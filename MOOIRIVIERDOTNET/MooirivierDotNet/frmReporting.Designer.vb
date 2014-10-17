<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporting
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
        Me.rptViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rptViewer
        '
        Me.rptViewer.Location = New System.Drawing.Point(10, 11)
        Me.rptViewer.Name = "rptViewer"
        Me.rptViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
        Me.rptViewer.Size = New System.Drawing.Size(809, 615)
        Me.rptViewer.TabIndex = 0
        '
        'frmReporting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 638)
        Me.Controls.Add(Me.rptViewer)
        Me.Name = "frmReporting"
        Me.Text = "frmReporting"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptViewer As Microsoft.Reporting.WinForms.ReportViewer
End Class
