param()
Write-Host "conventions"

$conventions = @{}
#solution folder
$conventions.rootDir=$global:solutionRoot
$conventions.solutionPath="$global:solutionRoot\Src\CadreManagement\CadreManagement.sln"
$conventions.webapiFolder="$global:solutionRoot\Src\CadreManagement\CadreManagement.WebApi"
$conventions.website="$global:solutionRoot\Src\CadreManagement\CadreManagement.Web"

#buildScript folder
$conventions.scriptRoot=$global:scriptRoot
$conventions.libsFolder="$global:scriptRoot\libs"

$conventions.artifactsFolder="$global:solutionRoot\Artifacts"
$conventions.binFolder="$global:solutionRoot\Artifacts\Bin"

#artifact\web
$conventions.websiteArtifactsFolder="$global:solutionRoot\Artifacts\Web"
$conventions.webapiArtifactsFolder="$global:solutionRoot\Artifacts\WebApi"

#artifact\zip
$conventions.artifactsZipFolder="$global:solutionRoot\Artifacts\zip"
$conventions.websiteZipPath="$global:solutionRoot\Artifacts\zip\Web.zip"
$conventions.webapiZipPath="$global:solutionRoot\Artifacts\zip\WebApi.zip"

#website
$conventions.websiteDeployFolder="C:\inetpub\wwwroot\cadre"
$conventions.webapiDeployFolder="C:\inetpub\wwwroot\cadreapi"


"Conventions being used:"
"solution folder `t`t $global:solutionRoot"
"script folder `t`t $global:scriptRoot"

$conventions.keys | % {
    Write-Host "$_`t: $($conventions.$_)"
}

