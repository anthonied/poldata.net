Option Strict Off
Option Explicit On

Imports System.Data.SqlClient
Imports DAL
Imports System.IO
Imports Microsoft.Reporting.WinForms
Imports System.Net
Imports System.Configuration

Friend Class BriefOpskort
    Inherits BaseForm

    'Description: Generate letter of Suspension of cover
    Dim rownumber As Short
    Dim language As Byte
    Dim strAreaBranch As String
    Public delay As Short
    Public Rede As String
    Public ListItemDesc As String
    Public ListItemValue As String
    Public OpskortTaal As Integer
    Public Adres1 As String
    Public Adres2 As String
    Public Adres3 As String
    Public Adres4 As String
    Public Adres5 As String
    Public result As Byte() = Nothing
    Dim tempFilename As String

    Private Sub btnClear_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClear.Click

        Me.txtPoskode.Text = ""
        Me.txtVoorstad.Text = ""
    End Sub

    Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click
        Me.delay = 30000 'milliseconds
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
        If rdAfrikaans.Checked Then
            OpskortTaal = 0
        ElseIf rdEngels.Checked Then
            OpskortTaal = 1
        End If

        'Check if an item was selected
        If Me.lstInsuredItems.SelectedIndex = -1 Then
            MsgBox("The item in question must be selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        'Check if a reason for the suspension was selected
        If Me.ddlRede.SelectedIndex = -1 Then
            MsgBox("Please select a reason for the suspension", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim BevestigDescEntity As New BevestigDescEntity
        BevestigDescEntity = lstInsuredItems.SelectedItem
        ListItemDesc = BevestigDescEntity.bevestigDesc
        ListItemValue = lstInsuredItems.SelectedValue

        Rede = ddlRede.SelectedIndex
        Adres1 = cmbTitel.Text + " " + txtVoorletter.Text + " " + txtVan.Text
        Adres2 = txtAdres1.Text
        Adres3 = txtAdres2.Text
        Adres4 = txtVoorstad.Text
        Adres5 = txtPoskode.Text

        If Adres1 = "" Then
            Adres1 = " "
        End If

        If Adres2 = "" Then
            Adres2 = " "
        End If

        If Adres3 = "" Then
            Adres3 = " "
        End If

        If Adres4 = "" Then
            Adres4 = " "
        End If

        If Adres5 = "" Then
            Adres5 = " "
        End If

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
                gen_ArchiveDocument(result, Persoonl.POLISNO, 13, "", "", "", "")
            ElseIf rdEpos.Checked Then
                CreateReportFile()
                gen_ArchiveDocument(result, Persoonl.POLISNO, 13, emailEngine.txtSubject.Text, emailEngine.txtTo.Text, emailEngine.txtBody.Text, getAttachmentsForEmailEngine, tempFilename)
                emailEngine.sendMail(emailEngine.txtTo.Text, emailEngine.txtSubject.Text, emailEngine.txtBody.Text, tempFilename)
            End If
            Exit Sub
        Else
            BriefOpskortReportViewer.Show()
            Exit Sub
        End If

    End Sub
    Sub CreateReportFile()
        Dim detailStream As Stream
        detailStream = createDetailFile("/Mooirivier/BriefOpskort")
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
            Dim PropertyCoverType As String
            Dim Security As String

            Select Case Trim(Mid(ListItemDesc, 1, 12))
                Case "Voertuig :"
                    PropertyCoverType = " "
                Case "* Voertuig :"
                    PropertyCoverType = " "
                Case "Eiendom HE:"
                    PropertyCoverType = "HO"
                Case "Eiendom HB:"
                    PropertyCoverType = "HH"
                Case "* Eiendom HE"
                    PropertyCoverType = "HO"
                Case "* Eiendom HB"
                    PropertyCoverType = "HH"
                Case Else
                    PropertyCoverType = " "
            End Select


            Dim huis As HuisEntity
            huis = GetHuisByPrimaryKey(ListItemValue)
            Security = gen_getPropertySecurity(Persoonl.TAAL, huis.SekuriteitBitValue)

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", Persoonl.POLISNO), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", OpskortTaal), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Rede", Rede), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Voertuig", ListItemValue), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("PropertyCoverType", PropertyCoverType), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Huis", ListItemValue), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("gen_getPropertySecurity", Security), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Address1", Adres1), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Address2", Adres2), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Address3", Adres3), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Address4", Adres4), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Address5", Adres5)}

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
            Return Nothing
            MsgBox(ex.Message)
        End Try
    End Function
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

    Private Sub btnPostalCodes_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnPostalCodes.Click
        PoskodesSoek.txtFormToPopulate.Text = Me.Name
        PoskodesSoek.ShowDialog()
    End Sub
    Private Sub BriefOpskort_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Populatefields()
        'Andriette 16/08/2013 gebrukk die global polisnommer
        '     If Trim(Form1.POLISNO.Text) = "" Then
        If Trim(glbPolicyNumber) = "" Then
            MsgBox("First, select a policy for which the confirmation must be printed.", MsgBoxStyle.Exclamation)
            Me.Close()
        End If
        Me.cmbTitel.SelectedIndex = -1

        lstInsuredItems.DisplayMember = "bevestigDesc"
        lstInsuredItems.ValueMember = "bevestigCode"
        lstInsuredItems.DataSource = bevestigDescFunction()

        '    cmbTitel.DataSource = ListTitle(language)

        '    'Populate list
        '    populateLstInsruredItems()

        Me.Text = My.Application.Info.Title & " - Letters - Suspension of coverage notice"
    End Sub
    Sub Populatefields()
        cmbTitel.DataSource = ListTitle(Integer.Parse(Persoonl.TAAL))
        cmbTitel.DisplayMember = "Title"
        cmbTitel.SelectedItem = Persoonl.TITEL

        Me.cmbTitel.Enabled = True
    End Sub
    ''Generate the letter
    Public Sub createLetter()
        '    Dim attachList As Object
        '    Dim message As Object
        '    Dim rsMakelaarSql As Object
        '    Dim rsAreaBrief As Object
        '    Dim rsPersoonl As Object
        '    Dim letterSubject As String
        '    Dim blnUserControl As Boolean
        '    Dim archiveCategory As Byte
        '    Dim tempFilename As String

        '    'Destination = email
        '    If Me.rdEpos.Checked Then
        '        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '        If emailEngine.signOn Then
        '            emailEngine.txtTo.Text = Persoonl.EMAIL
        '            emailEngine.ShowDialog()

        '            'If cancel was clicked - abort process else continue
        '            If Not emailEngine.returnValue Then
        '                emailEngine.signOff()
        '                emailEngine.Close()
        '                Exit Sub
        '            End If
        '        Else
        '            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '            Exit Sub
        '        End If
        '    End If

        '    'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        '    lblStatus.Text = "Laai Microsoft® Excel"

        '    '   letterhead_createExcelObject(xlapp, blnUserControl)
        '    '   xlbook = xlapp.Workbooks.Open("c:\polis5\docs\report.xls")
        '    '   xlsheet = xlbook.Worksheets(1)

        '    '   rsPersoonl = Persoonl

        '    '   xlapp.DisplayAlerts = False

        '    '   lblStatus.Text = "Genereer Opskort van dekking kennisgewing"
        '    '   Me.Refresh()

        '    '   rsAreaBrief = dbPoldata.OpenRecordset("SELECT * FROM area WHERE area_kode = '" & Persoonl.Area & "'")

        '    '   'UPGRADE_WARNING: Couldn't resolve default property of object rsAreaBrief(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '   rsMakelaarSql = dbPoldata.OpenRecordset("SELECT * FROM Makelaar where pkmakelaar = " & rsAreaBrief("fkmakelaar"))
        '    '   'UPGRADE_WARNING: Couldn't resolve default property of object rsMakelaarSql(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '   xlsheet.Shapes.AddPicture(getAdminPath & "Logo\" & rsMakelaarSql("Makelaar_logo"), True, True, ExcelGlobal_definst.Cells.Left, ExcelGlobal_definst.Cells.Top, 480, 70)

        '    '   If language = 0 Then
        '    '       letterSubject = "Opskort van dekking"
        '    '   Else
        '    '       letterSubject = "Suspension of cover"
        '    '   End If

        '    '   letterhead_setStyle(xlsheet, 100, 12, language, False, Persoonl.POLISNO)

        '    '   'UPGRADE_WARNING: Couldn't resolve default property of object rsPersoonl(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '   strAreaBranch = rsPersoonl("area")

        '    '   letterhead_setBranch(xlsheet, language, 5, 12, strAreaBranch)

        '    '   letterhead_setAddress(xlsheet, 9, 3, language, gen_getTitleDesc(language, (Me.cmbTitel.SelectedIndex)), (Me.txtVoorletter).Text, (Me.txtVan).Text, (Me.txtAdres1).Text, (Me.txtAdres2).Text, (Me.txtVoorstad).Text, (Me.txtPoskode).Text)

        '    '   letterhead_setSubject(xlsheet, 26, 12, language, letterSubject, Persoonl.POLISNO, gen_getTitleDesc(language, (cmbTitel.SelectedIndex)), (Me.txtVan).Text, True)

        '    '   'Set line
        '    '   letterhead_setLine(xlsheet, "A4", "L4")

        '    '   'Set special column widths
        '    '   'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Columns().ColumnWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '   xlsheet.Columns._Default("G").ColumnWidth = 4
        '    '   'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Columns().ColumnWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '   xlsheet.Columns._Default("I").ColumnWidth = 10

        '    '   'Footer - overide the footer set with letterhead_setStyle
        '    '   If language = 0 Then
        '    '       xlsheet.PageSetup.RightFooter = "&6Bladsy &p van &n"
        '    '   Else
        '    '       xlsheet.PageSetup.RightFooter = "&6Page &p of &n"
        '    '   End If
        '    'xlsheet.PageSetup.RightHeader = "&6 " & gen_getTitleDesc(language, Persoonl.titelnum & ". " & Persoonl.voorl & " " & Persoonl.versekerde & " (" & Persoonl.polisno & ")"

        '    '   'Insert greeting
        '    '   rownumber = 29
        '    '   If language = 0 Then
        '    '       'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '       xlsheet.Cells._Default(rownumber, 1).value = "Wie dit mag aangaan"
        '    '   Else
        '    '       'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '       xlsheet.Cells._Default(rownumber, 1).value = "To whom it may concern"
        '    '   End If

        '    '   rownumber = 31

        '    '   'Set the style of the letter introduction
        '    '   With xlsheet.Range("A" & rownumber & ":L" & rownumber)
        '    '       .Cells.Merge()
        '    '       .RowHeight = 34.5
        '    '       .VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop
        '    '       .HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlJustify
        '    '       .WrapText = True
        '    '   End With

        '    '   'Letter introduction
        '    '   If language = 0 Then
        '    '       Select Case Me.ddlRede.SelectedIndex
        '    '           Case 0 'Policy cancelled
        '    '               'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '               message = "Ons stel u hiermee in kennis dat die betrokke polishouer sy korttermynversekeringspolis gekanselleer het "
        '    '               'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '               message = message & "en dat u belange hierdeur benadeel word."
        '    '           Case 1 'Item removed
        '    '               'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '               message = "Ons stel u hiermee in kennis dat die betrokke polishouer dekking ten opsigte van die vermelde item gestaak het "
        '    '               'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '               message = message & "en dat u belange hierdeur benadeel word."
        '    '           Case 2 'VT
        '    '               'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '               message = "Ons stel u hiermee in kennis dat die betrokke polishouer nagelaat het om die maandelikse premie te betaal en dat hy/sy geen dekking geniet nie.  "
        '    '               'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '               message = message & "U belange word dus hierdeur benadeel."
        '    '       End Select
        '    '   Else
        '    '       Select Case Me.ddlRede.SelectedIndex
        '    '           Case 0 'Policy cancelled
        '    '               'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '               message = "This letter serves as notification that the policyholder cancelled his/her short term insurance policy "
        '    '               'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '               message = message & "and that your interests are at risk."
        '    '           Case 1 'Item removed
        '    '               'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '               message = "This letter serves as notification that the policyholder cancelled the cover on the specified item "
        '    '               'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '               message = message & "and that your interests are at risk."
        '    '           Case 2 'VT
        '    '               'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '               message = "This letter serves as notification that the policyholder failed to pay the montly premium resulting in no cover "
        '    '               'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '               message = message & "and that your interests are at risk."
        '    '       End Select
        '    '   End If
        '    '   'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '   'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '   xlsheet.Cells._Default(rownumber, 1).value = message

        '    '   rownumber = rownumber + 1

        '    '   'Insert policy holder detail
        '    '   insertPolicyHolderDetail()
        '    '   rownumber = rownumber + 2

        '    '   'Insert item detail
        '    '   'Check for property or vehicle
        '    '   Select Case Trim(VB.Left(Me.lstInsuredItems.Text, 12))
        '    '       Case "Voertuig"
        '    '           insertVehicleDetail(VB6.GetItemData(Me.lstInsuredItems, lstInsuredItems.SelectedIndex), False)
        '    '       Case "* Voertuig"
        '    '           insertVehicleDetail(VB6.GetItemData(Me.lstInsuredItems, lstInsuredItems.SelectedIndex), True)
        '    '       Case "Eiendom HE"
        '    '           insertPropertyDetail(VB6.GetItemData(Me.lstInsuredItems, lstInsuredItems.SelectedIndex), "HO", False)
        '    '       Case "Eiendom HB"
        '    '           insertPropertyDetail(VB6.GetItemData(Me.lstInsuredItems, lstInsuredItems.SelectedIndex), "HH", False)
        '    '       Case "* Eiendom HE"
        '    '           insertPropertyDetail(VB6.GetItemData(Me.lstInsuredItems, lstInsuredItems.SelectedIndex), "HO", True)
        '    '       Case "* Eiendom HB"
        '    '           insertPropertyDetail(VB6.GetItemData(Me.lstInsuredItems, lstInsuredItems.SelectedIndex), "HH", True)
        '    '   End Select

        '    '   'Insert closing comments on letter
        '    '   rownumber = rownumber + 2
        '    '   With xlsheet.Range("A" & rownumber & ":L" & rownumber)
        '    '       .Cells.Merge()
        '    '       .RowHeight = 24.75
        '    '       .VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop
        '    '       .HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlJustify
        '    '       .WrapText = False
        '    '   End With

        '    '   If language = 0 Then
        '    '       'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '       xlsheet.Cells._Default(rownumber, 1).value = "Moet asseblief nie huiwer om met ons in verbinding te tree indien u enige verdere inligting benodig in die verband."
        '    '       'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '       xlsheet.Cells._Default(rownumber + 2, 1).value = "Die uwe"
        '    '   Else
        '    '       'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '       xlsheet.Cells._Default(rownumber, 1).value = "Should you have any further inquiries you are welcome to contact us in this regard."
        '    '       'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    '       xlsheet.Cells._Default(rownumber + 2, 1).value = "Yours faithfully"
        '    '   End If

        '    'Printer / Email
        '    If Me.rdDrukker.Checked Then 'Print
        '        'Arhive document
        '        gen_ArchiveDocument(xlbook, 1, Persoonl.POLISNO, archiveCategory, "", "", "", "")

        '        'Preview letter
        '        xlapp.Visible = True
        '        xlsheet.PrintPreview()
        '        xlbook.Close()
        '        xlapp.Quit()
        '    ElseIf Me.rdEpos.Checked Then  'Email
        '        'UPGRADE_WARNING: Couldn't resolve default property of object attachList. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        gen_ArchiveDocument(xlbook, 1, Persoonl.POLISNO, 13, (emailEngine.txtSubject).Text, (emailEngine.txtTo).Text, (emailEngine.txtBody).Text, CStr(attachList), tempFilename)

        '        'email file as attachment
        '        emailEngine.sendMail((emailEngine.txtTo).Text, (emailEngine.txtSubject).Text, (emailEngine.txtBody).Text, tempFilename)
        '    End If

        '    'If the document was emailed - sign-off
        '    If Me.rdEpos.Checked Then
        '        emailEngine.signOff()
        '        'Unload form
        '        emailEngine.Close()
        '    End If

        '    lblStatus.Text = "Kennisgewing is gedruk/ge-epos"
        '    Me.Refresh()
        '    'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        '    'Close form
        '    btnClose_Click(btnClose, New System.EventArgs())
    End Sub
    Public Sub insertPolicyHolderDetail()
        '    Dim address1 As String
        '    Dim address2 As String
        '    Dim Suburb As String
        '    Dim Postalcode As String

        '    'Insert heading
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Rows._Default(rownumber).Font.Bold = True
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Rows._Default(rownumber).Font.Size = 9

        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 1).value = "'1. "

        '    If language = 0 Then
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber, 2).value = "BESONDERHEDE VAN DIE VERSEKERDE"
        '    Else
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber, 2).value = "PARTICULARS OF THE INSURED"
        '    End If

        '    rownumber = rownumber + 1

        '    'Bold headings
        '    With xlsheet.Range("B" & rownumber + 1 & ":B" & rownumber + 9)
        '        .Font.Bold = True
        '    End With

        '    'Get the address of the mainproperty for this policy
        '    gen_getPropertyMainAddress(Persoonl.POLISNO, address1, address2, Suburb, Postalcode)

        '    If language = 0 Then
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 1, "B").value = "Versekerde"
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 2, "B").value = "Polisnommer"
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 3, "B").value = "ID nommer"
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 4, "B").value = "Adres"
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 5, "B").value = "Telefoon (h)"
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 6, "B").value = "Telefoon (w)"
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 7, "B").value = "Selfoon"
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 8, "B").value = "Faks"
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 9, "B").value = "E-pos"
        '    Else
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 1, "B").value = "Policy holder"
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 2, "B").value = "Policy number"
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 3, "B").value = "ID number"
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 4, "B").value = "Address"
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 5, "B").value = "Telephone (h)"
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 6, "B").value = "Telephone (w)"
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 7, "B").value = "Cell phone"
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 8, "B").value = "Fax"
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 9, "B").value = "E-mail"
        '    End If

        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 1, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 1, "E").value = "'" & gen_getTitleDesc(language, Persoonl.titelnum & " " & Persoonl.voorl & " " & Persoonl.versekerde
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 2, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 2, "E").value = "'" & Persoonl.POLISNO
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 3, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 3, "E").value = "'" & Persoonl.ID_NOM
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 4, "E").value = "'" & address1 & " " & address2 & " " & Suburb & " " & Postalcode
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 5, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 5, "E").value = "'" & Persoonl.HUIS_TEL2
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 6, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 6, "E").value = "'" & Persoonl.WERK_TEL2
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 7, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 7, "E").value = "'" & Persoonl.SEL_TEL
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 8, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 8, "E").value = "'" & Persoonl.FAX
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 9, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 9, "E").value = "'" & Persoonl.EMAIL

        '    rownumber = rownumber + 9

    End Sub

    Public Sub insertVehicleDetail(ByRef pkVoertuie As Integer, Optional ByRef blnRemovedItem As Boolean = False)
        '    Dim i As Object
        '    'UPGRADE_WARNING: Arrays in structure rsVehicles may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '    Dim rsVehicles As DAO.Recordset

        '    'Insert heading
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Rows._Default(rownumber).Font.Bold = True
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Rows._Default(rownumber).Font.Size = 9

        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 1).value = "'2. "

        '    If language = 0 Then
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber, 2).value = "BESONDERHEDE VAN VERSEKERDE VOERTUIG"
        '    Else
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber, 2).value = "PARTICULARS OF THE INSURED VEHICLE"
        '    End If
        '    rownumber = rownumber + 2

        '    'Get all vehicles for policy (M&M and Diverse)
        '    If blnRemovedItem Then
        '        sSql = "SELECT voertuie.*, motors.maak, motors.besk FROM voertuie "
        '        sSql = sSql & " LEFT JOIN motors ON voertuie.kode = motors.kode AND voertuie.eeu = motors.eeu AND voertuie.jaar = motors.jaar"
        '        sSql = sSql & " WHERE not ander AND pkVoertuie = " & pkVoertuie
        '        sSql = sSql & " UNION"
        '        sSql = sSql & " SELECT voertuie.*, a_voertuig.maak, a_voertuig.besk FROM voertuie "
        '        sSql = sSql & " LEFT JOIN a_voertuig ON voertuie.kode = a_voertuig.kode AND voertuie.eeu = a_voertuig.eeu AND voertuie.jaar = a_voertuig.jaar "
        '        sSql = sSql & " WHERE ander AND pkVoertuie = " & pkVoertuie
        '        sSql = sSql & "  ORDER BY motors.maak"
        '    Else
        '        sSql = "SELECT voertuie.*, motors.maak, motors.besk FROM voertuie "
        '        sSql = sSql & " LEFT JOIN motors ON voertuie.kode = motors.kode AND voertuie.eeu = motors.eeu AND voertuie.jaar = motors.jaar"
        '        sSql = sSql & " WHERE not ander AND pkVoertuie = " & pkVoertuie
        '        sSql = sSql & " UNION"
        '        sSql = sSql & " SELECT voertuie.*, a_voertuig.maak, a_voertuig.besk FROM voertuie "
        '        sSql = sSql & " LEFT JOIN a_voertuig ON voertuie.kode = a_voertuig.kode AND voertuie.eeu = a_voertuig.eeu AND voertuie.jaar = a_voertuig.jaar "
        '        sSql = sSql & " WHERE ander AND pkVoertuie = " & pkVoertuie
        '        sSql = sSql & "  ORDER BY motors.maak"
        '    End If
        '    rsVehicles = dbPoldata.OpenRecordset(sSql)

        '    If Not (rsVehicles.EOF And rsVehicles.BOF) Then
        '        'Set style for heading columns
        '        xlsheet.Range("B" & rownumber & ":" & "B" & rownumber + 10).Font.Bold = True
        '        xlsheet.Range("H" & rownumber & ":" & "H" & rownumber + 10).Font.Bold = True

        '        'Set headings
        '        If language = 0 Then
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber, "B").value = "Fabrikaat"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 1, "B").value = "Model"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 2, "B").value = "Jaar"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 3, "B").value = "Registrasienommer"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 4, "B").value = "Tipe voertuig"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 5, "B").value = "Status"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 6, "B").value = "Enjinnommer"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 7, "B").value = "Onderstelnommer"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 8, "B").value = "Versekeringswaarde"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 9, "B").value = "Verseker teen"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 10, "B").value = "Tipe dekking"

        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber, "H").value = "Huurkoop instansie"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 1, "H").value = "Rekening nommer"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 2, "H").value = "Gebruik"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 3, "H").value = "Eienaar"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 4, "H").value = "Gereelde bestuurder 1"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 5, "H").value = "Gereelde bestuurder 2"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 6, "H").value = "Genomineerde best. 1"

        '        Else
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber, "B").value = "Manufacturer"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 1, "B").value = "Model"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 2, "B").value = "Year"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 3, "B").value = "Registration number"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 4, "B").value = "Type of vehicle"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 5, "B").value = "Status"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 6, "B").value = "Engine number"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 7, "B").value = "Chassis number"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 8, "B").value = "Value insured for"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 9, "B").value = "Insured at"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 10, "B").value = "Type of cover"

        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber, "H").value = "Vehicle financed at"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 1, "H").value = "Account number"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 2, "H").value = "Use"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 3, "H").value = "Owner"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 4, "H").value = "Primary driver 1"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 5, "H").value = "Primary driver 2"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber + 6, "H").value = "Nominated driver 1"

        '        End If

        '        'Insert data
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber, "E").value = "'" & rsVehicles.Fields("maak").Value
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 1, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 1, "E").value = "'" & rsVehicles.Fields("besk").Value
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 2, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 2, "E").value = "'" & rsVehicles.Fields("eeu").Value & rsVehicles.Fields("jaar").Value
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 3, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 3, "E").value = "'" & rsVehicles.Fields("n_plaat").Value
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 4, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 4, "E").value = gen_getVehicleType(language, rsVehicles.Fields("tipe").Value & "")
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 5, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 5, "E").value = gen_getVehicleStatus(language, rsVehicles.Fields("motorstatus").Value & "")
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 6, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 6, "E").value = "'" & rsVehicles.Fields("enjinnommer").Value
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 7, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 7, "E").value = "'" & rsVehicles.Fields("onderstelnommer").Value
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 8, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 8, "E").value = "R " & rsVehicles.Fields("waarde").Value
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 9, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 9, "E").value = gen_getVehicleValueType(language, rsVehicles.Fields("waardeTipe").Value)
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 10, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 10, "E").value = gen_getVehicleCover(language, rsVehicles.Fields("tipe_dek").Value)

        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber, "J").value = "'" & rsVehicles.Fields("huurinstansie").Value
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 1, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 1, "J").value = "'" & rsVehicles.Fields("huurnommer").Value
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 2, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 2, "J").value = gen_getVehicleUse(language, rsVehicles.Fields("gebruik").Value)
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 3, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 3, "J").value = "'" & VB.Left(rsVehicles.Fields("eienaar").Value, 30)
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 4, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 4, "J").value = "'" & VB.Left(rsVehicles.Fields("gereeldeBestuurder1").Value, 30)
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 5, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 5, "J").value = "'" & VB.Left(rsVehicles.Fields("gereeldeBestuurder2").Value, 30)
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 6, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 6, "J").value = "'" & VB.Left(rsVehicles.Fields("genomBestuurder1").Value, 30)

        '        'Style row
        '        For i = 0 To 9
        '            'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            With xlsheet.Rows._Default(rownumber + i)
        '                'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                .Font.Size = 9
        '                'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().RowHeight. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                .RowHeight = 11.25
        '            End With
        '        Next
        '    Else
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber, "B").Font.Size = 9
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().RowHeight. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber, "B").RowHeight = 11.25
        '        If language = 0 Then
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber, "B").value = "Geen"
        '        Else
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber, "B").value = "None"
        '        End If
        '    End If

        '    rownumber = rownumber + 11

    End Sub
    Public Sub populateLstInsruredItems()
        '    'UPGRADE_WARNING: Arrays in structure rsVehicles may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '    Dim rsVehicles As DAO.Recordset
        '    'UPGRADE_WARNING: Arrays in structure rsProperty may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '    Dim rsProperty As DAO.Recordset

        '    'Vehicles
        '    sSql = "SELECT voertuie.*, motors.maak, motors.besk FROM voertuie "
        '    sSql = sSql & " LEFT JOIN motors ON voertuie.kode = motors.kode AND voertuie.eeu = motors.eeu AND voertuie.jaar = motors.jaar"
        '    sSql = sSql & " WHERE not ander AND polisno = '" & Persoonl.POLISNO & "' AND cancelled = false"
        '    sSql = sSql & " UNION"
        '    sSql = sSql & " SELECT voertuie.*, a_voertuig.maak, a_voertuig.besk FROM voertuie "
        '    sSql = sSql & " LEFT JOIN a_voertuig ON voertuie.kode = a_voertuig.kode AND voertuie.eeu = a_voertuig.eeu AND voertuie.jaar = a_voertuig.jaar "
        '    sSql = sSql & " WHERE ander AND polisno = '" & Persoonl.POLISNO & "' AND cancelled = false"
        '    sSql = sSql & "  ORDER BY motors.maak"
        '    rsVehicles = dbPoldata.OpenRecordset(sSql)

        '    Do While Not rsVehicles.EOF
        '        Me.lstInsuredItems.Items.Add("Voertuig    : " & Trim(rsVehicles.Fields("maak").Value) & " " & Trim(rsVehicles.Fields("besk").Value) & " " & rsVehicles.Fields("eeu").Value & rsVehicles.Fields("jaar").Value & " " & Trim(rsVehicles.Fields("n_plaat").Value))
        '        'UPGRADE_ISSUE: ListBox property lstInsuredItems.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
        '        'TODO ____
        '        'VB6.SetItemData(Me.lstInsuredItems, lstInsuredItems.NewIndex, rsVehicles.Fields("pkVoertuie").Value)
        '        '_____
        '        rsVehicles.MoveNext()
        '    Loop

        '    sSql = "SELECT voertuie.*, motors.maak, motors.besk FROM voertuie "
        '    sSql = sSql & " LEFT JOIN motors ON voertuie.kode = motors.kode AND voertuie.eeu = motors.eeu AND voertuie.jaar = motors.jaar"
        '    sSql = sSql & " WHERE not ander AND polisno = '" & Persoonl.POLISNO & "' AND cancelled = true"
        '    sSql = sSql & " UNION"
        '    sSql = sSql & " SELECT voertuie.*, a_voertuig.maak, a_voertuig.besk FROM voertuie "
        '    sSql = sSql & " LEFT JOIN a_voertuig ON voertuie.kode = a_voertuig.kode AND voertuie.eeu = a_voertuig.eeu AND voertuie.jaar = a_voertuig.jaar "
        '    sSql = sSql & " WHERE ander AND polisno = '" & Persoonl.POLISNO & "' AND cancelled = true"
        '    sSql = sSql & "  ORDER BY motors.maak"
        '    rsVehicles = dbPoldata.OpenRecordset(sSql)

        '    Do While Not rsVehicles.EOF
        '        Me.lstInsuredItems.Items.Add("* Voertuig  : " & Trim(rsVehicles.Fields("maak").Value) & " " & Trim(rsVehicles.Fields("besk").Value) & " " & rsVehicles.Fields("eeu").Value & rsVehicles.Fields("jaar").Value & " " & Trim(rsVehicles.Fields("n_plaat").Value))
        '        'UPGRADE_ISSUE: ListBox property lstInsuredItems.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
        '        'TODO ____
        '        'VB6.SetItemData(Me.lstInsuredItems, lstInsuredItems.NewIndex, rsVehicles.Fields("pkVoertuie").Value)
        '        '_________
        '        rsVehicles.MoveNext()
        '    Loop

        '    'Property
        '    sSql = "SELECT * FROM huis WHERE polisno = '" & Persoonl.POLISNO & "' AND cancelled = false"
        '    rsProperty = dbPoldata.OpenRecordset(sSql)

        '    Do While Not rsProperty.EOF
        '        'Add to list HouseHolders if value > 0
        '        If rsProperty.Fields("waarde_hb").Value <> 0 Then
        '            Me.lstInsuredItems.Items.Add("Eiendom HB  " & Space(11) & ": " & Trim(rsProperty.Fields("adres_h1").Value) & " " & Trim(rsProperty.Fields("adres4").Value) & " " & Trim(rsProperty.Fields("voorstad").Value))
        '            'UPGRADE_ISSUE: ListBox property lstInsuredItems.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
        '            'TODO ____
        '            'VB6.SetItemData(Me.lstInsuredItems, lstInsuredItems.NewIndex, rsProperty.Fields("pkHuis").Value)
        '            '____________
        '        End If

        '        'Add to list HousOwners if value > 0
        '        If rsProperty.Fields("waarde_he").Value <> 0 Then
        '            Me.lstInsuredItems.Items.Add("Eiendom HE  " & Space(11) & ": " & Trim(rsProperty.Fields("adres_h1").Value) & " " & Trim(rsProperty.Fields("adres4").Value) & " " & Trim(rsProperty.Fields("voorstad").Value))
        '            'UPGRADE_ISSUE: ListBox property lstInsuredItems.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
        '            'TODO ____
        '            'VB6.SetItemData(Me.lstInsuredItems, lstInsuredItems.NewIndex, rsProperty.Fields("pkHuis").Value)
        '            '______________
        '        End If

        '        rsProperty.MoveNext()
        '    Loop

        '    sSql = "SELECT * FROM huis WHERE polisno = '" & Persoonl.POLISNO & "' AND cancelled = true"
        '    rsProperty = dbPoldata.OpenRecordset(sSql)

        '    Do While Not rsProperty.EOF
        '        'Add to list HouseHolders if value > 0
        '        If rsProperty.Fields("waarde_hb").Value <> 0 Then
        '            Me.lstInsuredItems.Items.Add("* Eiendom HB: " & Trim(rsProperty.Fields("adres_h1").Value) & " " & Trim(rsProperty.Fields("adres4").Value) & " " & Trim(rsProperty.Fields("voorstad").Value))
        '            'UPGRADE_ISSUE: ListBox property lstInsuredItems.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
        '            'TODO ____
        '            'VB6.SetItemData(Me.lstInsuredItems, lstInsuredItems.NewIndex, rsProperty.Fields("pkHuis").Value)
        '            '_____________
        '        End If

        '        'Add to list HousOwners if value > 0
        '        If rsProperty.Fields("waarde_he").Value <> 0 Then
        '            Me.lstInsuredItems.Items.Add("* Eiendom HE: " & Trim(rsProperty.Fields("adres_h1").Value) & " " & Trim(rsProperty.Fields("adres4").Value) & " " & Trim(rsProperty.Fields("voorstad").Value))
        '            'UPGRADE_ISSUE: ListBox property lstInsuredItems.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
        '            'TODO ____
        '            'VB6.SetItemData(Me.lstInsuredItems, lstInsuredItems.NewIndex, rsProperty.Fields("pkHuis").Value)
        '            '_______________
        '        End If

        '        rsProperty.MoveNext()
        '    Loop

    End Sub
    ''CoverType: HH - HouseHolders, HO - HouseOwners
    Public Sub insertPropertyDetail(ByRef pkHuis As Integer, ByRef CoverType As String, Optional ByRef blnRemovedItem As Boolean = False)
        '    Dim loanOrgField As Object
        '    Dim fieldDesc As Object
        '    Dim i As Object
        '    Dim rsProperty As DAO.Recordset

        '    If language = 0 Then
        '        If CoverType = "HH" Then 'House holder
        '            xlsheet.Cells._Default(rownumber, 2).value = "BESONDERHEDE VAN VERSEKERING: HUISHOUDELIKE INHOUD"
        '        Else 'House owner
        '            xlsheet.Cells._Default(rownumber, 2).value = "BESONDERHEDE VAN VERSEKERING: HUISEIENAARS"
        '        End If
        '    Else
        '        If CoverType = "HH" Then 'House holder
        '            xlsheet.Cells._Default(rownumber, 2).value = "PARTICULARS OF INSURANCE: HOUSE HOLDERS"
        '        Else 'House owner
        '            xlsheet.Cells._Default(rownumber, 2).value = "PARTICULARS OF INSURANCE: HOUSE OWNERS"
        '        End If
        '    End If
        '    rownumber = rownumber + 2

        '    'Get the property detail
        '    sSql = "SELECT huis.* , shortdescEng, shortDescAfr, nameAfr, nameEng FROM (huis"
        '    sSql = sSql & " LEFT JOIN propertyType on propertyType.pkPropertyType = huis.fkPropertyType)"
        '    sSql = sSql & " LEFT JOIN homeloanorg on homeloanOrg.pkHomeLoanOrg = huis.fkHomeloanorg"
        '    sSql = sSql & " WHERE pkHuis = " & pkHuis
        '    sSql = sSql & " AND polisno = '" & Persoonl.POLISNO & "'"
        '    rsProperty = dbPoldata.OpenRecordset(sSql)

        '    If Not (rsProperty.EOF And rsProperty.BOF) Then
        '        If language = 0 Then
        '            xlsheet.Cells._Default(rownumber, "B").value = "Risiko adres"
        '            xlsheet.Cells._Default(rownumber + 1, "B").value = "Bedrag verseker"
        '            xlsheet.Cells._Default(rownumber + 2, "B").value = "Maandelikse Sasria"
        '            xlsheet.Cells._Default(rownumber + 3, "B").value = "Tipe eiendom"
        '            xlsheet.Cells._Default(rownumber + 4, "B").value = "Sekuriteit"

        '            'Only for house owner
        '            If CoverType = "HO" Then
        '                xlsheet.Cells._Default(rownumber + 1, "H").value = "Verband instansie"
        '                xlsheet.Cells._Default(rownumber + 2, "H").value = "Rekeningnommer"
        '                xlsheet.Cells._Default(rownumber + 3, "H").value = "Struktuur"
        '                xlsheet.Cells._Default(rownumber + 4, "H").value = "Tipe dak"
        '            End If

        '            fieldDesc = "shortDescAfr"
        '            loanOrgField = "nameAfr"
        '        Else
        '            xlsheet.Cells._Default(rownumber, "B").value = "Risk address"
        '            xlsheet.Cells._Default(rownumber + 1, "B").value = "Amount insured"
        '            xlsheet.Cells._Default(rownumber + 2, "B").value = "Monthly Sasria"
        '            xlsheet.Cells._Default(rownumber + 3, "B").value = "Type of property"
        '            xlsheet.Cells._Default(rownumber + 4, "B").value = "Security"

        '            'Only for house owner
        '            If CoverType = "HO" Then
        '                xlsheet.Cells._Default(rownumber + 1, "H").value = "Home loan organization"
        '                xlsheet.Cells._Default(rownumber + 2, "H").value = "Account number"
        '                xlsheet.Cells._Default(rownumber + 3, "H").value = "Structure"
        '                xlsheet.Cells._Default(rownumber + 4, "H").value = "Type of roof"
        '            End If

        '            fieldDesc = "shortdescEng"
        '            loanOrgField = "nameEng"
        '        End If

        '        xlsheet.Cells._Default(rownumber, "E").value = "'" & rsProperty.Fields("adres_h1").Value & " " & rsProperty.Fields("adres4").Value & " " & rsProperty.Fields("voorstad").Value & " " & rsProperty.Fields("poskode").Value

        '        'Property type
        '        If IsDBNull(rsProperty.Fields(fieldDesc).Value) Or Trim(rsProperty.Fields(fieldDesc).Value) = "" Then
        '            If language = 0 Then
        '                xlsheet.Cells._Default(rownumber + 3, "E").value = "Onbekend"
        '            Else
        '                xlsheet.Cells._Default(rownumber + 3, "E").value = "Unknown"
        '            End If
        '        Else
        '            xlsheet.Cells._Default(rownumber + 3, "E").value = rsProperty.Fields(fieldDesc).Value
        '        End If

        '        If CoverType = "HH" Then 'House holder
        '            xlsheet.Cells._Default(rownumber + 1, "E").value = "R " & rsProperty.Fields("waarde_hb").Value
        '            xlsheet.Cells._Default(rownumber + 2, "E").value = "R " &Format(rsProperty.Fields("waarde_hb").Value * CDbl(sasria_ini), "0.00")
        '        Else
        '            xlsheet.Cells._Default(rownumber + 1, "E").value = "R " & rsProperty.Fields("waarde_he").Value
        '            xlsheet.Cells._Default(rownumber + 2, "E").value = "R " &Format(rsProperty.Fields("waarde_he").Value * CDbl(sasria_ini), "0.00")
        '        End If

        '        xlsheet.Cells._Default(rownumber + 4, "E").value = gen_getPropertySecurity(language, rsProperty.Fields("sekuriteitBitValue").Value)

        '        'Only for house owner
        '        If CoverType = "HO" Then
        '            xlsheet.Cells._Default(rownumber + 1, "J").value = rsProperty.Fields(loanOrgField).Value
        '            xlsheet.Cells._Default(rownumber + 2, "J").value = rsProperty.Fields("bondNumber").Value
        '            xlsheet.Cells._Default(rownumber + 3, "J").value = gen_getPropertyStructure(language, rsProperty.Fields("struktuur").Value)
        '            xlsheet.Cells._Default(rownumber + 4, "J").value = gen_getPropertyRoofType(language, rsProperty.Fields("tipe_dak").Value)
        '        End If

        '        rownumber = rownumber + 6
        '    Else
        '        xlsheet.Cells._Default(rownumber, "C").Font.Size = 9
        '        xlsheet.Cells._Default(rownumber, "C").RowHeight = 11.25
        '        If language = 0 Then
        '            xlsheet.Cells._Default(rownumber, "C").value = "Geen"
        '        Else
        '            xlsheet.Cells._Default(rownumber, "C").value = "None"
        '        End If
        '    End If
    End Sub
End Class