<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class KMemoFrm
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
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents Memo As System.Windows.Forms.TextBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.Memo = New System.Windows.Forms.TextBox()
        Me.grpClientMemo = New System.Windows.Forms.GroupBox()
        Me.grpClientMemo.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(412, 279)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(81, 23)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(324, 279)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(81, 23)
        Me.Command1.TabIndex = 1
        Me.Command1.Text = "&Ok"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'Memo
        '
        Me.Memo.AcceptsReturn = True
        Me.Memo.BackColor = System.Drawing.SystemColors.Window
        Me.Memo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Memo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Memo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Memo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Memo.Location = New System.Drawing.Point(6, 18)
        Me.Memo.MaxLength = 0
        Me.Memo.Multiline = True
        Me.Memo.Name = "Memo"
        Me.Memo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Memo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Memo.Size = New System.Drawing.Size(449, 220)
        Me.Memo.TabIndex = 0
        Me.Memo.Text = "Text1"
        '
        'grpClientMemo
        '
        Me.grpClientMemo.Controls.Add(Me.Memo)
        Me.grpClientMemo.Location = New System.Drawing.Point(16, 15)
        Me.grpClientMemo.Name = "grpClientMemo"
        Me.grpClientMemo.Size = New System.Drawing.Size(477, 258)
        Me.grpClientMemo.TabIndex = 3
        Me.grpClientMemo.TabStop = False
        '
        'KMemoFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(505, 311)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpClientMemo)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.Command1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(73, 101)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "KMemoFrm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Client Memo"
        Me.grpClientMemo.ResumeLayout(False)
        Me.grpClientMemo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpClientMemo As System.Windows.Forms.GroupBox
#End Region 
End Class