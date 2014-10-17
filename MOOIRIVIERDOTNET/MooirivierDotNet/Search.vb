Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Data.SqlClient
Imports DAL


Friend Class Search
    Inherits BaseForm
    Public searchCri As Boolean
    'Description: A search tool - search specific policies according to criteria specified generate a list of records to print
    Dim sSql As String
    Dim formattingArray() As String 'Array used to define formatting for fields select, width etc.
    'first dimension=db fieldname, 2nd = displayname, 3rd = colwidth (1 unit = width of a character)
    Private Sub btnBanke_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        BnkCodes.txtFormToPopulate.Text = Me.Name
        BnkCodes.ShowDialog()
    End Sub
    Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnHelp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim message As Object
        message = "Detail search - Help" & Chr(13) & Chr(13)
        message = message & "'Check' the fields on the report to appear" & Chr(13)
        message = message & "Specify the criteria by which the report must be created" & Chr(13)
        message = message & "'Click' 'Search' to generate the report..." & Chr(13) & Chr(13)
        message = message & "ID number" & Chr(13) & "  ##10 all the people looking in October birthday" & Chr(13) & "  ##1026 all the people looking on Oct. 26 birthday"
        message = message & ""
        MsgBox(message, MsgBoxStyle.Information)
    End Sub

    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        SearchReportViewer.Show()
        If searchCri = True Then
            SearchReportViewer.Show()
        Else
            Me.cmbBemarker.SelectedIndex = 0
            Me.cmbBybetaling.SelectedIndex = 0
            Me.cmbPosbestemming.SelectedIndex = 0
            Me.cmbStatus.SelectedIndex = 0
            Me.cmbTaal.SelectedIndex = 0
            Me.cmbTitel.SelectedIndex = 0
            Me.lstArea.SelectedIndex = 0
            Me.cmbOrderby.SelectedIndex = 0
            Me.cmbOrder.SelectedIndex = 0
            Me.cmbBet_wyse.SelectedIndex = 0
            Me.cmbAccType.SelectedIndex = 0
            Me.cmbEpos.SelectedIndex = 0
            Me.txtBank.Text = ""
            Me.txtBranch.Text = ""
            Me.txtBranchCode.Text = ""
            Me.txtID.Text = ""
            Me.txtPkBnkCodes.Text = ""
            Me.txtPoskode.Text = ""
            Me.txtStad.Text = ""
            Me.txtVanneTot.Text = ""
            Me.txtVanneVanaf.Text = ""
            Me.txtVoorl.Text = ""
            Me.txtVoorstad.Text = ""
            Exit Sub

        End If


        'Execute the search
        'Build sql statement
        'sSql = BuildSQL
        'rsPersoonl = pol.OpenRecordset(sSql)

        'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        'Generate list of records
        'If Not (rsPersoonl.EOF And rsPersoonl.BOF) Then
        '    If rsPersoonl.RecordCount >= 1 Then
        '        letterhead_printRS("Detail polis verslag", buildSubheading(), rsPersoonl, formattingArray)
        '    End If
        'Else
        '    MsgBox("There were no policies that meet the criteria yet.", MsgBoxStyle.Information)
        '    Exit Sub
        'End If

    End Sub

    Private Sub btnPostalCodes_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        PoskodesSoek.txtFormToPopulate.Text = Me.Name
        PoskodesSoek.ShowDialog()
    End Sub

    Private Sub chkField_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = chkField.GetIndex(eventSender)
        Dim tmpArray As Object
        tmpArray = Split(chkField(Index).Text, ",")
        If chkField(Index).CheckState Then 'Add item to the list
            'Me.cmbOrderby.Items.Add(New VB6.ListBoxItem(tmpArray(1), Index))
        Else 'Remove the item from the list
            Me.cmbOrderby.Text = tmpArray(1)
            'Me.cmbOrderby.Items.RemoveAt((cmbOrderby.SelectedIndex))
        End If
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Me.txtPoskode.Text = ""
        Me.txtVoorstad.Text = ""
        Me.txtStad.Text = ""
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Me.txtBank.Text = ""
        Me.txtBranch.Text = ""
        Me.txtBranchCode.Text = ""
        Me.txtPkBnkCodes.Text = CStr(0)
    End Sub
    Private Sub dtpAanvangs_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

        If IsDBNull(Me.dtpAanvangs.Value) Then
            Me.dtpAanvangsTot.Enabled = False
        Else
            Me.dtpAanvangsTot.Enabled = True
        End If

    End Sub

    Private Sub Search_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

        populateCmbTitel()
        'populateLstArea()
        PopulateArea()
        populatecmb()

        'Select default values
        Me.cmbBemarker.SelectedIndex = 0
        Me.cmbBybetaling.SelectedIndex = 0
        Me.cmbPosbestemming.SelectedIndex = 0
        Me.cmbStatus.SelectedIndex = 0
        Me.cmbTaal.SelectedIndex = 0
        Me.cmbTitel.SelectedIndex = 0
        Me.lstArea.SelectedIndex = 0
        Me.cmbOrderby.SelectedIndex = 0
        Me.cmbOrder.SelectedIndex = 0
        Me.cmbBet_wyse.SelectedIndex = 0
        Me.cmbAccType.SelectedIndex = 0
        Me.cmbEpos.SelectedIndex = 0

        'Me.DTPAanvangs.Value = System.DBNull.Value

        Me.SSTab2.TabPages.Item(2).Enabled = False
        Me.SSTab2.TabPages.Item(3).Enabled = False
        Me.SSTab2.TabPages.Item(4).Enabled = False

        Me.Text = My.Application.Info.Title & " - Policy detail search"
        Me.dtpAanvangsTot.Visible = True

    End Sub

    Public Sub populateCmbTitel()

        cmbTitel.DataSource = ListTitles(Integer.Parse(Persoonl.TAAL))
        cmbTitel.DisplayMember = "Title"
        cmbTitel.SelectedItem = Persoonl.TITEL

        Me.cmbTitel.Enabled = True

    End Sub
    Sub PopulateArea()
        'lstArea.Items.Clear()

        If ListAreaDropdown.Count > 0 Then
            lstArea.DataSource = ListAreaDropdown()
        End If
    End Sub
    Public Function ListTitles(ByVal langauage As Integer) As List(Of TitleEntity)
        Dim list As List(Of TitleEntity) = New List(Of TitleEntity)

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter(PARM_Languange, SqlDbType.Int)
                param.Value = langauage
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[ListTitle]", param)


                While reader.Read()
                    If list.Count = 0 Then
                        Dim item1 As TitleEntity = New TitleEntity()
                        item1.Title = "All"
                        'item1.ID = "All"
                        list.Add(item1)
                    End If
                    Dim item As TitleEntity = New TitleEntity()

                    item.ID = reader("ID")
                    item.Title = reader("Title")

                    list.Add(item)
                End While

            End Using
        Catch ex As Exception
            MsgBox("There's error trying to connect to the database.", MsgBoxStyle.Exclamation)
        End Try
        Return list
    End Function
    Function populatecmbBemarker1() As List(Of String)
        Dim list As List(Of String) = New List(Of String)

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.Listbemarker")

                While reader.Read()
                    If list.Count = 0 Then
                        Dim item1 As BemarkerEntity = New BemarkerEntity()
                        item1.Naam = "All"
                        list.Add(item1.Naam)
                    End If
                    Dim item As BemarkerEntity = New BemarkerEntity()
                    item.Kode_bem = reader("kode_bem")
                    item.Kode_bem_num = reader("kode_bem_num")
                    item.Naam = reader("naam")
                    list.Add(item.Naam)
                End While
                Return list
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function

    Public Sub populatecmb()

        cmbBemarker.DisplayMember = "naam"
        cmbBemarker.ValueMember = "kode_bem"

        cmbBemarker.DataSource = populatecmbBemarker1()

        Me.cmbBemarker.Enabled = True

    End Sub
    'Build the sql statement according to the criteria specified
    'Andriette 14/08/2014 maak warnings reg
    'Public Function BuildSQL() As String

    '    'Dim sqlID As Object
    '    'Dim tmpArray As Object
    '    'Dim sOrderby As Object
    '    'Dim selectlist As Object
    '    'Dim tempArray As Object
    '    'Dim k As Object
    '    'Dim sqlAccType As Object
    '    'Dim sqlBankCodes As Object
    '    'Dim sqlBetaalwyse As Object
    '    'Dim sqlBemarker As Object
    '    'Dim sqlBybetaling As Object
    '    'Dim sqlAanvangs As Object
    '    'Dim sqlPostalAddress As Object
    '    'Dim sqlVoorl As Object
    '    'Dim i As Object
    '    'Dim sSql As String
    '    'Dim sqlArea As String
    '    'Dim sqlSurname As String
    '    'Dim sqlLanguage As String
    '    'Dim sqlStatus As String
    '    'Dim sqlPosbestemming As String
    '    'Dim sqlTitel As String
    '    'Dim sqlEmail As String

    '    'Build sql string according to criteria specified
    '    'If lstArea.SelectedIndex <> -1 And lstArea.SelectedIndex <> 0 Then
    '    '    For i = 0 To lstArea.Items.Count - 1
    '    '        If lstArea.GetSelected(i) Then
    '    '            sqlArea = sqlArea & "'" & VB6.GetItemString(lstArea, i) & "',"
    '    '        End If
    '    '    Next
    '    '    sqlArea = " AND area_besk in (" & VB.Left(sqlArea, Len(sqlArea) - 1) & ")"
    '    'End If

    '    ''Surname
    '    'If Me.txtVanneVanaf.Text <> "" And Me.txtVanneTot.Text <> "" Then
    '    '    sqlSurname = " AND (trim(versekerde) >= '" & Replace(Trim(Me.txtVanneVanaf.Text), "'", "''") & "' AND trim(versekerde) <= '" & Replace(Trim(Me.txtVanneTot.Text), "'", "''") & "zzzz')"
    '    'End If

    '    ''Email
    '    'Select Case Me.cmbEpos.SelectedIndex
    '    '    Case 0 'Alle
    '    '        sqlEmail = ""
    '    '    Case 1
    '    '        sqlEmail = " AND trim(email) <> ''"
    '    '    Case 2
    '    '        sqlEmail = " AND (trim(email) = '' OR isnull(email))"
    '    'End Select

    '    ''Sql for language
    '    'Select Case Me.cmbTaal.SelectedIndex
    '    '    Case 0
    '    '        sqlLanguage = ""
    '    '    Case 1 'Afr
    '    '        sqlLanguage = " AND taal = '0'"
    '    '    Case 2 'Eng
    '    '        sqlLanguage = " AND taal = '1'"
    '    '    Case Else
    '    '        sqlLanguage = ""
    '    'End Select

    '    ''Sql for status
    '    'Select Case Me.cmbStatus.SelectedIndex
    '    '    Case 0
    '    '        sqlStatus = ""
    '    '    Case 1
    '    '        sqlStatus = " AND not gekans"
    '    '    Case 2
    '    '        sqlStatus = " AND gekans"
    '    '    Case Else
    '    '        sqlStatus = ""
    '    'End Select

    '    ''Sql for posbestemming
    '    'If Me.cmbPosbestemming.SelectedIndex <> 0 And Me.cmbPosbestemming.SelectedIndex <> -1 Then '0 - alle
    '    '    sqlPosbestemming = " AND posbestemming = '" & Me.cmbPosbestemming.SelectedIndex - 1 & "'"
    '    'End If

    '    ''Titel
    '    'If Me.cmbTitel.SelectedIndex <> -1 And Me.cmbTitel.SelectedIndex <> 0 Then
    '    '    sqlTitel = " AND titelnum = " & VB6.GetItemData(Me.cmbTitel, Me.cmbTitel.SelectedIndex)
    '    'End If

    '    ''Voorletters
    '    'If Me.txtVoorl.Text <> "" Then
    '    '     sqlVoorl = " AND voorl like '" & Me.txtVoorl.Text & "*'"
    '    'End If

    '    ''ID
    '    'If Me.txtID.Text <> "" Then
    '    '     sqlVoorl = " AND id_nom like '" & Me.txtID.Text & "*'"
    '    'End If

    '    ''Postal address
    '    'If Me.txtPoskode.Text <> "" Then
    '    '    sqlPostalAddress = " AND adres2 = '" & Me.txtPoskode.Text & "'"
    '    '     sqlPostalAddress = sqlPostalAddress & " AND adres1 = '" & Me.txtStad.Text & "'"
    '    '     sqlPostalAddress = sqlPostalAddress & " AND adres3 = '" & Me.txtVoorstad.Text & "'"
    '    'End If

    '    ''Aanvangsdatum
    '    ' If Not IsDBNull(Me.DTPAanvangs.Value) Then
    '    '    sqlAanvangs = " AND (p_a_dat >= cdate('" & Me.DTPAanvangs._Value & "') AND p_a_dat <= cdate('" & Me.DTPAanvangsTot._Value & "'))"
    '    'End If

    '    ''Bybetaling
    '    'If Me.cmbBybetaling.SelectedIndex > 0 Then
    '    '    sqlBybetaling = " AND bybet_k = '" & Me.cmbBybetaling.SelectedIndex - 1 & "'"
    '    'End If

    '    ''Bemarker
    '    'If Me.cmbBemarker.SelectedIndex > 0 Then
    '    '     sqlBemarker = " AND vanwie = '" & VB6.GetItemData(Me.cmbBemarker, cmbBemarker.SelectedIndex) & "'"
    '    'End If

    '    ''Betaalwyse
    '    'If Me.cmbBet_wyse.SelectedIndex > 0 Then
    '    '     sqlBetaalwyse = " AND bet_wyse = '" & Me.cmbBet_wyse.SelectedIndex & "'"
    '    'End If

    '    ''Bankcodes
    '    'If CDbl(Me.txtPkBnkCodes.Text) <> 0 Then
    '    '     sqlBankCodes = " AND bankcodes.pkBankCodes = " & Me.txtPkBnkCodes.Text
    '    'End If

    '    ''Account types
    '    'If Me.cmbAccType.SelectedIndex > 0 Then
    '    '    sqlAccType = " AND aftrek.a_tipe = '" & cmbAccType.SelectedIndex & "'"
    '    'End If

    '    ''Build select list
    '    'k = 0
    '    'For i = 0 To Me.chkField.UBound
    '    '    If Me.chkField(i).CheckState Then
    '    '        'Redim formattingArray
    '    '        ReDim Preserve formattingArray(3, k)

    '    '        'Split checkbox caption into array
    '    '        tempArray = Split(Me.chkField(i).Text, ",")

    '    '        'Build formattingArray with checkboxes.caption
    '    '         formattingArray(0, k) = tempArray(0)
    '    '        formattingArray(1, k) = tempArray(1)
    '    '        formattingArray(2, k) = tempArray(2)
    '    '        selectlist = selectlist & tempArray(0) & ", "
    '    '         k = k + 1
    '    '    End If
    '    'Next
    '    'Remove last comma
    '    'selectlist = VB.Left(selectlist, Len(selectlist) - 2)

    '    'Build order by list
    '    'If Me.cmbOrderby.SelectedIndex = -1 Then
    '    '     sOrderby = "persoonl.polisno"
    '    'Else
    '    '      tmpArray = Split(Me.chkField(VB6.GetItemData(cmbOrderby, cmbOrderby.SelectedIndex)).Text, ",")
    '    '       sOrderby = tmpArray(0)
    '    'End If

    '    'If Me.cmbOrder.SelectedIndex = 1 Then 'Descending
    '    '     sOrderby = sOrderby & " desc"
    '    'End If

    '    ''Build sql according to criteria specified
    '    ' sSql = "SELECT " & selectlist
    '    'sSql = sSql & " FROM (((((persoonl LEFT JOIN titel On titel.titelindeks = persoonl.titelnum)"
    '    'sSql = sSql & " LEFT JOIN area ON area.area_kode = persoonl.area)"
    '    'sSql = sSql & " LEFT JOIN bemarker ON bemarker.kode_bem = persoonl.vanwie)"
    '    'sSql = sSql & " LEFT JOIN aftrek ON aftrek.polisno = persoonl.polisno)"
    '    'sSql = sSql & " LEFT JOIN bankcodes ON bankcodes.pkBankCodes = aftrek.fkBankCodes)"
    '    'sSql = sSql & " WHERE 1=1 "
    '    'sSql = sSql & sqlStatus
    '    'sSql = sSql & sqlEmail
    '    'sSql = sSql & sqlArea
    '    'sSql = sSql & sqlSurname
    '    'sSql = sSql & sqlLanguage
    '    'sSql = sSql & sqlPosbestemming
    '    'sSql = sSql & sqlTitel
    '    ' sSql = sSql & sqlVoorl
    '    'sSql = sSql & sqlID
    '    'sSql = sSql & sqlPostalAddress
    '    'sSql = sSql & sqlAanvangs
    '    'sSql = sSql & sqlBybetaling
    '    'sSql = sSql & sqlBemarker
    '    'sSql = sSql & sqlBetaalwyse
    '    ' sSql = sSql & sqlBankCodes
    '    'sSql = sSql & sqlAccType
    '    ' sSql = sSql & " ORDER BY " & sOrderby
    '    'BuildSQL = sSql
    'End Function
    'Build the subheading for report according to criteria selected

    Public Function buildSubheading() As String

        Dim sAreas As Object = ""
        Dim i As Object
        Dim subheading As String

        subheading = "("

        'Vanne
        If Me.txtVanneVanaf.Text <> "" Then
            subheading = subheading & "Vanne:" & Me.txtVanneVanaf.Text & " tot " & Me.txtVanneTot.Text & "; "
        End If

        'Area
        If Me.lstArea.SelectedIndex <> -1 And Me.lstArea.SelectedIndex <> 0 Then
            For i = 0 To Me.lstArea.Items.Count - 1
                If Me.lstArea.GetSelected(i) Then
                    'sAreas = sAreas & VB6.GetItemString(Me.lstArea, i) & ","
                    sAreas = sAreas & VB.GetChar(Me.lstArea.SelectedItem, i) & ","
                End If
            Next
            sAreas = VB.Left(sAreas, Len(sAreas) - 1) 'Remove last comma
            subheading = subheading & "Area:" & sAreas & "; "
        End If

        'Voorletters
        If Me.txtVoorl.Text <> "" Then
            subheading = subheading & "Voorletters:" & Me.txtVoorl.Text & "; "
        End If

        'Titel
        If Me.cmbTitel.SelectedIndex <> 0 Then
            subheading = subheading & "Titel:" & Me.cmbTitel.Text & "; "
        End If

        'ID
        If Me.txtID.Text <> "" Then
            subheading = subheading & "ID:" & Me.txtID.Text & "; "
        End If

        'Posbestemming
        If Me.cmbPosbestemming.SelectedIndex <> 0 Then
            subheading = subheading & "Posbestemming:" & Me.cmbPosbestemming.Text & "; "
        End If

        'Posadres
        If Me.txtPoskode.Text <> "" Then
            subheading = subheading & "Posadres:" & Me.txtVoorstad.Text & "," & Me.txtStad.Text & "," & Me.txtPoskode.Text & "; "
        End If

        'Aanvangsdatum
        If Not IsDBNull(Me.DTPAanvangs.Value) Then
            subheading = subheading & "Aanvangs datum:" & Me.DTPAanvangs.Value & " tot " & Me.DTPAanvangsTot.Value & "; "
        End If

        'Bybetaling
        If Me.cmbBybetaling.SelectedIndex <> 0 Then
            subheading = subheading & "Bybetaling:" & Me.cmbBybetaling.Text & "; "
        End If

        'Bemarker
        If Me.cmbBemarker.SelectedIndex <> 0 Then
            subheading = subheading & "Bemarker:" & Me.cmbBemarker.Text & "; "
        End If

        'Taal
        If Me.cmbTaal.SelectedIndex <> 0 Then
            subheading = subheading & "Taal:" & Me.cmbTaal.Text & "; "
        End If

        'Status
        If Me.cmbStatus.SelectedIndex <> 0 Then
            subheading = subheading & "Status:" & Me.cmbStatus.Text & "; "
        End If

        'Email
        If Me.cmbEpos.SelectedIndex <> 0 Then
            subheading = subheading & "E-pos:" & Me.cmbEpos.Text & "; "
        End If

        'Betaalwyse
        If Me.cmbBet_wyse.SelectedIndex <> 0 Then
            subheading = subheading & "Betaalwyse:" & Me.cmbBet_wyse.Text & "; "
        End If

        'Banking
        If CDbl(Me.txtPkBnkCodes.Text) <> 0 Then
            subheading = subheading & "Bank:" & Me.txtBank.Text & " " & Me.txtBranch.Text & "; "
        End If

        'Betaalwyse
        If Me.cmbAccType.SelectedIndex > 0 Then
            subheading = subheading & "Rekeningtipe:" & Me.cmbAccType.Text & "; "
        End If

        'Order by
        If Me.cmbOrderby.SelectedIndex <> -1 Then
            subheading = subheading & "Sorteer volgens:" & Me.cmbOrderby.Text & "(" & Me.cmbOrder.Text & ")"
        End If

        subheading = subheading & ")"

        buildSubheading = subheading
    End Function

    Private Sub dtpAanvangs_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpAanvangs.ValueChanged
        If Me.dtpAanvangs.Checked = True Then
            Me.dtpAanvangsTot.Enabled = True
        Else
            Me.dtpAanvangsTot.Enabled = False

        End If
    End Sub


End Class