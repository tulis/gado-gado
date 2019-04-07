# Setup task scheduler to run this script
# https://stackoverflow.com/questions/23953926/how-do-i-execute-a-powershell-script-automatically-using-windows-task-scheduler

function Get-JiraId(){
    $currentBranchName = (git rev-parse --abbrev-ref HEAD)
    $option = [System.StringSplitOptions]::RemoveEmptyEntries

    if($currentBranchName -eq "HEAD"){
        # We do not want to log toggl if we are doing "git rebase -i"
        exit 0
    }
    elseif($currentBranchName.Split("/", $option).length -le 1){
        # We also do not want to log if we are in develop or master branch
        exit 0
    }
    elseif($currentBranchName.Split("/", $option)[1].Split("-", $option).length -le 1){
        # Applies to prep/yyyy.m.n branch
        exit 0
    }

    $jiraId = ($currentBranchName).Split("/", $option)[1]
    $jiraId = "$($jiraId.Split("-", $option)[0])-$($jiraId.Split("-", $option)[1])"

    return $jiraId
}

function Get-JiraRequestHeaders(){
    $apiKey = Get-Content “$env:UserProfile\.jira\api-key”
    $username = Get-Content “$env:UserProfile\.jira\username”

    # Powershell 5.1
    $base64AuthInfo = [Convert]::ToBase64String([Text.Encoding]::ASCII.GetBytes(("{0}:{1}" -f $username,$apiKey)))
    $headers = @{
        Authorization = ("Basic {0}" -f $base64AuthInfo)
        Accept = "application/json"
    }

    return $headers
}

function Get-JiraSummary([string]$jiraId, [hashtable]$jiraRequestHeaders){

    $response = Invoke-WebRequest -Method 'Get' `
        -uri "https://assetic.atlassian.net/rest/api/3/issue/$($jiraId)" `
        -Headers $jiraRequestHeaders

    $content = ConvertFrom-Json $response.Content

    # Example:
    # ABC-1234 As a user, I want to get JIRA Summary
    $jiraSummary = "`n`n`n$($content.key) $($content.fields.summary)"

    return $jiraSummary
}

function Get-TogglRequestHeaders() {
    $apiKey = Get-Content “$env:UserProfile\.toggl\api-key”
    $password = "api_token"

    # Powershell 5.1
    $base64AuthInfo = [Convert]::ToBase64String([Text.Encoding]::ASCII.GetBytes(("{0}:{1}" -f $apiKey,$password)))
    $headers = @{
        Authorization = ("Basic {0}" -f $base64AuthInfo)
        Accept = "application/json"
    }

    return $headers
}

function Start-Tracking([string] $jiraId){

}

function Stop-Tracking(){
    [cmdletbinding(ConfirmImpact="Low")]
    param(
        [Parameter(Mandatory=$true, HelpMessage="Toggl Request Headers")]
        [hashtable]$togglRequestHeaders,

        [Parameter(Mandatory=$false, HelpMessage="local time (not UTC)")]
        [DateTime] $endDateTime = (Get-Date).ToUniversalTime()
    )
    end {
        Write-Verbose "$($PSBoundParameters | Out-String)"

        $currentEntry = Invoke-WebRequest -Method 'Get' `
            -uri "https://www.toggl.com/api/v8/time_entries/current" `
            -Headers $togglRequestHeaders | ConvertFrom-Json

        $entryId = $currentEntry.data.id
        $payload = @{
            "time_entry" = @{
                "description" = $currentEntry.data.description
                "duration" = (New-TimeSpan -Start $currentEntry.data.start.ToUniversalTime() -End $endDateTime).TotalSeconds
                "stop" = $endDateTime.ToString("o")
                "start" = $currentEntry.data.start.ToUniversalTime().ToString("o")
                "pid" = $currentEntry.data.pid
                "duronly" = $true
                "created_with" = "powershell"
            }
        } | ConvertTo-Json -Depth 5

        Write-Debug "Stopping [$entryId]...."
        $response = Invoke-WebRequest -Method 'Put' `
            -uri "https://www.toggl.com/api/v8/time_entries/$entryId/stop" `
            -ContentType "application/json" `
            -Headers $togglRequestHeaders

        Write-Debug "Updating duration for [$entryId]..."
        $response = Invoke-WebRequest -Method 'Put' `
            -uri "https://www.toggl.com/api/v8/time_entries/$entryId" `
            -ContentType "application/json" `
            -Body $payload `
            -Headers $togglRequestHeaders

        Write-Debug $response
        return $response | ConvertFrom-Json
    }
}

function Start-Day(){

}

function Stop-Day(){

}



function Get-TogglePayload([int]$projectId, [string]$jiraSummary){

    $payload = @{
        "time_entry" = @{
        "description" = $jiraSummary
        "duration" = 1000
        "start" = (Get-Date).ToUniversalTime().ToString("o")
        "pid" = $projectId
        "created_with" = "powershell"
    }
    }
    return $payload | ConvertTo-Json -Depth 5
}

function Add-TogglTimeEntry([Hashtable]$togglRequestHeaders, [string] $togglPayload){
    Write-Host $togglRequestHeaders
    Write-Host "Toggl Payload: $togglPayload"

    #Write-Host (Invoke-WebRequest -Method Get -uri "" -Headers $togglRequestHeaders)

    $response = Invoke-WebRequest -Method 'Post' `
        -uri "https://www.toggl.com/api/v8/time_entries" `
        -ContentType "application/json" `
        -Body $togglPayload `
        -Headers $togglRequestHeaders

    return $response
}

function Main(){

$jiraId = Get-JiraId
$jiraRequestHeaders = Get-JiraRequestHeaders
$jiraSummary = Get-JiraSummary($jiraId, $jiraRequestHeaders)

    # $togglRequestHeaders = Get-TogglRequestHeaders
    # $togglPayload = Get-TogglePayload
    # $togglCreateResponse = Add-TogglTimeEntry($togglRequestHeaders, $togglPayload)

    # Write-Host $togglCreateResponse
}

