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

Public Class MainWindow

    Dim booDomain As Boolean

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
            lblADUser.Text = "Enter Worgroup User Name"
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

        If txtOutput.Text <> "" Then

            '-- Split text by line feed
            strUserData = Split(txtOutput.Text, vbCrLf)

            '-- Check each line
            For Each strDataLine In strUserData

                '-- Extract user name
                If strDataLine.StartsWith("User name") Then
                    txtUserName.Text = Mid(strDataLine, gloParamLen)
                End If

                '-- Extract full user name
                If strDataLine.StartsWith("Full Name") Then
                    txtFullName.Text = Mid(strDataLine, gloParamLen)
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
                    Else
                        If Mid(strDataLine, gloParamLen) = "Locked" Then
                            pbxAccountActive.Image = My.Resources.lock_symbol_icon_68326
                        Else
                            pbxAccountActive.Image = My.Resources.StatusAnnotations_Critical_32xLG_color
                        End If
                    End If
                End If

                '-- Extract Account expires
                If strDataLine.StartsWith("Account expires") Then
                    txtAccountExpires.Text = Mid(strDataLine, gloParamLen)
                    If txtAccountExpires.Text = "Never" Then
                        pbxAccountExpires.Image = My.Resources.StatusAnnotations_Complete_and_ok_32xLG_color
                        txtAccountExpiresDays.Text = ""
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
                        Else
                            pbxAccountExpires.Image = My.Resources.StatusAnnotations_Critical_32xLG_color
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
                        Else
                            pbxPasswordExpires.Image = My.Resources.StatusAnnotations_Critical_32xLG_color
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
End Class
