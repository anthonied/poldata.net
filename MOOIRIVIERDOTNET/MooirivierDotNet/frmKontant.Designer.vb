<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKontant
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GrpBxTransTypes = New System.Windows.Forms.GroupBox()
        Me.lblPaymenttype = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.optOutstandingTransactions = New System.Windows.Forms.RadioButton()
        Me.optAllTransactions = New System.Windows.Forms.RadioButton()
        Me.GrpBxMethods = New System.Windows.Forms.GroupBox()
        Me.optPaybackPayment = New System.Windows.Forms.RadioButton()
        Me.optTermPolicy = New System.Windows.Forms.RadioButton()
        Me.optPrepaidPayment = New System.Windows.Forms.RadioButton()
        Me.optFirstPayment = New System.Windows.Forms.RadioButton()
        Me.optVT = New System.Windows.Forms.RadioButton()
        Me.optMonthlyElectronic = New System.Windows.Forms.RadioButton()
        Me.optMonthlyCash = New System.Windows.Forms.RadioButton()
        Me.optMonthlyDebit = New System.Windows.Forms.RadioButton()
        Me.optMonthlySalary = New System.Windows.Forms.RadioButton()
        Me.dgvMonetereTransaksies = New System.Windows.Forms.DataGridView()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnRegisterPayment = New System.Windows.Forms.Button()
        Me.tctrlTransaksies = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnCancelPayment = New System.Windows.Forms.Button()
        Me.btnEditPayment = New System.Windows.Forms.Button()
        Me.tpageTermPolicy = New System.Windows.Forms.TabPage()
        Me.cmbTermPeriods = New System.Windows.Forms.ComboBox()
        Me.LblTermynPeriodes = New System.Windows.Forms.Label()
        Me.grpTermTypes = New System.Windows.Forms.GroupBox()
        Me.optTermAlteration = New System.Windows.Forms.RadioButton()
        Me.optNewTermPolicy = New System.Windows.Forms.RadioButton()
        Me.optRenewal = New System.Windows.Forms.RadioButton()
        Me.dgrTermynPolisse = New System.Windows.Forms.DataGridView()
        Me.TranDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tranType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tranPayment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tranPremRaised = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tranBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tranMonthsLeft = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdTermPolicyEarned = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TransYear = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransMonth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Afsluit_dat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Premie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vord_premie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kwitansie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vord_Dat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.trans_dat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KontantTipe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaymentDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Memoall = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.memo1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.memo2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.memo3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.memo4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.memo5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pk_waarde = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GrpBxTransTypes.SuspendLayout()
        Me.GrpBxMethods.SuspendLayout()
        CType(Me.dgvMonetereTransaksies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tctrlTransaksies.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.tpageTermPolicy.SuspendLayout()
        Me.grpTermTypes.SuspendLayout()
        CType(Me.dgrTermynPolisse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpBxTransTypes
        '
        Me.GrpBxTransTypes.Controls.Add(Me.lblPaymenttype)
        Me.GrpBxTransTypes.Controls.Add(Me.Label3)
        Me.GrpBxTransTypes.Controls.Add(Me.Label1)
        Me.GrpBxTransTypes.Controls.Add(Me.dtpFrom)
        Me.GrpBxTransTypes.Controls.Add(Me.Label2)
        Me.GrpBxTransTypes.Controls.Add(Me.dtpToDate)
        Me.GrpBxTransTypes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpBxTransTypes.Location = New System.Drawing.Point(7, 3)
        Me.GrpBxTransTypes.Name = "GrpBxTransTypes"
        Me.GrpBxTransTypes.Size = New System.Drawing.Size(482, 37)
        Me.GrpBxTransTypes.TabIndex = 0
        Me.GrpBxTransTypes.TabStop = False
        '
        'lblPaymenttype
        '
        Me.lblPaymenttype.Location = New System.Drawing.Point(368, 9)
        Me.lblPaymenttype.Name = "lblPaymenttype"
        Me.lblPaymenttype.Size = New System.Drawing.Size(106, 22)
        Me.lblPaymenttype.TabIndex = 12
        Me.lblPaymenttype.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(288, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 14)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Payment type:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From"
        '
        'dtpFrom
        '
        Me.dtpFrom.Enabled = False
        Me.dtpFrom.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(37, 10)
        Me.dtpFrom.MaxDate = New Date(2030, 12, 31, 0, 0, 0, 0)
        Me.dtpFrom.MinDate = New Date(1982, 1, 1, 0, 0, 0, 0)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(91, 20)
        Me.dtpFrom.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(150, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "To"
        '
        'dtpToDate
        '
        Me.dtpToDate.Enabled = False
        Me.dtpToDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpToDate.Location = New System.Drawing.Point(174, 10)
        Me.dtpToDate.MaxDate = New Date(2030, 12, 31, 0, 0, 0, 0)
        Me.dtpToDate.MinDate = New Date(1982, 1, 1, 0, 0, 0, 0)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(94, 20)
        Me.dtpToDate.TabIndex = 4
        '
        'optOutstandingTransactions
        '
        Me.optOutstandingTransactions.AutoSize = True
        Me.optOutstandingTransactions.Location = New System.Drawing.Point(6, 39)
        Me.optOutstandingTransactions.Name = "optOutstandingTransactions"
        Me.optOutstandingTransactions.Size = New System.Drawing.Size(149, 18)
        Me.optOutstandingTransactions.TabIndex = 1
        Me.optOutstandingTransactions.TabStop = True
        Me.optOutstandingTransactions.Text = "Outstanding Transactions"
        Me.optOutstandingTransactions.UseVisualStyleBackColor = True
        '
        'optAllTransactions
        '
        Me.optAllTransactions.AutoSize = True
        Me.optAllTransactions.Checked = True
        Me.optAllTransactions.Location = New System.Drawing.Point(6, 19)
        Me.optAllTransactions.Name = "optAllTransactions"
        Me.optAllTransactions.Size = New System.Drawing.Size(103, 18)
        Me.optAllTransactions.TabIndex = 0
        Me.optAllTransactions.TabStop = True
        Me.optAllTransactions.Text = "All Transactions"
        Me.optAllTransactions.UseVisualStyleBackColor = True
        '
        'GrpBxMethods
        '
        Me.GrpBxMethods.Controls.Add(Me.optPaybackPayment)
        Me.GrpBxMethods.Controls.Add(Me.optTermPolicy)
        Me.GrpBxMethods.Controls.Add(Me.optOutstandingTransactions)
        Me.GrpBxMethods.Controls.Add(Me.optPrepaidPayment)
        Me.GrpBxMethods.Controls.Add(Me.optAllTransactions)
        Me.GrpBxMethods.Controls.Add(Me.optFirstPayment)
        Me.GrpBxMethods.Controls.Add(Me.optVT)
        Me.GrpBxMethods.Controls.Add(Me.optMonthlyElectronic)
        Me.GrpBxMethods.Controls.Add(Me.optMonthlyCash)
        Me.GrpBxMethods.Controls.Add(Me.optMonthlyDebit)
        Me.GrpBxMethods.Controls.Add(Me.optMonthlySalary)
        Me.GrpBxMethods.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpBxMethods.Location = New System.Drawing.Point(3, 39)
        Me.GrpBxMethods.Name = "GrpBxMethods"
        Me.GrpBxMethods.Size = New System.Drawing.Size(730, 84)
        Me.GrpBxMethods.TabIndex = 11
        Me.GrpBxMethods.TabStop = False
        '
        'optPaybackPayment
        '
        Me.optPaybackPayment.AutoSize = True
        Me.optPaybackPayment.Location = New System.Drawing.Point(559, 39)
        Me.optPaybackPayment.Name = "optPaybackPayment"
        Me.optPaybackPayment.Size = New System.Drawing.Size(84, 18)
        Me.optPaybackPayment.TabIndex = 8
        Me.optPaybackPayment.TabStop = True
        Me.optPaybackPayment.Text = "Refund (TB)"
        Me.optPaybackPayment.UseVisualStyleBackColor = True
        '
        'optTermPolicy
        '
        Me.optTermPolicy.AutoSize = True
        Me.optTermPolicy.Location = New System.Drawing.Point(447, 39)
        Me.optTermPolicy.Name = "optTermPolicy"
        Me.optTermPolicy.Size = New System.Drawing.Size(101, 18)
        Me.optTermPolicy.TabIndex = 4
        Me.optTermPolicy.TabStop = True
        Me.optTermPolicy.Text = "Term Policy (LT)"
        Me.optTermPolicy.UseVisualStyleBackColor = True
        '
        'optPrepaidPayment
        '
        Me.optPrepaidPayment.AutoSize = True
        Me.optPrepaidPayment.Location = New System.Drawing.Point(559, 19)
        Me.optPrepaidPayment.Name = "optPrepaidPayment"
        Me.optPrepaidPayment.Size = New System.Drawing.Size(139, 18)
        Me.optPrepaidPayment.TabIndex = 7
        Me.optPrepaidPayment.TabStop = True
        Me.optPrepaidPayment.Text = "Advance Payment (VB)"
        Me.optPrepaidPayment.UseVisualStyleBackColor = True
        '
        'optFirstPayment
        '
        Me.optFirstPayment.AutoSize = True
        Me.optFirstPayment.Location = New System.Drawing.Point(559, 60)
        Me.optFirstPayment.Name = "optFirstPayment"
        Me.optFirstPayment.Size = New System.Drawing.Size(156, 18)
        Me.optFirstPayment.TabIndex = 6
        Me.optFirstPayment.TabStop = True
        Me.optFirstPayment.Text = "First/Pro-rata Payment (EB)"
        Me.optFirstPayment.UseVisualStyleBackColor = True
        '
        'optVT
        '
        Me.optVT.AutoSize = True
        Me.optVT.Location = New System.Drawing.Point(447, 19)
        Me.optVT.Name = "optVT"
        Me.optVT.Size = New System.Drawing.Size(89, 18)
        Me.optVT.TabIndex = 3
        Me.optVT.TabStop = True
        Me.optVT.Text = "Unpaids (VT)"
        Me.optVT.UseVisualStyleBackColor = True
        '
        'optMonthlyElectronic
        '
        Me.optMonthlyElectronic.AutoSize = True
        Me.optMonthlyElectronic.Location = New System.Drawing.Point(299, 39)
        Me.optMonthlyElectronic.Name = "optMonthlyElectronic"
        Me.optMonthlyElectronic.Size = New System.Drawing.Size(137, 18)
        Me.optMonthlyElectronic.TabIndex = 9
        Me.optMonthlyElectronic.TabStop = True
        Me.optMonthlyElectronic.Text = "Monthly Electronic (ME)"
        Me.optMonthlyElectronic.UseVisualStyleBackColor = True
        '
        'optMonthlyCash
        '
        Me.optMonthlyCash.AutoSize = True
        Me.optMonthlyCash.Location = New System.Drawing.Point(166, 19)
        Me.optMonthlyCash.Name = "optMonthlyCash"
        Me.optMonthlyCash.Size = New System.Drawing.Size(116, 18)
        Me.optMonthlyCash.TabIndex = 0
        Me.optMonthlyCash.TabStop = True
        Me.optMonthlyCash.Text = "Monthly Cash (MK)"
        Me.optMonthlyCash.UseVisualStyleBackColor = True
        '
        'optMonthlyDebit
        '
        Me.optMonthlyDebit.AutoSize = True
        Me.optMonthlyDebit.Location = New System.Drawing.Point(299, 19)
        Me.optMonthlyDebit.Name = "optMonthlyDebit"
        Me.optMonthlyDebit.Size = New System.Drawing.Size(115, 18)
        Me.optMonthlyDebit.TabIndex = 1
        Me.optMonthlyDebit.TabStop = True
        Me.optMonthlyDebit.Text = "Monthly Debit (MD)"
        Me.optMonthlyDebit.UseVisualStyleBackColor = True
        '
        'optMonthlySalary
        '
        Me.optMonthlySalary.AutoSize = True
        Me.optMonthlySalary.Location = New System.Drawing.Point(166, 39)
        Me.optMonthlySalary.Name = "optMonthlySalary"
        Me.optMonthlySalary.Size = New System.Drawing.Size(122, 18)
        Me.optMonthlySalary.TabIndex = 2
        Me.optMonthlySalary.TabStop = True
        Me.optMonthlySalary.Text = "Monthly Salary (MS)"
        Me.optMonthlySalary.UseVisualStyleBackColor = True
        '
        'dgvMonetereTransaksies
        '
        Me.dgvMonetereTransaksies.AllowUserToAddRows = False
        Me.dgvMonetereTransaksies.AllowUserToDeleteRows = False
        Me.dgvMonetereTransaksies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvMonetereTransaksies.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvMonetereTransaksies.ColumnHeadersHeight = 40
        Me.dgvMonetereTransaksies.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TransYear, Me.TransMonth, Me.Tipe, Me.Afsluit_dat, Me.Premie, Me.vord_premie, Me.Kwitansie, Me.Vord_Dat, Me.trans_dat, Me.KontantTipe, Me.PaymentDesc, Me.Memoall, Me.memo1, Me.memo2, Me.memo3, Me.memo4, Me.memo5, Me.pk_waarde, Me.tabel})
        Me.dgvMonetereTransaksies.Location = New System.Drawing.Point(2, 149)
        Me.dgvMonetereTransaksies.MultiSelect = False
        Me.dgvMonetereTransaksies.Name = "dgvMonetereTransaksies"
        Me.dgvMonetereTransaksies.RowHeadersWidth = 5
        Me.dgvMonetereTransaksies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMonetereTransaksies.Size = New System.Drawing.Size(731, 320)
        Me.dgvMonetereTransaksies.TabIndex = 12
        Me.dgvMonetereTransaksies.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(672, 519)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 25)
        Me.btnCancel.TabIndex = 15
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnRegisterPayment
        '
        Me.btnRegisterPayment.Enabled = False
        Me.btnRegisterPayment.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegisterPayment.Location = New System.Drawing.Point(520, 123)
        Me.btnRegisterPayment.Name = "btnRegisterPayment"
        Me.btnRegisterPayment.Size = New System.Drawing.Size(67, 20)
        Me.btnRegisterPayment.TabIndex = 16
        Me.btnRegisterPayment.Text = "Add"
        Me.btnRegisterPayment.UseVisualStyleBackColor = True
        '
        'tctrlTransaksies
        '
        Me.tctrlTransaksies.Controls.Add(Me.TabPage1)
        Me.tctrlTransaksies.Controls.Add(Me.tpageTermPolicy)
        Me.tctrlTransaksies.Location = New System.Drawing.Point(12, 12)
        Me.tctrlTransaksies.Name = "tctrlTransaksies"
        Me.tctrlTransaksies.SelectedIndex = 0
        Me.tctrlTransaksies.Size = New System.Drawing.Size(745, 501)
        Me.tctrlTransaksies.TabIndex = 17
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnCancelPayment)
        Me.TabPage1.Controls.Add(Me.dgvMonetereTransaksies)
        Me.TabPage1.Controls.Add(Me.btnEditPayment)
        Me.TabPage1.Controls.Add(Me.GrpBxMethods)
        Me.TabPage1.Controls.Add(Me.GrpBxTransTypes)
        Me.TabPage1.Controls.Add(Me.btnRegisterPayment)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(737, 475)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Transactions"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnCancelPayment
        '
        Me.btnCancelPayment.Enabled = False
        Me.btnCancelPayment.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelPayment.Location = New System.Drawing.Point(666, 123)
        Me.btnCancelPayment.Name = "btnCancelPayment"
        Me.btnCancelPayment.Size = New System.Drawing.Size(67, 20)
        Me.btnCancelPayment.TabIndex = 17
        Me.btnCancelPayment.Text = "Delete"
        Me.btnCancelPayment.UseVisualStyleBackColor = True
        '
        'btnEditPayment
        '
        Me.btnEditPayment.Enabled = False
        Me.btnEditPayment.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditPayment.Location = New System.Drawing.Point(593, 123)
        Me.btnEditPayment.Name = "btnEditPayment"
        Me.btnEditPayment.Size = New System.Drawing.Size(67, 20)
        Me.btnEditPayment.TabIndex = 18
        Me.btnEditPayment.Text = "Edit"
        Me.btnEditPayment.UseVisualStyleBackColor = True
        '
        'tpageTermPolicy
        '
        Me.tpageTermPolicy.Controls.Add(Me.cmbTermPeriods)
        Me.tpageTermPolicy.Controls.Add(Me.LblTermynPeriodes)
        Me.tpageTermPolicy.Controls.Add(Me.grpTermTypes)
        Me.tpageTermPolicy.Controls.Add(Me.dgrTermynPolisse)
        Me.tpageTermPolicy.Controls.Add(Me.cmdTermPolicyEarned)
        Me.tpageTermPolicy.Controls.Add(Me.Label11)
        Me.tpageTermPolicy.Controls.Add(Me.Label12)
        Me.tpageTermPolicy.Controls.Add(Me.lblStatus)
        Me.tpageTermPolicy.Controls.Add(Me.Label13)
        Me.tpageTermPolicy.Location = New System.Drawing.Point(4, 22)
        Me.tpageTermPolicy.Name = "tpageTermPolicy"
        Me.tpageTermPolicy.Padding = New System.Windows.Forms.Padding(3)
        Me.tpageTermPolicy.Size = New System.Drawing.Size(737, 475)
        Me.tpageTermPolicy.TabIndex = 1
        Me.tpageTermPolicy.Text = "Term Policy"
        Me.tpageTermPolicy.UseVisualStyleBackColor = True
        '
        'cmbTermPeriods
        '
        Me.cmbTermPeriods.FormattingEnabled = True
        Me.cmbTermPeriods.Location = New System.Drawing.Point(112, 5)
        Me.cmbTermPeriods.Name = "cmbTermPeriods"
        Me.cmbTermPeriods.Size = New System.Drawing.Size(361, 21)
        Me.cmbTermPeriods.Sorted = True
        Me.cmbTermPeriods.TabIndex = 21
        '
        'LblTermynPeriodes
        '
        Me.LblTermynPeriodes.AutoSize = True
        Me.LblTermynPeriodes.Location = New System.Drawing.Point(6, 9)
        Me.LblTermynPeriodes.Name = "LblTermynPeriodes"
        Me.LblTermynPeriodes.Size = New System.Drawing.Size(100, 13)
        Me.LblTermynPeriodes.TabIndex = 20
        Me.LblTermynPeriodes.Text = "Term Policy Periods"
        '
        'grpTermTypes
        '
        Me.grpTermTypes.Controls.Add(Me.optTermAlteration)
        Me.grpTermTypes.Controls.Add(Me.optNewTermPolicy)
        Me.grpTermTypes.Controls.Add(Me.optRenewal)
        Me.grpTermTypes.Location = New System.Drawing.Point(6, 28)
        Me.grpTermTypes.Name = "grpTermTypes"
        Me.grpTermTypes.Size = New System.Drawing.Size(276, 35)
        Me.grpTermTypes.TabIndex = 19
        Me.grpTermTypes.TabStop = False
        '
        'optTermAlteration
        '
        Me.optTermAlteration.AutoSize = True
        Me.optTermAlteration.Location = New System.Drawing.Point(201, 12)
        Me.optTermAlteration.Name = "optTermAlteration"
        Me.optTermAlteration.Size = New System.Drawing.Size(69, 17)
        Me.optTermAlteration.TabIndex = 12
        Me.optTermAlteration.Text = "Alteration"
        Me.optTermAlteration.UseVisualStyleBackColor = True
        '
        'optNewTermPolicy
        '
        Me.optNewTermPolicy.AutoSize = True
        Me.optNewTermPolicy.Checked = True
        Me.optNewTermPolicy.Location = New System.Drawing.Point(16, 9)
        Me.optNewTermPolicy.Name = "optNewTermPolicy"
        Me.optNewTermPolicy.Size = New System.Drawing.Size(105, 17)
        Me.optNewTermPolicy.TabIndex = 10
        Me.optNewTermPolicy.TabStop = True
        Me.optNewTermPolicy.Text = "New Term Policy"
        Me.optNewTermPolicy.UseVisualStyleBackColor = True
        '
        'optRenewal
        '
        Me.optRenewal.AutoSize = True
        Me.optRenewal.Location = New System.Drawing.Point(128, 9)
        Me.optRenewal.Name = "optRenewal"
        Me.optRenewal.Size = New System.Drawing.Size(67, 17)
        Me.optRenewal.TabIndex = 11
        Me.optRenewal.Text = "Renewal"
        Me.optRenewal.UseVisualStyleBackColor = True
        '
        'dgrTermynPolisse
        '
        Me.dgrTermynPolisse.ColumnHeadersHeight = 30
        Me.dgrTermynPolisse.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TranDate, Me.tranType, Me.tranPayment, Me.tranPremRaised, Me.tranBalance, Me.tranMonthsLeft})
        Me.dgrTermynPolisse.Location = New System.Drawing.Point(13, 116)
        Me.dgrTermynPolisse.Name = "dgrTermynPolisse"
        Me.dgrTermynPolisse.RowHeadersWidth = 5
        Me.dgrTermynPolisse.Size = New System.Drawing.Size(711, 322)
        Me.dgrTermynPolisse.TabIndex = 18
        '
        'TranDate
        '
        Me.TranDate.HeaderText = "Date"
        Me.TranDate.Name = "TranDate"
        '
        'tranType
        '
        Me.tranType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.tranType.HeaderText = "Type"
        Me.tranType.Name = "tranType"
        '
        'tranPayment
        '
        Me.tranPayment.HeaderText = "Payment"
        Me.tranPayment.Name = "tranPayment"
        '
        'tranPremRaised
        '
        Me.tranPremRaised.HeaderText = "Premium Raised"
        Me.tranPremRaised.Name = "tranPremRaised"
        '
        'tranBalance
        '
        Me.tranBalance.HeaderText = "Balance"
        Me.tranBalance.Name = "tranBalance"
        '
        'tranMonthsLeft
        '
        Me.tranMonthsLeft.HeaderText = "Months Left"
        Me.tranMonthsLeft.Name = "tranMonthsLeft"
        '
        'cmdTermPolicyEarned
        '
        Me.cmdTermPolicyEarned.Location = New System.Drawing.Point(590, 26)
        Me.cmdTermPolicyEarned.Name = "cmdTermPolicyEarned"
        Me.cmdTermPolicyEarned.Size = New System.Drawing.Size(134, 37)
        Me.cmdTermPolicyEarned.TabIndex = 17
        Me.cmdTermPolicyEarned.Text = "Term Policy earned amounts"
        Me.cmdTermPolicyEarned.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(479, 76)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Months Left"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(555, 76)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 13)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Timeframe"
        '
        'lblStatus
        '
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Location = New System.Drawing.Point(575, 89)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(86, 14)
        Me.lblStatus.TabIndex = 16
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(521, 89)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Status"
        '
        'TransYear
        '
        Me.TransYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.TransYear.DataPropertyName = "Jaar"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TransYear.DefaultCellStyle = DataGridViewCellStyle1
        Me.TransYear.HeaderText = "Year"
        Me.TransYear.Name = "TransYear"
        Me.TransYear.Width = 35
        '
        'TransMonth
        '
        Me.TransMonth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.TransMonth.DataPropertyName = "Maand"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TransMonth.DefaultCellStyle = DataGridViewCellStyle2
        Me.TransMonth.HeaderText = "Month"
        Me.TransMonth.Name = "TransMonth"
        Me.TransMonth.Width = 35
        '
        'Tipe
        '
        Me.Tipe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Tipe.DataPropertyName = "tipe"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Tipe.DefaultCellStyle = DataGridViewCellStyle3
        Me.Tipe.HeaderText = "Type"
        Me.Tipe.Name = "Tipe"
        Me.Tipe.Width = 38
        '
        'Afsluit_dat
        '
        Me.Afsluit_dat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Afsluit_dat.DataPropertyName = "Afsluit_dat"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Afsluit_dat.DefaultCellStyle = DataGridViewCellStyle4
        Me.Afsluit_dat.HeaderText = "Date"
        Me.Afsluit_dat.Name = "Afsluit_dat"
        Me.Afsluit_dat.Width = 67
        '
        'Premie
        '
        Me.Premie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Premie.DataPropertyName = "Premie"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Premie.DefaultCellStyle = DataGridViewCellStyle5
        Me.Premie.HeaderText = "Amount Raised"
        Me.Premie.Name = "Premie"
        Me.Premie.Width = 70
        '
        'vord_premie
        '
        Me.vord_premie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.vord_premie.DataPropertyName = "vord_premie"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.vord_premie.DefaultCellStyle = DataGridViewCellStyle6
        Me.vord_premie.HeaderText = "Amount Paid"
        Me.vord_premie.Name = "vord_premie"
        Me.vord_premie.Width = 70
        '
        'Kwitansie
        '
        Me.Kwitansie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Kwitansie.DataPropertyName = "kwitansie"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Kwitansie.DefaultCellStyle = DataGridViewCellStyle7
        Me.Kwitansie.HeaderText = "Receipt/           Unpaid reason"
        Me.Kwitansie.Name = "Kwitansie"
        Me.Kwitansie.Width = 150
        '
        'Vord_Dat
        '
        Me.Vord_Dat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Vord_Dat.DataPropertyName = "vord_dat"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Vord_Dat.DefaultCellStyle = DataGridViewCellStyle8
        Me.Vord_Dat.HeaderText = "Payment Date"
        Me.Vord_Dat.Name = "Vord_Dat"
        Me.Vord_Dat.Width = 67
        '
        'trans_dat
        '
        Me.trans_dat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.trans_dat.DataPropertyName = "trans_dat"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.Format = "G"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.trans_dat.DefaultCellStyle = DataGridViewCellStyle9
        Me.trans_dat.HeaderText = "Transaction Date"
        Me.trans_dat.Name = "trans_dat"
        Me.trans_dat.Width = 115
        '
        'KontantTipe
        '
        Me.KontantTipe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.KontantTipe.DataPropertyName = "kontant_tipe"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.KontantTipe.DefaultCellStyle = DataGridViewCellStyle10
        Me.KontantTipe.HeaderText = "Payment Type"
        Me.KontantTipe.Name = "KontantTipe"
        Me.KontantTipe.Visible = False
        '
        'PaymentDesc
        '
        Me.PaymentDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.PaymentDesc.DataPropertyName = "payment_beskrywing"
        Me.PaymentDesc.HeaderText = "Payment Type"
        Me.PaymentDesc.Name = "PaymentDesc"
        Me.PaymentDesc.Width = 92
        '
        'Memoall
        '
        Me.Memoall.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Memoall.HeaderText = "Memo"
        Me.Memoall.Name = "Memoall"
        Me.Memoall.Width = 300
        '
        'memo1
        '
        Me.memo1.DataPropertyName = "verw1"
        Me.memo1.HeaderText = "memo"
        Me.memo1.Name = "memo1"
        Me.memo1.Visible = False
        Me.memo1.Width = 60
        '
        'memo2
        '
        Me.memo2.DataPropertyName = "verw2"
        Me.memo2.HeaderText = "memo2"
        Me.memo2.Name = "memo2"
        Me.memo2.Visible = False
        Me.memo2.Width = 66
        '
        'memo3
        '
        Me.memo3.DataPropertyName = "verw3"
        Me.memo3.HeaderText = "memo3"
        Me.memo3.Name = "memo3"
        Me.memo3.Visible = False
        Me.memo3.Width = 66
        '
        'memo4
        '
        Me.memo4.DataPropertyName = "verw4"
        Me.memo4.HeaderText = "memo4"
        Me.memo4.Name = "memo4"
        Me.memo4.Visible = False
        Me.memo4.Width = 66
        '
        'memo5
        '
        Me.memo5.DataPropertyName = "verw5"
        Me.memo5.HeaderText = "memo5"
        Me.memo5.Name = "memo5"
        Me.memo5.Visible = False
        Me.memo5.Width = 66
        '
        'pk_waarde
        '
        Me.pk_waarde.DataPropertyName = "pk_waarde"
        Me.pk_waarde.HeaderText = "pk_waarde"
        Me.pk_waarde.Name = "pk_waarde"
        Me.pk_waarde.Visible = False
        Me.pk_waarde.Width = 85
        '
        'tabel
        '
        Me.tabel.DataPropertyName = "Tabel"
        Me.tabel.HeaderText = "tabel"
        Me.tabel.Name = "tabel"
        Me.tabel.Visible = False
        Me.tabel.Width = 55
        '
        'frmKontant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(759, 547)
        Me.ControlBox = False
        Me.Controls.Add(Me.tctrlTransaksies)
        Me.Controls.Add(Me.btnCancel)
        Me.Name = "frmKontant"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Income / Payments "
        Me.GrpBxTransTypes.ResumeLayout(False)
        Me.GrpBxTransTypes.PerformLayout()
        Me.GrpBxMethods.ResumeLayout(False)
        Me.GrpBxMethods.PerformLayout()
        CType(Me.dgvMonetereTransaksies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tctrlTransaksies.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.tpageTermPolicy.ResumeLayout(False)
        Me.tpageTermPolicy.PerformLayout()
        Me.grpTermTypes.ResumeLayout(False)
        Me.grpTermTypes.PerformLayout()
        CType(Me.dgrTermynPolisse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpBxTransTypes As System.Windows.Forms.GroupBox
    Friend WithEvents GrpBxMethods As System.Windows.Forms.GroupBox
    Friend WithEvents optTermPolicy As System.Windows.Forms.RadioButton
    Friend WithEvents optVT As System.Windows.Forms.RadioButton
    Friend WithEvents optMonthlySalary As System.Windows.Forms.RadioButton
    Friend WithEvents optMonthlyDebit As System.Windows.Forms.RadioButton
    Friend WithEvents optMonthlyCash As System.Windows.Forms.RadioButton
    Friend WithEvents optPaybackPayment As System.Windows.Forms.RadioButton
    Friend WithEvents optPrepaidPayment As System.Windows.Forms.RadioButton
    Friend WithEvents optFirstPayment As System.Windows.Forms.RadioButton
    Friend WithEvents dgvMonetereTransaksies As System.Windows.Forms.DataGridView
    Friend WithEvents optMonthlyElectronic As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents optAllTransactions As System.Windows.Forms.RadioButton
    Friend WithEvents optOutstandingTransactions As System.Windows.Forms.RadioButton
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnRegisterPayment As System.Windows.Forms.Button
    Friend WithEvents tctrlTransaksies As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents tpageTermPolicy As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblPaymenttype As System.Windows.Forms.Label
    Friend WithEvents cmdTermPolicyEarned As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents optTermAlteration As System.Windows.Forms.RadioButton
    Friend WithEvents optNewTermPolicy As System.Windows.Forms.RadioButton
    Friend WithEvents optRenewal As System.Windows.Forms.RadioButton
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dgrTermynPolisse As System.Windows.Forms.DataGridView
    Friend WithEvents TranDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tranType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tranPayment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tranPremRaised As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tranBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tranMonthsLeft As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grpTermTypes As System.Windows.Forms.GroupBox
    Friend WithEvents LblTermynPeriodes As System.Windows.Forms.Label
    Friend WithEvents cmbTermPeriods As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancelPayment As System.Windows.Forms.Button
    Friend WithEvents btnEditPayment As System.Windows.Forms.Button
    Friend WithEvents TransYear As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransMonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Afsluit_dat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Premie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vord_premie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kwitansie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vord_Dat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents trans_dat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KontantTipe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Memoall As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents memo1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents memo2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents memo3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents memo4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents memo5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pk_waarde As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tabel As System.Windows.Forms.DataGridViewTextBoxColumn


End Class
