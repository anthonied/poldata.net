Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports DAL

Public Class frmKontant
    Dim strkontant_tipe As String
    Dim strtipe_ontv As String
    Dim blnPaymentValidation As Boolean
    Dim intRow As Integer
    Dim strTakafkorting As String
    Dim strTaknaam As String
    Dim intVT As Integer
    Dim intKwit_nr As Integer
    Dim dteAfsluitdat As Date
    Dim blnEersteKeerIn As Boolean = True
    Dim EntKontant As New KontantEntity
    Dim blnloading As Boolean = True
    'Andriette 02/07/2014 om oor te dra na die detail vorm
    Public blnNuweBetaling As Boolean = False
    Public blnWysigBetaling As Boolean
    Public blnWisBetaling As Boolean
    Dim dteLaasteAfsluit As Date = "1900/01/01"
    'Andriette 02/09/2014
    Public entMaandVtDetails As New VTDetailsEntity
    Public KontantItem As KontantEntity = New KontantEntity

    Private Sub frmKontant_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Kry tak
        Dim arrVTCountandBalance As Array
        getBranch()
        'Me.Text = Me.Text & " Policy Number: " & glbPolicyNumber & "     Insured: " & Form1.form1Voorl.Text & " " & Form1.form1Versekerde.Text & "     Branch: " & strTaknaam
        Me.Text = Me.Text & " Policy Number: " & glbPolicyNumber & "     Insured: " & Form1.txtForm1Voorl.Text & " " & Form1.txtForm1Versekerde.Text
        intVT = 0
        blnloading = True
        Me.dtpToDate.Text = DateSerial(Year(Now), Month(Now), Now.Day + 1)
        Me.dtpFrom.Text = DateSerial(Year(Now) - 1, Month(Now) + 1, 1)
        'Andriette 09/06/2014 skuif na fmrkontantdetail
        '  Me.dtpChequeDate.Text = Now
        Me.dtpFrom.Enabled = True
        Me.dtpToDate.Enabled = True
        'If Gebruiker.titel = "Besigtig" Then
        '    'Andriette 09/06/2014 skuif na die frmkontantdetail
        '    'Me.cmdRegisterPayment.Enabled = False
        '    'Andriette 09/06/2014 skuif na die frmkontantdetail
        '    'Me.cmdCancelPayment.Enabled = False
        'End If

        'Andriette 09/06/2014 moenie die checks nou al stel nie, dan beperk dit die grid
        'select type of payment
        Select Case Persoonl.BET_WYSE
            Case 1
                '  Me.optMonthlyCash.Checked = True
                strtipe_ontv = "MK"
                lblPaymenttype.Text = "Monthly Cash"
                'tctrlTransaksies.TabPages.Remove(tpageTermPolicy)
            Case 3
                ' Me.optMonthlySalary.Checked = True
                strtipe_ontv = "MS"
                lblPaymenttype.Text = "Monthly Salary"
                '  tctrlTransaksies.TabPages.Remove(tpageTermPolicy)
            Case 4
                'Me.optMonthlyDebit.Checked = True
                strtipe_ontv = "MD"
                lblPaymenttype.Text = "Monthly Debit"
                '   tctrlTransaksies.TabPages.Remove(tpageTermPolicy)
            Case 5
                ' Me.optMonthlyElectronic.Checked = True
                strtipe_ontv = "ME"
                lblPaymenttype.Text = "Monthly Electronic"
                '   tctrlTransaksies.TabPages.Remove(tpageTermPolicy)
            Case 6
                ' Me.optTermPolicy.Checked = True
                strtipe_ontv = "LT"
                lblPaymenttype.Text = "Term Policy"
                'Andriette 09/06/2014 skuif na die frmkontantdetail
                '  Me.GrpBxTerm.Enabled = True
                ' tctrlTransaksies.TabPages.Add(tpageTermPolicy)
                frmKntPopulateTermPolicyTab()
                cmbTermPeriods.SelectedIndex = 0
                'Andriette 
                tctrlTransaksies.SelectedTab = tpageTermPolicy
            Case Else
                lblPaymenttype.Text = "Unknown"
                '  tctrlTransaksies.TabPages.Remove(tpageTermPolicy)
        End Select
        SetupGrid()

        frmkontantPopulateGrid()
        ' GetAllTransactions("AA")

        'If intVT > 0 Then
        '    MsgBox("This person has VT'd " & intVT & " times.")
        'End If
        arrVTCountandBalance = frmKontantKryVtDetails()
        If arrVTCountandBalance IsNot Nothing Then
            If arrVTCountandBalance.Length > 0 Then
                If arrVTCountandBalance(0) = 1 Then
                    MsgBox("The client has 1 unpaid and the outstanding balance is R" & FormatNumber(arrVTCountandBalance(1), 2).ToString)
                Else
                    MsgBox("The client has " & FormatNumber(arrVTCountandBalance(0), 0).ToString & " unpaids and the outstanding balance is R" & FormatNumber(arrVTCountandBalance(1), 2).ToString)

                End If
            End If
        End If
        blnEersteKeerIn = False
        Me.Cursor = System.Windows.Forms.Cursors.Default
        blnloading = False
        dgvMonetereTransaksies.ClearSelection()
        btnRegisterPayment.Enabled = False
        ' dgvMonetereTransaksies.
    End Sub

    Private Sub SetupGrid()
        dgvMonetereTransaksies.AutoGenerateColumns = False
        dgvMonetereTransaksies.ReadOnly = True
        dgvMonetereTransaksies.Enabled = True
    End Sub

    Public Sub frmkontantPopulateGrid()
        Dim strFilter As String = ""

        If optAllTransactions.Checked Then
            ' PopulateGrid("AA")
            dgvMonetereTransaksies.DataSource = GetAllTransactions("AA")
        ElseIf optFirstPayment.Checked Then
            '  PopulateGrid("EB")
            dgvMonetereTransaksies.DataSource = GetAllTransactions("EB")
        ElseIf optMonthlyCash.Checked Then
            '  PopulateGrid("MK")
            dgvMonetereTransaksies.DataSource = GetAllTransactions("MK")
        ElseIf optMonthlyDebit.Checked Then
            '   PopulateGrid("MD")
            dgvMonetereTransaksies.DataSource = GetAllTransactions("MD")
        ElseIf optMonthlyElectronic.Checked Then
            '  PopulateGrid("ME")
            dgvMonetereTransaksies.DataSource = GetAllTransactions("ME")
        ElseIf optMonthlySalary.Checked Then
            '  PopulateGrid("MS")
            dgvMonetereTransaksies.DataSource = GetAllTransactions("MS")
        ElseIf optOutstandingTransactions.Checked Then
            '  PopulateGrid("UA")
            dgvMonetereTransaksies.DataSource = GetAllTransactions("UA")
        ElseIf optPaybackPayment.Checked Then
            ' PopulateGrid("TB")
            dgvMonetereTransaksies.DataSource = GetAllTransactions("TB")
        ElseIf optPrepaidPayment.Checked Then
            '  PopulateGrid("VB")
            dgvMonetereTransaksies.DataSource = GetAllTransactions("VB")
        ElseIf optTermPolicy.Checked Then
            '   PopulateGrid("LT")
            dgvMonetereTransaksies.DataSource = GetAllTransactions("LT")
        ElseIf optVT.Checked Then
            '  PopulateGrid("VT")
            dgvMonetereTransaksies.DataSource = GetAllTransactions("VT")
        End If

        'Andriette 18/06/2014
        dgvMonetereTransaksies.Columns(6).HeaderText = "Receipt/" & vbCrLf & "Unpaid Reason"
        dgvMonetereTransaksies.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvMonetereTransaksies.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvMonetereTransaksies.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMonetereTransaksies.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMonetereTransaksies.Focus()
        dgvMonetereTransaksies.ClearSelection()

        btnRegisterPayment.Enabled = False
        btnCancelPayment.Enabled = False
        btnEditPayment.Enabled = False
    End Sub
    Private Function GetAllTransactions(ByVal strCat As String) As List(Of KontantEntity)
        Dim params() As SqlParameter
        Dim reader As SqlDataReader

        'Andriette 14/10/2013 verduideliking van die strCat kode
        'AA - Alle transaksies alle datums
        'AD - Alle transaksies met datum filter
        'UA - uitstaande transaksies alle datums
        'UD - uitstaande transaksies met datum filter

        intRow = 0
        dgvMonetereTransaksies.AutoGenerateColumns = False
        dgvMonetereTransaksies.DataSource = Nothing
        dgvMonetereTransaksies.Refresh()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                params = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                          New SqlParameter("@Category", SqlDbType.NVarChar), _
                          New SqlParameter("@Startdate", SqlDbType.DateTime), _
                          New SqlParameter("@end_date", SqlDbType.DateTime)}

                params(0).Value = Persoonl.POLISNO
                params(1).Value = strCat
                params(2).Value = dtpFrom.Value
                params(3).Value = dtpToDate.Value

                reader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchAlleTipesTransaksiesByPolisnoStatus]", params)
                Dim TransList As List(Of KontantEntity) = New List(Of KontantEntity)

                While reader.Read()
                    Dim item As KontantEntity = New KontantEntity()
                    'Andriette 14/10/2013 stel die begin datum vir die datum control
                    'If iposisie = -1 Then
                    '    dtpFrom.Value = reader("trans_dat")
                    'End If
                    'select type of payment
                    If reader("tipe") IsNot DBNull.Value Then
                        Select Case reader("tipe")
                            Case "1"
                                item.tipe = "MK"
                            Case "3"
                                item.tipe = "MS"
                            Case "4"
                                item.tipe = "MD"
                            Case "5"
                                item.tipe = "ME"
                            Case "6"
                                item.tipe = "LT"
                            Case Else
                                item.tipe = reader("tipe")
                        End Select
                    Else
                        strTipe_ontv = "VT"
                    End If

                    If reader("afsluit_dat") IsNot DBNull.Value Then
                        item.afsluit_dat = reader("afsluit_dat")
                    Else
                        item.afsluit_dat = Nothing
                    End If
                    If reader("premie") IsNot DBNull.Value Then
                        item.premie = FormatNumber(reader("premie"), 2)
                    Else
                        item.premie = 0
                    End If
                    If reader("vord_premie") IsNot DBNull.Value Then
                        item.vord_premie = FormatNumber(reader("vord_premie"), 2)
                    Else
                        item.vord_premie = 0
                    End If
                    If reader("kwitansie") IsNot DBNull.Value Then
                        item.kwitansie = reader("kwitansie")
                    Else
                        item.kwitansie = ""
                    End If
                    If reader("vord_dat") IsNot DBNull.Value Then
                        item.vord_dat = reader("vord_dat")
                    Else
                        item.vord_dat = Nothing
                    End If
                    If reader("trans_dat") IsNot DBNull.Value Then
                        item.trans_dat = reader("trans_dat")
                    Else
                        item.trans_dat = Nothing
                    End If
                    If reader("kontant_tipe") IsNot DBNull.Value Then
                        item.kontant_tipe = reader("kontant_tipe")
                        If item.tipe = "VT" And item.kontant_tipe = "1" Then
                            item.payment_beskrywing = "X"
                        Else
                            Select Case item.kontant_tipe
                                Case "E"
                                    item.payment_beskrywing = "Electronic"
                                Case "T"
                                    item.payment_beskrywing = "Cheque"
                                Case "K"
                                    item.payment_beskrywing = "Cash"
                                Case "0"
                                    item.payment_beskrywing = ""
                                Case Else
                                    'Andriette 01/07/2014 laai die kontant_tipe weer in
                                    item.payment_beskrywing = item.kontant_tipe
                            End Select
                        End If
                    Else
                        item.kontant_tipe = ""
                    End If
                    'Andriette 13/06/2014
                    If reader("Jaar") IsNot DBNull.Value Then
                        item.jaar = reader("Jaar")
                    Else
                        item.jaar = ""
                    End If

                    If reader("Maand") IsNot DBNull.Value Then
                        item.maand = reader("Maand")
                    Else
                        item.maand = ""
                    End If
                    'Andriette 18/06/2014 memo

                    If reader("verw1") IsNot DBNull.Value Then
                        item.verw1 = reader("verw1")
                    Else
                        item.verw1 = ""
                    End If

                    If reader("verw2") IsNot DBNull.Value Then
                        item.verw2 = reader("verw2")
                    Else
                        item.verw2 = ""
                    End If

                    If reader("verw3") IsNot DBNull.Value Then
                        item.verw3 = reader("verw3")
                    Else
                        item.verw3 = ""
                    End If

                    If reader("verw4") IsNot DBNull.Value Then
                        item.verw4 = reader("verw4")
                    Else
                        item.verw4 = ""
                    End If

                    If reader("verw5") IsNot DBNull.Value Then
                        item.verw5 = reader("verw5")
                    Else
                        item.verw5 = ""
                    End If
                    'Andriette 02/07/2014 voeg die tabel naam en die pk waarde by
                    If reader("pkwaarde") IsNot DBNull.Value Then
                        item.pk_waarde = reader("pkwaarde")
                    Else
                        item.pk_waarde = ""
                    End If
                    If reader("tabel") IsNot DBNull.Value Then
                        item.tabel = reader("tabel")
                    Else
                        item.tabel = ""
                    End If
                    TransList.Add(item)
                End While
                Return TransList
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function
    Private Sub optFirstPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optFirstPayment.CheckedChanged
        If Not blnloading Then
            If optFirstPayment.Checked Then


                strtipe_ontv = "EB"
                'optAllTransactions.Checked = False
                'optMonthlyCash.Checked = False
                'optMonthlyDebit.Checked = False
                'optMonthlyElectronic.Checked = False
                'optMonthlySalary.Checked = False
                'optOutstandingTransactions.Checked = False
                'optPaybackPayment.Checked = False
                'optPrepaidPayment.Checked = False
                'optTermPolicy.Checked = False
                'optVT.Checked = False
                frmkontantPopulateGrid()
                'Else
                '    optFirstPayment.Checked = False
                btnRegisterPayment.Enabled = True
            End If
        End If

    End Sub

    Private Sub optPrepaidPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPrepaidPayment.CheckedChanged
        If Not blnloading Then
            If optPrepaidPayment.Checked Then
                strtipe_ontv = "VB"
                'optAllTransactions.Checked = False
                'optFirstPayment.Checked = False
                'optMonthlyCash.Checked = False
                'optMonthlyDebit.Checked = False
                'optMonthlyElectronic.Checked = False
                'optMonthlySalary.Checked = False
                'optOutstandingTransactions.Checked = False
                'optPaybackPayment.Checked = False
                'optTermPolicy.Checked = False
                'optVT.Checked = False
                frmkontantPopulateGrid()
                btnRegisterPayment.Enabled = True
            Else
                optPrepaidPayment.Checked = False
            End If
        End If

    End Sub

    Private Sub optPaybackPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPaybackPayment.CheckedChanged
        If Not blnloading Then
            If optPaybackPayment.Checked Then
                strtipe_ontv = "TB"
                'optAllTransactions.Checked = False
                'optFirstPayment.Checked = False
                'optMonthlyCash.Checked = False
                'optMonthlyDebit.Checked = False
                'optMonthlyElectronic.Checked = False
                'optMonthlySalary.Checked = False
                'optOutstandingTransactions.Checked = False
                'optPrepaidPayment.Checked = False
                'optTermPolicy.Checked = False
                'optVT.Checked = False
                frmkontantPopulateGrid()
                btnRegisterPayment.Enabled = True
            Else
                optPaybackPayment.Checked = False
            End If
        End If
    End Sub

    Private Sub cmdRegisterPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not blnloading Then
        End If
    End Sub

    Private Sub optMonthlyDebit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMonthlyDebit.CheckedChanged
        If Not blnloading Then
            If optMonthlyDebit.Checked Then

                strtipe_ontv = "MD"
                optAllTransactions.Checked = False
                optFirstPayment.Checked = False
                optMonthlyCash.Checked = False
                'optMonthlyDebit.Checked = False
                optMonthlyElectronic.Checked = False
                optMonthlySalary.Checked = False
                optOutstandingTransactions.Checked = False
                optPaybackPayment.Checked = False
                optPrepaidPayment.Checked = False
                optTermPolicy.Checked = False
                optVT.Checked = False
                frmkontantPopulateGrid()
            Else
                optMonthlyDebit.Checked = False
            End If
        End If
    End Sub

    Private Sub optMonthlyCash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMonthlyCash.CheckedChanged
        If Not blnloading Then
            If optMonthlyCash.Checked Then
                optAllTransactions.Checked = False
                optFirstPayment.Checked = False
                optMonthlyDebit.Checked = False
                optMonthlyElectronic.Checked = False
                optMonthlySalary.Checked = False
                optOutstandingTransactions.Checked = False
                optPaybackPayment.Checked = False
                optPrepaidPayment.Checked = False
                optTermPolicy.Checked = False
                optVT.Checked = False
                strtipe_ontv = "MK"
                frmkontantPopulateGrid()
            Else
                optMonthlyCash.Checked = False
            End If
        End If
    End Sub

    Private Sub optMonthlySalary_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMonthlySalary.CheckedChanged
        If Not blnloading Then
            If optMonthlySalary.Checked Then
                optAllTransactions.Checked = False
                optFirstPayment.Checked = False
                optMonthlyCash.Checked = False
                optMonthlyDebit.Checked = False
                optMonthlyElectronic.Checked = False
                'optMonthlySalary.Checked = False
                optOutstandingTransactions.Checked = False
                optPaybackPayment.Checked = False
                optPrepaidPayment.Checked = False
                optTermPolicy.Checked = False
                optVT.Checked = False
                strtipe_ontv = "MS"
                frmkontantPopulateGrid()
            Else
                optMonthlySalary.Checked = False
            End If
        End If
    End Sub

    Private Sub optMonthlyElectronic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMonthlyElectronic.CheckedChanged
        If Not blnloading Then
            If optMonthlyElectronic.Checked Then
                optAllTransactions.Checked = False
                optFirstPayment.Checked = False
                optMonthlyCash.Checked = False
                optMonthlyDebit.Checked = False
                'optMonthlyElectronic.Checked = False
                optMonthlySalary.Checked = False
                optOutstandingTransactions.Checked = False
                optPaybackPayment.Checked = False
                optPrepaidPayment.Checked = False
                optTermPolicy.Checked = False
                optVT.Checked = False
                strtipe_ontv = "ME"

                'Andriette 09/06/2014 skuif na die frmkontantdetail
                'Me.GrpBxTerm.Enabled = False
                frmkontantPopulateGrid()
            Else
                optMonthlyElectronic.Checked = False
            End If
        End If
    End Sub


    Private Sub optVT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optVT.CheckedChanged
        If Not blnloading Then
            If optVT.Checked Then
                strtipe_ontv = "VT"
                'Andriette 09/06/2014 skuif na die frmkontantdetail
                'Me.GrpBxTerm.Enabled = False
                optAllTransactions.Checked = False
                optFirstPayment.Checked = False
                optMonthlyCash.Checked = False
                optMonthlyDebit.Checked = False
                optMonthlyElectronic.Checked = False
                optMonthlySalary.Checked = False
                optOutstandingTransactions.Checked = False
                optPaybackPayment.Checked = False
                optPrepaidPayment.Checked = False
                optTermPolicy.Checked = False
                ' optVT.Checked = False
                frmkontantPopulateGrid()
            Else
                optVT.Checked = False
            End If
        End If
    End Sub

    Private Sub optTermPolicy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTermPolicy.CheckedChanged
        If Not blnloading Then
            If optTermPolicy.Checked Then
                optAllTransactions.Checked = False
                optFirstPayment.Checked = False
                optMonthlyCash.Checked = False
                optMonthlyDebit.Checked = False
                optMonthlyElectronic.Checked = False
                optMonthlySalary.Checked = False
                optOutstandingTransactions.Checked = False
                optPaybackPayment.Checked = False
                optPrepaidPayment.Checked = False
                'optTermPolicy.Checked = False
                optVT.Checked = False
                strtipe_ontv = "LT"
                frmkontantPopulateGrid()
            Else
                optTermPolicy.Checked = False
            End If

        End If
    End Sub

    Private Sub cmdGetTransactions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.dgvMonetereTransaksies.DataSource = Nothing
        Me.dgvMonetereTransaksies.Refresh()
        intRow = 0
        frmkontantPopulateGrid()

    End Sub

    Private Sub GetKwitansieNr()
        'kry volgende kwitansienr 
        Dim readers As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchKwitansienr]")

        While readers.Read
            intKwit_nr = CDbl(readers("volg_nr")) + 1
        End While

        If intKwit_nr > 0 Then
            'kry volgende kwitansienr 
            Dim param() As SqlParameter = {New SqlParameter("@volg_nr", SqlDbType.NVarChar)}
            param(0).Value = intKwit_nr

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[UpdateKwitansienr]", param)

        End If
    End Sub

    Private Sub getBranch()

        Dim readers As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchTak]")
        While readers.Read
            strTaknaam = readers("tak_naam")
            strTakafkorting = readers("tak_afkorting")
            Exit Sub
        End While
    End Sub

    ' Andriette 23/05/2013 skep die kode vir die vertoon van uitstaande transaksies
    Private Sub optOutstandingTransactions_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optOutstandingTransactions.CheckedChanged
        ' 
        '   Dim strTipe_ontv As String
        If Not blnloading Then
            If optOutstandingTransactions.Checked Then
                optAllTransactions.Checked = False
                optFirstPayment.Checked = False
                optMonthlyCash.Checked = False
                optMonthlyDebit.Checked = False
                optMonthlyElectronic.Checked = False
                optMonthlySalary.Checked = False
                optPaybackPayment.Checked = False
                optPrepaidPayment.Checked = False
                optTermPolicy.Checked = False
                optVT.Checked = False
                frmkontantPopulateGrid()
            Else
                optOutstandingTransactions.Checked = False
            End If
        End If

    End Sub

    Private Sub optAllTransactions_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optAllTransactions.CheckedChanged
        'If Not EersteKeerIn Then
        '    GetAllTransactions("A")
        'End If
        'Andriette 14/102013 verander 
        If Not blnloading Then
            If optAllTransactions.Checked Then
                optFirstPayment.Checked = False
                optMonthlyCash.Checked = False
                optMonthlyDebit.Checked = False
                optMonthlyElectronic.Checked = False
                optMonthlySalary.Checked = False
                optOutstandingTransactions.Checked = False
                optPaybackPayment.Checked = False
                optPrepaidPayment.Checked = False
                optTermPolicy.Checked = False
                optVT.Checked = False
                frmkontantPopulateGrid()
            Else
                optAllTransactions.Checked = False
            End If
        End If

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    'Andriette 13/06/2014
    Private Function frmKontantKryVtDetails() As Array
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Andriette 30/06/2014 haal ekstra params uit
                Dim params = {New SqlParameter("@POLISNO", SqlDbType.NVarChar)} ', _
                '  New SqlParameter("@voorl", SqlDbType.NVarChar), _
                '   New SqlParameter("@Versekerde", SqlDbType.NVarChar)}
                params(0).Value = glbPolicyNumber
                ' params(1).Value = ""  'Persoonl.VOORL"
                ' params(2).Value = "" 'persoonl.versekerde
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaand_Balans]", params)
                If reader.HasRows Then
                    Dim vtdetails(2) As String
                    If reader.Read Then
                        If reader("vt_aant") IsNot DBNull.Value Then
                            vtdetails(0) = FormatNumber(reader("vt_aant"), 0).ToString
                        End If
                        If reader("vt_balans") IsNot DBNull.Value Then
                            vtdetails(1) = FormatNumber(reader("vt_balans"), 2).ToString
                        End If
                        Return vtdetails
                        Exit Function
                    End If
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)

        End Try
        Return Nothing
    End Function

    Private Sub dtpFrom_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFrom.ValueChanged
        frmkontantPopulateGrid()
    End Sub

    Private Sub dtpToDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpToDate.ValueChanged
        frmkontantPopulateGrid()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        frmkontantDetail.ShowDialog()
    End Sub

    'Andriette 26/06/2014 maak die datum veld skoon as dit die default datum in het

    Private Sub dgvMonetereTransaksies_DataBindingComplete(sender As Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvMonetereTransaksies.DataBindingComplete
        Dim strDate As String
        '   Dim strTransDat As String

        For intitem = 0 To dgvMonetereTransaksies.RowCount - 1
            strDate = dgvMonetereTransaksies.Rows(intitem).Cells("vord_dat").Value
            If strDate = "01/01/1900" Then
                dgvMonetereTransaksies.Rows(intitem).Cells("vord_dat").Value = ""
            End If

            'For nInskrywing = 0 To dgvAmendments.RowCount - 1
            '    strDate = dgvAmendments.Rows(nInskrywing).Cells("DateTime").Value
            '    dgvAmendments.Rows(nInskrywing).Cells("Wysdatum").Value = String.Format(strDate, "{0:dd/mm/yyyy  HH:MM:SS}")


            '     strTransDat = DataGridView1.Rows(item).Cells("trans_dat").Value
            '    DataGridView1.Rows(item).Cells("trans_dat").Value = String.Format(strTransDat, "{0:dd/mm/yyyy  HH:MM:SS}")
            'DataGridView1.Rows(item).Cells("trans_dat").Value = strTransDat
            dgvMonetereTransaksies.Rows(intitem).Cells("memoall").Value = dgvMonetereTransaksies.Rows(intitem).Cells("memo1").Value.ToString.Trim
            If dgvMonetereTransaksies.Rows(intitem).Cells("memo2").Value.ToString.Trim.Length > 0 Then
                dgvMonetereTransaksies.Rows(intitem).Cells("memoall").Value = dgvMonetereTransaksies.Rows(intitem).Cells("memoall").Value & " " & _
                dgvMonetereTransaksies.Rows(intitem).Cells("memo2").Value.ToString.Trim
            End If
            If dgvMonetereTransaksies.Rows(intitem).Cells("memo3").Value.ToString.Trim.Length > 0 Then
                dgvMonetereTransaksies.Rows(intitem).Cells("memoall").Value = dgvMonetereTransaksies.Rows(intitem).Cells("memoall").Value & " " & _
                dgvMonetereTransaksies.Rows(intitem).Cells("memo3").Value.ToString.Trim
            End If
            If dgvMonetereTransaksies.Rows(intitem).Cells("memo4").Value.ToString.Trim.Length > 0 Then
                dgvMonetereTransaksies.Rows(intitem).Cells("memoall").Value = dgvMonetereTransaksies.Rows(intitem).Cells("memoall").Value & " " & _
                dgvMonetereTransaksies.Rows(intitem).Cells("memo4").Value.ToString.Trim
            End If
            If dgvMonetereTransaksies.Rows(intitem).Cells("memo5").Value.ToString.Trim.Length > 0 Then
                dgvMonetereTransaksies.Rows(intitem).Cells("memoall").Value = dgvMonetereTransaksies.Rows(intitem).Cells("memoall").Value & " " & _
                dgvMonetereTransaksies.Rows(intitem).Cells("memo5").Value.ToString.Trim
            End If
        Next


    End Sub

    'Andriette 01/07/2014 
    ' Wanneer dit ;n termyn polis is word die termynpolis se tab oopgemaak
    ' 01/07/2014
    ' Vul die termynpolisinligting

    Private Sub frmKntPopulateTermPolicyTab()
        FrmKntPopulateTermynDates()
        dgrTermynPolisse.DataSource = FetchTermynBetalings()

    End Sub

    Private Sub FrmKntPopulateTermynDates()
        Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
        Dim dtDatumBegin As DateTime
        Dim dtDatumEindig As DateTime
        Dim intTydperk As Integer
        Dim strTermynDates As String

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Andriette 30/06/2014 haal ekstra params uit
                param.Value = glbPolicyNumber
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[GetLangtermynpolisByDatumEinding]", param)
                If reader.HasRows Then

                    While reader.Read

                        If reader("DatumBegin") IsNot DBNull.Value Then
                            dtDatumBegin = reader("DatumBegin")
                        End If

                        If reader("DatumEindig") IsNot DBNull.Value Then
                            dtDatumEindig = reader("DatumEindig")
                        End If

                        If reader("tydperk") IsNot DBNull.Value Then
                            intTydperk = reader("tydperk")
                        End If

                        strTermynDates = dtDatumBegin.ToString & " - " & dtDatumEindig.ToString & " (" & intTydperk.ToString & " months)"
                        cmbTermPeriods.Items.Add(strTermynDates)

                    End While
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Function FetchTermynBetalings()
        Dim dteTermynBegin As Date
        Dim dteTermynEindig As Date
        Dim intMaande As Integer
        Dim intpkTermyn As Integer
        Dim intPolisno As Integer
        Dim arrBetalings() As Array
        Dim arrMaand() As Array
        Dim TranDetail()


        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim paramFetchPolisse As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                paramFetchPolisse.Value = glbPolicyNumber
                Dim readerPolis As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchLangtermynPolisPolisno", paramFetchPolisse)
                If readerPolis.HasRows Then
                    Do While readerPolis.Read
                        ' kry die aantal maande
                        If readerPolis("DatumBegin") IsNot DBNull.Value Then
                            dteTermynBegin = readerPolis("DatumBegin")
                        Else
                            dteTermynBegin = "1900/01/01"
                        End If
                        If readerPolis("DatumEindig") IsNot DBNull.Value Then
                            dteTermynEindig = readerPolis("DatumEindig")
                        Else
                            dteTermynEindig = "1900/01/01"
                        End If
                        If readerPolis("Tydperk") IsNot DBNull.Value Then
                            intMaande = readerPolis("Tydperk")
                        Else
                            intMaande = 0
                        End If

                        If Not readerPolis("pklangtermynpolis") IsNot DBNull.Value Then
                            intpkTermyn = readerPolis("pklangtermynpolis")
                        Else
                            intpkTermyn = 0
                        End If

                        If Not readerPolis("Polisno") IsNot DBNull.Value Then
                            intPolisno = readerPolis("Polisno")
                        Else
                            intPolisno = 0
                        End If

                        arrBetalings = FetchTermynDetail(intPolisno, dteTermynBegin, dteTermynBegin, intMaande, intpkTermyn)
                        arrMaand = FetchTermynMaand()

                    Loop
                End If
                ' kry al die termyn inskrywings vir die persoon in descending order


                ' vir elke inskrywing wat terugkom, kry al die betalings reeds gedoen
                ' vir elke maand in die reeds betaal skep ;n inskrywing 

                If conn.State = ConnectionState.Open Then
                    conn.Close()

                End If
            End Using


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Return Nothing
    End Function

    Private Function FetchTermynDetail(intPolisno, dteTermynBegin, dteTermynEindig, intTermynMaand, pkTermyn)
        ' Kry al die inskrywings op kontant wat reeds gedoen is
        Dim arrbetalings(0) As Array
        Dim arrBetaalDetail(9)
        Dim intTel As Integer = 0

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim paramKontantTrans = {New SqlParameter("@vanaf", SqlDbType.Date), _
                                         New SqlParameter("@tot", SqlDbType.Date), _
                                         New SqlParameter("@POLISNO", SqlDbType.NVarChar)}

                paramKontantTrans(0).Value = dteTermynBegin
                paramKontantTrans(1).Value = dteTermynBegin
                paramKontantTrans(2).Value = intPolisno

                Dim readerKontant As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchKontantByTrans_Dat", paramKontantTrans)
                If readerKontant.HasRows Then
                    Do While readerKontant.Read
                        arrBetaalDetail(0) = ""
                        If readerKontant("LTPtipe") IsNot DBNull.Value Then
                            arrBetaalDetail(1) = readerKontant("LTPtipe")
                        Else
                            arrBetaalDetail(1) = ""
                        End If
                        If readerKontant("Vord_premie") IsNot DBNull.Value Then
                            arrBetaalDetail(2) = readerKontant("vord_remie")
                        Else
                            arrBetaalDetail(2) = FormatNumber(0, 2)
                        End If
                        If readerKontant("trans_dat") IsNot DBNull.Value Then
                            arrBetaalDetail(3) = readerKontant("trans_dat")
                        Else
                            arrBetaalDetail(3) = "1900/01/01"
                        End If
                        arrBetaalDetail(4) = 0
                        arrBetaalDetail(5) = 0
                        arrBetaalDetail(6) = 0
                        arrBetaalDetail(7) = "Kontant"
                        If readerKontant("pkKontant") IsNot DBNull.Value Then
                            arrBetaalDetail(8) = readerKontant("pkKontant")
                        Else
                            arrBetaalDetail(8) = 0
                        End If
                        intTel = intTel + 1
                        If intTel <> 0 Then
                            ReDim Preserve arrbetalings(intTel)
                        Else
                            intTel = intTel - 1
                        End If

                        arrbetalings(intTel) = arrBetaalDetail
                    Loop
                End If

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If

            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Return arrbetalings
    End Function

    Private Function FetchTermynMaand()
        Dim aMaand() As Array
        Dim aMaandDetails(9)

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection




                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try



        Return aMaand
    End Function


    'Andriette 01/07/2014 Vul die velde met die selected change
    Private Sub cmbTermPeriods_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbTermPeriods.SelectedIndexChanged
        Dim strDateBegin As String
        Dim strDateEnd As String
        Dim params() As SqlParameter
        Dim reader As SqlDataReader
        strDateBegin = cmbTermPeriods.SelectedItem.ToString.Substring(0, 10).ToString
        strDateEnd = cmbTermPeriods.SelectedItem.ToString.Substring(23, 10).ToString
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                params = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                          New SqlParameter("@Category", SqlDbType.NVarChar), _
                          New SqlParameter("@Startdate", SqlDbType.DateTime), _
                          New SqlParameter("@end_date", SqlDbType.DateTime)}

                params(0).Value = Persoonl.POLISNO
                params(1).Value = "LT"
                params(2).Value = strDateBegin
                params(3).Value = strDateEnd

                reader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchAlleTipesTransaksiesByPolisnoStatus]", params)
                If reader.HasRows Then
                    Dim TransList As List(Of KontantEntity) = New List(Of KontantEntity)

                    While reader.Read()
                        Dim item As KontantEntity = New KontantEntity()
                        'transaksie datum
                        If reader("trans_dat") IsNot DBNull.Value Then
                            item.trans_dat = reader("trans_dat")
                        End If

                        If reader("premie") IsNot DBNull.Value Then
                            item.premie = FormatNumber(reader("premie"), 2)
                        Else
                            item.premie = 0
                        End If

                        If reader("vord_premie") IsNot DBNull.Value Then
                            item.vord_premie = FormatNumber(reader("vord_premie"), 2)
                        Else
                            item.vord_premie = 0
                        End If
                        If reader("kontant_tipe") IsNot DBNull.Value Then
                            item.kontant_tipe = reader("kontant_tipe")
                        Else
                            item.kontant_tipe = ""
                        End If
                        TransList.Add(item)
                    End While

                    dgrTermynPolisse.DataSource = TransList

                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    'Andriette 01/07/2014 
    Private Sub dgrTermynPolisse_DataBindingComplete(sender As Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgrTermynPolisse.DataBindingComplete

        Dim strbegindatum As String
        Dim strenddatum As String
        Dim strbeginmaand As String
        Dim strendmaand As String
        Dim strbeginjaar As String
        Dim strendjaar As String
        Dim strteller As String = cmbTermPeriods.SelectedItem.ToString.Substring(43, 2).ToString
        Dim intTeller As Integer
        strbegindatum = cmbTermPeriods.SelectedItem.ToString.Substring(0, 10).ToString
        strenddatum = cmbTermPeriods.SelectedItem.ToString.Substring(22, 10).ToString
        strbeginmaand = strbegindatum.Substring(3, 2)
        strbeginjaar = strbegindatum.Substring(6, 4)
        strendmaand = strenddatum.Substring(3, 2)
        strendjaar = strenddatum.Substring(6, 4)
        For maande = dgrTermynPolisse.RowCount To 1 Step -1
            '      dgrTermynPolisse.Item(5, maande).Value = strteller
            intTeller = Val(strteller) - 1
            strteller = intTeller.ToString
        Next

    End Sub

    Private Sub btnRegisterPayment_Click(sender As System.Object, e As System.EventArgs) Handles btnRegisterPayment.Click
        blnNuweBetaling = True
        blnWisBetaling = False
        blnWysigBetaling = False
        frmkontantDetail.ShowDialog()
    End Sub


    Private Sub btnEditPayment_Click(sender As System.Object, e As System.EventArgs) Handles btnEditPayment.Click
        blnNuweBetaling = False
        blnWisBetaling = False
        blnWysigBetaling = True
        frmkontantDetail.ShowDialog()
    End Sub

    Private Sub btnCancelPayment_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelPayment.Click
        Dim intantwoord As Integer
        Dim arrVeldName(2) As String
        Dim arrVeldwaardes(2) As String
        '   Dim dteVt_Trans_Dat As Date
        Dim blnsukses As Boolean = True
        '    Dim param() As SqlParameter
        intantwoord = MsgBox("Are you sure you want to delete this transaction? ", MsgBoxStyle.YesNoCancel, )
        If intantwoord = DialogResult.Yes Then
            'updatekontanttabeltransaksie() 
            blnWisBetaling = True
            blnWysigBetaling = False
            blnNuweBetaling = False
            FrmKontantVulVelde()
            KontantItem.gekans = 1
            KontantItem.trans_dat = Now
            KontantItem.kans_dat = Now
            SaveKontantTransaksie(dgvMonetereTransaksies.SelectedRows(0).Cells(0).Value)

            ' As die betaling vir 'n VT was
            If dgvMonetereTransaksies.SelectedRows(0).Cells(2).Value = "VT" Then
                ' Kry die transaksie datum van die kontant tabel af
                '  dteVt_Trans_Dat = KontantVt_Trans_dat(dgvMonetereTransaksies.SelectedRows(0).Cells(17).Value)
                arrVeldName(0) = "vt_ingevorder"
                arrVeldName(1) = "vt_vord_datum"
                arrVeldName(2) = "kwit_boek"
                arrVeldwaardes(0) = (dgvMonetereTransaksies.SelectedRows(0).Cells(5).Value * -1)
                arrVeldwaardes(1) = ""
                arrVeldwaardes(2) = ""
                blnsukses = UpdateMaand_vt_details(arrVeldName, arrVeldwaardes, dgvMonetereTransaksies.SelectedRows(0).Cells(0).Value, dgvMonetereTransaksies.SelectedRows(0).Cells(1).Value)
                If blnsukses Then
                    UpdateMaandVtBalans(dgvMonetereTransaksies.SelectedRows(0).Cells(5).Value * -1)
                    UpdateMaandDetails(Now(), dgvMonetereTransaksies.SelectedRows(0).Cells(5).Value, Now(), "", dgvMonetereTransaksies.SelectedRows(0).Cells(1).Value, dgvMonetereTransaksies.SelectedRows(0).Cells(0).Value)
                End If

            End If
            frmkontantPopulateGrid()
        End If
    End Sub


    Private Sub dgvMonetereTransaksies_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMonetereTransaksies.RowEnter
        If Not blnloading Then
            If dgvMonetereTransaksies.SelectedRows.Count > 0 Then
                If dgvMonetereTransaksies.SelectedRows(0).Cells(18).Value.ToString.ToUpper = "KONTANT" Then
                    'Me.Grid1.SelectedCells.Item(0).Value
                    btnEditPayment.Enabled = True
                    btnCancelPayment.Enabled = True
                Else
                    btnEditPayment.Enabled = False
                    btnCancelPayment.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub dgvMonetereTransaksies_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvMonetereTransaksies.SelectionChanged
        If Not blnloading Then
            If dgvMonetereTransaksies.SelectedRows.Count > 0 Then
                If ToetsAfsluitDatum() Then
                    btnEditPayment.Enabled = True
                    btnCancelPayment.Enabled = True
                Else
                    btnEditPayment.Enabled = False
                    btnCancelPayment.Enabled = False
                End If
                btnRegisterPayment.Enabled = True
            Else
                btnRegisterPayment.Enabled = False
            End If
        End If
    End Sub

    Private Function ToetsAfsluitDatum() As Boolean
        Dim blnKanEdit As Boolean = False
        If dteLaasteAfsluit = "1900/01/01" Then
            Try
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim reader As SqlDataReader
                    reader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5d.FetchAfsluitDatumLaaste")
                    If reader.HasRows Then
                        If reader.Read() Then
                            dteLaasteAfsluit = reader("afsluit_Dat")
                        End If
                    End If

                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
        If dgvMonetereTransaksies.SelectedRows(0).Cells(8).Value >= dteLaasteAfsluit Then
            blnKanEdit = True
        Else
            blnKanEdit = False
        End If
        Return blnKanEdit
    End Function

    Private Sub updatekontanttabeltransaksie()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                New SqlParameter("@Trans_dat", SqlDbType.DateTime)}

                params(0).Value = glbPolicyNumber
                params(1).Value = dgvMonetereTransaksies.SelectedRows(0).Cells(8).Value

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Stats5.UpdateKontantAndRecord", params)

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Public Function UpdateMaand_vt_details(ByVal aFieldsToChange() As String, ByVal aValues() As String, ByVal intJaar As Integer, intMaand As Integer)
        Dim dteDatumaangevra As Date = "01/01/1900"
        Dim dblvt_bedrag As Double = 0, dblVt_Ingevorder As Double = 0
        Dim strvt_kwitansie As String = "", strvt_takkode As String = "", strvt_reknr As String = "", strVt_Rede As String = "", strKwit_BoekVT As String = ""
        Dim intVt_kode As Integer = 0, intVTJaar As Integer = 0, intVTMaand As Integer = 0, intPK_Maandvtdet As Integer = 0
        Dim dtevt_Vord_Datum As Date = "01/01/1900", dtevt_datum As Date = "01/01/1900"
        Dim blnX As Boolean = False
        Dim blnDatumAangevraNull As Boolean = False
        Dim dteafsluit_dat, dtetrans_dat As Date
        Dim intPlekGevind As Integer = -1
        Dim blnvord_DatumNull As Boolean = False
        Dim blnVT_DatumNull As Boolean = False
        Dim blnTrans_DatNull As Boolean = False
        Dim blnAfsluit_datNull As Boolean = False
        Dim blnsukses As Boolean = True

        Try
            Dim params() As SqlParameter = {New SqlParameter("@POLISNO ", SqlDbType.NVarChar), _
                                            New SqlParameter("@jaar", SqlDbType.Int), _
                                           New SqlParameter("@maand", SqlDbType.Int)}
            'New SqlParameter("@TransDat", SqlDbType.DateTime)}
            Using conn As SqlConnection = SqlHelper.GetConnection

                params(0).Value = glbPolicyNumber
                params(1).Value = intJaar
                params(2).Value = intMaand
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchVT_DetailsByTransDat_delete]", params)

                If reader.HasRows Then
                    If reader.Read Then
                        '  aFieldsToChange.FindIndex()
                        intPlekGevind = Array.FindIndex(aFieldsToChange, Function(s) s.ToString.ToUpper = "DATUMAANGEVRA")
                        If intPlekGevind > -1 Then
                            If aValues(intPlekGevind) Is DBNull.Value Or aValues(intPlekGevind) = "" Then
                                blnDatumAangevraNull = True
                            Else
                                dteDatumaangevra = aValues(intPlekGevind)
                            End If
                        Else
                            If reader("Datumaangevra") Is DBNull.Value Then
                                blnDatumAangevraNull = True
                                If reader("Vt_Datum") IsNot DBNull.Value Then
                                    dteDatumaangevra = reader("Vt_Datum")
                                End If
                            Else
                                dteDatumaangevra = reader("Datumaangevra")
                            End If
                        End If

                        intPlekGevind = Array.FindIndex(aFieldsToChange, Function(s) s.ToString.ToUpper = "VT_BEDRAG")
                        If intPlekGevind > -1 Then
                            dblvt_bedrag = aValues(intPlekGevind)
                        Else
                            If reader("VT_Bedrag") Is DBNull.Value Then
                                dblvt_bedrag = 0
                            Else
                                dblvt_bedrag = reader("VT_Bedrag")
                            End If
                        End If

                        intPlekGevind = Array.FindIndex(aFieldsToChange, Function(s) s.ToString.ToUpper = "VT_INGEVORDER")
                        If intPlekGevind > -1 Then
                            dblVt_Ingevorder = aValues(intPlekGevind)
                        End If

                        If reader("VT_Ingevorder") Is DBNull.Value Then
                            dblVt_Ingevorder = 0 + dblVt_Ingevorder
                        Else
                            dblVt_Ingevorder = reader("VT_Ingevorder") + dblVt_Ingevorder
                        End If

                        intPlekGevind = Array.FindIndex(aFieldsToChange, Function(s) s.ToString.ToUpper = "VT_KWITANSIE")
                        If intPlekGevind > -1 Then
                            strvt_kwitansie = aValues(intPlekGevind)
                        Else
                            If reader("VT_Kwitansie") Is DBNull.Value Then
                                strvt_kwitansie = ""
                            Else
                                strvt_kwitansie = reader("VT_Kwitansie")
                            End If
                        End If

                        intPlekGevind = Array.FindIndex(aFieldsToChange, Function(s) s.ToString.ToUpper = "VT_TAKKODE")
                        If intPlekGevind > -1 Then
                            strvt_takkode = aValues(intPlekGevind)
                        Else
                            If reader("VT_Takkode") Is DBNull.Value Then
                                strvt_takkode = ""
                            Else
                                strvt_takkode = reader("VT_Takkode")
                            End If
                        End If

                        intPlekGevind = Array.FindIndex(aFieldsToChange, Function(s) s.ToString.ToUpper = "VT_REKNR")
                        If intPlekGevind > -1 Then
                            strvt_reknr = aValues(intPlekGevind)
                        Else
                            If reader("VT_Reknr") Is DBNull.Value Then
                                strvt_reknr = ""
                            Else
                                strvt_reknr = reader("VT_Reknr")
                            End If
                        End If

                        intPlekGevind = Array.FindIndex(aFieldsToChange, Function(s) s.ToString.ToUpper = "VT_REDE")
                        If intPlekGevind > -1 Then
                            strVt_Rede = aValues(intPlekGevind)
                        Else
                            If reader("VT_Rede") Is DBNull.Value Then
                                strVt_Rede = ""
                            Else
                                strVt_Rede = reader("VT_Rede")
                            End If
                        End If

                        intPlekGevind = Array.FindIndex(aFieldsToChange, Function(s) s.ToString.ToUpper = "KWIT_BOEK")

                        If intPlekGevind > -1 Then
                            strKwit_BoekVT = aValues(intPlekGevind)
                        Else
                            If reader("Kwit_Boek") Is DBNull.Value Then
                                strKwit_BoekVT = ""
                            Else
                                strKwit_BoekVT = reader("Kwit_Boek")
                            End If
                        End If

                        intPlekGevind = Array.FindIndex(aFieldsToChange, Function(s) s.ToString.ToUpper = "VT_KODE")
                        If intPlekGevind > -1 Then
                            intVt_kode = aValues(intPlekGevind)
                        Else
                            If reader("VT_Kode") Is DBNull.Value Then
                                intVt_kode = 0
                            Else
                                intVt_kode = reader("VT_Kode")
                            End If
                        End If

                        intPlekGevind = Array.FindIndex(aFieldsToChange, Function(s) s.ToString.ToUpper = "JAAR")
                        If intPlekGevind > -1 Then
                            intVTJaar = aValues(intPlekGevind)
                        Else
                            If reader("JAAR") Is DBNull.Value Then
                                intVTJaar = 0
                            Else
                                intVTJaar = reader("JAAR")
                            End If
                        End If

                        intPlekGevind = Array.FindIndex(aFieldsToChange, Function(s) s.ToString.ToUpper = "MAAND")
                        If intPlekGevind > -1 Then
                            intVTMaand = aValues(intPlekGevind)
                        Else
                            If reader("Maand") Is DBNull.Value Then
                                intVTMaand = 0
                            Else
                                intVTMaand = reader("Maand")
                            End If
                        End If

                        intPlekGevind = Array.FindIndex(aFieldsToChange, Function(s) s.ToString.ToUpper = "PKMAAND_VT_DETAILS")
                        If intPlekGevind > -1 Then
                            intPK_Maandvtdet = aValues(intPlekGevind)
                        Else
                            If reader("pkmaand_vt_details") Is DBNull.Value Then
                                intPK_Maandvtdet = 0
                            Else
                                intPK_Maandvtdet = reader("pkmaand_vt_details")
                            End If
                        End If

                        intPlekGevind = Array.FindIndex(aFieldsToChange, Function(s) s.ToString.ToUpper = "VT_VORD_DATUM")
                        If intPlekGevind > -1 Then
                            If aValues(intPlekGevind) Is DBNull.Value Or aValues(intPlekGevind) = "" Then
                                blnvord_DatumNull = True
                            Else
                                dtevt_Vord_Datum = aValues(intPlekGevind)
                            End If
                        Else
                            If reader("VT_vord_Datum") IsNot DBNull.Value Then
                                dtevt_Vord_Datum = reader("VT_vord_Datum")
                            Else
                                blnvord_DatumNull = True
                                If reader("Vt_Datum") IsNot DBNull.Value Then
                                    dtevt_Vord_Datum = reader("Vt_Datum")
                                End If
                            End If
                        End If

                        intPlekGevind = Array.FindIndex(aFieldsToChange, Function(s) s.ToString.ToUpper = "VT_DATUM")
                        If intPlekGevind > -1 Then
                            If aValues(intPlekGevind) Is DBNull.Value Or aValues(intPlekGevind) = "" Then
                                blnVT_DatumNull = True
                            Else
                                dtevt_datum = aValues(intPlekGevind)
                            End If

                        Else
                            If reader("VT_Datum") Is DBNull.Value Then
                                blnVT_DatumNull = True
                                dtevt_datum = "1900/01/01"
                            Else
                                dtevt_datum = reader("VT_Datum")
                            End If
                        End If

                        intPlekGevind = Array.FindIndex(aFieldsToChange, Function(s) s.ToString.ToUpper = "TRANS_DAT")
                        If intPlekGevind > -1 Then
                            If aValues(intPlekGevind) Is DBNull.Value Or aValues(intPlekGevind) = "" Then
                                blnTrans_DatNull = True
                            Else
                                dtetrans_dat = aValues(intPlekGevind)
                            End If

                        Else
                            If reader("TRANS_DAT") Is DBNull.Value Then
                                blnTrans_DatNull = True
                                dtetrans_dat = "1900/01/01"
                            Else
                                dtetrans_dat = reader("TRANS_DAT")
                            End If
                        End If

                        intPlekGevind = Array.FindIndex(aFieldsToChange, Function(s) s.ToString.ToUpper = "AFSLUIT_DAT")
                        If intPlekGevind > -1 Then
                            If aValues(intPlekGevind) Is DBNull.Value Or aValues(intPlekGevind) = "" Then
                                blnAfsluit_datNull = True
                            Else
                                dteafsluit_dat = aValues(intPlekGevind)
                            End If

                        Else
                            If reader("Afsluit_Dat") IsNot DBNull.Value Then
                                dteafsluit_dat = reader("Afsluit_Dat")
                            Else
                                blnAfsluit_datNull = True
                                dteafsluit_dat = "1900/01/01"
                            End If
                        End If

                        intPlekGevind = Array.FindIndex(aFieldsToChange, Function(s) s.ToString.ToUpper = "X")
                        If intPlekGevind > -1 Then
                            blnX = aValues(intPlekGevind)
                        Else
                            If reader("X") IsNot DBNull.Value Then
                                blnX = reader("X")
                            Else
                                blnX = False
                            End If
                        End If

                    End If
                Else
                    MsgBox("No VT transactions to match.", MsgBoxStyle.Critical)
                    blnsukses = False
                    Return blnsukses
                    Exit Function
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            blnsukses = False
            Return blnsukses
            Exit Function
        End Try

        'Andriette 1/09/2014 update die maand_vt_details tabel ook
        Try
            Dim params3() As SqlParameter = {New SqlParameter("pkmaand_vt_details", SqlDbType.Int), _
                                             New SqlParameter("@POLISNO ", SqlDbType.NVarChar), _
                                             New SqlParameter("@vt_bedrag", SqlDbType.Money), _
                                             New SqlParameter("@vt_datum ", SqlDbType.DateTime), _
                                             New SqlParameter("@datumaangevra", SqlDbType.DateTime), _
                                             New SqlParameter("@vt_takkode", SqlDbType.NVarChar), _
                                             New SqlParameter("@vt_reknr", SqlDbType.NVarChar), _
                                             New SqlParameter("@vt_rede", SqlDbType.NVarChar), _
                                             New SqlParameter("@vt_kode", SqlDbType.NVarChar), _
                                             New SqlParameter("@x", SqlDbType.Bit), _
                                             New SqlParameter("@Vt_ingevorder", SqlDbType.Money), _
                                             New SqlParameter("@vt_kwitansie", SqlDbType.NVarChar), _
                                             New SqlParameter("@trans_dat", SqlDbType.DateTime), _
                                             New SqlParameter("@jaar", SqlDbType.Int), _
                                             New SqlParameter("@maand", SqlDbType.Int), _
                                             New SqlParameter("@afsluit_dat", SqlDbType.DateTime), _
                                             New SqlParameter("@vt_vord_Datum", SqlDbType.DateTime), _
                                             New SqlParameter("@Kwit_Boek", SqlDbType.NVarChar)}

            Using conn As SqlConnection = SqlHelper.GetConnection
                params3(0).Value = intPK_Maandvtdet
                params3(1).Value = glbPolicyNumber  '@POLISNO
                params3(2).Value = dblvt_bedrag '@vt_bedrag
                If blnVT_DatumNull Then
                    params3(3).Value = DBNull.Value
                Else
                    params3(3).Value = dtevt_datum  '@vt_datum D
                End If
                If blnDatumAangevraNull Then
                    params3(4).Value = DBNull.Value
                Else
                    params3(4).Value = dteDatumaangevra '@datumaangevra
                End If
                params3(5).Value = strvt_takkode  '@vt_takkode
                params3(6).Value = strvt_reknr '@vt_reknr"
                params3(7).Value = strVt_Rede  '@vt_rede"
                params3(8).Value = intVt_kode '@vt_kode"
                params3(9).Value = blnX  '@x"
                params3(10).Value = dblVt_Ingevorder '+ Val(txtamount) '@Vt_ingevorder"
                params3(11).Value = strvt_kwitansie  '@vt_kwitansie"
                If blnTrans_DatNull Then
                    params3(12).Value = DBNull.Value
                Else
                    params3(12).Value = dtetrans_dat  '@trans_dat"
                End If
                params3(13).Value = intVTJaar  '@jaar"
                params3(14).Value = intVTMaand  '@maand"
                If blnAfsluit_datNull Then
                    params3(15).Value = DBNull.Value
                Else
                    params3(15).Value = dteafsluit_dat  '@afsluit_dat"
                End If
                If blnvord_DatumNull Then
                    params3(16).Value = DBNull.Value
                Else
                    params3(16).Value = dtevt_Vord_Datum '@ vt_vord_Datum
                End If
                params3(17).Value = strKwit_BoekVT  'txtReceiptnr  '@Kwit_Boek"
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Stats5.UpdateMaand_VT_Details", params3)

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                blnsukses = True
                Return blnsukses
                Exit Function
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            blnsukses = False
            Return blnsukses
            Exit Function
        End Try

    End Function

    Public Function KontantVt_Trans_dat(pkkontant)
        Dim dteVt_Trans_Datum As Date
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@pkkontant", SqlDbType.NVarChar)}
                param(0).Value = pkkontant
                ' Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchTransaksiesPerPolisnoTipe]", param)
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchKontantperPK]", param)

                If reader.HasRows Then
                    If reader.Read Then
                        dteVt_Trans_Datum = reader("vt_trans_dat")
                    End If
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
            Return dteVt_Trans_Datum
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function

    Public Sub UpdateMaandVtBalans(dblBedrag As Double)
        Dim EntBalans As New maand_vt_balansEntity
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim paramFetch() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar)}
                paramFetch(0).Value = glbPolicyNumber
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchMaand_Balans", paramFetch)
                If reader.HasRows Then

                    If reader.Read Then
                        If reader("Afsluit_dat") IsNot DBNull.Value Then
                            EntBalans.AFSLUIT_DAT = reader("Afsluit_dat")
                        End If

                        If reader("vt_aant") IsNot DBNull.Value Then
                            EntBalans.VT_AANT = reader("vt_aant")
                        End If

                        If reader("vt_balans") IsNot DBNull.Value Then
                            EntBalans.VT_BALANS = reader("vt_balans")
                        End If

                        If reader("versekerde") IsNot DBNull.Value Then
                            EntBalans.VERSEKERDE = reader("versekerde")
                        End If

                        If reader("voorl") IsNot DBNull.Value Then
                            EntBalans.VOORL = reader("voorl")
                        End If

                        If reader("jaar") IsNot DBNull.Value Then
                            EntBalans.JAAR = reader("jaar")
                        End If

                        If reader("maand") IsNot DBNull.Value Then
                            EntBalans.MAAND = reader("maand")
                        End If
                        If reader("trans_dat") IsNot DBNull.Value Then
                            EntBalans.TRANS_DAT = reader("trans_dat")
                        End If
                    End If
                Else
                    MsgBox("There is no balance for the policyholder. Please contact support.")
                End If

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        Try
            Dim paramsUpdate() As SqlParameter = {New SqlParameter("Polisno", SqlDbType.NVarChar), _
                                                  New SqlParameter("Versekerde", SqlDbType.NVarChar), _
                                                  New SqlParameter("voorl", SqlDbType.NVarChar), _
                                                  New SqlParameter("vt_aant", SqlDbType.Int), _
                                                  New SqlParameter("vt_balans", SqlDbType.Money), _
                                                  New SqlParameter("trans_dat", SqlDbType.DateTime), _
                                                  New SqlParameter("afsluit_dat", SqlDbType.DateTime), _
                                                  New SqlParameter("jaar", SqlDbType.Int), _
                                                  New SqlParameter("maand", SqlDbType.Int)}

            paramsUpdate(0).Value = glbPolicyNumber
            paramsUpdate(1).Value = EntBalans.VERSEKERDE
            paramsUpdate(2).Value = EntBalans.VOORL
            paramsUpdate(3).Value = 0
            paramsUpdate(4).Value = dblBedrag
            paramsUpdate(5).Value = Now()
            paramsUpdate(6).Value = EntBalans.AFSLUIT_DAT
            paramsUpdate(7).Value = EntBalans.JAAR
            paramsUpdate(8).Value = EntBalans.MAAND
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Stats5.UpdateMaand_VT_Balans", paramsUpdate)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Public Function UpdateMaandDetails(dteVord_Dat As DateTime, dblVord_Premie As Double, dtetrans_dat As DateTime, strKwit_Boek As String, intmaand As Integer, intjaar As Integer)
        Dim entMaand As New MaandEntity
        Dim dbltotalgevorder As Double = 0

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim paramFetch() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                    New SqlParameter("@jaar", SqlDbType.Int), _
                                                    New SqlParameter("@maand", SqlDbType.Int)}
                paramFetch(0).Value = glbPolicyNumber
                paramFetch(1).Value = intjaar
                paramFetch(2).Value = intmaand

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchMaandDebities", paramFetch)
                If reader.HasRows Then
                    If reader.Read Then
                        If reader("polisno") IsNot DBNull.Value Then
                            entMaand.POLISNO = reader("polisno")
                        End If

                        If reader("vord_dat") IsNot DBNull.Value Then
                            entMaand.VORD_DAT = reader("vord_dat")
                        Else
                            entMaand.VORD_DAT = "1900/01/01"
                        End If

                        If reader("premie") IsNot DBNull.Value Then
                            entMaand.PREMIE = reader("premie")
                        End If
                        If reader("vord_premie") IsNot DBNull.Value Then
                            entMaand.VORD_PREMIE = reader("vord_premie")
                        End If
                        If reader("match") IsNot DBNull.Value Then
                            entMaand.MATCH = reader("match")
                        End If
                        If reader("nie_multi") IsNot DBNull.Value Then
                            entMaand.NIE_MULTI = reader("nie_multi")
                        End If
                        If reader("nie_md") IsNot DBNull.Value Then
                            entMaand.NIE_MD = reader("nie_md")
                        End If
                        If reader("oningewin") IsNot DBNull.Value Then
                            entMaand.ONINGEWIN = reader("oningewin")
                        End If
                        If reader("jaar") IsNot DBNull.Value Then
                            entMaand.JAAR = reader("jaar")
                        End If
                        If reader("maand") IsNot DBNull.Value Then
                            entMaand.MAAND = reader("maand")
                        End If
                        If reader("trans_dat") IsNot DBNull.Value Then
                            entMaand.TRANS_DAT = reader("trans_dat")
                        Else
                            entMaand.TRANS_DAT = "1900/01/01"

                        End If
                        If reader("betaalwyse") IsNot DBNull.Value Then
                            entMaand.BETAALWYSE = reader("betaalwyse")
                        End If
                        If reader("afsluit_dat") IsNot DBNull.Value Then
                            entMaand.AFSLUIT_DAT = reader("afsluit_dat")
                        Else
                            entMaand.AFSLUIT_DAT = "1900/01/01"
                        End If
                        If reader("ingevorder") IsNot DBNull.Value Then
                            entMaand.ingevorder = reader("ingevorder")
                        End If
                        If reader("ms_trans_dat") IsNot DBNull.Value Then
                            entMaand.ms_trans_dat = reader("ms_trans_dat")
                        Else
                            entMaand.ms_trans_dat = "1900/01/01"
                        End If

                        If reader("kwit_boek") IsNot DBNull.Value Then
                            entMaand.Kwit_boek = reader("kwit_boek")
                        Else
                            entMaand.Kwit_boek = ""
                        End If
                        If reader("area") IsNot DBNull.Value Then
                            entMaand.Area = reader("area")
                        End If
                        If reader("pers_nom") IsNot DBNull.Value Then
                            entMaand.Pers_Nom = reader("pers_nom")
                        Else
                            entMaand.Pers_Nom = ""
                        End If
                        'If reader("oortabel") IsNot DBNull.Value Then
                        '    entMaand.oortabel = reader("oortabel")
                        'End If

                    End If
                Else
                    Return False
                End If

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim paramUpdate() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                     New SqlParameter("@PREMIE", SqlDbType.Money), _
                                                     New SqlParameter("@VORD_PREMIE", SqlDbType.Money), _
                                                     New SqlParameter("@AFSLUIT_DAT", SqlDbType.DateTime), _
                                                     New SqlParameter("@Area", SqlDbType.NVarChar), _
                                                     New SqlParameter("@JAAR", SqlDbType.Int), _
                                                     New SqlParameter("@MAAND", SqlDbType.Int), _
                                                     New SqlParameter("@TRANS_DAT", SqlDbType.DateTime), _
                                                     New SqlParameter("@MS_Trans_dat", SqlDbType.DateTime), _
                                                     New SqlParameter("@BETAALWYSE", SqlDbType.NVarChar), _
                                                     New SqlParameter("@Kwit_boek", SqlDbType.NVarChar), _
                                                     New SqlParameter("@Vord_DAT", SqlDbType.DateTime), _
                                                     New SqlParameter("@Match", SqlDbType.Bit), _
                                                     New SqlParameter("@Nie_Multi", SqlDbType.Money), _
                                                     New SqlParameter("@Nie_MD", SqlDbType.Money), _
                                                     New SqlParameter("@Oningewin", SqlDbType.Money), _
                                                     New SqlParameter("@ingevorder", SqlDbType.Money), _
                                                     New SqlParameter("@Pers_nom", SqlDbType.NVarChar)}

                paramUpdate(0).Value = glbPolicyNumber                          ' polisno
                paramUpdate(1).Value = entMaand.PREMIE                          ' premie
                paramUpdate(2).Value = entMaand.VORD_PREMIE + dblVord_Premie    ' vord_premie
                dbltotalgevorder = FormatNumber((entMaand.VORD_PREMIE + dblVord_Premie), 2)
                If entMaand.AFSLUIT_DAT = "1900/01/01" Then
                    paramUpdate(3).Value = DBNull.Value
                Else
                    paramUpdate(3).Value = entMaand.AFSLUIT_DAT                     'afsluit_dat
                End If

                paramUpdate(4).Value = entMaand.Area                            'area
                paramUpdate(5).Value = entMaand.JAAR                            'jaar
                paramUpdate(6).Value = entMaand.MAAND                           'maand
                If dtetrans_dat = "1900/01/01" Then
                    paramUpdate(7).Value = DBNull.Value
                Else
                    paramUpdate(7).Value = dtetrans_dat                             'trans_dat
                End If
                If entMaand.ms_trans_dat = "1900/01/01" Then
                    paramUpdate(8).Value = DBNull.Value
                Else
                    paramUpdate(8).Value = entMaand.ms_trans_dat                    'ms_trans_dat
                End If

                paramUpdate(9).Value = entMaand.BETAALWYSE                      'betaalwyse
                paramUpdate(10).Value = strKwit_Boek                            'kwit_boek
                If dteVord_Dat = "1900/01/01" Then
                    paramUpdate(11).Value = DBNull.Value
                Else
                    paramUpdate(11).Value = dteVord_Dat                             'vord_dat
                End If

                If dbltotalgevorder = entMaand.PREMIE Then
                    paramUpdate(12).Value = True                                'match 
                    paramUpdate(15).Value = 0    'oningewin
                Else
                    paramUpdate(12).Value = False
                    paramUpdate(15).Value = entMaand.PREMIE - dbltotalgevorder    'oningewin
                End If
                paramUpdate(13).Value = 0                                       'nie_multi
                paramUpdate(14).Value = 0                                       'nie_md

                paramUpdate(16).Value = entMaand.ingevorder                     'ingevorder
                paramUpdate(17).Value = entMaand.Pers_Nom  'pers_nom 
                'paramUpdate(18).Value = 
                'paramUpdate(19).Value = 

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Stats5.UpdateMaand", paramUpdate)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try

        Return True
    End Function


    Public Sub SaveKontantTransaksie(ByVal dblbedrag As Double)
        '   Dim dtedatumaangevra As Date
        Dim dblNettoBedrag As Double = 0
        Dim params() As SqlParameter = {New SqlParameter("@pkKontant", SqlDbType.Int), _
                                New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                New SqlParameter("@vord_dat", SqlDbType.DateTime), _
                                New SqlParameter("@Premie", SqlDbType.Money), _
                                New SqlParameter("@Vord_Premie", SqlDbType.Money), _
                                New SqlParameter("@afsluit_dat", SqlDbType.DateTime), _
                                New SqlParameter("@jaar", SqlDbType.SmallInt), _
                                New SqlParameter("@maand", SqlDbType.SmallInt), _
                                New SqlParameter("@trans_dat", SqlDbType.DateTime), _
                                New SqlParameter("@Betaalwyse", SqlDbType.NVarChar), _
                                New SqlParameter("@verw1", SqlDbType.NVarChar), _
                                New SqlParameter("@verw2", SqlDbType.NVarChar), _
                                New SqlParameter("@verw3", SqlDbType.NVarChar), _
                                New SqlParameter("@verw4", SqlDbType.NVarChar), _
                                New SqlParameter("@verw5", SqlDbType.NVarChar), _
                                New SqlParameter("@gekans", SqlDbType.Bit), _
                                New SqlParameter("@kans_dat", SqlDbType.DateTime), _
                                New SqlParameter("@tipe", SqlDbType.NVarChar), _
                                New SqlParameter("@kontant_tipe", SqlDbType.NVarChar), _
                                New SqlParameter("@tjekno_in", SqlDbType.NVarChar), _
                                New SqlParameter("@TJEKDATUM", SqlDbType.DateTime), _
                                New SqlParameter("@TJEKBESONDERHEDE", SqlDbType.NVarChar), _
                                New SqlParameter("@kwitansie", SqlDbType.NVarChar), _
                                New SqlParameter("@vt_trans_dat", SqlDbType.DateTime), _
                                New SqlParameter("@mk_trans_dat", SqlDbType.DateTime), _
                                New SqlParameter("@jk_trans_dat", SqlDbType.DateTime), _
                                New SqlParameter("@eb_trans_dat", SqlDbType.DateTime), _
                                New SqlParameter("@ms_trans_dat", SqlDbType.DateTime), _
                                New SqlParameter("@ei_trans_dat", SqlDbType.DateTime), _
                                New SqlParameter("@md_trans_dat", SqlDbType.DateTime), _
                                New SqlParameter("@gg_trans_dat", SqlDbType.DateTime), _
                                New SqlParameter("@me_trans_dat", SqlDbType.DateTime), _
                                New SqlParameter("@nuwe_tjekno", SqlDbType.NVarChar), _
                                New SqlParameter("@tjekno", SqlDbType.NVarChar), _
                                New SqlParameter("@tjekno_uit", SqlDbType.NVarChar), _
                                New SqlParameter("@eisno", SqlDbType.NVarChar), _
                                New SqlParameter("@kwit_boek", SqlDbType.NVarChar), _
                                New SqlParameter("@fklangtermynpolis", SqlDbType.Int), _
                                New SqlParameter("@LtpTipe", SqlDbType.NVarChar), _
                                New SqlParameter("@fklangtermynpolis_kontant", SqlDbType.NVarChar), _
                                New SqlParameter("@vtdatumaangevra", SqlDbType.DateTime), _
                                New SqlParameter("@area", SqlDbType.NVarChar)}

        'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
        'Andriette 03/07/2014 Edit verskil van nuwe
        '  If frmKontant.blnNuweBetaling Then ' skep ' nuwe inskrywing
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                If KontantItem.pk_waarde = "" Or KontantItem.pk_waarde = "0" Then

                    params(0).Value = DBNull.Value              '"@pkKontant"   0
                Else
                    params(0).Value = KontantItem.pk_waarde
                End If

                params(1).Value = glbPolicyNumber               '"@POLISNO"     1

                If KontantItem.vord_dat = "1900/01/01" Then
                    params(2).Value = DBNull.Value              '"@vord_dat"    2
                Else
                    params(2).Value = KontantItem.vord_dat
                End If

                params(3).Value = KontantItem.premie            '"@Premie"      3
                params(4).Value = KontantItem.vord_premie       '"@Vord_Premie" 4
                If KontantItem.afsluit_dat = "1900/01/01" Then
                    params(5).Value = DBNull.Value '"@afsluit_dat" 5
                Else
                    params(5).Value = KontantItem.afsluit_dat
                End If
                params(6).Value = KontantItem.jaar '"@jaar"        6
                params(7).Value = KontantItem.maand '"@maand" 
                If KontantItem.trans_dat = "1900/01/01" Then
                    params(8).Value = DBNull.Value
                Else
                    params(8).Value = KontantItem.trans_dat  '"@trans_dat"   8
                End If

                'Betaalwyse

                params(9).Value = KontantItem.betaalwyse        'Betaalwyse 9
                params(17).Value = KontantItem.tipe
                ' tipe  17
                If KontantItem.vt_trans_dat = "1900/01/01" Then
                    params(23).Value = DBNull.Value
                Else
                    params(23).Value = KontantItem.vt_trans_dat
                End If
                If KontantItem.mk_trans_dat = "1900/01/01" Then
                    params(24).Value = DBNull.Value
                Else
                    params(24).Value = KontantItem.mk_trans_dat
                End If
                If KontantItem.jk_trans_dat = "1900/01/01" Then
                    params(25).Value = DBNull.Value
                Else
                    params(25).Value = KontantItem.jk_trans_dat
                End If
                If KontantItem.eb_trans_dat = "1900/01/01" Then
                    params(26).Value = DBNull.Value
                Else
                    params(26).Value = KontantItem.eb_trans_dat
                End If
                If KontantItem.ms_trans_dat = "1900/01/01" Then
                    params(27).Value = DBNull.Value
                Else
                    params(27).Value = KontantItem.ms_trans_dat
                End If
                If KontantItem.ei_trans_dat = "1900/01/01" Then
                    params(28).Value = DBNull.Value
                Else
                    params(28).Value = KontantItem.ei_trans_dat
                End If
                If KontantItem.md_trans_dat = "1900/01/01" Then
                    params(29).Value = DBNull.Value
                Else
                    params(29).Value = KontantItem.md_trans_dat
                End If
                If KontantItem.gg_trans_dat = "1900/01/01" Then
                    params(30).Value = DBNull.Value
                Else
                    params(30).Value = KontantItem.gg_trans_dat
                End If

                If KontantItem.Me_Trans_Dat = "1900/01/01" Then
                    params(31).Value = DBNull.Value

                Else
                    params(31).Value = KontantItem.Me_Trans_Dat
                End If

                If KontantItem.VTDatumAangevra = "1900/01/01" Then
                    params(40).Value = DBNull.Value
                Else
                    params(40).Value = KontantItem.VTDatumAangevra
                End If

                params(22).Value = KontantItem.kwitansie   '"@Kwitansie"   10

                params(10).Value = KontantItem.verw1 '"@verw1"       11
                params(11).Value = KontantItem.verw2   '"@verw2"       12
                params(12).Value = KontantItem.verw3 '"@verw3"       13
                params(13).Value = KontantItem.verw4 '"@verw4"       14
                params(14).Value = KontantItem.verw5 '"@verw5"       15
                params(15).Value = KontantItem.gekans  '"@gekans"      16
                If KontantItem.kans_dat = "1900/01/01" Then
                    params(16).Value = DBNull.Value
                Else
                    params(16).Value = KontantItem.kans_dat '"@kans_dat",   17
                End If
                params(18).Value = KontantItem.kontant_tipe  '"@kontanttipe"            25
                params(32).Value = KontantItem.tjekno   '"@tjekno"          32
                params(33).Value = KontantItem.tjekno_uit   '"@tjekno_uit"      33
                params(34).Value = KontantItem.tjekno_in   '"@tjekno_in"       34
                params(35).Value = KontantItem.EISNO  '"@eisno"           35
                params(19).Value = KontantItem.nuwe_tjekno    '@nuwe_tjekno       19
                params(20).Value = KontantItem.TJEKDATUM      '"@TJEKDATUM"       20
                params(21).Value = KontantItem.TJEKBESONDERHEDE        '"@TJEKBESONDERHEDE"   21
                params(36).Value = KontantItem.kwit_boek   '"@kwit_boek"       36
                params(37).Value = KontantItem.FkLangtermynpolis  '"@fklangtermynpolis"   37
                params(38).Value = KontantItem.LTPtipe             '"@LTPtipe"             38
                If KontantItem.FKLangtermynpolis_Kontant = "" Then
                    params(39).Value = DBNull.Value
                Else
                    params(39).Value = KontantItem.FKLangtermynpolis_Kontant  '"@fklangtermynpolis_kontant" 39
                End If
                params(41).Value = KontantItem.area         '"@Area"                    41 

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Stats5.UpdateKontant", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        UpdateMaandDetails(KontantItem.vord_dat, KontantItem.vord_premie, Now(), KontantItem.kwit_boek, KontantItem.maand, KontantItem.jaar)
    End Sub

    Public Sub FrmKontantVulVelde()

        Dim strString As String

        If blnNuweBetaling Then 'Nuwe betaling
            If optPaybackPayment.Checked Or optPrepaidPayment.Checked Or optFirstPayment.Checked Then
                ' wys die commencement datum
                frmkontantDetail.lblCommenceDate.Visible = True
                frmkontantDetail.dteCoverCommence.Visible = True
            Else
                frmkontantDetail.lblCommenceDate.Visible = False
                frmkontantDetail.dteCoverCommence.Visible = False
            End If
        Else 'edit betaling
            Try
                Dim param() As SqlParameter = {New SqlParameter("@pkkontant", SqlDbType.NVarChar)}
                Using conn As SqlConnection = SqlHelper.GetConnection
                    param(0).Value = dgvMonetereTransaksies.SelectedCells.Item(17).Value
                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchKontantperPK]", param)

                    If reader.HasRows Then
                        If reader.Read Then
                            If reader("kontant_tipe") IsNot DBNull.Value Then
                                KontantItem.kontant_tipe = reader("kontant_tipe")
                                If Not blnWisBetaling Then
                                    Select Case KontantItem.kontant_tipe
                                        Case "T"
                                            frmkontantDetail.optCheque.Checked = True
                                            frmkontantDetail.frmKntdetchequeVisibility(True)
                                        Case "E"
                                            frmkontantDetail.optElectronic.Checked = True
                                            frmkontantDetail.frmKntdetchequeVisibility(False)
                                        Case "K"
                                            frmkontantDetail.optCash.Checked = True
                                            frmkontantDetail.frmKntdetchequeVisibility(False)
                                        Case Else
                                            frmkontantDetail.optCash.Checked = False
                                            frmkontantDetail.optCheque.Checked = False
                                            frmkontantDetail.optElectronic.Checked = False
                                            frmkontantDetail.frmKntdetchequeVisibility(False)
                                    End Select
                                End If

                            Else
                                'strKontantTipe = ""
                                If Not blnWisBetaling Then
                                    frmkontantDetail.optCash.Checked = False
                                    frmkontantDetail.optCheque.Checked = False
                                    frmkontantDetail.optElectronic.Checked = False
                                End If

                            End If

                            If reader("kwit_boek") IsNot DBNull.Value Then
                                KontantItem.kwit_boek = reader("kwit_boek")
                                If Not blnWisBetaling Then
                                    frmkontantDetail.txtReceiptnr.Text = KontantItem.kwit_boek
                                End If

                            Else
                                If Not blnWisBetaling Then
                                    frmkontantDetail.txtReceiptnr.Text = ""
                                End If

                            End If

                            If reader("vord_premie") IsNot DBNull.Value Then
                                KontantItem.vord_premie = FormatNumber(reader("vord_premie"), 2)
                                If Not blnWisBetaling Then
                                    frmkontantDetail.txtAmount.Text = KontantItem.vord_premie
                                End If

                            Else
                                If Not blnWisBetaling Then
                                    frmkontantDetail.txtAmount.Text = ""
                                End If

                            End If

                            If reader("verw1") IsNot DBNull.Value Then

                                KontantItem.verw1 = reader("verw1").ToString.Trim
                                If Not blnWisBetaling Then
                                    frmkontantDetail.txtCashMemo.Text = KontantItem.verw1
                                End If
                            Else
                                If Not blnWisBetaling Then
                                    frmkontantDetail.txtCashMemo.Text = ""
                                End If

                            End If

                            If reader("verw2") IsNot DBNull.Value Then
                                KontantItem.verw2 = reader("verw2").ToString.Trim
                                If Not blnWisBetaling Then
                                    strString = KontantItem.verw2
                                    If strString.Length > 0 Then
                                        frmkontantDetail.txtCashMemo.Text = frmkontantDetail.txtCashMemo.Text & " " & strString
                                    End If
                                End If

                            End If

                            If reader("verw3") IsNot DBNull.Value Then
                                KontantItem.verw3 = reader("verw3").ToString.Trim
                                If Not blnWisBetaling Then
                                    strString = KontantItem.verw3
                                    If strString.Length > 0 Then
                                        frmkontantDetail.txtCashMemo.Text = frmkontantDetail.txtCashMemo.Text & " " & strString
                                    End If
                                End If
                            End If

                            If reader("verw4") IsNot DBNull.Value Then
                                KontantItem.verw4 = reader("verw4").ToString.Trim
                                If Not blnWisBetaling Then


                                    strString = KontantItem.verw4
                                    If strString.Length > 0 Then
                                        frmkontantDetail.txtCashMemo.Text = frmkontantDetail.txtCashMemo.Text & " " & strString
                                    End If
                                End If
                            End If

                            If reader("verw5") IsNot DBNull.Value Then
                                KontantItem.verw5 = reader("verw5").ToString.Trim

                                If Not blnWisBetaling Then
                                    strString = KontantItem.verw5
                                    If strString.Length > 0 Then
                                        frmkontantDetail.txtCashMemo.Text = frmkontantDetail.txtCashMemo.Text & " " & strString
                                    End If
                                End If

                            End If


                            If reader("tjekno_in") IsNot DBNull.Value Then
                                KontantItem.tjekno_in = reader("tjekno_in")
                                If Not blnWisBetaling Then
                                    frmkontantDetail.txtChequenr.Text = KontantItem.tjekno_in
                                End If

                            Else
                                If Not blnWisBetaling Then
                                    frmkontantDetail.txtChequenr.Text = ""
                                End If
                            End If

                                If reader("tjekdatum") IsNot DBNull.Value Then
                                KontantItem.TJEKDATUM = reader("tjekdatum")
                                If Not blnWisBetaling Then
                                    frmkontantDetail.dtpChequeDate.Text = KontantItem.TJEKDATUM
                                End If
                            Else
                                If Not blnWisBetaling Then
                                    frmkontantDetail.dtpChequeDate.Text = ""
                                End If

                            End If

                            If reader("Pkkontant") IsNot DBNull.Value Then
                                KontantItem.pk_waarde = reader("Pkkontant")
                            End If

                            If reader("Polisno") IsNot DBNull.Value Then
                                KontantItem.polisno = reader("Polisno")
                            End If

                            If reader("tjekbesonderhede") IsNot DBNull.Value Then
                                KontantItem.TJEKBESONDERHEDE = reader("tjekbesonderhede")
                                If Not blnWisBetaling Then
                                    frmkontantDetail.txtChequeInfo.Text = KontantItem.TJEKBESONDERHEDE
                                End If

                            Else
                                If Not blnWisBetaling Then
                                    frmkontantDetail.txtChequeInfo.Text = ""
                                End If

                            End If

                            If reader("vord_dat") IsNot DBNull.Value Then
                                KontantItem.vord_dat = reader("vord_dat")
                            Else
                                KontantItem.vord_dat = "1900/01/01"
                            End If

                            If reader("premie") IsNot DBNull.Value Then
                                KontantItem.premie = reader("premie")
                            End If
                            If reader("afsluit_dat") IsNot DBNull.Value Then
                                KontantItem.afsluit_dat = reader("afsluit_dat")
                            Else
                                KontantItem.afsluit_dat = "1900/01/01"
                            End If

                            If reader("jaar") IsNot DBNull.Value Then
                                KontantItem.jaar = reader("jaar")
                            End If

                                If reader("maand") IsNot DBNull.Value Then
                                    KontantItem.maand = reader("maand")
                                End If

                                If reader("trans_dat") IsNot DBNull.Value Then
                                    KontantItem.trans_dat = reader("trans_dat")
                                Else
                                    KontantItem.trans_dat = "1900/01/01"
                                End If

                                If reader("betaalwyse") IsNot DBNull.Value Then
                                    KontantItem.betaalwyse = reader("betaalwyse")
                                End If

                                If reader("gekans") IsNot DBNull.Value Then
                                    KontantItem.gekans = reader("gekans")
                                End If
                                If reader("kans_dat") IsNot DBNull.Value Then
                                    KontantItem.kans_dat = reader("kans_dat")
                                Else
                                    KontantItem.kans_dat = "1900/01/01"
                                End If
                                If reader("tipe") IsNot DBNull.Value Then
                                    KontantItem.tipe = reader("tipe")
                                End If

                                If reader("mk_trans_dat") IsNot DBNull.Value Then
                                    KontantItem.mk_trans_dat = reader("mk_trans_dat")
                                Else
                                    KontantItem.mk_trans_dat = "1900/01/01"
                                End If

                                If reader("jk_trans_dat") IsNot DBNull.Value Then
                                    KontantItem.jk_trans_dat = reader("jk_trans_dat")
                                Else
                                    KontantItem.jk_trans_dat = "1900/01/01"
                                End If
                                If reader("eb_trans_dat") IsNot DBNull.Value Then
                                    KontantItem.eb_trans_dat = reader("eb_trans_dat")
                                Else
                                    KontantItem.eb_trans_dat = "1900/01/01"
                                End If
                                If reader("ms_trans_dat") IsNot DBNull.Value Then
                                    KontantItem.ms_trans_dat = reader("ms_trans_dat")
                                Else
                                    KontantItem.ms_trans_dat = "1900/01/01"
                                End If
                                If reader("ei_trans_dat") IsNot DBNull.Value Then
                                    KontantItem.ei_trans_dat = reader("ei_trans_dat")
                                Else
                                    KontantItem.ei_trans_dat = "1900/01/01"
                                End If
                                If reader("md_trans_dat") IsNot DBNull.Value Then
                                    KontantItem.md_trans_dat = reader("md_trans_dat")
                                Else
                                    KontantItem.md_trans_dat = "1900/01/01"
                                End If
                                If reader("gg_trans_dat") IsNot DBNull.Value Then
                                    KontantItem.gg_trans_dat = reader("gg_trans_dat")
                                Else
                                    KontantItem.gg_trans_dat = "1900/01/01"
                                End If

                                If reader("nuwe_tjekno") IsNot DBNull.Value Then
                                    KontantItem.nuwe_tjekno = reader("nuwe_tjekno")
                                End If
                                If reader("tjekno") IsNot DBNull.Value Then
                                    KontantItem.tjekno = reader("tjekno")
                                End If
                                If reader("tjekno_uit") IsNot DBNull.Value Then
                                    KontantItem.tjekno_uit = reader("tjekno_uit")
                                End If
                                If reader("eisno") IsNot DBNull.Value Then
                                    KontantItem.EISNO = reader("eisno")
                                End If
                                If reader("Me_Trans_Dat") IsNot DBNull.Value Then
                                    KontantItem.Me_Trans_Dat = reader("Me_Trans_Dat")
                                Else
                                    KontantItem.Me_Trans_Dat = "1900/01/01"
                                End If
                                If reader("FkLangtermynpolis") IsNot DBNull.Value Then
                                    KontantItem.FkLangtermynpolis = reader("FkLangtermynpolis")
                                End If
                                If reader("FKLangtermynpolis_Kontant") IsNot DBNull.Value Then
                                    KontantItem.FKLangtermynpolis_Kontant = reader("FKLangtermynpolis_Kontant")
                                End If
                                If reader("LTPtipe") IsNot DBNull.Value Then
                                    KontantItem.LTPtipe = reader("LTPtipe")
                                End If
                                If reader("area") IsNot DBNull.Value Then
                                    KontantItem.area = reader("area")
                                End If
                                If reader("kwitansie") IsNot DBNull.Value Then
                                    KontantItem.kwitansie = reader("kwitansie")
                                End If
                                If reader("VT_Trans_dat") IsNot DBNull.Value Then
                                    KontantItem.vt_trans_dat = reader("VT_Trans_Dat")
                                Else
                                    KontantItem.vt_trans_dat = "1900/01/01"
                                End If
                                If reader("vtdatumaangevra") IsNot DBNull.Value Then
                                    KontantItem.VTDatumAangevra = reader("vtdatumaangevra")
                                Else
                                    KontantItem.VTDatumAangevra = "1900/01/01"
                                End If
                        End If
                    End If
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                End Using

                '  dgvMonetereTransaksies.Rows(intitem).Cells("vord_dat").Value()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try


        End If
    End Sub

End Class