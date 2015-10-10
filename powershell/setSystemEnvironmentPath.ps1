$newPath = 'C:\Program Files (x86)\Elm Platform\0.15.1\bin'
$oldPath = [Environment]::GetEnvironmentVariable('path', 'machine');
[Environment]::SetEnvironmentVariable('path2', "$($newPath);$($oldPath)",'Machine');
