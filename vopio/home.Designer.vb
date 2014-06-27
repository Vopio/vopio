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
        Me.imgSettings = New System.Windows.Forms.PictureBox()
        Me.imgHome = New System.Windows.Forms.PictureBox()
        Me.imgSavedWords = New System.Windows.Forms.PictureBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.imgBody = New System.Windows.Forms.PictureBox()
        Me.imgHeaderLogo = New System.Windows.Forms.PictureBox()
        Me.lblSavedWords = New System.Windows.Forms.Label()
        Me.lblHome = New System.Windows.Forms.Label()
        Me.lblSettings = New System.Windows.Forms.Label()
        Me.btnPlay = New System.Windows.Forms.Button()
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
        Me.lblDisplayStatus.Font = New System.Drawing.Font("Microsoft MHei", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayStatus.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.lblDisplayStatus.Location = New System.Drawing.Point(92, 154)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(251, 49)
        Me.lblDisplayStatus.TabIndex = 3
        Me.lblDisplayStatus.Text = "Recording...0 s"
        Me.lblDisplayStatus.UseWaitCursor = True
        '
        'lblSave
        '
        Me.lblSave.AutoSize = True
        Me.lblSave.BackColor = System.Drawing.Color.Transparent
        Me.lblSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblSave.Font = New System.Drawing.Font("Microsoft MHei", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSave.Location = New System.Drawing.Point(170, 359)
        Me.lblSave.Name = "lblSave"
        Me.lblSave.Size = New System.Drawing.Size(96, 49)
        Me.lblSave.TabIndex = 4
        Me.lblSave.Text = "Save"
        Me.lblSave.UseWaitCursor = True
        '
        'txtRecordLength
        '
        Me.txtRecordLength.Font = New System.Drawing.Font("Microsoft MHei", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecordLength.Location = New System.Drawing.Point(132, 224)
        Me.txtRecordLength.Name = "txtRecordLength"
        Me.txtRecordLength.Size = New System.Drawing.Size(154, 43)
        Me.txtRecordLength.TabIndex = 5
        Me.txtRecordLength.UseWaitCursor = True
        Me.txtRecordLength.Visible = False
        '
        'Timer1
        '
        '
        'listRecordings
        '
        Me.listRecordings.Font = New System.Drawing.Font("Microsoft MHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listRecordings.FormattingEnabled = True
        Me.listRecordings.ItemHeight = 21
        Me.listRecordings.Location = New System.Drawing.Point(101, 206)
        Me.listRecordings.Name = "listRecordings"
        Me.listRecordings.Size = New System.Drawing.Size(221, 151)
        Me.listRecordings.TabIndex = 6
        Me.listRecordings.UseWaitCursor = True
        Me.listRecordings.Visible = False
        '
        'imgSettings
        '
        Me.imgSettings.BackgroundImage = Global.vopio.My.Resources.Resources.settings
        Me.imgSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.imgSettings.Location = New System.Drawing.Point(348, 452)
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
        Me.imgHome.Location = New System.Drawing.Point(173, 461)
        Me.imgHome.Name = "imgHome"
        Me.imgHome.Size = New System.Drawing.Size(96, 77)
        Me.imgHome.TabIndex = 9
        Me.imgHome.TabStop = False
        Me.imgHome.UseWaitCursor = True
        '
        'imgSavedWords
        '
        Me.imgSavedWords.BackgroundImage = Global.vopio.My.Resources.Resources.saved_words
        Me.imgSavedWords.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.imgSavedWords.Location = New System.Drawing.Point(32, 464)
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
        Me.btnSave.Location = New System.Drawing.Point(91, 206)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(252, 150)
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
        Me.imgBody.Location = New System.Drawing.Point(0, 129)
        Me.imgBody.Name = "imgBody"
        Me.imgBody.Size = New System.Drawing.Size(443, 320)
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
        Me.imgHeaderLogo.Size = New System.Drawing.Size(444, 123)
        Me.imgHeaderLogo.TabIndex = 0
        Me.imgHeaderLogo.TabStop = False
        Me.imgHeaderLogo.UseWaitCursor = True
        '
        'lblSavedWords
        '
        Me.lblSavedWords.AutoSize = True
        Me.lblSavedWords.BackColor = System.Drawing.Color.Transparent
        Me.lblSavedWords.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblSavedWords.Font = New System.Drawing.Font("Microsoft MHei", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSavedWords.ForeColor = System.Drawing.Color.Black
        Me.lblSavedWords.Location = New System.Drawing.Point(0, 544)
        Me.lblSavedWords.Name = "lblSavedWords"
        Me.lblSavedWords.Size = New System.Drawing.Size(138, 28)
        Me.lblSavedWords.TabIndex = 11
        Me.lblSavedWords.Text = "Saved Words"
        Me.lblSavedWords.UseWaitCursor = True
        '
        'lblHome
        '
        Me.lblHome.AutoSize = True
        Me.lblHome.BackColor = System.Drawing.Color.Transparent
        Me.lblHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblHome.Font = New System.Drawing.Font("Microsoft MHei", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHome.ForeColor = System.Drawing.Color.Black
        Me.lblHome.Location = New System.Drawing.Point(187, 545)
        Me.lblHome.Name = "lblHome"
        Me.lblHome.Size = New System.Drawing.Size(70, 28)
        Me.lblHome.TabIndex = 12
        Me.lblHome.Text = "Home"
        Me.lblHome.UseWaitCursor = True
        '
        'lblSettings
        '
        Me.lblSettings.AutoSize = True
        Me.lblSettings.BackColor = System.Drawing.Color.Transparent
        Me.lblSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblSettings.Font = New System.Drawing.Font("Microsoft MHei", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSettings.ForeColor = System.Drawing.Color.Black
        Me.lblSettings.Location = New System.Drawing.Point(354, 545)
        Me.lblSettings.Name = "lblSettings"
        Me.lblSettings.Size = New System.Drawing.Size(89, 28)
        Me.lblSettings.TabIndex = 13
        Me.lblSettings.Text = "Settings"
        Me.lblSettings.UseWaitCursor = True
        '
        'btnPlay
        '
        Me.btnPlay.Font = New System.Drawing.Font("Microsoft MHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlay.Location = New System.Drawing.Point(173, 377)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(77, 31)
        Me.btnPlay.TabIndex = 14
        Me.btnPlay.Text = "Play"
        Me.btnPlay.UseVisualStyleBackColor = True
        Me.btnPlay.Visible = False
        '
        'home
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(444, 582)
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

End Class
