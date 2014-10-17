Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Public Class BriefGeneriesReportViewer

    Private Sub BriefGeneriesReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing
        Try
            MyReportViewer.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)


            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/BriefGeneries"

            Dim AreaBesk As String = ""

            'Assign Policy number
            If BriefGeneries.rdHuidig.Checked = True Then
                'Andriette 01/08/2013 verander die global variable
                glbPolicyNumber = Persoonl.POLISNO
                AreaBesk = BriefStatus.DataGridView1.Rows(0).Cells(3).Value
            ElseIf BriefGeneries.rdSpesifieke.Checked = True Then
                'Andriette 01/08/2013 verander die global variable
                glbPolicyNumber = BriefStatus.DataGridView1.Rows(0).Cells(0).Value
            Else
                BriefGeneries.rdSpesifieke.Checked = True
                'Andriette 01/08/2013 verander die global variable
                glbPolicyNumber = BriefStatus.DataGridView1.SelectedRows(0).Cells(0).Value
                AreaBesk = BriefStatus.DataGridView1.SelectedRows(0).Cells(3).Value
            End If

          
            'Andriette 01/08/2013 verander die global variable
            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", glbPolicyNumber), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", Persoonl.TAAL), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("AreaBesk", AreaBesk), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Onderwerp", BriefGeneries.txtOnderwerp.Text), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Inhond", BriefGeneries.txtInhoud.Text)}



            MyReportViewer.ServerReport.SetParameters(params)
            Me.MyReportViewer.RefreshReport()
        Catch ex As Exception
        End Try
    End Sub


End Class
