<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class Argief
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
	Public WithEvents btnPrint As System.Windows.Forms.Button
	Public WithEvents btnHelp As System.Windows.Forms.Button
	Public WithEvents btnOpen As System.Windows.Forms.Button
	Public WithEvents btnBesonderhede As System.Windows.Forms.Button
	Public WithEvents btnClose As System.Windows.Forms.Button
   
	Public WithEvents Label6 As System.Windows.Forms.Label
	
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.CommonDialog1Open = New System.Windows.Forms.OpenFileDialog()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dgvArgief = New System.Windows.Forms.DataGridView()
        Me.WysDatum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShowCategoryDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.inOut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gebruiker = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.epos_Adres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pkArgief = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Path = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Datum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Incoming = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fkArchiveCategories = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.btnBesonderhede = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnEmail = New System.Windows.Forms.Button()
        CType(Me.dgvArgief, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.SystemColors.Control
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnPrint.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPrint.Location = New System.Drawing.Point(468, 48)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPrint.Size = New System.Drawing.Size(93, 20)
        Me.btnPrint.TabIndex = 6
        Me.btnPrint.Text = "Print this list"
        Me.ToolTip1.SetToolTip(Me.btnPrint, "Druk hierdie lys")
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Location = New System.Drawing.Point(387, 420)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClose.Size = New System.Drawing.Size(85, 25)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'dgvArgief
        '
        Me.dgvArgief.AllowUserToAddRows = False
        Me.dgvArgief.AllowUserToDeleteRows = False
        Me.dgvArgief.AllowUserToResizeColumns = False
        Me.dgvArgief.AllowUserToResizeRows = False
        Me.dgvArgief.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArgief.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.WysDatum, Me.ShowCategoryDesc, Me.inOut, Me.Gebruiker, Me.epos_Adres, Me.pkArgief, Me.Path, Me.Datum, Me.Incoming, Me.fkArchiveCategories})
        Me.dgvArgief.Location = New System.Drawing.Point(12, 74)
        Me.dgvArgief.Name = "dgvArgief"
        Me.dgvArgief.ReadOnly = True
        Me.dgvArgief.RowHeadersVisible = False
        Me.dgvArgief.Size = New System.Drawing.Size(549, 335)
        Me.dgvArgief.TabIndex = 8
        '
        'WysDatum
        '
        Me.WysDatum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.WysDatum.HeaderText = "Date"
        Me.WysDatum.MinimumWidth = 60
        Me.WysDatum.Name = "WysDatum"
        Me.WysDatum.ReadOnly = True
        Me.WysDatum.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.WysDatum.Width = 60
        '
        'ShowCategoryDesc
        '
        Me.ShowCategoryDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ShowCategoryDesc.DataPropertyName = "None"
        Me.ShowCategoryDesc.HeaderText = "Document"
        Me.ShowCategoryDesc.MinimumWidth = 100
        Me.ShowCategoryDesc.Name = "ShowCategoryDesc"
        Me.ShowCategoryDesc.ReadOnly = True
        Me.ShowCategoryDesc.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'inOut
        '
        Me.inOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.inOut.HeaderText = "In\Out"
        Me.inOut.MinimumWidth = 40
        Me.inOut.Name = "inOut"
        Me.inOut.ReadOnly = True
        Me.inOut.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.inOut.Width = 40
        '
        'Gebruiker
        '
        Me.Gebruiker.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Gebruiker.DataPropertyName = "Gebruiker"
        Me.Gebruiker.HeaderText = "User"
        Me.Gebruiker.MinimumWidth = 60
        Me.Gebruiker.Name = "Gebruiker"
        Me.Gebruiker.ReadOnly = True
        Me.Gebruiker.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Gebruiker.Width = 60
        '
        'epos_Adres
        '
        Me.epos_Adres.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.epos_Adres.DataPropertyName = "epos_Adres"
        Me.epos_Adres.HeaderText = "Email"
        Me.epos_Adres.MinimumWidth = 100
        Me.epos_Adres.Name = "epos_Adres"
        Me.epos_Adres.ReadOnly = True
        Me.epos_Adres.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'pkArgief
        '
        Me.pkArgief.DataPropertyName = "pkArgief"
        Me.pkArgief.HeaderText = "pkArgief"
        Me.pkArgief.Name = "pkArgief"
        Me.pkArgief.ReadOnly = True
        Me.pkArgief.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.pkArgief.Visible = False
        '
        'Path
        '
        Me.Path.DataPropertyName = "Path"
        Me.Path.HeaderText = "Path"
        Me.Path.Name = "Path"
        Me.Path.ReadOnly = True
        Me.Path.Visible = False
        '
        'Datum
        '
        Me.Datum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Datum.DataPropertyName = "Datum"
        Me.Datum.HeaderText = "Date"
        Me.Datum.MinimumWidth = 60
        Me.Datum.Name = "Datum"
        Me.Datum.ReadOnly = True
        Me.Datum.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Datum.Visible = False
        '
        'Incoming
        '
        Me.Incoming.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Incoming.DataPropertyName = "Incoming"
        Me.Incoming.HeaderText = "In\Out1"
        Me.Incoming.MinimumWidth = 70
        Me.Incoming.Name = "Incoming"
        Me.Incoming.ReadOnly = True
        Me.Incoming.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Incoming.Visible = False
        '
        'fkArchiveCategories
        '
        Me.fkArchiveCategories.DataPropertyName = "fkArchiveCategories"
        Me.fkArchiveCategories.HeaderText = "fkArchiveCategories"
        Me.fkArchiveCategories.Name = "fkArchiveCategories"
        Me.fkArchiveCategories.ReadOnly = True
        '
        'btnHelp
        '
        Me.btnHelp.BackColor = System.Drawing.SystemColors.Control
        Me.btnHelp.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnHelp.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHelp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnHelp.Location = New System.Drawing.Point(477, 420)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnHelp.Size = New System.Drawing.Size(85, 25)
        Me.btnHelp.TabIndex = 5
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = False
        '
        'btnOpen
        '
        Me.btnOpen.BackColor = System.Drawing.SystemColors.Control
        Me.btnOpen.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOpen.Enabled = False
        Me.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOpen.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOpen.Location = New System.Drawing.Point(12, 48)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOpen.Size = New System.Drawing.Size(93, 20)
        Me.btnOpen.TabIndex = 4
        Me.btnOpen.Text = "Open document"
        Me.btnOpen.UseVisualStyleBackColor = False
        '
        'btnBesonderhede
        '
        Me.btnBesonderhede.BackColor = System.Drawing.SystemColors.Control
        Me.btnBesonderhede.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnBesonderhede.Enabled = False
        Me.btnBesonderhede.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnBesonderhede.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBesonderhede.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBesonderhede.Location = New System.Drawing.Point(216, 48)
        Me.btnBesonderhede.Name = "btnBesonderhede"
        Me.btnBesonderhede.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnBesonderhede.Size = New System.Drawing.Size(93, 20)
        Me.btnBesonderhede.TabIndex = 3
        Me.btnBesonderhede.Text = "Details"
        Me.btnBesonderhede.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnBesonderhede.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(12, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(321, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Documents communicated regarding the  Insured"
        '
        'btnEmail
        '
        Me.btnEmail.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmail.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnEmail.Enabled = False
        Me.btnEmail.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnEmail.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmail.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEmail.Location = New System.Drawing.Point(114, 48)
        Me.btnEmail.Name = "btnEmail"
        Me.btnEmail.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnEmail.Size = New System.Drawing.Size(93, 20)
        Me.btnEmail.TabIndex = 9
        Me.btnEmail.Text = "Email document"
        Me.btnEmail.UseVisualStyleBackColor = False
        '
        'Argief
        '
        Me.AcceptButton = Me.btnClose
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(575, 460)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnEmail)
        Me.Controls.Add(Me.dgvArgief)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.btnBesonderhede)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label6)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Argief"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "    Archive"
        CType(Me.dgvArgief, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvArgief As System.Windows.Forms.DataGridView
    Public WithEvents btnEmail As System.Windows.Forms.Button
    Friend WithEvents WysDatum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShowCategoryDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents inOut As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gebruiker As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents epos_Adres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pkArgief As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Path As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Datum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Incoming As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fkArchiveCategories As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class