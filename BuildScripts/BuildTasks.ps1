properties{
	$config="debug";
}


task -name ValidateConfig -action{
	assert("debug","release" -contains $config)
		"Invalid config:$config; valid values are debug and release";
}

task DeployWebsite1 {
    $website1ZipPath = Get-Conventions website1ZipPath
	$website1DeployFolder=Get-Conventions website1DeployFolder
	$poolName="firstWeb"

	$appPoolFlag = "/apppool.name:$poolName"
	Write-Host "Stopping IIS app pool"
    Invoke-AppCmd stop apppool $appPoolFlag -ErrorAction SilentlyContinue

    Extract-Artifact $website1ZipPath $website1DeployFolder

    Write-Host "Starting IIS app pool"
    Invoke-AppCmd start apppool $appPoolFlag
		
	Write-Host "Resetting IIS"
	Invoke-command -scriptblock {iisreset}
		
}

task -name PackageWebsite1 -description "produces a zip archive of the build output" -action{
	$website1ArtifactsFolder=Get-Conventions website1ArtifactsFolder
	$website1ZipPath=Get-Conventions website1ZipPath
	exec{
		if(Test-Path $website1ZipPath)
		{
			Remove-Item $website1ZipPath -Force
		}
		Write-Zip "$website1ArtifactsFolder\*" $website1ZipPath
	}
}

task -name CreateWebsite1 -description "create web app folder" -action{
	$binFolder=Get-Conventions binFolder

	$website1Folder=Get-Conventions website1Folder
	$webArtifactsFolder=Get-Conventions webArtifactsFolder
	$website1ArtifactsFolder=Get-Conventions website1ArtifactsFolder
	$website1ArtifactsBinFolder=Get-Conventions website1ArtifactsBinFolder
	exec{
		Copy-Item -LiteralPath $website1Folder -Destination $webArtifactsFolder -Recurse

		Remove-Item $website1ArtifactsBinFolder -Force -Recurse -ErrorAction SilentlyContinue
		Copy-Item -LiteralPath $binFolder -Destination $website1ArtifactsFolder -Recurse
	}
}

task -name UnitTests -action{
	Invoke-NUnitTests
}

task -name Build -description "build all artifacts" -action{
	$solutionPath=Get-Conventions solutionPath
	$binFolder=Get-Conventions binFolder
	exec{
		msbuild $solutionPath /t:build /p:OutputPath=$binFolder /p:Configuration=$config /m /verbosity:m /nologo
	}
}

task -name NugetRestore -description "nuget restore" -action{
	$solutionPath=Get-Conventions solutionPath
	$rootDir=Get-Conventions rootDir
    $nuget="$rootDir\Nuget\"
    exec{
        cd "$nuget"
        & "./nuget.exe" restore $solutionPath 
    }
}

task -name CleanSolution -description "clean all solution" -action{
	$solutionPath=Get-Conventions solutionPath
	exec{
		msbuild $solutionPath /t:clean /p:Configuration=$config /m /verbosity:m /nologo
	}
}

task -name CleanBuildArtifacts -description "delete all build artifacts artifacts\bin" -action{
	$binFolder=Get-Conventions binFolder
	exec{
		Remove-Item $binFolder -Force -Recurse -ErrorAction SilentlyContinue
		Create-Directory($binFolder)
	}
}

task -name CleanWebArtifacts -description "delete artifacts\web folder" -action{
	$webArtifacts=Get-Conventions webArtifactsFolder

	Remove-Item $webArtifacts -Force -Recurse -ErrorAction SilentlyContinue
	Create-Directory($webArtifacts)
}

function Remove-Recurse($buildPath) {
    Remove-Item $buildPath -Force -Recurse -ErrorAction SilentlyContinue
    Create-Directory($buildPath)
}

function Say-Hello{
	Write-Host "Hello world"
}

task -name Clean -depends CleanWebArtifacts,CleanBuildArtifacts,CleanSolution -description "clean bin folder and artifacts"
task -name Rebuild -depends Clean,NugetRestore,Build -description "rebuilds all artifacts from source"
task -name PackageWeb1 -depends Rebuild,CreateWebsite1,PackageWebsite1 -description "pakcage website1"
task -name DeployWeb1 -depends PackageWeb1,DeployWebsite1 -description "deploy website1"
task -name default -depends Say-Hello

