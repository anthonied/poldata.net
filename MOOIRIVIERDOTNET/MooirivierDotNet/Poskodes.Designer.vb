<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class PoskodesSoek
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
	Public WithEvents cmbCodeType As System.Windows.Forms.ComboBox
	Public WithEvents txtFormToPopulate As System.Windows.Forms.TextBox
	Public WithEvents Data1 As System.Windows.Forms.Label
	Public WithEvents txtPoskode As System.Windows.Forms.TextBox
	Public WithEvents btnClear As System.Windows.Forms.Button
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents soek As System.Windows.Forms.Button
	Public WithEvents soekdorp As System.Windows.Forms.TextBox
	Public WithEvents soekvoorstad As System.Windows.Forms.TextBox
	Public WithEvents OpdateerKodes As System.Windows.Forms.Button
    Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.soek = New System.Windows.Forms.Button()
        Me.DetailGridView = New System.Windows.Forms.DataGridView()
        Me.Voorstad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dorp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PoskodeStraat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PoskodePosbus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbCodeType = New System.Windows.Forms.ComboBox()
        Me.txtFormToPopulate = New System.Windows.Forms.TextBox()
        Me.Data1 = New System.Windows.Forms.Label()
        Me.txtPoskode = New System.Windows.Forms.TextBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.soekdorp = New System.Windows.Forms.TextBox()
        Me.soekvoorstad = New System.Windows.Forms.TextBox()
        Me.OpdateerKodes = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.DetailGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'soek
        '
        Me.soek.BackColor = System.Drawing.SystemColors.Control
        Me.soek.Cursor = System.Windows.Forms.Cursors.Default
        Me.soek.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.soek.ForeColor = System.Drawing.SystemColors.ControlText
        Me.soek.Location = New System.Drawing.Point(16, 280)
        Me.soek.Name = "soek"
        Me.soek.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.soek.Size = New System.Drawing.Size(57, 20)
        Me.soek.TabIndex = 3
        Me.soek.Text = "&Search"
        Me.soek.UseVisualStyleBackColor = False
        '
        'DetailGridView
        '
        Me.DetailGridView.AllowUserToResizeColumns = False
        Me.DetailGridView.AllowUserToResizeRows = False
        Me.DetailGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DetailGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Voorstad, Me.Dorp, Me.PoskodeStraat, Me.PoskodePosbus})
        Me.DetailGridView.Location = New System.Drawing.Point(150, 16)
        Me.DetailGridView.MultiSelect = False
        Me.DetailGridView.Name = "DetailGridView"
        Me.DetailGridView.RowHeadersVisible = False
        Me.DetailGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DetailGridView.Size = New System.Drawing.Size(513, 288)
        Me.DetailGridView.TabIndex = 15
        Me.DetailGridView.TabStop = False
        '
        'Voorstad
        '
        Me.Voorstad.DataPropertyName = "Voorstad"
        Me.Voorstad.HeaderText = "Suburb"
        Me.Voorstad.Name = "Voorstad"
        Me.Voorstad.Width = 200
        '
        'Dorp
        '
        Me.Dorp.DataPropertyName = "Dorp"
        Me.Dorp.HeaderText = "Town / City"
        Me.Dorp.Name = "Dorp"
        Me.Dorp.Width = 200
        '
        'PoskodeStraat
        '
        Me.PoskodeStraat.DataPropertyName = "Poskode"
        Me.PoskodeStraat.HeaderText = "Postal Codes (Street)"
        Me.PoskodeStraat.Name = "PoskodeStraat"
        Me.PoskodeStraat.Width = 110
        '
        'PoskodePosbus
        '
        Me.PoskodePosbus.DataPropertyName = "PoskodePosbus"
        Me.PoskodePosbus.HeaderText = "Postal Codes (PO Box)"
        Me.PoskodePosbus.Name = "PoskodePosbus"
        Me.PoskodePosbus.Visible = False
        '
        'cmbCodeType
        '
        Me.cmbCodeType.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCodeType.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbCodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCodeType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCodeType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbCodeType.Items.AddRange(New Object() {"Street", "PO Box"})
        Me.cmbCodeType.Location = New System.Drawing.Point(16, 232)
        Me.cmbCodeType.Name = "cmbCodeType"
        Me.cmbCodeType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbCodeType.Size = New System.Drawing.Size(117, 22)
        Me.cmbCodeType.TabIndex = 13
        '
        'txtFormToPopulate
        '
        Me.txtFormToPopulate.AcceptsReturn = True
        Me.txtFormToPopulate.BackColor = System.Drawing.SystemColors.Window
        Me.txtFormToPopulate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFormToPopulate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFormToPopulate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFormToPopulate.Location = New System.Drawing.Point(150, 313)
        Me.txtFormToPopulate.MaxLength = 0
        Me.txtFormToPopulate.Name = "txtFormToPopulate"
        Me.txtFormToPopulate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFormToPopulate.Size = New System.Drawing.Size(237, 20)
        Me.txtFormToPopulate.TabIndex = 12
        Me.txtFormToPopulate.Text = "Used for name of form to populate with values"
        Me.txtFormToPopulate.Visible = False
        '
        'Data1
        '
        Me.Data1.BackColor = System.Drawing.Color.Red
        Me.Data1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Data1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Data1.ForeColor = System.Drawing.Color.Black
        Me.Data1.Location = New System.Drawing.Point(16, 317)
        Me.Data1.Name = "Data1"
        Me.Data1.Size = New System.Drawing.Size(121, 23)
        Me.Data1.TabIndex = 14
        Me.Data1.Text = "Data1"
        Me.Data1.Visible = False
        '
        'txtPoskode
        '
        Me.txtPoskode.AcceptsReturn = True
        Me.txtPoskode.BackColor = System.Drawing.SystemColors.Window
        Me.txtPoskode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPoskode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPoskode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPoskode.Location = New System.Drawing.Point(16, 184)
        Me.txtPoskode.MaxLength = 0
        Me.txtPoskode.Name = "txtPoskode"
        Me.txtPoskode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPoskode.Size = New System.Drawing.Size(53, 20)
        Me.txtPoskode.TabIndex = 2
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.SystemColors.Control
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnClear.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClear.Location = New System.Drawing.Point(78, 280)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClear.Size = New System.Drawing.Size(57, 20)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(586, 317)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(85, 25)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'soekdorp
        '
        Me.soekdorp.AcceptsReturn = True
        Me.soekdorp.BackColor = System.Drawing.SystemColors.Window
        Me.soekdorp.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.soekdorp.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.soekdorp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.soekdorp.Location = New System.Drawing.Point(16, 136)
        Me.soekdorp.MaxLength = 0
        Me.soekdorp.Name = "soekdorp"
        Me.soekdorp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.soekdorp.Size = New System.Drawing.Size(117, 20)
        Me.soekdorp.TabIndex = 1
        '
        'soekvoorstad
        '
        Me.soekvoorstad.AcceptsReturn = True
        Me.soekvoorstad.BackColor = System.Drawing.SystemColors.Window
        Me.soekvoorstad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.soekvoorstad.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.soekvoorstad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.soekvoorstad.Location = New System.Drawing.Point(16, 88)
        Me.soekvoorstad.MaxLength = 0
        Me.soekvoorstad.Name = "soekvoorstad"
        Me.soekvoorstad.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.soekvoorstad.Size = New System.Drawing.Size(117, 20)
        Me.soekvoorstad.TabIndex = 0
        '
        'OpdateerKodes
        '
        Me.OpdateerKodes.BackColor = System.Drawing.SystemColors.Control
        Me.OpdateerKodes.Cursor = System.Windows.Forms.Cursors.Default
        Me.OpdateerKodes.Enabled = False
        Me.OpdateerKodes.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpdateerKodes.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OpdateerKodes.Location = New System.Drawing.Point(492, 317)
        Me.OpdateerKodes.Name = "OpdateerKodes"
        Me.OpdateerKodes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OpdateerKodes.Size = New System.Drawing.Size(85, 25)
        Me.OpdateerKodes.TabIndex = 5
        Me.OpdateerKodes.Text = "Ok"
        Me.OpdateerKodes.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 216)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Street / PO Box"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(16, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(117, 29)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Search using the following criteria:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 168)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(96, 21)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Postal Codes"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(16, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Town / City"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Suburb"
        '
        'PoskodesSoek
        '
        Me.AcceptButton = Me.soek
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(679, 356)
        Me.ControlBox = False
        Me.Controls.Add(Me.DetailGridView)
        Me.Controls.Add(Me.cmbCodeType)
        Me.Controls.Add(Me.txtFormToPopulate)
        Me.Controls.Add(Me.Data1)
        Me.Controls.Add(Me.txtPoskode)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.soek)
        Me.Controls.Add(Me.soekdorp)
        Me.Controls.Add(Me.soekvoorstad)
        Me.Controls.Add(Me.OpdateerKodes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PoskodesSoek"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Poldata - National postal codes"
        CType(Me.DetailGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DetailGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Voorstad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dorp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PoskodeStraat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PoskodePosbus As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class