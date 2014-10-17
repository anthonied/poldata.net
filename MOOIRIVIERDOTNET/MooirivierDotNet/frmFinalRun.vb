'********************************************************************
'Linkie 10/06/2013
'Form to handle the final run that was on stats and multistats
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
Imports System.Security.AccessControl

Public Class frmFinalRun
    Dim intSalaryArea As Integer
    Dim blnFinalRunValidated As Boolean
    Dim dteMaxBetaalDateAllowed As Date
    Dim intJaar As Integer
    Dim intMaand As Integer
    Dim dteExpPremium As Date
    Dim blnCheckBetDat As Boolean = True
    Dim strBet_wyse As String
    Dim strPolisno As String
    Dim strArea As String
    Dim dblPremie2 As Decimal
    Dim strTak As String
    Dim strVoorl As String
    Dim strVersekerde As String
    Dim dblEispers As Double
    Dim strBemarker As String
    Dim dblCareAssist As Decimal
    Dim strAdres2 As String
    Dim strAdres3 As String
    Dim dblSubTotaal As Decimal
    Dim dblTV_Diens As Decimal
    Dim dblBegrafnis As Decimal
    Dim dblSasPrem As Decimal
    Dim dblPremie As Decimal
    Dim dblPolFooi As Decimal
    Dim dblBeskerm As Decimal
    Dim dblPlip1 As Decimal
    Dim dteP_A_dat As Date
    Dim dblPakketitem1 As Decimal
    Dim dblPakketitem2 As Decimal
    Dim dblPakketitem3 As Decimal
    Dim dblPakketitem4 As Decimal
    Dim dblVerwysKommissie As Decimal
    Dim dblCourtesyV As Decimal
    Dim dblSelfoon As Decimal
    Dim dblEPC As Decimal
    Dim dblHuis_sub As Decimal
    Dim dblMotor_sub As Decimal
    Dim dblAlle_sub As Decimal
    Dim strIdNom As String
    Dim strBybet_k As String
    Dim strBetaalwyse As String
    Dim blnTaal As Boolean
    Dim strHuistipe As String
    Dim strHuisadres As String
    Dim strHuisPoskode As String
    Dim strHuisDekking As String
    Dim strHuisPremie As String
    Dim strTipeDak As String
    Dim strStruktuur As String
    Dim strA_Goedgekeur As String
    Dim strItemnr As String
    Dim strHeHb As String
    Dim strHuissekuriteit As String
    Dim strHuissekuriteitBitValueMemo As String
    Dim strHuisHoofeiendom As String
    Dim strHuisEiendomTipe As String
    Dim strHuisLapa As String
    Dim strHuisVerband As String
    Dim intCtrHE As Integer
    Dim intCtrHB As Integer
    Dim intCtrVoertuie As Integer
    Dim intCtrAR As Integer
    Dim strMMKode As String
    Dim strTipeVoert As String
    Dim strVoertJaar As String
    Dim strVoertEeu As String
    Dim strVoertKleur As String
    Dim strVoertpkVoertuie As String
    Dim strVoertWaardetipe As String
    Dim strVoertAreaBeskrywing As String
    Dim strVoertMotorhuis As String
    Dim strVoertPoskode As String
    Dim strVoertIngevoer As String
    Dim strVoertHuurkoop As String
    Dim strVoertLaeProfielbande As String
    Dim blnVoertuie As Boolean
    Dim strBesk As String
    Dim strJaar As String
    Dim strEeu As String
    Dim strReg As String
    Dim strWaarde As String
    Dim strMPremie As String
    Dim strMotorsek As String
    Dim strMotorsekuriteitbitvaluememo As String
    Dim strTipe As String
    Dim strGebruik As String
    Dim strARBeskryf As String
    Dim dblARDekking As Decimal
    Dim dblARPremie As Decimal
    Dim strARItemNr As String
    Dim strARTipe2 As String
    Dim strARArnPlaat As String
    Dim dblAddisionelePremie As Decimal
    Dim strPersnom As String
    Dim intStoorMaand1 As Integer
    Dim intStoorMaand2 As Integer
    Dim dteDatumBeginMinusEenMaand As Date
    Dim dteDatumEindigMinusEenMaand As Date
    Dim dteExpPremiumPlusMonth As Date
    Dim GroupTotal(55) As Decimal
    Dim GrandTotal(55) As Decimal
    Dim GroupTotNa(55) As Decimal
    Dim sumNegPremium As Decimal
    Dim polCount(8) As Integer
    Dim itemCount(20) As Integer
    Dim tmpAreaCode As String
    Dim l As Integer
    Dim strPaymentMethod As String
    Dim intI As Integer
    Dim intSalArea As Integer
    Dim serverPath As String
    Const strHeader As String = "##DIS"
    Const strCompanyNumber As String = "127811"
    Const strTransactionCode As String = "400"
    Const strTypeofPayment As String = "21"
    Const strReference As String = ""
    Dim strDebitOrderOutputFileName As String
    Dim strCollectiondate As String
    Dim strMultidataPath As String
    Dim strDebitOrderDataPath As String
    Dim entBankCodes = New BankCodes()
    Dim strOutputDOProc As String
    Dim strOutputDOProcKT As String
    Dim cnstFileName As String
    Dim introw As Integer = 1
    Dim entPersoonl As New PERSOONLEntity
    Dim entTitle As New TitleEntity
    Dim xlApp As Excel.Application
    Dim xlBook As Excel.Workbook = Nothing
    Dim xlSheet As Excel.Worksheet = Nothing
    Dim clsRun As New clsRuns()
    Dim strTitel As String
    Dim blnPersnoMissing As Boolean = False
    Dim strCLRSPath As String = ""

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click

        Dim strPath As String = ""
        Dim entTakEntity As New TakEntity
        Dim strTak_afkorting As String = ""

        Diagnostics.Debug.WriteLine("Begin" & Now)
        CheckBetDat()

        If blnCheckBetDat = False Then
            Me.Close()
            Exit Sub
        End If

        FinalRunValidate()

        If blnFinalRunValidated = True Then
            Cursor.Current = Cursors.WaitCursor
            Me.btnOk.Enabled = False
            Me.btnCancel.Enabled = False

            lblProcessing.Text = "Validated"
            lblProcessing.Refresh()

            glbVersekeraar = cmbInsurer.SelectedValue

            If Me.optGeneral.Checked Then
                If Me.optTestRunGeneral.Checked = False Then
                    lblProcessing.Text = "Database backup"
                    lblProcessing.Refresh()

                    'backup database
                    strPath = clsRun.gen_getServerPath & "MM Backup"
                    If Dir(strPath, vbDirectory) = "" Then MkDir(strPath)

                    entTakEntity = clsRun.GetTak
                    strTak_afkorting = entTakEntity.Tak_afkorting

                    strPath = strPath & "\" & strTak_afkorting & "_FinalRunBefore.bak"
                    If Gebruiker.titel = "Programmeerder" Then
                        If Me.chkDatabaseBackup.Checked = True Then
                            clsRun.BackupMooirivierDatabase(strPath)
                        End If
                    Else
                        clsRun.BackupMooirivierDatabase(strPath)
                    End If
                End If

                clsRun.UpdateGebrukerLopiesRuns("Finale lopie Algemeen - " & Me.cmbInsurer.Text, Me.dtpExpectedPremium.Text)
            ElseIf Me.optSalary.Checked Then
                If Me.optTestRun.Checked = False Then
                    lblProcessing.Text = "Database backup"
                    lblProcessing.Refresh()

                    'backup database
                    strPath = clsRun.gen_getServerPath & "MM Backup"
                    If Dir(strPath, vbDirectory) = "" Then MkDir(strPath)
                    entTakEntity = clsRun.GetTak
                    strTak_afkorting = entTakEntity.Tak_afkorting

                    strPath = strPath & "\" & strTak_afkorting & "_FinalRunBefore_Salary_" & Me.cmbArea.Text & ".bak"
                    If Gebruiker.titel = "Programmeerder" Then
                        If Me.chkDatabaseBackup.Checked = True Then
                            clsRun.BackupMooirivierDatabase(strPath)
                        End If
                    Else
                        clsRun.BackupMooirivierDatabase(strPath)
                    End If
                End If

                clsRun.UpdateGebrukerLopiesRuns("Finale lopie Salaris - " & Me.cmbInsurer.Text & " - " & Me.cmbArea.Text, Me.dtpExpectedPremiumSalary.Text)
            End If

            If Me.optGeneral.Checked Then
                dteMaxBetaalDateAllowed = dtpExpectedPremium.Value.AddMonths(1).AddDays(-dtpExpectedPremium.Value().Day + 1)
                'intStoormaand is afsluitingsdatum se maand plus een maand om te bepaal wanneer die rekords gestoor word.
                intStoorMaand1 = Month(Me.dtpExpectedPremium.Value.AddMonths(1))
                intStoorMaand2 = Month(Me.dtpExpectedPremium.Value.AddMonths(2))

                'Lees persoonl - kry alle aktiewe MD
                dteExpPremium = Me.dtpExpectedPremium.Value
                dteExpPremiumPlusMonth = Me.dtpExpectedPremium.Value.AddMonths(1)
                intJaar = Year(dteExpPremiumPlusMonth)
                intMaand = Month(dteExpPremiumPlusMonth)

                serverPath = clsRun.gen_getAdminPath()
                serverPath = serverPath & "Month ends\" & Format(dteExpPremiumPlusMonth, "yyyy") & "\" & Format(dteExpPremiumPlusMonth, "MM_yyyy") & "\Final run"
                strCLRSPath = serverPath

                If Dir(serverPath, vbDirectory) = "" Then MkDir(serverPath)

                If Me.chkDebitorderProcessing.Checked = True Then
                    Me.lblProcessing.Text = "Writing Debitorder file"
                    Me.lblProcessing.Refresh()

                    strMultidataPath = serverPath
                    DebitOrderProcessing()
                    If optTestRunGeneral.Checked = True Then
                        Me.lblProcessing.Text = "Test run complete"
                        Me.lblProcessing.Refresh()

                        MsgBox("Test run completed", vbInformation)

                        Me.btnCancel.Enabled = True
                        Exit Sub
                    End If
                End If
                If Me.chkFinalRun.Checked = True Then
                    Diagnostics.Debug.WriteLine("insertmdafsluitdat begin" & Now)
                    'stoor afsluitdatum
                    InsertMDAfsluitdat()

                    Diagnostics.Debug.WriteLine("readpersoonlbetwyse begin" & Now)
                    ReadPersoonlBetWyse()

                    lblProcessing.Text = "Finished with final run"
                    lblProcessing.Refresh()

                    If Me.chkReportsFinalRunSummary.Checked = True Then

                    End If
                    If Me.chkReportsFinalRunDetail.Checked = True Then

                    End If
                    If Me.chkReportsFinalRunConsolidated.Checked = True Then

                    End If
                End If

                If Me.chkFinalRunTermPolicies.Checked = True Then
                    If Me.chkReportsFinalRunTermSummary.Checked = True Then

                    End If
                    If Me.chkReportsFinalRunTermDetail.Checked = True Then

                    End If
                    If Me.chkReportsFinalRunTermConsolidated.Checked = True Then

                    End If
                    If Me.chkTermRunOutPremium.Checked = True Then

                    End If
                    If Me.chkTermRunOutPremium2Months.Checked = True Then

                    End If
                    If Me.chkTermFinished2Months.Checked = True Then

                    End If
                    If Me.chkTermFinished.Checked = True Then

                    End If
                End If

                If Me.dtpExpectedPremium.Checked = True Then
                    If Me.chkExpectedPremiumGeneral.Checked = True Then
                        Diagnostics.Debug.WriteLine("writerekon4 begin" & Now)
                        WriteRekon(4)
                        RunPlip(4)

                        lblProcessing.Text = "Finished with Monthly debit Expected premium run"
                        lblProcessing.Refresh()

                        Diagnostics.Debug.WriteLine("writerekon1 begin" & Now)
                        WriteRekon(1)
                        RunPlip(1)
                        lblProcessing.Text = "Finished with Monthly cash Expected premium run"
                        lblProcessing.Refresh()

                        Diagnostics.Debug.WriteLine("writerekon5 begin" & Now)
                        WriteRekon(5)
                        RunPlip(5)
                        lblProcessing.Text = "Finished with Monthly electronic Expected premium run"
                        lblProcessing.Refresh()
                    End If
                    If Me.chkExpectedPremiumTermPolicies.Checked = True Then
                        Diagnostics.Debug.WriteLine("writerekon6 begin" & Now)
                        WriteRekon(6)
                        RunPlip(6)
                        lblProcessing.Text = "Finished with Term Expected premium run"
                        lblProcessing.Refresh()
                    End If
                    Diagnostics.Debug.WriteLine("care 5 begin" & Now)
                    RunCare(7, 5)
                    Diagnostics.Debug.WriteLine("care 10 begin" & Now)
                    RunCare(7, 10)
                    RunHomeAssist(7)
                End If

                If Me.chkCompareSummaryFinalRunExpectedPrem.Checked = True Then

                End If
                If Me.chkCompleteReconciliationForm.Checked = True Then

                End If
                If Me.chkRestoreAdditionalPremium.Checked = True Then
                    ResetAddisionelePremie(1)
                End If

                Cursor.Current = Cursors.Default
            ElseIf Me.optSalary.Checked Then
                dteMaxBetaalDateAllowed = dtpExpectedPremiumSalary.Value.AddMonths(1).AddDays(-dtpExpectedPremiumSalary.Value().Day + 1)
                'intStoormaand is afsluitingsdatum se maand plus een maand om te bepaal wanneer die rekords gestoor word.
                intStoorMaand1 = Month(Me.dtpExpectedPremium.Value.AddMonths(1))
                intStoorMaand2 = Month(Me.dtpExpectedPremium.Value.AddMonths(2))

                'Lees persoonl - kry alle aktiewe MD
                dteExpPremium = Me.dtpExpectedPremiumSalary.Value
                dteExpPremiumPlusMonth = Me.dtpExpectedPremiumSalary.Value.AddMonths(1)
                intJaar = Year(dteExpPremiumPlusMonth)
                intMaand = Month(dteExpPremiumPlusMonth)
                intSalArea = Me.cmbArea.SelectedValue

                serverPath = clsRun.gen_getAdminPath()
                serverPath = serverPath & "Month ends\" & Format(dteExpPremiumPlusMonth, "yyyy") & "\" & Format(dteExpPremiumPlusMonth, "MM_yyyy") & "\Final run"
                strCLRSPath = serverPath

                If Dir(serverPath, vbDirectory) = "" Then MkDir(serverPath)

                If Me.chkSalaryFinalRun.Checked = True Then
                    Me.lblProcessing.Text = "Writing Salary file"
                    Me.lblProcessing.Refresh()

                    strMultidataPath = serverPath

                    RunPukFile()

                    If blnPersnoMissing = True Then
                        Me.btnCancel.Enabled = True
                        Cursor.Current = Cursors.Default

                        Me.lblProcessing.Text = "Please fix missing personnel numbers first and then do the Final run again."
                        Me.lblProcessing.Refresh()

                        Exit Sub
                    End If

                    If optTestRun.Checked = True Then
                        Me.btnCancel.Enabled = True

                        Exit Sub
                    End If

                    ReadPersoonlBetWyse()

                    lblProcessing.Text = "Finished with Salary final run"
                    lblProcessing.Refresh()

                    If Me.chkReportPersonnelnr.Checked = True Then

                    End If
                    If Me.chkSendEmail.Checked = True Then

                    End If
                End If

                If Me.chkSalaryOptionFinalRun.Checked = True Then
                    If Me.chkReportSalaryFRSummary.Checked = True Then

                    End If
                    If Me.chkReportSalaryFRDetail.Checked = True Then

                    End If
                    If Me.chkReportSalaryFRConsolidated.Checked = True Then

                    End If
                End If

                If Me.dtpExpectedPremiumSalary.Checked = True Then
                    If Me.chkExpectedPremiumSalary.Checked = True Then
                        WriteRekon(3)

                        lblProcessing.Text = "Finished with Salary expected premium run"
                        lblProcessing.Refresh()
                    End If
                    RunPlip(3)
                    RunCare(3, 5)
                    RunCare(3, 10)
                    RunHomeAssist(3)
                End If

                If Me.chkCompareSummaryFinalRunExpectedPremSalary.Checked = True Then

                End If
                If Me.chkCompleteReconciliationFormSalary.Checked = True Then

                End If
                If Me.chkRestoreAdditionalPremiumSalary.Checked = True Then
                    ResetAddisionelePremie(3)
                End If

                Cursor.Current = Cursors.Default

            End If
            RunCLRS()

            If Me.optGeneral.Checked Then
                lblProcessing.Text = "Database backup"
                lblProcessing.Refresh()

                'backup database
                strPath = clsRun.gen_getServerPath & "MM Backup"
                If Dir(strPath, vbDirectory) = "" Then MkDir(strPath)
                entTakEntity = clsRun.GetTak
                strTak_afkorting = entTakEntity.Tak_afkorting

                strPath = strPath & "\" & strTak_afkorting & "_FinalRunAfter.bak"
                If Gebruiker.titel = "Programmeerder" Then
                    If Me.chkDatabaseBackupAfter.Checked = True Then
                        clsRun.BackupMooirivierDatabase(strPath)
                    End If
                Else
                    clsRun.BackupMooirivierDatabase(strPath)
                End If
            ElseIf Me.optSalary.Checked Then
                lblProcessing.Text = "Database backup"
                lblProcessing.Refresh()

                'backup database
                strPath = clsRun.gen_getServerPath & "MM Backup"
                If Dir(strPath, vbDirectory) = "" Then MkDir(strPath)
                entTakEntity = clsRun.GetTak
                strTak_afkorting = entTakEntity.Tak_afkorting

                strPath = strPath & "\" & strTak_afkorting & "_FinalRunAfter_Salary_" & Me.cmbArea.Text & ".bak"
                If Gebruiker.titel = "Programmeerder" Then
                    If Me.chkDatabaseBackupAfter.Checked = True Then
                        clsRun.BackupMooirivierDatabase(strPath)
                    End If
                Else
                    clsRun.BackupMooirivierDatabase(strPath)
                End If
            End If

            lblProcessing.Text = "Finished with run"
            lblProcessing.Refresh()

            Me.btnCancel.Enabled = True
            MsgBox("Finished with run", vbInformation)
        End If

    End Sub

    Private Sub frmFinalRun_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmbInsurer.DataSource = BaseForm.FillCombo("poldata5.FetchVersekeraar", "pkVersekeraar", "Naam", "", "", "", "")
        cmbInsurer.DisplayMember = "ComboBoxName"
        cmbInsurer.ValueMember = "ComboBoxID"

        cmbInsurer.Text = ""

        cmbArea.DataSource = BaseForm.FillCombo("poldata5.ListActiveAreaOnly", "pkArea", "area_besk", "", "", "", "")
        cmbArea.DisplayMember = "ComboBoxName"
        cmbArea.ValueMember = "ComboBoxID"

        cmbArea.Text = ""

        Me.dtpExpectedPremium.Value = Today
        Me.dtpExpectedPremiumSalary.Value = Today

        fraGeneral.Enabled = False
        fraSalary.Enabled = False

        If Gebruiker.titel = "Programmeerder" Then
            Me.chkDatabaseBackup.Visible = True
            Me.Label24.Visible = True
            Me.chkDatabaseBackupAfter.Visible = True
            Me.Label25.Visible = True
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


    Private Sub optGeneral_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optGeneral.CheckedChanged
        fraSalary.Enabled = False
        fraGeneral.Enabled = True

        Me.dtpExpectedPremium.Value = Today
        Me.dtpExpectedPremium.Enabled = True
        Me.dtpExpectedPremiumSalary.Enabled = False
    End Sub

    Private Sub optSalary_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optSalary.CheckedChanged
        fraGeneral.Enabled = False
        fraSalary.Enabled = True

        Me.dtpExpectedPremiumSalary.Value = Today
        Me.dtpExpectedPremiumSalary.Enabled = True
        Me.dtpExpectedPremium.Enabled = False
    End Sub
    Private Sub FinalRunValidate()
        blnFinalRunValidated = False

        'Insurer must be chosen
        If Me.cmbInsurer.Text = "" Then
            MsgBox("A insurer must be chosen.", vbInformation)
            blnFinalRunValidated = False
            Me.cmbInsurer.Focus()
            Me.btnOk.Enabled = True
            Exit Sub
        End If

        If Me.optGeneral.Checked = False And Me.optSalary.Checked = False Then
            MsgBox("An option for this run must be chosen, General or Salary.", vbInformation)
            blnFinalRunValidated = False
            Exit Sub
        End If

        If Me.optSalary.Checked = True Then
            If Me.cmbArea.Text = "" Then
                MsgBox("An area must be chosen.", vbInformation)
                blnFinalRunValidated = False
                Me.cmbArea.Focus()
                Me.btnOk.Enabled = True
                Exit Sub
            End If
        End If

        If Me.optGeneral.Checked = True Then
            If Me.optTestRunGeneral.Checked = False And Me.optFinalRunGeneral.Checked = False Then
                MsgBox("An option must be chosen for DebitOrderprocessing: Test run or Final run.", vbInformation)
                blnFinalRunValidated = False
                Exit Sub
            End If
        End If

        If Me.optSalary.Checked = True Then
            If Me.optTestRun.Checked = False And Me.optFinalRun.Checked = False Then
                MsgBox("An option must be chosen for Salary run processing: Test run or Final run.", vbInformation)
                blnFinalRunValidated = False
                Exit Sub
            End If
        End If
        blnFinalRunValidated = True
    End Sub
    Private Sub InsertMDAfsluitdat()

        Try
            Using connAfsluitdat As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@Afsluit_dat", SqlDbType.NVarChar)
                param.Value = System.String.Format("{0:dd}/{0:MM}/{0:yyyy}", Me.dtpExpectedPremium.Value)

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5d.InsertMD_afsluit_dat", param)

                If connAfsluitdat.State = ConnectionState.Open Then
                    connAfsluitdat.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Public Sub CheckBetDat()

        Try
            Using connBetDat As SqlConnection = SqlHelper.GetConnection
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.CheckNullBetDat")

                Do While reader.Read
                    MsgBox("Please fix the first payment date of policynumber " & reader("polisno") & " before you can continue with the run.", vbInformation)
                    blnCheckBetDat = False
                Loop
                If connBetDat.State = ConnectionState.Open Then
                    connBetDat.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub ReadPersoonlBetWyse()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@Bet_wyse", SqlDbType.NVarChar)
                If Me.optGeneral.Checked = True Then
                    param.Value = "'1','4','5','6'"
                Else
                    param.Value = "'3'"
                End If

                dblTelUitgeloopJN = 0
                dblTelOor2MaandeUitgeloopJN = 0

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlBetWyse", param)

                Do While reader.Read
                    Application.DoEvents()

                    If reader("pkversekeraar") = cmbInsurer.SelectedValue Then
                        If CDate(reader("bet_dat")) <= dteMaxBetaalDateAllowed Then

                            strBet_wyse = IIf(reader("bet_wyse") Is DBNull.Value, "", reader("bet_wyse"))
                            Select Case strBet_wyse
                                Case "1"
                                    strBetaalwyse = "MK"
                                Case "2"
                                    strBetaalwyse = "JK"
                                Case "3"
                                    strBetaalwyse = "MS"
                                Case "4"
                                    strBetaalwyse = "MD"
                                Case "5"
                                    strBetaalwyse = "ME"
                                Case "6"
                                    strBetaalwyse = "LT"
                                Case Else
                                    strBetaalwyse = ""
                            End Select
                            strPolisno = IIf(reader("polisno") Is DBNull.Value, "", reader("polisno"))
                            Me.lblProcessing.Text = "Processing: " & strPolisno
                            Me.lblProcessing.Refresh()

                            strArea = IIf(reader("area") Is DBNull.Value, "", reader("area"))
                            dblPremie2 = IIf(reader("premie2") Is DBNull.Value, 0, reader("premie2"))
                            strVoorl = IIf(reader("voorl") Is DBNull.Value, "", reader("voorl"))
                            strVersekerde = IIf(reader("versekerde") Is DBNull.Value, "", reader("versekerde"))
                            dblEispers = String.Format("{0:N2}", IIf(reader("eispers") Is DBNull.Value, 0, reader("eispers")))
                            strBemarker = IIf(reader("naam") Is DBNull.Value, "", reader("naam"))
                            dblCareAssist = IIf(reader("careassist") Is DBNull.Value, 0, reader("careassist"))
                            strAdres2 = IIf(reader("Adres2") Is DBNull.Value, "", reader("Adres2"))
                            strAdres3 = IIf(reader("Adres3") Is DBNull.Value, "", reader("Adres3"))
                            dblSubTotaal = IIf(reader("SubTotaal") Is DBNull.Value, 0, reader("SubTotaal"))
                            dblTV_Diens = IIf(reader("TV_Diens") Is DBNull.Value, 0, reader("TV_Diens"))
                            dblBegrafnis = IIf(reader("Begrafnis") Is DBNull.Value, 0, reader("Begrafnis"))
                            dblSasPrem = IIf(reader("SasPrem") Is DBNull.Value, 0, reader("SasPrem"))
                            dblPremie = IIf(reader("Premie") Is DBNull.Value, 0, reader("Premie"))
                            dblPolFooi = IIf(reader("PolFooi") Is DBNull.Value, 0, reader("PolFooi"))
                            dblBeskerm = IIf(reader("Beskerm") Is DBNull.Value, 0, reader("Beskerm"))
                            dblPlip1 = IIf(reader("Plip1") Is DBNull.Value, 0, reader("Plip1"))
                            dteP_A_dat = IIf(reader("P_A_dat") Is DBNull.Value, "", reader("P_A_dat"))
                            dblPakketitem1 = IIf(reader("Pakketitem1") Is DBNull.Value, 0, reader("Pakketitem1"))
                            dblPakketitem2 = IIf(reader("Pakketitem2") Is DBNull.Value, 0, reader("Pakketitem2"))
                            dblPakketitem3 = IIf(reader("Pakketitem3") Is DBNull.Value, 0, reader("Pakketitem3"))
                            dblPakketitem4 = IIf(reader("Pakketitem4") Is DBNull.Value, 0, reader("Pakketitem4"))
                            dblVerwysKommissie = IIf(reader("VerwysKommissie") Is DBNull.Value, 0, reader("VerwysKommissie"))
                            dblCourtesyV = IIf(reader("CourtesyV") Is DBNull.Value, 0, reader("CourtesyV"))
                            dblSelfoon = IIf(reader("Selfoon") Is DBNull.Value, 0, reader("Selfoon"))
                            dblEPC = IIf(reader("EPC") Is DBNull.Value, 0, reader("EPC"))
                            dblHuis_sub = IIf(reader("Huis_sub") Is DBNull.Value, 0, reader("Huis_sub"))
                            dblMotor_sub = IIf(reader("Motor_sub") Is DBNull.Value, 0, reader("Motor_sub"))
                            dblAlle_sub = IIf(reader("Alle_sub") Is DBNull.Value, 0, reader("Alle_sub"))
                            strIdNom = IIf(reader("Id_Nom") Is DBNull.Value, "", reader("Id_Nom"))
                            strBybet_k = IIf(reader("Bybet_k") Is DBNull.Value, "", reader("Bybet_k"))
                            blnTaal = IIf(reader("taal") Is DBNull.Value, False, reader("taal"))
                            strPersnom = IIf(reader("pers_nom") Is DBNull.Value, "", reader("pers_nom"))

                            If reader("bet_wyse") = "6" Then
                                Try
                                    Using connLTP As SqlConnection = SqlHelper.GetConnection
                                        Dim paramLTP As New SqlParameter("@Polisno", SqlDbType.NVarChar)
                                        paramLTP.Value = strPolisno

                                        Dim readerLTP As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FectchLangtermynPolis", paramLTP)

                                        Do While readerLTP.Read
                                            'Afsluitingsdatum moet le tussen (DatumBegin - 1 maand) en (DatumEindig - 1 maand)
                                            dteDatumBeginMinusEenMaand = readerLTP("datumbegin").AddMonths(-1)
                                            dteDatumEindigMinusEenMaand = readerLTP("datumeindig").AddMonths(-1)

                                            If (DateDiff(DateInterval.Day, dteExpPremium, dteDatumBeginMinusEenMaand) <= 0) And (DateDiff(DateInterval.Day, dteDatumEindigMinusEenMaand, dteExpPremium) <= 0) Then
                                                WriteAfsluitingsTabel()

                                                'Stoor die res van die polis vir statistiek doeleindes, eise vs premies, asook om 'n polis te kan druk soos dit op maand_einde was
                                                StoorPolisAfsluiting()

                                                'vertoon lys van uitgeloopte premies en skep aanmaningsbriewe vir polisse wat oor 2 maande gaan uitloop vir ltp
                                                strUitgeloopJN = "N"
                                                strOor2MaandeUitgeloopJN = "N"
                                                strVertoonEarnedJN = "N"

                                                clsRun.BerekenLangtermynPolisFondse(strPolisno, dteExpPremium)

                                                If strUitgeloopJN = "J" Then
                                                    dblTelUitgeloopJN = dblTelUitgeloopJN + 1
                                                    arrUitgeloop(dblTelUitgeloopJN) = strPolisno
                                                Else
                                                    If strOor2MaandeUitgeloopJN = "J" Then
                                                        dblTelOor2MaandeUitgeloopJN = dblTelOor2MaandeUitgeloopJN + 1
                                                        arrUitgeloopOor2Maande(dblTelOor2MaandeUitgeloopJN) = strPolisno
                                                    End If
                                                End If
                                            End If
                                        Loop
                                        If connLTP.State = ConnectionState.Open Then
                                            connLTP.Close()
                                        End If
                                    End Using
                                Catch ex As Exception
                                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                                End Try
                            Else
                                WriteAfsluitingsTabel()

                                'Stoor die res van die polis vir statistiek doeleindes, eise vs premies, asook om 'n polis te kan druk soos dit op maand_einde was
                                StoorPolisAfsluiting()
                            End If

                        End If
                    End If
                Loop
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Private Sub WriteAfsluitingsTabel()

        Try
            Using conn3 As SqlConnection = SqlHelper.GetConnection

                Dim params3() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@PREMIE", SqlDbType.Money), _
                                                New SqlParameter("@VORD_PREMIE", SqlDbType.Money), _
                                                New SqlParameter("@AFSLUIT_DAT", SqlDbType.DateTime), _
                                                New SqlParameter("@Area", SqlDbType.NVarChar), _
                                                New SqlParameter("@JAAR", SqlDbType.SmallInt), _
                                                New SqlParameter("@MAAND", SqlDbType.SmallInt), _
                                                New SqlParameter("@TRANS_DAT", SqlDbType.DateTime), _
                                                New SqlParameter("@MS_TRANS_DAT", SqlDbType.DateTime), _
                                                New SqlParameter("@BETAALWYSE", SqlDbType.NVarChar), _
                                                New SqlParameter("@Kwit_boek", SqlDbType.NVarChar), _
                                                New SqlParameter("@Vord_DAT", SqlDbType.DateTime), _
                                                New SqlParameter("@Match", SqlDbType.Bit), _
                                                New SqlParameter("@Nie_Multi", SqlDbType.Money), _
                                                New SqlParameter("@Nie_MD", SqlDbType.Money), _
                                                New SqlParameter("@Oningewin", SqlDbType.Money), _
                                                New SqlParameter("@ingevorder", SqlDbType.Money), _
                                                New SqlParameter("@Pers_Nom", SqlDbType.NVarChar)}


                params3(0).Value = strPolisno
                params3(1).Value = Format(dblPremie2, "#####.00")
                params3(2).Value = 0
                If Me.optGeneral.Checked = True Then
                    params3(3).Value = Me.dtpExpectedPremium.Value
                Else
                    params3(3).Value = Me.dtpExpectedPremiumSalary.Value
                End If
                params3(4).Value = strArea
                params3(5).Value = intJaar
                params3(6).Value = intMaand
                params3(7).Value = Now
                If Me.optGeneral.Checked = True Then
                    params3(8).Value = DBNull.Value
                Else
                    params3(8).Value = Now
                End If
                params3(9).Value = strBet_wyse
                params3(10).Value = ""
                params3(11).Value = DBNull.Value
                params3(12).Value = False
                params3(13).Value = 0
                params3(14).Value = 0
                params3(15).Value = 0
                params3(16).Value = 0
                params3(17).Value = strPersnom

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.UpdateMaand", params3)
                If conn3.State = ConnectionState.Open Then
                    conn3.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub StoorPolisAfsluiting()
        FetchHuisFinalRun()
        FetchVoertuieFinalRun()
        FetchAlleRisikoFinalRun()

        Application.DoEvents()
        dblAddisionelePremie = BaseForm.gen_getAdditionalPremium(strPolisno)

        UpdateMDPrintDat()
        UpdateMDPrint2Dat()
    End Sub
    Private Sub UpdateMDPrintDat()
        Dim strAreaBesk As String = ""

        Try
            Using conn4 As SqlConnection = SqlHelper.GetConnection

                Dim params4() As SqlParameter = {New SqlParameter("@Voorl", SqlDbType.NVarChar), _
                                                New SqlParameter("@versekerde", SqlDbType.NVarChar), _
                                                New SqlParameter("@Adres2", SqlDbType.NVarChar), _
                                                New SqlParameter("@Subtotaal", SqlDbType.Money), _
                                                New SqlParameter("@TV_Diens", SqlDbType.Money), _
                                                New SqlParameter("@Begrafnis", SqlDbType.Money), _
                                                New SqlParameter("@Polfooi", SqlDbType.Money), _
                                                New SqlParameter("@Sasprem", SqlDbType.Money), _
                                                New SqlParameter("@Motorsekuriteitbitvaluememo", SqlDbType.NVarChar), _
                                                New SqlParameter("@Premie", SqlDbType.Money), _
                                                New SqlParameter("@Besk", SqlDbType.NVarChar), _
                                                New SqlParameter("@Pakketitem1", SqlDbType.Money), _
                                                New SqlParameter("@jaar", SqlDbType.NVarChar), _
                                                New SqlParameter("@Pakketitem2", SqlDbType.Money), _
                                                New SqlParameter("@Pakketitem3", SqlDbType.Money), _
                                                New SqlParameter("@Reg", SqlDbType.NVarChar), _
                                                New SqlParameter("@Pakketitem4", SqlDbType.Money), _
                                                New SqlParameter("@Tipe", SqlDbType.NVarChar), _
                                                New SqlParameter("@Waarde", SqlDbType.NVarChar), _
                                                New SqlParameter("@MPremie", SqlDbType.NVarChar), _
                                                New SqlParameter("@Voertuie", SqlDbType.Bit), _
                                                New SqlParameter("@Eise", SqlDbType.Bit), _
                                                New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@G_Bonus", SqlDbType.NVarChar), _
                                                New SqlParameter("@Area", SqlDbType.NVarChar), _
                                                New SqlParameter("@Bet_wyse", SqlDbType.NVarChar), _
                                                New SqlParameter("@Plip", SqlDbType.Money), _
                                                New SqlParameter("@Beskerm", SqlDbType.Money), _
                                                New SqlParameter("@P_A_Dat2", SqlDbType.DateTime), _
                                                New SqlParameter("@Eeu", SqlDbType.NVarChar), _
                                                New SqlParameter("@PA_Dat", SqlDbType.NVarChar), _
                                                New SqlParameter("@Afsluit_dat", SqlDbType.NVarChar), _
                                                New SqlParameter("@CareAssist", SqlDbType.Money), _
                                                New SqlParameter("@Eispers", SqlDbType.Real), _
                                                New SqlParameter("@MMKode", SqlDbType.NVarChar), _
                                                New SqlParameter("@TipeVoert", SqlDbType.NVarChar), _
                                                New SqlParameter("@Bemarker", SqlDbType.NVarChar), _
                                                New SqlParameter("@Adres3", SqlDbType.NVarChar), _
                                                New SqlParameter("@Motorsek", SqlDbType.NVarChar), _
                                                New SqlParameter("@Afsluitdatum", SqlDbType.DateTime), _
                                                New SqlParameter("@Gebruik", SqlDbType.NVarChar)}


                params4(0).Value = strVoorl                                                             'Voorletter
                params4(1).Value = strVersekerde                                                        'Versekerde
                params4(2).Value = strAdres2                                                            'Adres2
                params4(3).Value = dblSubTotaal                                                         'subtotaal
                params4(4).Value = dblTV_Diens                                                          'tv_diens
                params4(5).Value = dblBegrafnis                                                         'begrafnis
                params4(6).Value = dblPolFooi                                                           'polfooi
                params4(7).Value = dblSasPrem                                                           'sasprem
                params4(8).Value = strMotorsekuriteitbitvaluememo                                       'motorsekuriteitbitvalue
                params4(9).Value = dblPremie                                                            'premie
                params4(10).Value = strBesk                                                             'besk
                params4(11).Value = dblPakketitem1                                                      'pakketitem1
                params4(12).Value = strJaar                                                             'jaar
                params4(13).Value = dblPakketitem2                                                      'Pakketitem2
                params4(14).Value = dblPakketitem3                                                      'Pakketitem3
                params4(15).Value = strReg                                                              'reg
                params4(16).Value = dblPakketitem4                                                      'Pakketitem4
                params4(17).Value = strTipe                                                             'tipe
                params4(18).Value = strWaarde                                                           'waarde
                params4(19).Value = strMPremie                                                          'mpremie
                params4(20).Value = blnVoertuie                                                         'Voertuie
                params4(21).Value = 0                                                                   'Eise
                params4(22).Value = strPolisno                                                          'polisno
                params4(23).Value = ""                                                                  'G_bonus

                'Kry area naam
                Try
                    Using conn8 As SqlConnection = SqlHelper.GetConnection
                        Dim param As New SqlParameter("@Area_kode", SqlDbType.NVarChar)
                        param.Value = strArea

                        Dim readerArea As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAreakodeByArea", param)

                        If readerArea.Read Then
                            strAreaBesk = readerArea("area_besk")
                        End If
                        If conn8.State = ConnectionState.Open Then
                            conn8.Close()
                        End If
                    End Using
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                    'Exit Sub
                End Try

                params4(24).Value = strAreaBesk                                                         'Area_besk
                params4(25).Value = strBetaalwyse                                                       'betaalwyse
                params4(26).Value = dblPlip1                                                            'plip1
                params4(27).Value = dblBeskerm                                                          'beskerming
                params4(28).Value = dteP_A_dat                                                          'P_a_dat
                params4(29).Value = strEeu                                                              'eeu
                params4(30).Value = System.String.Format("{0:dd}/{0:MM}/{0:yyyy}", dteP_A_dat)          'p_a_dat
                params4(31).Value = System.String.Format("{0:dd}/{0:MM}/{0:yyyy}", dteExpPremium)       'afdat
                params4(32).Value = dblCareAssist                                                       'careassist
                params4(33).Value = 0                                                                   'eispers
                params4(34).Value = strMMKode                                                           'mmkode
                params4(35).Value = strTipeVoert                                                        'tipevoert
                params4(36).Value = IIf(strBemarker = "", "Geen Bemarker", strBemarker)                 'Bemarker
                params4(37).Value = strAdres3                                                           'adres3
                params4(38).Value = strMotorsek                                                         'motorsek
                params4(39).Value = dteExpPremium                                                       'afdat  
                params4(40).Value = strGebruik                                                          'gebruik

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5d.InsertMD_PRINT_DAT", params4)
                If conn4.State = ConnectionState.Open Then
                    conn4.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
        blnVoertuie = False
    End Sub
    Private Sub UpdateMDPrintAlle()
        Try
            Using conn5 As SqlConnection = SqlHelper.GetConnection

                Dim params5() As SqlParameter = {New SqlParameter("@Dekking", SqlDbType.Money), _
                                                New SqlParameter("@Premie", SqlDbType.Money), _
                                                New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@Afsluit_dat", SqlDbType.NVarChar), _
                                                New SqlParameter("@beskryf", SqlDbType.NVarChar), _
                                                New SqlParameter("@arnPlaat", SqlDbType.NVarChar), _
                                                New SqlParameter("@bet_wyse", SqlDbType.NVarChar), _
                                                New SqlParameter("@tipe2", SqlDbType.SmallInt), _
                                                New SqlParameter("@itemnr", SqlDbType.NVarChar), _
                                                New SqlParameter("@Afsluitdatum", SqlDbType.DateTime), _
                                                New SqlParameter("@kode", SqlDbType.NVarChar)}

                params5(0).Value = dblARDekking                                                         'dekking
                params5(1).Value = dblARPremie                                                          'premie
                params5(2).Value = strPolisno                                                           'polisno
                params5(3).Value = System.String.Format("{0:dd}/{0:MM}/{0:yyyy}", dteExpPremium)        'afsluit_dat
                params5(4).Value = strARBeskryf                                                         'Beskryf
                params5(5).Value = strARArnPlaat                                                        'arnplaat
                params5(6).Value = strBetaalwyse                                                        'bet_wyse
                params5(7).Value = strARTipe2                                                           'tipe2
                params5(8).Value = strARItemNr                                                          'Itemnr
                params5(9).Value = dtpExpectedPremium.Value                                             'Afsluitdatum
                params5(10).Value = ""                                                                  'kode

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5d.InsertMD_PRINT_Alle", params5)
                If conn5.State = ConnectionState.Open Then
                    conn5.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Private Sub UpdateMDPrint2Dat()
        Dim itemHuis As HuisEntity = New HuisEntity()
        Try
            Using conn6 As SqlConnection = SqlHelper.GetConnection

                Dim params6() As SqlParameter = {New SqlParameter("@Huistipe", SqlDbType.NVarChar), _
                                                New SqlParameter("@Huisadres", SqlDbType.NVarChar), _
                                                New SqlParameter("@Huisdekking", SqlDbType.NVarChar), _
                                                New SqlParameter("@HuisPremie", SqlDbType.NVarChar), _
                                                New SqlParameter("@VerwysKommissie", SqlDbType.Money), _
                                                New SqlParameter("@Premie2", SqlDbType.Money), _
                                                New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@Afsluit_dat", SqlDbType.NVarChar), _
                                                New SqlParameter("@Ongespesifiseerd", SqlDbType.Money), _
                                                New SqlParameter("@Ongevalle", SqlDbType.Money), _
                                                New SqlParameter("@CourtesyV", SqlDbType.Money), _
                                                New SqlParameter("@Afsluitdatum", SqlDbType.DateTime), _
                                                New SqlParameter("@Huisposkode", SqlDbType.NVarChar), _
                                                New SqlParameter("@hehb", SqlDbType.NVarChar), _
                                                New SqlParameter("@tipe_dak", SqlDbType.NVarChar), _
                                                New SqlParameter("@Struktuur", SqlDbType.NVarChar), _
                                                New SqlParameter("@Itemnr", SqlDbType.NVarChar), _
                                                New SqlParameter("@Alle_sub", SqlDbType.Money), _
                                                New SqlParameter("@Huis_sub", SqlDbType.Money), _
                                                New SqlParameter("@Motor_sub", SqlDbType.Money), _
                                                New SqlParameter("@A_Goedgekeur", SqlDbType.NVarChar), _
                                                New SqlParameter("@ID_nom", SqlDbType.NVarChar), _
                                                New SqlParameter("@Bybet_k", SqlDbType.NVarChar), _
                                                New SqlParameter("@Eispers", SqlDbType.Real), _
                                                New SqlParameter("@Toe_waarde", SqlDbType.Money), _
                                                New SqlParameter("@Toe_premie", SqlDbType.Money), _
                                                New SqlParameter("@EEM_Waarde", SqlDbType.Money), _
                                                New SqlParameter("@EEM_Premie", SqlDbType.Money), _
                                                New SqlParameter("@EPC", SqlDbType.Money), _
                                                New SqlParameter("@Inscell", SqlDbType.Money), _
                                                New SqlParameter("@Huissek", SqlDbType.NVarChar), _
                                                New SqlParameter("@AddisionelePremie", SqlDbType.Money), _
                                                New SqlParameter("@Huissekuriteit", SqlDbType.NVarChar), _
                                                New SqlParameter("@HuisHoofeiendom", SqlDbType.NVarChar), _
                                                New SqlParameter("@HuisEiendomTipe", SqlDbType.NVarChar), _
                                                New SqlParameter("@Huislapa", SqlDbType.NVarChar), _
                                                New SqlParameter("@VoertJaar", SqlDbType.NVarChar), _
                                                New SqlParameter("@VoertEeu", SqlDbType.NVarChar), _
                                                New SqlParameter("@VoertKleur", SqlDbType.NVarChar), _
                                                New SqlParameter("@VoertPKVoertuie", SqlDbType.NVarChar), _
                                                New SqlParameter("@VoertWaardeTipe", SqlDbType.NVarChar), _
                                                New SqlParameter("@VoertAreabeskrywing", SqlDbType.NVarChar), _
                                                New SqlParameter("@VoertMotorhuis", SqlDbType.NVarChar), _
                                                New SqlParameter("@VoertPoskode", SqlDbType.NVarChar), _
                                                New SqlParameter("@Voertingevoer", SqlDbType.NVarChar), _
                                                New SqlParameter("@VoertLaeprofielBande", SqlDbType.NVarChar), _
                                                New SqlParameter("@PersoonlAddisionelePremie", SqlDbType.Money), _
                                                New SqlParameter("@Huissekuriteitbitvaluememo", SqlDbType.NVarChar), _
                                                New SqlParameter("@Bet_wyse", SqlDbType.NVarChar), _
                                                New SqlParameter("@Huisverband", SqlDbType.NVarChar), _
                                                New SqlParameter("@VoertHuurkoop", SqlDbType.NVarChar)}

                params6(0).Value = strHuistipe                                                          'huistipe
                params6(1).Value = strHuisadres                                                         'huisadres
                params6(2).Value = strHuisDekking                                                       'huisdekking
                params6(3).Value = strHuisPremie                                                        'huispremie
                params6(4).Value = dblVerwysKommissie                                                   'verwyskommissie
                params6(5).Value = dblPremie2                                                           'premie2
                params6(6).Value = strPolisno                                                           'polisno
                params6(7).Value = System.String.Format("{0:dd}/{0:MM}/{0:yyyy}", dteExpPremium)        'afdat
                params6(8).Value = 2000                                                                 'ongespesifiseerd
                params6(9).Value = 8000                                                                 'ongevalle
                params6(10).Value = dblCourtesyV                                                        'courtesyv
                params6(11).Value = dteExpPremium                                                       'afdat
                params6(12).Value = strHuisPoskode                                                      'Huisposkode
                params6(13).Value = strHeHb                                                             'hehb
                params6(14).Value = strTipeDak                                                          'tipe_dak
                params6(15).Value = strStruktuur                                                        'struktuur
                params6(16).Value = strItemnr                                                           'itemnr
                params6(17).Value = dblAlle_sub                                                         'alle_sub
                params6(18).Value = dblHuis_sub                                                         'huis_sub
                params6(19).Value = dblMotor_sub                                                        'motor_sub
                params6(20).Value = strA_Goedgekeur                                                     'a_goedgekeur
                params6(21).Value = strIdNom                                                            'id_nom
                params6(22).Value = strBybet_k                                                          'bybet_k
                params6(23).Value = dblEispers                                                          'Eispers
                params6(24).Value = itemHuis.toe_waarde                                                 'toe_waarde
                params6(25).Value = itemHuis.toe_premie                                                 'toe_premie
                params6(26).Value = itemHuis.eem_waarde                                                 'eem_waarde
                params6(27).Value = itemHuis.eem_premie                                                 'eem_premie
                params6(28).Value = dblEPC                                                              'epc
                params6(29).Value = dblSelfoon                                                          'inscell
                params6(30).Value = ""                                                                  'huissek
                params6(31).Value = dblAddisionelePremie                                                'Addisionelepremie
                params6(32).Value = strHuissekuriteit                                                   'huissekuriteit
                params6(33).Value = strHuisHoofeiendom                                                  'huishoofeiendom
                params6(34).Value = strHuisEiendomTipe                                                  'huiseiendomtipe
                params6(35).Value = strHuisLapa                                                         'huislapa
                params6(36).Value = strVoertJaar                                                        'voertjaar
                params6(37).Value = strVoertEeu                                                         'voerteeu
                params6(38).Value = strVoertKleur                                                       'voertkleur
                params6(39).Value = strVoertpkVoertuie                                                  'voertpkvoertuie
                params6(40).Value = strVoertWaardetipe                                                  'voertwaardetipe
                params6(41).Value = strVoertAreaBeskrywing                                              'voertareabeskrywing
                params6(42).Value = strVoertMotorhuis                                                   'voertmotorhuis
                params6(43).Value = strVoertPoskode                                                     'voertposkode
                params6(44).Value = strVoertIngevoer                                                    'voertingevoer
                params6(45).Value = strVoertLaeProfielbande                                             'voertlaeprofielbande
                params6(46).Value = dblAddisionelePremie                                                'PersoonlAddisionelePremie
                params6(47).Value = strHuissekuriteitBitValueMemo                                       'Huissekuriteitbitvaluememo
                params6(48).Value = strBetaalwyse                                                       'betaalwyse
                params6(49).Value = strHuisVerband                                                      'Huisverband
                params6(50).Value = strVoertHuurkoop                                                    'VoertHuurkoop

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5d.InsertMD_PRINT2_DAT", params6)
                If conn6.State = ConnectionState.Open Then
                    conn6.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Private Sub FetchHuisFinalRun()

        strHuistipe = ""
        strHuisadres = ""
        strHuisPoskode = ""
        strHuisDekking = ""
        strHuisPremie = ""
        strTipeDak = ""
        strStruktuur = ""
        strA_Goedgekeur = ""
        strItemnr = ""
        strHeHb = ""
        strHuissekuriteit = ""
        strHuissekuriteitBitValueMemo = ""
        strHuisHoofeiendom = ""
        strHuisEiendomTipe = ""
        strHuisLapa = ""
        strHuisVerband = ""
        intCtrHE = 0
        intCtrHB = 0
        'blnVoertuie = False

        Try
            Using connHuis As SqlConnection = SqlHelper.GetConnection
                Dim paramHuis As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                paramHuis.Value = strPolisno

                Dim readerHuis As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchHuisByPolisno", paramHuis)
                Do While readerHuis.Read
                    Dim itemHuis As HuisEntity = New HuisEntity()
                    If readerHuis("ADRES_H1") IsNot DBNull.Value Then
                        itemHuis.ADRES_H1 = readerHuis("ADRES_H1")
                    End If
                    If readerHuis("poskode") IsNot DBNull.Value Then
                        itemHuis.poskode = readerHuis("poskode")
                    End If
                    If readerHuis("Adres4") IsNot DBNull.Value Then
                        itemHuis.Adres4 = readerHuis("Adres4")
                    End If
                    If readerHuis("lapa") IsNot DBNull.Value Then
                        itemHuis.lapa = readerHuis("lapa")
                    End If
                    If readerHuis("Cancelled") IsNot DBNull.Value Then
                        itemHuis.Cancelled = readerHuis("Cancelled")
                    End If
                    If readerHuis("eem_premie") IsNot DBNull.Value Then
                        itemHuis.eem_premie = readerHuis("eem_premie")
                    End If
                    If readerHuis("eem_waarde") IsNot DBNull.Value Then
                        itemHuis.eem_waarde = readerHuis("eem_waarde")
                    End If
                    If readerHuis("mainproperty") IsNot DBNull.Value Then
                        itemHuis.mainproperty = readerHuis("mainproperty")
                    End If
                    If readerHuis("pkHuis") IsNot DBNull.Value Then
                        itemHuis.pkHuis = readerHuis("pkHuis")
                    End If
                    If readerHuis("PREMIE_HB") IsNot DBNull.Value Then
                        itemHuis.PREMIE_HB = readerHuis("PREMIE_HB")
                    End If
                    If readerHuis("PREMIE_HE") IsNot DBNull.Value Then
                        itemHuis.PREMIE_HE = readerHuis("PREMIE_HE")
                    End If
                    If readerHuis("sekuriteit") IsNot DBNull.Value Then
                        itemHuis.sekuriteit = readerHuis("sekuriteit")
                    End If
                    If readerHuis("SekuriteitBitValue") IsNot DBNull.Value Then
                        itemHuis.SekuriteitBitValue = readerHuis("SekuriteitBitValue")
                    End If
                    If readerHuis("STRUKTUUR") IsNot DBNull.Value Then
                        itemHuis.STRUKTUUR = readerHuis("STRUKTUUR")
                    End If
                    If readerHuis("TIPE_DAK") IsNot DBNull.Value Then
                        itemHuis.TIPE_DAK = readerHuis("TIPE_DAK")
                    End If
                    If readerHuis("toe_premie") IsNot DBNull.Value Then
                        itemHuis.toe_premie = readerHuis("toe_premie")
                    End If
                    If readerHuis("toe_waarde") IsNot DBNull.Value Then
                        itemHuis.toe_waarde = readerHuis("toe_waarde")
                    End If
                    If readerHuis("fkPropertyType") IsNot DBNull.Value Then
                        itemHuis.fkPropertyType = readerHuis("fkPropertyType")
                    End If
                    If readerHuis("WAARDE_HB") IsNot DBNull.Value Then
                        itemHuis.WAARDE_HB = readerHuis("WAARDE_HB")
                    End If
                    If readerHuis("Verband") IsNot DBNull.Value Then
                        itemHuis.Verband = readerHuis("Verband")
                    End If
                    If readerHuis("WAARDE_HE") IsNot DBNull.Value Then
                        itemHuis.WAARDE_HE = readerHuis("WAARDE_HE")
                    End If
                    If readerHuis("a_goedgekeur") IsNot DBNull.Value Then
                        itemHuis.A_GOEDGEKEUR = readerHuis("a_goedgekeur")
                    End If

                    If readerHuis("polisno") = "7776001840" Then
                        strPolisno = strPolisno
                    End If
                    'Huiseienaars
                    If itemHuis.WAARDE_HE <> 0 Then
                        intCtrHE += 1
                        If blnTaal = 0 Then
                            strHuistipe &= "Huiseienaar " & intCtrHE & ":" & Chr(10) & Chr(13)
                        Else
                            strHuistipe &= "Home owner " & intCtrHE & ":" & Chr(10) & Chr(13)
                        End If
                        strHeHb &= "HE" & Chr(10) & Chr(13)
                        strHuisDekking &= itemHuis.WAARDE_HE & Chr(10) & Chr(13)
                        strHuisPremie &= itemHuis.PREMIE_HE & Chr(10) & Chr(13)

                        strHuisadres &= itemHuis.ADRES_H1 & Chr(10) & Chr(13)
                        strHuisPoskode &= itemHuis.poskode & Chr(10) & Chr(13)
                        strTipeDak &= itemHuis.TIPE_DAK & Chr(10) & Chr(13)
                        strStruktuur &= itemHuis.STRUKTUUR & Chr(10) & Chr(13)
                        strA_Goedgekeur &= IIf(itemHuis.A_GOEDGEKEUR = Nothing, "0", itemHuis.A_GOEDGEKEUR) & Chr(10) & Chr(13)
                        strItemnr &= IIf(readerHuis("itemnr") Is DBNull.Value, "", readerHuis("itemnr")) & Chr(10) & Chr(13)
                        strHuissekuriteit &= Format(0) & Chr(10) & Chr(13)
                        strHuissekuriteitBitValueMemo &= itemHuis.SekuriteitBitValue & Chr(10) & Chr(13)
                        strHuisHoofeiendom &= itemHuis.mainproperty & Chr(10) & Chr(13)
                        strHuisEiendomTipe &= itemHuis.fkPropertyType & Chr(10) & Chr(13)
                        strHuisLapa &= itemHuis.lapa & Chr(10) & Chr(13)
                        strHuisVerband &= IIf(itemHuis.Verband <> 0, "True", "False") & Chr(10) & Chr(13)
                    End If

                    'Huisbewoners
                    If itemHuis.WAARDE_HB <> 0 Then
                        intCtrHB += 1
                        If blnTaal = 0 Then
                            strHuistipe &= "Huisbewoner " & intCtrHB & ":" & Chr(10) & Chr(13)
                        Else
                            strHuistipe &= "Householder " & intCtrHB & ":" & Chr(10) & Chr(13)
                        End If
                        strHeHb &= "HB" & Chr(10) & Chr(13)
                        strHuisDekking &= itemHuis.WAARDE_HB & Chr(10) & Chr(13)
                        strHuisPremie &= itemHuis.PREMIE_HB & Chr(10) & Chr(13)

                        strHuisadres &= itemHuis.ADRES_H1 & Chr(10) & Chr(13)
                        strHuisPoskode &= itemHuis.poskode & Chr(10) & Chr(13)
                        strTipeDak &= itemHuis.TIPE_DAK & Chr(10) & Chr(13)
                        strStruktuur &= itemHuis.STRUKTUUR & Chr(10) & Chr(13)
                        strA_Goedgekeur &= IIf(itemHuis.A_GOEDGEKEUR = Nothing, "0", itemHuis.A_GOEDGEKEUR) & Chr(10) & Chr(13)
                        strItemnr &= IIf(readerHuis("itemnr") Is DBNull.Value, "", readerHuis("itemnr")) & Chr(10) & Chr(13)
                        strHuissekuriteit &= Format(0) & Chr(10) & Chr(13)
                        strHuissekuriteitBitValueMemo &= itemHuis.SekuriteitBitValue & Chr(10) & Chr(13)
                        strHuisHoofeiendom &= itemHuis.mainproperty & Chr(10) & Chr(13)
                        strHuisEiendomTipe &= itemHuis.fkPropertyType & Chr(10) & Chr(13)
                        strHuisLapa &= itemHuis.lapa & Chr(10) & Chr(13)
                        strHuisVerband &= IIf(itemHuis.Verband <> 0, "True", "False") & Chr(10) & Chr(13)
                    End If

                Loop
                If connHuis.State = ConnectionState.Open Then
                    connHuis.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Private Sub FetchVoertuieFinalRun()
        Dim itemHuis As HuisEntity = New HuisEntity()

        strMMKode = ""
        strTipeVoert = ""
        strVoertJaar = ""
        strVoertEeu = ""
        strVoertKleur = ""
        strVoertpkVoertuie = ""
        strVoertWaardetipe = ""
        strVoertAreaBeskrywing = ""
        strVoertMotorhuis = ""
        strVoertPoskode = ""
        strVoertIngevoer = ""
        strVoertHuurkoop = ""
        strVoertLaeProfielbande = ""
        'blnVoertuie = False
        strBesk = ""
        strJaar = ""
        strEeu = ""
        strReg = ""
        strWaarde = ""
        strMPremie = ""
        strMotorsek = ""
        strMotorsekuriteitbitvaluememo = ""
        strTipe = ""
        strGebruik = ""

        intCtrVoertuie = 0

        Try
            Using connVoertuie As SqlConnection = SqlHelper.GetConnection
                Dim paramVoertuie As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                paramVoertuie.Value = strPolisno

                Dim readerVoertuie As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuieForPremie", paramVoertuie)
                Do While readerVoertuie.Read()
                    Dim itemVoertuie As EntityVoertuie = New EntityVoertuie()
                    If readerVoertuie("eeu") IsNot DBNull.Value Then
                        itemVoertuie.eeu = readerVoertuie("eeu")
                    End If
                    If readerVoertuie("jaar") IsNot DBNull.Value Then
                        itemVoertuie.jaar = readerVoertuie("jaar")
                    End If
                    If readerVoertuie("n_plaat") IsNot DBNull.Value Then
                        itemVoertuie.plaat = readerVoertuie("n_plaat")
                    End If
                    If readerVoertuie("Premie") IsNot DBNull.Value Then
                        itemVoertuie.premie = readerVoertuie("Premie")
                    End If
                    If readerVoertuie("Cancelled") IsNot DBNull.Value Then
                        itemVoertuie.cancelled = readerVoertuie("Cancelled")
                    End If
                    If readerVoertuie("Premie") IsNot DBNull.Value Then
                        itemVoertuie.premie_voor = readerVoertuie("Premie")
                    End If
                    If readerVoertuie("ander") IsNot DBNull.Value Then
                        itemVoertuie.ander = readerVoertuie("ander")
                    End If
                    If readerVoertuie("kode") IsNot DBNull.Value Then
                        itemVoertuie.kode = readerVoertuie("kode")
                    End If
                    If readerVoertuie("pkvoertuie") IsNot DBNull.Value Then
                        itemVoertuie.pkVoertuie = readerVoertuie("pkvoertuie")
                    End If
                    If readerVoertuie("gebruik") IsNot DBNull.Value Then
                        itemVoertuie.gebruik = readerVoertuie("gebruik")
                    End If
                    If readerVoertuie("tipe_dek") IsNot DBNull.Value Then
                        itemVoertuie.tipe_dek = readerVoertuie("tipe_dek")
                    End If
                    If readerVoertuie("tipe") IsNot DBNull.Value Then
                        itemVoertuie.tipe = readerVoertuie("tipe")
                    End If
                    If readerVoertuie("polisno") = "7773008893" Then
                        strPolisno = strPolisno
                    End If
                    strMMKode &= itemVoertuie.kode & Chr(10) & Chr(13)
                    strTipeVoert &= itemVoertuie.tipe & Chr(10) & Chr(13)
                    strVoertJaar &= itemVoertuie.jaar & Chr(10) & Chr(13)
                    strVoertEeu &= itemVoertuie.eeu & Chr(10) & Chr(13)
                    strVoertKleur &= IIf(readerVoertuie("kleur") Is DBNull.Value, "", readerVoertuie("kleur")) & Chr(10) & Chr(13)
                    strVoertpkVoertuie &= itemVoertuie.pkVoertuie & Chr(10) & Chr(13)
                    strVoertWaardetipe &= IIf(readerVoertuie("waardetipe") Is DBNull.Value, "", readerVoertuie("waardetipe")) & Chr(10) & Chr(13)
                    strVoertAreaBeskrywing &= IIf(readerVoertuie("areabeskrywing") Is DBNull.Value, "", readerVoertuie("areabeskrywing")) & Chr(10) & Chr(13)
                    strVoertMotorhuis &= IIf(readerVoertuie("motorhuis") Is DBNull.Value, "", readerVoertuie("motorhuis")) & Chr(10) & Chr(13)
                    strVoertPoskode &= IIf(readerVoertuie("poskode") Is DBNull.Value, "", readerVoertuie("poskode")) & Chr(10) & Chr(13)
                    strVoertIngevoer &= IIf(readerVoertuie("ingevoer") Is DBNull.Value, "", readerVoertuie("ingevoer")) & Chr(10) & Chr(13)
                    strVoertHuurkoop &= IIf(readerVoertuie("huurkoop") Is DBNull.Value, "", readerVoertuie("huurkoop")) & Chr(10) & Chr(13)
                    strVoertLaeProfielbande &= IIf(readerVoertuie("laeprofielbande") Is DBNull.Value, "", readerVoertuie("laeprofielbande")) & Chr(10) & Chr(13)
                    blnVoertuie = True

                    If (itemVoertuie.tipe = "1" Or itemVoertuie.tipe = "2" Or itemVoertuie.tipe = "3" Or itemVoertuie.tipe = "6") Or (itemVoertuie.tipe = "4" Or itemVoertuie.tipe = "5" Or itemVoertuie.tipe = "7") Then
                        intCtrVoertuie += 1
                        clsRun.GetVehicleDescription(itemVoertuie.ander, itemVoertuie.kode, itemVoertuie.eeu, itemVoertuie.jaar)

                        strBesk &= strVoertuieMaak & " " & strVoertuieBesk & Chr(10) & Chr(13)
                        strJaar &= strVoertuieJaar & Chr(10) & Chr(13)
                        strEeu &= strVoertuieEeu & Chr(10) & Chr(13)
                        strReg &= IIf(readerVoertuie("n_plaat") Is DBNull.Value, "", readerVoertuie("n_plaat")) & Chr(10) & Chr(13)
                        strWaarde &= Format(IIf(readerVoertuie("waarde") Is DBNull.Value, 0, readerVoertuie("waarde")), "#########") & Chr(10) & Chr(13)
                        strMPremie &= String.Format("{0:N2}", itemVoertuie.premie) & Chr(10) & Chr(13)
                        strMotorsek &= " " & Chr(10) & Chr(13)
                        strMotorsekuriteitbitvaluememo &= IIf(readerVoertuie("sekuriteitbitvalue") Is DBNull.Value, "0", readerVoertuie("sekuriteitbitvalue")) & Chr(10) & Chr(13)

                        If blnTaal = 0 Then
                            Select Case itemVoertuie.tipe_dek
                                Case "1"
                                    strTipe &= "Omv" & Chr(10) & Chr(13)
                                Case "2"
                                    strTipe &= "BD&D" & Chr(10) & Chr(13)
                                Case "3"
                                    strTipe &= "DP" & Chr(10) & Chr(13)
                            End Select
                            Select Case itemVoertuie.gebruik
                                Case "1"
                                    strGebruik &= "Privaat " & Chr(10) & Chr(13)
                                Case "2"
                                    strGebruik &= "Besigheid " & Chr(10) & Chr(13)
                                Case "3"
                                    strGebruik &= "Profesioneel" & Chr(10) & Chr(13)
                            End Select
                        Else
                            Select Case itemVoertuie.tipe_dek
                                Case "1"
                                    strTipe &= "Comp" & Chr(10) & Chr(13)
                                Case "2"
                                    strTipe &= "BT&T" & Chr(10) & Chr(13)
                                Case "3"
                                    strTipe &= "TP" & Chr(10) & Chr(13)
                            End Select
                            Select Case itemVoertuie.gebruik
                                Case "1"
                                    strGebruik &= "Private " & Chr(10) & Chr(13)
                                Case "2"
                                    strGebruik &= "Business " & Chr(10) & Chr(13)
                                Case "3"
                                    strGebruik &= "Professional" & Chr(10) & Chr(13)
                            End Select
                        End If
                    End If

                Loop
                If connVoertuie.State = ConnectionState.Open Then
                    connVoertuie.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Private Sub FetchAlleRisikoFinalRun()

        strARBeskryf = ""
        dblARDekking = 0
        dblARPremie = 0
        strARItemNr = ""
        strARTipe2 = ""
        strARArnPlaat = ""

        intCtrAR = 0
        'blnVoertuie = False

        Try
            Using connAR As SqlConnection = SqlHelper.GetConnection
                Dim paramAR As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                paramAR.Value = strPolisno

                Dim readerAR As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAlleriskByPolisno", paramAR)
                Do While readerAR.Read
                    Dim itemAR As ALLERISKEntity = New ALLERISKEntity()
                    If readerAR("arnplaat") IsNot DBNull.Value Then
                        itemAR.arnplaat = readerAR("arnplaat")
                    End If
                    If readerAR("beskryf") IsNot DBNull.Value Then
                        itemAR.beskryf = readerAR("beskryf")
                    End If
                    If readerAR("DEKKING") IsNot DBNull.Value Then
                        itemAR.DEKKING = readerAR("DEKKING")
                    End If
                    If readerAR("itemnr") IsNot DBNull.Value Then
                        itemAR.itemnr = readerAR("itemnr")
                    End If
                    If readerAR("Premie") IsNot DBNull.Value Then
                        itemAR.Premie = readerAR("Premie")
                    End If
                    If readerAR("Tipe2") IsNot DBNull.Value Then
                        itemAR.Tipe2 = readerAR("Tipe2")
                    End If
                    If readerAR("pkAllerisk") IsNot DBNull.Value Then
                        itemAR.pkAllerisk = readerAR("pkAllerisk")
                    End If

                    strARBeskryf = itemAR.beskryf
                    dblARDekking = itemAR.DEKKING
                    dblARPremie = itemAR.Premie
                    strARItemNr = itemAR.itemnr
                    strARTipe2 = itemAR.Tipe2
                    strARArnPlaat = itemAR.arnplaat

                    UpdateMDPrintAlle()
                Loop
                If connAR.State = ConnectionState.Open Then
                    connAR.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Public Sub WriteRekon(strPaymentMethod As String)
        Dim intRecordCount As Integer = 0
        'reset totals
        For Me.l = 0 To 55
            GroupTotal(Me.l) = 0
            GrandTotal(Me.l) = 0
            GroupTotNa(Me.l) = 0
            sumNegPremium = 0
        Next
        intI = 0
        For Me.l = 0 To 8
            polCount(Me.l) = 0
        Next
        For Me.l = 0 To 20
            itemCount(Me.l) = 0
        Next
        tmpAreaCode = ""
        intI = 0

        Try
            Using connRekon As SqlConnection = SqlHelper.GetConnection
                Dim paramRekon() As SqlParameter = {New SqlParameter("@Betaalwyse", SqlDbType.NVarChar), _
                                               New SqlParameter("@Versekeraar", SqlDbType.Int)}
                paramRekon(0).Value = strPaymentMethod
                paramRekon(1).Value = glbVersekeraar

                Dim readerRekon As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchItemTotals", paramRekon)

                Do While readerRekon.Read
                    If intRecordCount = 0 Then
                        tmpAreaCode = readerRekon("area_kode")
                    End If

                    Me.lblProcessing.Text = "Processing expected premium: " & readerRekon("polisno")
                    Me.lblProcessing.Refresh()

                    If readerRekon("bet_dat") <= dteMaxBetaalDateAllowed Then
                        If tmpAreaCode <> readerRekon("area_kode") Then
                            'calcGrandTotals
                            calcGrandTotals()

                            'insert totals for area and paymentmethod in rekon table
                            InsertRekon(strPaymentMethod)

                            'reset totals
                            ResetTotals()

                            tmpAreaCode = readerRekon("area_kode")
                        End If

                        intRecordCount = intRecordCount + 1
                        intI = intI + 1

                        'calcGroupTotals
                        GroupTotal(3) += IIf(readerRekon("totVoertuie") Is DBNull.Value, 0, readerRekon("totVoertuie"))
                        GroupTotal(4) += IIf(readerRekon("totWater") Is DBNull.Value, 0, readerRekon("totWater"))
                        GroupTotal(5) += IIf(readerRekon("totAR") Is DBNull.Value, 0, readerRekon("totAR"))
                        GroupTotal(6) += IIf(readerRekon("totHB") Is DBNull.Value, 0, readerRekon("totHB"))
                        GroupTotal(7) += IIf(readerRekon("totHE") Is DBNull.Value, 0, readerRekon("totHE"))
                        GroupTotal(8) += IIf(readerRekon("totHBThatch") Is DBNull.Value, 0, readerRekon("totHBThatch"))
                        GroupTotal(9) += IIf(readerRekon("totHEThatch") Is DBNull.Value, 0, readerRekon("totHEThatch"))
                        GroupTotal(10) += IIf(readerRekon("totEEM") Is DBNull.Value, 0, readerRekon("totEEM"))
                        GroupTotal(11) += IIf(readerRekon("totToeval") Is DBNull.Value, 0, readerRekon("totToeval"))
                        GroupTotal(12) += IIf(readerRekon("subtotaal") Is DBNull.Value, 0, readerRekon("subtotaal"))
                        GroupTotal(14) += IIf(readerRekon("beskerm") Is DBNull.Value, 0, readerRekon("beskerm"))
                        GroupTotal(15) += IIf(readerRekon("sasprem") Is DBNull.Value, 0, readerRekon("sasprem"))
                        GroupTotal(16) += IIf(readerRekon("tv_diens") Is DBNull.Value, 0, readerRekon("tv_diens"))
                        GroupTotal(17) += IIf(readerRekon("polfooi") Is DBNull.Value, 0, readerRekon("polfooi"))
                        GroupTotal(18) += IIf(readerRekon("begrafnis") Is DBNull.Value, 0, readerRekon("begrafnis"))
                        GroupTotal(19) += IIf(readerRekon("plip1") Is DBNull.Value, 0, readerRekon("plip1"))
                        GroupTotal(20) += IIf(readerRekon("courtesyv") Is DBNull.Value, 0, readerRekon("courtesyv"))
                        GroupTotal(21) += IIf(readerRekon("epc") Is DBNull.Value, 0, readerRekon("epc"))
                        GroupTotal(22) += IIf(readerRekon("careassist") Is DBNull.Value, 0, readerRekon("careassist"))
                        GroupTotal(23) += IIf(readerRekon("selfoon") Is DBNull.Value, 0, readerRekon("selfoon"))
                        GroupTotal(24) += IIf(readerRekon("premie") Is DBNull.Value, 0, readerRekon("premie"))
                        GroupTotal(25) += IIf(readerRekon("verwyskommissie") Is DBNull.Value, 0, readerRekon("verwyskommissie"))
                        GroupTotal(26) += IIf(readerRekon("totAddPremie") Is DBNull.Value, 0, readerRekon("totAddPremie"))

                        GroupTotal(28) += IIf(readerRekon("totMotorsAP") Is DBNull.Value, 0, readerRekon("totMotorsAP"))
                        GroupTotal(29) += IIf(readerRekon("totAlleRisikoAP") Is DBNull.Value, 0, readerRekon("totAlleRisikoAP"))
                        GroupTotal(30) += IIf(readerRekon("totHBAP") Is DBNull.Value, 0, readerRekon("totHBAP"))
                        GroupTotal(31) += IIf(readerRekon("totHEAP") Is DBNull.Value, 0, readerRekon("totHEAP"))
                        GroupTotal(32) += IIf(readerRekon("totHBGrasAP") Is DBNull.Value, 0, readerRekon("totHBGrasAP"))
                        GroupTotal(33) += IIf(readerRekon("totHEGrasAP") Is DBNull.Value, 0, readerRekon("totHEGrasAP"))
                        GroupTotal(34) += IIf(readerRekon("totToevalEEMAP") Is DBNull.Value, 0, readerRekon("totToevalEEMAP"))
                        GroupTotal(35) += IIf(readerRekon("totToevalBreekAP") Is DBNull.Value, 0, readerRekon("totToevalBreekAP"))
                        GroupTotal(36) += IIf(readerRekon("totWaterleweAP") Is DBNull.Value, 0, readerRekon("totWaterleweAP"))
                        GroupTotal(37) += IIf(readerRekon("totBegrafnisAP") Is DBNull.Value, 0, readerRekon("totBegrafnisAP"))
                        GroupTotal(38) += IIf(readerRekon("totSasriaAP") Is DBNull.Value, 0, readerRekon("totSasriaAP"))
                        GroupTotal(39) += IIf(readerRekon("totPolisfooiAP") Is DBNull.Value, 0, readerRekon("totPolisfooiAP"))
                        GroupTotal(40) += IIf(readerRekon("totPlipAP") Is DBNull.Value, 0, readerRekon("totPlipAP"))
                        GroupTotal(41) += IIf(readerRekon("totTVDiensAP") Is DBNull.Value, 0, readerRekon("totTVDiensAP"))
                        GroupTotal(42) += IIf(readerRekon("totBeskermAP") Is DBNull.Value, 0, readerRekon("totBeskermAP"))
                        GroupTotal(43) += IIf(readerRekon("totCourtesyvAP") Is DBNull.Value, 0, readerRekon("totCourtesyvAP"))
                        GroupTotal(44) += IIf(readerRekon("totEPCAP") Is DBNull.Value, 0, readerRekon("totEPCAP"))
                        GroupTotal(45) += IIf(readerRekon("totCareAssistAP") Is DBNull.Value, 0, readerRekon("totCareAssistAP"))
                        GroupTotal(46) += IIf(readerRekon("totSelfoonAP") Is DBNull.Value, 0, readerRekon("totSelfoonAP"))
                        GroupTotal(47) += IIf(readerRekon("totSpesialeKortingAP") Is DBNull.Value, 0, readerRekon("totSpesialeKortingAP"))

                        GroupTotal(48) += IIf(readerRekon("Pakketitem1") Is DBNull.Value, 0, readerRekon("Pakketitem1"))
                        GroupTotal(49) += IIf(readerRekon("Pakketitem2") Is DBNull.Value, 0, readerRekon("Pakketitem2"))
                        GroupTotal(50) += IIf(readerRekon("Pakketitem3") Is DBNull.Value, 0, readerRekon("Pakketitem3"))
                        GroupTotal(51) += IIf(readerRekon("Pakketitem4") Is DBNull.Value, 0, readerRekon("Pakketitem4"))
                        GroupTotal(52) += IIf(readerRekon("totPakketitem1AP") Is DBNull.Value, 0, readerRekon("totPakketitem1AP"))
                        GroupTotal(53) += IIf(readerRekon("totPakketitem2AP") Is DBNull.Value, 0, readerRekon("totPakketitem2AP"))
                        GroupTotal(54) += IIf(readerRekon("totPakketitem3AP") Is DBNull.Value, 0, readerRekon("totPakketitem3AP"))
                        GroupTotal(55) += IIf(readerRekon("totPakketitem4AP") Is DBNull.Value, 0, readerRekon("totPakketitem4AP"))

                        GroupTotal(27) += IIf(readerRekon("premie2") Is DBNull.Value, 0, readerRekon("premie2"))

                        'calculate group total after discount
                        GroupTotNa(3) += Math.Round((IIf(readerRekon("totVoertuie") Is DBNull.Value, 0, readerRekon("totVoertuie")) * readerRekon("eispers")), 2)
                        GroupTotNa(4) += Math.Round((IIf(readerRekon("totWater") Is DBNull.Value, 0, readerRekon("totWater")) * readerRekon("eispers")), 2)
                        GroupTotNa(5) += Math.Round((IIf(readerRekon("totAR") Is DBNull.Value, 0, readerRekon("totAR")) * readerRekon("eispers")), 2)
                        GroupTotNa(6) += Math.Round((IIf(readerRekon("totHB") Is DBNull.Value, 0, readerRekon("totHB")) * readerRekon("eispers")), 2)
                        GroupTotNa(7) += Math.Round((IIf(readerRekon("totHE") Is DBNull.Value, 0, readerRekon("totHE")) * readerRekon("eispers")), 2)
                        GroupTotNa(8) += Math.Round((IIf(readerRekon("totHBThatch") Is DBNull.Value, 0, readerRekon("totHBThatch")) * readerRekon("eispers")), 2)
                        GroupTotNa(9) += Math.Round((IIf(readerRekon("totHEThatch") Is DBNull.Value, 0, readerRekon("totHEThatch")) * readerRekon("eispers")), 2)
                        GroupTotNa(10) += Math.Round((IIf(readerRekon("totEEM") Is DBNull.Value, 0, readerRekon("totEEM")) * readerRekon("eispers")), 2)
                        GroupTotNa(11) += Math.Round((IIf(readerRekon("totToeval") Is DBNull.Value, 0, readerRekon("totToeval")) * readerRekon("eispers")), 2)
                        GroupTotNa(12) += GroupTotNa(3) + GroupTotNa(4) + GroupTotNa(5) + GroupTotNa(6) + GroupTotNa(7) + GroupTotNa(8) + GroupTotNa(9) + GroupTotNa(10) + GroupTotNa(11)

                        'sun negative premiums
                        If readerRekon("premie2") < 0 Then
                            sumNegPremium += readerRekon("Premie2")
                        End If

                        'itemcount
                        itemCount(0) += readerRekon("countVoertuie")
                        itemCount(1) += readerRekon("countAR")
                        itemCount(2) += readerRekon("countHB")
                        itemCount(3) += readerRekon("countHE")
                        itemCount(4) += readerRekon("countHBThatch")
                        itemCount(5) += readerRekon("countHEThatch")
                        itemCount(6) += readerRekon("countEEM")
                        itemCount(7) += readerRekon("countToeval")
                        itemCount(8) += readerRekon("countWL")
                        If readerRekon("sasprem") > 0 Then
                            itemCount(9) += 1
                        End If
                        If readerRekon("tv_diens") > 0 Then
                            itemCount(10) += 1
                        End If
                        If readerRekon("begrafnis") > 0 Then
                            itemCount(11) += 1
                        End If
                        If readerRekon("plip1") > 0 Then
                            itemCount(12) += 1
                        End If
                        If readerRekon("courtesyv") > 0 Then
                            itemCount(13) += 1
                        End If
                        If readerRekon("epc") > 0 Then
                            itemCount(14) += 1
                        End If
                        If readerRekon("careassist") > 0 Then
                            itemCount(15) += 1
                        End If
                        If readerRekon("selfoon") > 0 Then
                            itemCount(16) += 1
                        End If
                        If readerRekon("pakketitem1") > 0 Then
                            itemCount(17) += 1
                        End If
                        If readerRekon("pakketitem2") > 0 Then
                            itemCount(18) += 1
                        End If
                        If readerRekon("pakketitem3") > 0 Then
                            itemCount(19) += 1
                        End If
                        If readerRekon("pakketitem4") > 0 Then
                            itemCount(20) += 1
                        End If

                        'polcount
                        If readerRekon("countVoertuie") > 0 Then
                            polCount(0) += 1
                        End If
                        If readerRekon("countAR") > 0 Then
                            polCount(1) += 1
                        End If
                        If readerRekon("countHB") > 0 Then
                            polCount(2) += 1
                        End If
                        If readerRekon("countHE") > 0 Then
                            polCount(3) += 1
                        End If
                        If readerRekon("countHBThatch") > 0 Then
                            polCount(4) += 1
                        End If
                        If readerRekon("countHEThatch") > 0 Then
                            polCount(5) += 1
                        End If
                        If readerRekon("countEEM") > 0 Then
                            polCount(6) += 1
                        End If
                        If readerRekon("countToeval") > 0 Then
                            polCount(7) += 1
                        End If
                        If readerRekon("countWL") > 0 Then
                            polCount(8) += 1
                        End If
                    End If
                Loop

                'calcGrandTotals
                calcGrandTotals()

                'insert totals for area and paymentmethod in rekon table
                If tmpAreaCode <> "" Then
                    InsertRekon(strPaymentMethod)
                End If

                'reset totals
                ResetTotals()
                If connRekon.State = ConnectionState.Open Then
                    connRekon.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub calcGrandTotals()
        For Me.l = 3 To 55
            GrandTotal(Me.l) += GroupTotal(Me.l)
        Next
    End Sub
    Private Sub ResetTotals()
        For Me.l = 0 To 55
            GroupTotal(Me.l) = 0
            GroupTotNa(Me.l) = 0
            sumNegPremium = 0
        Next
        intI = 0
        For Me.l = 0 To 8
            polCount(Me.l) = 0
        Next
        For Me.l = 0 To 20
            itemCount(Me.l) = 0
        Next
    End Sub
    Private Sub InsertRekon(strPaymentMethod As String)
        Dim intfkBetaalwyse As Integer

        Select Case Trim(strPaymentMethod)
            Case "1"
                intfkBetaalwyse = 1
            Case "2"
                intfkBetaalwyse = 2
            Case "3"
                intfkBetaalwyse = 3
            Case "4"
                intfkBetaalwyse = 4
            Case "5"
                intfkBetaalwyse = 5
            Case "6"
                intfkBetaalwyse = 6
        End Select

        Try
            Using connRekon1 As SqlConnection = SqlHelper.GetConnection

                Dim paramsRekon1() As SqlParameter = {New SqlParameter("@area", SqlDbType.NVarChar), _
                                                        New SqlParameter("@Jaar", SqlDbType.Int), _
                                                        New SqlParameter("@Maand", SqlDbType.Int), _
                                                        New SqlParameter("@MTPrem", SqlDbType.Money), _
                                                        New SqlParameter("@ARPrem", SqlDbType.Money), _
                                                        New SqlParameter("@HBGewPrem", SqlDbType.Money), _
                                                        New SqlParameter("@HEGewPrem", SqlDbType.Money), _
                                                        New SqlParameter("@HBGrasprem", SqlDbType.Money), _
                                                        New SqlParameter("@HEGrasprem", SqlDbType.Money), _
                                                        New SqlParameter("@Tselekprem", SqlDbType.Money), _
                                                        New SqlParameter("@tsgewprem", SqlDbType.Money), _
                                                        New SqlParameter("@WLPrem", SqlDbType.Money), _
                                                        New SqlParameter("@TOTPrem", SqlDbType.Money), _
                                                        New SqlParameter("@BeskermingPrem", SqlDbType.Money), _
                                                        New SqlParameter("@Sasriaprem", SqlDbType.Money), _
                                                        New SqlParameter("@TVDiensprem", SqlDbType.Money), _
                                                        New SqlParameter("@PFPrem", SqlDbType.Money), _
                                                        New SqlParameter("@Begrafnisprem", SqlDbType.Money), _
                                                        New SqlParameter("@Plipprem", SqlDbType.Money), _
                                                        New SqlParameter("@Geleentheidsmotorprem", SqlDbType.Money), _
                                                        New SqlParameter("@EPCPrem", SqlDbType.Money), _
                                                        New SqlParameter("@CAPrem", SqlDbType.Money), _
                                                        New SqlParameter("@Selfoonprem", SqlDbType.Money), _
                                                        New SqlParameter("@Mediesprem", SqlDbType.Money), _
                                                        New SqlParameter("@PremienaKorting", SqlDbType.Money), _
                                                        New SqlParameter("@PremievoorKorting", SqlDbType.Money), _
                                                        New SqlParameter("@SpesialeKorting", SqlDbType.Money), _
                                                        New SqlParameter("@Addisionelepremie", SqlDbType.Money), _
                                                        New SqlParameter("@MotorsAP", SqlDbType.Money), _
                                                        New SqlParameter("@AlleRisikoAP", SqlDbType.Money), _
                                                        New SqlParameter("@HBAP", SqlDbType.Money), _
                                                        New SqlParameter("@HEAP", SqlDbType.Money), _
                                                        New SqlParameter("@HBGrasAP", SqlDbType.Money), _
                                                        New SqlParameter("@HEGrasap", SqlDbType.Money), _
                                                        New SqlParameter("@ToevalEEMAP", SqlDbType.Money), _
                                                        New SqlParameter("@ToevalBreekAP", SqlDbType.Money), _
                                                        New SqlParameter("@WaterleweAP", SqlDbType.Money), _
                                                        New SqlParameter("@BegrafnisAP", SqlDbType.Money), _
                                                        New SqlParameter("@SasriaAP", SqlDbType.Money), _
                                                        New SqlParameter("@PolisfooiAP", SqlDbType.Money), _
                                                        New SqlParameter("@PlipAP", SqlDbType.Money), _
                                                        New SqlParameter("@TVDiensAP", SqlDbType.Money), _
                                                        New SqlParameter("@BeskermAP", SqlDbType.Money), _
                                                        New SqlParameter("@CourtesyvAP", SqlDbType.Money), _
                                                        New SqlParameter("@EPCAP", SqlDbType.Money), _
                                                        New SqlParameter("@CareAssistAP", SqlDbType.Money), _
                                                        New SqlParameter("@selfoonap", SqlDbType.Money), _
                                                        New SqlParameter("@SpesialeKortingAP", SqlDbType.Money), _
                                                        New SqlParameter("@Pakketitem1", SqlDbType.Money), _
                                                        New SqlParameter("@Pakketitem2", SqlDbType.Money), _
                                                        New SqlParameter("@Pakketitem3", SqlDbType.Money), _
                                                        New SqlParameter("@Pakketitem4", SqlDbType.Money), _
                                                        New SqlParameter("@Pakketitem1AP", SqlDbType.Money), _
                                                        New SqlParameter("@Pakketitem2AP", SqlDbType.Money), _
                                                        New SqlParameter("@Pakketitem3AP", SqlDbType.Money), _
                                                        New SqlParameter("@Pakketitem4AP", SqlDbType.Money), _
                                                        New SqlParameter("@AantalPolisse", SqlDbType.Int), _
                                                        New SqlParameter("@AantalVoertuie", SqlDbType.Int), _
                                                        New SqlParameter("@AantalHomeAssistance", SqlDbType.Int), _
                                                        New SqlParameter("@AantalPakketitem1", SqlDbType.Int), _
                                                        New SqlParameter("@AantalAR", SqlDbType.Int), _
                                                        New SqlParameter("@AantalHB", SqlDbType.Int), _
                                                        New SqlParameter("@AantalHE", SqlDbType.Int), _
                                                        New SqlParameter("@AantalHBGras", SqlDbType.Int), _
                                                        New SqlParameter("@AantalHEGras", SqlDbType.Int), _
                                                        New SqlParameter("@AantalTSElek", SqlDbType.Int), _
                                                        New SqlParameter("@AantalTS", SqlDbType.Int), _
                                                        New SqlParameter("@AantalWL", SqlDbType.Int), _
                                                        New SqlParameter("@AantalSasria", SqlDbType.Int), _
                                                        New SqlParameter("@AantalTV", SqlDbType.Int), _
                                                        New SqlParameter("@AantalBegrafnis", SqlDbType.Int), _
                                                        New SqlParameter("@AantalPlip", SqlDbType.Int), _
                                                        New SqlParameter("@AantalGeleentheidsmotor", SqlDbType.Int), _
                                                        New SqlParameter("@AantalCare", SqlDbType.Int), _
                                                        New SqlParameter("@AantalSelfoon", SqlDbType.Int), _
                                                        New SqlParameter("@AantalPakketitem2", SqlDbType.Int), _
                                                        New SqlParameter("@AantalPakketitem3", SqlDbType.Int), _
                                                        New SqlParameter("@AantalPakketitem4", SqlDbType.Int), _
                                                        New SqlParameter("@AantalVoertuiePol", SqlDbType.Int), _
                                                        New SqlParameter("@AantalARPol", SqlDbType.Int), _
                                                        New SqlParameter("@AantalHBPol", SqlDbType.Int), _
                                                        New SqlParameter("@AantalHEPol", SqlDbType.Int), _
                                                        New SqlParameter("@AantalHBGrasPol", SqlDbType.Int), _
                                                        New SqlParameter("@AantalHEGrasPol", SqlDbType.Int), _
                                                        New SqlParameter("@AantalTSElekPol", SqlDbType.Int), _
                                                        New SqlParameter("@AantalTSPol", SqlDbType.Int), _
                                                        New SqlParameter("@AantalWLPol", SqlDbType.Int), _
                                                        New SqlParameter("@fkBetaalwyse", SqlDbType.Int)}

                paramsRekon1(0).Value = tmpAreaCode                                                             'area       
                paramsRekon1(1).Value = intJaar                                                                 'jaar           
                paramsRekon1(2).Value = intMaand                                                                'maand
                paramsRekon1(3).Value = GroupTotNa(3)
                paramsRekon1(4).Value = GroupTotNa(5)
                paramsRekon1(5).Value = GroupTotNa(6)
                paramsRekon1(6).Value = GroupTotNa(7)
                paramsRekon1(7).Value = GroupTotNa(8)
                paramsRekon1(8).Value = GroupTotNa(9)
                paramsRekon1(9).Value = GroupTotNa(10)
                paramsRekon1(10).Value = GroupTotNa(11)
                paramsRekon1(11).Value = GroupTotNa(4)
                paramsRekon1(12).Value = GroupTotNa(3) + GroupTotNa(5) + GroupTotNa(6) + GroupTotNa(7) + GroupTotNa(8) + GroupTotNa(9) + GroupTotNa(10) + GroupTotNa(11) + GroupTotNa(4)
                paramsRekon1(13).Value = GroupTotal(14)
                paramsRekon1(14).Value = GroupTotal(15)
                paramsRekon1(15).Value = GroupTotal(16)
                paramsRekon1(16).Value = GroupTotal(17)
                paramsRekon1(17).Value = GroupTotal(18)
                paramsRekon1(18).Value = GroupTotal(19)
                paramsRekon1(19).Value = GroupTotal(20)
                paramsRekon1(20).Value = GroupTotal(21)
                paramsRekon1(21).Value = GroupTotal(22)
                paramsRekon1(22).Value = GroupTotal(23)
                paramsRekon1(23).Value = 0
                paramsRekon1(24).Value = GroupTotal(27)
                paramsRekon1(25).Value = GroupTotal(24)
                paramsRekon1(26).Value = GroupTotal(25)
                paramsRekon1(27).Value = GroupTotal(26)
                paramsRekon1(28).Value = GroupTotal(28)
                paramsRekon1(29).Value = GroupTotal(29)
                paramsRekon1(30).Value = GroupTotal(30)
                paramsRekon1(31).Value = GroupTotal(31)
                paramsRekon1(32).Value = GroupTotal(32)
                paramsRekon1(33).Value = GroupTotal(33)
                paramsRekon1(34).Value = GroupTotal(34)
                paramsRekon1(35).Value = GroupTotal(35)
                paramsRekon1(36).Value = GroupTotal(36)
                paramsRekon1(37).Value = GroupTotal(37)
                paramsRekon1(38).Value = GroupTotal(38)
                paramsRekon1(39).Value = GroupTotal(39)
                paramsRekon1(40).Value = GroupTotal(40)
                paramsRekon1(41).Value = GroupTotal(41)
                paramsRekon1(42).Value = GroupTotal(42)
                paramsRekon1(43).Value = GroupTotal(43)
                paramsRekon1(44).Value = GroupTotal(44)
                paramsRekon1(45).Value = GroupTotal(45)
                paramsRekon1(46).Value = GroupTotal(46)
                paramsRekon1(47).Value = GroupTotal(47)
                paramsRekon1(48).Value = GroupTotal(48)
                paramsRekon1(49).Value = GroupTotal(49)
                paramsRekon1(50).Value = GroupTotal(50)
                paramsRekon1(51).Value = GroupTotal(51)
                paramsRekon1(52).Value = GroupTotal(52)
                paramsRekon1(53).Value = GroupTotal(53)
                paramsRekon1(54).Value = GroupTotal(54)
                paramsRekon1(55).Value = GroupTotal(55)
                paramsRekon1(56).Value = intI
                paramsRekon1(57).Value = itemCount(0)
                paramsRekon1(58).Value = itemCount(14)
                paramsRekon1(59).Value = itemCount(17)
                paramsRekon1(60).Value = itemCount(1)
                paramsRekon1(61).Value = itemCount(2)
                paramsRekon1(62).Value = itemCount(3)
                paramsRekon1(63).Value = itemCount(4)
                paramsRekon1(64).Value = itemCount(5)
                paramsRekon1(65).Value = itemCount(6)
                paramsRekon1(66).Value = itemCount(7)
                paramsRekon1(67).Value = itemCount(8)
                paramsRekon1(68).Value = itemCount(9)
                paramsRekon1(69).Value = itemCount(10)
                paramsRekon1(70).Value = itemCount(11)
                paramsRekon1(71).Value = itemCount(12)
                paramsRekon1(72).Value = itemCount(13)
                paramsRekon1(73).Value = itemCount(15)
                paramsRekon1(74).Value = itemCount(16)
                paramsRekon1(75).Value = itemCount(18)
                paramsRekon1(76).Value = itemCount(19)
                paramsRekon1(77).Value = itemCount(20)
                paramsRekon1(78).Value = polCount(0)
                paramsRekon1(79).Value = polCount(1)
                paramsRekon1(80).Value = polCount(2)
                paramsRekon1(81).Value = polCount(3)
                paramsRekon1(82).Value = polCount(4)
                paramsRekon1(83).Value = polCount(5)
                paramsRekon1(84).Value = polCount(6)
                paramsRekon1(85).Value = polCount(7)
                paramsRekon1(86).Value = polCount(8)
                paramsRekon1(87).Value = intfkBetaalwyse

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.InsertRekon", paramsRekon1)
                If connRekon1.State = ConnectionState.Open Then
                    connRekon1.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Private Sub RunPlip(strBetwyse As String)
        Diagnostics.Debug.WriteLine("plip" & Now)
        Me.lblProcessing.Text = "Writing Plip file"
        Me.lblProcessing.Refresh()

        Try
            Using connPlip As SqlConnection = SqlHelper.GetConnection
                Dim paramPlip() As SqlParameter = {New SqlParameter("@Bet_dat", SqlDbType.Date), _
                                               New SqlParameter("@Bet_wyse", SqlDbType.NVarChar)}

                paramPlip(0).Value = dteExpPremiumPlusMonth
                paramPlip(1).Value = strBetwyse

                Dim readerPlip As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "plip.FetchPersoonlPlip", paramPlip)

                Do While readerPlip.Read
                    Try
                        Using connPlipUpdate As SqlConnection = SqlHelper.GetConnection

                            Dim paramsPlipUpdate() As SqlParameter = {New SqlParameter("@Versekerde", SqlDbType.NVarChar), _
                                                            New SqlParameter("@Voorl", SqlDbType.NVarChar), _
                                                            New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                            New SqlParameter("@Bet_wyse", SqlDbType.NVarChar), _
                                                            New SqlParameter("@plip", SqlDbType.Money), _
                                                            New SqlParameter("@afsluit_dat", SqlDbType.Date), _
                                                            New SqlParameter("@trans_dat", SqlDbType.DateTime), _
                                                            New SqlParameter("@area", SqlDbType.NVarChar)}

                            paramsPlipUpdate(0).Value = readerPlip("versekerde")
                            paramsPlipUpdate(1).Value = readerPlip("voorl")
                            paramsPlipUpdate(2).Value = readerPlip("polisno")
                            paramsPlipUpdate(3).Value = readerPlip("bet_wyse")
                            paramsPlipUpdate(4).Value = readerPlip("plip1")
                            paramsPlipUpdate(5).Value = System.String.Format("{0:dd}/{0:MM}/{0:yyyy}", dteExpPremium)
                            paramsPlipUpdate(6).Value = Now
                            paramsPlipUpdate(7).Value = readerPlip("area")

                            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "plip.InsertPlip", paramsPlipUpdate)
                            If connPlipUpdate.State = ConnectionState.Open Then
                                connPlipUpdate.Close()
                            End If
                        End Using
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                        Exit Sub
                    End Try
                Loop

                If connPlip.State = ConnectionState.Open Then
                    connPlip.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Diagnostics.Debug.WriteLine("plip" & Now)
    End Sub
    Private Sub GetBranch()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchTak")

                If reader.Read Then
                    strTak = reader("Tak_naam")
                    strTak_afkorting = reader("tak_afkorting")
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub RunCare(strBetwyse As String, dblCarePremie As Decimal)
        Dim strFile As String = ""
        Dim strFilePath As String
        Dim strOutput As String = ""
        Dim blnDoNotUpdate As Boolean
        Dim strPaymentMethodCare As String

        Diagnostics.Debug.WriteLine("care" & Now)
        Me.lblProcessing.Text = "Writing Care file"
        Me.lblProcessing.Refresh()

        GetBranch()

        'skryf data na leer
        Select Case strBetwyse
            Case "3"
                If strTak = "Bloemfontein" Then
                    If intSalArea = 2 Then
                        If dblCarePremie = 5 Then
                            strFile = strTak_afkorting & "_RoadAssistStand_uv.csv"
                        Else
                            strFile = strTak_afkorting & "_RoadAssist_uv.csv"
                        End If
                    End If
                    If intSalArea = 3 Then
                        If dblCarePremie = 5 Then
                            strFile = strTak_afkorting & "_RoadAssistStand_sut.csv"
                        Else
                            strFile = strTak_afkorting & "_RoadAssist_sut.csv"
                        End If
                    End If
                Else
                    If intSalArea = 2 Then
                        If dblCarePremie = 5 Then
                            strFile = strTak_afkorting & "_RoadAssistStand_puk.csv"
                        Else
                            strFile = strTak_afkorting & "_RoadAssist_puk.csv"
                        End If
                    End If
                End If
            Case Else
                If dblCarePremie = 5 Then
                    strFile = strTak_afkorting & "_RoadAssistStand_als.csv"
                Else
                    strFile = strTak_afkorting & "_RoadAssist_als.csv"
                End If
        End Select

        strFilePath = strMultidataPath & "\" & strFile

        Dim objWriter As New System.IO.StreamWriter(strFilePath)

        If (Not System.IO.File.Exists(strFilePath)) Then
            Try
                System.IO.File.Create(strFilePath)
            Catch ex As Exception
                MsgBox("Road Assist file can not be created", vbInformation)
            End Try
        End If
        If System.IO.File.Exists(strFilePath) = True Then
            Try
                Using connCare As SqlConnection = SqlHelper.GetConnection
                    Dim paramCare() As SqlParameter = {New SqlParameter("@Bet_wyse", SqlDbType.NVarChar), _
                                                   New SqlParameter("@CarePremie", SqlDbType.Money), _
                                                      New SqlParameter("@areabesk", SqlDbType.NVarChar), _
                                                       New SqlParameter("@Bet_dat", SqlDbType.Date)}

                    paramCare(0).Value = strBetwyse
                    paramCare(1).Value = dblCarePremie
                    paramCare(2).Value = Me.cmbArea.Text
                    paramCare(3).Value = dteExpPremiumPlusMonth

                    Dim readerCare As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Care.FetchPersoonlCare", paramCare)

                    strOutput = """ID No"",""Surname"",""Initials"",""First Name"",""Policynumber"",""Title"",""Address"",""P Address"",""Email Address""," _
                            & """Home Tel"",""Work Tel"",""Cell Tel"",""Contact Tel"",""Status"",""AddressLn2"",""AddressLn3"",""AdderssLn4"",""AddressLn5""," _
                            & """PAddressLn2"",""PAdderssLn3"",""PAddressLn4"",""PAddressLn5"",""Product Type"",""RegNo1"",""Year1"",""Type1"""
                    objWriter.WriteLine(strOutput)

                    Do While readerCare.Read
                        blnDoNotUpdate = False
                        Application.DoEvents()

                        strPaymentMethodCare = readerCare("bet_wyse")
                        If strPaymentMethodCare = "6" Then
                            Try
                                Using conn As SqlConnection = SqlHelper.GetConnection
                                    Dim param() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                                   New SqlParameter("@datumbegin", SqlDbType.DateTime), _
                                                                   New SqlParameter("@datumeindig", SqlDbType.DateTime)}

                                    param(0).Value = readerCare("polisno")
                                    param(1).Value = dteExpPremiumPlusMonth
                                    param(2).Value = dteExpPremiumPlusMonth

                                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchLangtermynPolis", param)

                                    If reader.Read Then
                                        blnDoNotUpdate = False
                                    Else
                                        blnDoNotUpdate = True
                                    End If
                                    If conn.State = ConnectionState.Open Then
                                        conn.Close()
                                    End If
                                End Using
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Critical)
                            End Try
                        End If
                        If blnDoNotUpdate = False Then
                            Try
                                Using connCareUpdate As SqlConnection = SqlHelper.GetConnection

                                    Dim paramsCareUpdate() As SqlParameter = {New SqlParameter("@Versekerde", SqlDbType.NVarChar), _
                                                                    New SqlParameter("@Voorl", SqlDbType.NVarChar), _
                                                                    New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                                    New SqlParameter("@Bet_wyse", SqlDbType.NVarChar), _
                                                                    New SqlParameter("@premie", SqlDbType.Money), _
                                                                    New SqlParameter("@afsluit_dat", SqlDbType.Date), _
                                                                    New SqlParameter("@trans_dat", SqlDbType.DateTime), _
                                                                    New SqlParameter("@area", SqlDbType.NVarChar), _
                                                                    New SqlParameter("@titelnum", SqlDbType.Int), _
                                                                    New SqlParameter("@sel_tel", SqlDbType.NVarChar), _
                                                                    New SqlParameter("@id_nom", SqlDbType.NVarChar), _
                                                                    New SqlParameter("@taknaam", SqlDbType.NVarChar), _
                                                                    New SqlParameter("@huis_tel2", SqlDbType.NVarChar), _
                                                                    New SqlParameter("@werk_tel2", SqlDbType.NVarChar)}

                                    paramsCareUpdate(0).Value = readerCare("versekerde")
                                    paramsCareUpdate(1).Value = readerCare("voorl")
                                    paramsCareUpdate(2).Value = readerCare("polisno")
                                    paramsCareUpdate(3).Value = readerCare("bet_wyse")
                                    paramsCareUpdate(4).Value = readerCare("careassist")
                                    paramsCareUpdate(5).Value = System.String.Format("{0:dd}/{0:MM}/{0:yyyy}", dteExpPremium)
                                    paramsCareUpdate(6).Value = Now
                                    paramsCareUpdate(7).Value = readerCare("area")
                                    paramsCareUpdate(8).Value = readerCare("titelnum")
                                    paramsCareUpdate(9).Value = readerCare("sel_tel")
                                    paramsCareUpdate(10).Value = readerCare("id_nom")
                                    paramsCareUpdate(11).Value = strTak
                                    paramsCareUpdate(12).Value = IIf(readerCare("huis_tel2") Is DBNull.Value, " ", readerCare("huis_tel2"))
                                    paramsCareUpdate(13).Value = IIf(readerCare("werk_tel2") Is DBNull.Value, " ", readerCare("werk_tel2"))

                                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "care.Insertcareheader", paramsCareUpdate)

                                    If connCareUpdate.State = ConnectionState.Open Then
                                        connCareUpdate.Close()
                                    End If
                                End Using
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Critical)
                                Exit Sub
                            End Try

                            Try
                                Using conn As SqlConnection = SqlHelper.GetConnection
                                    Dim param() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar)}

                                    param(0).Value = readerCare("polisno")

                                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuie_For_PremieDetails", param)

                                    Do While reader.Read
                                        If reader("tipe") = "1" Or reader("tipe") = "2" Or reader("tipe") = "3" Or reader("tipe") = "6" Then
                                            Try
                                                Using connCareDetails As SqlConnection = SqlHelper.GetConnection

                                                    Dim paramsCareDetails() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                                                    New SqlParameter("@tipe", SqlDbType.NVarChar), _
                                                                                    New SqlParameter("@jaar", SqlDbType.NVarChar), _
                                                                                    New SqlParameter("@maak", SqlDbType.NVarChar), _
                                                                                    New SqlParameter("@besk", SqlDbType.NVarChar), _
                                                                                    New SqlParameter("@n_plaat", SqlDbType.NVarChar), _
                                                                                    New SqlParameter("@kode", SqlDbType.NVarChar), _
                                                                                    New SqlParameter("@afsluit_dat", SqlDbType.Date)}

                                                    paramsCareDetails(0).Value = reader("polisno")
                                                    paramsCareDetails(1).Value = IIf(reader("tipe") Is DBNull.Value, " ", reader("tipe"))
                                                    paramsCareDetails(2).Value = IIf(reader("jaar") Is DBNull.Value, "0", reader("jaar"))
                                                    paramsCareDetails(3).Value = IIf(reader("maak") Is DBNull.Value, "None", reader("maak"))
                                                    paramsCareDetails(4).Value = IIf(reader("besk") Is DBNull.Value, "None", reader("besk"))
                                                    paramsCareDetails(5).Value = IIf(reader("n_plaat") Is DBNull.Value, " ", reader("n_plaat"))
                                                    paramsCareDetails(6).Value = reader("kode")
                                                    paramsCareDetails(7).Value = System.String.Format("{0:dd}/{0:MM}/{0:yyyy}", dteExpPremium)

                                                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "care.Insertcaredetail", paramsCareDetails)

                                                    strOutput = """" & readerCare("id_nom") & """,""" & readerCare("versekerde") & """,""" & readerCare("voorl") & """,""" & IIf(readerCare("noemnaam") Is DBNull.Value, "", readerCare("noemnaam")) & """," _
                                                        & """" & readerCare("polisno") & """,""" & readerCare("engelsetitel") & """,""" & reader("adres") & """,""" & readerCare("adres") & """,""" & readerCare("email") & """," _
                                                        & """" & readerCare("huis_tel2") & """,""" & readerCare("werk_tel2") & """,""" & readerCare("sel_tel") & ""","""",""" & IIf(readerCare("gekans"), "Cancelled", "Active") & """," _
                                                        & """" & reader("adres2") & """,""" & reader("voorstad") & """,""" & reader("stad") & """,""" & reader("poskode") & """," _
                                                        & """" & readerCare("adres4") & """,""" & readerCare("adres1") & """,""" & readerCare("adres3") & """,""" & readerCare("adres2") & """," _
                                                        & """" & strTak & """,""" & reader("n_plaat") & """,""" & reader("eeu") & reader("jaar") & """," _
                                                        & """" & StrConv(reader("maak"), vbProperCase) & " " & StrConv(reader("besk"), vbProperCase) & """"

                                                    objWriter.WriteLine(strOutput)

                                                    If connCareDetails.State = ConnectionState.Open Then
                                                        connCareDetails.Close()
                                                    End If
                                                End Using
                                            Catch ex As Exception
                                                MsgBox(ex.Message, MsgBoxStyle.Critical)
                                                Exit Sub
                                            End Try
                                        End If
                                    Loop

                                    If conn.State = ConnectionState.Open Then
                                        conn.Close()
                                    End If
                                End Using
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Critical)
                            End Try
                        End If

                    Loop

                    objWriter.Close()

                    If connCare.State = ConnectionState.Open Then
                        connCare.Close()
                    End If
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
        Diagnostics.Debug.WriteLine("care" & Now)
    End Sub

    Private Sub RunHomeAssist(strBetwyse As String)
        Dim strFile As String = ""
        Dim strFilePath As String
        Dim strOutput As String = ""
        Dim blnDoNotUpdate As Boolean
        Dim strPaymentMethodCare As String
        Dim strRisikoAdres As String
        Dim strRisikoAdres2 As String
        Dim strRisikoAdres3 As String
        Dim strRisikoAdres4 As String
        Dim strRisikoAdresPoskode As String
        Dim blnAssignedHouseDesc As Boolean

        Diagnostics.Debug.WriteLine("epc" & Now)
        GetBranch()

        Me.lblProcessing.Text = "Writing Home Assist file"
        Me.lblProcessing.Refresh()

        'skryf data na leer
        Select Case strBetwyse
            Case "3"
                If strTak = "Bloemfontein" Then
                    If intSalArea = 2 Then
                        strFile = strTak_afkorting & "_HomeAssist_uv.csv"
                    End If
                    If intSalArea = 3 Then
                        strFile = strTak_afkorting & "_HomeAssist_sut.csv"
                    End If
                Else
                    If intSalArea = 2 Then
                        strFile = strTak_afkorting & "_HomeAssist_puk.csv"
                    End If
                End If
            Case Else
                strFile = strTak_afkorting & "_HomeAssist_als.csv"
        End Select

        strFilePath = strMultidataPath & "\" & strFile

        Dim objWriter As New System.IO.StreamWriter(strFilePath)

        If (Not System.IO.File.Exists(strFilePath)) Then
            Try
                System.IO.File.Create(strFilePath)
            Catch ex As Exception
                MsgBox("Road Assist file can not be created", vbInformation)
            End Try
        End If
        If System.IO.File.Exists(strFilePath) = True Then
            Try
                Using connEPC As SqlConnection = SqlHelper.GetConnection
                    Dim paramEPC() As SqlParameter = {New SqlParameter("@Bet_wyse", SqlDbType.NVarChar), _
                                                      New SqlParameter("@areabesk", SqlDbType.NVarChar), _
                                                       New SqlParameter("@Bet_dat", SqlDbType.Date)}

                    paramEPC(0).Value = strBetwyse
                    paramEPC(1).Value = Me.cmbArea.Text
                    paramEPC(2).Value = dteExpPremiumPlusMonth

                    Dim readerEPC As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "EPC.FetchPersoonlEPC", paramEPC)

                    strOutput = """ID No"",""Surname"",""Initials"",""First Name"",""Policynumber"",""Title"",""Address"",""P Address"",""Email Address""," _
                            & """Home Tel"",""Work Tel"",""Cell Tel"",""Contact Tel"",""Status"",""AddressLn2"",""AddressLn3"",""AdderssLn4"",""AddressLn5""," _
                            & """PAddressLn2"",""PAdderssLn3"",""PAddressLn4"",""PAddressLn5"",""Product Type"""
                    objWriter.WriteLine(strOutput)

                    Do While readerEPC.Read
                        Application.DoEvents()
                        blnDoNotUpdate = False
                        strPaymentMethodCare = readerEPC("bet_wyse")
                        If strPaymentMethodCare = "6" Then
                            Try
                                Using conn As SqlConnection = SqlHelper.GetConnection
                                    Dim param() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                                   New SqlParameter("@datumbegin", SqlDbType.DateTime), _
                                                                   New SqlParameter("@datumeindig", SqlDbType.DateTime)}

                                    param(0).Value = readerEPC("polisno")
                                    param(1).Value = dteExpPremiumPlusMonth
                                    param(2).Value = dteExpPremiumPlusMonth

                                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchLangtermynPolis", param)

                                    If reader.Read Then
                                        blnDoNotUpdate = False
                                    Else
                                        blnDoNotUpdate = True
                                    End If
                                    If conn.State = ConnectionState.Open Then
                                        conn.Close()
                                    End If
                                End Using
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Critical)
                            End Try
                        End If
                        If blnDoNotUpdate = False Then
                            Try
                                Using conn As SqlConnection = SqlHelper.GetConnection
                                    Dim param() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar)}

                                    param(0).Value = readerEPC("polisno")

                                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchHuisByPolisno", param)

                                    'If Not reader.Read Then
                                    strRisikoAdres = "*Geen risiko adres"
                                    strRisikoAdres2 = ""
                                    strRisikoAdres3 = ""
                                    strRisikoAdres4 = ""
                                    strRisikoAdresPoskode = ""
                                    blnAssignedHouseDesc = True
                                    'End If

                                    Do While reader.Read
                                        strRisikoAdres = reader("adres_h1")
                                        strRisikoAdres2 = reader("adres4")
                                        strRisikoAdres3 = reader("voorstad")
                                        strRisikoAdres4 = reader("dorp")
                                        strRisikoAdresPoskode = reader("poskode")
                                        Try
                                            Using connEPCHeader As SqlConnection = SqlHelper.GetConnection

                                                Dim paramsEPCUpdate() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                                                        New SqlParameter("@Versekerde", SqlDbType.NVarChar), _
                                                                                        New SqlParameter("@Voorl", SqlDbType.NVarChar), _
                                                                                        New SqlParameter("@titelnum", SqlDbType.Int), _
                                                                                        New SqlParameter("@id_nom", SqlDbType.NVarChar), _
                                                                                        New SqlParameter("@Bet_wyse", SqlDbType.NVarChar), _
                                                                                        New SqlParameter("@huis_tel2", SqlDbType.NVarChar), _
                                                                                        New SqlParameter("@werk_tel2", SqlDbType.NVarChar), _
                                                                                        New SqlParameter("@sel_tel", SqlDbType.NVarChar), _
                                                                                        New SqlParameter("@premie", SqlDbType.Money), _
                                                                                        New SqlParameter("@afsluit_dat", SqlDbType.Date), _
                                                                                        New SqlParameter("@trans_dat", SqlDbType.DateTime), _
                                                                                        New SqlParameter("@taknaam", SqlDbType.NVarChar), _
                                                                                        New SqlParameter("@area", SqlDbType.NVarChar), _
                                                                                        New SqlParameter("@br_id", SqlDbType.NVarChar), _
                                                                                        New SqlParameter("@adres", SqlDbType.NVarChar), _
                                                                                        New SqlParameter("@adres1", SqlDbType.NVarChar), _
                                                                                        New SqlParameter("@adres2", SqlDbType.NVarChar), _
                                                                                        New SqlParameter("@adres3", SqlDbType.NVarChar), _
                                                                                        New SqlParameter("@straatadres", SqlDbType.NVarChar)}

                                                paramsEPCUpdate(0).Value = readerEPC("polisno")
                                                paramsEPCUpdate(1).Value = readerEPC("versekerde")
                                                paramsEPCUpdate(2).Value = readerEPC("voorl")
                                                paramsEPCUpdate(3).Value = readerEPC("titelnum")
                                                paramsEPCUpdate(4).Value = readerEPC("id_nom")
                                                paramsEPCUpdate(5).Value = readerEPC("bet_wyse")
                                                paramsEPCUpdate(6).Value = IIf(readerEPC("huis_tel2") Is DBNull.Value, " ", readerEPC("huis_tel2"))
                                                paramsEPCUpdate(7).Value = IIf(readerEPC("werk_tel2") Is DBNull.Value, " ", readerEPC("werk_tel2"))
                                                paramsEPCUpdate(8).Value = readerEPC("sel_tel")
                                                paramsEPCUpdate(9).Value = readerEPC("epc")
                                                paramsEPCUpdate(10).Value = System.String.Format("{0:dd}/{0:MM}/{0:yyyy}", dteExpPremium)
                                                paramsEPCUpdate(11).Value = Now
                                                paramsEPCUpdate(12).Value = strTak
                                                paramsEPCUpdate(13).Value = readerEPC("area")
                                                paramsEPCUpdate(14).Value = "29"
                                                paramsEPCUpdate(15).Value = strRisikoAdres
                                                paramsEPCUpdate(16).Value = readerEPC("adres1")
                                                paramsEPCUpdate(17).Value = readerEPC("adres2")
                                                paramsEPCUpdate(18).Value = readerEPC("adres3")
                                                paramsEPCUpdate(19).Value = strRisikoAdres

                                                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "epc.InsertEPCHeader", paramsEPCUpdate)

                                                strOutput = """" & readerEPC("id_nom") & """,""" & readerEPC("versekerde") & """,""" & readerEPC("voorl") & """,""" & IIf(readerEPC("noemnaam") Is DBNull.Value, "", readerEPC("noemnaam")) & """," _
                                                    & """" & readerEPC("polisno") & """,""" & readerEPC("engelsetitel") & """,""" & strRisikoAdres & """,""" & readerEPC("adres") & """,""" & readerEPC("email") & """," _
                                                    & """" & readerEPC("huis_tel2") & """,""" & readerEPC("werk_tel2") & """,""" & readerEPC("sel_tel") & ""","""",""" & IIf(readerEPC("gekans"), "Cancelled", "Active") & """," _
                                                    & """" & strRisikoAdres2 & """,""" & strRisikoAdres3 & """,""" & strRisikoAdres4 & """,""" & strRisikoAdresPoskode & """," _
                                                    & """" & readerEPC("adres4") & """,""" & readerEPC("adres1") & """,""" & readerEPC("adres3") & """,""" & readerEPC("adres2") & """," _
                                                    & """" & strTak & """"

                                                objWriter.WriteLine(strOutput)

                                                If connEPCHeader.State = ConnectionState.Open Then
                                                    connEPCHeader.Close()
                                                End If
                                            End Using
                                        Catch ex As Exception
                                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                                            Exit Sub
                                        End Try
                                    Loop


                                    If conn.State = ConnectionState.Open Then
                                        conn.Close()
                                    End If
                                End Using
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Critical)
                            End Try
                        End If
                    Loop

                    objWriter.Close()

                    If connEPC.State = ConnectionState.Open Then
                        connEPC.Close()
                    End If
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
        Diagnostics.Debug.WriteLine("epc" & Now)
    End Sub
    Private Sub RunCLRS()
        Dim strFile As String = ""
        Dim strFilePath As String = ""
        Dim strOutput As String = ""
        Dim strMakelaarCLRS As String = ""
        Dim strTakAfkorting As String = ""
        Dim blnOnce As Boolean
        Dim strPosbestemming As String
        Dim dteDateStart, dteDateEnd As Date
        Dim bteMonths, bteTermStatus As Byte
        Dim intCount As Integer = 0
        Dim strTermDesc As String = ""
        Dim strStatusDesc As String = ""

        Me.lblProcessing.Text = "Writing CLRS file"
        Me.lblProcessing.Refresh()

        Diagnostics.Debug.WriteLine("clrs" & Now)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlCLRS")

                Do While reader.Read
                    Application.DoEvents()
                    If intCount = 0 Then
                        strMakelaarCLRS = reader("beskrywingafr")
                        strTakAfkorting = reader("tak_afkorting")

                        clsRun.gen_GetCLRSArea(strTakAfkorting)
                        strFile = "P" & strCLRSArea & Format(Now, "ddhhmmss") & ".txt"
                        strFilePath = strCLRSPath & "\" & strFile
                        intCount += 1
                    End If

                    Dim objWriter As System.IO.StreamWriter
                    objWriter = New System.IO.StreamWriter(strFilePath, True)
                    If strTakAfkorting <> reader("tak_afkorting") Then
                        'email moet hier in
                        strMakelaarCLRS = reader("beskrywingafr")
                        strTakAfkorting = reader("tak_afkorting")

                        blnOnce = False

                        If Not blnOnce Then
                            clsRun.gen_GetCLRSArea(strTakAfkorting)
                            strFile = "P" & strCLRSArea & Format(Now, "ddhhmmss") & ".txt"
                            strFilePath = strCLRSPath & "\" & strFile
                            'Dim objWriter As New System.IO.StreamWriter(strFilePath)
                            objWriter = New System.IO.StreamWriter(strFilePath, True)
                        End If
                    ElseIf strMakelaarCLRS <> reader("beskrywingafr") Then
                        'email moet hier in
                        strMakelaarCLRS = reader("beskrywingafr")
                        strTakAfkorting = reader("tak_afkorting")

                        blnOnce = False

                        If Not blnOnce Then
                            clsRun.gen_GetCLRSArea(strTakAfkorting)
                            strFile = "P" & strCLRSArea & Format(Now, "ddhhmmss") & ".txt"
                            strFilePath = strCLRSPath & "\" & strFile
                            objWriter = New System.IO.StreamWriter(strFilePath, True)
                        End If
                    End If

                    If (Not System.IO.File.Exists(strFilePath)) Then
                        Try
                            System.IO.File.Create(strFilePath)
                            objWriter = New System.IO.StreamWriter(strFilePath, True)
                        Catch ex As Exception
                            MsgBox("CLRS file can not be created", vbInformation)
                        End Try
                    End If
                    If System.IO.File.Exists(strFilePath) = True Then
                        blnOnce = True
                    End If
                    strOutput = reader("clrstypeofamendment") & "|"
                    strOutput &= StrConv(reader("versekerde"), vbProperCase) & "|"
                    strOutput &= reader("voorl") & "|"
                    strOutput &= reader("polisno") & "|"
                    strOutput &= reader("titelnum") & "|"
                    strOutput &= StrConv(IIf(reader("noemnaam") Is DBNull.Value, "", reader("noemnaam")), vbProperCase) & "|"
                    strOutput &= reader("id_nom") & "|"
                    strOutput &= "" & "|"                'geregistreerde naam
                    strOutput &= "" & "|"                'bedryfsnaam
                    strOutput &= "" & "|"                'registrasienommer van maatskappy
                    strOutput &= reader("taal") & "|"
                    'Posadres
                    strOutput &= StrConv(IIf(reader("adres") Is DBNull.Value, "", reader("adres")), vbProperCase) & "|"
                    strOutput &= StrConv(IIf(reader("adres1") Is DBNull.Value, "", reader("adres1")), vbProperCase) & "|"
                    strOutput &= StrConv(IIf(reader("adres4") Is DBNull.Value, "", reader("adres4")), vbProperCase) & "|"
                    strOutput &= StrConv(IIf(reader("adres3") Is DBNull.Value, "", reader("adres3")), vbProperCase) & "|"
                    strOutput &= reader("adres2") & "|"
                    'Posbestemming bly posbestemming(0 word 0, risiko adres word fisiese adres (1 word 1), Universiteitsposbus word posbestemming (2 word 0), email byl email (3 word 2)
                    Select Case reader("posbestemming")
                        Case "2"
                            strPosbestemming = "0"
                        Case "3"
                            strPosbestemming = "2"
                        Case Else
                            strPosbestemming = reader("posbestemming")
                    End Select
                    strOutput &= strPosbestemming & "|"
                    strOutput &= IIf(reader("huis_tel2") Is DBNull.Value, "", reader("huis_tel2")) & "|"
                    strOutput &= IIf(reader("werk_tel2") Is DBNull.Value, "", reader("werk_tel2")) & "|"
                    strOutput &= IIf(reader("sel_tel") Is DBNull.Value, "", reader("sel_tel")) & "|"
                    strOutput &= IIf(reader("fax") Is DBNull.Value, "", reader("fax")) & "|"
                    Dim strEmail As String
                    strEmail = IIf(reader("email") Is DBNull.Value, "", reader("email"))
                    strOutput &= strEmail.left(40) & "|"

                    Try
                        Using connHuis As SqlConnection = SqlHelper.GetConnection
                            Dim paramHuis() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar)}

                            paramHuis(0).Value = reader("polisno")

                            Dim readerHuis As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchHuisByPolisno", paramHuis)

                            If readerHuis.Read Then
                                strOutput &= StrConv(readerHuis("adres_h1"), vbProperCase) & "|"             'fisiese adres 1 van 2
                                strOutput &= StrConv(readerHuis("adres4"), vbProperCase) & "|"               'fisiese adres 2 van 2
                                strOutput &= StrConv(readerHuis("voorstad"), vbProperCase) & "|"             'fisiese voorstad
                                strOutput &= StrConv(readerHuis("dorp"), vbProperCase) & "|"                 'fisiese dorp
                                strOutput &= StrConv(readerHuis("poskode"), vbProperCase) & "|"              'fisiese poskode
                            Else
                                'No property exists
                                strOutput &= "" & "|"            'Fisiese adres 1 van 2
                                strOutput &= "" & "|"            'Fisiese adres 2 van 2
                                strOutput &= "" & "|"            'Fisiese voorstad
                                strOutput &= "" & "|"            'Fisiese dorp
                                strOutput &= "" & "|"            'Fisiese poskode
                            End If

                            If connHuis.State = ConnectionState.Open Then
                                connHuis.Close()
                            End If
                        End Using
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try

                    strOutput &= Format(reader("p_a_dat"), "dd/MM/yyyy") & "|"
                    strOutput &= reader("bet_dat") & "|"
                    strOutput &= reader("betaaldatum") & "|"

                    clsRun.gen_GetCLRSArea(strTakAfkorting)

                    strOutput &= strCLRSArea & "|"
                    strOutput &= sngSalesPerson & "|"
                    strOutput &= reader("gekans") & "|"
                    strOutput &= reader("bet_wyse") & "|"

                    'Tipe polis (P - Personal, C - Commercial)
                    strOutput &= "P" & "|"

                    If reader("bet_wyse") = "6" Then
                        'Term policies
                        clsRun.gen_GetTermPolicyStatus(reader("bet_wyse"), reader("polisno"), dteDateStart, dteDateEnd, bteMonths, strTermDesc, strStatusDesc, bteTermStatus)
                        strOutput &= dteDateStart & "|"
                        strOutput &= dteDateEnd & "|"
                        strOutput &= bteMonths & "|"
                    Else
                        strOutput &= "" & "|"
                        strOutput &= "" & "|"
                        strOutput &= "0" & "|"
                    End If

                    '0 - Collected by broker, 1 - collected by clrs
                    strOutput &= 0 & "|"
                    strOutput &= reader("datumgekanselleer") & "|"
                    strOutput &= reader("fkKansellasieRedes") & "|"

                    objWriter.WriteLine(strOutput)
                    intCount += 1
                    objWriter.Close()
                Loop

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        'Reset CLRSTypeOFAmendment field
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.ResetCLRSTypeOfAmendment")

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        'email hier in
        Diagnostics.Debug.WriteLine("clrs" & Now)
    End Sub
    Private Sub DebitOrderProcessing()
        Dim strNow As String
        Dim blnfinalrun As Boolean

        strNow = Format(Now, "ddMMyyyy")
        Try
            If Me.optFinalRunGeneral.Checked = True Then
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim params() As SqlParameter = {New SqlParameter("@Gebruiker", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Datum", SqlDbType.DateTime), _
                                                    New SqlParameter("@Beskrywing", SqlDbType.NVarChar)}

                    params(0).Value = Gebruiker.Naam
                    params(1).Value = Now
                    params(2).Value = "Debit order Processing - Final run"

                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.UpdateGebruikerLopies", params)
                End Using

                strDebitOrderDataPath = strMultidataPath & "\" & strNow & "\Final\"
                blnfinalrun = True
                DOP_CreateMultidataFile(blnfinalrun)
                'MsgBox("Debitorderprocessing is completed.  The file was emailed to Mooirivier Computers and stored in " & strDebitOrderDataPath & ".")

            ElseIf Me.optTestRunGeneral.Checked = True Then
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim params() As SqlParameter = {New SqlParameter("@Gebruiker", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Datum", SqlDbType.DateTime), _
                                                    New SqlParameter("@Beskrywing", SqlDbType.NVarChar)}

                    params(0).Value = Gebruiker.Naam
                    params(1).Value = Now
                    params(2).Value = "Debitorder Processing - Test run"

                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.UpdateGebruikerLopies", params)
                End Using

                strDebitOrderDataPath = strMultidataPath & "\" & strNow & "\Test\"
                blnfinalrun = False

                DOP_CreateMultidataFile(blnfinalrun)

                'MsgBox("Debitorderprocessing is completed.  The file was emailed to Mooirivier Computers and stored in " & strDebitOrderDataPath & ".")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Public Function DOP_SetApplicationParameters(ByRef blnfinalrun As Boolean) As Object
        ' Andriette 07/03/2013 comment ingebruikte val's
        'Dim strSql As Object
        'Dim strDebitOrderApplicationPath As String
        Dim strNow As String
        Dim strTemporaryDate As String
        Dim intPos As Integer = 0
        Try
            strNow = Format(Now, "ddMMyyyy")

            strTemporaryDate = "01" & "/" & Mid(strNow, 3, 2) & "/" & strNow.right(4) 'dd/mm/yy
            strTemporaryDate = CDate(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, CDate(strTemporaryDate)))
            strCollectiondate = strTemporaryDate.right(2) & Mid(strTemporaryDate, 4, 2) & strTemporaryDate.left(2) 'yymmdd

            intPos = InStr(4, strMultidataPath, "\")
            If strMultidataPath.left(2) = "\\" Then
                intPos = InStr(intPos + 1, strMultidataPath, "\")
            End If
            Do While intPos <> 0
                If Dir(strMultidataPath.left(intPos), vbDirectory) = "" Then
                    MkDir(strMultidataPath.left(intPos))
                End If
                intPos = InStr(intPos + 1, strMultidataPath, "\")
            Loop
            If Dir(strMultidataPath, FileAttribute.Directory) = "" Then
                MkDir(strMultidataPath)
            End If

            strMultidataPath = strMultidataPath & "\"

            If Dir(strMultidataPath & strNow, FileAttribute.Directory) = "" Then
                MkDir(strMultidataPath & strNow)
            End If

            If blnfinalrun Then
                If Dir(strMultidataPath & strNow & "\Final", FileAttribute.Directory) = "" Then
                    MkDir(strMultidataPath & strNow & "\Final")
                End If
            Else
                If Dir(strMultidataPath & strNow & "\Test", FileAttribute.Directory) = "" Then
                    MkDir(strMultidataPath & strNow & "\Test")
                End If
            End If

            Using conn As SqlConnection = SqlHelper.GetConnection
                entV_area = BaseForm.FetchArea()
                entV_versekeraar = BaseForm.FetchVersekeraar()
                Dim param As New SqlParameter("@fkMakelaar", SqlDbType.Int)
                param.Value = entV_area.fkmakelaar

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchMakelaar", param)
                Do While reader.Read
                    strDebitOrderOutputFileName = strDebitOrderDataPath & reader("PreFix") & "_" & entV_versekeraar.DisFile & ".DIS"
                Loop
            End Using
            Return 0
        Catch ex As Exception
            Return 0
            MsgBox(ex.Message)
            Exit Function
        End Try
    End Function

    ' Public Function DOP_CreateMultidataFile(ByRef blnfinalrun As Boolean) As Object
    Public Sub DOP_CreateMultidataFile(ByRef blnfinalrun As Boolean)
        Dim strversekeraar As Object
        ' Andriette 07/03/2013 comment ongebruikte var's
        'Dim strSql As String
        'Dim sngBatchNumber As Single
        'Dim sngCounter As Single
        Dim strEmailPath As String
        Dim Area As New AreaEntity

        Try
            DOP_SetApplicationParameters(blnfinalrun)

            If System.IO.File.Exists(strDebitOrderOutputFileName) Then
                'delete die file, en dan create 'n nuwe een
                System.IO.File.Delete(strDebitOrderOutputFileName)
            End If

            Dim objWriterDOProc As New System.IO.StreamWriter(strDebitOrderOutputFileName)

            If (Not System.IO.File.Exists(strDebitOrderOutputFileName)) Then
                Try
                    System.IO.File.Create(strDebitOrderOutputFileName)
                Catch ex As Exception
                    MsgBox("Debitorder processing file can not be created", vbInformation)
                End Try
            End If

            If System.IO.File.Exists(strDebitOrderOutputFileName) = True Then
                strEmailPath = strDebitOrderOutputFileName

                Using conn As SqlConnection = SqlHelper.GetConnection

                    Dim param As New SqlParameter("@bet_dat", SqlDbType.Date)
                    param.Value = DateAdd("m", 1, Now)

                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlForMultidata", param)

                    Do While reader.Read
                        strversekeraar = reader("fkversekeraar")

                        'Aftrek
                        Aftrek = New AftrekEntity()

                        If reader("A_VAN") IsNot DBNull.Value Then
                            Aftrek.A_VAN = reader("A_VAN")
                        End If
                        If reader("A_VL") IsNot DBNull.Value Then
                            Aftrek.A_VL = reader("A_VL")
                        End If
                        If reader("A_TIPE") IsNot DBNull.Value Then
                            Aftrek.A_TIPE = reader("A_TIPE")
                        End If
                        If reader("A_KODE") IsNot DBNull.Value Then
                            Aftrek.A_KODE = reader("A_KODE")
                        End If
                        If reader("REK_NO1") IsNot DBNull.Value Then
                            Aftrek.REK_NO1 = reader("REK_NO1")
                        End If
                        If reader("fkBankCodes") IsNot DBNull.Value Then
                            Aftrek.FK_BANKCODE = reader("fkBankCodes")
                        End If
                        If reader("CreditCardCVVNumber") IsNot DBNull.Value Then
                            Aftrek.CREDIT_CARD_CVV_NO = reader("CreditCardCVVNumber")
                        End If
                        If reader("CreditCardExpiryDate") IsNot DBNull.Value Then
                            Aftrek.CREDIT_CARD_EXPIRY_DATE = reader("CreditCardExpiryDate")
                        End If
                        Aftrek.NoMatch = False

                        'Persoonl
                        Persoonl = New PERSOONLEntity()

                        If reader("aftrekdat") IsNot DBNull.Value Then
                            Persoonl.aftrekdat = reader("aftrekdat")
                        End If
                        If reader("Area") IsNot DBNull.Value Then
                            Persoonl.Area = reader("Area")
                        End If
                        If reader("bet_dat") IsNot DBNull.Value Then
                            Persoonl.bet_dat = reader("bet_dat")
                        End If
                        If reader("BET_WYSE") IsNot DBNull.Value Then
                            Persoonl.BET_WYSE = reader("BET_WYSE")
                        End If
                        If reader("betaaldatum") IsNot DBNull.Value Then
                            Persoonl.betaaldatum = reader("betaaldatum")
                        End If
                        If reader("GEKANS") IsNot DBNull.Value Then
                            Persoonl.GEKANS = reader("GEKANS")
                        End If
                        If reader("P_A_DAT") IsNot DBNull.Value Then
                            Persoonl.P_A_DAT = reader("P_A_DAT")
                        End If
                        If reader("PREMIE") IsNot DBNull.Value Then
                            Persoonl.PREMIE = reader("PREMIE")
                        End If
                        If reader("premie2") IsNot DBNull.Value Then
                            Persoonl.premie2 = reader("premie2")
                        End If
                        If reader("SUBTOTAAL") IsNot DBNull.Value Then
                            Persoonl.SUBTOTAAL = reader("SUBTOTAAL")
                        End If
                        If reader("TAAL") IsNot DBNull.Value Then
                            Persoonl.TAAL = reader("TAAL")
                        End If
                        If reader("titelnum") IsNot DBNull.Value Then
                            Persoonl.titelnum = reader("titelnum")
                        End If
                        If reader("VOORL") IsNot DBNull.Value Then
                            Persoonl.VOORL = reader("VOORL")
                        End If
                        If reader("VERSEKERDE") IsNot DBNull.Value Then
                            Persoonl.VERSEKERDE = reader("VERSEKERDE")
                        End If
                        If reader("polisno") IsNot DBNull.Value Then
                            Persoonl.POLISNO = reader("polisno")
                        End If

                        'Bankcodes
                        entBankCodes = New BankCodes()

                        If reader("branchcode") IsNot DBNull.Value Then
                            entBankCodes.branchcode = reader("branchcode")
                        End If

                        DOP_InsertTransaction(Persoonl.POLISNO)

                        objWriterDOProc.WriteLine(strOutputDOProc)
                        If strOutputDOProcKT <> "" Then
                            objWriterDOProc.WriteLine(strOutputDOProcKT)
                            strOutputDOProcKT = ""
                        End If

                        If reader("fkversekeraar") <> strversekeraar Then

                            objWriterDOProc.Close()

                            'Email file
                            If emailEngine.signOn Then
                                'Send mail according to parameters specified
                                emailEngine.sendMail("lpschlebusch@iafrica.com", "Mooirivier Makelaars(Flagship) - Debitorder file", " ", strEmailPath)
                                'Sign off
                                emailEngine.signOff()
                            End If

                            DOP_SetApplicationParameters(blnfinalrun)

                            objWriterDOProc = New System.IO.StreamWriter(strDebitOrderOutputFileName)

                            If (Not System.IO.File.Exists(strDebitOrderOutputFileName)) Then
                                Try
                                    System.IO.File.Create(strDebitOrderOutputFileName)
                                Catch ex As Exception
                                    MsgBox("Debitorder processing file can not be created", vbInformation)
                                End Try
                            End If
                            If System.IO.File.Exists(strDebitOrderOutputFileName) = True Then
                                strEmailPath = strDebitOrderOutputFileName
                            End If
                        End If
                    Loop
                End Using

                objWriterDOProc.Close()

                'Email file
                'If emailEngine.signOn Then
                '    'Send mail according to parameters specified
                '    emailEngine.sendMail("lpschlebusch@iafrica.com", "Mooirivier Makelaars(Flagship) - Debitorder file", " ", strEmailPath)
                '    'Sign off
                '    emailEngine.signOff()
                'End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    ' Public Function DOP_InsertBatchHeader(ByRef sngBatchNumber As Single) As Object
    Public Sub DOP_InsertBatchHeader(ByRef sngBatchNumber As Single)
        Dim frmMultidata As Object = ""
        Dim strBlankField As String

        strBlankField = ""

        strOutputDOProc = strHeader & strCompanyNumber & DOP_InsertTrailingSpaces(frmMultidata.txtReferenceNumber, 4) & Format(sngBatchNumber, "00#") & frmMultidata.dtpCollectionDate.Right(2) & Mid(frmMultidata.dtpCollectionDate, 3, 2) & DOP_InsertTrailingSpaces(strBlankField, 58)

    End Sub
    ' Andriette 07/03/2013 verander na ;n private sub want dit return niks
    'Public Function DOP_InsertTransaction(ByRef strPolisno As String) As Object
    Private Sub DOP_InsertTransaction(ByRef strPolisno As String)
        Dim strVersekerdeVoorl As String
        Dim strBlankField As String
        Dim strBranchcode As String = entBankCodes.branchcode

        strBlankField = ""

        If IsDBNull(Aftrek.A_VL) Or IsDBNull(Aftrek.A_VAN) Or Aftrek.A_VL = "" Or Aftrek.A_VAN = "" Then
            strVersekerdeVoorl = IIf(Trim(Persoonl.VOORL) = "", DOP_InsertTrailingSpaces(Persoonl.VERSEKERDE, 25), DOP_InsertTrailingSpaces(Persoonl.VERSEKERDE & "," & Persoonl.VOORL, 25))
        Else
            strVersekerdeVoorl = IIf(Trim(Aftrek.A_VL) = "", DOP_InsertTrailingSpaces(Aftrek.A_VAN, 25), DOP_InsertTrailingSpaces(Aftrek.A_VAN & "," & Aftrek.A_VL, 25))
        End If

        strOutputDOProc = (DOP_InsertLeadingZeros(strPolisno, 15) & strTransactionCode & DOP_InsertLeadingZeros(Format(Persoonl.premie2, "##########0.00"), 9) & (strCollectiondate.left(4) & IIf(CInt(Persoonl.betaaldatum) < 10, DOP_InsertLeadingZeros((Persoonl.betaaldatum), 2), Persoonl.betaaldatum)) & strBranchcode.left(6) & DOP_InsertLeadingZeros(Aftrek.REK_NO1, 13) & Aftrek.A_TIPE & strTypeofPayment & strVersekerdeVoorl)
        If Aftrek.A_TIPE = 4 Then
            strOutputDOProcKT = (DOP_InsertLeadingZeros(strPolisno, 15) & "402" & DOP_InsertTrailingSpaces(strBlankField, 35) & Aftrek.CREDIT_CARD_EXPIRY_DATE & Aftrek.CREDIT_CARD_CVV_NO)
        End If

    End Sub

    Public Function DOP_InsertTrailingSpaces(ByRef strField As String, ByRef intLength As Short) As Object

        If Len(strField) > intLength Then
            DOP_InsertTrailingSpaces = strField.left(intLength)
        Else
            DOP_InsertTrailingSpaces = strField & Space(intLength - Len(strField))
        End If

    End Function
    Public Function DOP_InsertLeadingZeros(ByRef strField As String, ByRef intLength As Short) As Object

        If Len(strField) > intLength Then
            DOP_InsertLeadingZeros = strField
        Else
            DOP_InsertLeadingZeros = Replace(strField, ".", "")
            DOP_InsertLeadingZeros = Space(intLength - Len(DOP_InsertLeadingZeros)) & DOP_InsertLeadingZeros
            DOP_InsertLeadingZeros = Replace(DOP_InsertLeadingZeros, " ", "0")
        End If

    End Function

    Private Sub RunPukFile()

        Dim strPersoneelNommers As Object
        Dim strNow As Object
        Dim i As Integer = 0

        'strMultidataPath = "c:\PUK"
        strNow = Format(Now, "ddMMyy")

        'toets lopie
        If Me.optTestRun.Checked = True Then
        Else
            cnstFileName = strMultidataPath & "\" & strNow & "\"

            'Kyk eers of daar enige personeelnommers nog uitstaande is
            Try
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim param() As SqlParameter = {New SqlParameter("@Missing", SqlDbType.NVarChar), _
                                                    New SqlParameter("@area_besk", SqlDbType.NVarChar), _
                                                       New SqlParameter("@Bet_dat", SqlDbType.Date)}

                    param(0).Value = "Missing"
                    param(1).Value = Me.cmbArea.Text
                    param(2).Value = dteExpPremiumPlusMonth

                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersnoFinalRun", param)

                    strPersoneelNommers = ""

                    Do While reader.Read
                        strPersoneelNommers = strPersoneelNommers & reader("polisno") & ", "
                        i = i + 1
                        blnPersnoMissing = True
                    Loop

                    If i > 0 Then
                        MsgBox("There are missing personnel number/s on policy/ies: " & Chr(13) & strPersoneelNommers & Chr(13) & "Correct it first or change the first payment date to the next month.", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

            setupExcel()
            createSalaryFile()

            xlbook.SaveAs(cnstFileName)

            xlBook.Close()
            xlApp.Quit()

            releaseObject(xlApp)
            releaseObject(xlBook)
            releaseObject(xlSheet)

            'Email file

            'Try
            '    Using conn As SqlConnection = SqlHelper.GetConnection

            '        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchTak")

            '        strContactEmail = "22150110@nwu.ac.za; juanita.vandenberg@nwu.ac.za"
            '        'if email - get email detail
            '        If emailEngine.signOn Then

            '            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            '            emailEngine.txtTo.Text = strContactEmail
            '            Do While reader.Read
            '                emailEngine.txtSubject.Text = "Mooirivier Makelaars(" & reader("tak_naam") & ") - Salaris Aftrekking leer"
            '                emailEngine.txtBody.Text = "Attached is the end file for salary deductions from Mooi River Estate " & reader("tak_naam") & "."
            '            Loop
            '            emailEngine.ShowDialog()
            '            'If cancel was clicked - abort process else continue
            '            If Not emailEngine.returnValue Then
            '                emailEngine.signOff()
            '                emailEngine.Close()
            '                Exit Sub
            '            End If
            '        Else
            '            Exit Sub
            '        End If
            '    End Using
            'Catch ex As Exception
            '    MsgBox(ex.Message, MsgBoxStyle.Critical)
            'End Try

            'Build list of attachmets
            'For i = 0 To emailEngine.lstAanhangsels.Items.Count - 1
            '    'attachList = attachList & VB6.GetItemString(emailEngine.lstAanhangsels, i) & "; "
            'Next

            ''email file as attachment
            'emailEngine.sendMail((emailEngine.txtTo).Text, (emailEngine.txtSubject).Text, (emailEngine.txtBody).Text, cnstFileName)

            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            'MsgBox("The PUK closure was completed." & Chr(13) & Chr(13) & "Die leer is '" & cnstFileName & "'", MsgBoxStyle.Information)

            ''If the document was emailed - sign-off
            'emailEngine.signOff()
            'emailEngine.Close()
        End If

    End Sub
    Public Sub createSalaryFile()
        
        Salary_SetApplicationParameters()

        introw = 10

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@Missing", SqlDbType.NVarChar), _
                                                New SqlParameter("@area_besk", SqlDbType.NVarChar), _
                                                   New SqlParameter("@Bet_dat", SqlDbType.Date)}

                param(0).Value = "NotMissing"
                param(1).Value = Me.cmbArea.Text
                param(2).Value = dteExpPremiumPlusMonth

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersnoFinalRun", param)

                Do While reader.Read
                    'strEmailPath = cnstFileName

                    'Logo
                    'rsMakelaarSql = dbPoldata.OpenRecordset("SELECT * FROM Makelaar where pkmakelaar = " & rs2.Fields("fkmakelaar").Value)
                    'xlsheet.Shapes.AddPicture(getAdminPath & "Logo\" & rsMakelaarSql("Makelaar_logo"), True, True, xlsheet.Cells.Left, xlsheet.Cells.Top, 480, 70)

                    'strversekeraar = rs2.Fields("fkversekeraar").Value
                    
                    Dim item As PERSOONLEntity = New PERSOONLEntity()
                    If reader("GEB_DAT") IsNot DBNull.Value Then
                        item.GEB_DAT = reader("GEB_DAT")
                    End If
                    If reader("GEKANS") IsNot DBNull.Value Then
                        item.GEKANS = reader("GEKANS")
                    End If
                    If reader("polisno") IsNot DBNull.Value Then
                        item.POLISNO = reader("polisno")
                    End If
                    If reader("pers_nom") IsNot DBNull.Value Then
                        item.pers_nom = reader("pers_nom")
                    End If
                    If reader("versekerde") IsNot DBNull.Value Then
                        item.VERSEKERDE = reader("versekerde")
                    End If
                    If reader("voorl") IsNot DBNull.Value Then
                        item.VOORL = reader("voorl")
                    End If
                    If reader("titelnum") IsNot DBNull.Value Then
                        item.titelnum = reader("titelnum")
                    End If
                    If reader("premie2") IsNot DBNull.Value Then
                        item.premie2 = reader("premie2")
                    End If
                    If reader("id_nom") IsNot DBNull.Value Then
                        item.ID_NOM = reader("id_nom")
                    End If
                    If reader("taal") IsNot DBNull.Value Then
                        item.TAAL = reader("taal")
                    End If

                    If item.TAAL = 0 Then
                        strTitel = reader("afrikaansetitel")
                    Else
                        strTitel = reader("engelsetitel")
                    End If

                    entPersoonl = item
                    SkryfExcel(entPersoonl.POLISNO)
                Loop

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

    End Sub
    Public Sub Salary_SetApplicationParameters()
        Dim strNow As String

        strNow = Format(Now, "ddMMyyyy")
        If Dir(strMultidataPath, FileAttribute.Directory) = "" Then
            MkDir(strMultidataPath)
        End If
        If Dir(strMultidataPath & "\" & strNow, FileAttribute.Directory) = "" Then
            MkDir(strMultidataPath & "\" & strNow)
        End If

        cnstFileName = strMultidataPath & "\" & strNow & "\NWU_Salary.xlsx"

    End Sub
    Public Sub SkryfExcel(ByRef strPolisno As String)

        'skryf rekord na puk leer
        xlSheet.Cells._Default(introw, 1) = "'" & entPersoonl.pers_nom
        xlsheet.Cells._Default(introw, 2) = entPersoonl.VERSEKERDE
        xlsheet.Cells._Default(introw, 3) = entPersoonl.VOORL

        xlSheet.Cells._Default(introw, 4) = strTitel
        xlSheet.Cells._Default(introw, 5) = "'" & entPersoonl.ID_NOM
        If IsDBNull(entPersoonl.GEB_DAT) Or entPersoonl.GEB_DAT = Nothing Then
            xlSheet.Cells._Default(introw, 6).value = ""
        Else
            xlSheet.Cells._Default(introw, 6).value = CDate(entPersoonl.GEB_DAT)
        End If
        xlsheet.Cells._Default(introw, 7) = entPersoonl.premie2
        xlsheet.Cells._Default(introw, 8) = entPersoonl.POLISNO

        With xlsheet.Range("A" & introw, "I" & introw)
            .Font.Size = 8
        End With

        introw = introw + 1

    End Sub

    Public Sub setupExcel()
        xlapp = New Excel.Application

        serverPath = clsRun.gen_getAdminPath()

        If IO.File.Exists(serverPath & "\Templates\Report.xlsx") Then
            xlBook = xlApp.Workbooks.Open(serverPath & "\Templates\Report.xlsx")
        ElseIf IO.File.Exists(serverPath & "\Templates\Report.xls") Then
            xlBook = xlApp.Workbooks.Open(serverPath & "\Templates\Report.xls")
        End If

        xlSheet = xlBook.Worksheets("Sheet1")

        'Dim xlRange As Microsoft.Office.Interop.Excel.Range

        'Set line
        xlSheet.Range("A4", "I4").Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlThin

        'Set headings
        With xlSheet.Range("A6")
            .Font.Bold = True
            .Font.Size = 10
            .Value = "Short term insurance - Tendered Collections for NWU"
            .RowHeight = 12.75
        End With

        With xlSheet.Range("A7")
            .Font.Size = 8
            .Value = "Month-end date: " & Format(Now, "dd/MM/yyyy")
            .RowHeight = 11.25
        End With

        With xlSheet.Range("A9", "I9")
            .Font.Bold = True
            .Font.Size = 10
            .BorderAround(Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Word.XlBorderWeight.xlThin)
        End With

        xlSheet.Cells._Default(9, 1) = "Emp code"
        xlSheet.Cells._Default(9, 2) = "Surname"
        xlSheet.Cells._Default(9, 3) = "Initials"
        xlSheet.Cells._Default(9, 4) = "Title"
        xlSheet.Cells._Default(9, 5) = "ID"
        xlSheet.Cells._Default(9, 6) = "DateOfBirth"
        xlSheet.Cells._Default(9, 7) = "Amount"
        xlSheet.Cells._Default(9, 8) = "Ref NR"

        xlSheet.Cells._Default(9, 1).ColumnWidth = 9
        xlSheet.Cells._Default(9, 2).ColumnWidth = 21
        xlSheet.Cells._Default(9, 3).ColumnWidth = 6.14
        xlSheet.Cells._Default(9, 4).ColumnWidth = 6
        xlSheet.Cells._Default(9, 5).ColumnWidth = 13.43
        xlSheet.Cells._Default(9, 6).ColumnWidth = 10.29
        xlSheet.Cells._Default(9, 7).ColumnWidth = 7.29
        xlSheet.Cells._Default(9, 8).ColumnWidth = 10.57
        xlSheet.Cells._Default(9, 9).ColumnWidth = 2

        'Set date
        With xlSheet.Cells._Default(5, 9)
            .value = "'" & Format(Now, "dd/MM/yyyy")
            .Font.Size = 8
            .Font.Bold = True
            .HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlRight
        End With

        'Footer
        xlSheet.PageSetup.RightFooter = "&6Page &p of &n"
    End Sub
    
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub ResetAddisionelePremie(ByVal BetWyse As Integer)
        Dim strBeskrywing As String
        Dim strGebruiker As String
        Dim dteMaxAfsluitdate As Date
        Dim strSql As String

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5d.FetchAfsluitDatumLaaste")

                If reader.Read Then
                    dteMaxAfsluitdate = reader("afsluit_dat")
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        'Opdateer addisionele premie
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                If BetWyse = 3 Then
                    strsql = "Poldata5.FetchPremieForSalary"
                Else
                    strsql = "Poldata5.FetchPremie"
                End If
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strsql)

                Do While reader.Read
                    glbPolicyNumber = reader("polisno")

                    Try
                        Using connAP As SqlConnection = SqlHelper.GetConnection
                            Dim paramsAP() As SqlParameter = {New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                                            New SqlParameter("@Afgesluit", SqlDbType.TinyInt), _
                                                            New SqlParameter("@DatumAfgesluit", SqlDbType.NVarChar)}

                            paramsAP(0).Value = glbPolicyNumber
                            paramsAP(1).Value = 1
                            paramsAP(2).Value = dteMaxAfsluitdate

                            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdateAddisionelePremie]", paramsAP)

                            If connAP.State = ConnectionState.Open Then
                                connAP.Close()
                            End If
                        End Using
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                        Exit Sub
                    End Try

                    If reader("totaal") <> 0 Then
                        If reader("taal") = "0" Then
                            strBeskrywing = "Herstel Addisionele premie"
                            strGebruiker = "Stelsel"
                        Else
                            strBeskrywing = "Reset Additional premium"
                            strGebruiker = "System"
                        End If

                        Try
                            Using connWysig As SqlConnection = SqlHelper.GetConnection
                                Dim paramWysig() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                                New SqlParameter("@kode", SqlDbType.NVarChar), _
                                                                New SqlParameter("@datum", SqlDbType.DateTime), _
                                                                New SqlParameter("@versekerde", SqlDbType.NVarChar), _
                                                                New SqlParameter("@voorl", SqlDbType.NVarChar), _
                                                                New SqlParameter("@gebruiker", SqlDbType.NVarChar), _
                                                                New SqlParameter("@beskrywing", SqlDbType.NVarChar)}

                                paramWysig(0).Value = glbPolicyNumber
                                paramWysig(1).Value = Format(44)
                                paramWysig(2).Value = Now()
                                paramWysig(3).Value = reader("versekerde")
                                paramWysig(4).Value = reader("voorl")
                                paramWysig(5).Value = strGebruiker
                                paramWysig(6).Value = strBeskrywing

                                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateWysig", paramWysig)
                                If connWysig.State = ConnectionState.Open Then
                                    connWysig.Close()
                                End If

                            End Using
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                        End Try
                    End If
                Loop
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
                Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class