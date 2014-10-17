Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports DAL

Friend Class frmLysDatumWysig
    Inherits BaseForm
    Dim gebruiker As String
    Dim datum As DateTimePicker
    Dim wysig_besk As String
    Dim kodeSql As String
    Dim dsql As String
    Dim wysigbeskSql As String
    'Dim xlapp As Microsoft.Office.Interop.Excel.Application
    'Dim xlbook As Microsoft.Office.Interop.Excel.Workbook
    'Dim xlsheet As Microsoft.Office.Interop.Excel.Worksheet
    Dim introw As Short
    Dim chooserow As Short
    Dim mystring As String
    Dim chosencodes As String
    Dim chosenstring As String
    Dim row As Short
    Dim takSql As String
    Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOK.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
    End Sub
    Private Sub btnSoekWysigingskode_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSoekWysigingskode.Click
        refreshGrid()
    End Sub
    Public Sub refreshGrid()
        DataGridView1.AutoGenerateColumns = False
        Dim listGridview1 As List(Of WysigEntity)
        Dim i As Integer
        listGridview1 = ListWysigDescr()

        DataGridView1.Rows.Clear()
        DataGridView2.Rows.Clear()

        If DataGridView1.ColumnCount = 0 Then
            DataGridView1.Columns.Add("Kode", "Code")
            DataGridView1.Columns.Add("besk", "Description")
        End If

        For i = 0 To listGridview1.Count - 1
            DataGridView1.Rows.Insert(i, listGridview1.Item(i).kode, listGridview1.Item(i).besk)
        Next
    End Sub

    Sub PopulateListUser()
        cmbGebruiker.DataSource = ListGebruikerForWysigDropdown()
    End Sub
    Private Sub frmLysDatumWysig_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        PopulateListUser()
        Me.dtpTotDatum.Value = Format(Now, "dd/MM/yyyy")
        Me.dtpVanafDatum.Value = Format(Now, "dd/MM/yyyy")
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.Refresh()
        DataGridView2.Refresh()
        DataGridView2.ReadOnly = True
        DataGridView1.ReadOnly = True


    End Sub
    Private Sub btnOneOver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOneOver.Click
        Try
            Dim i As Integer
            If DataGridView2.ColumnCount = 0 Then
                DataGridView2.Columns.Add("Kode", "Code")
                DataGridView2.Columns.Add("besk", "Description")
            End If
            For i = 0 To DataGridView2.RowCount - 1
                If DataGridView1.SelectedCells.Item(0).Value = DataGridView2.Rows(i).Cells(0).Value Then
                    MsgBox("The description was already added.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            Next i
            DataGridView2.Rows.Insert(DataGridView2.RowCount - 1, DataGridView1.SelectedCells.Item(0).Value, DataGridView1.SelectedCells.Item(1).Value)
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        Catch
        End Try
    End Sub

    Private Sub btnAllOver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllOver.Click
        Try
            Dim i As Integer
            DataGridView2.Rows.Clear()

            If DataGridView2.ColumnCount = 0 Then
                DataGridView2.Columns.Add("Kode", "Code")
                DataGridView2.Columns.Add("besk", "Description")
            End If
            For i = 0 To DataGridView2.RowCount - 1
                If DataGridView1.SelectedCells.Item(0).Value = DataGridView2.Rows(i).Cells(0).Value Then
                    MsgBox("The description was already added.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            Next i
            Do While i < Me.DataGridView1.RowCount - 1

                DataGridView2.Rows.Insert(DataGridView2.RowCount - 1, DataGridView1.Rows(i).Cells(0).Value, DataGridView1.Rows(i).Cells(1).Value)
                DataGridView1.Rows.Remove(DataGridView1.Rows(i))
                i = i + 1
            Loop
            Me.DataGridView1.RowCount = 1
            Me.DataGridView1.Refresh()
        Catch
        End Try
    End Sub
    Private Sub btnAllBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllBack.Click
        Try
            Dim i As Integer
            DataGridView1.Rows.Clear()
            If DataGridView1.ColumnCount = 0 Then
                DataGridView1.Columns.Add("Kode", "Code")
                DataGridView1.Columns.Add("besk", "Description")
            End If

            For i = 0 To DataGridView1.RowCount - 1
                If DataGridView2.SelectedCells.Item(0).Value = DataGridView1.Rows(i).Cells(0).Value Then
                    MsgBox("The description was already added.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            Next i
            Do While i < Me.DataGridView2.RowCount - 1
                DataGridView1.Rows.Insert(DataGridView1.RowCount - 1, DataGridView2.Rows(i).Cells(0).Value, DataGridView2.Rows(i).Cells(1).Value)
                DataGridView2.Rows.Remove(DataGridView2.Rows(i))
                i = i + 1
            Loop
            Me.DataGridView2.RowCount = 1
            Me.DataGridView2.Refresh()

        Catch
        End Try
    End Sub
    Private Sub btnOneBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOneBack.Click
        Try
            Dim i As Integer
            If DataGridView1.ColumnCount = 0 Then
                DataGridView1.Columns.Add("Kode", "Code")
                DataGridView1.Columns.Add("besk", "Description")
            End If

            For i = 0 To DataGridView1.RowCount - 1
                If DataGridView2.SelectedCells.Item(0).Value = DataGridView1.Rows(i).Cells(0).Value Then
                    MsgBox("The description was already added.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            Next i
            DataGridView1.Rows.Insert(DataGridView1.RowCount - 1, DataGridView2.SelectedCells.Item(0).Value, DataGridView2.SelectedCells.Item(1).Value)
            DataGridView2.Rows.Remove(DataGridView2.CurrentRow)
        Catch
        End Try
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        If DataGridView1.SelectedRows(0).Cells(0).Value Then
            txtKode.Text = DataGridView1.SelectedRows(0).Cells(0).Value
            txtBeskrywing.Text = DataGridView1.SelectedRows(0).Cells(1).Value
        End If
    End Sub

    Private Sub txtKode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKode.TextChanged
        txtBeskrywing.Text = String.Empty
    End Sub
End Class