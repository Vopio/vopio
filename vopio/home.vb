Public Class home
    Dim counter = 0
    Dim recordingRefresh = 0
    Dim countRecord = 0
    Dim storePATH
    Dim finalStorePath As String
    Private Declare Function mciSendString Lib "winmm.dll" _
    Alias "mciSendStringA" _
    (ByVal lpstrCommand As String, _
    ByVal lpstrReturnString As String, _
    ByVal uReturnLength As Long, _
    ByVal hwndCallback As Long) As Long

    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtRecordLength.Text = "15"
        recordingRefresh = txtRecordLength.Text
        Timer1.Interval = 1000
        Timer1.Start()
        Dim s As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        storePATH = s
        My.Computer.FileSystem.CreateDirectory(s + "\VopioAudioSnippets\")
        finalStorePath = s + "\VopioAudioSnippets\"
    End Sub

    Private Sub RecordSound()
        mciSendString("open new Type waveaudio Alias recsound", "", 0, 0)
        mciSendString("record recsound", "", 0, 0)
        'abel1.Text = "Recording..."
        lblDisplayStatus.Visible = True
    End Sub

    Private Sub ResetRecord()
        mciSendString("close recsound", "", 0, 0)
        My.Computer.Audio.Stop()
        recordingRefresh = txtRecordLength.Text
        Timer1.Enabled = False
        Timer1.Enabled = True
        Timer1.Interval = 1000
        Timer1.Start()
        countRecord = 0
    End Sub



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        counter += 1
        Dim mydate As String = String.Format(Now.ToString("MMddyyyy_hhmmss"))
        mciSendString("save recsound " + finalStorePath + mydate + ".wav", "", 0, 0)
        mciSendString("close recsound", "", 0, 0)
        MsgBox("File Created: " + finalStorePath + mydate + ".wav", MsgBoxStyle.OkOnly, "Success")
        My.Computer.Audio.Stop()
        ' make a reference to a directory
        listRecordings.Items.Clear()
        Dim di As New IO.DirectoryInfo(storePATH + "\VopioAudioSnippets")
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo

        'list the names of all files in the specified directory
        For Each dra In diar1
            listRecordings.Items.Add(dra)

        Next
        recordingRefresh = txtRecordLength.Text
        countRecord = 0

    End Sub




    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        countRecord += 1
        lblDisplayStatus.Text = "Recording..." + CStr(countRecord) + " s"
        'Label2.Text = TimeOfDay
        RecordSound()
        Static ElapsedSeconds As Integer = 1
        Dim ElapsedMod As Integer = 1
        ElapsedMod = ElapsedSeconds Mod recordingRefresh
        If ElapsedMod = 0 Then
            Timer1.Stop()

            'Label2.Text = "Timer Stopped"
            ResetRecord()


        End If
        ElapsedSeconds += 1
    End Sub

   
  
    Private Sub lblSavedWords_Click(sender As Object, e As EventArgs) Handles lblSavedWords.Click
        lblDisplayStatus.Visible = False
        txtRecordLength.Visible = False
        listRecordings.Visible = True
        btnSave.Visible = False
        lblSave.Visible = False
        btnPlay.Visible = True
    End Sub

    
    Private Sub imgSavedWords_Click(sender As Object, e As EventArgs) Handles imgSavedWords.Click
        lblDisplayStatus.Visible = False
        txtRecordLength.Visible = False
        listRecordings.Visible = True
        btnSave.Visible = False
        lblSave.Visible = False
        btnPlay.Visible = True
    End Sub

    Private Sub imgHome_Click(sender As Object, e As EventArgs) Handles imgHome.Click
        lblDisplayStatus.Visible = True
        txtRecordLength.Visible = False
        listRecordings.Visible = False
        btnSave.Visible = True
        lblSave.Visible = True
        btnPlay.Visible = True
    End Sub

    Private Sub lblHome_Click(sender As Object, e As EventArgs) Handles lblHome.Click
        lblDisplayStatus.Visible = True
        txtRecordLength.Visible = False
        listRecordings.Visible = False
        btnSave.Visible = True
        lblSave.Visible = True
        btnPlay.Visible = True
    End Sub

    Private Sub imgSettings_Click(sender As Object, e As EventArgs) Handles imgSettings.Click
        lblDisplayStatus.Visible = False
        txtRecordLength.Visible = True
        listRecordings.Visible = False
        btnSave.Visible = False
        lblSave.Visible = False
        btnPlay.Visible = True
    End Sub

    Private Sub lblSettings_Click(sender As Object, e As EventArgs) Handles lblSettings.Click
        lblDisplayStatus.Visible = False
        txtRecordLength.Visible = True
        listRecordings.Visible = False
        btnSave.Visible = False
        lblSave.Visible = False
        btnPlay.Visible = True
    End Sub


    Private Sub lblSave_Click(sender As Object, e As EventArgs) Handles lblSave.Click
        counter += 1
        Dim mydate As String = String.Format(Now.ToString("MMddyyyy_hhmmss"))
        mciSendString("save recsound " + finalStorePath + mydate + ".wav", "", 0, 0)
        mciSendString("close recsound", "", 0, 0)
        MsgBox("File Created: " + finalStorePath + mydate + ".wav", MsgBoxStyle.OkOnly, "Success")
        My.Computer.Audio.Stop()
        ' make a reference to a directory
        listRecordings.Items.Clear()
        Dim di As New IO.DirectoryInfo(storePATH + "\VopioAudioSnippets")
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo

        'list the names of all files in the specified directory
        For Each dra In diar1
            listRecordings.Items.Add(dra)

        Next
        recordingRefresh = txtRecordLength.Text
        countRecord = 0
    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        Dim currentFile As String = listRecordings.SelectedItem.ToString
        Dim audioPath As String
        audioPath = storePATH + "\VopioAudioSnippets\" + currentFile
        My.Computer.Audio.Play(audioPath, _
        AudioPlayMode.Background)
    End Sub
End Class
