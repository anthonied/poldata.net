Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports DAL
Public Class frmClaimsBeneficiary
    Dim blnEnabled As Boolean
    Dim blnBeneficiaryValidation As Boolean
    Dim blnSoek As Boolean = False
    Dim intRow As Integer
    Dim blnInfoChanges As Boolean = False
    Dim strBeneficiary As String = ""
    Dim blnAddEdit As Boolean = False

    Private Sub frmClaimsBeneficiary_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FieldsEnabled(False)

        dgvBeneficiaries.AutoGenerateColumns = False
        dgvBeneficiaries.DataSource = Nothing
        dgvBeneficiaries.Refresh()

        PopulateComboBoxes()

        populateGrid()

        blnInfoChanges = False
    End Sub

    Private Sub btnBanke_Click(sender As System.Object, e As System.EventArgs) Handles btnBanke.Click
        BnkCodes.txtFormToPopulate.Text = Me.Name
        BnkCodes.Show()
    End Sub
    Private Sub FieldsEnabled(ByVal blnEnabled As Boolean)
        Me.txtAccountNr.Enabled = blnEnabled
        Me.txtBank.Enabled = blnEnabled
        Me.txtBeneficiary.Enabled = blnEnabled
        Me.txtBranchCode.Enabled = blnEnabled
        Me.txtEmail.Enabled = blnEnabled
        Me.txtFax.Enabled = blnEnabled
        Me.cmbAccountType.Enabled = blnEnabled
        Me.cmbCategoryofService.Enabled = blnEnabled
        Me.cmbPayeeId.Enabled = blnEnabled
        Me.cmbSpecialityofService.Enabled = blnEnabled
        Me.cmbSubCategoryofService.Enabled = blnEnabled
        Me.btnBanke.Enabled = blnEnabled
        Me.txtSearchAssessor.Enabled = blnEnabled
        Me.cmdSearchAssessor.Enabled = blnEnabled
    End Sub
    Private Sub PopulateComboBoxes()
        'Populate account type combo box
        Me.cmbAccountType.Items.Clear()
        If Persoonl.TAAL = 0 Then
            cmbAccountType.Items.Add("Tjek")
            cmbAccountType.Items.Add("Spaar")
            cmbAccountType.Items.Add("Transmissie")
            cmbAccountType.Items.Add("Krediet")
        Else
            cmbAccountType.Items.Add("Cheque")
            cmbAccountType.Items.Add("Savings")
            cmbAccountType.Items.Add("Transmission")
            cmbAccountType.Items.Add("Credit")
        End If

        'payeeid
        Using conn As SqlConnection = SqlHelper.GetConnection

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchProcurementCategoriesPayeeID")
            cmbPayeeId.Items.Clear()
            Do While reader.Read
                cmbPayeeId.Items.Add(reader("payeeIdentification"))
            Loop

        End Using
        cmbPayeeId.Text = ""
    End Sub
    Private Sub populateGrid()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params() As SqlParameter = {New SqlParameter("@Begunstigde", SqlDbType.NVarChar)}
                If blnSoek = True Then
                    params(0).Value = Me.txtSearchBeneficiary.Text
                Else
                    params(0).Value = ""
                End If

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchBegunstigde", params)

                Dim BegunstigdeList As List(Of ClaimsBegunstigdeEntity) = New List(Of ClaimsBegunstigdeEntity)

                Do While reader.Read
                    Dim item As ClaimsBegunstigdeEntity = New ClaimsBegunstigdeEntity()

                    If reader("Begunstigde") IsNot DBNull.Value Then
                        item.Begunstigde = reader("Begunstigde")
                    Else
                        item.Begunstigde = ""
                    End If
                    If reader("Bank") IsNot DBNull.Value Then
                        item.Bank = reader("Bank")
                    Else
                        item.Bank = ""
                    End If
                    If reader("BankRekNo") IsNot DBNull.Value Then
                        item.BankRekNo = reader("BankRekNo")
                    Else
                        item.BankRekNo = ""
                    End If
                    If reader("fkBankCodes") IsNot DBNull.Value Then
                        item.fkBankCodes = reader("fkBankCodes")
                    Else
                        item.fkBankCodes = 0
                    End If
                    If reader("CategoryOfService") IsNot DBNull.Value Then
                        item.CategoryOfService = reader("CategoryOfService")
                    Else
                        item.CategoryOfService = ""
                    End If
                    If reader("Email") IsNot DBNull.Value Then
                        item.Email = reader("Email")
                    Else
                        item.Email = ""
                    End If
                    If reader("Faks") IsNot DBNull.Value Then
                        item.Faks = reader("Faks")
                    Else
                        item.Faks = ""
                    End If
                    If reader("NedRekTipe") IsNot DBNull.Value Then
                        item.NedRekTipe = reader("NedRekTipe")
                    Else
                        item.NedRekTipe = 0
                    End If
                    If reader("PayeeIdentification") IsNot DBNull.Value Then
                        item.PayeeIdentification = reader("PayeeIdentification")
                    Else
                        item.PayeeIdentification = ""
                    End If
                    If reader("Rektipe") IsNot DBNull.Value Then
                        item.Rektipe = reader("Rektipe")
                    Else
                        item.Rektipe = ""
                    End If
                    If reader("SpecialityOfServiceProvider") IsNot DBNull.Value Then
                        item.SpecialityOfServiceProvider = reader("SpecialityOfServiceProvider")
                    Else
                        item.SpecialityOfServiceProvider = ""
                    End If
                    If reader("SubCategoryOfService") IsNot DBNull.Value Then
                        item.SubCategoryOfService = reader("SubCategoryOfService")
                    Else
                        item.SubCategoryOfService = ""
                    End If
                    If reader("Takkode") IsNot DBNull.Value Then
                        item.Takkode = reader("Takkode")
                    Else
                        item.Takkode = ""
                    End If
                    If reader("pkBegunstigde") IsNot DBNull.Value Then
                        item.pkBegunstigde = reader("pkBegunstigde")
                    Else
                        item.pkBegunstigde = 0
                    End If

                    'Get the bank details using fk
                    If item.fkBankCodes <> 0 Then
                        Bet_Wyse.getBankDetails((item.fkBankCodes), bankName, branchName, branchCode, accType)
                        item.Bank = bankName
                    End If

                    BegunstigdeList.Add(item)
                Loop

                dgvBeneficiaries.DataSource = BegunstigdeList

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    reader.Close()
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

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        FieldsEnabled(True)
        Me.btnOK.Enabled = True
        Me.btnApply.Enabled = True

        If bankName = "" And branchCode = "" Then
            MsgBox("There is no bank stored for this beneficiary - please add a bank.", vbInformation)
        End If
        blnAddEdit = True
    End Sub

    Private Sub btnVoegby_Click(sender As System.Object, e As System.EventArgs) Handles btnVoegby.Click
        FieldsEnabled(True)
        Me.txtFax.Text = ""
        Me.txtEmail.Text = ""
        Me.txtBranchCode.Text = ""
        Me.txtBeneficiary.Text = ""
        Me.txtBank.Text = ""
        Me.txtAccountNr.Text = ""
        Me.cmbAccountType.Text = ""
        Me.cmbCategoryofService.Text = ""
        Me.cmbPayeeId.Text = ""
        Me.cmbSpecialityofService.Text = ""
        Me.cmbSubCategoryofService.Text = ""
        Me.txtSearchAssessor.Text = ""
        Me.btnOK.Enabled = True
        Me.btnApply.Enabled = True
        blnAddEdit = True
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        Me.btnOK.Enabled = False

        'validation
        BeneficiaryValidation()

        'save
        If blnBeneficiaryValidation = True Then
            SaveBeneficiaryDetails()

            Me.txtFax.Text = ""
            Me.txtEmail.Text = ""
            Me.txtBranchCode.Text = ""
            Me.txtBeneficiary.Text = ""
            Me.txtBank.Text = ""
            Me.txtAccountNr.Text = ""
            Me.cmbAccountType.Text = ""
            Me.cmbCategoryofService.Text = ""
            Me.cmbPayeeId.Text = ""
            Me.cmbSpecialityofService.Text = ""
            Me.cmbSubCategoryofService.Text = ""
            Me.txtSearchAssessor.Text = ""

            Me.Close()
        End If
    End Sub

    Private Sub btnApply_Click(sender As System.Object, e As System.EventArgs) Handles btnApply.Click
        Me.btnOK.Enabled = False

        'validation
        BeneficiaryValidation()

        'save
        If blnBeneficiaryValidation = True Then
            SaveBeneficiaryDetails()

            populateGrid()

            FieldsEnabled(False)
            Me.txtFax.Text = ""
            Me.txtEmail.Text = ""
            Me.txtBranchCode.Text = ""
            Me.txtBeneficiary.Text = ""
            Me.txtBank.Text = ""
            Me.txtAccountNr.Text = ""
            Me.cmbAccountType.Text = ""
            Me.cmbCategoryofService.Text = ""
            Me.cmbPayeeId.Text = ""
            Me.cmbSpecialityofService.Text = ""
            Me.cmbSubCategoryofService.Text = ""
            Me.txtSearchAssessor.Text = ""

            blnInfoChanges = False
            Me.btnOK.Enabled = True

            If blnClaimPaymentBeneficiary = True Then
                Me.Close()
            End If
        End If
    End Sub
    Private Sub BeneficiaryValidation()
        blnBeneficiaryValidation = False

        'Begunstigde 
        If Me.txtBeneficiary.Text = "" Then
            If blnClaimPaymentBeneficiary = True Then
                MsgBox("A beneficiary must be selected.", vbInformation)
            Else
                MsgBox("The beneficiary name is required.", vbInformation)
            End If
            blnBeneficiaryValidation = False
            Me.txtBeneficiary.Focus()
            Me.btnOK.Enabled = True
            Exit Sub
        End If

        'Accountnr 
        If Me.txtAccountNr.Text = "" Then
            MsgBox("An account nr must be filled in.", vbInformation)
            blnBeneficiaryValidation = False
            Me.txtAccountNr.Focus()
            Me.btnOK.Enabled = True
            Exit Sub
        End If

        'Accounttype
        If Me.cmbAccountType.Text = "" Then
            MsgBox("An account type must be chosen.", vbInformation)
            blnBeneficiaryValidation = False
            Me.cmbAccountType.Focus()
            Me.btnOK.Enabled = True
            Exit Sub
        End If

        'Bank
        If Me.txtBankCodes.Text = "" Then
            MsgBox("A bank must be chosen.", vbInformation)
            blnBeneficiaryValidation = False
            Me.txtBank.Focus()
            Me.btnOK.Enabled = True
            Exit Sub
        End If

        blnBeneficiaryValidation = True
    End Sub
    Private Sub SaveBeneficiaryDetails()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Begunstigde", SqlDbType.NVarChar), _
                                                New SqlParameter("@fkBankcode", SqlDbType.Int), _
                                                New SqlParameter("@BankRekno", SqlDbType.NVarChar), _
                                                New SqlParameter("@RekTipe", SqlDbType.NVarChar), _
                                                New SqlParameter("@Stuurdmv", SqlDbType.NVarChar), _
                                                New SqlParameter("@Faks", SqlDbType.NVarChar), _
                                                New SqlParameter("@email", SqlDbType.NVarChar), _
                                                New SqlParameter("@PayeeIdentification", SqlDbType.NVarChar), _
                                                New SqlParameter("@CategoryOfService", SqlDbType.NVarChar), _
                                                New SqlParameter("@SubCategoryofService", SqlDbType.NVarChar), _
                                                New SqlParameter("@SpecialityOfServiceProvider", SqlDbType.NVarChar), _
                                                New SqlParameter("@fkAssessor", SqlDbType.Int)}

                params(0).Value = Me.txtBeneficiary.Text
                params(1).Value = Me.txtBankCodes.Text
                params(2).Value = Me.txtAccountNr.Text
                params(3).Value = Me.cmbAccountType.Text
                params(4).Value = ""
                params(5).Value = Me.txtFax.Text
                params(6).Value = Me.txtEmail.Text
                params(7).Value = Me.cmbPayeeId.Text
                params(8).Value = Me.cmbCategoryofService.Text
                params(9).Value = Me.cmbSubCategoryofService.Text
                params(10).Value = Me.cmbSpecialityofService.Text
                params(11).Value = intfkAssessor

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "eisdat.UpdateBegunstigde", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub dgvBeneficiaries_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBeneficiaries.CellClick
        FieldsEnabled(False)
        blnAddEdit = False
        intRow = e.RowIndex
        Me.btnOK.Enabled = True
        Me.btnApply.Enabled = True

        GetBeneficiaryData()

        blnInfoChanges = False
    End Sub
    Public Sub GetBeneficiaryData()
        If intRow >= 0 Then
            Me.cmbAccountType.SelectedIndex = -1
            Me.cmbCategoryofService.SelectedIndex = -1
            Me.cmbPayeeId.SelectedIndex = -1
            Me.cmbSpecialityofService.SelectedIndex = -1
            Me.cmbSubCategoryofService.SelectedIndex = -1
            intpkBegunstigde = 0

            Try
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim params() As SqlParameter = {New SqlParameter("@Begunstigde", SqlDbType.NVarChar)}
                    params(0).Value = Me.dgvBeneficiaries.Item(0, intRow).Value

                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchBegunstigde", params)

                    If reader.Read Then
                        Dim item As ClaimsBegunstigdeEntity = New ClaimsBegunstigdeEntity()

                        If reader("Begunstigde") IsNot DBNull.Value Then
                            item.Begunstigde = reader("Begunstigde")
                        Else
                            item.Begunstigde = ""
                        End If
                        If reader("Bank") IsNot DBNull.Value Then
                            item.Bank = reader("Bank")
                        Else
                            item.Bank = ""
                        End If
                        If reader("BankRekNo") IsNot DBNull.Value Then
                            item.BankRekNo = reader("BankRekNo")
                        Else
                            item.BankRekNo = ""
                        End If
                        If reader("fkBankCodes") IsNot DBNull.Value Then
                            item.fkBankCodes = reader("fkBankCodes")
                        Else
                            item.fkBankCodes = 0
                        End If
                        If reader("CategoryOfService") IsNot DBNull.Value Then
                            item.CategoryOfService = reader("CategoryOfService")
                        Else
                            item.CategoryOfService = ""
                        End If
                        If reader("Email") IsNot DBNull.Value Then
                            item.Email = reader("Email")
                        Else
                            item.Email = ""
                        End If
                        If reader("Faks") IsNot DBNull.Value Then
                            item.Faks = reader("Faks")
                        Else
                            item.Faks = ""
                        End If
                        If reader("NedRekTipe") IsNot DBNull.Value Then
                            item.NedRekTipe = reader("NedRekTipe")
                        Else
                            item.NedRekTipe = 0
                        End If
                        If reader("PayeeIdentification") IsNot DBNull.Value Then
                            item.PayeeIdentification = reader("PayeeIdentification")
                        Else
                            item.PayeeIdentification = ""
                        End If
                        If reader("Rektipe") IsNot DBNull.Value Then
                            item.Rektipe = reader("Rektipe")
                        Else
                            item.Rektipe = ""
                        End If
                        If reader("SpecialityOfServiceProvider") IsNot DBNull.Value Then
                            item.SpecialityOfServiceProvider = reader("SpecialityOfServiceProvider")
                        Else
                            item.SpecialityOfServiceProvider = ""
                        End If
                        If reader("SubCategoryOfService") IsNot DBNull.Value Then
                            item.SubCategoryOfService = reader("SubCategoryOfService")
                        Else
                            item.SubCategoryOfService = ""
                        End If
                        If reader("Takkode") IsNot DBNull.Value Then
                            item.Takkode = reader("Takkode")
                        Else
                            item.Takkode = ""
                        End If
                        If reader("fkAssessor") IsNot DBNull.Value Then
                            item.fkAssessor = reader("fkAssessor")
                        Else
                            item.fkAssessor = 0
                        End If
                        If reader("pkBegunstigde") IsNot DBNull.Value Then
                            item.pkBegunstigde = reader("pkBegunstigde")
                        Else
                            item.pkBegunstigde = 0
                        End If

                        intfkAssessor = item.fkAssessor
                        If intfkAssessor <> 0 Then
                            Me.txtSearchAssessor.Text = reader("AssessorName")
                        End If

                        strBeneficiary = item.Begunstigde
                        Me.txtBank.Text = ""
                        Me.txtBranchCode.Text = ""
                        bankName = ""
                        branchCode = ""
                        branchName = ""
                        accType = ""
                        'Get the bank details using fk
                        Bet_Wyse.getBankDetails((item.fkBankCodes), bankName, branchName, branchCode, accType)
                        Me.txtBankCodes.Text = item.fkBankCodes
                        Me.txtFax.Text = item.Faks
                        Me.txtEmail.Text = item.Email
                        Me.txtBranchCode.Text = branchCode
                        Me.txtBeneficiary.Text = item.Begunstigde
                        Me.txtBank.Text = bankName
                        Me.txtAccountNr.Text = item.BankRekNo
                        Me.cmbAccountType.Text = item.Rektipe
                        Me.cmbPayeeId.Text = item.PayeeIdentification
                        Me.cmbCategoryofService.Text = item.CategoryOfService
                        Me.cmbCategoryofService.Refresh()
                        Me.cmbSubCategoryofService.Text = item.SubCategoryOfService
                        Me.cmbSpecialityofService.Text = item.SpecialityOfServiceProvider

                        'vul vorm payments
                        If blnClaimPaymentBeneficiary = True Then
                            frmClaimsPayments.cmbCategoryofService.SelectedIndex = -1
                            frmClaimsPayments.cmbPayeeId.SelectedIndex = -1
                            frmClaimsPayments.cmbSubCategoryofService.SelectedIndex = -1
                            frmClaimsPayments.cmbSpecialityofService.SelectedIndex = -1

                            If item.PayeeIdentification = "" Or item.CategoryOfService = "" Or item.SubCategoryOfService = "" Then
                                MsgBox("The procurement of this Beneficiary must be filled in before it can be used as a beneficiary", vbInformation)
                                Me.btnOK.Enabled = False
                            Else
                                intpkBegunstigde = item.pkBegunstigde
                                frmClaimsPayments.txtAccNumber.Text = item.BankRekNo
                                frmClaimsPayments.txtBenDetails.Text = item.Begunstigde
                                If item.Rektipe IsNot DBNull.Value Then
                                    frmClaimsPayments.cmbAccType.Text = item.Rektipe
                                Else
                                    frmClaimsPayments.cmbAccType.Text = ""
                                End If
                                If item.fkBankCodes <> 0 Then
                                    frmClaimsPayments.txtPkBnkCodes.Text = item.fkBankCodes
                                    frmClaimsPayments.txtBank.Text = bankName
                                    frmClaimsPayments.txtBranchCode.Text = branchCode
                                    frmClaimsPayments.txtBranch.Text = branchName
                                Else
                                    frmClaimsPayments.txtBranchCode.Text = item.Takkode
                                    frmClaimsPayments.txtBank.Text = item.Bank
                                End If
                                frmClaimsPayments.txtFax.Text = item.Faks
                                frmClaimsPayments.txtEmail.Text = item.Email
                                frmClaimsPayments.txtStuurDMV.Text = item.stuurdmv
                                frmClaimsPayments.cmbPayeeId.Text = item.PayeeIdentification
                                frmClaimsPayments.cmbCategoryofService.Text = item.CategoryOfService
                                frmClaimsPayments.cmbSubCategoryofService.Text = item.SubCategoryOfService
                                frmClaimsPayments.cmbSpecialityofService.Text = item.SpecialityOfServiceProvider
                            End If
                        End If
                        GetAllPaymentsBeneficiary()
                    Else
                        MsgBox("The Beneficiary could not be found.", vbInformation)
                    End If
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                        reader.Close()
                    End If
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
        Me.cmbAccountType.Refresh()
        'Me.cmbCategoryofService.Refresh()
        Me.cmbPayeeId.Refresh()
        Me.cmbSpecialityofService.Refresh()
        Me.cmbSubCategoryofService.Refresh()

        blnInfoChanges = False
    End Sub

    Private Sub dgvBeneficiaries_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBeneficiaries.CellDoubleClick
        FieldsEnabled(True)

        blnAddEdit = True
        intRow = e.RowIndex

        GetBeneficiaryData()

        If bankName = "" And branchCode = "" Then
            MsgBox("There is no bank stored for this beneficiary - please add a bank.", vbInformation)
        End If
    End Sub

    Private Sub btnSoek_Click(sender As System.Object, e As System.EventArgs) Handles btnSoek.Click
        FieldsEnabled(False)
        blnSoek = True

        populateGrid()
        blnSoek = False

    End Sub


    Private Sub txtBeneficiary_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBeneficiary.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtAccountNr_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAccountNr.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub cmbAccountType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbAccountType.SelectedIndexChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtBank_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBank.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtBranchCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBranchCode.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtBankCodes_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBankCodes.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtFax_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFax.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtEmail_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtEmail.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub cmbPayeeId_Leave(sender As Object, e As System.EventArgs) Handles cmbPayeeId.Leave

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
            If blnAddEdit = True Then
                Me.cmbCategoryofService.Text = ""
                Me.cmbSubCategoryofService.Text = ""
                Me.cmbSpecialityofService.Text = ""
            End If
        End If

        If blnInfoChanges = True And blnClaimPaymentBeneficiary = True Then
            frmClaimsPayments.cmbPayeeId.SelectedIndex = -1
            frmClaimsPayments.cmbPayeeId.Text = Me.cmbPayeeId.Text
        End If
    End Sub

    Private Sub cmbCategoryofService_Leave(sender As Object, e As System.EventArgs) Handles cmbCategoryofService.Leave

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
            If blnAddEdit = True Then
                Me.cmbSubCategoryofService.Text = ""
                Me.cmbSpecialityofService.Text = ""
            End If
        End If
        If blnInfoChanges = True And blnClaimPaymentBeneficiary = True Then
            frmClaimsPayments.cmbCategoryofService.SelectedIndex = -1
            frmClaimsPayments.cmbCategoryofService.Text = Me.cmbCategoryofService.Text
        End If
    End Sub

    Private Sub cmbSubCategoryofService_Leave(sender As Object, e As System.EventArgs) Handles cmbSubCategoryofService.Leave

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
            If blnAddEdit = True Then
                Me.cmbSpecialityofService.Text = ""
            End If
        End If
        If blnInfoChanges = True And blnClaimPaymentBeneficiary = True Then
            frmClaimsPayments.cmbSubCategoryofService.SelectedIndex = -1
            frmClaimsPayments.cmbSubCategoryofService.Text = Me.cmbSubCategoryofService.Text
        End If
    End Sub

    Private Sub cmbSpecialityofService_Leave(sender As Object, e As System.EventArgs) Handles cmbSpecialityofService.Leave

    End Sub

    Private Sub cmbSpecialityofService_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbSpecialityofService.SelectedIndexChanged
        blnInfoChanges = True
        If blnInfoChanges = True And blnClaimPaymentBeneficiary = True Then
            frmClaimsPayments.cmbSpecialityofService.SelectedIndex = -1
            frmClaimsPayments.cmbSpecialityofService.Text = Me.cmbSpecialityofService.Text
        End If
    End Sub

    Private Sub GetAllPaymentsBeneficiary()
        dgvPaymentToBeneficiary.AutoGenerateColumns = False
        dgvPaymentToBeneficiary.DataSource = Nothing
        dgvPaymentToBeneficiary.Refresh()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim paramsClaims() As SqlParameter = {New SqlParameter("@TjekBesonderhede", SqlDbType.NVarChar)}
                paramsClaims(0).Value = strBeneficiary

                Dim readerClaims As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchPaymentsTjekBesonderhede", paramsClaims)

                Dim PaymentList As List(Of ClaimsPaymentEntity) = New List(Of ClaimsPaymentEntity)

                Do While readerClaims.Read
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
                        item.Tjekdatum = readerClaims("tjekdatum")
                        item.strTjekdatum = readerClaims("tjekdatum")
                    Else
                        item.Tjekdatum = Nothing
                        item.strTjekdatum = Nothing
                    End If
                    If readerClaims("Tjekbesonderhede") IsNot DBNull.Value Then
                        item.Tjekbesonderhede = readerClaims("Tjekbesonderhede")
                    Else
                        item.Tjekbesonderhede = ""
                    End If
                    If readerClaims("Tjekno") IsNot DBNull.Value Then
                        item.Tjekno = readerClaims("Tjekno")
                    Else
                        item.Tjekno = ""
                    End If
                    If readerClaims("Tjekno_uit") IsNot DBNull.Value Then
                        item.Tjekno_uit = readerClaims("Tjekno_uit")
                    Else
                        item.Tjekno_uit = ""
                    End If
                    If readerClaims("Faktuurnr") IsNot DBNull.Value Then
                        item.Faktuurnr = readerClaims("Faktuurnr")
                    Else
                        item.Faktuurnr = ""
                    End If
                    If readerClaims("Vord_premie") IsNot DBNull.Value Then
                        item.Vord_premie = readerClaims("Vord_premie")
                    Else
                        item.Vord_premie = 0
                    End If
                    If readerClaims("Tipe") IsNot DBNull.Value Then
                        item.Tipe = readerClaims("Tipe")
                    Else
                        item.Tipe = ""
                    End If
                    If readerClaims("Gekans") IsNot DBNull.Value Then
                        item.Gekans = readerClaims("Gekans")
                    End If
                    If readerClaims("Nedlopie") IsNot DBNull.Value Then
                        item.Nedlopie = readerClaims("Nedlopie")
                    End If
                    If item.Gekans <> True Then
                        If item.Tipe = "EL" Then
                            If item.Nedlopie <> False Then
                                PaymentList.Add(item)
                            End If
                        Else
                            PaymentList.Add(item)
                        End If
                    End If
                Loop

                dgvPaymentToBeneficiary.DataSource = PaymentList

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    readerClaims.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub dgvBeneficiaries_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBeneficiaries.CellContentClick

    End Sub

    Private Sub cmdSearchAssessor_Click(sender As System.Object, e As System.EventArgs) Handles cmdSearchAssessor.Click
        blnfkAssessor = True
        frmClaimsAssessors.Show()
    End Sub

    Private Sub txtSearchAssessor_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchAssessor.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub dgvPaymentToBeneficiary_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPaymentToBeneficiary.CellContentClick

    End Sub

    Private Sub txtSearchBeneficiary_Leave(sender As Object, e As System.EventArgs) Handles txtSearchBeneficiary.Leave
        Me.btnSoek.Focus()
    End Sub

    
End Class