Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports DAL
Friend Class Kontant

    Inherits BaseForm

    Public Oor2maanduitgeloopJN, UitgeloopJN, VertoonEarnedJN As Object
    Public UnEarned As Double
    Public check_teveel As Short
    Public row_tel As Object
    Public tipe_bet As Object
    Public kdat_datum_van As Object
    Public maand_tots As Object
    Public grid_trans_dat As Object
    Public grid_vord_dat As Object
    Public grid_kwitansie As Object
    Public grid_nou_ingevorder As Object
    Public jaar4 As Object
    Public vb_afdat As Object
    Public vb_jaar As Object
    Public vb_maand As Object
    Public vb_dag As Object
    Public volg_maand As Object
    Public earlybird As Single
    Public ntoebehore As Single
    Public nkorting As Object
    Public nepc As Object
    Public volg_jaar As Object
    Public gen_trans As Object
    Public kontant_tipe As Object
    Public tipe_ontv As Object
    Public check_tj As Object
    Public ing As Object
    Public pkLangtermynPolis As Object
    Public rekordgekry As Object
    Public vt_ingevorder As Object
    Public M_Debiet As MaandEntity = New MaandEntity
    Public tak_hoof As AreaByPersoonlEntity
    Public AreaTaknaam As String
    Public strKwitansie As Object
    Public dteTransaksieDatum As Date
    Public pcs_pol_path_kont As Object
    Public vtBalans As Object
    Public k_geneer_Vord_Premie As Object
    Public k_geneer_Ingevorde As Object



    Public rep_taknaam As Tak_NaamEntity
    Public e_Kontant_Ingevorde As Object
    Public ktant1 As KontantEntity
    Public Byvoeg As Short
    Public initpoleerste As Object
    Public mktjekuitprem As Object
    Public mktjekinprem As Object
    Public mdtjekuitprem As Object
    Public mdtjekinprem As Object
    Public mkkontuitprem As Object
    Public mkkontinprem As Object
    Public mdkontuitprem As Object
    Public mdkontinprem As Object
    Public TITEL As Object
    Public kdat_datum_tot_f As Object
    Public kdat_datum_van_f As Object
    Public krit_tot As Object
    Public krit_vanaf As Object
    Public kdat_datum_tot As Object
    Public datum As Object


    Public Sub kry_vt_transaksies()
        Dim vt_in_det As Object
        Dim sSql As Object
        Dim vttransdat10 As Object
        Dim grid_trans_dat As Object
        Dim grid_vt_x As Object
        Dim grid_vord_dat As Object
        Dim grid_kwitansie As Object
        Dim grid_nou_ingevorder As Object
        Dim row_tel As Object
        Dim Ctr As Object
        Dim lus As Object
        Dim count_ As Object
        Dim Kwintasie As Object
        Dim vord_premie As Object
        'Dim i As Integer
        uitstaande.Text = CStr(0)
        If Len(Me.Polisno.Text) = 0 Then
            Exit Sub
        End If



        uitstaande.Text = CStr(0)
        If Len(Polisno.Text) = 0 Then
            Exit Sub
        End If

        'inisialiseer uitstaande
        uitstaande.Text = CStr(0)

        count_ = DataGridView1.RowCount

        If DataGridView1.RowCount <> 2 Then
            For lus = 2 To count_ - 1
                DataGridView1.Rows.RemoveAt(1)
            Next
        End If


        If ((Versekerde.Text = "") And (Voorl.Text = "")) Or (Len(Me.Polisno.Text) <> 0) Then

            vt_balans = FetchVt_Balans(Persoonl.POLISNO, "", "")
            'vt_balans.Index = "PN_INDEX"
            'vt_balans.Seek("=", Polisno)
        Else
            vt_balans = FetchVt_Balans("", Voorl.Text, Versekerde.Text)
            'vt_balans.Index = "VV_INDEX"
            'vt_balans.Seek("=", Versekerde, Voorl)
        End If

        If vt_balans.Nomatch Then
            Exit Sub
        End If

        Versekerde.Text = vt_balans.VERSEKERDE
        Voorl.Text = vt_balans.VOORL
        Polisno.Text = vt_balans.polisno
        uitstaande.Text = vt_balans.VT_BALANS

        'vt_details.Index = "PVD_INDEX"
        'VT_Details.Seek(">=", Polisno, "01/01/80")


        Ctr = 0
        row_tel = 0
        vt_details = FetchVTDetails(Persoonl.POLISNO)

        If vt_details.Nomatch Then
            MsgBox("There is no VT's for this person!", 48, "Error!")
            Exit Sub
        End If

        'kry alle vt transaksies
        ' While vt_details.POLISNO = Polisno.Text
        If vt_details.POLISNO = Polisno.Text Then


            'het gebruker net uitstaandes aangevra?
            If Uitst_transaksies.Checked Then
                If vt_details.VT_BEDRAG = vt_details.VT_INGEVORDER Then GoTo ktant_einde
            End If

sit_in_grid:

            'stel volgende ry op
            row_tel = row_tel + 1

            populateGridVTDetails()

            Ctr = Ctr + 1

            Err.Clear()

volg_vt:
            'replaced with code in sp
ktant_einde:
            'replaced with code in sp
            ' End While
        End If
vt_det_uit2:

        'zeroise vt_ingevorder
        nou_ingevorder.Enabled = True
        nou_ingevorder.Text = ""

        'zeroise memo
        Me.verw1.Text = " "
        Me.verw2.Text = " "
        Me.verw3.Text = " "
        Me.verw4.Text = " "
        Me.verw5.Text = " "

        DataGridView1.Enabled = True
        If Ctr > 1 Then
            MsgBox("The person has " & Format(Ctr) & " VT!", 64, "Information...")
        End If
    End Sub
    Sub GETVTKontantAndGrid()

        Try
            vt_details = New VTDetailsEntity
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@MaandKontantTransDate", SqlDbType.DateTime), _
                                                New SqlParameter("@Vord_Premie", SqlDbType.Money), _
                                                New SqlParameter("@verw1", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw2", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw3", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw4", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw5", SqlDbType.NVarChar), _
                                                New SqlParameter("@kontant_tipe", SqlDbType.NVarChar), _
                                                New SqlParameter("@tjekno_uit", SqlDbType.NVarChar), _
                                                New SqlParameter("@tjekno_in", SqlDbType.NVarChar), _
                                                New SqlParameter("@TJEKDATUM", SqlDbType.DateTime), _
                                                New SqlParameter("@TJEKBESONDERHEDE", SqlDbType.NVarChar), _
                                                New SqlParameter("@kwit_boek", SqlDbType.NVarChar), _
                                                New SqlParameter("@Area", SqlDbType.NVarChar), _
                                                New SqlParameter("@CurrentDate", SqlDbType.DateTime), _
                                                New SqlParameter("@tipe_ontv", SqlDbType.NVarChar), _
                                                New SqlParameter("@VT_INGEVORDER", SqlDbType.Money)}


                params(0).Value = Persoonl.POLISNO
                params(1).Value = vt_details.TRANS_DAT 'DataGridView1.SelectedRows(0).Cells(8).Value
                params(2).Value = Me.nou_ingevorder.Text

                If IsDBNull(Me.verw1.Text) Then
                    Me.verw1.Text = " "
                End If
                If IsDBNull(Me.verw2.Text) Then
                    Me.verw2.Text = " "
                End If
                If IsDBNull(Me.verw3.Text) Then
                    Me.verw3.Text = " "
                End If
                If IsDBNull(Me.verw4.Text) Then
                    Me.verw4.Text = " "
                End If
                If IsDBNull(Me.verw5.Text) Then
                    Me.verw5.Text = " "
                End If




                params(3).Value = Me.verw1.Text
                params(4).Value = Me.verw2.Text
                params(5).Value = Me.verw3.Text
                params(6).Value = Me.verw4.Text
                params(7).Value = Me.verw5.Text
                params(8).Value = kontant_tipe

                If Me.Tjek.Checked <> 0 Then
                    If terugbetaling.Checked Or check_tj Then
                        params(9).Value = Tjekno.Text
                        params(10).Value = DBNull.Value
                    Else
                        params(9).Value = DBNull.Value
                        params(10).Value = Tjekno.Text
                    End If
                Else
                    params(9).Value = DBNull.Value
                    params(10).Value = DBNull.Value
                End If

                If Me.Tjek.Checked Then
                    params(11).Value = Tjekdatum.Text
                    params(12).Value = Tjekbesonderhede.Text
                Else
                    params(11).Value = DBNull.Value
                    params(12).Value = DBNull.Value
                End If

                params(13).Value = kwit_boek.Text
                params(14).Value = Persoonl.Area
                params(15).Value = Now
                params(16).Value = tipe_ontv

                If IsDBNull(vt_details.VT_INGEVORDER) Then
                    params(17).Value = DBNull.Value
                Else
                    params(17).Value = params(17).Value + nou_ingevorder.Text
                End If

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Stats5.UpdateKontantAndVTKontant", params)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub
    Public Sub kry_mk_transaksies()

        'Dim jaar4 As Object
        'Dim vb_afdat As Object
        'Dim vb_jaar As Object
        Dim check_vb As Object
        'Dim vb_maand As Object
        Dim volg_maand As Object
        Dim volg_jaar As Object
        Dim sSql As Object
        Dim mktransdat10 As Object
        Dim grid_trans_dat As Object
        Dim grid_vord_dat As Object
        Dim grid_kwitansie As Object
        Dim grid_nou_ingevorder As Object
        Dim tot_jm As Object
        Dim vanaf_jm As Object
        Dim boek_jm As Object
        Dim boek_maand As Object
        Dim boek_jaar As Object
        Dim row_tel As Object
        Dim Ctr As Object
        Dim lus As Object
        Dim Kwintasie As Object
        Dim count_ As Object
        Dim i As Integer

        'kry mk transaksies
        '  m_kontant.Index = "pjm_index" 'polisno,jaar,maand

        'kry persoonl rekord
        'Persoonl.Index = "pn_index"

        If Len(Me.Polisno.Text) <> 10 Then
            Me.Polisno.Text = Form1.POLISNO.Text
        End If

        'Persoonl.Seek("=", Form1.POLISNO)
        If Persoonl.NoMatch Then
            MsgBox(Me.Polisno.Text & " is not found in PERSONAL...")
            Exit Sub
        End If
        Versekerde.Text = Persoonl.VERSEKERDE
        Voorl.Text = Mid(Persoonl.VOORL, 1, 5)
        Polisno.Text = Persoonl.POLISNO


        uitstaande.Text = CStr(0)
        Ctr = 0
        row_tel = 0
        'm_kontant.Seek(">=", Polisno, jaar_van, maand_van)

        m_kontant = FetchMaandKontant(Persoonl.POLISNO)

        'If m_kontant.Nomatch Then
        '    GoTo mk_det_uit2
        'End If

        'kry alle mk transaksies
        'While m_kontant.polisno = Polisno.Text
        If m_kontant.polisno = Polisno.Text Then


            'het gebruiker net uitstaandes aangevra?
            If Uitst_transaksies.Checked Then
                If m_kontant.Premie = m_kontant.Ingevorder Then
                    GoTo ktant_einde_2
                End If

                'val transaksie in aangevraagde vanaf en tot datum?
                boek_jaar = CStr(m_kontant.Jaar)
                boek_jaar = Trim(boek_jaar)
                boek_jaar = boek_jaar


                If boek_maand <= 9 Then
                    boek_maand = CStr(m_kontant.Maand)
                    boek_maand = CStr("0" + Trim(boek_maand))
                Else
                    boek_maand = CStr(m_kontant.Maand)
                End If

                'boek_maand = CStr(m_kontant.Maand)
                'boek_maand = Trim(boek_maand)
                'boek_maand = (boek_maand)

                'boekhou datum as jjjjmm
                boek_jm = boek_jaar + boek_maand

                'datum vanaf en datum tot as jjjjmm
                vanaf_jm = jaar_van.Text & maand_van.Text
                tot_jm = jaar_tot.Text & maand_tot.Text

                If (boek_jm <= vanaf_jm) And (boek_jm >= tot_jm) Then
                    GoTo sit_in_grid2
                Else
                    GoTo ktant_einde_2
                End If
            End If
sit_in_grid2:

            ''vertoon mk detail
            'Grid1.AddItem((VB6.Format(m_kontant.Fields("afsluit_dat").Value) & Chr(9) & Str(m_kontant.Fields("premie").Value) & Chr(9) + grid_nou_ingevorder + Chr(9) + grid_kwitansie + Chr(9) + grid_vord_dat + Chr(9) + grid_trans_dat), row_tel)

            uitstaande.Text = uitstaande.Text + m_kontant.Premie

            Ctr = Ctr + 1

            Err.Clear()

volg_mk:
            'kry kontant transaksie wat saamgaan met mk
            mktransdat10 = Mid(m_kontant.trans_dat, 1, 10)
            'sSql = "SELECT * from Kontant where polisno = '" & Polisno.Text & "' and left(mk_trans_dat,10) = '" & mktransdat10 & "' and tipe = " & "'MK'"
            'ktant = stats.OpenRecordset(sSql)
            If ktant.Item(i).tipe = "MK" And ktant.Item(i).mk_trans_dat = mktransdat10 Then

                'Do While Not ktant.BOF And Not ktant.EOF
                For i = 0 To ktant.Count - 1

                    If Mid(ktant.Item(i).mk_trans_dat, 1, 10) = mktransdat10 And ktant.Item(i).tipe = "MK" And _
                    Format((Mid(ktant.Item(i).mk_trans_dat, 1, 10)) = Format(Mid(m_kontant.trans_dat, 1, 10))) Then

                        If ktant.Item(i).gekans = False Then
                            row_tel = row_tel + 1
                            DataGridView1.AutoGenerateColumns = False
                            DataGridView1.Refresh()

                            DataGridView1.ColumnCount = 6
                            DataGridView1.ColumnHeadersVisible = True
                            DataGridView1.Columns(0).Name = " "
                            DataGridView1.Columns(1).Name = "MandatoryPremium"
                            DataGridView1.Columns(2).Name = "Receipt"
                            DataGridView1.Columns(3).Name = "MandatoryDate"
                            DataGridView1.Columns(4).Name = "Transaction_Date"
                            DataGridView1.Columns(5).Name = "Cash_Type"

                            If IsDBNull(ktant.Item(i).tjekno_in) Then
                                Kwintasie = ktant.Item(i).kwitansie
                            Else
                                Kwintasie = ktant.Item(i).kwitansie / ktant.Item(i).tjekno_in
                            End If


                            DataGridView1.Rows.Add(0, (" " & Chr(9) & " "), Format(ktant.Item(i).vord_premie, "#########00.00"), _
                                                      Kwintasie, Format(ktant.Item(i).vord_dat, "dd/mm/yyyy"), ktant.Item(i).trans_dat, ktant.Item(i).kontant_tipe, row_tel)

                        End If


                    End If
                Next


            End If
        End If
        ' End While

        PopulateGridWithMaandKontant()
        'Loop

ktant_einde_2:

        'Or (m_kontant.EOF)

        If (Err.Number = 3021) Then
            GoTo mk_det_uit2
        End If
        ' End While

mk_det_uit2:

        'vooruitbetaling
        '---------------
        'genereer die vooruitbetalingstransaksie
        'die gebruiker moet dan nog steeds daarteen n kontant ontvangste registreer die premie word vanaf persoonl gekry
        If check_vb Then

kry_vb_jaar:
            If Month(Now) = 12 Then
                volg_jaar = CDbl(VB.Right(CStr(Year(Now)), 2)) + 1
                volg_maand = 1
            Else
                volg_jaar = VB.Right(CStr(Year(Now)), 2)
                volg_maand = Month(Now) + 1
            End If

kry_vb_maand:

            vb_maand = InputBox("For which month the prepayment (mm)?", , Format(volg_maand, "00"))
            If vb_maand = "" Then
                MsgBox("You prepayments canceled ...")
                check_vb = False
                GoTo einde_mk_tr
            End If

            'kry jaar ook
kry_vb_jaar3:
            vb_jaar = InputBox("For which year the advance payment (yy)?", , volg_jaar)
            If vb_jaar = "" Then
                MsgBox("You prepayments canceled...")
                check_vb = False
                GoTo einde_mk_tr
            End If

            'genereer vooruitbetalings transaksie
            vb_afdat = "01" & "/" & Format(vb_maand, "00") & "/" & Format(vb_jaar, "00")
            If Not (IsDate(vb_afdat)) Then
                MsgBox("Or the year or the month is incorrect - enter years as yyyy, month as mm ")
                GoTo kry_vb_maand
            End If

            'skryf jaar as ccjj
            jaar4 = 1900 + vb_jaar

            grid_nou_ingevorder = " "
            grid_kwitansie = " "
            grid_vord_dat = " "
            grid_trans_dat = Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")

            'skryf transaksie na maandeliks kontant tabel

            SaveMaandKontant()

            row_tel = row_tel + 1
            DataGridView1.Rows.Insert(0, vb_afdat, CStr(m_kontant.Premie), grid_nou_ingevorder, grid_kwitansie, grid_vord_dat, grid_trans_dat, row_tel)

            ' Grid1.AddItem((vb_afdat + Chr(9) + Str(m_kontant.Premie) + Chr(9) + grid_nou_ingevorder + Chr(9) + grid_kwitansie + Chr(9) + grid_vord_dat + Chr(9) + grid_trans_dat), row_tel)

        End If

        'zeroise vt_ingevorder
        nou_ingevorder.Enabled = True
        nou_ingevorder.Text = ""

        'zeroise memo
        Me.verw1.Text = " "
        Me.verw2.Text = " "
        Me.verw3.Text = " "
        Me.verw4.Text = " "
        Me.verw5.Text = " "

einde_mk_tr:

    End Sub
    Sub PopulateGridWithMaandDebit()
        DataGridView1.Rows.Clear()
        row_tel = 0
        row_tel = row_tel + 1
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.Refresh()

        DataGridView1.ColumnCount = 8
        DataGridView1.ColumnHeadersVisible = True

        DataGridView1.Columns(0).Name = "MD Datum"

        DataGridView1.Columns(1).Name = "Amount"
        DataGridView1.Columns(2).Name = "Colletion"
        DataGridView1.Columns(3).Name = "Reference number"
        DataGridView1.Columns(4).Name = "Date of collection"
        DataGridView1.Columns(5).Name = "Transaction Date"
        DataGridView1.Columns(6).Name = "T/K/E"
        DataGridView1.Columns(7).Name = "Payment_Type"

        Try
            DataGridView1.Rows.Clear()
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                             New SqlParameter("@Jaar", SqlDbType.SmallInt), _
                                            New SqlParameter("@Maand", SqlDbType.SmallInt)}

                param(0).Value = Persoonl.POLISNO
                param(1).Value = jaar_van.Text
                param(2).Value = maand_van.Text

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchGridMaandDebit]", param)
                DataGridView1.Rows.Clear()
                While reader.Read()

                    DataGridView1.Rows.Insert(0, reader("MD Datum"), reader("Amount"), reader("Collection"), reader("Receipt/Cheque number"), reader("Collection Date"), reader("Transaction Date"), reader("Kontant Tipe"), row_tel)

                End While

            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Sub PopulateGridWithMaandSalaries()
        DataGridView1.Rows.Clear()
        row_tel = 0
        row_tel = row_tel + 1
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.Refresh()

        DataGridView1.ColumnCount = 8
        DataGridView1.ColumnHeadersVisible = True

        DataGridView1.Columns(0).Name = "MS Datum"
        DataGridView1.Columns(1).Name = "Amount"
        DataGridView1.Columns(2).Name = "Collection"
        DataGridView1.Columns(3).Name = "Receipt/Cheque number"
        DataGridView1.Columns(4).Name = "Collection Date"
        DataGridView1.Columns(5).Name = "Transaction Date"
        DataGridView1.Columns(6).Name = "T/K/E"
        DataGridView1.Columns(7).Name = "Payment_Type"
        Try
            DataGridView1.Rows.Clear()
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                            New SqlParameter("@Jaar", SqlDbType.SmallInt), _
                                            New SqlParameter("@Maand", SqlDbType.SmallInt)}
                param(0).Value = Persoonl.POLISNO
                param(1).Value = jaar_van.Text
                param(2).Value = maand_van.Text

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchGridMaandSalaries]", param)
                DataGridView1.Rows.Clear()
                While reader.Read()

                    DataGridView1.Rows.Insert(0, reader("MS Datum"), reader("Amount"), reader("Collection"), reader("Receipt/Cheque number"), reader("Collection Date"), reader("Transaction Date"), reader("Kontant Tipe"), row_tel)

                End While

            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
    Sub PopulateGridWithMaandKontant()
        'stel volgende ry op
        'row_tel = row_tel + 1
        'DataGridView1.RowCount = row_tel

        ''berei grid veranderlikes voor
        'If IsDBNull(m_kontant.Ingevorder) Then
        '    grid_nou_ingevorder = " "
        'Else
        '    grid_nou_ingevorder = CStr(m_kontant.Ingevorder)
        'End If
        'grid_nou_ingevorder = Format(grid_nou_ingevorder, "0.00")

        'grid_kwitansie = " "

        'grid_vord_dat = " "

        'If IsDBNull(m_kontant.mkTrans_dat) Then
        '    grid_trans_dat = " "
        'Else
        '    grid_trans_dat = CStr(m_kontant.mkTrans_dat)
        'End If
        'vertoon mk detail
        DataGridView1.Rows.Clear()
        row_tel = 0
        row_tel = row_tel + 1
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.Refresh()
        DataGridView1.DataSource = Nothing
        DataGridView1.ColumnCount = 8
        DataGridView1.ColumnHeadersVisible = True

        DataGridView1.Columns(0).Name = "MK Datum"
        DataGridView1.Columns(1).Name = "Amount"
        DataGridView1.Columns(2).Name = "Collection"
        DataGridView1.Columns(3).Name = "Receipt/Cheque number"
        DataGridView1.Columns(4).Name = "Collection Date"
        DataGridView1.Columns(5).Name = "Transaction Date"
        DataGridView1.Columns(6).Name = "T/K/E"
        DataGridView1.Columns(7).Name = "Payment_Type"

        Try
            DataGridView1.Rows.Clear()
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                            New SqlParameter("@Jaar", SqlDbType.SmallInt), _
                                            New SqlParameter("@Maand", SqlDbType.SmallInt)}
                param(0).Value = Persoonl.POLISNO
                param(1).Value = jaar_van.Text
                param(2).Value = maand_van.Text

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchGridMaandKontant]", param)

                While reader.Read()
                    DataGridView1.Rows.Insert(0, reader("MK Datum"), reader("Amount"), reader("Collection"), reader("Receipt/Cheque number"), reader("Collection Date"), reader("Transaction Date"), reader("Kontant Tipe"), row_tel)
                End While
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        ' DataGridView1.Rows.Insert((Format(m_kontant.Afsluit_dat) & Chr(9) & CStr(m_kontant.Premie) & Chr(9) + grid_nou_ingevorder + Chr(9) + grid_kwitansie + Chr(9) + grid_vord_dat + Chr(9) + grid_trans_dat), row_tel)

        ' uitstaande.Text = uitstaande.Text + m_kontant.Premie
        ' Ctr = Ctr + 1

    End Sub

    Sub populateGridVTDetails()

        Dim grid_trans_dat As Object
        Dim grid_vt_x As Object
        Dim grid_vord_dat As Object
        Dim grid_kwitansie As Object
        Dim grid_nou_ingevorder As Object
        Dim row_tel As Object

        row_tel = 0
        row_tel = row_tel + 1

        DataGridView1.AutoGenerateColumns = False
        DataGridView1.Refresh()
        DataGridView1.ColumnCount = 11
        DataGridView1.ColumnHeadersVisible = True

        DataGridView1.Columns(0).Name = "VT Datum"
        DataGridView1.Columns(1).Name = "Date Requested"
        DataGridView1.Columns(2).Name = "Amount"
        DataGridView1.Columns(3).Name = "VT_Reasons"
        DataGridView1.Columns(4).Name = "Collection"
        DataGridView1.Columns(5).Name = "Receipt/Cheque number"
        DataGridView1.Columns(6).Name = "Transaction Date"

        DataGridView1.Columns(7).Name = "Collection Date"
        DataGridView1.Columns(8).Name = "X"
        DataGridView1.Columns(9).Name = "T/K/E"
        DataGridView1.Columns(10).Name = "Payment_Type"

        Try
            DataGridView1.Rows.Clear()
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                            New SqlParameter("@VTDatum", SqlDbType.DateTime)}

                param(0).Value = Persoonl.POLISNO
                param(1).Value = "1980/01/01"


                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchGridVTKontact", param)

                While reader.Read()
                    If IsDBNull(reader("Collection")) Then
                        grid_nou_ingevorder = " "
                    Else
                        grid_nou_ingevorder = (reader("Collection"))
                    End If 'FetchGridVTKontact

                    If IsDBNull(reader("X")) Then
                        grid_vt_x = " "
                    Else

                        grid_vt_x = reader("X")
                    End If
                    If IsDBNull(reader("Transaction Date")) Then
                        grid_trans_dat = " "
                    Else
                        grid_trans_dat = reader("Transaction Date")
                    End If

                    DataGridView1.Rows.Insert(0, reader("VT Date"), reader("Date Requested"), reader("Amount"), reader("VT_Reasons"), grid_nou_ingevorder, reader("Receipt/Cheque number"), grid_trans_dat, reader("Collection Date"), grid_vt_x, reader("Kontant Tipe"), row_tel)
                End While
                DataGridView1.Rows.Clear()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Sub kry_me_transaksies()
        'Dim jaar4 As Object
        ' Dim vb_afdat As Object
        'Dim vb_jaar As Object
        Dim check_vb As Object
        'Dim vb_maand As Object
        Dim volg_maand As Object
        Dim volg_jaar As Object
        Dim sSql As Object
        Dim metransdat10 As Object
        Dim grid_trans_dat As Object
        Dim grid_vord_dat As Object
        Dim grid_kwitansie As Object
        Dim grid_nou_ingevorder As Object
        Dim tot_jm As Object
        Dim vanaf_jm As Object
        Dim boek_jm As Object
        Dim boek_maand As Object
        Dim boek_jaar As Object
        Dim row_tel As Object
        Dim Ctr As Object
        Dim lus As Object
        Dim I As Integer
        Dim count_ As Object
        Dim Kwintasie As Object




        'kry persoonl rekord
        'Persoonl.Index = "pn_index"

        If Len(Me.Polisno.Text) <> 10 Then
            Me.Polisno.Text = Form1.POLISNO.Text
        End If

        'Persoonl.Seek("=", Form1.POLISNO)
        If Persoonl.NoMatch Then
            MsgBox(Me.Polisno.Text & " is not found in PERSONAL")
            Exit Sub
        End If

        Versekerde.Text = Persoonl.VERSEKERDE
        Voorl.Text = Persoonl.VOORL
        Polisno.Text = Persoonl.POLISNO

        uitstaande.Text = CStr(0)
        Ctr = 0
        row_tel = 0
        ' m_elektronies.Seek(">=", Polisno, jaar_van, maand_van)
        m_elektronies = FetchMaandElectronics(Persoonl.POLISNO)
        'If Not m_elektronies.NoMatch Then

        'While m_elektronies.polisno = Polisno.Text
        'het gebruiker net uitstaandes aangevra?
        If Uitst_transaksies.Checked Then
            If m_elektronies.premie = m_elektronies.ingevorder Then GoTo ktant_einde_10
        End If

        '                'val transaksie in aangevraagde vanaf en tot datum?
        boek_jaar = CStr(m_elektronies.jaar)
        boek_jaar = Trim(boek_jaar)
        boek_jaar = boek_jaar


        If boek_maand <= 9 Then
            boek_maand = CStr(m_elektronies.maand)
            boek_maand = CStr("0" + Trim(boek_maand))
        Else
            boek_maand = CStr(m_elektronies.maand)
        End If

        'boek_maand = CStr(m_elektronies.maand)
        'boek_maand = Trim(boek_maand)
        'boek_maand = Format(boek_maand, "00")

        'boekhou datum as jjjjmm
        boek_jm = boek_jaar + boek_maand

        '                'datum vanaf en datum tot as jjjjmm
        vanaf_jm = jaar_van.Text & maand_van.Text
        tot_jm = jaar_tot.Text & maand_tot.Text

        If (boek_jm <= vanaf_jm) And (boek_jm >= tot_jm) Then
            GoTo sit_in_grid2
        Else
            GoTo ktant_einde_10
        End If

sit_in_grid2:

        '                'stel volgende ry op

        row_tel = row_tel + 1

        DataGridView1.RowCount = row_tel

        'berei grid veranderlikes voor

        If IsDBNull(m_elektronies.ingevorder) Then
            grid_nou_ingevorder = " "
        Else
            grid_nou_ingevorder = CStr(m_elektronies.ingevorder)
        End If

        grid_nou_ingevorder = Format(grid_nou_ingevorder, "0.00")


        grid_kwitansie = " "


        grid_vord_dat = " "



        If IsDBNull(m_elektronies.afsluit_dat) Then
            grid_trans_dat = " "
        Else
            grid_trans_dat = CStr(m_elektronies.afsluit_dat)
        End If

        'vertoon me detail




        'DataGridView1.Rows.Insert((Format(m_elektronies.afsluit_dat) & Chr(9) & CStr(m_elektronies.premie) & Chr(9) + grid_nou_ingevorder + Chr(9) + grid_kwitansie + Chr(9) + grid_vord_dat + Chr(9) + grid_trans_dat), row_tel)



        uitstaande.Text = uitstaande.Text + m_elektronies.premie


        Ctr = Ctr + 1

        Err.Clear()

volg_me:
        '                'kry kontant transaksie wat saamgaan met me

        metransdat10 = Mid(ktant.Item(I).Me_Trans_Dat, 1, 10)
        ' sSql = "SELECT * from Kontant where polisno = '" & Polisno.Text & "' and left(me_trans_dat,10) = '" & metransdat10 & "' and tipe = " & "'ME'"
        'ktant = stats.OpenRecordset(sSql)




        '  If ktant.Item(I).polisno = Polisno.Text And ktant.Item(I).Me_Trans_Dat = metransdat10 And ktant.Item(I).tipe = "ME" Then

        'Do While Not ktant.BOF And Not ktant.EOF
        For I = 0 To ktant.Count - 1

            If Mid(ktant.Item(I).Me_Trans_Dat, 1, 10) = metransdat10 And ktant.Item(I).tipe = "ME" And _
            Format((Mid(ktant.Item(I).Me_Trans_Dat, 1, 10)) = Format(Mid(m_elektronies.trans_dat, 1, 10))) Then
                If ktant.Item(I).gekans = False Then

                    row_tel = row_tel + 1
                    DataGridView1.AutoGenerateColumns = False
                    DataGridView1.Refresh()

                    DataGridView1.ColumnCount = 6
                    DataGridView1.ColumnHeadersVisible = True
                    DataGridView1.Columns(0).Name = " "
                    DataGridView1.Columns(1).Name = "Mandotory_Premium"
                    DataGridView1.Columns(2).Name = "Receipt"
                    DataGridView1.Columns(3).Name = "Mandotory_Date"
                    DataGridView1.Columns(4).Name = "Transaction_Date"
                    DataGridView1.Columns(5).Name = "Payment_Type"

                    If IsDBNull(ktant.Item(I).tjekno_in) Then
                        Kwintasie = ktant.Item(I).kwitansie
                    Else
                        Kwintasie = ktant.Item(I).kwitansie / ktant.Item(I).tjekno_in
                    End If


                    DataGridView1.Rows.Add(0, (" " & Chr(9) & " "), Format(ktant.Item(I).vord_premie, "#########00.00"), _
                                              Kwintasie, Format(ktant.Item(I).vord_dat, "dd/mm/yyyy"), ktant.Item(I).trans_dat, ktant.Item(I).kontant_tipe, row_tel)


                    uitstaande.Text = CStr(CDbl(uitstaande.Text) - ktant.Item(I).vord_premie)

                End If
            End If
        Next
        'DataGridView1.Rows.Insert((Format(m_elektronies.afsluit_dat) & Chr(9) & CStr(m_elektronies.premie) & Chr(9) + grid_nou_ingevorder + Chr(9) + grid_kwitansie + Chr(9) + grid_vord_dat + Chr(9) + grid_trans_dat), row_tel)

ktant_einde_10:

        '                '      m_elektronies.MoveNext()

        'If (Err.Number = 3021) Or (m_elektronies.EOF) Then
        GoTo me_det_uit2
        ' End If
        'End While

        ' End If


me_det_uit2:

        'vooruitbetaling
        '---------------
        'genereer die vooruitbetalingstransaksie die gebruiker moet dan nog steeds daarteen n kontant ontvangste registreer die premie word vanaf persoonl gekry
        If check_vb Then

kry_vb_jaar10:
            If Month(Now) = 12 Then
                volg_jaar = CDbl(VB.Right(CStr(Year(Now)), 2)) + 1
                volg_maand = 1
            Else
                volg_jaar = VB.Right(CStr(Year(Now)), 2)
                volg_maand = Month(Now) + 1
            End If

kry_vb_maand10:
            vb_maand = InputBox("What month is the prepayment (mm)?", , Format(volg_maand, "00"))
            If vb_maand = "" Then
                MsgBox("You have canceled prepayments...")
                check_vb = False
                'GoTo einde_me_tr
            End If

            'kry jaar ook
kry_vb_jaar11:
            vb_jaar = InputBox("For which year the advance payment(jj)?", , volg_jaar)
            If vb_jaar = "" Then
                MsgBox("You have canceled prepayments...")
                check_vb = False
                GoTo einde_me_tr
            End If

            'genereer vooruitbetalings transaksie
            vb_afdat = "01" & "/" & Format(vb_maand, "00") & "/" & Format(vb_jaar, "00")
            If Not (IsDate(vb_afdat)) Then
                MsgBox("Or the year or the month is incorrect - please year as yy, mm month as")
                GoTo kry_vb_maand10
            End If

            'skryf jaar as ccjj
            jaar4 = 1900 + vb_jaar


            grid_nou_ingevorder = " "

            grid_kwitansie = " "

            grid_vord_dat = " "

            grid_trans_dat = Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")

            '            'skryf transaksie na maandeliks kontant tabel

            SaveElectronies()

            row_tel = row_tel + 1


            DataGridView1.Rows.Insert(0, vb_afdat, CStr(m_kontant.Premie), grid_nou_ingevorder, grid_kwitansie, grid_vord_dat, grid_trans_dat, row_tel)

            'Grid1.AddItem((vb_afdat + Chr(9) + Str(m_elektronies.Fields("premie").Value) + Chr(9) + grid_nou_ingevorder + Chr(9) + grid_kwitansie + Chr(9) + grid_vord_dat + Chr(9) + grid_trans_dat), row_tel)

        End If
        PopulateGridWithMaandElectronies()

        'zeroise vt_ingevorder
        nou_ingevorder.Enabled = True
        nou_ingevorder.Text = ""

        'zeroise memo
        Me.verw1.Text = " "
        Me.verw2.Text = " "
        Me.verw3.Text = " "
        Me.verw4.Text = " "
        Me.verw5.Text = " "

