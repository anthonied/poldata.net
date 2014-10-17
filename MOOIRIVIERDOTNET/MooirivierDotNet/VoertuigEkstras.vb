Option Strict Off
Option Explicit On

Imports System.Data.SqlClient
Imports DAL

Friend Class VoertuigEkstras
    Inherits BaseForm

    'Description: Form containing all information on additional items for selected vehicle
    '           : Update grid on voertuigDetail
    Dim k As Integer
    'Dim sSql As String
    Dim blnInformationChanged As Boolean
    'Kobus 11/12/2013 om wysigings in geskiedenis te rëel
    Dim blnNoRepeat As Boolean = False
    Dim blnNilvalue As Boolean = False

    Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        Try
            If VoertuigDetail.blnAddnew = True Then
                If MsgBox("Are you sure you want to cancel your changes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Me.Close()
                    VoertuigDetail.blnAddnew = False
                Else
                    Exit Sub
                End If

            End If

            testExtraschange()
            If blnInformationChanged Then
                'Kobus 12/07/2013 verander van Are you sure you want to cancel your change (s) lose?
                If MsgBox("Are you sure you want to cancel your changes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Me.Close()

                End If
            Else
                
            End If
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
        Dim strStatus As String
        Try
            If validateForm() Then
                If pkVoertuieEkstra = 0 Then 'Add new
                    'Kobus 16/08/2013 voegby
                    blnediting = True
                    InsertIntoVoertuieEkstras()
                Else 'Update
                    Update_VoertuieEkstras()
                End If

                Using conn As SqlConnection = SqlHelper.GetConnection

                    Dim param As New SqlParameter("@fkVoertuie", SqlDbType.Int)
                    'Kobus 05/08/2013 voegby
                    strStatus = VoertuigDetail.strCurrentVehicle
                    If strStatus = "NewVehicleExtras" Or strStatus = "SavedVehicleExtras" Then
                        param.Value = pkVoertuie
                        'Kobus 07/03/2014 voegby
                        'VoertuigDetail.strCurrentVehicle = ""
                    Else
                        param.Value = Form1.dgvPoldataVoertuie.SelectedRows(0).Cells(0).Value
                    End If



                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuieEkstrasTotals", param)

                    If reader.Read Then
                        EditVoertuieWithEsktras(reader("Totpremie"), reader("TotWaarde"))

                        'Populate values on Voertuig detail
                        VoertuigDetail.populateEkstras()

                    End If
                    conn.Close()
                End Using

                'Kobus 20/2/2014 voegby
                VoertuigDetail.calcTotValue()
                VoertuigDetail.calcPremium()
                'Kobus 25/03/2014 voegby

                'Kobus 01/04/2014 voegby
                BFUpdateItemsSubTotals(glbPolicyNumber)
                HerBereken_Premie()
                'Kobus 01/04/2014 comment out
                'doen_subtotaal()
                'Log alterations
                logAlterations()
                'Kobus 21/01/2014 voegby
                blnediting = True

                'Repopulate grid on voertuigDetail
                VoertuigDetail.PopulateGridEkstras()
                'Kobus 21/01/2014 verander van false na true
                blnInformationChanged = True
                'Kobus 07/03/2014 voegby
                'VoertuigDetail.strCurrentVehicle = ""
                Me.Close()
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Sub EditVoertuieWithEsktras(ByVal premieEkstras As Object, ByVal waardeEkstras As Object)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim param() As SqlParameter = {New SqlParameter("@pkVoertuie", SqlDbType.Int), _
                                               New SqlParameter("@PremieEkstras", SqlDbType.Money), _
                                               New SqlParameter("@WaardeEkstras", SqlDbType.Money)}
                param(0).Value = pkVoertuie
                param(1).Value = premieEkstras
                param(2).Value = waardeEkstras

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdatevoertuieWithEkstras", param)
                conn.Close()
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Sub Update_VoertuieEkstras()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim param() As SqlParameter = {New SqlParameter("@pkVoertuieEkstras", SqlDbType.Int), _
                                               New SqlParameter("@fkVoertuie", SqlDbType.Int), _
                                               New SqlParameter("@Premie", SqlDbType.Money), _
                                               New SqlParameter("@Waarde", SqlDbType.Money), _
                                               New SqlParameter("@Beskrywing", SqlDbType.NVarChar), _
                                               New SqlParameter("@Fabrikaat", SqlDbType.NVarChar), _
                                               New SqlParameter("@Model", SqlDbType.NVarChar), _
                                               New SqlParameter("@SerieNommer", SqlDbType.NVarChar), _
                                               New SqlParameter("@Deleted", SqlDbType.TinyInt), _
                                               New SqlParameter("@DatumWysig", SqlDbType.NVarChar), _
                                               New SqlParameter("@fkVoertuieEkstraTipe", SqlDbType.Int)}

                param(0).Value = VoertuigDetail.GridEkstras.SelectedRows(0).Cells(0).Value
                'Kobus 15/08/2013 voeg voorwaarde by
                If VoertuigDetail.strCurrentVehicle = "NewVehicleExtras" Then
                    param(1).Value = pkVoertuie
                Else
                    param(1).Value = Form1.dgvPoldataVoertuie.SelectedRows(0).Cells(0).Value
                End If
                param(2).Value = Format(Val(txtPremie.Text), "######0.00") 'Kobus Visser 28/02/2013 format premie
                param(3).Value = txtWaarde.Text
                param(4).Value = txtBeskrywing.Text
                param(5).Value = txtFabrikaat.Text
                param(6).Value = txtModel.Text
                param(7).Value = txtSerienommer.Text
                param(8).Value = 0
                param(9).Value = Format(Now, "dd/mm/yyyy")

                If Me.cmbItemTipe.SelectedIndex = -1 Then
                    param(10).Value = 0
                Else
                    param(10).Value = cmbItemTipe.SelectedValue
                End If

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.Update_VoertuieEkstras", param)
                conn.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

    End Sub

    Sub InsertIntoVoertuieEkstras()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim param() As SqlParameter = {New SqlParameter("@pkVoertuieEkstras", SqlDbType.Int), _
                                               New SqlParameter("@fkVoertuie", SqlDbType.Int), _
                                               New SqlParameter("@Premie", SqlDbType.Money), _
                                               New SqlParameter("@Waarde", SqlDbType.Money), _
                                               New SqlParameter("@Beskrywing", SqlDbType.NVarChar), _
                                               New SqlParameter("@Fabrikaat", SqlDbType.NVarChar), _
                                               New SqlParameter("@Model", SqlDbType.NVarChar), _
                                               New SqlParameter("@SerieNommer", SqlDbType.NVarChar), _
                                               New SqlParameter("@Deleted", SqlDbType.TinyInt), _
                                               New SqlParameter("@DatumIn", SqlDbType.NVarChar), _
                                               New SqlParameter("@DatumWysig", SqlDbType.NVarChar), _
                                               New SqlParameter("@fkVoertuieEkstraTipe", SqlDbType.Int)}



                param(0).Value = DBNull.Value

                'Kobus 31/07/2013 voeg kondisie by

                param(1).Value = pkVoertuie 'Form1.Grid1.SelectedRows(0).Cells(0).Value
                'End If
                'Kobus 15/08/2013 voeg voorwaarde by
                If txtPremie.Text = "2" Then
                    txtPremie.Text = 0
                End If
                param(2).Value = txtPremie.Text
                If txtWaarde.Text = "2" Then
                    txtWaarde.Text = 0
                End If
                param(3).Value = txtWaarde.Text
                param(4).Value = txtBeskrywing.Text
                param(5).Value = txtFabrikaat.Text
                param(6).Value = txtModel.Text
                param(7).Value = txtSerienommer.Text
                param(8).Value = 0
                param(9).Value = Format(Now, "dd/MM/yyyy")
                param(10).Value = Format(Now, "dd/MM/yyyy")

                If Me.cmbItemTipe.SelectedIndex = -1 Then
                    param(11).Value = 0
                Else
                    param(11).Value = cmbItemTipe.SelectedValue
                End If

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.InsertIntoVoertuieEkstras", param)
                conn.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub

        End Try

    End Sub
    Private Sub cmbItemTipe_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbItemTipe.SelectedIndexChanged
        blnInformationChanged = True
        Select Case Me.cmbItemTipe.Text
            Case "Motorradio", "Car radio", "Canopy", "Kappie"
                Me.imgDot.Visible = True
            Case Else
                Me.imgDot.Visible = False
        End Select

    End Sub
    Private Sub VoertuigEkstras_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        'Set title for window
        'Kobus Visser - 25/02/2013 - Vehicle Accessories to Vehicle Extras
        Me.Text = My.Application.Info.Title & " - Vehicle Extras - " & Trim(VoertuigDetail.txtMaak.Text) & " " & Trim(VoertuigDetail.txtBesk.Text) & " " & Trim(VoertuigDetail.txtNPlaat.Text)
        'Kobus 19/7/2013 voorkom dat Voertuig ekstra tipes verander kan word- tipe moet verwyder en herlaai word
        cmbItemTipe.Enabled = True
        If cmbItemTipe.Text <> "" Then
            cmbItemTipe.Enabled = False
        End If
        'Hide date boxes for new items
        If voertuieEkstras.pkVoertuieEkstras = 0 Then
            Me.txtDatumIn.Visible = False
            Me.txtDatumWysig.Visible = False
            Me.Label8.Visible = False
            Me.Label9.Visible = False
        Else
            Me.txtDatumIn.Visible = True
            Me.txtDatumWysig.Visible = True
            Me.Label8.Visible = True
            Me.Label9.Visible = True
        End If
    End Sub

    Private Sub VoertuigEkstras_Leave(sender As Object, e As System.EventArgs) Handles Me.Leave
        'Kobus 09/09/2013 voegby
        If VoertuigDetail.blnAddnew = True Or VoertuigDetail.strRemove = "Yes" Then
            blnInformationChanged = True
            VoertuigDetail.calcTotValue()
            VoertuigDetail.calcPremium()
        End If
    End Sub

    'Private Sub VoertuigEkstras_Layout(sender As Object, e As System.Windows.Forms.LayoutEventArgs) Handles Me.Layout

    'End Sub

    Private Sub VoertuigEkstras_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Try
            VoertuigDetail.ClearFields()

            'Populate combobox and set value from db
            populateComboType()
            If pkVoertuieEkstra <> 0 Then

                Using conn As SqlConnection = SqlHelper.GetConnection

                    Dim param As New SqlParameter("@pkVoertuieEkstras", SqlDbType.Int)
                    param.Value = pkVoertuieEkstra

                    Dim reader As SqlDataReader

                    If Not VoertuigDetail.blnAddnew Then
                        If Persoonl.TAAL = 0 Then
                            reader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuieEsktrasAndStandard", param)
                        Else
                            reader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuie_EsktrasAndStandard", param)
                        End If

                        If reader.Read Then
                            'Populate fields
                            'Detail
                            txtBeskrywing.Text = reader("Beskrywing")
                            txtFabrikaat.Text = reader("Fabrikaat")
                            txtModel.Text = reader("Model")
                            'Kobus Visser 28/02/2013 Format Premium to keep last 0 in cents
                            txtPremie.Text = Format(Val(reader("Premie")), "######0.00") 'K
                            txtSerienommer.Text = reader("SerieNommer")
                            txtDatumIn.Text = reader("DatumIn")
                            txtDatumWysig.Text = reader("DatumWysig")
                            'Kobus 06/06/2013 change reader("Waarde")
                            txtWaarde.Text = Format(reader("Waarde"), "########")

                            cmbItemTipe.SelectedValue = reader("fkVoertuieEkstraTipe")
                            'Kobus 22/07/2013 voegby om VoertuieEkstrasEntity ook te populate
                            voertuieEkstras.Beskrywing = reader("Beskrywing")
                            voertuieEkstras.Fabrikaat = reader("Fabrikaat")
                            voertuieEkstras.Model = reader("Model")
                            voertuieEkstras.Premie = reader("Premie")
                            voertuieEkstras.SerieNommer = reader("SerieNommer")
                            voertuieEkstras.Waarde = reader("Waarde")
                            voertuieEkstras.fkVoertuieEkstraTipe = reader("fkVoertuieEkstraTipe")
                            'Kobus 22/7/2013 voorkom dat Voertuig ekstra tipes verander kan word- tipe moet verwyder en herlaai word
                            cmbItemTipe.Enabled = False
                            'If cmbItemTipe.Text <> "" Then
                            '    cmbItemTipe.Enabled = False
                            'End If
                            'Andriette 06/008/21013
                        Else
                            cmbItemTipe.Enabled = True
                        End If


                    Else
                        cmbItemTipe.SelectedIndex = -1
                        pkVoertuieEkstra = 0
                        cmbItemTipe.Enabled = True
                    End If
                    conn.Close()
                End Using
            Else
                cmbItemTipe.SelectedIndex = -1
                pkVoertuieEkstra = 0
                cmbItemTipe.Enabled = True
            End If

            blnInformationChanged = False

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    'Populate the comboboxe with values and set selected from db
    Private Sub populateComboType()

        Dim type As String
        Dim language As String
        Try
            If Persoonl.TAAL = 0 Then
                language = "BeskrywingAfrikaans"
                type = "BeskrywingAfrikaans"
            Else
                language = "BeskrywingEngels"
                type = "BeskrywingEngels"
            End If

            Dim list As List(Of VoertuigDropdownEntity) = New List(Of VoertuigDropdownEntity)
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim param() As SqlParameter = {New SqlParameter("@type", SqlDbType.NVarChar), _
                                             New SqlParameter("@VertoonGespesifiseerd", SqlDbType.Int)}

                param(0).Value = type
                param(1).Value = 1

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuieStandard", param)

                Do While reader.Read
                    Dim item As VoertuigDropdownEntity = New VoertuigDropdownEntity()
                    item.Descr = reader("Descr")
                    item.PK = reader("PK")
                    list.Add(item)
                Loop
                conn.Close()
            End Using
            cmbItemTipe.ValueMember = "pk"
            cmbItemTipe.DisplayMember = "Descr"
            cmbItemTipe.DataSource = list
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    'Validate the information on the form
    Public Function validateForm() As Object
        validateForm = True
        'Kobus 12/07/2013 voeg kontrole by ten opsigte van waarde en premie
        If txtWaarde.Text = "" Then
            txtWaarde.Text = 0
        End If
        If txtPremie.Text = "" Then
            txtPremie.Text = 0
        End If
        Try
            'ItemTipe
            If Me.cmbItemTipe.SelectedIndex = -1 Then
                MsgBox("The item type must be entered.", MsgBoxStyle.Exclamation)
                Me.cmbItemTipe.Focus()
                validateForm = False
                Exit Function
            End If

            'Fabrikaat - only compulsory when Car radio was selected
            Select Case Me.cmbItemTipe.SelectedText
                Case "Motorradio", "Car radio", "Canopy", "Kappie"
                    If Trim(Me.txtFabrikaat.Text) = "" Then
                        MsgBox("The make of the item must be completed.", MsgBoxStyle.Exclamation)
                        Me.txtFabrikaat.Focus()
                        validateForm = False
                        Exit Function
                    End If
            End Select

            'Waarde
            If Trim(Me.txtWaarde.Text) = "" Or txtWaarde.Text = 0 Then
                MsgBox("The value of the item must be completed.", MsgBoxStyle.Exclamation)
                validateForm = False
                Me.txtWaarde.Focus()
                Exit Function
            End If

            If Not IsNumeric(Me.txtWaarde.Text) Then
                MsgBox("The value of the item must be a numeric integer.", MsgBoxStyle.Exclamation)
                Me.txtWaarde.Focus()
                validateForm = False
                Exit Function
            End If

            If InStr(1, Me.txtWaarde.Text, ".") > 0 Then
                MsgBox("The value of the item should not contain cents.", MsgBoxStyle.Exclamation)
                Me.txtWaarde.Focus()
                validateForm = False
                Exit Function
            End If

            'Premie
            'Kobus 12/07/2013 verander van Trim(Me.txtPremie.Text) = ""
            If Me.txtPremie.Text = 0 Then
                MsgBox("The premium for the item must be entered.", MsgBoxStyle.Exclamation)
                Me.txtPremie.Focus()
                validateForm = False
                Exit Function
            End If

            'Premie
            If Not IsNumeric(Me.txtPremie.Text) Then
                MsgBox("Die Premie vir die item moet 'n numeries getal wees.", MsgBoxStyle.Exclamation)
                Me.txtPremie.Focus()
                validateForm = False
                Exit Function
            End If

            validateForm = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function
    'Log the alterations done on the specific item
    Public Sub logAlterations()
        
            'Kobus 22/08/2013 voegby
        Try
            'Kobus 31/03/2014 voegby 
            If blnPol_Byvoeg Or blnByvoeg Then
                'Don't log alterations if a new policy
            Else
                'A new item was added
                'Kobus 19/7/2013 verander If voertuieEkstras.pkVoertuieEkstras = 0 Then
                If pkVoertuieEkstra = 0 Then
                    If Persoonl.TAAL = 0 Then
                        'Kobus 19/07/2013 van Me.cmbItemTipe.SelectedText
                        'Kobus 02/09/2013 voegby " (" & Me.txtWaarde.Text & ") (" & Me.txtPremie.Text
                        BESKRYWING = Me.cmbItemTipe.Text & " " & Me.txtFabrikaat.Text & " " & Me.txtModel.Text & " " & Me.txtBeskrywing.Text & " " & Me.txtSerienommer.Text & " (" & Me.txtWaarde.Text & ") (" & Format(Val(Me.txtPremie.Text), "#########0.00") & ") op Voertuig:" & VoertuigDetail.txtNPlaat.Text
                    Else
                        BESKRYWING = Me.cmbItemTipe.Text & " " & Me.txtFabrikaat.Text & " " & Me.txtModel.Text & " " & Me.txtBeskrywing.Text & " " & Me.txtSerienommer.Text & " (" & Me.txtWaarde.Text & ") (" & Format(Val(Me.txtPremie.Text), "#########0.00") & ") on Vehicle:" & VoertuigDetail.txtNPlaat.Text
                    End If
                    UpdateWysig((171), BESKRYWING)
                Else

                    If VoertuigDetail.strRemove = "Yes" And blnNoRepeat = False Then
                        If Persoonl.TAAL = 0 Then
                            'Kobus 29/08/2013 voeg meer beskrywings by - 11/12/2013 voeg hakkies by
                            BESKRYWING = " verwyder " & VoertuigDetail.strExtrasDescription & "  op Voertuig: " & VoertuigDetail.txtNPlaat.Text
                        Else
                            BESKRYWING = " removed " & VoertuigDetail.strExtrasDescription & " on Vehicle: " & VoertuigDetail.txtNPlaat.Text
                        End If
                        blnNoRepeat = True
                        UpdateWysig((170), BESKRYWING)
                        VoertuigDetail.strRemove = "Extra"
                        blnNoRepeat = False
                        'Kobus 23/01/2014 comment out
                        'VoertuigDetail.logAlterations()
                        Exit Sub
                    End If


                    'Fabrikaat
                    If Trim(txtFabrikaat.Text) <> Trim(voertuieEkstras.Fabrikaat) Then
                        If Persoonl.TAAL = 0 Then
                            'Kobus 22/07/2013 verander van BESKRYWING = " wysig Fabrikaat vanaf (" & voertuieEkstras.Fabrikaat & ") na (" & txtFabrikaat.Text & ") op " & voertuieEkstras.fkVoertuieEkstraTipe & " Vehicle:" & VoertuigDetail.txtNPlaat.Text
                            BESKRYWING = " wysig Fabrikaat vanaf (" & Trim(voertuieEkstras.Fabrikaat) & ") na (" & Trim(txtFabrikaat.Text) & ") op " & cmbItemTipe.Text & " Voertuig:" & VoertuigDetail.txtNPlaat.Text
                        Else
                            BESKRYWING = " change Make from (" & Trim(voertuieEkstras.Fabrikaat) & ") to (" & Trim(txtFabrikaat.Text) & ") on " & cmbItemTipe.Text & " Vehicle:" & VoertuigDetail.txtNPlaat.Text
                        End If
                        UpdateWysig((170), BESKRYWING)
                    End If

                    'Model
                    If txtModel.Text <> voertuieEkstras.Model Then
                        If Persoonl.TAAL = 0 Then
                            BESKRYWING = " wysig Model vanaf (" & Format(voertuieEkstras.Model) & ") na (" & txtModel.Text & ") op " & cmbItemTipe.Text & " Voertuig:" & VoertuigDetail.txtNPlaat.Text
                        Else
                            BESKRYWING = " change Model from (" & Format(voertuieEkstras.Model) & ") to (" & txtModel.Text & ") on " & cmbItemTipe.Text & " Vehicle:" & VoertuigDetail.txtNPlaat.Text
                        End If
                        UpdateWysig((170), BESKRYWING)
                    End If

                    'Serienommer
                    If txtSerienommer.Text <> voertuieEkstras.SerieNommer Then
                        If Persoonl.TAAL = 0 Then
                            BESKRYWING = " wysig Serienommer vanaf (" & voertuieEkstras.SerieNommer & ") na (" & txtSerienommer.Text & ") op " & cmbItemTipe.Text & " Voertuig:" & VoertuigDetail.txtNPlaat.Text
                        Else
                            BESKRYWING = " change Seriel nummer from (" & voertuieEkstras.SerieNommer & ") to (" & txtSerienommer.Text & ") on " & cmbItemTipe.Text & " Vehicle:" & VoertuigDetail.txtNPlaat.Text
                        End If
                        UpdateWysig((170), BESKRYWING)
                    End If

                    'Waarde
                    If txtWaarde.Text <> voertuieEkstras.Waarde Then
                        If Persoonl.TAAL = 0 Then
                            BESKRYWING = " wysig Waarde vanaf (" & voertuieEkstras.Waarde & ") na (" & txtWaarde.Text & ") op " & cmbItemTipe.Text & " Voertuig:" & VoertuigDetail.txtNPlaat.Text
                        Else
                            BESKRYWING = " change Waarde from (" & voertuieEkstras.Waarde & ") to (" & txtWaarde.Text & ") on " & cmbItemTipe.Text & " Vehicle:" & VoertuigDetail.txtNPlaat.Text
                        End If
                        UpdateWysig((170), BESKRYWING)
                    End If

                    'Premie
                    If txtPremie.Text <> voertuieEkstras.Premie Then
                        If Persoonl.TAAL = 0 Then
                            BESKRYWING = " wysig Premie vanaf (" & voertuieEkstras.Premie & ") na (" & txtPremie.Text & ") op " & cmbItemTipe.Text & " Voertuig:" & VoertuigDetail.txtNPlaat.Text
                        Else
                            BESKRYWING = " change Premie from (" & voertuieEkstras.Premie & ") to (" & txtPremie.Text & ") on " & cmbItemTipe.Text & " Vehicle:" & VoertuigDetail.txtNPlaat.Text
                        End If
                        UpdateWysig((170), BESKRYWING)
                    End If
                    'Beskrywing
                    If txtBeskrywing.Text <> voertuieEkstras.Beskrywing Then
                        If Persoonl.TAAL = 0 Then
                            BESKRYWING = " wysig Beskrywing vanaf (" & voertuieEkstras.Beskrywing & ") na (" & txtBeskrywing.Text & ") op " & cmbItemTipe.Text & " Voertuig:" & VoertuigDetail.txtNPlaat.Text
                        Else
                            BESKRYWING = " change Description from (" & voertuieEkstras.Beskrywing & ") to (" & txtBeskrywing.Text & ") on " & cmbItemTipe.Text & " Vehicle:" & VoertuigDetail.txtNPlaat.Text
                        End If
                        UpdateWysig((170), BESKRYWING)
                    End If
                    'End If
                End If  'if pkVoertuie = 0 then
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    'UPGRADE_WARNING: Event txtBeskrywing.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub txtBeskrywing_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBeskrywing.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub txtBeskrywing_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtBeskrywing.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case 34, 39
                ' Anything else is unacceptable, and should be ignored
                MsgBox("The characters ' and """" can not be used.", MsgBoxStyle.Information)
                KeyAscii = 0
            Case Else
                ' These are acceptable keystrokes
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub txtFabrikaat_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFabrikaat.TextChanged
        blnInformationChanged = True
    End Sub

    Private Sub txtFabrikaat_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFabrikaat.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case 34, 39
                ' Anything else is unacceptable, and should be ignored
                MsgBox("The characters ' and """" can not be used.", MsgBoxStyle.Information)
                KeyAscii = 0
            Case Else
                ' These are acceptable keystrokes
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub txtModel_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtModel.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub txtModel_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtModel.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case 34, 39
                ' Anything else is unacceptable, and should be ignored
                MsgBox("The character ' and """" can not be used.", MsgBoxStyle.Information)
                KeyAscii = 0
            Case Else
                ' These are acceptable keystrokes
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    'Kobus Visser 13/03/2013 change KeyPres event to Leave Event. 
    Private Sub txtPremie_Leave(sender As Object, e As System.EventArgs) Handles txtPremie.Leave

        Dim strTest As String
        strTest = txtPremie.Text
        'Kobus 23/09/2013 voegby
        If strTest = "" Then
            txtPremie.Text = 0
        End If
        If IsNumeric(strTest) Then
            'do nothing
        Else
            MsgBox("Premium: Must be a numeric value", _
                   MsgBoxStyle.Information, "Verify")
            txtPremie.Focus()
        End If
    End Sub

    Private Sub txtPremie_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtPremie.MouseClick
        txtPremie.SelectAll()
    End Sub
    Private Sub txtPremie_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPremie.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub txtSerienommer_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSerienommer.TextChanged
        blnInformationChanged = True
    End Sub

    Private Sub txtWaarde_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWaarde.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar)) Then
                'do nothing
            Else
                e.Handled = True
                'Kobus 12/07/2013 verander van Value: only numbers are allowed
                MsgBox("Value must be a round figure.", _
                       MsgBoxStyle.Information, "Verify")
                txtWaarde.Focus()
            End If
        End If
    End Sub

    Private Sub txtWaarde_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtWaarde.MouseClick
        txtWaarde.SelectAll()
    End Sub
    Private Sub txtWaarde_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtWaarde.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub testExtraschange()
        If txtBeskrywing.Text <> voertuieEkstras.Beskrywing Then
            blnInformationChanged = True

        ElseIf txtFabrikaat.Text <> voertuieEkstras.Fabrikaat Then
            blnInformationChanged = True
        ElseIf txtModel.Text <> voertuieEkstras.Model Then
            blnInformationChanged = True
        ElseIf Val(txtPremie.Text) <> Val(voertuieEkstras.Premie) Then
            blnInformationChanged = True
        ElseIf Val(txtWaarde.Text) <> Val(voertuieEkstras.Waarde) Then
            blnInformationChanged = True
        Else
            blnInformationChanged = False

        End If
        
    End Sub
End Class