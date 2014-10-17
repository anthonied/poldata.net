Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Public Class BriefBesonderhedeReportViewer2

    Private Sub BriefBesonderhedeReportViewer2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing

        Try
            MyReportViewer.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)

            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/BriefBesonderhede"


            Dim polisno As String
            If BriefBesonderhede.rdHuidig.Checked = True Then
                polisno = Persoonl.POLISNO
            ElseIf BriefBesonderhede.rdSpesifieke.Checked = True And BriefStatus.DataGridView1.RowCount = 1 Then
                polisno = BriefStatus.DataGridView1.Rows(0).Cells(0).Value
            Else
                BriefBesonderhede.rdSpesifieke.Checked = True
                polisno = BriefStatus.DataGridView1.SelectedRows(0).Cells(0).Value
            End If

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", polisno), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Area_kode", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", Persoonl.TAAL), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("pkVoertuie", FetchVoertuie.pkVoertuie)}

            MyReportViewer.ServerReport.SetParameters(params)
            Me.MyReportViewer.RefreshReport()
        Catch ex As Exception
        End Try
    End Sub
End Class