einde_me_tr:


    End Sub

    Sub SaveDebit()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@PREMIE", SqlDbType.Money), _
                                                New SqlParameter("@VORD_PREMIE", SqlDbType.Money), _
                                                New SqlParameter("@AFSLUIT_DAT", SqlDbType.DateTime), _
                                                New SqlParameter("@Area", SqlDbType.NVarChar), _
                                                New SqlParameter("@JAAR", SqlDbType.SmallInt), _
                                                New SqlParameter("@MAAND", SqlDbType.SmallInt), _
                                                New SqlParameter("@TRANS_DAT", SqlDbType.DateTime), _
                                                New SqlParameter("@BETAALWYSE", SqlDbType.NVarChar)}


                params(0).Value = Persoonl.POLISNO
                params(1).Value = Format(Persoonl.PREMIE, "#####.00")
                params(2).Value = 0
                params(3).Value = vb_afdat
                params(4).Value = Persoonl.Area
                params(5).Value = jaar4
                params(6).Value = vb_maand
                params(7).Value = Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")
                params(8).Value = Persoonl.BET_WYSE

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.InsertIntoMaand", params)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

    End Sub

    Sub SaveElectronies()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim params() As SqlParameter = {New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@vord_dat", SqlDbType.DateTime), _
                                                New SqlParameter("@premie", SqlDbType.Money), _
                                                New SqlParameter("@vord_premie", SqlDbType.Money), _
                                                New SqlParameter("@afsluit_dat", SqlDbType.DateTime), _
                                                New SqlParameter("@jaar", SqlDbType.SmallInt), _
                                                New SqlParameter("@maand", SqlDbType.SmallInt), _
                                                New SqlParameter("@trans_dat", SqlDbType.DateTime), _
                                                New SqlParameter("@betaalwyse", SqlDbType.NVarChar), _
                                                New SqlParameter("@ingevorder", SqlDbType.Money), _
                                                New SqlParameter("@me_trans_dat", SqlDbType.DateTime), _
                                                New SqlParameter("@kwit_boek", SqlDbType.DateTime), _
                                                New SqlParameter("@Area", SqlDbType.NVarChar)}



                params(0).Value = Persoonl.POLISNO
                params(1).Value = Format(Persoonl.PREMIE, "#####.00")
                params(2).Value = 0
                params(3).Value = vb_afdat
                params(4).Value = Persoonl.Area
                params(5).Value = jaar4
                params(6).Value = vb_maand
                params(7).Value = Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")
                params(8).Value = Persoonl.BET_WYSE
                params(9).Value = kwit_boek.Text
                params(10).Value = Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")
                params(11).Value = Persoonl.BET_WYSE
                params(12).Value = kwit_boek.Text

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.UpdateEletctronies", params)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Public Sub SaveMaandKontant()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@PREMIE", SqlDbType.Float), _
                                                New SqlParameter("@VORD_PREMIE", SqlDbType.Float), _
                                                New SqlParameter("@AFSLUIT_DAT", SqlDbType.DateTime), _
                                                New SqlParameter("@Area", SqlDbType.NVarChar), _
                                                New SqlParameter("@JAAR", SqlDbType.SmallInt), _
                                                New SqlParameter("@MAAND", SqlDbType.SmallInt), _
                                                New SqlParameter("@TRANS_DAT", SqlDbType.DateTime), _
                                                New SqlParameter("@BETAALWYSE", SqlDbType.NVarChar), _
                                                New SqlParameter("@Kwit_boek", SqlDbType.DateTime)}



                params(0).Value = Persoonl.POLISNO
                params(1).Value = Format(CDec(Persoonl.PREMIE), "#####.00")
                params(2).Value = 0
                params(3).Value = vb_afdat
                params(4).Value = Persoonl.Area
                params(5).Value = jaar4
                params(6).Value = vb_maand
                params(7).Value = Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")
                params(8).Value = Persoonl.BET_WYSE
                params(9).Value = kwit_boek.Text

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.UpdateMaand", params)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Private Sub Check_bb_GotFocus()

    End Sub

    Private Sub Check_jk_hern_Click()

    End Sub

    Private Sub Check_jk_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check_jk.Enter

        'deselekteer al die ander opsies
        Langtermynpolis.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_mk.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_ms.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_VT.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_me.CheckState = System.Windows.Forms.CheckState.Unchecked
        eerstebetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        Vooruitbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        terugbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        genereer_trans.PerformClick()

        Command3.Visible = False
        genereer_trans.Visible = False

        kwit_boek.Visible = True
        Label14.Visible = True

    End Sub

    'UPGRADE_WARNING: Event check_md.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub check_md_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles check_md.CheckStateChanged

        If check_md.CheckState = 1 Then
            command4_Click(Command4, New System.EventArgs())
        End If

    End Sub

    Private Sub check_md_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles check_md.Enter

        'deselekteer al die ander opsies
        Langtermynpolis.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_mk.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_ms.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_VT.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_me.CheckState = System.Windows.Forms.CheckState.Unchecked
        eerstebetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        Vooruitbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        terugbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        genereer_trans.PerformClick()

        Command3.Visible = False
        genereer_trans.Visible = False
        kwit_boek.Visible = True
        Label14.Visible = True

    End Sub

    'UPGRADE_WARNING: Event Check_me.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub Check_me_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check_me.CheckStateChanged
        check_md.CheckState = System.Windows.Forms.CheckState.Unchecked

        If Check_me.CheckState = 1 Then
            command4_Click(Command4, New System.EventArgs())
        End If

    End Sub

    Private Sub Check_me_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check_me.Enter
        'deselekteer al die ander opsies
        Langtermynpolis.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_mk.CheckState = System.Windows.Forms.CheckState.Unchecked
        check_md.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_ms.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_VT.CheckState = System.Windows.Forms.CheckState.Unchecked
        eerstebetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        Vooruitbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        terugbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        genereer_trans.PerformClick()

        Command3.Visible = False
        genereer_trans.Visible = False

        kwit_boek.Visible = True
        Label14.Visible = True

    End Sub

    'UPGRADE_WARNING: Event Check_mk.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub Check_mk_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check_mk.CheckStateChanged

        If Check_mk.CheckState = 1 Then
            command4_Click(Command4, New System.EventArgs())
        End If

        check_md.CheckState = System.Windows.Forms.CheckState.Unchecked

    End Sub

    Private Sub Check_mk_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check_mk.Enter

        Langtermynpolis.CheckState = System.Windows.Forms.CheckState.Unchecked
        check_md.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_ms.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_VT.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_me.CheckState = System.Windows.Forms.CheckState.Unchecked
        eerstebetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        Vooruitbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        terugbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        genereer_trans.PerformClick()

        Command3.Visible = False
        genereer_trans.Visible = False
        kwit_boek.Visible = True
        Label14.Visible = True

    End Sub

    'UPGRADE_WARNING: Event Check_ms.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub Check_ms_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check_ms.CheckStateChanged

        If Check_ms.CheckState = 1 Then
            command4_Click(Command4, New System.EventArgs())
        End If

    End Sub

    Private Sub Check_ms_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check_ms.Enter

        'deselekteer al die ander opsies
        Langtermynpolis.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_mk.CheckState = System.Windows.Forms.CheckState.Unchecked
        check_md.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_VT.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_me.CheckState = System.Windows.Forms.CheckState.Unchecked
        eerstebetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        Vooruitbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        terugbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        genereer_trans.PerformClick()

        Command3.Visible = False
        genereer_trans.Visible = False

        kwit_boek.Visible = True
        Label14.Visible = True

    End Sub

    Private Sub Check_tj_GotFocus()

    End Sub

    'UPGRADE_WARNING: Event Check_VT.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub Check_VT_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check_VT.CheckStateChanged

        If Check_VT.CheckState = 1 Then
            command4_Click(Command4, New System.EventArgs())
        End If

    End Sub

    Private Sub Check_VT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check_VT.Enter

        'deselekteer al die ander opsies
        Langtermynpolis.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_mk.CheckState = System.Windows.Forms.CheckState.Unchecked
        check_md.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_ms.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_me.CheckState = System.Windows.Forms.CheckState.Unchecked
        eerstebetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        Vooruitbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        terugbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        genereer_trans.PerformClick()

        Command3.Visible = False
        genereer_trans.Visible = False

        kwit_boek.Visible = True
        Label14.Visible = True

    End Sub

    Private Sub Check_wr_GotFocus()

    End Sub

    Private Sub clear_scr()
        Dim lus As Object
        Polisno.Text = ""
        Versekerde.Text = ""
        Voorl.Text = ""
        uitstaande.Text = ""
        If DataGridView1.RowCount <> 2 Then
            For lus = 1 To DataGridView1.RowCount - 2
                DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
            Next
        End If
    End Sub

    Private Sub cmd_nuwetjek_Click()

    End Sub
    Sub GetMaandKontantAndGrid()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@MaandKontantTransDate", SqlDbType.DateTime), _
                                                New SqlParameter("@Vord_Premie", SqlDbType.Money), _
                                                New SqlParameter("@verw1", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw2", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw3", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw4", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw5", SqlDbType.NVarChar), _
                                                New SqlParameter("@kontant_tipe", SqlDbType.NVarChar), _
                                                New SqlParameter("@tjekno_uit", SqlDbType.NVarChar), _
                                                New SqlParameter("@tjekno_in", SqlDbType.NVarChar), _
                                                New SqlParameter("@TJEKDATUM", SqlDbType.DateTime), _
                                                New SqlParameter("@TJEKBESONDERHEDE", SqlDbType.NVarChar), _
                                                New SqlParameter("@kwit_boek", SqlDbType.NVarChar), _
                                                New SqlParameter("@Area", SqlDbType.NVarChar), _
                                                New SqlParameter("@CurrentDate", SqlDbType.DateTime), _
                                                New SqlParameter("@tipe_ontv", SqlDbType.NVarChar)}


                params(0).Value = Persoonl.POLISNO
                params(1).Value = DataGridView1.SelectedRows(0).Cells(5).Value 'CStr(Format(Now, "dd/mm/yyyy")) 
                params(2).Value = Me.nou_ingevorder.Text

                If IsDBNull(Me.verw1.Text) Then
                    Me.verw1.Text = " "
                End If
                If IsDBNull(Me.verw2.Text) Then
                    Me.verw2.Text = " "
                End If
                If IsDBNull(Me.verw3.Text) Then
                    Me.verw3.Text = " "
                End If
                If IsDBNull(Me.verw4.Text) Then
                    Me.verw4.Text = " "
                End If
                If IsDBNull(Me.verw5.Text) Then
                    Me.verw5.Text = " "
                End If

                params(3).Value = Me.verw1.Text
                params(4).Value = Me.verw2.Text
                params(5).Value = Me.verw3.Text
                params(6).Value = Me.verw4.Text
                params(7).Value = Me.verw5.Text
                params(8).Value = kontant_tipe

                If Me.Tjek.Checked <> 0 Then
                    If terugbetaling.Checked Or check_tj Then
                        params(9).Value = Tjekno.Text
                        params(10).Value = DBNull.Value
                    Else
                        params(9).Value = DBNull.Value
                        params(10).Value = Tjekno.Text
                    End If
                Else
                    params(9).Value = DBNull.Value
                    params(10).Value = DBNull.Value
                End If

                If Me.Tjek.Checked Then
                    params(11).Value = Tjekdatum.Text
                    params(12).Value = Tjekbesonderhede.Text
                Else
                    params(11).Value = DBNull.Value
                    params(12).Value = DBNull.Value
                End If

                params(13).Value = kwit_boek.Text
                params(14).Value = Persoonl.Area
                params(15).Value = Format(Now, "dd/MM/yyyy")
                params(16).Value = tipe_ontv

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Stats5.UpdateKontantAndMaandKontant", params)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub

    Sub GetMaandSalarisAndGrid()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@MaandSalariesTransDate", SqlDbType.DateTime), _
                                                New SqlParameter("@Vord_Premie", SqlDbType.Money), _
                                                New SqlParameter("@verw1", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw2", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw3", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw4", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw5", SqlDbType.NVarChar), _
                                                New SqlParameter("@kontant_tipe", SqlDbType.NVarChar), _
                                                New SqlParameter("@tjekno_uit", SqlDbType.NVarChar), _
                                                New SqlParameter("@tjekno_in", SqlDbType.NVarChar), _
                                                New SqlParameter("@TJEKDATUM", SqlDbType.DateTime), _
                                                New SqlParameter("@TJEKBESONDERHEDE", SqlDbType.NVarChar), _
                                                New SqlParameter("@kwit_boek", SqlDbType.NVarChar), _
                                                New SqlParameter("@Area", SqlDbType.NVarChar), _
                                                New SqlParameter("@CurrentDate", SqlDbType.DateTime), _
                                                New SqlParameter("@tipe_ontv", SqlDbType.NVarChar)}


                params(0).Value = Persoonl.POLISNO
                params(1).Value = DataGridView1.SelectedRows(0).Cells(5).Value
                params(2).Value = Me.nou_ingevorder.Text

                If IsDBNull(Me.verw1.Text) Then
                    Me.verw1.Text = " "
                End If
                If IsDBNull(Me.verw2.Text) Then
                    Me.verw2.Text = " "
                End If
                If IsDBNull(Me.verw3.Text) Then
                    Me.verw3.Text = " "
                End If
                If IsDBNull(Me.verw4.Text) Then
                    Me.verw4.Text = " "
                End If
                If IsDBNull(Me.verw5.Text) Then
                    Me.verw5.Text = " "
                End If

                params(3).Value = Me.verw1.Text
                params(4).Value = Me.verw2.Text
                params(5).Value = Me.verw3.Text
                params(6).Value = Me.verw4.Text
                params(7).Value = Me.verw5.Text
                params(8).Value = kontant_tipe

                If Me.Tjek.Checked <> 0 Then
                    If terugbetaling.Checked Or check_tj Then
                        params(9).Value = Tjekno.Text
                        params(10).Value = DBNull.Value
                    Else
                        params(9).Value = DBNull.Value
                        params(10).Value = Tjekno.Text
                    End If
                Else
                    params(9).Value = DBNull.Value
                    params(10).Value = DBNull.Value
                End If

                If Me.Tjek.Checked Then
                    params(11).Value = Tjekdatum.Text
                    params(12).Value = Tjekbesonderhede.Text
                Else
                    params(11).Value = DBNull.Value
                    params(12).Value = DBNull.Value
                End If

                params(13).Value = kwit_boek.Text
                params(14).Value = Persoonl.Area
                params(15).Value = Format(Now, "dd/MM/yyyy HH:mm")
                params(16).Value = tipe_ontv

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Stats5.UpdateKontantAndMaandSalaries", params)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Dim tipe_bet As Object
        Dim trans_dat As Object
        Dim grid_trans_dat As Object
        Dim grid_vord_dat As Object
        Dim grid_kwitansie As Object
        Dim grid_nou_ingevorder As Object
        Dim pkLangtermynPolis As Object
        Dim rekordgekry As Object
        Dim termynSql As Object
        'Dim jaar4 As Object
        'Dim vb_afdat As Object
        'Dim vb_jaar As Object
        'Dim vb_maand As Object
        Dim vb_dag As Object
        Dim volg_maand As Object
        Dim volg_jaar As Object
        Dim strSql As Object
        Dim nou_kwitansie As Object
        Dim kwit_nr_s As Object
        Dim kwit_nr As Object
        Dim vt_ingevorder As Object
        Dim bal As Object
        'Dim ing As Object
        Dim i As Integer
        Dim sSql As Object
        Dim gen_trans As Object
        Dim m_salaries As Object

        'If Check_mk.CheckState Or check_md.CheckState Or Check_ms.CheckState Or Check_me.CheckState Or Check_VT.CheckState Or eerstebetaling.CheckState Or Vooruitbetaling.CheckState Or terugbetaling.CheckState Or Langtermynpolis.CheckState Or Check_jk.CheckState Then
        'Else
        '    MsgBox("You want a transaction register. For at least one payment method or type of payment chosen. Valid choices are monthly cash, monthly flow, monthly salary, monthly electronic, annual cash, long-term policy, VT, first payment, prepayment or repayment.")
        '    Exit Sub
        'End If
        'transja: 

        'Gebruiker moes 'n transaksie gekies het om hierdie betaling teenoor te doen
        If Check_mk.CheckState Or check_md.CheckState Or Check_ms.CheckState Or Check_me.CheckState Or Check_VT.CheckState Then
            If DataGridView1.RowCount <> 0 Then
                If IsDate(DataGridView1.Rows(0).Cells(0).Value) Then
                    MsgBox("Select a transaction to which this payment must be done ...")
                    Exit Sub
                End If
            End If


        End If

        'edit dat geldige transaksie tipes ge-selekteer is bv. md en eerste betaling kan nie gelyk geselekteer wees nie
        If (check_teveel > 1) And (Not (gen_trans)) Then
            MsgBox("You may only generate and first payment or prepayment or repayment select. Furthermore, you may not select two transaction types, eg. deniet and first monthly payment may not equal selected..")
            check_teveel = 0
            Exit Sub
        End If

        'moet of n tjek of n kontant transaksie wees
        If Tjek.Checked = 0 And Kont.Checked = 0 And Elektronies.Checked = 0 Then
            MsgBox("Please select the transaction or a check or cash or an electronic transaction")
            Exit Sub
        End If

        If Tjek.Checked <> 0 Then

            kontant_tipe = "T"
        Else
            If Kont.Checked <> 0 Then

                kontant_tipe = "K"
            Else
                If Elektronies.Checked <> 0 Then

                    kontant_tipe = "E"
                End If
            End If
        End If

        If Me.Tjek.Checked <> 0 Then

            If Tjekno.Text = "" Or IsDBNull(Tjekno.Text) Or Val(Tjekno.Text) = 0 Then
                MsgBox("Please enter the check number ...")
                Tjekno.Focus()

                Exit Sub
            End If
        End If

        ''tjek nommer moet uniek wees
        If terugbetaling.CheckState Then
            If Tjekno.Text <> "" Then
                ktant.Item(i).Index = "tjuit_index"
                '        ktant.Seek("=", Tjekno)
                If Not (ktant.Item(i).Nomatch) Then
                    MsgBox("This check number is already used...")
                    Tjekno.Focus()
                    Exit Sub
                End If
            End If
        End If

        'Toets of dit 'n geldige datum is
        If Me.Tjek.Checked Then
            If Not (IsDate(Tjekdatum.Text)) Then
                MsgBox("The check date is not a valid date. Enter the date as dd / mm / yyyy.")
                Tjekdatum.Focus()
                Exit Sub
            End If
        End If

        'Tjek besonderhede moet ingevul word
        If Me.Tjek.Checked Then
            If Trim(Me.Tjekbesonderhede.Text) = "" Then
                MsgBox("Please enter. check details ...")
            End If
        End If

        'Vir alle ontvangstes moet kwitansie boek nommer ingevul wees
        If terugbetaling.CheckState = 0 Then
            If Len(kwit_boek.Text) = 0 Then
                MsgBox("Receipt book number must be completed for all receipts")
                kwit_boek.Focus()
                Exit Sub

            Else
                '        'Kwitansie boek nommer moet uniek wees
                'ktant.Item(i).Index = "kb_index"
                'ktant.Seek("=", kwit_boek)
                If ktant.Item(i).Nomatch Then

                    Do While ktant.Item(i).kwit_boek = kwit_boek.Text
                        If ktant.Item(i).gekans Then
                            MsgBox("Receipt book number must be unique...")
                            kwit_boek.Focus()
                            Exit Sub
                        End If
                        'ktant.MoveNext()
                    Loop
                End If
            End If
        End If

        'vt
        If Check_VT.Checked Then
            'kontant ontvangstes vir vt's moet teen die md transaksie geregistreer word
            'klient betaal vt's op transaksie datum
            'vt_balans.Index = "PN_INDEX"

            'indeks op polisno/transaksie datum/vt datum/vt rede/vt bedrag
            If Val(nou_ingevorder.Text) = 0 Then
                MsgBox("There is no value in the amount charged field!", 48, "Error!")
                nou_ingevorder.Focus()
                Exit Sub
            End If

            GETVTKontantAndGrid()


typ_mis_vt:

            If Check_VT.CheckState Then tipe_ontv = "VT"
            'inkrementeer sekwensiele kwitansie nommer
            'skep n rekord vir die eerste keer

            UpdateVTBalans()


        End If 'check vt

endvt:

        'mk
        If Check_mk.Checked Then

            If Val(nou_ingevorder.Text) = 0 Then
                MsgBox("There is no value in the amount charged field!", 48, "Error!")
                nou_ingevorder.Focus()
                Exit Sub
            End If

            If DataGridView1.RowCount = 0 Then
                MsgBox("Please select information on the Grid")
                Exit Sub
            End If

            If Err.Number = 13 Then
                MsgBox("Click for details Transaction date of monthly cash. ", 48, "Critical Error!")
                Exit Sub
            End If
            If m_kontant.Nomatch Then
                MsgBox("Click for details Tr (ansaksie) date of monthly cash.", 48, "Critical Error!")
                Exit Sub
            End If

            'rond nou_ingevorder af tot 2 desimale
            ing = CDbl(Format(Val(nou_ingevorder.Text))) + 0.005
            ing = ing * 100
            ing = Int(CDbl(ing))
            ing = ing / 100
            uitstaande.Text = CDec(uitstaande.Text) - ing

            tipe_ontv = "MK"

            GetMaandKontantAndGrid()

        End If

        'Maandeliks elektronies
        If Check_me.CheckState Then
            'indeks op polisno/transaksie datum
            'm_elektronies.Index = "PT_INDEX"

            If Val(nou_ingevorder.Text) = 0 Then
                MsgBox("There is no value in the transaction amount field!", 48, "Error!")
                nou_ingevorder.Focus()
                Exit Sub
            End If


            '			'type mismatch - want daar is op niks geclick nie
typ_mis10:
            If Err.Number = 13 Then
                MsgBox("Please Click Transaction date of monthly cash.", 48, "Critical Error!")
                Exit Sub
            End If
            If m_elektronies.NoMatch Then
                MsgBox("Please click on the transaction to a receipt being done.", 48, "Critical Error!")
                Exit Sub
            End If
            On Error GoTo 0

            'rond nou_ingevorder af tot 2 desimale
            ing = CDbl(Format(Val(nou_ingevorder.Text))) + 0.005
            ing = ing * 100
            ing = Int(CDbl(ing))
            ing = ing / 100

            tipe_ontv = "ME"


            GetMaandElektronies()
            '			'inkrementeer sekwensiele kwitansie nommer

            '			'skep n rekord vir die eerste keer
            '			

        End If

typ_mis2:

        'ms
        If Check_ms.CheckState Then

            Set_MonthlySalaryRecordset()

            'indeks op polisno/transaksie datum
            If Val(nou_ingevorder.Text) = 0 Then
                MsgBox("There is no value in the amount charged field! ", 48, "Error!")
                nou_ingevorder.Focus()
                Exit Sub
            End If

            'strSql = "SELECT * FROM tak"
            rsTak11 = FetchTakForsalaries()

            'strMSTabel = ""

            'strSql = "SELECT * FROM persoonl LEFT JOIN area ON area.area_kode = persoonl.area 
            'WHERE polisno = '" & Polisno.Text & "'"
            'rsArea = poldata_Renamed.OpenRecordset(strSql)
            rsArea = FetchAreaByPersoonl()
            'If rsTak.Fields("tak_naam").Value = "Flagship" Then
            '    strMSTabel = "Maand_puk"


            If rsTak11.TAKNAAM = "Flagship" Then
                'm_PukForSalaries = Fetch_Maand_Puk_For_Salaries(Persoonl.POLISNO)
                UpdateKontantAndMaand_PukForSalarisAndGrid()
            Else
                If rsArea.Area_besk = "Bfn SUT" Then
                    'm_GtbnForSalaries = Fetch_Maand_Gtbn_For_Salaries(Persoonl.POLISNO)
                    UpdateKontantAndMaand_GtbfnForSalarisAndGrid()
                ElseIf rsArea.Area_besk = "Bfn UV" Then
                    ' m_OuvsForSalaries = Fetch_Maand_Ouvs_For_Salaries(Persoonl.POLISNO)
                    UpdateKontantAndMaand_UovsForSalarisAndGrid()
                End If
            End If
            'Else
            '    If rsArea.Fields("Area_besk").Value = "Bfn SUT" Then
            '        strMSTabel = "Maand_gtbfn"
            '    ElseIf rsArea.Fields("Area_besk").Value = "Bfn UV" Then
            '        strMSTabel = "Maand_uovs"
            '    End If
            'End If

            'Grid1.col = 5
            'strSql = "SELECT * from " & strMSTabel
            'strSql = strSql & " WHERE Polisno = '" & Polisno.Text & "' "
            'strSql = strSql & " AND Trans_dat = cdate('" & Grid1.Text & "') "
            'm_salaris = stats5.OpenRecordset(strSql)

            'If m_salaris.BOF And m_salaris.EOF Then
            '    MsgBox("Click for details Tr (ansaksie) date of monthly cash...", 48, "Critical Error!")
            '    Exit Sub
            'End If

            'rond nou_ingevorder af tot 2 desimale

            ing = CDbl(Format(Val(nou_ingevorder.Text))) + 0.005

            ing = ing * 100

            ing = Int(CDbl(ing))

            ing = ing / 100

            '        m_salaris.Edit()
            '        m_salaris.Fields("INGEVORDER").Value = 0


            '        uitstaande.Text = uitstaande - ing

            tipe_ontv = "MS"

            '        'inkrementeer sekwensiele kwitansie nommer
            '        'skep n rekord vir die eerste keer
            '        If kwitansie_nr.RecordCount = 0 Then
            '            kwitansie_nr.addNew()
            '            kwitansie_nr.Fields("volg_nr").Value = "0000000000"
            '            kwitansie_nr.Update()
            '            kwitansie_nr.MoveFirst()
            '        Else
            '            kwitansie_nr.MoveFirst()
            '        End If

            '        
            '        If IsDBNull(kwitansie_nr.Fields("volg_nr").Value) Then

            '            kwit_nr = "0000000000"
            '        Else

            '            kwit_nr = kwitansie_nr.Fields("volg_nr").Value
            '        End If

            kwit_nr = Val(kwit_nr)

            kwit_nr = kwit_nr + 1

            kwit_nr = Str(kwit_nr)


            kwit_nr_s = kwit_nr

            kwit_nr = Trim(kwit_nr)




            '        nou_kwitansie = Tak_afk & "-" + tipe_ontv + "-" + kwit_nr

            '        m_salaris.Fields("Vord_Dat").Value = VB6.Format(Now, "dd/mm/yyyy")
            '        m_salaris.Fields("Kwit_Boek").Value = kwit_boek.Text

            '        m_salaris.Update()

            '        'opdateer kwitansie_nr met volgende nommer
            '        kwitansie_nr.MoveFirst()
            '        kwitansie_nr.Edit()

            '        kwitansie_nr.Fields("volg_nr").Value = kwit_nr_s
            '        kwitansie_nr.Update()

            '        'skryf rekord na recordset kontant
            '        ktant.addNew()
            GetMaandSalarisAndGrid()
            '        ktant.Fields("polisno").Value = Me.Polisno.Text
            '        ktant.Fields("vord_dat").Value = VB6.Format(Now, "dd/mm/yyyy")
            '        ktant.Fields("vord_premie").Value = Me.nou_ingevorder.Text
            '        ktant.Fields("jaar").Value = m_salaris.Fields("jaar").Value
            '        ktant.Fields("maand").Value = m_salaris.Fields("maand").Value

            '        ktant.Fields("kwitansie").Value = nou_kwitansie


            'If IsDBNull(Me.verw1.Text) Then
            '    Me.verw1.Text = " "
            'End If
            '
            'If IsDBNull(Me.verw2.Text) Then
            '    Me.verw2.Text = " "
            'End If
            '
            'If IsDBNull(Me.verw3.Text) Then
            '    Me.verw3.Text = " "
            'End If
            '
            'If IsDBNull(Me.verw4.Text) Then
            '    Me.verw4.Text = " "
            'End If
            '
            'If IsDBNull(Me.verw5.Text) Then
            '    Me.verw5.Text = " "
            'End If

            '        ktant.Fields("verw1").Value = Me.verw1.Text
            '        ktant.Fields("verw2").Value = Me.verw2.Text
            '        ktant.Fields("verw3").Value = Me.verw3.Text
            '        ktant.Fields("verw4").Value = Me.verw4.Text
            '        ktant.Fields("verw5").Value = Me.verw5.Text
            '        ktant.Fields("trans_dat").Value = VB6.Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")
            '        ktant.Fields("gekans").Value = False
            '        ktant.Fields("mk_trans_dat").Value = m_salaris.Fields("trans_dat").Value
            '        ktant.Fields("nuwe_tjekno").Value = " "

            '        ktant.Fields("kontant_tipe").Value = kontant_tipe


            '        ktant.Fields("tipe").Value = tipe_ontv
            '        If Me.Tjek.Checked <> 0 Then
            '            If terugbetaling.CheckState Or check_tj Then
            '                ktant.Fields("tjekno_uit").Value = Tjekno.Text
            '            Else
            '                ktant.Fields("tjekno_in").Value = Tjekno.Text
            '            End If

            '        End If

            '        ktant.Fields("eisno").Value = " "

            '        If Me.Tjek.Checked Then
            '            ktant.Fields("Tjekdatum").Value = Tjekdatum.Text
            '            ktant.Fields("Tjekbesonderhede").Value = Tjekbesonderhede.Text
            '        End If

            '        'invoer van kwitansie boek nr
            '        ktant.Fields("kwit_boek").Value = kwit_boek.Text

            '        ktant.Fields("LTPtipe").Value = ""

            '        ktant.Update()

        End If

        'md

        If check_md.CheckState Then

            'indeks op polisno/transaksie datum
            ' M_Debiet.Index = "PT_INDEX"

            If Val(nou_ingevorder.Text) = 0 Then
                MsgBox("There is no value in the amount charged field!", 48, "Exit!")
                nou_ingevorder.Focus()
                Exit Sub
            End If

            'type mismatch fout
            'On Error GoTo typ_mis_md
            'Err.Clear()
typ_mis_md:
            If Err.Number = 13 Then
                MsgBox("Click for details Transaction date of monthly debit ...", 48, "Critical Error!")
                Exit Sub
            End If
            If M_Debiet.NoMatch Then
                MsgBox("Click for details Tr (ansaksie) date of monthly debit ...", 48, "Critical Error!")
                Exit Sub
            End If
            On Error GoTo 0

            'rond nou_ingevorder af tot 2 desimale
            ing = CDbl(Format(Val(nou_ingevorder.Text))) + 0.005
            ing = ing * 100
            ing = Int(CDbl(ing))
            ing = ing / 100
            tipe_ontv = "MD"


            GetMaandDEBIT()

        End If


        'Langtermynpolis
        'Dim rsTermynPK As DAO.Recordset
        If (Me.Nuwepolis.CheckState = 1) Or (Me.Hernuwing.CheckState = 1) Or (Me.Wysiging.CheckState = 1) Then

            '            'indeks op polisno/transaksie datum
            '            k_gegenereer.Index = "PT_INDEX"

            If Val(nou_ingevorder.Text) = 0 Then

kry_tr_bedrag2:

                nou_ingevorder.Text = InputBox("Please provide the transaction amount")
                If nou_ingevorder.Text = "" Then
                    MsgBox("You have entered an amount, or you 'cancel' is selected, so the transaction will be canceled")
                    Exit Sub
                End If
            End If

            'as tjek nommer ingevul is, stel tjekno button aan anders kry die tjek nommer
            If Len(Tjekno.Text) <> 0 Then
                Tjek.Checked = 1
            Else

kry_tjek_weer2:

            End If

            'kies of transaksie tjek of kontant is
            If Me.Tjek.Checked = 0 And Me.Kont.Checked = 0 And Me.Elektronies.Checked = 0 Then
                MsgBox("Choose whether the transaction or cash is a check or electronic transaction")

                Exit Sub
            End If

            'as T(jek) gekies is, moet die tjek nommer ingevul wees
            If Me.Tjek.Checked <> 0 Then

                If Tjekno.Text = "" Or IsDBNull(Tjekno.Text) Or Val(Tjekno.Text) = 0 Then
                    MsgBox("Please enter the check number ...")
                    Tjekno.Focus()
                    Exit Sub
                End If
            End If

            'tjek nommer moet uniek wees
            If terugbetaling.CheckState Then
                If Tjekno.Text <> "" Then
                    '        ktant.Index = "tjuit_index"
                    '        ktant.Seek("=", Tjekno)
                    If Not (ktant.Item(i).Nomatch) Then
                        MsgBox("This check number is already used ...")
                        Tjekno.Focus()
                        Exit Sub
                    End If
                End If
            End If

            'memo veld moet ingevul wees
            If Me.verw1.Text = " " Then
                MsgBox("Please fill in the memo field")
                Exit Sub
            End If

            'type mismatch fout
            Err.Clear()

            'type mismatch - want daar is op niks geclick nie
typ_mis_gg2:


            If (Persoonl.NoMatch) Then
                If Persoonl.GEKANS Then

                    'Geen transaksies word toegelaat vir 'n gekanselleerde behalwe terugbetalings
                    If terugbetaling.CheckState = 0 Then
                        MsgBox("The person has been canceled. Net repayments of transactions allowed.")
                        Exit Sub
                    End If

                End If
            End If

            'toets of transaksie bedrag n waarde in het
            If Val(nou_ingevorder.Text) = 0 Then
                nou_ingevorder.Text = InputBox("What is the transaction amount?")
            End If

kry2_gt_jaar2:
            If Month(Now) = 12 Then

                volg_jaar = Year(Now) + 1


                volg_maand = 1
            Else

                volg_jaar = Year(Now)

                volg_maand = Month(Now) + 1
            End If

kry2_gt_dag2:

            'Vir 'n nuwe LT polis of 'n hernuwing moet die betaling op dag een geskied
            If (Me.Nuwepolis.CheckState = 1) Or (Me.Hernuwing.CheckState = 1) Then

                vb_dag = 1
            Else

                vb_dag = InputBox("On what day is the  transaction dd)?", , Format("01", "00"))

                If vb_dag = "" Then
                    MsgBox("You have canceled this transaction ...")
                    Exit Sub
                End If
            End If

            vb_maand = InputBox("For which month is the transaction mm)?", , Format(volg_maand, "00"))
            If vb_maand = "" Then
                MsgBox("You have canceled this transaction ...")
                Exit Sub
            End If

            'kry jaar ook
