New-WebAppPool WebTool
Set-ItemProperty IIS:\AppPools\WebTool managedRuntimeVersion v4.0

New-Item iis:\Sites\WebTool -bindings @{protocol="http";bindingInformation=":81:WebTool"} -physicalPath "$($env:appveyor_build_folder)\WebSite\WebTool"
Set-ItemProperty IIS:\Sites\WebTool -name applicationPool -value WebTool