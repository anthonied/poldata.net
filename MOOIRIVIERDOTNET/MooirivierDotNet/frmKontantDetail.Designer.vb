<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmkontantDetail
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
        Me.dtpChequeDate = New System.Windows.Forms.DateTimePicker()
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.grpPayMethods = New System.Windows.Forms.GroupBox()
        Me.grpPaymentDetail = New System.Windows.Forms.GroupBox()
        Me.dteCoverCommence = New System.Windows.Forms.DateTimePicker()
        Me.lblCommenceDate = New System.Windows.Forms.Label()
        Me.grpPayMethods.SuspendLayout()
        Me.grpPaymentDetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpChequeDate
        '
        Me.dtpChequeDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpChequeDate.Location = New System.Drawing.Point(159, 187)
        Me.dtpChequeDate.Name = "dtpChequeDate"
        Me.dtpChequeDate.Size = New System.Drawing.Size(100, 20)
        Me.dtpChequeDate.TabIndex = 9
        Me.dtpChequeDate.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 77)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 13)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Memo"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtChequeInfo
        '
        Me.txtChequeInfo.Location = New System.Drawing.Point(159, 220)
        Me.txtChequeInfo.Name = "txtChequeInfo"
        Me.txtChequeInfo.Size = New System.Drawing.Size(244, 20)
        Me.txtChequeInfo.TabIndex = 10
        Me.txtChequeInfo.Visible = False
        '
        'txtChequenr
        '
        Me.txtChequenr.Location = New System.Drawing.Point(159, 154)
        Me.txtChequenr.Name = "txtChequenr"
        Me.txtChequenr.Size = New System.Drawing.Size(122, 20)
        Me.txtChequenr.TabIndex = 8
        Me.txtChequenr.Visible = False
        '
        'txtReceiptnr
        '
        Me.txtReceiptnr.Location = New System.Drawing.Point(159, 11)
        Me.txtReceiptnr.MaxLength = 10
        Me.txtReceiptnr.Name = "txtReceiptnr"
        Me.txtReceiptnr.Size = New System.Drawing.Size(120, 20)
        Me.txtReceiptnr.TabIndex = 4
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(159, 42)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(120, 20)
        Me.txtAmount.TabIndex = 5
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCashMemo
        '
        Me.txtCashMemo.Location = New System.Drawing.Point(159, 73)
        Me.txtCashMemo.MaxLength = 400
        Me.txtCashMemo.Name = "txtCashMemo"
        Me.txtCashMemo.Size = New System.Drawing.Size(355, 20)
        Me.txtCashMemo.TabIndex = 6
        '
        'optElectronic
        '
        Me.optElectronic.AutoSize = True
        Me.optElectronic.Checked = True
        Me.optElectronic.Location = New System.Drawing.Point(37, 14)
        Me.optElectronic.Name = "optElectronic"
        Me.optElectronic.Size = New System.Drawing.Size(72, 17)
        Me.optElectronic.TabIndex = 3
        Me.optElectronic.TabStop = True
        Me.optElectronic.Text = "Electronic"
        Me.optElectronic.UseVisualStyleBackColor = True
        '
        'optCash
        '
        Me.optCash.AutoSize = True
        Me.optCash.Enabled = False
        Me.optCash.Location = New System.Drawing.Point(254, 14)
        Me.optCash.Name = "optCash"
        Me.optCash.Size = New System.Drawing.Size(49, 17)
        Me.optCash.TabIndex = 2
        Me.optCash.TabStop = True
        Me.optCash.Text = "Cash"
        Me.optCash.UseVisualStyleBackColor = True
        '
        'optCheque
        '
        Me.optCheque.AutoSize = True
        Me.optCheque.Location = New System.Drawing.Point(448, 14)
        Me.optCheque.Name = "optCheque"
        Me.optCheque.Size = New System.Drawing.Size(62, 17)
        Me.optCheque.TabIndex = 1
        Me.optCheque.TabStop = True
        Me.optCheque.Text = "Cheque"
        Me.optCheque.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 227)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Cheque info"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label9.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 194)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Cheque date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label8.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 161)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Cheque no"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label7.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Receipt no"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Amount"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(507, 316)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 25)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(412, 316)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(85, 25)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'grpPayMethods
        '
        Me.grpPayMethods.Controls.Add(Me.optElectronic)
        Me.grpPayMethods.Controls.Add(Me.optCash)
        Me.grpPayMethods.Controls.Add(Me.optCheque)
        Me.grpPayMethods.Location = New System.Drawing.Point(16, 16)
        Me.grpPayMethods.Name = "grpPayMethods"
        Me.grpPayMethods.Size = New System.Drawing.Size(576, 37)
        Me.grpPayMethods.TabIndex = 40
        Me.grpPayMethods.TabStop = False
        Me.grpPayMethods.Text = "Payment Methods"
        '
        'grpPaymentDetail
        '
        Me.grpPaymentDetail.Controls.Add(Me.dteCoverCommence)
        Me.grpPaymentDetail.Controls.Add(Me.lblCommenceDate)
        Me.grpPaymentDetail.Controls.Add(Me.dtpChequeDate)
        Me.grpPaymentDetail.Controls.Add(Me.Label10)
        Me.grpPaymentDetail.Controls.Add(Me.txtChequeInfo)
        Me.grpPaymentDetail.Controls.Add(Me.txtChequenr)
        Me.grpPaymentDetail.Controls.Add(Me.txtReceiptnr)
        Me.grpPaymentDetail.Controls.Add(Me.txtCashMemo)
        Me.grpPaymentDetail.Controls.Add(Me.Label9)
        Me.grpPaymentDetail.Controls.Add(Me.txtAmount)
        Me.grpPaymentDetail.Controls.Add(Me.Label8)
        Me.grpPaymentDetail.Controls.Add(Me.Label5)
        Me.grpPaymentDetail.Controls.Add(Me.Label7)
        Me.grpPaymentDetail.Controls.Add(Me.Label6)
        Me.grpPaymentDetail.Location = New System.Drawing.Point(12, 55)
        Me.grpPaymentDetail.Name = "grpPaymentDetail"
        Me.grpPaymentDetail.Size = New System.Drawing.Size(580, 255)
        Me.grpPaymentDetail.TabIndex = 61
        Me.grpPaymentDetail.TabStop = False
        '
        'dteCoverCommence
        '
        Me.dteCoverCommence.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dteCoverCommence.Location = New System.Drawing.Point(159, 121)
        Me.dteCoverCommence.Name = "dteCoverCommence"
        Me.dteCoverCommence.Size = New System.Drawing.Size(100, 20)
        Me.dteCoverCommence.TabIndex = 7
        Me.dteCoverCommence.Visible = False
        '
        'lblCommenceDate
        '
        Me.lblCommenceDate.Location = New System.Drawing.Point(9, 113)
        Me.lblCommenceDate.Name = "lblCommenceDate"
        Me.lblCommenceDate.Size = New System.Drawing.Size(112, 28)
        Me.lblCommenceDate.TabIndex = 31
        Me.lblCommenceDate.Text = "Cover Commencement Date"
        Me.lblCommenceDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCommenceDate.Visible = False
        '
        'frmkontantDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 355)
        Me.Controls.Add(Me.grpPaymentDetail)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.grpPayMethods)
        Me.Controls.Add(Me.btnCancel)
        Me.Name = "frmkontantDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transaction Detail"
        Me.grpPayMethods.ResumeLayout(False)
        Me.grpPayMethods.PerformLayout()
        Me.grpPaymentDetail.ResumeLayout(False)
        Me.grpPaymentDetail.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtpChequeDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtChequeInfo As System.Windows.Forms.TextBox
    Friend WithEvents txtChequenr As System.Windows.Forms.TextBox
    Friend WithEvents txtReceiptnr As System.Windows.Forms.TextBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtCashMemo As System.Windows.Forms.TextBox
    Friend WithEvents optElectronic As System.Windows.Forms.RadioButton
    Friend WithEvents optCash As System.Windows.Forms.RadioButton
    Friend WithEvents optCheque As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents grpPayMethods As System.Windows.Forms.GroupBox
    Friend WithEvents grpPaymentDetail As System.Windows.Forms.GroupBox
    Friend WithEvents dteCoverCommence As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCommenceDate As System.Windows.Forms.Label
End Class
