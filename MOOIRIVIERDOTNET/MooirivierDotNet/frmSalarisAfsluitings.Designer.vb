<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSalarisAfsluitings
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
	Public CommonDialog1Open As System.Windows.Forms.OpenFileDialog
	Public CommonDialog1Save As System.Windows.Forms.SaveFileDialog
	Public CommonDialog1Font As System.Windows.Forms.FontDialog
	Public CommonDialog1Color As System.Windows.Forms.ColorDialog
	Public CommonDialog1Print As System.Windows.Forms.PrintDialog
    Public WithEvents optFinaleLopie As System.Windows.Forms.RadioButton
	Public WithEvents optToetslopie As System.Windows.Forms.RadioButton
	Public WithEvents cmbArea As System.Windows.Forms.ComboBox
	Public WithEvents cmbSort As System.Windows.Forms.ComboBox
	Public WithEvents btnOk As System.Windows.Forms.Button
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents Line2 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line4 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents lblHeading As System.Windows.Forms.Label
	Public WithEvents Line1 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents lblProgress As System.Windows.Forms.Label
	Public WithEvents Line3 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.Line2 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Line4 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Line1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Line3 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.CommonDialog1Open = New System.Windows.Forms.OpenFileDialog
        Me.CommonDialog1Save = New System.Windows.Forms.SaveFileDialog
        Me.CommonDialog1Font = New System.Windows.Forms.FontDialog
        Me.CommonDialog1Color = New System.Windows.Forms.ColorDialog
        Me.CommonDialog1Print = New System.Windows.Forms.PrintDialog
        Me.optFinaleLopie = New System.Windows.Forms.RadioButton
        Me.optToetslopie = New System.Windows.Forms.RadioButton
        Me.cmbArea = New System.Windows.Forms.ComboBox
        Me.cmbSort = New System.Windows.Forms.ComboBox
        Me.btnOk = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblHeading = New System.Windows.Forms.Label
        Me.lblProgress = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Line2, Me.Line4, Me.Line1, Me.Line3})
        Me.ShapeContainer1.Size = New System.Drawing.Size(479, 239)
        Me.ShapeContainer1.TabIndex = 12
        Me.ShapeContainer1.TabStop = False
        '
        'Line2
        '
        Me.Line2.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Line2.Name = "Line2"
        Me.Line2.X1 = 56
        Me.Line2.X2 = 464
        Me.Line2.Y1 = 76
        Me.Line2.Y2 = 76
        '
        'Line4
        '
        Me.Line4.BorderColor = System.Drawing.Color.White
        Me.Line4.Name = "Line4"
        Me.Line4.X1 = 52
        Me.Line4.X2 = 464
        Me.Line4.Y1 = 77
        Me.Line4.Y2 = 77
        '
        'Line1
        '
        Me.Line1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line1.Name = "Line1"
        Me.Line1.X1 = 20
        Me.Line1.X2 = 456
        Me.Line1.Y1 = 192
        Me.Line1.Y2 = 192
        '
        'Line3
        '
        Me.Line3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line3.Name = "Line3"
        Me.Line3.X1 = 64
        Me.Line3.X2 = 464
        Me.Line3.Y1 = 24
        Me.Line3.Y2 = 24
        '
        'optFinaleLopie
        '
        Me.optFinaleLopie.BackColor = System.Drawing.SystemColors.Control
        Me.optFinaleLopie.Cursor = System.Windows.Forms.Cursors.Default
        Me.optFinaleLopie.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optFinaleLopie.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optFinaleLopie.Location = New System.Drawing.Point(232, 48)
        Me.optFinaleLopie.Name = "optFinaleLopie"
        Me.optFinaleLopie.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optFinaleLopie.Size = New System.Drawing.Size(169, 17)
        Me.optFinaleLopie.TabIndex = 11
        Me.optFinaleLopie.TabStop = True
        Me.optFinaleLopie.Text = "Final run"
        Me.optFinaleLopie.UseVisualStyleBackColor = False
        '
        'optToetslopie
        '
        Me.optToetslopie.BackColor = System.Drawing.SystemColors.Control
        Me.optToetslopie.Cursor = System.Windows.Forms.Cursors.Default
        Me.optToetslopie.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optToetslopie.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optToetslopie.Location = New System.Drawing.Point(48, 48)
        Me.optToetslopie.Name = "optToetslopie"
        Me.optToetslopie.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optToetslopie.Size = New System.Drawing.Size(129, 17)
        Me.optToetslopie.TabIndex = 10
        Me.optToetslopie.TabStop = True
        Me.optToetslopie.Text = "Test run"
        Me.optToetslopie.UseVisualStyleBackColor = False
        '
        'cmbArea
        '
        Me.cmbArea.BackColor = System.Drawing.SystemColors.Window
        Me.cmbArea.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbArea.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArea.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbArea.Location = New System.Drawing.Point(148, 92)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbArea.Size = New System.Drawing.Size(181, 22)
        Me.cmbArea.TabIndex = 5
        '
        'cmbSort
        '
        Me.cmbSort.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSort.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSort.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSort.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbSort.Items.AddRange(New Object() {"Versekerde", "Personeelnommer"})
        Me.cmbSort.Location = New System.Drawing.Point(148, 156)
        Me.cmbSort.Name = "cmbSort"
        Me.cmbSort.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbSort.Size = New System.Drawing.Size(181, 22)
        Me.cmbSort.TabIndex = 4
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Location = New System.Drawing.Point(284, 204)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New System.Drawing.Size(89, 25)
        Me.btnOk.TabIndex = 1
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
        Me.btnCancel.Location = New System.Drawing.Point(376, 204)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(81, 25)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(52, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Area"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(52, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(69, 17)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Payment method"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(148, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(173, 17)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Monthly salary"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(52, 161)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Sorting"
        '
        'lblHeading
        '
        Me.lblHeading.BackColor = System.Drawing.SystemColors.Control
        Me.lblHeading.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHeading.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHeading.Location = New System.Drawing.Point(16, 16)
        Me.lblHeading.Name = "lblHeading"
        Me.lblHeading.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHeading.Size = New System.Drawing.Size(189, 17)
        Me.lblHeading.TabIndex = 2
        Me.lblHeading.Text = "Salary Closure Runs"
        '
        'lblProgress
        '
        Me.lblProgress.BackColor = System.Drawing.Color.Transparent
        Me.lblProgress.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblProgress.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgress.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProgress.Location = New System.Drawing.Point(16, 200)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblProgress.Size = New System.Drawing.Size(217, 17)
        Me.lblProgress.TabIndex = 3
        '
        'frmSalarisAfsluitings
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(479, 239)
        Me.Controls.Add(Me.optFinaleLopie)
        Me.Controls.Add(Me.optToetslopie)
        Me.Controls.Add(Me.cmbArea)
        Me.Controls.Add(Me.cmbSort)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblHeading)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 30)
        Me.Name = "frmSalarisAfsluitings"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Salary Closure"
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class