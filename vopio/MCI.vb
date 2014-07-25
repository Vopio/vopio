    Imports System.Runtime.InteropServices

Public Class MCI

    <DllImport("winmm", setlasterror:=True, entrypoint:="mciSendString", CharSet:=CharSet.Auto)> _
    Private Shared Function mciSendString( _
            ByVal lpstrCommand As String, _
            ByVal lpstrReturnString As String, _
            ByRef uReturnLength As Integer, _
            ByVal hwndCallBack As IntPtr) As Integer
    End Function

    Public Shared Function GetMediaLength(ByVal FileName As String) As ULong
        Dim MediaLength As ULong
        Dim RetString As New String(" "c, 50)
        Dim CommandString As String

        'open the media file
        If Not IO.File.Exists(FileName) Then
            Throw New IO.FileNotFoundException(String.Format("File {0} was not found.", FileName))
            Return Nothing
        End If

        CommandString = "Open " & FileName & " alias MediaFile"
        mciSendString(CommandString, String.Empty, 0, IntPtr.Zero)

        'get the media file length
        CommandString = "Set MediaFile time format milliseconds"
        mciSendString(CommandString, String.Empty, 0, IntPtr.Zero)
        CommandString = "Status MediaFile length"

        mciSendString(CommandString, RetString, RetString.Length, IntPtr.Zero)

        RetString = RetString.Trim

        If Not ULong.TryParse(RetString, MediaLength) Then
            MsgBox(String.Format("Failed to retrieve the media length for '{0}'.", FileName))
            MsgBox(MediaLength)
            Return Nothing
        End If

        'close the media file
        CommandString = "Close MediaFile"
        mciSendString(CommandString, vbNullString, 0, IntPtr.Zero)

        Return MediaLength
    End Function
End Class

