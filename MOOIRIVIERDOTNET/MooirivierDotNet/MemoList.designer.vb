<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class MemoList
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
	Public WithEvents btnPrint As System.Windows.Forms.Button
	Public WithEvents btnClose As System.Windows.Forms.Button
	Public WithEvents btnHelp As System.Windows.Forms.Button
	Public WithEvents btnVerwyder As System.Windows.Forms.Button
	Public WithEvents btnBesonderhede As System.Windows.Forms.Button
	Public WithEvents btnVoegBy As System.Windows.Forms.Button
    Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnVerwyder = New System.Windows.Forms.Button()
        Me.btnBesonderhede = New System.Windows.Forms.Button()
        Me.btnVoegBy = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dgvMemo = New System.Windows.Forms.DataGridView()
        Me.Colour = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pkMemo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Polisno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DatumToegevoer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DatumVerander = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Deleted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvBeskrywing = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gebruiker = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kategorie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvMemo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.SystemColors.Control
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnPrint.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPrint.Location = New System.Drawing.Point(652, 12)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPrint.Size = New System.Drawing.Size(85, 20)
        Me.btnPrint.TabIndex = 6
        Me.btnPrint.Text = "Print this list"
        Me.ToolTip1.SetToolTip(Me.btnPrint, "Druk hierdie lys")
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnVerwyder
        '
        Me.btnVerwyder.BackColor = System.Drawing.SystemColors.Control
        Me.btnVerwyder.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnVerwyder.Enabled = False
        Me.btnVerwyder.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerwyder.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnVerwyder.Location = New System.Drawing.Point(96, 12)
        Me.btnVerwyder.Name = "btnVerwyder"
        Me.btnVerwyder.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnVerwyder.Size = New System.Drawing.Size(77, 20)
        Me.btnVerwyder.TabIndex = 3
        Me.btnVerwyder.Text = "Remove"
        Me.ToolTip1.SetToolTip(Me.btnVerwyder, "Verwyder betrokke memo")
        Me.btnVerwyder.UseVisualStyleBackColor = False
        '
        'btnBesonderhede
        '
        Me.btnBesonderhede.BackColor = System.Drawing.SystemColors.Control
        Me.btnBesonderhede.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnBesonderhede.Enabled = False
        Me.btnBesonderhede.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBesonderhede.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBesonderhede.Location = New System.Drawing.Point(176, 12)
        Me.btnBesonderhede.Name = "btnBesonderhede"
        Me.btnBesonderhede.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnBesonderhede.Size = New System.Drawing.Size(81, 20)
        Me.btnBesonderhede.TabIndex = 2
        Me.btnBesonderhede.Text = "Details"
        Me.ToolTip1.SetToolTip(Me.btnBesonderhede, "Besonderhede van betrokke memo")
        Me.btnBesonderhede.UseVisualStyleBackColor = False
        '
        'btnVoegBy
        '
        Me.btnVoegBy.BackColor = System.Drawing.SystemColors.Control
        Me.btnVoegBy.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnVoegBy.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoegBy.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnVoegBy.Location = New System.Drawing.Point(16, 12)
        Me.btnVoegBy.Name = "btnVoegBy"
        Me.btnVoegBy.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnVoegBy.Size = New System.Drawing.Size(77, 20)
        Me.btnVoegBy.TabIndex = 5
        Me.btnVoegBy.Text = "Add"
        Me.ToolTip1.SetToolTip(Me.btnVoegBy, "Add a memo")
        Me.btnVoegBy.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Location = New System.Drawing.Point(561, 352)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClose.Size = New System.Drawing.Size(85, 25)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'dgvMemo
        '
        Me.dgvMemo.AllowUserToAddRows = False
        Me.dgvMemo.AllowUserToDeleteRows = False
        Me.dgvMemo.AllowUserToResizeColumns = False
        Me.dgvMemo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvMemo.ColumnHeadersHeight = 20
        Me.dgvMemo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Colour, Me.pkMemo, Me.Polisno, Me.DatumToegevoer, Me.DatumVerander, Me.Deleted, Me.dgvBeskrywing, Me.Gebruiker, Me.Kategorie})
        Me.dgvMemo.Location = New System.Drawing.Point(16, 36)
        Me.dgvMemo.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvMemo.Name = "dgvMemo"
        Me.dgvMemo.ReadOnly = True
        Me.dgvMemo.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.dgvMemo.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvMemo.RowTemplate.Height = 10
        Me.dgvMemo.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMemo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMemo.Size = New System.Drawing.Size(721, 305)
        Me.dgvMemo.TabIndex = 15
        '
        'Colour
        '
        Me.Colour.FillWeight = 20.0!
        Me.Colour.HeaderText = "!"
        Me.Colour.Name = "Colour"
        Me.Colour.ReadOnly = True
        Me.Colour.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Colour.Width = 10
        '
        'pkMemo
        '
        Me.pkMemo.DataPropertyName = "pkMemo"
        Me.pkMemo.HeaderText = "pkMemo"
        Me.pkMemo.Name = "pkMemo"
        Me.pkMemo.ReadOnly = True
        Me.pkMemo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.pkMemo.Visible = False
        '
        'Polisno
        '
        Me.Polisno.DataPropertyName = "Polisno"
        Me.Polisno.HeaderText = "Polisno"
        Me.Polisno.Name = "Polisno"
        Me.Polisno.ReadOnly = True
        Me.Polisno.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Polisno.Visible = False
        '
        'DatumToegevoer
        '
        Me.DatumToegevoer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DatumToegevoer.DataPropertyName = "DatumToegevoer"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.Format = "D"
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DatumToegevoer.DefaultCellStyle = DataGridViewCellStyle1
        Me.DatumToegevoer.HeaderText = "DateEntered"
        Me.DatumToegevoer.Name = "DatumToegevoer"
        Me.DatumToegevoer.ReadOnly = True
        Me.DatumToegevoer.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DatumToegevoer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DatumToegevoer.Visible = False
        Me.DatumToegevoer.Width = 92
        '
        'DatumVerander
        '
        Me.DatumVerander.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DatumVerander.DataPropertyName = "DatumVerander"
        DataGridViewCellStyle2.Format = "G"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DatumVerander.DefaultCellStyle = DataGridViewCellStyle2
        Me.DatumVerander.HeaderText = "Date"
        Me.DatumVerander.Name = "DatumVerander"
        Me.DatumVerander.ReadOnly = True
        Me.DatumVerander.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DatumVerander.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DatumVerander.Width = 54
        '
        'Deleted
        '
        Me.Deleted.DataPropertyName = "Deleted"
        Me.Deleted.HeaderText = "Deleted"
        Me.Deleted.Name = "Deleted"
        Me.Deleted.ReadOnly = True
        Me.Deleted.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Deleted.Visible = False
        '
        'dgvBeskrywing
        '
        Me.dgvBeskrywing.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvBeskrywing.DataPropertyName = "Beskrywing"
        Me.dgvBeskrywing.HeaderText = "Description"
        Me.dgvBeskrywing.Name = "dgvBeskrywing"
        Me.dgvBeskrywing.ReadOnly = True
        Me.dgvBeskrywing.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBeskrywing.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.dgvBeskrywing.Width = 540
        '
        'Gebruiker
        '
        Me.Gebruiker.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Gebruiker.DataPropertyName = "Gebruiker"
        Me.Gebruiker.HeaderText = "User"
        Me.Gebruiker.Name = "Gebruiker"
        Me.Gebruiker.ReadOnly = True
        Me.Gebruiker.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Gebruiker.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Gebruiker.Width = 65
        '
        'Kategorie
        '
        Me.Kategorie.DataPropertyName = "Kategorie"
        Me.Kategorie.HeaderText = "Kategorie"
        Me.Kategorie.Name = "Kategorie"
        Me.Kategorie.ReadOnly = True
        Me.Kategorie.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Kategorie.Visible = False
        Me.Kategorie.Width = 10
        '
        'btnHelp
        '
        Me.btnHelp.BackColor = System.Drawing.SystemColors.Control
        Me.btnHelp.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnHelp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHelp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnHelp.Location = New System.Drawing.Point(652, 352)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnHelp.Size = New System.Drawing.Size(85, 25)
        Me.btnHelp.TabIndex = 4
        Me.btnHelp.Text = "&Help"
        Me.btnHelp.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(284, 359)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Critical"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(200, 359)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "System"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(112, 359)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "History"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(28, 359)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "General"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Red
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label4.Location = New System.Drawing.Point(272, 360)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(9, 9)
        Me.Label4.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.Location = New System.Drawing.Point(187, 360)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(9, 9)
        Me.Label3.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Location = New System.Drawing.Point(101, 360)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(9, 9)
        Me.Label2.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(16, 360)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(9, 9)
        Me.Label1.TabIndex = 7
        '
        'MemoList
        '
        Me.AcceptButton = Me.btnClose
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(749, 389)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvMemo)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnVerwyder)
        Me.Controls.Add(Me.btnBesonderhede)
        Me.Controls.Add(Me.btnVoegBy)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MemoList"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Poldata - Memo"
        CType(Me.dgvMemo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvMemo As System.Windows.Forms.DataGridView
    Friend WithEvents Colour As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pkMemo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Polisno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DatumToegevoer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DatumVerander As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Deleted As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvBeskrywing As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gebruiker As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kategorie As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class