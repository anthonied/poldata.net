Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports DAL
Public Class frmClaimsJoernale
    Dim blnIncomeValidation As Boolean = False
    Dim blnInfoChanges As Boolean = False

    Private Sub frmClaimsInkomste_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Claim Income - " & Persoonl.VOORL & " " & Persoonl.VERSEKERDE & " - " & glbPolicyNumber & " - " & glbEisno

        'Claims Income Type
        Using conn As SqlConnection = SqlHelper.GetConnection

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchDistinctIncomeType")
            cmbIncomeType.Items.Clear()
            Do While reader.Read
                cmbIncomeType.Items.Add(reader("tipe"))
            Loop

        End Using
        cmbIncomeType.Text = ""

        If intPkIncome <> 0 Then
            GetIncome()
        Else
            Me.txtIncomeVatAmount.Text = ""
            Me.txtIncomeInvRefNr.Text = ""
            Me.txtIncomeDetails.Text = ""
            Me.txtIncomeClaimnr3rdParty.Text = ""
            Me.txtIncomeChecqueNr.Text = ""
            Me.txtIncomeAmountWithoutVat.Text = ""
            Me.txtIncomeAmount.Text = ""
            Me.cmbIncomeType.Text = ""
            Me.dtpIncomeDate.Value = Today
            Me.optIncomeElectronic.Checked = False
            Me.optIncomeChecque.Checked = False
            Me.optIncomeCash.Checked = False
            Me.chkIncomeVAT.Checked = False
            Me.chkCancel.Checked = False
            Me.chkCancel.Enabled = False
            Me.lblCancel.Enabled = False
        End If

        blnInfoChanges = False
    End Sub
    Private Sub GetIncome()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim paramsClaims() As SqlParameter = {New SqlParameter("@pkIncome", SqlDbType.Int)}
                paramsClaims(0).Value = intPkIncome

                Dim readerClaims As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchIncomepkIncome", paramsClaims)

                If readerClaims.Read Then
                    Dim item As ClaimsIncomeEntity = New ClaimsIncomeEntity()

                    If readerClaims("pkIncome") IsNot DBNull.Value Then
                        item.pkIncome = readerClaims("pkIncome")
                    Else
                        item.pkIncome = 0
                    End If
                    If readerClaims("polisno") IsNot DBNull.Value Then
                        item.polisno = readerClaims("polisno")
                    Else
                        item.polisno = ""
                    End If
                    If readerClaims("eisno") IsNot DBNull.Value Then
                        item.eisno = readerClaims("eisno")
                    Else
                        item.eisno = ""
                    End If
                    If readerClaims("DatumInkomste") IsNot DBNull.Value Then
                        item.DatumInkomste = readerClaims("DatumInkomste")
                    Else
                        item.DatumInkomste = Nothing
                    End If
                    If readerClaims("besonderhede") IsNot DBNull.Value Then
                        item.besonderhede = readerClaims("besonderhede")
                    Else
                        item.besonderhede = ""
                    End If
                    If readerClaims("Btwjn") IsNot DBNull.Value Then
                        item.Btwjn = readerClaims("Btwjn")
                    Else
                        item.Btwjn = ""
                    End If
                    If readerClaims("kwitansienr") IsNot DBNull.Value Then
                        item.kwitansienr = readerClaims("kwitansienr")
                    Else
                        item.kwitansienr = ""
                    End If
                    If readerClaims("status") IsNot DBNull.Value Then
                        item.status = readerClaims("status")
                    Else
                        item.status = ""
                    End If
                    If readerClaims("Tipe") IsNot DBNull.Value Then
                        item.Tipe = readerClaims("Tipe")
                    Else
                        item.Tipe = ""
                    End If
                    If readerClaims("Trans_dat") IsNot DBNull.Value Then
                        item.Trans_dat = readerClaims("Trans_dat")
                    Else
                        item.Trans_dat = Nothing
                    End If
                    If readerClaims("Tjekno") IsNot DBNull.Value Then
                        item.Tjekno = readerClaims("Tjekno")
                    Else
                        item.Tjekno = ""
                    End If
                    If readerClaims("Tjekofkontant") IsNot DBNull.Value Then
                        item.Tjekofkontant = readerClaims("Tjekofkontant")
                    Else
                        item.Tjekofkontant = ""
                    End If
                    If readerClaims("VerhalingEisno") IsNot DBNull.Value Then
                        item.VerhalingEisno = readerClaims("VerhalingEisno")
                    Else
                        item.VerhalingEisno = ""
                    End If
                    If readerClaims("bedrag") IsNot DBNull.Value Then
                        item.bedrag = readerClaims("bedrag")
                    Else
                        item.bedrag = 0
                    End If
                    If readerClaims("Btwbedrag") IsNot DBNull.Value Then
                        item.Btwbedrag = readerClaims("Btwbedrag")
                    Else
                        item.Btwbedrag = 0
                    End If
                    If readerClaims("Btwuitbedrag") IsNot DBNull.Value Then
                        item.Btwuitbedrag = readerClaims("Btwuitbedrag")
                    Else
                        item.Btwuitbedrag = 0
                    End If
                    If readerClaims("Cancel") IsNot DBNull.Value Then
                        item.Cancel = readerClaims("Cancel")
                    End If

                    Me.cmbIncomeType.Text = item.Tipe
                    Me.dtpIncomeDate.Value = item.DatumInkomste
                    Me.txtIncomeAmount.Text = item.bedrag
                    Me.txtIncomeAmountWithoutVat.Text = item.Btwuitbedrag
                    Me.txtIncomeChecqueNr.Text = item.Tjekno
                    Me.txtIncomeClaimnr3rdParty.Text = item.VerhalingEisno
                    Me.txtIncomeDetails.Text = item.besonderhede
                    Me.txtIncomeInvRefNr.Text = item.kwitansienr
                    Me.txtIncomeVatAmount.Text = item.Btwbedrag
                    If item.Btwjn = "J" Then
                        Me.chkIncomeVAT.Checked = True
                    Else
                        Me.chkIncomeVAT.Checked = False
                    End If
                    If item.Tjekofkontant = "Tjek" Then
                        Me.optIncomeChecque.Checked = True
                    ElseIf item.Tjekofkontant = "Kontant" Then
                        Me.optIncomeCash.Checked = True
                    Else
                        Me.optIncomeElectronic.Checked = True
                    End If
                    If item.Cancel <> 0 Then
                        Me.lblCancel.Enabled = True
                        Me.chkCancel.Enabled = True
                        Me.chkCancel.Checked = True
                        IncomeEnabled(False)
                    Else
                        Me.lblCancel.Enabled = False
                        Me.chkCancel.Enabled = False
                        Me.chkCancel.Checked = False
                        IncomeEnabled(True)
                    End If
                Else
                    MsgBox("The Claim Income could not be found.", vbInformation)
                End If

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    readerClaims.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Private Sub IncomeEnabled(ByVal blnEnabled As Boolean)
        Me.txtIncomeVatAmount.Enabled = blnEnabled
        Me.txtIncomeInvRefNr.Enabled = blnEnabled
        Me.txtIncomeDetails.Enabled = blnEnabled
        Me.txtIncomeClaimnr3rdParty.Enabled = blnEnabled
        Me.txtIncomeChecqueNr.Enabled = blnEnabled
        Me.txtIncomeAmountWithoutVat.Enabled = blnEnabled
        Me.txtIncomeAmount.Enabled = blnEnabled
        Me.cmbIncomeType.Enabled = blnEnabled
        Me.dtpIncomeDate.Enabled = blnEnabled
        Me.optIncomeElectronic.Enabled = blnEnabled
        Me.optIncomeChecque.Enabled = blnEnabled
        Me.optIncomeCash.Enabled = blnEnabled
        Me.chkIncomeVAT.Enabled = blnEnabled
        If blnEnabled = True Then
            Me.chkCancel.Checked = False
            Me.chkCancel.Enabled = False
            Me.lblCancel.Enabled = False
        Else
            Me.chkCancel.Checked = True
            Me.chkCancel.Enabled = True
            Me.lblCancel.Enabled = True
        End If

    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        If blnInfoChanges = True Then
            If MsgBox("Are you sure you want to cancel and loose all your changes?", vbYesNo) = MsgBoxResult.Yes Then
                Me.Close()
            Else
                Exit Sub
            End If
        Else
            Me.Close()
        End If

    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If Me.chkCancel.Checked = True Then
            MsgBox("This income was cancelled.  You cannot edit on a cancelled income. To edit, please make it active again.", vbInformation)
            Me.chkCancel.Focus()
            Exit Sub
        Else
            IncomeValidation()

            If blnIncomeValidation = True Then
                SaveIncome()
                frmClaimsList.GetAllIncome()
                Me.Close()
            End If
        End If
    End Sub
    Private Sub IncomeValidation()
        blnIncomeValidation = False

        'Income type
        If Me.cmbIncomeType.Text = "" Then
            MsgBox("A Type must be chosen.", vbInformation)
            blnIncomeValidation = False
            Me.cmbIncomeType.Focus()
            Exit Sub
        End If

        'besonderhede 
        If Me.txtIncomeDetails.Text = "" Then
            MsgBox("Income details must be filled in.", vbInformation)
            blnIncomeValidation = False
            Me.txtIncomeDetails.Focus()
            Exit Sub
        End If

        'date 
        If Me.dtpIncomeDate.Text = "" Then
            MsgBox("A date must be chosen.", vbInformation)
            blnIncomeValidation = False
            Me.dtpIncomeDate.Focus()
            Me.btnOK.Enabled = True
            Exit Sub
        End If

        'amount 
        If Me.txtIncomeAmount.Text = "" Then
            MsgBox("The Income Amount must be filled in.", vbInformation)
            blnIncomeValidation = False
            Me.txtIncomeAmount.Focus()
            Exit Sub
        End If

        If (Not (IsNumeric(txtIncomeAmount.Text))) Then
            MsgBox("Amount value must be numeric!")
            Me.txtIncomeAmount.Focus()
            blnIncomeValidation = False
            Exit Sub
        End If

        If Me.txtIncomeAmountWithoutVat.Text <> "" Then
            If (Not (IsNumeric(txtIncomeAmountWithoutVat.Text))) Then
                MsgBox("Amount without VAT value must be numeric!")
                Me.txtIncomeAmountWithoutVat.Focus()
                blnIncomeValidation = False
                Exit Sub
            End If
        End If

        If Me.txtIncomeVatAmount.Text <> "" Then
            If (Not (IsNumeric(txtIncomeVatAmount.Text))) Then
                MsgBox("Amount value must be numeric!")
                Me.txtIncomeVatAmount.Focus()
                blnIncomeValidation = False
                Exit Sub
            End If
        End If

        If Me.optIncomeCash.Checked = False And Me.optIncomeChecque.Checked = False And Me.optIncomeElectronic.Checked = False Then
            MsgBox("The payment method must be chosen.", vbInformation)
            blnIncomeValidation = False
            Me.optIncomeElectronic.Focus()
            Exit Sub
        End If

        blnIncomeValidation = True
    End Sub

    Private Sub cmbIncomeType_TextChanged(sender As Object, e As System.EventArgs) Handles cmbIncomeType.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtIncomeDetails_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtIncomeDetails.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtIncomeInvRefNr_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtIncomeInvRefNr.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtIncomeAmount_Leave(sender As Object, e As System.EventArgs) Handles txtIncomeAmount.Leave
        If Me.txtIncomeAmount.Text = "" Then
            Me.txtIncomeAmount.Text = "0"
        End If
        If Me.chkIncomeVAT.Checked = False Then
            Me.txtIncomeAmountWithoutVat.Text = 0
            Me.txtIncomeVatAmount.Text = 0
        End If
    End Sub

    Private Sub txtIncomeAmount_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtIncomeAmount.TextChanged
        blnInfoChanges = True
        VatAmount()
    End Sub

    Private Sub chkIncomeVAT_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkIncomeVAT.CheckedChanged
        blnInfoChanges = True

        vatAmount()
    End Sub
    Private Sub VatAmount()
        'werk vat uit
        If Me.chkIncomeVAT.Checked = True Then
            Me.txtIncomeVatAmount.Text = FormatNumber((IIf(Me.txtIncomeAmount.Text = "", 0, Me.txtIncomeAmount.Text) * (Constants.VAT / 100)), 2)
            Me.txtIncomeAmountWithoutVat.Text = FormatNumber((IIf(Me.txtIncomeAmount.Text = "", 0, Me.txtIncomeAmount.Text) - Me.txtIncomeVatAmount.Text), 2)
        Else
            Me.txtIncomeVatAmount.Text = 0
            Me.txtIncomeAmountWithoutVat.Text = 0
        End If
    End Sub

    Private Sub txtIncomeVatAmount_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtIncomeVatAmount.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtIncomeAmountWithoutVat_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtIncomeAmountWithoutVat.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub dtpIncomeDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpIncomeDate.ValueChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtIncomeClaimnr3rdParty_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtIncomeClaimnr3rdParty.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtIncomeChecqueNr_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtIncomeChecqueNr.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub optIncomeChecque_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optIncomeChecque.CheckedChanged
        blnInfoChanges = True
    End Sub

    Private Sub optIncomeCash_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optIncomeCash.CheckedChanged
        blnInfoChanges = True
    End Sub

    Private Sub optIncomeElectronic_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optIncomeElectronic.CheckedChanged
        blnInfoChanges = True
    End Sub

    Private Sub cmbIncomeType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbIncomeType.SelectedIndexChanged
        blnInfoChanges = True
    End Sub
    Private Sub SaveIncome()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Eisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@besonderhede", SqlDbType.NVarChar), _
                                                New SqlParameter("@bedrag", SqlDbType.Money), _
                                                New SqlParameter("@status", SqlDbType.NVarChar), _
                                                New SqlParameter("@kwitansienr", SqlDbType.NVarChar), _
                                                New SqlParameter("@Btwuitbedrag", SqlDbType.Money), _
                                                New SqlParameter("@Btwbedrag", SqlDbType.Money), _
                                                New SqlParameter("@BtwJN", SqlDbType.NVarChar), _
                                                New SqlParameter("@TjekofKontant", SqlDbType.NVarChar), _
                                                New SqlParameter("@Tjekno", SqlDbType.NVarChar), _
                                                New SqlParameter("@Trans_dat", SqlDbType.Date), _
                                                New SqlParameter("@VerhalingEisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@Tipe", SqlDbType.NVarChar), _
                                                New SqlParameter("@DatumInkomste", SqlDbType.Date), _
                                                New SqlParameter("@pkIncome", SqlDbType.Int), _
                                                New SqlParameter("@Cancel", SqlDbType.Bit)}

                params(0).Value = glbEisno
                params(1).Value = glbPolicyNumber
                params(2).Value = Me.txtIncomeDetails.Text
                params(3).Value = Me.txtIncomeAmount.Text
                params(4).Value = ""
                params(5).Value = Me.txtIncomeInvRefNr.Text
                params(6).Value = IIf(Me.txtIncomeAmountWithoutVat.Text = "", 0, Me.txtIncomeAmountWithoutVat.Text)
                params(7).Value = IIf(Me.txtIncomeVatAmount.Text = "", 0, Me.txtIncomeVatAmount.Text)
                If Me.chkIncomeVAT.Checked = True Then
                    params(8).Value = "J"
                Else
                    params(8).Value = "N"
                End If
                If Me.optIncomeCash.Checked Then
                    params(9).Value = "Kontant"
                ElseIf Me.optIncomeChecque.Checked Then
                    params(9).Value = "Tjek"
                Else
                    params(9).Value = "Elektr"
                End If
                params(10).Value = Me.txtIncomeChecqueNr.Text
                params(11).Value = Today
                params(12).Value = Me.txtIncomeClaimnr3rdParty.Text
                params(13).Value = Me.cmbIncomeType.Text
                params(14).Value = Me.dtpIncomeDate.Value
                params(15).Value = intPkIncome
                params(16).Value = False

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "eisdat.UpdateIncome", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
        Dim strBeskrywing As String = ""
        If intpkIncome <> 0 Then
            If Persoonl.TAAL = 0 Then
                strBeskrywing = "Eis inkomste gewysig: " & glbEisno
            Else
                strBeskrywing = "Claim income edited: " & glbEisno
            End If
            BaseForm.UpdateWysig(168, strBeskrywing)
        Else
            If Persoonl.TAAL = 0 Then
                strBeskrywing = "Eis inkomste bygevoeg: " & glbEisno
            Else
                strBeskrywing = "Claim income added: " & glbEisno
            End If
            BaseForm.UpdateWysig(168, strBeskrywing)
        End If
    End Sub

    Private Sub chkCancel_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCancel.CheckedChanged
        blnInfoChanges = True
    End Sub
End Class