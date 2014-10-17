<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmVoiceRecording
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
    Public WithEvents txtInsured As System.Windows.Forms.TextBox
    Public WithEvents txtComments As System.Windows.Forms.TextBox
    Public WithEvents txtCallerNumber As System.Windows.Forms.TextBox
    Public WithEvents txtInitials As System.Windows.Forms.TextBox
    Public WithEvents txtContactNumber As System.Windows.Forms.TextBox
    Public WithEvents btnCancel As System.Windows.Forms.Button
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents lblCallerNumber As System.Windows.Forms.Label
    Public WithEvents lblContactNumber As System.Windows.Forms.Label
    Public WithEvents lblFileName As System.Windows.Forms.Label
    Public WithEvents lblInitials As System.Windows.Forms.Label
    Public WithEvents lblInsured As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVoiceRecording))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtInsured = New System.Windows.Forms.TextBox()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.txtCallerNumber = New System.Windows.Forms.TextBox()
        Me.txtInitials = New System.Windows.Forms.TextBox()
        Me.txtContactNumber = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblCallerNumber = New System.Windows.Forms.Label()
        Me.lblContactNumber = New System.Windows.Forms.Label()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.lblInitials = New System.Windows.Forms.Label()
        Me.lblInsured = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblCategoryDesc = New System.Windows.Forms.Label()
        Me.optInsurance = New System.Windows.Forms.RadioButton()
        Me.optNonInsurance = New System.Windows.Forms.RadioButton()
        Me.txtPolisno = New System.Windows.Forms.TextBox()
        Me.lblPolicyNo = New System.Windows.Forms.Label()
        Me.lblIDNO = New System.Windows.Forms.Label()
        Me.txtIDnumber = New System.Windows.Forms.TextBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.btnSearchIDno = New System.Windows.Forms.Button()
        Me.btnSearchInsured = New System.Windows.Forms.Button()
        Me.btnSearchPolisno = New System.Windows.Forms.Button()
        Me.lblCallerName = New System.Windows.Forms.Label()
        Me.txtCallerName = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtInsured
        '
        Me.txtInsured.AcceptsReturn = True
        Me.txtInsured.BackColor = System.Drawing.SystemColors.Window
        Me.txtInsured.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInsured.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInsured.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtInsured.Location = New System.Drawing.Point(115, 40)
        Me.txtInsured.MaxLength = 0
        Me.txtInsured.Name = "txtInsured"
        Me.txtInsured.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtInsured.Size = New System.Drawing.Size(157, 20)
        Me.txtInsured.TabIndex = 18
        '
        'txtComments
        '
        Me.txtComments.AcceptsReturn = True
        Me.txtComments.BackColor = System.Drawing.SystemColors.Window
        Me.txtComments.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtComments.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComments.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtComments.Location = New System.Drawing.Point(115, 235)
        Me.txtComments.MaxLength = 0
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComments.Size = New System.Drawing.Size(420, 102)
        Me.txtComments.TabIndex = 17
        '
        'txtCallerNumber
        '
        Me.txtCallerNumber.AcceptsReturn = True
        Me.txtCallerNumber.BackColor = System.Drawing.SystemColors.Window
        Me.txtCallerNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCallerNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCallerNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCallerNumber.Location = New System.Drawing.Point(115, 127)
        Me.txtCallerNumber.MaxLength = 0
        Me.txtCallerNumber.Name = "txtCallerNumber"
        Me.txtCallerNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCallerNumber.Size = New System.Drawing.Size(89, 20)
        Me.txtCallerNumber.TabIndex = 14
        '
        'txtInitials
        '
        Me.txtInitials.AcceptsReturn = True
        Me.txtInitials.BackColor = System.Drawing.SystemColors.Window
        Me.txtInitials.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInitials.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInitials.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtInitials.Location = New System.Drawing.Point(344, 40)
        Me.txtInitials.MaxLength = 0
        Me.txtInitials.Name = "txtInitials"
        Me.txtInitials.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtInitials.Size = New System.Drawing.Size(190, 20)
        Me.txtInitials.TabIndex = 13
        '
        'txtContactNumber
        '
        Me.txtContactNumber.AcceptsReturn = True
        Me.txtContactNumber.BackColor = System.Drawing.SystemColors.Window
        Me.txtContactNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtContactNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtContactNumber.Location = New System.Drawing.Point(115, 98)
        Me.txtContactNumber.MaxLength = 0
        Me.txtContactNumber.Name = "txtContactNumber"
        Me.txtContactNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtContactNumber.Size = New System.Drawing.Size(89, 20)
        Me.txtContactNumber.TabIndex = 12
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(450, 351)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(85, 25)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(22, 233)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(86, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Comments"
        '
        'lblCallerNumber
        '
        Me.lblCallerNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblCallerNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCallerNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCallerNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCallerNumber.Location = New System.Drawing.Point(22, 129)
        Me.lblCallerNumber.Name = "lblCallerNumber"
        Me.lblCallerNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCallerNumber.Size = New System.Drawing.Size(86, 13)
        Me.lblCallerNumber.TabIndex = 7
        Me.lblCallerNumber.Text = "Caller Number"
        '
        'lblContactNumber
        '
        Me.lblContactNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblContactNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblContactNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContactNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblContactNumber.Location = New System.Drawing.Point(22, 100)
        Me.lblContactNumber.Name = "lblContactNumber"
        Me.lblContactNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblContactNumber.Size = New System.Drawing.Size(90, 13)
        Me.lblContactNumber.TabIndex = 5
        Me.lblContactNumber.Text = "Contact Number"
        '
        'lblFileName
        '
        Me.lblFileName.BackColor = System.Drawing.SystemColors.Control
        Me.lblFileName.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblFileName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFileName.Location = New System.Drawing.Point(22, 156)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFileName.Size = New System.Drawing.Size(65, 13)
        Me.lblFileName.TabIndex = 4
        Me.lblFileName.Text = "File Name"
        '
        'lblInitials
        '
        Me.lblInitials.BackColor = System.Drawing.SystemColors.Control
        Me.lblInitials.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblInitials.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInitials.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInitials.Location = New System.Drawing.Point(301, 42)
        Me.lblInitials.Name = "lblInitials"
        Me.lblInitials.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblInitials.Size = New System.Drawing.Size(43, 13)
        Me.lblInitials.TabIndex = 3
        Me.lblInitials.Text = "Initials"
        '
        'lblInsured
        '
        Me.lblInsured.BackColor = System.Drawing.SystemColors.Control
        Me.lblInsured.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblInsured.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInsured.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInsured.Location = New System.Drawing.Point(22, 42)
        Me.lblInsured.Name = "lblInsured"
        Me.lblInsured.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblInsured.Size = New System.Drawing.Size(85, 13)
        Me.lblInsured.TabIndex = 2
        Me.lblInsured.Text = "Insured"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(22, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(118, 19)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Voice Recording"
        '
        'lblCategoryDesc
        '
        Me.lblCategoryDesc.BackColor = System.Drawing.SystemColors.Control
        Me.lblCategoryDesc.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCategoryDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoryDesc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCategoryDesc.Location = New System.Drawing.Point(22, 207)
        Me.lblCategoryDesc.Name = "lblCategoryDesc"
        Me.lblCategoryDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCategoryDesc.Size = New System.Drawing.Size(87, 13)
        Me.lblCategoryDesc.TabIndex = 19
        Me.lblCategoryDesc.Text = "Category Desc"
        '
        'optInsurance
        '
        Me.optInsurance.AutoSize = True
        Me.optInsurance.Checked = True
        Me.optInsurance.Location = New System.Drawing.Point(146, 12)
        Me.optInsurance.Name = "optInsurance"
        Me.optInsurance.Size = New System.Drawing.Size(82, 18)
        Me.optInsurance.TabIndex = 21
        Me.optInsurance.TabStop = True
        Me.optInsurance.Text = "   Insurance"
        Me.optInsurance.UseVisualStyleBackColor = True
        '
        'optNonInsurance
        '
        Me.optNonInsurance.AutoSize = True
        Me.optNonInsurance.Location = New System.Drawing.Point(262, 12)
        Me.optNonInsurance.Name = "optNonInsurance"
        Me.optNonInsurance.Size = New System.Drawing.Size(104, 18)
        Me.optNonInsurance.TabIndex = 22
        Me.optNonInsurance.TabStop = True
        Me.optNonInsurance.Text = "   Non Insurance"
        Me.optNonInsurance.UseVisualStyleBackColor = True
        '
        'txtPolisno
        '
        Me.txtPolisno.Location = New System.Drawing.Point(115, 69)
        Me.txtPolisno.Name = "txtPolisno"
        Me.txtPolisno.Size = New System.Drawing.Size(155, 20)
        Me.txtPolisno.TabIndex = 23
        '
        'lblPolicyNo
        '
        Me.lblPolicyNo.AutoSize = True
        Me.lblPolicyNo.Location = New System.Drawing.Point(22, 71)
        Me.lblPolicyNo.Name = "lblPolicyNo"
        Me.lblPolicyNo.Size = New System.Drawing.Size(75, 14)
        Me.lblPolicyNo.TabIndex = 24
        Me.lblPolicyNo.Text = "Policy Number"
        '
        'lblIDNO
        '
        Me.lblIDNO.AutoSize = True
        Me.lblIDNO.Location = New System.Drawing.Point(303, 71)
        Me.lblIDNO.Name = "lblIDNO"
        Me.lblIDNO.Size = New System.Drawing.Size(32, 14)
        Me.lblIDNO.TabIndex = 25
        Me.lblIDNO.Text = "ID No"
        '
        'txtIDnumber
        '
        Me.txtIDnumber.Location = New System.Drawing.Point(343, 69)
        Me.txtIDnumber.Name = "txtIDnumber"
        Me.txtIDnumber.Size = New System.Drawing.Size(165, 20)
        Me.txtIDnumber.TabIndex = 26
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Location = New System.Drawing.Point(354, 351)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New System.Drawing.Size(85, 25)
        Me.btnOk.TabIndex = 27
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(115, 156)
        Me.txtFileName.Multiline = True
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(419, 42)
        Me.txtFileName.TabIndex = 28
        '
        'cmbCategory
        '
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(114, 204)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(420, 22)
        Me.cmbCategory.TabIndex = 29
        '
        'btnSearchIDno
        '
        Me.btnSearchIDno.BackgroundImage = CType(resources.GetObject("btnSearchIDno.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchIDno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSearchIDno.Location = New System.Drawing.Point(515, 69)
        Me.btnSearchIDno.Name = "btnSearchIDno"
        Me.btnSearchIDno.Size = New System.Drawing.Size(20, 20)
        Me.btnSearchIDno.TabIndex = 31
        Me.btnSearchIDno.TabStop = False
        Me.btnSearchIDno.UseVisualStyleBackColor = True
        '
        'btnSearchInsured
        '
        Me.btnSearchInsured.BackgroundImage = CType(resources.GetObject("btnSearchInsured.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchInsured.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSearchInsured.Location = New System.Drawing.Point(275, 40)
        Me.btnSearchInsured.Name = "btnSearchInsured"
        Me.btnSearchInsured.Size = New System.Drawing.Size(20, 20)
        Me.btnSearchInsured.TabIndex = 32
        Me.btnSearchInsured.TabStop = False
        Me.btnSearchInsured.UseVisualStyleBackColor = True
        '
        'btnSearchPolisno
        '
        Me.btnSearchPolisno.BackgroundImage = CType(resources.GetObject("btnSearchPolisno.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchPolisno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSearchPolisno.Location = New System.Drawing.Point(275, 69)
        Me.btnSearchPolisno.Name = "btnSearchPolisno"
        Me.btnSearchPolisno.Size = New System.Drawing.Size(20, 20)
        Me.btnSearchPolisno.TabIndex = 33
        Me.btnSearchPolisno.TabStop = False
        Me.btnSearchPolisno.UseVisualStyleBackColor = True
        '
        'lblCallerName
        '
        Me.lblCallerName.AutoSize = True
        Me.lblCallerName.Location = New System.Drawing.Point(230, 101)
        Me.lblCallerName.Name = "lblCallerName"
        Me.lblCallerName.Size = New System.Drawing.Size(64, 14)
        Me.lblCallerName.TabIndex = 34
        Me.lblCallerName.Text = "Caller Name"
        Me.lblCallerName.Visible = False
        '
        'txtCallerName
        '
        Me.txtCallerName.Location = New System.Drawing.Point(314, 98)
        Me.txtCallerName.Name = "txtCallerName"
        Me.txtCallerName.Size = New System.Drawing.Size(220, 20)
        Me.txtCallerName.TabIndex = 35
        Me.txtCallerName.Visible = False
        '
        'frmVoiceRecording
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(550, 391)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtCallerName)
        Me.Controls.Add(Me.lblCallerName)
        Me.Controls.Add(Me.btnSearchPolisno)
        Me.Controls.Add(Me.btnSearchInsured)
        Me.Controls.Add(Me.btnSearchIDno)
        Me.Controls.Add(Me.cmbCategory)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.txtIDnumber)
        Me.Controls.Add(Me.lblIDNO)
        Me.Controls.Add(Me.lblPolicyNo)
        Me.Controls.Add(Me.txtPolisno)
        Me.Controls.Add(Me.optNonInsurance)
        Me.Controls.Add(Me.optInsurance)
        Me.Controls.Add(Me.lblCategoryDesc)
        Me.Controls.Add(Me.txtInsured)
        Me.Controls.Add(Me.txtComments)
        Me.Controls.Add(Me.txtCallerNumber)
        Me.Controls.Add(Me.txtInitials)
        Me.Controls.Add(Me.txtContactNumber)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblCallerNumber)
        Me.Controls.Add(Me.lblContactNumber)
        Me.Controls.Add(Me.lblFileName)
        Me.Controls.Add(Me.lblInitials)
        Me.Controls.Add(Me.lblInsured)
        Me.Controls.Add(Me.Label6)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVoiceRecording"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "       Voice Recording"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents lblCategoryDesc As System.Windows.Forms.Label
    Friend WithEvents optInsurance As System.Windows.Forms.RadioButton
    Friend WithEvents optNonInsurance As System.Windows.Forms.RadioButton
    Friend WithEvents txtPolisno As System.Windows.Forms.TextBox
    Friend WithEvents lblPolicyNo As System.Windows.Forms.Label
    Friend WithEvents lblIDNO As System.Windows.Forms.Label
    Friend WithEvents txtIDnumber As System.Windows.Forms.TextBox
    Public WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents btnSearchIDno As System.Windows.Forms.Button
    Friend WithEvents btnSearchInsured As System.Windows.Forms.Button
    Friend WithEvents btnSearchPolisno As System.Windows.Forms.Button
    Friend WithEvents lblCallerName As System.Windows.Forms.Label
    Friend WithEvents txtCallerName As System.Windows.Forms.TextBox
#End Region
End Class