Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports DAL
Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration

Friend Class ReminderPrint
    Inherits BaseForm
	
    Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
        'ReminderPrintReportViewer.ShowDialog()
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing
        Try
            ReportViewer1.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)

            ReportViewer1.ServerReport.ReportPath = "/Mooirivier/ReportNew"

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Gebruiker", Me.cmbGebruiker.SelectedItem.ToString), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("From", Me.DTPFrom.Value), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("To", Me.DTPTo.Value)}
            ReportViewer1.ServerReport.SetParameters(params)
            Me.ReportViewer1.RefreshReport()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DTPFrom_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If IsDBNull(Me.DTPFrom.Value) Then
            Me.DTPTo.Enabled = False
        Else
            Me.DTPTo.Enabled = True
        End If
    End Sub

    Private Sub ReminderPrint_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'populate combo users
        populateUsers()

        'Setup datepickers
        Me.DTPFrom.Value = Now
        Me.DTPTo.Value = Now
       
        Me.DTPTo.Enabled = False

        Me.Text = My.Application.Info.Title & " - Reports - Reminders"
    End Sub

    Public Sub populateUsers()
        ' Dim list As List(Of GebruikersEntity)
        cmbGebruiker.ValueMember = "Naam"
        cmbGebruiker.DisplayMember = "Naam"
       
        cmbGebruiker.DataSource = FetchGebruikerList()

    End Sub

    Private Sub DTPFrom_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFrom.GotFocus
        If IsDBNull(Me.DTPFrom.Value) Then
            Me.DTPTo.Enabled = False
        Else
            Me.DTPTo.Enabled = True
        End If
    End Sub
End Class