kry2_gt_jaar3b:

            vb_jaar = InputBox("What year was the deal yyyy)?", , volg_jaar)

            If vb_jaar = "" Then
                MsgBox("You have canceled this transaction ...")
                Exit Sub
            End If

            'genereer vooruitbetalings transaksie

            vb_afdat = (vb_dag) & "/" & (vb_maand) & "/" & (vb_jaar)

            If Not (IsDate(vb_afdat)) Then
                MsgBox("The date is incorrect. Please correct")
                GoTo kry2_gt_dag2
            End If

            'skryf jaar as ccjj
            jaar4 = vb_jaar

            'Nuwe polis - kry Langtermynrekord - dit is reeds deur poldata geskep
            'Hernuwing - kry Langtermynrekord - is reeds deur hernuwingskerm geskep
            'Wysiging - kry Langtermynrekord - is reeds deur hernuwingskerm geskep
            'Die vorderdatum moet voor of op die eerste maand wees van die tydperk vir die langtermynpolis

            GetDateNow()

            'termynSql = "SELECT * FROM langtermynpolis WHERE polisno = '" & Form1.POLISNO.Text & "' order by datumeindig desc"

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar)}
                params(0).Value = Persoonl.POLISNO


                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.GetLangtermynpolisByDatumEinding", params)
                Do While reader.Read

                    If (DateDiff(Microsoft.VisualBasic.DateInterval.Day, vb_afdat, reader("DatumBegin")) <= 0) Then
                        If reader("polisno") = Form1.POLISNO.Text Then
                            pkLangtermynPolis = reader("pkLangtermynpolis")
                            rekordgekry = 1
                            Exit Do
                        End If
                    Else
                        rekordgekry = 2
                    End If

                Loop

            End Using

            Select Case rekordgekry
                Case 0
                    MsgBox("There is no long-term policy information found.")
                    Exit Sub
                Case 2
                    MsgBox("The transaction date must be after the start of the long-term policy to be.")
                    Exit Sub
            End Select
            'Vir 'n hernuwing van 'n polis word die pkLangtermynpolis veld verkry vanaf die Langtermyntydperk vorm prosessering

            grid_nou_ingevorder = " "
            grid_kwitansie = " "
            grid_vord_dat = " "
            grid_trans_dat = Now

            'rond nou_ingevorder af tot 2 desimale

            ing = CDbl(Format(Val(nou_ingevorder.Text))) + 0.005

            ing = ing * 100

            ing = Int(CDbl(ing))

            ing = ing / 100


            'uitstaande.Text = uitstaande - ing
            If Me.Langtermynpolis.CheckState = 1 Then

                tipe_ontv = "LT"
            End If
            '            'inkrementeer sekwensiele kwitansie nommer

            '            'skep n rekord vir die eerste keer
            '           

            If IsDBNull(Me.verw1.Text) Then
                Me.verw1.Text = " "
            End If

            If IsDBNull(Me.verw2.Text) Then
                Me.verw2.Text = " "
            End If

            If IsDBNull(Me.verw3.Text) Then
                Me.verw3.Text = " "
            End If

            If IsDBNull(Me.verw4.Text) Then
                Me.verw4.Text = " "
            End If

            If IsDBNull(Me.verw5.Text) Then
                Me.verw5.Text = " "
            End If


            GetTermPolicy()

            'soek transaksies
            command4_Click(Command4, New System.EventArgs())

        End If

kry2_gt_dag2b:
typ_mis_tj:

fout:

        'gegenereerde transaksies
        If eerstebetaling.CheckState Or Vooruitbetaling.CheckState Or terugbetaling.CheckState Or Check_jk.CheckState Then

            'indeks op polisno/transaksie datum
            'k_gegenereer.Index = "PT_INDEX"

            If Val(nou_ingevorder.Text) = 0 Then

kry_tr_bedrag:

                nou_ingevorder.Text = InputBox("Please provide the transaction amount")
                If nou_ingevorder.Text = "" Then
                    MsgBox("You have entered an amount, or you 'cancel'  the transaction")
                    Exit Sub
                End If
            End If

            'as tjek nommer ingevul is, stel tjekno button aan anders kry die tjek nommer
            If Len(Tjekno.Text) <> 0 Then
                Tjek.Checked = 1
            Else

kry_tjek_weer:

            End If

            'kies of transaksie tjek of kontant is
            If Me.Tjek.Checked = 0 And Me.Kont.Checked = 0 And Me.Elektronies.Checked = 0 Then
                MsgBox("Choose whether the transaction or cash a check or electronic transaction")

                Exit Sub
            End If

            'as T(jek) gekies is, moet die tjek nommer ingevul wees
            If Me.Tjek.Checked <> 0 Then
                If Tjekno.Text = "" Or IsDBNull(Tjekno.Text) Or Val(Tjekno.Text) = 0 Then
                    MsgBox("Please enter the check number ...")
                    Tjekno.Focus()
                    Exit Sub
                End If
            End If

            '            'tjek nommer moet uniek wees
            If terugbetaling.CheckState Then

                ''n Terugbetaling mag nie meer wees as die oorblywende Unearned nie
                If Persoonl.BET_WYSE = "6" Then
                    Polisno.Text = Form1.POLISNO.Text
                    UitgeloopJN = "N"
                    Oor2maanduitgeloopJN = "N"
                    VertoonEarnedJN = "N"
                    Call VertoonLangtermynpolis(Polisno, UitgeloopJN, Oor2maanduitgeloopJN, VertoonEarnedJN)
                    If CDbl(nou_ingevorder.Text) > UnEarned Then
                        MsgBox("This reimbursement amount is greater than the unearned this policy.")
                    End If

                    If Tjekno.Text <> "" Then
                        'ktant.Index = "tjuit_index"
                        'ktant.Seek("=", Tjekno)
                        'If Not (ktant.Nomatch) Then
                        MsgBox("The check number is already used...")
                        Tjekno.Focus()
                        Exit Sub
                    End If
                End If

            End If


            'memo veld moet ingevul wees
            If Me.verw1.Text = " " Then
                MsgBox("Please fill in the memo field")
                Exit Sub
            End If

            Err.Clear()

typ_mis_gg:

            'Genereer self die transaksie

            'daar mag geen transaksies vir n gekanselleerde persoon gedoen word nie
            If Not (Persoonl.NoMatch) Then
                If Persoonl.GEKANS Then

                    'Geen transaksies word toegelaat vir 'n gekanselleerde behalwe terugbetalings
                    If terugbetaling.CheckState = 0 Then
                        MsgBox("The person has been canceled. Net repayments of transactions allowed.")
                        Exit Sub
                    End If

                End If
            End If

            '            'toets of transaksie bedrag n waarde in het
            If Val(nou_ingevorder.Text) = 0 Then
                nou_ingevorder.Text = InputBox("What is the transaction amount?")
            End If

kry2_gt_jaar:
            If Month(Now) = 12 Then
                volg_jaar = Year(Now) + 1

                volg_maand = 1
            Else
                volg_jaar = Year(Now)
                volg_maand = Month(Now) + 1
            End If

kry2_gt_dag:

            vb_dag = InputBox("What day is the transaction (dd)?", , ("01"))
            If vb_dag = "" Then
                MsgBox("You have canceled this transaction ...")
                Exit Sub
            End If
            vb_maand = InputBox("For which month is the transaction (mm)?", , (volg_maand))

            If vb_maand = "" Then
                MsgBox("You have canceled this transaction ...")
                Exit Sub
            End If

            'kry jaar ook
kry2_gt_jaar3:

            vb_jaar = InputBox("What year was the deal (yyyy)?", , volg_jaar)
            If vb_jaar = "" Then
                MsgBox("You have canceled this transaction ...")
                Exit Sub
            End If

            'genereer vooruitbetalings transaksie
            vb_afdat = (vb_dag) & "/" & (vb_maand) & "/" & (vb_jaar)

            If Not (IsDate(vb_afdat)) Then
                MsgBox("The date is incorrect. Please correct")
                GoTo kry2_gt_dag
            End If

            'skryf jaar as ccjj
            jaar4 = vb_jaar

            '  grid_nou_ingevorder = " "
            grid_kwitansie = " "
            grid_vord_dat = " "
            grid_trans_dat = Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")



            ing = CDbl(Format(Val(nou_ingevorder.Text))) + 0.005

            ing = ing * 100

            ing = Int(CDbl(ing))

            ing = ing / 100

            'uitstaande.Text = uitstaande - ing

            If Me.eerstebetaling.CheckState = 1 Then

                tipe_ontv = "EB"
            Else
                If Me.Vooruitbetaling.CheckState = 1 Then

                    tipe_ontv = "VB"
                Else
                    If Me.terugbetaling.CheckState = 1 Then

                        tipe_ontv = "TB"
                    Else
                        If Me.Check_jk.CheckState = 1 Then

                            tipe_ontv = "JK"
                        End If

                    End If
                End If
            End If

            GetTypeOfPayment()
        End If

        kry_gen_transaksies()

        'Maak tjek labels invisible asook tjek/kontant/elektronies se values false
        Label12.Visible = False
        Tjekno.Visible = False
        Label15.Visible = False
        nuwe_tjekno.Visible = False
        Label16.Visible = False
        Tjekdatum.Visible = False
        Label17.Visible = False
        Tjekbesonderhede.Visible = False
        Tjek.Checked = False
        Kont.Checked = False
        Elektronies.Checked = False
        DataGridView1.Refresh()

        'soek transaksies
        command4_Click(Command4, New System.EventArgs())

    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        '	Dim v_betwyse As Object
        '	Dim v_area As Object
        '	Dim TITEL As Object
        '	Dim Printer As New Printer
        Dim i As Integer
        '	'druk n kwitansie
        '	Dim stats5 As DAO.Database
        '	'UPGRADE_WARNING: Arrays in structure ktant may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '	Dim ktant As DAO.Recordset
        '	'UPGRADE_WARNING: Arrays in structure VT_Details may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '	Dim VT_Details As DAO.Recordset
        '	stats5 = DAODBEngine_definst.OpenDatabase(pol_path & "\Stats5.mdb")
        '	ktant = stats5.OpenRecordset("Kontant")
        '	VT_Details = stats5.OpenRecordset("maand_vt_details")

        '	'stel indekse
        '	VT_Details.Index = "PT_INDEX"
        '	ktant.Index = "K_INDEX"

        '	'kry recordset kontant se rekord (kwitansie)
        '	ktant.Index = "PT_INDEX"

        '	If Check_VT.CheckState Then
        '		Grid1.col = 8
        '	Else
        '		Grid1.col = 5
        'End If
        '	ktant.Seek("=", POLISNO, UCase(Grid1.Text))
        If ktant.Item(i).Nomatch Then
            MsgBox("n Receipt can be printed only on a cash receipts transaction. Cash receipts transactions, a receipt number in the receipt column.")
            Exit Sub
        End If

        '	'vertoon dialog wat drukker selekteer
        '	CommonDialog1Print.ShowDialog()

        '	'kry persoonl details
        '	Persoonl.Seek("=", POLISNO)
        If Persoonl.NoMatch Then
            MsgBox("Persoon not found in PERSOONL", 48, "Critical Error!")
            Exit Sub
        End If

        '	'druk...
        '	'watter tipe dokument
        '	'afrikaans
        '	If Persoonl.Fields("TAAL").Value = 0 Then
        '		Printer.FontBold = True
        '		Printer.FontUnderline = True
        '		Printer.FontSize = 13.5
        '		Printer.Write(TAB(18), "KWITANSIE")
        '		Printer.FontUnderline = False
        '		Printer.Print(TAB(35), "Kwitansie nommer: " & ktant.Fields("kwitansie").Value)
        '		Printer.Print(TAB(35), "Datum           : " & VB6.Format(Now, "dd/mm/yyyy"))

        '		Printer.FontBold = False
        '		Printer.FontSize = 9.75
        '		Printer.Print()
        KwitansieReportViewer.Show()
        '		'verskaf deur
        '		Printer.FontBold = True
        '		Printer.FontUnderline = True
        '		Printer.Print("Verskaf deur:")
        '		Printer.FontBold = False
        '		Printer.FontUnderline = False
        '		Printer.Print("Mooirivier Makelaars-" & tak_hoof.Fields("tak_naam").Value)
        '		Printer.Print("Posbus " & tak_hoof.Fields("tak_posbus").Value)
        '		Printer.Print(tak_hoof.Fields("tak_dorp").Value)
        '		Printer.Print(tak_hoof.Fields("tak_poskode").Value)
        '		Printer.Print("Telefoon nommer: " & tak_hoof.Fields("tak_tel").Value)
        '		Printer.Print()

        '		'verskaf aan
        '		Printer.FontBold = True
        '		Printer.FontUnderline = True
        '		Printer.Print("Verskaf aan:")
        '		Printer.FontBold = False
        '		Printer.FontUnderline = False

        'kry titel
        'Select Case Persoonl.Fields("titel").Value
        '    Case "0"

        '        TITEL = "Mnr."
        '    Case "1"

        '        TITEL = "Me."
        '    Case "2"

        '        TITEL = "Prof."
        '    Case "3"

        '        TITEL = "Dr."
        '    Case "4"

        '        TITEL = ""
        '    Case "5"

        '        TITEL = "Pastoor"
        '    Case "6"

        '        TITEL = "Ds."
        '    Case "7"

        '        TITEL = "Brig Genl"
        '    Case "12"

        '        TITEL = "Brigadier"
        '    Case "13"

        '        TITEL = "Regter"
        '    Case "14"

        '        TITEL = "Graaf"

        'End Select


        '		Printer.Write(" " & TITEL)
        '		Printer.Write(" " & VB.Left(Persoonl.Fields("voorl").Value, 5))
        '		Printer.Print(" " & Persoonl.Fields("versekerde").Value)
        '		Printer.Print(Persoonl.Fields("adres").Value)
        '		Printer.Print(Persoonl.Fields("adres1").Value)
        '		Printer.Print(Persoonl.Fields("adres2").Value)
        '		Printer.Print(Persoonl.Fields("adres3").Value)
        '		Printer.Print()

        '		'kwitansie details
        '		Printer.Print("Polis nommer:", TAB(30), ktant.Fields("polisno"))

        '		'Kry area
        '		tak_area.Index = "k_index"
        '		tak_area.Seek("=", Persoonl.Fields("area"))

        '		If tak_area.NoMatch Then

        '			v_area = "Geen area gevind vir kode " + Persoonl.Fields("area").Value + " nie"
        '		Else

        '			v_area = tak_area.Fields("area_besk").Value
        '		End If

        '		'Kry betaalwyse
        '		Select Case Persoonl.Fields("bet_wyse").Value
        '			Case "1"

        '				v_betwyse = "Maandeliks kontant"
        '			Case "2"

        '				v_betwyse = "Jaarliks kontant"
        '			Case "3"

        '				v_betwyse = "Maandeliks salaris"
        '			Case "4"

        '				v_betwyse = "Maandeliks debiet"
        '			Case "5"

        '				v_betwyse = "Maandeliks elektronies"
        '		End Select

        '		Printer.Print("Area:", TAB(30), v_area)
        '		Printer.Print("Betaalwyse:", TAB(30), v_betwyse)
        '		Printer.Print("Maand/Jaar betaal vir:", TAB(30), ktant.Fields("maand").Value & "/" & ktant.Fields("jaar").Value)
        '		Printer.Print("Bedrag (Belasting ingesluit):", TAB(30), VB6.Format(ktant.Fields("vord_premie").Value, "0.00"))
        '		Printer.Print("Verwysing:", TAB(30), ktant.Fields("verw1"))
        '		Printer.Print("", TAB(30), ktant.Fields("verw2"))
        '		Printer.Print("", TAB(30), ktant.Fields("verw3"))
        '		Printer.Print("", TAB(30), ktant.Fields("verw4"))
        '		Printer.Print("", TAB(30), ktant.Fields("verw5"))

        '		Printer.Print(" ")
        '		Printer.Print(" ")
        '		Printer.Print(" ")
        '		Printer.Print(" ")
        '		Printer.Print("_______________________________")
        '		Printer.Print("Ontvang deur")
        '		Printer.EndDoc()
        '	Else
        '		'engels
        '		Printer.FontBold = True
        '		Printer.FontUnderline = True
        '		Printer.FontSize = 13.5
        '		Printer.Write(TAB(18), "RECEIPT")

        '		Printer.FontUnderline = False
        '		Printer.Print(TAB(35), "Receipt number: " & ktant.Fields("kwitansie").Value)
        '		Printer.Print(TAB(35), "Date          : " & VB6.Format(Now, "dd/mm/yyyy"))

        '		Printer.FontBold = False
        '		Printer.FontSize = 9.75
        '		Printer.Print()

        '		'verskaf deur
        '		Printer.FontBold = True
        '		Printer.FontUnderline = True
        '		Printer.Print("Supplied by:")
        '		Printer.FontBold = False
        '		Printer.FontUnderline = False
        '		Printer.Print("Mooiriver Brokers-" & tak_hoof.Fields("tak_naam").Value)
        '		Printer.Print("P.O. Box " & tak_hoof.Fields("tak_posbus").Value)
        '		Printer.Print(tak_hoof.Fields("tak_dorp").Value)
        '		Printer.Print(tak_hoof.Fields("tak_poskode").Value)
        '		Printer.Print("Telephone number: " & tak_hoof.Fields("tak_tel").Value)
        '		Printer.Print()

        '		'verskaf aan
        '		Printer.FontBold = True
        '		Printer.FontUnderline = True
        '		Printer.Print("Supplied to:")
        '		Printer.FontBold = False
        '		Printer.FontUnderline = False

        '		'kry titel
        '		Select Case Persoonl.Fields("titel").Value
        '			Case "0"

        '				TITEL = "Mr."
        '			Case "1"

        '				TITEL = "Ms."
        '			Case "2"

        '				TITEL = "Prof."
        '			Case "3"

        '				TITEL = "Dr."
        '			Case "4"

        '				TITEL = ""
        '			Case "5"

        '				TITEL = "Pastor"
        '			Case "6"
        '				
        '				TITEL = "Rev."
        '			Case "7"
        '				
        '				TITEL = "Brig Genl"
        '			Case "8"
        '				
        '				TITEL = "Kolonel"
        '			Case "9"
        '				
        '				TITEL = "Luit. Genl."
        '			Case "A"
        '				
        '				TITEL = "Kaptein"
        '			Case "B"
        '				
        '				TITEL = "Advokaat"
        '			Case "C"
        '				
        '				TITEL = "Brigadier"
        '			Case "D"
        '				
        '				TITEL = "Regter"
        '			Case "E"
        '				
        '				TITEL = "Graaf"
        '		End Select

        '		
        '		Printer.Write(" " & TITEL)
        '		Printer.Write(" " & VB.Left(Persoonl.Fields("voorl").Value, 5))
        '		Printer.Print(" " & Persoonl.Fields("versekerde").Value)
        '		Printer.Print(Persoonl.Fields("adres").Value)
        '		Printer.Print(Persoonl.Fields("adres1").Value)
        '		Printer.Print(Persoonl.Fields("adres2").Value)
        '		Printer.Print(Persoonl.Fields("adres3").Value)
        '		Printer.Print()

        '		'Kry betaalwyse
        '		Select Case Persoonl.Fields("bet_wyse").Value
        '			Case "1"

        '				v_betwyse = "Monthly cash"
        '			Case "2"
        '				'UPGRADE_WARNING: Couldn't resolve default property of object v_betwyse. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '				v_betwyse = "Yearly cash"
        '			Case "3"
        '				'UPGRADE_WARNING: Couldn't resolve default property of object v_betwyse. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '				v_betwyse = "Monthly salary"
        '			Case "4"
        '				'UPGRADE_WARNING: Couldn't resolve default property of object v_betwyse. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '				v_betwyse = "Monthly debit order"
        '			Case "5"
        '				'UPGRADE_WARNING: Couldn't resolve default property of object v_betwyse. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '				v_betwyse = "Monthly electronic"
        '		End Select

        '		'kwitansie details
        '		Printer.Print("Policy Number:", TAB(30), ktant.Fields("polisno"))
        '		Printer.Print("Month/Year paid for:", TAB(30), ktant.Fields("maand").Value & "/" & ktant.Fields("jaar").Value)
        '		Printer.Print("Payment (Tax included):", TAB(30), VB6.Format(ktant.Fields("vord_premie").Value, "0.00"))
        '		Printer.Print("Reference:", TAB(30), ktant.Fields("verw1"))
        '		Printer.Print("", TAB(30), ktant.Fields("verw2"))
        '		Printer.Print("", TAB(30), ktant.Fields("verw3"))
        '		Printer.Print("", TAB(30), ktant.Fields("verw4"))
        '		Printer.Print("", TAB(30), ktant.Fields("verw5"))

        '		Printer.Print(" ")
        '		Printer.Print(" ")
        '		Printer.Print(" ")
        '		Printer.Print(" ")
        '		Printer.Print("_______________________________")
        '		Printer.Print("Received by")
        '		Printer.EndDoc()

        '		Printer.EndDoc()

        '	End If

        '	Command2.Visible = False

        'End Sub

    End Sub
    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        Dim Check_bb As Object
        Dim Check_wr As Object
        Dim check_tj As Object
        Dim vt_trans_dat As String
        Dim gen_trans As Object
        Dim bal As Object
        'Dim ing As Object
        Dim i As Integer
        Dim sSql As Object
        'Dim strKwitansie As Object
        Dim intTot As Object
        Dim passw As String
        'Dim m_salarie As Maand_Puk_For_SalariesEntity


        m_elektronies = FetchMaandElectronics(Persoonl.POLISNO)
        ktant = FetchKontantDetails(Persoonl.POLISNO)
        vt_details = FetchVTDetails(Persoonl.POLISNO)
        k_gegenereer = FetchKontantGegenereer(Persoonl.POLISNO)
        vt_balans = FetchVt_Balans(Persoonl.POLISNO, Persoonl.VOORL, Persoonl.VERSEKERDE)
        m_salarie = FetchMaand_Puk_For_Salaries()
        'Kanselleer n kontant ontvangste

        '	'daar mag geen transaksies vir n gekanselleerde persoon gedoen word nie
        'Persoonl.Index = "pn_index"
        'Persoonl.Seek("=", Me.Polisno)
        If Not (Persoonl.NoMatch) Then
            If Persoonl.GEKANS Then
                MsgBox("The person has been canceled. No transactions are allowed...")
                Exit Sub
            End If
        End If

        'password?
        passw = InputBox("What is your password?")

        If passw <> "Cancelled" Then
            MsgBox("You have entered an incorrect password. Please try again.")
            GoTo einde_kans
        End If

        'Maak tjek labels invisible asook tjek/kontant/elektronies se values 1
        Label12.Visible = False
        Tjekno.Visible = False
        Label15.Visible = False
        nuwe_tjekno.Visible = False
        Label16.Visible = False
        Tjekdatum.Visible = False
        Label17.Visible = False
        Tjekbesonderhede.Visible = False
        Tjek.Checked = False
        Kont.Checked = False
        Elektronies.Checked = False
        Me.Refresh()

        'Gegenereerde transaksies mag gekanselleer word
        'k_gegenereer.Index = "pt_index" 'Polisno/Trans dat

        'Grid1.col = 3

        If Mid(DataGridView1.SelectedRows(0).Cells(3).Value, 5, 2) = "EB" Or Mid(DataGridView1.SelectedRows(0).Cells(3).Value, 5, 2) = "VB" Or Mid(DataGridView1.SelectedRows(0).Cells(3).Value, 5, 2) = "TB" Then

            'Grid1.col = 5
            'k_gegenereer.Seek("=", Polisno, Grid1.Text)
            If k_gegenereer.nomatch Then

            Else
                '    '			'Kanselleer gegenereerde transaksie
                '    '			k_gegenereer.Edit()
                '    '			k_gegenereer.Fields("gekans").Value = True
                '    '			k_gegenereer.Update()
                UpdateKontantGenereer_For_Cancel()
                '    '			ktant.Index = "PT_INDEX"
                '    '			ktant.Seek("=", POLISNO, Grid1.Text)

                If Not ktant.Item(i).Nomatch Then
                    '    '				ktant.Edit()
                    '    '				ktant.Fields("Kans_dat").Value = VB6.Format(Now, "dd/mm/yyyy")
                    UpdateKontant_For_Cancel()
                    '    '				ktant.Fields("Gekans").Value = True
                    '    '				ktant.Update()
                End If

                '    '			'Opdateer nou_ingevorder
                nou_ingevorder.Text = Val(nou_ingevorder.Text) - k_gegenereer.premie
                'Maak kansellasie button invisible
                Command3.Visible = False
                'soek transaksies
                command4_Click(Command4, New System.EventArgs())


                Exit Sub

            End If
        End If
        '	'vt
        If Check_VT.Checked = True Then
            '    'opdateer recordset kontant
            '    ktant.Index = "k_INDEX" 'kwitansie
            '    Grid1.col = 5
            intTot = InStr(DataGridView1.SelectedRows(0).Cells(5).Value, "/")
            If intTot = 0 Then
                strKwitansie = DataGridView1.SelectedRows(0).Cells(5).Value
            Else
                'strKwitansie = VB.Left(Grid1.Text, intTot - 1)
                strKwitansie = Mid(DataGridView1.SelectedRows(0).Cells(5).Value, intTot - 1)
            End If

            vt_trans_dat = FetchKontantByKwitansie()
            '		sSql = "SELECT * from kontant where kwitansie = '" & strKwitansie & "' "
            '			sSql = sSql & "AND polisno = '" & Me.POLISNO.Text & "' "
            '		sSql = sSql & "AND not gekans"
            '		rs = stats5.OpenRecordset(sSql)
            If vt_trans_dat = "" Then
                '			rs.Edit()
                '			rs.Fields("trans_dat").Value = VB6.Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")
                '			rs.Fields("gekans").Value = True
                '			rs.Fields("kans_dat").Value = VB6.Format(Now, "dd/mm/yyyy")
                '			rs.Update()
                MsgBox("There is no cash receipts for the detail line is selected")
                Exit Sub
            Else
                dteTransaksieDatum = CDate(vt_trans_dat)
            End If

            '		'opdateer vt_details
            '		VT_Details.Index = "PT_INDEX"
            '		VT_Details.Seek("=", POLISNO, dteTransaksieDatum)
            If vt_details.Nomatch Then
                MsgBox("VT is not the receipts are not...", 48, "Critical Error!")
                Exit Sub
                'Else
                '    '			Grid1.row = Grid1.row - 1
                '    '			Grid1.col = 1
                '    If DataGridView1.SelectedRows(0).Cells(1).Value = "" Or DataGridView1.SelectedRows(0).Cells(1).Value = " " Then
                '    Else
                '        Do While Polisno.Text = vt_details.POLISNO And CDate(vt_trans_dat) = vt_details.TRANS_DAT
                '            'Grid1.Col = 1
                '            If DataGridView1.SelectedRows(0).Cells(0).Value = vt_details.DatumAangevra Then
                '                Exit Do
                '            End If
                '            '          VT_Details.MoveNext()
                '        Loop
                '    End If
            End If

            'rond ktant("vord_premie") af tot 2 desimale
            ing = CDbl(ktant.Item(i).vord_premie) + 0.005
            ing = ing * 100
            ing = Int(CDbl(ing))
            ing = ing / 100

            '      VT_Details.Edit()
            '      VT_Details.Fields("VT_INGEVORDER").Value = 0
            '      VT_Details.Fields("VT_VORD_DATUM").Value = "01/01/0100"
            '      VT_Details.Fields("VT_KWITANSIE").Value = Space(20)
            '      VT_Details.Update()

            '      'opdateer vt_balans
            '      vt_balans.Index = "PN_INDEX"
            '      vt_balans.Seek("=", Polisno)

            '      vt_balans.Edit()
            '      'rond vt_balans af tot 2 desimale
            bal = CDbl(vt_balans.VT_BALANS) + 0.005
            bal = bal * 100
            bal = Int(CDbl(bal))
            bal = bal / 100



            vtBalans = bal + ing

            UpdateVt_DetailsAndVt_BalansFor_Cancel()

            '      vt_balans.Update()
            uitstaande.Text = uitstaande.Text + ing
        End If

        '      'mk
        If Check_mk.Checked = True Then
            'opdateer recordset kontant
            'ktant.Index = "PT_INDEX"
            'Grid1.Col = 5
            'ktant.Seek("=", Polisno, Grid1.Text)
            If ktant.Item(i).Nomatch Then
                MsgBox("There is no cash receipts for the detail line is selected.")
                Exit Sub
            End If

            '          'rond ktant("vord_premie") af tot 2 desimale
            ing = CDbl(ktant.Item(i).vord_premie) + 0.005
            ing = ing * 100
            ing = Int(CDbl(ing))
            ing = ing / 100

            '          ktant.Edit()
            '          ktant.Fields("polisno").Value = Me.Polisno.Text
            '          ktant.Fields("trans_dat").Value = VB6.Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")
            '          ktant.Fields("gekans").Value = True
            '          ktant.Fields("kans_dat").Value = VB6.Format(Now, "dd/mm/yyyy")
            '          ktant.Update()

            UpdateKontant_Record()

            '          'opdateer m_kontant
            '          m_kontant.Index = "PT_INDEX"
            '          m_kontant.Seek("=", Polisno, ktant.Fields("mk_trans_dat"))
            If m_kontant.Nomatch Then
                MsgBox("No MK is not for the receipts...", 48, "Critical Error!")
                Exit Sub
            End If


            '          m_kontant.Edit()
            '          m_kontant.Fields("INGEVORDER").Value = 0
            '          m_kontant.Update()
            UpdateM_Kontant_For_Cancel()


            uitstaande.Text = uitstaande.Text + ing
        End If


        '      'Maandeliks elektronies
        If Check_me.Checked = True Then
            '          'opdateer recordset kontant
            '          ktant.Index = "PT_INDEX"
            '          Grid1.Col = 5
            '          ktant.Seek("=", Polisno, Grid1.Text)
            If ktant.Item(i).Nomatch Then
                MsgBox("There is no cash receipts for the detail line is selected.")
                Exit Sub
            End If

            '          'rond ktant("vord_premie") af tot 2 desimale
            ing = CDbl(ktant.Item(i).vord_premie) + 0.005
            ing = ing * 100
            ing = Int(CDbl(ing))
            ing = ing / 100

            '          ktant.Edit()
            '          ktant.Fields("polisno").Value = Me.Polisno.Text
            '          ktant.Fields("trans_dat").Value = VB6.Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")
            '          ktant.Fields("gekans").Value = True
            '          ktant.Fields("kans_dat").Value = VB6.Format(Now, "dd/mm/yyyy")
            '          ktant.Update()

            UpdateKontant_Record()

            '          'opdateer m_elektronies
            '          m_elektronies.Index = "PT_INDEX"
            '          m_elektronies.Seek("=", Polisno, ktant.Fields("me_trans_dat"))
            If m_elektronies.NoMatch Then
                MsgBox("None 'Monthly electronically'is not for the receipts...", 48, "Critical Error!")
                Exit Sub
            End If

            '          m_elektronies.Edit()
            '          m_elektronies.Fields("INGEVORDER").Value = 0
            '          m_elektronies.Update()

            UpdateM_Electronies_For_Cancel()

            uitstaande.Text = uitstaande.Text + ing
        End If

        '      'jk
        If Persoonl.BET_WYSE = "2" Then
            '          'opdateer recordset kontant
            '          ktant.Index = "PT_INDEX"
            '          ktant.Seek("=", Polisno, Grid1.Text)
            If ktant.Item(i).Nomatch Then
                MsgBox("There is no cash receipts for the detail line is selected.")
                Exit Sub
            End If

            '          'rond ktant("vord_premie") af tot 2 desimale
            ing = CDbl(ktant.Item(i).vord_premie) + 0.005
            ing = ing * 100
            ing = Int(CDbl(ing))
            ing = ing / 100

            '          ktant.Edit()
            '          ktant.Fields("polisno").Value = Me.Polisno.Text
            '          ktant.Fields("trans_dat").Value = VB6.Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")
            '          ktant.Fields("gekans").Value = True
            '          ktant.Fields("kans_dat").Value = VB6.Format(Now, "dd/mm/yyyy")
            '          ktant.Update()

            UpdateKontant_Record()

            '          'opdateer k_gegenereer
            '          k_gegenereer.Index = "PT_INDEX"
            '          k_gegenereer.Seek("=", Polisno, ktant.Fields("gg_trans_dat"))

            If k_gegenereer.nomatch Then
                MsgBox("No JK is not the receipts...", 48, "Critical Error!")
                Exit Sub
            End If

            '          k_gegenereer.Edit()

            k_geneer_Ingevorde = k_gegenereer.ingevorder - ing
            k_geneer_Vord_Premie = k_gegenereer.vord_premie - ing


            UpdateK_GegenereerForCancel()

            uitstaande.Text = uitstaande.Text + ing

        End If

        '      'Termynpolis
        If Langtermynpolis.Checked = True Then
            '          'opdateer recordset kontant
            '          ktant.Index = "PT_INDEX"
            '          Grid1.Col = 5
            '          ktant.Seek("=", Polisno, Grid1.Text)
            If ktant.Item(i).Nomatch Then
                MsgBox("There is no cash receipts for the detail line is selected.")
                Exit Sub
            End If

            '          'rond ktant("vord_premie") af tot 2 desimale
            ing = CDbl(ktant.Item(i).vord_premie) + 0.005
            ing = ing * 100
            ing = Int(CDbl(ing))
            ing = ing / 100

            '          ktant.Edit()
            '          ktant.Fields("polisno").Value = Me.Polisno.Text
            '          ktant.Fields("trans_dat").Value = VB6.Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")
            '          ktant.Fields("gekans").Value = True
            '          ktant.Fields("kans_dat").Value = VB6.Format(Now, "dd/mm/yyyy")
            '          ktant.Update()
            UpdateKontant_Record()


            '          'opdateer k_gegenereer
            '          k_gegenereer.Index = "PT_INDEX"
            '          k_gegenereer.Seek("=", Polisno, ktant.Fields("gg_trans_dat"))

            If k_gegenereer.nomatch Then
                MsgBox("No transaction is generated for receipt no...", 48, "critical Error!")
                Exit Sub
            End If

            '          k_gegenereer.Delete()

            DeleteK_GegenereerRecord()


            uitstaande.Text = uitstaande.Text + ing

        End If

        '      'eb - eerste betaling of jaarliks kontant
        If gen_trans Then
            '          'opdateer recordset kontant_gegenereer
            '          k_gegenereer.Index = "PT_INDEX"
            '          k_gegenereer.Seek("=", Polisno, Grid1.Text)
            If k_gegenereer.nomatch Then
                MsgBox("There is no cash receipts for the detail line is selected.")
                Exit Sub
            End If

            '          'rond k_gegenereer("vord_premie") af tot 2 desimale
            ing = CDbl(k_gegenereer.vord_premie) + 0.005
            ing = ing * 100
            ing = Int(CDbl(ing))
            ing = ing / 100
            '          k_gegenereer.Edit()
            '          k_gegenereer.Fields("trans_dat").Value = VB6.Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")
            '          k_gegenereer.Fields("gekans").Value = True
            '          k_gegenereer.Fields("kans_dat").Value = VB6.Format(Now, "dd/mm/yyyy")
            '          k_gegenereer.Update()


            '          k_gegenereer.Edit()
            k_geneer_Ingevorde = k_gegenereer.ingevorder - ing
            k_geneer_Vord_Premie = k_gegenereer.vord_premie - ing

            '          k_gegenereer.Update()

            UpdateK_GegenereerForCancel()

            uitstaande.Text = uitstaande.Text + ing
        End If

        '      'ms
        If Check_ms.CheckState Then
            '          'opdateer recordset kontant
            '          ktant.Index = "PT_INDEX"
            '          Grid1.Col = 5
            '          ktant.Seek("=", Polisno, Grid1.Text)



            If ktant.Item(i).Nomatch Then
                MsgBox("There is no cash receipts for the detail line is selected.")
                Exit Sub
            End If

            '          'rond ktant("vord_premie") af tot 2 desimale
            ing = CDbl(ktant.Item(i).vord_premie) + 0.005
            ing = ing * 100
            ing = Int(CDbl(ing))
            ing = ing / 100

            '          ktant.Edit()
            '          ktant.Fields("polisno").Value = Me.Polisno.Text
            '          ktant.Fields("trans_dat").Value = VB6.Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")
            '          ktant.Fields("gekans").Value = True
            '          ktant.Fields("kans_dat").Value = VB6.Format(Now, "dd/mm/yyyy")
            '          ktant.Update()

            UpdateKontant_Record()

            '          'opdateer m_salaris
            '          Set_MonthlySalaryRecordset()
            '          m_salaris.Index = "PT_INDEX"
            '          m_salaris.Seek("=", Polisno, ktant.Fields("mk_trans_dat"))
            m_salaris3 = Fetch_Maand_Puk_For_Salaries(Persoonl.POLISNO)

            If m_salaris3.NoMatch Then

                MsgBox("No MS is not the receipts...", 48, "Critical Error!")
                Exit Sub

            End If

            '          m_salaris.Edit()
            '          m_salaris.Fields("INGEVORDER").Value = 0
            'If UCase(Form1.AREA.Text) = "PUK" Then

            '    If m_salarie.PREMIE = m_salarie.VORD_PREMIE Then
            '        m_salaris.Fields("Match").Value = True
            '    End If

            'End If
            ''          m_salaris.Update()

            UpdateMaand_Puk_For_Cancel()

            uitstaande.Text = uitstaande.Text + ing

        End If

        '      'md
        If check_md.Checked = True Then
            '          'opdateer recordset kontant
            '          ktant.Index = "PT_INDEX"

            '          Grid1.Col = 5
            '          ktant.Seek("=", Polisno, Grid1.Text)
            If ktant.Item(i).Nomatch Then
                MsgBox("There is no cash receipts for the detail line is selected.")
                Exit Sub
            End If

            '          'rond ktant("vord_premie") af tot 2 desimale
            ing = CDbl(ktant.Item(i).vord_premie) + 0.005
            ing = ing * 100
            ing = Int(CDbl(ing))
            ing = ing / 100
            '          ktant.Edit()
            '          ktant.Fields("polisno").Value = Me.Polisno.Text
            '          ktant.Fields("trans_dat").Value = VB6.Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")
            '          ktant.Fields("gekans").Value = True
            '          ktant.Fields("kans_dat").Value = VB6.Format(Now, "dd/mm/yyyy")
            '          ktant.Update()
            UpdateKontant_Record()
            '          'opdateer m_debiet
            '          M_Debiet.Index = "PT_INDEX"
            '          M_Debiet.Seek("=", Polisno, ktant.Fields("md_trans_dat"))
            If M_Debiet.NoMatch Then
                MsgBox("No MD is not for the receipts...", 48, "Critical Error!")
                Exit Sub
            End If

            '          M_Debiet.Edit()
            '          M_Debiet.Fields("INGEVORDER").Value = 0
            '          If M_Debiet.Fields("Premie").Value = M_Debiet.Fields("Vord_premie").Value Then
            '              M_Debiet.Fields("Match").Value = True
            '          End If

            '          M_Debiet.Update()
            UpdateMAAND_Debiet()

            uitstaande.Text = uitstaande.Text + ing

        End If

        'tj, wr of bb
        If check_tj Or Check_wr Or Check_bb Then
            'opdateer recordset kontant
            'ktant.Index = "PT_INDEX"
            'ktant.Seek("=", Polisno, Grid1.Text)
            If ktant.Item(i).Nomatch Then
                MsgBox("There is no cash receipts for the detail line selected.")
                Exit Sub
            End If

            'rond ktant("vord_premie") af tot 2 desimale
            ing = CDbl(ktant.Item(i).vord_premie) + 0.005
            ing = ing * 100
            ing = Int(CDbl(ing))
            ing = ing / 100

            '          ktant.Edit()
            '          ktant.Fields("polisno").Value = Me.Polisno.Text
            '          ktant.Fields("trans_dat").Value = VB6.Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")
            '          ktant.Fields("gekans").Value = True
            '          ktant.Fields("kans_dat").Value = VB6.Format(Now, "dd/mm/yyyy")
            '          ktant.Update()

            UpdateKontant_Record()

            'opdateer e_kontant
            'e_kontant.Index = "PT_INDEX"
            'e_kontant.Seek("=", Polisno, ktant.Fields("ei_trans_dat"))
            If e_kontant.NoMatch Then
                MsgBox("No check, cash or co-wreck is not the receipts ...", 48, "Critical Error")
                Exit Sub
            End If

            '          e_kontant.Edit()
            'e_kontant.Fields("INGEVORDER").Value = e_kontant.Fields("INGEVORDER") - ing
            e_Kontant_Ingevorde = e_kontant.ingevorder - ing
            '          e_kontant.Update()

            UpdateEise_Kontant()

            uitstaande.Text = uitstaande.Text + ing

        End If

        'gegenereerde transaksie self of kontant wat saamgaan daarmee
        If terugbetaling.Checked = True Then
            'opdateer recordset kontant _gegenereer
            'k_gegenereer.Index = "PT_INDEX"
            'k_gegenereer.Seek("=", Polisno, Grid1.Text)

            '          'delete kontant transaksies vir die gegenereerde transaksie
            If k_gegenereer.nomatch Then

                '              ktant.Index = "PT_INDEX"
                '              ktant.Seek("=", Polisno, Grid1.Text)
                If ktant.Item(i).Nomatch Then
                    MsgBox("There had exists a cash receipts for the detail line is selected.")
                    Exit Sub
                End If

                '              ktant.Edit()
                '              ktant.Fields("polisno").Value = Me.Polisno.Text
                '              ktant.Fields("trans_dat").Value = VB6.Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")
                '              ktant.Fields("gekans").Value = True
                '              ktant.Fields("kans_dat").Value = VB6.Format(Now, "dd/mm/yyyy")
                '              ktant.Update()
                UpdateKontant_Record()
            Else
                'opdateer k_gegenereer
                '              k_gegenereer.Index = "PT_INDEX"
                '              k_gegenereer.Seek("=", Polisno, Grid1.Text)
                If k_gegenereer.nomatch Then
                    MsgBox("No transaction is generated for receipt no...", 48, "Kritiese Fout!")
                    Exit Sub
                End If

                '              k_gegenereer.Edit()
                '              k_gegenereer.Fields("trans_dat").Value = VB6.Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")
                '              k_gegenereer.Fields("gekans").Value = True
                '              k_gegenereer.Fields("kans_dat").Value = VB6.Format(Now, "dd/mm/yyyy")
                '              k_gegenereer.Update()


                UpdateK_Gegeneerer()

            End If

        End If

        '      'gegenereerde transaksies se kontant ontvangstes
        If eerstebetaling.Checked = True Or Vooruitbetaling.Checked = True Then
            '          'opdateer recordset kontant
            '          ktant.Index = "PT_INDEX"
            '          ktant.Seek("=", Polisno, Grid1.Text)
            If ktant.Item(i).Nomatch Then
                MsgBox("There is no cash receipts for the detail line selected.")
                Exit Sub
            End If

            'rond ktant("vord_premie") af tot 2 desimale
            ing = CDbl(ktant.Item(i).vord_premie) + 0.005
            ing = ing * 100
            ing = Int(CDbl(ing))
            ing = ing / 100

            'ktant.Edit()
            'ktant.Fields("polisno").Value = Me.Polisno.Text
            'ktant.Fields("trans_dat").Value = VB6.Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")
            'ktant.Fields("gekans").Value = True
            'ktant.Fields("kans_dat").Value = VB6.Format(Now, "dd/mm/yyyy")
            'ktant.Update()

            UpdateKontant_Record()

            'opdateer k_gegenereer+
            'k_gegenereer.Index = "PT_INDEX"
            'k_gegenereer.Seek("=", Polisno, ktant.Fields("gg_trans_dat"))
            If k_gegenereer.nomatch Then
                MsgBox("No transaction is generated for receipt no ...", 48, "Critical Error!")
                Exit Sub
            End If

            'k_gegenereer.Delete()

            DeleteK_GegenereerRecord()

            uitstaande.Text = uitstaande.Text + ing

        End If

        'Maak kansellasie button invisible
        Command3.Visible = False
        'soek transaksies
        command4_Click(Command4, New System.EventArgs())

