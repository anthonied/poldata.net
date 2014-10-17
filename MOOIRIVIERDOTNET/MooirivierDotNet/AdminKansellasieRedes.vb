Option Strict Off
Option Explicit On

Imports System.Data.SqlClient
Imports DAL

Friend Class AdminKansellasieRedes
    Inherits BaseForm
    Dim intpkKansellasieRedes As Integer
    Dim blnaddNew As Boolean
    Public list As List(Of KansellasieRedesEntity)
    Dim strsortOrder As String
    Private Sub btnAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnAdd.Click
        enableDetail(True)
        blnaddNew = True
    End Sub

    Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnDelete.Click
        blnaddNew = False
        'checkForChildren
        If intpkKansellasieRedes <> 0 Then
            If MsgBox("Are you sure you want to delete the selected item?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If checkForChildren() Then
                    'Andriette 22/08/2013 verander bewoording
                    If MsgBox("This item is linked to policies and cannot be removed. " & Chr(13) & " Would you like to mark it as deleted?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        'MarkForDelete
                        chkDeleted.Checked = True
                        Save("MarkForDelete")
                    End If
                Else
                    'Delete
                    Save("Delete")
                End If

                Me.enableDetail(False)
                refreshGrid()
            End If
        End If
    End Sub
    Private Sub btnSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSave.Click
        If InStr(1, Me.txtBeskrywingAfrikaans.Text, "'") > 0 Then
            MsgBox("The ""'"" character may not appear in the Afrikaans Description.")
            Me.txtBeskrywingAfrikaans.Focus()
        End If

        If InStr(1, Me.txtBeskrywingEngels.Text, "'") > 0 Then
            MsgBox("The ""'"" character may not appear in the English Description.")
            Me.txtBeskrywingEngels.Focus()
        End If

        Save("Add/Edit")
        enableDetail(False)
        refreshGrid()
    End Sub
    Sub Save(ByVal type As String)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@pkKansellasieRedes", SqlDbType.Int), _
                                                New SqlParameter("@BeskrywingAfrikaans", SqlDbType.NVarChar), _
                                                New SqlParameter("@BeskrywingEngels", SqlDbType.NVarChar), _
                                                New SqlParameter("@Deleted", SqlDbType.Int), _
                                                New SqlParameter("@Type", SqlDbType.NVarChar)}

                If blnaddNew Then
                    params(0).Value = DBNull.Value
                Else
                    'Andriette die pk value le nie meer op 3 nie maar op 4
                    'params(0).Value = CInt(DetailDataGridView.SelectedCells.Item(3).Value)
                    params(0).Value = CInt(dgvKansellasieRedes.SelectedCells.Item(4).Value)
                End If

                params(1).Value = Me.txtBeskrywingAfrikaans.Text
                params(2).Value = Me.txtBeskrywingEngels.Text

                If Me.chkDeleted.Checked Then
                    params(3).Value = 1
                Else
                    params(3).Value = 0
                End If

                params(4).Value = type

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateKansellasieRedes", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Private Sub AdminKansellasieRedes_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        dgvKansellasieRedes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        'Andriette 27/08/2013 stel die sortorder
        strsortOrder = "Afrikaans"
        refreshGrid()
        Me.Text = My.Application.Info.Title & " - Admin - Cancellation Reasons"
    End Sub

    'Enable / Disable detail text boxes and labels
    Public Sub enableDetail(ByRef enable As Boolean)
        Me.txtBeskrywingAfrikaans.Text = ""
        Me.txtBeskrywingEngels.Text = ""
        Me.chkDeleted.CheckState = False

        Me.lblBeskrywingAfrikaans.Enabled = enable
        Me.lblBeskrywingEngels.Enabled = enable
        Me.lblDeleted.Enabled = enable

        Me.txtBeskrywingEngels.Enabled = enable
        Me.txtBeskrywingAfrikaans.Enabled = enable
        Me.chkDeleted.Enabled = enable

        Me.btnSave.Enabled = enable

        If enable Then
            Me.txtBeskrywingAfrikaans.Focus()
        End If
    End Sub
    Public Sub refreshGrid()
        dgvKansellasieRedes.AutoGenerateColumns = False
        list = ListKansellasieRedes()

        If strsortOrder = "English" Then
            list.Sort(AddressOf sortEngels)
        ElseIf strsortOrder = "Afrikaans" Then
            list.Sort(AddressOf sortAfrikaans)
        ElseIf strsortOrder = "Deleted" Then
            list.Sort(AddressOf sortDeleted)
        End If

        dgvKansellasieRedes.DataSource = list
    End Sub
    Private Shared Function sortEngels(ByVal x As KansellasieRedesEntity, ByVal y As KansellasieRedesEntity) As Integer
        Return (x.Deleted.ToString.Trim + x.BeskrywingEngels).CompareTo(y.Deleted.ToString.Trim + y.BeskrywingEngels)
    End Function
    Private Shared Function sortAfrikaans(ByVal x As KansellasieRedesEntity, ByVal y As KansellasieRedesEntity) As Integer
        Return (x.Deleted.ToString.Trim + x.BeskrywingAfrikaans).CompareTo(y.Deleted.ToString.Trim + y.BeskrywingAfrikaans)
    End Function
    Private Shared Function sortDeleted(ByVal x As KansellasieRedesEntity, ByVal y As KansellasieRedesEntity) As Integer
        Return x.Deleted.ToString.Trim.CompareTo(y.Deleted.ToString.Trim)
    End Function

    'Check if item is linked
    Public Function checkForChildren() As Boolean
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@pkKansellasieRedes", SqlDbType.Int)
                'Andriette 05/06/2013 die plek van die PK is nie op 3 nie maar op 4
                '  param.Value = CInt(DetailDataGridView.SelectedCells.Item(3).Value)
                param.Value = CInt(dgvKansellasieRedes.SelectedCells.Item(4).Value)
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.CheckKansellasieRedesExist", param)
                While reader.Read()
                    Return reader("countRedes")
                End While
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function


    Private Sub DetailDataGridView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvKansellasieRedes.Click
        Try
            blnaddNew = False
            'Andriette 05/06/2013 die pk vir die kansellasieredes is nie in posisie 3 nie maar wel in 4
            'pkKansellasieRedes = DetailDataGridView.SelectedCells.Item(3).Value
            intpkKansellasieRedes = dgvKansellasieRedes.SelectedCells.Item(4).Value

            If intpkKansellasieRedes <> 0 Then
                enableDetail(True)
                Me.txtBeskrywingAfrikaans.Text = dgvKansellasieRedes.SelectedCells.Item(0).Value
                Me.txtBeskrywingEngels.Text = dgvKansellasieRedes.SelectedCells.Item(1).Value
                Me.chkDeleted.CheckState = dgvKansellasieRedes.SelectedCells.Item(2).Value
                If dgvKansellasieRedes.SelectedCells.Item(2).Value = 1 Then
                    Me.chkDeleted.Enabled = True
                Else
                    Me.chkDeleted.Enabled = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DetailDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvKansellasieRedes.CellContentClick
        dgvKansellasieRedes.ReadOnly = True
    End Sub

    Private Sub DetailDataGridView_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvKansellasieRedes.ColumnHeaderMouseClick
        strsortOrder = dgvKansellasieRedes.Columns(e.ColumnIndex).HeaderText
        refreshGrid()
    End Sub

    Private Sub DetailDataGridView_DataBindingComplete(sender As Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvKansellasieRedes.DataBindingComplete
        For intTeller = 0 To dgvKansellasieRedes.RowCount - 1
            'Andriette 23/08/2013 maak die value toets reg was vir true of false, werk net met 0 en 1
            If dgvKansellasieRedes.Rows(intTeller).Cells("Deleted").Value = 1 Then
                dgvKansellasieRedes.Rows(intTeller).Cells("Status").Value = "O"
                dgvKansellasieRedes.Rows(intTeller).Cells("Status").Style.ForeColor = Color.Red
            ElseIf dgvKansellasieRedes.Rows(intTeller).Cells("Deleted").Value = 0 Then
                dgvKansellasieRedes.Rows(intTeller).Cells("Status").Value = "P"
                dgvKansellasieRedes.Rows(intTeller).Cells("Status").Style.ForeColor = Color.Green
            End If
        Next

    End Sub
End Class