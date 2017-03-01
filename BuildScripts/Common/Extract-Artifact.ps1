function Extract-Artifact($source, $destination) {
    if(-not (Test-Path $source)){
        throw "Artifact $source not found"
    }

    $source = Get-Item $source

    if($source.extension -eq ".zip"){
        Create-Directory $destination
        Expand-Zip $source.FullName $destination
    }
}