Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Imports System.Data.SqlClient
Imports DAL

Public Class SearchReportViewer

    Private Sub SearchReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Language As String = ""
        Dim sqlStatus As String = ""
        Dim sqlSurnameFrom As String
        Dim sqlSurnameTo As String
        Dim Sqlposbestemming As String = ""
        Dim dtpAanvFrom As String
        Dim dtpAanvTo As String
        'Andriette 15/08/2014 gee veranderlike ;n aanvangswaarde om warnings weg te vat
        Dim strArea As String = ""
        Dim adres1 As String
        Dim adres2 As String
        Dim adres3 As String
        Dim sqlID As String
        Dim sqlAccType As String
        Dim sqlBetaalwyse As String
        Dim sqlBemarker As String
        Dim sqlBybetaling As String
        Dim sqlVoorl As String
        Dim sqlBankCodes As String
        Dim sqlTitel As String = ""
        Dim sqlEmail As String = ""
        Dim sOrderby As String
        Dim sqlDecsAsc As String

        Dim Language_Display As String = ""
        Dim sqlStatus_Display As String = ""
        Dim Sqlposbestemming_Display As String = ""
        Dim sqlAccType_Display As String = ""
        Dim sqlBetaalwyse_Display As String = ""
        Dim sqlBybetaling_Display As String = ""
        Dim sqlBankCodes_Display As String = ""
        Dim sqlTitel_Display As String = ""
        Dim sqlEmail_Display As String = ""
        Dim sOrderby_Display As String
        Dim sqlDecsAsc_Display As String
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing

        Try
            'Surname

            sqlSurnameFrom = Trim(Search.txtVanneVanaf.Text)
            sqlSurnameTo = Search.txtVanneTot.Text

            'Date Search
            If Search.DTPAanvangs.Checked = True Then
                Search.DTPAanvangsTot.Visible = True
                dtpAanvFrom = Format(Search.DTPAanvangs.Value, "yyyy-MM-dd")
            Else
                dtpAanvFrom = ""
                Search.DTPAanvangsTot.Visible = False
            End If

            If Search.DTPAanvangsTot.Visible = True Then
                dtpAanvTo = Format(Search.DTPAanvangsTot.Value, "yyyy-MM-dd")
            Else
                dtpAanvTo = ""
            End If


            'Postal Details
            Select Case Search.cmbPosbestemming.SelectedIndex
                Case 0
                    Sqlposbestemming = ""
                    Sqlposbestemming_Display = ""
                Case 1
                    Sqlposbestemming = "0"
                    Sqlposbestemming_Display = "Postal address"
                Case 2
                    Sqlposbestemming = "1"
                    Sqlposbestemming_Display = "Risk address"
                Case 3
                    Sqlposbestemming = "2"
                    Sqlposbestemming_Display = "University Box"
                Case 4
                    Sqlposbestemming = "3"
                    Sqlposbestemming_Display = "Email"
            End Select
            'Sql for status
            Select Case Search.cmbStatus.SelectedIndex
                Case 0
                    sqlStatus = ""
                Case 1
                    sqlStatus = "0"
                    sqlStatus_Display = Search.cmbStatus.SelectedItem
                Case 2
                    sqlStatus = "1"
                    sqlStatus_Display = Search.cmbStatus.SelectedItem
            End Select
            'Area
            If Search.lstArea.SelectedIndex <> -1 And Search.lstArea.SelectedIndex <> 0 Then
                For i = 0 To Search.lstArea.SelectedItems.Count - 1
                    If i = 0 Then
                        strArea = Search.lstArea.SelectedItems(i) + "',"
                    Else
                        strArea = strArea + "'" + Search.lstArea.SelectedItems(i) + "',"
                    End If

                Next
                strArea = Mid(strArea, 1, Len(strArea) - 2)
            End If
            'Area Parameter
            If strArea = "" Then
                strArea = ""
            Else
                strArea = "'" + strArea + "'"
            End If

            'Language parameter

            Select Case Search.cmbTaal.SelectedIndex
                Case 0
                    Language = ""
                Case 1 'Afr
                    Language = 0
                    Language_Display = Search.cmbTaal.SelectedItem
                Case 2 'Eng
                    Language = 1
                    Language_Display = Search.cmbTaal.SelectedItem
            End Select
            'Title Parameter
            'If Search.cmbTitel.SelectedIndex > 0 Then
            '    sqlTitel = Search.cmbTitel.SelectedIndex

            '    sqlTitel_Display = Search.cmbTitel.SelectedItem
            'Else
            '    sqlTitel = ""
            'End If

            Select Case Search.cmbTitel.SelectedIndex
                Case 0
                    sqlTitel = ""
                    sqlTitel_Display = ""
                Case 1
                    sqlTitel = "0"
                    sqlTitel_Display = "Mr"
                Case 2
                    sqlTitel = "1"
                    sqlTitel_Display = "Mrs"
                Case 3
                    sqlTitel = "2"
                    sqlTitel_Display = "Professor"
                Case 4
                    sqlTitel = "3"
                    sqlTitel_Display = "Dr"
                Case 5
                    sqlTitel = "4"
                    sqlTitel_Display = ""
                Case 6
                    sqlTitel = "5"
                    sqlTitel_Display = "Pastor"
                Case 7
                    sqlTitel = "6"
                    sqlTitel_Display = "Rev"
                Case 8
                    sqlTitel = "7"
                    sqlTitel_Display = "Brig Genl"
                Case 9
                    sqlTitel = "8"
                    sqlTitel_Display = "Col"
                Case 10
                    sqlTitel = "9"
                    sqlTitel_Display = "Lt genl"
                Case 11
                    sqlTitel = "10"
                    sqlTitel_Display = "Capt"
                Case 12
                    sqlTitel = "11"
                    sqlTitel_Display = "Advocat"
                Case 13
                    sqlTitel = "12"
                    sqlTitel_Display = "Judge"
                Case 14
                    sqlTitel = "13"
                    sqlTitel_Display = "Brig"
                Case 15
                    sqlTitel = "14"
                    sqlTitel_Display = "Earl"
                Case 16
                    sqlTitel = "15"
                    sqlTitel_Display = "Miss"
                Case 17
                    sqlTitel = "16"
                    sqlTitel_Display = "Ms"
            End Select

            'Initials parameter

            sqlVoorl = Trim(Search.txtVoorl.Text)

            'ID NUMBER PARAMETR
            sqlID = Trim(Search.txtID.Text)
            'Postal address
            adres2 = Search.txtPoskode.Text
            adres1 = Search.txtStad.Text
            adres3 = Search.txtVoorstad.Text

            'Account Type
            If Search.cmbAccType.SelectedIndex > 0 Then
                sqlAccType = Search.cmbAccType.SelectedIndex
                sqlAccType_Display = Search.cmbAccType.SelectedItem
            Else
                sqlAccType = ""
            End If

            'Excess
            If Search.cmbBybetaling.SelectedIndex > 0 Then
                sqlBybetaling = Search.cmbBybetaling.SelectedIndex
                sqlBybetaling_Display = Search.cmbBybetaling.SelectedItem
            Else
                sqlBybetaling = ""
            End If

            'Marketer
            If Search.cmbBemarker.SelectedIndex = 0 Then
                sqlBemarker = ""
            Else
                If Search.cmbBemarker.SelectedValue = "" Then
                    sqlBemarker = ""
                Else
                    sqlBemarker = Search.cmbBemarker.SelectedValue

                End If
            End If

            'Sage pay
            If Search.cmbBet_wyse.SelectedIndex > 0 Then
                sqlBetaalwyse = Search.cmbBet_wyse.SelectedIndex
                sqlBetaalwyse_Display = Search.cmbBet_wyse.SelectedItem
            Else
                sqlBetaalwyse = ""
            End If

            'Bankcodes
            If Search.txtPkBnkCodes.Text <> "" Then
                sqlBankCodes = Search.txtPkBnkCodes.Text
                sqlBankCodes_Display = Search.txtBank.Text
            Else
                sqlBankCodes = ""
            End If

            'Email
            Select Case Search.cmbEpos.SelectedIndex
                Case 0 'Alle
                    sqlEmail = ""
                Case 1
                    sqlEmail = "IS NOT NULL"
                    sqlEmail_Display = Search.cmbEpos.SelectedItem
                Case 2
                    sqlEmail = "IS NULL"
                    sqlEmail_Display = Search.cmbEpos.SelectedItem
            End Select

            'SORT DATA
            If Search.cmbOrderby.SelectedIndex = 0 Then
                sOrderby = "persoonl.polisno"
                sOrderby_Display = Search.cmbOrderby.SelectedItem
            ElseIf Search.cmbOrderby.SelectedIndex = 1 Then
                sOrderby = "PERSOONL.VERSEKERDE"
                sOrderby_Display = Search.cmbOrderby.SelectedItem
            ElseIf Search.cmbOrderby.SelectedIndex = 2 Then
                sOrderby = "PERSOONL.VOORL"
                sOrderby_Display = Search.cmbOrderby.SelectedItem
            Else
                sOrderby = "persoonl.titelnum"
                sOrderby_Display = Search.cmbOrderby.SelectedItem
            End If

            'SORT ASC OR DESC
            If Search.cmbOrder.SelectedIndex = 0 Then
                sqlDecsAsc = "ASC"
                sqlDecsAsc_Display = Search.cmbOrder.SelectedItem
            Else
                sqlDecsAsc = "DESC"
                sqlDecsAsc_Display = Search.cmbOrder.SelectedItem
            End If

            MyReportViewer.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)


            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/Search"

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Language", Language), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlStatus", sqlStatus), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlArea", strArea), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlSurnameFrom", sqlSurnameFrom), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlID", sqlID), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("adres1", adres1), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("adres2", adres2), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("adres3", adres3), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlAccType", sqlAccType), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlBankCodes", sqlBankCodes), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlBetaalwyse", sqlBetaalwyse), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlBemarker", sqlBemarker), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlBybetaling", sqlBybetaling), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlVoorl", sqlVoorl), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlTitel", sqlTitel), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlEmail", sqlEmail), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sOrderby", sOrderby), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlDecsAsc", sqlDecsAsc), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlSurnameTo", sqlSurnameTo), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Sqlposbestemming", Sqlposbestemming), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("dtpAanvFrom", dtpAanvFrom), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Language_Display", Language_Display), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlStatus_Display", sqlStatus_Display), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlEmail_Display", sqlEmail_Display), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Sqlposbestemming_Display", Sqlposbestemming_Display), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlAccType_Display", sqlAccType_Display), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlBetaalwyse_Display", sqlBetaalwyse_Display), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlBybetaling_Display", sqlBybetaling_Display), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlBankCodes_Display", sqlBankCodes_Display), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlTitel_Display", sqlTitel_Display), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sOrderby_Display", sOrderby_Display), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlDecsAsc_Display", sqlDecsAsc_Display), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("dtpAanvTo", dtpAanvTo)}


            MyReportViewer.ServerReport.SetParameters(params)

            Using conn As SqlConnection = SqlHelper.GetConnection


                Dim params2() As SqlParameter = {New SqlParameter("@Language", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlStatus", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlArea", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlSurnameFrom", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlSurnameTo", SqlDbType.NVarChar), _
                                                New SqlParameter("@Sqlposbestemming", SqlDbType.NVarChar), _
                                                New SqlParameter("@dtpAanvFrom", SqlDbType.NVarChar), _
                                                New SqlParameter("@dtpAanvTo", SqlDbType.NVarChar), _
                                                New SqlParameter("@adres1", SqlDbType.NVarChar), _
                                                New SqlParameter("@adres2", SqlDbType.NVarChar), _
                                                New SqlParameter("@adres3", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlID", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlAccType", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlBankCodes", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlBetaalwyse", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlBemarker", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlBybetaling", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlVoorl", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlTitel", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlEmail", SqlDbType.NVarChar), _
                                                New SqlParameter("@sOrderby", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlDecsAsc", SqlDbType.NVarChar)}


                params2(0).Value = Language
                params2(1).Value = sqlStatus
                params2(2).Value = strArea
                params2(3).Value = sqlSurnameFrom
                params2(4).Value = sqlSurnameTo
                params2(5).Value = Sqlposbestemming
                params2(6).Value = dtpAanvFrom
                params2(7).Value = dtpAanvTo
                params2(8).Value = adres1
                params2(9).Value = adres2
                params2(10).Value = adres3
                params2(11).Value = sqlID
                params2(12).Value = sqlAccType
                params2(13).Value = sqlBankCodes
                params2(14).Value = sqlBetaalwyse
                params2(15).Value = sqlBemarker
                params2(16).Value = sqlBybetaling
                params2(17).Value = sqlVoorl
                params2(18).Value = sqlTitel
                params2(19).Value = sqlEmail
                params2(20).Value = sOrderby
                params2(21).Value = sqlDecsAsc

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.ReportFetchSearch", params2)


                If reader.Read() Then
                    Me.MyReportViewer.RefreshReport()
                    Search.searchCri = True
                Else
                    MsgBox("There were no policies that meet the criteria.", MsgBoxStyle.Information)
                    Search.searchCri = False
                    Me.Close()
                    Exit Sub

                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


End Class
