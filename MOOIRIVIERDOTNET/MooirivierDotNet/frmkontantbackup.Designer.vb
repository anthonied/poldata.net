<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKontantBackup
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
        Me.GrpBxTransTypes = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdGetTransactions = New System.Windows.Forms.Button()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.optOutstandingTransactions = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.optAllTransactions = New System.Windows.Forms.RadioButton()
        Me.GrpBxPayRegister = New System.Windows.Forms.GroupBox()
        Me.dtpChequeDate = New System.Windows.Forms.DateTimePicker()
        Me.cmdRegisterPayment = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtChequeInfo = New System.Windows.Forms.TextBox()
        Me.txtChequenr = New System.Windows.Forms.TextBox()
        Me.txtReceiptnr = New System.Windows.Forms.TextBox()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.txtCashMemo = New System.Windows.Forms.TextBox()
        Me.optElectronic = New System.Windows.Forms.RadioButton()
        Me.optCash = New System.Windows.Forms.RadioButton()
        Me.optCheque = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GrpBxMethods = New System.Windows.Forms.GroupBox()
        Me.optMonthlyElectronic = New System.Windows.Forms.RadioButton()
        Me.optMonthlyCash = New System.Windows.Forms.RadioButton()
        Me.optMonthlyDebit = New System.Windows.Forms.RadioButton()
        Me.optMonthlySalary = New System.Windows.Forms.RadioButton()
        Me.optPaybackPayment = New System.Windows.Forms.RadioButton()
        Me.optPrepaidPayment = New System.Windows.Forms.RadioButton()
        Me.optFirstPayment = New System.Windows.Forms.RadioButton()
        Me.optVT = New System.Windows.Forms.RadioButton()
        Me.cmdTermPolicyEarned = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.optTermAlteration = New System.Windows.Forms.RadioButton()
        Me.optRenewal = New System.Windows.Forms.RadioButton()
        Me.optNewTermPolicy = New System.Windows.Forms.RadioButton()
        Me.optTermPolicy = New System.Windows.Forms.RadioButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Tipe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Afsluit_dat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Premie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vord_premie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kwitansie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vord_Dat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.trans_dat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KontantTipe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdPrintReceipt = New System.Windows.Forms.Button()
        Me.cmdCancelPayment = New System.Windows.Forms.Button()
        Me.GrpBVT = New System.Windows.Forms.GroupBox()
        Me.GrpBxPayTypes = New System.Windows.Forms.GroupBox()
        Me.GrpBxTermMain = New System.Windows.Forms.GroupBox()
        Me.GrpBxTerm = New System.Windows.Forms.GroupBox()
        Me.GrpBxTransTypes.SuspendLayout()
        Me.GrpBxPayRegister.SuspendLayout()
        Me.GrpBxMethods.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpBVT.SuspendLayout()
        Me.GrpBxPayTypes.SuspendLayout()
        Me.GrpBxTermMain.SuspendLayout()
        Me.GrpBxTerm.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpBxTransTypes
        '
        Me.GrpBxTransTypes.Controls.Add(Me.Label1)
        Me.GrpBxTransTypes.Controls.Add(Me.cmdGetTransactions)
        Me.GrpBxTransTypes.Controls.Add(Me.dtpFrom)
        Me.GrpBxTransTypes.Controls.Add(Me.optOutstandingTransactions)
        Me.GrpBxTransTypes.Controls.Add(Me.Label2)
        Me.GrpBxTransTypes.Controls.Add(Me.dtpToDate)
        Me.GrpBxTransTypes.Controls.Add(Me.optAllTransactions)
        Me.GrpBxTransTypes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpBxTransTypes.Location = New System.Drawing.Point(17, 4)
        Me.GrpBxTransTypes.Name = "GrpBxTransTypes"
        Me.GrpBxTransTypes.Size = New System.Drawing.Size(737, 37)
        Me.GrpBxTransTypes.TabIndex = 0
        Me.GrpBxTransTypes.TabStop = False
        Me.GrpBxTransTypes.Text = "Transactions all types"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(287, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From"
        '
        'cmdGetTransactions
        '
        Me.cmdGetTransactions.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGetTransactions.Location = New System.Drawing.Point(629, 8)
        Me.cmdGetTransactions.Name = "cmdGetTransactions"
        Me.cmdGetTransactions.Size = New System.Drawing.Size(102, 25)
        Me.cmdGetTransactions.TabIndex = 10
        Me.cmdGetTransactions.Text = "Get Transactions"
        Me.cmdGetTransactions.UseVisualStyleBackColor = True
        '
        'dtpFrom
        '
        Me.dtpFrom.Enabled = False
        Me.dtpFrom.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Location = New System.Drawing.Point(324, 14)
        Me.dtpFrom.MaxDate = New Date(2030, 12, 31, 0, 0, 0, 0)
        Me.dtpFrom.MinDate = New Date(1982, 1, 1, 0, 0, 0, 0)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(121, 20)
        Me.dtpFrom.TabIndex = 1
        '
        'optOutstandingTransactions
        '
        Me.optOutstandingTransactions.AutoSize = True
        Me.optOutstandingTransactions.Location = New System.Drawing.Point(132, 15)
        Me.optOutstandingTransactions.Name = "optOutstandingTransactions"
        Me.optOutstandingTransactions.Size = New System.Drawing.Size(146, 18)
        Me.optOutstandingTransactions.TabIndex = 1
        Me.optOutstandingTransactions.TabStop = True
        Me.optOutstandingTransactions.Text = "Outstanding transactions"
        Me.optOutstandingTransactions.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(453, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "To"
        '
        'dtpToDate
        '
        Me.dtpToDate.Enabled = False
        Me.dtpToDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Location = New System.Drawing.Point(479, 14)
        Me.dtpToDate.MaxDate = New Date(2030, 12, 31, 0, 0, 0, 0)
        Me.dtpToDate.MinDate = New Date(1982, 1, 1, 0, 0, 0, 0)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(121, 20)
        Me.dtpToDate.TabIndex = 4
        '
        'optAllTransactions
        '
        Me.optAllTransactions.AutoSize = True
        Me.optAllTransactions.Checked = True
        Me.optAllTransactions.Location = New System.Drawing.Point(6, 15)
        Me.optAllTransactions.Name = "optAllTransactions"
        Me.optAllTransactions.Size = New System.Drawing.Size(103, 18)
        Me.optAllTransactions.TabIndex = 0
        Me.optAllTransactions.TabStop = True
        Me.optAllTransactions.Text = "All Transactions"
        Me.optAllTransactions.UseVisualStyleBackColor = True
        '
        'GrpBxPayRegister
        '
        Me.GrpBxPayRegister.Controls.Add(Me.dtpChequeDate)
        Me.GrpBxPayRegister.Controls.Add(Me.cmdRegisterPayment)
        Me.GrpBxPayRegister.Controls.Add(Me.Label10)
        Me.GrpBxPayRegister.Controls.Add(Me.txtChequeInfo)
        Me.GrpBxPayRegister.Controls.Add(Me.txtChequenr)
        Me.GrpBxPayRegister.Controls.Add(Me.txtReceiptnr)
        Me.GrpBxPayRegister.Controls.Add(Me.txtAmount)
        Me.GrpBxPayRegister.Controls.Add(Me.txtCashMemo)
        Me.GrpBxPayRegister.Controls.Add(Me.optElectronic)
        Me.GrpBxPayRegister.Controls.Add(Me.optCash)
        Me.GrpBxPayRegister.Controls.Add(Me.optCheque)
        Me.GrpBxPayRegister.Controls.Add(Me.Label9)
        Me.GrpBxPayRegister.Controls.Add(Me.Label8)
        Me.GrpBxPayRegister.Controls.Add(Me.Label7)
        Me.GrpBxPayRegister.Controls.Add(Me.Label6)
        Me.GrpBxPayRegister.Controls.Add(Me.Label5)
        Me.GrpBxPayRegister.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpBxPayRegister.Location = New System.Drawing.Point(414, 47)
        Me.GrpBxPayRegister.Name = "GrpBxPayRegister"
        Me.GrpBxPayRegister.Size = New System.Drawing.Size(343, 266)
        Me.GrpBxPayRegister.TabIndex = 8
        Me.GrpBxPayRegister.TabStop = False
        Me.GrpBxPayRegister.Text = "Payment Registration"
        '
        'dtpChequeDate
        '
        Me.dtpChequeDate.Location = New System.Drawing.Point(94, 157)
        Me.dtpChequeDate.Name = "dtpChequeDate"
        Me.dtpChequeDate.Size = New System.Drawing.Size(123, 20)
        Me.dtpChequeDate.TabIndex = 16
        '
        'cmdRegisterPayment
        '
        Me.cmdRegisterPayment.Location = New System.Drawing.Point(232, 237)
        Me.cmdRegisterPayment.Name = "cmdRegisterPayment"
        Me.cmdRegisterPayment.Size = New System.Drawing.Size(105, 23)
        Me.cmdRegisterPayment.TabIndex = 15
        Me.cmdRegisterPayment.Text = "Register Payment"
        Me.cmdRegisterPayment.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 108)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 14)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Memo"
        '
        'txtChequeInfo
        '
        Me.txtChequeInfo.Location = New System.Drawing.Point(94, 183)
        Me.txtChequeInfo.Name = "txtChequeInfo"
        Me.txtChequeInfo.Size = New System.Drawing.Size(243, 20)
        Me.txtChequeInfo.TabIndex = 13
        '
        'txtChequenr
        '
        Me.txtChequenr.Location = New System.Drawing.Point(94, 131)
        Me.txtChequenr.Name = "txtChequenr"
        Me.txtChequenr.Size = New System.Drawing.Size(123, 20)
        Me.txtChequenr.TabIndex = 11
        '
        'txtReceiptnr
        '
        Me.txtReceiptnr.Location = New System.Drawing.Point(94, 79)
        Me.txtReceiptnr.Name = "txtReceiptnr"
        Me.txtReceiptnr.Size = New System.Drawing.Size(119, 20)
        Me.txtReceiptnr.TabIndex = 10
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(94, 53)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(119, 20)
        Me.txtAmount.TabIndex = 9
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCashMemo
        '
        Me.txtCashMemo.Location = New System.Drawing.Point(94, 105)
        Me.txtCashMemo.Name = "txtCashMemo"
        Me.txtCashMemo.Size = New System.Drawing.Size(243, 20)
        Me.txtCashMemo.TabIndex = 8
        '
        'optElectronic
        '
        Me.optElectronic.AutoSize = True
        Me.optElectronic.Location = New System.Drawing.Point(247, 24)
        Me.optElectronic.Name = "optElectronic"
        Me.optElectronic.Size = New System.Drawing.Size(72, 18)
        Me.optElectronic.TabIndex = 7
        Me.optElectronic.TabStop = True
        Me.optElectronic.Text = "Electronic"
        Me.optElectronic.UseVisualStyleBackColor = True
        '
        'optCash
        '
        Me.optCash.AutoSize = True
        Me.optCash.Location = New System.Drawing.Point(138, 24)
        Me.optCash.Name = "optCash"
        Me.optCash.Size = New System.Drawing.Size(50, 18)
        Me.optCash.TabIndex = 6
        Me.optCash.TabStop = True
        Me.optCash.Text = "Cash"
        Me.optCash.UseVisualStyleBackColor = True
        '
        'optCheque
        '
        Me.optCheque.AutoSize = True
        Me.optCheque.Location = New System.Drawing.Point(12, 24)
        Me.optCheque.Name = "optCheque"
        Me.optCheque.Size = New System.Drawing.Size(62, 18)
        Me.optCheque.TabIndex = 5
        Me.optCheque.TabStop = True
        Me.optCheque.Text = "Cheque"
        Me.optCheque.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 186)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 14)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Cheque info"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 160)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 14)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Cheque date"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 134)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 14)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Cheque nr"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 14)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Receipt book nr"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 14)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Amount"
        '
        'GrpBxMethods
        '
        Me.GrpBxMethods.Controls.Add(Me.optMonthlyElectronic)
        Me.GrpBxMethods.Controls.Add(Me.optMonthlyCash)
        Me.GrpBxMethods.Controls.Add(Me.optMonthlyDebit)
        Me.GrpBxMethods.Controls.Add(Me.optMonthlySalary)
        Me.GrpBxMethods.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpBxMethods.Location = New System.Drawing.Point(17, 47)
        Me.GrpBxMethods.Name = "GrpBxMethods"
        Me.GrpBxMethods.Size = New System.Drawing.Size(167, 113)
        Me.GrpBxMethods.TabIndex = 11
        Me.GrpBxMethods.TabStop = False
        Me.GrpBxMethods.Text = "Payment Methods"
        '
        'optMonthlyElectronic
        '
        Me.optMonthlyElectronic.AutoSize = True
        Me.optMonthlyElectronic.Location = New System.Drawing.Point(5, 85)
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
        Me.optMonthlyCash.Location = New System.Drawing.Point(6, 19)
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
        Me.optMonthlyDebit.Location = New System.Drawing.Point(5, 41)
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
        Me.optMonthlySalary.Enabled = False
        Me.optMonthlySalary.Location = New System.Drawing.Point(5, 63)
        Me.optMonthlySalary.Name = "optMonthlySalary"
        Me.optMonthlySalary.Size = New System.Drawing.Size(122, 18)
        Me.optMonthlySalary.TabIndex = 2
        Me.optMonthlySalary.TabStop = True
        Me.optMonthlySalary.Text = "Monthly Salary (MS)"
        Me.optMonthlySalary.UseVisualStyleBackColor = True
        '
        'optPaybackPayment
        '
        Me.optPaybackPayment.AutoSize = True
        Me.optPaybackPayment.Location = New System.Drawing.Point(5, 63)
        Me.optPaybackPayment.Name = "optPaybackPayment"
        Me.optPaybackPayment.Size = New System.Drawing.Size(134, 17)
        Me.optPaybackPayment.TabIndex = 8
        Me.optPaybackPayment.TabStop = True
        Me.optPaybackPayment.Text = "Payback Payment (TB)"
        Me.optPaybackPayment.UseVisualStyleBackColor = True
        '
        'optPrepaidPayment
        '
        Me.optPrepaidPayment.AutoSize = True
        Me.optPrepaidPayment.Location = New System.Drawing.Point(5, 41)
        Me.optPrepaidPayment.Name = "optPrepaidPayment"
        Me.optPrepaidPayment.Size = New System.Drawing.Size(127, 17)
        Me.optPrepaidPayment.TabIndex = 7
        Me.optPrepaidPayment.TabStop = True
        Me.optPrepaidPayment.Text = "Prepaid payment (VB)"
        Me.optPrepaidPayment.UseVisualStyleBackColor = True
        '
        'optFirstPayment
        '
        Me.optFirstPayment.AutoSize = True
        Me.optFirstPayment.Location = New System.Drawing.Point(5, 19)
        Me.optFirstPayment.Name = "optFirstPayment"
        Me.optFirstPayment.Size = New System.Drawing.Size(111, 17)
        Me.optFirstPayment.TabIndex = 6
        Me.optFirstPayment.TabStop = True
        Me.optFirstPayment.Text = "First Payment (EB)"
        Me.optFirstPayment.UseVisualStyleBackColor = True
        '
        'optVT
        '
        Me.optVT.AutoSize = True
        Me.optVT.Location = New System.Drawing.Point(6, 15)
        Me.optVT.Name = "optVT"
        Me.optVT.Size = New System.Drawing.Size(62, 17)
        Me.optVT.TabIndex = 3
        Me.optVT.TabStop = True
        Me.optVT.Text = "VT (VT)"
        Me.optVT.UseVisualStyleBackColor = True
        '
        'cmdTermPolicyEarned
        '
        Me.cmdTermPolicyEarned.Location = New System.Drawing.Point(18, 145)
        Me.cmdTermPolicyEarned.Name = "cmdTermPolicyEarned"
        Me.cmdTermPolicyEarned.Size = New System.Drawing.Size(158, 26)
        Me.cmdTermPolicyEarned.TabIndex = 9
        Me.cmdTermPolicyEarned.Text = "Term Policy earned amounts"
        Me.cmdTermPolicyEarned.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Location = New System.Drawing.Point(90, 106)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(86, 14)
        Me.lblStatus.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(15, 107)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "Status"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 90)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Timeframe"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 71)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Months Left"
        '
        'optTermAlteration
        '
        Me.optTermAlteration.AutoSize = True
        Me.optTermAlteration.Location = New System.Drawing.Point(18, 50)
        Me.optTermAlteration.Name = "optTermAlteration"
        Me.optTermAlteration.Size = New System.Drawing.Size(69, 17)
        Me.optTermAlteration.TabIndex = 2
        Me.optTermAlteration.TabStop = True
        Me.optTermAlteration.Text = "Alteration"
        Me.optTermAlteration.UseVisualStyleBackColor = True
        '
        'optRenewal
        '
        Me.optRenewal.AutoSize = True
        Me.optRenewal.Location = New System.Drawing.Point(18, 31)
        Me.optRenewal.Name = "optRenewal"
        Me.optRenewal.Size = New System.Drawing.Size(67, 17)
        Me.optRenewal.TabIndex = 1
        Me.optRenewal.TabStop = True
        Me.optRenewal.Text = "Renewal"
        Me.optRenewal.UseVisualStyleBackColor = True
        '
        'optNewTermPolicy
        '
        Me.optNewTermPolicy.AutoSize = True
        Me.optNewTermPolicy.Location = New System.Drawing.Point(18, 12)
        Me.optNewTermPolicy.Name = "optNewTermPolicy"
        Me.optNewTermPolicy.Size = New System.Drawing.Size(105, 17)
        Me.optNewTermPolicy.TabIndex = 0
        Me.optNewTermPolicy.TabStop = True
        Me.optNewTermPolicy.Text = "New Term Policy"
        Me.optNewTermPolicy.UseVisualStyleBackColor = True
        '
        'optTermPolicy
        '
        Me.optTermPolicy.AutoSize = True
        Me.optTermPolicy.Location = New System.Drawing.Point(6, 19)
        Me.optTermPolicy.Name = "optTermPolicy"
        Me.optTermPolicy.Size = New System.Drawing.Size(102, 17)
        Me.optTermPolicy.TabIndex = 4
        Me.optTermPolicy.TabStop = True
        Me.optTermPolicy.Text = "Term Policy (LT)"
        Me.optTermPolicy.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tipe, Me.Afsluit_dat, Me.Premie, Me.vord_premie, Me.Kwitansie, Me.Vord_Dat, Me.trans_dat, Me.KontantTipe})
        Me.DataGridView1.Location = New System.Drawing.Point(20, 323)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(731, 172)
        Me.DataGridView1.TabIndex = 12
        '
        'Tipe
        '
        Me.Tipe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Tipe.DataPropertyName = "tipe"
        Me.Tipe.HeaderText = "Tipe"
        Me.Tipe.MinimumWidth = 45
        Me.Tipe.Name = "Tipe"
        Me.Tipe.Width = 45
        '
        'Afsluit_dat
        '
        Me.Afsluit_dat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Afsluit_dat.DataPropertyName = "Afsluit_dat"
        Me.Afsluit_dat.HeaderText = "Date"
        Me.Afsluit_dat.MinimumWidth = 90
        Me.Afsluit_dat.Name = "Afsluit_dat"
        Me.Afsluit_dat.Width = 90
        '
        'Premie
        '
        Me.Premie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Premie.DataPropertyName = "Premie"
        Me.Premie.HeaderText = "Amount"
        Me.Premie.MinimumWidth = 90
        Me.Premie.Name = "Premie"
        Me.Premie.Width = 90
        '
        'vord_premie
        '
        Me.vord_premie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.vord_premie.DataPropertyName = "vord_premie"
        Me.vord_premie.HeaderText = "Amount Paid"
        Me.vord_premie.MinimumWidth = 90
        Me.vord_premie.Name = "vord_premie"
        Me.vord_premie.Width = 90
        '
        'Kwitansie
        '
        Me.Kwitansie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Kwitansie.DataPropertyName = "kwitansie"
        Me.Kwitansie.HeaderText = "Receipt/Cheque nr"
        Me.Kwitansie.Name = "Kwitansie"
        '
        'Vord_Dat
        '
        Me.Vord_Dat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Vord_Dat.DataPropertyName = "vord_dat"
        Me.Vord_Dat.HeaderText = "Payment_Date"
        Me.Vord_Dat.Name = "Vord_Dat"
        '
        'trans_dat
        '
        Me.trans_dat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.trans_dat.DataPropertyName = "trans_dat"
        Me.trans_dat.HeaderText = "Transaction Date"
        Me.trans_dat.Name = "trans_dat"
        '
        'KontantTipe
        '
        Me.KontantTipe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.KontantTipe.DataPropertyName = "kontant_tipe"
        Me.KontantTipe.HeaderText = "Cheque/Cash/Electronic"
        Me.KontantTipe.Name = "KontantTipe"
        Me.KontantTipe.Width = 45
        '
        'cmdPrintReceipt
        '
        Me.cmdPrintReceipt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrintReceipt.Location = New System.Drawing.Point(661, 501)
        Me.cmdPrintReceipt.Name = "cmdPrintReceipt"
        Me.cmdPrintReceipt.Size = New System.Drawing.Size(93, 26)
        Me.cmdPrintReceipt.TabIndex = 13
        Me.cmdPrintReceipt.Text = "Print Receipt"
        Me.cmdPrintReceipt.UseVisualStyleBackColor = True
        '
        'cmdCancelPayment
        '
        Me.cmdCancelPayment.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelPayment.Location = New System.Drawing.Point(562, 501)
        Me.cmdCancelPayment.Name = "cmdCancelPayment"
        Me.cmdCancelPayment.Size = New System.Drawing.Size(93, 26)
        Me.cmdCancelPayment.TabIndex = 14
        Me.cmdCancelPayment.Text = "Cancel Payment"
        Me.cmdCancelPayment.UseVisualStyleBackColor = True
        '
        'GrpBVT
        '
        Me.GrpBVT.Controls.Add(Me.optVT)
        Me.GrpBVT.Location = New System.Drawing.Point(17, 166)
        Me.GrpBVT.Name = "GrpBVT"
        Me.GrpBVT.Size = New System.Drawing.Size(167, 34)
        Me.GrpBVT.TabIndex = 10
        Me.GrpBVT.TabStop = False
        Me.GrpBVT.Text = "Refer to drawer"
        '
        'GrpBxPayTypes
        '
        Me.GrpBxPayTypes.Controls.Add(Me.optFirstPayment)
        Me.GrpBxPayTypes.Controls.Add(Me.optPrepaidPayment)
        Me.GrpBxPayTypes.Controls.Add(Me.optPaybackPayment)
        Me.GrpBxPayTypes.Location = New System.Drawing.Point(17, 207)
        Me.GrpBxPayTypes.Name = "GrpBxPayTypes"
        Me.GrpBxPayTypes.Size = New System.Drawing.Size(167, 88)
        Me.GrpBxPayTypes.TabIndex = 10
        Me.GrpBxPayTypes.TabStop = False
        Me.GrpBxPayTypes.Text = "Payment Types"
        '
        'GrpBxTermMain
        '
        Me.GrpBxTermMain.Controls.Add(Me.GrpBxTerm)
        Me.GrpBxTermMain.Controls.Add(Me.optTermPolicy)
        Me.GrpBxTermMain.Location = New System.Drawing.Point(196, 47)
        Me.GrpBxTermMain.Name = "GrpBxTermMain"
        Me.GrpBxTermMain.Size = New System.Drawing.Size(200, 248)
        Me.GrpBxTermMain.TabIndex = 16
        Me.GrpBxTermMain.TabStop = False
        Me.GrpBxTermMain.Text = "Term Policy"
        '
        'GrpBxTerm
        '
        Me.GrpBxTerm.Controls.Add(Me.cmdTermPolicyEarned)
        Me.GrpBxTerm.Controls.Add(Me.Label11)
        Me.GrpBxTerm.Controls.Add(Me.Label12)
        Me.GrpBxTerm.Controls.Add(Me.lblStatus)
        Me.GrpBxTerm.Controls.Add(Me.optTermAlteration)
        Me.GrpBxTerm.Controls.Add(Me.optNewTermPolicy)
        Me.GrpBxTerm.Controls.Add(Me.optRenewal)
        Me.GrpBxTerm.Controls.Add(Me.Label13)
        Me.GrpBxTerm.Location = New System.Drawing.Point(12, 41)
        Me.GrpBxTerm.Name = "GrpBxTerm"
        Me.GrpBxTerm.Size = New System.Drawing.Size(182, 199)
        Me.GrpBxTerm.TabIndex = 10
        Me.GrpBxTerm.TabStop = False
        '
        'frmKontant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(769, 534)
        Me.Controls.Add(Me.GrpBxTermMain)
        Me.Controls.Add(Me.GrpBxPayTypes)
        Me.Controls.Add(Me.GrpBVT)
        Me.Controls.Add(Me.cmdCancelPayment)
        Me.Controls.Add(Me.cmdPrintReceipt)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GrpBxMethods)
        Me.Controls.Add(Me.GrpBxPayRegister)
        Me.Controls.Add(Me.GrpBxTransTypes)
        Me.Name = "frmKontant"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Income / Payments / Queries"
        Me.GrpBxTransTypes.ResumeLayout(False)
        Me.GrpBxTransTypes.PerformLayout()
        Me.GrpBxPayRegister.ResumeLayout(False)
        Me.GrpBxPayRegister.PerformLayout()
        Me.GrpBxMethods.ResumeLayout(False)
        Me.GrpBxMethods.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpBVT.ResumeLayout(False)
        Me.GrpBVT.PerformLayout()
        Me.GrpBxPayTypes.ResumeLayout(False)
        Me.GrpBxPayTypes.PerformLayout()
        Me.GrpBxTermMain.ResumeLayout(False)
        Me.GrpBxTermMain.PerformLayout()
        Me.GrpBxTerm.ResumeLayout(False)
        Me.GrpBxTerm.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpBxTransTypes As System.Windows.Forms.GroupBox
    Friend WithEvents GrpBxPayRegister As System.Windows.Forms.GroupBox
    Friend WithEvents optCheque As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtChequeInfo As System.Windows.Forms.TextBox
    Friend WithEvents txtChequenr As System.Windows.Forms.TextBox
    Friend WithEvents txtReceiptnr As System.Windows.Forms.TextBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtCashMemo As System.Windows.Forms.TextBox
    Friend WithEvents optElectronic As System.Windows.Forms.RadioButton
    Friend WithEvents optCash As System.Windows.Forms.RadioButton
    Friend WithEvents cmdRegisterPayment As System.Windows.Forms.Button
    Friend WithEvents cmdGetTransactions As System.Windows.Forms.Button
    Friend WithEvents GrpBxMethods As System.Windows.Forms.GroupBox
    Friend WithEvents optTermAlteration As System.Windows.Forms.RadioButton
    Friend WithEvents optRenewal As System.Windows.Forms.RadioButton
    Friend WithEvents optNewTermPolicy As System.Windows.Forms.RadioButton
    Friend WithEvents optTermPolicy As System.Windows.Forms.RadioButton
    Friend WithEvents optVT As System.Windows.Forms.RadioButton
    Friend WithEvents optMonthlySalary As System.Windows.Forms.RadioButton
    Friend WithEvents optMonthlyDebit As System.Windows.Forms.RadioButton
    Friend WithEvents optMonthlyCash As System.Windows.Forms.RadioButton
    Friend WithEvents optPaybackPayment As System.Windows.Forms.RadioButton
    Friend WithEvents optPrepaidPayment As System.Windows.Forms.RadioButton
    Friend WithEvents optFirstPayment As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cmdPrintReceipt As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdTermPolicyEarned As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdCancelPayment As System.Windows.Forms.Button
    Friend WithEvents dtpChequeDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents optMonthlyElectronic As System.Windows.Forms.RadioButton
    Friend WithEvents Tipe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Afsluit_dat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Premie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vord_premie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kwitansie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vord_Dat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents trans_dat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KontantTipe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents optAllTransactions As System.Windows.Forms.RadioButton
    Friend WithEvents optOutstandingTransactions As System.Windows.Forms.RadioButton
    Friend WithEvents GrpBVT As System.Windows.Forms.GroupBox
    Friend WithEvents GrpBxPayTypes As System.Windows.Forms.GroupBox
    Friend WithEvents GrpBxTermMain As System.Windows.Forms.GroupBox
    Friend WithEvents GrpBxTerm As System.Windows.Forms.GroupBox


End Class
