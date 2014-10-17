Option Strict Off
Option Explicit On

Imports System.Data.SqlClient
Imports DAL

Friend Class VoertuigSearch
    Inherits BaseForm

    'Description  : A search engine for vehicles
    'Modification : Add 'Druk hierdie lys' button with functionality
    Dim makeSelected As String
    Dim descSelected As String
    Dim YearSelected As String
    Dim CodeSelected As String
    Dim tradinSelected As String
    Dim newSelected As String
    Dim sellSelected As String
    Dim endSelected As String
    Dim marketSelected As String
    Dim typeSelected As String
    Dim i As Short
    Dim sSql As String
    Dim formattingArray() As String ' For printing recordset
    Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click

        Me.Close()
        ClearSearch()

    End Sub
    'Button clear clicked
    Private Sub btnClear_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClear.Click
        'Clear txtboxes and grid
        DataGridView1.DataSource = Nothing
        Me.txtKode.Text = ""
        Me.txtBesk.Text = ""
        Me.txtMaak.Text = ""
        Me.cmbJaar.SelectedIndex = -1
        Me.lblTotal.Text = ""
        Label3.Text = "Number found:"

        'Me.MSFlexGrid1.row = 0
        Me.txtMaak.Focus()

        'disable print button
        Me.btnPrint.Enabled = False
    End Sub
    Public Sub populateGrid()
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.DataSource = ListMontorDetails()

    End Sub

    Function ListMontorDetails() As List(Of MontorEntity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim param() As SqlParameter = {New SqlParameter("@Fabrikaat", SqlDbType.NVarChar), _
                                               New SqlParameter("@ModelBeskrywing", SqlDbType.NVarChar), _
                                               New SqlParameter("@Jaar", SqlDbType.NVarChar), _
                                               New SqlParameter("@Kode", SqlDbType.NVarChar)}

                If Me.txtMaak.Text = "" Then
                    param(0).Value = DBNull.Value
                Else
                    param(0).Value = Me.txtMaak.Text
                End If

                If Me.txtBesk.Text = "" Then
                    param(1).Value = DBNull.Value
                Else
                    param(1).Value = Me.txtBesk.Text
                End If

                If Me.cmbJaar.SelectedItem = "" Then
                    param(2).Value = DBNull.Value
                Else
                    param(2).Value = Me.cmbJaar.SelectedItem
                End If

                If Me.txtKode.Text = "" Then
                    param(3).Value = DBNull.Value
                Else
                    param(3).Value = Me.txtKode.Text
                End If

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.ReportFetchMontorDetails", param)

                Dim list As List(Of MontorEntity) = New List(Of MontorEntity)
                While reader.Read()
                    Dim item As MontorEntity = New MontorEntity()

                    If Not IsDBNull(reader("TIPE")) Then
                        item.TIPE = reader("TIPE")
                    End If
                    If Not IsDBNull(reader("Fabrikaat")) Then
                        item.Fabrikaat = reader("Fabrikaat")
                    End If
                    If Not IsDBNull(reader("Model beskrywing")) Then
                        item.Model_beskrywing = reader("Model beskrywing")
                    End If
                    If Not IsDBNull(reader("Jr")) Then
                        item.Jr = reader("Jr")
                    End If
                    If Not IsDBNull(reader("Inruil")) Then
                        item.Inruil_R = reader("Inruil")
                    End If
                    If Not IsDBNull(reader("Koop")) Then
                        item.Koop_R = reader("Koop")
                    End If
                    If Not IsDBNull(reader("Nuut")) Then
                        item.Nuut_R = reader("Nuut")
                    End If
                    If Not IsDBNull(reader("Mark")) Then
                        item.Mark_R = reader("Mark")
                    End If
                    If Not IsDBNull(reader("KODE")) Then
                        item.KODE = reader("KODE")
                    End If
                    If Not IsDBNull(reader("Cyl")) Then
                        item.Cyl = reader("Cyl")
                    End If
                    If Not IsDBNull(reader("CC")) Then
                        item.CC = reader("CC")
                    End If
                    
                    If Not IsDBNull(reader("Begin")) Then
                        item.Begin = reader("Begin")
                    End If

                    If Not IsDBNull(reader("Einde")) Then
                        item.Einde = reader("Einde")
                    End If
                    list.Add(item)
                End While

                Return list
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function
    'Button ok clicked
    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
       
        If btnOk.Enabled Then

            If DataGridView1.Rows().Count > 0 Then

                '	'Set variables according to selection
                'Me.MSFlexGrid1.col = 0
                typeSelected = DataGridView1.SelectedCells.Item(0).Value
                ' Me.MSFlexGrid1.col = 1
                makeSelected = DataGridView1.SelectedCells.Item(1).Value
                '	Me.MSFlexGrid1.col = 2
                descSelected = DataGridView1.SelectedCells.Item(2).Value
                '	Me.MSFlexGrid1.col = 3
                YearSelected = DataGridView1.SelectedCells.Item(3).Value
                '	Me.MSFlexGrid1.col = 4
                tradinSelected = DataGridView1.SelectedCells.Item(4).Value
                '	Me.MSFlexGrid1.col = 5
                sellSelected = DataGridView1.SelectedCells.Item(5).Value
                '	Me.MSFlexGrid1.col = 6
                newSelected = DataGridView1.SelectedCells.Item(6).Value
                '	Me.MSFlexGrid1.col = 7
                marketSelected = DataGridView1.SelectedCells.Item(7).Value
                '	Me.MSFlexGrid1.col = 8
                CodeSelected = DataGridView1.SelectedCells.Item(8).Value
                '	Me.MSFlexGrid1.col = 12
                endSelected = DataGridView1.SelectedCells.Item(12).Value

                'If makeSelected = "" Then
                '    MsgBox("A specific motor must be selected to continue.", MsgBoxStyle.Exclamation)
                '    Exit Sub
                'Else
                'Populate caller form with selected values
                'Select vehicle type
                Select Case typeSelected
                    Case "1"
                        VoertuigDetail.cmbTipe.SelectedIndex = 0
                    Case "2"
                        VoertuigDetail.cmbTipe.SelectedIndex = 1
                    Case "6"
                        VoertuigDetail.cmbTipe.SelectedIndex = 5
                    Case Else
                        VoertuigDetail.cmbTipe.SelectedIndex = -1
                End Select

                VoertuigDetail.txtMaak.Text = makeSelected
                VoertuigDetail.txtJaar.Text = YearSelected
                VoertuigDetail.txtBesk.Text = descSelected
                VoertuigDetail.txtKode.Text = CodeSelected
                VoertuigDetail.txtEindDatum.Text = endSelected
                VoertuigDetail.txtValueMarket.Text = marketSelected
                VoertuigDetail.txtNuut.Text = newSelected
                VoertuigDetail.txtKoop.Text = sellSelected
                VoertuigDetail.txtInruil.Text = tradinSelected
                VoertuigDetail.txtAnder.Text = CStr(False)
                Me.Close()
                ' DataGridView1.Rows.Clear()       'Kobus
            Else
                MsgBox("A specific motor must be selected to continue.", MsgBoxStyle.Exclamation)
                'DataGridView1.Rows.Clear()
                Exit Sub
            End If
        End If
        ClearSearch()
    End Sub
    Private Sub ClearSearch()    'Kobus Visser - 26/02/2013 - clear frm VoertuigSearch.vb na OK Button Click
        'Clear txtboxes and grid
        DataGridView1.DataSource = Nothing
        Me.txtKode.Text = ""
        Me.txtBesk.Text = ""
        Me.txtMaak.Text = ""
        Me.cmbJaar.SelectedIndex = -1
        Me.lblTotal.Text = ""
        Label3.Text = "Number found:"

        'disable print button
        Me.btnPrint.Enabled = False
    End Sub


    Private Sub btnPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnPrint.Click
        'Dim rptSubheading As String
        MotorsReportViewer.Show()
        'rptSubheading = "Fabrikaat: " & Me.txtMaak.Text & "; Model beskrywing: " & Me.txtBesk.Text & "; Jaar model: " & Me.cmbJaar.Text & "; Kode: " & Me.txtKode.Text
        'letterhead_printRS("Mead & McGrouther motorwaardes", rptSubheading, rsMotors, formattingArray)
    End Sub

    'Button search clicked
    Private Sub btnSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSearch.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.lblTotal.Text = "Searching..."

        Me.Refresh()

        populateGrid()

        If DataGridView1.Rows.Count >= 1 Then
            btnPrint.Enabled = True
        Else
            btnPrint.Enabled = False
        End If

        Dim rowCount As Integer
        rowCount = DataGridView1.RowCount
        Me.lblTotal.Text = "Number found: " & rowCount
        Label3.Text = "Number found: " & rowCount


        Me.Cursor = System.Windows.Forms.Cursors.Default

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub VoertuigSearch_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Text = "      Vehicle - Mead and MacGrouther Values"

        Me.DataGridView1.ReadOnly = True
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        btnPrint.Enabled = False
        'Populate dropdown year
        'Add blank item
        Me.cmbJaar.Items.Clear()
        Me.cmbJaar.Items.Add("")
        'Only display the last 15 years' vehicles
        For Me.i = Year(Now) To Year(Now) - 14 Step -1
            Me.cmbJaar.Items.Add(CStr(i))
        Next

        'Select the first item (Blank)
        Me.cmbJaar.SelectedIndex = 0

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub VoertuigSearch_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'rsMotors = Nothing
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub
End Class