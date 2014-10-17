<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDOUnpaidRun
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
        Me.chkReportsReconPerMarketer = New System.Windows.Forms.CheckBox()
        Me.chkReconReport = New System.Windows.Forms.CheckBox()
        Me.chkReportsUnpaid = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbInsurer = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.opt1stUnpaidRun = New System.Windows.Forms.RadioButton()
        Me.opt2ndUnpaidRun = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtChooseUnpaidRunFilePath = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkReportsSuspensionOfCover = New System.Windows.Forms.CheckBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.fraUnpaidrun = New System.Windows.Forms.GroupBox()
        Me.ofdUnpaidRun = New System.Windows.Forms.OpenFileDialog()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtpUnpaidRunDate = New System.Windows.Forms.DateTimePicker()
        Me.lblProcessing = New System.Windows.Forms.Label()
        Me.cmdPath = New System.Windows.Forms.Button()
        Me.chkDatabaseBackup = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.fraUnpaidrun.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkReportsReconPerMarketer
        '
        Me.chkReportsReconPerMarketer.AutoSize = True
        Me.chkReportsReconPerMarketer.Location = New System.Drawing.Point(304, 309)
        Me.chkReportsReconPerMarketer.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkReportsReconPerMarketer.Name = "chkReportsReconPerMarketer"
        Me.chkReportsReconPerMarketer.Size = New System.Drawing.Size(15, 14)
        Me.chkReportsReconPerMarketer.TabIndex = 7
        Me.chkReportsReconPerMarketer.UseVisualStyleBackColor = True
        '
        'chkReconReport
        '
        Me.chkReconReport.AutoSize = True
        Me.chkReconReport.Checked = True
        Me.chkReconReport.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReconReport.Location = New System.Drawing.Point(304, 292)
        Me.chkReconReport.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkReconReport.Name = "chkReconReport"
        Me.chkReconReport.Size = New System.Drawing.Size(15, 14)
        Me.chkReconReport.TabIndex = 6
        Me.chkReconReport.UseVisualStyleBackColor = True
        '
        'chkReportsUnpaid
        '
        Me.chkReportsUnpaid.AutoSize = True
        Me.chkReportsUnpaid.Checked = True
        Me.chkReportsUnpaid.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReportsUnpaid.Location = New System.Drawing.Point(304, 274)
        Me.chkReportsUnpaid.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkReportsUnpaid.Name = "chkReportsUnpaid"
        Me.chkReportsUnpaid.Size = New System.Drawing.Size(15, 14)
        Me.chkReportsUnpaid.TabIndex = 5
        Me.chkReportsUnpaid.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(4, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 14)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "2nd Unpaid run (v1)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(59, 307)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(215, 14)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "- Unpaid Reconciliation Report per Marketer"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(59, 290)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(151, 14)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "- Unpaid Reconciliation Report"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(59, 272)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 14)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "- Unpaid report"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 257)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 14)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Reports"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 14)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "1st Unpaid Run (vt)"
        '
        'cmbInsurer
        '
        Me.cmbInsurer.FormattingEnabled = True
        Me.cmbInsurer.Location = New System.Drawing.Point(88, 62)
        Me.cmbInsurer.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbInsurer.Name = "cmbInsurer"
        Me.cmbInsurer.Size = New System.Drawing.Size(231, 22)
        Me.cmbInsurer.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 64)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 14)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Insurer"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 19)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(159, 16)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Debit Order Unpaid Run"
        '
        'opt1stUnpaidRun
        '
        Me.opt1stUnpaidRun.AutoSize = True
        Me.opt1stUnpaidRun.Location = New System.Drawing.Point(279, 14)
        Me.opt1stUnpaidRun.Name = "opt1stUnpaidRun"
        Me.opt1stUnpaidRun.Size = New System.Drawing.Size(14, 13)
        Me.opt1stUnpaidRun.TabIndex = 2
        Me.opt1stUnpaidRun.TabStop = True
        Me.opt1stUnpaidRun.UseVisualStyleBackColor = True
        '
        'opt2ndUnpaidRun
        '
        Me.opt2ndUnpaidRun.AutoSize = True
        Me.opt2ndUnpaidRun.Location = New System.Drawing.Point(279, 34)
        Me.opt2ndUnpaidRun.Name = "opt2ndUnpaidRun"
        Me.opt2ndUnpaidRun.Size = New System.Drawing.Size(14, 13)
        Me.opt2ndUnpaidRun.TabIndex = 3
        Me.opt2ndUnpaidRun.TabStop = True
        Me.opt2ndUnpaidRun.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 197)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 14)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "Choose file Path:"
        '
        'txtChooseUnpaidRunFilePath
        '
        Me.txtChooseUnpaidRunFilePath.Location = New System.Drawing.Point(27, 214)
        Me.txtChooseUnpaidRunFilePath.Name = "txtChooseUnpaidRunFilePath"
        Me.txtChooseUnpaidRunFilePath.Size = New System.Drawing.Size(290, 20)
        Me.txtChooseUnpaidRunFilePath.TabIndex = 45
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(59, 325)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(238, 14)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "- Suspension of Cover (only on 2nd Unpaid run)"
        '
        'chkReportsSuspensionOfCover
        '
        Me.chkReportsSuspensionOfCover.AutoSize = True
        Me.chkReportsSuspensionOfCover.Checked = True
        Me.chkReportsSuspensionOfCover.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReportsSuspensionOfCover.Location = New System.Drawing.Point(304, 327)
        Me.chkReportsSuspensionOfCover.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkReportsSuspensionOfCover.Name = "chkReportsSuspensionOfCover"
        Me.chkReportsSuspensionOfCover.Size = New System.Drawing.Size(15, 14)
        Me.chkReportsSuspensionOfCover.TabIndex = 8
        Me.chkReportsSuspensionOfCover.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOk.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Location = New System.Drawing.Point(165, 355)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New System.Drawing.Size(73, 22)
        Me.btnOk.TabIndex = 48
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
        Me.btnCancel.Location = New System.Drawing.Point(244, 355)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(73, 22)
        Me.btnCancel.TabIndex = 49
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'fraUnpaidrun
        '
        Me.fraUnpaidrun.Controls.Add(Me.opt2ndUnpaidRun)
        Me.fraUnpaidrun.Controls.Add(Me.opt1stUnpaidRun)
        Me.fraUnpaidrun.Controls.Add(Me.Label11)
        Me.fraUnpaidrun.Controls.Add(Me.Label3)
        Me.fraUnpaidrun.Location = New System.Drawing.Point(22, 116)
        Me.fraUnpaidrun.Name = "fraUnpaidrun"
        Me.fraUnpaidrun.Size = New System.Drawing.Size(308, 58)
        Me.fraUnpaidrun.TabIndex = 50
        Me.fraUnpaidrun.TabStop = False
        '
        'ofdUnpaidRun
        '
        Me.ofdUnpaidRun.FileName = "ofdUnpaidRun"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(23, 96)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 14)
        Me.Label12.TabIndex = 52
        Me.Label12.Text = "Last run Date"
        '
        'dtpUnpaidRunDate
        '
        Me.dtpUnpaidRunDate.Checked = False
        Me.dtpUnpaidRunDate.CustomFormat = ""
        Me.dtpUnpaidRunDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpUnpaidRunDate.Location = New System.Drawing.Point(213, 91)
        Me.dtpUnpaidRunDate.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.dtpUnpaidRunDate.MinDate = New Date(1982, 1, 1, 0, 0, 0, 0)
        Me.dtpUnpaidRunDate.Name = "dtpUnpaidRunDate"
        Me.dtpUnpaidRunDate.ShowCheckBox = True
        Me.dtpUnpaidRunDate.Size = New System.Drawing.Size(105, 20)
        Me.dtpUnpaidRunDate.TabIndex = 51
        Me.dtpUnpaidRunDate.Value = New Date(2013, 6, 6, 11, 49, 34, 0)
        '
        'lblProcessing
        '
        Me.lblProcessing.Location = New System.Drawing.Point(23, 355)
        Me.lblProcessing.MinimumSize = New System.Drawing.Size(75, 14)
        Me.lblProcessing.Name = "lblProcessing"
        Me.lblProcessing.Size = New System.Drawing.Size(136, 32)
        Me.lblProcessing.TabIndex = 53
        '
        'cmdPath
        '
        Me.cmdPath.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPath.Location = New System.Drawing.Point(231, 188)
        Me.cmdPath.Name = "cmdPath"
        Me.cmdPath.Size = New System.Drawing.Size(84, 24)
        Me.cmdPath.TabIndex = 4
        Me.cmdPath.Text = "File Path"
        Me.cmdPath.UseVisualStyleBackColor = True
        '
        'chkDatabaseBackup
        '
        Me.chkDatabaseBackup.AutoSize = True
        Me.chkDatabaseBackup.Checked = True
        Me.chkDatabaseBackup.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDatabaseBackup.Location = New System.Drawing.Point(303, 239)
        Me.chkDatabaseBackup.Name = "chkDatabaseBackup"
        Me.chkDatabaseBackup.Size = New System.Drawing.Size(15, 14)
        Me.chkDatabaseBackup.TabIndex = 189
        Me.chkDatabaseBackup.UseVisualStyleBackColor = True
        Me.chkDatabaseBackup.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(23, 239)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(92, 14)
        Me.Label15.TabIndex = 190
        Me.Label15.Text = "Database Backup"
        Me.Label15.Visible = False
        '
        'frmDOUnpaidRun
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(337, 387)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkDatabaseBackup)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblProcessing)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.dtpUnpaidRunDate)
        Me.Controls.Add(Me.fraUnpaidrun)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.chkReportsSuspensionOfCover)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmdPath)
        Me.Controls.Add(Me.txtChooseUnpaidRunFilePath)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.chkReportsReconPerMarketer)
        Me.Controls.Add(Me.chkReconReport)
        Me.Controls.Add(Me.chkReportsUnpaid)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbInsurer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmDOUnpaidRun"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Debit Order Unpaid Run"
        Me.fraUnpaidrun.ResumeLayout(False)
        Me.fraUnpaidrun.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkReportsReconPerMarketer As System.Windows.Forms.CheckBox
    Friend WithEvents chkReconReport As System.Windows.Forms.CheckBox
    Friend WithEvents chkReportsUnpaid As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbInsurer As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents opt1stUnpaidRun As System.Windows.Forms.RadioButton
    Friend WithEvents opt2ndUnpaidRun As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtChooseUnpaidRunFilePath As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkReportsSuspensionOfCover As System.Windows.Forms.CheckBox
    Public WithEvents btnOk As System.Windows.Forms.Button
    Public WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents fraUnpaidrun As System.Windows.Forms.GroupBox
    Friend WithEvents ofdUnpaidRun As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtpUnpaidRunDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblProcessing As System.Windows.Forms.Label
    Friend WithEvents cmdPath As System.Windows.Forms.Button
    Friend WithEvents chkDatabaseBackup As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
