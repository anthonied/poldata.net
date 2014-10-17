<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class AdminKansellasieRedes
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents Data1 As System.Windows.Forms.Label
	Public WithEvents btnDelete As System.Windows.Forms.Button
	Public WithEvents btnAdd As System.Windows.Forms.Button
	Public WithEvents btnClose As System.Windows.Forms.Button
	Public WithEvents btnSave As System.Windows.Forms.Button
	Public WithEvents chkDeleted As System.Windows.Forms.CheckBox
	Public WithEvents txtBeskrywingEngels As System.Windows.Forms.TextBox
	Public WithEvents txtBeskrywingAfrikaans As System.Windows.Forms.TextBox
	Public WithEvents lblDeleted As System.Windows.Forms.Label
	Public WithEvents lblBeskrywingEngels As System.Windows.Forms.Label
	Public WithEvents lblBeskrywingAfrikaans As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Data1 = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.dgvKansellasieRedes = New System.Windows.Forms.DataGridView()
        Me.Afrikaans = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.English = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Deleted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KansellasieRedes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.chkDeleted = New System.Windows.Forms.CheckBox()
        Me.txtBeskrywingEngels = New System.Windows.Forms.TextBox()
        Me.txtBeskrywingAfrikaans = New System.Windows.Forms.TextBox()
        Me.lblDeleted = New System.Windows.Forms.Label()
        Me.lblBeskrywingEngels = New System.Windows.Forms.Label()
        Me.lblBeskrywingAfrikaans = New System.Windows.Forms.Label()
        Me.Frame1.SuspendLayout()
        CType(Me.dgvKansellasieRedes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Data1
        '
        Me.Data1.BackColor = System.Drawing.Color.Red
        Me.Data1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Data1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Data1.ForeColor = System.Drawing.Color.Black
        Me.Data1.Location = New System.Drawing.Point(380, 28)
        Me.Data1.Name = "Data1"
        Me.Data1.Size = New System.Drawing.Size(141, 23)
        Me.Data1.TabIndex = 4
        Me.Data1.Text = "Data1"
        Me.Data1.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.Control
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDelete.Location = New System.Drawing.Point(96, 44)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDelete.Size = New System.Drawing.Size(65, 20)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.SystemColors.Control
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAdd.Location = New System.Drawing.Point(28, 44)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnAdd.Size = New System.Drawing.Size(65, 20)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Location = New System.Drawing.Point(460, 428)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClose.Size = New System.Drawing.Size(77, 25)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.dgvKansellasieRedes)
        Me.Frame1.Controls.Add(Me.btnSave)
        Me.Frame1.Controls.Add(Me.chkDeleted)
        Me.Frame1.Controls.Add(Me.txtBeskrywingEngels)
        Me.Frame1.Controls.Add(Me.txtBeskrywingAfrikaans)
        Me.Frame1.Controls.Add(Me.lblDeleted)
        Me.Frame1.Controls.Add(Me.lblBeskrywingEngels)
        Me.Frame1.Controls.Add(Me.lblBeskrywingAfrikaans)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(16, 16)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(521, 405)
        Me.Frame1.TabIndex = 4
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Cancellation reasons"
        '
        'dgvKansellasieRedes
        '
        Me.dgvKansellasieRedes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvKansellasieRedes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Afrikaans, Me.English, Me.Deleted, Me.Status, Me.KansellasieRedes})
        Me.dgvKansellasieRedes.Location = New System.Drawing.Point(15, 59)
        Me.dgvKansellasieRedes.Name = "dgvKansellasieRedes"
        Me.dgvKansellasieRedes.RowHeadersWidth = 10
        Me.dgvKansellasieRedes.Size = New System.Drawing.Size(490, 211)
        Me.dgvKansellasieRedes.TabIndex = 12
        '
        'Afrikaans
        '
        Me.Afrikaans.DataPropertyName = "BeskrywingAfrikaans"
        Me.Afrikaans.HeaderText = "Afrikaans"
        Me.Afrikaans.Name = "Afrikaans"
        Me.Afrikaans.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Afrikaans.Width = 190
        '
        'English
        '
        Me.English.DataPropertyName = "BeskrywingEngels"
        Me.English.HeaderText = "English"
        Me.English.Name = "English"
        Me.English.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.English.Width = 190
        '
        'Deleted
        '
        Me.Deleted.DataPropertyName = "Deleted"
        Me.Deleted.HeaderText = "Deleted"
        Me.Deleted.Name = "Deleted"
        Me.Deleted.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Deleted.Visible = False
        Me.Deleted.Width = 55
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Wingdings 2", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Status.DefaultCellStyle = DataGridViewCellStyle1
        Me.Status.HeaderText = ""
        Me.Status.Name = "Status"
        '
        'KansellasieRedes
        '
        Me.KansellasieRedes.DataPropertyName = "pkKansellasieRedes"
        Me.KansellasieRedes.HeaderText = "KansellasieRedes"
        Me.KansellasieRedes.Name = "KansellasieRedes"
        Me.KansellasieRedes.Visible = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.Control
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSave.Enabled = False
        Me.btnSave.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSave.Location = New System.Drawing.Point(148, 372)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSave.Size = New System.Drawing.Size(73, 21)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'chkDeleted
        '
        Me.chkDeleted.BackColor = System.Drawing.SystemColors.Control
        Me.chkDeleted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDeleted.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkDeleted.Enabled = False
        Me.chkDeleted.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDeleted.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkDeleted.Location = New System.Drawing.Point(140, 344)
        Me.chkDeleted.Name = "chkDeleted"
        Me.chkDeleted.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkDeleted.Size = New System.Drawing.Size(21, 13)
        Me.chkDeleted.TabIndex = 7
        Me.chkDeleted.UseVisualStyleBackColor = False
        '
        'txtBeskrywingEngels
        '
        Me.txtBeskrywingEngels.AcceptsReturn = True
        Me.txtBeskrywingEngels.BackColor = System.Drawing.SystemColors.Window
        Me.txtBeskrywingEngels.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBeskrywingEngels.Enabled = False
        Me.txtBeskrywingEngels.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBeskrywingEngels.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBeskrywingEngels.Location = New System.Drawing.Point(148, 308)
        Me.txtBeskrywingEngels.MaxLength = 50
        Me.txtBeskrywingEngels.Name = "txtBeskrywingEngels"
        Me.txtBeskrywingEngels.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBeskrywingEngels.Size = New System.Drawing.Size(361, 20)
        Me.txtBeskrywingEngels.TabIndex = 6
        '
        'txtBeskrywingAfrikaans
        '
        Me.txtBeskrywingAfrikaans.AcceptsReturn = True
        Me.txtBeskrywingAfrikaans.BackColor = System.Drawing.SystemColors.Window
        Me.txtBeskrywingAfrikaans.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBeskrywingAfrikaans.Enabled = False
        Me.txtBeskrywingAfrikaans.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBeskrywingAfrikaans.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBeskrywingAfrikaans.Location = New System.Drawing.Point(148, 276)
        Me.txtBeskrywingAfrikaans.MaxLength = 50
        Me.txtBeskrywingAfrikaans.Name = "txtBeskrywingAfrikaans"
        Me.txtBeskrywingAfrikaans.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBeskrywingAfrikaans.Size = New System.Drawing.Size(361, 20)
        Me.txtBeskrywingAfrikaans.TabIndex = 5
        '
        'lblDeleted
        '
        Me.lblDeleted.BackColor = System.Drawing.SystemColors.Control
        Me.lblDeleted.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDeleted.Enabled = False
        Me.lblDeleted.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeleted.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDeleted.Location = New System.Drawing.Point(12, 344)
        Me.lblDeleted.Name = "lblDeleted"
        Me.lblDeleted.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDeleted.Size = New System.Drawing.Size(125, 13)
        Me.lblDeleted.TabIndex = 10
        Me.lblDeleted.Text = "Deleted"
        '
        'lblBeskrywingEngels
        '
        Me.lblBeskrywingEngels.BackColor = System.Drawing.SystemColors.Control
        Me.lblBeskrywingEngels.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblBeskrywingEngels.Enabled = False
        Me.lblBeskrywingEngels.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBeskrywingEngels.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBeskrywingEngels.Location = New System.Drawing.Point(12, 311)
        Me.lblBeskrywingEngels.Name = "lblBeskrywingEngels"
        Me.lblBeskrywingEngels.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBeskrywingEngels.Size = New System.Drawing.Size(125, 13)
        Me.lblBeskrywingEngels.TabIndex = 9
        Me.lblBeskrywingEngels.Text = "Description in English"
        '
        'lblBeskrywingAfrikaans
        '
        Me.lblBeskrywingAfrikaans.BackColor = System.Drawing.SystemColors.Control
        Me.lblBeskrywingAfrikaans.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblBeskrywingAfrikaans.Enabled = False
        Me.lblBeskrywingAfrikaans.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBeskrywingAfrikaans.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBeskrywingAfrikaans.Location = New System.Drawing.Point(12, 278)
        Me.lblBeskrywingAfrikaans.Name = "lblBeskrywingAfrikaans"
        Me.lblBeskrywingAfrikaans.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBeskrywingAfrikaans.Size = New System.Drawing.Size(125, 13)
        Me.lblBeskrywingAfrikaans.TabIndex = 8
        Me.lblBeskrywingAfrikaans.Text = "Description in Afrikaans"
        '
        'AdminKansellasieRedes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(554, 463)
        Me.Controls.Add(Me.Data1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Frame1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AdminKansellasieRedes"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Poldata Admin - Cancellation reasons"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        CType(Me.dgvKansellasieRedes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvKansellasieRedes As System.Windows.Forms.DataGridView
    Friend WithEvents Afrikaans As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents English As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Deleted As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KansellasieRedes As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class