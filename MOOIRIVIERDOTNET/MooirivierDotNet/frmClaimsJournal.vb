Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports DAL
Public Class frmClaimsJournal
    Dim blnJournalValidation As Boolean = False
    Dim blnInfoChanges As Boolean = False
    Dim strVatNumber As String = ""
    Dim strServiceProviderName As String = ""
    Dim strPayeeID As String = ""
    Dim strCategoryofService As String = ""
    Dim strSubCategoryofService As String = ""
    Dim strSpecialityofServ As String = ""

    Private Sub frmClaimsJournal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Claim Journal - " & Persoonl.VOORL & " " & Persoonl.VERSEKERDE & " - " & glbPolicyNumber & " - " & glbEisno

        If intpkIncome <> 0 Then
            GetIncome()
        ElseIf intpkPayments <> 0 Then
            GetPayments()
        Else
            GetJournal()
        End If

        FieldsEnabled(False)
        blnInfoChanges = False
    End Sub
    Private Sub FieldsEnabled(ByVal blnEnabled As Boolean)

        Me.txtJournalAmount.Enabled = blnEnabled
        Me.txtJournalAmountWithoutVat.Enabled = blnEnabled
        Me.txtJournalDetails.Enabled = blnEnabled
        Me.txtJournalInvRefNr.Enabled = blnEnabled
        Me.txtJournalVatAmount.Enabled = blnEnabled
        Me.cmbCategory.Enabled = blnEnabled
        Me.cmbType.Enabled = blnEnabled
        Me.chkJournalVAT.Enabled = blnEnabled
        Me.dtpJournalDate.Enabled = blnEnabled
        Me.txtCrossRefNr.Enabled = blnEnabled
    End Sub

    Private Sub GetIncome()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim paramsClaims() As SqlParameter = {New SqlParameter("@pkIncome", SqlDbType.Int)}
                paramsClaims(0).Value = intpkIncome

                Dim readerClaims As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchIncomepkIncome", paramsClaims)

                If readerClaims.Read Then
                    Dim item As ClaimsIncomeEntity = New ClaimsIncomeEntity()

                    If readerClaims("pkIncome") IsNot DBNull.Value Then
                        item.pkIncome = readerClaims("pkIncome")
                    Else
                        item.pkIncome = 0
                    End If
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
                    If readerClaims("Btwjn") IsNot DBNull.Value Then
                        item.Btwjn = readerClaims("Btwjn")
                    Else
                        item.Btwjn = ""
                    End If
                    If readerClaims("kwitansienr") IsNot DBNull.Value Then
                        item.kwitansienr = readerClaims("kwitansienr")
                    Else
                        item.kwitansienr = ""
                    End If
                    If readerClaims("status") IsNot DBNull.Value Then
                        item.status = readerClaims("status")
                    Else
                        item.status = ""
                    End If
                    If readerClaims("Tipe") IsNot DBNull.Value Then
                        item.Tipe = readerClaims("Tipe")
                    Else
                        item.Tipe = ""
                    End If
                    If readerClaims("Trans_dat") IsNot DBNull.Value Then
                        item.Trans_dat = readerClaims("Trans_dat")
                    Else
                        item.Trans_dat = Nothing
                    End If
                    If readerClaims("Tjekno") IsNot DBNull.Value Then
                        item.Tjekno = readerClaims("Tjekno")
                    Else
                        item.Tjekno = ""
                    End If
                    If readerClaims("Tjekofkontant") IsNot DBNull.Value Then
                        item.Tjekofkontant = readerClaims("Tjekofkontant")
                    Else
                        item.Tjekofkontant = ""
                    End If
                    If readerClaims("VerhalingEisno") IsNot DBNull.Value Then
                        item.VerhalingEisno = readerClaims("VerhalingEisno")
                    Else
                        item.VerhalingEisno = ""
                    End If
                    If readerClaims("bedrag") IsNot DBNull.Value Then
                        item.bedrag = readerClaims("bedrag")
                    Else
                        item.bedrag = 0
                    End If
                    If readerClaims("Btwbedrag") IsNot DBNull.Value Then
                        item.Btwbedrag = readerClaims("Btwbedrag")
                    Else
                        item.Btwbedrag = 0
                    End If
                    If readerClaims("Btwuitbedrag") IsNot DBNull.Value Then
                        item.Btwuitbedrag = readerClaims("Btwuitbedrag")
                    Else
                        item.Btwuitbedrag = 0
                    End If
                    If readerClaims("Cancel") IsNot DBNull.Value Then
                        item.Cancel = readerClaims("Cancel")
                    End If

                    Me.cmbType.Text = item.Tipe
                    Me.dtpJournalDate.Value = item.DatumInkomste
                    Me.txtJournalAmount.Text = item.bedrag
                    Me.txtJournalAmountWithoutVat.Text = item.Btwuitbedrag
                    Me.txtJournalDetails.Text = item.besonderhede
                    Me.txtJournalInvRefNr.Text = item.Tjekno
                    Me.txtJournalVatAmount.Text = item.Btwbedrag
                    Me.txtCrossRefNr.Text = item.kwitansienr
                    If item.Btwjn = "J" Then
                        Me.chkJournalVAT.Checked = True
                    Else
                        Me.chkJournalVAT.Checked = False
                    End If
                    If item.Cancel <> 0 Then
                        Me.lblCancel.Enabled = True
                        Me.chkCancel.Enabled = True
                        Me.chkCancel.Checked = True
                    Else
                        Me.lblCancel.Enabled = False
                        Me.chkCancel.Enabled = False
                        Me.chkCancel.Checked = False
                    End If
                Else
                    MsgBox("The Claim Journal could not be found.", vbInformation)
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
    Private Sub GetPayments()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim paramsClaims() As SqlParameter = {New SqlParameter("@pkPayments", SqlDbType.Int)}
                paramsClaims(0).Value = intPkPayments

                Dim readerClaims As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchPaymentspkPayments", paramsClaims)

                If readerClaims.Read Then
                    Dim item As ClaimsPaymentEntity = New ClaimsPaymentEntity()

                    If readerClaims("pkPayments") IsNot DBNull.Value Then
                        item.pkPayments = readerClaims("pkPayments")
                    Else
                        item.pkPayments = 0
                    End If
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
                    If readerClaims("Tjekdatum") IsNot DBNull.Value Then
                        item.Tjekdatum = readerClaims("Tjekdatum")
                    Else
                        item.Tjekdatum = Nothing
                    End If
                    If readerClaims("Tjekbesonderhede") IsNot DBNull.Value Then
                        item.Tjekbesonderhede = readerClaims("Tjekbesonderhede")
                    Else
                        item.Tjekbesonderhede = ""
                    End If
                    If readerClaims("Btwjn") IsNot DBNull.Value Then
                        item.Btwjn = readerClaims("Btwjn")
                    Else
                        item.Btwjn = ""
                    End If
                    If readerClaims("Tjekno") IsNot DBNull.Value Then
                        item.Tjekno = readerClaims("Tjekno")
                    Else
                        item.Tjekno = ""
                    End If
                    If readerClaims("status") IsNot DBNull.Value Then
                        item.status = readerClaims("status")
                    Else
                        item.status = ""
                    End If
                    If readerClaims("Tipe") IsNot DBNull.Value Then
                        item.Tipe = readerClaims("Tipe")
                    Else
                        item.Tipe = ""
                    End If
                    If readerClaims("TipePayment") IsNot DBNull.Value Then
                        item.TipePayment = readerClaims("TipePayment")
                    Else
                        item.TipePayment = ""
                    End If
                    If readerClaims("Trans_dat") IsNot DBNull.Value Then
                        item.Trans_dat = readerClaims("Trans_dat")
                    Else
                        item.Trans_dat = Nothing
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
                    If readerClaims("Faktuurnr") IsNot DBNull.Value Then
                        item.Faktuurnr = readerClaims("Faktuurnr")
                    Else
                        item.Faktuurnr = ""
                    End If
                    If readerClaims("Faks") IsNot DBNull.Value Then
                        item.Faks = readerClaims("Faks")
                    Else
                        item.Faks = ""
                    End If
                    If readerClaims("Waarvoor") IsNot DBNull.Value Then
                        item.Waarvoor = readerClaims("Waarvoor")
                    Else
                        item.Waarvoor = ""
                    End If
                    If readerClaims("Email") IsNot DBNull.Value Then
                        item.Email = readerClaims("Email")
                    Else
                        item.Email = ""
                    End If
                    If readerClaims("Vord_premie") IsNot DBNull.Value Then
                        item.Vord_premie = readerClaims("Vord_premie")
                    Else
                        item.Vord_premie = 0
                    End If
                    If readerClaims("Btwbedrag") IsNot DBNull.Value Then
                        item.Btwbedrag = readerClaims("Btwbedrag")
                    Else
                        item.Btwbedrag = 0
                    End If
                    If readerClaims("Btwuitbedrag") IsNot DBNull.Value Then
                        item.Btwuitbedrag = readerClaims("Btwuitbedrag")
                    Else
                        item.Btwuitbedrag = 0
                    End If
                    If readerClaims("Gekans") IsNot DBNull.Value Then
                        item.Gekans = readerClaims("Gekans")
                    End If
                    If readerClaims("Nedlopie") IsNot DBNull.Value Then
                        item.Nedlopie = readerClaims("Nedlopie")
                    End If
                    If readerClaims("ServiceProviderName") IsNot DBNull.Value Then
                        item.ServiceProviderName = readerClaims("ServiceProviderName")
                    Else
                        item.ServiceProviderName = ""
                    End If
                    If readerClaims("CategoryOfService") IsNot DBNull.Value Then
                        item.CategoryofService = readerClaims("CategoryOfService")
                    Else
                        item.CategoryofService = ""
                    End If
                    If readerClaims("PayeeIdentification") IsNot DBNull.Value Then
                        item.PayeeIdentification = readerClaims("PayeeIdentification")
                    Else
                        item.PayeeIdentification = ""
                    End If
                    If readerClaims("SpecialityOfServiceProvider") IsNot DBNull.Value Then
                        item.SpecialityofServiceProvider = readerClaims("SpecialityOfServiceProvider")
                    Else
                        item.SpecialityofServiceProvider = ""
                    End If
                    If readerClaims("SubCategoryOfService") IsNot DBNull.Value Then
                        item.SubCategoryofService = readerClaims("SubCategoryOfService")
                    Else
                        item.SubCategoryofService = ""
                    End If
                    If readerClaims("VatNumber") IsNot DBNull.Value Then
                        item.VatNumber = readerClaims("VatNumber")
                    Else
                        item.VatNumber = ""
                    End If
                    If readerClaims("Banknaam") IsNot DBNull.Value Then
                        item.Banknaam = readerClaims("Banknaam")
                    Else
                        item.Banknaam = ""
                    End If
                    If readerClaims("Taknaam") IsNot DBNull.Value Then
                        item.Taknaam = readerClaims("Taknaam")
                    Else
                        item.Taknaam = ""
                    End If
                    If readerClaims("Nedbankrek") IsNot DBNull.Value Then
                        item.Nedbankrek = readerClaims("Nedbankrek")
                    Else
                        item.Nedbankrek = ""
                    End If
                    If readerClaims("Nedbankkode") IsNot DBNull.Value Then
                        item.Nedbankkode = readerClaims("Nedbankkode")
                    Else
                        item.Nedbankkode = ""
                    End If
                    If readerClaims("NedrekTipe") IsNot DBNull.Value Then
                        item.NedrekTipe = readerClaims("NedrekTipe")
                    Else
                        item.NedrekTipe = 0
                    End If

                    Me.cmbCategory.Text = item.Waarvoor
                    Me.cmbType.Text = item.TipePayment
                    Me.dtpJournalDate.Value = item.Tjekdatum
                    Me.txtJournalAmount.Text = item.Vord_premie * -1
                    Me.txtJournalAmountWithoutVat.Text = item.Btwuitbedrag * -1
                    Me.txtCrossRefNr.Text = item.Tjekno_uit
                    Me.txtJournalDetails.Text = item.Tjekbesonderhede
                    Me.txtJournalVatAmount.Text = item.Btwbedrag * -1
                    Me.txtJournalInvRefNr.Text = item.Faktuurnr
                    If item.Btwjn = "J" Then
                        Me.chkJournalVAT.Checked = True
                    Else
                        Me.chkJournalVAT.Checked = False
                    End If
                    If item.Gekans <> 0 Then
                        Me.lblCancel.Enabled = True
                        Me.chkCancel.Enabled = True
                        Me.chkCancel.Checked = True
                    Else
                        Me.lblCancel.Enabled = False
                        Me.chkCancel.Enabled = False
                        Me.chkCancel.Checked = False
                    End If
                    strVatNumber = item.VatNumber
                    strServiceProviderName = item.ServiceProviderName
                    strPayeeID = item.PayeeIdentification
                    strCategoryofService = item.CategoryofService
                    strSubCategoryofService = item.SubCategoryofService
                    strSpecialityofServ = item.SpecialityofServiceProvider

                Else
                    MsgBox("The Claim Journal could not be found.", vbInformation)
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

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        If blnInfoChanges = True Then
            If MsgBox("Are you sure you want to cancel and loose all your changes?", vbYesNo) = MsgBoxResult.Yes Then
                Me.Close()
            Else
                Exit Sub
            End If
        Else
            Me.Close()
        End If
    End Sub
    Private Sub GetJournal()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim paramsClaims() As SqlParameter = {New SqlParameter("@pkJoernale", SqlDbType.Int)}
                paramsClaims(0).Value = intpkJoernale

                Dim readerClaims As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchJoernalepkJoernale", paramsClaims)

                If readerClaims.Read Then
                    Dim item As ClaimsJoernaleEntity = New ClaimsJoernaleEntity()

                    If readerClaims("pkJoernale") IsNot DBNull.Value Then
                        item.pkJoernale = readerClaims("pkJoernale")
                    Else
                        item.pkJoernale = 0
                    End If
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
                    If readerClaims("Btwjn") IsNot DBNull.Value Then
                        item.Btwjn = readerClaims("Btwjn")
                    Else
                        item.Btwjn = ""
                    End If
                    If readerClaims("Faktuurnr") IsNot DBNull.Value Then
                        item.JFaktuurnr = readerClaims("Faktuurnr")
                    Else
                        item.JFaktuurnr = ""
                    End If
                    If readerClaims("Tipe") IsNot DBNull.Value Then
                        item.JTipe = readerClaims("Tipe")
                    Else
                        item.JTipe = ""
                    End If
                    If readerClaims("Trans_dat") IsNot DBNull.Value Then
                        item.Trans_dat = readerClaims("Trans_dat")
                    Else
                        item.Trans_dat = Nothing
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
                    If readerClaims("Waarvoor") IsNot DBNull.Value Then
                        item.Waarvoor = readerClaims("Waarvoor")
                    Else
                        item.Waarvoor = ""
                    End If
                    If readerClaims("Vord_Premie") IsNot DBNull.Value Then
                        item.JVord_Premie = readerClaims("Vord_Premie")
                    Else
                        item.JVord_Premie = 0
                    End If
                    If readerClaims("Btwbedrag") IsNot DBNull.Value Then
                        item.Btwbedrag = readerClaims("Btwbedrag")
                    Else
                        item.Btwbedrag = 0
                    End If
                    If readerClaims("Btwuitbedrag") IsNot DBNull.Value Then
                        item.Btwuitbedrag = readerClaims("Btwuitbedrag")
                    Else
                        item.Btwuitbedrag = 0
                    End If
                    If readerClaims("Gekans") IsNot DBNull.Value Then
                        item.Gekans = readerClaims("Gekans")
                    End If
                    If readerClaims("ServiceProviderName") IsNot DBNull.Value Then
                        item.ServiceProviderName = readerClaims("ServiceProviderName")
                    Else
                        item.ServiceProviderName = ""
                    End If
                    If readerClaims("CategoryOfService") IsNot DBNull.Value Then
                        item.CategoryofService = readerClaims("CategoryOfService")
                    Else
                        item.CategoryofService = ""
                    End If
                    If readerClaims("PayeeIdentification") IsNot DBNull.Value Then
                        item.PayeeIdentification = readerClaims("PayeeIdentification")
                    Else
                        item.PayeeIdentification = ""
                    End If
                    If readerClaims("SpecialityOfServiceProvider") IsNot DBNull.Value Then
                        item.SpecialityofServiceProvider = readerClaims("SpecialityOfServiceProvider")
                    Else
                        item.SpecialityofServiceProvider = ""
                    End If
                    If readerClaims("SubCategoryOfService") IsNot DBNull.Value Then
                        item.SubCategoryofService = readerClaims("SubCategoryOfService")
                    Else
                        item.SubCategoryofService = ""
                    End If
                    If readerClaims("VatNumber") IsNot DBNull.Value Then
                        item.VatNumber = readerClaims("VatNumber")
                    Else
                        item.VatNumber = ""
                    End If
                    Me.cmbType.Text = item.TjekofElektronies
                    Me.dtpJournalDate.Value = item.JVord_dat
                    Me.txtJournalAmount.Text = item.JVord_Premie
                    Me.txtJournalAmountWithoutVat.Text = item.Btwuitbedrag
                    Me.txtJournalDetails.Text = item.JTjekbesonderhede
                    Me.txtJournalInvRefNr.Text = item.JFaktuurnr
                    Me.txtJournalVatAmount.Text = item.Btwbedrag
                    Me.txtCrossRefNr.Text = item.KruisVerwysing
                    Me.cmbCategory.Text = item.Waarvoor
                    If item.Btwjn = "J" Then
                        Me.chkJournalVAT.Checked = True
                    Else
                        Me.chkJournalVAT.Checked = False
                    End If
                    If item.Gekans <> 0 Then
                        Me.lblCancel.Enabled = True
                        Me.chkCancel.Enabled = True
                        Me.chkCancel.Checked = True
                    Else
                        Me.lblCancel.Enabled = False
                        Me.chkCancel.Enabled = False
                        Me.chkCancel.Checked = False
                    End If
                    strVatNumber = item.VatNumber
                    strServiceProviderName = item.ServiceProviderName
                    strPayeeID = item.PayeeIdentification
                    strCategoryofService = item.CategoryofService
                    strSubCategoryofService = item.SubCategoryofService
                    strSpecialityofServ = item.SpecialityofServiceProvider
                Else
                    MsgBox("The Claim Journal could not be found.", vbInformation)
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

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If Me.chkCancel.Checked = True Then
            MsgBox("This journal was cancelled.  You cannot edit on a cancelled journal. To edit, please make it active again.", vbInformation)
            Me.chkCancel.Focus()
            Exit Sub
        Else
            SaveJournal()

            frmClaimsList.GetAllJournals()
            Me.Close()
        End If
    End Sub
    Private Sub SaveJournal()
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
                params(2).Value = Me.txtJournalDetails.Text
                params(3).Value = Me.txtJournalAmount.Text
                params(4).Value = Year(Me.dtpJournalDate.Value)
                params(5).Value = Month((Me.dtpJournalDate.Value).AddMonths(-1))
                params(6).Value = Me.txtJournalInvRefNr.Text
                params(7).Value = IIf(Me.txtJournalAmountWithoutVat.Text = "", 0, Me.txtJournalAmountWithoutVat.Text)
                params(8).Value = IIf(Me.txtJournalVatAmount.Text = "", 0, Me.txtJournalVatAmount.Text)
                If Me.chkJournalVAT.Checked = True Then
                    params(9).Value = "J"
                Else
                    params(9).Value = "N"
                End If
                params(10).Value = Me.cmbType.Text
                params(11).Value = Me.txtCrossRefNr.Text
                params(12).Value = strVatNumber
                params(13).Value = Today
                params(14).Value = Me.cmbCategory.Text
                params(15).Value = "JN"
                If Me.cmbType.Text = "EL" Then
                    params(16).Value = "E"
                ElseIf Me.cmbType.Text = "TJ" Then
                    params(16).Value = "T"
                Else
                    params(16).Value = "K"
                End If
                params(17).Value = Me.dtpJournalDate.Value
                params(18).Value = Me.dtpJournalDate.Value
                params(19).Value = intpkJoernale
                params(20).Value = strServiceProviderName
                params(21).Value = strPayeeID
                params(22).Value = strCategoryofService
                params(23).Value = strSubCategoryofService
                params(24).Value = strSpecialityofServ
                params(25).Value = False

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "eisdat.UpdateJoernale", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        Dim strBeskrywing As String = ""
        If intpkJoernale <> 0 Then
            If Persoonl.TAAL = 0 Then
                strBeskrywing = "Eis Joernaal gewysig: " & glbEisno
            Else
                strBeskrywing = "Claim Journal edited: " & glbEisno
            End If
            BaseForm.UpdateWysig(168, strBeskrywing)
        Else
            If Persoonl.TAAL = 0 Then
                strBeskrywing = "Eis Joernaal bygevoeg: " & glbEisno
            Else
                strBeskrywing = "Claim Journal added: " & glbEisno
            End If
            BaseForm.UpdateWysig(168, strBeskrywing)
        End If
    End Sub

    Private Sub chkCancel_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCancel.CheckedChanged
        blnInfoChanges = True
    End Sub
End Class