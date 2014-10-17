Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Imports System.Data.SqlClient
Imports DAL

Public Class frmLysVanDaaglikseWysigingReportViewer

    Private Sub ReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strArea As String
        Dim DtpDate As String
        Dim i As Integer
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing

        Try
            strArea = ""

            'Area
            If frmLysVanDaaglikseWysigings.lstArea.SelectedIndex <> -1 And frmLysVanDaaglikseWysigings.lstArea.SelectedIndex <> 0 Then
                For i = 0 To frmLysVanDaaglikseWysigings.lstArea.SelectedItems.Count - 1
                    If i = 0 Then
                        strArea = frmLysVanDaaglikseWysigings.lstArea.SelectedItems(i) + "',"
                    Else
                        strArea = strArea + "'" + frmLysVanDaaglikseWysigings.lstArea.SelectedItems(i) + "',"
                    End If

                Next
                strArea = Mid(strArea, 1, Len(strArea) - 2)
            End If
            'Area Parameter
            If strArea = "" Then
                strArea = ""
            Else
                strArea = strArea
            End If


            DtpDate = Format(frmLysVanDaaglikseWysigings.dtpDrukVir.Value, "yyyy-MM-dd")


            MyReportViewer.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)

            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/LysVanDaaglikseWysigings"

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("reportDate", DtpDate), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("AreaBesk", strArea)}

            MyReportViewer.ServerReport.SetParameters(params)

            Using conn As SqlConnection = SqlHelper.GetConnection


                Dim params2() As SqlParameter = {New SqlParameter("@reportDate", SqlDbType.NVarChar), _
                                                New SqlParameter("@AreaBesk", SqlDbType.NVarChar)}
                                               


                params2(0).Value = DtpDate
                params2(1).Value = strArea

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.ListOfDailyChange", params2)

                If reader.Read() Then
                    Me.MyReportViewer.RefreshReport()
                Else
                    MsgBox("There were no policies that meet the criteria.", MsgBoxStyle.Information)
                    Me.Close()
                    Exit Sub
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try



    End Sub

    Private Sub MyReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyReportViewer.Load

    End Sub
End Class