einde_kans:

    End Sub
    Sub UpdateK_Gegeneerer()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                               New SqlParameter("@Trans_dat", SqlDbType.DateTime)}


                param(0).Value = Polisno.Text
                param(1).Value = DataGridView1.SelectedRows(0).Cells(5).Value

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[stats5].[UpdateK_Gegeneerer]", param)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Sub UpdateEise_Kontant()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                               New SqlParameter("@INGEVORDER", SqlDbType.Float), _
                                               New SqlParameter("@Trans_dat", SqlDbType.DateTime)}


                param(0).Value = Polisno.Text
                param(1).Value = e_Kontant_Ingevorde
                param(3).Value = DataGridView1.SelectedRows(0).Cells(5).Value


                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[stats5].[UpdateEise_Kontant]", param)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Sub UpdateK_GegenereerForCancel()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                               New SqlParameter("@INGEVORDER", SqlDbType.Money), _
                                               New SqlParameter("@Vord_premie", SqlDbType.Money), _
                                               New SqlParameter("@Trans_dat", SqlDbType.DateTime)}

                param(0).Value = Polisno.Text
                param(1).Value = k_geneer_Ingevorde
                param(2).Value = k_geneer_Vord_Premie
                param(3).Value = DataGridView1.SelectedRows(0).Cells(5).Value


                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[stats5].[UpdateK_GegenereerForCancel]", param)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Sub UpdateKontant_Record()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                               New SqlParameter("@Trans_dat", SqlDbType.DateTime)}


                param(0).Value = Polisno.Text
                param(1).Value = DataGridView1.SelectedRows(0).Cells(5).Value


                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[stats5].[UpdateKontantAndRecord]", param)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Sub DeleteK_GegenereerRecord()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                               New SqlParameter("@Trans_dat", SqlDbType.DateTime)}


                param(0).Value = Polisno.Text
                param(1).Value = DataGridView1.SelectedRows(0).Cells(5).Value


                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[stats5].[DeleteK_GegenereerRecord]", param)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Sub UpdateMAAND_Debiet()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                               New SqlParameter("@Match", SqlDbType.Bit), _
                                               New SqlParameter("@Trans_dat", SqlDbType.DateTime)}


                param(0).Value = Polisno.Text
                If M_Debiet.PREMIE = M_Debiet.VORD_PREMIE Then
                    param(1).Value = 1
                Else
                    param(1).Value = DBNull.Value
                End If
                param(2).Value = DataGridView1.SelectedRows(0).Cells(5).Value


                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[stats5].[UpdateMaand_Debiet]", param)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Sub UpdateMaand_Puk_For_Cancel()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                               New SqlParameter("@Match", SqlDbType.Bit), _
                                               New SqlParameter("@Trans_dat", SqlDbType.DateTime)}


                param(0).Value = Polisno.Text
                If UCase(Form1.AREA.Text) = "PUK" Then

                    If m_salarie.PREMIE = m_salarie.VORD_PREMIE Then
                        param(1).Value = 1
                    Else
                        param(1).Value = DBNull.Value
                    End If
                Else
                    param(1).Value = DBNull.Value
                End If
                param(2).Value = DataGridView1.SelectedRows(0).Cells(5).Value


                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[stats5].[UpdateMaand_Puk]", param)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Sub UpdateK_Genereer_For_Cancel()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                               New SqlParameter("@INGEVORDER", SqlDbType.Money), _
                                               New SqlParameter("@Vord_premie", SqlDbType.Money), _
                                               New SqlParameter("@Trans_dat", SqlDbType.DateTime)}


                param(0).Value = Polisno.Text
                param(1).Value = k_geneer_Ingevorde
                param(2).Value = k_geneer_Vord_Premie
                param(3).Value = DataGridView1.SelectedRows(0).Cells(5).Value


                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[stats5].[UpdateK_GegenereerForCancel]", param)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Sub UpdateM_Electronies_For_Cancel()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                               New SqlParameter("@Trans_dat", SqlDbType.DateTime)}


                param(0).Value = Polisno.Text
                param(1).Value = DataGridView1.SelectedRows(0).Cells(5).Value


                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[stats5].[UpdateM_ElektroniesForCancel]", param)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Sub UpdateM_Kontant_For_Cancel()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                               New SqlParameter("@Trans_dat", SqlDbType.DateTime)}


                param(0).Value = Polisno.Text
                param(1).Value = DataGridView1.SelectedRows(0).Cells(5).Value


                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[stats5].[UpdateM_KontantForCancel]", param)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Sub UpdateVt_DetailsAndVt_BalansFor_Cancel()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                               New SqlParameter("@vt_Balans", SqlDbType.Money), _
                                               New SqlParameter("@DatumAangevra", SqlDbType.DateTime), _
                                               New SqlParameter("@TransaksieDatum", SqlDbType.DateTime)}


                param(0).Value = Polisno.Text
                param(1).Value = vtBalans
                param(2).Value = CDate(DataGridView1.SelectedCells.Item(1).Value)
                param(3).Value = CDate(dteTransaksieDatum)


                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[stats5].[UpdateVT_Details_VT_Balans]", param)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Sub UpdateKontantGenereer_For_Cancel()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                               New SqlParameter("@Trans_dat", SqlDbType.DateTime)}


                param(0).Value = Polisno.Text
                param(1).Value = DataGridView1.SelectedRows(0).Cells(0).Value


                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[stats5].[UpdateKontantGenereer_For_Cancel]", param)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Sub UpdateKontant_For_Cancel()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                               New SqlParameter("@Trans_dat", SqlDbType.DateTime)}


                param(0).Value = Polisno.Text
                param(1).Value = DataGridView1.SelectedRows(0).Cells(0).Value

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[stats5].[UpdateKontant_For_Cancel]", param)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command4.Click
        Dim check_alle_bw As Object
        Dim Check_bb As Object
        Dim Check_wr As Object
        Dim check_tj As Object
        'kry transaksies

        If Len(Me.Polisno.Text) <> 0 Then
            Persoonl.Index = "pn_index"
            ' Persoonl.Seek("=", Me.Polisno)
            If Persoonl.NoMatch Then
                MsgBox("This policy does not exist on the database...")
                Exit Sub
            Else

                'As enige seleksie alreeds gedoen is, gebruik daardie seleksie

                If (Check_mk.CheckState = 0) And (Check_ms.CheckState = 0) And (check_md.CheckState = 0) And (check_tj = 0) And (Check_wr = 0) And (Check_bb = 0) And (eerstebetaling.CheckState = 0) And (Vooruitbetaling.CheckState = 0) And (terugbetaling.CheckState = 0) And (Check_jk.CheckState = 0) And (Langtermynpolis.CheckState = 0) And (Check_me.CheckState = 0) And (Check_VT.CheckState = 0) Then

                    Check_mk.CheckState = System.Windows.Forms.CheckState.Unchecked
                    Check_ms.CheckState = System.Windows.Forms.CheckState.Unchecked
                    check_md.CheckState = System.Windows.Forms.CheckState.Unchecked
                    Select Case Persoonl.BET_WYSE
                        Case "1"
                            Check_mk.CheckState = System.Windows.Forms.CheckState.Checked
                        Case "3"
                            Check_ms.CheckState = System.Windows.Forms.CheckState.Checked
                        Case "4"
                        Case "5"
                            Check_me.CheckState = System.Windows.Forms.CheckState.Checked
                        Case "6"
                            Langtermynpolis.CheckState = System.Windows.Forms.CheckState.Checked
                    End Select
                End If
            End If
        End If

        'inisialiseer invoer velde
        nou_ingevorder.Text = ""
        Tjekno.Text = ""
        nuwe_tjekno.Text = ""

        Tjekdatum.Text = " "
        Tjekbesonderhede.Text = " "

        'check_teveel = 0
        verw1.Text = " "
        verw2.Text = " "
        verw3.Text = " "
        verw4.Text = " "

        'kry die geselekteerde transaksies

        If check_alle_bw Then
            'kry alle transaksies...
        Else
            'vt
            If Check_VT.CheckState Then

                kry_vt_transaksies()

                GoTo ekrytrans
            End If

            'mk
            If Check_mk.CheckState Then

                kry_mk_transaksies()

                GoTo ekrytrans

            End If

            'Maandeliks elektronies
            If Check_me.CheckState Then

                kry_me_transaksies()

                GoTo ekrytrans

            End If

            'gegenereerde transaksies
            If eerstebetaling.Checked = True Or Vooruitbetaling.Checked = True Or terugbetaling.Checked = True Or Langtermynpolis.Checked = True Or Check_jk.Checked = True Then

                kry_gen_transaksies()

                GoTo ekrytrans
            End If

            'ms
            If Check_ms.CheckState Then

                kry_ms_transaksies()

                GoTo ekrytrans

            End If

            'md
            If check_md.CheckState Then

                kry_md_transaksies()

                GoTo ekrytrans

            End If

        End If

ekrytrans:

        kwit_boek.Text = ""

    End Sub

    Private Sub Command5_Click()

        'registreer n kontant betaling

    End Sub

    Private Sub Command6_Click()

        'kanselleer n kontant betaling

    End Sub

    Private Sub deselekteer()
        Dim gen_trans As Object
        Dim Check_bb As Object
        Dim Check_wr As Object
        Dim check_tj As Object

        'deselekteer al die ander opsies
        Check_mk.CheckState = System.Windows.Forms.CheckState.Unchecked
        check_md.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_ms.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_VT.CheckState = System.Windows.Forms.CheckState.Unchecked

        check_tj.value = 0

        Check_wr.value = 0

        Check_bb.value = 0

        gen_trans.value = 0
        eerstebetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        Vooruitbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        terugbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked

    End Sub


    Private Sub eerstebetaling_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles eerstebetaling.CheckStateChanged

        'If eerstebetaling.CheckState = 1 Then
        '    command4_Click(Command4, New System.EventArgs())
        'End If
        If eerstebetaling.Checked = True Then
            command4_Click(Command4, New System.EventArgs())
        End If

    End Sub

    Private Sub eerstebetaling_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles eerstebetaling.Enter

        'deselekteer al die ander opsies
        Langtermynpolis.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_mk.CheckState = System.Windows.Forms.CheckState.Unchecked
        check_md.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_ms.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_VT.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_me.CheckState = System.Windows.Forms.CheckState.Unchecked
        Vooruitbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        terugbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        genereer_trans.PerformClick()

        Command3.Visible = False
        Label14.Visible = True
        kwit_boek.Visible = True

    End Sub


    Private Sub Kontant_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        'Vertoon 'Kry transaksies' en 'Registreer kontant onvangstes/betalings'
        Command4.Visible = True
        Command1.Visible = True

        Me.Status.Text = strTermStatusDesc
        Me.Label20.Text = strTermDesc


        Check_jk.Enabled = False


        If Gebruiker.titel = "Besigtig" Then
            Me.Command1.Enabled = False
            Me.Opdateertjek.Enabled = False
            Me.Command3.Enabled = False
        End If
    End Sub


    Private Sub GetDateNow()
        Try


            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar)}

                params(0).Value = Persoonl.POLISNO

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.GetLangtermynpolisDate", params)
                Do While reader.Read



                Loop
            End Using
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Information)
        End Try


    End Sub

    Private Sub Kontant_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing


    End Sub

    Private Sub Kontant_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.Title & " - Cash Receipts / Payments / Inquiries - "


        Dim sSql As Object
        'Check_me.Checked=True
        Try


            ktant = FetchKontantDetails(Persoonl.POLISNO)
            Me.Status.Visible = True
            Me.Label20.Visible = True
            Me.Status.Text = strTermStatusDesc
            Me.Label20.Text = strTermDesc

            DataGridView1.AutoGenerateColumns = False

            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.Refresh()

            Versekerde.Text = Persoonl.VERSEKERDE
            Voorl.Text = Persoonl.VOORL
            Polisno.Text = Persoonl.POLISNO

            'Jaar 2000 veranderings:
            'Selfde as vir poldata, plus:
            'Program veranderings:
            '1. Type mismatch foute het n format gekry
            '2. Rangskik kontant.frm se objects sodat almal sigbaar is
            '3. Common dialog box is vervang met nuwe
            '4. Grids: Datum kolomme is groter gemaak

            'Dim stats5 As DAO.Database
            ''UPGRADE_WARNING: Arrays in structure rsReport may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
            'Dim rsReport As DAO.Recordset
            'stats5 = DAODBEngine_definst.OpenDatabase(pol_path & "\Stats5.mdb")
            ''open databasis en tabelle
            ' Init_Pol()

            ''kry huidige polis: nommer en versekerde
            ''en stel betaalwyse checkbox asook alle transaksies radio button op
            'Persoonl.Seek("=", Form1.POLISNO)

            If Persoonl.NoMatch Then
                MsgBox("There are no cash transactions for this policy ...")
                Exit Sub
            End If

            If Persoonl.BET_WYSE = "6" Then
                Label7.Visible = True

                rsreport = FetchLangtermnDate(Persoonl.POLISNO)
                'sSql = "SELECT * from Langtermynpolis where polisno = '" & Form1.POLISNO.Text & "'"
                'sSql = sSql & " AND format(now,'dd/mm/yyyy') between datumBegin and datumEindig"
                'sSql = sSql & " ORDER BY pkLangtermynpolis"
                'rsreport = stats5.OpenRecordset(sSql)

                'Is 'n langtermynpolis
                'If Not rsreport.BOF And Not rsreport.EOF Then
                Me.Maandeoorlbl.Visible = True
                Label6.Visible = True

                Label11.Visible = True
                Status.Visible = True
                Label13.Visible = True
                Label20.Visible = True

                'Lê vandag in die skedule?
                If (DateDiff(Microsoft.VisualBasic.DateInterval.Month, (Now), rsreport.DatumBegin) <= 0) And (DateDiff(Microsoft.VisualBasic.DateInterval.Month, (Now), rsreport.DatumEindig) >= 0) Then
                    Me.Maandeoorlbl.Text = CStr(DateDiff(Microsoft.VisualBasic.DateInterval.Month, (Now), rsreport.DatumEindig))
                End If

                Langtermynpolis.CheckState = System.Windows.Forms.CheckState.Checked
                LTPJN = "J"
                'Vandag se datum lê nie in die skedule
            Else
                If Form1.lblTermynStatus.Text = "Term not in force" Then

                    ' Me.Maandeoorlbl.Text = Form1.txtAantalMaande.Text
                    Me.Maandeoorlbl.Text = Form1.lbltermynmaande.Text
                ElseIf Form1.lblTermynStatus.Text = "Term's up" Then
                    Me.Maandeoorlbl.Text = Form1.lblTermynStatus.Text
                End If

                Label7.Visible = False
            End If
            'Tot datum wys een jaar en een maand vorentoe
            If jaar_tot_n = 0 Then
                jaar_tot_n = Year(Now) + 1
                maand_tot_n = Month(Now) + 1
                jaar_tot.Text = Str(jaar_tot_n)
                maand_tot.Text = Str(maand_tot_n)
                jaar_tot.Text = jaar_tot_n

                maand_tots = maand_tot.Text

                maand_tot.Text = maand_tot_n
                Select Case maand_tot.Text
                    Case " 1"
                        maand_tot.Text = 0 & Trim(maand_tot.Text)
                    Case " 2"
                        maand_tot.Text = 0 & Trim(maand_tot.Text)
                    Case " 3"
                        maand_tot.Text = 0 & Trim(maand_tot.Text)
                    Case " 4"
                        maand_tot.Text = 0 & Trim(maand_tot.Text)
                    Case " 5"
                        maand_tot.Text = 0 & Trim(maand_tot.Text)
                    Case " 6"
                        maand_tot.Text = 0 & Trim(maand_tot.Text)
                    Case " 7"
                        maand_tot.Text = 0 & Trim(maand_tot.Text)
                    Case " 8"
                        maand_tot.Text = 0 & Trim(maand_tot.Text)
                    Case " 9"
                        maand_tot.Text = 0 & Trim(maand_tot.Text)
                    Case Else
                        maand_tot.Text = Trim(maand_tot.Text)
                End Select
            Else
                jaar_tot.Text = CStr(jaar_tot_n)
                maand_tot.Text = CStr(maand_tot_n)

                Select Case maand_tot.Text
                    Case " 1"
                        maand_tot.Text = 0 & Trim(maand_tot.Text)
                    Case " 2"
                        maand_tot.Text = 0 & Trim(maand_tot.Text)
                    Case " 3"
                        maand_tot.Text = 0 & Trim(maand_tot.Text)
                    Case " 4"
                        maand_tot.Text = 0 & Trim(maand_tot.Text)
                    Case " 5"
                        maand_tot.Text = 0 & Trim(maand_tot.Text)
                    Case " 6"
                        maand_tot.Text = 0 & Trim(maand_tot.Text)
                    Case " 7"
                        maand_tot.Text = 0 & Trim(maand_tot.Text)
                    Case " 8"
                        maand_tot.Text = 0 & Trim(maand_tot.Text)
                    Case " 9"
                        maand_tot.Text = 0 & Trim(maand_tot.Text)
                    Case Else
                        maand_tot.Text = Trim(maand_tot.Text)
                End Select
            End If
            'van datum wys een jaar plus een maand terug se data
            If jaar_van_n = 0 Then
                jaar_van_n = jaar_tot_n - 2
                jaar_van.Text = Str(jaar_van_n)
                maand_van.Text = maand_tots
                If CDbl(maand_van.Text) = 0 Then
                    maand_van.Text = CStr(12)
                End If

                jaar_van.Text = jaar_van_n

                maand_van_n = maand_van.Text
                Select Case maand_van.Text
                    Case " 1"
                        maand_van.Text = 0 & Trim(maand_van.Text)
                    Case " 2"
                        maand_van.Text = 0 & Trim(maand_van.Text)
                    Case " 3"
                        maand_van.Text = 0 & Trim(maand_van.Text)
                    Case " 4"
                        maand_van.Text = 0 & Trim(maand_van.Text)
                    Case " 5"
                        maand_van.Text = 0 & Trim(maand_van.Text)
                    Case " 6"
                        maand_van.Text = 0 & Trim(maand_van.Text)
                    Case " 7"
                        maand_van.Text = 0 & Trim(maand_van.Text)
                    Case " 8"
                        maand_van.Text = 0 & Trim(maand_van.Text)
                    Case " 9"
                        maand_van.Text = 0 & Trim(maand_van.Text)
                    Case Else
                        maand_van.Text = maand_van.Text
                End Select
            Else

                jaar_van.Text = CStr(jaar_van_n)
                maand_van.Text = CStr(maand_van_n)
                Select Case maand_van.Text
                    Case " 1"
                        maand_van.Text = 0 & Trim(maand_van.Text)
                    Case " 2"
                        maand_van.Text = 0 & Trim(maand_van.Text)
                    Case " 3"
                        maand_van.Text = 0 & Trim(maand_van.Text)
                    Case " 4"
                        maand_van.Text = 0 & Trim(maand_van.Text)
                    Case " 5"
                        maand_van.Text = 0 & Trim(maand_van.Text)
                    Case " 6"
                        maand_van.Text = 0 & Trim(maand_van.Text)
                    Case " 7"
                        maand_van.Text = 0 & Trim(maand_van.Text)
                    Case " 8"
                        maand_van.Text = 0 & Trim(maand_van.Text)
                    Case " 9"
                        maand_van.Text = 0 & Trim(maand_van.Text)
                    Case Else
                        maand_van.Text = maand_van.Text
                End Select
            End If


            Check_mk.CheckState = System.Windows.Forms.CheckState.Unchecked
            Check_ms.CheckState = System.Windows.Forms.CheckState.Unchecked
            check_md.CheckState = System.Windows.Forms.CheckState.Unchecked
            Check_me.CheckState = System.Windows.Forms.CheckState.Unchecked

            Select Case Persoonl.BET_WYSE
                Case "1"
                    Check_mk.CheckState = System.Windows.Forms.CheckState.Checked
                Case "2"
                Case "3"
                    Check_ms.CheckState = System.Windows.Forms.CheckState.Checked
                Case "4"
                    check_md.CheckState = System.Windows.Forms.CheckState.Checked
                Case "5"
                    Check_me.CheckState = System.Windows.Forms.CheckState.Checked
                Case "6"
                    If LTPJN = "J" Then
                        Label18.Enabled = False
                        eerstebetaling.Enabled = True
                        Vooruitbetaling.Enabled = True
                        jkearnedcmd.Enabled = True
                        Label6.Enabled = True
                        Maandeoorlbl.Enabled = True
                        Label11.Visible = True
                        Status.Visible = True
                        Label13.Visible = True
                        Label20.Visible = True
                        Label7.Visible = True
                    Else
                        Label18.Enabled = True
                        eerstebetaling.Enabled = False
                        Vooruitbetaling.Enabled = False
                        jkearnedcmd.Enabled = False
                        Label6.Enabled = False
                        Maandeoorlbl.Enabled = False
                        Label13.Visible = False
                        Label20.Visible = False
                        Label11.Visible = False
                        Status.Visible = False
                        Label7.Visible = False
                    End If

            End Select
            'alle_transaksies.Checked = True

            Me.Polisno.Text = Persoonl.POLISNO
            Me.Versekerde.Text = Persoonl.VERSEKERDE
            Me.Voorl.Text = Persoonl.VOORL

            'vul datum vanaf en datum tot in
            command4_Click(Command4, New System.EventArgs())

            If Gebruiker.titel = "Besigtig" Then
                Me.Command1.Enabled = False
                Me.Opdateertjek.Enabled = False
                Me.Command3.Enabled = False
            End If

            DataGridView1.ReadOnly = True
            DataGridView1.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message, "There has been a problem when loading the payment screen", "Loading Payment")
            Exit Sub
        End Try
    End Sub

    Private Sub gen_trans_Click()
        Dim gen_trans As Object

        If gen_trans.value = 1 Then
            'Selekteer genereer button
            genereer_trans.Visible = True

            'deselekteer al die ander opsies
            Check_mk.CheckState = System.Windows.Forms.CheckState.Unchecked
            check_md.CheckState = System.Windows.Forms.CheckState.Unchecked
            Check_ms.CheckState = System.Windows.Forms.CheckState.Unchecked
            Check_VT.CheckState = System.Windows.Forms.CheckState.Unchecked
            Check_me.CheckState = System.Windows.Forms.CheckState.Unchecked
            If eerstebetaling.CheckState = 1 Then
                Vooruitbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
                terugbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
            Else
                If Vooruitbetaling.CheckState = 1 Then
                    eerstebetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
                    terugbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
                Else
                    If terugbetaling.CheckState = 1 Then
                        eerstebetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
                        Vooruitbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
                    Else
                    End If
                End If
            End If
        Else
            genereer_trans.Visible = False
        End If
        gen_trans.value = 1

        Command3.Visible = False
    End Sub

    Private Sub gen_trans_GotFocus()

        'deselekteer al die ander opsies
        Check_mk.CheckState = System.Windows.Forms.CheckState.Unchecked
        check_md.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_ms.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_VT.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_me.CheckState = System.Windows.Forms.CheckState.Unchecked
        gen_trans.Value = 0
        If eerstebetaling.CheckState = 1 Then
            Vooruitbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
            terugbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        Else
            If Vooruitbetaling.CheckState = 1 Then
                eerstebetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
                terugbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
            Else
                If terugbetaling.CheckState = 1 Then
                    eerstebetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
                    Vooruitbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
                Else
                End If
            End If
        End If

    End Sub

    Private Sub genereer_trans_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles genereer_trans.Click

        'gegenereerde transaksies
        '------------------------
        'genereer die transaksie waarteen n ontvangste/betaling gedoen wil word

        'daar mag geen transaksies vir n gekanselleerde persoon gedoen word nie
        Persoonl.Index = "pn_index"
        'Persoonl.Seek("=", Me.Polisno)
        If Not (Persoonl.NoMatch) Then
            If Persoonl.GEKANS Then
                'Geen transaksies word toegelaat vir 'n gekanselleerde behalwe terugbetalings
                If terugbetaling.CheckState = 0 Then
                    MsgBox("The person has been canceled. Net repayments of transactions allowed.")
                    Exit Sub
                End If
            End If
        End If

        'As gegenereer gekies is dan moet eb, vb, tb of jk gekies wees
        If gen_trans Then
            Check_mk.CheckState = System.Windows.Forms.CheckState.Unchecked
            check_md.CheckState = System.Windows.Forms.CheckState.Unchecked
            Check_ms.CheckState = System.Windows.Forms.CheckState.Unchecked
            Check_me.CheckState = System.Windows.Forms.CheckState.Unchecked
            Check_VT.CheckState = System.Windows.Forms.CheckState.Unchecked

            If eerstebetaling.CheckState = 0 And Vooruitbetaling.CheckState = 0 And terugbetaling.CheckState = 0 Then
                MsgBox("You have indicated a transaction to generate. Choose what type of transaction it should be, namely 'First Payment' or 'Prepaid' or 'Refund' or 'Annually cash '. 'Transaction is a gegnereer run if no transactions were generated, and you need a receipt / payment have to make ...")
                Exit Sub
            End If

        Else
            MsgBox("You have clicked the generate button. Please choose. plus the option to generate the type receipts / payments you want to generate")
            Exit Sub
        End If

        If (gen_trans) And (eerstebetaling.CheckState Or Vooruitbetaling.CheckState Or terugbetaling.CheckState) Then

        End If
        'toets of transaksie bedrag n waarde in het
        If Val(nou_ingevorder.Text) = 0 Then
            nou_ingevorder.Text = InputBox("What is the transaction amount?")
        End If

