Option Strict Off
Option Explicit On

Imports System.Data.SqlClient
Imports DAL
Imports System.IO
Imports System.Configuration
Imports Microsoft.Reporting.WinForms
Imports System.Net

Friend Class BriefSkedule
    Inherits BaseForm

    'Dim xlapp As Microsoft.Office.Interop.Excel.Application
    'Dim xlbook As Microsoft.Office.Interop.Excel.Workbook
    'Dim xlsheet As Microsoft.Office.Interop.Excel.Worksheet
    'Dim xlRange As Microsoft.Office.Interop.Excel.Range
    Dim sSql As String
    Dim sStr As String
    Dim rownumber As Short 'Current rownumber in letter
    Dim letterSubject As String
    Dim language As Byte 'The language of the current policy holder
    Dim letternumber As Short
    Dim holderTitle As String
    Dim lastColumn As String
    Dim totalVehiclePremium As Double
    Dim totalPropertyPremium As Double
    Dim totalARPremium As Double
    Dim headingNumber As String
    Dim blnUserControl As Boolean
    Dim tempFilename As String
    Dim fs As Object
    Dim formattingArray() As String
    Dim longTermStart As Date
    Dim longTermEnd As Date
    Dim longtermMonths As Byte
    Dim longtermPeriod As String
    Dim TermDesc As String
    Dim StatusDesc As String
    Dim TermStatus As Byte
    Dim VersekeraarSql As String

    'Dim rsVersekeraar As DAO.Recordset

    'Dim rsAreaBrief As DAO.Recordset
    Dim rownumberpremie As Short
    Dim rownumberpolispakket As Short
    Dim strAreaBranch As String
    Dim dblPolisPakket As Double
    Public result As Byte() = Nothing

    Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click

    End Sub

    Private Sub btnHelp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnHelp.Click
        Dim message As Object

        message = "Information relating to the printing of schedules." & Chr(10) & Chr(10)
        message = message & Chr(149) & "  Hold 'Ctrl' from more than one area seemed to be chosen" & Chr(10)
        message = message & Chr(149) & "  For eg. all the surnames beginning with A press key 'A' and 'Az' in the from and to fields" & Chr(10)
        message = message & Chr(149) & "  The schedules to the 'default' printer printed" & Chr(10)
        message = message & Chr(149) & "  The schedules are printed one by one" & Chr(10)
        message = message & Chr(149) & "  It is better to print smaller volumes at a time " & Chr(10)
        message = message & Chr(149) & "  The schedules are only'd'Preview when a scheme to print" & Chr(10)
        message = message & Chr(149) & "  A list of schedules will be printed, appears only when more than one" & Chr(10)
        message = message & Chr(149) & "When the amended date had'check, it is taken into account, otherwise " & Chr(10)

        MsgBox(message, MsgBoxStyle.Information)
    End Sub

    'Build the sql query, loop through recordset and generate letters according to criteria
    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click

            If rdHuidig.Checked Then
                BriefStatus.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                BriefStatus.DataGridView1.ReadOnly = True
                BriefStatus.DataGridView1.AutoGenerateColumns = False
                BriefStatus.DataGridView1.DataSource = BriefGeneries.CurrentPolicy

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
                    gen_ArchiveDocument(result, Persoonl.POLISNO, 7, "", "", "", "")
                    ElseIf rdEpos.Checked Then
                        CreateReportFile()
                    gen_ArchiveDocument(result, Persoonl.POLISNO, 7, emailEngine.txtSubject.Text, emailEngine.txtTo.Text, emailEngine.txtBody.Text, getAttachmentsForEmailEngine, tempFilename)
                        emailEngine.sendMail(emailEngine.txtTo.Text, emailEngine.txtSubject.Text, emailEngine.txtBody.Text, tempFilename)
                    End If
                    Exit Sub
                Else
                BriefSkeduleReportViewer.Show()
                    Exit Sub
                End If
            End If

            If Me.cmbVersekeraar.SelectedIndex = -1 And Me.rdSpesifieke.Checked = True Then
                MsgBox("An insurer must be selected if more than one schedule to print.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Validate form

            '
            BriefStatus.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            BriefStatus.DataGridView1.ReadOnly = True
            BriefStatus.DataGridView1.AutoGenerateColumns = False
            BriefStatus.DataGridView1.DataSource = BuildSql()
            BriefStatus.txtFormToPopulate.Text = Me.Name

            If BriefStatus.DataGridView1.RowCount = 1 Then
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

                Else
                    BriefSkeduleReportViewer.Show()
                End If

            ElseIf BriefStatus.DataGridView1.RowCount < 1 Then
                MsgBox("No record match the criteria.")
                Exit Sub
            Else
                BriefStatus.ShowDialog()
            End If

    End Sub
    Sub CreateReportFile()
        Dim detailStream As Stream
        detailStream = createDetailFile("/Mooirivier/BriefSkedule")
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
            Dim AfriEngl As String
            Dim termInformation As String = ""
            Dim longtermMonths As String = ""
            Dim PlipCoverValue As Integer
            Dim ChkKantoor As Integer
            Dim chkBesonderherdeVersekerde As Integer
            Dim chkOpsommingVersekering As Integer
            Dim chkUiteensettingPremie As Integer
            Dim chkbesonderherdeItems As Integer
            Dim chkBybetalings As Integer
            Dim chkLaastewysigings As Integer
            Dim chkEndossemente As Integer
            Dim chkAddisioneleVoorwaardes As Integer
            Dim totPaid As Double
            Dim Startdate As String
            Dim Enddate As String
            Dim pol_druk As String

            'Assign Policy number
            If rdHuidig.Checked = True Then
                'Andriette 01/08/2013 verander die global variable 
                glbPolicyNumber = Persoonl.POLISNO
            ElseIf rdSpesifieke.Checked = True Then
                'Andriette 01/08/2013 verander die global variable
                glbPolicyNumber = BriefStatus.DataGridView1.Rows(0).Cells(0).Value
            Else
                rdSpesifieke.Checked = True
                'Andriette 01/08/2013 verander die global variable
                glbPolicyNumber = BriefStatus.DataGridView1.SelectedRows(0).Cells(0).Value
            End If
            'Poldruk parameter
            If rdKlient.Checked = True Then
                pol_druk = "J"
            Else
                pol_druk = ""
            End If

            totPaid = 0
            LongTermPolicy = ReportFetchLangTermPolicy()
            Startdate = Format(LongTermPolicy.DatumBegin, "dd/MM/yyyy")
            Enddate = Format(LongTermPolicy.DatumEindig, "dd/MM/yyyy")
           
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@startdate", SqlDbType.NVarChar), _
                                                New SqlParameter("@enddate", SqlDbType.NVarChar)}

                param(0).Value = Persoonl.POLISNO
                param(1).Value = Startdate
                param(2).Value = Enddate

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[Report_gen_getTermPolicyAmtPaid]", param)

                Do While reader.Read
                    If reader("tipe") = "TB" Then
                        totPaid = totPaid - reader("vord_premie")
                    Else
                        totPaid = totPaid + reader("vord_premie")
                    End If
                Loop
            End Using

            PrimaryKeyVoertuie = FetchPKvoertuie()
            fetchHuisForGeyser = ReportFetchHuisPk()
            FetchEndosidentifikasie = ReportFetchEndosidentifikasie()

            If Persoonl.TAAL = 0 Then
                AfriEngl = "A"
            Else
                AfriEngl = "E"
            End If

            If Trim(Persoonl.BET_WYSE) = "6" Then
                If strTermStatus <> 4 And strTermStatus <> 5 Then
                    termInformation = TermDesc
                    longtermMonths = strTermMonthCount
                End If
            Else
                longtermMonths = 1 'Default to one month policy
                termInformation = ""
                'Reset other values
                TermDesc = ""
                StatusDesc = ""
                strTermStatus = 5
            End If
            If rdHuidig.Checked = True And rdKlient.Checked = True Then
                chkBesonderherdeVersekerde = 1
                chkOpsommingVersekering = 1
                chkUiteensettingPremie = 1
                chkbesonderherdeItems = 1
                chkBybetalings = 1
                chkLaastewysigings = 1
                chkEndossemente = 1
                chkAddisioneleVoorwaardes = 1
            ElseIf rdHuidig.Checked = True And rdKantoor.Checked = True Then

                If chkBesonderhedeVersekerde.Checked = True Then
                    chkBesonderherdeVersekerde = 1
                Else
                    chkBesonderherdeVersekerde = 0
                End If
                If Me.chkOpsommingVersekering.Checked = True Then
                    chkOpsommingVersekering = 1
                Else
                    chkOpsommingVersekering = 0
                End If
                If Me.chkUiteensettingPremie.Checked = True Then
                    chkUiteensettingPremie = 1
                Else
                    chkUiteensettingPremie = 0
                End If
                If chkBesonderhedeItems.Checked = True Then
                    chkbesonderherdeItems = 1
                Else
                    chkbesonderherdeItems = 0
                End If
                If Me.chkBybetalings.Checked = True Then
                    chkBybetalings = 1
                Else
                    chkBybetalings = 0
                End If
                If Me.chkLaasteWysigings.Checked = True Then
                    chkLaastewysigings = 1
                Else
                    chkLaastewysigings = 0
                End If
                If chkEdossemente.Checked = True Then
                    chkEndossemente = 1
                Else
                    chkEndossemente = 0
                End If
                If Me.chkAddisioneleVoorwaardes.Checked = True Then
                    chkAddisioneleVoorwaardes = 1
                Else
                    chkAddisioneleVoorwaardes = 0
                End If

            ElseIf rdSpesifieke.Checked = True And rdKlient.Checked = True Then
                chkBesonderherdeVersekerde = 1
                chkOpsommingVersekering = 1
                chkUiteensettingPremie = 1
                chkbesonderherdeItems = 1
                chkBybetalings = 1
                chkLaastewysigings = 1
                chkEndossemente = 1
                chkAddisioneleVoorwaardes = 1
            Else
                If chkBesonderhedeVersekerde.Checked = True Then
                    chkBesonderherdeVersekerde = 1
                Else
                    chkBesonderherdeVersekerde = 0
                End If
                If Me.chkOpsommingVersekering.Checked = True Then
                    chkOpsommingVersekering = 1
                Else
                    chkOpsommingVersekering = 0
                End If
                If Me.chkUiteensettingPremie.Checked = True Then
                    chkUiteensettingPremie = 1
                Else
                    chkUiteensettingPremie = 0
                End If
                If chkBesonderhedeItems.Checked = True Then
                    chkbesonderherdeItems = 1
                Else
                    chkbesonderherdeItems = 0
                End If
                If Me.chkBybetalings.Checked = True Then
                    chkBybetalings = 1
                Else
                    chkBybetalings = 0
                End If
                If Me.chkLaasteWysigings.Checked = True Then
                    chkLaastewysigings = 1
                Else
                    chkLaastewysigings = 0
                End If
                If chkEdossemente.Checked = True Then
                    chkEndossemente = 1
                Else
                    chkEndossemente = 0
                End If
                If Me.chkAddisioneleVoorwaardes.Checked = True Then
                    chkAddisioneleVoorwaardes = 1
                Else
                    chkAddisioneleVoorwaardes = 0
                End If
            End If

            'Checkboxes to values
            If rdKantoor.Checked = True Then
                ChkKantoor = 1
            Else
                ChkKantoor = 0
            End If

            'flip value parameter
            'Andriette 14/08/2014 skuif die waarde na die tabel
            'PlipCoverValue = gen_getPlipCoverValue(Persoonl.PLIP1)
            PlipCoverValue = Constants.PlipCoverValue

            'Andriette 01/08/2013 verander die global variable
            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", glbPolicyNumber), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", Persoonl.TAAL), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Area_kode", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("pkVoertuie", PrimaryKeyVoertuie.pkVoertuie), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("pkHuis", fetchHuisForGeyser.pkHuis), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Language", Persoonl.TAAL), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Branchcode", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Endoslist", FetchEndosidentifikasie.Endosidentifikasie), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("TaalAfriEng", AfriEngl), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("termInformation", termInformation), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("StartAfsluit", Startdate), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("EndAfsluit", Enddate), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("longtermMonths", longtermMonths), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("KontantTotal", totPaid), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("PlipCoverValue", PlipCoverValue), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("pol_druk", pol_druk), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("bet_wyse", Persoonl.BET_WYSE), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("ChkKantoor", ChkKantoor), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("chkBesonderherdeVersekerde", chkBesonderherdeVersekerde), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("chkOpsommingVersekering", chkOpsommingVersekering), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("LongtermStatus", strTermStatus), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("chkUiteensettingPremie", chkUiteensettingPremie), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("chkbesonderherdeItems", chkbesonderherdeItems), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("chkBybetalings", chkBybetalings), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("chkLaastewysigings", chkLaastewysigings), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("chkEndossemente", chkEndossemente), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("chkAddisioneleVoorwaardes", chkAddisioneleVoorwaardes)}

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
            Return Nothing
        End Try
    End Function
    'Insert the section containing the policyholders' details
    Public Sub insertPolicyHolderDetail()

    End Sub
 

    'Enable, disable afdelings
    Public Sub enableAfdelings(ByRef enable As Boolean)
        Me.chkAddisioneleVoorwaardes.Enabled = enable
        Me.chkBesonderhedeItems.Enabled = enable
        Me.chkBesonderhedeVersekerde.Enabled = enable
        Me.chkBybetalings.Enabled = enable
        Me.chkEdossemente.Enabled = enable
        Me.chkLaasteWysigings.Enabled = enable
        Me.chkOpsommingVersekering.Enabled = enable
        Me.chkUiteensettingPremie.Enabled = enable
        Me.frmAfdelings.Enabled = enable
    End Sub

    Private Sub rdHuidig_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rdHuidig.CheckedChanged
        If eventSender.Checked Then
            If rdHuidig.Checked Then
                Me.lstArea.Enabled = False
                Me.txtVanaf.Enabled = False
                Me.txtTot.Enabled = False
                Me.lblTaal.Enabled = False
                Me.cmbTaal.Enabled = False
                Me.rdKlient.Enabled = True
                Me.rdKantoor.Enabled = True
                Me.Label1.Enabled = False
                Me.Label2.Enabled = False
                Me.Label3.Enabled = False
                Me.Label5.Enabled = False
                Me.cmbStatus.Enabled = False
                Me.frmKriteria.Enabled = False
                Me.lblPosbestemming.Enabled = False
                Me.cmbPosbestemming.Enabled = False
                Me.cmbVersekeraar.Enabled = False
                Me.lblVersekeraar.Enabled = False
                Me.cmbVersekeraar.SelectedIndex = -1

                'You should not be able to print a schedule to a client after it has been cancelled(except if you specify criteria)
                If Persoonl.GEKANS Then
                    Me.rdKlient.Enabled = False
                    Me.rdKantoor.Checked = True
                End If
            End If
        End If
    End Sub

    Private Sub rdKlient_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rdKlient.CheckedChanged
        If eventSender.Checked Then
            enableAfdelings(False)
            Me.rdEpos.Enabled = True
        End If
    End Sub
    'UPGRADE_WARNING: Event rdKantoor.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub rdKantoor_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rdKantoor.CheckedChanged
        If eventSender.Checked Then
            enableAfdelings(True)

            'Set default sections
            Me.chkOpsommingVersekering.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkUiteensettingPremie.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkLaasteWysigings.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkAddisioneleVoorwaardes.CheckState = System.Windows.Forms.CheckState.Checked

            Me.rdDrukker.Checked = True
            Me.rdEpos.Enabled = False
        End If
    End Sub

    Private Sub rdSpesifieke_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rdSpesifieke.CheckedChanged
        If eventSender.Checked Then
            Dim i As Object
            If rdSpesifieke.Checked Then
                Me.lstArea.Enabled = True
                Me.txtVanaf.Enabled = True
                Me.txtTot.Enabled = True
                Me.lblTaal.Enabled = True
                Me.cmbTaal.Enabled = True
                Me.rdKlient.Enabled = True
                Me.rdKantoor.Enabled = True
                Me.dtpGewysig.Enabled = True
                Me.Label1.Enabled = True
                Me.Label2.Enabled = True
                Me.Label3.Enabled = True
                Me.Label5.Enabled = True
                Me.cmbStatus.Enabled = True
                Me.frmKriteria.Enabled = True

                'Clear selection
                For i = 0 To lstArea.Items.Count - 1
                    Me.lstArea.SetSelected(i, False)
                Next

                Me.lstArea.SelectedIndex = 0
                Me.lstArea.SetSelected(0, True)
                Me.txtTot.Text = ""
                Me.txtVanaf.Text = ""
                Me.cmbStatus.SelectedIndex = 1
                Me.cmbTaal.SelectedIndex = 0
                Me.lblPosbestemming.Enabled = True
                Me.cmbPosbestemming.Enabled = True
                Me.cmbPosbestemming.SelectedIndex = 0
                Me.lblVersekeraar.Enabled = True
                Me.cmbVersekeraar.Enabled = True
                Me.cmbVersekeraar.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub BriefSkedule_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        PopulateArea()
        Me.dtpGewysig.Value = Format(Now, "dd/MM/yyyy")
        PopulateVersekeraar()

        'You should not be able to print a schedule to a client after it has been cancelled(except if you specify criteria)
        If Persoonl.GEKANS Then
            Me.rdKlient.Enabled = False
            Me.rdKantoor.Checked = True
        End If
        dtpGewysig.Checked = False
        rdHuidig.Checked = True
        Me.Text = My.Application.Info.Title & " - Reports - Policy Schedules"
    End Sub
    Sub PopulateVersekeraar()
        'cmbVersekeraar.Items.Clear()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVersekeraar")
                Dim list As List(Of String) = New List(Of String)

                While reader.Read()
                    Dim item As VersekeraarEntity = New VersekeraarEntity()
                    If reader("naam") IsNot DBNull.Value Then
                        item.Naam = reader("naam")
                    End If
                    list.Add(item.Naam)
                End While
                If list.Count > 0 Then
                    cmbVersekeraar.DataSource = list
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            End
        End Try
        cmbVersekeraar.SelectedIndex = -1

    End Sub
    Sub PopulateArea()
        'lstArea.Items.Clear()

        If ListAreaDropdown.Count > 0 Then
            lstArea.DataSource = ListAreaDropdown()
        End If
    End Sub
  

    Private Function FilterArea(ByVal area As AreaEntity) As Boolean

        If area.Tak_Naam = "MM Jeffreysbaai" Then
            Return True
        Else
            Return False
        End If
    End Function

    Function BuildSql()

        Try
            Dim strArea As String
            strArea = ""


            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Language", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlStatus", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlArea", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlSurnameFrom", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlSurnameTo", SqlDbType.NVarChar), _
                                                New SqlParameter("@Sqlposbestemming", SqlDbType.NVarChar), _
                                                New SqlParameter("@dtpGewysig", SqlDbType.VarChar), _
                                                New SqlParameter("@TYPE", SqlDbType.VarChar), _
                                                New SqlParameter("@sqlVersekeraar", SqlDbType.NVarChar)}

                If rdSpesifieke.Checked Then
                    Select Case cmbTaal.SelectedIndex
                        Case 0
                            params(0).Value = DBNull.Value
                        Case 1 'Afr
                            params(0).Value = CStr(0)
                        Case 2 'Eng
                            params(0).Value = 1
                    End Select
                Else
                    params(0).Value = DBNull.Value
                End If

                'Sql for status
                Select Case cmbStatus.SelectedIndex
                    Case 0
                        params(1).Value = DBNull.Value
                    Case 1
                        params(1).Value = "0"
                    Case 2
                        params(1).Value = "1"
                End Select

                'If Gebruiker.titel = "Programmeerder" Then
                If lstArea.SelectedIndex <> -1 And lstArea.SelectedIndex <> 0 Then
                    For i = 0 To lstArea.SelectedItems.Count - 1
                        strArea = strArea + "'" + lstArea.SelectedItems(i) + "',"
                    Next
                    strArea = Mid(strArea, 1, Len(strArea) - 1)
                    'Mid(params(2).Value, Len(params(2).Value) - 1)

                End If
                ' Else
                If lstArea.SelectedIndex = 0 Then
                    params(2).Value = ""
                Else
                    For i = 0 To lstArea.Items.Count - 1
                        If lstArea.GetSelected(i) Then
                            strArea = strArea + "'" + lstArea.SelectedItems(i) + "',"
                        End If
                    Next
                    strArea = Mid(strArea, 1, Len(strArea) - 1)

                    params(2).Value = strArea

                End If





                'Surname
                If Trim(txtVanaf.Text) <> "" Then
                    params(3).Value = Trim(txtVanaf.Text)
                Else
                    params(3).Value = ""
                End If
                '
                If Trim(txtTot.Text) <> "" Then
                    params(4).Value = txtTot.Text + "zzzz"
                Else
                    params(4).Value = "zzzz"
                End If
                'Destination parameter
                Select Case cmbPosbestemming.SelectedIndex
                    Case 0
                        params(5).Value = DBNull.Value
                    Case 1
                        params(5).Value = "0"
                    Case 2
                        params(5).Value = "1"
                    Case 3
                        params(5).Value = "2"
                    Case 4
                        params(5).Value = "3"
                End Select
                'Date parameter
                If dtpGewysig.Checked Then

                    params(6).Value = Format(dtpGewysig.Value, "yyyy-MM-dd")
                Else
                    params(6).Value = ""
                End If
                'type parameter
                If rdKantoor.Checked = True Then
                    params(7).Value = "Office"
                Else
                    params(7).Value = "Client"
                End If
                params(8).Value = cmbVersekeraar.SelectedItem

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[ReportFetchPersoonlForSkedule]", params)

                Dim list As List(Of PersoonlCriteria) = New List(Of PersoonlCriteria)

                While reader.Read()
                    Dim item As PersoonlCriteria = New PersoonlCriteria()

                    If Not IsDBNull(reader("POLISNO")) Then
                        item.PolisNo = reader("POLISNO")
                    End If
                    If Not IsDBNull(reader("VERSEKERDE")) Then
                        item.Surname = reader("VERSEKERDE")
                    End If
                    If Not IsDBNull(reader("VOORL")) Then
                        item.voorl = reader("VOORL")

                    End If
                    If Not IsDBNull(reader("AREA_BESK")) Then
                        item.Area = reader("AREA_BESK")
                    End If
                    item.posbestemming = reader("POSBESTEMMING")

                    If Persoonl.TAAL = 0 Then 'Afr

                        If item.posbestemming = "0" Then 'Posadres
                            item.SavePosbesbesteming = "Posadres"
                        ElseIf item.posbestemming = "1" Then 'Risikoadres
                            item.SavePosbesbesteming = "Risiko-adres"
                        ElseIf item.posbestemming = "2" Then 'Universiteitsposbus
                            item.SavePosbesbesteming = "Universiteitsposbus"
                        ElseIf item.posbestemming = "3" Then 'E-pos
                            item.SavePosbesbesteming = "E-pos"
                        Else
                            item.SavePosbesbesteming = "Foutiewe posbestemming"
                        End If

                    Else 'Eng
                        If item.posbestemming = "0" Then 'Postal address
                            item.SavePosbesbesteming = "Postal address"
                        ElseIf item.posbestemming = "1" Then 'Risk address
                            item.SavePosbesbesteming = "Risk address"
                        ElseIf item.posbestemming = "2" Then 'University mailbox
                            item.SavePosbesbesteming = "University mailbox"
                        ElseIf item.posbestemming = "3" Then 'Email
                            item.SavePosbesbesteming = "Email"
                        Else
                            item.SavePosbesbesteming = "Incorrect mailing destination"
                        End If

                    End If
                    If Persoonl.TAAL = 0 Then
                        Select Case Persoonl.GEKANS
                            Case True
                                getStatus = "Gekansellee"
                                item.Status = getStatus
                            Case False
                                getStatus = "Aktief"
                                item.Status = getStatus
                            Case Else
                                getStatus = "Onbekend"
                                item.Status = getStatus
                        End Select
                    Else
                        Select Case Persoonl.GEKANS
                            Case True
                                getStatus = "Cancelled"
                                item.Status = getStatus
                            Case False
                                getStatus = "Active"
                                item.Status = getStatus
                            Case Else
                                getStatus = "Unknown"
                                item.Status = getStatus
                        End Select
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

    Private Sub lstArea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstArea.SelectedIndexChanged

    End Sub
End Class