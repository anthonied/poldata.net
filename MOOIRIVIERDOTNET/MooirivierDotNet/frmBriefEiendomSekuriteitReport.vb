Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Public Class frmBriefEiendomSekuriteitReport

    Private Sub ReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strStandaard, Diefwering, Veiligheidshekke, Alarm, Kompleks, Dorp, Wagte As String
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing
        Try
            'MyReportViewer.ServerReport.ReportServerCredentials =  = New MyReportServerCredentials()
            MyReportViewer.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)

        

            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/BriefEiendomSekuriteit"

            If BriefEiendomSekuriteit._chkSekuriteit_0.Checked Then
                Diefwering = "true"
            Else
                Diefwering = "false"
            End If

            If BriefEiendomSekuriteit._chkSekuriteit_1.Checked Then
                Veiligheidshekke = "true"
            Else
                Veiligheidshekke = "false"
            End If

            If BriefEiendomSekuriteit._chkSekuriteit_2.Checked Then
                Alarm = "true"
            Else
                Alarm = "false"
            End If

            If BriefEiendomSekuriteit._chkSekuriteit_3.Checked Then
                Kompleks = "true"
            Else
                Kompleks = "false"
            End If

            If BriefEiendomSekuriteit._chkSekuriteit_4.Checked Then
                Dorp = "true"
            Else
                Dorp = "false"
            End If

            If BriefEiendomSekuriteit._chkSekuriteit_5.Checked Then
                Wagte = "true"
            Else
                Wagte = "false"
            End If

            If BriefEiendomSekuriteit.rdStandaard.Checked Then
                strStandaard = "Standaard"
            Else
                strStandaard = " "
            End If
            Dim myEntity As HuisEntity
            myEntity = BriefEiendomSekuriteit.lstRisikoAdres.SelectedItem


            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", Persoonl.POLISNO), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", Persoonl.TAAL), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("RisikoAdres", myEntity.EiendomDisplay), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("TipeBrief", strStandaard), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Diefwering", Diefwering), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Veiligheidshekke", Veiligheidshekke), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Alarm", Alarm), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Kompleks", Kompleks), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Dorp", Dorp), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Wagte", Wagte)}

            MyReportViewer.ServerReport.SetParameters(params)
            Me.MyReportViewer.RefreshReport()
        Catch ex As Exception
            MsgBox("The ReportServer is unavailable at this moment. Try again later.")
        End Try
    End Sub
End Class
