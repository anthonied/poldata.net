Option Strict Off
Option Explicit On

Imports System.Data.SqlClient
Imports DAL

Friend Class selfoonListFrm
    Inherits BaseForm
    Public blnaddnew As Boolean
    Public strCancelComment As String
    'Description: Form containing a grid with list of cellphones for selected policy holder
    '           : Buttons to add, edit and cancel a selected cellphone
    '           : Form working in conjunction with selfoonDetailfrm

    'Cancel button - close form

    Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        Me.Close()

    End Sub
   
    Public Sub RefreshGrid()
        dgvCellDetails.AutoGenerateColumns = False
        dgvCellDetails.DataSource = ListCellphone()
    End Sub

    'Edit the selected cellphone
    Private Sub btnEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnEdit.Click
        'gridSelfoon.col = 0
        blnaddnew = False
        If dgvCellDetails.Text <> "pkInsCell" Then
            selfoonDetailFrm.ShowDialog()
        End If
    End Sub
    'Ok button - close form
    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
        'Andriette 16/08/2013 gebruik die global polisnommer
        ' If Form1.POLISNO.Text = Nothing Then
        If glbPolicyNumber = Nothing Then
            MsgBox("Please allocate a policy number for the insured", MsgBoxStyle.Information)
            Exit Sub
        Else
            ' Andriette 14/06/2013 verander die selfoon textbox na 'n button
            'Form1.btnSelfoonPrem.Text = (cellphoneGetTotalPremium(Form1.POLISNO.Text))
            'Andriette 16/08/2013 gebruik die global polisnommer
            '            Form1.btnSelfoonPremie.Text = (cellphoneGetTotalPremium(Form1.POLISNO.Text))
            'Andriette 06/09/2014 skuif na die selfndet vorm
            ' Form1.btnSelfoonPremie.Text = (cellphoneGetTotalPremium(glbPolicyNumber))
            '  doen_subtotaal()
            BFUpdateItemsSubTotals(glbPolicyNumber)
            HerBereken_Premie()
            '   Form1.Premie2.Text = FormatNumber((Str(Val(Form1.Premie2.Text) + Val(Form1.btnSelfoonPremie.Text))), 2)
            '  Form1.lblMaandeliksePremie.Text = FormatNumber((Str(Val(Form1.lblMaandeliksePremie.Text) + Val(Form1.btnSelfoonPremie.Text))), 2)
            Me.Close()
        End If
    End Sub

    'Add a new cellphone
    Private Sub btnVoegBy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnVoegby.Click
        blnaddnew = True
        'Andriette 16/08/2013 gebruik die global polisnommer
        '  If Form1.POLISNO.Text = Nothing Then
        If glbPolicyNumber = Nothing Then
            MsgBox("Please allocate a policy number for the insured", MsgBoxStyle.Information)
            Exit Sub
        Else
            selfoonDetailFrm.ShowDialog()
        End If
    End Sub

    'Populate grid with cellphone data according to policy number
    Private Sub selfoonListFrm_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        dgvCellDetails.ReadOnly = True
        refreshGrid()

        dgvCellDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.Text = My.Application.Info.Title & " - Policy Functions - Cellphone"

        If dgvCellDetails.RowCount <> 0 Then
            Me.btnEdit.Enabled = True
        Else
            Me.btnEdit.Enabled = False
        End If

        If Persoonl.GEKANS Then
            Me.btnVoegby.Enabled = False
        Else
            Me.btnVoegby.Enabled = True
        End If
    End Sub

    Private Sub CellDetailsDataGridView_DataBindingComplete(sender As Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvCellDetails.DataBindingComplete

        For intTeller = 0 To dgvCellDetails.RowCount - 1
            If dgvCellDetails.Rows(intTeller).Cells("Status").Value = "A" Then
                dgvCellDetails.Rows(intTeller).Cells("ActiveIcon").Value = "P"
                dgvCellDetails.Rows(intTeller).Cells("ActiveIcon").Style.ForeColor = Color.Green
            ElseIf dgvCellDetails.Rows(intTeller).Cells("Status").Value = "C" Then
                dgvCellDetails.Rows(intTeller).Cells("ActiveIcon").Value = "O"
                dgvCellDetails.Rows(intTeller).Cells("ActiveIcon").Style.ForeColor = Color.Red
            End If
        Next (intTeller)
    End Sub
    'On double click on grid - edit the selected record

    Private Sub CellDetailsDataGridView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCellDetails.DoubleClick
        selfoonDetailFrm.ShowDialog()
    End Sub

    Public Sub SaveChancelledPhone()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params() As SqlParameter = {New SqlParameter("@pkInsCell", SqlDbType.Int), _
                                                New SqlParameter("@status", SqlDbType.NVarChar), _
                                                New SqlParameter("@cancel_date", SqlDbType.DateTime), _
                                                New SqlParameter("@cancel_comment", SqlDbType.NVarChar)}
                params(0).Value = CInt(dgvCellDetails.SelectedCells.Item(0).Value)
                params(1).Value = "C"
                params(2).Value = Now()
                params(3).Value = strCancelComment
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateCellphoneChancelled", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
End Class