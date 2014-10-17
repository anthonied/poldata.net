Option Strict Off
Option Explicit On

Imports System.Data.SqlClient
Imports DAL

Friend Class BnkCodes
    Inherits BaseForm

    'Description  : A search engine for bank branches / codes
    Dim intpkBankCodes As Integer
    Dim strbankSelected As String
    Dim strbranchSelected As String
    Dim strbrancCodeSelected As String
    Dim strtypeSelected As String

    Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    'Button clear clicked
    Private Sub btnClear_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClear.Click
        'Clear txtboxes and grid
        BankCodesGridView1.DataSource = Nothing
        Me.txtBank.Text = ""
        Me.txtBranch.Text = ""
        Me.txtCode.Text = ""
        Me.txtBank.Focus()
    End Sub
    'Button ok clicked
    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click  
        Try

            intpkBankCodes = BankCodesGridView1.SelectedCells.Item(0).Value
            bankSelected = BankCodesGridView1.SelectedCells.Item(1).Value
            branchSelected = BankCodesGridView1.SelectedCells.Item(2).Value
            brancCodeSelected = BankCodesGridView1.SelectedCells.Item(3).Value
            strtypeSelected = BankCodesGridView1.SelectedCells.Item(4).Value

            If intpkBankCodes <> 0 Then

                Select Case LCase(Trim(Me.txtFormToPopulate.Text))
                    Case "search"

                        Search.txtPkBnkCodes.Text = intpkBankCodes
                        Search.txtBank.Text = bankSelected
                        Search.txtBranch.Text = branchSelected
                        Search.txtBranchCode.Text = brancCodeSelected
                        'Linkie 02/07/2014 - sit in sodat eise dit ook kan gebruik
                    Case "frmclaimsbeneficiary"
                        frmClaimsBeneficiary.txtBankCodes.Text = intpkBankCodes
                        frmClaimsBeneficiary.txtBank.Text = bankSelected
                        frmClaimsBeneficiary.txtBranchCode.Text = brancCodeSelected
                        'Linkie 02/07/2014 - sit in sodat eise dit ook kan gebruik
                    Case "frmclaimspayments"
                        frmClaimsPayments.txtPkBnkCodes.Text = intpkBankCodes
                        frmClaimsPayments.txtBank.Text = bankSelected
                        frmClaimsPayments.txtBranchCode.Text = brancCodeSelected
                        frmClaimsPayments.txtBranch.Text = branchSelected
                    Case Else

                        'Populate caller form with selected values
                        Bet_Wyse.txtPkBnkCodes.Text = intpkBankCodes
                        Bet_Wyse.txtBank.Text = bankSelected
                        Bet_Wyse.txtBranch.Text = branchSelected
                        Bet_Wyse.txtBranchCode.Text = brancCodeSelected
                        Bet_Wyse.txtType.Text = strtypeSelected
                        'Andriette 10/04/2014 haal uit want dit is nie noodwendig in hierdie volgorde nie
                        ' Bet_Wyse.txtAccNumber.Text = ""

                        If Bet_Wyse.txtType.Text = "Credit card" Then
                            Bet_Wyse.cmbAccType.SelectedIndex = 3 'Credit
                            Bet_Wyse.lblCreditCardVervalDatum.Enabled = True
                            Bet_Wyse.lblCVVNumber.Enabled = True
                            Bet_Wyse.txtCVVNommer.Enabled = True
                            Bet_Wyse.txtKaartVervaldatum.Enabled = True
                        Else
                            Bet_Wyse.cmbAccType.SelectedIndex = -1
                            Bet_Wyse.lblCreditCardVervalDatum.Enabled = False
                            Bet_Wyse.lblCVVNumber.Enabled = False
                            Bet_Wyse.txtCVVNommer.Enabled = False
                            Bet_Wyse.txtKaartVervaldatum.Enabled = False
                        End If

                End Select
            Else
                MsgBox("A specific branch must be selected to continue.", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Me.Close()
    End Sub

    Public Sub refreshGrid()

        BankCodesGridView1.AutoGenerateColumns = False
        BankCodesGridView1.DataSource = ListBankCodes()
        If BankCodesGridView1.RowCount > 0 Then
            btnOk.Enabled = True
        End If

    End Sub
    'Button search clicked
    Private Sub btnSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSearch.Click
        refreshGrid()
        Me.lblTotal.Text = "Number found: " & BankCodesGridView1.RowCount
    End Sub
    Private Sub BnkCodes_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        Me.txtBank.Focus()
    End Sub

    Private Sub BnkCodes_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
   

        'Andriette 23/01/2014
        BnkCodesClearFields()
        'Populate dropdown
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchType")

                Do While reader.Read
                    cmbBnkType.Items.Add(reader("Type"))
                Loop
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        'Select the first item
        Me.cmbBnkType.SelectedIndex = 0
    End Sub

    Private Sub txtCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCode.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If Char.IsDigit(e.KeyChar) Then
                'continue
            Else
                e.Handled = True
                MsgBox("The Branch code must be numeric", MsgBoxStyle.Information, "Verify Branch Code")
                txtCode.Focus()
            End If
        End If
    End Sub


    Private Sub txtBank_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBank.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If Char.IsLetter(e.KeyChar) Or (Char.IsWhiteSpace(e.KeyChar)) Then
                'continue
            Else
                e.Handled = True
                MsgBox("The bank must be letters only", MsgBoxStyle.Information, "Verify Bank Name")
                txtBank.Focus()
            End If
        End If

    End Sub
    'Andriette 26/01/2014 
    Private Sub BnkCodesClearFields()

        cmbBnkType.Items.Clear()
        txtBank.Text = ""
        txtBranch.Text = ""
        txtCode.Text = ""
        BankCodesGridView1.DataSource = Nothing
        btnOk.Enabled = False
    End Sub

    Private Sub BankCodesGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles BankCodesGridView1.CellContentClick
        btnOk.PerformClick()
    End Sub
End Class