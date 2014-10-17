<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClaimsCatastrophe
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvCatastrophe = New System.Windows.Forms.DataGridView()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnVoegby = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCatastropheName = New System.Windows.Forms.TextBox()
        Me.cmbCatastropheType = New System.Windows.Forms.ComboBox()
        Me.dtpCatastropheDate = New System.Windows.Forms.DateTimePicker()
        Me.txtCatastropheExcessAmount = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.CatastropheName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CatType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CatDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExcessAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fkKatastrofeTipes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvCatastrophe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Catastrophes"
        '
        'dgvCatastrophe
        '
        Me.dgvCatastrophe.AllowUserToAddRows = False
        Me.dgvCatastrophe.AllowUserToDeleteRows = False
        Me.dgvCatastrophe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCatastrophe.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CatastropheName, Me.CatType, Me.CatDate, Me.ExcessAmount, Me.fkKatastrofeTipes})
        Me.dgvCatastrophe.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvCatastrophe.Location = New System.Drawing.Point(23, 50)
        Me.dgvCatastrophe.MultiSelect = False
        Me.dgvCatastrophe.Name = "dgvCatastrophe"
        Me.dgvCatastrophe.ReadOnly = True
        Me.dgvCatastrophe.RowHeadersWidth = 10
        Me.dgvCatastrophe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCatastrophe.Size = New System.Drawing.Size(540, 160)
        Me.dgvCatastrophe.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(492, 351)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(77, 25)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.SystemColors.Control
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEdit.Location = New System.Drawing.Point(492, 18)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnEdit.Size = New System.Drawing.Size(67, 22)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnVoegby
        '
        Me.btnVoegby.BackColor = System.Drawing.SystemColors.Control
        Me.btnVoegby.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnVoegby.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoegby.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnVoegby.Location = New System.Drawing.Point(421, 18)
        Me.btnVoegby.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnVoegby.Name = "btnVoegby"
        Me.btnVoegby.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnVoegby.Size = New System.Drawing.Size(67, 22)
        Me.btnVoegby.TabIndex = 1
        Me.btnVoegby.Text = "Add"
        Me.btnVoegby.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 237)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 14)
        Me.Label2.TabIndex = 125
        Me.Label2.Text = "Catastrophe name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 265)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 14)
        Me.Label3.TabIndex = 126
        Me.Label3.Text = "Type"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 293)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 14)
        Me.Label4.TabIndex = 127
        Me.Label4.Text = "Catastrophe Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 320)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 14)
        Me.Label5.TabIndex = 128
        Me.Label5.Text = "Excess Amount"
        '
        'txtCatastropheName
        '
        Me.txtCatastropheName.Location = New System.Drawing.Point(161, 234)
        Me.txtCatastropheName.Name = "txtCatastropheName"
        Me.txtCatastropheName.Size = New System.Drawing.Size(221, 20)
        Me.txtCatastropheName.TabIndex = 3
        '
        'cmbCatastropheType
        '
        Me.cmbCatastropheType.FormattingEnabled = True
        Me.cmbCatastropheType.Location = New System.Drawing.Point(161, 261)
        Me.cmbCatastropheType.Name = "cmbCatastropheType"
        Me.cmbCatastropheType.Size = New System.Drawing.Size(219, 22)
        Me.cmbCatastropheType.TabIndex = 4
        '
        'dtpCatastropheDate
        '
        Me.dtpCatastropheDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCatastropheDate.Location = New System.Drawing.Point(161, 290)
        Me.dtpCatastropheDate.Name = "dtpCatastropheDate"
        Me.dtpCatastropheDate.Size = New System.Drawing.Size(96, 20)
        Me.dtpCatastropheDate.TabIndex = 5
        '
        'txtCatastropheExcessAmount
        '
        Me.txtCatastropheExcessAmount.Location = New System.Drawing.Point(161, 317)
        Me.txtCatastropheExcessAmount.Name = "txtCatastropheExcessAmount"
        Me.txtCatastropheExcessAmount.Size = New System.Drawing.Size(96, 20)
        Me.txtCatastropheExcessAmount.TabIndex = 6
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOK.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOK.Location = New System.Drawing.Point(330, 351)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOK.Size = New System.Drawing.Size(77, 25)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnApply
        '
        Me.btnApply.BackColor = System.Drawing.SystemColors.Control
        Me.btnApply.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnApply.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnApply.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApply.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnApply.Location = New System.Drawing.Point(411, 351)
        Me.btnApply.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnApply.Size = New System.Drawing.Size(77, 25)
        Me.btnApply.TabIndex = 8
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = False
        '
        'CatastropheName
        '
        Me.CatastropheName.DataPropertyName = "Naam"
        Me.CatastropheName.HeaderText = "Name"
        Me.CatastropheName.Name = "CatastropheName"
        Me.CatastropheName.ReadOnly = True
        Me.CatastropheName.Width = 180
        '
        'CatType
        '
        Me.CatType.DataPropertyName = "Beskrywing"
        Me.CatType.HeaderText = "Type"
        Me.CatType.Name = "CatType"
        Me.CatType.ReadOnly = True
        Me.CatType.Width = 150
        '
        'CatDate
        '
        Me.CatDate.DataPropertyName = "Datum"
        Me.CatDate.HeaderText = "Date"
        Me.CatDate.Name = "CatDate"
        Me.CatDate.ReadOnly = True
        Me.CatDate.Width = 75
        '
        'ExcessAmount
        '
        Me.ExcessAmount.DataPropertyName = "BybetalingsBedrag"
        Me.ExcessAmount.HeaderText = "Excess Amount"
        Me.ExcessAmount.Name = "ExcessAmount"
        Me.ExcessAmount.ReadOnly = True
        Me.ExcessAmount.Width = 120
        '
        'fkKatastrofeTipes
        '
        Me.fkKatastrofeTipes.DataPropertyName = "fkKatastrofeTipes"
        Me.fkKatastrofeTipes.HeaderText = "fkKatastrofeTipe"
        Me.fkKatastrofeTipes.MinimumWidth = 2
        Me.fkKatastrofeTipes.Name = "fkKatastrofeTipes"
        Me.fkKatastrofeTipes.ReadOnly = True
        Me.fkKatastrofeTipes.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.fkKatastrofeTipes.Width = 2
        '
        'frmClaimsCatastrophe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 386)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtCatastropheExcessAmount)
        Me.Controls.Add(Me.dtpCatastropheDate)
        Me.Controls.Add(Me.cmbCatastropheType)
        Me.Controls.Add(Me.txtCatastropheName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnVoegby)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.dgvCatastrophe)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmClaimsCatastrophe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Claims Catastrophes"
        CType(Me.dgvCatastrophe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvCatastrophe As System.Windows.Forms.DataGridView
    Public WithEvents btnCancel As System.Windows.Forms.Button
    Public WithEvents btnEdit As System.Windows.Forms.Button
    Public WithEvents btnVoegby As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCatastropheName As System.Windows.Forms.TextBox
    Friend WithEvents cmbCatastropheType As System.Windows.Forms.ComboBox
    Friend WithEvents dtpCatastropheDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCatastropheExcessAmount As System.Windows.Forms.TextBox
    Public WithEvents btnOK As System.Windows.Forms.Button
    Public WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents CatastropheName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CatType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CatDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExcessAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fkKatastrofeTipes As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
