<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class BriefGeneries
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
	Public WithEvents cmbVersekeraar As System.Windows.Forms.ComboBox
	Public WithEvents cmbStatus As System.Windows.Forms.ComboBox
	Public WithEvents lstArea As System.Windows.Forms.ListBox
	Public WithEvents txtVanaf As System.Windows.Forms.TextBox
	Public WithEvents txtTot As System.Windows.Forms.TextBox
	Public WithEvents cmbPosbestemming As System.Windows.Forms.ComboBox
	Public WithEvents cmbTaal As System.Windows.Forms.ComboBox
    Public WithEvents lblVersekeraar As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents lblTaal As System.Windows.Forms.Label
	Public WithEvents lblPosbestemming As System.Windows.Forms.Label
	Public WithEvents frmKriteria As System.Windows.Forms.GroupBox
	Public WithEvents chkAttach As System.Windows.Forms.CheckBox
	Public WithEvents txtOnderwerp As System.Windows.Forms.TextBox
	Public WithEvents txtInhoud As System.Windows.Forms.TextBox
	Public WithEvents btnClose As System.Windows.Forms.Button
	Public WithEvents btnOk As System.Windows.Forms.Button
	Public WithEvents rdSpesifieke As System.Windows.Forms.RadioButton
	Public WithEvents rdHuidig As System.Windows.Forms.RadioButton
	Public WithEvents Frame1 As System.Windows.Forms.Panel
	Public WithEvents rdEpos As System.Windows.Forms.RadioButton
	Public WithEvents rdDrukker As System.Windows.Forms.RadioButton
	Public WithEvents Frame3 As System.Windows.Forms.Panel
	Public WithEvents btnHelp As System.Windows.Forms.Button
	Public WithEvents lblInhoud As System.Windows.Forms.Label
	Public WithEvents lblOnderwerp As System.Windows.Forms.Label
	Public WithEvents lblBriefBesonderhede As System.Windows.Forms.Label
	Public WithEvents Line6 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line5 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Line1 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line2 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Line3 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line4 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents lblStatus As System.Windows.Forms.Label
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.Line6 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Line5 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Line1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Line2 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Line3 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Line4 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.frmKriteria = New System.Windows.Forms.GroupBox
        Me.dtpAanvTo = New System.Windows.Forms.DateTimePicker
        Me.dtpAanvFrom = New System.Windows.Forms.DateTimePicker
        Me.cmbVersekeraar = New System.Windows.Forms.ComboBox
        Me.cmbStatus = New System.Windows.Forms.ComboBox
        Me.lstArea = New System.Windows.Forms.ListBox
        Me.txtVanaf = New System.Windows.Forms.TextBox
        Me.txtTot = New System.Windows.Forms.TextBox
        Me.cmbPosbestemming = New System.Windows.Forms.ComboBox
        Me.cmbTaal = New System.Windows.Forms.ComboBox
        Me.lblVersekeraar = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblTaal = New System.Windows.Forms.Label
        Me.lblPosbestemming = New System.Windows.Forms.Label
        Me.chkAttach = New System.Windows.Forms.CheckBox
        Me.txtOnderwerp = New System.Windows.Forms.TextBox
        Me.txtInhoud = New System.Windows.Forms.TextBox
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.Frame1 = New System.Windows.Forms.Panel
        Me.rdSpesifieke = New System.Windows.Forms.RadioButton
        Me.rdHuidig = New System.Windows.Forms.RadioButton
        Me.Frame3 = New System.Windows.Forms.Panel
        Me.rdEpos = New System.Windows.Forms.RadioButton
        Me.rdDrukker = New System.Windows.Forms.RadioButton
        Me.btnHelp = New System.Windows.Forms.Button
        Me.lblInhoud = New System.Windows.Forms.Label
        Me.lblOnderwerp = New System.Windows.Forms.Label
        Me.lblBriefBesonderhede = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.frmKriteria.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.Frame3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Line6, Me.Line5, Me.Line1, Me.Line2, Me.Line3, Me.Line4})
        Me.ShapeContainer1.Size = New System.Drawing.Size(617, 609)
        Me.ShapeContainer1.TabIndex = 32
        Me.ShapeContainer1.TabStop = False
        '
        'Line6
        '
        Me.Line6.BorderColor = System.Drawing.Color.White
        Me.Line6.Name = "Line6"
        Me.Line6.X1 = 42
        Me.Line6.X2 = 591
        Me.Line6.Y1 = 373
        Me.Line6.Y2 = 373
        '
        'Line5
        '
        Me.Line5.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Line5.Name = "Line5"
        Me.Line5.X1 = 12
        Me.Line5.X2 = 592
        Me.Line5.Y1 = 372
        Me.Line5.Y2 = 372
        '
        'Line1
        '
        Me.Line1.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Line1.Name = "Line1"
        Me.Line1.X1 = 12
        Me.Line1.X2 = 592
        Me.Line1.Y1 = 20
        Me.Line1.Y2 = 20
        '
        'Line2
        '
        Me.Line2.BorderColor = System.Drawing.Color.White
        Me.Line2.Name = "Line2"
        Me.Line2.X1 = 12
        Me.Line2.X2 = 592
        Me.Line2.Y1 = 21
        Me.Line2.Y2 = 21
        '
        'Line3
        '
        Me.Line3.BorderColor = System.Drawing.Color.White
        Me.Line3.Name = "Line3"
        Me.Line3.X1 = 124
        Me.Line3.X2 = 596
        Me.Line3.Y1 = 560
        Me.Line3.Y2 = 560
        '
        'Line4
        '
        Me.Line4.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Line4.Name = "Line4"
        Me.Line4.X1 = 124
        Me.Line4.X2 = 596
        Me.Line4.Y1 = 559
        Me.Line4.Y2 = 559
        '
        'frmKriteria
        '
        Me.frmKriteria.BackColor = System.Drawing.SystemColors.Control
        Me.frmKriteria.Controls.Add(Me.dtpAanvTo)
        Me.frmKriteria.Controls.Add(Me.dtpAanvFrom)
        Me.frmKriteria.Controls.Add(Me.cmbVersekeraar)
        Me.frmKriteria.Controls.Add(Me.cmbStatus)
        Me.frmKriteria.Controls.Add(Me.lstArea)
        Me.frmKriteria.Controls.Add(Me.txtVanaf)
        Me.frmKriteria.Controls.Add(Me.txtTot)
        Me.frmKriteria.Controls.Add(Me.cmbPosbestemming)
        Me.frmKriteria.Controls.Add(Me.cmbTaal)
        Me.frmKriteria.Controls.Add(Me.lblVersekeraar)
        Me.frmKriteria.Controls.Add(Me.Label4)
        Me.frmKriteria.Controls.Add(Me.Label9)
        Me.frmKriteria.Controls.Add(Me.Label5)
        Me.frmKriteria.Controls.Add(Me.Label1)
        Me.frmKriteria.Controls.Add(Me.Label2)
        Me.frmKriteria.Controls.Add(Me.Label3)
        Me.frmKriteria.Controls.Add(Me.lblTaal)
        Me.frmKriteria.Controls.Add(Me.lblPosbestemming)
        Me.frmKriteria.Enabled = False
        Me.frmKriteria.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmKriteria.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmKriteria.Location = New System.Drawing.Point(124, 60)
        Me.frmKriteria.Name = "frmKriteria"
        Me.frmKriteria.Padding = New System.Windows.Forms.Padding(0)
        Me.frmKriteria.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmKriteria.Size = New System.Drawing.Size(469, 269)
        Me.frmKriteria.TabIndex = 0
        Me.frmKriteria.TabStop = False
        Me.frmKriteria.Text = "Criteria"
        '
        'dtpAanvTo
        '
        Me.dtpAanvTo.Checked = False
        Me.dtpAanvTo.Location = New System.Drawing.Point(293, 142)
        Me.dtpAanvTo.Name = "dtpAanvTo"
        Me.dtpAanvTo.ShowCheckBox = True
        Me.dtpAanvTo.Size = New System.Drawing.Size(156, 20)
        Me.dtpAanvTo.TabIndex = 39
        Me.dtpAanvTo.Value = New Date(2011, 11, 16, 13, 28, 0, 0)
        '
        'dtpAanvFrom
        '
        Me.dtpAanvFrom.Checked = False
        Me.dtpAanvFrom.Location = New System.Drawing.Point(108, 142)
        Me.dtpAanvFrom.Name = "dtpAanvFrom"
        Me.dtpAanvFrom.ShowCheckBox = True
        Me.dtpAanvFrom.Size = New System.Drawing.Size(157, 20)
        Me.dtpAanvFrom.TabIndex = 38
        Me.dtpAanvFrom.Value = New Date(2001, 1, 1, 13, 28, 0, 0)
        '
        'cmbVersekeraar
        '
        Me.cmbVersekeraar.BackColor = System.Drawing.SystemColors.Window
        Me.cmbVersekeraar.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbVersekeraar.Enabled = False
        Me.cmbVersekeraar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVersekeraar.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbVersekeraar.Location = New System.Drawing.Point(108, 24)
        Me.cmbVersekeraar.Name = "cmbVersekeraar"
        Me.cmbVersekeraar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbVersekeraar.Size = New System.Drawing.Size(153, 22)
        Me.cmbVersekeraar.TabIndex = 36
        '
        'cmbStatus
        '
        Me.cmbStatus.BackColor = System.Drawing.SystemColors.Window
        Me.cmbStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.Enabled = False
        Me.cmbStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbStatus.Items.AddRange(New Object() {"Alle", "Aktief", "Gekanselleer"})
        Me.cmbStatus.Location = New System.Drawing.Point(108, 201)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbStatus.Size = New System.Drawing.Size(157, 22)
        Me.cmbStatus.TabIndex = 6
        '
        'lstArea
        '
        Me.lstArea.BackColor = System.Drawing.SystemColors.Window
        Me.lstArea.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstArea.Enabled = False
        Me.lstArea.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstArea.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstArea.ItemHeight = 14
        Me.lstArea.Location = New System.Drawing.Point(108, 55)
        Me.lstArea.Name = "lstArea"
        Me.lstArea.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstArea.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstArea.Size = New System.Drawing.Size(341, 46)
        Me.lstArea.TabIndex = 5
        '
        'txtVanaf
        '
        Me.txtVanaf.AcceptsReturn = True
        Me.txtVanaf.BackColor = System.Drawing.SystemColors.Window
        Me.txtVanaf.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVanaf.Enabled = False
        Me.txtVanaf.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVanaf.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVanaf.Location = New System.Drawing.Point(108, 110)
        Me.txtVanaf.MaxLength = 25
        Me.txtVanaf.Name = "txtVanaf"
        Me.txtVanaf.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVanaf.Size = New System.Drawing.Size(157, 20)
        Me.txtVanaf.TabIndex = 4
        '
        'txtTot
        '
        Me.txtTot.AcceptsReturn = True
        Me.txtTot.BackColor = System.Drawing.SystemColors.Window
        Me.txtTot.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTot.Enabled = False
        Me.txtTot.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTot.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTot.Location = New System.Drawing.Point(292, 110)
        Me.txtTot.MaxLength = 25
        Me.txtTot.Name = "txtTot"
        Me.txtTot.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTot.Size = New System.Drawing.Size(157, 20)
        Me.txtTot.TabIndex = 3
        '
        'cmbPosbestemming
        '
        Me.cmbPosbestemming.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPosbestemming.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbPosbestemming.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPosbestemming.Enabled = False
        Me.cmbPosbestemming.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPosbestemming.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbPosbestemming.Items.AddRange(New Object() {"Alle", "Posadres", "Risiko-adres", "Universiteitsposbus", "E-pos"})
        Me.cmbPosbestemming.Location = New System.Drawing.Point(108, 232)
        Me.cmbPosbestemming.Name = "cmbPosbestemming"
        Me.cmbPosbestemming.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbPosbestemming.Size = New System.Drawing.Size(157, 22)
        Me.cmbPosbestemming.TabIndex = 2
        '
        'cmbTaal
        '
        Me.cmbTaal.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTaal.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTaal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTaal.Enabled = False
        Me.cmbTaal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTaal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbTaal.Items.AddRange(New Object() {"Afrikaans en Engels", "Afrikaans", "Engels"})
        Me.cmbTaal.Location = New System.Drawing.Point(108, 171)
        Me.cmbTaal.Name = "cmbTaal"
        Me.cmbTaal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbTaal.Size = New System.Drawing.Size(157, 22)
        Me.cmbTaal.TabIndex = 1
        '
        'lblVersekeraar
        '
        Me.lblVersekeraar.BackColor = System.Drawing.SystemColors.Control
        Me.lblVersekeraar.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblVersekeraar.Enabled = False
        Me.lblVersekeraar.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersekeraar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblVersekeraar.Location = New System.Drawing.Point(20, 27)
        Me.lblVersekeraar.Name = "lblVersekeraar"
        Me.lblVersekeraar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVersekeraar.Size = New System.Drawing.Size(73, 17)
        Me.lblVersekeraar.TabIndex = 37
        Me.lblVersekeraar.Text = "Insurer"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Enabled = False
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(20, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(89, 17)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Start Date"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Enabled = False
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(272, 144)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(21, 13)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "To"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Enabled = False
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(20, 205)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Status"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(20, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Area"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(20, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(77, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Surnames"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(268, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "To"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTaal
        '
        Me.lblTaal.BackColor = System.Drawing.SystemColors.Control
        Me.lblTaal.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTaal.Enabled = False
        Me.lblTaal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTaal.Location = New System.Drawing.Point(20, 171)
        Me.lblTaal.Name = "lblTaal"
        Me.lblTaal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTaal.Size = New System.Drawing.Size(57, 22)
        Me.lblTaal.TabIndex = 8
        Me.lblTaal.Text = "Language"
        '
        'lblPosbestemming
        '
        Me.lblPosbestemming.BackColor = System.Drawing.SystemColors.Control
        Me.lblPosbestemming.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPosbestemming.Enabled = False
        Me.lblPosbestemming.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosbestemming.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPosbestemming.Location = New System.Drawing.Point(20, 237)
        Me.lblPosbestemming.Name = "lblPosbestemming"
        Me.lblPosbestemming.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPosbestemming.Size = New System.Drawing.Size(89, 17)
        Me.lblPosbestemming.TabIndex = 7
        Me.lblPosbestemming.Text = "Post destination"
        '
        'chkAttach
        '
        Me.chkAttach.BackColor = System.Drawing.SystemColors.Control
        Me.chkAttach.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkAttach.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAttach.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAttach.Location = New System.Drawing.Point(116, 364)
        Me.chkAttach.Name = "chkAttach"
        Me.chkAttach.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkAttach.Size = New System.Drawing.Size(132, 16)
        Me.chkAttach.TabIndex = 31
        Me.chkAttach.Text = "Attach letter to e-mail"
        Me.chkAttach.UseVisualStyleBackColor = False
        Me.chkAttach.Visible = False
        '
        'txtOnderwerp
        '
        Me.txtOnderwerp.AcceptsReturn = True
        Me.txtOnderwerp.BackColor = System.Drawing.SystemColors.Window
        Me.txtOnderwerp.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOnderwerp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOnderwerp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOnderwerp.Location = New System.Drawing.Point(124, 384)
        Me.txtOnderwerp.MaxLength = 35
        Me.txtOnderwerp.Name = "txtOnderwerp"
        Me.txtOnderwerp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOnderwerp.Size = New System.Drawing.Size(245, 20)
        Me.txtOnderwerp.TabIndex = 16
        '
        'txtInhoud
        '
        Me.txtInhoud.AcceptsReturn = True
        Me.txtInhoud.BackColor = System.Drawing.SystemColors.Window
        Me.txtInhoud.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInhoud.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInhoud.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtInhoud.Location = New System.Drawing.Point(124, 416)
        Me.txtInhoud.MaxLength = 0
        Me.txtInhoud.Multiline = True
        Me.txtInhoud.Name = "txtInhoud"
        Me.txtInhoud.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtInhoud.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtInhoud.Size = New System.Drawing.Size(473, 133)
        Me.txtInhoud.TabIndex = 17
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Location = New System.Drawing.Point(420, 568)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClose.Size = New System.Drawing.Size(85, 25)
        Me.btnClose.TabIndex = 19
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOk.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Location = New System.Drawing.Point(328, 568)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New System.Drawing.Size(85, 25)
        Me.btnOk.TabIndex = 18
        Me.btnOk.Text = "&Ok"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.rdSpesifieke)
        Me.Frame1.Controls.Add(Me.rdHuidig)
        Me.Frame1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(120, 36)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(301, 21)
        Me.Frame1.TabIndex = 20
        '
        'rdSpesifieke
        '
        Me.rdSpesifieke.BackColor = System.Drawing.SystemColors.Control
        Me.rdSpesifieke.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdSpesifieke.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdSpesifieke.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdSpesifieke.Location = New System.Drawing.Point(116, 4)
        Me.rdSpesifieke.Name = "rdSpesifieke"
        Me.rdSpesifieke.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdSpesifieke.Size = New System.Drawing.Size(157, 17)
        Me.rdSpesifieke.TabIndex = 23
        Me.rdSpesifieke.TabStop = True
        Me.rdSpesifieke.Text = "Specific \ all policies"
        Me.rdSpesifieke.UseVisualStyleBackColor = False
        '
        'rdHuidig
        '
        Me.rdHuidig.BackColor = System.Drawing.SystemColors.Control
        Me.rdHuidig.Checked = True
        Me.rdHuidig.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdHuidig.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdHuidig.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdHuidig.Location = New System.Drawing.Point(0, 4)
        Me.rdHuidig.Name = "rdHuidig"
        Me.rdHuidig.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdHuidig.Size = New System.Drawing.Size(113, 17)
        Me.rdHuidig.TabIndex = 22
        Me.rdHuidig.TabStop = True
        Me.rdHuidig.Text = "Current policy"
        Me.rdHuidig.UseVisualStyleBackColor = False
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me.rdEpos)
        Me.Frame3.Controls.Add(Me.rdDrukker)
        Me.Frame3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Frame3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(116, 328)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(229, 25)
        Me.Frame3.TabIndex = 13
        '
        'rdEpos
        '
        Me.rdEpos.BackColor = System.Drawing.SystemColors.Control
        Me.rdEpos.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdEpos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdEpos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdEpos.Location = New System.Drawing.Point(116, 8)
        Me.rdEpos.Name = "rdEpos"
        Me.rdEpos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdEpos.Size = New System.Drawing.Size(89, 17)
        Me.rdEpos.TabIndex = 15
        Me.rdEpos.TabStop = True
        Me.rdEpos.Text = "E-mail"
        Me.rdEpos.UseVisualStyleBackColor = False
        '
        'rdDrukker
        '
        Me.rdDrukker.BackColor = System.Drawing.SystemColors.Control
        Me.rdDrukker.Checked = True
        Me.rdDrukker.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdDrukker.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdDrukker.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdDrukker.Location = New System.Drawing.Point(8, 8)
        Me.rdDrukker.Name = "rdDrukker"
        Me.rdDrukker.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdDrukker.Size = New System.Drawing.Size(77, 17)
        Me.rdDrukker.TabIndex = 14
        Me.rdDrukker.TabStop = True
        Me.rdDrukker.Text = "Printer"
        Me.rdDrukker.UseVisualStyleBackColor = False
        '
        'btnHelp
        '
        Me.btnHelp.BackColor = System.Drawing.SystemColors.Control
        Me.btnHelp.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnHelp.Enabled = False
        Me.btnHelp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHelp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnHelp.Location = New System.Drawing.Point(512, 568)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnHelp.Size = New System.Drawing.Size(85, 25)
        Me.btnHelp.TabIndex = 21
        Me.btnHelp.Text = "&Help"
        Me.btnHelp.UseVisualStyleBackColor = False
        '
        'lblInhoud
        '
        Me.lblInhoud.BackColor = System.Drawing.SystemColors.Control
        Me.lblInhoud.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblInhoud.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInhoud.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInhoud.Location = New System.Drawing.Point(20, 416)
        Me.lblInhoud.Name = "lblInhoud"
        Me.lblInhoud.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblInhoud.Size = New System.Drawing.Size(93, 13)
        Me.lblInhoud.TabIndex = 30
        Me.lblInhoud.Text = "Contents"
        '
        'lblOnderwerp
        '
        Me.lblOnderwerp.BackColor = System.Drawing.SystemColors.Control
        Me.lblOnderwerp.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblOnderwerp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnderwerp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOnderwerp.Location = New System.Drawing.Point(20, 388)
        Me.lblOnderwerp.Name = "lblOnderwerp"
        Me.lblOnderwerp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblOnderwerp.Size = New System.Drawing.Size(93, 13)
        Me.lblOnderwerp.TabIndex = 29
        Me.lblOnderwerp.Text = "Subject"
        '
        'lblBriefBesonderhede
        '
        Me.lblBriefBesonderhede.BackColor = System.Drawing.SystemColors.Control
        Me.lblBriefBesonderhede.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblBriefBesonderhede.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBriefBesonderhede.ForeColor = System.Drawing.Color.Black
        Me.lblBriefBesonderhede.Location = New System.Drawing.Point(12, 364)
        Me.lblBriefBesonderhede.Name = "lblBriefBesonderhede"
        Me.lblBriefBesonderhede.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBriefBesonderhede.Size = New System.Drawing.Size(129, 14)
        Me.lblBriefBesonderhede.TabIndex = 28
        Me.lblBriefBesonderhede.Text = "Letter details"
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
        Me.Label6.Size = New System.Drawing.Size(177, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Generic letter / E-mail criteria"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(20, 336)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(93, 13)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Destination"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(20, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(93, 14)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Policy (ies)"
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStatus.Location = New System.Drawing.Point(124, 574)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStatus.Size = New System.Drawing.Size(201, 13)
        Me.lblStatus.TabIndex = 24
        '
        'BriefGeneries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(617, 609)
        Me.ControlBox = False
        Me.Controls.Add(Me.frmKriteria)
        Me.Controls.Add(Me.chkAttach)
        Me.Controls.Add(Me.txtOnderwerp)
        Me.Controls.Add(Me.txtInhoud)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.lblInhoud)
        Me.Controls.Add(Me.lblOnderwerp)
        Me.Controls.Add(Me.lblBriefBesonderhede)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BriefGeneries"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Poldata - Letters - Generic"
        Me.frmKriteria.ResumeLayout(False)
        Me.frmKriteria.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        Me.Frame3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpAanvTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpAanvFrom As System.Windows.Forms.DateTimePicker
#End Region 
End Class