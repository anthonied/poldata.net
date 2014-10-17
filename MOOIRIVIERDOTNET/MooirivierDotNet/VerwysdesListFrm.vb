Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports DAL

Friend Class VerwysdesListFrm
    Inherits BaseForm
    Public PersoonlForVerwysde As PERSOONLEntity
    Public strActionStatus As String

    Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click
        Me.cmbAfsluitdatums.Items.Clear()
        cmbAfsluitdatums.Refresh()
        Me.Close()
    End Sub

    Private Sub btnEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnEdit.Click
        ' GridVerwysdes.ColumnCount = 0
        ' Andriette 18/06/2013 bulletproof - as daar geen rekords is nie moenie kan edit nie
        strActionStatus = "Edit"
        If dgvVerwysdes.RowCount > 0 Then

            If (Me.dgvVerwysdes.SelectedRows(0).Cells(0).Value <> pkVerwysdes) And (IsNumeric(Me.dgvVerwysdes.SelectedRows(0).Cells(0).Value)) Then

                'GridVerwysdes.ColumnCount = 5
                'Andriette 19/06/2013 verander die taal
                If (Me.dgvVerwysdes.SelectedRows(0).Cells(5).Value = "Verval") Or (Me.dgvVerwysdes.SelectedRows(0).Cells(5).Value = "Expired") Or _
                    (Me.dgvVerwysdes.SelectedRows(0).Cells(5).Value = "Gekanseleer") Or (Me.dgvVerwysdes.SelectedRows(0).Cells(5).Value = "Cancelled") Then
                    MsgBox("No editing is allowed.")
                    Exit Sub
                Else
                    VerwysdesDetailFrm.ShowDialog()
                End If

            End If
        End If

    End Sub

    Private Sub btnKanselleer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnKanselleer.Click
        verwysdesAsluitings = New VerwysdesAfsluitingsEntity
        verwysdesAsluitings = FetchVerwysdesAsluitings()

        If Me.dgvVerwysdes.SelectedCells.Item(0).Value <> verwysdesAsluitings.pkVerwysdesAfsluitings And (IsNumeric(Me.dgvVerwysdes.SelectedCells.Item(0).Value)) Then
            'As verwysde alreeds gekanslleer is, vertoon boodskap
            ' GridVerwysdes.ColumnCount = 5
            ' Andriette 15/05/2013 verander die offset van die grid
            'If Me.GridVerwysdes.SelectedRows(0).Cells(5).Value = "Gekanselleer" Then
            If (Me.dgvVerwysdes.SelectedRows(0).Cells(6).Value = "Gekanselleer" Or Me.dgvVerwysdes.SelectedRows(0).Cells(6).Value = "Cancelled") Then
                MsgBox("This reference is already cancelled.")
                Exit Sub
            Else
                UpdateStatus()
                UpdateVerwysKanselasie()
                UpdateVerwysdeur()
                PopulateGridVerwysdes()
            End If
        Else
            MsgBox("Please select a valid reference to cancel.")
            Exit Sub
        End If
    End Sub

    Sub UpdateStatus()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@pkVerwysdes", SqlDbType.Int), _
                                               New SqlParameter("@Status", SqlDbType.NVarChar, 10)}
                params(0).Value = dgvVerwysdes.SelectedRows(0).Cells(0).Value
                params(1).Value = "Cancelled"
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateVerwysdesStatus", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub UpdateVerwysdeur()

        Dim param5() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NChar), _
                                        New SqlParameter("@verwysdeur", SqlDbType.NChar)}
        Try
            param5(0).Value = Me.dgvVerwysdes.SelectedRows(0).Cells(1).Value
            param5(1).Value = ""
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[Updateverwysdeurinpersoonl]", param5)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub UpdateVerwysKanselasie()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params As New SqlParameter("@pkVerwysdes", SqlDbType.Int)
                params.Value = dgvVerwysdes.SelectedRows(0).Cells(0).Value
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVerwysdes", params)

                Do While reader.Read

                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = "kanselleer verwysde: " & reader("versekerde") & " " & reader("voorl") & "(" & reader("Verwysde") & ")"
                    Else
                        ' Andriette 12/06/2013 verander die bewoording
                        BESKRYWING = "cancel referral: " & reader("versekerde") & " " & reader("voorl") & "(" & reader("Verwysde") & ")"
                    End If

                    UpdateWysig((142), BESKRYWING)
                Loop
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnVoegBy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnVoegby.Click
        strActionStatus = "Add"
        VersekerdeSoek.ShowDialog()
    End Sub

    Private Sub cmbAfsluitdatums_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbAfsluitdatums.SelectedIndexChanged
        Dim dblTotaalVerwyskommissie As Double
        Dim introw As Integer

        dblTotaalVerwyskommissie = 0
        dgvVerwysdes.AutoGenerateColumns = False
        dgvVerwysdes.Refresh()
        dgvVerwysdes.Rows.Clear()
        dgvVerwysdes.ColumnCount = 6
        dgvVerwysdes.ColumnHeadersVisible = True
        dgvVerwysdes.Columns(0).Name = "pkVerwysdesAfsluitings"
        dgvVerwysdes.Columns(0).ReadOnly = True
        dgvVerwysdes.Columns(0).Visible = False
        dgvVerwysdes.Columns(1).Name = "Policy Number"
        dgvVerwysdes.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvVerwysdes.Columns(2).Name = "Insured"
        dgvVerwysdes.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        'Andriette 18/06/2013 verander die bewoording
        dgvVerwysdes.Columns(3).Name = "Start date"
        dgvVerwysdes.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvVerwysdes.Columns(4).Name = "End date"
        dgvVerwysdes.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        ' Andriette 19/06/2013 haal heeltemal uit omdat dit altyd aktief gewys het en daar nie 'n status op die history tabel is nie
        'GridVerwysdes.Columns(5).Name = "Status"
        'GridVerwysdes.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvVerwysdes.Columns(5).Name = "Commission"
        dgvVerwysdes.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable

        introw = introw + 1
        introw = 0
        dblTotaalVerwyskommissie = 0
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                               New SqlParameter("@DatumAfgesluit", SqlDbType.Date)}
                'Andriette 16/08/2013 gebruik die global polisnommer
                'param(0).Value = Form1.POLISNO.Text
                param(0).Value = glbPolicyNumber
                param(1).Value = CDate(cmbAfsluitdatums.Text)

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchGridVerwysdes", param)
                While reader.Read()
                    'Andriette 16/08/2013 gebruik die global polisnommer
                    'If reader("Verwyser") = Form1.POLISNO.Text Then
                    If reader("Verwyser") = glbPolicyNumber Then
                        introw = introw + 1
                        'Andriette 19/06/2013 haal die status uit
                        'GridVerwysdes.Rows.Insert(0, reader("pkVerwysdesAfsluitings"), reader("Verwysde"), reader("Versekerde") & " " & reader("Voorl"), reader("Datumbegin"), reader("DatumEindig"), "Aktief", Format(reader("kommissie"), "#####0.00"), introw)
                        dgvVerwysdes.Rows.Insert(0, reader("pkVerwysdesAfsluitings"), reader("Verwysde"), reader("Versekerde") & " " & reader("Voorl"), reader("Datumbegin"), reader("DatumEindig"), Format(reader("kommissie"), "#####0.00"), introw)
                        dblTotaalVerwyskommissie = dblTotaalVerwyskommissie + reader("kommissie")
                    End If
                End While
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Display total for verwysdes
        introw = introw + 1
        ' Andriette 19/06/2013 haal die status heeltemal uit
        ' GridVerwysdes.Rows.Insert(GridVerwysdes.Rows.Add, "", "", "", "", "", "Total", Format(sngTotaalVerwyskommissie, "#####0.00"), introw)
        dgvVerwysdes.Rows.Insert(dgvVerwysdes.Rows.Add, "", "", "", "", "Total", Format(dblTotaalVerwyskommissie, "#####0.00"), introw)
        For intTeller = 0 To dgvVerwysdes.Rows.Count - 1
            If dgvVerwysdes.Rows(intTeller).Cells(5).Value = "Total" Then
                dgvVerwysdes.Rows(intTeller).DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold)
            End If
        Next intTeller
        dgvVerwysdes.DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Regular)
    End Sub

    Private Sub cmdKommissie_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdKommissie.Click
        Dim dteAfsluit As Date
        Dim dteVanaf As Date
        Dim dteTot As Date
        Dim strBetaalwyse As String = ""

        Me.dgvVerwysdes.RowCount = 1 'Verwysde
        If Me.rdVerwysdes.Checked Then
            GetDateAfsluit((Me.dgvVerwysdes.SelectedRows(0).Cells(1).Value), dteAfsluit, strBetaalwyse)
        ElseIf Me.rdAfsluitings.Checked Then

            'Kry betaalwyse
            GetDateAfsluit((Me.dgvVerwysdes.SelectedRows(0).Cells(1).Value), dteAfsluit, strBetaalwyse)
            dteAfsluit = CDate(Me.cmbAfsluitdatums.Text)
        End If

        'Bereken kommissie op verwysde geselekteer
        If validateFields() Then
            frmKommissie.dteAfsluit.Text = CStr(dteAfsluit)
            dteVanaf = CDate("20/" & Month(dteAfsluit) & "/" & Year(dteAfsluit))
            frmKommissie.dtpVanaf.Value = dteVanaf
            dteTot = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, dteVanaf)
            dteTot = DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, dteTot)
            frmKommissie.dtpTot.Value = dteTot
            frmKommissie.txtBetaalwyse.Text = strBetaalwyse
            frmKommissie.ShowDialog()
        End If

    End Sub

    '* Purpose    : To get the previous afsluit datum for the selected policy
    '* Inputs     : strVerwysde
    '* Outputs    : dteAfsluit, strBetaalwyse

    Public Sub GetDateAfsluit(ByRef strVerwysde As Object, ByRef dteAfsluit As Object, ByRef strBetaalwyse As Object)

        PersoonlForVerwysde = FetchPersoonlByVerwyser(strVerwysde)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@betwyse", SqlDbType.VarChar), _
                                               New SqlParameter("@strBetaalwyse", SqlDbType.VarChar), _
                                               New SqlParameter("@area", SqlDbType.VarChar)}

                param(0).Value = PersoonlForVerwysde.BET_WYSE
                param(1).Value = strBetaalwyse
                param(2).Value = PersoonlForVerwysde.Area
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchAfluit", param)

                Do While reader.Read
                    dteAfsluit = Format(reader("Maxdate"), "dd/mm/yyyy")
                Loop
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub VerwysdesListFrm_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        If UCase(Form1.GEKANS.Text) = "NEE" Then
            Me.btnVoegby.Enabled = False
            Me.btnEdit.Enabled = False
            Me.btnKanselleer.Enabled = False
        End If
        'Andriette 16/08/2013 gebruik die global polis nommer
        '        Me.Text = My.Application.Info.Title & " - Policy functions - Referrals for " & Form1.TITEL.Text & " " & Form1.VOORL.Text & " " & Form1.VERSEKERDE.Text & "(" & Form1.POLISNO.Text & ")"
        Me.Text = My.Application.Info.Title & " - Policy functions - Referrals for " & Form1.TITEL.Text & " " & Form1.VOORL.Text & " " & Form1.VERSEKERDE.Text & "(" & glbPolicyNumber & ")"

        dgvVerwysdes.ReadOnly = True
        dgvVerwysdes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        PopulateGridVerwysdes()
        With Me.dgvVerwysdes.RowTemplate
            .Height = 18
            .MinimumHeight = 5
        End With
        'Check if policy is cancelled
        If Persoonl.GEKANS Then
            Me.btnVoegby.Enabled = False

            Me.btnEdit.Enabled = False
            Me.btnKanselleer.Enabled = False
        Else
            Me.btnVoegby.Enabled = True

            Me.btnEdit.Enabled = True
            Me.btnKanselleer.Enabled = True
        End If

        Me.rdVerwysdes.Checked = 1

        If Gebruiker.titel = "Besigtig" Then
            Me.btnEdit.Enabled = False
            Me.btnKanselleer.Enabled = False
            Me.btnVoegby.Enabled = False
        End If
        If dgvVerwysdes.RowCount = 0 Then
            btnEdit.Enabled = False
            btnKanselleer.Enabled = False
        Else
            btnEdit.Enabled = True
            btnKanselleer.Enabled = True
        End If
        cmbAfsluitdatums.Text = "  "
    End Sub

    Private Sub GridVerwysdes_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If strGebtitel = "Besigtig" Then
            Exit Sub
        End If

        'GridVerwysdes.ColumnCount = 0
        If (Me.dgvVerwysdes.SelectedCells.Item(0).Value <> "pkVerwysdes") And (IsNumeric(Me.dgvVerwysdes.SelectedCells.Item(0).Value)) Then
            'GridVerwysdes.ColumnCount = 5
            If (Me.dgvVerwysdes.SelectedCells.Item(5).Value = "Verval") Then
                MsgBox("This referenced expired. No editing is allowed.")
                Exit Sub
            Else
                ' VerwysdesDetailFrm.lblVerwysde.Enabled = False
                '    VerwysdesDetailFrm.txtStatus.Enabled = True

                VerwysdesDetailFrm.ShowDialog()
            End If
        End If

    End Sub
    Private Sub rdAfsluitings_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rdAfsluitings.CheckedChanged
        Try
            If eventSender.Checked Then

                dgvVerwysdes.Rows.Clear()

                btnVoegby.Enabled = False
                btnEdit.Enabled = False
                btnKanselleer.Enabled = False

                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchDistinctDatumAfgesluit")
                    Me.cmbAfsluitdatums.Items.Clear()
                    While reader.Read
                        Me.cmbAfsluitdatums.Items.Add(Format(reader("DatumAfgesluit"), "dd/MM/yyyy"))
                    End While
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                End Using

                If Me.cmbAfsluitdatums.SelectedIndex <> -1 Then
                    Me.cmbAfsluitdatums.SelectedIndex = 0
                End If

                Me.cmbAfsluitdatums.Enabled = True
                ' Andriette 18/06/2013 maak die start niks
                cmbAfsluitdatums.Text = ""
                cmbAfsluitdatums.Refresh()
                If Gebruiker.titel = "Besigtig" Then
                    Me.btnEdit.Enabled = False
                    Me.btnKanselleer.Enabled = False
                    Me.btnVoegby.Enabled = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub rdVerwysdes_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rdVerwysdes.CheckedChanged
        cmbAfsluitdatums.Text = ""
        If eventSender.Checked Then

            PopulateGridVerwysdes()

            'Check if policy is cancelled
            If Persoonl.GEKANS Then
                Me.btnVoegby.Enabled = False

                Me.btnEdit.Enabled = False
                Me.btnKanselleer.Enabled = False

            Else
                Me.btnVoegby.Enabled = True

                Me.btnEdit.Enabled = True
                Me.btnKanselleer.Enabled = True
            End If
            Me.cmbAfsluitdatums.Enabled = False

            If Gebruiker.titel = "Besigtig" Then
                Me.btnEdit.Enabled = False
                Me.btnKanselleer.Enabled = False
                Me.btnVoegby.Enabled = False
            End If
        End If
    End Sub
    '* Purpose    : Get the Verwysde korting percentage
    '* Outputs    : GetVerwysdeKorting
    Public Function GetVerwysdeKorting() As String
        GetVerwysdeKorting = Constants.Korting
    End Function

    Public Function validateFields() As Object
        validateFields = True
        If Me.dgvVerwysdes.SelectedCells.Item(0).Value = "pkVerwysdes" Then
            MsgBox("Please select a reference to calculate commission.")
            validateFields = False
            Exit Function
        End If
    End Function

    Private Sub GridVerwysdes_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVerwysdes.CellClick, dgvVerwysdes.CellClick
        If Me.dgvVerwysdes.SelectedCells.Item(6).Value = "Cancelled" Or Me.dgvVerwysdes.SelectedCells.Item(6).Value = "Expired" Then
            btnEdit.Enabled = False
            btnKanselleer.Enabled = False
        Else
            btnEdit.Enabled = True
            btnKanselleer.Enabled = True
        End If
    End Sub

    Private Sub GridVerwysdes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVerwysdes.CellContentClick, dgvVerwysdes.CellContentClick
        dgvVerwysdes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Public Function FetchPersoonlByVerwyser(ByRef Nommer As String) As PERSOONLEntity
        Dim item As PERSOONLEntity = New PERSOONLEntity()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@Verwyser", SqlDbType.NVarChar)
                param.Value = Nommer
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchPersoonlForVerwysdes]", param)

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
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
        Return item
    End Function
End Class