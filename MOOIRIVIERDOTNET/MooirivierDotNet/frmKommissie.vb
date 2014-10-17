Option Strict Off
Option Explicit On

Imports System.Data.SqlClient
Imports DAL


Friend Class frmKommissie
    Inherits System.Windows.Forms.Form
    Private Sub btnBerekenkommissie_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnBerekenkommissie.Click

        'VerwysdesListFrm.GridVerwysdes.col = 1
        Berekenkommissie((VerwysdesListFrm.dgvVerwysdes.SelectedCells.Item(1).Value), (Me.dteAfsluit))

    End Sub

    Public Sub Berekenkommissie(ByRef strVerwysde As Object, ByRef dteAfsluit As Object)
        Dim sngVerwyskommissie As Object
        Dim sngKOTotaal As Object
        Dim sngVtTotaal As Object
        Dim sngVorderPremie As Object
        Dim sngPremie2 As Object
        Dim sngOnderlyn As Object
        Dim sngEispers As Object
        Dim sngSubtotaal As Object
        'Dim sSql As Object
        sngSubtotaal = 0
        sngEispers = 0
        sngOnderlyn = 0
        sngPremie2 = 0
        sngVtTotaal = 0
        sngKOTotaal = 0
        sngVerwyskommissie = 0

        'Dim dbPoldata5 As DAO.Database
        'Dim rs As DAO.Recordset
        'dbPoldata5 = DAODBEngine_definst.OpenDatabase(pol_path & "\Poldata5.mdb")

        'sSql = "SELECT * from persoonl where polisno = '" & strVerwysde & "'"
        ' rs = dbPoldata5.OpenRecordset(sSql)
        rs1 = Form1.FetchPersoonlForVerwysdes(strVerwysde)

        'If Not rs.BOF And Not rs.EOF Then

        If rs1.GEKANS Then
            Me.txtKommissie.Text = CStr(0)
        Else
            GetVorigeAfsluitingtotal(strVerwysde, sngSubtotaal, sngEispers, sngOnderlyn, sngPremie2, dteAfsluit)
             If sngSubtotaal <> 0 Then

                'Kry die vorder premie
                 sngVorderPremie = getVorderPremie(strVerwysde, dteAfsluit)

                'Kry al die VT's vir MD
                If (rs1.BET_WYSE = "4") Then
                    GetVTs(strVerwysde, dteAfsluit, sngVtTotaal)
                End If

                'Kry al die Kontant ontvangstes
                GetKontantOntvangstes(strVerwysde, (Me.dtpVanaf), (Me.dtpTot), sngKOTotaal)

                'Bereken verwysingskommissie
                BerekenVerwysingskommissie(strVerwysde, sngSubtotaal, sngEispers, sngOnderlyn, sngPremie2, sngVtTotaal, sngKOTotaal, sngVerwyskommissie, sngVorderPremie, dteAfsluit)

            End If
        End If
        ' End If

    End Sub

    '* Purpose    : Get the subtotal, geen eis bonus and all premiums under the line from the vorige afsluiting
    '* Inputs     : strVerwysde
    '* Outputs    : sngSubtotaal, sngEispers, sngOnderlyn, sngPremie2, dteVorigeAfsluiting
    Public Sub GetVorigeAfsluitingtotal(ByRef strVerwysde As Object, ByRef sngSubtotaal As Object, ByRef sngEispers As Object, ByRef sngOnderlyn As Object, ByRef sngPremie2 As Object, ByRef dteVorigeAfsluiting As Object)
        'Dim sSql As Object
        'Dim poldata5 As DAO.Database
        'Dim stats5 As DAO.Database
        'Dim stats5d As DAO.Database
        'Dim rs As DAO.Recordset
         'Dim rs2 As DAO.Recordset
         'Dim rs3 As DAO.Recordset
         'Dim rs4 As DAO.Recordset

        'poldata5 = DAODBEngine_definst.OpenDatabase(pol_path & "\Poldata5.mdb")
        'stats5 = DAODBEngine_definst.OpenDatabase(pol_path & "\Stats5.mdb")
        'stats5d = DAODBEngine_definst.OpenDatabase(pol_path & "\Stats5d.mdb")

        'Kry onder die lyn totale van stats5d
        'sSql = "SELECT * from md_print_dat where Afsluit_dat = '" & CDate(dteVorigeAfsluiting) & "' AND polisno = '" & strVerwysde & "'"
        ' rs3 = stats5d.OpenRecordset(sSql)

        'Kry subtotaal en eis persentasie
         'sSql = "SELECT * from md_print2_dat where Afsluit_dat = '" & CDate(dteVorigeAfsluiting) & "' AND polisno = '" & strVerwysde & "'"

        'rs4 = stats5d.OpenRecordset(sSql)

        'If Not rs3.EOF And Not rs4.EOF Then

         '	sngSubtotaal = Val(rs3.Fields("subtotaal").Value)
          '	sngEispers = rs4.Fields("Eispers").Value
         '	sngOnderlyn = Val(rs3.Fields("Beskerm").Value) + Val(rs3.Fields("Sasprem").Value) + Val(rs3.Fields("TV_diens").Value) + Val(rs3.Fields("Polfooi").Value) + Val(rs3.Fields("Begrafnis").Value) + rs3.Fields("Plip").Value + rs4.Fields("Courtesyv").Value + rs4.Fields("Epc").Value + rs3.Fields("CareAssist").Value + rs4.Fields("Inscell").Value
         '	sngPremie2 = rs4.Fields("Premie2").Value
        'Else
          '      sngSubtotaal = 0
         '      sngEispers = 0
         '      sngOnderlyn = 0
        '      sngPremie2 = 0
        'End If

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Verwysde", SqlDbType.NVarChar), _
                                                New SqlParameter("@dteVorigeAfsluiting", SqlDbType.DateTime)}

                params(0).Value = strVerwysde
                params(1).Value = dteVorigeAfsluiting

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[Stats5d].[FetchMd_PRINT_DATForTotal]", params)

                While reader.Read()

                    If reader("sngSubtotaal") IsNot DBNull.Value Then
                        sngSubtotaal = reader("sngSubtotaal")
                    Else
                        sngSubtotaal = 0
                    End If

                    If reader("sngEispers") IsNot DBNull.Value Then
                        sngEispers = reader("sngEispers")
                    Else
                        sngEispers = 0
                    End If

                    If reader("sngOnderlyn") IsNot DBNull.Value Then
                        sngOnderlyn = reader("sngOnderlyn")
                    Else
                        sngOnderlyn = 0
                    End If
                    If reader("sngPremie2") IsNot DBNull.Value Then
                        sngPremie2 = reader("sngPremie2")
                    Else
                        sngPremie2 = 0
                    End If
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try


    End Sub

    '* Purpose    : Get the vorder premium for a specific closing date
    '* Inputs     : strverwysde, dteAfsluit

    Public Function getVorderPremie(ByRef strVerwysde As Object, ByRef dteAfsluit As Object) As Object
        Dim dblPremie As Double
        'Dim sSql As Object

        'Dim dbStats5 As DAO.Database
        'Dim rs As DAO.Recordset

        'dbStats5 = DAODBEngine_definst.OpenDatabase(pol_path & "\Stats5.mdb")
        'sSql = "SELECT * from Maand where cdate(left(Afsluit_dat,10)) = Cdate('" & dteAfsluit & "') "
        'sSql = sSql & "AND polisno = '" & strVerwysde & "'"
        'rs = dbStats5.OpenRecordset(sSql)

        'getVorderPremie = 0
        'If Not rs.BOF And Not rs.EOF Then
        '	getVorderPremie = rs.Fields("Vord_premie").Value

        'End If

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@strVerwysde", SqlDbType.NVarChar), _
                                                New SqlParameter("@dteAfsluit", SqlDbType.DateTime)}

                params(0).Value = strVerwysde
                params(1).Value = dteAfsluit

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[Stats5].[FetchMaandForVerwysdes]", params)
                If reader.HasRows Then
                    While reader.Read()
                        If reader("Vord_premie") IsNot DBNull.Value Then
                            dblPremie = reader("Vord_premie")
                            ' getVorderPremie = reader("Vord_premie")
                        Else
                            'getVorderPremie = 0
                            dblPremie = 0
                        End If

                    End While
                Else
                    dblPremie = 0
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

        Return dblPremie
    End Function

    '* Purpose    : To calculate the 'VT's for this policy holder
    '* Inputs     : strVerwysde, dteAfsluit
    '* Outputs    : sngVtTotaal
    Public Sub GetVTs(ByRef strVerwysde As Object, ByRef dteAfsluit As Object, ByRef sngVtTotaal As Object)
        'Dim sSql As Object

        'Dim dbStats5 As DAO.Database
          'Dim rs As DAO.Recordset
        'dbStats5 = DAODBEngine_definst.OpenDatabase(pol_path & "\Stats5.mdb")

          'sngVtTotaal = 0

          'sSql = "SELECT * from Maand_VT_details where polisno = '" & strVerwysde
          'sSql = sSql & "' And cdate(trans_dat) between CDate('" & (Me.dtpVanaf)._Value & "') and CDate('" & (Me.dtpTot)._Value & "')"
         'rs = dbStats5.OpenRecordset(sSql)

        'Do While Not rs.EOF
         '	sngVtTotaal = sngVtTotaal + rs.Fields("VT_Bedrag").Value
        '	rs.MoveNext()
        'Loop 
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@strVerwysde", SqlDbType.NVarChar), _
                                                New SqlParameter("@dtVanaf", SqlDbType.DateTime), _
                                                New SqlParameter("@dtTot", SqlDbType.DateTime)}

                params(0).Value = strVerwysde
                params(1).Value = Me.dtpVanaf.Value
                params(2).Value = Me.dtpTot.Value

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[Stats5].[FetchMaand_VT_detailsForVerwysdes]", params)

                While reader.Read()

                    If reader("VT_Bedrag") IsNot DBNull.Value Then
                        sngVtTotaal = sngVtTotaal + reader("VT_Bedrag")
                    Else
                        sngVtTotaal = 0
                    End If

                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try


    End Sub

    '* Purpose    : To calculate the 'VT's for this policy holder
    '* Inputs     : strVerwysde
    '* Outputs    : sngKOTotaal
    Public Sub GetKontantOntvangstes(ByRef strVerwysde As Object, ByRef dteVanaf As Object, ByRef dteTot As Object, ByRef sngKOTotaal As Object)
        Dim Tipe As Object
        'Dim sSql As Object
        'Dim dbStats5 As DAO.Database
        'Dim rs As DAO.Recordset
        'dbStats5 = DAODBEngine_definst.OpenDatabase(pol_path & "\Stats5.mdb")
        sngKOTotaal = 0

          'sSql = "SELECT * from Kontant where polisno = '" & strVerwysde & "' AND cdate(left(trans_dat,10)) between cdate('" & dteVanaf & "') and cdate('" & dteTot & "') AND Not gekans"
         'rs = dbStats5.OpenRecordset(sSql)

        'Do While Not rs.EOF
          '	If rs.Fields("tipe").Value = "MK" Or rs.Fields("tipe").Value = "MD" Or rs.Fields("tipe").Value = "ME" Or rs.Fields("tipe").Value = "LT" Or rs.Fields("tipe").Value = "VT" Or rs.Fields("tipe").Value = "EB" Or Tipe = "VB" Then
          '		sngKOTotaal = sngKOTotaal + rs.Fields("Vord_premie").Value
        '	ElseIf rs.Fields("tipe").Value = "TB" Then 
         '              'TODO ____
        '              'sngKOTotaal = sngKOTotaal - rs.Fields("Vord_premie")
        '              '______
        '          End If
        '	rs.MoveNext()
        'Loop 
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@strVerwysde", SqlDbType.NVarChar), _
                                                New SqlParameter("@dtVanaf", SqlDbType.DateTime), _
                                                New SqlParameter("@dtTot", SqlDbType.DateTime)}

                params(0).Value = strVerwysde
                params(1).Value = Me.dtpVanaf.Value
                params(2).Value = Me.dtpTot.Value

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[Stats5].[FetchKontantForVerwysdes]", params)

                While reader.Read()

                    If reader("tipe") IsNot DBNull.Value Then
                        If reader("tipe") = "MK" Or reader("tipe") = "MD" _
                        Or reader("tipe") = "ME" Or reader("tipe") = "LT" Or reader("tipe") = "VT" _
                        Or reader("tipe") = "EB" Then
                            sngKOTotaal = sngKOTotaal + reader("Vord_premie")

                        ElseIf reader("tipe") = "TB" Then
                            sngKOTotaal = sngKOTotaal - reader("Vord_premie")

                        End If
                    Else
                        Tipe = "VB"
                    End If
                End While

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try

    End Sub
    '* Purpose    : Calculate the verwysingskommissie for this policy
    '* Inputs     : strVerwysde, sngSubtotaal, sngEispers, sngOnderlyn, sngPremie2, sngVtTotaal, sngKOTotaal, sngVorderPremie, dteAfsluit
    '* Outputs    : sngVerwyskommissie
    Public Sub BerekenVerwysingskommissie(ByRef strVerwysde As Object, ByRef sngSubtotaal As Object, ByRef sngEispers As Object, ByRef sngOnderlyn As Object, ByRef sngPremie2 As Object, ByRef sngVtTotaal As Object, ByRef sngKOTotaal As Object, ByRef sngVerwyskommissie As Object, ByRef sngVorderPremie As Object, ByRef dteAfsluit As Object)
        Dim sngVersVT As Object
        Dim sngVersVorder As Object
        Dim sngVersKO As Object
        'Dim sSql As Object
        Dim sngverwysdepremie As Object
        Dim sngVerwysdekorting As Object
        Dim sngAddisionelepremie As Object
        sngVersVorder = 0
        sngVersVT = 0
        'Dim dbPoldata5 As DAO.Database
        'Dim dbStats5 As DAO.Database
         'Dim rs As DAO.Recordset
         'Dim rs2 As DAO.Recordset
         'Dim rs3 As DAO.Recordset
        'dbPoldata5 = DAODBEngine_definst.OpenDatabase(pol_path & "\Poldata5.mdb")
        'dbStats5 = DAODBEngine_definst.OpenDatabase(pol_path & "\Stats5.mdb")
       
        'Get the additional premium for the closed period
        sngAddisionelepremie = getAdditionalPremiumForClosedPeriod(strVerwysde, dteAfsluit)

        'Kry die verwysde korting vanaf poldata.ini
        sngVerwysdekorting = VerwysdesListFrm.GetVerwysdeKorting

        sngverwysdepremie = sngSubtotaal * sngEispers
        sngverwysdepremie = sngverwysdepremie

        ''Kry betaalwyse
           'sSql = "SELECT * from persoonl where polisno = '" & strVerwysde & "'"
          'rs = dbPoldata5.OpenRecordset(sSql)
        rs1 = Form1.FetchPersoonlForVerwysdes(strVerwysde)


        'sSql = "SELECT * from area where area_kode = '" & rs.Fields("area").Value & "'"
         'rs2 = dbPoldata5.OpenRecordset(sSql)

        'Bereken versekerde Kontant Ontvangste premie
        sngVersKO = sngKOTotaal - (sngKOTotaal / sngPremie2 * sngOnderlyn)

        If rs1.BET_WYSE = "4" Then 'MD
            'Bereken versekerde vorder premie
            KryversekerdeVorderpremie(strVerwysde, dteAfsluit, sngVorderPremie, rs1.BET_WYSE, rs1.Area)

            sngVersVorder = sngVorderPremie - (sngVorderPremie / sngPremie2 * sngOnderlyn)

            'Bereken versekerde VT premie
            sngVersVT = sngVtTotaal - (sngVtTotaal / sngPremie2 * sngOnderlyn)

            sngverwysdepremie = sngVersVorder - rs1.verwyskommissie + sngVersKO - sngVersVT
            '___________
        ElseIf rs1.BET_WYSE = "3" Then  'MS
            'Bereken versekerde vorder premie
            KryversekerdeVorderpremie(strVerwysde, dteAfsluit, sngVorderPremie, rs1.BET_WYSE, rs1.Area)

            sngVersVorder = sngVorderPremie - (sngVorderPremie / sngPremie2 * sngOnderlyn)

            sngverwysdepremie = sngVersVorder - rs1.verwyskommissie + sngVersKO

        Else 'MK en ME
            sngverwysdepremie = sngVersKO - rs1.verwyskommissie
            '___________
        End If

        If sngverwysdepremie > 0 Then
            sngVerwyskommissie = sngverwysdepremie * 0.975
            sngVerwyskommissie = sngVerwyskommissie * sngVerwysdekorting
            sngVerwyskommissie = sngVerwyskommissie / 1.14
            sngVerwyskommissie = sngVerwyskommissie
        Else
            sngVerwyskommissie = 0
        End If

        Me.txtPremie2.Text = sngPremie2
        Me.txtVorderpremie.Text = sngVorderPremie
        Me.txtOnderlyn.Text = sngOnderlyn
        Me.txtAddisionelepremie.Text = sngAddisionelepremie
        Me.txtKontantontvangstes.Text = sngKOTotaal
        Me.txtVT.Text = sngVtTotaal
        Me.txtKommissieKorting.Text = sngVerwysdekorting
        Me.txtKommissie.Text = sngVerwyskommissie

        Me.txtVersekerdevorderpremie.Text = sngVersVorder
        Me.txtVersekerdekontantontvangste.Text = sngVersKO
        Me.txtVersekerdeVT.Text = sngVersVT
    End Sub

    '* Purpose    : Get the additional premium for a specific closing date
    '* Inputs     : strverwysde, dteAfsluit

    Public Function getAdditionalPremiumForClosedPeriod(ByRef strVerwysde As Object, ByRef dteAfsluit As Object) As Object
        'Dim sSql As Object

        'Dim dbPoldata5 As DAO.Database
        'Dim rs As DAO.Recordset
        'dbPoldata5 = DAODBEngine_definst.OpenDatabase(pol_path & "\Poldata5.mdb")

         'sSql = "SELECT * from AddisionelePremie where Afgesluit = 1 and cdate(left(DatumAfgesluit,10)) = Cdate('" & dteAfsluit & "') "
           'sSql = sSql & "AND polisno = '" & strVerwysde & "'"
         'rs = dbPoldata5.OpenRecordset(sSql)

        getAdditionalPremiumForClosedPeriod = 0
        'If Not rs.BOF And Not rs.EOF Then
        '	getAdditionalPremiumForClosedPeriod = rs.Fields("Totaal").Value
        'End If

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@strVerwysde", SqlDbType.NVarChar), _
                                                New SqlParameter("@dteAfsluit", SqlDbType.DateTime)}

                params(0).Value = strVerwysde
                params(1).Value = dteAfsluit


                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchAddisionelePremieForVerwysdes]", params)

               
                If reader("Totaal") IsNot DBNull.Value Then
                    getAdditionalPremiumForClosedPeriod = reader("Totaal")
                Else
                    getAdditionalPremiumForClosedPeriod = 0
                End If


            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try

    End Function

    '* Purpose    : Get the versekerde vorder premium for a specific closing date
    '* Inputs     : strverwysde, dteAfsluit, strBetaalwyse, strArea
    '* Outputs    : sngVorderPremie

    Public Sub KryversekerdeVorderpremie(ByRef strVerwysde As Object, ByRef dteAfsluit As Object, ByRef sngVorderPremie As Object, ByRef strBetaalwyse As Object, ByRef strArea As Object)
        'Dim sSql As Object

        'Dim dbStats5 As DAO.Database
          'Dim rs As DAO.Recordset
        'dbStats5 = DAODBEngine_definst.OpenDatabase(pol_path & "\Stats5.mdb")
        Dim sngVorderPremieFromMaand_Puk As Decimal
        Dim sngVorderPremieFromMaand_Uovs As Decimal
        Dim sngVorderPremieFromMaand_gtbfn As Decimal
        Dim sngVorderPremieFromMaand_Gnas As Decimal
        Dim sngVorderPremieFromMaand_gmun As Decimal
        Dim sngVorderPremieFromMaand As Decimal
        
        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim params() As SqlParameter = {New SqlParameter("@strVerwysde", SqlDbType.NVarChar), _
                                            New SqlParameter("@dteAfsluit", SqlDbType.DateTime)}

            params(0).Value = strVerwysde
            params(1).Value = dteAfsluit

            Dim readerMaand_Puk As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaand_PukForVerwysdes]", params)
            If readerMaand_Puk("Vord_premie") IsNot DBNull.Value Then
                sngVorderPremieFromMaand_Puk = readerMaand_Puk("Vord_premie")
            Else
                sngVorderPremieFromMaand_Puk = 0
            End If

            Dim readerUovs As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[Fetchmaand_uovskForVerwysdes]", params)
            If readerUovs("Vord_premie") IsNot DBNull.Value Then
                sngVorderPremieFromMaand_Uovs = readerUovs("Vord_premie")
            Else
                sngVorderPremieFromMaand_Uovs = 0
            End If


            Dim readerGtbfn As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaand_gtbfn ForVerwysdes]", params)
            If readerGtbfn("Vord_premie") IsNot DBNull.Value Then
                sngVorderPremieFromMaand_gtbfn = readerGtbfn("Vord_premie")
            Else
                sngVorderPremieFromMaand_gtbfn = 0
            End If


            Dim readerGnas As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaand_gnas ForVerwysdes]", params)
            If readerGnas("Vord_premie") IsNot DBNull.Value Then
                sngVorderPremieFromMaand_Gnas = readerGnas("Vord_premie")
            Else
                sngVorderPremieFromMaand_Gnas = 0
            End If

            Dim readergmun As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaand_gmunForVerwysdes]", params)
            If readergmun("Vord_premie") IsNot DBNull.Value Then
                sngVorderPremieFromMaand_gmun = readergmun("Vord_premie")
            Else
                sngVorderPremieFromMaand_gmun = 0
            End If

            Dim readerMaand As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaandForBetaalwyse_Verwysdes]", params)
            If readerMaand("Vord_premie") IsNot DBNull.Value Then
                sngVorderPremieFromMaand = readerMaand("Vord_premie")
            Else
                sngVorderPremieFromMaand = 0
            End If

        End Using

        sngVorderPremie = 0
        Select Case strBetaalwyse
            Case "3"
                Select Case strArea
                    Case "2" 'Linkie 25/06/2008 - verander na area 2, was area 1 - Voor flagship was PUK area 1 op Potch
                        'sSql = "SELECT * from Maand_Puk where polisno = '" & strVerwysde & "' "
                        'sSql = sSql & "AND cdate(left(Afsluit_dat,10)) = cdate('" & dteAfsluit & "')"

                        sngVorderPremie = sngVorderPremieFromMaand_Puk

                    Case "1" 'Linkie 25/06/2008 - verander na area 1, was area 2 - Voor flagship was UOVS area 2 op bloem
                        'sSql = "SELECT * from maand_uovs where polisno = '" & strVerwysde & "' "
                        'sSql = sSql & "AND cdate(left(Afsluit_dat,10)) = cdate('" & dteAfsluit & "')"

                        sngVorderPremie = sngVorderPremieFromMaand_Uovs

                    Case "3"
                        'sSql = "SELECT * from maand_gtbfn where polisno = '" & strVerwysde & "' "
                        'sSql = sSql & "AND cdate(left(Afsluit_dat,10)) = cdate('" & dteAfsluit & "')"

                        sngVorderPremie = sngVorderPremieFromMaand_gtbfn

                    Case "4"
                        'sSql = "SELECT * from maand_gnas where polisno = '" & strVerwysde & "' "
                        'sSql = sSql & "AND cdate(left(Afsluit_dat,10)) = cdate('" & dteAfsluit & "')"

                        sngVorderPremie = sngVorderPremieFromMaand_Gnas

                    Case "B"
                        'sSql = "SELECT * from maand_gmun where polisno = '" & strVerwysde & "' "
                        'sSql = sSql & "AND cdate(left(Afsluit_dat,10)) = cdate('" & dteAfsluit & "')"

                        sngVorderPremie = sngVorderPremieFromMaand_gmun

                End Select
            Case "4"
                'sSql = "SELECT * from Maand where polisno = '" & strVerwysde & "' "
                'sSql = sSql & "AND cdate(left(Afsluit_dat,10)) = cdate('" & dteAfsluit & "')"

                sngVorderPremie = sngVorderPremieFromMaand

        End Select

         'rs = dbStats5.OpenRecordset(sSql)
        'sngVorderPremie = 0
        'If Not rs.BOF And Not rs.EOF Then
         '	sngVorderPremie = rs.Fields("Vord_premie").Value
        'End If

    End Sub

    Private Sub frmKommissie_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.Title & " - Referred - Commission"

    End Sub
   
    Public Function FetchMd_print_dat2() As VerwysdesEntity
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
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function

    Private Sub txtVersekerdevorderpremie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVersekerdevorderpremie.Click

    End Sub
End Class