<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class BriefSkedule
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
		'MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents btnHelp As System.Windows.Forms.Button
	Public WithEvents cmbVersekeraar As System.Windows.Forms.ComboBox
	Public WithEvents cmbTaal As System.Windows.Forms.ComboBox
	Public WithEvents cmbPosbestemming As System.Windows.Forms.ComboBox
	Public WithEvents txtTot As System.Windows.Forms.TextBox
	Public WithEvents txtVanaf As System.Windows.Forms.TextBox
	Public WithEvents lstArea As System.Windows.Forms.ListBox
	Public WithEvents cmbStatus As System.Windows.Forms.ComboBox
	Public WithEvents lblVersekeraar As System.Windows.Forms.Label
	Public WithEvents lblPosbestemming As System.Windows.Forms.Label
	Public WithEvents lblTaal As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents frmKriteria As System.Windows.Forms.GroupBox
	Public WithEvents chkAddisioneleVoorwaardes As System.Windows.Forms.CheckBox
	Public WithEvents chkBesonderhedeItems As System.Windows.Forms.CheckBox
	Public WithEvents chkEdossemente As System.Windows.Forms.CheckBox
	Public WithEvents chkLaasteWysigings As System.Windows.Forms.CheckBox
	Public WithEvents chkBybetalings As System.Windows.Forms.CheckBox
	Public WithEvents chkUiteensettingPremie As System.Windows.Forms.CheckBox
	Public WithEvents chkOpsommingVersekering As System.Windows.Forms.CheckBox
	Public WithEvents chkBesonderhedeVersekerde As System.Windows.Forms.CheckBox
	Public WithEvents frmAfdelings As System.Windows.Forms.GroupBox
	Public WithEvents rdDrukker As System.Windows.Forms.RadioButton
	Public WithEvents rdEpos As System.Windows.Forms.RadioButton
	Public WithEvents Frame3 As System.Windows.Forms.Panel
	Public WithEvents rdKlient As System.Windows.Forms.RadioButton
	Public WithEvents rdKantoor As System.Windows.Forms.RadioButton
	Public WithEvents Frame2 As System.Windows.Forms.Panel
	Public WithEvents rdHuidig As System.Windows.Forms.RadioButton
	Public WithEvents rdSpesifieke As System.Windows.Forms.RadioButton
	Public WithEvents Frame1 As System.Windows.Forms.Panel
	Public WithEvents btnOk As System.Windows.Forms.Button
	Public WithEvents btnClose As System.Windows.Forms.Button
    Public WithEvents lblStatus As System.Windows.Forms.Label

	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents lblDatum As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.frmKriteria = New System.Windows.Forms.GroupBox()
        Me.cmbVersekeraar = New System.Windows.Forms.ComboBox()
        Me.cmbTaal = New System.Windows.Forms.ComboBox()
        Me.cmbPosbestemming = New System.Windows.Forms.ComboBox()
        Me.txtTot = New System.Windows.Forms.TextBox()
        Me.txtVanaf = New System.Windows.Forms.TextBox()
        Me.lstArea = New System.Windows.Forms.ListBox()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.lblVersekeraar = New System.Windows.Forms.Label()
        Me.lblPosbestemming = New System.Windows.Forms.Label()
        Me.lblTaal = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.frmAfdelings = New System.Windows.Forms.GroupBox()
        Me.chkAddisioneleVoorwaardes = New System.Windows.Forms.CheckBox()
        Me.chkBesonderhedeItems = New System.Windows.Forms.CheckBox()
        Me.chkEdossemente = New System.Windows.Forms.CheckBox()
        Me.chkLaasteWysigings = New System.Windows.Forms.CheckBox()
        Me.chkBybetalings = New System.Windows.Forms.CheckBox()
        Me.chkUiteensettingPremie = New System.Windows.Forms.CheckBox()
        Me.chkOpsommingVersekering = New System.Windows.Forms.CheckBox()
        Me.chkBesonderhedeVersekerde = New System.Windows.Forms.CheckBox()
        Me.Frame3 = New System.Windows.Forms.Panel()
        Me.rdDrukker = New System.Windows.Forms.RadioButton()
        Me.rdEpos = New System.Windows.Forms.RadioButton()
        Me.Frame2 = New System.Windows.Forms.Panel()
        Me.rdKlient = New System.Windows.Forms.RadioButton()
        Me.rdKantoor = New System.Windows.Forms.RadioButton()
        Me.Frame1 = New System.Windows.Forms.Panel()
        Me.rdHuidig = New System.Windows.Forms.RadioButton()
        Me.rdSpesifieke = New System.Windows.Forms.RadioButton()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblDatum = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpGewysig = New System.Windows.Forms.DateTimePicker()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.frmKriteria.SuspendLayout()
        Me.frmAfdelings.SuspendLayout()
        Me.Frame3.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnHelp
        '
        Me.btnHelp.BackColor = System.Drawing.SystemColors.Control
        Me.btnHelp.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnHelp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHelp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnHelp.Location = New System.Drawing.Point(512, 564)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnHelp.Size = New System.Drawing.Size(85, 25)
        Me.btnHelp.TabIndex = 39
        Me.btnHelp.Text = "&Help"
        Me.btnHelp.UseVisualStyleBackColor = False
        '
        'frmKriteria
        '
        Me.frmKriteria.BackColor = System.Drawing.SystemColors.Control
        Me.frmKriteria.Controls.Add(Me.cmbVersekeraar)
        Me.frmKriteria.Controls.Add(Me.cmbTaal)
        Me.frmKriteria.Controls.Add(Me.cmbPosbestemming)
        Me.frmKriteria.Controls.Add(Me.txtTot)
        Me.frmKriteria.Controls.Add(Me.txtVanaf)
        Me.frmKriteria.Controls.Add(Me.lstArea)
        Me.frmKriteria.Controls.Add(Me.cmbStatus)
        Me.frmKriteria.Controls.Add(Me.lblVersekeraar)
        Me.frmKriteria.Controls.Add(Me.lblPosbestemming)
        Me.frmKriteria.Controls.Add(Me.lblTaal)
        Me.frmKriteria.Controls.Add(Me.Label3)
        Me.frmKriteria.Controls.Add(Me.Label2)
        Me.frmKriteria.Controls.Add(Me.Label1)
        Me.frmKriteria.Controls.Add(Me.Label5)
        Me.frmKriteria.Enabled = False
        Me.frmKriteria.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmKriteria.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmKriteria.Location = New System.Drawing.Point(128, 64)
        Me.frmKriteria.Name = "frmKriteria"
        Me.frmKriteria.Padding = New System.Windows.Forms.Padding(0)
        Me.frmKriteria.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmKriteria.Size = New System.Drawing.Size(469, 245)
        Me.frmKriteria.TabIndex = 30
        Me.frmKriteria.TabStop = False
        Me.frmKriteria.Text = "Criteria"
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
        Me.cmbVersekeraar.TabIndex = 42
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
        Me.cmbTaal.Location = New System.Drawing.Point(108, 146)
        Me.cmbTaal.Name = "cmbTaal"
        Me.cmbTaal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbTaal.Size = New System.Drawing.Size(157, 22)
        Me.cmbTaal.TabIndex = 40
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
        Me.cmbPosbestemming.Location = New System.Drawing.Point(108, 212)
        Me.cmbPosbestemming.Name = "cmbPosbestemming"
        Me.cmbPosbestemming.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbPosbestemming.Size = New System.Drawing.Size(157, 22)
        Me.cmbPosbestemming.TabIndex = 38
        '
        'txtTot
        '
        Me.txtTot.AcceptsReturn = True
        Me.txtTot.BackColor = System.Drawing.SystemColors.Window
        Me.txtTot.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTot.Enabled = False
        Me.txtTot.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTot.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTot.Location = New System.Drawing.Point(292, 114)
        Me.txtTot.MaxLength = 25
        Me.txtTot.Name = "txtTot"
        Me.txtTot.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTot.Size = New System.Drawing.Size(157, 20)
        Me.txtTot.TabIndex = 4
        '
        'txtVanaf
        '
        Me.txtVanaf.AcceptsReturn = True
        Me.txtVanaf.BackColor = System.Drawing.SystemColors.Window
        Me.txtVanaf.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVanaf.Enabled = False
        Me.txtVanaf.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVanaf.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVanaf.Location = New System.Drawing.Point(108, 114)
        Me.txtVanaf.MaxLength = 25
        Me.txtVanaf.Name = "txtVanaf"
        Me.txtVanaf.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVanaf.Size = New System.Drawing.Size(157, 20)
        Me.txtVanaf.TabIndex = 3
        '
        'lstArea
        '
        Me.lstArea.BackColor = System.Drawing.SystemColors.Window
        Me.lstArea.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstArea.Enabled = False
        Me.lstArea.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstArea.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstArea.ItemHeight = 14
        Me.lstArea.Location = New System.Drawing.Point(108, 57)
        Me.lstArea.Name = "lstArea"
        Me.lstArea.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstArea.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstArea.Size = New System.Drawing.Size(341, 46)
        Me.lstArea.TabIndex = 2
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
        Me.cmbStatus.Location = New System.Drawing.Point(108, 179)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbStatus.Size = New System.Drawing.Size(157, 22)
        Me.cmbStatus.TabIndex = 5
        '
        'lblVersekeraar
        '
        Me.lblVersekeraar.BackColor = System.Drawing.SystemColors.Control
        Me.lblVersekeraar.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblVersekeraar.Enabled = False
        Me.lblVersekeraar.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersekeraar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblVersekeraar.Location = New System.Drawing.Point(20, 24)
        Me.lblVersekeraar.Name = "lblVersekeraar"
        Me.lblVersekeraar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVersekeraar.Size = New System.Drawing.Size(73, 17)
        Me.lblVersekeraar.TabIndex = 41
        Me.lblVersekeraar.Text = "Insurer"
        '
        'lblPosbestemming
        '
        Me.lblPosbestemming.BackColor = System.Drawing.SystemColors.Control
        Me.lblPosbestemming.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPosbestemming.Enabled = False
        Me.lblPosbestemming.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosbestemming.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPosbestemming.Location = New System.Drawing.Point(3, 217)
        Me.lblPosbestemming.Name = "lblPosbestemming"
        Me.lblPosbestemming.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPosbestemming.Size = New System.Drawing.Size(98, 13)
        Me.lblPosbestemming.TabIndex = 37
        Me.lblPosbestemming.Text = "Post destination"
        '
        'lblTaal
        '
        Me.lblTaal.BackColor = System.Drawing.SystemColors.Control
        Me.lblTaal.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTaal.Enabled = False
        Me.lblTaal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTaal.Location = New System.Drawing.Point(20, 151)
        Me.lblTaal.Name = "lblTaal"
        Me.lblTaal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTaal.Size = New System.Drawing.Size(45, 17)
        Me.lblTaal.TabIndex = 35
        Me.lblTaal.Text = "Language"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(268, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "tot"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(20, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(77, 17)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Surnames"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(20, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Area"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Enabled = False
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(20, 185)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Status"
        '
        'frmAfdelings
        '
        Me.frmAfdelings.BackColor = System.Drawing.SystemColors.Control
        Me.frmAfdelings.Controls.Add(Me.chkAddisioneleVoorwaardes)
        Me.frmAfdelings.Controls.Add(Me.chkBesonderhedeItems)
        Me.frmAfdelings.Controls.Add(Me.chkEdossemente)
        Me.frmAfdelings.Controls.Add(Me.chkLaasteWysigings)
        Me.frmAfdelings.Controls.Add(Me.chkBybetalings)
        Me.frmAfdelings.Controls.Add(Me.chkUiteensettingPremie)
        Me.frmAfdelings.Controls.Add(Me.chkOpsommingVersekering)
        Me.frmAfdelings.Controls.Add(Me.chkBesonderhedeVersekerde)
        Me.frmAfdelings.Enabled = False
        Me.frmAfdelings.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmAfdelings.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmAfdelings.Location = New System.Drawing.Point(128, 376)
        Me.frmAfdelings.Name = "frmAfdelings"
        Me.frmAfdelings.Padding = New System.Windows.Forms.Padding(0)
        Me.frmAfdelings.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmAfdelings.Size = New System.Drawing.Size(469, 125)
        Me.frmAfdelings.TabIndex = 28
        Me.frmAfdelings.TabStop = False
        Me.frmAfdelings.Text = "Sections"
        '
        'chkAddisioneleVoorwaardes
        '
        Me.chkAddisioneleVoorwaardes.BackColor = System.Drawing.SystemColors.Control
        Me.chkAddisioneleVoorwaardes.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkAddisioneleVoorwaardes.Enabled = False
        Me.chkAddisioneleVoorwaardes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAddisioneleVoorwaardes.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAddisioneleVoorwaardes.Location = New System.Drawing.Point(244, 100)
        Me.chkAddisioneleVoorwaardes.Name = "chkAddisioneleVoorwaardes"
        Me.chkAddisioneleVoorwaardes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkAddisioneleVoorwaardes.Size = New System.Drawing.Size(189, 22)
        Me.chkAddisioneleVoorwaardes.TabIndex = 16
        Me.chkAddisioneleVoorwaardes.Text = "Additional conditions"
        Me.chkAddisioneleVoorwaardes.UseVisualStyleBackColor = False
        '
        'chkBesonderhedeItems
        '
        Me.chkBesonderhedeItems.BackColor = System.Drawing.SystemColors.Control
        Me.chkBesonderhedeItems.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkBesonderhedeItems.Enabled = False
        Me.chkBesonderhedeItems.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBesonderhedeItems.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkBesonderhedeItems.Location = New System.Drawing.Point(12, 100)
        Me.chkBesonderhedeItems.Name = "chkBesonderhedeItems"
        Me.chkBesonderhedeItems.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkBesonderhedeItems.Size = New System.Drawing.Size(201, 22)
        Me.chkBesonderhedeItems.TabIndex = 12
        Me.chkBesonderhedeItems.Text = "Details of insured items"
        Me.chkBesonderhedeItems.UseVisualStyleBackColor = False
        '
        'chkEdossemente
        '
        Me.chkEdossemente.BackColor = System.Drawing.SystemColors.Control
        Me.chkEdossemente.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkEdossemente.Enabled = False
        Me.chkEdossemente.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEdossemente.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkEdossemente.Location = New System.Drawing.Point(244, 76)
        Me.chkEdossemente.Name = "chkEdossemente"
        Me.chkEdossemente.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkEdossemente.Size = New System.Drawing.Size(189, 18)
        Me.chkEdossemente.TabIndex = 15
        Me.chkEdossemente.Text = "Endorsements"
        Me.chkEdossemente.UseVisualStyleBackColor = False
        '
        'chkLaasteWysigings
        '
        Me.chkLaasteWysigings.BackColor = System.Drawing.SystemColors.Control
        Me.chkLaasteWysigings.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkLaasteWysigings.Enabled = False
        Me.chkLaasteWysigings.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLaasteWysigings.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkLaasteWysigings.Location = New System.Drawing.Point(244, 52)
        Me.chkLaasteWysigings.Name = "chkLaasteWysigings"
        Me.chkLaasteWysigings.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkLaasteWysigings.Size = New System.Drawing.Size(201, 18)
        Me.chkLaasteWysigings.TabIndex = 14
        Me.chkLaasteWysigings.Text = "Details of recent changes"
        Me.chkLaasteWysigings.UseVisualStyleBackColor = False
        '
        'chkBybetalings
        '
        Me.chkBybetalings.BackColor = System.Drawing.SystemColors.Control
        Me.chkBybetalings.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkBybetalings.Enabled = False
        Me.chkBybetalings.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBybetalings.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkBybetalings.Location = New System.Drawing.Point(244, 28)
        Me.chkBybetalings.Name = "chkBybetalings"
        Me.chkBybetalings.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkBybetalings.Size = New System.Drawing.Size(189, 18)
        Me.chkBybetalings.TabIndex = 13
        Me.chkBybetalings.Text = "Surcharges"
        Me.chkBybetalings.UseVisualStyleBackColor = False
        '
        'chkUiteensettingPremie
        '
        Me.chkUiteensettingPremie.BackColor = System.Drawing.SystemColors.Control
        Me.chkUiteensettingPremie.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkUiteensettingPremie.Enabled = False
        Me.chkUiteensettingPremie.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkUiteensettingPremie.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkUiteensettingPremie.Location = New System.Drawing.Point(12, 76)
        Me.chkUiteensettingPremie.Name = "chkUiteensettingPremie"
        Me.chkUiteensettingPremie.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkUiteensettingPremie.Size = New System.Drawing.Size(189, 18)
        Me.chkUiteensettingPremie.TabIndex = 11
        Me.chkUiteensettingPremie.Text = "Breakdown of premiums"
        Me.chkUiteensettingPremie.UseVisualStyleBackColor = False
        '
        'chkOpsommingVersekering
        '
        Me.chkOpsommingVersekering.BackColor = System.Drawing.SystemColors.Control
        Me.chkOpsommingVersekering.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkOpsommingVersekering.Enabled = False
        Me.chkOpsommingVersekering.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOpsommingVersekering.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkOpsommingVersekering.Location = New System.Drawing.Point(12, 52)
        Me.chkOpsommingVersekering.Name = "chkOpsommingVersekering"
        Me.chkOpsommingVersekering.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkOpsommingVersekering.Size = New System.Drawing.Size(189, 18)
        Me.chkOpsommingVersekering.TabIndex = 10
        Me.chkOpsommingVersekering.Text = "Summary of insured"
        Me.chkOpsommingVersekering.UseVisualStyleBackColor = False
        '
        'chkBesonderhedeVersekerde
        '
        Me.chkBesonderhedeVersekerde.BackColor = System.Drawing.SystemColors.Control
        Me.chkBesonderhedeVersekerde.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkBesonderhedeVersekerde.Enabled = False
        Me.chkBesonderhedeVersekerde.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBesonderhedeVersekerde.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkBesonderhedeVersekerde.Location = New System.Drawing.Point(12, 28)
        Me.chkBesonderhedeVersekerde.Name = "chkBesonderhedeVersekerde"
        Me.chkBesonderhedeVersekerde.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkBesonderhedeVersekerde.Size = New System.Drawing.Size(189, 18)
        Me.chkBesonderhedeVersekerde.TabIndex = 9
        Me.chkBesonderhedeVersekerde.Text = "Details of insured"
        Me.chkBesonderhedeVersekerde.UseVisualStyleBackColor = False
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me.rdDrukker)
        Me.Frame3.Controls.Add(Me.rdEpos)
        Me.Frame3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Frame3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(120, 512)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(229, 25)
        Me.Frame3.TabIndex = 27
        '
        'rdDrukker
        '
        Me.rdDrukker.BackColor = System.Drawing.SystemColors.Control
        Me.rdDrukker.Checked = True
        Me.rdDrukker.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdDrukker.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdDrukker.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdDrukker.Location = New System.Drawing.Point(0, 4)
        Me.rdDrukker.Name = "rdDrukker"
        Me.rdDrukker.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdDrukker.Size = New System.Drawing.Size(77, 17)
        Me.rdDrukker.TabIndex = 17
        Me.rdDrukker.TabStop = True
        Me.rdDrukker.Text = "Printer"
        Me.rdDrukker.UseVisualStyleBackColor = False
        '
        'rdEpos
        '
        Me.rdEpos.BackColor = System.Drawing.SystemColors.Control
        Me.rdEpos.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdEpos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdEpos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdEpos.Location = New System.Drawing.Point(116, 4)
        Me.rdEpos.Name = "rdEpos"
        Me.rdEpos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdEpos.Size = New System.Drawing.Size(89, 17)
        Me.rdEpos.TabIndex = 18
        Me.rdEpos.TabStop = True
        Me.rdEpos.Text = "E-mail"
        Me.rdEpos.UseVisualStyleBackColor = False
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.rdKlient)
        Me.Frame2.Controls.Add(Me.rdKantoor)
        Me.Frame2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(124, 344)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(285, 29)
        Me.Frame2.TabIndex = 26
        '
        'rdKlient
        '
        Me.rdKlient.BackColor = System.Drawing.SystemColors.Control
        Me.rdKlient.Checked = True
        Me.rdKlient.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdKlient.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdKlient.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdKlient.Location = New System.Drawing.Point(0, 3)
        Me.rdKlient.Name = "rdKlient"
        Me.rdKlient.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdKlient.Size = New System.Drawing.Size(73, 22)
        Me.rdKlient.TabIndex = 7
        Me.rdKlient.TabStop = True
        Me.rdKlient.Text = "Client"
        Me.rdKlient.UseVisualStyleBackColor = False
        '
        'rdKantoor
        '
        Me.rdKantoor.BackColor = System.Drawing.SystemColors.Control
        Me.rdKantoor.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdKantoor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdKantoor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdKantoor.Location = New System.Drawing.Point(116, 3)
        Me.rdKantoor.Name = "rdKantoor"
        Me.rdKantoor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdKantoor.Size = New System.Drawing.Size(121, 22)
        Me.rdKantoor.TabIndex = 8
        Me.rdKantoor.TabStop = True
        Me.rdKantoor.Text = "Office use"
        Me.rdKantoor.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.rdHuidig)
        Me.Frame1.Controls.Add(Me.rdSpesifieke)
        Me.Frame1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(124, 40)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(301, 24)
        Me.Frame1.TabIndex = 25
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
        Me.rdHuidig.TabIndex = 0
        Me.rdHuidig.TabStop = True
        Me.rdHuidig.Text = "Current policy"
        Me.rdHuidig.UseVisualStyleBackColor = False
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
        Me.rdSpesifieke.TabIndex = 1
        Me.rdSpesifieke.TabStop = True
        Me.rdSpesifieke.Text = "Specific \ all  policies"
        Me.rdSpesifieke.UseVisualStyleBackColor = False
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOk.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Location = New System.Drawing.Point(328, 564)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New System.Drawing.Size(85, 25)
        Me.btnOk.TabIndex = 19
        Me.btnOk.Text = "&Ok"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Location = New System.Drawing.Point(420, 564)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClose.Size = New System.Drawing.Size(85, 25)
        Me.btnClose.TabIndex = 20
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStatus.Location = New System.Drawing.Point(124, 568)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStatus.Size = New System.Drawing.Size(201, 13)
        Me.lblStatus.TabIndex = 36
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(93, 14)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Policy(ies)"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(16, 520)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(93, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Destination"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 356)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Print for"
        '
        'lblDatum
        '
        Me.lblDatum.BackColor = System.Drawing.SystemColors.Control
        Me.lblDatum.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDatum.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatum.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDatum.Location = New System.Drawing.Point(16, 324)
        Me.lblDatum.Name = "lblDatum"
        Me.lblDatum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDatum.Size = New System.Drawing.Size(93, 14)
        Me.lblDatum.TabIndex = 22
        Me.lblDatum.Text = "Date changed"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(16, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(121, 13)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Policy Schedule criteria"
        '
        'dtpGewysig
        '
        Me.dtpGewysig.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpGewysig.Location = New System.Drawing.Point(127, 318)
        Me.dtpGewysig.Name = "dtpGewysig"
        Me.dtpGewysig.ShowCheckBox = True
        Me.dtpGewysig.Size = New System.Drawing.Size(110, 20)
        Me.dtpGewysig.TabIndex = 40
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer"
        Me.ReportViewer1.Size = New System.Drawing.Size(400, 250)
        Me.ReportViewer1.TabIndex = 0
        '
        'BriefSkedule
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(612, 599)
        Me.ControlBox = False
        Me.Controls.Add(Me.dtpGewysig)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.frmKriteria)
        Me.Controls.Add(Me.frmAfdelings)
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblDatum)
        Me.Controls.Add(Me.Label6)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BriefSkedule"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Poldata - Reports - Policy Schedules"
        Me.frmKriteria.ResumeLayout(False)
        Me.frmKriteria.PerformLayout()
        Me.frmAfdelings.ResumeLayout(False)
        Me.Frame3.ResumeLayout(False)
        Me.Frame2.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtpGewysig As System.Windows.Forms.DateTimePicker
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
#End Region 
End Class