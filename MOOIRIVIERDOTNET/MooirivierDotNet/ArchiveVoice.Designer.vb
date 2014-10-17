<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class ArchiveVoice
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.CommonDialog1Open = New System.Windows.Forms.OpenFileDialog()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dgvArchiveVoice = New System.Windows.Forms.DataGridView()
        Me.CallDateShow = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContactNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CallerNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InOutWys = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gebruiker = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FileName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pkArchiveVoice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Incoming = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fkArchiveCategories = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CallDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.btnBesonderhede = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.dgvArchiveVoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.SystemColors.Control
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnPrint.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPrint.Location = New System.Drawing.Point(419, 40)
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
        Me.btnClose.Location = New System.Drawing.Point(334, 420)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClose.Size = New System.Drawing.Size(85, 25)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'dgvArchiveVoice
        '
        Me.dgvArchiveVoice.AllowUserToAddRows = False
        Me.dgvArchiveVoice.AllowUserToDeleteRows = False
        Me.dgvArchiveVoice.AllowUserToResizeColumns = False
        Me.dgvArchiveVoice.AllowUserToResizeRows = False
        Me.dgvArchiveVoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArchiveVoice.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CallDateShow, Me.ContactNumber, Me.CallerNumber, Me.InOutWys, Me.Gebruiker, Me.FileName, Me.pkArchiveVoice, Me.Incoming, Me.fkArchiveCategories, Me.CallDate})
        Me.dgvArchiveVoice.Location = New System.Drawing.Point(19, 66)
        Me.dgvArchiveVoice.Name = "dgvArchiveVoice"
        Me.dgvArchiveVoice.ReadOnly = True
        Me.dgvArchiveVoice.RowHeadersVisible = False
        Me.dgvArchiveVoice.Size = New System.Drawing.Size(493, 348)
        Me.dgvArchiveVoice.TabIndex = 8
        '
        'CallDateShow
        '
        DataGridViewCellStyle1.Format = "G"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.CallDateShow.DefaultCellStyle = DataGridViewCellStyle1
        Me.CallDateShow.HeaderText = "Call Date"
        Me.CallDateShow.Name = "CallDateShow"
        Me.CallDateShow.ReadOnly = True
        Me.CallDateShow.Width = 120
        '
        'ContactNumber
        '
        Me.ContactNumber.DataPropertyName = "ContactNumber"
        Me.ContactNumber.HeaderText = "Contact Number"
        Me.ContactNumber.Name = "ContactNumber"
        Me.ContactNumber.ReadOnly = True
        Me.ContactNumber.Width = 80
        '
        'CallerNumber
        '
        Me.CallerNumber.DataPropertyName = "CallerNumber"
        Me.CallerNumber.HeaderText = "Caller Number"
        Me.CallerNumber.Name = "CallerNumber"
        Me.CallerNumber.ReadOnly = True
        Me.CallerNumber.Width = 80
        '
        'InOutWys
        '
        Me.InOutWys.HeaderText = "In\Out"
        Me.InOutWys.Name = "InOutWys"
        Me.InOutWys.ReadOnly = True
        Me.InOutWys.Width = 50
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
        'FileName
        '
        Me.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.FileName.DataPropertyName = "Filename"
        Me.FileName.HeaderText = "File Name"
        Me.FileName.Name = "FileName"
        Me.FileName.ReadOnly = True
        Me.FileName.Width = 115
        '
        'pkArchiveVoice
        '
        Me.pkArchiveVoice.DataPropertyName = "pkArchiveVoice"
        Me.pkArchiveVoice.HeaderText = "pkArchiveVoice"
        Me.pkArchiveVoice.Name = "pkArchiveVoice"
        Me.pkArchiveVoice.ReadOnly = True
        Me.pkArchiveVoice.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.pkArchiveVoice.Visible = False
        '
        'Incoming
        '
        Me.Incoming.DataPropertyName = "Incoming"
        Me.Incoming.HeaderText = "In\Out"
        Me.Incoming.Name = "Incoming"
        Me.Incoming.ReadOnly = True
        Me.Incoming.Visible = False
        '
        'fkArchiveCategories
        '
        Me.fkArchiveCategories.DataPropertyName = "fkArchiveCategories"
        Me.fkArchiveCategories.HeaderText = "fkArchiveCategories"
        Me.fkArchiveCategories.Name = "fkArchiveCategories"
        Me.fkArchiveCategories.ReadOnly = True
        Me.fkArchiveCategories.Visible = False
        '
        'CallDate
        '
        Me.CallDate.DataPropertyName = "CallDate"
        Me.CallDate.HeaderText = "Call Date"
        Me.CallDate.Name = "CallDate"
        Me.CallDate.ReadOnly = True
        Me.CallDate.Visible = False
        '
        'btnHelp
        '
        Me.btnHelp.BackColor = System.Drawing.SystemColors.Control
        Me.btnHelp.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnHelp.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHelp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnHelp.Location = New System.Drawing.Point(429, 420)
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
        Me.btnOpen.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOpen.Location = New System.Drawing.Point(16, 40)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOpen.Size = New System.Drawing.Size(93, 20)
        Me.btnOpen.TabIndex = 4
        Me.btnOpen.Text = "Email Request"
        Me.btnOpen.UseVisualStyleBackColor = False
        '
        'btnBesonderhede
        '
        Me.btnBesonderhede.BackColor = System.Drawing.SystemColors.Control
        Me.btnBesonderhede.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnBesonderhede.Enabled = False
        Me.btnBesonderhede.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBesonderhede.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBesonderhede.Location = New System.Drawing.Point(119, 40)
        Me.btnBesonderhede.Name = "btnBesonderhede"
        Me.btnBesonderhede.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnBesonderhede.Size = New System.Drawing.Size(85, 20)
        Me.btnBesonderhede.TabIndex = 3
        Me.btnBesonderhede.Text = "Details"
        Me.btnBesonderhede.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(16, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(321, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Recorded Phone Calls regarding the  Insured"
        '
        'ArchiveVoice
        '
        Me.AcceptButton = Me.btnClose
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(537, 452)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvArchiveVoice)
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
        Me.Name = "ArchiveVoice"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "    Voice Archive"
        CType(Me.dgvArchiveVoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvArchiveVoice As System.Windows.Forms.DataGridView
    Friend WithEvents CallDateShow As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContactNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CallerNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InOutWys As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gebruiker As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FileName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pkArchiveVoice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Incoming As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fkArchiveCategories As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CallDate As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class