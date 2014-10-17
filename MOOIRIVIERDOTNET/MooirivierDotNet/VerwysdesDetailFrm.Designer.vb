<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class VerwysdesDetailFrm
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
    Public WithEvents btnOK As System.Windows.Forms.Button
	Public WithEvents btnCancel As System.Windows.Forms.Button
    Public WithEvents lblVoorletter As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents lblVan As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnOK = New System.Windows.Forms.Button()
        Me.cmbDatumEindig = New System.Windows.Forms.ComboBox()
        Me.cmbDatumBegin = New System.Windows.Forms.ComboBox()
        Me.lblVerwysde = New System.Windows.Forms.Label()
        Me.ChkForAdd = New System.Windows.Forms.CheckBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblVoorletter = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblVan = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOK.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOK.Location = New System.Drawing.Point(211, 148)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOK.Size = New System.Drawing.Size(77, 25)
        Me.btnOK.TabIndex = 16
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'cmbDatumEindig
        '
        Me.cmbDatumEindig.FormattingEnabled = True
        Me.cmbDatumEindig.Location = New System.Drawing.Point(95, 116)
        Me.cmbDatumEindig.Name = "cmbDatumEindig"
        Me.cmbDatumEindig.Size = New System.Drawing.Size(105, 22)
        Me.cmbDatumEindig.TabIndex = 24
        '
        'cmbDatumBegin
        '
        Me.cmbDatumBegin.FormattingEnabled = True
        Me.cmbDatumBegin.Location = New System.Drawing.Point(95, 91)
        Me.cmbDatumBegin.Name = "cmbDatumBegin"
        Me.cmbDatumBegin.Size = New System.Drawing.Size(105, 22)
        Me.cmbDatumBegin.TabIndex = 23
        '
        'lblVerwysde
        '
        Me.lblVerwysde.Location = New System.Drawing.Point(95, 16)
        Me.lblVerwysde.Name = "lblVerwysde"
        Me.lblVerwysde.Size = New System.Drawing.Size(105, 17)
        Me.lblVerwysde.TabIndex = 22
        Me.lblVerwysde.Text = " "
        Me.lblVerwysde.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ChkForAdd
        '
        Me.ChkForAdd.AutoSize = True
        Me.ChkForAdd.Location = New System.Drawing.Point(12, 148)
        Me.ChkForAdd.Name = "ChkForAdd"
        Me.ChkForAdd.Size = New System.Drawing.Size(15, 14)
        Me.ChkForAdd.TabIndex = 19
        Me.ChkForAdd.UseVisualStyleBackColor = True
        Me.ChkForAdd.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(297, 148)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(77, 25)
        Me.btnCancel.TabIndex = 15
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'lblVoorletter
        '
        Me.lblVoorletter.BackColor = System.Drawing.SystemColors.Control
        Me.lblVoorletter.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblVoorletter.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVoorletter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblVoorletter.Location = New System.Drawing.Point(95, 68)
        Me.lblVoorletter.Name = "lblVoorletter"
        Me.lblVoorletter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVoorletter.Size = New System.Drawing.Size(105, 17)
        Me.lblVoorletter.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(16, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(57, 17)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Initials"
        '
        'lblVan
        '
        Me.lblVan.BackColor = System.Drawing.SystemColors.Control
        Me.lblVan.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblVan.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVan.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblVan.Location = New System.Drawing.Point(95, 41)
        Me.lblVan.Name = "lblVan"
        Me.lblVan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVan.Size = New System.Drawing.Size(193, 17)
        Me.lblVan.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(81, 17)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Surname"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Policy no"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(69, 15)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "End date"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(16, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(61, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Start date"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(28, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(113, 1)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Label1"
        '
        'VerwysdesDetailFrm
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(386, 184)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbDatumEindig)
        Me.Controls.Add(Me.cmbDatumBegin)
        Me.Controls.Add(Me.lblVerwysde)
        Me.Controls.Add(Me.ChkForAdd)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblVoorletter)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblVan)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "VerwysdesDetailFrm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Poldata - Referral detail"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ChkForAdd As System.Windows.Forms.CheckBox
    Friend WithEvents lblVerwysde As System.Windows.Forms.Label
    Friend WithEvents cmbDatumBegin As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDatumEindig As System.Windows.Forms.ComboBox
#End Region
End Class