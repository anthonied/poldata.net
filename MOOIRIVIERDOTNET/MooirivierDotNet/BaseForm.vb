Imports System.Data.SqlClient
Imports DAL
Imports System
Imports System.IO



Public Class BaseForm
    Inherits System.Windows.Forms.Form

    Protected Const PARM_UserName As String = "@UserName"
    Protected Const PARM_POLISNO As String = "@POLISNO"
    Protected Const PARM_Languange As String = "@Languange"
    Protected Const PARM_VERSEKERDE As String = "@VERSEKERDE"
    Protected Const PARM_BranchCodes As String = "@BranchCodes"
    Public Const glbPakketItem1BeskAfr As String = "Operarum arbeidsversekering"
    ' Andriette verander die Engels 28/02/2013
    'Public Const glbPakketItem1BeskEng As String = "Operarum labour insurance"
    Public Const strglbPakketItem1BeskEng As String = "Labour insurance"
    Public Const strglbPakketItem2BeskAfr As String = "Makelaarsfooi"
    Public Const strglbPakketItem2BeskEng As String = "Broker fees"
    Public Const strglbPakketItem3BeskAfr As String = ""
    Public Const strglbPakketItem3BeskEng As String = ""
    Public Const strglbPakketItem4BeskAfr As String = ""
    Public Const strglbPakketItem4BeskEng As String = ""
    Public blnPol_Byvoeg As Boolean
    Public BESKRYWING As String
    Public blnNuwe As Boolean

    ' Andriette verander na boolean
    'Public Loading As Integer
    'Public Clear_s As Integer
    'Andriette 16/04/2014 moenie waarde toeken nie 
    Public blnLoading As Boolean '= True
    Public blnClear_s As Boolean '= True
    Public strGebtitel As String
    Public dblHuise_Sub As Double
    Public dblalle_sub As Double
    Public dblMotor_sub As Double
    Public dblsubtotaal As Double
    Public dblhuis_sub As Double
    Public dblmedies_sub As Double
    Public dblsubtot As Double
    Public dblsasria_ As Double
    Public dblPTotaal As Double
    Public blnSavedNew As Boolean = True 'aNDRIETTE 15/04/2014'= False 'Andriette 17/03/2014 skuif hierheen sodat hier ook sigbaar is

    Public Function ListBYBET_K() As List(Of String)
        Dim list As List(Of String) = New List(Of String)
        If Persoonl.TAAL = "0" Then
            list.Add("Gewone")
            list.Add("Bejaarde")
            list.Add("R 1000.00")
            list.Add("Afkoop")
            list.Add("Opsioneel")
            list.Add("Alternatief")
        Else
            list.Add("Plain")
            list.Add("Pensioner")
            list.Add("R 1000.00")
            list.Add("Buy Off")
            list.Add("Optional")
            list.Add("Alternative")
        End If
        Return list
    End Function
    Public Function gen_getMonthName(ByRef language As Byte, ByRef monthNumber As Byte) As String
        gen_getMonthName = ""
        If language = 0 Then
            Select Case monthNumber
                Case 1
                    gen_getMonthName = "Januarie"
                Case 2
                    gen_getMonthName = "Februarie"
                Case 3
                    gen_getMonthName = "Maart"
                Case 4
                    gen_getMonthName = "April"
                Case 5
                    gen_getMonthName = "Mei"
                Case 6
                    gen_getMonthName = "Junie"
                Case 7
                    gen_getMonthName = "Julie"
                Case 8
                    gen_getMonthName = "Augustus"
                Case 9
                    gen_getMonthName = "September"
                Case 10
                    gen_getMonthName = "Oktober"
                Case 11
                    gen_getMonthName = "November"
                Case 12
                    gen_getMonthName = "Desember"
            End Select
        Else
            gen_getMonthName = Format("01-" & monthNumber & "-2004", "MMMM")
        End If
    End Function
    'Andriette stuur die taal eerder as 'n parameter
    Public Function ListPOSBESTEMMING(nTaal As Integer) As List(Of String)
        'POSBESTEMMING
        Dim list As List(Of String) = New List(Of String)
        If nTaal = 0 Then
            list.Add("Posadres")
            list.Add("Risiko adres")
            list.Add("Universiteitsposbus")
            list.Add("Elektroniese pos")
        Else
            list.Add("Postal address")
            list.Add("Risk address")
            list.Add("University Box")
            list.Add("Email")
        End If

        Return list
    End Function
    'Andriette 03/05/2013 verander na die combobox standaard met die combobox entity

    Public Function ListTitle(ByVal langauage As Integer) As List(Of TitleEntity)
        Dim list As List(Of TitleEntity) = New List(Of TitleEntity)

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@Languange", SqlDbType.Int)
                If Form1.cmbForm1Taal.Text = "" Then
                    param.Value = langauage
                Else
                    param.Value = Persoonl.TAAL
                End If
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[ListTitle]", param)


                While reader.Read()
                    Dim item As TitleEntity = New TitleEntity()

                    item.ID = reader("ID")
                    item.Title = reader("Title")

                    list.Add(item)
                End While
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox("There's error trying to connect to the database.", MsgBoxStyle.Exclamation)
        End Try
        Return list
    End Function

    Public Function FetchLangtermnDate(ByRef Nommer As String) As LangtermynPolis
        Dim item As LangtermynPolis = New LangtermynPolis
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@Polisno", SqlDbType.NVarChar)
                param.Value = Nommer
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.GetLangtermynpolisDate", param)

                If reader.Read() Then

                    If reader("Polisno") IsNot DBNull.Value Then
                        item.Polisno = reader("Polisno")
                    End If
                    If reader("DatumBegin") IsNot DBNull.Value Then
                        item.DatumBegin = reader("DatumBegin")
                    End If
                    If reader("DatumEindig") IsNot DBNull.Value Then
                        item.DatumEindig = reader("DatumEindig")
                    End If
                    If reader("Tydperk") IsNot DBNull.Value Then
                        item.Tydperk = reader("Tydperk")
                    End If

                    item.NoMatch = False
                Else
                    item.NoMatch = True
                End If
                Return item
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function

    Public Function FetchMemoList(ByRef polisno As String) As List(Of MemoEntity)
        Dim list As List(Of MemoEntity) = New List(Of MemoEntity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                'Andriette 15/08/2013 gebruik die polisnommer wat in elke geval gestuur word
                'param.Value = Persoonl.POLISNO
                param.Value = polisno

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchMemo", param)
                While reader.Read()
                    Dim item As MemoEntity = New MemoEntity()
                    item.pkMemo = reader("pkMemo")
                    If reader("Polisno") IsNot DBNull.Value Then
                        item.POLISNO = reader("Polisno")
                    End If
                    If reader("Gebruiker") IsNot DBNull.Value Then
                        item.Gebruiker = reader("Gebruiker")
                    End If
                    If reader("DatumToegevoer") IsNot DBNull.Value Then
                        '   item.DatumToegevoer = reader("DatumToegevoer")
                        ' Andriette 02/05/2013 Verander na 'n datum
                        item.DatumToegevoer = System.String.Format("{0:dd}/{0:MM}/{0:yyyy}", reader("DatumToegevoer"))
                    End If
                    If reader("Kategorie") IsNot DBNull.Value Then
                        item.Kategorie = reader("Kategorie")
                    End If
                    If reader("Beskrywing") IsNot DBNull.Value Then
                        item.Beskrywing = reader("Beskrywing").ToString.ToLower
                    End If
                    If reader("Deleted") IsNot DBNull.Value Then
                        item.Deleted = reader("Deleted")
                    End If
                    If reader("DatumVerander") IsNot DBNull.Value Then
                        item.DatumVerander = reader("DatumVerander")
                        item.DatumJaarEerste = System.String.Format("{0:yyyy}/{0:MM}/{0:dd}  {0:H:mm:ss}", reader("DatumVerander"))
                    End If

                    list.Add(item)

                End While
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return list
    End Function
    Public Function FetchPropertyType()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPropertyType")
                Dim item As PropertyTypeEntity = New PropertyTypeEntity()
                While reader.Read

                    If reader("pkPropertyType") IsNot DBNull.Value Then
                        item.pkPropertyType = reader("pkPropertyType")
                    End If
                    If reader("ShortDescAfr") IsNot DBNull.Value Then
                        item.ShortDescAfr = reader("ShortDescAfr")
                    End If
                    If reader("ShortDescEng") IsNot DBNull.Value Then
                        item.ShortDescEng = reader("ShortDescEng")
                    End If
                    If reader("Description") IsNot DBNull.Value Then
                        item.Description = reader("Description")
                    End If

                End While
                Return item
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function
    Public Function FetchMd_Print_Dat()
        Dim list As List(Of md_Print_Dat) = New List(Of md_Print_Dat)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@Polisno", SqlDbType.NVarChar)

                param.Value = Persoonl.POLISNO


                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchReportMd_Print_dat", param)
                Dim item As md_Print_Dat = New md_Print_Dat()
                If reader.Read Then

                    If reader("ADRES2") IsNot DBNull.Value Then
                        item.ADRES2 = reader("ADRES2")
                    End If
                    If reader("adres3") IsNot DBNull.Value Then
                        item.adres3 = reader("adres3")
                    End If
                    If reader("Afsluit_dat") IsNot DBNull.Value Then
                        item.Afsluit_dat = reader("Afsluit_dat")
                    End If
                    If reader("afsluitdatum") IsNot DBNull.Value Then
                        item.afsluitdatum = reader("afsluitdatum")

                        If reader("akketItem3") IsNot DBNull.Value Then
                            item.akketItem3 = reader("akketItem3")
                        End If
                        If reader("AREA") IsNot DBNull.Value Then
                            item.AREA = reader("AREA")
                        End If
                        If reader("BEGRAFNIS") IsNot DBNull.Value Then
                            item.BEGRAFNIS = reader("BEGRAFNIS")
                        End If
                        If reader("bemarker") IsNot DBNull.Value Then
                            item.bemarker = reader("bemarker")
                        End If
                        If reader("BESK") IsNot DBNull.Value Then
                            item.BESK = reader("BESK")
                        End If
                        If reader("BESKERM") IsNot DBNull.Value Then
                            item.BESKERM = reader("BESKERM")
                        End If
                        If reader("BET_WYSE") IsNot DBNull.Value Then
                            item.BET_WYSE = reader("BET_WYSE")
                        End If
                        If reader("careassist") IsNot DBNull.Value Then
                            item.careassist = reader("careassist")
                        End If
                        If reader("EEU") IsNot DBNull.Value Then
                            item.EEU = reader("EEU")
                        End If
                        If reader("EISE") IsNot DBNull.Value Then
                            item.EISE = reader("EISE")
                        End If
                        If reader("eispers") IsNot DBNull.Value Then
                            item.eispers = reader("eispers")
                        End If
                        If reader("G_BONUS") IsNot DBNull.Value Then
                            item.G_BONUS = reader("G_BONUS")
                        End If
                        If reader("gebruik") IsNot DBNull.Value Then
                            item.gebruik = reader("gebruik")
                        End If
                        If reader("JAAR") IsNot DBNull.Value Then
                            item.JAAR = reader("JAAR")
                        End If
                        If reader("mmkode") IsNot DBNull.Value Then
                            item.mmkode = reader("mmkode")
                        End If
                        If reader("motorsek") IsNot DBNull.Value Then
                            item.motorsek = reader("motorsek")
                        End If
                        If reader("Motorsekuriteitbitvaluememo") IsNot DBNull.Value Then
                            item.Motorsekuriteitbitvaluememo = reader("Motorsekuriteitbitvaluememo")
                        End If
                        If reader("MPREMIE") IsNot DBNull.Value Then
                            item.MPREMIE = reader("MPREMIE")
                        End If
                        If reader("P_A_DAT2") IsNot DBNull.Value Then
                            item.P_A_DAT2 = reader("P_A_DAT2")
                        End If
                        If reader("pa_dat") IsNot DBNull.Value Then
                            item.pa_dat = reader("pa_dat")
                        End If
                        If reader("PakketItem1") IsNot DBNull.Value Then
                            item.PakketItem1 = reader("PakketItem1")
                        End If
                        If reader("PakketItem2") IsNot DBNull.Value Then
                            item.PakketItem2 = reader("PakketItem2")
                        End If
                        If reader("PakketItem3") IsNot DBNull.Value Then
                            item.PakketItem3 = reader("PakketItem3")
                        End If
                        If reader("PakketItem4") IsNot DBNull.Value Then
                            item.PakketItem4 = reader("PakketItem4")
                        End If
                        If reader("PLIP") IsNot DBNull.Value Then
                            item.PLIP = reader("PLIP")
                        End If
                        If reader("POLFOOI") IsNot DBNull.Value Then
                            item.POLFOOI = reader("POLFOOI")
                        End If
                        If reader("POLISNO") IsNot DBNull.Value Then
                            item.POLISNO = reader("POLISNO")
                        End If
                        If reader("PREMIE") IsNot DBNull.Value Then
                            item.PREMIE = reader("PREMIE")
                        End If
                        If reader("REG") IsNot DBNull.Value Then
                            item.REG = reader("REG")
                        End If
                        If reader("SASPREM") IsNot DBNull.Value Then
                            item.SASPREM = reader("SASPREM")
                        End If
                        If reader("SUBTOTAAL") IsNot DBNull.Value Then
                            item.SUBTOTAAL = reader("SUBTOTAAL")
                        End If
                        If reader("TIPE") IsNot DBNull.Value Then
                            item.TIPE = reader("TIPE")
                        End If
                        If reader("tipevoert") IsNot DBNull.Value Then
                            item.tipevoert = reader("tipevoert")
                        End If
                        If reader("TV_DIENS") IsNot DBNull.Value Then
                            item.TV_DIENS = reader("TV_DIENS")
                        End If
                        If reader("VERSEKERDE") IsNot DBNull.Value Then
                            item.VERSEKERDE = reader("VERSEKERDE")
                        End If
                        If reader("VOERTUIE") IsNot DBNull.Value Then
                            item.VOERTUIE = reader("VOERTUIE")
                        End If
                        If reader("VOORL") IsNot DBNull.Value Then
                            item.VOORL = reader("VOORL")
                        End If
                        If reader("WAARDE") IsNot DBNull.Value Then
                            item.WAARDE = reader("WAARDE")
                        End If
                    End If
                    item.Nomatch = False
                Else
                    item.Nomatch = True
                End If
                list.Add(item)
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return list
    End Function

    Public Sub FetchPrint2DatEntity()
        'Dim list As List(Of Print2DatEntity) = New List(Of Print2DatEntity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                               New SqlParameter("@Afsluit_dat", SqlDbType.NVarChar)}

                param(0).Value = Persoonl.POLISNO
                param(1).Value = "23/03/2001"

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchReportMd_PRINT2_DAT", param)
                Dim item As Print2DatEntity = New Print2DatEntity()
                If reader.Read Then

                    If reader("AddisionelePremie") IsNot DBNull.Value Then
                        item.AddisionelePremie = reader("AddisionelePremie")
                    End If
                    If reader("Afsluit_dat") IsNot DBNull.Value Then
                        item.Afsluit_dat = reader("Afsluit_dat")
                    End If

                    If reader("afsluitdatum") IsNot DBNull.Value Then
                        item.afsluitdatum = reader("afsluitdatum")
                    End If
                    If reader("alle_sub") IsNot DBNull.Value Then
                        item.alle_sub = reader("alle_sub")
                    End If
                    If reader("bet_wyse") IsNot DBNull.Value Then
                        item.bet_wyse = reader("bet_wyse")
                    End If
                    If reader("bybet_k") IsNot DBNull.Value Then
                        item.bybet_k = reader("bybet_k")
                    End If
                    If reader("courtesyv") IsNot DBNull.Value Then
                        item.courtesyv = reader("courtesyv")
                    End If
                    If reader("eem_premie") IsNot DBNull.Value Then
                        item.eem_premie = reader("eem_premie")
                    End If
                    If reader("eem_waarde") IsNot DBNull.Value Then
                        item.eem_waarde = reader("eem_waarde")
                    End If
                    If reader("eispers") IsNot DBNull.Value Then
                        item.eispers = reader("eispers")
                    End If
                    If reader("epc") IsNot DBNull.Value Then
                        item.epc = reader("epc")
                    End If
                    If reader("huis_sub") IsNot DBNull.Value Then
                        item.huis_sub = reader("huis_sub")
                    End If
                    If reader("Huispremie") IsNot DBNull.Value Then
                        item.Huispremie = reader("Huispremie")
                    End If
                    If reader("id_nom") IsNot DBNull.Value Then
                        item.id_nom = reader("id_nom")
                    End If
                    If reader("inscell") IsNot DBNull.Value Then
                        item.inscell = reader("inscell")
                    End If
                    If reader("motor_sub") IsNot DBNull.Value Then
                        item.motor_sub = reader("motor_sub")
                    End If
                    If reader("ongespesifiseerd") IsNot DBNull.Value Then
                        item.ongespesifiseerd = reader("ongespesifiseerd")
                    End If
                    If reader("ongevalle") IsNot DBNull.Value Then
                        item.ongevalle = reader("ongevalle")
                    End If
                    If reader("PersoonlAddisionelePremie") IsNot DBNull.Value Then
                        item.PersoonlAddisionelePremie = reader("PersoonlAddisionelePremie")
                    End If
                    If reader("Polisno") IsNot DBNull.Value Then
                        item.Polisno = reader("Polisno")
                    End If
                    If reader("Premie2") IsNot DBNull.Value Then
                        item.Premie2 = reader("Premie2")
                    End If
                    If reader("toe_premie") IsNot DBNull.Value Then
                        item.toe_premie = reader("toe_premie")
                    End If
                    If reader("toe_waarde") IsNot DBNull.Value Then
                        item.toe_waarde = reader("toe_waarde")
                    End If
                    If reader("Verwyskommissie") IsNot DBNull.Value Then
                        item.Verwyskommissie = reader("Verwyskommissie")
                    End If

                    item.Nomatch = False
                Else
                    item.Nomatch = True
                End If
                'list.Add(item)
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
        'Return list
    End Sub
    Public Function FetchPersoonlForVerwysdes(ByRef Nommer As String) As PERSOONLEntity
        Dim item As PERSOONLEntity = New PERSOONLEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@Verwyser", SqlDbType.NVarChar)
                param.Value = Persoonl.POLISNO
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchPersoonlForVerwysdes]", param)

                If reader.Read() Then
                    If reader("BET_WYSE") IsNot DBNull.Value Then
                        item.BET_WYSE = reader("BET_WYSE")
                    End If
                    If reader("Area") IsNot DBNull.Value Then
                        item.Area = reader("Area")
                    End If
                    item.NoMatch = False
                Else
                    item.NoMatch = True
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function
    ''[poldata5].[FetchPolicyNoForLoad]
    Public Function FetchPolicyNoForLoad() As PERSOONLEntity
        Dim item As PERSOONLEntity = New PERSOONLEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPolicyNoForLoad")

                If reader.Read() Then
                    If reader("ADRES") IsNot DBNull.Value Then
                        item.ADRES = reader("ADRES")
                    End If
                    If reader("ADRES1") IsNot DBNull.Value Then
                        item.ADRES1 = reader("ADRES1")
                    End If
                    If reader("ADRES2") IsNot DBNull.Value Then
                        item.ADRES2 = reader("ADRES2")
                    End If
                    If reader("adres3") IsNot DBNull.Value Then
                        item.adres3 = reader("adres3")
                    End If
                    If reader("Adres4") IsNot DBNull.Value Then
                        item.Adres4 = reader("Adres4")
                    End If
                    If reader("aftrekdat") IsNot DBNull.Value Then
                        item.aftrekdat = reader("aftrekdat")
                    End If
                    If reader("ALLE_SUB") IsNot DBNull.Value Then
                        item.ALLE_SUB = reader("ALLE_SUB")
                    End If
                    If reader("Area") IsNot DBNull.Value Then
                        item.Area = reader("Area")
                    End If
                    If reader("ASSESOR") IsNot DBNull.Value Then
                        item.ASSESOR = reader("ASSESOR")
                    End If
                    If reader("begraf_dek") IsNot DBNull.Value Then
                        item.begraf_dek = reader("begraf_dek")
                    End If
                    If reader("BEGRAFNIS") IsNot DBNull.Value Then
                        item.BEGRAFNIS = reader("BEGRAFNIS")
                    End If
                    If reader("BEROEP") IsNot DBNull.Value Then
                        item.BEROEP = reader("BEROEP")
                    End If
                    If reader("besk_nr") IsNot DBNull.Value Then
                        item.besk_nr = reader("besk_nr")
                    End If
                    If reader("BESKERM") IsNot DBNull.Value Then
                        item.BESKERM = reader("BESKERM")
                    End If
                    If reader("bet_dat") IsNot DBNull.Value Then
                        item.bet_dat = reader("bet_dat")
                    End If

                    If reader("BET_WYSE") IsNot DBNull.Value Then
                        item.BET_WYSE = reader("BET_WYSE")
                    End If
                    If reader("betaaldatum") IsNot DBNull.Value Then
                        item.betaaldatum = reader("betaaldatum")
                    End If

                    If reader("BTWNo") IsNot DBNull.Value Then
                        item.BTWNo = reader("BTWNo")
                    End If

                    If reader("BYBET_K") IsNot DBNull.Value Then
                        item.BYBET_K = reader("BYBET_K")
                    End If

                    If reader("bybmemo") IsNot DBNull.Value Then
                        item.bybmemo = reader("bybmemo")
                    End If

                    If reader("careassist") IsNot DBNull.Value Then
                        item.careassist = reader("careassist")
                    End If

                    If reader("CLRSTypeOfAmendment") IsNot DBNull.Value Then
                        item.CLRSTypeOfAmendment = reader("CLRSTypeOfAmendment")
                    End If

                    If reader("courtesyv") IsNot DBNull.Value Then
                        item.courtesyv = reader("courtesyv")
                    End If
                    If reader("DatumEffekGekans") IsNot DBNull.Value Then
                        item.DatumEffekGekans = reader("DatumEffekGekans")
                    End If

                    If reader("DatumGekanselleer") IsNot DBNull.Value Then
                        item.DatumGekanselleer = reader("DatumGekanselleer")
                    End If
                    If reader("DatumToegevoer") IsNot DBNull.Value Then
                        item.DatumToegevoer = reader("DatumToegevoer")
                    End If

                    If reader("DEPT") IsNot DBNull.Value Then
                        item.DEPT = reader("DEPT")
                    End If
                    If reader("EISBONUS") IsNot DBNull.Value Then
                        item.EISBONUS = reader("EISBONUS")
                    End If

                    If reader("Eisgeblok") IsNot DBNull.Value Then
                        item.Eisgeblok = reader("Eisgeblok")
                    End If
                    If reader("eispers") IsNot DBNull.Value Then
                        item.eispers = reader("eispers")
                    End If

                    If reader("elektroniesgestuur") IsNot DBNull.Value Then
                        item.elektroniesgestuur = reader("elektroniesgestuur")
                    End If
                    If reader("EMAIL") IsNot DBNull.Value Then
                        item.EMAIL = reader("EMAIL")
                    End If
                    If reader("epc") IsNot DBNull.Value Then
                        item.epc = reader("epc")
                    End If
                    If reader("FAX") IsNot DBNull.Value Then
                        item.FAX = reader("FAX")
                    End If
                    If reader("fkKansellasieRedes") IsNot DBNull.Value Then
                        item.fkKansellasieRedes = reader("fkKansellasieRedes")
                    End If

                    If reader("GEB_DAT") IsNot DBNull.Value Then
                        item.GEB_DAT = reader("GEB_DAT")
                    End If
                    If reader("GEKANS") IsNot DBNull.Value Then
                        item.GEKANS = reader("GEKANS")
                        If reader("GEKANS") = True Then
                            item.Active_Icon = "O"
                        Else
                            item.Active_Icon = "P"
                        End If
                    End If
                    If reader("HUIS_SUB") IsNot DBNull.Value Then
                        item.HUIS_SUB = reader("HUIS_SUB")
                    End If
                    If reader("HUIS_TEL") IsNot DBNull.Value Then
                        item.HUIS_TEL = reader("HUIS_TEL")
                    End If
                    If reader("HUIS_TEL2") IsNot DBNull.Value Then
                        item.HUIS_TEL2 = reader("HUIS_TEL2")
                    End If
                    If reader("ID_NOM") IsNot DBNull.Value Then
                        item.ID_NOM = reader("ID_NOM")
                    End If
                    If reader("INGEVORDER") IsNot DBNull.Value Then
                        item.INGEVORDER = reader("INGEVORDER")
                    End If
                    If reader("K_OPMERKING") IsNot DBNull.Value Then
                        item.K_OPMERKING = reader("K_OPMERKING")
                    End If
                    If reader("KLERK") IsNot DBNull.Value Then
                        item.KLERK = reader("KLERK")
                    End If
                    If reader("MAKELAAR") IsNot DBNull.Value Then
                        item.MAKELAAR = reader("MAKELAAR")
                    End If
                    If reader("MEDIES") IsNot DBNull.Value Then
                        item.MEDIES = reader("MEDIES")
                    End If
                    If reader("MOTOR_SUB") IsNot DBNull.Value Then
                        item.MOTOR_SUB = reader("MOTOR_SUB")
                    End If
                    If reader("noemnaam") IsNot DBNull.Value Then
                        item.noemnaam = reader("noemnaam")
                    End If
                    If reader("OPMERKING") IsNot DBNull.Value Then
                        item.OPMERKING = reader("OPMERKING")
                    End If
                    If reader("OUDSTUDENT") IsNot DBNull.Value Then
                        item.OUDSTUDENT = reader("OUDSTUDENT")
                    End If
                    If reader("P_A_DAT") IsNot DBNull.Value Then
                        item.P_A_DAT = reader("P_A_DAT")
                    End If
                    If reader("PakketItem1") IsNot DBNull.Value Then
                        item.PakketItem1 = reader("PakketItem1")
                    End If
                    If reader("PakketItem2") IsNot DBNull.Value Then
                        item.PakketItem2 = reader("PakketItem2")
                    End If
                    If reader("PakketItem3") IsNot DBNull.Value Then
                        item.PakketItem3 = reader("PakketItem3")
                    End If
                    If reader("PakketItem4") IsNot DBNull.Value Then
                        item.PakketItem4 = reader("PakketItem4")
                    End If
                    If reader("pers_nom") IsNot DBNull.Value Then
                        item.pers_nom = reader("pers_nom")
                    End If
                    If reader("PLIP") IsNot DBNull.Value Then
                        item.PLIP = reader("PLIP")
                    End If
                    If reader("PLIP1") IsNot DBNull.Value Then
                        item.PLIP1 = reader("PLIP1")
                    End If
                    If reader("POLFOOI") IsNot DBNull.Value Then
                        item.POLFOOI = reader("POLFOOI")
                    End If

                    If reader("POLISNO") IsNot DBNull.Value Then
                        item.POLISNO = reader("POLISNO")
                    End If
                    If reader("POS_VAKKIE") IsNot DBNull.Value Then
                        item.POS_VAKKIE = reader("POS_VAKKIE")
                    End If
                    If reader("POSBESTEMMING") IsNot DBNull.Value Then
                        item.POSBESTEMMING = reader("POSBESTEMMING")
                    End If
                    If reader("PREMIE") IsNot DBNull.Value Then
                        item.PREMIE = reader("PREMIE")
                    End If

                    If reader("premie2") IsNot DBNull.Value Then
                        item.premie2 = reader("premie2")
                    End If
                    If reader("PREMIEKODE") IsNot DBNull.Value Then
                        item.PREMIEKODE = reader("PREMIEKODE")
                    End If
                    If reader("SASPREM") IsNot DBNull.Value Then
                        item.SASPREM = reader("SASPREM")
                    End If
                    If reader("SEL_TEL") IsNot DBNull.Value Then
                        item.SEL_TEL = reader("SEL_TEL")
                    End If

                    If reader("selfoon") IsNot DBNull.Value Then
                        item.selfoon = reader("selfoon")
                    End If
                    If reader("STUDENTNO") IsNot DBNull.Value Then
                        item.STUDENTNO = reader("STUDENTNO")
                    End If
                    If reader("SUBTOTAAL") IsNot DBNull.Value Then
                        item.SUBTOTAAL = reader("SUBTOTAAL")
                    End If
                    If reader("TAAL") IsNot DBNull.Value Then
                        item.TAAL = reader("TAAL")
                    End If

                    If reader("TITEL") IsNot DBNull.Value Then
                        item.TITEL = reader("TITEL")
                    End If
                    If reader("titelnum") IsNot DBNull.Value Then
                        item.titelnum = reader("titelnum")
                    End If
                    If reader("TV_DIENS") IsNot DBNull.Value Then
                        item.TV_DIENS = reader("TV_DIENS")
                    End If
                    If reader("VANWIE") IsNot DBNull.Value Then
                        item.VANWIE = reader("VANWIE")
                    End If

                    If reader("verwysdeur") IsNot DBNull.Value Then
                        item.verwysdeur = reader("verwysdeur")
                    End If
                    If reader("verwyskommissie") IsNot DBNull.Value Then
                        item.verwyskommissie = reader("verwyskommissie")
                    End If
                    If reader("VOORL") IsNot DBNull.Value Then
                        item.VOORL = reader("VOORL")
                    End If
                    If reader("WERK_G") IsNot DBNull.Value Then
                        item.WERK_G = reader("WERK_G")
                    End If
                    If reader("WERK_TEL") IsNot DBNull.Value Then
                        item.WERK_TEL = reader("WERK_TEL")
                    End If
                    If reader("WERK_TEL2") IsNot DBNull.Value Then
                        item.WERK_TEL2 = reader("WERK_TEL2")
                    End If
                    If reader("WN_POLIS") IsNot DBNull.Value Then
                        item.WN_POLIS = reader("WN_POLIS")
                    End If
                    If reader("VERSEKERDE") IsNot DBNull.Value Then
                        item.VERSEKERDE = reader("VERSEKERDE")
                    End If
                    item.NoMatch = False
                Else
                    item.NoMatch = True
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function

    Public Function FetchPersoonl() As PERSOONLEntity
        Dim item As PERSOONLEntity = New PERSOONLEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                               New SqlParameter("@VERSEKERDE", SqlDbType.NVarChar)}
                'Andriette 15/08/2013 Verander na die global polisnommer
                'params(0).Value = Form1.form1Polisno.Text
                params(0).Value = glbPolicyNumber
                If params(0).Value = Nothing Then
                    params(0).Value = ""
                    'Else
                    '    params(0).Value = Form1.form1Polisno.Text
                End If
                params(1).Value = Form1.txtForm1Versekerde.Text

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlForFirstTime", params)

                If reader.Read() Then
                    If reader("ADRES") IsNot DBNull.Value Then
                        item.ADRES = reader("ADRES")
                    End If
                    If reader("ADRES1") IsNot DBNull.Value Then
                        item.ADRES1 = reader("ADRES1")
                    End If
                    If reader("ADRES2") IsNot DBNull.Value Then
                        item.ADRES2 = reader("ADRES2")
                    End If
                    If reader("adres3") IsNot DBNull.Value Then
                        item.adres3 = reader("adres3")
                    End If
                    If reader("Adres4") IsNot DBNull.Value Then
                        item.Adres4 = reader("Adres4")
                    End If
                    If reader("aftrekdat") IsNot DBNull.Value Then
                        item.aftrekdat = reader("aftrekdat")
                    End If
                    If reader("Polisno") IsNot DBNull.Value Then
                        item.POLISNO = reader("Polisno")
                    End If
                    If reader("ALLE_SUB") IsNot DBNull.Value Then
                        item.ALLE_SUB = reader("ALLE_SUB")
                    End If
                    If reader("Area") IsNot DBNull.Value Then
                        item.Area = reader("Area")
                    End If
                    If reader("ASSESOR") IsNot DBNull.Value Then
                        item.ASSESOR = reader("ASSESOR")
                    End If
                    If reader("begraf_dek") IsNot DBNull.Value Then
                        item.begraf_dek = reader("begraf_dek")
                    End If
                    If reader("BEGRAFNIS") IsNot DBNull.Value Then
                        item.BEGRAFNIS = reader("BEGRAFNIS")
                    End If
                    If reader("BEROEP") IsNot DBNull.Value Then
                        item.BEROEP = reader("BEROEP")
                    End If
                    If reader("besk_nr") IsNot DBNull.Value Then
                        item.besk_nr = reader("besk_nr")
                    End If
                    If reader("BESKERM") IsNot DBNull.Value Then
                        item.BESKERM = reader("BESKERM")
                    End If
                    If reader("bet_dat") IsNot DBNull.Value Then
                        item.bet_dat = reader("bet_dat")
                    End If

                    If reader("BET_WYSE") IsNot DBNull.Value Then
                        item.BET_WYSE = reader("BET_WYSE")
                    End If
                    If reader("betaaldatum") IsNot DBNull.Value Then
                        item.betaaldatum = reader("betaaldatum")
                    End If

                    If reader("BTWNo") IsNot DBNull.Value Then
                        item.BTWNo = reader("BTWNo")
                    End If

                    If reader("BYBET_K") IsNot DBNull.Value Then
                        item.BYBET_K = reader("BYBET_K")
                    End If

                    If reader("bybmemo") IsNot DBNull.Value Then
                        item.bybmemo = reader("bybmemo")
                    End If

                    If reader("careassist") IsNot DBNull.Value Then
                        item.careassist = reader("careassist")
                    End If

                    If reader("CLRSTypeOfAmendment") IsNot DBNull.Value Then
                        item.CLRSTypeOfAmendment = reader("CLRSTypeOfAmendment")
                    End If

                    If reader("courtesyv") IsNot DBNull.Value Then
                        item.courtesyv = reader("courtesyv")
                    End If
                    If reader("DatumEffekGekans") IsNot DBNull.Value Then
                        item.DatumEffekGekans = reader("DatumEffekGekans")
                    End If

                    If reader("DatumGekanselleer") IsNot DBNull.Value Then
                        item.DatumGekanselleer = reader("DatumGekanselleer")
                    End If
                    If reader("DatumToegevoer") IsNot DBNull.Value Then
                        item.DatumToegevoer = reader("DatumToegevoer")
                    End If

                    If reader("DEPT") IsNot DBNull.Value Then
                        item.DEPT = reader("DEPT")
                    End If
                    If reader("EISBONUS") IsNot DBNull.Value Then
                        item.EISBONUS = reader("EISBONUS")
                    End If

                    If reader("Eisgeblok") IsNot DBNull.Value Then
                        item.Eisgeblok = reader("Eisgeblok")
                    End If
                    If reader("eispers") IsNot DBNull.Value Then
                        item.eispers = reader("eispers")
                    End If

                    If reader("elektroniesgestuur") IsNot DBNull.Value Then
                        item.elektroniesgestuur = reader("elektroniesgestuur")
                    End If
                    If reader("EMAIL") IsNot DBNull.Value Then
                        item.EMAIL = reader("EMAIL")
                    End If
                    If reader("epc") IsNot DBNull.Value Then
                        item.epc = reader("epc")
                    End If
                    If reader("FAX") IsNot DBNull.Value Then
                        item.FAX = reader("FAX")
                    End If
                    If reader("fkKansellasieRedes") IsNot DBNull.Value Then
                        item.fkKansellasieRedes = reader("fkKansellasieRedes")
                    End If

                    If reader("GEB_DAT") IsNot DBNull.Value Then
                        item.GEB_DAT = reader("GEB_DAT")
                    End If
                    If reader("GEKANS") IsNot DBNull.Value Then
                        item.GEKANS = reader("GEKANS")
                        If reader("GEKANS") = True Then
                            item.Active_Icon = "O"
                        Else
                            item.Active_Icon = "P"
                        End If
                    End If
                    If reader("HUIS_SUB") IsNot DBNull.Value Then
                        item.HUIS_SUB = reader("HUIS_SUB")
                    End If
                    If reader("HUIS_TEL") IsNot DBNull.Value Then
                        item.HUIS_TEL = reader("HUIS_TEL")
                    End If
                    If reader("HUIS_TEL2") IsNot DBNull.Value Then
                        item.HUIS_TEL2 = reader("HUIS_TEL2")
                    End If
                    If reader("ID_NOM") IsNot DBNull.Value Then
                        item.ID_NOM = reader("ID_NOM")
                    End If
                    If reader("INGEVORDER") IsNot DBNull.Value Then
                        item.INGEVORDER = reader("INGEVORDER")
                    End If
                    If reader("K_OPMERKING") IsNot DBNull.Value Then
                        item.K_OPMERKING = reader("K_OPMERKING")
                    End If
                    If reader("KLERK") IsNot DBNull.Value Then
                        item.KLERK = reader("KLERK")
                    End If
                    If reader("MAKELAAR") IsNot DBNull.Value Then
                        item.MAKELAAR = reader("MAKELAAR")
                    End If
                    If reader("MEDIES") IsNot DBNull.Value Then
                        item.MEDIES = reader("MEDIES")
                    End If
                    If reader("MOTOR_SUB") IsNot DBNull.Value Then
                        item.MOTOR_SUB = reader("MOTOR_SUB")
                    End If
                    If reader("noemnaam") IsNot DBNull.Value Then
                        item.noemnaam = reader("noemnaam")
                    End If
                    If reader("OPMERKING") IsNot DBNull.Value Then
                        item.OPMERKING = reader("OPMERKING")
                    End If
                    If reader("OUDSTUDENT") IsNot DBNull.Value Then
                        item.OUDSTUDENT = reader("OUDSTUDENT")
                    End If
                    If reader("P_A_DAT") IsNot DBNull.Value Then
                        item.P_A_DAT = reader("P_A_DAT")
                    End If
                    If reader("PakketItem1") IsNot DBNull.Value Then
                        item.PakketItem1 = reader("PakketItem1")
                    End If
                    If reader("PakketItem2") IsNot DBNull.Value Then
                        item.PakketItem2 = reader("PakketItem2")
                    End If
                    If reader("PakketItem3") IsNot DBNull.Value Then
                        item.PakketItem3 = reader("PakketItem3")
                    End If
                    If reader("PakketItem4") IsNot DBNull.Value Then
                        item.PakketItem4 = reader("PakketItem4")
                    End If
                    If reader("pers_nom") IsNot DBNull.Value Then
                        item.pers_nom = reader("pers_nom")
                    End If
                    If reader("PLIP") IsNot DBNull.Value Then
                        item.PLIP = reader("PLIP")
                    End If
                    If reader("PLIP1") IsNot DBNull.Value Then
                        item.PLIP1 = reader("PLIP1")
                    End If
                    If reader("POLFOOI") IsNot DBNull.Value Then
                        item.POLFOOI = reader("POLFOOI")
                    End If

                    If reader("POLISNO") IsNot DBNull.Value Then
                        item.POLISNO = reader("POLISNO")
                    End If
                    If reader("POS_VAKKIE") IsNot DBNull.Value Then
                        item.POS_VAKKIE = reader("POS_VAKKIE")
                    End If
                    If reader("POSBESTEMMING") IsNot DBNull.Value Then
                        item.POSBESTEMMING = reader("POSBESTEMMING")
                    End If
                    If reader("PREMIE") IsNot DBNull.Value Then
                        item.PREMIE = reader("PREMIE")
                    End If

                    If reader("premie2") IsNot DBNull.Value Then
                        item.premie2 = reader("premie2")
                    End If
                    If reader("PREMIEKODE") IsNot DBNull.Value Then
                        item.PREMIEKODE = reader("PREMIEKODE")
                    End If
                    If reader("SASPREM") IsNot DBNull.Value Then
                        item.SASPREM = reader("SASPREM")
                    End If
                    If reader("SEL_TEL") IsNot DBNull.Value Then
                        item.SEL_TEL = reader("SEL_TEL")
                    End If

                    If reader("selfoon") IsNot DBNull.Value Then
                        item.selfoon = reader("selfoon")
                    End If
                    If reader("STUDENTNO") IsNot DBNull.Value Then
                        item.STUDENTNO = reader("STUDENTNO")
                    End If
                    If reader("SUBTOTAAL") IsNot DBNull.Value Then
                        item.SUBTOTAAL = reader("SUBTOTAAL")
                    End If
                    If reader("TAAL") IsNot DBNull.Value Then
                        item.TAAL = reader("TAAL")
                    End If

                    If reader("TITEL") IsNot DBNull.Value Then
                        item.TITEL = reader("TITEL")
                    End If
                    If reader("titelnum") IsNot DBNull.Value Then
                        item.titelnum = reader("titelnum")
                    End If
                    If reader("TV_DIENS") IsNot DBNull.Value Then
                        item.TV_DIENS = reader("TV_DIENS")
                    End If
                    If reader("VANWIE") IsNot DBNull.Value Then
                        item.VANWIE = reader("VANWIE")
                    End If

                    If reader("verwysdeur") IsNot DBNull.Value Then
                        item.verwysdeur = reader("verwysdeur")
                    End If
                    If reader("verwyskommissie") IsNot DBNull.Value Then
                        item.verwyskommissie = reader("verwyskommissie")
                    End If
                    If reader("VOORL") IsNot DBNull.Value Then
                        item.VOORL = reader("VOORL")
                    End If
                    If reader("WERK_G") IsNot DBNull.Value Then
                        item.WERK_G = reader("WERK_G")
                    End If
                    If reader("WERK_TEL") IsNot DBNull.Value Then
                        item.WERK_TEL = reader("WERK_TEL")
                    End If
                    If reader("WERK_TEL2") IsNot DBNull.Value Then
                        item.WERK_TEL2 = reader("WERK_TEL2")
                    End If
                    If reader("WN_POLIS") IsNot DBNull.Value Then
                        item.WN_POLIS = reader("WN_POLIS")
                    End If
                    If reader("VERSEKERDE") IsNot DBNull.Value Then
                        item.VERSEKERDE = reader("VERSEKERDE")
                    End If
                    item.NoMatch = False
                Else
                    item.NoMatch = True
                    Return item
                    Exit Function
                End If
                BFUpdateItemsSubTotals(item.POLISNO)
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function
    Public Function FetchPersoonForVers_Bes(ByVal policynumber As String) As PERSOONLEntity
        Dim item As PERSOONLEntity = New PERSOONLEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                               New SqlParameter("@VERSEKERDE", SqlDbType.NVarChar)}
                params(0).Value = policynumber
                If params(0).Value = Nothing Then
                    params(0).Value = ""
                Else
                    params(0).Value = policynumber
                End If
                params(1).Value = Form1.txtForm1Versekerde.Text

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlForFirstTime", params)

                If reader.Read() Then
                    If reader("ADRES") IsNot DBNull.Value Then
                        item.ADRES = reader("ADRES")
                    End If
                    If reader("ADRES1") IsNot DBNull.Value Then
                        item.ADRES1 = reader("ADRES1")
                    End If
                    If reader("ADRES2") IsNot DBNull.Value Then
                        item.ADRES2 = reader("ADRES2")
                    End If
                    If reader("adres3") IsNot DBNull.Value Then
                        item.adres3 = reader("adres3")
                    End If
                    If reader("Adres4") IsNot DBNull.Value Then
                        item.Adres4 = reader("Adres4")
                    End If
                    If reader("aftrekdat") IsNot DBNull.Value Then
                        item.aftrekdat = reader("aftrekdat")
                    End If
                    If reader("Polisno") IsNot DBNull.Value Then
                        item.POLISNO = reader("Polisno")
                    End If
                    If reader("ALLE_SUB") IsNot DBNull.Value Then
                        item.ALLE_SUB = reader("ALLE_SUB")
                    End If
                    If reader("Area") IsNot DBNull.Value Then
                        item.Area = reader("Area")
                    End If
                    If reader("ASSESOR") IsNot DBNull.Value Then
                        item.ASSESOR = reader("ASSESOR")
                    End If
                    If reader("begraf_dek") IsNot DBNull.Value Then
                        item.begraf_dek = reader("begraf_dek")
                    End If
                    If reader("BEGRAFNIS") IsNot DBNull.Value Then
                        item.BEGRAFNIS = reader("BEGRAFNIS")
                    End If
                    If reader("BEROEP") IsNot DBNull.Value Then
                        item.BEROEP = reader("BEROEP")
                    End If
                    If reader("besk_nr") IsNot DBNull.Value Then
                        item.besk_nr = reader("besk_nr")
                    End If
                    If reader("BESKERM") IsNot DBNull.Value Then
                        item.BESKERM = reader("BESKERM")
                    End If
                    If reader("bet_dat") IsNot DBNull.Value Then
                        item.bet_dat = reader("bet_dat")
                    End If

                    If reader("BET_WYSE") IsNot DBNull.Value Then
                        item.BET_WYSE = reader("BET_WYSE")
                    End If
                    If reader("betaaldatum") IsNot DBNull.Value Then
                        item.betaaldatum = reader("betaaldatum")
                    End If

                    If reader("BTWNo") IsNot DBNull.Value Then
                        item.BTWNo = reader("BTWNo")
                    End If

                    If reader("BYBET_K") IsNot DBNull.Value Then
                        item.BYBET_K = reader("BYBET_K")
                    End If

                    If reader("bybmemo") IsNot DBNull.Value Then
                        item.bybmemo = reader("bybmemo")
                    End If

                    If reader("careassist") IsNot DBNull.Value Then
                        item.careassist = reader("careassist")
                    End If

                    If reader("CLRSTypeOfAmendment") IsNot DBNull.Value Then
                        item.CLRSTypeOfAmendment = reader("CLRSTypeOfAmendment")
                    End If

                    If reader("courtesyv") IsNot DBNull.Value Then
                        item.courtesyv = reader("courtesyv")
                    End If
                    If reader("DatumEffekGekans") IsNot DBNull.Value Then
                        item.DatumEffekGekans = reader("DatumEffekGekans")
                    End If

                    If reader("DatumGekanselleer") IsNot DBNull.Value Then
                        item.DatumGekanselleer = reader("DatumGekanselleer")
                    End If
                    If reader("DatumToegevoer") IsNot DBNull.Value Then
                        item.DatumToegevoer = reader("DatumToegevoer")
                    End If

                    If reader("DEPT") IsNot DBNull.Value Then
                        item.DEPT = reader("DEPT")
                    End If
                    If reader("EISBONUS") IsNot DBNull.Value Then
                        item.EISBONUS = reader("EISBONUS")
                    End If

                    If reader("Eisgeblok") IsNot DBNull.Value Then
                        item.Eisgeblok = reader("Eisgeblok")
                    End If
                    If reader("eispers") IsNot DBNull.Value Then
                        item.eispers = reader("eispers")
                    End If

                    If reader("elektroniesgestuur") IsNot DBNull.Value Then
                        item.elektroniesgestuur = reader("elektroniesgestuur")
                    End If
                    If reader("EMAIL") IsNot DBNull.Value Then
                        item.EMAIL = reader("EMAIL")
                    End If
                    If reader("epc") IsNot DBNull.Value Then
                        item.epc = reader("epc")
                    End If
                    If reader("FAX") IsNot DBNull.Value Then
                        item.FAX = reader("FAX")
                    End If
                    If reader("fkKansellasieRedes") IsNot DBNull.Value Then
                        item.fkKansellasieRedes = reader("fkKansellasieRedes")
                    End If

                    If reader("GEB_DAT") IsNot DBNull.Value Then
                        item.GEB_DAT = reader("GEB_DAT")
                    End If
                    If reader("GEKANS") IsNot DBNull.Value Then
                        item.GEKANS = reader("GEKANS")
                        If reader("GEKANS") = True Then
                            item.Active_Icon = "O"
                        Else
                            item.Active_Icon = "P"
                        End If
                    End If
                    If reader("HUIS_SUB") IsNot DBNull.Value Then
                        item.HUIS_SUB = reader("HUIS_SUB")
                    End If
                    If reader("HUIS_TEL") IsNot DBNull.Value Then
                        item.HUIS_TEL = reader("HUIS_TEL")
                    End If
                    If reader("HUIS_TEL2") IsNot DBNull.Value Then
                        item.HUIS_TEL2 = reader("HUIS_TEL2")
                    End If
                    If reader("ID_NOM") IsNot DBNull.Value Then
                        item.ID_NOM = reader("ID_NOM")
                    End If
                    If reader("INGEVORDER") IsNot DBNull.Value Then
                        item.INGEVORDER = reader("INGEVORDER")
                    End If
                    If reader("K_OPMERKING") IsNot DBNull.Value Then
                        item.K_OPMERKING = reader("K_OPMERKING")
                    End If
                    If reader("KLERK") IsNot DBNull.Value Then
                        item.KLERK = reader("KLERK")
                    End If
                    If reader("MAKELAAR") IsNot DBNull.Value Then
                        item.MAKELAAR = reader("MAKELAAR")
                    End If
                    If reader("MEDIES") IsNot DBNull.Value Then
                        item.MEDIES = reader("MEDIES")
                    End If
                    If reader("MOTOR_SUB") IsNot DBNull.Value Then
                        item.MOTOR_SUB = reader("MOTOR_SUB")
                    End If
                    If reader("noemnaam") IsNot DBNull.Value Then
                        item.noemnaam = reader("noemnaam")
                    End If
                    If reader("OPMERKING") IsNot DBNull.Value Then
                        item.OPMERKING = reader("OPMERKING")
                    End If
                    If reader("OUDSTUDENT") IsNot DBNull.Value Then
                        item.OUDSTUDENT = reader("OUDSTUDENT")
                    End If
                    If reader("P_A_DAT") IsNot DBNull.Value Then
                        item.P_A_DAT = reader("P_A_DAT")
                    End If
                    If reader("PakketItem1") IsNot DBNull.Value Then
                        item.PakketItem1 = reader("PakketItem1")
                    End If
                    If reader("PakketItem2") IsNot DBNull.Value Then
                        item.PakketItem2 = reader("PakketItem2")
                    End If
                    If reader("PakketItem3") IsNot DBNull.Value Then
                        item.PakketItem3 = reader("PakketItem3")
                    End If
                    If reader("PakketItem4") IsNot DBNull.Value Then
                        item.PakketItem4 = reader("PakketItem4")
                    End If
                    If reader("pers_nom") IsNot DBNull.Value Then
                        item.pers_nom = reader("pers_nom")
                    End If
                    If reader("PLIP") IsNot DBNull.Value Then
                        item.PLIP = reader("PLIP")
                    End If
                    If reader("PLIP1") IsNot DBNull.Value Then
                        item.PLIP1 = reader("PLIP1")
                    End If
                    If reader("POLFOOI") IsNot DBNull.Value Then
                        item.POLFOOI = reader("POLFOOI")
                    End If

                    If reader("POLISNO") IsNot DBNull.Value Then
                        item.POLISNO = reader("POLISNO")
                    End If
                    If reader("POS_VAKKIE") IsNot DBNull.Value Then
                        item.POS_VAKKIE = reader("POS_VAKKIE")
                    End If
                    If reader("POSBESTEMMING") IsNot DBNull.Value Then
                        item.POSBESTEMMING = reader("POSBESTEMMING")
                    End If
                    If reader("PREMIE") IsNot DBNull.Value Then
                        item.PREMIE = reader("PREMIE")
                    End If

                    If reader("premie2") IsNot DBNull.Value Then
                        item.premie2 = reader("premie2")
                    End If
                    If reader("PREMIEKODE") IsNot DBNull.Value Then
                        item.PREMIEKODE = reader("PREMIEKODE")
                    End If
                    If reader("SASPREM") IsNot DBNull.Value Then
                        item.SASPREM = reader("SASPREM")
                    End If
                    If reader("SEL_TEL") IsNot DBNull.Value Then
                        item.SEL_TEL = reader("SEL_TEL")
                    End If

                    If reader("selfoon") IsNot DBNull.Value Then
                        item.selfoon = reader("selfoon")
                    End If
                    If reader("STUDENTNO") IsNot DBNull.Value Then
                        item.STUDENTNO = reader("STUDENTNO")
                    End If
                    If reader("SUBTOTAAL") IsNot DBNull.Value Then
                        item.SUBTOTAAL = reader("SUBTOTAAL")
                    End If
                    If reader("TAAL") IsNot DBNull.Value Then
                        item.TAAL = reader("TAAL")
                    End If

                    If reader("TITEL") IsNot DBNull.Value Then
                        item.TITEL = reader("TITEL")
                    End If
                    If reader("titelnum") IsNot DBNull.Value Then
                        item.titelnum = reader("titelnum")
                    End If
                    If reader("TV_DIENS") IsNot DBNull.Value Then
                        item.TV_DIENS = reader("TV_DIENS")
                    End If
                    If reader("VANWIE") IsNot DBNull.Value Then
                        item.VANWIE = reader("VANWIE")
                    End If

                    If reader("verwysdeur") IsNot DBNull.Value Then
                        item.verwysdeur = reader("verwysdeur")
                    End If
                    If reader("verwyskommissie") IsNot DBNull.Value Then
                        item.verwyskommissie = reader("verwyskommissie")
                    End If
                    If reader("VOORL") IsNot DBNull.Value Then
                        item.VOORL = reader("VOORL")
                    End If
                    If reader("WERK_G") IsNot DBNull.Value Then
                        item.WERK_G = reader("WERK_G")
                    End If
                    If reader("WERK_TEL") IsNot DBNull.Value Then
                        item.WERK_TEL = reader("WERK_TEL")
                    End If
                    If reader("WERK_TEL2") IsNot DBNull.Value Then
                        item.WERK_TEL2 = reader("WERK_TEL2")
                    End If
                    If reader("WN_POLIS") IsNot DBNull.Value Then
                        item.WN_POLIS = reader("WN_POLIS")
                    End If
                    If reader("VERSEKERDE") IsNot DBNull.Value Then
                        item.VERSEKERDE = reader("VERSEKERDE")
                    End If
                    item.NoMatch = False
                Else
                    item.NoMatch = True
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function

    Function ListAreaDropdown() As List(Of String)
        Dim param As New SqlParameter("@Area", SqlDbType.NVarChar)

        If Gebruiker.titel = "Programmeerder" Then
            param.Value = ""
        Else
            param.Value = Gebruiker.BranchCodes
        End If

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchArea", param)
                Dim list As List(Of String) = New List(Of String)

                While reader.Read()
                    Dim item As AreaEntity = New AreaEntity()

                    If list.Count = 0 Then
                        item.Area_Besk = "Alle Areas"
                        list.Add(item.Area_Besk)
                    End If

                    If reader("Area_Besk") IsNot DBNull.Value Then
                        item.Area_Besk = reader("Area_Besk")
                    End If

                    If list.Count = 0 Then
                        item.Area_Besk = "Alle Areas"
                    End If

                    list.Add(item.Area_Besk)
                End While
                Return list
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function

    Function ListAreaDropdownByb() As List(Of AreaEntity)
        Dim param As New SqlParameter("@Area", SqlDbType.NVarChar)
        param.Value = ""
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchArea", param)
                Dim list As List(Of AreaEntity) = New List(Of AreaEntity)

                While reader.Read()
                    Dim item As AreaEntity = New AreaEntity()
                    If reader("Area_Besk") IsNot DBNull.Value Then
                        item.Area_Besk = reader("Area_Besk")
                        item.pkarea = reader("pkarea")
                    End If
                    list.Add(item)
                End While
                Return list
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function

    Public Function ListArea() As List(Of AreaEntity)
        Dim list As List(Of AreaEntity) = New List(Of AreaEntity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.ListArea")
                While reader.Read()
                    Dim item As AreaEntity = New AreaEntity()
                    item.DisplayField = reader("DisplayField")

                    list.Add(item)
                End While
                Return list
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function

    Public Function ListBYBET_K(ByVal language As Integer) As List(Of String)
        Dim list As List(Of String) = New List(Of String)
        If language = 0 Then
            list.Add("Gewone")
            list.Add("Bejaarde")
            list.Add("R 1000.00")
            list.Add("Afkoop")
            list.Add("Opsioneel")
            list.Add("Alternatief")
            Return list
        ElseIf language = 1 Then
            list.Add("Plain")
            list.Add("Pensioner")
            list.Add("R 1000.00")
            list.Add("Buy Off")
            list.Add("Optional")
            list.Add("Alternative")
            Return list
        End If
        Return list
    End Function

    Public Function ListBemarker() As List(Of ComboBoxEntity)
        Dim list As List(Of ComboBoxEntity) = New List(Of ComboBoxEntity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.Listbemarker")
                While reader.Read()

                    Dim Item As ComboBoxEntity = New ComboBoxEntity()
                    Item.ComboBoxID = reader("kode_bem_num")
                    Item.ComboBoxName = reader("naam")
                    list.Add(Item)
                End While
                Return list
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function

    Public Function ListOUDSTUDENT() As List(Of OUDSTUDENTEntity)
        Dim list As List(Of OUDSTUDENTEntity) = New List(Of OUDSTUDENTEntity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.ListOUDSTUDENT")
                While reader.Read()
                    Dim item As OUDSTUDENTEntity = New OUDSTUDENTEntity()
                    item.INSTANSIENAAM = reader("INSTANSIENAAM")
                    list.Add(item)
                End While
                Return list
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function

    Function FetchGebruikerList() As List(Of GebruikersEntity)
        Dim list As List(Of GebruikersEntity) = New List(Of GebruikersEntity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@BranchCode", SqlDbType.NVarChar)
                If Gebruiker.titel = "Programmeerder" Then
                    param.Value = ""
                Else
                    param.Value = Gebruiker.BranchCodes
                End If

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "sekurit.FetchAllGebruikers", param)
                While reader.Read()
                    Dim item As GebruikersEntity = New GebruikersEntity()
                    item = New GebruikersEntity()
                    If reader("ApplicationPath") IsNot DBNull.Value Then
                        item.ApplicationPath = reader("ApplicationPath")
                    End If

                    If reader("Area_kode") IsNot DBNull.Value Then
                        item.Area_kode = reader("Area_kode")
                    End If

                    If reader("BranchCodes") IsNot DBNull.Value Then
                        item.BranchCodes = reader("BranchCodes")
                    End If

                    If reader("Kode") IsNot DBNull.Value Then
                        item.Kode = reader("Kode")
                    End If

                    If reader("Naam") IsNot DBNull.Value Then
                        item.Naam = reader("Naam")
                    End If

                    If reader("Nedseedno") IsNot DBNull.Value Then
                        item.Nedseedno = reader("Nedseedno")
                    End If

                    If reader("Policynumber") IsNot DBNull.Value Then
                        item.Policynumber = reader("Policynumber")
                    End If

                    If reader("titel") IsNot DBNull.Value Then
                        item.titel = reader("titel")
                    End If

                    If reader("WindowsUsername") IsNot DBNull.Value Then
                        item.WindowsUsername = reader("WindowsUsername")
                    End If

                    list.Add(item)
                End While
                Return list
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function

    Public Function FetchSekuriteitList(ByVal Type As String) As List(Of SekuriteitEntity)
        listSekuriteit = New List(Of SekuriteitEntity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@Type", SqlDbType.NVarChar)
                param.Value = Type

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchSekuriteitbyType", param)
                While reader.Read()
                    Dim item As SekuriteitEntity = New SekuriteitEntity()
                    item = New SekuriteitEntity()

                    If reader("pkSekuriteit") IsNot DBNull.Value Then
                        item.Sekuriteit = reader("pkSekuriteit")
                    End If

                    If reader("Tipe") IsNot DBNull.Value Then
                        item.Tipe = reader("Tipe")
                    End If

                    If reader("Bit") IsNot DBNull.Value Then
                        item.Bit = reader("Bit")
                    End If

                    If reader("Bitvalue") IsNot DBNull.Value Then
                        item.Bitvalue = reader("Bitvalue")
                    End If

                    If reader("BeskrywingAfrikaans") IsNot DBNull.Value Then
                        item.BeskrywingAfrikaans = reader("BeskrywingAfrikaans")
                    End If

                    If reader("BeskrywingEngels") IsNot DBNull.Value Then
                        item.BeskrywingEngels = reader("BeskrywingEngels")
                    End If

                    listSekuriteit.Add(item)
                End While
                Return listSekuriteit
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function

    Public Function ListHuis(ByRef Nommer As String) As List(Of HuisEntity)
        ListHuis = New List(Of HuisEntity)
        '  Dim dblpremiewaarde As Double = 0.0

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter(PARM_POLISNO, SqlDbType.NVarChar)
                ' Andriette 14/06/2013 gebruik die parameter
                'param.Value = Form1.form1Polisno.Text
                param.Value = Nommer
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchHuisByPolisno", param)

                While reader.Read()
                    Dim item As HuisEntity = New HuisEntity()
                    item = New HuisEntity()
                    If reader("pkHuis") IsNot DBNull.Value Then
                        item.pkHuis = reader("pkHuis")
                    End If
                    If reader("ADRES_H1") IsNot DBNull.Value Then
                        item.ADRES_H1 = reader("ADRES_H1")
                    End If
                    If reader("Adres4") IsNot DBNull.Value Then
                        item.Adres4 = reader("Adres4")
                    End If
                    If reader("voorstad") IsNot DBNull.Value Then
                        item.voorstad = reader("voorstad")
                    End If
                    If reader("STRUKTUUR") IsNot DBNull.Value Then
                        item.STRUKTUUR = reader("STRUKTUUR")
                    End If
                    If reader("TIPE_DAK") IsNot DBNull.Value Then
                        item.TIPE_DAK = reader("TIPE_DAK")
                    End If
                    If reader("mainproperty") IsNot DBNull.Value Then
                        item.mainproperty = reader("mainproperty")
                    End If
                    If reader("SekuriteitBitValue") IsNot DBNull.Value Then
                        item.SekuriteitBitValue = reader("SekuriteitBitValue")
                    End If
                    If reader("sekuriteit") IsNot DBNull.Value Then
                        item.sekuriteit = reader("sekuriteit")
                    End If

                    If reader("WAARDE_HB") IsNot DBNull.Value Then
                        ' Andriette 07/09/2013 formatering
                        'Andriette 26/08/2013 verwyder alle formatting
                        '    item.WAARDE_HB = FormatNumber(reader("WAARDE_HB"), 0)
                        item.WAARDE_HB = reader("WAARDE_HB")
                    End If
                    If reader("PREMIE_HB") IsNot DBNull.Value Then
                        'Andriette 05/08/2013 doen formatting
                        'Andriette 26/08/2013 verwyder alle formatting
                        ' item.PREMIE_HB = FormatNumber(reader("PREMIE_HB"), 2)
                        item.PREMIE_HB = reader("PREMIE_HB")
                    End If
                    If reader("WaardeHE") IsNot DBNull.Value Then
                        ' Andriette 07/09/2013 formatering
                        'Andriette 26/08/2013 verwyder alle formatting
                        'item.WAARDE_HE = FormatNumber(reader("WaardeHE"), 0)
                        item.WAARDE_HE = reader("Waarde_HE")
                    End If
                    If reader("PREMIE_HE") IsNot DBNull.Value Then
                        ' Andriette 07/09/2013 formatering
                        'Andriette 26/08/2013 verwyder alle formatting
                        ' item.PREMIE_HE = FormatNumber(reader("PREMIE_HE"), 2)
                        item.PREMIE_HE = reader("PREMIE_HE")
                    End If
                    If reader("eem_waarde") IsNot DBNull.Value Then
                        'Andriette 05/08/2013 doen formatting
                        'Andriette 26/08/2013 verwyder alle formatting
                        ' item.eem_waarde = FormatNumber(reader("eem_waarde"), 0)
                        item.eem_waarde = reader("eem_waarde")
                    End If
                    If reader("eem_premie") IsNot DBNull.Value Then
                        'Andriette 05/08/2013 doen formatting
                        'item.eem_premie = FormatNumber(reader("eem_premie"), 2)
                        item.eem_premie = reader("eem_premie")
                    End If
                    If reader("toe_waarde") IsNot DBNull.Value Then
                        ' Andriette 07/09/2013 formatering
                        'Andriette 26/08/2013 verwyder alle formatting
                        '  item.toe_waarde = FormatNumber(reader("toe_waarde"), 0)
                        item.toe_waarde = reader("toe_waarde")
                    End If
                    If reader("toe_premie") IsNot DBNull.Value Then
                        'Andriette 05/08/2013 doen formatting
                        '  item.toe_premie = FormatNumber(reader("toe_premie"), 2)
                        item.toe_premie = reader("toe_premie")
                    End If

                    ' Andriette 16/04/2013 want die sente het nie presies reg gewys nie 1.36 op 1083000286
                    'If reader("PremieHE") IsNot DBNull.Value Then
                    '    item.PREMIE_HE = FormatNumber(reader("PremieHE"), 2)
                    'End If
                    'If reader("A_KOMM") IsNot DBNull.Value Then
                    '    item.A_KOMM = reader("A_KOMM")
                    'End If
                    'If reader("A_GOEDGEKEUR") IsNot DBNull.Value Then
                    '    item.A_GOEDGEKEUR = reader("A_GOEDGEKEUR")
                    'End If
                    'If reader("fkHomeLoanOrg") IsNot DBNull.Value Then
                    '    item.fkHomeLoanOrg = reader("fkHomeLoanOrg")
                    'End If
                    'If reader("fkPropertyType") IsNot DBNull.Value Then
                    '    item.fkPropertyType = reader("fkPropertyType")
                    'End If


                    If Persoonl.TAAL = 0 Then
                        'Add to list HouseHolders if value > 0
                        If item.WAARDE_HB <> 0 Then
                            item.EiendomDisplay = "Huisbewoners: " & Trim(item.ADRES_H1) & " " & Trim(item.Adres4) & " " & Trim(item.voorstad)
                        End If
                        'Add to list HousOwners if value > 0
                        If item.WAARDE_HE <> 0 Then
                            item.EiendomDisplay = "Huiseienaar: " & Trim(item.ADRES_H1) & " " & Trim(item.Adres4) & " " & Trim(item.voorstad)
                        End If
                    Else
                        'Add to list HouseHolders if value > 0
                        If item.WAARDE_HB <> 0 Then
                            item.EiendomDisplay = "House holders: " & Trim(item.ADRES_H1) & " " & Trim(item.Adres4) & " " & Trim(item.voorstad)
                        End If
                        'Add to list HousOwners if value > 0
                        If item.WAARDE_HE <> 0 Then
                            item.EiendomDisplay = "House owners: " & Trim(item.ADRES_H1) & " " & Trim(item.Adres4) & " " & Trim(item.voorstad)
                        End If
                    End If

                    ListHuis.Add(item)
                End While
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return ListHuis
    End Function

    Public Function ListAreaByBranchCodes(ByVal branchcodes As String) As List(Of AreaEntity)
        Dim list As List(Of AreaEntity) = New List(Of AreaEntity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter(PARM_BranchCodes, SqlDbType.NVarChar)
                param.Value = branchcodes
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.ListAreaByBranchCodes", param)
                While reader.Read()
                    Dim item As AreaEntity = New AreaEntity()
                    item.DisplayField = reader("DisplayField")
                    item.Tak_Naam = reader("Tak_Naam")
                    list.Add(item)
                End While
                Return list
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function

    Public Function gen_getPropertySecurity(ByRef language As Byte, ByRef totalBitValue As Integer) As String
        Dim strfieldname As String
        Dim strtmp As String
        Dim strnoneDescription As String

        'Check language
        If language = 0 Then
            strfieldname = "beskrywingAfrikaans"
            strnoneDescription = "Geen"
        Else
            strfieldname = "beskrywingEngels"
            strnoneDescription = "None"
        End If

        strtmp = ""
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "sekurit.ListSekuritEiendom")
                While reader.Read()
                    If totalBitValue And reader("Bitvalue").ToString() Then
                        strtmp = strtmp & reader(strfieldname).ToString() & ", "
                    End If
                End While
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox("There's error trying to connect to the database.", MsgBoxStyle.Exclamation)
        End Try
        If strtmp <> "" Then
            strtmp = strtmp.Remove(strtmp.Length - 2, 1)
        Else
            strtmp = strnoneDescription
        End If
        Return strtmp

    End Function

    Public Function gen_getVehicleSecurity(ByRef language As Byte, ByRef totalBitValue As Integer) As String
        Dim strfieldname As String
        Dim strtmp As String
        Dim strnoneDescription As String

        'Check language
        If language = 0 Then
            strfieldname = "beskrywingAfrikaans"
            strnoneDescription = "Geen"
        Else
            strfieldname = "beskrywingEngels"
            strnoneDescription = "None"
        End If
        strtmp = ""
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.ListsekuriteitOnVoertuig")
                While reader.Read()
                    If totalBitValue And reader("Bitvalue").ToString() Then
                        strtmp = strtmp & reader(strfieldname).ToString() & ", "
                    End If
                End While
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        If strtmp <> "" Then
            strtmp = strtmp.Remove(strtmp.Length - 2, 1)
        Else
            strtmp = strnoneDescription
        End If
        Return strtmp
    End Function

    Public Function ListALLERISKByPolisno(ByVal strpolisno As String) As List(Of ALLERISKEntity)
        Dim list As List(Of ALLERISKEntity) = New List(Of ALLERISKEntity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter(PARM_POLISNO, SqlDbType.NVarChar)
                ' Andriette 14/06/2013 gebruik die parameter as die sp se parameter
                '  param.Value = Form1.form1Polisno.Text
                param.Value = strpolisno
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.ListALLERISKByPolisno", param)
                While reader.Read()
                    Dim item As ALLERISKEntity = New ALLERISKEntity()
                    'Andriette 23/04/2014 
                    If reader("POLISNO") IsNot DBNull.Value Then
                        item.POLISNO = reader("POLISNO")
                    Else
                        item.POLISNO = ""
                    End If

                    If reader("pkAllerisk") IsNot DBNull.Value Then
                        item.pkAllerisk = reader("pkAllerisk")
                    Else
                        item.pkAllerisk = ""
                    End If
                    If reader("Waarde") IsNot DBNull.Value Then
                        item.Waarde = FormatNumber(reader("Waarde"), 0)
                    Else
                        item.Waarde = 0
                    End If

                    If reader("Beskrywing") IsNot DBNull.Value Then
                        item.Beskrywing = reader("Beskrywing")
                    Else
                        item.Beskrywing = ""
                    End If
                    'Andriette 06/08/2013 verander die formatering
                    '     item.Premie = FormatNumber(reader("Premie"), 2)
                    If reader("Premie") IsNot DBNull.Value Then
                        ' Andriette 07/09/2013 formatering
                        If reader("Premie") = 0 Then
                            item.Premie = FormatNumber(0, 2)
                        Else
                            item.Premie = FormatNumber(reader("Premie"), 2)
                        End If
                        ' item.WAARDE_HB = FormatNumber(reader("WAARDE_HB"), 0)
                    End If
                    If reader("beskryf") IsNot DBNull.Value Then
                        item.beskryf = reader("beskryf")
                    Else
                        item.beskryf = ""
                    End If

                    list.Add(item)
                End While
                Return list
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function

    Public Function listPoskode(ByVal type As String, ByVal voorstad As String, ByVal dorp As String, ByVal poskode As String) As List(Of PoskodeEntity)
        Dim list As List(Of PoskodeEntity) = New List(Of PoskodeEntity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@type", SqlDbType.NVarChar), _
                                                New SqlParameter("@voorstad", SqlDbType.NVarChar), _
                                                New SqlParameter("@dorp", SqlDbType.NVarChar), _
                                                New SqlParameter("@poskode", SqlDbType.NVarChar)}


                params(0).Value = type
                If voorstad = "" Then
                    params(1).Value = DBNull.Value
                Else
                    params(1).Value = voorstad
                End If

                If dorp = "" Then
                    params(2).Value = DBNull.Value
                Else
                    params(2).Value = dorp
                End If

                If poskode = "" Then
                    params(3).Value = DBNull.Value
                Else
                    params(3).Value = poskode
                End If


                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.ListPoskode", params)
                While reader.Read()
                    Dim item As PoskodeEntity = New PoskodeEntity()

                    If IsDBNull(reader("Voorstad")) Then
                        item.Voorstad = ""
                    Else
                        item.Voorstad = reader("Voorstad")
                    End If

                    If IsDBNull(reader("Dorp/Stad")) Then
                        item.Dorp = ""
                    Else
                        item.Dorp = reader("Dorp/Stad")
                    End If

                    If type = "Straat" Then
                        If IsDBNull(reader("Poskode (Straat)")) Then
                            item.Poskode = ""
                        Else
                            item.Poskode = reader("Poskode (Straat)")
                        End If
                    End If

                    If type <> "Straat" Then
                        If IsDBNull(reader("Poskode (Posbus)")) Then
                            item.PoskodePosbus = ""
                        Else
                            item.PoskodePosbus = reader("Poskode (Posbus)")
                        End If
                    End If
                    list.Add(item)
                End While
                Return list
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function

    Function ListVoertuie(ByVal strpolisno As String) As List(Of ListVoertuieByPolisnoEntity)

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter(PARM_POLISNO, SqlDbType.NVarChar)
                'Andriette 15/08/2013 gebruik eerder die parameter wat in elke geval gegee word
                ' param.Value = Persoonl.POLISNO
                param.Value = strpolisno
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.ListVoertuieByPolisno", param)

                Dim list As List(Of ListVoertuieByPolisnoEntity) = New List(Of ListVoertuieByPolisnoEntity)
                While reader.Read()
                    Dim item As ListVoertuieByPolisnoEntity = New ListVoertuieByPolisnoEntity()
                    If Not IsDBNull(reader("Ander")) Then
                        item.Ander = reader("Ander")
                    End If

                    If Not IsDBNull(reader("Dekking")) Then
                        'Andriette 27/06/2013 formatering
                        item.Dekking = FormatNumber(reader("Dekking"), 0)

                    End If

                    If Not IsDBNull(reader("Fabrikaat")) Then
                        item.Fabrikaat = reader("Fabrikaat")
                    End If

                    If Not IsDBNull(reader("Jaar")) Then
                        item.Jaar = reader("Jaar")
                    End If

                    If Not IsDBNull(reader("Model beskrywing")) Then
                        item.Modelbeskrywing = reader("Model beskrywing")
                    End If

                    If Not IsDBNull(reader("pkVoertuie")) Then
                        item.pkVoertuie = reader("pkVoertuie")
                    End If

                    If Not IsDBNull(reader("Registrasie No")) Then
                        item.RegistrasieNo = reader("Registrasie No")
                    End If

                    If Not IsDBNull(reader("Sekuriteit")) Then
                        item.Sekuriteit = reader("Sekuriteit")
                    End If

                    If Not IsDBNull(reader("Totale premie")) Then
                        item.Totalepremie = FormatNumber(reader("Totale premie"), 2)
                    End If

                    If Not IsDBNull(reader("Totale waarde")) Then
                        item.Totalewaarde = FormatNumber(reader("Totale waarde"), 0)
                    End If

                    If Not IsDBNull(reader("KODE")) Then
                        item.KODE = reader("KODE")
                    End If

                    list.Add(item)
                End While
                Return list
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function

    Function ListKansellasieRedes() As List(Of KansellasieRedesEntity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.ListKansellasieRedes")

                Dim list As List(Of KansellasieRedesEntity) = New List(Of KansellasieRedesEntity)
                While reader.Read()
                    Dim item As KansellasieRedesEntity = New KansellasieRedesEntity()
                    item.pkKansellasieRedes = reader("pkKansellasieRedes")
                    item.BeskrywingAfrikaans = reader("Afrikaans")
                    item.BeskrywingEngels = reader("Engels")
                    item.Deleted = reader("Deleted")
                    list.Add(item)
                End While
                Return list
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function

    Function ListWysig() As List(Of WysigEntity)
        Dim strDatum As String
        Dim strDate As String

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                param.Value = Persoonl.POLISNO
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[wysigs]", param)

                Dim list As List(Of WysigEntity) = New List(Of WysigEntity)
                While reader.Read()
                    Dim item As WysigEntity = New WysigEntity()
                    ' Andriette 06/05/2013 haal die ekstra een uit geen nut
                    '  Dim description As WysigEntity = New WysigEntity
                    ' Andriette 18/03/2013 Toets elke keer vir dbnull
                    If reader("POLISNO") IsNot DBNull.Value Then
                        item.polisno = Trim(reader("POLISNO"))
                    Else
                        item.polisno = ""
                    End If
                    ' item.polisno = reader("polisno")
                    If reader("kode") IsNot DBNull.Value Then
                        item.kode = Trim(reader("kode"))
                    Else
                        item.kode = ""
                    End If

                    If reader("datum") IsNot DBNull.Value Then
                        strDate = reader("datum")
                        ' strDate = strDate.ToString("{0:dd/mm/yyyy  HH:MM:SS}")
                        strDate = String.Format(strDate, "{0:dd/mm/yyyy  HH:MM:SS}")
                        item.datum = DateTime.Parse(strDate)
                        ' item.datum = Trim(reader("datum"))
                        ' item.datum = String.Format(reader("datum"), "{0:dd}/{0:mm}/{0:yyyy}  hh:mm:ss")
                    Else
                        item.datum = ""
                    End If

                    If reader("versekerde") IsNot DBNull.Value Then
                        item.versekerde = Trim(reader("versekerde"))
                    Else
                        item.versekerde = ""
                    End If

                    If reader("voorl") IsNot DBNull.Value Then
                        item.voorl = Trim(reader("voorl"))
                    Else
                        item.voorl = ""
                    End If

                    If reader("gebruiker") IsNot DBNull.Value Then
                        item.gebruiker = Trim(reader("gebruiker"))
                    Else
                        item.gebruiker = ""
                    End If

                    If reader("beskrywing") IsNot DBNull.Value Then
                        item.beskrywing = Trim(reader("beskrywing"))
                    Else
                        item.beskrywing = ""
                    End If

                    item.description = ""
                    'If Persoonl.TAAL = 0 Then
                    '    If reader("besk") IsNot DBNull.Value Then
                    '        item.besk = Trim(reader("besk"))
                    '    Else
                    '        item.besk = ""
                    '    End If
                    '    ' Andriette 120/03/2013 verander die view
                    '    'If reader'("datum") IsNot DBNull.Value Then
                    '    '    item.description = CStr(reader("datum"))
                    '    'End If
                    '    'item.description = CStr(reader("datum")) & " " & reader("besk") & " " & reader("beskrywing") & " ~ Gebruiker: " & reader("gebruiker")
                    'Else
                    '    If reader("beskengels") IsNot DBNull.Value Then
                    '        item.besk = Trim(reader("beskengels"))
                    '    Else
                    '        item.besk = ""
                    '    End If

                    '    ' item.besk = reader("beskengels")

                    '    'item.description = CStr(reader("datum")) & " " & reader("besk") & " " & reader("beskrywing") & " ~ User: " & reader("gebruiker")
                    'End If
                    If reader("besk") IsNot DBNull.Value Then
                        If Persoonl.TAAL = 0 Then ' afrikaans
                            item.category = Trim(reader("besk"))
                        Else
                            If reader("beskEngels") IsNot DBNull.Value Then
                                item.category = Trim(reader("beskEngels"))
                            Else
                                item.category = ""
                            End If
                        End If
                        ' Andriette 07/05/2013 Haal die dubbelpunt uit
                        If item.category.Length > 0 Then

                            If item.category.Substring(Len(item.category) - 1, 1) = ":" Then
                                item.category = item.category.Substring(0, Len(item.category) - 1)
                            End If
                        Else

                        End If
                    Else
                        item.category = ""
                    End If
                    If item.datum.ToString <> "" Then

                        'strDatum = item.datum.ToString.Substring(0, 10)
                        strDatum = item.datum.ToString
                        ' strDatumdele = item.datum.ToString.Split("/")
                        ' Andriette 22/03/2013 Wys die volle datum met die tyd ingesluit
                        ' item.description = strDatumdele(2).Substring(0, 4) & "/" & strDatumdele(1) & "/" & strDatumdele(0) & "      "
                        item.description = strDatum
                        If item.category <> "" Then
                            item.description = item.description & " " & item.category

                            If item.beskrywing <> "" Then
                                item.description = item.description & " " & item.beskrywing
                            End If
                        Else
                            If item.beskrywing <> "" Then
                                item.description = item.description & " " & item.beskrywing
                            End If
                        End If
                    Else
                        If item.category <> "" Then
                            item.description = item.description & " " & item.category

                            If item.beskrywing <> "" Then
                                item.description = item.description & " " & item.beskrywing
                            End If
                        Else
                            If item.beskrywing <> "" Then
                                item.description = item.description & " " & item.beskrywing
                            End If
                        End If
                    End If

                    If Persoonl.TAAL = 0 Then
                        If item.gebruiker <> "" Then
                            item.description = item.description & " - Gebruiker: " & item.gebruiker
                        End If
                    Else
                        If item.gebruiker <> "" Then
                            item.description = item.description & " - User: " & item.gebruiker
                        End If
                    End If
                    'If item.datum.ToString <> "" Then

                    '    strDatum = item.datum.ToString.Substring(0, 10)
                    '    strDatumdele = item.datum.ToString.Split("/")
                    '    item.description = strDatumdele(2).Substring(0, 4) & "/" & strDatumdele(1) & "/" & strDatumdele(0) & "      "
                    '    If item.besk <> "" Then
                    '        item.description = item.description & " " & item.besk
                    '        If item.beskrywing <> "" Then
                    '            item.description = item.description & " " & item.beskrywing
                    '            If item.gebruiker <> "" Then
                    '                item.description = item.description & " - Gebruiker: " & item.gebruiker
                    '            End If
                    '        Else
                    '            If item.gebruiker <> "" Then
                    '                item.description = item.description & " - Gebruiker: " & item.gebruiker
                    '            End If
                    '        End If
                    '    Else
                    '        If item.beskrywing <> "" Then
                    '            item.description = item.description & " " & item.beskrywing
                    '            If item.gebruiker <> "" Then
                    '                item.description = item.description & " - Gebruiker: " & item.gebruiker
                    '            End If
                    '        Else
                    '            If item.gebruiker <> "" Then
                    '                item.description = item.description & " - Gebruiker: " & item.gebruiker
                    '            End If
                    '        End If
                    '    End If

                    'Else
                    '    If item.besk <> "" Then
                    '        item.description = item.description & " " & item.besk
                    '        If item.beskrywing <> "" Then
                    '            item.description = item.description & " " & item.beskrywing
                    '            If item.gebruiker <> "" Then
                    '                item.description = item.description & " - Gebruiker: " & item.gebruiker
                    '            End If
                    '        Else
                    '            If item.gebruiker <> "" Then
                    '                item.description = item.description & " - Gebruiker: " & item.gebruiker
                    '            End If
                    '        End If
                    '    Else
                    '        If item.beskrywing <> "" Then
                    '            item.description = item.description & " " & item.beskrywing
                    '            If item.gebruiker <> "" Then
                    '                item.description = item.description & " - Gebruiker: " & item.gebruiker
                    '            End If
                    '        Else
                    '            If item.gebruiker <> "" Then
                    '                item.description = item.description & " - Gebruiker: " & item.gebruiker
                    '            End If
                    '        End If
                    '    End If
                    'End If
                    If Trim(StrConv(item.description, VbStrConv.Uppercase)) = "MOOIRIVIERDOTNET.WYSIGENTITY" Then
                        MsgBox(item.description)
                    End If
                    list.Add(item)
                End While
                Return list
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function
    'Andriette 02/08/2013 verander die entity
    'Function ListCellphone() As List(Of Cellphone)
    Function ListCellphone() As List(Of Selfoone)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@Polisno", SqlDbType.NVarChar)
                'Andriette 15/08/2013 verander na die global polisnommer
                ' param.Value = Form1.form1Polisno.Text
                param.Value = glbPolicyNumber
                If param.Value = Nothing Then
                    MsgBox("please allocate a policy number for the insured")
                    selfoonListFrm.Hide()
                    selfoonDetailFrm.Hide()
                    ' Andriette 07/03/2013 Maak warning reg
                    Return Nothing
                    Exit Function
                End If

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[insCELL].[InsCellDetails]", param)
                'Andriette 02/08/2013 verander na die ander selfoon entity
                ' Dim list As List(Of Cellphone) = New List(Of Cellphone)
                Dim List As List(Of Selfoone) = New List(Of Selfoone)
                While reader.Read()
                    'Andriette 02/08/2013 verander na die ander selfoon entity
                    ' Dim item As Cellphone = New Cellphone()
                    Dim item As Selfoone = New Selfoone()
                    If Not IsDBNull(reader("pkInsCell")) Then
                        'Andriette 02/08/2013 verander na die ander selfoon entity
                        'item.pkInsCell = reader("pkInsCell")
                        item.pkSelfoon = reader("pkInsCell")
                    End If
                    If Not IsDBNull(reader("Maak")) Then
                        'Andriette 02/08/2013 verander na die ander selfoon entity
                        '  item.Maak = reader("Maak")
                        item.Make = reader("Maak")
                    End If
                    If Not IsDBNull(reader("Model")) Then
                        item.Model = reader("Model")
                    End If
                    If Not IsDBNull(reader("SerieNo")) Then
                        item.SerialNo = reader("SerieNo")
                    End If
                    If Not IsDBNull(reader("Sel_tel")) Then
                        item.Nommer = reader("Sel_tel")
                    End If
                    If Not IsDBNull(reader("Kotrak")) Then
                        'Andriette 02/08/2013 verander die entity
                        'item.Kotrak = reader("Kotrak")
                        item.Kontrak = reader("Kotrak")
                    End If
                    If Not IsDBNull(reader("Waarde")) Then
                        item.Waarde = reader("Waarde")
                    End If
                    If Not IsDBNull(reader("Premie")) Then
                        'Andriette 01/08/2013 verander die format
                        item.Premie = FormatNumber(reader("Premie"), 2)
                    End If
                    If Not IsDBNull(reader("status")) Then
                        item.Status = reader("status")
                    End If
                    If Not IsDBNull(reader("Kanselleer")) Then
                        item.Kanselleer = reader("Kanselleer")
                    End If
                    If Not IsDBNull(reader("Rede")) Then
                        'Andriette 02/08/2013 verander die entiry
                        'item.Rese = reader("Rede")
                        item.Rede = reader("Rede")
                    End If
                    List.Add(item)
                End While
                Return List
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'BaseForm
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Name = "BaseForm"
        Me.ResumeLayout(False)

    End Sub

    Function ListBankCodes() As List(Of BankCodes)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim param() As SqlParameter = {New SqlParameter("@bankname", SqlDbType.NVarChar), _
                                               New SqlParameter("@branchName", SqlDbType.NVarChar), _
                                               New SqlParameter("@branchCode", SqlDbType.NVarChar), _
                                               New SqlParameter("@type", SqlDbType.NVarChar)}

                If BnkCodes.txtBank.Text = "" Then
                    param(0).Value = DBNull.Value
                Else
                    param(0).Value = BnkCodes.txtBank.Text
                End If

                If BnkCodes.txtBranch.Text = "" Then
                    param(1).Value = DBNull.Value
                Else
                    param(1).Value = BnkCodes.txtBranch.Text
                End If

                If BnkCodes.txtCode.Text = "" Then
                    param(2).Value = DBNull.Value
                Else
                    param(2).Value = BnkCodes.txtCode.Text
                End If

                If BnkCodes.cmbBnkType.SelectedItem = "" Then
                    param(3).Value = DBNull.Value
                Else
                    param(3).Value = BnkCodes.cmbBnkType.SelectedItem
                End If

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.BankCodesProc", param)

                Dim list As List(Of BankCodes) = New List(Of BankCodes)
                While reader.Read()
                    Dim item As BankCodes = New BankCodes()

                    If Not IsDBNull(reader("pkBankCodes")) Then
                        item.pkBankCodes = reader("pkBankCodes")
                    End If

                    If Not IsDBNull(reader("Bank")) Then
                        item.Bankname = reader("Bank")
                    End If

                    If Not IsDBNull(reader("Tak")) Then
                        item.BranchName = reader("Tak")
                    End If

                    If Not IsDBNull(reader("Takkode")) Then
                        item.BranchCode = reader("Takkode")
                    End If

                    If Not IsDBNull(reader("Type")) Then
                        item.type = reader("Type")
                    End If
                    list.Add(item)
                End While
                Return list
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function


    Private Sub BaseForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not (blnByvoeg Or blnpol_byvoeg) Then
            blnSavedNew = True
        End If
    End Sub

    'Andriette 23/05/2014 voeg 'n opsionele polisnommer parameter by om te gebruik as die wysiging nie op die global polisnommer se rekord moet verskyn nie
    Function UpdateWysig(ByVal kode As String, ByVal beskrywing As String, Optional ByVal strPolisnommer As String = "")
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                Dim param() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@kode", SqlDbType.NVarChar), _
                                                 New SqlParameter("@datum", SqlDbType.DateTime), _
                                                 New SqlParameter("@versekerde", SqlDbType.NVarChar), _
                                                New SqlParameter("@voorl", SqlDbType.NVarChar), _
                                                New SqlParameter("@gebruiker", SqlDbType.NVarChar), _
                                                New SqlParameter("@beskrywing", SqlDbType.NVarChar)}
                'Andriette 15/08/2013 verander na die global polisnommer
                'param(0).Value = Form1.form1Polisno.Text
                If strPolisnommer = "" Then
                    param(0).Value = glbPolicyNumber
                Else
                    param(0).Value = strPolisnommer
                End If

                param(1).Value = kode
                param(2).Value = Now()
                param(3).Value = Form1.txtForm1Versekerde.Text
                param(4).Value = Form1.txtForm1Voorl.Text
                param(5).Value = Gebruiker.Naam
                param(6).Value = beskrywing

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateWysig", param)

                Return True
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function

    Public Sub gen_getTermPolicyStatus(ByVal POLISNO As String)

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@Polisno", SqlDbType.NVarChar)
                param.Value = POLISNO
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.ListLangtermynPolis", param)
                If reader.HasRows Then
                    EntLangtermynpolis = New LangtermynPolis

                    Do While reader.Read()
                        EntLangtermynpolis.DatumBegin = reader("DatumBegin")
                        EntLangtermynpolis.DatumEindig = reader("DatumEindig")
                        EntLangtermynpolis.Tydperk = reader("Tydperk")
                        strTermDesc = entLangtermynpolis.DatumBegin & " - " & entLangtermynpolis.DatumEindig
                        If Now() > reader("DatumBegin") And Now() <= reader("DatumEindig") Then
                            strTermStatusDesc = "Active"
                            strTermStatus = 1
                            '  EntLangtermynpolis.strStatus = 1
                            ' EntLangtermynpolis.strTermynDesc = dateStart & " - " & dateEnd
                            '  EntLangtermynpolis.strStatusDesc = "Active"
                        ElseIf Now() < reader("datumBegin") Then 'Term not active yet
                            strTermStatusDesc = "Inactive"
                            strTermStatus = 2
                            '  EntLangtermynpolis.strStatus = 2
                            '  EntLangtermynpolis.strTermynDesc = 
                            '  EntLangtermynpolis.strStatusDesc = "Inactive"
                        ElseIf Now() > reader("DatumEindig") Then 'Term expired
                            strTermStatusDesc = "Expired"
                            strTermStatus = 3
                            '   EntLangtermynpolis.strStatus = 3
                            '   EntLangtermynpolis.strStatusDesc = "Expired"
                            '   EntLangtermynpolis.strTermynDesc = dateStart & " - " & dateEnd
                        End If
                    Loop
                Else
                    'No term exists for this policy
                    'EntLangtermynpolis.Tydperk = 1
                    'EntLangtermynpolis.strStatus = 4
                    'EntLangtermynpolis.strTermynDesc = "No term available"
                    'EntLangtermynpolis.strStatusDesc = "Unknown"
                    strTermStatusDesc = "Unknown"
                    strTermStatus = 4
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
            'Form1.lbltermynperiode.Text = TermDesc
            'Form1.lblTermynStatus.Text = StatusDesc
            'Form1.lbltermynmaande.Text = CStr(Months)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    'Description: Update the Insure Cell file (finrite.txt) with records altered Populate arguments with record values to update file
    Public Sub cellphoneUpdateInsCellFile(ByVal dblcert_no As Double, ByVal strpolicy_no As String, ByVal strStatus As String, ByVal dtecancel_date As Date, ByVal strcancel_comment As String, ByVal strcust_surname As String, ByVal strcust_inititials As String, ByVal strcust_id_number As String, ByVal dtecontract_date As Date, ByVal strphone_make As String, ByVal strphone_model As String, ByVal strphone_price As Single, ByVal strsn_no As String, ByVal stre_mail_address As String, ByVal strcellular_number As String, ByVal dblpremium As Double, ByVal strbranch As String)
        Dim strcancel_date_tmp As String
        Dim strcontract_date_tmp As String
        Dim w As StreamWriter = File.AppendText("finrite.txt")
        Try
            'Open pol_path + "\finrite.txt" For Append As #1

            'Format dates to correct format(according to finrite standard)
            strcancel_date_tmp = CStr(Format(dtecancel_date, "yyyymmdd"))
            strcontract_date_tmp = CStr(Format(dtecontract_date, "yyyymmdd"))

            If strcancel_date_tmp = "19000101" Then
                strcancel_date_tmp = ""
            End If

            'if not a valid email address - return blank
            If InStr(1, stre_mail_address, "@") = 0 Then
                stre_mail_address = ""
            End If

            'Write record
            w.WriteLine(dblcert_no, strpolicy_no, strTermStatus, strcancel_date_tmp, strcancel_comment, strcust_surname, strcust_inititials, strcust_id_number, strcontract_date_tmp, strphone_make, strphone_model, strphone_price, strsn_no, stre_mail_address, strcellular_number, dblpremium, (Trim(strbranch)), 20)

            w.Close()
        Catch ex As Exception
        End Try
    End Sub

    Function ListGebruikerForWysigDropdown() As List(Of String)
        Dim param As New SqlParameter("@BranchCode", SqlDbType.NVarChar)

        If Gebruiker.titel = "Programmeerder" Then
            param.Value = ""
        Else
            param.Value = Gebruiker.BranchCodes
        End If

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.ReportFetchGebruiker", param)
                Dim list As List(Of String) = New List(Of String)

                While reader.Read()
                    Dim item As GebruikersEntity = New GebruikersEntity()
                    If reader("Gebruiker") IsNot DBNull.Value Then
                        item.Naam = reader("Gebruiker")
                    End If

                    list.Add(item.Naam)
                End While
                Return list
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function
    'Andriette 14/08/2014 haal die kontant vorm uit die projek
    'Function ListMonthlyCash() As List(Of M_KontantEntity)
    '    Dim param As New SqlParameter("@Polisno", SqlDbType.NVarChar)

    '    param.Value = Kontant.Polisno.Text

    '    Try
    '        Using conn As SqlConnection = SqlHelper.GetConnection

    '            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMonthlyCash]", param)
    '            Dim list As List(Of M_KontantEntity) = New List(Of M_KontantEntity)

    '            While reader.Read()
    '                Dim item As M_KontantEntity = New M_KontantEntity()
    '                If reader("mkTrans_dat") IsNot DBNull.Value Then
    '                    item.mkTrans_dat = reader("mkTrans_dat")
    '                End If

    '                If reader("Ingevorder") IsNot DBNull.Value Then
    '                    item.Ingevorder = reader("Ingevorder")
    '                End If

    '                If reader("kwit_boek") IsNot DBNull.Value Then
    '                    item.kwit_boek = reader("kwit_boek")
    '                End If

    '                If reader("Vord_dat") IsNot DBNull.Value Then
    '                    item.Vord_dat = reader("Vord_dat")
    '                End If

    '                If reader("trans_dat") IsNot DBNull.Value Then
    '                    item.trans_dat = reader("trans_dat")
    '                End If


    '                list.Add(item)
    '            End While
    '            Return list
    '            If conn.State = ConnectionState.Open Then
    '                conn.Open()
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        Return Nothing
    '    End Try

    'End Function

    Function ListWysigDescr() As List(Of WysigEntity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim param() As SqlParameter = {New SqlParameter("@kode", SqlDbType.NVarChar), _
                                                New SqlParameter("@besk", SqlDbType.NVarChar)}
                If frmLysDatumWysig.txtKode.Text = "" Then
                    param(0).Value = DBNull.Value
                Else
                    param(0).Value = frmLysDatumWysig.txtKode.Text
                End If

                If frmLysDatumWysig.txtBeskrywing.Text = "" Then
                    param(1).Value = DBNull.Value
                Else
                    param(1).Value = frmLysDatumWysig.txtBeskrywing.Text
                End If

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.ReportKodeProc", param)

                Dim list As List(Of WysigEntity) = New List(Of WysigEntity)
                While reader.Read()
                    Dim item As WysigEntity = New WysigEntity()

                    If Not IsDBNull(reader("kode")) Then
                        item.kode = reader("kode")
                    End If
                    If Not IsDBNull(reader("besk")) Then
                        item.besk = reader("besk")
                    End If
                    list.Add(item)
                End While
                Return list
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function

    Public Function gen_getBemarker(ByVal strCode As String) As String
        gen_getBemarker = ""
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchBemarker")

                If reader.Read Then
                    gen_getBemarker = reader("naam")
                Else
                    gen_getBemarker = ""
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Function

    Public Function gen_getVehicleUse(ByVal language As Byte, ByVal useCode As String) As String

        If language = 0 Then
            Select Case useCode
                Case "1"
                    gen_getVehicleUse = "Privaat"
                Case "2"
                    gen_getVehicleUse = "Professioneel"
                Case "3"
                    gen_getVehicleUse = "Professioneel"
                Case Else
                    gen_getVehicleUse = "Ongeldige gebruik kode"
            End Select
        Else
            Select Case useCode
                Case "1"
                    gen_getVehicleUse = "Private"
                Case "2"
                    gen_getVehicleUse = "Professional"
                Case "3"
                    gen_getVehicleUse = "Professional"
                Case Else
                    gen_getVehicleUse = "Invalid use code"
            End Select
        End If

    End Function

    '* Purpose    : Insert the month end record for policy in stat5d.mdb
    '* Inputs     : Policy number, month-end date, payment method

    Public Sub gen_insertMonthEndRecord(ByVal strPolicy As String, ByVal datMonthEnd As Date, ByVal strBetWyse As String)
        Try
            Dim strHeHb As String
            'Add 'PERSOONL' fields
            'Print_dat
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                     New SqlParameter("@Afsluit_dat", SqlDbType.NVarChar), _
                                     New SqlParameter("@afsluitdatum", SqlDbType.DateTime), _
                                     New SqlParameter("@bemarker", SqlDbType.NVarChar), _
                                     New SqlParameter("@PLIP1", SqlDbType.Money), _
                                     New SqlParameter("@Area", SqlDbType.NVarChar), _
                                     New SqlParameter("@BET_WYSE", SqlDbType.NVarChar), _
                                     New SqlParameter("@Voertuie", SqlDbType.Bit)}
                'Andriette 15/08/2013 verander na die parameter wat in elke geval gestuur word
                'params(0).Value = Persoonl.POLISNO
                params(0).Value = strPolicy
                params(1).Value = CStr(datMonthEnd)
                params(2).Value = datMonthEnd
                params(3).Value = gen_getBemarker(Persoonl.VANWIE)

                If IsDBNull(Persoonl.PLIP1) Then
                    params(4).Value = 0
                Else
                    params(4).Value = (Format(Persoonl.PLIP1, "0.00"))
                End If

                params(5).Value = gen_getAreaDesc(Persoonl.Area)
                params(6).Value = strBetWyse
                params(7).Value = False

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Stats5d.UpdateMD_PRINT_DAT_WITH_PERSOONL", params)
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using

            'Print2_dat
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@Afsluit_dat", SqlDbType.NVarChar), _
                                                New SqlParameter("@afsluitdatum", SqlDbType.DateTime), _
                                                New SqlParameter("@ongespesifiseerd", SqlDbType.Money), _
                                                New SqlParameter("@ongevalle", SqlDbType.Money), _
                                                New SqlParameter("@AddisionelePremie", SqlDbType.Money), _
                                                New SqlParameter("@PersoonlAddisionelePremie", SqlDbType.Money)}
                'Andriette 15/08/2013 gebruik die parameter wat in elke geval gestuur word
                'params(0).Value = Persoonl.POLISNO
                params(0).Value = strPolicy
                params(1).Value = CStr(datMonthEnd)
                params(2).Value = datMonthEnd
                params(3).Value = 2000
                params(4).Value = 8000
                'Andriette 15/082013 verander na die parameter wat in elke geval gestuur word
                'params(5).Value = gen_getAdditionalPremium(Persoonl.POLISNO)
                params(5).Value = gen_getAdditionalPremium(strPolicy)
                params(6).Value = params(5).Value

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Stats5d.UpdateMD_PRINT2_DAT_WITH_PERSOONL", params)
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using

            'Insert VOERTUIE records:
            'Print_dat
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@gebruik", SqlDbType.NVarChar), _
                                                New SqlParameter("@motorsek", SqlDbType.DateTime), _
                                                New SqlParameter("@TIPE", SqlDbType.NVarChar), _
                                                New SqlParameter("@VOERTUIE", SqlDbType.Bit)}
                ' Dim item As New EntityVoertuie
                Dim item As New VoertuieEntity
                'Andriette 15/08/2013 gebruik die parameter wat in elke geval gestuur word
                'params(0).Value = Persoonl.POLISNO
                params(0).Value = strPolicy
                params(1).Value = gen_getVehicleUse(Persoonl.TAAL, item.gebruik)
                params(2).Value = ""
                params(3).Value = gen_getVehicleUse(Persoonl.TAAL, item.tipe_dek)
                params(4).Value = 8000

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Stats5d.InsertMD_PRINT2_DAT_WITH_VOERTUIE", params)
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using

            'Print2_dat
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                params.Value = Persoonl.POLISNO

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Stats5d.InsertMD_PRINT2_DAT_WITH_VOERTUIE", params)
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using

            'Insert PROPERTY records into Print2_dat
            'HE
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@hehb", SqlDbType.NVarChar), _
                                                New SqlParameter("@huissek", SqlDbType.DateTime), _
                                                New SqlParameter("@Huissekuriteit", SqlDbType.NVarChar), _
                                                New SqlParameter("@Huistipe", SqlDbType.NVarChar)}

                'Andriette 15/08/2013 verander na die polisnommer wat in elke geval gestuur word
                'params(0).Value = Persoonl.POLISNO
                params(0).Value = strPolicy
                params(1).Value = "HE"
                params(2).Value = ""
                params(3).Value = "0"

                huis = New HuisEntity
                If huis.WAARDE_HE <> 0 Then
                    If Persoonl.TAAL = 0 Then
                        strHeHb = "Huiseienaar"
                    Else
                        strHeHb = "Homeowner"
                    End If
                    params(4).Value = strHeHb

                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Stats5d.InsertMD_PRINT2_DAT_WITH_HUIS_HE", params)
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using

            'HB
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@hehb", SqlDbType.NVarChar), _
                                                New SqlParameter("@huissek", SqlDbType.DateTime), _
                                                New SqlParameter("@Huissekuriteit", SqlDbType.NVarChar), _
                                                New SqlParameter("@Huistipe", SqlDbType.NVarChar)}
                'Andriette 15/08/2013 gebruik die parameter wat in elke geval gestuur word
                'params(0).Value = Persoonl.POLISNO
                params(0).Value = strPolicy
                params(1).Value = "HB"
                params(2).Value = ""
                params(3).Value = "0"

                huis = New HuisEntity
                If huis.WAARDE_HB <> 0 Then
                    If Persoonl.TAAL = 0 Then
                        strHeHb = "Huiseienaar"
                    Else
                        strHeHb = "Homeowner"
                    End If
                    params(4).Value = strHeHb

                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Stats5d.InsertMD_PRINT2_DAT_WITH_HUIS_HB", params)
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using

            'Insert ALL RISK records
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@bet_wyse", SqlDbType.NVarChar), _
                                                New SqlParameter("@Afsluit_dat", SqlDbType.DateTime), _
                                                New SqlParameter("@afsluitdatum", SqlDbType.DateTime)}
                'Andriette 15/08/2013 gebruik die parameter wat in elke geval gestuur word
                'params(0).Value = Persoonl.POLISNO
                params(0).Value = strPolicy
                params(1).Value = strBetWyse
                params(2).Value = CStr(datMonthEnd)
                params(3).Value = datMonthEnd

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Stats5d.InsertMD_PRINT_ALLE_WITH_ALLERISK", params)
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
        End Try

    End Sub

    Public Function gen_getAdditionalPremium(ByVal policyNumber As String) As Double
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params As New SqlParameter("@Polisno", SqlDbType.NVarChar)
                'Andriette 15/08/2013 gebruik die parameter wat in elke geval gestuur word
                'params.Value = Form1.form1Polisno.Text
                params.Value = policyNumber

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchAdditionalPrimie]", params)

                If reader.Read() Then
                    If Not IsDBNull(reader("Totaal")) Then
                        gen_getAdditionalPremium = CDbl(reader("Totaal"))
                    Else
                        gen_getAdditionalPremium = 0
                    End If
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function getAdditionalPremium() As Double
        'If IsNothing(Persoonl) Then
        '    Exit Function
        'Else
        '    If Persoonl.POLISNO = "" Then
        '        Exit Function
        '    End If
        'End If
        'Persoonl = FetchPersoonl()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params As New SqlParameter("@Polisno", SqlDbType.NVarChar)
                params.Value = Persoonl.POLISNO
                If params.Value = Nothing Then
                    params.Value = ""
                Else
                    params.Value = Persoonl.POLISNO
                End If
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAddisionalPrieme", params)
                If Persoonl.POLISNO <> "" And Not IsDBNull(Persoonl.POLISNO) Then
                    If reader.Read Then
                        getAdditionalPremium = Format(CDbl(reader("Totaal")), "0.00")
                    Else
                        getAdditionalPremium = 0
                    End If
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    'Public Function gen_WarningsOnCancelorRemove(ByVal strPolisno As String, ByVal strCheckType As enumCheckType, Optional ByVal strItemType As enumItemType = enumItemType.enum_Property, Optional ByVal lngPkItem As Long = 0) As Boolean
    Public Function gen_WarningsOnCancelorRemove(ByVal strPolisno As String, ByVal strCheckType As String, Optional ByVal strItemType As String = "", Optional ByVal lngPkItem As Long = 0) As Boolean
        Dim strMessage As String = ""
        Dim intCount As Integer = 0

        'Policy was cancelled
        If strCheckType = enumCheckType.PolicyCancelled Then
            'Get all the items that have a bond or are financed
            Try
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                    param.Value = Persoonl.POLISNO

                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchWarningonCancel]", param)
                    ' Andriette 13/05/2013 verander die reader se toets
                    'If reader.HasRows > 0 Then
                    If reader.HasRows = True Then
                        strMessage = "The interest of the Hire purchase Institution/Bank may be compromised when the policy is cancelled." & Chr(10) & Chr(10)
                        'strMessage = "Die belange van die Huurkoopinstansie/Bank van die volgende items kan benadeel word wanneer hierdie polis gekanselleer word." & Chr(10) & Chr(10)
                        Do While reader.Read()
                            intCount = intCount + 1
                            strMessage = strMessage & intCount & ". " & reader(0) & ": " & StrConv(reader(1), vbProperCase) & ", " & StrConv(reader(2), vbProperCase) & ", " & reader(3) & Chr(10)
                        Loop
                        strMessage = strMessage & Chr(10) & "It is therefore imperative to print a Notification (Printouts/Suspension of cover notice) and send it to the concerned party."
                        strMessage = strMessage & Chr(10) & "Are you sure you would like to continue to cancel the policy without printing the notice?"
                        If MsgBox(strMessage, vbYesNo) = vbYes Then
                            gen_WarningsOnCancelorRemove = True
                        Else
                            gen_WarningsOnCancelorRemove = False
                        End If
                    Else
                        'No items exists with bond etc.
                        gen_WarningsOnCancelorRemove = True
                    End If
                    If conn.State = ConnectionState.Open Then
                        conn.Open()
                    End If
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Return Nothing
            End Try
        End If

        'Item removed
        If strCheckType = enumCheckType.ItemRemoved Then
            Try
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim params() As SqlParameter = {New SqlParameter("@strItemType", SqlDbType.Int), _
                                           New SqlParameter("@lngPkItem", SqlDbType.NVarChar)}
                    If strItemType = enumItemType.enum_Vehicle Then
                        params(0).Value = 0
                        params(1).Value = lngPkItem
                    ElseIf strItemType = enumItemType.enum_Property Then
                        params(0).Value = 1
                        params(1).Value = lngPkItem

                    End If

                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchWarningonCancelItemType]", params)

                    If reader.HasRows Then
                        'No item with bond etc.
                        strMessage = "The interest of the Hire purchase Institution/Bank may be compromised when this item is cancelled." & Chr(10) & Chr(10)
                        'Andriette 11/09/2013 haal dit uit as 'n item gekanseleer word
                        'Do While reader.Read
                        '    intCount = intCount + 1
                        '    strMessage = strMessage & intCount & ". " & reader("N_Plaat") & Chr(10)
                        'Loop
                        strMessage = strMessage & Chr(10) & "It is therefore imperative to print a Notification (Printouts/Suspension of cover notice) and send it to the concerned party."
                        strMessage = strMessage & Chr(10) & "Are you sure you would still like to continue to cancel the item?"

                        If MsgBox(strMessage, vbYesNo) = vbYes Then
                            gen_WarningsOnCancelorRemove = True
                        Else
                            gen_WarningsOnCancelorRemove = False
                        End If
                    Else
                        gen_WarningsOnCancelorRemove = False
                    End If
                    If conn.State = ConnectionState.Open Then
                        conn.Open()
                    End If
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Return Nothing
            End Try

        End If
    End Function
    'Public Function FetchvoertuieWithPrimaryKey() As VoertuieEntity
    '    Dim item As VoertuieEntity = New VoertuieEntity()
    '    Try
    '        Using conn As SqlConnection = SqlHelper.GetConnection
    '            Dim param As New SqlParameter("@pkVoertuie", SqlDbType.Int)
    '            param.Value = lngPkItem

    '            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchvoertuieWithPrimaryKey", param)

    '            If reader.Read() Then
    '                If reader("ANDER") IsNot DBNull.Value Then
    '                    item.ANDER = reader("ANDER")
    '                End If
    '                If reader("CourtesyVehAmount") IsNot DBNull.Value Then
    '                    item.CourtesyVehAmount = reader("CourtesyVehAmount")
    '                End If
    '                If reader("enjinnommer") IsNot DBNull.Value Then
    '                    item.enjinnommer = reader("enjinnommer")
    '                End If
    '                If reader("GEBRUIK") IsNot DBNull.Value Then
    '                    item.GEBRUIK = reader("GEBRUIK")
    '                End If
    '                If reader("huurinstansie") IsNot DBNull.Value Then
    '                    item.huurinstansie = reader("huurinstansie")
    '                End If
    '                If reader("kilometerlesing") IsNot DBNull.Value Then
    '                    item.kilometerlesing = reader("kilometerlesing")
    '                End If
    '                If reader("kleur") IsNot DBNull.Value Then
    '                    item.kleur = reader("kleur")
    '                End If
    '                If reader("N_PLAAT") IsNot DBNull.Value Then
    '                    item.N_PLAAT = reader("N_PLAAT")
    '                End If
    '                If reader("onderstelnommer") IsNot DBNull.Value Then
    '                    item.onderstelnommer = reader("onderstelnommer")
    '                End If
    '                If reader("PREMIE") IsNot DBNull.Value Then
    '                    item.PREMIE = reader("PREMIE")
    '                End If
    '                If reader("Poskode") IsNot DBNull.Value Then
    '                    item.Poskode = reader("Poskode")
    '                End If
    '                If reader("TIPE_DEK") IsNot DBNull.Value Then
    '                    item.TIPE_DEK = reader("TIPE_DEK")
    '                End If
    '                If reader("SekuriteitBitValue") IsNot DBNull.Value Then
    '                    item.SekuriteitBitValue = reader("SekuriteitBitValue")
    '                End If
    '                If reader("vssratingbesk") IsNot DBNull.Value Then
    '                    item.vssratingbesk = reader("vssratingbesk")
    '                End If
    '                If reader("vssratingjn") IsNot DBNull.Value Then
    '                    item.vssratingjn = reader("vssratingjn")
    '                End If

    '                If reader("PremiePersentasie") IsNot DBNull.Value Then
    '                    item.PremiePersentasie = reader("PremiePersentasie")
    '                End If
    '                If reader("WAARDE") IsNot DBNull.Value Then
    '                    item.WAARDE = reader("WAARDE")
    '                End If

    '                If reader("huurnommer") IsNot DBNull.Value Then
    '                    item.huurnommer = reader("huurnommer")
    '                End If
    '                If reader("Huurkoop") IsNot DBNull.Value Then
    '                    item.Huurkoop = reader("Huurkoop")
    '                End If
    '                If reader("Voorstad") IsNot DBNull.Value Then
    '                    item.Voorstad = reader("Voorstad")
    '                End If
    '                If reader("WaardeEkstras") IsNot DBNull.Value Then
    '                    item.WaardeEkstras = reader("WaardeEkstras")
    '                End If
    '                item.NoMatch = False
    '            Else
    '                item.NoMatch = True
    '            End If
    '            If conn.State = ConnectionState.Open Then
    '                conn.Open()
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        Return Nothing
    '    End Try
    '    Return item
    'End Function

    'Public Function FetchHuisWithVerband() As HuisEntity
    '    Dim item As HuisEntity = New HuisEntity()
    '    Try
    '        Using conn As SqlConnection = SqlHelper.GetConnection
    '            Dim param As New SqlParameter("@pkHuis", SqlDbType.Int)
    '            param.Value = lngPkItem
    '            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchHuisWithVerband", param)

    '            While reader.Read()

    '                If reader("ADRES_H1") IsNot DBNull.Value Then
    '                    item.ADRES_H1 = reader("ADRES_H1")
    '                End If
    '                If reader("Adres4") IsNot DBNull.Value Then
    '                    item.Adres4 = reader("Adres4")
    '                End If
    '                If reader("WAARDE_HB") IsNot DBNull.Value Then
    '                    item.WAARDE_HB = reader("WAARDE_HB")
    '                End If
    '                If reader("WAARDE_HE") IsNot DBNull.Value Then
    '                    item.WAARDE_HE = reader("WAARDE_HE")
    '                End If
    '                If reader("voorstad") IsNot DBNull.Value Then
    '                    item.voorstad = reader("voorstad")
    '                End If
    '                If reader("SekuriteitBitValue") IsNot DBNull.Value Then
    '                    item.SekuriteitBitValue = reader("SekuriteitBitValue")
    '                End If
    '                If reader("eem_premie") IsNot DBNull.Value Then
    '                    item.eem_premie = reader("eem_premie")
    '                End If
    '                If reader("eem_waarde") IsNot DBNull.Value Then
    '                    item.eem_waarde = reader("eem_waarde")
    '                End If
    '                If reader("mainproperty") IsNot DBNull.Value Then
    '                    item.mainproperty = reader("mainproperty")
    '                End If
    '                If reader("pkHuis") IsNot DBNull.Value Then
    '                    item.pkHuis = reader("pkHuis")
    '                End If
    '                If reader("PREMIE_HE") IsNot DBNull.Value Then
    '                    item.PREMIE_HE = reader("PREMIE_HE")
    '                End If
    '                If reader("SekuriteitBitValue") IsNot DBNull.Value Then
    '                    item.SekuriteitBitValue = reader("SekuriteitBitValue")
    '                End If
    '                If reader("STRUKTUUR") IsNot DBNull.Value Then
    '                    item.STRUKTUUR = reader("STRUKTUUR")
    '                End If
    '                If reader("TIPE_DAK") IsNot DBNull.Value Then
    '                    item.TIPE_DAK = reader("TIPE_DAK")
    '                End If
    '                If reader("toe_premie") IsNot DBNull.Value Then
    '                    item.toe_premie = reader("toe_premie")
    '                End If
    '                If reader("toe_waarde") IsNot DBNull.Value Then
    '                    item.toe_waarde = reader("toe_waarde")
    '                End If
    '                If reader("PREMIE_HB") IsNot DBNull.Value Then
    '                    item.PREMIE_HB = reader("PREMIE_HB")
    '                End If
    '                If reader("sekuriteit") IsNot DBNull.Value Then
    '                    item.sekuriteit = reader("sekuriteit")
    '                End If
    '                If reader("verband") IsNot DBNull.Value Then
    '                    item.Verband = reader("verband")
    '                End If
    '            End While
    '            Return item
    '            If conn.State = ConnectionState.Open Then
    '                conn.Open()
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        Return Nothing
    '    End Try

    'End Function


    Public Function gen_getVehicleCoverAbbr(ByVal language As Byte, ByVal coverCode As String) As String

        If language = 0 Then
            Select Case coverCode
                Case "1"
                    gen_getVehicleCoverAbbr = "Omv"
                Case "2"
                    gen_getVehicleCoverAbbr = "BD&D"
                Case "3"
                    gen_getVehicleCoverAbbr = "DP"
                Case Else
                    gen_getVehicleCoverAbbr = "Ongeldig"
            End Select
        Else
            Select Case coverCode
                Case "1"
                    gen_getVehicleCoverAbbr = "COMP"
                Case "2"
                    gen_getVehicleCoverAbbr = "BT&T"
                Case "3"
                    gen_getVehicleCoverAbbr = "TP"
                Case Else
                    gen_getVehicleCoverAbbr = "Invalid"
            End Select
        End If

    End Function

    Public Function gen_getAreaDesc(ByVal strCode As String) As String

        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim params As New SqlParameter("@Area", SqlDbType.NVarChar)
            params.Value = strCode
            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchArea", params)

            If reader.Read Then
                gen_getAreaDesc = reader("AREA_BESK")
            Else
                gen_getAreaDesc = ""
            End If
            If conn.State = ConnectionState.Open Then
                conn.Open()
            End If
        End Using

    End Function

    Public Function getAreaCode(ByRef areaDesc As String) As String

        Dim params As New SqlParameter("@AREA_BESK", SqlDbType.NVarChar)
        params.Value = areaDesc

        If areaDesc <> "" Then
            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAreaCode", params)
            If reader.Read Then
                getAreaCode = reader("Area_kode")
            Else
                getAreaCode = ""
            End If
        Else
            getAreaCode = ""
        End If
    End Function


    Public Sub updatePersoonl()
        'Andriette 03/03/2014 voeg nog 'n parameter by die stored procedure by
        'Andriette 03/03/2014 haal die fetch uit, dit is nie nodig vir die opdatering van die velde nie
        '  Persoonl = FetchPersoonl()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@BEGRAFNIS", SqlDbType.Money), _
                                                New SqlParameter("@MEDIES", SqlDbType.Money), _
                                                New SqlParameter("@TV_DIENS", SqlDbType.Money), _
                                                New SqlParameter("@BESKERM", SqlDbType.Money), _
                                                New SqlParameter("@SASPREM", SqlDbType.Money), _
                                                New SqlParameter("@PLIP1", SqlDbType.Money), _
                                                New SqlParameter("@WN_POLIS", SqlDbType.Money), _
                                                New SqlParameter("@courtesyv", SqlDbType.Money), _
                                                New SqlParameter("@careassist", SqlDbType.Money), _
                                                New SqlParameter("@epc", SqlDbType.Money), _
                                                New SqlParameter("@selfoon", SqlDbType.Money), _
                                                New SqlParameter("@PREMIE", SqlDbType.Money), _
                                                New SqlParameter("@NEWPREMIE", SqlDbType.Money), _
                                                New SqlParameter("@SUBTOTAAL", SqlDbType.Money), _
                                                New SqlParameter("@MOTOR_SUB", SqlDbType.Money), _
                                                New SqlParameter("@HUIS_SUB", SqlDbType.Money), _
                                                New SqlParameter("@ALLE_SUB", SqlDbType.Money), _
                                                New SqlParameter("@PREMIE2", SqlDbType.Money)}


                If IsDBNull(Persoonl.POLISNO) Then
                    params(0).Value = DBNull.Value
                Else
                    'Andriette 15/08/2013 verander na die global polisnommer
                    '   params(0).Value = Form1.form1Polisno.Text
                    params(0).Value = glbPolicyNumber
                End If

                If IsDBNull(Persoonl.BEGRAFNIS) Then
                    params(1).Value = "0"
                Else
                    params(1).Value = Persoonl.BEGRAFNIS
                    If params(1).Value = Nothing Then
                        params(1).Value = "0"
                    Else
                        params(1).Value = Persoonl.BEGRAFNIS
                    End If
                End If

                If IsDBNull(Persoonl.MEDIES) Then
                    params(2).Value = "0"
                Else
                    params(2).Value = Persoonl.MEDIES
                    If params(2).Value = Nothing Then
                        params(2).Value = "0"
                    Else
                        params(2).Value = Persoonl.MEDIES
                    End If
                End If

                If IsDBNull(Persoonl.TV_DIENS) Then
                    params(3).Value = "0"
                Else
                    params(3).Value = Persoonl.TV_DIENS
                    If params(3).Value = Nothing Then
                        params(3).Value = "0"
                    Else
                        params(3).Value = Persoonl.TV_DIENS
                    End If
                End If

                If IsDBNull(Persoonl.BESKERM) Then
                    params(4).Value = "0"
                Else
                    params(4).Value = Persoonl.BESKERM
                    If params(4).Value = Nothing Then
                        params(4).Value = "0"
                    Else
                        params(4).Value = Persoonl.BESKERM
                    End If
                End If
                If IsDBNull(Persoonl.SASPREM) Then
                    params(5).Value = "0"
                Else
                    params(5).Value = Persoonl.SASPREM
                    If params(5).Value = Nothing Then
                        params(5).Value = "0"
                    Else
                        params(5).Value = Persoonl.SASPREM
                    End If
                End If
                If IsDBNull(Persoonl.PLIP1) Then
                    params(6).Value = "0"
                Else
                    params(6).Value = Form1.cmbForm1Plip2.Text
                    If params(6).Value = Nothing Then
                        params(6).Value = "0"
                    Else
                        params(6).Value = Form1.cmbForm1Plip2.Text
                    End If
                End If
                If IsDBNull(Persoonl.WN_POLIS) Then
                    params(7).Value = 0
                Else
                    params(7).Value = Persoonl.WN_POLIS
                    If params(7).Value = Nothing Then
                        params(7).Value = 0
                    Else
                        params(7).Value = Persoonl.WN_POLIS
                    End If
                End If

                If IsDBNull(Persoonl.courtesyv) Then
                    params(8).Value = Format(0, "0.00")
                Else
                    params(8).Value = Persoonl.courtesyv
                    If params(8).Value = Nothing Then
                        params(8).Value = Format(0, "0.00")
                    Else
                        params(8).Value = Persoonl.courtesyv
                    End If
                End If

                If IsDBNull(Persoonl.careassist) Then
                    params(9).Value = "0"
                Else
                    params(9).Value = Persoonl.careassist
                    If params(9).Value = Nothing Then
                        params(9).Value = "0"
                    Else
                        params(9).Value = Persoonl.careassist
                    End If
                End If

                If IsDBNull(Persoonl.epc) Then
                    params(10).Value = Format(0, "####00.00")
                Else
                    params(10).Value = Persoonl.epc
                    If params(10).Value = Nothing Then
                        params(10).Value = Format(0, "####00.00")
                    Else
                        params(10).Value = Persoonl.epc
                    End If
                End If

                If IsDBNull(Persoonl.selfoon) Then
                    params(11).Value = Format(0, "####00.00")
                Else
                    params(11).Value = FormatNumber(Persoonl.selfoon, 2)
                    If params(11).Value = Nothing Then
                        params(11).Value = Format(0, "####00.00")
                    Else
                        params(11).Value = FormatNumber(Persoonl.selfoon, 2)
                    End If
                End If

                If IsDBNull(Persoonl.PREMIE) Then
                    params(12).Value = "0.00"
                Else
                    params(12).Value = Persoonl.PREMIE
                    If params(12).Value = Nothing Then
                        params(12).Value = "0.00"
                    Else
                        params(12).Value = Persoonl.PREMIE
                    End If
                End If
                params(13).Value = Form1.lblForm1Label23.Text
                params(14).Value = (CDec(dblsubtotaal))
                params(15).Value = (CDec(dblMotor_sub))
                params(16).Value = (CDec(dblHuise_Sub))
                params(17).Value = (CDec(dblalle_sub))
                params(18).Value = (CDec(Persoonl.premie2))

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdatePersoonl", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                'Andriette 03/03/2014 update die persoonl entty na die update van die velde
                Persoonl = FetchPersoonl()
                If conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Function gen_getPakketPremie(ByVal strPolicyNo As String, ByVal strBetWyse As String, ByVal dtelongTermStart As Date, ByVal dtelongTermEnd As Date) As Double
        'Dim sSql As String
        Dim dblTotal As Double
        Dim arrtermPremDetail(17) As Double

        dblTotal = 0
        gen_getPakketPremie = 0
        Try
            If strBetWyse = "6" Then

                LongTermPolicy = ReportFetchLangTermPolicy()
                dteTermdateStart = Format(LongTermPolicy.DatumBegin, "dd/MM/yyyy")
                dteTermdateEnd = Format(LongTermPolicy.DatumEindig, "dd/MM/yyyy")
                'Get the earned premium for total period
                arrtermPremDetail = gen_getTermPolicyAmtEarned(strPolicyNo, dtelongTermStart, dtelongTermEnd)

                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@StartAfsluit", SqlDbType.NVarChar), _
                                                New SqlParameter("@EndAfsluit", SqlDbType.NVarChar)}
                    'Andriette 15/08/2013 verander na die parameter
                    ' params(0).Value = Persoonl.POLISNO
                    params(0).Value = strPolicyNo
                    params(1).Value = CStr(dteTermdateStart)
                    params(2).Value = CStr(dteTermdateEnd)

                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[ReportFetchTermPolicyAmtEarned]", params)

                    While reader.Read()

                        For intTeller = 2 To 7
                            dblTotal = dblTotal + reader(intTeller)
                        Next
                        dblTotal = dblTotal + reader("Totalvar9")
                        dblTotal = dblTotal + reader("Totalvar10")

                        'Package items
                        For intTeller = 14 To 17
                            dblTotal = dblTotal + reader(intTeller)
                        Next

                    End While
                    If conn.State = ConnectionState.Open Then
                        conn.Open()
                    End If
                End Using
            Else
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                    'Andriette 15/08/2013 verander na die parameter
                    'param.Value = Persoonl.POLISNO
                    param.Value = strPolicyNo

                    'Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlPakketPremie", param)
                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlPakketPremie", param)

                    While reader.Read
                        For i = 0 To 12 - 1
                            If Not IsDBNull(reader(i)) Then
                                Select Case CStr(reader(i)) & ""
                                    Case "0", "0.00", "", " "
                                        'nothing
                                    Case Else
                                        ' dblTotal = dblTotal + CDbl(reader(i) & "")
                                        dblTotal = dblTotal + FormatNumber(reader(i), 2)
                                End Select
                            End If
                        Next
                    End While
                    If conn.State = ConnectionState.Open Then
                        conn.Open()
                    End If
                End Using
            End If
            gen_getPakketPremie = Math.Round(dblTotal, 2).ToString
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return gen_getPakketPremie
        End Try
    End Function
    'Andriette 09/07/2014 verander die subu na ln funksie en return die premtotal array

    Public Function gen_getTermPolicyAmtEarned(ByVal POLISNO As String, ByVal TermStart As Date, ByVal TermEnd As Date) ', ByVal premTotal() As Double

        Dim intMonthsTillEnd As Integer
        Dim dtelastClosing As Date
        Dim arrpremHistory(17) As Double
        Dim arrpremCurrent(17) As Double
        Dim dtelastMonthEarned As Date
        Dim arrpremTotal(17) As Double

        'The month-end of the previous month is the earned figure for the current month
        ' -- Get all the premiums for the specified timeframe up to last month end (MD_PRINT2_DAT)

        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                           New SqlParameter("@Start", SqlDbType.NVarChar), _
                                           New SqlParameter("@End", SqlDbType.NVarChar)}

            'Andriette 15/08/2013 verander na die parameter wat in elke geval gestuur word
            'param(0).Value = Persoonl.POLISNO
            param(0).Value = POLISNO
            'param(1).Value = CDate(DateAdd("m", -1, TermStart) & ")")
            param(1).Value = CDate(TermStart)


            'param(2).Value = CDate(DateAdd("m", -1, TermEnd) & ")")
            param(2).Value = CDate(TermStart)

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchPremies", param)

            If reader.Read Then
                'Query return null when no transactions were found
                For i = 9 To 13
                    If IsDBNull(reader(i - 9)) Then
                        arrpremHistory(i) = 0
                    Else
                        arrpremHistory(i) = reader(i - 9)
                    End If
                Next
            Else
                arrpremHistory(9) = 0
                arrpremHistory(10) = 0
                arrpremHistory(11) = 0
                arrpremHistory(12) = 0
                arrpremHistory(13) = 0 'Addisionele premium
            End If

        End Using

        ' -- Get all the premiums for the specified timeframe up to last month end (MD_PRINT_DAT)

        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                           New SqlParameter("@Start", SqlDbType.NVarChar), _
                                           New SqlParameter("@End", SqlDbType.NVarChar)}
            'Andriette 15/08/2013 verander na die parameter wat in elke geval gestuur word

            'param(0).Value = Persoonl.POLISNO
            param(0).Value = POLISNO
            'param(1).Value = CDate(DateAdd("m", -1, TermStart) & ")")
            'param(2).Value = CDate(DateAdd("m", -1, TermEnd) & ")")
            param(1).Value = CDate(TermStart)
            param(2).Value = CDate(TermEnd)
            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchPremiesPrint_dat", param)

            If reader.Read Then
                Do While reader.Read
                    For i = 0 To 8
                        If IsDBNull(reader(i)) Or Trim(reader(i)) = "" Then
                            'ignore field
                        Else
                            'Add to total
                            arrpremHistory(i) = arrpremHistory(i) + Val(reader(i))
                        End If
                    Next
                    For k = 14 To 17
                        If IsDBNull(reader(k - 5)) Or Trim(reader(k - 5)) = "" Then
                            'ignore field
                        Else
                            'Add to total
                            arrpremHistory(k) = arrpremHistory(k) + Val(reader(k - 5))
                        End If
                    Next
                Loop
            Else
                'No records set fields equal to zero
                For i = 0 To 8
                    arrpremHistory(i) = 0
                Next
                For k = 14 To 17
                    arrpremHistory(k) = 0
                Next
            End If
        End Using

        ' -- Get last month-end closing

        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
            'Andriette 15/08/2013 verander na die parameter polisnommer
            'param.Value = Persoonl.POLISNO
            param.Value = POLISNO
            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchAfsluitdat", param)
            'When no month end exists - use term start date less one month as closing date
            If reader.Read Then
                If IsDBNull(reader("maxClosing")) Then
                    'lastClosing = DateAdd("m", -1, TermStart)
                    dtelastClosing = CDate(TermStart)
                Else
                    dtelastClosing = CDate(reader("maxClosing"))
                End If
            Else
                dtelastClosing = DateAdd("m", -1, TermStart)
            End If

            If dtelastClosing < TermStart Then
                If IsDBNull(reader("maxClosing")) Then 'no month end for LT policy
                    dtelastClosing = DateAdd("m", -1, TermStart)
                    dtelastMonthEarned = dtelastClosing
                Else 'Month-end for LT policy does exist
                    dtelastClosing = TermStart
                    dtelastMonthEarned = dtelastClosing
                End If
            Else
                dtelastMonthEarned = DateAdd("m", 1, dtelastClosing)
            End If
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Using

        '-- Get current premium

        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
            'Andriette 15/08/2013 verander na die parameter polisnommer
            'param.Value = Persoonl.POLISNO
            param.Value = POLISNO

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchCurrentPremie", param)
            If reader.Read Then
                For i = 0 To 17
                    'If IsDBNull(reader(i)) Or Trim(reader(i)) = "" Then
                    If IsDBNull(reader(i)) Then
                        'If reader(i) = "" Then
                        arrpremCurrent(i) = 0
                    Else
                        arrpremCurrent(i) = Val(reader(i))
                    End If
                Next
            Else
                'No records set fields equal to zero
                For i = 0 To 17
                    arrpremCurrent(i) = 0
                Next
            End If
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If

        End Using

        ' -- Calculate number of months left for term
        intMonthsTillEnd = (DateDiff("m", dtelastMonthEarned, TermEnd))

        ' -- Calculate tot premiums for length of term
        For i = 0 To 11
            arrpremTotal(i) = (arrpremCurrent(i) * intMonthsTillEnd) + arrpremHistory(i)
        Next
        For i = 14 To 17
            arrpremTotal(i) = (arrpremCurrent(i) * intMonthsTillEnd) + arrpremHistory(i)
        Next

        'Additional premium: history add premium and the current add premium
        arrpremTotal(13) = arrpremHistory(13) + arrpremCurrent(13)

        'The total premium must include all history additional premium but only add current additional premium ONCE
        ' --> Explanation: Totpremium = (currentPremium - currentaddition premium) * months left for term + current additional premium(ONCE) + historyPremiums
        'premTotal(12) = ((premCurrent(12) - premCurrent(13)) * monthsTillEnd) + premCurrent(13) + premHistory(12) + premHistory(13)
        arrpremTotal(12) = ((arrpremCurrent(12) - arrpremCurrent(13)) * intMonthsTillEnd) + arrpremCurrent(13) + arrpremHistory(12)
        Return arrpremTotal
    End Function

    Public Function baseform_GetTermPolicyMonthsLeft(ByVal strPOLISNO As String, ByVal dteTermStart As Date, ByVal dteTermEnd As Date)
        Dim intMonthsLeft As Integer = 0
        Dim dtelastClosing As Date
        Dim dtelastMonthEarned As Date

        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
            'Andriette 15/08/2013 verander na die parameter polisnommer
            'param.Value = Persoonl.POLISNO
            param.Value = strPOLISNO

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchAfsluitdat", param)

            'When no month end exists - use term start date less one month as closing date
            If reader.Read Then
                If IsDBNull(reader("maxClosing")) Then
                    'lastClosing = DateAdd("m", -1, TermStart)
                    dtelastClosing = CDate(dteTermStart)
                Else
                    dtelastClosing = CDate(reader("maxClosing"))
                End If
            Else
                dtelastClosing = DateAdd("m", -1, dteTermStart)
            End If

            If dtelastClosing < dteTermStart Then
                If IsDBNull(reader("maxClosing")) Then 'no month end for LT policy
                    dtelastClosing = DateAdd("m", -1, dteTermStart)
                    dtelastMonthEarned = dtelastClosing
                Else 'Month-end for LT policy does exist
                    dtelastClosing = dteTermStart
                    dtelastMonthEarned = dtelastClosing
                End If
            Else
                ' dtelastMonthEarned = DateAdd("m", 1, dtelastClosing)
                dtelastMonthEarned = dtelastClosing
            End If
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Using

        intMonthsLeft = (DateDiff("m", dtelastMonthEarned, dteTermEnd))
        Return intMonthsLeft

    End Function

    Private Structure TermLPolicyItems
        Dim strkategorie As String ' HUis/Voertuie/Alle Risiko
        Dim strTipe As String
        Dim strbeskrywing As String
        Dim strhuisafdeling As String
        Dim dblwaarde As Double

    End Structure

    Function FetchAreaBeskr(ByVal versekeraar As String) As List(Of String)
        Dim params() As SqlParameter = {New SqlParameter("@Area", SqlDbType.NVarChar), _
                                            New SqlParameter("@Versekeraar", SqlDbType.NVarChar)}

        If Gebruiker.titel = "Programmeerder" Then
            params(0).Value = ""
        Else
            params(0).Value = Gebruiker.BranchCodes
        End If

        params(1).Value = versekeraar

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAreaFiltered", params)
                Dim list As List(Of String) = New List(Of String)

                While reader.Read()
                    Dim item As AreaEntity = New AreaEntity()
                    If list.Count = 0 Then
                        item.Area_Besk = "Alle areas"
                        list.Add(item.Area_Besk)
                    End If

                    If reader("Area_Besk") IsNot DBNull.Value Then
                        item.Area_Besk = reader("Area_Besk")
                    End If

                    If list.Count = 0 Then
                        item.Area_Besk = "Alle areas"
                    End If
                    list.Add(item.Area_Besk)
                End While
                If list.Count = 0 Then

                    list.Add("Alle areas")

                End If
                Return list
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function

    Public Function cellphoneGetTotalPremium(ByVal strArgPolisno As String)
        Dim dblCellphoneTotal As Double = 0
        'cellphoneGetTotalPremium = 0
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar)}

                params(0).Value = strArgPolisno
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchTotalPrieme", params)
                While reader.Read()
                    'Check for null premium

                    If IsDBNull(reader("sumpremie")) Then
                        'Andriette 16/10/2013 verander die formatering
                        'cellphoneGetTotalPremium = Format(0, "####00.00")
                        'cellphoneGetTotalPremium = FormatNumber(0, 2)
                        dblCellphoneTotal = FormatNumber(0, 2)


                    Else
                        'Andriette 16/10/2013 verander die formatering
                        ' cellphoneGetTotalPremium = Format(CDec(reader("sumpremie")), "####00.00")
                        'cellphoneGetTotalPremium = FormatNumber(CDec(reader("sumpremie")), 2)
                        dblCellphoneTotal = FormatNumber(CDec(reader("sumpremie")), 2)
                    End If
                End While
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Try
        End Try

        Return dblCellphoneTotal
    End Function
    Public Function GetMaximumPremium() As Double
        Dim dblreturnValue As Double
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar)}
                params(0).Value = Persoonl.POLISNO
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[Stats5d].[md_Print2DataPremie2]", params)
                Do While reader.Read()

                    If IsDBNull(reader("premie2")) Then
                        dblreturnValue = Format(reader("premie2"), "0.00")
                    Else
                        dblreturnValue = "0.00"
                    End If
                    ' dblreturnValue = "0.00"
                Loop
                Return dblreturnValue
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function
    Public Function GetHuisByPrimaryKey(ByVal pkhuis As Integer) As HuisEntity
        Dim item As HuisEntity = New HuisEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@pkhuis", SqlDbType.Int)
                param.Value = pkhuis
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchHuisByPrimaryKey", param)

                While reader.Read()

                    If reader("ADRES_H1") IsNot DBNull.Value Then
                        item.ADRES_H1 = reader("ADRES_H1")
                    End If
                    If reader("Adres4") IsNot DBNull.Value Then
                        item.Adres4 = reader("Adres4")
                    End If
                    If reader("WAARDE_HB") IsNot DBNull.Value Then
                        item.WAARDE_HB = reader("WAARDE_HB")
                    End If
                    If reader("WAARDE_HE") IsNot DBNull.Value Then
                        item.WAARDE_HE = reader("WAARDE_HE")
                    End If
                    If reader("voorstad") IsNot DBNull.Value Then
                        item.voorstad = reader("voorstad")
                    End If
                    If reader("SekuriteitBitValue") IsNot DBNull.Value Then
                        item.SekuriteitBitValue = reader("SekuriteitBitValue")
                    End If
                    If reader("eem_premie") IsNot DBNull.Value Then
                        item.EEM_PREMIE = reader("eem_premie")
                    End If
                    If reader("eem_waarde") IsNot DBNull.Value Then
                        item.EEM_WAARDE = reader("eem_waarde")
                    End If
                    If reader("mainproperty") IsNot DBNull.Value Then
                        item.mainproperty = reader("mainproperty")
                    End If
                    If reader("pkHuis") IsNot DBNull.Value Then
                        item.pkHuis = reader("pkHuis")
                    End If
                    If reader("PREMIE_HE") IsNot DBNull.Value Then
                        item.PREMIE_HE = reader("PREMIE_HE")
                    End If
                    'Andriette 01/10/2013 haal uit word gedupliseer
                    'If reader("SekuriteitBitValue") IsNot DBNull.Value Then
                    '    item.SekuriteitBitValue = reader("SekuriteitBitValue")
                    'End If
                    If reader("STRUKTUUR") IsNot DBNull.Value Then
                        item.STRUKTUUR = reader("STRUKTUUR")
                    End If
                    If reader("TIPE_DAK") IsNot DBNull.Value Then
                        item.TIPE_DAK = reader("TIPE_DAK")
                    End If
                    If reader("toe_premie") IsNot DBNull.Value Then
                        item.TOE_PREMIE = reader("toe_premie")
                    End If
                    If reader("toe_waarde") IsNot DBNull.Value Then
                        item.TOE_WAARDE = reader("toe_waarde")
                    End If
                    If reader("PREMIE_HB") IsNot DBNull.Value Then
                        item.PREMIE_HB = reader("PREMIE_HB")
                    End If
                    If reader("sekuriteit") IsNot DBNull.Value Then
                        item.sekuriteit = reader("sekuriteit")
                    End If
                    'Andriette 01/10/2013 Voeg die velde by vir Kobus 
                    If reader("dorp") IsNot DBNull.Value Then
                        item.dorp = reader("dorp")
                    End If
                    If reader("cancelled") IsNot DBNull.Value Then
                        item.Cancelled = reader("cancelled")
                    End If
                    If reader("Verband") IsNot DBNull.Value Then
                        item.Verband = reader("Verband")
                    End If
                    If reader("BondNumber") IsNot DBNull.Value Then
                        item.bondNumber = reader("BondNumber")
                    End If
                    If reader("poskode") IsNot DBNull.Value Then
                        item.poskode = reader("poskode")
                    End If
                    If reader("A_MONITOR") IsNot DBNull.Value Then
                        item.A_MONITOR = reader("A_MONITOR")
                    End If
                    If reader("A_MAAK") IsNot DBNull.Value Then
                        item.A_MAAK = reader("A_MAAK")
                    End If
                    If reader("AlarmReaksie") IsNot DBNull.Value Then
                        item.AlarmReaksie = reader("AlarmReaksie")
                    End If
                    If reader("WeerligBeskerming") IsNot DBNull.Value Then
                        item.WeerligBeskerming = reader("WeerligBeskerming")
                    End If
                    If reader("PremiePersentasieHB") IsNot DBNull.Value Then
                        item.PremiePersentasieHB = reader("PremiePersentasieHB")
                    End If
                    If reader("PremiePersentasieHE") IsNot DBNull.Value Then
                        item.PremiePersentasieHE = reader("PremiePersentasieHE")
                    End If
                    If reader("lapa") IsNot DBNull.Value Then
                        item.lapa = reader("lapa")
                    End If
                    If reader("OppervlakteLapa") IsNot DBNull.Value Then
                        item.OppervlakteLapa = reader("OppervlakteLapa")
                    End If
                    If reader("OppervlakteHuis") IsNot DBNull.Value Then
                        item.OppervlakteHuis = reader("OppervlakteHuis")
                    End If
                    If reader("ErfNommer") IsNot DBNull.Value Then
                        item.ErfNommer = reader("ErfNommer")
                    End If
                    If reader("fkHomeLoanOrg") IsNot DBNull.Value Then
                        item.fkHomeLoanOrg = reader("fkHomeLoanOrg")
                    End If
                    If reader("fkPropertyType") IsNot DBNull.Value Then
                        item.fkPropertyType = reader("fkPropertyType")
                    End If
                    If reader("DatumVerwyder") IsNot DBNull.Value Then
                        item.DatumVerwyder = reader("DatumVerwyder")
                    End If
                    If reader("POSHIERNATOE") IsNot DBNull.Value Then
                        item.POSHIERNATOE = reader("POSHIERNATOE")
                    End If
                    If reader("WaardeEkstras") IsNot DBNull.Value Then
                        item.WaardeEkstras = reader("WaardeEkstras")
                    End If
                    If reader("premieEkstras") IsNot DBNull.Value Then
                        item.premieEkstras = reader("premieEkstras")
                    End If
                    If reader("A_KOMM") IsNot DBNull.Value Then
                        item.A_KOMM = reader("A_KOMM")
                    End If
                    If reader("A_GOEDGEKEUR") IsNot DBNull.Value Then
                        item.A_GOEDGEKEUR = reader("A_GOEDGEKEUR")
                    End If
                    If reader("WAARDEHE") IsNot DBNull.Value Then
                        item.WAARDEHE = reader("WAARDEHE")
                    End If
                End While
                Return item
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function
   
    Public Sub gen_ArchiveDocument(ByRef result As Byte(), ByRef POLISNO As String, ByRef KategorieNo As Byte, ByRef eposOnderwerp As String, ByRef eposAdres As String, ByRef eposInhoud As String, ByRef eposAanhangsels As String, Optional ByRef returnPath As String = "")
        Dim strCategoryFile As String
        Dim strDocPath As String
        Dim strDocDate As Date
        'Dim argief_path As String
        Dim strserverPath As String
        Dim strdocDir As String

        'Kobus 16/07/2014 voegby
        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim params() As SqlParameter = {New SqlParameter("@pkArchiveCategories", SqlDbType.NVarChar)}

            params(0).Value = KategorieNo

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchArchiveCategoriesByPk", params)
            reader.Read()
            If Persoonl.TAAL = 0 Then
                strCategoryFile = reader("CategoryFileAfr")
            Else
                strCategoryFile = reader("CategoryFileEng")
            End If
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Using

        ''Get category description
        'Select Case KategorieNo
        '    Case 1
        '        CategoryFile = "Belasting"
        '        CategoryDesc = "Belastingsertifikaat"
        '    Case 2
        '        CategoryFile = "Besonderhede"
        '        CategoryDesc = "Kliënt besonderhede"
        '    Case 3
        '        CategoryFile = "Bevestig"
        '        CategoryDesc = "Bevestig versekering: Voertuig"
        '    Case 4
        '        CategoryFile = "Generies"
        '        CategoryDesc = "Generiese brief"
        '    Case 5
        '        CategoryFile = "Kansellasie"
        '        CategoryDesc = "Kansellasie brief"
        '    Case 6
        '        CategoryFile = "Aanmaning"
        '        CategoryDesc = "Kontant/Elektroniese aanmaning"
        '    Case 7
        '        CategoryFile = "Skedule"
        '        CategoryDesc = "Polisskedule"
        '    Case 8
        '        CategoryFile = "VT"
        '        CategoryDesc = "VT Brief"
        '    Case 9
        '        CategoryFile = ""
        '        CategoryDesc = "E-pos"
        '    Case 10
        '        CategoryFile = "Bevestig"
        '        CategoryDesc = "Bevestig versekering: Huiseienaars"
        '    Case 11
        '        CategoryFile = "Bevestig"
        '        CategoryDesc = "Bevestig versekering: Huishoudelike inhoud"
        '    Case 12
        '        CategoryFile = "Hernuwing"
        '        CategoryDesc = "Termynpolis hernuwing"
        '    Case 13
        '        CategoryFile = "Opskorting"
        '        CategoryDesc = "Opskorting van dekking kennisgewing"
        '    Case 14
        '        CategoryFile = "Sekuriteit"
        '        CategoryDesc = "Sekuriteitsvereiste brief"
        '    Case 15
        '        CategoryFile = "EiseNotification"
        '        CategoryDesc = "Eis kennisgewing"
        '    Case Else
        '        CategoryFile = "Ander"
        '        CategoryDesc = "Ander"
        'End Select

        'I changed this for emails to be saved as well
        'Create document path - not for email without attachments
        strDocDate = Now()
        'If KategorieNo = 9 Then
        '    docPath = ""
        'Else
        strserverPath = gen_getArchivePath() 'The location on the server
        strdocDir = strserverPath & POLISNO 'The location on server with policy number
        'Path stored in db - no server path only subdirectory
        strDocPath = POLISNO & "\" & strCategoryFile & "_" & Format(strDocDate, "ddmmyyyy_HHMMSS") & ".pdf"
        returnPath = strserverPath & strDocPath
        'End If

        Try
            'Kobus 16/07/2014 comment out @kategorie and add @fkArchiveCategories
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                     New SqlParameter("@path", SqlDbType.NVarChar), _
                                     New SqlParameter("@epos_onderwerp", SqlDbType.NVarChar), _
                                     New SqlParameter("@epos_adres", SqlDbType.NVarChar), _
                                     New SqlParameter("@epos_inhoud", SqlDbType.NVarChar), _
                                     New SqlParameter("@epos_aanhangsels", SqlDbType.NVarChar), _
                                     New SqlParameter("@gebruiker", SqlDbType.NVarChar), _
                                     New SqlParameter("@datum", SqlDbType.DateTime), _
                                     New SqlParameter("@Incoming", SqlDbType.Bit), _
                                     New SqlParameter("@fkArchiveCategories", SqlDbType.Int)}
                'New SqlParameter("@kategorie", SqlDbType.NVarChar), _

                'Andriette 15/08/2013 verander na die parameter polisnommer
                'params(0).Value = Persoonl.POLISNO
                params(0).Value = glbPolicyNumber   'POLISNO
                'params(1).Value = CategoryDesc
                params(1).Value = strDocPath
                params(2).Value = eposOnderwerp
                params(3).Value = eposAdres
                params(4).Value = eposInhoud

                If eposAanhangsels Is Nothing Then
                    params(5).Value = ""
                Else
                    params(5).Value = eposAanhangsels
                End If

                params(6).Value = Gebruiker.Naam
                params(7).Value = strDocDate
                'Kobus 02/07/2014 voegby om nuwe veld Incoming te vul
                params(8).Value = 0
                'Kobus 16/07/2014 voegby om nuwe veld fkArchiceCategories te vul
                params(9).Value = KategorieNo
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateArchiveDocs", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try


        'Do not save document for an email - no document anyway
        'InitializeComponent changed this because we have a doc and it is written into the database
        ' If KategorieNo <> 9 Then
        'Check directory - create if necessary
        If Dir(strserverPath, vbDirectory) = "" Then
            MkDir(strserverPath)
        End If
        If Dir(strdocDir, vbDirectory) = "" Then
            MkDir(strdocDir)
        End If

        'Protect and save the file
        'If it is the letter of client details, save as a shared document
        'If KategorieNo = 2 Then

        File.WriteAllBytes(strserverPath & strDocPath, result)
        'Save a copy of this document
        'xlbook.SaveCopyAs(serverPath & docPath)

        'Reopen this document and save as shared document (So the changes may be tracked)
        'xlBook2 = xlbook.Application.Workbooks.Open(serverPath & docPath)
        'xlBook2.SaveAs(serverPath & docPath, , , , , , xlShared)
        'xlBook2.Close()
        'Else
        'xlbook.Worksheets(sheetNumber).Protect("m00i")
        ' xlbook.SaveCopyAs(serverPath & docPath)
        'End If
        ' End If
    End Sub

    Public Function gen_getArchivePath() As String
        Dim strPosisieGevind As String
        'Get archive path for server form pol_path (poldata.ini)
        strPosisieGevind = InStr(1, LCase(Constants.Path), "polis5") - 1
        gen_getArchivePath = Mid(Constants.Path, 1, strPosisieGevind) & "Polis5Argief\"
    End Function
    '***********************************************************************
    '    ' Author       : Kobus
    '    ' Created      : 11/07/2014
    '    ' Purpose      : Get Voice Path
    '    '******************************************************************
    Public Function gen_getVoicePath() As String
        Dim strPosisieGevind As String
        'Get archive path for server form pol_path (poldata.ini)
        strPosisieGevind = InStr(1, LCase(Constants.Path), "polis5") - 1
        gen_getVoicePath = Mid(Constants.Path, 1, strPosisieGevind) & "Polis5Voice\"
    End Function

    Public Function FetchConstants() As ConstantsEntity
        Dim strbeskrywing As String = ""
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchConstants")
                Dim item As ConstantsEntity = New ConstantsEntity()
                While reader.Read()

                    ' Andriette 26/06/2013 verander die stored procedure om net al die rekords terug te bring ipv om al die data op een rekord te probeer sit
                    If Not IsDBNull(reader("Description")) Then
                        strbeskrywing = reader("Description")
                        Select Case strbeskrywing
                            Case "ReportserverURL"
                                item.ReportserverURL = reader("stringvalue")
                            Case "Sasria_h"
                                item.Sasria_h = reader("intvalue")
                            Case "TV_Premie"
                                item.TV_Premie = reader("intvalue")
                            Case "Polisfooi"
                                item.Polisfooi = reader("intvalue")
                            Case "Earlybird"
                                item.Earlybird = reader("intvalue")
                            Case "Toebehore"
                                item.Toebehore = reader("intvalue")
                            Case "Korting"
                                item.Korting = reader("intvalue")
                            Case "MotorSasria"
                                item.MotorSasria = reader("intvalue")
                            Case "EPC"
                                item.EPC = reader("intvalue")
                            Case "path"
                                item.Path = reader("stringvalue")
                            Case "DebitOrderPerc"
                                item.DebitOrderPerc = reader("intvalue")
                                'Linkie 11/07/2014
                            Case "VAT"
                                item.VAT = reader("intvalue")
                                'Andriette 114/08/2014 voeg die PlipcoverValue by die tabel en lees in die entity in
                            Case "PlipCoverValue"
                                item.PlipCoverValue = reader("intvalue")
                        End Select
                    End If

                    'If Not IsDBNull(reader("ReportserverURL")) Then
                    '    item.ReportserverURL = reader("ReportserverURL")
                    'End If
                    'If Not IsDBNull(reader("Sasria_h")) Then
                    '    item.Sasria_h = reader("Sasria_h")
                    'End If
                    'If Not IsDBNull(reader("TV_Premie")) Then
                    '    item.TV_Premie = reader("TV_Premie")
                    'End If
                    'If Not IsDBNull(reader("Polisfooi")) Then
                    '    item.Polisfooi = reader("Polisfooi")
                    'End If
                    'If Not IsDBNull(reader("Earlybird")) Then
                    '    item.Earlybird = reader("Earlybird")
                    'End If
                    'If Not IsDBNull(reader("Toebehore")) Then
                    '    item.Toebehore = reader("Toebehore")
                    'End If
                    'If Not IsDBNull(reader("Korting")) Then
                    '    item.Korting = reader("Korting")
                    'End If
                    'If Not IsDBNull(reader("MotorSasria")) Then
                    '    item.MotorSasria = reader("MotorSasria")
                    'End If
                    'If Not IsDBNull(reader("EPC")) Then
                    '    item.EPC = reader("EPC")
                    'End If
                    'If Not IsDBNull(reader("Path")) Then
                    '    item.Path = reader("Path")
                    'End If
                    '' Andriette 25/06/2013 voeg die debit order percentage by die entity
                    'If Not IsDBNull(reader("DebitOrderPerc")) Then
                    '    item.DebitOrderPerc = reader("DebitOrderPerc")
                    'End If
                End While
                Return item
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function
    Public Function getAttachmentsForEmailEngine() As String
        Dim strAttachments As String = ""
        For intTeller = 0 To emailEngine.lstAanhangsels.Items.Count - 1
            If strAttachments <> "" Then
                strAttachments = strAttachments + ";"
            End If
            strAttachments = strAttachments + emailEngine.lstAanhangsels.Items(intTeller).ToString
        Next
        Return strAttachments
    End Function
    'Andriette 15/03/2014 maak sub publiek sodat dit van ander plekke ook gesien kan word
    ' Sub UpdatePersoonlPerField(ByVal FiedName As String, ByVal FieldValue As String)
    Public Sub UpdatePersoonlPerField(ByVal strFieldName As String, ByVal strFieldValue As String)

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                     New SqlParameter("@FieldName", SqlDbType.NVarChar), _
                                     New SqlParameter("@Value", SqlDbType.NVarChar)}

                'Andriette 15/08/2013 verander na die global polisnommer
                'params(0).Value = Form1.form1Polisno.Text
                'Andriette 01/10/2013 toets om te sien of die global polisnommer leeg is, dit gebeur wanneer 'n nuwe polis gelaai word
                If glbPolicyNumber = Nothing And strFieldName = "POLISNO" Then
                    If strFieldValue <> "" Then
                        glbPolicyNumber = strFieldValue
                    End If
                End If
                params(0).Value = glbPolicyNumber
                params(1).Value = strFieldName
                params(2).Value = strFieldValue.Trim
                If strFieldName <> "PERS_NOM" And IsNumeric(strFieldValue) Then ' Andriette 29/05/2013 sluit die pers_nom uit
                    ' params(2).Value = Str(FieldValue).Trim
                    params(2).Value = strFieldValue.ToString
                End If
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdatePersoonlPerField]", params)
            End Using
            'Linkie 03/07/2012
            'Andriette 21/05/2014 kry die waarde van die label
            If Form1.lblForm1Label23.Text <> "" Then
                Dim strLabel23 As String = Form1.lblForm1Label23.Text
                Dim dblLabel23 As Double = strLabel23
                dblPTotaal = FormatNumber(dblPTotaal, 2)
                dblLabel23 = FormatNumber(dblLabel23, 2)
                ' If PTotaal <> Val(Form1.Form1Label23.Text) Then
                If dblPTotaal.ToString <> dblLabel23.ToString Then
                    Using conn As SqlConnection = SqlHelper.GetConnection
                        Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                             New SqlParameter("@FieldName", SqlDbType.NVarChar), _
                                             New SqlParameter("@Value", SqlDbType.NVarChar)}
                        'Andriette 15/08/2013 verander na die global polisnommer
                        'params(0).Value = Form1.form1Polisno.Text
                        params(0).Value = glbPolicyNumber
                        params(1).Value = "premie"
                        params(2).Value = dblPTotaal
                        If IsNumeric(dblPTotaal) Then
                            params(2).Value = Str(dblPTotaal)
                        End If
                        SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdatePersoonlPerField]", params)
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                    End Using
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
        'Andriette 13/08/2013 verander om die persoonl entity te verander
        'FetchPersoonl()
        If Not blnByvoeg Then
            Persoonl = FetchPersoonl()
        End If
    End Sub

    Sub initScreen()

        '  Dim IntDag As Integer

        'Dim titelrek As DAO.Recordset
        'tak_hoof = pol.OpenRecordset("SELECT * FROM area WHERE area_kode in " & glbUserBranchCodes & " ")
        ' titelrek = pol.OpenRecordset("titel")
        Try
            If Form1.txtForm1Polisno.Text <> "" Then
                Persoonl = FetchPersoonl()
            End If
            ' Andriette 13/06/2013 haal hierdie uit want die comboboxes is reeds gevul
            Form1.cmbForm1Area.Items.Clear()
            Form1.cmbForm1Vanwie.Items.Clear()
            Form1.TITEL.Items.Clear()
            Form1.cmbForm1Bybet_k.Items.Clear()
            Form1.cmbForm1Combo1.Items.Clear()
            Form1.cmbForm1Posbestemming.Items.Clear()
            Form1.cmbForm1Taal.Items.Clear()
            Form1.cmbForm1Oudstudent.Items.Clear()

            ' Form1.form1AddSek.Items.Clecmbar()  ' Andriette 11/04/2013 Haal veld uit
            Form1.BindBemarker()
            ' Bemarker.MoveFirst()

            'While Not (Bemarker.EOF)
            '    Form1.VANWIE.Items.Add((Bemarker.Fields("NAAM").Value))
            '    Bemarker.MoveNext()
            'End While

            'Sit betaal dae by
            Form1.cmbForm1Betaaldag.Items.Clear()
            For IntdagTeller = 1 To 31
                IntdagTeller = CInt(Format(IntdagTeller, "00"))
                Form1.cmbForm1Betaaldag.Items.Add(IntdagTeller)
            Next
            Form1.cmbForm1Betaaldag.Text = "01"
            Form1.BindAreaCombo()

            If Form1.cmbForm1Taal.Text = "" Then
                Form1.TITEL.DataSource = FillCombo("[poldata5].[ListTitle]", "ID", "Title", "@Languange", 0)
                ' Form1.TITEL.DataSource = ListTitle(Integer.Parse(1))
            Else
                Form1.TITEL.DataSource = FillCombo("[poldata5].[ListTitle]", "ID", "Title", "@Languange", Val(Persoonl.TAAL))
                'Form1.TITEL.DataSource = ListTitle(Integer.Parse(Persoonl.TAAL))
            End If
            Form1.TITEL.DisplayMember = "Title"
            If Form1.txtForm1Polisno.Text = "" Then
                Form1.TITEL.SelectedItem = -1
            Else
                Form1.TITEL.SelectedItem = Persoonl.TITEL
            End If

            Form1.BindOudstudentinstansie()
            Dim intTaal As Integer

            'Andriette 15/08/2013 verander na die global polisnommer
            'If Form1.form1Polisno.Text = "" Then
            If glbPolicyNumber = "" Then
                intTaal = 1
            Else
                intTaal = Persoonl.TAAL
            End If

            If intTaal = 0 Then
                Form1.cmbForm1Bybet_k.Items.Add("Gewone")
                Form1.cmbForm1Bybet_k.Items.Add("Bejaarde")
                Form1.cmbForm1Bybet_k.Items.Add("R 1000.00")
                Form1.cmbForm1Bybet_k.Items.Add("Afkoop")
                Form1.cmbForm1Bybet_k.Items.Add("Opsioneel")
                Form1.cmbForm1Bybet_k.Items.Add("Alternatief")
            Else
                Form1.cmbForm1Bybet_k.Items.Add("Plain")
                Form1.cmbForm1Bybet_k.Items.Add("Pensioner")
                Form1.cmbForm1Bybet_k.Items.Add("R 1000.00")
                Form1.cmbForm1Bybet_k.Items.Add("Buy Off")
                Form1.cmbForm1Bybet_k.Items.Add("Optional")
                Form1.cmbForm1Bybet_k.Items.Add("Alternative")
            End If
            'Andriette 23/04/2013 Plaas in ;n For loop
            For intDisc = 0.05 To 3.0 Step 0.01
                Form1.cmbForm1Combo1.Items.Add(FormatNumber(intDisc, 2))
                If intDisc = 3.0 Then
                    Exit For
                End If
            Next
            Form1.cmbForm1Plip2.Items.Clear()
            Form1.cmbForm1Plip2.Items.Add("2.00")
            Form1.cmbForm1Plip2.Items.Add("3.00")
            Form1.cmbForm1Plip2.Items.Add("4.00")
            Form1.cmbForm1Plip2.Items.Add("5.00")
            Form1.cmbForm1Plip2.Items.Add("6.00")
            Form1.cmbForm1Plip2.Items.Add("11.00")
            Form1.cmbForm1Plip2.Items.Add("12.50")
            Form1.cmbForm1Plip2.SelectedIndex = -1

            'TAAL
            Form1.cmbForm1Taal.Items.Add("Afrikaans")
            Form1.cmbForm1Taal.Items.Add("Engels")

            ListPOSBESTEMMING(intTaal)
            Form1.lblForm1Pakket1Prem.Text = glbPakketItem1BeskAfr
            Form1.txtForm1Pakketitem2.Text = strglbPakketItem2BeskAfr

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub InitPol()
        'get all the values previously on ini files
        Try

            Constants = FetchConstants()
            'tak_hof = Form1.FetchAreaPerAreaKode(Persoonl.Area)
            Dim blnPrev_Motors As Boolean
            'btwPersentasie = 14

            'initpoleerste = 0

            blnPrev_Motors = False
            blnByvoeg = False
            blnediting = False
            ' Loading = False
            blnNuwe = False
            ' Andriette 13/06/2013 skuif al die konstante comboboxes hierheen omdat dit net eenmalig met die 
            ' inisieering van die poldata 1 bladsy gedoen moet word
            BindAreaCombo()
            BindBemarker()
            BindOudstudentinstansie()
            'BindAddSecurity() ' Andriette 11/04/2013 Haal veld uit
            'Bindposbestemming()
            BindCombo1()
            Bindplip2()
            ' Bindtitel()
            BindBYBET_K(1)
            BindPayMonth(1)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Function FetchVersekeraarForArea() As String
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@glbPreviousAreaCode", SqlDbType.Int)}

                params(0).Value = intGlbPreviousAreaCode

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchVersekeraarForArea]", params)
                Dim item As VersekeraarEntity = New VersekeraarEntity()
                While reader.Read()
                    item.Naam = reader("naam")
                End While
                Return item.Naam
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
            Exit Function
        End Try

    End Function
    Public Function FetchKontantDetails(ByRef strPolisNommer As String) As List(Of KontantEntity)
        Dim item As KontantEntity = New KontantEntity()
        Dim list As List(Of KontantEntity) = New List(Of KontantEntity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@polisno", SqlDbType.NVarChar)}
                param(0).Value = strPolisNommer
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaandKontantDeatils]", param)
                If reader.Read() Then
                    If reader("vord_dat") IsNot DBNull.Value Then
                        item.vord_dat = reader("vord_dat")
                    End If
                    If reader("premie") IsNot DBNull.Value Then
                        item.premie = reader("premie")
                    End If
                    If reader("vord_premie") IsNot DBNull.Value Then
                        item.vord_premie = reader("vord_premie")
                    End If
                    If reader("afsluit_dat") IsNot DBNull.Value Then
                        item.afsluit_dat = reader("afsluit_dat")
                    End If
                    If reader("jaar") IsNot DBNull.Value Then
                        item.jaar = reader("jaar")
                    End If
                    If reader("maand") IsNot DBNull.Value Then
                        item.maand = reader("maand")
                    End If
                    If reader("trans_dat") IsNot DBNull.Value Then
                        item.trans_dat = reader("trans_dat")
                    End If
                    If reader("betaalwyse") IsNot DBNull.Value Then
                        item.betaalwyse = reader("betaalwyse")
                    End If
                    If reader("kwitansie") IsNot DBNull.Value Then
                        item.kwitansie = reader("kwitansie")
                    End If
                    If reader("verw1") IsNot DBNull.Value Then
                        item.verw1 = reader("verw1")
                    End If
                    If reader("verw2") IsNot DBNull.Value Then
                        item.verw2 = reader("verw2")
                    End If
                    If reader("verw3") IsNot DBNull.Value Then
                        item.verw3 = reader("verw3")
                    End If
                    If reader("verw4") IsNot DBNull.Value Then
                        item.verw4 = reader("verw4")
                    End If
                    If reader("verw5") IsNot DBNull.Value Then
                        item.verw5 = reader("verw5")
                    End If
                    If reader("gekans") IsNot DBNull.Value Then
                        item.gekans = reader("gekans")
                    End If
                    If reader("kans_dat") IsNot DBNull.Value Then
                        item.kans_dat = reader("kans_dat")
                    End If
                    If reader("mk_trans_dat") IsNot DBNull.Value Then
                        item.mk_trans_dat = reader("mk_trans_dat")
                    End If
                    If reader("jk_trans_dat") IsNot DBNull.Value Then
                        item.jkkans_dat = reader("jk_trans_dat")
                    End If
                    If reader("eb_trans_dat") IsNot DBNull.Value Then
                        item.eb_trans_dat = reader("eb_trans_dat")
                    End If
                    If reader("ms_trans_dat") IsNot DBNull.Value Then
                        item.ms_trans_dat = reader("ms_trans_dat")
                    End If
                    If reader("ei_trans_dat") IsNot DBNull.Value Then
                        item.ei_trans_dat = reader("ei_trans_dat")
                    End If
                    If reader("md_trans_dat") IsNot DBNull.Value Then
                        item.md_trans_dat = reader("md_trans_dat")
                    End If
                    If reader("tipe") IsNot DBNull.Value Then
                        item.tipe = reader("tipe")
                    End If
                    If reader("kontant_tipe") IsNot DBNull.Value Then
                        item.kontant_tipe = reader("kontant_tipe")
                    End If
                    If reader("gg_trans_dat") IsNot DBNull.Value Then
                        item.gg_trans_dat = reader("gg_trans_dat")
                    End If
                    If reader("nuwe_tjekno") IsNot DBNull.Value Then
                        item.nuwe_tjekno = reader("nuwe_tjekno")
                    End If
                    If reader("tjekno") IsNot DBNull.Value Then
                        item.tjekno = reader("tjekno")
                    End If

                    If reader("tjekno_uit") IsNot DBNull.Value Then
                        item.tjekno_uit = reader("tjekno_uit")
                    End If
                    If reader("tjekno_in") IsNot DBNull.Value Then
                        item.tjekno_in = reader("tjekno_in")
                    End If
                    If reader("EISNO") IsNot DBNull.Value Then
                        item.EISNO = reader("EISNO")
                    End If

                    If reader("TJEKDATUM") IsNot DBNull.Value Then
                        item.TJEKDATUM = reader("TJEKDATUM")
                    End If

                    If reader("TJEKBESONDERHEDE") IsNot DBNull.Value Then
                        item.TJEKBESONDERHEDE = reader("TJEKBESONDERHEDE")
                    End If

                    If reader("kwit_boek") IsNot DBNull.Value Then
                        item.kwit_boek = reader("kwit_boek")
                    End If

                    If reader("Me_Trans_Dat") IsNot DBNull.Value Then
                        item.Me_Trans_Dat = reader("Me_Trans_Dat")
                    End If
                    If reader("FkLangtermynpolis") IsNot DBNull.Value Then
                        item.FkLangtermynpolis = reader("FkLangtermynpolis")
                    End If

                    If reader("LTPtipe") IsNot DBNull.Value Then
                        item.LTPtipe = reader("LTPtipe")
                    End If
                    If reader("FKLangtermynpolis_Kontant") IsNot DBNull.Value Then
                        item.FKLangtermynpolis_Kontant = reader("FKLangtermynpolis_Kontant")
                    End If
                    If reader("VTDatumAangevra") IsNot DBNull.Value Then
                        item.VTDatumAangevra = reader("VTDatumAangevra")
                    End If
                    If reader("area") IsNot DBNull.Value Then
                        item.area = reader("area")
                    End If
                    list.Add(item)
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return list
    End Function

    Public Function FetchVTDetails(ByRef strPolisNommer As String) As VTDetailsEntity
        Dim item As VTDetailsEntity = New VTDetailsEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                param.Value = strPolisNommer
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaand_details]", param)

                If reader.Read() Then
                    If reader("POLISNO") IsNot DBNull.Value Then
                        item.POLISNO = reader("POLISNO")
                    End If
                    If reader("VT_BEDRAG") IsNot DBNull.Value Then
                        item.VT_BEDRAG = reader("VT_BEDRAG")
                    End If
                    If reader("VT_INGEVORDER") IsNot DBNull.Value Then
                        item.VT_INGEVORDER = reader("VT_INGEVORDER")
                    End If
                    If reader("VT_KWITANSIE") IsNot DBNull.Value Then
                        item.VT_KWITANSIE = reader("VT_KWITANSIE")
                    End If
                    If reader("VT_TAKKODE") IsNot DBNull.Value Then
                        item.VT_TAKKODE = reader("VT_TAKKODE")
                    End If
                    If reader("VT_REKNR") IsNot DBNull.Value Then
                        item.VT_REKNR = reader("VT_REKNR")
                    End If
                    If reader("VT_REDE") IsNot DBNull.Value Then
                        item.VT_REDE = reader("VT_REDE")
                    End If
                    If reader("VT_TIPE_REK") IsNot DBNull.Value Then
                        item.VT_TIPE_REK = reader("VT_TIPE_REK")
                    End If
                    If reader("VT_VORD_DATUM") IsNot DBNull.Value Then
                        item.VT_VORD_DATUM = reader("VT_VORD_DATUM")
                    End If
                    If reader("VT_KODE") IsNot DBNull.Value Then
                        item.VT_KODE = reader("VT_KODE")
                    End If
                    If reader("X") IsNot DBNull.Value Then
                        item.X = reader("X")
                    End If
                    If reader("VT_DATUM") IsNot DBNull.Value Then
                        item.VT_DATUM = reader("VT_DATUM")
                    End If
                    If reader("JAAR") IsNot DBNull.Value Then
                        item.JAAR = reader("JAAR")
                    End If
                    If reader("MAAND") IsNot DBNull.Value Then
                        item.MAAND = reader("MAAND")
                    End If
                    If reader("TRANS_DAT") IsNot DBNull.Value Then
                        item.TRANS_DAT = reader("TRANS_DAT")
                    End If
                    If reader("Kwit_boek") IsNot DBNull.Value Then
                        item.Kwit_boek = reader("Kwit_boek")
                    End If
                    If reader("DatumAangevra") IsNot DBNull.Value Then
                        item.DatumAangevra = reader("DatumAangevra")
                    End If
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function
    'Public Function FetchSalariesDetails(ByRef Nommer As String) As maand_salariesEntity
    '    Dim item As maand_salariesEntity = New maand_salariesEntity()
    '    Try
    '        Using conn As SqlConnection = SqlHelper.GetConnection
    '            Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
    '            param.Value = Nommer
    '            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaand_Salaries]", param)


    '            If reader.Read() Then
    '                If reader("VORD_DAT") IsNot DBNull.Value Then
    '                    item.VORD_DAT = reader("VORD_DAT")
    '                End If
    '                If reader("PREMIE") IsNot DBNull.Value Then
    '                    item.PREMIE = reader("PREMIE")
    '                End If
    '                If reader("VORD_PREMIE") IsNot DBNull.Value Then
    '                    item.VORD_PREMIE = reader("VORD_PREMIE")
    '                End If
    '                If reader("AFSLUIT_DAT") IsNot DBNull.Value Then
    '                    item.AFSLUIT_DAT = reader("AFSLUIT_DAT")
    '                End If
    '                If reader("JAAR") IsNot DBNull.Value Then
    '                    item.JAAR = reader("JAAR")
    '                End If
    '                If reader("MAAND") IsNot DBNull.Value Then
    '                    item.MAAND = reader("MAAND")
    '                End If
    '                If reader("TRANS_DAT") IsNot DBNull.Value Then
    '                    item.TRANS_DAT = reader("TRANS_DAT")
    '                End If
    '                If reader("BETAALWYSE") IsNot DBNull.Value Then
    '                    item.betaalwyse = reader("BETAALWYSE")
    '                End If
    '                If reader("INGEVORDER") IsNot DBNull.Value Then
    '                    item.INGEVORDER = reader("INGEVORDER")
    '                End If
    '                If reader("MS_TRANS_DAT") IsNot DBNull.Value Then
    '                    item.MS_TRANS_DAT = reader("MS_TRANS_DAT")
    '                End If
    '                If reader("Area") IsNot DBNull.Value Then
    '                    item.Area = reader("Area")
    '                End If

    '            End If
    '        End Using
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        Return Nothing
    '    End Try
    '    Return item
    'End Function

    'Andriette 14/08/2014 haal die kontant vorm uit die projek
    'Public Function FetchMaandElectronics(ByRef strPolisNommer As String) As MaandElectronies
    '    Dim item As MaandElectronies = New MaandElectronies()
    '    Try
    '        Using conn As SqlConnection = SqlHelper.GetConnection
    '            Dim param() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
    '                                        New SqlParameter("@jaar", SqlDbType.SmallInt), _
    '                                        New SqlParameter("@maand", SqlDbType.SmallInt)}
    '            param(0).Value = strPolisNommer
    '            param(1).Value = Kontant.jaar_van.Text
    '            param(2).Value = Kontant.maand_van.Text
    '            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaandElektronies]", param)

    '            While reader.Read()

    '                If reader("vord_dat") IsNot DBNull.Value Then
    '                    item.vord_dat = reader("vord_dat")
    '                End If
    '                If reader("premie") IsNot DBNull.Value Then
    '                    item.premie = reader("premie")
    '                End If
    '                If reader("vord_premie") IsNot DBNull.Value Then
    '                    item.vord_premie = reader("vord_premie")
    '                End If
    '                If reader("afsluit_dat") IsNot DBNull.Value Then
    '                    item.afsluit_dat = reader("afsluit_dat")
    '                End If
    '                If reader("jaar") IsNot DBNull.Value Then
    '                    item.jaar = reader("jaar")
    '                End If
    '                If reader("maand") IsNot DBNull.Value Then
    '                    item.maand = reader("maand")
    '                End If
    '                If reader("trans_dat") IsNot DBNull.Value Then
    '                    item.trans_dat = reader("trans_dat")
    '                End If
    '                If reader("betaalwyse") IsNot DBNull.Value Then
    '                    item.betaalwyse = reader("betaalwyse")
    '                End If
    '                If reader("ingevorder") IsNot DBNull.Value Then
    '                    item.ingevorder = reader("ingevorder")
    '                End If
    '                If reader("me_trans_dat") IsNot DBNull.Value Then
    '                    item.me_trans_dat = reader("me_trans_dat")
    '                End If
    '                If reader("kwit_boek") IsNot DBNull.Value Then
    '                    item.kwit_boek = reader("kwit_boek")
    '                End If
    '                If reader("Area") IsNot DBNull.Value Then
    '                    item.Area = reader("Area")
    '                End If

    '            End While
    '            Return item
    '            If conn.State = ConnectionState.Open Then
    '                conn.Close()
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        Return Nothing
    '    End Try

    'End Function
    'Andriette 14/08/2014 haal die kontant vorm uit die projek
    'Public Function FetchMaandKontant(ByRef strPolisNommer As String) As M_KontantEntity
    '    Dim item As M_KontantEntity = New M_KontantEntity()
    '    Try
    '        Using conn As SqlConnection = SqlHelper.GetConnection
    '            Dim param() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
    '                                         New SqlParameter("@jaar", SqlDbType.SmallInt), _
    '                                         New SqlParameter("@maand", SqlDbType.SmallInt)}
    '            param(0).Value = strPolisNommer
    '            param(1).Value = Kontant.jaar_van.Text
    '            param(2).Value = Kontant.maand_van.Text

    '            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchMaandKontant", param)

    '            While reader.Read()
    '                If reader("polisno") IsNot DBNull.Value Then
    '                    item.polisno = reader("polisno")
    '                End If
    '                If reader("trans_dat") IsNot DBNull.Value Then
    '                    item.trans_dat = reader("vord_dat")
    '                End If
    '                If reader("betaalwyse") IsNot DBNull.Value Then
    '                    item.betaalwyse = reader("betaalwyse")
    '                End If
    '                If reader("kwit_boek") IsNot DBNull.Value Then
    '                    item.kwit_boek = reader("kwit_boek")
    '                End If
    '                If reader("Area") IsNot DBNull.Value Then
    '                    item.Area = reader("Area")
    '                End If
    '                If reader("Vord_dat") IsNot DBNull.Value Then
    '                    item.Vord_dat = reader("Vord_dat")
    '                End If
    '                If reader("Premie") IsNot DBNull.Value Then
    '                    item.Premie = reader("Premie")
    '                End If
    '                If reader("Vord_premie") IsNot DBNull.Value Then
    '                    item.Vord_premie = reader("Vord_premie")
    '                End If
    '                If reader("Jaar") IsNot DBNull.Value Then
    '                    item.Jaar = reader("Jaar")
    '                End If
    '                If reader("Maand") IsNot DBNull.Value Then
    '                    item.Maand = reader("Maand")
    '                End If
    '                If reader("mk_Trans_dat") IsNot DBNull.Value Then
    '                    item.mkTrans_dat = reader("mk_Trans_dat")
    '                End If
    '                If reader("Afsluit_dat") IsNot DBNull.Value Then
    '                    item.Afsluit_dat = reader("Afsluit_dat")
    '                End If
    '                If reader("Ingevorder") IsNot DBNull.Value Then
    '                    item.Ingevorder = reader("Ingevorder")
    '                End If

    '            End While
    '            Return item
    '            If conn.State = ConnectionState.Open Then
    '                conn.Close()
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        Return Nothing
    '    End Try

    'End Function
    'Andriette 14/08/2014 haal die kontant vorm uit die projek
    'Public Function FetchMaandDebities(ByRef strPolisNommer As String) As MaandEntity
    '    Dim item As MaandEntity = New MaandEntity
    '    Try
    '        Using conn As SqlConnection = SqlHelper.GetConnection
    '            Dim param() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
    '                                         New SqlParameter("@jaar", SqlDbType.SmallInt), _
    '                                         New SqlParameter("@maand", SqlDbType.SmallInt)}
    '            param(0).Value = strPolisNommer
    '            param(1).Value = Kontant.jaar_van.Text
    '            param(2).Value = Kontant.maand_van.Text

    '            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaandDebities]", param)

    '            While reader.Read()

    '                If reader("VORD_DAT") IsNot DBNull.Value Then
    '                    item.VORD_DAT = reader("VORD_DAT")
    '                End If
    '                If reader("PREMIE") IsNot DBNull.Value Then
    '                    item.PREMIE = reader("PREMIE")
    '                End If
    '                If reader("VORD_PREMIE") IsNot DBNull.Value Then
    '                    item.VORD_PREMIE = reader("VORD_PREMIE")
    '                End If
    '                If reader("MATCH") IsNot DBNull.Value Then
    '                    item.MATCH = reader("MATCH")
    '                End If
    '                If reader("NIE_MULTI") IsNot DBNull.Value Then
    '                    item.NIE_MULTI = reader("NIE_MULTI")
    '                End If
    '                If reader("NIE_MD") IsNot DBNull.Value Then
    '                    item.NIE_MD = reader("NIE_MD")
    '                End If
    '                If reader("ONINGEWIN") IsNot DBNull.Value Then
    '                    item.ONINGEWIN = reader("ONINGEWIN")
    '                End If
    '                If reader("AFSLUIT_DAT") IsNot DBNull.Value Then
    '                    item.AFSLUIT_DAT = reader("AFSLUIT_DAT")
    '                End If
    '                If reader("JAAR") IsNot DBNull.Value Then
    '                    item.JAAR = reader("JAAR")
    '                End If
    '                If reader("MAAND") IsNot DBNull.Value Then
    '                    item.MAAND = reader("MAAND")
    '                End If
    '                If reader("TRANS_DAT") IsNot DBNull.Value Then
    '                    item.TRANS_DAT = reader("TRANS_DAT")
    '                End If
    '                If reader("BETAALWYSE") IsNot DBNull.Value Then
    '                    item.BETAALWYSE = reader("BETAALWYSE")
    '                End If
    '                If reader("ingevorder") IsNot DBNull.Value Then
    '                    item.ingevorder = reader("ingevorder")
    '                End If
    '                If reader("md_trans_dat") IsNot DBNull.Value Then
    '                    item.md_trans_dat = reader("md_trans_dat")
    '                End If
    '                If reader("Kwit_boek") IsNot DBNull.Value Then
    '                    item.Kwit_boek = reader("Kwit_boek")
    '                End If
    '                If reader("Area") IsNot DBNull.Value Then
    '                    item.Area = reader("Area")
    '                End If

    '            End While
    '            Return item
    '            If conn.State = ConnectionState.Open Then
    '                conn.Close()
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        Return Nothing
    '    End Try

    'End Function

    Public Function FetchKontantGegenereer(ByRef strPolisNommer As String) As KontantGegenereerEntity
        Dim item As KontantGegenereerEntity = New KontantGegenereerEntity
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@Polisno", SqlDbType.NVarChar)
                param.Value = strPolisNommer
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchKontant_Gegenereer", param)

                While reader.Read()

                    If reader("vord_dat") IsNot DBNull.Value Then
                        item.vord_dat = reader("vord_dat")
                    End If

                    If reader("premie") IsNot DBNull.Value Then
                        item.premie = reader("premie")
                    End If
                    If reader("vord_premie") IsNot DBNull.Value Then
                        item.vord_premie = reader("vord_premie")
                    End If
                    If reader("afsluit_dat") IsNot DBNull.Value Then
                        item.afsluit_dat = reader("afsluit_dat")
                    End If
                    If reader("jaar") IsNot DBNull.Value Then
                        item.jaar = reader("jaar")
                    End If
                    If reader("maand") IsNot DBNull.Value Then
                        item.maand = reader("maand")
                    End If
                    If reader("trans_dat") IsNot DBNull.Value Then
                        item.trans_dat = reader("trans_dat")
                    End If
                    If reader("betaalwyse") IsNot DBNull.Value Then
                        item.betaalwyse = reader("betaalwyse")
                    End If
                    If reader("ingevorder") IsNot DBNull.Value Then
                        item.ingevorder = reader("ingevorder")
                    End If
                    If reader("gg_trans_dat") IsNot DBNull.Value Then
                        item.gg_trans_dat = reader("gg_trans_dat")
                    End If
                    If reader("tip_trans") IsNot DBNull.Value Then
                        item.tip_trans = reader("tip_trans")
                    End If
                    If reader("gekans") IsNot DBNull.Value Then
                        item.gekans = reader("gekans")
                    End If
                    If reader("kans_dat") IsNot DBNull.Value Then
                        item.kans_dat = reader("kans_dat")
                    End If
                    If reader("eb_vb_tb") IsNot DBNull.Value Then
                        item.eb_vb_tb = reader("eb_vb_tb")
                    End If
                    If reader("tipe_trans") IsNot DBNull.Value Then
                        item.tipe_trans = reader("tipe_trans")
                    End If
                    If reader("Polisno") IsNot DBNull.Value Then
                        item.polisno = reader("Polisno")
                    End If
                    If reader("Kwit_boek") IsNot DBNull.Value Then
                        item.Kwit_boek = reader("Kwit_boek")
                    End If
                    If reader("Area") IsNot DBNull.Value Then
                        item.Area = reader("Area")
                    End If
                End While
                Return item
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function

    Function FetchKontantAreas() As String
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchTakNaam]")
                Dim item As AreaEntity = New AreaEntity()
                If reader.Read() Then
                    item.Tak_Naam = reader("Tak_Naam")
                End If
                Return item.Tak_Naam
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
            Exit Function
        End Try
    End Function

    Public Function Fetch_Maand_Uovs_GTBfn_Salaries2(ByRef strPolisNommer As String) As List(Of Maand_SalariesEntity)
        Dim item As Maand_SalariesEntity = New Maand_SalariesEntity()
        Dim list As List(Of Maand_SalariesEntity) = New List(Of Maand_SalariesEntity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                param.Value = strPolisNommer
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[Fetch_Maand_Uovs_GTBfn _Salaries2]", param)
                While reader.Read()
                    If reader("VORD_DAT") IsNot DBNull.Value Then
                        item.VORD_DAT = reader("VORD_DAT")
                    End If
                    If reader("PREMIE") IsNot DBNull.Value Then
                        item.PREMIE = reader("PREMIE")
                    End If
                    If reader("VORD_PREMIE") IsNot DBNull.Value Then
                        item.VORD_PREMIE = reader("VORD_PREMIE")
                    End If
                    If reader("Jaar") IsNot DBNull.Value Then
                        item.JAAR = reader("Jaar")
                    End If
                    If reader("Maand") IsNot DBNull.Value Then
                        item.MAAND = reader("Maand")
                    End If
                    If reader("Trans_dat") IsNot DBNull.Value Then
                        item.TRANS_DAT = reader("Trans_dat")
                    End If
                    If reader("Afsluit_dat") IsNot DBNull.Value Then
                        item.AFSLUIT_DAT = reader("Afsluit_dat")
                    End If
                    If reader("Ingevorder") IsNot DBNull.Value Then
                        item.INGEVORDER = reader("Ingevorder")
                    End If
                    list.Add(item)
                End While
                Return list
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function
    Public Function Fetch_Maand_Uovs_Salaries(ByRef strPolisNommer As String) As List(Of Maand_SalariesEntity)
        Dim item As Maand_SalariesEntity = New Maand_SalariesEntity()
        Dim list As List(Of Maand_SalariesEntity) = New List(Of Maand_SalariesEntity)

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                param.Value = strPolisNommer
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[Fetch_Maand_Uovs_Salaries]", param)

                While reader.Read()
                    If reader("VORD_DAT") IsNot DBNull.Value Then
                        item.VORD_DAT = reader("VORD_DAT")
                    End If
                    If reader("PREMIE") IsNot DBNull.Value Then
                        item.PREMIE = reader("PREMIE")
                    End If
                    If reader("VORD_PREMIE") IsNot DBNull.Value Then
                        item.VORD_PREMIE = reader("VORD_PREMIE")
                    End If
                    If reader("Jaar") IsNot DBNull.Value Then
                        item.JAAR = reader("Jaar")
                    End If
                    If reader("Maand") IsNot DBNull.Value Then
                        item.MAAND = reader("Maand")
                    End If
                    If reader("Trans_dat") IsNot DBNull.Value Then
                        item.TRANS_DAT = reader("Trans_dat")
                    End If
                    If reader("Afsluit_dat") IsNot DBNull.Value Then
                        item.AFSLUIT_DAT = reader("Afsluit_dat")
                    End If
                    If reader("Ingevorder") IsNot DBNull.Value Then
                        item.INGEVORDER = reader("Ingevorder")
                    End If
                    list.Add(item)
                End While
                Return list
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            ' Andriette 07/03/2013 Maak warning reg
            Return Nothing
            Exit Function
        End Try

    End Function
    'Andriette 14/08/2014 haal die kontant vorm uit die projek
    'Public Function FetchVt_Balans(ByRef strPolisNommer As String, ByRef strvoorl As String, ByRef strversekerde As String) As maand_vt_balansEntity
    '    Dim item As maand_vt_balansEntity = New maand_vt_balansEntity
    '    Try
    '        Using conn As SqlConnection = SqlHelper.GetConnection
    '            'Andriette 30/06/2014 haal die voorletter en versekerde uit
    '            Dim params() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar)} ', _
    '            'New SqlParameter("@VOORL", SqlDbType.NVarChar), _
    '            'New SqlParameter("@VERSEKERDE", SqlDbType.NVarChar)}


    '            params(0).Value = Kontant.Polisno.Text
    '            'params(1).Value = Kontant.Voorl.Text
    '            ' params(2).Value = Kontant.Versekerde.Text

    '            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaand_Balans]", params)

    '            While reader.Read()

    '                If reader("polisno") IsNot DBNull.Value Then
    '                    item.polisno = reader("polisno")
    '                End If
    '                If reader("VOORL") IsNot DBNull.Value Then
    '                    item.VOORL = reader("VOORL")
    '                End If
    '                If reader("VERSEKERDE") IsNot DBNull.Value Then
    '                    item.VERSEKERDE = reader("VERSEKERDE")
    '                End If
    '            End While
    '            Return item
    '            If conn.State = ConnectionState.Open Then
    '                conn.Close()
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        Return Nothing
    '    End Try

    'End Function

    Public Function gen_getPosbestemmingDesc(ByVal intlanguage As Integer, ByVal strposbestemming As String) As String
        If intlanguage = 0 Then 'Afr
            Select Case strposbestemming
                Case "0" 'Posadres
                    gen_getPosbestemmingDesc = "Posadres"
                Case "1" 'Risikoadres
                    gen_getPosbestemmingDesc = "Risiko-adres"
                Case "2" 'Universiteitsposbus
                    gen_getPosbestemmingDesc = "Universiteitsposbus"
                Case "3" 'E-pos
                    gen_getPosbestemmingDesc = "E-pos"
                Case Else
                    gen_getPosbestemmingDesc = "Foutiewe posbestemming"
            End Select
        Else
            Select Case strposbestemming
                Case "0" 'Postal address
                    gen_getPosbestemmingDesc = "Postal address"
                Case "1" 'Risk address
                    gen_getPosbestemmingDesc = "Risk address"
                Case "2" 'University mailbox
                    gen_getPosbestemmingDesc = "University mailbox"
                Case "3" 'Email
                    gen_getPosbestemmingDesc = "Email"
                Case Else
                    gen_getPosbestemmingDesc = "Incorrect mailing destination"
            End Select
        End If
    End Function

    Public Function gen_getStatus(ByVal intlanguage As Integer, ByVal blnGEKANS As Boolean) As String
        If intlanguage = 0 Then
            Select Case blnGEKANS
                Case True
                    gen_getStatus = "Gekanselleer"
                Case False
                    gen_getStatus = "Aktief"
                Case Else
                    gen_getStatus = "Onbekend"
            End Select
        Else
            Select Case blnGEKANS
                Case True
                    gen_getStatus = "Cancelled"
                Case False
                    gen_getStatus = "Active"
                Case Else
                    gen_getStatus = "Unknown"
            End Select
        End If
    End Function

    'Andriette 20/06/2013 herontwerp die funksie
    Private Function GetPreviousAfsluitdatum(ByRef strVerwysde As String)
        Dim strTaknaam As String
        Dim dteAfsluitDatum As Date = "01/01/1900"

        rsTak11 = FetchTakForsalaries()
        strTaknaam = rsTak11.TAKNAAM
        rs1 = FetchPersoonlForVerwysdes(Persoonl.POLISNO)

        Using conn As SqlConnection = SqlHelper.GetConnection
            Select Case rs1.BET_WYSE
                Case "1"
                    Dim readerMaand_Kontant As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaxDateFromMaand_Kontant]")
                    If readerMaand_Kontant.Read() Then
                        dteAfsluitDatum = readerMaand_Kontant("dteAfsluit")
                    End If
                Case "2"

                Case "3"
                    Select Case rs1.Area
                        Case "1" 'Linkie 25/06/2008 - verander na area 1, was area 2 - Voor flagship was UOVS area 2

                            'If strTaknaam = "Flagship" Then
                            '    Dim readerUovs As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaxDateFromMaand_Uovs]")
                            '    If readerUovs.Read() Then
                            '        dteAfsluitDatum = readerUovs("dteAfsluit")
                            '    End If
                            'Else
                            Dim readerUovs As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaxDateFromMaand_Uovs]")
                            If readerUovs.Read() Then
                                dteAfsluitDatum = readerUovs("dteAfsluit")
                            End If
                            'End If

                        Case "2" 'Linkie 25/06/2008 - verander na area 2, was area 1 - Voor flagship was PUK area 1
                            If strTaknaam = "Flagship" Then
                                Dim readerMaand_Puk As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaxDateFromMaand_Puk]")
                                If readerMaand_Puk.Read() Then
                                    dteAfsluitDatum = readerMaand_Puk("dteAfsluit")
                                End If
                            Else
                                Dim readerUovs As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaxDateFromMaand_Uovs]")
                                If readerUovs.Read() Then
                                    dteAfsluitDatum = readerUovs("dteAfsluit")
                                End If
                            End If
                        Case "3"
                            Dim readerGtbfn As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaxDateFromMaand_gtbfn]")
                            If readerGtbfn.Read() Then
                                dteAfsluitDatum = readerGtbfn("dteAfsluit")
                            End If
                        Case "4"
                            Dim readerGnas As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaxDateFromMaand_Gnas]")
                            If readerGnas.Read() Then
                                dteAfsluitDatum = readerGnas("dteAfsluit")
                            End If
                        Case "B"
                            Dim readergmun As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaxDateFromMaand_gmun]")
                            If readergmun.Read() Then
                                dteAfsluitDatum = readergmun("dteAfsluit")
                            End If
                    End Select
                Case "4"
                    Dim readerMaand As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaxDateFromMaand]")
                    If readerMaand.Read() Then
                        dteAfsluitDatum = readerMaand("dteAfsluit")
                    End If
                Case "5"
                    Dim readerElektronies As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaxDateFromMaand_Elektronies]")
                    If readerElektronies.Read() Then
                        dteAfsluitDatum = readerElektronies("dteAfsluit")
                    End If
            End Select
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Using

        Return dteAfsluitDatum
    End Function

    Public Function FetchVerwysdes() As VerwysdesEntity
        Dim item As VerwysdesEntity = New VerwysdesEntity
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params As New SqlParameter("@Verwysde", SqlDbType.NVarChar)

                params.Value = Persoonl.POLISNO

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchVerwysdesDetails]", params)

                While reader.Read()

                    If reader("pkVerwysdes") IsNot DBNull.Value Then
                        item.pkVerwysdes = reader("pkVerwysdes")
                    End If
                    If reader("Verwyser") IsNot DBNull.Value Then
                        item.Verwyser = reader("Verwyser")
                    End If
                    If reader("Verwysde") IsNot DBNull.Value Then
                        item.Verwysde = reader("Verwysde")
                    End If
                    If reader("DatumEindig") IsNot DBNull.Value Then
                        item.DatumEindig = reader("DatumEindig")
                    End If
                    If reader("DatumBegin") IsNot DBNull.Value Then
                        item.DatumBegin = reader("DatumBegin")
                    End If
                    If reader("Status") IsNot DBNull.Value Then
                        item.Status = reader("Status")
                    End If
                    If reader("Verwyskommissie") IsNot DBNull.Value Then
                        item.Verwyskommissie = reader("Verwyskommissie")
                    End If
                End While
                Return item
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function

    'Public Sub GetKontantOntvangstes(ByVal strVerwysde, ByVal dteVanaf, ByVal dteTot, ByVal sngKOTotaal)

    '    'Dim dbStats5 As Database
    '    'Dim rs As Recordset
    '    'dbStats5 = OpenDatabase(pol_path + "\Stats5.mdb")

    '    'sngKOTotaal = 0

    '    'sSql = "SELECT * from Kontant where polisno = '" & strVerwysde & "' AND cdate(left(trans_dat,10)) between cdate('" & dteVanaf & "') and cdate('" & dteTot & "') AND Not gekans"

    '    'rs = dbStats5.OpenRecordset(sSql)

    '    'Do While Not rs.EOF
    '    '    If rs("tipe") = "MK" Or rs("tipe") = "MD" Or rs("tipe") = "ME" Or rs("tipe") = "MS" Or rs("tipe") = "VT" Or rs("tipe") = "EB" Or Tipe = "VB" Or Tipe = "TB" Then
    '    '        sngKOTotaal = sngKOTotaal + rs("Vord_premie")
    '    '    ElseIf rs("tipe") = "TB" Then
    '    '        sngKOTotaal = sngKOTotaal - rs("Vord_premie")
    '    '    End If
    '    '    rs.MoveNext()
    '    'Loop

    'End Sub

    'Public Sub GetVTs(ByVal strVerwysde, ByVal dteVorigeAfsluiting, ByVal dteVanaf, ByVal dteTot, ByVal intDekkingJaar, ByVal intDekkingMaand, ByVal sngVtTotaal)

    '    'Dim dbStats5 As Database
    '    'Dim rs As Recordset
    '    'dbStats5 = OpenDatabase(pol_path + "\Stats5.mdb")

    '    'sngVtTotaal = 0

    '    'sSql = "SELECT * from Maand_VT_details where polisno = '" & strVerwysde
    '    'sSql = sSql & "' And cdate(left(trans_dat,10)) between CDate('" & (dteVanaf) & "') and CDate('" & (dteTot) & "')"
    '    'rs = dbStats5.OpenRecordset(sSql)

    '    'Do While Not rs.EOF
    '    '    sngVtTotaal = sngVtTotaal + rs("VT_Bedrag")
    '    '    rs.MoveNext()
    '    'Loop

    'End Sub

    'Public Sub GetVorigeAfsluitingtotal(ByVal strVerwysde, ByVal sngSubtotaal, ByVal sngEispers, ByVal sngOnderlyn, ByVal sngPremie2, ByVal dteVorigeAfsluiting, ByVal sngVerwyskommissieVorigeAfsluiting)
    '    'Dim poldata5 As Database
    '    'Dim stats5 As Database
    '    'Dim stats5d As Database
    '    'Dim rs As Recordset
    '    'Dim rs2 As Recordset
    '    'Dim rs3 As Recordset
    '    'Dim rs4 As Recordset
    '    'Dim rs5 As Recordset

    '    'poldata5 = OpenDatabase(pol_path + "\Poldata5.mdb")
    '    'stats5 = OpenDatabase(pol_path + "\Stats5.mdb")
    '    'stats5d = OpenDatabase(pol_path + "\Stats5d.mdb")

    '    'Kry onder die lyn totale van stats5d
    '    'sSql = "SELECT * from md_print_dat where Afsluit_dat = '" & CDate(dteVorigeAfsluiting) & "' AND polisno = '" & strVerwysde & "'"
    '    'rs3 = stats5d.OpenRecordset(sSql)

    '    'Kry subtotaal en eis persentasie
    '    'sSql = "SELECT * from md_print2_dat where Afsluit_dat = '" & CDate(dteVorigeAfsluiting) & "' AND polisno = '" & strVerwysde & "'"

    '    'rs4 = stats5d.OpenRecordset(sSql)

    '    'If Not rs3.EOF And Not rs4.EOF Then
    '    '    sngSubtotaal = Val(rs3("subtotaal"))
    '    '    sngEispers = rs4("Eispers")
    '    '    sngOnderlyn = Val(IIf(IsNull(rs3("Beskerm")), 0, (rs3("Beskerm")))) + Val(IIf(IsNull(rs3("Sasprem")), 0, (rs3("Sasprem")))) + Val(IIf(IsNull(rs3("TV_diens")), 0, (rs3("TV_diens")))) + Val(IIf(IsNull(rs3("Polfooi")), 0, (rs3("Polfooi")))) + Val(IIf(IsNull(rs3("Begrafnis")), 0, (rs3("Begrafnis")))) + Val(IIf(IsNull(rs3("Plip")), 0, (rs3("Plip")))) + IIf(IsNull(rs4("Courtesyv")), 0, (rs4("Courtesyv"))) + IIf(IsNull(rs4("Epc")), 0, (rs4("Epc"))) + IIf(IsNull(rs3("CareAssist")), 0, (rs3("CareAssist"))) + IIf(IsNull(rs4("Inscell")), 0, (rs4("Inscell"))) + rs3("PakketItem1") + rs3("PakketItem2") + rs3("PakketItem3") + rs3("PakketItem4")
    '    '    sngPremie2 = rs4("Premie2")

    '    '    sngVerwyskommissieVorigeAfsluiting = rs4("Verwyskommissie")
    '    'Else
    '    '    'sSql = "SELECT * from persoonl where polisno = '" & strVerwysde & "'"
    '    '    'rs5 = poldata5.OpenRecordset(sSql)

    '    '    'If Not rs5.BOF And Not rs5.EOF Then
    '    '    sngSubtotaal = Val(rs5("subtotaal"))
    '    '    sngEispers = rs5("Eispers")
    '    '    sngOnderlyn = Val(IIf(IsNull(rs5("Beskerm")), 0, (rs5("Beskerm")))) + Val(IIf(IsNull(rs5("Sasprem")), 0, (rs5("Sasprem")))) + Val(IIf(IsNull(rs5("TV_diens")), 0, (rs5("TV_diens")))) + Val(IIf(IsNull(rs5("Polfooi")), 0, (rs5("Polfooi")))) + Val(IIf(IsNull(rs5("Begrafnis")), 0, (rs5("Begrafnis")))) + Val(IIf(IsNull(rs5("Plip1")), 0, (rs5("Plip1")))) + IIf(IsNull(rs5("Courtesyv")), 0, (rs5("Courtesyv"))) + IIf(IsNull(rs5("Epc")), 0, (rs5("Epc"))) + IIf(IsNull(rs5("CareAssist")), 0, (rs5("CareAssist"))) + IIf(IsNull(rs5("Selfoon")), 0, (rs5("Selfoon"))) + rs5("PakketItem1") + rs5("PakketItem2") + rs5("PakketItem3") + rs5("PakketItem4")
    '    '    sngPremie2 = rs5("Premie2")

    '    '    sngVerwyskommissieVorigeAfsluiting = rs5("Verwyskommissie")
    '    'Else
    '    '    sngSubtotaal = 0
    '    '    sngEispers = 0
    '    '    sngOnderlyn = 0
    '    '    sngPremie2 = 0

    '    '    sngVerwyskommissieVorigeAfsluiting = 0
    '    'End If
    '    'End If

    'End Sub
