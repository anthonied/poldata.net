Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports DAL
Public Class frmClaimsPayments
    Dim blnPaymentsValidation As Boolean = False
    Dim blnInfoChanges As Boolean = False

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        If blnInfoChanges = True Then
            If MsgBox("Are you sure you want to cancel and loose all your changes?", vbYesNo) = MsgBoxResult.Yes Then
                blnClaimPaymentBeneficiary = False
                Me.Close()
            Else
                Exit Sub
            End If
        Else
            blnClaimPaymentBeneficiary = False
            Me.Close()
        End If
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If Me.chkCancel.Checked = True Then
            MsgBox("This payment was cancelled.  You cannot edit on a cancelled payment. To edit, please make it active again.", vbInformation)
            Me.chkCancel.Focus()
            Exit Sub
        Else
            PaymentsValidation()

            If blnPaymentsValidation = True Then
                SavePayments()
                blnClaimPaymentBeneficiary = False
                frmClaimsList.GetAllPayments()
                Me.Close()
            End If
        End If

    End Sub
    Private Sub PaymentsValidation()
        blnPaymentsValidation = False

        'Payment type
        If Me.cmbType.Text = "" Then
            MsgBox("A Type must be selected.", vbInformation)
            blnPaymentsValidation = False
            TabPayment.SelectedTab = Me.TabPaymentBeneficiary
            Me.cmbType.Focus()
            Exit Sub
        End If

        'besonderhede 
        If Me.txtBenDetails.Text = "" Then
            MsgBox("Payment details is required.", vbInformation)
            blnPaymentsValidation = False
            TabPayment.SelectedTab = Me.TabPaymentBeneficiary
            Me.txtBenDetails.Focus()
            Exit Sub
        End If

        'invrefnr 
        If Me.txtInvRefNr.Text = "" Then
            MsgBox("Payment reference number is required.", vbInformation)
            blnPaymentsValidation = False
            TabPayment.SelectedTab = Me.TabPaymentBeneficiary
            Me.txtInvRefNr.Focus()
            Exit Sub
        End If

        'date 
        If Me.dtpPaymentDate.Text = "" Then
            MsgBox("A date must be selected.", vbInformation)
            blnPaymentsValidation = False
            TabPayment.SelectedTab = Me.TabPaymentInfo
            Me.dtpPaymentDate.Focus()
            Me.btnOK.Enabled = True
            Exit Sub
        End If

        'amount 
        If Me.txtAmount.Text = "" Then
            MsgBox("The Payment Amount is required.", vbInformation)
            blnPaymentsValidation = False
            TabPayment.SelectedTab = Me.TabPaymentInfo
            Me.txtAmount.Focus()
            Exit Sub
        End If

        If (Not (IsNumeric(txtAmount.Text))) Then
            MsgBox("Amount value must be numeric!")
            TabPayment.SelectedTab = Me.TabPaymentInfo
            Me.txtAmount.Focus()
            blnPaymentsValidation = False
            Exit Sub
        End If

        If Me.txtAmountWithoutVat.Text <> "" Then
            If (Not (IsNumeric(txtAmountWithoutVat.Text))) Then
                MsgBox("Amount without VAT value must be numeric!")
                TabPayment.SelectedTab = Me.TabPaymentInfo
                Me.txtAmountWithoutVat.Focus()
                blnPaymentsValidation = False
                Exit Sub
            End If
        End If

        If Me.txtVatAmount.Text <> "" Then
            If (Not (IsNumeric(txtVatAmount.Text))) Then
                MsgBox("Amount value must be numeric!")
                TabPayment.SelectedTab = Me.TabPaymentInfo
                Me.txtVatAmount.Focus()
                blnPaymentsValidation = False
                Exit Sub
            End If
        End If

        If Me.chkVAT.Checked = True Then
            If Me.txtVATNumber.Text = "" Then
                MsgBox("The VAT number is required.", vbInformation)
                blnPaymentsValidation = False
                TabPayment.SelectedTab = Me.TabPaymentBeneficiary
                Me.txtVATNumber.Focus()
                Exit Sub
            End If
        End If

        'waarvoor
        If Me.cmbCategory.Text = "" Then
            MsgBox("The category must be selected.", vbInformation)
            blnPaymentsValidation = False
            TabPayment.SelectedTab = Me.TabPaymentBeneficiary
            Me.cmbCategory.Focus()
            Exit Sub
        End If

        'vir elektronies moet rek detail ingevul wees.
        If Me.cmbType.Text = "Elektronies" Then
            'Acc number 
            If Me.txtAccNumber.Text = "" Then
                MsgBox("Account number is required.", vbInformation)
                blnPaymentsValidation = False
                TabPayment.SelectedTab = Me.TabPaymentBeneficiary
                Me.txtAccNumber.Focus()
                Exit Sub
            End If
            'account type 
            If Me.cmbAccType.Text = "" Then
                MsgBox("Account type is required.", vbInformation)
                blnPaymentsValidation = False
                TabPayment.SelectedTab = Me.TabPaymentBeneficiary
                Me.cmbAccType.Focus()
                Exit Sub
            End If
            'bankbesonderhede 
            If Me.txtBranchCode.Text = "" Then
                MsgBox("Bank details are required.", vbInformation)
                blnPaymentsValidation = False
                TabPayment.SelectedTab = Me.TabPaymentBeneficiary
                Me.txtBranchCode.Focus()
                Exit Sub
            End If
        End If

        'procurement
        If Me.cmbPayeeId.Text = "" Then
            MsgBox("The procurement must be selected.", vbInformation)
            blnPaymentsValidation = False
            TabPayment.SelectedTab = Me.TabPaymentProcurement
            Me.cmbPayeeId.Focus()
            Exit Sub
        End If

        If Me.cmbCategoryofService.Text = "" Then
            MsgBox("The procurement Category of service must be selected.", vbInformation)
            blnPaymentsValidation = False
            TabPayment.SelectedTab = Me.TabPaymentProcurement
            Me.cmbCategoryofService.Focus()
            Exit Sub
        End If

        If Me.cmbSubCategoryofService.Text = "" Then
            MsgBox("The procurement Sub category of service must be selected.", vbInformation)
            blnPaymentsValidation = False
            TabPayment.SelectedTab = Me.TabPaymentProcurement
            Me.cmbSubCategoryofService.Focus()
            Exit Sub
        End If

        If Me.cmbSpecialityofService.Text = "" Then
            MsgBox("The procurement Speciality of service must be selected.", vbInformation)
            blnPaymentsValidation = False
            TabPayment.SelectedTab = Me.TabPaymentProcurement
            Me.cmbSpecialityofService.Focus()
            Exit Sub
        End If

        blnPaymentsValidation = True
    End Sub
    Private Sub SavePayments()
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
                                                New SqlParameter("@TipePayment", SqlDbType.NVarChar), _
                                                New SqlParameter("@fkBegunstigde", SqlDbType.NVarChar)}

                params(0).Value = glbEisno          'Eisno
                params(1).Value = glbPolicyNumber           'polisno
                params(2).Value = Me.txtBenDetails.Text            'tjekbesonderhede
                params(3).Value = DBNull.Value              'premie
                params(4).Value = ""                    'status
                params(5).Value = ""                    'kwitansie
                params(6).Value = IIf(Me.txtAmountWithoutVat.Text = "", 0, Me.txtAmountWithoutVat.Text)           'Btwuitbedrag
                params(7).Value = IIf(Me.txtVatAmount.Text = "", 0, Me.txtVatAmount.Text)          'Btwbedrag
                If Me.chkVAT.Checked = True Then
                    params(8).Value = "J"                       'BtwJN
                Else
                    params(8).Value = "N"                           'BtwJN
                End If
                ''''''''

                params(9).Value = ""                    'Betaalwyse

                '''''''
                params(10).Value = ""                   'Tjekno
                params(11).Value = Now                'Trans_dat
                If Me.cmbType.Text = "Kontant" Then
                    params(12).Value = "KO"             'Tipe
                ElseIf Me.cmbType.Text = "Tjek" Then
                    params(12).Value = "TJ"         'Tipe
                Else
                    params(12).Value = "EL"             'Tipe
                End If
                params(13).Value = Me.dtpPaymentDate.Value  'Vord_dat
                params(14).Value = intpkPayments                'pkPayments
                params(15).Value = False                    'Gekans
                params(16).Value = DBNull.Value             'Afsluit_dat
                params(17).Value = DBNull.Value             'kans_dat
                params(18).Value = DBNull.Value             'vt_trans_dat
                params(19).Value = DBNull.Value             'mk_Trans_dat
                params(20).Value = DBNull.Value             'jk_Trans_dat
                params(21).Value = DBNull.Value             'eb_Trans_dat
                params(22).Value = DBNull.Value             'ms_Trans_dat
                params(23).Value = DBNull.Value             'ei_Trans_dat
                params(24).Value = DBNull.Value             'md_Trans_dat
                params(25).Value = DBNull.Value             'gg_Trans_dat
                params(26).Value = Me.dtpPaymentDate.Value          'Tjekdatum
                params(27).Value = Year(Me.dtpPaymentDate.Value)        'Jaar
                params(28).Value = Month(Me.dtpPaymentDate.Value)           'Maand
                params(29).Value = 0                    'Bankindeks
                params(30).Value = 0                    'NedrekTipe
                params(31).Value = Me.txtAmount.Text            'Vord_premie
                If Me.chkElectronicRunFinished.Checked Then
                    params(32).Value = True                 'Nedlopie
                Else
                    params(32).Value = False                'Nedlopie
                End If
                params(33).Value = ""               'Verw1
                params(34).Value = ""               'Verw2
                params(35).Value = ""               'Verw3
                params(36).Value = ""               'Verw4
                params(37).Value = ""               'Verw5
                If Me.cmbType.Text = "Kontant" Then
                    params(38).Value = "K"              'Kontant_tipe
                ElseIf Me.cmbType.Text = "Tjek" Then
                    params(38).Value = "T"                  'Kontant_tipe
                Else
                    params(38).Value = "E"              'Kontant_tipe
                End If
                params(39).Value = ""               'Nuwe_Tjekno
                params(40).Value = Me.txtInvRefNr.Text          'Tjekno_uit
                params(41).Value = ""               'Tjekno_in
                params(42).Value = DBNull.Value     'Neddatum
                params(43).Value = Me.txtBranchCode.Text              'Nedbankkode
                params(44).Value = Me.txtAccNumber.Text               'Nedbankrek
                params(45).Value = DBNull.Value         'afdat2
                params(46).Value = Me.cmbCategory.Text       'Waarvoor
                params(47).Value = Me.txtStuurDMV.Text          'Stuurdmv
                params(48).Value = Me.txtFax.Text           'Faks
                params(49).Value = Me.txtEmail.Text             'Email
                params(50).Value = Me.txtBank.Text          'Banknaam
                params(51).Value = Me.txtBranch.Text        'Taknaam
                params(52).Value = ""               'Batchid
                params(53).Value = ""               'BatchTyd
                params(54).Value = Me.txtVATNumber.Text         'VatNumber
                params(55).Value = Me.txtBenDetails.Text               'ServiceProviderName
                params(56).Value = Me.cmbPayeeId.Text           'PayeeIdentification
                params(57).Value = Me.cmbCategoryofService.Text         'CategoryofService
                params(58).Value = Me.cmbSubCategoryofService.Text          'SubCategoryofService
                params(59).Value = Me.cmbSpecialityofService.Text               'SpecialityofServiceProvider
                params(60).Value = ""           'area
                params(61).Value = Me.txtFaktuurnr.Text         'Faktuurnr
                params(62).Value = Me.cmbType.Text              'TipePayment
                params(63).Value = intpkBegunstigde

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "eisdat.UpdatePayments", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        Dim strBeskrywing As String = ""
        If intpkPayments <> 0 Then
            If Persoonl.TAAL = 0 Then
                strBeskrywing = "Eis betaling gewysig: " & glbEisno
            Else
                strBeskrywing = "Claim payment edited: " & glbEisno
            End If
            BaseForm.UpdateWysig(166, strBeskrywing)
        Else
            If Persoonl.TAAL = 0 Then
                strBeskrywing = "Eis betaling bygevoeg: " & glbEisno
            Else
                strBeskrywing = "Claim payment added: " & glbEisno
            End If
            BaseForm.UpdateWysig(166, strBeskrywing)
        End If
    End Sub

    Private Sub cmbPayeeId_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbPayeeId.SelectedIndexChanged
        blnInfoChanges = True

        If cmbPayeeId.Text <> "" Then
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim paramsClaims() As SqlParameter = {New SqlParameter("@PayeeID", SqlDbType.NVarChar)}
                paramsClaims(0).Value = Me.cmbPayeeId.Text

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchProcurementCategoriesCategoryofService", paramsClaims)
                cmbCategoryofService.Items.Clear()
                Do While reader.Read
                    cmbCategoryofService.Items.Add(reader("categoryofservice"))
                Loop
            End Using
            'Me.cmbCategoryofService.Text = ""
            Me.cmbSubCategoryofService.Text = ""
            Me.cmbSpecialityofService.Text = ""
        End If
    End Sub

    Private Sub cmbCategoryofService_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCategoryofService.SelectedIndexChanged
        blnInfoChanges = True

        If cmbPayeeId.Text <> "" And cmbCategoryofService.Text <> "" Then
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim paramsClaims() As SqlParameter = {New SqlParameter("@PayeeID", SqlDbType.NVarChar), _
                                               New SqlParameter("@CategoryofService", SqlDbType.NVarChar)}

                paramsClaims(0).Value = Me.cmbPayeeId.Text
                paramsClaims(1).Value = Me.cmbCategoryofService.Text

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchProcurementCategoriessubCategoryofService", paramsClaims)
                cmbSubCategoryofService.Items.Clear()
                Do While reader.Read
                    cmbSubCategoryofService.Items.Add(reader("subcategoryofservice"))
                Loop

            End Using
            Me.cmbSubCategoryofService.Text = ""
            Me.cmbSpecialityofService.Text = ""
        End If
    End Sub

    Private Sub cmbSubCategoryofService_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbSubCategoryofService.SelectedIndexChanged
        blnInfoChanges = True

        If cmbPayeeId.Text <> "" And cmbCategoryofService.Text <> "" And Me.cmbSubCategoryofService.Text <> "" Then
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim paramsClaims() As SqlParameter = {New SqlParameter("@PayeeID", SqlDbType.NVarChar), _
                                                      New SqlParameter("@CategoryofService", SqlDbType.NVarChar), _
                                               New SqlParameter("@subCategoryofService", SqlDbType.NVarChar)}

                paramsClaims(0).Value = Me.cmbPayeeId.Text
                paramsClaims(1).Value = Me.cmbCategoryofService.Text
                paramsClaims(2).Value = Me.cmbSubCategoryofService.Text

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchProcurementCategoriesSpecialityofService", paramsClaims)
                cmbSpecialityofService.Items.Clear()
                Do While reader.Read
                    cmbSpecialityofService.Items.Add(reader("specialityofserviceprovider"))
                Loop

            End Using

            Me.cmbSpecialityofService.Text = ""
        End If
    End Sub

    Private Sub frmClaimsPayments_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        blnClaimPaymentBeneficiary = False
        intpkBegunstigde = 0

        Me.Text = "Claim Payments - " & Persoonl.VOORL & " " & Persoonl.VERSEKERDE & " - " & glbPolicyNumber & " - " & glbEisno

        populateComboBoxes()

        'Claims Income Type
        Using conn As SqlConnection = SqlHelper.GetConnection

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchDistinctPaymentType")
            cmbType.Items.Clear()
            Do While reader.Read
                cmbType.Items.Add(reader("tipepayment"))
            Loop

        End Using
        cmbType.Text = ""

        clearFields()

        If intPkPayments <> 0 Then
            GetPayments()
        End If

        blnInfoChanges = False
    End Sub
    Private Sub clearFields()
        Me.txtAmount.Text = ""
        Me.txtAmountWithoutVat.Text = ""
        Me.txtEmail.Text = ""
        Me.txtFaktuurnr.Text = ""
        Me.txtFax.Text = ""
        Me.txtInvRefNr.Text = ""
        Me.txtOldChecqueNr.Text = ""
        Me.txtVatAmount.Text = ""
        Me.txtBenDetails.Text = ""
        Me.dtpPaymentDate.Value = Now
        Me.chkElectronicRunFinished.Checked = False
        Me.chkVAT.Checked = False
        Me.chkCancel.Checked = False
        Me.chkCancel.Enabled = False
        Me.lblCancel.Enabled = False
        Me.txtBank.Text = ""
        Me.txtBranch.Text = ""
        Me.txtAccNumber.Text = ""
        Me.txtBranchCode.Text = ""
        Me.chkElectronicRunFinished.Enabled = False
        Me.Label6.Enabled = False
    End Sub
    Private Sub populateComboBoxes()
        'payeeid
        Using conn As SqlConnection = SqlHelper.GetConnection

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchProcurementCategoriesPayeeID")
            cmbPayeeId.Items.Clear()
            Do While reader.Read
                cmbPayeeId.Items.Add(reader("payeeIdentification"))
            Loop

        End Using
        cmbPayeeId.Text = ""

        'category
        Using conn As SqlConnection = SqlHelper.GetConnection

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchWaarvoor")
            cmbCategory.Items.Clear()
            Do While reader.Read
                cmbCategory.Items.Add(reader("Verskaffer"))
            Loop

        End Using
        cmbCategory.Text = ""

        'Populate account type combo box
        cmbAccType.Items.Clear()
        If Persoonl.TAAL = 0 Then
            cmbAccType.Items.Add("Tjek")
            cmbAccType.Items.Add("Spaar")
            cmbAccType.Items.Add("Transmissie")
            cmbAccType.Items.Add("Krediet")
        Else
            cmbAccType.Items.Add("Cheque")
            cmbAccType.Items.Add("Savings")
            cmbAccType.Items.Add("Transmission")
            cmbAccType.Items.Add("Credit")
        End If
    End Sub
    Private Sub GetPayments()
        Me.cmbCategoryofService.DisplayMember = ""
        Me.cmbCategoryofService.Invalidate()
        Me.cmbAccType.DisplayMember = ""
        Me.cmbAccType.Invalidate()
        Me.cmbCategory.DisplayMember = ""
        Me.cmbCategory.Invalidate()
        Me.cmbPayeeId.DisplayMember = ""
        Me.cmbPayeeId.Invalidate()
        Me.cmbSpecialityofService.DisplayMember = ""
        Me.cmbSpecialityofService.Invalidate()
        Me.cmbSubCategoryofService.DisplayMember = ""
        Me.cmbSubCategoryofService.Invalidate()
        Me.cmbType.DisplayMember = ""
        Me.cmbType.Invalidate()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim paramsClaims() As SqlParameter = {New SqlParameter("@pkPayments", SqlDbType.Int)}
                paramsClaims(0).Value = intpkPayments

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

                    Me.cmbCategory.BindingContext(item.Waarvoor).SuspendBinding()
                    Me.cmbCategory.BindingContext(item.Waarvoor).ResumeBinding()
                    Me.cmbCategory.Text = item.Waarvoor
                    Me.cmbType.BindingContext(item.TipePayment).SuspendBinding()
                    Me.cmbType.BindingContext(item.TipePayment).ResumeBinding()
                    Me.cmbType.Text = item.TipePayment
                    Me.dtpPaymentDate.Value = item.Tjekdatum
                    Me.txtAmount.Text = item.Vord_premie
                    Me.txtAmountWithoutVat.Text = item.Btwuitbedrag
                    Me.txtInvRefNr.Text = item.Tjekno_uit
                    Me.txtFaktuurnr.Text = item.Faktuurnr
                    Me.txtVatAmount.Text = item.Btwbedrag
                    Me.chkElectronicRunFinished.Checked = item.Nedlopie
                    If item.Btwjn = "J" Then
                        Me.chkVAT.Checked = True
                    Else
                        Me.chkVAT.Checked = False
                    End If
                    Me.txtVATNumber.Text = item.VatNumber
                    If item.Gekans <> 0 Then
                        Me.lblCancel.Enabled = True
                        Me.chkCancel.Enabled = True
                        Me.chkCancel.Checked = True
                    Else
                        Me.lblCancel.Enabled = False
                        Me.chkCancel.Enabled = False
                        Me.chkCancel.Checked = False
                    End If
                    'kyk of begunstigde klient, eenmalig of gestoor is
                    If Me.txtBenDetails.Text = Persoonl.VOORL & " " & Persoonl.VERSEKERDE Then
                        Me.optClient.Checked = True
                    Else
                        Try
                            Using conn1 As SqlConnection = SqlHelper.GetConnection
                                Dim params() As SqlParameter = {New SqlParameter("@Begunstigde", SqlDbType.NVarChar)}
                                params(0).Value = item.Tjekbesonderhede

                                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchBegunstigde", params)

                                If reader.Read Then
                                    Me.optStoredBeneficiary.Checked = True
                                Else
                                    Me.optNonRecurrent.Checked = True
                                End If

                                If conn1.State = ConnectionState.Open Then
                                    conn1.Close()
                                    reader.Close()
                                End If
                            End Using
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                        End Try
                    End If
                    Me.txtFax.Text = item.Faks
                    Me.txtEmail.Text = item.Email
                    Me.cmbCategoryofService.BindingContext(item.CategoryofService).SuspendBinding()
                    Me.cmbCategoryofService.BindingContext(item.CategoryofService).ResumeBinding()
                    Me.cmbCategoryofService.Text = item.CategoryofService
                    Me.cmbPayeeId.BindingContext(item.PayeeIdentification).SuspendBinding()
                    Me.cmbPayeeId.BindingContext(item.PayeeIdentification).ResumeBinding()
                    Me.cmbPayeeId.Text = item.PayeeIdentification
                    Me.cmbSpecialityofService.BindingContext(item.SpecialityofServiceProvider).SuspendBinding()
                    Me.cmbSpecialityofService.BindingContext(item.SpecialityofServiceProvider).ResumeBinding()
                    Me.cmbSpecialityofService.Text = item.SpecialityofServiceProvider
                    Me.cmbSubCategoryofService.BindingContext(item.SubCategoryofService).SuspendBinding()
                    Me.cmbSubCategoryofService.BindingContext(item.SubCategoryofService).ResumeBinding()
                    Me.cmbSubCategoryofService.Text = item.SubCategoryofService
                    Me.txtBenDetails.Text = item.Tjekbesonderhede
                    If Me.cmbType.Text <> "Tjek" Then
                        Me.txtBank.Text = item.Banknaam
                        Me.txtBranch.Text = item.Taknaam
                        Me.txtAccNumber.Text = item.Nedbankrek
                        Me.txtBranchCode.Text = item.Nedbankkode
                        Me.cmbAccType.BindingContext(item.NedrekTipe).SuspendBinding()
                        Me.cmbAccType.BindingContext(item.NedrekTipe).ResumeBinding()
                        Me.cmbAccType.SelectedIndex = item.NedrekTipe
                    End If
                    If item.TipePayment <> "Elektronies" Then
                        Me.chkElectronicRunFinished.Enabled = False
                        Me.Label6.Enabled = False
                    Else
                        Me.chkElectronicRunFinished.Enabled = True
                        Me.Label6.Enabled = True
                    End If

                    If item.Gekans <> 0 Then
                        Me.TabPaymentBeneficiary.Enabled = False
                        Me.TabPaymentProcurement.Enabled = False
                        Me.TabPaymentInfo.Enabled = False
                    End If
                Else
                    MsgBox("The Claim payment could not be found.", vbInformation)
                End If

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    readerClaims.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Me.cmbCategoryofService.Refresh()
        Me.cmbAccType.Refresh()
        Me.cmbCategory.Refresh()
        Me.cmbPayeeId.Refresh()
        Me.cmbSpecialityofService.Refresh()
        Me.cmbSubCategoryofService.Refresh()
        Me.cmbType.Refresh()
        blnInfoChanges = False
    End Sub

    Private Sub chkVAT_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkVAT.CheckedChanged
        blnInfoChanges = True
        VatAmount()

    End Sub
    Private Sub VatAmount()
        'werk vat uit
        If Me.chkVAT.Checked = True Then
            Me.txtVatAmount.Text = FormatNumber((IIf(Me.txtAmount.Text = "", 0, Me.txtAmount.Text) * (Constants.VAT / 100)), 2)
            Me.txtAmountWithoutVat.Text = FormatNumber((IIf(Me.txtAmount.Text = "", 0, Me.txtAmount.Text) - Me.txtVatAmount.Text), 2)
        Else
            Me.txtVatAmount.Text = 0
            Me.txtAmountWithoutVat.Text = 0
        End If
    End Sub
    Private Sub cmdStoredBeneficiary_Click(sender As System.Object, e As System.EventArgs) Handles cmdStoredBeneficiary.Click
        Me.cmbAccType.DisplayMember = ""
        Me.cmbAccType.Invalidate()
        Me.cmbAccType.Refresh()
        Me.optStoredBeneficiary.Checked = True
        blnClaimPaymentBeneficiary = True
        frmClaimsBeneficiary.Show()
    End Sub

    Private Sub optClient_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optClient.CheckedChanged
        blnClaimPaymentBeneficiary = False
        blnInfoChanges = True

        If optClient.Checked = True Then
            intpkBegunstigde = 0
            Me.cmbAccType.DisplayMember = ""
            Me.cmbAccType.Invalidate()
            Me.cmbAccType.Refresh()
            Me.txtFax.Text = Persoonl.FAX
            Me.txtEmail.Text = Persoonl.EMAIL
            Me.txtBenDetails.Text = Persoonl.VOORL & " " & Persoonl.VERSEKERDE
            If Persoonl.BET_WYSE = "4" Then
                'Seek record in aftrek for this policy
                Try
                    Using conn As SqlConnection = SqlHelper.GetConnection
                        Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                        param.Value = glbPolicyNumber

                        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAftrek", param)

                        If reader.Read() Then
                            Me.cmbAccType.BindingContext(reader("A_TIPE")).SuspendBinding()
                            Me.cmbAccType.BindingContext(reader("A_TIPE")).ResumeBinding()
                            Me.cmbAccType.SelectedIndex = Val(reader("A_TIPE") - 1)
                            Me.cmbAccType.Refresh()
                            Me.txtAccNumber.Text = reader("REK_NO1")
                            Me.txtPkBnkCodes.Text = reader("fkBankCodes")
                            Bet_Wyse.getBankDetails((reader("fkBankCodes")), bankName, branchName, branchCode, accType)
                            Me.txtBank.Text = bankName
                            Me.txtBranch.Text = branchName
                            Me.txtBranchCode.Text = branchCode
                        Else
                            MsgBox("Can't find stored bank details for this client.", vbInformation)
                            Exit Sub
                        End If
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                            reader.Close()
                        End If
                    End Using
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
            Else
                MsgBox("This is not a monthly debit client.  There are no stored bank details for this client.", vbInformation)
                Exit Sub
            End If
        Else
            Me.txtAccNumber.Text = ""
            Me.txtBank.Text = ""
            Me.txtBranch.Text = ""
            Me.txtPkBnkCodes.Text = ""
            Me.txtBranchCode.Text = ""
            Me.cmbAccType.Text = ""
            Me.txtFax.Text = ""
            Me.txtEmail.Text = ""
            Me.txtBenDetails.Text = ""
            Me.cmbSubCategoryofService.Text = ""
            Me.cmbCategoryofService.Text = ""
            Me.cmbPayeeId.Text = ""
            Me.cmbSpecialityofService.Text = ""
        End If
        Me.cmbAccType.Refresh()
        Me.cmbCategoryofService.Refresh()
        Me.cmbSubCategoryofService.Refresh()
        Me.cmbPayeeId.Refresh()
        Me.cmbSpecialityofService.Refresh()
    End Sub

    Private Sub optNonRecurrent_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optNonRecurrent.CheckedChanged
        blnClaimPaymentBeneficiary = False
        blnInfoChanges = True

        If optNonRecurrent.Checked = True Then
            intpkBegunstigde = 0
            Me.cmbAccType.DisplayMember = ""
            Me.cmbAccType.Invalidate()
            Me.cmbAccType.Refresh()
            Me.txtAccNumber.Text = ""
            Me.txtBank.Text = ""
            Me.txtBranch.Text = ""
            Me.txtPkBnkCodes.Text = ""
            Me.txtBranchCode.Text = ""
            Me.cmbAccType.Text = ""
            Me.txtFax.Text = ""
            Me.txtEmail.Text = ""
            Me.cmbSubCategoryofService.Text = ""
            Me.cmbCategoryofService.Text = ""
            Me.cmbPayeeId.Text = ""
            Me.cmbSpecialityofService.Text = ""
        End If
        Me.cmbAccType.Refresh()
        Me.cmbCategoryofService.Refresh()
        Me.cmbSubCategoryofService.Refresh()
        Me.cmbPayeeId.Refresh()
        Me.cmbSpecialityofService.Refresh()
    End Sub

    Private Sub optStoredBeneficiary_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optStoredBeneficiary.CheckedChanged
        blnClaimPaymentBeneficiary = False
        blnInfoChanges = True

        If Me.optStoredBeneficiary.Checked = True Then
            intpkBegunstigde = 0
            Me.cmbAccType.DisplayMember = ""
            Me.cmbAccType.Invalidate()
            Me.cmbAccType.Refresh()
            Me.txtAccNumber.Text = ""
            Me.txtBank.Text = ""
            Me.txtBranch.Text = ""
            Me.txtPkBnkCodes.Text = ""
            Me.txtBranchCode.Text = ""
            Me.cmbAccType.Text = ""
            Me.txtFax.Text = ""
            Me.txtEmail.Text = ""
            Me.txtBenDetails.Text = ""
            Me.cmbSubCategoryofService.Text = ""
            Me.cmbCategoryofService.Text = ""
            Me.cmbPayeeId.Text = ""
            Me.cmbSpecialityofService.Text = ""
        End If
        Me.cmbAccType.Refresh()
        Me.cmbCategoryofService.Refresh()
        Me.cmbSubCategoryofService.Refresh()
        Me.cmbPayeeId.Refresh()
        Me.cmbSpecialityofService.Refresh()
    End Sub

    Private Sub txtBenDetails_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBenDetails.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub cmbType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbType.SelectedIndexChanged
        blnInfoChanges = True
    End Sub

    Private Sub chkCancel_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCancel.CheckedChanged
        blnInfoChanges = True
    End Sub

    Private Sub chkElectronicRunFinished_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkElectronicRunFinished.CheckedChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtDetails_TextChanged(sender As System.Object, e As System.EventArgs)
        blnInfoChanges = True
    End Sub

    Private Sub txtInvRefNr_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtInvRefNr.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtOldChecqueNr_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOldChecqueNr.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtFaktuurnr_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFaktuurnr.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtAmount_Leave(sender As Object, e As System.EventArgs) Handles txtAmount.Leave
        If Me.txtAmount.Text = "" Then
            Me.txtAmount.Text = "0"
        End If
    End Sub

    Private Sub txtAmount_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAmount.TextChanged
        blnInfoChanges = True
        
        If Me.chkVAT.Checked = True Then
            VatAmount()
        End If
    End Sub

    Private Sub txtVATNumber_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtVATNumber.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtVatAmount_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtVatAmount.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtAmountWithoutVat_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAmountWithoutVat.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub dtpPaymentDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpPaymentDate.ValueChanged
        blnInfoChanges = True
    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCategory.SelectedIndexChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtAccNumber_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAccNumber.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub cmbAccType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbAccType.SelectedIndexChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtBank_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBank.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtPkBnkCodes_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPkBnkCodes.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtBranch_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBranch.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtBranchCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBranchCode.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtFax_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFax.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtEmail_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtEmail.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub cmbSpecialityofService_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbSpecialityofService.SelectedIndexChanged
        blnInfoChanges = True
    End Sub

    Private Sub btnBanke_Click(sender As System.Object, e As System.EventArgs) Handles btnBanke.Click
        BnkCodes.txtFormToPopulate.Text = Me.Name
        BnkCodes.Show()
    End Sub
End Class