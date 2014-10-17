Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Public Class PtyCancelReportViewer

    Private Sub PtyCancelReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Premie As String
        Dim Polisno As String
        Dim titel As String
        Dim voorl As String
        Dim versekerde As String
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing

        ' Dim gekans As String
        Dim Adres4 As String
        Adres4 = ""
        'Dim area As String

        Try
            Premie = Form1.Combo1.SelectedValue
            'Andriette 16/08/2013 gebruik global polisnommer
            'Polisno = Form1.POLISNO.Text
            Polisno = glbPolicyNumber
            titel = Form1.TITEL.Text
            voorl = Form1.VOORL.Text
            versekerde = Form1.VERSEKERDE.Text
            If UCase(Form1.Ougekans.Text) = "JA" Then
                Adres4 = Form1.dgvPoldata1Eiendomme.Rows(0).Cells(0).Value
            Else

            End If

            MyReportViewer.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)

            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/PtyCancl"

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Premie", Premie), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Polisno", Polisno), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Titel", titel), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Voorl", voorl), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Versekerde", versekerde), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Adres_H1", Adres4), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("taal", Persoonl.TAAL), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("area_kode", Persoonl.Area), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("area", Persoonl.Area)}

            MyReportViewer.ServerReport.SetParameters(params)
            Me.MyReportViewer.RefreshReport()
        Catch ex As Exception
        End Try
    End Sub


End Class
