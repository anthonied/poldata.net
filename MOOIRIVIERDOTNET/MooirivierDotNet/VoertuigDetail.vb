Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Data.SqlClient
Imports DAL
Friend Class VoertuigDetail
    Inherits BaseForm
    Public blnAddnew As Boolean
    'Description: Form containing all information on a vehicle for selected policy
    '           : Update grid containing list of vehicles on form1
    Dim k As Integer
    Dim blnAnder As Boolean 'Selected vehicles' value for 'ander'
    'Dim sSql As String
    'Kobus 02/05/2013
    Dim blnInformationChanged As Boolean = False
    'Dim Loading As Boolean
    Dim strDittoAdress() As String
    Dim intStandaarditems As Integer
    Dim intTemp As Integer
    Dim strInputBx As String 'Temp for inputbox value
    Dim blnRequestPwd As Boolean
    Dim blnLoaded As Boolean
    Dim blnOrigAnder As Boolean
    Dim strBeskrywing As String
    Dim intItem As Integer
    'Kobus 22/04/2013 to use with closing event when cancel is used
    Public blnCancel As Boolean
    'Kobus voegby as tydelik om wysigings in geskiedenis te toets
    Dim strDiverseBesk As String
    'Kobus 24/07/2013 voegby om sekere btns te disable en enable
    Dim strPolicystatus As String
    Public strCurrentVehicle As String
    'Kobus 30/7/2013 voegby om by 'n nuwe voertuig ekstras te laai en Cancel events te trigger
    Public intPkVoertuigEkstras As Integer
    'Kobus 21/08/2013 voegby
    Dim intVorigeDekIndex As Integer
    'Kobus 22/08/2013 voegby - maak voorsiening vir geskiedenis by verwydering van ekstra
    Public strRemove As String
    'Kobus 23/08/2013 voegby - maak voorsiening by nuwe voertuig om ekstra te laai na all verpligte velde voltooi is
    Dim blnValidationOk As Boolean
    Dim dblPremieekstra As Double
    Dim dblWaardeekstra As Double
    'Kobus 29/08/2013 voegby - nodig waar meer as een ekstra verwyder word
    Public strExtrasDescription As String
    'Kobus 04/11/2013 voegby om Factory Std items te rëel
    Dim blnFactoryStanderd As Boolean
    Dim blnAddFactoryMulti As Boolean
    Dim blnDeleteFactoryMulti As Boolean
    Dim intfkVoertuieStandaard As Integer
    Dim lstPkFactoryStdDeleted As List(Of ComboBoxEntity) = New List(Of ComboBoxEntity)
    Dim lstPkFactoryStdAdd As List(Of ComboBoxEntity) = New List(Of ComboBoxEntity)
    Dim strType As String
    'Kobus 14/11/2013 voegby
    Dim intTipeDek As Integer
    Dim intWaardeVoertuig As Integer
    Dim decPremieVoertuig As Decimal
    Dim decPremie As Decimal
    Dim dblWaarde As Double
    'Kobus 10/12/2013 voegby - edit and new
    Dim blnNoExit As Boolean
    'Kobus 13/12/2013 voegby
    Dim blnNilvalueEkstra As Boolean = False
    'Kobus 28/01/2014 voegby om verandering van tipe dekking na third party te rëel
    Dim bln1stIdentification As Boolean = False
    'Kobus 30/01/2014 0m nulwaarde ekstras te reguleer by logalterations
    Dim blnNoRepeat1 As Boolean
    'Kobus 06/02/2014 voegby om BD kansellasie te hanteer
    Dim blnRestorTypeCover As Boolean
    Dim intpkVoertuie As Integer
    'Kobus 25/04/2014 voegby
    'Public strVoorstad As String
    'Kobus 29/04/2014 voegby
    Dim strPoskode As String
    'Kobus 13/05/2014 voegby
    Dim strWaardeTipe As String
    Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        'Kobus 13/05/2014 voegby
        If txtMaak.Text = "" Then
            blnCancel = True
            Me.Close()
            Exit Sub
        End If

        'Kobus 11/04/2014 voegby
        If strCurrentVehicle = "NewVehicleExtras" Then
            'Kobus 25/04/2014 comment out
            'CancelNewVehicle()
            blnCancel = True
            Me.Close()
            Exit Sub
        End If
        'Kobus 06/02/2014 voegby om nuwe voertuig te kanselleer voordat dit gestoor word
        If Not blnediting Then
            'Kobus 19/4/2014 voegby boodskap
            If MsgBox("Are you sure you want to cancel your changes?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                blnCancel = False
                blnInformationChanged = True
                Me.SSTab1.SelectedIndex = 2
                Me.txtPremieVoor.Focus()
                Exit Sub
            Else
                blnCancel = True
                blnInformationChanged = False
                Me.Close()
                Exit Sub
            End If
        End If

        'Kobus 19/4/2014 voegby
        If blnRestorTypeCover = True Then
            blnRestorTypeCover = False
        End If

        'Kobus 29/01/2014 voegby en comment out
        If strRemove = "Yes" Or strRemove = "Extra" Or strRemove = "Final" Or blnAddnew = True Then
            'Kobus 06/02/2014 voegby
            If txtWaarde.Text = "" Or txtWaarde.Text = "0" Then
                txtWaarde.Text = 0
            End If
            'Kobus 06/02/2014 voeg by
            blnCancel = True
            blnInformationChanged = True
            'Kobus 06/02/2014 comment out
            'SaveInformation()
            'InformationChanged = True
        End If

        'Kobus voegby - 'Kobus 07/04/2014 - tydelik - hierdie hele if is kokia
        If Not blnInformationChanged Then
            If GridEkstras.RowCount > 1 And cmbTipeDek.SelectedIndex = 2 And blnRestorTypeCover = True Then
                blnInformationChanged = True
                btnVerwyder.Enabled = True
                blnCancel = False
                Me.SSTab1.SelectedIndex = 7
                btnVerwyder.Focus()
                Exit Sub
            End If
            blnCancel = True
            Me.Close()
            Exit Sub
        End If
        'Kobus 21/08/2013 voeg by
        If blnInformationChanged And strPolicystatus = "Cancelled" Or strPolicystatus = "Gekanselleer" Then
            blnCancel = True
            Me.Close()
            Exit Sub
        End If
        If blnInformationChanged And strPolicystatus <> "Cancelled" Or strPolicystatus <> "Gekanselleer" Then
            If MsgBox("Are you sure you want to cancel your changes?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                blnCancel = False
                blnInformationChanged = True
                Me.SSTab1.SelectedIndex = 2
                Me.txtPremieVoor.Focus()
                Exit Sub
            Else
                'Kobus 08/04/2014 voegby om te verhoed dat die boodskap opkom by nuwe voertuie
                If blnPol_Byvoeg Or blnByvoeg Then
                    blnInformationChanged = False
                    'Kobus 10/04/2014 voegby
                    'Kobus 25/04/2014 comment out
                    'CancelNewVehicle()
                    blnCancel = True
                    Me.Close()
                    Exit Sub
                Else
                    'Kobus 06/02/2014 voegby om wysiging na BD terug te rol
                    'Kobus 07/02/2014 verander van If blnRestorTypeCover = True Then
                    If blnRestorTypeCover = True And strRemove = "" Then
                        bln1stIdentification = False
                        blnInformationChanged = False
                        blnCancel = True
                        Me.Close()
                        Exit Sub

                    End If


                End If

                'Kobus 06/02/2014 voegby
                If GridEkstras.RowCount > 1 And cmbTipeDek.SelectedIndex = 2 And blnRestorTypeCover = True Then
                    blnInformationChanged = True
                    btnVerwyder.Enabled = True
                    Me.SSTab1.SelectedIndex = 7
                    btnVerwyder.Focus()
                    Exit Sub
                End If
                'Kobus 08/04/2014 voegby om te verhoed dat die boodskap opkom by nuwe voertuie
                If blnPol_Byvoeg Or blnByvoeg Then
                    'skip
                Else
                    'Kobus 29/01/2014 voegby
                    If strRemove = "Extra" Or strRemove = "Yes" Or strRemove = "Final" Or blnNilvalueEkstra = True Or blnAddnew = True Then
                        'Kobus 07/02/2014 verander boodskap van MsgBox("Please restore exstras to original values.")
                        MsgBox("The removal of the extra(s) cannot be undone at this stage. Please restore extras to original state.")
                        blnInformationChanged = True
                        'Kobus 11/04/2014 voegby
                        SaveInformation()
                        'Kobus 11/04/2014 comment out
                        'Me.Close()
                        Exit Sub
                    Else
                        blnInformationChanged = False
                        blnCancel = True
                        Me.Close()
                        Exit Sub
                    End If
                    blnInformationChanged = False
                    blnCancel = True
                    Me.Close()
                    Exit Sub
                End If
            End If

            'Kobus 06/02/2014 voegby
            If GridEkstras.RowCount > 1 And cmbTipeDek.SelectedIndex = 2 Then
                blnInformationChanged = True
                btnVerwyder.Enabled = True
                Me.SSTab1.SelectedIndex = 7
                btnVerwyder.Focus()
                Exit Sub
            End If
            'Kobus 29/01/2014 voegby

        Else
            blnInformationChanged = False
            blnCancel = True
            Me.Close()
        End If
    End Sub
    Private Sub btnDittoVersekerde2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnDittoVersekerde2.Click
        Me.txtGereeldeBestuurder1.Text = Form1.TITEL.Text & ". " & Form1.VOORL.Text & " " & Form1.VERSEKERDE.Text
        If Trim(Form1.ID_NOM.Text) <> "" Then
            Me.txtGereeldeBestGebore1.Text = "19" & VB.Left(Trim(Form1.ID_NOM.Text), 2)
        End If
    End Sub
    Private Sub btnDiverseVoertuig_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnDiverseVoertuig.Click
        'Kobus 01/04/2014 voegby
        blnInformationChanged = True
        'Kobus 07/05/2013 add
        If blnediting Then
            If txtAnderBeskrywing.Text = "Auto Guide Vehicle" Then
                If MsgBox("Do you want to change a Auto guide Vechile to a Non Auto Guide Vehicle?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Me.txtMaak.Enabled = True
                    Me.txtBesk.Enabled = True
                    Me.txtJaar.Enabled = True
                    Me.txtKode.Text = ""
                    'Kobus 07/05/2013 change CStr(True)
                    Me.txtAnder.Text = True
                    Me.txtMaak.Focus()
                    'Kobus 19/04/2013 voegby And Not editing and change CStr(True)
                    'If Me.txtAnder.Text = True Then
                    'Kobus 10/04/2013 change message from: "The value of the vehicle must be revised where the classification of the vehicle is changed."
                    'If Not CBool(Me.txtAnder.Text) Then
                    MsgBox("Note" & Chr(13) & Chr(13) & "The value of the vehicle must be revised.", MsgBoxStyle.Information)
                    Me.SSTab1.SelectedIndex = 2
                    Me.txtWaardeVoertuig.Focus()
                    Exit Sub
                    'End If
                Else
                    blnInformationChanged = True
                    txtMaak.Focus()
                    Exit Sub
                End If
            End If
        Else
            Me.txtMaak.Enabled = True
            Me.txtBesk.Enabled = True
            Me.txtJaar.Enabled = True
            Me.txtKode.Text = ""
            'Kobus 07/05/2013 change CStr(True)
            Me.txtAnder.Text = True

            'Kobus 19/04/2013 voegby And Not editing and change CStr(True)
            'If Me.txtAnder.Text = True Then
            'Kobus 10/04/2013 change message from: "The value of the vehicle must be revised where the classification of the vehicle is changed."
            If Not CBool(Me.txtAnder.Text) Then
                MsgBox("Note" & Chr(13) & Chr(13) & "The value of the vehicle must be revised.", MsgBoxStyle.Information)
                Me.txtMaak.Focus()
                Exit Sub
            End If

        End If
    End Sub
    Private Sub btnEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnEdit.Click
        strType = "Edit"
        Try
            'Kobus 19/07/2013 voegby tipes moet nie verander by edit nie
            blnAddnew = False
            'Check for any extras for this vehicle

            If Me.DataVoertuieEkstras.Text = "" Then
                'Kobus Visser - 25/02/2013 - changed accessories to vehicle extras
                MsgBox("There are no vehicle extras to edit.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            'Set pk for vehicleEkstras
            ' GridEkstras.ColumnCount = 0
            If CInt(GridEkstras.SelectedRows(0).Cells(0).Value) = 0 Then
                pkVoertuieEkstra = 0
                MsgBox("You must select an item to edit.", MsgBoxStyle.Exclamation)
            Else
                blnAddnew = False
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                pkVoertuieEkstra = CInt(GridEkstras.SelectedRows(0).Cells(0).Value)

                VoertuigEkstras.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    'Show search form for vehicles
    Private Sub btnMotors_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnMotors.Click
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        'Kobus 01/04/2014 voegby
        blnInformationChanged = True
        VoertuigSearch.ShowDialog()
    End Sub
    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
        'If pkVoertuie = 0 And blnValidationOk = False Then
        '    blnNoExit = True
        '    validateForm()
        '    'InformationChanged = True
        '    'SaveInformation()
        '    Exit Sub
        'End If
        'Kobus 19/05/2014 voegby
        blnCancel = False
        'Kobus 02/04/2014 voegby
        If blnAddnew = True Then
            blnInformationChanged = True
        End If
        'Kobus 08/04/2014 voegby And pkVoertuie <> 0
        If blnInformationChanged = False And strRemove = "" And pkVoertuie <> 0 And blnValidationOk = True Then
            Me.Close()
        End If
        'Kobus 01/04/2014 Vervang ou teks
        If Val(txtPremieEkstras.Text) <> 0 And Val(txtWaardeEkstras.Text) = 0 Then
            'MsgBox("Make sure that the extras are restored to original values", MsgBoxStyle.Exclamation)
            txtPremieEkstras.Text = 0
        End If
        'Kobus 24/03/2014 voegby
        If Me.chkHuurkoop.CheckState And (Me.cmbHuurInstansie.SelectedIndex = -1 Or Me.cmbHuurInstansie.SelectedIndex = 0) Then
            MsgBox("Please select a Hire Purchase Institution.", MsgBoxStyle.Exclamation)
            blnInformationChanged = True
            'Kobus 09/06/2014 voegby
            blnValidationOk = False
            Me.SSTab1.SelectedIndex = 4
            Me.txtHuurNommer.Focus()
            blnNoExit = True
            Exit Sub
        Else
            'Kobus 12/05/2014 comment out
            'blnNoExit = False
        End If
        'Kobus 07/02/2014 voegby
        If blnRestorTypeCover = True And txtPremieEkstras.Text = 0 And GridEkstras.RowCount = 1 Then
            'Kobus 12/05/2014 voegby
            If blnValidationOk = False Then
                validateForm()
                If blnValidationOk = True Then
                Else
                    Exit Sub
                End If

            End If
            blnInformationChanged = True
            SaveInformation()
            blnInformationChanged = False
            blnCancel = False
            Me.Close()
            Exit Sub
        End If
        'Kobus 19/4/2014 voegby
        If cmbTipeDek.SelectedIndex = 2 And (Val(txtWaardeEkstras.Text) <> 0 Or Val(txtPremieEkstras.Text) <> 0) Then
            MsgBox("Type of cover is Third party. Remove all extras on vehicle.")
            blnInformationChanged = False
            blnediting = True
            Me.btnVoegby.Enabled = False
            Me.btnVerwyder.Enabled = True
            Me.SSTab1.SelectedIndex = 7
            Me.btnVerwyder.Focus()
            Exit Sub
        End If
        blnCancel = False
        'Kobus 15/11/2013 voegby
        'Kobus 27/01/2014 voegby om msg te aktiveer waar nil bedrag ekstas bestaan
        Dim blnExtra As Boolean
        blnExtra = False
        If GridEkstras.RowCount > 1 Then
            blnExtra = True
        End If
        'Kobus 30/01/2014 verander van If cmbTipeDek.SelectedIndex = 2 And (txtWaardeEkstras.Text <> 0 Or txtPremieEkstras.Text <> 0 Or blnExtra = True) Then
        If cmbTipeDek.SelectedIndex = 2 And blnExtra = True Then
            MsgBox("Type of cover is Third party. Remove all extras on vehicle.")
            'InformationChanged = False
            'editing = True
            bln1stIdentification = True
            Me.SSTab1.SelectedIndex = 7
            'Kobus 15/11/2013 voegby
            btnCancel.Enabled = False
            btnVoegby.Enabled = False
            Me.btnVerwyder.Enabled = True
            Me.btnVerwyder.Focus()
            Exit Sub
        End If
        If blnInformationChanged = True Then
            SaveInformation()
            If blnValidationOk = False Then
                Exit Sub
            End If
        Else
            If blnValidationOk = False Then
                Exit Sub
            End If
            'Kobus 26/03/2014 voegby
            'Kobus 01/04/2014 verander na
            BFUpdateItemsSubTotals(glbPolicyNumber)
            HerBereken_Premie()
            Me.Close()
        End If
    End Sub
    Private Sub UpdateglobalMotorSub()
        'Kobus 26/03/2014 skep om die opdatering van inligting op Form1 te doen
        Dim paramM() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar)}
        paramM(0).Value = glbPolicyNumber

        Dim readerM As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuieForPremie", paramM)
        dblMotor_sub = 0
        Do While readerM.Read
            dblMotor_sub = dblMotor_sub + Val(readerM("Premie"))
        Loop
        Dim paramH() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar)}
        paramH(0).Value = glbPolicyNumber

        Dim readerH As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchHuisByPolisno", paramH)
        dblHuise_Sub = 0
        Do While readerH.Read
            dblHuise_Sub = dblHuise_Sub + Val(readerH("Premie_he")) + Val(readerH("Premie_hb")) + Val(readerH("toe_premie")) + Val(readerH("eem_premie"))
        Loop
        Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar)}
        param(0).Value = glbPolicyNumber

        Dim readers As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAlleriskByPolisno", param)
        dblalle_sub = 0
        Do While readers.Read
            dblalle_sub = dblalle_sub + readers("Premie")
        Loop
    End Sub
    Private Sub btnPoskodeSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnPoskodeSearch.Click
        blnInformationChanged = True
        PoskodesSoek.txtFormToPopulate.Text = Me.Name
        PoskodesSoek.ShowDialog()
    End Sub
    Private Sub btnStdAddAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnStdAddAll.Click
        'Kobus 06/11/2013 voegby
        lstStdItmsSelected.DataSource = Nothing
        For Me.k = 1 To Me.lstStdItmsAvailable.Items.Count
            Me.lstStdItmsAvailable.SelectedIndex = 0
            btnStdAddOne_Click(btnStdAddOne, New System.EventArgs())
        Next
        'Kobus 04/11/2013 voegby
        blnInformationChanged = True
        blnFactoryStanderd = True
        blnAddFactoryMulti = True
    End Sub
    'Kobus 05/11/2013 comment alles uit en verander volgens nuwe kode
    Private Sub btnStdAddOne_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnStdAddOne.Click
        Dim lstAvailable As List(Of ComboBoxEntity) = New List(Of ComboBoxEntity)

        'Dim lstnewlist As List(Of ComboBoxEntity) = New List(Of ComboBoxEntity)
        Dim intCount As Integer
        Dim itemAvailable As ComboBoxEntity = New ComboBoxEntity

        'Move selected item to selected list box
        If Me.lstStdItmsAvailable.SelectedIndex <> -1 Then
            lstAvailable = lstStdItmsAvailable.DataSource
            itemAvailable = lstStdItmsAvailable.SelectedItem
            lstAvailable.Remove(lstStdItmsAvailable.SelectedItem)

            intCount = lstAvailable.Count
            lstStdItmsAvailable.DataSource = Nothing
            lstStdItmsAvailable.Refresh()
            lstStdItmsAvailable.DataSource = lstAvailable
            lstStdItmsAvailable.DisplayMember = "ComboBoxName"
            lstStdItmsAvailable.ValueMember = "ComboBoxId"
            lstStdItmsAvailable.SelectedIndex = -1
            lstStdItmsAvailable.Refresh()
            Dim lstselected As List(Of ComboBoxEntity) = New List(Of ComboBoxEntity)
            If lstStdItmsSelected.DataSource Is Nothing Then

            Else
                lstselected = lstStdItmsSelected.DataSource
            End If

            lstselected.Add(itemAvailable)
            lstStdItmsSelected.DataSource = Nothing
            lstStdItmsSelected.Refresh()
            lstStdItmsSelected.DataSource = lstselected
            lstStdItmsSelected.DisplayMember = "ComboBoxName"
            lstStdItmsSelected.ValueMember = "ComboBoxID"
            lstStdItmsSelected.Refresh()

            lstPkFactoryStdAdd.Add(itemAvailable)
            'Me.lstStdItmsSelected.Items.Add(Me.lstStdItmsAvailable.SelectedItem)  'lstStdItmsAvailable & Me.lstStdItmsAvailable.SelectedIndex & Me.lstStdItmsAvailable & Me.lstStdItmsAvailable.SelectedIndex)
            ''Me.lstStdItmsAvailable.Items.Remove(Me.lstStdItmsAvailable.SelectedItem)
            'Me.lstStdItmsAvailable.Items.RemoveAt(Me.lstStdItmsAvailable.SelectedIndex)
            blnInformationChanged = True
            blnFactoryStanderd = True
        Else
            MsgBox("Select an item to add.", MsgBoxStyle.Exclamation)
        End If
        'populateLstStdItmsSelected()
        blnInformationChanged = True
        blnFactoryStanderd = True
        blnAddFactoryMulti = False
    End Sub

    Private Sub btnStdRemoveAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnStdRemoveAll.Click
        For Me.k = 1 To Me.lstStdItmsSelected.Items.Count
            Me.lstStdItmsSelected.SelectedIndex = 0
            btnStdRemoveOne_Click(btnStdRemoveOne, New System.EventArgs())
            'Kobus 04/11/2013 voegby
            blnInformationChanged = True
            blnFactoryStanderd = True
            blnDeleteFactoryMulti = True
        Next
    End Sub
    Private Sub btnStdRemoveOne_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnStdRemoveOne.Click
        Dim lstSelected As List(Of ComboBoxEntity) = New List(Of ComboBoxEntity)
        'Dim lstnuwelys As List(Of ComboBoxEntity) = New List(Of ComboBoxEntity)
        Dim intTeller As Integer
        Dim item As ComboBoxEntity = New ComboBoxEntity

        'Remove selected item from list
        If Me.lstStdItmsSelected.SelectedIndex <> -1 Then
            'Me.lstStdItmsAvailable.Items.Add(Me.lstStdItmsAvailable.SelectedValue)
            lstSelected = lstStdItmsSelected.DataSource
            item = lstStdItmsSelected.SelectedItem
            lstSelected.Remove(lstStdItmsSelected.SelectedItem)

            intTeller = lstSelected.Count
            lstStdItmsSelected.DataSource = Nothing
            lstStdItmsSelected.Refresh()
            lstStdItmsSelected.DataSource = lstSelected
            lstStdItmsSelected.DisplayMember = "ComboBoxName"
            lstStdItmsSelected.ValueMember = "ComboBoxID"
            lstStdItmsSelected.SelectedIndex = -1
            lstStdItmsSelected.Refresh()

            lstSelected = lstStdItmsAvailable.DataSource
            lstSelected.Add(item)
            lstStdItmsAvailable.DataSource = Nothing
            lstStdItmsAvailable.Refresh()
            lstStdItmsAvailable.DataSource = lstSelected
            lstStdItmsAvailable.DisplayMember = "ComboBoxName"
            lstStdItmsAvailable.ValueMember = "ComboBoxID"
            lstStdItmsAvailable.Refresh()

            lstPkFactoryStdDeleted.Add(item)
            ' Me.lstStdItmsAvailable.Items.Add(Me.lstStdItmsSelected.SelectedItem)
            'Me.lstStdItmsSelected.Items.RemoveAt(Me.lstStdItmsSelected.SelectedIndex)
            blnInformationChanged = True
            'Kobus 04/11/2013 voegby
            blnFactoryStanderd = True
            'blnDeleteFactorySingle = True
            '  lstPkFactoryStdDeleted.Add(
            '  lstStdItmsSelected.
        Else
            MsgBox("Select an item to delete.", MsgBoxStyle.Exclamation)
        End If

    End Sub
    Sub UpdateDeletedField()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params() As SqlParameter = {New SqlParameter("@pkVoertuieEkstras", SqlDbType.Int), _
                                                 New SqlParameter("@Deleted", SqlDbType.TinyInt)}


                params(0).Value = GridEkstras.SelectedRows(0).Cells(0).Value
                If params(0).Value = Nothing Then
                    Exit Sub
                End If
                params(1).Value = 1

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdatevoertuieEkstras", params)
                conn.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Sub UpdatevoertuieWithEkstras(ByVal varPremieEkstras As Object, ByVal varWaardeEkstras As Object)

        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim params() As SqlParameter = {New SqlParameter("@pkVoertuie", SqlDbType.Int), _
                                                New SqlParameter("@PremieEkstras", SqlDbType.Money), _
                                                New SqlParameter("@WaardeEkstras", SqlDbType.Money)}


                params(0).Value = pkVoertuie

                params(1).Value = varPremieEkstras
                params(2).Value = varWaardeEkstras

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdatevoertuieWithEkstras", params)
                conn.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Private Sub btnVerwyder_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnVerwyder.Click
        Try

            blnediting = True
            'Kobus 27/01/2014 comment out
            'InformationChanged = True

            If GridEkstras.SelectedRows(0).Cells(0).Value = 0 Then
                pkVoertuieEkstra = 0

            Else
                pkVoertuieEkstra = CInt(GridEkstras.SelectedRows(0).Cells(0).Value)
                'Kobus 30/08/2013 voegby - nodig vir geskiedenis van ekstras waar meer as een ekstra verwyder word
                strExtrasDescription = GridEkstras.SelectedRows(0).Cells(1).Value & " (" & GridEkstras.SelectedRows(0).Cells(2).Value & ") (" & GridEkstras.SelectedRows(0).Cells(3).Value & ") (" & GridEkstras.SelectedRows(0).Cells(4).Value & ") (R " & GridEkstras.SelectedRows(0).Cells(5).Value & ") (R " & GridEkstras.SelectedRows(0).Cells(6).Value & ")"
                'Kobus 13/12/2013 voegby
                Dim strNiltest As String
                strNiltest = GridEkstras.SelectedRows(0).Cells(6).Value
                If Val(strNiltest) = 0 Then
                    blnNilvalueEkstra = True
                End If
            End If
            If pkVoertuieEkstra <> 0 Then
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim param As New SqlParameter("@fkVoertuie", SqlDbType.Int)
                    param.Value = Form1.dgvPoldataVoertuie.SelectedRows(0).Cells(0).Value

                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuieEkstrasTotals", param)

                    If MsgBox("Are you sure you want to delete the selected item?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        strRemove = "Yes"
                        'Set deleted field = 1 for selected record
                        UpdateDeletedField()
                        'Kobus 29/01/2014 voegby om multi verwydering te reguleer
                        'Kobus 29/01/2014 voeg kondisie by

                        'If blnNilvalueEkstra = True Then
                        '    'Kobus 29/01/2014 comment out 
                        '    'decPremie = txtPremie.Text
                        '    'dblWaarde = txtWaarde.Text
                        'Else
                        '    InformationChanged = True
                        '    SaveInformation()
                        'End If
                        'Kobus 29/01/2014 voegby om multi verwydering te reguleer
                        'Kobus 06/02/2014 voeg voorwaarde by
                        If cmbTipeDek.SelectedIndex = 2 Then
                            btnCancel.Enabled = False
                        End If
                        'Log alteration
                        blnInformationChanged = True
                        'Kobus 22/08/2013 voegby
                        VoertuigEkstras.logAlterations()
                        'Kobus 16/05/2014 comment out
                        'logAlterations()
                        'Kobus 30/01/2014 comment out
                        'FetchEkstras()

                    Else
                        'Kobus 29/01/2014 voegby
                        strRemove = False
                        SSTab1.SelectedIndex = 2
                        txtPremieVoor.Focus()
                        Exit Sub
                    End If
                    'Kobus 29/01/2014 comment out al die If Reader.Read
                    If reader.Read Then
                        VoertuigEkstras.EditVoertuieWithEsktras(reader("Totpremie"), reader("TotWaarde"))

                        'Populate values on Voertuig detail
                        populateEkstras()
                        'Kobus 28/01/2014 voegby om op huidige voertuig te bly
                        intpkVoertuie = pkVoertuie
                        PopulateGridEkstras()
                        pkVoertuie = intpkVoertuie

                    End If
                    conn.Close()
                End Using
            Else
                MsgBox("Please select an item to remove", MsgBoxStyle.Exclamation)
            End If

            'Kobus 28/01/2014 voegby
            If GridEkstras.RowCount > 1 Then
                'Kobus 07/02/2014 voeg kondisie by om BD gevalle te forseer om lys leeg te maak
                If cmbTipeDek.SelectedIndex = 2 Then
                    blnInformationChanged = False
                    blnCancel = False
                    btnCancel.Enabled = False
                Else
                    blnInformationChanged = True
                    btnCancel.Enabled = True
                End If

                btnVerwyder.Enabled = True
                Me.SSTab1.SelectedIndex = 7
                btnVerwyder.Focus()
            Else

                'Kobus 29/01/2014 voegby
                blnInformationChanged = True
                'Kobus 07/02/2014 comment out om die geleentheid te gee om te wysigings op voertuig te kanselleer
                'SaveInformation()
                'Kobus 21/11/2013 voegby
                Me.SSTab1.SelectedIndex = 7
                btnCancel.Enabled = True
                'logAlterations() 'K 2014
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Sub FetchEkstras()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@pkVoertuieEkstras", SqlDbType.Int)
                param.Value = Form1.dgvPoldataVoertuie.SelectedRows(0).Cells(0).Value

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuieEkstrasByPrimaryKey", param)
                Do While reader.Read
                    If Persoonl.TAAL = 0 Then
                        strBeskrywing = GridEkstras.SelectedRows(0).Cells(1).Value & " " & reader("Fabrikaat") & " " & reader("Model") & " " & reader("serienommer") & " Voertuig: " & Me.txtNPlaat.Text
                    Else
                        strBeskrywing = GridEkstras.SelectedRows(0).Cells(1).Value & " " & reader("Fabrikaat") & " " & reader("Model") & " " & reader("serienommer") & " Vehicle: " & Me.txtNPlaat.Text
                    End If
                    UpdateWysig((172), strBeskrywing)
                Loop
                conn.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Sub ClearFields()
        'Kobus 05/08/2013 verander van False na True
        If blnAddnew = True Then
            VoertuigEkstras.txtFabrikaat.Text = ""
            VoertuigEkstras.txtModel.Text = ""
            VoertuigEkstras.txtBeskrywing.Text = ""
            'Kobus 01/08/2013 verander van ""
            VoertuigEkstras.txtPremie.Text = CDec(0)
            VoertuigEkstras.txtSerienommer.Text = ""
            VoertuigEkstras.txtWaarde.Text = CInt(0)
            VoertuigEkstras.txtDatumIn.Text = ""
            VoertuigEkstras.txtDatumWysig.Text = ""
            VoertuigEkstras.txtDatumIn.Enabled = False
            VoertuigEkstras.txtDatumWysig.Enabled = False
        End If
    End Sub
    Private Sub btnVoegby_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoegby.Click
        'pkVoertuieEkstras = 0
        blnAddnew = True
        Try
            'Kobus Visser 28/03/2013 change message from: This vehicle has not been saved to voorttegaan the vehicle is stored
            If Not blnediting Then
                'Kobus verander van If MsgBox("This vehicle has not been saved, to continue it has to be saved. " & Chr(13) & " Do you want to save it now?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If MsgBox("Prior to loading the extras, the vehicle information must be saved. " & Chr(13) & " Do you want to save it?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    blnInformationChanged = True
                    'Kobus voegby om huidige voertuiginligting te behou
                    strCurrentVehicle = "NewVehicleExtras"
                    'Kobus 12/08/2013 voegby
                    blnAddnew = True
                    SaveInformation()
                    blnInformationChanged = True
                    'ClearFields()
                    'Kobus 06/02/2014 comment out
                    'btnCancel.Enabled = False
                    VoertuigEkstras.ShowDialog()
                Else
                    blnAddnew = False
                    'Kobus 07/02/2014 voegby
                    blnInformationChanged = True
                    SSTab1.SelectedIndex = 2
                    txtPremieVoor.Focus()
                    Exit Sub
                End If
            Else
                blnAddnew = True

                pkVoertuieEkstra = CInt(GridEkstras.SelectedRows(0).Cells(0).Value)
                'Kobus 12/08/2013 voegby
                'ClearFields() word by fetch ekstras gedoen
                blnInformationChanged = True
                'Kobus 30/01/2014 voegby
                'SaveInformation()
                VoertuigEkstras.ShowDialog()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub chkHuurkoop_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkHuurkoop.CheckStateChanged
        blnInformationChanged = True
        If Me.chkHuurkoop.CheckState Then
            Me.cmbHuurInstansie.Enabled = True
            'Kobus 24/03/2014 voegby
            blnNoExit = False
            Me.SSTab1.SelectedIndex = 4
            Me.txtHuurNommer.Focus()
            Exit Sub
            'Kobus 10/09/2013 - veld is disabled en onsigbaar
            'Me.txtHuurNommer.Enabled = True
        Else
            Me.cmbHuurInstansie.SelectedIndex = -1
            'Me.txtHuurNommer.Text = ""
            Me.cmbHuurInstansie.Enabled = False
            'Me.txtHuurNommer.Enabled = False
            blnNoExit = False
        End If
    End Sub
    Private Sub chkIngevoer_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkIngevoer.CheckStateChanged
        blnInformationChanged = True
    End Sub
    Private Sub chkLaeProfielBande_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkLaeProfielBande.CheckStateChanged
        blnInformationChanged = True
    End Sub
    Private Sub chkMotorHuis_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkMotorHuis.CheckStateChanged
        blnInformationChanged = True
        If Me.chkMotorHuis.CheckState Then
            Me.txtOornagBeskrywing.Visible = False
            Me.lblOornagBeskrywing.Visible = False
        Else
            Me.txtOornagBeskrywing.Visible = True
            Me.lblOornagBeskrywing.Visible = True
        End If
    End Sub
    Private Sub chkMotorplan_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkMotorplan.CheckStateChanged
        blnInformationChanged = True
        If Me.chkMotorplan.CheckState Then
            Me.lblMotorplandat.Visible = True
            Me.lblMotorplankm.Visible = True
            Me.lblMotorplanverval.Visible = True
            Me.txtMotorplanKm.Visible = True
            Me.txtMotorplanVervalDat.Visible = True
        Else
            Me.lblMotorplandat.Visible = False
            Me.lblMotorplankm.Visible = False
            Me.lblMotorplanverval.Visible = False
            Me.txtMotorplanKm.Visible = False
            Me.txtMotorplanVervalDat.Visible = False
        End If
    End Sub
    Private Sub chkOnder25_Click()
        blnInformationChanged = True
    End Sub
    Private Sub chkSekuriteit_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkSekuriteit.CheckStateChanged
        Dim Index As Short = chkSekuriteit.GetIndex(eventSender)
        blnInformationChanged = True
    End Sub
    Private Sub chkVssRatingJN_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkVssRatingJN.CheckStateChanged
        blnInformationChanged = True
    End Sub
    Private Sub cmbDitto_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbDitto.SelectedIndexChanged
        If Trim(cmbDitto.Text) = "" Then
            Me.txtAdres.Text = ""
            Me.txtAdres2.Text = ""
            Me.txtVoorstad.Text = ""
            Me.txtStad.Text = ""
            Me.txtPoskode.Text = ""
        Else
            'Kobus 22/04/2014 voegby
            Me.txtStad.Enabled = True
            strDittoAdress = Split(Me.cmbDitto.Text, "|")
            Me.txtAdres.Text = Trim(strDittoAdress(0))
            Me.txtAdres2.Text = Trim(strDittoAdress(1))
            Me.txtVoorstad.Text = Trim(strDittoAdress(2))
            Me.txtStad.Text = Trim(strDittoAdress(3))
            Me.txtPoskode.Text = Trim(strDittoAdress(4))
            'Kobus 22/04/2013 add
            blnInformationChanged = True
            'Kobus 25/04/2014 voegby
            If txtVoorstad.Text <> "" And txtStad.Text = "" Then
                'strVoorstad = txtVoorstad.Text
                strPoskode = txtPoskode.Text
                GetPoskodeAdres(strPoskode)
            End If
        End If
    End Sub
    Private Sub btnDittoVersekerde_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnDittoVersekerde.Click
        Me.txtEienaar.Text = Form1.TITEL.Text & ". " & Form1.VOORL.Text & " " & Form1.VERSEKERDE.Text
    End Sub
    Private Sub cmbGebruik_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbGebruik.SelectedIndexChanged
        blnInformationChanged = True
    End Sub
    Private Sub cmbHuurInstansie_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbHuurInstansie.SelectedIndexChanged
        blnInformationChanged = True
    End Sub
    Private Sub cmbMotorStatus_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbMotorStatus.SelectedIndexChanged
        blnInformationChanged = True
        If Not blnLoading Then
            'When kode3 is selected, the suminsured must default to marketvalue - 30%
            If Me.cmbMotorStatus.SelectedIndex = 2 Then 'Kode 3
                'Kobus 11/09/2013 verander 
                ' MsgBox("When the motor status Code 3 is specified, the value must be adjusted to ensure after-market or sales value - 30%, as determined by the branch manager is.", MsgBoxStyle.Information)
                Me.cmbWaardeTipe.SelectedIndex = 2 'Ooreengekomewaarde
                MsgBox("You selected the status as Code 3. The value should be adjusted to market or resell value minus 30% as determined by the branch manager. You must calculate it and enter the correct value.", MsgBoxStyle.Exclamation)
                Me.SSTab1.SelectedIndex = 2
                Me.txtWaardeVoertuig.Focus()
            End If
        End If
    End Sub
    Private Sub cmbTipe_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbTipe.SelectedIndexChanged
        blnInformationChanged = True

        If Me.cmbTipe.SelectedIndex = 6 Then 'Ander/Other
            'Kobus Visser - 14/02/2013 verander The vehicle type other cannot be specified.
            'Kobus 11/09/2013 verander van "To add a new vehicle type contact your Administrator" na
            MsgBox("(Other) can't be used.", MsgBoxStyle.Exclamation)
            cmbTipe.SelectedIndex = -1
        End If

    End Sub

    Private Sub cmbTipeDek_DropDown(sender As Object, e As System.EventArgs) Handles cmbTipeDek.DropDown
        intVorigeDekIndex = cmbTipeDek.SelectedIndex
    End Sub
    Private Sub cmbTipeDek_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbTipeDek.SelectedIndexChanged
        Try

            blnInformationChanged = True
            'Kobus 30/01/2014 voegby
            If cmbTipeDek.SelectedIndex = 2 Then '3rd Party
                blnRestorTypeCover = True
                bln1stIdentification = True
                'Kobus 08/05/2014 voegby
                btnVoegby.Enabled = False
                btnEdit.Enabled = False
                btnVerwyder.Enabled = False

            Else
                bln1stIdentification = False
            End If

            If Not blnLoading Then
                If cmbTipeDek.SelectedIndex = 2 Then '3rd party
                    'Kobus 07/08/2013 voegby
                    If pkVoertuie = 0 Then
                        'Kobus 09/04/2013 change message from: "Verwyder asseblief ook die Voertuig bykomstighede (Waar van toepassing)."
                        MsgBox("Since only 3rd party coverage is selected, the value of the vehicle is made ​​zero.", MsgBoxStyle.Exclamation)
                    Else
                        'Kobus 09/04/2013 change message from: "Verwyder asseblief ook die Voertuig bykomstighede (Waar van toepassing)."
                        MsgBox("Since only 3rd party coverage is selected, the value of the vehicle is made ​​zero.", MsgBoxStyle.Exclamation)
                    End If
                    'Kobus 31/07/2013 verander van Cstr(0) na CInt(0)
                    Me.txtWaardeVoertuig.Text = CDec(0)
                    'Kobus 22/08/2013
                    Me.txtWaarde.Text = 0
                    'Kobus 05/08/2013 verander Me.txtWaardeVoertuig.Enabled = False
                    Me.txtWaardeVoertuig.Enabled = False
                    Me.cmbWaardeTipe.Enabled = False
                    blnInformationChanged = True
                    'Kobus 07/082013 uncomment - skuif na Tab Enter Ekstras
                    'Me.btnVoegby.Enabled = False
                    txtPersentasieWaarde.Enabled = False
                    lblPercentage.Enabled = False
                    'Kobus 06/02/2014 voegby om exteras te rëel by BD gevalle
                    btnVoegby.Enabled = False
                    btnVerwyder.Enabled = True
                    Me.btnVoegby.Enabled = False
                    Me.SSTab1.SelectedIndex = 2
                    Me.txtPremieVoor.Focus()
                    'Kobus voegby
                Else
                    'Kobus 06/05/2014 voegby
                    Me.btnVoegby.Enabled = True
                    Me.btnEdit.Enabled = True
                    Me.btnVerwyder.Enabled = True
                    If cmbTipeDek.SelectedIndex = 2 Then '3rd party
                        Me.btnVoegby.Enabled = False
                        Me.btnVerwyder.Enabled = False
                        Me.btnEdit.Enabled = False
                    End If
                    'Kobus 14/08/2013 comment in
                    Me.txtWaardeVoertuig.Enabled = True
                    Me.cmbWaardeTipe.Enabled = True

                    '    ElseIf cmbTipeDek.Text = "Comprehensive" Then
                    '    cmbTipeDek.SelectedIndex = 0
                    '    ElseIf cmbTipeDek.Text = "Balance, Third party, Fire & Theft" Then
                    '    cmbTipeDek.SelectedIndex = 1
                    'End If
                    Me.SSTab1.SelectedIndex = 2
                    Me.txtWaardeVoertuig.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    'Kobus 10/04/2013 add
    Private Sub clearvehicle()
        Me.txtWaardeVoertuig.Enabled = True
        Me.cmbWaardeTipe.Enabled = True
        Me.btnVoegby.Enabled = True
        Me.txtWaarde.Text = 0
        intVorigeDekIndex = -1
    End Sub

    Private Sub cmbWaardeTipe_Click(sender As Object, e As System.EventArgs) Handles cmbWaardeTipe.Click
        'Kobus 02/09/2014 voegby
        Me.txtWaardeVoertuig.Enabled = True
    End Sub
    Private Sub cmbWaardeTipe_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbWaardeTipe.SelectedIndexChanged
        Try
            'Kobus 12/05/2014 voegby - wysigings moet voortaan in geskiedenis skryf
            If pkVoertuie <> 0 Then
                blnInformationChanged = True
            End If

            If Not blnLoading Then
                blnInformationChanged = True
                Me.txtPersentasieWaarde.Enabled = False
                Me.optMark.Visible = False
                Me.optNuut.Visible = False
                Me.optKoop.Visible = False
                Me.optInruil.Visible = False
                Me.lblPercentage.Visible = False

                Select Case cmbWaardeTipe.SelectedIndex
                    Case 0 'Market value
                        'Kobus 4/07/13 change from CStr(Val(Me.txtValueMarket.Text)
                        'Kobus 31/07/2013 verander Me.txtWaardeVoertuig.Text = FormatNumber(Me.txtValueMarket.Text, 0)
                        'Kobus 05/08/2013 verander van
                        'Me.txtWaardeVoertuig.Text = CInt(Me.txtValueMarket.Text)
                        'Kobus 21/11/2013 voegby
                        Me.txtWaardeVoertuig.Text = CDec(Me.txtValueMarket.Text)
                        Me.txtPersentasieWaarde.Enabled = False
                        Me.lblPercentage.Visible = False
                        Me.SSTab1.SelectedIndex = 2
                        Me.txtWaardeVoertuig.Focus()
                    Case 1 'Resell value
                        'Kobus 4/07/13 change from CStr(Val(Me.txtKoop.Text))
                        'Kobus 31/07/2013  Me.txtWaardeVoertuig.Text = FormatNumber(Me.txtKoop.Text, 0)
                        'Kobus 05/08/2013 verander van
                        'Me.txtWaardeVoertuig.Text = CInt(Me.txtKoop.Text)
                        Me.txtWaardeVoertuig.Text = CDec(Me.txtKoop.Text)
                        'Kobus 21/11/2013 voegby - 24/01/2014 comment ou
                        'Me.txtWaardeVoertuig.Text = CDec(Me.txtValueMarket.Text)
                        Me.txtPersentasieWaarde.Enabled = False
                        Me.lblPercentage.Visible = False
                        Me.SSTab1.SelectedIndex = 2
                        Me.txtWaardeVoertuig.Focus()
                    Case 2 'Value agreed upon
                        'Kobus 31/07/2013 verander Cstr(0) na Cint
                        'Kobus 06/08/2013 verander van CInt(0) na 0
                        Me.txtWaardeVoertuig.Text = 0
                        'Kobus 09/04/2014 comment out
                        ''Kobus 21/11/2013 voegby
                        'Me.txtWaardeVoertuig.Text = CDec(Me.txtValueMarket.Text)
                        Me.txtPersentasieWaarde.Enabled = False
                        Me.lblPercentage.Visible = False
                        Me.SSTab1.SelectedIndex = 2
                        Me.txtWaardeVoertuig.Focus()
                    Case 3 'Percentage of selected value
                        'A password is necessary to complete this action - hardcoded for now
                        '               frmPassword.lblMessage.Text = "Please label the property value specified by the password fields."
                        frmPassword.ShowDialog()
                        If pwdEntered = "passmeby" Then
                            blnInformationChanged = True
                            Me.txtPersentasieWaarde.Enabled = True
                            Me.optMark.Visible = True
                            Me.optNuut.Visible = True
                            Me.optKoop.Visible = True
                            Me.optInruil.Visible = True
                            Me.lblPercentage.Visible = True
                            'Kobus 07/11/2013 voegby
                            Me.txtPersentasieWaarde.Focus()
                            Exit Sub
                            calcValue()
                        ElseIf pwdEntered <> "Cancelled" Then
                            MsgBox("Password is not correct.", MsgBoxStyle.Information)
                            cmbWaardeTipe.SelectedIndex = -1
                            Me.SSTab1.SelectedIndex = 2
                            Me.txtWaardeVoertuig.Focus()
                        Else
                            cmbWaardeTipe.SelectedIndex = -1
                            Me.SSTab1.SelectedIndex = 2
                            Me.txtWaardeVoertuig.Focus()
                        End If
                        'Kobus 23/08/2013 voegby
                        cmbWaardeTipe.SelectedIndex = -1
                        cmbWaardeTipe.Enabled = True
                        Me.SSTab1.SelectedIndex = 2
                        Me.txtWaardeVoertuig.Focus()
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub VoertuigDetail_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        Try
            'Kobus 19/05/2014 voegby
            If txtWaardeVoertuig.Text > 350000 Then
                txtWaardeVoertuig.Enabled = False
            End If
            'Kobus 29/11/2013 voegby
            'Kobus 28/01/2014 voegby kondisie
            If blnAddnew = True Then
                blnInformationChanged = True
                blnediting = True
            Else

                'InformationChanged = False
            End If
            ''Kobus 26/07/2013 voeg condisie by
            'If strCurrentVehicle = "NewVehicleExtras" Then
            '    'Do nothing
            'Else

            'Set title for window
            'Kobus 29/08/2013 Form1.POLISNO.Text met glbpolicynumber
            Me.Text = "     Vehicle detail - " & Form1.TITEL.Text & " " & Form1.VOORL.Text & " " & Form1.VERSEKERDE.Text & " (" & glbPolicyNumber & ")"

            'Kobus 08/07/2013 add to disable OK button when policy is cancelled
            strPolicystatus = Form1.GEKANS.Text

            'Set values from form1
            Me.txtArea.Text = Form1.AREA.Text
            'Kobus 24/7/2013 voegby
            'Kobus 12/11/2013 voegby
            'Kobus 12/05/2014 voegby And GridEkstras.RowCount > 1
            If cmbTipeDek.SelectedIndex = 2 And txtPremieEkstras.Text = 0 And GridEkstras.RowCount > 1 Then '3rd Party
                Me.btnVoegby.Enabled = False
                Me.btnVerwyder.Enabled = True
                Me.btnEdit.Enabled = False
                'Kobus 12/05/2014 voegby
                Exit Sub
            End If
            If cmbTipeDek.SelectedIndex = 2 And txtPremieEkstras.Text = 0 And GridEkstras.RowCount <= 1 Then
                Me.btnOk.Enabled = True
                Me.btnVoegby.Enabled = False
                Me.btnEdit.Enabled = False
                Me.btnVerwyder.Enabled = False
            End If
            'Kobus 12/05/2014 voegby
            If cmbTipeDek.SelectedIndex <> 2 Then
                Me.btnOk.Enabled = True
                Me.btnVoegby.Enabled = True
                Me.btnEdit.Enabled = True
                Me.btnVerwyder.Enabled = True
            End If
            If strPolicystatus = "Cancelled" Or strPolicystatus = "Gekanselleer" Then
                Me.btnOk.Enabled = False
                Me.btnVoegby.Enabled = False
                Me.btnEdit.Enabled = False
                Me.btnVerwyder.Enabled = False
            End If

            'Set focus
            If Not blnLoaded Then
                If Me.txtAnder.Text <> "" Then
                    If CBool(Me.txtAnder.Text) Then 'Diverse vehicle
                        Me.txtMaak.Focus()
                        Me.btnMotors.Enabled = False
                        Me.btnDiverseVoertuig.Enabled = False
                        'Default to value agreed upon as value type
                        Me.cmbWaardeTipe.SelectedIndex = 2 'Value agreed upon
                        Me.cmbWaardeTipe.Enabled = False
                    Else
                        Me.txtNPlaat.Focus()
                        Me.cmbWaardeTipe.Enabled = True
                    End If
                Else
                    Me.txtNPlaat.Focus()
                End If
            End If
            'Kobus 21/11/2013 voegby
            If Me.cmbWaardeTipe.SelectedIndex = 3 Then
                Me.txtPersentasieWaarde.Visible = True
                Me.txtPersentasieWaarde.Enabled = False
                Me.lblPercentage.Visible = True
                Me.lblPercentage.Enabled = False
                Me.optMark.Visible = False
                Me.optNuut.Visible = False
                Me.optKoop.Visible = False
                Me.optInruil.Visible = False
            End If
            'Kobus 18/11/2013 verander If Me.cmbWaardeTipe.SelectedIndex = 3 Then na
            'if Percentage of value selected - set controls to visible
            If Me.cmbWaardeTipe.SelectedIndex = 3 And blnInformationChanged = True And cmbTipeDek.SelectedIndex <> 2 Then
                Me.txtPersentasieWaarde.Visible = True
                Me.txtPersentasieWaarde.Enabled = True
                Me.optMark.Visible = True
                Me.optNuut.Visible = True
                Me.optKoop.Visible = True
                Me.optInruil.Visible = True
                Me.lblPercentage.Visible = True
                Me.lblPercentage.Enabled = True
            End If
            'Kobus 21/11/2013 voegby
            If Me.cmbWaardeTipe.SelectedIndex <> 3 Then
                Me.txtPersentasieWaarde.Visible = False
                Me.txtPersentasieWaarde.Enabled = False
                Me.lblPercentage.Visible = False
                Me.lblPercentage.Enabled = False
                'Me.optMark.Visible = False
                'Me.optNuut.Visible = False
                'Me.optKoop.Visible = False
                'Me.optInruil.Visible = False
            End If
            'Kobus 11/09/2013 verander Gebtitel na 
            If Gebruiker.titel = "Besigtig" Then
                Me.btnOk.Enabled = False
                Me.btnVoegby.Enabled = False
                Me.btnEdit.Enabled = False
                Me.btnVerwyder.Enabled = False
            End If
            'End If
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    'Kobus 22/01/2014 verwyder paramaters ByVal varEEU As String, ByVal varJaar As String
    Sub Read_A_Voertuig()
        voertuie = FetchVoertuie(pkVoertuie)
        Me.txtAnder.Text = voertuie.ANDER
        blnAnder = voertuie.ANDER
        blnOrigAnder = voertuie.ANDER
        'Kobus 22/01/14 - alles voor 'try' kom van die load event
        Me.txtJaar.Text = voertuie.EEU & voertuie.JAAR
        Me.txtNPlaat.Text = voertuie.N_PLAAT
        Me.txtKleur.Text = voertuie.kleur
        Me.cmbTipe.SelectedIndex = voertuie.TIPE - 1
        If IsDBNull(voertuie.motorstatus) Then
            Me.cmbMotorStatus.SelectedIndex = 0
        Else
            Me.cmbMotorStatus.Text = voertuie.motorstatus
        End If

        Me.cmbGebruik.SelectedIndex = voertuie.GEBRUIK - 1
        Me.txtKilometerLesing.Text = voertuie.kilometerlesing
        Me.txtEnjinNommer.Text = voertuie.enjinnommer
        Me.txtOnderstelNommer.Text = voertuie.onderstelnommer

        If IsDBNull(voertuie.CourtesyVehAmount) Then
            Me.txtCourtesyVehAmount.Text = CDec(0)
        Else
            Me.txtCourtesyVehAmount.Text = FormatNumber(voertuie.CourtesyVehAmount, 2)
        End If

        Me.txtKode.Text = CStr(voertuie.KODE)
        Me.cmbTipeDek.SelectedIndex = voertuie.TIPE_DEK - 1
        intTipeDek = Me.cmbTipeDek.SelectedIndex
        If cmbTipeDek.SelectedIndex = 2 Then '3rd Party
            Me.txtWaardeVoertuig.Text = 0
            Me.txtWaardeVoertuig.Enabled = False
            Me.cmbWaardeTipe.Enabled = False
            Me.btnVoegby.Enabled = False
            Me.btnVerwyder.Enabled = True 'K
            Me.btnEdit.Enabled = False
        End If

        Me.txtVSSRatingBesk.Text = voertuie.vssratingbesk

        Select Case Trim(voertuie.vssratingjn)
            Case ""
                Me.chkVssRatingJN.CheckState = System.Windows.Forms.CheckState.Unchecked
            Case "Ja"
                Me.chkVssRatingJN.CheckState = System.Windows.Forms.CheckState.Checked
            Case "Nee"
                Me.chkVssRatingJN.CheckState = System.Windows.Forms.CheckState.Unchecked

                Me.chkVssRatingJN.CheckState = System.Windows.Forms.CheckState.Unchecked
        End Select

        If IsDBNull(voertuie.huurinstansie) Then
            Me.cmbHuurInstansie.SelectedIndex = -1
        Else
            Me.cmbHuurInstansie.Text = Trim(voertuie.huurinstansie)
        End If
        If IsDBNull(voertuie.huurnommer) Then

            Me.txtHuurNommer.Text = ""
        Else
            Me.txtHuurNommer.Text = voertuie.huurnommer
        End If
        If IsDBNull(voertuie.waardetipe) Then
            Me.cmbWaardeTipe.SelectedIndex = -1
        Else
            Me.cmbWaardeTipe.SelectedIndex = voertuie.waardetipe
        End If
        'Kobus 13/05/2014 voegby
        strWaardeTipe = cmbWaardeTipe.Text
        Me.txtAdres.Text = voertuie.Adres
        Me.txtAdres2.Text = voertuie.adres2
        If Trim(voertuie.areabeskrywing) = "" Then
            Me.cmbAreaBeskrywing.SelectedIndex = -1
        Else
            Me.cmbAreaBeskrywing.Text = voertuie.areabeskrywing
        End If
        Me.cmbAreaFrekwensie.Text = voertuie.AreaFrekwensie
        Me.txtEienaar.Text = voertuie.eienaar
        Me.txtPoskode.Text = voertuie.Poskode
        Me.txtStad.Text = voertuie.stad
        Me.txtVoorstad.Text = voertuie.Voorstad
        'Kobus 25/04/2014 voegby
        If txtVoorstad.Text <> "" And txtStad.Text = "" Then
            'strVoorstad = txtVoorstad.Text
            strPoskode = txtPoskode.Text
            GetPoskodeAdres(strPoskode)

        End If

        If IsDBNull(voertuie.MotorHuis) Then
            Me.chkMotorHuis.CheckState = System.Windows.Forms.CheckState.Unchecked
        Else
            Me.chkMotorHuis.CheckState = voertuie.MotorHuis
        End If

        If IsDBNull(voertuie.ingevoer) Then
            Me.chkIngevoer.CheckState = System.Windows.Forms.CheckState.Unchecked
        Else
            Me.chkIngevoer.CheckState = voertuie.ingevoer
        End If

        If IsDBNull(voertuie.laeprofielbande) Then
            Me.chkLaeProfielBande.CheckState = System.Windows.Forms.CheckState.Unchecked
        Else
            Me.chkLaeProfielBande.CheckState = voertuie.laeprofielbande
        End If

        If IsDBNull(voertuie.motorplan) Then
            Me.chkMotorplan.CheckState = System.Windows.Forms.CheckState.Unchecked
        Else
            Me.chkMotorplan.CheckState = voertuie.motorplan
        End If
        chkMotorplan_CheckStateChanged(chkMotorplan, New System.EventArgs())
        If voertuie.Huurkoop = 0 Then
            Me.chkHuurkoop.CheckState = System.Windows.Forms.CheckState.Unchecked
        Else
            Me.chkHuurkoop.CheckState = System.Windows.Forms.CheckState.Checked
        End If
        Me.txtOornagBeskrywing.Text = voertuie.oornagbeskrywing
        Me.txtKmPerJaar.Text = voertuie.kmperjaar

        Me.txtGenomBestuurder1.Text = voertuie.genombestuurder1
        Me.txtGenomBestuurder2.Text = voertuie.genombestuurder2
        Me.txtGenomBestGebore1.Text = voertuie.genombestgebore1
        Me.txtGenomBestGebore2.Text = voertuie.genombestgebore2

        Me.txtGereeldeBestuurder1.Text = voertuie.gereeldebestuurder1
        Me.txtGereeldeBestuurder2.Text = voertuie.gereeldebestuurder2
        Me.txtGereeldeBestuurder3.Text = voertuie.gereeldebestuurder3
        Me.txtGereeldeBestuurder4.Text = voertuie.gereeldebestuurder4
        Me.txtGereeldeBestGebore1.Text = voertuie.gereeldebestgebore1
        Me.txtGereeldeBestGebore2.Text = voertuie.gereeldebestgebore2
        Me.txtGereeldeBestGebore3.Text = voertuie.gereeldebestgebore3
        Me.txtGereeldeBestGebore4.Text = voertuie.gereeldebestgebore4

        Me.txtKmLesingDatum.Text = voertuie.kmlesingdatum
        Me.txtMotorplanVervalDat.Text = voertuie.motorplanvervaldat
        If IsDBNull(voertuie.motorplankm) Then
            txtMotorplanKm.Text = 0
        Else
            Me.txtMotorplanKm.Text = voertuie.motorplankm
        End If
        Me.txtPersentasieWaarde.Text = Val(voertuie.persentasiewaarde)
        Me.txtPremiePersentasie.Text = Val(voertuie.PremiePersentasie)

        Me.txtPremieVoor.Text = Format(CDec(voertuie.premievoertuig), "######0.00")

        decPremieVoertuig = Me.txtPremieVoor.Text

        If IsDBNull(voertuie.premieekstras) Then
            Me.txtPremieEkstras.Text = 0
            dblPremieekstra = Me.txtPremieEkstras.Text
        Else
            Me.txtPremieEkstras.Text = Format(CDec(voertuie.premieekstras), "######0.00")
            If Me.txtPremieEkstras.Text = "" Then
                Me.txtPremieEkstras.Text = 0

            End If

            dblPremieekstra = Me.txtPremieEkstras.Text
        End If
        dblWaardeekstra = 0
        If IsDBNull(voertuie.WaardeEkstras) Then
            Me.txtWaardeEkstras.Text = 0
            If voertuie.WaardeEkstras = "" Then
                Me.txtWaardeEkstras.Text = 0
            End If
            dblWaardeekstra = 0
            dblWaardeekstra = txtWaardeEkstras.Text
        Else
            Me.txtWaardeEkstras.Text = Format(CDec(voertuie.WaardeEkstras), "########")
            If txtWaardeEkstras.Text = "" Then
                txtWaardeEkstras.Text = 0
            End If
            dblWaardeekstra = 0
            dblWaardeekstra = txtWaardeEkstras.Text
        End If

        If IsDBNull(voertuie.PREMIE) Then
            Me.txtPremie.Text = 0
        Else
            Me.txtPremie.Text = Format(CDec(voertuie.PREMIE), "########0.00")
        End If
        decPremie = Me.txtPremie.Text
        Me.txtPremieNaKorting.Text = Format(CDec(System.Math.Round(CDbl(Me.txtPremie.Text) * Persoonl.eispers, 2)), "########0.00")
        populateEkstras()
        If IsDBNull(voertuie.waardevoertuig) Then
            Me.txtWaardeVoertuig.Text = 0
        End If
        If voertuie.waardevoertuig = 0 Then
            Me.txtWaardeVoertuig.Text = 0
        Else

            Me.txtWaardeVoertuig.Text = Format(Val(voertuie.waardevoertuig), "########")
        End If
        intWaardeVoertuig = Me.txtWaardeVoertuig.Text
        If IsDBNull(voertuie.WAARDE) Then
            Me.txtWaarde.Text = 0
        Else
            Me.txtWaarde.Text = Format(Val(voertuie.WAARDE), "########")
            If Me.txtWaarde.Text = "" Then
                Me.txtWaarde.Text = 0
                blnInformationChanged = False
            End If
            dblWaarde = Me.txtWaarde.Text
        End If
        'Kobus 29/01/2014 comment out - maak geen sin
        'If txtPremieEkstras.Text = 0 And txtWaardeEkstras.Text <> 0 Then
        'End If

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@KODE", SqlDbType.NVarChar), _
                                               New SqlParameter("@EEU", SqlDbType.NVarChar), _
                                               New SqlParameter("@JAAR", SqlDbType.NVarChar)}

                'Kobus 22/01/14 skuif voertuie = FetchVoertuie(pkVoertuie) buite try lyn een van sub

                param(0).Value = voertuie.KODE
                param(1).Value = voertuie.EEU  'varEEU
                param(2).Value = voertuie.JAAR  'varJaar()

                Dim strTable As String

                'Kobus Visser - 07/02/2013 - keuse te maak tussen Diverse voertuie en M & Mc voertuie
                If txtAnder.Text = False Then
                    strTable = "poldata5.FetchMotorByKode"
                Else
                    strTable = "poldata5.FetchMotorKodeA_VOERTUIG"
                End If
                Dim readerMotor As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, strTable, param)

                Do While readerMotor.Read

                    txtMaak.Text = readerMotor("MAAK")
                    txtBesk.Text = readerMotor("BESK")
                    'Kobus 15/07/2013 - voegby
                    strDiverseBesk = txtBesk.Text

                    If Not blnAnder Then
                        'Kobus 28/08/2013 voeg voorwaarde by
                        If IsDBNull(readerMotor("EIND_DATUM")) Then
                            Me.txtEindDatum.Text = "N/A"
                        Else
                            Me.txtEindDatum.Text = readerMotor("EIND_DATUM")
                        End If

                        If Val(voertuie.EEU) & voertuie.JAAR < (Year(Now) - 15) Then
                            'Kobus 22/07/2013 verander van "n.v.t" na 0
                            Me.txtKoop.Text = 0
                            Me.txtInruil.Text = 0
                            Me.txtNuut.Text = 0
                            Me.txtValueMarket.Text = 0
                        Else
                            Me.txtKoop.Text = readerMotor("KOOP")
                            Me.txtInruil.Text = readerMotor("INRUIL")
                            Me.txtNuut.Text = readerMotor("NUUT")
                            'Kobus 11/7/2013 verander formatm van Me.txtValueMarket.Text = CStr(System.Math.Round((Val(readerMotor("KOOP")) + Val(readerMotor("INRUIL"))) / 2, 0))
                            Me.txtValueMarket.Text = System.Math.Round((Val(readerMotor("KOOP")) + Val(readerMotor("INRUIL"))) / 2, 0)
                        End If
                    End If
                Loop
                If cmbHuurInstansie.SelectedIndex <> -1 Then
                    Me.cmbHuurInstansie.Text = Trim(voertuie.huurinstansie)
                End If
                conn.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    'Kobus 03/09/2013 skep sub om diverse voertuie se beskrywing te kry vir logalteration
    Sub ReadAVoertuig(ByVal varEEU As String, ByVal varJaar As String, ByVal varKode As String)

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@KODE", SqlDbType.NVarChar)}
                'Kobus 07/11/2013 verwyder parm wat nie in die stordp is nie
                'New SqlParameter("@EEU", SqlDbType.NVarChar), _
                'New SqlParameter("@JAAR", SqlDbType.NVarChar)}


                voertuie = FetchVoertuie(pkVoertuie)
                'kobus 07/11/2013 verander van Trim(voertuie.KODE)
                param(0).Value = varKode
                'param(1).Value = varEEU
                'param(2).Value = varJaar

                Dim readerMotor As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAvoertuieByKode", param)

                Do While readerMotor.Read

                    txtMaak.Text = readerMotor("MAAK")
                    txtBesk.Text = readerMotor("BESK")
                Loop
                conn.Close()
            End Using
            strDiverseBesk = txtBesk.Text
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Public Sub SecurityItemsCaption()
        listSekuriteit = FetchSekuriteitList("Voertuig")
        Dim i As Integer
        For i = 0 To listSekuriteit.Count - 1
            Select Case listSekuriteit(i).Bit
                Case 0
                    _chkSekuriteit_0.Text = listSekuriteit(i).BeskrywingEngels
                    If listSekuriteit(i).BeskrywingEngels = "n.v.t." Or listSekuriteit(i).Sekuriteit = 12 Or listSekuriteit(i).Sekuriteit = 13 Or listSekuriteit(i).Sekuriteit = 14 Then
                        _chkSekuriteit_0.Enabled = False
                    End If
                Case 1
                    _chkSekuriteit_1.Text = listSekuriteit(i).BeskrywingEngels
                    If listSekuriteit(i).BeskrywingEngels = "n.v.t." Or listSekuriteit(i).Sekuriteit = 12 Or listSekuriteit(i).Sekuriteit = 13 Or listSekuriteit(i).Sekuriteit = 14 Then
                        _chkSekuriteit_1.Enabled = False
                    End If
                Case 2
                    _chkSekuriteit_2.Text = listSekuriteit(i).BeskrywingEngels
                    If listSekuriteit(i).BeskrywingEngels = "n.v.t." Or listSekuriteit(i).Sekuriteit = 12 Or listSekuriteit(i).Sekuriteit = 13 Or listSekuriteit(i).Sekuriteit = 14 Then
                        _chkSekuriteit_2.Enabled = False
                    End If
                Case 3
                    _chkSekuriteit_3.Text = listSekuriteit(i).BeskrywingEngels
                    If listSekuriteit(i).BeskrywingEngels = "n.v.t." Or listSekuriteit(i).Sekuriteit = 12 Or listSekuriteit(i).Sekuriteit = 13 Or listSekuriteit(i).Sekuriteit = 14 Then
                        _chkSekuriteit_3.Enabled = False
                    End If
                Case 4
                    _chkSekuriteit_4.Text = listSekuriteit(i).BeskrywingEngels
                    If listSekuriteit(i).BeskrywingEngels = "n.v.t." Or listSekuriteit(i).Sekuriteit = 12 Or listSekuriteit(i).Sekuriteit = 13 Or listSekuriteit(i).Sekuriteit = 14 Then
                        _chkSekuriteit_4.Enabled = False
                    End If
                Case 5
                    _chkSekuriteit_5.Text = listSekuriteit(i).BeskrywingEngels
                    If listSekuriteit(i).BeskrywingEngels = "n/a" Or listSekuriteit(i).Sekuriteit = 12 Or listSekuriteit(i).Sekuriteit = 13 Or listSekuriteit(i).Sekuriteit = 14 Then
                        _chkSekuriteit_5.Enabled = False
                    End If
                Case 6
                    _chkSekuriteit_6.Text = listSekuriteit(i).BeskrywingEngels
                    If listSekuriteit(i).BeskrywingEngels = "n/a" Or listSekuriteit(i).Sekuriteit = 12 Or listSekuriteit(i).Sekuriteit = 13 Or listSekuriteit(i).Sekuriteit = 14 Then
                        _chkSekuriteit_6.Enabled = False
                    End If
                Case 7
                    _chkSekuriteit_7.Text = listSekuriteit(i).BeskrywingEngels
                    If listSekuriteit(i).BeskrywingEngels = "n/a" Or listSekuriteit(i).Sekuriteit = 12 Or listSekuriteit(i).Sekuriteit = 13 Or listSekuriteit(i).Sekuriteit = 14 Then
                        _chkSekuriteit_7.Enabled = False
                    End If
            End Select
        Next
    End Sub
    Private Sub VoertuigDetail_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Kobus 25/04/2014 voegby
        blnCancel = False
        blnInformationChanged = False
        blnValidationOk = True
        Try
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            'Kobus 24/07/2013 add to disable OK button when policy is cancelled
            strPolicystatus = Form1.GEKANS.Text
            'Kobus 25/10/2013 voegby
            If Gebruiker.MMLicence = False Then
                txtM_M.Visible = True
                Me.btnMotors.Enabled = False
            Else
                txtM_M.Visible = False
                Me.btnMotors.Enabled = True
            End If

            'Kobus 24/7/2013 voegby
            'Set values from form1
            'Me.txtArea.Text = Form1.AREA.Text
            Me.btnOk.Enabled = True
            Me.btnVoegby.Enabled = True
            Me.btnEdit.Enabled = True
            Me.btnEdit.Enabled = True
            Me.btnVerwyder.Enabled = True
            'Kobusv 04/11/2013 voegby
            blnFactoryStanderd = False
            blnDeleteFactoryMulti = False
            blnAddFactoryMulti = False
            'Kobus 06/11/2013 voegby
            lstPkFactoryStdDeleted.Clear()
            lstPkFactoryStdAdd.Clear()
            'Kobus 18/11/2013 voegby
            'txtPersentasieWaarde.Visible = False
            'Kobus 07/02/2014 bring taalkwessie in
            If strPolicystatus = "Cancelled" Or strPolicystatus = "Gekanselleer" Then
                Me.btnOk.Enabled = False
                Me.btnVoegby.Enabled = False
                Me.btnEdit.Enabled = False
                Me.btnEdit.Enabled = False
                Me.btnVerwyder.Enabled = False
            End If
            SecurityItemsCaption()
            'Set loading flag
            blnLoading = True
            blnRequestPwd = True

            'Kobus 11/09/2013 verander Gebtitel na
            If Gebruiker.titel = "Besigtig" Then
                Me.btnOk.Enabled = False
                Me.btnVoegby.Enabled = False
                Me.btnEdit.Enabled = False
                Me.btnVerwyder.Enabled = False
            End If

            'Populate combo's
            populateComboBoxes()
            populateCmbWaardeTipe(False)

            'Set the security items' captions
            setSecurityItemsCaption()

            Using conn As SqlConnection = SqlHelper.GetConnection

                'Kobus 22/01/2014 - comment out
                'Dim param As New SqlParameter("@pkVoertuie", SqlDbType.NVarChar)
                'Kobus 29/07/2013 verander If editing na
                If strCurrentVehicle = "NewVehicleExtras" Then
                    pkVoertuie = intPkVoertuigEkstras
                    blnediting = True
                ElseIf blnediting And strCurrentVehicle <> "NewVehicleExtras" Then
                    pkVoertuie = Form1.dgvPoldataVoertuie.SelectedRows(0).Cells(0).Value

                ElseIf Not blnediting Then
                    pkVoertuie = 0

                End If

                If blnediting Then
                    Read_A_Voertuig()

                    'Kobus 22/01/2014 tot hier geskuif na Read_A_Voertuig
                    populateLstStdItmsAvailable()
                    populateLstStdItmsSelected()

                    'Security
                    setSecuritySelected((voertuie.SekuriteitBitValue))
                    PopulateGridEkstras()
                    'Kobus 25/04/2014 voegby
                    If voertuie.stad = "" And txtStad.Text <> "" Then
                        'continue
                    Else
                        blnInformationChanged = False
                    End If

                Else 'New record
                    ClearVoertuig()
                    Me.cmbTipe.SelectedIndex = 0
                    Me.cmbGebruik.SelectedIndex = 0
                    Me.cmbTipeDek.SelectedIndex = 0
                    'Me.cmbMotorStatus.SelectedIndex = 1
                    'Me.cmbHuurInstansie.SelectedIndex = 0
                    'Kobus 23/08/2013 wysig van 0 na -1
                    Me.cmbWaardeTipe.SelectedIndex = -1
                    'Kobus 31/07/2013 verander van CStr
                    Me.txtPremiePersentasie.Text = CInt(100)
                    'Kobus 31/07/2013 verander van CStr
                    Me.txtPersentasieWaarde.Text = CInt(100)
                    'Kobus 31/07/2013 verander van CStr
                    Me.txtPremieVoor.Text = CDec(0)
                    'Kobus 31/07/2013 verander van CStr
                    Me.txtWaardeEkstras.Text = CDec(0)
                    'Kobus 31/07/2013 verander van CStr
                    Me.txtPremieEkstras.Text = CDec(0)
                    'Kobus 07/08/2013 voegby
                    txtWaardeVoertuig.Enabled = True
                    txtWaardeVoertuig.Text = CDec(0)
                    Me.calcPremium()
                    populateLstStdItmsAvailable()
                    GridEkstras.DataSource = Nothing
                End If
                conn.Close()
            End Using


            PopulateCmbDitto()

            Me.SSTab1.SelectedIndex = 2

            'InformationChanged = False
            blnLoading = False
            blnLoaded = True

            _chkSekuriteit_6.Enabled = False
            _chkSekuriteit_7.Enabled = False

            'Kobus 07/08/2013 voegby
            If cmbTipeDek.SelectedIndex = 2 Then '3rd party
                Me.txtWaardeVoertuig.Enabled = False
                'Kobus 12/11/2013 voegby
                Me.btnVoegby.Enabled = False
                Me.btnVerwyder.Enabled = True 'K
                Me.btnEdit.Enabled = False

            End If

            GridEkstras.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            'Kobus 10/12/2013 voegby
            calcPremium()
            calcTotValue()
            'Kobus 25/04/2014 voegby
            blnInformationChanged = False
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
        'Kobus 16/05/2014 voegby
        blnInformationChanged = False
        'Kobus 19/05/2014 voegby
        If txtWaardeVoertuig.Text > 350000 Then
            txtWaardeVoertuig.Enabled = False
        End If
    End Sub
    Sub populateEkstras()

        Using conn As SqlConnection = SqlHelper.GetConnection

            Dim param As New SqlParameter("@fkVoertuie", SqlDbType.NVarChar)
            'Kobus 06/08/2013 voegby
            If strCurrentVehicle = "NewVehicleExtras" Then
                param.Value = pkVoertuie
            Else
                param.Value = Form1.dgvPoldataVoertuie.SelectedRows(0).Cells(0).Value
            End If

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuieEkstrasTotals", param)
            If reader.Read Then
                If IsDBNull(reader("TotPremie")) Then
                    'Kobus 25/07/2013 verander "0.00" na 0
                    Me.txtPremieEkstras.Text = 0
                Else
                    'Kobus 06/06/2013 change reader("TotPremie")
                    'Kobus 30/08/2013 verander van Me.txtPremieEkstras.Text = FormatNumber(reader("TotPremie"), 2)
                    'Kobus 02/09/2013 voegby
                    If Format(CDec(reader("TotPremie")), "########0.00") = "0.00" Then
                        Me.txtPremieEkstras.Text = Format(CDbl(dblPremieekstra), "########0.00")
                    Else
                        Me.txtPremieEkstras.Text = Format(CDec(reader("TotPremie")), "########0.00")
                    End If

                End If

                If IsDBNull(reader("TotWaarde")) Then
                    'Kobus 11/7/2013 verander van "0.00" na 0
                    Me.txtWaardeEkstras.Text = 0
                Else
                    'Kobus 11/09/2013 voegby
                    If Me.txtPremieEkstras.Text = 0 Then
                        Me.txtWaardeEkstras.Text = 0
                    Else
                        'Kobus 06/06/2013 change reader("TotWaarde")
                        'Kobus 11/7/2013 verander format van 'Me.txtWaardeEkstras.Text = FormatNumber(reader("TotWaarde"), 0)
                        Me.txtWaardeEkstras.Text = Format(CDec(reader("TotWaarde")), "########")
                    End If
                End If
            End If
            conn.Close()
        End Using

    End Sub
    Sub ClearVoertuig()
        Me.txtJaar.Text = ""
        Me.txtNPlaat.Text = ""
        Me.txtKleur.Text = ""
        Me.txtMaak.Text = ""
        Me.txtBesk.Text = ""
        Me.txtEindDatum.Text = ""
        'Kobus 18/07/2013 verander van "" .Clear
        'Kobus 22/07/2013 comment out
        'Me.txtKoop.Clear()
        'Me.txtInruil.Clear()
        'Me.txtNuut.Clear()
        'Me.txtValueMarket.Clear()
        'Kobus 18/07/2013 comment out - already done
        Me.txtKoop.Text = CInt(0)
        'Kobus 18/07/2013 comment out - already done
        Me.txtInruil.Text = CInt(0)
        'Kobus 18/07/2013 comment out - already done
        Me.txtNuut.Text = CInt(0)
        'Kobus 11/07/2013 comment out - already done
        Me.txtValueMarket.Text = CInt(0)
        Me.cmbMotorStatus.SelectedIndex = 0
        Me.cmbGebruik.SelectedIndex = -1
        'Kobus 18/07/2013 verander "" na 0
        Me.txtKilometerLesing.Text = 0
        Me.txtEnjinNommer.Text = ""
        Me.txtOnderstelNommer.Text = ""
        'Kobus 18/07/2013 verander "" na 0
        Me.txtCourtesyVehAmount.Text = 0
        Me.txtKode.Text = ""
        Me.txtPremieVoor.Text = 0
        Me.txtPremieEkstras.Text = 0
        Me.txtPremie.Text = 0
        Me.txtPremieNaKorting.Text = 0
        Me.txtWaardeEkstras.Text = 0
        Me.txtWaardeVoertuig.Text = 0
        Me.txtWaarde.Text = 0
        Me.txtVSSRatingBesk.Text = ""
        Me.txtOornagBeskrywing.Text = ""
        Me.txtKmPerJaar.Text = ""
        Me.txtGenomBestuurder1.Text = ""
        Me.txtGenomBestuurder2.Text = ""
        Me.txtGenomBestGebore1.Text = ""
        Me.txtGenomBestGebore2.Text = ""
        Me.txtGereeldeBestuurder1.Text = ""
        Me.txtGereeldeBestuurder2.Text = ""
        Me.txtGereeldeBestuurder3.Text = ""
        Me.txtGereeldeBestuurder4.Text = ""
        Me.txtGereeldeBestGebore1.Text = ""
        Me.txtGereeldeBestGebore2.Text = ""
        Me.txtGereeldeBestGebore3.Text = ""
        Me.txtGereeldeBestGebore4.Text = ""
        Me.txtKmLesingDatum.Text = ""
        Me.txtMotorplanVervalDat.Text = ""
        'Kobus 18/07/2013 verander "" na 0
        Me.txtMotorplanKm.Text = ""
        Me.txtPersentasieWaarde.Text = 0
        Me.txtPremiePersentasie.Text = 0
        'Kobus 18/07/2013 comment out - already done
        'Me.txtPremieVoor.Text = ""
        'Me.txtPremieEkstras.Text = ""
        'Me.txtPremie.Text = ""
        'Me.txtPremieNaKorting.Text = ""
        'Me.txtWaardeEkstras.Text = ""
        'Me.txtWaarde.Text = ""
        Me.txtEienaar.Text = ""
        cmbAreaBeskrywing.SelectedIndex = -1
        cmbAreaFrekwensie.SelectedIndex = -1
        cmbHuurInstansie.SelectedIndex = -1
        'Kobus 12/7/2013 verander van txtHuurNommer.Text = "" na Me. ... en die ander
        Me.txtHuurNommer.Text = ""
        Me.chkIngevoer.CheckState = CheckState.Unchecked
        Me.chkMotorplan.CheckState = CheckState.Unchecked
        Me.chkHuurkoop.CheckState = CheckState.Unchecked
        'lstStdItmsSelected.Items.Clear()
        lstStdItmsSelected.DataSource = Nothing
        'Kobus 17/07/2013 voeg Me. vooraan _chkSekuriteit....
        Me._chkSekuriteit_0.CheckState = CheckState.Unchecked
        Me._chkSekuriteit_1.CheckState = CheckState.Unchecked
        Me._chkSekuriteit_2.CheckState = CheckState.Unchecked
        Me._chkSekuriteit_3.CheckState = CheckState.Unchecked
        Me._chkSekuriteit_4.CheckState = CheckState.Unchecked
        Me._chkSekuriteit_5.CheckState = CheckState.Unchecked
        Me._chkSekuriteit_6.CheckState = CheckState.Unchecked
        Me._chkSekuriteit_7.CheckState = CheckState.Unchecked
        chkVssRatingJN.CheckState = CheckState.Unchecked
        chkMotorHuis.CheckState = CheckState.Unchecked
        cmbDitto.SelectedIndex = -1
        'Kobus 12/07/2013 voeg Me. voor txtAdres.Text = "" en txtAdres2.Text = "" en res van adres
        Me.txtAdres.Text = ""
        Me.txtAdres2.Text = ""
        Me.txtVoorstad.Text = ""
        Me.txtStad.Text = ""
        Me.txtPoskode.Text = ""
        'Kobus 15/7/2013 voegby om te voorkom dat Ok btn enable/disable nie die vorige polis se waarde het nie
        strPolicystatus = ""
        strCurrentVehicle = ""
        intVorigeDekIndex = -1
        strRemove = ""
        blnValidationOk = False
        Me.txtWaardeVoertuig.Enabled = True
        Me.cmbWaardeTipe.Enabled = True
        Me.btnCancel.Enabled = True
        'Kobus 13/05/2014 voegby
        strWaardeTipe = ""
    End Sub
    Private Sub VoertuigDetail_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Kobus 24/03/2014 voegby
        If blnNoExit = True Then
            Exit Sub
        End If
        'Kobus 02/09/2013 voegby
        dblPremieekstra = 0
        dblWaardeekstra = 0
        blnNilvalueEkstra = False
        blnAddnew = False
        'Kobus 30/01/2014 voegby
        blnNoRepeat1 = False
        bln1stIdentification = False
        ClearVoertuig()
        'Kobus 06/02/2014 voegby
        blnRestorTypeCover = False
        'Kobus 20/4/2014 voegby
        strType = ""
        blnFactoryStanderd = False
    End Sub
    'Populate the comboboxes with values
    Private Sub populateComboBoxes()
        cmbTipe.Items.Clear()
        'Type of vehicle
        'Kobus 04/12/2013 verander terug na taal van polis - 5.129
        'Kobus 09/09/2013 verander na slegs Engels - 5.83
        If Persoonl.TAAL = 0 Then
            cmbTipe.Items.Add("Motor")
            'Kobus 04/12/2013 verander van Bakkie na Ligte Afleweringsvoertuig
            cmbTipe.Items.Add("Ligte Afleweringsvoertuig")
            cmbTipe.Items.Add("Kombi")
            cmbTipe.Items.Add("Sleepwa")
            cmbTipe.Items.Add("Karavaan")
            cmbTipe.Items.Add("Motorfiets")
            cmbTipe.Items.Add("Ander")
            cmbTipe.Items.Add("Motorboot")
            cmbTipe.Items.Add("Vierwielmotorfiets")
            cmbTipe.Items.Add("Gholf kar")

        Else
            cmbTipe.Items.Add("Motor")
            cmbTipe.Items.Add("Light Delivery Vehicle") 'K - 5.83
            cmbTipe.Items.Add("Microbus")
            cmbTipe.Items.Add("Trailer")
            cmbTipe.Items.Add("Caravan")
            cmbTipe.Items.Add("Motorcycle")
            cmbTipe.Items.Add("Other")
            cmbTipe.Items.Add("Motorboat")
            cmbTipe.Items.Add("Quad bike")  'K - 5.83
            cmbTipe.Items.Add("Golf cart")  'K - 5.83
        End If

        cmbTipeDek.Items.Clear()

        'Type of cover
        'Kobus 04/12/2013 verander terug na taal van polis - 5.129
        'Kobus 19/08/2013 verander na slegs Engels
        If Persoonl.TAAL = 0 Then
            cmbTipeDek.Items.Add("Omvattend")
            cmbTipeDek.Items.Add("Balans, Derde party, Brand & Diefstal")
            cmbTipeDek.Items.Add("Balans & Derde party")
        Else
            cmbTipeDek.Items.Add("Comprehensive") ' index 0 - idetifier: 1
            cmbTipeDek.Items.Add("Balance, Third party, Fire & Theft") ' index 1, identifier:2
            cmbTipeDek.Items.Add("Balance & Third party") 'index 2, identifier: 3
        End If

        'Use of vehicle
        cmbGebruik.Items.Clear()
        If Persoonl.TAAL = 0 Then
            cmbGebruik.Items.Add("Privaat")
            cmbGebruik.Items.Add("Professioneel")
        Else
            cmbGebruik.Items.Add("Private")
            cmbGebruik.Items.Add("Professional")
        End If

        PopulateComboWithMotorstatus()

        'Huurkoop instansie

        PopulateComboWithHuurinstansie()

        'Areabeskrywing

        PopulateComboWithDrop()


        cmbAreaFrekwensie.Items.Clear() 'Kobus Visser - 15/02/2013 - voorkom herhaling van inligting

        'AreaFrekwensie
        For Me.k = 0 To 15
            Me.cmbAreaFrekwensie.Items.Add(CStr(k))
        Next
        Me.cmbAreaFrekwensie.Items.Add("15+")
    End Sub
    Sub PopulateComboWithDrop()

        Using conn As SqlConnection = SqlHelper.GetConnection

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchDrop")

            'cmbAreaBeskrywing.Items.Clear()

            Do While reader.Read
                cmbAreaBeskrywing.Items.Add(reader("Dorp"))
            Loop
            conn.Close()
        End Using
    End Sub
    Sub PopulateComboWithMotorstatus()
        Using conn As SqlConnection = SqlHelper.GetConnection

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchMotorStatus")
            cmbMotorStatus.Items.Clear()
            Do While reader.Read
                'Kobus 12/09/2013 voeg taalopsie by
                If Persoonl.TAAL = 0 Then
                    cmbMotorStatus.Items.Add(reader("beskrywing"))
                Else
                    cmbMotorStatus.Items.Add(reader("BeskrywingEngels"))
                End If
            Loop
            cmbMotorStatus.SelectedIndex = 1
            conn.Close()
        End Using
    End Sub
    Sub PopulateComboWithHuurinstansie()
        Using conn As SqlConnection = SqlHelper.GetConnection

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchHuurinstansie")
            cmbHuurInstansie.Items.Clear()
            Do While reader.Read
                cmbHuurInstansie.Items.Add(reader("beskrywing"))
            Loop
            conn.Close()
        End Using
    End Sub
    Private Sub GridEkstras_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'UPGRADE_WARNING: Couldn't resolve default property of object Gebtitel. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Kobus 11/09/2013 verander Gebtitel na
        If Gebruiker.titel = "Besigtig" Then
            btnEdit_Click(btnEdit, New System.EventArgs())
        End If
    End Sub
    Private Sub lstStdItmsAvailable_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstStdItmsAvailable.DoubleClick
        btnStdAddOne_Click(btnStdAddOne, New System.EventArgs())
        blnInformationChanged = True
        blnFactoryStanderd = True
    End Sub
    Private Sub lstStdItmsSelected_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstStdItmsSelected.DoubleClick
        btnStdRemoveOne_Click(btnStdRemoveOne, New System.EventArgs())
        blnInformationChanged = True
        blnFactoryStanderd = True
    End Sub
    Private Sub optMark_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optMark.CheckedChanged
        If eventSender.Checked Then
            blnInformationChanged = True
            calcValue()
        End If
    End Sub
    Private Sub optNuut_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optNuut.CheckedChanged
        If eventSender.Checked Then
            blnInformationChanged = True
            calcValue()
        End If
    End Sub
    Private Sub optKoop_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optKoop.CheckedChanged
        If eventSender.Checked Then
            blnInformationChanged = True
            calcValue()
        End If
    End Sub
    Private Sub optInruil_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optInruil.CheckedChanged
        If eventSender.Checked Then
            blnInformationChanged = True
            calcValue()
        End If
    End Sub
    Private Sub txtAdres_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtAdres.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub txtAdres_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtAdres.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case 34, 39
                ' Anything else is unacceptable, and should be ignored
                MsgBox("The characters ''and"" ""can not be used.", MsgBoxStyle.Information)
                KeyAscii = 0
            Case Else
                ' These are acceptable keystrokes
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub txtAdres2_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtAdres2.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub txtAdres2_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtAdres2.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case 34, 39
                ' Anything else is unacceptable, and should be ignored
                MsgBox("The characters ""and"" ""can not be used.", MsgBoxStyle.Information)
                KeyAscii = 0
            Case Else
                ' These are acceptable keystrokes
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub txtAnder_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtAnder.TextChanged
        If CBool(Me.txtAnder.Text) Then
            'Populate combobox
            populateCmbWaardeTipe(True)
            'Kobus 22/04/2013 add 02/05/2013 comment out this field is invisable and should not influence cancel options
            'InformationChanged = True
            'Kobus - 30/01/2013 en 13/02/2013 changed "Diverse motor" en "Sundry Vehicle"
            Me.txtAnderBeskrywing.Text = "Non Auto Guide Vehicle"
            Me.txtMaak.Enabled = True
            Me.txtBesk.Enabled = True
            Me.txtJaar.Enabled = True
            'Kobus 22/07/2013 verander "n.v.t." na "N/A"
            Me.txtEindDatum.Text = "N/A"
            'Kobus 22/07/2013 verander "n.v.t." na 0
            Me.txtKoop.Text = 0
            'Kobus 22/07/2013 verander "n.v.t." na 0
            Me.txtInruil.Text = 0
            'Kobus 22/07/2013 verander "n.v.t." na 0 daarna comment ou
            Me.txtNuut.Text = 0
            'Kobus 22/07/2013 verander "n.v.t." na 0
            Me.txtValueMarket.Text = 0
            'Kobus 23/08/2013 verander 0 na -1
            Me.cmbWaardeTipe.SelectedIndex = -1
        Else
            'Populate combobox
            populateCmbWaardeTipe(False)
            'Kobus 22/04/2013 add 02/05/2013 comment out this field is invisable and should not influence cancel options
            'InformationChanged = True
            'Kobus - 30/01/2013 en 13/02/2013 changed "Mead and McGrouther"
            Me.txtAnderBeskrywing.Text = "Auto Guide Vehicle"
            Me.txtMaak.Enabled = False
            Me.txtBesk.Enabled = False
            Me.txtJaar.Enabled = False
            'Kobus 23/08/2013 verander van 0 na -1
            Me.cmbWaardeTipe.SelectedIndex = -1
            Me.cmbWaardeTipe.Enabled = True
        End If
    End Sub
    Private Sub txtAreaBeskrywing_Change()
        blnInformationChanged = True
    End Sub
    Private Sub txtBesk_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBesk.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub txtBesk_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtBesk.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case 34, 39
                ' Anything else is unacceptable, and should be ignored
                MsgBox("The characters ""and"" ""can not be used.", MsgBoxStyle.Information)
                KeyAscii = 0
            Case Else
                ' These are acceptable keystrokes
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub txtBesk_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtBesk.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Me.txtAnder.Text = CStr(True)
    End Sub
    Private Sub txtBestuurder_Change()
        blnInformationChanged = True
    End Sub
    Private Sub txtEienaar_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtEienaar.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub txtEnjinNommer_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtEnjinNommer.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub txtGenomBestGebore1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtGenomBestGebore1.TextChanged
        blnInformationChanged = True
        If Me.txtGenomBestGebore1.Text <> "0" And Me.txtGenomBestGebore1.Text <> "" Then
            Me.txtGenomBestOud1.Text = CStr(Year(Now) - Val(Me.txtGenomBestGebore1.Text))
        Else
            Me.txtGenomBestOud1.Text = CStr(0)
        End If
    End Sub
    Private Sub txtGenomBestGebore2_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtGenomBestGebore2.TextChanged
        blnInformationChanged = True
        If Me.txtGenomBestGebore2.Text <> "0" And Me.txtGenomBestGebore2.Text <> "" Then
            Me.txtGenomBestOud2.Text = CStr(Year(Now) - Val(Me.txtGenomBestGebore2.Text))
        Else
            Me.txtGenomBestOud2.Text = CStr(0)
        End If
    End Sub
    Private Sub txtGereeldeBestGebore1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtGereeldeBestGebore1.TextChanged
        blnInformationChanged = True
        If Me.txtGereeldeBestGebore1.Text <> "0" And Me.txtGereeldeBestGebore1.Text <> "" Then
            Me.txtGereeldeBestOud1.Text = CStr(Year(Now) - Val(Me.txtGereeldeBestGebore1.Text))
        Else
            Me.txtGereeldeBestOud1.Text = CStr(0)
        End If
    End Sub
    Private Sub txtGereeldeBestGebore2_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtGereeldeBestGebore2.TextChanged
        blnInformationChanged = True
        If Me.txtGereeldeBestGebore2.Text <> "0" And Me.txtGereeldeBestGebore2.Text <> "" Then
            Me.txtGereeldeBestOud2.Text = CStr(Year(Now) - Val(Me.txtGereeldeBestGebore2.Text))
        Else
            Me.txtGereeldeBestOud2.Text = CStr(0)
        End If
    End Sub
    Private Sub txtGereeldeBestGebore3_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtGereeldeBestGebore3.TextChanged
        blnInformationChanged = True
        If Me.txtGereeldeBestGebore3.Text <> "0" And Me.txtGereeldeBestGebore3.Text <> "" Then
            Me.txtGereeldeBestOud3.Text = CStr(Year(Now) - Val(Me.txtGereeldeBestGebore3.Text))
        Else
            Me.txtGereeldeBestOud3.Text = CStr(0)
        End If
    End Sub
    Private Sub txtGereeldeBestGebore4_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtGereeldeBestGebore4.TextChanged
        'Kobus 10/09/2013 5.86 in onbruik - veld is onsigbaar
        blnInformationChanged = True
        If Me.txtGereeldeBestGebore4.Text <> "0" And Me.txtGereeldeBestGebore4.Text <> "" Then
            Me.txtGereeldeBestOud4.Text = CStr(Year(Now) - Val(Me.txtGereeldeBestGebore4.Text))
        Else
            Me.txtGereeldeBestOud4.Text = CStr(0)
        End If
    End Sub
    Private Sub txtHuurNommer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHuurNommer.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar)) Then
                'do nothing
            Else
                e.Handled = True
                MsgBox("Account number must be numeric", _
                       MsgBoxStyle.Information, "Verify")
                'Kobus 24/04/2013 change txtKilometerLesing.Focus()
                txtHuurNommer.Focus()
            End If
        End If
    End Sub
    Private Sub txtHuurNommer_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtHuurNommer.TextChanged
        blnInformationChanged = True
    End Sub
    'Kobus 06/05/2013 moved from form validation to field validation
    Private Sub txtJaar_Leave(sender As Object, e As System.EventArgs) Handles txtJaar.Leave
        'Vehicles in the M&M year window should be entered with the desired password
        'Only for newly entered vehicles
        'Kobus 10/12/2013 voegby
        If Me.txtJaar.Text = "" Then
            MsgBox("A year value is required.", MsgBoxStyle.Information)
            Me.txtJaar.Focus()
            Exit Sub
        End If
        If pkVoertuie = 0 Then
            'Kobus 11/04/2013 add strPassword and clear
            Dim strPassword As String
            strPassword = "pass25"
            'Only require password for bakkies,cars and combi's
            'Kobus 11/04/2013 change message from: "When a variety of vehicles with model years in the Mead & McGrouther & window, is added, it must first be approved."
            If Me.cmbTipe.SelectedIndex = 0 Or Me.cmbTipe.SelectedIndex = 1 Or Me.cmbTipe.SelectedIndex = 2 Then
                If CDbl(Me.txtJaar.Text) >= (Year(Now) - 15) Then
                    frmPassword.lblMessage.Text = "This vehicle's model year falls within the Auto Guide window period of fifteen years. To load this as a Non Auto Guide vehicle it must first be approved."
                    frmPassword.ShowDialog()
                    If pwdEntered <> strPassword Then
                        MsgBox("The password is not correct.", MsgBoxStyle.Information)
                        pwdEntered = ""
                        Me.txtJaar.Focus()
                        Exit Sub
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub txtJaar_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtJaar.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub txtJaar_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtJaar.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case 34, 39
                ' Anything else is unacceptable, and should be ignored
                MsgBox("The characters ''and "" "" can not be used.", MsgBoxStyle.Information)
                KeyAscii = 0
            Case Else
                ' These are acceptable keystrokes
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub txtJaar_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtJaar.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Me.txtAnder.Text = CStr(True)
    End Sub
    Private Sub txtKilometerLesing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKilometerLesing.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar)) Then
                'do nothing
            Else
                e.Handled = True
                MsgBox("Value must be numeric", _
                       MsgBoxStyle.Information, "Verify")
                txtKilometerLesing.Focus()
            End If
        End If
    End Sub
    Private Sub txtKilometerLesing_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtKilometerLesing.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub txtKleur_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtKleur.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub txtKmLesingDatum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtKmLesingDatum.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub txtKode_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtKode.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub txtKoop_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtKoop.TextChanged
        If Not blnLoading Then
            If Me.cmbWaardeTipe.SelectedIndex = 1 Then
                Me.txtWaarde.Text = Me.txtKoop.Text
            End If
        End If
    End Sub
    Private Sub txtMaak_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMaak.TextChanged
        blnInformationChanged = True

    End Sub
    Private Sub txtMaak_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtMaak.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Me.txtAnder.Text = CStr(True)
    End Sub
    Private Sub txtMotorplanKm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMotorplanKm.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar)) Then
                'do nothing
            Else
                e.Handled = True
                MsgBox("Value must be numeric", _
                       MsgBoxStyle.Information, "Verify")
                txtKilometerLesing.Focus()
            End If
        End If
    End Sub
    Private Sub txtMotorplanKm_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMotorplanKm.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub txtMotorplanVervalDat_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMotorplanVervalDat.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub txtNPlaat_EnabledChanged(sender As Object, e As System.EventArgs) Handles txtNPlaat.EnabledChanged
        'Kobus 24/03/2014 voegby
        blnInformationChanged = True
    End Sub
    Private Sub txtNPlaat_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtNPlaat.Enter
        'Select the whole string in textbox
        Me.txtNPlaat.SelectionStart = 0
        'UPGRADE_WARNING: TextBox property txtNPlaat.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        Me.txtNPlaat.SelectionLength = Me.txtNPlaat.MaxLength
    End Sub
    Private Sub txtNPlaat_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtNPlaat.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case 34, 39
                ' Anything else is unacceptable, and should be ignored
                MsgBox("The characters "" And  "" ""can not be used.", MsgBoxStyle.Information)
                KeyAscii = 0
            Case Else
                ' These are acceptable keystrokes
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub txtNPlaat_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtNPlaat.Leave
        Me.txtNPlaat.Text = UCase(txtNPlaat.Text)
        'Kobus 11/09/2013 voegby
        Me.txtNPlaat.Text = Me.txtNPlaat.Text.Replace(" ", "")
    End Sub
    Private Sub txtOnderstelNommer_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtOnderstelNommer.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub txtPersentasiewaarde_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPersentasieWaarde.TextChanged
        blnInformationChanged = True
        calcValue()
    End Sub

    Private Sub txtPersentasiewaarde_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPersentasieWaarde.Enter
        Me.txtPersentasieWaarde.SelectionStart = 0
        Me.txtPersentasieWaarde.SelectionLength = Me.txtPersentasieWaarde.MaxLength
    End Sub
    Private Sub txtPoskode_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPoskode.TextChanged
        Me.txtPoskode.Text = (Me.txtPoskode.Text)
    End Sub
    Private Sub txtPremie_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPremie.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub txtPremiePersentasie_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPremiePersentasie.TextChanged
        If Not blnLoading Then
            'calcPremium()
            blnInformationChanged = True
        End If
    End Sub
    Private Sub txtPremiePersentasie_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPremiePersentasie.Enter
        Area = FetchArea()
        If Area.Tak_Naam <> "Bloemfontein" Then
            If blnRequestPwd Then
                'Kobus 23/09/2013 verander van "Please label the discount / loading stuff in the password fields."
                frmPassword.lblMessage.Text = "Authorise the item discount/loading"
                frmPassword.ShowDialog()
                Me.txtPremiePersentasie.Focus()
            End If
            If pwdEntered = "passmeby" Then
                Me.txtPremiePersentasie.SelectionStart = 0
                Me.txtPremiePersentasie.SelectionLength = Me.txtPremiePersentasie.MaxLength
                blnRequestPwd = False
            Else
                'Kobus 02/09/2014 voegby
                If pwdEntered = "Cancelled" Then
                    Me.txtPremieVoor.Focus()
                    Exit Sub
                End If
                MsgBox("The password is not correct.", MsgBoxStyle.Information)
                Me.txtPremieVoor.Focus()
            End If
        End If
    End Sub
    Private Sub txtPremiePersentasie_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPremiePersentasie.Leave
        blnRequestPwd = True
        If Me.txtPremiePersentasie.Text = "" Or CDbl(Me.txtPremiePersentasie.Text) = 0 Then
            MsgBox("Premium rate can not be 0%, it is changed to 100%.", MsgBoxStyle.Information)
            'Kobus 31/07/2013 verander van CStr
            Me.txtPremiePersentasie.Text = (CInt(100))
            Exit Sub
        End If
    End Sub
    Private Sub txtPremieVoor_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPremieVoor.TextChanged
        'If Loading Then
        blnInformationChanged = True
        If Me.txtPremie.Text = "" Then
            'Kobus 31/07/2013 verander van CStr
            Me.txtPremie.Text = CDec(0)
        End If

        'calcPremium()
        blnInformationChanged = True
        'End If
    End Sub
    Private Sub txtPremieVoor_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPremieVoor.Enter
        Me.txtPremie.SelectionStart = 0
        Me.txtPremie.SelectionLength = Len(txtPremie.Text)
        'Kobus 07/08/2013 voegby
        Me.txtPremie.SelectAll()
    End Sub
    Private Sub txtValueMarket_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtValueMarket.TextChanged
        If Not blnLoading Then
            If Me.cmbWaardeTipe.SelectedIndex = 0 Then
                Me.txtWaarde.Text = Me.txtValueMarket.Text
            End If
        End If
    End Sub
    Private Sub txtVSSRatingBesk_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtVSSRatingBesk.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub txtWaarde_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtWaarde.TextChanged
        blnInformationChanged = True
    End Sub
    'Validate the information on the form
    Public Function validateForm() As Object

        blnValidationOk = False

        If Me.txtAnder.Text = "" Then
            'Kobus 22/08/2013 verander car na vehicle
            MsgBox("The type of vehicle could not be determined (Mead & McGrouther / Miscellaneous)." & Chr(13) & "Please choose the type of vehicle by pressing the 'buttons' to 'click'.", MsgBoxStyle.Exclamation)
            Me.btnMotors.Focus()
            validateForm = False
            Exit Function
        End If

        'Diverse motor
        If CBool(Me.txtAnder.Text) Then
            'Fabrikaat
            If Trim(Me.txtMaak.Text) = "" Then
                'Kobus 22/08/2013 verander car na vehicle
                MsgBox("The make of the vehicle must be entered.", MsgBoxStyle.Exclamation)
                Me.txtMaak.Focus()
                validateForm = False
                Exit Function
            End If

            'Model beskrywing
            If Trim(Me.txtBesk.Text) = "" Then
                'Kobus 22/08/2013 verander car na vehicle
                MsgBox("The model description of the vehicle must be entered.", MsgBoxStyle.Exclamation)
                Me.txtBesk.Focus()
                validateForm = False
                Exit Function
            End If

            'Jaar
            If Trim(txtJaar.Text) = "" Then
                MsgBox("The model year must be entered.", MsgBoxStyle.Exclamation)
                Me.txtJaar.Focus()
                validateForm = False
                Exit Function
            End If
            If Not IsNumeric(txtJaar.Text) Then
                MsgBox("The model year must be a numeric number.", MsgBoxStyle.Exclamation)
                Me.txtJaar.Focus()
                validateForm = False
                Exit Function
            End If
            If Len(Trim(txtJaar.Text)) < 4 Then
                MsgBox("The year model format should be ccyy.", MsgBoxStyle.Exclamation)
                Me.txtJaar.Focus()
                validateForm = False
                Exit Function
            End If
            If Val(txtJaar.Text) > Val(CStr(Year(Now) + 1)) Then
                MsgBox("The model year not more than a year ahead cannot be filled.", MsgBoxStyle.Exclamation)
                Me.txtJaar.Focus()
                validateForm = False
                Exit Function
            End If
            If Val(txtJaar.Text) < 1900 Then
                MsgBox("The model year can not be before 1900.", MsgBoxStyle.Exclamation)
                Me.txtJaar.Focus()
                validateForm = False
                Exit Function
            End If
            'Kobus 06/05/2013 commented out - move to field validation (leave event of txtJaar)
            ''Vehicles in the M&M year window should be entered with the desired password
            ''Only for newly entered vehicles
            'If pkVoertuie = 0 Then
            '    'Kobus 11/04/2013 add strPassword and clear
            '    Dim strPassword As String
            '    strPassword = "pass25"
            '    'Only require password for bakkies,cars and combi's
            '    'Kobus 11/04/2013 change message from: "When a variety of vehicles with model years in the Mead & McGrouther & window, is added, it must first be approved."
            '    If Me.cmbTipe.SelectedIndex = 0 Or Me.cmbTipe.SelectedIndex = 1 Or Me.cmbTipe.SelectedIndex = 2 Then
            '        If CDbl(Me.txtJaar.Text) >= (Year(Now) - 15) Then
            '            frmPassword.lblMessage.Text = "This vehicle's model year falls within the Auto Guide window period of fifteen years. To load this as a Non Auto Guide vehicle it must first be approved."
            '            frmPassword.ShowDialog()
            '            If pwdEntered <> strPassword Then
            '                MsgBox("The password is not correct.", MsgBoxStyle.Information)
            '                pwdEntered = ""
            '                Me.txtJaar.Focus()
            '                validateForm = False
            '                Exit Function
            '            End If
            '          End If
            '    End If
            'End If

        End If

        'Voertuigtipe
        If Me.cmbTipe.SelectedIndex = -1 Then
            MsgBox("The vehicle type must be entered.", MsgBoxStyle.Exclamation)
            Me.cmbTipe.Focus()
            validateForm = False
            Exit Function
        End If

        'Registration number
        If Trim(Me.txtNPlaat.Text) = "" Then
            MsgBox("The registration number must be entered.", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 2
            'Kobus 10/12/2013 voegby
            blnNoExit = True
            validateForm = False
            Me.txtNPlaat.Focus()
            Exit Function
        End If

        'KmLesingDatum
        If Not CStr(Trim(Me.txtKmLesingDatum.Text)) = "" Then
            If Not IsDate(Trim(Me.txtKmLesingDatum.Text)) Then
                MsgBox("The date the kilometer readings taken is not correct.", MsgBoxStyle.Exclamation)
                Me.SSTab1.SelectedIndex = 0
                Me.txtKmLesingDatum.Focus()
                validateForm = False
                Exit Function
            End If
        End If

        'Kilometer per year
        'Kobus Visser 28/03/2013 add condition from "" to 0
        If txtKmPerJaar.Text = "" Then
            txtKmPerJaar.Text = 0
        End If
        If Not IsNumeric(txtKmPerJaar.Text) Then
            MsgBox("The number of miles per year is a numeric integer. ", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 1
            Me.txtKmPerJaar.Focus()
            validateForm = False
            Exit Function
        End If

        'Value insured
        'Kobus 07/08/2013 voegby And cmbTipeDek.SelectedIndex <> 2 Then '3rd party uitsondering
        'Kobus 31/07/2013 verander van If Trim(Me.txtWaardeVoertuig.Text) = "" Then
        If Me.txtWaardeVoertuig.Text = 0 And cmbTipeDek.SelectedIndex <> 2 Then '3rd party uitsondering
            MsgBox("The insured value must be entered.", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 2
            Me.txtWaardeVoertuig.Focus()
            validateForm = False
            Exit Function

        End If
        'Kobus 28/08/2013 voegby And txtWaardeVoertuig.Text <> 0
        If Me.cmbWaardeTipe.SelectedIndex = -1 And txtWaardeVoertuig.Text <> 0 Then
            MsgBox("The type of value to be insured must be selected.", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 2
            Me.cmbWaardeTipe.Focus()
            validateForm = False
            Exit Function
        End If

        If Not IsNumeric(Me.txtWaardeVoertuig.Text) Then
            MsgBox("The insured value must be numeric.", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 2
            Me.txtWaardeVoertuig.Focus()
            validateForm = False
            Exit Function
        End If

        'Premium
        If Trim(Me.txtPremieVoor.Text) = "" Or Val(Trim(Me.txtPremieVoor.Text)) = 0 Then
            MsgBox("The premium must be completed.", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 2
            Me.txtPremieVoor.Focus()
            validateForm = False
            Exit Function
        End If

        If Not IsNumeric(Me.txtPremieVoor.Text) Then
            MsgBox("The premium must be numeric.", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 2
            Me.txtPremieVoor.Focus()
            validateForm = False
            Exit Function
        End If

        If Val(Me.txtPremieVoor.Text) = 0 Then
            MsgBox("The premium may not be zero.", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 2
            Me.txtPremieVoor.Focus()
            validateForm = False
            Exit Function
        End If

        'Don't allow si > 0 and no premium and vice versa
        If Me.cmbTipeDek.SelectedIndex = 2 Then '3rd party
            'No check
        Else
            If (Val(Me.txtWaardeVoertuig.Text) = 0 And Val(Me.txtPremieVoor.Text) <> 0) Or (Val(Me.txtWaardeVoertuig.Text) <> 0 And Val(Me.txtPremieVoor.Text) = 0) Then
                MsgBox("The premium and value of the vehicle must either be completed.", MsgBoxStyle.Exclamation)
                Me.SSTab1.SelectedIndex = 2
                validateForm = False
                Exit Function
            End If
        End If

        'Percentagevalue
        If Trim(Me.txtPersentasieWaarde.Text) <> "" Then
            If Not IsNumeric(Me.txtPersentasieWaarde.Text) Then
                MsgBox("The percentage value must be numeric.", MsgBoxStyle.Exclamation)
                Me.SSTab1.SelectedIndex = 2
                Me.txtPersentasieWaarde.Focus()
                validateForm = False
                Exit Function
            End If
        End If

        'PremiePersentasie
        If Trim(Me.txtPremiePersentasie.Text) <> "" Then
            If Not IsNumeric(Me.txtPremiePersentasie.Text) Then
                MsgBox("The discount / loading rate must be numeric.", MsgBoxStyle.Exclamation)
                Me.SSTab1.SelectedIndex = 2
                Me.txtPremiePersentasie.Focus()
                validateForm = False
                Exit Function
            End If
        End If

        'Kobus 25/03/2014 voegby om duplikaat check te voorkom as die rekord reeds gestoor is met 'n duplikaat
        If blnediting And txtNPlaat.Text = voertuie.N_PLAAT Then
            'do nothing
        Else
            If Trim(Me.txtNPlaat.Text) <> "" Then
                'Kobus 06/05/2013 add condition to skip existing record
                'Kobus 24/03/2014 comment out If editing
                '
                'do nothing
                'Else

                'Unique numberplate?
                ' sSql = "SELECT TOP 1 voertuie.polisno FROM voertuie LEFT JOIN persoonl ON persoonl.polisno = voertuie.polisno WHERE n_plaat = '" & Me.txtNPlaat.Text & "' AND pkVoertuie <> " & pkVoertuie & " AND not gekans AND not(cancelled)"
                'rs = pol.OpenRecordset(sSql)
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim param() As SqlParameter = {New SqlParameter("@N_PLAAT", SqlDbType.NVarChar), _
                                                   New SqlParameter("@pkVoertuie", SqlDbType.Int)}

                    param(0).Value = txtNPlaat.Text
                    param(1).Value = pkVoertuie

                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPolisnoFromVoertuie", param)

                    If reader.Read Then 'A record found with same numberplate
                        'duplikaat registrasienommers moet kan plaasvind
                        'Kobus 29/08/2013 Form1.POLISNO.Text met glbpolicynumber
                        If reader("polisno") = glbPolicyNumber And blnNoRepeat1 = False Then
                            'Kobus 02/05/2013 change car with vehicle and 06/05/2013 change message Would you go to the vehicle to load
                            If MsgBox("There is already a vehicle with this registration number on this policy. Would you like to continue to load the vehicle?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                validateForm = False
                                Me.txtNPlaat.Text = ""
                                Me.txtNPlaat.Focus()
                                'Kobus 24/03/2014 voegby
                                blnNoExit = True
                                Exit Function
                                'Kobus 06/05/2013 add
                            Else
                                validateForm = True
                                blnNoRepeat1 = True
                                blnInformationChanged = True
                                blnNoExit = True
                            End If
                        End If
                        If reader("polisno") <> glbPolicyNumber And blnNoRepeat1 = False Then
                            'Kobus 02/05/2013 change car with vehicle and 06/05/2013 change message Would you go to the vehicle to load
                            If MsgBox("There is already a vehicle with this registration number on policy " & reader("polisno") & ". Would you like to continue to load the vehicle?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                validateForm = False
                                'Kobus 24/03/2014 voegby
                                blnNoExit = True
                                Me.txtNPlaat.Text = ""
                                Me.txtNPlaat.Focus()
                                Exit Function
                                'Kobus 15/08/2013 comment out
                                '    'Kobus 06/05/2013 add
                            Else
                                ''Kobus 24/03/2014 verander van die volgende
                                ''    MsgBox("Engela as ek dit nie mis het nie, moet hier eintlik die volgende staan:" & "There is already a vehicle with this registration number on policy " & reader("polisno") & ". It cannot be loaded on this policy also.")
                                'MsgBox("A valid registration number must be entered.", MsgBoxStyle.Exclamation)
                                'validateForm = False
                                'If pkVoertuie = 0 Then
                                '    editing = False
                                '    InformationChanged = True
                                'End If
                                'Me.txtNPlaat.Text = ""
                                'Me.SSTab1.SelectedIndex = 2
                                'blnNoExit = True
                                'Me.txtNPlaat.Focus()
                                'Exit Function
                                validateForm = True
                                blnNoRepeat1 = True
                                blnInformationChanged = True
                                blnNoExit = True
                            End If
                        End If
                    End If 'If rs("polisno") = POLISNO Then
                    conn.Close()
                End Using
            End If
        End If


        'Kilometers
        If CStr(Trim(Me.txtKilometerLesing.Text)) = "0" Then
        Else
            If Not IsNumeric(Me.txtKilometerLesing.Text) Then
                MsgBox("The kilometer reading should be numerical.", MsgBoxStyle.Exclamation)
                Me.SSTab1.SelectedIndex = 0
                Me.txtKilometerLesing.Focus()
                validateForm = False
                Exit Function
            End If
        End If

        'Voorstad, Stad, Poskode
        'Kobus 23/01/2014 wysig toets van If Trim(Me.txtVoorstad.Text) = "" Or Trim(Me.txtStad.Text) = "" Or Trim(Me.txtPoskode.Text) = "" Then
        If Trim(Me.txtPoskode.Text) = "" Then
            If pkVoertuie = 0 Then
                ' Kobus Visser 13/03/2013 change message: The address (ZIP code) where the motor must be completed overnight.
                MsgBox("The overnight address of the vehicle must be completed.", MsgBoxStyle.Exclamation)
                Me.SSTab1.SelectedIndex = 3
                Me.btnPoskodeSearch.Focus()
                validateForm = False
                'Kobus 06/05/2014 voegby
                blnInformationChanged = True
                Exit Function
            Else
                'Kobus 13/05/2014 voegby
                MsgBox("The overnight address of the vehicle must be completed.", MsgBoxStyle.Exclamation)
                Me.SSTab1.SelectedIndex = 3
                Me.btnPoskodeSearch.Focus()
                validateForm = False
                blnInformationChanged = True
                Exit Function
                'Kobus 13/05/2014 comment out
                ''Kobus Visser 13/03/2013 change message: MsgBox("The address (ZIP code) where the car overnight is outstanding, but can later be erased.", MsgBoxStyle.Information)
                'MsgBox("The overnight address of the vehicle can be completed later.")
                'If InformationChanged = False Then
                '    validateForm = True      'Kobus add
                'End If
            End If
        End If

        'If motorplan was selected then check fields
        If Me.chkMotorplan.CheckState Then
            'Motorplan verval datum
            If Not Trim(Me.txtMotorplanVervalDat.Text) = "" Then
                If Not IsDate(Trim(Me.txtMotorplanVervalDat.Text)) Then
                    MsgBox("The kilometer reading Should be numerical....", MsgBoxStyle.Exclamation)
                    Me.SSTab1.SelectedIndex = 4
                    Me.txtMotorplanVervalDat.Focus()
                    validateForm = False
                    Exit Function
                End If
            End If

            'Motorplan kilometer
            If Not Trim(Me.txtMotorplanKm.Text) = "" Then
                If Not IsNumeric(Trim(Me.txtMotorplanKm.Text)) Then 'Kobus 22/08/2013 verander car na vehicle
                    MsgBox("The mileage that the vehicle should plan expire be numeric.", MsgBoxStyle.Exclamation)
                    Me.SSTab1.SelectedIndex = 4
                    Me.txtMotorplanKm.Focus()
                    validateForm = False
                    Exit Function
                End If
            End If
        End If

        'Validate date of birth on drivers
        If Trim(Me.txtGereeldeBestGebore1.Text) <> "" And Trim(Me.txtGereeldeBestGebore1.Text) <> "0" Then
            If Len(Trim(Me.txtGereeldeBestGebore1.Text)) < 4 Or Val(Trim(Me.txtGereeldeBestGebore1.Text)) > Year(Now) Or Val(Trim(Me.txtGereeldeBestGebore1.Text)) < (Year(Now) - 120) Or Val(Trim(Me.txtGereeldeBestGebore1.Text)) > (Year(Now) - 16) Then
                MsgBox("The year of birth is not correct." & Chr(13) & "of" & Chr(13) & "Age should be between 16 and 120.", MsgBoxStyle.Exclamation)
                Me.SSTab1.SelectedIndex = 5
                Me.txtGereeldeBestGebore1.Focus()
                validateForm = False
                Exit Function
            End If
        End If
        If Trim(Me.txtGereeldeBestGebore2.Text) <> "" And Trim(Me.txtGereeldeBestGebore2.Text) <> "0" Then
            If Len(Trim(Me.txtGereeldeBestGebore2.Text)) < 4 Or Val(Trim(Me.txtGereeldeBestGebore2.Text)) > Year(Now) Or Val(Trim(Me.txtGereeldeBestGebore2.Text)) < (Year(Now) - 120) Or Val(Trim(Me.txtGereeldeBestGebore2.Text)) > (Year(Now) - 16) Then
                MsgBox("The year of birth is not correct." & Chr(13) & "of" & Chr(13) & "Age should be between 16 and 120.", MsgBoxStyle.Exclamation)
                Me.SSTab1.SelectedIndex = 5
                Me.txtGereeldeBestGebore2.Focus()
                validateForm = False
                Exit Function
            End If
        End If
        If Trim(Me.txtGereeldeBestGebore3.Text) <> "" And Trim(Me.txtGereeldeBestGebore3.Text) <> "0" Then
            If Len(Trim(Me.txtGereeldeBestGebore3.Text)) < 4 Or Val(Trim(Me.txtGereeldeBestGebore3.Text)) > Year(Now) Or Val(Trim(Me.txtGereeldeBestGebore3.Text)) < (Year(Now) - 120) Or Val(Trim(Me.txtGereeldeBestGebore3.Text)) > (Year(Now) - 16) Then
                MsgBox("The year of birth is not correct." & Chr(13) & "of" & Chr(13) & "Age should be between 16 and 120.", MsgBoxStyle.Exclamation)
                Me.SSTab1.SelectedIndex = 5
                Me.txtGereeldeBestGebore3.Focus()
                validateForm = False
                Exit Function
            End If
        End If
        If Trim(Me.txtGereeldeBestGebore4.Text) <> "" And Trim(Me.txtGereeldeBestGebore4.Text) <> "0" Then
            If Len(Trim(Me.txtGereeldeBestGebore4.Text)) < 4 Or Val(Trim(Me.txtGereeldeBestGebore4.Text)) > Year(Now) Or Val(Trim(Me.txtGereeldeBestGebore4.Text)) < (Year(Now) - 120) Or Val(Trim(Me.txtGereeldeBestGebore4.Text)) > (Year(Now) - 16) Then
                MsgBox("The year of birth is not correct." & Chr(13) & "of" & Chr(13) & "Age should be between 16 and 120.", MsgBoxStyle.Exclamation)
                Me.SSTab1.SelectedIndex = 5
                Me.txtGereeldeBestGebore4.Focus()
                validateForm = False
                Exit Function
            End If
        End If

        'Nominated drivers
        If Trim(Me.txtGenomBestGebore1.Text) <> "" And Trim(Me.txtGenomBestGebore1.Text) <> "0" Then
            If Len(Trim(Me.txtGenomBestGebore1.Text)) < 4 Or Val(Trim(Me.txtGenomBestGebore1.Text)) > Year(Now) Or Val(Trim(Me.txtGenomBestGebore1.Text)) < (Year(Now) - 120) Or Val(Trim(Me.txtGenomBestGebore1.Text)) > (Year(Now) - 16) Then
                MsgBox("The year of birth is not correct." & Chr(13) & "of" & Chr(13) & "Age should be between 16 and 120.", MsgBoxStyle.Exclamation)
                Me.SSTab1.SelectedIndex = 5
                Me.txtGenomBestGebore1.Focus()
                validateForm = False
                Exit Function
            End If
        End If
        If Trim(Me.txtGenomBestGebore2.Text) <> "" And Trim(Me.txtGenomBestGebore2.Text) <> "0" Then
            If Len(Trim(Me.txtGenomBestGebore2.Text)) < 4 Or Val(Trim(Me.txtGenomBestGebore2.Text)) > Year(Now) Or Val(Trim(Me.txtGenomBestGebore2.Text)) < (Year(Now) - 120) Or Val(Trim(Me.txtGenomBestGebore2.Text)) > (Year(Now) - 16) Then
                MsgBox("The year of birth is not correct." & Chr(13) & "of" & Chr(13) & "Age should be between 16 and 120.", MsgBoxStyle.Exclamation)
                Me.SSTab1.SelectedIndex = 5
                Me.txtGenomBestGebore2.Focus()
                validateForm = False
                Exit Function
            End If
        End If

        'Kobus 07/08/2013 comment out
        'If cmbTipeDek.SelectedIndex = 2 And GridEkstras.RowCount > 2 Then
        '    'Kobus Visser - 25/02/2013 -  changed Accessiories to Vehcile Extras
        '    MsgBox("When only 3rd party coverage, the Vehicle zero and there can be no Vehicle Extras listed for cover.", MsgBoxStyle.Exclamation)
        '    validateForm = False
        '    Exit Function
        'End If

        'Kobus 16/08/2013 voegby
        If Me.txtWaardeEkstras.Text = "" Then
            txtWaardeEkstras.Text = 0
        End If
        If Me.txtWaarde.Text = "" Then
            txtWaarde.Text = 0
        End If
        'Kobus 28/01/2014 voegby - bln1stIdentification aktiveer by Tipe dekking Index Canged waar indeks 2 is
        '3rd Party test
        'If bln1stIdentification = True And cmbTipeDek.SelectedIndex = 2 And strRemove = "" Then
        '    MsgBox("Type of cover is Third party. Remove all extras on vehicle before exit.", MsgBoxStyle.Exclamation)
        '    InformationChanged = True
        '    editing = True
        '    'calcTotValue()
        '    'calcPremium()
        '    'Kobus 15/11/2013 voegby
        '    btnCancel.Enabled = False
        '    Me.SSTab1.SelectedIndex = 7
        '    ' Me.btnVerwyder.Focus()
        '    validateForm = False
        '    Exit Function
        'End If
        'End If
        If Me.chkHuurkoop.CheckState And (Me.cmbHuurInstansie.SelectedIndex = -1 Or Me.cmbHuurInstansie.SelectedIndex = 0) Then
            'Kobus Visser - 26/02/2013 - Changed message as per 5.18 QA
            'Kobus 19/03/2014 verander van "The Hire Purchase Institution is outstanding, but can be added later."
            MsgBox("Please select a Hire Purchase Institution.", MsgBoxStyle.Exclamation)
            validateForm = False
            'Kobus 24/03/2014 voegby
            blnInformationChanged = True
            Me.SSTab1.SelectedIndex = 4
            Me.txtHuurNommer.Focus()
            blnNoExit = True
            Return False
            Exit Function
        End If
        'Kobus 05/09/2013 comment out - this field is not in use - 5.85
        'If (Me.cmbHuurInstansie.SelectedIndex <> -1 And Me.cmbHuurInstansie.SelectedIndex <> 0) And Trim(Me.txtHuurNommer.Text) = "" Then
        '    'Kobus Visser - 26/02/2013 - Changed message as per 5.18 QA
        '    MsgBox("The account number of the Hire Purchase Institution is outstanding, but can be added later.", MsgBoxStyle.Exclamation)
        '    validateForm = True
        'End If

        'Kobus Visser 28/03/2013 add condition "" to 0
        If CStr(txtCourtesyVehAmount.Text) = "0" Then
        End If
        If (Not (IsNumeric(txtCourtesyVehAmount.Text))) Then
            'Kobus Visser 28/03/2013 change message from: The Event Engine amount must be numeric!
            MsgBox("The courtesy vehicle amount must be numeric!", 48, "Error!")
            txtCourtesyVehAmount.Focus()
            validateForm = False
            Exit Function
        End If

        'Form validated
        blnValidationOk = True
        validateForm = True
        'Kobus 10/12/2013 voegby
        blnNoExit = False
    End Function
    'Log the alterations done on the specific policy (vehicles)
    Public Sub logAlterations()
        'Kobus 08/04/2014 voegby
        Dim blnDone As Boolean = False
        'Kobus 31/03/2014 voegby 
        If blnPol_Byvoeg Or blnByvoeg Then
            'Don't log alterations if a new policy
        Else
            'Kobus 30/01/2014 comment out
            'A new vehicle was added
            Dim v_ander As Integer
            Dim VssRatingJN As String
            If pkVoertuie = 0 Then
                strBeskrywing = Trim(Me.txtMaak.Text) & " " & Trim(Me.txtBesk.Text) & " " & Me.txtJaar.Text & " " & Me.txtNPlaat.Text
                UpdateWysig((8), strBeskrywing)
                blnediting = False
                'Kobus 08/04/2014 voegby
                Exit Sub
                'Kobus 05/02/2014 comment out op grond van 5.143
                'Dim decWaarde As Decimal
                'decWaarde = 0
                'If Persoonl.TAAL = 0 Then
                '    strBeskrywing = " wysig vanaf (" & decWaarde & ") na (" & txtWaarde.Text & ") op voertuig (" & txtNPlaat.Text & ")"
                'Else
                '    strBeskrywing = " change from (" & decWaarde & ") to (" & txtWaarde.Text & ") on vehicle (" & txtNPlaat.Text & ")"
                'End If
                'UpdateWysig((64), strBeskrywing)
                'If Persoonl.TAAL = 0 Then
                '    strBeskrywing = " wysig vanaf (" & Format(Val(decWaarde), "########0.00") & ") na (" & Format(Val(txtPremie.Text), "########0.00") & ") op voertuig (" & txtNPlaat.Text & ")"
                'Else
                '    strBeskrywing = " change from (" & Format(Val(decWaarde), "########0.00") & ") to (" & Format(Val(txtPremie.Text), "########0.00") & ") on vehicle (" & txtNPlaat.Text & ")"
                'End If
                'UpdateWysig((6), strBeskrywing)
                ''addnew = False
                ''Exit Sub
            Else
                'Kobus 30/01/2014 voegby om nulwaarde ekstras te rëel
                If blnNilvalueEkstra = True And blnNoRepeat1 = False Then
                    blnNoRepeat1 = True
                    'Exit Sub
                End If
                'Kobus 23/01/2014 comment out
                ''Kobus 13/12/2013 voegby
                'If blnNilvalueEkstra = True Then
                '    blnNilvalueEkstra = False
                'Else
                'Kobus 12/12/2013 voegby om gewysigde waardes en premies by verwydering van Ekstras aan te teken 
                'Kobus 23/01/2014 vernader van If strRemove = "Extra" Then
                'Kobus 29/01/2014 verander weer van If strRemove = "Extra" And blnNilvalueEkstra = False Then
                If blnRestorTypeCover = False And (strRemove = "Extra" Or strRemove = "Yes" Or blnAddnew = True) And blnCancel <> True Then
                    If txtWaarde.Text <> voertuie.WAARDE Then
                        If Persoonl.TAAL = 0 Then
                            strBeskrywing = " wysig vanaf (" & voertuie.WAARDE & ") na (" & txtWaarde.Text & ") op voertuig (" & txtNPlaat.Text & ")"
                        Else
                            strBeskrywing = " change from (" & voertuie.WAARDE & ") to (" & txtWaarde.Text & ") on vehicle (" & txtNPlaat.Text & ")"
                        End If
                        UpdateWysig((64), strBeskrywing)
                    End If

                    ' Premie
                    If Format(Val(txtPremie.Text), "########0.00") <> voertuie.PREMIE Then  'txtPremie.Text
                        If Persoonl.TAAL = 0 Then
                            strBeskrywing = " wysig vanaf (" & Format(Val(voertuie.PREMIE), "########0.00") & ") na (" & Format(Val(txtPremie.Text), "########0.00") & ") op voertuig (" & txtNPlaat.Text & ")"
                        Else
                            strBeskrywing = " change from (" & Format(Val(voertuie.PREMIE), "########0.00") & ") to (" & Format(Val(txtPremie.Text), "########0.00") & ") on vehicle (" & txtNPlaat.Text & ")"
                        End If
                        UpdateWysig((6), strBeskrywing)
                        'Kobus 08/04/2014 voegby
                        blnDone = True
                    End If
                    'Kobus 30/01/2014 comment out - beter om niks teskryf as dit 'n nulwaarde ekstra is
                    ''Kobus 29/01/2014 voegby
                    'If blnNilvalueEkstra = True And blnNoRepeat1 = False Then
                    '    blnNoRepeat1 = True
                    '    'waarde
                    '    If Persoonl.TAAL = 0 Then
                    '        strBeskrywing = " wysig vanaf (" & voertuie.WAARDE & ") na (" & dblWaarde & ") op voertuig (" & txtNPlaat.Text & ")"
                    '    Else
                    '        strBeskrywing = " change from (" & voertuie.WAARDE & ") to (" & dblWaarde & ") on vehicle (" & txtNPlaat.Text & ")"
                    '    End If
                    '    UpdateWysig((64), strBeskrywing)


                    '    'Kobus 29/01/2014 voegby
                    '    'premie
                    '    If Persoonl.TAAL = 0 Then
                    '        strBeskrywing = " wysig vanaf (" & Format(Val(voertuie.PREMIE), "########0.00") & ") na (" & Format(Val(decPremie), "########0.00") & ") op voertuig (" & txtNPlaat.Text & ")"
                    '    Else
                    '        strBeskrywing = " change from (" & Format(Val(voertuie.PREMIE), "########0.00") & ") to (" & Format(Val(decPremie), "########0.00") & ") on vehicle (" & txtNPlaat.Text & ")"
                    '    End If
                    '    UpdateWysig((6), strBeskrywing)
                    'End If
                    'Kobus 07/02/2014 voegby
                    If blnAddnew = True Then
                        strRemove = "N/A"
                    Else
                        strRemove = "Final"
                    End If
                    'Kobus 07/02/2014 comment out
                    'Exit Sub
                End If
                'Kobus 30/01/2014 - comment out
                'If strRemove = "Extra" And blnNilvalueEkstra = True Then
                '    'blnNilvalueEkstra = False
                '    Exit Sub
                'End If


                'Kobus 04/09/2013 voegby    
                If txtAnder.Text = False And strCurrentVehicle <> "NewVehicleExtras" Then
                    'Kobus 19/05/04/2014 verander van motor = FetchMotor()
                    'voertuie = FetchVoertuie()
                ElseIf txtAnder.Text = True And strCurrentVehicle = "newVehicleExtras" Then
                    ReadAVoertuig(txtJaar.Text.Substring(0, 2), txtJaar.Text.Substring(2, 2), txtKode.Text)
                End If
                'Kobus verander If v_ander <> voertuie.ANDER Then
                If txtAnder.Text <> voertuie.ANDER Then
                    If txtAnder.Text = False Then
                        v_ander = 0
                    Else
                        v_ander = 1
                    End If

                    If CBool(v_ander) <> blnAnder Then
                        If Persoonl.TAAL = 0 Then
                            If txtAnder.Text Then
                                'Kobus 30/08/2013 verander 
                                'strBeskrywing = " verander na (Diverse) op voertuig (" & txtNPlaat.Text & ")"
                                strBeskrywing = " verander na Diverse voertuie op voertuig (" & txtNPlaat.Text & ")"
                                UpdateWysig((187), strBeskrywing)
                            Else
                                strBeskrywing = " verander na Motorgidsvoertuie op voertuig (" & txtNPlaat.Text & ")"
                                UpdateWysig((187), strBeskrywing)
                            End If
                        Else
                            If txtAnder.Text Then
                                strBeskrywing = " changed to non Auto Guide Vehicle on vehicle (" & txtNPlaat.Text & ")"
                                UpdateWysig((187), strBeskrywing)
                            Else
                                strBeskrywing = " changed to Auto Guide Vehicles on vehicle (" & txtNPlaat.Text & ")"
                                UpdateWysig((187), strBeskrywing)
                            End If
                        End If
                        'Kobus 16/07/2013 sluit toets op v_ander
                    End If
                End If
                ' Color
                If txtKleur.Text <> voertuie.kleur Then
                    If Persoonl.TAAL = 0 Then
                        strBeskrywing = " wysig vanaf (" & voertuie.kleur & ") na (" & txtKleur.Text & ") op voertuig (" & txtNPlaat.Text & ")"
                    Else
                        strBeskrywing = " change from (" & voertuie.kleur & ") to (" & txtKleur.Text & ") on vehicle (" & txtNPlaat.Text & ")"
                    End If
                    UpdateWysig((123), strBeskrywing)
                End If

                'Kilometer(reading)
                If txtKilometerLesing.Text <> voertuie.kilometerlesing Then
                    If Persoonl.TAAL = 0 Then
                        strBeskrywing = " wysig vanaf (" & Format(voertuie.kilometerlesing) & ") na (" & txtKilometerLesing.Text & ") op voertuig (" & txtNPlaat.Text & ")"
                    Else
                        strBeskrywing = " change from (" & Format(voertuie.kilometerlesing) & ") to (" & txtKilometerLesing.Text & ") on vehicle (" & txtNPlaat.Text & ")"
                    End If
                    UpdateWysig((124), strBeskrywing)
                End If

                'Enjin(number)
                If txtEnjinNommer.Text <> voertuie.enjinnommer Then
                    If Persoonl.TAAL = 0 Then
                        strBeskrywing = " wysig vanaf (" & voertuie.enjinnommer & ") na (" & txtEnjinNommer.Text & ") op voertuig (" & txtNPlaat.Text & ")"
                    Else
                        strBeskrywing = " change from (" & voertuie.enjinnommer & ") to (" & txtEnjinNommer.Text & ") on vehicle (" & txtNPlaat.Text & ")"
                    End If
                    UpdateWysig((125), strBeskrywing)
                End If

                'Chassis(number)
                If txtOnderstelNommer.Text <> voertuie.onderstelnommer Then
                    If Persoonl.TAAL = 0 Then
                        strBeskrywing = " wysig vanaf (" & voertuie.onderstelnommer & ") na (" & txtOnderstelNommer.Text & ") op voertuig (" & txtNPlaat.Text & ")"
                    Else
                        strBeskrywing = " change from (" & voertuie.onderstelnommer & ") to (" & txtOnderstelNommer.Text & ") on vehicle (" & txtNPlaat.Text & ")"
                    End If
                    UpdateWysig((126), strBeskrywing)
                End If

                If chkVssRatingJN.Checked = True Then
                    VssRatingJN = "Ja"
                Else
                    VssRatingJN = "Nee"
                End If
                'VssRatingJN
                'VSSRatingjn
                If VssRatingJN <> voertuie.vssratingjn Then
                    If Persoonl.TAAL = 0 Then
                        strBeskrywing = " wysig vanaf (" & voertuie.vssratingjn & ") na (" & chkVssRatingJN.Checked & ") op voertuig (" & txtNPlaat.Text & ")"
                    Else
                        strBeskrywing = " change from (" & voertuie.vssratingjn & ") to (" & chkVssRatingJN.Checked & ") on vehicle (" & txtNPlaat.Text & ")"
                    End If
                    UpdateWysig((128), strBeskrywing)
                End If

                'VSSRatingBesk
                If txtVSSRatingBesk.Text <> voertuie.vssratingbesk Then
                    If Persoonl.TAAL = 0 Then
                        strBeskrywing = " wysig vanaf (" & voertuie.vssratingbesk & ") na (" & txtVSSRatingBesk.Text & ") op voertuig (" & txtNPlaat.Text & ")"
                    Else
                        strBeskrywing = " change from (" & voertuie.vssratingbesk & ") to (" & txtVSSRatingBesk.Text & ") on vehicle (" & txtNPlaat.Text & ")"
                    End If
                    UpdateWysig((129), strBeskrywing)
                End If

                'Gebruik
                'Kobus 08/07/2013 change condition If cmbGebruik.Text <> voertuie.GEBRUIK Then
                Dim strGebruik As String
                strGebruik = cmbGebruik.SelectedIndex + 1
                If strGebruik <> voertuie.GEBRUIK Then
                    If Persoonl.TAAL = 0 Then
                        strBeskrywing = " wysig na (" & Me.cmbGebruik.Text & ") op voertuig (" & txtNPlaat.Text & ")"
                    Else
                        strBeskrywing = " change to (" & Me.cmbGebruik.Text & ") on vehicle (" & txtNPlaat.Text & ")"
                    End If
                    UpdateWysig((4), strBeskrywing)
                End If

                'Tipe(dekking)
                'Kobus 24/03/2014 voegby
                If cmbTipeDek.SelectedIndex = 2 And txtPremieEkstras.Text <> "0" And blnCancel = True Then
                    'skip
                Else
                    'Kobus 08/07/2013 change test condition from If cmbTipeDek.Text <> voertuie.TIPE_DEK Then
                    Dim strTipedekking As String

                    strTipedekking = cmbTipeDek.SelectedIndex + 1
                    'Kobus 28/01/2014 voegby 'and strRemove <> "Final" 17/03/2014 voegby or blnCancel = False
                    If strTipedekking <> voertuie.TIPE_DEK And (strRemove = "" Or strRemove = "Final" Or strRemove = "N/A" Or strRemove = "Extra") And blnCancel = False Then
                        If Persoonl.TAAL = 0 Then
                            strBeskrywing = " wysig na (" & Me.cmbTipeDek.Text & ") op voertuig (" & txtNPlaat.Text & ")"
                        Else
                            strBeskrywing = " change to (" & Me.cmbTipeDek.Text & ") on vehicle (" & txtNPlaat.Text & ")"
                        End If
                        UpdateWysig((5), strBeskrywing)
                    End If

                End If
                'Kobus 19/4/2014 voegby
                'If strTipedekking <> voertuie.TIPE_DEK Then
                '    If Persoonl.TAAL = 0 Then
                '        strBeskrywing = " wysig na (" & Me.cmbTipeDek.Text & ") op voertuig (" & txtNPlaat.Text & ")"
                '    Else
                '        strBeskrywing = " change to (" & Me.cmbTipeDek.Text & ") on vehicle (" & txtNPlaat.Text & ")"
                '    End If
                '    UpdateWysig((5), strBeskrywing)
                'End If

                'UpdateWysig((5), strBeskrywing)


                'Waarde
                'Kobus 12/12/2013 voegby  - and strRemove = "" 7/4/2014 VERWYDER DIE VOLGENDE And (strRemove = "" Or strRemove = "Final" Or strRemove = "N/A")

                If (txtWaarde.Text <> voertuie.WAARDE) And blnDone = False And blnCancel = False Then
                    'Kobus 16/05/2014 voegby
                    If txtWaarde.Text = txtWaardeEkstras.Text And cmbTipeDek.SelectedIndex = 2 And txtWaardeEkstras.Text <> 0 Then
                    Else
                        'And bln1stIdentification = True Then
                        If Persoonl.TAAL = 0 Then
                            'Kobus 08/07/2013 voeg format by
                            'Kobus 10/07/2013 haal format uit
                            strBeskrywing = " wysig vanaf (" & voertuie.WAARDE & ") na (" & txtWaarde.Text & ") op voertuig (" & txtNPlaat.Text & ")"
                        Else
                            strBeskrywing = " change from (" & voertuie.WAARDE & ") to (" & txtWaarde.Text & ") on vehicle (" & txtNPlaat.Text & ")"
                        End If
                        UpdateWysig((64), strBeskrywing)
                        'bln1stIdentification = False
                    End If

                End If
                ' Premie
                'Kobus 12/12/2013 voegby  - and strRemove = "" 7/4/2014 VERWYDER DIE VOLGENDE And (strRemove = "" Or strRemove = "Final" Or strRemove = "N/A")
                'Kobus 16/05/2014 voegby
                If txtWaarde.Text = txtWaardeEkstras.Text And cmbTipeDek.SelectedIndex = 2 And txtWaardeEkstras.Text <> 0 Then
                Else
                    If (Format(Val(txtPremie.Text), "########0.00") <> voertuie.PREMIE) And blnDone = False And blnCancel = False Then
                        If Persoonl.TAAL = 0 Then
                            'Kobus 4/7/13 change from " wysig vanaf (" & voertuie.PREMIE & ") na (" & txtPremie.Text & ") op voertuig (" & txtNPlaat.Text & ")"
                            strBeskrywing = " wysig vanaf (" & Format(Val(voertuie.PREMIE), "########0.00") & ") na (" & Format(Val(txtPremie.Text), "########0.00") & ") op voertuig (" & txtNPlaat.Text & ")"
                        Else
                            strBeskrywing = " change from (" & Format(Val(voertuie.PREMIE), "########0.00") & ") to (" & Format(Val(txtPremie.Text), "########0.00") & ") on vehicle (" & txtNPlaat.Text & ")"
                        End If
                        UpdateWysig((6), strBeskrywing)
                        bln1stIdentification = False
                    End If
                End If
                'waarde Tipe
                'Kobus 12/05/2014 voegby
                'Kobus 19/05/2014 comment out en verander
                'If cmbWaardeTipe.Text <> strWaardeTipe Then
                If cmbWaardeTipe.SelectedIndex <> voertuie.waardetipe Then
                    If Persoonl.TAAL = 0 Then
                        strBeskrywing = " wysig van (" & strWaardeTipe & ") na (" & Me.cmbWaardeTipe.Text & ") op voertuig (" & txtNPlaat.Text & ")"
                    Else
                        strBeskrywing = " change from (" & strWaardeTipe & ") to (" & Me.cmbWaardeTipe.Text & ") on vehicle (" & txtNPlaat.Text & ")"
                    End If
                    UpdateWysig((195), strBeskrywing)
                End If

                'End If


                'Registration(number)
                If txtNPlaat.Text <> voertuie.N_PLAAT Then
                    If Persoonl.TAAL = 0 Then
                        strBeskrywing = " wysig na (" & txtNPlaat.Text & ") op voertuig (" & voertuie.N_PLAAT & ")"
                    Else
                        strBeskrywing = " change to (" & txtNPlaat.Text & ") on vehicle (" & voertuie.N_PLAAT & ")"
                    End If
                    UpdateWysig((52), strBeskrywing)
                End If

                'Diverse(BESKRYWING)
                'Kobus 19/08/2013 voegby
                Dim strBesk As String
                strBesk = strDiverseBesk
                'If txtBesk.Text <> motor.Model_beskrywing Then
                If txtBesk.Text <> strBesk Then
                    If Persoonl.TAAL = 0 Then
                        strBeskrywing = " wysig van (" & strDiverseBesk & ")  na (" & Trim(Me.txtBesk.Text) & ") op voertuig (" & txtNPlaat.Text & ")"
                    Else
                        strBeskrywing = " change from (" & strDiverseBesk & ")  na (" & Trim(Me.txtBesk.Text) & ") op voertuig (" & txtNPlaat.Text & ")"
                    End If
                    UpdateWysig((54), strBeskrywing)
                End If

                'Oornag(adres)
                'Kobus 11/11/2013 verander hele aksie
                'If txtPoskode.Text <> voertuie.Poskode Then
                '    If Persoonl.TAAL = 0 Then
                '        strBeskrywing = " vanaf (" & voertuie.Voorstad & "," & voertuie.Poskode & ") na (" & txtVoorstad.Text & "," & txtPoskode.Text & ") Voertuig: " & txtNPlaat.Text
                '    Else
                '        strBeskrywing = " from (" & voertuie.Voorstad & "," & voertuie.Poskode & ") to (" & txtVoorstad.Text & "," & txtPoskode.Text & ") Vehicle: " & txtNPlaat.Text
                '    End If
                '    UpdateWysig((173), strBeskrywing)
                'End If
                If txtAdres.Text <> voertuie.Adres Or txtVoorstad.Text <> voertuie.Voorstad Then
                    If Persoonl.TAAL = 0 Then
                        strBeskrywing = " vanaf (" & voertuie.Adres & "," & voertuie.Voorstad & "," & voertuie.Poskode & ") na (" & txtAdres.Text & "," & txtVoorstad.Text & "," & txtPoskode.Text & ") Voertuig: " & txtNPlaat.Text
                    Else
                        strBeskrywing = " from (" & voertuie.Adres & "," & voertuie.Voorstad & "," & voertuie.Poskode & ") to (" & txtAdres.Text & "," & txtVoorstad.Text & "," & txtPoskode.Text & ") Vehicle: " & txtNPlaat.Text
                    End If
                    UpdateWysig((173), strBeskrywing)
                End If

                'Huurkoop(instansie)
                If Trim(cmbHuurInstansie.Text) <> Trim(voertuie.huurinstansie) Then
                    If Persoonl.TAAL = 0 Then
                        strBeskrywing = " verander vanaf (" & voertuie.huurinstansie & ") na (" & cmbHuurInstansie.Text & ") Voertuig: " & txtNPlaat.Text
                    Else
                        strBeskrywing = " change from (" & voertuie.huurinstansie & ") to (" & cmbHuurInstansie.Text & ") Vehicle: " & txtNPlaat.Text
                    End If
                    UpdateWysig((71), strBeskrywing)
                End If

                'Kobus 10/09/2013 - in onbruik - 5.85 - moet nog steeds wysigings skryf
                'Huurkoop(rekeningnommer)
                If Trim(txtHuurNommer.Text) <> Trim(voertuie.huurnommer) Then
                    If Persoonl.TAAL = 0 Then
                        strBeskrywing = " verander vanaf (" & voertuie.huurnommer & ") na (" & txtHuurNommer.Text & ") Voertuig: " & txtNPlaat.Text
                    Else
                        strBeskrywing = " change from (" & voertuie.huurnommer & ") to (" & txtHuurNommer.Text & ") Vehicle: " & txtNPlaat.Text
                    End If
                    UpdateWysig((72), strBeskrywing)
                End If

                'Persentasie van Premie
                If txtPremiePersentasie.Text <> voertuie.PremiePersentasie Then
                    If Persoonl.TAAL = 0 Then
                        strBeskrywing = " vanaf " & voertuie.PremiePersentasie & " na " & txtPremiePersentasie.Text & " Voertuig: " & txtNPlaat.Text
                    Else
                        strBeskrywing = " from " & voertuie.PremiePersentasie & " to " & txtPremiePersentasie.Text & " Vehicle: " & txtNPlaat.Text
                    End If
                    UpdateWysig((175), strBeskrywing)
                End If

                'Security
                If voertuie.SekuriteitBitValue <> voertuie.SekuriteitBitValue Then
                    If Persoonl.TAAL = 0 Then
                        strBeskrywing = "verander na (" & gen_getVehicleSecurity(0, voertuie.SekuriteitBitValue) & ") op Voertuig: " & txtNPlaat.Text
                    Else
                        strBeskrywing = "changes to (" & gen_getVehicleSecurity(1, voertuie.SekuriteitBitValue) & ") on Vehicle: " & txtNPlaat.Text
                    End If
                    UpdateWysig((7), strBeskrywing)
                End If

                'Geleentheidsvoertuig()
                If IIf(IsDBNull(txtCourtesyVehAmount.Text), 0, txtCourtesyVehAmount.Text) <> IIf(IsDBNull(voertuie.CourtesyVehAmount), 0, voertuie.CourtesyVehAmount) Then
                    If Persoonl.TAAL = 0 Then
                        strBeskrywing = " verander vanaf (" & voertuie.CourtesyVehAmount & ") na (" & txtCourtesyVehAmount.Text & ") op Voertuig: " & txtNPlaat.Text
                    Else
                        strBeskrywing = " changes from (" & voertuie.CourtesyVehAmount & ") to (" & txtCourtesyVehAmount.Text & ") on Vehicle: " & txtNPlaat.Text
                    End If
                    UpdateWysig((75), strBeskrywing)
                End If
                'Kobus 16/07/2013 sluit toets op v_ander hoër op
                'End If 
            End If 'if pkVoertuie = 0 then
        End If  ' New policy
    End Sub
    'populate the grid with information

    Public Sub PopulateGridEkstras()
        GridEkstras.AutoGenerateColumns = False
        GridEkstras.DataSource = FetchVoertuieEkstrasForGrid()
        GridEkstras.Refresh()
        'Kobus 
    End Sub

    Public Function FetchVoertuieEkstrasForGrid() As List(Of VoertuieEkstrasEnity)
        Dim i As Integer 'Kobus 25/01/2013
        i = 0

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@fkVoertuie", SqlDbType.Int), _
                                               New SqlParameter("@taal", SqlDbType.NVarChar)}

                If blnediting Then
                    If Not glbPolicyNumber = Nothing Then
                        'Kobus 3/08/2013 voegby
                        If strCurrentVehicle = "NewVehicleExtras" Then
                            pkVoertuie = pkVoertuie 'intPkVoertuigEkstras
                        Else
                            pkVoertuie = CInt(Form1.dgvPoldataVoertuie.SelectedRows(0).Cells(0).Value)
                        End If
                        'Kobus comment out toets
                        'If Form1.Grid1.RowCount <> 0 Then
                        '    MsgBox("Please select a vehicle.")
                        'End If
                        'End If
                        'Kobus 06/02/2014 voeg voorwaarde by
                        If strRemove = "Yes" Or strRemove = "Extra" Or strRemove = "Final" Then
                            pkVoertuie = intpkVoertuie
                            param(0).Value = pkVoertuie
                        Else
                            param(0).Value = pkVoertuie
                        End If

                    Else
                        param(0).Value = DBNull.Value
                    End If
                End If
                param(1).Value = Persoonl.TAAL

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuieEkstras_And_Standard", param)

                Dim list As New List(Of VoertuieEkstrasEnity)
                While reader.Read
                    Dim item As VoertuieEkstrasEnity = New VoertuieEkstrasEnity()

                    If reader("pkVoertuieEkstras") IsNot DBNull.Value Then
                        item.pkVoertuieEkstras = reader("pkVoertuieEkstras")
                    End If

                    If reader("ItemTipe") IsNot DBNull.Value Then
                        item.Beskrywing = reader("ItemTipe")
                    End If
                    If reader("Aanvang") IsNot DBNull.Value Then
                        item.DatumIn = reader("Aanvang")
                    End If
                    If reader("SerieNommer") IsNot DBNull.Value Then
                        item.SerieNommer = reader("SerieNommer")
                    End If
                    If reader("PremieR") IsNot DBNull.Value Then
                        'Kobus Visser 28/02/2013 format PremieR - No joy
                        'item.Premie = reader("PremieR")
                        'Linkie 05/07/2013item.Premie = Format(Val(reader("PremieR")), "######0.00")
                        item.Premie = reader("PremieR")
                    End If
                    If reader("WaardeR") IsNot DBNull.Value Then
                        'Kobus 06/06/2013 reader("WaardeR")
                        item.Waarde = FormatNumber(reader("WaardeR"), 0)
                    End If

                    If reader("Fabrikaat") IsNot DBNull.Value Then
                        item.Fabrikaat = reader("Fabrikaat")
                    End If
                    If reader("Model") IsNot DBNull.Value Then
                        item.Model = reader("Model")

                    End If

                    list.Add(item)
                    i = i - 1

                    'Kobus Visser - 26/02/2013 - Changed Totaal to Total
                    If reader("ItemTipe") = "Total" Then

                    End If

                End While
                Return list
                conn.Close()
            End Using
            'Kobus 05/08/2013 voegby
            Me.txtWaardeEkstras.Text = CDec("TotWaarde")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function

    Sub SaveVoertuieDetails()
        'Kobus 24/01/2014 voegby om dit slegs eenmalig te aktiveer
        'logAlterations()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@PremieEkstras", SqlDbType.Money), _
                                                New SqlParameter("@WaardeEkstras", SqlDbType.Money), _
                                                New SqlParameter("@TIPE", SqlDbType.NVarChar), _
                                                New SqlParameter("@N_PLAAT", SqlDbType.NVarChar), _
                                                New SqlParameter("@TIPE_DEK", SqlDbType.NVarChar), _
                                                New SqlParameter("@GEBRUIK", SqlDbType.NVarChar), _
                                                New SqlParameter("@CourtesyVehAmount", SqlDbType.Money), _
                                                New SqlParameter("@WAARDE", SqlDbType.Money), _
                                                New SqlParameter("@PREMIE", SqlDbType.Money), _
                                                New SqlParameter("@WaardeVoertuig", SqlDbType.Money), _
                                                New SqlParameter("@PremieVoertuig", SqlDbType.Money), _
                                                New SqlParameter("@JAAR", SqlDbType.NVarChar), _
                                                New SqlParameter("@ANDER", SqlDbType.Int), _
                                                New SqlParameter("@motorstatus", SqlDbType.NVarChar), _
                                                New SqlParameter("@huurinstansie", SqlDbType.NVarChar), _
                                                New SqlParameter("@huurnommer", SqlDbType.NVarChar), _
                                                New SqlParameter("@EEU", SqlDbType.NVarChar), _
                                                New SqlParameter("@enjinnommer", SqlDbType.NVarChar), _
                                                New SqlParameter("@onderstelnommer", SqlDbType.NVarChar), _
                                                New SqlParameter("@kleur", SqlDbType.NVarChar), _
                                                New SqlParameter("@vssratingbesk", SqlDbType.NVarChar), _
                                                New SqlParameter("@waardeTipe", SqlDbType.Int), _
                                                New SqlParameter("@Adres", SqlDbType.NVarChar), _
                                                New SqlParameter("@Adres2", SqlDbType.NVarChar), _
                                                New SqlParameter("@AreaBeskrywing", SqlDbType.NVarChar), _
                                                New SqlParameter("@AreaFrekwensie", SqlDbType.NVarChar), _
                                                New SqlParameter("@Eienaar", SqlDbType.NVarChar), _
                                                New SqlParameter("@Poskode", SqlDbType.NVarChar), _
                                                New SqlParameter("@Stad", SqlDbType.NVarChar), _
                                                New SqlParameter("@Voorstad", SqlDbType.NVarChar), _
                                                New SqlParameter("@OornagBeskrywing", SqlDbType.NVarChar), _
                                                New SqlParameter("@Motorhuis", SqlDbType.TinyInt), _
                                                New SqlParameter("@ingevoer", SqlDbType.TinyInt), _
                                                New SqlParameter("@LaeProfielbande", SqlDbType.TinyInt), _
                                                New SqlParameter("@Motorplan", SqlDbType.TinyInt), _
                                                New SqlParameter("@Huurkoop", SqlDbType.Int), _
                                                New SqlParameter("@kilometerlesing", SqlDbType.Float), _
                                                New SqlParameter("@MotorplanKm", SqlDbType.Int), _
                                                New SqlParameter("@vssratingjn", SqlDbType.NVarChar), _
                                                New SqlParameter("@KmPerJaar", SqlDbType.Int), _
                                                New SqlParameter("@GenomBestuurder1", SqlDbType.NVarChar), _
                                                New SqlParameter("@GenomBestuurder2", SqlDbType.NVarChar), _
                                                New SqlParameter("@GenomBestGebore1", SqlDbType.Int), _
                                                New SqlParameter("@GenomBestGebore2", SqlDbType.Int), _
                                                New SqlParameter("@GereeldeBestuurder1", SqlDbType.NVarChar), _
                                                New SqlParameter("@GereeldeBestuurder2", SqlDbType.NVarChar), _
                                                New SqlParameter("@GereeldeBestuurder3", SqlDbType.NVarChar), _
                                                New SqlParameter("@GereeldeBestuurder4", SqlDbType.NVarChar), _
                                                New SqlParameter("@GereeldeBestGebore1", SqlDbType.Int), _
                                                New SqlParameter("@GereeldeBestGebore2", SqlDbType.Int), _
                                                New SqlParameter("@GereeldeBestGebore3", SqlDbType.Int), _
                                                New SqlParameter("@GereeldeBestGebore4", SqlDbType.Int), _
                                                New SqlParameter("@KmLesingDatum", SqlDbType.NVarChar), _
                                                New SqlParameter("@MotorplanVervalDat", SqlDbType.NVarChar), _
                                                New SqlParameter("@PersentasieWaarde", SqlDbType.Int), _
                                                New SqlParameter("@PremiePersentasie", SqlDbType.Int), _
                                                New SqlParameter("@PersentasieOp", SqlDbType.NVarChar), _
                                                New SqlParameter("@SekuriteitBitValue", SqlDbType.Int), _
                                                New SqlParameter("@cancelled", SqlDbType.Int), _
                                                New SqlParameter("@KODE", SqlDbType.NVarChar)}

                'Kobus 29/08/2013 Form1.POLISNO.Text met glbpolicynumber
                params(0).Value = glbPolicyNumber
                params(1).Value = CDec(txtPremieEkstras.Text)
                params(2).Value = CDec(txtWaardeEkstras.Text)
                params(3).Value = CStr(cmbTipe.SelectedIndex + 1)
                params(4).Value = txtNPlaat.Text
                params(5).Value = CStr(cmbTipeDek.SelectedIndex + 1)
                params(6).Value = CStr(cmbGebruik.SelectedIndex + 1)
                params(7).Value = CDec(txtCourtesyVehAmount.Text)
                'Kobus 10/7/2013 verander na Cdec
                params(8).Value = CDec(txtWaarde.Text)
                'Kobus 11/7/2013 voeg by CDec
                params(9).Value = CDec(txtPremie.Text)
                'Kobus 11/7/2013 verander van CInt na CDec
                params(10).Value = CDec(txtWaardeVoertuig.Text)
                'Kobus 9/7/13 verander van CInt na Cdec
                params(11).Value = CDec(txtPremieVoor.Text)
                params(12).Value = Mid(txtJaar.Text, 3)
                If txtAnder.Text = "False" Then
                    params(13).Value = 0
                Else
                    params(13).Value = 1
                End If
                'params(13).Value = txtAnder.Text
                params(14).Value = cmbMotorStatus.Text
                params(15).Value = cmbHuurInstansie.Text
                params(16).Value = txtHuurNommer.Text
                params(17).Value = Mid(txtJaar.Text, 1, 2)
                'Kobus 12/11/2013 voegby trim
                params(18).Value = Trim(txtEnjinNommer.Text)
                params(19).Value = Trim(txtOnderstelNommer.Text)
                params(20).Value = txtKleur.Text
                params(21).Value = txtVSSRatingBesk.Text
                params(22).Value = CInt(cmbWaardeTipe.SelectedIndex)
                params(23).Value = Trim(txtAdres.Text)
                params(24).Value = Trim(txtAdres2.Text)
                params(25).Value = Trim(cmbAreaBeskrywing.Text)

                If cmbAreaFrekwensie.SelectedIndex = -1 Then
                    params(26).Value = 0
                Else
                    params(26).Value = cmbAreaFrekwensie.Text
                End If

                params(27).Value = Trim(txtEienaar.Text)
                params(28).Value = Trim(txtPoskode.Text)
                params(29).Value = Trim(txtStad.Text)
                params(30).Value = txtVoorstad.Text

                If Me.chkMotorHuis.CheckState Then
                    params(31).Value = ""
                    params(32).Value = 1
                Else
                    params(31).Value = Me.txtOornagBeskrywing.Text
                    params(32).Value = 0
                End If
                If chkIngevoer.CheckState = CheckState.Checked Then
                    params(33).Value = 1
                Else
                    params(33).Value = 0
                End If
                If chkLaeProfielBande.CheckState = CheckState.Checked Then
                    params(34).Value = 1
                Else
                    params(34).Value = 0
                End If
                If chkMotorplan.CheckState = CheckState.Checked Then
                    params(35).Value = 1
                Else
                    params(35).Value = 0
                End If
                If chkHuurkoop.CheckState = CheckState.Checked Then
                    params(36).Value = 1
                Else
                    params(36).Value = 0
                End If

                If CDec(txtKilometerLesing.Text) = 0 Then
                    params(37).Value = 0
                Else
                    params(37).Value = CDec(txtKilometerLesing.Text)
                End If

                If txtMotorplanKm.Text = "" Then
                    params(38).Value = 0
                Else
                    params(38).Value = CInt(txtMotorplanKm.Text)
                End If

                If Me.chkVssRatingJN.CheckState Then
                    params(39).Value = "Ja"
                Else
                    params(39).Value = "Nee"
                End If

                If txtKmPerJaar.Text = "" Then
                    params(40).Value = 0
                Else
                    params(40).Value = CInt(txtKmPerJaar.Text)
                End If

                params(41).Value = txtGenomBestuurder1.Text
                params(42).Value = txtGenomBestuurder2.Text

                If txtGenomBestGebore1.Text = "" Then
                    params(43).Value = 0
                Else
                    params(43).Value = CInt(txtGenomBestGebore1.Text)
                End If

                If txtGenomBestGebore2.Text = "" Then
                    params(44).Value = 0
                Else
                    params(44).Value = CInt(txtGenomBestGebore2.Text)
                End If

                params(45).Value = txtGereeldeBestuurder1.Text
                params(46).Value = txtGereeldeBestuurder2.Text
                params(47).Value = txtGereeldeBestuurder3.Text
                params(48).Value = txtGereeldeBestuurder4.Text

                If txtGereeldeBestGebore1.Text = "" Then
                    params(49).Value = 0
                Else
                    params(49).Value = CInt(txtGereeldeBestGebore1.Text)
                End If

                If txtGereeldeBestGebore2.Text = "" Then
                    params(50).Value = 0
                Else
                    params(50).Value = CInt(txtGereeldeBestGebore2.Text)
                End If

                If txtGereeldeBestGebore3.Text = "" Then
                    params(51).Value = 0
                Else
                    params(51).Value = CInt(txtGereeldeBestGebore3.Text)
                End If

                If txtGereeldeBestGebore4.Text = "" Then
                    params(52).Value = 0
                Else
                    params(52).Value = CInt(txtGereeldeBestGebore4.Text)
                End If
                params(53).Value = txtKmLesingDatum.Text
                params(54).Value = txtMotorplanVervalDat.Text

                If txtPersentasieWaarde.Text = "" Then
                    params(55).Value = 0
                Else
                    params(55).Value = CInt(txtPersentasieWaarde.Text)
                End If

                If txtPremiePersentasie.Text = "" Then
                    params(55).Value = 0
                Else
                    params(56).Value = CInt(txtPremiePersentasie.Text)
                End If
                'Persentasie waarde op
                If Me.optInruil.Checked Then
                    params(57).Value = "Inruil"
                ElseIf Me.optKoop.Checked Then
                    params(57).Value = "Koop"
                ElseIf Me.optMark.Checked Then
                    params(57).Value = "Mark"
                ElseIf Me.optNuut.Checked Then
                    params(57).Value = "Nuut"
                End If

                params(58).Value = CInt(calcSecuritySelectedBitwise())
                params(59).Value = 0

                params(60).Value = txtKode.Text

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.InsertVoertuieDetails", params)
                conn.Close()
            End Using

            'Kobus 29/07/2013 voegby
            'Kobus 01/11/2013 voegby 'Not editing'
            If Not blnediting Or strCurrentVehicle = "NewVehicleExtras" Then

                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                    New SqlParameter("@Kode", SqlDbType.NVarChar), _
                                                    New SqlParameter("@N_PLAAT", SqlDbType.NVarChar)}

                    'Kobus 29/08/2013 Form1.POLISNO.Text met glbpolicynumber
                    params(0).Value = glbPolicyNumber
                    params(1).Value = txtKode.Text
                    params(2).Value = txtNPlaat.Text


                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuiepkVoertuie", params)

                    If reader.Read Then
                        intPkVoertuigEkstras = reader("pkVoertuie")
                        pkVoertuie = reader("pkVoertuie")
                        intpkVoertuie = pkVoertuie
                    End If
                    conn.Close()
                End Using
                'Kobus 29/07/2013 voegby
                'pkVoertuie = intPkVoertuigEkstras
                blnediting = True
                'Andriette 06/08/2013 verander die pkVoertuieekstras na die pk van die betrokke nuwe voetruig want dit word in die 
                ' Voertuie ekstras vorm gebruik om al die ekstras vir die voertuig op te roep
                'Kobus 03/09/2013 voegby
                If txtAnder.Text = True Then
                    ReadAVoertuig(txtJaar.Text.Substring(0, 2), txtJaar.Text.Substring(2, 2), txtKode.Text)
                    strDiverseBesk = txtBesk.Text
                    'logAlterations()
                    pkVoertuieEkstra = 0
                    blnInformationChanged = True
                Else
                    'Kobus 12/08/2013 voegby
                    If strCurrentVehicle = "NewVehicleExtras" Then
                        voertuie = FetchVoertuie(intpkVoertuie)
                        strDiverseBesk = txtBesk.Text
                        'logAlterations()
                        blnediting = True
                        'Kobus 07/03/2014 verander van pkVoertuieEkstra = 0
                        pkVoertuieEkstra = 0
                        blnInformationChanged = False
                    End If

                End If
            Else
                If pkVoertuie = 0 Then
                    'gaan voort
                Else
                    pkVoertuie = Form1.dgvPoldataVoertuie.SelectedRows(0).Cells(0).Value

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Sub UpdateVoertuieDetails()
        'Kobus 24/01/2014 voegby om dit slegs eenmalig te aktiveer
        'logAlterations()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - maak tipes reg om by db aan te pas
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@pkVoertuie", SqlDbType.Int), _
                                                New SqlParameter("@PremieEkstras", SqlDbType.Money), _
                                                New SqlParameter("@WaardeEkstras", SqlDbType.Money), _
                                                New SqlParameter("@TIPE", SqlDbType.NVarChar), _
                                                New SqlParameter("@N_PLAAT", SqlDbType.NVarChar), _
                                                New SqlParameter("@TIPE_DEK", SqlDbType.NVarChar), _
                                                New SqlParameter("@GEBRUIK", SqlDbType.NVarChar), _
                                                New SqlParameter("@CourtesyVehAmount", SqlDbType.Money), _
                                                New SqlParameter("@WAARDE", SqlDbType.Money), _
                                                New SqlParameter("@PREMIE", SqlDbType.Money), _
                                                New SqlParameter("@WaardeVoertuig", SqlDbType.Money), _
                                                New SqlParameter("@PremieVoertuig", SqlDbType.Money), _
                                                New SqlParameter("@JAAR", SqlDbType.NVarChar), _
                                                New SqlParameter("@ANDER", SqlDbType.Bit), _
                                                New SqlParameter("@motorstatus", SqlDbType.NVarChar), _
                                                New SqlParameter("@huurinstansie", SqlDbType.NVarChar), _
                                                New SqlParameter("@huurnommer", SqlDbType.NVarChar), _
                                                New SqlParameter("@EEU", SqlDbType.NVarChar), _
                                                New SqlParameter("@enjinnommer", SqlDbType.NVarChar), _
                                                New SqlParameter("@onderstelnommer", SqlDbType.NVarChar), _
                                                New SqlParameter("@kleur", SqlDbType.NVarChar), _
                                                New SqlParameter("@vssratingbesk", SqlDbType.NVarChar), _
                                                New SqlParameter("@waardeTipe", SqlDbType.Int), _
                                                New SqlParameter("@Adres", SqlDbType.NVarChar), _
                                                New SqlParameter("@Adres2", SqlDbType.NVarChar), _
                                                New SqlParameter("@AreaBeskrywing", SqlDbType.NVarChar), _
                                                New SqlParameter("@AreaFrekwensie", SqlDbType.NVarChar), _
                                                New SqlParameter("@Eienaar", SqlDbType.NVarChar), _
                                                New SqlParameter("@Poskode", SqlDbType.NVarChar), _
                                                New SqlParameter("@Stad", SqlDbType.NVarChar), _
                                                New SqlParameter("@Voorstad", SqlDbType.NVarChar), _
                                                New SqlParameter("@OornagBeskrywing", SqlDbType.NVarChar), _
                                                New SqlParameter("@Motorhuis", SqlDbType.TinyInt), _
                                                New SqlParameter("@ingevoer", SqlDbType.TinyInt), _
                                                New SqlParameter("@LaeProfielbande", SqlDbType.TinyInt), _
                                                New SqlParameter("@Motorplan", SqlDbType.TinyInt), _
                                                New SqlParameter("@Huurkoop", SqlDbType.Bit), _
                                                New SqlParameter("@kilometerlesing", SqlDbType.Float), _
                                                New SqlParameter("@MotorplanKm", SqlDbType.Int), _
                                                New SqlParameter("@vssratingjn", SqlDbType.NVarChar), _
                                                New SqlParameter("@KmPerJaar", SqlDbType.Int), _
                                                New SqlParameter("@GenomBestuurder1", SqlDbType.NVarChar), _
                                                New SqlParameter("@GenomBestuurder2", SqlDbType.NVarChar), _
                                                New SqlParameter("@GenomBestGebore1", SqlDbType.Int), _
                                                New SqlParameter("@GenomBestGebore2", SqlDbType.Int), _
                                                New SqlParameter("@GereeldeBestuurder1", SqlDbType.NVarChar), _
                                                New SqlParameter("@GereeldeBestuurder2", SqlDbType.NVarChar), _
                                                New SqlParameter("@GereeldeBestuurder3", SqlDbType.NVarChar), _
                                                New SqlParameter("@GereeldeBestuurder4", SqlDbType.NVarChar), _
                                                New SqlParameter("@GereeldeBestGebore1", SqlDbType.Int), _
                                                New SqlParameter("@GereeldeBestGebore2", SqlDbType.Int), _
                                                New SqlParameter("@GereeldeBestGebore3", SqlDbType.Int), _
                                                New SqlParameter("@GereeldeBestGebore4", SqlDbType.Int), _
                                                New SqlParameter("@KmLesingDatum", SqlDbType.NVarChar), _
                                                New SqlParameter("@MotorplanVervalDat", SqlDbType.NVarChar), _
                                                New SqlParameter("@PersentasieWaarde", SqlDbType.Int), _
                                                New SqlParameter("@PremiePersentasie", SqlDbType.Int), _
                                                New SqlParameter("@PersentasieOp", SqlDbType.NVarChar), _
                                                New SqlParameter("@SekuriteitBitValue", SqlDbType.Int), _
                                                New SqlParameter("@KODE", SqlDbType.NVarChar)}

                'Kobus 12/04/2013 add @KODE to make provision for change from Auto Guide to Non Auto Guide
                params(0).Value = glbPolicyNumber
                'Kobus 27/01/2014 verander van If strCurrentVehicle = "NewVehicleExtras" Then
                If strCurrentVehicle = "NewVehicleExtras" Or pkVoertuie <> 0 Then
                    params(1).Value = pkVoertuie
                Else
                    params(1).Value = Form1.dgvPoldataVoertuie.SelectedRows(0).Cells(0).Value
                End If
                'Kobus 15/08/2013 voeg if opsie by waar money en integer "" kan wees
                If txtPremieEkstras.Text = "" Then
                    txtPremieEkstras.Text = 0
                End If
                params(2).Value = txtPremieEkstras.Text
                If txtWaardeEkstras.Text = "" Then
                    txtWaardeEkstras.Text = 0
                End If
                params(3).Value = txtWaardeEkstras.Text
                params(4).Value = cmbTipe.SelectedIndex + 1
                params(5).Value = txtNPlaat.Text
                params(6).Value = cmbTipeDek.SelectedIndex + 1
                params(7).Value = cmbGebruik.SelectedIndex + 1
                If txtCourtesyVehAmount.Text = "" Then
                    txtCourtesyVehAmount.Text = 0
                End If
                params(8).Value = txtCourtesyVehAmount.Text
                If txtWaarde.Text = "" Then
                    txtWaarde.Text = 0
                End If
                params(9).Value = txtWaarde.Text
                If txtPremie.Text = "" Then
                    txtPremie.Text = 0
                End If
                params(10).Value = txtPremie.Text
                If txtWaardeVoertuig.Text = "" Then
                    txtWaardeVoertuig.Text = 0
                End If
                params(11).Value = txtWaardeVoertuig.Text
                If txtPremieVoor.Text = "" Then
                    txtPremieVoor.Text = 0
                End If
                params(12).Value = txtPremieVoor.Text
                params(13).Value = Mid(txtJaar.Text, 3)
                params(14).Value = txtAnder.Text
                params(15).Value = cmbMotorStatus.Text
                params(16).Value = cmbHuurInstansie.Text
                params(17).Value = txtHuurNommer.Text
                params(18).Value = Mid(txtJaar.Text, 1, 2)
                params(19).Value = txtEnjinNommer.Text
                params(20).Value = txtOnderstelNommer.Text
                params(21).Value = txtKleur.Text
                params(22).Value = txtVSSRatingBesk.Text
                params(23).Value = CInt(cmbWaardeTipe.SelectedIndex)
                params(24).Value = Trim(txtAdres.Text)
                params(25).Value = Trim(txtAdres2.Text)
                params(26).Value = Trim(cmbAreaBeskrywing.Text)

                If cmbAreaFrekwensie.SelectedIndex = -1 Then
                    params(27).Value = 0
                Else
                    params(27).Value = cmbAreaFrekwensie.Text
                End If

                params(28).Value = Trim(txtEienaar.Text)
                params(29).Value = Trim(txtPoskode.Text)
                params(30).Value = Trim(txtStad.Text)
                params(31).Value = txtVoorstad.Text

                If Me.chkMotorHuis.CheckState Then
                    params(32).Value = ""
                    params(33).Value = 1
                Else
                    params(32).Value = Me.txtOornagBeskrywing.Text
                    params(33).Value = 0
                End If

                params(34).Value = Val(CStr(chkIngevoer.CheckState))
                params(35).Value = Val(CStr(chkLaeProfielBande.CheckState))
                params(36).Value = Val(CStr(chkMotorplan.CheckState))
                params(37).Value = Val(CStr(chkHuurkoop.CheckState))

                If CStr(txtKilometerLesing.Text) = "" Then
                    params(38).Value = "0"
                Else
                    params(38).Value = txtKilometerLesing.Text
                End If
                'Kobus 06/08/2013 verwyder CInt
                'If txtMotorplanKm.Text = 0 Then
                If txtMotorplanKm.Text = "" Then

                    params(39).Value = "0"
                    '
                Else
                    params(39).Value = CInt(txtMotorplanKm.Text)
                End If

                If Me.chkVssRatingJN.CheckState Then
                    params(40).Value = "Ja"
                Else
                    params(40).Value = "Nee"
                End If
                'Kobus 06/08/2013 verander al die CInt om te toets vir 'n leë veld en dan 0 te gee
                params(41).Value = txtKmPerJaar.Text
                params(42).Value = txtGenomBestuurder1.Text
                params(43).Value = txtGenomBestuurder2.Text
                If txtGenomBestGebore1.Text = "" Then
                    params(44).Value = "0"
                Else
                    params(44).Value = CInt(txtGenomBestGebore1.Text)
                End If

                If txtGenomBestGebore2.Text = "" Then
                    params(45).Value = "0"
                Else
                    params(45).Value = CInt(txtGenomBestGebore2.Text)
                End If

                params(46).Value = txtGereeldeBestuurder1.Text
                params(47).Value = txtGereeldeBestuurder2.Text
                params(48).Value = txtGereeldeBestuurder3.Text
                params(49).Value = txtGereeldeBestuurder4.Text

                If txtGereeldeBestGebore1.Text = "" Then
                    params(50).Value = "0"
                Else
                    params(50).Value = CInt(txtGereeldeBestGebore1.Text)
                End If

                If txtGereeldeBestGebore2.Text = "" Then
                    params(51).Value = "0"
                Else
                    params(51).Value = CInt(txtGereeldeBestGebore2.Text)
                End If

                If txtGereeldeBestGebore3.Text = "" Then
                    params(52).Value = "0"
                Else
                    params(52).Value = CInt(txtGereeldeBestGebore3.Text)
                End If

                If txtGereeldeBestGebore4.Text = "" Then
                    params(53).Value = "0"
                Else
                    params(53).Value = CInt(txtGereeldeBestGebore4.Text)
                End If

                params(54).Value = txtKmLesingDatum.Text
                params(55).Value = txtMotorplanVervalDat.Text

                If txtPersentasieWaarde.Text = "" Then
                    params(56).Value = "0"
                Else
                    params(56).Value = CInt(txtPersentasieWaarde.Text)
                End If

                If txtPremiePersentasie.Text = "" Then
                    params(57).Value = "0"
                Else
                    params(57).Value = CInt(txtPremiePersentasie.Text)
                End If

                'Persentasie waarde op
                If Me.optInruil.Checked Then
                    params(58).Value = "Inruil"
                ElseIf Me.optKoop.Checked Then
                    params(58).Value = "Koop"
                ElseIf Me.optMark.Checked Then
                    params(58).Value = "Mark"
                ElseIf Me.optNuut.Checked Then
                    params(58).Value = "Nuut"
                End If

                params(59).Value = CInt(calcSecuritySelectedBitwise())
                params(60).Value = txtKode.Text

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateVoertuieDetails", params)
                conn.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        If strCurrentVehicle = "NewVehicleExtras" Then
            'Kobus 03/09/2013 voegby
            If txtAnder.Text = True Then
                strDiverseBesk = txtBesk.Text
                'logAlterations()
                'editing = True
                blnInformationChanged = False
            Else
                'voertuie = FetchVoertuie(pkVoertuie)
                strDiverseBesk = txtBesk.Text
                'logAlterations()
                'editing = True
                blnInformationChanged = False
            End If
        Else
            blnInformationChanged = False
            'logAlterations()
        End If
    End Sub

    Public Function SaveInformation() As Boolean
        Try
            Me.Cursor = System.Windows.Forms.Cursors.Default
            validateForm()
            If blnValidationOk = False Then
                Exit Function
            End If
            If Me.txtAnder.Text = True Then
                If pkVoertuie = 0 Then 'Adding new vehicle
                    V_Kode()
                    Ander_K = Format(Val(Ander_K) + 1, "00000000")
                    add_ander_k((Val(Ander_K)))
                    'Kobus Visser - 07/02/2013 - verAnder SaveMotor na SaveA_VOERTUIG
                    SaveA_VOERTUIG(Ander_K, "Add")
                    'Kobus Visser - 07/02/2013 - populate Kode field
                    txtKode.Text = Ander_K
                Else 'Editing existing vehicle
                    'Kobus 07/05/2013 change If (CBool(Me.txtAnder.Text) And Not blnOrigAnder) Then
                    If (CBool(Me.txtAnder.Text) = blnOrigAnder) Then
                        '   Kobus 07/05/2013 change Ander_k from Format(Val(Ander_K) + 1, "00000000")
                        'V_Kode()
                        Ander_K = Format(Val(txtKode.Text), "00000000")
                        'Kobus 07/05/2013 comment out
                        'add_ander_k((Val(Ander_K)))
                        'Kobus Visser - 07/02/2013 - verander SaveMotor na SaveA_VOERTUIG
                        SaveA_VOERTUIG(Ander_K, "Edit")
                        'Kobus Visser - 07/02/2013 - populate Kode field
                        'txtKode.Text = Ander_K
                    Else
                        'Kobus Visser - 07/02/2013 - verAnder SaveMotor na SaveA_VOERTUIG
                        V_Kode()
                        Ander_K = Format(Val(Ander_K) + 1, "00000000")
                        txtKode.Text = Ander_K
                        add_ander_k((Val(Ander_K)))
                        SaveA_VOERTUIG(Ander_K, "Add")
                    End If
                End If

                'If strCurrentVehicle = "NewVehicleExtras" Then
                '    'Kobus 10/04/2014 voegby
                '    calcPremium()
                '    calcTotValue()
                '    logAlterations()
                '    SaveVoertuieDetails()
                '    HerBereken_Premie()
                '    BFUpdateItemsSubTotals(glbPolicyNumber)
                '    InformationChanged = False
                '    Form1.populateGrid1()
                '    PopulateGridEkstras()
                '    If addnew = True Then
                '        InformationChanged = True
                '        Exit Function
                '    Else
                '        Me.Close()
                '        Exit Function
                '    End If
                'End If
            End If
            If pkVoertuie = 0 And blnValidationOk = True Then
                calcPremium()
                calcTotValue()
                logAlterations()
                SaveVoertuieDetails()
                BFUpdateItemsSubTotals(glbPolicyNumber)
                HerBereken_Premie()
                blnInformationChanged = False
                Form1.populate_dgvPoldataVoertuie()
                PopulateGridEkstras()
                If blnAddnew = True Then
                    blnInformationChanged = True
                    Exit Function
                Else
                    Me.Close()
                    Exit Function
                End If
                'Kobus 12/05/2014 voegby
                Me.Close()
                Exit Function
            End If
            'Kobus 12/05/2014 voegby
            If pkVoertuie = 0 And blnValidationOk = False Then
                Exit Function

            End If
            If pkVoertuie <> 0 And blnValidationOk = True Then
                calcPremium()
                calcTotValue()
                'Kobus 24/04/2014 comment out
                'logAlterations()
                'Kobus 11/04/2014 voegby
                If blnRestorTypeCover = False And strRemove <> "" And blnCancel = True Then
                    voertuie = FetchVoertuie(pkVoertuie)
                    blnInformationChanged = True
                    Me.cmbTipeDek.SelectedIndex = intTipeDek
                    Me.txtWaardeVoertuig.Text = intWaardeVoertuig
                    Me.txtPremieVoor.Text = decPremieVoertuig
                    'Kobus 24/04/2014 voegby
                    Me.txtPremie.Text = decPremieVoertuig
                    'Kobus 24/04/2014 comment in
                    logAlterations()
                    'Kobus 24/04/2014 voegby
                Else
                    'Kobus 13/05/2014 voegby
                    voertuie = FetchVoertuie(pkVoertuie)
                    logAlterations()
                End If

                UpdateVoertuieDetails()
                blnInformationChanged = False
                BFUpdateItemsSubTotals(glbPolicyNumber)
                HerBereken_Premie()
                Me.Close()
            End If
            If pkVoertuie = 0 Or pkVoertuie <> 0 And blnValidationOk = False Then
                Me.SSTab1.SelectedIndex = 2
                Exit Function
            End If

            Form1.populate_dgvPoldataVoertuie()

            'Kobus 04/11/2013
            If blnFactoryStanderd = True Then
                updateStdItems(pkVoertuie)
            End If
            Return False

            'If Not validateForm() Then

            '    blnNoExit = True
            '    'Kobus 20/03/2014 voegby
            '    Exit Function
            'End If
            'Try
            '    'Kobus 08/08/2013 voegby

            '    If InformationChanged = False Then
            '        'Kobus 20/03/2014 comment out
            '        'If blnNoExit Then
            '        '    Exit Function
            '        'End If
            '        Me.Close()
            '        Exit Function
            '    End If
            '    'Dim blnDoPwd As Boolean

            '    ''Kobus 19/04/2013 om indeksprobleem by nuwe voertuie te voorkom wanneer rekord gestoor word
            '    'If strCurrentVehicle = "NewVehicleExtras" Then
            '    'End If

            '    'Kobus 01/11/2013 comment out alles oor blnDoPwd - het private sub Above350() geskep
            '    'Kobus 31/01/2014 comment out
            '    If Not validateForm() Then
            '        'Kobus 10/12/2013 voegby
            '        If txtNPlaat.Text = "" Then
            '            Exit Function
            '        End If
            '        SaveInformation = True
            '        'Kobus 12/08/2013 voeg condisie by
            '        If strCurrentVehicle = "NewVehicleExtras" Then
            '            Me.Close()
            '        Else
            '            Exit Function
            '        End If
            '    End If
            '    'Else
            '    '    blnDoPwd = False
            '    '    If pkVoertuie = 0 Then
            '    '        blnDoPwd = True
            '    '    Else
            '    '        If Val(txtWaardeEkstras.Text) <> voertuie.WaardeEkstras Or _
            '    '        Val(txtWaardeVoertuig.Text) <> voertuie.WaardeEkstras And voertuie.WAARDE < 350000 Then
            '    '            blnDoPwd = True
            '    '        Else
            '    '            blnDoPwd = False
            '    '        End If
            '    '    End If

            '    'If blnDoPwd Then
            '    'Kobus 30/10/2013 verander If CDbl(Me.txtWaarde.Text) >= 350000 Then na - dit moenie ekstras inberekening bring nie.
            '    'If CDbl(Me.txtWaardeVoertuig.Text) >= 350000 Then
            '    '    'Kobus changed message from: "Vehicle Values ​​of R350, 000.00 or more must be referred to the branch manager for permission to download." & Chr(13) & "To continue this?"
            '    '    If MsgBox("To add a vehicle ​​of R350 000 or more, it must be authorized by the branch manager." & Chr(13) & "Would you like to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            '    '        'Kobus change message from: "Please label the specified vehicle well worth the password fields."
            '    '        frmPassword.lblMessage.Text = "Authorise the specified vehicle value."
            '    '        frmPassword.ShowDialog()
            '    '        If pwdEntered = "350good" Then

            '    '        ElseIf pwdEntered <> "Cancelled" Then
            '    '            MsgBox("Password is not correct.", MsgBoxStyle.Information)
            '    '            SaveInformation = False
            '    '            Exit Function
            '    '            'Kobus 01/11/2013 comment out
            '    '            '    Else
            '    '            '        SaveInformation = False
            '    '            '        Exit Function
            '    '            '    End If
            '    '            'Else
            '    '            '    SaveInformation = False
            '    '            '    Exit Function
            '    '        End If
            '    '    End If
            '    'End If

            '    Me.Cursor = System.Windows.Forms.Cursors.Default
            '    'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor


            '    'if ander = true then add to a_voertuig
            '    If Me.txtAnder.Text = True Then
            '        If pkVoertuie = 0 Then 'Adding new vehicle
            '            V_Kode()
            '            Ander_K = Format(Val(Ander_K) + 1, "00000000")
            '            add_ander_k((Val(Ander_K)))
            '            'Kobus Visser - 07/02/2013 - verAnder SaveMotor na SaveA_VOERTUIG
            '            SaveA_VOERTUIG(Ander_K, "Add")
            '            'Kobus Visser - 07/02/2013 - populate Kode field
            '            txtKode.Text = Ander_K
            '        Else 'Editing existing vehicle
            '            'Kobus 07/05/2013 change If (CBool(Me.txtAnder.Text) And Not blnOrigAnder) Then
            '            If (CBool(Me.txtAnder.Text) = blnOrigAnder) Then
            '                '   Kobus 07/05/2013 change Ander_k from Format(Val(Ander_K) + 1, "00000000")
            '                'V_Kode()
            '                Ander_K = Format(Val(txtKode.Text), "00000000")
            '                'Kobus 07/05/2013 comment out
            '                'add_ander_k((Val(Ander_K)))
            '                'Kobus Visser - 07/02/2013 - verander SaveMotor na SaveA_VOERTUIG
            '                SaveA_VOERTUIG(Ander_K, "Edit")
            '                'Kobus Visser - 07/02/2013 - populate Kode field
            '                'txtKode.Text = Ander_K
            '            Else
            '                'Kobus Visser - 07/02/2013 - verAnder SaveMotor na SaveA_VOERTUIG
            '                V_Kode()
            '                Ander_K = Format(Val(Ander_K) + 1, "00000000")
            '                txtKode.Text = Ander_K
            '                add_ander_k((Val(Ander_K)))
            '                SaveA_VOERTUIG(Ander_K, "Add")
            '            End If
            '        End If
            '    End If
            '    'End If 'K

            '    'Kobus Visser - 07/02/2013 - Skuif Save Voertuig Details tot na SaveA_VOERTUIG
            '    'pkVoertuie (global variable) contains the primary key of the selected vehicle selected on form1.
            '    'When pkVoertuie = 0, a new vehicle will be added.
            '    If Not editing Then 'Add new
            '        'logAlterations()
            '        SaveVoertuieDetails()
            '    Else 'Update
            '        'Kobus 07/08/2013 voeg by
            '        If strCurrentVehicle = "NewVehicleExtras" Then
            '            'pkVoertuie = intPkVoertuigEkstras
            '            'Kobus 12/08/2013 voegby
            '            calcPremium()
            '            calcTotValue()

            '            'logAlterations()
            '            'SaveInformation = True
            '            'Kobus 07/03/2014 verander van UpdateVoertuieDetails()
            '            SaveVoertuieDetails()
            '        Else
            '            'Kobus 08/05/2013 add: pkVoertuie = Form1.Grid1.SelectedRows(0).Cells(0).Value (Change from Auto Guide to Non Auto Guide
            '            'pkVoertuie = Form1.Grid1.SelectedRows(0).Cells(0).Value
            '            'Kobus 24/01/2014 voegby
            '            calcPremium()
            '            calcTotValue()

            '            'Kobus 24/01/2014 voegby
            '            'logAlterations()
            '            UpdateVoertuieDetails()
            '        End If
            '    End If

            '    'Kobus 01/11/2013 skuif na laaste
            '    'updateStdItems(pkVoertuie)

            '    'Log alterations
            '    'kobus 13/08/2013 comment out word by save vehile details en update gedoen
            '    'logAlterations()

            '    'Update the premium
            '    'HerBereken_Premie()
            '    'Andriette 24/10/2013 comment out
            '    'doen_subtotaal()
            '    'Repopulate grid on form1
            '    Form1.populateGrid1()

            '    ' Set new pk and reload form
            '    'Kobus 29/07/2013 comment out
            '    'pkVoertuie = 0

            '    'Kobus 07/08/2013 voeg condisie by
            '    If strCurrentVehicle = "NewVehicleExtras" Then
            '        If InformationChanged Then
            '            UpdateVoertuieDetails()
            '        Else
            '            'Exit Function
            '            'Else
            '            '    If validateForm() = False Then
            '            '        Exit Function
            '            'Else

            '            '        SaveInformation = True
            '            '        InformationChanged = False
            '        End If
            '    End If
            '    'Kobus 04/11/2013
            '    If blnFactoryStanderd = True Then
            '        updateStdItems(pkVoertuie)
            '    End If
            '    'If blnFactoryStanderd = True Then
            '    '    If blnDeleteFactorySingle = True Then
            '    '        pkVoertuieStanadaard()
            '    '        DeleteFromVoertuieFabrieks("DeleteByfkVoertuieFabrieks")
            '    '    ElseIf blnDeleteFactoryMulti = True Then
            '    '        DeleteFromVoertuieFabrieks("DeleteByfkVoertuie")
            '    '    ElseIf blnDeleteFactoryMulti = False And blnDeleteFactorySingle = False Then
            '    '        updateStdItems(pkVoertuie)
            '    '    End If
            '    'End If
            Me.Cursor = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function

    'Kobus Visser - 07/02/2013 - Verander 'Sub SaveMOTOR' na'Sub SaveA_VOERTUIG' en die betrokke gedeeltes waar dit gebruik word.
    Sub SaveA_VOERTUIG(ByVal MotorKode As String, ByVal type As String)

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@KODE", SqlDbType.NVarChar), _
                                               New SqlParameter("@JAAR", SqlDbType.NVarChar), _
                                               New SqlParameter("@MAAK", SqlDbType.NVarChar), _
                                               New SqlParameter("@BESK", SqlDbType.NVarChar), _
                                               New SqlParameter("@TIPE", SqlDbType.NVarChar), _
                                               New SqlParameter("@EEU", SqlDbType.NVarChar), _
                                               New SqlParameter("@Type", SqlDbType.NVarChar)}

                'Kobus 11/04/2013 add if  - 06/05/2013 comment out
                'If MotorKode <> "" Then
                '    param(0).Value = MotorKode
                'Else
                '    param(0).Value = txtKode.Text
                'End If
                MotorKode = Ander_K
                param(0).Value = MotorKode
                param(1).Value = Mid(txtJaar.Text, 3)
                param(2).Value = txtMaak.Text
                param(3).Value = txtBesk.Text
                param(4).Value = cmbTipe.SelectedIndex + 1
                param(5).Value = Mid(txtJaar.Text, 1, 2)
                param(6).Value = type

                'Kobus - 07/02/2013 - verander stored procedure van poldata5.UpdateMOTORS na poldata5.UpdateA_VOERTUIG
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateA_VOERTUIG", param)
                conn.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
            ClearVoertuig()
        End Try

    End Sub

    'Populate combo Ditto with adresses of properties and postal adress of policy

    Public Sub PopulateCmbDitto()

        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                          New SqlParameter("@Cancelled", SqlDbType.Bit)}
            'Kobus 29/08/2013 Form1.POLISNO.Text met glbpolicynumber
            param(0).Value = glbPolicyNumber
            param(1).Value = False

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchHuisToPopulateCombo", param)

            'Blank item
            cmbDitto.Items.Clear()
            Do While reader.Read
                Me.cmbDitto.Items.Add(reader("ADRES_H1") & "|" & reader("Adres4") & "|" & reader("voorstad") & "|" & reader("dorp") & "|" & reader("poskode"))
            Loop
            conn.Close()
        End Using
    End Sub
    'Calculate the value to insure, according to value selected and percentage
    Public Sub calcValue()
        If Me.cmbWaardeTipe.SelectedIndex = 3 Then
            If Me.optMark.Checked Then
                'Kobus 05/08/2013 verabder CInt na CDec
                Me.txtWaardeVoertuig.Text = CDec(System.Math.Round(Val(Me.txtPersentasieWaarde.Text) / 100 * Val(Me.txtValueMarket.Text)))
                Exit Sub
            End If

            If Me.optNuut.Checked Then
                'Kobus 31/07/2013 verander van Me.txtWaardeVoertuig.Text = CStr(System.Math.Round(Val(Me.txtPersentasieWaarde.Text) / 100 * Val(Me.txtNuut.Text)))
                'Kobus 05/08/2013 verabder CInt na CDec
                Me.txtWaardeVoertuig.Text = CDec(System.Math.Round(Val(Me.txtPersentasieWaarde.Text) / 100 * Val(Me.txtNuut.Text)))
                Exit Sub
            End If

            If Me.optKoop.Checked Then
                'Kobus 31/07/2013 verander van CStr....
                'Kobus 05/08/2013 verabder CInt na CDec
                Me.txtWaardeVoertuig.Text = CDec(System.Math.Round(Val(Me.txtPersentasieWaarde.Text) / 100 * Val(Me.txtKoop.Text)))
                Exit Sub
            End If

            If Me.optInruil.Checked Then
                'Kobus 31/07/2013 verander van CStr....
                'Kobus 05/08/2013 verabder CInt na CDec
                Me.txtWaardeVoertuig.Text = CDec(System.Math.Round(Val(Me.txtPersentasieWaarde.Text) / 100 * Val(Me.txtInruil.Text)))
                Exit Sub
            End If
        End If
    End Sub
    'Calculate the premium according to the % discount
    Public Sub calcPremium()
        'Kobus 4/07/13 changed from 
        'Me.txtPremie.Text = System.Math.Round((Val(Me.txtPremieVoor.Text) + Val(Me.txtPremieEkstras.Text)) * (Val(Me.txtPremiePersentasie.Text) / 100), 2)
        Me.txtPremie.Text = Format(System.Math.Round((Val(Me.txtPremieVoor.Text) + Val(Me.txtPremieEkstras.Text)) * (Val(Me.txtPremiePersentasie.Text) / 100), 2), "######0.00")
        If IsDBNull(Persoonl.eispers) Then
            Me.txtPremieNaKorting.Text = Format(System.Math.Round(Val(Me.txtPremie.Text), 2), "######0.00")
        Else
            Me.txtPremieNaKorting.Text = Format(System.Math.Round(Val(Me.txtPremie.Text) * Val(Persoonl.eispers), 2), "######0.00")
        End If
    End Sub

    Private Sub txtWaardeVoertuig_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWaardeVoertuig.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar)) Then
                'do nothing
            Else
                e.Handled = True
                MsgBox("Value must be numeric", _
                       MsgBoxStyle.Information, "Verify")
                txtKilometerLesing.Focus()
            End If
        End If
    End Sub
    'UPGRADE_WARNING: Event txtWaardeVoertuig.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub txtWaardeVoertuig_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtWaardeVoertuig.TextChanged
        calcTotValue()
        'Kobus 22/04/2013 add
        blnInformationChanged = True
    End Sub
    'Calculate the total value of the vehicle (vehicle + extras)
    Public Sub calcTotValue()
        'Kobus 06/06/2013 change  FormatNumber((Me.txtWaardeEkstras.Text + Me.txtWaardeVoertuig.Text), 0) -  07/06/2013 change to no decimal
        'Kobus 10/7/2013 verander van Me.txtWaarde.Text = CStr(System.Math.Round(Val(Me.txtWaardeEkstras.Text) + Val(Me.txtWaardeVoertuig.Text), 0))
        'Me.txtWaarde.Text = System.Math.Round(Val(Me.txtWaardeEkstras.Text) + Val(Me.txtWaardeVoertuig.Text), 0)
        'Kobus 31/07/2013 verander van Me.txtWaarde.Text = Val(Me.txtWaardeEkstras.Text) + Val(Me.txtWaardeVoertuig.Text)
        Me.txtWaarde.Text = CDec(Val(Me.txtWaardeEkstras.Text)) + CDec(Val(Me.txtWaardeVoertuig.Text))

    End Sub

    Private Sub txtWaardeVoertuig_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtWaardeVoertuig.Enter
        'Kobus 07/11/2013 voegby
        Dim strWardeTipe As String
        strWardeTipe = Me.cmbWaardeTipe.Text
        If Trim(strWardeTipe) = "" Then 'Or txtWaardeVoertuig.Text = 0 And Me.cmbWaardeTipe.SelectedIndex = 3 Then
            Me.txtWaardeVoertuig.Text = 0
            MsgBox("A value type must be selected first.", MsgBoxStyle.Information)
        End If
        Me.txtWaardeVoertuig.SelectionStart = 0
        Me.txtWaardeVoertuig.SelectionLength = Len(txtWaarde.Text)
        'Kobus 07/08/2013 voegby
        'Me.txtWaardeVoertuig.SelectAll()
    End Sub

    Public Function pwdInputBox() As String
        pwdInputBox = InputBox("Only authorized users may select this option...." & Chr(13) & "Please enter the password.", "Poldata sekuriteit")
    End Function

    Public Sub populateCmbWaardeTipe(ByRef diverseVoertuig As Boolean)
        'Value description
        cmbWaardeTipe.Items.Clear()
        If diverseVoertuig Then
            'Kobus 04/12/2013 verander terug na taal van polis - 5.129
            'Kobus 16/08/2013 comment out
            If Persoonl.TAAL = 0 Then
                cmbWaardeTipe.Items.Add("Markwaarde")
                cmbWaardeTipe.Items.Add("Verkoopwaarde")
                cmbWaardeTipe.Items.Add("Ooreengekomewaarde")
            Else
                cmbWaardeTipe.Items.Add("Market value")
                cmbWaardeTipe.Items.Add("Resell value")
                cmbWaardeTipe.Items.Add("Value agreed upon")
            End If
        Else
            If Persoonl.TAAL = 0 Then
                cmbWaardeTipe.Items.Add("Markwaarde")
                cmbWaardeTipe.Items.Add("Verkoopwaarde")
                cmbWaardeTipe.Items.Add("Ooreengekomewaarde")
                cmbWaardeTipe.Items.Add("Persentasie van waarde")
            Else
                cmbWaardeTipe.Items.Add("Market value")
                cmbWaardeTipe.Items.Add("Resell value")
                cmbWaardeTipe.Items.Add("Value agreed upon")
                cmbWaardeTipe.Items.Add("Percentage of value")
            End If
        End If
    End Sub
    'Set captions of the security checkboxes
    Public Sub setSecurityItemsCaption()
        'rs = dbPoldata.OpenRecordset("SELECT * FROM sekuriteit WHERE tipe = 'Voertuig' ORDER BY [bit]")
        'If Not (rs.EOF And rs.BOF) Then
        '    Do While Not rs.EOF
        '        chkSekuriteit(rs.Fields("bit")).Text = rs.Fields("BeskrywingAfrikaans").Value
        '        If rs.Fields("beskrywingAfrikaans").Value = "n.v.t." Then
        '            chkSekuriteit(rs.Fields("bit")).Enabled = False
        '        End If
        '        rs.MoveNext()
        '    Loop
        'End If

        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim param As New SqlParameter("@Type", SqlDbType.NVarChar)
            param.Value = "Voertuig"

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchSekuriteitbyType", param)

            If Not reader.Read Then

                Do While Not reader.Read
                    chkSekuriteit(reader("bit")).Text = reader("BeskrywingAfrikaans").Value
                    If reader("beskrywingAfrikaans") = "n.v.t." Then
                        chkSekuriteit(reader("bit")).Enabled = False
                    End If
                Loop
            End If
            conn.Close()
        End Using
    End Sub
    'Calculate the bitwise number of the SECURITY options selected
    Public Function calcSecuritySelectedBitwise() As Integer
        calcSecuritySelectedBitwise = 0
        intTemp = 0
        For Me.k = 0 To chkSekuriteit.UBound
            If chkSekuriteit(k).CheckState Then
                intTemp = intTemp + (2 ^ k) 'to calculate bitwise number 2 ^ position of bit
            End If
        Next

        calcSecuritySelectedBitwise = intTemp
    End Function
    'Set SECURITY checkboxes according to bitwise number
    Public Sub setSecuritySelected(ByRef bitwise As Integer)
        If bitwise <> 0 Then
            For Me.k = 0 To chkSekuriteit.UBound
                If bitwise And (2 ^ k) Then
                    chkSekuriteit(k).CheckState = System.Windows.Forms.CheckState.Checked
                End If
            Next
        End If
    End Sub
    'Private Sub populateLstStdItmsAvailable()

    '    Dim type As String
    '    Dim language As String
    '    Try
    '        If Persoonl.TAAL = 0 Then
    '            language = "BeskrywingAfrikaans"
    '            type = "BeskrywingAfrikaans"
    '        Else
    '            language = "BeskrywingEngels"
    '            type = "BeskrywingEngels"
    '        End If

    '        Dim list As List(Of VoertuigDropdownEntity) = New List(Of VoertuigDropdownEntity)
    '        Using conn As SqlConnection = SqlHelper.GetConnection

    '            Dim param() As SqlParameter = {New SqlParameter("@type", SqlDbType.NVarChar), _
    '                                         New SqlParameter("@VertoonGespesifiseerd", SqlDbType.Int)}

    '            param(0).Value = type
    '            param(1).Value = 1

    '            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuieStandard", param)

    '            Do While reader.Read
    '                Dim item As VoertuigDropdownEntity = New VoertuigDropdownEntity()
    '                item.Descr = reader("Descr")
    '                item.PK = reader("PK")
    '                list.Add(item)
    '            Loop
    '        End Using
    '        lstStdItmsAvailable.ValueMember = "PK"
    '        lstStdItmsAvailable.DisplayMember = "Descr"
    '        lstStdItmsAvailable.DataSource = list
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '    End Try
    'End Sub
    'Private Sub populateLstStdItmsSelected()

    '    Dim type As String
    '    Dim language As String
    '    Try
    '        If Persoonl.TAAL = 0 Then
    '            language = "BeskrywingAfrikaans"
    '            type = "BeskrywingAfrikaans"
    '        Else
    '            language = "BeskrywingEngels"
    '            type = "BeskrywingEngels"
    '        End If

    '        Dim list As List(Of VoertuigDropdownEntity) = New List(Of VoertuigDropdownEntity)
    '        Using conn As SqlConnection = SqlHelper.GetConnection

    '            'Dim param() As SqlParameter = {New SqlParameter("@type", SqlDbType.NVarChar), _

    '            Dim param As New SqlParameter("@fkVoertuie", SqlDbType.Int)
    '            If editing Then
    '                param.Value = Form1.Grid1.SelectedRows(0).Cells(0).Value
    '            Else
    '                param.Value = DBNull.Value
    '            End If

    '            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuieStandaardForItemSelected", param)

    '            Do While reader.Read
    '                Dim item As VoertuigDropdownEntity = New VoertuigDropdownEntity()
    '                item.Descr = reader("Descr")
    '                item.PK = reader("PK")
    '                list.Add(item)
    '            Loop
    '        End Using
    '        lstStdItmsSelected.ValueMember = "pk"
    '        lstStdItmsSelected.DisplayMember = "Descr"
    '        lstStdItmsSelected.DataSource = list
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '    End Try
    'End Sub
    '* Purpose  : Populate listbox lstStdItmsAvailable with all items available for selection
    'Public Sub populateLstStdItmsAvailable()
    '    Dim list As List(Of VoertuigDropdownEntity) = New List(Of VoertuigDropdownEntity)
    '    Using conn As SqlConnection = SqlHelper.GetConnection

    '        Dim param As New SqlParameter("@fkVoertuie", SqlDbType.Int)
    '        If editing Then
    '            param.Value = Form1.Grid1.SelectedRows(0).Cells(0).Value
    '        Else
    '            param.Value = DBNull.Value
    '        End If

    '        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuieStandaard", param)
    '        lstStdItmsAvailable.Items.Clear()

    '        'Kobus Visser - 11/02/2013 - pkKode moet nie wys langs Beskrywing - NB Waanneer ek pkVoertuieStandaard hier uithaal werk Add
    '        'en Edit nie reg nie
    '        Dim C As Color
    '        C = Color.Blue
    '        Do While reader.Read
    '            If Persoonl.TAAL = 0 Then
    '                lstStdItmsAvailable.Items.Add(reader("beskrywingAfrikaans") & "  " & reader("pkVoertuieStandaard"))
    '                'pkVoertuieStanadaard()
    '            Else
    '                lstStdItmsAvailable.Items.Add(reader("beskrywingEngels") & " " & reader("pkVoertuieStandaard"))
    '            End If
    '        Loop
    '    End Using

    'End Sub

    'Andriette 05/11
    Public Sub populateLstStdItmsAvailable()
        Dim lstStandardItems As List(Of ComboBoxEntity) = New List(Of ComboBoxEntity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim param As New SqlParameter("@fkVoertuie", SqlDbType.Int)
                If blnediting Then
                    param.Value = Form1.dgvPoldataVoertuie.SelectedRows(0).Cells(0).Value
                Else
                    param.Value = DBNull.Value
                End If

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuieStandaard", param)

                'Kobus Visser - 11/02/2013 - pkKode moet nie wys langs Beskrywing - NB Waanneer ek pkVoertuieStandaard hier uithaal werk Add
                'en Edit nie reg nie

                Dim C As Color
                C = Color.Blue
                Do While reader.Read
                    'Andriette 05/11
                    Dim Item As ComboBoxEntity = New ComboBoxEntity()
                    Item.ComboBoxID = reader("pkVoertuieStandaard")
                    If Persoonl.TAAL = 0 Then
                        Item.ComboBoxName = reader("beskrywingAfrikaans")
                        ' lstStdItmsAvailable.Items.Add(reader("beskrywingAfrikaans") & "  " & reader("pkVoertuieStandaard"))
                        'pkVoertuieStanadaard()
                    Else
                        Item.ComboBoxName = reader("beskrywingEngels")
                        '  lstStdItmsAvailable.Items.Add(reader("beskrywingEngels") & " " & reader("pkVoertuieStandaard"))
                    End If
                    lstStandardItems.Add(Item)
                Loop
                conn.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        'Andriette 05/11

        lstStdItmsAvailable.DataSource = lstStandardItems
        lstStdItmsAvailable.DisplayMember = "ComboBoxName"
        lstStdItmsAvailable.ValueMember = "ComboBoxID"
    End Sub
    '* Purpose  : Populate listbox lstStdItmsSelected with the items selected
    Public Sub populateLstStdItmsSelected()
        Dim lstSelectedItems As List(Of ComboBoxEntity) = New List(Of ComboBoxEntity)
        Try


            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim param As New SqlParameter("@fkVoertuie", SqlDbType.Int)
                If blnediting Then
                    param.Value = Form1.dgvPoldataVoertuie.SelectedRows(0).Cells(0).Value
                Else
                    param.Value = DBNull.Value
                End If

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuieStandaardForItemSelected", param)
                'lstStdItmsSelected.Items.Clear()
                Do While reader.Read
                    'Andriette 05/11
                    Dim Item As ComboBoxEntity = New ComboBoxEntity()
                    'Kobus Visser - 11/02/2013 - pkKode moet nie wys langs Beskrywing - NB Waanneer ek pkVoertuieStandaard hier uithaal werk Add
                    'en Edit nie reg nie
                    Item.ComboBoxID = reader("pkVoertuieStandaard")
                    If Persoonl.TAAL = 0 Then
                        'lstStdItmsSelected.Items.Add(reader("beskrywingAfrikaans") & " " & reader("pkVoertuieStandaard"))
                        'Andriette 05/11
                        Item.ComboBoxName = reader("beskrywingAfrikaans")
                    Else
                        ' lstStdItmsSelected.Items.Add(reader("beskrywingEngels") & " " & reader("pkVoertuieStandaard"))
                        'Andriette 05/11
                        Item.ComboBoxName = reader("beskrywingEngels")
                    End If
                    lstSelectedItems.Add(Item)
                Loop
                conn.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        'Andriette 05/11
        lstStdItmsSelected.DataSource = lstSelectedItems
        lstStdItmsSelected.DisplayMember = "ComboBoxName"
        lstStdItmsSelected.ValueMember = "ComboBoxID"
    End Sub

    'Lyk of hierdie Fuksie nie êrens gebruik word nie - pkVoertuieStandaard is ook verkeerd gespel
    Public Function pkVoertuieStanadaard() As Integer

        Using conn As SqlConnection = SqlHelper.GetConnection

            Dim param As New SqlParameter("@fkVoertuie", SqlDbType.Int)
            'Kobus 04/11/2013 verander van Form1.Grid1.SelectedRows(0).Cells(0).Value
            param.Value = pkVoertuie

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuieStandaardForItemSelected", param)

            Do While reader.Read
                k = reader("pkVoertuieStandaard")
                'Kobus 04/11/2013 voegby
                intfkVoertuieStandaard = k
            Loop
            conn.Close()
        End Using
    End Function

    '* Purpose  : Update the selected factory fitted items
    Public Sub updateStdItems(ByRef fkVoertuie As Integer)
        'Kobus 05/11/2013 comment alles uit
        If blnDeleteFactoryMulti = False Then
            DeleteFromVoertuieFabrieks("DeleteByfkVoertuieFabrieks")
        Else
            DeleteFromVoertuieFabrieks("DeleteByfkVoertuie")
        End If

        InsertIntoVoertuieFabrieks()
        'Try

        '    'Dim lngFkVoertuieStandaard As Integer
        '    Dim strItems As String
        '    'Dim strpkEkstras As String
        '    'Dim STRLEN As Integer

        '    strItems = ""

        '    Using conn As SqlConnection = SqlHelper.GetConnection
        '        For Me.k = 0 To Me.lstStdItmsSelected.Items.Count - 1
        '            Dim param() As SqlParameter = {New SqlParameter("@fkVoertuie", SqlDbType.Int), _
        '                                           New SqlParameter("@fkVoertuieStandaard", SqlDbType.Int)}


        '            If editing Then
        '                'Kobus 04/11/2013 verander van Value = Form1.Grid1.SelectedRows(0).Cells(0).Value
        '                param(0).Value = pkVoertuie
        '                param(1).Value = intfkVoertuieStandaard
        '            Else
        '                param(0).Value = DBNull.Value
        '            End If

        '            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuieFabrieksByVSAndVoertuie", param)
        '            If reader.Read Then
        '                'Delete all other from table
        '                DeleteFromVoertuieFabrieks("DeleteByfkVoertuie")
        '                If strItems = "" Then
        '                    DeleteFromVoertuieFabrieks("DeleteByfkVoertuie")
        '                Else
        '                    strItems = VB.Left(strItems, Len(strItems) - 1)
        '                    strItems = "(" & strItems & ")"
        '                    DeleteFromVoertuieFabrieks("DeleteByfkVoertuieFabrieks")
        '                End If
        '            End If

        '            For i = 0 To lstStdItmsSelected.Items.Count - 1
        '                strItems = lstStdItmsSelected.Items(i)

        '                Dim splitstrItems() As String

        '                splitstrItems = Split(strItems, " ")


        '                'Dim index As Integer = strItems.IndexOf(" ")

        '                'STRLEN = Len(CInt(strItems - 2))

        '                'index = Mid(strItems, Len(strItems - 2), Len(strItems))
        '                'intItem = CInt(index)
        '                intItem = splitstrItems(UBound(splitstrItems)) 'CInt(strItems.Substring(index))

        '                param(1).Value = intItem

        '                InsertIntoVoertuieFabrieks()
        '                strItems = strItems & intItem
        '            Next i

        '        Next
        '    End Using
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Sub DeleteFromVoertuieFabrieks(ByRef type As String)
        Try
            'Kobus 04/11/2013 voegby derde param
            If type = "DeleteByfkVoertuieFabrieks" Then
                If lstPkFactoryStdDeleted.Count > 0 Then
                    For Each item In lstPkFactoryStdDeleted
                        Using conn As SqlConnection = SqlHelper.GetConnection
                            Dim param() As SqlParameter = {New SqlParameter("@fkVoertuie", SqlDbType.Int), _
                                                           New SqlParameter("@type", SqlDbType.NVarChar), _
                                                           New SqlParameter("fkVoertuieStandaard", SqlDbType.NVarChar)}
                            'Kobus 06/11/2013 verander terug na ou stp
                            ''Kobus 04/11/2013 verander van param(0).Value = Form1.Grid1.SelectedRows(0).Cells(0).Value
                            'Andriette 05/11
                            param(0).Value = pkVoertuie
                            param(1).Value = type
                            param(2).Value = item.ComboBoxID
                            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.Delete_VoertuieFabrieks", param)
                            SqlHelper.GetConnection.Close()
                            conn.Close()
                        End Using
                    Next
                End If

            Else
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim param() As SqlParameter = {New SqlParameter("@fkVoertuie", SqlDbType.Int), _
                                                   New SqlParameter("@type", SqlDbType.NVarChar), _
                                                   New SqlParameter("fkVoertuieStandaard", SqlDbType.NVarChar)}
                    'Kobus 06/11/2013 verander terug na ou stp
                    'Kobus 04/11/2013 verander van param(0).Value = Form1.Grid1.SelectedRows(0).Cells(0).Value
                    'Andriette 05/11
                    param(0).Value = pkVoertuie
                    param(1).Value = type
                    param(2).Value = 0
                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.Delete_VoertuieFabrieks", param)
                    SqlHelper.GetConnection.Close()
                    conn.Close()
                End Using

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Sub InsertIntoVoertuieFabrieks()
        Try
            'Kobus 06/11/2013 voegby en verander
            If lstPkFactoryStdAdd.Count > 0 Then
                For Each item In lstPkFactoryStdAdd
                    Using conn As SqlConnection = SqlHelper.GetConnection
                        Dim param() As SqlParameter = {New SqlParameter("@fkVoertuie", SqlDbType.Int), _
                                                       New SqlParameter("@fkVoertuieStandaard", SqlDbType.Int)}
                        'Kobus 01/11/2013 verander van param(0).Value = Form1.Grid1.SelectedRows(0).Cells(0).Value
                        param(0).Value = pkVoertuie
                        param(1).Value = item.ComboBoxID
                        'For Me.k = 0 To lstStdItmsSelected.Items.Count - 1
                        '    param(1).Value = intItem

                        'If Me.lstStdItmsSelected.Items.Count = 0 Then
                        '    param(1).Value = DBNull.Value
                        'End If

                        SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.InsertIntoVoertuieFabrieks", param)
                        SqlHelper.GetConnection.Close()
                        conn.Close()
                    End Using
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub

        End Try
        'Kobus 07/11/2013 voegby
        blnFactoryStanderd = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        VerwysdesListFrm.ShowDialog()
    End Sub

    Private Sub txtCourtesyVehAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCourtesyVehAmount.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar)) Then
                'do nothing
            Else
                e.Handled = True
                MsgBox("Amount must be numeric", _
                       MsgBoxStyle.Information, "Verify")
                txtKilometerLesing.Focus()
            End If
        End If
    End Sub

    Private Sub txtKmPerJaar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKmPerJaar.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar)) Then
                'do nothing
            Else
                e.Handled = True
                MsgBox("Value must be numeric", _
                       MsgBoxStyle.Information, "Verify")
                txtKilometerLesing.Focus()
            End If
        End If
    End Sub

    Private Sub txtPremieVoor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtPremieVoor.MouseDown

    End Sub

    Private Sub GridEkstras_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridEkstras.CellContentClick

    End Sub

    Private Sub GridEkstras_DataBindingComplete(sender As Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles GridEkstras.DataBindingComplete
        'Kobus Visser - 22/02/2013 - Highlight Total row in gridExtras
        Dim i As Integer
        For i = 0 To Me.GridEkstras.RowCount - 1
            If Me.GridEkstras.Rows(i).Cells(0).Value = 0 Then
                Me.GridEkstras.Rows(i).Cells(1).Style.Font = New Font("arial", 9, FontStyle.Bold)
                Me.GridEkstras.Rows(i).Cells(5).Style.Font = New Font("arial", 9, FontStyle.Bold)
                Me.GridEkstras.Rows(i).Cells(6).Style.Font = New Font("arial", 9, FontStyle.Bold)
                'Kobus 06/06/2013 change Format(Val(Me.GridEkstras.Rows(i).Cells(6).Value), "######0.00")
                'Linkie 05/07/2013FormatNumber(Me.GridEkstras.Rows(i).Cells(6).Value, 2)
            End If
        Next

    End Sub

    Private Sub GridEkstras_Layout(sender As Object, e As System.Windows.Forms.LayoutEventArgs) Handles GridEkstras.Layout

    End Sub
    'Kobus Visser 25/01/2013 - Dubble Click Mouse activated

    Private Sub GridEkstras_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles GridEkstras.MouseDoubleClick

        btnEdit_Click(btnEdit, New System.EventArgs())


    End Sub


    Private Sub lstStdItmsAvailable_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstStdItmsAvailable.SelectedIndexChanged
        'Kobus 04/11/2013 voegby
        blnInformationChanged = True
        blnFactoryStanderd = True
    End Sub

    Private Sub cmbAreaBeskrywing_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbAreaBeskrywing.SelectedIndexChanged
        blnInformationChanged = True
    End Sub

    Private Sub txtPremieVoor_Leave(sender As Object, e As System.EventArgs) Handles txtPremieVoor.Leave
        ' Kobus 29/08/2013 voegby
        If txtPremieVoor.Text = "" Then
            txtPremieVoor.Text = 0
        End If
        'Kobus 15/04/2013 change from keypress to leave event
        If IsNumeric(Me.txtPremieVoor.Text) = True Then
            'do nothing
        Else
            MsgBox("Premium must be numeric", _
                   MsgBoxStyle.Information, "Verify")
            txtPremieVoor.Focus()
        End If

        calcPremium()
    End Sub

    Private Sub VoertuigDetail_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Kobus 10/12/2013 verander hierdie prosedures dieselfde as Huise
        If blnCancel = True Then
            If blnInformationChanged = True Then
                Exit Sub
            End If
        Else
            If Not blnInformationChanged Then
                e.Cancel = False
            Else
                If MsgBox("Are you sure you want to cancel your changes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    e.Cancel = False
                Else
                    e.Cancel = True
                End If
            End If
        End If

        'If blnCancel = True Then
        '    If InformationChanged = True Then
        '        Exit Sub
        '    End If
        'End If
        ''kOBUS 14/08/2013 VOEGBY EN COMMENT OUT ELSE
        'If InformationChanged = True Then
        '    e.Cancel = False
        'End If
        ''Else
        ''    If Not InformationChanged Then
        ''        e.Cancel = True
        ''    Else
        ''        e.Cancel = False
        ''    End If
        ''End If
    End Sub

    Private Sub txtKmPerJaar_TextChanged(sender As Object, e As System.EventArgs) Handles txtKmPerJaar.TextChanged
        blnInformationChanged = True
    End Sub

    Private Sub cmbAreaFrekwensie_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbAreaFrekwensie.SelectedIndexChanged
        blnInformationChanged = True
    End Sub

    Private Sub DataVoertuieEkstras_TextChanged(sender As Object, e As System.EventArgs) Handles DataVoertuieEkstras.TextChanged
        'Kobus 22/04/2013 add
        blnInformationChanged = True
    End Sub

    Private Sub txtAnderBeskrywing_TextChanged(sender As Object, e As System.EventArgs) Handles txtAnderBeskrywing.TextChanged
        'Kobus 22/04/2013 add
        blnInformationChanged = True
    End Sub

    Private Sub txtArea_TextChanged(sender As Object, e As System.EventArgs) Handles txtArea.TextChanged
        'Kobus 22/04/2013 add
        '  InformationChanged = True
    End Sub

    Private Sub txtCourtesyVehAmount_TextChanged(sender As Object, e As System.EventArgs) Handles txtCourtesyVehAmount.TextChanged
        'Kobus 22/04/2013 add
        blnInformationChanged = True
    End Sub

    Private Sub txtEindDatum_TextChanged(sender As Object, e As System.EventArgs) Handles txtEindDatum.TextChanged
        'Kobus 22/04/2013 add
        'InformationChanged = True
    End Sub

    Private Sub txtGenomBestOud1_TextChanged(sender As Object, e As System.EventArgs) Handles txtGenomBestOud1.TextChanged
        'Kobus 22/04/2013 add
        blnInformationChanged = True
    End Sub

    Private Sub txtGenomBestOud2_TextChanged(sender As Object, e As System.EventArgs) Handles txtGenomBestOud2.TextChanged
        'Kobus 22/04/2013 add
        blnInformationChanged = True
    End Sub

    Private Sub txtGenomBestuurder1_TextChanged(sender As Object, e As System.EventArgs) Handles txtGenomBestuurder1.TextChanged
        'Kobus 22/04/2013 add
        blnInformationChanged = True
    End Sub

    Private Sub txtGenomBestuurder2_TextChanged(sender As Object, e As System.EventArgs) Handles txtGenomBestuurder2.TextChanged
        'Kobus 22/04/2013 add
        blnInformationChanged = True
    End Sub

    Private Sub txtGereeldeBestOud1_TextChanged(sender As Object, e As System.EventArgs) Handles txtGereeldeBestOud1.TextChanged
        'Kobus 22/04/2013 add
        blnInformationChanged = True
    End Sub

    Private Sub txtGereeldeBestOud2_TextChanged(sender As Object, e As System.EventArgs) Handles txtGereeldeBestOud2.TextChanged
        'Kobus 22/04/2013 add
        blnInformationChanged = True
    End Sub

    Private Sub txtGereeldeBestOud3_TextChanged(sender As Object, e As System.EventArgs) Handles txtGereeldeBestOud3.TextChanged
        'Kobus 22/04/2013 add
        blnInformationChanged = True
    End Sub

    Private Sub txtGereeldeBestOud4_TextChanged(sender As Object, e As System.EventArgs) Handles txtGereeldeBestOud4.TextChanged
        'Kobus 22/04/2013 add
        blnInformationChanged = True
    End Sub

    Private Sub txtGereeldeBestuurder1_TextChanged(sender As Object, e As System.EventArgs) Handles txtGereeldeBestuurder1.TextChanged
        'Kobus 22/04/2013 add
        blnInformationChanged = True
    End Sub

    Private Sub txtGereeldeBestuurder2_TextChanged(sender As Object, e As System.EventArgs) Handles txtGereeldeBestuurder2.TextChanged
        'Kobus 22/04/2013 add
        blnInformationChanged = True
    End Sub

    Private Sub txtGereeldeBestuurder3_TextChanged(sender As Object, e As System.EventArgs) Handles txtGereeldeBestuurder3.TextChanged
        'Kobus 22/04/2013 add
        blnInformationChanged = True
    End Sub

    Private Sub txtGereeldeBestuurder4_TextChanged(sender As Object, e As System.EventArgs) Handles txtGereeldeBestuurder4.TextChanged
        'Kobus 22/04/2013 add
        blnInformationChanged = True
    End Sub

    Private Sub txtInruil_TextChanged(sender As Object, e As System.EventArgs) Handles txtInruil.TextChanged
        'Kobus 22/04/2013 add
        'InformationChanged = True
    End Sub

    Private Sub txtNPlaat_TextChanged(sender As Object, e As System.EventArgs) Handles txtNPlaat.TextChanged
        'Kobus 22/04/2013 add
        blnInformationChanged = True
    End Sub



    Private Sub txtOornagBeskrywing_TextChanged(sender As Object, e As System.EventArgs) Handles txtOornagBeskrywing.TextChanged
        'Kobus 22/04/2013 add
        blnInformationChanged = True
    End Sub

    Private Sub txtPremieEkstras_TextChanged(sender As Object, e As System.EventArgs) Handles txtPremieEkstras.TextChanged
        'Kobus 22/04/2013 add
        blnInformationChanged = True
    End Sub

    Private Sub txtStad_TextChanged(sender As Object, e As System.EventArgs) Handles txtStad.TextChanged
        'Kobus 22/04/2013 add
        blnInformationChanged = True
    End Sub

    Private Sub txtVoorstad_TextChanged(sender As Object, e As System.EventArgs) Handles txtVoorstad.TextChanged
        'Kobus 22/04/2013 add
        blnInformationChanged = True
    End Sub

    Private Sub txtWaardeEkstras_TextChanged(sender As Object, e As System.EventArgs) Handles txtWaardeEkstras.TextChanged
        'Kobus 22/04/2013 add
        blnInformationChanged = True
    End Sub


    Private Sub _SSTab1_TabPage7_Enter(sender As Object, e As System.EventArgs) Handles _SSTab1_TabPage7.Enter
        'Kobus 19/09/2013 voegby
        If cmbTipeDek.SelectedIndex = 2 And txtWaardeVoertuig.Text = 0 And blnValidationOk = True Then '3rd party" Then
            'If pkVoertuie = 0 Then
            btnVoegby.Enabled = False
            btnEdit.Enabled = False
            btnVerwyder.Enabled = False
            Exit Sub
            'End If
        End If
        'Kobus 12/05/2014 voegby
        If cmbTipeDek.SelectedIndex = 2 And txtWaardeVoertuig.Text = 0 And GridEkstras.RowCount > 1 Then '3rd party
            btnVoegby.Enabled = False
            btnEdit.Enabled = False
            btnVerwyder.Enabled = True
            Exit Sub
        End If
        'Kobus 12/05/2014 voegby
        If cmbTipeDek.SelectedIndex = 2 And txtWaardeVoertuig.Text = 0 And GridEkstras.RowCount <= 1 Then '3rd party
            btnVoegby.Enabled = False
            btnEdit.Enabled = False
            btnVerwyder.Enabled = False
            Exit Sub
        End If
        'Kobus 24/07/2013 voegby
        'validateForm()
        'Kobus 29/08/2013 voegby
        If blnediting Then
            'do nothing
        Else

            If pkVoertuie = 0 Then
                If blnValidationOk = True Then
                    'Kobus 25/04/2014 voegby
                    Me.btnVoegby.Enabled = True
                    Me.btnEdit.Enabled = True
                    Me.btnVerwyder.Enabled = True
                    Me.btnVoegby.Focus()
                    'Kobus 06/05/2014 voegby
                    If cmbTipeDek.SelectedIndex = 2 Then
                        Me.btnVoegby.Enabled = False
                        Me.btnEdit.Enabled = False
                        Me.btnVerwyder.Enabled = False
                    End If
                    Exit Sub
                Else
                    Me.SSTab1.SelectedIndex = 2
                    validateForm()
                    'Kobus 25/04/2014 voegby
                    If blnValidationOk = True Then
                        Me.SSTab1.SelectedIndex = 7
                        btnVoegby.Enabled = True
                        btnEdit.Enabled = True
                        btnVerwyder.Enabled = True
                        btnVoegby.Focus()
                        Exit Sub
                    End If
                    Exit Sub
                End If
            Else
                If blnValidationOk = True Then
                    'gaan voort
                Else
                    Me.SSTab1.SelectedIndex = 2
                    validateForm()
                    Exit Sub
                End If
            End If
            If strRemove = "Yes" Then
                validateForm()
            End If
            If Form1.GEKANS.Text = "Cancelled" Or Form1.GEKANS.Text = "Gekanselleer" Then
                btnVoegby.Enabled = False
                btnEdit.Enabled = False
                btnVerwyder.Enabled = False
            End If
            'Kobus 14/08/2013 voegby
            If cmbTipeDek.SelectedIndex = 2 Then
                btnVoegby.Enabled = False
                If CStr(txtWaardeEkstras.Text) = "" Or CStr(txtWaardeEkstras.Text) = "0" Then
                    btnEdit.Enabled = False
                    btnVerwyder.Enabled = True  'K
                    Me.SSTab1.SelectedIndex = 2
                    Me.txtPremieVoor.Focus()
                End If
            Else
                btnVoegby.Enabled = True
                btnEdit.Enabled = True
                btnVerwyder.Enabled = True

            End If

        End If
        If cmbTipeDek.SelectedIndex = 2 And pkVoertuie = 0 Then '3rd party
            btnVoegby.Enabled = False
            btnEdit.Enabled = False
            btnVerwyder.Enabled = True
        ElseIf cmbTipeDek.SelectedIndex = 2 And pkVoertuie <> 0 Then
            btnEdit.Enabled = False
            btnVerwyder.Enabled = True
        End If
    End Sub
    Private Sub _SSTab1_TabPage7_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles _SSTab1_TabPage7.MouseClick
        'validateForm()
        btnVerwyder.Enabled = True
        'Kobus 25/04/2014 voegby

        'End If
    End Sub

    Private Sub txtWaardeVoertuig_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtWaardeVoertuig.MouseClick
        'txtWaardeVoertuig.SelectAll()
    End Sub

    Private Sub txtPremieVoor_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtPremieVoor.MouseClick
        txtPremieVoor.SelectAll()
    End Sub

    Private Sub _SSTab1_TabPage2_Enter(sender As Object, e As System.EventArgs) Handles _SSTab1_TabPage2.Enter
        'Kobus 16/05/2014 voegby
        If blnInformationChanged = False Then
            Exit Sub
        End If
        'Kobus 15/11/2013 voegby
        btnCancel.Enabled = True
        'Kobus 02/09/2013 Hierdie opsies is by remove extras afgehaal sodat daar nie veelvuldige bêreaksies uitgevoer word nie - bntCancel
        If Not blnLoading Then
            calcTotValue()
            calcPremium()
        End If
        'Kobus 11/12/2013 voegby
        If txtWaardeVoertuig.Text = "" Then
            txtWaardeVoertuig.Text = 0
        End If
        If blnediting And txtWaardeVoertuig.Text >= 350000 Then
            txtWaardeVoertuig.Enabled = False
        End If
        'Kobus 09/09/2013 op versoek van Andriette comment out
        'HerBereken_Premie()
        'doen_subtotaal()
    End Sub

    'Kobus 01/11/2013 skep sub om voertuigwaarde te kontroleer
    Private Sub Above350()
        'Kobus 21/05/2014 voegby
        If blnCancel = True Then
        Else
            'skip
            If Me.txtWaardeVoertuig.Text >= "350000" Then
                If MsgBox("To add a vehicle ​​of R350000 or more, it must be authorized by the branch manager." & Chr(13) & "Would you like to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    frmPassword.lblMessage.Text = "Authorise the specified vehicle value."
                    'Kobus 21/05/2014 voegby
                    frmPassword.txtPassword.Focus()
                    frmPassword.txtPassword.Text = ""
                    frmPassword.ShowDialog()
                    If pwdEntered = "350good" Then
                        Me.txtWaardeVoertuig.Enabled = False
                    End If
                    'Kobus 02/09/2014 verander om al die opsies te betrek
                    If pwdEntered = "Cancelled" Then
                        Me.txtWaardeVoertuig.Enabled = True
                        Me.txtWaardeVoertuig.Text = 0
                        Me.txtWaardeVoertuig.Focus()
                        Exit Sub
                    End If
                    'Kobus 02/09/2014 verander en voegby om verkeerde password te rëel
                    If pwdEntered <> "350good" And pwdEntered <> "Cancelled" Then
                        MsgBox("Password is not correct.", MsgBoxStyle.Information)
                        Me.txtWaardeVoertuig.Enabled = True
                        pwdEntered = ""
                        Me.txtWaardeVoertuig.Focus()
                        Exit Sub
                    End If
                Else
                    Me.txtWaardeVoertuig.Text = 0
                    Me.txtWaardeVoertuig.Focus()
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub txtWaardeVoertuig_Leave(sender As Object, e As System.EventArgs) Handles txtWaardeVoertuig.Leave
        'Kobus 01/11/2013 voegby
        'Kobus 07/11/2013 voegby
        If Me.txtWaardeVoertuig.Text = "" Then
            Me.txtWaardeVoertuig.Text = 0
        End If
        If Trim(Me.cmbWaardeTipe.Text) = "" Then
            Me.txtWaardeVoertuig.Text = 0
            'MsgBox("A value type must be selected first.", MsgBoxStyle.Information)
            Me.cmbWaardeTipe.Focus()
        End If

        If txtWaardeVoertuig.Text >= 350000 Then
            Above350()
        End If
    End Sub

    Private Sub lstStdItmsSelected_TextChanged(sender As Object, e As System.EventArgs) Handles lstStdItmsSelected.TextChanged
        blnInformationChanged = True
        blnFactoryStanderd = True
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Private Sub CancelNewVehicle()
        'Kobus 25/04/2014 comment out - gebruiker moet self die voertuig verwyder op Poldata1
        ''Kobus 10/04/2014 voegby om nuwe voertuie te hanteer by nuwe en bestaande polisse
        ''If Ander Then
        ''    voertuie = FetchVoertuie()
        ''End If
        ''voertuie = FetchVoertuie()

        ''Get selected vehicle from database
        ''rsVoertuie = pol.OpenRecordset("SELECT * FROM voertuie WHERE pkVoertuie = " & pkVoertuie)

        'If voertuie.NoMatch = False Then
        '    If MsgBox("Are you sure you want to delete the vehicle with registration number:  " & voertuie.N_PLAAT, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        '        Exit Sub
        '    End If
        '    reg_uc = UCase(voertuie.N_PLAAT)

        '    If InStr(reg_uc, "ONB") > 0 Then
        '        MsgBox("The vehicle registration number is required to cancel the vehicle", MsgBoxStyle.Exclamation)
        '        Exit Sub
        '    End If
        '    If MsgBox("The vehicle radio must be removed in All Risk, where applicable." & Chr(13) & "Continue to delete the vehicle?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        '        Exit Sub
        '    End If

        '    'If Not gen_WarningsOnCancelorRemove((Me.POLISNO).Text, General.enumCheckType.ItemRemoved, General.enumItemType.Vehicle, pkVoertuie) Then
        '    If voertuie.Huurkoop = True Then
        '        'If Not gen_WarningsOnCancelorRemove(Me.POLISNO.Text, enumCheckType.PolicyCancelled, enumItemType.enum_Vehicle, pkVoertuie) Then
        '        If Not gen_WarningsOnCancelorRemove(glbPolicyNumber, enumCheckType.ItemRemoved, enumItemType.enum_Vehicle, voertuie.pkVoertuie) Then
        '            Exit Sub
        '        End If
        '    End If


        '    'if this was not a Mead & McGrouther vehicle, move record to verwyderede avoertuig

        '    If voertuie.ANDER = True Then
        '        pkVoertuie = pkVoertuie
        '        'Mark select vehicle as deleted in die Voertuie Table
        '        Updatevoertuie(pkVoertuie, True)
        '        'Insert record into verwyderdea_voertuig
        '        '   InsertIntOverwyderdea_Voertuig(voertuie.KODE, voertuie.TIPE)
        '        'Delete selected a_voertuig when it was not as Mead & McGrouther
        '        DeleteFromA_Voertuig(voertuie.KODE, "Delete")
        '    Else
        '        'Mark select vehicle as deleted in die Voertuie Table
        '        Updatevoertuie(Form1.Grid1.SelectedRows(0).Cells(0).Value, True)
        '    End If

        '    'write alteration record
        '    If pol_byvoeg Or Byvoeg Then
        '        'Skip
        '    Else
        '        BESKRYWING = Trim(Form1.Grid1.SelectedRows(0).Cells(2).Value)
        '        BESKRYWING = BESKRYWING & " " & Trim(Form1.Grid1.SelectedRows(0).Cells(3).Value) & " (" & voertuie.N_PLAAT & ")"
        '        UpdateWysig(9, BESKRYWING)
        '    End If


        '    'Recalculate premiums
        '    BFUpdateItemsSubTotals(glbPolicyNumber)
        '    HerBereken_Premie()
        '    Form1.populateGrid1()
        '    If Form1.Grid1.RowCount = 0 Then
        '        MsgBox("Please remove the road assistance and Courtesy vehicle premiums there are no vehicles on the policy.", MsgBoxStyle.Exclamation)

        '    End If

        'End If 'not (rsVoertuie.eof and rsVoertuie.bof)
    End Sub
    Private Sub DeleteFromA_Voertuig(ByVal Kode As String, ByVal strAksie As String)
        'Kobus 10/04/2014 voegby om nuwe voertuie te hanteer by nuwe en bestaande polisse
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params() As SqlParameter = {New SqlParameter("@KODE", SqlDbType.NVarChar), _
                                                New SqlParameter("@verwyderdedatum", SqlDbType.DateTime), _
                                                New SqlParameter("@TransType", SqlDbType.NVarChar)}

                params(0).Value = Kode
                params(1).Value = Now()
                params(2).Value = strAksie

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.DeleteFromA_Voertuig", params)
                conn.Close()
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Updatevoertuie(ByVal pkVoertuig As String, ByVal blnStatus As Boolean)
        'Kobus 10/04/2014 voegby om nuwe voertuie te hanteer by nuwe en bestaande polisse
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params() As SqlParameter = {New SqlParameter("@pkVoertuie", SqlDbType.Int), _
                                                 New SqlParameter("@Cancelled", SqlDbType.Bit), _
                                                New SqlParameter("@VerwyderdeDatum", SqlDbType.DateTime)}

                params(0).Value = pkVoertuig
                params(1).Value = blnStatus
                params(2).Value = Format(Now, "dd/MM/yyyy")

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.Updatevoertuie", params)
                conn.Close()
            End Using
        Catch ex As Exception
        End Try
    End Sub
    Public Sub GetPoskodeAdres(ByVal Poskode As String)
        'Kobus 30/4/2014 skep sub om dorp/stad te soek wanneer dit by ou rekords ontbreek
        Dim strDorp As String = ""
        Dim intI As Integer = 2

        Using conn As SqlConnection = SqlHelper.GetConnection

            Dim param() As SqlParameter = {New SqlParameter("@Poskode", SqlDbType.NVarChar)}

            param(0).Value = Poskode

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPoskodeAdresByKode", param)

            Do While reader.Read
                If reader("voorstad") = txtVoorstad.Text Then
                    strDorp = reader("dorp")
                    txtStad.Text = (reader("Dorp"))
                    intI = 1
                    Exit Do
                Else
                    intI = 2
                    txtStad.Text = reader("dorp")
                End If
            Loop

            If intI > 2 Then
                MsgBox("The record cannot be found, please select a valid address.")
                txtStad.Text = strDorp
            End If
            conn.Close()
        End Using

    End Sub

End Class