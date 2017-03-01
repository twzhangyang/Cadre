function Write-Zip($source, $destination){
    $libsFolder=Get-Conventions libsFolder

    $7z = "$libsFolder\7z\7za.exe"
    Write-Host "Zipping $source to $destination"
    & $7z a  $destination $source | Out-Null
}

function Expand-Zip($source, $destination) {
    $libsFolder=Get-Conventions libsFolder
    $7z = "$libsFolder\7z\7za.exe"

    Remove-Item $destination -Recurse -ErrorAction silentlycontinue

    Write-Host "Unzipping $source to $destination"

    $destination = "-o" + $destination
    &$7z x -y -aoa $source $destination | out-null
}