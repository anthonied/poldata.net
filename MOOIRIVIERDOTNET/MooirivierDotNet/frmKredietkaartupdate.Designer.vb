<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmKredietkaartupdate
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
	Public CommonDialog1Open As System.Windows.Forms.OpenFileDialog
	Public WithEvents btnBrowse As System.Windows.Forms.Button
	Public WithEvents txtPath As System.Windows.Forms.TextBox
	Public WithEvents listStatus As System.Windows.Forms.ListBox
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents btnOk As System.Windows.Forms.Button
    Public WithEvents lblGetFile As System.Windows.Forms.Label
    Public WithEvents lblHeading As System.Windows.Forms.Label
    Public WithEvents lblUpdateResult As System.Windows.Forms.Label
    Public WithEvents lblProgress As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents lblUpdateWillDo As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKredietkaartupdate))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CommonDialog1Open = New System.Windows.Forms.OpenFileDialog()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.listStatus = New System.Windows.Forms.ListBox()
        Me.lblGetFile = New System.Windows.Forms.Label()
        Me.lblHeading = New System.Windows.Forms.Label()
        Me.lblUpdateResult = New System.Windows.Forms.Label()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblUpdateWillDo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CommonDialog1Open
        '
        Me.CommonDialog1Open.DefaultExt = "xl*"
        Me.CommonDialog1Open.Filter = "Microsoft Excel Worksheet (*.xl*)|*.xl*"
        Me.CommonDialog1Open.InitialDirectory = "c:\polis5admin\updates"
        Me.CommonDialog1Open.Title = "Select the Credit Card file."
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Location = New System.Drawing.Point(277, 233)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New System.Drawing.Size(85, 25)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(371, 233)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(85, 25)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnBrowse
        '
        Me.btnBrowse.BackColor = System.Drawing.SystemColors.Control
        Me.btnBrowse.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnBrowse.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBrowse.Location = New System.Drawing.Point(389, 58)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnBrowse.Size = New System.Drawing.Size(67, 20)
        Me.btnBrowse.TabIndex = 11
        Me.btnBrowse.Text = "Select file"
        Me.btnBrowse.UseVisualStyleBackColor = False
        '
        'txtPath
        '
        Me.txtPath.AcceptsReturn = True
        Me.txtPath.BackColor = System.Drawing.SystemColors.Window
        Me.txtPath.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPath.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPath.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPath.Location = New System.Drawing.Point(16, 60)
        Me.txtPath.MaxLength = 0
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPath.Size = New System.Drawing.Size(345, 20)
        Me.txtPath.TabIndex = 10
        '
        'listStatus
        '
        Me.listStatus.BackColor = System.Drawing.SystemColors.Window
        Me.listStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.listStatus.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.listStatus.ItemHeight = 14
        Me.listStatus.Location = New System.Drawing.Point(16, 110)
        Me.listStatus.Name = "listStatus"
        Me.listStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.listStatus.Size = New System.Drawing.Size(440, 88)
        Me.listStatus.TabIndex = 6
        Me.listStatus.Visible = False
        '
        'lblGetFile
        '
        Me.lblGetFile.BackColor = System.Drawing.Color.Transparent
        Me.lblGetFile.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblGetFile.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGetFile.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGetFile.Location = New System.Drawing.Point(16, 38)
        Me.lblGetFile.Name = "lblGetFile"
        Me.lblGetFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblGetFile.Size = New System.Drawing.Size(441, 22)
        Me.lblGetFile.TabIndex = 9
        Me.lblGetFile.Text = "To do the update, you must select the Credit card file."
        '
        'lblHeading
        '
        Me.lblHeading.BackColor = System.Drawing.Color.Transparent
        Me.lblHeading.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHeading.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHeading.Location = New System.Drawing.Point(16, 16)
        Me.lblHeading.Name = "lblHeading"
        Me.lblHeading.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHeading.Size = New System.Drawing.Size(137, 17)
        Me.lblHeading.TabIndex = 2
        Me.lblHeading.Text = "Credit Card Update"
        '
        'lblUpdateResult
        '
        Me.lblUpdateResult.BackColor = System.Drawing.Color.Transparent
        Me.lblUpdateResult.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblUpdateResult.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdateResult.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUpdateResult.Location = New System.Drawing.Point(16, 209)
        Me.lblUpdateResult.Name = "lblUpdateResult"
        Me.lblUpdateResult.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblUpdateResult.Size = New System.Drawing.Size(129, 21)
        Me.lblUpdateResult.TabIndex = 8
        Me.lblUpdateResult.Text = "Number of Credit cards:"
        '
        'lblProgress
        '
        Me.lblProgress.BackColor = System.Drawing.Color.Transparent
        Me.lblProgress.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblProgress.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgress.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProgress.Location = New System.Drawing.Point(150, 209)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblProgress.Size = New System.Drawing.Size(114, 21)
        Me.lblProgress.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 176)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(513, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Update the credit card table"
        '
        'lblUpdateWillDo
        '
        Me.lblUpdateWillDo.BackColor = System.Drawing.Color.Transparent
        Me.lblUpdateWillDo.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblUpdateWillDo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdateWillDo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUpdateWillDo.Location = New System.Drawing.Point(16, 89)
        Me.lblUpdateWillDo.Name = "lblUpdateWillDo"
        Me.lblUpdateWillDo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblUpdateWillDo.Size = New System.Drawing.Size(415, 19)
        Me.lblUpdateWillDo.TabIndex = 4
        Me.lblUpdateWillDo.Text = "This update will do the following:"
        '
        'frmKredietkaartupdate
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(476, 276)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.listStatus)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.lblGetFile)
        Me.Controls.Add(Me.lblHeading)
        Me.Controls.Add(Me.lblUpdateResult)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblUpdateWillDo)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmKredietkaartupdate"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "     Credit Card Update"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class