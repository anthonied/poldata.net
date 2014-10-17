<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmVoice1Management
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
    Public WithEvents txtPath As System.Windows.Forms.TextBox
    Public WithEvents btnBrowse As System.Windows.Forms.Button
    Public CommonDialog1Open As System.Windows.Forms.OpenFileDialog
    Public WithEvents btnCancel As System.Windows.Forms.Button
    Public WithEvents btnOk As System.Windows.Forms.Button
    Public WithEvents lblHeading As System.Windows.Forms.Label
    Public WithEvents lblNewFileName As System.Windows.Forms.Label
    Public WithEvents lblChoosCategory As System.Windows.Forms.Label
    Public WithEvents lbl1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVoice1Management))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.CommonDialog1Open = New System.Windows.Forms.OpenFileDialog()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.lblHeading = New System.Windows.Forms.Label()
        Me.lblNewFileName = New System.Windows.Forms.Label()
        Me.lblChoosCategory = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.lblComments = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.btnSearchPolisno = New System.Windows.Forms.Button()
        Me.btnSearchInsured = New System.Windows.Forms.Button()
        Me.btnSearchIDno = New System.Windows.Forms.Button()
        Me.txtIDnumber = New System.Windows.Forms.TextBox()
        Me.lblIDNO = New System.Windows.Forms.Label()
        Me.lblPolicyNo = New System.Windows.Forms.Label()
        Me.txtPolisno = New System.Windows.Forms.TextBox()
        Me.txtInsured = New System.Windows.Forms.TextBox()
        Me.txtInitials = New System.Windows.Forms.TextBox()
        Me.lblInitials = New System.Windows.Forms.Label()
        Me.lblInsured = New System.Windows.Forms.Label()
        Me.txtCallerName = New System.Windows.Forms.TextBox()
        Me.lblCallerName = New System.Windows.Forms.Label()
        Me.txtCallerNumber = New System.Windows.Forms.TextBox()
        Me.txtContactNumber = New System.Windows.Forms.TextBox()
        Me.lblCallerNumber = New System.Windows.Forms.Label()
        Me.lblContactNumber = New System.Windows.Forms.Label()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtPath
        '
        Me.txtPath.AcceptsReturn = True
        Me.txtPath.BackColor = System.Drawing.SystemColors.Window
        Me.txtPath.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPath.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPath.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPath.Location = New System.Drawing.Point(16, 62)
        Me.txtPath.MaxLength = 0
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPath.Size = New System.Drawing.Size(390, 20)
        Me.txtPath.TabIndex = 12
        '
        'btnBrowse
        '
        Me.btnBrowse.BackColor = System.Drawing.SystemColors.Control
        Me.btnBrowse.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnBrowse.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBrowse.Location = New System.Drawing.Point(416, 61)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnBrowse.Size = New System.Drawing.Size(67, 20)
        Me.btnBrowse.TabIndex = 11
        Me.btnBrowse.Text = "Select file"
        Me.btnBrowse.UseVisualStyleBackColor = False
        '
        'CommonDialog1Open
        '
        Me.CommonDialog1Open.DefaultExt = "*"
        Me.CommonDialog1Open.Filter = "All files (*.*)|*.*"
        Me.CommonDialog1Open.InitialDirectory = "c:\Documents"
        Me.CommonDialog1Open.Title = "Choose file to attach."
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(446, 386)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(85, 25)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Location = New System.Drawing.Point(353, 386)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New System.Drawing.Size(85, 25)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = False
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
        Me.lblHeading.Size = New System.Drawing.Size(178, 21)
        Me.lblHeading.TabIndex = 2
        Me.lblHeading.Text = "Voice Management"
        '
        'lblNewFileName
        '
        Me.lblNewFileName.BackColor = System.Drawing.Color.Transparent
        Me.lblNewFileName.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblNewFileName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewFileName.ForeColor = System.Drawing.Color.Black
        Me.lblNewFileName.Location = New System.Drawing.Point(16, 238)
        Me.lblNewFileName.Name = "lblNewFileName"
        Me.lblNewFileName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNewFileName.Size = New System.Drawing.Size(89, 17)
        Me.lblNewFileName.TabIndex = 10
        Me.lblNewFileName.Text = "New file name:"
        '
        'lblChoosCategory
        '
        Me.lblChoosCategory.BackColor = System.Drawing.Color.Transparent
        Me.lblChoosCategory.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblChoosCategory.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChoosCategory.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblChoosCategory.Location = New System.Drawing.Point(16, 206)
        Me.lblChoosCategory.Name = "lblChoosCategory"
        Me.lblChoosCategory.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblChoosCategory.Size = New System.Drawing.Size(191, 22)
        Me.lblChoosCategory.TabIndex = 9
        Me.lblChoosCategory.Text = "Choose a category for this file"
        '
        'lbl1
        '
        Me.lbl1.BackColor = System.Drawing.Color.Transparent
        Me.lbl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl1.Location = New System.Drawing.Point(16, 41)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl1.Size = New System.Drawing.Size(221, 21)
        Me.lbl1.TabIndex = 3
        Me.lbl1.Text = "To store voice files for selected policy"
        '
        'cmbCategory
        '
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(200, 202)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(331, 22)
        Me.cmbCategory.TabIndex = 14
        '
        'lblComments
        '
        Me.lblComments.AutoSize = True
        Me.lblComments.Location = New System.Drawing.Point(16, 295)
        Me.lblComments.Name = "lblComments"
        Me.lblComments.Size = New System.Drawing.Size(57, 14)
        Me.lblComments.TabIndex = 15
        Me.lblComments.Text = "Comments"
        '
        'txtComments
        '
        Me.txtComments.Location = New System.Drawing.Point(112, 292)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(419, 88)
        Me.txtComments.TabIndex = 16
        '
        'btnSearchPolisno
        '
        Me.btnSearchPolisno.BackgroundImage = CType(resources.GetObject("btnSearchPolisno.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchPolisno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSearchPolisno.Location = New System.Drawing.Point(272, 120)
        Me.btnSearchPolisno.Name = "btnSearchPolisno"
        Me.btnSearchPolisno.Size = New System.Drawing.Size(20, 20)
        Me.btnSearchPolisno.TabIndex = 44
        Me.btnSearchPolisno.TabStop = False
        Me.btnSearchPolisno.UseVisualStyleBackColor = True
        '
        'btnSearchInsured
        '
        Me.btnSearchInsured.BackgroundImage = CType(resources.GetObject("btnSearchInsured.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchInsured.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSearchInsured.Location = New System.Drawing.Point(272, 90)
        Me.btnSearchInsured.Name = "btnSearchInsured"
        Me.btnSearchInsured.Size = New System.Drawing.Size(20, 20)
        Me.btnSearchInsured.TabIndex = 43
        Me.btnSearchInsured.TabStop = False
        Me.btnSearchInsured.UseVisualStyleBackColor = True
        '
        'btnSearchIDno
        '
        Me.btnSearchIDno.BackgroundImage = CType(resources.GetObject("btnSearchIDno.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchIDno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSearchIDno.Location = New System.Drawing.Point(511, 120)
        Me.btnSearchIDno.Name = "btnSearchIDno"
        Me.btnSearchIDno.Size = New System.Drawing.Size(20, 20)
        Me.btnSearchIDno.TabIndex = 42
        Me.btnSearchIDno.TabStop = False
        Me.btnSearchIDno.UseVisualStyleBackColor = True
        '
        'txtIDnumber
        '
        Me.txtIDnumber.Location = New System.Drawing.Point(340, 120)
        Me.txtIDnumber.Name = "txtIDnumber"
        Me.txtIDnumber.Size = New System.Drawing.Size(165, 20)
        Me.txtIDnumber.TabIndex = 41
        '
        'lblIDNO
        '
        Me.lblIDNO.AutoSize = True
        Me.lblIDNO.Location = New System.Drawing.Point(300, 122)
        Me.lblIDNO.Name = "lblIDNO"
        Me.lblIDNO.Size = New System.Drawing.Size(32, 14)
        Me.lblIDNO.TabIndex = 40
        Me.lblIDNO.Text = "ID No"
        '
        'lblPolicyNo
        '
        Me.lblPolicyNo.AutoSize = True
        Me.lblPolicyNo.Location = New System.Drawing.Point(16, 120)
        Me.lblPolicyNo.Name = "lblPolicyNo"
        Me.lblPolicyNo.Size = New System.Drawing.Size(75, 14)
        Me.lblPolicyNo.TabIndex = 39
        Me.lblPolicyNo.Text = "Policy Number"
        '
        'txtPolisno
        '
        Me.txtPolisno.Location = New System.Drawing.Point(112, 118)
        Me.txtPolisno.Name = "txtPolisno"
        Me.txtPolisno.Size = New System.Drawing.Size(155, 20)
        Me.txtPolisno.TabIndex = 38
        '
        'txtInsured
        '
        Me.txtInsured.AcceptsReturn = True
        Me.txtInsured.BackColor = System.Drawing.SystemColors.Window
        Me.txtInsured.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInsured.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInsured.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtInsured.Location = New System.Drawing.Point(112, 90)
        Me.txtInsured.MaxLength = 0
        Me.txtInsured.Name = "txtInsured"
        Me.txtInsured.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtInsured.Size = New System.Drawing.Size(157, 20)
        Me.txtInsured.TabIndex = 37
        '
        'txtInitials
        '
        Me.txtInitials.AcceptsReturn = True
        Me.txtInitials.BackColor = System.Drawing.SystemColors.Window
        Me.txtInitials.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInitials.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInitials.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtInitials.Location = New System.Drawing.Point(341, 90)
        Me.txtInitials.MaxLength = 0
        Me.txtInitials.Name = "txtInitials"
        Me.txtInitials.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtInitials.Size = New System.Drawing.Size(190, 20)
        Me.txtInitials.TabIndex = 36
        '
        'lblInitials
        '
        Me.lblInitials.BackColor = System.Drawing.SystemColors.Control
        Me.lblInitials.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblInitials.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInitials.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInitials.Location = New System.Drawing.Point(298, 93)
        Me.lblInitials.Name = "lblInitials"
        Me.lblInitials.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblInitials.Size = New System.Drawing.Size(43, 13)
        Me.lblInitials.TabIndex = 35
        Me.lblInitials.Text = "Initials"
        '
        'lblInsured
        '
        Me.lblInsured.BackColor = System.Drawing.SystemColors.Control
        Me.lblInsured.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblInsured.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInsured.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInsured.Location = New System.Drawing.Point(16, 94)
        Me.lblInsured.Name = "lblInsured"
        Me.lblInsured.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblInsured.Size = New System.Drawing.Size(85, 13)
        Me.lblInsured.TabIndex = 34
        Me.lblInsured.Text = "Insured"
        '
        'txtCallerName
        '
        Me.txtCallerName.Location = New System.Drawing.Point(311, 146)
        Me.txtCallerName.Name = "txtCallerName"
        Me.txtCallerName.Size = New System.Drawing.Size(220, 20)
        Me.txtCallerName.TabIndex = 50
        Me.txtCallerName.Visible = False
        '
        'lblCallerName
        '
        Me.lblCallerName.AutoSize = True
        Me.lblCallerName.Location = New System.Drawing.Point(227, 148)
        Me.lblCallerName.Name = "lblCallerName"
        Me.lblCallerName.Size = New System.Drawing.Size(64, 14)
        Me.lblCallerName.TabIndex = 49
        Me.lblCallerName.Text = "Caller Name"
        Me.lblCallerName.Visible = False
        '
        'txtCallerNumber
        '
        Me.txtCallerNumber.AcceptsReturn = True
        Me.txtCallerNumber.BackColor = System.Drawing.SystemColors.Window
        Me.txtCallerNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCallerNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCallerNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCallerNumber.Location = New System.Drawing.Point(112, 174)
        Me.txtCallerNumber.MaxLength = 0
        Me.txtCallerNumber.Name = "txtCallerNumber"
        Me.txtCallerNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCallerNumber.Size = New System.Drawing.Size(89, 20)
        Me.txtCallerNumber.TabIndex = 48
        '
        'txtContactNumber
        '
        Me.txtContactNumber.AcceptsReturn = True
        Me.txtContactNumber.BackColor = System.Drawing.SystemColors.Window
        Me.txtContactNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtContactNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtContactNumber.Location = New System.Drawing.Point(112, 146)
        Me.txtContactNumber.MaxLength = 0
        Me.txtContactNumber.Name = "txtContactNumber"
        Me.txtContactNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtContactNumber.Size = New System.Drawing.Size(89, 20)
        Me.txtContactNumber.TabIndex = 47
        '
        'lblCallerNumber
        '
        Me.lblCallerNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblCallerNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCallerNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCallerNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCallerNumber.Location = New System.Drawing.Point(16, 176)
        Me.lblCallerNumber.Name = "lblCallerNumber"
        Me.lblCallerNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCallerNumber.Size = New System.Drawing.Size(86, 13)
        Me.lblCallerNumber.TabIndex = 46
        Me.lblCallerNumber.Text = "Caller Number"
        '
        'lblContactNumber
        '
        Me.lblContactNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblContactNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblContactNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContactNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblContactNumber.Location = New System.Drawing.Point(16, 148)
        Me.lblContactNumber.Name = "lblContactNumber"
        Me.lblContactNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblContactNumber.Size = New System.Drawing.Size(90, 13)
        Me.lblContactNumber.TabIndex = 45
        Me.lblContactNumber.Text = "Contact Number"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(112, 240)
        Me.txtFileName.Multiline = True
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(419, 42)
        Me.txtFileName.TabIndex = 51
        '
        'frmVoice1Management
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(549, 429)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.txtCallerName)
        Me.Controls.Add(Me.lblCallerName)
        Me.Controls.Add(Me.txtCallerNumber)
        Me.Controls.Add(Me.txtContactNumber)
        Me.Controls.Add(Me.lblCallerNumber)
        Me.Controls.Add(Me.lblContactNumber)
        Me.Controls.Add(Me.btnSearchPolisno)
        Me.Controls.Add(Me.btnSearchInsured)
        Me.Controls.Add(Me.btnSearchIDno)
        Me.Controls.Add(Me.txtIDnumber)
        Me.Controls.Add(Me.lblIDNO)
        Me.Controls.Add(Me.lblPolicyNo)
        Me.Controls.Add(Me.txtPolisno)
        Me.Controls.Add(Me.txtInsured)
        Me.Controls.Add(Me.txtInitials)
        Me.Controls.Add(Me.lblInitials)
        Me.Controls.Add(Me.lblInsured)
        Me.Controls.Add(Me.txtComments)
        Me.Controls.Add(Me.lblComments)
        Me.Controls.Add(Me.cmbCategory)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.lblHeading)
        Me.Controls.Add(Me.lblNewFileName)
        Me.Controls.Add(Me.lblChoosCategory)
        Me.Controls.Add(Me.lbl1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVoice1Management"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "     Voice Management for policy()"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents lblComments As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchPolisno As System.Windows.Forms.Button
    Friend WithEvents btnSearchInsured As System.Windows.Forms.Button
    Friend WithEvents btnSearchIDno As System.Windows.Forms.Button
    Friend WithEvents txtIDnumber As System.Windows.Forms.TextBox
    Friend WithEvents lblIDNO As System.Windows.Forms.Label
    Friend WithEvents lblPolicyNo As System.Windows.Forms.Label
    Friend WithEvents txtPolisno As System.Windows.Forms.TextBox
    Public WithEvents txtInsured As System.Windows.Forms.TextBox
    Public WithEvents txtInitials As System.Windows.Forms.TextBox
    Public WithEvents lblInitials As System.Windows.Forms.Label
    Public WithEvents lblInsured As System.Windows.Forms.Label
    Friend WithEvents txtCallerName As System.Windows.Forms.TextBox
    Friend WithEvents lblCallerName As System.Windows.Forms.Label
    Public WithEvents txtCallerNumber As System.Windows.Forms.TextBox
    Public WithEvents txtContactNumber As System.Windows.Forms.TextBox
    Public WithEvents lblCallerNumber As System.Windows.Forms.Label
    Public WithEvents lblContactNumber As System.Windows.Forms.Label
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
#End Region
End Class