<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class menmfrm1
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
	Public WithEvents listStatus As System.Windows.Forms.ListBox
	Public WithEvents txtLeernaam As System.Windows.Forms.TextBox
	Public WithEvents btnSearch As System.Windows.Forms.Button
	Public CommonDialog1Open As System.Windows.Forms.OpenFileDialog
	Public WithEvents btnClose As System.Windows.Forms.Button
	Public WithEvents btnOk As System.Windows.Forms.Button
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Line1 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line2 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents lbl1 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents lblStatus As System.Windows.Forms.Label
	Public WithEvents Line4 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line3 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(menmfrm))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Line1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Line2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Line4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Line3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.listStatus = New System.Windows.Forms.ListBox()
        Me.txtLeernaam = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.CommonDialog1Open = New System.Windows.Forms.OpenFileDialog()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Line1, Me.Line2, Me.Line4, Me.Line3})
        Me.ShapeContainer1.Size = New System.Drawing.Size(543, 340)
        Me.ShapeContainer1.TabIndex = 13
        Me.ShapeContainer1.TabStop = False
        '
        'Line1
        '
        Me.Line1.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Line1.Name = "Line1"
        Me.Line1.X1 = 221
        Me.Line1.X2 = 524
        Me.Line1.Y1 = 24
        Me.Line1.Y2 = 25
        '
        'Line2
        '
        Me.Line2.BorderColor = System.Drawing.Color.White
        Me.Line2.Name = "Line2"
        Me.Line2.X1 = 136
        Me.Line2.X2 = 524
        Me.Line2.Y1 = 26
        Me.Line2.Y2 = 26
        '
        'Line4
        '
        Me.Line4.BorderColor = System.Drawing.Color.White
        Me.Line4.Name = "Line4"
        Me.Line4.X1 = 16
        Me.Line4.X2 = 520
        Me.Line4.Y1 = 285
        Me.Line4.Y2 = 285
        '
        'Line3
        '
        Me.Line3.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Line3.Name = "Line3"
        Me.Line3.X1 = 16
        Me.Line3.X2 = 520
        Me.Line3.Y1 = 284
        Me.Line3.Y2 = 284
        '
        'listStatus
        '
        Me.listStatus.BackColor = System.Drawing.SystemColors.Window
        Me.listStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.listStatus.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.listStatus.ItemHeight = 14
        Me.listStatus.Location = New System.Drawing.Point(16, 184)
        Me.listStatus.Name = "listStatus"
        Me.listStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.listStatus.Size = New System.Drawing.Size(505, 88)
        Me.listStatus.TabIndex = 10
        Me.listStatus.Visible = False
        '
        'txtLeernaam
        '
        Me.txtLeernaam.AcceptsReturn = True
        Me.txtLeernaam.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeernaam.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeernaam.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLeernaam.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLeernaam.Location = New System.Drawing.Point(16, 104)
        Me.txtLeernaam.MaxLength = 0
        Me.txtLeernaam.Name = "txtLeernaam"
        Me.txtLeernaam.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeernaam.Size = New System.Drawing.Size(345, 20)
        Me.txtLeernaam.TabIndex = 5
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.Control
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSearch.Location = New System.Drawing.Point(368, 101)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSearch.Size = New System.Drawing.Size(89, 25)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "Select file"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'CommonDialog1Open
        '
        Me.CommonDialog1Open.Filter = "All Files (*.dta) | *.dta"
        Me.CommonDialog1Open.InitialDirectory = "c:\polis5admin\updates"
        Me.CommonDialog1Open.Title = "Choose the vehicle value file"
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Location = New System.Drawing.Point(448, 301)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClose.Size = New System.Drawing.Size(77, 26)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Location = New System.Drawing.Point(364, 301)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New System.Drawing.Size(77, 26)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "&Ok"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(441, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "This update will do the following:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 184)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(497, 41)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Update Mead & McGrouther values for both Poldata and Quotation Program."
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(16, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(505, 17)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "This update will take a few minutes."
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(223, 24)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Poldata Mead && McGrouther values"
        '
        'lbl1
        '
        Me.lbl1.BackColor = System.Drawing.Color.Transparent
        Me.lbl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl1.Location = New System.Drawing.Point(16, 40)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl1.Size = New System.Drawing.Size(509, 29)
        Me.lbl1.TabIndex = 7
        Me.lbl1.Text = "There are several vehicle values that can change monthly. The update will replace" & _
    " the existing values with new values, it will also add new entries if any."
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(521, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Please use the correct file for this update."
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 304)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(117, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Number of records read"
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStatus.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStatus.Location = New System.Drawing.Point(136, 304)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStatus.Size = New System.Drawing.Size(133, 13)
        Me.lblStatus.TabIndex = 2
        Me.lblStatus.Text = "lblStatus"
        '
        'menmfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(543, 340)
        Me.Controls.Add(Me.listStatus)
        Me.Controls.Add(Me.txtLeernaam)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbl1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "menmfrm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        'Kobus 04/03/2014 verander van Poldata - Databasis Opdatering (Mead & McGrouther)
        Me.Text = "Poldata - Database Maintenance (Mead & McGrouther)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class