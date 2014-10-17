Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Data.SqlClient
Imports DAL
Imports System.IO
Imports Microsoft.Reporting.WinForms
Imports System.Net
Imports System.Configuration

Friend Class BriefVT
    Inherits BaseForm

    'Description: Print a 'VT' letter
    Dim sSql As String
    'Dim xlapp As Microsoft.Office.Interop.Excel.Application
    'Dim xlbook As Microsoft.Office.Interop.Excel.Workbook
    'Dim xlsheet As Microsoft.Office.Interop.Excel.Worksheet
    Dim rownumber As Short
    'Dim dbPoldata As DAO.Database
    Dim strAreaBranch As String
    Public result As Byte() = Nothing
    Dim tempFilename As String

    Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click

        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click


        If rdEpos.Checked Then

            If emailEngine.signOn Then
                emailEngine.txtTo.Text = Persoonl.EMAIL
                emailEngine.ShowDialog()

                'If cancel was clicked - abort process else continue
                If Not emailEngine.returnValue Then
                    emailEngine.signOff()
                    emailEngine.Close()
                    Exit Sub
                End If
            End If
            If rdDrukker.Checked Then
                CreateReportFile()
                gen_ArchiveDocument(result, Persoonl.POLISNO, 8, "", "", "", "")
            ElseIf rdEpos.Checked Then
                CreateReportFile()
                gen_ArchiveDocument(result, Persoonl.POLISNO, 8, emailEngine.txtSubject.Text, emailEngine.txtTo.Text, emailEngine.txtBody.Text, getAttachmentsForEmailEngine, tempFilename)
                emailEngine.sendMail(emailEngine.txtTo.Text, emailEngine.txtSubject.Text, emailEngine.txtBody.Text, tempFilename)
            End If
            Exit Sub
        Else
            Brief_VTDetailReportViewer.Show()
            Exit Sub
        End If
        'End If

        'Catch ex As Exception

        ' End Try

        'Else
        '	MsgBox("Daar moet 'n VT gekies wees om 'n brief te druk", MsgBoxStyle.Exclamation)
        'End If
    End Sub
    Sub CreateReportFile()
        Dim detailStream As Stream
        detailStream = createDetailFile("/Mooirivier/BriefVT")
    End Sub
    Public Function createDetailFile(ByVal reportPath As String) As Stream
        Dim stream As MemoryStream = Nothing
        Dim rview = New ReportViewer
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing
        Try
            Try
                'MyReportViewer.ServerReport.ReportServerCredentials =  = New MyReportServerCredentials()
                rview.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)

            Catch ex As Exception
                MsgBox("The ReportServer is unavailable at this moment. Try again later.")
            End Try

            rview.ServerReport.ReportServerUrl = New Uri(ConfigurationManager.AppSettings("ReportPath"))

            'begin params specific
            Dim premie As String
            Dim DateOffered As String

            DateOffered = BriefVTGrid1.SelectedRows(0).Cells(1).Value
            premie = BriefVTGrid1.SelectedRows(0).Cells(3).Value

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", Persoonl.POLISNO), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("LANGUAGE", Persoonl.TAAL), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", Persoonl.TAAL), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("DateOffered", DateOffered), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("GebruikerBranhCode", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Premie", premie)}


            'end params specific

            rview.ServerReport.ReportPath = reportPath
            rview.ServerReport.SetParameters(params)

            Dim encoding As String = ""
            Dim mimeType As String = ""
            Dim warnings As Microsoft.Reporting.WinForms.Warning() = Nothing
            Dim streamIDs As String() = Nothing
            Dim extension As String = ""
            Dim format As String = "PDF" '//Desired format goes here (PDF, Excel, or Image)
            Dim deviceInfo As String = "<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>"

            result = rview.ServerReport.Render(format, deviceInfo, mimeType, encoding, extension, streamIDs, warnings)

            stream = New MemoryStream(result.Length)
            stream.Write(result, 0, result.Length)

            Return stream
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub BriefVT_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'UPGRADE_ISSUE: Data property DataVT.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'TODO ____
        'DataVT.DatabaseName = pol_path & "\stats5.mdb"
        '_________
        'Andriette 16/08/2013 gebruik die global polisnommer
        '        If Trim(Form1.POLISNO.Text) = "" Then
        If Trim(glbPolicyNumber) = "" Then
            MsgBox("First, select a policy for which the VT letter must be printed.", MsgBoxStyle.Exclamation)
            Me.Close()
        End If
        BriefVTGrid1.AutoGenerateColumns = False
        BriefVTGrid1.DataSource = PopulatesBriefVT()
        BriefVTGrid1.Refresh()
        'Select first row of grid (headings)
        'GridVT.row = 1
        BriefVTGrid1.ReadOnly = True
        BriefVTGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        'Column widths
        'GridVT.set_ColWidth(0, 0) 'Polisnommer
        'GridVT.set_ColWidth(1, 1500) 'Aangebied
        'GridVT.set_ColWidth(2, 1000) 'VT Datum
        'GridVT.set_ColWidth(3, 5000) 'Beskrywing
        'GridVT.set_ColWidth(4, 1000) 'Bedrag
        'GridVT.set_ColWidth(5, 570) 'Krities
        'GridVT.set_ColWidth(6, 0) 'Beskrywing engels
        'GridVT.set_ColWidth(7, 0) 'Maand
        'GridVT.set_ColWidth(8, 0) 'Jaar

        'sSql = "SELECT polisno, jaar&maand as [Datum aangebied], vt_datum as [VT Datum], beskrywingAfr as [Beskrywing], vt_bedrag as [Bedrag(R)], abs(x) as [Krities], beskrywingEng,maand, jaar FROM maand_vt_details "
        'sSql = sSql & " LEFT JOIN VTRedes ON VTRedes.kode = maand_vt_details.vt_kode"
        'sSql = sSql & " WHERE polisno = '" & Form1.POLISNO.Text & "'"
        'sSql = sSql & " ORDER BY jaar, maand"

        'UPGRADE_ISSUE: Data property DataVT.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'TODO ____
        'DataVT.RecordSource = sSql
        '________
        'DataVT.Refresh()
        'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        'TODO ____
        'GridVT.CtlRefresh()
        '______
        'GridVT.row = 0

        Me.Text = My.Application.Info.Title & " -Letters - Client VT"

    End Sub
    'Generate the letter for the selected transaction
    Public Sub createLetter()
        'Dim attachList As Object
        'Dim rs As Object
        'Dim message As Object
        'Dim dateOffered As Object
        'Dim amount As Object
        'Dim language As Object
        'Dim rsMakelaarSql As Object
        'Dim rsAreaBrief As Object
        'Dim letterSubject As String
        'UPGRADE_NOTE: MonthName was upgraded to MonthName_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        'Dim MonthName_Renamed As String
        'Dim blnUserControl As Boolean
        'Dim tempFilename As String
        'Dim AreaSql As String
        'UPGRADE_WARNING: Arrays in structure rsArea may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        'Dim rsArea As DAO.Recordset

        'Destination = email
        If Me.rdEpos.Checked Then
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            If emailEngine.signOn Then
                emailEngine.txtTo.Text = Persoonl.EMAIL & ""
                emailEngine.ShowDialog()

                'If cancel was clicked - abort process else continue
                If Not emailEngine.returnValue Then
                    emailEngine.signOff()
                    emailEngine.Close()
                    Exit Sub
                End If
            Else
                'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If
        End If

        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        lblStatus.Text = "Laai Microsoft® Excel"

        'letterhead_createExcelObject(xlapp, blnUserControl)
        'xlbook = xlapp.Workbooks.Open("c:\polis5\docs\report.xls")
        'xlsheet = xlbook.Worksheets(1)

        'xlapp.DisplayAlerts = False

        lblStatus.Text = "Genereer VT brief"
        Me.Refresh()

        'dbPoldata = DAODBEngine_definst.OpenDatabase(pol_path & "\poldata5.mdb")
        'rsAreaBrief = dbPoldata.OpenRecordset("SELECT * FROM area WHERE area_kode = '" & Persoonl.Fields("area").Value & "'")

        'UPGRADE_WARNING: Couldn't resolve default property of object rsAreaBrief(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'rsMakelaarSql = dbPoldata.OpenRecordset("SELECT * FROM Makelaar where pkmakelaar = " & rsAreaBrief("fkmakelaar"))
        'UPGRADE_WARNING: Couldn't resolve default property of object rsMakelaarSql(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Shapes.AddPicture(getAdminPath & "Logo\" & rsMakelaarSql("Makelaar_logo"), True, True, ExcelGlobal_definst.Cells.Left, ExcelGlobal_definst.Cells.Top, 480, 70)

        'If Persoonl.TAAL = 0 Then
        '    letterSubject = "ONBETAALDE PREMIE"
        'Else
        '    letterSubject = "UNPAID PREMIUM"
        'End If

        '      letterhead_setStyle(xlsheet, 100, 12, Persoonl.TAAL, False, Persoonl.POLISNO)

        '      strAreaBranch = Persoonl.Area

        '      letterhead_setBranch(xlsheet, Persoonl.TAAL, 5, 12, strAreaBranch)

        '      letterhead_setAddress(xlsheet, 9, 3, Persoonl.TAAL, gen_getTitleDesc(Persoonl.TAAL, Persoonl.titelnum, Persoonl.VOORL, Persoonl.VERSEKERDE.Value, Persoonl.ADRES & "", Persoonl.Adres4 & "", Persoonl.Adres4, Persoonl.ADRES2)

        '      letterhead_setSubject(xlsheet, 26, 12, Persoonl.TAAL, letterSubject, Persoonl.POLISNO, gen_getTitleDesc(Persoonl.TAAL, Persoonl.titelnum , Persoonl.VERSEKERDE, True)

        ''Set line
        'letterhead_setLine(xlsheet, "A4", "L4")

        'Footer - overide the footer set with letterhead_setStyle
        'UPGRADE_WARNING: Couldn't resolve default property of object language. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If language = 0 Then
        'xlsheet.PageSetup.RightFooter = "&6Bladsy &p van &n"
        'Else
        'xlsheet.PageSetup.RightFooter = "&6Page &p of &n"
        'End If
        'xlsheet.PageSetup.RightHeader = "&6 " & gen_getTitleDesc(Persoonl.TAAL, Persoonl.titelnum) & ". " & Persoonl.VOORL & " " & Persoonl.VERSEKERDE & " (" & Persoonl.POLISNO & ")"

        rownumber = 31

        'Set the style of the letter introduction
        'With xlsheet.Range("A" & rownumber & ":L" & rownumber)
        '.Cells.Merge()
        '.RowHeight = 34.5
        '.VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop
        '.HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlJustify
        '.WrapText = True
        'End With

        'UPGRADE_WARNING: Couldn't resolve default property of object amount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'amount = GridVT.get_TextMatrix(GridVT.row, 4)
        'MonthName_Renamed = gen_getMonthName(Persoonl.TAAL, CByte(GridVT.get_TextMatrix(GridVT.Row, 7)))
        'UPGRADE_WARNING: Couldn't resolve default property of object dateOffered. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'dateOffered = MonthName_Renamed & " " & GridVT.get_TextMatrix(GridVT.row, 8)

        'Letter introduction
        If Persoonl.TAAL = 0 Then
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'message = "Met betrekking tot bogenoemde polis wil ons u in kennis stel dat die premie ten bedrae van"
            'UPGRADE_WARNING: Couldn't resolve default property of object dateOffered. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object amount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'message = message & " R " & Format(amount, "##0.00") & " wat betaalbaar was vir " & dateOffered & " deur u bank teruggestuur is as gevolg van:"
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'message = message & " " & UCase(GridVT.get_TextMatrix(GridVT.Row, 3))

            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber + 2, 1).value = "Volgens ons rekords is u bank besonderhede as volg:"
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ' message = "With reference to the above policy, we wish to advise you that the premium to the amount of"
            'UPGRADE_WARNING: Couldn't resolve default property of object dateOffered. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object amount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'message = message & " R " & Format(amount, "##0.00") & " that was due and payable for " & dateOffered & " has been returned to the bank due to:"
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'message = message & " " & UCase(GridVT.get_TextMatrix(GridVT.Row, 6))

            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber + 2, 1).value = "According to our records your bank account details are as follows:"
        End If
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 1).value = message

        'Banking information
        sSql = "SELECT * FROM aftrek LEFT JOIN bankcodes on bankcodes.pkBankCodes = aftrek.fkBankCodes"
        sSql = sSql & " WHERE polisno = '" & Persoonl.POLISNO & "'"
        'rs = pol.OpenRecordset(sSql)

        rownumber = rownumber + 3

        'With xlsheet.Range("B" & rownumber & ":D" & rownumber + 4)
        '.RowHeight = 11
        '.Font.Bold = True
        'End With

        'UPGRADE_WARNING: Couldn't resolve default property of object rs.BOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object rs.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If Not (rs.EOF And rs.BOF) Then
        If Persoonl.TAAL = 0 Then
            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber + 1, 2).value = "Bank/bouvereniging"
            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber + 2, 2).value = "Takkode"
            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber + 3, 2).value = "Rekeningnommer"
            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber + 4, 2).value = "Tipe rekening"
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber + 1, 2).value = "Bank/building society"
            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber + 2, 2).value = "Branch code"
            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber + 3, 2).value = "Account number"
            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber + 4, 2).value = "Account type"
        End If

        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 1, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 1, 5).value = rs("bankname")
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 2, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 2, 5).value = "'" & rs("branchcode")
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 3, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 3, 5).value = "'" & rs("rek_no1")
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 4, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 4, 5).value = gen_getAccountType(Persoonl.TAAL, CStr(rs("a_tipe")))
        'Else
        If Persoonl.TAAL = 0 Then
            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber + 1, 2).value = "Geen bankbesonderhede beskikbaar nie"
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber + 1, 2).value = "No banking detail available"
        End If
        'End If

        rownumber = rownumber + 6

        If Persoonl.TAAL = 0 Then
            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber, 1).value = "Indien die inligting nie korrek is nie, moet u ons asseblief onmiddelik in kennis stel van die regte besonderhede."
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ' Message = "U het 'n 15 dae grasie tydperk vanaf die datum waarop die premie betaalbaar was om die premie te betaal."
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ' Message = Message & "  Indien u in gebreke bly sal daar geen dekking wees nie.  Die inbetaling(s) op die uitstaande bedrag(e)"
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'Message = Message & " kan direk by ons kantoor inbetaal word of andersins kan u die betaling per pos aanstuur na ons posadres,"
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'Message = Message & " op voorwaarde dat die betaling ons bereik binne die grasie tydperk.  Indien u sou verkies om die betaling elektronies oor te betaal, is ons bank besonderhede as volg:"
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber, 1).value = "If the above information is incorrect, please advise us of the correct details immediately."
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'Message = "You have a grace period of 15 days, from the date upon which the premium became due, within which you must pay the premium, "
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ' Message = Message & "failing to will result in you having no cover.  Payment(s) of the outstanding premium can be paid "
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'Message = Message & "at our office or alternatively, you may submit payment to our postal address, on condition that we receive payment within the grace period mentioned above.  Electronic payment(s) can also be paid into"
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'Message = Message & " the following account: "
        End If

        rownumber = rownumber + 2

        'With xlsheet.Range("A" & rownumber & ":L" & rownumber)
        '.Cells.Merge()
        '.RowHeight = 51
        '.VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop
        '.WrapText = True
        '.HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlJustify
        'End With

        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 1).value = Message

        rownumber = rownumber + 2

        'With xlsheet.Range("B" & rownumber & ":D" & rownumber + 5)
        '.Font.Bold = True
        '.RowHeight = 11
        'End With

        'Area information
        ' AreaSql = "SELECT * FROM area WHERE area_kode = '" & Persoonl.Area & "'"
        'rsArea = pol.OpenRecordset(AreaSql)

        If Persoonl.TAAL = 0 Then
            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 2).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber, 2).value = "Gebruik u polisnommer as verwysing en faks asseblief die depositostrokie na " & rsArea.Fields("tak_faks").Value
            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber + 2, 2).value = "Bank/bouvereniging:"
            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber + 3, 2).value = "Takkode:"
            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber + 4, 2).value = "Rekeningnommer:"
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 2).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber, 2).value = "Please state your policy number as reference and fax the deposit slip to " & rsArea.Fields("tak_faks").Value
            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber + 2, 2).value = "Bank/building society:"
            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber + 3, 2).value = "Branch code:"
            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber + 4, 2).value = "Account number:"
        End If

        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 2, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 2, 5).value = rsArea.Fields("tak_bankbouv").Value
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 3, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 3, 5).value = "'" & rsArea.Fields("tak_takkode").Value
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 4, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 4, 5).value = "'" & rsArea.Fields("tak_rekeningnr").Value

        rownumber = rownumber + 6

        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 1).Font.Bold = True
        'With xlsheet.Range("A" & rownumber + 1 & ":L" & rownumber + 1)
        '.Cells.Merge()
        '.RowHeight = 75
        '.VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop
        '.WrapText = True
        '.HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlJustify
        'End With

        If Persoonl.TAAL = 0 Then
            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber, 1).value = "Neem kennis:"

            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ' Message = "Ons is onder geen verpligting om enige premie wat na 15 dae vanaf die betaaldatum getender word te aanvaar nie."
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ' Message = Message & "  Enige premie wat na hierdie datum aanvaar word sal sonder benadeling van ons of die versekeraar se regte aanvaar word en met die voorbehoud dat dekking eers sal"
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'Message = Message & " hervat na die ontvangs van die premie. Daar sal geen dekking wees vanaf die betaaldatum tot en met die datum"
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'Message = Message & " van ontvangs van premie nie.  Indien enige premie aanvaar word na 15 dae vanaf die betaaldatum, vereis ons dat 'n"
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'Message = Message & " voertuig inspeksieverslag voltooi word met betrekking tot u voertuig voordat ons dekking kan hervat op die polis."
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'Message = Message & "  Dit beteken dat u addisionele kostes sal moet aangaan."

            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber + 3, 1).value = "Die uwe"
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber, 1).value = "Kindly take note that:"

            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ' Message = "We are not obliged to accept any premium tendered to us later than 15 days after the date upon which the premium became due.  "
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'Message = Message & "Any premium accepted after such date will be subject to the condition that cover will only apply from the date the premium was"
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'Message = Message & " accepted onwards. There will be no cover from the due date to the premium"
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ' Message = Message & " acceptance date.  Should any premium be accepted more than 15 days after the due date, then we will require a Vehicle"
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ' Message = Message & " inspection report to be completed in respect of your vehicle in order for us to reinstate your policy."
            'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'Message = Message & "  This means that you will have to incur additional expenses in obtaining such a report."

            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'xlsheet.Cells._Default(rownumber + 3, 1).value = "Yours faithfully"
        End If
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 1, 1).value = Message

        'Printer / Email
        If Me.rdDrukker.Checked Then 'Print
            'Arhive document
            'gen_ArchiveDocument(xlbook, 1, Persoonl.POLISNO, 8, "", "", "", "")

            'Preview letter
            'xlapp.Visible = True
            'xlsheet.PrintPreview()

        ElseIf Me.rdEpos.Checked Then  'Email
            'UPGRADE_WARNING: Couldn't resolve default property of object attachList. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'gen_ArchiveDocument(xlbook, 1, Persoonl.POLISNO, 8, (emailEngine.txtSubject).Text, (emailEngine.txtTo).Text, (emailEngine.txtBody).Text, CStr(attachList), tempFilename)

            'email file as attachment
            'emailEngine.sendMail((emailEngine.txtTo).Text, (emailEngine.txtSubject).Text, (emailEngine.txtBody).Text, tempFilename)
        End If

        'If the document was emailed - sign-off
        If Me.rdEpos.Checked Then
            emailEngine.signOff()
            emailEngine.Close()
        End If

        lblStatus.Text = "VT brief is gedruk/ge-epos"

        Me.Refresh()
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        'xlbook.Close()
        'xlapp.Quit()
        'UPGRADE_NOTE: Object xlapp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'xlapp = Nothing
        'UPGRADE_NOTE: Object xlbook may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'xlbook = Nothing
        'UPGRADE_NOTE: Object xlsheet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'xlsheet = Nothing

        'Close form
        btnClose_Click(btnClose, New System.EventArgs())
    End Sub

    Function PopulatesBriefVT()

        Dim list As List(Of BriefVT_Entity) = New List(Of BriefVT_Entity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                param.Value = Persoonl.POLISNO

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[KlientVTDetails]", param)
                While reader.Read()
                    Dim item As BriefVT_Entity = New BriefVT_Entity()

                    'item.ander = reader("ander")
                    'If reader("Polisno") IsNot DBNull.Value Then
                    '    item.POLISNO = reader("Polisno")
                    'End If
                    If reader("Datum aangebied") IsNot DBNull.Value Then
                        item.Datumaangebied = reader("Datum aangebied")
                    End If
                    If reader("VT Datum") IsNot DBNull.Value Then
                        item.VTDatum = reader("VT Datum")
                    End If
                    If reader("Beskrywing") IsNot DBNull.Value Then
                        item.Beskrywing = reader("Beskrywing")
                    End If
                    If reader("Bedrag(R)") IsNot DBNull.Value Then
                        item.Bedrag = reader("Bedrag(R)")
                    End If
                    If reader("Krities") IsNot DBNull.Value Then
                        item.Krities = reader("Krities")
                    End If

                    list.Add(item)

                End While
                Return list

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function

    Private Sub BriefVTGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        BriefVTGrid1.ReadOnly = True
    End Sub

    Private Sub BriefVTGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BriefVTGrid1.Click
        Try

        Catch
        End Try
    End Sub

    Private Sub BriefVTGrid1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles BriefVTGrid1.CellContentClick
        BriefVTGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub


End Class