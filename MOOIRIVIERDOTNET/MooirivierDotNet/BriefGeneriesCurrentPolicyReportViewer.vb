Public Class BriefGeneriesCurrentPolicyReportViewer

    Private Sub BriefGeneriesCurrentPolicyReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim AreaBesk As String

            'Assign Policy number
            If BriefGeneries.rdHuidig.Checked = True Then
                PolicyNumber = Persoonl.POLISNO
            ElseIf BriefGeneries.rdSpesifieke.Checked = True Then
                PolicyNumber = BriefStatus.DataGridView1.Rows(0).Cells(0).Value
            Else
                BriefGeneries.rdSpesifieke.Checked = True
                PolicyNumber = BriefStatus.DataGridView1.SelectedRows(0).Cells(0).Value

            End If

            AreaBesk = BriefStatus.DataGridView1.Rows(0).Cells(3).Value

            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/BriefGeneries"

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", PolicyNumber), _
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
