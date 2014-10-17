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

Friend Class BriefBevestig
    Inherits BaseForm
    Dim rownumber As Short
    Dim language As Byte
    Dim strAreaBranch As String
    Public delay As Short
    Public Rede As String
    Public ListItemDesc As String
    Public ListItemValue As String
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
            Persoonl.TAAL = 0
        ElseIf rdEngels.Checked Then
            Persoonl.TAAL = 1
        End If

        'Check if an item was selected
        If Me.lstInsuredItems.SelectedIndex = -1 Then
            MsgBox("The item in question must be selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        'Message regarding endorsement landslide etc.
        If Trim(VB.Left(Me.lstInsuredItems.Text, 10)) = "Eiendom HE" Then
            If MsgBox("Neem :" & Chr(13) & "If the mounting section Landslip and subsidence must include the appropriate endorsement to the policy added. " & Chr(13) & Chr(13) & " Policy options => Change endorsement master and details", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                Exit Sub
            End If
        End If

        Dim BevestigDescEntity As New BevestigDescEntity
        BevestigDescEntity = lstInsuredItems.SelectedItem
        ListItemDesc = BevestigDescEntity.bevestigDesc
        ListItemValue = lstInsuredItems.SelectedValue

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
                gen_ArchiveDocument(result, Persoonl.POLISNO, 3, "", "", "", "")
            ElseIf rdEpos.Checked Then
                CreateReportFile()
                gen_ArchiveDocument(result, Persoonl.POLISNO, 3, emailEngine.txtSubject.Text, emailEngine.txtTo.Text, emailEngine.txtBody.Text, getAttachmentsForEmailEngine, tempFilename)
                emailEngine.sendMail(emailEngine.txtTo.Text, emailEngine.txtSubject.Text, emailEngine.txtBody.Text, tempFilename)
            End If
            Exit Sub
        Else
            BriefBevestigReportViewer.Show()
            Exit Sub
        End If

    End Sub
    Sub CreateReportFile()
        Dim detailStream As Stream
        detailStream = createDetailFile("/Mooirivier/BriefBevestig")
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
            'If BriefBevestig.rdBuiteland.Checked Then
            '    PropertyCoverType = " "
            'End If
            Dim huis As HuisEntity
            huis = GetHuisByPrimaryKey(ListItemValue)
            Security = gen_getPropertySecurity(Persoonl.TAAL, huis.SekuriteitBitValue)

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", Persoonl.POLISNO), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", Persoonl.TAAL), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("area_kode", Persoonl.Area), _
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

    Private Sub btnPostalCodes_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnPostalCodes.Click
        PoskodesSoek.txtFormToPopulate.Text = Me.Name
        PoskodesSoek.ShowDialog()
    End Sub
    Private Sub BriefBevestig_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Populatefields()
        'Andriette 16/08/2013 gebruik die global polisnommer
        'If Trim(Form1.POLISNO.Text) = "" Then
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
    End Sub
    Function PopulateListForVoertue()
        Dim list As List(Of BevestigDescEntity) = New List(Of BevestigDescEntity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                param.Value = Persoonl.POLISNO

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FecthInsuredItem]", param)
                While reader.Read()
                    Dim item As BevestigDescEntity = New BevestigDescEntity()

                    If reader("bevestigDesc") IsNot DBNull.Value Then
                        item.bevestigDesc = reader("bevestigDesc")
                    End If
                    If reader("bevestigCode") IsNot DBNull.Value Then
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
    'Populate list 
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
                    End If
                    If reader("bevestigCode") IsNot DBNull.Value Then
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
    Public Sub createLetter()
        'Dim attachList As Object
        'Dim message As Object
        'Dim rsMakelaarSql As Object
        'Dim rsAreaBrief As Object
        'Dim rsPersoonl As Object
        'Dim letterSubject As String
        'Dim blnUserControl As Boolean
        'Dim archiveCategory As Byte
        'Dim tempFilename As String
        'Dim AreaSql As String
        'Dim rsArea As DAO.Recordset

        ''Destination = email
        'If Me.rdEpos.Checked Then
        '    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '    If emailEngine.signOn Then
        '        emailEngine.txtTo.Text = Persoonl.EMAIL & ""

        '        emailEngine.ShowDialog()

        '        If Not emailEngine.returnValue Then
        '            emailEngine.signOff()
        '            emailEngine.Close()
        '            Exit Sub
        '        End If
        '    Else
        '        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '        Exit Sub
        '    End If
        'End If
        'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        'lblStatus.Text = "Laai Microsoft® Excel"

        ''letterhead_createExcelObject(xlapp, blnUserControl)
        'xlbook = xlapp.Workbooks.Open("c:\polis5\docs\report.xls")
        'xlsheet = xlbook.Worksheets(1)

        'rsPersoonl = Persoonl

        'xlapp.DisplayAlerts = False

        'lblStatus.Text = "Genereer bevestigingsbrief"
        'Me.Refresh()

        '' rsAreaBrief = dbPoldata.OpenRecordset("SELECT * FROM area WHERE area_kode = '" & Persoonl.Fields("area").Value & "'")
        '' rsMakelaarSql = dbPoldata.OpenRecordset("SELECT * FROM Makelaar where pkmakelaar = " & rsAreaBrief("fkmakelaar"))
        ''xlsheet.Shapes.AddPicture(getAdminPath & "Logo\" & rsMakelaarSql("Makelaar_logo"), True, True, ExcelGlobal_definst.Cells.Left, ExcelGlobal_definst.Cells.Top, 480, 70)

        'If language = 0 Then
        '    letterSubject = "Bevestiging van versekering"
        'Else
        '    letterSubject = "Confirmation of insurance"
        'End If

        ''letterhead_setStyle(xlsheet, 100, 12, language, False, Persoonl.Fields("polisno").Value)

        'strAreaBranch = rsPersoonl("area")

        'letterhead_setBranch(xlsheet, language, 5, 12, strAreaBranch)

        'letterhead_setAddress(xlsheet, 9, 3, language, gen_getTitleDesc(language, (Me.cmbTitel.SelectedIndex)), (Me.txtVoorletter).Text, (Me.txtVan).Text, (Me.txtAdres1).Text, (Me.txtAdres2).Text, (Me.txtVoorstad).Text, (Me.txtPoskode).Text)

        'letterhead_setSubject(xlsheet, 26, 12, language, letterSubject, Persoonl.Fields("polisno").Value, gen_getTitleDesc(language, (cmbTitel.SelectedIndex)), (Me.txtVan).Text, True)

        ''Set line
        'letterhead_setLine(xlsheet, "A4", "L4")

        'Set special column widths
        'xlsheet.Columns._Default("G").ColumnWidth = 4
        'xlsheet.Columns._Default("I").ColumnWidth = 10

        '' Footer - overide the footer set with letterhead_setStyle
        'If language = 0 Then
        '    xlsheet.PageSetup.RightFooter = "&6Bladsy &p van &n"
        'Else
        '    xlsheet.PageSetup.RightFooter = "&6Page &p of &n"
        'End If
        ''  xlsheet.PageSetup.RightHeader = "&6 " & gen_getTitleDesc(language, Persoonl.Fields("titelnum").Value) & ". " & Persoonl.Fields("voorl").Value & " " & Persoonl.Fields("versekerde").Value & " (" & Persoonl.Fields("polisno").Value & ")"

        ''rownumber = 29

        '' Set the style of the letter introduction
        ''  With xlsheet.Range("A" & rownumber & ":L" & rownumber)
        '.Cells.Merge()
        '.RowHeight = 34.5
        '.VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop
        '.HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlJustify
        '.WrapText = True
        'End With

        '' Versekeraar(Information)
        ''AreaSql = "SELECT area.*, versekeraar.* FROM area, versekeraar "
        ''AreaSql = AreaSql & " WHERE area.fkversekeraar = versekeraar.pkversekeraar AND area_kode = '" & Persoonl.Fields("area").Value & "'"
        ''rsArea = dbPoldata.OpenRecordset(AreaSql)

        'Letter(introduction)
        'If language = 0 Then
        '    message = "Hierdie skrywe bevestig dat die volgende versekerde oor 'n geldige versekeringspolis beskik, "
        '    message = message & "welke polis onderskryf word deur '" & StrConv(rsArea.Fields("Bedryfsnaam").Value, VbStrConv.Uppercase) & "', onderworpe aan die terme en voorwaardes van die polis."
        'Else
        '    message = "This letter confirms that the following insured is the valid policy holder of a policy underwritten by '" & StrConv(rsArea.Fields("Bedryfsnaam").Value, VbStrConv.Uppercase) & "'."
        '    message = message & "  Subject to inter alia the following terms and conditions."
        '    If Me.rdBuiteland.Checked Then
        '        message = "It is hereby confirmed that the insured below is the valid policy holder of a policy underwritten by '" & StrConv(rsArea.Fields("Bedryfsnaam").Value, VbStrConv.Uppercase) & "'"
        '        message = message & " and that the specified vehicle enjoys cover for own damages in neighbouring states (Malawi, Mozambique, Lesotho, Botswana, Swaziland, Namibia, Zambia and Zimbabwe), subject to the terms and conditions of the policy, which is available on request."
        '        message = message & "It is further confirmed that in the event of a vehicle being damaged in an accident, it is the insured's responsibility to, at his/her expense, make the neccesary arrangements"
        '        message = message & " for the recovery of the vehicle to within the boundaries of the Republic of South Africa."
        '        message = message & Chr(10)
        '        message = message & "The policy does not make provision for third  party liability as most neighbouring states prescribe their own compulsory third party liability insurance for foreign visitors."
        '        ' xlsheet.Rows._Default(rownumber).RowHeight = 96
        '    End If
        'End If
        'xlsheet.Cells._Default(rownumber, 1).value = message

        'rownumber = rownumber + 2

        'Insert policy holder detail
        'insertPolicyHolderDetail()
        'rownumber = rownumber + 2

        ''        Insert item detail
        'Check for property or vehicle
        'Select Case Trim(VB.Left(Me.lstInsuredItems.Text, 10))
        '    Case "Voertuig"
        'insertVehicleDetail(VB6.GetItemData(Me.lstInsuredItems, lstInsuredItems.SelectedIndex))
        '        archiveCategory = 3
        '    Case "Eiendom HB"
        '        insertPropertyDetail(VB6.GetItemData(Me.lstInsuredItems, lstInsuredItems.SelectedIndex), "HH")
        '        archiveCategory = 11
        '    Case "Eiendom HE"
        '        insertPropertyDetail(VB6.GetItemData(Me.lstInsuredItems, lstInsuredItems.SelectedIndex), "HO")
        '        rownumber = rownumber + 1
        '        insertEndorsement()
        '        archiveCategory = 10
        'End Select

        'Insert closing comments on letter
        'rownumber = rownumber + 1
        'With xlsheet.Range("A" & rownumber & ":L" & rownumber)
        '    .Cells.Merge()
        '    .RowHeight = 24.75
        '    .VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop
        '    .HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlJustify
        '    .WrapText = False
        'End With

        'If language = 0 Then
        '    'UPGRADE_WARNING: Couldn() 't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 1).value = "Ons glo dat u die bogemelde in orde vind en moet u nie huiwer om met ons in verbinding te tree indien u enige verdere inligting benodig in die verband."
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 2, 1).value = "Die uwe"
        'Else
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 1).value = "We trust that you will find the above to be in order and should you have any further inquiries you are welcome to contact us in this regard."
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 2, 1).value = "Yours faithfully"
        'End If

        ''Printer / Email
        'If Me.rdDrukker.Checked Then 'Print
        '    'Arhive document
        '    gen_ArchiveDocument(xlbook, 1, Persoonl.Fields("polisno").Value, archiveCategory, "", "", "", "")

        '    'Preview letter
        '    xlapp.Visible = True
        '    xlsheet.PrintPreview()
        '    xlbook.Close()
        '    xlapp.Quit()
        'ElseIf Me.rdEpos.Checked Then  'Email
        '    'UPGRADE_WARNING: Couldn't resolve default property of object attachList. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    gen_ArchiveDocument(xlbook, 1, Persoonl.Fields("polisno").Value, archiveCategory, (emailEngine.txtSubject).Text, (emailEngine.txtTo).Text, (emailEngine.txtBody).Text, CStr(attachList), tempFilename)

        '    emailEngine.sendMail((emailEngine.txtTo).Text, (emailEngine.txtSubject).Text, (emailEngine.txtBody).Text, tempFilename)
        'End If

        'If the document was emailed - sign-off
        '    If Me.rdEpos.Checked Then
        '        emailEngine.signOff()
        '        emailEngine.Close()
        '    End If

        '    Clean(-up)
        'UPGRADE_NOTE: Object xlapp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        '    xlapp = Nothing
        '    'UPGRADE_NOTE: Object xlbook may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        '    xlbook = Nothing
        '    'UPGRADE_NOTE: Object xlsheet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        '    xlsheet = Nothing
        '    'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        '    lblStatus.Text = "Bevestinging is gedruk/ge-epos"
        '    Me.Refresh()
        '    'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        '    'Close form
        '    btnClose_Click(btnClose, New System.EventArgs())
    End Sub
    Public Sub insertPolicyHolderDetail()
        'Dim address1 As String
        'Dim address2 As String
        'Dim Suburb As String
        'Dim Postalcode As String

        ''Insert heading
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Rows._Default(rownumber).Font.Bold = True
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Rows._Default(rownumber).Font.Size = 9

        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 1).value = "'1. "

        'If language = 0 Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 2).value = "BESONDERHEDE VAN DIE VERSEKERDE"
        'Else
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 2).value = "PARTICULARS OF THE INSURED"
        'End If

        'rownumber = rownumber + 1

        ''Bold headings
        'With xlsheet.Range("B" & rownumber + 1 & ":B" & rownumber + 9)
        '	.Font.Bold = True
        'End With
        'With xlsheet.Range("H" & rownumber + 1 & ":H" & rownumber + 9)
        '	.Font.Bold = True
        'End With

        ''Get the address of the mainproperty for this policy
        'gen_getPropertyMainAddress(Persoonl.Fields("polisno").Value, address1, address2, Suburb, Postalcode)

        'If language = 0 Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 1, "B").value = "Versekerde"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 2, "B").value = "Polisnommer"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 3, "B").value = "Aanvangsdatum"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 4, "B").value = "ID nommer"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 6, "B").value = "Adres"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 2, "H").value = "Telefoon (h)"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 3, "H").value = "Telefoon (w)"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 4, "H").value = "Selfoon"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 5, "B").value = "Faks"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 5, "H").value = "E-pos"
        'Else
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 1, "B").value = "Policy holder"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 2, "B").value = "Policy number"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 3, "B").value = "Inception date"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 4, "B").value = "ID number"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 6, "B").value = "Address"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 2, "H").value = "Telephone (h)"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 3, "H").value = "Telephone (w)"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 4, "H").value = "Cell phone"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 5, "B").value = "Fax"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 5, "H").value = "E-mail"
        'End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 1, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 1, "E").value = "'" & gen_getTitleDesc(language, Persoonl.Fields("titelnum").Value) & " " & Persoonl.Fields("voorl").Value & " " & Persoonl.Fields("versekerde").Value
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 2, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 2, "E").value = "'" & Persoonl.Fields("polisno").Value
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 3, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 3, "E").value = "'" &Format(Persoonl.Fields("p_a_dat").Value, "dd/MM/yyyy")
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 4, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 4, "E").value = "'" & Persoonl.Fields("id_nom").Value
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 6, "E").value = "'" & address1 & " " & address2
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 7, "E").value = "'" & Suburb & " " & Postalcode
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 2, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 2, "J").value = "'" & Persoonl.Fields("huis_tel2").Value
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 3, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 3, "J").value = "'" & Persoonl.Fields("werk_tel2").Value
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 4, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 4, "J").value = "'" & Persoonl.Fields("sel_tel").Value
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 5, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 5, "E").value = "'" & Persoonl.Fields("fax").Value
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 5, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 5, "J").value = "'" & Persoonl.Fields("email").Value

        'rownumber = rownumber + 7

    End Sub

    Public Sub insertVehicleDetail(ByRef pkVoertuie As Integer)
        'Dim i As Object
        ''UPGRADE_WARNING: Arrays in structure rsVehicles may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        'Dim rsVehicles As DAO.Recordset

        ''Insert heading
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Rows._Default(rownumber).Font.Bold = True
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Rows._Default(rownumber).Font.Size = 9

        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 1).value = "'2. "

        'If language = 0 Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 2).value = "BESONDERHEDE VAN VERSEKERDE VOERTUIG"
        'Else
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 2).value = "PARTICULARS OF THE INSURED VEHICLE"
        'End If
        'rownumber = rownumber + 2

        ''Get all vehicles for policy (M&M and Diverse)
        'sSql = "SELECT voertuie.*, motors.maak, motors.besk FROM voertuie "
        'sSql = sSql & " LEFT JOIN motors ON voertuie.kode = motors.kode AND voertuie.eeu = motors.eeu AND voertuie.jaar = motors.jaar"
        'sSql = sSql & " WHERE not ander AND pkVoertuie = " & pkVoertuie
        'sSql = sSql & " UNION"
        'sSql = sSql & " SELECT voertuie.*, a_voertuig.maak, a_voertuig.besk FROM voertuie "
        'sSql = sSql & " LEFT JOIN a_voertuig ON voertuie.kode = a_voertuig.kode AND voertuie.eeu = a_voertuig.eeu AND voertuie.jaar = a_voertuig.jaar "
        'sSql = sSql & " WHERE ander AND pkVoertuie = " & pkVoertuie
        'sSql = sSql & "  ORDER BY motors.maak"
        'rsVehicles = dbPoldata.OpenRecordset(sSql)

        'If Not (rsVehicles.EOF And rsVehicles.BOF) Then
        '	'Set style for heading columns
        '	xlsheet.Range("B" & rownumber & ":" & "B" & rownumber + 11).Font.Bold = True
        '	xlsheet.Range("H" & rownumber & ":" & "H" & rownumber + 11).Font.Bold = True

        '	'Set headings
        '	If language = 0 Then
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, "B").value = "Fabrikaat"
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber + 1, "B").value = "Model"
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber + 2, "B").value = "Jaar"
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber + 3, "B").value = "Registrasienommer"
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 4, "B").value = "Tipe voertuig"
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 5, "B").value = "Status"
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 6, "B").value = "Enjinnommer"
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 7, "B").value = "Onderstelnommer"
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 8, "B").value = "Versekeringswaarde"
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 9, "B").value = "Tipe dekking"
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 10, "B").value = "Adres waar oornag"

        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, "H").value = "Huurkoop instansie"
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 1, "H").value = "Rekening nommer"
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 2, "H").value = "Gebruik"
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 3, "H").value = "Eienaar"
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 4, "H").value = "Gereelde bestuurder 1"
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 5, "H").value = "Gereelde bestuurder 2"
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 6, "H").value = "Genomineerde best. 1"
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 7, "H").value = "Maandelikse Sasria"
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 8, "H").value = "Verseker teen"

        ''UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        'If Not IsDBNull(dtpDekkingVanaf.Value) Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 9, "H").value = "Dekking vanaf"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 9, "J").value = "'" & dtpDekkingVanaf.Value
        '    'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        '    If Not IsDBNull(dtpDekkingTot.Value) Then
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 9, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 9, "J").value = xlsheet.Cells._Default(rownumber + 9, "J").value & " tot " & dtpDekkingTot.Value
        '    End If
        '     End If
        'Else
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber, "B").value = "Manufacturer"
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 1, "B").value = "Model"
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 2, "B").value = "Year"
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 3, "B").value = "Registration number"
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 4, "B").value = "Type of vehicle"
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 5, "B").value = "Status"
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 6, "B").value = "Engine number"
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 7, "B").value = "Chassis number"
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 8, "B").value = "Value insured for"
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 9, "B").value = "Type of cover"
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 10, "B").value = "Address overnight"

        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber, "H").value = "Vehicle financed at"
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 1, "H").value = "Account number"
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 2, "H").value = "Use"
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 3, "H").value = "Owner"
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 4, "H").value = "Primary driver 1"
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 5, "H").value = "Primary driver 2"
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 6, "H").value = "Nominated driver 1"
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 7, "H").value = "Monthly Sasria"
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 8, "H").value = "Insured at"

        '     'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        '     If Not IsDBNull(dtpDekkingVanaf.Value) Then
        '         'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '         xlsheet.Cells._Default(rownumber + 9, "H").value = "Covered from"
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 9, "J").value = "'" & dtpDekkingVanaf.Value
        '     'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        '     If Not IsDBNull(dtpDekkingTot.Value) Then
        '         'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 9, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '         'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '         xlsheet.Cells._Default(rownumber + 9, "J").value = xlsheet.Cells._Default(rownumber + 9, "J").value & " to " & dtpDekkingTot.Value
        '     End If
        '     End If
        'End If

        '     'Insert data
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber, "E").value = "'" & rsVehicles.Fields("maak").Value
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 1, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 1, "E").value = "'" & rsVehicles.Fields("besk").Value
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 2, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 2, "E").value = "'" & rsVehicles.Fields("eeu").Value & rsVehicles.Fields("jaar").Value
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 3, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 3, "E").value = "'" & rsVehicles.Fields("n_plaat").Value
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 4, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 4, "E").value = gen_getVehicleType(language, rsVehicles.Fields("tipe").Value & "")
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 5, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 5, "E").value = gen_getVehicleStatus(language, rsVehicles.Fields("motorstatus").Value & "")
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 6, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 6, "E").value = "'" & rsVehicles.Fields("enjinnommer").Value
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 7, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 7, "E").value = "'" & rsVehicles.Fields("onderstelnommer").Value
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 8, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 8, "E").value = "R " & rsVehicles.Fields("waarde").Value
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 9, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 9, "E").value = gen_getVehicleCover(language, rsVehicles.Fields("tipe_dek").Value)
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 10, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 10, "E").value = "'" & VB.Left(rsVehicles.Fields("adres").Value & " " & rsVehicles.Fields("adres2").Value, 60)
        '     'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 11, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber + 11, "E").value = "'" & VB.Left(rsVehicles.Fields("voorstad").Value, 30)
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 12, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 12, "E").value = "'" & rsVehicles.Fields("stad").Value & " " & VB.Left(rsVehicles.Fields("poskode").Value, 30)

        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, "J").value = "'" & rsVehicles.Fields("huurinstansie").Value
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 1, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 1, "J").value = "'" & rsVehicles.Fields("huurnommer").Value
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 2, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 2, "J").value = gen_getVehicleUse(language, rsVehicles.Fields("gebruik").Value)
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 3, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 3, "J").value = "'" & VB.Left(rsVehicles.Fields("eienaar").Value, 30)
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 4, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 4, "J").value = "'" & VB.Left(rsVehicles.Fields("gereeldeBestuurder1").Value, 30)
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 5, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 5, "J").value = "'" & VB.Left(rsVehicles.Fields("gereeldeBestuurder2").Value, 30)
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 6, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 6, "J").value = "'" & VB.Left(rsVehicles.Fields("genomBestuurder1").Value, 30)
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 7, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object nmotorsasria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 7, "J").value = "R " &Format(nmotorsasria, "0.00")
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 8, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 8, "J").value = gen_getVehicleValueType(language, rsVehicles.Fields("waardeTipe").Value)

        ''Style row
        'For i = 0 To 11
        '    'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    With xlsheet.Rows._Default(rownumber + i)
        '      'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      .Font.Size = 9
        '      'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().RowHeight. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      .RowHeight = 11.25
        '          End With
        '      Next
        'Else
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Cells._Default(rownumber, "B").Font.Size = 9
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().RowHeight. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Cells._Default(rownumber, "B").RowHeight = 11.25
        '      If language = 0 Then
        '          'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '          xlsheet.Cells._Default(rownumber, "B").value = "Geen"
        '      Else
        '          'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '          xlsheet.Cells._Default(rownumber, "B").value = "None"
        '      End If
        'End If

        '      rownumber = rownumber + 13

    End Sub
    Public Sub populateLstInsruredItems(ByRef blnVehicles As Boolean, ByRef blnProperty As Boolean)
        '    'UPGRADE_WARNING: Arrays in structure rsVehicles may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '    Dim rsVehicles As DAO.Recordset
        '    'UPGRADE_WARNING: Arrays in structure rsProperty may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '    Dim rsProperty As DAO.Recordset

        '    'Clear list
        '    Me.lstInsuredItems.Items.Clear()

        '    'Vehicles
        '    If blnVehicles Then
        '        sSql = "SELECT voertuie.*, motors.maak, motors.besk FROM voertuie "
        '        sSql = sSql & " LEFT JOIN motors ON voertuie.kode = motors.kode AND voertuie.eeu = motors.eeu AND voertuie.jaar = motors.jaar"
        '        sSql = sSql & " WHERE not ander AND polisno = '" & Persoonl.Fields("polisno").Value & "' AND cancelled = false"
        '        sSql = sSql & " UNION"
        '        sSql = sSql & " SELECT voertuie.*, a_voertuig.maak, a_voertuig.besk FROM voertuie "
        '        sSql = sSql & " LEFT JOIN a_voertuig ON voertuie.kode = a_voertuig.kode AND voertuie.eeu = a_voertuig.eeu AND voertuie.jaar = a_voertuig.jaar "
        '        sSql = sSql & " WHERE ander AND polisno = '" & Persoonl.Fields("polisno").Value & "' AND cancelled = false"
        '        sSql = sSql & " ORDER BY motors.maak"
        '        rsVehicles = dbPoldata.OpenRecordset(sSql)

        '        Do While Not rsVehicles.EOF
        '            Me.lstInsuredItems.Items.Add("Voertuig  : " & Trim(rsVehicles.Fields("maak").Value) & " " & Trim(rsVehicles.Fields("besk").Value) & " " & rsVehicles.Fields("eeu").Value & rsVehicles.Fields("jaar").Value & " " & Trim(rsVehicles.Fields("n_plaat").Value))
        '            'UPGRADE_ISSUE: ListBox property lstInsuredItems.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
        '            'TODO___________
        '            'VB6.SetItemData(Me.lstInsuredItems, lstInsuredItems.NewIndex, rsVehicles.Fields("pkVoertuie").Value)
        '            'rsVehicles.MoveNext()
        '            '___________
        '        Loop
        '    End If

        '    'Property
        '    If blnProperty Then
        '        sSql = "SELECT * FROM huis WHERE polisno = '" & Persoonl.Fields("polisno").Value & "' AND cancelled = false"
        '        rsProperty = dbPoldata.OpenRecordset(sSql)

        '        Do While Not rsProperty.EOF
        '            If rsProperty.Fields("waarde_hb").Value <> 0 Then
        '                Me.lstInsuredItems.Items.Add("Eiendom HB: " & Trim(rsProperty.Fields("adres_h1").Value) & " " & Trim(rsProperty.Fields("adres4").Value) & " " & Trim(rsProperty.Fields("voorstad").Value))
        '                'UPGRADE_ISSUE: ListBox property lstInsuredItems.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
        '                'TODO ____
        '                'VB6.SetItemData(Me.lstInsuredItems, lstInsuredItems.NewIndex, rsProperty.Fields("pkHuis").Value)
        '                '___
        '            End If

        '            If rsProperty.Fields("waarde_he").Value <> 0 Then
        '                Me.lstInsuredItems.Items.Add("Eiendom HE: " & Trim(rsProperty.Fields("adres_h1").Value) & " " & Trim(rsProperty.Fields("adres4").Value) & " " & Trim(rsProperty.Fields("voorstad").Value))
        '                'UPGRADE_ISSUE: ListBox property lstInsuredItems.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
        '                'TODO ____
        '                'VB6.SetItemData(Me.lstInsuredItems, lstInsuredItems.NewIndex, rsProperty.Fields("pkHuis").Value)
        '                '________
        '            End If

        '            rsProperty.MoveNext()
        '        Loop
        '    End If
        'End Sub
    End Sub


    'Sub populateLstInsruredItemsHuis()
    '    Try
    '        Using conn As SqlConnection = SqlHelper.GetConnection
    '            Dim params() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
    '                                               New SqlParameter("@Cancelled", SqlDbType.Bit)}

    '            params(0).Value = Persoonl.POLISNO
    '            params(1).Value = False

    '            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.ReportFetchHuisByPoliceno", params)
    '            Do While reader.Read
    '                If reader("waarde_hb") <> 0 Then

    '                    Me.lstInsuredItems.Items.Add("Eiendom HB: " & Trim(reader("adres_h1")) & " " & Trim(reader("adres4")) & " " & Trim(reader("voorstad")))

    '                    'VB6.SetItemData(Me.lstInsuredItems, lstInsuredItems.NewIndex, rsProperty.Fields("pkHuis").Value)

    '                End If
    '                If reader("waarde_he") <> 0 Then
    '                    Me.lstInsuredItems.Items.Add("Eiendom HE: " & Trim(reader("adres_h1")) & " " & Trim(reader("adres4")) & " " & Trim(reader("voorstad")))
    '                    'VB6.SetItemData(Me.lstInsuredItems, lstInsuredItems.NewIndex, rsProperty.Fields("pkHuis").Value)

    '                End If
    '            Loop
    '        End Using
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub
    'CoverType: HH - HouseHolders, HO - HouseOwners
    Public Sub insertPropertyDetail(ByRef pkHuis As Integer, ByRef CoverType As String)
        'Dim loanOrgField As Object
        'Dim fieldDesc As Object

        'Dim i As Object
        ''UPGRADE_WARNING: Arrays in structure rsProperty may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        'Dim rsProperty As DAO.Recordset

        ''Insert heading
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Rows._Default(rownumber).Font.Bold = True
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Rows._Default(rownumber).Font.Size = 9

        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 1).value = "'2. "

        'If language = 0 Then
        '	If CoverType = "HH" Then 'House holder
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 2).value = "BESONDERHEDE VAN VERSEKERING: HUISHOUDELIKE INHOUD"
        '	Else 'House owner
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Cells._Default(rownumber, 2).value = "BESONDERHEDE VAN VERSEKERING: HUISEIENAARS"
        '	End If
        'Else
        '      If CoverType = "HH" Then 'House holder
        '          'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '          xlsheet.Cells._Default(rownumber, 2).value = "PARTICULARS OF INSURANCE: HOUSE HOLDERS"
        '      Else 'House owner
        '          'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '          xlsheet.Cells._Default(rownumber, 2).value = "PARTICULARS OF INSURANCE: HOUSE OWNERS"
        '      End If
        'End If
        '      rownumber = rownumber + 2

        ''Get the property detail
        'sSql = "SELECT huis.* , shortdescEng, shortDescAfr, nameAfr, nameEng FROM (huis"
        'sSql = sSql & " LEFT JOIN propertyType on propertyType.pkPropertyType = huis.fkPropertyType)"
        'sSql = sSql & " LEFT JOIN homeloanorg on homeloanOrg.pkHomeLoanOrg = huis.fkHomeloanorg"
        'sSql = sSql & " WHERE pkHuis = " & pkHuis
        'rsProperty = dbPoldata.OpenRecordset(sSql)

        'If Not (rsProperty.EOF And rsProperty.BOF) Then

        '    'Set style for heading columns
        '    xlsheet.Range("B" & rownumber & ":" & "B" & rownumber + 5).Font.Bold = True
        '    xlsheet.Range("H" & rownumber & ":" & "H" & rownumber + 5).Font.Bold = True

        '    'Style row
        '    For i = 1 To 5
        '        'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        With xlsheet.Rows._Default(rownumber + i)
        'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '.Font.Size = 9
        ''UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().RowHeight. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '.RowHeight = 11.25
        '        End With
        '    Next

        'If language = 0 Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, "B").value = "Risiko adres"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 1, "B").value = "Bedrag verseker"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 2, "B").value = "Maandelikse Sasria"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 3, "B").value = "Tipe eiendom"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 4, "B").value = "Sekuriteit"
        ''UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        'If Not IsDBNull(dtpDekkingVanaf.Value) Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 5, "B").value = "Dekking vanaf"
        'End If

        ''Only for house owner
        'If CoverType = "HO" Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 1, "H").value = "Verband instansie"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 2, "H").value = "Rekeningnommer"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 3, "H").value = "Struktuur"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 4, "H").value = "Tipe dak"
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 5, "H").value = "Erfnommer"
        'End If

        ''UPGRADE_WARNING: Couldn't resolve default property of object fieldDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'fieldDesc = "shortDescAfr"
        ''UPGRADE_WARNING: Couldn't resolve default property of object loanOrgField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'loanOrgField = "nameAfr"
        'Else
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, "B").value = "Risk address"
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 1, "B").value = "Amount insured"
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 2, "B").value = "Monthly Sasria"
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 3, "B").value = "Type of property"
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 4, "B").value = "Security"
        ''UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        'If Not IsDBNull(dtpDekkingVanaf.Value) Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 5, "B").value = "Covered from"
        'End If

        ''Only for house owner
        'If CoverType = "HO" Then
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 1, "H").value = "Home loan organization"
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 2, "H").value = "Account number"
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 3, "H").value = "Structure"
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 4, "H").value = "Type of roof"
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 5, "H").value = "Stand number"
        'End If

        ''UPGRADE_WARNING: Couldn't resolve default property of object fieldDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'fieldDesc = "shortdescEng"
        ''UPGRADE_WARNING: Couldn't resolve default property of object loanOrgField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'loanOrgField = "nameEng"
        'End If

        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, "E").value = "'" & rsProperty.Fields("adres_h1").Value & " " & rsProperty.Fields("adres4").Value & " " & rsProperty.Fields("voorstad").Value & " " & rsProperty.Fields("dorp").Value & " " & rsProperty.Fields("poskode").Value

        ''Property type
        ''UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        'If IsDBNull(rsProperty.Fields(fieldDesc).Value) Or Trim(rsProperty.Fields(fieldDesc).Value) = "" Then
        '    If language = 0 Then
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 3, "E").value = "Onbekend"
        '    Else
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber + 3, "E").value = "Unknown"
        '    End If
        'Else
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 3, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 3, "E").value = rsProperty.Fields(fieldDesc).Value
        'End If

        'If CoverType = "HH" Then 'House holder
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 1, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 1, "E").value = "R " & rsProperty.Fields("waarde_hb").Value
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 2, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 2, "E").value = "R " &Format(rsProperty.Fields("waarde_hb").Value * CDbl(sasria_ini), "0.00")
        'Else
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 1, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 1, "E").value = "R " & rsProperty.Fields("waarde_he").Value
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 2, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 2, "E").value = "R " &Format(rsProperty.Fields("waarde_he").Value * CDbl(sasria_ini), "0.00")
        'End If

        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 4, E).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 4, "E").value = gen_getPropertySecurity(language, rsProperty.Fields("sekuriteitBitValue").Value)

        ''UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        'If Not IsDBNull(dtpDekkingVanaf.Value) Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 5, "E").value = "'" & dtpDekkingVanaf.Value
        'End If

        ''Only for house owner
        'If CoverType = "HO" Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 1, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 1, "J").value = rsProperty.Fields(loanOrgField).Value
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 2, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 2, "J").value = "'" & rsProperty.Fields("bondNumber").Value
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 3, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 3, "J").value = gen_getPropertyStructure(language, rsProperty.Fields("struktuur").Value)
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 4, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 4, "J").value = gen_getPropertyRoofType(language, rsProperty.Fields("tipe_dak").Value)
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 5, J).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 5, "J").value = "'" & rsProperty.Fields("erfnommer").Value & ""
        'End If

        'rownumber = rownumber + 7
        'Else
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, "C").Font.Size = 9
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().RowHeight. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, "C").RowHeight = 11.25
        'If language = 0 Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, "C").value = "Geen"
        'Else
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, "C").value = "None"
        'End If
        'End If
    End Sub
    'Insert notice of interest for property
    Public Sub insertEndorsement()
        'Dim i As Object
        'Dim myArray As Object
        'Dim endorsementMemo As Object

        ''Insert heading
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Rows._Default(rownumber + 2).Font.Bold = True
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Rows._Default(rownumber + 2).Font.Size = 9

        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 2, 1).value = "'3. "

        'If language = 0 Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 1).value = "Ons noteer nie sessies op ons polis nie, maar bevestig dat die bank se belange as volg in die polis genoteer is:"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 2, 2).value = "VERBANDHOUER"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 4, 2).value = "Die belange van die verbandhouer:"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 5, 2).value = "'3.1"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 5, 3).value = "Kom voor u belange;"
        'Else
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 1).value = "We do not give sessions on our policies but confirm that the bank's interest is noted in the following way in the policy:"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 2, 2).value = "MORTGAGEE"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 4, 2).value = "The interests of the mortgagee:"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 5, 2).value = "'3.1"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 5, 3).value = "rank prior to your interest;"
        'End If
        'rownumber = rownumber + 7

        ''Style
        'With xlsheet.Range("C" & rownumber & ":L" & rownumber)
        '	.Cells.Merge()
        '	.RowHeight = 24.75
        '	.VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop
        '	.HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlJustify
        '	.WrapText = True
        'End With
        'With xlsheet.Range("C" & rownumber + 2 & ":L" & rownumber + 2)
        '	.Cells.Merge()
        '	.RowHeight = 24.75
        '	.VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop
        '	.HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlJustify
        '	.WrapText = True
        'End With

        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().VerticalAlignment. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 2).VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().VerticalAlignment. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 2, 2).VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop

        'If language = 0 Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 2).value = "'3.2"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 3).value = "Is beperk tot die bedrag wat u verskuldig is aan die verbandhouer op die huisleningsrekening met betrekking tot die versekerde woonhuis;"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 2, 2).value = "'3.3"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 2, 3).value = "Sal nie ongeldig gemaak (nietig verklaar) word deur enige handeling of nalating van u kant, ook nie as sodanige handeling sonder die medewete van die verbandhouer geskied nie."
        'Else
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 2).value = "'3.2"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 3).value = "are limited to the amount owing to the mortgagee by you on the home loan account in respect of the insured dwelling;"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 2, 2).value = "'3.3"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 2, 3).value = "will not be invalidated by any act or omission of yours if the act or omission occurs without the mortgagee's knowledge."
        'End If

        'rownumber = rownumber + 3

        ''Insert heading
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Rows._Default(rownumber + 2).Font.Bold = True
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Rows._Default(rownumber + 2).Font.Size = 9

        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 2, 1).value = "'4. "

        'If language = 0 Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 2, 2).value = "PERSOONLIKE AANSPREEKLIKHEID"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 4, 2).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 4, 2).value = "Persoonlike Aanspreeklikheid is ingesluit in die polis ter waarde van R " &Format(gen_getPlipCoverValue(Persoonl.Fields("plip1").Value), "#,##0.00")
        'Else
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 2, 2).value = "PUBLIC LIABILITY COVER"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 4, 2).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 4, 2).value = "Public Liability cover is included in the policy worth R " &Format(gen_getPlipCoverValue(Persoonl.Fields("plip1").Value), "#,##0.00")
        'End If
        'rownumber = rownumber + 4

        ''Style
        'With xlsheet.Range("B" & rownumber & ":L" & rownumber)
        '	.Cells.Merge()
        '	.RowHeight = 24.75
        '	.VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop
        '	.HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlJustify
        '	.WrapText = True
        'End With

        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().VerticalAlignment. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 2).VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop

        ''Insert heading
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Rows._Default(rownumber + 2).Font.Bold = True
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Rows._Default(rownumber + 2).Font.Size = 9

        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 2, 1).value = "'5. "

        'If language = 0 Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 2, 2).value = "JAARLIKSE AANPASSING"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 4, 2).value = "Die Makelaar onderneem om 'n jaarlikse eskalasie in waarde op die eiendom te doen."
        'Else
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 2, 2).value = "ANNUAL ADJUSTMENTS"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 4, 2).value = "The Broker undertakes to perform an annual increase on the value of the property."
        'End If
        'rownumber = rownumber + 4

        ''Style
        'With xlsheet.Range("B" & rownumber & ":L" & rownumber)
        '	.Cells.Merge()
        '	.RowHeight = 24.75
        '	.VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop
        '	.HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlJustify
        '	.WrapText = True
        'End With

        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().VerticalAlignment. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 2).VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop

        ''Check if landslide endorsement was linked to this policy
        'If Huis_EF.LandslideEndorsementLinked(Persoonl.Fields("polisno").Value) Then
        '	'Get endorsement
        '	If language = 0 Then
        '		'UPGRADE_WARNING: Couldn't resolve default property of object endorsementMemo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		endorsementMemo = Huis_EF.getLandslideEndorsement("99A")
        '	Else
        '		'UPGRADE_WARNING: Couldn't resolve default property of object endorsementMemo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		endorsementMemo = Huis_EF.getLandslideEndorsement("99E")
        '	End If

        '	rownumber = rownumber + 1
        '	'Place each line into an array item
        '	'UPGRADE_WARNING: Couldn't resolve default property of object endorsementMemo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object myArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	myArray = Split(endorsementMemo, Chr(13))

        'For i = 0 To UBound(myArray)
        '    'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    With xlsheet.Range("B" & rownumber + i & ":L" & rownumber + i)
        '        'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        .Merge()
        '        'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        .RowHeight = 11.25 * Int((Len(myArray(i)) / 110) + 1)
        '        'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        .VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop
        '        'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        .HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlJustify
        '    End With
        '    'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + i, B).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object myArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + i, "B").value = Replace(Replace(Replace(myArray(i), Chr(10), ""), "2.", "6."), Chr(9), "   ")
        'Next

        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().VerticalAlignment. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 1).VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 1).value = "'6."
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 2).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Cells._Default(rownumber, 2).value = UCase(xlsheet.Cells._Default(rownumber, 2).value)
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Cells._Default(rownumber, 2).Font.Bold = True
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Cells._Default(rownumber, 1).Font.Bold = True
        'End If

        '      'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      rownumber = rownumber + i + 1
    End Sub
    'UPGRADE_WARNING: Event rdBuiteland.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub rdBuiteland_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rdBuiteland.CheckedChanged
        If eventSender.Checked Then
            Me.rdEngels.Checked = True
            Me.rdAfrikaans.Enabled = False

            'Populate items
            'PopulateListForVoertue() '(True, False)
            lstInsuredItems.DisplayMember = "bevestigDesc"
            lstInsuredItems.ValueMember = "bevestigCode"
            lstInsuredItems.DataSource = PopulateListForVoertue()

        End If
    End Sub

    'UPGRADE_WARNING: Event rdLokaal.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub rdLokaal_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rdLokaal.CheckedChanged
        If eventSender.Checked Then
            Me.rdEngels.Checked = False
            Me.rdAfrikaans.Enabled = True
            Me.rdAfrikaans.Checked = True

            'Populate items
            ' populateLstInsruredItems(True, True)

            lstInsuredItems.DisplayMember = "bevestigDesc"
            lstInsuredItems.ValueMember = "bevestigCode"
            lstInsuredItems.DataSource = bevestigDescFunction()
        End If
    End Sub

    Private Sub cmbTitel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTitel.SelectedIndexChanged

        If cmbTitel.SelectedIndex = -1 Then
            Exit Sub
        End If
    End Sub
    Sub Populatefields()

        cmbTitel.DataSource = ListTitle(Integer.Parse(Persoonl.TAAL))

        cmbTitel.DisplayMember = "Title"
        cmbTitel.SelectedItem = Persoonl.TITEL

        Me.cmbTitel.Enabled = True

    End Sub


    Private Sub lstInsuredItems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstInsuredItems.SelectedIndexChanged

    End Sub
End Class