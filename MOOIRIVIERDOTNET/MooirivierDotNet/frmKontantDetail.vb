Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports DAL

Public Class frmkontantDetail
    Dim blnloading As Boolean = True

    Dim dteafsluitdat As Date
    Dim strBetaalTipe As String = ""
    Dim strOntvTipe As String = ""
    Dim strTakafkorting As String
    Dim strTaknaam As String = ""
    Dim intKwit_nr As Integer
    Dim intRow As Integer
    Dim dteFrom As Date
    Dim dteto As Date
    Dim intCountVt As Integer = 0

    Dim blnVt_betaling As Boolean

    Private Sub frmkontantDetail_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        intCountVt = 0
        Me.Text = " Policy Number: " & glbPolicyNumber & "     Insured: " & Form1.txtForm1Voorl.Text & " " & Form1.txtForm1Versekerde.Text
        blnloading = False
        VeldeSkoonmaak()
        frmKntdetchequeVisibility(False)
        If Not frmKontant.blnNuweBetaling Then
            frmKontant.FrmKontantVulVelde()
        End If

        If frmKontant.optAllTransactions.Checked Or frmKontant.optVT.Checked Then
            strOntvTipe = frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(2).Value
            'frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(0).Value
            If strOntvTipe.Trim = "VT" Then
                blnVt_betaling = True
            Else
                blnVt_betaling = False
            End If

        End If
        'Andriette 20/08/2014 stel altyd as die default
        optElectronic.Checked = True
    End Sub

    Private Sub optCheque_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optCheque.CheckedChanged

        If optCheque.Checked Then
            strBetaalTipe = "T"
            frmKntdetchequeVisibility(True)
        End If
    End Sub

    Private Sub optCash_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optCash.CheckedChanged
        strBetaalTipe = "K"
    End Sub


    Private Sub optElectronic_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optElectronic.CheckedChanged

        If optElectronic.Checked Then
            strBetaalTipe = "E"
            frmKntdetchequeVisibility(False)
        End If
    End Sub

    Private Sub optFirstPayment_CheckedChanged(sender As System.Object, e As System.EventArgs)
        strOntvTipe = "EB"
    End Sub

    Private Sub optPrepaidPayment_CheckedChanged(sender As System.Object, e As System.EventArgs)
        strOntvTipe = "VB"
    End Sub

    Private Sub optPaybackPayment_CheckedChanged(sender As System.Object, e As System.EventArgs)
        strOntvTipe = "TB"
    End Sub

    Private Sub txtAmount_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.Leave
        Me.txtAmount.Text = Format(CDbl(Val(Me.txtAmount.Text)), "0.00")

    End Sub

    Private Sub txtReceiptnr_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        'kyk of kwitansienr uniek is
        Dim param() As SqlParameter = {New SqlParameter("@Kwitansie", SqlDbType.NVarChar)}
        param(0).Value = Me.txtReceiptnr.Text

        Dim readers As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.checkduplicateKwitansie", param)

        While readers.Read
            MsgBox("A receipt with this number already exists.")
            Me.txtReceiptnr.Focus()
            Exit Sub
        End While

    End Sub

    Private Sub txtChequenr_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        'kyk of tjeknr uniek is
        Dim param() As SqlParameter = {New SqlParameter("@Tjek", SqlDbType.NVarChar)}
        param(0).Value = Me.txtChequenr.Text

        Dim readers As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.checkduplicateTjek", param)

        While readers.Read
            MsgBox("A cheque nr with this number already exists.")
            Me.txtChequenr.Focus()
            Exit Sub
        End While
    End Sub

    '------------------- Subs en Funksies


    Private Function PaymentValidation()
        'tipe betaling moet gekies wees
        'If Me.optFirstPayment.Checked = False And Me.optMonthlyCash.Checked = False And Me.optMonthlyDebit.Checked = False And Me.optMonthlySalary.Checked = False And Me.optTermPolicy.Checked = False And Me.optPaybackPayment.Checked = False And Me.optPrepaidPayment.Checked = False And Me.optVT.Checked = False And Me.optmonthlyElectronic.checked = False Then
        '    MsgBox("You have to pick a type of payment option")
        '    blnPaymentValidation = False
        '    Exit Sub
        'End If
        'radio button moet gekies wees
        If Me.optCheque.Checked = False And Me.optCash.Checked = False And Me.optElectronic.Checked = False Then
            MsgBox("Please select a payment option.")
            Return False
            Exit Function
        End If

        If Me.txtReceiptnr.Text = "" Or IsDBNull(Me.txtReceiptnr.Text) Then
            MsgBox("Please enter the Receipt number.")

            Me.txtReceiptnr.Focus()
            Return False
            Exit Function
        End If

        'Bedrag moet in wees
        If txtAmount.Text = "" Or IsDBNull(txtAmount.Text) Or (txtAmount.Text <> "" And Val(txtAmount.Text) <= 0) Then
            MsgBox("Please enter the amount.")
            ' blnPaymentValidation = False
            Me.txtAmount.Focus()
            Return False
            Exit Function
        End If

        'kwitansie moet ingevul wees


        'memo moet ingevul wees
        'andriette 20/08/2014 moet nie verpligtend wees nie
        'If Me.txtCashMemo.Text = "" Or IsDBNull(Me.txtCashMemo.Text) Then
        '    MsgBox("The memo must be entered.")
        '    blnPaymentValidation = False
        '    Me.txtCashMemo.Focus()
        '    Exit Sub
        'End If

        'as dit tjek is, moet die volgende ook ingevul wees
        If Me.optCheque.Checked Then
            'Tjek besonderhede in wees
            If Me.txtChequeInfo.Text = "" Or IsDBNull(Me.txtChequeInfo.Text) Then
                MsgBox("Please enter the Cheque information.")
                Me.txtChequeInfo.Focus()
                Return False
                Exit Function
            End If

            'tjek nr moet ingevul wees
            If Me.txtChequenr.Text = "" Or IsDBNull(Me.txtChequenr.Text) Then
                MsgBox("Please enter the Cheque number.")
                Me.txtChequenr.Focus()
                Return False
                Exit Function
            End If

            'datum moet ingevul wees
            If Me.dtpChequeDate.Text = "" Or IsDBNull(Me.dtpChequeDate.Text) Then
                MsgBox("Please enter the Cheque date.")
                Me.dtpChequeDate.Focus()
                Return False
                Exit Function
            End If
        End If
        Return True
    End Function


    'Private Sub SaveKontant()
    '    Dim dtedatumaangevra As Date
    '    Dim dblNettoBedrag As Double = 0
    '    Dim params() As SqlParameter = {New SqlParameter("@pkKontant", SqlDbType.Int), _
    '                            New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
    '                            New SqlParameter("@vord_dat", SqlDbType.DateTime), _
    '                            New SqlParameter("@Premie", SqlDbType.Money), _
    '                            New SqlParameter("@Vord_Premie", SqlDbType.Money), _
    '                            New SqlParameter("@afsluit_dat", SqlDbType.DateTime), _
    '                            New SqlParameter("@jaar", SqlDbType.SmallInt), _
    '                            New SqlParameter("@maand", SqlDbType.SmallInt), _
    '                            New SqlParameter("@trans_dat", SqlDbType.DateTime), _
    '                            New SqlParameter("@Betaalwyse", SqlDbType.NVarChar), _
    '                            New SqlParameter("@verw1", SqlDbType.NVarChar), _
    '                            New SqlParameter("@verw2", SqlDbType.NVarChar), _
    '                            New SqlParameter("@verw3", SqlDbType.NVarChar), _
    '                            New SqlParameter("@verw4", SqlDbType.NVarChar), _
    '                            New SqlParameter("@verw5", SqlDbType.NVarChar), _
    '                            New SqlParameter("@gekans", SqlDbType.Bit), _
    '                            New SqlParameter("@kans_dat", SqlDbType.DateTime), _
    '                            New SqlParameter("@tipe", SqlDbType.NVarChar), _
    '                            New SqlParameter("@kontant_tipe", SqlDbType.NVarChar), _
    '                            New SqlParameter("@tjekno_in", SqlDbType.NVarChar), _
    '                            New SqlParameter("@TJEKDATUM", SqlDbType.DateTime), _
    '                            New SqlParameter("@TJEKBESONDERHEDE", SqlDbType.NVarChar), _
    '                            New SqlParameter("@kwitansie", SqlDbType.NVarChar), _
    '                            New SqlParameter("@vt_trans_dat", SqlDbType.DateTime), _
    '                            New SqlParameter("@mk_trans_dat", SqlDbType.DateTime), _
    '                            New SqlParameter("@jk_trans_dat", SqlDbType.DateTime), _
    '                            New SqlParameter("@eb_trans_dat", SqlDbType.DateTime), _
    '                            New SqlParameter("@ms_trans_dat", SqlDbType.DateTime), _
    '                            New SqlParameter("@ei_trans_dat", SqlDbType.DateTime), _
    '                            New SqlParameter("@md_trans_dat", SqlDbType.DateTime), _
    '                            New SqlParameter("@gg_trans_dat", SqlDbType.DateTime), _
    '                            New SqlParameter("@me_trans_dat", SqlDbType.DateTime), _
    '                            New SqlParameter("@nuwe_tjekno", SqlDbType.NVarChar), _
    '                            New SqlParameter("@tjekno", SqlDbType.NVarChar), _
    '                            New SqlParameter("@tjekno_uit", SqlDbType.NVarChar), _
    '                            New SqlParameter("@eisno", SqlDbType.NVarChar), _
    '                            New SqlParameter("@kwit_boek", SqlDbType.NVarChar), _
    '                            New SqlParameter("@fklangtermynpolis", SqlDbType.Int), _
    '                            New SqlParameter("@LtpTipe", SqlDbType.NVarChar), _
    '                            New SqlParameter("@fklangtermynpolis_kontant", SqlDbType.NVarChar), _
    '                            New SqlParameter("@vtdatumaangevra", SqlDbType.DateTime), _
    '                            New SqlParameter("@area", SqlDbType.NVarChar)}

    '        'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
    '        'Andriette 03/07/2014 Edit verskil van nuwe
    '    If frmKontant.blnNuweBetaling Then ' skep ' nuwe inskrywing
    '        Try
    '            Using conn As SqlConnection = SqlHelper.GetConnection


    '                params(0).Value = DBNull.Value '"@pkKontant"   0
    '                params(1).Value = glbPolicyNumber  '"@POLISNO"     1
    '                params(2).Value = Now()  '"@vord_dat"    2
    '                params(3).Value = DBNull.Value  '"@Premie"      3
    '                params(4).Value = txtAmount.Text '"@Vord_Premie" 4
    '                params(5).Value = DBNull.Value '"@afsluit_dat" 5
    '                If frmKontant.optFirstPayment.Checked Or frmKontant.optPaybackPayment.Checked Or frmKontant.optPrepaidPayment.Checked Then
    '                    params(6).Value = dteCoverCommence.Value.Year
    '                    params(7).Value = dteCoverCommence.Value.Month
    '                Else
    '                    params(6).Value = frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(0).Value '"@jaar"        6
    '                    params(7).Value = frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(1).Value '"@maand" 
    '                End If
    '                params(8).Value = Now() '"@trans_dat"   8
    '                'Betaalwyse

    '                If frmKontant.optFirstPayment.Checked Then
    '                    params(9).Value = "EB"
    '                    params(17).Value = "EB"
    '                    params(23).Value = DBNull.Value
    '                    params(24).Value = DBNull.Value
    '                    params(25).Value = DBNull.Value
    '                    params(26).Value = Now()
    '                    params(27).Value = DBNull.Value
    '                    params(28).Value = DBNull.Value
    '                    params(29).Value = DBNull.Value
    '                    params(30).Value = Now()
    '                    params(31).Value = DBNull.Value
    '                    params(40).Value = DBNull.Value 'vtdatumaangevra
    '                ElseIf frmKontant.optPaybackPayment.Checked Then
    '                    params(9).Value = "TB"
    '                    params(17).Value = "TB"
    '                    params(23).Value = DBNull.Value
    '                    params(24).Value = DBNull.Value
    '                    params(25).Value = DBNull.Value
    '                    params(26).Value = DBNull.Value
    '                    params(27).Value = DBNull.Value
    '                    params(28).Value = DBNull.Value
    '                    params(29).Value = DBNull.Value
    '                    params(30).Value = Now()
    '                    params(31).Value = DBNull.Value
    '                    params(40).Value = DBNull.Value 'vtdatumaangevra
    '                ElseIf frmKontant.optPrepaidPayment.Checked Then
    '                    params(9).Value = "VB"
    '                    params(17).Value = "VB"
    '                    params(23).Value = DBNull.Value
    '                    params(24).Value = DBNull.Value
    '                    params(25).Value = DBNull.Value
    '                    params(26).Value = DBNull.Value
    '                    params(27).Value = DBNull.Value
    '                    params(28).Value = DBNull.Value
    '                    params(29).Value = DBNull.Value
    '                    params(30).Value = Now()
    '                    params(31).Value = DBNull.Value
    '                ElseIf frmKontant.optVT.Checked Or _
    '                    frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(2).Value.ToString.ToUpper = "VT" Then
    '                    ' kry die datumaangevra uit die maand_vtDetails tabel uit sommer hier
    '                    dtedatumaangevra = FetchDatumAangevra(frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(0).Value, frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(1).Value)
    '                    params(9).Value = "VT"
    '                    params(17).Value = "VT"
    '                    params(23).Value = frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(8).Value 'Now()   ' vt_trans_dat
    '                    params(24).Value = DBNull.Value
    '                    params(25).Value = DBNull.Value
    '                    params(26).Value = DBNull.Value
    '                    params(27).Value = DBNull.Value
    '                    params(28).Value = DBNull.Value
    '                    params(29).Value = DBNull.Value
    '                    params(30).Value = Now()
    '                    params(31).Value = DBNull.Value
    '                    params(40).Value = dtedatumaangevra  'vtdatumaangevra
    '                ElseIf frmKontant.optMonthlyCash.Checked Or _
    '                    frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(2).Value.ToString.ToUpper = "MK" Then
    '                    params(9).Value = "MK"
    '                    params(17).Value = "MK"
    '                    params(23).Value = DBNull.Value
    '                    params(24).Value = Now()
    '                    params(25).Value = DBNull.Value
    '                    params(26).Value = DBNull.Value
    '                    params(27).Value = DBNull.Value
    '                    params(28).Value = DBNull.Value
    '                    params(29).Value = DBNull.Value
    '                    params(30).Value = Now()
    '                    params(31).Value = DBNull.Value
    '                    params(40).Value = DBNull.Value 'vtdatumaangevra
    '                ElseIf frmKontant.optMonthlySalary.Checked Or _
    '                    frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(2).Value.ToString.ToUpper = "MS" Then
    '                    params(9).Value = "MS"
    '                    params(17).Value = "MS"
    '                    params(23).Value = DBNull.Value
    '                    params(24).Value = DBNull.Value
    '                    params(25).Value = DBNull.Value
    '                    params(26).Value = DBNull.Value
    '                    params(27).Value = Now()
    '                    params(28).Value = DBNull.Value
    '                    params(29).Value = DBNull.Value
    '                    params(30).Value = Now()
    '                    params(31).Value = DBNull.Value
    '                    params(40).Value = DBNull.Value 'vtdatumaangevra
    '                ElseIf frmKontant.optMonthlyDebit.Checked Or _
    '                    frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(2).Value.ToString.ToUpper = "MD" Then
    '                    params(9).Value = "MD"
    '                    params(17).Value = "MD"
    '                    params(23).Value = DBNull.Value
    '                    params(24).Value = DBNull.Value
    '                    params(25).Value = DBNull.Value
    '                    params(26).Value = DBNull.Value
    '                    params(27).Value = DBNull.Value
    '                    params(28).Value = DBNull.Value
    '                    params(29).Value = Now()
    '                    params(30).Value = Now()
    '                    params(31).Value = DBNull.Value
    '                    params(40).Value = DBNull.Value 'vtdatumaangevra
    '                ElseIf frmKontant.optMonthlyElectronic.Checked Or _
    '                    frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(2).Value.ToString.ToUpper = "ME" Then
    '                    params(9).Value = "ME"
    '                    params(17).Value = "ME"
    '                    params(23).Value = DBNull.Value
    '                    params(24).Value = DBNull.Value
    '                    params(25).Value = DBNull.Value
    '                    params(26).Value = DBNull.Value
    '                    params(27).Value = DBNull.Value
    '                    params(28).Value = DBNull.Value
    '                    params(29).Value = DBNull.Value
    '                    params(30).Value = Now()
    '                    params(31).Value = Now()
    '                    params(40).Value = DBNull.Value 'vtdatumaangevra
    '                ElseIf frmKontant.optTermPolicy.Checked Or _
    '                    frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(2).Value.ToString.ToUpper = "LT" Then
    '                    params(9).Value = "LT"
    '                    params(17).Value = "LT"
    '                    params(23).Value = DBNull.Value
    '                    params(24).Value = DBNull.Value
    '                    params(25).Value = Now()
    '                    params(26).Value = DBNull.Value
    '                    params(27).Value = DBNull.Value
    '                    params(28).Value = DBNull.Value
    '                    params(29).Value = DBNull.Value
    '                    params(30).Value = Now()
    '                    params(31).Value = DBNull.Value
    '                    params(40).Value = DBNull.Value 'vtdatumaangevra
    '                End If
    '                params(22).Value = ""  '"@Kwitansie"   10

    '                Dim strWatOoris As String = txtCashMemo.Text.Trim

    '                If txtCashMemo.Text.Trim.Length > 80 Then
    '                    Dim strmemo As String = strWatOoris.Substring(0, 79)
    '                    params(10).Value = strWatOoris.Substring(0, 79) '"@verw1"       11
    '                    strWatOoris = txtCashMemo.Text.Trim.Substring(80, strWatOoris.Length - 80)
    '                    If strWatOoris.Length > 80 Then
    '                        params(11).Value = strWatOoris.Substring(0, 79)   '"@verw2"       12
    '                        strWatOoris = txtCashMemo.Text.Trim.Substring(80, strWatOoris.Length - 80)
    '                        If strWatOoris.Length > 80 Then
    '                            params(12).Value = strWatOoris.Substring(0, 79) '"@verw3"       13
    '                            strWatOoris = txtCashMemo.Text.Trim.Substring(80, strWatOoris.Length - 80)
    '                            If strWatOoris.Length > 80 Then
    '                                params(13).Value = strWatOoris.Substring(0, 79) '"@verw4"       14
    '                                strWatOoris = txtCashMemo.Text.Trim.Substring(80, strWatOoris.Length - 80)
    '                                params(14).Value = strWatOoris.Trim  '"@verw5"       15
    '                            Else
    '                                params(13).Value = strWatOoris.Trim '"@verw4"       14
    '                            End If
    '                        Else
    '                            params(12).Value = strWatOoris.Trim '"@verw3"       13
    '                        End If
    '                    Else
    '                        params(11).Value = strWatOoris.Trim  '"@verw2"       12
    '                    End If
    '                Else
    '                    params(10).Value = txtCashMemo.Text.Trim '"@verw1"       11
    '                End If

    '                params(15).Value = False '"@gekans"      16
    '                params(16).Value = DBNull.Value '"@kans_dat",   17

    '                If optCash.Checked Then '"@kontanttipe"            25
    '                    params(18).Value = "K"
    '                ElseIf optCheque.Checked Then
    '                    params(18).Value = "T"
    '                ElseIf optElectronic.Checked Then
    '                    params(18).Value = "E"
    '                End If

    '                params(32).Value = ""  '"@tjekno"          32
    '                params(33).Value = ""  '"@tjekno_uit"      33
    '                params(34).Value = ""  '"@tjekno_in"       34
    '                params(35).Value = "" '"@eisno"           35
    '                If Not optCheque.Checked Then
    '                    params(19).Value = ""   '@nuwe_tjekno       19
    '                    params(20).Value = DBNull.Value         '"@TJEKDATUM"       20
    '                    params(21).Value = ""          '"@TJEKBESONDERHEDE"   21
    '                Else
    '                    params(19).Value = txtChequenr.Text    '@nuwe_tjekno       19
    '                    params(20).Value = dtpChequeDate.Value          '"@TJEKDATUM"       20
    '                    params(21).Value = txtChequeInfo.Text           '"@TJEKBESONDERHEDE"   21
    '                End If
    '                params(36).Value = txtReceiptnr.Text  '"@kwit_boek"       36
    '                params(37).Value = DBNull.Value '"@fklangtermynpolis"   37
    '                params(38).Value = ""            '"@LTPtipe"             38
    '                params(39).Value = ""  '"@fklangtermynpolis_kontant" 39

    '                'params(40).Value = DBNull.Value 'vtdatumaangevra

    '                params(41).Value = Area.tak_afkorting          '"@Area"                    41 

    '                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Stats5.UpdateKontant", params)
    '                If conn.State = ConnectionState.Open Then
    '                    conn.Close()
    '                End If

    '            End Using
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        End Try
    '    Else ' edit 'n inskrywing

    '        Try
    '            Using conn As SqlConnection = SqlHelper.GetConnection
    '                params(0).Value = KontantItem.pk_waarde  '"@pkKontant"   0
    '                params(1).Value = KontantItem.polisno  '"@POLISNO"     1
    '                params(2).Value = KontantItem.vord_dat  '"@vord_dat"    2
    '                params(3).Value = KontantItem.premie '"@Premie"      3
    '                params(4).Value = txtAmount.Text '"@Vord_Premie" 4
    '                ' params(5).Value = KontantItem.afsluit_dat '"@afsluit_dat" 5
    '                If KontantItem.afsluit_dat.ToString.Substring(0, 10) = "01/01/0001" Then
    '                    params(5).Value = DBNull.Value
    '                Else
    '                    params(5).Value = KontantItem.afsluit_dat  '"@kans_dat",   17
    '                End If

    '                params(6).Value = KontantItem.jaar '"@jaar"        6
    '                params(7).Value = KontantItem.maand '"@maand"       7
    '                params(8).Value = KontantItem.trans_dat '"@trans_dat"   8
    '                params(9).Value = KontantItem.betaalwyse '"@Betaalwyse"  9

    '                Dim strWatOoris As String = txtCashMemo.Text.Trim

    '                If txtCashMemo.Text.Trim.Length > 80 Then
    '                    Dim strmemo As String = strWatOoris.Substring(0, 79)
    '                    params(10).Value = strWatOoris.Substring(0, 79) '"@verw1"       11
    '                    strWatOoris = strWatOoris.Substring(80, strWatOoris.Length - 80)
    '                    If strWatOoris.Length > 80 Then
    '                        params(11).Value = strWatOoris.Substring(0, 79)   '"@verw2"       12
    '                        strWatOoris = strWatOoris.Substring(80, strWatOoris.Length - 80)
    '                        If strWatOoris.Length > 80 Then
    '                            params(12).Value = strWatOoris.Substring(0, 79) '"@verw3"       13
    '                            strWatOoris = strWatOoris.Substring(80, strWatOoris.Length - 80)
    '                            If strWatOoris.Length > 80 Then
    '                                params(13).Value = strWatOoris.Substring(0, 79) '"@verw4"       14
    '                                strWatOoris = strWatOoris.Substring(80, strWatOoris.Length - 80)
    '                                params(14).Value = strWatOoris.Trim  '"@verw5"       15
    '                            Else
    '                                params(13).Value = strWatOoris.Trim '"@verw4"       14
    '                            End If
    '                        Else
    '                            params(12).Value = strWatOoris.Trim '"@verw3"       13
    '                        End If
    '                    Else
    '                        params(11).Value = strWatOoris.Trim  '"@verw2"       12
    '                    End If
    '                Else
    '                    params(10).Value = txtCashMemo.Text.Trim '"@verw1"       11
    '                End If
    '                params(15).Value = KontantItem.gekans '"@gekans"      16
    '                If KontantItem.kans_dat.ToString.Substring(0, 10) = "01/01/0001" Then
    '                    params(16).Value = DBNull.Value
    '                Else
    '                    params(16).Value = KontantItem.kans_dat '"@kans_dat",   17
    '                End If

    '                params(17).Value = KontantItem.tipe    '"@tipe"            25
    '                If optCash.Checked Then  '"@kontant_tipe" 
    '                    params(18).Value = "K"
    '                ElseIf optCheque.Checked Then
    '                    params(18).Value = "T"
    '                ElseIf optElectronic.Checked Then
    '                    params(18).Value = "E"
    '                End If

    '                params(19).Value = dtpChequeDate.Value    '"@tjekno_in"       31
    '                params(20).Value = KontantItem.TJEKDATUM          '"@TJEKDATUM"       33
    '                params(21).Value = txtChequeInfo.Text           '"@TJEKBESONDERHEDE"    34
    '                params(22).Value = KontantItem.kwitansie        '"@kwit_boek"       35

    '                If KontantItem.vt_trans_dat.ToString.Substring(0, 10) = "01/01/0001" Then
    '                    params(23).Value = DBNull.Value
    '                Else
    '                    params(23).Value = KontantItem.vt_trans_dat
    '                End If

    '                If KontantItem.mk_trans_dat.ToString.Substring(0, 10) = "01/01/0001" Then
    '                    params(24).Value = DBNull.Value
    '                Else
    '                    params(24).Value = KontantItem.mk_trans_dat
    '                End If

    '                If KontantItem.jk_trans_dat.ToString.Substring(0, 10) = "01/01/0001" Then
    '                    params(25).Value = DBNull.Value
    '                Else
    '                    params(25).Value = KontantItem.jk_trans_dat
    '                End If

    '                If KontantItem.eb_trans_dat.ToString.Substring(0, 10) = "01/01/0001" Then
    '                    params(26).Value = DBNull.Value
    '                Else
    '                    params(26).Value = KontantItem.eb_trans_dat
    '                End If

    '                If KontantItem.ms_trans_dat.ToString.Substring(0, 10) = "01/01/0001" Then
    '                    params(27).Value = DBNull.Value
    '                Else
    '                    params(27).Value = KontantItem.ms_trans_dat
    '                End If

    '                If KontantItem.ei_trans_dat.ToString.Substring(0, 10) = "01/01/0001" Then
    '                    params(28).Value = DBNull.Value
    '                Else
    '                    params(28).Value = KontantItem.ei_trans_dat
    '                End If

    '                If KontantItem.md_trans_dat.ToString.Substring(0, 10) = "01/01/0001" Then
    '                    params(29).Value = DBNull.Value
    '                Else
    '                    params(29).Value = KontantItem.md_trans_dat
    '                End If

    '                If KontantItem.gg_trans_dat.ToString.Substring(0, 10) = "01/01/0001" Then
    '                    params(30).Value = DBNull.Value
    '                Else
    '                    params(30).Value = KontantItem.gg_trans_dat
    '                End If

    '                If KontantItem.Me_Trans_Dat.ToString.Substring(0, 10) = "01/01/0001" Then
    '                    params(31).Value = DBNull.Value
    '                Else
    '                    params(31).Value = KontantItem.Me_Trans_Dat
    '                End If

    '                params(32).Value = KontantItem.nuwe_tjekno
    '                params(33).Value = KontantItem.tjekno
    '                params(34).Value = KontantItem.tjekno_uit
    '                params(35).Value = KontantItem.EISNO
    '                params(36).Value = KontantItem.kwit_boek
    '                params(37).Value = KontantItem.FkLangtermynpolis
    '                params(39).Value = KontantItem.FKLangtermynpolis_Kontant
    '                If KontantItem.VTDatumAangevra.ToString.Substring(0, 10) = "01/01/0001" Then
    '                    params(40).Value = DBNull.Value
    '                Else
    '                    params(40).Value = KontantItem.VTDatumAangevra
    '                End If
    '                params(41).Value = KontantItem.area

    '                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Stats5.UpdateKontant", params)
    '                If conn.State = ConnectionState.Open Then
    '                    conn.Close()
    '                End If

    '            End Using
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
    '        End Try
    '    End If

    '    If blnVt_betaling Then
    '        If DoenVtopdaterings() Then
    '            dblNettoBedrag = KontantItem.vord_premie - txtAmount.Text
    '            frmKontant.UpdateMaandVtBalans(dblNettoBedrag)
    '        End If
    '    End If

    '    frmKontant.UpdateMaandDetails(Now(), txtAmount.Text, Now(), "", Now.Month, Now.Year)
    'End Sub

    Private Sub ClearTextboxes()

        Me.txtReceiptnr.Clear()
        Me.txtChequenr.Clear()
        Me.txtChequeInfo.Clear()
        Me.txtCashMemo.Clear()
        Me.txtAmount.Clear()
        optCheque.Checked = False
        optElectronic.Checked = False
        dteCoverCommence.Value = Now()
        Me.dtpChequeDate.Value = Now()
    End Sub

    'Andriette 08/08/2014 word nie meer gebruik nie
    'Private Sub PopulateGrid()
    '    Dim strTipe_ontv As String
    '    Dim Intposisie As Integer = -1
    '    intRow = 0
    '    frmKontant.dgvMonetereTransaksies.AutoGenerateColumns = False
    '    frmKontant.dgvMonetereTransaksies.Refresh()
    '    frmKontant.dgvMonetereTransaksies.DataSource = Nothing

    '    Try
    '        Using conn As SqlConnection = SqlHelper.GetConnection
    '            Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
    '                                            New SqlParameter("@tipe", SqlDbType.NVarChar)}
    '            param(0).Value = Persoonl.POLISNO
    '            Select Case strOntvTipe
    '                Case "MD"
    '                    param(1).Value = "4"
    '                Case "MK"
    '                    param(1).Value = "1"
    '                Case "ME"
    '                    param(1).Value = "5"
    '                Case "LT"
    '                    param(1).Value = "6"
    '                Case "MS"
    '                    param(1).Value = "3"
    '                Case Else
    '                    param(1).Value = "0"
    '            End Select

    '            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchTransaksiesPerPolisnoTipe]", param)
    '            Dim TransList As List(Of KontantEntity) = New List(Of KontantEntity)
    '            While reader.Read()
    '                Dim item As KontantEntity = New KontantEntity()
    '                'Andriette 14/10/2013 stel die begin datum vir die datum control
    '                If Intposisie = -1 Then
    '                    dteFrom = reader("trans_dat")
    '                End If
    '                'select type of payment
    '                If reader("betaalwyse") IsNot DBNull.Value Then
    '                    Select Case reader("betaalwyse")
    '                        Case "1"
    '                            'strTipe_ontv = "MK"
    '                            item.tipe = "MK"
    '                        Case "3"
    '                            ' strTipe_ontv = "MS"
    '                            item.tipe = "MS"
    '                        Case "4"
    '                            ' strTipe_ontv = "MD"
    '                            item.tipe = "MD"
    '                        Case "5"
    '                            'strTipe_ontv = "ME"
    '                            item.tipe = "ME"
    '                        Case "6"
    '                            ' strTipe_ontv = "LT"
    '                            item.tipe = "LT"
    '                        Case Else
    '                            ' strTipe_ontv = reader("tipe")
    '                            item.tipe = reader("betaalwyse")
    '                    End Select
    '                Else
    '                    strTipe_ontv = "VT"
    '                    intCountVt = intCountVt + 1
    '                End If
    '                '   reader("WN_POLIS") IsNot DBNull.Value Then

    '                If reader("afsluit_dat") IsNot DBNull.Value Then
    '                    item.afsluit_dat = reader("afsluit_dat")
    '                Else
    '                    item.afsluit_dat = Nothing
    '                End If
    '                If reader("premie") IsNot DBNull.Value Then
    '                    item.premie = reader("premie")
    '                Else
    '                    item.premie = 0
    '                End If
    '                If reader("vord_premie") IsNot DBNull.Value Then
    '                    item.vord_premie = reader("vord_premie")
    '                Else
    '                    item.vord_premie = 0
    '                End If
    '                If reader("kwitansie") IsNot DBNull.Value Then
    '                    item.kwitansie = reader("kwitansie")
    '                Else
    '                    item.kwitansie = ""
    '                End If
    '                If reader("vord_dat") IsNot DBNull.Value Then
    '                    item.vord_dat = reader("vord_dat")
    '                Else
    '                    item.vord_dat = Nothing
    '                End If
    '                If reader("trans_dat") IsNot DBNull.Value Then
    '                    item.trans_dat = reader("trans_dat")
    '                Else
    '                    item.trans_dat = Nothing
    '                End If
    '                If reader("kontant_tipe") IsNot DBNull.Value Then
    '                    item.kontant_tipe = reader("kontant_tipe")
    '                Else
    '                    item.kontant_tipe = ""
    '                End If

    '                'Andriette 14/10/2013 sit oor op die kontant entity
    '                '     DataGridView1.Rows.Insert(intRow, strTipe_ontv, reader("afsluit_dat"), reader("premie"), reader("vord_premie"), reader("kwitansie"), reader("vord_dat"), reader("trans_dat"), IIf(IsDBNull(reader("kontant_tipe")), "", reader("kontant_tipe")), intRow)

    '                TransList.Add(item)
    '                '  intRow = intRow + 1
    '            End While

    '            dteto = Today()
    '            frmKontant.dgvMonetereTransaksies.DataSource = TransList
    '            If conn.State = ConnectionState.Open Then
    '                conn.Close()
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '    End Try

    'End Sub

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

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click
        Dim dblnettobedrag As Double = 0
        If PaymentValidation() = True Then
            VulEntityMetveranderinge()
            frmKontant.SaveKontantTransaksie(txtAmount.Text)
            If blnVt_betaling Then
                If DoenVtopdaterings() Then
                    dblnettobedrag = frmKontant.KontantItem.vord_premie - txtAmount.Text
                    frmKontant.UpdateMaandVtBalans(dblnettobedrag)
                End If
            End If
            ClearTextboxes()
            frmKontant.frmkontantPopulateGrid()
            'PopulateGrid()
            Me.Close()
        End If


    End Sub



    Public Sub frmKntdetchequeVisibility(blnVisible As Boolean)

        txtChequeInfo.Visible = blnVisible
        dtpChequeDate.Visible = blnVisible
        txtChequenr.Visible = blnVisible
        Label7.Visible = blnVisible
        Label8.Visible = blnVisible
        Label9.Visible = blnVisible

    End Sub

    Private Function DoenVtopdaterings()
        '  Dim dtedatumaangevra As Date
        Dim arrVeldName(2) As String
        Dim arrVeldwaardes(2) As String
        Dim blnsukses As Boolean = True
        '  Dim dteVt_Trans_Dat As Date
        arrVeldName(0) = "vt_ingevorder"
        arrVeldName(1) = "vt_vord_datum"
        arrVeldName(2) = "kwit_boek"
        arrVeldwaardes(0) = (txtAmount.Text)
        arrVeldwaardes(1) = Now()
        arrVeldwaardes(2) = txtReceiptnr.Text
        '  dteVt_Trans_Dat = frmKontant.KontantVt_Trans_dat(FetchKontantPK(txtReceiptnr.Text))
        blnsukses = frmKontant.UpdateMaand_vt_details(arrVeldName, arrVeldwaardes, frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(0).Value, frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(1).Value)

        '   dtedatumaangevra = UpdateMaand_Vt_Details()
        '    Updatemaandkontant(dtedatumaangevra)
        Return blnsukses
    End Function

    Private Sub VeldeSkoonmaak()
        txtCashMemo.Text = ""
        txtAmount.Text = ""
        txtChequeInfo.Text = ""
        txtChequenr.Text = ""
        txtReceiptnr.Text = ""
        dtpChequeDate.Text = Now()
        dteCoverCommence.Text = Now()
        optElectronic.Checked = True

    End Sub

    Private Function FetchDatumAangevra(ByVal intJaar As Integer, ByVal intMaand As Integer)
        Dim dteDatumAangevra As DateTime
        Dim blndatumaangevranull As Boolean = False

        Dim params() As SqlParameter = {New SqlParameter("@POLISNO ", SqlDbType.NVarChar), _
                                        New SqlParameter("@jaar", SqlDbType.Int), _
                                       New SqlParameter("@maand", SqlDbType.Int)}
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                params(0).Value = glbPolicyNumber
                'params(1).Value = DateTime.Parse(frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(8).Value)
                params(1).Value = intJaar
                params(2).Value = intMaand
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchVT_DetailsByTransDat_delete", params)

                If reader.HasRows Then
                    If reader.Read Then
                        If reader("Datumaangevra") Is DBNull.Value Then
                            blndatumaangevranull = False
                            If reader("Vt_Datum") IsNot DBNull.Value Then
                                dteDatumAangevra = reader("Vt_Datum")
                            End If
                        Else
                            dteDatumAangevra = reader("Datumaangevra")
                        End If
                    End If
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        If blndatumaangevranull Then
            Return Nothing
        Else
            Return dteDatumAangevra
        End If

    End Function

    Private Function FetchKontantPK(txtKwitansienr)
        Dim params() As SqlParameter = {New SqlParameter("@POLISNO ", SqlDbType.NVarChar), _
                                        New SqlParameter("@Kwit_boek", SqlDbType.NVarChar)}
        Dim intPkKontant As Integer = 0
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                params(0).Value = glbPolicyNumber
                params(1).Value = txtKwitansienr
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchkontantbyKwitansie", params)
                If reader.HasRows Then
                    If reader.Read Then
                        intPkKontant = reader("pkkontant")
                    End If
                Else
                    Return Nothing
                End If


                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return intPkKontant
    End Function

    Private Sub txtReceiptnr_Leave1(sender As Object, e As System.EventArgs) Handles txtReceiptnr.Leave
        Dim intKontantpk As Integer
        intKontantpk = FetchKontantPK(txtReceiptnr.Text)
        If intKontantpk > 0 Then
            MsgBox("The Receipt number must be unique", MsgBoxStyle.Exclamation)
            txtReceiptnr.Text = ""
            txtReceiptnr.Focus()
        End If
    End Sub

    Private Sub VulEntityMetveranderinge()
        Dim dtedatumaangevra As DateTime

        Dim strWatOoris As String = txtCashMemo.Text.Trim

        If txtCashMemo.Text.Trim.Length > 80 Then
            Dim strmemo As String = strWatOoris.Substring(0, 79)
            frmKontant.KontantItem.verw1 = strWatOoris.Substring(0, 79) '"@verw1"       11
            strWatOoris = strWatOoris.Substring(80, strWatOoris.Length - 80)
            If strWatOoris.Length > 80 Then
                frmKontant.KontantItem.verw2 = strWatOoris.Substring(0, 79)   '"@verw2"       12
                strWatOoris = strWatOoris.Substring(80, strWatOoris.Length - 80)
                If strWatOoris.Length > 80 Then
                    frmKontant.KontantItem.verw3 = strWatOoris.Substring(0, 79) '"@verw3"       13
                    strWatOoris = strWatOoris.Substring(80, strWatOoris.Length - 80)
                    If strWatOoris.Length > 80 Then
                        frmKontant.KontantItem.verw4 = strWatOoris.Substring(0, 79) '"@verw4"       14
                        strWatOoris = strWatOoris.Substring(80, strWatOoris.Length - 80)
                        frmKontant.KontantItem.verw5 = strWatOoris.Trim  '"@verw5"       15
                    Else
                        frmKontant.KontantItem.verw4 = strWatOoris.Trim '"@verw4"       14
                    End If
                Else
                    frmKontant.KontantItem.verw3 = strWatOoris.Trim '"@verw3"       13
                End If
            Else
                frmKontant.KontantItem.verw2 = strWatOoris.Trim  '"@verw2"       12
            End If
        Else
            frmKontant.KontantItem.verw1 = txtCashMemo.Text.Trim '"@verw1"       11
        End If

        If frmKontant.blnNuweBetaling Then
            frmKontant.KontantItem.pk_waarde = ""
            frmKontant.KontantItem.vord_dat = Now()
            frmKontant.KontantItem.premie = 0
            frmKontant.KontantItem.vord_premie = txtAmount.Text
            If frmKontant.optFirstPayment.Checked Or
                frmKontant.optPaybackPayment.Checked Or
                frmKontant.optPrepaidPayment.Checked Then
                frmKontant.KontantItem.jaar = dteCoverCommence.Value.Year
                frmKontant.KontantItem.maand = dteCoverCommence.Value.Month
            Else
                frmKontant.KontantItem.jaar = frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(0).Value
                frmKontant.KontantItem.maand = frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(1).Value
            End If
            frmKontant.KontantItem.trans_dat = Now()
            frmKontant.KontantItem.vt_trans_dat = "1900/01/01" '23
            frmKontant.KontantItem.mk_trans_dat = "1900/01/01" '24
            frmKontant.KontantItem.jk_trans_dat = "1900/01/01" '25 
            frmKontant.KontantItem.eb_trans_dat = "1900/01/01" '26
            frmKontant.KontantItem.ms_trans_dat = "1900/01/01" '27
            frmKontant.KontantItem.ei_trans_dat = "1900/01/01" '28
            frmKontant.KontantItem.md_trans_dat = "1900/01/01" '29
            frmKontant.KontantItem.Me_Trans_Dat = "1900/01/01" '31
            frmKontant.KontantItem.VTDatumAangevra = "1900/01/01" '40
            frmKontant.KontantItem.gg_trans_dat = Now()
            frmKontant.KontantItem.afsluit_dat = "1900/01/01"

            If frmKontant.optFirstPayment.Checked Then
                frmKontant.KontantItem.betaalwyse = "EB"
                frmKontant.KontantItem.tipe = "EB"
                frmKontant.KontantItem.eb_trans_dat = Now()
            End If

            If frmKontant.optPaybackPayment.Checked Then
                frmKontant.KontantItem.betaalwyse = "TB"
                frmKontant.KontantItem.tipe = "TB"
            End If
            If frmKontant.optPrepaidPayment.Checked Then
                frmKontant.KontantItem.betaalwyse = "VB"
                frmKontant.KontantItem.tipe = "VB"
            End If
            If frmKontant.optVT.Checked Or _
                frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(2).Value.ToString.ToUpper = "VT" Then
                dtedatumaangevra = FetchDatumAangevra(frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(0).Value, _
                                                      frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(1).Value)
                frmKontant.KontantItem.betaalwyse = "VT"
                frmKontant.KontantItem.tipe = "VT"
                frmKontant.KontantItem.VTDatumAangevra = dtedatumaangevra
            End If
            If frmKontant.optMonthlyCash.Checked Or _
                frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(2).Value.ToString.ToUpper = "MK" Then
                frmKontant.KontantItem.betaalwyse = "MK"
                frmKontant.KontantItem.tipe = "MK"
                frmKontant.KontantItem.mk_trans_dat = Now()
            End If
            If frmKontant.optMonthlySalary.Checked Or _
                frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(2).Value.ToString.ToUpper = "MS" Then
                frmKontant.KontantItem.betaalwyse = "MS"
                frmKontant.KontantItem.tipe = "MS"
                frmKontant.KontantItem.ms_trans_dat = Now()
            End If
            If frmKontant.optMonthlyDebit.Checked Or _
                frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(2).Value.ToString.ToUpper = "MD" Then
                frmKontant.KontantItem.betaalwyse = "MD"
                frmKontant.KontantItem.tipe = "MD"
                frmKontant.KontantItem.md_trans_dat = Now

            End If
            If frmKontant.optMonthlyElectronic.Checked Or _
                 frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(2).Value.ToString.ToUpper = "ME" Then
                frmKontant.KontantItem.betaalwyse = "ME"
                frmKontant.KontantItem.tipe = "ME"
                frmKontant.KontantItem.Me_Trans_Dat = Now()
            End If
            If frmKontant.optTermPolicy.Checked Or _
                frmKontant.dgvMonetereTransaksies.SelectedRows(0).Cells(2).Value.ToString.ToUpper = "LT" Then
                frmKontant.KontantItem.betaalwyse = "LT"
                frmKontant.KontantItem.tipe = "LT"
                frmKontant.KontantItem.jk_trans_dat = Now
            End If

            frmKontant.KontantItem.gekans = 0
            frmKontant.KontantItem.kans_dat = "1900/01/01"

            frmKontant.KontantItem.tjekno = ""
            frmKontant.KontantItem.tjekno_uit = ""
            frmKontant.KontantItem.tjekno_in = ""
            frmKontant.KontantItem.EISNO = ""
            frmKontant.KontantItem.kwit_boek = txtReceiptnr.Text
            frmKontant.KontantItem.FkLangtermynpolis = 0
            frmKontant.KontantItem.LTPtipe = ""
            frmKontant.KontantItem.area = Area.tak_afkorting
        Else
            frmKontant.KontantItem.vord_premie = txtAmount.Text
            frmKontant.KontantItem.kwit_boek = txtReceiptnr.Text
        End If

        If optCash.Checked Then
            frmKontant.KontantItem.kontant_tipe = "K"
        ElseIf optCheque.Checked Then
            frmKontant.KontantItem.kontant_tipe = "T"
            frmKontant.KontantItem.tjekno_in = txtChequenr.Text
            frmKontant.KontantItem.TJEKDATUM = dtpChequeDate.Value
            frmKontant.KontantItem.TJEKBESONDERHEDE = txtChequeInfo.Text

        ElseIf optElectronic.Checked Then
            frmKontant.KontantItem.kontant_tipe = "E"
        End If
        If Not optCheque.Checked Then
            frmKontant.KontantItem.tjekno_in = ""
            frmKontant.KontantItem.TJEKDATUM = "1900/01/01"
            frmKontant.KontantItem.TJEKBESONDERHEDE = ""
        End If

    End Sub
End Class