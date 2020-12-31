# Make sure chocolatey is installed
# https://docs.chocolatey.org/en-us/create/functions/update-sessionenvironment
# https://stackoverflow.com/questions/46758437/how-to-refresh-the-environment-of-a-powershell-session-after-a-chocolatey-instal

Import-Module "$env:ChocolateyInstall\helpers\chocolateyInstaller.psm1" -Force;
refreshenv;
