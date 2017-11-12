'---------------------------------------------------------------------------------------------------------------------------------
' Program Name: ADUserDetails
' Written By Nigel Bolton, UXC Connect | Ready for what comes next
' Copyright 2017
'---------------------------------------------------------------------------------------------------------------------------------
' This application is designed to report the user details from active directory in a more visually friendly manner
' This applicaiton is freeware & no liability is accepted for any damage, etc, that may result from using this software.
' By using this software you automatically idemnify the writer of any liability
'---------------------------------------------------------------------------------------------------------------------------------

Imports System.Deployment.Application
Imports System.Reflection
Imports System.Globalization
Imports System.IO

Public Class MainWindow

    Dim booDomain As Boolean
    Dim sr_importusers As StreamReader
    Dim sw_exportusers As StreamWriter
    Dim UserDetails As New clsUser

    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '-- Check if running on domain-joined computer or not
        Try
            DirectoryServices.ActiveDirectory.Domain.GetComputerDomain()
            Text = "Active Directory User Details"
            gbxUserDetails.Text = "Active Directory User Details"
            lblADUser.Text = "Enter Active Directory User Name"
            lblDomain.Text = "Domain"
            booDomain = True

        Catch ex As Exception
            Text = "Workgroup User Details"
            gbxUserDetails.Text = "Workgroup User Details"
            lblADUser.Text = "Enter Workgroup User Name"
            lblDomain.Text = "Workgroup"
            booDomain = False

        End Try

        '-- Add version details
        Try
            Text = Text & " (V" & ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString & ")"

        Catch ex As Exception
            Text = Text & " (V" & Assembly.GetExecutingAssembly.GetName.Version.ToString & ")"
        End Try

        '-- Add current computer details
        txtRegion.Text = CultureInfo.CurrentCulture.EnglishName
        txtDomainName.Text = Environment.UserDomainName
        txtComputerName.Text = Environment.MachineName

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        If txtADUser.Text <> "" Then

            Dim psi As New ProcessStartInfo("cmd.exe")
            Dim p As Process
            Dim cmdstr As String

            '-- Redirect both streams so we can write/read them
            psi.RedirectStandardInput = True
            psi.RedirectStandardOutput = True
            psi.UseShellExecute = False
            psi.CreateNoWindow = True

            '-- Start the procses
            p = Process.Start(psi)

            '-- Generate command
            cmdstr = "net user " & txtADUser.Text
            If booDomain = True Then
                cmdstr = cmdstr & " /domain"
            End If

            '-- Issue the Net user command
            p.StandardInput.WriteLine(cmdstr)

            '-- Exit the application
            p.StandardInput.WriteLine("exit")

            '-- Read all the output generated from it.
            txtOutput.Text = p.StandardOutput.ReadToEnd()

            '-- Reset window controls
            ResetWindowControls()

            '-- Extract the user data
            ExtractUserData()

        End If

        '-- Select ADUser name when command finishes
        txtADUser.Select()
        txtADUser.SelectAll()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Me.Close()

    End Sub

    Private Sub ExtractUserData()

        Dim gloParamLen As Integer = 30
        Dim strUserData() As String
        Dim strDataLine As String
        Dim lngTimeDiffHrs As Long
        Dim booUserFound As Boolean = False

        If txtOutput.Text <> "" Then

            '-- Split text by line feed
            strUserData = Split(txtOutput.Text, vbCrLf)

            '-- Check each line
            For Each strDataLine In strUserData

                '-- Extract user name
                If strDataLine.StartsWith("User name") Then
                    txtUserName.Text = Mid(strDataLine, gloParamLen)
                    UserDetails.UserName = txtUserName.Text
                    booUserFound = True
                End If

                '-- Extract full user name
                If strDataLine.StartsWith("Full Name") Then
                    txtFullName.Text = Mid(strDataLine, gloParamLen)
                    UserDetails.UserFullName = txtFullName.Text
                End If

                '-- Extract user's comment
                If strDataLine.StartsWith("User's comment") Then
                    txtUserComment.Text = Mid(strDataLine, gloParamLen)
                End If

                '-- Extract comment
                If strDataLine.StartsWith("Comment") Then
                    txtComment.Text = Mid(strDataLine, gloParamLen)
                End If

                '-- Extract Account active
                If strDataLine.StartsWith("Account active") Then
                    If Mid(strDataLine, gloParamLen) = "Yes" Then
                        pbxAccountActive.Image = My.Resources.StatusAnnotations_Complete_and_ok_32xLG_color
                        UserDetails.AccountActive = True
                        UserDetails.AccountLocked = False
                    Else
                        If Mid(strDataLine, gloParamLen) = "Locked" Then
                            pbxAccountActive.Image = My.Resources.lock_symbol_icon_68326
                            UserDetails.AccountActive = False
                            UserDetails.AccountLocked = True
                        Else
                            pbxAccountActive.Image = My.Resources.StatusAnnotations_Critical_32xLG_color
                            UserDetails.AccountActive = False
                            UserDetails.AccountLocked = False
                        End If
                    End If
                End If

                '-- Extract Account expires
                If strDataLine.StartsWith("Account expires") Then
                    txtAccountExpires.Text = Mid(strDataLine, gloParamLen)
                    If txtAccountExpires.Text = "Never" Then
                        pbxAccountExpires.Image = My.Resources.StatusAnnotations_Complete_and_ok_32xLG_color
                        txtAccountExpiresDays.Text = ""
                        UserDetails.AccountExpired = False
                    Else
                        Try
                            lngTimeDiffHrs = DateDiff(DateInterval.Hour, Now, DateTime.Parse(txtAccountExpires.Text))
                            If (lngTimeDiffHrs / 24) < 10 And (lngTimeDiffHrs / 24) > -10 Then
                                txtAccountExpiresDays.Text = Format(lngTimeDiffHrs / 24, "F2").ToString
                            Else
                                txtAccountExpiresDays.Text = Format(lngTimeDiffHrs / 24, "F0").ToString
                            End If

                        Catch ex As Exception
                            txtAccountExpiresDays.Text = ""
                        End Try
                        If Val(txtAccountExpiresDays.Text) >= 0 Then
                            pbxAccountExpires.Image = My.Resources.StatusAnnotations_Complete_and_ok_32xLG_color
                            UserDetails.AccountExpired = True
                        Else
                            pbxAccountExpires.Image = My.Resources.StatusAnnotations_Critical_32xLG_color
                            UserDetails.AccountExpired = False
                        End If
                    End If
                End If

                '-- Extract Password last set
                If strDataLine.StartsWith("Password last set") Then
                    txtPasswordLastSet.Text = Mid(strDataLine, gloParamLen)
                    Try
                        lngTimeDiffHrs = DateDiff(DateInterval.Hour, DateTime.Parse(txtPasswordLastSet.Text), Now)
                        If (lngTimeDiffHrs / 24) < 10 And (lngTimeDiffHrs / 24) > -10 Then
                            txtPasswordLastSetDays.Text = Format(lngTimeDiffHrs / 24, "F2").ToString
                        Else
                            txtPasswordLastSetDays.Text = Format(lngTimeDiffHrs / 24, "F0").ToString
                        End If
                        'txtPasswordLastSetDays.Text = Format(DateDiff(DateInterval.Hour, DateTime.Parse(txtPasswordLastSet.Text), Now) / 24, "F").ToString
                    Catch ex As Exception
                        txtPasswordLastSetDays.Text = ""
                    End Try
                End If

                '-- Extract Password expires
                If strDataLine.StartsWith("Password expires") Then
                    txtPasswordExpires.Text = Mid(strDataLine, gloParamLen)
                    If txtPasswordExpires.Text = "Never" Then
                        pbxPasswordExpires.Image = My.Resources.StatusAnnotations_Complete_and_ok_32xLG_color
                        txtPasswordExpiresDays.Text = ""
                        UserDetails.PasswordExpired = False
                    Else
                        Try
                            lngTimeDiffHrs = DateDiff(DateInterval.Hour, Now, DateTime.Parse(txtPasswordExpires.Text))
                            If (lngTimeDiffHrs / 24) < 10 And (lngTimeDiffHrs / 24) > -10 Then
                                txtPasswordExpiresDays.Text = Format(lngTimeDiffHrs / 24, "F2").ToString
                            Else
                                txtPasswordExpiresDays.Text = Format(lngTimeDiffHrs / 24, "F0").ToString
                            End If
                            'txtPasswordExpiresDays.Text = Format(DateDiff(DateInterval.Hour, Now, DateTime.Parse(txtPasswordExpires.Text)), "F").ToString
                        Catch ex As Exception
                            txtPasswordExpiresDays.Text = ""
                        End Try
                        If Val(txtPasswordExpiresDays.Text) >= 0 Then
                            pbxPasswordExpires.Image = My.Resources.StatusAnnotations_Complete_and_ok_32xLG_color
                            UserDetails.PasswordExpired = False
                        Else
                            pbxPasswordExpires.Image = My.Resources.StatusAnnotations_Critical_32xLG_color
                            UserDetails.PasswordExpired = True
                        End If
                    End If
                End If

                '-- Extract Password changeable
                Dim lngPwdChangeable As Long

                If strDataLine.StartsWith("Password changeable") Then
                    txtPasswordChangeable.Text = Mid(strDataLine, gloParamLen)
                    If txtPasswordChangeable.Text = "Never" Then
                        pbxPasswordChangeable.Image = My.Resources.StatusAnnotations_Complete_and_ok_32xLG_color
                    Else
                        Try
                            lngPwdChangeable = DateDiff(DateInterval.Hour, DateTime.Parse(txtPasswordChangeable.Text), Now)
                        Catch ex As Exception
                        End Try
                        If lngPwdChangeable >= 0 Then
                            pbxPasswordChangeable.Image = My.Resources.StatusAnnotations_Complete_and_ok_32xLG_color
                        Else
                            pbxPasswordChangeable.Image = My.Resources.StatusAnnotations_Critical_32xLG_color
                        End If
                    End If
                End If

                '-- Extract Password required
                If strDataLine.StartsWith("Password required") Then
                    If Mid(strDataLine, gloParamLen) = "Yes" Then
                        pbxPasswordRequired.Image = My.Resources.StatusAnnotations_Complete_and_ok_32xLG_color
                    Else
                        pbxPasswordRequired.Image = My.Resources.StatusAnnotations_Information_32xLG_color
                    End If
                End If

                '-- Extract User may change password
                If strDataLine.StartsWith("User may change password") Then
                    If Mid(strDataLine, gloParamLen) = "Yes" Then
                        pbxMayChangePassword.Image = My.Resources.StatusAnnotations_Complete_and_ok_32xLG_color
                    Else
                        pbxMayChangePassword.Image = My.Resources.StatusAnnotations_Critical_32xLG_color
                    End If

                End If

                '-- Extract logon script
                If strDataLine.StartsWith("Logon script") Then
                    txtLogonScript.Text = Mid(strDataLine, gloParamLen)
                End If

                '-- Extract user profile
                If strDataLine.StartsWith("User profile") Then
                    txtUserProfile.Text = Mid(strDataLine, gloParamLen)
                End If

                '-- Extract home directory
                If strDataLine.StartsWith("Home directory") Then
                    txtHomeDirectory.Text = Mid(strDataLine, gloParamLen)
                End If

                '-- Extract country code
                If strDataLine.StartsWith("Country code") Or strDataLine.StartsWith("Country/region code") Then
                    txtCountryCode.Text = Mid(strDataLine, gloParamLen)
                End If

                '-- Extract last logon
                If strDataLine.StartsWith("Last logon") Then
                    txtLastLogon.Text = Mid(strDataLine, gloParamLen)
                    If txtLastLogon.Text <> "Never" Or txtLastLogon.Text <> "" Then
                        Try
                            lngTimeDiffHrs = DateDiff(DateInterval.Hour, DateTime.Parse(txtLastLogon.Text), Now)
                            If (lngTimeDiffHrs / 24) < 10 And (lngTimeDiffHrs / 24) > -10 Then
                                txtLastLogonDays.Text = Format(lngTimeDiffHrs / 24, "F2").ToString
                            Else
                                txtLastLogonDays.Text = Format(lngTimeDiffHrs / 24, "F0").ToString
                            End If
                            'txtLastLogonDays.Text = Format(DateDiff(DateInterval.Hour, DateTime.Parse(txtLastLogon.Text), Now), "F").ToString
                        Catch ex As Exception
                            txtLastLogonDays.Text = ""
                        End Try
                    End If
                End If
            Next

            '-- Check if user was found
            If booUserFound = False Then
                txtUserName.Text = "No user was found"
                UserDetails.UserName = txtUserName.Text
            End If
        End If

    End Sub

    Private Sub txtADUser_GotFocus(sender As Object, e As EventArgs) Handles txtADUser.GotFocus

        '-- Select user name text field when it gets the focus
        txtADUser.Select()
        txtADUser.SelectAll()

    End Sub

    Private Sub txtADUser_LostFocus(sender As Object, e As EventArgs) Handles txtADUser.LostFocus

        '-- Re-select user name text field when it loses focus
        txtADUser.Select()
        txtADUser.SelectAll()

    End Sub

    Private Sub ResetWindowControls()

        '-- Initialise window controls
        txtUserName.Text = ""
        txtCountryCode.Text = ""
        txtFullName.Text = ""
        txtUserComment.Text = ""
        txtComment.Text = ""
        txtLastLogon.Text = ""
        txtLastLogonDays.Text = ""
        txtAccountExpires.Text = ""
        txtAccountExpiresDays.Text = ""
        txtPasswordExpires.Text = ""
        txtPasswordExpiresDays.Text = ""
        txtPasswordLastSet.Text = ""
        txtPasswordLastSetDays.Text = ""
        txtPasswordChangeable.Text = ""
        txtLogonScript.Text = ""
        txtUserProfile.Text = ""
        txtHomeDirectory.Text = ""

        pbxAccountActive.Image = Nothing
        pbxPasswordRequired.Image = Nothing
        pbxMayChangePassword.Image = Nothing
        pbxAccountExpires.Image = Nothing
        pbxPasswordExpires.Image = Nothing
        pbxPasswordLastSet.Image = Nothing
        pbxPasswordChangeable.Image = Nothing

    End Sub

    Private Sub btnImportUserNames_Click(sender As Object, e As EventArgs) Handles btnImportUserNames.Click

        Dim ofd As New OpenFileDialog

        '-- Set up open file dialog
        ofd.Filter = "CSV file|*.csv|Text file|*.txt|All files|*.*"
        ofd.Title = "Select import users file"

        '-- Import list of users
        If ofd.ShowDialog = DialogResult.OK Then

            Dim strline As String

            '-- Open import file
            sr_importusers = New StreamReader(ofd.FileName)

            '-- Read first line & confirm it contains header name
            strline = sr_importusers.ReadLine
            If strline.ToUpper = "USER NAMES" Or strline.ToUpper = "USERNAMES" Then
                txtImportUserNames.Text = ofd.FileName
                pbxImportUserNames.Image = My.Resources.StatusAnnotations_Complete_and_ok_32xLG_color
            Else
                txtImportUserNames.Text = "INVALID HEADER NAME"
                pbxImportUserNames.Image = My.Resources.StatusAnnotations_Critical_32xLG_color
            End If

            '-- Enable validate user button
            If txtImportUserNames.Text = "" Or txtImportUserNames.Text = "INVALID HEADER NAME" Or txtExportFileName.Text = "" Then
                btnValidateUsers.Enabled = False
            Else
                btnValidateUsers.Enabled = True
            End If

        End If

    End Sub

    Private Sub btnExportFileName_Click(sender As Object, e As EventArgs) Handles btnExportFileName.Click

        Dim sfd As New SaveFileDialog
        Dim strline As String

        '-- Set up save file dialog
        sfd.CheckFileExists = False
        sfd.Title = "Save the exported users file"

        '-- Get file name & location to export the user results
        If txtImportUserNames.Text <> "" And txtImportUserNames.Text <> "INVALID HEADER NAME" Then
            'txtExportFileName.Text = Path.GetDirectoryName(txtImportUserNames.Text) & "\" & Path.GetFileNameWithoutExtension(txtImportUserNames.Text) & "_VERIFIED.csv"
            sfd.InitialDirectory = Path.GetDirectoryName(txtImportUserNames.Text)
            sfd.FileName = Path.GetFileNameWithoutExtension(txtImportUserNames.Text) & "_VERIFIED.csv"
            sfd.ShowDialog()
            txtExportFileName.Text = sfd.FileName
            sw_exportusers = New StreamWriter(sfd.FileName)

            '-- Write headers
            strline = "User Name,User Name Found, User Full Name, Account Active, Account Expired, Account Locked"
            sw_exportusers.WriteLine(strline)

            '-- Enable validate user button
            If txtImportUserNames.Text = "" Or txtImportUserNames.Text = "INVALID HEADER NAME" Or txtExportFileName.Text = "" Then
                btnValidateUsers.Enabled = False
            Else
                btnValidateUsers.Enabled = True
            End If
        Else
            txtExportFileName.Text = ""
        End If

    End Sub

    Private Sub btnValidateUsers_Click(sender As Object, e As EventArgs) Handles btnValidateUsers.Click

        Dim strUserResults As String
        Dim strline As String
        Dim RecordsProcessed As Integer = 0

        '-- Validate import & export files
        If txtImportUserNames.Text <> "INVALID HEADER NAME" And txtExportFileName.Text <> "" Then

            '-- Read each user name
            Do

                '-- Clear any existing user details
                UserDetails.ClearUserDetails()

                strline = sr_importusers.ReadLine

                '-- Search for user
                txtADUser.Text = strline
                btnSearch.PerformClick()

                '-- Extract data
                strUserResults = strline & "," & UserDetails.UserName & "," & UserDetails.UserFullName & "," & UserDetails.AccountActive & "," & UserDetails.AccountExpired & "," & UserDetails.AccountLocked

                '-- Write result
                sw_exportusers.WriteLine(strUserResults)

                '-- Update processed records
                RecordsProcessed += 1
                txtProcessed.Text = "Records Processed: " & RecordsProcessed
                txtProcessed.Refresh()

            Loop Until strline Is Nothing

            '-- Close all streams
            sr_importusers.Close()
            sw_exportusers.Close()

            '-- Task completed
            txtProcessed.Text = txtProcessed.Text & " - Completed"
            btnValidateUsers.Enabled = False

        End If

    End Sub
End Class
