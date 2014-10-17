<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class BnkCodes
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
	Public WithEvents txtFormToPopulate As System.Windows.Forms.TextBox
	Public WithEvents cmbBnkType As System.Windows.Forms.ComboBox
	Public WithEvents Data1 As System.Windows.Forms.Label
    Public WithEvents btnOk As System.Windows.Forms.Button
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents txtBank As System.Windows.Forms.TextBox
	Public WithEvents txtBranch As System.Windows.Forms.TextBox
	Public WithEvents btnSearch As System.Windows.Forms.Button
	Public WithEvents btnClear As System.Windows.Forms.Button
	Public WithEvents txtCode As System.Windows.Forms.TextBox
	Public WithEvents lblTotal As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtFormToPopulate = New System.Windows.Forms.TextBox()
        Me.cmbBnkType = New System.Windows.Forms.ComboBox()
        Me.Data1 = New System.Windows.Forms.Label()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtBank = New System.Windows.Forms.TextBox()
        Me.txtBranch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BankCodesGridView1 = New System.Windows.Forms.DataGridView()
        Me.pkBankCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bank = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Branch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BranchCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.BankCodesGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtFormToPopulate
        '
        Me.txtFormToPopulate.AcceptsReturn = True
        Me.txtFormToPopulate.BackColor = System.Drawing.SystemColors.Window
        Me.txtFormToPopulate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFormToPopulate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFormToPopulate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFormToPopulate.Location = New System.Drawing.Point(180, 305)
        Me.txtFormToPopulate.MaxLength = 0
        Me.txtFormToPopulate.Name = "txtFormToPopulate"
        Me.txtFormToPopulate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFormToPopulate.Size = New System.Drawing.Size(237, 20)
        Me.txtFormToPopulate.TabIndex = 15
        Me.txtFormToPopulate.Text = "Used for name of form to populate with values"
        Me.txtFormToPopulate.Visible = False
        '
        'cmbBnkType
        '
        Me.cmbBnkType.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBnkType.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbBnkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBnkType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBnkType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbBnkType.Location = New System.Drawing.Point(8, 224)
        Me.cmbBnkType.Name = "cmbBnkType"
        Me.cmbBnkType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbBnkType.Size = New System.Drawing.Size(117, 22)
        Me.cmbBnkType.TabIndex = 12
        '
        'Data1
        '
        Me.Data1.BackColor = System.Drawing.Color.Red
        Me.Data1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Data1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Data1.ForeColor = System.Drawing.Color.Black
        Me.Data1.Location = New System.Drawing.Point(12, 296)
        Me.Data1.Name = "Data1"
        Me.Data1.Size = New System.Drawing.Size(121, 23)
        Me.Data1.TabIndex = 16
        Me.Data1.Text = "Data1"
        Me.Data1.Visible = False
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOk.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Location = New System.Drawing.Point(513, 300)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New System.Drawing.Size(77, 25)
        Me.btnOk.TabIndex = 6
        Me.btnOk.Text = "&Ok"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(596, 300)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(77, 25)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'txtBank
        '
        Me.txtBank.AcceptsReturn = True
        Me.txtBank.BackColor = System.Drawing.SystemColors.Window
        Me.txtBank.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBank.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBank.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBank.Location = New System.Drawing.Point(8, 80)
        Me.txtBank.MaxLength = 0
        Me.txtBank.Name = "txtBank"
        Me.txtBank.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBank.Size = New System.Drawing.Size(117, 20)
        Me.txtBank.TabIndex = 0
        '
        'txtBranch
        '
        Me.txtBranch.AcceptsReturn = True
        Me.txtBranch.BackColor = System.Drawing.SystemColors.Window
        Me.txtBranch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBranch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranch.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBranch.Location = New System.Drawing.Point(8, 128)
        Me.txtBranch.MaxLength = 0
        Me.txtBranch.Name = "txtBranch"
        Me.txtBranch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBranch.Size = New System.Drawing.Size(117, 20)
        Me.txtBranch.TabIndex = 1
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.Control
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSearch.Location = New System.Drawing.Point(8, 264)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSearch.Size = New System.Drawing.Size(57, 21)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.SystemColors.Control
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnClear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClear.Location = New System.Drawing.Point(68, 264)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClear.Size = New System.Drawing.Size(57, 21)
        Me.btnClear.TabIndex = 5
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'txtCode
        '
        Me.txtCode.AcceptsReturn = True
        Me.txtCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCode.Location = New System.Drawing.Point(8, 176)
        Me.txtCode.MaxLength = 0
        Me.txtCode.Name = "txtCode"
        Me.txtCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCode.Size = New System.Drawing.Size(65, 20)
        Me.txtCode.TabIndex = 2
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.SystemColors.Control
        Me.lblTotal.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTotal.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTotal.Location = New System.Drawing.Point(144, 300)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTotal.Size = New System.Drawing.Size(109, 13)
        Me.lblTotal.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 208)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Type"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(8, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(117, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Bank"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(8, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(117, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Branch"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(8, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Branch code"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(8, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(117, 37)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Search using the following criteria:"
        '
        'BankCodesGridView1
        '
        Me.BankCodesGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.BankCodesGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pkBankCode, Me.Bank, Me.Branch, Me.BranchCode, Me.Type})
        Me.BankCodesGridView1.Location = New System.Drawing.Point(148, 12)
        Me.BankCodesGridView1.Name = "BankCodesGridView1"
        Me.BankCodesGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.BankCodesGridView1.Size = New System.Drawing.Size(547, 273)
        Me.BankCodesGridView1.TabIndex = 17
        '
        'pkBankCode
        '
        Me.pkBankCode.DataPropertyName = "pkBankCodes"
        Me.pkBankCode.HeaderText = "BankCode"
        Me.pkBankCode.Name = "pkBankCode"
        Me.pkBankCode.Visible = False
        '
        'Bank
        '
        Me.Bank.DataPropertyName = "BankName"
        Me.Bank.HeaderText = "Bank"
        Me.Bank.Name = "Bank"
        '
        'Branch
        '
        Me.Branch.DataPropertyName = "Branchname"
        Me.Branch.HeaderText = "Branch"
        Me.Branch.Name = "Branch"
        Me.Branch.Width = 300
        '
        'BranchCode
        '
        Me.BranchCode.DataPropertyName = "Branchcode"
        Me.BranchCode.HeaderText = "Branch Code"
        Me.BranchCode.Name = "BranchCode"
        '
        'Type
        '
        Me.Type.DataPropertyName = "Type"
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        Me.Type.Visible = False
        '
        'BnkCodes
        '
        Me.AcceptButton = Me.btnSearch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(707, 343)
        Me.Controls.Add(Me.BankCodesGridView1)
        Me.Controls.Add(Me.txtFormToPopulate)
        Me.Controls.Add(Me.cmbBnkType)
        Me.Controls.Add(Me.Data1)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtBank)
        Me.Controls.Add(Me.txtBranch)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 30)
        Me.Name = "BnkCodes"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.BankCodesGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BankCodesGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents pkBankCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bank As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Branch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BranchCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class