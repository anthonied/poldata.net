<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class Wysig2006
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
	Public WithEvents wysig_2006_oud As System.Windows.Forms.Button
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
        Me.dgvAmendments = New System.Windows.Forms.DataGridView()
        Me.WysDatum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvBeskrywing = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.User = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.wysig_2006_oud = New System.Windows.Forms.Button()
        CType(Me.dgvAmendments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvAmendments
        '
        Me.dgvAmendments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAmendments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.WysDatum, Me.Category, Me.dgvBeskrywing, Me.User, Me.DateTime})
        Me.dgvAmendments.Location = New System.Drawing.Point(1, 0)
        Me.dgvAmendments.Name = "dgvAmendments"
        Me.dgvAmendments.Size = New System.Drawing.Size(790, 490)
        Me.dgvAmendments.TabIndex = 2
        '
        'WysDatum
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.WysDatum.DefaultCellStyle = DataGridViewCellStyle1
        Me.WysDatum.HeaderText = "Date"
        Me.WysDatum.Name = "WysDatum"
        Me.WysDatum.Width = 120
        '
        'Category
        '
        Me.Category.DataPropertyName = "category"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.Category.DefaultCellStyle = DataGridViewCellStyle2
        Me.Category.HeaderText = "Category"
        Me.Category.MinimumWidth = 40
        Me.Category.Name = "Category"
        Me.Category.Width = 170
        '
        'dgvBeskrywing
        '
        Me.dgvBeskrywing.DataPropertyName = "beskrywing"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.dgvBeskrywing.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvBeskrywing.HeaderText = "Description"
        Me.dgvBeskrywing.MinimumWidth = 70
        Me.dgvBeskrywing.Name = "dgvBeskrywing"
        Me.dgvBeskrywing.Width = 350
        '
        'User
        '
        Me.User.DataPropertyName = "gebruiker"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.User.DefaultCellStyle = DataGridViewCellStyle4
        Me.User.HeaderText = "User"
        Me.User.Name = "User"
        Me.User.Width = 90
        '
        'DateTime
        '
        Me.DateTime.DataPropertyName = "datum"
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.DateTime.DefaultCellStyle = DataGridViewCellStyle5
        Me.DateTime.HeaderText = "DateOld"
        Me.DateTime.Name = "DateTime"
        Me.DateTime.Visible = False
        Me.DateTime.Width = 10
        '
        'wysig_2006_oud
        '
        Me.wysig_2006_oud.BackColor = System.Drawing.SystemColors.Control
        Me.wysig_2006_oud.Cursor = System.Windows.Forms.Cursors.Default
        Me.wysig_2006_oud.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.wysig_2006_oud.ForeColor = System.Drawing.SystemColors.ControlText
        Me.wysig_2006_oud.Location = New System.Drawing.Point(697, 496)
        Me.wysig_2006_oud.Name = "wysig_2006_oud"
        Me.wysig_2006_oud.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.wysig_2006_oud.Size = New System.Drawing.Size(85, 25)
        Me.wysig_2006_oud.TabIndex = 1
        Me.wysig_2006_oud.Text = "Close"
        Me.wysig_2006_oud.UseVisualStyleBackColor = False
        '
        'Wysig2006
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(784, 517)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvAmendments)
        Me.Controls.Add(Me.wysig_2006_oud)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(73, 99)
        Me.Name = "Wysig2006"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Amendments 2000-2006"
        CType(Me.dgvAmendments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvAmendments As System.Windows.Forms.DataGridView
    Friend WithEvents WysDatum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvBeskrywing As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents User As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateTime As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class