Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Public Class frmVervaldeVerwysingskommissieReportViewer

    Private Sub ReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing

        Try
            MyReportViewer.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)
      
            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/VervaldeVerwysingsKommisie"

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Branchcode", Gebruiker.BranchCodes), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("From", frmVervaldeVerwysingskommissie.dtpVervalDatumVanaf.Value), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("To", frmVervaldeVerwysingskommissie.dtpVervalDatumTot.Value)}

            MyReportViewer.ServerReport.SetParameters(params)
            Me.MyReportViewer.RefreshReport()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
