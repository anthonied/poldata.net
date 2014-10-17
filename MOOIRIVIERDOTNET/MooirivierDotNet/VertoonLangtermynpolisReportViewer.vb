Imports System.Data.SqlClient
Imports DAL

Public Class VertoonLangtermynpolisViewer

    Private Sub VertoonLangtermynpolisViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/VertoonLangtermynpolis"

            Dim maand As String
            Dim jaar As Integer

            maand = Kontant.maand_van.Text
            jaar = Kontant.jaar_van.Text

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", Persoonl.POLISNO), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Area_kode", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Maand", maand), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Jaar", jaar), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", Persoonl.TAAL)}


            MyReportViewer.ServerReport.SetParameters(params)
            Me.MyReportViewer.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class
