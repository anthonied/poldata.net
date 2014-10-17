Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports DAL

Public Class frmClaimsList
    Dim intRow As Integer = 0
    Dim intRowIncome As Integer = 0
    Dim blnInfoChanges As Boolean = False
    Dim intRowPayments As Integer = 0
    Dim blnNedLopie As Boolean
    Dim dblIncome As Decimal = 0
    Dim dblPayments As Decimal = 0
    Dim dblClaimAmount As Decimal = 0
    Dim dblJournals As Decimal = 0
    Dim intRowJournal As Integer = 0
    Dim dblEisGrootte As Decimal = 0
    Dim intRowAssessor As Integer = 0
    Dim intPKAssessorsPerClaim As Integer = 0
    Dim blnClaimsValidation As Boolean = False
    Dim intpkUMA As Integer = 0
    Dim intfkVersekeraar As Integer = 0
    Dim blnUnique As Boolean = False
    Dim clsRun As New clsRuns()
    Dim blnNewClaim As Boolean = False
    Dim blnClaimLoading As Boolean = True
    Dim entClaims As ClaimsEntity = New ClaimsEntity()
    Dim strBeskrywing As String
    Dim strVoor As String = ""

    Private Sub frmClaimsList_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        blnAssessorClaim = False

        FieldsEnabled(False)

        Me.Text = "Claims - " & Persoonl.VOORL & " " & Persoonl.VERSEKERDE & " - " & glbPolicyNumber

        Me.tabClaims1.Show()
        
        Me.dtpClaimReportDate.Value = Today
        Me.dtpClaimDate.Value = Today
        Me.dtpClaimCompletionDate.Value = Today
        Me.dtpClaimDate.MaxDate = Today

        populateComboboxes()

        populateClaimsGrid()

        blnInfoChanges = False
    End Sub
    Private Sub populateClaimsGrid()
        Dim intCount As Integer = 0
        dgvClaims.AutoGenerateColumns = False
        dgvClaims.DataSource = Nothing
        dgvClaims.Refresh()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim paramsClaims() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar)}
                paramsClaims(0).Value = glbPolicyNumber

                Dim readerClaims As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchEisdatPolisno", paramsClaims)
                Dim ClaimsList As List(Of ClaimsEntity) = New List(Of ClaimsEntity)

                Do While readerClaims.Read
                    Dim item As ClaimsEntity = New ClaimsEntity()

                    If readerClaims("polisno") IsNot DBNull.Value Then
                        item.Polisno = readerClaims("polisno")
                    Else
                        item.Polisno = Nothing
                    End If
                    If readerClaims("eisno") IsNot DBNull.Value Then
                        item.Eisno = readerClaims("eisno")
                    Else
                        item.Eisno = 0
                    End If
                    If readerClaims("datum") IsNot DBNull.Value Then
                        item.Datum = readerClaims("datum")
                    Else
                        item.Datum = Nothing
                    End If
                    If readerClaims("beskrywing") IsNot DBNull.Value Then
                        item.Beskrywing = readerClaims("beskrywing")
                    Else
                        item.Beskrywing = ""
                    End If
                    If readerClaims("beskrywing2") IsNot DBNull.Value Then
                        item.Beskrywing2 = readerClaims("beskrywing2")
                    Else
                        item.Beskrywing2 = ""
                    End If
                    If readerClaims("beskrywing3") IsNot DBNull.Value Then
                        item.Beskrywing3 = readerClaims("beskrywing3")
                    Else
                        item.Beskrywing3 = ""
                    End If
                    If readerClaims("ClaimStatusAfr") IsNot DBNull.Value Then
                        item.ClaimStatusAfr = readerClaims("ClaimStatusAfr")
                    Else
                        item.ClaimStatusAfr = ""
                    End If
                    If readerClaims("ClaimSubStatusAfr") IsNot DBNull.Value Then
                        item.ClaimSubStatusAfr = readerClaims("ClaimSubStatusAfr")
                    Else
                        item.ClaimSubStatusAfr = ""
                    End If

                    ClaimsList.Add(item)
                    intCount += 1
                Loop

                dgvClaims.DataSource = ClaimsList
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    readerClaims.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Me.lblNumberofClaims.Text = "Number of claims: " & intCount
        Me.lblNumberofClaims.Refresh()
    End Sub

    Private Sub populateComboBoxes()
        'Claims Class
        Using conn As SqlConnection = SqlHelper.GetConnection

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchClaimClass")
            cmbClaimClassType.Items.Clear()
            Do While reader.Read
                cmbClaimClassType.Items.Add(reader("afdeling"))
            Loop

        End Using
        'cmbClaimClassType.Text = ""
        cmbClaimClassType.SelectedValue = -1

        'Claims Type
        If cmbClaimClassType.Text <> "" Then
            If Persoonl.TAAL = 0 Then
                cmbClaimType.DataSource = BaseForm.FillCombo("eisdat.FetchClaimType", "EisTipekode", "EisTipe", , , "@Afdeling", , SqlDbType.NVarChar, Me.cmbClaimClassType.Text)
            Else
                cmbClaimType.DataSource = BaseForm.FillCombo("eisdat.FetchClaimType", "EisTipekode", "EisTipeEngels", , , "@Afdeling", , SqlDbType.NVarChar, Me.cmbClaimClassType.Text)
            End If
            cmbClaimType.DisplayMember = "ComboBoxName"
            cmbClaimType.ValueMember = "ComboBoxID"
        End If

        'cmbClaimType.Text = ""
        cmbClaimType.SelectedValue = -1

        'Reinsurer
        cmbReinsurer.DataSource = BaseForm.FillCombo("poldata5.FetchVersekeraar", "pkVersekeraar", "Naam", "", "", "", "")
        cmbReinsurer.DisplayMember = "ComboBoxName"
        cmbReinsurer.ValueMember = "ComboBoxID"

        'cmbReinsurer.Text = ""
        cmbReinsurer.SelectedIndex = -1

        'catastrophe
        Using conn As SqlConnection = SqlHelper.GetConnection

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchKatastrofe")
            cmbCatastrophe.Items.Clear()
            Do While reader.Read
                cmbCatastrophe.Items.Add(reader("naam"))
            Loop
            If conn.State = ConnectionState.Open Then
                conn.Close()
                reader.Close()
            End If
        End Using

        'cmbCatastrophe.Text = ""
        Me.cmbCatastrophe.SelectedIndex = -1

        'Claimstatus
        cmbClaimStatus.DataSource = BaseForm.FillCombo("eisdat.FetchClaimStatus", "pkClaimStatus", "ClaimStatusAfr", "", "", "", "")
        cmbClaimStatus.DisplayMember = "ComboBoxName"
        cmbClaimStatus.ValueMember = "ComboBoxID"
        'Me.cmbClaimStatus.Text = ""
        Me.cmbClaimStatus.SelectedIndex = -1
        Me.cmbClaimStatus.Refresh()

        'claimsubstatus
        cmbClaimSubstatus.DataSource = BaseForm.FillCombo("eisdat.FetchClaimSubStatus", "pkClaimSubStatus", "ClaimSubStatusAfr", "", "", "", "")
        cmbClaimSubstatus.DisplayMember = "ComboBoxName"
        cmbClaimSubstatus.ValueMember = "ComboBoxID"
        'cmbClaimSubstatus.Text = ""
        Me.cmbClaimSubstatus.SelectedIndex = -1

    End Sub

    Private Sub CatastrophesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CatastrophesToolStripMenuItem.Click
        frmClaimsCatastrophe.Show()
    End Sub

    Private Sub BeneficiariesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BeneficiariesToolStripMenuItem.Click
        frmClaimsBeneficiary.Show()
    End Sub

    Private Sub getClaimData()
        blnClaimLoading = True
        CleanFields()
        If intRow >= 0 Then
            Me.lstSecurity.Items.Clear()
            Try
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim paramsClaims() As SqlParameter = {New SqlParameter("@Eisno", SqlDbType.NVarChar)}
                    paramsClaims(0).Value = Me.dgvClaims.Item(0, intRow).Value

                    Dim readerClaims As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchEisdatEisno", paramsClaims)

                    If readerClaims.Read Then
                        Dim item As ClaimsEntity = New ClaimsEntity()
                        entClaims = New ClaimsEntity()

                        If readerClaims("polisno") IsNot DBNull.Value Then
                            item.Polisno = readerClaims("polisno")
                        Else
                            item.Polisno = ""
                        End If
                        If readerClaims("eisno") IsNot DBNull.Value Then
                            item.Eisno = readerClaims("eisno")
                        Else
                            item.Eisno = ""
                        End If
                        If readerClaims("datum") IsNot DBNull.Value Then
                            item.Datum = readerClaims("datum")
                        Else
                            item.Datum = Nothing
                        End If
                        If readerClaims("beskrywing") IsNot DBNull.Value Then
                            item.Beskrywing = readerClaims("beskrywing")
                        Else
                            item.Beskrywing = ""
                        End If
                        If readerClaims("beskrywing2") IsNot DBNull.Value Then
                            item.Beskrywing2 = readerClaims("beskrywing2")
                        Else
                            item.Beskrywing2 = ""
                        End If
                        If readerClaims("beskrywing3") IsNot DBNull.Value Then
                            item.Beskrywing3 = readerClaims("beskrywing3")
                        Else
                            item.Beskrywing3 = ""
                        End If
                        If readerClaims("fkClaimstatus") IsNot DBNull.Value Then
                            item.fkClaimstatus = readerClaims("fkClaimstatus")
                        Else
                            item.fkClaimstatus = 0
                        End If
                        If readerClaims("fkClaimSubstatus") IsNot DBNull.Value Then
                            item.fkClaimSubstatus = readerClaims("fkClaimSubstatus")
                        Else
                            item.fkClaimSubstatus = 0
                        End If
                        If readerClaims("afdat2") IsNot DBNull.Value Then
                            item.afdat2 = readerClaims("afdat2")
                        Else
                            item.afdat2 = Nothing
                        End If
                        If readerClaims("Aan_dat") IsNot DBNull.Value Then
                            item.Aan_dat = readerClaims("Aan_dat")
                        Else
                            item.Aan_dat = Today
                        End If
                        If readerClaims("Tipe2") IsNot DBNull.Value Then
                            item.Tipe2 = readerClaims("Tipe2")
                        Else
                            item.Tipe2 = ""
                        End If
                        If readerClaims("EisGrNum") IsNot DBNull.Value Then
                            item.EisGrNum = readerClaims("EisGrNum")
                        Else
                            item.EisGrNum = 0
                        End If
                        If readerClaims("fkVersekeraar") IsNot DBNull.Value Then
                            item.fkVersekeraar = readerClaims("fkVersekeraar")
                        Else
                            item.fkVersekeraar = 0
                        End If
                        If readerClaims("Bybetalingsbedrag") IsNot DBNull.Value Then
                            item.Bybetalingsbedrag = readerClaims("Bybetalingsbedrag")
                        Else
                            item.Bybetalingsbedrag = 0
                        End If
                        If readerClaims("fkMakelaar") IsNot DBNull.Value Then
                            item.fkMakelaar = readerClaims("fkMakelaar")
                        Else
                            item.fkMakelaar = 0
                        End If
                        If readerClaims("beskrywing4") IsNot DBNull.Value Then
                            item.Beskrywing4 = readerClaims("beskrywing4")
                        Else
                            item.Beskrywing4 = ""
                        End If
                        If readerClaims("Voorstad") IsNot DBNull.Value Then
                            item.Voorstad = readerClaims("Voorstad")
                        Else
                            item.Voorstad = ""
                        End If
                        If readerClaims("Dorp") IsNot DBNull.Value Then
                            item.Dorp = readerClaims("Dorp")
                        Else
                            item.Dorp = ""
                        End If
                        If readerClaims("Poskode") IsNot DBNull.Value Then
                            item.Poskode = readerClaims("Poskode")
                        Else
                            item.Poskode = ""
                        End If
                        If readerClaims("EisBeskrywing") IsNot DBNull.Value Then
                            item.EisBeskrywing = readerClaims("EisBeskrywing")
                        Else
                            item.EisBeskrywing = ""
                        End If
                        If readerClaims("KatastrofeNaam") IsNot DBNull.Value Then
                            item.KatastrofeNaam = readerClaims("KatastrofeNaam")
                        Else
                            item.KatastrofeNaam = ""
                        End If
                        If readerClaims("ExGratia") IsNot DBNull.Value Then
                            item.ExGratia = readerClaims("ExGratia")
                        Else
                            item.ExGratia = ""
                        End If
                        If readerClaims("fkItem") IsNot DBNull.Value Then
                            item.fkItem = readerClaims("fkItem")
                        Else
                            item.fkItem = 0
                        End If
                        If readerClaims("ItemWaarde") IsNot DBNull.Value Then
                            item.ItemWaarde = readerClaims("ItemWaarde")
                        Else
                            item.ItemWaarde = 0
                        End If
                        If readerClaims("fkUma") IsNot DBNull.Value Then
                            item.fkUma = readerClaims("fkUma")
                        Else
                            item.fkUma = 0
                        End If
                        glbEisno = item.Eisno

                        intpkUMA = item.fkUma
                        intpkClassItem = item.fkItem
                        dblClassCover = item.ItemWaarde
                        dblEisGrootte = item.EisGrNum
                        intfkMakelaar = item.fkMakelaar
                        rsMakelaarSql = BaseForm.FetchMakeLaarByPk()
                        Me.txtBroker.Text = rsMakelaarSql.BeskrywingAfr
                        Me.txtClaimAmount.Text = item.EisGrNum
                        Me.cmbClaimClassType.BindingContext(item.Beskrywing).SuspendBinding()
                        Me.cmbClaimClassType.BindingContext(item.Beskrywing).ResumeBinding()
                        Me.cmbClaimClassType.Text = item.Beskrywing
                        'Me.txtClaimDescription2.Text = item.Beskrywing2
                        Me.txtClaimDescription3.Text = item.Beskrywing3
                        Me.txtClaimDescription4.Text = item.Beskrywing4
                        Me.txtClaimnumber.Text = item.Eisno
                        Me.cmbClaimStatus.BindingContext(item.fkClaimstatus).SuspendBinding()
                        Me.cmbClaimStatus.BindingContext(item.fkClaimstatus).ResumeBinding()
                        Me.cmbClaimStatus.SelectedValue = item.fkClaimstatus
                        Me.cmbClaimSubstatus.BindingContext(item.fkClaimSubstatus).SuspendBinding()
                        Me.cmbClaimSubstatus.BindingContext(item.fkClaimSubstatus).ResumeBinding()
                        Me.cmbClaimSubstatus.SelectedValue = item.fkClaimSubstatus
                        Me.txtExcess.Text = item.Bybetalingsbedrag
                        Me.cmbClaimType.BindingContext(item.Tipe2).SuspendBinding()
                        Me.cmbClaimType.BindingContext(item.Tipe2).ResumeBinding()
                        Me.cmbClaimType.SelectedValue = item.Tipe2
                        If item.afdat2 <> Nothing Then
                            Me.dtpClaimCompletionDate.Value = item.afdat2
                            Me.dtpClaimCompletionDate.Checked = True
                        Else
                            Me.dtpClaimCompletionDate.Value = Today
                            Me.dtpClaimCompletionDate.Checked = False
                        End If
                        If item.Datum <> Nothing Then
                            Me.dtpClaimDate.Value = item.Datum
                            Me.dtpClaimDate.Checked = True
                        Else
                            Me.dtpClaimDate.Value = item.Datum
                            Me.dtpClaimDate.Checked = False
                        End If
                        Me.dtpClaimReportDate.Value = item.Aan_dat
                        Me.dtpClaimReportDate.Checked = True
                        Me.cmbReinsurer.BindingContext(item.fkVersekeraar).SuspendBinding()
                        Me.cmbReinsurer.BindingContext(item.fkVersekeraar).ResumeBinding()
                        Me.cmbReinsurer.SelectedValue = item.fkVersekeraar
                        Me.txtSubburb.Text = item.Voorstad
                        Me.txtTown.Text = item.Dorp
                        Me.txtPostalCode.Text = item.Poskode
                        Me.txtShortClaimDescription.Text = item.EisBeskrywing
                        Me.cmbCatastrophe.BindingContext(item.KatastrofeNaam).SuspendBinding()
                        Me.cmbCatastrophe.BindingContext(item.KatastrofeNaam).ResumeBinding()
                        Me.cmbCatastrophe.Text = item.KatastrofeNaam
                        If item.ExGratia = "Ja" Then
                            optExgratiaYes.Checked = True
                        ElseIf item.ExGratia = "Nee" Then
                            optExGratiaNo.Checked = True
                        End If
                        populateEisramingsGrid()

                        'show/hide additional info
                        If item.Tipe2 = 601 Then 'Persoonlike regsaanspreeklikheid - hondbyte
                            Me.grpDogBite.Visible = True

                            If readerClaims("Hondgebyt") IsNot DBNull.Value Then
                                item.Hondgebyt = readerClaims("Hondgebyt")
                            Else
                                item.Hondgebyt = ""
                            End If
                            If readerClaims("Hondgedrag") IsNot DBNull.Value Then
                                item.Hondgedrag = readerClaims("Hondgedrag")
                            Else
                                item.Hondgedrag = ""
                            End If
                            If readerClaims("Aggressief") IsNot DBNull.Value Then
                                item.Aggressief = readerClaims("Aggressief")
                            Else
                                item.Aggressief = ""
                            End If
                            If readerClaims("WerfUitgaan") IsNot DBNull.Value Then
                                item.WerfUitgaan = readerClaims("WerfUitgaan")
                            Else
                                item.WerfUitgaan = ""
                            End If
                            If readerClaims("WatHetGebeur") IsNot DBNull.Value Then
                                item.WatHetGebeur = readerClaims("WatHetGebeur")
                            Else
                                item.WatHetGebeur = ""
                            End If
                            If readerClaims("RegsSoortEis") IsNot DBNull.Value Then
                                item.RegsSoortEis = readerClaims("RegsSoortEis")
                            Else
                                item.RegsSoortEis = ""
                            End If
                            Me.txtDogBiteDetails.Text = item.WatHetGebeur
                            Me.txtDogBiteHistory.Text = item.Hondgedrag
                            If item.RegsSoortEis = "Hondbyt" Then
                                optDogBite.Checked = True
                            ElseIf item.RegsSoortEis = "Tref en Trap" Then
                                optHitandRun.Checked = True
                            End If
                            If item.WerfUitgaan = "Ja" Then
                                optDogYardYes.Checked = True
                            ElseIf item.WerfUitgaan = "Nee" Then
                                optDogYardNo.Checked = True
                            End If
                            If item.Hondgebyt = "Ja" Then
                                optDogBitBeforeYes.Checked = True
                            ElseIf item.Hondgebyt = "Nee" Then
                                optDogBitBeforeNo.Checked = True
                            End If
                            If item.Aggressief = "Ja" Then
                                optDogAggressiveYes.Checked = True
                            ElseIf item.Aggressief = "Nee" Then
                                optDogAggressiveNo.Checked = True
                            End If
                        ElseIf item.Tipe2 = 16 Or item.Tipe2 = 170 Then   'Weerlig/powersurges
                            Me.lblThunder.Visible = True
                            Me.optThunderNo.Visible = True
                            Me.optThunderYes.Visible = True
                            If readerClaims("WeerligBeskermer") IsNot DBNull.Value Then
                                item.WeerligBeskermer = readerClaims("WeerligBeskermer")
                            Else
                                item.WeerligBeskermer = ""
                            End If
                            If item.WeerligBeskermer = "Ja" Then
                                optThunderYes.Checked = True
                            ElseIf item.WeerligBeskermer = "Nee" Then
                                optThunderNo.Checked = True
                            End If
                        ElseIf item.Tipe2 = 301 Or item.Tipe2 = 302 Or item.Tipe2 = 305 Or item.Tipe2 = 306 Or item.Tipe2 = 320 Or item.Tipe2 = 330 Then
                            Me.grpVehicle.Visible = True

                            If readerClaims("MotorTeruggekry") IsNot DBNull.Value Then
                                item.MotorTeruggekry = readerClaims("MotorTeruggekry")
                            Else
                                item.MotorTeruggekry = ""
                            End If
                            If readerClaims("SkadeBedrag") IsNot DBNull.Value Then
                                item.SkadeBedrag = readerClaims("SkadeBedrag")
                            Else
                                item.SkadeBedrag = ""
                            End If
                            If readerClaims("Motorgebruik") IsNot DBNull.Value Then
                                item.Motorgebruik = readerClaims("Motorgebruik")
                            Else
                                item.Motorgebruik = ""
                            End If
                            If readerClaims("BestuurderIDNommer") IsNot DBNull.Value Then
                                item.BestuurderIDNommer = readerClaims("BestuurderIDNommer")
                            Else
                                item.BestuurderIDNommer = ""
                            End If
                            If readerClaims("DwelmMisbruik") IsNot DBNull.Value Then
                                item.DwelmMisbruik = readerClaims("DwelmMisbruik")
                            Else
                                item.DwelmMisbruik = ""
                            End If
                            If readerClaims("KnockVirKnock") IsNot DBNull.Value Then
                                item.KnockVirKnock = readerClaims("KnockVirKnock")
                            Else
                                item.KnockVirKnock = ""
                            End If
                            If readerClaims("Waargekry") IsNot DBNull.Value Then
                                item.Waargekry = readerClaims("Waargekry")
                            Else
                                item.Waargekry = ""
                            End If
                            If readerClaims("Afgeskryf") IsNot DBNull.Value Then
                                item.Afgeskryf = readerClaims("Afgeskryf")
                            Else
                                item.Afgeskryf = ""
                            End If

                            Me.txtDamageAmount.Text = item.SkadeBedrag
                            Me.txtVehicleUse.Text = item.Motorgebruik
                            Me.txtDriverIDnr.Text = item.BestuurderIDNommer
                            Me.txtWhereVehicleFound.Text = item.Waargekry
                            If item.KnockVirKnock = "Ja" Then
                                Me.optKnockYes.Checked = True
                            ElseIf item.KnockVirKnock = "Nee" Then
                                Me.optKnockNo.Checked = True
                            End If
                            If item.Afgeskryf = "Ja" Then
                                Me.optWriteoffYes.Checked = True
                            ElseIf item.Afgeskryf = "Nee" Then
                                Me.optWriteoffNo.Checked = True
                            End If
                            If item.MotorTeruggekry = "Ja" Then
                                Me.optVehiclefoundYes.Checked = True
                            ElseIf item.MotorTeruggekry = "Nee" Then
                                Me.optVehicleFoundNo.Checked = True
                            End If
                            If item.DwelmMisbruik = "Ja" Then
                                Me.optAlcoholYes.Checked = True
                            ElseIf item.DwelmMisbruik = "Nee" Then
                                Me.optAlcoholNo.Checked = True
                            End If
                        End If

                        'sekuriteit
                        Me.lstSecurity.Items.Clear()
                        If item.Beskrywing = "Motor" Or item.Beskrywing = "Waterlewe" Or item.Beskrywing = "Huiseienaar" Or item.Beskrywing = "Huisbewoner" Then
                            Dim strSekuriteit As String = ""
                            Dim bitSekuriteit As Byte = 0
                            Dim j As Integer = 0

                            If item.Beskrywing = "Motor" Or item.Beskrywing = "Waterlewe" Then
                                strSekuriteit = "Voertuig"

                                If item.fkItem <> 0 Then
                                    voertuie = BaseForm.FetchVoertuie(item.fkItem)
                                    bitSekuriteit = voertuie.SekuriteitBitValue
                                Else
                                End If
                                If Persoonl.TAAL = 0 Then
                                    If voertuie.TIPE_DEK = 1 Then
                                        Me.txtTypeofCover.Text = "Omvattend"
                                    ElseIf voertuie.TIPE_DEK = 2 Then
                                        Me.txtTypeofCover.Text = "Balans, Derde party, Brand & Diefstal"
                                    Else
                                        Me.txtTypeofCover.Text = "Balans & Derde party"
                                    End If
                                Else
                                    If voertuie.TIPE_DEK = 1 Then
                                        Me.txtTypeofCover.Text = "Comprehensive"
                                    ElseIf voertuie.TIPE_DEK = 2 Then
                                        Me.txtTypeofCover.Text = "Balance, Third party, Fire & Theft"
                                    Else
                                        Me.txtTypeofCover.Text = "Balance & Third party"
                                    End If
                                End If
                            Else
                                strSekuriteit = "Eiendom"

                                If item.fkItem <> 0 Then
                                    huis = BaseForm.GetHuisByPrimaryKey(item.fkItem)
                                    bitSekuriteit = huis.SekuriteitBitValue
                                Else
                                End If
                            End If

                            listSekuriteit = BaseForm.FetchSekuriteitList(strSekuriteit)

                            If bitSekuriteit <> 0 Then
                                For j = 0 To listSekuriteit.Count
                                    If bitSekuriteit And (2 ^ j) Then
                                        If Persoonl.TAAL = 0 Then
                                            Me.lstSecurity.Items.Add(listSekuriteit(j).BeskrywingAfrikaans)
                                        Else
                                            Me.lstSecurity.Items.Add(listSekuriteit(j).BeskrywingEngels)
                                        End If
                                    End If
                                Next
                            Else
                                Me.lstSecurity.Items.Add("None")
                            End If
                        End If
                        Me.cmbClaimStatus.Refresh()
                        Me.cmbClaimSubstatus.Refresh()
                        Me.cmbClaimClassType.Refresh()
                        Me.cmbCatastrophe.Refresh()
                        Me.cmbClaimType.Refresh()
                        Me.cmbReinsurer.Refresh()
                        entClaims = item
                    Else
                        MsgBox("The Claim could not be found.", vbInformation)
                    End If
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                        readerClaims.Close()
                    End If
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try

            GetAllIncome()
            GetAllPayments()
            GetAllJournals()
            populateAssessorsGrid()
            Me.cmbClaimStatus.Refresh()
            Me.cmbClaimSubstatus.Refresh()

            Dim dblBybetalings As Decimal = 0
            Try
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim paramsClaims() As SqlParameter = {New SqlParameter("@Eisno", SqlDbType.NVarChar)}
                    paramsClaims(0).Value = glbEisno

                    Dim readerClaims As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchBybetalingsEisno", paramsClaims)

                    Do While readerClaims.Read
                        dblBybetalings = dblBybetalings + readerClaims("vord_premie")
                    Loop

                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                        readerClaims.Close()
                    End If
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try

            Dim dblClaimOutstandingAmount As Decimal = 0
            dblClaimAmount = dblPayments + dblBybetalings - dblIncome + dblJournals
            dblClaimOutstandingAmount = dblEisGrootte - dblPayments - dblJournals
            Me.lblActualClaimAmount.Text = dblClaimAmount & " = " & dblPayments & " + " & dblBybetalings & " - " & dblIncome & " + (" & dblJournals & ")"
            Me.lblClaimOutstandingAmount.Text = dblClaimOutstandingAmount & " = " & dblEisGrootte & " - " & dblPayments & " - (" & dblJournals & ")"

        End If
        blnInfoChanges = False
        blnClaimLoading = False
    End Sub
    Private Sub populateEisramingsGrid()
        dgvClaimEstimate.AutoGenerateColumns = False
        dgvClaimEstimate.DataSource = Nothing
        dgvClaimEstimate.Refresh()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim paramsClaims() As SqlParameter = {New SqlParameter("@Eisno", SqlDbType.NVarChar)}
                paramsClaims(0).Value = glbEisno

                Dim readerClaims As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchEisramingsEisno", paramsClaims)

                Dim ClaimsEstimate As List(Of ClaimsEisramingsEntity) = New List(Of ClaimsEisramingsEntity)

                Do While readerClaims.Read
                    Dim item As ClaimsEisramingsEntity = New ClaimsEisramingsEntity()

                    If readerClaims("Polisno") IsNot DBNull.Value Then
                        item.Polisno = readerClaims("Polisno")
                    Else
                        item.Polisno = ""
                    End If
                    If readerClaims("Eisno") IsNot DBNull.Value Then
                        item.Eisno = readerClaims("Eisno")
                    Else
                        item.Eisno = ""
                    End If
                    If readerClaims("Eisramingsbedrag") IsNot DBNull.Value Then
                        item.Eisramingsbedrag = readerClaims("Eisramingsbedrag")
                    Else
                        item.Eisramingsbedrag = 0
                    End If
                    If readerClaims("Eisramingsdatum") IsNot DBNull.Value Then
                        item.Eisramingsdatum = readerClaims("Eisramingsdatum")
                    Else
                        item.Eisramingsdatum = ""
                    End If

                    ClaimsEstimate.Add(item)
                Loop

                dgvClaimEstimate.DataSource = ClaimsEstimate

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    readerClaims.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub dgvClaims_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClaims.CellClick
        blnNewClaim = False
        intRow = e.RowIndex
        FieldsEnabled(False)
        blnAssessorClaim = False
        tabClaims.SelectedTab = Me.tabClaims1
        getClaimData()
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        blnNewClaim = False
        getClaimData()
        FieldsEnabled(True)

    End Sub

    Private Sub btnVoegby_Click(sender As System.Object, e As System.EventArgs) Handles btnVoegby.Click
        FieldsEnabled(True)
        blnNewClaim = True

        blnAssessorClaim = False
        CleanFields()
        tabClaims.SelectedTab = Me.tabClaims1
        dgvClaimIncome.AutoGenerateColumns = False
        dgvClaimIncome.DataSource = Nothing
        dgvClaimIncome.Refresh()
        dgvPayments.AutoGenerateColumns = False
        dgvPayments.DataSource = Nothing
        dgvPayments.Refresh()
        dgvClaimAssessors.AutoGenerateColumns = False
        dgvClaimAssessors.DataSource = Nothing
        dgvClaimAssessors.Refresh()
        dgvClaimEstimate.AutoGenerateColumns = False
        dgvClaimEstimate.DataSource = Nothing
        dgvClaimEstimate.Refresh()
        dgvClaimJournals.AutoGenerateColumns = False
        dgvClaimJournals.DataSource = Nothing
        dgvClaimJournals.Refresh()
        dblIncome = 0
        dblPayments = 0
        dblClaimAmount = 0
        dblJournals = 0
        dblEisGrootte = 0

        frmClaimsClassList.Show()

        GetInsurerBrokerInfo()
        Me.cmbReinsurer.SelectedValue = intfkVersekeraar

        'default claim status and claim substatus
        Me.cmbClaimStatus.SelectedIndex = 1
        Me.cmbClaimSubstatus.SelectedIndex = 4
        Me.dtpClaimDate.Checked = False
    End Sub
    Private Sub CleanFields()
        Me.txtClaimAmount.Text = ""
        'Me.txtClaimDescription2.Text = ""
        Me.txtClaimDescription3.Text = ""
        Me.txtClaimDescription4.Text = ""
        Me.txtClaimnumber.Text = ""
        Me.cmbClaimStatus.Text = ""
        Me.cmbClaimSubstatus.Text = ""
        Me.txtExcess.Text = ""
        Me.txtPostalCode.Text = ""
        Me.txtShortClaimDescription.Text = ""
        Me.txtSubburb.Text = ""
        Me.txtTown.Text = ""
        Me.txtBroker.Text = ""
        Me.cmbClaimClassType.Text = ""
        Me.cmbClaimType.Text = ""
        Me.cmbReinsurer.Text = ""
        Me.dtpClaimCompletionDate.Value = Today
        Me.dtpClaimDate.Value = Today
        Me.dtpClaimReportDate.Value = Today
        Me.dtpClaimCompletionDate.Checked = False
        Me.txtTypeofCover.Text = ""
        Me.txtDriverIDnr.Text = ""
        Me.txtVehicleUse.Text = ""
        Me.grpDogBite.Visible = False
        Me.grpVehicle.Visible = False
        Me.cmbCatastrophe.SelectedIndex = -1
        Me.cmbClaimClassType.SelectedIndex = -1
        Me.cmbClaimStatus.SelectedIndex = -1
        Me.cmbClaimSubstatus.SelectedIndex = -1
        Me.cmbClaimType.SelectedIndex = -1
        Me.cmbReinsurer.SelectedIndex = -1
        Me.lstSecurity.Items.Clear()
        Me.lblActualClaimAmount.Text = ""
        Me.lblClaimOutstandingAmount.Text = ""
        Me.lblTotalIncome.Text = ""
        Me.lblTotalJournal.Text = ""
        Me.lblTotalPayments.Text = ""

    End Sub


    Private Sub GetInsurerBrokerInfo()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar)}
                params(0).Value = glbPolicyNumber

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAreaMakelaarUMAVersekeraarPolisno", params)

                If reader.Read Then
                    intfkVersekeraar = reader("pkversekeraar")
                    intpkUMA = reader("pkUMA")
                    If reader("fkvorigemakelaar") IsNot DBNull.Value Then
                        If reader("datecancelled") IsNot DBNull.Value Then
                            Try
                                Using conn1 As SqlConnection = SqlHelper.GetConnection
                                    Dim params1() As SqlParameter = {New SqlParameter("@fkMakelaar", SqlDbType.Int)}
                                    params1(0).Value = reader("fkvorigemakelaar")

                                    Dim reader1 As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchMakelaarByPk", params1)

                                    If reader1.Read Then
                                        If Me.dtpClaimDate.Value >= reader1("datecancelled") Then
                                            intfkMakelaar = reader("pkmakelaar")
                                        Else
                                            intfkMakelaar = reader("fkvorigemakelaar")
                                        End If
                                    End If

                                    If conn1.State = ConnectionState.Open Then
                                        conn1.Close()
                                        reader1.Close()
                                    End If
                                End Using
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Critical)
                            End Try
                        Else
                            intfkMakelaar = reader("pkmakelaar")
                        End If
                    Else
                        intfkMakelaar = reader("pkmakelaar")
                    End If
                End If

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    reader.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub ClaimsValidation()
        blnClaimsValidation = False

        'Claim number 
        If Me.txtClaimnumber.Text = "" Then
            MsgBox("A claim number is required.", vbInformation)
            blnClaimsValidation = False
            tabClaims.SelectedTab = Me.tabClaims1
            Me.txtClaimnumber.Focus()
            Me.btnOKClaims.Enabled = True
            Exit Sub
        End If
        If Len(Me.txtClaimnumber.Text) <> 10 Then
            MsgBox("The claim number must be 10 characters.", vbInformation)
            blnClaimsValidation = False
            tabClaims.SelectedTab = Me.tabClaims1
            Me.txtClaimnumber.Focus()
            Me.btnOKClaims.Enabled = True
            Exit Sub
        End If
        'unique claim number
        If blnNewClaim = True Then
            UniqueClaimNr()
            If blnUnique = False Then
                blnClaimsValidation = False
                MsgBox("A claim with this number already exists.  The claim number must be unique.", vbInformation)
                tabClaims.SelectedTab = Me.tabClaims1
                Me.txtClaimnumber.Focus()
                Me.btnOKClaims.Enabled = True
                Exit Sub
            End If
        End If

        'claim amount
        If Me.txtClaimAmount.Text = "" Then
            MsgBox("A claim amount is required.", vbInformation)
            blnClaimsValidation = False
            tabClaims.SelectedTab = Me.tabClaims1
            Me.txtClaimAmount.Focus()
            Me.btnOKClaims.Enabled = True
            Exit Sub
        End If
        If (Not (IsNumeric(txtClaimAmount.Text))) Then
            MsgBox("Claim Amount value must be numeric!", vbInformation)
            tabClaims.SelectedTab = Me.tabClaims1
            Me.txtClaimAmount.Focus()
            blnClaimsValidation = False
            Exit Sub
        End If

        'claim class type
        If Me.cmbClaimClassType.Text = "" Then
            MsgBox("A claim classs type is required.", vbInformation)
            blnClaimsValidation = False
            tabClaims.SelectedTab = Me.tabClaims1
            Me.cmbClaimClassType.Focus()
            Me.btnOKClaims.Enabled = True
            Exit Sub
        End If

        'claim type
        If Me.cmbClaimType.Text = "" Then
            MsgBox("A claim type is required.", vbInformation)
            blnClaimsValidation = False
            tabClaims.SelectedTab = Me.tabClaims1
            Me.cmbClaimType.Focus()
            Me.btnOKClaims.Enabled = True
            Exit Sub
        End If

        'claim status
        If Me.cmbClaimStatus.Text = "" Then
            MsgBox("A claim status is required.", vbInformation)
            blnClaimsValidation = False
            tabClaims.SelectedTab = Me.tabClaims1
            Me.cmbClaimStatus.Focus()
            Me.btnOKClaims.Enabled = True
            Exit Sub
        End If

        'claim substatus
        If Me.cmbClaimSubstatus.Text = "" Then
            MsgBox("A claim substatus is required.", vbInformation)
            blnClaimsValidation = False
            tabClaims.SelectedTab = Me.tabClaims1
            Me.cmbClaimSubstatus.Focus()
            Me.btnOKClaims.Enabled = True
            Exit Sub
        End If

        'excess
        If Me.txtExcess.Text = "" Then
            MsgBox("A claim excess value is required.", vbInformation)
            blnClaimsValidation = False
            tabClaims.SelectedTab = Me.tabClaims1
            Me.txtExcess.Focus()
            Me.btnOKClaims.Enabled = True
            Exit Sub
        End If
        If (Not (IsNumeric(txtExcess.Text))) Then
            MsgBox("Claim Excess value must be numeric!", vbInformation)
            tabClaims.SelectedTab = Me.tabClaims1
            Me.txtExcess.Focus()
            blnClaimsValidation = False
            Exit Sub
        End If

        'claimdate
        If Me.dtpClaimDate.Checked = False Then
            MsgBox("A claim date is required.", vbInformation)
            blnClaimsValidation = False
            tabClaims.SelectedTab = Me.tabClaims1
            Me.dtpClaimDate.Focus()
            Me.btnOKClaims.Enabled = True
            Exit Sub
        End If

        glbVersekeraar = cmbReinsurer.SelectedValue
        Dim clsRun As New clsRuns()
        clsRun.GetInsurer()

        If Me.dtpClaimDate.Value >= dteInsuredStartDate Then
            If glbVersekeraar <> Area.fkversekeraar Then
                If MsgBox("Are you sure you want to change the Reinsurer to a Reinsurer that is not currently active on this policy?", vbYesNo) = vbYes Then
                    intfkVersekeraar = intPKInsurer
                Else
                    blnClaimsValidation = False
                    tabClaims.SelectedTab = Me.tabClaims1
                    Me.cmbReinsurer.Focus()
                    Exit Sub
                End If
            End If
        Else
            MsgBox("The Reinsurer was not yet active on the date of the claim, please choose the correct Reinsurer.", vbInformation)
            tabClaims.SelectedTab = Me.tabClaims1
            Me.cmbReinsurer.Focus()
            blnClaimsValidation = False
            Exit Sub
        End If

        'Termynpolis - as eisdatum na Term end is, kan eis nie geskep word nie
        If Persoonl.BET_WYSE = "6" Then
            Dim dteDateStart, dteDateEnd As Date
            Dim bteMonths, bteTermStatus As Byte
            Dim strTermDesc As String = ""
            Dim strStatusDesc As String = ""

            'Term policies
            clsRun.gen_GetTermPolicyStatus(Persoonl.BET_WYSE, glbPolicyNumber, dteDateStart, dteDateEnd, bteMonths, strTermDesc, strStatusDesc, bteTermStatus)
            If Me.dtpClaimDate.Value > dteTermDateEnd Then
                MsgBox("The claimdate is after the term ended. There is no cover for this claim.", vbInformation)
                tabClaims.SelectedTab = Me.tabClaims1
                blnClaimsValidation = False
                Exit Sub
            End If
        End If

        'Aanvangsdatum is later as eisdatum
        If Persoonl.P_A_DAT > Me.dtpClaimDate.Value Then
            MsgBox("The claimdate is before the startdate of the policy, so there is no cover for this claim.", vbInformation)
            tabClaims.SelectedTab = Me.tabClaims1
            blnClaimsValidation = False
            Exit Sub
        End If

        'Adres moet ingevul wees
        If Me.txtSubburb.Text = "" Then
            MsgBox("The address where the claim took place is required.", vbInformation)
            blnClaimsValidation = False
            tabClaims.SelectedTab = Me.tabClaims1
            Me.txtSubburb.Focus()
            Me.btnOKClaims.Enabled = True
            Exit Sub
        End If

        If blnNewClaim = False Then
            'diefstal en kaping moet weet of voertuig gevind is
            If Me.cmbClaimType.SelectedValue = 320 Or Me.cmbClaimType.SelectedValue = 330 Then
                If Me.optVehiclefoundYes.Checked = False And Me.optVehicleFoundNo.Checked = False Then
                    MsgBox("Vehicle recovered is required.", vbInformation)
                    tabClaims.SelectedTab = Me.TabClaims4
                    blnClaimsValidation = False
                    Exit Sub
                End If
            End If

            'afgehandelde motoreis moet dwelmmisbruik en afgeskryf waardes he
            If Me.cmbClaimType.SelectedValue = 301 Or Me.cmbClaimType.SelectedValue = 302 Or Me.cmbClaimType.SelectedValue = 305 Or Me.cmbClaimType.SelectedValue = 306 Then
                If Me.optAlcoholYes.Checked = False And Me.optAlcoholNo.Checked = False Then
                    MsgBox("Tested for Alcohol/drugs is required.", vbInformation)
                    tabClaims.SelectedTab = Me.TabClaims4
                    blnClaimsValidation = False
                    Exit Sub
                End If
            End If
            If Me.cmbClaimType.SelectedValue = 301 Or Me.cmbClaimType.SelectedValue = 305 Or Me.cmbClaimType.SelectedValue = 306 Or Me.cmbClaimType.SelectedValue = 320 Or Me.cmbClaimType.SelectedValue = 330 Then
                If Me.optWriteoffYes.Checked = False And Me.optWriteoffNo.Checked = False Then
                    MsgBox("Vehicle written off is required.", vbInformation)
                    tabClaims.SelectedTab = Me.TabClaims4
                    blnClaimsValidation = False
                    Exit Sub
                End If
            End If
        End If

        'aktiewe eise mag nie afhandel datum he nie, en afgehandelde eis moet afhandel datum he
        If Me.cmbClaimStatus.SelectedValue = 1 Then
            If Me.dtpClaimCompletionDate.Checked = False Then
                MsgBox("A completed claim must have a completion date.", vbInformation)
                Me.dtpClaimCompletionDate.Focus()
                tabClaims.SelectedTab = Me.tabClaims1
                blnClaimsValidation = False
                Exit Sub
            End If
        Else
            If Me.dtpClaimCompletionDate.Checked = True Then
                MsgBox("An active claim may not have a completed date.", vbInformation)
                Me.dtpClaimCompletionDate.Focus()
                tabClaims.SelectedTab = Me.tabClaims1
                blnClaimsValidation = False
                Exit Sub
            End If
        End If

        blnClaimsValidation = True
    End Sub
    Private Sub SaveClaimsDetails()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Eisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@eisgr", SqlDbType.NVarChar), _
                                                New SqlParameter("@tipe", SqlDbType.NVarChar), _
                                                New SqlParameter("@datum", SqlDbType.Date), _
                                                New SqlParameter("@afdat", SqlDbType.Date), _
                                                New SqlParameter("@aan_dat", SqlDbType.Date), _
                                                New SqlParameter("@beskrywing", SqlDbType.NVarChar), _
                                                New SqlParameter("@beskrywing2", SqlDbType.NVarChar), _
                                                New SqlParameter("@beskrywing3", SqlDbType.NVarChar), _
                                                New SqlParameter("@Eis_sorteer", SqlDbType.Bit), _
                                                New SqlParameter("@herverseker", SqlDbType.Real), _
                                                New SqlParameter("@hollard_kat", SqlDbType.Int), _
                                                New SqlParameter("@eisgrnum", SqlDbType.Money), _
                                                New SqlParameter("@tipe2", SqlDbType.Int), _
                                                New SqlParameter("@beskrywing4", SqlDbType.NVarChar), _
                                                New SqlParameter("@versekerde", SqlDbType.NVarChar), _
                                                New SqlParameter("@voorl", SqlDbType.NVarChar), _
                                                New SqlParameter("@afdat2", SqlDbType.NVarChar), _
                                                New SqlParameter("@bybetalingsbedrag", SqlDbType.Money), _
                                                New SqlParameter("@eismemo", SqlDbType.NVarChar), _
                                                New SqlParameter("@etbeskrywing", SqlDbType.NVarChar), _
                                                New SqlParameter("@etbeskrywing2", SqlDbType.NVarChar), _
                                                New SqlParameter("@voorstad", SqlDbType.NVarChar), _
                                                New SqlParameter("@dorp", SqlDbType.NVarChar), _
                                                New SqlParameter("@poskode", SqlDbType.NVarChar), _
                                                New SqlParameter("@weerligbeskermer", SqlDbType.NVarChar), _
                                                New SqlParameter("@eisbeskrywing", SqlDbType.NVarChar), _
                                                New SqlParameter("@motorteruggekry", SqlDbType.NVarChar), _
                                                New SqlParameter("@skadebedrag", SqlDbType.Money), _
                                                New SqlParameter("@motorgebruik", SqlDbType.NVarChar), _
                                                New SqlParameter("@bestuurderidnommer", SqlDbType.NVarChar), _
                                                New SqlParameter("@dwelmmisbruik", SqlDbType.NVarChar), _
                                                New SqlParameter("@knockvirknock", SqlDbType.NVarChar), _
                                                New SqlParameter("@hondgebyt", SqlDbType.NVarChar), _
                                                New SqlParameter("@aggressief", SqlDbType.NVarChar), _
                                                New SqlParameter("@werfuitgaan", SqlDbType.NVarChar), _
                                                New SqlParameter("@wathetgebeur", SqlDbType.NVarChar), _
                                                New SqlParameter("@waargekry", SqlDbType.NVarChar), _
                                                New SqlParameter("@eissubstatuskode", SqlDbType.NVarChar), _
                                                New SqlParameter("@exgratia", SqlDbType.NVarChar), _
                                                New SqlParameter("@regssoorteis", SqlDbType.NVarChar), _
                                                New SqlParameter("@hondgedrag", SqlDbType.NVarChar), _
                                                New SqlParameter("@itemwaarde", SqlDbType.Money), _
                                                New SqlParameter("@Afgeskryf", SqlDbType.NVarChar), _
                                                New SqlParameter("@katastrofejn", SqlDbType.NVarChar), _
                                                New SqlParameter("@katastrofenaam", SqlDbType.NVarChar), _
                                                New SqlParameter("@katastrofedatum", SqlDbType.Date), _
                                                New SqlParameter("@katastrofebybetalingsbedrag", SqlDbType.Money), _
                                                New SqlParameter("@FKItem", SqlDbType.Int), _
                                                New SqlParameter("@katastrofeTipe", SqlDbType.Int), _
                                                New SqlParameter("@fkVersekeraar", SqlDbType.Int), _
                                                New SqlParameter("@fkUMA", SqlDbType.Int), _
                                                New SqlParameter("@fkMakelaar", SqlDbType.Int), _
                                                New SqlParameter("@fkClaimStatus", SqlDbType.Int), _
                                                New SqlParameter("@fkClaimsubStatus", SqlDbType.Int)}

                params(0).Value = Me.txtClaimnumber.Text     'Eisno
                params(1).Value = glbPolicyNumber        'polisno
                params(2).Value = Me.txtClaimAmount.Text      'eisgr
                params(3).Value = DBNull.Value      'tipe
                params(4).Value = Me.dtpClaimDate.Value      'datum
                If Me.dtpClaimCompletionDate.Checked = True Then
                    params(5).Value = Me.dtpClaimCompletionDate.Value      'afdat
                Else
                    params(5).Value = DBNull.Value      'afdat
                End If
                params(6).Value = Me.dtpClaimReportDate.Value      'aan_dat
                params(7).Value = Me.cmbClaimClassType.Text      'beskrywing
                params(8).Value = Me.cmbClaimType.Text     'beskrywing2
                params(9).Value = Me.txtClaimDescription3.Text      'beskrywing3
                params(10).Value = False      'Eis_sorteer
                params(11).Value = 0     'herverseker
                params(12).Value = 0     'hollard_kat
                params(13).Value = CDec(Me.txtClaimAmount.Text)    'eisgrnum
                params(14).Value = Me.cmbClaimType.SelectedValue     'tipe2
                params(15).Value = Me.txtClaimDescription4.Text     'beskrywing4
                params(16).Value = Persoonl.VERSEKERDE     'versekerde
                params(17).Value = Persoonl.VOORL     'voorl
                If Me.dtpClaimCompletionDate.Checked = True Then
                    params(18).Value = CStr(Format(Me.dtpClaimCompletionDate.Value, "dd/MM/yyyy"))     'afdat2
                Else
                    params(18).Value = DBNull.Value      'afdat
                End If
                params(19).Value = IIf(Me.txtExcess.Text = "", 0, CDec(Me.txtExcess.Text))     'bybetalingsbedrag
                params(20).Value = DBNull.Value     'eismemo
                params(21).Value = DBNull.Value     'etbeskrywing
                params(22).Value = DBNull.Value     'etbeskrywing2
                params(23).Value = Me.txtSubburb.Text     'voorstad
                params(24).Value = Me.txtTown.Text     'dorp
                params(25).Value = Me.txtPostalCode.Text     'poskode
                If optThunderYes.Checked = True Then
                    params(26).Value = "Ja"    'weerligbeskermer
                ElseIf optThunderNo.Checked = True Then
                    params(26).Value = "Nee"     'weerligbeskermer
                Else
                    params(26).Value = DBNull.Value     'weerligbeskermer
                End If
                params(27).Value = Me.txtShortClaimDescription.Text     'eisbeskrywing
                If Me.optVehiclefoundYes.Checked = True Then
                    params(28).Value = "Ja"     'motorteruggekry
                ElseIf Me.optVehicleFoundNo.Checked = True Then
                    params(28).Value = "Nee"     'motorteruggekry
                Else
                    params(28).Value = DBNull.Value     'motorteruggekry
                End If
                If Me.txtDamageAmount.Text = "" Then
                    params(29).Value = 0     'skadebedrag
                Else
                    params(29).Value = CDec(Me.txtDamageAmount.Text)     'skadebedrag
                End If
                params(30).Value = Me.txtVehicleUse.Text     'motorgebruik
                params(31).Value = Me.txtDriverIDnr.Text     'bestuurderidnommer
                If Me.optAlcoholYes.Checked = True Then
                    params(32).Value = "Ja"     'dwelmmisbruik
                ElseIf Me.optAlcoholNo.Checked = True Then
                    params(32).Value = "Nee"     'dwelmmisbruik
                Else
                    params(32).Value = DBNull.Value     'dwelmmisbruik
                End If
                If Me.optKnockYes.Checked = True Then
                    params(33).Value = "Ja"     'knockvirknock
                ElseIf Me.optKnockNo.Checked = True Then
                    params(33).Value = "Nee"     'knockvirknock
                Else
                    params(33).Value = DBNull.Value     'knockvirknock
                End If
                If optDogBitBeforeYes.Checked = True Then
                    params(34).Value = "Ja"     'hondgebyt
                ElseIf optDogBitBeforeNo.Checked = True Then
                    params(34).Value = "Nee"     'hondgebyt
                Else
                    params(34).Value = DBNull.Value     'hondgebyt
                End If
                If optDogAggressiveYes.Checked = True Then
                    params(35).Value = "Ja"     'aggressief
                ElseIf optDogAggressiveNo.Checked = True Then
                    params(35).Value = "Nee"    'aggressief
                Else
                    params(35).Value = DBNull.Value     'aggressief
                End If
                If optDogYardYes.Checked = True Then
                    params(36).Value = "Ja"    'werfuitgaan
                ElseIf optDogYardNo.Checked = True Then
                    params(36).Value = "Nee"     'werfuitgaan
                Else
                    params(36).Value = DBNull.Value     'werfuitgaan
                End If
                params(37).Value = Me.txtDogBiteDetails.Text     'wathetgebeur
                params(38).Value = Me.txtWhereVehicleFound.Text     'waargekry
                params(39).Value = DBNull.Value     'eissubstatuskode
                If optExgratiaYes.Checked = True Then
                    params(40).Value = "Ja"     'exgratia
                Else
                    params(40).Value = "Nee"     'exgratia                
                End If
                If optDogBite.Checked = True Then
                    params(41).Value = "Hondbyt"     'regssoorteis
                ElseIf optHitandRun.Checked = True Then
                    params(41).Value = "Tref en Trap"     'regssoorteis
                Else
                    params(41).Value = DBNull.Value     'regssoorteis
                End If
                params(42).Value = Me.txtDogBiteHistory.Text     'hondgedrag
                params(43).Value = dblClassCover     'itemwaarde
                If Me.optWriteoffYes.Checked = True Then
                    params(44).Value = "Ja"     'Afgeskryf
                ElseIf Me.optWriteoffNo.Checked = True Then
                    params(44).Value = "Nee"     'Afgeskryf
                Else
                    params(44).Value = DBNull.Value     'Afgeskryf
                End If
                If Me.cmbCatastrophe.Text <> "" Then
                    params(45).Value = "J"     'katastrofejn
                Else
                    params(45).Value = "N"     'katastrofejn
                End If
                params(46).Value = Me.cmbCatastrophe.Text     'katastrofenaam
                If Trim(Me.cmbCatastrophe.Text) <> "" Then
                    'gaan kry katastrofe
                    params(47).Value = DBNull.Value     'katastrofedatum
                    params(48).Value = DBNull.Value     'katastrofebybetalingsbedrag
                    params(50).Value = DBNull.Value    'katastrofeTipe
                    'catastrophe
                    Using conn1 As SqlConnection = SqlHelper.GetConnection
                        Dim reader1 As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchKatastrofe")

                        Do While reader1.Read
                            If reader1("naam") = Me.cmbCatastrophe.Text Then
                                params(47).Value = reader1("datum")     'katastrofedatum
                                params(48).Value = reader1("bybetalingsbedrag")     'katastrofebybetalingsbedrag
                                params(50).Value = reader1("fkkatastrofeTipes")    'katastrofeTipe
                            End If
                        Loop
                        If conn1.State = ConnectionState.Open Then
                            conn1.Close()
                            reader1.Close()
                        End If
                    End Using
                Else
                    params(47).Value = DBNull.Value     'katastrofedatum
                    params(48).Value = DBNull.Value     'katastrofebybetalingsbedrag
                    params(50).Value = DBNull.Value    'katastrofeTipe
                End If
                params(49).Value = intpkClassItem    'FKItem - primary key van item
                params(51).Value = Me.cmbReinsurer.SelectedValue     'fkVersekeraar
                params(52).Value = intpkUMA     'fkUMA                    
                params(53).Value = intfkMakelaar     'fkMakelaar
                params(54).Value = Me.cmbClaimStatus.SelectedValue     'fkClaimStatus
                params(55).Value = Me.cmbClaimSubstatus.SelectedValue     'fkClaimsubStatus

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "eisdat.UpdateEis_dat", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
        If blnNewClaim = True Then
            glbEisno = Me.txtClaimnumber.Text
            SaveEisramings()
            If Persoonl.TAAL = 0 Then
                strBeskrywing = "Eis bygevoeg: " & glbEisno
            Else
                strBeskrywing = "Claim added: " & glbEisno
            End If
            BaseForm.UpdateWysig(66, strBeskrywing)
        End If
        CleanFields()
        populateClaimsGrid()
    End Sub
    Private Sub FieldsEnabled(ByVal blnEnabled As Boolean)
        Me.txtClaimAmount.Enabled = blnEnabled
        'Me.txtClaimDescription2.Enabled = blnEnabled
        Me.txtClaimDescription3.Enabled = blnEnabled
        Me.txtClaimDescription4.Enabled = blnEnabled
        Me.txtClaimnumber.Enabled = blnEnabled
        Me.cmbClaimStatus.Enabled = blnEnabled
        Me.cmbClaimSubstatus.Enabled = blnEnabled
        Me.txtExcess.Enabled = blnEnabled
        Me.txtPostalCode.Enabled = blnEnabled
        Me.txtShortClaimDescription.Enabled = blnEnabled
        Me.txtSubburb.Enabled = blnEnabled
        Me.txtTown.Enabled = blnEnabled
        Me.txtBroker.Enabled = blnEnabled
        Me.cmbClaimClassType.Enabled = blnEnabled
        Me.cmbClaimType.Enabled = blnEnabled
        Me.cmbReinsurer.Enabled = blnEnabled
        Me.dtpClaimCompletionDate.Enabled = blnEnabled
        Me.dtpClaimDate.Enabled = blnEnabled
        Me.dtpClaimReportDate.Enabled = blnEnabled
        Me.tabClaims2.Enabled = blnEnabled
        Me.TabClaims3.Enabled = blnEnabled
        Me.TabClaims4.Enabled = blnEnabled
        Me.btnAssessorDelete.Enabled = False
        Me.btnIncomeDelete.Enabled = False
        Me.btnIncomeJournal.Enabled = False
        Me.btnJournalDelete.Enabled = False
        Me.btnPaymentsDelete.Enabled = False
        Me.btnPaymentsJournal.Enabled = False
        Me.btnPostalcodes.Enabled = blnEnabled
        Me.btnApply.Enabled = blnEnabled
        Me.btnOKClaims.Enabled = blnEnabled
    End Sub


    Private Sub dgvClaims_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClaims.CellDoubleClick
        blnNewClaim = False
        blnAssessorClaim = False
        getClaimData()
        FieldsEnabled(True)

    End Sub

    Public Sub GetAllIncome()
        dgvClaimIncome.AutoGenerateColumns = False
        dgvClaimIncome.DataSource = Nothing
        dgvClaimIncome.Refresh()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim paramsClaims() As SqlParameter = {New SqlParameter("@Eisno", SqlDbType.NVarChar)}
                paramsClaims(0).Value = glbEisno

                Dim readerClaims As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchIncomeEisno", paramsClaims)

                Dim ClaimsIncome As List(Of ClaimsIncomeEntity) = New List(Of ClaimsIncomeEntity)

                Do While readerClaims.Read
                    Dim item As ClaimsIncomeEntity = New ClaimsIncomeEntity()

                    If readerClaims("polisno") IsNot DBNull.Value Then
                        item.polisno = readerClaims("polisno")
                    Else
                        item.polisno = ""
                    End If
                    If readerClaims("eisno") IsNot DBNull.Value Then
                        item.eisno = readerClaims("eisno")
                    Else
                        item.eisno = ""
                    End If
                    If readerClaims("DatumInkomste") IsNot DBNull.Value Then
                        item.DatumInkomste = readerClaims("DatumInkomste")
                    Else
                        item.DatumInkomste = Nothing
                    End If
                    If readerClaims("besonderhede") IsNot DBNull.Value Then
                        item.besonderhede = readerClaims("besonderhede")
                    Else
                        item.besonderhede = ""
                    End If
                    If readerClaims("kwitansienr") IsNot DBNull.Value Then
                        item.kwitansienr = readerClaims("kwitansienr")
                    Else
                        item.kwitansienr = ""
                    End If
                    If readerClaims("Tipe") IsNot DBNull.Value Then
                        item.Tipe = readerClaims("Tipe")
                    Else
                        item.Tipe = ""
                    End If
                    If readerClaims("bedrag") IsNot DBNull.Value Then
                        item.bedrag = readerClaims("bedrag")
                    Else
                        item.bedrag = 0
                    End If
                    If readerClaims("pkIncome") IsNot DBNull.Value Then
                        item.pkIncome = readerClaims("pkIncome")
                    Else
                        item.pkIncome = 0
                    End If
                    If readerClaims("Cancel") IsNot DBNull.Value Then
                        item.Cancel = readerClaims("Cancel")
                    End If
                    If item.Cancel = True Then
                        item.CancelIcon = 1
                    Else
                        item.CancelIcon = 0
                    End If

                    intpkIncome = item.pkIncome

                    ClaimsIncome.Add(item)
                Loop

                dgvClaimIncome.DataSource = ClaimsIncome

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    readerClaims.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        If dgvClaimIncome.RowCount = 0 Then
            Me.btnIncomeEdit.Enabled = False
        Else
            Me.btnIncomeEdit.Enabled = True
        End If
        Me.lblTotalIncome.Text = "Total Income:  R" & dblIncome
    End Sub

    Private Sub txtClaimnumber_GotFocus(sender As Object, e As System.EventArgs) Handles txtClaimnumber.GotFocus
        strVoor = Me.txtClaimnumber.Text
    End Sub

    Private Sub txtClaimnumber_Leave(sender As Object, e As System.EventArgs) Handles txtClaimnumber.Leave
        'unique claim number
        If blnNewClaim = True Then
            UniqueClaimNr()
            If blnUnique = False Then
                blnClaimsValidation = False
                MsgBox("A claim with this number already exists.  The claim number must be unique.", vbInformation)
                Me.btnOKClaims.Enabled = True
                Exit Sub
            End If
        End If

        glbEisno = Me.txtClaimnumber.Text
        If blnNewClaim = False And blnClaimLoading = False Then
            SkryfWysiging(Me.txtClaimnumber.Text, glbEisno, 67)
        End If
    End Sub

    Private Sub txtClaimnumber_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtClaimnumber.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub cmbClaimClassType_GotFocus(sender As Object, e As System.EventArgs) Handles cmbClaimClassType.GotFocus
        strVoor = Me.cmbClaimClassType.Text
    End Sub

    Private Sub cmbClaimClassType_Leave(sender As Object, e As System.EventArgs) Handles cmbClaimClassType.Leave
        If blnNewClaim = False And blnClaimLoading = False Then
            SkryfWysiging(Me.cmbClaimClassType.Text, glbEisno, 67)
        End If
    End Sub
    Private Sub SkryfWysiging(ByVal strNa As String, ByVal strBeskrywing As String, ByVal intKode As Integer)

        If strVoor <> strNa Then
            If Persoonl.TAAL = 0 Then
                strBeskrywing = strBeskrywing & " wysig vanaf (" & strVoor & ") na (" & strNa & ")"
            Else
                strBeskrywing = strBeskrywing & " change from (" & (strVoor) & ") to (" & strNa & ")"
            End If
            BaseForm.UpdateWysig(intKode, strBeskrywing)
        End If

    End Sub
    Private Sub cmbClaimClassType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbClaimClassType.SelectedIndexChanged
        blnInfoChanges = True

        'Claims Type
        If cmbClaimClassType.Text <> "" Then
            If Persoonl.TAAL = 0 Then
                cmbClaimType.DataSource = BaseForm.FillCombo("eisdat.FetchClaimType", "EisTipekode", "EisTipe", , , "@Afdeling", , SqlDbType.NVarChar, Me.cmbClaimClassType.Text)
            Else
                cmbClaimType.DataSource = BaseForm.FillCombo("eisdat.FetchClaimType", "EisTipekode", "EisTipeEngels", , , "@Afdeling", , SqlDbType.NVarChar, Me.cmbClaimClassType.Text)
            End If
            cmbClaimType.DisplayMember = "ComboBoxName"
            cmbClaimType.ValueMember = "ComboBoxID"
            cmbClaimType.SelectedIndex = -1
        End If

        'sekuriteit
        If Me.cmbClaimClassType.Text = "Motor" Or Me.cmbClaimClassType.Text = "Waterlewe" Or Me.cmbClaimClassType.Text = "Huiseienaar" Or Me.cmbClaimClassType.Text = "Huisbewoner" Then
            Me.lstSecurity.Items.Clear()
            Dim strSekuriteit As String = ""
            Dim bitSekuriteit As Byte = 0
            Dim j As Integer = 0

            If Me.cmbClaimClassType.Text = "Motor" Or Me.cmbClaimClassType.Text = "Waterlewe" Then
                strSekuriteit = "Voertuig"

                If intpkClassItem <> 0 Then
                    voertuie = BaseForm.FetchVoertuie(intpkClassItem)
                    bitSekuriteit = voertuie.SekuriteitBitValue
                Else
                End If

                If Persoonl.TAAL = 0 Then
                    If voertuie.TIPE_DEK = 1 Then
                        Me.txtTypeofCover.Text = "Omvattend"
                    ElseIf voertuie.TIPE_DEK = 2 Then
                        Me.txtTypeofCover.Text = "Balans, Derde party, Brand & Diefstal"
                    Else
                        Me.txtTypeofCover.Text = "Balans & Derde party"
                    End If
                Else
                    If voertuie.TIPE_DEK = 1 Then
                        Me.txtTypeofCover.Text = "Comprehensive"
                    ElseIf voertuie.TIPE_DEK = 2 Then
                        Me.txtTypeofCover.Text = "Balance, Third party, Fire & Theft"
                    Else
                        Me.txtTypeofCover.Text = "Balance & Third party"
                    End If
                End If
            Else
                strSekuriteit = "Eiendom"

                If intpkClassItem <> 0 Then
                    huis = BaseForm.GetHuisByPrimaryKey(intpkClassItem)
                    bitSekuriteit = huis.SekuriteitBitValue
                Else
                End If
            End If

            listSekuriteit = BaseForm.FetchSekuriteitList(strSekuriteit)

            If bitSekuriteit <> 0 Then
                For j = 0 To listSekuriteit.Count
                    If bitSekuriteit And (2 ^ j) Then
                        If Persoonl.TAAL = 0 Then
                            Me.lstSecurity.Items.Add(listSekuriteit(j).BeskrywingAfrikaans)
                        Else
                            Me.lstSecurity.Items.Add(listSekuriteit(j).BeskrywingEngels)
                        End If
                    End If
                Next
            Else
                Me.lstSecurity.Items.Add("None")
            End If
        End If
    End Sub

    Private Sub cmbClaimType_GotFocus(sender As Object, e As System.EventArgs) Handles cmbClaimType.GotFocus
        strVoor = Me.cmbClaimType.Text
    End Sub

    Private Sub cmbClaimType_Leave(sender As Object, e As System.EventArgs) Handles cmbClaimType.Leave
        'show/hide additional info
        If cmbClaimType.SelectedValue = 601 Then 'Persoonlike regsaanspreeklikheid - hondbyte
            Me.grpDogBite.Visible = True
        ElseIf Me.cmbClaimType.SelectedValue = 16 Or Me.cmbClaimType.SelectedValue = 170 Then   'Weerlig/powersurges
            Me.lblThunder.Visible = True
            Me.optThunderNo.Visible = True
            Me.optThunderYes.Visible = True
        ElseIf Me.cmbClaimType.SelectedValue = 301 Or Me.cmbClaimType.SelectedValue = 302 Or Me.cmbClaimType.SelectedValue = 305 Or Me.cmbClaimType.SelectedValue = 306 Or Me.cmbClaimType.SelectedValue = 320 Or Me.cmbClaimType.SelectedValue = 330 Then
            Me.grpVehicle.Visible = True
            voertuie = BaseForm.FetchVoertuie(intpkClassItem)
            If voertuie.GEBRUIK = 1 Then
                If Persoonl.TAAL = 0 Then
                    Me.txtVehicleUse.Text = "Privaat"
                Else
                    Me.txtVehicleUse.Text = "Private"
                End If
            Else
                If Persoonl.TAAL = 0 Then
                    Me.txtVehicleUse.Text = "Professioneel"
                Else
                    Me.txtVehicleUse.Text = "Professional"
                End If
            End If
            If blnNewClaim = True Then
                Me.optKnockNo.Checked = True
            End If
        End If

        Me.cmbClaimStatus.Refresh()
        Me.cmbClaimSubstatus.Refresh()
        Me.cmbClaimClassType.Refresh()
        Me.cmbCatastrophe.Refresh()
        Me.cmbClaimType.Refresh()
        Me.cmbReinsurer.Refresh()

        If blnNewClaim = False And blnClaimLoading = False Then
            SkryfWysiging(Me.cmbClaimType.Text, glbEisno, 67)
        End If
    End Sub

    Private Sub cmbClaimType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbClaimType.SelectedIndexChanged
        blnInfoChanges = True

    End Sub

    Private Sub txtClaimDescription2_TextChanged(sender As System.Object, e As System.EventArgs)
        blnInfoChanges = True
    End Sub

    Private Sub txtClaimDescription3_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtClaimDescription3.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtClaimDescription4_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtClaimDescription4.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtShortClaimDescription_GotFocus(sender As Object, e As System.EventArgs) Handles txtShortClaimDescription.GotFocus
        strVoor = Me.txtShortClaimDescription.Text
    End Sub

    Private Sub txtShortClaimDescription_Leave(sender As Object, e As System.EventArgs) Handles txtShortClaimDescription.Leave
        If blnNewClaim = False And blnClaimLoading = False Then
            SkryfWysiging(Me.txtShortClaimDescription.Text, glbEisno, 67)
        End If
    End Sub

    Private Sub txtShortClaimDescription_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtShortClaimDescription.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtSubburb_GotFocus(sender As Object, e As System.EventArgs) Handles txtSubburb.GotFocus
        strVoor = Me.txtSubburb.Text
    End Sub

    Private Sub txtSubburb_Leave(sender As Object, e As System.EventArgs) Handles txtSubburb.Leave
        If blnNewClaim = False And blnClaimLoading = False Then
            SkryfWysiging(Me.txtSubburb.Text, glbEisno, 67)
        End If
    End Sub

    Private Sub txtSubburb_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSubburb.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtTown_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTown.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtPostalCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPostalCode.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub cmbReinsurer_GotFocus(sender As Object, e As System.EventArgs) Handles cmbReinsurer.GotFocus
        strVoor = Me.cmbReinsurer.Text
    End Sub

    Private Sub cmbReinsurer_Leave(sender As Object, e As System.EventArgs) Handles cmbReinsurer.Leave
        If blnNewClaim = False And blnClaimLoading = False Then
            SkryfWysiging(Me.cmbReinsurer.Text, glbEisno, 67)
        End If
    End Sub

    Private Sub cmbReinsurer_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbReinsurer.SelectedIndexChanged
        blnInfoChanges = True

    End Sub

    Private Sub txtReinsureAmount_TextChanged(sender As System.Object, e As System.EventArgs)
        blnInfoChanges = True
    End Sub

    Private Sub cmbBroker_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        blnInfoChanges = True
    End Sub

    Private Sub txtExcess_GotFocus(sender As Object, e As System.EventArgs) Handles txtExcess.GotFocus
        strVoor = Me.txtExcess.Text
    End Sub

    Private Sub txtExcess_Leave(sender As Object, e As System.EventArgs) Handles txtExcess.Leave
        If blnNewClaim = False And blnClaimLoading = False Then
            SkryfWysiging(Me.txtExcess.Text, glbEisno, 67)
        End If
    End Sub

    Private Sub txtExcess_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtExcess.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtClaimAmount_GotFocus(sender As Object, e As System.EventArgs) Handles txtClaimAmount.GotFocus
        strVoor = Me.txtClaimAmount.Text
    End Sub

    Private Sub txtClaimAmount_Leave(sender As Object, e As System.EventArgs) Handles txtClaimAmount.Leave
        If blnNewClaim = False And blnClaimLoading = False Then
            SaveEisramings()
            SkryfWysiging(Me.txtClaimAmount.Text, glbEisno, 67)
        End If
    End Sub


    Private Sub txtClaimAmount_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtClaimAmount.TextChanged
        blnInfoChanges = True
    End Sub
    Private Sub SaveEisramings()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@Eisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@eisramingsbedrag", SqlDbType.Float), _
                                                New SqlParameter("@eisramingsdatum", SqlDbType.NVarChar)}

                params(0).Value = glbPolicyNumber
                params(1).Value = glbEisno
                params(2).Value = Me.txtClaimAmount.Text
                params(3).Value = CStr(Format(Now, "dd/MM/yyyy"))

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "eisdat.InsertEisramings", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Private Sub txtClaimSubStatus_TextChanged(sender As System.Object, e As System.EventArgs)
        blnInfoChanges = True
    End Sub

    Private Sub txtClaimStatus_TextChanged(sender As System.Object, e As System.EventArgs)
        blnInfoChanges = True
    End Sub

    Private Sub dtpClaimCompletionDate_GotFocus(sender As Object, e As System.EventArgs) Handles dtpClaimCompletionDate.GotFocus
        strVoor = CStr(Me.dtpClaimCompletionDate.Value)
    End Sub

    Private Sub dtpClaimCompletionDate_Leave(sender As Object, e As System.EventArgs) Handles dtpClaimCompletionDate.Leave
        If blnNewClaim = False And blnClaimLoading = False Then
            SkryfWysiging(CStr(Me.dtpClaimCompletionDate.Value), glbEisno, 67)
        End If
    End Sub

    Private Sub dtpClaimCompletionDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpClaimCompletionDate.ValueChanged
        blnInfoChanges = True
    End Sub

    Private Sub dtpClaimReportDate_GotFocus(sender As Object, e As System.EventArgs) Handles dtpClaimReportDate.GotFocus
        strVoor = CStr(Me.dtpClaimReportDate.Value)
    End Sub

    Private Sub dtpClaimReportDate_Leave(sender As Object, e As System.EventArgs) Handles dtpClaimReportDate.Leave
        If blnNewClaim = False And blnClaimLoading = False Then
            SkryfWysiging(CStr(Me.dtpClaimReportDate.Value), glbEisno, 67)
        End If
    End Sub

    Private Sub dtpClaimReportDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpClaimReportDate.ValueChanged
        blnInfoChanges = True
    End Sub

    Private Sub dtpClaimDate_GotFocus(sender As Object, e As System.EventArgs) Handles dtpClaimDate.GotFocus
        strVoor = CStr(Me.dtpClaimDate.Value)
    End Sub

    Private Sub dtpClaimDate_Leave(sender As Object, e As System.EventArgs) Handles dtpClaimDate.Leave
        If Me.dtpClaimDate.Checked <> False Then
            If blnNewClaim = True Then
                clsRun.GetVerifieerDekking(glbPolicyNumber, Me.dtpClaimDate.Value, Month(Me.dtpClaimDate.Value))
                If blnIsBetaalJN = False Then
                    If strMsg2 = "You are in the grace period of 15 days." Then
                        MsgBox("The premium for this month hasn't been paid in full.  " & strMsg2, vbInformation)
                    Else
                        If MsgBox("The premium for this month hasn't been paid in full.  The claim cannot be added.  Do you have authorization to add it?", vbYesNo) = vbYes Then
                            frmPassword.lblMessage.Text = "Authorise to add a claim"
                            frmPassword.ShowDialog()

                            clsRun.GetSekuritDetail(pwdEntered)

                            If strSekuritTitel = "Programmeerder" Then
                                Exit Sub
                            Else
                                MsgBox("The password is incorrect or this user doesn't have authorization to add this claim.", vbInformation)
                                blnClaimsValidation = False
                                Me.dtpClaimDate.Checked = False
                                Exit Sub
                            End If
                        Else
                            blnClaimsValidation = False
                            blnNewClaim = False
                            CleanFields()
                            FieldsEnabled(False)
                            blnInfoChanges = False
                            Exit Sub
                        End If
                    End If
                End If
            End If
        End If

        If blnNewClaim = False And blnClaimLoading = False Then
            SkryfWysiging(CStr(Me.dtpClaimDate.Value), glbEisno, 67)
        End If
    End Sub

    Private Sub dtpClaimDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpClaimDate.ValueChanged
        blnInfoChanges = True
    End Sub

    Private Sub btnPaymentsAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnPaymentsAdd.Click
        intpkPayments = 0
        frmClaimsPayments.Show()
    End Sub

    Private Sub btnPaymentsEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnPaymentsEdit.Click
        If intRowPayments <> -1 Then
            intpkPayments = Me.dgvPayments.Item(6, intRowPayments).Value

            frmClaimsPayments.Show()
        End If

    End Sub

    Private Sub btnPaymentsDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnPaymentsDelete.Click
        If intRowPayments <> -1 Then
            Try
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim params() As SqlParameter = {New SqlParameter("@Eisno", SqlDbType.NVarChar), _
                                                    New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                                    New SqlParameter("@tjekbesonderhede", SqlDbType.NVarChar), _
                                                    New SqlParameter("@premie", SqlDbType.Money), _
                                                    New SqlParameter("@status", SqlDbType.NVarChar), _
                                                    New SqlParameter("@kwitansie", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Btwuitbedrag", SqlDbType.Money), _
                                                    New SqlParameter("@Btwbedrag", SqlDbType.Money), _
                                                    New SqlParameter("@BtwJN", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Betaalwyse", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Tjekno", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Trans_dat", SqlDbType.DateTime), _
                                                    New SqlParameter("@Tipe", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Vord_dat", SqlDbType.Date), _
                                                    New SqlParameter("@pkPayments", SqlDbType.Int), _
                                                    New SqlParameter("@Gekans", SqlDbType.Bit), _
                                                    New SqlParameter("@Afsluit_dat", SqlDbType.Date), _
                                                    New SqlParameter("@kans_dat", SqlDbType.Date), _
                                                    New SqlParameter("@vt_trans_dat", SqlDbType.Date), _
                                                    New SqlParameter("@mk_Trans_dat", SqlDbType.Date), _
                                                    New SqlParameter("@jk_Trans_dat", SqlDbType.Date), _
                                                    New SqlParameter("@eb_Trans_dat", SqlDbType.Date), _
                                                    New SqlParameter("@ms_Trans_dat", SqlDbType.Date), _
                                                    New SqlParameter("@ei_Trans_dat", SqlDbType.Date), _
                                                    New SqlParameter("@md_Trans_dat", SqlDbType.Date), _
                                                    New SqlParameter("@gg_Trans_dat", SqlDbType.Date), _
                                                    New SqlParameter("@Tjekdatum", SqlDbType.DateTime), _
                                                    New SqlParameter("@Jaar", SqlDbType.Int), _
                                                    New SqlParameter("@Maand", SqlDbType.Int), _
                                                    New SqlParameter("@Bankindeks", SqlDbType.Int), _
                                                    New SqlParameter("@NedrekTipe", SqlDbType.Int), _
                                                    New SqlParameter("@Vord_premie", SqlDbType.Money), _
                                                    New SqlParameter("@Nedlopie", SqlDbType.Bit), _
                                                    New SqlParameter("@Verw1", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Verw2", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Verw3", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Verw4", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Verw5", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Kontant_tipe", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Nuwe_Tjekno", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Tjekno_uit", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Tjekno_in", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Neddatum", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Nedbankkode", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Nedbankrek", SqlDbType.NVarChar), _
                                                    New SqlParameter("@afdat2", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Waarvoor", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Stuurdmv", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Faks", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Email", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Banknaam", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Taknaam", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Batchid", SqlDbType.NVarChar), _
                                                    New SqlParameter("@BatchTyd", SqlDbType.NVarChar), _
                                                    New SqlParameter("@VatNumber", SqlDbType.NVarChar), _
                                                    New SqlParameter("@ServiceProviderName", SqlDbType.NVarChar), _
                                                    New SqlParameter("@PayeeIdentification", SqlDbType.NVarChar), _
                                                    New SqlParameter("@CategoryofService", SqlDbType.NVarChar), _
                                                    New SqlParameter("@SubCategoryofService", SqlDbType.NVarChar), _
                                                    New SqlParameter("@SpecialityofServiceProvider", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Area", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Faktuurnr", SqlDbType.NVarChar), _
                                                    New SqlParameter("@TipePayment", SqlDbType.NVarChar)}

                    params(0).Value = glbEisno
                    params(1).Value = glbPolicyNumber
                    params(2).Value = ""
                    params(3).Value = DBNull.Value
                    params(4).Value = ""
                    params(5).Value = ""
                    params(6).Value = DBNull.Value
                    params(7).Value = DBNull.Value
                    params(8).Value = ""
                    params(9).Value = ""
                    params(10).Value = ""
                    params(11).Value = Now
                    params(12).Value = ""
                    params(13).Value = Today
                    params(14).Value = intpkPayments
                    params(15).Value = True
                    params(16).Value = DBNull.Value
                    params(17).Value = DBNull.Value
                    params(18).Value = DBNull.Value
                    params(19).Value = DBNull.Value
                    params(20).Value = DBNull.Value
                    params(21).Value = DBNull.Value
                    params(22).Value = DBNull.Value
                    params(23).Value = DBNull.Value
                    params(24).Value = DBNull.Value
                    params(25).Value = DBNull.Value
                    params(26).Value = DBNull.Value
                    params(27).Value = DBNull.Value
                    params(28).Value = DBNull.Value
                    params(29).Value = 0
                    params(30).Value = 0
                    params(31).Value = DBNull.Value
                    params(32).Value = False
                    params(33).Value = ""
                    params(34).Value = ""
                    params(35).Value = ""
                    params(36).Value = ""
                    params(37).Value = ""
                    params(38).Value = ""
                    params(39).Value = ""
                    params(40).Value = ""
                    params(41).Value = ""
                    params(42).Value = DBNull.Value
                    params(43).Value = ""
                    params(44).Value = ""
                    params(45).Value = DBNull.Value
                    params(46).Value = ""
                    params(47).Value = ""
                    params(48).Value = ""
                    params(49).Value = ""
                    params(50).Value = ""
                    params(51).Value = ""
                    params(52).Value = ""
                    params(53).Value = ""
                    params(54).Value = ""
                    params(55).Value = ""
                    params(56).Value = ""
                    params(57).Value = ""
                    params(58).Value = ""
                    params(59).Value = ""
                    params(60).Value = ""           'area
                    params(61).Value = ""
                    params(62).Value = ""

                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "eisdat.UpdatePayments", params)
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

            GetAllPayments()
        End If
    End Sub

    Private Sub dgvPayments_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPayments.CellClick
        intRowPayments = e.RowIndex
        If intRowPayments >= 0 Then
            intpkPayments = Me.dgvPayments.Item(6, intRowPayments).Value
            blnNedLopie = Me.dgvPayments.Item(7, intRowPayments).Value

            Me.btnPaymentsJournal.Enabled = True

            If blnNedLopie = True Then
                Me.btnPaymentsDelete.Enabled = False
                Exit Sub
            End If

            If Me.dgvPayments.Item(4, intRowPayments).Value = "O" Then
                Me.btnPaymentsDelete.Enabled = False
            ElseIf Me.dgvPayments.Item(4, intRowPayments).Value = "P" Then
                Me.btnPaymentsDelete.Enabled = True
            End If
        End If
    End Sub

    Private Sub dgvPayments_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPayments.CellDoubleClick
        If intRowPayments >= 0 Then
            intpkPayments = Me.dgvPayments.Item(6, intRowPayments).Value

            frmClaimsPayments.Show()
        End If

    End Sub

    Private Sub dgvPayments_DataBindingComplete(sender As Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvPayments.DataBindingComplete
        dblPayments = 0
        For i = 0 To dgvPayments.RowCount - 1
            If dgvPayments.Rows(i).Cells("GekansIcon").Value = "1" Then
                dgvPayments.Rows(i).Cells("GekansIcon").Value = "O"
                dgvPayments.Rows(i).Cells("GekansIcon").Style.ForeColor = Color.Red
            ElseIf dgvPayments.Rows(i).Cells("GekansIcon").Value = "0" Then
                dgvPayments.Rows(i).Cells("GekansIcon").Value = "P"
                dgvPayments.Rows(i).Cells("GekansIcon").Style.ForeColor = Color.Green
                dblPayments = dblPayments + dgvPayments.Rows(i).Cells("vord_premie").Value
            End If
        Next
    End Sub
    Public Sub GetAllPayments()
        dgvPayments.AutoGenerateColumns = False
        dgvPayments.DataSource = Nothing
        dgvPayments.Refresh()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim paramsClaims() As SqlParameter = {New SqlParameter("@Eisno", SqlDbType.NVarChar)}
                paramsClaims(0).Value = glbEisno

                Dim readerClaims As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchPaymentsEisno", paramsClaims)

                Dim ClaimsPayments As List(Of ClaimsPaymentEntity) = New List(Of ClaimsPaymentEntity)

                Do While readerClaims.Read
                    Dim item As ClaimsPaymentEntity = New ClaimsPaymentEntity()

                    If readerClaims("polisno") IsNot DBNull.Value Then
                        item.polisno = readerClaims("polisno")
                    Else
                        item.polisno = ""
                    End If
                    If readerClaims("eisno") IsNot DBNull.Value Then
                        item.eisno = readerClaims("eisno")
                    Else
                        item.eisno = ""
                    End If
                    If readerClaims("Vord_dat") IsNot DBNull.Value Then
                        item.Vord_dat = readerClaims("Vord_dat")
                    Else
                        item.Vord_dat = Nothing
                    End If
                    If readerClaims("Tjekbesonderhede") IsNot DBNull.Value Then
                        item.Tjekbesonderhede = readerClaims("Tjekbesonderhede")
                    Else
                        item.Tjekbesonderhede = ""
                    End If
                    If readerClaims("Tjekno_uit") IsNot DBNull.Value Then
                        item.Tjekno_uit = readerClaims("Tjekno_uit")
                    Else
                        item.Tjekno_uit = ""
                    End If
                    If readerClaims("Tipe") IsNot DBNull.Value Then
                        item.Tipe = readerClaims("Tipe")
                    Else
                        item.Tipe = ""
                    End If
                    If readerClaims("Vord_premie") IsNot DBNull.Value Then
                        item.Vord_premie = readerClaims("Vord_premie")
                    Else
                        item.Vord_premie = 0
                    End If
                    If readerClaims("pkPayments") IsNot DBNull.Value Then
                        item.pkPayments = readerClaims("pkPayments")
                    Else
                        item.pkPayments = 0
                    End If
                    If readerClaims("Gekans") IsNot DBNull.Value Then
                        item.Gekans = readerClaims("Gekans")
                    End If
                    If item.Gekans = True Then
                        item.GekansIcon = 1
                    Else
                        item.GekansIcon = 0
                    End If
                    If readerClaims("TipePayment") IsNot DBNull.Value Then
                        item.TipePayment = readerClaims("TipePayment")
                    Else
                        item.TipePayment = ""
                    End If
                    If readerClaims("Nedlopie") IsNot DBNull.Value Then
                        item.Nedlopie = readerClaims("Nedlopie")
                    End If

                    intpkPayments = item.pkPayments

                    ClaimsPayments.Add(item)
                Loop

                dgvPayments.DataSource = ClaimsPayments

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    readerClaims.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        If dgvPayments.RowCount = 0 Then
            Me.btnPaymentsEdit.Enabled = False
        Else
            Me.btnPaymentsEdit.Enabled = True
        End If
        Me.lblTotalPayments.Text = "Total Payments:  R" & dblPayments
    End Sub
    Public Sub GetAllJournals()
        dgvClaimJournals.AutoGenerateColumns = False
        dgvClaimJournals.DataSource = Nothing
        dgvClaimJournals.Refresh()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim paramsClaims() As SqlParameter = {New SqlParameter("@Eisno", SqlDbType.NVarChar)}
                paramsClaims(0).Value = glbEisno

                Dim readerClaims As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchJoernaleEisno", paramsClaims)

                Dim ClaimsJoernale As List(Of ClaimsJoernaleEntity) = New List(Of ClaimsJoernaleEntity)

                Do While readerClaims.Read
                    Dim item As ClaimsJoernaleEntity = New ClaimsJoernaleEntity()

                    If readerClaims("polisno") IsNot DBNull.Value Then
                        item.polisno = readerClaims("polisno")
                    Else
                        item.polisno = ""
                    End If
                    If readerClaims("eisno") IsNot DBNull.Value Then
                        item.eisno = readerClaims("eisno")
                    Else
                        item.eisno = ""
                    End If
                    If readerClaims("Vord_dat") IsNot DBNull.Value Then
                        item.JVord_dat = readerClaims("Vord_dat")
                    Else
                        item.JVord_dat = Nothing
                    End If
                    If readerClaims("Tjekbesonderhede") IsNot DBNull.Value Then
                        item.JTjekbesonderhede = readerClaims("Tjekbesonderhede")
                    Else
                        item.JTjekbesonderhede = ""
                    End If
                    If readerClaims("Tipe") IsNot DBNull.Value Then
                        item.JTipe = readerClaims("Tipe")
                    Else
                        item.JTipe = ""
                    End If
                    If readerClaims("Vord_premie") IsNot DBNull.Value Then
                        item.JVord_Premie = readerClaims("Vord_premie")
                    Else
                        item.JVord_Premie = 0
                    End If
                    If readerClaims("pkJoernale") IsNot DBNull.Value Then
                        item.pkJoernale = readerClaims("pkJoernale")
                    Else
                        item.pkJoernale = 0
                    End If
                    If readerClaims("Gekans") IsNot DBNull.Value Then
                        item.Gekans = readerClaims("Gekans")
                    End If
                    If item.Gekans = True Then
                        item.CancelledIcon = 1
                    Else
                        item.CancelledIcon = 0
                    End If
                    If readerClaims("Kontant_Tipe") IsNot DBNull.Value Then
                        item.Kontant_Tipe = readerClaims("Kontant_Tipe")
                    Else
                        item.Kontant_Tipe = ""
                    End If
                    If readerClaims("TjekofElektronies") IsNot DBNull.Value Then
                        item.TjekofElektronies = readerClaims("TjekofElektronies")
                    Else
                        item.TjekofElektronies = ""
                    End If
                    If readerClaims("KruisVerwysing") IsNot DBNull.Value Then
                        item.KruisVerwysing = readerClaims("KruisVerwysing")
                    Else
                        item.KruisVerwysing = ""
                    End If

                    intpkJoernale = item.pkJoernale

                    ClaimsJoernale.Add(item)
                Loop

                dgvClaimJournals.DataSource = ClaimsJoernale

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    readerClaims.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        If dgvClaimJournals.RowCount = 0 Then
            Me.btnJournalEdit.Enabled = False
        Else
            Me.btnJournalEdit.Enabled = True
        End If
        Me.lblTotalJournal.Text = "Total Journals:  R" & dblJournals
    End Sub

    Private Sub cmdCatastrophe_Click(sender As System.Object, e As System.EventArgs) Handles cmdCatastrophe.Click
        frmClaimsCatastrophe.Show()
    End Sub


    Private Sub cmbCatastrophe_GotFocus(sender As Object, e As System.EventArgs) Handles cmbCatastrophe.GotFocus
        'catastrophe
        Using conn As SqlConnection = SqlHelper.GetConnection

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchKatastrofe")
            cmbCatastrophe.Items.Clear()
            Do While reader.Read
                cmbCatastrophe.Items.Add(reader("naam"))
            Loop

        End Using

        cmbCatastrophe.Text = ""
    End Sub

    Private Sub dgvClaimIncome_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClaimIncome.CellClick
        intRowIncome = e.RowIndex
        If intRowIncome >= 0 Then
            intpkIncome = Me.dgvClaimIncome.Item(6, intRowIncome).Value

            If Me.dgvClaimIncome.Item(4, intRowIncome).Value = "O" Then
                Me.btnIncomeDelete.Enabled = False
            ElseIf Me.dgvClaimIncome.Item(4, intRowIncome).Value = "P" Then
                Me.btnIncomeDelete.Enabled = True
            End If
            Me.btnIncomeJournal.Enabled = True
        End If
    End Sub

    Private Sub dgvClaimIncome_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClaimIncome.CellDoubleClick
        If intRowIncome >= 0 Then
            intpkIncome = Me.dgvClaimIncome.Item(6, intRowIncome).Value

            frmClaimsJoernale.Show()
        End If
    End Sub

    Private Sub dgvClaimIncome_DataBindingComplete(sender As Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvClaimIncome.DataBindingComplete
        dblIncome = 0

        For i = 0 To dgvClaimIncome.RowCount - 1
            If dgvClaimIncome.Rows(i).Cells("CancelIcon").Value = "1" Then
                dgvClaimIncome.Rows(i).Cells("CancelIcon").Value = "O"
                dgvClaimIncome.Rows(i).Cells("CancelIcon").Style.ForeColor = Color.Red
            ElseIf dgvClaimIncome.Rows(i).Cells("CancelIcon").Value = "0" Then
                dgvClaimIncome.Rows(i).Cells("CancelIcon").Value = "P"
                dgvClaimIncome.Rows(i).Cells("CancelIcon").Style.ForeColor = Color.Green
                dblIncome = dblIncome + dgvClaimIncome.Rows(i).Cells("Amount").Value
            End If
        Next
    End Sub

    Private Sub dgvClaimIncome_CellContentClick_1(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClaimIncome.CellContentClick

    End Sub

    Private Sub btnIncomeEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnIncomeEdit.Click
        If intRowIncome <> -1 Then
            intpkIncome = Me.dgvClaimIncome.Item(6, intRowIncome).Value

            frmClaimsJoernale.Show()
        End If
    End Sub

    Private Sub btnIncomeDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnIncomeDelete.Click
        If intRowIncome <> -1 Then
            Try
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim params() As SqlParameter = {New SqlParameter("@Eisno", SqlDbType.NVarChar), _
                                                    New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                                    New SqlParameter("@besonderhede", SqlDbType.NVarChar), _
                                                    New SqlParameter("@bedrag", SqlDbType.Money), _
                                                    New SqlParameter("@status", SqlDbType.NVarChar), _
                                                    New SqlParameter("@kwitansienr", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Btwuitbedrag", SqlDbType.Money), _
                                                    New SqlParameter("@Btwbedrag", SqlDbType.Money), _
                                                    New SqlParameter("@BtwJN", SqlDbType.NVarChar), _
                                                    New SqlParameter("@TjekofKontant", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Tjekno", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Trans_dat", SqlDbType.Date), _
                                                    New SqlParameter("@VerhalingEisno", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Tipe", SqlDbType.NVarChar), _
                                                    New SqlParameter("@DatumInkomste", SqlDbType.Date), _
                                                    New SqlParameter("@pkIncome", SqlDbType.Int), _
                                                    New SqlParameter("@Cancel", SqlDbType.Bit)}

                    params(0).Value = glbEisno
                    params(1).Value = glbPolicyNumber
                    params(2).Value = ""
                    params(3).Value = 0
                    params(4).Value = ""
                    params(5).Value = ""
                    params(6).Value = 0
                    params(7).Value = 0
                    params(8).Value = ""
                    params(9).Value = ""
                    params(10).Value = ""
                    params(11).Value = Today
                    params(12).Value = ""
                    params(13).Value = ""
                    params(14).Value = Today
                    params(15).Value = intpkIncome
                    params(16).Value = True

                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "eisdat.UpdateIncome", params)
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

            GetAllIncome()
        End If
    End Sub

    Private Sub btnIncomeAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnIncomeAdd.Click
        intpkIncome = 0
        frmClaimsJoernale.Show()
    End Sub

    Private Sub dgvClaims_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClaims.CellContentClick

    End Sub

    Private Sub dgvClaimJournals_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClaimJournals.CellClick
        intRowJournal = e.RowIndex
        If intRowJournal >= 0 Then
            intpkJoernale = Me.dgvClaimJournals.Item(6, intRowJournal).Value

            If Me.dgvClaimJournals.Item(4, intRowJournal).Value = "O" Then
                Me.btnJournalDelete.Enabled = False
            ElseIf Me.dgvClaimJournals.Item(4, intRowJournal).Value = "P" Then
                Me.btnJournalDelete.Enabled = True
            End If
        End If
    End Sub

    Private Sub dgvClaimJournals_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClaimJournals.CellContentClick

    End Sub

    Private Sub dgvClaimJournals_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClaimJournals.CellDoubleClick
        If intRowJournal >= 0 Then
            intpkJoernale = Me.dgvClaimJournals.Item(6, intRowJournal).Value
            intpkIncome = 0
            intpkPayments = 0
            frmClaimsJournal.Show()
        End If
    End Sub

    Private Sub dgvClaimJournals_DataBindingComplete(sender As Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvClaimJournals.DataBindingComplete
        dblJournals = 0

        For i = 0 To dgvClaimJournals.RowCount - 1
            If dgvClaimJournals.Rows(i).Cells("CancelledIcon").Value = "1" Then
                dgvClaimJournals.Rows(i).Cells("CancelledIcon").Value = "O"
                dgvClaimJournals.Rows(i).Cells("CancelledIcon").Style.ForeColor = Color.Red
            ElseIf dgvClaimJournals.Rows(i).Cells("CancelledIcon").Value = "0" Then
                dgvClaimJournals.Rows(i).Cells("CancelledIcon").Value = "P"
                dgvClaimJournals.Rows(i).Cells("CancelledIcon").Style.ForeColor = Color.Green
                dblJournals = dblJournals + dgvClaimJournals.Rows(i).Cells("jvord_premie").Value
            End If
        Next
    End Sub

    Private Sub btnPaymentsJournal_Click(sender As System.Object, e As System.EventArgs) Handles btnPaymentsJournal.Click
        If intRowPayments <> -1 Then
            intpkPayments = Me.dgvPayments.Item(6, intRowPayments).Value
            intpkIncome = 0
            intpkJoernale = 0
            frmClaimsJournal.Show()
        End If
    End Sub

    Private Sub btnIncomeJournal_Click(sender As System.Object, e As System.EventArgs) Handles btnIncomeJournal.Click
        If intRowIncome <> -1 Then
            intpkIncome = Me.dgvClaimIncome.Item(6, intRowIncome).Value
            intpkPayments = 0
            intpkJoernale = 0
            frmClaimsJournal.Show()
        End If

    End Sub


    Private Sub btnJournalEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnJournalEdit.Click
        If intRowJournal <> -1 Then
            intpkJoernale = Me.dgvClaimJournals.Item(6, intRowJournal).Value
            intpkIncome = 0
            intpkPayments = 0
            frmClaimsJournal.Show()
        End If
    End Sub

    Private Sub dgvPayments_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPayments.CellContentClick

    End Sub

    Private Sub btnJournalDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnJournalDelete.Click
        If intRowJournal <> -1 Then
            Try
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim params() As SqlParameter = {New SqlParameter("@Eisno", SqlDbType.NVarChar), _
                                                    New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Tjekbesonderhede", SqlDbType.NVarChar), _
                                                    New SqlParameter("@vord_premie", SqlDbType.Money), _
                                                    New SqlParameter("@Jaar", SqlDbType.Int), _
                                                    New SqlParameter("@Maand", SqlDbType.Int), _
                                                    New SqlParameter("@Faktuurnr", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Btwuitbedrag", SqlDbType.Money), _
                                                    New SqlParameter("@Btwbedrag", SqlDbType.Money), _
                                                    New SqlParameter("@BtwJN", SqlDbType.NVarChar), _
                                                    New SqlParameter("@TjekofElektronies", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Kruisverwysing", SqlDbType.NVarChar), _
                                                    New SqlParameter("@VATNumber", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Trans_dat", SqlDbType.Date), _
                                                    New SqlParameter("@Waarvoor", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Tipe", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Kontant_tipe", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Tjekdatum", SqlDbType.Date), _
                                                    New SqlParameter("@Vord_dat", SqlDbType.Date), _
                                                    New SqlParameter("@pkJoernale", SqlDbType.Int), _
                                                    New SqlParameter("@ServiceProviderName", SqlDbType.NVarChar), _
                                                    New SqlParameter("@PayeeIdentification", SqlDbType.NVarChar), _
                                                    New SqlParameter("@CategoryofService", SqlDbType.NVarChar), _
                                                    New SqlParameter("@SubCategoryofService", SqlDbType.NVarChar), _
                                                    New SqlParameter("@SpecialityofServiceProvider", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Gekans", SqlDbType.Bit)}

                    params(0).Value = glbEisno
                    params(1).Value = glbPolicyNumber
                    params(2).Value = ""
                    params(3).Value = 0
                    params(4).Value = 0
                    params(5).Value = 0
                    params(6).Value = ""
                    params(7).Value = 0
                    params(8).Value = 0
                    params(9).Value = ""
                    params(10).Value = ""
                    params(11).Value = ""
                    params(12).Value = ""
                    params(13).Value = Today
                    params(14).Value = ""
                    params(15).Value = ""
                    params(16).Value = ""
                    params(17).Value = DBNull.Value
                    params(18).Value = DBNull.Value
                    params(19).Value = intpkJoernale
                    params(20).Value = ""
                    params(21).Value = ""
                    params(22).Value = ""
                    params(23).Value = ""
                    params(24).Value = ""
                    params(25).Value = True

                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "eisdat.UpdateJoernale", params)
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

            GetAllJournals()
        End If
    End Sub

    Private Sub Label18_Click(sender As System.Object, e As System.EventArgs) Handles Label18.Click

    End Sub

    Private Sub PaymentAdvisoryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PaymentAdvisoryToolStripMenuItem.Click
        frmClaimsBetalingsAdvies.Show()
    End Sub

    Private Sub ElectronicPaymentToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ElectronicPaymentToolStripMenuItem.Click
        frmClaimsElectronicPayments.Show()
    End Sub

    Private Sub cmbClaimStatus_GotFocus(sender As Object, e As System.EventArgs) Handles cmbClaimStatus.GotFocus
        strVoor = Me.cmbClaimStatus.Text
    End Sub

    Private Sub cmbClaimStatus_Leave(sender As Object, e As System.EventArgs) Handles cmbClaimStatus.Leave
        If blnNewClaim = False And blnClaimLoading = False Then
            SkryfWysiging(Me.cmbClaimStatus.Text, glbEisno, 67)
        End If
    End Sub

    Private Sub cmbClaimStatus_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbClaimStatus.SelectedIndexChanged
        blnInfoChanges = True
    End Sub

    Private Sub cmbClaimSubstatus_GotFocus(sender As Object, e As System.EventArgs) Handles cmbClaimSubstatus.GotFocus
        strVoor = Me.cmbClaimSubstatus.Text
    End Sub

    Private Sub cmbClaimSubstatus_Leave(sender As Object, e As System.EventArgs) Handles cmbClaimSubstatus.Leave
        If blnNewClaim = False And blnClaimLoading = False Then
            SkryfWysiging(Me.cmbClaimSubstatus.Text, glbEisno, 67)
        End If
    End Sub

    Private Sub cmbClaimSubstatus_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbClaimSubstatus.SelectedIndexChanged
        blnInfoChanges = True
    End Sub

    Private Sub AssessorsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AssessorsToolStripMenuItem.Click
        frmClaimsAssessors.Show()
    End Sub
    Public Sub populateAssessorsGrid()
        dgvClaimAssessors.AutoGenerateColumns = False
        dgvClaimAssessors.DataSource = Nothing
        dgvClaimAssessors.Refresh()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params() As SqlParameter = {New SqlParameter("@Eisno", SqlDbType.NVarChar)}
                params(0).Value = glbEisno

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchAssessorsperClaim", params)

                Dim AssessorList As List(Of ClaimsAssessorEntity) = New List(Of ClaimsAssessorEntity)

                Do While reader.Read
                    Dim item As ClaimsAssessorEntity = New ClaimsAssessorEntity()

                    If reader("AssessorName") IsNot DBNull.Value Then
                        item.AssessorName = reader("AssessorName")
                    Else
                        item.AssessorName = ""
                    End If
                    If reader("pkAssessorsperclaim") IsNot DBNull.Value Then
                        item.pkAssessorsPerClaim = reader("pkAssessorsperclaim")
                    Else
                        item.pkAssessorsPerClaim = 0
                    End If

                    AssessorList.Add(item)
                Loop

                dgvClaimAssessors.DataSource = AssessorList

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    reader.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub dgvClaimAssessors_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClaimAssessors.CellClick
        intRowAssessor = e.RowIndex
        intPKAssessorsPerClaim = Me.dgvClaimAssessors.Item(0, intRowAssessor).Value
        Me.btnAssessorDelete.Enabled = True
    End Sub

    Private Sub btnAssessorAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAssessorAdd.Click
        If Me.txtClaimnumber.Text <> "" Then
            blnfkAssessor = True
            blnAssessorClaim = True
            frmClaimsAssessors.Show()
        Else
            MsgBox("Please enter the claimnumber before you can add an assessor.", vbInformation)
            tabClaims.SelectedTab = Me.tabClaims1
            Me.txtClaimnumber.Focus()
        End If

    End Sub

    Private Sub btnAssessorDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnAssessorDelete.Click

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@pkAssessorsPerClaim", SqlDbType.Int), _
                                                New SqlParameter("@Eisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@fkAssessor", SqlDbType.NVarChar), _
                                                New SqlParameter("@Cancel", SqlDbType.Bit)}

                params(0).Value = intPKAssessorsPerClaim
                params(1).Value = glbEisno
                params(2).Value = intfkAssessor
                params(3).Value = True

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "eisdat.UpdateAssessorsPerClaim", params)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
        populateAssessorsGrid()

    End Sub

    Private Sub dgvClaimAssessors_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClaimAssessors.CellContentClick

    End Sub

    Private Sub btnPostalcodes_Click(sender As System.Object, e As System.EventArgs) Handles btnPostalcodes.Click
        PoskodesSoek.txtFormToPopulate.Text = Me.Name
        PoskodesSoek.ShowDialog()
    End Sub
    Private Sub UniqueClaimNr()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim paramsClaims() As SqlParameter = {New SqlParameter("@Eisno", SqlDbType.NVarChar)}
                paramsClaims(0).Value = Me.txtClaimnumber.Text    'Me.dgvClaims.Item(0, intRow).Value

                Dim readerClaims As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchEisdatEisno", paramsClaims)

                If readerClaims.Read Then
                    blnUnique = False
                Else
                    blnUnique = True
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    readerClaims.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub



    Private Sub btnApply_Click(sender As System.Object, e As System.EventArgs) Handles btnApply.Click
        'validation
        ClaimsValidation()

        'save
        If blnClaimsValidation = True Then
            GetInsurerBrokerInfo()

            SaveClaimsDetails()

            populateClaimsGrid()

            CleanFields()

            FieldsEnabled(False)
            blnInfoChanges = False
        End If
    End Sub

    Private Sub btnOKClaims_Click(sender As System.Object, e As System.EventArgs) Handles btnOKClaims.Click
        'validation
        ClaimsValidation()

        'save
        If blnClaimsValidation = True Then
            GetInsurerBrokerInfo()

            SaveClaimsDetails()

            populateClaimsGrid()

            FieldsEnabled(False)

            CleanFields()

            Me.Dispose()
        End If
    End Sub

    Private Sub btnCancelClaim_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelClaim.Click
        If blnInfoChanges = True Then
            If MsgBox("Are you sure you want to cancel and loose all your changes?", vbYesNo) = MsgBoxResult.Yes Then
                Me.Dispose()
            Else
                Exit Sub
            End If
        Else
            Me.Dispose()
        End If
    End Sub
End Class