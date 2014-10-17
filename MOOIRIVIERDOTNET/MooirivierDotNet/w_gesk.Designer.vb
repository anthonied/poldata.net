<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class W_Gesk
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
    Public WithEvents Command1 As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Command1 = New System.Windows.Forms.Button()
        Me.dgvAmendments = New System.Windows.Forms.DataGridView()
        Me.Wysdatum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvBeskrywing = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.User = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvAmendments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(697, 496)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(85, 25)
        Me.Command1.TabIndex = 0
        Me.Command1.Text = "Close"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'dgvAmendments
        '
        Me.dgvAmendments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAmendments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Wysdatum, Me.Category, Me.dgvBeskrywing, Me.User, Me.DateTime})
        Me.dgvAmendments.Location = New System.Drawing.Point(1, 0)
        Me.dgvAmendments.Name = "dgvAmendments"
        Me.dgvAmendments.Size = New System.Drawing.Size(790, 490)
        Me.dgvAmendments.TabIndex = 1
        '
        'Wysdatum
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.Wysdatum.DefaultCellStyle = DataGridViewCellStyle1
        Me.Wysdatum.HeaderText = "Date"
        Me.Wysdatum.Name = "Wysdatum"
        Me.Wysdatum.Width = 120
        '
        'Category
        '
        Me.Category.DataPropertyName = "category"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.Category.DefaultCellStyle = DataGridViewCellStyle2
        Me.Category.HeaderText = "Category"
        Me.Category.MinimumWidth = 40
        Me.Category.Name = "Category"
        Me.Category.Width = 150
        '
        'dgvBeskrywing
        '
        Me.dgvBeskrywing.DataPropertyName = "beskrywing"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.dgvBeskrywing.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvBeskrywing.HeaderText = "Description"
        Me.dgvBeskrywing.MinimumWidth = 70
        Me.dgvBeskrywing.Name = "dgvBeskrywing"
        Me.dgvBeskrywing.Width = 370
        '
        'User
        '
        Me.User.DataPropertyName = "gebruiker"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.User.DefaultCellStyle = DataGridViewCellStyle4
        Me.User.HeaderText = "User"
        Me.User.Name = "User"
        Me.User.Width = 85
        '
        'DateTime
        '
        Me.DateTime.DataPropertyName = "datum"
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.DateTime.DefaultCellStyle = DataGridViewCellStyle5
        Me.DateTime.HeaderText = "Date"
        Me.DateTime.Name = "DateTime"
        Me.DateTime.Visible = False
        Me.DateTime.Width = 140
        '
        'W_Gesk
        '
        Me.AcceptButton = Me.Command1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(794, 527)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvAmendments)
        Me.Controls.Add(Me.Command1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(73, 99)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "W_Gesk"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Amendments History"
        CType(Me.dgvAmendments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvAmendments As System.Windows.Forms.DataGridView
    Friend WithEvents Wysdatum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvBeskrywing As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents User As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateTime As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class