<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmGeisers
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
	Public WithEvents txtFabrikaat As System.Windows.Forms.TextBox
	Public WithEvents cmbItemTipe As System.Windows.Forms.ComboBox
	Public WithEvents txtModel As System.Windows.Forms.TextBox
	Public WithEvents txtLiter As System.Windows.Forms.TextBox
	Public WithEvents txtPremie As System.Windows.Forms.TextBox
	Public WithEvents txtDatumIn As System.Windows.Forms.TextBox
	Public WithEvents txtDatumWysig As System.Windows.Forms.TextBox
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents btnOk As System.Windows.Forms.Button
	Public WithEvents txtWaarde As System.Windows.Forms.TextBox
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Image3 As System.Windows.Forms.PictureBox
    Public WithEvents lblMake As System.Windows.Forms.Label
    Public WithEvents lblItemType As System.Windows.Forms.Label
    Public WithEvents Image1 As System.Windows.Forms.PictureBox
    Public WithEvents lblModel As System.Windows.Forms.Label
    Public WithEvents lblLiter As System.Windows.Forms.Label
    Public WithEvents lblValue As System.Windows.Forms.Label
    Public WithEvents lblPremium As System.Windows.Forms.Label
    Public WithEvents lblStartDate As System.Windows.Forms.Label
    Public WithEvents lblDateAmended As System.Windows.Forms.Label
    Public WithEvents Label30 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Image2 As System.Windows.Forms.PictureBox
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGeisers))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Image3 = New System.Windows.Forms.PictureBox()
        Me.Image1 = New System.Windows.Forms.PictureBox()
        Me.Image2 = New System.Windows.Forms.PictureBox()
        Me.txtFabrikaat = New System.Windows.Forms.TextBox()
        Me.cmbItemTipe = New System.Windows.Forms.ComboBox()
        Me.txtModel = New System.Windows.Forms.TextBox()
        Me.txtLiter = New System.Windows.Forms.TextBox()
        Me.txtPremie = New System.Windows.Forms.TextBox()
        Me.txtDatumIn = New System.Windows.Forms.TextBox()
        Me.txtDatumWysig = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.txtWaarde = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblMake = New System.Windows.Forms.Label()
        Me.lblItemType = New System.Windows.Forms.Label()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.lblLiter = New System.Windows.Forms.Label()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.lblPremium = New System.Windows.Forms.Label()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.lblDateAmended = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.Image3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Image3
        '
        Me.Image3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image3.Image = CType(resources.GetObject("Image3.Image"), System.Drawing.Image)
        Me.Image3.Location = New System.Drawing.Point(268, 172)
        Me.Image3.Name = "Image3"
        Me.Image3.Size = New System.Drawing.Size(8, 8)
        Me.Image3.TabIndex = 21
        Me.Image3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Image3, "Vereiste veld")
        '
        'Image1
        '
        Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image1.Image = CType(resources.GetObject("Image1.Image"), System.Drawing.Image)
        Me.Image1.Location = New System.Drawing.Point(396, 32)
        Me.Image1.Name = "Image1"
        Me.Image1.Size = New System.Drawing.Size(8, 8)
        Me.Image1.TabIndex = 22
        Me.Image1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Image1, "Vereiste veld")
        '
        'Image2
        '
        Me.Image2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image2.Image = CType(resources.GetObject("Image2.Image"), System.Drawing.Image)
        Me.Image2.Location = New System.Drawing.Point(268, 208)
        Me.Image2.Name = "Image2"
        Me.Image2.Size = New System.Drawing.Size(8, 8)
        Me.Image2.TabIndex = 23
        Me.Image2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Image2, "Vereiste veld")
        '
        'txtFabrikaat
        '
        Me.txtFabrikaat.AcceptsReturn = True
        Me.txtFabrikaat.BackColor = System.Drawing.Color.White
        Me.txtFabrikaat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFabrikaat.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFabrikaat.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFabrikaat.Location = New System.Drawing.Point(196, 60)
        Me.txtFabrikaat.MaxLength = 50
        Me.txtFabrikaat.Name = "txtFabrikaat"
        Me.txtFabrikaat.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFabrikaat.Size = New System.Drawing.Size(193, 20)
        Me.txtFabrikaat.TabIndex = 1
        '
        'cmbItemTipe
        '
        Me.cmbItemTipe.BackColor = System.Drawing.SystemColors.Window
        Me.cmbItemTipe.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbItemTipe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbItemTipe.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbItemTipe.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbItemTipe.Location = New System.Drawing.Point(196, 24)
        Me.cmbItemTipe.Name = "cmbItemTipe"
        Me.cmbItemTipe.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbItemTipe.Size = New System.Drawing.Size(193, 22)
        Me.cmbItemTipe.TabIndex = 0
        '
        'txtModel
        '
        Me.txtModel.AcceptsReturn = True
        Me.txtModel.BackColor = System.Drawing.Color.White
        Me.txtModel.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtModel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModel.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtModel.Location = New System.Drawing.Point(196, 96)
        Me.txtModel.MaxLength = 50
        Me.txtModel.Name = "txtModel"
        Me.txtModel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtModel.Size = New System.Drawing.Size(193, 20)
        Me.txtModel.TabIndex = 2
        '
        'txtLiter
        '
        Me.txtLiter.AcceptsReturn = True
        Me.txtLiter.BackColor = System.Drawing.Color.White
        Me.txtLiter.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLiter.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLiter.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLiter.Location = New System.Drawing.Point(196, 128)
        Me.txtLiter.MaxLength = 100
        Me.txtLiter.Name = "txtLiter"
        Me.txtLiter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLiter.Size = New System.Drawing.Size(33, 20)
        Me.txtLiter.TabIndex = 3
        '
        'txtPremie
        '
        Me.txtPremie.AcceptsReturn = True
        Me.txtPremie.BackColor = System.Drawing.Color.White
        Me.txtPremie.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPremie.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPremie.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPremie.Location = New System.Drawing.Point(196, 200)
        Me.txtPremie.MaxLength = 6
        Me.txtPremie.Name = "txtPremie"
        Me.txtPremie.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPremie.Size = New System.Drawing.Size(65, 20)
        Me.txtPremie.TabIndex = 5
        '
        'txtDatumIn
        '
        Me.txtDatumIn.AcceptsReturn = True
        Me.txtDatumIn.BackColor = System.Drawing.Color.White
        Me.txtDatumIn.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDatumIn.Enabled = False
        Me.txtDatumIn.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDatumIn.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDatumIn.Location = New System.Drawing.Point(196, 236)
        Me.txtDatumIn.MaxLength = 15
        Me.txtDatumIn.Name = "txtDatumIn"
        Me.txtDatumIn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDatumIn.Size = New System.Drawing.Size(89, 20)
        Me.txtDatumIn.TabIndex = 8
        '
        'txtDatumWysig
        '
        Me.txtDatumWysig.AcceptsReturn = True
        Me.txtDatumWysig.BackColor = System.Drawing.Color.White
        Me.txtDatumWysig.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDatumWysig.Enabled = False
        Me.txtDatumWysig.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDatumWysig.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDatumWysig.Location = New System.Drawing.Point(196, 272)
        Me.txtDatumWysig.MaxLength = 15
        Me.txtDatumWysig.Name = "txtDatumWysig"
        Me.txtDatumWysig.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDatumWysig.Size = New System.Drawing.Size(89, 20)
        Me.txtDatumWysig.TabIndex = 10
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(304, 308)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(85, 25)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOk.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Location = New System.Drawing.Point(211, 308)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New System.Drawing.Size(85, 25)
        Me.btnOk.TabIndex = 6
        Me.btnOk.Text = "&Ok"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'txtWaarde
        '
        Me.txtWaarde.AcceptsReturn = True
        Me.txtWaarde.BackColor = System.Drawing.Color.White
        Me.txtWaarde.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtWaarde.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWaarde.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtWaarde.Location = New System.Drawing.Point(196, 164)
        Me.txtWaarde.MaxLength = 6
        Me.txtWaarde.Name = "txtWaarde"
        Me.txtWaarde.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtWaarde.Size = New System.Drawing.Size(65, 20)
        Me.txtWaarde.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(232, 132)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(9, 14)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "l"
        '
        'lblMake
        '
        Me.lblMake.AutoSize = True
        Me.lblMake.BackColor = System.Drawing.SystemColors.Control
        Me.lblMake.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMake.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMake.ForeColor = System.Drawing.Color.Black
        Me.lblMake.Location = New System.Drawing.Point(16, 64)
        Me.lblMake.Name = "lblMake"
        Me.lblMake.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMake.Size = New System.Drawing.Size(32, 14)
        Me.lblMake.TabIndex = 19
        Me.lblMake.Text = "Make"
        '
        'lblItemType
        '
        Me.lblItemType.AutoSize = True
        Me.lblItemType.BackColor = System.Drawing.SystemColors.Control
        Me.lblItemType.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblItemType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemType.ForeColor = System.Drawing.Color.Black
        Me.lblItemType.Location = New System.Drawing.Point(16, 28)
        Me.lblItemType.Name = "lblItemType"
        Me.lblItemType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblItemType.Size = New System.Drawing.Size(52, 14)
        Me.lblItemType.TabIndex = 18
        Me.lblItemType.Text = "Item Type"
        '
        'lblModel
        '
        Me.lblModel.AutoSize = True
        Me.lblModel.BackColor = System.Drawing.SystemColors.Control
        Me.lblModel.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblModel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModel.ForeColor = System.Drawing.Color.Black
        Me.lblModel.Location = New System.Drawing.Point(16, 100)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblModel.Size = New System.Drawing.Size(35, 14)
        Me.lblModel.TabIndex = 17
        Me.lblModel.Text = "Model"
        '
        'lblLiter
        '
        Me.lblLiter.AutoSize = True
        Me.lblLiter.BackColor = System.Drawing.SystemColors.Control
        Me.lblLiter.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLiter.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLiter.ForeColor = System.Drawing.Color.Black
        Me.lblLiter.Location = New System.Drawing.Point(16, 132)
        Me.lblLiter.Name = "lblLiter"
        Me.lblLiter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLiter.Size = New System.Drawing.Size(28, 14)
        Me.lblLiter.TabIndex = 16
        Me.lblLiter.Text = "Liter"
        '
        'lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.BackColor = System.Drawing.SystemColors.Control
        Me.lblValue.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblValue.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValue.ForeColor = System.Drawing.Color.Black
        Me.lblValue.Location = New System.Drawing.Point(16, 168)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblValue.Size = New System.Drawing.Size(34, 14)
        Me.lblValue.TabIndex = 15
        Me.lblValue.Text = "Value"
        '
        'lblPremium
        '
        Me.lblPremium.AutoSize = True
        Me.lblPremium.BackColor = System.Drawing.SystemColors.Control
        Me.lblPremium.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPremium.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPremium.ForeColor = System.Drawing.Color.Black
        Me.lblPremium.Location = New System.Drawing.Point(16, 204)
        Me.lblPremium.Name = "lblPremium"
        Me.lblPremium.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPremium.Size = New System.Drawing.Size(47, 14)
        Me.lblPremium.TabIndex = 14
        Me.lblPremium.Text = "Premium"
        '
        'lblStartDate
        '
        Me.lblStartDate.AutoSize = True
        Me.lblStartDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblStartDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStartDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartDate.ForeColor = System.Drawing.Color.Black
        Me.lblStartDate.Location = New System.Drawing.Point(16, 240)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStartDate.Size = New System.Drawing.Size(55, 14)
        Me.lblStartDate.TabIndex = 13
        Me.lblStartDate.Text = "Start Date"
        '
        'lblDateAmended
        '
        Me.lblDateAmended.AutoSize = True
        Me.lblDateAmended.BackColor = System.Drawing.SystemColors.Control
        Me.lblDateAmended.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDateAmended.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateAmended.ForeColor = System.Drawing.Color.Black
        Me.lblDateAmended.Location = New System.Drawing.Point(16, 276)
        Me.lblDateAmended.Name = "lblDateAmended"
        Me.lblDateAmended.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDateAmended.Size = New System.Drawing.Size(77, 14)
        Me.lblDateAmended.TabIndex = 12
        Me.lblDateAmended.Text = "Date Amended"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.SystemColors.Control
        Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label30.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(184, 168)
        Me.Label30.Name = "Label30"
        Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label30.Size = New System.Drawing.Size(14, 14)
        Me.Label30.TabIndex = 11
        Me.Label30.Text = "R"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(184, 204)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(14, 14)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "R"
        '
        'frmGeisers
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(411, 344)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtFabrikaat)
        Me.Controls.Add(Me.cmbItemTipe)
        Me.Controls.Add(Me.txtModel)
        Me.Controls.Add(Me.txtLiter)
        Me.Controls.Add(Me.txtPremie)
        Me.Controls.Add(Me.txtDatumIn)
        Me.Controls.Add(Me.txtDatumWysig)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.txtWaarde)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Image3)
        Me.Controls.Add(Me.lblMake)
        Me.Controls.Add(Me.lblItemType)
        Me.Controls.Add(Me.Image1)
        Me.Controls.Add(Me.lblModel)
        Me.Controls.Add(Me.lblLiter)
        Me.Controls.Add(Me.lblValue)
        Me.Controls.Add(Me.lblPremium)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.lblDateAmended)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Image2)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGeisers"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "    Geysers"
        CType(Me.Image3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class