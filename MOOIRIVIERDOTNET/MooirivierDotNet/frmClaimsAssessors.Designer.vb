<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClaimsAssessors
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClaimsAssessors))
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnVoegby = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvAssessors = New System.Windows.Forms.DataGridView()
        Me.pkAssessor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AssessorName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AssessorCell = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AssessorEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtAddress1 = New System.Windows.Forms.TextBox()
        Me.txtAddress2 = New System.Windows.Forms.TextBox()
        Me.txtSubburb = New System.Windows.Forms.TextBox()
        Me.txtTown = New System.Windows.Forms.TextBox()
        Me.txtPostalCode = New System.Windows.Forms.TextBox()
        Me.txtAssessor = New System.Windows.Forms.TextBox()
        Me.txtCellnr = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtTelnr = New System.Windows.Forms.TextBox()
        Me.txtFaxnr = New System.Windows.Forms.TextBox()
        Me.chkBeneficiary = New System.Windows.Forms.CheckBox()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.cmdPostalCodes = New System.Windows.Forms.Button()
        Me.btnSoek = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        CType(Me.dgvAssessors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.SystemColors.Control
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEdit.Location = New System.Drawing.Point(493, 22)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnEdit.Size = New System.Drawing.Size(67, 22)
        Me.btnEdit.TabIndex = 4
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnVoegby
        '
        Me.btnVoegby.BackColor = System.Drawing.SystemColors.Control
        Me.btnVoegby.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnVoegby.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoegby.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnVoegby.Location = New System.Drawing.Point(422, 22)
        Me.btnVoegby.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnVoegby.Name = "btnVoegby"
        Me.btnVoegby.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnVoegby.Size = New System.Drawing.Size(67, 22)
        Me.btnVoegby.TabIndex = 3
        Me.btnVoegby.Text = "Add"
        Me.btnVoegby.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(490, 388)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(77, 25)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 14)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Assessors"
        '
        'dgvAssessors
        '
        Me.dgvAssessors.AllowUserToAddRows = False
        Me.dgvAssessors.AllowUserToDeleteRows = False
        Me.dgvAssessors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAssessors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pkAssessor, Me.AssessorName, Me.AssessorCell, Me.AssessorEmail})
        Me.dgvAssessors.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvAssessors.Location = New System.Drawing.Point(23, 50)
        Me.dgvAssessors.Name = "dgvAssessors"
        Me.dgvAssessors.ReadOnly = True
        Me.dgvAssessors.RowHeadersWidth = 5
        Me.dgvAssessors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAssessors.Size = New System.Drawing.Size(540, 160)
        Me.dgvAssessors.TabIndex = 5
        '
        'pkAssessor
        '
        Me.pkAssessor.DataPropertyName = "pkAssessor"
        Me.pkAssessor.HeaderText = "pkAssessor"
        Me.pkAssessor.Name = "pkAssessor"
        Me.pkAssessor.ReadOnly = True
        Me.pkAssessor.Visible = False
        '
        'AssessorName
        '
        Me.AssessorName.DataPropertyName = "AssessorName"
        Me.AssessorName.HeaderText = "Name"
        Me.AssessorName.Name = "AssessorName"
        Me.AssessorName.ReadOnly = True
        Me.AssessorName.Width = 200
        '
        'AssessorCell
        '
        Me.AssessorCell.DataPropertyName = "AssessorCell"
        Me.AssessorCell.HeaderText = "Cellphone nr"
        Me.AssessorCell.Name = "AssessorCell"
        Me.AssessorCell.ReadOnly = True
        '
        'AssessorEmail
        '
        Me.AssessorEmail.DataPropertyName = "AssessorEmail"
        Me.AssessorEmail.HeaderText = "Email"
        Me.AssessorEmail.Name = "AssessorEmail"
        Me.AssessorEmail.ReadOnly = True
        Me.AssessorEmail.Width = 200
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 234)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 14)
        Me.Label2.TabIndex = 131
        Me.Label2.Text = "Assessor"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 338)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 14)
        Me.Label3.TabIndex = 132
        Me.Label3.Text = "Fax no"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 286)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 14)
        Me.Label4.TabIndex = 133
        Me.Label4.Text = "Email address"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 260)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 14)
        Me.Label5.TabIndex = 134
        Me.Label5.Text = "Cellphone no"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(27, 312)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 14)
        Me.Label6.TabIndex = 135
        Me.Label6.Text = "Tel no"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(336, 234)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 14)
        Me.Label7.TabIndex = 136
        Me.Label7.Text = "Address"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(336, 260)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 14)
        Me.Label8.TabIndex = 137
        Me.Label8.Text = "Address"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(336, 286)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 14)
        Me.Label9.TabIndex = 138
        Me.Label9.Text = "Suburb"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(336, 312)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 14)
        Me.Label10.TabIndex = 139
        Me.Label10.Text = "Town"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(336, 338)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 14)
        Me.Label11.TabIndex = 140
        Me.Label11.Text = "Postal code"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(27, 363)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 14)
        Me.Label12.TabIndex = 141
        Me.Label12.Text = "Beneficiary"
        '
        'txtAddress1
        '
        Me.txtAddress1.Location = New System.Drawing.Point(406, 231)
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(156, 20)
        Me.txtAddress1.TabIndex = 11
        '
        'txtAddress2
        '
        Me.txtAddress2.Location = New System.Drawing.Point(407, 257)
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(156, 20)
        Me.txtAddress2.TabIndex = 12
        '
        'txtSubburb
        '
        Me.txtSubburb.Enabled = False
        Me.txtSubburb.Location = New System.Drawing.Point(407, 283)
        Me.txtSubburb.Name = "txtSubburb"
        Me.txtSubburb.Size = New System.Drawing.Size(156, 20)
        Me.txtSubburb.TabIndex = 13
        '
        'txtTown
        '
        Me.txtTown.Enabled = False
        Me.txtTown.Location = New System.Drawing.Point(407, 309)
        Me.txtTown.Name = "txtTown"
        Me.txtTown.Size = New System.Drawing.Size(156, 20)
        Me.txtTown.TabIndex = 145
        '
        'txtPostalCode
        '
        Me.txtPostalCode.Enabled = False
        Me.txtPostalCode.Location = New System.Drawing.Point(407, 335)
        Me.txtPostalCode.Name = "txtPostalCode"
        Me.txtPostalCode.Size = New System.Drawing.Size(49, 20)
        Me.txtPostalCode.TabIndex = 146
        '
        'txtAssessor
        '
        Me.txtAssessor.Location = New System.Drawing.Point(104, 231)
        Me.txtAssessor.Name = "txtAssessor"
        Me.txtAssessor.Size = New System.Drawing.Size(226, 20)
        Me.txtAssessor.TabIndex = 6
        '
        'txtCellnr
        '
        Me.txtCellnr.Location = New System.Drawing.Point(104, 257)
        Me.txtCellnr.Name = "txtCellnr"
        Me.txtCellnr.Size = New System.Drawing.Size(97, 20)
        Me.txtCellnr.TabIndex = 7
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(104, 283)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(226, 20)
        Me.txtEmail.TabIndex = 8
        '
        'txtTelnr
        '
        Me.txtTelnr.Location = New System.Drawing.Point(104, 309)
        Me.txtTelnr.Name = "txtTelnr"
        Me.txtTelnr.Size = New System.Drawing.Size(97, 20)
        Me.txtTelnr.TabIndex = 9
        '
        'txtFaxnr
        '
        Me.txtFaxnr.Location = New System.Drawing.Point(104, 335)
        Me.txtFaxnr.Name = "txtFaxnr"
        Me.txtFaxnr.Size = New System.Drawing.Size(97, 20)
        Me.txtFaxnr.TabIndex = 10
        '
        'chkBeneficiary
        '
        Me.chkBeneficiary.AutoSize = True
        Me.chkBeneficiary.Location = New System.Drawing.Point(104, 363)
        Me.chkBeneficiary.Name = "chkBeneficiary"
        Me.chkBeneficiary.Size = New System.Drawing.Size(15, 14)
        Me.chkBeneficiary.TabIndex = 152
        Me.chkBeneficiary.UseVisualStyleBackColor = True
        '
        'btnApply
        '
        Me.btnApply.BackColor = System.Drawing.SystemColors.Control
        Me.btnApply.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnApply.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnApply.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApply.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnApply.Location = New System.Drawing.Point(410, 388)
        Me.btnApply.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnApply.Size = New System.Drawing.Size(77, 25)
        Me.btnApply.TabIndex = 15
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOK.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOK.Location = New System.Drawing.Point(329, 388)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOK.Size = New System.Drawing.Size(77, 25)
        Me.btnOK.TabIndex = 14
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'cmdPostalCodes
        '
        Me.cmdPostalCodes.Location = New System.Drawing.Point(476, 333)
        Me.cmdPostalCodes.Name = "cmdPostalCodes"
        Me.cmdPostalCodes.Size = New System.Drawing.Size(87, 22)
        Me.cmdPostalCodes.TabIndex = 13
        Me.cmdPostalCodes.Text = "Postalcodes"
        Me.cmdPostalCodes.UseVisualStyleBackColor = True
        '
        'btnSoek
        '
        Me.btnSoek.BackgroundImage = CType(resources.GetObject("btnSoek.BackgroundImage"), System.Drawing.Image)
        Me.btnSoek.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSoek.Location = New System.Drawing.Point(391, 23)
        Me.btnSoek.Name = "btnSoek"
        Me.btnSoek.Size = New System.Drawing.Size(20, 20)
        Me.btnSoek.TabIndex = 2
        Me.btnSoek.TabStop = False
        Me.btnSoek.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(160, 23)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(225, 20)
        Me.txtSearch.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(121, 363)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(140, 14)
        Me.Label13.TabIndex = 153
        Me.Label13.Text = "Please link from Beneficiary"
        '
        'frmClaimsAssessors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 419)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnSoek)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.cmdPostalCodes)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.chkBeneficiary)
        Me.Controls.Add(Me.txtFaxnr)
        Me.Controls.Add(Me.txtTelnr)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtCellnr)
        Me.Controls.Add(Me.txtAssessor)
        Me.Controls.Add(Me.txtPostalCode)
        Me.Controls.Add(Me.txtTown)
        Me.Controls.Add(Me.txtSubburb)
        Me.Controls.Add(Me.txtAddress2)
        Me.Controls.Add(Me.txtAddress1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnVoegby)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvAssessors)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmClaimsAssessors"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Assessors"
        CType(Me.dgvAssessors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents btnEdit As System.Windows.Forms.Button
    Public WithEvents btnVoegby As System.Windows.Forms.Button
    Public WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvAssessors As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtSubburb As System.Windows.Forms.TextBox
    Friend WithEvents txtTown As System.Windows.Forms.TextBox
    Friend WithEvents txtPostalCode As System.Windows.Forms.TextBox
    Friend WithEvents txtAssessor As System.Windows.Forms.TextBox
    Friend WithEvents txtCellnr As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtTelnr As System.Windows.Forms.TextBox
    Friend WithEvents txtFaxnr As System.Windows.Forms.TextBox
    Friend WithEvents chkBeneficiary As System.Windows.Forms.CheckBox
    Public WithEvents btnApply As System.Windows.Forms.Button
    Public WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents cmdPostalCodes As System.Windows.Forms.Button
    Friend WithEvents btnSoek As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents pkAssessor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssessorName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssessorCell As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssessorEmail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
