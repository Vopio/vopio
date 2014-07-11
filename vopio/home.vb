Imports System.Speech
Imports System.Net
Imports System.IO




Public Class home


    Dim WithEvents WC As New WebClient

    Dim counter = 0
    Dim recordingRefresh = 0
    Dim countRecord = 0
    Dim storePATH
    Dim desktopStorePath As String
    Dim finalStorePath As String
    Dim appDataPath As String

    Dim settingsRecordingLength
    Dim settingsStorePath

    Private Declare Function mciSendString Lib "winmm.dll" _
    Alias "mciSendStringA" _
    (ByVal lpstrCommand As String, _
    ByVal lpstrReturnString As String, _
    ByVal uReturnLength As Long, _
    ByVal hwndCallback As Long) As Long

    Declare Function GetShortPathName Lib "kernel32" Alias _
"GetShortPathNameA" (ByVal lpszLongPath As String, _
ByVal lpszShortPath As String, ByVal cchBuffer As Long) As Long

    Dim newStorePath As String

    ' Speech
    Public synth As New Speech.Synthesis.SpeechSynthesizer
    Public WithEvents recognizer As New Speech.Recognition.SpeechRecognitionEngine
    Dim gram As New System.Speech.Recognition.DictationGrammar()

    Private Sub getFontFile()
        appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        My.Computer.FileSystem.CreateDirectory(appDataPath + "\vopio\config\fonts")
        Dim startupPath = appDataPath + "\vopio\config\fonts\"
        Dim myWebClient As New System.Net.WebClient()
        'Need to create a logic here to check for internet connection
        myWebClient.DownloadFile("http://vopio.info/MSMHei.ttf", startupPath + "MSMHei.ttf")
        myWebClient.DownloadFile("http://vopio.info/installFont.vbs", startupPath + "installFont.vbs")
        Process.Start(appDataPath + "\vopio\config\fonts\installFont.vbs")


    End Sub
    Public Sub configureApp()
        appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        'getFontFile()
        If My.Computer.FileSystem.DirectoryExists(appDataPath + "\vopio\config") Then
            'MsgBox("Config File Exist! with Default Data at " + appDataPath + "\vopio\config\")
            getFinalStorePath()
            If My.Computer.FileSystem.DirectoryExists(appDataPath + "\vopio\config\fonts") Then
                'MsgBox("Directory Exists!")
            Else
                getFontFile() ' so that users dont have to update their config files
            End If
        Else
            'Setting Up Directories for the first time
            My.Computer.FileSystem.CreateDirectory(appDataPath + "\vopio\config")
            My.Computer.FileSystem.WriteAllText(appDataPath + "\vopio\config\recordingLength.txt", "20", True)
            getDesktopStorePath()
            My.Computer.FileSystem.WriteAllText(appDataPath + "\vopio\config\storePATH.txt", desktopStorePath, True)
            MsgBox("Recording Length is set to 20 s" & vbCrLf & "Audio Snippets are being saved at " + desktopStorePath & vbCrLf & "You can change it from the Settings Menu at any time!")
            getFontFile()
        End If

        Me.BackColor = Color.FromArgb(0, 174, 239)
        lblHomeRec.ForeColor = Color.FromArgb(0, 174, 239)
        lblHomeRec.BackColor = Color.FromArgb(255, 255, 255)
        lblSave.ForeColor = Color.FromArgb(0, 174, 239)
        lblSave.BackColor = Color.FromArgb(255, 255, 255)
        lblListening.ForeColor = Color.FromArgb(0, 174, 239)
        lblListening.BackColor = Color.FromArgb(255, 255, 255)
        bodyPanel.BackColor = Color.FromArgb(255, 255, 255)
        lblSetAudioStoragePath.BackColor = Color.FromArgb(255, 255, 255)
        lblSetRecordingHeader.BackColor = Color.FromArgb(255, 255, 255)
        trackRecordingLength.BackColor = Color.FromArgb(255, 255, 255)

        btnSave.Visible = False
        getRecordLength()
        recordingRefresh = txtRecordLength.Text
        Timer1.Interval = 1000
        Timer1.Start()
        recognizer.LoadGrammar(gram)
        progressRecording.Maximum = txtRecordLength.Text
        progressRecording.Minimum = 0
        trackRecordingLength.Value = txtRecordLength.Text ' Fixing osTicket # 626423






        'Embedding Font Assembla Ticket # 33
        Dim big As New System.Drawing.Font("Microsoft MHei", 36)
        Dim medium As New System.Drawing.Font("Microsoft MHei", 22)
        Dim small As New System.Drawing.Font("Microsoft MHei", 16)
        Dim smaller As New System.Drawing.Font("Microsoft MHei", 12)
        Dim smallest As New System.Drawing.Font("Microsoft MHei", 10)
        Dim tiny As New System.Drawing.Font("Microsoft MHei", 9)
        lblSave.Font = big
        lblListening.Font = medium
        lblHome.Font = small
        lblSavedWords.Font = small
        lblSettings.Font = small

        lblCopyright.Font = smallest
        linkVopioWeb.Font = smallest

        lblDisplayStatus.Font = smaller

        lblSetAudioStoragePath.Font = smaller
        lblSetRecordingHeader.Font = smaller

        btnBrowse.Font = smaller
        btnPlay.Font = smaller
        btnDelete.Font = smaller
        btnAddNotes.Font = smaller
        btnOpenNotes.Font = smaller
        btnSaveNow.Font = smaller ' Assitional font size improvemenbt from ticket # 640586
        btnTranscribe.Font = smaller
        btnShowInFolder.Font = smaller
        btnUpdateSettings.Font = smaller

        txtRecordLength.Font = smaller
        txtStorePath.Font = smaller

        listRecordings.Font = smaller

        lblHomeRec.Font = medium
        lblListening.Font = medium

        'Fixing osTicket # 347172 creating a check to see if settings updated then remind user to update settings
        settingsRecordingLength = txtRecordLength.Text
        settingsStorePath = txtStorePath.Text





        'lblListening.Font = CustomFont.GetInstance(22, FontStyle.Regular)
        'lblHome.Font = CustomFont.GetInstance(16, FontStyle.Regular)
        'lblSavedWords.Font = CustomFont.GetInstance(16, FontStyle.Regular)
        'lblSettings.Font = CustomFont.GetInstance(16, FontStyle.Regular)

        'lblCopyright.Font = CustomFont.GetInstance(10, FontStyle.Regular)
        'linkVopioWeb.Font = CustomFont.GetInstance(10, FontStyle.Regular)

        'lblDisplayStatus.Font = CustomFont.GetInstance(12, FontStyle.Regular)

        'lblSetAudioStoragePath.Font = CustomFont.GetInstance(12, FontStyle.Regular)
        'lblSetRecordingHeader.Font = CustomFont.GetInstance(12, FontStyle.Regular)

        'btnBrowse.Font = CustomFont.GetInstance(12, FontStyle.Regular)
        'btnPlay.Font = CustomFont.GetInstance(12, FontStyle.Regular)
        'btnDelete.Font = CustomFont.GetInstance(12, FontStyle.Regular)
        'btnSaveNow.Font = CustomFont.GetInstance(9, FontStyle.Regular)
        'btnTranscribe.Font = CustomFont.GetInstance(12, FontStyle.Regular)
        'btnUpdateSettings.Font = CustomFont.GetInstance(12, FontStyle.Regular)

        'txtRecordLength.Font = CustomFont.GetInstance(12, FontStyle.Regular)
        'txtStorePath.Font = CustomFont.GetInstance(12, FontStyle.Regular)

        'listRecordings.Font = CustomFont.GetInstance(12, FontStyle.Regular)

        'lblHomeRec.Font = CustomFont.GetInstance(22, FontStyle.Regular)
        'lblListening.Font = CustomFont.GetInstance(22, FontStyle.Regular)



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
        desktopStorePath = s + "\VopioAudioSnippets\"
    End Sub

    Public Sub getFinalStorePath()
        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText(appDataPath + "\vopio\config\storePATH.txt")
        finalStorePath = fileReader
    End Sub

    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        configureApp()
    End Sub

    Private Sub RecordSound()
        mciSendString("open new Type waveaudio Alias recsound", "", 0, 0)
        mciSendString("record recsound", "", 0, 0)
        'lblDisplayStatus.Visible = True
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
        progressRecording.Maximum = txtRecordLength.Text
        progressRecording.Minimum = 1
        progressRecording.Value = 1
    End Sub



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        counter += 1
        Dim mydate As String = String.Format(Now.ToString("MMddyyyy_hhmmss"))
        mciSendString("save recsound " & """" & finalStorePath + mydate + ".wav" & """", "", 0, 0)
        mciSendString("close recsound", "", 0, 0)
        MsgBox("File Created: " + finalStorePath + mydate + ".wav", MsgBoxStyle.OkOnly, "Success")
        My.Computer.Audio.Stop()

        UpdateDirectory()

        recordingRefresh = txtRecordLength.Text
        countRecord = 0

    End Sub




    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Assembla Ticket # 1 Implementation
        If progressRecording.Value < progressRecording.Maximum Then
            progressRecording.Value += 1
        Else
            progressRecording.Value = progressRecording.Minimum
        End If


        countRecord += 1
        lblDisplayStatus.Text = "learning last " + CStr(countRecord) + " s" 'Fixing osTicket # 106951
        lblHomeRec.Text = CStr(countRecord) + " s"
        'lblDisplayStatus.Text = "Recording..." + CStr(countRecord) + " s"
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

    

    Private Sub DisplaySavedWords()
        listRecordings.Visible = True
        btnPlay.Visible = True
        btnTranscribe.Visible = True
        btnShowInFolder.Visible = True
        btnDelete.Visible = True
        btnAddNotes.Visible = True
        btnOpenNotes.Visible = True
        lblDisplayStatus.Visible = True
        btnSaveNow.Visible = True

        'Settings False
        txtRecordLength.Visible = False
        btnUpdateSettings.Visible = False
        trackRecordingLength.Visible = False
        lblSetRecordingHeader.Visible = False
        lblSetAudioStoragePath.Visible = False
        txtStorePath.Visible = False
        btnBrowse.Visible = False

        'Home False
        btnSave.Visible = False
        lblSave.Visible = False
        lblListening.Visible = False
        imgBody.Visible = False
        lblHomeRec.Visible = False
        lblHomeRec.Visible = False

        'Fixing osTicket # 347172 creating a check to see if settings updated then remind user to update settings
        lblSettings.Visible = True
        imgSettings.Enabled = True
        lblSettingsDummy.Visible = False


        'Assembla Ticket # 11 Implementation: Listings should always be updated
        UpdateDirectory()
    End Sub

    Private Sub DisplayHome()
        lblDisplayStatus.Visible = True
        lblSave.Visible = True
        lblListening.Visible = True
        imgBody.Visible = True
        lblDisplayStatus.Visible = False
        btnSaveNow.Visible = False
        lblHomeRec.Visible = True

        'Saved Words False
        listRecordings.Visible = False
        btnPlay.Visible = False
        btnTranscribe.Visible = False
        btnShowInFolder.Visible = False
        btnDelete.Visible = False
        btnAddNotes.Visible = False
        btnOpenNotes.Visible = False

        'Settings False
        txtRecordLength.Visible = False
        btnUpdateSettings.Visible = False
        trackRecordingLength.Visible = False
        lblSetRecordingHeader.Visible = False
        lblSetAudioStoragePath.Visible = False
        txtStorePath.Visible = False
        btnBrowse.Visible = False

        'Fixing osTicket # 347172 creating a check to see if settings updated then remind user to update settings
        lblSettings.Visible = True
        imgSettings.Enabled = True
        lblSettingsDummy.Visible = False

    End Sub

    Private Sub DisplaySettings()
        'True Values
        lblDisplayStatus.Visible = True
        txtRecordLength.Visible = True
        btnUpdateSettings.Visible = True
        trackRecordingLength.Visible = True
        lblSetRecordingHeader.Visible = True
        lblSetAudioStoragePath.Visible = True
        txtStorePath.Visible = True
        btnBrowse.Visible = True
        txtStorePath.Text = finalStorePath
        trackRecordingLength.Value = txtRecordLength.Text ' Fixing osTicket # 626423

        'Fixing osTicket # 347172 creating a check to see if settings updated then remind user to update settings
        lblSettings.Visible = False
        imgSettings.Enabled = False
        lblSettingsDummy.Visible = True



        lblDisplayStatus.Visible = True
        btnSaveNow.Visible = True

        'Saved Words False
        listRecordings.Visible = False
        btnPlay.Visible = False
        btnTranscribe.Visible = False
        btnShowInFolder.Visible = False
        btnDelete.Visible = False
        btnAddNotes.Visible = False
        btnOpenNotes.Visible = False

        'Home False
        btnSave.Visible = False
        lblSave.Visible = False
        lblListening.Visible = False
        imgBody.Visible = False
        lblHomeRec.Visible = False
        lblHomeRec.Visible = False


    End Sub


    'SavedWords UI
    Private Sub imgSavedWords_Click(sender As Object, e As EventArgs) Handles imgSavedWords.Click
        'Fixing osTicket # 347172 creating a check to see if settings updated then remind user to update settings
        If (settingsRecordingLength = txtRecordLength.Text) Then
            If (settingsStorePath = txtStorePath.Text) Then
                DisplaySavedWords()
            Else
                If MsgBox("You tried to update your Recording Length. Would you like to update it?" & vbCrLf & "Click on Yes button to update!" & vbCrLf & "Press No/Cancel buttons if you do not want to!", MsgBoxStyle.YesNoCancel, "vopio") = MsgBoxResult.Yes Then
                    Dim lengthTo
                    lengthTo = trackRecordingLength.Value

                    txtRecordLength.Text = lengthTo
                    trackRecordingLength.Value = txtRecordLength.Text ' Fixing osTicket # 626423

                    If (newStorePath = "") Then
                    Else
                        setStorePath(newStorePath)
                    End If

                    setRecordLength(lengthTo)

                    'Restarting Recording
                    Timer1.Stop()
                    ResetRecord()

                    ' MsgBox("Recording Length has been updated to " + CStr(lengthTo) + " s")
                    ' MsgBox("Audio Snippets Storage has been set to the following location: " & vbCrLf & newStorePath)
                    MsgBox("Your Settings have been updated!")

                    'Fixing osTicket # 347172 creating a check to see if settings updated then remind user to update settings
                    settingsRecordingLength = txtRecordLength.Text
                    settingsStorePath = txtStorePath.Text
                Else
                    MsgBox("Update Cancelled!")
                    DisplaySavedWords()
                End If
            End If
        Else
            If MsgBox("You tried to update your Recording Length. Would you like to update it?" & vbCrLf & "Click on Yes button to update!" & vbCrLf & "Press No/Cancel buttons if you do not want to!", MsgBoxStyle.YesNoCancel, "vopio") = MsgBoxResult.Yes Then
                Dim lengthTo
                lengthTo = trackRecordingLength.Value

                txtRecordLength.Text = lengthTo
                trackRecordingLength.Value = txtRecordLength.Text ' Fixing osTicket # 626423

                If (newStorePath = "") Then
                Else
                    setStorePath(newStorePath)
                End If

                setRecordLength(lengthTo)

                'Restarting Recording
                Timer1.Stop()
                ResetRecord()

                ' MsgBox("Recording Length has been updated to " + CStr(lengthTo) + " s")
                ' MsgBox("Audio Snippets Storage has been set to the following location: " & vbCrLf & newStorePath)
                MsgBox("Your Settings have been updated!")

                'Fixing osTicket # 347172 creating a check to see if settings updated then remind user to update settings
                settingsRecordingLength = txtRecordLength.Text
                settingsStorePath = txtStorePath.Text
            Else
                MsgBox("Update Cancelled!")
                DisplaySavedWords()
            End If
        End If
    End Sub

    Private Sub lblSavedWords_Click(sender As Object, e As EventArgs) Handles lblSavedWords.Click
        'Fixing osTicket # 347172 creating a check to see if settings updated then remind user to update settings
        If (settingsRecordingLength = txtRecordLength.Text) Then
            If (settingsStorePath = txtStorePath.Text) Then
                DisplaySavedWords()
            Else
                If MsgBox("You tried to update your Recording Length. Would you like to update it?" & vbCrLf & "Click on Yes button to update!" & vbCrLf & "Press No/Cancel buttons if you do not want to!", MsgBoxStyle.YesNoCancel, "vopio") = MsgBoxResult.Yes Then
                    Dim lengthTo
                    lengthTo = trackRecordingLength.Value

                    txtRecordLength.Text = lengthTo
                    trackRecordingLength.Value = txtRecordLength.Text ' Fixing osTicket # 626423

                    If (newStorePath = "") Then
                    Else
                        setStorePath(newStorePath)
                    End If

                    setRecordLength(lengthTo)

                    'Restarting Recording
                    Timer1.Stop()
                    ResetRecord()

                    ' MsgBox("Recording Length has been updated to " + CStr(lengthTo) + " s")
                    ' MsgBox("Audio Snippets Storage has been set to the following location: " & vbCrLf & newStorePath)
                    MsgBox("Your Settings have been updated!")

                    'Fixing osTicket # 347172 creating a check to see if settings updated then remind user to update settings
                    settingsRecordingLength = txtRecordLength.Text
                    settingsStorePath = txtStorePath.Text
                Else
                    MsgBox("Update Cancelled!")
                    DisplaySavedWords()
                End If
            End If
        Else
            If MsgBox("You tried to update your Recording Length. Would you like to update it?" & vbCrLf & "Click on Yes button to update!" & vbCrLf & "Press No/Cancel buttons if you do not want to!", MsgBoxStyle.YesNoCancel, "vopio") = MsgBoxResult.Yes Then
                Dim lengthTo
                lengthTo = trackRecordingLength.Value

                txtRecordLength.Text = lengthTo
                trackRecordingLength.Value = txtRecordLength.Text ' Fixing osTicket # 626423

                If (newStorePath = "") Then
                Else
                    setStorePath(newStorePath)
                End If

                setRecordLength(lengthTo)

                'Restarting Recording
                Timer1.Stop()
                ResetRecord()

                ' MsgBox("Recording Length has been updated to " + CStr(lengthTo) + " s")
                ' MsgBox("Audio Snippets Storage has been set to the following location: " & vbCrLf & newStorePath)
                MsgBox("Your Settings have been updated!")

                'Fixing osTicket # 347172 creating a check to see if settings updated then remind user to update settings
                settingsRecordingLength = txtRecordLength.Text
                settingsStorePath = txtStorePath.Text
            Else
                MsgBox("Update Cancelled!")
                DisplaySavedWords()
            End If
        End If
    End Sub
    Private Sub imgHome_Click(sender As Object, e As EventArgs) Handles imgHome.Click
        'Fixing osTicket # 347172 creating a check to see if settings updated then remind user to update settings
        If (settingsRecordingLength = txtRecordLength.Text) Then
            If (settingsStorePath = txtStorePath.Text) Then
                DisplayHome()  'fixing ticket # 184811
            Else
                If MsgBox("You tried to update your Recording Length. Would you like to update it?" & vbCrLf & "Click on Yes button to update!" & vbCrLf & "Press No/Cancel buttons if you do not want to!", MsgBoxStyle.YesNoCancel, "vopio") = MsgBoxResult.Yes Then
                    Dim lengthTo
                    lengthTo = trackRecordingLength.Value

                    txtRecordLength.Text = lengthTo
                    trackRecordingLength.Value = txtRecordLength.Text ' Fixing osTicket # 626423

                    If (newStorePath = "") Then
                    Else
                        setStorePath(newStorePath)
                    End If

                    setRecordLength(lengthTo)

                    'Restarting Recording
                    Timer1.Stop()
                    ResetRecord()

                    ' MsgBox("Recording Length has been updated to " + CStr(lengthTo) + " s")
                    ' MsgBox("Audio Snippets Storage has been set to the following location: " & vbCrLf & newStorePath)
                    MsgBox("Your Settings have been updated!")

                    'Fixing osTicket # 347172 creating a check to see if settings updated then remind user to update settings
                    settingsRecordingLength = txtRecordLength.Text
                    settingsStorePath = txtStorePath.Text
                Else
                    MsgBox("Update Cancelled!")
                    DisplayHome() 'fixing ticket # 184811
                End If
            End If
        Else
            If MsgBox("You tried to update your Recording Length. Would you like to update it?" & vbCrLf & "Click on Yes button to update!" & vbCrLf & "Press No/Cancel buttons if you do not want to!", MsgBoxStyle.YesNoCancel, "vopio") = MsgBoxResult.Yes Then
                Dim lengthTo
                lengthTo = trackRecordingLength.Value

                txtRecordLength.Text = lengthTo
                trackRecordingLength.Value = txtRecordLength.Text ' Fixing osTicket # 626423

                If (newStorePath = "") Then
                Else
                    setStorePath(newStorePath)
                End If

                setRecordLength(lengthTo)

                'Restarting Recording
                Timer1.Stop()
                ResetRecord()

                ' MsgBox("Recording Length has been updated to " + CStr(lengthTo) + " s")
                ' MsgBox("Audio Snippets Storage has been set to the following location: " & vbCrLf & newStorePath)
                MsgBox("Your Settings have been updated!")

                'Fixing osTicket # 347172 creating a check to see if settings updated then remind user to update settings
                settingsRecordingLength = txtRecordLength.Text
                settingsStorePath = txtStorePath.Text
            Else
                MsgBox("Update Cancelled!")
                DisplayHome()  'fixing ticket # 184811
            End If
        End If
    End Sub

    Private Sub lblHome_Click(sender As Object, e As EventArgs) Handles lblHome.Click
        'Fixing osTicket # 347172 creating a check to see if settings updated then remind user to update settings
        If (settingsRecordingLength = txtRecordLength.Text) Then
            If (settingsStorePath = txtStorePath.Text) Then
                DisplayHome()
            Else
                If MsgBox("You tried to update your Store Path. Would you like to update it? Press No/Cancel if you do not want to!", MsgBoxStyle.YesNoCancel, "vopio") = MsgBoxResult.Yes Then
                    Dim lengthTo
                    lengthTo = trackRecordingLength.Value

                    txtRecordLength.Text = lengthTo
                    trackRecordingLength.Value = txtRecordLength.Text ' Fixing osTicket # 626423

                    If (newStorePath = "") Then
                    Else
                        setStorePath(newStorePath)
                    End If

                    setRecordLength(lengthTo)

                    'Restarting Recording
                    Timer1.Stop()
                    ResetRecord()

                    ' MsgBox("Recording Length has been updated to " + CStr(lengthTo) + " s")
                    ' MsgBox("Audio Snippets Storage has been set to the following location: " & vbCrLf & newStorePath)
                    MsgBox("Your Settings have been updated!")

                    'Fixing osTicket # 347172 creating a check to see if settings updated then remind user to update settings
                    settingsRecordingLength = txtRecordLength.Text
                    settingsStorePath = txtStorePath.Text
                Else
                    MsgBox("Update Cancelled!")
                    DisplayHome()
                End If
            End If
        Else
            If MsgBox("You tried to update your Recording Length. Would you like to update it? Press No/Cancel if you do not want to!", MsgBoxStyle.YesNoCancel, "vopio") = MsgBoxResult.Yes Then
                Dim lengthTo
                lengthTo = trackRecordingLength.Value

                txtRecordLength.Text = lengthTo
                trackRecordingLength.Value = txtRecordLength.Text ' Fixing osTicket # 626423

                If (newStorePath = "") Then
                Else
                    setStorePath(newStorePath)
                End If

                setRecordLength(lengthTo)

                'Restarting Recording
                Timer1.Stop()
                ResetRecord()

                ' MsgBox("Recording Length has been updated to " + CStr(lengthTo) + " s")
                ' MsgBox("Audio Snippets Storage has been set to the following location: " & vbCrLf & newStorePath)
                MsgBox("Your Settings have been updated!")

                'Fixing osTicket # 347172 creating a check to see if settings updated then remind user to update settings
                settingsRecordingLength = txtRecordLength.Text
                settingsStorePath = txtStorePath.Text
            Else
                MsgBox("Update Cancelled!")
                DisplayHome()
            End If
        End If
    End Sub

    Private Sub imgSettings_Click(sender As Object, e As EventArgs) Handles imgSettings.Click
        DisplaySettings()
        'Fixing osTicket # 347172 creating a check to see if settings updated then remind user to update settings
        settingsRecordingLength = txtRecordLength.Text
        settingsStorePath = txtStorePath.Text
    End Sub

    Private Sub lblSettings_Click(sender As Object, e As EventArgs) Handles lblSettings.Click
        DisplaySettings()
        'Fixing osTicket # 347172 creating a check to see if settings updated then remind user to update settings
        settingsRecordingLength = txtRecordLength.Text
        settingsStorePath = txtStorePath.Text
    End Sub


    Private Sub lblSave_Click(sender As Object, e As EventArgs) Handles lblSave.Click
        counter += 1
        Dim mydate As String = String.Format(Now.ToString("MMddyyyy_hhmmss"))
        mciSendString("save recsound " & """" & finalStorePath + mydate + ".wav" & """", "", 0, 0)
        mciSendString("close recsound", "", 0, 0)
        'MsgBox("File Created: " + finalStorePath + mydate + ".wav", MsgBoxStyle.OkOnly, "Success")
        ' Implementing Assembla Ticket # 26
        Dim result As Integer = MessageBox.Show("File Created: " + finalStorePath + mydate + ".wav" & vbCrLf & vbCrLf & "Would you like to rename this file?", "vopio | always learning", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
            MessageBox.Show("Cancel pressed")
        ElseIf result = DialogResult.No Then
            MessageBox.Show("No pressed")
        ElseIf result = DialogResult.Yes Then
            Dim Value As String
            Value = InputBox("Enter a Name for this Audio Snippet:") + ".wav"
            Dim oldValue As String = finalStorePath + mydate + ".wav"
            Dim newValue As String = Value
            'MsgBox(oldValue + " " + newValue)
            My.Computer.FileSystem.RenameFile("""" & finalStorePath + mydate + ".wav" & """", newValue)
        End If
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
        Dim diar1 As IO.FileInfo() = di.GetFiles("*.wav*") ' Added the code in bracket for GetFiles
        Dim dra As IO.FileInfo

        'list the names of all files in the specified directory
        For Each dra In diar1
            listRecordings.Items.Add(dra)
        Next
    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        If (listRecordings.SelectedItems.Count = 0) Then        'Assembla # 19
            MsgBox("Please Select a Recordig Snippet First!")
        Else
            Dim currentFile As String = listRecordings.SelectedItem.ToString
            Dim audioPath As String
            audioPath = finalStorePath + currentFile
            My.Computer.Audio.Play(audioPath, _
            AudioPlayMode.Background)
        End If

    End Sub

    Private Sub btnTranscribe_Click(sender As Object, e As EventArgs) Handles btnTranscribe.Click
        If (listRecordings.SelectedItems.Count = 0) Then        'Assembla # 19
            MsgBox("Please Select a Recordig Snippet First!")
        Else
            Dim currentAudio As String
            Dim currentFile As String = listRecordings.SelectedItem.ToString
            currentAudio = finalStorePath + currentFile
            recognizer.SetInputToWaveFile(currentAudio)
            recognizer.RecognizeAsync(Recognition.RecognizeMode.Multiple)
        End If

    End Sub

    Public Sub GotSpeech(ByVal sender As Object, ByVal phrase As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles recognizer.SpeechRecognized
        MsgBox(phrase.Result.Text)
        recognizer.Dispose() 'So that the file is release from the memory to be able to be deleted from the btnDelete
    End Sub



    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If (listRecordings.SelectedItems.Count = 0) Then        'Assembla # 19
            MsgBox("Please Select a Recordig Snippet First!")
        Else
            Dim currentAudio As String
            Dim currentFile As String = listRecordings.SelectedItem.ToString
            currentAudio = finalStorePath + currentFile
            ' Fixing osTicket # 951786 checking for if file exists
            If My.Computer.FileSystem.FileExists(currentAudio) Then
                'Code for Deleting (Assembla Ticket # 13)
                My.Computer.FileSystem.DeleteFile(currentAudio,
                Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently,
                Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)

                'After Deleting needs to update the listBox, so here is the code
                UpdateDirectory()
            Else
                MsgBox("File not found.")
                UpdateDirectory()
            End If

        End If

    End Sub

    Public Sub setRecordLength(rLength As String)
        My.Computer.FileSystem.WriteAllText(appDataPath + "\vopio\config\recordingLength.txt", rLength, False)
    End Sub

    Public Sub setStorePath(sPath As String)
        My.Computer.FileSystem.WriteAllText(appDataPath + "\vopio\config\storePath.txt", sPath, False)
        finalStorePath = sPath
    End Sub
    Private Sub trackRecordingLength_Scroll(sender As Object, e As EventArgs) Handles trackRecordingLength.Scroll
        txtRecordLength.Text = trackRecordingLength.Value
    End Sub

    Private Sub btnUpdateSettings_Click(sender As Object, e As EventArgs) Handles btnUpdateSettings.Click

        Dim lengthTo
        lengthTo = trackRecordingLength.Value

        txtRecordLength.Text = lengthTo
        trackRecordingLength.Value = txtRecordLength.Text ' Fixing osTicket # 626423

        If (newStorePath = "") Then
        Else
            setStorePath(newStorePath)
        End If

        setRecordLength(lengthTo)

        'Restarting Recording
        Timer1.Stop()
        ResetRecord()

        ' MsgBox("Recording Length has been updated to " + CStr(lengthTo) + " s")
        ' MsgBox("Audio Snippets Storage has been set to the following location: " & vbCrLf & newStorePath)
        MsgBox("Your Settings have been updated!")

        'Fixing osTicket # 347172 creating a check to see if settings updated then remind user to update settings
        settingsRecordingLength = txtRecordLength.Text
        settingsStorePath = txtStorePath.Text



    End Sub

    Private Sub linkVopioWeb_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkVopioWeb.LinkClicked
        Dim url As String = "http://www.vopio.info"
        Process.Start(url)
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim BrowseFolder As New FolderBrowserDialog
        BrowseFolder.ShowDialog()
        If (BrowseFolder.SelectedPath = "") Then 'Fixing osTicket # 831115
            MsgBox("No Folder was Selected!")
        Else
            newStorePath = BrowseFolder.SelectedPath + "\"
            txtStorePath.Text = newStorePath
        End If


    End Sub

    Private Sub btnSaveNow_Click(sender As Object, e As EventArgs) Handles btnSaveNow.Click
        ' Fixing Ticket # 640586
        counter += 1
        Dim mydate As String = String.Format(Now.ToString("MMddyyyy_hhmmss"))
        mciSendString("save recsound " & """" & finalStorePath + mydate + ".wav" & """", "", 0, 0)
        mciSendString("close recsound", "", 0, 0)
        'MsgBox("File Created: " + finalStorePath + mydate + ".wav", MsgBoxStyle.OkOnly, "Success")
        ' Implementing Assembla Ticket # 26
        Dim result As Integer = MessageBox.Show("File Created: " + finalStorePath + mydate + ".wav" & vbCrLf & vbCrLf & "Would you like to rename this file?", "vopio | always learning", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
            MessageBox.Show("Cancel pressed")
        ElseIf result = DialogResult.No Then
            MessageBox.Show("No pressed")
        ElseIf result = DialogResult.Yes Then
            Dim Value As String
            Value = InputBox("Enter a Name for this Audio Snippet:") + ".wav"
            Dim oldValue As String = finalStorePath + mydate + ".wav"
            Dim newValue As String = Value
            'MsgBox(oldValue + " " + newValue)
            My.Computer.FileSystem.RenameFile("""" & finalStorePath + mydate + ".wav" & """", newValue)
        End If
        My.Computer.Audio.Stop()

        UpdateDirectory()

        recordingRefresh = txtRecordLength.Text
        countRecord = 0
    End Sub

    'Implementing Assembla Ticket # 42 
    Private Sub btnShowInFolder_Click(sender As Object, e As EventArgs) Handles btnShowInFolder.Click
        If (listRecordings.SelectedItems.Count = 0) Then        'Assembla # 19
            MsgBox("Please Select a Recordig Snippet First!")
        Else
            Dim currentAudio As String
            Dim currentFile As String = listRecordings.SelectedItem.ToString
            currentAudio = finalStorePath + currentFile
            Diagnostics.Process.Start("Explorer.exe", String.Format("/select,{0}", IO.Path.Combine(finalStorePath, currentFile)))
        End If

    End Sub

    Private Sub btnAddNotes_Click(sender As Object, e As EventArgs) Handles btnAddNotes.Click
        'Implementing Assembla Ticket # 20
        If (listRecordings.SelectedItems.Count = 0) Then        'Assembla # 19
            MsgBox("Please Select a Recordig Snippet First!")
        Else
            Dim currentAudio As String
            Dim currentFile As String = listRecordings.SelectedItem.ToString
            currentAudio = finalStorePath + currentFile
            Dim stringToBeInput As String
            stringToBeInput = InputBox("Please enter the note for this wave file: " & vbCrLf & currentAudio)
            My.Computer.FileSystem.WriteAllText(currentAudio + ".txt", stringToBeInput, True)
            MsgBox("Note Created!")
        End If
    End Sub

    Private Sub btnOpenNotes_Click(sender As Object, e As EventArgs) Handles btnOpenNotes.Click
        'Implementing Assembla Ticket # 20
        If (listRecordings.SelectedItems.Count = 0) Then        'Assembla # 19
            MsgBox("Please Select a Recordig Snippet First!")
        Else
            Dim currentAudio As String
            Dim currentFile As String = listRecordings.SelectedItem.ToString
            currentAudio = finalStorePath + currentFile + ".txt"

            If My.Computer.FileSystem.FileExists(currentAudio) Then
                Dim fileReader As String
                fileReader = My.Computer.FileSystem.ReadAllText(currentAudio, System.Text.Encoding.UTF32)
                MsgBox(fileReader)
            Else
                MsgBox("You have not added a Note to this Audio Snippet yet. Please click Add Notes button to add a note to it.")
            End If
            
        End If
    End Sub
End Class


