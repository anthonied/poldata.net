Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Public Class Brief_VTDetailReportViewer

    Private Sub Brief_VTDetailReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing

        Try
            MyReportViewer.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)


            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/BriefVT"


            Dim premie As String
            Dim DateOffered As String

            DateOffered = BriefVT.BriefVTGrid1.SelectedRows(0).Cells(1).Value
            premie = BriefVT.BriefVTGrid1.SelectedRows(0).Cells(3).Value

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", Persoonl.POLISNO), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("LANGUAGE", Persoonl.TAAL), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", Persoonl.TAAL), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("DateOffered", DateOffered), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("GebruikerBranhCode", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Premie", premie)}

            MyReportViewer.ServerReport.SetParameters(params)
            Me.MyReportViewer.RefreshReport()
        Catch ex As Exception
        End Try
    End Sub


End Class
