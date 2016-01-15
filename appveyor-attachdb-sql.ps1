$startPath = "$($env:appveyor_build_folder)\DBProject\WebToolDB\WebToolDB\Backup"
$sqlInstance = "\SQL2008R2SP2"
$dbName = "WebTool"


# attach mdf to local instance
$mdfFile = join-path $startPath "WebTool.mdf"
$ldfFile = join-path $startPath "WebTool_log.ldf"
sqlcmd -S "$sqlInstance" -Q "Use [master]; CREATE DATABASE [$dbName] ON (FILENAME = '$mdfFile'),(FILENAME = '$ldfFile') for ATTACH"