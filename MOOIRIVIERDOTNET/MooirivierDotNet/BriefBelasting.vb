Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Data.SqlClient
Imports DAL
Imports System.IO
Imports Microsoft.Reporting.WinForms
Imports System.Net
Imports System.Configuration

Friend Class BriefBelasting
    Inherits BaseForm


    Public ListItemDesc As String
    Public ListItemValue As String
    'Description: Print a tax certificate
    'Dim sSql As String
    'Dim dbPoldata As DAO.Database
    'Dim dbStats As DAO.Database
    'Dim xlapp As Microsoft.Office.Interop.Excel.Application
    'Dim xlbook As Microsoft.Office.Interop.Excel.Workbook
    'Dim xlsheet As Microsoft.Office.Interop.Excel.Worksheet
    Dim rownumber As Short
    Dim language As Byte
    Dim todate As String
    Dim fromdate As String
    Dim fromdateDisplay As String
    Dim todateDisplay As String
    'Dim rs As DAO.Recordset
    Dim strAreaBranch As String
    Dim strItem As String
    Dim strKlas As String
    Dim dblItembedrag As Double
    Public result As Byte() = Nothing
    Dim tempFilename As String

    Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click

        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
        language = Persoonl.TAAL

        If Me.optItem.Checked Then

            If lstInsuredItems.SelectedIndex < 0 Then
                MsgBox("You need an item to choose to participate in the tax asking.", MsgBoxStyle.Information)
                Exit Sub
            Else
                Dim BevestigDescEntity As New BevestigDescEntity

                BevestigDescEntity = lstInsuredItems.SelectedItem
                ListItemDesc = BevestigDescEntity.bevestigDesc
                ListItemValue = lstInsuredItems.SelectedValue
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
                        gen_ArchiveDocument(result, Persoonl.POLISNO, 14, "", "", "", "")
                    ElseIf rdEpos.Checked Then
                        CreateReportFile()
                        gen_ArchiveDocument(result, Persoonl.POLISNO, 14, emailEngine.txtSubject.Text, emailEngine.txtTo.Text, emailEngine.txtBody.Text, getAttachmentsForEmailEngine, tempFilename)
                        emailEngine.sendMail(emailEngine.txtTo.Text, emailEngine.txtSubject.Text, emailEngine.txtBody.Text, tempFilename)
                    End If
                    Exit Sub
                Else
                    BriefTaxReportViewer.ShowDialog()
                    Exit Sub
                End If

            End If
        Else
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
                    gen_ArchiveDocument(result, Persoonl.POLISNO, 14, "", "", "", "")
                ElseIf rdEpos.Checked Then
                    CreateReportFile()
                    gen_ArchiveDocument(result, Persoonl.POLISNO, 14, emailEngine.txtSubject.Text, emailEngine.txtTo.Text, emailEngine.txtBody.Text, getAttachmentsForEmailEngine, tempFilename)
                    emailEngine.sendMail(emailEngine.txtTo.Text, emailEngine.txtSubject.Text, emailEngine.txtBody.Text, tempFilename)
                End If
                Exit Sub
            Else
                BriefTaxReportViewer.ShowDialog()
                Exit Sub
            End If
        End If


    End Sub
    Sub CreateReportFile()
        Dim detailStream As Stream
        detailStream = createDetailFile("/Mooirivier/BriefTaxCertificate")
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
            Dim language As Byte
            Dim fromdateDisplay As String
            Dim todateDisplay As String
            Dim PropertyCoverType As String
            'Dim Security As String
            Dim BTWno As String
            Dim strKlas As String
            Dim strItem As String
            Dim subtotaal As Double
            Dim BTWteen As String
            Dim Total As String
            Dim premDate As String
            Dim itemDesc As String
            Dim dblItembedrag As String
            Dim btwPersentasie As Single
            ' Dim fromdate As String
            'Dim todate As String
            Dim Checked As String
            Dim Premie As String
            strKlas = ""
            strItem = ""
            btwPersentasie = 14


            sSql = FetchPrint2()

            Total = 0
            dblItembedrag = 0
            'Date parameters
            fromdateDisplay = DateSerial(Year(DTPicker1.Value), Month(DTPicker1.Value), 1)
            todateDisplay = DateSerial(Year(DTPicker2.Value), Month(DTPicker2.Value) + 1, 0)

            'BTWnr parameter
            'rsAreaVerseke = FetchVersekeraarForArea()
            If rsAreaVerseke.BTWNommer = "" Then
                If Persoonl.TAAL = 0 Then
                    BTWno = "n.v.t"
                Else
                    BTWno = "n/a"
                End If
            Else
                BTWno = rsAreaVerseke.BTWNommer
            End If
            'Klas and Item parameters for vehicle
            rsVoertuie = FetchVoertuieForPrint()
            'Klas and Item parameters for property
            rsProperty = GetHuisByPrimaryKey(pkHuis)
            If optItem.Checked Then
                Select Case Trim(Mid(ListItemDesc, 1, 12)) '(Mid(ListItemDesc, 1, 12))
                    Case "Voertuig :"
                        PropertyCoverType = " "
                        strItem = Mid(ListItemDesc, 15, ListItemDesc.Length - 1)
                        If Persoonl.TAAL = 0 Then
                            strKlas = "Voertuig"
                        Else
                            strKlas = "Vehicle"
                        End If
                    Case "* Voertuig :"
                        strItem = Mid(ListItemDesc, 15, ListItemDesc.Length - 1)
                        PropertyCoverType = " "
                        If Persoonl.TAAL = 0 Then
                            strKlas = "Voertuig"
                        Else
                            strKlas = "Vehicle"
                        End If
                    Case "Eiendom HE:"
                        PropertyCoverType = "HE"
                        strItem = Mid(ListItemDesc, 15, ListItemDesc.Length - 1)
                        If Persoonl.TAAL = 0 Then
                            If PropertyCoverType = "HE" Then
                                strKlas = "Huiseienaar"
                            Else
                                strKlas = "Huisbewoner"
                            End If
                        Else
                            If PropertyCoverType = "HE" Then
                                strKlas = "Homeowner"
                            Else
                                strKlas = "Householder"
                            End If
                        End If
                    Case "Eiendom HB:"
                        PropertyCoverType = "HB"
                        strItem = Mid(ListItemDesc, 15, ListItemDesc.Length - 1)
                        If Persoonl.TAAL = 0 Then
                            If PropertyCoverType = "HB" Then
                                strKlas = "Huiseienaar"
                            Else
                                strKlas = "Huisbewoner"
                            End If
                        Else
                            If PropertyCoverType = "HB" Then
                                strKlas = "Homeowner"
                            Else
                                strKlas = "Householder"
                            End If
                        End If
                    Case "* Eiendom HE"
                        strItem = Mid(ListItemDesc, 15, ListItemDesc.Length - 1)
                        PropertyCoverType = "HE"
                        If Persoonl.TAAL = 0 Then
                            If PropertyCoverType = "HE" Then
                                strKlas = "Huiseienaar"
                            Else
                                strKlas = "Huisbewoner"
                            End If
                        Else
                            If PropertyCoverType = "HE" Then
                                strKlas = "Homeowner"
                            Else
                                strKlas = "Householder"
                            End If
                        End If
                    Case "* Eiendom HB"
                        strItem = Mid(ListItemDesc, 15, ListItemDesc.Length - 1)
                        PropertyCoverType = "HB"
                        If Persoonl.TAAL = 0 Then
                            If PropertyCoverType = "HB" Then
                                strKlas = "Huiseienaar"
                            Else
                                strKlas = "Huisbewoner"
                            End If
                        Else
                            If PropertyCoverType = "HB" Then
                                strKlas = "Homeowner"
                            Else
                                strKlas = "Householder"
                            End If
                        End If
                    Case Else
                        PropertyCoverType = " "
                End Select

                subtotaal = Format(subtotaal + (dblItembedrag / 1.14), "0.00")

                Premie = Format(System.Math.Round(dblItembedrag / ((btwPersentasie / 100) + 1), 2), "0.00")
            Else
                subtotaal = Format(subtotaal + (ssql.Premie2 / 1.14), "0.00")

                Premie = Format(System.Math.Round(ssql.Premie2 / ((btwPersentasie / 100) + 1), 2), "0.00")

            End If
            subtotaal = System.Math.Round(subtotaal, 2)

            BTWteen = format(System.Math.Round(subtotaal * (btwPersentasie / 100), 2), "0.00")

            Total = format(System.Math.Round(subtotaal * ((btwPersentasie / 100) + 1), 2), "0.00")

            premDate = DateSerial(Year(sSql.Afsluit_dat), Month(sSql.Afsluit_dat) + 1, 1)

            'check for yearly payments and date parameters
            If Persoonl.BET_WYSE = "2" Then
                itemDesc = Year(premDate)
            Else
                itemDesc = gen_getMonthName(language, Month(premDate)) & " " & Year(premDate)
            End If
            If optItem.Checked Then
                Checked = "1"
            Else
                Checked = "0"
            End If

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("area_kode", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", Persoonl.POLISNO), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", Persoonl.TAAL), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("BTWno", BTWno), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Klas", strKlas), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Item", strItem), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("itemDesc", itemDesc), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Subtotaal", subtotaal), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("FromDate", fromdateDisplay), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("ToDate", todateDisplay), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("BTWteen", BTWteen), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Premie", Premie), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Checked", Checked), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Totaal", Total)}

            'end params specific

            rview.ServerReport.ReportPath = reportPath
            rview.ServerReport.SetParameters(params)

            Dim encoding As String = ""
            Dim mimeType As String = ""
            Dim warnings As Microsoft.Reporting.WinForms.Warning() = Nothing
            Dim streamIDs As String() = Nothing
            Dim extension As String = ""
            Dim formats As String = "PDF" '//Desired format goes here (PDF, Excel, or Image)
            Dim deviceInfo As String = "<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>"

            result = rview.ServerReport.Render(formats, deviceInfo, mimeType, encoding, extension, streamIDs, warnings)

            stream = New MemoryStream(result.Length)
            stream.Write(result, 0, result.Length)

            Return stream
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing ' Andriette - maak warnings reg
        End Try
    End Function

    Private Sub BriefBelasting_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'dbPoldata = DAODBEngine_definst.OpenDatabase(pol_path & "\poldata5.mdb")
        'dbStats = DAODBEngine_definst.OpenDatabase(pol_path & "\stats5d.mdb")
        fromdate = DateSerial(Year(Me.DTPicker1.Value), Month(Me.DTPicker1.Value) - 1, 1)

        todate = DateSerial(Year(Me.DTPicker2.Value), Month(Me.DTPicker2.Value), 0)

        fromdateDisplay = DateSerial(Year(Me.DTPicker1.Value), Month(Me.DTPicker1.Value), 1)

        todateDisplay = DateSerial(Year(Me.DTPicker2.Value), Month(Me.DTPicker2.Value) + 1, 0)


        Me.DTPicker1.Value = DateAdd(Microsoft.VisualBasic.DateInterval.Month, -6, Now)
        Me.DTPicker1.CustomFormat = "MMMM yyyy"
        Me.DTPicker2.Value = Now
        Me.DTPicker2.CustomFormat = "MMMM yyyy"

        Me.lstInsuredItems.Enabled = False
        'Me.lstInsuredItems.Items.Clear()

        Me.Text = My.Application.Info.Title & " - Letters - Tax Certificate"
    End Sub
    Public Function FetchPrint2() As Print2DatEntity

        Dim item As Print2DatEntity = New Print2DatEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@fromdate", SqlDbType.NVarChar), _
                                            New SqlParameter("@todate", SqlDbType.NVarChar)}

                params(0).Value = Persoonl.POLISNO
                params(1).Value = fromdate
                params(2).Value = todate

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[Stats5d].[stats5d.md_PRINT2_DAT_Brief_Belasting]", params)

                If reader.Read() Then

                    If reader("Huispremie") IsNot DBNull.Value Then
                        item.Huispremie = reader("Huispremie")
                    End If
                    If reader("Verwyskommissie") IsNot DBNull.Value Then
                        item.Verwyskommissie = reader("Verwyskommissie")
                    End If
                    If reader("Premie2") IsNot DBNull.Value Then
                        item.Premie2 = reader("Premie2")
                    End If
                    If reader("Polisno") IsNot DBNull.Value Then
                        item.Polisno = reader("Polisno")
                    End If
                    If reader("Afsluit_dat") IsNot DBNull.Value Then
                        item.Afsluit_dat = reader("Afsluit_dat")
                    End If
                    If reader("ongespesifiseerd") IsNot DBNull.Value Then
                        item.ongespesifiseerd = reader("ongespesifiseerd")
                    End If
                    If reader("ongevalle") IsNot DBNull.Value Then
                        item.ongevalle = reader("ongevalle")
                    End If
                    If reader("courtesyv") IsNot DBNull.Value Then
                        item.courtesyv = reader("courtesyv")
                    End If
                    If reader("afsluitdatum") IsNot DBNull.Value Then
                        item.afsluitdatum = reader("afsluitdatum")
                    End If
                    If reader("alle_sub") IsNot DBNull.Value Then
                        item.alle_sub = reader("alle_sub")
                    End If
                    If reader("huis_sub") IsNot DBNull.Value Then
                        item.huis_sub = reader("huis_sub")
                    End If
                    If reader("motor_sub") IsNot DBNull.Value Then
                        item.motor_sub = reader("motor_sub")
                    End If
                    If reader("id_nom") IsNot DBNull.Value Then
                        item.id_nom = reader("id_nom")
                    End If
                    If reader("bybet_k") IsNot DBNull.Value Then
                        item.bybet_k = reader("bybet_k")
                    End If
                    If reader("eispers") IsNot DBNull.Value Then
                        item.eispers = reader("eispers")
                    End If
                    If reader("toe_waarde") IsNot DBNull.Value Then
                        item.toe_waarde = reader("toe_waarde")
                    End If
                    If reader("toe_premie") IsNot DBNull.Value Then
                        item.toe_premie = reader("toe_premie")
                    End If
                    If reader("eem_waarde") IsNot DBNull.Value Then
                        item.eem_waarde = reader("eem_waarde")
                    End If
                    If reader("eem_premie") IsNot DBNull.Value Then
                        item.eem_premie = reader("eem_premie")
                    End If
                    If reader("epc") IsNot DBNull.Value Then
                        item.epc = reader("epc")
                    End If
                    If reader("inscell") IsNot DBNull.Value Then
                        item.inscell = reader("inscell")
                    End If
                    If reader("AddisionelePremie") IsNot DBNull.Value Then
                        item.AddisionelePremie = reader("AddisionelePremie")
                    End If
                    If reader("PersoonlAddisionelePremie") IsNot DBNull.Value Then
                        item.PersoonlAddisionelePremie = reader("PersoonlAddisionelePremie")
                    End If
                    If reader("bet_wyse") IsNot DBNull.Value Then
                        item.bet_wyse = reader("bet_wyse")
                    End If

                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function
    
    Sub md_print()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@fromdate", SqlDbType.NVarChar), _
                                                New SqlParameter("@todate", SqlDbType.NVarChar)}

                params(0).Value = Persoonl.POLISNO
                params(1).Value = fromdate
                params(2).Value = todate
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[Stats5d].[stats5d.md_PRINT2_DAT_Brief_Belasting]", params)

                Dim item As Print2DatEntity = New Print2DatEntity()

                If reader.Read() Then
                    If reader("afsluit_dat") IsNot DBNull.Value Then
                        item.Afsluit_dat = reader("afsluit_dat")
                    End If
                    If reader("polisno") IsNot DBNull.Value Then
                        item.Polisno = reader("polisno")
                    End If

                Else
                    MsgBox("There were no transactions for the policy number.", MsgBoxStyle.Information)
                    Exit Sub

                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    'Generate the letter
    Public Sub createLetter()
        'Dim attachList As Object
        Dim message As Object
        Dim rsMakelaarSql As Object
        Dim rsAreaBrief As Object
        Dim rsPersoonl As Object
        Dim todateDisplay As Object
        Dim fromdateDisplay As Object
        Dim letterSubject As String
        'Dim blnUserControl As Boolean
        Dim tempFilename As String
        'Dim AreaSql As String

        'Dim rsArea As DAO.Recordset
        tempFilename = ""
        'Destination = email
        If Me.rdEpos.Checked Then

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            If emailEngine.signOn Then

                emailEngine.txtTo.Text = Persoonl.EMAIL
                emailEngine.ShowDialog()

                'If cancel was clicked - abort process else continue
                If Not emailEngine.returnValue Then
                    emailEngine.signOff()
                    emailEngine.Close()
                    Exit Sub
                End If
            Else
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If
        End If

        'Configure to and from dates to first and last day of months
        'Because the 'afsluit' dates are used, the display dates need to be adjusted accordingly

        fromdate = DateSerial(Year(Me.DTPicker1.Value), Month(Me.DTPicker1.Value) - 1, 1)

        todate = DateSerial(Year(Me.DTPicker2.Value), Month(Me.DTPicker2.Value), 0)

        fromdateDisplay = DateSerial(Year(Me.DTPicker1.Value), Month(Me.DTPicker1.Value), 1)

        todateDisplay = DateSerial(Year(Me.DTPicker2.Value), Month(Me.DTPicker2.Value) + 1, 0)

        'Get all the premiums for the specified timeframe

        'sSql = "SELECT * FROM md_print2_dat WHERE polisno = '" & Persoonl.Fields("polisno").Value & "'"
        'sSql = sSql & " AND cdate(afsluit_dat) >= cdate('" & fromdate & "')"
        'sSql = sSql & " AND cdate(afsluit_dat) <= cdate('" & todate & "')"
        'sSql = sSql & " ORDER BY cdate(afsluit_dat)"
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.Int), _
                                                New SqlParameter("@fromdate", SqlDbType.Int), _
                                            New SqlParameter("@todate", SqlDbType.NVarChar)}

                params(0).Value = Persoonl.POLISNO
                params(1).Value = CDate(fromdate)
                params(2).Value = CDate(todate)
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[Stats5d].[stats5d.md_PRINT2_DAT_Brief_Belasting]", params)

                If reader.Read() Then

                    MsgBox("There were no transactions for the policy number.", MsgBoxStyle.Information)
                    Exit Sub
                Else

                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                    lblStatus.Text = "Laai Microsoft® Excel"

                    'letterhead_createExcelObject(xlapp, blnUserControl)
                    'xlbook = xlapp.Workbooks.Open("c:\polis5\docs\report.xls")
                    'xlsheet = xlbook.Worksheets(1)

                    rsPersoonl = Persoonl

                    'xlapp.DisplayAlerts = False

                    lblStatus.Text = "generate certificate"
                    Me.Refresh()

                    'rsAreaBrief = dbPoldata.OpenRecordset("SELECT * FROM area WHERE area_kode = '" & Persoonl.Fields("area").Value & "'")
                    rsAreaBrief = FetchAreaForPremie()

                    'rsMakelaarSql = dbPoldata.OpenRecordset("SELECT * FROM Makelaar where pkmakelaar = " & rsAreaBrief("fkmakelaar"))

                    'Linkie 04/07/2014
                    intfkMakelaar = rsAreaBrief.fkmakelaar
                    rsMakelaarSql = FetchMakeLaarByPk()
                    'xlsheet.Shapes.AddPicture(getAdminPath & "Logo\" & rsMakelaarSql("Makelaar_logo"), True, True, ExcelGlobal_definst.Cells.Left, ExcelGlobal_definst.Cells.Top, 480, 70)

                    If language = 0 Then
                        letterSubject = "Belastingsertifikaat "
                    Else
                        letterSubject = "Tax certificate "
                    End If

                    'letterhead_setStyle(xlsheet, 100, 12, language, False, Persoonl.Fields("polisno").Value)


                    'strAreaBranch = rsPersoonl("area")

                    'letterhead_setBranch(xlsheet, language, 5, 12, strAreaBranch)

                    If Persoonl.POSBESTEMMING = "2" Then 'University
                        'letterhead_setAddress(xlsheet, 9, 3, language, gen_getTitleDesc(language, Persoonl.Fields("titelnum").Value), Persoonl.Fields("voorl").Value, Persoonl.Fields("versekerde").Value, "Posvakkie " & Persoonl.Fields("pos_vakkie").Value & "", "", "", "")
                    Else
                        'letterhead_setAddress(xlsheet, 9, 3, language, gen_getTitleDesc(language, Persoonl.Fields("titelnum").Value), Persoonl.Fields("voorl").Value, Persoonl.Fields("versekerde").Value, Persoonl.Fields("adres").Value & "", Persoonl.Fields("adres4").Value & "", Persoonl.Fields("adres3").Value & "", Persoonl.Fields("adres2").Value & "")
                    End If
                    'letterhead_setSubject(xlsheet, 26, 12, language, letterSubject, Persoonl.Fields("polisno").Value, "", "", True)

                    'Set line
                    'letterhead_setLine(xlsheet, "A4", "L4")

                    'Repeat row as titel

                    'xlsheet.PageSetup.PrintTitleRows = ExcelGlobal_definst.ActiveSheet.Rows(33).address 'The row selected as the heading for each page

                    ' Footer - overide the footer set with letterhead_setStyle
                    If language = 0 Then
                        'xlsheet.PageSetup.RightFooter = "&6Bladsy &p van &n"
                    Else
                        'xlsheet.PageSetup.RightFooter = "&6Page &p of &n"
                    End If
                    'xlsheet.PageSetup.RightHeader = "&6 " & gen_getTitleDesc(language, Persoonl.Fields("titelnum").Value) & ". " & Persoonl.Fields("voorl").Value & " " & Persoonl.Fields("versekerde").Value & " (" & Persoonl.Fields("polisno").Value & ")"

                    rownumber = 29

                    'Set the style of the letter introduction
                    'With xlsheet.Range("A" & rownumber & ":L" & rownumber)
                    '.Cells.Merge()
                    '.RowHeight = 39
                    '.VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop
                    '.Font.Bold = True
                    'End With

                    'Versekeraar(Information)
                    'AreaSql = "SELECT area.*, versekeraar.* FROM area, versekeraar "
                    'AreaSql = AreaSql & " WHERE area.fkversekeraar = versekeraar.pkversekeraar AND area_kode = '" & Persoonl.Fields("area").Value & "'"
                    'rsArea = dbPoldata.OpenRecordset(AreaSql)

                    'rsAreaVerseke = FetchVersekeraarForArea()

                    'Letter(introduction)
                    If language = 0 Then

                        message = "Die versekeraar is '" & rsAreaVerseke.Bedryfsnaam

                        message = message & Chr(10) & rsAreaVerseke.Posadres & ", " & rsAreaVerseke.PosVoorstad & ", " & rsAreaVerseke.PosDorp & ", " & rsAreaVerseke.PosPoskode

                        message = message & Chr(10) & "BTW nr. " & rsAreaVerseke.BTWNommer
                    Else

                        message = "The insurer is '" & rsAreaVerseke.Bedryfsnaam

                        message = message & Chr(10) & rsAreaVerseke.Posadres & ", " & rsAreaVerseke.PosVoorstad & ", " & rsAreaVerseke.PosDorp & ", " & rsAreaVerseke.PosPoskode

                        message = message & Chr(10) & "VAT nr. " & rsAreaVerseke.BTWNommer
                    End If

                    'xlsheet.Cells._Default(rownumber, 1).value = message

                    rownumber = rownumber + 2

                    ' Period & VAT number for policyholder
                    If language = 0 Then

                        'xlsheet.Cells._Default(rownumber, 1).value = "Tydperk: "

                        'xlsheet.Cells._Default(rownumber, 5).value = fromdateDisplay & " tot " & todateDisplay

                        'xlsheet.Cells._Default(rownumber + 1, 1).value = "Polishouer BTW nr. "
                        If Me.optItem.Checked Then

                            'xlsheet.Cells._Default(rownumber + 2, 1).value = "Klas: "

                            'xlsheet.Cells._Default(rownumber + 3, 1).value = "Item: "
                        End If
                    Else

                        'xlsheet.Cells._Default(rownumber, 1).value = "Period: " & fromdateDisplay & " to " & todateDisplay

                        'xlsheet.Cells._Default(rownumber, 1).value = fromdateDisplay & " to " & todateDisplay

                        'xlsheet.Cells._Default(rownumber + 1, 1).value = "Policyholder VAT nr. "
                        If Me.optItem.Checked Then

                            'xlsheet.Cells._Default(rownumber + 2, 1).value = "Class: "

                            'xlsheet.Cells._Default(rownumber + 3, 1).value = "Item: "
                        End If
                    End If
                    If Trim(rsPersoonl("BTWno")) = "" Or IsDBNull(rsPersoonl("BTWno")) Then
                        If language = 0 Then

                            'xlsheet.Cells._Default(rownumber + 1, 5).value = "n.v.t."
                        Else

                            'xlsheet.Cells._Default(rownumber + 1, 5).value = "n/a"
                        End If
                    Else
                        'xlsheet.Cells._Default(rownumber + 1, 5).value = "'" & rsPersoonl("BTWno")
                    End If

                    If Me.optItem.Checked Then
                        'Insert item detail
                        'Check for property or vehicle
                        'Select Case Trim(VB.Left(Me.lstInsuredItems.Text, 12))
                        '    Case "Voertuig"
                        '        insertVehicleDetail(VB6.GetItemData(Me.lstInsuredItems, lstInsuredItems.SelectedIndex), False)
                        '    Case "* Voertuig"
                        '        insertVehicleDetail(VB6.GetItemData(Me.lstInsuredItems, lstInsuredItems.SelectedIndex), True)
                        '    Case "Eiendom HE"
                        '        insertPropertyDetail(VB6.GetItemData(Me.lstInsuredItems, lstInsuredItems.SelectedIndex), "HE", False)
                        '    Case "Eiendom HB"
                        '        insertPropertyDetail(VB6.GetItemData(Me.lstInsuredItems, lstInsuredItems.SelectedIndex), "HB", False)
                        '    Case "* Eiendom HE"
                        '        insertPropertyDetail(VB6.GetItemData(Me.lstInsuredItems, lstInsuredItems.SelectedIndex), "HE", True)
                        '    Case "* Eiendom HB"
                        '        insertPropertyDetail(VB6.GetItemData(Me.lstInsuredItems, lstInsuredItems.SelectedIndex), "HB", True)
                        'End Select


                        'xlsheet.Cells._Default(rownumber + 2, 5).value = strKlas

                        'xlsheet.Cells._Default(rownumber + 3, 5).value = strItem
                        rownumber = rownumber + 5
                    Else
                        rownumber = rownumber + 3
                    End If

                    'Insert certificate detail
                    insertDetail()

                    lblStatus.Text = "Tax Certificate is printed"
                    Me.Refresh()

                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

                    If Me.rdDrukker.Checked Then 'Print
                        'Arhive(document)
                        'gen_ArchiveDocument(xlbook, 1, Persoonl.Fields("polisno").Value, 1, "", "", "", "")

                        'Preview(letter)
                        'xlapp.Visible = True
                        'xlsheet.PrintPreview()

                    ElseIf Me.rdEpos.Checked Then  'Email

                        'gen_ArchiveDocument(xlbook, 1, Persoonl.Fields("polisno").Value, 1, (emailEngine.txtSubject).Text, (emailEngine.txtTo).Text, (emailEngine.txtBody).Text, CStr(attachList), tempFilename)

                        emailEngine.sendMail((emailEngine.txtTo).Text, (emailEngine.txtSubject).Text, (emailEngine.txtBody).Text, tempFilename)
                    End If

                    'xlbook.Close()
                    'xlapp.Quit()


                    'xlapp = Nothing

                    'xlsheet = Nothing

                    'xlbook = Nothing

                    'Close(Form)
                    btnClose_Click(btnClose, New System.EventArgs())

                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try


        '      'rs = dbStats.OpenRecordset(sSql)
        '      'If rs.EOF And rs.BOF Then
        '     
        'End If
    End Sub
    'Insert the detail of the tax certificate
    Public Sub insertDetail()
        'Dim premDate As Object
        'Dim Total As Double
        'Dim blockStart As Short
        'Dim itemDesc As String
        'Dim subTotal As Double

        '		Total = 0
        '		blockStart = rownumber

        '		Style first row
        '        With xlsheet.Range("A" & rownumber, "L" & rownumber)
        '            .Font.Bold = True
        '            .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = 3
        '        End With

        '        Column(headings)
        '        If language = 0 Then

        '            xlsheet.Cells._Default(rownumber, 1).value = "Beskrywing"

        '            xlsheet.Cells._Default(rownumber, 12).value = "Bedrag R"
        '            If Me.optItem.Checked Then
        '                itemDesc = "Korttermynversekering: Item premie vir "
        '            Else
        '                itemDesc = "Korttermynversekering: Totale premie vir "
        '            End If
        '        Else

        '            xlsheet.Cells._Default(rownumber, 1).value = "Description"

        '            xlsheet.Cells._Default(rownumber, 12).value = "Amount R"
        '            If Me.optItem.Checked Then
        '                itemDesc = "Short term insurance: Item premium for "
        '            Else
        '                itemDesc = "Short term insurance: Total premium for "
        '            End If
        '        End If

        '        Every(row)
        '        Do While Not rs.EOF
        '            rownumber = rownumber + 1


        '            premDate = DateSerial(Year(rs.Fields("afsluit_dat").Value), Month(rs.Fields("afsluit_dat").Value) + 1, 1)

        '            'check for yearly payments
        '            If Persoonl.Fields("bet_wyse").Value = "2" Then


        '                xlsheet.Cells._Default(rownumber, 1).value = itemDesc & " " & Year(premDate)
        '            Else


        '                xlsheet.Cells._Default(rownumber, 1).value = itemDesc & gen_getMonthName(language, Month(premDate)) & " " & Year(premDate)
        '            End If

        '            If Me.optItem.Checked Then
        '                'Check for property or vehicle
        '                Select Case Trim(VB.Left(Me.lstInsuredItems.Text, 12))
        '                    Case "Voertuig"
        '                        insertVehicleDetail(VB6.GetItemData(Me.lstInsuredItems, lstInsuredItems.SelectedIndex), False)
        '                    Case "* Voertuig"
        '                        insertVehicleDetail(VB6.GetItemData(Me.lstInsuredItems, lstInsuredItems.SelectedIndex), True)
        '                    Case "Eiendom HE"
        '                        insertPropertyDetail(VB6.GetItemData(Me.lstInsuredItems, lstInsuredItems.SelectedIndex), "HE", False)
        '                    Case "Eiendom HB"
        '                        insertPropertyDetail(VB6.GetItemData(Me.lstInsuredItems, lstInsuredItems.SelectedIndex), "HB", False)
        '                    Case "* Eiendom HE"
        '                        insertPropertyDetail(VB6.GetItemData(Me.lstInsuredItems, lstInsuredItems.SelectedIndex), "HE", True)
        '                    Case "* Eiendom HB"
        '                        insertPropertyDetail(VB6.GetItemData(Me.lstInsuredItems, lstInsuredItems.SelectedIndex), "HB", True)
        '                End Select

        '                subTotal = subTotal + (dblItembedrag / 1.14)

        '                xlsheet.Cells._Default(rownumber, 12).value = "'" & VB6.Format(System.Math.Round(dblItembedrag / ((btwPersentasie / 100) + 1), 2), "0.00")
        '            Else
        '                subTotal = subTotal + (rs.Fields("premie2").Value / 1.14)

        '                xlsheet.Cells._Default(rownumber, 12).value = "'" & VB6.Format(System.Math.Round(rs.Fields("premie2").Value / ((btwPersentasie / 100) + 1), 2), "0.00")
        '            End If

        '            rs.MoveNext()
        '        Loop

        '        rownumber = rownumber + 1

        '        'Style last rows
        '        With xlsheet.Range("A" & rownumber, "L" & rownumber)
        '            .Font.Bold = True
        '            .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).Weight = 3
        '        End With
        '        With xlsheet.Range("A" & rownumber + 2, "L" & rownumber + 2)
        '            .Font.Bold = True
        '            .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).Weight = 3
        '        End With

        '        'Total row
        '        If language = 0 Then

        '            xlsheet.Cells._Default(rownumber, 1).value = "Subtotaal"

        '            xlsheet.Cells._Default(rownumber + 1, 1).value = "BTW teen " & btwPersentasie & "%"

        '            xlsheet.Cells._Default(rownumber + 2, 1).value = "Totaal"
        '        Else

        '            xlsheet.Cells._Default(rownumber, 1).value = "Subtotal"

        '            xlsheet.Cells._Default(rownumber + 1, 1).value = "Vat at " & btwPersentasie & "%"

        '            xlsheet.Cells._Default(rownumber + 2, 1).value = "Total"
        '        End If


        '        xlsheet.Cells._Default(rownumber, 11).Font.Bold = True

        '        xlsheet.Cells._Default(rownumber + 2, 11).Font.Bold = True
        '        With xlsheet.Range("K" & rownumber, "K" & rownumber + 2)
        '            .Value = "R"
        '            .HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlRight
        '        End With

        '        Insert(totals And vat)

        '        xlsheet.Cells._Default(rownumber, 12).value = System.Math.Round(subTotal, 2)

        '        xlsheet.Cells._Default(rownumber + 1, 12).value = System.Math.Round(subTotal * (btwPersentasie / 100), 2)

        '        xlsheet.Cells._Default(rownumber + 2, 12).value = "'" & VB6.Format(System.Math.Round(subTotal * ((btwPersentasie / 100) + 1), 2), "0.00")

        '        rownumber = rownumber + 2

        '        'Style block
        '        With xlsheet.Range("A" & blockStart, "L" & rownumber)
        '            .BorderAround(Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Word.XlBorderWeight.xlThin)
        '            .RowHeight = 16.5
        '        End With
        '        With xlsheet.Range("L" & blockStart, "L" & rownumber)
        '            .Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '            .HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlRight
        '        End With

    End Sub


    Private Sub optItem_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optItem.CheckedChanged
        If eventSender.Checked Then
            Me.lstInsuredItems.Enabled = True
            populateLstInsuredItems()
        End If
    End Sub
    Public Function FetchVoertuieForPrint2() As EntityVoertuie

        Dim item As EntityVoertuie = New EntityVoertuie()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                param.Value = Persoonl.POLISNO

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchVoertuie_For_PremieDetails2]", param)
                While reader.Read
                    If reader("maak") IsNot DBNull.Value Then
                        item.maak = reader("maak")
                    End If
                    If reader("besk") IsNot DBNull.Value Then
                        item.besk = reader("besk")
                    End If
                    If reader("eeu") IsNot DBNull.Value Then
                        item.eeu = reader("eeu")
                    End If
                    If reader("jaar") IsNot DBNull.Value Then
                        item.jaar = reader("jaar")
                    End If
                    If reader("n_plaat") IsNot DBNull.Value Then
                        item.plaat = reader("n_plaat")
                    End If
                    If reader("PremieVoertuig") IsNot DBNull.Value Then
                        item.premie = reader("PremieVoertuig")
                    End If
                    If reader("pkVoertuie") IsNot DBNull.Value Then
                        item.premie = reader("pkVoertuie")
                    End If
                End While
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function
    'Andriette 22/01/2014 vervang die entity
    'Public Function FetchVoertuieForPrint() As EntityVoertuie

    '    Dim item As EntityVoertuie = New EntityVoertuie()
    Public Function FetchVoertuieForPrint() As VoertuieEntity

        Dim item As VoertuieEntity = New VoertuieEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                param.Value = Persoonl.POLISNO

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchVoertuie_For_PremieDetails]", param)
                While reader.Read
                    If reader("maak") IsNot DBNull.Value Then
                        item.Maak = reader("maak")
                    End If
                    If reader("besk") IsNot DBNull.Value Then
                        item.Besk = reader("besk")
                    End If
                    If reader("eeu") IsNot DBNull.Value Then
                        item.EEU = reader("eeu")
                    End If
                    If reader("jaar") IsNot DBNull.Value Then
                        item.JAAR = reader("jaar")
                    End If
                    If reader("n_plaat") IsNot DBNull.Value Then
                        item.N_PLAAT = reader("n_plaat")
                    End If
                    If reader("PremieVoertuig") IsNot DBNull.Value Then
                        item.PREMIE = reader("PremieVoertuig")
                    End If
                    If reader("pkVoertuie") IsNot DBNull.Value Then
                        item.PREMIE = reader("pkVoertuie")
                    End If
                End While
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function

    Private Sub optPolis_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optPolis.CheckedChanged
        If eventSender.Checked Then
            Me.lstInsuredItems.Enabled = False
            'Me.lstInsuredItems.Items.Clear()
            lstInsuredItems.DataSource = Nothing
        End If
    End Sub
    Public Sub populateLstInsuredItems()


        'Dim rsVehicles As DAO.Recordset
        lstInsuredItems.DisplayMember = "bevestigDesc"
        lstInsuredItems.ValueMember = "bevestigCode"
        'Dim rsProperty As DAO.Recordset
        lstInsuredItems.DataSource = bevestigDescFunction()
        ''Vehicles
        'sSql = "SELECT voertuie.*, motors.maak, motors.besk FROM voertuie "
        'sSql = sSql & " LEFT JOIN motors ON voertuie.kode = motors.kode AND voertuie.eeu = motors.eeu AND voertuie.jaar = motors.jaar"
        'sSql = sSql & " WHERE not ander AND polisno = '" & Persoonl.Fields("polisno").Value & "' AND cancelled = false"
        'sSql = sSql & " UNION"
        'sSql = sSql & " SELECT voertuie.*, a_voertuig.maak, a_voertuig.besk FROM voertuie "
        'sSql = sSql & " LEFT JOIN a_voertuig ON voertuie.kode = a_voertuig.kode AND voertuie.eeu = a_voertuig.eeu AND voertuie.jaar = a_voertuig.jaar "
        'sSql = sSql & " WHERE ander AND polisno = '" & Persoonl.Fields("polisno").Value & "' AND cancelled = false"
        'sSql = sSql & "  ORDER BY motors.maak"
        'rsVehicles = dbPoldata.OpenRecordset(sSql)
        ' rsVoertuieForPrint2 = FetchVoertuieForPrint()

        'Do While Not rsVoertuieForPrint2.NoMatch
        'Me.lstInsuredItems.Items.Add("Voertuig   : " & Trim(rsVoertuieForPrint2.maak) & " " & Trim(rsVoertuieForPrint2.besk) & " " & rsVoertuieForPrint2.eeu & rsVoertuieForPrint2.jaar & " " & Trim(rsVoertuieForPrint2.plaat))

        'VB6.SetItemData(Me.lstInsuredItems, lstInsuredItems.NewIndex, rsVoertuieForPrint2.pkVoertuie)
        'rsVehicles.MoveNext()
        'Loop

        'sSql = "SELECT voertuie.*, motors.maak, motors.besk FROM voertuie "
        'sSql = sSql & " LEFT JOIN motors ON voertuie.kode = motors.kode AND voertuie.eeu = motors.eeu AND voertuie.jaar = motors.jaar"
        'sSql = sSql & " WHERE not ander AND polisno = '" & Persoonl.Fields("polisno").Value & "' AND cancelled = true"
        'sSql = sSql & " UNION"
        'sSql = sSql & " SELECT voertuie.*, a_voertuig.maak, a_voertuig.besk FROM voertuie "
        'sSql = sSql & " LEFT JOIN a_voertuig ON voertuie.kode = a_voertuig.kode AND voertuie.eeu = a_voertuig.eeu AND voertuie.jaar = a_voertuig.jaar "
        'sSql = sSql & " WHERE ander AND polisno = '" & Persoonl.Fields("polisno").Value & "' AND cancelled = true"
        'sSql = sSql & "  ORDER BY motors.maak"
        'rsVehicles = dbPoldata.OpenRecordset(sSql)

        'Do While Not rsVehicles.EOF

        'rsVoertuieForPrint3 = FetchVoertuieForPrint2()
        '	VB6.SetItemData(Me.lstInsuredItems, lstInsuredItems.NewIndex, rsVehicles.Fields("pkVoertuie").Value)
        '	rsVehicles.MoveNext()
        'Me.lstInsuredItems.Items.Add("* Voertuig  : " & Trim(rsVoertuieForPrint3.maak) & " " & Trim(rsVoertuieForPrint3.besk) & " " & rsVoertuieForPrint3.eeu & rsVoertuieForPrint3.jaar & " " & Trim(rsVoertuieForPrint3.plaat))
        'Loop 

        ''Property
        'sSql = "SELECT * FROM huis WHERE polisno = '" & Persoonl.Fields("polisno").Value & "' AND cancelled = false"
        'rsProperty = dbPoldata.OpenRecordset(sSql)

        'rsProperty = FetchHuisForPrint2_Report()

        'Do While Not rsProperty.EOF
        'If rsProperty.WAARDE_HB <> 0 Then
        ''Me.lstInsuredItems.Items.Add("Eiendom HB  " & Space(11) & ": " & Trim(rsProperty.ADRES_H1) & " " & Trim(rsProperty.Adres4) & " " & Trim(rsProperty.voorstad))

        'VB6.SetItemData(Me.lstInsuredItems, lstInsuredItems.NewIndex, rsProperty.Fields("pkHuis").Value)
        ' End If

        ' If rsProperty.WAARDE_HE <> 0 Then
        'Me.lstInsuredItems.Items.Add("Eiendom HE  " & Space(11) & ": " & Trim(rsProperty.ADRES_H1) & " " & Trim(rsProperty.Adres4) & " " & Trim(rsProperty.voorstad))

        'VB6.SetItemData(Me.lstInsuredItems, lstInsuredItems.NewIndex, rsProperty.Fields("pkHuis").Value)
        ' End If
        '	rsProperty.MoveNext()
        'Loop 

        'sSql = "SELECT * FROM huis WHERE polisno = '" & Persoonl.Fields("polisno").Value & "' AND cancelled = true"
        'rsProperty = dbPoldata.OpenRecordset(sSql)
        ' rsProperty = FetchHuisForPrint2_Report1()
        'Do While Not rsProperty.EOF
        'Do While Not rsProperty.NoMatch

        ' If rsProperty.WAARDE_HB <> 0 Then
        'Me.lstInsuredItems.Items.Add("* Eiendom HB: " & Trim(rsProperty.ADRES_H1) & " " & Trim(rsProperty.Adres4) & " " & Trim(rsProperty.voorstad))

        'VB6.SetItemData(Me.lstInsuredItems, lstInsuredItems.NewIndex, rsProperty.Fields("pkHuis").Value)
        ' End If

        '  If rsProperty.WAARDE_HE <> 0 Then
        'Me.lstInsuredItems.Items.Add("* Eiendom HE: " & Trim(rsProperty.ADRES_H1) & " " & Trim(rsProperty.Adres4) & " " & Trim(rsProperty.voorstad))

        'VB6.SetItemData(Me.lstInsuredItems, lstInsuredItems.NewIndex, rsProperty.Fields("pkHuis").Value)
        ' End If

        '	rsProperty.MoveNext()
        'Loop

    End Sub
    Public Function FetchHuisForPrint2_Report1() As HuisEntity

        Dim item As HuisEntity = New HuisEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)

                param.Value = Persoonl.POLISNO

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchHuisByPersoon_For_Tax2]", param)
                While reader.Read
                    If reader("ADRES_H1") IsNot DBNull.Value Then
                        item.ADRES_H1 = reader("ADRES_H1")

                    End If
                    If reader("Adres4") IsNot DBNull.Value Then
                        item.Adres4 = reader("Adres4")
                    End If
                    If reader("voorstad") IsNot DBNull.Value Then
                        item.voorstad = reader("voorstad")
                    End If
                    If reader("WAARDE_HE") IsNot DBNull.Value Then
                        item.WAARDE_HE = reader("WAARDE_HE")
                    End If
                    If reader("PREMIE_HE") IsNot DBNull.Value Then
                        item.PREMIE_HE = reader("PREMIE_HE")
                    End If
                    If reader("PREMIE_HB") IsNot DBNull.Value Then
                        item.PREMIE_HB = reader("PREMIE_HB")
                    End If
                    If reader("eem_premie") IsNot DBNull.Value Then
                        item.EEM_PREMIE = reader("eem_premie")
                    End If
                    If reader("eem_waarde") IsNot DBNull.Value Then
                        item.EEM_WAARDE = reader("eem_waarde")
                    End If
                    If reader("toe_waarde") IsNot DBNull.Value Then
                        item.TOE_WAARDE = reader("toe_waarde")
                    End If
                End While
                'If reader.Read() Then

                'End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function
    Public Function FetchHuisForPrint2_Report() As HuisEntity

        Dim item As HuisEntity = New HuisEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)

                param.Value = Persoonl.POLISNO

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchHuisByPersoon_For_Tax]", param)
                While reader.Read
                    If reader("ADRES_H1") IsNot DBNull.Value Then
                        item.ADRES_H1 = reader("ADRES_H1")

                    End If
                    If reader("Adres4") IsNot DBNull.Value Then
                        item.Adres4 = reader("Adres4")
                    End If
                    If reader("voorstad") IsNot DBNull.Value Then
                        item.voorstad = reader("voorstad")
                    End If
                    If reader("WAARDE_HE") IsNot DBNull.Value Then
                        item.WAARDE_HE = reader("WAARDE_HE")
                    End If
                    If reader("PREMIE_HE") IsNot DBNull.Value Then
                        item.PREMIE_HE = reader("PREMIE_HE")
                    End If
                    If reader("PREMIE_HB") IsNot DBNull.Value Then
                        item.PREMIE_HB = reader("PREMIE_HB")
                    End If
                    If reader("eem_premie") IsNot DBNull.Value Then
                        item.EEM_PREMIE = reader("eem_premie")
                    End If
                    If reader("eem_waarde") IsNot DBNull.Value Then
                        item.EEM_WAARDE = reader("eem_waarde")
                    End If
                    If reader("toe_waarde") IsNot DBNull.Value Then
                        item.TOE_WAARDE = reader("toe_waarde")
                    End If
                End While
                'If reader.Read() Then

                'End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function
    Public Sub insertVehicleDetail(ByRef pkVoertuie As Integer, Optional ByRef blnRemovedItem As Boolean = False)
        Dim k As Object
        'Dim rs1 As Object
        'Dim strSql As Object

        'Dim rsVehicles As DAO.Recordset
        Dim arPremies() As String
        Dim arPremiesRegNom() As String
        Dim dblMotorpremie As Double
        Dim strMotorRegNom As String
        'dblItembedrag = 0

        'sSql = "SELECT voertuie.*, motors.maak, motors.besk FROM voertuie "
        'sSql = sSql & " LEFT JOIN motors ON voertuie.kode = motors.kode AND voertuie.eeu = motors.eeu AND voertuie.jaar = motors.jaar"
        'sSql = sSql & " WHERE not ander AND pkVoertuie = " & pkVoertuie
        'sSql = sSql & " UNION"
        'sSql = sSql & " SELECT voertuie.*, a_voertuig.maak, a_voertuig.besk FROM voertuie "
        'sSql = sSql & " LEFT JOIN a_voertuig ON voertuie.kode = a_voertuig.kode AND voertuie.eeu = a_voertuig.eeu AND voertuie.jaar = a_voertuig.jaar "
        'sSql = sSql & " WHERE ander AND pkVoertuie = " & pkVoertuie
        'sSql = sSql & "  ORDER BY motors.maak"

        'rsVehicles = dbPoldata.OpenRecordset(sSql)
        rsVoertuie = FetchVoertuieForPrint()
        'If Not (rsVehicles.EOF) Then
        strItem = "'" & Trim(rsVoertuie.Maak) & " " & Trim(rsVoertuie.Besk) & ", " & rsVoertuie.EEU & rsVoertuie.JAAR & ", " & Trim(rsVoertuie.N_PLAAT)
        If language = 0 Then
            strKlas = "Voertuig"
        Else
            strKlas = "Vehicle"
        End If


        '	strSql = "SELECT * from (md_print_dat "

        '	strSql = strSql & " LEFT JOIN md_print2_dat on md_print2_dat.polisno = md_print_dat.polisno)"

        '	strSql = strSql & " WHERE md_print_dat.Afsluitdatum = cdate('" & rs.Fields("afsluit_dat").Value & "') "

        '	strSql = strSql & " AND md_print_dat.polisno = '" & Persoonl.Fields("polisno").Value & "'"

        '	strSql = strSql & " AND md_print_dat.Afsluitdatum = md_print2_dat.Afsluitdatum "

        '	rs1 = dbStats.OpenRecordset(strSql)
        rsPrintVoertuie = Fetch_MD_Print2()

        '	Do While Not rs1.BOF And Not rs1.EOF

        arPremies = Split((rsPrintVoertuie.MPREMIE), Chr(10) & Chr(13))

        arPremiesRegNom = Split((rsPrintVoertuie.REG), Chr(10) & Chr(13))

        For k = 0 To UBound(arPremies)

            If arPremies(k) <> "" Then

                dblMotorpremie = CDbl(Format(arPremies(k), "0.00") & Chr(10) & Chr(13))

                strMotorRegNom = arPremiesRegNom(k) & Chr(10) & Chr(13)

                If arPremiesRegNom(k) = rsVoertuie.N_PLAAT Then


                    dblItembedrag = CDbl(arPremies(k)) * rsPrintVoertuie.eispers
                End If
            End If
        Next k

        '		rs1.MoveNext()
        '	Loop 
        'Else
        '	MsgBox("This vehicle is not found in the database, contact the computer department.", MsgBoxStyle.Information)
        '	Me.Show()
        '	Exit Sub
        'End If

    End Sub
    Function bevestigDescFunction()

        Dim list As List(Of BevestigDescEntity) = New List(Of BevestigDescEntity)
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                param.Value = Persoonl.POLISNO

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[GetInsuredItem22]", param)
                While reader.Read()
                    Dim item As BevestigDescEntity = New BevestigDescEntity()
                    If reader("bevestigDesc") IsNot DBNull.Value Then
                        item.bevestigDesc = reader("bevestigDesc")
                        item.bevestigCode = reader("bevestigCode")
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
    'CoverType: HH - HouseHolders, HO - HouseOwners
    Public Sub insertPropertyDetail(ByRef pkHuis As Integer, ByRef CoverType As String, Optional ByRef blnRemovedItem As Boolean = False)
        Dim k As Object
        'Dim rs1 As Object
        'Dim strSql As Object

        'Dim rsProperty As DAO.Recordset
        Dim arPremies() As String
        Dim arPremiesAdres() As String
        Dim arPremiesCovertype() As String
        'Dim strCovertype As String
        Dim dblHuispremie As Double
        Dim strHuisadres As String
        Dim strHeHb As String
        dblItembedrag = 0

        ''Get the property detail
        'sSql = "SELECT * FROM huis"
        'sSql = sSql & " WHERE pkHuis = " & pkHuis

        rsProperty = GetHuisByPrimaryKey(pkHuis)



        'rsProperty = dbPoldata.OpenRecordset(sSql)

        'If Not (rsProperty.EOF And rsProperty.BOF) Then
        strItem = "'" & Trim(rsProperty.ADRES_H1) & ", " & Trim(rsProperty.Adres4) & ", " & Trim(rsProperty.voorstad)
        If language = 0 Then
            If CoverType = "HE" Then
                strKlas = "Huiseienaar"
            Else
                strKlas = "Huisbewoner"
            End If
        Else
            If CoverType = "HE" Then
                strKlas = "Homeowner"
            Else
                strKlas = "Householder"
            End If
        End If

        '	strSql = "SELECT * from md_print2_dat "
        '	strSql = strSql & "WHERE Afsluitdatum = cdate('" & rs.Fields("afsluit_dat").Value & "') "
        '	strSql = strSql & " AND polisno = '" & Persoonl.Fields("polisno").Value & "'"

        '	rs1 = dbStats.OpenRecordset(strSql)

        rs1PropertyForPrint = FetchHuisForPrint()



        '	Do While Not rs1.BOF And Not rs1.EOF

        arPremies = Split((rs1PropertyForPrint.Huispremie), Chr(10) & Chr(13))

        arPremiesAdres = Split((rs1PropertyForPrint.huisadres), Chr(10) & Chr(13))

        arPremiesCovertype = Split((rs1PropertyForPrint.hehb), Chr(10) & Chr(13))

        For k = 0 To UBound(arPremies)

            If arPremies(k) <> "" Then

                dblHuispremie = CDbl(Format(arPremies(k), "0.00") & Chr(10) & Chr(13))

                strHuisadres = arPremiesAdres(k) & Chr(10) & Chr(13)

                strHeHb = arPremiesCovertype(k) & Chr(10) & Chr(13)

                If arPremiesAdres(k) = rsProperty.ADRES_H1 Then

                    If CoverType = arPremiesCovertype(k) Then


                        dblItembedrag = CDbl(arPremies(k)) * rs1PropertyForPrint.eispers 'rs1("eispers")
                    End If
                End If
            End If
        Next k

        'rs1.MoveNext()
        'Loop 
        ' Else
        MsgBox("This property is not found in the database, please contact the IT department.", MsgBoxStyle.Information)
        Me.Show()
        Exit Sub
        'End If
    End Sub
    Public Function FetchHuisForPrint() 'As Print2DatEntity
        Dim item As Print2DatEntity = New Print2DatEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                          New SqlParameter("@Afsluitdatum", SqlDbType.Date)}

                param(0).Value = Persoonl.POLISNO
                param(1).Value = rsPrint2.afsluitdatum

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[Stats5d].[md_Print2Data_Afsluit]", param)

                While reader.Read()
                    If reader("huisadres") IsNot DBNull.Value Then
                        item.huisadres = reader("huisadres")
                    End If
                    If reader("hehb") IsNot DBNull.Value Then
                        item.hehb = reader("hehb")
                    End If

                    If reader("Huispremie") IsNot DBNull.Value Then
                        item.Huispremie = reader("Huispremie")
                    End If
                    If reader("Verwyskommissie") IsNot DBNull.Value Then
                        item.Verwyskommissie = reader("Verwyskommissie")
                    End If
                    If reader("Premie2") IsNot DBNull.Value Then
                        item.Premie2 = reader("Premie2")
                    End If
                    If reader("Polisno") IsNot DBNull.Value Then
                        item.Polisno = reader("Polisno")
                    End If
                    If reader("Afsluit_dat") IsNot DBNull.Value Then
                        item.Afsluit_dat = reader("Afsluit_dat")
                    End If
                    If reader("ongespesifiseerd") IsNot DBNull.Value Then
                        item.ongespesifiseerd = reader("ongespesifiseerd")
                    End If
                    If reader("ongevalle") IsNot DBNull.Value Then
                        item.ongevalle = reader("ongevalle")
                    End If
                    If reader("courtesyv") IsNot DBNull.Value Then
                        item.courtesyv = reader("courtesyv")
                    End If
                    If reader("afsluitdatum") IsNot DBNull.Value Then
                        item.afsluitdatum = reader("afsluitdatum")
                    End If
                    If reader("alle_sub") IsNot DBNull.Value Then
                        item.alle_sub = reader("alle_sub")
                    End If
                    If reader("huis_sub") IsNot DBNull.Value Then
                        item.huis_sub = reader("huis_sub")
                    End If
                    If reader("motor_sub") IsNot DBNull.Value Then
                        item.motor_sub = reader("motor_sub")
                    End If
                    If reader("id_nom") IsNot DBNull.Value Then
                        item.id_nom = reader("id_nom")
                    End If
                    If reader("bybet_k") IsNot DBNull.Value Then
                        item.bybet_k = reader("bybet_k")
                    End If
                    If reader("eispers") IsNot DBNull.Value Then
                        item.eispers = reader("eispers")
                    End If
                    If reader("toe_waarde") IsNot DBNull.Value Then
                        item.toe_waarde = reader("toe_waarde")
                    End If
                    If reader("toe_premie") IsNot DBNull.Value Then
                        item.toe_premie = reader("toe_premie")
                    End If
                    If reader("eem_waarde") IsNot DBNull.Value Then
                        item.eem_waarde = reader("eem_waarde")
                    End If
                    If reader("eem_premie") IsNot DBNull.Value Then
                        item.eem_premie = reader("eem_premie")
                    End If
                    If reader("epc") IsNot DBNull.Value Then
                        item.epc = reader("epc")
                    End If
                    If reader("inscell") IsNot DBNull.Value Then
                        item.inscell = reader("inscell")
                    End If
                    If reader("AddisionelePremie") IsNot DBNull.Value Then
                        item.AddisionelePremie = reader("AddisionelePremie")
                    End If
                    If reader("PersoonlAddisionelePremie") IsNot DBNull.Value Then
                        item.PersoonlAddisionelePremie = reader("PersoonlAddisionelePremie")
                    End If
                    If reader("bet_wyse") IsNot DBNull.Value Then
                        item.bet_wyse = reader("bet_wyse")
                    End If
                End While
                Return item
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function

    Public Function Fetch_MD_Print2() 'As Print2DatEntity
        Dim item As md_Print_Dat = New md_Print_Dat()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                          New SqlParameter("@afsluit_dat", SqlDbType.Date)}

                param(0).Value = Persoonl.POLISNO
                param(1).Value = rs1PropertyForPrint.Afsluit_dat

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[Stats5d].[stats5d.MD_Print_Dat_Voertuig]", param)

                While reader.Read()

                    If reader("Polisno") IsNot DBNull.Value Then
                        item.POLISNO = reader("Polisno")
                    End If
                    If reader("Afsluit_dat") IsNot DBNull.Value Then
                        item.Afsluit_dat = reader("Afsluit_dat")
                    End If

                    If reader("afsluitdatum") IsNot DBNull.Value Then
                        item.afsluitdatum = reader("afsluitdatum")
                    End If

                    If reader("eispers") IsNot DBNull.Value Then
                        item.eispers = reader("eispers")
                    End If
                    If reader("mpremie") IsNot DBNull.Value Then
                        item.MPREMIE = reader("mpremie")
                    End If
                    If reader("reg") IsNot DBNull.Value Then
                        item.REG = reader("reg")
                    End If

                End While
                Return item
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class