$ErrorActionPreference = "Stop"

$relativePathToReleaseFolder = '..\DeveGpuFanSpeedController\bin\Release'
$relativePathToILRepackExe = '..\packages\ILRepack.2.0.13\tools\ILRepack.exe'
$fileNameOfPrimaryExe = 'DeveGpuFanSpeedController.exe'
$relativePathToOutputFolder = 'Output'

$invocation = (Get-Variable MyInvocation).Value
$directorypath = Split-Path $invocation.MyCommand.Path
$ilrepackexe = Join-Path $directorypath $relativePathToILRepackExe -Resolve

$releaseFolder = Join-Path $directorypath $relativePathToReleaseFolder -Resolve
$theexefilename = Join-Path $releaseFolder $fileNameOfPrimaryExe -Resolve
$outputfolder = Join-Path $directorypath $relativePathToOutputFolder
$outputexe = Join-Path $outputfolder $fileNameOfPrimaryExe

Write-Host $directorypath;
Write-Host $ilrepackexe;

$arguments = @();

$arguments += "/out:""$($outputexe)""";
$arguments += """$($theexefilename)""";

Get-ChildItem $releaseFolder -Filter *.dll | 
Foreach-Object {
	$path = """$($_.FullName)"""
	$arguments += $path
	Write-Host "Found dll for merging: $path"
}

Write-Host $arguments

& $ilrepackexe $arguments
if ($LastExitCode -ne 0) { $host.SetShouldExit($LastExitCode)  }