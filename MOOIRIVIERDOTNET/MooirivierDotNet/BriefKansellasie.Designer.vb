<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class BriefKansellasie
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
	Public WithEvents rdDrukker As System.Windows.Forms.RadioButton
	Public WithEvents rdEpos As System.Windows.Forms.RadioButton
	Public WithEvents Frame3 As System.Windows.Forms.Panel
    Public WithEvents btnClose As System.Windows.Forms.Button
	Public WithEvents btnOk As System.Windows.Forms.Button
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Line8 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line7 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Line2 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line1 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line3 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line4 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents lblStatus As System.Windows.Forms.Label
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.Line8 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Line7 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Line2 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Line1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Line3 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Line4 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Frame3 = New System.Windows.Forms.Panel
        Me.rdDrukker = New System.Windows.Forms.RadioButton
        Me.rdEpos = New System.Windows.Forms.RadioButton
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.dtpLastDayOfCoverage = New System.Windows.Forms.DateTimePicker
        Me.Frame3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Line8, Me.Line7, Me.Line2, Me.Line1, Me.Line3, Me.Line4})
        Me.ShapeContainer1.Size = New System.Drawing.Size(412, 168)
        Me.ShapeContainer1.TabIndex = 10
        Me.ShapeContainer1.TabStop = False
        '
        'Line8
        '
        Me.Line8.BorderColor = System.Drawing.Color.White
        Me.Line8.Name = "Line8"
        Me.Line8.X1 = 12
        Me.Line8.X2 = 400
        Me.Line8.Y1 = 81
        Me.Line8.Y2 = 81
        '
        'Line7
        '
        Me.Line7.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Line7.Name = "Line7"
        Me.Line7.X1 = 8
        Me.Line7.X2 = 400
        Me.Line7.Y1 = 80
        Me.Line7.Y2 = 80
        '
        'Line2
        '
        Me.Line2.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Line2.Name = "Line2"
        Me.Line2.X1 = 12
        Me.Line2.X2 = 400
        Me.Line2.Y1 = 20
        Me.Line2.Y2 = 20
        '
        'Line1
        '
        Me.Line1.BorderColor = System.Drawing.Color.White
        Me.Line1.Name = "Line1"
        Me.Line1.X1 = 12
        Me.Line1.X2 = 400
        Me.Line1.Y1 = 21
        Me.Line1.Y2 = 21
        '
        'Line3
        '
        Me.Line3.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Line3.Name = "Line3"
        Me.Line3.X1 = 12
        Me.Line3.X2 = 400
        Me.Line3.Y1 = 124
        Me.Line3.Y2 = 124
        '
        'Line4
        '
        Me.Line4.BorderColor = System.Drawing.Color.White
        Me.Line4.Name = "Line4"
        Me.Line4.X1 = 12
        Me.Line4.X2 = 400
        Me.Line4.Y1 = 125
        Me.Line4.Y2 = 125
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me.rdDrukker)
        Me.Frame3.Controls.Add(Me.rdEpos)
        Me.Frame3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Frame3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(116, 84)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(229, 29)
        Me.Frame3.TabIndex = 6
        '
        'rdDrukker
        '
        Me.rdDrukker.BackColor = System.Drawing.SystemColors.Control
        Me.rdDrukker.Checked = True
        Me.rdDrukker.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdDrukker.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdDrukker.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdDrukker.Location = New System.Drawing.Point(34, 12)
        Me.rdDrukker.Name = "rdDrukker"
        Me.rdDrukker.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdDrukker.Size = New System.Drawing.Size(77, 17)
        Me.rdDrukker.TabIndex = 8
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
        Me.rdEpos.Location = New System.Drawing.Point(124, 12)
        Me.rdEpos.Name = "rdEpos"
        Me.rdEpos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdEpos.Size = New System.Drawing.Size(89, 17)
        Me.rdEpos.TabIndex = 7
        Me.rdEpos.TabStop = True
        Me.rdEpos.Text = "E-mail"
        Me.rdEpos.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Location = New System.Drawing.Point(316, 132)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClose.Size = New System.Drawing.Size(85, 25)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOk.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Location = New System.Drawing.Point(224, 132)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New System.Drawing.Size(85, 25)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "&Ok"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(8, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Destination"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(141, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Print the letter for"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(12, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(129, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Last day of coverage"
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStatus.Location = New System.Drawing.Point(12, 138)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStatus.Size = New System.Drawing.Size(193, 13)
        Me.lblStatus.TabIndex = 3
        '
        'dtpLastDayOfCoverage
        '
        Me.dtpLastDayOfCoverage.Checked = False
        Me.dtpLastDayOfCoverage.Location = New System.Drawing.Point(147, 40)
        Me.dtpLastDayOfCoverage.Name = "dtpLastDayOfCoverage"
        Me.dtpLastDayOfCoverage.ShowCheckBox = True
        Me.dtpLastDayOfCoverage.Size = New System.Drawing.Size(157, 20)
        Me.dtpLastDayOfCoverage.TabIndex = 39
        Me.dtpLastDayOfCoverage.Value = New Date(2001, 1, 1, 13, 28, 0, 0)
        '
        'BriefKansellasie
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(412, 168)
        Me.ControlBox = False
        Me.Controls.Add(Me.dtpLastDayOfCoverage)
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BriefKansellasie"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Poldata -Letters - Cancellation"
        Me.Frame3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtpLastDayOfCoverage As System.Windows.Forms.DateTimePicker
#End Region
End Class