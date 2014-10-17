<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class MemoListDetail
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
	Public WithEvents cmbTyd As System.Windows.Forms.ComboBox
    Public WithEvents btnOk As System.Windows.Forms.Button
	Public WithEvents txtDatumVerander As System.Windows.Forms.TextBox
	Public WithEvents txtGebruiker As System.Windows.Forms.TextBox
	Public WithEvents txtBeskrywing As System.Windows.Forms.TextBox
	Public WithEvents chkNB As System.Windows.Forms.CheckBox
	Public WithEvents txtDatum As System.Windows.Forms.TextBox
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents chkRemindMe As System.Windows.Forms.CheckBox
	Public WithEvents lblTyd As System.Windows.Forms.Label
	Public WithEvents lblDatum As System.Windows.Forms.Label
    Public WithEvents Image4 As System.Windows.Forms.PictureBox
    Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MemoListDetail))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Image4 = New System.Windows.Forms.PictureBox()
        Me.cmbTyd = New System.Windows.Forms.ComboBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.txtDatumVerander = New System.Windows.Forms.TextBox()
        Me.txtGebruiker = New System.Windows.Forms.TextBox()
        Me.txtBeskrywing = New System.Windows.Forms.TextBox()
        Me.chkNB = New System.Windows.Forms.CheckBox()
        Me.txtDatum = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.chkRemindMe = New System.Windows.Forms.CheckBox()
        Me.lblTyd = New System.Windows.Forms.Label()
        Me.lblDatum = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTPicker1 = New System.Windows.Forms.DateTimePicker()
        Me.grpMemoDetail = New System.Windows.Forms.GroupBox()
        CType(Me.Image4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMemoDetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'Image4
        '
        Me.Image4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image4.Image = CType(resources.GetObject("Image4.Image"), System.Drawing.Image)
        Me.Image4.Location = New System.Drawing.Point(551, 65)
        Me.Image4.Name = "Image4"
        Me.Image4.Size = New System.Drawing.Size(8, 8)
        Me.Image4.TabIndex = 18
        Me.Image4.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Image4, "Vereiste veld")
        '
        'cmbTyd
        '
        Me.cmbTyd.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTyd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTyd.Enabled = False
        Me.cmbTyd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTyd.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbTyd.Location = New System.Drawing.Point(143, 324)
        Me.cmbTyd.Name = "cmbTyd"
        Me.cmbTyd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbTyd.Size = New System.Drawing.Size(117, 22)
        Me.cmbTyd.TabIndex = 6
        Me.cmbTyd.Text = "Time"
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Location = New System.Drawing.Point(416, 414)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New System.Drawing.Size(85, 25)
        Me.btnOk.TabIndex = 7
        Me.btnOk.Text = "&Ok"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'txtDatumVerander
        '
        Me.txtDatumVerander.AcceptsReturn = True
        Me.txtDatumVerander.BackColor = System.Drawing.SystemColors.Window
        Me.txtDatumVerander.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDatumVerander.Enabled = False
        Me.txtDatumVerander.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDatumVerander.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDatumVerander.Location = New System.Drawing.Point(143, 185)
        Me.txtDatumVerander.MaxLength = 0
        Me.txtDatumVerander.Name = "txtDatumVerander"
        Me.txtDatumVerander.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDatumVerander.Size = New System.Drawing.Size(117, 20)
        Me.txtDatumVerander.TabIndex = 3
        '
        'txtGebruiker
        '
        Me.txtGebruiker.AcceptsReturn = True
        Me.txtGebruiker.BackColor = System.Drawing.SystemColors.Window
        Me.txtGebruiker.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGebruiker.Enabled = False
        Me.txtGebruiker.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGebruiker.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGebruiker.Location = New System.Drawing.Point(143, 220)
        Me.txtGebruiker.MaxLength = 0
        Me.txtGebruiker.Name = "txtGebruiker"
        Me.txtGebruiker.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGebruiker.Size = New System.Drawing.Size(117, 20)
        Me.txtGebruiker.TabIndex = 2
        '
        'txtBeskrywing
        '
        Me.txtBeskrywing.AcceptsReturn = True
        Me.txtBeskrywing.BackColor = System.Drawing.SystemColors.Window
        Me.txtBeskrywing.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBeskrywing.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBeskrywing.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBeskrywing.Location = New System.Drawing.Point(143, 65)
        Me.txtBeskrywing.MaxLength = 250
        Me.txtBeskrywing.Multiline = True
        Me.txtBeskrywing.Name = "txtBeskrywing"
        Me.txtBeskrywing.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBeskrywing.Size = New System.Drawing.Size(402, 65)
        Me.txtBeskrywing.TabIndex = 0
        '
        'chkNB
        '
        Me.chkNB.BackColor = System.Drawing.SystemColors.Control
        Me.chkNB.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkNB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkNB.Location = New System.Drawing.Point(135, 27)
        Me.chkNB.Name = "chkNB"
        Me.chkNB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkNB.Size = New System.Drawing.Size(17, 17)
        Me.chkNB.TabIndex = 14
        Me.chkNB.Text = "Check1"
        Me.chkNB.UseVisualStyleBackColor = False
        '
        'txtDatum
        '
        Me.txtDatum.AcceptsReturn = True
        Me.txtDatum.BackColor = System.Drawing.SystemColors.Window
        Me.txtDatum.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDatum.Enabled = False
        Me.txtDatum.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDatum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDatum.Location = New System.Drawing.Point(143, 149)
        Me.txtDatum.MaxLength = 0
        Me.txtDatum.Name = "txtDatum"
        Me.txtDatum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDatum.Size = New System.Drawing.Size(117, 20)
        Me.txtDatum.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(508, 414)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(85, 25)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'chkRemindMe
        '
        Me.chkRemindMe.BackColor = System.Drawing.SystemColors.Control
        Me.chkRemindMe.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkRemindMe.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkRemindMe.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRemindMe.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkRemindMe.Location = New System.Drawing.Point(19, 248)
        Me.chkRemindMe.Name = "chkRemindMe"
        Me.chkRemindMe.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkRemindMe.Size = New System.Drawing.Size(137, 50)
        Me.chkRemindMe.TabIndex = 4
        Me.chkRemindMe.Text = "Reminder"
        Me.chkRemindMe.UseVisualStyleBackColor = False
        '
        'lblTyd
        '
        Me.lblTyd.BackColor = System.Drawing.SystemColors.Control
        Me.lblTyd.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTyd.Enabled = False
        Me.lblTyd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTyd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTyd.Location = New System.Drawing.Point(19, 329)
        Me.lblTyd.Name = "lblTyd"
        Me.lblTyd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTyd.Size = New System.Drawing.Size(109, 13)
        Me.lblTyd.TabIndex = 17
        Me.lblTyd.Text = "Time"
        '
        'lblDatum
        '
        Me.lblDatum.BackColor = System.Drawing.SystemColors.Control
        Me.lblDatum.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDatum.Enabled = False
        Me.lblDatum.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatum.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDatum.Location = New System.Drawing.Point(19, 296)
        Me.lblDatum.Name = "lblDatum"
        Me.lblDatum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDatum.Size = New System.Drawing.Size(109, 13)
        Me.lblDatum.TabIndex = 16
        Me.lblDatum.Text = "Date"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(19, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "NB"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(19, 189)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(87, 16)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Date changed"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(19, 223)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(141, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "User"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(19, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(141, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Description"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(19, 153)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(87, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Date entered"
        '
        'DTPicker1
        '
        Me.DTPicker1.Enabled = False
        Me.DTPicker1.Location = New System.Drawing.Point(143, 296)
        Me.DTPicker1.Name = "DTPicker1"
        Me.DTPicker1.Size = New System.Drawing.Size(200, 20)
        Me.DTPicker1.TabIndex = 20
        '
        'grpMemoDetail
        '
        Me.grpMemoDetail.Controls.Add(Me.Label5)
        Me.grpMemoDetail.Controls.Add(Me.DTPicker1)
        Me.grpMemoDetail.Controls.Add(Me.chkNB)
        Me.grpMemoDetail.Controls.Add(Me.cmbTyd)
        Me.grpMemoDetail.Controls.Add(Me.txtBeskrywing)
        Me.grpMemoDetail.Controls.Add(Me.Label2)
        Me.grpMemoDetail.Controls.Add(Me.txtDatumVerander)
        Me.grpMemoDetail.Controls.Add(Me.chkRemindMe)
        Me.grpMemoDetail.Controls.Add(Me.lblTyd)
        Me.grpMemoDetail.Controls.Add(Me.txtGebruiker)
        Me.grpMemoDetail.Controls.Add(Me.lblDatum)
        Me.grpMemoDetail.Controls.Add(Me.Image4)
        Me.grpMemoDetail.Controls.Add(Me.txtDatum)
        Me.grpMemoDetail.Controls.Add(Me.Label1)
        Me.grpMemoDetail.Controls.Add(Me.Label3)
        Me.grpMemoDetail.Controls.Add(Me.Label4)
        Me.grpMemoDetail.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpMemoDetail.Location = New System.Drawing.Point(16, 16)
        Me.grpMemoDetail.Name = "grpMemoDetail"
        Me.grpMemoDetail.Size = New System.Drawing.Size(577, 392)
        Me.grpMemoDetail.TabIndex = 21
        Me.grpMemoDetail.TabStop = False
        Me.grpMemoDetail.Text = "Memo"
        '
        'MemoListDetail
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(606, 447)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpMemoDetail)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MemoListDetail"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Poldata - Memo - Detail"
        CType(Me.Image4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMemoDetail.ResumeLayout(False)
        Me.grpMemoDetail.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DTPicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents grpMemoDetail As System.Windows.Forms.GroupBox
#End Region 
End Class