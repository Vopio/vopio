Imports System.Speech
Imports System.Net
Imports System.IO
Imports System.Deployment.Application
Imports System.Reflection
Imports System.Deployment
Imports System.Configuration
Imports System.Runtime.InteropServices
Imports System.Text

' Implementing Assembla # 64 Saved Words: Improve Audio Transcription Ability
' Using Google Speech API to convert to text
' Using flac.exe frontline commandline program to convert .wav to .flac
' Sending the .flac file to the server, getting a json back
' Modifying the json to extract the transcribed text
Public Class frmTranscribe

    Friend inputWavFile As String
    Friend nameFile As String

    Private Sub frmTranscribe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblCurrentFile.Text = "File: " + nameFile
        If My.Computer.FileSystem.FileExists(inputWavFile + "_transcribed.txt") Then
            Dim fileReader As String
            fileReader = My.Computer.FileSystem.ReadAllText(inputWavFile + "_transcribed.txt", System.Text.Encoding.UTF32)
            lblDisplayTranscribedText.Text = fileReader
            btnSaveTranscribedText.Visible = False
        Else
            frmLoader.lblDisplay.Text = "Transcribing . . ."
            frmLoader.Show()


            Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            Dim startupPath As String = appDataPath + "\vopio\config\transcribe\input.wav"

            My.Computer.FileSystem.CopyFile(inputWavFile, startupPath, True)

            If My.Computer.FileSystem.FileExists(startupPath) Then
                ' Upload file using FTP
                ' UploadFile(startupPath, "ftp://noramovins.com/www/vopio/transcribe/input.wav", "noramovi", "@A1b1c1d1")
                'MsgBox("Vopio is contacting Google Speech API to transcribe!")
                'Assembla # 68 Transcribe: Create new uploading technique to not use FTP anymore for file upload
                My.Computer.Network.UploadFile(startupPath, "http://vopio.info/transcribe/upload.php")
                'Using wc As New System.Net.WebClient()
                'wc.UploadFile("http://www.noramovins.com/www/vopio/transcribe/upload.php", startupPath)
                'End Using
                'Diagnostics.Process.Start("Explorer.exe", String.Format("/select,{0}", appDataPath + "\vopio\config\transcribe\"))
            Else
                MsgBox("Error 879: Can't Transcribe at the moment!")
            End If

            System.Threading.Thread.Sleep(5000)

            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(New System.Uri("http://www.vopio.info/transcribe/process.php"))
            request.Method = System.Net.WebRequestMethods.Http.Get


            Dim response As System.Net.HttpWebResponse = request.GetResponse()
            Dim ResponseText As String
            Dim myStreamReader As New StreamReader(response.GetResponseStream())
            Using (myStreamReader)
                ResponseText = myStreamReader.ReadToEnd

                Using outfile As New StreamWriter(appDataPath & "\vopio\config\transcribe\text.txt")
                    outfile.Write(ResponseText)
                End Using
                lblDisplayTranscribedText.Text = "Transcribed Text: " & vbCrLf & ResponseText
            End Using

            'Diagnostics.Process.Start("Explorer.exe", String.Format("/select,{0}", appDataPath + "\vopio\config\transcribe\"))
            response.Close()

            frmLoader.Close()

        End If
       
    End Sub

    Public Sub UploadFile(ByVal _FileName As String, ByVal _UploadPath As String, ByVal _FTPUser As String, ByVal _FTPPass As String)
        Dim _FileInfo As New System.IO.FileInfo(_FileName)

        ' Create FtpWebRequest object from the Uri provided
        Dim _FtpWebRequest As System.Net.FtpWebRequest = CType(System.Net.FtpWebRequest.Create(New Uri(_UploadPath)), System.Net.FtpWebRequest)

        ' Provide the WebPermission Credintials
        _FtpWebRequest.Credentials = New System.Net.NetworkCredential(_FTPUser, _FTPPass)

        ' By default KeepAlive is true, where the control connection is not closed
        ' after a command is executed.
        _FtpWebRequest.KeepAlive = False

        ' set timeout for 20 seconds
        _FtpWebRequest.Timeout = 20000

        ' Specify the command to be executed.
        _FtpWebRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

        ' Specify the data transfer type.
        _FtpWebRequest.UseBinary = True

        ' Notify the server about the size of the uploaded file
        _FtpWebRequest.ContentLength = _FileInfo.Length

        ' The buffer size is set to 2kb
        Dim buffLength As Integer = 2048
        Dim buff(buffLength - 1) As Byte

        ' Opens a file stream (System.IO.FileStream) to read the file to be uploaded
        Dim _FileStream As System.IO.FileStream = _FileInfo.OpenRead()

        Try
            ' Stream to which the file to be upload is written
            Dim _Stream As System.IO.Stream = _FtpWebRequest.GetRequestStream()

            ' Read from the file stream 2kb at a time
            Dim contentLen As Integer = _FileStream.Read(buff, 0, buffLength)

            ' Till Stream content ends
            Do While contentLen <> 0
                ' Write Content from the file stream to the FTP Upload Stream
                _Stream.Write(buff, 0, contentLen)
                contentLen = _FileStream.Read(buff, 0, buffLength)
            Loop

            ' Close the file stream and the Request Stream
            _Stream.Close()
            _Stream.Dispose()
            _FileStream.Close()
            _FileStream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub btnSaveTranscribedText_Click(sender As Object, e As EventArgs) Handles btnSaveTranscribedText.Click
        Dim stringToBeInput As String
        stringToBeInput = lblDisplayTranscribedText.Text
        My.Computer.FileSystem.WriteAllText(inputWavFile + "_transcribed.txt", stringToBeInput, True)
        MsgBox("Transcribed Text Successfully Saved Created!")
    End Sub
End Class