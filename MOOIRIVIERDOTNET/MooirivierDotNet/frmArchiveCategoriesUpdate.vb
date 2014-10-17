Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports DAL
Friend Class frmArchiveCategoriesUpdate
    'Kobus 10/06/2014 create the Class to update Archive Categories from a txt file
    Inherits System.Windows.Forms.Form
    'Dim appPath As String
    Dim intRow As Integer
    Dim strFilename As String
    Dim strArchiveDescAfr As String
    Dim strArchiveDescEng As String
    Dim bitCancelled As SByte
    Dim bitIncoming As SByte
    'Kobus 16/07/2014 voegby
    Dim strAchiveFileAfr As String
    Dim strArchiveFileEng As String
    Private Sub btnBrowse_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnBrowse.Click
        CommonDialog1Open.ShowDialog()
        If CommonDialog1Open.FileName <> "" Then
            Me.txtPath.Text = CommonDialog1Open.FileName
        End If
    End Sub
    'Cancel button onclick - close/unload form
    Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click

        If Me.txtPath.Text = "" Then
            CommonDialog1Open.ShowDialog()
            If CommonDialog1Open.FileName <> "" Then
                Me.txtPath.Text = CommonDialog1Open.FileName
                Dim strSearchWithinThis As String = Me.txtPath.Text
                Dim strSearchForThis As String = "rchive"
                Dim intFirstFind As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
                If intFirstFind = -1 Then
                    MsgBox("The wrong file is selected.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            Else
                MsgBox("Please select the Archive Categories file.", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If
        If Me.txtPath.Text <> "" Then
            Dim strSearchWithinThis As String = Me.txtPath.Text
            Dim strSearchForThis As String = "rchive"
            Dim intFirstFind As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
            If intFirstFind = -1 Then
                MsgBox("The wrong file is selected.", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If
        strFilename = Me.txtPath.Text

        Me.Label1.Visible = True
        Me.Label1.Text = "Number of Archive Categories updated: " & intRow
        Me.btnCancel.Enabled = False
        Me.btnOk.Enabled = False
        Me.btnBrowse.Enabled = False

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Me.listStatus.Visible = True '
        'Kobus 23/06/2014 comment out
        'Me.listStatus.Items.Add(("Update the existing Archive Categories table."))
        'Me.Refresh()

        If updateArchiveCategories() Then
            Me.listStatus.Items.Add(("Archive Categories Update completed."))
            Me.Refresh()
            Me.Cursor = System.Windows.Forms.Cursors.Default
            MsgBox("Archive Categories Update completed.", MsgBoxStyle.Information)

            Me.btnCancel.Enabled = True
            Me.btnOk.Enabled = True
            Me.Label1.Text = "Number of Archive Categories updated:"
            Me.btnCancel.Text = "Close"
            Me.btnOk.Enabled = False
            Me.listStatus.Visible = True
            'Me.Label2.Text = "Update completed."
        Else
            MsgBox("Archive Categories Update Failed.", MsgBoxStyle.Exclamation)
            Me.Label1.Visible = False
            'Me.Label2.Text = "Update the existing Archive Categories table."
            'Kobus 23/06/2014 verwyder My.Application.Info.Title &
            Me.Text = "      Archive Update"
            Me.btnBrowse.Enabled = True
            Me.txtPath.Text = ""
            Me.listStatus.Items.Clear()
            Me.listStatus.Visible = True
            Me.lblProgress.Text = "Update Archive Categories table."
            Me.btnCancel.Enabled = True
            Me.btnOk.Enabled = True
            Me.Label1.Text = ""
            Me.btnCancel.Text = "Cancel"
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If

    End Sub
    Private Function updateArchiveCategories() As Boolean

        Try
            intRow = 0
            strArchiveDescAfr = ""
            strArchiveDescEng = ""
            bitCancelled = 0
            bitIncoming = 0
            strAchiveFileAfr = ""
            strArchiveFileEng = ""

            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader(strFilename)
            If System.IO.File.Exists(strFilename) = True Then
                Dim strReader As String
                strReader = fileReader.ReadLine()
                If Trim(strReader) = "" Then
                    MsgBox("The wrong file is selected.")
                    Return False
                    Exit Function
                End If

                Dim strSearchWithinThis As String = Trim(strReader)
                Dim strSearchForThis As String = "|"
                Dim intFirstFind As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
                If intFirstFind = -1 Then
                    MsgBox("The wrong file is selected.", MsgBoxStyle.Information)
                    Return False
                    Exit Function
                End If

                Do While Trim(strReader) <> ""
                    If intRow <> 0 Then
                        strReader = fileReader.ReadLine()
                    End If

                    If strReader = "" Then
                        Exit Do

                    Else

                        Dim myarray() As String = strReader.Split("|")
                        If myarray(0) = "" Or myarray(0) = "0" Then
                            MsgBox("The wrong file is selected.", MsgBoxStyle.Information)
                            Return False
                            Exit Function
                        Else
                            strArchiveDescAfr = Trim(myarray(0).Replace("""", " "))
                        End If

                        If myarray(1) = "" Or myarray(1) = "0" Then
                            MsgBox("The wrong file is selected.", MsgBoxStyle.Information)
                            Return False
                            Exit Function
                        Else
                            strArchiveDescEng = Trim(myarray(1).Replace("""", " "))
                        End If
                        If myarray(2) = "" Then
                            myarray(2) = "0"
                        End If
                        bitCancelled = myarray(2)
                        If myarray(3) = "" Then
                            myarray(3) = "1"
                        End If
                        bitIncoming = myarray(3)
                        If myarray(4) = "" Then
                            MsgBox("The wrong file is selected.", MsgBoxStyle.Information)
                            Return False
                            Exit Function
                        Else
                            strAchiveFileAfr = Trim(myarray(4).Replace("""", " "))
                        End If

                        If myarray(5) = "" Then
                            MsgBox("The wrong file is selected.", MsgBoxStyle.Information)
                            Return False
                            Exit Function
                        Else
                            strArchiveFileEng = Trim(myarray(5).Replace("""", " "))
                        End If

                        Using conn As SqlConnection = SqlHelper.GetConnection
                            Dim param() As SqlParameter = {New SqlParameter("@DescriptionAfr", SqlDbType.NVarChar), _
                                                           New SqlParameter("@descriptionEng", SqlDbType.NVarChar), _
                                                           New SqlParameter("@Cancelled", SqlDbType.Bit), _
                                                           New SqlParameter("@Incoming", SqlDbType.Bit), _
                                                           New SqlParameter("@CategoryFileAfr", SqlDbType.NVarChar), _
                                                           New SqlParameter("@CategoryFileEng", SqlDbType.NVarChar)}
                            param(0).Value = strArchiveDescAfr
                            param(1).Value = strArchiveDescEng
                            param(2).Value = bitCancelled
                            param(3).Value = bitIncoming
                            param(4).Value = strAchiveFileAfr
                            param(5).Value = strArchiveFileEng

                            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdateArchiveCategoriesFromFile]", param)

                            If conn.State = ConnectionState.Open Then
                                conn.Close()
                            End If
                            conn.Close()
                        End Using
                    End If

                    intRow = intRow + 1
                    lblProgress.Text = CStr(intRow)
                    lblProgress.Refresh()
                Loop

            Else
                MsgBox("File does not exist.", vbInformation)
                Return False
                Exit Function
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
            updateErrorList(True)
            Cursor = System.Windows.Forms.Cursors.Default
            Exit Function
        End Try

        Me.lblProgress.Text = CStr(intRow)
        Me.lblProgress.Refresh()
        Me.Label1.Text = "Verify data"
        Me.lblProgress.Text = intRow
        Cursor = System.Windows.Forms.Cursors.Default
        Return True

    End Function
    'Update listbox with current error
    Public Function updateErrorList(ByRef resetError As Boolean) As Object
        If Err.Number <> 0 Then
            Me.listStatus.Items.Add("     !Attention: " & Err.Description)
            If resetError Then
                Err.Clear()
            End If
        End If
        Return False
    End Function
    Private Sub frmArchiveCategoriesUpdate_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Label1.Visible = False
        ' Kobus 23/06/2014 voegby
        Me.listStatus.Items.Add(("Update the Archive Categories table."))
        Me.Refresh()
        'Kobus 23/06/2014 verwyder My.Application.Info.Title & " -  Database update (Archive Update)"
        Me.Text = "      Archive Update"
        Me.btnBrowse.Enabled = True
        Me.txtPath.Text = ""
        Me.listStatus.Visible = True
        Me.lblProgress.Text = ""
        Me.btnCancel.Enabled = True
        Me.btnOk.Enabled = True
        Me.Label1.Text = ""
        Me.btnCancel.Text = "Cancel"

    End Sub

    Private Sub txtPath_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPath.TextChanged
        Me.btnCancel.Enabled = True
        Me.btnOk.Enabled = True
        Me.Label1.Text = ""
        Me.btnCancel.Text = "Cancel"

    End Sub
End Class
