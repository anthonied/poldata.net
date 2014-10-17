<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClaimsBetalingsAdvies
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Frame3 = New System.Windows.Forms.Panel()
        Me.rdDrukker = New System.Windows.Forms.RadioButton()
        Me.rdEpos = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.optBegunstigde = New System.Windows.Forms.RadioButton()
        Me.optDateTime = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvBetalingsAdvies = New System.Windows.Forms.DataGridView()
        Me.begunstigde = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aksiedatum2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Batchid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bedrag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.polisno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Frame3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvBetalingsAdvies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOK.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOK.Location = New System.Drawing.Point(554, 454)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOK.Size = New System.Drawing.Size(77, 25)
        Me.btnOK.TabIndex = 18
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
        Me.btnCancel.Location = New System.Drawing.Point(635, 454)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(77, 25)
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me.rdDrukker)
        Me.Frame3.Controls.Add(Me.rdEpos)
        Me.Frame3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Frame3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(116, 429)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(229, 25)
        Me.Frame3.TabIndex = 29
        '
        'rdDrukker
        '
        Me.rdDrukker.BackColor = System.Drawing.SystemColors.Control
        Me.rdDrukker.Checked = True
        Me.rdDrukker.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdDrukker.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdDrukker.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdDrukker.Location = New System.Drawing.Point(0, 4)
        Me.rdDrukker.Name = "rdDrukker"
        Me.rdDrukker.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdDrukker.Size = New System.Drawing.Size(77, 17)
        Me.rdDrukker.TabIndex = 17
        Me.rdDrukker.TabStop = True
        Me.rdDrukker.Text = "Printer"
        Me.rdDrukker.UseVisualStyleBackColor = False
        '
        'rdEpos
        '
        Me.rdEpos.BackColor = System.Drawing.SystemColors.Control
        Me.rdEpos.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdEpos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdEpos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdEpos.Location = New System.Drawing.Point(116, 4)
        Me.rdEpos.Name = "rdEpos"
        Me.rdEpos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdEpos.Size = New System.Drawing.Size(89, 17)
        Me.rdEpos.TabIndex = 18
        Me.rdEpos.TabStop = True
        Me.rdEpos.Text = "E-mail"
        Me.rdEpos.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(12, 435)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(93, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Destination"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.optBegunstigde)
        Me.Panel1.Controls.Add(Me.optDateTime)
        Me.Panel1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Panel1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel1.Location = New System.Drawing.Point(116, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Panel1.Size = New System.Drawing.Size(242, 25)
        Me.Panel1.TabIndex = 31
        '
        'optBegunstigde
        '
        Me.optBegunstigde.BackColor = System.Drawing.SystemColors.Control
        Me.optBegunstigde.Checked = True
        Me.optBegunstigde.Cursor = System.Windows.Forms.Cursors.Default
        Me.optBegunstigde.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optBegunstigde.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optBegunstigde.Location = New System.Drawing.Point(0, 4)
        Me.optBegunstigde.Name = "optBegunstigde"
        Me.optBegunstigde.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optBegunstigde.Size = New System.Drawing.Size(110, 17)
        Me.optBegunstigde.TabIndex = 17
        Me.optBegunstigde.TabStop = True
        Me.optBegunstigde.Text = "Beneficiary"
        Me.optBegunstigde.UseVisualStyleBackColor = False
        '
        'optDateTime
        '
        Me.optDateTime.BackColor = System.Drawing.SystemColors.Control
        Me.optDateTime.Cursor = System.Windows.Forms.Cursors.Default
        Me.optDateTime.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDateTime.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optDateTime.Location = New System.Drawing.Point(116, 4)
        Me.optDateTime.Name = "optDateTime"
        Me.optDateTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optDateTime.Size = New System.Drawing.Size(113, 17)
        Me.optDateTime.TabIndex = 18
        Me.optDateTime.TabStop = True
        Me.optDateTime.Text = "Date and Time"
        Me.optDateTime.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Sort order"
        '
        'dgvBetalingsAdvies
        '
        Me.dgvBetalingsAdvies.AllowUserToAddRows = False
        Me.dgvBetalingsAdvies.AllowUserToOrderColumns = True
        Me.dgvBetalingsAdvies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBetalingsAdvies.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.begunstigde, Me.aksiedatum2, Me.Batchid, Me.bedrag, Me.polisno})
        Me.dgvBetalingsAdvies.Location = New System.Drawing.Point(17, 54)
        Me.dgvBetalingsAdvies.Name = "dgvBetalingsAdvies"
        Me.dgvBetalingsAdvies.RowHeadersWidth = 10
        Me.dgvBetalingsAdvies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBetalingsAdvies.Size = New System.Drawing.Size(694, 373)
        Me.dgvBetalingsAdvies.TabIndex = 32
        '
        'begunstigde
        '
        Me.begunstigde.DataPropertyName = "begunstigde"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.begunstigde.DefaultCellStyle = DataGridViewCellStyle1
        Me.begunstigde.HeaderText = "Beneficiary"
        Me.begunstigde.Name = "begunstigde"
        Me.begunstigde.Width = 280
        '
        'aksiedatum2
        '
        Me.aksiedatum2.DataPropertyName = "aksiedatum2"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.aksiedatum2.DefaultCellStyle = DataGridViewCellStyle2
        Me.aksiedatum2.HeaderText = "Payment Date"
        Me.aksiedatum2.Name = "aksiedatum2"
        '
        'Batchid
        '
        Me.Batchid.DataPropertyName = "Batchid"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Batchid.DefaultCellStyle = DataGridViewCellStyle3
        Me.Batchid.HeaderText = "Batch ID"
        Me.Batchid.Name = "Batchid"
        Me.Batchid.Width = 80
        '
        'bedrag
        '
        Me.bedrag.DataPropertyName = "bedrag"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.bedrag.DefaultCellStyle = DataGridViewCellStyle4
        Me.bedrag.HeaderText = "Amount"
        Me.bedrag.Name = "bedrag"
        '
        'polisno
        '
        Me.polisno.DataPropertyName = "polisno"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.polisno.DefaultCellStyle = DataGridViewCellStyle5
        Me.polisno.HeaderText = "Policynumber"
        Me.polisno.Name = "polisno"
        '
        'frmClaimsBetalingsAdvies
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 491)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvBetalingsAdvies)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmClaimsBetalingsAdvies"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payment advise"
        Me.Frame3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvBetalingsAdvies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents btnOK As System.Windows.Forms.Button
    Public WithEvents btnCancel As System.Windows.Forms.Button
    Public WithEvents Frame3 As System.Windows.Forms.Panel
    Public WithEvents rdDrukker As System.Windows.Forms.RadioButton
    Public WithEvents rdEpos As System.Windows.Forms.RadioButton
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents optBegunstigde As System.Windows.Forms.RadioButton
    Public WithEvents optDateTime As System.Windows.Forms.RadioButton
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvBetalingsAdvies As System.Windows.Forms.DataGridView
    Friend WithEvents begunstigde As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents aksiedatum2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Batchid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bedrag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents polisno As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
