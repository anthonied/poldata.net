<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class PremieDetail
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
    Public WithEvents lblTydperk As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents lblTermynStatus As System.Windows.Forms.Label
	Public WithEvents lblMaande As System.Windows.Forms.Label
	Public WithEvents lblTipePolis As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Line4 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line3 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Line4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Line3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblTydperk = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTermynStatus = New System.Windows.Forms.Label()
        Me.lblMaande = New System.Windows.Forms.Label()
        Me.lblTipePolis = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvPremieUiteensetting = New System.Windows.Forms.DataGridView()
        CType(Me.dgvPremieUiteensetting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Line4, Me.Line3})
        Me.ShapeContainer1.Size = New System.Drawing.Size(544, 566)
        Me.ShapeContainer1.TabIndex = 11
        Me.ShapeContainer1.TabStop = False
        '
        'Line4
        '
        Me.Line4.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Line4.Name = "Line4"
        Me.Line4.X1 = 12
        Me.Line4.X2 = 528
        Me.Line4.Y1 = 520
        Me.Line4.Y2 = 520
        '
        'Line3
        '
        Me.Line3.BorderColor = System.Drawing.Color.White
        Me.Line3.Name = "Line3"
        Me.Line3.X1 = 12
        Me.Line3.X2 = 528
        Me.Line3.Y1 = 521
        Me.Line3.Y2 = 521
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Location = New System.Drawing.Point(444, 528)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClose.Size = New System.Drawing.Size(85, 25)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'lblTydperk
        '
        Me.lblTydperk.BackColor = System.Drawing.SystemColors.Control
        Me.lblTydperk.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTydperk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTydperk.ForeColor = System.Drawing.Color.Black
        Me.lblTydperk.Location = New System.Drawing.Point(376, 32)
        Me.lblTydperk.Name = "lblTydperk"
        Me.lblTydperk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTydperk.Size = New System.Drawing.Size(153, 13)
        Me.lblTydperk.TabIndex = 10
        Me.lblTydperk.Text = " lbl Period"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(268, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Period"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(268, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Period status"
        '
        'lblTermynStatus
        '
        Me.lblTermynStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblTermynStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTermynStatus.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTermynStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTermynStatus.Location = New System.Drawing.Point(376, 48)
        Me.lblTermynStatus.Name = "lblTermynStatus"
        Me.lblTermynStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTermynStatus.Size = New System.Drawing.Size(153, 13)
        Me.lblTermynStatus.TabIndex = 7
        Me.lblTermynStatus.Text = "PeriodStatus"
        '
        'lblMaande
        '
        Me.lblMaande.BackColor = System.Drawing.SystemColors.Control
        Me.lblMaande.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMaande.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaande.ForeColor = System.Drawing.Color.Black
        Me.lblMaande.Location = New System.Drawing.Point(108, 48)
        Me.lblMaande.Name = "lblMaande"
        Me.lblMaande.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMaande.Size = New System.Drawing.Size(53, 13)
        Me.lblMaande.TabIndex = 6
        Me.lblMaande.Text = "lblMonth"
        '
        'lblTipePolis
        '
        Me.lblTipePolis.BackColor = System.Drawing.SystemColors.Control
        Me.lblTipePolis.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTipePolis.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipePolis.ForeColor = System.Drawing.Color.Black
        Me.lblTipePolis.Location = New System.Drawing.Point(108, 32)
        Me.lblTipePolis.Name = "lblTipePolis"
        Me.lblTipePolis.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTipePolis.Size = New System.Drawing.Size(134, 13)
        Me.lblTipePolis.TabIndex = 5
        Me.lblTipePolis.Text = "Monthly electronic"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(24, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Month"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(24, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Type of policy"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(12, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(380, 20)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Premium breakdown after discount"
        '
        'dgvPremieUiteensetting
        '
        Me.dgvPremieUiteensetting.AllowUserToResizeColumns = False
        Me.dgvPremieUiteensetting.AllowUserToResizeRows = False
        Me.dgvPremieUiteensetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvPremieUiteensetting.Location = New System.Drawing.Point(16, 75)
        Me.dgvPremieUiteensetting.Name = "dgvPremieUiteensetting"
        Me.dgvPremieUiteensetting.RowHeadersVisible = False
        Me.dgvPremieUiteensetting.Size = New System.Drawing.Size(513, 421)
        Me.dgvPremieUiteensetting.TabIndex = 12
        '
        'PremieDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(544, 566)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvPremieUiteensetting)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblTydperk)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblTermynStatus)
        Me.Controls.Add(Me.lblMaande)
        Me.Controls.Add(Me.lblTipePolis)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PremieDetail"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Poldata - Premie detail"
        CType(Me.dgvPremieUiteensetting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvPremieUiteensetting As System.Windows.Forms.DataGridView
#End Region
End Class