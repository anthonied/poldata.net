Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports DAL

Public Class frmKontantBackup
    Dim kontant_tipe As String
    Dim tipe_ontv As String
    Dim blnPaymentValidation As Boolean
    Dim intRow As Integer
    Dim strTakafkorting As String
    Dim strTaknaam As String
    Dim intVT As Integer
    Dim intKwit_nr As Integer
    Dim dteAfsluitdat As Date
    Dim EersteKeerIn As Boolean = True
    Dim EntKontant As New KontantEntity
    Dim loading As Boolean = True

    Private Sub optCheque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCheque.CheckedChanged
        If Not loading Then
            If optCheque.Checked Then

                Me.Label7.Visible = True
                Me.Label8.Visible = True
                Me.Label9.Visible = True
                Me.dtpChequeDate.Visible = True
                Me.txtChequeInfo.Visible = True
                Me.txtChequenr.Visible = True

                kontant_tipe = "T"
                ClearTextboxes()

                optAllTransactions.Checked = False
                optOutstandingTransactions.Checked = False

                optMonthlyCash.Checked = False
                optMonthlyDebit.Checked = False
                optMonthlySalary.Checked = False
                optMonthlyElectronic.Checked = False

                optVT.Checked = False

                optFirstPayment.Checked = False
                optPrepaidPayment.Checked = False
                optPaybackPayment.Checked = False

                optTermPolicy.Checked = False
                optNewTermPolicy.Checked = False
                optTermAlteration.Checked = False

                'optCheque.Checked = False
                'optCash.Checked = False
                'optElectronic.Checked = False
            End If
        End If
    End Sub

    Private Sub optCash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCash.CheckedChanged
        If Not loading Then
            If optCash.Checked Then
                Me.Label7.Visible = False
                Me.Label8.Visible = False
                Me.Label9.Visible = False
                Me.dtpChequeDate.Visible = False
                Me.txtChequeInfo.Visible = False
                Me.txtChequenr.Visible = False

                kontant_tipe = "K"
                ClearTextboxes()
                optAllTransactions.Checked = False
                optOutstandingTransactions.Checked = False

                optMonthlyCash.Checked = False
                optMonthlyDebit.Checked = False
                optMonthlySalary.Checked = False
                optMonthlyElectronic.Checked = False

                optVT.Checked = False

                optFirstPayment.Checked = False
                optPrepaidPayment.Checked = False
                optPaybackPayment.Checked = False

                optTermPolicy.Checked = False
                optNewTermPolicy.Checked = False
                optTermAlteration.Checked = False

                'optCheque.Checked = False
                'optCash.Checked = False
                'optElectronic.Checked = False
            End If

        End If
    End Sub

    Private Sub optElectronic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optElectronic.CheckedChanged
        If Not loading Then
            If optElectronic.Checked Then
                Me.Label7.Visible = False
                Me.Label8.Visible = False
                Me.Label9.Visible = False
                Me.dtpChequeDate.Visible = False
                Me.txtChequeInfo.Visible = False
                Me.txtChequenr.Visible = False

                kontant_tipe = "E"
                ClearTextboxes()
                optAllTransactions.Checked = False
                optOutstandingTransactions.Checked = False

                optMonthlyCash.Checked = False
                optMonthlyDebit.Checked = False
                optMonthlySalary.Checked = False
                optMonthlyElectronic.Checked = False

                optVT.Checked = False

                optFirstPayment.Checked = False
                optPrepaidPayment.Checked = False
                optPaybackPayment.Checked = False

                optTermPolicy.Checked = False
                optNewTermPolicy.Checked = False
                optTermAlteration.Checked = False

                'optCheque.Checked = False
                'optCash.Checked = False
                'optElectronic.Checked = False
            End If
        End If

    End Sub

    Private Sub frmKontant_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Kry tak
        getBranch()
        Me.Text = Me.Text & " Policy Number: " & glbPolicyNumber & "     Insured: " & Form1.txtForm1Voorl.Text & " " & Form1.txtForm1Versekerde.Text & "     Branch: " & strTaknaam
        intVT = 0
        loading = True
        Me.Label7.Visible = False
        Me.Label8.Visible = False
        Me.Label9.Visible = False
        Me.dtpChequeDate.Visible = False
        Me.txtChequeInfo.Visible = False
        Me.txtChequenr.Visible = False
        'Haal die veld uit en plaas in die opskrif vd vorm
        '   Me.txtPolicynumber.Text = Form1.form1Polisno.Text
        '    Me.txtClient.Text = Form1.form1Voorl.Text & " " & Form1.form1Versekerde.Text

        Me.cmdPrintReceipt.Visible = False
        Me.cmdCancelPayment.Visible = False
        Me.cmdRegisterPayment.Enabled = False

        '  Me.lblTimeframe.Text = Form1.form1tydperk.Text
        Me.lblStatus.Text = Form1.lblForm1status.Text
        '   Me.lblMonthsLeft.Text = Form1.form1Months.Text

        Me.dtpToDate.Text = DateSerial(Year(Now), Month(Now), 1)
        Me.dtpFrom.Text = DateSerial(Year(Now) - 2, Month(Now) + 1, 1)
        Me.dtpChequeDate.Text = Now
        Me.dtpFrom.Enabled = True
        Me.dtpToDate.Enabled = True
        If Gebruiker.titel = "Besigtig" Then
            Me.cmdRegisterPayment.Enabled = False
            Me.cmdCancelPayment.Enabled = False
        End If

        SetupGrid()

        Me.GrpBxTerm.Enabled = False

        'select type of payment
        Select Case Persoonl.BET_WYSE
            Case 1
                Me.optMonthlyCash.Checked = True
                tipe_ontv = "MK"
            Case 3
                Me.optMonthlySalary.Checked = True
                tipe_ontv = "MS"
            Case 4
                Me.optMonthlyDebit.Checked = True
                tipe_ontv = "MD"
            Case 5
                Me.optMonthlyElectronic.Checked = True
                tipe_ontv = "ME"
            Case 6
                Me.optTermPolicy.Checked = True
                tipe_ontv = "LT"
                Me.GrpBxTerm.Enabled = True
        End Select


        'Andriette 10/10/2013 die tak naam vir Potch is nou Flagship
        '  If strTaknaam = "MM Potchefstroom" Or strTaknaam = "MM Bloemfontein" Then
        If strTaknaam = "Flagship" Or strTaknaam = "MM Bloemfontein" Then
            Me.optMonthlySalary.Enabled = True
        End If

        GetAllTransactions("AA")

        If intVT > 0 Then
            MsgBox("This person has VT'd " & intVT & " times.")
        End If
        EersteKeerIn = False
        Me.Cursor = System.Windows.Forms.Cursors.Default
        loading = False
    End Sub

    Private Sub SetupGrid()
        'DataGridView1.ColumnCount = 8
        'Dim columnHeaderStyle As New DataGridViewCellStyle()
        'Me.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        'columnHeaderStyle.Font = New Font("Arial", 8, FontStyle.Bold)

        'DataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle
        'DataGridView1.Columns(0).Width = 45
        'DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '' DataGridView1.Columns().
        'DataGridView1.Columns(1).Width = 90
        'DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DataGridView1.Columns(2).Width = 90
        'DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DataGridView1.Columns(3).Width = 90
        'DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DataGridView1.Columns(4).Width = 110
        'DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DataGridView1.Columns(5).Width = 100
        'DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DataGridView1.Columns(6).Width = 100
        'DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DataGridView1.Columns(7).Width = 45
        'DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DataGridView1.Columns(0).Selected = False
        ''First column background
        'DataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.ReadOnly = True

        'introw = 0
        'DataGridView1.AutoGenerateColumns = False
        'DataGridView1.Refresh()
        'DataGridView1.Rows.Clear()
        'DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DataGridView1.Columns(0).Name = "Type"
        'DataGridView1.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        'DataGridView1.Columns(1).Name = "Date"
        'DataGridView1.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        'DataGridView1.Columns(2).Name = "Amount"
        'DataGridView1.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        'DataGridView1.Columns(3).Name = "Amount paid"
        'DataGridView1.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        'DataGridView1.Columns(4).Name = "Receipt/Cheque nr"
        'DataGridView1.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        'DataGridView1.Columns(5).Name = "Payment Date"
        'DataGridView1.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        'DataGridView1.Columns(6).Name = "Transaction Date"
        'DataGridView1.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
        'DataGridView1.Columns(7).Name = "Cheque/Cash/Electronic"
        'DataGridView1.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable

        DataGridView1.Enabled = True
    End Sub
    Private Sub PopulateGrid()
        Dim strTipe_ontv As String
        Dim iposisie As Integer = -1
        intRow = 0
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.Refresh()
        DataGridView1.DataSource = Nothing

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@tipe", SqlDbType.NVarChar)}
                param(0).Value = Persoonl.POLISNO
                Select Case tipe_ontv
                    Case "MD"
                        param(1).Value = "4"
                    Case "MK"
                        param(1).Value = "1"
                    Case "ME"
                        param(1).Value = "5"
                    Case "LT"
                        param(1).Value = "6"
                    Case "MS"
                        param(1).Value = "3"
                    Case Else
                        param(1).Value = "0"
                End Select


                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchTransaksiesPerPolisnoTipe]", param)
                Dim TransList As List(Of KontantEntity) = New List(Of KontantEntity)
                'While reader.Read()
                '    DataGridView1.Rows.Insert(intRow, reader("tipe"), reader("afsluit_dat"), reader("premie"), reader("vord_premie"), reader("kwitansie"), reader("vord_dat"), reader("trans_dat"), reader("kontant_tipe"), intRow)

                '    intRow = intRow + 1
                'End While
                While reader.Read()
                    Dim item As KontantEntity = New KontantEntity()
                    'Andriette 14/10/2013 stel die begin datum vir die datum control
                    If iposisie = -1 Then
                        dtpFrom.Value = reader("trans_dat")
                    End If
                    'select type of payment
                    If reader("betaalwyse") IsNot DBNull.Value Then
                        Select Case reader("betaalwyse")
                            Case "1"
                                'strTipe_ontv = "MK"
                                item.tipe = "MK"
                            Case "3"
                                ' strTipe_ontv = "MS"
                                item.tipe = "MS"
                            Case "4"
                                ' strTipe_ontv = "MD"
                                item.tipe = "MD"
                            Case "5"
                                'strTipe_ontv = "ME"
                                item.tipe = "ME"
                            Case "6"
                                ' strTipe_ontv = "LT"
                                item.tipe = "LT"
                            Case Else
                                ' strTipe_ontv = reader("tipe")
                                item.tipe = reader("betaalwyse")
                        End Select
                    Else
                        strTipe_ontv = "VT"
                        intVT = intVT + 1
                    End If
                    '   reader("WN_POLIS") IsNot DBNull.Value Then

                    If reader("afsluit_dat") IsNot DBNull.Value Then
                        item.afsluit_dat = reader("afsluit_dat")
                    Else
                        item.afsluit_dat = Nothing
                    End If
                    If reader("premie") IsNot DBNull.Value Then
                        item.premie = reader("premie")
                    Else
                        item.premie = 0
                    End If
                    If reader("vord_premie") IsNot DBNull.Value Then
                        item.vord_premie = reader("vord_premie")
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
                    Else
                        item.kontant_tipe = ""
                    End If

                    'Andriette 14/10/2013 sit oor op die kontant entity
                    '     DataGridView1.Rows.Insert(intRow, strTipe_ontv, reader("afsluit_dat"), reader("premie"), reader("vord_premie"), reader("kwitansie"), reader("vord_dat"), reader("trans_dat"), IIf(IsDBNull(reader("kontant_tipe")), "", reader("kontant_tipe")), intRow)

                    TransList.Add(item)
                    '  intRow = intRow + 1
                End While

                dtpToDate.Value = Today()
                DataGridView1.DataSource = TransList

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Private Sub GetAllTransactions(ByVal strCat As String)
        Dim strTipe_ontv As String
        Dim iposisie As Integer = -1
        Dim params() As SqlParameter
        Dim reader As SqlDataReader

        'Andriette 14/10/2013 verduideliking van die strCat kode
        'AA - Alle transaksies alle datums
        'AD - Alle transaksies met datum filter
        'UA - uitstaande transaksies alle datums
        'UD - uitstaande transaksies met datum filter

        intRow = 0
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.DataSource = Nothing
        DataGridView1.Refresh()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Andriette 11/10/213 skep 'n nuwe SP met nuwe parameters na DB veranderinge 
                Select Case strCat
                    Case "AA"
                        params = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                  New SqlParameter("@TransStatus", SqlDbType.NVarChar)}
                        params(0).Value = Persoonl.POLISNO
                        params(1).Value = "A"
                    Case "UA"
                        params = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                    New SqlParameter("@TransStatus", SqlDbType.NVarChar)}
                        params(0).Value = Persoonl.POLISNO
                        params(1).Value = "O"
                    Case "AD"
                        params = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                  New SqlParameter("@TransStatus", SqlDbType.NVarChar), _
                                  New SqlParameter("@Startdate", SqlDbType.DateTime), _
                                  New SqlParameter("@end_date", SqlDbType.DateTime)}
                        params(0).Value = Persoonl.POLISNO
                        params(1).Value = "A"
                        params(2).Value = dtpFrom.Value
                        params(3).Value = dtpToDate.Value
                        iposisie = 0
                    Case "UD"
                        params = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                  New SqlParameter("@TransStatus", SqlDbType.NVarChar), _
                                  New SqlParameter("@Startdate", SqlDbType.DateTime), _
                                  New SqlParameter("@end_date", SqlDbType.DateTime)}
                        params(0).Value = Persoonl.POLISNO
                        params(1).Value = "O"
                        params(2).Value = dtpFrom.Value
                        params(3).Value = dtpToDate.Value
                        iposisie = 0
                    Case Else
                        params = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                  New SqlParameter("@TransStatus", SqlDbType.NVarChar)}
                        params(0).Value = Persoonl.POLISNO
                        params(1).Value = "A"

                End Select

                reader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchAlleTipesTransaksiesByPolisnoStatus]", params)
                Dim TransList As List(Of KontantEntity) = New List(Of KontantEntity)

                While reader.Read()
                    Dim item As KontantEntity = New KontantEntity()
                    'Andriette 14/10/2013 stel die begin datum vir die datum control
                    If iposisie = -1 Then
                        dtpFrom.Value = reader("trans_dat")
                    End If
                    'select type of payment
                    If reader("tipe") IsNot DBNull.Value Then
                        Select Case reader("tipe")
                            Case "1"
                                'strTipe_ontv = "MK"
                                item.tipe = "MK"
                            Case "3"
                                ' strTipe_ontv = "MS"
                                item.tipe = "MS"
                            Case "4"
                                ' strTipe_ontv = "MD"
                                item.tipe = "MD"
                            Case "5"
                                'strTipe_ontv = "ME"
                                item.tipe = "ME"
                            Case "6"
                                ' strTipe_ontv = "LT"
                                item.tipe = "LT"
                            Case Else
                                ' strTipe_ontv = reader("tipe")
                                item.tipe = reader("tipe")
                        End Select
                    Else
                        strTipe_ontv = "VT"
                        intVT = intVT + 1
                    End If
                    '   reader("WN_POLIS") IsNot DBNull.Value Then

                    If reader("afsluit_dat") IsNot DBNull.Value Then
                        item.afsluit_dat = reader("afsluit_dat")
                    Else
                        item.afsluit_dat = Nothing
                    End If
                    If reader("premie") IsNot DBNull.Value Then
                        item.premie = reader("premie")
                    Else
                        item.premie = 0
                    End If
                    If reader("vord_premie") IsNot DBNull.Value Then
                        item.vord_premie = reader("vord_premie")
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
                    Else
                        item.kontant_tipe = ""
                    End If

                    'Andriette 14/10/2013 sit oor op die kontant entity
                    '     DataGridView1.Rows.Insert(intRow, strTipe_ontv, reader("afsluit_dat"), reader("premie"), reader("vord_premie"), reader("kwitansie"), reader("vord_dat"), reader("trans_dat"), IIf(IsDBNull(reader("kontant_tipe")), "", reader("kontant_tipe")), intRow)

                    TransList.Add(item)
                    '  intRow = intRow + 1
                End While

                dtpToDate.Value = Today()
                DataGridView1.DataSource = TransList
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Private Sub optFirstPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optFirstPayment.CheckedChanged
        If Not loading Then
            tipe_ontv = "EB"
            Me.GrpBxTerm.Enabled = False
            PopulateGrid()
            Me.cmdRegisterPayment.Enabled = True

            optAllTransactions.Checked = False
            optOutstandingTransactions.Checked = False

            optMonthlyCash.Checked = False
            optMonthlyDebit.Checked = False
            optMonthlySalary.Checked = False
            optMonthlyElectronic.Checked = False

            optVT.Checked = False

            '  optFirstPayment.Checked = False
            optPrepaidPayment.Checked = False
            optPaybackPayment.Checked = False

            optTermPolicy.Checked = False
            optNewTermPolicy.Checked = False
            optTermAlteration.Checked = False

            optCheque.Checked = False
            optCash.Checked = False
            optElectronic.Checked = False
        End If

    End Sub

    Private Sub optPrepaidPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPrepaidPayment.CheckedChanged
        If Not loading Then
            tipe_ontv = "VB"
            Me.GrpBxTerm.Enabled = False
            PopulateGrid()
            Me.cmdRegisterPayment.Enabled = True
            optAllTransactions.Checked = False
            optOutstandingTransactions.Checked = False

            optMonthlyCash.Checked = False
            optMonthlyDebit.Checked = False
            optMonthlySalary.Checked = False
            optMonthlyElectronic.Checked = False

            optVT.Checked = False

            '  optFirstPayment.Checked = False
            optPrepaidPayment.Checked = False
            optPaybackPayment.Checked = False

            optTermPolicy.Checked = False
            optNewTermPolicy.Checked = False
            optTermAlteration.Checked = False

            optCheque.Checked = False
            optCash.Checked = False
            optElectronic.Checked = False
        End If

    End Sub

    Private Sub optPaybackPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPaybackPayment.CheckedChanged
        If Not loading Then
            tipe_ontv = "TB"
            Me.GrpBxTerm.Enabled = False
            PopulateGrid()
            Me.cmdRegisterPayment.Enabled = True
            optAllTransactions.Checked = False
            optOutstandingTransactions.Checked = False

            optMonthlyCash.Checked = False
            optMonthlyDebit.Checked = False
            optMonthlySalary.Checked = False
            optMonthlyElectronic.Checked = False

            optVT.Checked = False

            '  optFirstPayment.Checked = False
            optPrepaidPayment.Checked = False
            optPaybackPayment.Checked = False

            optTermPolicy.Checked = False
            optNewTermPolicy.Checked = False
            optTermAlteration.Checked = False

            optCheque.Checked = False
            optCash.Checked = False
            optElectronic.Checked = False
        End If
    End Sub

    Private Sub cmdRegisterPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRegisterPayment.Click
        If Not loading Then
            PaymentValidation()

            If blnPaymentValidation = True Then
                SaveKontant()
            End If

            ClearTextboxes()

            PopulateGrid()
        End If
    End Sub
    Private Sub PaymentValidation()
        'tipe betaling moet gekies wees
        If Me.optFirstPayment.Checked = False And Me.optMonthlyCash.Checked = False And Me.optMonthlyDebit.Checked = False And Me.optMonthlySalary.Checked = False And Me.optTermPolicy.Checked = False And Me.optPaybackPayment.Checked = False And Me.optPrepaidPayment.Checked = False And Me.optVT.Checked = False And Me.optmonthlyElectronic.checked = False Then
            MsgBox("You have to pick a type of payment option")
            blnPaymentValidation = False
            Exit Sub
        End If
        'radio button moet gekies wees
        If Me.optCheque.Checked = False And Me.optCash.Checked = False And Me.optElectronic.Checked = False Then
            MsgBox("You have to pick a payment option")
            blnPaymentValidation = False
            Exit Sub
        End If

        'Bedrag moet in wees
        If Me.txtAmount.Text = "" Or IsDBNull(Me.txtAmount.Text) Then
            MsgBox("The Payment amount must be entered.")
            blnPaymentValidation = False
            Me.txtAmount.Focus()
            Exit Sub
        End If

        'kwitansie moet ingevul wees
        If Me.txtReceiptnr.Text = "" Or IsDBNull(Me.txtReceiptnr.Text) Then
            MsgBox("The Receipt book number must be entered.")
            blnPaymentValidation = False
            Me.txtReceiptnr.Focus()
            Exit Sub
        End If

        'memo moet ingevul wees
        If Me.txtCashMemo.Text = "" Or IsDBNull(Me.txtCashMemo.Text) Then
            MsgBox("The memo must be entered.")
            blnPaymentValidation = False
            Me.txtCashMemo.Focus()
            Exit Sub
        End If

        'as dit tjek is, moet die volgende ook ingevul wees
        If Me.optCheque.Checked Then
            'Tjek besonderhede in wees
            If Me.txtChequeInfo.Text = "" Or IsDBNull(Me.txtChequeInfo.Text) Then
                MsgBox("The cheque info must be entered.")
                blnPaymentValidation = False
                Me.txtChequeInfo.Focus()
                Exit Sub
            End If

            'tjek nr moet ingevul wees
            If Me.txtChequenr.Text = "" Or IsDBNull(Me.txtChequenr.Text) Then
                MsgBox("The cheque number must be entered.")
                blnPaymentValidation = False
                Me.txtChequenr.Focus()
                Exit Sub
            End If

            'datum moet ingevul wees
            If Me.dtpChequeDate.Text = "" Or IsDBNull(Me.dtpChequeDate.Text) Then
                MsgBox("The date must be entered.")
                blnPaymentValidation = False
                Me.dtpChequeDate.Focus()
                Exit Sub
            End If
        End If

        blnPaymentValidation = True

    End Sub
    Sub SaveKontant()

        Try
            If Me.optPaybackPayment.Checked Or Me.optPrepaidPayment.Checked Or Me.optFirstPayment.Checked Then
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
                    params(1).Value = dteAfsluitdat 'CDate(DataGridView1.SelectedRows(0).Cells(5).Value)
                    params(2).Value = Now
                    params(3).Value = Now
                    params(4).Value = Now
                    params(5).Value = Me.txtAmount.Text
                    params(6).Value = Me.txtAmount.Text
                    params(7).Value = Me.txtAmount.Text
                    params(8).Value = Year(Me.dtpChequeDate.Value)
                    params(9).Value = Month(Me.dtpChequeDate.Value)
                    If IsDBNull(Me.txtCashMemo.Text) Then
                        Me.txtCashMemo.Text = " "
                    End If

                    params(10).Value = Me.txtCashMemo.Text
                    params(11).Value = Me.txtCashMemo.Text
                    params(12).Value = Me.txtCashMemo.Text
                    params(13).Value = Me.txtCashMemo.Text
                    params(14).Value = Me.txtCashMemo.Text
                    params(15).Value = kontant_tipe
                    params(16).Value = Persoonl.BET_WYSE
                    params(17).Value = kontant_tipe
                    params(18).Value = tipe_ontv

                    If Me.optCheque.Checked <> 0 Then
                        If Me.optPaybackPayment.Checked Then
                            params(19).Value = txtChequenr.Text
                        Else
                            params(20).Value = txtChequenr.Text
                        End If
                    Else
                        params(19).Value = DBNull.Value
                        params(20).Value = DBNull.Value
                    End If

                    If Me.optCheque.Checked <> 0 Then
                        params(21).Value = CDate(dtpChequeDate.Text)
                        params(22).Value = txtChequeInfo.Text
                    Else
                        params(21).Value = DBNull.Value
                        params(22).Value = DBNull.Value
                    End If

                    GetKwitansieNr()
                    params(23).Value = Me.txtReceiptnr.Text
                    'Kwit_nr = strTakafkorting & "-" & tipe_ontv & "-" & intKwit_nr
                    params(24).Value = Persoonl.Area
                    params(25).Value = ""
                    params(26).Value = 0
                    params(27).Value = tipe_ontv

                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Stats5.InsertIntoKontantGegenereer", params)

                End Using
            Else
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
                    params(1).Value = dteAfsluitdat 'CStr(Format(Now, "dd/mm/yyyy")) 
                    params(2).Value = Me.txtAmount.Text

                    If IsDBNull(Me.txtCashMemo.Text) Then
                        Me.txtCashMemo.Text = " "
                    End If

                    params(3).Value = Me.txtCashMemo.Text
                    params(4).Value = Me.txtCashMemo.Text
                    params(5).Value = Me.txtCashMemo.Text
                    params(6).Value = Me.txtCashMemo.Text
                    params(7).Value = Me.txtCashMemo.Text
                    params(8).Value = kontant_tipe

                    If Me.optCheque.Checked <> 0 Then
                        If Me.optPaybackPayment.Checked Then
                            params(9).Value = Me.txtChequenr.Text
                            params(10).Value = DBNull.Value
                        Else
                            params(9).Value = DBNull.Value
                            params(10).Value = txtChequenr.Text
                        End If
                    Else
                        params(9).Value = DBNull.Value
                        params(10).Value = DBNull.Value
                    End If

                    If Me.optCheque.Checked Then
                        params(11).Value = Me.dtpChequeDate.Value
                        params(12).Value = Me.txtChequeInfo.Text
                    Else
                        params(11).Value = DBNull.Value
                        params(12).Value = DBNull.Value
                    End If

                    GetKwitansieNr()

                    params(13).Value = strTakafkorting & "-" & tipe_ontv & "-" & intKwit_nr
                    params(14).Value = Persoonl.Area
                    params(15).Value = Format(Now, "dd/MM/yyyy")
                    params(16).Value = tipe_ontv

                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Stats5.UpdateKontantAndMaandKontant", params)

                End Using

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub txtAmount_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.Leave
        Me.txtAmount.Text = Format(CDbl(Val(Me.txtAmount.Text)), "0.00")

    End Sub


    Private Sub optMonthlyDebit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMonthlyDebit.CheckedChanged
        If Not loading Then
            If optMonthlyDebit.Checked Then

                tipe_ontv = "MD"
                Me.GrpBxTerm.Enabled = False
                PopulateGrid()
                Me.cmdRegisterPayment.Enabled = False

                optAllTransactions.Checked = False
                optOutstandingTransactions.Checked = False

                'optMonthlyCash.Checked = False
                'optMonthlyDebit.Checked = False
                'optMonthlySalary.Checked = False
                'optMonthlyElectronic.Checked = False

                optVT.Checked = False

                optFirstPayment.Checked = False
                optPrepaidPayment.Checked = False
                optPaybackPayment.Checked = False

                optTermPolicy.Checked = False
                optNewTermPolicy.Checked = False
                optTermAlteration.Checked = False

                optCheque.Checked = False
                optCash.Checked = False
                optElectronic.Checked = False
            End If
        End If
    End Sub

    Private Sub optMonthlyCash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMonthlyCash.CheckedChanged
        If Not loading Then
            If optMonthlyCash.Checked Then

                tipe_ontv = "MK"
                Me.GrpBxTerm.Enabled = False
                PopulateGrid()
                Me.cmdRegisterPayment.Enabled = False

                optAllTransactions.Checked = False
                optOutstandingTransactions.Checked = False

                'optMonthlyCash.Checked = False
                'optMonthlyDebit.Checked = False
                'optMonthlySalary.Checked = False
                'optMonthlyElectronic.Checked = False

                optVT.Checked = False

                optFirstPayment.Checked = False
                optPrepaidPayment.Checked = False
                optPaybackPayment.Checked = False

                optTermPolicy.Checked = False
                optNewTermPolicy.Checked = False
                optTermAlteration.Checked = False

                optCheque.Checked = False
                optCash.Checked = False
                optElectronic.Checked = False
            End If
        End If
    End Sub

    Private Sub optMonthlySalary_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMonthlySalary.CheckedChanged
        If Not loading Then
            If optMonthlySalary.Checked Then

                tipe_ontv = "MS"
                Me.GrpBxTerm.Enabled = False
                PopulateGrid()
                Me.cmdRegisterPayment.Enabled = False

                optAllTransactions.Checked = False
                optOutstandingTransactions.Checked = False

                'optMonthlyCash.Checked = False
                'optMonthlyDebit.Checked = False
                'optMonthlySalary.Checked = False
                'optMonthlyElectronic.Checked = False

                optVT.Checked = False

                optFirstPayment.Checked = False
                optPrepaidPayment.Checked = False
                optPaybackPayment.Checked = False

                optTermPolicy.Checked = False
                optNewTermPolicy.Checked = False
                optTermAlteration.Checked = False

                optCheque.Checked = False
                optCash.Checked = False
                optElectronic.Checked = False
            End If
        End If
    End Sub

    Private Sub optMonthlyElectronic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMonthlyElectronic.CheckedChanged
        If Not loading Then
            If optMonthlyElectronic.Checked Then

                tipe_ontv = "ME"
                Me.GrpBxTerm.Enabled = False
                PopulateGrid()
                Me.cmdRegisterPayment.Enabled = False

                optAllTransactions.Checked = False
                optOutstandingTransactions.Checked = False

                'optMonthlyCash.Checked = False
                'optMonthlyDebit.Checked = False
                'optMonthlySalary.Checked = False
                'optMonthlyElectronic.Checked = False

                optVT.Checked = False

                optFirstPayment.Checked = False
                optPrepaidPayment.Checked = False
                optPaybackPayment.Checked = False

                optTermPolicy.Checked = False
                optNewTermPolicy.Checked = False
                optTermAlteration.Checked = False

                optCheque.Checked = False
                optCash.Checked = False
                optElectronic.Checked = False
            End If
        End If
    End Sub


    Private Sub optVT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optVT.CheckedChanged
        If Not loading Then
            If optVT.Checked Then
                tipe_ontv = "VT"
                Me.GrpBxTerm.Enabled = False
                PopulateGrid()
                Me.cmdRegisterPayment.Enabled = False
                optAllTransactions.Checked = False
                optOutstandingTransactions.Checked = False

                optMonthlyCash.Checked = False
                optMonthlyDebit.Checked = False
                optMonthlySalary.Checked = False
                optMonthlyElectronic.Checked = False

                ' optVT.Checked = False

                optFirstPayment.Checked = False
                optPrepaidPayment.Checked = False
                optPaybackPayment.Checked = False

                optTermPolicy.Checked = False
                optNewTermPolicy.Checked = False
                optTermAlteration.Checked = False

                optCheque.Checked = False
                optCash.Checked = False
                optElectronic.Checked = False

            End If
        End If
    End Sub

    Private Sub optTermPolicy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTermPolicy.CheckedChanged
        If Not loading Then
            If optTermPolicy.Checked Then

                tipe_ontv = "LT"
                Me.GrpBxTerm.Enabled = True
                PopulateGrid()
                Me.cmdRegisterPayment.Enabled = False
                optAllTransactions.Checked = False
                optOutstandingTransactions.Checked = False

                optMonthlyCash.Checked = False
                optMonthlyDebit.Checked = False
                optMonthlySalary.Checked = False
                optMonthlyElectronic.Checked = False

                optVT.Checked = False

                optFirstPayment.Checked = False
                optPrepaidPayment.Checked = False
                optPaybackPayment.Checked = False

                '  optTermPolicy.Checked = False
                optNewTermPolicy.Checked = False
                optTermAlteration.Checked = False

                optCheque.Checked = False
                optCash.Checked = False
                optElectronic.Checked = False
            Else
                Me.GrpBxTerm.Enabled = False
            End If

        End If
    End Sub

    Private Sub cmdGetTransactions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetTransactions.Click
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Refresh()
        intRow = 0
        optTermPolicy.Checked = False
        Me.optPaybackPayment.Checked = False
        Me.optPrepaidPayment.Checked = False
        Me.optVT.Checked = False
        Me.optFirstPayment.Checked = False
        Me.optTermPolicy.Checked = False
        Me.optMonthlySalary.Checked = False
        Me.optMonthlyElectronic.Checked = False
        Me.optMonthlyDebit.Checked = False
        Me.optMonthlyCash.Checked = False
        If Me.optAllTransactions.Checked Then
            GetAllTransactions("AD")
        Else
            ' PopulateGrid()
            GetAllTransactions("UD")
        End If

    End Sub

    Private Sub txtReceiptnr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReceiptnr.Leave
        'kyk of kwitansienr uniek is
        Dim param() As SqlParameter = {New SqlParameter("@Kwitansie", SqlDbType.NVarChar)}
        param(0).Value = Me.txtReceiptnr.Text

        Dim readers As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.checkduplicateKwitansie", param)

        While readers.Read
            MsgBox("A receipt book nr with this number already exists.")
            Me.txtReceiptnr.Focus()
            Exit Sub
        End While

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

    Private Sub txtChequenr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChequenr.Leave
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
    Private Sub getBranch()

        Dim readers As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchTak]")

        While readers.Read

            strTaknaam = readers("tak_naam")
            strTakafkorting = readers("tak_afkorting")

            Exit Sub
        End While
    End Sub
    Private Sub ClearTextboxes()

        Me.txtReceiptnr.Clear()
        Me.txtChequenr.Clear()
        Me.txtChequeInfo.Clear()
        Me.txtCashMemo.Clear()
        Me.txtAmount.Clear()
        Me.dtpChequeDate.Value = Now
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        dteAfsluitdat = DataGridView1.Item(1, e.RowIndex).Value
    End Sub
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Me.cmdRegisterPayment.Enabled = True
        If Form1.txtForm1Gekans.Text = "NEE" Then
            Me.optPaybackPayment.Checked = True
            Me.optMonthlySalary.Enabled = False
            Me.optMonthlyCash.Enabled = False
            Me.optMonthlyDebit.Enabled = False
            Me.optMonthlyElectronic.Enabled = False
            Me.optVT.Enabled = False
            Me.optTermPolicy.Enabled = False
            Me.optFirstPayment.Enabled = False
            Me.optPrepaidPayment.Enabled = False
        End If
        ClearTextboxes()
    End Sub
    ' Andriette 23/05/2013 skep die kode vir die vertoon van uitstaande transaksies
    Private Sub optOutstandingTransactions_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optOutstandingTransactions.CheckedChanged
        ' 
        '   Dim strTipe_ontv As String
        If Not loading Then
            If optOutstandingTransactions.Checked Then
                optTermPolicy.Checked = False
                GetAllTransactions("UD")
            Else
                'optAllTransactions.Checked = False
                'optOutstandingTransactions.Checked = false

                optMonthlyCash.Checked = False
                optMonthlyDebit.Checked = False
                optMonthlySalary.Checked = False
                optMonthlyElectronic.Checked = False

                optVT.Checked = False

                optFirstPayment.Checked = False
                optPrepaidPayment.Checked = False
                optPaybackPayment.Checked = False

                optTermPolicy.Checked = False
                optNewTermPolicy.Checked = False
                optTermAlteration.Checked = False

                optCheque.Checked = False
                optCash.Checked = False
                optElectronic.Checked = False
            End If
        End If
        'intRow = 0
        'DataGridView1.AutoGenerateColumns = False
        'DataGridView1.DataSource = Nothing
        'DataGridView1.Refresh()
        'Try
        '    Using conn As SqlConnection = SqlHelper.GetConnection
        '        Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
        '                                        New SqlParameter("@TransStatus", SqlDbType.NVarChar)}


        '        params(0).Value = Persoonl.POLISNO
        '        params(1).Value = "O"
        '        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchAlletipesTransaksiesByPolisnoStatus ]", params)

        '        While reader.Read()
        '            'select type of payment
        '            If IsDBNull(reader("tipe")) Then
        '                strTipe_ontv = "VT"
        '                intVT = intVT + 1
        '            Else
        '                Select Case reader("tipe")
        '                    Case "1"
        '                        strTipe_ontv = "MK"
        '                    Case "3"
        '                        strTipe_ontv = "MS"
        '                    Case "4"
        '                        strTipe_ontv = "MD"
        '                    Case "5"
        '                        strTipe_ontv = "ME"
        '                    Case "6"
        '                        strTipe_ontv = "LT"
        '                    Case Else
        '                        strTipe_ontv = reader("tipe")
        '                End Select
        '            End If
        '            DataGridView1.Rows.Insert(intRow, strTipe_ontv, reader("afsluit_dat"), reader("premie"), reader("vord_premie"), reader("kwitansie"), reader("vord_dat"), reader("trans_dat"), IIf(IsDBNull(reader("kontant_tipe")), "", reader("kontant_tipe")), intRow)

        '            intRow = intRow + 1
        '        End While
        '    End Using
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical)
        'End Try
    End Sub

    Private Sub optAllTransactions_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optAllTransactions.CheckedChanged
        'If Not EersteKeerIn Then
        '    GetAllTransactions("A")
        'End If
        'Andriette 14/102013 verander 
        If Not loading Then
            If optAllTransactions.Checked Then
                GetAllTransactions("AD")
                optTermPolicy.Checked = False
                '   Else
                ' GetAllTransactions("UD")
            Else
                'optAllTransactions.Checked = False
                'optOutstandingTransactions.Checked = false

                optMonthlyCash.Checked = False
                optMonthlyDebit.Checked = False
                optMonthlySalary.Checked = False
                optMonthlyElectronic.Checked = False

                optVT.Checked = False

                optFirstPayment.Checked = False
                optPrepaidPayment.Checked = False
                optPaybackPayment.Checked = False

                optTermPolicy.Checked = False
                optNewTermPolicy.Checked = False
                optTermAlteration.Checked = False

                optCheque.Checked = False
                optCash.Checked = False
                optElectronic.Checked = False

            End If
        End If

    End Sub



End Class