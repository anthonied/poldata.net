<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class VoertuigSearch
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
	Public WithEvents btnPrint As System.Windows.Forms.Button
	Public WithEvents txtKode As System.Windows.Forms.TextBox
	Public WithEvents cmbJaar As System.Windows.Forms.ComboBox
	Public WithEvents Data1 As System.Windows.Forms.Label
	Public WithEvents btnOk As System.Windows.Forms.Button
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents txtMaak As System.Windows.Forms.TextBox
	Public WithEvents txtBesk As System.Windows.Forms.TextBox
	Public WithEvents btnSearch As System.Windows.Forms.Button
	Public WithEvents btnClear As System.Windows.Forms.Button
    Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents lblTotal As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TIPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fabrikaat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Modelbeskrywing = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Jr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Inruil_R = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Koop_R = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nuut_R = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mark_R = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cyl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Begin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Einde = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtKode = New System.Windows.Forms.TextBox()
        Me.cmbJaar = New System.Windows.Forms.ComboBox()
        Me.Data1 = New System.Windows.Forms.Label()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtMaak = New System.Windows.Forms.TextBox()
        Me.txtBesk = New System.Windows.Forms.TextBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.SystemColors.Control
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnPrint.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPrint.Location = New System.Drawing.Point(617, 11)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPrint.Size = New System.Drawing.Size(67, 20)
        Me.btnPrint.TabIndex = 15
        Me.btnPrint.Text = "Print this list"
        Me.ToolTip1.SetToolTip(Me.btnPrint, "Druk hierdie lys")
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.Control
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSearch.Location = New System.Drawing.Point(18, 272)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSearch.Size = New System.Drawing.Size(57, 20)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(144, 304)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 14)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Number found:"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowDrop = True
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TIPE, Me.Fabrikaat, Me.Modelbeskrywing, Me.Jr, Me.Inruil_R, Me.Koop_R, Me.Nuut_R, Me.Mark_R, Me.KODE, Me.Cyl, Me.CC, Me.Begin, Me.Einde})
        Me.DataGridView1.Location = New System.Drawing.Point(149, 36)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(534, 257)
        Me.DataGridView1.TabIndex = 17
        '
        'TIPE
        '
        Me.TIPE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.TIPE.DataPropertyName = "TIPE"
        Me.TIPE.HeaderText = "Type"
        Me.TIPE.Name = "TIPE"
        Me.TIPE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TIPE.Visible = False
        '
        'Fabrikaat
        '
        Me.Fabrikaat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Fabrikaat.DataPropertyName = "Fabrikaat"
        Me.Fabrikaat.HeaderText = "Make"
        Me.Fabrikaat.Name = "Fabrikaat"
        Me.Fabrikaat.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Fabrikaat.Width = 57
        '
        'Modelbeskrywing
        '
        Me.Modelbeskrywing.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Modelbeskrywing.DataPropertyName = "Model_beskrywing"
        Me.Modelbeskrywing.FillWeight = 200.0!
        Me.Modelbeskrywing.HeaderText = "Model description"
        Me.Modelbeskrywing.Name = "Modelbeskrywing"
        Me.Modelbeskrywing.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Modelbeskrywing.Width = 116
        '
        'Jr
        '
        Me.Jr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Jr.DataPropertyName = "Jr"
        Me.Jr.FillWeight = 50.0!
        Me.Jr.HeaderText = "Year"
        Me.Jr.Name = "Jr"
        Me.Jr.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Jr.Width = 55
        '
        'Inruil_R
        '
        Me.Inruil_R.DataPropertyName = "Inruil_R"
        Me.Inruil_R.FillWeight = 50.0!
        Me.Inruil_R.HeaderText = "Trade in R"
        Me.Inruil_R.Name = "Inruil_R"
        Me.Inruil_R.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Inruil_R.Width = 61
        '
        'Koop_R
        '
        Me.Koop_R.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Koop_R.DataPropertyName = "Koop_R"
        Me.Koop_R.FillWeight = 50.0!
        Me.Koop_R.HeaderText = "Buy R"
        Me.Koop_R.Name = "Koop_R"
        Me.Koop_R.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Koop_R.Width = 61
        '
        'Nuut_R
        '
        Me.Nuut_R.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Nuut_R.DataPropertyName = "Nuut_R"
        Me.Nuut_R.FillWeight = 50.0!
        Me.Nuut_R.HeaderText = "New R"
        Me.Nuut_R.Name = "Nuut_R"
        Me.Nuut_R.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Nuut_R.Width = 65
        '
        'Mark_R
        '
        Me.Mark_R.DataPropertyName = "Mark_R"
        Me.Mark_R.FillWeight = 50.0!
        Me.Mark_R.HeaderText = "Market R"
        Me.Mark_R.Name = "Mark_R"
        Me.Mark_R.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Mark_R.Width = 61
        '
        'KODE
        '
        Me.KODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.KODE.DataPropertyName = "KODE"
        Me.KODE.HeaderText = "Code"
        Me.KODE.Name = "KODE"
        Me.KODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.KODE.Width = 57
        '
        'Cyl
        '
        Me.Cyl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cyl.DataPropertyName = "Cyl"
        Me.Cyl.FillWeight = 3.0!
        Me.Cyl.HeaderText = "Cyl"
        Me.Cyl.MinimumWidth = 3
        Me.Cyl.Name = "Cyl"
        Me.Cyl.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Cyl.Width = 25
        '
        'CC
        '
        Me.CC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CC.DataPropertyName = "CC"
        Me.CC.FillWeight = 50.0!
        Me.CC.HeaderText = "CC"
        Me.CC.Name = "CC"
        Me.CC.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CC.Width = 46
        '
        'Begin
        '
        Me.Begin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Begin.DataPropertyName = "Begin"
        Me.Begin.FillWeight = 50.0!
        Me.Begin.HeaderText = "Start"
        Me.Begin.Name = "Begin"
        Me.Begin.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Begin.Width = 55
        '
        'Einde
        '
        Me.Einde.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Einde.DataPropertyName = "Einde"
        Me.Einde.FillWeight = 50.0!
        Me.Einde.HeaderText = "End"
        Me.Einde.Name = "Einde"
        Me.Einde.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Einde.Width = 50
        '
        'txtKode
        '
        Me.txtKode.AcceptsReturn = True
        Me.txtKode.BackColor = System.Drawing.SystemColors.Window
        Me.txtKode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtKode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtKode.Location = New System.Drawing.Point(18, 232)
        Me.txtKode.MaxLength = 8
        Me.txtKode.Name = "txtKode"
        Me.txtKode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtKode.Size = New System.Drawing.Size(113, 20)
        Me.txtKode.TabIndex = 3
        '
        'cmbJaar
        '
        Me.cmbJaar.BackColor = System.Drawing.SystemColors.Window
        Me.cmbJaar.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbJaar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJaar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbJaar.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbJaar.Location = New System.Drawing.Point(18, 184)
        Me.cmbJaar.Name = "cmbJaar"
        Me.cmbJaar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbJaar.Size = New System.Drawing.Size(93, 22)
        Me.cmbJaar.TabIndex = 2
        '
        'Data1
        '
        Me.Data1.BackColor = System.Drawing.Color.Red
        Me.Data1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Data1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Data1.ForeColor = System.Drawing.Color.Black
        Me.Data1.Location = New System.Drawing.Point(12, 308)
        Me.Data1.Name = "Data1"
        Me.Data1.Size = New System.Drawing.Size(121, 23)
        Me.Data1.TabIndex = 16
        Me.Data1.Text = "Data1"
        Me.Data1.Visible = False
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOk.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Location = New System.Drawing.Point(502, 304)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New System.Drawing.Size(85, 25)
        Me.btnOk.TabIndex = 7
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(598, 304)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(85, 25)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'txtMaak
        '
        Me.txtMaak.AcceptsReturn = True
        Me.txtMaak.BackColor = System.Drawing.SystemColors.Window
        Me.txtMaak.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMaak.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaak.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMaak.Location = New System.Drawing.Point(18, 88)
        Me.txtMaak.MaxLength = 15
        Me.txtMaak.Name = "txtMaak"
        Me.txtMaak.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMaak.Size = New System.Drawing.Size(117, 20)
        Me.txtMaak.TabIndex = 0
        '
        'txtBesk
        '
        Me.txtBesk.AcceptsReturn = True
        Me.txtBesk.BackColor = System.Drawing.SystemColors.Window
        Me.txtBesk.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBesk.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBesk.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBesk.Location = New System.Drawing.Point(18, 136)
        Me.txtBesk.MaxLength = 30
        Me.txtBesk.Name = "txtBesk"
        Me.txtBesk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBesk.Size = New System.Drawing.Size(117, 20)
        Me.txtBesk.TabIndex = 1
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.SystemColors.Control
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClear.Location = New System.Drawing.Point(78, 272)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClear.Size = New System.Drawing.Size(57, 20)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(146, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(393, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Note: Only vehicles manufactured in the last 15 years will be displayed."
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.SystemColors.Control
        Me.lblTotal.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTotal.Location = New System.Drawing.Point(144, 308)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTotal.Size = New System.Drawing.Size(109, 13)
        Me.lblTotal.TabIndex = 13
        Me.lblTotal.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(18, 216)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Code"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(18, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(117, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Make"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(18, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(117, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Model Description"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(18, 168)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Year Model"
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
        Me.Label7.Size = New System.Drawing.Size(117, 37)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Search using the following criteria:"
        '
        'VoertuigSearch
        '
        Me.AcceptButton = Me.btnSearch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(697, 343)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.txtKode)
        Me.Controls.Add(Me.cmbJaar)
        Me.Controls.Add(Me.Data1)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtMaak)
        Me.Controls.Add(Me.txtBesk)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Location = New System.Drawing.Point(4, 30)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "VoertuigSearch"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TIPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fabrikaat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Modelbeskrywing As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Jr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Inruil_R As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Koop_R As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nuut_R As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mark_R As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cyl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Begin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Einde As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class