kry2_gt_jaar:
        If Month(Now) = 12 Then
            volg_jaar = Year(Now) + 1
            volg_maand = 1
        Else
            volg_jaar = Year(Now)
            volg_maand = Month(Now) + 1
        End If

kry2_gt_dag:

        vb_dag = InputBox("What day is the transaction(dd)?", , Format("01", "00"))
        If vb_dag = "" Then
            MsgBox("You have canceled generated transactions...")
            gen_trans = False
            eerstebetaling.CheckState = False
            Vooruitbetaling.CheckState = False
            terugbetaling.CheckState = False
            GoTo einde_gt_tr
        End If
        vb_maand = InputBox("For which month the transaction (mm)?", , Format(volg_maand, "00"))
        If vb_maand = "" Then
            MsgBox("You have canceled generated transactions...")
            gen_trans = False
            eerstebetaling.CheckState = False
            Vooruitbetaling.CheckState = False
            terugbetaling.CheckState = False
            GoTo einde_gt_tr
        End If

        'kry jaar ook
kry2_gt_jaar3:
        vb_jaar = InputBox("What year was the deal yyyy)?", , volg_jaar)

        If vb_jaar = "" Then
            MsgBox("You have canceled generated transactions...")
            gen_trans = False
            eerstebetaling.CheckState = False
            Vooruitbetaling.CheckState = False
            terugbetaling.CheckState = False
            GoTo einde_gt_tr
        End If

        'genereer vooruitbetalings transaksie

        vb_afdat = (vb_dag) & "/" & Format(vb_maand) & "/" & Format(vb_jaar)

        If Not (IsDate(vb_afdat)) Then
            MsgBox("The date is incorrect. Please correct")
            GoTo kry2_gt_dag
        End If

        'skryf jaar as ccjj

        jaar4 = vb_jaar


        grid_nou_ingevorder = " "

        grid_kwitansie = " "

        grid_vord_dat = " "

        grid_trans_dat = Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")

        UpdateGenereerde()

        row_tel = row_tel + 1


        'zeroise ingevorder
        nou_ingevorder.Enabled = True
        nou_ingevorder.Text = ""

        'zeroise memo
        Me.verw1.Text = " "
        Me.verw2.Text = " "
        Me.verw3.Text = " "
        Me.verw4.Text = " "
        Me.verw5.Text = " "

        'deselekteer genereerde transaksies
        gen_trans.value = 0

        'Maak genereer button invisible
        genereer_trans.Visible = False

        command4_Click(Command4, New System.EventArgs())

einde_gt_tr:

    End Sub

    Sub UpdateGenereerde()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                 New SqlParameter("@Premie", SqlDbType.Float), _
                                                 New SqlParameter("@Vord_Premie", SqlDbType.Float), _
                                                 New SqlParameter("@Afsluit_dat", SqlDbType.DateTime), _
                                                 New SqlParameter("@Jaar", SqlDbType.SmallInt), _
                                                 New SqlParameter("@Maad", SqlDbType.SmallInt), _
                                                 New SqlParameter("@Trans_dat", SqlDbType.DateTime), _
                                                 New SqlParameter("@Betaalwyse", SqlDbType.NVarChar), _
                                                 New SqlParameter("@gg_trans_dat", SqlDbType.DateTime), _
                                                 New SqlParameter("@tipe_trans", SqlDbType.NVarChar), _
                                                 New SqlParameter("@gekans", SqlDbType.Bit), _
                                                 New SqlParameter("@eb_vb_tb", SqlDbType.NVarChar), _
                                                 New SqlParameter("@Area", SqlDbType.NVarChar)}



                params(0).Value = Persoonl.POLISNO
                params(1).Value = Format(Val(nou_ingevorder.Text), "#####.00")
                params(2).Value = 0
                params(3).Value = vb_afdat
                params(4).Value = jaar4
                params(5).Value = vb_maand
                params(6).Value = Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")
                params(7).Value = Persoonl.BET_WYSE
                params(8).Value = Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")

                If Me.Tjek.Checked = True Then
                    params(9).Value = "T"
                Else
                    If Me.Kont.Checked = True Then
                        params(9).Value = "K"
                    Else
                        If Me.Elektronies.Checked = True Then
                            params(9).Value = "E"
                        End If
                    End If

                End If
                params(10).Value = False

                'identifiseer watter tipe betaling
                tipe_bet = " "
                If Me.eerstebetaling.CheckState = 1 Then
                    params(11).Value = "EB"
                    tipe_bet = "EB"
                Else
                    If Me.Vooruitbetaling.CheckState = 1 Then
                        params(11).Value = "VB"
                        tipe_bet = "VB"
                    Else
                        If Me.terugbetaling.CheckState = 1 Then
                            params(11).Value = "TB"
                            tipe_bet = "TB"
                        Else
                            If Me.Langtermynpolis.CheckState = 1 Then
                                params(11).Value = "JK"
                                tipe_bet = "JK"
                            End If
                        End If
                    End If
                End If
                params(12).Value = Persoonl.Area


                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[stats5].[UpdateKontantGegenereer]", params)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

    End Sub

    Private Sub Init_Pol()
        Dim Prev_Motors As Object
        Dim pcs_pol_path As Object
        Dim wat As Object
        Dim leer As Object


        'Dim rep_taknaam As DAO.Recordset

        'Dim rsPersoonl As DAO.Recordset
        'rep = DAODBEngine_definst.OpenDatabase("c:\polis5\reports5.mdb")
        'rep_taknaam = rep.OpenRecordset("taknaam")
        rep_taknaam = FetchTakNaam()
        'rep = DAODBEngine_definst.OpenDatabase("c:\polis5\reports5.mdb")

        'Kry poldata.ini se waardes

        leer = "c:\windows\poldata.ini"


        wat = "path"
        Call kry_path_en_ander(leer, wat)
        If Len(pol_path) = 0 Then
            MsgBox("The path in poldata.ini is not found. program stops")
            End
        End If

        pcs_pol_path = pol_path


        pcs_pol_path_kont = pol_path


        wat = "tv_premie"
        Call kry_path_en_ander(leer, wat)
        If Len(tv_koste) = 0 Then
            MsgBox("The TV poldata.ini premium is not found. program stop ")
            End
        End If


        wat = "password"
        Call kry_path_en_ander(leer, wat)
        If Len(Password) = 0 Then
            MsgBox("The vehicles poldata.ini password is not found. program stop")
            End
        End If


        wat = "polisfooi"
        Call kry_path_en_ander(leer, wat)
        If Len(polisfooi_ini) = 0 Then
            MsgBox("The policy fee poldata.ini is not found. program stops")
            End
        End If


        wat = "sasria"
        Call kry_path_en_ander(leer, wat)

        If Len(sasria_ini) = 0 Then
            MsgBox("SASRIA (houses) in poldata.ini is not found. program stops")
            End
        End If


        wat = "sasria_h"
        Call kry_path_en_ander(leer, wat)

        If Len(h_sasria_ini) = 0 Then
            MsgBox("SASRIA (houses) in poldata.ini is not found. program stops")
            End
        End If


        wat = "earlybird"
        Call kry_path_en_ander(leer, wat)
        If Len(earlybird) = 0 Then
            MsgBox("Earlybird rate poldata.ini is not found. program stops")
            End
        End If

        'Tv diens premie moet numeries wees vanaf c:\windows\poldata.ini
        If Len(tv_koste) > 0 Then
            If (Not (IsNumeric(tv_koste))) Then
                MsgBox("The TV service premium numerically be in c: \ windows \ poldata.ini!", 48, "Fout!")
                End
            End If
        End If


        wat = "epospath"
        Call kry_path_en_ander(leer, wat)
        If Len(epospath) = 0 Then
            MsgBox("The e-mail in poldata.ini path was not found. program stops")
            End
        End If

        'pol = DAODBEngine_definst.OpenDatabase(pol_path & "\poldata5.mdb")
        'stats = DAODBEngine_definst.OpenDatabase(pol_path & "\stats5.mdb")

        'rsPersoonl = pol.OpenRecordset("SELECT * FROM Persoonl WHERE polisno = '" & Form1.POLISNO.Text & "'")
        Persoonl = FetchPersoonl()
        'tak_hoof = pol.OpenRecordset("SELECT * FROM area WHERE area_kode = '" & rsPersoonl.Fields("area").Value & "' ")
        tak_hoof = FetchAreaCodeByPersoon()
        'Tak_afk = tak_hoof.Fields("tak_afkorting").Value
        Tak_afk = tak_hoof.Tak_afkorting


        tak_hoof.LockEdits = False


        Prev_Motors = False
        Byvoeg = False
        blnediting = False
        blnLoading = False
        blnNuwe = False

        ''vdh/pcs oorskakeling
        'rep = DAODBEngine_definst.OpenDatabase("c:\polis5\reports5.mdb")

        'tak_hoof.MoveFirst()
        Me.Taknaam.Text = tak_hoof.tak_naam

        'vdh/pcs oorskakeling
        'skryf die tak naam na leer
        'rep_taknaam.addNew()
        InsertIntoTak_Naam()
        'rep_taknaam.Fields("tak_naam").Value = "fop rekord"
        'rep_taknaam.Update()
        'rep_taknaam.MoveFirst()
        While rep_taknaam.tak_naam
            'rep_taknaam.Delete()
            DeleteFromTak_Naam()
            'rep_taknaam.MoveNext()
        End While
        'rep_taknaam.addNew()
        UpdateTak_Naam()
        'rep_taknaam.Fields("tak_naam").Value = tak_hoof.Fields("tak_naam").Value
        'rep_taknaam.Update()e


        If tak_hoof.tak_naam = "Potchefstroom" Or tak_hoof.tak_naam = "Vaaldriehoek" Then
        Else
            Me.PCSk.Visible = False
            Me.VDHk.Visible = False
        End If


        initpoleerste = 1

        'Persoonl = pol.OpenRecordset("PERSOONL")
        Persoonl.Index = "PN_INDEX"

        'vt_balans = stats.OpenRecordset("MAAND_VT_BALANS")
        'vt_balans.Index = "PN_INDEX"

        'maand = stats.OpenRecordset("MAAND")
        'maand.Index = "PN_INDEX"

        'recordset maand_vt_details
        'VT_Details = stats.OpenRecordset("MAAND_VT_DETAILS")
        'VT_Details.Index = "PVD_INDEX"

        'tak_hoof = pol.OpenRecordset("SELECT * FROM area WHERE area_kode in " & Gebruiker.BranchCodes  & " ")

        'tak_hoof.MoveFirst()

        'tak_polisno = pol.OpenRecordset("TAK_POLISNO")
        'col = stats.OpenRecordset("COLLECTIONS")
        'kwitansie_nr = stats.OpenRecordset("KWITANSIE_NR")
        'ktant = stats.OpenRecordset("KONTANT")
        'm_kontant = stats.OpenRecordset("MAAND_KONTANT")
        'j_kontant = stats.OpenRecordset("JAAR_KONTANT")
        'm_salaris = stats.OpenRecordset("MAAND_PUK")
        'M_Debiet = stats.OpenRecordset("MAAND")
        'e_kontant = stats.OpenRecordset("EISE_KONTANT")
        ''gegenereerde transaksies
        'k_gegenereer = stats.OpenRecordset("kontant_gegenereer")

    End Sub
    Function FetchAreaCodeByPersoon()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)

                param.Value = Persoonl.POLISNO

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchAreaByPersoonl]", param)

                Dim item As AreaByPersoonlEntity = New AreaByPersoonlEntity()

                If reader.Read() Then
                    item.Area_kode = reader("Area_kode")
                End If
                If reader.Read() Then
                    item.tak_naam = reader("tak_naam")
                End If
                Return item
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

            Exit Function
        End Try
    End Function
    Function UpdateTak_Naam()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                Dim param() As SqlParameter = {New SqlParameter("@Tak_naam", SqlDbType.NVarChar)}


                param(0).Value = tak_hoof.tak_naam

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, " [Reports5].[InsertTaak_Naam]", param)

                Return True

            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing

        End Try
    End Function
    Function InsertIntoTak_Naam()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim param() As SqlParameter = {New SqlParameter("@Tak_naam", SqlDbType.NVarChar)}


                param(0).Value = "fop rekord"

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[reports5].[UpdateTaak_Naam]", param)

                Return True

            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing

        End Try
    End Function
    Function DeleteFromTak_Naam()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim param() As SqlParameter = {New SqlParameter("@Tak_naam", SqlDbType.NVarChar)}


                param(0).Value = tak_hoof.tak_naam

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[Reports5].[DeleteTaak_Naam]", param)

                Return True

            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing

        End Try
    End Function
    Function FetchTakNaam()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[reports5].[FecthTaak_Naam]")

                Dim item As Tak_NaamEntity = New Tak_NaamEntity()

                If reader.Read() Then
                    item.tak_naam = reader("tak_naam")
                End If
                Return item.tak_naam
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

            Exit Function
        End Try
    End Function

    Public Sub kry_gen_transaksies()
        Dim sSql As Object
        Dim ggtransdat19 As Object
        Dim grid_tipe_betaling As Object
        Dim grid_trans_dat As Object
        Dim grid_vord_dat As Object
        Dim grid_kwitansie As Object
        Dim grid_nou_ingevorder As Object
        Dim tot_jm As Object
        Dim vanaf_jm As Object
        Dim boek_jm As Object
        Dim boek_maand As Object
        Dim boek_jaar As Object
        Dim tipe_trans As Object
        Dim row_tel As Object
        Dim Ctr As Object
        Dim lus As Object
        Dim Kwintasie As Object
        Dim count_ As Object
        Dim nuwe_tjekno As Object
        Dim i As Integer

        ' Dim stats5 As DAO.Database
        'stats5 = DAODBEngine_definst.OpenDatabase(pol_path & "\Stats5.mdb")

        'kry gegenereerde transaksies en kry dan alle transaksies in recordset kontant wat ontvang is teen die polis)

        'kry persoonl rekord

        If Persoonl.NoMatch Then
            MsgBox(ktant.Item(i).polisno + " is nie gekry in PERSOONL")
            Exit Sub
        End If

        Versekerde.Text = Persoonl.VERSEKERDE
        Voorl.Text = Mid((Persoonl.VOORL), 1, 5)
        Polisno.Text = Persoonl.POLISNO


        DataGridView1.Rows.Clear()

        'het gebruiker net uitstaandes aangevra?
        If Uitst_transaksies.Checked Then
            If Val(Persoonl.PREMIE) = Persoonl.INGEVORDER Then GoTo ktant_einde_gt
        End If

        uitstaande.Text = CStr(0)

        Ctr = 0

        row_tel = 0
        'k_gegenereer.Index = "pjm_index"
        ' k_gegenereer.Seek(">=", Polisno, jaar_van, maand_van)

        k_gegenereer = FetchKontantGegenereer(Persoonl.POLISNO)

        If k_gegenereer.nomatch Then
            GoTo gt_det_uit3
        End If

        'geen transaksies?
        If k_gegenereer.polisno <> Polisno.Text Then
            If eerstebetaling.CheckState Then

                tipe_trans = " eerste betaling "
            Else
                If Vooruitbetaling.CheckState Then

                    tipe_trans = " vooruitbetaling "
                Else
                    If terugbetaling.CheckState Then

                        tipe_trans = " terugbetaling "
                    Else
                        If Check_jk.CheckState Then

                            tipe_trans = " jaarliks kontant "
                        Else
                            If Langtermynpolis.CheckState Then

                                tipe_trans = " langtermynpolis "
                            End If

                        End If

                    End If
                End If
            End If
            'Exit Sub
        End If

        'kry alle gegenereerde transaksies
        If k_gegenereer.polisno = Polisno.Text Then
            'kry net ongekanselleerde gegenereerde transaksies
            If k_gegenereer.gekans = False Then
                'Kry gebruiker aangevraagde transaksies
                If eerstebetaling.CheckState Then
                    If k_gegenereer.eb_vb_tb <> "EB" Then
                        GoTo ktant_einde_3_gt
                        ' k_gegenereer.polisno = Polisno.Text
                    End If
                End If

                If Vooruitbetaling.CheckState Then
                    'k_gegenereer.eb_vb_tb = "VB"
                    If k_gegenereer.eb_vb_tb <> "VB" Then
                        'GoTo ktant_einde_3_gt
                        k_gegenereer.polisno = Polisno.Text
                    End If
                End If

                If terugbetaling.CheckState Then
                    If k_gegenereer.eb_vb_tb <> "TB" Then
                        'GoTo ktant_einde_3_gt
                        k_gegenereer.polisno = Polisno.Text
                    End If
                End If

                If Langtermynpolis.CheckState Then
                    If k_gegenereer.eb_vb_tb <> "LT" Then
                        GoTo ktant_einde_3_gt
                    End If
                End If

                If Check_jk.CheckState Then
                    If k_gegenereer.eb_vb_tb <> "JK" Then
                        GoTo ktant_einde_3_gt
                    End If
                End If

                'het gebruiker net uitstaandes aangevra?
                If Uitst_transaksies.Checked Then
                    If k_gegenereer.premie = k_gegenereer.ingevorder Then
                        GoTo ktant_einde_3_gt
                    End If

                End If

                'val transaksie in aangevraagde vanaf en tot datum?

                boek_jaar = (k_gegenereer.jaar)

                boek_jaar = Trim(boek_jaar)

                'boek_jaar = Format(boek_jaar, "0000")
                boek_jaar = CStr(boek_jaar)

                boek_maand = k_gegenereer.maand

                If boek_maand <= 9 Then
                    boek_maand = CStr(k_gegenereer.maand)
                    boek_maand = CStr("0" + Trim(boek_maand))
                Else
                    boek_maand = CStr(k_gegenereer.maand)
                End If

                boek_maand = (boek_maand)

                'boekhou datum as jjjjmm

                boek_jm = boek_jaar + boek_maand

                'datum vanaf en datum tot as jjjjmm

                vanaf_jm = jaar_van.Text & maand_van.Text

                tot_jm = jaar_tot.Text & maand_tot.Text

                If (boek_jm >= vanaf_jm) And (boek_jm >= tot_jm) Then
                    GoTo sit_in_grid3_gt
                Else
                    GoTo ktant_einde_3_gt
                End If

sit_in_grid3_gt:

                'stel volgende ry op

                Try
                    row_tel = row_tel + 1

                    'Grid1.row = row_tel

                    'berei grid veranderlikes voor
                    DataGridView1.AutoGenerateColumns = False
                    DataGridView1.Refresh()

                    DataGridView1.ColumnCount = 8
                    DataGridView1.ColumnHeadersVisible = True
                    DataGridView1.Columns(0).Name = "ClosingDate"
                    DataGridView1.Columns(1).Name = "Premium"
                    DataGridView1.Columns(2).Name = "Now Recovered"
                    DataGridView1.Columns(3).Name = "Receipt"
                    DataGridView1.Columns(4).Name = "MandotoryDate"
                    DataGridView1.Columns(5).Name = "Transaction_Date"
                    DataGridView1.Columns(6).Name = "Payment_Type"
                    DataGridView1.Columns(7).Name = "T/K/E"
                    DataGridView1.Rows.Clear()




                    'kry kontant transaksie wat saamgaan met polis
                    'kontant indeks is polisno/ gg transaksie datum

                    ggtransdat19 = Mid(k_gegenereer.trans_dat, 1, 19)
                    Using conn As SqlConnection = SqlHelper.GetConnection

                        Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)

                        param.Value = Persoonl.POLISNO

                        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchKontantbypolisno]", param)
                        DataGridView1.Rows.Clear()
                        While reader.Read()
                            If IsDBNull(k_gegenereer.ingevorder) Then

                                grid_nou_ingevorder = " "
                            Else

                                grid_nou_ingevorder = CStr(k_gegenereer.ingevorder)
                            End If

                            grid_nou_ingevorder = (grid_nou_ingevorder)


                            grid_kwitansie = " "


                            grid_vord_dat = " "


                            If IsDBNull(k_gegenereer.trans_dat) Then

                                grid_trans_dat = " "
                            Else

                                grid_trans_dat = k_gegenereer.trans_dat
                            End If


                            If IsDBNull(k_gegenereer.eb_vb_tb) Then

                                grid_tipe_betaling = " "
                            Else

                                grid_tipe_betaling = k_gegenereer.eb_vb_tb
                            End If

                            uitstaande.Text = uitstaande.Text + k_gegenereer.premie

                            Ctr = Ctr + 1

                            Err.Clear()
                            DataGridView1.Rows.Add(0, reader("afsluit_dat"), reader("premie"), reader("ingevorder"), reader("kwitansie"), reader("vord_dat"), reader("trans_dat"), reader("tipe"), reader("kontant_tipe"), row_tel)
                            'DataGridView1.Rows.Clear()
                        End While

                    End Using

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                'row_tel = row_tel + 1

                ''Grid1.row = row_tel

                ''berei grid veranderlikes voor
                'DataGridView1.AutoGenerateColumns = False
                'DataGridView1.Refresh()

                'DataGridView1.ColumnCount = 7
                'DataGridView1.ColumnHeadersVisible = True
                'DataGridView1.Columns(0).Name = "afsluit_dat"
                'DataGridView1.Columns(1).Name = "Premie"
                'DataGridView1.Columns(2).Name = "Nou_ingevorder"
                'DataGridView1.Columns(3).Name = "Kwitansie"
                'DataGridView1.Columns(4).Name = "Vord_dat"
                'DataGridView1.Columns(5).Name = "Trans_dat"
                'DataGridView1.Columns(6).Name = "Tipe_betaling"

                '' DataGridView1.Rows.Add((Format(k_gegenereer.afsluit_dat) & Chr(9) & Str(k_gegenereer.premie) & Chr(9) + grid_nou_ingevorder + Chr(9) + grid_kwitansie + Chr(9) + grid_vord_dat + Chr(9) + grid_trans_dat + Chr(9) + Chr(9) + Chr(9) + grid_tipe_betaling), row_tel)
                ''DataGridView1.Rows.Add((k_gegenereer.afsluit_dat) & Chr(9) & k_gegenereer.premie & Chr(9) & grid_nou_ingevorder + Chr(9) + grid_kwitansie + Chr(9) + grid_vord_dat + Chr(9) + grid_trans_dat + Chr(9) + grid_tipe_betaling, row_tel)
                ''DataGridView1.Rows.Add((Format(k_gegenereer.afsluit_dat) & Chr(9) _
                ''               & CStr(k_gegenereer.premie) & Chr(9) + _
                ''               grid_nou_ingevorder + Chr(9) + grid_kwitansie + Chr(9) + _
                ''               grid_vord_dat + Chr(9) + grid_trans_dat + Chr(9) + Chr(9) + _
                ''               Chr(9) + grid_tipe_betaling), row_tel)



                'If IsDBNull(k_gegenereer.ingevorder) Then

                '    grid_nou_ingevorder = " "
                'Else

                '    grid_nou_ingevorder = CStr(k_gegenereer.ingevorder)
                'End If

                'grid_nou_ingevorder = (grid_nou_ingevorder)


                'grid_kwitansie = " "


                'grid_vord_dat = " "


                'If IsDBNull(k_gegenereer.trans_dat) Then

                '    grid_trans_dat = " "
                'Else

                '    grid_trans_dat = k_gegenereer.trans_dat
                'End If


                'If IsDBNull(k_gegenereer.eb_vb_tb) Then

                '    grid_tipe_betaling = " "
                'Else

                '    grid_tipe_betaling = k_gegenereer.eb_vb_tb
                'End If

                'uitstaande.Text = uitstaande.Text + k_gegenereer.premie

                'Ctr = Ctr + 1

                'Err.Clear()

                ''kry kontant transaksie wat saamgaan met polis
                ''kontant indeks is polisno/ gg transaksie datum

                'ggtransdat19 = Mid(k_gegenereer.trans_dat, 1, 19)


                'DataGridView1.Rows.Insert(0, k_gegenereer.afsluit_dat, k_gegenereer.premie, grid_nou_ingevorder, grid_kwitansie, grid_vord_dat, grid_trans_dat, grid_tipe_betaling, row_tel)
                For i = 0 To ktant.Count - 1


                    '"SELECT * from Kontant where polisno = '" & Polisno &
                    '"' and left(gg_trans_dat,19) = '" & ggtransdat19 &
                    ' "' And Tipe = '" & grid_tipe_betaling & "'"


                    'filter ktant with the info in where.... sSql = "SELECT * from Kontant where polisno = '" & Polisno.Text & "' and left(gg_trans_dat,19) = '" & ggtransdat19 & "' And Tipe = '" & grid_tipe_betaling & "'"
                    If Mid(ktant.Item(i).gg_trans_dat, 1, 19) = ggtransdat19 And ktant.Item(i).tipe = grid_tipe_betaling And _
                    Format((Mid(ktant.Item(i).gg_trans_dat, 1, 10)) = Format(Mid(k_gegenereer.trans_dat, 1, 10))) Then
                        If ktant.Item(i).gekans = False Then

                            row_tel = row_tel + 1

                            DataGridView1.AutoGenerateColumns = False
                            DataGridView1.Refresh()

                            DataGridView1.ColumnCount = 7
                            DataGridView1.ColumnHeadersVisible = True
                            DataGridView1.Columns(0).Name = " "
                            DataGridView1.Columns(1).Name = "MandotoryPremium"
                            DataGridView1.Columns(2).Name = "Receipt"
                            DataGridView1.Columns(3).Name = "MandotoryDate"
                            DataGridView1.Columns(4).Name = "Transaction_Date"
                            DataGridView1.Columns(5).Name = "New_Chequeno"
                            DataGridView1.Columns(6).Name = "Payment_Type"



                            If ktant.Item(i).tipe = "EB" Or ktant.Item(i).tipe = "VB" Then

                                If IsDBNull(ktant.Item(i).tjekno_in) Then
                                    Kwintasie = ktant.Item(i).kwitansie
                                Else
                                    Kwintasie = ktant.Item(i).kwitansie + "/" + ktant.Item(i).tjekno_in
                                End If
                                'terugbetaling
                            Else

                                If IsDBNull(ktant.Item(i).tjekno_uit) Then
                                    Kwintasie = ktant.Item(i).kwitansie
                                Else
                                    Kwintasie = ktant.Item(i).kwitansie + "/" + ktant.Item(i).tjekno_uit
                                End If
                            End If
                            If IsDBNull(ktant.Item(i).nuwe_tjekno) Then
                                nuwe_tjekno = " "
                            Else
                                nuwe_tjekno = ktant.Item(i).nuwe_tjekno
                            End If

                            uitstaande.Text = CStr(CDbl(uitstaande.Text) - ktant.Item(i).vord_premie)

                            DataGridView1.Rows.Add(0, (" " & Chr(9) & " "), Format(ktant.Item(i).vord_premie, "#########00.00"), _
                                                      Kwintasie, Format(ktant.Item(i).vord_dat, "dd/mm/yyyy"), ktant.Item(i).trans_dat, nuwe_tjekno, ktant.Item(i).kontant_tipe, row_tel)

                        End If
                    End If
                Next

ktant_einde_3_gt:
            End If

            'k_gegenereer.MoveNext()

            'eof?
            'If (Err.Number = 3021) Then Or (k_gegenereer.EOF) Then
            'GoTo gt_det_uit3
            'End If
        End If


ktant_einde_gt:

        'zeroise nou_ingevorder
        Me.nou_ingevorder.Enabled = True
        Me.nou_ingevorder.Text = ""

        'zeroise memo
        Me.verw1.Text = " "
        Me.verw2.Text = " "
        Me.verw3.Text = " "
        Me.verw4.Text = " "
        Me.verw5.Text = " "

gt_det_uit3:

    End Sub

    Public Sub kry_ms_transaksies()
        Dim mktransdat10 As Object
        Dim grid_trans_dat As Object
        Dim grid_vord_dat As Object
        Dim grid_kwitansie As Object
        Dim grid_nou_ingevorder As Object
        Dim tot_jm As Object
        Dim vanaf_jm As Object
        Dim boek_jm As Object
        Dim boek_maand As Object
        Dim boek_jaar As Object
        Dim row_tel As Object
        Dim Ctr As Object
        Dim lus As Object
        Dim count_ As Object
        Dim sSql As Object
        Dim Kwintasie As Object
        Dim i As Integer
        Dim it As Integer





        If Gebruiker.titel = "Programmeerder" Then
            AreaTaknaam = FetchKontantAreas()
        End If


        'Combine all MS tables in order to display MS transactions
        'This has to be done, for if an area was changed, the previous MS transactions cannot be viewed
        m_salaris1 = Fetch_Maand_Uovs_Salaries(Persoonl.POLISNO)
        m_salaris2 = Fetch_Maand_Uovs_GTBfn_Salaries2(Persoonl.POLISNO)

        If AreaTaknaam = "MM Potchefstroom" Or AreaTaknaam = "MM Puk" Then
            m_salaris = m_salaris1
        ElseIf AreaTaknaam = "MM Bloemfontein" Then
            m_salaris = m_salaris2
        End If

        Versekerde.Text = Persoonl.VERSEKERDE
        Voorl.Text = Mid(Persoonl.VOORL, 1, 5)
        Polisno.Text = Persoonl.POLISNO

        uitstaande.Text = CStr(0)
        '  DataGridView1.Rows.Clear()
        Ctr = 0

        row_tel = 0



        'kry alle mk transaksies
        'Do While Not m_salaris.BOF And Not m_salaris.EOF
        'While m_salaris.polisno = Me.Polisno.Text
        For i = 0 To m_salaris.Count - 1
            'het gebruiker net uitstaandes aangevra?
            If Uitst_transaksies.Checked Then
                If m_salaris.Item(i).PREMIE = m_salaris.Item(i).INGEVORDER Then GoTo ktant_einde_5
            End If

            'val transaksie in aangevraagde vanaf en tot datum?

            boek_jaar = CStr(m_salaris.Item(i).JAAR)

            boek_jaar = Trim(boek_jaar)

            boek_jaar = Format(boek_jaar, "0000")

            'If boek_maand <= 9 Then
            '    boek_maand = CStr(m_salaris.Item(i).MAAND)
            '    boek_maand = CStr("0" + Trim(boek_maand))
            'Else
            '    boek_maand = CStr(boek_maand)
            'End If


            boek_maand = CStr(m_salaris.Item(i).MAAND)

            boek_maand = Trim(boek_maand)

            boek_maand = boek_maand

            'boekhou datum as jjjjmm

            boek_jm = boek_jaar + boek_maand

            'datum vanaf en datum tot as jjjjmm

            vanaf_jm = jaar_van.Text & maand_van.Text

            tot_jm = jaar_tot.Text & maand_tot.Text


            If (boek_jm >= vanaf_jm) And (boek_jm <= tot_jm) Then
                GoTo sit_in_grid5

            Else
                GoTo ktant_einde_5
            End If

sit_in_grid5:

            'stel volgende ry op

            row_tel = row_tel + 1

            'vertoon vt detail

            'PopulateGridWithMaandSalaries()

            uitstaande.Text = uitstaande.Text + m_salaris.Item(i).PREMIE

            Ctr = Ctr + 1

            Err.Clear()

volg_ms:
            'kry kontant transaksie wat saamgaan met mk
            '(mk-trans_dat is korrek - dit is waar ms se trans dat gestoor is)

            mktransdat10 = Mid(m_salaris.Item(i).TRANS_DAT, 1, 10)

            'sSql = "SELECT * from Kontant where polisno = '" & Polisno.Text & "' and left(mk_trans_dat,10) = '" & mktransdat10 & "' and tipe = " & "'MS'"
            If ktant.Item(i).tipe = "MS" And ktant.Item(i).mk_trans_dat = mktransdat10 Then

                'Do While Not ktant.BOF And Not ktant.EOF
                For it = 0 To ktant.Count - 1

                    If Mid(ktant.Item(it).Me_Trans_Dat, 1, 10) = mktransdat10 And ktant.Item(it).tipe = "MS" And _
                    Format((Mid(ktant.Item(it).mk_trans_dat, 1, 10)) = Format(Mid(m_salaris.Item(i).TRANS_DAT, 1, 10))) Then

                        If ktant.Item(i).gekans = False Then

                            row_tel = 0
                            row_tel = row_tel + 1
                            DataGridView1.AutoGenerateColumns = False
                            DataGridView1.Refresh()

                            DataGridView1.ColumnCount = 6
                            DataGridView1.ColumnHeadersVisible = True
                            DataGridView1.Columns(0).Name = " "
                            DataGridView1.Columns(1).Name = "MandotoryPremium"
                            DataGridView1.Columns(2).Name = "Receipt"
                            DataGridView1.Columns(3).Name = "MandotoryDate"
                            DataGridView1.Columns(4).Name = "Transaction_Date"
                            DataGridView1.Columns(5).Name = "Payment_Type"

                            If IsDBNull(ktant.Item(i).tjekno_in) Then
                                Kwintasie = ktant.Item(i).kwitansie
                            Else
                                Kwintasie = ktant.Item(i).kwitansie / ktant.Item(i).tjekno_in
                            End If


                            DataGridView1.Rows.Insert(0, (" "), Format(ktant.Item(it).vord_premie, "#########00.00"), _
                                                      Kwintasie, Format(ktant.Item(it).vord_dat, "dd/mm/yyyy"), ktant.Item(it).trans_dat, ktant.Item(it).kontant_tipe, row_tel)


                        End If
                    End If
                Next
ktant_einde_5:
                'If (Err.Number = 3021) Or (m_salaris) Then
                '    GoTo mk_det_uit5
            End If
            'End While
        Next
        PopulateGridWithMaandSalaries()
