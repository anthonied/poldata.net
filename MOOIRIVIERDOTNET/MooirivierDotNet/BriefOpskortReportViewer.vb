Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Public Class BriefOpskortReportViewer

    Private Sub BriefOpskortReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing

        Try
            Dim PropertyCoverType As String
            Dim Security As String

            MyReportViewer.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)

            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/BriefOpskort"

            Select Case Trim(Mid(BriefOpskort.ListItemDesc, 1, 12))
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


            Dim huis As HuisEntity
            huis = GetHuisByPrimaryKey(BriefOpskort.ListItemValue)
            Security = gen_getPropertySecurity(Persoonl.TAAL, huis.SekuriteitBitValue)

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", Persoonl.POLISNO), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", BriefOpskort.OpskortTaal), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Rede", BriefOpskort.Rede), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Voertuig", BriefOpskort.ListItemValue), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("PropertyCoverType", PropertyCoverType), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Huis", BriefOpskort.ListItemValue), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("gen_getPropertySecurity", Security), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Address1", BriefOpskort.Adres1), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Address2", BriefOpskort.Adres2), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Address3", BriefOpskort.Adres3), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Address4", BriefOpskort.Adres4), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Address5", BriefOpskort.Adres5)}

            MyReportViewer.ServerReport.SetParameters(params)
            Me.MyReportViewer.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


End Class
