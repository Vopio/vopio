Imports System.Speech
Imports System.Net
Imports System.IO
Imports System.Deployment.Application
Imports System.Reflection
Imports System.Deployment
Imports System.Configuration

Imports System.Runtime.InteropServices


Public Class home

    'Implementing Automatic Key Press when not focussed

    'For example, I've found that &H1 is the ALT key, &H2 is the CONTROL key, and &H3 is both the ALT and CONTROL keys together. &H10 is the Shift key, it appears. I
    Public Const MOD_ALT As Integer = &H1 'Alt key
    Public Const WM_HOTKEY As Integer = &H312
    Public Const MOD_CTRL As Integer = &H2 'Control key

    <DllImport("User32.dll")> _
    Public Shared Function RegisterHotKey(ByVal hwnd As IntPtr, _
                        ByVal id As Integer, ByVal fsModifiers As Integer, _
                        ByVal vk As Integer) As Integer
    End Function

    <DllImport("User32.dll")> _
    Public Shared Function UnregisterHotKey(ByVal hwnd As IntPtr, _
                        ByVal id As Integer) As Integer
    End Function
    '------------------------------------------------------------------------------

    'Implementing the automatic publish version update
    Public Function GetAppVersion() As String
        ''Return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
        Return "Version: " + My.Application.Deployment.CurrentVersion.ToString
    End Function

    Dim storePathTest As String
    Dim WithEvents WC As New WebClient

    Dim counter = 0
    Dim recordingRefresh = 0
    Dim countRecord = 0
    Dim storePATH
    Dim desktopStorePath As String
    Public Shared finalStorePath As String
    Dim appDataPath As String

    Dim settingsRecordingLength
    Dim settingsStorePath

    Dim audioHandler As Long
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


    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_HOTKEY Then
            Dim id As IntPtr = m.WParam
            Select Case (id.ToString)
                Case "100"
                    'MessageBox.Show("You pressed ALT+S key combination")
                    Me.WindowState = FormWindowState.Normal
                    SaveAudio()
                Case "200"
                    MessageBox.Show("You pressed ALT+C key combination")
            End Select
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub home_FormClosing(ByVal sender As System.Object, _
                       ByVal e As System.Windows.Forms.FormClosingEventArgs) _
                       Handles MyBase.FormClosing
        UnregisterHotKey(Me.Handle, 100)
        UnregisterHotKey(Me.Handle, 200)
    End Sub


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



        'Automatic Key press assembla # 53
        RegisterHotKey(Me.Handle, 100, MOD_CTRL, Keys.S)
        'RegisterHotKey(Me.Handle, 200, MOD_ALT, Keys.C)


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
        getFinalStorePath()

        recordingRefresh = txtRecordLength.Text

        Timer1.Interval = 1000
        Timer1.Start()
        recognizer.LoadGrammar(gram)
        progressRecording.Maximum = txtRecordLength.Text
        progressRecording.Minimum = 0
        trackRecordingLength.Value = txtRecordLength.Text ' Fixing osTicket # 626423

        'Fixing osTicket # 641368 Locking the Recording Lenght Text Box
        txtRecordLength.Enabled = False




        'Embedding Font Assembla Ticket # 33
        Dim big As New System.Drawing.Font("Microsoft MHei", 36)
        Dim medium As New System.Drawing.Font("Microsoft MHei", 22)
        Dim mediumSmall As New System.Drawing.Font("Microsoft MHei", 18)
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

        'Assembla # 48 Footer design to include version number of the software

        lblVersion.Text = GetAppVersion()



        lblVersion.Font = smallest



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

        'lblHomeRec.Font = medium
        lblHomeRec.Font = mediumSmall ' fixing osTicket # 554000 Home: design issues with time in the save animation progress bar

        lblListening.Font = medium

        'Fixing osTicket # 347172 creating a check to see if settings updated then remind user to update settings
        settingsRecordingLength = txtRecordLength.Text
        settingsStorePath = txtStorePath.Text
        'MsgBox(settingsRecordingLength)



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
        'MsgBox(txtRecordLength.Text)
        settingsRecordingLength = fileReader

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
        settingsStorePath = fileReader
        txtStorePath.Text = fileReader
    End Sub

    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        configureApp()
    End Sub
    ' Implementing Assembla # 53 Saving function remote control
    Private Sub home_KeyDown(sender As Object, f As KeyEventArgs) Handles MyBase.KeyDown
        If f.KeyCode = Keys.S Then
            SaveAudio()
        End If
    End Sub

    Private Sub RecordSound()
        ''Dim RetStr As String = Space(1024)
        ''audioHandler = mciSendString("open new Type waveaudio Alias recsound", "", 0, 0)
        ''audioHandler = mciSendString("set recsound channels 2", RetStr, 1024, 0) ' Stereo Or Mono Sound
        ''audioHandler = mciSendString("set recsound samplespersec 44100", RetStr, 1024, 0) ' Khz Rate
        ''audioHandler = mciSendString("set recsound bitspersample 16", RetStr, 1024, 0) ' Sound Sample Rate (Bits)
        ''audioHandler = mciSendString("record recsound", 0&, 0, 0)
        'lblDisplayStatus.Visible = True

        'Samples Per Second that are supported:
        '11025       low quality
        '22050       medium quality
        '44100     high quality (CD music quality)
        Dim I As Long

        Dim sCommand As String
        Dim lAvgBytesPerSec As Long
        Dim lBlockAlignment As Long

        'Calculate the average bytes/sec and block alignment
        lAvgBytesPerSec = (16 * 2 * 44100) / 8
        lBlockAlignment = (16 * 2) / 8
        I = mciSendString("open new Type waveaudio Alias recsound", "", 0, 0)
        'Even though MCI's documentation does not mention these
        'need to be set in a certain order, I've found that if
        'the below order is not used, the function will fail.
        sCommand = "set recsound bitspersample 16 channels 2 alignment " &
        CStr(lBlockAlignment) & " samplespersec 44100 bytespersec " &
        CStr(lAvgBytesPerSec) & " format tag pcm wait"

        I = mciSendString(sCommand, vbNullString, 0, 0)
        I = mciSendString("record recsound", 0&, 0, 0)  'Start the recording



    End Sub

    Private Sub ResetRecord()
        audioHandler = mciSendString("close recsound", "", 0, 0)
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
        audioHandler = mciSendString("save recsound " & """" & finalStorePath + mydate + ".wav" & """", "", 0, 0)
        audioHandler = mciSendString("close recsound", "", 0, 0)
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
        'Implementing Assembla # 50 Home: change main sentence 
        lblDisplayStatus.Text = "learning the previous " + CStr(countRecord) + " s" 'Fixing osTicket # 106951
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
        If (My.Computer.FileSystem.DirectoryExists(finalStorePath)) Then
            UpdateDirectory()
        Else
            My.Computer.FileSystem.CreateDirectory(finalStorePath)
            MsgBox("Your folder containing the saved audio snippets is deleted or renamed manually. The store path will be created again. If you need to set a new store path,  please change your store path through the Settings Menu!")
        End If


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
        'txtRecordLength.Enabled = False

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
                    getRecordLength()
                    getFinalStorePath()
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
                getRecordLength()
                getFinalStorePath()
                DisplaySavedWords()
            End If
        End If
    End Sub

    ' Implementing Assembla # Footer: Icons Hovering Effect
    '-----------------------------------------------------------------------------------------------------------
    Private Sub lblSavedWords_Hover(sender As Object, e As EventArgs) Handles lblSavedWords.MouseHover
        lblSavedWords.BackColor = Color.White
        lblSavedWords.ForeColor = Color.FromArgb(0, 174, 239)
    End Sub

    Private Sub lblSavedWords_Leave(sender As Object, e As EventArgs) Handles lblSavedWords.MouseLeave
        lblSavedWords.BackColor = Color.Transparent
        lblSavedWords.ForeColor = Color.White
    End Sub

    Private Sub lblHome_Hover(sender As Object, e As EventArgs) Handles lblHome.MouseHover
        lblHome.BackColor = Color.White
        lblHome.ForeColor = Color.FromArgb(0, 174, 239)
    End Sub

    Private Sub lblHome_Leave(sender As Object, e As EventArgs) Handles lblHome.MouseLeave
        lblHome.BackColor = Color.Transparent
        lblHome.ForeColor = Color.White
    End Sub

    Private Sub lblSettings_Hover(sender As Object, e As EventArgs) Handles lblSettings.MouseHover
        lblSettings.BackColor = Color.White
        lblSettings.ForeColor = Color.FromArgb(0, 174, 239)
    End Sub

    Private Sub lblSettings_Leave(sender As Object, e As EventArgs) Handles lblSettings.MouseLeave
        lblSettings.BackColor = Color.Transparent
        lblSettings.ForeColor = Color.White
    End Sub

    Private Sub imgavedWords_Hover(sender As Object, e As EventArgs) Handles imgSavedWords.MouseHover
        lblSavedWords.BackColor = Color.White
        lblSavedWords.ForeColor = Color.FromArgb(0, 174, 239)
    End Sub

    Private Sub imgSavedWords_Leave(sender As Object, e As EventArgs) Handles imgSavedWords.MouseLeave
        lblSavedWords.BackColor = Color.Transparent
        lblSavedWords.ForeColor = Color.White
    End Sub

    Private Sub imgHome_Hover(sender As Object, e As EventArgs) Handles imgHome.MouseHover
        lblHome.BackColor = Color.White
        lblHome.ForeColor = Color.FromArgb(0, 174, 239)
    End Sub

    Private Sub imgHome_Leave(sender As Object, e As EventArgs) Handles imgHome.MouseLeave
        lblHome.BackColor = Color.Transparent
        lblHome.ForeColor = Color.White
    End Sub

    Private Sub imgSettings_Hover(sender As Object, e As EventArgs) Handles imgSettings.MouseHover
        lblSettings.BackColor = Color.White
        lblSettings.ForeColor = Color.FromArgb(0, 174, 239)
    End Sub

    Private Sub imgSettings_Leave(sender As Object, e As EventArgs) Handles imgSettings.MouseLeave
        lblSettings.BackColor = Color.Transparent
        lblSettings.ForeColor = Color.White
    End Sub





    ' -------------------------------------------------------------------------------------------

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
                    getRecordLength()
                    getFinalStorePath()
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
                getRecordLength()
                getFinalStorePath()
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
                    getRecordLength()
                    getFinalStorePath()
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
                getRecordLength()
                getFinalStorePath()
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
                    getRecordLength()
                    getFinalStorePath()
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
                getRecordLength()
                getFinalStorePath()
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
        SaveAudio()
    End Sub

    Private Sub UpdateDirectory()

        getDesktopStorePath()
        ' make a reference to a directory
        listRecordings.Items.Clear()
        Dim di As New IO.DirectoryInfo(finalStorePath)
        'Dim diar1 As IO.FileInfo() = di.GetFiles("*.wav*") ' Added the code in bracket for GetFiles
        Dim diar1 As IO.FileInfo() = di.GetFiles("*.wav") ' Removed the * after .wav to display only .wav files fix for osTicket # 869991
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

            ' Assembla # 46 Special Audio Player
            frmAudioPlayer.Close()
            frmAudioPlayer.audioName = currentFile
            frmAudioPlayer.audioFile = audioPath
            frmAudioPlayer.Show()
        End If

    End Sub

    

    Private Sub btnTranscribe_Click(sender As Object, e As EventArgs) Handles btnTranscribe.Click
        If (listRecordings.SelectedItems.Count = 0) Then        'Assembla # 19
            MsgBox("Please Select a Recordig Snippet First!")
        Else
            Dim currentAudio As String
            Dim currentFile As String = listRecordings.SelectedItem.ToString
            currentAudio = finalStorePath + currentFile
            Dim audioDuration As String
            audioDuration = frmAudioPlayer.getAudioDuration(currentAudio)
            Dim audioDurationValue As Double
            audioDurationValue = CDbl(audioDuration)

            If audioDuration < 2 Then
                MsgBox("Sorry cant transcribe less than 2 seconds snippet!")
            Else
                recognizer.SetInputToWaveFile(currentAudio)
                recognizer.RecognizeAsync(Recognition.RecognizeMode.Multiple)
            End If
        End If

    End Sub

    Public Sub GotSpeech(ByVal sender As Object, ByVal phrase As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles recognizer.SpeechRecognized
        MsgBox(phrase.Result.Text)
        recognizer.Dispose() 'So that the file is release from the memory to be able to be deleted from the btnDelete
    End Sub



    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'recognizer.Dispose() ' osTicket # 742942 Saved words: can't delete a file
        If (listRecordings.SelectedItems.Count = 0) Then        'Assembla # 19
            MsgBox("Please Select a Recordig Snippet First!")
        ElseIf (listRecordings.SelectedItems.Count > 1) Then
            ' Implementing multiple deletion Assembla # 47 Delete multiple files functionality
            Dim countSelected = listRecordings.SelectedItems.Count
            Dim currentAudio As String
            Dim currentFile As String
            Dim counter = 0
            While (counter < countSelected)
                currentFile = listRecordings.SelectedItems(counter).ToString()
                currentAudio = finalStorePath + currentFile
                ' Fixing osTicket # 951786 checking for if file exists
                If My.Computer.FileSystem.FileExists(currentAudio) Then
                    'Code for Deleting (Assembla Ticket # 13)
                    My.Computer.FileSystem.DeleteFile(currentAudio,
                    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                    Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently,
                    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
                Else
                    MsgBox("File not found.")
                End If
                counter = counter + 1
            End While
            'After Deleting needs to update the listBox, so here is the code
            UpdateDirectory()
        Else
            Dim currentAudio As String
            Dim currentFile As String = listRecordings.SelectedItem.ToString
            currentAudio = finalStorePath + currentFile
            ' Fixing osTicket # 951786 checking for if file exists
            If My.Computer.FileSystem.FileExists(currentAudio) Then
                'Code for Deleting (Assembla Ticket # 13)
                ' Fixing from Only errors to all dialogs [delete single files no warning] assembla # 52
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
        Dim oldStorePath As String
        oldStorePath = finalStorePath
        My.Computer.FileSystem.WriteAllText(appDataPath + "\vopio\config\storePath.txt", sPath, False)
        finalStorePath = sPath
        'Fixing osTicket # 195338 checking to see if the folder has been deleted or not
        'osTicket # 737628 Saved Words: broken link possible suggestion is to ask user to move
        Dim result As Integer = MessageBox.Show("Would you like to move your recording snippets to the new folder?", "vopio", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
            'MessageBox.Show("Cancel pressed")
        ElseIf result = DialogResult.No Then
            'MessageBox.Show("No pressed")
        ElseIf result = DialogResult.Yes Then
            If (My.Computer.FileSystem.DirectoryExists(oldStorePath)) Then
                For Each foundFile As String In My.Computer.FileSystem.GetFiles( _
                    oldStorePath, _
                    Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.wav*")

                    Dim foundFileInfo As New System.IO.FileInfo(foundFile)
                    ' Fixing osTicket # 780781 Creating a logic to check if the file exists already
                    If My.Computer.FileSystem.FileExists(newStorePath + "\" + foundFile) Then
                        Dim stillMove As Integer = MessageBox.Show(newStorePath + "\" + foundFile & vbCrLf & "This file already exist! Would you like to replace the file?", "vopio", MessageBoxButtons.YesNoCancel)
                        If stillMove = DialogResult.Yes Then
                            My.Computer.FileSystem.DeleteFile(newStorePath + "\" + foundFile)
                            My.Computer.FileSystem.MoveFile(foundFile, newStorePath + "\" & foundFileInfo.Name)
                        End If
                    Else
                        My.Computer.FileSystem.MoveFile(foundFile, newStorePath + "\" & foundFileInfo.Name)
                    End If

                Next
                MessageBox.Show("Files Successfully Moved")
            Else
                MsgBox("Your old folder is deleted, moved or renamed manually! So, vopio could not find it. New audio snippets would be recording in your new store path. It is always recommended that you do not manually rename or move or delete your store path folder.")
            End If
        End If


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
    Private Sub SaveAudio()
        ' Fixing Ticket # 640586
        counter += 1

        'Fixing osTicket # 859671 Saving function
        If (My.Computer.FileSystem.DirectoryExists(finalStorePath)) Then
            'MsgBox("Storepath exists!")
        Else
            MsgBox("Your settings store path might have been deleted or not created. So, we just created the storage path again for you.")
            My.Computer.FileSystem.CreateDirectory(finalStorePath)
        End If


        Dim mydate As String = String.Format(Now.ToString("MMddyyyy_hhmmss"))
        mciSendString("save recsound " & """" & finalStorePath + mydate + ".wav" & """", "", 0, 0)
        mciSendString("close recsound", "", 0, 0)
        'MsgBox("File Created: " + finalStorePath + mydate + ".wav", MsgBoxStyle.OkOnly, "Success")
        ' Implementing Assembla Ticket # 26
        Dim result As Integer = MessageBox.Show("File Created: " + finalStorePath + mydate + ".wav" & vbCrLf & vbCrLf & "Would you like to rename this file?", "vopio | always learning", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
            'MessageBox.Show("Cancel pressed")
        ElseIf result = DialogResult.No Then
            'MessageBox.Show("No pressed") ' fixing osTicket # 271511
        ElseIf result = DialogResult.Yes Then
            Dim Value As String
            Value = InputBox("Enter a Name for this Audio Snippet:") + ".wav"
            Dim oldValue As String = finalStorePath + mydate + ".wav"
            Dim storePathFormatted As String = """" & finalStorePath & """" ' fxing rename issues osTicket # 597985 Renaming files does not work
            Dim newValue As String = Value
            MsgBox(oldValue + " " + newValue)
            My.Computer.FileSystem.RenameFile(finalStorePath + mydate + ".wav", newValue)
        End If
        My.Computer.Audio.Stop()

        UpdateDirectory()

        recordingRefresh = txtRecordLength.Text
        countRecord = 0
    End Sub
    Private Sub btnSaveNow_Click(sender As Object, e As EventArgs) Handles btnSaveNow.Click
        SaveAudio()
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


