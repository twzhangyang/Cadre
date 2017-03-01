param()
Write-Host "conventions"

$conventions = @{}
#solution folder
$conventions.rootDir=$global:solutionRoot
$conventions.solutionPath="$global:solutionRoot\firstWebApp.sln"
$conventions.website1Folder="$global:solutionRoot\WebApp"

#buildScript folder
$conventions.scriptRoot=$global:scriptRoot
$conventions.libsFolder="$global:scriptRoot\libs"

$conventions.artifactsFolder="$global:solutionRoot\Artifacts"
$conventions.binFolder="$global:solutionRoot\Artifacts\Bin"

#artifact\web
$conventions.webArtifactsFolder="$global:solutionRoot\Artifacts\Web"
$conventions.website1ArtifactsFolder="$global:solutionRoot\Artifacts\Web\WebApp"
$conventions.website1ArtifactsBinFolder="$global:solutionRoot\Artifacts\Web\WebApp\Bin"

#artifact\zip
$conventions.artifactsZipFolder="$global:solutionRoot\Artifacts\zip"
$conventions.website1ZipPath="$global:solutionRoot\Artifacts\zip\WebApp.zip"

#website
$conventions.website1DeployFolder="C:\inetpub\wwwroot\firstWeb"


"Conventions being used:"
"solution folder `t`t $global:solutionRoot"
"script folder `t`t $global:scriptRoot"

$conventions.keys | % {
    Write-Host "$_`t: $($conventions.$_)"
}

