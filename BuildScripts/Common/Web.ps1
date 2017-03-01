#task WebTask {

#    #$artifactsDir = Get-Conventions artifactsDir
#    #$taskConfig = Get-InstallTaskConfiguration
#    #$spliceMap = Get-InstallTaskSpliceMap

#    if($taskConfig.isNavitaireEnv -eq "false") {
#        . Add-CarbonModule IIS
#        $appPoolFlag = "/apppool.name:$($taskConfig.appPool)"

#        try {
#            Write-Host "Stopping IIS app pool"
#            Invoke-AppCmd stop apppool $appPoolFlag
#            $tmp_path = $taskConfig.iisTempFolders

#            Write-Host "Checking $tmp_path"
#            if (Test-Path $tmp_path){
#                Remove-Item -Recurse -Force $tmp_path | Out-Null
#                Write-Host("Cleared!")
#                }
#        }
#        catch {
#        }
#    }

#    Extract-Artifact (Join-Path $artifactsDir $taskConfig.artifact) $taskConfig.sitePath $spliceMap

#    if($taskConfig.isNavitaireEnv -eq "false") {
#        Write-Host "Starting IIS app pool"
#        Invoke-AppCmd start apppool $appPoolFlag
		
#		Write-Host "Resetting IIS"
#		Invoke-command -scriptblock {iisreset}
		
#        $taskConfig.warmUpPaths | % { Invoke-WebApplicationWarmUp $_ }
#    }
#}



##task WebTask {
##    $artifactsDir = Get-Conventions artifactsDir
##    $taskConfig = Get-InstallTaskConfiguration
##    $spliceMap = Get-InstallTaskSpliceMap

##    if($taskConfig.isNavitaireEnv -eq "false") {
##        . Add-CarbonModule IIS
##        $appPoolFlag = "/apppool.name:$($taskConfig.appPool)"

##        try {
##            Write-Host "Stopping IIS app pool"
##            Invoke-AppCmd stop apppool $appPoolFlag
##            $tmp_path = $taskConfig.iisTempFolders

##            Write-Host "Checking $tmp_path"
##            if (Test-Path $tmp_path){
##                Remove-Item -Recurse -Force $tmp_path | Out-Null
##                Write-Host("Cleared!")
##                }
##        }
##        catch {
##        }
##    }

##    Extract-Artifact (Join-Path $artifactsDir $taskConfig.artifact) $taskConfig.sitePath $spliceMap

##    if($taskConfig.isNavitaireEnv -eq "false") {
##        Write-Host "Starting IIS app pool"
##        Invoke-AppCmd start apppool $appPoolFlag
		
##		Write-Host "Resetting IIS"
##		Invoke-command -scriptblock {iisreset}
		
##        $taskConfig.warmUpPaths | % { Invoke-WebApplicationWarmUp $_ }
##    }
##}