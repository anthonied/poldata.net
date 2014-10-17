Public Class VertoonLangtermynpolisViewer

    Private Sub BriefBevestigReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/VertoonLangtermynpolis"

            Dim voertuie As New VoertuieEntity
          
            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("area_kode", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", Persoonl.POLISNO), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Taal", Persoonl.TAAL), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Voertuig", FetchVoertuie.pkVoertuie), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("PropertyCoverType", PropertyCoverType), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("gen_getPropertySecurity", Security), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Address1", BriefBevestig.cmbTitel.SelectedIndex & BriefBevestig.txtVoorletter.Text & BriefBevestig.txtVan.Text), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Address2", BriefBevestig.txtAdres1.Text), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Address3", BriefBevestig.txtAdres2.Text), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Address4", BriefBevestig.txtVoorstad.Text), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Address5", BriefBevestig.txtPoskode.Text)}


            MyReportViewer.ServerReport.SetParameters(params)
            Me.MyReportViewer.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


End Class
