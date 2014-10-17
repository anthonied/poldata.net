Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class BriefKontant
	Inherits System.Windows.Forms.Form
	
	'Description: Print a Cancellation letter
	Dim sSql As String
    'Dim xlapp As Microsoft.Office.Interop.Excel.Application
    'Dim xlbook As Microsoft.Office.Interop.Excel.Workbook
    'Dim xlsheet As Microsoft.Office.Interop.Excel.Worksheet
	Dim rownumber As Short
	Dim strAreaBranch As String
	
	Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click
		'UPGRADE_NOTE: Object xlapp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'xlapp = Nothing
		'UPGRADE_NOTE: Object xlbook may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'xlbook = Nothing
		'UPGRADE_NOTE: Object xlsheet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'xlsheet = Nothing
		
		Me.Close()
	End Sub
	
	Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
        'If validateForm Then
        'createLetter()
        'End If
        BriefKontantReportViewe.Show()
	End Sub
	
	Public Sub createLetter()
        'Dim message As Object
        'Dim dateOffered As Object
        'Dim language As Object
        'Dim rsMakelaarSql As Object
        'Dim rsAreaBrief As Object
        'Dim dbPoldata As Object
        'Dim letterSubject As String
        ''UPGRADE_NOTE: MonthName was upgraded to MonthName_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        'Dim MonthName_Renamed As String
        'Dim blnUserControl As Boolean
		'UPGRADE_WARNING: Arrays in structure rsAreaInfo may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        'Dim rsAreaInfo As DAO.Recordset

        ''UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        'lblStatus.Text = "Laai Microsoft® Excel"

        'letterhead_createExcelObject(xlapp, blnUserControl)
        'xlbook = xlapp.Workbooks.Open("c:\polis5\docs\report.xls")
        'xlsheet = xlbook.Worksheets(1)

        'xlapp.DisplayAlerts = False

        'lblStatus.Text = "Genereer aanmaningsbrief"
        'Me.Refresh()

        'dbPoldata = DAODBEngine_definst.OpenDatabase(pol_path & "\poldata5.mdb")
        ''UPGRADE_WARNING: Couldn't resolve default property of object dbPoldata.OpenRecordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'rsAreaBrief = dbPoldata.OpenRecordset("SELECT * FROM area WHERE area_kode = '" & Persoonl.Fields("area").Value & "'")

        ''UPGRADE_WARNING: Couldn't resolve default property of object rsAreaBrief(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object dbPoldata.OpenRecordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'rsMakelaarSql = dbPoldata.OpenRecordset("SELECT * FROM Makelaar where pkmakelaar = " & rsAreaBrief("fkmakelaar"))
        ''UPGRADE_WARNING: Couldn't resolve default property of object rsMakelaarSql(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Shapes.AddPicture(getAdminPath & "Logo\" & rsMakelaarSql("Makelaar_logo"), True, True, ExcelGlobal_definst.Cells.Left, ExcelGlobal_definst.Cells.Top, 480, 70)

        'If Persoonl.Fields("taal").Value = 0 Then
        '	letterSubject = "ONBETAALDE PREMIE"
        'Else
        '	letterSubject = "UNPAID PREMIUM"
        'End If

        'letterhead_setStyle(xlsheet, 100, 12, Persoonl.Fields("taal").Value, False, Persoonl.Fields("polisno").Value)

        'strAreaBranch = Persoonl.Fields("area").Value

        'letterhead_setBranch(xlsheet, Persoonl.Fields("taal").Value, 5, 12, strAreaBranch)

        'letterhead_setAddress(xlsheet, 9, 3, Persoonl.Fields("taal").Value, gen_getTitleDesc(Persoonl.Fields("taal").Value, Persoonl.Fields("titelnum").Value), Persoonl.Fields("voorl").Value, Persoonl.Fields("versekerde").Value, Persoonl.Fields("adres").Value & "", Persoonl.Fields("adres4").Value & "", Persoonl.Fields("adres3").Value, Persoonl.Fields("adres2").Value)

        'letterhead_setSubject(xlsheet, 26, 12, Persoonl.Fields("taal").Value, letterSubject, Persoonl.Fields("polisno").Value, gen_getTitleDesc(Persoonl.Fields("taal").Value, Persoonl.Fields("titelnum").Value), Persoonl.Fields("versekerde").Value, True)

        ''Set line
        'letterhead_setLine(xlsheet, "A4", "L4")

        ''Footer - overide the footer set with letterhead_setStyle
        ''UPGRADE_WARNING: Couldn't resolve default property of object language. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If language = 0 Then
        '	xlsheet.PageSetup.RightFooter = "&6Bladsy &p van &n"
        'Else
        '	xlsheet.PageSetup.RightFooter = "&6Page &p of &n"
        'End If
        'xlsheet.PageSetup.RightHeader = "&6 " & gen_getTitleDesc(Persoonl.Fields("taal").Value, Persoonl.Fields("titelnum").Value) & ". " & Persoonl.Fields("voorl").Value & " " & Persoonl.Fields("versekerde").Value & " (" & Persoonl.Fields("polisno").Value & ")"

        'rownumber = 31

        ''Set the style of the letter introduction
        'With xlsheet.Range("A" & rownumber & ":L" & rownumber)
        '	.Cells.Merge()
        '	.RowHeight = 24.75
        '	.VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop
        '	.HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlJustify
        '	.WrapText = True
        'End With

        'MonthName_Renamed = gen_getMonthName(Persoonl.Fields("taal").Value, CByte(VB6.Format(Me.DTPicker1.value, "mm")))
        ''UPGRADE_WARNING: Couldn't resolve default property of object dateOffered. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'dateOffered = MonthName_Renamed & " " &Format(Me.DTPicker1.value, "yyyy")

        ''Letter introduction
        'If Persoonl.Fields("taal").Value = 0 Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	message = "Met betrekking tot bogenoemde polis wil ons u in kennis stel dat die premie ten bedrae van"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object dateOffered. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	message = message & " R " &Format(txtPremie.Text, "0.00") & " wat betaalbaar was vir " & dateOffered & " nog nie ontvang is nie."

        'Else
        '	'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	message = "With reference to the above policy, we wish to advise you that the premium to the amount of"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object dateOffered. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	message = message & " R " &Format(txtPremie.Text, "0.00") & " that was due and payable for " & dateOffered & " was not received by us."

        'End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 1).value = message

        'rownumber = rownumber + 2

        'If Persoonl.Fields("taal").Value = 0 Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	message = "U het 'n 15 dae grasie tydperk vanaf die datum waarop die premie betaalbaar was om die premie te betaal."
        '	'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	message = message & "  Indien u in gebreke bly sal daar geen dekking wees nie.  Die inbetaling(s) op die uitstaande bedrag(e)"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	message = message & " kan direk by ons kantoor inbetaal word of andersins kan u die betaling per pos aanstuur na ons posadres,"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	message = message & " op voorwaarde dat die betaling ons bereik binne die grasie tydperk.  Indien u sou verkies om die betaling elektronies oor te betaal, is ons bank besonderhede as volg:"
        'Else
        '	'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	message = "You have a grace period of 15 days, from the date upon which the premium became due, within which you must pay the premium, "
        '	'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	message = message & "failing to will result in you having no cover.  Payment(s) of the outstanding premium can be paid "
        '	'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	message = message & "at our office or alternatively, you may submit payment to our postal address, on condition that we receive payment within the grace period mentioned above.  Electronic payment(s) can also be paid into"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	message = message & " the following account: "
        'End If

        'With xlsheet.Range("A" & rownumber & ":L" & rownumber)
        '	.Cells.Merge()
        '	.RowHeight = 51
        '	.VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop
        '	.WrapText = True
        '	.HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlJustify
        'End With

        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 1).value = message

        'rownumber = rownumber + 4

        'With xlsheet.Range("B" & rownumber & ":D" & rownumber + 4)
        '	.Font.Bold = True
        '	.RowHeight = 11
        'End With

        'If Persoonl.Fields("taal").Value = 0 Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 2).value = "U polisnommer moet asseblief as verwysing gebruik word."
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 2, 2).value = "Bank/bouvereniging:"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 3, 2).value = "Takkode:"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 4, 2).value = "Rekeningnommer:"
        'Else
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 2).value = "Please state your policy number as reference."
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 2, 2).value = "Bank/building society:"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 3, 2).value = "Branch code:"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 4, 2).value = "Account number:"
        'End If

        'rsAreaInfo = pol.OpenRecordset("SELECT * FROM area WHERE area_kode in " &  Gebruiker.BranchCodes & " AND area_kode = '" & Persoonl.Fields("area").Value & "'")

        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 2, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 2, 5).value = rsAreaInfo.Fields("tak_bankbouv").Value
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 3, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 3, 5).value = "'" & rsAreaInfo.Fields("tak_takkode").Value
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 4, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 4, 5).value = "'" & rsAreaInfo.Fields("tak_rekeningnr").Value

        'rownumber = rownumber + 6

        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 1).Font.Bold = True
        'With xlsheet.Range("A" & rownumber + 1 & ":L" & rownumber + 1)
        '	.Cells.Merge()
        '	.RowHeight = 75
        '	.VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop
        '	.WrapText = True
        '	.HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlJustify
        'End With

        'If Persoonl.Fields("taal").Value = 0 Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 1).value = "Neem kennis:"

        '	'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	message = "Ons is onder geen verpligting om enige premie wat na 15 dae vanaf die betaaldatum getender word te aanvaar nie."
        '	'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	message = message & "  Enige premie wat na hierdie datum aanvaar word sal sonder benadeling van ons of die versekeraar se regte aanvaar word en met die voorbehoud dat dekking eers sal"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	message = message & " hervat na die ontvangs van die premie. Daar sal geen dekking wees vanaf die betaaldatum tot en met die datum"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	message = message & " van ontvangs van premie nie."
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 5, 1).value = "Die uwe"
        'Else
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 1).value = "Kindly take note that:"

        '	'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	message = "We are not obliged to accept any premium tendered to us later than 15 days after the date upon which the premium became due.  "
        '	'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	message = message & "Any premium accepted after such date will be subject to the condition that cover will only apply from the date the premium was"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	message = message & " accepted onwards. There will be no cover from the due date to the premium"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	message = message & " acceptance date."
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 5, 1).value = "Yours faithfully"
        'End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 1, 1).value = message

        'lblStatus.Text = "Aanmaningsbrief"
        'Me.Refresh()
        ''UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        ''Arhive document
        'gen_ArchiveDocument(xlbook, 1, Persoonl.Fields("polisno").Value, 6, "", "", "", "")

        ''Preview letter
        'xlapp.Visible = True
        'xlsheet.PrintPreview()
        'xlbook.Close()
        'xlapp.Quit()
		
		'Close form
		btnClose_Click(btnClose, New System.EventArgs())
	End Sub
	'Check form
	Public Function validateForm() As Boolean
		
		'Check premium
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Trim(txtPremie.Text) = "" Or IsDbNull(txtPremie.Text) Then
			validateForm = False
            MsgBox("Please complete the premium.", MsgBoxStyle.Exclamation)
			Me.txtPremie.Focus()
			Exit Function
		End If
		
		If Not IsNumeric(txtPremie.Text) Then
			validateForm = False
            MsgBox("The premium must be a number, be.", MsgBoxStyle.Exclamation)
			Me.txtPremie.Focus()
			Exit Function
		End If
		
		validateForm = True
	End Function
	Private Sub BriefKontant_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		txtPremie.Text = Form1.Premie2.Text
		
		'Set the default values for the datepicker
		Me.DTPicker1.MinDate = DateAdd(Microsoft.VisualBasic.DateInterval.Month, -6, Now)
		Me.DTPicker1.MaxDate = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 6, Now)
		Me.DTPicker1.CustomFormat = "01 MMMM yyyy"
		Me.DTPicker1.value = Now
		Me.DTPicker1.CustomFormat = "01 MMMM yyyy"
		
        Me.Text = My.Application.Info.Title & " - Letters - Cash / Electronic warning"
	End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub txtPremie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPremie.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If Char.IsDigit(e.KeyChar) Then
                'Do nothing
            Else
                e.Handled = True
                MsgBox("The premium value must be numeric", MsgBoxStyle.Information, "Validating the premium")
                txtPremie.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtPremie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPremie.TextChanged

    End Sub
End Class