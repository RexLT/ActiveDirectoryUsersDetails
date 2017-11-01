<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainWindow
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
        Me.lblADUser = New System.Windows.Forms.Label()
        Me.txtADUser = New System.Windows.Forms.TextBox()
        Me.gbxUserDetails = New System.Windows.Forms.GroupBox()
        Me.tbcAnalyser = New System.Windows.Forms.TabControl()
        Me.tbpAnalysedResults = New System.Windows.Forms.TabPage()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtUserComment = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtHomeDirectory = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtUserProfile = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtLogonScript = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtLastLogonDays = New System.Windows.Forms.TextBox()
        Me.txtLastLogon = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPasswordExpiresDays = New System.Windows.Forms.TextBox()
        Me.txtPasswordLastSetDays = New System.Windows.Forms.TextBox()
        Me.txtAccountExpiresDays = New System.Windows.Forms.TextBox()
        Me.txtCountryCode = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pbxMayChangePassword = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pbxPasswordRequired = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pbxPasswordChangeable = New System.Windows.Forms.PictureBox()
        Me.txtPasswordChangeable = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pbxPasswordExpires = New System.Windows.Forms.PictureBox()
        Me.txtPasswordExpires = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pbxPasswordLastSet = New System.Windows.Forms.PictureBox()
        Me.txtPasswordLastSet = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pbxAccountExpires = New System.Windows.Forms.PictureBox()
        Me.txtAccountExpires = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pbxAccountActive = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbpCmdResults = New System.Windows.Forms.TabPage()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtDomainName = New System.Windows.Forms.TextBox()
        Me.lblDomain = New System.Windows.Forms.Label()
        Me.txtRegion = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtComputerName = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.gbxUserDetails.SuspendLayout()
        Me.tbcAnalyser.SuspendLayout()
        Me.tbpAnalysedResults.SuspendLayout()
        CType(Me.pbxMayChangePassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxPasswordRequired, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxPasswordChangeable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxPasswordExpires, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxPasswordLastSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxAccountExpires, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxAccountActive, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpCmdResults.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblADUser
        '
        Me.lblADUser.AutoSize = True
        Me.lblADUser.Location = New System.Drawing.Point(12, 21)
        Me.lblADUser.Name = "lblADUser"
        Me.lblADUser.Size = New System.Drawing.Size(166, 13)
        Me.lblADUser.TabIndex = 0
        Me.lblADUser.Text = "Enter Active Directory User Name"
        '
        'txtADUser
        '
        Me.txtADUser.Location = New System.Drawing.Point(195, 18)
        Me.txtADUser.Name = "txtADUser"
        Me.txtADUser.Size = New System.Drawing.Size(226, 20)
        Me.txtADUser.TabIndex = 1
        '
        'gbxUserDetails
        '
        Me.gbxUserDetails.Controls.Add(Me.tbcAnalyser)
        Me.gbxUserDetails.Location = New System.Drawing.Point(12, 58)
        Me.gbxUserDetails.Name = "gbxUserDetails"
        Me.gbxUserDetails.Size = New System.Drawing.Size(799, 375)
        Me.gbxUserDetails.TabIndex = 2
        Me.gbxUserDetails.TabStop = False
        Me.gbxUserDetails.Text = "Active Directory User Details"
        '
        'tbcAnalyser
        '
        Me.tbcAnalyser.Controls.Add(Me.tbpAnalysedResults)
        Me.tbcAnalyser.Controls.Add(Me.tbpCmdResults)
        Me.tbcAnalyser.Location = New System.Drawing.Point(6, 19)
        Me.tbcAnalyser.Name = "tbcAnalyser"
        Me.tbcAnalyser.SelectedIndex = 0
        Me.tbcAnalyser.Size = New System.Drawing.Size(786, 350)
        Me.tbcAnalyser.TabIndex = 5
        '
        'tbpAnalysedResults
        '
        Me.tbpAnalysedResults.Controls.Add(Me.txtComment)
        Me.tbpAnalysedResults.Controls.Add(Me.Label16)
        Me.tbpAnalysedResults.Controls.Add(Me.txtUserComment)
        Me.tbpAnalysedResults.Controls.Add(Me.Label15)
        Me.tbpAnalysedResults.Controls.Add(Me.txtHomeDirectory)
        Me.tbpAnalysedResults.Controls.Add(Me.Label14)
        Me.tbpAnalysedResults.Controls.Add(Me.txtUserProfile)
        Me.tbpAnalysedResults.Controls.Add(Me.Label13)
        Me.tbpAnalysedResults.Controls.Add(Me.txtLogonScript)
        Me.tbpAnalysedResults.Controls.Add(Me.Label12)
        Me.tbpAnalysedResults.Controls.Add(Me.txtLastLogonDays)
        Me.tbpAnalysedResults.Controls.Add(Me.txtLastLogon)
        Me.tbpAnalysedResults.Controls.Add(Me.Label11)
        Me.tbpAnalysedResults.Controls.Add(Me.txtPasswordExpiresDays)
        Me.tbpAnalysedResults.Controls.Add(Me.txtPasswordLastSetDays)
        Me.tbpAnalysedResults.Controls.Add(Me.txtAccountExpiresDays)
        Me.tbpAnalysedResults.Controls.Add(Me.txtCountryCode)
        Me.tbpAnalysedResults.Controls.Add(Me.Label10)
        Me.tbpAnalysedResults.Controls.Add(Me.pbxMayChangePassword)
        Me.tbpAnalysedResults.Controls.Add(Me.Label9)
        Me.tbpAnalysedResults.Controls.Add(Me.pbxPasswordRequired)
        Me.tbpAnalysedResults.Controls.Add(Me.Label8)
        Me.tbpAnalysedResults.Controls.Add(Me.pbxPasswordChangeable)
        Me.tbpAnalysedResults.Controls.Add(Me.txtPasswordChangeable)
        Me.tbpAnalysedResults.Controls.Add(Me.Label7)
        Me.tbpAnalysedResults.Controls.Add(Me.pbxPasswordExpires)
        Me.tbpAnalysedResults.Controls.Add(Me.txtPasswordExpires)
        Me.tbpAnalysedResults.Controls.Add(Me.Label6)
        Me.tbpAnalysedResults.Controls.Add(Me.pbxPasswordLastSet)
        Me.tbpAnalysedResults.Controls.Add(Me.txtPasswordLastSet)
        Me.tbpAnalysedResults.Controls.Add(Me.Label5)
        Me.tbpAnalysedResults.Controls.Add(Me.pbxAccountExpires)
        Me.tbpAnalysedResults.Controls.Add(Me.txtAccountExpires)
        Me.tbpAnalysedResults.Controls.Add(Me.Label4)
        Me.tbpAnalysedResults.Controls.Add(Me.pbxAccountActive)
        Me.tbpAnalysedResults.Controls.Add(Me.Label3)
        Me.tbpAnalysedResults.Controls.Add(Me.txtFullName)
        Me.tbpAnalysedResults.Controls.Add(Me.Label2)
        Me.tbpAnalysedResults.Controls.Add(Me.txtUserName)
        Me.tbpAnalysedResults.Controls.Add(Me.Label1)
        Me.tbpAnalysedResults.Location = New System.Drawing.Point(4, 22)
        Me.tbpAnalysedResults.Name = "tbpAnalysedResults"
        Me.tbpAnalysedResults.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpAnalysedResults.Size = New System.Drawing.Size(778, 324)
        Me.tbpAnalysedResults.TabIndex = 1
        Me.tbpAnalysedResults.Text = "Analysed Results"
        Me.tbpAnalysedResults.UseVisualStyleBackColor = True
        '
        'txtComment
        '
        Me.txtComment.Location = New System.Drawing.Point(443, 81)
        Me.txtComment.Name = "txtComment"
        Me.txtComment.ReadOnly = True
        Me.txtComment.Size = New System.Drawing.Size(314, 20)
        Me.txtComment.TabIndex = 40
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(384, 84)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 13)
        Me.Label16.TabIndex = 39
        Me.Label16.Text = "Comment"
        '
        'txtUserComment
        '
        Me.txtUserComment.Location = New System.Drawing.Point(141, 81)
        Me.txtUserComment.Name = "txtUserComment"
        Me.txtUserComment.ReadOnly = True
        Me.txtUserComment.Size = New System.Drawing.Size(222, 20)
        Me.txtUserComment.TabIndex = 38
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(20, 84)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 13)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "User's comment"
        '
        'txtHomeDirectory
        '
        Me.txtHomeDirectory.Location = New System.Drawing.Point(443, 286)
        Me.txtHomeDirectory.Name = "txtHomeDirectory"
        Me.txtHomeDirectory.ReadOnly = True
        Me.txtHomeDirectory.Size = New System.Drawing.Size(314, 20)
        Me.txtHomeDirectory.TabIndex = 36
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(355, 289)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 13)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "Home Directory"
        '
        'txtUserProfile
        '
        Me.txtUserProfile.Location = New System.Drawing.Point(443, 251)
        Me.txtUserProfile.Name = "txtUserProfile"
        Me.txtUserProfile.ReadOnly = True
        Me.txtUserProfile.Size = New System.Drawing.Size(314, 20)
        Me.txtUserProfile.TabIndex = 34
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(355, 254)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 13)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "User Profile"
        '
        'txtLogonScript
        '
        Me.txtLogonScript.Location = New System.Drawing.Point(93, 251)
        Me.txtLogonScript.Name = "txtLogonScript"
        Me.txtLogonScript.ReadOnly = True
        Me.txtLogonScript.Size = New System.Drawing.Size(231, 20)
        Me.txtLogonScript.TabIndex = 32
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(20, 254)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 13)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "Logon Script"
        '
        'txtLastLogonDays
        '
        Me.txtLastLogonDays.Location = New System.Drawing.Point(254, 119)
        Me.txtLastLogonDays.Name = "txtLastLogonDays"
        Me.txtLastLogonDays.ReadOnly = True
        Me.txtLastLogonDays.Size = New System.Drawing.Size(56, 20)
        Me.txtLastLogonDays.TabIndex = 30
        Me.txtLastLogonDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLastLogon
        '
        Me.txtLastLogon.Location = New System.Drawing.Point(93, 119)
        Me.txtLastLogon.Name = "txtLastLogon"
        Me.txtLastLogon.ReadOnly = True
        Me.txtLastLogon.Size = New System.Drawing.Size(155, 20)
        Me.txtLastLogon.TabIndex = 29
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(20, 122)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 13)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Last Logon"
        '
        'txtPasswordExpiresDays
        '
        Me.txtPasswordExpiresDays.Location = New System.Drawing.Point(665, 153)
        Me.txtPasswordExpiresDays.Name = "txtPasswordExpiresDays"
        Me.txtPasswordExpiresDays.ReadOnly = True
        Me.txtPasswordExpiresDays.Size = New System.Drawing.Size(56, 20)
        Me.txtPasswordExpiresDays.TabIndex = 27
        Me.txtPasswordExpiresDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPasswordLastSetDays
        '
        Me.txtPasswordLastSetDays.Location = New System.Drawing.Point(665, 185)
        Me.txtPasswordLastSetDays.Name = "txtPasswordLastSetDays"
        Me.txtPasswordLastSetDays.ReadOnly = True
        Me.txtPasswordLastSetDays.Size = New System.Drawing.Size(56, 20)
        Me.txtPasswordLastSetDays.TabIndex = 26
        Me.txtPasswordLastSetDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAccountExpiresDays
        '
        Me.txtAccountExpiresDays.Location = New System.Drawing.Point(665, 120)
        Me.txtAccountExpiresDays.Name = "txtAccountExpiresDays"
        Me.txtAccountExpiresDays.ReadOnly = True
        Me.txtAccountExpiresDays.Size = New System.Drawing.Size(56, 20)
        Me.txtAccountExpiresDays.TabIndex = 25
        Me.txtAccountExpiresDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCountryCode
        '
        Me.txtCountryCode.Location = New System.Drawing.Point(443, 19)
        Me.txtCountryCode.Name = "txtCountryCode"
        Me.txtCountryCode.ReadOnly = True
        Me.txtCountryCode.Size = New System.Drawing.Size(155, 20)
        Me.txtCountryCode.TabIndex = 24
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(366, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Country Code"
        '
        'pbxMayChangePassword
        '
        Me.pbxMayChangePassword.Location = New System.Drawing.Point(164, 214)
        Me.pbxMayChangePassword.Name = "pbxMayChangePassword"
        Me.pbxMayChangePassword.Size = New System.Drawing.Size(20, 27)
        Me.pbxMayChangePassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxMayChangePassword.TabIndex = 22
        Me.pbxMayChangePassword.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(20, 220)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(138, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "User may change password"
        '
        'pbxPasswordRequired
        '
        Me.pbxPasswordRequired.Location = New System.Drawing.Point(164, 181)
        Me.pbxPasswordRequired.Name = "pbxPasswordRequired"
        Me.pbxPasswordRequired.Size = New System.Drawing.Size(20, 27)
        Me.pbxPasswordRequired.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxPasswordRequired.TabIndex = 20
        Me.pbxPasswordRequired.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 188)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Password required"
        '
        'pbxPasswordChangeable
        '
        Me.pbxPasswordChangeable.Location = New System.Drawing.Point(476, 215)
        Me.pbxPasswordChangeable.Name = "pbxPasswordChangeable"
        Me.pbxPasswordChangeable.Size = New System.Drawing.Size(20, 27)
        Me.pbxPasswordChangeable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxPasswordChangeable.TabIndex = 17
        Me.pbxPasswordChangeable.TabStop = False
        '
        'txtPasswordChangeable
        '
        Me.txtPasswordChangeable.Location = New System.Drawing.Point(504, 218)
        Me.txtPasswordChangeable.Name = "txtPasswordChangeable"
        Me.txtPasswordChangeable.ReadOnly = True
        Me.txtPasswordChangeable.Size = New System.Drawing.Size(155, 20)
        Me.txtPasswordChangeable.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(355, 221)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Password changeable"
        '
        'pbxPasswordExpires
        '
        Me.pbxPasswordExpires.Location = New System.Drawing.Point(476, 150)
        Me.pbxPasswordExpires.Name = "pbxPasswordExpires"
        Me.pbxPasswordExpires.Size = New System.Drawing.Size(20, 27)
        Me.pbxPasswordExpires.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxPasswordExpires.TabIndex = 14
        Me.pbxPasswordExpires.TabStop = False
        '
        'txtPasswordExpires
        '
        Me.txtPasswordExpires.Location = New System.Drawing.Point(504, 153)
        Me.txtPasswordExpires.Name = "txtPasswordExpires"
        Me.txtPasswordExpires.ReadOnly = True
        Me.txtPasswordExpires.Size = New System.Drawing.Size(155, 20)
        Me.txtPasswordExpires.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(355, 156)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Password expires"
        '
        'pbxPasswordLastSet
        '
        Me.pbxPasswordLastSet.Location = New System.Drawing.Point(476, 182)
        Me.pbxPasswordLastSet.Name = "pbxPasswordLastSet"
        Me.pbxPasswordLastSet.Size = New System.Drawing.Size(20, 27)
        Me.pbxPasswordLastSet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxPasswordLastSet.TabIndex = 11
        Me.pbxPasswordLastSet.TabStop = False
        '
        'txtPasswordLastSet
        '
        Me.txtPasswordLastSet.Location = New System.Drawing.Point(504, 185)
        Me.txtPasswordLastSet.Name = "txtPasswordLastSet"
        Me.txtPasswordLastSet.ReadOnly = True
        Me.txtPasswordLastSet.Size = New System.Drawing.Size(155, 20)
        Me.txtPasswordLastSet.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(355, 188)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Password last set"
        '
        'pbxAccountExpires
        '
        Me.pbxAccountExpires.Location = New System.Drawing.Point(476, 117)
        Me.pbxAccountExpires.Name = "pbxAccountExpires"
        Me.pbxAccountExpires.Size = New System.Drawing.Size(20, 27)
        Me.pbxAccountExpires.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxAccountExpires.TabIndex = 8
        Me.pbxAccountExpires.TabStop = False
        '
        'txtAccountExpires
        '
        Me.txtAccountExpires.Location = New System.Drawing.Point(504, 120)
        Me.txtAccountExpires.Name = "txtAccountExpires"
        Me.txtAccountExpires.ReadOnly = True
        Me.txtAccountExpires.Size = New System.Drawing.Size(155, 20)
        Me.txtAccountExpires.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(355, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Account expires"
        '
        'pbxAccountActive
        '
        Me.pbxAccountActive.Location = New System.Drawing.Point(164, 148)
        Me.pbxAccountActive.Name = "pbxAccountActive"
        Me.pbxAccountActive.Size = New System.Drawing.Size(20, 27)
        Me.pbxAccountActive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxAccountActive.TabIndex = 5
        Me.pbxAccountActive.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Account active"
        '
        'txtFullName
        '
        Me.txtFullName.Location = New System.Drawing.Point(141, 50)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.ReadOnly = True
        Me.txtFullName.Size = New System.Drawing.Size(183, 20)
        Me.txtFullName.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Full Name"
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(141, 19)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.ReadOnly = True
        Me.txtUserName.Size = New System.Drawing.Size(183, 20)
        Me.txtUserName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User Name"
        '
        'tbpCmdResults
        '
        Me.tbpCmdResults.Controls.Add(Me.txtOutput)
        Me.tbpCmdResults.Location = New System.Drawing.Point(4, 22)
        Me.tbpCmdResults.Name = "tbpCmdResults"
        Me.tbpCmdResults.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpCmdResults.Size = New System.Drawing.Size(778, 324)
        Me.tbpCmdResults.TabIndex = 0
        Me.tbpCmdResults.Text = "Command Results"
        Me.tbpCmdResults.UseVisualStyleBackColor = True
        '
        'txtOutput
        '
        Me.txtOutput.Location = New System.Drawing.Point(6, 6)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOutput.Size = New System.Drawing.Size(766, 312)
        Me.txtOutput.TabIndex = 0
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(716, 16)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(95, 23)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(716, 439)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(95, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtDomainName
        '
        Me.txtDomainName.Location = New System.Drawing.Point(81, 441)
        Me.txtDomainName.Name = "txtDomainName"
        Me.txtDomainName.ReadOnly = True
        Me.txtDomainName.Size = New System.Drawing.Size(144, 20)
        Me.txtDomainName.TabIndex = 26
        '
        'lblDomain
        '
        Me.lblDomain.AutoSize = True
        Me.lblDomain.Location = New System.Drawing.Point(15, 444)
        Me.lblDomain.Name = "lblDomain"
        Me.lblDomain.Size = New System.Drawing.Size(60, 13)
        Me.lblDomain.TabIndex = 25
        Me.lblDomain.Text = "Workgroup"
        '
        'txtRegion
        '
        Me.txtRegion.Location = New System.Drawing.Point(278, 441)
        Me.txtRegion.Name = "txtRegion"
        Me.txtRegion.ReadOnly = True
        Me.txtRegion.Size = New System.Drawing.Size(155, 20)
        Me.txtRegion.TabIndex = 28
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(231, 444)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(41, 13)
        Me.Label18.TabIndex = 27
        Me.Label18.Text = "Region"
        '
        'txtComputerName
        '
        Me.txtComputerName.Location = New System.Drawing.Point(528, 441)
        Me.txtComputerName.Name = "txtComputerName"
        Me.txtComputerName.ReadOnly = True
        Me.txtComputerName.Size = New System.Drawing.Size(155, 20)
        Me.txtComputerName.TabIndex = 30
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(439, 444)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(83, 13)
        Me.Label19.TabIndex = 29
        Me.Label19.Text = "Computer Name"
        '
        'MainWindow
        '
        Me.AcceptButton = Me.btnSearch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(824, 474)
        Me.Controls.Add(Me.txtComputerName)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtRegion)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtDomainName)
        Me.Controls.Add(Me.lblDomain)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.gbxUserDetails)
        Me.Controls.Add(Me.txtADUser)
        Me.Controls.Add(Me.lblADUser)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainWindow"
        Me.Text = "Active Directory User Details"
        Me.gbxUserDetails.ResumeLayout(False)
        Me.tbcAnalyser.ResumeLayout(False)
        Me.tbpAnalysedResults.ResumeLayout(False)
        Me.tbpAnalysedResults.PerformLayout()
        CType(Me.pbxMayChangePassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxPasswordRequired, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxPasswordChangeable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxPasswordExpires, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxPasswordLastSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxAccountExpires, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxAccountActive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpCmdResults.ResumeLayout(False)
        Me.tbpCmdResults.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblADUser As Label
	Friend WithEvents txtADUser As TextBox
	Friend WithEvents gbxUserDetails As GroupBox
	Friend WithEvents btnSearch As Button
	Friend WithEvents btnClose As Button
	Friend WithEvents tbcAnalyser As TabControl
	Friend WithEvents tbpCmdResults As TabPage
	Friend WithEvents txtOutput As TextBox
	Friend WithEvents tbpAnalysedResults As TabPage
	Friend WithEvents txtUserName As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents txtFullName As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents pbxAccountActive As PictureBox
	Friend WithEvents pbxAccountExpires As PictureBox
	Friend WithEvents txtAccountExpires As TextBox
	Friend WithEvents Label4 As Label
	Friend WithEvents pbxPasswordRequired As PictureBox
	Friend WithEvents Label8 As Label
	Friend WithEvents pbxPasswordChangeable As PictureBox
	Friend WithEvents txtPasswordChangeable As TextBox
	Friend WithEvents Label7 As Label
	Friend WithEvents pbxPasswordExpires As PictureBox
	Friend WithEvents txtPasswordExpires As TextBox
	Friend WithEvents Label6 As Label
	Friend WithEvents pbxPasswordLastSet As PictureBox
	Friend WithEvents txtPasswordLastSet As TextBox
	Friend WithEvents Label5 As Label
    Friend WithEvents pbxMayChangePassword As PictureBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtLastLogonDays As TextBox
    Friend WithEvents txtLastLogon As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtPasswordExpiresDays As TextBox
    Friend WithEvents txtPasswordLastSetDays As TextBox
    Friend WithEvents txtAccountExpiresDays As TextBox
    Friend WithEvents txtCountryCode As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtHomeDirectory As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtUserProfile As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtLogonScript As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtUserComment As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtComment As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtDomainName As TextBox
    Friend WithEvents lblDomain As Label
    Friend WithEvents txtRegion As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtComputerName As TextBox
    Friend WithEvents Label19 As Label
End Class
