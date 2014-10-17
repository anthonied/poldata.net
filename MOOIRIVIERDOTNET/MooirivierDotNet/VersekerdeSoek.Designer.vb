<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class VersekerdeSoek
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
	Public WithEvents txtPolisno As System.Windows.Forms.TextBox
	Public WithEvents dcVersekerde As System.Windows.Forms.Label
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents btnOk As System.Windows.Forms.Button
	Public WithEvents btnClear As System.Windows.Forms.Button
	Public WithEvents btnSearch As System.Windows.Forms.Button
    Public WithEvents txtVersekerde As System.Windows.Forms.TextBox
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.gridVersekerde = New System.Windows.Forms.DataGridView()
        Me.Surname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Initials = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PolicyNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtPolisno = New System.Windows.Forms.TextBox()
        Me.dcVersekerde = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.txtVersekerde = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbMaandBegin = New System.Windows.Forms.ComboBox()
        Me.cmbMaandEindig = New System.Windows.Forms.ComboBox()
        CType(Me.gridVersekerde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.Control
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSearch.Location = New System.Drawing.Point(8, 159)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSearch.Size = New System.Drawing.Size(65, 20)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'gridVersekerde
        '
        Me.gridVersekerde.AllowUserToAddRows = False
        Me.gridVersekerde.AllowUserToDeleteRows = False
        Me.gridVersekerde.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Surname, Me.Initials, Me.PolicyNumber})
        Me.gridVersekerde.Location = New System.Drawing.Point(213, 16)
        Me.gridVersekerde.Name = "gridVersekerde"
        Me.gridVersekerde.RowHeadersWidth = 5
        Me.gridVersekerde.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridVersekerde.Size = New System.Drawing.Size(378, 497)
        Me.gridVersekerde.TabIndex = 10
        '
        'Surname
        '
        Me.Surname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Surname.DataPropertyName = "VERSEKERDE"
        Me.Surname.HeaderText = "Surname"
        Me.Surname.Name = "Surname"
        '
        'Initials
        '
        Me.Initials.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Initials.DataPropertyName = "VOORL"
        Me.Initials.HeaderText = "Initials"
        Me.Initials.Name = "Initials"
        Me.Initials.Width = 61
        '
        'PolicyNumber
        '
        Me.PolicyNumber.DataPropertyName = "POLISNO"
        Me.PolicyNumber.HeaderText = "Policy No"
        Me.PolicyNumber.Name = "PolicyNumber"
        Me.PolicyNumber.Width = 90
        '
        'txtPolisno
        '
        Me.txtPolisno.AcceptsReturn = True
        Me.txtPolisno.BackColor = System.Drawing.SystemColors.Window
        Me.txtPolisno.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPolisno.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolisno.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPolisno.Location = New System.Drawing.Point(8, 72)
        Me.txtPolisno.MaxLength = 10
        Me.txtPolisno.Name = "txtPolisno"
        Me.txtPolisno.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPolisno.Size = New System.Drawing.Size(73, 20)
        Me.txtPolisno.TabIndex = 2
        '
        'dcVersekerde
        '
        Me.dcVersekerde.BackColor = System.Drawing.Color.Red
        Me.dcVersekerde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dcVersekerde.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dcVersekerde.ForeColor = System.Drawing.Color.Black
        Me.dcVersekerde.Location = New System.Drawing.Point(8, 520)
        Me.dcVersekerde.Name = "dcVersekerde"
        Me.dcVersekerde.Size = New System.Drawing.Size(169, 23)
        Me.dcVersekerde.TabIndex = 2
        Me.dcVersekerde.Text = "dcVersekerde"
        Me.dcVersekerde.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(506, 520)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(85, 25)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Location = New System.Drawing.Point(414, 520)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New System.Drawing.Size(81, 25)
        Me.btnOk.TabIndex = 8
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.SystemColors.Control
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnClear.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClear.Location = New System.Drawing.Point(84, 159)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClear.Size = New System.Drawing.Size(65, 20)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'txtVersekerde
        '
        Me.txtVersekerde.AcceptsReturn = True
        Me.txtVersekerde.BackColor = System.Drawing.SystemColors.Window
        Me.txtVersekerde.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVersekerde.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVersekerde.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVersekerde.Location = New System.Drawing.Point(8, 120)
        Me.txtVersekerde.MaxLength = 0
        Me.txtVersekerde.Name = "txtVersekerde"
        Me.txtVersekerde.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVersekerde.Size = New System.Drawing.Size(145, 20)
        Me.txtVersekerde.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(73, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Policy No"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(117, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Insured"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(113, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search using the following criteria"
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.SystemColors.Window
        Me.txtStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStatus.Location = New System.Drawing.Point(75, 380)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStatus.Size = New System.Drawing.Size(101, 22)
        Me.txtStatus.TabIndex = 7
        Me.txtStatus.Text = "Combo3"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(8, 247)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(49, 17)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Period"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(8, 383)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(41, 17)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Status"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(8, 332)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(69, 15)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "End date"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(8, 276)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(61, 15)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Start date"
        '
        'cmbMaandBegin
        '
        Me.cmbMaandBegin.FormattingEnabled = True
        Me.cmbMaandBegin.Location = New System.Drawing.Point(75, 273)
        Me.cmbMaandBegin.Name = "cmbMaandBegin"
        Me.cmbMaandBegin.Size = New System.Drawing.Size(104, 22)
        Me.cmbMaandBegin.TabIndex = 26
        '
        'cmbMaandEindig
        '
        Me.cmbMaandEindig.FormattingEnabled = True
        Me.cmbMaandEindig.Location = New System.Drawing.Point(73, 329)
        Me.cmbMaandEindig.Name = "cmbMaandEindig"
        Me.cmbMaandEindig.Size = New System.Drawing.Size(104, 22)
        Me.cmbMaandEindig.TabIndex = 27
        '
        'VersekerdeSoek
        '
        Me.AcceptButton = Me.btnSearch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(603, 566)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbMaandEindig)
        Me.Controls.Add(Me.cmbMaandBegin)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.gridVersekerde)
        Me.Controls.Add(Me.txtPolisno)
        Me.Controls.Add(Me.dcVersekerde)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtVersekerde)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 30)
        Me.Name = "VersekerdeSoek"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "1"
        Me.Text = "Poldata - Referral Search Policy"
        CType(Me.gridVersekerde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gridVersekerde As System.Windows.Forms.DataGridView
    Friend WithEvents Surname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Initials As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PolicyNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents txtStatus As System.Windows.Forms.ComboBox
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbMaandBegin As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMaandEindig As System.Windows.Forms.ComboBox
#End Region
End Class