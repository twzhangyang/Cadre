function Create-Directory{
	param($folder)

	if(-not (Test-Path $folder)){
		Write-Host "Creating directory $dir"
		New-Item -Path $folder -ItemType directory
	}
}