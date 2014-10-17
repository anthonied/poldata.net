Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports DAL
Public Class frmHirePurchasesUpdate
    'Kobus 27/05/2014 create the Class to update Hire Purchase institutions
    Inherits System.Windows.Forms.Form

    'Kobus 27/05/2014 create Class
    'Description: Update Hire Purchase Institutions from a txt file

    'Dim appPath As String
    Dim intRow As Integer
    Dim strFilename As String
    Dim strHPInstitutions As String
    Dim bitHPInstitutionsCancelled As SByte
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
                Dim strSearchForThis As String = "Hire"
                Dim intFirstFind As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
                If intFirstFind = -1 Then
                    MsgBox("The wrong file is selected.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            Else
                MsgBox("Please select the Hire Purchase Institutions file.", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If
        If Me.txtPath.Text <> "" Then
            Dim strSearchWithinThis As String = Me.txtPath.Text
            Dim strSearchForThis As String = "Hire"
            Dim intFirstFind As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
            If intFirstFind = -1 Then
                MsgBox("The wrong file is selected.", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If
        strFilename = Me.txtPath.Text

        Me.Label1.Visible = True
        Me.Label1.Text = "Number of Hire Purchase Institutions updated:"
        Me.btnCancel.Enabled = False
        Me.btnOk.Enabled = False
        Me.btnBrowse.Enabled = False

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'Kobus 24/06/2014 comment out
        'Me.listStatus.Visible = True '
        'Me.listStatus.Items.Add(("Update the existing Hire purchase institutions table."))
        'Me.Refresh()

        If updateHirePurchase() Then
            Me.listStatus.Visible = True
            Me.listStatus.Items.Add(("Hire Purchase Institutions Update completed."))
            Me.Refresh()
            Me.Cursor = System.Windows.Forms.Cursors.Default
            MsgBox("Hire Purchase Institutions Update completed.", MsgBoxStyle.Information)
            Me.btnCancel.Enabled = True
            Me.btnOk.Enabled = True
            'Kobus 24/06/2014 comment out
            'Me.Label1.Text = "Number of Hire purchase institutions:"
            Me.btnCancel.Text = "Close"
            Me.btnOk.Enabled = False
            'Kobus 24/06/2014 comment out
            'Me.Label2.Text = "Update completed."
        Else
            MsgBox("Hire Purchase Institutions Update Failed.", MsgBoxStyle.Exclamation)
            Me.Label1.Visible = False
            'Kobus 24/06/2014 comment out
            'Me.Label2.Text = "Update the existing Hire purchase institutions table."
            'Kobus 24/06/2014 verander van My.Application.Info.Title & " -  Database update (Hire purchase)"
            Me.Text = "       Hire Purchase Update"
            Me.btnBrowse.Enabled = True
            Me.txtPath.Text = ""
            'Kobus 24/06/2014 comment out
            'Me.listStatus.Items.Clear()
            Me.listStatus.Visible = True
            'Kobus 24/06/2014 voegby
            Me.listStatus.Visible = True '
            Me.listStatus.Items.Add(("Hire Purchase Institutions Update Failed"))
            Me.Refresh()
            Me.lblProgress.Text = ""
            Me.btnCancel.Enabled = True
            Me.btnOk.Enabled = True
            Me.Label1.Text = ""
            Me.btnCancel.Text = "Cancel"
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If
    End Sub
    Private Function updateHirePurchase() As Boolean

        Try
            intRow = 0
            strHPInstitutions = ""

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
                        strHPInstitutions = Trim(myarray(0).Replace("""", " "))
                        If myarray(1) = "" Then
                            myarray(1) = "0"
                        End If
                        'Kobus 24/06/2014 voegby
                        If myarray(1) <> "1" Then
                            myarray(1) = "0"
                        End If
                        bitHPInstitutionsCancelled = Trim(myarray(1))

                        If Trim(myarray(1)) <= "1" Then
                            'skip
                        Else
                            MsgBox("The selected file has invalid characters.", MsgBoxStyle.Information)
                            Return False
                            Exit Function
                        End If


                        Using conn As SqlConnection = SqlHelper.GetConnection
                            Dim param() As SqlParameter = {New SqlParameter("@Beskrywing", SqlDbType.NVarChar), _
                                                           New SqlParameter("@Cancelled", SqlDbType.Bit)}
                            param(0).Value = strHPInstitutions
                            param(1).Value = bitHPInstitutionsCancelled

                            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdateHirePurchaseFromFile]", param)

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
        Me.Label1.Text = "Number of Hire Purchase Institutions updated:"
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
    Private Sub frmHirePurchaseUpdate_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Label1.Visible = False
        'Kobus 24/06/2014 comment out
        'Me.Label2.Text = "Update the Hire purchase institutions table."
        'Kobus 24/06/2014 verander van My.Application.Info.Title & " -  Database update (Hire purchase institutions information)"
        Me.Text = "       Hire Purchase Update"
        Me.listStatus.Visible = True
        'Kobus 24/06/2014 comment out
        Me.listStatus.Visible = True '
        Me.listStatus.Items.Add(("Update the Hire Purchase Institutions table"))
        Me.Refresh()
        Me.btnBrowse.Enabled = True
        Me.txtPath.Text = ""
        'Kobus 24/06/2014 comment out
        'Me.listStatus.Visible = False
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
