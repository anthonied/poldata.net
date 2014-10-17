Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Imports System.Data.SqlClient
Imports DAL

Public Class BriefSkeduleReportViewer

    Private Sub BriefSkeduleReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing

        Try

            Dim AfriEngl As String
            Dim termInformation As String
            Dim longtermMonths As String
            Dim PlipCoverValue As Integer
            Dim ChkKantoor As Integer
            Dim chkBesonderherdeVersekerde As Integer
            Dim chkOpsommingVersekering As Integer
            Dim chkUiteensettingPremie As Integer
            Dim chkbesonderherdeItems As Integer
            Dim chkBybetalings As Integer
            Dim chkLaastewysigings As Integer
            Dim chkEndossemente As Integer
            Dim chkAddisioneleVoorwaardes As Integer
            Dim totPaid As Double
            Dim Startdate As String
            Dim Enddate As String
            Dim pol_druk As String
            termInformation = ""
            longtermMonths = ""

            'Assign Policy number
            If BriefSkedule.rdHuidig.Checked = True Then
                'Andriette 01/08/2013 verander die global variable
                glbPolicyNumber = Persoonl.POLISNO
            ElseIf BriefSkedule.rdSpesifieke.Checked = True Then
                glbPolicyNumber = BriefStatus.DataGridView1.Rows(0).Cells(0).Value
            Else
                BriefSkedule.rdSpesifieke.Checked = True
                glbPolicyNumber = BriefStatus.DataGridView1.SelectedRows(0).Cells(0).Value
            End If
            'Poldruk parameter
            If BriefSkedule.rdKlient.Checked = True Then
                pol_druk = "J"
            Else
                pol_druk = ""
            End If

            totPaid = 0
            LongTermPolicy = ReportFetchLangTermPolicy()
            Startdate = Format(LongTermPolicy.DatumBegin, "dd/MM/yyyy")
            Enddate = Format(LongTermPolicy.DatumEindig, "dd/MM/yyyy")


            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@startdate", SqlDbType.NVarChar), _
                                                New SqlParameter("@enddate", SqlDbType.NVarChar)}

                param(0).Value = Persoonl.POLISNO
                param(1).Value = Startdate
                param(2).Value = Enddate

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[Report_gen_getTermPolicyAmtPaid]", param)

                Do While reader.Read
                    If reader("tipe") = "TB" Then
                        totPaid = totPaid - reader("vord_premie")
                    Else
                        totPaid = totPaid + reader("vord_premie")
                    End If
                Loop
            End Using

            PrimaryKeyVoertuie = FetchPKvoertuie()
            fetchHuisForGeyser = ReportFetchHuisPk()
            FetchEndosidentifikasie = ReportFetchEndosidentifikasie()

            If Persoonl.TAAL = 0 Then
                AfriEngl = "A"
            Else
                AfriEngl = "E"
            End If

            If Trim(Persoonl.BET_WYSE) = "6" Then
                If strTermStatus <> 4 And strTermStatus <> 5 Then
                    termInformation = strTermDesc
                    longtermMonths = strTermMonthCount
                End If
            Else
                longtermMonths = 1 'Default to one month policy
                termInformation = ""
                'Reset other values
                strTermDesc = ""
                strTermStatusDesc = ""
                strTermStatus = 5
            End If
            If BriefSkedule.rdHuidig.Checked = True And BriefSkedule.rdKlient.Checked = True Then
                chkBesonderherdeVersekerde = 1
                chkOpsommingVersekering = 1
                chkUiteensettingPremie = 1
                chkbesonderherdeItems = 1
                chkBybetalings = 1
                chkLaastewysigings = 1
                chkEndossemente = 1
                chkAddisioneleVoorwaardes = 1
            ElseIf BriefSkedule.rdHuidig.Checked = True And BriefSkedule.rdKantoor.Checked = True Then

                If BriefSkedule.chkBesonderhedeVersekerde.Checked = True Then
                    chkBesonderherdeVersekerde = 1
                Else
                    chkBesonderherdeVersekerde = 0
                End If
                If BriefSkedule.chkOpsommingVersekering.Checked = True Then
                    chkOpsommingVersekering = 1
                Else
                    chkOpsommingVersekering = 0
                End If
                If BriefSkedule.chkUiteensettingPremie.Checked = True Then
                    chkUiteensettingPremie = 1
                Else
                    chkUiteensettingPremie = 0
                End If
                If BriefSkedule.chkBesonderhedeItems.Checked = True Then
                    chkbesonderherdeItems = 1
                Else
                    chkbesonderherdeItems = 0
                End If
                If BriefSkedule.chkBybetalings.Checked = True Then
                    chkBybetalings = 1
                Else
                    chkBybetalings = 0
                End If
                If BriefSkedule.chkLaasteWysigings.Checked = True Then
                    chkLaastewysigings = 1
                Else
                    chkLaastewysigings = 0
                End If
                If BriefSkedule.chkEdossemente.Checked = True Then
                    chkEndossemente = 1
                Else
                    chkEndossemente = 0
                End If
                If BriefSkedule.chkAddisioneleVoorwaardes.Checked = True Then
                    chkAddisioneleVoorwaardes = 1
                Else
                    chkAddisioneleVoorwaardes = 0
                End If

            ElseIf BriefSkedule.rdSpesifieke.Checked = True And BriefSkedule.rdKlient.Checked = True Then
                chkBesonderherdeVersekerde = 1
                chkOpsommingVersekering = 1
                chkUiteensettingPremie = 1
                chkbesonderherdeItems = 1
                chkBybetalings = 1
                chkLaastewysigings = 1
                chkEndossemente = 1
                chkAddisioneleVoorwaardes = 1
            Else
                If BriefSkedule.chkBesonderhedeVersekerde.Checked = True Then
                    chkBesonderherdeVersekerde = 1
                Else
                    chkBesonderherdeVersekerde = 0
                End If
                If BriefSkedule.chkOpsommingVersekering.Checked = True Then
                    chkOpsommingVersekering = 1
                Else
                    chkOpsommingVersekering = 0
                End If
                If BriefSkedule.chkUiteensettingPremie.Checked = True Then
                    chkUiteensettingPremie = 1
                Else
                    chkUiteensettingPremie = 0
                End If
                If BriefSkedule.chkBesonderhedeItems.Checked = True Then
                    chkbesonderherdeItems = 1
                Else
                    chkbesonderherdeItems = 0
                End If
                If BriefSkedule.chkBybetalings.Checked = True Then
                    chkBybetalings = 1
                Else
                    chkBybetalings = 0
                End If
                If BriefSkedule.chkLaasteWysigings.Checked = True Then
                    chkLaastewysigings = 1
                Else
                    chkLaastewysigings = 0
                End If
                If BriefSkedule.chkEdossemente.Checked = True Then
                    chkEndossemente = 1
                Else
                    chkEndossemente = 0
                End If
                If BriefSkedule.chkAddisioneleVoorwaardes.Checked = True Then
                    chkAddisioneleVoorwaardes = 1
                Else
                    chkAddisioneleVoorwaardes = 0
                End If
            End If

            'Checkboxes to values
            If BriefSkedule.rdKantoor.Checked = True Then
                ChkKantoor = 1
            Else
                ChkKantoor = 0
            End If

            'flip value parameter

            'Andriette 14/08/2014 skuif die waarde na die tabel
            'PlipCoverValue = gen_getPlipCoverValue(Persoonl.PLIP1)
            PlipCoverValue = Constants.PlipCoverValue

            MyReportViewer.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)

            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/BriefSkedule"
            'Andriette 01/08/2013 verander die global variable
            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", glbPolicyNumber), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", Persoonl.TAAL), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Area_kode", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("pkVoertuie", PrimaryKeyVoertuie.pkVoertuie), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("pkHuis", fetchHuisForGeyser.pkHuis), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Language", Persoonl.TAAL), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Branchcode", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Endoslist", FetchEndosidentifikasie.Endosidentifikasie), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("TaalAfriEng", AfriEngl), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("termInformation", termInformation), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("StartAfsluit", Startdate), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("EndAfsluit", Enddate), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("longtermMonths", longtermMonths), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("KontantTotal", totPaid), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("PlipCoverValue", PlipCoverValue), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("pol_druk", pol_druk), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("bet_wyse", Persoonl.BET_WYSE), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("ChkKantoor", ChkKantoor), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("chkBesonderherdeVersekerde", chkBesonderherdeVersekerde), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("chkOpsommingVersekering", chkOpsommingVersekering), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("LongtermStatus", strTermStatus), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("chkUiteensettingPremie", chkUiteensettingPremie), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("chkbesonderherdeItems", chkbesonderherdeItems), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("chkBybetalings", chkBybetalings), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("chkLaastewysigings", chkLaastewysigings), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("chkEndossemente", chkEndossemente), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("chkAddisioneleVoorwaardes", chkAddisioneleVoorwaardes)}



            MyReportViewer.ServerReport.SetParameters(params)
            Me.MyReportViewer.RefreshReport()
        Catch ex As Exception
        End Try
    End Sub


End Class
