<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmVervaldeVerwysingskommissie
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
    Public WithEvents btnClose As System.Windows.Forms.Button
	Public WithEvents btnOK As System.Windows.Forms.Button
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpVervalDatumVanaf = New System.Windows.Forms.DateTimePicker
        Me.dtpVervalDatumTot = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Location = New System.Drawing.Point(272, 96)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClose.Size = New System.Drawing.Size(85, 25)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOK.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOK.Location = New System.Drawing.Point(168, 96)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOK.Size = New System.Drawing.Size(85, 25)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "Ok"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(297, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Print referral commission expired in period"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(33, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "To"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(41, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "From"
        '
        'dtpVervalDatumVanaf
        '
        Me.dtpVervalDatumVanaf.Checked = False
        Me.dtpVervalDatumVanaf.CustomFormat = "dd/MM/yyyy"
        Me.dtpVervalDatumVanaf.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVervalDatumVanaf.Location = New System.Drawing.Point(55, 45)
        Me.dtpVervalDatumVanaf.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpVervalDatumVanaf.Name = "dtpVervalDatumVanaf"
        Me.dtpVervalDatumVanaf.Size = New System.Drawing.Size(117, 20)
        Me.dtpVervalDatumVanaf.TabIndex = 7
        Me.dtpVervalDatumVanaf.Value = New Date(2011, 7, 21, 0, 0, 0, 0)
        '
        'dtpVervalDatumTot
        '
        Me.dtpVervalDatumTot.Checked = False
        Me.dtpVervalDatumTot.CustomFormat = "dd/MM/yyyy"
        Me.dtpVervalDatumTot.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVervalDatumTot.Location = New System.Drawing.Point(55, 71)
        Me.dtpVervalDatumTot.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpVervalDatumTot.Name = "dtpVervalDatumTot"
        Me.dtpVervalDatumTot.Size = New System.Drawing.Size(117, 20)
        Me.dtpVervalDatumTot.TabIndex = 8
        Me.dtpVervalDatumTot.Value = New Date(2011, 7, 21, 0, 0, 0, 0)
        '
        'frmVervaldeVerwysingskommissie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(371, 135)
        Me.ControlBox = False
        Me.Controls.Add(Me.dtpVervalDatumTot)
        Me.Controls.Add(Me.dtpVervalDatumVanaf)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 30)
        Me.Name = "frmVervaldeVerwysingskommissie"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Poldata - Reports - Referral Commission that expired"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents dtpVervalDatumVanaf As System.Windows.Forms.DateTimePicker
    Public WithEvents dtpVervalDatumTot As System.Windows.Forms.DateTimePicker
#End Region
End Class