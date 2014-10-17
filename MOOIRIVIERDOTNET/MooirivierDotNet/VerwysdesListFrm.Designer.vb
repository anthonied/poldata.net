<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class VerwysdesListFrm
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
	Public WithEvents btnClose As System.Windows.Forms.Button
	Public WithEvents cmdKommissie As System.Windows.Forms.Button
	Public WithEvents cmbAfsluitdatums As System.Windows.Forms.ComboBox
	Public WithEvents rdAfsluitings As System.Windows.Forms.RadioButton
	Public WithEvents rdVerwysdes As System.Windows.Forms.RadioButton
	Public WithEvents DataVerwysdes As System.Windows.Forms.Label
    Public WithEvents btnKanselleer As System.Windows.Forms.Button
	Public WithEvents btnEdit As System.Windows.Forms.Button
	Public WithEvents btnVoegby As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cmdKommissie = New System.Windows.Forms.Button()
        Me.cmbAfsluitdatums = New System.Windows.Forms.ComboBox()
        Me.rdAfsluitings = New System.Windows.Forms.RadioButton()
        Me.rdVerwysdes = New System.Windows.Forms.RadioButton()
        Me.DataVerwysdes = New System.Windows.Forms.Label()
        Me.btnKanselleer = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnVoegby = New System.Windows.Forms.Button()
        Me.dgvVerwysdes = New System.Windows.Forms.DataGridView()
        CType(Me.dgvVerwysdes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Location = New System.Drawing.Point(585, 380)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClose.Size = New System.Drawing.Size(77, 25)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'cmdKommissie
        '
        Me.cmdKommissie.BackColor = System.Drawing.SystemColors.Control
        Me.cmdKommissie.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdKommissie.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdKommissie.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdKommissie.Location = New System.Drawing.Point(271, 10)
        Me.cmdKommissie.Name = "cmdKommissie"
        Me.cmdKommissie.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdKommissie.Size = New System.Drawing.Size(81, 21)
        Me.cmdKommissie.TabIndex = 7
        Me.cmdKommissie.Text = "Commission"
        Me.cmdKommissie.UseVisualStyleBackColor = False
        Me.cmdKommissie.Visible = False
        '
        'cmbAfsluitdatums
        '
        Me.cmbAfsluitdatums.BackColor = System.Drawing.SystemColors.Window
        Me.cmbAfsluitdatums.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbAfsluitdatums.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAfsluitdatums.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbAfsluitdatums.Location = New System.Drawing.Point(567, 9)
        Me.cmbAfsluitdatums.Name = "cmbAfsluitdatums"
        Me.cmbAfsluitdatums.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbAfsluitdatums.Size = New System.Drawing.Size(95, 22)
        Me.cmbAfsluitdatums.TabIndex = 6
        '
        'rdAfsluitings
        '
        Me.rdAfsluitings.BackColor = System.Drawing.SystemColors.Control
        Me.rdAfsluitings.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdAfsluitings.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdAfsluitings.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdAfsluitings.Location = New System.Drawing.Point(462, 12)
        Me.rdAfsluitings.Name = "rdAfsluitings"
        Me.rdAfsluitings.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdAfsluitings.Size = New System.Drawing.Size(76, 17)
        Me.rdAfsluitings.TabIndex = 5
        Me.rdAfsluitings.TabStop = True
        Me.rdAfsluitings.Text = "History"
        Me.rdAfsluitings.UseVisualStyleBackColor = False
        '
        'rdVerwysdes
        '
        Me.rdVerwysdes.BackColor = System.Drawing.SystemColors.Control
        Me.rdVerwysdes.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdVerwysdes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdVerwysdes.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdVerwysdes.Location = New System.Drawing.Point(380, 12)
        Me.rdVerwysdes.Name = "rdVerwysdes"
        Me.rdVerwysdes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdVerwysdes.Size = New System.Drawing.Size(76, 17)
        Me.rdVerwysdes.TabIndex = 4
        Me.rdVerwysdes.TabStop = True
        Me.rdVerwysdes.Text = "Current"
        Me.rdVerwysdes.UseVisualStyleBackColor = False
        '
        'DataVerwysdes
        '
        Me.DataVerwysdes.BackColor = System.Drawing.Color.Red
        Me.DataVerwysdes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DataVerwysdes.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataVerwysdes.ForeColor = System.Drawing.Color.Black
        Me.DataVerwysdes.Location = New System.Drawing.Point(12, 384)
        Me.DataVerwysdes.Name = "DataVerwysdes"
        Me.DataVerwysdes.Size = New System.Drawing.Size(185, 23)
        Me.DataVerwysdes.TabIndex = 9
        Me.DataVerwysdes.Text = "DataVerwysdes"
        Me.DataVerwysdes.Visible = False
        '
        'btnKanselleer
        '
        Me.btnKanselleer.BackColor = System.Drawing.SystemColors.Control
        Me.btnKanselleer.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnKanselleer.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKanselleer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnKanselleer.Location = New System.Drawing.Point(186, 10)
        Me.btnKanselleer.Name = "btnKanselleer"
        Me.btnKanselleer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnKanselleer.Size = New System.Drawing.Size(81, 21)
        Me.btnKanselleer.TabIndex = 2
        Me.btnKanselleer.Text = "Cancel"
        Me.btnKanselleer.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.SystemColors.Control
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEdit.Location = New System.Drawing.Point(101, 10)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnEdit.Size = New System.Drawing.Size(81, 21)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnVoegby
        '
        Me.btnVoegby.BackColor = System.Drawing.SystemColors.Control
        Me.btnVoegby.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnVoegby.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoegby.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnVoegby.Location = New System.Drawing.Point(16, 10)
        Me.btnVoegby.Name = "btnVoegby"
        Me.btnVoegby.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnVoegby.Size = New System.Drawing.Size(81, 21)
        Me.btnVoegby.TabIndex = 0
        Me.btnVoegby.Text = "Add"
        Me.btnVoegby.UseVisualStyleBackColor = False
        '
        'dgvVerwysdes
        '
        Me.dgvVerwysdes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvVerwysdes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVerwysdes.Location = New System.Drawing.Point(12, 41)
        Me.dgvVerwysdes.Name = "dgvVerwysdes"
        Me.dgvVerwysdes.ReadOnly = True
        Me.dgvVerwysdes.RowHeadersWidth = 5
        Me.dgvVerwysdes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVerwysdes.Size = New System.Drawing.Size(650, 333)
        Me.dgvVerwysdes.TabIndex = 10
        '
        'VerwysdesListFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(668, 408)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvVerwysdes)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.cmdKommissie)
        Me.Controls.Add(Me.cmbAfsluitdatums)
        Me.Controls.Add(Me.rdAfsluitings)
        Me.Controls.Add(Me.rdVerwysdes)
        Me.Controls.Add(Me.DataVerwysdes)
        Me.Controls.Add(Me.btnKanselleer)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnVoegby)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "VerwysdesListFrm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Poldata - Policy functions  - Referals"
        CType(Me.dgvVerwysdes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvVerwysdes As System.Windows.Forms.DataGridView
#End Region 
End Class