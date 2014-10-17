Public Class BriefBesonderhede1ReportViewer

    Private Sub BriefBesonderhede1ReportViewer(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Language As String
        Dim sqlStatus As String
        Dim sqlSurnameFrom As String
        Dim Bestemming As String
        Dim sqlSurnameTo As String
        Dim sqlVersekeraar As String
        Dim Sqlposbestemming As String
        Dim dtpAanvFrom As String
        Dim dtpAanvTo As String
        Dim strArea As String
        Dim Druk_Vir As String


        Try
            
            If BriefBesonderhede.rdDrukker.Checked Then
                Druk_Vir = "Drukker"
            ElseIf BriefBesonderhede.rdEpos.Checked Then
                Druk_Vir = "E-pos"
            End If

            If BriefBesonderhede.rdSpesifieke.Checked Then
                Select Case BriefBesonderhede.cmbTaal.SelectedIndex
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

            'Sql for status
            Select Case BriefBesonderhede.cmbStatus.SelectedIndex
                Case 0
                    sqlStatus = ""
                Case 1
                    sqlStatus = "0"
                Case 2
                    sqlStatus = "1"
            End Select

            If Gebruiker.titel = "Programmeerder" Then
                If BriefBesonderhede.lstArea.SelectedIndex <> -1 And BriefBesonderhede.lstArea.SelectedIndex <> 0 Then
                    For i = 0 To BriefBesonderhede.lstArea.SelectedItems.Count - 1
                        If i = 0 Then
                            strArea = BriefBesonderhede.lstArea.SelectedItems(i) + "',"
                        Else
                            strArea = strArea + "'" + BriefBesonderhede.lstArea.SelectedItems(i) + "',"
                        End If
                    Next
                    strArea = Mid(strArea, 1, Len(strArea) - 2)
                    'Mid(params(2).Value, Len(params(2).Value) - 1)

                End If
            Else
                For i = 0 To BriefBesonderhede.lstArea.Items.Count - 1
                    If BriefBesonderhede.lstArea.GetSelected(i) Then
                        strArea = strArea + "'" + BriefGeneries.lstArea.SelectedItems(i) + "',"
                    End If
                Next
                strArea = Mid(strArea, 1, Len(strArea) - 1)
                ' Mid(params(2).Value, Len(params(2).Value) - 1)
            End If
            If strArea = "" Then
                strArea = ""
            Else
                strArea = strArea
            End If

            'Surname
            If Trim(BriefBesonderhede.txtVanaf.Text) <> "" Then
                sqlSurnameFrom = Trim(BriefBesonderhede.txtVanaf.Text)
            Else
                sqlSurnameFrom = ""
            End If

            If Trim(BriefBesonderhede.txtTot.Text) <> "" Then
                sqlSurnameTo = BriefBesonderhede.txtTot.Text + "zzzz"
            Else
                sqlSurnameTo = "zzzz"
            End If

            sqlVersekeraar = BriefBesonderhede.cmbVersekeraar.SelectedItem
            'params(6).Value = Me.cmbPosbestemming.SelectedItem
            Select Case BriefBesonderhede.cmbPosbestemming.SelectedIndex
                Case 0
                    Sqlposbestemming = ""
                Case 1
                    Sqlposbestemming = "0"
                Case 2
                    Sqlposbestemming = "1"
                Case 3
                    Sqlposbestemming = "2"
                Case 4
                    Sqlposbestemming = "3"
            End Select


            'If BriefGeneries.dtpAanvFrom.Checked Then

            '    dtpAanvFrom = Format(BriefGeneries.dtpAanvFrom.Value, "yyyy-MM-dd")
            'Else
            '    dtpAanvFrom = ""
            'End If

            'If BriefGeneries.dtpAanvTo.Checked Then
            '    dtpAanvTo = Format(BriefGeneries.dtpAanvTo.Value, "yyyy-MM-dd")
            'Else
            '    dtpAanvTo = ""
            'End If


            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/BriefBesonderhede1"

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Language", Language), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlStatus", sqlStatus), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlArea", strArea), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlSurnameFrom", sqlSurnameFrom), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("DrukVir", Druk_Vir), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Bestemming", Bestemming), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlSurnameTo", sqlSurnameTo), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlVersekeraar", sqlVersekeraar), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Sqlposbestemming", Sqlposbestemming)}





            MyReportViewer.ServerReport.SetParameters(params)
            Me.MyReportViewer.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


End Class
