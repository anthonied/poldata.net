Public Class ReportViewer

    Private Sub ReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MyReportViewer.ServerReport.ReportPath = "/Mooirivier/LysVanDaaglikseWysigings"

        Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("reportDate", Format(frmLysVanDaaglikseWysigings.dtpDrukVir.Value, "dd/MM/yyyy")), _
                                                                        New Microsoft.Reporting.WinForms.ReportParameter("Area", frmLysVanDaaglikseWysigings.strArea)}

        MyReportViewer.ServerReport.SetParameters(params)
        Me.MyReportViewer.RefreshReport()

    End Sub

    Function ServerReport() As Object
        Throw New NotImplementedException
    End Function

End Class
