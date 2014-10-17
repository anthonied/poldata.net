Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Public Class BriefStatusReportViewer

    Private Sub BriefStatusReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing
        Language = Persoonl.TAAL
        sqlStatus = ""
        sqlSurnameFrom = ""
        Druk_Vir = ""
        Bestemming = ""
        sqlSurnameTo = ""
        sqlVersekeraar = ""
        Sqlposbestemming = ""
        dtpAanvFrom = ""
        dtpAanvTo = ""


        strArea = ""
        Try
            Select Case BriefStatus.txtFormToPopulate.Text

                Case "BriefBesonderhede"
                    BriefBesonderhede.rdSpesifieke.Checked = True
                    If BriefBesonderhede.rdSpesifieke.Checked Then
                        Select Case BriefBesonderhede.cmbTaal.SelectedIndex
                            Case 0
                                BriefStatus.briefLanguage = ""
                            Case 1 'Afr
                                BriefStatus.briefLanguage = 0
                            Case 2 'Eng
                                BriefStatus.briefLanguage = 1
                        End Select
                    Else
                        BriefStatus.briefLanguage = ""
                    End If

                    Language = BriefStatus.briefLanguage

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
                        If BriefGeneries.lstArea.SelectedIndex <> -1 And BriefGeneries.lstArea.SelectedIndex <> 0 Then
                            For i = 0 To BriefBesonderhede.lstArea.SelectedItems.Count - 1
                                If i = 0 Then
                                    strArea = BriefBesonderhede.lstArea.SelectedItems(i) + "',"
                                Else
                                    strArea = strArea + "'" + BriefBesonderhede.lstArea.SelectedItems(i) + "',"
                                End If


                            Next
                            strArea = Mid(strArea, 1, Len(strArea) - 2)
                        End If
                    Else
                        For i = 0 To BriefBesonderhede.lstArea.Items.Count - 1
                            If BriefBesonderhede.lstArea.GetSelected(i) Then
                                strArea = strArea + "'" + BriefBesonderhede.lstArea.SelectedItems(i) + "',"
                            End If
                        Next
                        strArea = Mid(strArea, 1, Len(strArea) - 1)

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

                    dtpAanvFrom = ""

                    dtpAanvTo = ""

                Case "BriefGeneries"
                    BriefGeneries.rdSpesifieke.Checked = True
                    If BriefGeneries.rdSpesifieke.Checked Then
                        Select Case BriefGeneries.cmbTaal.SelectedIndex
                            Case 0
                                BriefStatus.briefLanguage = ""
                            Case 1 'Afr
                                BriefStatus.briefLanguage = 0
                            Case 2 'Eng
                                BriefStatus.briefLanguage = 1
                        End Select
                    Else
                        BriefStatus.briefLanguage = ""
                    End If

                    Language = BriefStatus.briefLanguage

                    'Sql for status
                    Select Case BriefGeneries.cmbStatus.SelectedIndex
                        Case 0
                            sqlStatus = ""
                        Case 1
                            sqlStatus = "0"
                        Case 2
                            sqlStatus = "1"
                    End Select

                    If Gebruiker.titel = "Programmeerder" Then
                        If BriefGeneries.lstArea.SelectedIndex <> -1 And BriefGeneries.lstArea.SelectedIndex <> 0 Then
                            For i = 0 To BriefGeneries.lstArea.SelectedItems.Count - 1
                                If i = 0 Then
                                    strArea = BriefGeneries.lstArea.SelectedItems(i) + "',"
                                Else
                                    strArea = strArea + "'" + BriefGeneries.lstArea.SelectedItems(i) + "',"
                                End If


                            Next
                            strArea = Mid(strArea, 1, Len(strArea) - 2)


                        End If
                    Else
                        For i = 0 To BriefGeneries.lstArea.Items.Count - 1
                            If BriefGeneries.lstArea.GetSelected(i) Then
                                strArea = strArea + "'" + BriefGeneries.lstArea.SelectedItems(i) + "',"
                            End If
                        Next
                        strArea = Mid(strArea, 1, Len(strArea) - 1)

                    End If
                    If strArea = "" Then
                        strArea = ""
                    Else
                        strArea = strArea
                    End If

                    'Surname
                    If Trim(BriefGeneries.txtVanaf.Text) <> "" Then
                        sqlSurnameFrom = Trim(BriefGeneries.txtVanaf.Text)
                    Else
                        sqlSurnameFrom = ""
                    End If

                    If Trim(BriefGeneries.txtTot.Text) <> "" Then
                        sqlSurnameTo = BriefGeneries.txtTot.Text + "zzzz"
                    Else
                        sqlSurnameTo = "zzzz"
                    End If

                    sqlVersekeraar = BriefGeneries.cmbVersekeraar.SelectedItem

                    Select Case BriefGeneries.cmbPosbestemming.SelectedIndex
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


                    If BriefGeneries.dtpAanvFrom.Checked Then

                        dtpAanvFrom = Format(BriefGeneries.dtpAanvFrom.Value, "yyyy-MM-dd")
                    Else
                        dtpAanvFrom = ""
                    End If

                    If BriefGeneries.dtpAanvTo.Checked Then
                        dtpAanvTo = Format(BriefGeneries.dtpAanvTo.Value, "yyyy-MM-dd")
                    Else
                        dtpAanvTo = ""
                    End If

                Case "BriefSkedule"
                    BriefSkedule.rdSpesifieke.Checked = True
                    If BriefSkedule.rdSpesifieke.Checked Then
                        Select Case BriefSkedule.cmbTaal.SelectedIndex
                            Case 0
                                BriefStatus.briefLanguage = ""
                            Case 1 'Afr
                                BriefStatus.briefLanguage = 0
                            Case 2 'Eng
                                BriefStatus.briefLanguage = 1
                        End Select
                    Else
                        BriefStatus.briefLanguage = ""
                    End If

                    If BriefSkedule.rdKantoor.Checked Then
                        Druk_Vir = "Kantoor; "
                    Else
                        Druk_Vir = "Kliënt; "
                    End If
                    If BriefSkedule.rdDrukker.Checked Then
                        Bestemming = "Drukker"
                    Else
                        Bestemming = "E-pos"
                    End If

                    Language = BriefStatus.briefLanguage


                    'Sql for status
                    Select Case BriefSkedule.cmbStatus.SelectedIndex
                        Case 0
                            sqlStatus = ""
                        Case 1
                            sqlStatus = "0"
                        Case 2
                            sqlStatus = "1"
                    End Select

                    If Gebruiker.titel = "Programmeerder" Then
                        If BriefSkedule.lstArea.SelectedIndex <> -1 And BriefSkedule.lstArea.SelectedIndex <> 0 Then
                            For i = 0 To BriefSkedule.lstArea.SelectedItems.Count - 1
                                If i = 0 Then
                                    strArea = BriefSkedule.lstArea.SelectedItems(i) + "',"
                                Else
                                    strArea = strArea + "'" + BriefSkedule.lstArea.SelectedItems(i) + "',"
                                End If


                            Next
                            strArea = Mid(strArea, 1, Len(strArea) - 2)
                          
                        End If
                    Else
                        For i = 0 To BriefSkedule.lstArea.Items.Count - 1
                            If BriefSkedule.lstArea.GetSelected(i) Then
                                strArea = strArea + "'" + BriefSkedule.lstArea.SelectedItems(i) + "',"
                            End If
                        Next
                        strArea = Mid(strArea, 1, Len(strArea) - 1)

                    End If
                    If strArea = "" Then
                        strArea = ""
                    Else
                        strArea = strArea
                    End If

                    'Surname
                    If Trim(BriefSkedule.txtVanaf.Text) <> "" Then
                        sqlSurnameFrom = Trim(BriefSkedule.txtVanaf.Text)
                    Else
                        sqlSurnameFrom = ""
                    End If

                    If Trim(BriefSkedule.txtTot.Text) <> "" Then
                        sqlSurnameTo = BriefSkedule.txtTot.Text + "zzzz"
                    Else
                        sqlSurnameTo = "zzzz"
                    End If

                    sqlVersekeraar = BriefSkedule.cmbVersekeraar.SelectedItem

                    Select Case BriefSkedule.cmbPosbestemming.SelectedIndex
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


                    If BriefSkedule.dtpGewysig.Checked Then

                        dtpAanvFrom = Format(BriefSkedule.dtpGewysig.Value, "yyyy-MM-dd")
                    Else
                        dtpAanvFrom = ""
                    End If


            End Select


            MyReportViewer.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)

            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/BriefStatus"

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Language", Language), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlStatus", sqlStatus), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Taal", Persoonl.TAAL), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlArea", strArea), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlSurnameFrom", sqlSurnameFrom), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("DrukVir", Druk_Vir), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Bestemming", Bestemming), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlSurnameTo", sqlSurnameTo), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("sqlVersekeraar", sqlVersekeraar), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("Sqlposbestemming", Sqlposbestemming), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("dtpAanvFrom", dtpAanvFrom), _
                                                                             New Microsoft.Reporting.WinForms.ReportParameter("dtpAanvTo", dtpAanvTo)}




            MyReportViewer.ServerReport.SetParameters(params)
            Me.MyReportViewer.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


End Class
