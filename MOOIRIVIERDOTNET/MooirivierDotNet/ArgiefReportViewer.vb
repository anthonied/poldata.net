﻿Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Public Class ArgiefReportViewer

    Private Sub ArgiefReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing

        Try
            MyReportViewer.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)


            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/report1"


            'Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", Persoonl.POLISNO)}

            'MyReportViewer.ServerReport.SetParameters(params)
            Me.MyReportViewer.RefreshReport()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MyReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyReportViewer.Load

    End Sub
End Class
