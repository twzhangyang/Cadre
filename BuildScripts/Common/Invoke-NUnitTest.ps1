function Stop-Nunit(){
    ps | where {$_.Name -Like "nunit*"} | Stop-Process -Force -ErrorAction SilentlyContinue
}


function Invoke-NUnitTests {
    $script:isError = $false

	$libsFolder=Get-Conventions libsFolder
    $nunit = Resolve-Path "$libsFolder\NUnit\nunit-console.exe"
	$solutionPath=Get-Conventions solutionPath
    $binFolder=Get-Conventions binFolder

	$unitTestsPathPattern="UnitTests.dll"
    $testProjects=""

	Get-ChildItem "$binFolder" | % {
        if($_.FullName -match "$unitTestsPathPattern"){
            $testProjects+=$_.FullName
        }
	}

	& {
        $ErrorActionPreference = "Continue"
        trap { $script:isError = $true; }
        Stop-Nunit
        Exec { 
			& $nunit $testProjects
		}
        Stop-Nunit
        }



    #$reportOutputDir = "$artifactsDir\$testType"
    #$nunitOutputXml = "$reportOutputDir\$testType-Results.xml"


        #Create-Directory($reportOutputDir)
        #$coverageResultsXml = "$reportOutputDir\Coverage-Results.xml"
        #$nunitReport = Resolve-Path "$libPath\NUnit-report-generator\NUnitHTMLReportGenerator.exe"
        #$opencover = Resolve-Path "$libPath\OpenCover\OpenCover.Console.exe"
        #$reportGen = Resolve-Path "$libPath\ReportGenerator\ReportGenerator.exe"
        #$filters = "`"-filter:$coverageFilters`""
        #$attribFilters = "`"-excludebyattribute:$attributeFilters`""
        #& {
        #    $ErrorActionPreference = "Continue"
        #    trap { $script:isError = $true; }
        #    Stop-Nunit
        #    Exec { & $opencover "-targetdir:$buildPath" "-target:$nunit" "-targetargs:$testProjects --labels:All" "-register:user" "-threshold:3" "-output:$coverageResultsXml" "$filters" "-mergebyhash" "`"-excludebyfile:*\*.asax.cs;*\*.Designer.cs;`"" "$attribFilters" "-returntargetcode" }
        #    Stop-Nunit
        #    Exec { & $reportGen "-reports:$coverageResultsXml" "-targetdir:$reportOutputDir\coverage" "-verbosity:Error" }
        #    Exec { & $nunitReport $nunitOutputXml "$reportOutputDir\$testType-Reports.html" }
        #}

        #Check-Ratchet "$testType" "$unitTestsCoverageTolerableRatchets" "$rootDir\Build\$testType-Previous-Ratchets.dat" "$coverageResultsXml" "string(//CoverageSession/Summary/@sequenceCoverage)" $false


    if($script:isError) {
        throw "Test failure"
    }
}
