param($installPath, $toolsPath, $package, $project)

$file1 = $project.ProjectItems.Item("TRANS2QUIK.dll")
$file2 = $project.ProjectItems.Item("TRANS2QUIK.lib")

# set 'Copy To Output Directory' to 'Copy if newer'
$copyToOutput1 = $file1.Properties.Item("CopyToOutputDirectory")
$copyToOutput1.Value = 1

$copyToOutput2 = $file2.Properties.Item("CopyToOutputDirectory")
$copyToOutput2.Value = 1
