Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Public Class MotorsReportViewer

    Private Sub MotorsReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim fabrikaat As String
        Dim model As String
        Dim jaar As String
        Dim code As String
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing

        Try
            fabrikaat = VoertuigSearch.txtMaak.Text
            model = VoertuigSearch.txtBesk.Text
            jaar = VoertuigSearch.cmbJaar.SelectedItem
            code = VoertuigSearch.txtKode.Text

            MyReportViewer.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)

            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/Motors"

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Fabrikaat", fabrikaat), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("ModelBeskrywing", model), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Jaar", jaar), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Kode", code)}

            MyReportViewer.ServerReport.SetParameters(params)
            Me.MyReportViewer.RefreshReport()
        Catch ex As Exception
        End Try
    End Sub


End Class
