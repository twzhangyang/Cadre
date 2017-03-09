[CmdletBinding()]
param($task)

trap
{
	Write-Error $_
	exit 1
}

if([string]::IsNullOrEmpty($task))
{
	$task='default'
}

$rootDir=Split-Path $MyInvocation.MyCommand.Path -Parent
$rootDir=$rootDir | Split-Path

$global:solutionRoot = $rootDir
$global:scriptRoot = $PSScriptRoot

Write-Host "`$global:solutionRoot`=$global:solutionRoot"
Write-Host "`$global:scriptRoot`=$global:scriptRoot"

Import-Module "$PSScriptRoot\Run-Task.psm1" -Force

Run-task $task



