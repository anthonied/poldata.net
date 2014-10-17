<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClaimsJournal
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
        Me.txtCrossRefNr = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkCancel = New System.Windows.Forms.CheckBox()
        Me.lblCancel = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkJournalVAT = New System.Windows.Forms.CheckBox()
        Me.dtpJournalDate = New System.Windows.Forms.DateTimePicker()
        Me.txtJournalDetails = New System.Windows.Forms.TextBox()
        Me.txtJournalAmountWithoutVat = New System.Windows.Forms.TextBox()
        Me.txtJournalVatAmount = New System.Windows.Forms.TextBox()
        Me.txtJournalAmount = New System.Windows.Forms.TextBox()
        Me.txtJournalInvRefNr = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtCrossRefNr
        '
        Me.txtCrossRefNr.Location = New System.Drawing.Point(136, 115)
        Me.txtCrossRefNr.Name = "txtCrossRefNr"
        Me.txtCrossRefNr.Size = New System.Drawing.Size(290, 20)
        Me.txtCrossRefNr.TabIndex = 220
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 14)
        Me.Label2.TabIndex = 219
        Me.Label2.Text = "Cross Reference No"
        '
        'cmbCategory
        '
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(135, 82)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(292, 22)
        Me.cmbCategory.TabIndex = 217
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 85)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 14)
        Me.Label12.TabIndex = 218
        Me.Label12.Text = "Category"
        '
        'chkCancel
        '
        Me.chkCancel.AutoSize = True
        Me.chkCancel.Location = New System.Drawing.Point(135, 339)
        Me.chkCancel.Name = "chkCancel"
        Me.chkCancel.Size = New System.Drawing.Size(15, 14)
        Me.chkCancel.TabIndex = 216
        Me.chkCancel.UseVisualStyleBackColor = True
        '
        'lblCancel
        '
        Me.lblCancel.AutoSize = True
        Me.lblCancel.Location = New System.Drawing.Point(11, 339)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(40, 14)
        Me.lblCancel.TabIndex = 215
        Me.lblCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOK.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOK.Location = New System.Drawing.Point(274, 372)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOK.Size = New System.Drawing.Size(77, 25)
        Me.btnOK.TabIndex = 214
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
        Me.btnCancel.Location = New System.Drawing.Point(355, 372)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(77, 25)
        Me.btnCancel.TabIndex = 213
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 14)
        Me.Label1.TabIndex = 212
        Me.Label1.Text = "Claim Journal"
        '
        'chkJournalVAT
        '
        Me.chkJournalVAT.AutoSize = True
        Me.chkJournalVAT.Location = New System.Drawing.Point(135, 204)
        Me.chkJournalVAT.Name = "chkJournalVAT"
        Me.chkJournalVAT.Size = New System.Drawing.Size(15, 14)
        Me.chkJournalVAT.TabIndex = 208
        Me.chkJournalVAT.UseVisualStyleBackColor = True
        '
        'dtpJournalDate
        '
        Me.dtpJournalDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpJournalDate.Location = New System.Drawing.Point(135, 281)
        Me.dtpJournalDate.Name = "dtpJournalDate"
        Me.dtpJournalDate.Size = New System.Drawing.Size(116, 20)
        Me.dtpJournalDate.TabIndex = 207
        '
        'txtJournalDetails
        '
        Me.txtJournalDetails.Location = New System.Drawing.Point(135, 51)
        Me.txtJournalDetails.Name = "txtJournalDetails"
        Me.txtJournalDetails.Size = New System.Drawing.Size(293, 20)
        Me.txtJournalDetails.TabIndex = 206
        '
        'txtJournalAmountWithoutVat
        '
        Me.txtJournalAmountWithoutVat.Location = New System.Drawing.Point(135, 253)
        Me.txtJournalAmountWithoutVat.Name = "txtJournalAmountWithoutVat"
        Me.txtJournalAmountWithoutVat.Size = New System.Drawing.Size(116, 20)
        Me.txtJournalAmountWithoutVat.TabIndex = 205
        '
        'txtJournalVatAmount
        '
        Me.txtJournalVatAmount.Location = New System.Drawing.Point(135, 225)
        Me.txtJournalVatAmount.Name = "txtJournalVatAmount"
        Me.txtJournalVatAmount.Size = New System.Drawing.Size(116, 20)
        Me.txtJournalVatAmount.TabIndex = 204
        '
        'txtJournalAmount
        '
        Me.txtJournalAmount.Location = New System.Drawing.Point(135, 176)
        Me.txtJournalAmount.Name = "txtJournalAmount"
        Me.txtJournalAmount.Size = New System.Drawing.Size(116, 20)
        Me.txtJournalAmount.TabIndex = 203
        '
        'txtJournalInvRefNr
        '
        Me.txtJournalInvRefNr.Location = New System.Drawing.Point(135, 148)
        Me.txtJournalInvRefNr.Name = "txtJournalInvRefNr"
        Me.txtJournalInvRefNr.Size = New System.Drawing.Size(171, 20)
        Me.txtJournalInvRefNr.TabIndex = 202
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(11, 54)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(62, 14)
        Me.Label23.TabIndex = 200
        Me.Label23.Text = "Beneficiary"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(11, 284)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(29, 14)
        Me.Label22.TabIndex = 199
        Me.Label22.Text = "Date"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(11, 256)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(106, 14)
        Me.Label21.TabIndex = 198
        Me.Label21.Text = "Amount without VAT"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(11, 228)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(66, 14)
        Me.Label20.TabIndex = 197
        Me.Label20.Text = "VAT Amount"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(11, 204)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(27, 14)
        Me.Label19.TabIndex = 196
        Me.Label19.Text = "VAT"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(11, 179)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 14)
        Me.Label18.TabIndex = 195
        Me.Label18.Text = "Amount"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(11, 151)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(111, 14)
        Me.Label17.TabIndex = 194
        Me.Label17.Text = "Invoice/Reference No"
        '
        'cmbType
        '
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(135, 308)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(170, 22)
        Me.cmbType.TabIndex = 222
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(11, 312)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(81, 14)
        Me.Label24.TabIndex = 221
        Me.Label24.Text = "Type of Journal"
        '
        'frmClaimsJournal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(439, 405)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbType)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtCrossRefNr)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbCategory)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.chkCancel)
        Me.Controls.Add(Me.lblCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkJournalVAT)
        Me.Controls.Add(Me.dtpJournalDate)
        Me.Controls.Add(Me.txtJournalDetails)
        Me.Controls.Add(Me.txtJournalAmountWithoutVat)
        Me.Controls.Add(Me.txtJournalVatAmount)
        Me.Controls.Add(Me.txtJournalAmount)
        Me.Controls.Add(Me.txtJournalInvRefNr)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmClaimsJournal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Claim Journal"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCrossRefNr As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkCancel As System.Windows.Forms.CheckBox
    Friend WithEvents lblCancel As System.Windows.Forms.Label
    Public WithEvents btnOK As System.Windows.Forms.Button
    Public WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkJournalVAT As System.Windows.Forms.CheckBox
    Friend WithEvents dtpJournalDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtJournalDetails As System.Windows.Forms.TextBox
    Friend WithEvents txtJournalAmountWithoutVat As System.Windows.Forms.TextBox
    Friend WithEvents txtJournalVatAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtJournalAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtJournalInvRefNr As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
End Class
