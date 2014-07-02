Imports System.Speech
Public Class home

    Dim counter = 0
    Dim recordingRefresh = 0
    Dim countRecord = 0
    Dim storePATH
    Dim finalStorePath As String
    Dim appDataPath As String
    Private Declare Function mciSendString Lib "winmm.dll" _
    Alias "mciSendStringA" _
    (ByVal lpstrCommand As String, _
    ByVal lpstrReturnString As String, _
    ByVal uReturnLength As Long, _
    ByVal hwndCallback As Long) As Long


    ' Speech
    Public synth As New Speech.Synthesis.SpeechSynthesizer
    Public WithEvents recognizer As New Speech.Recognition.SpeechRecognitionEngine
    Dim gram As New System.Speech.Recognition.DictationGrammar()

    Public Sub configureApp()

        appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        If My.Computer.FileSystem.DirectoryExists(appDataPath + "\vopio\config") Then
            'MsgBox("Config File Exist! with Default Data at " + appDataPath + "\vopio\config\")
        Else
            My.Computer.FileSystem.CreateDirectory(appDataPath + "\vopio\config")
            My.Computer.FileSystem.WriteAllText(appDataPath + "\vopio\config\recordingLength.txt", "20", True)
            getDesktopStorePath()
            My.Computer.FileSystem.WriteAllText(appDataPath + "\vopio\config\storePATH.txt", finalStorePath, True)
            'MsgBox("Config File Created with Default Data at " + appDataPath + "\vopio\config\")
        End If
        getRecordLength()
        recordingRefresh = txtRecordLength.Text
        Timer1.Interval = 1000
        Timer1.Start()
        
        recognizer.LoadGrammar(gram)

    End Sub

    Public Sub getRecordLength()
        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText(appDataPath + "\vopio\config\recordingLength.txt")
        txtRecordLength.Text = fileReader
    End Sub
    Public Sub getDesktopStorePath()
        Dim s As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        storePATH = s
        My.Computer.FileSystem.CreateDirectory(s + "\VopioAudioSnippets\")
        finalStorePath = s + "\VopioAudioSnippets\"
    End Sub


    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        configureApp()
    End Sub

    Private Sub RecordSound()
        mciSendString("open new Type waveaudio Alias recsound", "", 0, 0)
        mciSendString("record recsound", "", 0, 0)
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

        UpdateDirectory()

        recordingRefresh = txtRecordLength.Text
        countRecord = 0

    End Sub




    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Cursor.Current = Cursors.Hand
        countRecord += 1
        lblDisplayStatus.Text = "Recording..." + CStr(countRecord) + " s"
        Cursor.Current = Cursors.Hand
        RecordSound()
        Static ElapsedSeconds As Integer = 1
        Dim ElapsedMod As Integer = 1
        ElapsedMod = ElapsedSeconds Mod recordingRefresh
        If ElapsedMod = 0 Then
            Timer1.Stop()
            ResetRecord()
        End If
        ElapsedSeconds += 1
    End Sub

    'SavedWords UI
    Private Sub imgSavedWords_Click(sender As Object, e As EventArgs) Handles imgSavedWords.Click
        DisplaySavedWords()
    End Sub

    Private Sub lblSavedWords_Click(sender As Object, e As EventArgs) Handles lblSavedWords.Click
        DisplaySavedWords()
    End Sub

    Private Sub DisplaySavedWords()
        listRecordings.Visible = True
        btnPlay.Visible = True
        btnTranscribe.Visible = True
        btnDelete.Visible = True

        'Settings False
        txtRecordLength.Visible = False
        btnUpdateRecordingLength.Visible = False
        trackRecordingLength.Visible = False
        lblSetRecordingHeader.Visible = False

        'Home False
        btnSave.Visible = False
        lblSave.Visible = False

        'Assembla Ticket # 11 Implementation: Listings should always be updated
        UpdateDirectory()
    End Sub

    Private Sub DisplayHome()
        lblDisplayStatus.Visible = True
        btnSave.Visible = True
        lblSave.Visible = True

        'Saved Words False
        listRecordings.Visible = False
        btnPlay.Visible = False
        btnTranscribe.Visible = False
        btnDelete.Visible = False

        'Settings False
        txtRecordLength.Visible = False
        btnUpdateRecordingLength.Visible = False
        trackRecordingLength.Visible = False
        lblSetRecordingHeader.Visible = False
    End Sub

    Private Sub DisplaySettings()
        'False Values
        lblDisplayStatus.Visible = True
        txtRecordLength.Visible = True
        btnUpdateRecordingLength.Visible = True
        trackRecordingLength.Visible = True
        lblSetRecordingHeader.Visible = True

        'Saved Words False
        listRecordings.Visible = False
        btnPlay.Visible = False
        btnTranscribe.Visible = False
        btnDelete.Visible = False

        'Home False
        btnSave.Visible = False
        lblSave.Visible = False


    End Sub


    Private Sub imgHome_Click(sender As Object, e As EventArgs) Handles imgHome.Click
        DisplayHome()
    End Sub

    Private Sub lblHome_Click(sender As Object, e As EventArgs) Handles lblHome.Click
        DisplayHome()
    End Sub

    Private Sub imgSettings_Click(sender As Object, e As EventArgs) Handles imgSettings.Click
        DisplaySettings()
    End Sub

    Private Sub lblSettings_Click(sender As Object, e As EventArgs) Handles lblSettings.Click
        DisplaySettings()
    End Sub


    Private Sub lblSave_Click(sender As Object, e As EventArgs) Handles lblSave.Click
        counter += 1
        Dim mydate As String = String.Format(Now.ToString("MMddyyyy_hhmmss"))
        mciSendString("save recsound " + finalStorePath + mydate + ".wav", "", 0, 0)
        mciSendString("close recsound", "", 0, 0)
        MsgBox("File Created: " + finalStorePath + mydate + ".wav", MsgBoxStyle.OkOnly, "Success")
        My.Computer.Audio.Stop()

        UpdateDirectory()

        recordingRefresh = txtRecordLength.Text
        countRecord = 0
    End Sub

    Private Sub UpdateDirectory()

        getDesktopStorePath()
        ' make a reference to a directory
        listRecordings.Items.Clear()
        Dim di As New IO.DirectoryInfo(finalStorePath)
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo
        'list the names of all files in the specified directory
        For Each dra In diar1
            listRecordings.Items.Add(dra)
        Next
    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        Dim currentFile As String = listRecordings.SelectedItem.ToString
        Dim audioPath As String
        audioPath = storePATH + "\VopioAudioSnippets\" + currentFile
        My.Computer.Audio.Play(audioPath, _
        AudioPlayMode.Background)
    End Sub

    Private Sub btnTranscribe_Click(sender As Object, e As EventArgs) Handles btnTranscribe.Click
        Dim currentAudio As String
        Dim currentFile As String = listRecordings.SelectedItem.ToString
        currentAudio = storePATH + "\VopioAudioSnippets\" + currentFile
        recognizer.SetInputToWaveFile(currentAudio)
        recognizer.RecognizeAsync(Recognition.RecognizeMode.Multiple)


    End Sub

    Public Sub GotSpeech(ByVal sender As Object, ByVal phrase As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles recognizer.SpeechRecognized
        MsgBox(phrase.Result.Text)
        recognizer.Dispose() 'So that the file is release from the memory to be able to be deleted from the btnDelete
    End Sub



    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim currentAudio As String
        Dim currentFile As String = listRecordings.SelectedItem.ToString
        currentAudio = storePATH + "\VopioAudioSnippets\" + currentFile
        'Code for Deleting (Assembla Ticket # 13)
        My.Computer.FileSystem.DeleteFile(currentAudio,
        Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
        Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently,
        Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)

        'After Deleting needs to update the listBox, so here is the code

        UpdateDirectory()

    End Sub

    Public Sub setRecordLength(rLength As String)
        My.Computer.FileSystem.WriteAllText(appDataPath + "\vopio\config\recordingLength.txt", rLength, False)
    End Sub

    Private Sub trackRecordingLength_Scroll(sender As Object, e As EventArgs) Handles trackRecordingLength.Scroll
        txtRecordLength.Text = trackRecordingLength.Value
    End Sub

    Private Sub btnUpdateRecordingLength_Click(sender As Object, e As EventArgs) Handles btnUpdateRecordingLength.Click

        Dim lengthTo
        lengthTo = trackRecordingLength.Value

        txtRecordLength.Text = lengthTo

        MsgBox("Recording Length has been updated to " + CStr(lengthTo) + " s")

        setRecordLength(lengthTo)

        'Restarting Recording
        Timer1.Stop()
        ResetRecord()

    End Sub

    Private Sub linkVopioWeb_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkVopioWeb.LinkClicked
        Dim url As String = "http://www.vopio.info"
        Process.Start(url)
    End Sub
End Class