mk_det_uit5:
        'End Using
        'zeroise vt_ingevorder
        nou_ingevorder.Enabled = True
        nou_ingevorder.Text = ""

        'zeroise memo
        Me.verw1.Text = " "
        Me.verw2.Text = " "
        Me.verw3.Text = " "
        Me.verw4.Text = " "
        Me.verw5.Text = " "

        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical)

        'End Try

    End Sub

    Public Sub kry_md_transaksies()
        'Dim jaar4 As Object
        'Dim vb_afdat As Object
        'Dim vb_jaar As Object
        Dim check_vb As Object
        'Dim vb_maand As Object
        Dim volg_maand As Object
        Dim volg_jaar As Object
        Dim sSql As Object
        Dim mdtransdat10 As Object
        Dim ingevorder As Object
        Dim grid_trans_dat As Object
        Dim grid_vord_dat As Object
        Dim grid_kwitansie As Object
        Dim grid_nou_ingevorder As Object
        Dim tot_jm As Object
        Dim vanaf_jm As Object
        Dim Kwintasie As Object
        Dim boek_jm As Object
        Dim boek_maand As Object
        Dim boek_jaar As Object
        Dim row_tel As Object
        Dim Ctr As Object
        Dim lus As Object
        Dim count_ As Object


        kry_vt_transaksies()


        If uitstaande.Text <> 0 Then
            MsgBox("There is VT's outstanding for the insured to the value of R " + Format(uitstaande) + ". To see which month had VT select  VT and press ENTER (on the Monthly Cash screen) ")
        End If


        If Persoonl.NoMatch Then
            Exit Sub
        End If

        Versekerde.Text = Persoonl.VERSEKERDE
        Voorl.Text = Mid(Persoonl.VOORL, 1, 5)
        Polisno.Text = Persoonl.POLISNO


        uitstaande.Text = CStr(0)

        Ctr = 0

        row_tel = 0
        'M_Debiet.Seek(">=", Polisno, jaar_van, maand_van)

        M_Debiet = FetchMaandDebities1(Persoonl.POLISNO)
        If M_Debiet.NoMatch Then
            GoTo einde_md_tr
        End If




        ''kry alle md transaksies
        ' While M_Debiet.POLISNO = Polisno.Text
        If M_Debiet.POLISNO = Polisno.Text Then


            'het gebruiker net uitstaandes aangevra?
            If Uitst_transaksies.Checked Then
                If M_Debiet.PREMIE = M_Debiet.VORD_PREMIE Then GoTo md_einde_2
            End If

            'val transaksie in aangevraagde vanaf en tot datum?

            boek_jaar = CStr(M_Debiet.JAAR)

            boek_jaar = Trim(boek_jaar)

            boek_jaar = (boek_jaar)


            If boek_maand <= 9 Then
                boek_maand = CStr(M_Debiet.MAAND)
                boek_maand = CStr("0" + Trim(boek_maand))
            Else
                boek_maand = CStr(boek_maand)
            End If


            'boek_maand = CStr(M_Debiet.MAAND)

            'boek_maand = Trim(boek_maand)

            'boek_maand = Format(boek_maand, "00")

            'boekhou datum as jjjjmm

            boek_jm = boek_jaar + boek_maand

            'datum vanaf en datum tot as jjjjmm

            vanaf_jm = jaar_van.Text & maand_van.Text

            tot_jm = jaar_tot.Text & maand_tot.Text


            If (boek_jm >= vanaf_jm) And (boek_jm >= tot_jm) Then
                GoTo sit2_in_grid2
            Else
                GoTo md_einde_2
            End If

sit2_in_grid2:

            'stel volgende ry op

            row_tel = row_tel + 1

            DataGridView1.RowCount = row_tel

            'berei grid veranderlikes voor

            If IsDBNull(M_Debiet.VORD_PREMIE) Then

                grid_nou_ingevorder = " "
            Else

                grid_nou_ingevorder = Str(M_Debiet.VORD_PREMIE)
            End If

            'grid_nou_ingevorder = Format(grid_nou_ingevorder, "0.00")


            grid_kwitansie = " "

            'vertoon vorder datum

            If IsDBNull(M_Debiet.VORD_DAT) Then

                grid_vord_dat = " "
            Else

                grid_vord_dat = M_Debiet.VORD_DAT
            End If


            If IsDBNull(M_Debiet.TRANS_DAT) Then

                grid_trans_dat = " "
            Else

                grid_trans_dat = CStr(M_Debiet.TRANS_DAT)
            End If

            'vertoon mk detail

            'Grid1.AddItem((VB6.Format(M_Debiet.Fields("afsluit_dat").Value) & Chr(9) & Str(M_Debiet.Fields("premie").Value) & Chr(9) + grid_nou_ingevorder + Chr(9) + grid_kwitansie + Chr(9) + VB6.Format(grid_vord_dat) + Chr(9) + grid_trans_dat), row_tel)


            If IsDBNull(M_Debiet.VORD_PREMIE) Then

                ingevorder = 0
            Else

                ingevorder = M_Debiet.VORD_PREMIE
            End If


            uitstaande.Text = uitstaande.Text + M_Debiet.PREMIE - ingevorder


            Ctr = Ctr + 1

            Err.Clear()

            'volg_md:
            'kry kontant transaksie wat saamgaan met md

            'kontant indeks is polisno/ md transaksie datum

            mdtransdat10 = Mid(M_Debiet.TRANS_DAT, 1, 10)


            'sSql = "SELECT * from Kontant where polisno = '" & Polisno.Text & "' and left(md_trans_dat,10) = '" & mdtransdat10 & "' and tipe = " & "'MD'"

            ' ktant = stats.OpenRecordset(sSql)

            'Do While Not ktant.BOF And Not ktant.EOF
            For i = 0 To ktant.Count - 1

                If Mid(ktant.Item(i).md_trans_dat, 1, 10) = mdtransdat10 And ktant.Item(i).tipe = "MD" And _
               Format((Mid(ktant.Item(i).md_trans_dat, 1, 10)) = Format(Mid(M_Debiet.TRANS_DAT, 1, 10))) Then


                    If ktant.Item(i).gekans = False Then

                        row_tel = row_tel + 1
                        DataGridView1.AutoGenerateColumns = False
                        DataGridView1.Refresh()

                        DataGridView1.ColumnCount = 6
                        DataGridView1.ColumnHeadersVisible = True
                        DataGridView1.Columns(0).Name = " "
                        DataGridView1.Columns(1).Name = "MadotoryPremium"
                        DataGridView1.Columns(2).Name = "Receipt"
                        DataGridView1.Columns(3).Name = "MandotoryDate"
                        DataGridView1.Columns(4).Name = "Transaction_Date"
                        DataGridView1.Columns(5).Name = "Payment_Type"

                        If IsDBNull(ktant.Item(i).tjekno_in) Then
                            Kwintasie = ktant.Item(i).kwitansie
                        Else
                            Kwintasie = ktant.Item(i).kwitansie / ktant.Item(i).tjekno_in
                        End If


                        DataGridView1.Rows.Insert(0, (" " & Chr(9) & " "), Format(ktant.Item(i).vord_premie, "#########00.00"), _
                                                  Kwintasie, Format(ktant.Item(i).vord_dat, "dd/mm/yyyy"), ktant.Item(i).trans_dat, ktant.Item(i).kontant_tipe, row_tel)

                    End If
                End If
            Next




md_einde_2:

            '        M_Debiet.MoveNext()

            '        'eof?
            '        If (Err.Number = 3021) Or (M_Debiet.EOF) Then
            '            GoTo md_det_uit2
            '        End If
            ' End While
        End If
md_det_uit2:

        'vooruitbetaling

        'genereer die vooruitbetalingstransaksie die gebruiker moet dan nog steeds daarteen n kontant ontvangste registreer die premie word vanaf persoonl gekry

        If check_vb Then

kry2_vb_jaar:
            If Month(Now) = 12 Then

                volg_jaar = CDbl(VB.Right(CStr(Year(Now)), 2)) + 1

                volg_maand = 1
            Else

                volg_jaar = VB.Right(CStr(Year(Now)), 2)

                volg_maand = Month(Now) + 1
            End If

kry2_vb_maand:



            vb_maand = InputBox("Vir watter maand is die vooruitbetaling (mm)?", Format(volg_maand, "00"))

            If vb_maand = "" Then
                MsgBox("You canceled the advance ...")

                check_vb = False
                GoTo einde_md_tr
            End If

            '        'kry jaar ook
kry2_vb_jaar3:


            vb_jaar = InputBox("For which year is the advance payment (yy)?", , volg_jaar)

            If vb_jaar = "" Then
                MsgBox("You canceled the advance ...")

                check_vb = False
                GoTo einde_md_tr
            End If

            'genereer vooruitbetalings transaksie

            vb_afdat = "01" & "/" & Format(vb_maand, "00") & "/" & Format(vb_jaar, "00")
            If Not (IsDate(vb_afdat)) Then
                MsgBox("Either the year or the month is incorrect - please enter the year as yy and month as mm ")
                GoTo kry2_vb_maand
            End If

            'skryf jaar as ccjj

            jaar4 = 1900 + vb_jaar


            grid_nou_ingevorder = " "

            grid_kwitansie = " "

            grid_vord_dat = " "

            grid_trans_dat = Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")




            ''skryf transaksie na maandeliks debiet tabel

            SaveDebit()

            row_tel = row_tel + 1

            DataGridView1.Rows.Insert((vb_afdat + Chr(9) + CStr(M_Debiet.PREMIE) + Chr(9) + grid_nou_ingevorder + Chr(9) + grid_kwitansie + Chr(9) + grid_vord_dat + Chr(9) + grid_trans_dat), row_tel)

        End If
        PopulateGridWithMaandDebit()
        'toets of daar vt's was
        'zeroise vt_ingevorder
        nou_ingevorder.Enabled = True
        nou_ingevorder.Text = ""

        'zeroise memo
        Me.verw1.Text = " "
        Me.verw2.Text = " "
        Me.verw3.Text = " "
        Me.verw4.Text = " "
        Me.verw5.Text = " "

einde_md_tr:

    End Sub
    Public Function FetchMaandDebities1(ByRef Nommer As String) As MaandEntity
        Dim item As MaandEntity = New MaandEntity
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                             New SqlParameter("@jaar", SqlDbType.SmallInt), _
                                             New SqlParameter("@maand", SqlDbType.SmallInt)}
                param(0).Value = Nommer
                param(1).Value = CInt(jaar_van.Text)
                param(2).Value = CInt(maand_van.Text)

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaandDebities]", param)

                While reader.Read()

                    If reader("Polisno") IsNot DBNull.Value Then
                        item.POLISNO = reader("Polisno")
                    End If
                    If reader("VORD_DAT") IsNot DBNull.Value Then
                        item.VORD_DAT = reader("VORD_DAT")
                    End If
                    If reader("PREMIE") IsNot DBNull.Value Then
                        item.PREMIE = reader("PREMIE")
                    End If
                    If reader("VORD_PREMIE") IsNot DBNull.Value Then
                        item.VORD_PREMIE = reader("VORD_PREMIE")
                    End If
                    If reader("MATCH") IsNot DBNull.Value Then
                        item.MATCH = reader("MATCH")
                    End If
                    If reader("NIE_MULTI") IsNot DBNull.Value Then
                        item.NIE_MULTI = reader("NIE_MULTI")
                    End If
                    If reader("NIE_MD") IsNot DBNull.Value Then
                        item.NIE_MD = reader("NIE_MD")
                    End If
                    If reader("ONINGEWIN") IsNot DBNull.Value Then
                        item.ONINGEWIN = reader("ONINGEWIN")
                    End If
                    If reader("AFSLUIT_DAT") IsNot DBNull.Value Then
                        item.AFSLUIT_DAT = reader("AFSLUIT_DAT")
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
                    If reader("BETAALWYSE") IsNot DBNull.Value Then
                        item.BETAALWYSE = reader("BETAALWYSE")
                    End If
                    If reader("ingevorder") IsNot DBNull.Value Then
                        item.ingevorder = reader("ingevorder")
                    End If
                    If reader("md_trans_dat") IsNot DBNull.Value Then
                        item.md_trans_dat = reader("md_trans_dat")
                    End If
                    If reader("Kwit_boek") IsNot DBNull.Value Then
                        item.Kwit_boek = reader("Kwit_boek")
                    End If
                    If reader("Area") IsNot DBNull.Value Then
                        item.Area = reader("Area")
                    End If

                End While
                Return item
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function

    Private Sub Hernuwing_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Hernuwing.CheckStateChanged
        Dim datStart As Date
        Dim datEnd As Date
        Dim bytMonths As Byte
        Dim strDesc As String
        Dim strStatus As String
        Dim bytStatus As Byte
        Dim strMessage As String

        If Me.Hernuwing.CheckState = 1 Then
            'Andriette 09/07/2014 maak die funksie meer eenvoudig en pos alles dan in die entity ipv variables
            ' gen_getTermPolicyStatus(Persoonl.BET_WYSE, Persoonl.POLISNO, datStart, datEnd, bytMonths, strDesc, strStatus, bytStatus)
            gen_getTermPolicyStatus(Persoonl.POLISNO)
            If bytStatus = 1 Then 'Active term
                Me.Hernuwing.CheckState = System.Windows.Forms.CheckState.Unchecked
                strMessage = "The policy term can not be renewed because the current term has not expired not."
                strMessage = strMessage & Chr(13) & "Current term: " & datStart & " - " & datEnd
                MsgBox(strMessage, MsgBoxStyle.Information)
            Else
                Me.Nuwepolis.CheckState = System.Windows.Forms.CheckState.Unchecked
                Me.Wysiging.CheckState = System.Windows.Forms.CheckState.Unchecked

                LangtermynTydperk.ShowDialog()

                UpdateWysig(190, "")

                UpdateCLRSField("A", (Form1.POLISNO).Text)

            End If
        End If

    End Sub

    Private Sub Image1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Image1.Click
        MsgBox("'New policy'should be clicked when a new policy is entered for the insured or when there is a different way to pay long-term policy changed. ")

    End Sub

    Private Sub jaar_tot_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles jaar_tot.TextChanged
        jaar_tot_n = jaar_tot.Text
    End Sub

    Private Sub jaar_van_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles jaar_van.Leave
        jaar_van_n = jaar_van.Text
    End Sub

    Private Sub k_verslae_Click()
        Dim kwitdruk As Object
        kwitdruk.Show()
    End Sub
    Private Sub jkearnedcmd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles jkearnedcmd.Click
        'Vertoon(Langtermynpolis)
        'Polisno.Text = Form1.POLISNO.Text
        'UitgeloopJN = "N"
        'Oor2maanduitgeloopJN = "N"
        'VertoonEarnedJN = "J"
        'UnEarned = 0
        'Call VertoonLangtermynpolis(Polisno, UitgeloopJN, Oor2maanduitgeloopJN, VertoonEarnedJN)

        KontantReportViewer.Show()

        'KontantReportViewer.DeleteKontant()


    End Sub
    Private Sub Kont_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Kont.CheckedChanged
        If eventSender.Checked Then
            'Tjek button is nie gekliek, vertoon nie tjek besonderhede
            Me.Label12.Visible = False
            Me.Label15.Visible = False
            Me.Label16.Visible = False
            Me.Label17.Visible = False

            Me.Tjekno.Visible = False
            Me.nuwe_tjekno.Visible = False
            Me.Tjekdatum.Visible = False
            Me.Tjekbesonderhede.Visible = False

        End If
    End Sub

    Private Sub kwit_betaalwyse_Click()
        'Dim TITEL As Object
        'Dim kdat_datum_tot_f As Object
        'Dim kdat_datum_van_f As Object
        'Dim krit_tot As Object
        'Dim krit_vanaf As Object
        'Dim kdat_datum_tot As Object
        'Dim kdat_datum_van As Object
        'Dim datum As Object
        'Dim mktjekuitprem As Object
        'Dim mktjekinprem As Object
        'Dim mdtjekuitprem As Object
        'Dim mdtjekinprem As Object
        'Dim mkkontuitprem As Object
        'Dim mkkontinprem As Object
        'Dim mdkontuitprem As Object
        'Dim mdkontinprem As Object

        'enige transaksies?

        'Dim reports As DAO.Database
        'Dim kwit_dtl As DAO.Recordset
        'Dim mdkrekon As DAO.Recordset
        'Dim mkkrekon As DAO.Recordset
        ''open leers
        'reports = DAODBEngine_definst.OpenDatabase(pol_path & "\reports5.mdb")
        'kwit_dtl = reports.OpenRecordset("kwit_dtl")
        'tak_hoof = pol.OpenRecordset("SELECT * FROM area WHERE area_kode in " & Gebruiker.BranchCodes  & " ")
        'mdkrekon = reports.OpenRecordset("mdkontantrekon")
        'mkkrekon = reports.OpenRecordset("mkkontantrekon")

        mdkontinprem = 0
        mdkontuitprem = 0
        mkkontinprem = 0
        mkkontuitprem = 0

        mdtjekinprem = 0
        mdtjekuitprem = 0
        mktjekinprem = 0
        mktjekuitprem = 0

        datum = 0
        'tak_hoof.MoveFirst()

        'vertoon dialog wat drukker selekteer
        On Error Resume Next
        Err.Clear()
        CommonDialog1Print.ShowDialog()
        If Err.Number = 32755 Then
            MsgBox("You have canceled. Program ends now.")
            Exit Sub
        End If
        On Error GoTo 0

        'delete kwitansie databasis
        On Error Resume Next
        Err.Clear()
        'kwit_dtl.MoveFirst()
        While Err.Number = 0
            'kwit_dtl.Delete()
            DeleteFromKwit_dtl()
            'kwit_dtl.MoveNext()
        End While
        On Error GoTo 0

kry_datum:

        'Kry transaksie datum van en transaksie datum tot
        kdat_datum_van = InputBox("Transaction date from (dd / mm / yyyy)? ", " Please. date")

        kdat_datum_tot = InputBox("Transaction date to (dd / mm / yyyy)? ", " Please. date")

        'kry kontant transaksies wat voldoen aan seleksie kriteria
        'is datums geselekteer?
        If (kdat_datum_van <> "") Or (kdat_datum_tot <> "") Then
            If (kdat_datum_van = "") Or (kdat_datum_tot = "") Then
                MsgBox("Please fill all the dates....")
                GoTo kry_datum
            End If

            'toets of datum wel n datum is
            If IsDate(kdat_datum_van) And IsDate(kdat_datum_tot) Then
            Else
                MsgBox("One of the dates is not a valid date. Enter the date as dd / mm / yy")
                GoTo kry_datum
            End If
            'skryf kriteria vir crystal reports
            krit_vanaf = "Datum=" & Mid(kdat_datum_van, 1, 10)
            krit_tot = "Datum=" & Mid(kdat_datum_tot, 1, 10)
            datum = 1
            '    ktant.Index = "t_index"
            '    ktant.Seek(">=", kdat_datum_van)
            ktant1 = FetchKontantByTrans_Dat()
        End If

        If Not ktant1.Nomatch Then

            'lees alle kwitansie rekords vanaf "vanaf datum" tot by "tot datum"    OF vanaf "vanaf kwitansie nommer" tot by "tot kwitansie nommer"
lees_kwit:

            If datum = 1 Then
                'oorskry transaksie aangevraagde tot datum?
                kdat_datum_van_f = Format(kdat_datum_van, "dd/mm/yyyy hh:mm:ss")
                kdat_datum_tot_f = Format(kdat_datum_tot, "dd/mm/yyyy hh:mm:ss")
                If ((DateDiff(Microsoft.VisualBasic.DateInterval.Day, ktant1.trans_dat, kdat_datum_van_f)) <= 0) And ((DateDiff(Microsoft.VisualBasic.DateInterval.Day, ktant1.trans_dat, kdat_datum_tot_f)) >= 0) Then
                    GoTo druk_lyn
                Else
                    GoTo ktant_einde
                End If

            End If

druk_lyn:
            'kry persoonl rekord
            Persoonl.Index = "pn_index"
            'Persoonl.Seek("=", ktant.Fields("polisno"))
            If Persoonl.NoMatch Then
                MsgBox(ktant1.polisno + " is not found in PERSONAL")
                Exit Sub
            End If
            InsertKwit_dtl()

            'Akkumuleer totale vir md kontant rekon
            Select Case Persoonl.BET_WYSE
                Case "1" 'MK
                    mkkontuitprem = mkkontuitprem + ktant1.vord_premie
                Case "4" 'MD
                    mdkontuitprem = mdkontuitprem + ktant1.vord_premie
            End Select

            'Akkumuleer totale vir md kontant rekon
            Select Case Persoonl.BET_WYSE
                Case "1" 'MK
                    mktjekinprem = mktjekinprem + ktant1.vord_premie

                Case "4" 'MD
                    mdtjekinprem = mdtjekinprem + ktant1.vord_premie
            End Select

            'If ktant1.EOF = True Then
            '    GoTo ktant_einde
            'Else
            '    GoTo lees_kwit
            'End If

        End If

ktant_einde:

        UpdateMD_MKkontantrekon()
        FileClose()
        MsgBox("Receipt Report by mode of payment is printed")
        Exit Sub
    End Sub

    Sub InsertKwit_dtl()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                 New SqlParameter("@tak_naam", SqlDbType.NVarChar), _
                                                 New SqlParameter("@kwitansie", SqlDbType.NVarChar), _
                                                 New SqlParameter("@titel", SqlDbType.NVarChar), _
                                                 New SqlParameter("@voorl", SqlDbType.NVarChar), _
                                                 New SqlParameter("@versekerde", SqlDbType.NVarChar), _
                                                 New SqlParameter("@Jaar", SqlDbType.SmallInt), _
                                                 New SqlParameter("@Maad", SqlDbType.SmallInt), _
                                                 New SqlParameter("@krit_vanaf", SqlDbType.NVarChar), _
                                                 New SqlParameter("@krit_tot", SqlDbType.NVarChar), _
                                                 New SqlParameter("@trans_dat", SqlDbType.DateTime), _
                                                 New SqlParameter("@gekans", SqlDbType.NVarChar), _
                                                 New SqlParameter("@vord_premie", SqlDbType.Float), _
                                                 New SqlParameter("@kans_premie", SqlDbType.Float), _
                                                 New SqlParameter("@kwit_boek", SqlDbType.NVarChar), _
                                                 New SqlParameter("@kontant_in", SqlDbType.Float), _
                                                 New SqlParameter("@kontant_uit", SqlDbType.Float), _
                                                 New SqlParameter("@Tjeks_in", SqlDbType.Float), _
                                                 New SqlParameter("@tjeks_uit", SqlDbType.Float)}

                params(0).Value = Persoonl.POLISNO
                params(1).Value = tak_hoof.tak_naam
                params(2).Value = ktant1.kwitansie

                Select Case Persoonl.TITEL
                    Case "0"

                        TITEL = "Mnr."
                    Case "1"

                        TITEL = "Me."
                    Case "2"

                        TITEL = "Prof."
                    Case "3"

                        TITEL = "Dr."
                    Case "4"

                        TITEL = ""
                    Case "5"

                        TITEL = "Past."
                    Case "6"

                        TITEL = "Ds."
                    Case "7"

                        TITEL = "Brig Genl"
                    Case "8"

                        TITEL = "Kolonel"
                    Case "9"

                        TITEL = "Luit. Genl."
                    Case "A"

                        TITEL = "Kaptein"
                    Case "B"

                        TITEL = "Advokaat"
                    Case "C"

                        TITEL = "Brigadier"
                    Case "D"

                        TITEL = "Regter"
                    Case "E"

                        TITEL = "Graaf"
                End Select
                params(3).Value = TITEL
                params(4).Value = Mid(Persoonl.VOORL, 1, 5)
                params(5).Value = Persoonl.VERSEKERDE
                params(6).Value = ktant1.jaar
                params(7).Value = ktant1.maand
                params(8).Value = krit_vanaf
                params(9).Value = krit_tot
                params(10).Value = ktant1.trans_dat



                If ktant1.gekans = 1 Then
                    params(11).Value = "Gekanselleer"
                    params(12).Value = 0
                    params(13).Value = ktant1.vord_premie
                    params(14).Value = DBNull.Value
                Else
                    params(11).Value = " "
                    params(12).Value = ktant1.vord_premie
                    params(13).Value = 0
                    params(14).Value = ktant1.kwit_boek

                End If

                If Not ktant1.gekans Then
                    If ktant1.kontant_tipe = "K" Then

                        If InStr(ktant1.kwitansie, "TB") = 0 Then
                            params(14).Value = ktant1.vord_premie
                            Select Case Persoonl.BET_WYSE
                                Case "1" 'MK
                                    mkkontinprem = mkkontinprem + ktant1.vord_premie

                                Case "4" 'MD
                                    mdkontinprem = mdkontinprem + ktant1.vord_premie
                            End Select
                        Else
                            params(15).Value = ktant1.vord_premie
                            Select Case Persoonl.BET_WYSE
                                Case "1" 'MK
                                    mkkontuitprem = mkkontuitprem + ktant1.vord_premie
                                Case "4" 'MD
                                    mdkontuitprem = mdkontuitprem + ktant1.vord_premie
                            End Select

                        End If

                    Else
                        If InStr(ktant1.kwitansie, "TB") = 0 Then
                            params(16).Value = ktant1.vord_premie
                            Select Case Persoonl.BET_WYSE
                                Case "1" 'MK
                                    mktjekinprem = mktjekinprem + ktant1.vord_premie

                                Case "4" 'MD
                                    mdtjekinprem = mdtjekinprem + ktant1.vord_premie
                            End Select
                        Else
                            params(17).Value = ktant1.vord_premie

                        End If

                    End If
                End If

                '        kwit_dtl.Update()

                params(0).Value = Persoonl.POLISNO
                params(1).Value = Format(Val(nou_ingevorder.Text), "#####.00")
                params(2).Value = 0
                params(3).Value = vb_afdat
                params(4).Value = jaar4
                params(5).Value = vb_maand
                params(6).Value = Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")
                params(7).Value = Persoonl.BET_WYSE
                params(8).Value = Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")

                If Me.Tjek.Checked = True Then
                    params(9).Value = "T"
                Else
                    If Me.Kont.Checked = True Then
                        params(9).Value = "K"
                    Else
                        If Me.Elektronies.Checked = True Then
                            params(9).Value = "E"
                        End If
                    End If

                End If
                params(10).Value = False

                'identifiseer watter tipe betaling
                tipe_bet = " "
                If Me.eerstebetaling.CheckState = 1 Then
                    params(11).Value = "EB"
                    tipe_bet = "EB"
                Else
                    If Me.Vooruitbetaling.CheckState = 1 Then
                        params(11).Value = "VB"
                        tipe_bet = "VB"
                    Else
                        If Me.terugbetaling.CheckState = 1 Then
                            params(11).Value = "TB"
                            tipe_bet = "TB"
                        Else
                            If Me.Langtermynpolis.CheckState = 1 Then
                                params(11).Value = "JK"
                                tipe_bet = "JK"
                            End If
                        End If
                    End If
                End If
                params(12).Value = Persoonl.Area


                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[stats5].[UpdateKontantGegenereer]", params)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

    End Sub

    Sub UpdateMD_MKkontantrekon()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@mdKontinprem", SqlDbType.Float), _
                                                 New SqlParameter("@mdKontuitprem", SqlDbType.Float), _
                                                 New SqlParameter("@mdTjinprem", SqlDbType.Float), _
                                                 New SqlParameter("@mdTjuitprem", SqlDbType.Float), _
                                                 New SqlParameter("@mkKontinprem", SqlDbType.Float), _
                                                 New SqlParameter("@mkKontuitprem", SqlDbType.Float), _
                                                 New SqlParameter("@mkTjinprem", SqlDbType.Float), _
                                                 New SqlParameter("@mkTjuitprem", SqlDbType.Float)}



                params(0).Value = mdkontinprem
                params(1).Value = mdkontuitprem
                params(2).Value = mktjekinprem
                params(3).Value = mdtjekuitprem
                params(4).Value = mkkontinprem
                params(5).Value = mkkontuitprem
                params(6).Value = mktjekinprem
                params(7).Value = mktjekuitprem

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[Reports5].[UpdateMD_MKkontantrekon]", params)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

    End Sub
    Function FetchKontantByTrans_Dat()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@kdat_datum_van", SqlDbType.DateTime)

                param.Value = kdat_datum_van

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchKontantByTrans_Dat]", param)

                Dim item As KontantEntity = New KontantEntity()

                While reader.Read

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
                    Return item

                End While
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

            Exit Function
        End Try
    End Function
    Function DeleteFromKwit_dtl()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar)}


                param(0).Value = Persoonl.POLISNO

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[Reports5].[DeleteKwit_dtl]", param)

                Return True

            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing

        End Try
    End Function

    Private Sub kwit_datum_Click()
        Dim TITEL As Object
        Dim kdat_datum_tot_f As Object
        Dim kdat_datum_van_f As Object
        Dim krit_tot As Object
        Dim krit_vanaf As Object
        Dim kdat_datum_tot As Object
        Dim kdat_datum_van As Object
        Dim datum As Object
        '        'enige transaksies?
        '        'vertoon kwitansie verslag seleksie skerm

        '        Dim reports As DAO.Database
        '        Dim kwit_dtl As DAO.Recordset
        '        'open leers
        '        reports = DAODBEngine_definst.OpenDatabase(pol_path & "\reports5.mdb")
        '        kwit_dtl = reports.OpenRecordset("kwit_dtl")
        '        tak_hoof = pol.OpenRecordset("SELECT * FROM area WHERE area_kode in " & Gebruiker.BranchCodes  & " ")

        datum = 0
        '        tak_hoof.MoveFirst()

        '        'vertoon dialog wat drukker selekteer
        On Error Resume Next
        Err.Clear()
        CommonDialog1Print.ShowDialog()
        If Err.Number = 32755 Then
            MsgBox("You have canceled. Program ends Now.")
            Exit Sub
        End If
        On Error GoTo 0

        'delete kwitansie databasis
        On Error Resume Next
        Err.Clear()
        'kwit_dtl.MoveFirst()
        While Err.Number = 0
            DeleteFromKwit_dtl()
            'kwit_dtl.Delete()
            'kwit_dtl.MoveNext()
        End While
        On Error GoTo 0

kry_datum:

        'Kry transaksie datum van en transaksie datum tot
        kdat_datum_van = InputBox("Transaction date From(dd / mm / yyyy)? ", " Please. date")
        kdat_datum_tot = InputBox("Transaction date to (dd / mm / yyyy)? ", " Please. date")

        'kry kontant transaksies wat voldoen aan seleksie kriteria is datums geselekteer?
        If (kdat_datum_van <> "") Or (kdat_datum_tot <> "") Then
            If (kdat_datum_van = "") Or (kdat_datum_tot = "") Then
                MsgBox("Please fill all the dates...")
                GoTo kry_datum
            End If

            'toets of datum wel n datum is
            If IsDate(kdat_datum_van) And IsDate(kdat_datum_tot) Then
            Else
                MsgBox("One of the dates is not a valid date. Enter the date as dd / mm / yy")
                GoTo kry_datum
            End If

            krit_vanaf = "Datum=" & Mid(kdat_datum_van, 1, 10)
            krit_tot = "Datum=" & Mid(kdat_datum_tot, 1, 10)


            datum = 1
            'ktant.Index = "t_index"
            'ktant.Seek(">=", kdat_datum_van)
            ktant1 = FetchKontantByTrans_Dat()
        End If

        If Not ktant1.Nomatch Then

            'Read all records from receipt "from date" to "to date" from OR "from receipt number" to "until receipt number"
lees_kwit:

            If datum = 1 Then
                'oorskry transaksie aangevraagde tot datum?
                kdat_datum_van_f = Format(kdat_datum_van, "dd/mm/yyyy hh:mm:ss")
                kdat_datum_tot_f = Format(kdat_datum_tot, "dd/mm/yyyy hh:mm:ss")
                If ((DateDiff(Microsoft.VisualBasic.DateInterval.Day, ktant1.trans_dat, kdat_datum_van_f)) <= 0) And ((DateDiff(Microsoft.VisualBasic.DateInterval.Day, ktant1.trans_dat, kdat_datum_tot_f)) >= 0) Then
                    GoTo druk_lyn
                Else
                    GoTo ktant_einde
                End If

            End If

druk_lyn:
            'kry persoonl rekord
            Persoonl.Index = "pn_index"
            'Persoonl.Seek("=", ktant.Fields("polisno"))
            If Persoonl.NoMatch Then
                MsgBox(ktant1.polisno + " is not found in PERSONAL")
                Exit Sub
            End If

            InsertKwit_dtl()
        End If

ktant_einde:

        FileClose()
        MsgBox("Receipt reports by date printed ...")
        Exit Sub

    End Sub

    Private Sub kwit_Kwitansie_Click()

        datum = 0

        'vertoon dialog wat drukker selekteer
        On Error Resume Next
        Err.Clear()
        CommonDialog1Print.ShowDialog()
        If Err.Number = 32755 Then
            MsgBox("Jy het gekanselleer. Program eindig nou.")
            Exit Sub
        End If
        On Error GoTo 0

        'delete kwitansie databasis
        On Error Resume Next
        Err.Clear()
        'kwit_dtl.MoveFirst()
        While Err.Number = 0
            DeleteFromKwit_dtl()
            'kwit_dtl.Delete()
            'kwit_dtl.MoveNext()
        End While
        On Error GoTo 0

kry_datum:

        'Kry transaksie datum van en transaksie datum tot
        kdat_datum_van = InputBox("Transaksie datum van (dd/mm/jjjj)?", "Verskaf asb. datum")
        kdat_datum_tot = InputBox("Transaksie datum tot (dd/mm/jjjj)?", "Verskaf asb. datum")

        'kry kontant transaksies wat voldoen aan seleksie kriteria is datums geselekteer?
        If (kdat_datum_van <> "") Or (kdat_datum_tot <> "") Then
            If (kdat_datum_van = "") Or (kdat_datum_tot = "") Then
                MsgBox("Please fill all the dates...")
                GoTo kry_datum
            End If

            'toets of datum wel n datum is
            If IsDate(kdat_datum_van) And IsDate(kdat_datum_tot) Then
            Else
                MsgBox("One of the dates is not a valid date. Enter date as dd / mm / yy")
                GoTo kry_datum
            End If
            'skryf kriteria vir crystal reports
            krit_vanaf = "Datum=" & VB.Left(kdat_datum_van, 10)
            krit_tot = "Datum=" & VB.Left(kdat_datum_tot, 10)
            datum = 1
            'ktant.Index = "t_index"
            ' ktant.Seek(">=", kdat_datum_van)
        End If

        If Not (ktant1.Nomatch) Then

            'lees alle kwitansie rekords vanaf "vanaf datum" tot by "tot datum"    OF vanaf "vanaf kwitansie nommer" tot by "tot kwitansie nommer"
