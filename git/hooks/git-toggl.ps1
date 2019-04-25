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

function Get-TogglProjectId(){
    return 11269147;
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

function Start-Tracking(){
    [cmdletbinding(ConfirmImpact="None")]
    param(
        [Parameter(Mandatory=$true, HelpMessage="Toggl Request Headers")]
        [hashtable]$togglRequestHeaders,

        [Parameter(Mandatory=$true, HelpMessage="JIRA Summary")]
        [string] $jiraSummary,

        [Parameter(Mandatory=$true, HelpMessage="Project ID Toggl")]
        [string] $projectId
    )
    end{
        Write-Verbose "$($PSBoundParameters | Out-String)"

        $startDateTime = (Get-Date).ToUniversalTime()
        $payload = @{
            "time_entry" = @{
                "description" = $jiraSummary
                "start" = $startDateTime.ToUniversalTime().ToString("o")
                "pid" = $projectId
                "created_with" = "powershell"
            }
        } | ConvertTo-Json

        $response = Invoke-WebRequest -Method 'Post' `
            -uri "https://www.toggl.com/api/v8/time_entries/start" `
            -ContentType "application/json" `
            -Body $payload `
            -Headers $togglRequestHeaders | ConvertFrom-Json

        Write-Host "Start tracking [$response.data.id] [$jiraSummary]"
        return $response
    }
}

function Stop-Tracking(){
    [cmdletbinding(ConfirmImpact="None")]
    param(
        [Parameter(Mandatory=$true, HelpMessage="Toggl Request Headers")]
        [hashtable]$togglRequestHeaders,

        [Parameter(Mandatory=$false, HelpMessage="End DateTime in UTC")]
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
                "duration" = (New-TimeSpan `
                    -Start $currentEntry.data.start `
                    -End $endDateTime).TotalSeconds
                "stop" = $endDateTime.ToString("o")
                "start" = $currentEntry.data.start.ToString("o")
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
        $payload | Out-String -Stream | Write-Debug
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
    [cmdletbinding(ConfirmImpact="None")]
    param()

    Main
}

function Stop-Day(){
    [cmdletbinding(ConfirmImpact="None")]
    param()

    function Get-TodayTogglEntries(){
        [cmdletbinding(ConfirmImpact="None")]
        param(
            [Parameter(Mandatory=$true, HelpMessage="Toggl Request Headers")]
            [hashtable]$togglRequestHeaders,

            [Parameter(Mandatory=$true, HelpMessage="Project ID Toggl")]
            [string] $projectId
        )
        end{
            $endLocalDateTime = (Get-Date)
            $todayStartDate = [System.Web.HttpUtility]::UrlEncode((Get-Date -Day $endLocalDateTime.Day `
                -Month $endLocalDateTime.Month `
                -Year $endLocalDateTime.Year `
                -Hour 00 -Minute 00 -Second 00).ToUniversalTime().ToString("o"))
            $todayEndDate = [System.Web.HttpUtility]::UrlEncode((Get-Date -Day $endLocalDateTime.Day `
                -Month $endLocalDateTime.Month `
                -Year $endLocalDateTime.Year `
                -Hour 23 -Minute 59 -Second 59).ToUniversalTime().ToString("o"))

            $todayEntries = Invoke-WebRequest -Method 'Get' `
                -uri "https://www.toggl.com/api/v8/time_entries?start_date=$todayStartDate&end_date=$todayEndDate" `
                -Headers $togglRequestHeaders

            Write-Debug $todayEntries
            return $todayEntries | ConvertFrom-Json
        }
    }

    function Get-RemainingDateTime(){
        [cmdletbinding(ConfirmImpact="None")]
        param(
            [Parameter(Mandatory=$true, HelpMessage="Toggl Time Entries")]
            [object[]]$timeEntries
        )
        end{
            $totalSeconds = ($timeEntries `
                | Where-Object {$_.duration -gt 0} `
                | Measure-Object -Property duration -Sum).Sum

            # 27360 seconds is equivalent to 7.6 hours
            $remainingSeconds = 27360 - $totalSeconds
            $latestEntry = ($timeEntries `
                | Where-Object {!$_.stop} `
                | Sort-Object -Descending -Property start `
                | Select-Object -index 0)

            $remainingDateTime = $latestEntry.start + (New-TimeSpan -Seconds $remainingSeconds)
            $remaining = @{Seconds = $remainingSeconds; DateTime = $remainingDateTime}

            ($remaining | Out-String -Stream) | Write-Debug

            return $remaining
        }
    }

    $togglRequestHeaders = Get-TogglRequestHeaders
    $projectId = Get-TogglProjectId
    $todayEntries = Get-TodayTogglEntries -togglRequestHeaders $togglRequestHeaders -projectId $projectId
    $runningEntry = @($todayEntries | Where-Object { $_.duration -lt 0 }[0])

    if($runningEntry){
        Write-Host "End of day; stop tracking..."
        Write-Debug $todayEntries.GetType()
        $remaining = Get-RemainingDateTime -timeEntries $todayEntries
        Stop-Tracking -togglRequestHeaders $togglRequestHeaders `
            -endDateTime $remaining.DateTime
    }
    else{
        Write-Host "No running entry."
    }
}

function Main(){

    [cmdletbinding(ConfirmImpact="None")]
    param()

$jiraId = Get-JiraId
$jiraRequestHeaders = Get-JiraRequestHeaders
$jiraSummary = Get-JiraSummary($jiraId, $jiraRequestHeaders)

$projectId = Get-TogglProjectId

    $togglRequestHeaders = Get-TogglRequestHeaders

    $trackingResponse = Start-Tracking `
        -togglRequestHeaders $togglRequestHeaders `
        -jiraSummary $jiraSummary `
        -projectId $projectId

    $trackingResponse | Format-List
}

