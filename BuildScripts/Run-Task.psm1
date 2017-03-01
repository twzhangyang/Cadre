$scriptRoot=$global:scriptRoot 
$libsFolder = "$global:scriptRoot\Libs"

Import-Module "$libsFolder\psake\psake.psm1" -Force
$psake.use_exit_on_error = $true
#how to import pscx module
#Import-Module "$scriptRoot\Libs\Pscx\Pscx.psm1" -Force

Get-ChildItem "$scriptRoot\Common" -Recurse -Filter "*.ps1" | foreach { . $_.FullName}
Get-ChildItem "$libsFolder\Carbon\Functions" -Recurse -Filter "*.ps1" | foreach { . $_.FullName }

function Run-Task{
	param($task)

	Write-Host "Invoking task $task..."

	$buildTasks="$scriptRoot\{0}.ps1" -f "BuildTasks"
	Invoke-psake $buildTasks `
			-taskList $task

	if(-not $psake.build_success) { throw "{0} failed!" -f $task }
}

