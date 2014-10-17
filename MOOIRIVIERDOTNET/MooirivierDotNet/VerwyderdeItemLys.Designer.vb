<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class VerwyderdeItemLys
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
	Public WithEvents btnHerstel As System.Windows.Forms.Button
	Public WithEvents btnCancel As System.Windows.Forms.Button
    Public WithEvents DataVerwyderdeItems As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnHerstel = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.DataVerwyderdeItems = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridVerwyderdeVoertuie = New System.Windows.Forms.DataGridView()
        CType(Me.GridVerwyderdeVoertuie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnHerstel
        '
        Me.btnHerstel.BackColor = System.Drawing.SystemColors.Control
        Me.btnHerstel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnHerstel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHerstel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnHerstel.Location = New System.Drawing.Point(496, 288)
        Me.btnHerstel.Name = "btnHerstel"
        Me.btnHerstel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnHerstel.Size = New System.Drawing.Size(77, 25)
        Me.btnHerstel.TabIndex = 2
        Me.btnHerstel.Text = "&Restore"
        Me.ToolTip1.SetToolTip(Me.btnHerstel, "Herstel voertuig na polis")
        Me.btnHerstel.UseVisualStyleBackColor = False
        Me.btnHerstel.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(576, 288)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(77, 25)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Close"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'DataVerwyderdeItems
        '
        Me.DataVerwyderdeItems.BackColor = System.Drawing.Color.Red
        Me.DataVerwyderdeItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DataVerwyderdeItems.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataVerwyderdeItems.ForeColor = System.Drawing.Color.Black
        Me.DataVerwyderdeItems.Location = New System.Drawing.Point(12, 288)
        Me.DataVerwyderdeItems.Name = "DataVerwyderdeItems"
        Me.DataVerwyderdeItems.Size = New System.Drawing.Size(193, 23)
        Me.DataVerwyderdeItems.TabIndex = 3
        Me.DataVerwyderdeItems.Text = "Deleted Items"
        Me.DataVerwyderdeItems.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(12, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(633, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Note: From February 20, 2006, all deleted items are retained regardless of whethe" & _
    "r a claim was registered or not."
        '
        'GridVerwyderdeVoertuie
        '
        Me.GridVerwyderdeVoertuie.AllowUserToResizeColumns = False
        Me.GridVerwyderdeVoertuie.AllowUserToResizeRows = False
        Me.GridVerwyderdeVoertuie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridVerwyderdeVoertuie.EnableHeadersVisualStyles = False
        Me.GridVerwyderdeVoertuie.Location = New System.Drawing.Point(15, 42)
        Me.GridVerwyderdeVoertuie.Name = "GridVerwyderdeVoertuie"
        Me.GridVerwyderdeVoertuie.RowHeadersVisible = False
        Me.GridVerwyderdeVoertuie.Size = New System.Drawing.Size(604, 243)
        Me.GridVerwyderdeVoertuie.TabIndex = 4
        '
        'VerwyderdeItemLys
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(665, 321)
        Me.ControlBox = False
        Me.Controls.Add(Me.GridVerwyderdeVoertuie)
        Me.Controls.Add(Me.btnHerstel)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.DataVerwyderdeItems)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 30)
        Me.Name = "VerwyderdeItemLys"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Deleted Item List"
        CType(Me.GridVerwyderdeVoertuie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridVerwyderdeVoertuie As System.Windows.Forms.DataGridView
#End Region 
End Class