<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class vers_bes
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
    Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.dgvNamesList = New System.Windows.Forms.DataGridView()
        Me.VERSEKERDE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VOORL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POLISNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Area_besk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActiveIcon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADRES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADRES1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADRES2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PREMIEKODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HUIS_TEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WERK_TEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.selfoon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gekans = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vehicles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Data1 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.dgvNamesList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvNamesList
        '
        Me.dgvNamesList.AllowUserToAddRows = False
        Me.dgvNamesList.AllowUserToDeleteRows = False
        Me.dgvNamesList.AllowUserToOrderColumns = True
        Me.dgvNamesList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvNamesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNamesList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VERSEKERDE, Me.VOORL, Me.POLISNO, Me.Area_besk, Me.ID, Me.ActiveIcon, Me.ADRES, Me.ADRES1, Me.ADRES2, Me.PREMIEKODE, Me.HUIS_TEL, Me.WERK_TEL, Me.selfoon, Me.Gekans, Me.Vehicles})
        Me.dgvNamesList.Location = New System.Drawing.Point(0, 0)
        Me.dgvNamesList.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvNamesList.Name = "dgvNamesList"
        Me.dgvNamesList.RowHeadersWidth = 10
        Me.dgvNamesList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvNamesList.Size = New System.Drawing.Size(785, 589)
        Me.dgvNamesList.TabIndex = 3
        '
        'VERSEKERDE
        '
        Me.VERSEKERDE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.VERSEKERDE.DataPropertyName = "VERSEKERDE"
        Me.VERSEKERDE.Frozen = True
        Me.VERSEKERDE.HeaderText = "Surname"
        Me.VERSEKERDE.Name = "VERSEKERDE"
        Me.VERSEKERDE.ReadOnly = True
        Me.VERSEKERDE.Width = 75
        '
        'VOORL
        '
        Me.VOORL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.VOORL.DataPropertyName = "VOORL"
        Me.VOORL.Frozen = True
        Me.VOORL.HeaderText = "Initials"
        Me.VOORL.MinimumWidth = 40
        Me.VOORL.Name = "VOORL"
        Me.VOORL.ReadOnly = True
        Me.VOORL.Width = 40
        '
        'POLISNO
        '
        Me.POLISNO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.POLISNO.DataPropertyName = "POLISNO"
        Me.POLISNO.Frozen = True
        Me.POLISNO.HeaderText = "Policy Number"
        Me.POLISNO.MinimumWidth = 100
        Me.POLISNO.Name = "POLISNO"
        Me.POLISNO.ReadOnly = True
        '
        'Area_besk
        '
        Me.Area_besk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.Area_besk.DataPropertyName = "Area_besk"
        Me.Area_besk.HeaderText = "Area Description"
        Me.Area_besk.MinimumWidth = 65
        Me.Area_besk.Name = "Area_besk"
        Me.Area_besk.ReadOnly = True
        Me.Area_besk.Width = 65
        '
        'ID
        '
        Me.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ID.DataPropertyName = "id_nom"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Width = 41
        '
        'ActiveIcon
        '
        Me.ActiveIcon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.ActiveIcon.DataPropertyName = "ActiveIcon"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Wingdings 2", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ActiveIcon.DefaultCellStyle = DataGridViewCellStyle1
        Me.ActiveIcon.HeaderText = "Active"
        Me.ActiveIcon.MinimumWidth = 40
        Me.ActiveIcon.Name = "ActiveIcon"
        Me.ActiveIcon.Width = 40
        '
        'ADRES
        '
        Me.ADRES.DataPropertyName = "ADRES"
        Me.ADRES.HeaderText = "Street/Box"
        Me.ADRES.Name = "ADRES"
        Me.ADRES.ReadOnly = True
        Me.ADRES.Width = 83
        '
        'ADRES1
        '
        Me.ADRES1.DataPropertyName = "ADRES1"
        Me.ADRES1.HeaderText = "Suburb/Town"
        Me.ADRES1.Name = "ADRES1"
        Me.ADRES1.ReadOnly = True
        Me.ADRES1.Width = 97
        '
        'ADRES2
        '
        Me.ADRES2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ADRES2.DataPropertyName = "ADRES2"
        Me.ADRES2.HeaderText = "Code"
        Me.ADRES2.Name = "ADRES2"
        Me.ADRES2.ReadOnly = True
        Me.ADRES2.Width = 57
        '
        'PREMIEKODE
        '
        Me.PREMIEKODE.DataPropertyName = "PREMIEKODE"
        Me.PREMIEKODE.HeaderText = "Premium"
        Me.PREMIEKODE.Name = "PREMIEKODE"
        Me.PREMIEKODE.ReadOnly = True
        Me.PREMIEKODE.Visible = False
        Me.PREMIEKODE.Width = 72
        '
        'HUIS_TEL
        '
        Me.HUIS_TEL.DataPropertyName = "HUIS_TEL2"
        Me.HUIS_TEL.HeaderText = "Tel(h)"
        Me.HUIS_TEL.Name = "HUIS_TEL"
        Me.HUIS_TEL.ReadOnly = True
        Me.HUIS_TEL.Width = 59
        '
        'WERK_TEL
        '
        Me.WERK_TEL.DataPropertyName = "WERK_TEL2"
        Me.WERK_TEL.HeaderText = "Tel(w)"
        Me.WERK_TEL.Name = "WERK_TEL"
        Me.WERK_TEL.ReadOnly = True
        Me.WERK_TEL.Width = 63
        '
        'selfoon
        '
        Me.selfoon.DataPropertyName = "sel_tel"
        Me.selfoon.HeaderText = "Cellphone"
        Me.selfoon.Name = "selfoon"
        Me.selfoon.ReadOnly = True
        Me.selfoon.Width = 79
        '
        'Gekans
        '
        Me.Gekans.DataPropertyName = "Gekans"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Gekans.DefaultCellStyle = DataGridViewCellStyle2
        Me.Gekans.HeaderText = "Active Boolean"
        Me.Gekans.Name = "Gekans"
        Me.Gekans.ReadOnly = True
        Me.Gekans.Visible = False
        Me.Gekans.Width = 97
        '
        'Vehicles
        '
        Me.Vehicles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Vehicles.DataPropertyName = "Nommerplate"
        Me.Vehicles.HeaderText = "Vehicles (all numberplates in brackets are deleted vehicles)"
        Me.Vehicles.Name = "Vehicles"
        Me.Vehicles.Visible = False
        '
        'Data1
        '
        Me.Data1.BackColor = System.Drawing.Color.Red
        Me.Data1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Data1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Data1.ForeColor = System.Drawing.Color.Black
        Me.Data1.Location = New System.Drawing.Point(8, 564)
        Me.Data1.Name = "Data1"
        Me.Data1.Size = New System.Drawing.Size(76, 23)
        Me.Data1.TabIndex = 0
        Me.Data1.Text = "Data1"
        Me.Data1.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(4, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(513, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Gekans = 0 is aktiewe polisse      "
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(24, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(633, 33)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Selekteer die versekerde deur op enige sel in sy ry te click. "
        '
        'vers_bes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(786, 589)
        Me.Controls.Add(Me.dgvNamesList)
        Me.Controls.Add(Me.Data1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(8, 139)
        Me.Name = "vers_bes"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insured details"
        CType(Me.dgvNamesList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvNamesList As System.Windows.Forms.DataGridView
    Friend WithEvents VERSEKERDE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VOORL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POLISNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Area_besk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActiveIcon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADRES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADRES1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADRES2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PREMIEKODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HUIS_TEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WERK_TEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents selfoon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gekans As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vehicles As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class