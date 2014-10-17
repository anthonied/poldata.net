Public Class BriefBesonderhedeReportViewer

    Private Sub BriefBesonderhedeReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Language As String
        Try

            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/BriefBesonderhede"

            If BriefGeneries.rdSpesifieke.Checked Then
                Select Case BriefGeneries.cmbTaal.SelectedIndex
                    Case 0
                        Language = 0
                    Case 1 'Afr
                        Language = 0
                    Case 2 'Eng
                        Language = 1
                End Select
            Else
                Language = ""
            End If

            'Select Case Trim(Mid(BriefOpskort.ListItemDesc, 1, 12))
            '    Case "Voertuig :"
            '        PropertyCoverType = " "
            '    Case "* Voertuig :"
            '        PropertyCoverType = " "
            '    Case "Eiendom HE:"
            '        PropertyCoverType = "HO"
            '    Case "Eiendom HB:"
            '        PropertyCoverType = "HH"
            '    Case "* Eiendom HE"
            '        PropertyCoverType = "HO"
            '    Case "* Eiendom HB"
            '        PropertyCoverType = "HH"
            '    Case Else
            '        PropertyCoverType = " "
            'End Select


            'voertuie = FetchVoertuie()
            'Dim huis As HuisEntity
            'huis = GetHuisByPrimaryKey(BriefBesonderhede.ListItemValue)
            ' Security = gen_getPropertySecurity(Persoonl.TAAL, voertuie.SekuriteitBitValue)

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", Persoonl.TAAL), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", Persoonl.POLISNO), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Area_kode", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("pkVoertuie", FetchVoertuie.pkVoertuie)}
            'New Microsoft.Reporting.WinForms.ReportParameter("Surnames", BriefBesonderhede.txtVanaf.Text & BriefBesonderhede.txtTot.Text), _
            'New Microsoft.Reporting.WinForms.ReportParameter("Insurer", BriefBesonderhede.cmbVersekeraar.SelectedIndex), _
            'New Microsoft.Reporting.WinForms.ReportParameter("Status", BriefBesonderhede.cmbStatus.SelectedIndex), _
            ' New Microsoft.Reporting.WinForms.ReportParameter("Post Destination", BriefBesonderhede.cmbPosbestemming.SelectedIndex), _
            'New Microsoft.Reporting.WinForms.ReportParameter("Language", Language), _
            MyReportViewer.ServerReport.SetParameters(params)
            Me.MyReportViewer.RefreshReport()
        Catch ex As Exception
        End Try
    End Sub

End Class
