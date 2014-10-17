<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCollections
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbInsurer = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkCollectionsRun = New System.Windows.Forms.CheckBox()
        Me.chkReportsSummary = New System.Windows.Forms.CheckBox()
        Me.chkReportsDetail = New System.Windows.Forms.CheckBox()
        Me.chkReportsRecon = New System.Windows.Forms.CheckBox()
        Me.chkReconReport103Report = New System.Windows.Forms.CheckBox()
        Me.chkReconReportPoliciesAdded = New System.Windows.Forms.CheckBox()
        Me.chkReconciliationForm = New System.Windows.Forms.CheckBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.dtpCollectionsDate = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmdPath = New System.Windows.Forms.Button()
        Me.txtChooseCollectionsFilePath = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ofdCollectionsFile = New System.Windows.Forms.OpenFileDialog()
        Me.lblProcessing = New System.Windows.Forms.Label()
        Me.fraGeneralSalary = New System.Windows.Forms.GroupBox()
        Me.optSalary = New System.Windows.Forms.RadioButton()
        Me.optGeneral = New System.Windows.Forms.RadioButton()
        Me.cmbArea = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtpSalaryCollectionDate = New System.Windows.Forms.DateTimePicker()
        Me.grdInfoChange = New System.Windows.Forms.DataGridView()
        Me.Polisno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pers_nom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vord_premie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Insured = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pkMaand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblFixIncorrectData = New System.Windows.Forms.Label()
        Me.chkDatabaseBackup = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.fraGeneralSalary.SuspendLayout()
        CType(Me.grdInfoChange, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Collections"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Insurer"
        '
        'cmbInsurer
        '
        Me.cmbInsurer.FormattingEnabled = True
        Me.cmbInsurer.Location = New System.Drawing.Point(116, 86)
        Me.cmbInsurer.Name = "cmbInsurer"
        Me.cmbInsurer.Size = New System.Drawing.Size(199, 22)
        Me.cmbInsurer.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 265)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Collections Run"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 289)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 14)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Reports"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(52, 302)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 14)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "- Summary"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(52, 316)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 14)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "- Detail"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(52, 330)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 14)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "- Reconciliation"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(21, 358)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 14)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Reconciliation Report"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(52, 372)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 14)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "- 103 Report"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(52, 386)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(149, 14)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "- Policies added after test run"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(21, 411)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 14)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Reconciliation form"
        '
        'chkCollectionsRun
        '
        Me.chkCollectionsRun.AutoSize = True
        Me.chkCollectionsRun.Checked = True
        Me.chkCollectionsRun.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCollectionsRun.Location = New System.Drawing.Point(298, 266)
        Me.chkCollectionsRun.Name = "chkCollectionsRun"
        Me.chkCollectionsRun.Size = New System.Drawing.Size(15, 14)
        Me.chkCollectionsRun.TabIndex = 2
        Me.chkCollectionsRun.UseVisualStyleBackColor = True
        '
        'chkReportsSummary
        '
        Me.chkReportsSummary.AutoSize = True
        Me.chkReportsSummary.Checked = True
        Me.chkReportsSummary.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReportsSummary.Location = New System.Drawing.Point(298, 302)
        Me.chkReportsSummary.Name = "chkReportsSummary"
        Me.chkReportsSummary.Size = New System.Drawing.Size(15, 14)
        Me.chkReportsSummary.TabIndex = 3
        Me.chkReportsSummary.UseVisualStyleBackColor = True
        '
        'chkReportsDetail
        '
        Me.chkReportsDetail.AutoSize = True
        Me.chkReportsDetail.Location = New System.Drawing.Point(298, 316)
        Me.chkReportsDetail.Name = "chkReportsDetail"
        Me.chkReportsDetail.Size = New System.Drawing.Size(15, 14)
        Me.chkReportsDetail.TabIndex = 4
        Me.chkReportsDetail.UseVisualStyleBackColor = True
        '
        'chkReportsRecon
        '
        Me.chkReportsRecon.AutoSize = True
        Me.chkReportsRecon.Checked = True
        Me.chkReportsRecon.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReportsRecon.Location = New System.Drawing.Point(298, 330)
        Me.chkReportsRecon.Name = "chkReportsRecon"
        Me.chkReportsRecon.Size = New System.Drawing.Size(15, 14)
        Me.chkReportsRecon.TabIndex = 5
        Me.chkReportsRecon.UseVisualStyleBackColor = True
        '
        'chkReconReport103Report
        '
        Me.chkReconReport103Report.AutoSize = True
        Me.chkReconReport103Report.Location = New System.Drawing.Point(298, 372)
        Me.chkReconReport103Report.Name = "chkReconReport103Report"
        Me.chkReconReport103Report.Size = New System.Drawing.Size(15, 14)
        Me.chkReconReport103Report.TabIndex = 6
        Me.chkReconReport103Report.UseVisualStyleBackColor = True
        '
        'chkReconReportPoliciesAdded
        '
        Me.chkReconReportPoliciesAdded.AutoSize = True
        Me.chkReconReportPoliciesAdded.Location = New System.Drawing.Point(298, 386)
        Me.chkReconReportPoliciesAdded.Name = "chkReconReportPoliciesAdded"
        Me.chkReconReportPoliciesAdded.Size = New System.Drawing.Size(15, 14)
        Me.chkReconReportPoliciesAdded.TabIndex = 7
        Me.chkReconReportPoliciesAdded.UseVisualStyleBackColor = True
        '
        'chkReconciliationForm
        '
        Me.chkReconciliationForm.AutoSize = True
        Me.chkReconciliationForm.Checked = True
        Me.chkReconciliationForm.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReconciliationForm.Location = New System.Drawing.Point(298, 412)
        Me.chkReconciliationForm.Name = "chkReconciliationForm"
        Me.chkReconciliationForm.Size = New System.Drawing.Size(15, 14)
        Me.chkReconciliationForm.TabIndex = 8
        Me.chkReconciliationForm.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOk.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Location = New System.Drawing.Point(421, 567)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New System.Drawing.Size(73, 22)
        Me.btnOk.TabIndex = 9
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(500, 567)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(73, 22)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'dtpCollectionsDate
        '
        Me.dtpCollectionsDate.Checked = False
        Me.dtpCollectionsDate.CustomFormat = ""
        Me.dtpCollectionsDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCollectionsDate.Location = New System.Drawing.Point(210, 115)
        Me.dtpCollectionsDate.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.dtpCollectionsDate.MinDate = New Date(1982, 1, 1, 0, 0, 0, 0)
        Me.dtpCollectionsDate.Name = "dtpCollectionsDate"
        Me.dtpCollectionsDate.ShowCheckBox = True
        Me.dtpCollectionsDate.Size = New System.Drawing.Size(105, 20)
        Me.dtpCollectionsDate.TabIndex = 12
        Me.dtpCollectionsDate.Value = New Date(2013, 6, 6, 11, 49, 34, 0)
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(21, 120)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 14)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Last run Date"
        '
        'cmdPath
        '
        Me.cmdPath.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPath.Location = New System.Drawing.Point(230, 204)
        Me.cmdPath.Name = "cmdPath"
        Me.cmdPath.Size = New System.Drawing.Size(84, 24)
        Me.cmdPath.TabIndex = 46
        Me.cmdPath.Text = "File Path"
        Me.cmdPath.UseVisualStyleBackColor = True
        '
        'txtChooseCollectionsFilePath
        '
        Me.txtChooseCollectionsFilePath.Enabled = False
        Me.txtChooseCollectionsFilePath.Location = New System.Drawing.Point(25, 230)
        Me.txtChooseCollectionsFilePath.Name = "txtChooseCollectionsFilePath"
        Me.txtChooseCollectionsFilePath.Size = New System.Drawing.Size(290, 20)
        Me.txtChooseCollectionsFilePath.TabIndex = 48
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(21, 213)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 14)
        Me.Label13.TabIndex = 47
        Me.Label13.Text = "Choose file Path:"
        '
        'ofdCollectionsFile
        '
        Me.ofdCollectionsFile.FileName = "ofdCollectionsFile"
        '
        'lblProcessing
        '
        Me.lblProcessing.AutoSize = True
        Me.lblProcessing.Location = New System.Drawing.Point(9, 571)
        Me.lblProcessing.MinimumSize = New System.Drawing.Size(75, 14)
        Me.lblProcessing.Name = "lblProcessing"
        Me.lblProcessing.Size = New System.Drawing.Size(75, 14)
        Me.lblProcessing.TabIndex = 49
        '
        'fraGeneralSalary
        '
        Me.fraGeneralSalary.Controls.Add(Me.optSalary)
        Me.fraGeneralSalary.Controls.Add(Me.optGeneral)
        Me.fraGeneralSalary.Location = New System.Drawing.Point(19, 37)
        Me.fraGeneralSalary.Name = "fraGeneralSalary"
        Me.fraGeneralSalary.Size = New System.Drawing.Size(553, 39)
        Me.fraGeneralSalary.TabIndex = 50
        Me.fraGeneralSalary.TabStop = False
        '
        'optSalary
        '
        Me.optSalary.AutoSize = True
        Me.optSalary.Location = New System.Drawing.Point(284, 13)
        Me.optSalary.Name = "optSalary"
        Me.optSalary.Size = New System.Drawing.Size(56, 18)
        Me.optSalary.TabIndex = 1
        Me.optSalary.Text = "Salary"
        Me.optSalary.UseVisualStyleBackColor = True
        '
        'optGeneral
        '
        Me.optGeneral.AutoSize = True
        Me.optGeneral.Checked = True
        Me.optGeneral.Location = New System.Drawing.Point(14, 13)
        Me.optGeneral.Name = "optGeneral"
        Me.optGeneral.Size = New System.Drawing.Size(63, 18)
        Me.optGeneral.TabIndex = 0
        Me.optGeneral.TabStop = True
        Me.optGeneral.Text = "General"
        Me.optGeneral.UseVisualStyleBackColor = True
        '
        'cmbArea
        '
        Me.cmbArea.Enabled = False
        Me.cmbArea.FormattingEnabled = True
        Me.cmbArea.Location = New System.Drawing.Point(191, 145)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(124, 22)
        Me.cmbArea.TabIndex = 181
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Enabled = False
        Me.Label30.Location = New System.Drawing.Point(22, 148)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(31, 14)
        Me.Label30.TabIndex = 182
        Me.Label30.Text = "Area"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Enabled = False
        Me.Label14.Location = New System.Drawing.Point(21, 179)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 14)
        Me.Label14.TabIndex = 184
        Me.Label14.Text = "Salary Run Date"
        '
        'dtpSalaryCollectionDate
        '
        Me.dtpSalaryCollectionDate.Checked = False
        Me.dtpSalaryCollectionDate.CustomFormat = ""
        Me.dtpSalaryCollectionDate.Enabled = False
        Me.dtpSalaryCollectionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSalaryCollectionDate.Location = New System.Drawing.Point(210, 173)
        Me.dtpSalaryCollectionDate.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.dtpSalaryCollectionDate.MinDate = New Date(1982, 1, 1, 0, 0, 0, 0)
        Me.dtpSalaryCollectionDate.Name = "dtpSalaryCollectionDate"
        Me.dtpSalaryCollectionDate.ShowCheckBox = True
        Me.dtpSalaryCollectionDate.Size = New System.Drawing.Size(105, 20)
        Me.dtpSalaryCollectionDate.TabIndex = 183
        Me.dtpSalaryCollectionDate.Value = New Date(2013, 6, 6, 11, 49, 34, 0)
        '
        'grdInfoChange
        '
        Me.grdInfoChange.AllowUserToAddRows = False
        Me.grdInfoChange.AllowUserToDeleteRows = False
        Me.grdInfoChange.AllowUserToOrderColumns = True
        Me.grdInfoChange.AllowUserToResizeRows = False
        Me.grdInfoChange.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdInfoChange.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Polisno, Me.pers_nom, Me.vord_premie, Me.Insured, Me.pkMaand})
        Me.grdInfoChange.Location = New System.Drawing.Point(25, 447)
        Me.grdInfoChange.Name = "grdInfoChange"
        Me.grdInfoChange.RowHeadersWidth = 4
        Me.grdInfoChange.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdInfoChange.Size = New System.Drawing.Size(547, 103)
        Me.grdInfoChange.TabIndex = 185
        '
        'Polisno
        '
        Me.Polisno.DataPropertyName = "Polisno"
        Me.Polisno.HeaderText = "Policynr"
        Me.Polisno.Name = "Polisno"
        '
        'pers_nom
        '
        Me.pers_nom.DataPropertyName = "pers_nom"
        Me.pers_nom.HeaderText = "Personnel nr"
        Me.pers_nom.Name = "pers_nom"
        '
        'vord_premie
        '
        Me.vord_premie.DataPropertyName = "vord_premie"
        Me.vord_premie.HeaderText = "Amount"
        Me.vord_premie.Name = "vord_premie"
        Me.vord_premie.ReadOnly = True
        '
        'Insured
        '
        Me.Insured.HeaderText = "Insured"
        Me.Insured.Name = "Insured"
        Me.Insured.ReadOnly = True
        '
        'pkMaand
        '
        Me.pkMaand.DataPropertyName = "pkMaand"
        Me.pkMaand.HeaderText = "pkMaand"
        Me.pkMaand.Name = "pkMaand"
        Me.pkMaand.ReadOnly = True
        Me.pkMaand.Visible = False
        '
        'lblFixIncorrectData
        '
        Me.lblFixIncorrectData.AutoSize = True
        Me.lblFixIncorrectData.ForeColor = System.Drawing.Color.Red
        Me.lblFixIncorrectData.Location = New System.Drawing.Point(32, 428)
        Me.lblFixIncorrectData.Name = "lblFixIncorrectData"
        Me.lblFixIncorrectData.Size = New System.Drawing.Size(0, 14)
        Me.lblFixIncorrectData.TabIndex = 186
        '
        'chkDatabaseBackup
        '
        Me.chkDatabaseBackup.AutoSize = True
        Me.chkDatabaseBackup.Checked = True
        Me.chkDatabaseBackup.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDatabaseBackup.Location = New System.Drawing.Point(547, 89)
        Me.chkDatabaseBackup.Name = "chkDatabaseBackup"
        Me.chkDatabaseBackup.Size = New System.Drawing.Size(15, 14)
        Me.chkDatabaseBackup.TabIndex = 187
        Me.chkDatabaseBackup.UseVisualStyleBackColor = True
        Me.chkDatabaseBackup.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(333, 89)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(92, 14)
        Me.Label15.TabIndex = 188
        Me.Label15.Text = "Database Backup"
        Me.Label15.Visible = False
        '
        'frmCollections
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 598)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkDatabaseBackup)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblFixIncorrectData)
        Me.Controls.Add(Me.grdInfoChange)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.dtpSalaryCollectionDate)
        Me.Controls.Add(Me.cmbArea)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.fraGeneralSalary)
        Me.Controls.Add(Me.lblProcessing)
        Me.Controls.Add(Me.cmdPath)
        Me.Controls.Add(Me.txtChooseCollectionsFilePath)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.dtpCollectionsDate)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.chkReconciliationForm)
        Me.Controls.Add(Me.chkReconReportPoliciesAdded)
        Me.Controls.Add(Me.chkReconReport103Report)
        Me.Controls.Add(Me.chkReportsRecon)
        Me.Controls.Add(Me.chkReportsDetail)
        Me.Controls.Add(Me.chkReportsSummary)
        Me.Controls.Add(Me.chkCollectionsRun)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbInsurer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmCollections"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Collections"
        Me.fraGeneralSalary.ResumeLayout(False)
        Me.fraGeneralSalary.PerformLayout()
        CType(Me.grdInfoChange, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbInsurer As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkCollectionsRun As System.Windows.Forms.CheckBox
    Friend WithEvents chkReportsSummary As System.Windows.Forms.CheckBox
    Friend WithEvents chkReportsDetail As System.Windows.Forms.CheckBox
    Friend WithEvents chkReportsRecon As System.Windows.Forms.CheckBox
    Friend WithEvents chkReconReport103Report As System.Windows.Forms.CheckBox
    Friend WithEvents chkReconReportPoliciesAdded As System.Windows.Forms.CheckBox
    Friend WithEvents chkReconciliationForm As System.Windows.Forms.CheckBox
    Public WithEvents btnOk As System.Windows.Forms.Button
    Public WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents dtpCollectionsDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdPath As System.Windows.Forms.Button
    Friend WithEvents txtChooseCollectionsFilePath As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ofdCollectionsFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblProcessing As System.Windows.Forms.Label
    Friend WithEvents fraGeneralSalary As System.Windows.Forms.GroupBox
    Friend WithEvents optSalary As System.Windows.Forms.RadioButton
    Friend WithEvents optGeneral As System.Windows.Forms.RadioButton
    Friend WithEvents cmbArea As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtpSalaryCollectionDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents grdInfoChange As System.Windows.Forms.DataGridView
    Friend WithEvents Polisno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pers_nom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vord_premie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Insured As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pkMaand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblFixIncorrectData As System.Windows.Forms.Label
    Friend WithEvents chkDatabaseBackup As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
