param([String]$gitEditMessageFilePath=".git/COMMIT_EDITMSG")

echo $gitEditMessageFilePath

$option = [System.StringSplitOptions]::RemoveEmptyEntries
$branchName = (git rev-parse --abbrev-ref HEAD)

if($branchName -eq "HEAD"){
    # We do not want to fetch JIRA Summary if we are doing "git rebase -i"
    exit 0
}
$jiraId = (git rev-parse --abbrev-ref HEAD).Split("/", $option)[1]
$jiraId = "$($jiraId.Split("-", $option)[0])-$($jiraId.Split("-", $option)[1])" 

$apiKey = cat “$env:UserProfile\.jira\api-key”
$username = cat “$env:UserProfile\.jira\username”


# Powershell 5.1
$base64AuthInfo = [Convert]::ToBase64String([Text.Encoding]::ASCII.GetBytes(("{0}:{1}" -f $username,$apiKey)))
$headers = @{
    Authorization = ("Basic {0}" -f $base64AuthInfo)
    Accept = "application/json"
}
$response = Invoke-WebRequest -Method 'Get' -uri "https://assetic.atlassian.net/rest/api/3/issue/$($jiraId)" -Headers $headers
$content = ConvertFrom-Json $response.Content 

# Example: 
# CLD-4791 As a user, I want to ensure Disposed assets are not able to be modified
$jiraTag = "`n`n`n$($content.key) $($content.fields.summary)"
echo $jiraTag
Add-Content $gitEditMessageFilePath $jiraTag





<# Use this when Powershell upgraded to Powershell 6
$apiKey = cat $apiKeyPath | ConvertTo-SecureString –AsPlainText -Force
$credential = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $apiKey
Invoke-RestMethod -Method Get -uri 'https://assetic.atlassian.net/' -Authentication 'Basic' -Credential $credential -ContentType "application/json"
#>