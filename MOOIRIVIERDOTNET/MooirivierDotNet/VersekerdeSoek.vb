Option Strict Off
Option Explicit On

Imports System.Data.SqlClient
Imports DAL

Friend Class VersekerdeSoek
    Inherits BaseForm

    Dim strEndofThisMonth As String
    Dim strStartofThisMonth As String
    Dim blnPolisNrChange As Boolean = False
    Dim dteDatumbegin As Date
    Dim dteDatumeindig As Date


    Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        ClearFields()
        'dtpDatumEindig = Nothing
        Me.Close()
    End Sub

    Private Sub btnClear_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click

        If txtVersekerde.Text <> "" Then
            ' Andriette 12/06/2014 doen die datum omskakeling
            SkakelDatumOm()

            'Andriette 29/07/2013 Skuif die inskryf van die nuwe referral na hier
            If validateFields() Then
                ' Andriette 24/06/2013 verander na ;n bruikbare variable
                'If Me.ChkForAdd.Checked = True Then
                If VerwysdesListFrm.strActionStatus = "Add" Then

                    InsertVerwysdes()
                    'Andriette 25/06/2013 haal uit sodat die datums ook in ag geneem kan word
                    '   Me.Close()
                    'Andriette 29/07/2013 skryf die amendment weg

                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = "voeg verwysde by: " & txtVersekerde.Text & "(" & txtPolisno.Text & ")"
                    Else
                        BESKRYWING = "add Referral: " & txtVersekerde.Text & "(" & txtPolisno.Text & ")"
                    End If

                    UpdateWysig((142), BESKRYWING)
                End If
                VerwysdesListFrm.PopulateGridVerwysdes()
                'Andriette 06/06/2014
                'Die verwysdeur in die persoonl tabel van die verwysde moet die verwyser se waare in kry
                UpdateVerwysdeWithVerwysdeur(Me.txtPolisno.Text, glbPolicyNumber)

                Me.Close()
            End If

        Else
            MsgBox("An Insured must be selected to continue.", MsgBoxStyle.Exclamation)
        End If
        ClearFields()
    End Sub

    Private Sub btnSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSearch.Click
        'Replace code to only retrieve records from database that conforms to the search criteria specified
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        If txtPolisno.Text <> "" And txtPolisno.Text.Length = 10 Then

            Dim strVan As String = ""
            Dim strVoorl As String = ""
            If Len(Trim(txtPolisno.Text)) = 10 Then
                'If blnPolisNrChange Then
                Try
                    Using conn As SqlConnection = SqlHelper.GetConnection
                        Dim params() As SqlParameter = {New SqlParameter("@PolisNo", SqlDbType.NVarChar)}
                        params(0).Value = txtPolisno.Text
                        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[Poldata5].[FetchPersoonlByPolisno]", params)
                        If reader.Read() Then
                            If reader("versekerde") IsNot DBNull.Value Then
                                strVan = reader("Versekerde")
                            End If
                            If reader("voorl") IsNot DBNull.Value Then
                                strVoorl = (reader("Voorl"))
                            End If
                            txtVersekerde.Text = Trim(strVan) & " " & Trim(strVoorl)
                            '   gridVersekerde.SelectedCells.Item(0).Value & " " & gridVersekerde.SelectedCells.Item(1).Value
                            'Andriette 05/08/2013 vul ook die grid met die versekerde wat gevind is
                            gridVersekerde.AutoGenerateColumns = False
                            gridVersekerde.Rows.Insert(0, strVan, strVoorl, txtPolisno.Text, 1)

                        End If
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                    End Using
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
            End If
        ElseIf txtPolisno.Text.Length > 1 And txtPolisno.Text.Length < 10 Then
            MsgBox("The Policy Number is not long enough, please re-enter", MsgBoxStyle.Exclamation)
            txtPolisno.Text = ""
        ElseIf txtVersekerde.Text <> "" Then
            refreshGrid()
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub VersekerdeSoek_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ClearFields()
        InitialiseFormValues()
        gridVersekerde.ReadOnly = True
        gridVersekerde.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.txtVersekerde.Text = ""
        'Andriette 31/07/2013 fokus hier
        Me.txtVersekerde.Focus()
        With Me.gridVersekerde.RowTemplate
            .Height = 18
            .MinimumHeight = 5
        End With
        'Andriette 24/06/2013 Inisialiseer al die waardes

    End Sub

    Public Sub refreshGrid()

        gridVersekerde.AutoGenerateColumns = False
        gridVersekerde.DataSource = FetchPersoonlForGrid()
        gridVersekerde.ClearSelection()

    End Sub

    Public Function FetchPersoonlForGrid() As List(Of PERSOONLEntity)

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                               New SqlParameter("@POLISNOFROMMAINFORM", SqlDbType.NVarChar), _
                                               New SqlParameter("@UserBranchCodes", SqlDbType.NVarChar), _
                                               New SqlParameter("@VERSEKERDE", SqlDbType.NVarChar)}


                If txtPolisno.Text = "" Then
                    param(0).Value = DBNull.Value
                Else
                    param(0).Value = txtPolisno.Text
                End If
                'Andriette 16/08/2013 gebruik die global polisnommer
                'param(1).Value = Form1.POLISNO.Text
                param(1).Value = glbPolicyNumber
                If Gebruiker.titel = "Programmeerder" Then
                    param(2).Value = Persoonl.Area
                Else
                    param(2).Value = DBNull.Value
                End If

                If txtVersekerde.Text = "" Then
                    param(3).Value = DBNull.Value
                Else
                    param(3).Value = txtVersekerde.Text
                End If

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlDetailsForGrid", param)
                Dim list As List(Of PERSOONLEntity) = New List(Of PERSOONLEntity)
                Do While reader.Read()
                    Dim item As PERSOONLEntity = New PERSOONLEntity()
                    If reader("Polisnommer") IsNot DBNull.Value Then
                        item.POLISNO = reader("Polisnommer")
                    End If

                    If reader("Voorletter") IsNot DBNull.Value Then
                        item.VOORL = reader("Voorletter")
                    End If

                    If reader("VERSEKERDE") IsNot DBNull.Value Then
                        item.VERSEKERDE = reader("VERSEKERDE")
                    End If
                    list.Add(item)
                Loop

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

    Private Sub gridVersekerde_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridVersekerde.Click
        'Dim txtVoorletter As Object
        'Dim txtVan As Object

        ' Me.gridVersekerde.ColumnCount = 3
        If gridVersekerde.SelectedCells.Count = 0 Then 'And (Me.gridVersekerde.SelectedCells  Text <> "") Then ' (Me.gridVersekerde.SelectedCells.Item(2).Value <> "Polisnommer") Then
            MsgBox("An Insured must be selected to continue.", MsgBoxStyle.Exclamation)
        Else
            ' Andriette 24/06/2013 kombineer die 2 vorms nl Versekerdesoek en Verwysdesdetail om te vereenvoudig
            txtVersekerde.Text = gridVersekerde.SelectedCells.Item(0).Value & " " & gridVersekerde.SelectedCells.Item(1).Value
            txtPolisno.Text = gridVersekerde.SelectedCells.Item(2).Value
            '   btnClear.Enabled = False
            btnSearch.Enabled = False
        End If

    End Sub

    Private Sub ClearFields()
        txtPolisno.Text = ""
        Me.txtVersekerde.Text = ""
        Me.txtVersekerde.Focus()
        gridVersekerde.DataSource = Nothing
        gridVersekerde.Refresh()
        gridVersekerde.Rows.Clear()
        btnClear.Enabled = True
        btnSearch.Enabled = True
        '  dtpDatumEindig.Text = ""
    End Sub

    ' Andriette 24/06/2013 skuif van die funksies van verwysdesdetailfrm na hier 
    Public Function validateFields() As Boolean
        Dim blnPolisno As Boolean
        'Dim sSql As String

        'Die verwyser mag nie homself verwys nie
        'Andriette 24/06/2013 die veldnaam verskil
        'If Me.txtVerwysde.Text = Form1.POLISNO.Text Then
        'Andriette 16/08/2013 gebruik die global polisnommer
        '        If txtPolisno.Text = Form1.POLISNO.Text Then
        If txtPolisno.Text = glbPolicyNumber Then
            MsgBox("Referral may not be to himself.", MsgBoxStyle.Exclamation, "Poldata")
            validateFields = False

            'Me.txtVerwysde.Focus()
            txtPolisno.Focus()
            validateFields = False
            Exit Function
        End If

        'Verwysde moet 'n polisnommer in hê. Dit moet bestaan op persoonl en nie gekanselleerd wees.
        ' If (Me.txtVerwysde.Text = "") Or Not IsNumeric(Me.txtVerwysde.Text) Then
        If (txtPolisno.Text = "") Or Not IsNumeric(txtPolisno.Text) Then
            'Andriette 26/06/2014 
            '  MsgBox("The referral must have a valid policy number.", MsgBoxStyle.Exclamation, "Poldata")
            MsgBox("An Insured must be selected to continue.", MsgBoxStyle.Exclamation, "Poldata")
            validateFields = False
            'e.txtVerwysde.Focus()
            txtPolisno.Focus()
            Exit Function
        End If

        If dteDatumbegin > dteDatumeindig Then
            MsgBox("The start date must be before the end date", MsgBoxStyle.Exclamation, "Poldata")
            Exit Function
        End If
        'If VerwysdesListFrm.GridVerwysdes.SelectedRows(0).Cells(0).Value = pkVerwysdes Then 'Vir byvoeg
        'Andriette 
        ' PolisnoFetch = FetchPersoonlPolisno()
        blnPolisno = FetchPersoonlPolisno()
        If blnPolisno = False Then
            'Andriette 26/06/2014
            ' MsgBox("The referral must have a valid policy number and it may not be cancelled. ", MsgBoxStyle.Exclamation, "Poldata")
            'An Insured must be selected to continue
            MsgBox("An Active Insured must be selected to continue.", MsgBoxStyle.Exclamation, "Poldata")
            validateFields = False
            Exit Function
        Else
            validateFields = True
        End If

        'Die verwysde mag nie 'n JK of TP wees nie 
        If Persoonl.BET_WYSE = "2" Or Persoonl.BET_WYSE = "6" Then
            MsgBox("Yearly cash or a term policy may not be a referral.", MsgBoxStyle.Exclamation, "Poldata")
            validateFields = False
            Exit Function
        End If

        'If ChkForAdd.Checked = True Then
        If VerwysdesListFrm.strActionStatus = "Add" Then
            For intTeller = 0 To VerwysdesListFrm.dgvVerwysdes.Rows.Count - 1
                Dim strstatus As String
                strstatus = VerwysdesListFrm.dgvVerwysdes.Rows(intTeller).Cells(6).Value.ToString.ToUpper
                'Andriette 26/03/2014 ekstra toets vir aktiewe verwysings
                If VerwysdesListFrm.dgvVerwysdes.Rows(intTeller).Cells(6).Value.ToString.ToUpper = "ACTIVE" Then
                    If txtPolisno.Text = VerwysdesListFrm.dgvVerwysdes.Rows(intTeller).Cells(1).Value Then
                        MsgBox("This is already a referral link.", MsgBoxStyle.Exclamation, "Poldata")
                        validateFields = False
                        Exit Function
                    End If
                End If
            Next
        Else
            validateFields = True
        End If
        validateFields = True
    End Function

    Sub InsertVerwysdes()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim param() As SqlParameter = {New SqlParameter("@Verwysde ", SqlDbType.NVarChar), _
                                                New SqlParameter("@Verwyser", SqlDbType.NVarChar), _
                                                New SqlParameter("@DatumBegin", SqlDbType.DateTime), _
                                                New SqlParameter("@DatumEinding", SqlDbType.DateTime), _
                                                New SqlParameter("@Status", SqlDbType.NVarChar)}

                'Andriette 24/06/201 verander die parameter
                ' param(0).Value = Me.txtVerwysde.Text
                param(0).Value = Me.txtPolisno.Text
                param(1).Value = Persoonl.POLISNO
                param(2).Value = Me.dteDatumbegin
                param(3).Value = Me.dteDatumEindig
                param(4).Value = Me.txtStatus.Text

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[InsertVerwysdes]", param)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try
    End Sub

    ' Andriette 24/06/2013 skuif van detail form af
    Public Sub logVerwysdesAlteration(ByRef strAltType As Object, ByRef StrOldValue As Object)

        'Log alterations on when new Verwysde was added and Datum verval was changed
        Select Case strAltType
            Case "Addnew"

                If Persoonl.TAAL = 0 Then
                    BESKRYWING = "voeg verwysde by: "
                Else
                    BESKRYWING = "add Referral: "
                End If

                BESKRYWING = BESKRYWING & txtVersekerde.Text & " " & "(" & Me.txtPolisno.Text & ")"

            Case "Status"
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig status vanaf (" & StrOldValue & ") na (" & Me.txtStatus.Text & ") op verwysde: " & Me.txtVersekerde.Text & "(" & Me.txtPolisno.Text & ")"
                Else
                    BESKRYWING = " change status from (" & StrOldValue & ") to (" & Me.txtStatus.Text & ") on referral: " & Me.txtVersekerde.Text & "(" & Me.txtPolisno.Text & ")"
                End If

        End Select

        UpdateWysig((142), BESKRYWING)

    End Sub

    Sub UpdateVerwysdes()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@Verwysde ", SqlDbType.Int), _
                                               New SqlParameter("@DatumBegin", SqlDbType.DateTime), _
                                               New SqlParameter("@DatumEinding", SqlDbType.DateTime), _
                                               New SqlParameter("@Status", SqlDbType.NVarChar)}

                param(0).Value = VerwysdesListFrm.dgvVerwysdes.SelectedRows(0).Cells(0).Value
                param(3).Value = Me.txtStatus.Text
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdateVerwysdesData]", param)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try
    End Sub

    Private Function UpdateVerwysdeWithVerwysdeur(ByRef strVerwysde As Object, ByRef strverwyser As String) As Object
        Dim params() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                            New SqlParameter("@verwysdeur", SqlDbType.NVarChar)}
        params(0).Value = strVerwysde
        params(1).Value = strverwyser

        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.UpdateVerwysdeurInPersoonl", params)

        Return Nothing

    End Function

    Function FetchPersoonlPolisno() As Boolean
        Dim blnreturnValue As Boolean = False
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchPersoonlPolisno]")
                While reader.Read()
                    If reader("Polisno") = txtPolisno.Text Then
                        blnreturnValue = True
                    End If
                End While
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            blnreturnValue = False
        End Try
        Return blnreturnValue
    End Function

    ' Andriette 24/06/2013 skep ;n sub wat die inisiasie van die velde doen
    Private Sub InitialiseFormValues()
        'Dim dteAfsluitDatum As Date
        'Dim dteBeginDatum As Date
        Dim strMaande(12, 2) As String

        'Andriette 12/06/2013 verander die bewoording
        Me.Text = My.Application.Info.Title & " - Referral - search policy"
        Me.txtStatus.Items.Clear()
        txtVersekerde.Focus()
        Me.txtStatus.Items.Add("Active")
        Me.txtStatus.Items.Add("Cancelled")
        Me.txtStatus.Items.Add("Expired")

        strMaande(0, 0) = "01"
        strMaande(0, 1) = "Januarie"
        strMaande(0, 2) = "January"
        strMaande(1, 0) = "02"
        strMaande(1, 1) = "Februarie"
        strMaande(1, 2) = "February"
        strMaande(2, 0) = "03"
        strMaande(2, 1) = "Maart"
        strMaande(2, 2) = "March"
        strMaande(3, 0) = "04"
        strMaande(3, 1) = "April"
        strMaande(3, 2) = "April"
        strMaande(4, 0) = "05"
        strMaande(4, 1) = "Mei"
        strMaande(4, 2) = "May"
        strMaande(5, 0) = "06"
        strMaande(5, 1) = "Junie"
        strMaande(5, 2) = "June"
        strMaande(6, 0) = "07"
        strMaande(6, 1) = "Julie"
        strMaande(6, 2) = "July"
        strMaande(7, 0) = "08"
        strMaande(7, 1) = "Augustus"
        strMaande(7, 2) = "August"
        strMaande(8, 0) = "09"
        strMaande(8, 1) = "September"
        strMaande(8, 2) = "September"
        strMaande(9, 0) = "10"
        strMaande(9, 1) = "Oktober"
        strMaande(9, 2) = "October"
        strMaande(10, 0) = "11"
        strMaande(10, 1) = "November"
        strMaande(10, 2) = "November"
        strMaande(11, 0) = "12"
        strMaande(11, 1) = "Desember"
        strMaande(11, 2) = "December"
        'andriette 24/06/2013 default na gelang van die button gebruik
        cmbMaandBegin.Items.Clear()
        cmbMaandEindig.Items.Clear()
        If VerwysdesListFrm.strActionStatus = "Add" Then
            txtStatus.Text = "Active"
            Dim intVandagMaand As Integer = Today.Month
            Dim IntVandagJaar As Integer = Today.Year
            Dim dteTeldatum As Date = Now()

            For intmaand = 1 To 12
                If Persoonl.TAAL = 0 Then ' Afrikaans
                    cmbMaandBegin.Items.Add(strMaande(dteTeldatum.Month - 1, 1) + " " + dteTeldatum.Year.ToString)
                    cmbMaandEindig.Items.Add(strMaande(dteTeldatum.Month - 1, 1) + " " + dteTeldatum.Year.ToString)
                ElseIf Persoonl.TAAL = 1 Then ' Engels
                    cmbMaandBegin.Items.Add(strMaande(dteTeldatum.Month - 1, 2) + " " + dteTeldatum.Year.ToString)
                    cmbMaandEindig.Items.Add(strMaande(dteTeldatum.Month - 1, 2) + " " + dteTeldatum.Year.ToString)
                End If

                dteTeldatum = dteTeldatum.AddMonths(1)
            Next
            cmbMaandBegin.SelectedIndex = 0
            cmbMaandEindig.SelectedIndex = 11

        ElseIf VerwysdesListFrm.strActionStatus = "Edit" Then
            txtStatus.Text = VerwysdesListFrm.dgvVerwysdes.CurrentRow.Cells(6).Value
            'Andriette 24/06/2013 stel die datums as edit
            ' Andriette 24/06/2013 stel die kommissie as edit
        End If
        'Andriette 31/07/2013 disable die search button, word slegs met die versekerde van gebruik
        '  btnSearch.Enabled = False
        txtVersekerde.Focus()
    End Sub

    Private Function GetAfsluitDatumFromTable()
        Dim dteAfsluit As Date = "01/01/1900"
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[STATS5D].[FetchAfsluitDatumLaaste]")
                If reader.HasRows() Then

                    While reader.Read()

                        If reader("afsluit_dat") IsNot DBNull.Value Then
                            dteAfsluit = reader("afsluit_dat")
                        End If
                    End While
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Return dteAfsluit
    End Function

    Private Sub txtPolisno_Click(sender As Object, e As System.EventArgs) Handles txtPolisno.Click
        blnPolisNrChange = True
        txtVersekerde.Text = ""
    End Sub
    'Andriette 31/07/2013
    'Purpose:   To catch the entry of the policy number so that the grid is not filled and the name of the insured is populated automatically
    Private Sub txtPolisno_Leave(sender As Object, e As System.EventArgs) Handles txtPolisno.Leave
        Dim strVan As String = ""
        Dim strVoorl As String = ""
        If Len(Trim(txtPolisno.Text)) = 10 Then
            'If blnPolisNrChange Then
            Try
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim params() As SqlParameter = {New SqlParameter("@PolisNo", SqlDbType.NVarChar)}
                    params(0).Value = txtPolisno.Text
                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[Poldata5].[FetchPersoonlByPolisno]", params)
                    If reader.Read() Then
                        If reader("versekerde") IsNot DBNull.Value Then
                            strVan = reader("Versekerde")
                        End If
                        If reader("voorl") IsNot DBNull.Value Then
                            strVoorl = (reader("Voorl"))
                        End If
                        txtVersekerde.Text = Trim(strVan) & " " & Trim(strVoorl)
                    End If
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub txtVersekerde_Click(sender As Object, e As System.EventArgs) Handles txtVersekerde.Click
        txtPolisno.Text = ""
    End Sub

    Private Sub txtVersekerde_TextChanged(sender As Object, e As System.EventArgs) Handles txtVersekerde.TextChanged
        'Andriette 31/07/2013 disable die search button, word slegs met die versekerde van gebruik
        btnSearch.Enabled = True
    End Sub

    Private Sub SkakelDatumOm()
        Dim strBeginmonth As String = cmbMaandBegin.SelectedItem.ToString.Substring(0, InStr(cmbMaandBegin.SelectedItem.ToString, " ")).Trim
        Dim strBeginYear As String = cmbMaandBegin.SelectedItem.ToString.Substring(InStr(cmbMaandBegin.SelectedItem.ToString, " "), 4).Trim
        Dim strEndMonth As String = cmbMaandEindig.SelectedItem.ToString.Substring(0, InStr(cmbMaandEindig.SelectedItem.ToString, " ")).Trim
        Dim strEndYear As String = cmbMaandEindig.SelectedItem.ToString.Substring(InStr(cmbMaandEindig.SelectedItem.ToString, " "), 4).Trim
        Select Case strBeginmonth
            Case "Januarie", "January"
                dteDatumbegin = "01/01/" & strBeginYear
            Case "Februarie", "February"
                dteDatumbegin = "01/02/" & strBeginYear
            Case "Maart", "March"
                dteDatumbegin = "01/03/" & strBeginYear
            Case "April"
                dteDatumbegin = "01/04/" & strBeginYear
            Case "Mei", "May"
                dteDatumbegin = "01/05/" & strBeginYear
            Case "Junie", "June"
                dteDatumbegin = "01/06/" & strBeginYear
            Case "Julie", "July"
                dteDatumbegin = "01/07/" & strBeginYear
            Case "Augustus", "August"
                dteDatumbegin = "01/08/" & strBeginYear
            Case "September"
                dteDatumbegin = "01/09/" & strBeginYear
            Case "Oktober", "October"
                dteDatumbegin = "01/10/" & strBeginYear
            Case "November"
                dteDatumbegin = "01/11/" & strBeginYear
            Case "Desember", "December"
                dteDatumbegin = "01/12/" & strBeginYear
            Case Else
                MsgBox("There was a problem with the selection of the start date", MsgBoxStyle.Critical)
                Exit Sub
        End Select

        Select Case strEndMonth
            Case "Januarie", "January"
                dteDatumeindig = DateTime.Parse("01/01/" & strEndYear)
            Case "Februarie", "February"
                dteDatumeindig = DateTime.Parse("01/02/" & strEndYear)
            Case "Maart", "March"
                dteDatumeindig = DateTime.Parse("01/03/" & strEndYear)
            Case "April"
                dteDatumeindig = DateTime.Parse("01/04/" & strEndYear)
            Case "Mei", "May"
                dteDatumeindig = DateTime.Parse("01/05/" & strEndYear)
            Case "Junie", "June"
                dteDatumeindig = DateTime.Parse("01/06/" & strEndYear)
            Case "Julie", "July"
                dteDatumeindig = DateTime.Parse("01/07/" & strEndYear)
            Case "Augustus", "August"
                dteDatumeindig = DateTime.Parse("01/08/" & strEndYear)
            Case "September"
                dteDatumeindig = DateTime.Parse("01/09/" & strEndYear)
            Case "Oktober", "October"
                dteDatumeindig = DateTime.Parse("01/10/" & strEndYear)
            Case "November"
                dteDatumeindig = DateTime.Parse("01/11/" & strEndYear)
            Case "Desember", "December"
                dteDatumeindig = DateTime.Parse("01/12/" & strEndYear)
            Case Else
                MsgBox("There was a problem with the selection of the first payment date", MsgBoxStyle.Critical)
                Exit Sub
        End Select
        dteDatumeindig = dteDatumeindig.AddMonths(1)
        dteDatumeindig = dteDatumeindig.AddDays(-1)
    End Sub
End Class
