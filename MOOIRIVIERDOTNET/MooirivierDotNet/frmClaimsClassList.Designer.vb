<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClaimsClassList
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvClassList = New System.Windows.Forms.DataGridView()
        Me.pkItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InsuredClass = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InsuredItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SerialNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cover = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Afdeling = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvClassList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOK.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOK.Location = New System.Drawing.Point(604, 373)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOK.Size = New System.Drawing.Size(77, 25)
        Me.btnOK.TabIndex = 19
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(685, 373)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(77, 25)
        Me.btnCancel.TabIndex = 21
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 14)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Class list"
        '
        'dgvClassList
        '
        Me.dgvClassList.AllowUserToAddRows = False
        Me.dgvClassList.AllowUserToDeleteRows = False
        Me.dgvClassList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClassList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pkItem, Me.InsuredClass, Me.InsuredItem, Me.SerialNumber, Me.Cover, Me.Afdeling})
        Me.dgvClassList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvClassList.Location = New System.Drawing.Point(18, 33)
        Me.dgvClassList.Name = "dgvClassList"
        Me.dgvClassList.RowHeadersWidth = 5
        Me.dgvClassList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvClassList.Size = New System.Drawing.Size(739, 326)
        Me.dgvClassList.TabIndex = 23
        '
        'pkItem
        '
        Me.pkItem.HeaderText = "pkItem"
        Me.pkItem.Name = "pkItem"
        Me.pkItem.Visible = False
        '
        'InsuredClass
        '
        Me.InsuredClass.HeaderText = "InsuredClass"
        Me.InsuredClass.Name = "InsuredClass"
        Me.InsuredClass.Width = 150
        '
        'InsuredItem
        '
        Me.InsuredItem.HeaderText = "Insured Item"
        Me.InsuredItem.Name = "InsuredItem"
        Me.InsuredItem.Width = 250
        '
        'SerialNumber
        '
        Me.SerialNumber.HeaderText = "Numberplate/Serialnumber"
        Me.SerialNumber.Name = "SerialNumber"
        Me.SerialNumber.Width = 150
        '
        'Cover
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Cover.DefaultCellStyle = DataGridViewCellStyle1
        Me.Cover.HeaderText = "Cover"
        Me.Cover.Name = "Cover"
        '
        'Afdeling
        '
        Me.Afdeling.HeaderText = "Afdeling"
        Me.Afdeling.Name = "Afdeling"
        Me.Afdeling.Visible = False
        Me.Afdeling.Width = 5
        '
        'frmClaimsClassList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(769, 410)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvClassList)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmClaimsClassList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Claims Class List"
        CType(Me.dgvClassList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents btnOK As System.Windows.Forms.Button
    Public WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvClassList As System.Windows.Forms.DataGridView
    Friend WithEvents pkItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InsuredClass As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InsuredItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cover As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Afdeling As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
