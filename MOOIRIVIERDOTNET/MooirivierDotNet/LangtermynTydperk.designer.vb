<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class LangtermynTydperk
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
    Public WithEvents cmbTydperk As System.Windows.Forms.ComboBox
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents btnOk As System.Windows.Forms.Button
    Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents lblDatum As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmbTydperk = New System.Windows.Forms.ComboBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDatum = New System.Windows.Forms.Label()
        Me.dtpBegin = New System.Windows.Forms.DateTimePicker()
        Me.dtpEindig = New System.Windows.Forms.DateTimePicker()
        Me.grpTermynTydperk = New System.Windows.Forms.GroupBox()
        Me.grpTermynTydperk.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbTydperk
        '
        Me.cmbTydperk.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTydperk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTydperk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTydperk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTydperk.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbTydperk.Items.AddRange(New Object() {"2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cmbTydperk.Location = New System.Drawing.Point(191, 59)
        Me.cmbTydperk.Name = "cmbTydperk"
        Me.cmbTydperk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbTydperk.Size = New System.Drawing.Size(41, 22)
        Me.cmbTydperk.TabIndex = 7
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(285, 167)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(85, 25)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Location = New System.Drawing.Point(194, 167)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New System.Drawing.Size(85, 25)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "&Ok"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(22, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(109, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Number of months"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(22, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "End"
        '
        'lblDatum
        '
        Me.lblDatum.BackColor = System.Drawing.SystemColors.Control
        Me.lblDatum.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDatum.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatum.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDatum.Location = New System.Drawing.Point(22, 35)
        Me.lblDatum.Name = "lblDatum"
        Me.lblDatum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDatum.Size = New System.Drawing.Size(109, 13)
        Me.lblDatum.TabIndex = 4
        Me.lblDatum.Text = "Begin"
        '
        'dtpBegin
        '
        Me.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBegin.Location = New System.Drawing.Point(191, 30)
        Me.dtpBegin.Name = "dtpBegin"
        Me.dtpBegin.Size = New System.Drawing.Size(126, 20)
        Me.dtpBegin.TabIndex = 10
        '
        'dtpEindig
        '
        Me.dtpEindig.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEindig.Location = New System.Drawing.Point(191, 90)
        Me.dtpEindig.Name = "dtpEindig"
        Me.dtpEindig.Size = New System.Drawing.Size(127, 20)
        Me.dtpEindig.TabIndex = 11
        '
        'grpTermynTydperk
        '
        Me.grpTermynTydperk.Controls.Add(Me.lblDatum)
        Me.grpTermynTydperk.Controls.Add(Me.dtpEindig)
        Me.grpTermynTydperk.Controls.Add(Me.Label1)
        Me.grpTermynTydperk.Controls.Add(Me.dtpBegin)
        Me.grpTermynTydperk.Controls.Add(Me.cmbTydperk)
        Me.grpTermynTydperk.Controls.Add(Me.Label2)
        Me.grpTermynTydperk.Location = New System.Drawing.Point(16, 16)
        Me.grpTermynTydperk.Name = "grpTermynTydperk"
        Me.grpTermynTydperk.Size = New System.Drawing.Size(354, 145)
        Me.grpTermynTydperk.TabIndex = 12
        Me.grpTermynTydperk.TabStop = False
        Me.grpTermynTydperk.Text = "Term Policy Period"
        '
        'LangtermynTydperk
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(389, 203)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpTermynTydperk)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 30)
        Me.Name = "LangtermynTydperk"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Poldata - term policy - Period"
        Me.grpTermynTydperk.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtpBegin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEindig As System.Windows.Forms.DateTimePicker
    Friend WithEvents grpTermynTydperk As System.Windows.Forms.GroupBox
#End Region 
End Class