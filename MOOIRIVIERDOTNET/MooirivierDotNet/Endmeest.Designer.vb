<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class Endmeest
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
    Public WithEvents cmbAreaDescription As System.Windows.Forms.ComboBox
    Public WithEvents btnEndmeestverwcmd As System.Windows.Forms.Button
    Public WithEvents btnEndmeestbyvoeg As System.Windows.Forms.Button
    Public WithEvents btnEnddetcmd As System.Windows.Forms.Button
    Public WithEvents txtEndosafreng As System.Windows.Forms.TextBox
    Public WithEvents txtEndosnaam As System.Windows.Forms.TextBox
    Public WithEvents txtEndosidentifikasie As System.Windows.Forms.TextBox
    Public WithEvents btnEndmeestcmd As System.Windows.Forms.Button
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents endmststatus As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtEndosDrukPolis = New System.Windows.Forms.TextBox()
        Me.txtEndosDrukOrals = New System.Windows.Forms.TextBox()
        Me.txtEndosdrukpolistOld = New System.Windows.Forms.TextBox()
        Me.cmbAreaDescription = New System.Windows.Forms.ComboBox()
        Me.btnEndmeestverwcmd = New System.Windows.Forms.Button()
        Me.btnEndmeestbyvoeg = New System.Windows.Forms.Button()
        Me.btnEnddetcmd = New System.Windows.Forms.Button()
        Me.txtEndosafreng = New System.Windows.Forms.TextBox()
        Me.txtEndosnaam = New System.Windows.Forms.TextBox()
        Me.txtEndosidentifikasie = New System.Windows.Forms.TextBox()
        Me.btnEndmeestcmd = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.endmststatus = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvEndorsments = New System.Windows.Forms.DataGridView()
        Me.BranchCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Endosprint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Endosidentifikasie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Endosnaam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.endosAfrEng = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndosDrukOrals = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Endosdrukoralsdonotshow = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvEndorsments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtEndosDrukPolis
        '
        Me.txtEndosDrukPolis.Location = New System.Drawing.Point(128, 478)
        Me.txtEndosDrukPolis.MaxLength = 3
        Me.txtEndosDrukPolis.Name = "txtEndosDrukPolis"
        Me.txtEndosDrukPolis.Size = New System.Drawing.Size(37, 20)
        Me.txtEndosDrukPolis.TabIndex = 21
        '
        'txtEndosDrukOrals
        '
        Me.txtEndosDrukOrals.Location = New System.Drawing.Point(128, 454)
        Me.txtEndosDrukOrals.MaxLength = 3
        Me.txtEndosDrukOrals.Name = "txtEndosDrukOrals"
        Me.txtEndosDrukOrals.Size = New System.Drawing.Size(37, 20)
        Me.txtEndosDrukOrals.TabIndex = 20
        '
        'txtEndosdrukpolistOld
        '
        Me.txtEndosdrukpolistOld.AcceptsReturn = True
        Me.txtEndosdrukpolistOld.BackColor = System.Drawing.SystemColors.Window
        Me.txtEndosdrukpolistOld.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEndosdrukpolistOld.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEndosdrukpolistOld.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEndosdrukpolistOld.Location = New System.Drawing.Point(171, 478)
        Me.txtEndosdrukpolistOld.MaxLength = 1
        Me.txtEndosdrukpolistOld.Name = "txtEndosdrukpolistOld"
        Me.txtEndosdrukpolistOld.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEndosdrukpolistOld.Size = New System.Drawing.Size(49, 20)
        Me.txtEndosdrukpolistOld.TabIndex = 19
        Me.txtEndosdrukpolistOld.Visible = False
        '
        'cmbAreaDescription
        '
        Me.cmbAreaDescription.BackColor = System.Drawing.SystemColors.Window
        Me.cmbAreaDescription.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbAreaDescription.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAreaDescription.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbAreaDescription.Location = New System.Drawing.Point(16, 22)
        Me.cmbAreaDescription.Name = "cmbAreaDescription"
        Me.cmbAreaDescription.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbAreaDescription.Size = New System.Drawing.Size(229, 22)
        Me.cmbAreaDescription.TabIndex = 0
        '
        'btnEndmeestverwcmd
        '
        Me.btnEndmeestverwcmd.BackColor = System.Drawing.SystemColors.Control
        Me.btnEndmeestverwcmd.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnEndmeestverwcmd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEndmeestverwcmd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEndmeestverwcmd.Location = New System.Drawing.Point(404, 508)
        Me.btnEndmeestverwcmd.Name = "btnEndmeestverwcmd"
        Me.btnEndmeestverwcmd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnEndmeestverwcmd.Size = New System.Drawing.Size(173, 23)
        Me.btnEndmeestverwcmd.TabIndex = 14
        Me.btnEndmeestverwcmd.Text = "Remove Endorsement Master"
        Me.btnEndmeestverwcmd.UseVisualStyleBackColor = False
        '
        'btnEndmeestbyvoeg
        '
        Me.btnEndmeestbyvoeg.BackColor = System.Drawing.SystemColors.Control
        Me.btnEndmeestbyvoeg.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnEndmeestbyvoeg.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEndmeestbyvoeg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEndmeestbyvoeg.Location = New System.Drawing.Point(14, 508)
        Me.btnEndmeestbyvoeg.Name = "btnEndmeestbyvoeg"
        Me.btnEndmeestbyvoeg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnEndmeestbyvoeg.Size = New System.Drawing.Size(171, 23)
        Me.btnEndmeestbyvoeg.TabIndex = 13
        Me.btnEndmeestbyvoeg.Text = "Add Endorsement Master"
        Me.btnEndmeestbyvoeg.UseVisualStyleBackColor = False
        '
        'btnEnddetcmd
        '
        Me.btnEnddetcmd.BackColor = System.Drawing.SystemColors.Control
        Me.btnEnddetcmd.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnEnddetcmd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnddetcmd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEnddetcmd.Location = New System.Drawing.Point(598, 508)
        Me.btnEnddetcmd.Name = "btnEnddetcmd"
        Me.btnEnddetcmd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnEnddetcmd.Size = New System.Drawing.Size(177, 23)
        Me.btnEnddetcmd.TabIndex = 12
        Me.btnEnddetcmd.Text = "Change Endorsement Details"
        Me.btnEnddetcmd.UseVisualStyleBackColor = False
        '
        'txtEndosafreng
        '
        Me.txtEndosafreng.AcceptsReturn = True
        Me.txtEndosafreng.BackColor = System.Drawing.SystemColors.Window
        Me.txtEndosafreng.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEndosafreng.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEndosafreng.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEndosafreng.Location = New System.Drawing.Point(128, 432)
        Me.txtEndosafreng.MaxLength = 10
        Me.txtEndosafreng.Name = "txtEndosafreng"
        Me.txtEndosafreng.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEndosafreng.Size = New System.Drawing.Size(177, 20)
        Me.txtEndosafreng.TabIndex = 4
        '
        'txtEndosnaam
        '
        Me.txtEndosnaam.AcceptsReturn = True
        Me.txtEndosnaam.BackColor = System.Drawing.SystemColors.Window
        Me.txtEndosnaam.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEndosnaam.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEndosnaam.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEndosnaam.Location = New System.Drawing.Point(128, 410)
        Me.txtEndosnaam.MaxLength = 200
        Me.txtEndosnaam.Name = "txtEndosnaam"
        Me.txtEndosnaam.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEndosnaam.Size = New System.Drawing.Size(442, 20)
        Me.txtEndosnaam.TabIndex = 3
        '
        'txtEndosidentifikasie
        '
        Me.txtEndosidentifikasie.AcceptsReturn = True
        Me.txtEndosidentifikasie.BackColor = System.Drawing.SystemColors.Window
        Me.txtEndosidentifikasie.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEndosidentifikasie.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEndosidentifikasie.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEndosidentifikasie.Location = New System.Drawing.Point(128, 386)
        Me.txtEndosidentifikasie.MaxLength = 5
        Me.txtEndosidentifikasie.Name = "txtEndosidentifikasie"
        Me.txtEndosidentifikasie.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEndosidentifikasie.Size = New System.Drawing.Size(49, 20)
        Me.txtEndosidentifikasie.TabIndex = 2
        '
        'btnEndmeestcmd
        '
        Me.btnEndmeestcmd.BackColor = System.Drawing.SystemColors.Control
        Me.btnEndmeestcmd.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnEndmeestcmd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEndmeestcmd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEndmeestcmd.Location = New System.Drawing.Point(206, 508)
        Me.btnEndmeestcmd.Name = "btnEndmeestcmd"
        Me.btnEndmeestcmd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnEndmeestcmd.Size = New System.Drawing.Size(177, 23)
        Me.btnEndmeestcmd.TabIndex = 11
        Me.btnEndmeestcmd.Text = "Change Endorsement Master"
        Me.btnEndmeestcmd.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Area"
        '
        'endmststatus
        '
        Me.endmststatus.BackColor = System.Drawing.SystemColors.Control
        Me.endmststatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.endmststatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.endmststatus.Font = New System.Drawing.Font("Californian FB", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.endmststatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.endmststatus.Location = New System.Drawing.Point(438, 8)
        Me.endmststatus.Name = "endmststatus"
        Me.endmststatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.endmststatus.Size = New System.Drawing.Size(337, 25)
        Me.endmststatus.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(16, 481)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(174, 19)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Print on this policy"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 457)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(203, 18)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Print on all policies"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(16, 435)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(161, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Language "
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 411)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(161, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Name"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 387)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(177, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Identification"
        '
        'dgvEndorsments
        '
        Me.dgvEndorsments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEndorsments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BranchCode, Me.Endosprint, Me.Endosidentifikasie, Me.Endosnaam, Me.endosAfrEng, Me.EndosDrukOrals, Me.Endosdrukoralsdonotshow})
        Me.dgvEndorsments.Location = New System.Drawing.Point(16, 49)
        Me.dgvEndorsments.Name = "dgvEndorsments"
        Me.dgvEndorsments.RowHeadersWidth = 5
        Me.dgvEndorsments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEndorsments.Size = New System.Drawing.Size(758, 317)
        Me.dgvEndorsments.TabIndex = 22
        '
        'BranchCode
        '
        Me.BranchCode.DataPropertyName = "branchcode"
        Me.BranchCode.HeaderText = "BranchCode"
        Me.BranchCode.Name = "BranchCode"
        Me.BranchCode.Visible = False
        '
        'Endosprint
        '
        Me.Endosprint.DataPropertyName = "endosprint"
        Me.Endosprint.HeaderText = "Endosprint"
        Me.Endosprint.Name = "Endosprint"
        Me.Endosprint.Visible = False
        '
        'Endosidentifikasie
        '
        Me.Endosidentifikasie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Endosidentifikasie.DataPropertyName = "endosidentifikasie"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Endosidentifikasie.DefaultCellStyle = DataGridViewCellStyle1
        Me.Endosidentifikasie.HeaderText = "Endorsement"
        Me.Endosidentifikasie.Name = "Endosidentifikasie"
        Me.Endosidentifikasie.Width = 95
        '
        'Endosnaam
        '
        Me.Endosnaam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Endosnaam.DataPropertyName = "endosnaam"
        Me.Endosnaam.HeaderText = "Description"
        Me.Endosnaam.Name = "Endosnaam"
        '
        'endosAfrEng
        '
        Me.endosAfrEng.DataPropertyName = "endosafreng"
        Me.endosAfrEng.HeaderText = "Language"
        Me.endosAfrEng.Name = "endosAfrEng"
        '
        'EndosDrukOrals
        '
        Me.EndosDrukOrals.DataPropertyName = "endosdrukorals"
        Me.EndosDrukOrals.HeaderText = "Print location"
        Me.EndosDrukOrals.Name = "EndosDrukOrals"
        '
        'Endosdrukoralsdonotshow
        '
        Me.Endosdrukoralsdonotshow.DataPropertyName = "endosdrukorals"
        Me.Endosdrukoralsdonotshow.HeaderText = "Print"
        Me.Endosdrukoralsdonotshow.Name = "Endosdrukoralsdonotshow"
        Me.Endosdrukoralsdonotshow.Visible = False
        '
        'Endmeest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(791, 542)
        Me.Controls.Add(Me.dgvEndorsments)
        Me.Controls.Add(Me.txtEndosDrukPolis)
        Me.Controls.Add(Me.txtEndosDrukOrals)
        Me.Controls.Add(Me.txtEndosdrukpolistOld)
        Me.Controls.Add(Me.cmbAreaDescription)
        Me.Controls.Add(Me.btnEndmeestverwcmd)
        Me.Controls.Add(Me.btnEndmeestbyvoeg)
        Me.Controls.Add(Me.btnEnddetcmd)
        Me.Controls.Add(Me.txtEndosafreng)
        Me.Controls.Add(Me.txtEndosnaam)
        Me.Controls.Add(Me.txtEndosidentifikasie)
        Me.Controls.Add(Me.btnEndmeestcmd)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.endmststatus)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "Endmeest"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Endossement meester"
        CType(Me.dgvEndorsments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents txtEndosdrukpolistOld As System.Windows.Forms.TextBox
    Friend WithEvents txtEndosDrukOrals As System.Windows.Forms.TextBox
    Friend WithEvents txtEndosDrukPolis As System.Windows.Forms.TextBox
    Friend WithEvents dgvEndorsments As System.Windows.Forms.DataGridView
    Friend WithEvents BranchCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Endosprint As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Endosidentifikasie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Endosnaam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents endosAfrEng As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndosDrukOrals As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Endosdrukoralsdonotshow As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class