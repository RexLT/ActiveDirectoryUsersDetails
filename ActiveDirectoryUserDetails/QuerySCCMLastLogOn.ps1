<#
.SYNOPSIS
Get Computers by Last Logged on User via SCCM.
.DESCRIPTION
Queries SCCM for the list of computer’s whose last logged on user matches the supplied SamAccountName.
.SOURCE
http://blog.vertigion.com/post/16644240309/powershell-get-computers-by-last-logged-on-user
.PARAMETER SamAccountName
For users, this is typically their EUID.  Non-user accounts may vary.
.PARAMETER SiteName
SCCM Server Site Name.
.PARAMETER SCCMServer
SCCM Server Name.
.PARAMETER SCCM_SystemOUName
Default OU Name where your Computers are stored in the AD.
.PARAMETER PassThru
Quiet Mode.  Silence all Write-Host output.
.INPUTS
System.String SamAccountName
.OUTPUTS
List of Computer Names.
.EXAMPLE
Get-CompByUser user0123
SamAccountName:  user0123
 
Name
----
Computer0123A
Computer0123B
.EXAMPLE
Get-CompByUser @('user0123','user0456','user0789')
SamAccountName:  user0123
 
Name
----
Computer0123A
Computer0123B
SamAccountName:  user0456
SamAccountName:  user0789
Computer0789A
.EXAMPLE
Get-ADUser user0123 | Get-CompByUser
SamAccountName:  user0123
 
Name
----
Computer0123A
Computer0123B
.EXAMPLE
Get-CompByUser @('user0123','user0456','user0789') -PassThru | Measure-Object
 
Count    : 3
Average  :
Sum      :
Maximum  :
Minimum  :
Property :
.NOTES
Starting point gleaned from:  <a href="http://bit.ly/AliSQt">http://bit.ly/AliSQt</a>
.LINK
http://go.vertigion.com/PowerShell-Get-CompByUser
#>
function Get-CompByUser {
    param(
        [Alias("SamAccountName")]
        [parameter(
            Position = 0,
            Mandatory = $true,
            ValueFromPipeline = $true,
            ValueFromPipelineByPropertyName = $true,
            HelpMessage = "Enter the SamAccountName of a user account."
        )]
        $SamAccountNames
        ,
        [string]$SiteName="AG1",
        [string]$SCCMServer="DC1WP10201.energy.com.au",
        [string]$SCCM_SystemOUName="ENERGYCOM/COMPUTERS",
        [switch]$PassThru
    )
     
    Begin {
        [string] $SCCMNameSpace="root\sms\site_$SiteName"
        [int] $compCount = 0
        [int] $userCount = 0
        [int] $userUknCount = 0
         
        function _checkSCCM {
            param(
                [parameter(Mandatory = $true)]
                $SamAccountName
            )
            if (Get-ADUser -Filter{SamAccountName -eq $SamAccountName}) {
                if (!$PassThru.isPresent) { Write-Host -ForegroundColor green "SamAccountName:  $SamAccountName" }
                $userCount++
                Set-Variable -Scope 1 -Name userCount -Value $userCount
            } else {
                if (!$PassThru.isPresent) { Write-Host -ForegroundColor red "SamAccountName:  $SamAccountName" }
                $userUknCount++
                Set-Variable -Scope 1 -Name userUknCount -Value $userUknCount
            }
            $computers = Get-WmiObject -namespace $SCCMNameSpace -computer $SCCMServer -query "select SMS_R_System.Name, SMS_R_System.SystemOUName from  SMS_R_System where SMS_R_System.LastLogonUserName = ""$SamAccountName"" and SMS_R_System.SystemOUName = ""$SCCM_SystemOUName""" | select Name
            $compCount += $computers.Count
            Set-Variable -Scope 1 -Name compCount -Value $compCount
            $computers
        }
    }
     
    Process {
        switch -regex ($(($SamAccountNames.GetType()).Name)) {
            "ADUser" {
                _checkSCCM $SamAccountNames.SamAccountName
                if ($PassThru.isPresent) {
                    if ($_ProgressTotal) {
                        Write-Progress -Activity "Getting Computers by User" -Status "Processing User: $(($SamAccountNames).SamAccountName)" -PercentComplete ((($userCount+$userUknCount)/$_ProgressTotal)*100)
                    } else {
                        Write-Progress -Activity "Getting Computers by User" -Status "Processing User: $(($SamAccountNames).SamAccountName)"
                    }
                }
                break
            }
            "String|Object\[\]" {
                foreach ($SamAccountName in $SamAccountNames) {
                    _checkSCCM $SamAccountName
                }
            }
            default { Throw("Unable to handle that Type: $(($SamAccountNames.GetType()).Name)") }
        }
    }
     
    End {
        Write-Debug "SamAccountNames Type:  $(($SamAccountNames.GetType()).Name)"
        Write-Debug "Total User Count:  $userCount"
        Write-Debug "Total Computer Count:  $compCount"
        Write-Debug "Unknown User Count:  $userUknCount"
    }
}