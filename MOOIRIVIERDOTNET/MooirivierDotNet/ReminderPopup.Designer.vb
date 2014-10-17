<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class ReminderPopup
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
	Public WithEvents btnOk As System.Windows.Forms.Button
	Public WithEvents chkSoekPolis As System.Windows.Forms.CheckBox
	Public WithEvents chkStaak As System.Windows.Forms.CheckBox
	Public WithEvents cmbSnooze As System.Windows.Forms.ComboBox
	Public WithEvents txtBoodskap As System.Windows.Forms.TextBox
	Public WithEvents btnSnooze As System.Windows.Forms.Button
	Public WithEvents Line4 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line3 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents lblOnderwerp As System.Windows.Forms.Label
	Public WithEvents lblDue As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Line1 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line2 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.Line4 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Line3 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Line1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Line2 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.btnOk = New System.Windows.Forms.Button
        Me.chkSoekPolis = New System.Windows.Forms.CheckBox
        Me.chkStaak = New System.Windows.Forms.CheckBox
        Me.cmbSnooze = New System.Windows.Forms.ComboBox
        Me.txtBoodskap = New System.Windows.Forms.TextBox
        Me.btnSnooze = New System.Windows.Forms.Button
        Me.lblOnderwerp = New System.Windows.Forms.Label
        Me.lblDue = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Line4, Me.Line3, Me.Line1, Me.Line2})
        Me.ShapeContainer1.Size = New System.Drawing.Size(420, 247)
        Me.ShapeContainer1.TabIndex = 9
        Me.ShapeContainer1.TabStop = False
        '
        'Line4
        '
        Me.Line4.BorderColor = System.Drawing.Color.White
        Me.Line4.Name = "Line4"
        Me.Line4.X1 = 8
        Me.Line4.X2 = 408
        Me.Line4.Y1 = 157
        Me.Line4.Y2 = 157
        '
        'Line3
        '
        Me.Line3.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Line3.Name = "Line3"
        Me.Line3.X1 = 8
        Me.Line3.X2 = 408
        Me.Line3.Y1 = 156
        Me.Line3.Y2 = 156
        '
        'Line1
        '
        Me.Line1.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Line1.Name = "Line1"
        Me.Line1.X1 = 44
        Me.Line1.X2 = 408
        Me.Line1.Y1 = 20
        Me.Line1.Y2 = 20
        '
        'Line2
        '
        Me.Line2.BorderColor = System.Drawing.Color.White
        Me.Line2.Name = "Line2"
        Me.Line2.X1 = 44
        Me.Line2.X2 = 408
        Me.Line2.Y1 = 21
        Me.Line2.Y2 = 21
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Location = New System.Drawing.Point(304, 166)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New System.Drawing.Size(105, 21)
        Me.btnOk.TabIndex = 8
        Me.btnOk.Text = "Stop Reminder"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'chkSoekPolis
        '
        Me.chkSoekPolis.BackColor = System.Drawing.SystemColors.Control
        Me.chkSoekPolis.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkSoekPolis.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSoekPolis.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkSoekPolis.Location = New System.Drawing.Point(184, 187)
        Me.chkSoekPolis.Name = "chkSoekPolis"
        Me.chkSoekPolis.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkSoekPolis.Size = New System.Drawing.Size(141, 22)
        Me.chkSoekPolis.TabIndex = 7
        Me.chkSoekPolis.Text = "Search on Policy"
        Me.chkSoekPolis.UseVisualStyleBackColor = False
        Me.chkSoekPolis.Visible = False
        '
        'chkStaak
        '
        Me.chkStaak.BackColor = System.Drawing.SystemColors.Control
        Me.chkStaak.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkStaak.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkStaak.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkStaak.Location = New System.Drawing.Point(184, 168)
        Me.chkStaak.Name = "chkStaak"
        Me.chkStaak.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkStaak.Size = New System.Drawing.Size(145, 20)
        Me.chkStaak.TabIndex = 6
        Me.chkStaak.Text = "Stop Reminder"
        Me.chkStaak.UseVisualStyleBackColor = False
        Me.chkStaak.Visible = False
        '
        'cmbSnooze
        '
        Me.cmbSnooze.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSnooze.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSnooze.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSnooze.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSnooze.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbSnooze.Items.AddRange(New Object() {"5 min", "10 min", "15 min", "30 min", "1 uur", "2 ure", "4 ure", "8 ure", "1 dag", "2 dae", "3 dae", "4 dae", "1 week", "2 weke", "1 maand"})
        Me.cmbSnooze.Location = New System.Drawing.Point(16, 166)
        Me.cmbSnooze.Name = "cmbSnooze"
        Me.cmbSnooze.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbSnooze.Size = New System.Drawing.Size(89, 22)
        Me.cmbSnooze.TabIndex = 5
        '
        'txtBoodskap
        '
        Me.txtBoodskap.AcceptsReturn = True
        Me.txtBoodskap.BackColor = System.Drawing.SystemColors.Control
        Me.txtBoodskap.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBoodskap.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBoodskap.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBoodskap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtBoodskap.Location = New System.Drawing.Point(16, 88)
        Me.txtBoodskap.MaxLength = 0
        Me.txtBoodskap.Multiline = True
        Me.txtBoodskap.Name = "txtBoodskap"
        Me.txtBoodskap.ReadOnly = True
        Me.txtBoodskap.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBoodskap.Size = New System.Drawing.Size(393, 61)
        Me.txtBoodskap.TabIndex = 4
        Me.txtBoodskap.Text = "txtBoodskap" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnSnooze
        '
        Me.btnSnooze.BackColor = System.Drawing.SystemColors.Control
        Me.btnSnooze.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSnooze.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSnooze.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSnooze.Location = New System.Drawing.Point(108, 166)
        Me.btnSnooze.Name = "btnSnooze"
        Me.btnSnooze.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSnooze.Size = New System.Drawing.Size(53, 21)
        Me.btnSnooze.TabIndex = 0
        Me.btnSnooze.Text = "&Snooze"
        Me.btnSnooze.UseVisualStyleBackColor = False
        '
        'lblOnderwerp
        '
        Me.lblOnderwerp.BackColor = System.Drawing.SystemColors.Control
        Me.lblOnderwerp.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblOnderwerp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnderwerp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblOnderwerp.Location = New System.Drawing.Point(16, 64)
        Me.lblOnderwerp.Name = "lblOnderwerp"
        Me.lblOnderwerp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblOnderwerp.Size = New System.Drawing.Size(361, 13)
        Me.lblOnderwerp.TabIndex = 3
        Me.lblOnderwerp.Text = "lblOnderwerp"
        '
        'lblDue
        '
        Me.lblDue.BackColor = System.Drawing.SystemColors.Control
        Me.lblDue.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDue.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDue.Location = New System.Drawing.Point(16, 36)
        Me.lblDue.Name = "lblDue"
        Me.lblDue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDue.Size = New System.Drawing.Size(361, 13)
        Me.lblDue.TabIndex = 2
        Me.lblDue.Text = "lblDue"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(8, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Reminder"
        '
        'ReminderPopup
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(420, 247)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.chkSoekPolis)
        Me.Controls.Add(Me.chkStaak)
        Me.Controls.Add(Me.cmbSnooze)
        Me.Controls.Add(Me.txtBoodskap)
        Me.Controls.Add(Me.btnSnooze)
        Me.Controls.Add(Me.lblOnderwerp)
        Me.Controls.Add(Me.lblDue)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReminderPopup"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Poldata - Reminder"
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class