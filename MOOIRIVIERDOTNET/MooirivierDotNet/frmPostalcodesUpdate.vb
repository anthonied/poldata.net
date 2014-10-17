Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports DAL
'Kobus 17/02/2014 voegby
Imports Excel = Microsoft.Office.Interop.Excel
Friend Class frmPostalcodesUpdate
	Inherits System.Windows.Forms.Form
	
	
    Dim intRow As Integer
    'Public pcvlag As Short
    'Kobus 17/02/2014 voegby
    Dim strFilename As String
    Dim strTown As String
    Dim strSuburb As String
    Dim strPostCode As String
    Dim strStreetCode As String
    
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
                MsgBox("you must select the specific file.", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If

        strFilename = Me.txtPath.Text

        Me.Label1.Visible = True

        Me.Label1.Text = "Number of Postal Codes updated:"
        Me.btnCancel.Enabled = False
        Me.btnOk.Enabled = False
        Me.btnBrowse.Enabled = False

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Me.listStatus.Visible = True '

        If updatePostalCodes() Then
            'Kobus 05/05/2014 verander van "Update is completed."
            Me.listStatus.Items.Add(("Postal Codes Update completed."))
            Me.Refresh()
            'Kobus 05/05/2014 verander van "Update is completed."
            Me.Cursor = System.Windows.Forms.Cursors.Default
            MsgBox("Postal codes update completed.", MsgBoxStyle.Information)

            Me.btnCancel.Enabled = True
            Me.btnOk.Enabled = True
            'Kobus 02/06/2014 voegby
            Me.Label1.Text = "Number of Postal Codes updated:"
            Me.btnCancel.Text = "Close"
            Me.btnOk.Enabled = False
            Me.listStatus.Visible = True
        Else
            Me.listStatus.Visible = True
            Me.listStatus.Items.Add(("Postal Codes Update failed."))
            Me.btnCancel.Enabled = True
            Me.Refresh()
            Me.Cursor = System.Windows.Forms.Cursors.Default
            'Kobus 02/06/2014 voegby
            Me.Label1.Visible = False
            Me.Text = "       Postal Codes Update"
            Me.btnBrowse.Enabled = True
            Me.txtPath.Text = ""
            Me.listStatus.Items.Add("Update the Postal Codes table")
            Me.Refresh()
            Me.lblProgress.Text = ""
            Me.btnCancel.Enabled = True
            Me.btnOk.Enabled = True
            Me.Label1.Text = ""
            Me.btnCancel.Text = "Cancel"
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If
    End Sub
    Private Function updatePostalCodes() As Boolean


        Dim blnTown As Boolean
        'Kobus 05/05/2014 verander van 1 na 2 (1 is heading)
        intRow = 1
        Dim xlApp As New Excel.Application
        Dim xlBook As Excel.Workbook
        Dim xlSheet As Excel.Worksheet
        'Andriette 15/08/2014 maak warnings reg
        ' Dim xlxBook As Excel.Workbook 


        If System.IO.File.Exists(strFilename) = True Then

            xlBook = xlApp.Workbooks.Open(strFilename)
            xlSheet = xlBook.Worksheets(1)
        Else
            MsgBox("File does not exist.", vbInformation)
            Return False
            Exit Function
        End If

        If xlSheet Is Nothing Then
            MsgBox("Windows could not open the file.", vbInformation)
            Return False
            Exit Function
        End If


        Do Until intRow = xlSheet.Rows.Count
            If xlSheet.Cells(intRow, 4).Text = "BLOEMFONTEIN" Or xlSheet.Cells(intRow, 1).Text = "WITBANK" Then
                blnTown = True
                Exit Do
            Else
                blnTown = False
            End If
            If intRow = 50 Then
                Exit Do
            End If
            intRow += 1
            lblProgress.Text = CStr(intRow)
            lblProgress.Refresh()
        Loop
        'Kobus 05/05/2014 verander van 1 na 2 (1 is heading)
        intRow = 1

        If blnTown = False Then
            MsgBox("The file chosen is not in the correct format. No information can be updated.  Please choose correct file.", vbInformation)
            Me.btnBrowse.Enabled = True
            Me.btnCancel.Enabled = True
            Me.btnOk.Enabled = True
            Me.txtPath.Text = ""
            Me.btnCancel.Text = "Cancel"
            Me.listStatus.Visible = True
            'Kobus 23/06/2014 voegby
            Me.listStatus.Items.Add("Wrong file selected")
            Refresh()
            Return False
            Exit Function
        End If

        'Remove all data in table
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@Dorp", SqlDbType.NVarChar), _
                                                       New SqlParameter("@Voorstad", SqlDbType.NVarChar), _
                                                       New SqlParameter("@Poskode", SqlDbType.NVarChar), _
                                                       New SqlParameter("@Foutboodskap", SqlDbType.NVarChar), _
                                                       New SqlParameter("@pcidnum", SqlDbType.Int), _
                                                       New SqlParameter("@crestazone", SqlDbType.Int), _
                                                       New SqlParameter("@PoskodePosbus", SqlDbType.NVarChar), _
                                                       New SqlParameter("@Tipe", SqlDbType.NVarChar)}

                param(0).Value = ""
                param(1).Value = ""
                param(2).Value = ""
                param(3).Value = ""
                param(4).Value = 0
                param(5).Value = 0
                param(6).Value = ""
                param(7).Value = "Delete"

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdatePoskodesFromFile]", param)

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If

            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        'Insert new data into table
        intRow = 1
        'Kobus 02/06/2014 voegby
        Dim strAll As String
        strAll = Trim(xlSheet.Cells(intRow, 1).Text) & Trim(xlSheet.Cells(intRow, 2).Text) & Trim(xlSheet.Cells(intRow, 3).Text) & Trim(xlSheet.Cells(intRow, 4).Text)
        'Kobus 02/06/2014 verander van Do While Trim(xlSheet.Cells(intRow, 1).Text) <> "" na
        Do While strAll <> ""
            strAll = Trim(xlSheet.Cells(intRow, 1).Text) & Trim(xlSheet.Cells(intRow, 2).Text) & Trim(xlSheet.Cells(intRow, 3).Text) & Trim(xlSheet.Cells(intRow, 4).Text)
            If strAll = "" Then
                Exit Do
            End If
            'Kobus 02/06/2014 verander van  net "SUBURB" na or > 4
            If UCase(xlSheet.Cells(intRow, 1).Text) = "SUBURB" Or xlSheet.Cells(intRow, 2).text.Trim.Length > 4 Or xlSheet.Cells(intRow, 3).Text.Trim.Length > 4 Then  'Kolomopskrifte word herhaal per bladsy
                'intRow += 1
            Else
                strSuburb = Trim(xlSheet.Cells(intRow, 1).value)
                'Kobus 02/06/2014 voegby
                If strSuburb = "" Then
                    MsgBox("Suburb field cannot be empty.", MsgBoxStyle.Exclamation)
                    Return False
                    updateErrorList(True)
                    Exit Function
                End If
                strPostCode = Trim(xlSheet.Cells(intRow, 2).value)
                strStreetCode = Trim(xlSheet.Cells(intRow, 3).value)
                strTown = Trim(xlSheet.Cells(intRow, 4).value)


                Try
                    Using conn As SqlConnection = SqlHelper.GetConnection
                        Dim param() As SqlParameter = {New SqlParameter("@Dorp", SqlDbType.NVarChar), _
                                                       New SqlParameter("@Voorstad", SqlDbType.NVarChar), _
                                                       New SqlParameter("@Poskode", SqlDbType.NVarChar), _
                                                       New SqlParameter("@Foutboodskap", SqlDbType.NVarChar), _
                                                       New SqlParameter("@pcidnum", SqlDbType.Int), _
                                                       New SqlParameter("@crestazone", SqlDbType.Int), _
                                                       New SqlParameter("@PoskodePosbus", SqlDbType.NVarChar), _
                                                       New SqlParameter("@Tipe", SqlDbType.NVarChar)}

                        'Kobus 26/05/2014 voegby
                        If Trim(strTown) = "" Or Trim(strTown) = "-" Then
                            strTown = strSuburb
                        End If
                        param(0).Value = strTown
                        param(1).Value = strSuburb
                        'Kobus 02/06/2014 comment out en voegby
                        strStreetCode = strStreetCode.Trim
                        If strStreetCode = "" Then
                            'Dont't change

                        Else
                            strStreetCode = strStreetCode.PadLeft(4, "0")
                        End If

                        param(2).Value = strStreetCode
                        param(3).Value = ""
                        param(4).Value = 0
                        param(5).Value = 0
                        'Kobus 02/06/2014 comment out en voegby
                        strPostCode = strPostCode.Trim
                        If strPostCode = "" Then
                            'Dont't change
                        Else
                            strPostCode = strPostCode.PadLeft(4, "0")
                        End If

                        param(6).Value = strPostCode
                        param(7).Value = "Insert"

                        SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdatePoskodesFromFile]", param)

                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If

                    End Using
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return False
                End Try

                updateErrorList(True)

            End If ' = "SUBURB"
            intRow += 1
            lblProgress.Text = CStr(intRow)
            lblProgress.Refresh()
        Loop

        xlBook.Close()
        xlApp.Quit()
        xlSheet = Nothing
        xlBook = Nothing
        xlApp = Nothing


        updateErrorList(True)

        'Kobus 17/2/2014 verander van Me.Label1.Text = "Verifieer data"
        Me.Label1.Text = "Number of Postal Codes updated:"
        Me.lblProgress.Text = intRow - 1
        Cursor = System.Windows.Forms.Cursors.Default
        Return True


    End Function
    'Update listbox with current error
    'Andriette 15/08/2014 maak warnings reg
    '  Public Function updateErrorList(ByRef resetError As Boolean) As Object
    Private Sub updateErrorList(ByRef resetError As Boolean)
        If Err.Number <> 0 Then
            Me.listStatus.Items.Add("     !Attention: " & Err.Description)
            Me.Refresh()
            If resetError Then
                Err.Clear()
            End If
        End If
    End Sub
    Private Sub frmPostalcodesUpdate_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Label1.Visible = False
        'Kobus 26/05/2014 voegby
        Me.Label2.Text = "Update the Postal Codes table"

        Me.Text = "       Postal Codes Update"
        Me.btnBrowse.Enabled = True 'k
        Me.txtPath.Text = ""  'k
        Me.listStatus.Visible = True
        Me.listStatus.Items.Clear()
        Me.listStatus.Items.Add("Update the Postal Codes table")
        Me.lblProgress.Text = ""  'k
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