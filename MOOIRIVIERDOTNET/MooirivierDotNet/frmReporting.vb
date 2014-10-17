Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Public Class frmReporting

    Private Sub frmReporting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing

        Try
            rptViewer.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)

            rptViewer.ServerReport.ReportPath = strglbReportPath

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("afsluit_dat", frmCollections.dtpCollectionsDate.Value)}

            rptViewer.ServerReport.SetParameters(params)
            Me.rptViewer.RefreshReport()
        Catch ex As Exception
        End Try
    End Sub


End Class

