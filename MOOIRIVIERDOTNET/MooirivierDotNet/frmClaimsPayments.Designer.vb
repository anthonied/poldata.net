<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClaimsPayments
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.chkCancel = New System.Windows.Forms.CheckBox()
        Me.lblCancel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkVAT = New System.Windows.Forms.CheckBox()
        Me.dtpPaymentDate = New System.Windows.Forms.DateTimePicker()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.txtAmountWithoutVat = New System.Windows.Forms.TextBox()
        Me.txtVatAmount = New System.Windows.Forms.TextBox()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.txtInvRefNr = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.TabPayment = New System.Windows.Forms.TabControl()
        Me.TabPaymentInfo = New System.Windows.Forms.TabPage()
        Me.txtVATNumber = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtFaktuurnr = New System.Windows.Forms.TextBox()
        Me.txtOldChecqueNr = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabPaymentBeneficiary = New System.Windows.Forms.TabPage()
        Me.txtStuurDMV = New System.Windows.Forms.TextBox()
        Me.cmdStoredBeneficiary = New System.Windows.Forms.Button()
        Me.optStoredBeneficiary = New System.Windows.Forms.RadioButton()
        Me.optNonRecurrent = New System.Windows.Forms.RadioButton()
        Me.optClient = New System.Windows.Forms.RadioButton()
        Me.cmbAccType = New System.Windows.Forms.ComboBox()
        Me.txtAccNumber = New System.Windows.Forms.TextBox()
        Me.lblAccType = New System.Windows.Forms.Label()
        Me.lblAccNumber = New System.Windows.Forms.Label()
        Me.txtPkBnkCodes = New System.Windows.Forms.TextBox()
        Me.btnBanke = New System.Windows.Forms.Button()
        Me.txtBranchCode = New System.Windows.Forms.TextBox()
        Me.txtBranch = New System.Windows.Forms.TextBox()
        Me.txtBank = New System.Windows.Forms.TextBox()
        Me.lblBranchCode = New System.Windows.Forms.Label()
        Me.lblBranch = New System.Windows.Forms.Label()
        Me.lblBank = New System.Windows.Forms.Label()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtBenDetails = New System.Windows.Forms.TextBox()
        Me.TabPaymentProcurement = New System.Windows.Forms.TabPage()
        Me.cmbSpecialityofService = New System.Windows.Forms.ComboBox()
        Me.cmbSubCategoryofService = New System.Windows.Forms.ComboBox()
        Me.cmbCategoryofService = New System.Windows.Forms.ComboBox()
        Me.cmbPayeeId = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkElectronicRunFinished = New System.Windows.Forms.CheckBox()
        Me.TabPayment.SuspendLayout()
        Me.TabPaymentInfo.SuspendLayout()
        Me.TabPaymentBeneficiary.SuspendLayout()
        Me.TabPaymentProcurement.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOK.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOK.Location = New System.Drawing.Point(484, 464)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOK.Size = New System.Drawing.Size(77, 25)
        Me.btnOK.TabIndex = 29
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(565, 464)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(77, 25)
        Me.btnCancel.TabIndex = 30
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'chkCancel
        '
        Me.chkCancel.AutoSize = True
        Me.chkCancel.Location = New System.Drawing.Point(161, 77)
        Me.chkCancel.Name = "chkCancel"
        Me.chkCancel.Size = New System.Drawing.Size(15, 14)
        Me.chkCancel.TabIndex = 2
        Me.chkCancel.UseVisualStyleBackColor = True
        '
        'lblCancel
        '
        Me.lblCancel.AutoSize = True
        Me.lblCancel.Location = New System.Drawing.Point(12, 78)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(40, 14)
        Me.lblCancel.TabIndex = 181
        Me.lblCancel.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 14)
        Me.Label1.TabIndex = 180
        Me.Label1.Text = "Claim Payments"
        '
        'chkVAT
        '
        Me.chkVAT.AutoSize = True
        Me.chkVAT.Location = New System.Drawing.Point(204, 94)
        Me.chkVAT.Name = "chkVAT"
        Me.chkVAT.Size = New System.Drawing.Size(15, 14)
        Me.chkVAT.TabIndex = 9
        Me.chkVAT.UseVisualStyleBackColor = True
        '
        'dtpPaymentDate
        '
        Me.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPaymentDate.Location = New System.Drawing.Point(204, 188)
        Me.dtpPaymentDate.Name = "dtpPaymentDate"
        Me.dtpPaymentDate.Size = New System.Drawing.Size(116, 20)
        Me.dtpPaymentDate.TabIndex = 13
        '
        'cmbType
        '
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(161, 48)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(170, 22)
        Me.cmbType.TabIndex = 1
        '
        'txtAmountWithoutVat
        '
        Me.txtAmountWithoutVat.Location = New System.Drawing.Point(204, 138)
        Me.txtAmountWithoutVat.Name = "txtAmountWithoutVat"
        Me.txtAmountWithoutVat.Size = New System.Drawing.Size(128, 20)
        Me.txtAmountWithoutVat.TabIndex = 11
        '
        'txtVatAmount
        '
        Me.txtVatAmount.Location = New System.Drawing.Point(204, 113)
        Me.txtVatAmount.Name = "txtVatAmount"
        Me.txtVatAmount.Size = New System.Drawing.Size(128, 20)
        Me.txtVatAmount.TabIndex = 10
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(204, 69)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(128, 20)
        Me.txtAmount.TabIndex = 8
        '
        'txtInvRefNr
        '
        Me.txtInvRefNr.Location = New System.Drawing.Point(204, 18)
        Me.txtInvRefNr.Name = "txtInvRefNr"
        Me.txtInvRefNr.Size = New System.Drawing.Size(167, 20)
        Me.txtInvRefNr.TabIndex = 5
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(12, 52)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(87, 14)
        Me.Label24.TabIndex = 163
        Me.Label24.Text = "Type of Payment"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 193)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(29, 14)
        Me.Label22.TabIndex = 161
        Me.Label22.Text = "Date"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 141)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(106, 14)
        Me.Label21.TabIndex = 160
        Me.Label21.Text = "Amount without VAT"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 116)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(66, 14)
        Me.Label20.TabIndex = 159
        Me.Label20.Text = "VAT Amount"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 94)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(27, 14)
        Me.Label19.TabIndex = 158
        Me.Label19.Text = "VAT"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 72)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 14)
        Me.Label18.TabIndex = 157
        Me.Label18.Text = "Amount"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 21)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(118, 14)
        Me.Label17.TabIndex = 156
        Me.Label17.Text = "Payment Reference No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 240)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 14)
        Me.Label2.TabIndex = 183
        Me.Label2.Text = "Fax"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 267)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 14)
        Me.Label3.TabIndex = 184
        Me.Label3.Text = "Email"
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(132, 237)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(161, 20)
        Me.txtFax.TabIndex = 23
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(132, 264)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(390, 20)
        Me.txtEmail.TabIndex = 24
        '
        'TabPayment
        '
        Me.TabPayment.Controls.Add(Me.TabPaymentInfo)
        Me.TabPayment.Controls.Add(Me.TabPaymentBeneficiary)
        Me.TabPayment.Controls.Add(Me.TabPaymentProcurement)
        Me.TabPayment.Location = New System.Drawing.Point(15, 134)
        Me.TabPayment.Name = "TabPayment"
        Me.TabPayment.SelectedIndex = 0
        Me.TabPayment.Size = New System.Drawing.Size(627, 324)
        Me.TabPayment.TabIndex = 187
        '
        'TabPaymentInfo
        '
        Me.TabPaymentInfo.Controls.Add(Me.txtVATNumber)
        Me.TabPaymentInfo.Controls.Add(Me.Label14)
        Me.TabPaymentInfo.Controls.Add(Me.txtFaktuurnr)
        Me.TabPaymentInfo.Controls.Add(Me.txtOldChecqueNr)
        Me.TabPaymentInfo.Controls.Add(Me.Label5)
        Me.TabPaymentInfo.Controls.Add(Me.Label4)
        Me.TabPaymentInfo.Controls.Add(Me.Label17)
        Me.TabPaymentInfo.Controls.Add(Me.txtInvRefNr)
        Me.TabPaymentInfo.Controls.Add(Me.Label18)
        Me.TabPaymentInfo.Controls.Add(Me.Label19)
        Me.TabPaymentInfo.Controls.Add(Me.Label20)
        Me.TabPaymentInfo.Controls.Add(Me.Label21)
        Me.TabPaymentInfo.Controls.Add(Me.Label22)
        Me.TabPaymentInfo.Controls.Add(Me.chkVAT)
        Me.TabPaymentInfo.Controls.Add(Me.txtAmount)
        Me.TabPaymentInfo.Controls.Add(Me.dtpPaymentDate)
        Me.TabPaymentInfo.Controls.Add(Me.txtVatAmount)
        Me.TabPaymentInfo.Controls.Add(Me.txtAmountWithoutVat)
        Me.TabPaymentInfo.Location = New System.Drawing.Point(4, 23)
        Me.TabPaymentInfo.Name = "TabPaymentInfo"
        Me.TabPaymentInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPaymentInfo.Size = New System.Drawing.Size(619, 297)
        Me.TabPaymentInfo.TabIndex = 0
        Me.TabPaymentInfo.Text = "Payment Info"
        Me.TabPaymentInfo.UseVisualStyleBackColor = True
        '
        'txtVATNumber
        '
        Me.txtVATNumber.Location = New System.Drawing.Point(204, 163)
        Me.txtVATNumber.Name = "txtVATNumber"
        Me.txtVATNumber.Size = New System.Drawing.Size(167, 20)
        Me.txtVATNumber.TabIndex = 12
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 166)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 14)
        Me.Label14.TabIndex = 179
        Me.Label14.Text = "VAT Number"
        '
        'txtFaktuurnr
        '
        Me.txtFaktuurnr.Location = New System.Drawing.Point(204, 44)
        Me.txtFaktuurnr.Name = "txtFaktuurnr"
        Me.txtFaktuurnr.Size = New System.Drawing.Size(167, 20)
        Me.txtFaktuurnr.TabIndex = 7
        '
        'txtOldChecqueNr
        '
        Me.txtOldChecqueNr.Enabled = False
        Me.txtOldChecqueNr.Location = New System.Drawing.Point(204, 214)
        Me.txtOldChecqueNr.Name = "txtOldChecqueNr"
        Me.txtOldChecqueNr.Size = New System.Drawing.Size(167, 20)
        Me.txtOldChecqueNr.TabIndex = 6
        Me.txtOldChecqueNr.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 14)
        Me.Label5.TabIndex = 173
        Me.Label5.Text = "Invoice no"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 217)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 14)
        Me.Label4.TabIndex = 172
        Me.Label4.Text = "Old Checque No"
        Me.Label4.Visible = False
        '
        'TabPaymentBeneficiary
        '
        Me.TabPaymentBeneficiary.Controls.Add(Me.txtStuurDMV)
        Me.TabPaymentBeneficiary.Controls.Add(Me.cmdStoredBeneficiary)
        Me.TabPaymentBeneficiary.Controls.Add(Me.optStoredBeneficiary)
        Me.TabPaymentBeneficiary.Controls.Add(Me.optNonRecurrent)
        Me.TabPaymentBeneficiary.Controls.Add(Me.optClient)
        Me.TabPaymentBeneficiary.Controls.Add(Me.cmbAccType)
        Me.TabPaymentBeneficiary.Controls.Add(Me.txtAccNumber)
        Me.TabPaymentBeneficiary.Controls.Add(Me.lblAccType)
        Me.TabPaymentBeneficiary.Controls.Add(Me.lblAccNumber)
        Me.TabPaymentBeneficiary.Controls.Add(Me.txtPkBnkCodes)
        Me.TabPaymentBeneficiary.Controls.Add(Me.btnBanke)
        Me.TabPaymentBeneficiary.Controls.Add(Me.txtBranchCode)
        Me.TabPaymentBeneficiary.Controls.Add(Me.txtBranch)
        Me.TabPaymentBeneficiary.Controls.Add(Me.txtBank)
        Me.TabPaymentBeneficiary.Controls.Add(Me.lblBranchCode)
        Me.TabPaymentBeneficiary.Controls.Add(Me.lblBranch)
        Me.TabPaymentBeneficiary.Controls.Add(Me.lblBank)
        Me.TabPaymentBeneficiary.Controls.Add(Me.cmbCategory)
        Me.TabPaymentBeneficiary.Controls.Add(Me.Label12)
        Me.TabPaymentBeneficiary.Controls.Add(Me.Label11)
        Me.TabPaymentBeneficiary.Controls.Add(Me.txtBenDetails)
        Me.TabPaymentBeneficiary.Controls.Add(Me.Label2)
        Me.TabPaymentBeneficiary.Controls.Add(Me.Label3)
        Me.TabPaymentBeneficiary.Controls.Add(Me.txtFax)
        Me.TabPaymentBeneficiary.Controls.Add(Me.txtEmail)
        Me.TabPaymentBeneficiary.Location = New System.Drawing.Point(4, 23)
        Me.TabPaymentBeneficiary.Name = "TabPaymentBeneficiary"
        Me.TabPaymentBeneficiary.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPaymentBeneficiary.Size = New System.Drawing.Size(619, 297)
        Me.TabPaymentBeneficiary.TabIndex = 1
        Me.TabPaymentBeneficiary.Text = "Beneficiary"
        Me.TabPaymentBeneficiary.UseVisualStyleBackColor = True
        '
        'txtStuurDMV
        '
        Me.txtStuurDMV.Location = New System.Drawing.Point(442, 192)
        Me.txtStuurDMV.Name = "txtStuurDMV"
        Me.txtStuurDMV.Size = New System.Drawing.Size(100, 20)
        Me.txtStuurDMV.TabIndex = 210
        Me.txtStuurDMV.Visible = False
        '
        'cmdStoredBeneficiary
        '
        Me.cmdStoredBeneficiary.Location = New System.Drawing.Point(462, 72)
        Me.cmdStoredBeneficiary.Name = "cmdStoredBeneficiary"
        Me.cmdStoredBeneficiary.Size = New System.Drawing.Size(121, 25)
        Me.cmdStoredBeneficiary.TabIndex = 19
        Me.cmdStoredBeneficiary.Text = "Stored Beneficiaries"
        Me.cmdStoredBeneficiary.UseVisualStyleBackColor = True
        '
        'optStoredBeneficiary
        '
        Me.optStoredBeneficiary.AutoSize = True
        Me.optStoredBeneficiary.Location = New System.Drawing.Point(337, 75)
        Me.optStoredBeneficiary.Name = "optStoredBeneficiary"
        Me.optStoredBeneficiary.Size = New System.Drawing.Size(115, 18)
        Me.optStoredBeneficiary.TabIndex = 18
        Me.optStoredBeneficiary.TabStop = True
        Me.optStoredBeneficiary.Text = "Stored Beneficiary"
        Me.optStoredBeneficiary.UseVisualStyleBackColor = True
        '
        'optNonRecurrent
        '
        Me.optNonRecurrent.AutoSize = True
        Me.optNonRecurrent.Location = New System.Drawing.Point(222, 75)
        Me.optNonRecurrent.Name = "optNonRecurrent"
        Me.optNonRecurrent.Size = New System.Drawing.Size(93, 18)
        Me.optNonRecurrent.TabIndex = 17
        Me.optNonRecurrent.TabStop = True
        Me.optNonRecurrent.Text = "Non-recurrent"
        Me.optNonRecurrent.UseVisualStyleBackColor = True
        '
        'optClient
        '
        Me.optClient.AutoSize = True
        Me.optClient.Location = New System.Drawing.Point(135, 75)
        Me.optClient.Name = "optClient"
        Me.optClient.Size = New System.Drawing.Size(51, 18)
        Me.optClient.TabIndex = 16
        Me.optClient.TabStop = True
        Me.optClient.Text = "Client"
        Me.optClient.UseVisualStyleBackColor = True
        '
        'cmbAccType
        '
        Me.cmbAccType.BackColor = System.Drawing.SystemColors.Window
        Me.cmbAccType.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbAccType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAccType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbAccType.Location = New System.Drawing.Point(132, 127)
        Me.cmbAccType.Name = "cmbAccType"
        Me.cmbAccType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbAccType.Size = New System.Drawing.Size(161, 22)
        Me.cmbAccType.TabIndex = 21
        '
        'txtAccNumber
        '
        Me.txtAccNumber.AcceptsReturn = True
        Me.txtAccNumber.BackColor = System.Drawing.SystemColors.Window
        Me.txtAccNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAccNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAccNumber.Location = New System.Drawing.Point(132, 100)
        Me.txtAccNumber.MaxLength = 15
        Me.txtAccNumber.Name = "txtAccNumber"
        Me.txtAccNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAccNumber.Size = New System.Drawing.Size(161, 20)
        Me.txtAccNumber.TabIndex = 20
        '
        'lblAccType
        '
        Me.lblAccType.BackColor = System.Drawing.SystemColors.Window
        Me.lblAccType.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAccType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAccType.Location = New System.Drawing.Point(8, 132)
        Me.lblAccType.Name = "lblAccType"
        Me.lblAccType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAccType.Size = New System.Drawing.Size(108, 13)
        Me.lblAccType.TabIndex = 204
        Me.lblAccType.Text = "Account Type"
        '
        'lblAccNumber
        '
        Me.lblAccNumber.BackColor = System.Drawing.SystemColors.Window
        Me.lblAccNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAccNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAccNumber.Location = New System.Drawing.Point(6, 104)
        Me.lblAccNumber.Name = "lblAccNumber"
        Me.lblAccNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAccNumber.Size = New System.Drawing.Size(108, 13)
        Me.lblAccNumber.TabIndex = 203
        Me.lblAccNumber.Text = "Account no"
        '
        'txtPkBnkCodes
        '
        Me.txtPkBnkCodes.AcceptsReturn = True
        Me.txtPkBnkCodes.BackColor = System.Drawing.SystemColors.Window
        Me.txtPkBnkCodes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPkBnkCodes.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPkBnkCodes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPkBnkCodes.Location = New System.Drawing.Point(442, 152)
        Me.txtPkBnkCodes.MaxLength = 0
        Me.txtPkBnkCodes.Name = "txtPkBnkCodes"
        Me.txtPkBnkCodes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPkBnkCodes.Size = New System.Drawing.Size(141, 20)
        Me.txtPkBnkCodes.TabIndex = 198
        Me.txtPkBnkCodes.TabStop = False
        Me.txtPkBnkCodes.Text = "0"
        Me.txtPkBnkCodes.Visible = False
        '
        'btnBanke
        '
        Me.btnBanke.BackColor = System.Drawing.SystemColors.Control
        Me.btnBanke.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnBanke.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBanke.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBanke.Location = New System.Drawing.Point(316, 156)
        Me.btnBanke.Name = "btnBanke"
        Me.btnBanke.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnBanke.Size = New System.Drawing.Size(67, 22)
        Me.btnBanke.TabIndex = 22
        Me.btnBanke.Text = "Banks ..."
        Me.btnBanke.UseVisualStyleBackColor = False
        '
        'txtBranchCode
        '
        Me.txtBranchCode.AcceptsReturn = True
        Me.txtBranchCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtBranchCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBranchCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranchCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBranchCode.Location = New System.Drawing.Point(132, 210)
        Me.txtBranchCode.MaxLength = 0
        Me.txtBranchCode.Name = "txtBranchCode"
        Me.txtBranchCode.ReadOnly = True
        Me.txtBranchCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBranchCode.Size = New System.Drawing.Size(85, 20)
        Me.txtBranchCode.TabIndex = 194
        Me.txtBranchCode.TabStop = False
        '
        'txtBranch
        '
        Me.txtBranch.AcceptsReturn = True
        Me.txtBranch.BackColor = System.Drawing.SystemColors.Window
        Me.txtBranch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBranch.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranch.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBranch.Location = New System.Drawing.Point(132, 183)
        Me.txtBranch.MaxLength = 0
        Me.txtBranch.Name = "txtBranch"
        Me.txtBranch.ReadOnly = True
        Me.txtBranch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBranch.Size = New System.Drawing.Size(241, 20)
        Me.txtBranch.TabIndex = 193
        Me.txtBranch.TabStop = False
        '
        'txtBank
        '
        Me.txtBank.AcceptsReturn = True
        Me.txtBank.BackColor = System.Drawing.SystemColors.Window
        Me.txtBank.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBank.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBank.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBank.Location = New System.Drawing.Point(132, 156)
        Me.txtBank.MaxLength = 0
        Me.txtBank.Name = "txtBank"
        Me.txtBank.ReadOnly = True
        Me.txtBank.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBank.Size = New System.Drawing.Size(161, 20)
        Me.txtBank.TabIndex = 192
        Me.txtBank.TabStop = False
        '
        'lblBranchCode
        '
        Me.lblBranchCode.BackColor = System.Drawing.SystemColors.Window
        Me.lblBranchCode.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblBranchCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBranchCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBranchCode.Location = New System.Drawing.Point(8, 212)
        Me.lblBranchCode.Name = "lblBranchCode"
        Me.lblBranchCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBranchCode.Size = New System.Drawing.Size(104, 17)
        Me.lblBranchCode.TabIndex = 197
        Me.lblBranchCode.Text = "Branch code"
        '
        'lblBranch
        '
        Me.lblBranch.BackColor = System.Drawing.SystemColors.Window
        Me.lblBranch.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblBranch.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBranch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBranch.Location = New System.Drawing.Point(8, 187)
        Me.lblBranch.Name = "lblBranch"
        Me.lblBranch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBranch.Size = New System.Drawing.Size(108, 13)
        Me.lblBranch.TabIndex = 196
        Me.lblBranch.Text = "Branch"
        '
        'lblBank
        '
        Me.lblBank.BackColor = System.Drawing.SystemColors.Window
        Me.lblBank.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblBank.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBank.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBank.Location = New System.Drawing.Point(8, 160)
        Me.lblBank.Name = "lblBank"
        Me.lblBank.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBank.Size = New System.Drawing.Size(108, 13)
        Me.lblBank.TabIndex = 195
        Me.lblBank.Text = "Bank"
        '
        'cmbCategory
        '
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(132, 19)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(292, 22)
        Me.cmbCategory.TabIndex = 14
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 14)
        Me.Label12.TabIndex = 189
        Me.Label12.Text = "Category"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 14)
        Me.Label11.TabIndex = 187
        Me.Label11.Text = "Beneficiary name"
        '
        'txtBenDetails
        '
        Me.txtBenDetails.Location = New System.Drawing.Point(132, 48)
        Me.txtBenDetails.Name = "txtBenDetails"
        Me.txtBenDetails.Size = New System.Drawing.Size(293, 20)
        Me.txtBenDetails.TabIndex = 15
        '
        'TabPaymentProcurement
        '
        Me.TabPaymentProcurement.Controls.Add(Me.cmbSpecialityofService)
        Me.TabPaymentProcurement.Controls.Add(Me.cmbSubCategoryofService)
        Me.TabPaymentProcurement.Controls.Add(Me.cmbCategoryofService)
        Me.TabPaymentProcurement.Controls.Add(Me.cmbPayeeId)
        Me.TabPaymentProcurement.Controls.Add(Me.Label10)
        Me.TabPaymentProcurement.Controls.Add(Me.Label9)
        Me.TabPaymentProcurement.Controls.Add(Me.Label8)
        Me.TabPaymentProcurement.Controls.Add(Me.Label7)
        Me.TabPaymentProcurement.Location = New System.Drawing.Point(4, 23)
        Me.TabPaymentProcurement.Name = "TabPaymentProcurement"
        Me.TabPaymentProcurement.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPaymentProcurement.Size = New System.Drawing.Size(619, 297)
        Me.TabPaymentProcurement.TabIndex = 2
        Me.TabPaymentProcurement.Text = "Procurement"
        Me.TabPaymentProcurement.UseVisualStyleBackColor = True
        '
        'cmbSpecialityofService
        '
        Me.cmbSpecialityofService.FormattingEnabled = True
        Me.cmbSpecialityofService.Location = New System.Drawing.Point(174, 101)
        Me.cmbSpecialityofService.Name = "cmbSpecialityofService"
        Me.cmbSpecialityofService.Size = New System.Drawing.Size(257, 22)
        Me.cmbSpecialityofService.TabIndex = 28
        '
        'cmbSubCategoryofService
        '
        Me.cmbSubCategoryofService.FormattingEnabled = True
        Me.cmbSubCategoryofService.Location = New System.Drawing.Point(174, 76)
        Me.cmbSubCategoryofService.Name = "cmbSubCategoryofService"
        Me.cmbSubCategoryofService.Size = New System.Drawing.Size(257, 22)
        Me.cmbSubCategoryofService.TabIndex = 27
        '
        'cmbCategoryofService
        '
        Me.cmbCategoryofService.FormattingEnabled = True
        Me.cmbCategoryofService.Location = New System.Drawing.Point(174, 51)
        Me.cmbCategoryofService.Name = "cmbCategoryofService"
        Me.cmbCategoryofService.Size = New System.Drawing.Size(257, 22)
        Me.cmbCategoryofService.TabIndex = 26
        '
        'cmbPayeeId
        '
        Me.cmbPayeeId.FormattingEnabled = True
        Me.cmbPayeeId.Location = New System.Drawing.Point(174, 26)
        Me.cmbPayeeId.Name = "cmbPayeeId"
        Me.cmbPayeeId.Size = New System.Drawing.Size(257, 22)
        Me.cmbPayeeId.TabIndex = 25
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 105)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(149, 14)
        Me.Label10.TabIndex = 156
        Me.Label10.Text = "Speciality of Service Provider"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(126, 14)
        Me.Label9.TabIndex = 155
        Me.Label9.Text = "Sub Category of Service"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 14)
        Me.Label8.TabIndex = 154
        Me.Label8.Text = "Category of Service"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 14)
        Me.Label7.TabIndex = 153
        Me.Label7.Text = "Payee Identification"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 14)
        Me.Label6.TabIndex = 188
        Me.Label6.Text = "Electronic Run Finished"
        '
        'chkElectronicRunFinished
        '
        Me.chkElectronicRunFinished.AutoSize = True
        Me.chkElectronicRunFinished.Location = New System.Drawing.Point(161, 103)
        Me.chkElectronicRunFinished.Name = "chkElectronicRunFinished"
        Me.chkElectronicRunFinished.Size = New System.Drawing.Size(15, 14)
        Me.chkElectronicRunFinished.TabIndex = 3
        Me.chkElectronicRunFinished.UseVisualStyleBackColor = True
        '
        'frmClaimsPayments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(649, 496)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkElectronicRunFinished)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TabPayment)
        Me.Controls.Add(Me.chkCancel)
        Me.Controls.Add(Me.lblCancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbType)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmClaimsPayments"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Claims Payments"
        Me.TabPayment.ResumeLayout(False)
        Me.TabPaymentInfo.ResumeLayout(False)
        Me.TabPaymentInfo.PerformLayout()
        Me.TabPaymentBeneficiary.ResumeLayout(False)
        Me.TabPaymentBeneficiary.PerformLayout()
        Me.TabPaymentProcurement.ResumeLayout(False)
        Me.TabPaymentProcurement.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents btnOK As System.Windows.Forms.Button
    Public WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents chkCancel As System.Windows.Forms.CheckBox
    Friend WithEvents lblCancel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkVAT As System.Windows.Forms.CheckBox
    Friend WithEvents dtpPaymentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents txtAmountWithoutVat As System.Windows.Forms.TextBox
    Friend WithEvents txtVatAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtInvRefNr As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents TabPayment As System.Windows.Forms.TabControl
    Friend WithEvents TabPaymentInfo As System.Windows.Forms.TabPage
    Friend WithEvents TabPaymentBeneficiary As System.Windows.Forms.TabPage
    Friend WithEvents txtFaktuurnr As System.Windows.Forms.TextBox
    Friend WithEvents txtOldChecqueNr As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TabPaymentProcurement As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkElectronicRunFinished As System.Windows.Forms.CheckBox
    Friend WithEvents cmbSpecialityofService As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSubCategoryofService As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCategoryofService As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPayeeId As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtBenDetails As System.Windows.Forms.TextBox
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents txtPkBnkCodes As System.Windows.Forms.TextBox
    Public WithEvents btnBanke As System.Windows.Forms.Button
    Public WithEvents txtBranchCode As System.Windows.Forms.TextBox
    Public WithEvents txtBranch As System.Windows.Forms.TextBox
    Public WithEvents txtBank As System.Windows.Forms.TextBox
    Public WithEvents lblBranchCode As System.Windows.Forms.Label
    Public WithEvents lblBranch As System.Windows.Forms.Label
    Public WithEvents lblBank As System.Windows.Forms.Label
    Friend WithEvents cmdStoredBeneficiary As System.Windows.Forms.Button
    Friend WithEvents optStoredBeneficiary As System.Windows.Forms.RadioButton
    Friend WithEvents optNonRecurrent As System.Windows.Forms.RadioButton
    Friend WithEvents optClient As System.Windows.Forms.RadioButton
    Public WithEvents cmbAccType As System.Windows.Forms.ComboBox
    Public WithEvents txtAccNumber As System.Windows.Forms.TextBox
    Public WithEvents lblAccType As System.Windows.Forms.Label
    Public WithEvents lblAccNumber As System.Windows.Forms.Label
    Friend WithEvents txtVATNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtStuurDMV As System.Windows.Forms.TextBox
End Class
