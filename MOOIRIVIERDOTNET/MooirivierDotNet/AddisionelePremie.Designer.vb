<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class AddisionelePremie
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
	Public WithEvents btnClear As System.Windows.Forms.Button
	Public WithEvents btnVulHuidigePremies As System.Windows.Forms.Button
	Public WithEvents cmbGeskiedenis As System.Windows.Forms.ComboBox
    Public WithEvents btnOk As System.Windows.Forms.Button
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents Image1 As System.Windows.Forms.PictureBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddisionelePremie))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnVulHuidigePremies = New System.Windows.Forms.Button()
        Me.cmbGeskiedenis = New System.Windows.Forms.ComboBox()
        Me.Image1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvAddisionelePremie = New System.Windows.Forms.DataGridView()
        Me.Text1 = New System.Windows.Forms.TextBox()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAddisionelePremie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Location = New System.Drawing.Point(419, 586)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New System.Drawing.Size(77, 25)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "&Ok"
        Me.ToolTip1.SetToolTip(Me.btnOk, "Stoor")
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(502, 586)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(77, 25)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Cancel"
        Me.ToolTip1.SetToolTip(Me.btnCancel, "Kanselleer")
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.SystemColors.Control
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnClear.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClear.Location = New System.Drawing.Point(450, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClear.Size = New System.Drawing.Size(65, 22)
        Me.btnClear.TabIndex = 7
        Me.btnClear.TabStop = False
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnVulHuidigePremies
        '
        Me.btnVulHuidigePremies.BackColor = System.Drawing.SystemColors.Control
        Me.btnVulHuidigePremies.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnVulHuidigePremies.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVulHuidigePremies.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnVulHuidigePremies.Location = New System.Drawing.Point(290, 3)
        Me.btnVulHuidigePremies.Name = "btnVulHuidigePremies"
        Me.btnVulHuidigePremies.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnVulHuidigePremies.Size = New System.Drawing.Size(154, 22)
        Me.btnVulHuidigePremies.TabIndex = 6
        Me.btnVulHuidigePremies.TabStop = False
        Me.btnVulHuidigePremies.Text = "Fill with current premiums"
        Me.btnVulHuidigePremies.UseVisualStyleBackColor = False
        '
        'cmbGeskiedenis
        '
        Me.cmbGeskiedenis.BackColor = System.Drawing.SystemColors.Window
        Me.cmbGeskiedenis.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbGeskiedenis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGeskiedenis.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGeskiedenis.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbGeskiedenis.Location = New System.Drawing.Point(93, 3)
        Me.cmbGeskiedenis.MaxDropDownItems = 15
        Me.cmbGeskiedenis.Name = "cmbGeskiedenis"
        Me.cmbGeskiedenis.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbGeskiedenis.Size = New System.Drawing.Size(137, 22)
        Me.cmbGeskiedenis.TabIndex = 5
        Me.cmbGeskiedenis.TabStop = False
        '
        'Image1
        '
        Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image1.Image = CType(resources.GetObject("Image1.Image"), System.Drawing.Image)
        Me.Image1.Location = New System.Drawing.Point(560, 9)
        Me.Image1.Name = "Image1"
        Me.Image1.Size = New System.Drawing.Size(19, 16)
        Me.Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Image1.TabIndex = 8
        Me.Image1.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(39, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(48, 21)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "History"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvAddisionelePremie
        '
        Me.dgvAddisionelePremie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAddisionelePremie.Location = New System.Drawing.Point(19, 32)
        Me.dgvAddisionelePremie.Name = "dgvAddisionelePremie"
        Me.dgvAddisionelePremie.Size = New System.Drawing.Size(560, 546)
        Me.dgvAddisionelePremie.TabIndex = 9
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Location = New System.Drawing.Point(19, 584)
        Me.Text1.MaxLength = 50
        Me.Text1.Name = "Text1"
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.Size = New System.Drawing.Size(61, 20)
        Me.Text1.TabIndex = 0
        Me.Text1.Visible = False
        '
        'AddisionelePremie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(591, 620)
        Me.Controls.Add(Me.dgvAddisionelePremie)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnVulHuidigePremies)
        Me.Controls.Add(Me.cmbGeskiedenis)
        Me.Controls.Add(Me.Text1)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Image1)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddisionelePremie"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Additional premium"
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAddisionelePremie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvAddisionelePremie As System.Windows.Forms.DataGridView
    Public WithEvents Text1 As System.Windows.Forms.TextBox
#End Region
End Class