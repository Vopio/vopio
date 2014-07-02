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
        Me.btnUpdateRecordingLength = New System.Windows.Forms.Button()
        Me.imgSettings = New System.Windows.Forms.PictureBox()
        Me.imgHome = New System.Windows.Forms.PictureBox()
        Me.imgSavedWords = New System.Windows.Forms.PictureBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.imgBody = New System.Windows.Forms.PictureBox()
        Me.imgHeaderLogo = New System.Windows.Forms.PictureBox()
        CType(Me.trackRecordingLength, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgHome, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgSavedWords, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgBody, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgHeaderLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblDisplayStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblDisplayStatus.Font = New System.Drawing.Font("Arial Narrow", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayStatus.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.lblDisplayStatus.Location = New System.Drawing.Point(114, 154)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(222, 43)
        Me.lblDisplayStatus.TabIndex = 3
        Me.lblDisplayStatus.Text = "Recording...0 s"
        Me.lblDisplayStatus.UseWaitCursor = True
        '
        'lblSave
        '
        Me.lblSave.AutoSize = True
        Me.lblSave.BackColor = System.Drawing.Color.Transparent
        Me.lblSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblSave.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSave.Location = New System.Drawing.Point(169, 393)
        Me.lblSave.Name = "lblSave"
        Me.lblSave.Size = New System.Drawing.Size(108, 44)
        Me.lblSave.TabIndex = 4
        Me.lblSave.Text = "Save"
        Me.lblSave.UseWaitCursor = True
        '
        'txtRecordLength
        '
        Me.txtRecordLength.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecordLength.Location = New System.Drawing.Point(202, 306)
        Me.txtRecordLength.Name = "txtRecordLength"
        Me.txtRecordLength.Size = New System.Drawing.Size(56, 38)
        Me.txtRecordLength.TabIndex = 5
        Me.txtRecordLength.UseWaitCursor = True
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
        Me.listRecordings.Location = New System.Drawing.Point(99, 212)
        Me.listRecordings.Name = "listRecordings"
        Me.listRecordings.Size = New System.Drawing.Size(253, 164)
        Me.listRecordings.TabIndex = 6
        Me.listRecordings.UseWaitCursor = True
        Me.listRecordings.Visible = False
        '
        'lblSavedWords
        '
        Me.lblSavedWords.AutoSize = True
        Me.lblSavedWords.BackColor = System.Drawing.Color.Transparent
        Me.lblSavedWords.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblSavedWords.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSavedWords.ForeColor = System.Drawing.Color.Black
        Me.lblSavedWords.Location = New System.Drawing.Point(17, 551)
        Me.lblSavedWords.Name = "lblSavedWords"
        Me.lblSavedWords.Size = New System.Drawing.Size(124, 25)
        Me.lblSavedWords.TabIndex = 11
        Me.lblSavedWords.Text = "Saved Words"
        Me.lblSavedWords.UseWaitCursor = True
        '
        'lblHome
        '
        Me.lblHome.AutoSize = True
        Me.lblHome.BackColor = System.Drawing.Color.Transparent
        Me.lblHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblHome.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHome.ForeColor = System.Drawing.Color.Black
        Me.lblHome.Location = New System.Drawing.Point(204, 551)
        Me.lblHome.Name = "lblHome"
        Me.lblHome.Size = New System.Drawing.Size(60, 25)
        Me.lblHome.TabIndex = 12
        Me.lblHome.Text = "Home"
        Me.lblHome.UseWaitCursor = True
        '
        'lblSettings
        '
        Me.lblSettings.AutoSize = True
        Me.lblSettings.BackColor = System.Drawing.Color.Transparent
        Me.lblSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblSettings.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSettings.ForeColor = System.Drawing.Color.Black
        Me.lblSettings.Location = New System.Drawing.Point(360, 551)
        Me.lblSettings.Name = "lblSettings"
        Me.lblSettings.Size = New System.Drawing.Size(82, 25)
        Me.lblSettings.TabIndex = 13
        Me.lblSettings.Text = "Settings"
        Me.lblSettings.UseWaitCursor = True
        '
        'btnPlay
        '
        Me.btnPlay.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlay.Location = New System.Drawing.Point(98, 396)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(65, 31)
        Me.btnPlay.TabIndex = 14
        Me.btnPlay.Text = "Play"
        Me.btnPlay.UseVisualStyleBackColor = True
        Me.btnPlay.UseWaitCursor = True
        Me.btnPlay.Visible = False
        '
        'btnTranscribe
        '
        Me.btnTranscribe.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTranscribe.Location = New System.Drawing.Point(256, 396)
        Me.btnTranscribe.Name = "btnTranscribe"
        Me.btnTranscribe.Size = New System.Drawing.Size(95, 31)
        Me.btnTranscribe.TabIndex = 15
        Me.btnTranscribe.Text = "Transcribe"
        Me.btnTranscribe.UseVisualStyleBackColor = True
        Me.btnTranscribe.UseWaitCursor = True
        Me.btnTranscribe.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(177, 396)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(67, 31)
        Me.btnDelete.TabIndex = 16
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        Me.btnDelete.UseWaitCursor = True
        Me.btnDelete.Visible = False
        '
        'linkVopioWeb
        '
        Me.linkVopioWeb.AutoSize = True
        Me.linkVopioWeb.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.linkVopioWeb.Location = New System.Drawing.Point(248, 588)
        Me.linkVopioWeb.Name = "linkVopioWeb"
        Me.linkVopioWeb.Size = New System.Drawing.Size(80, 16)
        Me.linkVopioWeb.TabIndex = 17
        Me.linkVopioWeb.TabStop = True
        Me.linkVopioWeb.Text = "www.vopio.info"
        Me.linkVopioWeb.UseWaitCursor = True
        '
        'lblCopyright
        '
        Me.lblCopyright.AutoSize = True
        Me.lblCopyright.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopyright.Location = New System.Drawing.Point(133, 588)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(116, 16)
        Me.lblCopyright.TabIndex = 18
        Me.lblCopyright.Text = "(C) 2014  Vopio LLC  |"
        Me.lblCopyright.UseWaitCursor = True
        '
        'trackRecordingLength
        '
        Me.trackRecordingLength.Location = New System.Drawing.Point(145, 255)
        Me.trackRecordingLength.Maximum = 30
        Me.trackRecordingLength.Minimum = 1
        Me.trackRecordingLength.Name = "trackRecordingLength"
        Me.trackRecordingLength.Size = New System.Drawing.Size(169, 45)
        Me.trackRecordingLength.TabIndex = 19
        Me.trackRecordingLength.UseWaitCursor = True
        Me.trackRecordingLength.Value = 1
        Me.trackRecordingLength.Visible = False
        '
        'lblSetRecordingHeader
        '
        Me.lblSetRecordingHeader.AutoSize = True
        Me.lblSetRecordingHeader.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSetRecordingHeader.Location = New System.Drawing.Point(116, 225)
        Me.lblSetRecordingHeader.Name = "lblSetRecordingHeader"
        Me.lblSetRecordingHeader.Size = New System.Drawing.Size(229, 25)
        Me.lblSetRecordingHeader.TabIndex = 20
        Me.lblSetRecordingHeader.Text = "Set Recording Length (in s)"
        Me.lblSetRecordingHeader.UseWaitCursor = True
        Me.lblSetRecordingHeader.Visible = False
        '
        'btnUpdateRecordingLength
        '
        Me.btnUpdateRecordingLength.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateRecordingLength.Location = New System.Drawing.Point(191, 359)
        Me.btnUpdateRecordingLength.Name = "btnUpdateRecordingLength"
        Me.btnUpdateRecordingLength.Size = New System.Drawing.Size(73, 31)
        Me.btnUpdateRecordingLength.TabIndex = 21
        Me.btnUpdateRecordingLength.Text = "Update"
        Me.btnUpdateRecordingLength.UseVisualStyleBackColor = True
        Me.btnUpdateRecordingLength.UseWaitCursor = True
        Me.btnUpdateRecordingLength.Visible = False
        '
        'imgSettings
        '
        Me.imgSettings.BackgroundImage = Global.vopio.My.Resources.Resources.settings1
        Me.imgSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.imgSettings.Location = New System.Drawing.Point(353, 458)
        Me.imgSettings.Name = "imgSettings"
        Me.imgSettings.Size = New System.Drawing.Size(96, 90)
        Me.imgSettings.TabIndex = 10
        Me.imgSettings.TabStop = False
        Me.imgSettings.UseWaitCursor = True
        '
        'imgHome
        '
        Me.imgHome.BackgroundImage = Global.vopio.My.Resources.Resources.home
        Me.imgHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.imgHome.Location = New System.Drawing.Point(188, 467)
        Me.imgHome.Name = "imgHome"
        Me.imgHome.Size = New System.Drawing.Size(96, 77)
        Me.imgHome.TabIndex = 9
        Me.imgHome.TabStop = False
        Me.imgHome.UseWaitCursor = True
        '
        'imgSavedWords
        '
        Me.imgSavedWords.BackColor = System.Drawing.Color.Transparent
        Me.imgSavedWords.BackgroundImage = Global.vopio.My.Resources.Resources.saved_words
        Me.imgSavedWords.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.imgSavedWords.Location = New System.Drawing.Point(44, 471)
        Me.imgSavedWords.Name = "imgSavedWords"
        Me.imgSavedWords.Size = New System.Drawing.Size(69, 75)
        Me.imgSavedWords.TabIndex = 8
        Me.imgSavedWords.TabStop = False
        Me.imgSavedWords.UseWaitCursor = True
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = Global.vopio.My.Resources.Resources.record
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSave.Location = New System.Drawing.Point(99, 209)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(252, 170)
        Me.btnSave.TabIndex = 2
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.UseWaitCursor = True
        '
        'imgBody
        '
        Me.imgBody.BackColor = System.Drawing.Color.White
        Me.imgBody.BackgroundImage = Global.vopio.My.Resources.Resources.bodybg
        Me.imgBody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.imgBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgBody.Location = New System.Drawing.Point(0, 147)
        Me.imgBody.Name = "imgBody"
        Me.imgBody.Size = New System.Drawing.Size(464, 306)
        Me.imgBody.TabIndex = 1
        Me.imgBody.TabStop = False
        Me.imgBody.UseWaitCursor = True
        '
        'imgHeaderLogo
        '
        Me.imgHeaderLogo.BackgroundImage = Global.vopio.My.Resources.Resources.header_logo1
        Me.imgHeaderLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.imgHeaderLogo.Dock = System.Windows.Forms.DockStyle.Top
        Me.imgHeaderLogo.Location = New System.Drawing.Point(0, 0)
        Me.imgHeaderLogo.Name = "imgHeaderLogo"
        Me.imgHeaderLogo.Size = New System.Drawing.Size(464, 151)
        Me.imgHeaderLogo.TabIndex = 0
        Me.imgHeaderLogo.TabStop = False
        Me.imgHeaderLogo.UseWaitCursor = True
        '
        'home
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(464, 612)
        Me.Controls.Add(Me.btnUpdateRecordingLength)
        Me.Controls.Add(Me.lblSetRecordingHeader)
        Me.Controls.Add(Me.trackRecordingLength)
        Me.Controls.Add(Me.lblCopyright)
        Me.Controls.Add(Me.linkVopioWeb)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnTranscribe)
        Me.Controls.Add(Me.btnPlay)
        Me.Controls.Add(Me.lblSettings)
        Me.Controls.Add(Me.lblHome)
        Me.Controls.Add(Me.lblSavedWords)
        Me.Controls.Add(Me.imgSettings)
        Me.Controls.Add(Me.imgHome)
        Me.Controls.Add(Me.imgSavedWords)
        Me.Controls.Add(Me.listRecordings)
        Me.Controls.Add(Me.txtRecordLength)
        Me.Controls.Add(Me.lblSave)
        Me.Controls.Add(Me.lblDisplayStatus)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.imgBody)
        Me.Controls.Add(Me.imgHeaderLogo)
        Me.Font = New System.Drawing.Font("Microsoft MHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "home"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "vopio  |  always learning "
        Me.UseWaitCursor = True
        CType(Me.trackRecordingLength, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgSettings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgHome, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgSavedWords, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgBody, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgHeaderLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents imgHeaderLogo As System.Windows.Forms.PictureBox
    Friend WithEvents imgBody As System.Windows.Forms.PictureBox
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
    Friend WithEvents btnUpdateRecordingLength As System.Windows.Forms.Button

End Class
