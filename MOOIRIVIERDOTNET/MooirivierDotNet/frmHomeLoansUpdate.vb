Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports DAL
Public Class frmHomeLoansUpdate
    'Kobus 27/05/2014 create the Class to update Home Loan institutions
    Inherits System.Windows.Forms.Form

    'Kobus 27/05/2014 create Class
    'Description: Update Hire Purchase Institutions from a txt file

    'Dim appPath As String
    Dim intRow As Integer
    Dim strFilename As String
    Dim strNameAfr As String
    Dim strNameEng As String
    Dim bitHomeLoanCancelled As SByte

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
                Dim strSearchForThis As String = "Home"
                Dim intFirstFind As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
                If intFirstFind = -1 Then
                    MsgBox("The wrong file is selected.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            Else
                MsgBox("Please select the Home loan file.", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If
        If Me.txtPath.Text <> "" Then
            Dim strSearchWithinThis As String = Me.txtPath.Text
            Dim strSearchForThis As String = "Home"
            Dim intFirstFind As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
            If intFirstFind = -1 Then
                MsgBox("The wrong file is selected.", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If
        strFilename = Me.txtPath.Text

        Me.Label1.Visible = True
        Me.Label1.Text = "Number of Home Loan Organisations updated:"
        Me.btnCancel.Enabled = False
        Me.btnOk.Enabled = False
        Me.btnBrowse.Enabled = False

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'Kobus 24/06/2014 comment out
        'Me.listStatus.Visible = True '
        'Me.listStatus.Items.Add(("Update the existing Home loan organisations table."))
        'Me.Refresh()

        If UpdateHomeLoans() Then
            Me.listStatus.Visible = True
            Me.listStatus.Items.Add(("Home Loan Organisations Update completed."))
            Me.Refresh()
            Me.Cursor = System.Windows.Forms.Cursors.Default
            MsgBox("Home Loan Organisations Update completed.", MsgBoxStyle.Information)
            Me.btnCancel.Enabled = True
            Me.btnOk.Enabled = True
            Me.Label1.Text = "Number of Home Loan Organisations updated:"
            Me.btnCancel.Text = "Close"
            Me.btnOk.Enabled = False
            'Kobus 24/06/2014 comment out
            'Me.Label2.Text = "Update completed."
        Else
            MsgBox("Home Loan Organisations Update Failed.", MsgBoxStyle.Exclamation)
            Me.Label1.Visible = False
            'Kobus 24/06/2014 comment out
            'Me.Label2.Text = "Update the existing Home loan organisations table."
            'Kobus 24/06/2014 verander van My.Application.Info.Title & " -  Database update (Home loan organisations)"
            Me.Text = "     Home Loan Update"
            Me.btnBrowse.Enabled = True
            Me.txtPath.Text = ""
            'Kobus 24/06/2014 comment out
            'Me.listStatus.Items.Clear()
            Me.listStatus.Visible = True
            Me.lblProgress.Text = ""
            Me.btnCancel.Enabled = True
            Me.btnOk.Enabled = True
            Me.Label1.Text = ""
            Me.btnCancel.Text = "Cancel"

            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If


    End Sub


    Private Function UpdateHomeLoans() As Boolean

        Try
            intRow = 0
            strNameAfr = ""
            strNameEng = ""
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
                        strNameAfr = Trim(myarray(0).Replace("""", " "))
                        If Trim(strNameAfr) <> "" Then
                            'skip
                        Else
                            MsgBox("The wrong file is selected.", MsgBoxStyle.Information)
                            Return False
                            Exit Function
                        End If
                        strNameEng = Trim(myarray(1).Replace("""", " "))
                        If Trim(strNameEng) <> "" Then
                            'skip
                        Else
                            MsgBox("The wrong file is selected.", MsgBoxStyle.Information)
                            Return False
                            Exit Function
                        End If
                        If myarray(2) = "" Then
                            myarray(2) = "0"
                        End If
                        If myarray(2) <> "1" Then
                            myarray(2) = "0"
                        End If
                        bitHomeLoanCancelled = Trim(myarray(2))

                        


                        Using conn As SqlConnection = SqlHelper.GetConnection
                            Dim param() As SqlParameter = {New SqlParameter("@NameAfr", SqlDbType.NVarChar), _
                                                           New SqlParameter("@NameEng", SqlDbType.NVarChar), _
                                                           New SqlParameter("@Cancelled", SqlDbType.Bit)}
                            param(0).Value = strNameAfr
                            param(1).Value = strNameEng
                            param(2).Value = bitHomeLoanCancelled


                            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdateHomeLoansFromFile]", param)

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


        Me.Label1.Text = "Number of Home Loan Organisations updated:"
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

    Private Sub frmHomeLoansUpdate_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Label1.Visible = False
        'Kobus 24/06/2014 comment out
        'Me.Label2.Text = "Update the Home loan organisations table."
        'Kobus 24/06/2014 verander van My.Application.Info.Title & " -  Database update (Home loan organisations information)"
        Me.Text = "      Home Loan Update"
        Me.btnBrowse.Enabled = True
        Me.txtPath.Text = ""
        Me.listStatus.Visible = True
        'Kobus 24/06/2014 comment out
        Me.listStatus.Visible = True '
        Me.listStatus.Items.Add(("Update the Home Loan Organisations table."))
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
