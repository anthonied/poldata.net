Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Data.SqlClient
Imports DAL
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Public Class frmClaimsElectronicPayments
    Dim blnInfoChanges As Boolean = False
    Dim intRow As Integer = 0
    Dim strNedbankLeerafk As String = ""
    Dim blnUnique As Boolean = False
    Dim blnVerified As Boolean = False
    Dim strBrokers As String = ""
    Dim strMMBankrekno As String = ""
    Dim intfkMakelaar As Integer = 0
    Dim strVersekerde As String = ""
    Dim strVoorl As String
    Dim item As ClaimsPaymentEntity = New ClaimsPaymentEntity()
    Dim strBatchTyd As String = ""
    Dim strEisKlas As String = ""
    Dim strCredAcc As String = ""
    Dim strCredBnkSrt As String = ""
    Dim strCredName As String = ""
    Dim strDebAcc As String = ""
    Dim strDesc As String = ""
    Dim strOrder As String = ""
    Dim strInv As String = ""
    Dim dblAmount As Decimal = 0
    Dim strTjekbesonderhede As String = ""
    Dim strTjeknouit As String = ""
    Dim strEisno As String = ""
    Dim strBTWJN As String = ""
    Dim strFaktuurnr As String = ""
    Dim dblVordPremie As Decimal
    Dim strPolisno As String = ""
    Dim strTakkode As String = ""
    Dim strBankrekno As String = ""
    Dim strCLRSPath As String = ""
    Dim serverPath As String = ""
    Private Sub frmClaimsElectronicPayments_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        cmbInsurer.DataSource = BaseForm.FillCombo("poldata5.FetchVersekeraar", "pkVersekeraar", "Naam", "", "", "", "")
        cmbInsurer.DisplayMember = "ComboBoxName"
        cmbInsurer.ValueMember = "ComboBoxID"

        cmbInsurer.Text = ""

        Me.dtpPaymentDate.Value = Today
        Me.dtpPaymentDate.Enabled = False
        Me.lblPassword.Enabled = False
        Me.txtPassword.Enabled = False
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        If blnInfoChanges = True Then
            If MsgBox("Are you sure you want to cancel and loose all your changes?", vbYesNo) = MsgBoxResult.Yes Then
                frmClaimsList.Show()
                Me.Close()
            Else
                Exit Sub
            End If
        Else
            frmClaimsList.Show()
            Me.Close()
        End If
    End Sub

    Private Sub cmbInsurer_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles cmbInsurer.SelectionChangeCommitted
        Dim strMakelaar As String = ""
        Dim BrokerBindingSource As BindingSource

        dgvBrokersExisting.AutoGenerateColumns = False
        dgvBrokersExisting.DataSource = Nothing
        dgvBrokersExisting.Refresh()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim paramsClaims() As SqlParameter = {New SqlParameter("@fkVersekeraar", SqlDbType.Int)}
                paramsClaims(0).Value = Me.cmbInsurer.SelectedValue

                Dim readerClaims As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchMakelaarfkVersekeraar", paramsClaims)

                Dim BrokerList As List(Of EntityMakeLaar) = New List(Of EntityMakeLaar)

                Do While readerClaims.Read
                    Dim item As EntityMakeLaar = New EntityMakeLaar()

                    If readerClaims("pkMakelaar") IsNot DBNull.Value Then
                        item.pkMakelaar = readerClaims("pkMakelaar")
                    Else
                        item.pkMakelaar = 0
                    End If
                    If readerClaims("Beskrywingafr") IsNot DBNull.Value Then
                        item.BeskrywingAfr = readerClaims("Beskrywingafr")
                    Else
                        item.BeskrywingAfr = ""
                    End If
                    If readerClaims("NedbankleerAfkorting") IsNot DBNull.Value Then
                        item.NedbankleerAfkorting = readerClaims("NedbankleerAfkorting")
                    Else
                        item.NedbankleerAfkorting = ""
                    End If

                    If strMakelaar <> item.BeskrywingAfr Then
                        BrokerList.Add(item)
                    End If

                    strMakelaar = item.BeskrywingAfr
                Loop

                BrokerBindingSource = New BindingSource
                BrokerBindingSource.DataSource = BrokerList
                Me.dgvBrokersExisting.DataSource = BrokerBindingSource

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    readerClaims.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmdOneOver_Click(sender As System.Object, e As System.EventArgs) Handles cmdOneOver.Click
        OneOver()
    End Sub

    Private Sub dgvBrokersExisting_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBrokersExisting.CellClick
        intRow = e.RowIndex
    End Sub

    Private Sub dgvBrokersExisting_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBrokersExisting.CellDoubleClick
        intRow = e.RowIndex
        OneOver()

    End Sub

    Private Sub dgvBrokersPay_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBrokersPay.CellClick
        intRow = e.RowIndex
    End Sub

    Private Sub OneOver()

        Me.dgvBrokersPay.Rows.Add(Me.dgvBrokersExisting.Rows(intRow).Cells("pkMakelaar").Value, Me.dgvBrokersExisting.Rows(intRow).Cells("Beskrywingafr").Value, Me.dgvBrokersExisting.Rows(intRow).Cells("nedbankleerafkorting").Value)

        Me.txtFilename.Text = Me.cmbInsurer.SelectedValue & Me.dgvBrokersExisting.Rows(intRow).Cells("nedbankleerafkorting").Value & Format(Now, "ddMMyy") & ".csv"
        Me.dgvBrokersExisting.Rows.Remove(Me.dgvBrokersExisting.Rows(intRow))

        If Me.optTestRun.Checked = True Then
            Me.txtBacthID.Text = "T" & Format(Now, "ddMMyy")
        Else
            Me.txtBacthID.Text = "F" & Format(Now, "ddMMyy")
        End If
    End Sub

    Private Sub optTestRun_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optTestRun.CheckedChanged
        Me.txtBacthID.Text = ""
        Me.txtFilename.Text = ""
        Me.txtPassword.Text = ""
        Me.cmbInsurer.Text = ""
        Me.dtpPaymentDate.Value = Today
        Me.dtpPaymentDate.Enabled = False
        Me.lblPassword.Enabled = False
        Me.txtPassword.Enabled = False
        dgvBrokersExisting.AutoGenerateColumns = False
        dgvBrokersExisting.DataSource = Nothing
        dgvBrokersExisting.Refresh()
        dgvBrokersPay.AutoGenerateColumns = False
        dgvBrokersPay.Rows.Clear()
        dgvBrokersPay.Refresh()
        Me.btnOK.Enabled = True
        Me.lblVerified.Text = ""
    End Sub

    Private Sub optFinalRun_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optFinalRun.CheckedChanged
        Me.txtBacthID.Text = ""
        Me.txtFilename.Text = ""
        Me.txtPassword.Text = ""
        Me.cmbInsurer.Text = ""
        Me.dtpPaymentDate.Enabled = True
        Me.dtpPaymentDate.Value = Today
        Me.lblPassword.Enabled = True
        Me.txtPassword.Enabled = True
        dgvBrokersExisting.AutoGenerateColumns = False
        dgvBrokersExisting.DataSource = Nothing
        dgvBrokersExisting.Refresh()
        dgvBrokersPay.AutoGenerateColumns = False
        dgvBrokersPay.Rows.Clear()
        dgvBrokersPay.Refresh()
        Me.btnOK.Enabled = True
        Me.lblVerified.Text = ""
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        Cursor.Current = Cursors.WaitCursor
        'Check vir magtiging 
        If blnVerified = False And Me.optFinalRun.Checked = True Then
            MsgBox("Please verify before your do this this run.", vbInformation)
            Exit Sub
        End If

        'kyk vir unieke batchid
        BatchIDUnique()

        If blnUnique = False Then
            MsgBox("Please enter a unique batch ID no.", vbInformation)
            Exit Sub
        End If

        'get brokers
        GetBrokers()

        strBatchTyd = CStr(Format(Now, "hh:mm:ss"))

        'GetAllPayments
        GetAllELPayments()

        'is dit nodig?
        'DeleteNedHeaderDetailTrailer()

        UpdateGroup()

        If Me.optFinalRun.Checked = True Then
            SkryfLeer()
            'Email leer

        End If

        Cursor.Current = Cursors.Arrow
        MsgBox("Run completed.", vbInformation)
        Me.btnOK.Enabled = False
    End Sub

    Private Sub UpdateGroup()
        Dim dblAmount As Decimal = 0
        Dim strOrder As String = ""

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params() As SqlParameter = {New SqlParameter("@BatchID", SqlDbType.NVarChar)}
                params(0).Value = Me.txtBacthID.Text

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "ned.FetchBegunstigdeDetailsBatchID", params)

                Do While reader.Read
                    'skryf neddetail
                    Try
                        Using conn1 As SqlConnection = SqlHelper.GetConnection
                            Dim params1() As SqlParameter = {New SqlParameter("@rekordtipe", SqlDbType.NVarChar), _
                                                            New SqlParameter("@debline", SqlDbType.NVarChar), _
                                                            New SqlParameter("@debacc", SqlDbType.NVarChar), _
                                                            New SqlParameter("@debbnksrt", SqlDbType.NVarChar), _
                                                            New SqlParameter("@debacctyp", SqlDbType.NVarChar), _
                                                            New SqlParameter("@credline", SqlDbType.NVarChar), _
                                                            New SqlParameter("@credacc", SqlDbType.NVarChar), _
                                                            New SqlParameter("@credbnksrt", SqlDbType.NVarChar), _
                                                            New SqlParameter("@credacctyp", SqlDbType.NVarChar), _
                                                            New SqlParameter("@amount", SqlDbType.NVarChar), _
                                                            New SqlParameter("@Desc", SqlDbType.NVarChar), _
                                                            New SqlParameter("@remflag", SqlDbType.NVarChar), _
                                                            New SqlParameter("@credname", SqlDbType.NVarChar), _
                                                            New SqlParameter("@credaddress", SqlDbType.NVarChar), _
                                                            New SqlParameter("@credpostal", SqlDbType.NVarChar), _
                                                            New SqlParameter("@contact", SqlDbType.NVarChar), _
                                                            New SqlParameter("@Order", SqlDbType.NVarChar), _
                                                            New SqlParameter("@supplier", SqlDbType.NVarChar), _
                                                            New SqlParameter("@genledger", SqlDbType.NVarChar), _
                                                            New SqlParameter("@link", SqlDbType.NVarChar), _
                                                            New SqlParameter("@rekordnommer", SqlDbType.Int), _
                                                            New SqlParameter("@credacc2", SqlDbType.NVarChar), _
                                                            New SqlParameter("@debname", SqlDbType.NVarChar), _
                                                            New SqlParameter("@inv", SqlDbType.NVarChar)}

                            params1(0).Value = "D"
                            params1(1).Value = ""   'debline
                            params1(2).Value = strMMBankrekno   'debacc
                            params1(3).Value = "000000" 'debbnksrt
                            params1(4).Value = "0"  'debacctyp
                            params1(5).Value = "0000000000"   'credline
                            params1(6).Value = IIf(reader("nedbankrek") Is DBNull.Value, "", reader("nedbankrek"))  'credacc
                            params1(7).Value = IIf(reader("nedbankkode") Is DBNull.Value, "", reader("nedbankkode"))   'takkode - fkbankcodes
                            params1(8).Value = CStr(item.NedrekTipe + 1)      'credacctype
                            params1(9).Value = reader("BEDRAG")       'amount
                            params1(10).Value = reader("begunstigde")      'description
                            params1(11).Value = "N"                 'remflag
                            params1(12).Value = reader("begunstigde")       'credname
                            params1(13).Value = ""                  'credaddress
                            params1(14).Value = "0000"              'credpostal
                            params1(15).Value = reader("voorl") & " " & reader("versekerde")       'contact
                            params1(16).Value = reader("polisnommer")            'order
                            params1(17).Value = ""                  'supplier
                            params1(18).Value = ""                  'Genledger
                            params1(19).Value = "1"                  'link
                            params1(20).Value = 0                  'rekordnommer
                            params1(21).Value = ""                  'credacc2
                            params1(22).Value = reader("faktuurnommer")     'debname
                            params1(23).Value = reader("faktuurnommer")      'inv

                            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "ned.UpdateNeddetail", params1)
                            If conn1.State = ConnectionState.Open Then
                                conn1.Close()
                            End If
                        End Using
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                        Exit Sub
                    End Try

                    Try
                        Using conn2 As SqlConnection = SqlHelper.GetConnection
                            Dim params2() As SqlParameter = {New SqlParameter("@Begunstigde", SqlDbType.NVarChar), _
                                                            New SqlParameter("@aksiedatum", SqlDbType.NVarChar), _
                                                            New SqlParameter("@bedrag", SqlDbType.Money), _
                                                            New SqlParameter("@Toetslopie", SqlDbType.NVarChar), _
                                                            New SqlParameter("@BatchID", SqlDbType.NVarChar), _
                                                            New SqlParameter("@aksiedatum2", SqlDbType.Date), _
                                                            New SqlParameter("@Polisno", SqlDbType.NVarChar)}

                            params2(0).Value = reader("begunstigde")
                            params2(1).Value = CStr(Format(Today, "dd/MM/yyyy"))
                            params2(2).Value = reader("BEDRAG")
                            If Me.optFinalRun.Checked = True Then
                                params2(3).Value = "Nee"
                            Else
                                params2(3).Value = "Ja"
                            End If
                            params2(4).Value = Me.txtBacthID.Text
                            params2(5).Value = Today
                            params2(6).Value = reader("polisnommer")

                            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Ned.UpdateBegunstigdeHeader", params2)

                            If conn2.State = ConnectionState.Open Then
                                conn2.Close()
                            End If
                        End Using
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                        Exit Sub
                    End Try
                Loop

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    reader.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Private Sub PaymentUpdate()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Nedlopie", SqlDbType.Bit), _
                                                New SqlParameter("@Batchid", SqlDbType.NVarChar), _
                                                New SqlParameter("@BatchTyd", SqlDbType.NVarChar), _
                                                New SqlParameter("@pkPayments", SqlDbType.Int)}

                If Me.optFinalRun.Checked = True Then
                    params(0).Value = True
                Else
                    params(0).Value = False
                End If
                params(1).Value = Me.txtBacthID.Text
                params(2).Value = strBatchTyd
                params(3).Value = intpkPayments

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "eisdat.UpdatePaymentsNedLopie", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Private Sub GetElectronicBank()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@reknaam", SqlDbType.NVarChar), _
                                                New SqlParameter("@fkVersekeraar", SqlDbType.Int)}

                params(0).Value = ""
                For i = 0 To dgvBrokersPay.RowCount - 1
                    If intfkMakelaar = dgvBrokersPay.Rows(i).Cells("pkMakelaar2").Value Then
                        params(0).Value = dgvBrokersPay.Rows(i).Cells("beskrywingafr2").Value
                        Exit For
                    End If
                Next
                params(1).Value = Me.cmbInsurer.SelectedValue

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchElektroniesBank", params)

                If reader.Read Then
                    If reader("takgebruik") = "Ja" Then
                        strMMBankrekno = reader("reknr")
                    End If
                End If

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    reader.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub GetAllELPayments()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@nedlopie", SqlDbType.Bit), _
                                                New SqlParameter("@Tipe", SqlDbType.NVarChar), _
                                                New SqlParameter("@fkVersekeraar", SqlDbType.Int), _
                                                New SqlParameter("@fkmakelaar", SqlDbType.NVarChar)}

                params(0).Value = False
                params(1).Value = "EL"
                params(2).Value = Me.cmbInsurer.SelectedValue
                params(3).Value = strBrokers

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchPaymentsNedlopie", params)

                Do While reader.Read
                    Dim item As ClaimsPaymentEntity = New ClaimsPaymentEntity()

                    If reader("pkPayments") IsNot DBNull.Value Then
                        item.pkPayments = reader("pkPayments")
                    Else
                        item.pkPayments = 0
                    End If
                    If reader("Tjekbesonderhede") IsNot DBNull.Value Then
                        item.Tjekbesonderhede = reader("Tjekbesonderhede")
                    Else
                        item.Tjekbesonderhede = ""
                    End If
                    If reader("Tjekno_uit") IsNot DBNull.Value Then
                        item.Tjekno_uit = reader("Tjekno_uit")
                    Else
                        item.Tjekno_uit = ""
                    End If
                    If reader("Faktuurnr") IsNot DBNull.Value Then
                        item.Faktuurnr = reader("Faktuurnr")
                    Else
                        item.Faktuurnr = ""
                    End If
                    If reader("Vord_premie") IsNot DBNull.Value Then
                        item.Vord_premie = reader("Vord_premie")
                    Else
                        item.Vord_premie = 0
                    End If
                    If reader("polisno") IsNot DBNull.Value Then
                        item.polisno = reader("polisno")
                    Else
                        item.polisno = ""
                    End If
                    If reader("eisno") IsNot DBNull.Value Then
                        item.eisno = reader("eisno")
                    Else
                        item.eisno = ""
                    End If
                    If reader("Btwjn") IsNot DBNull.Value Then
                        item.Btwjn = reader("Btwjn")
                    Else
                        item.Btwjn = ""
                    End If

                    strVersekerde = reader("versekerde")
                    strVoorl = reader("voorl")
                    strEisKlas = reader("beskrywing")
                    intpkPayments = reader("pkpayments")
                    intfkMakelaar = reader("fkmakelaar")
                    strTjekbesonderhede = item.Tjekbesonderhede
                    strTjeknouit = item.Tjekno_uit
                    dblVordPremie = item.Vord_premie
                    strEisno = item.eisno
                    strBTWJN = item.Btwjn
                    strFaktuurnr = item.Faktuurnr
                    strPolisno = item.polisno
                    strBankrekno = IIf(reader("nedbankrek") Is DBNull.Value, "", reader("nedbankrek"))
                    'Get the bank details using fk
                    strTakkode = IIf(reader("nedbankkode") Is DBNull.Value, "", reader("nedbankkode"))
                    intpkBegunstigde = IIf(reader("fkbegunstigde") Is DBNull.Value, 0, reader("fkbegunstigde"))
                    intpkPayments = item.pkPayments

                    'payment update
                    PaymentUpdate()

                    GetElectronicBank()

                    'delete alle rekords in begunstigdedetails as die finale lopie geloop word
                    If Me.optFinalRun.Checked = True Then
                        BegunstigdeHeaderDelete()
                        BegunstigdeDetailsDelete()
                    End If

                    NedDetailsDelete()

                    'skryf begunstigdedetails indien dit finale lopie is
                    BegunstigdeDetailsUpdate()
                Loop

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    reader.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub SkryfLeer()
        Dim strFile As String = ""
        Dim strFilePath As String
        Dim strOutput As String = ""
        Dim clsRun As New clsRuns()
        Dim strPath As String = ""

        'skryf data na leer        
        strFile = Me.txtFilename.Text

        strPath = clsRun.gen_getAdminPath() & "EiseBetalings"
        If Dir(strPath, vbDirectory) = "" Then MkDir(strPath)
        strFilePath = strPath & "\" & strFile

        Dim objwriter As System.IO.StreamWriter

        objwriter = New System.IO.StreamWriter(strFilePath, False)

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "ned.FetchNedDetail")

                Do While reader.Read
                    strOutput = """" & reader("debacc") & """,""" & reader("Order") & """,""" & reader("Credname") & """," _
                        & """" & reader("credacc") & """,,""" & reader("credbnksrt") & """," _
                        & """" & reader("Credname") & """,""Mooirivier " & reader("inv") & """,""" & String.Format("{0:N2}", reader("amount")) & """"

                    objwriter.WriteLine(strOutput)
                Loop

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
            objwriter.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

    End Sub
    Private Sub BegunstigdeHeaderUpdate()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Begunstigde", SqlDbType.NVarChar), _
                                                New SqlParameter("@aksiedatum", SqlDbType.NVarChar), _
                                                New SqlParameter("@bedrag", SqlDbType.Money), _
                                                New SqlParameter("@Toetslopie", SqlDbType.NVarChar), _
                                                New SqlParameter("@BatchID", SqlDbType.NVarChar), _
                                                New SqlParameter("@aksiedatum2", SqlDbType.Date), _
                                                New SqlParameter("@Polisno", SqlDbType.NVarChar)}

                params(0).Value = strTjekbesonderhede
                params(1).Value = CStr(Format(Today, "dd/MM/yyyy"))
                params(2).Value = dblVordPremie
                If Me.optFinalRun.Checked = True Then
                    params(3).Value = "Nee"
                Else
                    params(3).Value = "Ja"
                End If
                params(4).Value = Me.txtBacthID.Text
                params(5).Value = Today
                params(6).Value = strPolisno

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Ned.UpdateBegunstigdeHeader", params)

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

    End Sub
    Private Sub BegunstigdeDetailsUpdate()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Begunstigde", SqlDbType.NVarChar), _
                                                New SqlParameter("@aksiedatum", SqlDbType.NVarChar), _
                                                New SqlParameter("@Verwysingsnommer", SqlDbType.NVarChar), _
                                                New SqlParameter("@bedrag", SqlDbType.Money), _
                                                New SqlParameter("@Actdate", SqlDbType.NVarChar), _
                                                New SqlParameter("@Toetslopie", SqlDbType.NVarChar), _
                                                New SqlParameter("@Polisnommer", SqlDbType.NVarChar), _
                                                New SqlParameter("@Eisnommer", SqlDbType.NVarChar), _
                                                New SqlParameter("@Klas", SqlDbType.NVarChar), _
                                                New SqlParameter("@Versekerde", SqlDbType.NVarChar), _
                                                New SqlParameter("@Voorl", SqlDbType.NVarChar), _
                                                New SqlParameter("@BatchID", SqlDbType.NVarChar), _
                                                New SqlParameter("@BatchTyd", SqlDbType.NVarChar), _
                                                New SqlParameter("@reject", SqlDbType.NVarChar), _
                                                New SqlParameter("@btwjn", SqlDbType.NVarChar), _
                                                New SqlParameter("@fkVersekeraar", SqlDbType.Int), _
                                                New SqlParameter("@faktuurnommer", SqlDbType.NVarChar), _
                                                New SqlParameter("@fkBegunstigde", SqlDbType.Int), _
                                                New SqlParameter("@fkPayments", SqlDbType.Int)}

                params(0).Value = strTjekbesonderhede
                params(1).Value = CStr(Format(Today, "dd/MM/yyyy"))
                params(2).Value = strTjeknouit
                params(3).Value = dblVordPremie
                params(4).Value = Mid(params(1).Value, 1, 2) + Mid(params(1).Value, 4, 2) + Mid(params(1).Value, 9, 2)
                If Me.optFinalRun.Checked = True Then
                    params(5).Value = "Nee"
                Else
                    params(5).Value = "Ja"
                End If
                params(6).Value = strpolisno
                params(7).Value = streisno
                params(8).Value = strEisKlas
                params(9).Value = strVersekerde
                params(10).Value = strVoorl
                params(11).Value = Me.txtBacthID.Text
                params(12).Value = strBatchTyd
                params(13).Value = "Nee"
                params(14).Value = strBtwjn
                params(15).Value = Me.cmbInsurer.SelectedValue
                params(16).Value = strFaktuurnr
                params(17).Value = intpkBegunstigde
                params(18).Value = intpkPayments

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Ned.UpdateBegunstigdeDetails", params)

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

    End Sub
    Private Sub NedDetailsDelete()
        Try
            Using conn1 As SqlConnection = SqlHelper.GetConnection

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "ned.DeleteNedHeaderDetailTrailer")
                If conn1.State = ConnectionState.Open Then
                    conn1.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Private Sub BegunstigdeHeaderDelete()
        Try
            Using conn1 As SqlConnection = SqlHelper.GetConnection
                Dim params1() As SqlParameter = {New SqlParameter("@Toetslopie", SqlDbType.NVarChar)}

                params1(0).Value = "Ja"

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "ned.DeleteBegunstigdeHeaderToetslopie", params1)
                If conn1.State = ConnectionState.Open Then
                    conn1.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Private Sub BegunstigdeDetailsDelete()
        Try
            Using conn1 As SqlConnection = SqlHelper.GetConnection
                Dim params1() As SqlParameter = {New SqlParameter("@Toetslopie", SqlDbType.NVarChar)}

                params1(0).Value = "Ja"

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "ned.DeleteBegunstigdeDetailsToetslopie", params1)
                If conn1.State = ConnectionState.Open Then
                    conn1.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Private Sub DeleteNedHeaderDetailTrailer()
        Try
            Using conn1 As SqlConnection = SqlHelper.GetConnection

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "ned.DeleteNedHeaderDetailsTrailer")

                If conn1.State = ConnectionState.Open Then
                    conn1.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Private Sub GetBrokers()
        Dim intLenBrokers As Integer = 0

        For i = 0 To dgvBrokersPay.RowCount - 1
            strBrokers = strBrokers & dgvBrokersPay.Rows(i).Cells("pkMakelaar2").Value
            strBrokers = strBrokers & ","
        Next
        intLenBrokers = Len(strBrokers)
        strBrokers = strBrokers.left(intLenBrokers - 1)

    End Sub
    Private Sub BatchIDUnique()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params() As SqlParameter = {New SqlParameter("@BatchID", SqlDbType.NVarChar)}
                params(0).Value = Me.txtBacthID.Text

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "ned.FetchBegunstigdeDetailsBatchID", params)

                If reader.Read Then
                    If reader("reject") = "Nee" Then
                        blnUnique = False
                    Else
                        'if rejected, delete from begunstigdeheader and run again
                        Try
                            Using conn1 As SqlConnection = SqlHelper.GetConnection
                                Dim params1() As SqlParameter = {New SqlParameter("@BatchID", SqlDbType.NVarChar)}

                                params1(0).Value = Me.txtBacthID.Text

                                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "ned.DeleteBegunstigdeHeaderBatchID", params1)
                            End Using
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                            Exit Sub
                        End Try
                        blnUnique = True
                    End If
                Else
                    blnUnique = True
                End If

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    reader.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmdVerify_Click(sender As System.Object, e As System.EventArgs) Handles cmdVerify.Click
        Dim strKode As String = ""
        Dim blnVerified1 As Boolean = False
        Dim blnVerified2 As Boolean = False
        Dim i As Integer = 0

        blnVerified = False

        If Len(Me.txtPassword.Text) <> 8 Or (Not (IsNumeric(Me.txtPassword.Text))) Then
            MsgBox("2 passwords of 4 numerical characters must be entered", vbInformation)
            Me.lblVerified.Text = "O"
            Me.lblVerified.ForeColor = Color.Red
            Me.txtPassword.Text = ""
            Me.txtPassword.Focus()
            Exit Sub
        End If

        If (Me.txtPassword.Text).left(4) = (Me.txtPassword.Text).right(4) Then
            MsgBox("The 2 passwords can not be the same.", vbInformation)
            Me.lblVerified.Text = "O"
            Me.lblVerified.ForeColor = Color.Red
            Me.txtPassword.Text = ""
            Me.txtPassword.Focus()
            Exit Sub
        End If

        i = 1
        strKode = (Me.txtPassword.Text).left(4)

        Do While i < 3
            Try
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim param As New SqlParameter("@kode", SqlDbType.NVarChar)

                    param.Value = strKode
                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "sekurit.FetchGebruikersKode", param)

                    If reader.Read() Then
                        If reader("Nedseedno") = "J" Then
                            If i = 1 Then
                                blnVerified1 = True
                            ElseIf i = 2 Then
                                blnVerified2 = True
                            End If
                        Else
                            MsgBox("You do not have sufficient rights to do this run.", vbInformation)
                            Me.txtPassword.Text = ""
                            Me.txtPassword.Focus()
                            Me.lblVerified.Text = "O"
                            Me.lblVerified.ForeColor = Color.Red
                            Exit Sub
                        End If
                    Else
                        MsgBox("Password is not correct.", vbInformation)
                        Me.lblVerified.Text = "O"
                        Me.lblVerified.ForeColor = Color.Red
                        Me.txtPassword.Text = ""
                        Me.txtPassword.Focus()
                        Exit Sub
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
            i += 1
            strKode = (Me.txtPassword.Text).right(4)
        Loop

        If blnVerified1 = True And blnVerified2 = True Then
            blnVerified = True
            Me.lblVerified.Text = "P"
            Me.lblVerified.ForeColor = Color.Green
        End If

    End Sub

    Private Sub dgvBrokersPay_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBrokersPay.CellContentClick

    End Sub
End Class