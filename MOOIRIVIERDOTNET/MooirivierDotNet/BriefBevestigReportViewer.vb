Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Public Class BriefBevestigReportViewer

    Private Sub BriefBevestigReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing

        Try
            Dim PropertyCoverType As String
            Dim Security As String

            MyReportViewer.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)

            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/BriefBevestig"

            Select Case Trim(Mid(BriefBevestig.ListItemDesc, 1, 12))
                Case "Voertuig :"
                    PropertyCoverType = " "
                Case "* Voertuig :"
                    PropertyCoverType = " "
                Case "Eiendom HE:"
                    PropertyCoverType = "HO"
                Case "Eiendom HB:"
                    PropertyCoverType = "HH"
                Case "* Eiendom HE"
                    PropertyCoverType = "HO"
                Case "* Eiendom HB"
                    PropertyCoverType = "HH"
                Case Else
                    PropertyCoverType = " "
            End Select
            'If BriefBevestig.rdBuiteland.Checked Then
            '    PropertyCoverType = " "
            'End If
            Dim huis As HuisEntity
            huis = GetHuisByPrimaryKey(BriefBevestig.ListItemValue)
            Security = gen_getPropertySecurity(Persoonl.TAAL, huis.SekuriteitBitValue)

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", Persoonl.POLISNO), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", Persoonl.TAAL), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("area_kode", Persoonl.Area), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Voertuig", BriefBevestig.ListItemValue), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("PropertyCoverType", PropertyCoverType), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Huis", BriefBevestig.ListItemValue), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("gen_getPropertySecurity", Security), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Address1", BriefBevestig.Adres1), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Address2", BriefBevestig.Adres2), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Address3", BriefBevestig.Adres3), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Address4", BriefBevestig.Adres4), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Address5", BriefBevestig.Adres5)}

            MyReportViewer.ServerReport.SetParameters(params)
            Me.MyReportViewer.RefreshReport()
        Catch ex As Exception
        End Try
    End Sub


End Class



