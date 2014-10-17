Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Imports System.Data.SqlClient
Imports DAL

Public Class KontantReportViewer
    Dim rsreport As New LangtermynPolis
    Dim rskontant As New KontantEntity
    Dim Mdprint2dat As New Print2DatEntity
    Dim TermynJaar As String
    Dim TermynMaand As Object
    Dim Termynmaandbeskrywing As String
    Dim GeldOntvang As Double
    Dim BeskrywingLTP As String
    Dim earned As Double
    Dim UnEarned As Double
    Dim maandeoor As String



    Public Function langtermpolisie() As LangtermynPolis


        Dim item As LangtermynPolis = New LangtermynPolis()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                param.Value = Persoonl.POLISNO

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.ReportFetchTermypolicyForKontant", param)

                If reader.Read() Then
                    If reader("DatumBegin") IsNot DBNull.Value Then
                        item.DatumBegin = reader("DatumBegin")
                    End If
                    If reader("Tydperk") IsNot DBNull.Value Then
                        item.Tydperk = reader("Tydperk")
                    End If
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function
    Sub DeleteKontant()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@User_name", SqlDbType.NVarChar)}

                params(0).Value = Gebruiker.Naam

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[dbo].[DeleteKontantReport]", params)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try

    End Sub
    Sub InsertINTOReportKontant()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Maand", SqlDbType.NVarChar), _
                                                New SqlParameter("@Jaar", SqlDbType.NVarChar), _
                                                New SqlParameter("@GeldOntvang", SqlDbType.NVarChar), _
                                                New SqlParameter("@Beskrywing", SqlDbType.NVarChar), _
                                                New SqlParameter("@Unearned", SqlDbType.NVarChar), _
                                                New SqlParameter("@Earned", SqlDbType.NVarChar), _
                                                New SqlParameter("@MaandeOor", SqlDbType.NVarChar), _
                                                New SqlParameter("@ReportDate", SqlDbType.DateTime), _
                                                New SqlParameter("@User_name", SqlDbType.NVarChar)}

                params(0).Value = Termynmaandbeskrywing
                params(1).Value = TermynJaar
                params(2).Value = GeldOntvang
                If BeskrywingLTP = Nothing Then
                    params(3).Value = ""
                Else
                    params(3).Value = BeskrywingLTP
                End If
                params(4).Value = UnEarned
                params(5).Value = earned
                params(6).Value = maandeoor
                params(7).Value = Format(Now, "dd/MM/yyyy")
                params(8).Value = Gebruiker.Naam

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "dbo.ReportFetchKontant", params)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try

    End Sub

    Public Function FetchKontant() As KontantEntity

        Dim item As KontantEntity = New KontantEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                               New SqlParameter("@TermynMaand", SqlDbType.NVarChar), _
                                               New SqlParameter("@TermynJaar", SqlDbType.NVarChar)}

                param(0).Value = Persoonl.POLISNO
                param(1).Value = TermynMaand
                param(2).Value = TermynJaar

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.ReportFetchKontant", param)

                If reader.Read() Then
                    If reader("vord_premie") IsNot DBNull.Value Then
                        item.vord_premie = reader("vord_premie")
                    End If
                    If reader("LTPtipe") IsNot DBNull.Value Then
                        item.LTPtipe = reader("LTPtipe")
                    End If
                    If reader("tipe") IsNot DBNull.Value Then
                        item.tipe = reader("tipe")
                    End If

                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function
    Public Function Mdprint2() As Print2DatEntity

        Dim item As Print2DatEntity = New Print2DatEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar)}

                param(0).Value = Persoonl.POLISNO
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.ReportFetchKontant", param)

                If reader.Read() Then
                    If reader("Afsluit_dat") IsNot DBNull.Value Then
                        item.Afsluit_dat = reader("Afsluit_dat")
                    End If
                    If reader("Polisno") IsNot DBNull.Value Then
                        item.Polisno = reader("Polisno")
                    End If
                    If reader("Premie2") IsNot DBNull.Value Then
                        item.Premie2 = reader("Premie2")
                    End If
                    If reader("Bet_wyse") IsNot DBNull.Value Then
                        item.bet_wyse = reader("bet_wyse")
                    End If
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function
    Private Sub KontantReportViewe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Clear the table before loading new values
        DeleteKontant()
        Try

            Dim authCookie As Cookie
            Dim authority As String
            authCookie = Nothing
            authority = Nothing
            'Andriette 05/08/2014 maak warnings reg
            'Dim Oor2maanduitgeloopJN, UitgeloopJN, VertoonEarnedJN As Object
            Dim Oor2maanduitgeloopJN, UitgeloopJN As Object
            Dim DateOffered As String
            DateOffered = BriefKontant.DTPicker1.Value
            Dim termyndatum As Object
            Dim totdatnowplus2 As Object
            Dim vanafnowplus2 As Object
            Dim totdattermynmaand As Object
            Dim vanaftermynmaand As Object
            Dim soekdatum As Object
            Dim j As Object
            Dim l As Object
            Dim k As Object
            Dim VorigemaandEarned As Object
            Dim telgeldontvang As Object
            Dim varterugbetaling As Object
            Dim i As Object
            Dim VorigetydperkUnearned As Object
            'Andriette 15/08/2014 gee ;n waarde maak warnings reg
            Dim introw As Object = 0
            Dim reportDate As Object

            UitgeloopJN = "N"
            Oor2maanduitgeloopJN = "N"
            reportDate = Format(Now, "dd/MM/yyyy")

            'gen_getTermPolicyStatus("6", CStr(POLISNO), dateStart, dateEnd, Months, TermDesc, StatusDesc, TermStatus)

            'Me.Status.Text = StatusDesc
            'Me.Label20.Text = TermDesc
            rsreport = langtermpolisie()
            'sSql = "SELECT Langtermynpolis.DatumBegin, Langtermynpolis.DatumEindig, Langtermynpolis.Tydperk, Langtermynpolis.pkLangtermynpolis, Langtermynpolis.polisno from Langtermynpolis where polisno = '" & POLISNO & "'" & " ORDER BY pkLangtermynpolis"
            'rsreport = stats5.OpenRecordset(sSql)

            VorigetydperkUnearned = 0
            'Do While rsreport.Tydperk
            'Stel detail op
            For i = 1 To rsreport.Tydperk
                'Bereken Termyn maand en jaar
                If i = 1 Then
                    TermynMaand = Month(rsreport.DatumBegin)
                    TermynJaar = Year(rsreport.DatumBegin)
                Else
                    TermynMaand = TermynMaand + 1
                    If TermynMaand > 12 Then
                        TermynJaar = TermynJaar + 1
                        TermynMaand = 1
                    End If
                End If

                rskontant = FetchKontant()

                'Bereken Geld ontvang vir hierdie maand en jaar
                GeldOntvang = 0

                varterugbetaling = 0

                BeskrywingLTP = ""
                telgeldontvang = 0

                'Do While Not rsKontant.EOF
                If rskontant.tipe = "TB" Then
                    varterugbetaling = varterugbetaling + rskontant.vord_premie

                    If BeskrywingLTP = "" Then
                        BeskrywingLTP = "Terugbetaling"
                    Else
                        BeskrywingLTP = Trim(BeskrywingLTP) & "," & "Terugbetaling"
                    End If
                Else
                    GeldOntvang = GeldOntvang + rskontant.vord_premie
                    telgeldontvang = telgeldontvang + 1

                    If BeskrywingLTP = "" Then
                        BeskrywingLTP = rskontant.LTPtipe
                    Else
                        BeskrywingLTP = Trim(BeskrywingLTP) & "," + rskontant.LTPtipe
                    End If
                End If
                'rskontant.MoveNext()
                'Loop
                GeldOntvang = System.Math.Round(GeldOntvang, 2)

                GeldOntvang = GeldOntvang - varterugbetaling

                'Earned
                'Kyk of daar 'n stats5d rekord bestaan vir termyn maand?
                VorigemaandEarned = earned
                earned = 0

                'Kyk of vandag se maand ooreenstem met Langtermynpolis begindatum

                k = TermynMaand - 1
                l = TermynJaar
                If k = 0 Then
                    k = 12
                    l = TermynJaar - 1
                End If

                For j = 1 To 31
                    soekdatum = Format(j, "00") & "/" & Format(k, "00") & "/" & (l)

                    'Soek vorige maand se afsluitdatum data
                    'Mdprint2dat.Seek("=", soekdatum, rsreport.Fields("Polisno"))
                    'If Not Mdprint2dat.Nomatch Then

                    'Select only 'Term' betaalwyses
                    'MDprintdat.Seek("=", soekdatum, rsreport.Polisno)
                    'If Not MDprintdat.NoMatch Then
                    Do While Mdprint2dat.Afsluit_dat = soekdatum And Mdprint2dat.Polisno = rsreport.Polisno
                        If Mdprint2dat.bet_wyse = "LT" Then
                            earned = Mdprint2dat.Premie2
                            j = 32
                        End If
                    Loop

                    ' End If

                    'End If
                Next j

                earned = System.Math.Round(earned, 2)

                'Unearned
                If i = 1 Then
                    UnEarned = GeldOntvang + UnEarned
                Else
                    UnEarned = UnEarned + GeldOntvang - VorigemaandEarned
                End If

                UnEarned = System.Math.Round(UnEarned, 2)

                'Maande oor
                If i = 1 Then
                    maandeoor = rsreport.Tydperk
                Else
                    maandeoor = rsreport.Tydperk - i + 1
                End If

                'Is hierdie polis uitgeloop?
                vanaftermynmaand = "01" & "/" & Format(TermynMaand, "00") & "/" & (TermynJaar)
                totdattermynmaand = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, vanaftermynmaand)
                totdattermynmaand = DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, totdattermynmaand)
                If DateDiff(Microsoft.VisualBasic.DateInterval.Day, CDate(Format(Now, "dd/MM/yyyy")), vanaftermynmaand) <= 0 And DateDiff(Microsoft.VisualBasic.DateInterval.Day, CDate(Format(Now, "dd/MM/yyyy")), totdattermynmaand) >= 0 Then
                    If UnEarned - earned <= 0 Then
                        UitgeloopJN = "J"
                    End If
                End If

                'Is hierdie polis oor 2 maande uitgeloop?
                vanafnowplus2 = "01" & "/" & Format(Month(Now), "00") & "/" & (Year(Now))
                vanafnowplus2 = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 2, vanafnowplus2)
                totdatnowplus2 = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, vanafnowplus2)
                totdatnowplus2 = DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, totdatnowplus2)
                termyndatum = "01" & "/" & Format(TermynMaand, "00") & "/" & (TermynJaar)
                If DateDiff(Microsoft.VisualBasic.DateInterval.Day, termyndatum, vanafnowplus2) <= 0 And DateDiff(Microsoft.VisualBasic.DateInterval.Day, termyndatum, totdatnowplus2) >= 0 Then
                    If UnEarned - earned <= 0 Then
                        Oor2maanduitgeloopJN = "J"
                    End If
                End If

                'Detail
                introw = introw + 1

                Select Case TermynMaand
                    Case 1
                        Termynmaandbeskrywing = "Januarie"
                    Case 2
                        Termynmaandbeskrywing = "Februarie"
                    Case 3
                        Termynmaandbeskrywing = "Maart"
                    Case 4
                        Termynmaandbeskrywing = "April"
                    Case 5
                        Termynmaandbeskrywing = "Mei"
                    Case 6
                        Termynmaandbeskrywing = "Junie"
                    Case 7
                        Termynmaandbeskrywing = "Julie"
                    Case 8
                        Termynmaandbeskrywing = "Augustus"
                    Case 9
                        Termynmaandbeskrywing = "September"
                    Case 10
                        Termynmaandbeskrywing = "Oktober"
                    Case 11
                        Termynmaandbeskrywing = "November"
                    Case 12
                        Termynmaandbeskrywing = "Desember"
                End Select


                InsertINTOReportKontant()
            Next

            UnEarned = UnEarned - earned
            Dim reportdateNow As String
            reportdateNow = Format(Now, "yyyy/MM/dd")

            MyReportViewer.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)

            MyReportViewer.ServerReport.ReportPath = "/Mooirivier/Kontant"

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", Persoonl.POLISNO), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", Persoonl.TAAL), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Area_kode", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("ReportDate", reportdateNow), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("User_name", Gebruiker.Naam)}



            MyReportViewer.ServerReport.SetParameters(params)
            Me.MyReportViewer.RefreshReport()


        Catch ex As Exception
        End Try
    End Sub
End Class
