Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports DAL
Friend Class frmBankupdate
    Inherits BaseForm
	
    Dim blnBcvlag As Boolean
    'Kobus 07/02/2014 voegby
    Dim strFilename As String
    'Dim quot As Object
    Dim intRow As Integer
    ''Kobus 07/02/2014 voegby
    'Dim xlApp As Microsoft.Office.Interop.Excel.Application
    'Dim xlBook As Microsoft.Office.Interop.Excel.Workbook
    'Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet
    
    Private Sub bankReadExclAndUpdateSql()
        'Kobus 07/02/2014 skep Sub om Excel lêer in bankkode tabel op datum te bring
        Try
            Dim strBankcodes As String
            Dim strDay As String
            Dim strBank As String
            Dim strBranch As String
            Dim strComment As String
            Dim xlApp As New Excel.Application
            Dim xlBook As Excel.Workbook
            Dim xlSheet As Excel.Worksheet

            intRow = 1

            If System.IO.File.Exists(strFilename) = True Then

                xlBook = xlApp.Workbooks.Open(strFilename)
                xlSheet = xlBook.Worksheets(1)

            Else
                MsgBox("File does not exist.", vbInformation)
                Exit Sub
            End If


            If xlSheet Is Nothing Then
                MsgBox("Windows could not open the file.", vbInformation)
                Exit Sub
            End If
            If Trim(xlSheet.Cells(1, 2).Text) <> "1-DAY" Then
                MsgBox("The file chosen is not in the correct format. No information can be updated.  Please choose correct file.", vbInformation)
                Me.btnBrowse.Enabled = True
                Me.btnCancel.Enabled = True
                Me.btnOk.Enabled = True
                Me.txtPath.Text = ""
                Me.btnCancel.Text = "Cancel"
                'Kobus 23/06/2014 verander van false
                Me.listStatus.Visible = True
                Me.listStatus.Items.Add("Wrong file was selected.")
                Me.Refresh()
                blnBcvlag = 0
                Exit Sub
            End If

            blnBcvlag = 0

            Do While xlSheet.Cells(intRow, 2).Text = "1-DAY"
                'Kobus 22/05/2014 voegby voorwaarde fout indie kode ontbreek in xls
                If xlSheet.Cells(intRow, 1).Text = "" And xlSheet.Cells(intRow, 2).Text = "1-DAY" Then
                    blnBcvlag = 0
                    Exit Sub
                End If

                strBankcodes = Trim(xlSheet.Cells(intRow, 1).value)
                'Kobus 30/05/2014 voegby
                If IsNumeric(strBankcodes) And Trim(strBankcodes) <> "" Then
                    'Proceed
                Else
                    blnBcvlag = 0
                    MsgBox("The Branch Code is not valid.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
                strDay = Trim(xlSheet.Cells(intRow, 2).value)
                If xlSheet.Cells(intRow, 3).Text = "ABSA" Then
                    'Do nothing
                Else
                    'Kobus 02/06/2014 voegby toetse

                    strBank = Trim(xlSheet.Cells(intRow, 3).value)
                    If strBank = "" Then
                        MsgBox("The Bank Name is not valid.", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                    strBranch = Trim(xlSheet.Cells(intRow, 4).value)
                    If strBranch = "" Then
                        MsgBox("The Branch Name is not valid.", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                    strComment = Trim(xlSheet.Cells(intRow, 5).value)

                    'Kobus 22/05/2014 comment out
                    'Try
                    Using conn As SqlConnection = SqlHelper.GetConnection
                        Dim param() As SqlParameter = {New SqlParameter("@Branchcode", SqlDbType.NVarChar), _
                                                       New SqlParameter("@Period", SqlDbType.NVarChar), _
                                                       New SqlParameter("@Bankname", SqlDbType.NVarChar), _
                                                       New SqlParameter("@Branchname", SqlDbType.NVarChar), _
                                                       New SqlParameter("@Comment", SqlDbType.NVarChar), _
                                                       New SqlParameter("@Type", SqlDbType.NVarChar)}

                        param(0).Value = strBankcodes
                        param(1).Value = strDay
                        param(2).Value = strBank
                        param(3).Value = strBranch
                        param(4).Value = strComment
                        param(5).Value = "Bank"


                        SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdateBankCodesFromFile]", param)

                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                        conn.Dispose()

                    End Using
                    'Kobus 22/05/2014 comment out
                    'Catch ex As Exception
                    '    MsgBox(ex.Message)
                    'End Try
                End If
                intRow += 1
                'Kobus 21/05/2014 voegby
                Me.lblProgress.Text = CStr(intRow - 1)
                Me.lblProgress.Refresh()
            Loop

            xlBook.Close()
            xlApp.Quit()
            xlSheet = Nothing
            xlBook = Nothing
            xlApp = Nothing
            blnBcvlag = 1
            'Kobus 12/02/2014 voegby
            updateErrorList(True)
            'Kobus 22/05/2014 voegby
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
	Private Sub btnBrowse_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnBrowse.Click
		CommonDialog1Open.ShowDialog()
		If CommonDialog1Open.FileName <> "" Then
			Me.txtPath.Text = CommonDialog1Open.FileName
		End If
	End Sub
    'Cancel button onclick - close/unload form
    Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        Me.txtPath.Text = ""
        Me.Label1.Visible = False
        Me.Label2.Visible = False
        Me.btnBrowse.Enabled = True
        Me.Close()
    End Sub
    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click

        If Me.txtPath.Text = "" Then
            CommonDialog1Open.ShowDialog()
            If CommonDialog1Open.FileName <> "" Then
                Me.txtPath.Text = CommonDialog1Open.FileName
                'Kobus 10/02/2014 voegby
                strFilename = Me.txtPath.Text
            Else
                MsgBox("You must select the specific file.", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If

        'Kobus 10/02/2014 voegby
        strFilename = Me.txtPath.Text

        'Are you sure you want to run this upgrade ?
        'Kobus 10/02/2014 verander van MsgBox("Are you sure you want to update the banks do?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        If strFilename <> "" Then
            'If MsgBox("Are you sure you want to update the Bank Codes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Label2.Visible = True
            'Kobus 10/02/2014 verander van Label2.Text = "Aantal Banke:"
            Label2.Text = "Number of Bank Codes updated:"
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Me.btnBrowse.Enabled = False
            Me.btnCancel.Enabled = False
            Me.btnOk.Enabled = False

            Me.listStatus.Visible = True
            blnBcvlag = 0
            bankReadExclAndUpdateSql()

            If blnBcvlag = 1 Then
                Me.listStatus.Items.Add(("Update completed."))
                Me.Refresh()

                Me.Cursor = System.Windows.Forms.Cursors.Default
                'Kobus 21/05/04/2014 verander van MsgBox("Bank Information update completed.", MsgBoxStyle.Information)
                MsgBox("Bank Codes Update completed.", MsgBoxStyle.Information)
                Me.txtPath.Text = ""
                Me.Label2.Text = "Number of Bank Codes updated: "
                Me.btnCancel.Enabled = True
                Me.btnCancel.Text = "Close"
                Me.btnOk.Enabled = False
                Me.txtPath.Enabled = False
            ElseIf blnBcvlag <> 1 Then
                MsgBox("Bank Codes Update Failed!", MsgBoxStyle.Critical)
                Me.txtPath.Text = ""
                Me.txtPath.Enabled = True
                'Kobus 23/06/2014 comment out
                'Me.listStatus.Hide()

                Me.listStatus.Items.Add(("Bank Codes Update Failed!"))
                Me.Refresh()
                Me.Label2.Text = ""
                Me.lblProgress.Text = ""
                Me.btnCancel.Enabled = True
                Me.btnCancel.Text = "Cancel"
                Me.btnOk.Enabled = True
                'Kobus 23/06/2014 comment out
                'Me.listStatus.Items.Clear()
                Me.btnBrowse.Enabled = True
                'Kobus 23/06/2014 comment out
                'Me.lbl1.Text = "Update the Bank code table"
                'Kobus 26/05/2014 voegby
                Me.Cursor = System.Windows.Forms.Cursors.Default
            End If
        Else
            Exit Sub
        End If 'Msgbox
    End Sub
	Private Sub frmBankupdate_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Me.Label2.Visible = False
        'Kobus 05/12/2013 verander van Databasis Opdatering - Bank inligting
        'Kobus 23/06/2014 verander van My.Application.Info.Title & " - Database update (Bank information)"
        Me.Text = "      Bank Codes Update"
        'Kobus 22/05/2014 voegby

        Me.listStatus.Items.Clear()
        Me.listStatus.Visible = True
        'Kobus 23/06/2014 comment out
        Me.listStatus.Items.Add("Update the Bank Codes table")
        Me.Refresh()
        Me.lblProgress.Text = ""
        Me.txtPath.Text = ""
        Me.txtPath.Enabled = True

	End Sub
    'Update listbox with current error
    Public Sub updateErrorList(ByRef resetError As Boolean)
        If Err.Number <> 0 Then
            Me.listStatus.Items.Add("     !Attention: " & Err.Description)
            Me.Refresh()
            If resetError Then
                Err.Clear()
            End If
        End If
    End Sub
    Private Sub txtPath_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPath.TextChanged
        Me.btnCancel.Enabled = True
        Me.btnOk.Enabled = True
        Me.Label2.Text = ""
        Me.btnCancel.Text = "Cancel"
    End Sub
End Class
