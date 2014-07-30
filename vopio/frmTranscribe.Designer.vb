<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTranscribe
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
        Me.lblCurrentFile = New System.Windows.Forms.Label()
        Me.lblDisplayTranscribedText = New System.Windows.Forms.Label()
        Me.btnSaveTranscribedText = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblCurrentFile
        '
        Me.lblCurrentFile.AutoSize = True
        Me.lblCurrentFile.Font = New System.Drawing.Font("Microsoft MHei", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentFile.Location = New System.Drawing.Point(25, 33)
        Me.lblCurrentFile.Name = "lblCurrentFile"
        Me.lblCurrentFile.Size = New System.Drawing.Size(75, 26)
        Me.lblCurrentFile.TabIndex = 4
        Me.lblCurrentFile.Text = "Playing "
        '
        'lblDisplayTranscribedText
        '
        Me.lblDisplayTranscribedText.AutoSize = True
        Me.lblDisplayTranscribedText.Font = New System.Drawing.Font("Microsoft MHei", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayTranscribedText.Location = New System.Drawing.Point(27, 81)
        Me.lblDisplayTranscribedText.Name = "lblDisplayTranscribedText"
        Me.lblDisplayTranscribedText.Size = New System.Drawing.Size(43, 17)
        Me.lblDisplayTranscribedText.TabIndex = 5
        Me.lblDisplayTranscribedText.Text = "Notes:"
        '
        'btnSaveTranscribedText
        '
        Me.btnSaveTranscribedText.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveTranscribedText.Location = New System.Drawing.Point(172, 216)
        Me.btnSaveTranscribedText.Name = "btnSaveTranscribedText"
        Me.btnSaveTranscribedText.Size = New System.Drawing.Size(195, 40)
        Me.btnSaveTranscribedText.TabIndex = 15
        Me.btnSaveTranscribedText.Text = "Saved Transcribed Text"
        Me.btnSaveTranscribedText.UseCompatibleTextRendering = True
        Me.btnSaveTranscribedText.UseVisualStyleBackColor = True
        '
        'frmTranscribe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(576, 280)
        Me.Controls.Add(Me.btnSaveTranscribedText)
        Me.Controls.Add(Me.lblDisplayTranscribedText)
        Me.Controls.Add(Me.lblCurrentFile)
        Me.Name = "frmTranscribe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "vopio | Transcribe"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCurrentFile As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTranscribedText As System.Windows.Forms.Label
    Friend WithEvents btnSaveTranscribedText As System.Windows.Forms.Button
End Class
