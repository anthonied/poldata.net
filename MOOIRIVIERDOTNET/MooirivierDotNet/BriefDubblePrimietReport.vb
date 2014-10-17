Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration

Public Class BriefDubblePremieReport

    Private Sub ReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing

        Try

            Dim language As Integer

            MyReportViewer.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)

            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/BriefDubblePrime"

            If BriefDubbelPremie.rdAfrikaans.Checked Then
                language = 0

            ElseIf BriefDubbelPremie.rdEngels.Checked Then
                language = 1
            End If
            Dim myTitel As TitleEntity
            myTitel = BriefDubbelPremie.cmbTitel.SelectedItem


            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", Persoonl.POLISNO), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", language), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Adres1", BriefDubbelPremie.txtAdres1.Text), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Adres2", BriefDubbelPremie.txtAdres2.Text), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Van", BriefDubbelPremie.txtVan.Text), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Voorstad", BriefDubbelPremie.txtVoorstad.Text), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Poskode", BriefDubbelPremie.txtPoskode.Text), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Premium", BriefDubbelPremie.txtPremium.Text), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Voorl", BriefDubbelPremie.txtVoorletter.Text), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Titel", myTitel.Title)}

            MyReportViewer.ServerReport.SetParameters(params)
            Me.MyReportViewer.RefreshReport()


        Catch ex As Exception
            MsgBox("The ReportServer is unavailable at this moment. Try again later.")
        End Try

    End Sub
End Class
