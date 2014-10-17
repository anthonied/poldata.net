<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class Bet_Wyse
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
	Public WithEvents txtType As System.Windows.Forms.TextBox
	Public WithEvents txtKaartVervaldatum As System.Windows.Forms.TextBox
	Public WithEvents txtCVVNommer As System.Windows.Forms.TextBox
	Public WithEvents cmbAccType As System.Windows.Forms.ComboBox
	Public WithEvents txtInitials As System.Windows.Forms.TextBox
	Public WithEvents txtSurname As System.Windows.Forms.TextBox
	Public WithEvents txtAccNumber As System.Windows.Forms.TextBox
	Public WithEvents Image7 As System.Windows.Forms.PictureBox
	Public WithEvents Image6 As System.Windows.Forms.PictureBox
	Public WithEvents lblCreditCardVervalDatum As System.Windows.Forms.Label
	Public WithEvents lblCVVNumber As System.Windows.Forms.Label
	Public WithEvents Image2 As System.Windows.Forms.PictureBox
	Public WithEvents Image1 As System.Windows.Forms.PictureBox
	Public WithEvents lblSurname As System.Windows.Forms.Label
	Public WithEvents lblInitials As System.Windows.Forms.Label
	Public WithEvents lblAccType As System.Windows.Forms.Label
	Public WithEvents lblAccNumber As System.Windows.Forms.Label
	Public WithEvents frameRekening As System.Windows.Forms.GroupBox
	Public WithEvents txtPkBnkCodes As System.Windows.Forms.TextBox
	Public WithEvents btnBanke As System.Windows.Forms.Button
	Public WithEvents txtBranchCode As System.Windows.Forms.TextBox
	Public WithEvents txtBranch As System.Windows.Forms.TextBox
	Public WithEvents txtBank As System.Windows.Forms.TextBox
	Public WithEvents Image5 As System.Windows.Forms.PictureBox
	Public WithEvents Image4 As System.Windows.Forms.PictureBox
	Public WithEvents Image3 As System.Windows.Forms.PictureBox
	Public WithEvents lblBranchCode As System.Windows.Forms.Label
	Public WithEvents lblBranch As System.Windows.Forms.Label
	Public WithEvents lblBank As System.Windows.Forms.Label
	Public WithEvents frameBank As System.Windows.Forms.GroupBox
	Public WithEvents rdTermynPolis As System.Windows.Forms.RadioButton
	Public WithEvents rdMndElektronies As System.Windows.Forms.RadioButton
	Public WithEvents rdMndDebiet As System.Windows.Forms.RadioButton
	Public WithEvents rdMndSalaris As System.Windows.Forms.RadioButton
    Public WithEvents rdMndKontant As System.Windows.Forms.RadioButton
	Public WithEvents frameBetalings As System.Windows.Forms.GroupBox
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents btnOk As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Bet_Wyse))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Image7 = New System.Windows.Forms.PictureBox()
        Me.Image6 = New System.Windows.Forms.PictureBox()
        Me.Image2 = New System.Windows.Forms.PictureBox()
        Me.Image1 = New System.Windows.Forms.PictureBox()
        Me.Image5 = New System.Windows.Forms.PictureBox()
        Me.Image4 = New System.Windows.Forms.PictureBox()
        Me.Image3 = New System.Windows.Forms.PictureBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtType = New System.Windows.Forms.TextBox()
        Me.frameRekening = New System.Windows.Forms.GroupBox()
        Me.txtKaartVervaldatum = New System.Windows.Forms.TextBox()
        Me.txtCVVNommer = New System.Windows.Forms.TextBox()
        Me.cmbAccType = New System.Windows.Forms.ComboBox()
        Me.txtInitials = New System.Windows.Forms.TextBox()
        Me.txtSurname = New System.Windows.Forms.TextBox()
        Me.txtAccNumber = New System.Windows.Forms.TextBox()
        Me.lblCreditCardVervalDatum = New System.Windows.Forms.Label()
        Me.lblCVVNumber = New System.Windows.Forms.Label()
        Me.lblSurname = New System.Windows.Forms.Label()
        Me.lblInitials = New System.Windows.Forms.Label()
        Me.lblAccType = New System.Windows.Forms.Label()
        Me.lblAccNumber = New System.Windows.Forms.Label()
        Me.frameBank = New System.Windows.Forms.GroupBox()
        Me.txtPkBnkCodes = New System.Windows.Forms.TextBox()
        Me.btnBanke = New System.Windows.Forms.Button()
        Me.txtBranchCode = New System.Windows.Forms.TextBox()
        Me.txtBranch = New System.Windows.Forms.TextBox()
        Me.txtBank = New System.Windows.Forms.TextBox()
        Me.lblBranchCode = New System.Windows.Forms.Label()
        Me.lblBranch = New System.Windows.Forms.Label()
        Me.lblBank = New System.Windows.Forms.Label()
        Me.frameBetalings = New System.Windows.Forms.GroupBox()
        Me.rdTermynPolis = New System.Windows.Forms.RadioButton()
        Me.rdMndElektronies = New System.Windows.Forms.RadioButton()
        Me.rdMndDebiet = New System.Windows.Forms.RadioButton()
        Me.rdMndSalaris = New System.Windows.Forms.RadioButton()
        Me.rdMndKontant = New System.Windows.Forms.RadioButton()
        CType(Me.Image7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frameRekening.SuspendLayout()
        Me.frameBank.SuspendLayout()
        Me.frameBetalings.SuspendLayout()
        Me.SuspendLayout()
        '
        'Image7
        '
        Me.Image7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image7.Image = CType(resources.GetObject("Image7.Image"), System.Drawing.Image)
        Me.Image7.Location = New System.Drawing.Point(408, 168)
        Me.Image7.Name = "Image7"
        Me.Image7.Size = New System.Drawing.Size(8, 8)
        Me.Image7.TabIndex = 11
        Me.Image7.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Image7, "Required Field")
        '
        'Image6
        '
        Me.Image6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image6.Image = CType(resources.GetObject("Image6.Image"), System.Drawing.Image)
        Me.Image6.Location = New System.Drawing.Point(224, 168)
        Me.Image6.Name = "Image6"
        Me.Image6.Size = New System.Drawing.Size(8, 8)
        Me.Image6.TabIndex = 12
        Me.Image6.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Image6, "Required Field")
        '
        'Image2
        '
        Me.Image2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image2.Image = CType(resources.GetObject("Image2.Image"), System.Drawing.Image)
        Me.Image2.Location = New System.Drawing.Point(292, 72)
        Me.Image2.Name = "Image2"
        Me.Image2.Size = New System.Drawing.Size(8, 8)
        Me.Image2.TabIndex = 32
        Me.Image2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Image2, "Required Field")
        '
        'Image1
        '
        Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image1.Image = CType(resources.GetObject("Image1.Image"), System.Drawing.Image)
        Me.Image1.Location = New System.Drawing.Point(324, 40)
        Me.Image1.Name = "Image1"
        Me.Image1.Size = New System.Drawing.Size(8, 8)
        Me.Image1.TabIndex = 33
        Me.Image1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Image1, "Required Field")
        '
        'Image5
        '
        Me.Image5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image5.Image = CType(resources.GetObject("Image5.Image"), System.Drawing.Image)
        Me.Image5.Location = New System.Drawing.Point(260, 104)
        Me.Image5.Name = "Image5"
        Me.Image5.Size = New System.Drawing.Size(8, 8)
        Me.Image5.TabIndex = 27
        Me.Image5.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Image5, "Required Field")
        '
        'Image4
        '
        Me.Image4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image4.Image = CType(resources.GetObject("Image4.Image"), System.Drawing.Image)
        Me.Image4.Location = New System.Drawing.Point(416, 72)
        Me.Image4.Name = "Image4"
        Me.Image4.Size = New System.Drawing.Size(8, 8)
        Me.Image4.TabIndex = 28
        Me.Image4.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Image4, "Required Field")
        '
        'Image3
        '
        Me.Image3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image3.Image = CType(resources.GetObject("Image3.Image"), System.Drawing.Image)
        Me.Image3.Location = New System.Drawing.Point(336, 40)
        Me.Image3.Name = "Image3"
        Me.Image3.Size = New System.Drawing.Size(8, 8)
        Me.Image3.TabIndex = 29
        Me.Image3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Image3, "Required Field")
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Location = New System.Drawing.Point(460, 384)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New System.Drawing.Size(77, 25)
        Me.btnOk.TabIndex = 11
        Me.btnOk.Text = "&Ok"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(540, 384)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(77, 25)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'txtType
        '
        Me.txtType.AcceptsReturn = True
        Me.txtType.BackColor = System.Drawing.SystemColors.Window
        Me.txtType.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtType.Location = New System.Drawing.Point(352, 144)
        Me.txtType.MaxLength = 0
        Me.txtType.Name = "txtType"
        Me.txtType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtType.Size = New System.Drawing.Size(169, 20)
        Me.txtType.TabIndex = 27
        Me.txtType.TabStop = False
        Me.txtType.Visible = False
        '
        'frameRekening
        '
        Me.frameRekening.BackColor = System.Drawing.SystemColors.Control
        Me.frameRekening.Controls.Add(Me.txtKaartVervaldatum)
        Me.frameRekening.Controls.Add(Me.txtCVVNommer)
        Me.frameRekening.Controls.Add(Me.cmbAccType)
        Me.frameRekening.Controls.Add(Me.txtInitials)
        Me.frameRekening.Controls.Add(Me.txtSurname)
        Me.frameRekening.Controls.Add(Me.txtAccNumber)
        Me.frameRekening.Controls.Add(Me.Image7)
        Me.frameRekening.Controls.Add(Me.Image6)
        Me.frameRekening.Controls.Add(Me.lblCreditCardVervalDatum)
        Me.frameRekening.Controls.Add(Me.lblCVVNumber)
        Me.frameRekening.Controls.Add(Me.Image2)
        Me.frameRekening.Controls.Add(Me.Image1)
        Me.frameRekening.Controls.Add(Me.lblSurname)
        Me.frameRekening.Controls.Add(Me.lblInitials)
        Me.frameRekening.Controls.Add(Me.lblAccType)
        Me.frameRekening.Controls.Add(Me.lblAccNumber)
        Me.frameRekening.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frameRekening.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frameRekening.Location = New System.Drawing.Point(184, 172)
        Me.frameRekening.Name = "frameRekening"
        Me.frameRekening.Padding = New System.Windows.Forms.Padding(0)
        Me.frameRekening.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frameRekening.Size = New System.Drawing.Size(433, 197)
        Me.frameRekening.TabIndex = 21
        Me.frameRekening.TabStop = False
        Me.frameRekening.Text = "Account details"
        '
        'txtKaartVervaldatum
        '
        Me.txtKaartVervaldatum.AcceptsReturn = True
        Me.txtKaartVervaldatum.BackColor = System.Drawing.SystemColors.Window
        Me.txtKaartVervaldatum.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtKaartVervaldatum.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKaartVervaldatum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtKaartVervaldatum.Location = New System.Drawing.Point(352, 161)
        Me.txtKaartVervaldatum.MaxLength = 4
        Me.txtKaartVervaldatum.Name = "txtKaartVervaldatum"
        Me.txtKaartVervaldatum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtKaartVervaldatum.Size = New System.Drawing.Size(49, 20)
        Me.txtKaartVervaldatum.TabIndex = 10
        '
        'txtCVVNommer
        '
        Me.txtCVVNommer.AcceptsReturn = True
        Me.txtCVVNommer.BackColor = System.Drawing.SystemColors.Window
        Me.txtCVVNommer.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCVVNommer.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCVVNommer.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCVVNommer.Location = New System.Drawing.Point(168, 161)
        Me.txtCVVNommer.MaxLength = 3
        Me.txtCVVNommer.Name = "txtCVVNommer"
        Me.txtCVVNommer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCVVNommer.Size = New System.Drawing.Size(49, 20)
        Me.txtCVVNommer.TabIndex = 9
        '
        'cmbAccType
        '
        Me.cmbAccType.BackColor = System.Drawing.SystemColors.Window
        Me.cmbAccType.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbAccType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAccType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAccType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbAccType.Location = New System.Drawing.Point(168, 65)
        Me.cmbAccType.Name = "cmbAccType"
        Me.cmbAccType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbAccType.Size = New System.Drawing.Size(117, 22)
        Me.cmbAccType.TabIndex = 6
        '
        'txtInitials
        '
        Me.txtInitials.AcceptsReturn = True
        Me.txtInitials.BackColor = System.Drawing.SystemColors.Window
        Me.txtInitials.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInitials.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInitials.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtInitials.Location = New System.Drawing.Point(168, 96)
        Me.txtInitials.MaxLength = 6
        Me.txtInitials.Name = "txtInitials"
        Me.txtInitials.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtInitials.Size = New System.Drawing.Size(61, 20)
        Me.txtInitials.TabIndex = 7
        '
        'txtSurname
        '
        Me.txtSurname.AcceptsReturn = True
        Me.txtSurname.BackColor = System.Drawing.SystemColors.Window
        Me.txtSurname.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSurname.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSurname.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSurname.Location = New System.Drawing.Point(168, 128)
        Me.txtSurname.MaxLength = 25
        Me.txtSurname.Name = "txtSurname"
        Me.txtSurname.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSurname.Size = New System.Drawing.Size(205, 20)
        Me.txtSurname.TabIndex = 8
        '
        'txtAccNumber
        '
        Me.txtAccNumber.AcceptsReturn = True
        Me.txtAccNumber.BackColor = System.Drawing.SystemColors.Window
        Me.txtAccNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAccNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAccNumber.Location = New System.Drawing.Point(168, 33)
        Me.txtAccNumber.MaxLength = 15
        Me.txtAccNumber.Name = "txtAccNumber"
        Me.txtAccNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAccNumber.Size = New System.Drawing.Size(149, 20)
        Me.txtAccNumber.TabIndex = 5
        '
        'lblCreditCardVervalDatum
        '
        Me.lblCreditCardVervalDatum.BackColor = System.Drawing.SystemColors.Control
        Me.lblCreditCardVervalDatum.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCreditCardVervalDatum.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreditCardVervalDatum.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCreditCardVervalDatum.Location = New System.Drawing.Point(240, 168)
        Me.lblCreditCardVervalDatum.Name = "lblCreditCardVervalDatum"
        Me.lblCreditCardVervalDatum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCreditCardVervalDatum.Size = New System.Drawing.Size(121, 13)
        Me.lblCreditCardVervalDatum.TabIndex = 31
        Me.lblCreditCardVervalDatum.Text = "Expiry date (YYMM)"
        '
        'lblCVVNumber
        '
        Me.lblCVVNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblCVVNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCVVNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCVVNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCVVNumber.Location = New System.Drawing.Point(16, 168)
        Me.lblCVVNumber.Name = "lblCVVNumber"
        Me.lblCVVNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCVVNumber.Size = New System.Drawing.Size(97, 13)
        Me.lblCVVNumber.TabIndex = 30
        Me.lblCVVNumber.Text = "CVV number"
        '
        'lblSurname
        '
        Me.lblSurname.BackColor = System.Drawing.SystemColors.Control
        Me.lblSurname.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSurname.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSurname.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSurname.Location = New System.Drawing.Point(16, 136)
        Me.lblSurname.Name = "lblSurname"
        Me.lblSurname.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSurname.Size = New System.Drawing.Size(169, 13)
        Me.lblSurname.TabIndex = 25
        Me.lblSurname.Text = "Account holder"
        '
        'lblInitials
        '
        Me.lblInitials.BackColor = System.Drawing.SystemColors.Control
        Me.lblInitials.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblInitials.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInitials.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInitials.Location = New System.Drawing.Point(16, 104)
        Me.lblInitials.Name = "lblInitials"
        Me.lblInitials.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblInitials.Size = New System.Drawing.Size(169, 13)
        Me.lblInitials.TabIndex = 24
        Me.lblInitials.Text = "Account holder initials"
        '
        'lblAccType
        '
        Me.lblAccType.BackColor = System.Drawing.SystemColors.Control
        Me.lblAccType.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAccType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAccType.Location = New System.Drawing.Point(16, 72)
        Me.lblAccType.Name = "lblAccType"
        Me.lblAccType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAccType.Size = New System.Drawing.Size(169, 13)
        Me.lblAccType.TabIndex = 23
        Me.lblAccType.Text = "Account Type"
        '
        'lblAccNumber
        '
        Me.lblAccNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblAccNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAccNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAccNumber.Location = New System.Drawing.Point(16, 40)
        Me.lblAccNumber.Name = "lblAccNumber"
        Me.lblAccNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAccNumber.Size = New System.Drawing.Size(169, 13)
        Me.lblAccNumber.TabIndex = 22
        Me.lblAccNumber.Text = "Account number"
        '
        'frameBank
        '
        Me.frameBank.BackColor = System.Drawing.SystemColors.Control
        Me.frameBank.Controls.Add(Me.txtPkBnkCodes)
        Me.frameBank.Controls.Add(Me.btnBanke)
        Me.frameBank.Controls.Add(Me.txtBranchCode)
        Me.frameBank.Controls.Add(Me.txtBranch)
        Me.frameBank.Controls.Add(Me.txtBank)
        Me.frameBank.Controls.Add(Me.Image5)
        Me.frameBank.Controls.Add(Me.Image4)
        Me.frameBank.Controls.Add(Me.Image3)
        Me.frameBank.Controls.Add(Me.lblBranchCode)
        Me.frameBank.Controls.Add(Me.lblBranch)
        Me.frameBank.Controls.Add(Me.lblBank)
        Me.frameBank.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frameBank.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frameBank.Location = New System.Drawing.Point(184, 16)
        Me.frameBank.Name = "frameBank"
        Me.frameBank.Padding = New System.Windows.Forms.Padding(0)
        Me.frameBank.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frameBank.Size = New System.Drawing.Size(433, 150)
        Me.frameBank.TabIndex = 14
        Me.frameBank.TabStop = False
        Me.frameBank.Text = "Bank details"
        '
        'txtPkBnkCodes
        '
        Me.txtPkBnkCodes.AcceptsReturn = True
        Me.txtPkBnkCodes.BackColor = System.Drawing.SystemColors.Window
        Me.txtPkBnkCodes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPkBnkCodes.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPkBnkCodes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPkBnkCodes.Location = New System.Drawing.Point(168, 0)
        Me.txtPkBnkCodes.MaxLength = 0
        Me.txtPkBnkCodes.Name = "txtPkBnkCodes"
        Me.txtPkBnkCodes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPkBnkCodes.Size = New System.Drawing.Size(141, 20)
        Me.txtPkBnkCodes.TabIndex = 26
        Me.txtPkBnkCodes.TabStop = False
        Me.txtPkBnkCodes.Text = "0"
        Me.txtPkBnkCodes.Visible = False
        '
        'btnBanke
        '
        Me.btnBanke.BackColor = System.Drawing.SystemColors.Control
        Me.btnBanke.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnBanke.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBanke.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBanke.Location = New System.Drawing.Point(352, 32)
        Me.btnBanke.Name = "btnBanke"
        Me.btnBanke.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnBanke.Size = New System.Drawing.Size(61, 21)
        Me.btnBanke.TabIndex = 4
        Me.btnBanke.Text = "Banks ..."
        Me.btnBanke.UseVisualStyleBackColor = False
        '
        'txtBranchCode
        '
        Me.txtBranchCode.AcceptsReturn = True
        Me.txtBranchCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtBranchCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBranchCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranchCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBranchCode.Location = New System.Drawing.Point(168, 97)
        Me.txtBranchCode.MaxLength = 0
        Me.txtBranchCode.Name = "txtBranchCode"
        Me.txtBranchCode.ReadOnly = True
        Me.txtBranchCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBranchCode.Size = New System.Drawing.Size(85, 20)
        Me.txtBranchCode.TabIndex = 17
        Me.txtBranchCode.TabStop = False
        '
        'txtBranch
        '
        Me.txtBranch.AcceptsReturn = True
        Me.txtBranch.BackColor = System.Drawing.SystemColors.Window
        Me.txtBranch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBranch.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranch.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBranch.Location = New System.Drawing.Point(168, 64)
        Me.txtBranch.MaxLength = 0
        Me.txtBranch.Name = "txtBranch"
        Me.txtBranch.ReadOnly = True
        Me.txtBranch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBranch.Size = New System.Drawing.Size(241, 20)
        Me.txtBranch.TabIndex = 16
        Me.txtBranch.TabStop = False
        '
        'txtBank
        '
        Me.txtBank.AcceptsReturn = True
        Me.txtBank.BackColor = System.Drawing.SystemColors.Window
        Me.txtBank.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBank.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBank.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBank.Location = New System.Drawing.Point(168, 32)
        Me.txtBank.MaxLength = 0
        Me.txtBank.Name = "txtBank"
        Me.txtBank.ReadOnly = True
        Me.txtBank.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBank.Size = New System.Drawing.Size(161, 20)
        Me.txtBank.TabIndex = 15
        Me.txtBank.TabStop = False
        '
        'lblBranchCode
        '
        Me.lblBranchCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblBranchCode.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblBranchCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBranchCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBranchCode.Location = New System.Drawing.Point(16, 100)
        Me.lblBranchCode.Name = "lblBranchCode"
        Me.lblBranchCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBranchCode.Size = New System.Drawing.Size(165, 17)
        Me.lblBranchCode.TabIndex = 20
        Me.lblBranchCode.Text = "Branch code"
        '
        'lblBranch
        '
        Me.lblBranch.BackColor = System.Drawing.SystemColors.Control
        Me.lblBranch.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblBranch.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBranch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBranch.Location = New System.Drawing.Point(16, 72)
        Me.lblBranch.Name = "lblBranch"
        Me.lblBranch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBranch.Size = New System.Drawing.Size(169, 13)
        Me.lblBranch.TabIndex = 19
        Me.lblBranch.Text = "Branch"
        '
        'lblBank
        '
        Me.lblBank.BackColor = System.Drawing.SystemColors.Control
        Me.lblBank.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblBank.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBank.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBank.Location = New System.Drawing.Point(16, 40)
        Me.lblBank.Name = "lblBank"
        Me.lblBank.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBank.Size = New System.Drawing.Size(169, 13)
        Me.lblBank.TabIndex = 18
        Me.lblBank.Text = "Bank"
        '
        'frameBetalings
        '
        Me.frameBetalings.BackColor = System.Drawing.SystemColors.Control
        Me.frameBetalings.Controls.Add(Me.rdTermynPolis)
        Me.frameBetalings.Controls.Add(Me.rdMndElektronies)
        Me.frameBetalings.Controls.Add(Me.rdMndDebiet)
        Me.frameBetalings.Controls.Add(Me.rdMndSalaris)
        Me.frameBetalings.Controls.Add(Me.rdMndKontant)
        Me.frameBetalings.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frameBetalings.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frameBetalings.Location = New System.Drawing.Point(16, 16)
        Me.frameBetalings.Name = "frameBetalings"
        Me.frameBetalings.Padding = New System.Windows.Forms.Padding(0)
        Me.frameBetalings.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frameBetalings.Size = New System.Drawing.Size(157, 353)
        Me.frameBetalings.TabIndex = 12
        Me.frameBetalings.TabStop = False
        Me.frameBetalings.Text = "Payment method"
        '
        'rdTermynPolis
        '
        Me.rdTermynPolis.BackColor = System.Drawing.SystemColors.Control
        Me.rdTermynPolis.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdTermynPolis.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdTermynPolis.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdTermynPolis.Location = New System.Drawing.Point(16, 199)
        Me.rdTermynPolis.Name = "rdTermynPolis"
        Me.rdTermynPolis.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdTermynPolis.Size = New System.Drawing.Size(125, 23)
        Me.rdTermynPolis.TabIndex = 29
        Me.rdTermynPolis.TabStop = True
        Me.rdTermynPolis.Text = "Term Policy"
        Me.rdTermynPolis.UseVisualStyleBackColor = False
        '
        'rdMndElektronies
        '
        Me.rdMndElektronies.BackColor = System.Drawing.SystemColors.Control
        Me.rdMndElektronies.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdMndElektronies.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdMndElektronies.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdMndElektronies.Location = New System.Drawing.Point(16, 146)
        Me.rdMndElektronies.Name = "rdMndElektronies"
        Me.rdMndElektronies.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdMndElektronies.Size = New System.Drawing.Size(137, 23)
        Me.rdMndElektronies.TabIndex = 28
        Me.rdMndElektronies.TabStop = True
        Me.rdMndElektronies.Text = "Monthly electronic"
        Me.rdMndElektronies.UseVisualStyleBackColor = False
        '
        'rdMndDebiet
        '
        Me.rdMndDebiet.BackColor = System.Drawing.SystemColors.Control
        Me.rdMndDebiet.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdMndDebiet.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdMndDebiet.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdMndDebiet.Location = New System.Drawing.Point(16, 93)
        Me.rdMndDebiet.Name = "rdMndDebiet"
        Me.rdMndDebiet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdMndDebiet.Size = New System.Drawing.Size(125, 23)
        Me.rdMndDebiet.TabIndex = 3
        Me.rdMndDebiet.TabStop = True
        Me.rdMndDebiet.Text = "Monthly debit"
        Me.rdMndDebiet.UseVisualStyleBackColor = False
        '
        'rdMndSalaris
        '
        Me.rdMndSalaris.BackColor = System.Drawing.SystemColors.Control
        Me.rdMndSalaris.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdMndSalaris.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdMndSalaris.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdMndSalaris.Location = New System.Drawing.Point(16, 40)
        Me.rdMndSalaris.Name = "rdMndSalaris"
        Me.rdMndSalaris.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdMndSalaris.Size = New System.Drawing.Size(125, 23)
        Me.rdMndSalaris.TabIndex = 2
        Me.rdMndSalaris.TabStop = True
        Me.rdMndSalaris.Text = "Monthly salary"
        Me.rdMndSalaris.UseVisualStyleBackColor = False
        '
        'rdMndKontant
        '
        Me.rdMndKontant.BackColor = System.Drawing.SystemColors.Control
        Me.rdMndKontant.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdMndKontant.Enabled = False
        Me.rdMndKontant.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdMndKontant.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdMndKontant.Location = New System.Drawing.Point(16, 252)
        Me.rdMndKontant.Name = "rdMndKontant"
        Me.rdMndKontant.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdMndKontant.Size = New System.Drawing.Size(125, 30)
        Me.rdMndKontant.TabIndex = 0
        Me.rdMndKontant.TabStop = True
        Me.rdMndKontant.Text = "Monthly cash"
        Me.rdMndKontant.UseVisualStyleBackColor = False
        Me.rdMndKontant.Visible = False
        '
        'Bet_Wyse
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(641, 426)
        Me.Controls.Add(Me.txtType)
        Me.Controls.Add(Me.frameRekening)
        Me.Controls.Add(Me.frameBank)
        Me.Controls.Add(Me.frameBetalings)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(209, 167)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Bet_Wyse"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payment Method"
        CType(Me.Image7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frameRekening.ResumeLayout(False)
        Me.frameRekening.PerformLayout()
        Me.frameBank.ResumeLayout(False)
        Me.frameBank.PerformLayout()
        Me.frameBetalings.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
End Class