Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports DAL
'Kobus 12/02/2014 voegby
Imports Excel = Microsoft.Office.Interop.Excel

Friend Class frmKredietkaartupdate
    Inherits BaseForm
	
    Dim blnBcvlag As Boolean
    Dim intRow As Integer
    'Kobus 07/02/2014 voegby
    Dim strFilename As String
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
            Else
                MsgBox("You must select the specific file.", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If

        'Kobus 12/02/2014 voegby
        strFilename = Me.txtPath.Text
        lblUpdateResult.Visible = True
        'Kobus 12/02/2014 verander van  Label2.Text = "aantal Kredietkaarte:"
        lblUpdateResult.Text = "Number of Credit Cards:"
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Me.btnBrowse.Enabled = False
        Me.btnCancel.Enabled = False
        Me.btnOk.Enabled = False

        Me.listStatus.Visible = True

        updateCreditCard()

        If blnBcvlag = True Then
            'Kobus 12/02/2014 verander van "Opdatering afgehandel."
            Me.listStatus.Items.Add(("Update completed."))
            Me.Refresh()

            Me.Cursor = System.Windows.Forms.Cursors.Default

            MsgBox("Credit cards update completed.", MsgBoxStyle.Information)
            Me.lblUpdateResult.Enabled = True
            Me.lblUpdateResult.Text = "Number of Credit Cards: " & intRow
            Me.btnCancel.Enabled = True
            Me.btnCancel.Enabled = True
            Me.btnCancel.Text = "Close"
            Me.btnOk.Enabled = False
            Me.txtPath.Enabled = False
        ElseIf blnBcvlag <> True Then
            MsgBox("Credit cards update Failed!", MsgBoxStyle.Critical)
            Me.txtPath.Text = ""
            Me.txtPath.Enabled = True
            'Kobus 23/06/2014 voegby
            Me.listStatus.Visible = True
            'Kobus 23/06/2014 verander van Me.listStatus.Items.Clear()
            Me.listStatus.Items.Add("Credit cards update Failed!")
            Me.Refresh()
            Me.lblProgress.Text = ""
            Me.btnCancel.Enabled = True
            Me.btnCancel.Text = "Cancel"
            Me.btnOk.Enabled = True
            Me.btnBrowse.Enabled = True
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If

    End Sub
    Private Sub frmKredietkaartupdate_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.lblUpdateResult.Visible = False

        Me.Text = "      Credit Card Update"
        'Kobus 23/06/2014 voegby
        Me.listStatus.Visible = True
        Me.listStatus.Items.Clear()
        Me.listStatus.Items.Add(("Update the Credit Card table."))
        Me.Refresh()
        'Kobus 23/05/2014 voegby
        Me.btnBrowse.Enabled = True
        Me.btnCancel.Text = "Cancel"
        Me.btnOk.Enabled = True
        Me.txtPath.Text = ""
        Me.txtPath.Enabled = True
        Me.lblProgress.Text = ""
        
    End Sub
    Public Sub updateCreditCard()
        'Kobus 12/02/2014 skep sub om Kredietkaartinligting in stand te hou
        Dim strBank As String = ""
        Dim strBranchCodes As String = ""
        Dim blnBank As Boolean
        Dim strDay As String
        Dim strBranch As String = ""
        Dim strComment As String
        Dim strType As String
        Dim strSeparator() As String = {" "}
        Dim xlApp As New Excel.Application
        Dim xlBook As Excel.Workbook
        Dim xlSheet As Excel.Worksheet
        If System.IO.File.Exists(strFilename) = True Then

            intRow = 3

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

        Do Until intRow = xlSheet.Rows.Count
            If xlSheet.Cells(intRow, 1).Text.Contains("ABSA") Then
                blnBank = True
                Exit Do
            Else
                blnBank = False
            End If
            intRow += 1
            If intRow = 50 Then
                Exit Do
            End If
        Loop

        If blnBank = False Then
            MsgBox("The file chosen is not in the correct format. No information can be updated.  Please choose correct file.", vbInformation)
            Me.btnBrowse.Enabled = True
            Me.btnCancel.Enabled = True
            Me.btnOk.Enabled = True
            Me.txtPath.Text = ""
            Me.btnCancel.Text = "Cancel"
            Me.listStatus.Visible = False
            blnBcvlag = False
            Exit Sub
        End If

        intRow = 3
        'Kobus 23/05/2014 verander van Do While xlSheet.Cells(intRow, 1).Text <> ""
        Do While xlSheet.Cells(intRow, 1).Text <> "" And xlSheet.Cells(intRow, 2).Text <> ""

            Dim strWoorde() As String
            Dim intTeller As Integer
            strBranch = ""
            'arrWoorde = Split(xlSheet.Cells(intRow, 1).Text, strSeparator, StringSplitOptions.RemoveEmptyEntries)
            strWoorde = xlSheet.Cells(intRow, 1).Text.split(strSeparator, StringSplitOptions.RemoveEmptyEntries)
            If strWoorde.Length > 0 Then

                If strWoorde.Length = 1 Then
                    strBank = strWoorde(0)
                    strBranch = strWoorde(0)
                Else
                    If UCase(strWoorde(1)) = "BANK" Or UCase(strWoorde(1)) = "WEST" Then
                        strBank = strWoorde(0) & " " & Trim(strWoorde(1))

                        'If arrWoorde.Length = 2 Then
                        '    strBranch = strBank
                        'Else
                        intTeller = 2
                        'End If
                    Else
                        strBank = strWoorde(0)
                        intTeller = 1
                    End If


                    If strWoorde.Length = 2 Then
                        strBranch = strBank
                    Else

                        For indeks As Integer = intTeller To strWoorde.Length - 1 Step 1
                            strBranch = strBranch & " " & strWoorde(indeks)
                        Next

                    End If
                End If


                strBranchCodes = xlSheet.Cells(intRow, 2).Text
                strBranchCodes = strBranchCodes.Replace("-", "")
                strType = "Credit card"
                strDay = ""
                strComment = ""

                Try
                    Using conn As SqlConnection = SqlHelper.GetConnection
                        Dim param() As SqlParameter = {New SqlParameter("@Branchcode", SqlDbType.NVarChar), _
                                                       New SqlParameter("@Period", SqlDbType.NVarChar), _
                                                       New SqlParameter("@Bankname", SqlDbType.NVarChar), _
                                                       New SqlParameter("@Branchname", SqlDbType.NVarChar), _
                                                       New SqlParameter("@Comment", SqlDbType.NVarChar), _
                                                       New SqlParameter("@Type", SqlDbType.NVarChar)}

                        param(0).Value = strBranchCodes.Trim
                        param(1).Value = strDay
                        param(2).Value = strBank.Trim
                        param(3).Value = strBranch.Trim
                        param(4).Value = strComment
                        param(5).Value = strType


                        SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdateBankCodesFromFile]", param)

                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                        conn.Dispose()

                    End Using
                Catch ex As Exception
                    MsgBox(ex.Message)
                    blnBcvlag = False
                End Try
                intRow += 1
                'Kobus 23/05/2014 voegby
                Me.lblProgress.Text = CStr(intRow - 1)
                Me.lblProgress.Refresh()
                blnBcvlag = True
            End If
        Loop
        'Kobus 23/05/2014 voegby
        If (xlSheet.Cells(intRow, 1).Text <> "" And xlSheet.Cells(intRow, 2).Text = "") Then
            blnBcvlag = False
        End If
        If (xlSheet.Cells(intRow, 1).Text = "" And xlSheet.Cells(intRow, 2).Text <> "") Then
            blnBcvlag = False
        End If

        xlBook.Close()
        xlApp.Quit()
        xlSheet = Nothing
        xlBook = Nothing
        xlApp = Nothing
        updateErrorList(True)
    End Sub
    'Update listbox with current error
    Private Sub updateErrorList(ByRef resetError As Boolean)
        If Err.Number <> 0 Then
            Me.listStatus.Items.Add("     !Attention: " & Err.Description)
            If resetError Then
                Err.Clear()
            End If
        Else
            Err.Clear()
        End If
    End Sub
    Private Sub txtPath_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPath.TextChanged
        Me.btnCancel.Enabled = True
        Me.btnOk.Enabled = True
        Me.lblUpdateResult.Text = ""
        Me.btnCancel.Text = "Cancel"
    End Sub
End Class