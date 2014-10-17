Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports DAL

Friend Class VerwyderdeItemLys
    Inherits BaseForm

    'Description: Form listing all vehicles removed from policy
    '           : User will be able to restore selected vehicle
    Dim strNPlaatSelected As String
    Dim strpkSelected As String
    Dim strfabrikaatSelected As String
    Dim strmodelSelected As String
    Dim intRow_tel As Integer
    '  Dim sSql As String
    Dim strAdresHuis As String
    Dim strTipeAr As String
    '  Dim intRyCount As Integer

    Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    'Andriette 29/01/2014 hierdie funksie word nie meer gebruik nie
    'Sub InsertIntoA_VOERTUIG()
    '    Try
    '        Using conn As SqlConnection = SqlHelper.GetConnection
    '            'Andriette verander om al die parameters te neem en die inskrywing korrek te voltooi

    '            Dim params() As SqlParameter = {New SqlParameter("@KODE", SqlDbType.NVarChar), _
    '                                            New SqlParameter("@JAAR", SqlDbType.NVarChar), _
    '                                            New SqlParameter("@MAAK", SqlDbType.NVarChar), _
    '                                            New SqlParameter("@BESK", SqlDbType.NVarChar), _
    '                                            New SqlParameter("@EEU", SqlDbType.NVarChar), _
    '                                            New SqlParameter("@TIPE", SqlDbType.NVarChar)}

    '            params(0).Value = GridVerwyderdeVoertuie.SelectedRows(0).Cells(12).Value
    '            params(1).Value = GridVerwyderdeVoertuie.SelectedRows(0).Cells(3).Value.ToString.Substring(2, 2)
    '            params(2).Value = GridVerwyderdeVoertuie.SelectedRows(0).Cells(1).Value
    '            params(3).Value = GridVerwyderdeVoertuie.SelectedRows(0).Cells(2).Value
    '            params(4).Value = GridVerwyderdeVoertuie.SelectedRows(0).Cells(3).Value.ToString.Substring(0, 2)
    '            params(5).Value = GridVerwyderdeVoertuie.SelectedRows(0).Cells(13).Value
    '            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.InsertIntoA_VOERTUIG", params)
    '        End Using
    '    Catch ex As Exception
    '    End Try
    'End Sub
    'Andriette 29/01/2014 hierdie funskie bestaan reeds in Poldata1
    'Sub DeleteFromA_Voertuig()
    '    Try
    '        Using conn As SqlConnection = SqlHelper.GetConnection
    '            Dim param As New SqlParameter("@KODE", SqlDbType.NVarChar)
    '            param.Value = GridVerwyderdeVoertuie.SelectedRows(0).Cells(12).Value
    '            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.DeleteFromA_Voertuig", param)
    '        End Using
    '    Catch ex As Exception
    '        'Andriette 19/08/2013 sit die catch by
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '    End Try
    'End Sub
    Sub Update_Voertuig()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@pkVoertuie", SqlDbType.Int)
                param.Value = GridVerwyderdeVoertuie.SelectedRows(0).Cells(0).Value
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdatevoertuieForPoldata]", param)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            'Andriette 19/08/2013 sit die catch by
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Sub UpdateHuisWithPrimartyKey()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@pkHuis", SqlDbType.NVarChar), _
                                          New SqlParameter("@Cancelled", SqlDbType.NVarChar)}
                params(0).Value = strpkSelected
                params(1).Value = False
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateHuisWithPrimartyKey", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            'Andriette 19/08/2013 sit die catch by
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    
    Public Sub UpdateAlleRiskWithPrimaryKey()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@pkAllerisk", SqlDbType.Int)}
                params(0).Value = GridVerwyderdeVoertuie.SelectedRows(0).Cells(0).Value
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateAlleRiskWithPrimaryKey", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            'Andriette 19/08/2013 sit die catch by
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    ' Make use of pk instead of code
    ' Only vehicles will be restored due to data integrity not existing on pty
    '  !!!!!  Not in use - would be used te restore an old record to the system - decided against it
    Private Sub btnHerstel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnHerstel.Click
        'Me.GridVerwyderdeVoertuie.Col = 0
        strpkSelected = Me.GridVerwyderdeVoertuie.SelectedCells.Item(0).Value
        If strpkSelected <> "kode" Then
            If MsgBox("Are you sure you want to restore this item to the policy?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Select Case intPoldataGrid_Focus
                    Case 1 ' Voertuie
                        'Andriette 15/08/2013 verander die offset vanuit die grid, was verkeerd
                        'NPlaatSelected = Me.GridVerwyderdeVoertuie.SelectedCells.Item(1).Value

                        'fabrikaatSelected = Me.GridVerwyderdeVoertuie.SelectedCells.Item(2).Value

                        'modelSelected = Me.GridVerwyderdeVoertuie.SelectedCells.Item(3).Value

                        strNPlaatSelected = Me.GridVerwyderdeVoertuie.SelectedCells.Item(4).Value
                        strfabrikaatSelected = Me.GridVerwyderdeVoertuie.SelectedCells.Item(1).Value
                        strmodelSelected = Me.GridVerwyderdeVoertuie.SelectedCells.Item(2).Value
                        'Andriette 29/01/2014 hierdie skuif van transaksie van die verwyderdea_voertuig na
                        ' a_voertuig word nou gedoen in een SP nie meer 2 nie
                        '    InsertIntoA_VOERTUIG()
                        'Andriette 19/08/2013 Kan nie delete uit A voertuig nie, het dit nog nodig om beskrywing etc te kry
                        Form1.DeleteFromA_Voertuig(GridVerwyderdeVoertuie.SelectedRows(0).Cells(12).Value, "Restore")
                        Form1.Updatevoertuie(strpkSelected, False)
                        ' Update_Voertuig()

                        If Persoonl.TAAL = 0 Then
                            BESKRYWING = Trim(strfabrikaatSelected) & " " & Trim(strmodelSelected) & " (" & Trim(strNPlaatSelected) & ")"
                        Else
                            BESKRYWING = Trim(strfabrikaatSelected) & " " & Trim(strmodelSelected) & " (" & Trim(strNPlaatSelected) & ")"
                        End If

                        UpdateWysig(191, BESKRYWING)
                        'Repopulate grid on form1
                        displayVehicles()
                        Form1.populate_dgvPoldataVoertuie()

                    Case 2 ' Eiendomme
                        'Me.GridVerwyderdeVoertuie.Col = 1
                        strAdresHuis = Me.GridVerwyderdeVoertuie.SelectedCells.Item(1).Value
                        'rsHUis = pol.OpenRecordset("SELECT * FROM huis where pkHuis = " & pkSelected)
                        Using conn As SqlConnection = SqlHelper.GetConnection
                            Dim param As New SqlParameter("@pkHuis", SqlDbType.Int)
                            param.Value = GridVerwyderdeVoertuie.SelectedRows(0).Cells(0).Value
                            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateHuisForPoldata", param)
                            If conn.State = ConnectionState.Open Then
                                conn.Close()
                            End If
                        End Using

                        'Update the premium
                        'Andriette 30/08/2013 skuif na onder
                        'HerBereken_Premie()
                        'doen_subtotaal()
                        'Record alteration
                        If Persoonl.TAAL = 0 Then
                            BESKRYWING = Trim(strAdresHuis)
                        Else
                            BESKRYWING = Trim(strAdresHuis)
                        End If
                        UpdateWysig(191, BESKRYWING)
                        'Repopulate grid on form1
                        Form1.populate_dgvPoldata1Eiendomme()
                    Case 3 'Alle risko
                        'Me.GridVerwyderdeVoertuie.Col = 1
                        strTipeAr = Me.GridVerwyderdeVoertuie.SelectedCells.Item(2).Value.ToString.Trim
                        ' rsAr = pol.OpenRecordset("SELECT * FROM AlleRisk WHERE pkAlleRisk = " & pkSelected)
                        ' FetchAlleriskByPrimaryKey()
                        'sSql = "UPDATE AlleRisk SET cancelled = false WHERE pkAlleRisk = " & pkSelected
                        'pol.Execute((sSql))
                        UpdateAlleRiskWithPrimaryKey()
                        'Update the premium
                        'Andriette 30/08/2013 skuif na onder
                        'HerBereken_Premie()
                        'doen_subtotaal()
                        'Record alteration
                        If Persoonl.TAAL = 0 Then
                            BESKRYWING = Trim(strTipeAr)
                        Else
                            BESKRYWING = Trim(strTipeAr)
                        End If
                        UpdateWysig(191, BESKRYWING)
                        'Repopulate grid on form1
                        Form1.populate_dgvPoldata1AlleRisikoItems()
                        Form1.dgvPoldata1AlleRisikoItems.Refresh()
                End Select
                'Andriette 30/08/2013 herbereken die premie as daar items herstel is
                'HerBereken_Premie()
                'doen_subtotaal()
            End If

            Me.Close()
        End If

    End Sub

    Private Sub VerwyderdeItemLys_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        GridVerwyderdeVoertuie.Rows.Clear()
        GridVerwyderdeVoertuie.ReadOnly = True

        GridVerwyderdeVoertuie.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        'displayVehicles()
        'displayProperties()
        ' displayAllRisks()
        'updateForm1Grid3()
        If Gebruiker.titel = "Programmeerder" Then
            Me.btnHerstel.Visible = True
        Else
            Me.btnHerstel.Visible = False
        End If
        'Set database name
        'Me.DataVerwyderdeItems.DatabaseName = pol_path & "\poldata5.mdb"
        Select Case intPoldataGrid_Focus
            Case 1 'Vehicles
                displayVehicles()
            Case 2 'Properties
                displayProperties()
            Case 3 'All risks
                displayAllRisks()
            Case Else
                MsgBox("Click on the vehicles, properties, or all risk for the deleted list items to show.", MsgBoxStyle.Information)
        End Select
        'Andriette 19/09/2013 as die gebruiker net mag besigtig maak die delete button toe

        If Gebruiker.titel = "Besigtig" Then
            btnHerstel.Enabled = False
        Else
            btnHerstel.Enabled = True
        End If
    End Sub
    Public Sub displayVehicles()
        'Set title for window
        Dim strVoertuigWaarde As String
        intRow_tel = 0
        intRow_tel = intRow_tel + 1
        'Andriette 15/08/2013 verander na die global polisnommer
        'Me.Text = My.Application.Info.Title & " - Deleted Vehicles - " & Form1.TITEL.Text & " " & Form1.VOORL.Text & " " & Form1.VERSEKERDE.Text & " (" & Form1.POLISNO.Text & ")"
        Me.Text = My.Application.Info.Title & " - Deleted Vehicles - " & Form1.TITEL.Text & " " & Form1.VOORL.Text & " " & Form1.VERSEKERDE.Text & " (" & glbPolicyNumber & ")"
        Dim item As VoertuieMotorVerwyderdeeEntity = New VoertuieMotorVerwyderdeeEntity()
        GridVerwyderdeVoertuie.AutoGenerateColumns = False
        GridVerwyderdeVoertuie.Refresh()
        GridVerwyderdeVoertuie.DataSource = Nothing
        GridVerwyderdeVoertuie.ColumnCount = 14
        GridVerwyderdeVoertuie.ColumnHeadersVisible = True
        ' Andriette 08/05/2013 verander die opskrifte
        Dim columnHeaderStyle As New DataGridViewCellStyle
        ' andriette maak die header bietjie kleiner
        columnHeaderStyle.Font = New Font("Microsoft Sans Serif", 6.5, FontStyle.Bold)
        GridVerwyderdeVoertuie.ColumnHeadersDefaultCellStyle = columnHeaderStyle
        ' Andriette 08/05/2013 maak rye kleiner
        With Me.GridVerwyderdeVoertuie.RowTemplate
            .Height = 15
            .MinimumHeight = 5
        End With
        GridVerwyderdeVoertuie.AllowUserToAddRows = False
        GridVerwyderdeVoertuie.AllowUserToDeleteRows = False
        GridVerwyderdeVoertuie.Columns(0).Name = "pkVoertuie"
        GridVerwyderdeVoertuie.Columns(0).Visible = False

        GridVerwyderdeVoertuie.Columns(1).Name = "Make"
        GridVerwyderdeVoertuie.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(1).Width = 75
        GridVerwyderdeVoertuie.Columns(1).Visible = True

        GridVerwyderdeVoertuie.Columns(2).Name = "Model Description"
        GridVerwyderdeVoertuie.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(2).Width = 200
        GridVerwyderdeVoertuie.Columns(2).Visible = True

        GridVerwyderdeVoertuie.Columns(3).Name = "Year"
        GridVerwyderdeVoertuie.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(3).Width = 40
        GridVerwyderdeVoertuie.Columns(3).Visible = True

        GridVerwyderdeVoertuie.Columns(4).Name = "Reg nr"
        GridVerwyderdeVoertuie.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(4).Width = 75
        GridVerwyderdeVoertuie.Columns(4).Visible = True

        GridVerwyderdeVoertuie.Columns(5).Name = "Colour"
        GridVerwyderdeVoertuie.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(5).Width = 75
        GridVerwyderdeVoertuie.Columns(5).Visible = True

        GridVerwyderdeVoertuie.Columns(6).Name = "Cover"
        GridVerwyderdeVoertuie.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(6).Width = 75
        GridVerwyderdeVoertuie.Columns(6).Visible = True

        GridVerwyderdeVoertuie.Columns(7).Name = "Premium"
        GridVerwyderdeVoertuie.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(7).Width = 75
        GridVerwyderdeVoertuie.Columns(7).DefaultCellStyle.Format = "C"
        GridVerwyderdeVoertuie.Columns(7).Visible = True

        GridVerwyderdeVoertuie.Columns(8).Name = "Date cancelled"
        GridVerwyderdeVoertuie.Columns(8).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(8).Width = 75
        GridVerwyderdeVoertuie.Columns(8).Visible = True

        GridVerwyderdeVoertuie.Columns(9).Name = "Motor Status"
        GridVerwyderdeVoertuie.Columns(9).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(9).Width = 75
        'Andriette 13/08/2013 moenie vertoon nie
        GridVerwyderdeVoertuie.Columns(9).Visible = False

        GridVerwyderdeVoertuie.Columns(10).Name = "Engine number"
        GridVerwyderdeVoertuie.Columns(10).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(10).Width = 100
        'Andriette 13/08/2013 moenie vertoon nie
        GridVerwyderdeVoertuie.Columns(10).Visible = False

        GridVerwyderdeVoertuie.Columns(11).Name = "Chassis"
        GridVerwyderdeVoertuie.Columns(11).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(11).Width = 100
        'Andriette 13/08/2013 moenie vertoon nie
        GridVerwyderdeVoertuie.Columns(11).Visible = False

        GridVerwyderdeVoertuie.Columns(12).Name = "KODE"
        GridVerwyderdeVoertuie.Columns(12).Visible = False
        'Andriette 19/08/2013 bring ook die tipe van die verwyderde voertuig terug
        GridVerwyderdeVoertuie.Columns(13).Name = "Tipe"
        GridVerwyderdeVoertuie.Columns(13).Visible = False

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                    New SqlParameter("@Cancelled", SqlDbType.Int)}
                params(0).Value = Persoonl.POLISNO
                params(1).Value = 1
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuieWithGrid", params)
                While reader.Read()
                    strVoertuigWaarde = reader("WaardeR").ToString.Trim
                    strVoertuigWaarde = strVoertuigWaarde.Substring(0, Len(strVoertuigWaarde) - 5)
                    'Andriette 19/08/2013 vul ook die tipe van die verwyderde voertuig
                    GridVerwyderdeVoertuie.Rows.Insert(0, reader("pkVoertuie"), reader("Fabrikaat"), reader("Model"), reader("Jaar") _
                                                       , reader("Registrasie"), reader("Kleur"), strVoertuigWaarde _
                                                       , reader("PremieR"), reader("Datum verwyder"), reader("MotorStatus"), reader("EnjinNommer"), reader("OnderstelNommer") _
                                                       , reader("KODE"), reader("tipe"), intRow_tel)

                End While
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        'Me.DataVerwyderdeItems.RecordSource = sSql
        '  Me.DataVerwyderdeItems.Refresh()
        'Me.GridVerwyderdeVoertuie.CtlRefresh()
    End Sub
    Public Sub displayProperties()
        Dim strHOwaarde As String
        Dim strHEwaarde As String
        intRow_tel = 0
        intRow_tel = intRow_tel + 1
        'Set title for window
        'Andriette 15/08/2013 verander na die global polisnommer
        '   Me.Text = My.Application.Info.Title & " - Deleted properties - " & Form1.TITEL.Text & " " & Form1.VOORL.Text & " " & Form1.VERSEKERDE.Text & " (" & Form1.POLISNO.Text & ")"
        Me.Text = My.Application.Info.Title & " - Deleted properties - " & Form1.TITEL.Text & " " & Form1.VOORL.Text & " " & Form1.VERSEKERDE.Text & " (" & glbPolicyNumber & ")"
        Dim item As HuisEntity = New HuisEntity()
        GridVerwyderdeVoertuie.AutoGenerateColumns = False
        GridVerwyderdeVoertuie.Refresh()
        GridVerwyderdeVoertuie.DataSource = Nothing
        GridVerwyderdeVoertuie.ColumnCount = 9
        GridVerwyderdeVoertuie.ColumnHeadersVisible = True
        GridVerwyderdeVoertuie.AllowUserToAddRows = False
        GridVerwyderdeVoertuie.AllowUserToDeleteRows = False

        ' Andriette 08/05/2013 verander die opskrifte
        Dim columnHeaderStyle As New DataGridViewCellStyle
        ' andriette maak die header bietjie kleiner
        columnHeaderStyle.Font = New Font("Microsoft Sans Serif", 6.5, FontStyle.Bold)
        GridVerwyderdeVoertuie.ColumnHeadersDefaultCellStyle = columnHeaderStyle
        ' Andriette 08/05/2013 maak rye kleiner
        With Me.GridVerwyderdeVoertuie.RowTemplate
            .Height = 15
            .MinimumHeight = 5
        End With

        GridVerwyderdeVoertuie.Columns(0).Name = "pkhuis"
        GridVerwyderdeVoertuie.Columns(0).Visible = False
        GridVerwyderdeVoertuie.Columns(1).Name = "Risk Address"
        GridVerwyderdeVoertuie.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(1).Width = 225

        GridVerwyderdeVoertuie.Columns(2).Name = "Address2"
        ' GridVerwyderdeVoertuie.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(2).Visible = False

        GridVerwyderdeVoertuie.Columns(3).Name = "PostCode"
        'GridVerwyderdeVoertuie.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(3).Visible = False

        GridVerwyderdeVoertuie.Columns(4).Name = "HO Cover"
        GridVerwyderdeVoertuie.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(4).Width = 75
        GridVerwyderdeVoertuie.Columns(4).Visible = True

        GridVerwyderdeVoertuie.Columns(5).Name = "HO Prem"
        GridVerwyderdeVoertuie.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(5).Width = 75
        GridVerwyderdeVoertuie.Columns(5).DefaultCellStyle.Format = "C"
        GridVerwyderdeVoertuie.Columns(5).Visible = True

        GridVerwyderdeVoertuie.Columns(6).Name = "HH Cover"
        GridVerwyderdeVoertuie.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(6).Width = 75
        GridVerwyderdeVoertuie.Columns(6).Visible = True

        GridVerwyderdeVoertuie.Columns(7).Name = "HH Prem"
        GridVerwyderdeVoertuie.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(7).Width = 75
        GridVerwyderdeVoertuie.Columns(7).DefaultCellStyle.Format = "C"
        GridVerwyderdeVoertuie.Columns(7).Visible = True

        GridVerwyderdeVoertuie.Columns(8).Name = "Date cancelled"
        GridVerwyderdeVoertuie.Columns(8).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(8).Width = 75
        GridVerwyderdeVoertuie.Columns(8).Visible = True
        ' Andriette haal uit
        'GridVerwyderdeVoertuie.Columns(9).Name = "Acc Cover"
        'GridVerwyderdeVoertuie.Columns(9).SortMode = DataGridViewColumnSortMode.NotSortable
        'GridVerwyderdeVoertuie.Columns(9).Width = 75
        'GridVerwyderdeVoertuie.Columns(10).Name = "Acc Prem"
        'GridVerwyderdeVoertuie.Columns(10).SortMode = DataGridViewColumnSortMode.NotSortable
        'GridVerwyderdeVoertuie.Columns(10).Width = 75
        'GridVerwyderdeVoertuie.Columns(11).Name = "EEM Cover"
        'GridVerwyderdeVoertuie.Columns(11).SortMode = DataGridViewColumnSortMode.NotSortable
        'GridVerwyderdeVoertuie.Columns(11).Width = 75
        'GridVerwyderdeVoertuie.Columns(12).Name = "EEM Prem"
        'GridVerwyderdeVoertuie.Columns(12).SortMode = DataGridViewColumnSortMode.NotSortable
        'GridVerwyderdeVoertuie.Columns(12).Width = 75
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                    New SqlParameter("@Cancelled", SqlDbType.Int)}
                params(0).Value = Persoonl.POLISNO
                params(1).Value = True
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchHuisWithGrid", params)
                While reader.Read()
                    'Andriette 24/07/20103 herformateer hierdie waardes omdat dit met desimale uit die sp kom maar nie desimale moet vertoon nie

                    strHEwaarde = reader("WAARDE_HE R").ToString.Trim
                    strHEwaarde = strHEwaarde.Substring(0, Len(strHEwaarde) - 5)

                    strHOwaarde = reader("WAARDE_HB R").ToString.Trim
                    strHOwaarde = strHOwaarde.Substring(0, Len(strHOwaarde) - 5)

                    'GridVerwyderdeVoertuie.Rows.Insert(0, reader("pkhuis"), reader("Adres"), reader("Adres2"), reader("poskode"), reader("WAARDE_HE R"), reader("PREMIE_HE R"), reader("WAARDE_HB R"), reader("PREMIE_HB R"), reader("Datum verwyder"), row_tel)
                    GridVerwyderdeVoertuie.Rows.Insert(0, reader("pkhuis"), reader("Adres"), reader("Adres2"), reader("poskode"), strHEwaarde, reader("PREMIE_HE R"), strHOwaarde, reader("PREMIE_HB R"), reader("Datum verwyder"), intRow_tel)
                End While
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        ' Me.DataVerwyderdeItems.Refresh()
        ' Me.DataVerwyderdeItems.Refresh()
        GridVerwyderdeVoertuie.Visible = True
        Me.GridVerwyderdeVoertuie.Refresh()
    End Sub
    Public Sub displayAllRisks()
        Dim strwaarde As String
        '  Dim strPremie As String
        intRow_tel = 0
        intRow_tel = intRow_tel + 1
        'Set title for window
        'Andriette 15/08/2013 verander na die global polisnommer
        'Me.Text = My.Application.Info.Title & " - Deleted all risk items - " & Form1.TITEL.Text & " " & Form1.VOORL.Text & " " & Form1.VERSEKERDE.Text & " (" & Form1.POLISNO.Text & ")"
        Me.Text = My.Application.Info.Title & " - Deleted all risk items - " & Form1.TITEL.Text & " " & Form1.VOORL.Text & " " & Form1.VERSEKERDE.Text & " (" & glbPolicyNumber & ")"
        Dim item As ALLERISKEntity = New ALLERISKEntity()
        GridVerwyderdeVoertuie.AutoGenerateColumns = False
        GridVerwyderdeVoertuie.Refresh()
        GridVerwyderdeVoertuie.DataSource = Nothing
        GridVerwyderdeVoertuie.ColumnCount = 9
        GridVerwyderdeVoertuie.ColumnHeadersVisible = True
        GridVerwyderdeVoertuie.AllowUserToAddRows = False
        GridVerwyderdeVoertuie.AllowUserToDeleteRows = False

        ' Andriette 08/05/2013 verander die opskrifte
        Dim columnHeaderStyle As New DataGridViewCellStyle
        ' andriette maak die header bietjie kleiner
        columnHeaderStyle.Font = New Font("Microsoft Sans Serif", 6.5, FontStyle.Bold)
        GridVerwyderdeVoertuie.ColumnHeadersDefaultCellStyle = columnHeaderStyle
        ' Andriette 08/05/2013 maak rye kleiner
        With Me.GridVerwyderdeVoertuie.RowTemplate
            .Height = 15
            .MinimumHeight = 5
        End With

        GridVerwyderdeVoertuie.Columns(0).Name = "pkAllerisk"
        GridVerwyderdeVoertuie.Columns(0).Visible = False

        GridVerwyderdeVoertuie.Columns(1).Name = "Type"
        GridVerwyderdeVoertuie.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(1).Visible = True
        GridVerwyderdeVoertuie.Columns(1).Width = 150
        '   GridVerwyderdeVoertuie.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        GridVerwyderdeVoertuie.Columns(2).Name = "Description"
        GridVerwyderdeVoertuie.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(2).MinimumWidth = 200
        GridVerwyderdeVoertuie.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        GridVerwyderdeVoertuie.Columns(2).Visible = True

        GridVerwyderdeVoertuie.Columns(3).Name = "Cover"
        GridVerwyderdeVoertuie.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(3).Width = 50
        GridVerwyderdeVoertuie.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        GridVerwyderdeVoertuie.Columns(3).DefaultCellStyle.Format = "C0"
        GridVerwyderdeVoertuie.Columns(3).Visible = True
        '   GridVerwyderdeVoertuie.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        GridVerwyderdeVoertuie.Columns(4).Name = "Premium"
        GridVerwyderdeVoertuie.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(4).Width = 50
        GridVerwyderdeVoertuie.Columns(4).DefaultCellStyle.Format = "C2"
        GridVerwyderdeVoertuie.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        GridVerwyderdeVoertuie.Columns(4).Visible = True
        ' GridVerwyderdeVoertuie.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        GridVerwyderdeVoertuie.Columns(5).Name = "Plekhouer1"
        GridVerwyderdeVoertuie.Columns(5).Visible = False
        GridVerwyderdeVoertuie.Columns(5).Width = 0

        GridVerwyderdeVoertuie.Columns(6).Name = "Plekhouer2"
        GridVerwyderdeVoertuie.Columns(6).Visible = False
        GridVerwyderdeVoertuie.Columns(6).Width = 0

        GridVerwyderdeVoertuie.Columns(7).Name = "Plekhouer3"
        GridVerwyderdeVoertuie.Columns(7).Visible = False
        GridVerwyderdeVoertuie.Columns(7).Width = 0

        GridVerwyderdeVoertuie.Columns(8).Name = "Date cancelled"
        GridVerwyderdeVoertuie.Columns(8).SortMode = DataGridViewColumnSortMode.NotSortable
        GridVerwyderdeVoertuie.Columns(8).Width = 100
        GridVerwyderdeVoertuie.Columns(8).Visible = True

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                    New SqlParameter("@Cancelled", SqlDbType.Int)}
                params(0).Value = Persoonl.POLISNO
                params(1).Value = True
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAlleriskWithGrid", params)
                While reader.Read()
                    strwaarde = reader("DEKKING").ToString.Trim
                    strwaarde = strwaarde.Substring(0, Len(strwaarde) - 5)
                    GridVerwyderdeVoertuie.Rows.Insert(0, reader("pkAllerisk"), reader("Beskrywing"), reader("beskryf"), strwaarde, reader("Premie"), "", "", "", reader("verwyderdedatum"), intRow_tel)
                End While
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        'Me.DataVerwyderdeItems.Refresh()
        '  Me.DataVerwyderdeItems.Refresh()
        Me.GridVerwyderdeVoertuie.Refresh()
    End Sub

    Private Sub GridVerwyderdeVoertuie_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Me.GridVerwyderdeVoertuie.ColumnCount = 0
        strpkSelected = Me.GridVerwyderdeVoertuie.Text
        'Me.GridVerwyderdeVoertuie.HighLight = MSFlexGridLib.HighLightSettings.flexHighlightAlways
        'Me.GridVerwyderdeVoertuie.ColSel = Me.GridVerwyderdeVoertuie.Cols - 1
        If Me.GridVerwyderdeVoertuie.RowCount > 1 Then
            If CDbl(strpkSelected) = 0 Then
                Me.btnHerstel.Enabled = False
            Else
                Me.btnHerstel.Enabled = True
            End If
        Else
            MsgBox("There is no item to recover.", MsgBoxStyle.Information)
            Me.btnHerstel.Enabled = False
        End If
    End Sub

    'Update the grid on form1
    Public Sub updateForm1Grid2()
        'Ry = Form1.Grid2.row
        rsHUis = FetchHuis()
        Form1.dgvPoldata1Eiendomme.Rows.Add(rsHUis.ADRES_H1, 1)
        Form1.dgvPoldata1Eiendomme.RowCount = 1
        Form1.dgvPoldata1Eiendomme.ColumnCount = 3
        Form1.dgvPoldata1Eiendomme.SelectedCells.Item(3).Value = rsHUis.WAARDE_HE
        'Form1.Grid2.col = 4
        Form1.dgvPoldata1Eiendomme.SelectedCells.Item(4).Value = rsHUis.PREMIE_HE
        'Form1.Grid2.col = 5
        Form1.dgvPoldata1Eiendomme.SelectedCells.Item(5).Value = rsHUis.WAARDE_HB
        ' Form1.Grid2.col = 6
        Form1.dgvPoldata1Eiendomme.SelectedCells.Item(6).Value = rsHUis.PREMIE_HB
        'Form1.Grid2.col = 13
        ' Andriette 2013-02-25
        ' Verander die offset van die grid
        'Form1.Grid2.SelectedCells.Item(13).Value = rsHUis.pkHuis
        Form1.dgvPoldata1Eiendomme.SelectedCells.Item(21).Value = rsHUis.pkHuis
        'Eiendom sekuriteit
        'Form1.Grid2.col = 7
        Form1.dgvPoldata1Eiendomme.SelectedCells.Item(7).Value = gen_getPropertySecurity(Persoonl.TAAL, rsHUis.SekuriteitBitValue)
        'toevallige skade
        'Form1.Grid2.col = 8
        Form1.dgvPoldata1Eiendomme.SelectedCells.Item(8).Value = rsHUis.toe_waarde
        'Form1.Grid2.col = 9
        Form1.dgvPoldata1Eiendomme.SelectedCells.Item(9).Value = rsHUis.toe_premie
        'toevallige skade - eem
        'Form1.Grid2.col = 10
        Form1.dgvPoldata1Eiendomme.SelectedCells.Item(10).Value = rsHUis.eem_waarde
        ' Form1.Grid2.col = 11
        Form1.dgvPoldata1Eiendomme.SelectedCells.Item(11).Value = rsHUis.eem_premie
        'Form1.Grid2.col = 12
        Form1.dgvPoldata1Eiendomme.SelectedCells.Item(12).Value = rsHUis.mainproperty
        Form1.dgvPoldata1Eiendomme.RowCount = 1
        Form1.dgvPoldata1Eiendomme.ColumnCount = 1
        If Persoonl.TAAL Then
            Select Case rsHUis.TIPE_DAK
                Case "1"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(1).Value = "Teël Staan"
                Case "2"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(1).Value = "Sink Staan"
                Case "3"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(1).Value = "Sink Plat"
                Case "4"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(1).Value = "Asbes Staan"
                Case "5"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(1).Value = "Asbes Plat"
                Case "6"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(1).Value = "Grasdak"
                Case "7"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(1).Value = "Ander Staan"
                Case "8"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(1).Value = "Ander Plat"
            End Select
            Form1.dgvPoldata1Eiendomme.ColumnCount = 2
            Select Case rsHUis.STRUKTUUR
                Case "1"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(2).Value = "Standaard"
                Case "2"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(2).Value = "Houthuis"
                Case "3"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(2).Value = "Nie stand"
                Case "4"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(2).Value = "Strandhuis"
                Case "5"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(2).Value = "Asbes"
            End Select
        Else
            Select Case rsHUis.TIPE_DAK
                Case "1"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(2).Value = "Pitch Tiled"
                Case "2"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(2).Value = "Pitch Iron"
                Case "3"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(2).Value = "Flat Iron"
                Case "4"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(2).Value = "Pitch Asbestos"
                Case "5"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(2).Value = "Flat Asbestos"
                Case "6"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(2).Value = "Pitch Grass"
                Case "7"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(2).Value = "Other Pitched"
                Case "8"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(2).Value = "Other Flat"
            End Select
            Form1.dgvPoldata1Eiendomme.ColumnCount = 2
            Select Case rsHUis.STRUKTUUR
                Case "1"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(2).Value = "Standard"
                Case "2"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(2).Value = "Wood"
                Case "3"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(2).Value = "Not stand"
                Case "4"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(2).Value = "Beach house"
                Case "5"
                    Form1.dgvPoldata1Eiendomme.SelectedCells.Item(2).Value = "Asbestos"
            End Select
        End If
    End Sub
    Private Sub updateForm1Grid3()
        'row_tel = 0
        'row_tel = row_tel + 1
        'When a allrisk item is added without focussing on grid an error ocurred because ry will have the value 0 and 0 is the fixed row in the grid.
        If intRow_tel = 0 Then
            intRow_tel = Form1.dgvPoldata1AlleRisikoItems.RowCount - 1
        End If
        GridVerwyderdeVoertuie.AutoGenerateColumns = False
        GridVerwyderdeVoertuie.Refresh()
        GridVerwyderdeVoertuie.DataSource = Nothing
        GridVerwyderdeVoertuie.ColumnCount = 4
        GridVerwyderdeVoertuie.ColumnHeadersVisible = True

        GridVerwyderdeVoertuie.Columns(0).Name = "pkAllerisk"
        GridVerwyderdeVoertuie.Columns(1).Name = "description"
        GridVerwyderdeVoertuie.Columns(2).Name = "cover"
        GridVerwyderdeVoertuie.Columns(3).Name = "premium"

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                    New SqlParameter("@Cancelled", SqlDbType.Int)}
                params(0).Value = Persoonl.POLISNO
                params(1).Value = True
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAlleriskWithGrid", params)

                While reader.Read()
                    Form1.dgvPoldata1AlleRisikoItems.Rows.Insert(0, reader("pkAllerisk"), reader("beskryf") + Chr(9) + reader("Dekking") + Chr(9) + reader("Premie"), intRow_tel)
                    'Form1.Grid3.Rows.Insert(0, reader("pkAllerisk"), reader("beskryf"), reader("Dekking"), reader("Premie"), row_tel)
                End While
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Me.DataVerwyderdeItems.Refresh()
    End Sub

    Private Sub GridVerwyderdeVoertuie_DataBindingComplete(sender As Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles GridVerwyderdeVoertuie.DataBindingComplete
        'Andriette 24/07/2013 gaan deur die lys en haal die waarde se nulle uit

        For intTeller = 0 To GridVerwyderdeVoertuie.RowCount - 1

            Select Case intPoldataGrid_Focus
                Case 1 'Vehicles
                    GridVerwyderdeVoertuie.Rows(intTeller).Cells(6).Value = GridVerwyderdeVoertuie.Rows(intTeller).Cells(4).Value.ToString.Substring(0, Len(GridVerwyderdeVoertuie.Rows(intTeller).Cells(4).Value) - 3)
                Case 2 'Properties
                    GridVerwyderdeVoertuie.Rows(intTeller).Cells(4).Value = GridVerwyderdeVoertuie.Rows(intTeller).Cells(4).Value.ToString.Substring(0, Len(GridVerwyderdeVoertuie.Rows(intTeller).Cells(4).Value) - 3)
                    GridVerwyderdeVoertuie.Rows(intTeller).Cells(6).Value = GridVerwyderdeVoertuie.Rows(intTeller).Cells(6).Value.ToString.Substring(0, Len(GridVerwyderdeVoertuie.Rows(intTeller).Cells(6).Value) - 3)
                Case 3 'All risks
                    GridVerwyderdeVoertuie.Rows(intTeller).Cells(3).Value = GridVerwyderdeVoertuie.Rows(intTeller).Cells(3).Value.ToString.Substring(0, Len(GridVerwyderdeVoertuie.Rows(intTeller).Cells(3).Value) - 3)
            End Select
        Next
    End Sub
End Class