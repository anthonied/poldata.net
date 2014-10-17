<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmLysDatumWysig
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
    Public WithEvents btnAllBack As System.Windows.Forms.Button
	Public WithEvents btnAllOver As System.Windows.Forms.Button
	Public WithEvents btnOneBack As System.Windows.Forms.Button
	Public WithEvents btnOneOver As System.Windows.Forms.Button
	Public WithEvents txtWysigingskode As System.Windows.Forms.TextBox
	Public WithEvents btnSoekWysigingskode As System.Windows.Forms.Button
	Public WithEvents txtBeskrywing As System.Windows.Forms.TextBox
	Public WithEvents txtKode As System.Windows.Forms.TextBox
    Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents btnOK As System.Windows.Forms.Button
	Public WithEvents cmbGebruiker As System.Windows.Forms.ComboBox
	Public WithEvents dtpTotDatum As AxMSComCtl2.AxDTPicker
	Public WithEvents dtpVanafDatum As AxMSComCtl2.AxDTPicker
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Line4 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line3 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLysDatumWysig))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAllBack = New System.Windows.Forms.Button
        Me.btnAllOver = New System.Windows.Forms.Button
        Me.btnOneBack = New System.Windows.Forms.Button
        Me.btnOneOver = New System.Windows.Forms.Button
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.Line4 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Line3 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Data1 = New System.Windows.Forms.Label
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.txtWysigingskode = New System.Windows.Forms.TextBox
        Me.btnSoekWysigingskode = New System.Windows.Forms.Button
        Me.txtBeskrywing = New System.Windows.Forms.TextBox
        Me.txtKode = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.cmbGebruiker = New System.Windows.Forms.ComboBox
        Me.dtpTotDatum = New AxMSComCtl2.AxDTPicker
        Me.dtpVanafDatum = New AxMSComCtl2.AxDTPicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Frame1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpTotDatum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpVanafDatum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAllBack
        '
        Me.btnAllBack.BackColor = System.Drawing.SystemColors.Control
        Me.btnAllBack.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnAllBack.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAllBack.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAllBack.Location = New System.Drawing.Point(288, 216)
        Me.btnAllBack.Name = "btnAllBack"
        Me.btnAllBack.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnAllBack.Size = New System.Drawing.Size(30, 22)
        Me.btnAllBack.TabIndex = 10
        Me.btnAllBack.Text = "<<"
        Me.ToolTip1.SetToolTip(Me.btnAllBack, "Plaas al die wysigings terug.")
        Me.btnAllBack.UseVisualStyleBackColor = False
        '
        'btnAllOver
        '
        Me.btnAllOver.BackColor = System.Drawing.SystemColors.Control
        Me.btnAllOver.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnAllOver.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAllOver.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAllOver.Location = New System.Drawing.Point(288, 144)
        Me.btnAllOver.Name = "btnAllOver"
        Me.btnAllOver.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnAllOver.Size = New System.Drawing.Size(30, 22)
        Me.btnAllOver.TabIndex = 8
        Me.btnAllOver.Text = ">>"
        Me.ToolTip1.SetToolTip(Me.btnAllOver, "Plaas al die wysigings oor.")
        Me.btnAllOver.UseVisualStyleBackColor = False
        '
        'btnOneBack
        '
        Me.btnOneBack.BackColor = System.Drawing.SystemColors.Control
        Me.btnOneBack.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOneBack.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOneBack.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOneBack.Location = New System.Drawing.Point(288, 192)
        Me.btnOneBack.Name = "btnOneBack"
        Me.btnOneBack.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOneBack.Size = New System.Drawing.Size(30, 22)
        Me.btnOneBack.TabIndex = 9
        Me.btnOneBack.Text = "<"
        Me.ToolTip1.SetToolTip(Me.btnOneBack, "Plaas gekose wysiging terug.")
        Me.btnOneBack.UseVisualStyleBackColor = False
        '
        'btnOneOver
        '
        Me.btnOneOver.BackColor = System.Drawing.SystemColors.Control
        Me.btnOneOver.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOneOver.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOneOver.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOneOver.Location = New System.Drawing.Point(288, 120)
        Me.btnOneOver.Name = "btnOneOver"
        Me.btnOneOver.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOneOver.Size = New System.Drawing.Size(30, 22)
        Me.btnOneOver.TabIndex = 7
        Me.btnOneOver.Text = ">"
        Me.ToolTip1.SetToolTip(Me.btnOneOver, "Plaas gekose wysiging oor.")
        Me.btnOneOver.UseVisualStyleBackColor = False
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Line4, Me.Line3})
        Me.ShapeContainer1.Size = New System.Drawing.Size(761, 543)
        Me.ShapeContainer1.TabIndex = 17
        Me.ShapeContainer1.TabStop = False
        '
        'Line4
        '
        Me.Line4.BorderColor = System.Drawing.Color.White
        Me.Line4.Name = "Line4"
        Me.Line4.X1 = 184
        Me.Line4.X2 = 624
        Me.Line4.Y1 = 25
        Me.Line4.Y2 = 25
        '
        'Line3
        '
        Me.Line3.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Line3.Name = "Line3"
        Me.Line3.X1 = 184
        Me.Line3.X2 = 624
        Me.Line3.Y1 = 24
        Me.Line3.Y2 = 24
        '
        'Data1
        '
        Me.Data1.BackColor = System.Drawing.Color.Red
        Me.Data1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Data1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Data1.ForeColor = System.Drawing.Color.Black
        Me.Data1.Location = New System.Drawing.Point(504, 152)
        Me.Data1.Name = "Data1"
        Me.Data1.Size = New System.Drawing.Size(121, 23)
        Me.Data1.TabIndex = 0
        Me.Data1.Text = "Data1"
        Me.Data1.Visible = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.DataGridView2)
        Me.Frame1.Controls.Add(Me.DataGridView1)
        Me.Frame1.Controls.Add(Me.btnAllBack)
        Me.Frame1.Controls.Add(Me.btnAllOver)
        Me.Frame1.Controls.Add(Me.btnOneBack)
        Me.Frame1.Controls.Add(Me.btnOneOver)
        Me.Frame1.Controls.Add(Me.txtWysigingskode)
        Me.Frame1.Controls.Add(Me.btnSoekWysigingskode)
        Me.Frame1.Controls.Add(Me.txtBeskrywing)
        Me.Frame1.Controls.Add(Me.txtKode)
        Me.Frame1.Controls.Add(Me.Label4)
        Me.Frame1.Controls.Add(Me.Label7)
        Me.Frame1.Controls.Add(Me.Label6)
        Me.Frame1.Controls.Add(Me.Label8)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(24, 168)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(601, 281)
        Me.Frame1.TabIndex = 16
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Description"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowDrop = True
        Me.DataGridView2.AllowUserToOrderColumns = True
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView2.Location = New System.Drawing.Point(337, 116)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(256, 150)
        Me.DataGridView2.TabIndex = 25
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Location = New System.Drawing.Point(3, 120)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(270, 150)
        Me.DataGridView1.TabIndex = 24
        '
        'txtWysigingskode
        '
        Me.txtWysigingskode.AcceptsReturn = True
        Me.txtWysigingskode.BackColor = System.Drawing.SystemColors.Window
        Me.txtWysigingskode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtWysigingskode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWysigingskode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtWysigingskode.Location = New System.Drawing.Point(496, 24)
        Me.txtWysigingskode.MaxLength = 0
        Me.txtWysigingskode.Name = "txtWysigingskode"
        Me.txtWysigingskode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtWysigingskode.Size = New System.Drawing.Size(81, 20)
        Me.txtWysigingskode.TabIndex = 20
        Me.txtWysigingskode.Visible = False
        '
        'btnSoekWysigingskode
        '
        Me.btnSoekWysigingskode.BackColor = System.Drawing.SystemColors.Control
        Me.btnSoekWysigingskode.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSoekWysigingskode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSoekWysigingskode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSoekWysigingskode.Location = New System.Drawing.Point(288, 61)
        Me.btnSoekWysigingskode.Name = "btnSoekWysigingskode"
        Me.btnSoekWysigingskode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSoekWysigingskode.Size = New System.Drawing.Size(81, 25)
        Me.btnSoekWysigingskode.TabIndex = 6
        Me.btnSoekWysigingskode.Text = "Search"
        Me.btnSoekWysigingskode.UseVisualStyleBackColor = False
        '
        'txtBeskrywing
        '
        Me.txtBeskrywing.AcceptsReturn = True
        Me.txtBeskrywing.BackColor = System.Drawing.SystemColors.Window
        Me.txtBeskrywing.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBeskrywing.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBeskrywing.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBeskrywing.Location = New System.Drawing.Point(136, 64)
        Me.txtBeskrywing.MaxLength = 0
        Me.txtBeskrywing.Name = "txtBeskrywing"
        Me.txtBeskrywing.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBeskrywing.Size = New System.Drawing.Size(137, 20)
        Me.txtBeskrywing.TabIndex = 5
        '
        'txtKode
        '
        Me.txtKode.AcceptsReturn = True
        Me.txtKode.BackColor = System.Drawing.SystemColors.Window
        Me.txtKode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtKode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtKode.Location = New System.Drawing.Point(136, 32)
        Me.txtKode.MaxLength = 0
        Me.txtKode.Name = "txtKode"
        Me.txtKode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtKode.Size = New System.Drawing.Size(49, 20)
        Me.txtKode.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(241, 17)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "List of Changes to choose from"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(16, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(113, 17)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Description Changes"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(89, 17)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Code Changes"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(328, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(265, 17)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "List of Changes report in which data are"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(544, 464)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(81, 25)
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOK.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOK.Location = New System.Drawing.Point(456, 464)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOK.Size = New System.Drawing.Size(81, 25)
        Me.btnOK.TabIndex = 11
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'cmbGebruiker
        '
        Me.cmbGebruiker.BackColor = System.Drawing.SystemColors.Window
        Me.cmbGebruiker.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbGebruiker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGebruiker.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGebruiker.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbGebruiker.Location = New System.Drawing.Point(104, 128)
        Me.cmbGebruiker.Name = "cmbGebruiker"
        Me.cmbGebruiker.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbGebruiker.Size = New System.Drawing.Size(145, 22)
        Me.cmbGebruiker.TabIndex = 3
        '
        'dtpTotDatum
        '
        Me.dtpTotDatum.Location = New System.Drawing.Point(104, 88)
        Me.dtpTotDatum.Name = "dtpTotDatum"
        Me.dtpTotDatum.OcxState = CType(resources.GetObject("dtpTotDatum.OcxState"), System.Windows.Forms.AxHost.State)
        Me.dtpTotDatum.Size = New System.Drawing.Size(81, 25)
        Me.dtpTotDatum.TabIndex = 2
        '
        'dtpVanafDatum
        '
        Me.dtpVanafDatum.Location = New System.Drawing.Point(104, 48)
        Me.dtpVanafDatum.Name = "dtpVanafDatum"
        Me.dtpVanafDatum.OcxState = CType(resources.GetObject("dtpVanafDatum.OcxState"), System.Windows.Forms.AxHost.State)
        Me.dtpVanafDatum.Size = New System.Drawing.Size(81, 25)
        Me.dtpVanafDatum.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(16, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(201, 17)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Print list of changes history"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(24, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(57, 17)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "user"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(24, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Date to"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(24, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(81, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date from"
        '
        'frmLysDatumWysig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(761, 543)
        Me.Controls.Add(Me.Data1)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cmbGebruiker)
        Me.Controls.Add(Me.dtpTotDatum)
        Me.Controls.Add(Me.dtpVanafDatum)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 30)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLysDatumWysig"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpTotDatum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpVanafDatum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
#End Region
End Class