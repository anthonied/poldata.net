<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClaimsBeneficiary
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClaimsBeneficiary))
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnVoegby = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvBeneficiaries = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtBeneficiary = New System.Windows.Forms.TextBox()
        Me.txtAccountNr = New System.Windows.Forms.TextBox()
        Me.txtBranchCode = New System.Windows.Forms.TextBox()
        Me.txtBank = New System.Windows.Forms.TextBox()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.cmbPayeeId = New System.Windows.Forms.ComboBox()
        Me.cmbCategoryofService = New System.Windows.Forms.ComboBox()
        Me.cmbSubCategoryofService = New System.Windows.Forms.ComboBox()
        Me.cmbSpecialityofService = New System.Windows.Forms.ComboBox()
        Me.cmbAccountType = New System.Windows.Forms.ComboBox()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnBanke = New System.Windows.Forms.Button()
        Me.txtBankCodes = New System.Windows.Forms.TextBox()
        Me.txtSearchBeneficiary = New System.Windows.Forms.TextBox()
        Me.btnSoek = New System.Windows.Forms.Button()
        Me.dgvPaymentToBeneficiary = New System.Windows.Forms.DataGridView()
        Me.pkPayment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.strTjekDatum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tjekno_uit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.faktuurnr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vord_premie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.polisno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.eisno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtSearchAssessor = New System.Windows.Forms.TextBox()
        Me.cmdSearchAssessor = New System.Windows.Forms.Button()
        Me.Beneficiary = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountNr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bank = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PayeeIdentification = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategoryOfService = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pkBegunstigde = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvBeneficiaries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPaymentToBeneficiary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.SystemColors.Control
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEdit.Location = New System.Drawing.Point(829, 22)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnEdit.Size = New System.Drawing.Size(67, 22)
        Me.btnEdit.TabIndex = 4
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnVoegby
        '
        Me.btnVoegby.BackColor = System.Drawing.SystemColors.Control
        Me.btnVoegby.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnVoegby.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoegby.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnVoegby.Location = New System.Drawing.Point(759, 22)
        Me.btnVoegby.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnVoegby.Name = "btnVoegby"
        Me.btnVoegby.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnVoegby.Size = New System.Drawing.Size(67, 22)
        Me.btnVoegby.TabIndex = 3
        Me.btnVoegby.Text = "Add"
        Me.btnVoegby.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(820, 582)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(77, 25)
        Me.btnCancel.TabIndex = 18
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 14)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Beneficiaries"
        '
        'dgvBeneficiaries
        '
        Me.dgvBeneficiaries.AllowUserToAddRows = False
        Me.dgvBeneficiaries.AllowUserToDeleteRows = False
        Me.dgvBeneficiaries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBeneficiaries.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Beneficiary, Me.AccountNr, Me.Bank, Me.Fax, Me.Email, Me.PayeeIdentification, Me.CategoryOfService, Me.pkBegunstigde})
        Me.dgvBeneficiaries.Location = New System.Drawing.Point(23, 50)
        Me.dgvBeneficiaries.Name = "dgvBeneficiaries"
        Me.dgvBeneficiaries.ReadOnly = True
        Me.dgvBeneficiaries.RowHeadersWidth = 10
        Me.dgvBeneficiaries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBeneficiaries.Size = New System.Drawing.Size(873, 160)
        Me.dgvBeneficiaries.TabIndex = 126
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 225)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 14)
        Me.Label2.TabIndex = 131
        Me.Label2.Text = "Beneficiary"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 249)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 14)
        Me.Label3.TabIndex = 132
        Me.Label3.Text = "Account no"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 299)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 14)
        Me.Label4.TabIndex = 133
        Me.Label4.Text = "Bank"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 274)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 14)
        Me.Label5.TabIndex = 134
        Me.Label5.Text = "Account Type"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 323)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 14)
        Me.Label6.TabIndex = 135
        Me.Label6.Text = "Branch Code"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(477, 249)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 14)
        Me.Label7.TabIndex = 136
        Me.Label7.Text = "Payee Identification"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(477, 274)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 14)
        Me.Label8.TabIndex = 137
        Me.Label8.Text = "Category of Service"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(477, 299)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(126, 14)
        Me.Label9.TabIndex = 138
        Me.Label9.Text = "Sub Category of Service"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(477, 323)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(149, 14)
        Me.Label10.TabIndex = 139
        Me.Label10.Text = "Speciality of Service Provider"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(28, 347)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(25, 14)
        Me.Label11.TabIndex = 140
        Me.Label11.Text = "Fax"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(28, 371)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 14)
        Me.Label12.TabIndex = 141
        Me.Label12.Text = "Email"
        '
        'txtBeneficiary
        '
        Me.txtBeneficiary.Location = New System.Drawing.Point(120, 222)
        Me.txtBeneficiary.MaxLength = 100
        Me.txtBeneficiary.Name = "txtBeneficiary"
        Me.txtBeneficiary.Size = New System.Drawing.Size(284, 20)
        Me.txtBeneficiary.TabIndex = 5
        '
        'txtAccountNr
        '
        Me.txtAccountNr.Location = New System.Drawing.Point(120, 246)
        Me.txtAccountNr.MaxLength = 30
        Me.txtAccountNr.Name = "txtAccountNr"
        Me.txtAccountNr.Size = New System.Drawing.Size(196, 20)
        Me.txtAccountNr.TabIndex = 6
        '
        'txtBranchCode
        '
        Me.txtBranchCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtBranchCode.Location = New System.Drawing.Point(120, 320)
        Me.txtBranchCode.MaxLength = 8
        Me.txtBranchCode.Name = "txtBranchCode"
        Me.txtBranchCode.ReadOnly = True
        Me.txtBranchCode.Size = New System.Drawing.Size(86, 20)
        Me.txtBranchCode.TabIndex = 145
        '
        'txtBank
        '
        Me.txtBank.BackColor = System.Drawing.SystemColors.Window
        Me.txtBank.Location = New System.Drawing.Point(120, 296)
        Me.txtBank.MaxLength = 100
        Me.txtBank.Name = "txtBank"
        Me.txtBank.ReadOnly = True
        Me.txtBank.Size = New System.Drawing.Size(196, 20)
        Me.txtBank.TabIndex = 146
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(120, 344)
        Me.txtFax.MaxLength = 40
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(196, 20)
        Me.txtFax.TabIndex = 9
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(120, 368)
        Me.txtEmail.MaxLength = 40
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(284, 20)
        Me.txtEmail.TabIndex = 10
        '
        'cmbPayeeId
        '
        Me.cmbPayeeId.FormattingEnabled = True
        Me.cmbPayeeId.Location = New System.Drawing.Point(639, 245)
        Me.cmbPayeeId.Name = "cmbPayeeId"
        Me.cmbPayeeId.Size = New System.Drawing.Size(257, 22)
        Me.cmbPayeeId.TabIndex = 12
        '
        'cmbCategoryofService
        '
        Me.cmbCategoryofService.FormattingEnabled = True
        Me.cmbCategoryofService.Location = New System.Drawing.Point(639, 270)
        Me.cmbCategoryofService.Name = "cmbCategoryofService"
        Me.cmbCategoryofService.Size = New System.Drawing.Size(257, 22)
        Me.cmbCategoryofService.TabIndex = 13
        '
        'cmbSubCategoryofService
        '
        Me.cmbSubCategoryofService.FormattingEnabled = True
        Me.cmbSubCategoryofService.Location = New System.Drawing.Point(639, 295)
        Me.cmbSubCategoryofService.Name = "cmbSubCategoryofService"
        Me.cmbSubCategoryofService.Size = New System.Drawing.Size(257, 22)
        Me.cmbSubCategoryofService.TabIndex = 14
        '
        'cmbSpecialityofService
        '
        Me.cmbSpecialityofService.FormattingEnabled = True
        Me.cmbSpecialityofService.Location = New System.Drawing.Point(639, 319)
        Me.cmbSpecialityofService.Name = "cmbSpecialityofService"
        Me.cmbSpecialityofService.Size = New System.Drawing.Size(257, 22)
        Me.cmbSpecialityofService.TabIndex = 15
        '
        'cmbAccountType
        '
        Me.cmbAccountType.FormattingEnabled = True
        Me.cmbAccountType.Location = New System.Drawing.Point(120, 270)
        Me.cmbAccountType.Name = "cmbAccountType"
        Me.cmbAccountType.Size = New System.Drawing.Size(195, 22)
        Me.cmbAccountType.TabIndex = 7
        '
        'btnApply
        '
        Me.btnApply.BackColor = System.Drawing.SystemColors.Control
        Me.btnApply.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnApply.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnApply.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApply.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnApply.Location = New System.Drawing.Point(739, 582)
        Me.btnApply.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnApply.Size = New System.Drawing.Size(77, 25)
        Me.btnApply.TabIndex = 17
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOK.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOK.Location = New System.Drawing.Point(658, 582)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOK.Size = New System.Drawing.Size(77, 25)
        Me.btnOK.TabIndex = 16
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnBanke
        '
        Me.btnBanke.BackColor = System.Drawing.SystemColors.Control
        Me.btnBanke.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnBanke.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBanke.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBanke.Location = New System.Drawing.Point(221, 319)
        Me.btnBanke.Name = "btnBanke"
        Me.btnBanke.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnBanke.Size = New System.Drawing.Size(67, 22)
        Me.btnBanke.TabIndex = 8
        Me.btnBanke.Text = "Banks ..."
        Me.btnBanke.UseVisualStyleBackColor = False
        '
        'txtBankCodes
        '
        Me.txtBankCodes.Location = New System.Drawing.Point(299, 320)
        Me.txtBankCodes.Name = "txtBankCodes"
        Me.txtBankCodes.Size = New System.Drawing.Size(82, 20)
        Me.txtBankCodes.TabIndex = 157
        Me.txtBankCodes.Visible = False
        '
        'txtSearchBeneficiary
        '
        Me.txtSearchBeneficiary.Location = New System.Drawing.Point(480, 24)
        Me.txtSearchBeneficiary.Name = "txtSearchBeneficiary"
        Me.txtSearchBeneficiary.Size = New System.Drawing.Size(225, 20)
        Me.txtSearchBeneficiary.TabIndex = 1
        '
        'btnSoek
        '
        Me.btnSoek.BackgroundImage = CType(resources.GetObject("btnSoek.BackgroundImage"), System.Drawing.Image)
        Me.btnSoek.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSoek.Location = New System.Drawing.Point(711, 24)
        Me.btnSoek.Name = "btnSoek"
        Me.btnSoek.Size = New System.Drawing.Size(20, 20)
        Me.btnSoek.TabIndex = 2
        Me.btnSoek.TabStop = False
        Me.btnSoek.UseVisualStyleBackColor = True
        '
        'dgvPaymentToBeneficiary
        '
        Me.dgvPaymentToBeneficiary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPaymentToBeneficiary.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pkPayment, Me.strTjekDatum, Me.Tjekno_uit, Me.faktuurnr, Me.vord_premie, Me.polisno, Me.eisno})
        Me.dgvPaymentToBeneficiary.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvPaymentToBeneficiary.Location = New System.Drawing.Point(6, 21)
        Me.dgvPaymentToBeneficiary.Name = "dgvPaymentToBeneficiary"
        Me.dgvPaymentToBeneficiary.RowHeadersWidth = 10
        Me.dgvPaymentToBeneficiary.Size = New System.Drawing.Size(644, 153)
        Me.dgvPaymentToBeneficiary.TabIndex = 158
        '
        'pkPayment
        '
        Me.pkPayment.DataPropertyName = "pkPayment"
        Me.pkPayment.HeaderText = "pkPayment"
        Me.pkPayment.Name = "pkPayment"
        Me.pkPayment.Visible = False
        '
        'strTjekDatum
        '
        Me.strTjekDatum.DataPropertyName = "strTjekDatum"
        Me.strTjekDatum.HeaderText = "Payment Date"
        Me.strTjekDatum.Name = "strTjekDatum"
        Me.strTjekDatum.Width = 130
        '
        'Tjekno_uit
        '
        Me.Tjekno_uit.DataPropertyName = "Tjekno_uit"
        Me.Tjekno_uit.HeaderText = "Reference No"
        Me.Tjekno_uit.Name = "Tjekno_uit"
        '
        'faktuurnr
        '
        Me.faktuurnr.DataPropertyName = "faktuurnr"
        Me.faktuurnr.HeaderText = "Invoice No"
        Me.faktuurnr.Name = "faktuurnr"
        '
        'vord_premie
        '
        Me.vord_premie.DataPropertyName = "vord_premie"
        Me.vord_premie.HeaderText = "Amount"
        Me.vord_premie.Name = "vord_premie"
        Me.vord_premie.Width = 80
        '
        'polisno
        '
        Me.polisno.DataPropertyName = "polisno"
        Me.polisno.HeaderText = "Policynumber"
        Me.polisno.Name = "polisno"
        '
        'eisno
        '
        Me.eisno.DataPropertyName = "eisno"
        Me.eisno.HeaderText = "Claimnumber"
        Me.eisno.Name = "eisno"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvPaymentToBeneficiary)
        Me.GroupBox1.Location = New System.Drawing.Point(31, 399)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(658, 180)
        Me.GroupBox1.TabIndex = 159
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "All Payments to Beneficiary"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(477, 225)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 14)
        Me.Label13.TabIndex = 160
        Me.Label13.Text = "Assessor"
        '
        'txtSearchAssessor
        '
        Me.txtSearchAssessor.Location = New System.Drawing.Point(638, 222)
        Me.txtSearchAssessor.Name = "txtSearchAssessor"
        Me.txtSearchAssessor.Size = New System.Drawing.Size(188, 20)
        Me.txtSearchAssessor.TabIndex = 161
        '
        'cmdSearchAssessor
        '
        Me.cmdSearchAssessor.Location = New System.Drawing.Point(829, 221)
        Me.cmdSearchAssessor.Name = "cmdSearchAssessor"
        Me.cmdSearchAssessor.Size = New System.Drawing.Size(67, 22)
        Me.cmdSearchAssessor.TabIndex = 162
        Me.cmdSearchAssessor.Text = "Search"
        Me.cmdSearchAssessor.UseVisualStyleBackColor = True
        '
        'Beneficiary
        '
        Me.Beneficiary.DataPropertyName = "Begunstigde"
        Me.Beneficiary.HeaderText = "Beneficiary"
        Me.Beneficiary.Name = "Beneficiary"
        Me.Beneficiary.ReadOnly = True
        Me.Beneficiary.Width = 150
        '
        'AccountNr
        '
        Me.AccountNr.DataPropertyName = "Bankrekno"
        Me.AccountNr.HeaderText = "Account No"
        Me.AccountNr.Name = "AccountNr"
        Me.AccountNr.ReadOnly = True
        '
        'Bank
        '
        Me.Bank.DataPropertyName = "bank"
        Me.Bank.HeaderText = "Bank"
        Me.Bank.Name = "Bank"
        Me.Bank.ReadOnly = True
        '
        'Fax
        '
        Me.Fax.DataPropertyName = "faks"
        Me.Fax.HeaderText = "Fax"
        Me.Fax.Name = "Fax"
        Me.Fax.ReadOnly = True
        '
        'Email
        '
        Me.Email.DataPropertyName = "email"
        Me.Email.HeaderText = "Email"
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        Me.Email.Width = 150
        '
        'PayeeIdentification
        '
        Me.PayeeIdentification.DataPropertyName = "PayeeIdentification"
        Me.PayeeIdentification.HeaderText = "Payee Identification"
        Me.PayeeIdentification.Name = "PayeeIdentification"
        Me.PayeeIdentification.ReadOnly = True
        Me.PayeeIdentification.Width = 150
        '
        'CategoryOfService
        '
        Me.CategoryOfService.DataPropertyName = "CategoryOfService"
        Me.CategoryOfService.HeaderText = "Category Of Service"
        Me.CategoryOfService.Name = "CategoryOfService"
        Me.CategoryOfService.ReadOnly = True
        Me.CategoryOfService.Width = 150
        '
        'pkBegunstigde
        '
        Me.pkBegunstigde.HeaderText = "pkBegunstigde"
        Me.pkBegunstigde.Name = "pkBegunstigde"
        Me.pkBegunstigde.ReadOnly = True
        Me.pkBegunstigde.Visible = False
        '
        'frmClaimsBeneficiary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(908, 619)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdSearchAssessor)
        Me.Controls.Add(Me.txtSearchAssessor)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSoek)
        Me.Controls.Add(Me.txtSearchBeneficiary)
        Me.Controls.Add(Me.txtBankCodes)
        Me.Controls.Add(Me.btnBanke)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cmbAccountType)
        Me.Controls.Add(Me.cmbSpecialityofService)
        Me.Controls.Add(Me.cmbSubCategoryofService)
        Me.Controls.Add(Me.cmbCategoryofService)
        Me.Controls.Add(Me.cmbPayeeId)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtFax)
        Me.Controls.Add(Me.txtBank)
        Me.Controls.Add(Me.txtBranchCode)
        Me.Controls.Add(Me.txtAccountNr)
        Me.Controls.Add(Me.txtBeneficiary)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnVoegby)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvBeneficiaries)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmClaimsBeneficiary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Beneficiaries"
        CType(Me.dgvBeneficiaries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPaymentToBeneficiary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents btnEdit As System.Windows.Forms.Button
    Public WithEvents btnVoegby As System.Windows.Forms.Button
    Public WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvBeneficiaries As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtBeneficiary As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountNr As System.Windows.Forms.TextBox
    Friend WithEvents txtBranchCode As System.Windows.Forms.TextBox
    Friend WithEvents txtBank As System.Windows.Forms.TextBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents cmbPayeeId As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCategoryofService As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSubCategoryofService As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSpecialityofService As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAccountType As System.Windows.Forms.ComboBox
    Public WithEvents btnApply As System.Windows.Forms.Button
    Public WithEvents btnOK As System.Windows.Forms.Button
    Public WithEvents btnBanke As System.Windows.Forms.Button
    Friend WithEvents txtBankCodes As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchBeneficiary As System.Windows.Forms.TextBox
    Friend WithEvents btnSoek As System.Windows.Forms.Button
    Friend WithEvents dgvPaymentToBeneficiary As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSearchAssessor As System.Windows.Forms.TextBox
    Friend WithEvents cmdSearchAssessor As System.Windows.Forms.Button
    Friend WithEvents pkPayment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents strTjekDatum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tjekno_uit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktuurnr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vord_premie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents polisno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents eisno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Beneficiary As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountNr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bank As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Email As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PayeeIdentification As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CategoryOfService As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pkBegunstigde As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
