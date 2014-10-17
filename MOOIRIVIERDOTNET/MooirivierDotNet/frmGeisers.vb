Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports DAL

Friend Class frmGeisers
    Inherits BaseForm

    Dim blnInformationChanged As Boolean
    'Kobus 11/11/2013 voegby
    Dim blnPremiumAfterGeyserAdd As Boolean

    'Public pkGeysers As Integer
   
    Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        If blnInformationChanged Then
            If MsgBox("Are you sure you want to cancel your changes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Me.Close()
                'Kobus 28/11/2013 voegby
                Exit Sub
            End If
        Else
            'Kobus 28/11/2013 voegby
            Huis_EF.blnInformationChanged = False
            Me.Close()
            'Kobus 28/11/2013 voegby
            Exit Sub
        End If
    End Sub
    Sub updateHuis(ByVal premieEkstras As Decimal, ByVal waardeEkstras As Decimal)
        Using conn As SqlConnection = SqlHelper.GetConnection
            'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
            Dim param() As SqlParameter = {New SqlParameter("@pkHuis", SqlDbType.Int), _
                                           New SqlParameter("@premieEkstras", SqlDbType.Money), _
                                          New SqlParameter("@waardeEkstras", SqlDbType.Money)}
            'Kobus 17/08/2013 verander van huis_e.pkHuis
            param(0).Value = pkHuis
            param(1).Value = premieEkstras
            param(2).Value = waardeEkstras

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateHuis", param)
            conn.Close()
        End Using
    End Sub
    Private Sub updateGeyser(ByVal type As String)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim params() As SqlParameter = {New SqlParameter("@DatumIn", SqlDbType.Date), _
                                                New SqlParameter("@fkHuis", SqlDbType.Int), _
                                                 New SqlParameter("@pkGeysers", SqlDbType.Int), _
                                                New SqlParameter("@Cancelled", SqlDbType.Bit), _
                                                New SqlParameter("@Liter", SqlDbType.NVarChar), _
                                                New SqlParameter("@Fabrikaat", SqlDbType.NVarChar), _
                                                New SqlParameter("@Model", SqlDbType.NVarChar), _
                                                New SqlParameter("@Premie", SqlDbType.Money), _
                                                New SqlParameter("@Waarde", SqlDbType.Money), _
                                                New SqlParameter("@fkGeyserTipe", SqlDbType.Int), _
                                                New SqlParameter("@DatumWysig", SqlDbType.Date), _
                                                New SqlParameter("@Type", SqlDbType.NVarChar)}


                params(0).Value = Now
                'pkHuis()  'Kobus Visse 14/03/2013 change huis_e.pkHuis
                params(1).Value = pkHuis

                If type = "Add" Then
                    params(2).Value = 0
                Else
                    params(2).Value = geyser.pkGeysers
                End If

                params(3).Value = 0
                params(4).Value = Me.txtLiter.Text & ""
                ' params(5).Value = Me.txtFabrikaat.Text & ""
                If Trim(txtFabrikaat.Text) = "" Then
                    params(5).Value = ""
                Else
                    params(5).Value = Trim(txtFabrikaat.Text)
                End If
                params(6).Value = Me.txtModel.Text & ""
                params(7).Value = Me.txtPremie.Text
                params(8).Value = Me.txtWaarde.Text

                If Me.cmbItemTipe.SelectedIndex = -1 Then

                    params(9).Value = 0
                Else
                    params(9).Value = (cmbItemTipe.SelectedIndex) + 1
                    'params(9).Value = (cmbItemTipe.Items.Add(Me.cmbItemTipe, (cmbItemTipe.SelectedIndex)+1)
                End If
                params(10).Value = Now
                params(11).Value = type

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateGeysers", params)
                conn.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
        If validateForm() Then
            'geyser = FetchGeyserByPrimary()

            If pkGeysers = 0 Then
                updateGeyser("Add")
                'Kobus 11/11/2013 voegby
                blnediting = True
                blnPremiumAfterGeyserAdd = True
            Else
                updateGeyser("Edit")

            End If

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@fkHuis", SqlDbType.Int)
                param.Value = pkHuis   'Kobus Visser 14/03/2013 change huis_e.pkHuis
                'Kobus 11/11/2013 voegby
                blnediting = True
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchTotalPremies", param)

                If reader.Read Then
                    updateHuis(reader("Totpremie"), reader("TotWaarde"))
                    'Kobus 16/09/2013 verander van Huis_EF.txtWaardeEkstras.Text = reader("TotWaarde")
                    Huis_EF.txtWaardeEkstras.Text = Format(Val(reader("TotWaarde")), "#########")
                    Huis_EF.calcTotValue()
                    'Kobus Visser 19/03/2013 change to Format Val
                    Huis_EF.txtPremieEkstras.Text = Format(Val(reader("Totpremie")), "######0.00")
                    Huis_EF.calcPremium()
                End If
                conn.Close()
            End Using
            'Log alterations
            logAlterations()
            'Kobus 03/04/2014 voegby
            blnInformationChanged = True

            Huis_EF.PopulateGridGeysers()

            If blnPremiumAfterGeyserAdd = True Then
                Me.Close()
            Else
                Me.Close()
            End If
        End If
    End Sub
    Private Sub cmbItemTipe_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbItemTipe.SelectedIndexChanged
        blnInformationChanged = True
    End Sub
    Private Sub frmGeisers_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        'Set title for window
        'Kobus 10/10/2013 verander van Geiser na Geysers
        Me.Text = "     Geysers - " & Trim(Huis_EF.ADRES_H1.Text)
        'Hide date boxes for new items
        If pkGeysers = 0 Then
            Me.txtDatumIn.Visible = False
            Me.txtDatumWysig.Visible = False
            Me.lblStartDate.Visible = False
            Me.lblDateAmended.Visible = False
        Else
            Me.txtDatumIn.Visible = True
            Me.txtDatumWysig.Visible = True
            Me.lblStartDate.Visible = True
            Me.lblDateAmended.Visible = True
        End If
    End Sub
    Private Sub frmGeisers_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Kobus 11/11/2013 voegby
        blnPremiumAfterGeyserAdd = False
        'Set database
        If pkGeysers <> 0 Then
            geyser = FetchGeyserByPrimary(Huis_EF.GridGeisers.SelectedCells.Item(0).Value)

            Me.txtLiter.Text = geyser.Liter
            Me.txtFabrikaat.Text = geyser.Fabrikaat
            Me.txtModel.Text = geyser.Model
            Me.txtPremie.Text = geyser.Premie
            Me.txtDatumIn.Text = geyser.DatumIn
            Me.txtDatumWysig.Text = geyser.DatumWysig
            Me.txtWaarde.Text = geyser.Waarde

        Else
            Me.txtLiter.Text = ""
            Me.txtFabrikaat.Text = ""
            Me.txtModel.Text = ""
            Me.txtPremie.Text = ""
            Me.txtDatumIn.Text = ""
            Me.txtDatumWysig.Text = ""
            Me.txtWaarde.Text = ""
        End If

        'Populate combobox and set value from db
        'populateComboType(rsGeysers.Fields("fkGeyserTipe").Value)
        cmbItemTipe.SelectedText = ""
        If Persoonl.TAAL = 0 Then
            populateComboType(geyser.GeyserTipe, "ORDER BY afr")
        Else
            populateComboType(geyser.GeyserTipe, "ORDER BY Eng")
        End If
        'End If

        If pkGeysers = 0 Then
            populateComboType(0, "")
            Me.cmbItemTipe.SelectedIndex = -1
        End If
        blnInformationChanged = False
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
  
    'Populate the comboboxe with values and set selected from db
    Private Sub populateComboType(ByRef fk As Integer, ByRef type As String)
        cmbItemTipe.Items.Clear()
        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim param As New SqlParameter("@type", SqlDbType.NVarChar)

            param.Value = "ORDER BY Afr"

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchGeyserTipe", param)
            If Persoonl.TAAL = 0 Then
                cmbItemTipe.Items.Clear()
                Do While reader.Read

                    cmbItemTipe.Items.Add(reader("afr"))
                    'cmbItemTipe.Items.Add(reader("pkGeysertipe"))
                    'cmbItemTipe.Items.Add(New ListViewItem.ListViewSubItem(reader("afr"), reader("pkGeysertipe")))
                    'cmbItemTipe.Items.Add(cmbItemTipe.Items.Add(reader("afr"), reader("pkGeysertipe")))
                    If reader("pkGeysertipe") = fk Then
                        cmbItemTipe.Text = reader("afr")

                    End If
                Loop

                'rs.MoveNext()
            Else
                Do While reader.Read
                    'cmbItemTipe.Items.Add(New ListViewItem.ListViewSubItem(reader("eng"), reader("pkGeysertipe")))
                    cmbItemTipe.Items.Add(reader("eng"))
                    'cmbItemTipe.Items.Add(reader("pkGeysertipe"))
                    'cmbItemTipe.ItemData(cmbItemTipe.NewIndex) = rs("pkGeysertipe")
                    If reader("pkGeysertipe") = fk Then
                        cmbItemTipe.Text = reader("eng")

                    End If
                Loop
            End If
            conn.Close()
        End Using
    End Sub
    'Validate the information on the form
    Public Function validateForm() As Object
        'ItemTipe
        If Me.cmbItemTipe.SelectedIndex = -1 Then
            MsgBox("The item type must be entered.", MsgBoxStyle.Exclamation)
            Me.cmbItemTipe.Focus()

            validateForm = False
            Exit Function
        End If

        'Waarde
        If Trim(Me.txtWaarde.Text) = "" Then
            MsgBox("The Value of the item must be completed.", MsgBoxStyle.Exclamation)
            Me.txtWaarde.Focus()
            validateForm = False
            Exit Function
        End If

        If Not IsNumeric(Me.txtWaarde.Text) Then
            MsgBox("The Value of the item must be completed.", MsgBoxStyle.Exclamation)
            Me.txtWaarde.Focus()

            validateForm = False
            Exit Function
        End If

        If InStr(1, Me.txtWaarde.Text, ".") > 0 Then
            MsgBox("The Value of the item should not contain cents.", MsgBoxStyle.Exclamation)
            Me.txtWaarde.Focus()

            validateForm = False
            Exit Function
        End If

        'Premie
        If Trim(Me.txtPremie.Text) = "" Then
            MsgBox("The premium for the item must be completed. ", MsgBoxStyle.Exclamation)
            Me.txtPremie.Focus()
            validateForm = False
            Exit Function
        End If

        'Premie
        If Not IsNumeric(Me.txtPremie.Text) Then
            'Kobus Visser 14/03/2013 change message: The premium for the item must be a numeric integer.
            MsgBox("The premium for the item must be a numeric value.", MsgBoxStyle.Exclamation)
            Me.txtPremie.Focus()
            validateForm = False
            Exit Function
        End If
        validateForm = True
    End Function
    'Log the alterations done on the specific item
    Public Sub logAlterations()
        'Kobus 31/03/2014 voegby 
        If blnPol_Byvoeg Or blnByvoeg Then
            'Don't log alterations if a new policy
        Else
            'A new item was added
            'Kobus 29/10/2013 verander Huis na Eiendom en House na Property met hakkies in die hele sub
            If pkGeysers = 0 Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = "Geiser bygevoeg: (" & Me.cmbItemTipe.Text & ") (" & Me.txtFabrikaat.Text & ") (" & Me.txtModel.Text & ") (" & Me.txtWaarde.Text & ") (" & Me.txtPremie.Text & ") Eiendom: (" & Huis_EF.ADRES_H1.Text & ")"
                Else
                    BESKRYWING = "Geyser added: (" & Me.cmbItemTipe.Text & ") (" & Me.txtFabrikaat.Text & ") (" & Me.txtModel.Text & ") (" & Me.txtWaarde.Text & ") (" & Me.txtPremie.Text & ") Property: (" & Huis_EF.ADRES_H1.Text & ")"
                End If
                UpdateWysig((165), BESKRYWING)
            Else
                'Itemtipe
                If geyser.GeyserTipe <> geyser.GeyserTipe Then
                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = " Geiser wysig: Item tipe na (" & Me.cmbItemTipe.Text & ") Eiendom: (" & Huis_EF.ADRES_H1.Text & ")"
                    Else
                        BESKRYWING = " Geyser change: Item type to (" & Me.cmbItemTipe.Text & ") Property: (" & Huis_EF.ADRES_H1.Text & ")"
                    End If
                    UpdateWysig((165), BESKRYWING)
                End If

                'Fabrikaat()
                If txtFabrikaat.Text <> geyser.Fabrikaat Then
                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = " Geiser wysig: Fabrikaat vanaf (" & txtFabrikaat.Text & ") na (" & geyser.Fabrikaat & ") Eiendom: (" & Huis_EF.ADRES_H1.Text & ")"
                    Else
                        BESKRYWING = " Geyser change: Make from (" & txtFabrikaat.Text & ") to (" & geyser.Fabrikaat & ") Property: (" & Huis_EF.ADRES_H1.Text & ")"
                    End If
                    UpdateWysig((165), BESKRYWING)
                End If

                'Model()
                If txtModel.Text <> geyser.Model Then
                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = " Geiser wysig: Model vanaf (" & Format(txtModel.Text) & ") na (" & geyser.Model & ") Eiendom: (" & Huis_EF.ADRES_H1.Text & ")"
                    Else
                        BESKRYWING = " Geyser change: Model from (" & Format(txtModel.Text) & ") to (" & geyser.Model & ") Property: (" & Huis_EF.ADRES_H1.Text & ")"
                    End If
                    UpdateWysig((165), BESKRYWING)
                End If

                'Waarde()
                If txtWaarde.Text <> geyser.Waarde Then
                    If Persoonl.TAAL = 0 Then
                        'Kobus 09/10/2013 verander van Geiser wysig: Waarde vanaf (" & txtWaarde.Text & ") na (" & geyser.Waarde & ") Huis:" & Huis_EF.ADRES_H1.Text
                        BESKRYWING = " Geiser wysig: Waarde vanaf (" & geyser.Waarde & ") na (" & txtWaarde.Text & ") Eiendom: (" & Huis_EF.ADRES_H1.Text & ")"
                    Else
                        BESKRYWING = " Geyser change: Waarde from (" & geyser.Waarde & ") to (" & txtWaarde.Text & ") Property: (" & Huis_EF.ADRES_H1.Text & ")"
                    End If
                    UpdateWysig((165), BESKRYWING)
                End If

                'Premie()
                If txtPremie.Text <> geyser.Premie Then
                    If Persoonl.TAAL = 0 Then
                        ' Kobus 09/10/2013 verander van Geiser wysig: Premie vanaf (" & txtPremie.Text & ") na (" & geyser.Premie & ") Huis:" & Huis_EF.ADRES_H1.Text
                        BESKRYWING = " Geiser wysig: Premie vanaf (" & geyser.Premie & ") na (" & txtPremie.Text & ") Eiendom: (" & Huis_EF.ADRES_H1.Text & ")"
                    Else
                        BESKRYWING = " Geyser change: Premie from (" & geyser.Premie & ") to (" & txtPremie.Text & ") Property: (" & Huis_EF.ADRES_H1.Text & ")"
                    End If
                    UpdateWysig((165), BESKRYWING)
                End If
            End If 'if pkhuis = 0 then
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
                MsgBox("The characters and""""can not be used.", MsgBoxStyle.Information)
                KeyAscii = 0
            Case Else
                ' These are acceptable keystrokes
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub txtLiter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLiter.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar)) Then
                'do nothing
            Else
                e.Handled = True
                MsgBox("Liter: only numbers are allowed", _
                       MsgBoxStyle.Information, "Verify")
                txtLiter.Focus()
            End If
        End If
    End Sub
    Private Sub txtLiter_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtLiter.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub txtModel_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtModel.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub txtModel_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtModel.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case 34, 39
                ' Anything else is unacceptable, and should be ignored
                MsgBox("The characters and """" can not be used. ", MsgBoxStyle.Information)
                KeyAscii = 0
            Case Else
                ' These are acceptable keystrokes
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub txtPremie_Leave(sender As Object, e As System.EventArgs) Handles txtPremie.Leave
        'Kobus Visser 13/03/2013 change KeyPress Event to Leave Event
        Dim strTest As String
        strTest = txtPremie.Text
        If IsNumeric(strTest) Then
            'Do Nothing
        Else
            MsgBox("Premium: Use only numeric values", _
                   MsgBoxStyle.Information, "Verify")
            txtPremie.Focus()
        End If
    End Sub
    Private Sub txtPremie_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPremie.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub txtWaarde_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWaarde.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar)) Then
                'do nothing
            Else
                e.Handled = True
                'Kobus Visser 14/03/2013 change messege: Value: only numbers are allowed
                MsgBox("Value: Only whole numbers are allowed.", _
                       MsgBoxStyle.Information, "Verify")
                txtWaarde.Focus()
            End If
        End If
    End Sub

    Private Sub txtWaarde_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtWaarde.TextChanged
        blnInformationChanged = True
    End Sub
End Class