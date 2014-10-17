<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class emailEngine
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
	Public WithEvents txtTo As System.Windows.Forms.TextBox
	Public CommonDialog1Open As System.Windows.Forms.OpenFileDialog
	Public WithEvents btnHelp As System.Windows.Forms.Button
	Public WithEvents btnVerwyder As System.Windows.Forms.Button
	Public WithEvents lstAanhangsels As System.Windows.Forms.ListBox
	Public WithEvents btnSoek As System.Windows.Forms.Button
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents btnOk As System.Windows.Forms.Button
    'Linkie 29/08/2014 Public WithEvents MAPIMessage1 As AxMSMAPI.AxMAPIMessages
    'Linkie 29/08/2014 Public WithEvents MAPISession1 As AxMSMAPI.AxMAPISession
	Public WithEvents txtBody As System.Windows.Forms.TextBox
	Public WithEvents txtSubject As System.Windows.Forms.TextBox
    Public WithEvents lblAan As System.Windows.Forms.Label
	Public WithEvents Image1 As System.Windows.Forms.PictureBox
	Public WithEvents lblNote As System.Windows.Forms.Label
	Public WithEvents Image3 As System.Windows.Forms.PictureBox
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(emailEngine))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Image1 = New System.Windows.Forms.PictureBox
        Me.Image3 = New System.Windows.Forms.PictureBox
        Me.txtTo = New System.Windows.Forms.TextBox
        Me.CommonDialog1Open = New System.Windows.Forms.OpenFileDialog
        Me.btnHelp = New System.Windows.Forms.Button
        Me.btnVerwyder = New System.Windows.Forms.Button
        Me.lstAanhangsels = New System.Windows.Forms.ListBox
        Me.btnSoek = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        'Linkie 29/08/2014 Me.MAPIMessage1 = New AxMSMAPI.AxMAPIMessages
        'Linkie 29/08/2014 Me.MAPISession1 = New AxMSMAPI.AxMAPISession
        Me.txtBody = New System.Windows.Forms.TextBox
        Me.txtSubject = New System.Windows.Forms.TextBox
        Me.lblAan = New System.Windows.Forms.Label
        Me.lblNote = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image3, System.ComponentModel.ISupportInitialize).BeginInit()
        'Linkie 29/08/2014 CType(Me.MAPIMessage1, System.ComponentModel.ISupportInitialize).BeginInit()
        'Linkie 29/08/2014 CType(Me.MAPISession1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Image1
        '
        Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image1.Image = CType(resources.GetObject("Image1.Image"), System.Drawing.Image)
        Me.Image1.Location = New System.Drawing.Point(480, 44)
        Me.Image1.Name = "Image1"
        Me.Image1.Size = New System.Drawing.Size(8, 8)
        Me.Image1.TabIndex = 15
        Me.Image1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Image1, "Vereiste veld")
        '
        'Image3
        '
        Me.Image3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image3.Image = CType(resources.GetObject("Image3.Image"), System.Drawing.Image)
        Me.Image3.Location = New System.Drawing.Point(580, 76)
        Me.Image3.Name = "Image3"
        Me.Image3.Size = New System.Drawing.Size(8, 8)
        Me.Image3.TabIndex = 16
        Me.Image3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Image3, "Vereiste veld")
        '
        'txtTo
        '
        Me.txtTo.AcceptsReturn = True
        Me.txtTo.BackColor = System.Drawing.SystemColors.Window
        Me.txtTo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTo.Location = New System.Drawing.Point(112, 36)
        Me.txtTo.MaxLength = 80
        Me.txtTo.Name = "txtTo"
        Me.txtTo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTo.Size = New System.Drawing.Size(361, 20)
        Me.txtTo.TabIndex = 0
        '
        'btnHelp
        '
        Me.btnHelp.BackColor = System.Drawing.SystemColors.Control
        Me.btnHelp.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnHelp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHelp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnHelp.Location = New System.Drawing.Point(504, 324)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnHelp.Size = New System.Drawing.Size(85, 25)
        Me.btnHelp.TabIndex = 12
        Me.btnHelp.Text = "&Help"
        Me.btnHelp.UseVisualStyleBackColor = False
        '
        'btnVerwyder
        '
        Me.btnVerwyder.BackColor = System.Drawing.SystemColors.Control
        Me.btnVerwyder.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnVerwyder.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerwyder.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnVerwyder.Location = New System.Drawing.Point(176, 195)
        Me.btnVerwyder.Name = "btnVerwyder"
        Me.btnVerwyder.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnVerwyder.Size = New System.Drawing.Size(72, 30)
        Me.btnVerwyder.TabIndex = 4
        Me.btnVerwyder.Text = "Delete"
        Me.btnVerwyder.UseVisualStyleBackColor = False
        '
        'lstAanhangsels
        '
        Me.lstAanhangsels.BackColor = System.Drawing.SystemColors.Window
        Me.lstAanhangsels.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstAanhangsels.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAanhangsels.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstAanhangsels.ItemHeight = 14
        Me.lstAanhangsels.Location = New System.Drawing.Point(112, 228)
        Me.lstAanhangsels.Name = "lstAanhangsels"
        Me.lstAanhangsels.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstAanhangsels.Size = New System.Drawing.Size(477, 60)
        Me.lstAanhangsels.TabIndex = 5
        '
        'btnSoek
        '
        Me.btnSoek.BackColor = System.Drawing.SystemColors.Control
        Me.btnSoek.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSoek.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSoek.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSoek.Location = New System.Drawing.Point(112, 195)
        Me.btnSoek.Name = "btnSoek"
        Me.btnSoek.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSoek.Size = New System.Drawing.Size(61, 30)
        Me.btnSoek.TabIndex = 3
        Me.btnSoek.Text = "Add"
        Me.btnSoek.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(412, 324)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(85, 25)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOk.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Location = New System.Drawing.Point(320, 324)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New System.Drawing.Size(85, 25)
        Me.btnOk.TabIndex = 6
        Me.btnOk.Text = "&Ok"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        ''MAPIMessage1
        ''
        'Linkie 29/08/2014 Me.MAPIMessage1.Enabled = True
        'Linkie 29/08/2014 Me.MAPIMessage1.Location = New System.Drawing.Point(48, 144)
        'Linkie 29/08/2014 Me.MAPIMessage1.Name = "MAPIMessage1"
        'Linkie 29/08/2014 Me.MAPIMessage1.OcxState = CType(resources.GetObject("MAPIMessage1.OcxState"), System.Windows.Forms.AxHost.State)
        'Linkie 29/08/2014 Me.MAPIMessage1.Size = New System.Drawing.Size(38, 38)
        'Linkie 29/08/2014 Me.MAPIMessage1.TabIndex = 13
        ''
        ''MAPISession1
        ''
        'Linkie 29/08/2014 Me.MAPISession1.Enabled = True
        'Linkie 29/08/2014 Me.MAPISession1.Location = New System.Drawing.Point(8, 144)
        'Linkie 29/08/2014 Me.MAPISession1.Name = "MAPISession1"
        'Linkie 29/08/2014 Me.MAPISession1.OcxState = CType(resources.GetObject("MAPISession1.OcxState"), System.Windows.Forms.AxHost.State)
        'Linkie 29/08/2014 Me.MAPISession1.Size = New System.Drawing.Size(38, 38)
        'Linkie 29/08/2014 Me.MAPISession1.TabIndex = 14
        '
        'txtBody
        '
        Me.txtBody.AcceptsReturn = True
        Me.txtBody.BackColor = System.Drawing.SystemColors.Window
        Me.txtBody.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBody.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBody.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBody.Location = New System.Drawing.Point(112, 100)
        Me.txtBody.MaxLength = 0
        Me.txtBody.Multiline = True
        Me.txtBody.Name = "txtBody"
        Me.txtBody.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBody.Size = New System.Drawing.Size(477, 93)
        Me.txtBody.TabIndex = 2
        '
        'txtSubject
        '
        Me.txtSubject.AcceptsReturn = True
        Me.txtSubject.BackColor = System.Drawing.SystemColors.Window
        Me.txtSubject.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSubject.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubject.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSubject.Location = New System.Drawing.Point(112, 68)
        Me.txtSubject.MaxLength = 60
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSubject.Size = New System.Drawing.Size(461, 20)
        Me.txtSubject.TabIndex = 1
        '
        'lblAan
        '
        Me.lblAan.BackColor = System.Drawing.SystemColors.Control
        Me.lblAan.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAan.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAan.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAan.Location = New System.Drawing.Point(24, 40)
        Me.lblAan.Name = "lblAan"
        Me.lblAan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAan.Size = New System.Drawing.Size(89, 13)
        Me.lblAan.TabIndex = 14
        Me.lblAan.Text = "To"
        '
        'lblNote
        '
        Me.lblNote.BackColor = System.Drawing.SystemColors.Control
        Me.lblNote.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblNote.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNote.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNote.Location = New System.Drawing.Point(112, 288)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNote.Size = New System.Drawing.Size(477, 13)
        Me.lblNote.TabIndex = 13
        Me.lblNote.Text = "(Additiional attachments)"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(8, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(125, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = " E-mail details"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(24, 212)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Attachments"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(24, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Detail"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(24, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Subject"
        '
        'emailEngine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(600, 360)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtTo)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnVerwyder)
        Me.Controls.Add(Me.lstAanhangsels)
        Me.Controls.Add(Me.btnSoek)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        'Linkie 29/08/2014 Me.Controls.Add(Me.MAPIMessage1)
        'Linkie 29/08/2014 Me.Controls.Add(Me.MAPISession1)
        Me.Controls.Add(Me.txtBody)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.lblAan)
        Me.Controls.Add(Me.Image1)
        Me.Controls.Add(Me.lblNote)
        Me.Controls.Add(Me.Image3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "emailEngine"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Poldata - E-mail details"
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image3, System.ComponentModel.ISupportInitialize).EndInit()
        'Linkie 29/08/2014 CType(Me.MAPIMessage1, System.ComponentModel.ISupportInitialize).EndInit()
        'Linkie 29/08/2014 CType(Me.MAPISession1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
End Class