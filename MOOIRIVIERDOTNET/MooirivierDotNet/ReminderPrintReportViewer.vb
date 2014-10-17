Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Public Class ReminderPrintReportViewer

    Private Sub ReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing
        Try
            MyReportViewer.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)

            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/Reminders"

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Gebruiker", ReminderPrint.cmbGebruiker.SelectedItem.ToString), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("From", ReminderPrint.DTPFrom.Value), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("To", ReminderPrint.DTPTo.Value)}
            MyReportViewer.ServerReport.SetParameters(params)
            Me.MyReportViewer.RefreshReport()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class
