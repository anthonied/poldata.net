<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IDSearch
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
        Me.btnIDOK = New System.Windows.Forms.Button()
        Me.btnIDCancel = New System.Windows.Forms.Button()
        Me.grdInsuredDetail = New System.Windows.Forms.DataGridView()
        Me.VERSEKERDE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VOORL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POLISNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Area_besk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActiveIcon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADRES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADRES1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADRES2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PREMIEKODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HUIS_TEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WERK_TEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.selfoon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gekans = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.grdInsuredDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnIDOK
        '
        Me.btnIDOK.Location = New System.Drawing.Point(692, 471)
        Me.btnIDOK.Name = "btnIDOK"
        Me.btnIDOK.Size = New System.Drawing.Size(45, 33)
        Me.btnIDOK.TabIndex = 0
        Me.btnIDOK.Text = "OK"
        Me.btnIDOK.UseVisualStyleBackColor = True
        '
        'btnIDCancel
        '
        Me.btnIDCancel.Location = New System.Drawing.Point(743, 471)
        Me.btnIDCancel.Name = "btnIDCancel"
        Me.btnIDCancel.Size = New System.Drawing.Size(51, 33)
        Me.btnIDCancel.TabIndex = 1
        Me.btnIDCancel.Text = "Cancel"
        Me.btnIDCancel.UseVisualStyleBackColor = True
        '
        'grdInsuredDetail
        '
        Me.grdInsuredDetail.AllowUserToAddRows = False
        Me.grdInsuredDetail.AllowUserToDeleteRows = False
        Me.grdInsuredDetail.AllowUserToOrderColumns = True
        Me.grdInsuredDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grdInsuredDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdInsuredDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VERSEKERDE, Me.VOORL, Me.POLISNO, Me.Area_besk, Me.ActiveIcon, Me.ADRES, Me.ADRES1, Me.ADRES2, Me.PREMIEKODE, Me.HUIS_TEL, Me.WERK_TEL, Me.selfoon, Me.Gekans})
        Me.grdInsuredDetail.Location = New System.Drawing.Point(9, 9)
        Me.grdInsuredDetail.Margin = New System.Windows.Forms.Padding(0)
        Me.grdInsuredDetail.Name = "grdInsuredDetail"
        Me.grdInsuredDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdInsuredDetail.Size = New System.Drawing.Size(785, 459)
        Me.grdInsuredDetail.TabIndex = 4
        '
        'VERSEKERDE
        '
        Me.VERSEKERDE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.VERSEKERDE.DataPropertyName = "VERSEKERDE"
        Me.VERSEKERDE.HeaderText = "Surname"
        Me.VERSEKERDE.Name = "VERSEKERDE"
        Me.VERSEKERDE.ReadOnly = True
        Me.VERSEKERDE.Width = 74
        '
        'VOORL
        '
        Me.VOORL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.VOORL.DataPropertyName = "VOORL"
        Me.VOORL.HeaderText = "Initials"
        Me.VOORL.MinimumWidth = 40
        Me.VOORL.Name = "VOORL"
        Me.VOORL.ReadOnly = True
        Me.VOORL.Width = 40
        '
        'POLISNO
        '
        Me.POLISNO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.POLISNO.DataPropertyName = "POLISNO"
        Me.POLISNO.HeaderText = "Policy Number"
        Me.POLISNO.MinimumWidth = 100
        Me.POLISNO.Name = "POLISNO"
        Me.POLISNO.ReadOnly = True
        '
        'Area_besk
        '
        Me.Area_besk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.Area_besk.DataPropertyName = "Area_besk"
        Me.Area_besk.HeaderText = "Area Description"
        Me.Area_besk.MinimumWidth = 65
        Me.Area_besk.Name = "Area_besk"
        Me.Area_besk.ReadOnly = True
        Me.Area_besk.Width = 65
        '
        'ActiveIcon
        '
        Me.ActiveIcon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.ActiveIcon.DataPropertyName = "ActiveIcon"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Wingdings 2", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ActiveIcon.DefaultCellStyle = DataGridViewCellStyle1
        Me.ActiveIcon.HeaderText = "Active"
        Me.ActiveIcon.MinimumWidth = 40
        Me.ActiveIcon.Name = "ActiveIcon"
        Me.ActiveIcon.Width = 40
        '
        'ADRES
        '
        Me.ADRES.DataPropertyName = "ADRES"
        Me.ADRES.HeaderText = "Street/Box"
        Me.ADRES.Name = "ADRES"
        Me.ADRES.ReadOnly = True
        Me.ADRES.Width = 83
        '
        'ADRES1
        '
        Me.ADRES1.DataPropertyName = "ADRES1"
        Me.ADRES1.HeaderText = "Suburb/Town"
        Me.ADRES1.Name = "ADRES1"
        Me.ADRES1.ReadOnly = True
        Me.ADRES1.Width = 98
        '
        'ADRES2
        '
        Me.ADRES2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ADRES2.DataPropertyName = "ADRES2"
        Me.ADRES2.HeaderText = "Code"
        Me.ADRES2.Name = "ADRES2"
        Me.ADRES2.ReadOnly = True
        Me.ADRES2.Width = 57
        '
        'PREMIEKODE
        '
        Me.PREMIEKODE.DataPropertyName = "PREMIEKODE"
        Me.PREMIEKODE.HeaderText = "Premium"
        Me.PREMIEKODE.Name = "PREMIEKODE"
        Me.PREMIEKODE.ReadOnly = True
        Me.PREMIEKODE.Visible = False
        Me.PREMIEKODE.Width = 72
        '
        'HUIS_TEL
        '
        Me.HUIS_TEL.DataPropertyName = "HUIS_TEL2"
        Me.HUIS_TEL.HeaderText = "Tel(h)"
        Me.HUIS_TEL.Name = "HUIS_TEL"
        Me.HUIS_TEL.ReadOnly = True
        Me.HUIS_TEL.Width = 59
        '
        'WERK_TEL
        '
        Me.WERK_TEL.DataPropertyName = "WERK_TEL2"
        Me.WERK_TEL.HeaderText = "Tel(w)"
        Me.WERK_TEL.Name = "WERK_TEL"
        Me.WERK_TEL.ReadOnly = True
        Me.WERK_TEL.Width = 61
        '
        'selfoon
        '
        Me.selfoon.DataPropertyName = "sel_tel"
        Me.selfoon.HeaderText = "Cellphone"
        Me.selfoon.Name = "selfoon"
        Me.selfoon.ReadOnly = True
        Me.selfoon.Width = 79
        '
        'Gekans
        '
        Me.Gekans.DataPropertyName = "Gekans"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Gekans.DefaultCellStyle = DataGridViewCellStyle2
        Me.Gekans.HeaderText = "Active Boolean"
        Me.Gekans.Name = "Gekans"
        Me.Gekans.ReadOnly = True
        Me.Gekans.Visible = False
        Me.Gekans.Width = 97
        '
        'IDSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 505)
        Me.Controls.Add(Me.grdInsuredDetail)
        Me.Controls.Add(Me.btnIDCancel)
        Me.Controls.Add(Me.btnIDOK)
        Me.Name = "IDSearch"
        Me.Text = "Insured search by ID number"
        CType(Me.grdInsuredDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnIDOK As System.Windows.Forms.Button
    Friend WithEvents btnIDCancel As System.Windows.Forms.Button
    Friend WithEvents grdInsuredDetail As System.Windows.Forms.DataGridView
    Friend WithEvents VERSEKERDE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VOORL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POLISNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Area_besk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActiveIcon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADRES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADRES1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADRES2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PREMIEKODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HUIS_TEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WERK_TEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents selfoon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gekans As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
