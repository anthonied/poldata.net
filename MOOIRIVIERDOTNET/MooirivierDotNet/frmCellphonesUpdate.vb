Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports DAL
Imports Excel = Microsoft.Office.Interop.Excel ' K
Friend Class frmCellphonesUpdate
    Inherits System.Windows.Forms.Form

    'Kobus 27/05/2014 create Class
    'Description: Update cellphone brands with a txt file

    Dim appPath As String
    Dim intRow As Integer
    Dim strFilename As String
    Dim strCellPhoneMake As String
    Dim bitCellphoneMakeCancelled As SByte
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
                Dim strSearchForThis As String = "phone"
                Dim intFirstFind As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
                If intFirstFind = -1 Then
                    MsgBox("The wrong file is selected.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            Else
                MsgBox("The wrong file is selected.", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If
        If Me.txtPath.Text <> "" Then
            Dim strSearchWithinThis As String = Me.txtPath.Text
            Dim strSearchForThis As String = "phone"
            Dim intFirstFind As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
            If intFirstFind = -1 Then
                MsgBox("The wrong file is selected.", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If
        strFilename = Me.txtPath.Text

        Me.Label1.Visible = True
        Me.Label1.Text = "Number of Cellphone Make updated:"
        Me.btnCancel.Enabled = False
        Me.btnOk.Enabled = False
        Me.btnBrowse.Enabled = False

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Me.listStatus.Visible = True '
        'Kobus 23/06/2014 comment out
        'Me.listStatus.Items.Add(("Update the existing Cellphone Make table"))
        'Me.Refresh()

        If updateCellphoneBrand() Then
            Me.listStatus.Visible = True
            Me.listStatus.Items.Add(("Cellphone Make Update completed."))
            Me.Refresh()
            Me.Cursor = System.Windows.Forms.Cursors.Default
            MsgBox("Cellphone Make Update completed.", MsgBoxStyle.Information)

            Me.btnCancel.Enabled = True
            Me.btnOk.Enabled = True
            Me.Label1.Text = "Number of Cellphone Make updated:"
            Me.btnCancel.Text = "Close"
            Me.btnOk.Enabled = False

            'Kobus 23/06/2014 comment out
            'Me.Label2.Text = "Update completed."
        Else
            MsgBox("Cellphone Make Update Failed.", MsgBoxStyle.Exclamation)
            Me.Label1.Visible = False
            'Kobus 23/06/2014 comment out
            'Me.Label2.Text = "Update the existing Cellphone Make table."
            'Kobus 23/06/2014 verander van My.Application.Info.Title & " -  Database update (Cellphone information)"
            Me.Text = "    Cellphone Make Update"
            Me.btnBrowse.Enabled = True
            Me.txtPath.Text = ""
            'Kobus 23/06/2014 verander listStatus na
            'Me.listStatus.Items.Clear()
            Me.listStatus.Visible = True
            Me.listStatus.Items.Add("Cellphone Make Update failed")
            Me.lblProgress.Text = ""
            Me.btnCancel.Enabled = True
            Me.btnOk.Enabled = True
            Me.Label1.Text = ""
            Me.btnCancel.Text = "Cancel"
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If


    End Sub
    

    Private Function updateCellphoneBrand() As Boolean

        Try
            intRow = 0
            strCellPhoneMake = ""
            bitCellphoneMakeCancelled = 0

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
                        strCellPhoneMake = Trim(myarray(0).Replace("""", " "))
                        If Trim(CStr(myarray(1))) = "" Then
                            myarray(1) = 0
                        End If

                        If Trim(myarray(1)) <= "1" Then
                            'skip
                        Else
                            'Kobus 24/06/2014 verander van  MsgBox("The wrong file is selected.", MsgBoxStyle.Information)
                            MsgBox("The selected file has invalid characters.", MsgBoxStyle.Information)
                            Return False
                            Exit Function
                        End If
                        bitCellphoneMakeCancelled = Trim(myarray(1))


                        Using conn As SqlConnection = SqlHelper.GetConnection
                            Dim param() As SqlParameter = {New SqlParameter("@cellmake", SqlDbType.NVarChar), _
                                                           New SqlParameter("@Cancelled", SqlDbType.Bit)}
                            param(0).Value = strCellPhoneMake
                            param(1).Value = bitCellphoneMakeCancelled

                            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdateCellphonesFromFile]", param)

                            If conn.State = ConnectionState.Open Then
                                conn.Close()
                            End If

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


        Me.Label1.Text = "Number of Cellphone Make updated:"
        Me.lblProgress.Text = intRow
        Cursor = System.Windows.Forms.Cursors.Default
        Return True

    End Function
    'Update listbox with current error
    Public Function updateErrorList(ByRef resetError As Boolean) As Object
        If Err.Number <> 0 Then
            Me.listStatus.Items.Add("     !Attention: " & Err.Description)
            Me.Refresh()
            If resetError Then
                Err.Clear()
            End If
        End If
        Return False
    End Function

    Private Sub frmCellphonesUpdate_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Label1.Visible = False
        'Kobus 23/06/2014 comment out
        'Me.Label2.Text = "Update the existing Cellphone Make table."
        'Kobus 23/06/2014 verander van My.Application.Info.Title & " -  Database update (Cellphone information)"
        Me.Text = "      Cellphone Make Update"
        Me.btnBrowse.Enabled = True
        Me.txtPath.Text = ""  
        Me.listStatus.Visible = True
        'Kobus 23/06/2014 voegby
        Me.listStatus.Items.Add("Update Cellphone Make table")
        Me.Refresh()
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
