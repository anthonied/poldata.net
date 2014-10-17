<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClaimsJoernale
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
        Me.optIncomeElectronic = New System.Windows.Forms.RadioButton()
        Me.optIncomeCash = New System.Windows.Forms.RadioButton()
        Me.optIncomeChecque = New System.Windows.Forms.RadioButton()
        Me.chkIncomeVAT = New System.Windows.Forms.CheckBox()
        Me.dtpIncomeDate = New System.Windows.Forms.DateTimePicker()
        Me.cmbIncomeType = New System.Windows.Forms.ComboBox()
        Me.txtIncomeChecqueNr = New System.Windows.Forms.TextBox()
        Me.txtIncomeClaimnr3rdParty = New System.Windows.Forms.TextBox()
        Me.txtIncomeDetails = New System.Windows.Forms.TextBox()
        Me.txtIncomeAmountWithoutVat = New System.Windows.Forms.TextBox()
        Me.txtIncomeVatAmount = New System.Windows.Forms.TextBox()
        Me.txtIncomeAmount = New System.Windows.Forms.TextBox()
        Me.txtIncomeInvRefNr = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblCancel = New System.Windows.Forms.Label()
        Me.chkCancel = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'optIncomeElectronic
        '
        Me.optIncomeElectronic.AutoSize = True
        Me.optIncomeElectronic.Location = New System.Drawing.Point(241, 248)
        Me.optIncomeElectronic.Name = "optIncomeElectronic"
        Me.optIncomeElectronic.Size = New System.Drawing.Size(72, 18)
        Me.optIncomeElectronic.TabIndex = 11
        Me.optIncomeElectronic.TabStop = True
        Me.optIncomeElectronic.Text = "Electronic"
        Me.optIncomeElectronic.UseVisualStyleBackColor = True
        '
        'optIncomeCash
        '
        Me.optIncomeCash.AutoSize = True
        Me.optIncomeCash.Location = New System.Drawing.Point(346, 248)
        Me.optIncomeCash.Name = "optIncomeCash"
        Me.optIncomeCash.Size = New System.Drawing.Size(50, 18)
        Me.optIncomeCash.TabIndex = 10
        Me.optIncomeCash.TabStop = True
        Me.optIncomeCash.Text = "Cash"
        Me.optIncomeCash.UseVisualStyleBackColor = True
        Me.optIncomeCash.Visible = False
        '
        'optIncomeChecque
        '
        Me.optIncomeChecque.AutoSize = True
        Me.optIncomeChecque.Location = New System.Drawing.Point(140, 248)
        Me.optIncomeChecque.Name = "optIncomeChecque"
        Me.optIncomeChecque.Size = New System.Drawing.Size(68, 18)
        Me.optIncomeChecque.TabIndex = 9
        Me.optIncomeChecque.TabStop = True
        Me.optIncomeChecque.Text = "Checque"
        Me.optIncomeChecque.UseVisualStyleBackColor = True
        '
        'chkIncomeVAT
        '
        Me.chkIncomeVAT.AutoSize = True
        Me.chkIncomeVAT.Location = New System.Drawing.Point(140, 150)
        Me.chkIncomeVAT.Name = "chkIncomeVAT"
        Me.chkIncomeVAT.Size = New System.Drawing.Size(15, 14)
        Me.chkIncomeVAT.TabIndex = 5
        Me.chkIncomeVAT.UseVisualStyleBackColor = True
        '
        'dtpIncomeDate
        '
        Me.dtpIncomeDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpIncomeDate.Location = New System.Drawing.Point(140, 222)
        Me.dtpIncomeDate.Name = "dtpIncomeDate"
        Me.dtpIncomeDate.Size = New System.Drawing.Size(116, 20)
        Me.dtpIncomeDate.TabIndex = 8
        '
        'cmbIncomeType
        '
        Me.cmbIncomeType.FormattingEnabled = True
        Me.cmbIncomeType.Location = New System.Drawing.Point(140, 44)
        Me.cmbIncomeType.Name = "cmbIncomeType"
        Me.cmbIncomeType.Size = New System.Drawing.Size(170, 22)
        Me.cmbIncomeType.TabIndex = 1
        '
        'txtIncomeChecqueNr
        '
        Me.txtIncomeChecqueNr.Location = New System.Drawing.Point(140, 320)
        Me.txtIncomeChecqueNr.Name = "txtIncomeChecqueNr"
        Me.txtIncomeChecqueNr.Size = New System.Drawing.Size(293, 20)
        Me.txtIncomeChecqueNr.TabIndex = 13
        '
        'txtIncomeClaimnr3rdParty
        '
        Me.txtIncomeClaimnr3rdParty.Location = New System.Drawing.Point(140, 297)
        Me.txtIncomeClaimnr3rdParty.Name = "txtIncomeClaimnr3rdParty"
        Me.txtIncomeClaimnr3rdParty.Size = New System.Drawing.Size(293, 20)
        Me.txtIncomeClaimnr3rdParty.TabIndex = 12
        '
        'txtIncomeDetails
        '
        Me.txtIncomeDetails.Location = New System.Drawing.Point(140, 72)
        Me.txtIncomeDetails.Name = "txtIncomeDetails"
        Me.txtIncomeDetails.Size = New System.Drawing.Size(293, 20)
        Me.txtIncomeDetails.TabIndex = 2
        '
        'txtIncomeAmountWithoutVat
        '
        Me.txtIncomeAmountWithoutVat.Location = New System.Drawing.Point(140, 196)
        Me.txtIncomeAmountWithoutVat.Name = "txtIncomeAmountWithoutVat"
        Me.txtIncomeAmountWithoutVat.Size = New System.Drawing.Size(116, 20)
        Me.txtIncomeAmountWithoutVat.TabIndex = 7
        '
        'txtIncomeVatAmount
        '
        Me.txtIncomeVatAmount.Location = New System.Drawing.Point(140, 170)
        Me.txtIncomeVatAmount.Name = "txtIncomeVatAmount"
        Me.txtIncomeVatAmount.Size = New System.Drawing.Size(116, 20)
        Me.txtIncomeVatAmount.TabIndex = 6
        '
        'txtIncomeAmount
        '
        Me.txtIncomeAmount.Location = New System.Drawing.Point(140, 124)
        Me.txtIncomeAmount.Name = "txtIncomeAmount"
        Me.txtIncomeAmount.Size = New System.Drawing.Size(116, 20)
        Me.txtIncomeAmount.TabIndex = 4
        '
        'txtIncomeInvRefNr
        '
        Me.txtIncomeInvRefNr.Location = New System.Drawing.Point(140, 98)
        Me.txtIncomeInvRefNr.Name = "txtIncomeInvRefNr"
        Me.txtIncomeInvRefNr.Size = New System.Drawing.Size(171, 20)
        Me.txtIncomeInvRefNr.TabIndex = 3
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(16, 250)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(86, 14)
        Me.Label27.TabIndex = 135
        Me.Label27.Text = "Payment Method"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(16, 323)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(65, 14)
        Me.Label26.TabIndex = 134
        Me.Label26.Text = "Checque no"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(16, 300)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(107, 14)
        Me.Label25.TabIndex = 133
        Me.Label25.Text = "Claim no of 3rd Party"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(16, 48)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(80, 14)
        Me.Label24.TabIndex = 132
        Me.Label24.Text = "Type of Income"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(16, 75)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(39, 14)
        Me.Label23.TabIndex = 131
        Me.Label23.Text = "Details"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(16, 225)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(29, 14)
        Me.Label22.TabIndex = 130
        Me.Label22.Text = "Date"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(16, 199)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(106, 14)
        Me.Label21.TabIndex = 129
        Me.Label21.Text = "Amount without VAT"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(16, 173)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(66, 14)
        Me.Label20.TabIndex = 128
        Me.Label20.Text = "VAT Amount"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(16, 150)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(27, 14)
        Me.Label19.TabIndex = 127
        Me.Label19.Text = "VAT"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(16, 127)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 14)
        Me.Label18.TabIndex = 126
        Me.Label18.Text = "Amount"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(16, 101)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(111, 14)
        Me.Label17.TabIndex = 125
        Me.Label17.Text = "Invoice/Reference No"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 14)
        Me.Label1.TabIndex = 151
        Me.Label1.Text = "Claim Income"
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOK.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOK.Location = New System.Drawing.Point(275, 370)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOK.Size = New System.Drawing.Size(77, 25)
        Me.btnOK.TabIndex = 16
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
        Me.btnCancel.Location = New System.Drawing.Point(356, 370)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(77, 25)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'lblCancel
        '
        Me.lblCancel.AutoSize = True
        Me.lblCancel.Location = New System.Drawing.Point(16, 349)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(40, 14)
        Me.lblCancel.TabIndex = 154
        Me.lblCancel.Text = "Cancel"
        '
        'chkCancel
        '
        Me.chkCancel.AutoSize = True
        Me.chkCancel.Location = New System.Drawing.Point(140, 349)
        Me.chkCancel.Name = "chkCancel"
        Me.chkCancel.Size = New System.Drawing.Size(15, 14)
        Me.chkCancel.TabIndex = 15
        Me.chkCancel.UseVisualStyleBackColor = True
        '
        'frmClaimsJoernale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 401)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkCancel)
        Me.Controls.Add(Me.lblCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.optIncomeElectronic)
        Me.Controls.Add(Me.optIncomeCash)
        Me.Controls.Add(Me.optIncomeChecque)
        Me.Controls.Add(Me.chkIncomeVAT)
        Me.Controls.Add(Me.dtpIncomeDate)
        Me.Controls.Add(Me.cmbIncomeType)
        Me.Controls.Add(Me.txtIncomeChecqueNr)
        Me.Controls.Add(Me.txtIncomeClaimnr3rdParty)
        Me.Controls.Add(Me.txtIncomeDetails)
        Me.Controls.Add(Me.txtIncomeAmountWithoutVat)
        Me.Controls.Add(Me.txtIncomeVatAmount)
        Me.Controls.Add(Me.txtIncomeAmount)
        Me.Controls.Add(Me.txtIncomeInvRefNr)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmClaimsJoernale"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Claim Income"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents optIncomeElectronic As System.Windows.Forms.RadioButton
    Friend WithEvents optIncomeCash As System.Windows.Forms.RadioButton
    Friend WithEvents optIncomeChecque As System.Windows.Forms.RadioButton
    Friend WithEvents chkIncomeVAT As System.Windows.Forms.CheckBox
    Friend WithEvents dtpIncomeDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbIncomeType As System.Windows.Forms.ComboBox
    Friend WithEvents txtIncomeChecqueNr As System.Windows.Forms.TextBox
    Friend WithEvents txtIncomeClaimnr3rdParty As System.Windows.Forms.TextBox
    Friend WithEvents txtIncomeDetails As System.Windows.Forms.TextBox
    Friend WithEvents txtIncomeAmountWithoutVat As System.Windows.Forms.TextBox
    Friend WithEvents txtIncomeVatAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtIncomeAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtIncomeInvRefNr As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents btnOK As System.Windows.Forms.Button
    Public WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblCancel As System.Windows.Forms.Label
    Friend WithEvents chkCancel As System.Windows.Forms.CheckBox
End Class
