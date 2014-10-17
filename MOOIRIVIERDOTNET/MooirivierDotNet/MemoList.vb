Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports DAL
Imports VB = Microsoft.VisualBasic
Friend Class MemoList
    Inherits BaseForm
    Public intCatSelected As Integer
    Public blnaddNew As Boolean
    Public list As List(Of MemoEntity)
    'Description  : Memo for office use
    'Important info: The db field Kategorie contains the following:
    '               0: Normal memo - display white
    '               1: NB - display red
    '               2: Old previous memos - display light grey
    '               3: System memos - display purple
    Dim IntGridSorted As Integer
    Dim strSortOrder As String = "Date"
    Dim strOldsortorder As String = "Date"
    Dim strOldcolumn As String
    Dim strASC As String = "ASC"
    Dim strSortOrderDesc As String

    Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    
    Private Sub btnBesonderhede_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnBesonderhede.Click
        'Check if detail row was selected and display details

        If Not IsNothing(dgvMemo.SelectedCells(1).Value) Then
            blnaddNew = False
            ' Andriette 12/04/2013 verander die datum terug na oorspronklike formaat
            'MemoListDetail.txtDatumVerander.Text = gridMemo.SelectedCells(4).Value
            LoadFields()
            MemoListDetail.ShowDialog()
        Else
            MsgBox("First choose an entry which details should be displayed.", MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub btnHelp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnHelp.Click
        Dim message As Object
        message = "Memo." & Chr(10) & Chr(10)
        message = message & Chr(149) & "  Sort column by clicking the heading of the column" & Chr(10)
        message = message & Chr(149) & "  To view details, click on the entry" & Chr(10)
        message = message & Chr(149) & "  The displayed user is the user that did the last change " & Chr(10)
        MsgBox(message, MsgBoxStyle.Information)
    End Sub
    Private Sub btnPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnPrint.Click
        'Dim rptSubheading As String
        MemolistReportViewer.Show()
        'rptSubheading = Form1.TITEL.Text & " " & Persoonl.Fields("voorl").Value & " " & Persoonl.Fields("versekerde").Value & " (" & Persoonl.Fields("polisno").Value & ")"
        'letterhead_printRS("Memo - vir kantoor gebruik", rptSubheading, rsMemoList, formattingArray)
    End Sub
    Sub UpdateMemo()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@pkMemo", SqlDbType.Int), _
                                                 New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                 New SqlParameter("@Gebruiker", SqlDbType.NVarChar), _
                                                 New SqlParameter("@DatumToegevoer", SqlDbType.DateTime), _
                                                 New SqlParameter("@Kategorie", SqlDbType.Int), _
                                                 New SqlParameter("@Beskrywing", SqlDbType.NVarChar), _
                                                 New SqlParameter("@Deleted", SqlDbType.Int), _
                                                 New SqlParameter("@DatumVerander", SqlDbType.DateTime)}

                If blnaddNew Then
                    params(0).Value = DBNull.Value
                Else
                    params(0).Value = dgvMemo.SelectedCells(0).Value
                End If

                params(1).Value = Persoonl.POLISNO
                params(2).Value = dgvMemo.SelectedCells(7).Value
                params(3).Value = dgvMemo.SelectedCells(4).Value

                'Only change category to NB when necessary
                If blnaddNew = False Then
                    If dgvMemo.SelectedCells(8).Value <> 1 And dgvMemo.SelectedCells(8).Value <> 3 Then
                        If MemoListDetail.chkNB.Checked = True Then
                            params(4).Value = 1
                        Else
                            params(4).Value = 0
                        End If
                    End If
                Else
                    If MemoListDetail.chkNB.Checked = True Then
                        params(4).Value = 1
                    Else
                        params(4).Value = 0
                    End If
                End If

                params(5).Value = MemoListDetail.txtBeskrywing.Text
                params(6).Value = 0
                params(7).Value = Now

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.InsertMemo", params)

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Sub UpdateMemoWhenReminderDeleted()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@pkMemo", SqlDbType.Int), _
                                                New SqlParameter("@Deleted", SqlDbType.Int)}
                params(0).Value = dgvMemo.SelectedCells(1).Value
                params(1).Value = 1
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateMemoForReminderDeleted", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Sub DeleteReminder()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params As New SqlParameter("@fkMemo", SqlDbType.Int)

                If params.Value = CInt(dgvMemo.SelectedCells(1).Value) Then
                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[DeleteReminder]", params)
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

    End Sub

    Private Sub btnVerwyder_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnVerwyder.Click
        'Andriette 15/08/2014 gee dit ;n waarde sodat die warning weg gaan
        Dim strmemo As String = ""
        Try

            'Check if detail row was selected -> set deleted
            If Not IsNothing(dgvMemo.SelectedCells(1).Value) Then
                strmemo = dgvMemo.SelectedCells(6).Value.trim
                If MsgBox("Are you sure you want to delete the entry?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    'Update memo
                    UpdateMemoWhenReminderDeleted()

                    'Remove all reminders for this item
                    DeleteReminder()
                Else
                    ' MsgBox("Select an entry to remove.", MsgBoxStyle.Exclamation)
                End If
            End If
            'Andriette 26/05/2014 verander die beskrywing
            If Persoonl.TAAL = 0 Then
                UpdateWysig((39), "Verwyder Kantoor Memo inskrywing ( " & strmemo & " )")
            Else
                UpdateWysig((39), "Remove Office Memo entry ( " & strmemo & " )")
            End If

            'Repopulate grid
            populateGridDesc()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub btnVoegBy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnVoegBy.Click
        ' pkMemoSelected = 0
        MemoListDetail.Refresh()
        MemoListDetail.txtBeskrywing.Text = ""
        MemoListDetail.txtBeskrywing.Enabled = True
        MemoListDetail.chkNB.Enabled = True
        MemoListDetail.chkNB.Checked = False
        MemoListDetail.txtDatum.Text = Now
        MemoListDetail.txtDatumVerander.Text = Now
        MemoListDetail.txtGebruiker.Text = Gebruiker.Name
        MemoListDetail.chkNB.CheckState = System.Windows.Forms.CheckState.Unchecked
        MemoListDetail.chkRemindMe.Checked = False
        blnaddNew = True
        MemoListDetail.ShowDialog()
    End Sub

    Private Sub MemoList_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        'Refresh()

        populateGridDesc()

        intCatSelected = 0
        Me.Text = "Office Memo - " & Form1.TITEL.Text & " " & Persoonl.VOORL & " " & Persoonl.VERSEKERDE & " (" & Persoonl.POLISNO & ")"

        If Persoonl.TITEL = "Besigtig" Then
            Me.btnVerwyder.Enabled = False
        End If
        strASC = "ASC"
        Me.btnClose.Focus()

    End Sub
    'Populate grid with records from database
    Public Sub populateGrid()
        'Dim row As DataGridViewRow = Me.gridMemo.RowTemplate
        'row.Height = 20
        'row.MinimumHeight = 10

        Try
            ' Andriette 06/03/2013 Verander die formaat van die datum sodat dit gesorteer kan word

            dgvMemo.DataBindings.Clear()
            dgvMemo.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvMemo.ReadOnly = True
            dgvMemo.AutoGenerateColumns = False
            dgvMemo.Columns(6).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            strASC = "DESC"
            list = FetchMemoList(Persoonl.POLISNO)
            If strSortOrder = "Date" Then
                list.Sort(AddressOf sortDatum)
            ElseIf strSortOrder = "Description" Then
                list.Sort(AddressOf sortBeskrywing)
            ElseIf strSortOrder = "User" Then
                list.Sort(AddressOf sortGebruiker)
            End If

            dgvMemo.DataSource = list

            strASC = "DESC"
        Catch ex As Exception
        End Try
    End Sub
    Public Sub populateGridDesc()
        '  Dim row As DataGridViewRow = Me.gridMemo.RowTemplate

        Try
            dgvMemo.DataBindings.Clear()
            dgvMemo.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvMemo.ReadOnly = True
            dgvMemo.AutoGenerateColumns = False
            dgvMemo.Columns(6).DefaultCellStyle.WrapMode = DataGridViewTriState.True

            ' row.MinimumHeight = 10
            ' row.DefaultCellStyle.BackColor = Color.Red
            'gridMemo.Columns(3).DefaultCellStyle.Format = "yyyy/mm/dd"
            list = FetchMemoList(Persoonl.POLISNO)
            If strSortOrder = "Date" Then
                list.Sort(AddressOf sortDatumDesc)
            ElseIf strSortOrder = "Description" Then
                list.Sort(AddressOf sortBeskrywingDesc)
            ElseIf strSortOrder = "User" Then
                list.Sort(AddressOf sortGebruikerDesc)
            End If

            dgvMemo.DataSource = list
            strASC = "ASC"
        Catch ex As Exception
        End Try
    End Sub

    Private Shared Function sortDatum(ByVal x As MemoEntity, ByVal y As MemoEntity) As Integer ' Ascending
        'Andriette 02/05/2013 sorteer op die veld wat die datum jaar eerste vertoon

        ' Return x.DatumVerander.CompareTo(y.DatumVerander)
        Return x.DatumJaarEerste.CompareTo(y.DatumJaarEerste)
    End Function
    Private Shared Function sortBeskrywing(ByVal x As MemoEntity, ByVal y As MemoEntity) As Integer ' Ascending
        Return x.Beskrywing.CompareTo(y.Beskrywing)
    End Function
    Private Shared Function sortGebruiker(ByVal x As MemoEntity, ByVal y As MemoEntity) As Integer ' Ascending
        Return x.Gebruiker.CompareTo(y.Gebruiker)
    End Function
    Private Shared Function sortDatumDesc(ByVal x As MemoEntity, ByVal y As MemoEntity) As Integer ' Descending
        ' Andriette 02/05/2013 sorteer op die veld wat die jaar eerste vertoon
        'Return y.DatumVerander.CompareTo(x.DatumVerander)
        Return y.DatumJaarEerste.CompareTo(x.DatumJaarEerste)
    End Function
    Private Shared Function sortBeskrywingDesc(ByVal x As MemoEntity, ByVal y As MemoEntity) As Integer ' Descending
        Return y.Beskrywing.CompareTo(x.Beskrywing)
    End Function
    Private Shared Function sortGebruikerDesc(ByVal x As MemoEntity, ByVal y As MemoEntity) As Integer 'Descending
        Return y.Gebruiker.CompareTo(x.Gebruiker)
    End Function

    Private Sub gridMemo_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        btnBesonderhede_Click(btnBesonderhede, New System.EventArgs())
    End Sub

    Private Sub gridMemo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvMemo.Click

        If dgvMemo.SelectedCells(8).Value = 1 Then
            Me.btnVerwyder.Enabled = False
            Me.btnBesonderhede.Enabled = True
        Else
            Me.btnVerwyder.Enabled = True
            Me.btnBesonderhede.Enabled = True
        End If

    End Sub


    Private Sub gridMemo_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) _
                Handles dgvMemo.ColumnHeaderMouseClick

        If strOldsortorder <> dgvMemo.Columns(e.ColumnIndex).HeaderText Then
            If dgvMemo.Columns(e.ColumnIndex).HeaderText = "Date" Then
                strSortOrder = dgvMemo.Columns(e.ColumnIndex).HeaderText
                list.Sort(AddressOf sortDatumDesc)
                strASC = "DESC"
            ElseIf dgvMemo.Columns(e.ColumnIndex).HeaderText = "User" Then
                list.Sort(AddressOf sortGebruiker)
                strASC = "ASC"
            ElseIf dgvMemo.Columns(e.ColumnIndex).HeaderText = "Description" Then
                list.Sort(AddressOf sortBeskrywing)
                strASC = "ASC"
            End If

        Else
            If strASC = "ASC" Then
                strASC = "DESC"
                strSortOrder = dgvMemo.Columns(e.ColumnIndex).HeaderText
                If dgvMemo.Columns(e.ColumnIndex).HeaderText = "Date" Then
                    list.Sort(AddressOf sortDatumDesc)
                ElseIf dgvMemo.Columns(e.ColumnIndex).HeaderText = "User" Then
                    list.Sort(AddressOf sortGebruikerDesc)
                ElseIf dgvMemo.Columns(e.ColumnIndex).HeaderText = "Description" Then
                    list.Sort(AddressOf sortBeskrywingDesc)
                End If
            Else
                If dgvMemo.Columns(e.ColumnIndex).HeaderText = "Date" Then
                    list.Sort(AddressOf sortDatum)
                ElseIf dgvMemo.Columns(e.ColumnIndex).HeaderText = "User" Then
                    list.Sort(AddressOf sortGebruiker)
                ElseIf dgvMemo.Columns(e.ColumnIndex).HeaderText = "Description" Then
                    list.Sort(AddressOf sortBeskrywing)
                End If
                strASC = "ASC"
            End If
        End If
        strOldsortorder = dgvMemo.Columns(e.ColumnIndex).HeaderText
        dgvMemo.Refresh()

    End Sub
    Private Sub dataGridView1_DataBindingComplete(ByVal sender As Object, ByVal e As DataGridViewBindingCompleteEventArgs) _
    Handles dgvMemo.DataBindingComplete
        Dim row As DataGridViewRow = Me.dgvMemo.RowTemplate

        For I = 0 To dgvMemo.RowCount - 1
            If dgvMemo.Rows(I).Cells(8).Value = 1 Then
                dgvMemo.Rows(I).Cells(0).Style.BackColor = Color.Red
            ElseIf dgvMemo.Rows(I).Cells(8).Value = 2 Then
                dgvMemo.Rows(I).Cells(0).Style.BackColor = Color.Gray
            ElseIf dgvMemo.Rows(I).Cells(8).Value = 3 Then
                dgvMemo.Rows(I).Cells(0).Style.BackColor = Color.Purple
            End If
            dgvMemo.Rows(I).Cells(6).Value.ToString.ToLower()

        Next
        'gridMemo.Columns(3).DefaultCellStyle.Format = "yyyy/mm/dd"

        'row.Height = 10
        row.MinimumHeight = 10
        row.Resizable = DataGridViewTriState.True
        dgvMemo.Columns(6).DefaultCellStyle.WrapMode = DataGridViewTriState.True

    End Sub

    Private Sub gridMemo_CellContentDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMemo.CellContentDoubleClick
        'Check if detail row was selected and display details

        If Not IsNothing(dgvMemo.SelectedCells(1).Value) Then
            LoadFields()
            MemoListDetail.ShowDialog()
        Else
            MsgBox("First choose an entry which details should be displayed.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub LoadFields()
        'Dim strDag As String
        'Dim strMaand As String
        'Dim strDatum As String
        'Dim StrJaar As String
        'Dim strNewDate As String
        'Dim strTyd As String
        blnaddNew = False
        MemoListDetail.txtBeskrywing.Text = dgvMemo.SelectedCells(6).Value
        MemoListDetail.txtDatum.Text = dgvMemo.SelectedCells(3).Value
        ' Andriette 12/04/2013 verander die formaat terug na dd/mm/yyyy + time
        MemoListDetail.txtDatumVerander.Text = dgvMemo.SelectedCells(4).Value
        'strDatum = gridMemo.SelectedCells(4).Value
        'StrJaar = strDatum.Substring(0, 4)
        'strMaand = strDatum.Substring(5, 2)
        'strDag = strDatum.Substring(8, 2)
        'strTyd = strDatum.Substring(12, 8)
        'strNewDate = strDag & "/" & strMaand & "/" & StrJaar & " " & strTyd

        'MemoListDetail.txtDatumVerander.Text = strNewDate
        MemoListDetail.txtGebruiker.Text = dgvMemo.SelectedCells(7).Value
        If dgvMemo.SelectedCells(8).Value = 1 Then
            MemoListDetail.chkNB.Checked = True
            MemoListDetail.chkNB.Enabled = False
            MemoListDetail.txtBeskrywing.Enabled = False
        Else
            MemoListDetail.chkNB.Checked = False
            MemoListDetail.chkNB.Enabled = True
            MemoListDetail.txtBeskrywing.Enabled = True
        End If
    End Sub
End Class