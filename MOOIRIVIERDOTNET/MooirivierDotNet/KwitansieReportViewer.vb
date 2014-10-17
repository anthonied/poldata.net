Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Public Class KwitansieReportViewer

    Private Sub KwitansieReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing

        Try

            Dim kwitansie_nr As String = ""

            MyReportViewer.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)

            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/Kwitansie"


            'If Kontant.Check_VT.CheckState Then
            '    kwitansie_nr = Kontant.DataGridView1.SelectedRows(0).Cells(5).Value
            'ElseIf Kontant.Check_mk.CheckState Then
            '    kwitansie_nr = Kontant.DataGridView1.SelectedRows(0).Cells(3).Value
            'ElseIf Kontant.check_md.CheckState Then
            '    kwitansie_nr = Kontant.DataGridView1.SelectedRows(0).Cells(3).Value
            'ElseIf Kontant.Check_me.CheckState Then
            '    kwitansie_nr = Kontant.DataGridView1.SelectedRows(0).Cells(3).Value
            'ElseIf Kontant.Check_ms.CheckState Then
            '    kwitansie_nr = Kontant.DataGridView1.SelectedRows(0).Cells(3).Value
            'End If

            If kwitansie_nr = " " Then
                MsgBox("A receipt can only be printed on a cash transaction. Pls select a column that contains a receipt number.")
                Me.Close()
                Exit Sub
            End If


            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", Persoonl.POLISNO), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", Persoonl.TAAL), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("kwitansie", kwitansie_nr), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Area_kode", Persoonl.Area)}

            MyReportViewer.ServerReport.SetParameters(params)
            Me.MyReportViewer.RefreshReport()
        Catch ex As Exception
        End Try
    End Sub


End Class
