Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Public Class BriefLTPDetailReportViewer

    Private Sub BriefLTPDetailReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing

        Try

            MyReportViewer.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)


            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/BriefLTPDetail"


            Dim DateOffered As String
            DateOffered = BriefLTPDetail.DTPicker1.Value

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", Persoonl.POLISNO), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", Persoonl.TAAL), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("DateOffered", DateOffered), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("GebruikerBranhCode", Gebruiker.BranchCodes), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Premie", BriefLTPDetail.txtPremie2.Text)}

            MyReportViewer.ServerReport.SetParameters(params)
            Me.MyReportViewer.RefreshReport()
        Catch ex As Exception
        End Try
    End Sub


End Class
