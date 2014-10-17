<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class KanselleerPolis
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
    Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents cmbKansellasieRede As System.Windows.Forms.ComboBox
	Public WithEvents btnOk As System.Windows.Forms.Button
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.cmbKansellasieRede = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpEffekDatum = New System.Windows.Forms.DateTimePicker()
        Me.grpCancelPolicy = New System.Windows.Forms.GroupBox()
        Me.grpCancelPolicy.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(412, 137)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(77, 25)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        Me.ToolTip1.SetToolTip(Me.btnCancel, "Stoor")
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Location = New System.Drawing.Point(326, 137)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New System.Drawing.Size(77, 25)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "&Ok"
        Me.ToolTip1.SetToolTip(Me.btnOk, "Stoor")
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'cmbKansellasieRede
        '
        Me.cmbKansellasieRede.BackColor = System.Drawing.SystemColors.Window
        Me.cmbKansellasieRede.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbKansellasieRede.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbKansellasieRede.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbKansellasieRede.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbKansellasieRede.Location = New System.Drawing.Point(162, 31)
        Me.cmbKansellasieRede.Name = "cmbKansellasieRede"
        Me.cmbKansellasieRede.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbKansellasieRede.Size = New System.Drawing.Size(327, 22)
        Me.cmbKansellasieRede.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(6, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(164, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Effective Cancellation Date"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(6, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(126, 19)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Reason for cancellation"
        '
        'dtpEffekDatum
        '
        Me.dtpEffekDatum.CustomFormat = "dd/MM/yyyy"
        Me.dtpEffekDatum.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEffekDatum.Location = New System.Drawing.Point(162, 70)
        Me.dtpEffekDatum.Name = "dtpEffekDatum"
        Me.dtpEffekDatum.Size = New System.Drawing.Size(99, 20)
        Me.dtpEffekDatum.TabIndex = 5
        '
        'grpCancelPolicy
        '
        Me.grpCancelPolicy.Controls.Add(Me.btnOk)
        Me.grpCancelPolicy.Controls.Add(Me.dtpEffekDatum)
        Me.grpCancelPolicy.Controls.Add(Me.btnCancel)
        Me.grpCancelPolicy.Controls.Add(Me.cmbKansellasieRede)
        Me.grpCancelPolicy.Controls.Add(Me.Label2)
        Me.grpCancelPolicy.Controls.Add(Me.Label1)
        Me.grpCancelPolicy.Location = New System.Drawing.Point(16, 16)
        Me.grpCancelPolicy.Name = "grpCancelPolicy"
        Me.grpCancelPolicy.Size = New System.Drawing.Size(507, 168)
        Me.grpCancelPolicy.TabIndex = 6
        Me.grpCancelPolicy.TabStop = False
        '
        'KanselleerPolis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(535, 204)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpCancelPolicy)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "KanselleerPolis"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Poldata - Cancel Policy"
        Me.grpCancelPolicy.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtpEffekDatum As System.Windows.Forms.DateTimePicker
    Friend WithEvents grpCancelPolicy As System.Windows.Forms.GroupBox
#End Region 
End Class