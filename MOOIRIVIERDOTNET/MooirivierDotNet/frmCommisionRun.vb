'********************************************************************
'Linkie 10/06/2013
'Form to handle the commission run that was on stats and multistats
'*******************************************************************
Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Data.SqlClient
Imports DAL
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Public Class frmCommisionRun
    Dim blnCommissionValidated As Boolean
    Dim clsRun As New clsRuns()
    Dim strTak As String
    Dim dteAfsluitdat As Date
    Dim dteVanaf As Date
    Dim dteTot As Date
    Dim dblSubtotaal, dblEispers, dblOnderlyn, dblPremie2, dblVerwyskommissieVorigeAfsluiting As Decimal
    Dim dteVorigeAfsluiting As Date
    Dim strBetwyse As String
    Dim strArea As String
    Dim dblVorderPremie As Decimal
    Dim strBetaalwyseVerwyser As String
    Dim dblVTTotaal As Decimal
    Dim dblKOTotaal As Decimal
    Dim dblVerwysKommissieTotaal, dblVerwysKommissie As Decimal
    Dim dblAdditionalPremiumforClosedPeriod As Decimal
    Dim dblAPOnderlyn As Decimal
    Dim dblVerwysdeKorting As Decimal
    Dim dblVerwysdepremie As Decimal
    Dim strBeskrywing As String
    Dim strGebruiker As String
    Dim intMakelaarfk As Integer
    Dim strKommissieArea As String
    Dim dblBalans As Decimal
    Dim strBetaalwyseKommissie As String
    Dim intfkVersekeraar As Integer
    Dim dblBeskermingTot As Decimal
    Dim dblSaspremTot As Decimal
    Dim dblTV_diensTot As Decimal
    Dim dblPolfooiTot As Decimal
    Dim dblBegrafnisTot As Decimal
    Dim dblPlipTot As Decimal
    Dim dblCourtesyvTot As Decimal
    Dim dblEpcTot As Decimal
    Dim dblCareAssistTot As Decimal
    Dim dblInscellTot As Decimal
    Dim dblSubMinKortingTot As Decimal
    Dim dblBedragFinTotaal As Decimal
    Dim dblKontroleFinTotaal As Decimal
    Dim dblFintot(25)
    Dim dblSelfoonVerwagtePremieTotaal, dblSpesialeKorting, dblPremievoorKorting1, dblPremievoorKorting2 As Decimal
    Dim dblMotorsAP, dblAlleRisikoAP, dblHBAP, dblHEAP, dblHBGrasAP, dblHEGrasAP, dblToevalEEMAP, dblToevalBreekAP, dblWaterleweAP As Decimal
    Dim dblBegrafnisAP, dblSasriaAP, dblMedies, dblPolisfooiAP, dblPlipAP, dblTVDiensAP, dblBeskermAP, dblCourtesyvAP, dblEPCAP, dblCareAssistAP, dblSelfoonAP, dblSpesialeKortingAP, dblPakketitem1AP, dblPakketitem2AP, dblPakketitem3AP, dblPakketitem4AP As Decimal
    Dim strLopieTipe As String
    Dim strVersekerde, strVoorl, strPolisno As String
    Dim intlopiehetrekords As Integer
    Dim intJaar As Integer
    Dim intMnd As Integer
    Dim arPaid(0, 0)
    Dim dblBedrag As Decimal
    Dim strKommissieKategorie As String
    Dim strBeskArea As String
    Dim intBetaalwysekommissie As Integer
    Dim strAreaBesk As String
    Dim dblOorblyBedrag As Decimal
    Dim dblOorblyBedrag1 As Decimal

    Private Sub frmCommisionRun_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim strParamaterMaandBetaalwyse As String

        ReDim arPaid(2, 1)

        Me.dtpSalary1.Enabled = False
        Me.dtpSalary2.Enabled = False
        Me.Label15.Text = ""
        Me.Label16.Text = ""

        cmbInsurer.DataSource = BaseForm.FillCombo("poldata5.FetchVersekeraar", "pkVersekeraar", "Naam", "", "", "", "")
        cmbInsurer.DisplayMember = "ComboBoxName"
        cmbInsurer.ValueMember = "ComboBoxID"

        Me.cmbInsurer.Text = ""

        cmbBroker.DataSource = BaseForm.FillCombo("Poldata5.Listbroker", "pkMakelaar", "BeskrywingEng", "", "", "", "")
        cmbBroker.DisplayMember = "ComboBoxName"
        cmbBroker.ValueMember = "ComboBoxID"

        Me.cmbBroker.Text = ""

        cmbMarketer.DataSource = BaseForm.FillCombo("Poldata5.Listbemarker", "kode_bem_num", "Naam", "", "", "", "")
        cmbMarketer.DisplayMember = "ComboBoxName"
        cmbMarketer.ValueMember = "ComboBoxID"

        Me.cmbMarketer.Text = ""

        'last  debietorder afsluitdatum
        strParamaterMaandBetaalwyse = "4"
        clsRun.MaxAfsluitDatMaand(strParamaterMaandBetaalwyse)
        Me.dtpPreviousFinalRun.Value = glbMaxAfsluitDatMaand

        Me.dtpFrom.Value = CDate("20/" & Month(glbMaxAfsluitDatMaand) & "/" & Year(glbMaxAfsluitDatMaand))
        Me.dtpTo.Value = CDate("19/" & Month(glbMaxAfsluitDatMaand.AddMonths(1)) & "/" & Year(glbMaxAfsluitDatMaand.AddMonths(1)))

        GetBranch()

        If strTak = "Flagship" Then
            Me.dtpSalary1.Enabled = True
            Me.Label15.Text = "PUK salary date"
        ElseIf strTak = "Bloemfontein" Then
            Me.dtpSalary1.Enabled = True
            Me.dtpSalary2.Enabled = True
            Me.Label15.Text = "UV salary date"
            Me.Label16.Text = "SUT salary date"
        End If

        'last msafsluitdatum
        If Me.dtpSalary1.Enabled = True Then
            strParamaterMaandBetaalwyse = "3"
            clsRun.MaxAfsluitDatMaand(strParamaterMaandBetaalwyse)
            Me.dtpSalary1.Value = glbMaxAfsluitDatMaand
        End If

        'last msafsluitdatum
        If Me.dtpSalary2.Enabled = True Then
            strParamaterMaandBetaalwyse = "3"
            clsRun.MaxAfsluitDatMaand(strParamaterMaandBetaalwyse)
            Me.dtpSalary2.Value = glbMaxAfsluitDatMaand
        End If

        If Gebruiker.titel = "Programmeerder" Then
            Me.chkDatabaseBackup.Visible = True
            Me.Label27.Visible = True
        End If
    End Sub
    Public Sub GetBranch()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchTak")

                If reader.Read Then
                    strTak = reader("Tak_naam")
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub CommissionValidate()
        blnCommissionValidated = False

        'Insurer must be chosen
        If Me.cmbInsurer.Text = "" Then
            MsgBox("A insurer must be chosen.", vbInformation)
            blnCommissionValidated = False
            Me.cmbInsurer.Focus()
            Me.btnOk.Enabled = True
            Exit Sub
        End If

        'Date must be checked
        If Me.dtpPreviousFinalRun.Checked = False Then
            MsgBox("A date must be chosen.", vbInformation)
            blnCommissionValidated = False
            Me.dtpPreviousFinalRun.Focus()
            Me.btnOk.Enabled = True
            Exit Sub
        End If

        If Me.dtpSalary1.Enabled = True Then
            If Me.dtpSalary1.Checked = False Then
                MsgBox("A date must be chosen.", vbInformation)
                blnCommissionValidated = False
                Me.dtpSalary1.Focus()
                Me.btnOk.Enabled = True
            End If
        End If

        If Me.dtpSalary2.Enabled = True Then
            If Me.dtpSalary2.Checked = False Then
                MsgBox("A date must be chosen.", vbInformation)
                blnCommissionValidated = False
                Me.dtpSalary2.Focus()
                Me.btnOk.Enabled = True
            End If
        End If

        blnCommissionValidated = True
    End Sub
    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        Dim clsRun As New clsRuns()
        Dim dtpPreviousFinalRun As Date = Me.dtpPreviousFinalRun.Text
        Dim strPath As String = ""
        Dim entTakEntity As New TakEntity
        Dim strTak_afkorting As String = ""

        Me.lblProcessing.Text = "Starting..."
        Me.lblProcessing.Refresh()

        CommissionValidate()

        If blnCommissionValidated = True Then
            Cursor.Current = Cursors.WaitCursor
            Me.lblProcessing.Text = "Validated"
            Me.lblProcessing.Refresh()
            Me.btnOk.Enabled = False
            Me.btnCancel.Enabled = False

            lblProcessing.Text = "Database backup"
            lblProcessing.Refresh()

            'backup database
            strPath = clsRun.gen_getServerPath & "MM Backup"
            If Dir(strPath, vbDirectory) = "" Then MkDir(strPath)
            entTakEntity = clsRun.GetTak
            strTak_afkorting = entTakEntity.Tak_afkorting

            strPath = strPath & "\" & strTak_afkorting & "_Commission.bak"
            If Gebruiker.titel = "Programmeerder" Then
                If Me.chkDatabaseBackup.Checked = True Then
                    clsRun.BackupMooirivierDatabase(strPath)
                End If
            Else
                clsRun.BackupMooirivierDatabase(strPath)
            End If

            clsRun.UpdateGebrukerLopiesRuns("Kommissielopie - " & cmbInsurer.Text, dtpPreviousFinalRun)

            glbVersekeraar = cmbInsurer.SelectedValue
            clsRun.GetInsurerArea()

            clsRun.gen_GetCLRSArea(strTak_afkorting)

            dteAfsluitdat = Me.dtpPreviousFinalRun.Value
            dteVanaf = Me.dtpFrom.Value
            dteTot = Me.dtpTo.Value

            If Me.chkReceiptReportsClaimDate.Checked = True Then

            End If
            If Me.chkReceiptReportsPaymentAreaType.Checked = True Then

            End If
            If Me.chkReceiptReportsBank.Checked = True Then

            End If
            If Me.chkReceiptReportsElectronic.Checked = True Then

            End If
            If Me.chkReceiptReportsPaymentAreaTypePaidBack.Checked = True Then

            End If
            If Me.chkCollectionsRun.Checked = True Then
                'second term policy verwagte premie must be run in order for processing to continue for new term policies added after final run
                Me.lblProcessing.Text = "Term Policy expected premium commission run"
                Me.lblProcessing.Refresh()
                dteMaxBetaalDateAllowed = Today.AddMonths(1).AddDays(-Today().Day + 1)
                frmFinalRun.WriteRekon(6)
            End If

            VerwysdeLopie()

            If Me.chkIncomeReconGeneral.Checked = True Then
                If Me.chkCLRSCommissionGeneral.Checked = True Then
                    'update afsluitdatums in stats5d
                    Me.lblProcessing.Text = "Update table"
                    Me.lblProcessing.Refresh()
                    strKommissieKategorie = "Algemeen"
                    strBeskArea = ""
                    UpdateCommissionAfsluitdatums()

                    'Lopies
                    Me.lblProcessing.Text = "Non-MS Run"
                    Me.lblProcessing.Refresh()
                    'VerwysdeLopie("Nie-MS")

                    strLopieTipe = "Lopie"
                    Kontant_rekon()

                    strLopieTipe = "Rekon"
                    Rekonlopie()
                End If
            End If
            If Me.chkIncomeReconSalary.Checked = True Then
                If Me.chkCLRSCommissionSalary.Checked = True Then
                    'update afsluitdatums in stats5d
                    If strTak = "Flagship" Or strTak = "Bloemfontein" Then
                        strKommissieKategorie = "Salaris"
                        strArea = "2"   'dek MM Puk en MM UV
                        strBeskArea = clsRun.GetArea(strArea)
                        UpdateCommissionAfsluitdatums()

                        If strTak = "Bloemfontein" Then
                            strArea = "3"    'dek MM Sut
                            strBeskArea = clsRun.GetArea(strArea)
                            UpdateCommissionAfsluitdatums()
                        End If

                        'Me.lblProcessing.Text = "MS Run"
                        'Me.lblProcessing.Refresh()
                        ''Lopies
                        'VerwysdeLopie("MS")
                    End If

                    'strLopieTipe = "Lopie"
                    'Kontant_rekon()

                    'strLopieTipe = "Rekon"
                    'Rekonlopie()

                    Me.lblProcessing.Text = "Write CLRS commission File"
                    Me.lblProcessing.Refresh()
                    'CLRS leer skryf
                    WriteCLRSFile()

                End If
            End If
            If Me.chkPaymentRun.Checked = True Then

            End If
            If Me.chkPaymentRunPerBroker.Checked = True Then

            End If
            If Me.chkHobexRun.Checked = True Then

            End If
            If Me.chkReportCommissionBrokerClass.Checked = True Then
                If Me.cmbBroker.Text <> "" And Me.cmbMarketer.Text <> "" Then
                Else
                    MsgBox("You must choose the broker or the marketer to run the report on.", vbInformation)
                End If
            End If

            If Me.chkRoadAssistReport.Checked = True Then

            End If

            Me.lblProcessing.Text = "Finished with commission run"
            Me.lblProcessing.Refresh()

            Cursor.Current = Cursors.Default
            Me.btnOk.Enabled = False
            Me.btnCancel.Enabled = True
            MsgBox("Finished with run", vbInformation)
        End If

    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub UpdateCommissionAfsluitdatums()
        Diagnostics.Debug.WriteLine("updatecommissionafsluitdatums")
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@Tipe", SqlDbType.NVarChar), _
                                                New SqlParameter("@Kategorie", SqlDbType.NVarChar), _
                                                New SqlParameter("@Area", SqlDbType.NVarChar), _
                                                New SqlParameter("@Afsluitdatum", SqlDbType.Date), _
                                                New SqlParameter("@AfsluitVanaf", SqlDbType.Date), _
                                                New SqlParameter("@AfsluitTot", SqlDbType.Date)}

                param(0).Value = "Kommissie"
                param(1).Value = strKommissieKategorie
                param(2).Value = strBeskArea
                param(3).Value = dteAfsluitdat
                param(4).Value = dteVanaf
                param(5).Value = dteTot

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5d.UpdateCommissionRunAfsluitdat", param)

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    'Purpose: To calculate the "Verwysingskorting' for all Verwysdes and to update it to 1) Verwyskommissie in persoonl and 2) update it to verwysdesafsluitings
    'Inputs:  strBetaalwyseBesk
    Private Sub VerwysdeLopie()
        Diagnostics.Debug.WriteLine("verwysdelopie")
        'If strBetaalwyseBesk = "Nie-MS" Then
        '    strBetaalwyseVerwyser = "0"
        'Else
        '    strBetaalwyseVerwyser = "3"
        'End If

        'stel die verwysde status na verval as die tydperk geeindig het
        SetVervalDates()

        'opdateer verwysdes("status") = "Cancelled" se persoonl en verwysdes rekords met nul
        UpdateVerwysdesPersoonl()
    End Sub
    'Purpose:  Update table verwysdes verval date
    Public Sub SetVervalDates()

        Try
            Using connVerwysdeur As SqlConnection = SqlHelper.GetConnection
                Dim paramsVerwysdeur() As SqlParameter = {New SqlParameter("@Einddatum", SqlDbType.Date)}
                paramsVerwysdeur(0).Value = Now()

                Dim readerVerwysdeur As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVerwysdesEinddatum", paramsVerwysdeur)

                Do While readerVerwysdeur.Read
                    Try
                        Using conn As SqlConnection = SqlHelper.GetConnection
                            Dim params() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                        New SqlParameter("@verwysdeur", SqlDbType.NVarChar)}

                            params(0).Value = readerVerwysdeur("verwysde")
                            params(1).Value = ""

                            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.UpdateVerwysdeurInPersoonl", params)

                            If conn.State = ConnectionState.Open Then
                                conn.Close()
                            End If
                        End Using
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try

                    glbPolicyNumber = readerVerwysdeur("verwysde")

                    If readerVerwysdeur("taal") = "0" Then
                        strBeskrywing = "VerwysingsKommissie se datum verval vir polis (" & readerVerwysdeur("verwyser") & ")"
                        strGebruiker = "Stelsel"
                    Else
                        strBeskrywing = "Commission on referred date expired for policy (" & readerVerwysdeur("verwyser") & ")"
                        strGebruiker = "System"
                    End If

                    UpdateWysigGebruiker("142", strBeskrywing, strGebruiker)
                Loop

                If connVerwysdeur.State = ConnectionState.Open Then
                    connVerwysdeur.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Poldata5.UpdateVerwysdesVervalDates")

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub UpdateVerwysdesPersoonl()
        Dim dblVoor As Decimal
        Dim intDekkingJaar As Integer
        Dim intDekkingMaand As Integer
        Dim sngVerwysKommissieTotaal As Single
        Dim blnKommissieIsBereken As Boolean
        Dim strTaal As String
        Dim dblOuVerwyskommissie As Decimal

        Diagnostics.Debug.WriteLine("updateverwysdespersoonl")
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@Status", SqlDbType.NVarChar)
                param.Value = "NotActive"
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Poldata5.FetchDistinctVerwysdes", param)

                Do While reader.Read
                    If reader("verwyser") = "1183005887" Then
                        strPolisno = strPolisno
                    End If
                    'Opdateer verwyser
                    Try
                        Using connPersoonl As SqlConnection = SqlHelper.GetConnection
                            Dim paramPersoonl() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                            New SqlParameter("@Gekans", SqlDbType.NVarChar)}
                            paramPersoonl(0).Value = reader("verwyser")
                            paramPersoonl(1).Value = "False"

                            Dim readerPersoonl As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Poldata5.FetchPersoonlByAreaVerwysdes", paramPersoonl)

                            Do While readerPersoonl.Read
                                dblVoor = readerPersoonl("Verwyskommissie")
                                glbPolicyNumber = readerPersoonl("polisno")

                                BaseForm.UpdatePersoonlPerField("verwyskommissie", 0)

                                If dblVoor <> 0 Then
                                    If readerPersoonl("taal") = "0" Then
                                        strBeskrywing = "VerwysingsKommissie verander van (" & String.Format("{0:N2}", dblVoor) & ") na (0)"
                                        strGebruiker = "Stelsel"
                                    Else
                                        strBeskrywing = "Commission on referred changed from (" & String.Format("{0:N2}", dblVoor) & ") to (0)"
                                        strGebruiker = "System"
                                    End If

                                    UpdateWysigGebruiker("142", strBeskrywing, strGebruiker)
                                End If
                            Loop

                            'Opdateer verwysde
                            Try
                                Using connVerwysde As SqlConnection = SqlHelper.GetConnection
                                    Dim paramVerwysdeUpdate() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                                                                    New SqlParameter("@Status", SqlDbType.NVarChar), _
                                                                                                    New SqlParameter("@Type", SqlDbType.NVarChar)}

                                    paramVerwysdeUpdate(0).Value = reader("verwyser")
                                    paramVerwysdeUpdate(1).Value = "Cancelled"
                                    paramVerwysdeUpdate(2).Value = "NotActive"
                                    Dim readerVerwysde As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Poldata5.UpdateVerwysdesVerwysKommissie", paramVerwysdeUpdate)

                                    If connVerwysde.State = ConnectionState.Open Then
                                        connVerwysde.Close()
                                    End If
                                End Using
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Critical)
                            End Try

                            If connPersoonl.State = ConnectionState.Open Then
                                connPersoonl.Close()
                            End If
                        End Using
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                Loop
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        intDekkingJaar = Year(Me.dtpPreviousFinalRun.Value.AddMonths(1))
        intDekkingMaand = Month(Me.dtpPreviousFinalRun.Value.AddMonths(1))

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@status", SqlDbType.NVarChar)
                param.Value = "Active"
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Poldata5.FetchDistinctVerwysdes", param)

                Do While reader.Read
                    sngVerwysKommissieTotaal = 0

                    Try
                        Using connVerwysde As SqlConnection = SqlHelper.GetConnection
                            Dim paramVerwysde() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                                    New SqlParameter("@Status", SqlDbType.NVarChar)}
                            paramVerwysde(0).Value = reader("verwyser")
                            paramVerwysde(1).Value = "Active"

                            Dim readerVerwysde As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Poldata5.FetchVerwysdesStatus", paramVerwysde)

                            If reader("verwyser") = "1183005887" Then
                                strPolisno = strPolisno
                            End If

                            Do While readerVerwysde.Read
                                blnKommissieIsBereken = False

                                'Verwyser is gekanselleer in persoonl.  Opdateer die verwyser se status met gekanselleer en maak die kommissie nul
                                Try
                                    Using connPersoonlAll As SqlConnection = SqlHelper.GetConnection
                                        Dim paramPersoonlAll As New SqlParameter("@Polisno", SqlDbType.NVarChar)
                                        paramPersoonlAll.Value = readerVerwysde("verwyser")

                                        Dim readerPersoonlAll As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Poldata5.FetchPersoonlByPolisno", paramPersoonlAll)

                                        If readerPersoonlAll.Read Then
                                            strTaal = readerPersoonlAll("taal")
                                            dblOuVerwyskommissie = readerPersoonlAll("verwyskommissie")

                                            If readerPersoonlAll("gekans") = True Then
                                                Try
                                                    Using connVerwysdeUpdate As SqlConnection = SqlHelper.GetConnection
                                                        Dim paramVerwysdeUpdate() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                                                                    New SqlParameter("@Status", SqlDbType.NVarChar), _
                                                                                                    New SqlParameter("@Type", SqlDbType.NVarChar)}

                                                        paramVerwysdeUpdate(0).Value = reader("verwyser")
                                                        paramVerwysdeUpdate(1).Value = "Cancelled"
                                                        paramVerwysdeUpdate(2).Value = "Active"

                                                        Dim readerVerwysdeUpdate As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Poldata5.UpdateVerwysdesVerwysKommissie", paramVerwysdeUpdate)

                                                        If connVerwysdeUpdate.State = ConnectionState.Open Then
                                                            connVerwysdeUpdate.Close()
                                                        End If
                                                    End Using
                                                Catch ex As Exception
                                                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                                                End Try

                                                glbPolicyNumber = readerPersoonlAll("polisno")

                                                BaseForm.UpdatePersoonlPerField("verwyskommissie", 0)

                                                If dblOuVerwyskommissie <> 0 Then
                                                    If readerPersoonlAll("taal") = "0" Then
                                                        strBeskrywing = "VerwysingsKommissie verander van (" & String.Format("{0:N2}", dblOuVerwyskommissie) & ") na (0)"
                                                        strGebruiker = "Stelsel"
                                                    Else
                                                        strBeskrywing = "Commission on referred changed from (" & String.Format("{0:N2}", dblOuVerwyskommissie) & ") to (0)"
                                                        strGebruiker = "System"
                                                    End If

                                                    UpdateWysigGebruiker("142", strBeskrywing, strGebruiker)
                                                End If
                                            Else
                                                Try
                                                    Using connPersoonlVerwysde As SqlConnection = SqlHelper.GetConnection
                                                        Dim paramPersoonlVerwysde As New SqlParameter("@Polisno", SqlDbType.NVarChar)
                                                        paramPersoonlVerwysde.Value = readerVerwysde("verwysde")

                                                        Dim readerPersoonlVerwysde As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Poldata5.FetchPersoonlByPolisno", paramPersoonlVerwysde)

                                                        If readerPersoonlVerwysde.Read Then
                                                            'stel alle verwyspremies op persoonl na nul
                                                            If readerPersoonlVerwysde("gekans") = True Then
                                                                'verwysde is gekanselleer in persoonl.  Opdateer die verwysde se status met gekanselleer en maak die kommissie nul
                                                                Try
                                                                    Using connVerwysdeUpdate As SqlConnection = SqlHelper.GetConnection
                                                                        Dim paramVerwysdeUpdate() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                                                                                    New SqlParameter("@Status", SqlDbType.NVarChar), _
                                                                                                                    New SqlParameter("@Type", SqlDbType.NVarChar)}

                                                                        paramVerwysdeUpdate(0).Value = readerVerwysde("verwyser")
                                                                        paramVerwysdeUpdate(1).Value = "Cancelled"
                                                                        paramVerwysdeUpdate(2).Value = "Active"

                                                                        Dim readerVerwysdeUpdate As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Poldata5.UpdateVerwysdesVerwysKommissie", paramVerwysdeUpdate)

                                                                        If connVerwysdeUpdate.State = ConnectionState.Open Then
                                                                            connVerwysdeUpdate.Close()
                                                                        End If
                                                                    End Using
                                                                Catch ex As Exception
                                                                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                                                                End Try

                                                                glbPolicyNumber = readerVerwysde("verwyser")

                                                                BaseForm.UpdatePersoonlPerField("verwyskommissie", 0)

                                                                If dblOuVerwyskommissie <> 0 Then
                                                                    If readerPersoonlVerwysde("taal") = "0" Then
                                                                        strBeskrywing = "VerwysingsKommissie verander van (" & String.Format("{0:N2}", dblOuVerwyskommissie) & ") na (0)"
                                                                        strGebruiker = "Stelsel"
                                                                    Else
                                                                        strBeskrywing = "Commission on referred changed from (" & String.Format("{0:N2}", dblOuVerwyskommissie) & ") to (0)"
                                                                        strGebruiker = "System"
                                                                    End If

                                                                    UpdateWysigGebruiker("142", strBeskrywing, strGebruiker)
                                                                End If

                                                            Else
                                                                'Prosesseer nie_ms vir nie_salaris lopie en MS vir salarislopie
                                                                'kry die subtotaal en alles onder die lyn van die vorige afsluiting
                                                                'as dit nie in stats5d gevind kan word nie, gebruik poldata5.mdb
                                                                GetVorigeAfsluitingTotal(readerVerwysde("verwysde"))

                                                                strBetwyse = readerPersoonlAll("bet_wyse")
                                                                strArea = readerPersoonlAll("area")

                                                                If dblSubtotaal <> 0 Then
                                                                    'kry die vorder premie
                                                                    'bereken versekerde vorder premie (net vir MD en MS)                                                            
                                                                    If strBetwyse = "3" Or strBetwyse = "4" Then
                                                                        KryVersekerdeVorderPremie(readerVerwysde("verwysde"), strBetwyse, strArea)
                                                                    End If

                                                                    'kry al die vt's vir MD
                                                                    'If strBetwyse = "4" Then
                                                                    GetVts(readerVerwysde("verwysde"), intDekkingJaar, intDekkingMaand)
                                                                    'End If

                                                                    'kry al die kontant ontvangstes
                                                                    GetKontantOntvangstes(readerVerwysde("verwysde"))

                                                                    'bereken verwysingskommissie
                                                                    BerekenVerwysingsKommissie(readerVerwysde("verwysde"))
                                                                    dblVerwysKommissieTotaal = dblVerwysKommissieTotaal + dblVerwysKommissie

                                                                    'update verwyskommissie in table verwysdes with verwysde commission
                                                                    OpdateerVerwysdes(readerVerwysde("verwysde"))

                                                                    'opdateer verwysdesafsluitings
                                                                    OpdateerVerwysdesAfsluitings(readerVerwysde("pkverwysdes"), readerPersoonlAll("area"), readerPersoonlAll("bet_wyse"))

                                                                End If

                                                                'herbereken premie?

                                                            End If
                                                        End If

                                                        If connPersoonlVerwysde.State = ConnectionState.Open Then
                                                            connPersoonlVerwysde.Close()
                                                        End If
                                                    End Using
                                                Catch ex As Exception
                                                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                                                End Try
                                            End If
                                        End If

                                        If connPersoonlAll.State = ConnectionState.Open Then
                                            connPersoonlAll.Close()
                                        End If
                                    End Using
                                Catch ex As Exception
                                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                                End Try
                            Loop

                            If connVerwysde.State = ConnectionState.Open Then
                                connVerwysde.Close()
                            End If
                        End Using
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                Loop

                'Opdateer rekordset persoonl met verwysingskommissie
                OpdateerPersoonlVerwysKommissie()

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Function UpdateWysigGebruiker(ByVal strKode As String, ByVal strBeskrywing As String, ByVal strGebruiker As String)
        Diagnostics.Debug.WriteLine("updatewysiggebruiker")
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@kode", SqlDbType.NVarChar), _
                                                New SqlParameter("@datum", SqlDbType.DateTime), _
                                                New SqlParameter("@versekerde", SqlDbType.NVarChar), _
                                                New SqlParameter("@voorl", SqlDbType.NVarChar), _
                                                New SqlParameter("@gebruiker", SqlDbType.NVarChar), _
                                                New SqlParameter("@beskrywing", SqlDbType.NVarChar)}

                param(0).Value = glbPolicyNumber
                param(1).Value = strKode
                param(2).Value = Now()
                param(3).Value = ""
                param(4).Value = ""
                param(5).Value = strGebruiker
                param(6).Value = strBeskrywing

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateWysig", param)

                Return True
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function
    'Inputs:  StrVerwysde
    'Outputs: dblSubtotaal, dblEispers, dblOnderlyn, dblPremie2, dteVorigeAfsluiting, dblVerwyskommissieVorigeAfsluiting
    Private Sub GetVorigeAfsluitingTotal(ByVal strVerwysde As String)
        Diagnostics.Debug.WriteLine("getvorigeafsluitingtotal")
        'kry onder die lyn totale van stats5d
        Try
            Using connVorigeAfsluitdat As SqlConnection = SqlHelper.GetConnection
                Dim paramVorigeAfsluitdat() As SqlParameter = {New SqlParameter("@Afsluitdatum", SqlDbType.Date), _
                                                            New SqlParameter("@Polisno", SqlDbType.NVarChar)}

                paramVorigeAfsluitdat(0).Value = Me.dtpFrom.Value
                paramVorigeAfsluitdat(1).Value = strVerwysde

                Dim readerVerwysdeUpdate As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5d.FetchMDPrintDatAfsluitdatPolisno", paramVorigeAfsluitdat)

                Try
                    Using connVorigeAfsluitdat2 As SqlConnection = SqlHelper.GetConnection
                        Dim paramVorigeAfsluitdat2() As SqlParameter = {New SqlParameter("@Afsluitdatum", SqlDbType.Date), _
                                                                    New SqlParameter("@Polisno", SqlDbType.NVarChar)}

                        paramVorigeAfsluitdat2(0).Value = Me.dtpFrom.Value
                        paramVorigeAfsluitdat2(1).Value = strVerwysde

                        Dim readerVerwysdeUpdate2 As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5d.FetchMDPrint2DatAfsluitdatPolisno", paramVorigeAfsluitdat2)

                        If readerVerwysdeUpdate.Read And readerVerwysdeUpdate2.Read Then
                            dblSubtotaal = readerVerwysdeUpdate("subtotaal")
                            dblEispers = readerVerwysdeUpdate2("eispers")
                            dblOnderlyn = IIf(readerVerwysdeUpdate("Beskerm") Is DBNull.Value, 0, readerVerwysdeUpdate("Beskerm")) + IIf(readerVerwysdeUpdate("sasprem") Is DBNull.Value, 0, readerVerwysdeUpdate("sasprem")) + IIf(readerVerwysdeUpdate("tv_diens") Is DBNull.Value, 0, readerVerwysdeUpdate("tv_diens")) + IIf(readerVerwysdeUpdate("polfooi") Is DBNull.Value, 0, readerVerwysdeUpdate("polfooi")) + IIf(readerVerwysdeUpdate("begrafnis") Is DBNull.Value, 0, readerVerwysdeUpdate("begrafnis")) + IIf(readerVerwysdeUpdate("plip") Is DBNull.Value, 0, readerVerwysdeUpdate("plip")) + IIf(readerVerwysdeUpdate2("courtesyv") Is DBNull.Value, 0, readerVerwysdeUpdate2("courtesyv")) + IIf(readerVerwysdeUpdate2("epc") Is DBNull.Value, 0, readerVerwysdeUpdate2("epc")) + IIf(readerVerwysdeUpdate("careassist") Is DBNull.Value, 0, readerVerwysdeUpdate("careassist")) + IIf(readerVerwysdeUpdate2("inscell") Is DBNull.Value, 0, readerVerwysdeUpdate2("inscell")) + IIf(readerVerwysdeUpdate("pakketitem1") Is DBNull.Value, 0, readerVerwysdeUpdate("pakketitem1")) + IIf(readerVerwysdeUpdate("pakketitem2") Is DBNull.Value, 0, readerVerwysdeUpdate("pakketitem2")) + IIf(readerVerwysdeUpdate("pakketitem3") Is DBNull.Value, 0, readerVerwysdeUpdate("pakketitem3")) + IIf(readerVerwysdeUpdate("pakketitem4") Is DBNull.Value, 0, readerVerwysdeUpdate("pakketitem4"))
                            dblPremie2 = readerVerwysdeUpdate2("premie2")
                            dblVerwyskommissieVorigeAfsluiting = readerVerwysdeUpdate2("verwyskommissie")
                        Else
                            Try
                                Using connPersoonlVerwysde As SqlConnection = SqlHelper.GetConnection
                                    Dim paramPersoonlVerwysde As New SqlParameter("@Polisno", SqlDbType.NVarChar)
                                    paramPersoonlVerwysde.Value = strVerwysde

                                    Dim readerPersoonlVerwysde As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Poldata5.FetchPersoonlByPolisno", paramPersoonlVerwysde)

                                    If readerPersoonlVerwysde.Read Then
                                        dblSubtotaal = readerPersoonlVerwysde("subtotaal")
                                        dblEispers = readerPersoonlVerwysde("eispers")
                                        dblOnderlyn = IIf(readerPersoonlVerwysde("Beskerm") Is DBNull.Value, 0, readerPersoonlVerwysde("Beskerm")) + IIf(readerPersoonlVerwysde("sasprem") Is DBNull.Value, 0, readerPersoonlVerwysde("sasprem")) + IIf(readerPersoonlVerwysde("tv_diens") Is DBNull.Value, 0, readerPersoonlVerwysde("tv_diens")) + IIf(readerPersoonlVerwysde("polfooi") Is DBNull.Value, 0, readerPersoonlVerwysde("polfooi")) + IIf(readerPersoonlVerwysde("begrafnis") Is DBNull.Value, 0, readerPersoonlVerwysde("begrafnis")) + IIf(readerPersoonlVerwysde("plip1") Is DBNull.Value, 0, readerPersoonlVerwysde("plip1")) + IIf(readerPersoonlVerwysde("courtesyv") Is DBNull.Value, 0, readerPersoonlVerwysde("courtesyv")) + IIf(readerPersoonlVerwysde("epc") Is DBNull.Value, 0, readerPersoonlVerwysde("epc")) + IIf(readerPersoonlVerwysde("careassist") Is DBNull.Value, 0, readerPersoonlVerwysde("careassist")) + IIf(readerPersoonlVerwysde("selfoon") Is DBNull.Value, 0, readerPersoonlVerwysde("selfoon")) + IIf(readerPersoonlVerwysde("pakketitem1") Is DBNull.Value, 0, readerPersoonlVerwysde("pakketitem1")) + IIf(readerPersoonlVerwysde("pakketitem2") Is DBNull.Value, 0, readerPersoonlVerwysde("pakketitem2")) + IIf(readerPersoonlVerwysde("pakketitem3") Is DBNull.Value, 0, readerPersoonlVerwysde("pakketitem3")) + IIf(readerPersoonlVerwysde("pakketitem4") Is DBNull.Value, 0, readerPersoonlVerwysde("pakketitem4"))
                                        dblPremie2 = readerPersoonlVerwysde("premie2")
                                        dblVerwyskommissieVorigeAfsluiting = readerPersoonlVerwysde("verwyskommissie")
                                    Else
                                        dblSubtotaal = 0
                                        dblEispers = 0
                                        dblOnderlyn = 0
                                        dblPremie2 = 0
                                        dteVorigeAfsluiting = ""
                                        dblVerwyskommissieVorigeAfsluiting = 0
                                    End If
                                    If connPersoonlVerwysde.State = ConnectionState.Open Then
                                        connPersoonlVerwysde.Close()
                                    End If
                                End Using
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Critical)
                            End Try
                        End If

                        If connVorigeAfsluitdat2.State = ConnectionState.Open Then
                            connVorigeAfsluitdat2.Close()
                        End If
                    End Using
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try

                If connVorigeAfsluitdat.State = ConnectionState.Open Then
                    connVorigeAfsluitdat.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    '*Purpose:  Get the versekerde vorder premium for a specific closing date
    '*Inputs:   strVerwysde, strBetaalwyse, strArea
    '*Outputs:  dblVorderpremie
    Private Sub KryVersekerdeVorderPremie(ByVal strVerwysde As String, ByVal strBetwyse As String, ByVal strArea As String)
        Diagnostics.Debug.WriteLine("kryversekerdevorderpremie")
        dblVorderPremie = 0

        clsRun.MaxAfsluitDatMaand(strBetwyse)

        Try
            Using connMaand As SqlConnection = SqlHelper.GetConnection
                Dim paramMaand() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Afsluitdat", SqlDbType.DateTime)}

                paramMaand(0).Value = strVerwysde
                Select Case strBetwyse
                    Case "3"
                        Select Case strArea
                            Case "2"
                                paramMaand(1).Value = IIf((Me.dtpSalary1.Enabled = False), Me.dtpPreviousFinalRun.Value, Me.dtpSalary1.Value)
                            Case "3"
                                paramMaand(1).Value = IIf((Me.dtpSalary2.Enabled = False), Me.dtpPreviousFinalRun.Value, Me.dtpSalary2.Value)
                            Case Else
                                paramMaand(1).Value = Me.dtpPreviousFinalRun.Value
                        End Select
                    Case "4"
                        If IsDBNull(glbMaxAfsluitDatMaand) = False Then
                            paramMaand(1).Value = glbMaxAfsluitDatMaand
                        Else
                            paramMaand(1).Value = Me.dtpPreviousFinalRun.Value
                        End If
                End Select

                Dim readerMaand As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchMaandPolisnoAfsluitdat", paramMaand)

                If readerMaand.Read Then
                    dblVorderPremie = readerMaand("vord_premie")
                End If

                If connMaand.State = ConnectionState.Open Then
                    connMaand.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    '*Purpose:  To calculate the VTs for this policy holder
    '*Inputs:   strVerwysde, intDekkingJaar, intDekkingMaand
    '*Outputs:  dblVTTotaal
    Private Sub GetVts(ByVal strVerwysde As String, ByVal intDekkingJaar As Integer, ByVal intDekkingMaand As Integer)
        Diagnostics.Debug.WriteLine("getvts")
        dblVTTotaal = 0

        Try
            Using connVTDet As SqlConnection = SqlHelper.GetConnection
                Dim paramVTDet() As SqlParameter = {New SqlParameter("@strVerwysde", SqlDbType.NVarChar), _
                                                    New SqlParameter("@dtVanaf", SqlDbType.DateTime), _
                                                    New SqlParameter("@dtTot", SqlDbType.DateTime)}

                paramVTDet(0).Value = strVerwysde
                paramVTDet(1).Value = Me.dtpFrom.Value
                paramVTDet(2).Value = Me.dtpTo.Value

                Dim readerVTDet As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchMaand_VT_detailsForVerwysdes", paramVTDet)

                Do While readerVTDet.Read
                    dblVTTotaal = dblVTTotaal + readerVTDet("vt_bedrag")
                Loop

                If connVTDet.State = ConnectionState.Open Then
                    connVTDet.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    '*Purpose:  to calculate the kontant ontvangstes for this policy holder
    '*Inputs:   strVerwysde
    '*Outputs:  dblKOTotaal
    Private Sub GetKontantOntvangstes(ByVal strVerwysde As String)

        Diagnostics.Debug.WriteLine("getkontantontvangstes")
        dblKOTotaal = 0

        Try
            Using connKontantDet As SqlConnection = SqlHelper.GetConnection
                Dim paramKontantDet() As SqlParameter = {New SqlParameter("@strVerwysde", SqlDbType.NVarChar), _
                                                    New SqlParameter("@dtVanaf", SqlDbType.DateTime), _
                                                    New SqlParameter("@dtTot", SqlDbType.DateTime)}

                paramKontantDet(0).Value = strVerwysde
                paramKontantDet(1).Value = Me.dtpFrom.Value
                paramKontantDet(2).Value = Me.dtpTo.Value

                Dim readerKontantDet As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchKontantForVerwysdes", paramKontantDet)

                Do While readerKontantDet.Read
                    If readerKontantDet("tipe") = "TB" Then
                        dblKOTotaal = dblKOTotaal - readerKontantDet("vord_premie")
                    Else
                        dblKOTotaal = dblKOTotaal + readerKontantDet("vord_premie")
                    End If
                Loop

                If connKontantDet.State = ConnectionState.Open Then
                    connKontantDet.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    '*Purpose:  Calculate the verwysingskommissie for this policy and update the verwysdes commission on table verwysdes
    '*Inputs:   strVerwysde
    '*Outputs:  dblVerwyskommissie
    Private Sub BerekenVerwysingsKommissie(ByVal strVerwysde As String)

        'Get the additional premium for the closed period and under the line figure
        getAdditionalPremiumForClosedPeriod(strVerwysde)

        dblVerwysdeKorting = Constants.Korting
        dblVerwysdepremie = dblSubtotaal * dblEispers

        'kry betaalwyse
        Try
            Using connPersoonlVerwysde As SqlConnection = SqlHelper.GetConnection
                Dim paramPersoonlVerwysde As New SqlParameter("@Polisno", SqlDbType.NVarChar)
                paramPersoonlVerwysde.Value = strVerwysde

                Dim readerPersoonlVerwysde As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Poldata5.FetchAreaByPersoonl", paramPersoonlVerwysde)

                If readerPersoonlVerwysde.Read Then
                    If readerPersoonlVerwysde("bet_wyse") = "4" Then
                        'kry vorder premie
                        strArea = readerPersoonlVerwysde("area_kode")
                        KryVersekerdeVorderPremie(strVerwysde, "4", strArea)

                        dblVerwysdepremie = dblVerwyskommissieVorigeAfsluiting + dblVorderPremie - dblVTTotaal + dblKOTotaal - dblOnderlyn - dblAPOnderlyn
                    ElseIf readerPersoonlVerwysde("bet_wyse") = "3" Then
                        dblVerwysdepremie = dblVerwyskommissieVorigeAfsluiting + dblVorderPremie + dblKOTotaal - dblOnderlyn - dblAPOnderlyn
                    Else
                        dblVerwysdepremie = dblVerwyskommissieVorigeAfsluiting + dblKOTotaal - dblOnderlyn - dblAPOnderlyn
                    End If
                End If

                If dblVerwysdepremie > 0 Then
                    dblVerwysKommissie = dblVerwysdepremie * 0.975
                    dblVerwysKommissie = dblVerwysKommissie * dblVerwysdeKorting
                Else
                    dblVerwysdepremie = 0
                    dblVerwysKommissie = 0
                End If

                If connPersoonlVerwysde.State = ConnectionState.Open Then
                    connPersoonlVerwysde.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    '*Purpose:  Get the additional premium for a specific closing date
    '*Inputs:   strVerwysde
    '*Outputs:  dblAdditionalPremiumforClosedPeriod, dblAPOnderlyn
    Private Sub getAdditionalPremiumForClosedPeriod(ByVal strVerwysde As String)

        Diagnostics.Debug.WriteLine("getadditionalpremiumforclosedperiod")
        dblAdditionalPremiumforClosedPeriod = 0

        Try
            Using connAP As SqlConnection = SqlHelper.GetConnection
                Dim paramAP() As SqlParameter = {New SqlParameter("@strVerwysde", SqlDbType.NVarChar), _
                                                    New SqlParameter("@dteAfsluit", SqlDbType.NVarChar)}

                paramAP(0).Value = strVerwysde
                paramAP(1).Value = CStr(Me.dtpPreviousFinalRun.Value)

                Dim readerAP As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAddisionelePremieForVerwysdes", paramAP)

                If readerAP.Read Then
                    dblAdditionalPremiumforClosedPeriod = readerAP("Totaal")

                    dblAPOnderlyn = IIf(readerAP("Beskerm") Is DBNull.Value, 0, readerAP("Beskerm")) + IIf(readerAP("sasria") Is DBNull.Value, 0, readerAP("sasria")) + IIf(readerAP("tvdiens") Is DBNull.Value, 0, readerAP("tvdiens")) + IIf(readerAP("polisfooi") Is DBNull.Value, 0, readerAP("polisfooi")) + IIf(readerAP("begrafnis") Is DBNull.Value, 0, readerAP("begrafnis")) + IIf(readerAP("plip") Is DBNull.Value, 0, readerAP("plip")) + IIf(readerAP("courtesyv") Is DBNull.Value, 0, readerAP("courtesyv")) + IIf(readerAP("epc") Is DBNull.Value, 0, readerAP("epc")) + IIf(readerAP("careassist") Is DBNull.Value, 0, readerAP("careassist")) + IIf(readerAP("selfoon") Is DBNull.Value, 0, readerAP("selfoon")) + IIf(readerAP("pakketitem1") Is DBNull.Value, 0, readerAP("pakketitem1")) + IIf(readerAP("pakketitem2") Is DBNull.Value, 0, readerAP("pakketitem2")) + IIf(readerAP("pakketitem3") Is DBNull.Value, 0, readerAP("pakketitem3")) + IIf(readerAP("pakketitem4") Is DBNull.Value, 0, readerAP("pakketitem4"))
                End If

                If connAP.State = ConnectionState.Open Then
                    connAP.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    '*Purpose:  Update the table verwysdes with verwysde commission
    '*Inputs:   strverwysde
    Private Sub OpdateerVerwysdes(ByVal strVerwysde As String)
        Diagnostics.Debug.WriteLine("opdateerverwysdes")
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@Verwyskommissie", SqlDbType.Money), _
                                                New SqlParameter("@verwysde", SqlDbType.NVarChar)}

                param(0).Value = dblVerwysKommissie
                param(1).Value = strVerwysde

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateVerwysdeKommissie", param)

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    '*Purpose:  Update the table verwysdesAfsluitings with verwysde commission
    '*Inputs:   lngPkverwysde
    Private Sub OpdateerVerwysdesAfsluitings(ByVal lngPkVerwysde As Long, ByVal strVAArea As String, ByVal strVABetWyse As String)

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@Verwyskommissie", SqlDbType.Money), _
                                                New SqlParameter("@pkverwysde", SqlDbType.Int), _
                                                New SqlParameter("@DatumAfgesluit", SqlDbType.Date)}
                If lngPkVerwysde = 909 Or lngPkVerwysde = 907 Or lngPkVerwysde = 904 Then
                    lngPkVerwysde = lngPkVerwysde
                End If
                param(0).Value = String.Format("{0:N2}", dblVerwysKommissie)
                param(1).Value = lngPkVerwysde
                If strVABetWyse = "3" Then
                    If strTak = "Flagship" And strVAArea = "2" Then
                        param(2).Value = Me.dtpSalary1.Value
                    ElseIf strTak = "Bloemfontein" And strVAArea = "2" Then
                        param(2).Value = Me.dtpSalary1.Value
                    ElseIf strTak = "Bloemfontein" And strVAArea = "3" Then
                        param(2).Value = Me.dtpSalary2.Value
                    Else
                        param(2).Value = Me.dtpPreviousFinalRun.Value
                    End If
                Else
                    param(2).Value = Me.dtpPreviousFinalRun.Value
                End If

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateVerwysdesAfsluitings", param)

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    '*Purpose:  Update the table persoonl with verwysde commission
    Private Sub OpdateerPersoonlVerwysKommissie()
        Diagnostics.Debug.WriteLine("opdateerpersoonlverwyskommissie")
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@Status", SqlDbType.NVarChar)
                param.Value = "Active"
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Poldata5.FetchDistinctVerwysdes", param)

                Do While reader.Read
                    Try
                        Using connSum As SqlConnection = SqlHelper.GetConnection
                            Dim paramSum As New SqlParameter("@verwyser", SqlDbType.NVarChar)
                            paramSum.Value = reader("verwyser")
                            Dim readerSum As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Poldata5.FetchVerwysdesSumKommissie", paramSum)

                            If reader("verwyser") = "1183049649" Or reader("verwyser") = "1183052461" Then
                                strPolisno = strPolisno
                            End If
                            If readerSum.Read Then
                                glbPolicyNumber = reader("verwyser")

                                'skryf wysiging
                                Try
                                    Using connPersoonl As SqlConnection = SqlHelper.GetConnection
                                        Dim paramPersoonl() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                                        New SqlParameter("@Gekans", SqlDbType.NVarChar)}
                                        paramPersoonl(0).Value = reader("verwyser")
                                        paramPersoonl(1).Value = "False"

                                        Dim readerPersoonl As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Poldata5.FetchPersoonlByAreaVerwysdes", paramPersoonl)

                                        If readerPersoonl.Read Then
                                            If String.Format("{0:N2}", readerPersoonl("verwyskommissie")) <> String.Format("{0:N2}", readerSum("totaalverwyskommissie")) Then
                                                If readerPersoonl("verwyskommissie") = 0 And readerSum("totaalverwyskommissie") = 0 Then
                                                    'do not write out an alteration record
                                                Else
                                                    If readerPersoonl("taal") = "0" Then
                                                        strBeskrywing = "VerwysingsKommissie verander van (" & String.Format("{0:N2}", readerPersoonl("verwyskommissie")) & ") na (" & String.Format("{0:N2}", readerSum("totaalverwyskommissie")) & ")"
                                                        strGebruiker = "Stelsel"
                                                    Else
                                                        strBeskrywing = "Commission on referred changed from (" & String.Format("{0:N2}", readerPersoonl("verwyskommissie")) & ") to (" & String.Format("{0:N2}", readerSum("totaalverwyskommissie")) & ")"
                                                        strGebruiker = "System"
                                                    End If

                                                    UpdateWysigGebruiker("142", strBeskrywing, strGebruiker)
                                                End If
                                            End If
                                        End If

                                        If connPersoonl.State = ConnectionState.Open Then
                                            connPersoonl.Close()
                                        End If
                                    End Using
                                Catch ex As Exception
                                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                                End Try

                                BaseForm.UpdatePersoonlPerField("verwyskommissie", String.Format("{0:N2}", readerSum("totaalverwyskommissie")))
                            End If

                            If connSum.State = ConnectionState.Open Then
                                connSum.Close()
                            End If
                        End Using
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                Loop
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Kontant_rekon()

        Dim strBetaalwyseTemp As String = ""
        Dim intcount As Integer = 0
        'Delete existing rekords - om te kyk in die sp vat te lank, so delete eerder en skep dit weer deur die program
        Diagnostics.Debug.WriteLine("kontantrekon")
        Try
            Using connDelete As SqlConnection = SqlHelper.GetConnection
                Dim paramDelete() As SqlParameter = {New SqlParameter("@afsluitdatum", SqlDbType.Date), _
                                                     New SqlParameter("@SalarisAfsluitdatum", SqlDbType.Date), _
                                                New SqlParameter("@fkversekeraar", SqlDbType.Int)}

                paramDelete(0).Value = Me.dtpPreviousFinalRun.Value
                paramDelete(1).Value = Me.dtpSalary1.Value
                paramDelete(2).Value = Me.cmbInsurer.SelectedValue

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.DeleteKontantRekonAfsluitdat", paramDelete)

                If connDelete.State = ConnectionState.Open Then
                    connDelete.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        intJaar = Year(Me.dtpTo.Value)
        intMnd = Month(Me.dtpTo.Value)

        'Delete existing rekords uit hollardoorbetalings - om te kyk in die sp vat te lank, so delete eerder en skep dit weer deur die program
        Try
            Using connDelete As SqlConnection = SqlHelper.GetConnection
                Dim paramDelete() As SqlParameter = {New SqlParameter("@jaar", SqlDbType.Int), _
                                                New SqlParameter("@maand", SqlDbType.Int)}

                paramDelete(0).Value = intJaar
                paramDelete(1).Value = intMnd

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.DeleteHollardOorbetalingsJaarMaand", paramDelete)

                If connDelete.State = ConnectionState.Open Then
                    connDelete.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        'kry rekon syfers
        ''n polis kon van area verander het na die verwagte lopie geloop is.  Dan kon daar 'n betaling gemaak wees teen hierdie nuwe area wat dan uitgewys moet word
        dblBeskermingTot = 0
        dblSaspremTot = 0
        dblTV_diensTot = 0
        dblPolfooiTot = 0
        dblBegrafnisTot = 0
        dblPlipTot = 0
        dblCourtesyvTot = 0
        dblEpcTot = 0
        dblCareAssistTot = 0
        dblInscellTot = 0
        dblSubMinKortingTot = 0
        dblBedragFinTotaal = 0
        dblKontroleFinTotaal = 0

        For i = 1 To 25
            dblFintot(i) = 0
        Next

        Dim item As KontantRekonEntity = New KontantRekonEntity()

        'lopie details
        Try
            Using connLopie As SqlConnection = SqlHelper.GetConnection
                Dim paramLopie() As SqlParameter = {New SqlParameter("@jaar", SqlDbType.Int), _
                                                New SqlParameter("@maand", SqlDbType.Int), _
                                                New SqlParameter("@fkversekeraar", SqlDbType.Int), _
                                                 New SqlParameter("@type", SqlDbType.NVarChar)}

                paramLopie(0).Value = intJaar
                paramLopie(1).Value = intMnd
                paramLopie(2).Value = Me.cmbInsurer.SelectedValue
                paramLopie(3).Value = strLopieTipe

                Dim readerLopie As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchKommissieDetail", paramLopie)

                Do While readerLopie.Read
                    strArea = readerLopie("area")
                    intfkVersekeraar = readerLopie("fkversekeraar")
                    intMakelaarfk = readerLopie("fkmakelaar")

                    'Entity                    
                    If readerLopie("PolisfooiAP") IsNot DBNull.Value Then
                        item.Polisfooiap = readerLopie("PolisfooiAP")
                    Else
                        item.Polisfooiap = 0
                    End If
                    If readerLopie("MotorsAP") IsNot DBNull.Value Then
                        item.Motorsap = readerLopie("MotorsAP")
                    Else
                        item.Motorsap = 0
                    End If
                    If readerLopie("AlleRisikoAP") IsNot DBNull.Value Then
                        item.Allerisikoap = readerLopie("AlleRisikoAP")
                    Else
                        item.Allerisikoap = 0
                    End If
                    If readerLopie("HBAP") IsNot DBNull.Value Then
                        item.Hbap = readerLopie("HBAP")
                    Else
                        item.Hbap = 0
                    End If
                    If readerLopie("HEAP") IsNot DBNull.Value Then
                        item.HeAp = readerLopie("HEAP")
                    Else
                        item.HeAp = 0
                    End If
                    If readerLopie("HBGrasAP") IsNot DBNull.Value Then
                        item.Hbgrasap = readerLopie("HBGrasAP")
                    Else
                        item.Hbgrasap = 0
                    End If
                    If readerLopie("HEGrasAP") IsNot DBNull.Value Then
                        item.Hegrasap = readerLopie("HEGrasAP")
                    Else
                        item.Hegrasap = 0
                    End If
                    If readerLopie("ToevalEEMAP") IsNot DBNull.Value Then
                        item.Toevaleemap = readerLopie("ToevalEEMAP")
                    Else
                        item.Toevaleemap = 0
                    End If
                    If readerLopie("ToevalBreekAP") IsNot DBNull.Value Then
                        item.Toevalbreekap = readerLopie("ToevalBreekAP")
                    Else
                        item.Toevalbreekap = 0
                    End If
                    If readerLopie("WaterleweAP") IsNot DBNull.Value Then
                        item.Waterleweap = readerLopie("WaterleweAP")
                    Else
                        item.Waterleweap = 0
                    End If
                    If readerLopie("SasriaAP") IsNot DBNull.Value Then
                        item.Sasriaap = readerLopie("SasriaAP")
                    Else
                        item.Sasriaap = 0
                    End If
                    If readerLopie("PlipAP") IsNot DBNull.Value Then
                        item.Plipap = readerLopie("PlipAP")
                    Else
                        item.Plipap = 0
                    End If
                    If readerLopie("CareAssistAP") IsNot DBNull.Value Then
                        item.Careassistap = readerLopie("CareAssistAP")
                    Else
                        item.Careassistap = 0
                    End If
                    If readerLopie("EPCAP") IsNot DBNull.Value Then
                        item.Epcap = readerLopie("EPCAP")
                    Else
                        item.Epcap = 0
                    End If
                    If readerLopie("SelfoonAP") IsNot DBNull.Value Then
                        item.Selfoonap = readerLopie("SelfoonAP")
                    Else
                        item.Selfoonap = 0
                    End If
                    If readerLopie("BegrafnisAP") IsNot DBNull.Value Then
                        item.Begrafnisap = readerLopie("BegrafnisAP")
                    Else
                        item.Begrafnisap = 0
                    End If
                    If readerLopie("TVDiensAP") IsNot DBNull.Value Then
                        item.Tvdiensap = readerLopie("TVDiensAP")
                    Else
                        item.Tvdiensap = 0
                    End If
                    If readerLopie("BeskermAP") IsNot DBNull.Value Then
                        item.Beskermap = readerLopie("BeskermAP")
                    Else
                        item.Beskermap = 0
                    End If
                    If readerLopie("CourtesyvAP") IsNot DBNull.Value Then
                        item.Courtesyvap = readerLopie("CourtesyvAP")
                    Else
                        item.Courtesyvap = 0
                    End If
                    If readerLopie("Pakketitem1AP") IsNot DBNull.Value Then
                        item.Pakketitem1ap = readerLopie("Pakketitem1AP")
                    Else
                        item.Pakketitem1ap = 0
                    End If
                    If readerLopie("Pakketitem2AP") IsNot DBNull.Value Then
                        item.Pakketitem2ap = readerLopie("Pakketitem2AP")
                    Else
                        item.Pakketitem2ap = 0
                    End If
                    If readerLopie("Pakketitem3AP") IsNot DBNull.Value Then
                        item.Pakketitem3ap = readerLopie("Pakketitem3AP")
                    Else
                        item.Pakketitem3ap = 0
                    End If
                    If readerLopie("Pakketitem4AP") IsNot DBNull.Value Then
                        item.Pakketitem4ap = readerLopie("Pakketitem4AP")
                    Else
                        item.Pakketitem4ap = 0
                    End If
                    If readerLopie("pfprem") IsNot DBNull.Value Then
                        item.Pfprem = readerLopie("pfprem")
                    Else
                        item.Pfprem = 0
                    End If
                    If readerLopie("SpesialeKortingAP") IsNot DBNull.Value Then
                        item.Spesialekortingap = readerLopie("SpesialeKortingAP")
                    Else
                        item.Spesialekortingap = 0
                    End If
                    If readerLopie("selfoonprem") IsNot DBNull.Value Then
                        item.Selfoonprem = readerLopie("selfoonprem")
                    Else
                        item.Selfoonprem = 0
                    End If
                    If readerLopie("spesialekorting") IsNot DBNull.Value Then
                        item.Spesialekorting = readerLopie("spesialekorting")
                    Else
                        item.Spesialekorting = 0
                    End If
                    If readerLopie("premievoorkorting") IsNot DBNull.Value Then
                        item.Premievoorkorting = readerLopie("premievoorkorting")
                    Else
                        item.Premievoorkorting = 0
                    End If
                    If readerLopie("mtprem") IsNot DBNull.Value Then
                        item.Mtprem = readerLopie("mtprem")
                    Else
                        item.Mtprem = 0
                    End If
                    If readerLopie("arprem") IsNot DBNull.Value Then
                        item.Arprem = readerLopie("arprem")
                    Else
                        item.Arprem = 0
                    End If
                    If readerLopie("hbgewprem") IsNot DBNull.Value Then
                        item.Hbgewprem = readerLopie("hbgewprem")
                    Else
                        item.Hbgewprem = 0
                    End If
                    If readerLopie("hegewprem") IsNot DBNull.Value Then
                        item.Hegewprem = readerLopie("hegewprem")
                    Else
                        item.Hegewprem = 0
                    End If
                    If readerLopie("hbgrasprem") IsNot DBNull.Value Then
                        item.Hbgrasprem = readerLopie("hbgrasprem")
                    Else
                        item.Hbgrasprem = 0
                    End If
                    If readerLopie("hegrasprem") IsNot DBNull.Value Then
                        item.Hegrasprem = readerLopie("hegrasprem")
                    Else
                        item.Hegrasprem = 0
                    End If
                    If readerLopie("tselekprem") IsNot DBNull.Value Then
                        item.Tselekprem = readerLopie("tselekprem")
                    Else
                        item.Tselekprem = 0
                    End If
                    If readerLopie("tsgewprem") IsNot DBNull.Value Then
                        item.Tsgewprem = readerLopie("tsgewprem")
                    Else
                        item.Tsgewprem = 0
                    End If
                    If readerLopie("wlprem") IsNot DBNull.Value Then
                        item.Wlprem = readerLopie("wlprem")
                    Else
                        item.Wlprem = 0
                    End If
                    If readerLopie("totprem") IsNot DBNull.Value Then
                        item.Totprem = readerLopie("totprem")
                    Else
                        item.Totprem = 0
                    End If
                    If readerLopie("beskermingprem") IsNot DBNull.Value Then
                        item.Beskermingprem = readerLopie("beskermingprem")
                    Else
                        item.Beskermingprem = 0
                    End If
                    If readerLopie("sasriaprem") IsNot DBNull.Value Then
                        item.Sasriaprem = readerLopie("sasriaprem")
                    Else
                        item.Sasriaprem = 0
                    End If
                    If readerLopie("tvdiensprem") IsNot DBNull.Value Then
                        item.Tvdiensprem = readerLopie("tvdiensprem")
                    Else
                        item.Tvdiensprem = 0
                    End If
                    If readerLopie("pfprem") IsNot DBNull.Value Then
                        item.Pfprem = readerLopie("pfprem")
                    Else
                        item.Pfprem = 0
                    End If
                    If readerLopie("begrafnisprem") IsNot DBNull.Value Then
                        item.Begrafnisprem = readerLopie("begrafnisprem")
                    Else
                        item.Begrafnisprem = 0
                    End If
                    If readerLopie("plipprem") IsNot DBNull.Value Then
                        item.Plipprem = readerLopie("plipprem")
                    Else
                        item.Plipprem = 0
                    End If
                    If readerLopie("geleentheidsmotorprem") IsNot DBNull.Value Then
                        item.Geleentheidsmotorprem = readerLopie("geleentheidsmotorprem")
                    Else
                        item.Geleentheidsmotorprem = 0
                    End If
                    If readerLopie("epcprem") IsNot DBNull.Value Then
                        item.Epcprem = readerLopie("epcprem")
                    Else
                        item.Epcprem = 0
                    End If
                    If readerLopie("caprem") IsNot DBNull.Value Then
                        item.Caprem = readerLopie("caprem")
                    Else
                        item.Caprem = 0
                    End If
                    If readerLopie("selfoonprem") IsNot DBNull.Value Then
                        item.Selfoonprem = readerLopie("selfoonprem")
                    Else
                        item.Selfoonprem = 0
                    End If
                    If readerLopie("mediesprem") IsNot DBNull.Value Then
                        item.Mediesprem = readerLopie("mediesprem")
                    Else
                        item.Mediesprem = 0
                    End If
                    If readerLopie("premienakorting") IsNot DBNull.Value Then
                        item.Premienakorting = readerLopie("premienakorting")
                    Else
                        item.Premienakorting = 0
                    End If
                    If readerLopie("addisionelepremie") IsNot DBNull.Value Then
                        item.Addisionelepremie = readerLopie("addisionelepremie")
                    Else
                        item.Addisionelepremie = 0
                    End If
                    If readerLopie("pakketitem1") IsNot DBNull.Value Then
                        item.Pakketitem1 = readerLopie("pakketitem1")
                    Else
                        item.Pakketitem1 = 0
                    End If
                    If readerLopie("pakketitem2") IsNot DBNull.Value Then
                        item.Pakketitem2 = readerLopie("pakketitem2")
                    Else
                        item.Pakketitem2 = 0
                    End If
                    If readerLopie("pakketitem3") IsNot DBNull.Value Then
                        item.Pakketitem3 = readerLopie("pakketitem3")
                    Else
                        item.Pakketitem3 = 0
                    End If
                    If readerLopie("pakketitem4") IsNot DBNull.Value Then
                        item.Pakketitem4 = readerLopie("pakketitem4")
                    Else
                        item.Pakketitem4 = 0
                    End If

                    WriteValues("", "", "", "Verwagte Premie", readerLopie("fkBetaalwyse"), item.Pfprem, item.Mtprem, item.Arprem, item.Hbgewprem, _
                    item.Hegewprem, item.Hbgrasprem, item.Hegrasprem, item.Tselekprem, item.Tsgewprem, item.Wlprem, item.Sasriaprem, item.Plipprem, _
                    item.Caprem, item.Epcprem, item.Selfoonprem, item.Begrafnisprem, 0, item.Tvdiensprem, item.Beskermingprem, item.Geleentheidsmotorprem, _
                    item.Pakketitem1, item.Pakketitem2, item.Pakketitem3, item.Pakketitem4, item.Pfprem, 0)

                    dblSelfoonVerwagtePremieTotaal = dblSelfoonVerwagtePremieTotaal + item.Selfoonprem
                    dblSpesialeKorting = item.Spesialekorting * -1
                    dblPremievoorKorting2 = item.Premievoorkorting
                    dblPremievoorKorting1 = dblSelfoonVerwagtePremieTotaal + dblSpesialeKorting + dblPremievoorKorting2 + dblMotorsAP + dblAlleRisikoAP + dblHBAP + dblHEAP + dblHBGrasAP + dblHEGrasAP + dblToevalEEMAP + dblToevalBreekAP + dblWaterleweAP + dblBegrafnisAP + dblSasriaAP + dblPolisfooiAP + dblPlipAP + dblTVDiensAP + dblBeskermAP + dblCourtesyvAP + dblEPCAP + dblCareAssistAP + dblSelfoonAP + dblSpesialeKortingAP + dblPakketitem1AP + dblPakketitem2AP + dblPakketitem3AP + dblPakketitem4AP

                    UpdateKontantRekonHollard()

                    Me.lblProcessing.Text = "Processing - 20%"
                    Me.lblProcessing.Refresh()

                    'skryf spesiale korting
                    WriteValues("", "", "", "Verwagte spesiale korting", readerLopie("fkBetaalwyse"), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, dblSpesialeKorting)
                    UpdateKontantRekonHollard()

                    'kry verwagte addisionele premie
                    WriteValues("", "", "", "Verwagte addisionele premie", readerLopie("fkBetaalwyse"), item.Polisfooiap, item.Motorsap, _
                    item.Allerisikoap, item.Hbap, item.HeAp, item.Hbgrasap, item.Hegrasap, item.Toevaleemap, item.Toevalbreekap, item.Waterleweap, item.Sasriaap, _
                    item.Plipap, item.Careassistap, item.Epcap, item.Selfoonap, item.Begrafnisap, 0, item.Tvdiensap, item.Beskermap, item.Courtesyvap, item.Pakketitem1ap, _
                    item.Pakketitem2ap, item.Pakketitem3ap, item.Pakketitem4ap, item.Pfprem, item.Spesialekortingap)

                    UpdateKontantRekonHollard()
                Loop

                If connLopie.State = ConnectionState.Open Then
                    connLopie.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Private Sub UpdateKontantRekonHollard()
        Try
            Using connHollard As SqlConnection = SqlHelper.GetConnection
                Dim paramHollard() As SqlParameter = {New SqlParameter("@fkversekeraar", SqlDbType.Int), _
                                                New SqlParameter("@fkmakelaar", SqlDbType.Int), _
                                                New SqlParameter("@area", SqlDbType.NVarChar), _
                                                New SqlParameter("@Betaalwyse", SqlDbType.NVarChar), _
                                                New SqlParameter("@Versekerde", SqlDbType.NVarChar), _
                                                New SqlParameter("@Voorletter", SqlDbType.NVarChar), _
                                                New SqlParameter("@polisnommer", SqlDbType.NVarChar), _
                                                New SqlParameter("@LopieTipe", SqlDbType.NVarChar), _
                                                New SqlParameter("@Motors", SqlDbType.Money), _
                                                New SqlParameter("@AR", SqlDbType.Money), _
                                                New SqlParameter("@HBGewoon", SqlDbType.Money), _
                                                New SqlParameter("@HEGewoon", SqlDbType.Money), _
                                                New SqlParameter("@HBGras", SqlDbType.Money), _
                                                New SqlParameter("@HEGras", SqlDbType.Money), _
                                                New SqlParameter("@TSElektries", SqlDbType.Money), _
                                                New SqlParameter("@TSGewoon", SqlDbType.Money), _
                                                New SqlParameter("@Waterlewe", SqlDbType.Money), _
                                                New SqlParameter("@Sasria", SqlDbType.Money), _
                                                New SqlParameter("@polisfooi", SqlDbType.Money), _
                                                New SqlParameter("@Plip", SqlDbType.Money), _
                                                New SqlParameter("@CareAssist", SqlDbType.Money), _
                                                New SqlParameter("@selfoon", SqlDbType.Money), _
                                                New SqlParameter("@Safrican", SqlDbType.Money), _
                                                New SqlParameter("@Medies", SqlDbType.Money), _
                                                New SqlParameter("@TVDiens", SqlDbType.Money), _
                                                New SqlParameter("@Beskerming", SqlDbType.Money), _
                                                New SqlParameter("@Geleentheidsmotor", SqlDbType.Money), _
                                                New SqlParameter("@Instandhoudingskontrak", SqlDbType.Money), _
                                                New SqlParameter("@Pakketitem1", SqlDbType.Money), _
                                                New SqlParameter("@Pakketitem2", SqlDbType.Money), _
                                                New SqlParameter("@Pakketitem3", SqlDbType.Money), _
                                                New SqlParameter("@Pakketitem4", SqlDbType.Money), _
                                                New SqlParameter("@SpesialeKorting", SqlDbType.Money), _
                                                New SqlParameter("@Afsluitdatum", SqlDbType.Date)}

                Diagnostics.Debug.WriteLine("Opdateerhollard")
                paramHollard(0).Value = intfkVersekeraar
                paramHollard(1).Value = intMakelaarfk
                paramHollard(2).Value = strArea
                paramHollard(3).Value = strBetaalwyseKommissie
                paramHollard(4).Value = IIf(strVersekerde Is Nothing, "", strVersekerde)
                paramHollard(5).Value = IIf(strVoorl Is Nothing, "", strVoorl)
                paramHollard(6).Value = IIf(strPolisno Is Nothing, "", strPolisno)
                paramHollard(7).Value = IIf(strLopieTipe Is Nothing, "", strLopieTipe)
                paramHollard(8).Value = String.Format("{0:N2}", dblMotorsAP)
                paramHollard(9).Value = String.Format("{0:N2}", dblAlleRisikoAP)
                paramHollard(10).Value = String.Format("{0:N2}", dblHBAP)
                paramHollard(11).Value = String.Format("{0:N2}", dblHEAP)
                paramHollard(12).Value = String.Format("{0:N2}", dblHBGrasAP)
                paramHollard(13).Value = String.Format("{0:N2}", dblHEGrasAP)
                paramHollard(14).Value = String.Format("{0:N2}", dblToevalEEMAP)
                paramHollard(15).Value = String.Format("{0:N2}", dblToevalBreekAP)
                paramHollard(16).Value = String.Format("{0:N2}", dblWaterleweAP)
                paramHollard(17).Value = String.Format("{0:N2}", dblSasriaAP)
                paramHollard(18).Value = String.Format("{0:N2}", dblPolisfooiAP)
                paramHollard(19).Value = String.Format("{0:N2}", dblPlipAP)
                paramHollard(20).Value = String.Format("{0:N2}", dblCareAssistAP)
                paramHollard(21).Value = String.Format("{0:N2}", dblSelfoonAP)
                paramHollard(22).Value = String.Format("{0:N2}", dblBegrafnisAP)
                paramHollard(23).Value = String.Format("{0:N2}", dblMedies)
                paramHollard(24).Value = String.Format("{0:N2}", dblTVDiensAP)
                paramHollard(25).Value = String.Format("{0:N2}", dblBeskermAP)
                paramHollard(26).Value = String.Format("{0:N2}", dblCourtesyvAP)
                paramHollard(27).Value = String.Format("{0:N2}", dblEPCAP)
                paramHollard(28).Value = String.Format("{0:N2}", dblPakketitem1AP)
                paramHollard(29).Value = String.Format("{0:N2}", dblPakketitem2AP)
                paramHollard(30).Value = String.Format("{0:N2}", dblPakketitem3AP)
                paramHollard(31).Value = String.Format("{0:N2}", dblPakketitem4AP)
                paramHollard(32).Value = String.Format("{0:N2}", dblSpesialeKortingAP)
                If strBetaalwyseKommissie = "MS" Then
                    'vir bloemfontein gaan hierdie uitgebrei moet word - sluit nie altyd op dieselfde dag af vir die verskillende areas nie.
                    If strTak = "Bloemfontein" Then
                        If strArea = "2" Then     'UV
                            paramHollard(33).Value = Me.dtpSalary1.Value
                        ElseIf strArea = "3" Then     'SUT
                            paramHollard(33).Value = Me.dtpSalary2.Value
                        Else        'nie UV of SUT nie, vat default van gewone nie MS afsluitdatum
                            paramHollard(33).Value = Me.dtpPreviousFinalRun.Value
                        End If
                    Else
                        paramHollard(33).Value = Me.dtpSalary1.Value
                    End If
                Else
                    paramHollard(33).Value = Me.dtpPreviousFinalRun.Value
                End If

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.UpdateKontantRekonHollard", paramHollard)

                If connHollard.State = ConnectionState.Open Then
                    connHollard.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Private Sub Rekonlopie()
        Dim dblVerskil As Decimal
        'Dim dblOorblybedrag As Decimal
        Dim blnRekon As Boolean
        Dim intCount As Integer = 0
        Dim intfkMakelaar As Integer
        Dim strBetaalwyseTemp As String = ""
        Dim strBetwyseKRH As String = ""
        Dim dteVTAfsluitdatum As Date
        Dim intDatumAangevraMonth As Integer
        Dim intDatumAangevraYear As Integer
        Dim dblVtVordPremie As Decimal
        Dim dblVtPremie As Decimal
        Dim strLopieTipe1 As String = ""
        Dim dblVordPremie As Decimal = 0
        Dim dblVTenMaandVerskil As Decimal = 0
        Dim blnVTenMaandVerskil As Boolean

        'skryf rekon rekords
        'Persentasiegewys bo die lyn
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@jaar", SqlDbType.Int), _
                                                New SqlParameter("@maand", SqlDbType.Int), _
                                                New SqlParameter("@fkversekeraar", SqlDbType.Int), _
                                                New SqlParameter("@Type", SqlDbType.NVarChar)}

                param(0).Value = intJaar
                param(1).Value = intMnd
                param(2).Value = Me.cmbInsurer.SelectedValue
                param(3).Value = strLopieTipe

                Dim readerKommissieDetail As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchKommissieDetail", param)

                If strLopieTipe = "Rekon" Then
                    strBetaalwyseTemp = ""
                Else
                    strBetaalwyseTemp = "fk"
                End If

                Do While readerKommissieDetail.Read
                    If intCount = 0 Then
                        strBetwyse = readerKommissieDetail("" & strBetaalwyseTemp & "betaalwyse")
                        strArea = readerKommissieDetail("area")
                        intfkMakelaar = readerKommissieDetail("fkmakelaar")
                        intMakelaarfk = intfkMakelaar

                        If readerKommissieDetail("betaalwyse") = "4" Then
                            strBetwyseKRH = "MD"
                        ElseIf readerKommissieDetail("betaalwyse") = "1" Then
                            strBetwyseKRH = "MK"
                        ElseIf readerKommissieDetail("betaalwyse") = "5" Then
                            strBetwyseKRH = "ME"
                        ElseIf readerKommissieDetail("betaalwyse") = "2" Then
                            strBetwyseKRH = "JK"
                        ElseIf readerKommissieDetail("betaalwyse") = "3" Then
                            strBetwyseKRH = "MS"
                        ElseIf readerKommissieDetail("betaalwyse") = "6" Then
                            strBetwyseKRH = "LT"
                        End If
                    End If

                    intCount += 1

                    Diagnostics.Debug.WriteLine("rekonlopie")

                    If strBetwyse <> readerKommissieDetail("" & strBetaalwyseTemp & "betaalwyse") Or strArea <> readerKommissieDetail("area") Or intfkMakelaar <> readerKommissieDetail("fkmakelaar") Then
                        strAreaBesk = clsRun.GetArea(strArea)

                        'UpdateHollardOorbetalings
                        UpdateHollardOorbetalings(strBetwyseKRH, strArea, intfkMakelaar)

                        strBetwyse = readerKommissieDetail("" & strBetaalwyseTemp & "betaalwyse")
                        strArea = readerKommissieDetail("area")
                        intfkMakelaar = readerKommissieDetail("fkmakelaar")
                        intMakelaarfk = intfkMakelaar

                        If readerKommissieDetail("betaalwyse") = "4" Then
                            strBetwyseKRH = "MD"
                        ElseIf readerKommissieDetail("betaalwyse") = "1" Then
                            strBetwyseKRH = "MK"
                        ElseIf readerKommissieDetail("betaalwyse") = "5" Then
                            strBetwyseKRH = "ME"
                        ElseIf readerKommissieDetail("betaalwyse") = "2" Then
                            strBetwyseKRH = "JK"
                        ElseIf readerKommissieDetail("betaalwyse") = "3" Then
                            strBetwyseKRH = "MS"
                        ElseIf readerKommissieDetail("betaalwyse") = "6" Then
                            strBetwyseKRH = "LT"
                        End If
                    End If

                    If strArea = "2" Then
                        strArea = strArea
                    End If
                    blnRekon = False
                    strVersekerde = readerKommissieDetail("versekerde")
                    strVoorl = readerKommissieDetail("voorl")
                    strPolisno = readerKommissieDetail("polisno")

                    If strPolisno = "1685000887" Or strPolisno = "1183052722" Then
                        strPolisno = strPolisno
                    End If

                    If readerKommissieDetail("betaalwyse") = "4" Then
                        strLopieTipe = "MD rekon"
                    ElseIf readerKommissieDetail("betaalwyse") = "1" Then
                        strLopieTipe = "MK rekon"
                    ElseIf readerKommissieDetail("betaalwyse") = "5" Then
                        strLopieTipe = "ME rekon"
                    ElseIf readerKommissieDetail("betaalwyse") = "2" Then
                        strLopieTipe = "JK rekon"
                    ElseIf readerKommissieDetail("betaalwyse") = "3" Then
                        strLopieTipe = "MS rekon"
                    ElseIf readerKommissieDetail("betaalwyse") = "6" Then
                        strLopieTipe = "LT rekon"

                        'vertoon lys van uitgeloopte premies en skep aanmaningsbriewe vir polisse wat oor 2 maande gaan uitloop vir ltp
                        strUitgeloopJN = "N"
                        strOor2MaandeUitgeloopJN = "N"
                        strVertoonEarnedJN = "N"

                        clsRun.BerekenLangtermynPolisFondse(strPolisno, "01" & "/" & Format(Month(Me.dtpTo.Value), "00") & "/" & Format(Year(Me.dtpTo.Value), "0000"))

                        If strUitgeloopJN = "J" Then
                            GetVorigeAfsluitingTotal(strPolisno)

                            dblVerskil = dblPremie2
                            dblOorblyBedrag = dblVerskil
                            dblOorblyBedrag1 = dblOorblyBedrag
                            dblBedragFinTotaal = dblBedragFinTotaal + dblVerskil

                            PasbedragAan(readerKommissieDetail("versekerde"), readerKommissieDetail("voorl"), readerKommissieDetail("Polisno"))

                            WriteValues(readerKommissieDetail("versekerde"), readerKommissieDetail("voorl"), readerKommissieDetail("Polisno"), strLopieTipe, readerKommissieDetail("bet_wyse"), dblPolisfooiAP, (dblMotorsAP + (dblSpesialeKortingAP * -1)), dblAlleRisikoAP, dblHBAP, dblHEAP, dblHBGrasAP, dblHEGrasAP, dblToevalEEMAP, dblToevalBreekAP, dblWaterleweAP, dblSasriaAP, dblPlipAP, dblCareAssistAP, dblEPCAP, dblSelfoonAP, dblBegrafnisAP, 0, dblTVDiensAP, dblBeskermAP, dblCourtesyvAP, dblPakketitem1AP, dblPakketitem2AP, dblPakketitem3AP, dblPakketitem4AP, dblPolisfooiAP, 0)

                            UpdateKontantRekonHollard()

                        End If
                        blnRekon = True
                    End If

                    strLopieTipe1 = strLopieTipe

                        'kyk vir VT's
                        Try
                            Using connVT As SqlConnection = SqlHelper.GetConnection
                                Dim paramVT() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                                New SqlParameter("@Vanaf", SqlDbType.Date), _
                                                                New SqlParameter("@Tot", SqlDbType.Date)}

                                paramVT(0).Value = strPolisno
                                paramVT(1).Value = dteVanaf
                                paramVT(2).Value = dteTot

                                Dim readerVT As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchMaandVTdetailsPolisnoDate", paramVT)

                                If strPolisno = "1183052434" Then
                                    strPolisno = strPolisno
                                End If

                                Do While readerVT.Read
                                    strLopieTipe = "VT lopie"
                                    intDatumAangevraMonth = Month(readerVT("datumaangevra"))
                                    intDatumAangevraYear = Year(readerVT("datumaangevra"))
                                    'indien die vt vir die vorige maand is, moet dit die vorige maand se afsluitdatum kry
                                    If intDatumAangevraMonth <> intMnd Or intDatumAangevraYear <> intJaar Then
                                        Try
                                            Using connMaand As SqlConnection = SqlHelper.GetConnection
                                                Dim paramMaand() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                                               New SqlParameter("@Maand", SqlDbType.Int), _
                                                                               New SqlParameter("@JAAR", SqlDbType.Int)}

                                                paramMaand(0).Value = strPolisno
                                                paramMaand(1).Value = intDatumAangevraMonth
                                                paramMaand(2).Value = intDatumAangevraYear

                                                Dim readerMaand As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchMaandDebities", paramMaand)

                                                If readerMaand.Read Then
                                                    Dim list As New List(Of MaandEntity)
                                                    Dim item As MaandEntity = New MaandEntity()

                                                    If readerMaand("polisno") IsNot DBNull.Value Then
                                                        item.POLISNO = readerMaand("polisno")
                                                    End If
                                                    If readerMaand("afsluit_dat") IsNot DBNull.Value Then
                                                        item.AFSLUIT_DAT = readerMaand("afsluit_dat")
                                                    End If
                                                    If readerMaand("vord_premie") IsNot DBNull.Value Then
                                                        item.VORD_PREMIE = readerMaand("vord_premie")
                                                    End If
                                                    If readerMaand("premie") IsNot DBNull.Value Then
                                                        item.PREMIE = readerMaand("premie")
                                                    End If
                                                    If readerMaand("BETAALWYSE") IsNot DBNull.Value Then
                                                        item.BETAALWYSE = readerMaand("BETAALWYSE")
                                                    End If

                                                    dteVTAfsluitdatum = item.AFSLUIT_DAT
                                                    dblVtVordPremie = item.VORD_PREMIE
                                                    dblVtPremie = item.PREMIE
                                                    dblVerskil = dblVtVordPremie - dblVtPremie
                                                    dblOorblyBedrag = dblVerskil
                                                    dblOorblyBedrag1 = dblOorblyBedrag
                                                    dblBedragFinTotaal = dblBedragFinTotaal + dblVerskil

                                                    PasbedragAan(strVersekerde, strVoorl, item.POLISNO)

                                                    WriteValues(strVersekerde, strVoorl, item.POLISNO, strLopieTipe, item.BETAALWYSE, dblPolisfooiAP, (dblMotorsAP + (dblSpesialeKortingAP * -1)), dblAlleRisikoAP, dblHBAP, dblHEAP, dblHBGrasAP, dblHEGrasAP, dblToevalEEMAP, dblToevalBreekAP, dblWaterleweAP, dblSasriaAP, dblPlipAP, dblCareAssistAP, dblEPCAP, dblSelfoonAP, dblBegrafnisAP, 0, dblTVDiensAP, dblBeskermAP, dblCourtesyvAP, dblPakketitem1AP, dblPakketitem2AP, dblPakketitem3AP, dblPakketitem4AP, dblPolisfooiAP, 0)

                                                    UpdateKontantRekonHollard()

                                                    blnRekon = True
                                                End If

                                                If connMaand.State = ConnectionState.Open Then
                                                    readerMaand.Close()
                                                End If
                                            End Using
                                        Catch ex As Exception
                                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                                            Exit Sub
                                    End Try
                                    'as vt en verwag nie dieselfde is nie
                                ElseIf readerKommissieDetail("premie") <> readerVT("vt_bedrag") Then
                                    blnVTenMaandVerskil = True
                                    dblVerskil = readerVT("vt_bedrag") * -1
                                    dblVTenMaandVerskil = dblVerskil
                                    dblOorblyBedrag = dblVerskil
                                    dblOorblyBedrag1 = dblOorblyBedrag
                                    dblBedragFinTotaal = dblBedragFinTotaal + dblVerskil

                                    PasbedragAan(readerKommissieDetail("versekerde"), readerKommissieDetail("voorl"), readerKommissieDetail("Polisno"))

                                    WriteValues(readerKommissieDetail("versekerde"), readerKommissieDetail("voorl"), readerKommissieDetail("Polisno"), strLopieTipe, readerKommissieDetail("bet_wyse"), dblPolisfooiAP, (dblMotorsAP + (dblSpesialeKortingAP * -1)), dblAlleRisikoAP, dblHBAP, dblHEAP, dblHBGrasAP, dblHEGrasAP, dblToevalEEMAP, dblToevalBreekAP, dblWaterleweAP, dblSasriaAP, dblPlipAP, dblCareAssistAP, dblEPCAP, dblSelfoonAP, dblBegrafnisAP, 0, dblTVDiensAP, dblBeskermAP, dblCourtesyvAP, dblPakketitem1AP, dblPakketitem2AP, dblPakketitem3AP, dblPakketitem4AP, dblPolisfooiAP, 0)

                                    UpdateKontantRekonHollard()

                                    blnRekon = False
                                Else
                                    dblVerskil = readerKommissieDetail("vord_premie") - readerKommissieDetail("premie")
                                    dblOorblyBedrag = dblVerskil
                                    dblOorblyBedrag1 = dblOorblyBedrag
                                    dblBedragFinTotaal = dblBedragFinTotaal + dblVerskil

                                    PasbedragAan(readerKommissieDetail("versekerde"), readerKommissieDetail("voorl"), readerKommissieDetail("Polisno"))

                                    WriteValues(readerKommissieDetail("versekerde"), readerKommissieDetail("voorl"), readerKommissieDetail("Polisno"), strLopieTipe, readerKommissieDetail("bet_wyse"), dblPolisfooiAP, (dblMotorsAP + (dblSpesialeKortingAP * -1)), dblAlleRisikoAP, dblHBAP, dblHEAP, dblHBGrasAP, dblHEGrasAP, dblToevalEEMAP, dblToevalBreekAP, dblWaterleweAP, dblSasriaAP, dblPlipAP, dblCareAssistAP, dblEPCAP, dblSelfoonAP, dblBegrafnisAP, 0, dblTVDiensAP, dblBeskermAP, dblCourtesyvAP, dblPakketitem1AP, dblPakketitem2AP, dblPakketitem3AP, dblPakketitem4AP, dblPolisfooiAP, 0)

                                    UpdateKontantRekonHollard()

                                    blnRekon = True
                                    End If
                                Loop

                                If connVT.State = ConnectionState.Open Then
                                    connVT.Close()
                                End If
                            End Using
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                        End Try

                        'kyk vir betalings
                        Try
                            Using connKontant As SqlConnection = SqlHelper.GetConnection
                                Dim paramKontant() As SqlParameter = {New SqlParameter("@Vanaf", SqlDbType.Date), _
                                                                New SqlParameter("@Tot", SqlDbType.Date), _
                                                                New SqlParameter("@Polisno", SqlDbType.NVarChar)}

                                paramKontant(0).Value = Me.dtpFrom.Value
                                paramKontant(1).Value = Me.dtpTo.Value
                                paramKontant(2).Value = strPolisno

                                Dim readerKontant As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchKontantByTrans_Dat", paramKontant)

                            Do While readerKontant.Read
                                'If readerKontant("jaar") <> intJaar Or readerKontant("maand") <> intMnd Then
                                '    strLopieTipe = readerKontant("tipe") & " betaling"
                                'End If
                                'If readerKontant("tipe") = "VB" Or readerKontant("tipe") = "TB" Or readerKontant("tipe") = "EB" Then
                                '    strLopieTipe = readerKontant("tipe") & " betaling"
                                'End If
                                strLopieTipe = readerKontant("tipe") & " betaling"
                                dblVordPremie = IIf(readerKontant("vord_premie") Is DBNull.Value, 0, readerKontant("vord_premie"))

                                If readerKontant("tipe") = "TB" Then
                                    dblVerskil = (IIf(readerKontant("vord_premie") Is DBNull.Value, 0, readerKontant("vord_premie")) - IIf(readerKontant("premie") Is DBNull.Value, 0, readerKontant("premie"))) * -1
                                Else
                                    dblVerskil = IIf(readerKontant("vord_premie") Is DBNull.Value, 0, readerKontant("vord_premie")) - IIf(readerKontant("premie") Is DBNull.Value, 0, readerKontant("premie"))
                                End If
                                dblOorblyBedrag = dblVerskil
                                dblOorblyBedrag1 = dblOorblyBedrag
                                dblBedragFinTotaal = dblBedragFinTotaal + dblVerskil

                                PasbedragAan(readerKommissieDetail("versekerde"), readerKommissieDetail("voorl"), readerKommissieDetail("Polisno"))

                                WriteValues(readerKommissieDetail("versekerde"), readerKommissieDetail("voorl"), readerKommissieDetail("Polisno"), strLopieTipe, readerKommissieDetail("bet_wyse"), dblPolisfooiAP, (dblMotorsAP + (dblSpesialeKortingAP * -1)), dblAlleRisikoAP, dblHBAP, dblHEAP, dblHBGrasAP, dblHEGrasAP, dblToevalEEMAP, dblToevalBreekAP, dblWaterleweAP, dblSasriaAP, dblPlipAP, dblCareAssistAP, dblEPCAP, dblSelfoonAP, dblBegrafnisAP, 0, dblTVDiensAP, dblBeskermAP, dblCourtesyvAP, dblPakketitem1AP, dblPakketitem2AP, dblPakketitem3AP, dblPakketitem4AP, dblPolisfooiAP, 0)

                                UpdateKontantRekonHollard()

                                'If readerKommissieDetail("betaalwyse") = "1" Or readerKommissieDetail("betaalwyse") = "5" Or readerKommissieDetail("betaalwyse") = "2" Then
                                '    blnRekon = True
                                'Else
                                '    blnRekon = False
                                'End If

                            Loop

                                If connKontant.State = ConnectionState.Open Then
                                    connKontant.Close()
                                End If
                            End Using
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try

                    If readerKommissieDetail("premie") <> readerKommissieDetail("vord_premie") Then
                        dblVordPremie = readerKommissieDetail("vord_premie")
                        If blnRekon = False Then
                            strLopieTipe = strLopieTipe1

                            If blnVTenMaandVerskil = True Then
                                dblVerskil = (readerKommissieDetail("premie") + dblVTenMaandVerskil) * -1
                            Else
                                dblVerskil = dblVordPremie - readerKommissieDetail("premie")
                            End If
                            
                            dblOorblyBedrag = dblVerskil
                            dblOorblyBedrag1 = dblOorblyBedrag
                            dblBedragFinTotaal = dblBedragFinTotaal + dblVerskil

                            PasbedragAan(readerKommissieDetail("versekerde"), readerKommissieDetail("voorl"), readerKommissieDetail("Polisno"))

                            WriteValues(readerKommissieDetail("versekerde"), readerKommissieDetail("voorl"), readerKommissieDetail("Polisno"), strLopieTipe, readerKommissieDetail("bet_wyse"), dblPolisfooiAP, (dblMotorsAP + (dblSpesialeKortingAP * -1)), dblAlleRisikoAP, dblHBAP, dblHEAP, dblHBGrasAP, dblHEGrasAP, dblToevalEEMAP, dblToevalBreekAP, dblWaterleweAP, dblSasriaAP, dblPlipAP, dblCareAssistAP, dblEPCAP, dblSelfoonAP, dblBegrafnisAP, 0, dblTVDiensAP, dblBeskermAP, dblCourtesyvAP, dblPakketitem1AP, dblPakketitem2AP, dblPakketitem3AP, dblPakketitem4AP, dblPolisfooiAP, 0)

                            UpdateKontantRekonHollard()
                        End If
                    End If
                    blnVTenMaandVerskil = False
                Loop
                'UpdateHollardOorbetalings
                strAreaBesk = clsRun.GetArea(strArea)
                UpdateHollardOorbetalings(strBetwyseKRH, strArea, intfkMakelaar)

                strVersekerde = ""
                strVoorl = ""
                strPolisno = ""

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub WriteValues(ByVal strVersekerde As String, ByVal strVoorl As String, strPolisnommer As String, strTipe As String, intfkBetaalwyse As Integer, dblPolisfooi As Decimal, _
                            dblMotors As Decimal, dblAlleRisiko As Decimal, dblHBGewoon As Decimal, dblHEGewoon As Decimal, dblHBGras As Decimal, dblHEGras As Decimal, _
                            dblTSElektries As Decimal, dblTSGewoon As Decimal, dblWater As Decimal, dblSasria As Decimal, dblPlip As Decimal, dblCareAssist As Decimal, _
                            dblHomeAssist As Decimal, dblCellphones As Decimal, dblSafrican As Decimal, dblMedies As Decimal, dblTVDiens As Decimal, _
                            dblBeskerming As Decimal, dblCourtesy As Decimal, dblPakketitem1 As Decimal, dblPakketitem2 As Decimal, dblPakketitem3 As Decimal, _
                            dblPakketitem4 As Decimal, dblAanspreeklikheid As Decimal, dblSpesialeKorting As Decimal)

        Diagnostics.Debug.WriteLine("writevalues")
        strVersekerde = strVersekerde
        strVoorl = strVoorl
        strPolisno = strPolisnommer
        strLopieTipe = strTipe
        dblMotorsAP = dblMotors
        dblAlleRisikoAP = dblAlleRisiko
        dblHBAP = dblHBGewoon
        dblHEAP = dblHEGewoon
        dblHBGrasAP = dblHBGras
        dblHEGrasAP = dblHEGras
        dblToevalEEMAP = dblTSElektries
        dblToevalBreekAP = dblTSGewoon
        dblWaterleweAP = dblWater
        dblSasriaAP = dblSasria
        dblPolisfooiAP = dblPolisfooi
        dblPlipAP = dblPlip
        dblCareAssistAP = dblCareAssist
        dblSelfoonAP = dblCellphones
        dblBegrafnisAP = dblSafrican
        dblTVDiensAP = dblTVDiens
        dblBeskermAP = dblBeskerming
        dblCourtesyvAP = dblCourtesy
        dblEPCAP = dblHomeAssist
        dblPakketitem1AP = dblPakketitem1
        dblPakketitem2AP = dblPakketitem2
        dblPakketitem3AP = dblPakketitem3
        dblPakketitem4AP = dblPakketitem4
        dblSpesialeKortingAP = dblSpesialeKorting
        strArea = strArea

        Select Case intfkBetaalwyse
            Case 1
                strBetaalwyseKommissie = "MK"
            Case 2
                strBetaalwyseKommissie = "JK"
            Case 3
                strBetaalwyseKommissie = "MS"
            Case 4
                strBetaalwyseKommissie = "MD"
            Case 5
                strBetaalwyseKommissie = "ME"
            Case 6
                strBetaalwyseKommissie = "LT"
        End Select

    End Sub
    Private Sub ClearValues()

        dblMotorsAP = 0
        dblAlleRisikoAP = 0
        dblHBAP = 0
        dblHEAP = 0
        dblHBGrasAP = 0
        dblHEGrasAP = 0
        dblToevalEEMAP = 0
        dblToevalBreekAP = 0
        dblWaterleweAP = 0
        dblSasriaAP = 0
        dblPolisfooiAP = 0
        dblPlipAP = 0
        dblCareAssistAP = 0
        dblSelfoonAP = 0
        dblBegrafnisAP = 0
        dblTVDiensAP = 0
        dblBeskermAP = 0
        dblCourtesyvAP = 0
        dblEPCAP = 0
        dblPakketitem1AP = 0
        dblPakketitem2AP = 0
        dblPakketitem3AP = 0
        dblPakketitem4AP = 0

    End Sub
    Private Sub PasbedragAan(strVersekerde As String, strVoorl As String, strPolisno As String)

        Dim dblIndivMTTotaal As Decimal
        Dim dblIndivWLTotaal As Decimal
        Dim dblIndivARTotaal As Decimal
        Dim dblIndivHEGewTotaal As Decimal
        Dim dblIndivHBGewTotaal As Decimal
        Dim dblIndivHEGrasTotaal As Decimal
        Dim dblIndivHBGrasTotaal As Decimal
        Dim dblIndivEEMTotaal As Decimal
        Dim dblIndivToeTotaal As Decimal
        Dim dblIndivSubt As Decimal
        Dim dblIndivMTPers As Decimal
        Dim dblIndivARPers As Decimal
        Dim dblIndivHBGewPers As Decimal
        Dim dblIndivHEGewPers As Decimal
        Dim dblIndivHBGrasPers As Decimal
        Dim dblIndivHEGrasPers As Decimal
        Dim dblIndivEEMPers As Decimal
        Dim dblIndivToePers As Decimal
        Dim dblIndivWLPers As Decimal

        Try
            Using connMD As SqlConnection = SqlHelper.GetConnection
                Dim paramMD() As SqlParameter = {New SqlParameter("@afsluitdat", SqlDbType.Date), _
                                                 New SqlParameter("@afsluitdat2", SqlDbType.Date), _
                                                 New SqlParameter("@afsluitdat3", SqlDbType.Date), _
                                                New SqlParameter("@polisno", SqlDbType.NVarChar)}

                paramMD(0).Value = Me.dtpPreviousFinalRun.Value
                If Me.dtpSalary1.Enabled = True Then
                    paramMD(1).Value = Me.dtpSalary1.Value
                Else
                    paramMD(1).Value = Me.dtpPreviousFinalRun.Value
                End If
                If Me.dtpSalary2.Enabled = True Then
                    paramMD(2).Value = Me.dtpSalary2.Value
                Else
                    paramMD(2).Value = Me.dtpPreviousFinalRun.Value
                End If
                paramMD(3).Value = strPolisno

                Dim readerMD As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5d.FetchDataforCommission", paramMD)

                If strPolisno = "1183052722" Then
                    strPolisno = strPolisno
                End If
                If readerMD.Read Then
                    ClearValues()
                    dblBedrag = readerMD("premie2")
                    Diagnostics.Debug.WriteLine("pasbedragaan " & strPolisno)
                    'spesiale korting
                    If readerMD("verwyskommissie") <> 0 Then
                        dblSpesialeKortingAP = GetSpesialeKorting(readerMD("verwyskommissie"), readerMD("polisno"), readerMD("premie2"))
                    Else
                        dblSpesialeKortingAP = 0
                    End If

                    'onder die lyn
                    If dblOorblyBedrag < 0 Then
                        dblOorblyBedrag = dblOorblyBedrag * -1
                    End If
                    'sasria
                    If dblOorblyBedrag - readerMD("sasprem") >= 0 Then
                        dblOorblyBedrag = dblOorblyBedrag - readerMD("sasprem")


                        If (UCase(strLopieTipe) = "VT LOPIE" Or UCase(strLopieTipe) = "TB LOPIE" Or UCase(strLopieTipe) = "UITGELOOPTEPREMIES") Or dblBedrag < 0 Or dblOorblyBedrag1 < 0 Then
                            dblSasriaAP = readerMD("sasprem") * -1
                        Else
                            dblSasriaAP = readerMD("sasprem")
                        End If
                    Else
                        If dblOorblyBedrag1 < 0 Then
                            dblMotorsAP = dblOorblyBedrag * -1
                        Else
                            dblMotorsAP = dblOorblyBedrag
                        End If
                        Exit Sub
                    End If
                    'plip
                    If dblOorblyBedrag >= readerMD("plip") Then
                        dblOorblyBedrag = dblOorblyBedrag - readerMD("plip")

                        If (UCase(strLopieTipe) = "VT LOPIE" Or UCase(strLopieTipe) = "TB LOPIE" Or UCase(strLopieTipe) = "UITGELOOPTEPREMIES") Or dblBedrag < 0 Or dblOorblyBedrag1 < 0 Then
                            dblPlipAP = readerMD("plip") * -1
                        Else
                            dblPlipAP = readerMD("plip")
                        End If
                    Else
                        If dblOorblyBedrag1 < 0 Then
                            dblMotorsAP = dblOorblyBedrag * -1
                        Else
                            dblMotorsAP = dblOorblyBedrag
                        End If
                        Exit Sub
                    End If
                    'care assist
                    If dblOorblyBedrag >= readerMD("careassist") Then
                        dblOorblyBedrag = dblOorblyBedrag - readerMD("careassist")

                        If (UCase(strLopieTipe) = "VT LOPIE" Or UCase(strLopieTipe) = "TB LOPIE" Or UCase(strLopieTipe) = "UITGELOOPTEPREMIES") Or dblBedrag < 0 Or dblOorblyBedrag1 < 0 Then
                            dblCareAssistAP = readerMD("careassist") * -1
                        Else
                            dblCareAssistAP = readerMD("careassist")
                        End If
                    Else
                        If dblOorblyBedrag1 < 0 Then
                            dblMotorsAP = dblOorblyBedrag * -1
                        Else
                            dblMotorsAP = dblOorblyBedrag
                        End If
                        Exit Sub
                    End If
                    'epc
                    If dblOorblyBedrag >= readerMD("epc") Then
                        dblOorblyBedrag = dblOorblyBedrag - readerMD("epc")

                        If (UCase(strLopieTipe) = "VT LOPIE" Or UCase(strLopieTipe) = "TB LOPIE" Or UCase(strLopieTipe) = "UITGELOOPTEPREMIES") Or dblBedrag < 0 Or dblOorblyBedrag1 < 0 Then
                            dblEPCAP = readerMD("epc") * -1
                        Else
                            dblEPCAP = readerMD("epc")
                        End If
                    Else
                        If dblOorblyBedrag1 < 0 Then
                            dblMotorsAP = dblOorblyBedrag * -1
                        Else
                            dblMotorsAP = dblOorblyBedrag
                        End If
                        Exit Sub
                    End If
                    'insurecell
                    If dblOorblyBedrag >= readerMD("inscell") Then
                        dblOorblyBedrag = dblOorblyBedrag - readerMD("inscell")

                        If (UCase(strLopieTipe) = "VT LOPIE" Or UCase(strLopieTipe) = "TB LOPIE" Or UCase(strLopieTipe) = "UITGELOOPTEPREMIES") Or dblBedrag < 0 Or dblOorblyBedrag1 < 0 Then
                            dblSelfoonAP = readerMD("inscell") * -1
                        Else
                            dblSelfoonAP = readerMD("inscell")
                        End If
                    Else
                        If dblOorblyBedrag1 < 0 Then
                            dblMotorsAP = dblOorblyBedrag * -1
                        Else
                            dblMotorsAP = dblOorblyBedrag
                        End If
                        Exit Sub
                    End If
                    'begrafnis
                    If dblOorblyBedrag >= readerMD("begrafnis") Then
                        dblOorblyBedrag = dblOorblyBedrag - readerMD("begrafnis")

                        If (UCase(strLopieTipe) = "VT LOPIE" Or UCase(strLopieTipe) = "TB LOPIE" Or UCase(strLopieTipe) = "UITGELOOPTEPREMIES") Or dblBedrag < 0 Or dblOorblyBedrag1 < 0 Then
                            dblBegrafnisAP = readerMD("begrafnis") * -1
                        Else
                            dblBegrafnisAP = readerMD("begrafnis")
                        End If
                    Else
                        If dblOorblyBedrag1 < 0 Then
                            dblMotorsAP = dblOorblyBedrag * -1
                        Else
                            dblMotorsAP = dblOorblyBedrag
                        End If
                        Exit Sub
                    End If
                    'medies
                    dblMedies = 0

                    'tvdiens
                    If dblOorblyBedrag >= readerMD("tv_diens") Then
                        dblOorblyBedrag = dblOorblyBedrag - readerMD("tv_diens")

                        If (UCase(strLopieTipe) = "VT LOPIE" Or UCase(strLopieTipe) = "TB LOPIE" Or UCase(strLopieTipe) = "UITGELOOPTEPREMIES") Or dblBedrag < 0 Or dblOorblyBedrag1 < 0 Then
                            dblTVDiensAP = readerMD("tv_diens") * -1
                        Else
                            dblTVDiensAP = readerMD("tv_diens")
                        End If
                    Else
                        If dblOorblyBedrag1 < 0 Then
                            dblMotorsAP = dblOorblyBedrag * -1
                        Else
                            dblMotorsAP = dblOorblyBedrag
                        End If
                        Exit Sub
                    End If
                    'beskerming
                    If dblOorblyBedrag >= readerMD("beskerm") Then
                        dblOorblyBedrag = dblOorblyBedrag - readerMD("beskerm")

                        If (UCase(strLopieTipe) = "VT LOPIE" Or UCase(strLopieTipe) = "TB LOPIE" Or UCase(strLopieTipe) = "UITGELOOPTEPREMIES") Or dblBedrag < 0 Or dblOorblyBedrag1 < 0 Then
                            dblBeskermAP = readerMD("beskerm") * -1
                        Else
                            dblBeskermAP = readerMD("beskerm")
                        End If
                    Else
                        If dblOorblyBedrag1 < 0 Then
                            dblMotorsAP = dblOorblyBedrag * -1
                        Else
                            dblMotorsAP = dblOorblyBedrag
                        End If
                        Exit Sub
                    End If
                    'geleentheidsmotor
                    If dblOorblyBedrag >= readerMD("courtesyv") Then
                        dblOorblyBedrag = dblOorblyBedrag - readerMD("courtesyv")

                        If (UCase(strLopieTipe) = "VT LOPIE" Or UCase(strLopieTipe) = "TB LOPIE" Or UCase(strLopieTipe) = "UITGELOOPTEPREMIES") Or dblBedrag < 0 Or dblOorblyBedrag1 < 0 Then
                            dblCourtesyvAP = readerMD("courtesyv") * -1
                        Else
                            dblCourtesyvAP = readerMD("courtesyv")
                        End If
                    Else
                        If dblOorblyBedrag1 < 0 Then
                            dblMotorsAP = dblOorblyBedrag * -1
                        Else
                            dblMotorsAP = dblOorblyBedrag
                        End If
                        Exit Sub
                    End If
                    'pakketitem1
                    If dblOorblyBedrag >= readerMD("pakketitem1") Then
                        dblOorblyBedrag = dblOorblyBedrag - readerMD("pakketitem1")

                        If (UCase(strLopieTipe) = "VT LOPIE" Or UCase(strLopieTipe) = "TB LOPIE" Or UCase(strLopieTipe) = "UITGELOOPTEPREMIES") Or dblBedrag < 0 Or dblOorblyBedrag1 < 0 Then
                            dblPakketitem1AP = readerMD("pakketitem1") * -1
                        Else
                            dblPakketitem1AP = readerMD("pakketitem1")
                        End If
                    Else
                        If dblOorblyBedrag1 < 0 Then
                            dblMotorsAP = dblOorblyBedrag * -1
                        Else
                            dblMotorsAP = dblOorblyBedrag
                        End If
                        Exit Sub
                    End If
                    'pakketitem2
                    If dblOorblyBedrag >= readerMD("pakketitem2") Then
                        dblOorblyBedrag = dblOorblyBedrag - readerMD("pakketitem2")

                        If (UCase(strLopieTipe) = "VT LOPIE" Or UCase(strLopieTipe) = "TB LOPIE" Or UCase(strLopieTipe) = "UITGELOOPTEPREMIES") Or dblBedrag < 0 Or dblOorblyBedrag1 < 0 Then
                            dblPakketitem2AP = readerMD("pakketitem2") * -1
                        Else
                            dblPakketitem2AP = readerMD("pakketitem2")
                        End If
                    Else
                        If dblOorblyBedrag1 < 0 Then
                            dblMotorsAP = dblOorblyBedrag * -1
                        Else
                            dblMotorsAP = dblOorblyBedrag
                        End If
                        Exit Sub
                    End If
                    'pakketitem3
                    If dblOorblyBedrag >= readerMD("pakketitem3") Then
                        dblOorblyBedrag = dblOorblyBedrag - readerMD("pakketitem3")

                        If (UCase(strLopieTipe) = "VT LOPIE" Or UCase(strLopieTipe) = "TB LOPIE" Or UCase(strLopieTipe) = "UITGELOOPTEPREMIES") Or dblBedrag < 0 Or dblOorblyBedrag1 < 0 Then
                            dblPakketitem3AP = readerMD("pakketitem3") * -1
                        Else
                            dblPakketitem3AP = readerMD("pakketitem3")
                        End If
                    Else
                        If dblOorblyBedrag1 < 0 Then
                            dblMotorsAP = dblOorblyBedrag * -1
                        Else
                            dblMotorsAP = dblOorblyBedrag
                        End If
                        Exit Sub
                    End If
                    'pakketitem4
                    If dblOorblyBedrag >= readerMD("pakketitem4") Then
                        dblOorblyBedrag = dblOorblyBedrag - readerMD("pakketitem4")

                        If (UCase(strLopieTipe) = "VT LOPIE" Or UCase(strLopieTipe) = "TB LOPIE" Or UCase(strLopieTipe) = "UITGELOOPTEPREMIES") Or dblBedrag < 0 Or dblOorblyBedrag1 < 0 Then
                            dblPakketitem4AP = readerMD("pakketitem4") * -1
                        Else
                            dblPakketitem4AP = readerMD("pakketitem4")
                        End If
                    Else
                        If dblOorblyBedrag1 < 0 Then
                            dblMotorsAP = dblOorblyBedrag * -1
                        Else
                            dblMotorsAP = dblOorblyBedrag
                        End If
                        Exit Sub
                    End If
                    'polisfooi
                    If dblOorblyBedrag >= readerMD("polfooi") Then
                        dblOorblyBedrag = dblOorblyBedrag - readerMD("polfooi")

                        If (UCase(strLopieTipe) = "VT LOPIE" Or UCase(strLopieTipe) = "TB LOPIE" Or UCase(strLopieTipe) = "UITGELOOPTEPREMIES") Or dblBedrag < 0 Or dblOorblyBedrag1 < 0 Then
                            dblPolisfooiAP = readerMD("polfooi") * -1
                        Else
                            dblPolisfooiAP = readerMD("polfooi")
                        End If
                    Else
                        If dblOorblyBedrag1 < 0 Then
                            dblMotorsAP = dblOorblyBedrag * -1
                        Else
                            dblMotorsAP = dblOorblyBedrag
                        End If
                        Exit Sub
                    End If

                    'die res van die geld moet persentasiegewys bo die lyn aangepas word
                    'Bereken die individuele persentasies volgens premies uit stats5d verkry
                    dblIndivMTTotaal = 0
                    dblIndivWLTotaal = 0
                    dblIndivARTotaal = 0
                    dblIndivHEGewTotaal = 0
                    dblIndivHBGewTotaal = 0
                    dblIndivHEGrasTotaal = 0
                    dblIndivHBGrasTotaal = 0
                    dblIndivEEMTotaal = 0
                    dblIndivToeTotaal = 0

                    If strPolisno = "7773004461" Or strPolisno = "7773005545" Or strPolisno = "7773008893" Or strPolisno = "7773019151" Or strPolisno = "7773037596" Or strPolisno = "7773040927" Then
                        strPolisno = strPolisno
                    End If
                    'Bereken individuele persentasies soos uit stats5d verkry
                    'Kry motors en waterlewe totaal
                    If readerMD("Tempfield") = "stats5d" Then
                        Dim arMT()
                        Dim arMTipe()
                        arMT = Split(IIf(readerMD("mpremie") Is DBNull.Value, 0, readerMD("mpremie")), Chr(10) & Chr(13))
                        arMTipe = Split(IIf(readerMD("tipevoert") Is DBNull.Value, 0, readerMD("tipevoert")), Chr(10) & Chr(13))
                        For i = 0 To UBound(arMT) - 1
                            If arMTipe(i) = "8" Then
                                dblIndivWLTotaal = dblIndivWLTotaal + CDbl(arMT(i))
                            Else
                                dblIndivMTTotaal = dblIndivMTTotaal + CDbl(arMT(i))
                            End If
                        Next

                        'Alle risiko
                        Try
                            Using connMDAR As SqlConnection = SqlHelper.GetConnection
                                Dim paramMDAR() As SqlParameter = {New SqlParameter("@afsluitdat", SqlDbType.Date), _
                                                                 New SqlParameter("@afsluitdat2", SqlDbType.Date), _
                                                                 New SqlParameter("@afsluitdat3", SqlDbType.Date), _
                                                                New SqlParameter("@polisno", SqlDbType.NVarChar)}

                                paramMDAR(0).Value = Me.dtpPreviousFinalRun.Value
                                If Me.dtpSalary1.Enabled = True Then
                                    paramMDAR(1).Value = Me.dtpSalary1.Value
                                Else
                                    paramMDAR(1).Value = Me.dtpPreviousFinalRun.Value
                                End If
                                If Me.dtpSalary2.Enabled = True Then
                                    paramMDAR(2).Value = Me.dtpSalary2.Value
                                Else
                                    paramMDAR(2).Value = Me.dtpPreviousFinalRun.Value
                                End If
                                paramMDAR(3).Value = strPolisno

                                Dim readerMDAR As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5d.FetchMDPrintAlle", paramMDAR)

                                Do While readerMDAR.Read
                                    dblIndivARTotaal = dblIndivARTotaal + readerMDAR("premie")
                                Loop

                                If connMDAR.State = ConnectionState.Open Then
                                    connMDAR.Close()
                                End If
                            End Using
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                        End Try

                        'kry hb en he totale
                        Dim intHuispremieBegin As Integer = 1
                        Dim intHuispremieEinde As Integer = 1
                        Dim intHuisTipedakbegin As Integer = 1  '6 = grasdak
                        Dim intHuisTipedakEinde As Integer = 1  '6 = grasdak
                        Dim intHuisHEHBBegin As Integer = 1
                        Dim strHuistipeDak As String = ""
                        Dim intHuisHEHBEinde As Integer = 1
                        Dim strHuisHEHB As String = ""

                        Dim arHuisPremie()
                        Dim arHuisTipeDak()
                        Dim arHuisHEHB()
                        arHuisPremie = Split(IIf(readerMD("huispremie") Is DBNull.Value, 0, readerMD("huispremie")), Chr(10) & Chr(13))
                        arHuisTipeDak = Split(IIf(readerMD("tipe_dak") Is DBNull.Value, 0, readerMD("tipe_dak")), Chr(10) & Chr(13))
                        arHuisHEHB = Split(IIf(readerMD("hehb") Is DBNull.Value, 0, readerMD("hehb")), Chr(10) & Chr(13))
                        For i = 0 To UBound(arHuisPremie) - 1
                            If arHuisTipeDak(i) = "6" Then
                                If arHuisHEHB(i) = "HE" Then
                                    dblIndivHEGrasTotaal = dblIndivHEGrasTotaal + CDbl(arHuisPremie(i))
                                Else
                                    dblIndivHBGrasTotaal = dblIndivHBGrasTotaal + CDbl(arHuisPremie(i))
                                End If
                            Else
                                If arHuisHEHB(i) = "HE" Then
                                    dblIndivHEGewTotaal = dblIndivHEGewTotaal + CDbl(arHuisPremie(i))
                                Else
                                    dblIndivHBGewTotaal = dblIndivHBGewTotaal + CDbl(arHuisPremie(i))
                                End If
                            End If
                        Next

                        'kry toevallige skade eem en toe totaal
                        dblIndivEEMTotaal = IIf(readerMD("eem_Premie") Is DBNull.Value, 0, readerMD("eem_Premie"))
                        dblIndivToeTotaal = IIf(readerMD("toe_premie") Is DBNull.Value, 0, readerMD("toe_premie"))
                    Else
                        dblIndivMTTotaal = readerMD("motor_sub")
                        dblIndivARTotaal = readerMD("alle_sub")
                        dblIndivHBGewTotaal = readerMD("huis_sub")
                    End If

                    dblSubtotaal = dblIndivMTTotaal + dblIndivWLTotaal + dblIndivARTotaal + dblIndivHEGewTotaal + dblIndivHBGewTotaal + dblIndivHEGrasTotaal + dblIndivHBGrasTotaal + dblIndivEEMTotaal + dblIndivToeTotaal

                    dblEispers = readerMD("eispers")
                    dblIndivSubt = dblSubtotaal * dblEispers

                    If dblIndivSubt = 0 Then
                        dblIndivMTPers = 0
                        dblIndivARPers = 0
                        dblIndivHBGewPers = 0
                        dblIndivHEGewPers = 0
                        dblIndivHBGrasPers = 0
                        dblIndivHEGrasPers = 0
                        dblIndivEEMPers = 0
                        dblIndivToePers = 0
                        dblIndivWLPers = 0
                    Else
                        'die klas persentasies word as volg uitgewerk: ((klas * eispers)/premie2) * (bedrag om te verdeel - onder die lyn)
                        'as die bedrag negatief was moet die klasse bedrae ook negatief wees
                        Dim blnKlasNegatief As Boolean
                        If dblOorblyBedrag1 < 0 Then
                            blnKlasNegatief = True
                        Else
                            blnKlasNegatief = False
                        End If

                        'Motors
                        If dblOorblyBedrag = 0 Then
                            dblIndivMTPers = 0
                        Else
                            dblIndivMTPers = (dblIndivMTTotaal * dblEispers) / dblIndivSubt
                        End If
                        dblBedrag = dblOorblyBedrag * dblIndivMTPers
                        If (UCase(strLopieTipe) = "VT LOPIE" Or UCase(strLopieTipe) = "TB LOPIE" Or UCase(strLopieTipe) = "UITGELOOPTEPREMIES") Or blnKlasNegatief = True Then
                            dblMotorsAP = dblBedrag * -1
                        Else
                            dblMotorsAP = dblBedrag
                        End If

                        'Alle Risiko
                        If dblOorblyBedrag = 0 Then
                            dblIndivARPers = 0
                        Else
                            dblIndivARPers = (dblIndivARTotaal * dblEispers) / dblIndivSubt
                        End If
                        dblBedrag = dblOorblyBedrag * dblIndivARPers
                        If (UCase(strLopieTipe) = "VT LOPIE" Or UCase(strLopieTipe) = "TB LOPIE" Or UCase(strLopieTipe) = "UITGELOOPTEPREMIES") Or blnKlasNegatief = True Then
                            dblAlleRisikoAP = dblBedrag * -1
                        Else
                            dblAlleRisikoAP = dblBedrag
                        End If

                        'HB Gewoon
                        If dblOorblyBedrag = 0 Then
                            dblIndivHBGewPers = 0
                        Else
                            dblIndivHBGewPers = (dblIndivHBGewTotaal * dblEispers) / dblIndivSubt
                        End If
                        dblBedrag = dblOorblyBedrag * dblIndivHBGewPers
                        If (UCase(strLopieTipe) = "VT LOPIE" Or UCase(strLopieTipe) = "TB LOPIE" Or UCase(strLopieTipe) = "UITGELOOPTEPREMIES") Or blnKlasNegatief = True Then
                            dblHBAP = dblBedrag * -1
                        Else
                            dblHBAP = dblBedrag
                        End If

                        'HE Gewoon
                        If dblOorblyBedrag = 0 Then
                            dblIndivHEGewPers = 0
                        Else
                            dblIndivHEGewPers = (dblIndivHEGewTotaal * dblEispers) / dblIndivSubt
                        End If
                        dblBedrag = dblOorblyBedrag * dblIndivHEGewPers
                        If (UCase(strLopieTipe) = "VT LOPIE" Or UCase(strLopieTipe) = "TB LOPIE" Or UCase(strLopieTipe) = "UITGELOOPTEPREMIES") Or blnKlasNegatief = True Then
                            dblHEAP = dblBedrag * -1
                        Else
                            dblHEAP = dblBedrag
                        End If

                        'HB gras
                        If dblOorblyBedrag = 0 Then
                            dblIndivHBGrasPers = 0
                        Else
                            dblIndivHBGrasPers = (dblIndivHBGrasTotaal * dblEispers) / dblIndivSubt
                        End If
                        dblBedrag = dblOorblyBedrag * dblIndivHBGrasPers
                        If (UCase(strLopieTipe) = "VT LOPIE" Or UCase(strLopieTipe) = "TB LOPIE" Or UCase(strLopieTipe) = "UITGELOOPTEPREMIES") Or blnKlasNegatief = True Then
                            dblHBGrasAP = dblBedrag * -1
                        Else
                            dblHBGrasAP = dblBedrag
                        End If

                        'HE gras
                        If dblOorblyBedrag = 0 Then
                            dblIndivHEGrasPers = 0
                        Else
                            dblIndivHEGrasPers = (dblIndivHEGrasTotaal * dblEispers) / dblIndivSubt
                        End If
                        dblBedrag = dblOorblyBedrag * dblIndivHEGrasPers
                        If (UCase(strLopieTipe) = "VT LOPIE" Or UCase(strLopieTipe) = "TB LOPIE" Or UCase(strLopieTipe) = "UITGELOOPTEPREMIES") Or blnKlasNegatief = True Then
                            dblHEGrasAP = dblBedrag * -1
                        Else
                            dblHEGrasAP = dblBedrag
                        End If

                        'Toevallige skade (elektries)
                        If dblOorblyBedrag = 0 Then
                            dblIndivToePers = 0
                        Else
                            dblIndivToePers = (dblIndivToeTotaal * dblEispers) / dblIndivSubt
                        End If
                        dblBedrag = dblOorblyBedrag * dblIndivToePers
                        If (UCase(strLopieTipe) = "VT LOPIE" Or UCase(strLopieTipe) = "TB LOPIE" Or UCase(strLopieTipe) = "UITGELOOPTEPREMIES") Or blnKlasNegatief = True Then
                            dblToevalEEMAP = dblBedrag * -1
                        Else
                            dblToevalEEMAP = dblBedrag
                        End If

                        'Toevallige skade (breek)
                        If dblOorblyBedrag = 0 Then
                            dblIndivEEMPers = 0
                        Else
                            dblIndivEEMPers = (dblIndivEEMTotaal * dblEispers) / dblIndivSubt
                        End If
                        dblBedrag = dblOorblyBedrag * dblIndivEEMPers
                        If (UCase(strLopieTipe) = "VT LOPIE" Or UCase(strLopieTipe) = "TB LOPIE" Or UCase(strLopieTipe) = "UITGELOOPTEPREMIES") Or blnKlasNegatief = True Then
                            dblToevalEEMAP = dblBedrag * -1
                        Else
                            dblToevalEEMAP = dblBedrag
                        End If

                        'waterlewe
                        If dblOorblyBedrag = 0 Then
                            dblIndivWLPers = 0
                        Else
                            dblIndivWLPers = (dblIndivWLTotaal * dblEispers) / dblIndivSubt
                        End If
                        dblBedrag = dblOorblyBedrag * dblIndivWLPers
                        If (UCase(strLopieTipe) = "VT LOPIE" Or UCase(strLopieTipe) = "TB LOPIE" Or UCase(strLopieTipe) = "UITGELOOPTEPREMIES") Or blnKlasNegatief = True Then
                            dblWaterleweAP = dblBedrag * -1
                        Else
                            dblWaterleweAP = dblBedrag
                        End If
                    End If

                End If

                If connMD.State = ConnectionState.Open Then
                    connMD.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    '*Purpose:  Get the spesiale korting adjustment amount for this transaction
    '*          It considers all the transactions for this policy e.g if there was a vt, the special discount will be subtracted from the original verwagte amount
    '*          If this client pays the vt, the special discount will be added back to the verwagte premie
    '*          If this client pays only part of this vt, the special discount will also be added to the verwagte premie
    '*          If the client makes two or more payment transactions, the special discount will be added only once to the verwagte premie
    Private Function GetSpesialeKorting(dblSpesialeKorting As Decimal, strPolisno As String, dblPremie2 As Decimal) As Decimal
        Dim intArrayIndex As Integer

        GetSpesialeKorting = 0

        'Add this policy to the status array if it was not added before
        'It is stored in an array arPaid(i,j) where i = policy number, j = paid status (Each transaction affects this array)
        AddPolicyToArray(strPolisno, intArrayIndex)

        Diagnostics.Debug.WriteLine("getspesialekorting")

        Select Case strLopieTipe
            Case "rekonlopie"
                If strBetaalwyseKommissie = "MK" Or strBetaalwyseKommissie = "ME" Then
                    If dblBedrag = dblPremie2 Then
                        If arPaid(1, intArrayIndex) Then    'paid
                            GetSpesialeKorting = dblSpesialeKortingAP
                            arPaid(1, intArrayIndex) = False
                        Else
                            GetSpesialeKorting = 0
                        End If
                    Else
                        GetSpesialeKorting = 0
                    End If
                Else
                    If arPaid(1, intArrayIndex) Then 'paid
                        GetSpesialeKorting = 0
                    Else
                        'store the paid status for this policy
                        arPaid(1, intArrayIndex) = True
                        GetSpesialeKorting = dblSpesialeKortingAP * -1
                    End If
                End If
            Case "mdlopie", "mklopie", "melopie", "mslopie", "vtinlopie"
                If arPaid(1, intArrayIndex) Then 'paid
                    GetSpesialeKorting = 0
                Else
                    'store the paid status for this policy
                    arPaid(1, intArrayIndex) = True
                    GetSpesialeKorting = dblSpesialeKortingAP * -1
                End If
            Case "vtlopie"
                If arPaid(1, intArrayIndex) Then 'paid                    
                    arPaid(1, intArrayIndex) = False
                    GetSpesialeKorting = dblSpesialeKortingAP
                Else
                    GetSpesialeKorting = 0
                End If
            Case "eblopie"
                arPaid(1, intArrayIndex) = True
                GetSpesialeKorting = dblSpesialeKortingAP * -1
            Case "tblopie"
                If dblBedrag < dblPremie2 Then
                    GetSpesialeKorting = 0
                Else
                    If arPaid(1, intArrayIndex) Then    'paid
                        GetSpesialeKorting = dblSpesialeKortingAP
                        arPaid(1, intArrayIndex) = False
                    Else
                        GetSpesialeKorting = 0
                    End If
                End If

                'the spesiale korting will be part of the verwagte premie for the next month and cannot be added this month
            Case "vblopie"
                arPaid(1, intArrayIndex) = True
                GetSpesialeKorting = 0
        End Select

        Return GetSpesialeKorting
    End Function
    '*Purpose:  Store the policy and paid status in an array arPaid if it has not been stored before Paid status in dimension 1 policy number in dimension 2
    '* ex 0,0 Policy A
    '* 0,1 Policy B
    '* 1,0 True/False for A
    '* 1,1 True/False for B
    Private Sub AddPolicyToArray(strPolisno As String, intArrayIndex As Integer)
        'First policy
        If arPaid(0, 0) = "" Then
            arPaid(0, 0) = strPolisno
            arPaid(1, 0) = True
            intArrayIndex = 0
        Else
            'subsequent policies
            'if policy exists already do not add it to array
            If Not blnPolisExistInArray(strPolisno, intArrayIndex) Then
                ReDim Preserve arPaid(2, UBound(arPaid, 2) + 1) 'uppder bound second dimension + 1
                arPaid(0, UBound(arPaid, 2) - 1) = strPolisno
                arPaid(1, UBound(arPaid, 2) - 1) = True
            End If
        End If
    End Sub
    '*purpose:  Check if this policy number exists in the paid array
    Private Function blnPolisExistInArray(strPolisno As String, i As Integer) As Boolean

        blnPolisExistInArray = False

        For i = 0 To UBound(arPaid, 2) - 1
            If arPaid(0, i) = strPolisno Then
                blnPolisExistInArray = True
                Exit For
            End If
        Next
    End Function
    Private Sub UpdateHollardOorbetalings(strBetWyse As String, intArea As Integer, intMakelaar As Integer)
        Dim dblToevalSkade As Decimal
        'sum kontantrekonhollard
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@afsluitdat", SqlDbType.Date), _
                                                 New SqlParameter("@Betaalwyse", SqlDbType.NVarChar), _
                                                 New SqlParameter("@area", SqlDbType.Int), _
                                               New SqlParameter("@fkMakelaar", SqlDbType.Int), _
                                                New SqlParameter("@fkVersekeraar", SqlDbType.Int)}

                If strBetWyse = "MS" Then
                    If strTak = "Flagship" And intArea = 2 Then
                        param(0).Value = Me.dtpSalary1.Value
                    ElseIf strTak = "Bloemfontein" And intArea = 2 Then
                        param(0).Value = Me.dtpSalary1.Value
                    ElseIf strTak = "Bloemfontein" And intArea = 3 Then
                        param(0).Value = Me.dtpSalary2.Value
                    Else
                        param(0).Value = Me.dtpPreviousFinalRun.Value
                    End If
                Else
                    param(0).Value = Me.dtpPreviousFinalRun.Value
                End If
                param(1).Value = strBetWyse
                param(2).Value = intArea
                param(3).Value = intMakelaar
                param(4).Value = intfkVersekeraar

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchSumKontantRekonHollard", param)

                If reader.Read Then
                    'skryf na hollardoorbetalings
                    Try
                        Using connHollard As SqlConnection = SqlHelper.GetConnection
                            Dim paramHollard() As SqlParameter = {New SqlParameter("@fkversekeraar", SqlDbType.Int), _
                                                            New SqlParameter("@fkmakelaar", SqlDbType.Int), _
                                                            New SqlParameter("@area", SqlDbType.NVarChar), _
                                                            New SqlParameter("@Betaalwyse", SqlDbType.NVarChar), _
                                                            New SqlParameter("@Jaar", SqlDbType.Int), _
                                                            New SqlParameter("@maand", SqlDbType.Int), _
                                                            New SqlParameter("@MTPrem", SqlDbType.Money), _
                                                            New SqlParameter("@ARPrem", SqlDbType.Money), _
                                                            New SqlParameter("@HBGewPrem", SqlDbType.Money), _
                                                            New SqlParameter("@HEGewPrem", SqlDbType.Money), _
                                                            New SqlParameter("@HBGrasPrem", SqlDbType.Money), _
                                                            New SqlParameter("@HEGrasPrem", SqlDbType.Money), _
                                                            New SqlParameter("@WLPrem", SqlDbType.Money), _
                                                            New SqlParameter("@SasriaPrem", SqlDbType.Money), _
                                                            New SqlParameter("@TSprem", SqlDbType.Money), _
                                                            New SqlParameter("@Plipprem", SqlDbType.Money), _
                                                            New SqlParameter("@CareAssistPrem", SqlDbType.Money), _
                                                            New SqlParameter("@InsurecellPrem", SqlDbType.Money), _
                                                            New SqlParameter("@SafricanPrem", SqlDbType.Money), _
                                                            New SqlParameter("@MediesPrem", SqlDbType.Money), _
                                                            New SqlParameter("@TVDiensPrem", SqlDbType.Money), _
                                                            New SqlParameter("@BeskermingPrem", SqlDbType.Money), _
                                                            New SqlParameter("@GeleentheidsmotorPrem", SqlDbType.Money), _
                                                            New SqlParameter("@AdministrasiefooiPrem", SqlDbType.Money), _
                                                            New SqlParameter("@EPCPrem", SqlDbType.Money), _
                                                            New SqlParameter("@Pakketitem1", SqlDbType.Money), _
                                                            New SqlParameter("@Pakketitem2", SqlDbType.Money), _
                                                            New SqlParameter("@Pakketitem3", SqlDbType.Money), _
                                                            New SqlParameter("@Pakketitem4", SqlDbType.Money), _
                                                            New SqlParameter("@SpesialeKortingPrem", SqlDbType.Money)}
                            Diagnostics.Debug.WriteLine("updatehollardoorbetalings")
                            paramHollard(0).Value = intfkVersekeraar
                            paramHollard(1).Value = intMakelaarfk
                            paramHollard(2).Value = strAreaBesk
                            paramHollard(3).Value = strBetWyse
                            paramHollard(4).Value = intJaar
                            paramHollard(5).Value = intMnd
                            paramHollard(6).Value = String.Format("{0:N2}", IIf(reader("motors") Is DBNull.Value, 0, reader("motors")))
                            paramHollard(7).Value = String.Format("{0:N2}", IIf(reader("ar") Is DBNull.Value, 0, reader("ar")))
                            paramHollard(8).Value = String.Format("{0:N2}", IIf(reader("hbgewoon") Is DBNull.Value, 0, reader("hbgewoon")))
                            paramHollard(9).Value = String.Format("{0:N2}", IIf(reader("hegewoon") Is DBNull.Value, 0, reader("hegewoon")))
                            paramHollard(10).Value = String.Format("{0:N2}", IIf(reader("hbgras") Is DBNull.Value, 0, reader("hbgras")))
                            paramHollard(11).Value = String.Format("{0:N2}", IIf(reader("hegras") Is DBNull.Value, 0, reader("hegras")))
                            paramHollard(12).Value = String.Format("{0:N2}", IIf(reader("waterlewe") Is DBNull.Value, 0, reader("waterlewe")))
                            paramHollard(13).Value = String.Format("{0:N2}", IIf(reader("sasria") Is DBNull.Value, 0, reader("sasria")))
                            dblToevalSkade = IIf(reader("tselektries") Is DBNull.Value, 0, reader("tselektries")) + IIf(reader("tsgewoon") Is DBNull.Value, 0, reader("tsgewoon"))
                            paramHollard(14).Value = String.Format("{0:N2}", (dblToevalSkade))
                            paramHollard(15).Value = String.Format("{0:N2}", IIf(reader("plip") Is DBNull.Value, 0, reader("plip")))
                            paramHollard(16).Value = String.Format("{0:N2}", IIf(reader("careassist") Is DBNull.Value, 0, reader("careassist")))
                            paramHollard(17).Value = String.Format("{0:N2}", IIf(reader("selfoon") Is DBNull.Value, 0, reader("selfoon")))
                            paramHollard(18).Value = String.Format("{0:N2}", IIf(reader("safrican") Is DBNull.Value, 0, reader("safrican")))
                            paramHollard(19).Value = String.Format("{0:N2}", IIf(reader("medies") Is DBNull.Value, 0, reader("medies")))
                            paramHollard(20).Value = String.Format("{0:N2}", IIf(reader("tvdiens") Is DBNull.Value, 0, reader("tvdiens")))
                            paramHollard(21).Value = String.Format("{0:N2}", IIf(reader("beskerming") Is DBNull.Value, 0, reader("beskerming")))
                            paramHollard(22).Value = String.Format("{0:N2}", IIf(reader("geleentheidsmotor") Is DBNull.Value, 0, reader("geleentheidsmotor")))
                            paramHollard(23).Value = String.Format("{0:N2}", IIf(reader("polisfooi") Is DBNull.Value, 0, reader("polisfooi")))
                            paramHollard(24).Value = String.Format("{0:N2}", IIf(reader("instandhoudingskontrak") Is DBNull.Value, 0, reader("instandhoudingskontrak")))
                            paramHollard(25).Value = String.Format("{0:N2}", IIf(reader("pakketitem1") Is DBNull.Value, 0, reader("pakketitem1")))
                            paramHollard(26).Value = String.Format("{0:N2}", IIf(reader("pakketitem2") Is DBNull.Value, 0, reader("pakketitem2")))
                            paramHollard(27).Value = String.Format("{0:N2}", IIf(reader("pakketitem3") Is DBNull.Value, 0, reader("pakketitem3")))
                            paramHollard(28).Value = String.Format("{0:N2}", IIf(reader("pakketitem4") Is DBNull.Value, 0, reader("pakketitem4")))
                            paramHollard(29).Value = String.Format("{0:N2}", IIf(reader("spesialekorting") Is DBNull.Value, 0, reader("spesialekorting")))

                            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.UpdateHollardOorbetalings", paramHollard)

                            If connHollard.State = ConnectionState.Open Then
                                connHollard.Close()
                            End If
                        End Using
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub WriteCLRSFile()
        Dim strFilePath As String
        Dim strFile As String
        Dim strAreasKontantRekon As String = ""
        Dim intLenAreasKontantrekon As Integer
        Dim strOutput As String = ""
        Diagnostics.Debug.WriteLine("writeclrsfile")
        Try
            Using connDistinctMakelaar As SqlConnection = SqlHelper.GetConnection
                Dim paramDistinctMakelaar() As SqlParameter = {New SqlParameter("@jaar", SqlDbType.Int), _
                                                                New SqlParameter("@maand", SqlDbType.Int), _
                                                                New SqlParameter("@fkversekeraar", SqlDbType.Int)}

                paramDistinctMakelaar(0).Value = intJaar
                paramDistinctMakelaar(1).Value = intMnd
                paramDistinctMakelaar(2).Value = Me.cmbInsurer.SelectedValue

                Dim readerDistinctMakelaar As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchDistinctMakelaarHOorbetalings", paramDistinctMakelaar)

                Do While readerDistinctMakelaar.Read
                    strFilePath = ""

                    Try
                        Using connArea As SqlConnection = SqlHelper.GetConnection
                            Dim paramArea() As SqlParameter = {New SqlParameter("@fkmakelaar", SqlDbType.Int), _
                                                                            New SqlParameter("@fkversekeraar", SqlDbType.Int)}

                            paramArea(0).Value = readerDistinctMakelaar("fkmakelaar")
                            paramArea(1).Value = Me.cmbInsurer.SelectedValue

                            Dim readerArea As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAreaPerMakelaarVersekeraar", paramArea)

                            If readerArea.Read Then
                                clsRun.gen_GetCLRSArea(readerArea("tak_afkorting"))

                                strFile = "C" & strCLRSArea & Format(Now, "ddhhmmss") & ".txt"
                                strFilePath = "c:\" & strFile
                                Dim objWriter As New System.IO.StreamWriter(strFile)

                                If (Not System.IO.File.Exists(strFilePath)) Then
                                    Try
                                        System.IO.File.Create(strFilePath)
                                    Catch ex As Exception
                                        MsgBox("CLRS file can not be created", vbInformation)
                                    End Try
                                End If
                                If System.IO.File.Exists(strFilePath) = True Then

                                    For i = 1 To 6
                                        Select Case i
                                            Case 1
                                                strBetwyse = "MK"
                                            Case 2
                                                strBetwyse = "JK"
                                            Case 3
                                                strBetwyse = "MS"
                                            Case 4
                                                strBetwyse = "MD"
                                            Case 5
                                                strBetwyse = "ME"
                                            Case 6
                                                strBetwyse = "LT"
                                        End Select

                                        If strTak = "Bloemfontein" Or strTak = "Klerksdorp" Or strTak = "Flagship" Then
                                            If readerArea("tak_afkorting") = "BFN" Or readerArea("tak_afkorting") = "KDP" Or readerArea("tak_afkorting") = "PCS" Then
                                                Try
                                                    Using connMakelaar As SqlConnection = SqlHelper.GetConnection
                                                        Dim paramMakelaar() As SqlParameter = {New SqlParameter("@tak_afkorting", SqlDbType.NVarChar), _
                                                                                                        New SqlParameter("@fkversekeraar", SqlDbType.Int)}

                                                        paramMakelaar(0).Value = readerArea("tak_afkorting")
                                                        paramMakelaar(1).Value = Me.cmbInsurer.SelectedValue

                                                        Dim readerMakelaar As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchMakelaarAreaTak_afkorting", paramMakelaar)

                                                        strAreasKontantRekon = ""

                                                        Do While readerMakelaar.Read
                                                            strAreasKontantRekon = strAreasKontantRekon & readerMakelaar("pkmakelaar")
                                                            strAreasKontantRekon = strAreasKontantRekon & ","
                                                        Loop

                                                        intLenAreasKontantrekon = Len(strAreasKontantRekon)
                                                        strAreasKontantRekon = strAreasKontantRekon.left(intLenAreasKontantrekon - 1)

                                                        If connMakelaar.State = ConnectionState.Open Then
                                                            connMakelaar.Close()
                                                        End If
                                                    End Using
                                                Catch ex As Exception
                                                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                                                End Try

                                            End If
                                        End If

                                        Try
                                            Using connSumPI1 As SqlConnection = SqlHelper.GetConnection
                                                Dim paramSumPI1() As SqlParameter = {New SqlParameter("@jaar", SqlDbType.Int), _
                                                                                    New SqlParameter("@maand", SqlDbType.Int), _
                                                                                    New SqlParameter("@betaalwyse", SqlDbType.NVarChar), _
                                                                                    New SqlParameter("@fkversekeraar", SqlDbType.Int), _
                                                                                     New SqlParameter("@fkmakelaar", SqlDbType.NVarChar)}

                                                paramSumPI1(0).Value = intJaar
                                                paramSumPI1(1).Value = intMnd
                                                paramSumPI1(2).Value = strBetwyse
                                                paramSumPI1(3).Value = Me.cmbInsurer.SelectedValue
                                                paramSumPI1(4).Value = strAreasKontantRekon

                                                Dim readerSumPI1 As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchSumPakketitem1HOorbetalings", paramSumPI1)

                                                If readerSumPI1.Read Then
                                                    If (readerSumPI1("causa") Is DBNull.Value = False) Then
                                                        strOutput = intJaar & "|"
                                                        strOutput = strOutput & intMnd & "|"
                                                        strOutput = strOutput & readerSumPI1("causa") & "|"
                                                        strOutput = strOutput & strCLRSArea & "|"
                                                        strOutput = strOutput & i

                                                        objWriter.WriteLine(strOutput)
                                                    End If
                                                End If

                                                If connSumPI1.State = ConnectionState.Open Then
                                                    connSumPI1.Close()
                                                End If
                                            End Using
                                        Catch ex As Exception
                                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                                        End Try

                                    Next
                                    objWriter.Close()
                                End If
                                clsRun.gen_GetCLRSArea(readerArea("tak_afkorting"))

                                'email moet nog inkom
                            End If

                            If connArea.State = ConnectionState.Open Then
                                connArea.Close()
                            End If
                        End Using
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try

                Loop

                If connDistinctMakelaar.State = ConnectionState.Open Then
                    connDistinctMakelaar.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

End Class

