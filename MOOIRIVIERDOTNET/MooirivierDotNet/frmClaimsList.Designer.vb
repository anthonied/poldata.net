<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClaimsList
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvClaims = New System.Windows.Forms.DataGridView()
        Me.Claimnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClaimDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Classification = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubClass = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtExcess = New System.Windows.Forms.TextBox()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnVoegby = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbReinsurer = New System.Windows.Forms.ComboBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ClaimFormsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClaimHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClaimHistoryToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PremiumVsClaimsReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgreementOfLossToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClaimPaymentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeneficiariesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaymentAdvisoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ElectronicPaymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CatastrophesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssessorsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabClaims = New System.Windows.Forms.TabControl()
        Me.tabClaims1 = New System.Windows.Forms.TabPage()
        Me.txtBroker = New System.Windows.Forms.TextBox()
        Me.btnPostalcodes = New System.Windows.Forms.Button()
        Me.cmbClaimSubstatus = New System.Windows.Forms.ComboBox()
        Me.cmbClaimStatus = New System.Windows.Forms.ComboBox()
        Me.lblClaimOutstandingAmount = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblActualClaimAmount = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtPostalCode = New System.Windows.Forms.TextBox()
        Me.txtTown = New System.Windows.Forms.TextBox()
        Me.txtSubburb = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtShortClaimDescription = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbClaimClassType = New System.Windows.Forms.ComboBox()
        Me.cmbClaimType = New System.Windows.Forms.ComboBox()
        Me.txtClaimDescription4 = New System.Windows.Forms.TextBox()
        Me.txtClaimDescription3 = New System.Windows.Forms.TextBox()
        Me.dtpClaimCompletionDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpClaimReportDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpClaimDate = New System.Windows.Forms.DateTimePicker()
        Me.txtClaimAmount = New System.Windows.Forms.TextBox()
        Me.txtClaimnumber = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabClaims2 = New System.Windows.Forms.TabPage()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.lblTotalJournal = New System.Windows.Forms.Label()
        Me.dgvClaimJournals = New System.Windows.Forms.DataGridView()
        Me.JTjekBesonderhede = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TjekofElektronies = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JVord_premie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JVord_dat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CancelledIcon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kruisverwysing = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pkJoernale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnJournalDelete = New System.Windows.Forms.Button()
        Me.btnJournalEdit = New System.Windows.Forms.Button()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.lblTotalIncome = New System.Windows.Forms.Label()
        Me.btnIncomeJournal = New System.Windows.Forms.Button()
        Me.btnIncomeDelete = New System.Windows.Forms.Button()
        Me.btnIncomeEdit = New System.Windows.Forms.Button()
        Me.dgvClaimIncome = New System.Windows.Forms.DataGridView()
        Me.Details = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IncomeDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CancelIcon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvoiceReferenceNr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pkIncome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnIncomeAdd = New System.Windows.Forms.Button()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.lblTotalPayments = New System.Windows.Forms.Label()
        Me.btnPaymentsJournal = New System.Windows.Forms.Button()
        Me.btnPaymentsAdd = New System.Windows.Forms.Button()
        Me.dgvPayments = New System.Windows.Forms.DataGridView()
        Me.TjekBesonderhede = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipePayment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vord_premie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vord_dat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GekansIcon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tjekno_uit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pkPayments = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nedlopie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnPaymentsEdit = New System.Windows.Forms.Button()
        Me.btnPaymentsDelete = New System.Windows.Forms.Button()
        Me.TabClaims3 = New System.Windows.Forms.TabPage()
        Me.btnAssessorAdd = New System.Windows.Forms.Button()
        Me.btnAssessorDelete = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.dgvClaimAssessors = New System.Windows.Forms.DataGridView()
        Me.pkAssessorsperClaim = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AssessorName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabClaims4 = New System.Windows.Forms.TabPage()
        Me.grpExGratia = New System.Windows.Forms.GroupBox()
        Me.optExGratiaNo = New System.Windows.Forms.RadioButton()
        Me.optExgratiaYes = New System.Windows.Forms.RadioButton()
        Me.lstSecurity = New System.Windows.Forms.ListBox()
        Me.dgvClaimEstimate = New System.Windows.Forms.DataGridView()
        Me.ClaimEstimateAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClaimEstimateDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdCatastrophe = New System.Windows.Forms.Button()
        Me.optThunderNo = New System.Windows.Forms.RadioButton()
        Me.optThunderYes = New System.Windows.Forms.RadioButton()
        Me.lblThunder = New System.Windows.Forms.Label()
        Me.lblExGratia = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbCatastrophe = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblSecurity = New System.Windows.Forms.Label()
        Me.grpVehicle = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.optVehiclefoundYes = New System.Windows.Forms.RadioButton()
        Me.optVehicleFoundNo = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.optWriteoffNo = New System.Windows.Forms.RadioButton()
        Me.optWriteoffYes = New System.Windows.Forms.RadioButton()
        Me.lblAlcoholSubstanceAbuse = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optAlcoholYes = New System.Windows.Forms.RadioButton()
        Me.optAlcoholNo = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optKnockNo = New System.Windows.Forms.RadioButton()
        Me.optKnockYes = New System.Windows.Forms.RadioButton()
        Me.txtWhereVehicleFound = New System.Windows.Forms.TextBox()
        Me.txtVehicleUse = New System.Windows.Forms.TextBox()
        Me.txtDamageAmount = New System.Windows.Forms.TextBox()
        Me.txtTypeofCover = New System.Windows.Forms.TextBox()
        Me.txtDriverIDnr = New System.Windows.Forms.TextBox()
        Me.lblWhereVehicleFound = New System.Windows.Forms.Label()
        Me.lblVehicleUse = New System.Windows.Forms.Label()
        Me.lblVehicleFound = New System.Windows.Forms.Label()
        Me.lblTypeofCover = New System.Windows.Forms.Label()
        Me.lblKnockforKnock = New System.Windows.Forms.Label()
        Me.lblDriverIDNr = New System.Windows.Forms.Label()
        Me.lblDamageAmount = New System.Windows.Forms.Label()
        Me.lblVehicleWrittenoff = New System.Windows.Forms.Label()
        Me.grpDogBite = New System.Windows.Forms.GroupBox()
        Me.grpDogAggressive = New System.Windows.Forms.GroupBox()
        Me.optDogAggressiveYes = New System.Windows.Forms.RadioButton()
        Me.optDogAggressiveNo = New System.Windows.Forms.RadioButton()
        Me.grpBittenBefore = New System.Windows.Forms.GroupBox()
        Me.optDogBitBeforeYes = New System.Windows.Forms.RadioButton()
        Me.optDogBitBeforeNo = New System.Windows.Forms.RadioButton()
        Me.txtDogBiteDetails = New System.Windows.Forms.RichTextBox()
        Me.txtDogBiteHistory = New System.Windows.Forms.TextBox()
        Me.lblDogBitesYard = New System.Windows.Forms.Label()
        Me.lblDogBitesAggressive = New System.Windows.Forms.Label()
        Me.lblDogBiteBittenBefore = New System.Windows.Forms.Label()
        Me.lblDogBite = New System.Windows.Forms.Label()
        Me.lblClaimType = New System.Windows.Forms.Label()
        Me.lblDogBitesDescription = New System.Windows.Forms.Label()
        Me.grpPrecautionMeasure = New System.Windows.Forms.GroupBox()
        Me.optDogYardYes = New System.Windows.Forms.RadioButton()
        Me.optDogYardNo = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.optHitandRun = New System.Windows.Forms.RadioButton()
        Me.optDogBite = New System.Windows.Forms.RadioButton()
        Me.lblNumberofClaims = New System.Windows.Forms.Label()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.btnOKClaims = New System.Windows.Forms.Button()
        Me.btnCancelClaim = New System.Windows.Forms.Button()
        CType(Me.dgvClaims, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.tabClaims.SuspendLayout()
        Me.tabClaims1.SuspendLayout()
        Me.tabClaims2.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        CType(Me.dgvClaimJournals, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox10.SuspendLayout()
        CType(Me.dgvClaimIncome, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox9.SuspendLayout()
        CType(Me.dgvPayments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabClaims3.SuspendLayout()
        CType(Me.dgvClaimAssessors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabClaims4.SuspendLayout()
        Me.grpExGratia.SuspendLayout()
        CType(Me.dgvClaimEstimate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpVehicle.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpDogBite.SuspendLayout()
        Me.grpDogAggressive.SuspendLayout()
        Me.grpBittenBefore.SuspendLayout()
        Me.grpPrecautionMeasure.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvClaims
        '
        Me.dgvClaims.AllowUserToDeleteRows = False
        Me.dgvClaims.AllowUserToResizeRows = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvClaims.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvClaims.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvClaims.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClaims.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Claimnumber, Me.ClaimDate, Me.Classification, Me.SubClass, Me.Status, Me.SubStatus, Me.Item})
        Me.dgvClaims.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvClaims.Location = New System.Drawing.Point(17, 78)
        Me.dgvClaims.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgvClaims.Name = "dgvClaims"
        Me.dgvClaims.RowHeadersWidth = 10
        Me.dgvClaims.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvClaims.Size = New System.Drawing.Size(756, 154)
        Me.dgvClaims.TabIndex = 0
        '
        'Claimnumber
        '
        Me.Claimnumber.DataPropertyName = "eisno"
        Me.Claimnumber.HeaderText = "Claim no"
        Me.Claimnumber.Name = "Claimnumber"
        Me.Claimnumber.Width = 80
        '
        'ClaimDate
        '
        Me.ClaimDate.DataPropertyName = "datum"
        Me.ClaimDate.HeaderText = "ClaimDate"
        Me.ClaimDate.Name = "ClaimDate"
        Me.ClaimDate.Width = 80
        '
        'Classification
        '
        Me.Classification.DataPropertyName = "beskrywing"
        Me.Classification.HeaderText = "Class"
        Me.Classification.Name = "Classification"
        Me.Classification.Width = 80
        '
        'SubClass
        '
        Me.SubClass.DataPropertyName = "beskrywing2"
        Me.SubClass.HeaderText = "SubClass"
        Me.SubClass.Name = "SubClass"
        Me.SubClass.Width = 150
        '
        'Status
        '
        Me.Status.DataPropertyName = "ClaimstatusAfr"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.Width = 80
        '
        'SubStatus
        '
        Me.SubStatus.DataPropertyName = "claimsubstatusAfr"
        Me.SubStatus.HeaderText = "Substatus"
        Me.SubStatus.Name = "SubStatus"
        Me.SubStatus.Width = 80
        '
        'Item
        '
        Me.Item.DataPropertyName = "beskrywing3"
        Me.Item.HeaderText = "Item"
        Me.Item.Name = "Item"
        Me.Item.Width = 200
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(384, 143)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 14)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Excess"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 276)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 14)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Reinsurer"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 304)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 14)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Broker"
        '
        'txtExcess
        '
        Me.txtExcess.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExcess.Location = New System.Drawing.Point(546, 140)
        Me.txtExcess.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtExcess.Name = "txtExcess"
        Me.txtExcess.Size = New System.Drawing.Size(196, 20)
        Me.txtExcess.TabIndex = 20
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.SystemColors.Control
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEdit.Location = New System.Drawing.Point(702, 49)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnEdit.Size = New System.Drawing.Size(67, 22)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnVoegby
        '
        Me.btnVoegby.BackColor = System.Drawing.SystemColors.Control
        Me.btnVoegby.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnVoegby.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoegby.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnVoegby.Location = New System.Drawing.Point(631, 49)
        Me.btnVoegby.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnVoegby.Name = "btnVoegby"
        Me.btnVoegby.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnVoegby.Size = New System.Drawing.Size(67, 22)
        Me.btnVoegby.TabIndex = 1
        Me.btnVoegby.Text = "Add"
        Me.btnVoegby.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(16, 40)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 14)
        Me.Label14.TabIndex = 123
        Me.Label14.Text = "Claims"
        '
        'cmbReinsurer
        '
        Me.cmbReinsurer.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbReinsurer.FormattingEnabled = True
        Me.cmbReinsurer.Location = New System.Drawing.Point(169, 272)
        Me.cmbReinsurer.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmbReinsurer.Name = "cmbReinsurer"
        Me.cmbReinsurer.Size = New System.Drawing.Size(205, 22)
        Me.cmbReinsurer.TabIndex = 18
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClaimFormsToolStripMenuItem, Me.ClaimHistoryToolStripMenuItem, Me.ClaimPaymentsToolStripMenuItem, Me.CatastrophesToolStripMenuItem, Me.AssessorsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(781, 24)
        Me.MenuStrip1.TabIndex = 128
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ClaimFormsToolStripMenuItem
        '
        Me.ClaimFormsToolStripMenuItem.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClaimFormsToolStripMenuItem.Name = "ClaimFormsToolStripMenuItem"
        Me.ClaimFormsToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.ClaimFormsToolStripMenuItem.Text = "Claim forms"
        '
        'ClaimHistoryToolStripMenuItem
        '
        Me.ClaimHistoryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClaimHistoryToolStripMenuItem1, Me.PremiumVsClaimsReportToolStripMenuItem, Me.AgreementOfLossToolStripMenuItem})
        Me.ClaimHistoryToolStripMenuItem.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClaimHistoryToolStripMenuItem.Name = "ClaimHistoryToolStripMenuItem"
        Me.ClaimHistoryToolStripMenuItem.Size = New System.Drawing.Size(85, 20)
        Me.ClaimHistoryToolStripMenuItem.Text = "Claim Reports"
        '
        'ClaimHistoryToolStripMenuItem1
        '
        Me.ClaimHistoryToolStripMenuItem1.Name = "ClaimHistoryToolStripMenuItem1"
        Me.ClaimHistoryToolStripMenuItem1.Size = New System.Drawing.Size(198, 22)
        Me.ClaimHistoryToolStripMenuItem1.Text = "Claim History"
        '
        'PremiumVsClaimsReportToolStripMenuItem
        '
        Me.PremiumVsClaimsReportToolStripMenuItem.Name = "PremiumVsClaimsReportToolStripMenuItem"
        Me.PremiumVsClaimsReportToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.PremiumVsClaimsReportToolStripMenuItem.Text = "Premium vs Claims Report"
        '
        'AgreementOfLossToolStripMenuItem
        '
        Me.AgreementOfLossToolStripMenuItem.Name = "AgreementOfLossToolStripMenuItem"
        Me.AgreementOfLossToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.AgreementOfLossToolStripMenuItem.Text = "Agreement of loss"
        '
        'ClaimPaymentsToolStripMenuItem
        '
        Me.ClaimPaymentsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BeneficiariesToolStripMenuItem, Me.PaymentAdvisoryToolStripMenuItem, Me.ElectronicPaymentToolStripMenuItem})
        Me.ClaimPaymentsToolStripMenuItem.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClaimPaymentsToolStripMenuItem.Name = "ClaimPaymentsToolStripMenuItem"
        Me.ClaimPaymentsToolStripMenuItem.Size = New System.Drawing.Size(94, 20)
        Me.ClaimPaymentsToolStripMenuItem.Text = "Claim payments"
        '
        'BeneficiariesToolStripMenuItem
        '
        Me.BeneficiariesToolStripMenuItem.Name = "BeneficiariesToolStripMenuItem"
        Me.BeneficiariesToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.BeneficiariesToolStripMenuItem.Text = "Beneficiaries"
        '
        'PaymentAdvisoryToolStripMenuItem
        '
        Me.PaymentAdvisoryToolStripMenuItem.Name = "PaymentAdvisoryToolStripMenuItem"
        Me.PaymentAdvisoryToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.PaymentAdvisoryToolStripMenuItem.Text = "Payment Advise"
        '
        'ElectronicPaymentToolStripMenuItem
        '
        Me.ElectronicPaymentToolStripMenuItem.Name = "ElectronicPaymentToolStripMenuItem"
        Me.ElectronicPaymentToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ElectronicPaymentToolStripMenuItem.Text = "Electronic Payments"
        '
        'CatastrophesToolStripMenuItem
        '
        Me.CatastrophesToolStripMenuItem.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CatastrophesToolStripMenuItem.Name = "CatastrophesToolStripMenuItem"
        Me.CatastrophesToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
        Me.CatastrophesToolStripMenuItem.Text = "Catastrophes"
        '
        'AssessorsToolStripMenuItem
        '
        Me.AssessorsToolStripMenuItem.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AssessorsToolStripMenuItem.Name = "AssessorsToolStripMenuItem"
        Me.AssessorsToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.AssessorsToolStripMenuItem.Text = "Assessors"
        '
        'tabClaims
        '
        Me.tabClaims.Controls.Add(Me.tabClaims1)
        Me.tabClaims.Controls.Add(Me.tabClaims2)
        Me.tabClaims.Controls.Add(Me.TabClaims3)
        Me.tabClaims.Controls.Add(Me.TabClaims4)
        Me.tabClaims.Location = New System.Drawing.Point(17, 238)
        Me.tabClaims.Name = "tabClaims"
        Me.tabClaims.SelectedIndex = 0
        Me.tabClaims.Size = New System.Drawing.Size(756, 400)
        Me.tabClaims.TabIndex = 137
        '
        'tabClaims1
        '
        Me.tabClaims1.Controls.Add(Me.txtBroker)
        Me.tabClaims1.Controls.Add(Me.btnPostalcodes)
        Me.tabClaims1.Controls.Add(Me.cmbClaimSubstatus)
        Me.tabClaims1.Controls.Add(Me.cmbClaimStatus)
        Me.tabClaims1.Controls.Add(Me.lblClaimOutstandingAmount)
        Me.tabClaims1.Controls.Add(Me.Label19)
        Me.tabClaims1.Controls.Add(Me.lblActualClaimAmount)
        Me.tabClaims1.Controls.Add(Me.Label18)
        Me.tabClaims1.Controls.Add(Me.txtPostalCode)
        Me.tabClaims1.Controls.Add(Me.txtTown)
        Me.tabClaims1.Controls.Add(Me.txtSubburb)
        Me.tabClaims1.Controls.Add(Me.Label16)
        Me.tabClaims1.Controls.Add(Me.txtShortClaimDescription)
        Me.tabClaims1.Controls.Add(Me.Label15)
        Me.tabClaims1.Controls.Add(Me.cmbClaimClassType)
        Me.tabClaims1.Controls.Add(Me.cmbClaimType)
        Me.tabClaims1.Controls.Add(Me.txtClaimDescription4)
        Me.tabClaims1.Controls.Add(Me.Label9)
        Me.tabClaims1.Controls.Add(Me.txtClaimDescription3)
        Me.tabClaims1.Controls.Add(Me.cmbReinsurer)
        Me.tabClaims1.Controls.Add(Me.dtpClaimCompletionDate)
        Me.tabClaims1.Controls.Add(Me.dtpClaimReportDate)
        Me.tabClaims1.Controls.Add(Me.Label10)
        Me.tabClaims1.Controls.Add(Me.dtpClaimDate)
        Me.tabClaims1.Controls.Add(Me.Label5)
        Me.tabClaims1.Controls.Add(Me.txtClaimAmount)
        Me.tabClaims1.Controls.Add(Me.txtExcess)
        Me.tabClaims1.Controls.Add(Me.txtClaimnumber)
        Me.tabClaims1.Controls.Add(Me.Label13)
        Me.tabClaims1.Controls.Add(Me.Label12)
        Me.tabClaims1.Controls.Add(Me.Label8)
        Me.tabClaims1.Controls.Add(Me.Label7)
        Me.tabClaims1.Controls.Add(Me.Label6)
        Me.tabClaims1.Controls.Add(Me.Label4)
        Me.tabClaims1.Controls.Add(Me.Label3)
        Me.tabClaims1.Controls.Add(Me.Label2)
        Me.tabClaims1.Controls.Add(Me.Label1)
        Me.tabClaims1.Location = New System.Drawing.Point(4, 23)
        Me.tabClaims1.Name = "tabClaims1"
        Me.tabClaims1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabClaims1.Size = New System.Drawing.Size(748, 373)
        Me.tabClaims1.TabIndex = 0
        Me.tabClaims1.Text = "General info"
        Me.tabClaims1.UseVisualStyleBackColor = True
        '
        'txtBroker
        '
        Me.txtBroker.Location = New System.Drawing.Point(170, 301)
        Me.txtBroker.Name = "txtBroker"
        Me.txtBroker.ReadOnly = True
        Me.txtBroker.Size = New System.Drawing.Size(205, 20)
        Me.txtBroker.TabIndex = 168
        '
        'btnPostalcodes
        '
        Me.btnPostalcodes.Location = New System.Drawing.Point(285, 247)
        Me.btnPostalcodes.Name = "btnPostalcodes"
        Me.btnPostalcodes.Size = New System.Drawing.Size(88, 20)
        Me.btnPostalcodes.TabIndex = 167
        Me.btnPostalcodes.Text = "Postalcodes"
        Me.btnPostalcodes.UseVisualStyleBackColor = True
        '
        'cmbClaimSubstatus
        '
        Me.cmbClaimSubstatus.FormattingEnabled = True
        Me.cmbClaimSubstatus.Location = New System.Drawing.Point(546, 115)
        Me.cmbClaimSubstatus.Name = "cmbClaimSubstatus"
        Me.cmbClaimSubstatus.Size = New System.Drawing.Size(196, 22)
        Me.cmbClaimSubstatus.TabIndex = 166
        '
        'cmbClaimStatus
        '
        Me.cmbClaimStatus.FormattingEnabled = True
        Me.cmbClaimStatus.Location = New System.Drawing.Point(546, 89)
        Me.cmbClaimStatus.Name = "cmbClaimStatus"
        Me.cmbClaimStatus.Size = New System.Drawing.Size(196, 22)
        Me.cmbClaimStatus.TabIndex = 165
        '
        'lblClaimOutstandingAmount
        '
        Me.lblClaimOutstandingAmount.AutoSize = True
        Me.lblClaimOutstandingAmount.Location = New System.Drawing.Point(384, 319)
        Me.lblClaimOutstandingAmount.Name = "lblClaimOutstandingAmount"
        Me.lblClaimOutstandingAmount.Size = New System.Drawing.Size(0, 14)
        Me.lblClaimOutstandingAmount.TabIndex = 164
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(384, 304)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(316, 14)
        Me.Label19.TabIndex = 163
        Me.Label19.Text = "Claim Outstanding Amount = Claim Amount - Payments - Journals"
        '
        'lblActualClaimAmount
        '
        Me.lblActualClaimAmount.Location = New System.Drawing.Point(384, 237)
        Me.lblActualClaimAmount.Name = "lblActualClaimAmount"
        Me.lblActualClaimAmount.Size = New System.Drawing.Size(354, 51)
        Me.lblActualClaimAmount.TabIndex = 162
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(384, 200)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(354, 40)
        Me.Label18.TabIndex = 161
        Me.Label18.Text = "Actual Claim amount = Total Payments + Excess out - Income(Excess in, Recovery, S" & _
    "alvage, Collections) + Journals"
        '
        'txtPostalCode
        '
        Me.txtPostalCode.Location = New System.Drawing.Point(169, 247)
        Me.txtPostalCode.Name = "txtPostalCode"
        Me.txtPostalCode.ReadOnly = True
        Me.txtPostalCode.Size = New System.Drawing.Size(90, 20)
        Me.txtPostalCode.TabIndex = 11
        '
        'txtTown
        '
        Me.txtTown.Location = New System.Drawing.Point(170, 220)
        Me.txtTown.Name = "txtTown"
        Me.txtTown.ReadOnly = True
        Me.txtTown.Size = New System.Drawing.Size(203, 20)
        Me.txtTown.TabIndex = 160
        '
        'txtSubburb
        '
        Me.txtSubburb.Location = New System.Drawing.Point(169, 193)
        Me.txtSubburb.Name = "txtSubburb"
        Me.txtSubburb.ReadOnly = True
        Me.txtSubburb.Size = New System.Drawing.Size(204, 20)
        Me.txtSubburb.TabIndex = 10
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(7, 196)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(164, 14)
        Me.Label16.TabIndex = 158
        Me.Label16.Text = "Address where Claim took place"
        '
        'txtShortClaimDescription
        '
        Me.txtShortClaimDescription.Location = New System.Drawing.Point(169, 166)
        Me.txtShortClaimDescription.Name = "txtShortClaimDescription"
        Me.txtShortClaimDescription.Size = New System.Drawing.Size(573, 20)
        Me.txtShortClaimDescription.TabIndex = 9
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 169)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(90, 14)
        Me.Label15.TabIndex = 156
        Me.Label15.Text = "Short Description"
        '
        'cmbClaimClassType
        '
        Me.cmbClaimClassType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbClaimClassType.FormattingEnabled = True
        Me.cmbClaimClassType.Location = New System.Drawing.Point(169, 39)
        Me.cmbClaimClassType.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmbClaimClassType.Name = "cmbClaimClassType"
        Me.cmbClaimClassType.Size = New System.Drawing.Size(204, 22)
        Me.cmbClaimClassType.TabIndex = 4
        '
        'cmbClaimType
        '
        Me.cmbClaimType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbClaimType.FormattingEnabled = True
        Me.cmbClaimType.Location = New System.Drawing.Point(169, 65)
        Me.cmbClaimType.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmbClaimType.Name = "cmbClaimType"
        Me.cmbClaimType.Size = New System.Drawing.Size(204, 22)
        Me.cmbClaimType.TabIndex = 5
        '
        'txtClaimDescription4
        '
        Me.txtClaimDescription4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaimDescription4.Location = New System.Drawing.Point(169, 116)
        Me.txtClaimDescription4.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtClaimDescription4.Name = "txtClaimDescription4"
        Me.txtClaimDescription4.ReadOnly = True
        Me.txtClaimDescription4.Size = New System.Drawing.Size(204, 20)
        Me.txtClaimDescription4.TabIndex = 8
        '
        'txtClaimDescription3
        '
        Me.txtClaimDescription3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaimDescription3.Location = New System.Drawing.Point(169, 90)
        Me.txtClaimDescription3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtClaimDescription3.Name = "txtClaimDescription3"
        Me.txtClaimDescription3.ReadOnly = True
        Me.txtClaimDescription3.Size = New System.Drawing.Size(204, 20)
        Me.txtClaimDescription3.TabIndex = 7
        '
        'dtpClaimCompletionDate
        '
        Me.dtpClaimCompletionDate.Checked = False
        Me.dtpClaimCompletionDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpClaimCompletionDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpClaimCompletionDate.Location = New System.Drawing.Point(636, 63)
        Me.dtpClaimCompletionDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpClaimCompletionDate.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.dtpClaimCompletionDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpClaimCompletionDate.Name = "dtpClaimCompletionDate"
        Me.dtpClaimCompletionDate.ShowCheckBox = True
        Me.dtpClaimCompletionDate.Size = New System.Drawing.Size(107, 20)
        Me.dtpClaimCompletionDate.TabIndex = 14
        '
        'dtpClaimReportDate
        '
        Me.dtpClaimReportDate.Checked = False
        Me.dtpClaimReportDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpClaimReportDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpClaimReportDate.Location = New System.Drawing.Point(636, 37)
        Me.dtpClaimReportDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpClaimReportDate.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.dtpClaimReportDate.MinDate = New Date(1982, 1, 1, 0, 0, 0, 0)
        Me.dtpClaimReportDate.Name = "dtpClaimReportDate"
        Me.dtpClaimReportDate.ShowCheckBox = True
        Me.dtpClaimReportDate.Size = New System.Drawing.Size(107, 20)
        Me.dtpClaimReportDate.TabIndex = 13
        '
        'dtpClaimDate
        '
        Me.dtpClaimDate.Checked = False
        Me.dtpClaimDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpClaimDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpClaimDate.Location = New System.Drawing.Point(636, 9)
        Me.dtpClaimDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpClaimDate.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.dtpClaimDate.MinDate = New Date(1982, 1, 1, 0, 0, 0, 0)
        Me.dtpClaimDate.Name = "dtpClaimDate"
        Me.dtpClaimDate.ShowCheckBox = True
        Me.dtpClaimDate.Size = New System.Drawing.Size(107, 20)
        Me.dtpClaimDate.TabIndex = 12
        '
        'txtClaimAmount
        '
        Me.txtClaimAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaimAmount.Location = New System.Drawing.Point(169, 140)
        Me.txtClaimAmount.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtClaimAmount.Name = "txtClaimAmount"
        Me.txtClaimAmount.Size = New System.Drawing.Size(205, 20)
        Me.txtClaimAmount.TabIndex = 17
        '
        'txtClaimnumber
        '
        Me.txtClaimnumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaimnumber.Location = New System.Drawing.Point(169, 11)
        Me.txtClaimnumber.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtClaimnumber.MaxLength = 10
        Me.txtClaimnumber.Name = "txtClaimnumber"
        Me.txtClaimnumber.Size = New System.Drawing.Size(204, 20)
        Me.txtClaimnumber.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(384, 119)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(83, 14)
        Me.Label13.TabIndex = 143
        Me.Label13.Text = "Claim substatus"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(384, 93)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 14)
        Me.Label12.TabIndex = 142
        Me.Label12.Text = "Claim status"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(384, 69)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 14)
        Me.Label8.TabIndex = 141
        Me.Label8.Text = "Claim Completion date"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(384, 41)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 14)
        Me.Label7.TabIndex = 140
        Me.Label7.Text = "Claim Report date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(384, 14)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 14)
        Me.Label6.TabIndex = 139
        Me.Label6.Text = "Claim date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 143)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 14)
        Me.Label4.TabIndex = 138
        Me.Label4.Text = "Claim Amount"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 13)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 14)
        Me.Label3.TabIndex = 137
        Me.Label3.Text = "Claim number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 93)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 14)
        Me.Label2.TabIndex = 136
        Me.Label2.Text = "Claim description"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 40)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 14)
        Me.Label1.TabIndex = 135
        Me.Label1.Text = "Claim Type"
        '
        'tabClaims2
        '
        Me.tabClaims2.Controls.Add(Me.GroupBox11)
        Me.tabClaims2.Controls.Add(Me.GroupBox10)
        Me.tabClaims2.Controls.Add(Me.GroupBox9)
        Me.tabClaims2.Location = New System.Drawing.Point(4, 23)
        Me.tabClaims2.Name = "tabClaims2"
        Me.tabClaims2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabClaims2.Size = New System.Drawing.Size(748, 373)
        Me.tabClaims2.TabIndex = 1
        Me.tabClaims2.Text = "Financials"
        Me.tabClaims2.UseVisualStyleBackColor = True
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.lblTotalJournal)
        Me.GroupBox11.Controls.Add(Me.dgvClaimJournals)
        Me.GroupBox11.Controls.Add(Me.btnJournalDelete)
        Me.GroupBox11.Controls.Add(Me.btnJournalEdit)
        Me.GroupBox11.Location = New System.Drawing.Point(2, 268)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(740, 99)
        Me.GroupBox11.TabIndex = 139
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Journal"
        '
        'lblTotalJournal
        '
        Me.lblTotalJournal.AutoSize = True
        Me.lblTotalJournal.Location = New System.Drawing.Point(13, 18)
        Me.lblTotalJournal.Name = "lblTotalJournal"
        Me.lblTotalJournal.Size = New System.Drawing.Size(0, 14)
        Me.lblTotalJournal.TabIndex = 141
        '
        'dgvClaimJournals
        '
        Me.dgvClaimJournals.AllowUserToDeleteRows = False
        Me.dgvClaimJournals.AllowUserToResizeRows = False
        Me.dgvClaimJournals.ColumnHeadersHeight = 21
        Me.dgvClaimJournals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvClaimJournals.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.JTjekBesonderhede, Me.TjekofElektronies, Me.JVord_premie, Me.JVord_dat, Me.CancelledIcon, Me.Kruisverwysing, Me.pkJoernale})
        Me.dgvClaimJournals.Location = New System.Drawing.Point(2, 35)
        Me.dgvClaimJournals.MultiSelect = False
        Me.dgvClaimJournals.Name = "dgvClaimJournals"
        Me.dgvClaimJournals.ReadOnly = True
        Me.dgvClaimJournals.RowHeadersWidth = 5
        Me.dgvClaimJournals.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvClaimJournals.RowTemplate.Height = 18
        Me.dgvClaimJournals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvClaimJournals.Size = New System.Drawing.Size(736, 57)
        Me.dgvClaimJournals.TabIndex = 140
        '
        'JTjekBesonderhede
        '
        Me.JTjekBesonderhede.DataPropertyName = "JTjekBesonderhede"
        Me.JTjekBesonderhede.HeaderText = "Details"
        Me.JTjekBesonderhede.Name = "JTjekBesonderhede"
        Me.JTjekBesonderhede.ReadOnly = True
        Me.JTjekBesonderhede.Width = 250
        '
        'TjekofElektronies
        '
        Me.TjekofElektronies.DataPropertyName = "TjekofElektronies"
        Me.TjekofElektronies.HeaderText = "Type of Journal"
        Me.TjekofElektronies.Name = "TjekofElektronies"
        Me.TjekofElektronies.ReadOnly = True
        Me.TjekofElektronies.Width = 140
        '
        'JVord_premie
        '
        Me.JVord_premie.DataPropertyName = "JVord_premie"
        Me.JVord_premie.HeaderText = "Amount"
        Me.JVord_premie.Name = "JVord_premie"
        Me.JVord_premie.ReadOnly = True
        '
        'JVord_dat
        '
        Me.JVord_dat.DataPropertyName = "JVord_dat"
        Me.JVord_dat.HeaderText = "Date"
        Me.JVord_dat.Name = "JVord_dat"
        Me.JVord_dat.ReadOnly = True
        '
        'CancelledIcon
        '
        Me.CancelledIcon.DataPropertyName = "CancelledIcon"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Wingdings 2", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.CancelledIcon.DefaultCellStyle = DataGridViewCellStyle6
        Me.CancelledIcon.HeaderText = "Active"
        Me.CancelledIcon.Name = "CancelledIcon"
        Me.CancelledIcon.ReadOnly = True
        Me.CancelledIcon.Width = 70
        '
        'Kruisverwysing
        '
        Me.Kruisverwysing.DataPropertyName = "Kruisverwysing"
        Me.Kruisverwysing.HeaderText = "Cross Reference No"
        Me.Kruisverwysing.Name = "Kruisverwysing"
        Me.Kruisverwysing.ReadOnly = True
        Me.Kruisverwysing.Width = 150
        '
        'pkJoernale
        '
        Me.pkJoernale.DataPropertyName = "pkJoernale"
        Me.pkJoernale.HeaderText = "pkJoernale"
        Me.pkJoernale.Name = "pkJoernale"
        Me.pkJoernale.ReadOnly = True
        Me.pkJoernale.Visible = False
        '
        'btnJournalDelete
        '
        Me.btnJournalDelete.BackColor = System.Drawing.SystemColors.Control
        Me.btnJournalDelete.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnJournalDelete.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnJournalDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnJournalDelete.Location = New System.Drawing.Point(664, 10)
        Me.btnJournalDelete.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnJournalDelete.Name = "btnJournalDelete"
        Me.btnJournalDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnJournalDelete.Size = New System.Drawing.Size(67, 20)
        Me.btnJournalDelete.TabIndex = 139
        Me.btnJournalDelete.Text = "Delete"
        Me.btnJournalDelete.UseVisualStyleBackColor = False
        '
        'btnJournalEdit
        '
        Me.btnJournalEdit.BackColor = System.Drawing.SystemColors.Control
        Me.btnJournalEdit.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnJournalEdit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnJournalEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnJournalEdit.Location = New System.Drawing.Point(593, 10)
        Me.btnJournalEdit.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnJournalEdit.Name = "btnJournalEdit"
        Me.btnJournalEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnJournalEdit.Size = New System.Drawing.Size(67, 20)
        Me.btnJournalEdit.TabIndex = 138
        Me.btnJournalEdit.Text = "Edit"
        Me.btnJournalEdit.UseVisualStyleBackColor = False
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.lblTotalIncome)
        Me.GroupBox10.Controls.Add(Me.btnIncomeJournal)
        Me.GroupBox10.Controls.Add(Me.btnIncomeDelete)
        Me.GroupBox10.Controls.Add(Me.btnIncomeEdit)
        Me.GroupBox10.Controls.Add(Me.dgvClaimIncome)
        Me.GroupBox10.Controls.Add(Me.btnIncomeAdd)
        Me.GroupBox10.Location = New System.Drawing.Point(0, 154)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(745, 114)
        Me.GroupBox10.TabIndex = 138
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Income"
        '
        'lblTotalIncome
        '
        Me.lblTotalIncome.AutoSize = True
        Me.lblTotalIncome.Location = New System.Drawing.Point(13, 16)
        Me.lblTotalIncome.Name = "lblTotalIncome"
        Me.lblTotalIncome.Size = New System.Drawing.Size(0, 14)
        Me.lblTotalIncome.TabIndex = 138
        '
        'btnIncomeJournal
        '
        Me.btnIncomeJournal.BackColor = System.Drawing.SystemColors.Control
        Me.btnIncomeJournal.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnIncomeJournal.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIncomeJournal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnIncomeJournal.Location = New System.Drawing.Point(669, 9)
        Me.btnIncomeJournal.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnIncomeJournal.Name = "btnIncomeJournal"
        Me.btnIncomeJournal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnIncomeJournal.Size = New System.Drawing.Size(67, 20)
        Me.btnIncomeJournal.TabIndex = 137
        Me.btnIncomeJournal.Text = "Journal"
        Me.btnIncomeJournal.UseVisualStyleBackColor = False
        '
        'btnIncomeDelete
        '
        Me.btnIncomeDelete.BackColor = System.Drawing.SystemColors.Control
        Me.btnIncomeDelete.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnIncomeDelete.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIncomeDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnIncomeDelete.Location = New System.Drawing.Point(598, 9)
        Me.btnIncomeDelete.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnIncomeDelete.Name = "btnIncomeDelete"
        Me.btnIncomeDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnIncomeDelete.Size = New System.Drawing.Size(67, 20)
        Me.btnIncomeDelete.TabIndex = 136
        Me.btnIncomeDelete.Text = "Delete"
        Me.btnIncomeDelete.UseVisualStyleBackColor = False
        '
        'btnIncomeEdit
        '
        Me.btnIncomeEdit.BackColor = System.Drawing.SystemColors.Control
        Me.btnIncomeEdit.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnIncomeEdit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIncomeEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnIncomeEdit.Location = New System.Drawing.Point(527, 9)
        Me.btnIncomeEdit.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnIncomeEdit.Name = "btnIncomeEdit"
        Me.btnIncomeEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnIncomeEdit.Size = New System.Drawing.Size(67, 20)
        Me.btnIncomeEdit.TabIndex = 135
        Me.btnIncomeEdit.Text = "Edit"
        Me.btnIncomeEdit.UseVisualStyleBackColor = False
        '
        'dgvClaimIncome
        '
        Me.dgvClaimIncome.AllowUserToDeleteRows = False
        Me.dgvClaimIncome.AllowUserToResizeRows = False
        Me.dgvClaimIncome.ColumnHeadersHeight = 21
        Me.dgvClaimIncome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvClaimIncome.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Details, Me.Type, Me.Amount, Me.IncomeDate, Me.CancelIcon, Me.InvoiceReferenceNr, Me.pkIncome})
        Me.dgvClaimIncome.Location = New System.Drawing.Point(3, 33)
        Me.dgvClaimIncome.MultiSelect = False
        Me.dgvClaimIncome.Name = "dgvClaimIncome"
        Me.dgvClaimIncome.ReadOnly = True
        Me.dgvClaimIncome.RowHeadersWidth = 5
        Me.dgvClaimIncome.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvClaimIncome.RowTemplate.Height = 18
        Me.dgvClaimIncome.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvClaimIncome.Size = New System.Drawing.Size(736, 77)
        Me.dgvClaimIncome.TabIndex = 133
        '
        'Details
        '
        Me.Details.DataPropertyName = "Besonderhede"
        Me.Details.HeaderText = "Details"
        Me.Details.Name = "Details"
        Me.Details.ReadOnly = True
        Me.Details.Width = 250
        '
        'Type
        '
        Me.Type.DataPropertyName = "Tipe"
        Me.Type.HeaderText = "Type of Income"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        Me.Type.Width = 140
        '
        'Amount
        '
        Me.Amount.DataPropertyName = "Bedrag"
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.ReadOnly = True
        '
        'IncomeDate
        '
        Me.IncomeDate.DataPropertyName = "DatumInkomste"
        Me.IncomeDate.HeaderText = "Date"
        Me.IncomeDate.Name = "IncomeDate"
        Me.IncomeDate.ReadOnly = True
        '
        'CancelIcon
        '
        Me.CancelIcon.DataPropertyName = "CancelIcon"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Wingdings 2", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.CancelIcon.DefaultCellStyle = DataGridViewCellStyle7
        Me.CancelIcon.HeaderText = "Active"
        Me.CancelIcon.Name = "CancelIcon"
        Me.CancelIcon.ReadOnly = True
        Me.CancelIcon.Width = 70
        '
        'InvoiceReferenceNr
        '
        Me.InvoiceReferenceNr.DataPropertyName = "kwitansienr"
        Me.InvoiceReferenceNr.HeaderText = "Invoice/Reference No"
        Me.InvoiceReferenceNr.Name = "InvoiceReferenceNr"
        Me.InvoiceReferenceNr.ReadOnly = True
        Me.InvoiceReferenceNr.Width = 150
        '
        'pkIncome
        '
        Me.pkIncome.DataPropertyName = "pkIncome"
        Me.pkIncome.HeaderText = "pkIncome"
        Me.pkIncome.MinimumWidth = 2
        Me.pkIncome.Name = "pkIncome"
        Me.pkIncome.ReadOnly = True
        Me.pkIncome.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.pkIncome.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pkIncome.Width = 2
        '
        'btnIncomeAdd
        '
        Me.btnIncomeAdd.BackColor = System.Drawing.SystemColors.Control
        Me.btnIncomeAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnIncomeAdd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIncomeAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnIncomeAdd.Location = New System.Drawing.Point(456, 9)
        Me.btnIncomeAdd.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnIncomeAdd.Name = "btnIncomeAdd"
        Me.btnIncomeAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnIncomeAdd.Size = New System.Drawing.Size(67, 20)
        Me.btnIncomeAdd.TabIndex = 134
        Me.btnIncomeAdd.Text = "Add"
        Me.btnIncomeAdd.UseVisualStyleBackColor = False
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.lblTotalPayments)
        Me.GroupBox9.Controls.Add(Me.btnPaymentsJournal)
        Me.GroupBox9.Controls.Add(Me.btnPaymentsAdd)
        Me.GroupBox9.Controls.Add(Me.dgvPayments)
        Me.GroupBox9.Controls.Add(Me.btnPaymentsEdit)
        Me.GroupBox9.Controls.Add(Me.btnPaymentsDelete)
        Me.GroupBox9.Location = New System.Drawing.Point(0, 7)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(745, 148)
        Me.GroupBox9.TabIndex = 137
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Payments"
        '
        'lblTotalPayments
        '
        Me.lblTotalPayments.AutoSize = True
        Me.lblTotalPayments.Location = New System.Drawing.Point(13, 17)
        Me.lblTotalPayments.Name = "lblTotalPayments"
        Me.lblTotalPayments.Size = New System.Drawing.Size(0, 14)
        Me.lblTotalPayments.TabIndex = 134
        '
        'btnPaymentsJournal
        '
        Me.btnPaymentsJournal.BackColor = System.Drawing.SystemColors.Control
        Me.btnPaymentsJournal.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnPaymentsJournal.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPaymentsJournal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPaymentsJournal.Location = New System.Drawing.Point(669, 10)
        Me.btnPaymentsJournal.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnPaymentsJournal.Name = "btnPaymentsJournal"
        Me.btnPaymentsJournal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPaymentsJournal.Size = New System.Drawing.Size(67, 20)
        Me.btnPaymentsJournal.TabIndex = 133
        Me.btnPaymentsJournal.Text = "Journal"
        Me.btnPaymentsJournal.UseVisualStyleBackColor = False
        '
        'btnPaymentsAdd
        '
        Me.btnPaymentsAdd.BackColor = System.Drawing.SystemColors.Control
        Me.btnPaymentsAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnPaymentsAdd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPaymentsAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPaymentsAdd.Location = New System.Drawing.Point(456, 10)
        Me.btnPaymentsAdd.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnPaymentsAdd.Name = "btnPaymentsAdd"
        Me.btnPaymentsAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPaymentsAdd.Size = New System.Drawing.Size(67, 20)
        Me.btnPaymentsAdd.TabIndex = 22
        Me.btnPaymentsAdd.Text = "Add"
        Me.btnPaymentsAdd.UseVisualStyleBackColor = False
        '
        'dgvPayments
        '
        Me.dgvPayments.AllowUserToDeleteRows = False
        Me.dgvPayments.AllowUserToResizeRows = False
        Me.dgvPayments.ColumnHeadersHeight = 21
        Me.dgvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvPayments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TjekBesonderhede, Me.TipePayment, Me.Vord_premie, Me.Vord_dat, Me.GekansIcon, Me.tjekno_uit, Me.pkPayments, Me.Nedlopie})
        Me.dgvPayments.Location = New System.Drawing.Point(3, 34)
        Me.dgvPayments.MultiSelect = False
        Me.dgvPayments.Name = "dgvPayments"
        Me.dgvPayments.ReadOnly = True
        Me.dgvPayments.RowHeadersWidth = 5
        Me.dgvPayments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvPayments.RowTemplate.Height = 18
        Me.dgvPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPayments.Size = New System.Drawing.Size(734, 104)
        Me.dgvPayments.TabIndex = 132
        '
        'TjekBesonderhede
        '
        Me.TjekBesonderhede.DataPropertyName = "TjekBesonderhede"
        Me.TjekBesonderhede.HeaderText = "Details"
        Me.TjekBesonderhede.Name = "TjekBesonderhede"
        Me.TjekBesonderhede.ReadOnly = True
        Me.TjekBesonderhede.Width = 250
        '
        'TipePayment
        '
        Me.TipePayment.DataPropertyName = "TipePayment"
        Me.TipePayment.HeaderText = "Type of Payment"
        Me.TipePayment.Name = "TipePayment"
        Me.TipePayment.ReadOnly = True
        Me.TipePayment.Width = 140
        '
        'Vord_premie
        '
        Me.Vord_premie.DataPropertyName = "Vord_premie"
        Me.Vord_premie.HeaderText = "Amount"
        Me.Vord_premie.Name = "Vord_premie"
        Me.Vord_premie.ReadOnly = True
        '
        'Vord_dat
        '
        Me.Vord_dat.DataPropertyName = "Vord_dat"
        Me.Vord_dat.HeaderText = "Date"
        Me.Vord_dat.Name = "Vord_dat"
        Me.Vord_dat.ReadOnly = True
        '
        'GekansIcon
        '
        Me.GekansIcon.DataPropertyName = "GekansIcon"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Wingdings 2", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.GekansIcon.DefaultCellStyle = DataGridViewCellStyle8
        Me.GekansIcon.HeaderText = "Active"
        Me.GekansIcon.Name = "GekansIcon"
        Me.GekansIcon.ReadOnly = true
        Me.GekansIcon.Width = 70
        '
        'tjekno_uit
        '
        Me.tjekno_uit.DataPropertyName = "tjekno_uit"
        Me.tjekno_uit.HeaderText = "Cheque/Electronic Reference No"
        Me.tjekno_uit.Name = "tjekno_uit"
        Me.tjekno_uit.ReadOnly = true
        Me.tjekno_uit.Width = 150
        '
        'pkPayments
        '
        Me.pkPayments.DataPropertyName = "pkPayments"
        Me.pkPayments.HeaderText = "pkPayments"
        Me.pkPayments.MinimumWidth = 2
        Me.pkPayments.Name = "pkPayments"
        Me.pkPayments.ReadOnly = true
        Me.pkPayments.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.pkPayments.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pkPayments.Width = 2
        '
        'Nedlopie
        '
        Me.Nedlopie.DataPropertyName = "Nedlopie"
        Me.Nedlopie.HeaderText = "Nedlopie"
        Me.Nedlopie.Name = "Nedlopie"
        Me.Nedlopie.ReadOnly = true
        Me.Nedlopie.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Nedlopie.Visible = false
        Me.Nedlopie.Width = 5
        '
        'btnPaymentsEdit
        '
        Me.btnPaymentsEdit.BackColor = System.Drawing.SystemColors.Control
        Me.btnPaymentsEdit.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnPaymentsEdit.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnPaymentsEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPaymentsEdit.Location = New System.Drawing.Point(527, 10)
        Me.btnPaymentsEdit.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnPaymentsEdit.Name = "btnPaymentsEdit"
        Me.btnPaymentsEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPaymentsEdit.Size = New System.Drawing.Size(67, 20)
        Me.btnPaymentsEdit.TabIndex = 23
        Me.btnPaymentsEdit.Text = "Edit"
        Me.btnPaymentsEdit.UseVisualStyleBackColor = false
        '
        'btnPaymentsDelete
        '
        Me.btnPaymentsDelete.BackColor = System.Drawing.SystemColors.Control
        Me.btnPaymentsDelete.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnPaymentsDelete.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnPaymentsDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPaymentsDelete.Location = New System.Drawing.Point(598, 10)
        Me.btnPaymentsDelete.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnPaymentsDelete.Name = "btnPaymentsDelete"
        Me.btnPaymentsDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPaymentsDelete.Size = New System.Drawing.Size(67, 20)
        Me.btnPaymentsDelete.TabIndex = 24
        Me.btnPaymentsDelete.Text = "Delete"
        Me.btnPaymentsDelete.UseVisualStyleBackColor = false
        '
        'TabClaims3
        '
        Me.TabClaims3.Controls.Add(Me.btnAssessorAdd)
        Me.TabClaims3.Controls.Add(Me.btnAssessorDelete)
        Me.TabClaims3.Controls.Add(Me.Label21)
        Me.TabClaims3.Controls.Add(Me.dgvClaimAssessors)
        Me.TabClaims3.Location = New System.Drawing.Point(4, 23)
        Me.TabClaims3.Name = "TabClaims3"
        Me.TabClaims3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabClaims3.Size = New System.Drawing.Size(748, 373)
        Me.TabClaims3.TabIndex = 2
        Me.TabClaims3.Text = "Assessors"
        Me.TabClaims3.UseVisualStyleBackColor = true
        '
        'btnAssessorAdd
        '
        Me.btnAssessorAdd.BackColor = System.Drawing.SystemColors.Control
        Me.btnAssessorAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnAssessorAdd.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnAssessorAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAssessorAdd.Location = New System.Drawing.Point(201, 10)
        Me.btnAssessorAdd.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnAssessorAdd.Name = "btnAssessorAdd"
        Me.btnAssessorAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnAssessorAdd.Size = New System.Drawing.Size(67, 20)
        Me.btnAssessorAdd.TabIndex = 25
        Me.btnAssessorAdd.Text = "Add"
        Me.btnAssessorAdd.UseVisualStyleBackColor = false
        '
        'btnAssessorDelete
        '
        Me.btnAssessorDelete.BackColor = System.Drawing.SystemColors.Control
        Me.btnAssessorDelete.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnAssessorDelete.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnAssessorDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAssessorDelete.Location = New System.Drawing.Point(272, 10)
        Me.btnAssessorDelete.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnAssessorDelete.Name = "btnAssessorDelete"
        Me.btnAssessorDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnAssessorDelete.Size = New System.Drawing.Size(67, 20)
        Me.btnAssessorDelete.TabIndex = 26
        Me.btnAssessorDelete.Text = "Delete"
        Me.btnAssessorDelete.UseVisualStyleBackColor = false
        '
        'Label21
        '
        Me.Label21.AutoSize = true
        Me.Label21.Location = New System.Drawing.Point(8, 13)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(123, 14)
        Me.Label21.TabIndex = 15
        Me.Label21.Text = "Assessors on this claim"
        '
        'dgvClaimAssessors
        '
        Me.dgvClaimAssessors.AllowUserToAddRows = false
        Me.dgvClaimAssessors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClaimAssessors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pkAssessorsperClaim, Me.AssessorName})
        Me.dgvClaimAssessors.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvClaimAssessors.Location = New System.Drawing.Point(11, 36)
        Me.dgvClaimAssessors.Name = "dgvClaimAssessors"
        Me.dgvClaimAssessors.RowHeadersWidth = 5
        Me.dgvClaimAssessors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvClaimAssessors.Size = New System.Drawing.Size(328, 202)
        Me.dgvClaimAssessors.TabIndex = 0
        '
        'pkAssessorsperClaim
        '
        Me.pkAssessorsperClaim.DataPropertyName = "pkAssessorsperClaim"
        Me.pkAssessorsperClaim.HeaderText = "pkAssessorClaim"
        Me.pkAssessorsperClaim.Name = "pkAssessorsperClaim"
        Me.pkAssessorsperClaim.Visible = false
        '
        'AssessorName
        '
        Me.AssessorName.DataPropertyName = "AssessorName"
        Me.AssessorName.HeaderText = "Assessor Name"
        Me.AssessorName.Name = "AssessorName"
        Me.AssessorName.Width = 200
        '
        'TabClaims4
        '
        Me.TabClaims4.Controls.Add(Me.grpExGratia)
        Me.TabClaims4.Controls.Add(Me.lstSecurity)
        Me.TabClaims4.Controls.Add(Me.dgvClaimEstimate)
        Me.TabClaims4.Controls.Add(Me.cmdCatastrophe)
        Me.TabClaims4.Controls.Add(Me.optThunderNo)
        Me.TabClaims4.Controls.Add(Me.optThunderYes)
        Me.TabClaims4.Controls.Add(Me.lblThunder)
        Me.TabClaims4.Controls.Add(Me.lblExGratia)
        Me.TabClaims4.Controls.Add(Me.Label17)
        Me.TabClaims4.Controls.Add(Me.cmbCatastrophe)
        Me.TabClaims4.Controls.Add(Me.Label11)
        Me.TabClaims4.Controls.Add(Me.lblSecurity)
        Me.TabClaims4.Controls.Add(Me.grpVehicle)
        Me.TabClaims4.Controls.Add(Me.grpDogBite)
        Me.TabClaims4.Location = New System.Drawing.Point(4, 23)
        Me.TabClaims4.Name = "TabClaims4"
        Me.TabClaims4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabClaims4.Size = New System.Drawing.Size(748, 373)
        Me.TabClaims4.TabIndex = 3
        Me.TabClaims4.Text = "More Claim Info"
        Me.TabClaims4.UseVisualStyleBackColor = true
        '
        'grpExGratia
        '
        Me.grpExGratia.Controls.Add(Me.optExGratiaNo)
        Me.grpExGratia.Controls.Add(Me.optExgratiaYes)
        Me.grpExGratia.Location = New System.Drawing.Point(97, 32)
        Me.grpExGratia.Name = "grpExGratia"
        Me.grpExGratia.Size = New System.Drawing.Size(149, 30)
        Me.grpExGratia.TabIndex = 72
        Me.grpExGratia.TabStop = false
        '
        'optExGratiaNo
        '
        Me.optExGratiaNo.AutoSize = true
        Me.optExGratiaNo.Location = New System.Drawing.Point(85, 9)
        Me.optExGratiaNo.Name = "optExGratiaNo"
        Me.optExGratiaNo.Size = New System.Drawing.Size(38, 18)
        Me.optExGratiaNo.TabIndex = 68
        Me.optExGratiaNo.TabStop = true
        Me.optExGratiaNo.Text = "No"
        Me.optExGratiaNo.UseVisualStyleBackColor = true
        '
        'optExgratiaYes
        '
        Me.optExgratiaYes.AutoSize = true
        Me.optExgratiaYes.Location = New System.Drawing.Point(10, 9)
        Me.optExgratiaYes.Name = "optExgratiaYes"
        Me.optExgratiaYes.Size = New System.Drawing.Size(44, 18)
        Me.optExgratiaYes.TabIndex = 67
        Me.optExgratiaYes.TabStop = true
        Me.optExgratiaYes.Text = "Yes"
        Me.optExgratiaYes.UseVisualStyleBackColor = true
        '
        'lstSecurity
        '
        Me.lstSecurity.FormattingEnabled = true
        Me.lstSecurity.ItemHeight = 14
        Me.lstSecurity.Location = New System.Drawing.Point(97, 66)
        Me.lstSecurity.Name = "lstSecurity"
        Me.lstSecurity.Size = New System.Drawing.Size(350, 74)
        Me.lstSecurity.TabIndex = 69
        '
        'dgvClaimEstimate
        '
        Me.dgvClaimEstimate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClaimEstimate.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ClaimEstimateAmount, Me.ClaimEstimateDate})
        Me.dgvClaimEstimate.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvClaimEstimate.Location = New System.Drawing.Point(469, 30)
        Me.dgvClaimEstimate.Name = "dgvClaimEstimate"
        Me.dgvClaimEstimate.ReadOnly = true
        Me.dgvClaimEstimate.RowHeadersWidth = 5
        Me.dgvClaimEstimate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvClaimEstimate.Size = New System.Drawing.Size(273, 109)
        Me.dgvClaimEstimate.TabIndex = 58
        '
        'ClaimEstimateAmount
        '
        Me.ClaimEstimateAmount.DataPropertyName = "eisramingsbedrag"
        Me.ClaimEstimateAmount.HeaderText = "Estimate Amount"
        Me.ClaimEstimateAmount.Name = "ClaimEstimateAmount"
        Me.ClaimEstimateAmount.ReadOnly = true
        Me.ClaimEstimateAmount.Width = 150
        '
        'ClaimEstimateDate
        '
        Me.ClaimEstimateDate.DataPropertyName = "eisramingsdatum"
        Me.ClaimEstimateDate.HeaderText = "Estimate Date"
        Me.ClaimEstimateDate.Name = "ClaimEstimateDate"
        Me.ClaimEstimateDate.ReadOnly = true
        Me.ClaimEstimateDate.Width = 150
        '
        'cmdCatastrophe
        '
        Me.cmdCatastrophe.Location = New System.Drawing.Point(281, 9)
        Me.cmdCatastrophe.Name = "cmdCatastrophe"
        Me.cmdCatastrophe.Size = New System.Drawing.Size(90, 25)
        Me.cmdCatastrophe.TabIndex = 57
        Me.cmdCatastrophe.Text = "Catastrophe"
        Me.cmdCatastrophe.UseVisualStyleBackColor = true
        Me.cmdCatastrophe.Visible = false
        '
        'optThunderNo
        '
        Me.optThunderNo.AutoSize = true
        Me.optThunderNo.Location = New System.Drawing.Point(645, 146)
        Me.optThunderNo.Name = "optThunderNo"
        Me.optThunderNo.Size = New System.Drawing.Size(38, 18)
        Me.optThunderNo.TabIndex = 56
        Me.optThunderNo.TabStop = true
        Me.optThunderNo.Text = "No"
        Me.optThunderNo.UseVisualStyleBackColor = true
        Me.optThunderNo.Visible = false
        '
        'optThunderYes
        '
        Me.optThunderYes.AutoSize = true
        Me.optThunderYes.Location = New System.Drawing.Point(580, 146)
        Me.optThunderYes.Name = "optThunderYes"
        Me.optThunderYes.Size = New System.Drawing.Size(44, 18)
        Me.optThunderYes.TabIndex = 55
        Me.optThunderYes.TabStop = true
        Me.optThunderYes.Text = "Yes"
        Me.optThunderYes.UseVisualStyleBackColor = true
        Me.optThunderYes.Visible = false
        '
        'lblThunder
        '
        Me.lblThunder.AutoSize = true
        Me.lblThunder.Location = New System.Drawing.Point(8, 148)
        Me.lblThunder.Name = "lblThunder"
        Me.lblThunder.Size = New System.Drawing.Size(545, 14)
        Me.lblThunder.TabIndex = 23
        Me.lblThunder.Text = "In case of thunder, was there any surge protectors on the plugs, phone lines, ant"& _ 
    "ennas and/or distribution box?"
        Me.lblThunder.Visible = false
        '
        'lblExGratia
        '
        Me.lblExGratia.AutoSize = true
        Me.lblExGratia.Location = New System.Drawing.Point(8, 44)
        Me.lblExGratia.Name = "lblExGratia"
        Me.lblExGratia.Size = New System.Drawing.Size(51, 14)
        Me.lblExGratia.TabIndex = 5
        Me.lblExGratia.Text = "Ex Gratia"
        '
        'Label17
        '
        Me.Label17.AutoSize = true
        Me.Label17.Location = New System.Drawing.Point(466, 13)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(75, 14)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "Claim Estimate"
        '
        'cmbCatastrophe
        '
        Me.cmbCatastrophe.FormattingEnabled = true
        Me.cmbCatastrophe.Location = New System.Drawing.Point(97, 9)
        Me.cmbCatastrophe.Name = "cmbCatastrophe"
        Me.cmbCatastrophe.Size = New System.Drawing.Size(176, 22)
        Me.cmbCatastrophe.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = true
        Me.Label11.Location = New System.Drawing.Point(7, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 14)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Catastrophe"
        '
        'lblSecurity
        '
        Me.lblSecurity.AutoSize = true
        Me.lblSecurity.Location = New System.Drawing.Point(8, 71)
        Me.lblSecurity.Name = "lblSecurity"
        Me.lblSecurity.Size = New System.Drawing.Size(47, 14)
        Me.lblSecurity.TabIndex = 8
        Me.lblSecurity.Text = "Security"
        '
        'grpVehicle
        '
        Me.grpVehicle.Controls.Add(Me.GroupBox4)
        Me.grpVehicle.Controls.Add(Me.GroupBox3)
        Me.grpVehicle.Controls.Add(Me.lblAlcoholSubstanceAbuse)
        Me.grpVehicle.Controls.Add(Me.GroupBox2)
        Me.grpVehicle.Controls.Add(Me.GroupBox1)
        Me.grpVehicle.Controls.Add(Me.txtWhereVehicleFound)
        Me.grpVehicle.Controls.Add(Me.txtVehicleUse)
        Me.grpVehicle.Controls.Add(Me.txtDamageAmount)
        Me.grpVehicle.Controls.Add(Me.txtTypeofCover)
        Me.grpVehicle.Controls.Add(Me.txtDriverIDnr)
        Me.grpVehicle.Controls.Add(Me.lblWhereVehicleFound)
        Me.grpVehicle.Controls.Add(Me.lblVehicleUse)
        Me.grpVehicle.Controls.Add(Me.lblVehicleFound)
        Me.grpVehicle.Controls.Add(Me.lblTypeofCover)
        Me.grpVehicle.Controls.Add(Me.lblKnockforKnock)
        Me.grpVehicle.Controls.Add(Me.lblDriverIDNr)
        Me.grpVehicle.Controls.Add(Me.lblDamageAmount)
        Me.grpVehicle.Controls.Add(Me.lblVehicleWrittenoff)
        Me.grpVehicle.Location = New System.Drawing.Point(6, 148)
        Me.grpVehicle.Name = "grpVehicle"
        Me.grpVehicle.Size = New System.Drawing.Size(714, 182)
        Me.grpVehicle.TabIndex = 54
        Me.grpVehicle.TabStop = false
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.optVehiclefoundYes)
        Me.GroupBox4.Controls.Add(Me.optVehicleFoundNo)
        Me.GroupBox4.Location = New System.Drawing.Point(145, 112)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(149, 30)
        Me.GroupBox4.TabIndex = 70
        Me.GroupBox4.TabStop = false
        '
        'optVehiclefoundYes
        '
        Me.optVehiclefoundYes.AutoSize = true
        Me.optVehiclefoundYes.Location = New System.Drawing.Point(10, 9)
        Me.optVehiclefoundYes.Name = "optVehiclefoundYes"
        Me.optVehiclefoundYes.Size = New System.Drawing.Size(44, 18)
        Me.optVehiclefoundYes.TabIndex = 59
        Me.optVehiclefoundYes.TabStop = true
        Me.optVehiclefoundYes.Text = "Yes"
        Me.optVehiclefoundYes.UseVisualStyleBackColor = true
        '
        'optVehicleFoundNo
        '
        Me.optVehicleFoundNo.AutoSize = true
        Me.optVehicleFoundNo.Location = New System.Drawing.Point(85, 9)
        Me.optVehicleFoundNo.Name = "optVehicleFoundNo"
        Me.optVehicleFoundNo.Size = New System.Drawing.Size(38, 18)
        Me.optVehicleFoundNo.TabIndex = 60
        Me.optVehicleFoundNo.TabStop = true
        Me.optVehicleFoundNo.Text = "No"
        Me.optVehicleFoundNo.UseVisualStyleBackColor = true
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.optWriteoffNo)
        Me.GroupBox3.Controls.Add(Me.optWriteoffYes)
        Me.GroupBox3.Location = New System.Drawing.Point(477, 112)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(149, 30)
        Me.GroupBox3.TabIndex = 69
        Me.GroupBox3.TabStop = false
        '
        'optWriteoffNo
        '
        Me.optWriteoffNo.AutoSize = true
        Me.optWriteoffNo.Location = New System.Drawing.Point(91, 8)
        Me.optWriteoffNo.Name = "optWriteoffNo"
        Me.optWriteoffNo.Size = New System.Drawing.Size(38, 18)
        Me.optWriteoffNo.TabIndex = 64
        Me.optWriteoffNo.TabStop = true
        Me.optWriteoffNo.Text = "No"
        Me.optWriteoffNo.UseVisualStyleBackColor = true
        '
        'optWriteoffYes
        '
        Me.optWriteoffYes.AutoSize = true
        Me.optWriteoffYes.Location = New System.Drawing.Point(8, 8)
        Me.optWriteoffYes.Name = "optWriteoffYes"
        Me.optWriteoffYes.Size = New System.Drawing.Size(44, 18)
        Me.optWriteoffYes.TabIndex = 63
        Me.optWriteoffYes.TabStop = true
        Me.optWriteoffYes.Text = "Yes"
        Me.optWriteoffYes.UseVisualStyleBackColor = true
        '
        'lblAlcoholSubstanceAbuse
        '
        Me.lblAlcoholSubstanceAbuse.AutoSize = true
        Me.lblAlcoholSubstanceAbuse.Location = New System.Drawing.Point(358, 43)
        Me.lblAlcoholSubstanceAbuse.Name = "lblAlcoholSubstanceAbuse"
        Me.lblAlcoholSubstanceAbuse.Size = New System.Drawing.Size(232, 14)
        Me.lblAlcoholSubstanceAbuse.TabIndex = 14
        Me.lblAlcoholSubstanceAbuse.Text = "Driver tested for Alcohol or Substance Abuse?"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optAlcoholYes)
        Me.GroupBox2.Controls.Add(Me.optAlcoholNo)
        Me.GroupBox2.Location = New System.Drawing.Point(477, 56)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(149, 30)
        Me.GroupBox2.TabIndex = 68
        Me.GroupBox2.TabStop = false
        '
        'optAlcoholYes
        '
        Me.optAlcoholYes.AutoSize = true
        Me.optAlcoholYes.Location = New System.Drawing.Point(8, 9)
        Me.optAlcoholYes.Name = "optAlcoholYes"
        Me.optAlcoholYes.Size = New System.Drawing.Size(44, 18)
        Me.optAlcoholYes.TabIndex = 61
        Me.optAlcoholYes.TabStop = true
        Me.optAlcoholYes.Text = "Yes"
        Me.optAlcoholYes.UseVisualStyleBackColor = true
        '
        'optAlcoholNo
        '
        Me.optAlcoholNo.AutoSize = true
        Me.optAlcoholNo.Location = New System.Drawing.Point(91, 9)
        Me.optAlcoholNo.Name = "optAlcoholNo"
        Me.optAlcoholNo.Size = New System.Drawing.Size(38, 18)
        Me.optAlcoholNo.TabIndex = 62
        Me.optAlcoholNo.TabStop = true
        Me.optAlcoholNo.Text = "No"
        Me.optAlcoholNo.UseVisualStyleBackColor = true
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optKnockNo)
        Me.GroupBox1.Controls.Add(Me.optKnockYes)
        Me.GroupBox1.Location = New System.Drawing.Point(145, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(149, 30)
        Me.GroupBox1.TabIndex = 67
        Me.GroupBox1.TabStop = false
        '
        'optKnockNo
        '
        Me.optKnockNo.AutoSize = true
        Me.optKnockNo.Location = New System.Drawing.Point(87, 8)
        Me.optKnockNo.Name = "optKnockNo"
        Me.optKnockNo.Size = New System.Drawing.Size(38, 18)
        Me.optKnockNo.TabIndex = 66
        Me.optKnockNo.TabStop = true
        Me.optKnockNo.Text = "No"
        Me.optKnockNo.UseVisualStyleBackColor = true
        '
        'optKnockYes
        '
        Me.optKnockYes.AutoSize = true
        Me.optKnockYes.Location = New System.Drawing.Point(12, 8)
        Me.optKnockYes.Name = "optKnockYes"
        Me.optKnockYes.Size = New System.Drawing.Size(44, 18)
        Me.optKnockYes.TabIndex = 65
        Me.optKnockYes.TabStop = true
        Me.optKnockYes.Text = "Yes"
        Me.optKnockYes.UseVisualStyleBackColor = true
        '
        'txtWhereVehicleFound
        '
        Me.txtWhereVehicleFound.Location = New System.Drawing.Point(145, 148)
        Me.txtWhereVehicleFound.Name = "txtWhereVehicleFound"
        Me.txtWhereVehicleFound.Size = New System.Drawing.Size(174, 20)
        Me.txtWhereVehicleFound.TabIndex = 43
        '
        'txtVehicleUse
        '
        Me.txtVehicleUse.Enabled = false
        Me.txtVehicleUse.Location = New System.Drawing.Point(145, 92)
        Me.txtVehicleUse.Name = "txtVehicleUse"
        Me.txtVehicleUse.Size = New System.Drawing.Size(174, 20)
        Me.txtVehicleUse.TabIndex = 33
        '
        'txtDamageAmount
        '
        Me.txtDamageAmount.Location = New System.Drawing.Point(477, 92)
        Me.txtDamageAmount.Name = "txtDamageAmount"
        Me.txtDamageAmount.Size = New System.Drawing.Size(149, 20)
        Me.txtDamageAmount.TabIndex = 44
        '
        'txtTypeofCover
        '
        Me.txtTypeofCover.Enabled = false
        Me.txtTypeofCover.Location = New System.Drawing.Point(145, 66)
        Me.txtTypeofCover.Name = "txtTypeofCover"
        Me.txtTypeofCover.Size = New System.Drawing.Size(174, 20)
        Me.txtTypeofCover.TabIndex = 32
        '
        'txtDriverIDnr
        '
        Me.txtDriverIDnr.Location = New System.Drawing.Point(477, 17)
        Me.txtDriverIDnr.Name = "txtDriverIDnr"
        Me.txtDriverIDnr.Size = New System.Drawing.Size(206, 20)
        Me.txtDriverIDnr.TabIndex = 39
        '
        'lblWhereVehicleFound
        '
        Me.lblWhereVehicleFound.AutoSize = true
        Me.lblWhereVehicleFound.Location = New System.Drawing.Point(7, 151)
        Me.lblWhereVehicleFound.Name = "lblWhereVehicleFound"
        Me.lblWhereVehicleFound.Size = New System.Drawing.Size(138, 14)
        Me.lblWhereVehicleFound.TabIndex = 13
        Me.lblWhereVehicleFound.Text = "Where was vehicle found?"
        '
        'lblVehicleUse
        '
        Me.lblVehicleUse.AutoSize = true
        Me.lblVehicleUse.Location = New System.Drawing.Point(7, 95)
        Me.lblVehicleUse.Name = "lblVehicleUse"
        Me.lblVehicleUse.Size = New System.Drawing.Size(63, 14)
        Me.lblVehicleUse.TabIndex = 12
        Me.lblVehicleUse.Text = "Vehicle use"
        '
        'lblVehicleFound
        '
        Me.lblVehicleFound.AutoSize = true
        Me.lblVehicleFound.Location = New System.Drawing.Point(7, 120)
        Me.lblVehicleFound.Name = "lblVehicleFound"
        Me.lblVehicleFound.Size = New System.Drawing.Size(104, 14)
        Me.lblVehicleFound.TabIndex = 10
        Me.lblVehicleFound.Text = "Vehicle Recovered?"
        '
        'lblTypeofCover
        '
        Me.lblTypeofCover.AutoSize = true
        Me.lblTypeofCover.Location = New System.Drawing.Point(7, 69)
        Me.lblTypeofCover.Name = "lblTypeofCover"
        Me.lblTypeofCover.Size = New System.Drawing.Size(75, 14)
        Me.lblTypeofCover.TabIndex = 9
        Me.lblTypeofCover.Text = "Type of Cover"
        '
        'lblKnockforKnock
        '
        Me.lblKnockforKnock.AutoSize = true
        Me.lblKnockforKnock.Location = New System.Drawing.Point(7, 20)
        Me.lblKnockforKnock.Name = "lblKnockforKnock"
        Me.lblKnockforKnock.Size = New System.Drawing.Size(87, 14)
        Me.lblKnockforKnock.TabIndex = 7
        Me.lblKnockforKnock.Text = "Knock for Knock"
        '
        'lblDriverIDNr
        '
        Me.lblDriverIDNr.AutoSize = true
        Me.lblDriverIDNr.Location = New System.Drawing.Point(359, 20)
        Me.lblDriverIDNr.Name = "lblDriverIDNr"
        Me.lblDriverIDNr.Size = New System.Drawing.Size(63, 14)
        Me.lblDriverIDNr.TabIndex = 15
        Me.lblDriverIDNr.Text = "Driver ID no"
        '
        'lblDamageAmount
        '
        Me.lblDamageAmount.AutoSize = true
        Me.lblDamageAmount.Location = New System.Drawing.Point(359, 95)
        Me.lblDamageAmount.Name = "lblDamageAmount"
        Me.lblDamageAmount.Size = New System.Drawing.Size(85, 14)
        Me.lblDamageAmount.TabIndex = 11
        Me.lblDamageAmount.Text = "Damage Amount"
        '
        'lblVehicleWrittenoff
        '
        Me.lblVehicleWrittenoff.AutoSize = true
        Me.lblVehicleWrittenoff.Location = New System.Drawing.Point(359, 120)
        Me.lblVehicleWrittenoff.Name = "lblVehicleWrittenoff"
        Me.lblVehicleWrittenoff.Size = New System.Drawing.Size(102, 14)
        Me.lblVehicleWrittenoff.TabIndex = 21
        Me.lblVehicleWrittenoff.Text = "Vehicle Written off?"
        '
        'grpDogBite
        '
        Me.grpDogBite.Controls.Add(Me.grpDogAggressive)
        Me.grpDogBite.Controls.Add(Me.grpBittenBefore)
        Me.grpDogBite.Controls.Add(Me.txtDogBiteDetails)
        Me.grpDogBite.Controls.Add(Me.txtDogBiteHistory)
        Me.grpDogBite.Controls.Add(Me.lblDogBitesYard)
        Me.grpDogBite.Controls.Add(Me.lblDogBitesAggressive)
        Me.grpDogBite.Controls.Add(Me.lblDogBiteBittenBefore)
        Me.grpDogBite.Controls.Add(Me.lblDogBite)
        Me.grpDogBite.Controls.Add(Me.lblClaimType)
        Me.grpDogBite.Controls.Add(Me.lblDogBitesDescription)
        Me.grpDogBite.Controls.Add(Me.grpPrecautionMeasure)
        Me.grpDogBite.Controls.Add(Me.GroupBox5)
        Me.grpDogBite.Location = New System.Drawing.Point(12, 144)
        Me.grpDogBite.Name = "grpDogBite"
        Me.grpDogBite.Size = New System.Drawing.Size(718, 215)
        Me.grpDogBite.TabIndex = 71
        Me.grpDogBite.TabStop = false
        Me.grpDogBite.Visible = false
        '
        'grpDogAggressive
        '
        Me.grpDogAggressive.Controls.Add(Me.optDogAggressiveYes)
        Me.grpDogAggressive.Controls.Add(Me.optDogAggressiveNo)
        Me.grpDogAggressive.Location = New System.Drawing.Point(440, 36)
        Me.grpDogAggressive.Name = "grpDogAggressive"
        Me.grpDogAggressive.Size = New System.Drawing.Size(184, 30)
        Me.grpDogAggressive.TabIndex = 68
        Me.grpDogAggressive.TabStop = false
        '
        'optDogAggressiveYes
        '
        Me.optDogAggressiveYes.AutoSize = true
        Me.optDogAggressiveYes.Location = New System.Drawing.Point(11, 8)
        Me.optDogAggressiveYes.Name = "optDogAggressiveYes"
        Me.optDogAggressiveYes.Size = New System.Drawing.Size(44, 18)
        Me.optDogAggressiveYes.TabIndex = 57
        Me.optDogAggressiveYes.TabStop = true
        Me.optDogAggressiveYes.Text = "Yes"
        Me.optDogAggressiveYes.UseVisualStyleBackColor = true
        '
        'optDogAggressiveNo
        '
        Me.optDogAggressiveNo.AutoSize = true
        Me.optDogAggressiveNo.Location = New System.Drawing.Point(86, 8)
        Me.optDogAggressiveNo.Name = "optDogAggressiveNo"
        Me.optDogAggressiveNo.Size = New System.Drawing.Size(38, 18)
        Me.optDogAggressiveNo.TabIndex = 58
        Me.optDogAggressiveNo.TabStop = true
        Me.optDogAggressiveNo.Text = "No"
        Me.optDogAggressiveNo.UseVisualStyleBackColor = true
        '
        'grpBittenBefore
        '
        Me.grpBittenBefore.Controls.Add(Me.optDogBitBeforeYes)
        Me.grpBittenBefore.Controls.Add(Me.optDogBitBeforeNo)
        Me.grpBittenBefore.Location = New System.Drawing.Point(439, 95)
        Me.grpBittenBefore.Name = "grpBittenBefore"
        Me.grpBittenBefore.Size = New System.Drawing.Size(184, 30)
        Me.grpBittenBefore.TabIndex = 67
        Me.grpBittenBefore.TabStop = false
        '
        'optDogBitBeforeYes
        '
        Me.optDogBitBeforeYes.AutoSize = true
        Me.optDogBitBeforeYes.Location = New System.Drawing.Point(11, 9)
        Me.optDogBitBeforeYes.Name = "optDogBitBeforeYes"
        Me.optDogBitBeforeYes.Size = New System.Drawing.Size(44, 18)
        Me.optDogBitBeforeYes.TabIndex = 61
        Me.optDogBitBeforeYes.TabStop = true
        Me.optDogBitBeforeYes.Text = "Yes"
        Me.optDogBitBeforeYes.UseVisualStyleBackColor = true
        '
        'optDogBitBeforeNo
        '
        Me.optDogBitBeforeNo.AutoSize = true
        Me.optDogBitBeforeNo.Location = New System.Drawing.Point(86, 9)
        Me.optDogBitBeforeNo.Name = "optDogBitBeforeNo"
        Me.optDogBitBeforeNo.Size = New System.Drawing.Size(38, 18)
        Me.optDogBitBeforeNo.TabIndex = 62
        Me.optDogBitBeforeNo.TabStop = true
        Me.optDogBitBeforeNo.Text = "No"
        Me.optDogBitBeforeNo.UseVisualStyleBackColor = true
        '
        'txtDogBiteDetails
        '
        Me.txtDogBiteDetails.Location = New System.Drawing.Point(9, 164)
        Me.txtDogBiteDetails.Name = "txtDogBiteDetails"
        Me.txtDogBiteDetails.Size = New System.Drawing.Size(687, 42)
        Me.txtDogBiteDetails.TabIndex = 52
        Me.txtDogBiteDetails.Text = ""
        '
        'txtDogBiteHistory
        '
        Me.txtDogBiteHistory.Location = New System.Drawing.Point(153, 126)
        Me.txtDogBiteHistory.Name = "txtDogBiteHistory"
        Me.txtDogBiteHistory.Size = New System.Drawing.Size(540, 20)
        Me.txtDogBiteHistory.TabIndex = 48
        '
        'lblDogBitesYard
        '
        Me.lblDogBitesYard.AutoSize = true
        Me.lblDogBitesYard.Location = New System.Drawing.Point(9, 76)
        Me.lblDogBitesYard.Name = "lblDogBitesYard"
        Me.lblDogBitesYard.Size = New System.Drawing.Size(413, 14)
        Me.lblDogBitesYard.TabIndex = 27
        Me.lblDogBitesYard.Text = "Were there precautionary measures taken to prevent the dog from leaving the yard?"& _ 
    ""
        '
        'lblDogBitesAggressive
        '
        Me.lblDogBitesAggressive.AutoSize = true
        Me.lblDogBitesAggressive.Location = New System.Drawing.Point(9, 47)
        Me.lblDogBitesAggressive.Name = "lblDogBitesAggressive"
        Me.lblDogBitesAggressive.Size = New System.Drawing.Size(164, 14)
        Me.lblDogBitesAggressive.TabIndex = 26
        Me.lblDogBitesAggressive.Text = "Is the dog aggressive of nature?"
        '
        'lblDogBiteBittenBefore
        '
        Me.lblDogBiteBittenBefore.AutoSize = true
        Me.lblDogBiteBittenBefore.Location = New System.Drawing.Point(9, 103)
        Me.lblDogBiteBittenBefore.Name = "lblDogBiteBittenBefore"
        Me.lblDogBiteBittenBefore.Size = New System.Drawing.Size(182, 14)
        Me.lblDogBiteBittenBefore.TabIndex = 25
        Me.lblDogBiteBittenBefore.Text = "Has the dog bitten someone before?"
        '
        'lblDogBite
        '
        Me.lblDogBite.AutoSize = true
        Me.lblDogBite.Location = New System.Drawing.Point(9, 129)
        Me.lblDogBite.Name = "lblDogBite"
        Me.lblDogBite.Size = New System.Drawing.Size(137, 14)
        Me.lblDogBite.TabIndex = 24
        Me.lblDogBite.Text = "Historical behaviour of Dog"
        '
        'lblClaimType
        '
        Me.lblClaimType.AutoSize = true
        Me.lblClaimType.Location = New System.Drawing.Point(9, 16)
        Me.lblClaimType.Name = "lblClaimType"
        Me.lblClaimType.Size = New System.Drawing.Size(58, 14)
        Me.lblClaimType.TabIndex = 22
        Me.lblClaimType.Text = "Claim Type"
        '
        'lblDogBitesDescription
        '
        Me.lblDogBitesDescription.AutoSize = true
        Me.lblDogBitesDescription.Location = New System.Drawing.Point(9, 149)
        Me.lblDogBitesDescription.Name = "lblDogBitesDescription"
        Me.lblDogBitesDescription.Size = New System.Drawing.Size(319, 14)
        Me.lblDogBitesDescription.TabIndex = 28
        Me.lblDogBitesDescription.Text = "Full details of what happened described by the owner and victim"
        '
        'grpPrecautionMeasure
        '
        Me.grpPrecautionMeasure.Controls.Add(Me.optDogYardYes)
        Me.grpPrecautionMeasure.Controls.Add(Me.optDogYardNo)
        Me.grpPrecautionMeasure.Location = New System.Drawing.Point(439, 66)
        Me.grpPrecautionMeasure.Name = "grpPrecautionMeasure"
        Me.grpPrecautionMeasure.Size = New System.Drawing.Size(184, 30)
        Me.grpPrecautionMeasure.TabIndex = 66
        Me.grpPrecautionMeasure.TabStop = false
        '
        'optDogYardYes
        '
        Me.optDogYardYes.AutoSize = true
        Me.optDogYardYes.Location = New System.Drawing.Point(11, 9)
        Me.optDogYardYes.Name = "optDogYardYes"
        Me.optDogYardYes.Size = New System.Drawing.Size(44, 18)
        Me.optDogYardYes.TabIndex = 59
        Me.optDogYardYes.TabStop = true
        Me.optDogYardYes.Text = "Yes"
        Me.optDogYardYes.UseVisualStyleBackColor = true
        '
        'optDogYardNo
        '
        Me.optDogYardNo.AutoSize = true
        Me.optDogYardNo.Location = New System.Drawing.Point(86, 9)
        Me.optDogYardNo.Name = "optDogYardNo"
        Me.optDogYardNo.Size = New System.Drawing.Size(38, 18)
        Me.optDogYardNo.TabIndex = 60
        Me.optDogYardNo.TabStop = true
        Me.optDogYardNo.Text = "No"
        Me.optDogYardNo.UseVisualStyleBackColor = true
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.optHitandRun)
        Me.GroupBox5.Controls.Add(Me.optDogBite)
        Me.GroupBox5.Location = New System.Drawing.Point(440, 7)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(184, 30)
        Me.GroupBox5.TabIndex = 63
        Me.GroupBox5.TabStop = false
        '
        'optHitandRun
        '
        Me.optHitandRun.AutoSize = true
        Me.optHitandRun.Location = New System.Drawing.Point(86, 8)
        Me.optHitandRun.Name = "optHitandRun"
        Me.optHitandRun.Size = New System.Drawing.Size(80, 18)
        Me.optHitandRun.TabIndex = 47
        Me.optHitandRun.TabStop = true
        Me.optHitandRun.Text = "Hit and Run"
        Me.optHitandRun.UseVisualStyleBackColor = true
        '
        'optDogBite
        '
        Me.optDogBite.AutoSize = true
        Me.optDogBite.Location = New System.Drawing.Point(11, 8)
        Me.optDogBite.Name = "optDogBite"
        Me.optDogBite.Size = New System.Drawing.Size(65, 18)
        Me.optDogBite.TabIndex = 46
        Me.optDogBite.TabStop = true
        Me.optDogBite.Text = "Dog Bite"
        Me.optDogBite.UseVisualStyleBackColor = true
        '
        'lblNumberofClaims
        '
        Me.lblNumberofClaims.AutoSize = true
        Me.lblNumberofClaims.Location = New System.Drawing.Point(29, 61)
        Me.lblNumberofClaims.Name = "lblNumberofClaims"
        Me.lblNumberofClaims.Size = New System.Drawing.Size(0, 14)
        Me.lblNumberofClaims.TabIndex = 138
        '
        'btnApply
        '
        Me.btnApply.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnApply.Location = New System.Drawing.Point(610, 640)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(77, 25)
        Me.btnApply.TabIndex = 139
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = false
        '
        'btnOKClaims
        '
        Me.btnOKClaims.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnOKClaims.Location = New System.Drawing.Point(527, 640)
        Me.btnOKClaims.Name = "btnOKClaims"
        Me.btnOKClaims.Size = New System.Drawing.Size(77, 25)
        Me.btnOKClaims.TabIndex = 140
        Me.btnOKClaims.Text = "OK"
        Me.btnOKClaims.UseVisualStyleBackColor = false
        '
        'btnCancelClaim
        '
        Me.btnCancelClaim.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnCancelClaim.Location = New System.Drawing.Point(692, 640)
        Me.btnCancelClaim.Name = "btnCancelClaim"
        Me.btnCancelClaim.Size = New System.Drawing.Size(77, 25)
        Me.btnCancelClaim.TabIndex = 141
        Me.btnCancelClaim.Text = "Cancel"
        Me.btnCancelClaim.UseVisualStyleBackColor = false
        '
        'frmClaimsList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 14!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 672)
        Me.ControlBox = false
        Me.Controls.Add(Me.btnCancelClaim)
        Me.Controls.Add(Me.btnOKClaims)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.lblNumberofClaims)
        Me.Controls.Add(Me.tabClaims)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnVoegby)
        Me.Controls.Add(Me.dgvClaims)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "frmClaimsList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Claims"
        CType(Me.dgvClaims,System.ComponentModel.ISupportInitialize).EndInit
        Me.MenuStrip1.ResumeLayout(false)
        Me.MenuStrip1.PerformLayout
        Me.tabClaims.ResumeLayout(false)
        Me.tabClaims1.ResumeLayout(false)
        Me.tabClaims1.PerformLayout
        Me.tabClaims2.ResumeLayout(false)
        Me.GroupBox11.ResumeLayout(false)
        Me.GroupBox11.PerformLayout
        CType(Me.dgvClaimJournals,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox10.ResumeLayout(false)
        Me.GroupBox10.PerformLayout
        CType(Me.dgvClaimIncome,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox9.ResumeLayout(false)
        Me.GroupBox9.PerformLayout
        CType(Me.dgvPayments,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabClaims3.ResumeLayout(false)
        Me.TabClaims3.PerformLayout
        CType(Me.dgvClaimAssessors,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabClaims4.ResumeLayout(false)
        Me.TabClaims4.PerformLayout
        Me.grpExGratia.ResumeLayout(false)
        Me.grpExGratia.PerformLayout
        CType(Me.dgvClaimEstimate,System.ComponentModel.ISupportInitialize).EndInit
        Me.grpVehicle.ResumeLayout(false)
        Me.grpVehicle.PerformLayout
        Me.GroupBox4.ResumeLayout(false)
        Me.GroupBox4.PerformLayout
        Me.GroupBox3.ResumeLayout(false)
        Me.GroupBox3.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.grpDogBite.ResumeLayout(false)
        Me.grpDogBite.PerformLayout
        Me.grpDogAggressive.ResumeLayout(false)
        Me.grpDogAggressive.PerformLayout
        Me.grpBittenBefore.ResumeLayout(false)
        Me.grpBittenBefore.PerformLayout
        Me.grpPrecautionMeasure.ResumeLayout(false)
        Me.grpPrecautionMeasure.PerformLayout
        Me.GroupBox5.ResumeLayout(false)
        Me.GroupBox5.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents dgvClaims As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtExcess As System.Windows.Forms.TextBox
    Public WithEvents btnEdit As System.Windows.Forms.Button
    Public WithEvents btnVoegby As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbReinsurer As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ClaimFormsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClaimHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClaimHistoryToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PremiumVsClaimsReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AgreementOfLossToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClaimPaymentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CatastrophesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssessorsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BeneficiariesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabClaims As System.Windows.Forms.TabControl
    Friend WithEvents tabClaims1 As System.Windows.Forms.TabPage
    Friend WithEvents txtPostalCode As System.Windows.Forms.TextBox
    Friend WithEvents txtTown As System.Windows.Forms.TextBox
    Friend WithEvents txtSubburb As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtShortClaimDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbClaimClassType As System.Windows.Forms.ComboBox
    Friend WithEvents cmbClaimType As System.Windows.Forms.ComboBox
    Friend WithEvents txtClaimDescription4 As System.Windows.Forms.TextBox
    Friend WithEvents txtClaimDescription3 As System.Windows.Forms.TextBox
    Friend WithEvents dtpClaimCompletionDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpClaimReportDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpClaimDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtClaimAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtClaimnumber As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tabClaims2 As System.Windows.Forms.TabPage
    Friend WithEvents TabClaims3 As System.Windows.Forms.TabPage
    Public WithEvents btnPaymentsDelete As System.Windows.Forms.Button
    Public WithEvents btnPaymentsEdit As System.Windows.Forms.Button
    Public WithEvents btnPaymentsAdd As System.Windows.Forms.Button
    Friend WithEvents dgvPayments As System.Windows.Forms.DataGridView
    Friend WithEvents lblNumberofClaims As System.Windows.Forms.Label
    Friend WithEvents TabClaims4 As System.Windows.Forms.TabPage
    Friend WithEvents lblThunder As System.Windows.Forms.Label
    Friend WithEvents lblVehicleWrittenoff As System.Windows.Forms.Label
    Friend WithEvents lblDriverIDNr As System.Windows.Forms.Label
    Friend WithEvents lblAlcoholSubstanceAbuse As System.Windows.Forms.Label
    Friend WithEvents lblWhereVehicleFound As System.Windows.Forms.Label
    Friend WithEvents lblVehicleUse As System.Windows.Forms.Label
    Friend WithEvents lblDamageAmount As System.Windows.Forms.Label
    Friend WithEvents lblVehicleFound As System.Windows.Forms.Label
    Friend WithEvents lblTypeofCover As System.Windows.Forms.Label
    Friend WithEvents lblSecurity As System.Windows.Forms.Label
    Friend WithEvents lblKnockforKnock As System.Windows.Forms.Label
    Friend WithEvents lblExGratia As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbCatastrophe As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents grpVehicle As System.Windows.Forms.GroupBox
    Friend WithEvents txtWhereVehicleFound As System.Windows.Forms.TextBox
    Friend WithEvents txtVehicleUse As System.Windows.Forms.TextBox
    Friend WithEvents txtDamageAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtTypeofCover As System.Windows.Forms.TextBox
    Friend WithEvents txtDriverIDnr As System.Windows.Forms.TextBox
    Friend WithEvents optThunderNo As System.Windows.Forms.RadioButton
    Friend WithEvents optThunderYes As System.Windows.Forms.RadioButton
    Friend WithEvents cmdCatastrophe As System.Windows.Forms.Button
    Friend WithEvents dgvClaimEstimate As System.Windows.Forms.DataGridView
    Friend WithEvents ClaimEstimateAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClaimEstimateDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents optWriteoffNo As System.Windows.Forms.RadioButton
    Friend WithEvents optWriteoffYes As System.Windows.Forms.RadioButton
    Friend WithEvents optAlcoholNo As System.Windows.Forms.RadioButton
    Friend WithEvents optAlcoholYes As System.Windows.Forms.RadioButton
    Friend WithEvents optVehicleFoundNo As System.Windows.Forms.RadioButton
    Friend WithEvents optVehiclefoundYes As System.Windows.Forms.RadioButton
    Friend WithEvents optKnockNo As System.Windows.Forms.RadioButton
    Friend WithEvents optKnockYes As System.Windows.Forms.RadioButton
    Friend WithEvents optExGratiaNo As System.Windows.Forms.RadioButton
    Friend WithEvents optExgratiaYes As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstSecurity As System.Windows.Forms.ListBox
    Friend WithEvents lblActualClaimAmount As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Public WithEvents btnIncomeDelete As System.Windows.Forms.Button
    Public WithEvents btnIncomeEdit As System.Windows.Forms.Button
    Friend WithEvents dgvClaimIncome As System.Windows.Forms.DataGridView
    Public WithEvents btnIncomeAdd As System.Windows.Forms.Button
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Public WithEvents btnJournalDelete As System.Windows.Forms.Button
    Public WithEvents btnJournalEdit As System.Windows.Forms.Button
    Friend WithEvents dgvClaimJournals As System.Windows.Forms.DataGridView
    Public WithEvents btnIncomeJournal As System.Windows.Forms.Button
    Public WithEvents btnPaymentsJournal As System.Windows.Forms.Button
    Friend WithEvents lblClaimOutstandingAmount As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents PaymentAdvisoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ElectronicPaymentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbClaimSubstatus As System.Windows.Forms.ComboBox
    Friend WithEvents cmbClaimStatus As System.Windows.Forms.ComboBox
    Friend WithEvents dgvClaimAssessors As System.Windows.Forms.DataGridView
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Public WithEvents btnAssessorAdd As System.Windows.Forms.Button
    Public WithEvents btnAssessorDelete As System.Windows.Forms.Button
    Friend WithEvents pkAssessorsperClaim As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssessorName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnPostalcodes As System.Windows.Forms.Button
    Friend WithEvents txtBroker As System.Windows.Forms.TextBox
    Friend WithEvents Claimnumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClaimDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Classification As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubClass As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Details As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IncomeDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CancelIcon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceReferenceNr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pkIncome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grpDogBite As System.Windows.Forms.GroupBox
    Friend WithEvents grpDogAggressive As System.Windows.Forms.GroupBox
    Friend WithEvents optDogAggressiveYes As System.Windows.Forms.RadioButton
    Friend WithEvents optDogAggressiveNo As System.Windows.Forms.RadioButton
    Friend WithEvents grpBittenBefore As System.Windows.Forms.GroupBox
    Friend WithEvents optDogBitBeforeYes As System.Windows.Forms.RadioButton
    Friend WithEvents optDogBitBeforeNo As System.Windows.Forms.RadioButton
    Friend WithEvents txtDogBiteDetails As System.Windows.Forms.RichTextBox
    Friend WithEvents txtDogBiteHistory As System.Windows.Forms.TextBox
    Friend WithEvents lblDogBitesYard As System.Windows.Forms.Label
    Friend WithEvents lblDogBitesAggressive As System.Windows.Forms.Label
    Friend WithEvents lblDogBiteBittenBefore As System.Windows.Forms.Label
    Friend WithEvents lblDogBite As System.Windows.Forms.Label
    Friend WithEvents lblClaimType As System.Windows.Forms.Label
    Friend WithEvents lblDogBitesDescription As System.Windows.Forms.Label
    Friend WithEvents grpPrecautionMeasure As System.Windows.Forms.GroupBox
    Friend WithEvents optDogYardYes As System.Windows.Forms.RadioButton
    Friend WithEvents optDogYardNo As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents optHitandRun As System.Windows.Forms.RadioButton
    Friend WithEvents optDogBite As System.Windows.Forms.RadioButton
    Friend WithEvents JTjekBesonderhede As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TjekofElektronies As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JVord_premie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JVord_dat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CancelledIcon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kruisverwysing As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pkJoernale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grpExGratia As System.Windows.Forms.GroupBox
    Friend WithEvents TjekBesonderhede As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipePayment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vord_premie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vord_dat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GekansIcon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tjekno_uit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pkPayments As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nedlopie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblTotalJournal As System.Windows.Forms.Label
    Friend WithEvents lblTotalIncome As System.Windows.Forms.Label
    Friend WithEvents lblTotalPayments As System.Windows.Forms.Label
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents btnOKClaims As System.Windows.Forms.Button
    Friend WithEvents btnCancelClaim As System.Windows.Forms.Button
End Class
