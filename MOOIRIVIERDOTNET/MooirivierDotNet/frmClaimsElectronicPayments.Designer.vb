<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClaimsElectronicPayments
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.optTestRun = New System.Windows.Forms.RadioButton()
        Me.optFinalRun = New System.Windows.Forms.RadioButton()
        Me.cmdVerify = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpPaymentDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbInsurer = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvBrokersExisting = New System.Windows.Forms.DataGridView()
        Me.pkMakelaar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.beskrywingafr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nedbankleerafkorting = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvBrokersPay = New System.Windows.Forms.DataGridView()
        Me.pkMakelaar2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.beskrywingafr2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nedbankleerafkorting2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdOneOver = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBacthID = New System.Windows.Forms.TextBox()
        Me.txtFilename = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblVerified = New System.Windows.Forms.Label()
        CType(Me.dgvBrokersExisting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBrokersPay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Claims Electronic Payments"
        '
        'optTestRun
        '
        Me.optTestRun.AutoSize = True
        Me.optTestRun.Location = New System.Drawing.Point(17, 54)
        Me.optTestRun.Name = "optTestRun"
        Me.optTestRun.Size = New System.Drawing.Size(67, 18)
        Me.optTestRun.TabIndex = 1
        Me.optTestRun.TabStop = True
        Me.optTestRun.Text = "Test Run"
        Me.optTestRun.UseVisualStyleBackColor = True
        '
        'optFinalRun
        '
        Me.optFinalRun.AutoSize = True
        Me.optFinalRun.Location = New System.Drawing.Point(154, 54)
        Me.optFinalRun.Name = "optFinalRun"
        Me.optFinalRun.Size = New System.Drawing.Size(69, 18)
        Me.optFinalRun.TabIndex = 2
        Me.optFinalRun.TabStop = True
        Me.optFinalRun.Text = "Final Run"
        Me.optFinalRun.UseVisualStyleBackColor = True
        '
        'cmdVerify
        '
        Me.cmdVerify.Location = New System.Drawing.Point(345, 96)
        Me.cmdVerify.Name = "cmdVerify"
        Me.cmdVerify.Size = New System.Drawing.Size(67, 22)
        Me.cmdVerify.TabIndex = 3
        Me.cmdVerify.Text = "Verify"
        Me.cmdVerify.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Payment date"
        '
        'dtpPaymentDate
        '
        Me.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPaymentDate.Location = New System.Drawing.Point(154, 130)
        Me.dtpPaymentDate.MaxDate = New Date(2040, 12, 31, 0, 0, 0, 0)
        Me.dtpPaymentDate.MinDate = New Date(1980, 1, 1, 0, 0, 0, 0)
        Me.dtpPaymentDate.Name = "dtpPaymentDate"
        Me.dtpPaymentDate.Size = New System.Drawing.Size(85, 20)
        Me.dtpPaymentDate.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 161)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 14)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Insurer"
        '
        'cmbInsurer
        '
        Me.cmbInsurer.FormattingEnabled = True
        Me.cmbInsurer.Location = New System.Drawing.Point(154, 158)
        Me.cmbInsurer.Name = "cmbInsurer"
        Me.cmbInsurer.Size = New System.Drawing.Size(167, 22)
        Me.cmbInsurer.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 190)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 14)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Broker"
        '
        'dgvBrokersExisting
        '
        Me.dgvBrokersExisting.AllowUserToAddRows = False
        Me.dgvBrokersExisting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBrokersExisting.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pkMakelaar, Me.beskrywingafr, Me.nedbankleerafkorting})
        Me.dgvBrokersExisting.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvBrokersExisting.Location = New System.Drawing.Point(19, 208)
        Me.dgvBrokersExisting.Name = "dgvBrokersExisting"
        Me.dgvBrokersExisting.RowHeadersWidth = 5
        Me.dgvBrokersExisting.Size = New System.Drawing.Size(258, 193)
        Me.dgvBrokersExisting.TabIndex = 10
        '
        'pkMakelaar
        '
        Me.pkMakelaar.DataPropertyName = "pkMakelaar"
        Me.pkMakelaar.HeaderText = "pkMakelaar"
        Me.pkMakelaar.Name = "pkMakelaar"
        Me.pkMakelaar.Visible = False
        '
        'beskrywingafr
        '
        Me.beskrywingafr.DataPropertyName = "beskrywingafr"
        Me.beskrywingafr.HeaderText = "Broker Description"
        Me.beskrywingafr.Name = "beskrywingafr"
        Me.beskrywingafr.Width = 250
        '
        'nedbankleerafkorting
        '
        Me.nedbankleerafkorting.DataPropertyName = "nedbankleerafkorting"
        Me.nedbankleerafkorting.HeaderText = "nedbankleerafk"
        Me.nedbankleerafkorting.Name = "nedbankleerafkorting"
        Me.nedbankleerafkorting.Visible = False
        '
        'dgvBrokersPay
        '
        Me.dgvBrokersPay.AllowUserToAddRows = False
        Me.dgvBrokersPay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBrokersPay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pkMakelaar2, Me.beskrywingafr2, Me.nedbankleerafkorting2})
        Me.dgvBrokersPay.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvBrokersPay.Location = New System.Drawing.Point(326, 208)
        Me.dgvBrokersPay.Name = "dgvBrokersPay"
        Me.dgvBrokersPay.RowHeadersWidth = 5
        Me.dgvBrokersPay.Size = New System.Drawing.Size(258, 193)
        Me.dgvBrokersPay.TabIndex = 11
        '
        'pkMakelaar2
        '
        Me.pkMakelaar2.DataPropertyName = "pkMakelaar2"
        Me.pkMakelaar2.HeaderText = "pkMakelaar2"
        Me.pkMakelaar2.Name = "pkMakelaar2"
        Me.pkMakelaar2.Visible = False
        '
        'beskrywingafr2
        '
        Me.beskrywingafr2.DataPropertyName = "beskrywingafr2"
        Me.beskrywingafr2.HeaderText = "Broker Description"
        Me.beskrywingafr2.Name = "beskrywingafr2"
        Me.beskrywingafr2.Width = 250
        '
        'nedbankleerafkorting2
        '
        Me.nedbankleerafkorting2.DataPropertyName = "nedbankleerafkorting2"
        Me.nedbankleerafkorting2.HeaderText = "nedbankleerafk2"
        Me.nedbankleerafkorting2.Name = "nedbankleerafkorting2"
        Me.nedbankleerafkorting2.Visible = False
        '
        'cmdOneOver
        '
        Me.cmdOneOver.Location = New System.Drawing.Point(283, 289)
        Me.cmdOneOver.Name = "cmdOneOver"
        Me.cmdOneOver.Size = New System.Drawing.Size(37, 31)
        Me.cmdOneOver.TabIndex = 12
        Me.cmdOneOver.Text = ">"
        Me.cmdOneOver.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(19, 420)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(339, 28)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Batch ID (Max 7) - must be unique for final run, except for rejected batches"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 448)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 14)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Filename (Max 14)"
        '
        'txtBacthID
        '
        Me.txtBacthID.Location = New System.Drawing.Point(364, 419)
        Me.txtBacthID.MaxLength = 7
        Me.txtBacthID.Name = "txtBacthID"
        Me.txtBacthID.Size = New System.Drawing.Size(220, 20)
        Me.txtBacthID.TabIndex = 16
        '
        'txtFilename
        '
        Me.txtFilename.Location = New System.Drawing.Point(364, 445)
        Me.txtFilename.MaxLength = 14
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.Size = New System.Drawing.Size(220, 20)
        Me.txtFilename.TabIndex = 17
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOK.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOK.Location = New System.Drawing.Point(426, 482)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOK.Size = New System.Drawing.Size(77, 25)
        Me.btnOK.TabIndex = 20
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
        Me.btnCancel.Location = New System.Drawing.Point(507, 482)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(77, 25)
        Me.btnCancel.TabIndex = 21
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(19, 99)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(128, 14)
        Me.lblPassword.TabIndex = 22
        Me.lblPassword.Text = "Verify with 2 passwords"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(153, 97)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(167, 20)
        Me.txtPassword.TabIndex = 23
        '
        'lblVerified
        '
        Me.lblVerified.Font = New System.Drawing.Font("Wingdings 2", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.lblVerified.Location = New System.Drawing.Point(321, 99)
        Me.lblVerified.Name = "lblVerified"
        Me.lblVerified.Size = New System.Drawing.Size(25, 17)
        Me.lblVerified.TabIndex = 24
        '
        'frmClaimsElectronicPayments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 519)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.cmdVerify)
        Me.Controls.Add(Me.lblVerified)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtFilename)
        Me.Controls.Add(Me.txtBacthID)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmdOneOver)
        Me.Controls.Add(Me.dgvBrokersPay)
        Me.Controls.Add(Me.dgvBrokersExisting)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbInsurer)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpPaymentDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.optFinalRun)
        Me.Controls.Add(Me.optTestRun)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmClaimsElectronicPayments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Claims Electronic Payments"
        CType(Me.dgvBrokersExisting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBrokersPay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents optTestRun As System.Windows.Forms.RadioButton
    Friend WithEvents optFinalRun As System.Windows.Forms.RadioButton
    Friend WithEvents cmdVerify As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpPaymentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbInsurer As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvBrokersExisting As System.Windows.Forms.DataGridView
    Friend WithEvents dgvBrokersPay As System.Windows.Forms.DataGridView
    Friend WithEvents cmdOneOver As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtBacthID As System.Windows.Forms.TextBox
    Friend WithEvents txtFilename As System.Windows.Forms.TextBox
    Public WithEvents btnOK As System.Windows.Forms.Button
    Public WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents pkMakelaar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents beskrywingafr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nedbankleerafkorting As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pkMakelaar2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents beskrywingafr2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nedbankleerafkorting2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblVerified As System.Windows.Forms.Label
End Class
