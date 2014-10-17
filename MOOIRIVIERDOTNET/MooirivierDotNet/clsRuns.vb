'*************************************
'Linkie 10/06/2013
'Insert Class that will be used for all old Stats and Multistats runs - any runs done on Poldata
'*************************************
Option Strict Off
Option Explicit On

Imports System.Data.SqlClient
Imports DAL


Public Class clsRuns
    Dim strUitgeloopJN As String = "N"
    Dim strOor2MaandeUitgeloopJN As String = "N"
    Dim strVertoonEarnedJN As String = "N"

    'Linkie 10/06/2013 - update table gebruikerlopies with all runs done by user
    Public Sub UpdateGebrukerLopiesRuns(ByVal strDescription As String, ByVal dte2VTRunDate As Date)

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Gebruiker", SqlDbType.NVarChar), _
                                                New SqlParameter("@Datum", SqlDbType.DateTime), _
                                                New SqlParameter("@Beskrywing", SqlDbType.NVarChar), _
                                                New SqlParameter("@AfsluitDatum", SqlDbType.DateTime)}


                params(0).Value = Gebruiker.Naam
                params(1).Value = Now
                params(2).Value = strDescription
                params(3).Value = dte2VTRunDate

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.UpdateGebruikerLopies2", params)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

    End Sub
    '*Purpose - Get Insurer that was chosen
    '*Inputs - glbVersekeraar
    '*Outputs - intPkInsurer, StrInsured, StrDisfile
    Public Sub GetInsurer()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@intVersekeraar", SqlDbType.Int)
                param.Value = glbVersekeraar

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVersekeraarPerPK", param)

                Do While reader.Read
                    intPKInsurer = reader("pkversekeraar")
                    strInsured = reader("Naam")
                    strDisFile = reader("Disfile")
                    dteInsuredStartDate = reader("datestarted")
                Loop
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    '*Purpose - Get Insurer and areas that was chosen
    '*Inputs - glbVersekeraar
    '*Outputs - intPkInsurer, StrInsured, strTak_afkorting
    Public Sub GetInsurerArea()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@intVersekeraar", SqlDbType.Int)
                param.Value = glbVersekeraar

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVersekeraarAreaPerVersekeraarPK", param)

                If reader.Read Then
                    intPKInsurer = reader("pkversekeraar")
                    strInsured = reader("Naam")
                    strTak_afkorting = reader("tak_afkorting")
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    '*Purpose - Get area that was chosen
    '*Inputs - strArea
    '*Outputs - strAreaBesk
    Public Function GetArea(ByVal strArea As String) As String
        Dim strAreaBesk As String = ""
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@Area_kode", SqlDbType.NVarChar)
                param.Value = strArea

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAreaByPolisNo", param)

                If reader.Read Then
                    strAreaBesk = reader("area_besk")
                End If

                Return strAreaBesk

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function
    '*Purpose - Get branch 
    '*Inputs - none
    '*Outputs - Tak table
    Public Function GetTak()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchTak]")
                Dim item As TakEntity = New TakEntity()
                If reader.Read() Then
                    If reader("Tak_naam") IsNot DBNull.Value Then
                        item.TAKNAAM = reader("Tak_naam")
                    End If
                    If reader("Tak_afkorting") IsNot DBNull.Value Then
                        item.Tak_afkorting = reader("Tak_afkorting")
                    End If
                    If reader("Tak_Posbus") IsNot DBNull.Value Then
                        item.TAK_POBUS = reader("Tak_Posbus")
                    End If
                    If reader("Tak_Dorp") IsNot DBNull.Value Then
                        item.TAKDORP = reader("Tak_Dorp")
                    End If
                    If reader("Tak_Poskode") IsNot DBNull.Value Then
                        item.TAK_POSKODE = reader("Tak_Poskode")
                    End If
                    If reader("Tak_Straat") IsNot DBNull.Value Then
                        item.TAK_STRAAT = reader("Tak_Straat")
                    End If
                    If reader("Tak_Tel") IsNot DBNull.Value Then
                        item.TAK_TEL = reader("Tak_Tel")
                    End If
                    If reader("Tak_Faks") IsNot DBNull.Value Then
                        item.TAK_FAKS = reader("Tak_Faks")
                    End If
                    If reader("Tak_Modem") IsNot DBNull.Value Then
                        item.TAK_MODERM = reader("Tak_Modem")
                    End If
                    If reader("Tak_Univ") IsNot DBNull.Value Then
                        item.TAK_UNIV = reader("Tak_Univ")
                    End If
                    If reader("Tak_Unive") IsNot DBNull.Value Then
                        item.TAK_UNIVE = reader("Tak_Unive")
                    End If
                End If
                Return item

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
            Exit Function
        End Try
    End Function
    '*Purpose - Get the CLRS area for this branch
    '*Inputs - tak_afkorting
    '*Outputs - strCLRSArea, sngSalesPerson
    Public Sub gen_GetCLRSArea(strTak_afkorting As String)
        'Tak_kode word gehuisves in Area(by CLRS)
        Select Case UCase(strTak_afkorting)
            Case "BEL"
                strCLRSArea = "7"
                sngSalesPerson = 14 'Val(strCLRSArea) + 1
            Case "BFN"
                strCLRSArea = "8"
                sngSalesPerson = 15 'Val(strCLRSArea) + 1
            Case "JEF"
                strCLRSArea = "9"
                sngSalesPerson = 16 'Val(strCLRSArea) + 1
            Case "JHB"
                strCLRSArea = "10"
                sngSalesPerson = 17 'Val(strCLRSArea) + 1
            Case "JHN"
                strCLRSArea = "11"
                sngSalesPerson = 18 'Val(strCLRSArea) + 1
            Case "KDP"
                strCLRSArea = "12"
                sngSalesPerson = 19 'Val(strCLRSArea) + 1
            Case "MSB"
                strCLRSArea = "13"
                sngSalesPerson = 20 'Val(strCLRSArea) + 1
            Case "PCS"
                strCLRSArea = "14"
                sngSalesPerson = 21 'Val(strCLRSArea) + 1
            Case "PTA"
                strCLRSArea = "15"
                sngSalesPerson = 22 'Val(strCLRSArea) + 1
            Case "RIE"
                strCLRSArea = "16"
                sngSalesPerson = 23 'Val(strCLRSArea) + 1
            Case "SUI"
                strCLRSArea = "17"
                sngSalesPerson = 24 'Val(strCLRSArea) + 1
            Case "STB"
                strCLRSArea = "18"
                sngSalesPerson = 25 'Val(strCLRSArea) + 1
            Case "VDH"
                strCLRSArea = "19"
                sngSalesPerson = 26 'Val(strCLRSArea) + 1
            Case "VDB"
                strCLRSArea = "20"
                sngSalesPerson = 27 'Val(strCLRSArea) + 1
            Case "FLG"
                strCLRSArea = "21"
                sngSalesPerson = 28 'Val(strCLRSArea) + 1
            Case Else
                strCLRSArea = "Z"   'Not found
        End Select
    End Sub
    '*Purpose - To get the Max Afsluit_dat in Maand with a certain Betaalwyse
    '*Inputs - StrParamaterMaandBetaalwyse
    '*Outputs - glbMaxAfsluitdatMaand
    Public Sub MaxAfsluitDatMaand(ByVal strParamaterMaandBetaalwyse As String)
        'last afsluitdatum
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@Betaalwyse", SqlDbType.NVarChar)
                param.Value = strParamaterMaandBetaalwyse

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchMaxDateFromMaand", param)
                Do While reader.Read
                    glbMaxAfsluitDatMaand = reader("dteAfsluit")
                Loop
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    '*Purpose - get the 2de vt lopie run date
    '*Outputs - dte2VTRunDate
    Public Function Get2ndVTRunDate()
        Dim dte2VTRunDate As Date

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@Tipe", SqlDbType.NVarChar)
                param.Value = "2de VT Lopie"

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5d.Fetch2deVtAfsluitdatum", param)
                Do While reader.Read
                    dte2VTRunDate = reader("datumtoegevoer")
                Loop
                Return dte2VTRunDate
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function
    '*Purpose - Was this policy cancelled between the two dates supplied?
    '*Inputs - strPolisno, dte2VTRunDate, dteToday
    '*Outputs - strCancelled
    Public Function GetPolicyCancelled(strPolisno As String, dte2VTRunDate As Date, dteToday As Date, strCancelled As String) As String

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@Vanaf", SqlDbType.Date), _
                                                New SqlParameter("@Tot", SqlDbType.Date)}


                params(0).Value = strPolisno
                params(1).Value = dte2VTRunDate
                params(2).Value = dteToday

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Poldata5.FetchGekansPolisTussenDatums", params)

                If reader.Read Then
                    strCancelled = "Yes"
                Else
                    strCancelled = "No"
                End If

                Return strCancelled
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
            Exit Function
        End Try
    End Function
    '*Purpose - Get this vehicles description
    '*Inputs - blnAnder, strKode, strEeu, strJaar
    '*Outputs - strDescription
    Public Sub GetVehicleDescription(blnAnder As Boolean, strKode As String, strEeu As String, strJaar As String)
        Dim strTable As String

        If blnAnder = True Then
            strTable = "poldata5.FetchMotorKodeA_VOERTUIG"
        Else
            strTable = "poldata5.FetchMotorByKode"
        End If

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@KODE", SqlDbType.NVarChar), _
                                               New SqlParameter("@EEU", SqlDbType.NVarChar), _
                                               New SqlParameter("@JAAR", SqlDbType.NVarChar)}

                param(0).Value = strKode
                param(1).Value = strEeu
                param(2).Value = strJaar

                Dim readerMotor As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strTable, param)

                If readerMotor.Read Then
                    strDescriptionVehicle = Trim(readerMotor("maak")) & " " & Trim(readerMotor("besk"))
                    strVoertuieKode = IIf(readerMotor("kode") Is DBNull.Value, "", readerMotor("kode"))
                    strVoertuieJaar = IIf(readerMotor("jaar") Is DBNull.Value, "", readerMotor("jaar"))
                    strVoertuieMaak = IIf(readerMotor("maak") Is DBNull.Value, "", readerMotor("maak"))
                    strVoertuieBesk = IIf(readerMotor("besk") Is DBNull.Value, "", readerMotor("besk"))
                    strVoertuieTipe = IIf(readerMotor("tipe") Is DBNull.Value, "", readerMotor("tipe"))
                    strVoertuieEeu = IIf(readerMotor("eeu") Is DBNull.Value, "", readerMotor("eeu"))
                    If blnAnder = False Then
                        strVoertuieCC = IIf(readerMotor("cc") Is DBNull.Value, "", readerMotor("cc"))
                        strVoertuieCylinder = IIf(readerMotor("cylinder") Is DBNull.Value, "", readerMotor("cylinder"))
                        strVoertuieBeginDatum = IIf(readerMotor("begin_datum") Is DBNull.Value, "", readerMotor("begin_datum"))
                        strVoertuieEindDatum = IIf(readerMotor("eind_datum") Is DBNull.Value, "", readerMotor("eind_datum"))
                        strVoertuieInruil = IIf(readerMotor("inruil") Is DBNull.Value, "", readerMotor("inruil"))
                        strVoertuieKoop = IIf(readerMotor("koop") Is DBNull.Value, "", readerMotor("koop"))
                        strVoertuieNuut = IIf(readerMotor("nuut") Is DBNull.Value, "", readerMotor("nuut"))
                    Else
                        strVoertuieCC = ""
                        strVoertuieCylinder = ""
                        strVoertuieBeginDatum = ""
                        strVoertuieEindDatum = ""
                        strVoertuieInruil = ""
                        strVoertuieKoop = ""
                        strVoertuieNuut = ""
                    End If
                Else
                    strDescriptionVehicle = "No Description"
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    '*Inputs - polisno, datumomteverifieer, vertoonmsg, maand
    '*Outputs - isbetaaljn, dblAmountDueVerifyDek, dblAmountPaidVerifyDek, blnPolisinEersteMaand
    '*Isbetaaljn - false if there is no cover
    Public Sub GetVerifieerDekking(strPolisno As String, dteDateToVerify As Date, intMonth As Integer)
        Dim dteDateToVerify2 As Date
        Dim dblPremie As Decimal = 0
        Dim dblVordPremie As Decimal = 0
        Dim intJaarEB As Integer
        Dim intMaandEB As Integer
        Dim dblKontantingekry As Decimal = 0

        'Die proses van verifikasie of 'n polis betaal is werk as volg:
        '1) Soek eisdatum maand in rekordset Maand.  As premie = vord_premie, gaan na punt 2).  As vord_premie = 0, gaan na punt 4)
        '2) Soek 'n VT vir eisdatum maand.  As vt gekry is, gaan na punt 3).
        '3) Kyk of 'n VT betaling gemaak is.  As dit is vergelyk vt_bedrag met vt_ingevorder.  As dit verskil msgbox.  as dit dieselfde is, dan het die polis dekking.
        '4) Kyk of daar MD betalings gedoen is vir hierdie polis.  As MD bedrag = polis bedrag OK.  As dit nie ins nie gaan na stap 5).
        '5) Rapporteer op MD verskil.

        'Bereken of die eis in die grasietydperk van 15 dae is (Bv. 'n eis op 10/11/2004 in in die grasieperiode van 01/11/2004 - 15/11/2004)
        Dim dteDag1 As Date
        Dim dteDag15 As Date
        strMsg2 = ""
        strMsg = ""

        dteDag1 = dteDateToVerify.AddDays(-(dteDateToVerify.Day - 1))
        dteDag15 = dteDateToVerify.AddDays(-(dteDateToVerify.Day - 15))
        If (DateDiff(DateInterval.Day, dteDateToVerify, dteDag1) <= 0) And (DateDiff(DateInterval.Day, dteDateToVerify, dteDag15) >= 0) Then
            strMsg2 = "You are in the grace period of 15 days."
        End If

        dblAmountDueVerifyDek = 0
        dblAmountPaidVerifyDek = 0

        blnPolisInEersteMaand = False

        Dim intJaar As Integer
        intJaar = Year(dteDateToVerify)
        'Linkie 31/10/2013intMonth = intMonth - 1
        intMonth = intMonth

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@Polisno", SqlDbType.NVarChar)
                param.Value = strPolisno

                Dim readerPersoonl As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlByPolisno", param)

                If readerPersoonl.Read Then
                    'As die eisdatum ingevul is, dan moet geverifieer word of die versekerde dekking het en of daar uitstaande VT is
                    If IsDBNull(dteDateToVerify) = False Then
                        'Geen verifieering vir JK nie
                        If readerPersoonl("bet_wyse") = "2" Then
                            Exit Sub
                        End If
                        Diagnostics.Debug.WriteLine("readerpersoonl" & strPolisno)
                        'n Termynpolis moet nie uitgeloop wees nie
                        'Toets vir die maand waarin die eis le.
                        'As die premie uitgeloop is, toets of die premie die vorige maand uitgeloop het.
                        'As die premie die vorige maand uitgeloop het, dan het hierdie persoon nie dekking nie.
                        'As die premie nie die vorige maand uitgeloop het nie, dan is hierdie polis of in die grasieperiode of nie.
                        If readerPersoonl("bet_wyse") = "6" Then
                            'Toets vir die maand waarin die eis le
                            GetTermynPolisUitgeloop(strPolisno, dteDateToVerify)

                            If strUitgeloopJN = "J" Then
                                'toets of die premie die vorige maand uitgeloop het
                                dteDateToVerify2 = DateAdd(DateInterval.Month, -1, dteDateToVerify)
                                GetTermynPolisUitgeloop(strPolisno, dteDateToVerify2)

                                'Geen dekking nie, polis word geblok
                                If strUitgeloopJN = "J" Then
                                    'Te min dekking.  Vra password.  Geen password dan word eis geblok
                                Else
                                    'is hierdie eisdatum in die grasieperiode?
                                    If (DateDiff(DateInterval.Day, dteDateToVerify, dteDag1) <= 0) And (DateDiff(DateInterval.Day, dteDateToVerify, dteDag15) >= 0) Then
                                        strMsg2 = "You are in the grace period of 15 days."
                                        strMsg = "The premium for this month hasn't been paid in full." & strMsg2
                                        MsgBox(strMsg, vbInformation)
                                    Else
                                        'Te min dekking.  Vra password.  Geen password dan word eis geblok

                                    End If
                                End If
                            End If
                            Exit Sub
                        End If

                        'kry maandeinde premie
                        Try
                            Using connMaand As SqlConnection = SqlHelper.GetConnection
                                Dim paramMaand() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                               New SqlParameter("@Maand", SqlDbType.Int), _
                                                               New SqlParameter("@JAAR", SqlDbType.Int)}

                                paramMaand(0).Value = strPolisno
                                paramMaand(1).Value = intMonth
                                paramMaand(2).Value = intJaar

                                Dim readerMaand As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchMaandDebities", paramMaand)
                                Diagnostics.Debug.WriteLine("readermaand" & strPolisno)
                                If readerMaand.Read Then
                                    dblPremie = readerMaand("premie")
                                    dblVordPremie = readerMaand("vord_Premie")
                                End If

                                dblAmountDueVerifyDek = dblPremie

                                'Bereken of die eis in die grasietydperk van 15 dae is(bv.'n eis op 10/11/2004 is in die grasietydperk van 01/11/2004 - 15/11/2004)
                                'as premie en vordpremie 0 is geen maandelikse afsluiting transaksie gekry nie
                                If dblPremie = 0 And dblVordPremie = 0 Then
                                    If DateDiff(DateInterval.Day, readerPersoonl("P_a_dat"), dteDateToVerify) <= 31 Then
                                        'vir 'n nuwe polis is die pro-rata en die volgende maand se betalings as twee aparte kwitansies ingelees.
                                        intJaarEB = Year(dteDateToVerify)
                                        intMaandEB = Month(dteDateToVerify)

                                        dblKontantingekry = 0

                                        'Is daar eerste betalings gemaak?
                                        Try
                                            Using connKontant1 As SqlConnection = SqlHelper.GetConnection
                                                Dim paramKontant1() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                                               New SqlParameter("@Maand", SqlDbType.Int), _
                                                                               New SqlParameter("@JAAR", SqlDbType.Int)}

                                                paramKontant1(0).Value = strPolisno
                                                paramKontant1(1).Value = intMonth
                                                paramKontant1(2).Value = intJaar

                                                Dim readerKontant1 As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchKontantPolisnoJaarMaand", paramKontant1)
                                                Diagnostics.Debug.WriteLine("readerkontant1" & strPolisno)
                                                Do While readerKontant1.Read
                                                    If readerKontant1("tipe") = "EB" Then
                                                        dblKontantingekry = dblKontantingekry + readerKontant1("vord_premie")
                                                    End If
                                                Loop

                                                If connKontant1.State = ConnectionState.Open Then
                                                    connKontant1.Close()
                                                End If
                                            End Using
                                        Catch ex As Exception
                                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                                        End Try

                                        dblAmountPaidVerifyDek = dblKontantingekry

                                        If blnVertoonMsg = True Then
                                            If dblKontantingekry > 0 Then
                                                MsgBox("This is a policy in its first month.  There are payments received to the value of R" & dblKontantingekry, vbInformation)
                                            Else
                                                MsgBox("This is a policy in its first month.  There are no payments received for this policy.", vbInformation)
                                            End If
                                        End If
                                        blnPolisInEersteMaand = True
                                        Exit Sub
                                    Else
                                        dblKontantingekry = 0

                                        'is daar vooruitbetalings?
                                        Try
                                            Using connKontant1 As SqlConnection = SqlHelper.GetConnection
                                                Dim paramKontant1() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                                               New SqlParameter("@Maand", SqlDbType.Int), _
                                                                               New SqlParameter("@JAAR", SqlDbType.Int)}

                                                paramKontant1(0).Value = strPolisno
                                                paramKontant1(1).Value = intMonth
                                                paramKontant1(2).Value = intJaar

                                                Dim readerKontant1 As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchKontantPolisnoJaarMaand", paramKontant1)
                                                Diagnostics.Debug.WriteLine("readerkontant1vb" & strPolisno)
                                                Do While readerKontant1.Read
                                                    If readerKontant1("tipe") = "VB" Then
                                                        dblKontantingekry = dblKontantingekry + readerKontant1("vord_premie")
                                                    End If
                                                Loop

                                                If connKontant1.State = ConnectionState.Open Then
                                                    connKontant1.Close()
                                                End If
                                            End Using
                                        Catch ex As Exception
                                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                                        End Try

                                        If dblKontantingekry > 0 Then
                                            blnIsBetaalJN = True
                                            Exit Sub
                                        Else
                                            If blnVertoonMsg = True Then
                                                If strMsg2 = "" Then
                                                    'registreereispassword.show vbmodal
                                                Else
                                                    GetVertoonMsg(blnVertoonMsg, strMsg2, strMsg, "The premium for this month hasn't been paid in full.")
                                                End If

                                            End If
                                        End If
                                    End If
                                    blnIsBetaalJN = False
                                    Exit Sub
                                End If

                                'is vord_premie = 0? dan kan daar moontlik MD/MK/ME/MS betalings wees
                                'daar kan ook VB en EB wees
                                If dblVordPremie = 0 Or dblVordPremie < dblPremie Then
                                    dblAmountPaidVerifyDek = dblVordPremie

                                    Try
                                        Using connKontant1 As SqlConnection = SqlHelper.GetConnection
                                            Dim paramKontant1() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                                           New SqlParameter("@Maand", SqlDbType.Int), _
                                                                           New SqlParameter("@JAAR", SqlDbType.Int)}

                                            paramKontant1(0).Value = strPolisno
                                            paramKontant1(1).Value = intMonth
                                            paramKontant1(2).Value = intJaar

                                            Dim readerKontant1 As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchKontantPolisnoJaarMaand", paramKontant1)
                                            Diagnostics.Debug.WriteLine("readerkontant1res" & strPolisno)
                                            If readerKontant1.Read Then
                                                dblKontantingekry = 0

                                                Do While readerKontant1.Read
                                                    If readerKontant1("tipe") = "MD" Or readerKontant1("tipe") = "MK" Or readerKontant1("tipe") = "MS" Or readerKontant1("tipe") = "ME" Or readerKontant1("tipe") = "VB" Or readerKontant1("tipe") = "EB" Then
                                                        dblKontantingekry = dblKontantingekry + readerKontant1("vord_premie")
                                                    End If
                                                Loop

                                                dblKontantingekry = dblKontantingekry + dblVordPremie
                                                dblAmountPaidVerifyDek = dblKontantingekry

                                                If dblKontantingekry < dblPremie Then
                                                    blnIsBetaalJN = False
                                                    If blnVertoonMsg = True Then
                                                        If strMsg2 = "" Then
                                                            'registreereispassword.show vbmodal
                                                        Else
                                                            GetVertoonMsg(blnVertoonMsg, strMsg2, strMsg, "The premium for this month hasn't been paid in full.")
                                                        End If
                                                    End If

                                                    Exit Sub
                                                Else
                                                    blnIsBetaalJN = True
                                                    Exit Sub
                                                End If
                                            Else
                                                blnIsBetaalJN = False
                                                If blnVertoonMsg = True Then
                                                    If strMsg2 = "" Then
                                                        'registreereispassword.show vbmodal
                                                    Else
                                                        GetVertoonMsg(blnVertoonMsg, strMsg2, strMsg, "The premium for this month hasn't been paid in full.")
                                                    End If
                                                End If
                                                Exit Sub
                                            End If

                                            If connKontant1.State = ConnectionState.Open Then
                                                connKontant1.Close()
                                            End If
                                        End Using
                                    Catch ex As Exception
                                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                                    End Try
                                Else
                                    If dblVordPremie > dblPremie Then
                                        blnIsBetaalJN = True
                                        Exit Sub
                                    End If
                                End If

                                'is premie = vord_premie?  Dan kan daar moontlik nog vt's wees
                                'daar kan ook vt betalings sowel as md betalings wees (vir bv. polisse wat nie korrekte rekening nrs in het nie.)
                                If dblPremie = dblVordPremie Then
                                    'is daar vooruitbetalings?
                                    Try
                                        Using connVTDetails As SqlConnection = SqlHelper.GetConnection
                                            Dim paramVTDetails() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                                           New SqlParameter("@Maand", SqlDbType.Int), _
                                                                           New SqlParameter("@JAAR", SqlDbType.Int)}

                                            paramVTDetails(0).Value = strPolisno
                                            paramVTDetails(1).Value = intMonth
                                            paramVTDetails(2).Value = intJaar

                                            Dim readerVTDetails As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchVTDetailsPolisnoJaarMaand", paramVTDetails)
                                            Diagnostics.Debug.WriteLine("readervtdetails" & strPolisno)
                                            If readerVTDetails.Read Then
                                                'n vt is gekry, kyk nou of dit ten volle betaal is
                                                If readerVTDetails("vt_ingevorder") >= readerVTDetails("vt_bedrag") Then
                                                    dblAmountPaidVerifyDek = readerVTDetails("vt_ingevorder")
                                                    blnIsBetaalJN = True
                                                    GetVertoonMsg(blnVertoonMsg, strMsg2, strMsg, "The premium for this month hasn't been paid in full.")
                                                    Exit Sub
                                                Else
                                                    'soek MD/MK/MS/ME/VB/EB betalings
                                                    dblKontantingekry = 0

                                                    Try
                                                        Using connKontant1 As SqlConnection = SqlHelper.GetConnection
                                                            Dim paramKontant1() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                                                           New SqlParameter("@Maand", SqlDbType.Int), _
                                                                                           New SqlParameter("@JAAR", SqlDbType.Int)}

                                                            paramKontant1(0).Value = strPolisno
                                                            paramKontant1(1).Value = intMonth
                                                            paramKontant1(2).Value = intJaar

                                                            Dim readerKontant1 As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchKontantPolisnoJaarMaand", paramKontant1)
                                                            Diagnostics.Debug.WriteLine("readerkontant1als2" & strPolisno)
                                                            If readerKontant1.Read Then
                                                                Do While readerKontant1.Read
                                                                    If readerKontant1("tipe") = "MD" Or readerKontant1("tipe") = "MK" Or readerKontant1("tipe") = "MS" Or readerKontant1("tipe") = "ME" Or readerKontant1("tipe") = "VB" Or readerKontant1("tipe") = "EB" Then
                                                                        dblKontantingekry = dblKontantingekry + readerKontant1("vord_premie")
                                                                    End If
                                                                Loop

                                                                dblKontantingekry = dblKontantingekry + readerVTDetails("vt_ingevorder")
                                                                dblAmountPaidVerifyDek = dblKontantingekry

                                                                If dblKontantingekry >= dblPremie Then
                                                                    blnIsBetaalJN = True
                                                                    Exit Sub
                                                                Else
                                                                    blnIsBetaalJN = False
                                                                    GetVertoonMsg(blnVertoonMsg, strMsg2, strMsg, "The premium for this month hasn't been paid in full.")
                                                                    Exit Sub
                                                                End If
                                                            Else
                                                                blnIsBetaalJN = False
                                                                GetVertoonMsg(blnVertoonMsg, strMsg2, strMsg, "The premium for this month hasn't been paid in full.")
                                                                Exit Sub
                                                            End If

                                                            If connKontant1.State = ConnectionState.Open Then
                                                                connKontant1.Close()
                                                            End If
                                                        End Using
                                                    Catch ex As Exception
                                                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                                                    End Try
                                                End If
                                            Else
                                                dblAmountPaidVerifyDek = dblVordPremie
                                                blnIsBetaalJN = True
                                                Exit Sub
                                                'Geen vt's is gekry nie, polis is op datum
                                            End If
                                            If connVTDetails.State = ConnectionState.Open Then
                                                connVTDetails.Close()
                                            End If
                                        End Using
                                    Catch ex As Exception
                                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                                    End Try
                                ElseIf dblVordPremie < dblPremie Then
                                    dblAmountPaidVerifyDek = dblVordPremie
                                    blnIsBetaalJN = False
                                    GetVertoonMsg(blnVertoonMsg, strMsg2, strMsg, "The premium for this month hasn't been paid in full.")
                                    Exit Sub
                                End If
                                If connMaand.State = ConnectionState.Open Then
                                    connMaand.Close()
                                End If
                            End Using
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                        End Try
                    End If
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Public Sub GetTermynPolisUitgeloop(strPolisno As String, dteDateToVerify As Date)
        'Lys waar termynpolisse se unearned kleiner as nul is
        BerekenLangtermynPolisFondse(strPolisno, dteDateToVerify)
    End Sub
    Public Sub BerekenLangtermynPolisFondse(strPolisno As String, dteDateToVerify As Date)
        Dim dblUnearned As Decimal = 0
        Dim dteReportDate As Date = Today
        Dim dblVorigeTydperkUnearned As Decimal = 0
        Dim intTermynMaand As Integer
        Dim intTermynJaar As Integer
        Dim dblGeldOntvang As Decimal = 0
        Dim dblVARTerugbetaling As Decimal = 0
        Dim intTelGeldOntvang As Integer = 0
        Dim strBeskrywingLTP As String
        Dim dblVorigeMaandEarned As Decimal = 0
        Dim dblEarned As Decimal = 0
        Dim i As Integer

        strUitgeloopJN = "N"
        strOor2MaandeUitgeloopJN = "N"

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@Polisno", SqlDbType.NVarChar)
                param.Value = strPolisno

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FectchLangtermynPolis", param)
                Diagnostics.Debug.WriteLine("ltpreader")
                If reader.Read Then
                    Try
                        Using connect As SqlConnection = SqlHelper.GetConnection
                            Dim param1 As New SqlParameter("@Polisno", SqlDbType.NVarChar)
                            param1.Value = strPolisno

                            Dim reader1 As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlByPolisno", param1)
                            Diagnostics.Debug.WriteLine("ltpreader1")
                            If reader1.Read Then
                                Do While reader.Read
                                    'Stel detail op
                                    For i = 1 To reader("tydperk")
                                        'Berekene termyn maand en jaar
                                        If i = 1 Then
                                            intTermynMaand = Month(reader("datumbegin"))
                                            intTermynJaar = Year(reader("datumbegin"))
                                        Else
                                            intTermynMaand = intTermynMaand + 1
                                            If intTermynMaand > 12 Then
                                                intTermynJaar = intTermynJaar + 1
                                                intTermynMaand = 1
                                            End If
                                        End If

                                        'Bereken Geld ontvang vir hierdie maand en jaar
                                        Try
                                            Using connKontant As SqlConnection = SqlHelper.GetConnection
                                                Dim paramKontant As New SqlParameter("@fkLangtermynpolis", SqlDbType.Int)
                                                paramKontant.Value = reader("pklangtermynpolis")

                                                Dim readerKontant As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FectchKontantfkLangtermynPolis", paramKontant)
                                                Diagnostics.Debug.WriteLine("readerkontantltp")
                                                Do While readerKontant.Read
                                                    If readerKontant("jaar") = intTermynJaar And readerKontant("maand") = intTermynMaand Then
                                                        If readerKontant("gekans") = False Then
                                                            If readerKontant("tipe") = "TB" Then
                                                                dblVARTerugbetaling = dblVARTerugbetaling + readerKontant("vord_premie")
                                                            Else
                                                                dblGeldOntvang = dblGeldOntvang + readerKontant("vord_premie")
                                                                intTelGeldOntvang = intTelGeldOntvang + 1
                                                            End If
                                                        End If
                                                    End If
                                                Loop

                                                If connKontant.State = ConnectionState.Open Then
                                                    connKontant.Close()
                                                End If
                                            End Using
                                        Catch ex As Exception
                                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                                        End Try

                                        dblGeldOntvang = dblGeldOntvang - dblVARTerugbetaling

                                        'Beskrywing
                                        If i = 1 Then
                                            strBeskrywingLTP = "Hernuwingspremie"
                                        Else
                                            strBeskrywingLTP = " "
                                        End If

                                        'Earned
                                        'Kyk of daar 'n stats5d rekord bestaan vir termyn maand?
                                        dblVorigeMaandEarned = dblEarned
                                        dblEarned = 0

                                        'Kyk of vandag se maand ooreenstem met langtermynpolis begindatum
                                        If Month(Today) >= intTermynMaand Then
                                            'kry die vorige afsluitdatum van die ltp
                                            Dim dteSoekdatum As Date
                                            dteSoekdatum = reader("datumbegin")
                                            dteSoekdatum = dteSoekdatum.AddMonths(-1)
                                            Try
                                                Using connAfsluitdatums As SqlConnection = SqlHelper.GetConnection
                                                    Dim paramAfsluitdatums() As SqlParameter = {New SqlParameter("@Kategorie", SqlDbType.NVarChar), _
                                                                                                New SqlParameter("@Maand", SqlDbType.Int), _
                                                                                                New SqlParameter("@Jaar", SqlDbType.Int)}

                                                    paramAfsluitdatums(0).Value = "Algemeen"
                                                    paramAfsluitdatums(1).Value = Month(dteSoekdatum)
                                                    paramAfsluitdatums(2).Value = Year(dteSoekdatum)

                                                    Dim readerAfsluitdatums As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5d].[FetchAfsluitdatumJaarMaand]", paramAfsluitdatums)
                                                    Diagnostics.Debug.WriteLine("readerafsluitdatums" & strPolisno)
                                                    If readerAfsluitdatums.Read Then
                                                        dteSoekdatum = readerAfsluitdatums("afsluitdatum")
                                                    End If
                                                    If connAfsluitdatums.State = ConnectionState.Open Then
                                                        connAfsluitdatums.Close()
                                                    End If
                                                End Using
                                            Catch ex As Exception
                                                MsgBox(ex.Message, MsgBoxStyle.Critical)
                                            End Try

                                            Dim strSoekdatum As String

                                            strSoekdatum = System.String.Format("{0:dd}/{0:MM}/{0:yyyy}", dteSoekdatum)
                                            Try
                                                Using connMDPrint2Dat As SqlConnection = SqlHelper.GetConnection
                                                    Dim paramMDPrint2Dat() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                                                                New SqlParameter("@Afsluit_dat", SqlDbType.Date)}
                                                    paramMDPrint2Dat(0).Value = strPolisno
                                                    paramMDPrint2Dat(1).Value = strSoekdatum

                                                    Dim readerMDPrint2Dat As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchReportMd_PRINT2_DAT]", paramMDPrint2Dat)
                                                    Diagnostics.Debug.WriteLine(strPolisno & "readermdprint2daltpt" & strSoekdatum)
                                                    If readerMDPrint2Dat.Read Then
                                                        dblEarned = readerMDPrint2Dat("premie2")
                                                    End If
                                                    If connMDPrint2Dat.State = ConnectionState.Open Then
                                                        connMDPrint2Dat.Close()
                                                    End If
                                                End Using
                                            Catch ex As Exception
                                                MsgBox(ex.Message, MsgBoxStyle.Critical)
                                            End Try

                                        End If

                                        'Unearned
                                        If i = 1 Then
                                            dblUnearned = dblGeldOntvang + dblUnearned
                                        Else
                                            dblUnearned = dblUnearned + dblGeldOntvang - dblVorigeMaandEarned
                                        End If

                                        'Maande oor
                                        Dim intMaandeOor As Integer
                                        If i = 1 Then
                                            intMaandeOor = reader("tydperk")
                                        Else
                                            intMaandeOor = reader("tydperk") - i + 1
                                        End If

                                        'Is Hierdie polis uitgeloop?
                                        Dim dteVanafTermynMaand As Date
                                        Dim dteTotTermynMaand As Date
                                        dteVanafTermynMaand = "01" & "/" & Format(intTermynMaand, "00") & "/" & Format(intTermynJaar, "0000")
                                        dteTotTermynMaand = DateAdd(DateInterval.Month, 1, dteVanafTermynMaand)
                                        dteTotTermynMaand = DateAdd(DateInterval.Day, -1, dteTotTermynMaand)

                                        If (DateDiff(DateInterval.Day, dteDateToVerify, dteVanafTermynMaand) <= 0) And (DateDiff(DateInterval.Day, dteDateToVerify, dteTotTermynMaand) >= 0) Then
                                            If dblUnearned - dblEarned <= 0 Then
                                                strUitgeloopJN = "J"
                                            End If
                                        End If

                                        'is hierdie polis oor 2 maande uitgeloop?
                                        'is vandag in hierdie polis se 2 maande voor eind maand?
                                        Dim dteVanafEindMaand As Date
                                        Dim dteTotEindMaand As Date
                                        Dim dteVanaf2VooreindMaand As Date
                                        Dim dteTot2VooreindMaand As Date

                                        dteVanafEindMaand = "01" & "/" & Format(Month(reader("datumeindig")), "00") & "/" & Format(Year(reader("datumeindig")), "0000")
                                        dteTotEindMaand = reader("Datumeindig")

                                        If i = reader("tydperk") Then
                                            dteVanaf2VooreindMaand = DateAdd(DateInterval.Month, -2, dteVanafEindMaand)
                                            dteTot2VooreindMaand = DateAdd(DateInterval.Month, -2, dteTotEindMaand)
                                            If (DateDiff(DateInterval.Day, Today, dteVanaf2VooreindMaand) <= 0) And (DateDiff(DateInterval.Day, Today, dteTot2VooreindMaand) >= 0) Then
                                                If dblUnearned - dblEarned < 0 Then
                                                    strOor2MaandeUitgeloopJN = "J"
                                                End If
                                            End If
                                        End If
                                    Next
                                Loop
                            End If
                            If connect.State = ConnectionState.Open Then
                                connect.Close()
                            End If
                        End Using
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub GetVertoonMsg(blnVertoonMsg As Boolean, strMsg2 As String, strMsg As String, strMessage As String)
        If blnVertoonMsg = True Then
            If strMsg2 = "" Then
                'te min dekking.  vra password.  Geen password dan word eis geblok
            Else
                MsgBox(strMessage & " " & strMsg2, vbInformation)
            End If
        End If
    End Sub
    'Return the staus for a termpolicy (Return: dateStart, DateEnd, Months, TermDesc, StatusDesc, Status)
    'Status: 1 - Active term, 2 - Term not active yet, 3 - Expired, 4 - Old annual cash policy (no term exists)
    Public Function gen_GetTermPolicyStatus(ByVal Betwyse As String, ByVal polisno As String, ByVal dateStart As Date, ByVal DateEnd As Date, ByVal Months As Byte, ByVal TermDesc As String, ByVal StatusDesc As String, ByVal Status As Byte)
        'Check if this is a longterm policy
        If Trim(Betwyse) = "6" Then
            Try
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim params() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar)}

                    params(0).Value = polisno

                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchLangtermynPolisPolisno", params)

                    'No term exists for this policy (default to 12 months existing annual cash policies)
                    Months = 12
                    Status = 4
                    'loop through records, set variables, exit as soon as current preiod found, exit on first historical period
                    Do While reader.Read
                        If Now() >= reader("datumbegin") And Now() <= reader("datumeindig") Then        'current term in action
                            dateStart = reader("datumbegin")
                            DateEnd = reader("datumeindig")
                            Months = reader("tydperk")
                            Status = 1
                            Exit Do
                        ElseIf Now() < reader("datumbegin") Then                                    'term not active yet
                            dateStart = reader("datumbegin")
                            DateEnd = reader("datumeindig")
                            Months = reader("tydperk")
                            Status = 2
                            Exit Do
                        ElseIf Now() > reader("datumeindig") Then                               'term expired
                            dateStart = reader("datumbegin")
                            DateEnd = reader("datumeindig")
                            Months = reader("tydperk")
                            Status = 3
                            Exit Do
                        End If
                    Loop
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Return Nothing
                Exit Function
            End Try
        Else
            'Not a longterm policy - status not applicable
            Months = 1
            Status = 5
        End If

        'set descriptions according to status
        Select Case Status
            Case 1
                TermDesc = dateStart & " - " & DateEnd
                StatusDesc = "Active"
            Case 2
                TermDesc = dateStart & " - " & DateEnd
                StatusDesc = "Inactive"
            Case 3
                TermDesc = dateStart & " - " & DateEnd
                StatusDesc = "Expired"
            Case 4
                TermDesc = "Unknown"
                StatusDesc = "Waiting on renewal"
            Case 5
                TermDesc = "n.a."
                StatusDesc = ""
        End Select

        dteTermDateEnd = DateEnd
        Return dateStart
        Return DateEnd
        Return Months
        Return TermDesc
        Return StatusDesc
        Return Status
    End Function
    Public Function gen_getAdminPath() As String
        Dim pos1 As String
        'Get stats archive path for server form pol_path (poldata.ini)
        pos1 = InStr(1, LCase(Constants.Path), "polis5") - 1
        gen_getAdminPath = Mid(Constants.Path, 1, pos1) & "Polis5Admin\"
    End Function
    Public Function gen_getServerPath() As String
        Dim pos1 As String
        'Get stats archive path for server form pol_path (poldata.ini)
        pos1 = InStr(1, LCase(Constants.Path), "polis5") - 1
        gen_getServerPath = Mid(Constants.Path, 1, pos1)
    End Function
    Public Sub BackupMooirivierDatabase(strPath As String)
        Dim dbBackup As Integer
        dbBackup = Shell("""C:\Program Files\Microsoft SQL Server\110\Tools\Binn\osql.exe"" -E -Q ""BACKUP DATABASE Mooirivier TO DISK='" & strPath & "' WITH FORMAT""", AppWinStyle.Hide, True)

    End Sub
    Public Sub GetSekuritDetail(ByVal strPassword As String)
        strSekuritTitel = ""
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@kode", SqlDbType.NVarChar)

                param.Value = strPassword
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "sekurit.FetchGebruikersKode", param)

                If reader.Read() Then
                    strSekuritTitel = reader("titel")
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    reader.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            End
        End Try
    End Sub
End Class
