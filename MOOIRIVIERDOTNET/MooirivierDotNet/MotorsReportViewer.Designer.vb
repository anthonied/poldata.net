Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MotorsReportViewer
    Inherits MooirivierDotNet.BaseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MyReportViewer = New Microsoft.Reporting.WinForms.ReportViewer
        Me.SuspendLayout()
        '
        'MyReportViewer
        '
        Me.MyReportViewer.AutoSize = True
        Me.MyReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MyReportViewer.Location = New System.Drawing.Point(0, 0)
        Me.MyReportViewer.Name = "MyReportViewer"
        Me.MyReportViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
        Me.MyReportViewer.PromptAreaCollapsed = True
        Me.MyReportViewer.ServerReport.ReportServerUrl = New System.Uri(ConfigurationManager.AppSettings("ReportPath"), System.UriKind.Absolute)
        Me.MyReportViewer.Size = New System.Drawing.Size(767, 554)
        Me.MyReportViewer.TabIndex = 0
        Me.MyReportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage
        '
        'frmLysVanDaaglikseWysigingReportViewer
        '
        Me.AutoScroll = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(767, 554)
        Me.Controls.Add(Me.MyReportViewer)
        Me.Name = "frmLysVanDaaglikseWysigingReportViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MyReportViewer As Microsoft.Reporting.WinForms.ReportViewer

End Class