'

    Public Sub PopulateGridVerwysdes()
        Dim introw As Integer
        Dim dblTotaalVerwysKommissie As Double
        Dim dblVerwyskommissie As Double
        Dim strDateStart As String
        Dim strEndDate As String

        introw = 0
        VerwysdesListFrm.dgvVerwysdes.AutoGenerateColumns = False
        VerwysdesListFrm.dgvVerwysdes.Refresh()
        VerwysdesListFrm.dgvVerwysdes.Rows.Clear()
        VerwysdesListFrm.dgvVerwysdes.ColumnCount = 8
        VerwysdesListFrm.dgvVerwysdes.ColumnHeadersVisible = True
        VerwysdesListFrm.dgvVerwysdes.AutoSize = True
        VerwysdesListFrm.dgvVerwysdes.Columns(0).Name = "pkVerwysdes"
        VerwysdesListFrm.dgvVerwysdes.Columns(1).Name = "Policy number"
        VerwysdesListFrm.dgvVerwysdes.Columns(2).Name = "Surname"
        VerwysdesListFrm.dgvVerwysdes.Columns(3).Name = "Initials"
        ' Andriette 18/06/2013 verander die bewoording
        'VerwysdesListFrm.GridVerwysdes.Columns(4).Name = "Begin date"
        VerwysdesListFrm.dgvVerwysdes.Columns(4).Name = "Start date"
        VerwysdesListFrm.dgvVerwysdes.Columns(5).Name = "End date"
        VerwysdesListFrm.dgvVerwysdes.Columns(6).Name = "Status"
        VerwysdesListFrm.dgvVerwysdes.Columns(7).Name = "Commission"
        VerwysdesListFrm.dgvVerwysdes.Columns(0).Visible = False
        VerwysdesListFrm.dgvVerwysdes.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        VerwysdesListFrm.dgvVerwysdes.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        VerwysdesListFrm.dgvVerwysdes.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        VerwysdesListFrm.dgvVerwysdes.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        VerwysdesListFrm.dgvVerwysdes.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        VerwysdesListFrm.dgvVerwysdes.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        VerwysdesListFrm.dgvVerwysdes.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        VerwysdesListFrm.dgvVerwysdes.AllowUserToAddRows = False
        VerwysdesListFrm.dgvVerwysdes.AllowUserToDeleteRows = False
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@Verwyser", SqlDbType.NVarChar)}
                'Andriette 15/08/2013 veander na die global polisnommer
                'param(0).Value = Form1.form1Polisno.Text
                param(0).Value = glbPolicyNumber
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPopulateGridVerwysdes", param)
                dblTotaalVerwysKommissie = 0
                VerwysdesListFrm.btnVoegby.Enabled = True
                Do While reader.Read
                    'If  reader.Read Then
                    '    VerwysdesListFrm.btnEdit.Enabled = False
                    '    VerwysdesListFrm.btnKanselleer.Enabled = False
                    'Else
                    VerwysdesListFrm.btnEdit.Enabled = True
                    VerwysdesListFrm.btnKanselleer.Enabled = True

                    introw = introw + 1

                    'Kry kommissie vir verwysdes
                    dblVerwyskommissie = 0
                    ' Andriette 20/06/2013 toets vir engels
                    'Andriette 08/08/2013 doen altyd die berekening nie net as die kommissie leeg is nie
                    '   If reader("Status") = "Aktief" Or reader("Status") = "Active" Then
                    'Get real-time verwysdepremie
                    'sngVerwyskommissie = GetRealtimeVerwysPremie(Form1.form1Polisno.Text, reader("Verwysde"))
                    'Andriette 25/06/2013 verander die berekening

                    'If reader("Verwyskommissie") = 0.0 Then
                    'Andriette 15/08/2013 verander na die global polisnommer
                    'sngVerwyskommissie = CalculateInterimReferralCommission(Form1.POLISNO.Text, reader("Verwysde"))
                    If reader("Status").ToString.Trim.ToUpper = "ACTIVE" Then
                        dblVerwyskommissie = CalculateInterimReferralCommission(glbPolicyNumber, reader("Verwysde"))
                    Else
                        dblVerwyskommissie = 0
                    End If

                    'Else
                    '    sngVerwyskommissie = reader("Verwyskommissie")
                    'End If
                    ' Andriette 20/06/2013 gebruik die een van die tabel af
                    '    Else
                    '     sngVerwyskommissie = reader("Verwyskommissie")
                    '    End If

                    dblTotaalVerwysKommissie = dblTotaalVerwysKommissie + dblVerwyskommissie
                    ' Andriette 19/03/2013 Die velde bestaan nie in die stored proc nie
                    ' VerwysdesListFrm.GridVerwysdes.Rows.Insert(0, reader("pkVerwysdes"), reader("Verwysde"), reader("VERSEKERDE"), reader("Initials"), Mid(reader("Begindate"), 10), Mid(reader("Enddate"), 10), reader("Status"), Format(sngVerwyskommissie, "0.00"), introw)
                    strDateStart = reader("Begindate").ToString.Substring(0, 10)
                    strEndDate = reader("Enddate").ToString.Substring(0, 10)
                    VerwysdesListFrm.dgvVerwysdes.Rows.Insert(0, reader("pkVerwysdes"), reader("Verwysde"), reader("Surname"), reader("Initials"), strDateStart, strEndDate, reader("Status"), FormatNumber(dblVerwyskommissie, 2), introw)

                    ' End If
                Loop
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If VerwysdesListFrm.dgvVerwysdes.RowCount > 0 Then
            VerwysdesListFrm.dgvVerwysdes.Sort(VerwysdesListFrm.dgvVerwysdes.Columns(6), ComponentModel.ListSortDirection.Ascending)
            'Display total for verwysdes
            'introw = introw + 1
            VerwysdesListFrm.dgvVerwysdes.Rows.Insert(introw, "", "", "", "", "", "", "Total", FormatNumber(dblTotaalVerwysKommissie, 2), introw)
        End If
    End Sub

    Function FetchTakForsalaries()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchTak]")
                Dim item As TakEntity = New TakEntity()
                If reader.Read() Then
                    ' Andriette 19/03/2013 verander die toekennings om eers te check vir null's
                    If reader("Tak_naam") IsNot DBNull.Value Then
                        item.TAKNAAM = reader("Tak_naam")
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
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
            Exit Function
        End Try
    End Function
    Function FetchAreaByPersoonl()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                param.Value = Persoonl.POLISNO
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchAreaByPersoonl]", param)
                Dim item As AreaEntity = New AreaEntity()
                If reader.Read() Then
                    item.Area_Besk = reader("Area_besk")
                End If
                Return item.Area_Besk
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
            Exit Function
        End Try
    End Function


    'Andriette 14/08/2014 haal die kontant vorm heeltemal uit die projek
    'Public Function Fetch_Maand_Puk_For_Salaries(ByRef strPolisNommer As String) As Maand_Puk_For_SalariesEntity
    '    Dim item As Maand_Puk_For_SalariesEntity = New Maand_Puk_For_SalariesEntity()

    '    Try
    '        Using conn As SqlConnection = SqlHelper.GetConnection
    '            Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
    '                                           New SqlParameter("@Trans_dat", SqlDbType.DateTime)}

    '            'Andriette 15/08/2013 gebruik die parameter 
    '            ' param(0).Value = Persoonl.POLISNO
    '            param(0).Value = strPolisNommer
    '            param(1).Value = Kontant.DataGridView1.SelectedRows(0).Cells(5).Value

    '            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaand_PukForSalaries]", param)

    '            While reader.Read()
    '                If reader("POLISNO") IsNot DBNull.Value Then
    '                    item.POLISNO = reader("POLISNO")
    '                End If

    '                If reader("VORD_DAT") IsNot DBNull.Value Then
    '                    item.VORD_DAT = reader("VORD_DAT")
    '                End If
    '                If reader("PREMIE") IsNot DBNull.Value Then
    '                    item.PREMIE = reader("PREMIE")
    '                End If
    '                If reader("VORD_PREMIE") IsNot DBNull.Value Then
    '                    item.VORD_PREMIE = reader("VORD_PREMIE")
    '                End If
    '                If reader("nie_multi") IsNot DBNull.Value Then
    '                    item.NIE_MULTI = reader("nie_multi")
    '                End If
    '                If reader("match") IsNot DBNull.Value Then
    '                    item.MATCH = reader("match")
    '                End If
    '                If reader("nie_md") IsNot DBNull.Value Then
    '                    item.NIE_MD = reader("nie_md")
    '                End If
    '                If reader("oningewin") IsNot DBNull.Value Then
    '                    item.ONINGEWIN = reader("oningewin")
    '                End If
    '                If reader("Jaar") IsNot DBNull.Value Then
    '                    item.JAAR = reader("Jaar")
    '                End If
    '                If reader("Maand") IsNot DBNull.Value Then
    '                    item.MAAND = reader("Maand")
    '                End If
    '                If reader("Trans_dat") IsNot DBNull.Value Then
    '                    item.TRANS_DAT = reader("Trans_dat")
    '                End If

    '                If reader("Afsluit_dat") IsNot DBNull.Value Then
    '                    item.AFSLUIT_DAT = reader("Afsluit_dat")
    '                End If
    '                If reader("Ingevorder") IsNot DBNull.Value Then
    '                    item.ingevorder = reader("Ingevorder")
    '                End If

    '                If reader("ms_trans_dat") IsNot DBNull.Value Then
    '                    item.ms_trans_dat = reader("ms_trans_dat")
    '                End If

    '                If reader("Area") IsNot DBNull.Value Then
    '                    item.Area = reader("Area")
    '                End If
    '                If reader("pers_nom") IsNot DBNull.Value Then
    '                    item.pers_nom = reader("pers_nom")
    '                End If
    '                If reader("Kwit_boek") IsNot DBNull.Value Then
    '                    item.Kwit_boek = reader("Kwit_boek")
    '                End If
    '                If reader("BETAALWYSE") IsNot DBNull.Value Then
    '                    item.BETAALWYSE = reader("BETAALWYSE")
    '                End If
    '            End While
    '            Return item
    '            If conn.State = ConnectionState.Open Then
    '                conn.Close()
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        ' Andriette 07/03/2013 Maak warning reg
    '        Return Nothing
    '    End Try

    'End Function

    'Public Function Fetch_Maand_Gtbn_For_Salaries(ByRef strPolisNommer As String) As Maand_gtbnForSalaries
    '    Dim item As Maand_gtbnForSalaries = New Maand_gtbnForSalaries()
    '    Try
    '        Using conn As SqlConnection = SqlHelper.GetConnection
    '            Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
    '                                           New SqlParameter("@Trans_dat", SqlDbType.DateTime)}

    '            'Andriette 15/08/2013 gebruik die parameter
    '            'param(0).Value = Persoonl.POLISNO
    '            param(0).Value = strPolisNommer
    '            param(1).Value = Kontant.DataGridView1.SelectedRows(0).Cells(5)
    '            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaand_gtbfnForSalaries]", param)
    '            While reader.Read()
    '                If reader("POLISNO") IsNot DBNull.Value Then
    '                    item.POLISNO = reader("POLISNO")
    '                End If
    '                If reader("VORD_DAT") IsNot DBNull.Value Then
    '                    item.VORD_DAT = reader("VORD_DAT")
    '                End If
    '                If reader("PREMIE") IsNot DBNull.Value Then
    '                    item.PREMIE = reader("PREMIE")
    '                End If
    '                If reader("VORD_PREMIE") IsNot DBNull.Value Then
    '                    item.VORD_PREMIE = reader("VORD_PREMIE")
    '                End If
    '                If reader("nie_multi") IsNot DBNull.Value Then
    '                    item.NIE_MULTI = reader("nie_multi")
    '                End If
    '                If reader("match") IsNot DBNull.Value Then
    '                    item.MATCH = reader("match")
    '                End If
    '                If reader("nie_md") IsNot DBNull.Value Then
    '                    item.NIE_MD = reader("nie_md")
    '                End If
    '                If reader("oningewin") IsNot DBNull.Value Then
    '                    item.ONINGEWIN = reader("oningewin")
    '                End If
    '                If reader("Jaar") IsNot DBNull.Value Then
    '                    item.JAAR = reader("Jaar")
    '                End If
    '                If reader("Maand") IsNot DBNull.Value Then
    '                    item.MAAND = reader("Maand")
    '                End If
    '                If reader("Trans_dat") IsNot DBNull.Value Then
    '                    item.TRANS_DAT = reader("Trans_dat")
    '                End If
    '                If reader("Afsluit_dat") IsNot DBNull.Value Then
    '                    item.AFSLUIT_DAT = reader("Afsluit_dat")
    '                End If
    '                If reader("Ingevorder") IsNot DBNull.Value Then
    '                    item.ingevorder = reader("Ingevorder")
    '                End If
    '                If reader("ms_trans_dat") IsNot DBNull.Value Then
    '                    item.ms_trans_dat = reader("ms_trans_dat")
    '                End If
    '                If reader("Area") IsNot DBNull.Value Then
    '                    item.Area = reader("Area")
    '                End If
    '                If reader("pers_nom") IsNot DBNull.Value Then
    '                    item.pers_nom = reader("pers_nom")
    '                End If
    '                If reader("Kwit_boek") IsNot DBNull.Value Then
    '                    item.Kwit_boek = reader("Kwit_boek")
    '                End If
    '                If reader("BETAALWYSE") IsNot DBNull.Value Then
    '                    item.BETAALWYSE = reader("BETAALWYSE")
    '                End If
    '            End While
    '            Return item
    '            If conn.State = ConnectionState.Open Then
    '                conn.Close()
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        ' Andriette 07/03/213 Maak warning reg
    '        Return Nothing
    '    End Try

    'End Function

    'Public Function Fetch_Maand_Ouvs_For_Salaries(ByRef strPolisNommer As String) As Maand_OuvsForSalaries
    '    Dim item As Maand_OuvsForSalaries = New Maand_OuvsForSalaries()

    '    Try
    '        Using conn As SqlConnection = SqlHelper.GetConnection
    '            Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
    '                                           New SqlParameter("@Trans_dat", SqlDbType.DateTime)}

    '            'Andriette 15/08/2013 gebruik die parameter
    '            'param(0).Value = Persoonl.POLISNO
    '            param(0).Value = strPolisNommer
    '            param(1).Value = Kontant.DataGridView1.SelectedRows(0).Cells(5)
    '            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaand_uovsForSalaries]", param)
    '            While reader.Read()
    '                If reader("POLISNO") IsNot DBNull.Value Then
    '                    item.POLISNO = reader("POLISNO")
    '                End If

    '                If reader("VORD_DAT") IsNot DBNull.Value Then
    '                    item.VORD_DAT = reader("VORD_DAT")
    '                End If
    '                If reader("PREMIE") IsNot DBNull.Value Then
    '                    item.PREMIE = reader("PREMIE")
    '                End If
    '                If reader("VORD_PREMIE") IsNot DBNull.Value Then
    '                    item.VORD_PREMIE = reader("VORD_PREMIE")
    '                End If
    '                If reader("nie_multi") IsNot DBNull.Value Then
    '                    item.NIE_MULTI = reader("nie_multi")
    '                End If
    '                If reader("match") IsNot DBNull.Value Then
    '                    item.MATCH = reader("match")
    '                End If
    '                If reader("nie_md") IsNot DBNull.Value Then
    '                    item.NIE_MD = reader("nie_md")
    '                End If
    '                If reader("oningewin") IsNot DBNull.Value Then
    '                    item.ONINGEWIN = reader("oningewin")
    '                End If
    '                If reader("Jaar") IsNot DBNull.Value Then
    '                    item.JAAR = reader("Jaar")
    '                End If
    '                If reader("Maand") IsNot DBNull.Value Then
    '                    item.MAAND = reader("Maand")
    '                End If
    '                If reader("Trans_dat") IsNot DBNull.Value Then
    '                    item.TRANS_DAT = reader("Trans_dat")
    '                End If

    '                If reader("Afsluit_dat") IsNot DBNull.Value Then
    '                    item.AFSLUIT_DAT = reader("Afsluit_dat")
    '                End If
    '                If reader("Ingevorder") IsNot DBNull.Value Then
    '                    item.ingevorder = reader("Ingevorder")
    '                End If

    '                If reader("ms_trans_dat") IsNot DBNull.Value Then
    '                    item.ms_trans_dat = reader("ms_trans_dat")
    '                End If

    '                If reader("Area") IsNot DBNull.Value Then
    '                    item.Area = reader("Area")
    '                End If
    '                If reader("pers_nom") IsNot DBNull.Value Then
    '                    item.pers_nom = reader("pers_nom")
    '                End If
    '                If reader("Kwit_boek") IsNot DBNull.Value Then
    '                    item.Kwit_boek = reader("Kwit_boek")
    '                End If
    '                If reader("BETAALWYSE") IsNot DBNull.Value Then
    '                    item.BETAALWYSE = reader("BETAALWYSE")
    '                End If
    '            End While
    '            Return item
    '            If conn.State = ConnectionState.Open Then
    '                conn.Close()
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        Return Nothing

    '    End Try

    'End Function

    Sub V_Kode()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                'Andriette 15/08/2013 gebruik die global variable
                'param.Value = Form1.form1Polisno.Text
                param.Value = glbPolicyNumber

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchDATABYPOLISNO", param)
                Do While reader.Read
                    Ander_K = (reader("V_KODE"))
                Loop
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        ' T_Data.MoveFirst()
        ' Ander_K = Format(Val(T_Data("V_KODE")))
    End Sub


    Sub add_ander_k(ByVal strKode As String)

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                               New SqlParameter("@V_KODE", SqlDbType.NVarChar)}
                'Andriette 16/08/2013 gebruik die global polisnommer
                'param(0).Value = Form1.form1Polisno.Text
                param(0).Value = glbPolicyNumber
                param(1).Value = strKode

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateVKODE", param)
                'T_Data.Edit()
                'T_Data("V_KODE") = Kode
                'T_Data.Update()
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

    End Sub


    Sub HerBereken_Premie()
        Dim dblAddisionelePremie_Renamed As Decimal
        Dim dblKlassTotvoorAfslag As Decimal = 0
        Dim dblKlasseSaamNaAfslag As Decimal = 0
        Dim dblAlgPakketItems As Decimal = 0
        Dim dblAfslag As Decimal = 0
        Dim dblPremie As Decimal = 0
        Dim dblSelfoon As Decimal = 0
        Dim dblPremie2 As Decimal = 0

        Try
            'Andriette 17/03/2014 toets as dit reeds gesave is
            '  If ((Byvoeg Or pol_byvoeg) And blnSavedNew) Or (Not (Byvoeg Or pol_byvoeg)) Then
            If blnSavedNew Or (Not (blnByvoeg Or blnpol_byvoeg)) Then
                'Andriette 05/03/2014 moenie toets as dit nog in die laai van 'n nuwe polis is nie
                ' If Not (Byvoeg Or pol_byvoeg) Then
                If glbPolicyNumber <> "" Then
                    If glbPolicyNumber <> Persoonl.POLISNO Then
                        Persoonl = FetchPersoonl()
                    End If
                End If
                If Not IsNothing(Persoonl) Then
                    If Persoonl.GEKANS Then
                        Exit Sub
                    End If
                End If
                If blnNieOpdateer = 1 Then
                    Exit Sub
                End If

                'Areas wat nie lewendig is nie, word geignoreer
                blnNieOpdateer = 0
                Form1.Combo1.Enabled = True
                Form1.Check1.Enabled = True
                Form1.txtLiabilityPrem.Enabled = True
                Form1.Plip.Enabled = True
                Form1.plip2.Enabled = True
                ' Andriette 28/05/2013 verander van label na text box
                Form1.txtCourtesyPrem.Enabled = True
                Form1.txtRoadsidePrem.Enabled = True
                Form1.txthomeAsstPrem.Enabled = True
                Form1.lblPakket1Prem.Enabled = True
                Form1.txtPakketitem2.Enabled = True

                If Form1.cmbForm1Area.SelectedIndex <> -1 Then
                    Area = FetchArea()
                    'Andriette 24/10/2013 haal uit 
                    ' Area = New AreaEntity

                    If (Area.NoMatch) Then
                        For intTeller = 1 To 100
                            Beep()
                        Next intTeller
                        MsgBox("The area of the person insured is not in the AREA table.")
                        Exit Sub
                    Else
                        If (Area.Lewendig = "N") Then
                            For intTeller = 1 To 100
                                Beep()
                            Next intTeller
                            blnNieOpdateer = 1
                            Form1.cmbForm1Combo1.Enabled = False
                            Form1.Check1.Enabled = False
                            Form1.txtLiabilityPrem.Enabled = False
                            Form1.Plip.Enabled = False
                            Form1.plip2.Enabled = False
                            ' Andriette 28/05/2013 verander vam label na txt box
                            Form1.txtCourtesyPrem.Enabled = False
                            Form1.txtRoadsidePrem.Enabled = False
                            Form1.lblPakket1Prem.Enabled = False
                            Form1.txtPakketitem2.Enabled = False
                            Form1.txthomeAsstPrem.Enabled = False
                            'Geen verwysdes mag gekies word vir hierdie nie-lewendige area nie
                            Form1.m_verwysdes.Enabled = False
                            blnNieOpdateer = 0
                            Exit Sub '??
                        Else
                            Form1.m_verwysdes.Enabled = True
                        End If
                    End If
                End If 'form1.area.listindex <> -1

                If Gebruiker.titel = "Besigtig" Then
                    Form1.m_verwysdes.Enabled = True
                    Form1.mnuAddisionelepremie.Enabled = True
                    'onder die lyn
                    Form1.cmbForm1Combo1.Enabled = False
                    Form1.Check1.Enabled = False
                    Form1.Label18.Enabled = False
                    Form1.txtLiabilityPrem.Enabled = False
                    Form1.Label35.Enabled = False
                    Form1.plip2.Enabled = False
                    Form1.txtCourtesyPrem.Enabled = False
                    Form1.txthomeAsstPrem.Enabled = False
                    Form1.txtRoadsidePrem.Enabled = False
                    Form1.lblPakket1Prem.Enabled = False
                    Form1.txtPakketitem2.Enabled = False
                    Form1.lblSubtotaalNaKorting.Enabled = False
                    Form1.btnSelfoonPremie.Enabled = False
                    Form1.Label16.Enabled = False
                    Form1.Verwysingskommissie.Enabled = False
                    Form1.btnAddisionelePremie.Enabled = False
                End If

                'If Area.Tak_Naam = "Potchefstroom" Then
                '    If (Persoonl.Area = "5") Or (Persoonl.Area = "6") Or (Persoonl.Area = "7") Or (Persoonl.Area = "9") Then
                '        MsgBox("This policy may not be updated. This is a G / Luke, G / Tech, G / G or Rie / Mid field. Using the Vaal Triangle's database. (Click on the button VDH)")

                '        'Andriette 02/09/2013 verander 
                '        'GoTo einde
                '        Exit Sub
                '    End If
                'End If

                ''        'keer om riemland op te dateer

                'If Area.Tak_Naam = "Riemland" Then
                '    If (Persoonl.Area = "6") Or (Persoonl.Area = "7") Then
                '        MsgBox("This policy may not be updated. This is a G / G or Luke / Tech area.")
                '        'Andriette 02/09/2013 verander 
                '        'GoTo einde
                '        Exit Sub
                '    End If
                'End If

                If Area.Tak_Naam = "MM Potchefstroom" Then
                    If Persoonl.Area = "8" Then
                        MsgBox("This policy may not be updated. This is a historical claim", MsgBoxStyle.Information)
                    End If
                End If
                dblsasria_ = Bereken_Sasria()
                dblAddisionelePremie_Renamed = FormatNumber(gen_getAdditionalPremium(glbPolicyNumber), 2)
                Form1.btnForm1AddisionelePremie.Text = dblAddisionelePremie_Renamed
                Form1.btnAddisionelePremie.Text = dblAddisionelePremie_Renamed
                dblKlassTotvoorAfslag = dblMotor_sub + dblHuise_Sub + dblalle_sub
                dblsubtotaal = dblKlassTotvoorAfslag
                Form1.lblForm1Label33.Text = (Val(CDec(dblKlassTotvoorAfslag)))
                Persoonl.SUBTOTAAL = dblKlassTotvoorAfslag
                dblAlgPakketItems = FormatNumber(gen_getPakketPremie(glbPolicyNumber, 1, Now, Now), 2)
                Form1.lblForm1PolisPakketTotaal.Text = dblAlgPakketItems
                Form1.lblPolisPakketTotaal.Text = dblAlgPakketItems
                dblAfslag = Val(Form1.cmbForm1Combo1.Text)
                If dblAfslag = 0 Then
                    dblAfslag = 1
                End If
                dblKlasseSaamNaAfslag = FormatNumber((dblKlassTotvoorAfslag * dblAfslag), 2)

                Form1.lblForm1SubtotaalNaKorting.Text = FormatNumber(dblKlasseSaamNaAfslag, 2)
                dblSelfoon = FormatNumber(cellphoneGetTotalPremium(glbPolicyNumber), 2)
                Form1.btnForm1Selfoon.Text = dblSelfoon
                Persoonl.selfoon = dblSelfoon
                Form1.btnSelfoonPremie.Text = dblSelfoon

                dblPremie = dblKlasseSaamNaAfslag + dblSelfoon + dblAlgPakketItems
                Form1.lblForm1Label23.Text = FormatNumber(CDec(dblPremie), 2)
                Persoonl.PREMIE = FormatNumber(CDec(dblPremie), 2)
                dblPTotaal = dblPremie
                Form1.lblForm1MaandeliksePremie.Text = dblPremie
                Form1.lblMaandeliksePremie.Text = dblPremie

                'Andriette 27/06/2013 verander die formatting
                Form1.lblForm1Verwysingskommissie.Text = FormatNumber(CDec(Persoonl.verwyskommissie), 2)
                'Andriette 20/02/2014
                dblPremie2 = FormatNumber((dblPremie - Form1.lblForm1Verwysingskommissie.Text + dblAddisionelePremie_Renamed), 2)
                Form1.lblForm1Premie2.Text = dblPremie2
                Form1.Premie2.Text = dblPremie2
                '   Form1.Premie2.Text = FormatNumber((Form1.lblMaandeliksePremie.Text - Form1.Verwysingskommissie.Text + Form1.btnAddisionelePremie.Text), 2)
                Persoonl.premie2 = dblPremie2
                'If (Persoonl.PREMIE) <> (Form1.Form1Label23.Text) Then
                '    Persoonl.PREMIE = Form1.Form1Label23.Text
                '    Persoonl.SUBTOTAAL = Format(CDec(subtotaal), "0.00")

                Persoonl.MOTOR_SUB = Format(CDec(dblMotor_sub), "0.00")
                Persoonl.HUIS_SUB = Format(CDec(dblHuise_Sub), "0.00")
                Persoonl.ALLE_SUB = Format(CDec(dblalle_sub), "0.00")
                'End If
                Form1.ToolTip1.SetToolTip(Form1.lblForm1SubtotaalNaKorting, "Subtotal before discount: R" & FormatNumber(Form1.lblForm1Label33.Text, 2))

                ' sasria_ = Bereken_Sasria()
                'Andriette 27/05/2014 bereken sasria net as die blokkie gecheck is
                If Form1.Check1.Checked Then
                    UpdatePersoonlPerField("SASPREM", dblsasria_)
                    Persoonl.SASPREM = dblsasria_
                    'Andriette 11/09/2013 verander die formatering beter vir die skerm
                    Form1.Label36.Text = FormatNumber(dblsasria_, 2)
                Else
                    UpdatePersoonlPerField("SASPREM", 0)
                    Persoonl.SASPREM = 0
                    Form1.Label36.Text = FormatNumber(0, 2)
                End If

                Persoonl.premie2 = dblPremie2
                If (blnLoading = False) And (blnClear_s = False) Then
                    If IsDBNull(Persoonl.verwysdeur) Then
                        Form1.Verwysdeur.Text = " "
                    Else
                        Form1.Verwysdeur.Text = Persoonl.verwysdeur
                    End If
                    Persoonl.TV_DIENS = 0
                    Persoonl.MEDIES = 0
                    '  Persoonl.BEGRAFNIS = 0
                    Persoonl.BESKERM = 0
                    Persoonl.PLIP1 = 0
                    Persoonl.WN_POLIS = 0
                    Persoonl.courtesyv = Val(Form1.txtCourtesyPrem.Text)
                    Persoonl.careassist = Val(Form1.txtRoadsidePrem.Text)
                    Persoonl.epc = Val(Form1.txthomeAsstPrem.Text)
                    updatePersoonl()
                End If
                'Andriette 05/02/2014 
                ' EditPersoonlEdit()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Public Sub UpdateHuisWithPrimaryKey1()
        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim params() As SqlParameter = {New SqlParameter("@pkHuis", SqlDbType.Int)}
            params(0).Value = Form1.dgvPoldata1Eiendomme.SelectedRows(0).Cells(13).Value

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[UpdateHuisWithPrimaryKey1]", params)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Using

    End Sub

    'Sub EditPersoonlEdit()
    '    'Andriette 19/09/2013 bereken addisionele premie net 1 maal
    '    'Dim nAddisionelepremie As Decimal
    '    Try
    '        Using conn As SqlConnection = SqlHelper.GetConnection
    '            'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
    '            Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
    '                                         New SqlParameter("@SUBTOTAAL", SqlDbType.Money), _
    '                                         New SqlParameter("@MEDIES", SqlDbType.Money), _
    '                                         New SqlParameter("@MOTOR_SUB", SqlDbType.Money), _
    '                                         New SqlParameter("@HUIS_SUB", SqlDbType.Money), _
    '                                         New SqlParameter("@ALLE_SUB", SqlDbType.Money), _
    '                                         New SqlParameter("@SASPREM", SqlDbType.Money), _
    '                                         New SqlParameter("@WN_POLIS", SqlDbType.Money), _
    '                                         New SqlParameter("@PREMIE", SqlDbType.Money), _
    '                                         New SqlParameter("@premie2", SqlDbType.Money), _
    '                                         New SqlParameter("@Selfoon", SqlDbType.Money)}
    '            'Andriette 16/08/2013 gebruik die global polisnommer
    '            'param(0).Value = Form1.form1Polisno.Text
    '            param(0).Value = glbPolicyNumber
    '            'Andriette 11/09/2013 haal die roep uit want dit beteken niks
    '            'FetchPersoonl()
    '            dblsubtot = dblHuise_Sub + dblalle_sub + dblMotor_sub
    '            param(1).Value = Format(dblsubtot, "0.00")
    '            param(2).Value = Format(dblmedies_sub, "0.00")
    '            param(3).Value = Format(dblMotor_sub, "0.00")
    '            param(4).Value = Format(dblHuise_Sub, "0.00")
    '            param(5).Value = Format(dblalle_sub, "0.00")

    '            If IsDBNull(dblsubtot) Then
    '                dblsubtot = 0
    '            Else
    '                dblsubtot = FormatNumber((dblsubtot * Persoonl.eispers), 2)
    '            End If

    '            '  verskil = sasria_ - Val(Persoonl.SASPREM)
    '            'Andriette 02/09/2013 betaalwyse 6 is die termynpolis
    '            'If Persoonl.BET_WYSE = "2" And Not glbSkakelJKomTP Then
    '            If Persoonl.BET_WYSE = "6" And Not glbSkakelJKomTP Then
    '                dblsasria_ = dblsasria_ * 12
    '                param(6).Value = FormatNumber(dblsasria_, 2)
    '            Else
    '                'Andriette 02/09/2013 verander na die nuut berekende sasria
    '                ' param(6).Value = Persoonl.SASPREM
    '                param(6).Value = dblsasria_
    '            End If

    '            If IsDBNull(Persoonl.WN_POLIS) Then
    '                param(7).Value = 0
    '            Else
    '                param(7).Value = Persoonl.WN_POLIS
    '            End If

    '            param(8).Value = Persoonl.PREMIE
    '            param(9).Value = Persoonl.premie2
    '            'Andriette 05/02/214 voeg die selfoon premie by
    '            param(10).Value = Persoonl.selfoon
    '            'If IsDBNull(Persoonl.PLIP1) Then
    '            '    subtot = subtot + Val(Persoonl.POLFOOI) + Format(sasria_, "####.00") + Val(Persoonl.TV_DIENS) + Val(Persoonl.BESKERM) + Val(Persoonl.BEGRAFNIS) + medies_sub + Persoonl.WN_POLIS + Persoonl.courtesyv + Persoonl.careassist + Persoonl.epc + Persoonl.selfoon
    '            'Else
    '            '    subtot = subtot + Persoonl.PLIP1 + Val(Persoonl.POLFOOI) + Format(sasria_, "####.00") + Val(Persoonl.TV_DIENS) + Val(Persoonl.BESKERM) + Val(Persoonl.BEGRAFNIS) + medies_sub + Persoonl.WN_POLIS + Persoonl.courtesyv + Persoonl.careassist + Persoonl.epc + Persoonl.selfoon

    '            '    subtot = subtot + Persoonl.PakketItem1 + Persoonl.PakketItem2 + Persoonl.PakketItem3 + Persoonl.PakketItem4
    '            'End If
    '            'nAddisionelepremie = getAdditionalPremium()

    '            'param(8).Value = FormatNumber(subtot, 2)
    '            ''Andriette 19/09/2013 bereken addisionele prem net 1 maal
    '            ''Andriette 19/09/2013 verander om die herberekende subtot toe gebruik en nie die ou premie nie
    '            ''param(9).Value = Val(Persoonl.PREMIE) + nAddisionelepremie - Persoonl.verwyskommissie
    '            'param(9).Value = FormatNumber((subtot + nAddisionelepremie - Persoonl.verwyskommissie), 2)

    '            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdatePersoonlFields", param)

    '            ''Form1.lblAddisionelePremie.Text = CStr(getAdditionalPremium()) ' Andriette 09/04/2013
    '            'Form1.btnAddisionelePremie.Text = FormatNumber(nAddisionelepremie, 2) ' Andriette 09/04/2013 button ipv veld
    '            ''Andriette 27/06/2013 verander die formatting
    '            'Form1.Verwysingskommissie.Text = FormatNumber(Persoonl.verwyskommissie, 2)

    '            'f1subtotaal = Persoonl.SUBTOTAAL
    '            'f1eispers = Persoonl.eispers
    '            'subpremie = Persoonl.SUBTOTAAL * Persoonl.eispers
    '            'Form1.lblAlle_Sub.Text = FormatNumber(alle_sub, 2)
    '            'Form1.lblHuis_Sub.Text = FormatNumber(Huise_Sub, 2)
    '            'Form1.lblMotor_Sub.Text = FormatNumber(Motor_sub, 2)
    '            If conn.State = ConnectionState.Open Then
    '                conn.Close()
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub

    'Sub EditAlleriskFields()
    '    Try
    '        Using conn As SqlConnection = SqlHelper.GetConnection
    '            'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
    '            Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
    '                                         New SqlParameter("@PREMIE", SqlDbType.Money), _
    '                                         New SqlParameter("@DEKKING", SqlDbType.Money), _
    '                                         New SqlParameter("@arnplaat", SqlDbType.NVarChar)}

    '            'Andriette 16/08/2013 gebruik die global polisnommer
    '            '  param(0).Value = Form1.form1Polisno.Text
    '            param(0).Value = glbPolicyNumber
    '            If param(0).Value = "" Then
    '                Exit Sub
    '            End If

    '            If IsDBNull(alle_risiko.Premie) Then
    '                param(1).Value = "0.00"
    '            Else
    '                param(1).Value = alle_risiko.Premie
    '                If param(1).Value = Nothing Then
    '                    param(1).Value = "0.00"
    '                Else
    '                    param(1).Value = alle_risiko.Premie

    '                End If
    '            End If

    '            dblalle_sub = dblalle_sub + Val(alle_risiko.Premie)

    '            If IsDBNull(alle_risiko.DEKKING) Then
    '                param(2).Value = "0.00"
    '            Else
    '                param(2).Value = alle_risiko.DEKKING
    '                If param(2).Value = Nothing Then
    '                    param(2).Value = "0.00"
    '                Else
    '                    param(2).Value = alle_risiko.DEKKING
    '                End If
    '            End If

    '            If IsDBNull(alle_risiko.arnplaat) Then
    '                param(3).Value = ""
    '            Else
    '                param(3).Value = alle_risiko.arnplaat
    '                If param(3).Value = Nothing Then
    '                    param(3).Value = " "
    '                Else
    '                    param(3).Value = alle_risiko.arnplaat
    '                End If
    '            End If

    '            'SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateALLERISKForNullValues", param)
    '            If conn.State = ConnectionState.Open Then
    '                conn.Close()
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Sub EditHuisFields()
    '    If Not IsNothing(Persoonl) Then
    '        Using conn As SqlConnection = SqlHelper.GetConnection
    '            'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
    '            Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
    '                                         New SqlParameter("@PREMIE_HE", SqlDbType.Money), _
    '                                         New SqlParameter("@PREMIE_HB", SqlDbType.Money), _
    '                                         New SqlParameter("@toe_premie", SqlDbType.Money), _
    '                                         New SqlParameter("@eem_premie", SqlDbType.Money), _
    '                                         New SqlParameter("@WAARDE_HB", SqlDbType.Money), _
    '                                         New SqlParameter("@WAARDE_HE", SqlDbType.Money), _
    '                                         New SqlParameter("@toe_waarde", SqlDbType.Money), _
    '                                         New SqlParameter("@eem_waarde", SqlDbType.Money)}

    '            'Andriette 16/08/2013 gebruik die global polisnommer
    '            'param(0).Value = Form1.form1Polisno.Text
    '            param(0).Value = glbPolicyNumber

    '            If IsDBNull(huis_e.PREMIE_HE) Then
    '                param(1).Value = "0.00"
    '            Else
    '                param(1).Value = huis_e.PREMIE_HE
    '            End If

    '            If IsDBNull(huis_e.PREMIE_HB) Then
    '                param(2).Value = "0.00"
    '            Else
    '                param(2).Value = huis_e.PREMIE_HB
    '            End If

    '            dblhuis_sub = dblhuis_sub + Val(huis_e.PREMIE_HB)

    '            dblhuis_sub = dblhuis_sub + Val(huis_e.PREMIE_HE)

    '            If IsDBNull(huis_e.TOE_PREMIE) Then
    '                param(3).Value = 0
    '            Else
    '                param(3).Value = huis_e.TOE_PREMIE
    '            End If

    '            If IsDBNull(huis_e.EEM_PREMIE) Then
    '                param(4).Value = 0
    '            Else
    '                param(4).Value = huis_e.TOE_PREMIE
    '            End If

    '            dblhuis_sub = dblhuis_sub + huis_e.TOE_PREMIE

    '            dblhuis_sub = dblhuis_sub + huis_e.EEM_PREMIE

    '            If IsDBNull(huis_e.WAARDE_HB) Then
    '                param(5).Value = "0"
    '            Else
    '                param(5).Value = huis_e.WAARDE_HB
    '            End If

    '            If IsDBNull(huis_e.WAARDE_HE) Then
    '                param(6).Value = "0"
    '            Else
    '                param(6).Value = huis_e.WAARDE_HE
    '            End If

    '            If IsDBNull(huis_e.TOE_WAARDE) Then
    '                param(7).Value = 0
    '            Else
    '                param(7).Value = huis_e.TOE_WAARDE
    '            End If

    '            If IsDBNull(huis_e.EEM_WAARDE) Then
    '                param(8).Value = 0
    '            Else
    '                param(8).Value = huis_e.EEM_WAARDE
    '            End If

    '            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateHUISForNullValues", param)
    '        End Using
    '    End If
    'End Sub
    'Andriette 02/09/2013 verander die sub na ;n funksie en return die aantal voertuie, + die waarde van die voertuie asook die totale premies
    Private Function getPremieForVoertuie()
        Dim intAantal As Integer = 0
        Dim dblpremie As Double = 0
        Dim dblValue As Double = 0

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)

                'voertuie = FetchVoertuie()
                'Andriette 16/08/2013 gebruik die global polisnommer
                'param.Value = Form1.form1Polisno.Text
                param.Value = glbPolicyNumber
                If param.Value = Nothing Then
                    Return Nothing
                    'Exit Function
                Else
                    param.Value = Persoonl.POLISNO
                End If
                ' param.Value = voertuie.pkVoertuie
                'Active vehicles
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchVoertuieForPremie]", param)

                If reader.HasRows Then
                    Do While reader.Read

                        If Not IsDBNull(reader("PREMIE")) And Trim(reader("PREMIE")) <> "" Then
                            dblpremie = dblpremie + Val(reader("PREMIE"))
                            'Motor_sub = Motor_sub + Val(reader("PREMIE"))
                        End If
                        '                rs.MoveNext()
                        If Not IsDBNull(reader("Waarde")) Then
                            If Trim(reader("Waarde")) <> "" Then
                                dblValue = dblValue + Val(reader("Waarde"))
                            End If
                        End If
                        intAantal = intAantal + 1
                    Loop
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
            Return {intAantal, dblpremie, dblValue}
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function FetchHuis() As HuisEntity
        Dim blngekry As Boolean = False
        Dim item As HuisEntity = New HuisEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)

                'Andriette 16/08/2013 gebruik die global polisnommer
                'param.Value = Form1.form1Polisno.Text

                param.Value = glbPolicyNumber
                If param.Value = Nothing Or param.Value = "" Then
                    ' Andriette stel die nomattch
                    item.NoMatch = True
                    ' Return Nothing
                    Return item
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    Exit Function
                End If
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchHuisByPolisno", param)
                Do While reader.Read
                    'If reader.Read() Then

                    If reader("POLISNO") IsNot DBNull.Value Then
                        item.POLISNO = reader("POLISNO")
                    End If
                    If reader("ADRES_H1") IsNot DBNull.Value Then
                        item.ADRES_H1 = reader("ADRES_H1")
                    End If
                    If reader("AlarmReaksie") IsNot DBNull.Value Then
                        item.AlarmReaksie = reader("AlarmReaksie")
                    End If
                    If reader("WeerligBeskerming") IsNot DBNull.Value Then
                        item.WeerligBeskerming = reader("WeerligBeskerming")
                    End If
                    If reader("PremiePersentasieHB") IsNot DBNull.Value Then
                        item.PremiePersentasieHB = reader("PremiePersentasieHB")
                    End If
                    If reader("PremiePersentasieHE") IsNot DBNull.Value Then
                        item.PremiePersentasieHE = reader("PremiePersentasieHE")
                    End If
                    If reader("dorp") IsNot DBNull.Value Then
                        item.dorp = reader("dorp")
                    End If
                    If reader("A_MONITOR") IsNot DBNull.Value Then
                        item.A_MONITOR = reader("A_MONITOR")
                    End If
                    If reader("bondNumber") IsNot DBNull.Value Then
                        item.bondNumber = reader("bondNumber")
                    End If
                    If reader("ErfNommer") IsNot DBNull.Value Then
                        item.ErfNommer = reader("ErfNommer")
                    End If
                    If reader("OppervlakteLapa") IsNot DBNull.Value Then
                        item.OppervlakteLapa = reader("OppervlakteLapa")
                    End If
                    If reader("OppervlakteHuis") IsNot DBNull.Value Then
                        item.OppervlakteHuis = reader("OppervlakteHuis")
                    End If
                    If reader("poskode") IsNot DBNull.Value Then
                        item.poskode = reader("poskode")
                    End If
                    If reader("Adres4") IsNot DBNull.Value Then
                        item.Adres4 = reader("Adres4")
                    End If
                    If reader("lapa") IsNot DBNull.Value Then
                        item.lapa = reader("lapa")
                    End If
                    If reader("Cancelled") IsNot DBNull.Value Then
                        item.Cancelled = reader("Cancelled")
                    End If
                    If reader("eem_premie") IsNot DBNull.Value Then
                        item.EEM_PREMIE = reader("eem_premie")
                    End If
                    If reader("eem_waarde") IsNot DBNull.Value Then
                        item.EEM_WAARDE = reader("eem_waarde")
                    End If
                    'If reader("EiendomDisplay") IsNot DBNull.Value Then
                    '    item.EiendomDisplay = reader("EiendomDisplay")
                    'End If
                    If reader("mainproperty") IsNot DBNull.Value Then
                        item.mainproperty = reader("mainproperty")
                    End If

                    If reader("pkHuis") IsNot DBNull.Value Then
                        item.pkHuis = reader("pkHuis")
                    End If
                    If reader("PREMIE_HB") IsNot DBNull.Value Then
                        item.PREMIE_HB = reader("PREMIE_HB")
                    End If
                    If reader("PREMIE_HE") IsNot DBNull.Value Then
                        item.PREMIE_HE = reader("PREMIE_HE")
                    End If
                    If reader("sekuriteit") IsNot DBNull.Value Then
                        item.sekuriteit = reader("sekuriteit")
                    End If
                    If reader("SekuriteitBitValue") IsNot DBNull.Value Then
                        item.SekuriteitBitValue = reader("SekuriteitBitValue")
                    End If
                    If reader("STRUKTUUR") IsNot DBNull.Value Then
                        item.STRUKTUUR = reader("STRUKTUUR")
                    End If
                    If reader("TIPE_DAK") IsNot DBNull.Value Then
                        item.TIPE_DAK = reader("TIPE_DAK")
                    End If

                    If reader("toe_premie") IsNot DBNull.Value Then
                        item.TOE_PREMIE = reader("toe_premie")
                    End If
                    If reader("toe_premie") IsNot DBNull.Value Then
                        item.TOE_PREMIE = reader("toe_premie")
                    End If
                    If reader("toe_waarde") IsNot DBNull.Value Then
                        item.TOE_WAARDE = reader("toe_waarde")
                    End If

                    If reader("voorstad") IsNot DBNull.Value Then
                        item.voorstad = reader("voorstad")
                    End If
                    If reader("fkPropertyType") IsNot DBNull.Value Then
                        item.fkPropertyType = reader("fkPropertyType")
                    End If
                    If reader("WAARDE_HB") IsNot DBNull.Value Then
                        item.WAARDE_HB = reader("WAARDE_HB")
                    End If
                    If reader("fkHomeLoanOrg") IsNot DBNull.Value Then
                        item.fkHomeLoanOrg = reader("fkHomeLoanOrg")
                    End If

                    If reader("Verband") IsNot DBNull.Value Then
                        item.Verband = reader("Verband")
                    End If

                    If reader("WAARDE_HE") IsNot DBNull.Value Then
                        item.WAARDE_HE = reader("WAARDE_HE")
                    End If


                    item.NoMatch = False
                    'Else
                    'item.NoMatch = True
                    blngekry = True
                Loop
                'If Not blngekry Then
                '    item.NoMatch = True
                'End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            item.NoMatch = True
            Return item
            '  Return Nothing
        End Try
        Return item
    End Function
    Public Function FetchGeyserByPrimary(ByVal intGeyser As Integer) As GeyserEntity
        Dim item As GeyserEntity = New GeyserEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@pkGeyser", SqlDbType.Int)
                ' huis_e = FetchHuis()
                param.Value = intGeyser
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchGeyserByPrimary", param)

                If reader.Read() Then
                    If reader("fkGeyserTipe") IsNot DBNull.Value Then
                        item.GeyserTipe = reader("fkGeyserTipe")
                    End If
                    If reader("Liter") IsNot DBNull.Value Then
                        item.Liter = reader("Liter")
                    End If
                    If reader("Fabrikaat") IsNot DBNull.Value Then
                        item.Fabrikaat = reader("Fabrikaat")
                    End If
                    If reader("Model") IsNot DBNull.Value Then
                        item.Model = reader("Model")
                    End If
                    If reader("Premie") IsNot DBNull.Value Then
                        item.Premie = reader("Premie")
                    End If
                    If reader("DatumIn") IsNot DBNull.Value Then
                        item.DatumIn = reader("DatumIn")
                    End If
                    If reader("DatumWysig") IsNot DBNull.Value Then
                        item.DatumWysig = reader("DatumWysig")
                    End If
                    If reader("Waarde") IsNot DBNull.Value Then
                        item.Waarde = reader("Waarde")
                    End If

                    If reader("pkGeysers") IsNot DBNull.Value Then
                        item.pkGeysers = reader("pkGeysers")
                    End If
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function

    Public Function FetchAlleriskByPrimarykey() As ALLERISKEntity
        If IsNothing(Persoonl) Then
            ' Andriette 07/03/2013 Maak warning reg
            Return Nothing
            Exit Function
        Else
            If Persoonl.POLISNO = "" Then
                ' Andriette 07/03/2013 Maak warning reg
                Return Nothing
                Exit Function
            End If
        End If
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim item As ALLERISKEntity = New ALLERISKEntity()
                Dim param As New SqlParameter("@pkAllerisk", SqlDbType.Int)

                param.Value = Form1.dgvPoldata1AlleRisikoItems.SelectedRows(0).Cells(0).Value

                If param.Value = Nothing Then
                    item.NoMatch = True
                    ' Andriette 07/03/2013 Maak warning reg
                    Return Nothing
                    Exit Function
                End If

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAlleriskByPrimaryKey", param)

                If reader.Read() Then

                    If reader("POLISNO") IsNot DBNull.Value Then
                        item.POLISNO = reader("POLISNO")
                    End If
                    'If reader("afsluitdatum") IsNot DBNull.Value Then
                    '    item.afsluitdatum = reader("afsluitdatum")
                    'End If
                    If reader("arnplaat") IsNot DBNull.Value Then
                        item.arnplaat = reader("arnplaat")
                    End If
                    If reader("beskryf") IsNot DBNull.Value Then
                        item.beskryf = reader("beskryf")
                    End If
                    If reader("Beskrywing") IsNot DBNull.Value Then
                        item.Beskrywing = reader("Beskrywing")
                    End If
                    If reader("cancelled") IsNot DBNull.Value Then
                        item.cancelled = reader("cancelled")
                    End If
                    If reader("DEKKING") IsNot DBNull.Value Then
                        item.DEKKING = reader("DEKKING")
                    End If
                    If reader("itemnr") IsNot DBNull.Value Then
                        item.itemnr = reader("itemnr")
                    End If
                    If reader("Premie") IsNot DBNull.Value Then
                        item.Premie = reader("Premie")
                    End If
                    If reader("Tipe2") IsNot DBNull.Value Then
                        item.Tipe2 = reader("Tipe2")
                    End If
                    If reader("pkAllerisk") IsNot DBNull.Value Then
                        item.pkAllerisk = reader("pkAllerisk")
                    End If

                    If reader("selkontrakmet") IsNot DBNull.Value Then
                        item.selkontrakmet = reader("selkontrakmet")
                    End If
                    If reader("selnommer") IsNot DBNull.Value Then
                        item.selnommer = reader("selnommer")
                    End If
                    If reader("seldatumaangekoop") IsNot DBNull.Value Then
                        item.seldatumaangekoop = reader("seldatumaangekoop")
                    End If
                    item.NoMatch = False
                Else
                    item.NoMatch = True
                End If
                Return item
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function

    Public Function FetchAlleriskbyPolisNo() As ALLERISKEntity
        'If IsNothing(Persoonl.POLISNO) Then
        '    Exit Function
        'End If
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)

                'Andriette 16/08/2013 gebruik die global polisnommer
                'param.Value = Form1.form1Polisno.Text
                param.Value = glbPolicyNumber

                If param.Value = Nothing Then
                    ' Andriette 07/03/2013 Maak warning reg
                    Return Nothing
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    Exit Function
                    'Else
                    '    param.Value = Form1.form1Polisno.Text
                End If
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAlleriskByPolisno", param)
                Dim item As ALLERISKEntity = New ALLERISKEntity()

                Do While reader.Read

                    If reader("POLISNO") IsNot DBNull.Value Then
                        item.POLISNO = reader("POLISNO")
                    End If
                    'If reader("afsluitdatum") IsNot DBNull.Value Then
                    '    item.afsluitdatum = reader("afsluitdatum")
                    'End If
                    If reader("arnplaat") IsNot DBNull.Value Then
                        item.arnplaat = reader("arnplaat")
                    End If
                    If reader("beskryf") IsNot DBNull.Value Then
                        item.beskryf = reader("beskryf")
                    End If
                    If reader("Beskrywing") IsNot DBNull.Value Then
                        item.Beskrywing = reader("Beskrywing")
                    End If
                    If reader("cancelled") IsNot DBNull.Value Then
                        item.cancelled = reader("cancelled")
                    End If
                    If reader("DEKKING") IsNot DBNull.Value Then
                        item.DEKKING = reader("DEKKING")
                    End If
                    If reader("itemnr") IsNot DBNull.Value Then
                        item.itemnr = reader("itemnr")
                    End If
                    If reader("Premie") IsNot DBNull.Value Then
                        item.Premie = reader("Premie")
                    End If
                    If reader("Tipe2") IsNot DBNull.Value Then
                        item.Tipe2 = reader("Tipe2")
                    End If
                    If reader("pkAllerisk") IsNot DBNull.Value Then
                        item.pkAllerisk = reader("pkAllerisk")
                    End If

                    If reader("selkontrakmet") IsNot DBNull.Value Then
                        item.selkontrakmet = reader("selkontrakmet")
                    End If
                    If reader("selnommer") IsNot DBNull.Value Then
                        item.selnommer = reader("selnommer")
                    End If
                    If reader("seldatumaangekoop") IsNot DBNull.Value Then
                        item.seldatumaangekoop = reader("seldatumaangekoop")
                    End If
                    'item.NoMatch = True
                    item.NoMatch = False
                Loop
                'item.NoMatch = True
                'End If
                Return item
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function

    Public Function FetchMedies() As MediesEntity
        Dim item As MediesEntity = New MediesEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                param.Value = Persoonl.POLISNO

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchMediesByPolisno", param)

                Do While reader.Read() 'Then
                    If reader("POLISNO") IsNot DBNull.Value Then
                        item.POLISNO = reader("POLISNO")
                    End If
                    If reader("EGGENOTE") IsNot DBNull.Value Then
                        item.EGGENOTE = reader("EGGENOTE")
                    End If
                    If reader("EGGENOTE_G") IsNot DBNull.Value Then
                        item.EGGENOTE_G = reader("EGGENOTE_G")
                    End If
                    If reader("ME_GROOT_D") IsNot DBNull.Value Then
                        item.ME_GROOT_D = reader("ME_GROOT_D")
                    End If
                    If reader("ME_GROOT_K") IsNot DBNull.Value Then
                        item.ME_GROOT_K = reader("ME_GROOT_K")
                    End If
                    If reader("ME_GROOT_P") IsNot DBNull.Value Then
                        item.ME_GROOT_P = reader("ME_GROOT_P")
                    End If
                    If reader("ME_HOSPI_D") IsNot DBNull.Value Then
                        item.ME_HOSPI_D = reader("ME_HOSPI_D")
                    End If
                    If reader("ME_HOSPI_K") IsNot DBNull.Value Then
                        item.ME_HOSPI_K = reader("ME_HOSPI_K")
                    End If
                    If reader("ME_HOSPI_P") IsNot DBNull.Value Then
                        item.ME_HOSPI_P = reader("ME_HOSPI_P")
                    End If
                    If reader("ME_SIEKT_D") IsNot DBNull.Value Then
                        item.ME_SIEKT_D = reader("ME_SIEKT_D")
                    End If
                    If reader("ME_SIEKT_K") IsNot DBNull.Value Then
                        item.ME_SIEKT_K = reader("ME_SIEKT_K")
                    End If
                    If reader("ME_SIEKT_P") IsNot DBNull.Value Then
                        item.ME_SIEKT_P = reader("ME_SIEKT_P")
                    End If
                    If reader("ME_UNIV_K") IsNot DBNull.Value Then
                        item.ME_UNIV_K = reader("ME_UNIV_K")
                    End If
                    If reader("ME_UNIVE_D") IsNot DBNull.Value Then
                        item.ME_UNIVE_D = reader("ME_UNIVE_D")
                    End If
                    If reader("ME_UNIVE_P") IsNot DBNull.Value Then
                        item.ME_UNIVE_P = reader("ME_UNIVE_P")
                    End If
                    If reader("MEDIESE_V") IsNot DBNull.Value Then
                        item.MEDIESE_V = reader("MEDIESE_V")
                    End If
                    item.NoMatch = False
                    'Else
                Loop
                'item.NoMatch = True
                'End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function

    Public Function FetchArea() As AreaEntity
        Dim item As AreaEntity = New AreaEntity()
        If Not IsNothing(Persoonl) Then
            Try
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim param As New SqlParameter("@Area_kode", SqlDbType.NVarChar)
                    param.Value = Gebruiker.Area_kode
                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAreaByPolisNo", param)

                    If reader.Read() Then
                        If reader("Area_Besk") IsNot DBNull.Value Then
                            item.Area_Besk = reader("Area_Besk")
                        End If
                        If reader("Area_Windskerm_Bybet") IsNot DBNull.Value Then
                            item.Area_Windskerm_Bybet = reader("Area_Windskerm_Bybet")
                        End If
                        If reader("arkommpers") IsNot DBNull.Value Then
                            item.arkommpers = reader("arkommpers")
                        End If
                        If reader("Datumnielewendig") IsNot DBNull.Value Then
                            item.Datumnielewendig = reader("Datumnielewendig")
                        End If
                        'If reader("DisplayField") IsNot DBNull.Value Then
                        '    item.DisplayField = reader("DisplayField")
                        'End If
                        If reader("fkversekeraar") IsNot DBNull.Value Then
                            item.fkversekeraar = reader("fkversekeraar")
                        End If
                        If reader("hbkommpers") IsNot DBNull.Value Then
                            item.hbkommpers = reader("hbkommpers")
                        End If
                        If reader("hekommpers") IsNot DBNull.Value Then
                            item.hekommpers = reader("hekommpers")
                        End If
                        If reader("Lewendig") IsNot DBNull.Value Then
                            item.Lewendig = reader("Lewendig")
                        End If
                        'If reader("Mot_Cov_e_d") IsNot DBNull.Value Then
                        '    item.Mot_Cov_e_d = reader("Mot_Cov_e_d")
                        'End If
                        If reader("motkommpers") IsNot DBNull.Value Then
                            item.motkommpers = reader("motkommpers")
                        End If
                        If reader("pkarea") IsNot DBNull.Value Then
                            item.pkarea = reader("pkarea")
                        End If

                        If reader("tak_afkorting") IsNot DBNull.Value Then
                            item.tak_afkorting = reader("tak_afkorting")
                        End If
                        If reader("tak_bknaam") IsNot DBNull.Value Then
                            item.tak_bknaam = reader("tak_bknaam")
                        End If

                        'If reader("tak_dae1_a") IsNot DBNull.Value Then
                        '    item.tak_dae1_a = reader("tak_dae1_a")
                        'End If

                        'If reader("tak_dae1_e") IsNot DBNull.Value Then
                        '    item.tak_dae1_e = reader("tak_dae1_e")
                        'End If

                        'If reader("tak_dae2_a") IsNot DBNull.Value Then
                        '    item.tak_dae2_a = reader("tak_dae2_a")
                        'End If

                        'If reader("tak_dae2_e") IsNot DBNull.Value Then
                        '    item.tak_dae2_e = reader("tak_dae2_e")
                        'End If

                        If reader("Tak_Dorp") IsNot DBNull.Value Then
                            item.Tak_Dorp = reader("Tak_Dorp")
                        End If
                        If reader("tak_epos") IsNot DBNull.Value Then
                            item.tak_epos = reader("tak_epos")
                        End If

                        'If reader("tak_ete_a") IsNot DBNull.Value Then
                        '    item.tak_ete_a = reader("tak_ete_a")
                        'End If
                        'If reader("tak_ete_e") IsNot DBNull.Value Then
                        '    item.tak_ete_e = reader("tak_ete_e")
                        'End If

                        If reader("tak_faks") IsNot DBNull.Value Then
                            item.tak_faks = reader("tak_faks")
                        End If
                        If reader("tak_kontakpersoon") IsNot DBNull.Value Then
                            item.tak_kontakpersoon = reader("tak_kontakpersoon")
                        End If

                        If reader("Tak_Naam") IsNot DBNull.Value Then
                            item.Tak_Naam = reader("Tak_Naam")
                        End If
                        If reader("tak_posbus") IsNot DBNull.Value Then
                            item.tak_posbus = reader("tak_posbus")
                        End If

                        If reader("Tak_Poskode") IsNot DBNull.Value Then
                            item.Tak_Poskode = reader("Tak_Poskode")
                        End If
                        If reader("tak_regno") IsNot DBNull.Value Then
                            item.tak_regno = reader("tak_regno")
                        End If
                        'If reader("tak_regno_e") IsNot DBNull.Value Then
                        '    item.tak_regno_e = reader("tak_regno_e")
                        'End If
                        If reader("Tak_straat") IsNot DBNull.Value Then
                            item.Tak_straat = reader("Tak_straat")
                        End If
                        'If reader("Tak_straat_e") IsNot DBNull.Value Then
                        '    item.Tak_straat_e = reader("Tak_straat_e")
                        'End If

                        If reader("Tak_Straat_Poskode") IsNot DBNull.Value Then
                            item.Tak_Straat_Poskode = reader("Tak_Straat_Poskode")
                        End If
                        If reader("Tak_tel") IsNot DBNull.Value Then
                            item.Tak_tel = reader("Tak_tel")
                        End If
                        If reader("TAK_UNIV") IsNot DBNull.Value Then
                            item.TAK_UNIV = reader("TAK_UNIV")
                        End If
                        If reader("TAK_UNIVE") IsNot DBNull.Value Then
                            item.TAK_UNIVE = reader("TAK_UNIVE")
                        End If
                        If reader("tak_voorstad") IsNot DBNull.Value Then
                            item.tak_voorstad = reader("tak_voorstad")
                        End If
                        If reader("fkmakelaar") IsNot DBNull.Value Then
                            item.fkmakelaar = reader("fkmakelaar")
                        End If
                        item.NoMatch = False
                    Else
                        item.NoMatch = True
                    End If
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Return Nothing
            End Try
        End If
        Return item
    End Function
    Public Function FetchVersekeraar() As VersekeraarEntity
        Dim item As VersekeraarEntity = New VersekeraarEntity()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 15/01/2014 - verander bet_dat vanaf nvarchar na date
                Dim param As New SqlParameter("@bet_dat", SqlDbType.Date)
                param.Value = DateAdd("m", 1, Now)
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlForMultidata", param)

                If reader.Read() Then
                    If reader("Bedryfsnaam") IsNot DBNull.Value Then
                        item.Bedryfsnaam = reader("Bedryfsnaam")
                    End If
                    If reader("BTWNommer") IsNot DBNull.Value Then
                        item.BTWNommer = reader("BTWNommer")
                    End If
                    If reader("DateCancelled") IsNot DBNull.Value Then
                        item.DateCancelled = reader("DateCancelled")
                    End If
                    If reader("DateStarted") IsNot DBNull.Value Then
                        item.DateStarted = reader("DateStarted")
                    End If
                    If reader("DisFile") IsNot DBNull.Value Then
                        item.DisFile = reader("DisFile")
                    End If
                    If reader("FisiesDorp") IsNot DBNull.Value Then
                        item.FisiesDorp = reader("FisiesDorp")
                    End If
                    If reader("FisieseAdres") IsNot DBNull.Value Then
                        item.FisieseAdres = reader("FisieseAdres")
                    End If
                    If reader("FisiesPoskode") IsNot DBNull.Value Then
                        item.FisiesPoskode = reader("FisiesPoskode")
                    End If
                    If reader("FisiesVoorstad") IsNot DBNull.Value Then
                        item.FisiesVoorstad = reader("FisiesVoorstad")
                    End If
                    If reader("HuisBystandKomPers") IsNot DBNull.Value Then
                        item.HuisBystandKomPers = reader("HuisBystandKomPers")
                    End If
                    If reader("Naam") IsNot DBNull.Value Then
                        item.Naam = reader("Naam")
                    End If
                    If reader("PadbystandKomPers") IsNot DBNull.Value Then
                        item.PadbystandKomPers = reader("PadbystandKomPers")
                    End If
                    If reader("PhysicalAddress") IsNot DBNull.Value Then
                        item.PhysicalAddress = reader("PhysicalAddress")
                    End If
                    If reader("pkVersekeraar") IsNot DBNull.Value Then
                        item.pkVersekeraar = reader("pkVersekeraar")
                    End If
                    If reader("Posadres") IsNot DBNull.Value Then
                        item.Posadres = reader("Posadres")
                    End If

                    If reader("PosDorp") IsNot DBNull.Value Then
                        item.PosDorp = reader("PosDorp")
                    End If
                    If reader("PosPoskode") IsNot DBNull.Value Then
                        item.PosPoskode = reader("PosPoskode")
                    End If

                    If reader("Postaladdress") IsNot DBNull.Value Then
                        item.Postaladdress = reader("Postaladdress")
                    End If
                    If reader("PosVoorstad") IsNot DBNull.Value Then
                        item.PosVoorstad = reader("PosVoorstad")
                    End If
                    If reader("Registrasienommer") IsNot DBNull.Value Then
                        item.Registrasienommer = reader("Registrasienommer")
                    End If
                    If reader("Telno") IsNot DBNull.Value Then
                        item.Telno = reader("Telno")
                    End If
                    If reader("WaterleweKommpers") IsNot DBNull.Value Then
                        item.WaterleweKommpers = reader("WaterleweKommpers")
                    End If
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function

    'Andriette 13/08/2013 voeg die parameter van die voertuig by as 'n opsionele parameter sodat die funksie ook
    'entities vul wat nie die default gekose voertuig op die grid is nie
    'Andriette 22/01/2013 brei hierdie funksie uit
    Public Function FetchVoertuie(Optional ByVal intpkVoertuig As Integer = 0) As VoertuieEntity
        Dim item As VoertuieEntity = New VoertuieEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@pkVoertuie", SqlDbType.Int)
                'Andriette 13/08/2013 indien die parameter ingevul is, kry dit voorkeur andersins 
                'verstek die waarde na die gekose een opd ie grid op poldata1
                If intpkVoertuig = 0 Then
                    param.Value = Form1.dgvPoldataVoertuie.SelectedRows(0).Cells(0).Value
                Else
                    param.Value = intpkVoertuig
                End If

                If param.Value = Nothing Then
                    item.NoMatch = True
                    Return Nothing
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    Exit Function
                End If

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuieByPrimaryKey", param)

                If reader.Read() Then
                    If reader("ANDER") IsNot DBNull.Value Then
                        item.ANDER = reader("ANDER")
                    End If
                    If reader("CourtesyVehAmount") IsNot DBNull.Value Then
                        item.CourtesyVehAmount = reader("CourtesyVehAmount")
                    End If
                    If reader("enjinnommer") IsNot DBNull.Value Then
                        item.enjinnommer = reader("enjinnommer")
                    End If
                    If reader("GEBRUIK") IsNot DBNull.Value Then
                        item.GEBRUIK = reader("GEBRUIK")
                    End If
                    If reader("huurinstansie") IsNot DBNull.Value Then
                        item.huurinstansie = reader("huurinstansie")
                    End If
                    If reader("kilometerlesing") IsNot DBNull.Value Then
                        item.kilometerlesing = reader("kilometerlesing")
                    End If
                    If reader("kleur") IsNot DBNull.Value Then
                        item.kleur = reader("kleur")
                    End If
                    If reader("N_PLAAT") IsNot DBNull.Value Then
                        item.N_PLAAT = reader("N_PLAAT")
                    End If
                    If reader("onderstelnommer") IsNot DBNull.Value Then
                        item.onderstelnommer = reader("onderstelnommer")
                    End If
                    If reader("PREMIE") IsNot DBNull.Value Then
                        item.PREMIE = reader("PREMIE")
                    End If
                    If reader("Poskode") IsNot DBNull.Value Then
                        item.Poskode = reader("Poskode")
                    End If
                    If reader("TIPE_DEK") IsNot DBNull.Value Then
                        item.TIPE_DEK = reader("TIPE_DEK")
                    End If
                    If reader("SekuriteitBitValue") IsNot DBNull.Value Then
                        item.SekuriteitBitValue = reader("SekuriteitBitValue")
                    End If
                    If reader("vssratingbesk") IsNot DBNull.Value Then
                        item.vssratingbesk = reader("vssratingbesk")
                    End If
                    If reader("vssratingjn") IsNot DBNull.Value Then
                        item.vssratingjn = reader("vssratingjn")
                    End If

                    If reader("PremiePersentasie") IsNot DBNull.Value Then
                        item.PremiePersentasie = reader("PremiePersentasie")
                    End If
                    If reader("WAARDE") IsNot DBNull.Value Then
                        item.WAARDE = reader("WAARDE")
                    End If
                    If reader("KODE") IsNot DBNull.Value Then
                        item.KODE = reader("KODE")
                    End If
                    'kobus 16/07/2013 uncomment huurnommer
                    If reader("huurnommer") IsNot DBNull.Value Then
                        item.huurnommer = reader("huurnommer")
                    End If
                    If reader("pkVoertuie") IsNot DBNull.Value Then
                        item.pkVoertuie = reader("pkVoertuie")
                    End If
                    If reader("Voorstad") IsNot DBNull.Value Then
                        item.Voorstad = reader("Voorstad")
                    End If
                    'Andriette 11/11/2013 voeg die adres by
                    If reader("adres") IsNot DBNull.Value Then
                        item.Adres = reader("adres")
                    End If
                    If reader("WaardeEkstras") IsNot DBNull.Value Then
                        item.WaardeEkstras = reader("WaardeEkstras")
                    End If
                    'Andriette 29/08/2013 voeg die huurmotor indicator by
                    If reader("Huurkoop") IsNot DBNull.Value Then
                        item.Huurkoop = reader("Huurkoop")
                    End If
                    If reader("EEU") IsNot DBNull.Value Then
                        item.EEU = reader("EEU")
                    End If
                    If reader("Jaar") IsNot DBNull.Value Then
                        item.JAAR = reader("JAAR")
                    End If
                    If reader("TIPE") IsNot DBNull.Value Then
                        item.TIPE = reader("TIPE")
                    End If

                    If reader("Motorstatus") IsNot DBNull.Value Then
                        item.motorstatus = reader("Motorstatus")
                    End If
                    If reader("waardetipe") IsNot DBNull.Value Then
                        item.waardetipe = reader("waardetipe")
                    End If

                    If reader("adres2") IsNot DBNull.Value Then
                        item.adres2 = reader("adres2")
                    End If

                    If reader("areabeskrywing") IsNot DBNull.Value Then
                        item.areabeskrywing = reader("areabeskrywing")
                    End If

                    If reader("Ingevoer") IsNot DBNull.Value Then
                        item.ingevoer = reader("Ingevoer")
                    End If
                    If reader("laeprofielbande") IsNot DBNull.Value Then
                        item.laeprofielbande = reader("laeprofielbande")
                    End If

                    If reader("motorplan") IsNot DBNull.Value Then
                        item.motorplan = reader("motorplan")
                    End If
                    If reader("oornagbeskrywing") IsNot DBNull.Value Then
                        item.oornagbeskrywing = reader("oornagbeskrywing")
                    End If
                    If reader("kmperjaar") IsNot DBNull.Value Then
                        item.kmperjaar = reader("kmperjaar")
                    End If
                    If reader("genombestuurder1") IsNot DBNull.Value Then
                        item.genombestuurder1 = reader("genombestuurder1")
                    End If
                    If reader("genombestuurder2") IsNot DBNull.Value Then
                        item.genombestuurder2 = reader("genombestuurder2")
                    End If
                    If reader("Genombestgebore1") IsNot DBNull.Value Then
                        item.genombestgebore1 = reader("Genombestgebore1")
                    End If

                    If reader("Genombestgebore2") IsNot DBNull.Value Then
                        item.genombestgebore2 = reader("Genombestgebore2")
                    End If

                    If reader("gereeldebestuurder1") IsNot DBNull.Value Then
                        item.gereeldebestuurder1 = reader("gereeldebestuurder1")
                    End If
                    If reader("gereeldebestuurder2") IsNot DBNull.Value Then
                        item.gereeldebestuurder2 = reader("gereeldebestuurder2")
                    End If
                    If reader("gereeldebestuurder3") IsNot DBNull.Value Then
                        item.gereeldebestuurder3 = reader("gereeldebestuurder3")
                    End If
                    If reader("gereeldebestuurder4") IsNot DBNull.Value Then
                        item.gereeldebestuurder4 = reader("gereeldebestuurder4")
                    End If
                    If reader("gereeldebestgebore1") IsNot DBNull.Value Then
                        item.gereeldebestgebore1 = reader("gereeldebestgebore1")
                    End If

                    If reader("gereeldebestgebore2") IsNot DBNull.Value Then
                        item.gereeldebestgebore2 = reader("gereeldebestgebore2")
                    End If

                    If reader("gereeldebestgebore3") IsNot DBNull.Value Then
                        item.gereeldebestgebore3 = reader("gereeldebestgebore3")
                    End If

                    If reader("gereeldebestgebore4") IsNot DBNull.Value Then
                        item.gereeldebestgebore4 = reader("gereeldebestgebore4")
                    End If
                    If reader("kmlesingdatum") IsNot DBNull.Value Then
                        item.kmlesingdatum = reader("kmlesingdatum")
                    End If
                    If reader("motorplankm") IsNot DBNull.Value Then
                        item.motorplankm = reader("motorplankm")
                    End If
                    If reader("persentasiewaarde") IsNot DBNull.Value Then
                        item.persentasiewaarde = reader("persentasiewaarde")
                    End If
                    If reader("premievoertuig") IsNot DBNull.Value Then
                        item.premievoertuig = reader("premievoertuig")
                    End If
                    If reader("premieekstras") IsNot DBNull.Value Then
                        item.premieekstras = reader("premieekstras")
                    End If
                    If reader("waardevoertuig") IsNot DBNull.Value Then
                        item.waardevoertuig = reader("waardevoertuig")
                    End If

                    If reader("huurkoop") IsNot DBNull.Value Then
                        item.Huurkoop = reader("huurkoop")
                    End If
                    If reader("Motorhuis") IsNot DBNull.Value Then
                        item.MotorHuis = reader("Motorhuis")
                    End If
                    'Andriette 25/03/2014 voeg die eienaar by die lys
                    If reader("eienaar") IsNot DBNull.Value Then
                        item.eienaar = reader("eienaar")
                    End If
                    'Andriette 22/04/2014
                    If reader("Stad") IsNot DBNull.Value Then
                        item.stad = reader("stad")
                    End If
                    item.NoMatch = False
                Else
                    item.NoMatch = True
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function

    Public Function FetchMotor() As MontorEntity
        Dim item As MontorEntity = New MontorEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@KODE", SqlDbType.NVarChar)
                param.Value = VoertuigDetail.txtKode.Text

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchMotor", param)

                If reader.Read() Then
                    If reader("BEGIN_DATUM") IsNot DBNull.Value Then
                        item.Begin = reader("BEGIN_DATUM")
                    End If
                    If reader("CC") IsNot DBNull.Value Then
                        item.CC = reader("CC")
                    End If
                    If reader("CYLINDER") IsNot DBNull.Value Then
                        item.Cyl = reader("CYLINDER")
                    End If
                    If reader("EIND_DATUM") IsNot DBNull.Value Then
                        item.Einde = reader("EIND_DATUM")
                    End If
                    If reader("MAAK") IsNot DBNull.Value Then
                        item.Fabrikaat = reader("MAAK")
                    End If
                    If reader("INRUIL") IsNot DBNull.Value Then
                        item.Inruil_R = reader("INRUIL")
                    End If
                    If reader("JAAR") IsNot DBNull.Value Then
                        item.Jr = reader("JAAR")
                    End If
                    If reader("KODE") IsNot DBNull.Value Then
                        item.KODE = reader("KODE")
                    End If
                    If reader("KOOP") IsNot DBNull.Value Then
                        item.Koop_R = reader("KOOP")
                    End If
                    If reader("BESK") IsNot DBNull.Value Then
                        item.Model_beskrywing = reader("BESK")
                    End If
                    If reader("NUUT") IsNot DBNull.Value Then
                        item.Nuut_R = reader("NUUT")
                    End If
                    If reader("TIPE") IsNot DBNull.Value Then
                        item.TIPE = reader("TIPE")
                    End If
                    item.NoMatch = False
                Else
                    item.NoMatch = True
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function

    Public Function FetchAlle_Tipe2() As Alle_Tipe2Entity
        Dim item As Alle_Tipe2Entity = New Alle_Tipe2Entity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@Eistipekode", SqlDbType.Int)

                alle_risiko = FetchAlleriskByPrimarykey()
                If IsNothing(alle_risiko) Then
                    item.NoMatch = True
                    ' Andriette 07/03/2013 Maak warning reg
                    Return Nothing
                    Exit Function
                End If
                If alle_risiko.Tipe2 = Nothing Then
                    item.NoMatch = True
                    ' Andriette 07/03/2013 Maak warning reg
                    Return Nothing
                    Exit Function
                Else
                    param.Value = alle_risiko.Tipe2
                End If

                'param.Value = alle_risiko.Tipe2

                'If param.Value = Nothing Then
                '    item.NoMatch = True
                '    Exit Function
                'End If

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAlle_tipe", param)

                If reader.Read() Then
                    If reader("Afdeling") IsNot DBNull.Value Then
                        item.Afdeling = reader("Afdeling")
                    End If
                    If reader("Eistipe") IsNot DBNull.Value Then
                        item.Eistipe = reader("Eistipe")
                    End If
                    If reader("cancelled") IsNot DBNull.Value Then
                        item.cancelled = reader("cancelled")
                    End If
                    If reader("EistipeEngels") IsNot DBNull.Value Then
                        item.EistipeEngels = reader("EistipeEngels")
                    End If
                    If reader("Eistipekode") IsNot DBNull.Value Then
                        item.Eistipekode = reader("Eistipekode")
                    End If
                    If reader("Hollardkat") IsNot DBNull.Value Then
                        item.Hollardkat = reader("Hollardkat")
                    End If
                    If reader("Hollardkatbesk") IsNot DBNull.Value Then
                        item.Hollardkatbesk = reader("Hollardkatbesk")
                    End If
                    item.NoMatch = False
                Else
                    item.NoMatch = True
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item

    End Function

    Public Function FetchVoertuieEkstras() As List(Of VoertuieEkstrasEnity)
        Dim item As VoertuieEkstrasEnity = New VoertuieEkstrasEnity()
        Dim list As New List(Of VoertuieEkstrasEnity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Dim param As New SqlParameter("@pkVoertuieEkstras", SqlDbType.Int)
                'param.Value = DBNull.Value
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuieEkstrasByPrimaryKey") ', param)
                Do While reader.Read
                    If reader.Read Then

                        If reader("pkVoertuieEkstras") IsNot DBNull.Value Then
                            item.pkVoertuieEkstras = reader("pkVoertuieEkstras")
                        End If
                        If reader("fkVoertuieEkstraTipe") IsNot DBNull.Value Then
                            item.fkVoertuieEkstraTipe = reader("fkVoertuieEkstraTipe")
                        End If
                        If reader("Beskrywing") IsNot DBNull.Value Then
                            item.Beskrywing = reader("Beskrywing")
                        End If
                        If reader("Waarde") IsNot DBNull.Value Then
                            item.Waarde = reader("Waarde")
                        End If

                        If reader("fkVoertuie") IsNot DBNull.Value Then
                            item.fkVoertuie = reader("fkVoertuie")
                        End If

                        If reader("Premie") IsNot DBNull.Value Then
                            item.Premie = reader("Premie")
                        End If
                        If reader("DatumIn") IsNot DBNull.Value Then
                            item.DatumIn = reader("DatumIn")
                        End If
                        If reader("DatumWysig") IsNot DBNull.Value Then
                            item.DatumWysig = reader("DatumWysig")
                        End If
                        If reader("Deleted") IsNot DBNull.Value Then
                            item.Deleted = reader("Deleted")
                        End If
                        If reader("Fabrikaat") IsNot DBNull.Value Then
                            item.Fabrikaat = reader("Fabrikaat")
                        End If
                        If reader("Model") IsNot DBNull.Value Then
                            item.Model = reader("Model")
                        End If

                        item.NoMatch = False
                    Else
                        item.NoMatch = True
                    End If
                Loop
                list.Add(item)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return list
    End Function

    'Andriette kry al die polisnommer van die hu7is tabel as waar die 1ste adres lyn match
    'Andriette 19/09/2013 veraner na 'n funksie en return die string van polisnommers
    Public Function genCheckUniquePtyAddress(ByRef strAddress As String, ByRef strPolisno As String, ByRef intPkHuis As Integer, ByRef blnUnique As Boolean, ByRef strPolicyFound As String)
        Dim strPolisnommers As String = ""

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@pkHuis", SqlDbType.Int), _
                                                New SqlParameter("@adres_h1", SqlDbType.NVarChar)}
                params(0).Value = intPkHuis
                params(1).Value = strAddress

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchHuisByPersoon]", params)
                If reader.HasRows Then
                    While reader.Read
                        If reader("polisno") IsNot DBNull.Value Then
                            strPolisnommers = strPolisnommers + reader("polisno") + ", "
                        End If
                    End While

                End If
                'Andriette 19/09/2013 haal die laaste komma uit
                If strPolisnommers.Length > 0 Then
                    strPolisnommers = strPolisnommers.Substring(0, strPolisnommers.Length - 2)
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return strPolisnommers
    End Function

    Public Function FetchVoertuieForPremie() As List(Of VoertuieEntity)

        Dim list As List(Of VoertuieEntity) = New List(Of VoertuieEntity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                param.Value = Persoonl.POLISNO

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchVoertuie_For_PremieDetails]", param)
                ' Andriette 13/03/2013 Verander om al die voertuie in berekening te bring en nie net die eerste nie

                Do While reader.Read()
                    'Dim item As EntityVoertuie = New EntityVoertuie()
                    Dim item As VoertuieEntity = New VoertuieEntity()
                    If reader("maak") IsNot DBNull.Value Then
                        item.Maak = reader("maak")
                    End If
                    If reader("besk") IsNot DBNull.Value Then
                        item.Besk = reader("besk")
                    End If
                    If reader("eeu") IsNot DBNull.Value Then
                        item.EEU = reader("eeu")
                    End If
                    If reader("jaar") IsNot DBNull.Value Then
                        item.JAAR = reader("jaar")
                    End If
                    If reader("n_plaat") IsNot DBNull.Value Then
                        item.N_PLAAT = reader("n_plaat")
                    End If
                    If reader("PremieVoertuig") IsNot DBNull.Value Then
                        item.PREMIE = reader("PremieVoertuig")
                    End If
                    If reader("Cancelled") IsNot DBNull.Value Then
                        item.Cancelled = reader("Cancelled")
                    End If
                    'Andriette 09/04/2013
                    If reader("Premie") IsNot DBNull.Value Then
                        item.PREMIE = reader("Premie")
                    End If
                    list.Add(item)
                Loop

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return list
    End Function
    Public Function FetchAreaForPremie() As AreaEntity
        Dim item As AreaEntity = New AreaEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@Area_kode", SqlDbType.NVarChar)
                param.Value = Persoonl.Area
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAreaByPolisNo", param)

                If reader.Read() Then
                    If reader("Area_Besk") IsNot DBNull.Value Then
                        item.Area_Besk = reader("Area_Besk")
                    End If
                    If reader("Area_Windskerm_Bybet") IsNot DBNull.Value Then
                        item.Area_Windskerm_Bybet = reader("Area_Windskerm_Bybet")
                    End If
                    If reader("arkommpers") IsNot DBNull.Value Then
                        item.arkommpers = reader("arkommpers")
                    End If
                    If reader("Datumnielewendig") IsNot DBNull.Value Then
                        item.Datumnielewendig = reader("Datumnielewendig")
                    End If
                    If reader("Area_Besk") IsNot DBNull.Value Then
                        item.DisplayField = reader("Area_Besk")
                    End If
                    If reader("fkversekeraar") IsNot DBNull.Value Then
                        item.fkversekeraar = reader("fkversekeraar")
                    End If
                    If reader("hbkommpers") IsNot DBNull.Value Then
                        item.hbkommpers = reader("hbkommpers")
                    End If
                    If reader("hekommpers") IsNot DBNull.Value Then
                        item.hekommpers = reader("hekommpers")
                    End If
                    If reader("Lewendig") IsNot DBNull.Value Then
                        item.Lewendig = reader("Lewendig")
                    End If
                    'If reader("Mot_Cov_e_d") IsNot DBNull.Value Then
                    '    item.Mot_Cov_e_d = reader("Mot_Cov_e_d")
                    'End If
                    If reader("Mot_Dek_Bedrag") IsNot DBNull.Value Then
                        item.Mot_Dek_Bedrag = reader("Mot_Dek_Bedrag")
                    End If
                    'If reader("Mot_Dek_e_d") IsNot DBNull.Value Then
                    '    item.Mot_Dek_e_d = reader("Mot_Dek_e_d")
                    'End If
                    If reader("Mot_Dek_Pers") IsNot DBNull.Value Then
                        item.Mot_Dek_Pers = reader("Mot_Dek_Pers")
                    End If
                    If reader("motkommpers") IsNot DBNull.Value Then
                        item.motkommpers = reader("motkommpers")
                    End If
                    If reader("pkarea") IsNot DBNull.Value Then
                        item.pkarea = reader("pkarea")
                    End If

                    If reader("tak_afkorting") IsNot DBNull.Value Then
                        item.tak_afkorting = reader("tak_afkorting")
                    End If
                    If reader("tak_bknaam") IsNot DBNull.Value Then
                        item.tak_bknaam = reader("tak_bknaam")
                    End If

                    If reader("AutoAssist") IsNot DBNull.Value Then
                        item.autoassist = reader("AutoAssist")
                    End If
                    If reader("HomeAssistanceDesc") IsNot DBNull.Value Then
                        item.homeassistancedesc = reader("HomeAssistanceDesc")
                    End If
                    If reader("HomeAssistanceTel") IsNot DBNull.Value Then
                        item.homeassistancetel = reader("HomeAssistanceTel")
                    End If

                    item.NoMatch = False
                Else
                    item.NoMatch = True
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function

    Public Function insertCellForPremie() As InCellDetailsEntity

        Dim item As InCellDetailsEntity = New InCellDetailsEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                param.Value = Persoonl.POLISNO

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[insCELL].[FetchInsCellForDetails]", param)

                If reader.Read() Then
                    If reader("phone_make") IsNot DBNull.Value Then
                        item.phone_make = reader("phone_make")
                    End If
                    If reader("phone_model") IsNot DBNull.Value Then
                        item.phone_model = reader("phone_model")
                    End If
                    If reader("Premie") IsNot DBNull.Value Then
                        item.Premie = reader("Premie")
                    End If

                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function
    Public Function FetchHuisForPremie() As List(Of HuisEntity)

        Dim list As List(Of HuisEntity) = New List(Of HuisEntity)

        ' Andriette 13/03/2013 verander om al die huise in 'n list terug te bring
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)

                param.Value = Persoonl.POLISNO

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchHuisByPersoon_For_Premie]", param)

                ' If reader.Read() Then

                Do While reader.Read()
                    Dim item As HuisEntity = New HuisEntity()
                    If reader("Cancelled") IsNot DBNull.Value Then
                        item.Cancelled = reader("Cancelled")
                    End If
                    If reader("ADRES_H1") IsNot DBNull.Value Then
                        item.ADRES_H1 = reader("ADRES_H1")
                    End If
                    If reader("Adres4") IsNot DBNull.Value Then
                        item.Adres4 = reader("Adres4")
                    End If
                    If reader("voorstad") IsNot DBNull.Value Then
                        item.voorstad = reader("voorstad")
                    End If
                    If reader("WAARDE_HE") IsNot DBNull.Value Then
                        item.WAARDE_HE = reader("WAARDE_HE")
                    End If
                    If reader("PREMIE_HE") IsNot DBNull.Value Then
                        item.PREMIE_HE = reader("PREMIE_HE")
                    End If
                    If reader("PREMIE_HB") IsNot DBNull.Value Then
                        item.PREMIE_HB = reader("PREMIE_HB")
                    End If
                    If reader("eem_premie") IsNot DBNull.Value Then
                        item.EEM_PREMIE = reader("eem_premie")
                    End If
                    If reader("eem_waarde") IsNot DBNull.Value Then
                        item.EEM_WAARDE = reader("eem_waarde")
                    End If
                    If reader("toe_waarde") IsNot DBNull.Value Then
                        item.TOE_WAARDE = reader("toe_waarde")
                    End If
                    ' Andriette 20/03/2013
                    ' voeg die toevallige skade by
                    If reader("toe_premie") IsNot DBNull.Value Then
                        item.TOE_PREMIE = reader("toe_premie")
                    End If
                    list.Add(item)

                Loop
                'End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return list
    End Function
    Public Function FetchBetaal() As BetaalEntity

        Dim item As BetaalEntity = New BetaalEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)

                param.Value = Persoonl.POLISNO

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchBetaal]", param)

                If reader.Read() Then
                    If reader("POLISNO") IsNot DBNull.Value Then
                        item.POLISNO = reader("POLISNO")
                    End If
                    If reader("DATUM") IsNot DBNull.Value Then
                        item.Datum = reader("DATUM")
                    End If
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item

    End Function
    Public Function FetchMakeLaarByPk() As EntityMakeLaar

        Dim item As EntityMakeLaar = New EntityMakeLaar()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@fkMakelaar", SqlDbType.NVarChar)
                param.Value = rsAreaBrief.fkmakelaar

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchMakelaarByPk]", param)

                If reader.Read() Then
                    If reader("pkMakelaar") IsNot DBNull.Value Then
                        item.pkMakelaar = reader("pkMakelaar")
                    End If
                    If reader("BeskrywingAfr") IsNot DBNull.Value Then
                        item.BeskrywingAfr = reader("BeskrywingAfr")
                    End If
                    If reader("BeskrywingEng") IsNot DBNull.Value Then
                        item.BeskrywingEng = reader("BeskrywingEng")
                    End If
                    If reader("DateCommenced") IsNot DBNull.Value Then
                        item.DateCommenced = reader("DateCommenced")
                    End If
                    If reader("DateCancelled") IsNot DBNull.Value Then
                        item.DateCancelled = reader("DateCancelled")
                    End If
                    If reader("PreFix") IsNot DBNull.Value Then
                        item.PreFix = reader("PreFix")
                    End If
                    If reader("fkUMA") IsNot DBNull.Value Then
                        item.fkUMA = reader("fkUMA")
                    End If
                    If reader("Makelaar_afkorting") IsNot DBNull.Value Then
                        item.Makelaar_afkorting = reader("Makelaar_afkorting")
                    End If
                    If reader("Makelaar_Logo") IsNot DBNull.Value Then
                        item.Makelaar_Logo = reader("Makelaar_Logo")
                    End If
                    If reader("Makelaar_LogoLand") IsNot DBNull.Value Then
                        item.Makelaar_LogoLand = reader("Makelaar_LogoLand")
                    End If
                    If reader("Makelaar_groep") IsNot DBNull.Value Then
                        item.Makelaar_groep = reader("Makelaar_groep")
                    End If
                    If reader("Makelaar_groepEng") IsNot DBNull.Value Then
                        item.Makelaar_groepEng = reader("Makelaar_groepEng")
                    End If
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function

    Public Function FetchVerwysdesAsluitings() As VerwysdesAfsluitingsEntity


        Dim item As VerwysdesAfsluitingsEntity = New VerwysdesAfsluitingsEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVerwysdesAsluitings")

                Do While reader.Read

                    If reader("pkVerwysdesAfsluitings") IsNot DBNull.Value Then
                        item.pkVerwysdesAfsluitings = reader("pkVerwysdesAfsluitings")
                    End If
                    If reader("fkVerwysdes") IsNot DBNull.Value Then
                        item.fkVerwysdes = reader("fkVerwysdes")
                    End If
                    If reader("DatumAfgesluit") IsNot DBNull.Value Then
                        item.DatumAfgesluit = reader("DatumAfgesluit")
                    End If
                    If reader("Kommissie") IsNot DBNull.Value Then
                        item.Kommissie = reader("Kommissie")
                    End If
                Loop
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function
    'Andriette 11/08/2014 skuif na die constants tabel en entity
    'Public Function gen_getPlipCoverValue(ByRef plipPremium As String) As Double
    '    'All personal liability cover will be R20 000 000 regardless of the premium
    '    gen_getPlipCoverValue = 20000000
    'End Function
    Public Function FetchPKvoertuie() As VoertuieEntity
        Dim item As VoertuieEntity = New VoertuieEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@Language", SqlDbType.Int)}
                params(0).Value = Persoonl.POLISNO
                params(1).Value = Persoonl.TAAL
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.ReportFetchVoertuie", params)
                If reader.Read() Then
                    If reader("pkVoertuie") IsNot DBNull.Value Then
                        item.pkVoertuie = reader("pkVoertuie")
                    End If
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function
    Public Function ReportFetchHuisPk() As HuisEntity
        Dim item As HuisEntity = New HuisEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@Language", SqlDbType.Int)}
                params(0).Value = Persoonl.POLISNO
                params(1).Value = Persoonl.TAAL

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[ReportFetchPropertyDetails]", params)
                Do While reader.Read

                    If reader("pkHuis") IsNot DBNull.Value Then
                        item.pkHuis = reader("pkHuis")
                    End If
                Loop
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function

    Public Function ReportFetchEndosidentifikasie() As Endos2001Entity
        Dim item As Endos2001Entity = New Endos2001Entity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@branchCode", SqlDbType.NVarChar)}
                params(0).Value = Persoonl.POLISNO
                params(1).Value = Persoonl.Area
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[ReportFetchEndosidentifikasie]", params)
                Do While reader.Read
                    If reader("endosidentifikasie") IsNot DBNull.Value Then
                        item.Endosidentifikasie = reader("endosidentifikasie")
                    End If
                Loop
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function

    Public Function ReportFetchLangTermPolicy() As LangtermynPolis
        Dim item As LangtermynPolis = New LangtermynPolis()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar)}

                params(0).Value = Persoonl.POLISNO
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[ReportGetLangtermynpolis]", params)
                Do While reader.Read
                    If reader("DatumBegin") IsNot DBNull.Value Then
                        item.DatumBegin = reader("DatumBegin")
                    End If
                    If reader("datumEindig") IsNot DBNull.Value Then
                        item.DatumEindig = reader("datumEindig")
                    End If

                    If reader("DatumBegin") IsNot DBNull.Value Then
                        If Now >= reader("DatumBegin") And Now <= reader("DatumEindig") Then
                            dteTermdateStart = reader("datumBegin")
                            dteTermdateEnd = reader("datumEindig")
                            strTermMonthCount = reader("Tydperk")
                            strTermStatus = 1
                            Exit Do
                        ElseIf Now < reader("DatumBegin") Then
                            dteTermdateStart = reader("datumBegin")
                            dteTermdateEnd = reader("datumEindig")
                            strTermMonthCount = reader("Tydperk")
                            strTermStatus = 2
                            Exit Do
                        ElseIf Now > reader("DatumBegin") Then
                            dteTermdateStart = reader("datumBegin")
                            dteTermdateEnd = reader("datumEindig")
                            strTermMonthCount = reader("Tydperk")
                            strTermStatus = 3
                            Exit Do
                        Else
                            'No term exists for this policy
                            strTermMonthCount = 1
                            strTermStatus = 4
                        End If

                    Else
                        'No term exists for this policy
                        strTermMonthCount = 1
                        strTermStatus = 5

                    End If
                Loop
                'Set descriptions according to status
                Select Case strTermStatus
                    Case 1
                        strTermDesc = dteTermdateStart & " - " & dteTermdateEnd
                        strTermStatusDesc = "Aktief"
                    Case 2
                        strTermDesc = dteTermdateStart & " - " & dteTermdateEnd
                        strTermStatusDesc = "Onaktief"
                    Case 3
                        strTermStatusDesc = "Verstreke"
                        strTermDesc = dteTermdateStart & " - " & dteTermdateEnd
                    Case 4
                        strTermDesc = "Onbekend"
                        strTermStatusDesc = "Geen termyn beskikbaar"
                    Case 5
                        strTermDesc = "n.v.t."
                        strTermStatusDesc = ""
                End Select
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function

    Public Function ReportFetchKontantTotal() As KontantEntity
        Dim item As KontantEntity = New KontantEntity()
        Dim dbltotPaid As Double = 0

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@startdate", SqlDbType.NVarChar), _
                                                New SqlParameter("@enddate", SqlDbType.NVarChar)}
                params(0).Value = Persoonl.POLISNO
                params(1).Value = Persoonl.POLISNO
                params(2).Value = Persoonl.POLISNO
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[Report_gen_getTermPolicyAmtPaid]", params)
                Do While reader.Read
                    If reader("tipe") = "TB" Then
                        dbltotPaid = dbltotPaid - reader("vord_premie")
                    Else
                        dbltotPaid = dbltotPaid + reader("vord_premie")
                    End If
                Loop
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function

    'Sub FetchEPCValue()
    '    Dim strAREAepc As String
    '    Dim intCounter As Integer
    '    Try
    '        Using conn As SqlConnection = SqlHelper.GetConnection
    '            Dim param As New SqlParameter("@AREA_BESK", SqlDbType.NVarChar)
    '            strAREAepc = Form1.cmbForm1Area.Text
    '            intCounter = strAREAepc.IndexOf(",")

    '            'param.Value = (Form1.AREA.Text)
    '            param.Value = strAREAepc.Substring(0, intCounter)

    '            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchEPC]", param)
    '            Do While reader.Read
    '                nepc = (reader("Motkommpers"))
    '            Loop
    '            If conn.State = ConnectionState.Open Then
    '                conn.Close()
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    ' T_Data.MoveFirst()
    '    ' Ander_K = Format(Val(T_Data("V_KODE")))
    'End Sub

    Public Function FillCombo(strStoredProc As String, strCodefield As String, strNameField As String, Optional ByVal strtaalField As String = "", _
                              Optional ByVal strTaal As String = "", Optional ByVal strFilter As String = "", Optional ByVal StrSortOrder As String = "", Optional strparamtype As String = "", Optional strParamWaarde As String = "") As List(Of ComboBoxEntity)
        Dim intCounter As Integer = -1
        Dim list As List(Of ComboBoxEntity) = New List(Of ComboBoxEntity)
        Dim reader As SqlDataReader
        Dim param As New SqlParameter
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                If strTaal <> "" Then
                    ' Dim param As New SqlParameter(strtaalField, SqlDbType.TinyInt)
                    param = New SqlParameter(strtaalField, SqlDbType.TinyInt)
                    param.Value = Val(strTaal)
                End If

                If StrSortOrder <> "" Then
                    '  Dim param As New SqlParameter("@sqlSortField", SqlDbType.NVarChar)
                    param = New SqlParameter("@sqlSortField", SqlDbType.NVarChar)
                    param.Value = StrSortOrder
                End If

                If strFilter <> "" And strparamtype <> "" Then
                    param = New SqlParameter(strFilter, strparamtype)
                    param.Value = strParamWaarde
                End If

                If String.IsNullOrEmpty(param.Value) Then
                    reader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strStoredProc)
                Else
                    reader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strStoredProc, param)
                End If
                While reader.Read()
                    intCounter = intCounter + 1
                    Dim Item As ComboBoxEntity = New ComboBoxEntity()
                    If strCodefield <> "" Then
                        Item.ComboBoxID = reader(strCodefield)
                    End If
                    Item.ComboBoxName = reader(strNameField)
                    Item.ComboBoxPosition = intCounter
                    list.Add(Item)
                End While
                'Andriette 06/06/2013 1.73 Indien die Area op die polis nie 'n aktiewe Area is nie sal dit nie in die Combobox vertoon nie
                'en sal die combobox leeg wees. Wys eerder "Not Available" ipv niks
                If strCodefield = "pkarea" Then
                    Dim AreaNotAvailable As New ComboBoxEntity
                    AreaNotAvailable.ComboBoxID = 99
                    AreaNotAvailable.ComboBoxName = "Not Available"
                    AreaNotAvailable.ComboBoxPosition = intCounter + 1
                    list.Add(AreaNotAvailable)
                End If

                Return list
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function

    Public Function GetComboIndex(strKode As String, lstDatasource As List(Of ComboBoxEntity)) As Integer

        Dim intcounter As Integer = -1
        Dim intIndexGevind As Integer = -1
        For Each lstEntry In lstDatasource
            intcounter = intcounter + 1

            If lstEntry.ComboBoxID = strKode Then
                intIndexGevind = intcounter
                Exit For
            End If
        Next

        Return intIndexGevind
    End Function

    Sub BindAreaCombo()

        Form1.AREA.ValueMember = "ComboBoxID"
        Form1.AREA.DisplayMember = "ComboBoxName"
        Form1.AREA.DataSource = FillCombo("poldata5.ListArea", "pkarea", "DisplayField", "", "")

    End Sub
    Sub BindBemarker()
        ' Andriette 17/04/2013 Verander die bemarker na die COMBOBOXES entity
        Form1.VANWIE.DataSource = Nothing
        Form1.VANWIE.ValueMember = "ComboBoxID"
        Form1.VANWIE.DisplayMember = "ComboBoxName"
        Form1.VANWIE.DataSource = FillCombo("poldata5.Listbemarker", "kode_bem_num", "naam", "", "")
    End Sub
    Sub BindOudstudentinstansie()
        Form1.Oudstudentinstansie.DisplayMember = "INSTANSIENAAM"
        Form1.Oudstudentinstansie.ValueMember = "INSTANSIENAAM"
        Form1.Oudstudentinstansie.DataSource = ListOUDSTUDENT()
    End Sub

    Sub BindCombo1()
        ' Andriette 26/04/2013 vervang eerder met loop dit het dieselfde effek met baie minder lyne
        For intDisc = 0.05 To 3.0 Step 0.01
            Form1.Combo1.Items.Add(FormatNumber(intDisc, 2))
            If intDisc = 3.0 Then
                Exit For
            End If
        Next

    End Sub
    Sub Bindplip2()
        Form1.plip2.Items.Clear()
        Form1.plip2.Items.Add("2.00")
        Form1.plip2.Items.Add("3.00")
        Form1.plip2.Items.Add("4.00")
        Form1.plip2.Items.Add("5.00")
        Form1.plip2.Items.Add("6.00")
        Form1.plip2.Items.Add("11.00")
        Form1.plip2.Items.Add("12.50")
        Form1.plip2.SelectedIndex = -1
    End Sub
    Sub Bindtitel(ByVal intTaal As Integer)
        'Andriette 31/10/2013 as taal nognie gekies is nie, kies  
        Form1.TITEL.DataSource = FillCombo("[poldata5].[ListTitle]", "ID", "Title", "@Languange", intTaal)
        Form1.TITEL.DisplayMember = "ComboBoxName"
        Form1.TITEL.ValueMember = "ComboBoxID"
    End Sub
    Sub BindBYBET_K(ByVal languange As Integer)
        Form1.BYBET_K.DataSource = ListBYBET_K(languange)
    End Sub
    'Andriette 10/02/2014 vul volgens die taal

    Sub BindPayMonth(ByVal intTaal As Integer)
        Form1.cmbPayMonthYear.Items.Clear()
        If intTaal = 0 Then 'Afrikaans
            Form1.cmbPayMonthYear.Items.Add("Januarie")
            Form1.cmbPayMonthYear.Items.Add("Februarie")
            Form1.cmbPayMonthYear.Items.Add("Maart")
            Form1.cmbPayMonthYear.Items.Add("April")
            Form1.cmbPayMonthYear.Items.Add("Mei")
            Form1.cmbPayMonthYear.Items.Add("Junie")
            Form1.cmbPayMonthYear.Items.Add("Julie")
            Form1.cmbPayMonthYear.Items.Add("Augustus")
            Form1.cmbPayMonthYear.Items.Add("September")
            Form1.cmbPayMonthYear.Items.Add("Oktober")
            Form1.cmbPayMonthYear.Items.Add("November")
            Form1.cmbPayMonthYear.Items.Add("Desember")
        Else 'Engels
            Form1.cmbPayMonthYear.Items.Add("January")
            Form1.cmbPayMonthYear.Items.Add("February")
            Form1.cmbPayMonthYear.Items.Add("March")
            Form1.cmbPayMonthYear.Items.Add("April")
            Form1.cmbPayMonthYear.Items.Add("May")
            Form1.cmbPayMonthYear.Items.Add("June")
            Form1.cmbPayMonthYear.Items.Add("July")
            Form1.cmbPayMonthYear.Items.Add("August")
            Form1.cmbPayMonthYear.Items.Add("September")
            Form1.cmbPayMonthYear.Items.Add("October")
            Form1.cmbPayMonthYear.Items.Add("November")
            Form1.cmbPayMonthYear.Items.Add("December")
        End If
    End Sub


    ' Purpose:  Om die tussentydse verwysingskomissie te bereken vir die Referrals skerm
    ' Inputs:   Verwyser, verwysde
    ' Outputs:  Tussentydse verwysingskommissie
    ' Author:   Andriette 
    ' Date:     25/06/2013 
    Public Function CalculateInterimReferralCommission(ByRef strVerwyser As String, ByRef strVerwysde As String)
        Dim dblCommissionCalculated As Double = 0.0
        Dim strPolisnommerVerwysde As String = ""
        Dim dblPremieVoorKorting As Decimal = 0
        Dim dblAfslag As Decimal = 0
        Dim dblPremienakorting As Decimal = 0

        'Andriette 07/08/2013 die berekening word gedoen op die verwysde se premie nie die verwyser se premie nie
        'dblCommissionCalculated = (Form1.lblSubtotaalNaKorting.Text * (1 - Constants.DebitOrderPerc)) * Constants.Korting
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@Verwyser", SqlDbType.NVarChar)
                param.Value = strVerwysde
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchPersoonlForVerwysdes]", param)

                If reader.Read Then
                    If reader("polisno") Then
                        strPolisnommerVerwysde = reader("Polisno")
                    End If
                    If reader("Subtotaal") Then
                        dblPremieVoorKorting = reader("subtotaal")
                    End If
                    If reader("eispers") Then
                        dblAfslag = reader("eispers")
                    End If
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
            Exit Function
        End Try
        dblPremienakorting = dblPremieVoorKorting * dblAfslag
        'Andriette 08/08/2013 vervang hierdie met die regte formule
        '  dblCommissionCalculated = (Form1.lblSubtotaalNaKorting.Text * (1 - Constants.DebitOrderPerc)) * Constants.Korting
        dblCommissionCalculated = (dblPremienakorting * (1 - Constants.DebitOrderPerc)) * Constants.Korting
        ' Subtotaal

        'Korting
        ' Onderversekeraar se kostes default ons nou na 2.5%
        'formule = ((subtotaal - korting) -2.5% ) * 5% korting op verwyser
        'Andriette haal truncate uit
        'dblCommissionCalculated = Math.Truncate(dblCommissionCalculated * 100)
        'dblCommissionCalculated = dblCommissionCalculated / 100
        Return FormatNumber(dblCommissionCalculated, 2)
    End Function

    ' Andriette 02/09/2013 Bereken die sasria premie
    Public Function Bereken_Sasria(Optional ByVal strPolisnommer As String = "") As Decimal
        Dim dblSasriaPrem As Decimal = 0
        Dim dblAllriskTotalValue As Decimal = 0
        Dim dblHuiseTotalValue As Decimal = 0
        Dim dblVoertuieTotalValue As Decimal = 0
        Dim arrVoertuig As Array = {}
        Dim lstAlleRisiko As List(Of ALLERISKEntity) = New List(Of ALLERISKEntity)
        Dim lstHuis As List(Of HuisEntity) = New List(Of HuisEntity)
        Dim dblSASHuis As Decimal = 0
        Dim dblSASAlleRisiko As Decimal = 0
        Dim dblSASVoertuig As Decimal = 0

        'Andriette 02/09/2013 
        'As die huise + alle risiko se totaal bereken < R3.00 maak dit R3
        ' Voertuie - maak die bedrag met elke voertuig

        arrVoertuig = getPremieForVoertuie()

        lstAlleRisiko = ListALLERISKByPolisno(glbPolicyNumber)

        If IsNothing(lstAlleRisiko) Then
            ' Exit Try
        Else
            For Each allerisikoItem In lstAlleRisiko
                If allerisikoItem.Premie > 0 Then
                    dblAllriskTotalValue = dblAllriskTotalValue + allerisikoItem.Waarde
                End If
            Next
        End If

        'Complain when adding new person
        lstHuis = ListHuis(glbPolicyNumber)
        If IsNothing(lstHuis) Then

        Else
            For Each huisinfo In lstHuis
                dblHuiseTotalValue = dblHuiseTotalValue + huisinfo.WAARDE_HB + huisinfo.WAARDE_HE
            Next
        End If
        dblSASVoertuig = arrVoertuig(0) * Constants.MotorSasria

        dblSASHuis = dblHuiseTotalValue * Constants.Sasria_h
        dblSASAlleRisiko = dblAllriskTotalValue * Constants.Sasria_h

        If (dblSASHuis + dblSASAlleRisiko) <> 0 And dblSASHuis + dblSASAlleRisiko < 3.0 Then
            dblSasriaPrem = 3 + dblSASVoertuig
        Else
            dblSasriaPrem = dblSASHuis + dblSASAlleRisiko + dblSASVoertuig
        End If

        dblSasriaPrem = dblSasriaPrem

        Return FormatNumber(dblSasriaPrem, 2)

    End Function
    'Andriette 07/02/214
    'Delete the orphan rekords wat agterbly as prosesse gecancel word
    Public Sub DeleteOrphanRecords(ByVal strVeld As String, ByVal strWaarde As String, ByVal strTabelNaam As String)

        If strVeld <> "" Then
            Try
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim params() As SqlParameter = {New SqlParameter("@Linkfield", SqlDbType.NChar), _
                                                    New SqlParameter("@LinkfieldValue", SqlDbType.NChar), _
                                                    New SqlParameter("@Tablename", SqlDbType.NChar)}

                    params(0).Value = strVeld
                    params(1).Value = strWaarde
                    params(2).Value = strTabelNaam

                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[DeleteOrphanRecordTable]", params)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                End Using

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If

    End Sub

    'Andriette 28/03/2014 Funksie wat die global variables, huise_sub, alle_sub en Motors_sub update

    Public Sub BFUpdateItemsSubTotals(strPolisno)

        'Linkie 03/07/2012 - alle risiko
        Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar)}
        'param(0).Value = item.POLISNO
        param(0).Value = strPolisno

        Dim readers As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAlleriskByPolisno", param)
        dblalle_sub = 0
        Do While readers.Read
            dblalle_sub = dblalle_sub + readers("Premie")
        Loop
        'Linkie 03/07/2012 - Huise
        Dim paramH() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar)}
        'paramH(0).Value = item.POLISNO
        paramH(0).Value = strPolisno

        Dim readerH As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchHuisByPolisno", paramH)
        dblHuise_Sub = 0
        Do While readerH.Read
            dblHuise_Sub = dblHuise_Sub + Val(readerH("Premie_he")) + Val(readerH("Premie_hb")) + Val(readerH("toe_premie")) + Val(readerH("eem_premie"))
        Loop
        'Linkie 03/07/2012 - motors
        Dim paramM() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar)}
        ' paramM(0).Value = item.POLISNO
        paramM(0).Value = strPolisno

        Dim readerM As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuieForPremie", paramM)
        dblMotor_sub = 0
        Do While readerM.Read
            dblMotor_sub = dblMotor_sub + Val(readerM("Premie"))
        Loop
        'Linkie 03/07/2012 - subtotaal
        dblsubtot = dblHuise_Sub + dblalle_sub + dblMotor_sub
        dblsubtotaal = dblHuise_Sub + dblalle_sub + dblMotor_sub
    End Sub
    'Andriette 17/06/2014
    'Moet die gevraagde inligting van 'n gegewe polisnommer terugbring uit die persoonl tabel
    Public Function poldata1_FetchDetailOnPolicy(strField As String, strPolicyNumber As String)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar)}
                params(0).Value = strPolicyNumber
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlbyPolisno", params)
                If reader.Read Then
                    If reader(strField) IsNot DBNull.Value Then
                        Return reader(strField)
                    Else
                        Return ""
                    End If
                Else
                    Return ""
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return Nothing
        End Try
    End Function
End Class

