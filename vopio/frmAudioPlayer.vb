' Assembla # 46 Special Audio Player
Imports WMPLib
Public Class frmAudioPlayer
    Friend audioFile
    Friend audioName

    Dim audioNotes

  
    Private Sub frmAudioPlayer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'My.Computer.Audio.Play(storePath, AudioPlayMode.Background)
        AxWindowsMediaPlayer1.URL = audioFile
        lblCurrentAudio.Text = "Playing " + audioName
        audioNotes = audioFile + ".txt"
        If (My.Computer.FileSystem.FileExists(audioNotes)) Then
            Dim fileReader As String
            fileReader = My.Computer.FileSystem.ReadAllText(audioNotes, System.Text.Encoding.UTF32)
            lblNotes.Text = "Notes: " + fileReader
        Else
            lblNotes.Text = "Notes: "
        End If

    End Sub

    Friend Function getAudioDuration(sPath As String)
        Dim mediaLength As String
        Dim w As New WMPLib.WindowsMediaPlayer
        Dim m As WMPLib.IWMPMedia = w.newMedia(sPath)
        If m IsNot Nothing Then
            mediaLength = m.duration
            Return mediaLength
            w.close()
        End If
    End Function

End Class