lees_kwit:

            If datum = 1 Then
                'oorskry transaksie aangevraagde tot datum?
                kdat_datum_van_f = Format(kdat_datum_van, "dd/mm/yyyy hh:mm:ss")
                kdat_datum_tot_f = Format(kdat_datum_tot, "dd/mm/yyyy hh:mm:ss")
                If ((DateDiff(Microsoft.VisualBasic.DateInterval.Day, ktant1.trans_dat, kdat_datum_van_f)) <= 0) And ((DateDiff(Microsoft.VisualBasic.DateInterval.Day, ktant1.trans_dat, kdat_datum_tot_f)) >= 0) Then
                    GoTo druk_lyn
                Else
                    GoTo ktant_einde
                End If

            End If

druk_lyn:
            'kry persoonl rekord
            If Persoonl.NoMatch Then
                MsgBox(ktant1.polisno + " is not found in PERSONAL")
                Exit Sub
            End If

            InsertKwit_dtl()




            '            'kry volgende kwitansie
            '            ktant.MoveNext()
            '            If (ktant.EOF) Then
            '                GoTo ktant_einde
            '            Else
            '                GoTo lees_kwit
            '            End If

        End If

ktant_einde:


        FileClose()
        MsgBox("Receipt reports by receipt book was printed...")
        Exit Sub

    End Sub

    Private Sub m_kwitansie_Click()

    End Sub

    Private Sub PCS_Click()
        Dim All As Object

        'tak_hoof
        'Dim tak_hoof As DAO.Recordset

        'tak_hoof = pol.OpenRecordset("tak")
        tak_hoof = FetchAreaCodeByPersoon()
        'aktiveer VDH databasis of PCS databasis
        ' tak_hoof.MoveFirst()

        If (tak_hoof.tak_naam = "Potchefstroom") Or (tak_hoof.tak_naam = "Vaaldriehoek") Then

            FileClose(All)

            'open databasis en tabelle
            Init_Pol()

            command4_Click(Command4, New System.EventArgs())

        End If

    End Sub

    Private Sub m_tjek_tjek_Click()

        'Tjek besonderhede volgens Tjek datum/Tjek nommer
        'Dim Ntemp5 As DAO.Database
        'Dim Eisdata5 As DAO.Database
        'Dim tjeks As DAO.Recordset
        'Dim tjektdata As DAO.Recordset
        'Ntemp5 = DAODBEngine_definst.OpenDatabase(pol_path & "\n_temp5.mdb")
        'Eisdata5 = DAODBEngine_definst.OpenDatabase(pol_path & "\Eisdata5.mdb")
        'tjektdata = Ntemp5.OpenRecordset("tjek_t_data")

    End Sub

    Private Sub m_tjek_Click()

        'Vertoon tjek druk skerm

    End Sub


    Private Sub Langtermynpolis_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Langtermynpolis.CheckStateChanged

        If Me.Langtermynpolis.CheckState = 1 Then
            'deselekteer al die ander opsies
            Check_mk.CheckState = System.Windows.Forms.CheckState.Unchecked
            check_md.CheckState = System.Windows.Forms.CheckState.Unchecked
            Check_ms.CheckState = System.Windows.Forms.CheckState.Unchecked
            Check_VT.CheckState = System.Windows.Forms.CheckState.Unchecked
            Check_me.CheckState = System.Windows.Forms.CheckState.Unchecked
            eerstebetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
            Vooruitbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
            terugbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        End If

    End Sub

    Private Sub Langtermynpolis_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Langtermynpolis.Enter

        kwit_boek.Visible = True
        Label14.Visible = True

    End Sub


    Private Sub maand_tot_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles maand_tot.TextChanged
        maand_tot_n = maand_tot.Text
    End Sub


    Private Sub maand_van_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles maand_van.TextChanged
        maand_van_n = maand_van.Text
    End Sub

    Public Sub MD_uistaande_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MD_uistaande.Click

    End Sub

    Public Sub MK_Uitstaande_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MK_Uitstaande.Click

    End Sub

    Public Sub MS_Uitstaande_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MS_Uitstaande.Click

    End Sub


    Private Sub nou_ingevorder_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles nou_ingevorder.TextChanged

        If Me.Langtermynpolis.CheckState = 1 Then
            If Me.Nuwepolis.CheckState = 0 And Me.Hernuwing.CheckState = 0 And Me.Wysiging.CheckState = 0 And Me.terugbetaling.CheckState = 0 Then
                MsgBox("Before a cash receipts can be registered for a termypolis must first indicate whether a new policy, a renewal, a modification or a repayment.")
                Exit Sub
            End If
        End If

    End Sub

    Private Sub nou_ingevorder_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles nou_ingevorder.Leave
        Dim verwagtepremie As Object

        'If (Form1.txtTipePolis.Text = "Termynpolis") And (Me.Nuwepolis.CheckState = 1 Or Me.Hernuwing.CheckState = 1) Then
        If (Form1.lbltipepolis.Text = "Termynpolis") And (Me.Nuwepolis.CheckState = 1 Or Me.Hernuwing.CheckState = 1) Then
            If Me.Hernuwing.CheckState Then

                verwagtepremie = (Val(Form1.Premie2.Text) * Val(LangtermynTydperk.cmbTydperk.Text))
            Else

                'verwagtepremie = (Val(Form1.Premie2.Text) * Val(Form1.txtAantalMaande.Text))
            End If
            verwagtepremie = (Val(Form1.Premie2.Text) * Val(Form1.lbltermynmaande.Text))

            If CSng(nou_ingevorder.Text) <> CSng(verwagtepremie) Then

                MsgBox("The transaction amount that you entered the difference of the expected premium (final premium * Number of months). The expected premium is R " & verwagtepremie)
            End If
        End If
    End Sub


    Private Sub Nuwepolis_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Nuwepolis.CheckStateChanged

        If Me.Nuwepolis.CheckState = 1 Then
            Me.Hernuwing.CheckState = System.Windows.Forms.CheckState.Unchecked
            Me.Wysiging.CheckState = System.Windows.Forms.CheckState.Unchecked
        End If

    End Sub



    Private Sub PCSk_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PCSk.CheckedChanged
        If eventSender.Checked Then
            Dim pcsdat As Object
            Dim All As Object

            Dim retval As Object
            ' pol = DAODBEngine_definst.OpenDatabase(pol_path & "\poldata5.mdb")

            'Dim tak_hoof As DAO.Recordset

            'tak_hoof = pol.OpenRecordset("SELECT * FROM area WHERE area_kode in " & Gebruiker.BranchCodes & " ")
            tak_hoof = FetchAreaCodeByPersoon()

            'aktiveer VDH databasis of PCS databasis
            'tak_hoof.MoveFirst()
            If tak_hoof.tak_naam = "Potchefstroom" Or tak_hoof.tak_naam = "Vaaldriehoek" Then


                FileClose(All)

                Call clear_scr()

                'Kopieer pcs.ini na poldata.ini
                'FileOpen(15, "c:\windows\pcs.ini", OpenMode.Input)
                'FileOpen(16, "c:\windows\poldata.ini", OpenMode.Output)

                While Not EOF(15)
                    pcsdat = LineInput(15)
                    PrintLine(16, pcsdat)
                End While

                FileClose(15, 16)

                'Maak seker dat die kopiering klaar is voordat aangegaan word met kode
                MsgBox("Potchefstroom's database is now loaded ... just wait a moment please!!!")

                'open databasis en tabelle
                Init_Pol()

                command4_Click(Command4, New System.EventArgs())

            End If

        End If
    End Sub

    Private Sub Polisno_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Polisno.Click

        clear_scr()

    End Sub

    Private Sub Polisno_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Polisno.Leave

        Persoonl.Index = "pn_index"
        '        Persoonl.Seek("=", Me.Polisno)
        Persoonl.POLISNO = Polisno.Text
        If Persoonl.NoMatch Then
            MsgBox("This policy does not exist on the database...")
        End If

    End Sub


    Private Sub terugbetaling_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles terugbetaling.CheckStateChanged

        If terugbetaling.CheckState = 1 Then
            command4_Click(Command4, New System.EventArgs())
        End If

    End Sub


    Private Sub terugbetaling_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles terugbetaling.Enter
        'deselekteer al die ander opsies
        Check_mk.CheckState = System.Windows.Forms.CheckState.Unchecked
        check_md.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_ms.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_VT.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_me.CheckState = System.Windows.Forms.CheckState.Unchecked
        eerstebetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        Vooruitbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        genereer_trans.PerformClick()

        Langtermynpolis.CheckState = System.Windows.Forms.CheckState.Unchecked
        Nuwepolis.CheckState = System.Windows.Forms.CheckState.Unchecked
        Hernuwing.CheckState = System.Windows.Forms.CheckState.Unchecked
        Wysiging.CheckState = System.Windows.Forms.CheckState.Unchecked

        Command3.Visible = False
        Label14.Visible = False
        kwit_boek.Visible = False
    End Sub

    Private Sub Text1_Change()

        clear_scr()

    End Sub

    Private Sub Text2_change()

        clear_scr()

    End Sub

    Private Sub Tjek_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Tjek.CheckedChanged
        If eventSender.Checked Then

            'Tjek button is gekliek, vertoon tjek besonderhede
            Me.Label12.Visible = True
            Me.Label16.Visible = True
            Me.Label17.Visible = True

            Me.Tjekno.Visible = True
            Me.Tjekdatum.Visible = True
            Me.Tjekbesonderhede.Visible = True

        End If
    End Sub


    Private Sub VDHk_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VDHk.CheckedChanged
        If eventSender.Checked Then
            Dim vdhdat As Object
            Dim All As Object

            Dim retval As Object
            'pol = DAODBEngine_definst.OpenDatabase(pol_path & "\poldata5.mdb")

            ' Dim tak_hoof As DAO.Recordset

            'tak_hoof = pol.OpenRecordset("SELECT * FROM area WHERE area_kode in " & Gebruiker.BranchCodes & " ")
            tak_hoof = FetchAreaCodeByPersoon()
            'aktiveer VDH databasis of PCS databasis
            'tak_hoof.MoveFirst()
            If (tak_hoof.tak_naam = "Potchefstroom") Or (tak_hoof.tak_naam = "Vaaldriehoek") Then


                FileClose(All)

                Call clear_scr()

                'Kopieer vaal.ini na poldata.ini
                FileOpen(15, "c:\windows\vaal.ini", OpenMode.Input)
                FileOpen(16, "c:\windows\poldata.ini", OpenMode.Output)

                While Not EOF(15)
                    vdhdat = LineInput(15)
                    PrintLine(16, vdhdat)
                End While

                FileClose(15, 16)

                'Maak seker dat die kopiering klaar is voordat aangegaan word met kode
                MsgBox("Vaal Triangle's database is now loaded ... just wait a moment please")

                'open databasis en tabelle
                Init_Pol()

                command4_Click(Command4, New System.EventArgs())
            End If
        End If
    End Sub

    Private Sub Versekerde_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Versekerde.Click

        clear_scr()

    End Sub

    Private Sub verw1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles verw1.Leave

        'lengte mag net 80 karakters lank wees
        If Len(Me.verw1.Text) > 80 Then
            MsgBox(CDbl("Marking a line exceeds 80 characters. it is") + Len(Me.verw1.Text) + CDbl(" characters long. Please reduce."))
            Me.verw1.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub verw2_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles verw2.Leave

        'lengte mag net 80 karakters lank wees
        If Len(Me.verw2.Text) > 80 Then
            MsgBox(CDbl("Marking a line exceeds 80 characters. it is") + Len(Me.verw2.Text) + CDbl("characters long. Please reduce."))
            Me.verw2.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub verw3_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles verw3.Leave

        'lengte mag net 80 karakters lank wees
        If Len(Me.verw3.Text) > 80 Then
            MsgBox(CDbl("Marking a line exceeds 80 characters. it is") + Len(Me.verw3.Text) + CDbl(" characters long. Please reduce."))
            Me.verw3.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub verw4_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles verw4.TextChanged

        'lengte mag net 80 karakters lank wees
        If Len(Me.verw4.Text) > 80 Then
            MsgBox(CDbl("Marking a line exceeds 80 characters. it is ") + Len(Me.verw4.Text) + CDbl(" characters long. Please reduce."))
            Me.verw4.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub verw5_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles verw5.Leave

        'lengte mag net 80 karakters lank wees
        If Len(Me.verw5.Text) > 80 Then
            MsgBox(CDbl("Marking a line exceeds 80 characters. it is ") + Len(Me.verw5.Text) + CDbl(" characters long. Please reduce."))
            Me.verw5.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub Vooruitbetaling_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Vooruitbetaling.CheckStateChanged

        If Vooruitbetaling.CheckState = 1 Then
            command4_Click(Command4, New System.EventArgs())
        End If

    End Sub


    Private Sub Vooruitbetaling_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Vooruitbetaling.Enter
        'deselekteer al die ander opsies
        Langtermynpolis.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_mk.CheckState = System.Windows.Forms.CheckState.Unchecked
        check_md.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_ms.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_VT.CheckState = System.Windows.Forms.CheckState.Unchecked
        Check_me.CheckState = System.Windows.Forms.CheckState.Unchecked
        eerstebetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        terugbetaling.CheckState = System.Windows.Forms.CheckState.Unchecked
        genereer_trans.PerformClick()

        Command3.Visible = False
        Label14.Visible = True
        kwit_boek.Visible = True

    End Sub

    Public Sub najk2005()

    End Sub
    Public Sub VertoonLangtermynpolis(ByRef POLISNO As Object, ByRef UitgeloopJN As Object, ByRef Oor2maandeuitgeloopJN As Object, ByRef VertoonEarnedJN As Object)
        Dim Termynmaandbeskrywing As Object
        Dim termyndatum As Object
        Dim totdatnowplus2 As Object
        Dim vanafnowplus2 As Object
        Dim totdattermynmaand As Object
        Dim vanaftermynmaand As Object
        Dim maandeoor As Object
        Dim soekdatum As Object
        Dim j As Object
        Dim l As Object
        Dim k As Object
        Dim VorigemaandEarned As Object
        Dim earned As Object
        Dim telgeldontvang As Object
        Dim BeskrywingLTP As Object
        Dim varterugbetaling As Object
        Dim GeldOntvang As Object
        Dim TermynJaar As Object
        Dim TermynMaand As Object
        Dim i As Object
        Dim VorigetydperkUnearned As Object
        '        Dim introw As Object
        '        Dim rsMakelaarSql As Object
        '        Dim rsAreaBrief As Object
        '        Dim dbPoldata As Object
        Dim reportDate As Object
        '        Dim MDprintdat As Object
        '        'A report template must be in Polis5\docs (report.xls)
        '        Dim sSql As String
        '        'UPGRADE_WARNING: Arrays in structure rsReport may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '        Dim rsReport As DAO.Recordset
        '        'UPGRADE_WARNING: Arrays in structure rs may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '        Dim rs As DAO.Recordset
        '        Dim xlapp As Microsoft.Office.Interop.Excel.Application
        '        Dim xlbook As Microsoft.Office.Interop.Excel.Workbook
        '        Dim xlsheet As Microsoft.Office.Interop.Excel.Worksheet
        '        Dim xlRange As Microsoft.Office.Interop.Excel.Range
        '        Dim blnUserControl As Boolean
        Dim dateStart As Date
        Dim dateEnd As Date
        Dim Months As Byte
        Dim TermDesc As String
        Dim StatusDesc As String
        Dim TermStatus As Byte
        '        Dim stats5 As DAO.Database
        '        Dim stats5d As DAO.Database
        '        Dim poldata5 As DAO.Database
        '        'UPGRADE_WARNING: Arrays in structure Langtermynpolis may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '        Dim Langtermynpolis As DAO.Recordset
        '        'UPGRADE_WARNING: Arrays in structure Mdprint2dat may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '        Dim Mdprint2dat As DAO.Recordset
        '        'UPGRADE_WARNING: Arrays in structure Persoonl may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '        Dim Persoonl As DAO.Recordset
        '        'UPGRADE_WARNING: Arrays in structure rsKontant may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '        Dim rsKontant As DAO.Recordset
        '        stats5 = DAODBEngine_definst.OpenDatabase(pol_path & "\Stats5.mdb")
        '        stats5d = DAODBEngine_definst.OpenDatabase(pol_path & "\Stats5d.mdb")
        '        poldata5 = DAODBEngine_definst.OpenDatabase(pol_path & "\Poldata5.mdb")
        '        Langtermynpolis = stats5.OpenRecordset("Langtermynpolis")

        '        MDprintdat = stats5d.OpenRecordset("Md_print_dat")
        '        UPGRADE_WARNING: Couldn't resolve default property of object MDprintdat.Index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        MDprintdat.Index = "a_index" 'Afsluitdatum, Polisno
        '        Mdprint2dat = stats5d.OpenRecordset("Md_print2_dat")
        '        Mdprint2dat.Index = "a_index" 'Afsluitdatum, Polisno
        '        Persoonl = poldata5.OpenRecordset("Persoonl")
        '        Persoonl.Index = "pn_index"
        '        rsKontant = stats5.OpenRecordset("Kontant")
        '        rsKontant.Index = "Pk2_index"


        UitgeloopJN = "N"
        Oor2maandeuitgeloopJN = "N"
        reportDate = Format(Now, "dd/m/yyyy")
        'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        ''Kyk of hierdie polis 'n aktiewe langtermynpolis is
        'Andriette 09/07/2014 verander die funksie om net die polisnommer as parameter te gebruik en dan die entity te vul met die inligting
        '  gen_getTermPolicyStatus("6", CStr(Persoonl.POLISNO), dateStart, dateEnd, Months, TermDesc, StatusDesc, TermStatus)
        gen_getTermPolicyStatus(Persoonl.POLISNO)
        Me.Status.Text = StatusDesc
        Me.Label20.Text = TermDesc

        '        sSql = "SELECT Langtermynpolis.DatumBegin, Langtermynpolis.DatumEindig, Langtermynpolis.Tydperk, Langtermynpolis.pkLangtermynpolis, Langtermynpolis.polisno from Langtermynpolis where polisno = '" & POLISNO & "'" & " ORDER BY pkLangtermynpolis"
        '        rsReport = stats5.OpenRecordset(sSql)
        'If Not rsreport.NoMatch Then
        '            letterhead_createExcelObject(xlapp, blnUserControl)
        '            xlbook = xlapp.Workbooks.Open(pol_path & "\docs\report.xls")
        '            xlsheet = xlbook.Worksheets(1)

        '            xlapp.DisplayAlerts = False

        '            dbPoldata = DAODBEngine_definst.OpenDatabase(pol_path & "\poldata5.mdb")
        '            'UPGRADE_WARNING: Couldn't resolve default property of object dbPoldata.OpenRecordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            rsAreaBrief = dbPoldata.OpenRecordset("SELECT * FROM area WHERE area_kode = '" & Persoonl.Fields("area").Value & "'")

        '            'UPGRADE_WARNING: Couldn't resolve default property of object rsAreaBrief(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object dbPoldata.OpenRecordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            rsMakelaarSql = dbPoldata.OpenRecordset("SELECT * FROM Makelaar where pkmakelaar = " & rsAreaBrief("fkmakelaar"))
        '            'UPGRADE_WARNING: Couldn't resolve default property of object rsMakelaarSql(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Shapes.AddPicture(getAdminPath & "Logo\" & rsMakelaarSql("Makelaar_logo"), True, True, ExcelGlobal_definst.Cells.Left, ExcelGlobal_definst.Cells.Top, 460, 70)

        '            'Set margins and papersize
        '            With xlsheet.PageSetup
        '                .PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4
        '                .BottomMargin = 40 '0.5
        '                .FooterMargin = 10 '0.25
        '                .LeftMargin = 36 '0.5 inches
        '                .RightMargin = 36
        '                .TopMargin = 54
        '                .HeaderMargin = 36
        '            End With

        '            'Set branch name
        '            xlRange = xlsheet.Range("G5")
        '            xlRange.Font.Bold = True
        '            xlRange.Font.Size = 8
        '            xlRange.HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlRight
        '            xlRange._Default = Form1.Taknaam.Text

        '            'Set date
        '            xlRange = xlsheet.Range("G6")
        '            xlRange.Font.Bold = True
        '            xlRange.Font.Size = 8
        '            xlRange.HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlRight
        '            xlRange._Default = "'" & VB6.Format(Now, "dd/mm/yyyy")

        '            'Set report heading
        '            xlRange = xlsheet.Range("A7")
        '            xlRange.Font.Bold = True
        '            xlRange.Font.Size = 10
        '            'UPGRADE_WARNING: Couldn't resolve default property of object reportDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlRange._Default = "Earned en Unearned syfers vir versekerde " & Form1.VOORL.Text & " " & Form1.VERSEKERDE.Text & "(" & Form1.POLISNO.Text & ") soos op " & VB6.Format(reportDate, "dd/mm/yyyy")

        '            'Set column headings
        '            xlRange = xlsheet.Range("A9:G10")
        '            xlRange.Font.Bold = True
        '            xlRange.Font.Size = 8
        '            xlRange.BorderAround(Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Word.XlBorderWeight.xlThin)

        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(9, "C") = "Geld ontvang/"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(9, "E") = "Unearned"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(9, "F") = "Earned"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(10, "A") = "Maand"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(10, "B") = "Jaar"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(10, "C") = "Terugbetaal"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(10, "D") = "Beskrywing"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(10, "E") = "(Bank)"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(10, "F") = "(Premie verdien)"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(10, "G") = "Maande oor"

        '            xlRange.HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlRight
        '            xlRange.ColumnWidth = 14

        '            xlRange = xlsheet.Range("A10:B10")
        '            xlRange.ColumnWidth = 6

        '            'Set report style
        '            xlRange = xlsheet.Range("A11:I1000")
        '            xlRange.Font.Size = 8

        '            'Stel alignment
        '            xlRange.HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlRight
        '            xlRange.ColumnWidth = 14

        '            xlRange = xlsheet.Range("A9:A1000")
        '            xlRange.HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlLeft

        '            xlRange = xlsheet.Range("D9:D1000")
        '            xlRange.HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlLeft

        '            xlRange = xlsheet.Range("A9:B1000")
        '            xlRange.ColumnWidth = 8

        '            xlRange = xlsheet.Range("C9:G1000")
        '            xlRange.ColumnWidth = 13

        '            xlRange = xlsheet.Range("D9:D1000")
        '            xlRange.ColumnWidth = 20

        '            xlRange = xlsheet.Range("G9:G1000")
        '            xlRange.ColumnWidth = 8


        '            introw = 10
        'Bereken die maande oor vir die langtermynpolis
        VorigetydperkUnearned = 0
        EntLangtermynpolis = New LangtermynPolis
        EntLangtermynpolis = FetchLangtermnDate(Persoonl.POLISNO)
        '            Do While Not rsReport.EOF
        '                'Stel detail op
        'For i = 1 To langtermnypolis.Tydperk
        '    'Bereken Termyn maand en jaar
        '    If i = 1 Then
        '        TermynMaand = Month(langtermnypolis.DatumBegin)
        '        TermynJaar = Year(langtermnypolis.DatumBegin)
        '    Else
        '        TermynMaand = TermynMaand + 1
        '        If TermynMaand > 12 Then
        '            TermynJaar = TermynJaar + 1
        '    '            TermynMaand = 1
        'End If
        '        End If
        'Bereken Geld ontvang vir hierdie maand en jaar
        GeldOntvang = 0
        varterugbetaling = 0
        BeskrywingLTP = ""
        telgeldontvang = 0
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                               New SqlParameter("@Jaar", SqlDbType.SmallInt), _
                                               New SqlParameter("@Maand", SqlDbType.SmallInt)}

                param(0).Value = Persoonl.POLISNO
                param(1).Value = TermynJaar
                param(2).Value = TermynMaand
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchKontantbytipe", param)
                Do While reader.Read
                    If reader("tipe").Value = "TB" Then
                        varterugbetaling = varterugbetaling + reader("vord_premie").Value

                        If BeskrywingLTP = "" Then
                            BeskrywingLTP = "Terugbetaling"
                        Else
                            BeskrywingLTP = Trim(BeskrywingLTP) & "," & "Terugbetaling"
                        End If
                    Else

                        GeldOntvang = GeldOntvang + reader("vord_premie").Value

                        telgeldontvang = telgeldontvang + 1


                        If BeskrywingLTP = "" Then

                            BeskrywingLTP = reader("LTPtipe").Value
                        Else

                            BeskrywingLTP = Trim(BeskrywingLTP) & "," + reader("LTPtipe").Value
                        End If
                    End If
                Loop
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'GeldOntvang = System.Math.Round(GeldOntvang, 2)

        'GeldOntvang = GeldOntvang - varterugbetaling

        ''Earned
        ''Kyk of daar 'n stats5d rekord bestaan vir termyn maand?

        'VorigemaandEarned = earned
        'earned = 0
        ''Kyk of vandag se maand ooreenstem met Langtermynpolis begindatum

        'k = TermynMaand - 1

        'l = TermynJaar

        'If k = 0 Then

        '    k = 12

        '    l = TermynJaar - 1
        'End If

        'For j = 1 To 31

        '    soekdatum = Format(j, "00") & "/" & Format(k, "00") & "/" & Format(l, "00")


        '    'Soek vorige maand se afsluitdatum data
        '    ' Mdprint2dat.Seek("=", soekdatum, rsreport.Fields("Polisno"))
        '    If Not Mdprint2dat.Nomatch Then

        'Select only 'Term' betaalwyses

        '     MDprintdat.Seek("=", soekdatum, rsreport.Fields("Polisno"))

        '        If Not MDprintdat.Nomatch Then
        '            Do While Mdprint2dat.Afsluit_dat = soekdatum And Mdprint2dat.Polisno = rsreport.Polisno
        '                If Mdprint2dat.bet_wyse = "LT" Then

        '                    earned = Mdprint2dat.Premie2

        '                    j = 32
        '                End If

        '                ' Mdprint2dat.MoveNext()
        '            Loop

        '        End If

        '    End If
        'Next j


        'earned = System.Math.Round(earned, 2)

        ''Unearned

        'If i = 1 Then

        '    UnEarned = GeldOntvang + UnEarned
        'Else

        '    UnEarned = UnEarned + GeldOntvang - VorigemaandEarned
        'End If

        'UnEarned = System.Math.Round(UnEarned, 2)

        ''Maande oor

        'If i = 1 Then

        '    maandeoor = langtermnypolis.Tydperk
        'Else

        '    maandeoor = langtermnypolis.Tydperk - i + 1
        'End If

        'Is hierdie polis uitgeloop?

        vanaftermynmaand = "01" & "/" & Format(TermynMaand, "00") & "/" & Format(TermynJaar, "0000")

        totdattermynmaand = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, vanaftermynmaand)

        totdattermynmaand = DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, totdattermynmaand)

        If DateDiff(Microsoft.VisualBasic.DateInterval.Day, CDate(Format(Now, "dd/mm/yyyy")), vanaftermynmaand) <= 0 And DateDiff(Microsoft.VisualBasic.DateInterval.Day, CDate(Format(Now, "dd/mm/yyyy")), totdattermynmaand) >= 0 Then

            If UnEarned - earned <= 0 Then

            End If
        End If
        'Is hierdie polis oor 2 maande uitgeloop?
        vanafnowplus2 = "01" & "/" & Format(Month(Now), "00") & "/" & Format(Year(Now), "0000")

        vanafnowplus2 = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 2, vanafnowplus2)

        totdatnowplus2 = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, vanafnowplus2)

        totdatnowplus2 = DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, totdatnowplus2)

        termyndatum = "01" & "/" & Format(TermynMaand, "00") & "/" & Format(TermynJaar, "0000")

        If DateDiff(Microsoft.VisualBasic.DateInterval.Day, termyndatum, vanafnowplus2) <= 0 And DateDiff(Microsoft.VisualBasic.DateInterval.Day, termyndatum, totdatnowplus2) >= 0 Then

            If UnEarned - earned <= 0 Then

                Oor2maandeuitgeloopJN = "J"
            End If
        End If

        'Detail

        ' introw = introw + 1

        'Select Case TermynMaand
        '    Case 1
        '        Termynmaandbeskrywing = "Januarie"
        '    Case 2
        '        Termynmaandbeskrywing = "Februarie"
        '    Case 3
        '        Termynmaandbeskrywing = "Maart"
        '    Case 4
        '        Termynmaandbeskrywing = "April"
        '    Case 5
        '        Termynmaandbeskrywing = "Mei"
        '    Case 6
        '        Termynmaandbeskrywing = "Junie"
        '    Case 7
        '        Termynmaandbeskrywing = "Julie"
        '    Case 8
        '        Termynmaandbeskrywing = "Augustus"
        '    Case 9
        '        Termynmaandbeskrywing = "September"
        '    Case 10
        '        Termynmaandbeskrywing = "Oktober"
        '    Case 11
        '        Termynmaandbeskrywing = "November"
        '    Case 12
        '        Termynmaandbeskrywing = "Desember"
        'End Select
        '                    xlsheet.Cells._Default(introw, "A") = Termynmaandbeskrywing
        '                    xlsheet.Cells._Default(introw, "B") = TermynJaar
        '                    xlsheet.Cells._Default(introw, "C") = "'" & VB6.Format(GeldOntvang, "#########0.00")
        '                    'UPGRADE_WARNING: Couldn't resolve default property of object BeskrywingLTP. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                    xlsheet.Cells._Default(introw, "D") = BeskrywingLTP
        '                    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                    xlsheet.Cells._Default(introw, "E") = "'" & VB6.Format(UnEarned, "#########0.00")
        '                    'UPGRADE_WARNING: Couldn't resolve default property of object earned. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                    xlsheet.Cells._Default(introw, "F") = "'" & VB6.Format(earned, "#########0.00")
        '                    'UPGRADE_WARNING: Couldn't resolve default property of object maandeoor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                    xlsheet.Cells._Default(introw, "G") = maandeoor

        'Next i
        'UnEarned = UnEarned - earned
        'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        ''            'Preview report
        ''            xlapp.Visible = True

        ''            'Moet hierdie berekenings vertoon word?

        'If VertoonEarnedJN = "J" Then
        '                xlsheet.PrintPreview()
        '                   call report
        '    End If

        '    '            xlbook.Close()
        '    '            xlapp.Quit()
        'Else
        '    MsgBox("There is no term policy information not found", MsgBoxStyle.Information)
        'End If

        '                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        '                Exit Sub
        'errorhandler:
        '                If Err.Number = 1004 Then
        '                    MsgBox("The report template (" & pol_path & "\docs\report.xls) could not be found, please contact Mooirivier Rekenaars.", MsgBoxStyle.Exclamation)
        '                Else
        '                    Err.Raise(Err.Number)
        '                End If
        '                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Wysiging_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Wysiging.CheckStateChanged

        If Me.Wysiging.CheckState = 1 Then
            Me.Nuwepolis.CheckState = System.Windows.Forms.CheckState.Unchecked
            Me.Hernuwing.CheckState = System.Windows.Forms.CheckState.Unchecked
        End If

    End Sub

    '* Purpose:       Set the appropriate recordset for this monthly salary area
    Public Function Set_MonthlySalaryRecordset() As Object
        Dim i As Integer
        'Dim stats5 As DAO.Database
        'stats5 = DAODBEngine_definst.OpenDatabase(pol_path & "\Stats5.mdb")

        Select Case Persoonl.Area
            Case "2"
                m_salaris3 = Fetch_Maand_Puk_For_Salaries(Persoonl.POLISNO)
                'm_salaris = stats5.OpenRecordset("maand_puk")
        End Select

    End Function
    Public Sub InsertIntoKontant()
        Using conn As SqlConnection = SqlHelper.GetConnection
            'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
            Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                           New SqlParameter("@vord_dat", SqlDbType.DateTime), _
                                           New SqlParameter("@vord_premie", SqlDbType.Money), _
                                           New SqlParameter("@trans_dat", SqlDbType.DateTime), _
                                           New SqlParameter("@kwitansie", SqlDbType.NVarChar), _
                                           New SqlParameter("@verw1", SqlDbType.NVarChar), _
                                           New SqlParameter("@verw2", SqlDbType.NVarChar), _
                                           New SqlParameter("@verw3", SqlDbType.NVarChar), _
                                           New SqlParameter("@verw4", SqlDbType.NVarChar), _
                                           New SqlParameter("@verw5", SqlDbType.NVarChar), _
                                           New SqlParameter("@gekans", SqlDbType.Bit), _
                                           New SqlParameter("@tipe", SqlDbType.NVarChar), _
                                           New SqlParameter("@kontant_tipe", SqlDbType.NVarChar), _
                                           New SqlParameter("@nuwe_tjekno", SqlDbType.NVarChar), _
                                           New SqlParameter("@tjekno_uit", SqlDbType.NVarChar), _
                                           New SqlParameter("@tjekno_in", SqlDbType.NVarChar), _
                                           New SqlParameter("@EISNO", SqlDbType.NVarChar), _
                                           New SqlParameter("@TJEKDATUM", SqlDbType.DateTime), _
                                           New SqlParameter("@TJEKBESONDERHEDE", SqlDbType.NVarChar), _
                                           New SqlParameter("@kwit_boek", SqlDbType.NVarChar), _
                                           New SqlParameter("@LTPtipe", SqlDbType.NVarChar)}
            param(0).Value = Form1.POLISNO.Text
            param(1).Value = Format(Now, "dd/mm/yyyy")
            param(2).Value = Me.nou_ingevorder.Text
            param(3).Value = kwit_boek.Text

            If IsDBNull(Me.verw1.Text) Then
                Me.verw1.Text = " "
            End If

            If IsDBNull(Me.verw2.Text) Then
                Me.verw2.Text = " "
            End If

            If IsDBNull(Me.verw3.Text) Then
                Me.verw3.Text = " "
            End If

            If IsDBNull(Me.verw4.Text) Then
                Me.verw4.Text = " "
            End If

            If IsDBNull(Me.verw5.Text) Then
                Me.verw5.Text = " "
            End If

            param(4).Value = Me.verw1.Text
            param(5).Value = Me.verw2.Text
            param(6).Value = Me.verw3.Text
            param(7).Value = Me.verw4.Text
            param(8).Value = Me.verw5.Text
            param(9).Value = Format(Now, "dd/mm/yyyy hh:mm:ss AM/PM")
            param(10).Value = False
            param(11).Value = " "
            param(12).Value = kontant_tipe
            param(13).Value = tipe_ontv

            If Me.Tjek.Checked <> 0 Then
                If terugbetaling.CheckState Or check_tj Then
                    param(14).Value = Tjekno.Text
                Else
                    param(15).Value = Tjekno.Text
                End If
            End If

            param(16).Value = " "

            If Me.Tjek.Checked Then
                param(17).Value = Tjekdatum.Text
                param(18).Value = Tjekbesonderhede.Text
            End If

            param(19).Value = kwit_boek.Text
            param(20).Value = " "
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.InsertIntoKontant", param)

        End Using

    End Sub


    Sub GetMaandDEBIT()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@MaandDebitisTransDate", SqlDbType.DateTime), _
                                                New SqlParameter("@Vord_Premie", SqlDbType.Money), _
                                                New SqlParameter("@verw1", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw2", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw3", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw4", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw5", SqlDbType.NVarChar), _
                                                New SqlParameter("@kontant_tipe", SqlDbType.NVarChar), _
                                                New SqlParameter("@tjekno_uit", SqlDbType.NVarChar), _
                                                New SqlParameter("@tjekno_in", SqlDbType.NVarChar), _
                                                New SqlParameter("@TJEKDATUM", SqlDbType.DateTime), _
                                                New SqlParameter("@TJEKBESONDERHEDE", SqlDbType.NVarChar), _
                                                New SqlParameter("@kwit_boek", SqlDbType.NVarChar), _
                                                New SqlParameter("@Area", SqlDbType.NVarChar), _
                                                New SqlParameter("@CurrentDate", SqlDbType.DateTime), _
                                                New SqlParameter("@tipe_ontv", SqlDbType.NVarChar)}


                params(0).Value = Persoonl.POLISNO
                params(1).Value = DataGridView1.SelectedRows(0).Cells(6).Value
                params(2).Value = Me.nou_ingevorder.Text

                If IsDBNull(Me.verw1.Text) Then
                    Me.verw1.Text = " "
                End If
                If IsDBNull(Me.verw2.Text) Then
                    Me.verw2.Text = " "
                End If
                If IsDBNull(Me.verw3.Text) Then
                    Me.verw3.Text = " "
                End If
                If IsDBNull(Me.verw4.Text) Then
                    Me.verw4.Text = " "
                End If
                If IsDBNull(Me.verw5.Text) Then
                    Me.verw5.Text = " "
                End If

                params(3).Value = Me.verw1.Text
                params(4).Value = Me.verw2.Text
                params(5).Value = Me.verw3.Text
                params(6).Value = Me.verw4.Text
                params(7).Value = Me.verw5.Text
                params(8).Value = kontant_tipe

                If Me.Tjek.Checked <> 0 Then
                    If terugbetaling.Checked Or check_tj Then
                        params(9).Value = Tjekno.Text
                        params(10).Value = DBNull.Value
                    Else
                        params(9).Value = DBNull.Value
                        params(10).Value = Tjekno.Text
                    End If
                Else
                    params(9).Value = DBNull.Value
                    params(10).Value = DBNull.Value
                End If

                If Me.Tjek.Checked Then
                    params(11).Value = Tjekdatum.Text
                    params(12).Value = Tjekbesonderhede.Text
                Else
                    params(11).Value = DBNull.Value
                    params(12).Value = DBNull.Value
                End If

                params(13).Value = kwit_boek.Text
                params(14).Value = Persoonl.Area
                params(15).Value = Format(Now, "dd/MM/yyyy HH:mm")
                params(16).Value = tipe_ontv

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[stats5].[UpdateKontantAndMaandDebit]", params)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub
    Sub GetMaandElektronies()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@MaandElektroniesTransDate", SqlDbType.DateTime), _
                                                New SqlParameter("@Vord_Premie", SqlDbType.Money), _
                                                New SqlParameter("@verw1", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw2", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw3", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw4", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw5", SqlDbType.NVarChar), _
                                                New SqlParameter("@kontant_tipe", SqlDbType.NVarChar), _
                                                New SqlParameter("@tjekno_uit", SqlDbType.NVarChar), _
                                                New SqlParameter("@tjekno_in", SqlDbType.NVarChar), _
                                                New SqlParameter("@TJEKDATUM", SqlDbType.DateTime), _
                                                New SqlParameter("@TJEKBESONDERHEDE", SqlDbType.NVarChar), _
                                                New SqlParameter("@kwit_boek", SqlDbType.NVarChar), _
                                                New SqlParameter("@Area", SqlDbType.NVarChar), _
                                                New SqlParameter("@CurrentDate", SqlDbType.DateTime), _
                                                New SqlParameter("@tipe_ontv", SqlDbType.NVarChar)}


                params(0).Value = Persoonl.POLISNO
                params(1).Value = DataGridView1.SelectedRows(0).Cells(5).Value
                params(2).Value = Me.nou_ingevorder.Text

                If IsDBNull(Me.verw1.Text) Then
                    Me.verw1.Text = " "
                End If
                If IsDBNull(Me.verw2.Text) Then
                    Me.verw2.Text = " "
                End If
                If IsDBNull(Me.verw3.Text) Then
                    Me.verw3.Text = " "
                End If
                If IsDBNull(Me.verw4.Text) Then
                    Me.verw4.Text = " "
                End If
                If IsDBNull(Me.verw5.Text) Then
                    Me.verw5.Text = " "
                End If
                params(3).Value = Me.verw1.Text
                params(4).Value = Me.verw2.Text
                params(5).Value = Me.verw3.Text
                params(6).Value = Me.verw4.Text
                params(7).Value = Me.verw5.Text
                params(8).Value = kontant_tipe

                If Me.Tjek.Checked <> 0 Then
                    If terugbetaling.Checked Or check_tj Then
                        params(9).Value = Tjekno.Text
                        params(10).Value = DBNull.Value
                    Else
                        params(9).Value = DBNull.Value
                        params(10).Value = Tjekno.Text
                    End If
                Else
                    params(9).Value = DBNull.Value
                    params(10).Value = DBNull.Value
                End If

                If Me.Tjek.Checked Then
                    params(11).Value = Tjekdatum.Text
                    params(12).Value = Tjekbesonderhede.Text
                Else
                    params(11).Value = DBNull.Value
                    params(12).Value = DBNull.Value
                End If

                params(13).Value = kwit_boek.Text
                params(14).Value = Persoonl.Area
                params(15).Value = Format(Now, "dd/MM/yyyy HH:mm")
                params(16).Value = tipe_ontv

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Stats5.UpdateKontantAndMaandElektronies", params)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub
    Sub PopulateGridWithMaandElectronies()
        DataGridView1.Rows.Clear()
        ' DataGridView1.Rows.Add((Format(m_kontant.Afsluit_dat) & Chr(9) & CStr(m_kontant.Premie) & Chr(9) + grid_nou_ingevorder + Chr(9) + grid_kwitansie + Chr(9) + grid_vord_dat + Chr(9) + grid_trans_dat), row_tel)
        row_tel = 0
        row_tel = row_tel + 1
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.Refresh()
        DataGridView1.DataSource = Nothing
        DataGridView1.ColumnCount = 8
        DataGridView1.ColumnHeadersVisible = True

        DataGridView1.Columns(0).Name = "ME Datum"
        DataGridView1.Columns(1).Name = "Amount"
        DataGridView1.Columns(2).Name = "Collection"
        DataGridView1.Columns(3).Name = "Receipt/Cheque number"
        DataGridView1.Columns(4).Name = "Collection Date"
        DataGridView1.Columns(5).Name = "Transaction Date"
        DataGridView1.Columns(6).Name = "T/K/E"
        DataGridView1.Columns(7).Name = "PaymentType"

        Try
            DataGridView1.Rows.Clear()
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                            New SqlParameter("@Jaar", SqlDbType.SmallInt), _
                                            New SqlParameter("@Maand", SqlDbType.SmallInt)}
                param(0).Value = Persoonl.POLISNO
                param(1).Value = jaar_van.Text
                param(2).Value = maand_van.Text

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchGridMaandElektronies", param)

                While reader.Read()
                    DataGridView1.Rows.Insert(0, reader("ME Datum"), reader("Amount"), reader("Collection"), reader("Receipt/Cheque number"), reader("Collection Date"), reader("Transaction Date"), reader("Kontant Tipe"), row_tel)
                End While
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        ' uitstaande.Text = uitstaande.Text + m_kontant.Premie
        ' Ctr = Ctr + 1

    End Sub
    Sub GetTermPolicy()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@Afsluit_dat", SqlDbType.DateTime), _
                                                New SqlParameter("@Trans_dat", SqlDbType.DateTime), _
                                                New SqlParameter("@gg_trans_dat", SqlDbType.DateTime), _
                                                New SqlParameter("@Vord_Dat", SqlDbType.DateTime), _
                                                New SqlParameter("@Premie", SqlDbType.Money), _
                                                New SqlParameter("@ingevorder", SqlDbType.Money), _
                                                New SqlParameter("@Vord_Premie", SqlDbType.Money), _
                                                New SqlParameter("@Jaar", SqlDbType.Float), _
                                                New SqlParameter("@Maand", SqlDbType.Float), _
                                                New SqlParameter("@verw1", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw2", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw3", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw4", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw5", SqlDbType.NVarChar), _
                                                New SqlParameter("@kontant_tipe", SqlDbType.NVarChar), _
                                                New SqlParameter("@Betaalwyse", SqlDbType.NVarChar), _
                                                New SqlParameter("@tipe_trans", SqlDbType.NVarChar), _
                                                New SqlParameter("@eb_vb_tb", SqlDbType.NVarChar), _
                                                New SqlParameter("@tjekno_uit", SqlDbType.NVarChar), _
                                                New SqlParameter("@tjekno_in", SqlDbType.NVarChar), _
                                                New SqlParameter("@TJEKDATUM", SqlDbType.DateTime), _
                                                New SqlParameter("@TJEKBESONDERHEDE", SqlDbType.NVarChar), _
                                                New SqlParameter("@kwit_boek", SqlDbType.NVarChar), _
                                                New SqlParameter("@Area", SqlDbType.NVarChar), _
                                                New SqlParameter("@LTPtipe", SqlDbType.NVarChar), _
                                                New SqlParameter("@pkLangtermynPolis", SqlDbType.Int), _
                                                New SqlParameter("@tipe_ontv", SqlDbType.NVarChar)}


                params(0).Value = Persoonl.POLISNO
                params(1).Value = CDate(vb_afdat)
                params(2).Value = Now
                params(3).Value = Now
                params(4).Value = Now
                params(5).Value = Val(nou_ingevorder.Text)
                params(6).Value = ing
                params(7).Value = ing
                params(8).Value = Year(vb_afdat)
                params(9).Value = Month(vb_afdat)
                If IsDBNull(Me.verw1.Text) Then
                    Me.verw1.Text = " "
                End If
                If IsDBNull(Me.verw2.Text) Then
                    Me.verw2.Text = " "
                End If
                If IsDBNull(Me.verw3.Text) Then
                    Me.verw3.Text = " "
                End If
                If IsDBNull(Me.verw4.Text) Then
                    Me.verw4.Text = " "
                End If
                If IsDBNull(Me.verw5.Text) Then
                    Me.verw5.Text = " "
                End If

                params(10).Value = Me.verw1.Text
                params(11).Value = Me.verw2.Text
                params(12).Value = Me.verw3.Text
                params(13).Value = Me.verw4.Text
                params(14).Value = Me.verw5.Text
                params(15).Value = kontant_tipe
                params(16).Value = Persoonl.BET_WYSE

                If Me.Tjek.Checked = True Then
                    params(17).Value = "T"
                Else
                    If Me.Kont.Checked = True Then
                        params(17).Value = "K"

                    Else
                        If Me.Elektronies.Checked = True Then
                            params(17).Value = "E"
                        End If
                    End If

                End If

                If Me.Langtermynpolis.CheckState = 1 Then
                    params(18).Value = "LT"
                Else
                    params(18).Value = DBNull.Value
                End If

                If Me.Tjek.Checked <> 0 Then
                    If terugbetaling.CheckState Or check_tj Then
                        params(19).Value = Tjekno.Text
                    Else
                        params(20).Value = Tjekno.Text
                    End If
                Else
                    params(19).Value = DBNull.Value
                    params(20).Value = DBNull.Value
                End If
                If Me.Tjek.Checked Then
                    If eerstebetaling.CheckState Or Vooruitbetaling.CheckState Or check_tj Then

                        params(20).Value = Tjekno.Text
                    Else
                        params(19).Value = Tjekno.Text
                    End If
                Else
                    params(19).Value = DBNull.Value
                    params(20).Value = DBNull.Value
                End If

                If Me.Tjek.Checked Then
                    params(21).Value = Tjekdatum.Text
                    params(22).Value = Tjekbesonderhede.Text
                Else
                    params(21).Value = DBNull.Value
                    params(22).Value = DBNull.Value
                End If
                params(23).Value = kwit_boek.Text
                params(24).Value = Persoonl.Area

                If Me.Nuwepolis.CheckState = 1 Then
                    params(25).Value = "Nuwe polis"
                ElseIf Me.Hernuwing.CheckState = 1 Then
                    params(25).Value = "Hernuwing"
                ElseIf Me.Wysiging.CheckState = 1 Then
                    params(25).Value = "Wysiging"
                End If
                If pkLangtermynPolis = 0 Or IsDBNull(pkLangtermynPolis) Then
                    params(26).Value = 0
                Else
                    params(26).Value = pkLangtermynPolis
                End If
                params(27).Value = tipe_ontv

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Stats5.InsertIntoKontantGegenereer", params)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub

    Sub GetTypeOfPayment()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@Afsluit_dat", SqlDbType.DateTime), _
                                                New SqlParameter("@Trans_dat", SqlDbType.DateTime), _
                                                New SqlParameter("@gg_trans_dat", SqlDbType.DateTime), _
                                                New SqlParameter("@Vord_Dat", SqlDbType.DateTime), _
                                                New SqlParameter("@Premie", SqlDbType.Float), _
                                                New SqlParameter("@ingevorder", SqlDbType.Float), _
                                                New SqlParameter("@Vord_Premie", SqlDbType.Float), _
                                                New SqlParameter("@Jaar", SqlDbType.Float), _
                                                New SqlParameter("@Maand", SqlDbType.Float), _
                                                New SqlParameter("@verw1", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw2", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw3", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw4", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw5", SqlDbType.NVarChar), _
                                                New SqlParameter("@kontant_tipe", SqlDbType.NVarChar), _
                                                New SqlParameter("@Betaalwyse", SqlDbType.NVarChar), _
                                                New SqlParameter("@tipe_trans", SqlDbType.NVarChar), _
                                                New SqlParameter("@eb_vb_tb", SqlDbType.NVarChar), _
                                                New SqlParameter("@tjekno_uit", SqlDbType.NVarChar), _
                                                New SqlParameter("@tjekno_in", SqlDbType.NVarChar), _
                                                New SqlParameter("@TJEKDATUM", SqlDbType.DateTime), _
                                                New SqlParameter("@TJEKBESONDERHEDE", SqlDbType.NVarChar), _
                                                New SqlParameter("@kwit_boek", SqlDbType.NVarChar), _
                                                New SqlParameter("@Area", SqlDbType.NVarChar), _
                                                New SqlParameter("@LTPtipe", SqlDbType.NVarChar), _
                                                New SqlParameter("@pkLangtermynPolis", SqlDbType.Int), _
                                                New SqlParameter("@tipe_ontv", SqlDbType.NVarChar)}


                params(0).Value = Persoonl.POLISNO
                params(1).Value = CDate(vb_afdat)
                params(2).Value = Now
                params(3).Value = Now
                params(4).Value = Now
                params(5).Value = Val(nou_ingevorder.Text)
                params(6).Value = ing
                params(7).Value = ing
                params(8).Value = jaar4
                params(9).Value = vb_maand
                If IsDBNull(Me.verw1.Text) Then
                    Me.verw1.Text = " "
                End If
                If IsDBNull(Me.verw2.Text) Then
                    Me.verw2.Text = " "
                End If
                If IsDBNull(Me.verw3.Text) Then
                    Me.verw3.Text = " "
                End If
                If IsDBNull(Me.verw4.Text) Then
                    Me.verw4.Text = " "
                End If
                If IsDBNull(Me.verw5.Text) Then
                    Me.verw5.Text = " "
                End If

                params(10).Value = Me.verw1.Text
                params(11).Value = Me.verw2.Text
                params(12).Value = Me.verw3.Text
                params(13).Value = Me.verw4.Text
                params(14).Value = Me.verw5.Text
                params(15).Value = kontant_tipe
                params(16).Value = Persoonl.BET_WYSE

                If Me.Tjek.Checked = True Then
                    params(17).Value = "T"
                Else
                    If Me.Kont.Checked = True Then
                        params(17).Value = "K"

                    Else
                        If Me.Elektronies.Checked = True Then
                            params(17).Value = "E"
                        End If
                    End If

                End If

                If Me.eerstebetaling.CheckState = 1 Then
                    params(18).Value = "EB"
                Else
                    If Me.Vooruitbetaling.CheckState = 1 Then
                        params(18).Value = "VB"

                    Else
                        If Me.terugbetaling.CheckState = 1 Then
                            params(18).Value = "TB"
                        Else
                            If Me.Check_jk.CheckState = 1 Then
                                params(18).Value = "JK"
                            End If

                        End If
                    End If
                End If


                If Me.Tjek.Checked <> 0 Then
                    If terugbetaling.CheckState Or check_tj Then
                        params(19).Value = Tjekno.Text
                    Else
                        params(20).Value = Tjekno.Text
                    End If
                Else
                    params(19).Value = DBNull.Value
                    params(20).Value = DBNull.Value
                End If
                If Me.Tjek.Checked Then
                    If eerstebetaling.CheckState Or Vooruitbetaling.CheckState Or check_tj Then

                        params(20).Value = Tjekno.Text
                    Else
                        params(19).Value = Tjekno.Text
                    End If
                Else
                    params(19).Value = DBNull.Value
                    params(20).Value = DBNull.Value
                End If


                If Me.Tjek.Checked Then
                    params(21).Value = CDate(Tjekdatum.Text)
                    params(22).Value = Tjekbesonderhede.Text
                Else
                    params(21).Value = DBNull.Value
                    params(22).Value = DBNull.Value
                End If
                params(23).Value = kwit_boek.Text
                params(24).Value = Persoonl.Area

                params(25).Value = ""

                If pkLangtermynPolis = 0 Or IsDBNull(pkLangtermynPolis) Then
                    params(26).Value = 0
                Else
                    params(26).Value = pkLangtermynPolis
                End If

                params(27).Value = tipe_ontv


                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Stats5.InsertIntoKontantGegenereer", params)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub

    Sub UpdateVTBalans()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@BAL", SqlDbType.Money)}

                ing = CDbl(Format(Val(nou_ingevorder.Text))) + 0.005
                ing = ing * 100
                ing = Int(CDbl(ing))

                ing = ing / 100
                params(0).Value = Persoonl.POLISNO
                params(1).Value = params(1).Value - ing

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.UpdateVT_BALANS", params)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub



    Sub UpdateKontantAndMaand_PukForSalarisAndGrid()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@MaandSalariesTransDate", SqlDbType.DateTime), _
                                                New SqlParameter("@Vord_Premie", SqlDbType.Money), _
                                                New SqlParameter("@verw1", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw2", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw3", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw4", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw5", SqlDbType.NVarChar), _
                                                New SqlParameter("@kontant_tipe", SqlDbType.NVarChar), _
                                                New SqlParameter("@tjekno_uit", SqlDbType.NVarChar), _
                                                New SqlParameter("@tjekno_in", SqlDbType.NVarChar), _
                                                New SqlParameter("@TJEKDATUM", SqlDbType.DateTime), _
                                                New SqlParameter("@TJEKBESONDERHEDE", SqlDbType.NVarChar), _
                                                New SqlParameter("@kwit_boek", SqlDbType.NVarChar), _
                                                New SqlParameter("@Area", SqlDbType.NVarChar), _
                                                New SqlParameter("@CurrentDate", SqlDbType.DateTime), _
                                                New SqlParameter("@tipe_ontv", SqlDbType.NVarChar)}


                params(0).Value = Persoonl.POLISNO
                params(1).Value = DataGridView1.SelectedRows(0).Cells(5).Value
                params(2).Value = Me.nou_ingevorder.Text

                If IsDBNull(Me.verw1.Text) Then
                    Me.verw1.Text = " "
                End If
                If IsDBNull(Me.verw2.Text) Then
                    Me.verw2.Text = " "
                End If
                If IsDBNull(Me.verw3.Text) Then
                    Me.verw3.Text = " "
                End If
                If IsDBNull(Me.verw4.Text) Then
                    Me.verw4.Text = " "
                End If
                If IsDBNull(Me.verw5.Text) Then
                    Me.verw5.Text = " "
                End If

                params(3).Value = Me.verw1.Text
                params(4).Value = Me.verw2.Text
                params(5).Value = Me.verw3.Text
                params(6).Value = Me.verw4.Text
                params(7).Value = Me.verw5.Text
                params(8).Value = kontant_tipe

                If Me.Tjek.Checked <> 0 Then
                    If terugbetaling.Checked Or check_tj Then
                        params(9).Value = Tjekno.Text
                        params(10).Value = DBNull.Value
                    Else
                        params(9).Value = DBNull.Value
                        params(10).Value = Tjekno.Text
                    End If
                Else
                    params(9).Value = DBNull.Value
                    params(10).Value = DBNull.Value
                End If

                If Me.Tjek.Checked Then
                    params(11).Value = Tjekdatum.Text
                    params(12).Value = Tjekbesonderhede.Text
                Else
                    params(11).Value = DBNull.Value
                    params(12).Value = DBNull.Value
                End If

                params(13).Value = kwit_boek.Text
                params(14).Value = Persoonl.Area
                params(15).Value = Format(Now, "dd/MM/yyyy HH:mm")
                params(16).Value = tipe_ontv

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[stats5].[UpdateKontantAndMaandPukForSalaries]", params)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub

    Sub UpdateKontantAndMaand_GtbfnForSalarisAndGrid()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@MaandSalariesTransDate", SqlDbType.DateTime), _
                                                New SqlParameter("@Vord_Premie", SqlDbType.Money), _
                                                New SqlParameter("@verw1", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw2", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw3", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw4", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw5", SqlDbType.NVarChar), _
                                                New SqlParameter("@kontant_tipe", SqlDbType.NVarChar), _
                                                New SqlParameter("@tjekno_uit", SqlDbType.NVarChar), _
                                                New SqlParameter("@tjekno_in", SqlDbType.NVarChar), _
                                                New SqlParameter("@TJEKDATUM", SqlDbType.DateTime), _
                                                New SqlParameter("@TJEKBESONDERHEDE", SqlDbType.NVarChar), _
                                                New SqlParameter("@kwit_boek", SqlDbType.NVarChar), _
                                                New SqlParameter("@Area", SqlDbType.NVarChar), _
                                                New SqlParameter("@CurrentDate", SqlDbType.DateTime), _
                                                New SqlParameter("@tipe_ontv", SqlDbType.NVarChar)}


                params(0).Value = Persoonl.POLISNO
                params(1).Value = DataGridView1.SelectedRows(0).Cells(5).Value
                params(2).Value = Me.nou_ingevorder.Text

                If IsDBNull(Me.verw1.Text) Then
                    Me.verw1.Text = " "
                End If
                If IsDBNull(Me.verw2.Text) Then
                    Me.verw2.Text = " "
                End If
                If IsDBNull(Me.verw3.Text) Then
                    Me.verw3.Text = " "
                End If
                If IsDBNull(Me.verw4.Text) Then
                    Me.verw4.Text = " "
                End If
                If IsDBNull(Me.verw5.Text) Then
                    Me.verw5.Text = " "
                End If

                params(3).Value = Me.verw1.Text
                params(4).Value = Me.verw2.Text
                params(5).Value = Me.verw3.Text
                params(6).Value = Me.verw4.Text
                params(7).Value = Me.verw5.Text
                params(8).Value = kontant_tipe

                If Me.Tjek.Checked <> 0 Then
                    If terugbetaling.Checked Or check_tj Then
                        params(9).Value = Tjekno.Text
                        params(10).Value = DBNull.Value
                    Else
                        params(9).Value = DBNull.Value
                        params(10).Value = Tjekno.Text
                    End If
                Else
                    params(9).Value = DBNull.Value
                    params(10).Value = DBNull.Value
                End If

                If Me.Tjek.Checked Then
                    params(11).Value = Tjekdatum.Text
                    params(12).Value = Tjekbesonderhede.Text
                Else
                    params(11).Value = DBNull.Value
                    params(12).Value = DBNull.Value
                End If

                params(13).Value = kwit_boek.Text
                params(14).Value = Persoonl.Area
                params(15).Value = Format(Now, "dd/MM/yyyy HH:mm")
                params(16).Value = tipe_ontv

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[stats5].[UpdateKontantAndMaandGtbnForSalaries]", params)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub
    Sub UpdateKontantAndMaand_UovsForSalarisAndGrid()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@MaandSalariesTransDate", SqlDbType.DateTime), _
                                                New SqlParameter("@Vord_Premie", SqlDbType.Money), _
                                                New SqlParameter("@verw1", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw2", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw3", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw4", SqlDbType.NVarChar), _
                                                New SqlParameter("@verw5", SqlDbType.NVarChar), _
                                                New SqlParameter("@kontant_tipe", SqlDbType.NVarChar), _
                                                New SqlParameter("@tjekno_uit", SqlDbType.NVarChar), _
                                                New SqlParameter("@tjekno_in", SqlDbType.NVarChar), _
                                                New SqlParameter("@TJEKDATUM", SqlDbType.DateTime), _
                                                New SqlParameter("@TJEKBESONDERHEDE", SqlDbType.NVarChar), _
                                                New SqlParameter("@kwit_boek", SqlDbType.NVarChar), _
                                                New SqlParameter("@Area", SqlDbType.NVarChar), _
                                                New SqlParameter("@CurrentDate", SqlDbType.DateTime), _
                                                New SqlParameter("@tipe_ontv", SqlDbType.NVarChar)}


                params(0).Value = Persoonl.POLISNO
                params(1).Value = DataGridView1.SelectedRows(0).Cells(5).Value
                params(2).Value = Me.nou_ingevorder.Text

                If IsDBNull(Me.verw1.Text) Then
                    Me.verw1.Text = " "
                End If
                If IsDBNull(Me.verw2.Text) Then
                    Me.verw2.Text = " "
                End If
                If IsDBNull(Me.verw3.Text) Then
                    Me.verw3.Text = " "
                End If
                If IsDBNull(Me.verw4.Text) Then
                    Me.verw4.Text = " "
                End If
                If IsDBNull(Me.verw5.Text) Then
                    Me.verw5.Text = " "
                End If

                params(3).Value = Me.verw1.Text
                params(4).Value = Me.verw2.Text
                params(5).Value = Me.verw3.Text
                params(6).Value = Me.verw4.Text
                params(7).Value = Me.verw5.Text
                params(8).Value = kontant_tipe

                If Me.Tjek.Checked <> 0 Then
                    If terugbetaling.Checked Or check_tj Then
                        params(9).Value = Tjekno.Text
                        params(10).Value = DBNull.Value
                    Else
                        params(9).Value = DBNull.Value
                        params(10).Value = Tjekno.Text
                    End If
                Else
                    params(9).Value = DBNull.Value
                    params(10).Value = DBNull.Value
                End If

                If Me.Tjek.Checked Then
                    params(11).Value = Tjekdatum.Text
                    params(12).Value = Tjekbesonderhede.Text
                Else
                    params(11).Value = DBNull.Value
                    params(12).Value = DBNull.Value
                End If

                params(13).Value = kwit_boek.Text
                params(14).Value = Persoonl.Area
                params(15).Value = Format(Now, "dd/MM/yyyy HH:mm")
                params(16).Value = tipe_ontv

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[stats5].[UpdateKontantAndMaandUovsForSalaries]", params)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub
    Function FetchKontantByKwitansie() As String
        Dim returnvalue As String

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                           New SqlParameter("@kwitansie", SqlDbType.NVarChar)}
                param(0).Value = Persoonl.POLISNO
                param(1).Value = strKwitansie

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchKontantByKwitansie]", param)

                If reader.Read() Then
                    If reader("vt_trans_dat") IsNot DBNull.Value Then
                        returnvalue = reader("vt_trans_dat")
                    End If
                    UpdateKontantByKwantasie()
                Else
                    returnvalue = ""
                End If
                Return returnvalue
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
            Exit Function
        End Try
    End Function

    Sub UpdateKontantByKwantasie()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@kwitansie", SqlDbType.NVarChar)}


                params(0).Value = Persoonl.POLISNO
                params(1).Value = strKwitansie


                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[stats5].[UpdateKontantByKwitansie]", params)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub
    Function FetchMaand_Puk_For_Salaries()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@Trans_dat", SqlDbType.DateTime)}

                param(0).Value = Persoonl.POLISNO
                param(1).Value = CDate(DataGridView1.SelectedRows(0).Cells(5).Value)

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaand_PukForSalaries]", param)
                Dim item As Maand_SalariesEntity = New Maand_SalariesEntity
                If reader.Read() Then
                    item.PREMIE = reader("PREMIE")
                End If
                If reader.Read() Then
                    item.VORD_PREMIE = reader("VORD_PREMIE")
                End If

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
            Exit Function
        End Try
    End Function
    Function Fetch_Eise_Kontant()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@Trans_dat", SqlDbType.DateTime)}

                param(0).Value = Persoonl.POLISNO
                param(1).Value = DataGridView1.SelectedRows(0).Cells(5).Value

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchEISE_KONTANT]", param)
                Dim item As EISE_KONTANT_Entity = New EISE_KONTANT_Entity
                If reader.Read() Then
                    item.PREMIE = reader("PREMIE")
                End If
                If reader.Read() Then
                    item.VORD_PREMIE = reader("VORD_PREMIE")
                End If

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
            Exit Function
        End Try
    End Function

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'Vertoon kansellasie en verwyder tjek besonderhede buttons

        Command3.Visible = True
        Command2.Visible = True


        'If Check_mk.CheckState Or check_md.CheckState Or Check_ms.CheckState Or Check_me.CheckState Or Check_VT.CheckState Or eerstebetaling.CheckState Then
        '    DataGridView1.ColumnCount = 6
        'Else
        '    DataGridView1.ColumnCount = 7
        'End If

        'Wys kansellasie en druk kwitansie buttons as op 'n geldige transaksie gekliek word
        If eerstebetaling.CheckState Then
            'DataGridView1.ColumnCount = 7
            If DataGridView1.SelectedRows(0).Cells(7).Value <> "T" And DataGridView1.SelectedRows(0).Cells(7).Value <> "K" And DataGridView1.SelectedRows(0).Cells(7).Value <> "E" Then
                Command2.Visible = False
                Command3.Visible = False
            End If
        End If

        If Vooruitbetaling.CheckState Then
            'DataGridView1.ColumnCount = 7
            If DataGridView1.SelectedRows(0).Cells(7).Value <> "T" And DataGridView1.SelectedRows(0).Cells(7).Value <> "K" And DataGridView1.SelectedRows(0).Cells(7).Value <> "E" Then
                Command2.Visible = False
                Command3.Visible = False
            End If
        End If

        If terugbetaling.CheckState Then
            'DataGridView1.ColumnCount = 7
            If DataGridView1.SelectedRows(0).Cells(7).Value <> "T" And DataGridView1.SelectedRows(0).Cells(7).Value <> "K" And DataGridView1.SelectedRows(0).Cells(7).Value <> "E" Then
                Command2.Visible = False
                Command3.Visible = False
            End If
        End If
    End Sub

    Public Sub kry_path_en_ander(ByRef leer As Object, ByRef wat As Object)
        Dim EPC As Object
        Dim motorsasria As Object
        Dim korting As Object
        Dim toebehore As Object
        Dim pol_exe_path As Object
        Dim wat2 As Object
        Dim einde As Object
        Dim polini As Object
        Dim lengte As Object

        'kry path, tv_premie, password vir motors,polisfooi,sasria en earlybird
        'parameters:
        'leer= watter *.ini moet gelees word bv. c:\windows\poldata.ini

        FileOpen(2, leer, OpenMode.Input)

        lengte = Len(wat)

        Do While Not (EOF(2))
            polini = LineInput(2)

            einde = Len(polini)
            wat2 = VB.Left(polini, lengte)

            If UCase(wat) = UCase(wat2) Then

                Select Case wat2
                    Case "EXE_PATH", "exe_path"
                        Exe_path = Mid(polini, lengte + 2, einde)
                        Exe_path = Trim(pol_exe_path)
                        Exit Do
                    Case "PATH", "path"
                        pol_path = Mid(polini, lengte + 2, einde)
                        pol_path = Trim(pol_path)
                        Exit Do
                    Case "TV_PREMIE", "tv_premie"
                        tv_koste = CSng(Mid(polini, lengte + 2, einde))
                        tv_koste = CSng(Trim(CStr(tv_koste)))
                        Exit Do
                    Case "PASSWORD", "password"
                        Password = Mid(polini, lengte + 2, einde)
                        Password = Trim(Password)
                        Exit Do
                    Case "POLISFOOI", "polisfooi"
                        polisfooi_ini = Mid(polini, lengte + 2, einde)
                        polisfooi_ini = Trim(polisfooi_ini)
                        Exit Do
                    Case "SASRIA", "sasria"
                        sasria_ini = Mid(polini, lengte + 2, einde)
                        sasria_ini = Trim(sasria_ini)
                        Exit Do
                    Case "SASRIA_H", "sasria_h"
                        h_sasria_ini = Mid(polini, lengte + 2, einde)
                        h_sasria_ini = Trim(h_sasria_ini)
                        Exit Do
                    Case "EARLYBIRD", "earlybird"
                        earlybird = CSng(Mid(polini, lengte + 2, einde))
                        earlybird = CSng(Trim(CStr(earlybird)))
                        Exit Do

                    Case "EPOSPATH", "epospath"
                        epospath = Mid(polini, lengte + 2, einde)
                        epospath = Trim(epospath)
                        Exit Do

                    Case "TOEBEHORE", "toebehore"
                        toebehore = Mid(polini, lengte + 2, einde)
                        toebehore = Trim(toebehore)
                        ntoebehore = Val(toebehore)
                        Exit Do

                    Case "korting", "KORTING"
                        korting = Mid(polini, lengte + 2, einde)
                        korting = Trim(korting)
                        nkorting = Val(korting)
                        Exit Do

                    Case "motorsasria", "MOTORSASRIA"
                        motorsasria = Mid(polini, lengte + 2, einde)
                        motorsasria = Trim(motorsasria)
                        nmotorsasria = Val(motorsasria)
                        Exit Do

                    Case "EPC", "epc"
                        EPC = Mid(polini, lengte + 2, einde)
                        EPC = Trim(EPC)
                        nepc = Val(EPC)
                        Exit Do

                End Select
            End If
        Loop
        FileClose(2)
        ' End ClassOption Strict Off

    End Sub

    Private Sub Check_mk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_mk.CheckedChanged

    End Sub

    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label19.Click

    End Sub

    Private Sub Taknaam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Taknaam.Click

    End Sub
End Class








