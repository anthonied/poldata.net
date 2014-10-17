Option Strict Off
Option Explicit On
Friend Class PtyCancl
    Inherits BaseForm
	
    ''Description  : Generate letter of notice for bank regarding the cancellation of a policy or property insurance.

    'Dim wApp As Microsoft.Office.Interop.Word.Application
    'Dim wDoc As Microsoft.Office.Interop.Word.Document
    ''UPGRADE_WARNING: Arrays in structure rs may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    'Dim rs As DAO.Recordset
    Dim descAfr As String
    Dim descEng As String
    'Dim xlapp As Microsoft.Office.Interop.Excel.Application
    'Dim xlbook As Microsoft.Office.Interop.Excel.Workbook
    'Dim xlsheet As Microsoft.Office.Interop.Excel.Worksheet
    'Dim xlRange As Microsoft.Office.Interop.Excel.Range
    Dim strAreaBranch As String

    Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        '	'UPGRADE_NOTE: Object xlapp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        '	xlapp = Nothing
        '	'UPGRADE_NOTE: Object xlbook may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        '	xlbook = Nothing
        '	'UPGRADE_NOTE: Object xlsheet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        '	xlsheet = Nothing


        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
        If Me.chkPrintAfr.Checked = False And Me.chkPrintEng.Checked = False Then
            MsgBox("Neem kennis: Geen kennisgewings brief gaan gedruk word nie.", MsgBoxStyle.Exclamation)
        Else
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            'When policy is cancelled get all properties involved else use selected property
            'If UCase(Form1.GEKANS.Text) = "JA" Then
            'rs = huis_e

            PtyCancelReportViewer.Show()
            'Get specified property item selected
            ' Form1.Grid2.col = 0
            'rs.Index = "PA_INDEX"
            'rs.Seek("=", Form1.POLISNO, Form1.Grid2.Text)
            'createLetter()
            ' Else
            'Get all the property items for this policy with homeloand organization other than 0
            ' rs = pol.OpenRecordset("SELECT * FROM huis WHERE polisno = '" & Form1.POLISNO.Text & "' AND fkHomeLoanOrg <> 0 AND cancelled = false")
            'If Not (rs.EOF And rs.BOF) Then
            ' Do While Not rs.EOF
            'createLetter()
            ' rs.MoveNext()
            ' Loop
            'End If
            ' End If
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Close()
    End Sub

    Private Sub chkPrintAfr_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkPrintAfr.CheckStateChanged
        If Me.chkPrintAfr.CheckState = 1 Then
            Me.chkPrintEng.CheckState = System.Windows.Forms.CheckState.Unchecked
        End If
    End Sub

    Private Sub chkPrintEng_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkPrintEng.CheckStateChanged
        If Me.chkPrintEng.CheckState = 1 Then
            Me.chkPrintAfr.CheckState = System.Windows.Forms.CheckState.Unchecked
        End If
    End Sub
    Private Sub PtyCancl_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.chkPrintAfr.CheckState = System.Windows.Forms.CheckState.Checked

        Me.Text = My.Application.Info.Title
    End Sub
    ''Create the letter in excel
    Public Sub createLetter()
        '	Dim message As Object
        '	Dim language As Byte
        '	Dim letterSubject As String
        '	Dim letterTitle As String
        '	Dim rownumber As Short
        '	Dim myArray As Object
        '	Dim i As Short
        '	Dim blnUserControl As Boolean


        '	System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        '	lblStatus.Text = "Laai Microsoft® Excel"
        '	Me.Refresh()

        '	letterhead_createExcelObject(xlapp, blnUserControl)
        '	xlbook = xlapp.Workbooks.Open(pol_path & "\docs\report.xls")
        '	xlsheet = xlbook.Worksheets(1)

        '	xlapp.DisplayAlerts = False


        '	Dim rsPersoonl As DAO.Recordset
        '	rsPersoonl = pol.OpenRecordset("SELECT * FROM persoonl where polisno = '" & Form1.POLISNO.Text & "'")

        '	Dim rsAreaBrief As DAO.Recordset
        '	rsAreaBrief = pol.OpenRecordset("SELECT * FROM area WHERE area_kode = '" & rsPersoonl.Fields("area").Value & "'")

        '	Dim rsMakelaarSql As DAO.Recordset
        '	rsMakelaarSql = pol.OpenRecordset("SELECT * FROM Makelaar where pkmakelaar = " & rsAreaBrief.Fields("fkmakelaar").Value)
        '	xlsheet.Shapes.AddPicture(getAdminPath & "Logo\" & rsMakelaarSql.Fields("Makelaar_logo").Value, True, True, ExcelGlobal_definst.Cells.Left, ExcelGlobal_definst.Cells.Top, 480, 70)
        '	'Set line
        '	letterhead_setLine(xlsheet, "A4", "L4")

        '	lblStatus.Text = "Genereer brief van kansellasie aan bank"
        '	Me.Refresh()

        '	If Me.chkPrintAfr.CheckState = 1 Then
        '		letterSubject = "KENNISGEWING KANSELLASIE - HUISEIENAARS"
        '		language = 0
        '		letterTitle = "Meneer / Mevrou"
        '	ElseIf Me.chkPrintEng.CheckState = 1 Then 
        '		letterSubject = "NOTICE OF CANCELLATION - HOUSE OWNERS "
        '		language = 1
        '		letterTitle = "Sir / Madam"
        '	End If

        '	letterhead_setStyle(xlsheet, 100, 12, language, False, (Form1.POLISNO).Text)

        '	strAreaBranch = Persoonl.Fields("area").Value

        '	letterhead_setBranch(xlsheet, language, 5, 12, strAreaBranch)

        '	letterhead_setAddress(xlsheet, 9, 3, language, UCase(gen_getPropertyHomeLoanOrg(language, (rs.Fields("fkHomeloanOrg").value))), "", "", "", "", "", "")

        '	letterhead_setSubject(xlsheet, 26, 12, language, letterSubject, (Form1.POLISNO).Text, letterTitle, "")

        '	'Header & footer
        '	If Persoonl.Fields("taal").Value = 0 Then
        '		xlsheet.PageSetup.RightFooter = "&6Bladsy &p van &n"
        '	Else
        '		xlsheet.PageSetup.RightFooter = "&6Page &p of &n"
        '	End If
        '	xlsheet.PageSetup.RightHeader = "&6 " & Form1.POLISNO.Text

        '	rownumber = 30

        '	'Insert information of policyholder
        '	With xlsheet.Range("A" & rownumber & ":A" & rownumber + 7)
        '		.Font.Bold = True
        '	End With

        '	'Set style for address
        '	With xlsheet.Range("F" & rownumber + 7 & ":L" & rownumber + 11)
        '		.Cells.Merge()
        '		.VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop
        '	End With

        '	If language = 0 Then

        '		xlsheet.Cells._Default(rownumber, "A").value = "U verwysing"

        '		xlsheet.Cells._Default(rownumber + 1, "A").value = "Datum"

        '		xlsheet.Cells._Default(rownumber + 2, "A").value = "Bankrekeningnommer"

        '		xlsheet.Cells._Default(rownumber + 3, "A").value = "Versekerde"

        '		xlsheet.Cells._Default(rownumber + 4, "A").value = "Polisnommer"

        '		xlsheet.Cells._Default(rownumber + 5, "A").value = "Bedrag verseker"

        '		xlsheet.Cells._Default(rownumber + 6, "A").value = "Maandelikse premie"

        '		xlsheet.Cells._Default(rownumber + 7, "A").value = "Risiko adres"
        '	Else

        '		xlsheet.Cells._Default(rownumber, "A").value = "Your reference"

        '		xlsheet.Cells._Default(rownumber + 1, "A").value = "Date"

        '		xlsheet.Cells._Default(rownumber + 2, "A").value = "Bank account number"

        '		xlsheet.Cells._Default(rownumber + 3, "A").value = "Insured"

        '		xlsheet.Cells._Default(rownumber + 4, "A").value = "Policy number"

        '		xlsheet.Cells._Default(rownumber + 5, "A").value = "Amount insured"

        '		xlsheet.Cells._Default(rownumber + 6, "A").value = "Monthly premium"

        '		xlsheet.Cells._Default(rownumber + 7, "A").value = "Risk address"
        '	End If

        '	'Build address

        '	message = "'" & rs.Fields("ADRES_H1").Value
        '	If Trim(rs.Fields("Adres4").Value) <> "" Then

        '		message = message & Chr(10) & rs.Fields("Adres4").Value
        '	End If
        '	If Trim(rs.Fields("Voorstad").Value) <> "" Then

        '		message = message & Chr(10) & rs.Fields("Voorstad").Value
        '	End If

        '	message = message & Chr(10) & rs.Fields("Dorp").Value & Chr(10) & rs.Fields("poskode").Value


        '	xlsheet.Cells._Default(rownumber, "F").value = ""

        '	xlsheet.Cells._Default(rownumber + 1, "F").value = "'" & VB6.Format(Now, "dd/mm/yyyy")

        '	xlsheet.Cells._Default(rownumber + 2, "F").value = "'" & rs.Fields("BondNumber").Value

        '	xlsheet.Cells._Default(rownumber + 3, "F").value = "'" & Form1.TITEL.Text & " " & Form1.VOORL.Text & " " & Form1.VERSEKERDE.Text

        '	xlsheet.Cells._Default(rownumber + 4, "F").value = "'" & Form1.POLISNO.Text

        '	xlsheet.Cells._Default(rownumber + 5, "F").value = "R " & rs.Fields("WAARDE_he").Value

        '	xlsheet.Cells._Default(rownumber + 6, "F").value = "R " & VB6.Format(rs.Fields("Premie_he").Value * CDbl(Form1.Combo1.Text), "####.##")


        '	xlsheet.Cells._Default(rownumber + 7, "F").value = message

        '	rownumber = rownumber + 13

        '	'Set the style of the letter introduction
        '	With xlsheet.Range("A" & rownumber & ":L" & rownumber)
        '		.Cells.Merge()
        '		.RowHeight = 49.5
        '		.VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop
        '		.HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlJustify
        '		.WrapText = True
        '	End With

        '	If language = 0 Then

        '		message = "Hierdie skrywe bevestig dat die bogemelde versekerde sy/haar versekeringspolis gekanselleer het."

        '		message = message & Chr(10) & Chr(10) & "Moet asseblief nie huiwer om met ons in verbinding te tree indien u enige verdere inligting benodig in die verband nie"

        '		xlsheet.Cells._Default(rownumber + 5, 1).value = "Die uwe"
        '	Else

        '		message = "This letter serves to confirm that the abovementioned insured has cancelled his/her insurance policy."

        '		message = message & Chr(10) & Chr(10) & "Kindly do not hesitate to contact us if you require any further information in this regard."

        '		xlsheet.Cells._Default(rownumber + 5, 1).value = "Yours faithfully"
        '	End If


        '	xlsheet.Cells._Default(rownumber, 1).value = message

        '	lblStatus.Text = "Brief van kansellasie aan bank is gedruk"
        '	Me.Refresh()

        '	System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        '	'Preview letter
        '	xlapp.Visible = True
        '	xlsheet.PrintPreview()
        '	xlbook.Close()
        '	xlapp.Quit()
    End Sub
End Class