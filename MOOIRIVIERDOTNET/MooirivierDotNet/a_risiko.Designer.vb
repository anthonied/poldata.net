<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class A_Risiko
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
	Public WithEvents Kode As System.Windows.Forms.ComboBox
	Public WithEvents selkontrakmet As System.Windows.Forms.TextBox
	Public WithEvents Selnommer As System.Windows.Forms.TextBox
	Public WithEvents Seldatumaangekoop As System.Windows.Forms.TextBox
    Public WithEvents lblDMY As System.Windows.Forms.Label
    Public WithEvents lblCellContract As System.Windows.Forms.Label
    Public WithEvents lblCellNumber As System.Windows.Forms.Label
    Public WithEvents lblDatePurchased As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents btnRedigeer As System.Windows.Forms.Button
    Public WithEvents btnVoegby As System.Windows.Forms.Button
    Public WithEvents btnCancel As System.Windows.Forms.Button
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents Premie As System.Windows.Forms.TextBox
    Public WithEvents Beskruiwing As System.Windows.Forms.TextBox
    Public WithEvents Dekking As System.Windows.Forms.TextBox
    Public WithEvents Serienommer As System.Windows.Forms.TextBox
    Public WithEvents arnplaat As System.Windows.Forms.TextBox
    Public WithEvents LblWhereApplicable2 As System.Windows.Forms.Label
    Public WithEvents lblWhereApplicable As System.Windows.Forms.Label
    Public WithEvents Image1 As System.Windows.Forms.PictureBox
    Public WithEvents Image4 As System.Windows.Forms.PictureBox
    Public WithEvents Image2 As System.Windows.Forms.PictureBox
    Public WithEvents Image3 As System.Windows.Forms.PictureBox
    Public WithEvents lblDescription As System.Windows.Forms.Label
    Public WithEvents lblValue As System.Windows.Forms.Label
    Public WithEvents lblPremium As System.Windows.Forms.Label
    Public WithEvents lblRiskType As System.Windows.Forms.Label
    Public WithEvents lblSerialNumber As System.Windows.Forms.Label
    Public WithEvents lblRegNumber As System.Windows.Forms.Label
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents Label8 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(A_Risiko))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Image1 = New System.Windows.Forms.PictureBox()
        Me.Image4 = New System.Windows.Forms.PictureBox()
        Me.Image2 = New System.Windows.Forms.PictureBox()
        Me.Image3 = New System.Windows.Forms.PictureBox()
        Me.Kode = New System.Windows.Forms.ComboBox()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.selkontrakmet = New System.Windows.Forms.TextBox()
        Me.Selnommer = New System.Windows.Forms.TextBox()
        Me.Seldatumaangekoop = New System.Windows.Forms.TextBox()
        Me.lblDMY = New System.Windows.Forms.Label()
        Me.lblCellContract = New System.Windows.Forms.Label()
        Me.lblCellNumber = New System.Windows.Forms.Label()
        Me.lblDatePurchased = New System.Windows.Forms.Label()
        Me.btnRedigeer = New System.Windows.Forms.Button()
        Me.btnVoegby = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.Premie = New System.Windows.Forms.TextBox()
        Me.Beskruiwing = New System.Windows.Forms.TextBox()
        Me.Dekking = New System.Windows.Forms.TextBox()
        Me.Serienommer = New System.Windows.Forms.TextBox()
        Me.arnplaat = New System.Windows.Forms.TextBox()
        Me.LblWhereApplicable2 = New System.Windows.Forms.Label()
        Me.lblWhereApplicable = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.lblPremium = New System.Windows.Forms.Label()
        Me.lblRiskType = New System.Windows.Forms.Label()
        Me.lblSerialNumber = New System.Windows.Forms.Label()
        Me.lblRegNumber = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame1.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Image1
        '
        Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image1.Image = CType(resources.GetObject("Image1.Image"), System.Drawing.Image)
        Me.Image1.Location = New System.Drawing.Point(540, 61)
        Me.Image1.Name = "Image1"
        Me.Image1.Size = New System.Drawing.Size(8, 8)
        Me.Image1.TabIndex = 29
        Me.Image1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Image1, "Vereiste veld")
        '
        'Image4
        '
        Me.Image4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image4.Image = CType(resources.GetObject("Image4.Image"), System.Drawing.Image)
        Me.Image4.Location = New System.Drawing.Point(264, 115)
        Me.Image4.Name = "Image4"
        Me.Image4.Size = New System.Drawing.Size(8, 8)
        Me.Image4.TabIndex = 30
        Me.Image4.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Image4, "Vereiste veld")
        '
        'Image2
        '
        Me.Image2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image2.Image = CType(resources.GetObject("Image2.Image"), System.Drawing.Image)
        Me.Image2.Location = New System.Drawing.Point(264, 89)
        Me.Image2.Name = "Image2"
        Me.Image2.Size = New System.Drawing.Size(8, 8)
        Me.Image2.TabIndex = 31
        Me.Image2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Image2, "Vereiste veld")
        '
        'Image3
        '
        Me.Image3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image3.Image = CType(resources.GetObject("Image3.Image"), System.Drawing.Image)
        Me.Image3.Location = New System.Drawing.Point(540, 31)
        Me.Image3.Name = "Image3"
        Me.Image3.Size = New System.Drawing.Size(8, 8)
        Me.Image3.TabIndex = 32
        Me.Image3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Image3, "Vereiste veld")
        '
        'Kode
        '
        Me.Kode.BackColor = System.Drawing.Color.White
        Me.Kode.Cursor = System.Windows.Forms.Cursors.Default
        Me.Kode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Kode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Kode.ForeColor = System.Drawing.Color.Black
        Me.Kode.Location = New System.Drawing.Point(191, 90)
        Me.Kode.Name = "Kode"
        Me.Kode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Kode.Size = New System.Drawing.Size(357, 22)
        Me.Kode.TabIndex = 1
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.selkontrakmet)
        Me.Frame1.Controls.Add(Me.Selnommer)
        Me.Frame1.Controls.Add(Me.Seldatumaangekoop)
        Me.Frame1.Controls.Add(Me.lblDMY)
        Me.Frame1.Controls.Add(Me.lblCellContract)
        Me.Frame1.Controls.Add(Me.lblCellNumber)
        Me.Frame1.Controls.Add(Me.lblDatePurchased)
        Me.Frame1.Enabled = False
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(20, 260)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(557, 129)
        Me.Frame1.TabIndex = 15
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Cellphone detail"
        '
        'selkontrakmet
        '
        Me.selkontrakmet.AcceptsReturn = True
        Me.selkontrakmet.BackColor = System.Drawing.Color.White
        Me.selkontrakmet.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.selkontrakmet.Enabled = False
        Me.selkontrakmet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selkontrakmet.ForeColor = System.Drawing.SystemColors.WindowText
        Me.selkontrakmet.Location = New System.Drawing.Point(176, 28)
        Me.selkontrakmet.MaxLength = 0
        Me.selkontrakmet.Name = "selkontrakmet"
        Me.selkontrakmet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.selkontrakmet.Size = New System.Drawing.Size(201, 20)
        Me.selkontrakmet.TabIndex = 6
        '
        'Selnommer
        '
        Me.Selnommer.AcceptsReturn = True
        Me.Selnommer.BackColor = System.Drawing.Color.White
        Me.Selnommer.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Selnommer.Enabled = False
        Me.Selnommer.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Selnommer.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Selnommer.Location = New System.Drawing.Point(176, 60)
        Me.Selnommer.MaxLength = 0
        Me.Selnommer.Name = "Selnommer"
        Me.Selnommer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Selnommer.Size = New System.Drawing.Size(137, 20)
        Me.Selnommer.TabIndex = 7
        '
        'Seldatumaangekoop
        '
        Me.Seldatumaangekoop.AcceptsReturn = True
        Me.Seldatumaangekoop.BackColor = System.Drawing.Color.White
        Me.Seldatumaangekoop.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Seldatumaangekoop.Enabled = False
        Me.Seldatumaangekoop.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Seldatumaangekoop.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Seldatumaangekoop.Location = New System.Drawing.Point(176, 92)
        Me.Seldatumaangekoop.MaxLength = 0
        Me.Seldatumaangekoop.Name = "Seldatumaangekoop"
        Me.Seldatumaangekoop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Seldatumaangekoop.Size = New System.Drawing.Size(113, 20)
        Me.Seldatumaangekoop.TabIndex = 8
        '
        'lblDMY
        '
        Me.lblDMY.BackColor = System.Drawing.SystemColors.Control
        Me.lblDMY.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDMY.Enabled = False
        Me.lblDMY.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDMY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDMY.Location = New System.Drawing.Point(296, 96)
        Me.lblDMY.Name = "lblDMY"
        Me.lblDMY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDMY.Size = New System.Drawing.Size(81, 13)
        Me.lblDMY.TabIndex = 26
        Me.lblDMY.Text = "(dd/mm/yyyy)"
        '
        'lblCellContract
        '
        Me.lblCellContract.BackColor = System.Drawing.Color.Transparent
        Me.lblCellContract.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCellContract.Enabled = False
        Me.lblCellContract.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCellContract.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCellContract.Location = New System.Drawing.Point(16, 32)
        Me.lblCellContract.Name = "lblCellContract"
        Me.lblCellContract.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCellContract.Size = New System.Drawing.Size(157, 13)
        Me.lblCellContract.TabIndex = 18
        Me.lblCellContract.Text = "Contract with"
        '
        'lblCellNumber
        '
        Me.lblCellNumber.BackColor = System.Drawing.Color.Transparent
        Me.lblCellNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCellNumber.Enabled = False
        Me.lblCellNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCellNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCellNumber.Location = New System.Drawing.Point(16, 64)
        Me.lblCellNumber.Name = "lblCellNumber"
        Me.lblCellNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCellNumber.Size = New System.Drawing.Size(161, 13)
        Me.lblCellNumber.TabIndex = 17
        Me.lblCellNumber.Text = "Cellphone number"
        '
        'lblDatePurchased
        '
        Me.lblDatePurchased.BackColor = System.Drawing.Color.Transparent
        Me.lblDatePurchased.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDatePurchased.Enabled = False
        Me.lblDatePurchased.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatePurchased.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDatePurchased.Location = New System.Drawing.Point(16, 96)
        Me.lblDatePurchased.Name = "lblDatePurchased"
        Me.lblDatePurchased.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDatePurchased.Size = New System.Drawing.Size(173, 13)
        Me.lblDatePurchased.TabIndex = 16
        Me.lblDatePurchased.Text = "Date purchased"
        '
        'btnRedigeer
        '
        Me.btnRedigeer.BackColor = System.Drawing.SystemColors.Control
        Me.btnRedigeer.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnRedigeer.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRedigeer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRedigeer.Location = New System.Drawing.Point(397, 412)
        Me.btnRedigeer.Name = "btnRedigeer"
        Me.btnRedigeer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnRedigeer.Size = New System.Drawing.Size(85, 25)
        Me.btnRedigeer.TabIndex = 11
        Me.btnRedigeer.Text = "Ok"
        Me.btnRedigeer.UseVisualStyleBackColor = False
        '
        'btnVoegby
        '
        Me.btnVoegby.BackColor = System.Drawing.SystemColors.Control
        Me.btnVoegby.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnVoegby.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoegby.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnVoegby.Location = New System.Drawing.Point(302, 412)
        Me.btnVoegby.Name = "btnVoegby"
        Me.btnVoegby.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnVoegby.Size = New System.Drawing.Size(85, 25)
        Me.btnVoegby.TabIndex = 10
        Me.btnVoegby.Text = "Ok"
        Me.btnVoegby.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(491, 412)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(85, 25)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(20, 412)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(85, 25)
        Me.Command1.TabIndex = 9
        Me.Command1.Text = "Ok"
        Me.Command1.UseVisualStyleBackColor = False
        Me.Command1.Visible = False
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.Premie)
        Me.Frame2.Controls.Add(Me.Beskruiwing)
        Me.Frame2.Controls.Add(Me.Dekking)
        Me.Frame2.Controls.Add(Me.Serienommer)
        Me.Frame2.Controls.Add(Me.arnplaat)
        Me.Frame2.Controls.Add(Me.LblWhereApplicable2)
        Me.Frame2.Controls.Add(Me.lblWhereApplicable)
        Me.Frame2.Controls.Add(Me.Image1)
        Me.Frame2.Controls.Add(Me.Image4)
        Me.Frame2.Controls.Add(Me.Image2)
        Me.Frame2.Controls.Add(Me.Image3)
        Me.Frame2.Controls.Add(Me.lblDescription)
        Me.Frame2.Controls.Add(Me.lblValue)
        Me.Frame2.Controls.Add(Me.lblPremium)
        Me.Frame2.Controls.Add(Me.lblRiskType)
        Me.Frame2.Controls.Add(Me.lblSerialNumber)
        Me.Frame2.Controls.Add(Me.lblRegNumber)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(16, 16)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(557, 196)
        Me.Frame2.TabIndex = 19
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "All risk detail"
        '
        'Premie
        '
        Me.Premie.AcceptsReturn = True
        Me.Premie.BackColor = System.Drawing.Color.White
        Me.Premie.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Premie.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Premie.ForeColor = System.Drawing.Color.Black
        Me.Premie.Location = New System.Drawing.Point(176, 105)
        Me.Premie.MaxLength = 9
        Me.Premie.Name = "Premie"
        Me.Premie.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Premie.Size = New System.Drawing.Size(81, 20)
        Me.Premie.TabIndex = 3
        Me.Premie.Text = "0.00"
        '
        'Beskruiwing
        '
        Me.Beskruiwing.AcceptsReturn = True
        Me.Beskruiwing.BackColor = System.Drawing.Color.White
        Me.Beskruiwing.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Beskruiwing.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Beskruiwing.ForeColor = System.Drawing.Color.Black
        Me.Beskruiwing.Location = New System.Drawing.Point(176, 20)
        Me.Beskruiwing.MaxLength = 80
        Me.Beskruiwing.Name = "Beskruiwing"
        Me.Beskruiwing.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Beskruiwing.Size = New System.Drawing.Size(357, 20)
        Me.Beskruiwing.TabIndex = 0
        '
        'Dekking
        '
        Me.Dekking.AcceptsReturn = True
        Me.Dekking.BackColor = System.Drawing.Color.White
        Me.Dekking.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Dekking.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dekking.ForeColor = System.Drawing.Color.Black
        Me.Dekking.Location = New System.Drawing.Point(176, 78)
        Me.Dekking.MaxLength = 6
        Me.Dekking.Name = "Dekking"
        Me.Dekking.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Dekking.Size = New System.Drawing.Size(81, 20)
        Me.Dekking.TabIndex = 2
        Me.Dekking.Text = "0"
        '
        'Serienommer
        '
        Me.Serienommer.AcceptsReturn = True
        Me.Serienommer.BackColor = System.Drawing.Color.White
        Me.Serienommer.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Serienommer.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serienommer.ForeColor = System.Drawing.Color.Black
        Me.Serienommer.Location = New System.Drawing.Point(176, 160)
        Me.Serienommer.MaxLength = 0
        Me.Serienommer.Name = "Serienommer"
        Me.Serienommer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Serienommer.Size = New System.Drawing.Size(169, 20)
        Me.Serienommer.TabIndex = 5
        '
        'arnplaat
        '
        Me.arnplaat.AcceptsReturn = True
        Me.arnplaat.BackColor = System.Drawing.Color.White
        Me.arnplaat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.arnplaat.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.arnplaat.ForeColor = System.Drawing.Color.Black
        Me.arnplaat.Location = New System.Drawing.Point(176, 133)
        Me.arnplaat.MaxLength = 0
        Me.arnplaat.Name = "arnplaat"
        Me.arnplaat.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.arnplaat.Size = New System.Drawing.Size(97, 20)
        Me.arnplaat.TabIndex = 4
        '
        'LblWhereApplicable2
        '
        Me.LblWhereApplicable2.BackColor = System.Drawing.Color.Transparent
        Me.LblWhereApplicable2.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblWhereApplicable2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWhereApplicable2.ForeColor = System.Drawing.Color.Black
        Me.LblWhereApplicable2.Location = New System.Drawing.Point(348, 164)
        Me.LblWhereApplicable2.Name = "LblWhereApplicable2"
        Me.LblWhereApplicable2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblWhereApplicable2.Size = New System.Drawing.Size(125, 13)
        Me.LblWhereApplicable2.TabIndex = 28
        Me.LblWhereApplicable2.Text = "(where applicable)"
        '
        'lblWhereApplicable
        '
        Me.lblWhereApplicable.BackColor = System.Drawing.Color.Transparent
        Me.lblWhereApplicable.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblWhereApplicable.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWhereApplicable.ForeColor = System.Drawing.Color.Black
        Me.lblWhereApplicable.Location = New System.Drawing.Point(276, 136)
        Me.lblWhereApplicable.Name = "lblWhereApplicable"
        Me.lblWhereApplicable.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblWhereApplicable.Size = New System.Drawing.Size(133, 13)
        Me.lblWhereApplicable.TabIndex = 27
        Me.lblWhereApplicable.Text = "(where applicable)"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblDescription.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.ForeColor = System.Drawing.Color.Black
        Me.lblDescription.Location = New System.Drawing.Point(16, 28)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDescription.Size = New System.Drawing.Size(61, 14)
        Me.lblDescription.TabIndex = 25
        Me.lblDescription.Text = "Description"
        '
        'lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.BackColor = System.Drawing.Color.Transparent
        Me.lblValue.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblValue.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValue.ForeColor = System.Drawing.Color.Black
        Me.lblValue.Location = New System.Drawing.Point(16, 82)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblValue.Size = New System.Drawing.Size(34, 14)
        Me.lblValue.TabIndex = 24
        Me.lblValue.Text = "Value"
        '
        'lblPremium
        '
        Me.lblPremium.BackColor = System.Drawing.Color.Transparent
        Me.lblPremium.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPremium.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPremium.ForeColor = System.Drawing.Color.Black
        Me.lblPremium.Location = New System.Drawing.Point(16, 109)
        Me.lblPremium.Name = "lblPremium"
        Me.lblPremium.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPremium.Size = New System.Drawing.Size(167, 13)
        Me.lblPremium.TabIndex = 23
        Me.lblPremium.Text = "Premium"
        '
        'lblRiskType
        '
        Me.lblRiskType.AutoSize = True
        Me.lblRiskType.BackColor = System.Drawing.Color.Transparent
        Me.lblRiskType.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblRiskType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRiskType.ForeColor = System.Drawing.Color.Black
        Me.lblRiskType.Location = New System.Drawing.Point(16, 56)
        Me.lblRiskType.Name = "lblRiskType"
        Me.lblRiskType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblRiskType.Size = New System.Drawing.Size(63, 14)
        Me.lblRiskType.TabIndex = 22
        Me.lblRiskType.Text = "All risk type"
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.BackColor = System.Drawing.Color.Transparent
        Me.lblSerialNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSerialNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerialNumber.ForeColor = System.Drawing.Color.Black
        Me.lblSerialNumber.Location = New System.Drawing.Point(16, 164)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSerialNumber.Size = New System.Drawing.Size(153, 13)
        Me.lblSerialNumber.TabIndex = 21
        Me.lblSerialNumber.Text = "Serial number"
        '
        'lblRegNumber
        '
        Me.lblRegNumber.BackColor = System.Drawing.Color.Transparent
        Me.lblRegNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblRegNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegNumber.ForeColor = System.Drawing.Color.Black
        Me.lblRegNumber.Location = New System.Drawing.Point(16, 136)
        Me.lblRegNumber.Name = "lblRegNumber"
        Me.lblRegNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblRegNumber.Size = New System.Drawing.Size(169, 13)
        Me.lblRegNumber.TabIndex = 20
        Me.lblRegNumber.Text = "Motor registration number"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(16, 392)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(436, 17)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "If the insured item is a car radio ~ Please fill in the registration number for t" & _
    "he vehicle"
        Me.Label8.Visible = False
        '
        'A_Risiko
        '
        Me.AcceptButton = Me.Command1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(598, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.Kode)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.btnRedigeer)
        Me.Controls.Add(Me.btnVoegby)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Label8)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(33, 59)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "A_Risiko"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Poldata"
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class