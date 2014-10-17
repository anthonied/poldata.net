<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class BriefStatus
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
	Public WithEvents btnHelp As System.Windows.Forms.Button
	Public WithEvents btnDrukLys As System.Windows.Forms.Button
	Public WithEvents btnBack As System.Windows.Forms.Button
	Public WithEvents btnOk As System.Windows.Forms.Button
    Public WithEvents lblTotaal As System.Windows.Forms.Label
	Public WithEvents lbl As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Data1 = New System.Windows.Forms.Label
        Me.btnHelp = New System.Windows.Forms.Button
        Me.btnDrukLys = New System.Windows.Forms.Button
        Me.btnBack = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.lblTotaal = New System.Windows.Forms.Label
        Me.lbl = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Policy_number = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Insured = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtFormToPopulate = New System.Windows.Forms.TextBox
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Data1
        '
        Me.Data1.BackColor = System.Drawing.Color.Red
        Me.Data1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Data1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Data1.ForeColor = System.Drawing.Color.Black
        Me.Data1.Location = New System.Drawing.Point(184, 492)
        Me.Data1.Name = "Data1"
        Me.Data1.Size = New System.Drawing.Size(76, 25)
        Me.Data1.TabIndex = 0
        Me.Data1.Text = "Data1"
        Me.Data1.Visible = False
        '
        'btnHelp
        '
        Me.btnHelp.BackColor = System.Drawing.SystemColors.Control
        Me.btnHelp.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnHelp.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHelp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnHelp.Location = New System.Drawing.Point(560, 488)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnHelp.Size = New System.Drawing.Size(85, 25)
        Me.btnHelp.TabIndex = 7
        Me.btnHelp.Text = "&Help"
        Me.btnHelp.UseVisualStyleBackColor = False
        '
        'btnDrukLys
        '
        Me.btnDrukLys.BackColor = System.Drawing.SystemColors.Control
        Me.btnDrukLys.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnDrukLys.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDrukLys.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDrukLys.Location = New System.Drawing.Point(532, 24)
        Me.btnDrukLys.Name = "btnDrukLys"
        Me.btnDrukLys.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDrukLys.Size = New System.Drawing.Size(113, 22)
        Me.btnDrukLys.TabIndex = 5
        Me.btnDrukLys.Text = "Print this list"
        Me.btnDrukLys.UseVisualStyleBackColor = False
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.SystemColors.Control
        Me.btnBack.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnBack.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBack.Location = New System.Drawing.Point(468, 488)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnBack.Size = New System.Drawing.Size(85, 25)
        Me.btnBack.TabIndex = 2
        Me.btnBack.Text = "&Cancel"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Location = New System.Drawing.Point(376, 488)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New System.Drawing.Size(85, 25)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "&Ok"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'lblTotaal
        '
        Me.lblTotaal.BackColor = System.Drawing.SystemColors.Control
        Me.lblTotaal.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTotaal.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotaal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotaal.Location = New System.Drawing.Point(73, 494)
        Me.lblTotaal.Name = "lblTotaal"
        Me.lblTotaal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTotaal.Size = New System.Drawing.Size(60, 19)
        Me.lblTotaal.TabIndex = 6
        Me.lblTotaal.Text = "Total"
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.SystemColors.Control
        Me.lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl.Location = New System.Drawing.Point(20, 494)
        Me.lbl.Name = "lbl"
        Me.lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl.Size = New System.Drawing.Size(47, 19)
        Me.lbl.TabIndex = 4
        Me.lbl.Text = "Total"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(12, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(121, 19)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Policies for printing"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Policy_number, Me.Insured, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.DataGridView1.Location = New System.Drawing.Point(3, 52)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(651, 413)
        Me.DataGridView1.TabIndex = 9
        '
        'Policy_number
        '
        Me.Policy_number.DataPropertyName = "POLISNO"
        Me.Policy_number.HeaderText = "Policy number"
        Me.Policy_number.Name = "Policy_number"
        '
        'Insured
        '
        Me.Insured.DataPropertyName = "Surname"
        Me.Insured.HeaderText = "Surname"
        Me.Insured.Name = "Insured"
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "Voorl"
        Me.Column2.HeaderText = "Initials"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "Area"
        Me.Column3.HeaderText = "Area"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "Status"
        Me.Column4.HeaderText = "Status"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "SavePosbesbesteming"
        Me.Column5.HeaderText = "Mail Destination"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 150
        '
        'txtFormToPopulate
        '
        Me.txtFormToPopulate.AcceptsReturn = True
        Me.txtFormToPopulate.BackColor = System.Drawing.SystemColors.Window
        Me.txtFormToPopulate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFormToPopulate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFormToPopulate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFormToPopulate.Location = New System.Drawing.Point(163, 469)
        Me.txtFormToPopulate.MaxLength = 0
        Me.txtFormToPopulate.Name = "txtFormToPopulate"
        Me.txtFormToPopulate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFormToPopulate.Size = New System.Drawing.Size(237, 20)
        Me.txtFormToPopulate.TabIndex = 13
        Me.txtFormToPopulate.Text = "Used for name of form to populate with values"
        Me.txtFormToPopulate.Visible = False
        '
        'BriefStatus
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnBack
        Me.ClientSize = New System.Drawing.Size(666, 533)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtFormToPopulate)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Data1)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnDrukLys)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.lblTotaal)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.Label6)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BriefStatus"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Poldata - Printouts - Policies for printing"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Policy_number As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Insured As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents txtFormToPopulate As System.Windows.Forms.TextBox
#End Region
End Class