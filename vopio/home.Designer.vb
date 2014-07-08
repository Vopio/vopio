<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class home
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(home))
        Me.lblDisplayStatus = New System.Windows.Forms.Label()
        Me.lblSave = New System.Windows.Forms.Label()
        Me.txtRecordLength = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.listRecordings = New System.Windows.Forms.ListBox()
        Me.lblSavedWords = New System.Windows.Forms.Label()
        Me.lblHome = New System.Windows.Forms.Label()
        Me.lblSettings = New System.Windows.Forms.Label()
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.btnTranscribe = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.linkVopioWeb = New System.Windows.Forms.LinkLabel()
        Me.lblCopyright = New System.Windows.Forms.Label()
        Me.trackRecordingLength = New System.Windows.Forms.TrackBar()
        Me.lblSetRecordingHeader = New System.Windows.Forms.Label()
        Me.btnUpdateSettings = New System.Windows.Forms.Button()
        Me.lblSetAudioStoragePath = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtStorePath = New System.Windows.Forms.TextBox()
        Me.progressRecording = New System.Windows.Forms.ProgressBar()
        Me.btnSaveNow = New System.Windows.Forms.Button()
        Me.lblHomeRec = New System.Windows.Forms.Label()
        Me.bodyPanel = New System.Windows.Forms.Panel()
        Me.lblListening = New System.Windows.Forms.Label()
        Me.imgSettings = New System.Windows.Forms.PictureBox()
        Me.imgHome = New System.Windows.Forms.PictureBox()
        Me.imgSavedWords = New System.Windows.Forms.PictureBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.imgHeaderLogo = New System.Windows.Forms.PictureBox()
        Me.imgBody = New System.Windows.Forms.PictureBox()
        CType(Me.trackRecordingLength, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bodyPanel.SuspendLayout()
        CType(Me.imgSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgHome, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgSavedWords, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgHeaderLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgBody, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblDisplayStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblDisplayStatus.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayStatus.ForeColor = System.Drawing.Color.White
        Me.lblDisplayStatus.Location = New System.Drawing.Point(121, 111)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(121, 23)
        Me.lblDisplayStatus.TabIndex = 3
        Me.lblDisplayStatus.Text = "learning last 0 s"
        Me.lblDisplayStatus.UseCompatibleTextRendering = True
        Me.lblDisplayStatus.Visible = False
        '
        'lblSave
        '
        Me.lblSave.AutoSize = True
        Me.lblSave.BackColor = System.Drawing.Color.Transparent
        Me.lblSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblSave.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSave.Location = New System.Drawing.Point(169, 305)
        Me.lblSave.Name = "lblSave"
        Me.lblSave.Size = New System.Drawing.Size(108, 44)
        Me.lblSave.TabIndex = 4
        Me.lblSave.Text = "Save"
        '
        'txtRecordLength
        '
        Me.txtRecordLength.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecordLength.Location = New System.Drawing.Point(417, 209)
        Me.txtRecordLength.Name = "txtRecordLength"
        Me.txtRecordLength.Size = New System.Drawing.Size(31, 26)
        Me.txtRecordLength.TabIndex = 5
        Me.txtRecordLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRecordLength.Visible = False
        '
        'Timer1
        '
        '
        'listRecordings
        '
        Me.listRecordings.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listRecordings.FormattingEnabled = True
        Me.listRecordings.ItemHeight = 20
        Me.listRecordings.Location = New System.Drawing.Point(53, 31)
        Me.listRecordings.Name = "listRecordings"
        Me.listRecordings.Size = New System.Drawing.Size(335, 264)
        Me.listRecordings.TabIndex = 6
        Me.listRecordings.Visible = False
        '
        'lblSavedWords
        '
        Me.lblSavedWords.AutoSize = True
        Me.lblSavedWords.BackColor = System.Drawing.Color.Transparent
        Me.lblSavedWords.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblSavedWords.Font = New System.Drawing.Font("Microsoft MHei", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSavedWords.ForeColor = System.Drawing.Color.White
        Me.lblSavedWords.Location = New System.Drawing.Point(12, 635)
        Me.lblSavedWords.Name = "lblSavedWords"
        Me.lblSavedWords.Size = New System.Drawing.Size(152, 34)
        Me.lblSavedWords.TabIndex = 11
        Me.lblSavedWords.Text = "SAVED WORDS"
        Me.lblSavedWords.UseCompatibleTextRendering = True
        '
        'lblHome
        '
        Me.lblHome.AutoSize = True
        Me.lblHome.BackColor = System.Drawing.Color.Transparent
        Me.lblHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblHome.Font = New System.Drawing.Font("Microsoft MHei", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHome.ForeColor = System.Drawing.Color.White
        Me.lblHome.Location = New System.Drawing.Point(202, 635)
        Me.lblHome.Name = "lblHome"
        Me.lblHome.Size = New System.Drawing.Size(68, 34)
        Me.lblHome.TabIndex = 12
        Me.lblHome.Text = "HOME"
        Me.lblHome.UseCompatibleTextRendering = True
        '
        'lblSettings
        '
        Me.lblSettings.AutoSize = True
        Me.lblSettings.BackColor = System.Drawing.Color.Transparent
        Me.lblSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblSettings.Font = New System.Drawing.Font("Microsoft MHei", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSettings.ForeColor = System.Drawing.Color.White
        Me.lblSettings.Location = New System.Drawing.Point(334, 635)
        Me.lblSettings.Name = "lblSettings"
        Me.lblSettings.Size = New System.Drawing.Size(99, 34)
        Me.lblSettings.TabIndex = 13
        Me.lblSettings.Text = "SETTINGS"
        Me.lblSettings.UseCompatibleTextRendering = True
        '
        'btnPlay
        '
        Me.btnPlay.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlay.Location = New System.Drawing.Point(91, 318)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(65, 31)
        Me.btnPlay.TabIndex = 14
        Me.btnPlay.Text = "Play"
        Me.btnPlay.UseCompatibleTextRendering = True
        Me.btnPlay.UseVisualStyleBackColor = True
        Me.btnPlay.Visible = False
        '
        'btnTranscribe
        '
        Me.btnTranscribe.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTranscribe.Location = New System.Drawing.Point(249, 318)
        Me.btnTranscribe.Name = "btnTranscribe"
        Me.btnTranscribe.Size = New System.Drawing.Size(95, 31)
        Me.btnTranscribe.TabIndex = 15
        Me.btnTranscribe.Text = "Transcribe"
        Me.btnTranscribe.UseCompatibleTextRendering = True
        Me.btnTranscribe.UseVisualStyleBackColor = True
        Me.btnTranscribe.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(170, 318)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(67, 31)
        Me.btnDelete.TabIndex = 16
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseCompatibleTextRendering = True
        Me.btnDelete.UseVisualStyleBackColor = True
        Me.btnDelete.Visible = False
        '
        'linkVopioWeb
        '
        Me.linkVopioWeb.ActiveLinkColor = System.Drawing.Color.White
        Me.linkVopioWeb.AutoSize = True
        Me.linkVopioWeb.DisabledLinkColor = System.Drawing.Color.White
        Me.linkVopioWeb.Font = New System.Drawing.Font("Microsoft MHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.linkVopioWeb.ForeColor = System.Drawing.Color.White
        Me.linkVopioWeb.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.linkVopioWeb.LinkColor = System.Drawing.Color.White
        Me.linkVopioWeb.Location = New System.Drawing.Point(349, 686)
        Me.linkVopioWeb.Name = "linkVopioWeb"
        Me.linkVopioWeb.Size = New System.Drawing.Size(114, 27)
        Me.linkVopioWeb.TabIndex = 17
        Me.linkVopioWeb.TabStop = True
        Me.linkVopioWeb.Text = "www.vopio.info"
        Me.linkVopioWeb.UseCompatibleTextRendering = True
        Me.linkVopioWeb.VisitedLinkColor = System.Drawing.Color.White
        '
        'lblCopyright
        '
        Me.lblCopyright.AutoSize = True
        Me.lblCopyright.Font = New System.Drawing.Font("Microsoft MHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopyright.ForeColor = System.Drawing.Color.White
        Me.lblCopyright.Location = New System.Drawing.Point(0, 686)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(148, 27)
        Me.lblCopyright.TabIndex = 18
        Me.lblCopyright.Text = "(C) 2014  Vopio LLC "
        Me.lblCopyright.UseCompatibleTextRendering = True
        '
        'trackRecordingLength
        '
        Me.trackRecordingLength.Location = New System.Drawing.Point(187, 209)
        Me.trackRecordingLength.Maximum = 30
        Me.trackRecordingLength.Minimum = 1
        Me.trackRecordingLength.Name = "trackRecordingLength"
        Me.trackRecordingLength.Size = New System.Drawing.Size(227, 45)
        Me.trackRecordingLength.TabIndex = 19
        Me.trackRecordingLength.TickFrequency = 5
        Me.trackRecordingLength.Value = 1
        Me.trackRecordingLength.Visible = False
        '
        'lblSetRecordingHeader
        '
        Me.lblSetRecordingHeader.AutoSize = True
        Me.lblSetRecordingHeader.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSetRecordingHeader.Location = New System.Drawing.Point(12, 209)
        Me.lblSetRecordingHeader.Name = "lblSetRecordingHeader"
        Me.lblSetRecordingHeader.Size = New System.Drawing.Size(146, 24)
        Me.lblSetRecordingHeader.TabIndex = 20
        Me.lblSetRecordingHeader.Text = "Recording Length (in s)"
        Me.lblSetRecordingHeader.UseCompatibleTextRendering = True
        Me.lblSetRecordingHeader.Visible = False
        '
        'btnUpdateSettings
        '
        Me.btnUpdateSettings.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateSettings.Location = New System.Drawing.Point(191, 359)
        Me.btnUpdateSettings.Name = "btnUpdateSettings"
        Me.btnUpdateSettings.Size = New System.Drawing.Size(73, 31)
        Me.btnUpdateSettings.TabIndex = 21
        Me.btnUpdateSettings.Text = "Update"
        Me.btnUpdateSettings.UseCompatibleTextRendering = True
        Me.btnUpdateSettings.UseVisualStyleBackColor = True
        Me.btnUpdateSettings.Visible = False
        '
        'lblSetAudioStoragePath
        '
        Me.lblSetAudioStoragePath.AutoSize = True
        Me.lblSetAudioStoragePath.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSetAudioStoragePath.Location = New System.Drawing.Point(12, 283)
        Me.lblSetAudioStoragePath.Name = "lblSetAudioStoragePath"
        Me.lblSetAudioStoragePath.Size = New System.Drawing.Size(123, 24)
        Me.lblSetAudioStoragePath.TabIndex = 22
        Me.lblSetAudioStoragePath.Text = "Audio Storage Path"
        Me.lblSetAudioStoragePath.UseCompatibleTextRendering = True
        Me.lblSetAudioStoragePath.Visible = False
        '
        'btnBrowse
        '
        Me.btnBrowse.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.Location = New System.Drawing.Point(379, 283)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(73, 31)
        Me.btnBrowse.TabIndex = 23
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseCompatibleTextRendering = True
        Me.btnBrowse.UseVisualStyleBackColor = True
        Me.btnBrowse.Visible = False
        '
        'txtStorePath
        '
        Me.txtStorePath.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStorePath.Location = New System.Drawing.Point(167, 283)
        Me.txtStorePath.Name = "txtStorePath"
        Me.txtStorePath.Size = New System.Drawing.Size(206, 26)
        Me.txtStorePath.TabIndex = 24
        Me.txtStorePath.Visible = False
        '
        'progressRecording
        '
        Me.progressRecording.Location = New System.Drawing.Point(0, 0)
        Me.progressRecording.Name = "progressRecording"
        Me.progressRecording.Size = New System.Drawing.Size(143, 23)
        Me.progressRecording.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.progressRecording.TabIndex = 25
        Me.progressRecording.Visible = False
        '
        'btnSaveNow
        '
        Me.btnSaveNow.BackColor = System.Drawing.Color.Transparent
        Me.btnSaveNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveNow.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveNow.ForeColor = System.Drawing.Color.White
        Me.btnSaveNow.Location = New System.Drawing.Point(248, 111)
        Me.btnSaveNow.Name = "btnSaveNow"
        Me.btnSaveNow.Size = New System.Drawing.Size(96, 23)
        Me.btnSaveNow.TabIndex = 26
        Me.btnSaveNow.Text = "Save Now"
        Me.btnSaveNow.UseCompatibleTextRendering = True
        Me.btnSaveNow.UseVisualStyleBackColor = False
        Me.btnSaveNow.Visible = False
        '
        'lblHomeRec
        '
        Me.lblHomeRec.AutoSize = True
        Me.lblHomeRec.BackColor = System.Drawing.Color.Transparent
        Me.lblHomeRec.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblHomeRec.Font = New System.Drawing.Font("Microsoft MHei", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHomeRec.ForeColor = System.Drawing.Color.White
        Me.lblHomeRec.Location = New System.Drawing.Point(200, 312)
        Me.lblHomeRec.Name = "lblHomeRec"
        Me.lblHomeRec.Size = New System.Drawing.Size(46, 46)
        Me.lblHomeRec.TabIndex = 29
        Me.lblHomeRec.Text = "0 s"
        Me.lblHomeRec.UseCompatibleTextRendering = True
        '
        'bodyPanel
        '
        Me.bodyPanel.BackColor = System.Drawing.Color.White
        Me.bodyPanel.Controls.Add(Me.lblSave)
        Me.bodyPanel.Controls.Add(Me.lblListening)
        Me.bodyPanel.Controls.Add(Me.imgBody)
        Me.bodyPanel.Controls.Add(Me.listRecordings)
        Me.bodyPanel.Controls.Add(Me.btnTranscribe)
        Me.bodyPanel.Controls.Add(Me.btnPlay)
        Me.bodyPanel.Controls.Add(Me.btnDelete)
        Me.bodyPanel.Location = New System.Drawing.Point(0, 148)
        Me.bodyPanel.Name = "bodyPanel"
        Me.bodyPanel.Size = New System.Drawing.Size(464, 378)
        Me.bodyPanel.TabIndex = 30
        '
        'lblListening
        '
        Me.lblListening.AutoSize = True
        Me.lblListening.BackColor = System.Drawing.Color.Transparent
        Me.lblListening.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblListening.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListening.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblListening.Location = New System.Drawing.Point(146, 12)
        Me.lblListening.Name = "lblListening"
        Me.lblListening.Size = New System.Drawing.Size(186, 40)
        Me.lblListening.TabIndex = 31
        Me.lblListening.Text = "learning last"
        Me.lblListening.UseCompatibleTextRendering = True
        '
        'imgSettings
        '
        Me.imgSettings.BackgroundImage = Global.vopio.My.Resources.Resources.settings2
        Me.imgSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.imgSettings.Location = New System.Drawing.Point(345, 552)
        Me.imgSettings.Name = "imgSettings"
        Me.imgSettings.Size = New System.Drawing.Size(90, 91)
        Me.imgSettings.TabIndex = 10
        Me.imgSettings.TabStop = False
        '
        'imgHome
        '
        Me.imgHome.BackgroundImage = Global.vopio.My.Resources.Resources.home1
        Me.imgHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.imgHome.Location = New System.Drawing.Point(201, 552)
        Me.imgHome.Name = "imgHome"
        Me.imgHome.Size = New System.Drawing.Size(90, 91)
        Me.imgHome.TabIndex = 9
        Me.imgHome.TabStop = False
        '
        'imgSavedWords
        '
        Me.imgSavedWords.BackColor = System.Drawing.Color.Transparent
        Me.imgSavedWords.BackgroundImage = Global.vopio.My.Resources.Resources.savedwords
        Me.imgSavedWords.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.imgSavedWords.Location = New System.Drawing.Point(53, 552)
        Me.imgSavedWords.Name = "imgSavedWords"
        Me.imgSavedWords.Size = New System.Drawing.Size(90, 91)
        Me.imgSavedWords.TabIndex = 8
        Me.imgSavedWords.TabStop = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnSave.Image = Global.vopio.My.Resources.Resources.record
        Me.btnSave.Location = New System.Drawing.Point(314, 324)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(134, 113)
        Me.btnSave.TabIndex = 2
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'imgHeaderLogo
        '
        Me.imgHeaderLogo.BackColor = System.Drawing.Color.White
        Me.imgHeaderLogo.BackgroundImage = Global.vopio.My.Resources.Resources.header_logo1
        Me.imgHeaderLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.imgHeaderLogo.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.imgHeaderLogo.Dock = System.Windows.Forms.DockStyle.Top
        Me.imgHeaderLogo.Image = Global.vopio.My.Resources.Resources.header_logo1
        Me.imgHeaderLogo.Location = New System.Drawing.Point(0, 0)
        Me.imgHeaderLogo.Name = "imgHeaderLogo"
        Me.imgHeaderLogo.Size = New System.Drawing.Size(464, 151)
        Me.imgHeaderLogo.TabIndex = 0
        Me.imgHeaderLogo.TabStop = False
        '
        'imgBody
        '
        Me.imgBody.BackColor = System.Drawing.Color.Transparent
        Me.imgBody.BackgroundImage = Global.vopio.My.Resources.Resources.loader
        Me.imgBody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.imgBody.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.imgBody.Image = Global.vopio.My.Resources.Resources.loader
        Me.imgBody.Location = New System.Drawing.Point(23, 35)
        Me.imgBody.Name = "imgBody"
        Me.imgBody.Size = New System.Drawing.Size(377, 318)
        Me.imgBody.TabIndex = 1
        Me.imgBody.TabStop = False
        '
        'home
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(464, 712)
        Me.Controls.Add(Me.lblHomeRec)
        Me.Controls.Add(Me.btnSaveNow)
        Me.Controls.Add(Me.progressRecording)
        Me.Controls.Add(Me.txtStorePath)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.lblSetAudioStoragePath)
        Me.Controls.Add(Me.btnUpdateSettings)
        Me.Controls.Add(Me.lblSetRecordingHeader)
        Me.Controls.Add(Me.trackRecordingLength)
        Me.Controls.Add(Me.lblCopyright)
        Me.Controls.Add(Me.linkVopioWeb)
        Me.Controls.Add(Me.lblSettings)
        Me.Controls.Add(Me.lblHome)
        Me.Controls.Add(Me.lblSavedWords)
        Me.Controls.Add(Me.imgSettings)
        Me.Controls.Add(Me.imgHome)
        Me.Controls.Add(Me.imgSavedWords)
        Me.Controls.Add(Me.txtRecordLength)
        Me.Controls.Add(Me.lblDisplayStatus)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.imgHeaderLogo)
        Me.Controls.Add(Me.bodyPanel)
        Me.Font = New System.Drawing.Font("Microsoft MHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.Name = "home"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "vopio  |  always learning "
        CType(Me.trackRecordingLength, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bodyPanel.ResumeLayout(False)
        Me.bodyPanel.PerformLayout()
        CType(Me.imgSettings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgHome, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgSavedWords, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgHeaderLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgBody, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents imgHeaderLogo As System.Windows.Forms.PictureBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblDisplayStatus As System.Windows.Forms.Label
    Friend WithEvents lblSave As System.Windows.Forms.Label
    Friend WithEvents txtRecordLength As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents listRecordings As System.Windows.Forms.ListBox
    Friend WithEvents imgSavedWords As System.Windows.Forms.PictureBox
    Friend WithEvents imgHome As System.Windows.Forms.PictureBox
    Friend WithEvents imgSettings As System.Windows.Forms.PictureBox
    Friend WithEvents lblSavedWords As System.Windows.Forms.Label
    Friend WithEvents lblHome As System.Windows.Forms.Label
    Friend WithEvents lblSettings As System.Windows.Forms.Label
    Friend WithEvents btnPlay As System.Windows.Forms.Button
    Friend WithEvents btnTranscribe As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents linkVopioWeb As System.Windows.Forms.LinkLabel
    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    Friend WithEvents trackRecordingLength As System.Windows.Forms.TrackBar
    Friend WithEvents lblSetRecordingHeader As System.Windows.Forms.Label
    Friend WithEvents btnUpdateSettings As System.Windows.Forms.Button
    Friend WithEvents lblSetAudioStoragePath As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents txtStorePath As System.Windows.Forms.TextBox
    Friend WithEvents progressRecording As System.Windows.Forms.ProgressBar
    Private WithEvents btnSaveNow As System.Windows.Forms.Button
    Friend WithEvents imgBody As System.Windows.Forms.PictureBox
    Friend WithEvents lblHomeRec As System.Windows.Forms.Label
    Friend WithEvents bodyPanel As System.Windows.Forms.Panel
    Friend WithEvents lblListening As System.Windows.Forms.Label

End Class
