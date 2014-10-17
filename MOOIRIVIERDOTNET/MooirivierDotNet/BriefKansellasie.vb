Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Data.SqlClient
Imports DAL
Friend Class BriefKansellasie
    Inherits BaseForm
	
	'Description: Print a Cancellation letter
	Dim sSql As String
    'Dim xlapp As Microsoft.Office.Interop.Excel.Application
    'Dim xlbook As Microsoft.Office.Interop.Excel.Workbook
    'Dim xlsheet As Microsoft.Office.Interop.Excel.Worksheet
	Dim rownumber As Short
	Dim strAreaBranch As String
	
	Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click
        'xlapp = Nothing
        'xlbook = Nothing
        'xlsheet = Nothing
		
		Me.Close()
	End Sub
	
	Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
        'BriefKansellasieReportViewer.Show()
        Huis_EF.ShowDialog()
        'createLetter()
	End Sub
	
	Public Sub createLetter()
        'Dim attachList As Object
        'Dim message As Object
        'Dim cancelDesc As Object
        'Dim rs As Object
        'Dim language As Object
        'Dim rsMakelaarSql As Object
        'Dim rsAreaBrief As Object
        'Dim dbPoldata As Object
        'Dim letterSubject As String
        'Dim MonthName_Renamed As String
        'Dim blnUserControl As Boolean
        'Dim tempFilename As String

        ''Destination = email
        'If Me.rdEpos.Checked Then
        '	System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '	If emailEngine.signOn Then
        '              'emailEngine.txtTo.Text = Persoonl.Fields("email").Value & ""
        '		emailEngine.ShowDialog()

        '		'If cancel was clicked - abort process else continue
        '		If Not emailEngine.returnValue Then
        '			emailEngine.signOff()
        '			emailEngine.Close()
        '			Exit Sub
        '		End If
        '	Else
        '		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '		Exit Sub
        '	End If
        'End If

        'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        'lblStatus.Text = "Laai Microsoft® Excel"

        '      'letterhead_createExcelObject(xlapp, blnUserControl)
        'xlbook = xlapp.Workbooks.Open("c:\polis5\docs\report.xls")
        'xlsheet = xlbook.Worksheets(1)

        'xlapp.DisplayAlerts = False

        '      'dbPoldata = DAODBEngine_definst.OpenDatabase(pol_path & "\poldata5.mdb")
        ' 'rsAreaBrief = dbPoldata.OpenRecordset("SELECT * FROM area WHERE area_kode = '" & Persoonl.Fields("area").Value & "'")

        'rsMakelaarSql = dbPoldata.OpenRecordset("SELECT * FROM Makelaar where pkmakelaar = " & rsAreaBrief("fkmakelaar"))
        ' 'xlsheet.Shapes.AddPicture(getAdminPath & "Logo\" & rsMakelaarSql("Makelaar_logo"), True, True, ExcelGlobal_definst.Cells.Left, ExcelGlobal_definst.Cells.Top, 480, 70)

        'lblStatus.Text = "Genereer kansellasiebrief"
        'Me.Refresh()

        '      'If Persoonl.Fields("taal").Value = 0 Then
        '      letterSubject = "KANSELLASIE VAN POLIS"
        '      'Else
        '      letterSubject = "CANCELLATION OF POLICY"
        '      'End If

        '      'letterhead_setStyle(xlsheet, 100, 12, Persoonl.Fields("taal").Value, False, Persoonl.Fields("polisno").Value)

        '      'strAreaBranch = Persoonl.Fields("area").Value

        '      'letterhead_setBranch(xlsheet, Persoonl.Fields("taal").Value, 5, 12, strAreaBranch)

        '      'If Persoonl.Fields("posbestemming").Value = "2" Then 'University
        '      'letterhead_setAddress(xlsheet, 9, 3, Persoonl.Fields("taal").Value, gen_getTitleDesc(Persoonl.Fields("taal").Value, Persoonl.Fields("titelnum").Value), Persoonl.Fields("voorl").Value, Persoonl.Fields("versekerde").Value, "Posvakkie " & Persoonl.Fields("pos_vakkie").Value & "", "", "", "")
        '      ' Else
        '      'letterhead_setAddress(xlsheet, 9, 3, Persoonl.Fields("taal").Value, gen_getTitleDesc(Persoonl.Fields("taal").Value, Persoonl.Fields("titelnum").Value), Persoonl.Fields("voorl").Value, Persoonl.Fields("versekerde").Value, Persoonl.Fields("adres").Value & "", Persoonl.Fields("adres4").Value & "", Persoonl.Fields("adres3").Value & "", Persoonl.Fields("adres2").Value & "")
        '      'End If
        '      'letterhead_setSubject(xlsheet, 26, 12, Persoonl.Fields("taal").Value, letterSubject, Persoonl.Fields("polisno").Value, gen_getTitleDesc(Persoonl.Fields("taal").Value, Persoonl.Fields("titelnum").Value), Persoonl.Fields("versekerde").Value, True)

        '      'Set line
        '      'letterhead_setLine(xlsheet, "A4", "L4")

        '      'Footer - overide the footer set with letterhead_setStyle
        '       If language = 0 Then
        '          xlsheet.PageSetup.RightFooter = "&6Bladsy &p van &n"
        '      Else
        '          xlsheet.PageSetup.RightFooter = "&6Page &p of &n"
        '      End If
        '      'xlsheet.PageSetup.RightHeader = "&6 " & gen_getTitleDesc(Persoonl.Fields("taal").Value, Persoonl.Fields("titelnum").Value) & ". " & Persoonl.Fields("voorl").Value & " " & Persoonl.Fields("versekerde").Value & " (" & Persoonl.Fields("polisno").Value & ")"

        '      rownumber = 31

        '      'Set the style of the letter introduction
        '      With xlsheet.Range("A" & rownumber + 2 & ":L" & rownumber + 2)
        '          .Cells.Merge()
        '          .RowHeight = 24.75
        '          .VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop
        '          .HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlJustify
        '          .WrapText = True
        '      End With

        '      With xlsheet.Range("A" & rownumber & ":L" & rownumber)
        '          .Cells.Merge()
        '          .RowHeight = 24.75
        '          .VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop
        '          .HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlJustify
        '          .WrapText = True
        '      End With

        '      ' MonthName_Renamed = gen_getMonthName(Persoonl.Fields("taal").Value, CByte(VB6.Format(Me.DTPicker1.Value, "mm"))) & " " &Format(Me.DTPicker1.Value, "yyyy")

        '      'sSql = "SELECT beskrywingafrikaans, beskrywingengels FROM persoonl LEFT JOIN kansellasieRedes ON persoonl.fkKansellasieRedes = kansellasieRedes.pkKansellasieRedes"
        '      'sSql = sSql & " WHERE polisno = '" & Persoonl.Fields("polisno").Value & "'"
        '      'rs = pol.OpenRecordset(sSql)

        '      If Not (rs.EOF And rs.BOF) Then
        '          ' If Persoonl.Fields("taal").Value = 0 Then
        '          cancelDesc = rs("beskrywingAfrikaans")
        '      Else
        '          cancelDesc = rs("beskrywingEngels")
        '      End If
        '      'Else
        '        cancelDesc = ""
        '      'End If

        '      'If Persoonl.Fields("taal").Value = 0 Then
        '       xlsheet.Cells._Default(rownumber, 1).value = "Ons verwys na bogenoemde polis en bevestig die kansellasie van die polis op grond van: " & cancelDesc & "."
        '       message = "Die polis sal dus dekking verleen tot en met 24h00 op " & Me.DTPicker1.Value
        '       message = message & " en geen debietorder sal in die toekoms teenoor u bankrekening aangebied word nie."
        '       xlsheet.Cells._Default(rownumber + 2, 1).value = message

        '       xlsheet.Cells._Default(rownumber + 4, 1).value = "Indien u die polis wil herstel moet u asseblief met ons in verbinding tree."

        '      xlsheet.Cells._Default(rownumber + 4, 1).value = "Die uwe"
        '      'Else
        '       xlsheet.Cells._Default(rownumber, 1).value = "With reference to the above policy, we wish to advise you that the policy has been cancelled due to: " & cancelDesc & "."
        '       message = "Cover will be effective until 24h00 on " & Me.DTPicker1.Value & ". "
        '      'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      message = message & "No debit order will be presented to your bank for payment thereafter."
        '       xlsheet.Cells._Default(rownumber + 2, 1).value = message

        '       xlsheet.Cells._Default(rownumber + 4, 1).value = "Should you wish to reinstate this policy, kindly contact us in this regard."

        '       xlsheet.Cells._Default(rownumber + 4, 1).value = "Yours faithfully"
        '      'End If

        '      'Printer / Email
        '      If Me.rdDrukker.Checked Then 'Print
        '          'Arhive document
        '          'gen_ArchiveDocument(xlbook, 1, Persoonl.Fields("polisno").Value, 5, "", "", "", "")

        '          'Preview letter
        '          xlapp.Visible = True
        '          xlsheet.PrintPreview()
        '      ElseIf Me.rdEpos.Checked Then  'Email
        '           'gen_ArchiveDocument(xlbook, 1, Persoonl.Fields("polisno").Value, 5, (emailEngine.txtSubject).Text, (emailEngine.txtTo).Text, (emailEngine.txtBody).Text, CStr(attachList), tempFilename)

        '          'email file as attachment
        '          emailEngine.sendMail((emailEngine.txtTo).Text, (emailEngine.txtSubject).Text, (emailEngine.txtBody).Text, tempFilename)
        '      End If

        '      'If the document was emailed - sign-off
        '      If Me.rdEpos.Checked Then
        '          emailEngine.signOff()
        '          emailEngine.Close()
        '      End If

        '      xlbook.Close()
        '      xlapp.Quit()

        '      lblStatus.Text = "Kansellasiebrief is gedruk\ge-epos"
        '      Me.Refresh()
        '       System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        '      'Close form
        '      btnClose_Click(btnClose, New System.EventArgs())
    End Sub

    Private Sub BriefKansellasie_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        'If Not Persoonl.GEKANS Then
        '    If MsgBox("The policy must first be canceled for a return letter to print.", MsgBoxStyle.Exclamation, "Form Closing") = MsgBoxResult.Cancel Then
        '        Me.Close()
        '    End If

        'End If

    End Sub

    Private Sub BriefKansellasie_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        'Set the default values for the datepicker
        Me.dtpLastDayOfCoverage.MinDate = DateAdd(Microsoft.VisualBasic.DateInterval.Month, -6, Now)
        Me.dtpLastDayOfCoverage.MaxDate = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 6, Now)
        If IsDBNull(Persoonl.DatumEffekGekans) Then
            Me.dtpLastDayOfCoverage.Value = Format(Now, "yyyy-MM-dd")
            Me.dtpLastDayOfCoverage.Value = DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, DateAdd(Microsoft.VisualBasic.DateInterval.Day, 0 - (dtpLastDayOfCoverage.Value.Day - 1), dtpLastDayOfCoverage.Value)))
        Else
            Me.dtpLastDayOfCoverage.Value = Persoonl.DatumEffekGekans
            Me.dtpLastDayOfCoverage.Enabled = False
        End If
        Me.Text = My.Application.Info.Title & " -Letters - Cancellation"


        If Not Persoonl.GEKANS Then
            MsgBox("The policy must first be canceled for a return letter to print.", MsgBoxStyle.Exclamation, "Form Closing")
            Me.Close()
        End If
    End Sub


End Class