<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class selfoonListFrm
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
	Public WithEvents dataselfoon As System.Windows.Forms.Label
	Public WithEvents btnEdit As System.Windows.Forms.Button
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents btnOk As System.Windows.Forms.Button
    Public WithEvents btnVoegby As System.Windows.Forms.Button
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnVoegby = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.dgvCellDetails = New System.Windows.Forms.DataGridView()
        Me.pkInsCell = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Make = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Model = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SerialNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CellNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContractDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Value = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Premium = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActiveIcon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cancel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rede = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dataselfoon = New System.Windows.Forms.Label()
        CType(Me.dgvCellDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.SystemColors.Control
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEdit.Location = New System.Drawing.Point(740, 22)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnEdit.Size = New System.Drawing.Size(67, 20)
        Me.btnEdit.TabIndex = 5
        Me.btnEdit.Text = "&Edit"
        Me.ToolTip1.SetToolTip(Me.btnEdit, "Verander die inligting van die betrokke selfoon.")
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnVoegby
        '
        Me.btnVoegby.BackColor = System.Drawing.SystemColors.Control
        Me.btnVoegby.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnVoegby.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoegby.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnVoegby.Location = New System.Drawing.Point(667, 22)
        Me.btnVoegby.Name = "btnVoegby"
        Me.btnVoegby.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnVoegby.Size = New System.Drawing.Size(67, 20)
        Me.btnVoegby.TabIndex = 1
        Me.btnVoegby.Text = "&Add"
        Me.ToolTip1.SetToolTip(Me.btnVoegby, "Voeg 'n nuwe selfoon by.")
        Me.btnVoegby.UseVisualStyleBackColor = False
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Location = New System.Drawing.Point(722, 193)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New System.Drawing.Size(85, 25)
        Me.btnOk.TabIndex = 3
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
        Me.btnCancel.Location = New System.Drawing.Point(631, 193)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(85, 25)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'dgvCellDetails
        '
        Me.dgvCellDetails.AllowUserToAddRows = False
        Me.dgvCellDetails.AllowUserToDeleteRows = False
        Me.dgvCellDetails.AllowUserToResizeColumns = False
        Me.dgvCellDetails.AllowUserToResizeRows = False
        Me.dgvCellDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCellDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pkInsCell, Me.Make, Me.Model, Me.SerialNumber, Me.CellNumber, Me.ContractDate, Me.Value, Me.Premium, Me.Status, Me.ActiveIcon, Me.Cancel, Me.Rede})
        Me.dgvCellDetails.Location = New System.Drawing.Point(8, 48)
        Me.dgvCellDetails.Name = "dgvCellDetails"
        Me.dgvCellDetails.ReadOnly = True
        Me.dgvCellDetails.RowHeadersVisible = False
        Me.dgvCellDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCellDetails.Size = New System.Drawing.Size(803, 139)
        Me.dgvCellDetails.TabIndex = 6
        '
        'pkInsCell
        '
        Me.pkInsCell.DataPropertyName = "pkSelfoon"
        Me.pkInsCell.HeaderText = "PkInsCell"
        Me.pkInsCell.Name = "pkInsCell"
        Me.pkInsCell.ReadOnly = True
        Me.pkInsCell.Visible = False
        '
        'Make
        '
        Me.Make.DataPropertyName = "Make"
        Me.Make.HeaderText = "Make"
        Me.Make.Name = "Make"
        Me.Make.ReadOnly = True
        Me.Make.Width = 80
        '
        'Model
        '
        Me.Model.DataPropertyName = "Model"
        Me.Model.HeaderText = "Model"
        Me.Model.Name = "Model"
        Me.Model.ReadOnly = True
        Me.Model.Width = 80
        '
        'SerialNumber
        '
        Me.SerialNumber.DataPropertyName = "SerialNo"
        Me.SerialNumber.HeaderText = "Serial Number"
        Me.SerialNumber.Name = "SerialNumber"
        Me.SerialNumber.ReadOnly = True
        '
        'CellNumber
        '
        Me.CellNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.CellNumber.DataPropertyName = "Nommer"
        Me.CellNumber.HeaderText = "Cell Number"
        Me.CellNumber.Name = "CellNumber"
        Me.CellNumber.ReadOnly = True
        Me.CellNumber.Width = 75
        '
        'ContractDate
        '
        Me.ContractDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.ContractDate.DataPropertyName = "Kotrak"
        Me.ContractDate.HeaderText = "Contract Date"
        Me.ContractDate.MinimumWidth = 40
        Me.ContractDate.Name = "ContractDate"
        Me.ContractDate.ReadOnly = True
        Me.ContractDate.Width = 40
        '
        'Value
        '
        Me.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Value.DataPropertyName = "Waarde"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Value.DefaultCellStyle = DataGridViewCellStyle1
        Me.Value.HeaderText = "Cover"
        Me.Value.MinimumWidth = 60
        Me.Value.Name = "Value"
        Me.Value.ReadOnly = True
        Me.Value.Width = 61
        '
        'Premium
        '
        Me.Premium.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Premium.DataPropertyName = "Premie"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.Premium.DefaultCellStyle = DataGridViewCellStyle2
        Me.Premium.HeaderText = "Premium"
        Me.Premium.MinimumWidth = 60
        Me.Premium.Name = "Premium"
        Me.Premium.ReadOnly = True
        Me.Premium.Width = 72
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Status.DefaultCellStyle = DataGridViewCellStyle3
        Me.Status.HeaderText = "ActiveValue"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Visible = False
        Me.Status.Width = 40
        '
        'ActiveIcon
        '
        Me.ActiveIcon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ActiveIcon.DataPropertyName = "ActiveIcon"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Wingdings 2", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.ActiveIcon.DefaultCellStyle = DataGridViewCellStyle4
        Me.ActiveIcon.HeaderText = "Active"
        Me.ActiveIcon.Name = "ActiveIcon"
        Me.ActiveIcon.ReadOnly = True
        Me.ActiveIcon.Width = 50
        '
        'Cancel
        '
        Me.Cancel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.Cancel.DataPropertyName = "Kanselleer"
        Me.Cancel.HeaderText = "Cancel Date"
        Me.Cancel.Name = "Cancel"
        Me.Cancel.ReadOnly = True
        Me.Cancel.Width = 5
        '
        'Rede
        '
        Me.Rede.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Rede.DataPropertyName = "Rede"
        Me.Rede.HeaderText = "Reason"
        Me.Rede.MinimumWidth = 50
        Me.Rede.Name = "Rede"
        Me.Rede.ReadOnly = True
        '
        'dataselfoon
        '
        Me.dataselfoon.BackColor = System.Drawing.Color.Red
        Me.dataselfoon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dataselfoon.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dataselfoon.ForeColor = System.Drawing.Color.Black
        Me.dataselfoon.Location = New System.Drawing.Point(8, 193)
        Me.dataselfoon.Name = "dataselfoon"
        Me.dataselfoon.Size = New System.Drawing.Size(169, 25)
        Me.dataselfoon.TabIndex = 0
        Me.dataselfoon.Text = "dataselfoon"
        Me.dataselfoon.Visible = False
        '
        'selfoonListFrm
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(819, 221)
        Me.Controls.Add(Me.dgvCellDetails)
        Me.Controls.Add(Me.dataselfoon)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnVoegby)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "selfoonListFrm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Poldata - Policy Functions - Cell Phone"
        CType(Me.dgvCellDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvCellDetails As System.Windows.Forms.DataGridView
    Friend WithEvents pkInsCell As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Make As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Model As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CellNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContractDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Premium As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActiveIcon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cancel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rede As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class