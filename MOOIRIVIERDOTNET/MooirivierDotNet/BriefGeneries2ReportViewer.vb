Public Class BriefGeneries2ReportViewer

    Private Sub BriefGeneries2ReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim AreaBesk As String
            Dim PolisNo As String

            PolisNo = BriefStatus.DataGridView1.SelectedRows(0).Cells(0).Value
            AreaBesk = BriefStatus.DataGridView1.SelectedRows(0).Cells(3).Value

            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/BriefGeneries"

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", PolisNo), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", Persoonl.TAAL), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("AreaBesk", AreaBesk), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Onderwerp", BriefGeneries.txtOnderwerp.Text), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Inhond", BriefGeneries.txtInhoud.Text)}


            MyReportViewer.ServerReport.SetParameters(params)
            Me.MyReportViewer.RefreshReport()
        Catch ex As Exception
        End Try
    End Sub


End Class
