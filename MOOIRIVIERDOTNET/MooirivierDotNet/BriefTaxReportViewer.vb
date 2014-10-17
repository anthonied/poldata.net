Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Public Class BriefTaxReportViewer
    Inherits BaseForm
    Private Sub BriefTaxReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing

        Try

            MyReportViewer.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)

            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/BriefTaxCertificate"

            Dim language As Byte
            Dim fromdateDisplay As String
            Dim todateDisplay As String
            Dim PropertyCoverType As String
            'Dim Security As String
            Dim BTWno As String
            Dim strKlas As String
            Dim strItem As String
            Dim subtotaal As Double
            Dim BTWteen As String
            Dim Total As String
            Dim premDate As String
            Dim itemDesc As String
            Dim dblItembedrag As String
            Dim btwPersentasie As Single
            'Dim fromdate As String
            'Dim todate As String
            Dim Checked As String
            Dim Premie As String

            strKlas = ""
            strItem = ""

            btwPersentasie = 14



            ssql = BriefBelasting.FetchPrint2

            Total = 0
            dblItembedrag = 0
            'Date parameters
            fromdateDisplay = DateSerial(Year(BriefBelasting.DTPicker1.Value), Month(BriefBelasting.DTPicker1.Value), 1)
            todateDisplay = DateSerial(Year(BriefBelasting.DTPicker2.Value), Month(BriefBelasting.DTPicker2.Value) + 1, 0)

            'BTWnr parameter
            'rsAreaVerseke = BriefBelasting.FetchVersekeraarForArea()
            If rsAreaVerseke.BTWNommer = "" Then
                If Persoonl.TAAL = 0 Then
                    BTWno = "n.v.t"
                Else
                    BTWno = "n/a"
                End If
            Else
                BTWno = rsAreaVerseke.BTWNommer
            End If
            'Klas and Item parameters for vehicle
            rsVoertuie = BriefBelasting.FetchVoertuieForPrint()
            'Klas and Item parameters for property
            rsProperty = GetHuisByPrimaryKey(pkHuis)
            If BriefBelasting.optItem.Checked Then
                Select Case Trim(Mid(BriefBelasting.ListItemDesc, 1, 12)) '(Mid(BriefBelasting.ListItemDesc, 1, 12))
                    Case "Voertuig :"
                        PropertyCoverType = " "
                        strItem = Mid(BriefBelasting.ListItemDesc, 15, BriefBelasting.ListItemDesc.Length - 1)
                        If Persoonl.TAAL = 0 Then
                            strKlas = "Voertuig"
                        Else
                            strKlas = "Vehicle"
                        End If
                    Case "* Voertuig :"
                        strItem = Mid(BriefBelasting.ListItemDesc, 15, BriefBelasting.ListItemDesc.Length - 1)
                        PropertyCoverType = " "
                        If Persoonl.TAAL = 0 Then
                            strKlas = "Voertuig"
                        Else
                            strKlas = "Vehicle"
                        End If
                    Case "Eiendom HE:"
                        PropertyCoverType = "HE"
                        strItem = Mid(BriefBelasting.ListItemDesc, 15, BriefBelasting.ListItemDesc.Length - 1)
                        If Persoonl.TAAL = 0 Then
                            If PropertyCoverType = "HE" Then
                                strKlas = "Huiseienaar"
                            Else
                                strKlas = "Huisbewoner"
                            End If
                        Else
                            If PropertyCoverType = "HE" Then
                                strKlas = "Homeowner"
                            Else
                                strKlas = "Householder"
                            End If
                        End If
                    Case "Eiendom HB:"
                        PropertyCoverType = "HB"
                        strItem = Mid(BriefBelasting.ListItemDesc, 15, BriefBelasting.ListItemDesc.Length - 1)
                        If Persoonl.TAAL = 0 Then
                            If PropertyCoverType = "HB" Then
                                strKlas = "Huiseienaar"
                            Else
                                strKlas = "Huisbewoner"
                            End If
                        Else
                            If PropertyCoverType = "HB" Then
                                strKlas = "Homeowner"
                            Else
                                strKlas = "Householder"
                            End If
                        End If
                    Case "* Eiendom HE"
                        strItem = Mid(BriefBelasting.ListItemDesc, 15, BriefBelasting.ListItemDesc.Length - 1)
                        PropertyCoverType = "HE"
                        If Persoonl.TAAL = 0 Then
                            If PropertyCoverType = "HE" Then
                                strKlas = "Huiseienaar"
                            Else
                                strKlas = "Huisbewoner"
                            End If
                        Else
                            If PropertyCoverType = "HE" Then
                                strKlas = "Homeowner"
                            Else
                                strKlas = "Householder"
                            End If
                        End If
                    Case "* Eiendom HB"
                        strItem = Mid(BriefBelasting.ListItemDesc, 15, BriefBelasting.ListItemDesc.Length - 1)
                        PropertyCoverType = "HB"
                        If Persoonl.TAAL = 0 Then
                            If PropertyCoverType = "HB" Then
                                strKlas = "Huiseienaar"
                            Else
                                strKlas = "Huisbewoner"
                            End If
                        Else
                            If PropertyCoverType = "HB" Then
                                strKlas = "Homeowner"
                            Else
                                strKlas = "Householder"
                            End If
                        End If
                    Case Else
                        PropertyCoverType = " "
                End Select

                subtotaal = Format(subtotaal + (dblItembedrag / 1.14), "0.00")

                Premie = Format(System.Math.Round(dblItembedrag / ((btwPersentasie / 100) + 1), 2), "0.00")
            Else
                subtotaal = Format(subtotaal + (ssql.Premie2 / 1.14), "0.00")

                Premie = Format(System.Math.Round(ssql.Premie2 / ((btwPersentasie / 100) + 1), 2), "0.00")

            End If
            subtotaal = System.Math.Round(subtotaal, 2)

            BTWteen = Format(System.Math.Round(subtotaal * (btwPersentasie / 100), 2), "0.00")

            Total = Format(System.Math.Round(subtotaal * ((btwPersentasie / 100) + 1), 2), "0.00")

            premDate = DateSerial(Year(ssql.Afsluit_dat), Month(ssql.Afsluit_dat) + 1, 1)

            'check for yearly payments and date parameters
            If Persoonl.BET_WYSE = "2" Then
                itemDesc = Year(premDate)
            Else
                itemDesc = gen_getMonthName(language, Month(premDate)) & " " & Year(premDate)
            End If
            If BriefBelasting.optItem.Checked Then
                Checked = "1"
            Else
                Checked = "0"
            End If

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("area_kode", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", Persoonl.POLISNO), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", Persoonl.TAAL), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("BTWno", BTWno), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Klas", strKlas), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Item", strItem), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("itemDesc", itemDesc), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Subtotaal", subtotaal), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("FromDate", fromdateDisplay), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("ToDate", todateDisplay), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("BTWteen", BTWteen), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Premie", Premie), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Checked", Checked), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Totaal", Total)}


            MyReportViewer.ServerReport.SetParameters(params)
            Me.MyReportViewer.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    
End Class
