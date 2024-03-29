Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Data.SqlClient
Imports DAL

Friend Class Huis_EF

    Inherits BaseForm
    'Description: Form containing all information on property for selected policy Update grid containing list of properties on form1
    Dim k As Integer
   
    Dim oldTypeAfr As String
    Dim oldTypeEng As String
    Dim oldBondAfr As String
    Dim oldBondEng As String
    Dim strMessage As String
    Dim intCurrentMainPtyStatus As Integer
    Public blnInformationChanged As Boolean 'Check if info on form changed
    'Public Loading As Boolean
    Dim blnRequestPwd As Boolean
    Dim blnLoaded As Boolean
    Public intCurrentPtyTypeIndex As Integer
    Public WithEvents GridEkstras As AxMSFlexGridLib.AxMSFlexGrid
    'Linkie 28/03/2013 - comboboxes het nie gewerk nie, altyd verkeerde data teruggebring - stuur variable deur waar dit die combobox pupulate
    Public intPropertyType As Integer
    Public intHomeLoanOrg As Integer
    'Kobus 19/04/2013 skep om onderskeid te maak tussen cancel en ok buttons op vorms om closing event te reguleer
    Public blnCancel As Boolean
    Public blnNoRepeat As Boolean
    'Kobus 18/09/2013 voegby - nodig vir nuwe eiendom waar geysers dadelik gelaai word
    Public blnNewWithGeyser As Boolean
    'Kobus voegby 25/09/2013 om OK te disable by gekanselleerde polisse
    Public strPolicystatus As String
    Public intpkHuisPoshiernatoe As Integer
    Public dblHEWaarde As Double
    Public blnRepeatGeyser As Boolean
    'Kobus 08/05/2014 voegby om dorp/stad by te voeg wanneer ontbreek
    Public strPoskode As String
    'Kobus 09/06/2014 voegby
    Public blnValidationOK As Boolean
    Private Sub A_goedgekeur_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles A_goedgekeur.SelectedIndexChanged
        blnInformationChanged = True
    End Sub
    Private Sub A_komm_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles A_komm.SelectedIndexChanged
        blnInformationChanged = True
    End Sub
    Private Sub A_maak_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles A_maak.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub A_maak_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles A_maak.Leave
        A_maak.Text = UCase(A_maak.Text)
    End Sub
    Private Sub A_monitor_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles A_monitor.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub A_monitor_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles A_monitor.Leave
        A_monitor.Text = UCase(A_monitor.Text)
    End Sub
    Private Sub ADRES_H1_Leave(sender As Object, e As System.EventArgs) Handles ADRES_H1.Leave
        'Kobus 23/10/2013 voegby om Uniekheid te toets
        'Kobus 04/04/2014 voegby voorwaarde
        If Not blnLoading Then
            huis_CheckUniqueAddressAll(ADRES_H1.Text)
        End If
    End Sub
    Private Sub ADRES_H1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ADRES_H1.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub ADRES_H1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles ADRES_H1.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case 34, 39
                ' Anything else is unacceptable, and should be ignored
                MsgBox("The characters " And "can not be used.", MsgBoxStyle.Information)
                KeyAscii = 0
            Case Else
                ' These are acceptable keystrokes
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub Adres4_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Adres4.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub Adres4_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Adres4.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case 34, 39
                ' Anything else is unacceptable, and should be ignored
                MsgBox("The characters " And " can not be used....", MsgBoxStyle.Information)
                KeyAscii = 0
            Case Else
                ' These are acceptable keystrokes
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    'Button cancel clicked
    Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        'Kobus 25/09/2013 voegby
        'Kobus 24/04/2014 voegby Or strPolicystatus = "Gekanselleer"
        If strPolicystatus = "Cancelled" Or strPolicystatus = "Gekanselleer" Then
            blnCancel = True
            blnInformationChanged = False
            Me.Close()
        End If
        'Kobus 24/04/2014 voegby
        If blnNewWithGeyser = True Then
            blnInformationChanged = False
            blnCancel = True
            Me.Close()
        End If
        
        'Update the premium
        'Kobus 07/11/2013 voegby
        If (ADRES_H1.Text) = "" Then
            blnInformationChanged = False
        End If
        blnCancel = True
        Me.Close()
    End Sub
    Private Sub btnDitto_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnDitto.Click
        If Me.ADRES_H1.Enabled = True Then
            Me.ADRES_H1.Text = Trim(Form1.ADRES.Text)
            Me.Adres4.Text = Trim(Form1.adres4.Text)
            Me.DisplayVoorstad.Text = Trim(Form1.ADRES3.Text)
            Me.DisplayDorp.Text = Trim(Form1.ADRES1.Text)
            Me.poskode.Text = Trim(Form1.ADRES2.Text)
            'Kobus 08/05/2014 voegby
            If Me.DisplayDorp.Text = "" Then
                strPoskode = Me.poskode.Text
                GetPoskodeAdres(strPoskode)
            End If
        Else
            'Kobus 24/04/2014 verander van "Address can not be withdrawn on an existing home, only to new homes." na
            'Kobus 19/05/04/2014 verander van MsgBox("Address can not be changed please delete the house and add a new house.", MsgBoxStyle.Information)
            MsgBox("Address can not be changed please delete the property and add a new property.", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub btnEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnEdit.Click
        blnInformationChanged = True

        'Kobus Visser - 22/02/2013 - add if-option to prevent error message when no geyser record exists
        If Me.GridGeisers.RowCount = 0 Then
            MsgBox("There are no geysers to edit.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        'Set pk for Geysers
        If Me.GridGeisers.SelectedCells.Item(0).Value = 0 Then
            geyser.pkGeysers = 0
            MsgBox("You must select an item to edit. ", MsgBoxStyle.Exclamation)
        Else
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            ' pkGeysers = Me.GridGeisers.Text
            geyser.pkGeysers = CInt(Me.GridGeisers.SelectedCells.Item(0).Value)
            pkGeysers = geyser.pkGeysers
            frmGeisers.ShowDialog()
        End If
    End Sub
    Sub UpdateHuis(ByVal premieEkstras As Integer, ByVal waardeEkstras As Integer)
        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim param() As SqlParameter = {New SqlParameter("@pkHuis", SqlDbType.Int), _
                                           New SqlParameter("@premieEkstras", SqlDbType.Int), _
                                          New SqlParameter("@waardeEkstras", SqlDbType.Int)}
            'Kobus 16/09/2013 verander van huis_e.pkHuis
            param(0).Value = pkHuis
            param(1).Value = premieEkstras
            param(2).Value = waardeEkstras

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateHuis", param)
            conn.Close()
        End Using
    End Sub
    Private Sub btnVerwyder_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnVerwyder.Click

        'Kobus Visser - 22/02/2013 - add if-option to prevent error message when no geyser record exists
        If Me.GridGeisers.RowCount = 0 Then
            MsgBox("There are no geysers to remove.", MsgBoxStyle.Exclamation)   'Kobus Visser 12/3/2013 to read remove instead of edit
            Exit Sub
        End If

        If GridGeisers.SelectedRows(0).Cells(0).Value = 0 Then
            pkGeysers = 0

            'If GridGeisers.Text = "pkGeysers" Then
            '    pkGeysers = 0
        Else
            pkGeysers = CInt(GridGeisers.SelectedRows(0).Cells(0).Value)
        End If

        If pkGeysers <> 0 Then
            If MsgBox("Are you sure you want to delete the selected item? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                'Set deleted field = 1 for selected record
                'Me.GridGeisers.Col = 1
                'GridGeisers.SelectedCells.Item(1).Value = "pkGeysers"
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim params() As SqlParameter = {New SqlParameter("@pkGeysers", SqlDbType.Int), _
                                                    New SqlParameter("@Cancelled", SqlDbType.Bit)}
                    params(0).Value = pkGeysers
                    params(1).Value = True
                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateGeyser", params)
                    conn.Close()
                End Using
                'Log alteration
                'Kobus 29/10/2013 voegby
                BESKRYWING = Trim(GridGeisers.SelectedRows(0).Cells(1).Value)
                Dim strMake As String
                Dim decPremie As Decimal
                strMake = Trim(GridGeisers.SelectedRows(0).Cells(2).Value)
                decPremie = Trim(GridGeisers.SelectedRows(0).Cells(6).Value)
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " Geiser verwyder: (" & BESKRYWING & ") (" & strMake & ") Premie: (" & decPremie & ") Eiendom: (" & Me.ADRES_H1.Text & ")"
                Else
                    BESKRYWING = " Geyser removed: (" & BESKRYWING & ") (" & strMake & ") Premium: (" & decPremie & ") Property: (" & Me.ADRES_H1.Text & ")"
                End If
                UpdateWysig(165, BESKRYWING)

                FecthGeyserByprimaryKey()


                'Repopulate gridreader
                PopulateGridGeysers()
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim param() As SqlParameter = {New SqlParameter("@fkHuis", SqlDbType.Int), _
                                             New SqlParameter("@Cancelled", SqlDbType.Bit)}
                    'Kobus 17/09/2013 verabder van huis_e.pkHuis
                    param(0).Value = pkHuis
                    param(1).Value = 0

                    Dim readerGeyser As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchGeyser", param)


                    If readerGeyser.Read Then
                        If IsDBNull(readerGeyser("totpremie")) Then 'No extra items

                            UpdateHuis(0, 0)

                            Me.txtWaardeEkstras.Text = 0
                            Me.calcTotValue()
                            Me.txtPremieEkstras.Text = 0
                            Me.calcPremium()
                        Else

                            UpdateHuis(readerGeyser("Totpremie"), readerGeyser("TotWaarde"))
                            'Populate(values)
                            Me.txtWaardeEkstras.Text = readerGeyser("TotWaarde")
                            Me.calcTotValue()
                            Me.txtPremieEkstras.Text = Format(Val(readerGeyser("Totpremie")), "######0.00")   'Kobus Visser 19/03/2013 change to Format Val
                            Me.calcPremium()
                        End If

                    End If
                    conn.Close()
                End Using
            End If 'Msgbox("is jy seker....
        Else
            MsgBox("Please select an item to remove", MsgBoxStyle.Exclamation)
        End If
    End Sub
    Sub FecthGeyserByprimaryKey()
        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim param As New SqlParameter("@pkGeysers", SqlDbType.NVarChar)
            param.Value = pkGeysers

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchGeyser1", param)
            ' Me.GridGeisers.col = 1
            If Not reader.Read Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = "Geiser verwyder: " & GridGeisers.Text & " " & reader("Fabrikaat") & " " & reader("Model") & " Huis: " & Me.ADRES_H1.Text
                Else
                    BESKRYWING = "Geyser removed: " & GridGeisers.Text & " " & reader("Fabrikaat") & " " & reader("Model") & " House: " & Me.ADRES_H1.Text
                End If

                UpdateWysig(BESKRYWING, (165))

            End If
            conn.Close()
        End Using
    End Sub
    'Button Ok clicked
    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click

        'Kobus 03/04/2014 voegby
        SaveInformation()
        'Kobus 11/11/2013 voegby
        If blnInformationChanged = False Then
            blnCancel = False
            Me.Close()
            Exit Sub
        End If
        'Kobus 03/04/2014 voegby
        'SaveInformation()
        'Kobus 03/04/2014 comment out
        'If SaveInformation() Then
        '    If InformationChanged = True Then
        '        'Exit Sub
        '    End If
        '    blnCancel = False
        'Else
        'Kobus 09/06/2014 voegby
        'validateForm()
        If blnValidationOK = True Then
            blnCancel = False
            'blnNoRepeat = True
            Me.Close()
        End If

        'End If
    End Sub
    Sub InsertINTOHuis()
        Try

            'Dim i As Integer
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim params() As SqlParameter = {New SqlParameter("@itemnr", SqlDbType.SmallInt), _
                                                New SqlParameter("@ADRES_H1", SqlDbType.NVarChar), _
                                                New SqlParameter("@Adres4", SqlDbType.NVarChar), _
                                                New SqlParameter("@TIPE_DAK", SqlDbType.NVarChar), _
                                                New SqlParameter("@STRUKTUUR", SqlDbType.NVarChar), _
                                                New SqlParameter("@WAARDE_HB", SqlDbType.Money), _
                                                New SqlParameter("@PREMIE_HB", SqlDbType.Money), _
                                                New SqlParameter("@WaardeHE", SqlDbType.Money), _
                                                New SqlParameter("@PREMIEHE", SqlDbType.Money), _
                                                New SqlParameter("@PREMIE_HE", SqlDbType.Money), _
                                                New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@PremiePersentasieHB", SqlDbType.Int), _
                                                New SqlParameter("@PremiePersentasieHE", SqlDbType.Int), _
                                                New SqlParameter("@A_MAAK", SqlDbType.NVarChar), _
                                                New SqlParameter("@A_MONITOR", SqlDbType.NVarChar), _
                                                New SqlParameter("@A_KOMM", SqlDbType.NVarChar), _
                                                New SqlParameter("@A_GOEDGEKEUR", SqlDbType.NVarChar), _
                                                New SqlParameter("@POSHIERNATOE", SqlDbType.Real), _
                                                New SqlParameter("@toe_waarde", SqlDbType.Money), _
                                                New SqlParameter("@toe_premie", SqlDbType.Money), _
                                                New SqlParameter("@eem_waarde", SqlDbType.Money), _
                                                New SqlParameter("@eem_premie", SqlDbType.Money), _
                                                New SqlParameter("@poskode", SqlDbType.NVarChar), _
                                                New SqlParameter("@dorp", SqlDbType.NVarChar), _
                                                New SqlParameter("@mainProperty", SqlDbType.TinyInt), _
                                                New SqlParameter("@voorstad", SqlDbType.NVarChar), _
                                                New SqlParameter("@WeerligBeskerming", SqlDbType.TinyInt), _
                                                New SqlParameter("@AlarmReaksie", SqlDbType.TinyInt), _
                                                New SqlParameter("@lapa", SqlDbType.TinyInt), _
                                                New SqlParameter("@OppervlakteLapa", SqlDbType.Float), _
                                                 New SqlParameter("@OppervlakteHuis", SqlDbType.Float), _
                                                New SqlParameter("@fkPropertyType", SqlDbType.Int), _
                                                New SqlParameter("@fkHomeLoanOrg", SqlDbType.Int), _
                                                New SqlParameter("@bondNumber", SqlDbType.NVarChar), _
                                                New SqlParameter("@SekuriteitBitValue", SqlDbType.Int), _
                                                New SqlParameter("@Verband", SqlDbType.Int), _
                                                New SqlParameter("@WAARDE_HE", SqlDbType.Money), _
                                                New SqlParameter("@ErfNommer", SqlDbType.NVarChar)}

                If Len(huisvolgitem) < 1 Then
                    huisvolgitem = 1
                End If
                'Kobus 03/04/2014 comment out
                'If Not editing Then

                dblHuise_Sub = dblHuise_Sub + (Val(HE_Premie.Text) + Val(Premie_HB.Text)) + CDbl(toe_premie.Text) + CDbl(eem_premie.Text)
                params(0).Value = huisvolgitem
                huisvolgitem = huisvolgitem + 1
                'nd If

                'Kobus 29/08/2013 Form1.POLISNO.Text met glbpolicynumber
                UpdateCLRSField("A", (glbPolicyNumber))

                params(1).Value = Trim(ADRES_H1.Text)
                params(2).Value = Trim(Me.Adres4.Text)
                params(3).Value = Format(Combo2.SelectedIndex + 1)
                params(4).Value = Format(Combo1.SelectedIndex + 1)
                'Kobus 03/10/2013 verander van params(5).Value = WAARDE_HB.Text en params(6).Value = Premie_HB.Text
                params(5).Value = CDec(WAARDE_HB.Text)
                params(6).Value = CDec(Premie_HB.Text)
                params(7).Value = CDec(HE_WAARDE.Text)
                params(8).Value = CDec(Me.txtPremieVoorHE.Text)
                params(9).Value = CDec(HE_Premie.Text)
                'Kobus 29/08/2013 Form1.POLISNO.Text met glbpolicynumber
                params(10).Value = glbPolicyNumber
                params(11).Value = Me.txtPremiePersentasieHB.Text
                params(12).Value = Me.txtPremiePersentasieHE.Text
                ''a_maak cannot be a zero length string
                If Trim(A_maak.Text) = "" Then
                    params(13).Value = ""
                Else
                    params(13).Value = Trim(A_maak.Text)
                End If

                If Trim(A_monitor.Text) = "" Then
                    params(14).Value = ""
                Else
                    params(14).Value = Trim(A_monitor.Text)
                End If

                params(15).Value = Format(A_komm.SelectedIndex + 1)
                params(16).Value = Format(A_goedgekeur.SelectedIndex + 1)

                If huisposbestemming.Checked Then
                    params(17).Value = 1
                Else
                    params(17).Value = 0
                End If
                params(18).Value = CDec(toe_waarde.Text)
                params(19).Value = CDec(toe_premie.Text)
                params(20).Value = CDec(eem_waarde.Text)
                params(21).Value = CDec(eem_premie.Text)
                params(22).Value = poskode.Text
                params(23).Value = DisplayDorp.Text
                If Check1.Checked Then
                    params(24).Value = 1
                Else
                    params(24).Value = 0
                End If
                params(25).Value = DisplayVoorstad.Text
                If chkWeerlig.Checked Then
                    params(26).Value = 1
                Else
                    params(26).Value = 0
                End If

                If chkAlarmReaksie.Checked Then
                    params(27).Value = 1
                Else
                    params(27).Value = 0
                End If
                If chkGrasdakLapa.Checked Then
                    params(28).Value = 1
                Else
                    params(28).Value = 0
                End If

                params(29).Value = Val(Me.txtOppervlakteLapa.Text)    'Kobus  System.Math.Round(CDbl(Me.txtOppervlakteLapa.Text), 2)
                params(30).Value = Val(Me.txtOppervlakteHuis.Text)    'Kobus  System.Math.Round(CDbl(Me.txtOppervlakteHuis.Text), 2)

                'Kobus 23/04/2013 COMBOBOXES
                'Kobus 12/11/2013 vervang intBemarkIndeks met 'n meer gepaste veranderlike (intBemarkIndeks word by wysigings van bemarker gebruik)
                Dim intPropertyTypeIndeks As Integer
                Dim item As New ComboBoxEntity
                If cmbPropertyType.SelectedIndex <> -1 Then
                    item = Me.cmbPropertyType.SelectedItem
                    intPropertyTypeIndeks = item.ComboBoxID
                    params(31).Value = intPropertyTypeIndeks
                Else
                    params(31).Value = -1
                End If
                'Kobus 12/11/2013 vervang intBemarkIndeks met 'n meer gepaste veranderlike (intBemarkIndeks word by wysigings van bemarker gebruik)
                Dim intHomeLoanOrgIndeks As Integer
                Dim item1 As New ComboBoxEntity
                If cmbHomeLoanOrg.SelectedIndex <> -1 Then
                    item1 = Me.cmbHomeLoanOrg.SelectedItem
                    intHomeLoanOrgIndeks = item1.ComboBoxID
                    params(32).Value = intHomeLoanOrgIndeks

                Else
                    params(32).Value = -1

                End If
                
                params(33).Value = Trim(Me.txtBondNumber.Text)
                params(34).Value = calcSecuritySelectedBitwise()

                If chkVerband.Checked Then
                    params(35).Value = 1
                Else
                    params(35).Value = 0
                End If
                params(36).Value = Me.TotWaardeHE.Text
                params(37).Value = Me.txtErfNommer.Text

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.InsertIntoHuis", params)
            End Using

            'Kobus 18/09/2013 voeby - vir nuwe eiendom om geyser dadelik te laai

            If blnNewWithGeyser = True Then

                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                    New SqlParameter("ADRES_H1", SqlDbType.NVarChar)}


                    params(0).Value = glbPolicyNumber
                    params(1).Value = ADRES_H1.Text


                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchHuisPkByPolisnoAdresH1", params)

                    If reader.Read Then
                        pkHuis = reader("pkHuis")
                    End If
                    conn.Close()
                End Using

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
            'Kobus 17/04/2013 add
            'Clearnow()
        End Try
    End Sub
    Sub UpdateHuisPosHiernatoe()
        'Kobus 07/10/2013 voegby - opdateer poshienatoe waar nuwe adres die afleweringsadres word
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@pkHuis", SqlDbType.Int), _
                                     New SqlParameter("@FieldName", SqlDbType.NVarChar), _
                                     New SqlParameter("@Value", SqlDbType.NVarChar)}



                params(0).Value = intpkHuisPoshiernatoe
                params(1).Value = "poshiernatoe"
                params(2).Value = 0
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdateHuisPerField]", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub
    Sub UpdateHuisForGrid2()
        Try

            'Dim i As Integer
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim params() As SqlParameter = {New SqlParameter("@itemnr", SqlDbType.SmallInt), _
                                                New SqlParameter("@ADRES_H1", SqlDbType.NVarChar), _
                                                New SqlParameter("@Adres4", SqlDbType.NVarChar), _
                                                New SqlParameter("@TIPE_DAK", SqlDbType.NVarChar), _
                                                New SqlParameter("@STRUKTUUR", SqlDbType.NVarChar), _
                                                New SqlParameter("@WAARDE_HB", SqlDbType.Money), _
                                                New SqlParameter("@PREMIE_HB", SqlDbType.Money), _
                                                New SqlParameter("@WaardeHE", SqlDbType.Money), _
                                                New SqlParameter("@PREMIEHE", SqlDbType.Money), _
                                                New SqlParameter("@PREMIE_HE", SqlDbType.Money), _
                                                New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@PremiePersentasieHB", SqlDbType.Int), _
                                                New SqlParameter("@PremiePersentasieHE", SqlDbType.Int), _
                                                New SqlParameter("@A_MAAK", SqlDbType.NVarChar), _
                                                New SqlParameter("@A_MONITOR", SqlDbType.NVarChar), _
                                                New SqlParameter("@A_KOMM", SqlDbType.NVarChar), _
                                                New SqlParameter("@A_GOEDGEKEUR", SqlDbType.NVarChar), _
                                                New SqlParameter("@POSHIERNATOE", SqlDbType.Real), _
                                                New SqlParameter("@toe_waarde", SqlDbType.Money), _
                                                New SqlParameter("@toe_premie", SqlDbType.Money), _
                                                New SqlParameter("@eem_waarde", SqlDbType.Money), _
                                                New SqlParameter("@eem_premie", SqlDbType.Money), _
                                                New SqlParameter("@poskode", SqlDbType.NVarChar), _
                                                New SqlParameter("@dorp", SqlDbType.NVarChar), _
                                                New SqlParameter("@mainProperty", SqlDbType.TinyInt), _
                                                New SqlParameter("@voorstad", SqlDbType.NVarChar), _
                                                New SqlParameter("@WeerligBeskerming", SqlDbType.TinyInt), _
                                                New SqlParameter("@AlarmReaksie", SqlDbType.TinyInt), _
                                                New SqlParameter("@lapa", SqlDbType.TinyInt), _
                                                New SqlParameter("@OppervlakteLapa", SqlDbType.Float), _
                                                New SqlParameter("@OppervlakteHuis", SqlDbType.Float), _
                                                New SqlParameter("@fkPropertyType", SqlDbType.Int), _
                                                New SqlParameter("@fkHomeLoanOrg", SqlDbType.Int), _
                                                New SqlParameter("@bondNumber", SqlDbType.NVarChar), _
                                                New SqlParameter("@SekuriteitBitValue", SqlDbType.Int), _
                                                New SqlParameter("@Verband", SqlDbType.Int), _
                                                New SqlParameter("@WAARDE_HE", SqlDbType.Money), _
                                                New SqlParameter("@ErfNommer", SqlDbType.NVarChar), _
                                                New SqlParameter("@pkHuis", SqlDbType.Int)}    ' Kobus Visser 06/03/2013 added to use in storedProcedure UpdateHuisForGrid2



                If Len(huisvolgitem) < 1 Then
                    huisvolgitem = 1
                End If
                dblHuise_Sub = dblHuise_Sub + (Val(HE_Premie.Text) + Val(Premie_HB.Text)) + CDbl(toe_premie.Text) + CDbl(eem_premie.Text)
                If blnediting Then

                    params(0).Value = huisvolgitem
                Else 'not editing
                    huisvolgitem = huisvolgitem + 1
                End If

                UpdateCLRSField("A", (Form1.POLISNO).Text)

                params(1).Value = Trim(ADRES_H1.Text)
                params(2).Value = Trim(Me.Adres4.Text)
                params(3).Value = Format(Combo2.SelectedIndex + 1)
                params(4).Value = Format(Combo1.SelectedIndex + 1)
                params(5).Value = WAARDE_HB.Text
                'Kobus 10/10/2013 verander van 
                params(6).Value = Premie_HB.Text
                params(7).Value = CDec(HE_WAARDE.Text)
                params(8).Value = CDec(Me.txtPremieVoorHE.Text)
                params(9).Value = HE_Premie.Text
                'Kobus 29/08/2013 Form1.POLISNO.Text met glbpolicynumber
                params(10).Value = glbPolicyNumber
                params(11).Value = Me.txtPremiePersentasieHB.Text
                params(12).Value = Me.txtPremiePersentasieHE.Text
                ''a_maak cannot be a zero length string
                If Trim(A_maak.Text) = "" Then
                    params(13).Value = ""
                Else
                    params(13).Value = Trim(A_maak.Text)
                End If

                If Trim(A_monitor.Text) = "" Then
                    params(14).Value = ""
                Else
                    params(14).Value = Trim(A_monitor.Text)
                End If

                params(15).Value = Format(A_komm.SelectedIndex + 1)
                params(16).Value = Format(A_goedgekeur.SelectedIndex + 1)

                If huisposbestemming.Checked Then
                    params(17).Value = 1
                Else
                    params(17).Value = 0
                End If
                params(18).Value = CDec(toe_waarde.Text)
                params(19).Value = CDec(toe_premie.Text)
                params(20).Value = CDec(eem_waarde.Text)
                ' Kobus Visser 20/03/2013 bring if option
                If Val(eem_waarde.Text) = 0 Then
                    params(21).Value = "0.00"
                Else
                    params(21).Value = CDec(eem_premie.Text)
                End If
                'params(21).Value = CDec(eem_premie.Text)
                params(22).Value = poskode.Text
                params(23).Value = DisplayDorp.Text
                If Check1.Checked Then
                    params(24).Value = 1
                Else
                    params(24).Value = 0
                End If
                params(25).Value = DisplayVoorstad.Text
                If chkWeerlig.Checked Then
                    params(26).Value = 1
                Else
                    params(26).Value = 0
                End If

                If chkAlarmReaksie.Checked Then
                    params(27).Value = 1
                Else
                    params(27).Value = 0
                End If
                If chkGrasdakLapa.Checked Then
                    params(28).Value = 1
                Else
                    params(28).Value = 0
                End If

                params(29).Value = Val(Me.txtOppervlakteLapa.Text)     'Kobus  .Math.Round(CDbl(Me.txtOppervlakteLapa.Text), 2)
                params(30).Value = Val(Me.txtOppervlakteHuis.Text)     'Kobus  System.Math.Round(CDbl(Me.txtOppervlakteHuis.Text), 2)
                Dim intPropertyTypeIndeks As Integer
                'Kobus 12/11/2013 vervang intBemarkIndeks met 'n meer gepaste veranderlike (intBemarkIndeks word by wysigings van bemarker gebruik)
                Dim item As New ComboBoxEntity
                If cmbPropertyType.SelectedIndex <> -1 Then
                    '  Dim intcounter As Integer
                    item = Me.cmbPropertyType.SelectedItem
                    intPropertyTypeIndeks = item.ComboBoxID
                    params(31).Value = intPropertyTypeIndeks
                    ' Kobus 18/04/2013 
                    'params(31).Value = cmbPropertyType.SelectedIndex
                    'params(31).Value = cmbPropertyType.SelectedItem.comboboxid()
                Else
                    ' huis_e.fkPropertyType = 0
                    'Kobus verander van params(31).Value = 0
                    params(31).Value = -1
                End If
                'Kobus 12/11/2013 vervang intBemarkIndeks met 'n meer gepaste veranderlike (intBemarkIndeks word by wysigings van bemarker gebruik)
                Dim intHomeLoanOrgIndeks As Integer
                Dim item1 As New ComboBoxEntity
                If cmbHomeLoanOrg.SelectedIndex <> -1 Then
                    item1 = Me.cmbHomeLoanOrg.SelectedItem
                    intHomeLoanOrgIndeks = item1.ComboBoxID
                    params(32).Value = intHomeLoanOrgIndeks

                Else
                    params(32).Value = -1

                End If
                params(33).Value = Trim(Me.txtBondNumber.Text)
                params(34).Value = calcSecuritySelectedBitwise()

                If chkVerband.Checked Then
                    params(35).Value = 1
                Else
                    params(35).Value = 0
                End If
                params(36).Value = Me.TotWaardeHE.Text
                params(37).Value = Me.txtErfNommer.Text
                params(38).Value = pkHuis       ' Kobus Visser 06/03/2013 added to use in storedProcedure UpdateHuisForGrid2

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateHuisForGrid2", params)
                conn.Close()
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
            'Kobus17/04/2013 add
            'Clearnow()
        End Try
    End Sub
    Private Function SaveInformation() As Object
        'Kobus 02/04/2014 verander hele function om herhaling van aksies uit te skakel
        'Kobus 10/06/2014 verander van
        blnInformationChanged = True
        'Return True
        validateForm()
        If blnValidationOK = False Then
            Return True
            Exit Function
        End If
        'End If
        'Kobus 03/04/2014 voegby
        If blnRepeatGeyser = False Then
            Return False
            Exit Function

        End If
        If pkHuis = 0 And blnNewWithGeyser = False And blnRepeatGeyser = True Then
            logAlterations()
            InsertINTOHuis()
            'Kobus 01/04/2014 voegby
            BFUpdateItemsSubTotals(glbPolicyNumber)
            'Update grid on form1
            'Update the premium
            HerBereken_Premie()

            updateGrid()
            'Kobus Visser 13/03/2013 change message:  As new added the address where vehicles are checked overnight
            'Kobus Visser 18/03/2013 change message: A New address has been added, check the overnight address for vehicles now.
            'Kobus 19/05/04/2014 verander van MsgBox("A new house has been added, check the overnight address for vehicles now.", MsgBoxStyle.Information)
            MsgBox("A new property has been added, check the overnight address for vehicles now.", MsgBoxStyle.Information)
            Form1.populate_dgvPoldata1Eiendomme()
            'Kobus 11/11/2013 voegby
            blnCancel = False
            'Kobus 03/10/2013 voegby
            'Return True
            Clearnow()
            Me.Close()
            Return False
            Exit Function
        End If
        If pkHuis = 0 And blnNewWithGeyser = True Then
            logAlterations()
            InsertINTOHuis()
            'Kobus 01/04/2014 voegby
            BFUpdateItemsSubTotals(glbPolicyNumber)
            'Update the premium
            HerBereken_Premie()

            'Update grid on form1
            updateGrid()
            'Kobus Visser 13/03/2013 change message:  As new added the address where vehicles are checked overnight
            'Kobus Visser 18/03/2013 change message: A New address has been added, check the overnight address for vehicles now.
            'Kobus 20/05/04/2014 verander van house
            MsgBox("A new Property has been added, check the overnight address for vehicles now.", MsgBoxStyle.Information)
            blnediting = True
            blnInformationChanged = False
            Return False
            Me.Close()
            Exit Function
            Me.Close()
        End If

        If blnediting Then
            logAlterations()
            UpdateHuisForGrid2()
            'Kobus 01/04/2014 voegby
            BFUpdateItemsSubTotals(glbPolicyNumber)
            'Update the premium
            HerBereken_Premie()
            'Update grid on form1
            updateGrid()
            Form1.populate_dgvPoldata1Eiendomme()
            'Kobus 11/11/2013 voegby
            blnCancel = False
            Clearnow()
            Me.Close()
            Return False
        End If
        Return False
        
    End Function
    Private Sub UpdateglobalHuisSub()
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
    Private Sub Clearnow()
       
        Me.cmbHomeLoanOrg.SelectedIndex = -1
        Me.cmbHomeLoanOrg.Text = ""
        Me.A_komm.SelectedIndex = -1
        Me.A_goedgekeur.SelectedIndex = -1
        Me.chkVerband.CheckState = System.Windows.Forms.CheckState.Unchecked
        Me.A_komm.Items.Clear()
        Me.A_goedgekeur.Items.Clear()
        Me.toe_premie.Text = "0.00"
        Me.eem_premie.Text = "0.00"
        Me.toe_waarde.Text = "0"
        Me.eem_waarde.Text = "0"
        Me.txtBoukoste.Text = "0"
        Me.HE_Premie.Text = "0.00"
        Me.Premie_HB.Text = "0.00"
        'Kobus 03/10/2013 voegby
        Me.txtPremieVoorHB.Text = "0.00"
        'Kobus 03/10/2013 voegby
        Me.txtPremieVoorHE.Text = "0.00"
        Me.Check1.CheckState = System.Windows.Forms.CheckState.Unchecked
        Me.chkWeerlig.CheckState = System.Windows.Forms.CheckState.Unchecked
        Me.chkGrasdakLapa.CheckState = System.Windows.Forms.CheckState.Unchecked
        Me.txtOppervlakteHuis.Text = 0
        Me.txtOppervlakteLapa.Text = 0
        Me.txtErfNommer.Text = ""
        Me.txtPremiePersentasieHB.Text = "100"
        Me.txtPremiePersentasieHE.Text = "100"
        'Kobus 30/09/2013 voegby
        Me.chkAlarmReaksie.CheckState = System.Windows.Forms.CheckState.Unchecked
        'Kobus 03/10/2013 voegby
        Me.huisposbestemming.CheckState = System.Windows.Forms.CheckState.Unchecked
        'Kobus 09/10/2013 voegby
        'blnNewWithGeyser = False
        'Kobus 28/10/2013 voegby
        Me.btnVoegby.Enabled = True
        Me.btnEdit.Enabled = True
        Me.btnVerwyder.Enabled = True
        'Kobus 03/04/2014 voegby
        blnRepeatGeyser = False
        'Kobus 20/05/2014 voegby
        blnInformationChanged = False
        blnNewWithGeyser = False
    End Sub
    'Button poskodes clicked
    Private Sub btnPostalCodes_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnPostalCodes.Click
        PoskodesSoek.txtFormToPopulate.Text = Me.Name
        PoskodesSoek.ShowDialog()

    End Sub
    Private Sub btnVoegBy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnVoegby.Click
        
        If pkHuis = 0 Then
            blnNewWithGeyser = True
        End If
        If pkHuis = 0 Then
            If blnNewWithGeyser = False And blnRepeatGeyser = False Then
                validateForm()
                If blnRepeatGeyser = False Then
                    Exit Sub
                End If
            End If
            'Kobus Visser 14/03/2013 change message: This house has not been saved,continue to store the house
            'Kobus 10/10/2013 verander boodskap van - "This property has not been saved jet,continue to add this property? " & Chr(13) & " Save the information now?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            'Kobus 19/05/04/2014 verander van If MsgBox("Prior to loading the geyser, the house information must be saved. " & Chr(13) & " Do you want to save it?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If MsgBox("Prior to loading the geyser, the property information must be saved. " & Chr(13) & " Do you want to save it?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                'Kobus 18/09/2013 voegby
                blnNewWithGeyser = True
                pkGeysers = 0
                'Kobus 03/04/2014 comment out
                'InformationChanged = False
                blnRepeatGeyser = False
                SaveInformation()
                'Huis_EF_Load(Me, New System.EventArgs())
                frmGeisers.ShowDialog()
                
                Exit Sub
                'Me.Close()
            End If
        Else
            pkGeysers = 0
            frmGeisers.ShowDialog()
        End If
    End Sub
    Sub FetchMainProperty()
        'Kobus 25/04/2013 this sub is activated by Check1 Click event - the stored procedure poldata5.FetchMainProperty now check if a_
        'Main Property exists for aspecific polisno
        Try
            Dim param() As SqlParameter = {New SqlParameter("@mainProperty", SqlDbType.TinyInt), _
                                           New SqlParameter("@POLISNO", SqlDbType.VarChar), _
                                           New SqlParameter("@Cancelled", SqlDbType.Bit)}

            param(0).Value = 1
            param(1).Value = Persoonl.POLISNO
            param(2).Value = False

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchMainProperties", param)
            If reader.Read() Then
                'Kobus 08/04/2013 change message from: "There may be only one main property per policy be."
                'Kobus 12/09/2013 verander van "There may only be one main property per policy." na
                MsgBox("There is already a major property for this policy." & Chr(13) & "There may only be one main property per policy.", MsgBoxStyle.Information)
                Check1.CheckState = System.Windows.Forms.CheckState.Unchecked
            Else
                UpdateCLRSField("A", (Form1.POLISNO).Text)
                Check1.CheckState = System.Windows.Forms.CheckState.Checked
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
        

    End Sub
    Private Sub Check1_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check1.CheckStateChanged
        blnInformationChanged = True
        'set current mainproperty status
        If huis_e.NoMatch Then

            If IsDBNull(huis_e.mainproperty) Then
                intCurrentMainPtyStatus = 0
            Else
                intCurrentMainPtyStatus = huis_e.mainproperty
            End If
        Else
            intCurrentMainPtyStatus = 0
        End If


    End Sub
    Private Sub chkGrasdakLapa_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkGrasdakLapa.CheckStateChanged
        If chkGrasdakLapa.CheckState Then
            Me.lblm.Enabled = True
            Me.lblOppvLapa.Enabled = True
            Me.txtOppervlakteLapa.Enabled = True
        Else
            Me.lblm.Enabled = False
            Me.lblOppvLapa.Enabled = False
            Me.txtOppervlakteLapa.Enabled = False
        End If

    End Sub
    Private Sub chkSekuriteit_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkSekuriteit.CheckStateChanged
        Dim Index As Short = chkSekuriteit.GetIndex(eventSender)
        blnInformationChanged = True
    End Sub
    Private Sub chkVerband_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkVerband.CheckStateChanged
        blnInformationChanged = True
        If Me.chkVerband.CheckState Then
            Me.cmbHomeLoanOrg.SelectedIndex = -1
            Me.cmbHomeLoanOrg.Text = ""
            Me.cmbHomeLoanOrg.Enabled = True
            Me.txtBondNumber.Enabled = True
        Else
            'Kobus Visser 27/03/2013 change from 0
            Me.cmbHomeLoanOrg.Text = ""
            Me.cmbHomeLoanOrg.SelectedIndex = -1
            Me.txtBondNumber.Text = ""
            Me.cmbHomeLoanOrg.Enabled = False
            Me.txtBondNumber.Enabled = False
            Me.txtBondNumber.Text = ""

        End If
        
        'Kobus voegby
        If Me.chkVerband.CheckState = CheckState.Unchecked And Me.cmbHomeLoanOrg.Text = "Absa" Then
            Me.cmbHomeLoanOrg.Enabled = True
            Me.cmbHomeLoanOrg.Text = ""
            Me.cmbHomeLoanOrg.Enabled = False
        End If
    End Sub
    Private Sub chkWeerlig_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkWeerlig.CheckStateChanged
        blnInformationChanged = True

    End Sub
    Private Sub cmbHomeLoanOrg_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbHomeLoanOrg.SelectedIndexChanged
        blnInformationChanged = True
        'Kobus Visser 27/03/2013 change from 0
        If cmbHomeLoanOrg.SelectedIndex = -1 Then
            cmbHomeLoanOrg.Text = "" 'K
            Me.txtBondNumber.Text = ""
        End If

    End Sub
    Private Sub cmbPropertyType_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbPropertyType.SelectedIndexChanged
       
        blnInformationChanged = True
        'Kobus 25/09/2013 voegby
        'Kobus 24/04/2014 voegby Or strPolicystatus = "Gekanselleer"
        If strPolicystatus = "Cancelled" Or strPolicystatus = "Gekanselleer" Then
            ' do nothing
        Else

            'Only authorized users may select this option
            'If GetItemData(cmbPropertyType, cmbPropertyType.SelectedIndex) = 19 Then 'Pk of item
            'Kobus 08/11/2013 voegby
            If Me.cmbPropertyType.SelectedIndex = -1 Then
            Else
                If cmbPropertyType.SelectedItem.comboboxid = 19 Then 'Pk of item
                    If Not blnLoading Then
                        'Kobus 30/10/2013 verander van frmPassword.lblMessage.Text = "Please choose from local storage on the password fields. (HB only be covered for this choice) "
                        frmPassword.lblMessage.Text = "Authorise local storage. (Only valid for House Contents coverage) "

                        frmPassword.ShowDialog()

                        If pwdEntered = "passmeby" Then

                        Else
                            If Trim(pwdEntered) = "" Then
                                Me.cmbPropertyType.Focus()
                                Exit Sub
                            End If
                            MsgBox("The password is not correct.", MsgBoxStyle.Information)
                            'Kobus 01/09/2014 voegby if...
                            If pkHuis <> 0 Then
                                cmbPropertyType.SelectedIndex = intCurrentPtyTypeIndex
                            Else
                                cmbPropertyType.SelectedIndex = -1
                            End If

                        End If
                    End If
                Else
                End If
            End If
        End If
    End Sub
    Private Sub Combo1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Combo1.SelectedIndexChanged
        blnInformationChanged = True
    End Sub
    Private Sub Combo2_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Combo2.SelectedIndexChanged
        blnInformationChanged = True
    End Sub
    Private Sub DisplayDorp_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DisplayDorp.Enter
        MsgBox("Please use the list of National postal codes for a town \ city to choose.", MsgBoxStyle.Exclamation)
        Me.btnPostalCodes.Focus()
    End Sub
    Private Sub DisplayVoorstad_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DisplayVoorstad.TextChanged
        blnInformationChanged = True
    End Sub

    Private Sub DisplayVoorstad_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DisplayVoorstad.Enter
        MsgBox("Please use the list of National postal codes to a suburb to choose.", MsgBoxStyle.Exclamation)

        Me.btnPostalCodes.Focus()
    End Sub

    Private Sub eem_premie_Click(sender As Object, e As System.EventArgs) Handles eem_premie.Click
        Me.eem_premie.SelectAll()
    End Sub

    Private Sub eem_premie_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles eem_premie.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub eem_premie_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles eem_premie.Enter
        Me.eem_premie.SelectAll()
        'Kobus 29/04/2013 comment out
        'Me.eem_premie.SelectionLength = Len(Me.eem_premie.Text)
    End Sub

    Private Sub eem_waarde_Click(sender As Object, e As System.EventArgs) Handles eem_waarde.Click
        Me.eem_waarde.SelectAll()
    End Sub
    Private Sub eem_waarde_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles eem_waarde.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar)) Then
                'do nothing
            Else
                e.Handled = True
                MsgBox("Value: Must be a whole numeric value.", _
                       MsgBoxStyle.Information, "Verify")
                Me.SSTab1.SelectedIndex = 5
                Me.eem_waarde.Focus()
                Exit Sub
            End If
        End If
    End Sub
    Private Sub eem_waarde_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles eem_waarde.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub eem_waarde_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles eem_waarde.Enter
        Me.eem_waarde.SelectionStart = 0
        Me.eem_waarde.SelectionLength = Len(Me.eem_waarde.Text)
    End Sub
    Private Sub Huis_EF_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        'Kobus 25/09/2013 voegby om OK button te disable by gekanselleerde polisse
        'Kobus 25/09/2013 voegby om OK button te disable by gekanselleerde polisse
        strPolicystatus = Form1.GEKANS.Text
        'Kobus 24/04/2014 voegby Or strPolicystatus = "Gekanselleer"
        If strPolicystatus = "Cancelled" Or strPolicystatus = "Gekanselleer" Then
            btnOk.Enabled = False
        End If
        If Me.chkVerband.CheckState Then
            'do nothing
        Else
            Me.cmbHomeLoanOrg.SelectedIndex = -1
            Me.cmbHomeLoanOrg.Text = ""
        End If
        'Set title for window
        'Kobus 29/08/2013 Form1.POLISNO.Text met glbpolicynumber
        'Kobus 07/11/2013 verander Eiendom besonderhede na Property detail 6.98
        Me.Text = "     Property detail - " & Form1.TITEL.Text & " " & Form1.VOORL.Text & " " & Form1.VERSEKERDE.Text & " (" & glbPolicyNumber & ")"
        'format die waarde om R en c te vertoon
        toe_premie.Text = Format(toe_premie.Text)
        eem_premie.Text = Format(eem_premie.Text)
        'Kobus Visser 25/03/2013 added
        Me.SSTab1.SelectedIndex = 1
        
        'Kobus Visser 25/03/2013 added
        If Me.txtPremieVoorHE.Text > "0.00" Then
            'Me.SSTab1.TabPages.Item(6).IsAccessible = True
            Me.btnVoegby.Enabled = True
        Else
            'Kobus 29/10/2013 voegby
            Me.btnVoegby.Enabled = True
            'Kobus 29/10/2013 comment out
            'Me.SSTab1.TabPages.Item(6).IsAccessible = False
        End If

        'Disable adres when editing
        If blnediting Then
            Me.ADRES_H1.Enabled = False
            If Val(HE_WAARDE.Text) <> 0 Then
                Me._SSTab1_TabPage6.Enabled = True
                Me.btnVoegby.Enabled = True
                Me.btnEdit.Enabled = True
                Me.btnVerwyder.Enabled = True
            Else
                Me._SSTab1_TabPage6.Enabled = False
            End If
        Else
            Me.ADRES_H1.Enabled = True
            'Kobus 28/10/2013 voegby
            Me._SSTab1_TabPage6.Enabled = False
            Me.btnVoegby.Enabled = False
            Me.btnEdit.Enabled = False
            Me.btnVerwyder.Enabled = False
        End If


        If Gebruiker.titel = "Besigtig" Then
            Me.btnOk.Enabled = False
            Me.btnVoegby.Enabled = False
            Me.btnEdit.Enabled = False
            Me.btnVerwyder.Enabled = False
        End If

        'Set focus
        If Not blnLoaded Then
            'set active tab
            'Kobus Visser 25/03/2013
            Me.SSTab1.SelectedIndex = 1
            If Me.ADRES_H1.Enabled Then
                Me.ADRES_H1.Focus()
            Else
                Me.cmbPropertyType.Focus()
            End If
        End If
    End Sub
    'Kobus 19/04/2013 add
    Private Sub Huis_EF_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If blnCancel = False Then
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
        'blnNewWithGeyser = False
        blnNoRepeat = False
        blnRepeatGeyser = False
        'Me.Close()
    End Sub
    Private Sub Huis_EF_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Clearnow()
        blnLoading = True
        blnRequestPwd = True
        'Kobus 19/04/2013 add
        blnCancel = False
        'Kobus 07/03/2013 comment out - created by Andriette no longer needed
        'Dim intSelectIndex As Integer  
        'Kobus 25/03/2013 added
        Me.SSTab1.SelectTab(1)
        If Not blnediting Then
            'Kobus Visser 25/03/2013 added
            Me.A_komm.SelectedIndex = -1
            'Kobus Visser 25/03/2013 added
            Me.A_goedgekeur.SelectedIndex = -1
            'Kobus Visser 29/04/2013 added
            Me.cmbHomeLoanOrg.SelectedIndex = -1
            Me.cmbHomeLoanOrg.Text = "" ' k
        End If
        If Gebruiker.titel = "Besigtig" Then
            Me.btnOk.Enabled = False
            Me.btnVoegby.Enabled = False
            Me.btnEdit.Enabled = False
            Me.btnVerwyder.Enabled = False

        End If
        'Kobus 25/09/2013 voegby om OK button te disable by gekanselleerde polisse
        strPolicystatus = Form1.GEKANS.Text
        'Kobus 24/04/2014 voegby Or strPolicystatus = "Gekanselleer"
        If strPolicystatus = "Cancelled" Or strPolicystatus = "Gekanselleer" Then
            btnOk.Enabled = False
        Else
            btnOk.Enabled = True
        End If

        'Kobus 26/09/2013 voegby
        Dim intTestnow As Integer
        intTestnow = Form1.dgvPoldata1Eiendomme.RowCount
        If intTestnow = 0 Then
            pkHuis = 0
        Else
            'Kobus Visser 04/03/2013 restore
            'Kobus 01/11/2013 voeg kondisie by
            If Not blnediting Then
                pkHuis = 0
            Else
                pkHuis = Form1.dgvPoldata1Eiendomme.SelectedCells.Item(13).Value
                'pkHuis = Form1.Grid2.SelectedCells.Item(13).Value
                'ElsEnd If
            End If
        End If
        'Get the selected property
        'Check: edit or addnew
        If blnediting Then
            Me.SSTab1.SelectedIndex = 1   'Kobus Visser 25/03/2013 added
            'sSql = "SELECT * FROM huis WHERE polisno = '" & Trim(Form1.POLISNO) & "' AND pkHuis = " & pkHuis & " AND adres_h1 = '" & Replace(Trim(Form1.Grid2.Text), "'", "''") & "' AND cancelled = false"
            Try
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim param() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                     New SqlParameter("@pkHuis", SqlDbType.Int), _
                                                    New SqlParameter("@Cancelled", SqlDbType.Bit), _
                                                    New SqlParameter("@ADRES_H1", SqlDbType.NVarChar)}

                    'Kobus 30/09/2013 verander van Persoonl.POLISNO
                    param(0).Value = glbPolicyNumber
                    'Kobus 18/09/2013 verander van param(1).Value = Form1.Grid2.SelectedCells.Item(13).Value  'Kobus Visser 04/03/2013 restore
                    ' Andriette 27/02/2013 Grid Veranderinge
                    'Kobus 30/09/2013 - verander van param(1).Value = Form1.Grid2.SelectedCells.It
                    'param(1).Value = Form1.Grid2.SelectedCells.Item(21).Valueem(13).Value
                    param(1).Value = pkHuis
                    param(2).Value = 0
                    ' Andriette 27/02/2013 Grid veranderinge
                    param(3).Value = Replace(Trim(Form1.dgvPoldata1Eiendomme.SelectedCells.Item(13).Value), "'", "''")    'Kobus Visser 04/03/2013 restore
                    'param(3).Value = Replace(Trim(Form1.Grid2.SelectedCells.Item(21).Value), "'", "''")

                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchHuisInformation4Grid1", param)

                    'Linkie 28/03/2013 - skuif populatecomboboxes en setsecurityitemscaption in die If in - as daar nie 'n huis gevind word nie, laai dit ook nie die skerm nie, so nie nodig dat die comboboxes laai nie

                    If reader.Read Then
                        'Linkie 28/03/2013 - comboboxes het nie regte data teruggebring nie (indexe), stuur variable deur van die fk
                        intPropertyType = reader("fkPropertyType")
                        intHomeLoanOrg = reader("fkHomeLoanOrg")

                        'sub populating the comboboxes
                        populateComboBoxes()

                        'Set security items' caption
                        setSecurityItemsCaption()

                        pkHuis = reader("pkHuis")
                        'Kobus 08/05/04/2014 verander van : If IsDBNull(reader("AlarmReaksie")) Or reader("AlarmReaksie") = 0 Then
                        If IsDBNull(reader("AlarmReaksie")) Then
                            Me.chkAlarmReaksie.CheckState = System.Windows.Forms.CheckState.Unchecked
                        Else
                            If reader("AlarmReaksie") = 0 Then
                                Me.chkAlarmReaksie.CheckState = System.Windows.Forms.CheckState.Unchecked
                            Else
                                Me.chkAlarmReaksie.CheckState = System.Windows.Forms.CheckState.Checked
                            End If

                        End If

                        If reader("mainproperty") = 0 Or IsDBNull(reader("mainproperty")) Then
                            Check1.CheckState = System.Windows.Forms.CheckState.Unchecked

                        Else
                            Check1.CheckState = System.Windows.Forms.CheckState.Checked
                        End If
                        If IsDBNull(reader("Verband")) Or Not (reader("Verband")) Then
                            Me.chkVerband.CheckState = System.Windows.Forms.CheckState.Unchecked
                            cmbHomeLoanOrg.SelectedIndex = -1
                        Else
                            Me.chkVerband.CheckState = System.Windows.Forms.CheckState.Checked
                        End If
                        chkVerband_CheckStateChanged(chkVerband, New System.EventArgs())

                        Me.txtErfNommer.Text = reader("ErfNommer") & ""

                        'Security()
                        Me.setSecuritySelected(reader("SekuriteitBitValue"))

                        'Populate(lapa)
                        If IsDBNull(reader("lapa")) Then
                            chkGrasdakLapa.CheckState = System.Windows.Forms.CheckState.Unchecked
                        Else
                            chkGrasdakLapa.CheckState = reader("lapa")
                        End If
                        If IsDBNull(reader("OppervlakteLapa")) Then
                            'Kobus 03/10/2013 van CStr(0)
                            Me.txtOppervlakteLapa.Text = "0.00"
                        Else
                            'Kobus Visser - 21/02/2013 - Format to show last 0 in decimal value where applicable
                            Me.txtOppervlakteLapa.Text = Format(Val(reader("OppervlakteLapa")), "######0.00")
                        End If
                        If IsDBNull(reader("OppervlakteHuis")) Then
                            'Kobus 03/10/2013 verander van CStr(0)
                            Me.txtOppervlakteHuis.Text = "0.00"
                        Else
                            Me.txtOppervlakteHuis.Text = Format(Val(reader("OppervlakteHuis")), "######0.00")
                        End If
                        'Populate(fields)

                        'If reader("STRUKTUUR") IsNot DBNull.Value Then
                        '    Combo1.SelectedIndex = reader("STRUKTUUR")
                        'End If
                        'If reader("TIPE_DAK") IsNot DBNull.Value Then
                        '    Combo2.SelectedIndex = reader("TIPE_DAK")
                        'End If
                        Combo1.SelectedIndex = Val(reader("STRUKTUUR")) - 1
                        Combo2.SelectedIndex = Val(reader("TIPE_DAK")) - 1
                        'Linkie 28/03/2013 - comboboxes het nie regte data teruggebring nie (indexe)
                        'Linkie 28/03/2013If reader("fkHomeLoanOrg") IsNot DBNull.Value Then
                        'Linkie 28/03/2013cmbHomeLoanOrg.SelectedIndex = reader("fkHomeLoanOrg")
                        'Linkie 28/03/2013End If
                        'Linkie 28/03/2013 - comboboxes het nie regte data teruggebring nie (indexe)
                        'Linkie 28/03/2013If reader("fkPropertyType") IsNot DBNull.Value Then
                        'Linkie 28/03/2013cmbPropertyType.SelectedIndex = reader("fkPropertyType")
                        'Linkie 28/03/2013End If

                        'Kobus 23/04/2013 COMBOBOX

                        If IsDBNull(reader("fkPropertyType")) Then
                            Me.cmbPropertyType.SelectedIndex = -1

                        Else
                            'Kobus 08/11/2013 voegby om die probleem te ondervang waar fkPropertyType 0 is en nie Null
                            Dim intfkPropertyType As Integer
                            intfkPropertyType = reader("fkPropertyType")
                            If intfkPropertyType = 0 Then
                                Me.cmbPropertyType.SelectedIndex = -1
                            Else
                                Me.cmbPropertyType.SelectedIndex = GetComboIndex(reader("fkPropertyType"), Me.cmbPropertyType.DataSource)
                                'Kobus 01/09/2014 voegby
                                intCurrentPtyTypeIndex = Me.cmbPropertyType.SelectedIndex
                            End If
                        End If
                        If IsDBNull(reader("fkHomeLoanOrg")) Then
                            Me.cmbHomeLoanOrg.SelectedIndex = -1
                        Else

                            Me.cmbHomeLoanOrg.SelectedIndex = GetComboIndex(reader("fkHomeLoanorg"), Me.cmbHomeLoanOrg.DataSource)

                        End If
                        Me.txtBondNumber.Text = reader("bondNumber")
                        Me.ADRES_H1.Text = reader("ADRES_H1")
                        Me.Adres4.Text = reader("Adres4")
                        Me.DisplayDorp.Text = reader("dorp")
                        Me.DisplayVoorstad.Text = reader("voorstad")
                        Me.poskode.Text = reader("poskode")
                        'Kobus 08/05/2014 voegby
                        If Me.DisplayDorp.Text = "" Then
                            strPoskode = reader("poskode")
                            GetPoskodeAdres(strPoskode)
                        End If
                        If IsDBNull(reader("WeerligBeskerming")) Then
                            chkWeerlig.CheckState = System.Windows.Forms.CheckState.Unchecked

                        Else
                            Me.chkWeerlig.CheckState = reader("WeerligBeskerming")
                        End If
                        If IsDBNull(reader("A_MAAK")) Then
                            A_maak.Text = ""
                        Else
                            A_maak.Text = reader("A_MAAK")
                        End If
                        If IsDBNull(reader("A_MONITOR")) Then
                            A_monitor.Text = ""
                        Else
                            A_monitor.Text = reader("A_MONITOR")
                        End If

                        If IsDBNull(reader("A_KOMM")) Then
                            A_komm.SelectedIndex = -1

                        Else
                            'Kobus Visser 25/03/2013
                            A_komm.SelectedIndex = Val(reader("A_KOMM")) - 1
                        End If

                        If IsDBNull(reader("A_GOEDGEKEUR")) Then
                            'Kobus 03/10/2013 verander van Format(A_goedgekeur.SelectedIndex + 1)
                            'Kobus Visser 25/03/2013 restore
                            A_goedgekeur.SelectedIndex = -1
                        Else
                            A_goedgekeur.SelectedIndex = Val(reader("A_GOEDGEKEUR")) - 1
                        End If

                        If IsDBNull(reader("POSHIERNATOE")) Then
                            'Kobus 03/10/2013 verander van
                            '    huisposbestemming.CheckState = reader("POSHIERNATOE")
                            'Else
                            '    huisposbestemming.CheckState = System.Windows.Forms.CheckState.Unchecked
                            'End If
                            huisposbestemming.CheckState = System.Windows.Forms.CheckState.Unchecked
                        Else
                            huisposbestemming.CheckState = reader("POSHIERNATOE")
                        End If
                        If reader("WAARDEHE") <> 0 Then
                            'Kobus 31/5/2013 change to FormatNumber(reader("WAARDEHE"), 0)
                            HE_WAARDE.Text = Format(Val(reader("WAARDEHE")), "##########")
                        Else
                            HE_WAARDE.Text = "0"
                        End If

                        If reader("PREMIEHE") <> 0 Then
                            HE_Premie.Text = reader("PREMIEHE")
                        Else
                            'Kobus 13/09/2013 verander van "0"
                            HE_Premie.Text = 0
                        End If

                        'Kobus - 21/02/2013 - Format values that last 0 in cents where applicable will show.
                        If reader("PREMIE_HB") <> 0 Then
                            'Kobus 09/10/2013 verander van Format(Val(reader("premie_hb")), "######0,00")
                            'Premie_HB.Text = Format(CDbl(reader("PREMIE_HB")), "######0,00")
                            Me.Premie_HB.Text = reader("PREMIE_HB")
                            'Premie_HB.Text = FormatNumber(Val(reader("premie_hb")), 2)
                        Else
                            'Kobus 03/10/2013 verander van Premie_HB.Text = FormatNumber(0, 2)     'Kobus - 20/02/2013 - verander 0 na 0.00
                            Premie_HB.Text = 0
                        End If

                        'Kobus Visser - 13/09/2013 - Format to show last 0 in decimal values where applicable
                        If reader("WAARDE_HB") <> 0 Then
                            WAARDE_HB.Text = Format(Val(reader("WAARDE_HB")), "#########")
                        Else
                            WAARDE_HB.Text = "0"
                        End If

                        If reader("toe_waarde") <> 0 Then
                            'Kobus verander van reader("toe_waarde")
                            toe_waarde.Text = Format(Val(reader("toe_waarde")), "##########")
                        Else
                            toe_waarde.Text = "0"
                        End If
                        If reader("toe_premie") <> 0 Then
                            toe_premie.Text = Format(Val(reader("toe_premie")), "######0.00")
                        Else
                            toe_premie.Text = Format("0", "0.00")
                        End If

                        If reader("eem_waarde") <> 0 Then
                            'Kobus verander van
                            eem_waarde.Text = Format(Val(reader("eem_waarde")), "##########")
                        Else
                            eem_waarde.Text = "0"
                        End If

                        If reader("eem_premie") <> 0 Then
                            eem_premie.Text = Format(Val(reader("eem_premie")), "######0.00")
                        Else
                            'Kobus 16/04/2013 change toe_premie.Text to eem_premie.Text
                            eem_premie.Text = Format("0", "0.00")
                        End If

                        Me.txtPremiePersentasieHB.Text = CStr(Val(reader("PremiePersentasieHB")))
                        Me.txtPremiePersentasieHE.Text = CStr(Val(reader("PremiePersentasieHE")))


                        Me.HE_Premie.Text = Format((CDbl(Me.HE_Premie.Text) / CDbl(Me.txtPremiePersentasieHE.Text) * 100), "######0.00")     'K
                        Me.txtPremieVoorHE.Text = CStr(Format(CDbl(reader("PremieHE")), "######0.00"))     'K
                        Me.txtPremieVoorHB.Text = Format(System.Math.Round((Val(reader("PREMIE_HB")) / (Val(Me.txtPremiePersentasieHB.Text)) * 100), 2), "########0.00")
                        'Me.txtPremieVoorHB.Text = CStr(Format(CDbl(reader("PREMIE_HB")), "########0.00"))
                        Me.txtWaardeEkstras.Text = CStr(Val(IIf(IsDBNull(reader("WaardeEkstras")), 0, reader("WaardeEkstras"))))
                        Me.txtPremieEkstras.Text = CStr(Format(Val(IIf(IsDBNull(reader("premieEkstras")), 0, reader("premieEkstras"))), "######0.00")) 'K
                        calcTotValue()
                        calcPremium()
                        If IsDBNull(Persoonl.eispers) Then
                            Me.txtPremieNaKortingHB.Text = CStr(Format(Val(Me.Premie_HB.Text), "######0.00"))     'K
                            Me.txtPremieNaKortingHE.Text = CStr(Format(Val(Me.HE_Premie.Text), "######0.00"))     'K
                        Else
                            Me.txtPremieNaKortingHB.Text = CStr(Format(Val(Me.Premie_HB.Text) * Val(Persoonl.eispers), "######0.00"))    'K
                            Me.txtPremieNaKortingHE.Text = CStr(Format(System.Math.Round(Val(Me.HE_Premie.Text) * Val(Persoonl.eispers), 2), "######0.00"))    'K
                        End If

                    Else
                        MsgBox("The property could not be found." & Chr(13) & "There may be error with the database. Contact Mooi River Computers", MsgBoxStyle.Exclamation)

                        Me.Close()
                    End If
                    conn.Close()
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)

            End Try
        Else 'Not editing
            'sub populating the comboboxes
            populateComboBoxes()

            'Set security items' caption
            setSecurityItemsCaption()

            FetchHuisInformation4Grid()

            pkHuis = 0
            Me.SSTab1.SelectedIndex = 1   'Kobus Visser 25/03/2013 added
            'Me.SSTab1.TabPages.Item(6).Enabled = True  'K
            A_komm.SelectedIndex = -1                   'K Visser 25/03/2013 added
            A_goedgekeur.SelectedIndex = -1             'K

        End If 'if editing
        FetchPerssonByArea()

        If blnediting Then
            PopulateGridGeysers()
        Else
            GridGeisers.DataSource = Nothing
        End If

        'Populate grid with geysers

        _chkSekuriteit_6.Enabled = False
        _chkSekuriteit_7.Enabled = False

        blnInformationChanged = False
        blnLoading = False
        blnLoaded = True
        blnNoRepeat = True
        'Kobus 29/04/2013 add condition
        If chkVerband.CheckState = CheckState.Unchecked Then
            cmbHomeLoanOrg.SelectedIndex = -1
        End If
    End Sub
    Sub FetchHuisInformation4Grid()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection


                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                               New SqlParameter("@pkHuis", SqlDbType.Int), _
                                               New SqlParameter("@Cancelled", SqlDbType.Bit)}

                'Kobus 29/08/2013 Form1.POLISNO.Text met glbpolicynumber
                param(0).Value = Trim(glbPolicyNumber)
                param(1).Value = 0
                param(2).Value = 0

                Combo1.SelectedIndex = -1
                Combo2.SelectedIndex = -1

                A_maak.Text = ""
                A_monitor.Text = ""
                A_komm.SelectedIndex = -1
                A_goedgekeur.SelectedIndex = -1
                'Kobus 13/09/2013 verander van string na integer
                HE_WAARDE.Text = "0"
                Premie_HB.Text = "0.00"
                WAARDE_HB.Text = "0"
                toe_waarde.Text = "0"
                toe_premie.Text = "0.00"
                eem_waarde.Text = "0"
                eem_premie.Text = "0.00"
                txtPremieVoorHB.Text = "0.00"
                txtPremieVoorHE.Text = "0.00"
                ADRES_H1.Text = ""
                Adres4.Text = ""
                DisplayVoorstad.Text = ""
                DisplayDorp.Text = ""
                poskode.Text = ""
                txtWaardeEkstras.Text = ""
                TotWaardeHE.Text = ""
                txtPremieEkstras.Text = ""
                txtGrootTotaal.Text = ""
                txtPremieNaKortingHE.Text = ""
                HE_Premie.Text = ""
                cmbPropertyType.SelectedIndex = -1
                chkWeerlig.CheckState = CheckState.Unchecked
                Check1.CheckState = CheckState.Unchecked
                chkGrasdakLapa.CheckState = CheckState.Unchecked
                txtOppervlakteHuis.Text = ""
                txtOppervlakteLapa.Text = ""
                txtErfNommer.Text = ""
                chkAlarmReaksie.CheckState = CheckState.Unchecked
                chkVerband.CheckState = CheckState.Unchecked
                _chkSekuriteit_0.CheckState = CheckState.Unchecked
                _chkSekuriteit_1.CheckState = CheckState.Unchecked
                _chkSekuriteit_2.CheckState = CheckState.Unchecked
                _chkSekuriteit_3.CheckState = CheckState.Unchecked
                _chkSekuriteit_4.CheckState = CheckState.Unchecked
                _chkSekuriteit_5.CheckState = CheckState.Unchecked
                _chkSekuriteit_6.CheckState = CheckState.Unchecked
                _chkSekuriteit_7.CheckState = CheckState.Unchecked

                cmbHomeLoanOrg.SelectedIndex = -1
                txtBondNumber.Text = ""

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchHuisInformation4Grid", param)
                conn.Close()
            End Using
        Catch ex As Exception
        End Try

    End Sub
    Sub FetchPerssonByArea()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                param.Value = Persoonl.POLISNO
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlByArea", param)
                Do While reader.Read
                    'Kobus 31/05/2013 change reader("boukoste")
                    'Kobus 12/09/2013 verander van
                    'Me.txtBoukoste.Text = FormatNumber(reader("boukoste"), 0)
                    Me.txtBoukoste.Text = Format(Val(reader("boukoste")), "########")
                Loop
                conn.Close()
            End Using
        Catch ex As Exception
        End Try
    End Sub
    ' populate the grid with information
    'Kobus Visser 14/03/2013 change Function to Public Sub
    'Public Function PopulateGridGeysers() As Object
    Public Sub PopulateGridGeysers()

        If pkHuis <> 0 Then
            GridGeisers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            GridGeisers.AutoGenerateColumns = False
            GridGeisers.DataSource = FetchGeyserTypeWithGrid()
            GridGeisers.Refresh()
        Else
            GridGeisers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            GridGeisers.AutoGenerateColumns = False
            GridGeisers.DataSource = FetchGeyserType1()
            GridGeisers.Refresh()

        End If
        'GridGeisers.Refresh()

    End Sub
    Public Function FetchGeyserTypeWithGrid() As List(Of GeyserEntity)
        Dim list As List(Of GeyserEntity) = New List(Of GeyserEntity)
        Try
            'Check language for display in list

            Using conn As SqlConnection = SqlHelper.GetConnection
                'Kobus 19/09/2013 voegby
                If blnNewWithGeyser = True Then
                    pkHuis = pkHuis
                    blnediting = True
                Else
                    ' Andriette Grid veranderinge
                    pkHuis = Form1.dgvPoldata1Eiendomme.SelectedRows(0).Cells(13).Value     'Kobus Visser 04/03/2013 restore
                    'pkHuis = Form1.Grid2.SelectedRows(0).Cells(21).Value
                End If
                Dim param As New SqlParameter("@pkHuis", SqlDbType.Int)

                If blnediting Then
                    GridGeisers.DataSource = Nothing
                    GridGeisers.Refresh()
                    param.Value = pkHuis
                End If
                ' param.Value = pkHuis
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchGeyserTypeWithGrid", param)

                While reader.Read
                    Dim item As GeyserEntity = New GeyserEntity()
                    If reader("pkGeysers") IsNot DBNull.Value Then
                        item.pkGeysers = reader("pkGeysers")
                    End If
                    If reader("Geyser Tipe") IsNot DBNull.Value Then
                        item.GeyserTipe = reader("Geyser Tipe")
                    End If
                    If reader("Fabrikaat") IsNot DBNull.Value Then
                        item.Fabrikaat = reader("Fabrikaat")
                    End If

                    If reader("Model") IsNot DBNull.Value Then
                        item.Model = reader("Model")
                    End If
                    If reader("Liter") IsNot DBNull.Value Then
                        item.Liter = reader("Liter")
                    End If
                    If reader("Waarde R") IsNot DBNull.Value Then
                        item.Waarde = reader("Waarde R")
                    End If
                    If reader("Premie R") IsNot DBNull.Value Then
                        item.Premie = Format(reader("Premie R"), "######0.00")    'Kobus Visser 14/03/2013 change format
                    End If
                    If reader("Aanvang") IsNot DBNull.Value Then
                        item.DatumIn = reader("Aanvang")
                    End If

                    list.Add(item)
                End While
                Return list
                conn.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function
    Public Function FetchGeyserType1() As List(Of GeyserEntity)
        Try
            'Check language for display in list
            Using conn As SqlConnection = SqlHelper.GetConnection
                huis_e = FetchHuis()
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchGeyserType1")
                Dim list As List(Of GeyserEntity) = New List(Of GeyserEntity)
                Do While reader.Read
                    Dim item As GeyserEntity = New GeyserEntity()
                    If reader("Geyser Tipe") IsNot DBNull.Value Then
                        item.pkGeysers = reader("Geyser Tipe")
                    End If
                    If reader("Fabrikaat") IsNot DBNull.Value Then
                        item.Fabrikaat = reader("Fabrikaat")
                    End If

                    If reader("Model") IsNot DBNull.Value Then
                        item.Model = reader("Model")
                    End If
                    If reader("Liter") IsNot DBNull.Value Then
                        item.Liter = reader("Liter")
                    End If
                    If reader("Waarde R") IsNot DBNull.Value Then
                        item.Waarde = reader("Waarde R")
                    End If
                    If reader("Premie R") IsNot DBNull.Value Then
                        item.Premie = Format(reader("Premie R"), "######0.00")    'Kobus Visser 14/03/2013 change format
                    End If
                    If reader("Aanvang") IsNot DBNull.Value Then
                        item.DatumIn = reader("Aanvang")
                    End If

                    list.Add(item)
                Loop
                Return list
                conn.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function
    Private Sub HE_Premie_Leave(sender As Object, e As System.EventArgs) Handles HE_Premie.Leave
        If HE_Premie.Text = "" Then
            HE_Premie.Text = "0.00"
        End If
    End Sub
    Private Sub HE_PREMIE_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HE_Premie.TextChanged
        blnInformationChanged = True
        calcGrandTotal()
    End Sub
    Private Sub HE_PREMIE_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HE_Premie.Enter
        Me.HE_Premie.SelectionStart = 0
        Me.HE_Premie.SelectionLength = Len(Me.HE_Premie.Text)
        'Kobus 29/04/2014 voegby
        Me.HE_Premie.SelectAll()
    End Sub
    Private Sub HE_WAARDE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles HE_WAARDE.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar)) Then
                'do nothing
            Else
                e.Handled = True
                MsgBox("Value: Must be numeric", _
                       MsgBoxStyle.Information, "Verify")
                HE_WAARDE.Focus()
            End If
        End If
    End Sub
    Private Sub HE_WAARDE_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HE_WAARDE.TextChanged
        blnInformationChanged = True

    End Sub
    'txtPremieEkstras
    'Calculate the total value of the vehicle (vehicle + extras)
    Public Sub calcTotValue()
        'Kobus 31/05/2013 change + Val(Me.HE_WAARDE.Text), 2)
        Me.TotWaardeHE.Text = CStr(System.Math.Round(Val(Me.txtWaardeEkstras.Text) + FormatNumber(Me.HE_WAARDE.Text), 0))
        Me.TotWaardeHB.Text = CStr(System.Math.Round(Val(Me.WAARDE_HB.Text), 2))

    End Sub
    Private Sub HE_WAARDE_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HE_WAARDE.Enter
        Me.HE_WAARDE.SelectionStart = 0
        Me.HE_WAARDE.SelectionLength = Len(Me.HE_WAARDE.Text)
        'Kobus 28/10/2013 voegby
        dblHEWaarde = Val(HE_WAARDE.Text)
        'Kobus 29/04/2014 voegby
        Me.HE_WAARDE.SelectAll()
    End Sub
    Private Sub huisposbestemming_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles huisposbestemming.CheckStateChanged
        blnInformationChanged = True
    End Sub
    Private Sub poskode_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles poskode.TextChanged
        blnInformationChanged = True
        Me.poskode.Text = (Me.poskode.Text)
    End Sub
    Private Sub poskode_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles poskode.Enter
        MsgBox("Please use the list of National postal a postal code to select. ", MsgBoxStyle.Exclamation)
        Me.btnPostalCodes.Focus()
    End Sub
    Private Sub PREMIE_HB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Premie_HB.TextChanged
        blnInformationChanged = True
        calcGrandTotal()
    End Sub
    Private Sub PREMIE_HB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Premie_HB.Enter
        Me.Premie_HB.SelectionStart = 0
        Me.Premie_HB.SelectionLength = Len(Me.Premie_HB.Text)
        'Kobus 13/09/2013 voegby
        Me.Premie_HB.SelectAll()
    End Sub
    Private Sub SSTab1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SSTab1.SelectedIndexChanged
        Static PreviousTab As Short = SSTab1.SelectedIndex()
        'Set focus on control for selected tab
        Select Case SSTab1.SelectedIndex
            Case 0
                Me.cmbPropertyType.Focus()
            Case 1
                Me.Combo1.Focus()
            Case 4
                Me.txtBondNumber.Focus()
            Case 5
                Me.toe_waarde.Focus()
        End Select
        'Kobus 31/10/2013 voeg kondisie by
        If Me.SSTab1.SelectedIndex = 6 Then
        Else
            PreviousTab = SSTab1.SelectedIndex()
        End If

    End Sub
    'Check if the landslide endorsement is linked to the specific policy number
    'BriefBevesting uses this function as well
    Public Function LandslideEndorsementLinked(ByRef policyNumber As String) As Boolean

        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
            param.Value = Persoonl.POLISNO
            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchEndos11", param)
            If reader.Read() Then
                LandslideEndorsementLinked = False
            Else
                LandslideEndorsementLinked = True
            End If
            conn.Close()
        End Using
        Return Nothing
        Exit Function
    End Function
    'Get the specified endorsement memo field
    'BriefBevestig uses this function as well
    Public Function getLandslideEndorsement(ByRef endorsementId As String) As String
        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim param As New SqlParameter("@Endosdetidentifikasie", SqlDbType.NVarChar)
            param.Value = endorsementId
            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "endos5.FetchEndosDetails", param)
            If reader.Read() Then
                getLandslideEndorsement = ""
            Else
                getLandslideEndorsement = reader("Endosdetmemo")
            End If
            conn.Close()
        End Using
        Return Nothing
        Exit Function
    End Function
    Sub FetchHomeloanOrgByName(ByVal NameAfr As String, ByVal pkHomeLoanOrg As Integer)
        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim param() As SqlParameter = {New SqlParameter("@NameAfr", SqlDbType.NVarChar), _
                                           New SqlParameter("@pkHomeLoanOrg", SqlDbType.Int)}

            param(0).Value = NameAfr
            param(1).Value = pkHomeLoanOrg
            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchHomeloanOrg", param)
            Do While Not reader.Read

                cmbHomeLoanOrg.Items.Add((reader("nameAfr")))
                ' VB6.SetItemData(cmbHomeLoanOrg, k, reader("pkHomeLoanOrg").value)
            Loop
            conn.Close()
        End Using
    End Sub
    'Populate the combo boxes with values
    Public Sub populateComboBoxes()
        Combo1.Items.Clear()
        If Persoonl.TAAL = 0 Then
            Combo1.Items.Add("Standaard")
            Combo1.Items.Add("Hout")
            Combo1.Items.Add("Nie standaard")
            Combo1.Items.Add("Strand Huis")
            Combo1.Items.Add("Asbes Huis")
        Else
            Combo1.Items.Add("Standard")
            Combo1.Items.Add("Wood")
            Combo1.Items.Add("Not standard")
            Combo1.Items.Add("Beach House")
            Combo1.Items.Add("Asbestos")
        End If

        Combo2.Items.Clear()
        If Persoonl.TAAL = 0 Then
            Combo2.Items.Add("Teël staandak")
            Combo2.Items.Add("Sink staandak")
            Combo2.Items.Add("Sink platdak")
            Combo2.Items.Add("Asbes staandak")
            Combo2.Items.Add("Asbes platdak")
            Combo2.Items.Add("Gras staandak")
            Combo2.Items.Add("Ander staandak")
            Combo2.Items.Add("Ander platdak")
        Else
            Combo2.Items.Add("Pitched tiled roof")
            Combo2.Items.Add("Pitched corrugated iron roof")
            Combo2.Items.Add("Corrugated iron flat roof")
            Combo2.Items.Add("Pitch asbestos roof")
            Combo2.Items.Add("Asbestos flat roof")
            Combo2.Items.Add("Pitched grass roof")
            Combo2.Items.Add("Other pitched roof")
            Combo2.Items.Add("Other flat roof")
        End If

        'alarm kommunikasie
        A_komm.Items.Clear()
        If Persoonl.TAAL = 0 Then
            A_komm.Items.Add(" ")
            A_komm.Items.Add("Radio")
            A_komm.Items.Add("Telefoon")
            'Kobus Visser 28/02/2013 add Elektronies (SMS, Email etc)
            A_komm.Items.Add("Elektronies")
        Else
            'Kobus Visser 28/02/2013 add " "
            A_komm.Items.Add(" ")
            A_komm.Items.Add("Radio")
            A_komm.Items.Add("Telephone")
            'Kobus Visser 28/02/2013 add Electronically (SMS, Email etc)
            A_komm.Items.Add("Electronically")
        End If
        'goedgekeur deur Mooirivier Makelaars
        A_goedgekeur.Items.Clear()
        If Persoonl.TAAL = 0 Then
            A_goedgekeur.Items.Add(" ")
            A_goedgekeur.Items.Add("J")
            A_goedgekeur.Items.Add("N")
        Else
            'Kobus Visser 28/02/2013 add " "
            A_goedgekeur.Items.Add(" ")
            A_goedgekeur.Items.Add("Y")
            A_goedgekeur.Items.Add("N")
        End If

        k = 0

        Try
            ' cmbPropertyType.Items.Clear()    ' Kobus Visser 27/03/2013
            'Kobus 23/04/2013 change combobox procedure
            If Persoonl.TAAL = 0 Then
                cmbPropertyType.DataSource = FillCombo("poldata5.FetchPropertyType", "pkPropertyType", "ShortDescAfr", "", "")
            Else
                cmbPropertyType.DataSource = FillCombo("poldata5.FetchPropertyType", "pkPropertyType", "ShortDescEng", "", "")
            End If
            cmbPropertyType.DisplayMember = "ComboBoxName"
            
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        'Linkie 28/03/2013 - kan nie sien hoekom hierdie hier nodig is nie - populate klaar die propertytype hierbo
        'Linkie 28/03/2013If editing Then
        'Linkie 28/03/2013PropertyType = FetchPropertyType()
        'Set the currently selected item from database
        'Linkie 28/03/2013If PropertyType.Nomatch Then
        'Linkie 28/03/2013If huis_e.fkPropertyType = PropertyType.pkPropertyType Then
        'cmbPropertyType.Text = GetItemString(cmbPropertyType, k)
        'Linkie 28/03/2013End If
        'Linkie 28/03/2013End If
        'Linkie 28/03/2013End If

        'rsPropertyType.MoveNext()
        k = k + 1
        'Loop

        'Linkie 28/03/2013currentPtyTypeIndex = cmbPropertyType.SelectedIndex
        'Linkie 28/03/2013 - comboboxes het nie regte data teruggebring nie (indexe)
        ' Me.cmbHomeLoanOrg.Items.Clear()
        'Kobus 23/04/2013 change combobox procedure
        If Persoonl.TAAL = 0 Then
            cmbHomeLoanOrg.DataSource = FillCombo("poldata5.FetchHomeloanOrg", "pkHomeloanOrg", "nameAfr", "", "")
        Else
            cmbHomeLoanOrg.DataSource = FillCombo("poldata5.FetchHomeloanOrg", "pkHomeloanOrg", "nameEng", "", "")
        End If
        cmbHomeLoanOrg.DisplayMember = "ComboBoxName"

        
        k = 1
        'Me.cmbHomeLoanOrg.Items.Clear()

        If blnediting Then

            ' rsHomeloanOrg.MoveNext()
            k = k + 1
        End If
    End Sub
    'Validate the form
    Public Function validateForm() As Boolean
        Dim strTmpPolicy As String
        Dim blnUnique As Boolean
        strTmpPolicy = ""
        blnUnique = False
        'Kobus 09/06/2014 voegby
        blnValidationOK = False
        'Kobus verander van huis_e = FetchHuis()
        'Kobus 11/10/2013 add condition
        If blnediting Then
            huis_e = GetHuisByPrimaryKey(pkHuis)
        End If
        'Adres
        If Trim(ADRES_H1.Text) = "" Then
            MsgBox("Please enter an address for the property.", MsgBoxStyle.Exclamation)
            ADRES_H1.Focus()
            validateForm = False
            Exit Function
        End If

       
        'kobus Visser 05/04/2013 change message from: "The suburb, town / village and postal code must be entered. " & Chr(13) & " Please use the list of National postal codes to select it."
        'Voorstad, dorp, poskode
        If Trim(DisplayVoorstad.Text) = "" Or Trim(DisplayDorp.Text) = "" Or Trim(poskode.Text) = "" Then
            MsgBox("The suburb/town and postal code must be entered. " & Chr(13) & " Please use the postal code list to select it.", MsgBoxStyle.Exclamation)
            btnPostalCodes_Click(btnPostalCodes, New System.EventArgs())
            validateForm = False
            Exit Function
        End If

        'The houseowners and housekeeper values can't both be zero
        If Me.HE_Premie.Text = "" Then
            Me.HE_Premie.Text = "0.00"
        End If
        'Kobus 02/10/2013 verander van  MsgBox("The landlord and tenant house values ​​can not both be 0.", MsgBoxStyle.Exclamation) na
        If Me.WAARDE_HB.Text = "0" And CDbl(Me.HE_WAARDE.Text) = "0" And Me.Premie_HB.Text = "0.00" And Me.HE_Premie.Text = "0.00" Then
            MsgBox("The homeowner and household contents values can not both be zero.", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 1
            WAARDE_HB.Focus()
            validateForm = False
            Exit Function
        End If
        'Kobus 02/10/2013 verander van  MsgBox("The landlord and tenant house values ​​can not both be 0.", MsgBoxStyle.Exclamation) na
        If Me.WAARDE_HB.Text = "0" And CDbl(Me.HE_WAARDE.Text) <> "0" And Me.Premie_HB.Text <> "0.00" And Me.HE_Premie.Text = "0.00" Then
            MsgBox("The Household contents value and Homeowner premium must both be captured.", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 1
            WAARDE_HB.Focus()
            validateForm = False
            Exit Function
        End If


        'Houshold contents not zero rest is zero
        'Kobus 02/10/2013 voegby
        If Me.WAARDE_HB.Text <> "0" And CDbl(Me.HE_WAARDE.Text) = "0" And Me.Premie_HB.Text = "0.00" And Me.HE_Premie.Text = "0.00" Then
            MsgBox("The household contents premium must be captured.", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 1
            'Kobus 20/11/2013 comment out
            'Me.txtPremieVoorHB.Focus()
            validateForm = False
            Exit Function
        End If

        'Hosehold contents and Homeowner values not zero rest zero
        'Kobus 02/10/2013 voegby
        If Me.WAARDE_HB.Text <> "0" And CDbl(Me.HE_WAARDE.Text) <> "0" And Me.Premie_HB.Text = "0.00" And Me.HE_Premie.Text = "0.00" Then
            MsgBox("The household contents premium and Homeowner premium must both be captured.", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 1
            'Kobus 20/11/2013 comment out
            'Me.txtPremieVoorHB.Focus()
            validateForm = False
            Exit Function
        End If

        'Hosehold contents and Homeowner values not zero rest zero
        'Kobus 02/10/2013 voegby
        If Me.WAARDE_HB.Text <> "0" And CDbl(Me.HE_WAARDE.Text) = "0" And Me.Premie_HB.Text = "0.00" And Me.HE_Premie.Text <> "0.00" Then
            MsgBox("The household contents premium and homeowner value must both be captured.", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 1
            'Kobus 20/11/2013 comment out
            'Me.txtPremieVoorHB.Focus()
            validateForm = False
            Exit Function
        End If

        'Hosehold contents, Homeowner values and Houshold contents premium not zero rest zero
        'Kobus 11/11/2013 voegby
        If Me.WAARDE_HB.Text <> "0" And CDbl(Me.HE_WAARDE.Text) <> "0" And Me.Premie_HB.Text <> "0.00" And Me.HE_Premie.Text = "0.00" Then
            MsgBox("The Homeowner premium must be captured.", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 1
            'Kobus 20/11/2013 comment out
            'Me.txtPremieVoorHE.Focus()
            validateForm = False
            Exit Function
        End If

        'Kobus 02/11/2013 voegby
        If Me.WAARDE_HB.Text <> "0" And CDbl(Me.HE_WAARDE.Text) <> "0" And Me.Premie_HB.Text = "0.00" And Me.HE_Premie.Text <> "0.00" And blnNewWithGeyser <> True Then
            MsgBox("Household contents premium must be captured.", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 1
            'Kobus 20/11/2013 comment out
            'Me.txtPremieVoorHB.Focus()
            validateForm = False
            Exit Function
        End If

        'Kobus 02/10/2013 voegby
        If Me.WAARDE_HB.Text = "0" And CDbl(Me.HE_WAARDE.Text) <> "0" And Me.Premie_HB.Text = "0.00" And Me.HE_Premie.Text = "0.00" Then
            MsgBox("Homeowner premium must be captured.", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 1
            'Kobus 20/11/2013 comment out
            'Me.HE_Premie.Focus()
            validateForm = False
            Exit Function
        End If

        'Kobus 02/10/2013 voegby
        If Me.WAARDE_HB.Text = "0" And CDbl(Me.HE_WAARDE.Text) = "0" And Me.Premie_HB.Text = "0.00" And Me.HE_Premie.Text <> "0.00" Then
            MsgBox("Homeowner value must be captured.", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 1
            Me.HE_WAARDE.Focus()
            validateForm = False
            Exit Function
        End If
        'Kobus 08/10/2013 voegby
        If Me.WAARDE_HB.Text = "0" And CDbl(Me.HE_WAARDE.Text) = "0" And Me.Premie_HB.Text <> "0.00" And Me.HE_Premie.Text = "0.00" Then
            MsgBox("Thw household contents value must be captured.", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 1
            Me.WAARDE_HB.Focus()
            validateForm = False
            Exit Function
        End If

        'Kobus 02/10/2013 voegby
        If Me.WAARDE_HB.Text = "0" And CDbl(Me.HE_WAARDE.Text) = "0" And Me.Premie_HB.Text <> "0.00" And Me.HE_Premie.Text <> "0.00" Then
            MsgBox("Household contents and Homeowner values must both be captured.", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 1
            Me.WAARDE_HB.Focus()
            validateForm = False
            Exit Function
        End If

        'Kobus 02/10/2013 voegby
        If Me.WAARDE_HB.Text <> "0" And CDbl(Me.HE_WAARDE.Text) = "0" And Me.Premie_HB.Text <> "0.00" And Me.HE_Premie.Text <> "0.00" Then
            MsgBox("Homeowner value must be captured.", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 1
            Me.HE_WAARDE.Focus()
            validateForm = False
            Exit Function
        End If

        'The houseowners and housekeeper premiums can't both be zero
        'Kobus 02/10/2013 verander van If CDbl(Me.Premie_HB.Text) = "0.00" And CDbl(Me.HE_Premie.Text) = "0.00" Then
        If Me.Premie_HB.Text = "0.00" And Me.HE_Premie.Text = "" Then
            MsgBox("The household contents and Homeowner premiums can not both be zero.", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 1
            Me.txtPremieVoorHE.Focus()
            validateForm = False
            Exit Function
        End If

        
        If blnediting Then


            If ((huis_e.WAARDE_HE <> 0 And CDbl(HE_WAARDE.Text) = 0) Or (huis_e.PREMIE_HE <> 0 And CDbl(HE_Premie.Text) = 0)) And huis_e.Verband Then
                If Not gen_WarningsOnCancelorRemove(Persoonl.POLISNO, enumCheckType.ItemRemoved, enumItemType.enum_Property, huis_e.pkHuis) Then
                    validateForm = False
                    Exit Function
                End If
            End If
        End If

        
        'PremiePersentasieHB
        If Trim(Me.txtPremiePersentasieHB.Text) <> "" Then
            If Not IsNumeric(Me.txtPremiePersentasieHB.Text) Then
                MsgBox("The discount / loading rate must be numeric.", MsgBoxStyle.Exclamation)
                Me.SSTab1.SelectedIndex = 1
                Me.txtPremiePersentasieHB.Focus()
                validateForm = False
                Exit Function
            End If
        End If

        'PremiePersentasieHE
        If Trim(Me.txtPremiePersentasieHE.Text) <> "" Then
            If Not IsNumeric(Me.txtPremiePersentasieHE.Text) Then
                MsgBox("The discount / loading rate must be numerically.", MsgBoxStyle.Exclamation)
                Me.SSTab1.SelectedIndex = 1
                Me.txtPremiePersentasieHE.Focus()
                validateForm = False
                Exit Function
            End If
        End If

        
        'Kobus 16/04/2013 add test
        If Me.toe_waarde.Text <> 0 And Me.toe_premie.Text = 0 Then
            MsgBox("The accidental damage premium is required.", MsgBoxStyle.Exclamation)
            validateForm = False
            Me.SSTab1.SelectedIndex = 5
            Me.toe_premie.Focus()
            Exit Function
        End If

        
        'Kobus 16/04/2013 add test
        If Me.toe_waarde.Text = 0 And Me.toe_premie.Text > 0 Then
            MsgBox("The accidental damage value is required.", MsgBoxStyle.Exclamation)
            validateForm = False
            Me.SSTab1.SelectedIndex = 5
            Me.toe_waarde.Focus()
            Exit Function
        End If


        
        'Kobus 30/04/2013 add condition
        If Me.eem_waarde.Text > 0 And Me.eem_premie.Text = 0 Then
            MsgBox("The accidental damage (EEM) premium is required.", MsgBoxStyle.Exclamation)
            validateForm = False
            Me.SSTab1.SelectedIndex = 5
            Me.eem_premie.Focus()
            Exit Function
        End If

       
        'Kobus 30/04/2013 add if condition
        'Kobus 13/09/2013 verwyder een 'the' in die boodskap
        If Me.eem_waarde.Text = 0 And Me.eem_premie.Text > 0 Then
            MsgBox("The accidental damage value (EEM) is required.", MsgBoxStyle.Exclamation)
            validateForm = False
            Me.SSTab1.SelectedIndex = 5
            Me.eem_waarde.Focus()
            Exit Function
        End If

        'Struktuur
        If Combo1.SelectedIndex = -1 Then
            MsgBox("The structure must be entered.", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 2
            Combo1.Focus()
            validateForm = False
            Exit Function
        End If

        'Tipedak
        If Combo2.SelectedIndex = -1 Then
            MsgBox("The type of roof should be completed. ", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 2
            Combo2.Focus()
            validateForm = False
            Exit Function
        End If

        'Alarm gemonitor as goedgekeur Ja
        If A_goedgekeur.Text = "J" And Len(A_monitor.Text) = 0 Then
            MsgBox("Alarm monitoring should be completed by.", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 3
            A_monitor.Focus()
            validateForm = False
            Exit Function
        End If

        'Only one property per policy may be set as 'posbestemming'
        If Me.huisposbestemming.CheckState Then
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim param() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar)}
                'Kobus 04/10/2013 deaktiveer param(1)                                              
                'New SqlParameter("@ADRES_H1", SqlDbType.NVarChar)}
                'Kobus 29/08/2013 Form1.POLISNO.Text met glbpolicynumber
                param(0).Value = glbPolicyNumber
                'param(1).Value = Replace(Trim(Form1.Grid2.Text), "'", "''")

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchHuisInformation", param)

                If reader.Read Then
                    Dim strCurrentAddress As String
                    strCurrentAddress = Trim(reader("ADRES_H1"))
                    intpkHuisPoshiernatoe = reader("pkHuis")
                    If strCurrentAddress = Me.ADRES_H1.Text Then
                        'do nothing
                    Else
                        If MsgBox("Only one property can be marked as preferred mail destination. " & Chr(13) & " The current address is (" & strCurrentAddress & ") Do you want to change it to the new address: (" & Me.ADRES_H1.Text & ")?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            Me.huisposbestemming.CheckState = CheckState.Checked
                            UpdateHuisPosHiernatoe()
                            Me.SSTab1.SelectedIndex = 1
                            validateForm = False
                            Exit Function
                        Else
                            Me.huisposbestemming.CheckState = CheckState.Unchecked
                            Me.SSTab1.SelectedIndex = 1
                            validateForm = False
                            Exit Function
                        End If
                    End If
                Else
                    Me.huisposbestemming.CheckState = CheckState.Checked
                    validateForm = True
                End If
                conn.Close()
            End Using
        End If

        'When alarm is selected as security the alarm detail on Sekuriteit should be compulsory
        If Me.chkSekuriteit(2).CheckState Then
            'Alarm monitor
            If Trim(Me.A_monitor.Text) = "" Then
                'Kobus 28/11/2013 verander van  MsgBox("Since Alarm is selected as security must be monitored by whom it is entered.", MsgBoxStyle.Exclamation)
                MsgBox("Since 'Alarm' is selected as security, the 'Alarm monitored by' must be completed.", MsgBoxStyle.Exclamation)
                Me.SSTab1.SelectedIndex = 3
                Me.A_monitor.Focus()
                validateForm = False
                Exit Function
            End If

            'Alarm kommunikasie
            If Me.A_komm.SelectedIndex = -1 Or Me.A_komm.SelectedIndex = 0 Then
                'Kobus Visser 25/03/2013 chancge from: Since 'Alarm' is selected as security, the alarm communication, form.
                MsgBox("Since 'Alarm' is selected as security, the alarm communication must be completed.", MsgBoxStyle.Exclamation)
                Me.A_komm.Focus()
                Me.SSTab1.SelectedIndex = 3
                validateForm = False
                Exit Function
            End If

            'Alarm goedgekeur
            'Kobus 28/11/2013 verander van  MsgBox("Since 'Alarm' is selected as security must be approved or completed. ", MsgBoxStyle.Exclamation)
            If Me.A_goedgekeur.SelectedIndex = -1 Or Me.A_goedgekeur.SelectedIndex = 0 Then
                MsgBox("Since 'Alarm' is selected as security, 'Is the alarm approved' must be completed. ", MsgBoxStyle.Exclamation)
                Me.A_goedgekeur.Focus()
                Me.SSTab1.SelectedIndex = 3
                validateForm = False
                Exit Function
            End If
        End If

        'Property type
        If Me.cmbPropertyType.SelectedIndex = -1 Then
            MsgBox("The property type must be entered.", MsgBoxStyle.Exclamation)
            Me.SSTab1.SelectedIndex = 0
            validateForm = False
            cmbPropertyType.Focus()
            Exit Function
        End If

        'Kobus 17/04/2013 add 'Not editing' condition
        If Not blnediting Then
            If Me.chkVerband.CheckState And Me.cmbHomeLoanOrg.SelectedIndex = -1 Then
                'Kobus 17/04/2013 change message from: "The Loan institution is still outstanding, but can be completed later."
                MsgBox("Please select a loan institution.", MsgBoxStyle.Exclamation)
                validateForm = False

                Me.SSTab1.SelectedIndex = 4
                Me.txtBondNumber.Focus()
                Exit Function
            End If
            
        Else
            If Me.chkVerband.CheckState And Me.cmbHomeLoanOrg.SelectedIndex = -1 Then
                'Kobus 03/05/2013 change message from mortgage institution to loan institution
                MsgBox("Please select a loan institution.", MsgBoxStyle.Exclamation)
                validateForm = False
                blnInformationChanged = True
                Me.SSTab1.SelectedIndex = 4
                Me.txtBondNumber.Focus()
                'Kobus 10/06/2014 voegby
                Return False
                Exit Function
            End If
            
        End If
        'Kobus 11/10/2013 voeg by
        validateForm = True

        'Kobus 31/10/2013 voegby om by nuwe geisers te hanteer
        blnRepeatGeyser = True
        'Kobus 09/06/2014 voegby
        blnValidationOK = True
    End Function
    'Kobus 23/10/2013 skep funksie om tabel poldate5.HUIS te toets of huidige adres reeds bestaan
    Private Sub huis_CheckUniqueAddressAll(ByRef strAddress As String)
        If blnNoRepeat = False Or pkHuis = 0 Then
            Dim strPolicyNumbers As String = ""
            Try
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim param() As SqlParameter = {New SqlParameter("@adres_h1", SqlDbType.NVarChar)}
                    param(0).Value = strAddress

                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchHuisByADRES_H1]", param)
                    If reader.HasRows Then
                        While reader.Read
                            If reader("polisno") IsNot DBNull.Value Then
                                strPolicyNumbers = strPolicyNumbers + reader("polisno") + ", "
                            End If
                        End While

                    End If
                    If strPolicyNumbers.Length > 0 Then
                        strPolicyNumbers = strPolicyNumbers.Substring(0, strPolicyNumbers.Length - 2)
                        MsgBox("This address already exists at the following policy number(s): " & strPolicyNumbers, MsgBoxStyle.Exclamation)
                    End If
                    conn.Close()
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            blnNoRepeat = False
        End If
    End Sub
    'Log the alterations made (wysigings)
    Public Sub logAlterations()
        'Kobus 31/03/2014 voegby 
        If blnPol_Byvoeg Or blnByvoeg Then
            'Don't log alterations if a new policy
        Else
            'if new property is added - only log property added
            If Me.chkVerband.CheckState = CheckState.Unchecked And Me.cmbHomeLoanOrg.SelectedIndex = 0 Then
                Me.cmbHomeLoanOrg.Enabled = True
                Me.cmbHomeLoanOrg.Text = ""
                Me.cmbHomeLoanOrg.Enabled = False
                Me.cmbHomeLoanOrg.SelectedIndex = -1
            End If
            'Kobus 03/04/2014 verander van If Not editing Then
            If pkHuis = 0 Then
                BESKRYWING = (ADRES_H1).Text & " " & Adres4.Text
                UpdateWysig((16), BESKRYWING)
                Exit Sub
            End If

            'fkPropertyType
            'Get the description for the propertyType
            getPropertyTypeDesc((huis_e.fkPropertyType), oldTypeAfr, oldTypeEng)

            If cmbPropertyType.SelectedIndex <> -1 Then
                
                If Persoonl.TAAL = 0 Then
                    If oldTypeAfr <> cmbPropertyType.Text Then
                        'BESKRYWING = " wysig die tipe eiendom vanaf (" & Trim(oldTypeAfr) & ") na (" & Trim(cmbPropertyType.SelectedItem.comboboxnaam) & ") op (" & (ADRES_H1).Text & ")"
                        BESKRYWING = " wysig die tipe eiendom vanaf (" & Trim(oldTypeAfr) & ") na (" & Trim(cmbPropertyType.Text) & ") op (" & (ADRES_H1).Text & ")"
                        UpdateWysig((165), BESKRYWING)
                    End If
                Else
                    If oldTypeEng <> cmbPropertyType.Text Then
                        BESKRYWING = " change the type of property from (" & Trim(oldTypeEng) & ") to (" & Trim(cmbPropertyType.Text) & ") on (" & (ADRES_H1).Text & ")"
                        UpdateWysig((165), BESKRYWING)
                    End If

                End If
            End If

            ''HomeLoanOrganization
            'Kobus 08/10/2013 comment alles uit en begin voor
            getHomeloanOrgDesc((huis_e.fkHomeLoanOrg), oldBondAfr, oldBondEng)
            'Kobus 09/10/2013 verander van If cmbHomeLoanOrg.SelectedIndex <> -1 Then
            If Persoonl.TAAL = 0 And oldBondAfr <> Trim(cmbHomeLoanOrg.Text) Then
                BESKRYWING = " wysig verbandhouer vanaf (" & Trim(oldBondAfr) & ") na (" & Trim(cmbHomeLoanOrg.Text) & ") op (" & (ADRES_H1).Text & ")"
                UpdateWysig((165), BESKRYWING)
            Else
                If Persoonl.TAAL = 1 And oldBondEng <> cmbHomeLoanOrg.Text Then
                    BESKRYWING = " change bondholder from (" & Trim(oldBondEng) & ") to (" & Trim(cmbHomeLoanOrg.Text) & ") on (" & (ADRES_H1).Text & ")"
                    UpdateWysig((165), BESKRYWING)
                End If
            End If

            
            If Me.txtBondNumber.Text <> huis_e.bondNumber Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig Verband rek.no. vanaf (" & Trim(huis_e.bondNumber) & ") na (" & Trim(Me.txtBondNumber.Text) & ") op (" & (ADRES_H1).Text & ")"
                Else
                    BESKRYWING = " change Bond acc. num. from (" & Trim(huis_e.bondNumber) & ") to (" & Trim(Me.txtBondNumber.Text) & ") on (" & (ADRES_H1).Text & ")"
                End If
                UpdateWysig((165), BESKRYWING)
            End If

            'Mainproperty
            If Me.Check1.CheckState <> huis_e.mainproperty Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig Hoofeiendom vanaf (" & huis_e.mainproperty & ") na (" & Me.Check1.CheckState & ") op " & Me.ADRES_H1.Text
                Else
                    BESKRYWING = " change Mainproperty from (" & huis_e.mainproperty & ") to (" & Me.Check1.CheckState & ") on " & Me.ADRES_H1.Text
                End If
                UpdateWysig((165), BESKRYWING)
            End If

            'Adres
            If Trim(huis_e.ADRES_H1) <> Trim(Me.ADRES_H1.Text) Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & Trim(huis_e.ADRES_H1) & ") na (" & Trim(Me.ADRES_H1.Text) & ")"
                Else
                    BESKRYWING = " change from (" & Trim(huis_e.ADRES_H1) & ") to (" & Trim(Me.ADRES_H1.Text) & ")"
                End If
                UpdateWysig((115), BESKRYWING)
            End If

            'Address line 2
            If Trim(huis_e.Adres4) <> Trim(Me.Adres4.Text) Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " lyn 2 wysig vanaf (" & Trim(huis_e.Adres4) & ") na (" & Trim(Me.Adres4.Text) & ")"
                Else
                    BESKRYWING = " line 2 change from (" & Trim(huis_e.Adres4) & ") to (" & Trim(Me.Adres4.Text) & ")"
                End If
                UpdateWysig((115), BESKRYWING)
            End If

            'Poskode
            If Trim(huis_e.poskode) <> Trim(Me.poskode.Text) Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & Trim(huis_e.poskode) & ") na (" & Trim(Me.poskode.Text) & ") op (" & (ADRES_H1).Text & ")"
                Else
                    BESKRYWING = " change from (" & Trim(huis_e.poskode) & ") to (" & Trim(Me.poskode.Text) & ") on (" & (ADRES_H1).Text & ")"
                End If
                UpdateWysig((114), BESKRYWING)
            End If

            'Daktipe
            'Kobus 26/09/2013 verander van If huis_e.TIPE_DAK <> Combo2.Text Then
            If huis_e.TIPE_DAK <> Combo2.SelectedIndex + 1 Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig na (" & (Combo2.Text) & ") op (" & (ADRES_H1).Text & ")"
                Else
                    BESKRYWING = " change to (" & (Combo2.Text) & ") on (" & (ADRES_H1).Text & ")"
                End If
                UpdateWysig((10), BESKRYWING)
            End If

            ' Struktuur()
            'Kobus 26/09/2013 verander van If huis_e.STRUKTUUR <> Combo1.Text Then
            If huis_e.STRUKTUUR <> Combo1.SelectedIndex + 1 Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig na (" & (Combo1.Text) & ") op (" & (ADRES_H1).Text & ")"
                Else
                    BESKRYWING = " change to (" & (Combo1.Text) & ") on (" & (ADRES_H1).Text & ")"
                End If
                UpdateWysig((15), BESKRYWING)
            End If

            ''Sekuriteit
            If huis_e.SekuriteitBitValue <> calcSecuritySelectedBitwise() Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig van (" & gen_getPropertySecurity(0, huis_e.SekuriteitBitValue) & ") na (" & gen_getPropertySecurity(0, Me.calcSecuritySelectedBitwise()) & ") op (" & (ADRES_H1).Text & ")"
                Else
                    BESKRYWING = " change to (" & gen_getPropertySecurity(1, huis_e.SekuriteitBitValue) & ") on (" & (ADRES_H1).Text & ")"
                End If
                UpdateWysig((121), BESKRYWING)
            End If

            ' Huiseinaar(waarde)
            'Kobus 08/10/2013 verander huis_e.WAARDE_HE na huis_e.WAARDEHE
            If huis_e.WAARDE_HE <> TotWaardeHE.Text Then
                If Persoonl.TAAL = 0 Then
                    'Kobus 08/10/2013 verander HE_WAARDE.Text na TotwaardeHE.Text
                    BESKRYWING = " wysig vanaf (" & huis_e.WAARDE_HE & ") na (" & TotWaardeHE.Text & ") op (" & (ADRES_H1).Text & ")"
                Else
                    BESKRYWING = " change from (" & huis_e.WAARDE_HE & ") to (" & TotWaardeHE.Text & ") on (" & (ADRES_H1).Text & ")"
                End If
                UpdateWysig((11), BESKRYWING)
            End If

            'HuisEienaar(premie)
            'kobus 08/10/2013 verander If huis_e.PREMIE_HE <> txtPremieVoorHE Then
            If huis_e.PREMIE_HE <> HE_Premie.Text Then
                If Persoonl.TAAL = 0 Then
                    'Kobus 12/11/2013 verander "########.00" na "########0.00"
                    'kobus 01/10/2013 verander van BESKRYWING = " wysig vanaf (" & huis_e.PREMIE_HE & ") na (" & txtPremieVoorHE.Text & ") op (" & (ADRES_H1).Text & ")"
                    BESKRYWING = " wysig vanaf (" & Format(Val(huis_e.PREMIE_HE), "########0.00") & ") na (" & Format(Val(HE_Premie.Text), "########0.00") & ") op (" & (ADRES_H1).Text & ")"
                Else
                    BESKRYWING = " change from (" & Format(Val(huis_e.PREMIE_HE), "########0.00") & ") to (" & Format(Val(HE_Premie.Text), "########0.00") & ") on (" & (ADRES_H1).Text & ")"
                End If
                UpdateWysig((12), BESKRYWING)
            End If

            'Huisbewoner(waarde)
            If huis_e.WAARDE_HB <> WAARDE_HB.Text Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & huis_e.WAARDE_HB & ") na (" & WAARDE_HB.Text & ") op (" & (ADRES_H1).Text & ")"
                Else
                    BESKRYWING = " changed from (" & huis_e.WAARDE_HB & ") na (" & WAARDE_HB.Text & ") on (" & (ADRES_H1).Text & ")"
                End If
                UpdateWysig((13), BESKRYWING)
            End If

            'HuisBewoner(premie)
            'Kobus 03/10/2013 verander van If huis_e.PREMIE_HB <> txtPremieVoorHB.Text Then
            If huis_e.PREMIE_HB <> Premie_HB.Text Then
                If Persoonl.TAAL = 0 Then
                    'kobus 01/10/2013 verander van BESKRYWING = " wysig vanaf (" & huis_e.PREMIE_HB & ") na (" & txtPremieVoorHB.Text & ") op (" & (ADRES_H1).Text & ")"
                    'Kobus 22/10/2013 wysig van BESKRYWING = " wysig vanaf (" & Format(Val(huis_e.PREMIE_HB), "########0.00") & ") na (" & Format(Val(txtPremieVoorHB.Text), "########0.00") & ") op (" & (ADRES_H1).Text & ")"
                    BESKRYWING = " wysig vanaf (" & Format(Val(huis_e.PREMIE_HB), "########0.00") & ") na (" & Format(Val(Premie_HB.Text), "########0.00") & ") op (" & (ADRES_H1).Text & ")"
                Else
                    BESKRYWING = " change from (" & Format(Val(huis_e.PREMIE_HB), "########0.00") & ") to (" & Format(Val(Premie_HB.Text), "########0.00") & ") on (" & (ADRES_H1).Text & ")"
                End If
                UpdateWysig((14), BESKRYWING)
            End If

            'Toevallige skade premie
            'Kobus 26/09/2013 verander van If huis_e.TOE_PREMIE <> Premie_HB.Text Then
            If huis_e.TOE_PREMIE <> toe_premie.Text Then
                If Persoonl.TAAL = 0 Then
                    'kobus 01/10/2013 verander van Format(huis_e.TOE_PREMIE) & ") na (" & Format(toe_premie.Text) & ") op (" & (ADRES_H1).Text & ")"
                    'BESKRYWING = " wysig vanaf (" & Format(huis_e.TOE_PREMIE) & ") na (" & Format(Premie_HB.Text) & ") op (" & (ADRES_H1).Text & ")"
                    BESKRYWING = " wysig vanaf (" & Format(Val(huis_e.TOE_PREMIE), "########0.00") & ") na (" & Format(Val(toe_premie.Text), "########0.00") & ") op (" & (ADRES_H1).Text & ")"
                Else
                    'BESKRYWING = " change from (" & Format(huis_e.TOE_PREMIE) & ") to (" & Format(Premie_HB.Text) & ") on (" & (ADRES_H1).Text & ")"
                    BESKRYWING = " change from (" & Format(Val(huis_e.TOE_PREMIE), "########0.00") & ") to (" & Format(Val(toe_premie.Text), "########0.00") & ") on (" & (ADRES_H1).Text & ")"
                End If
                UpdateWysig((104), BESKRYWING)
            End If

            'Toevallige skade waarde
            'Kobus 26/09/2013 verander van If huis_e.TOE_WAARDE <> HE_Premie.Text Then
            If huis_e.TOE_WAARDE <> toe_waarde.Text Then
                If Persoonl.TAAL = 0 Then
                    'BESKRYWING = " wysig vanaf ( " & (Format(huis_e.TOE_WAARDE)) & ") na (" & Format(HE_Premie.Text) & ") op (" & (Me.ADRES_H1).Text & ")"
                    BESKRYWING = " wysig vanaf ( " & (Format(huis_e.TOE_WAARDE)) & ") na (" & Format(toe_waarde.Text) & ") op (" & (Me.ADRES_H1).Text & ")"
                Else
                    BESKRYWING = " change from ( " & (Format(huis_e.TOE_WAARDE)) & ") to (" & Format(toe_waarde.Text) & ") on (" & (Me.ADRES_H1).Text & ")"
                End If
                UpdateWysig((105), BESKRYWING)
            End If

            'EEM(waarde)
            If huis_e.EEM_WAARDE <> eem_waarde.Text Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & (Format(huis_e.EEM_WAARDE)) & ") na (" & Format(eem_waarde.Text) & ") op (" & (Me.ADRES_H1).Text & ")"
                Else
                    BESKRYWING = " change from (" & (Format(huis_e.EEM_WAARDE)) & ") to (" & Format(eem_waarde.Text) & ") on (" & (Me.ADRES_H1).Text & ")"
                End If
                UpdateWysig((111), BESKRYWING)
            End If

            'EEM(premie)
            If huis_e.EEM_PREMIE <> eem_premie.Text Then
                If Persoonl.TAAL = 0 Then
                    'Kobus 01/10/2013 verander van (Format(huis_e.EEM_PREMIE)) & ") na (" & Format(eem_premie.Text) & ") op (" & (Me.ADRES_H1).Text & ")"
                    BESKRYWING = " wysig vanaf (" & (Format(Val(huis_e.EEM_PREMIE), "#########0.00")) & ") na (" & Format(Val(eem_premie.Text), "########0.00") & ") op (" & (Me.ADRES_H1).Text & ")"
                Else
                    BESKRYWING = " change from (" & (Format(Val(huis_e.EEM_PREMIE), "#########0.00")) & ") to (" & Format(Val(eem_premie.Text), "########0.00") & ") on (" & (Me.ADRES_H1).Text & ")"
                End If
                UpdateWysig((110), BESKRYWING)
            End If

            'Dorp()
            If huis_e.dorp <> DisplayDorp.Text Then
                'Kobus 25/10/2013 vervang BESKRYWING = " wysig na (" & (huis_e.dorp) & ") op (" & (Me.ADRES_H1).Text & ")"
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig na (" & (DisplayDorp.Text) & ") op (" & (Me.ADRES_H1).Text & ")"
                Else
                    BESKRYWING = " change to (" & (DisplayDorp.Text) & ") on (" & (Me.ADRES_H1).Text & ")"
                End If
                UpdateWysig((161), BESKRYWING)
            End If

            'Voorstad()
            If huis_e.voorstad <> DisplayVoorstad.Text Then
                'Kobus 25/10/2013 vervang BESKRYWING = " wysig na (" & (huis_e.voorstad) & ") op (" & (Me.ADRES_H1).Text & ")"
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig na (" & (DisplayVoorstad.Text) & ") op (" & (Me.ADRES_H1).Text & ")"
                Else
                    BESKRYWING = " change to (" & (DisplayVoorstad.Text) & ") on (" & (Me.ADRES_H1).Text & ")"
                End If
                UpdateWysig((160), BESKRYWING)
            End If

            'Alarm(monitor)
            If Trim(huis_e.A_MONITOR) <> Trim(A_monitor.Text) Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & (huis_e.A_MONITOR) & ") na (" & (A_monitor.Text) & ")"
                Else
                    BESKRYWING = " change from (" & (huis_e.A_MONITOR) & ") to (" & (A_monitor.Text) & ")"
                End If
                UpdateWysig((116), BESKRYWING)
            End If

            'Alarm(reaksie)
            'Kobus 26/09/2013 verander van  If Trim(huis_e.AlarmReaksie) & "" <> Trim(chkAlarmReaksie.Text) Then
            If Trim(huis_e.AlarmReaksie) & "" <> Trim(chkAlarmReaksie.CheckState) Then
                If Persoonl.TAAL = 0 Then
                    If chkAlarmReaksie.Checked = True Then
                        strMessage = "Ja"
                    Else
                        strMessage = "Nee"
                    End If
                    BESKRYWING = " Alarm reaksie wysig na (" & strMessage & ")"
                Else
                    If chkAlarmReaksie.Checked = True Then
                        strMessage = "Yes"
                    Else
                        strMessage = "No"
                    End If
                    BESKRYWING = " Alarm response change to (" & strMessage & ")"
                End If
                UpdateWysig((116), BESKRYWING)
            End If

            'Weerligbeskerming()
            'Kobus 26/09/2013 verander van If huis_e.WeerligBeskerming <> chkWeerlig.Checked = True Then
            If huis_e.WeerligBeskerming <> chkWeerlig.CheckState Then
                If Persoonl.TAAL = 0 Then
                    If chkWeerlig.Checked = True Then
                        strMessage = "Ja"
                    Else
                        strMessage = "Nee"
                    End If
                    BESKRYWING = " wysig na (" & strMessage & ") op (" & (Me.ADRES_H1).Text & ")"
                Else
                    If chkWeerlig.Checked = True Then
                        'If chkWeerlig.Text = 1 Then
                        strMessage = "Yes"
                    Else
                        strMessage = "No"
                    End If
                    BESKRYWING = " change to (" & strMessage & ") on (" & (Me.ADRES_H1).Text & ")"
                End If
                UpdateWysig((174), BESKRYWING)
            End If

            'Premiepersentasie
            If Trim(huis_e.PremiePersentasieHB) <> Trim(txtPremiePersentasieHB.Text) Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " Huisbewoner vanaf (" & (huis_e.PremiePersentasieHB) & ") na (" & (txtPremiePersentasieHB.Text) & ") op " & (Me.ADRES_H1).Text
                Else
                    BESKRYWING = " House contents from (" & (huis_e.PremiePersentasieHB) & ") to (" & (txtPremiePersentasieHB.Text) & ") on " & (Me.ADRES_H1).Text
                End If
                UpdateWysig((176), BESKRYWING)
            End If

            If Trim(huis_e.PremiePersentasieHE) <> Trim(txtPremiePersentasieHE.Text) Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " Huiseienaar vanaf (" & (huis_e.PremiePersentasieHE) & ") na (" & (txtPremiePersentasieHE.Text) & ") op " & (Me.ADRES_H1).Text
                Else
                    BESKRYWING = " House owner from (" & (huis_e.PremiePersentasieHE) & ") to (" & (txtPremiePersentasieHE.Text) & ") on " & (Me.ADRES_H1).Text
                End If
                UpdateWysig((176), BESKRYWING)
            End If

            'Lapa
            'Kobus 26/09/2013 verander van If Trim(huis_e.lapa) & "" <> Trim(chkGrasdakLapa.Checked = True) Then
            If Trim(huis_e.lapa) & "" <> chkGrasdakLapa.CheckState Then
                'Kobus 26/09/2013 voegby
                ' Andriette 15/08/2014 Maak warnings reg
                Dim strLapaA As String = ""
                Dim strLapaB As String = ""
                If huis_e.lapa = 0 And Persoonl.TAAL = 0 Then
                    strLapaA = "Geen lapa aan huis"
                    strLapaB = "Lapa aan huis"
                ElseIf huis_e.lapa = 1 And Persoonl.TAAL = 0 Then
                    strLapaA = "Lapa aan huis"
                    strLapaB = "geen lapa aan huis"
                ElseIf huis_e.lapa = 0 And Persoonl.TAAL = 1 Then
                    strLapaA = "No lapa attached"
                    strLapaB = "Lapa attached"
                ElseIf huis_e.lapa = 1 And Persoonl.TAAL = 1 Then
                    strLapaA = "Lapa attached"
                    strLapaB = "No lapa attached"
                End If
                If Persoonl.TAAL = 0 Then
                    'BESKRYWING = " vanaf (" & (huis_e.lapa & "") & ") na (" & (chkGrasdakLapa.Text & "") & ") op " & (Me.ADRES_H1).Text
                    BESKRYWING = " vanaf (" & (strLapaA & "") & ") na (" & (strLapaB & "") & ") op " & (Me.ADRES_H1).Text
                Else
                    BESKRYWING = " from (" & (huis_e.lapa & "") & ") to (" & (chkGrasdakLapa.Text & "") & ") on " & (Me.ADRES_H1).Text
                End If
                UpdateWysig((180), BESKRYWING)
            End If

            'Oppervlakte
            'Kobus 26/09/2013 verander van If Trim(huis_e.OppervlakteHuis) & "" <> Trim(txtOppervlakteHuis.Text) Then
            If Trim(Val(huis_e.OppervlakteHuis)) <> Trim(Val(txtOppervlakteHuis.Text)) Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " vanaf (" & (huis_e.OppervlakteHuis) & ") m² na (" & (txtOppervlakteHuis.Text) & ") m² op " & (Me.ADRES_H1).Text
                Else
                    BESKRYWING = " from (" & (huis_e.OppervlakteHuis) & ") m² to (" & (txtOppervlakteHuis.Text) & ") m² on " & (Me.ADRES_H1).Text
                End If
                UpdateWysig((181), BESKRYWING)
            End If
            'Kobus 26/09/2013 verander van If Trim(huis_e.OppervlakteLapa) & "" <> Trim(txtOppervlakteLapa.Text) Then
            If Trim(Val(huis_e.OppervlakteLapa)) <> Trim(Val(txtOppervlakteLapa.Text)) Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " vanaf (" & (huis_e.OppervlakteLapa) & ") m² na (" & (txtOppervlakteLapa.Text) & ") m² op " & (Me.ADRES_H1).Text
                Else
                    BESKRYWING = " from (" & (huis_e.OppervlakteLapa) & ") m² to (" & (txtOppervlakteLapa.Text) & ") m² on " & (Me.ADRES_H1).Text
                End If
                UpdateWysig((182), BESKRYWING)
            End If

            'Erfnommer
            If Trim(huis_e.ErfNommer) & "" <> Trim(txtErfNommer.Text) Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = "vanaf (" & (huis_e.ErfNommer) & ") na (" & (txtErfNommer.Text) & ") op " & (Me.ADRES_H1).Text
                Else
                    BESKRYWING = "from (" & (huis_e.ErfNommer) & ") to (" & (txtErfNommer.Text) & ") on " & (Me.ADRES_H1).Text
                End If
                UpdateWysig((188), BESKRYWING)
            End If
        End If

    End Sub
    'Return the specified propertyTypes' description
    Public Sub getPropertyTypeDesc(ByRef pkPropertyType As Integer, ByRef shrtDescAfr As String, ByRef shrtDescEng As String)
        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim param As New SqlParameter("@pkPropertyType", SqlDbType.Int)
            param.Value = pkPropertyTYpe

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPropertyTypeByPrimaryKey", param)
            'Kobus 26/09/2013 haal Do While uit
            'Do While reader.Read
            If pkPropertyType <> 0 Then
                If reader.Read Then
                   
                    oldTypeAfr = reader("ShortDescAfr")
                    oldTypeEng = reader("ShortDescEng")
                Else
                    'Kobus 26/09/2013 comment out en voegby
                    'shrtDescAfr = ""
                    'shrtDescEng = ""
                    oldTypeAfr = ""
                    oldTypeEng = ""
                End If
            Else
                'Kobus 26/09/2013 comment out en voegby
                'shrtDescAfr = ""
                'shrtDescEng = ""
                oldTypeAfr = ""
                oldTypeEng = ""
            End If
            'Loop
            conn.Close()
        End Using

    End Sub
    'Return the specified homeloanorganizations' description
    Public Sub getHomeloanOrgDesc(ByRef pkHomeloanOrg As Integer, ByRef nameAfr As String, ByRef nameEng As String)
        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim param As New SqlParameter("@pkHomeLoanOrg", SqlDbType.NVarChar)
            param.Value = pkHomeloanOrg

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchHomeloanOrgByPrimaryKey", param)
            If pkHomeloanOrg <> 0 Then
                If reader.Read Then
                    oldBondAfr = reader("nameAfr")
                    oldBondEng = reader("nameEng")
                Else
                    oldBondAfr = ""
                    oldBondEng = ""
                End If
            Else
                oldBondAfr = ""
                oldBondEng = ""
            End If
            conn.Close()
        End Using
    End Sub
    'Update the grid on form1
    Public Sub updateGrid()
        Form1.dgvPoldata1Eiendomme.AutoGenerateColumns = False
        Form1.dgvPoldata1Eiendomme.DataSource = Nothing
        Form1.dgvPoldata1Eiendomme.Refresh()
        Form1.populate_dgvPoldata1Eiendomme()
    End Sub
    Private Sub toe_premie_Click(sender As Object, e As System.EventArgs) Handles toe_premie.Click
        Me.toe_premie.SelectAll()
    End Sub
    Private Sub toe_premie_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles toe_premie.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub toe_premie_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles toe_premie.Enter
        Me.toe_premie.SelectionLength = Len(Me.toe_premie.Text)
        Me.toe_premie.SelectAll()
    End Sub
    Private Sub toe_waarde_Click(sender As Object, e As System.EventArgs) Handles toe_waarde.Click
        Me.toe_waarde.SelectAll()
    End Sub
    Private Sub toe_waarde_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles toe_waarde.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar)) Then
                'do nothing
            Else
                e.Handled = True
                MsgBox("Value: Must be a whole numeric value.", _
                       MsgBoxStyle.Information, "Verify")
                Me.SSTab1.SelectedIndex = 5
                Me.toe_waarde.Focus()
                Exit Sub
            End If

        End If
    End Sub
    Private Sub toe_waarde_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles toe_waarde.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub toe_waarde_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles toe_waarde.Enter
        Me.toe_waarde.SelectAll()
        Me.toe_waarde.SelectionLength = Len(Me.toe_waarde.Text)
    End Sub
    Private Sub txtBondNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBondNumber.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar)) Then
                'do nothing
            Else
                e.Handled = True
                MsgBox("Bond number: only numbers are allowed", _
                       MsgBoxStyle.Information, "Verify")
                txtBondNumber.Focus()
            End If
        End If
    End Sub
    Private Sub txtBondNumber_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBondNumber.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub txtBoukoste_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBoukoste.TextChanged
        blnInformationChanged = True
        berekenHEWaarde()
    End Sub
    Private Sub txtOppervlakteHuis_Leave(sender As Object, e As System.EventArgs) Handles txtOppervlakteHuis.Leave
        'Kobus Visser 13/03/2013 change  KeyPress Event to Leave Event
        If txtOppervlakteHuis.Text = "" Then
            txtOppervlakteHuis.Text = "0"
        End If
        If CDbl(Me.HE_WAARDE.Text) <> 0 Then
            Dim strTest As String
            strTest = txtOppervlakteHuis.Text
            If IsNumeric(strTest) = True Then
                'Do nothing
            Else
                MsgBox("Surface of the House: only numbers are allowed", _
                       MsgBoxStyle.Information, "Verify")
                txtOppervlakteHuis.Focus()
            End If
        End If
    End Sub
    Private Sub txtOppervlakteHuis_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtOppervlakteHuis.TextChanged
        berekenHEWaarde()
        Me.txtOppvdummy.Text = CStr(Val(Me.txtOppervlakteHuis.Text) + Val(Me.txtOppervlakteLapa.Text)) ' Kobus CStr(Val(Me.txtOppervlakteHuis.Text) + Val(Me.txtOppervlakteLapa.Text))
    End Sub
    'Kobus Visser 13/03/2013 change  KeyPress Event to Leave Event
    Private Sub txtOppervlakteLapa_Leave(sender As Object, e As System.EventArgs) Handles txtOppervlakteLapa.Leave
        If txtOppervlakteLapa.Text = "" Then
            txtOppervlakteLapa.Text = "0"
        End If
        Dim strTest As String
        strTest = txtOppervlakteLapa.Text
        If IsNumeric(strTest) = True Then
            'Do nothing
        Else
            MsgBox("Size of lapa: only numbers are allowed", _
                   MsgBoxStyle.Information, "Verify")
            txtOppervlakteLapa.Focus()
        End If

    End Sub
    Private Sub txtOppervlakteLapa_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtOppervlakteLapa.TextChanged
        blnInformationChanged = True
        berekenHEWaarde()
        'Kobus - 21/02/2013 - Format to allow last 0 in decimal value where applicable? - removed format
        Me.txtOppvdummy.Text = CStr(Val(Me.txtOppervlakteHuis.Text) + Val(Me.txtOppervlakteLapa.Text))
    End Sub
    Private Sub txtOppvdummy_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtOppvdummy.TextChanged
        berekenHEWaarde()
    End Sub
    Private Sub txtPremieEkstras_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPremieEkstras.TextChanged
        If Not blnLoading Then
            calcPremium()
            blnInformationChanged = True
        End If
    End Sub
    Private Sub txtPremieNaKortingHB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPremieNaKortingHB.TextChanged
        calcGrandTotalAfter()
        blnInformationChanged = True
    End Sub
    Private Sub txtPremieNaKortingHE_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPremieNaKortingHE.TextChanged
        calcGrandTotalAfter()
        blnInformationChanged = True
    End Sub
    Private Sub txtPremiePersentasieHB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPremiePersentasieHB.TextChanged
        If Not blnLoading Then
            calcPremium()
            blnInformationChanged = True
        End If
    End Sub
    Private Sub txtPremiePersentasieHB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPremiePersentasieHB.Enter
        If Area.Tak_Naam <> "Bloemfontein" Then
            If blnRequestPwd Then
                'Kobus 23/09/2013 verander van "Please choose the discount / loading stuff in the password fields."
                frmPassword.lblMessage.Text = "Authorise the item discount/loading."

                frmPassword.ShowDialog()
                Me.txtPremiePersentasieHB.Focus()
            End If
            If pwdEntered = "passmeby" Then
                Me.txtPremiePersentasieHB.SelectionStart = 0
                Me.txtPremiePersentasieHB.SelectionLength = Me.txtPremiePersentasieHB.MaxLength
                blnRequestPwd = False
            Else
                'Kobus 02/09/2014 voegby om verkeerde password te rëel
                If pwdEntered = "Cancelled" Then
                    Me.txtPremieVoorHB.Focus()
                    Exit Sub
                End If
                MsgBox("The password is incorrect.", MsgBoxStyle.Information)
                Me.txtPremieVoorHB.Focus()
            End If
        End If
    End Sub
    Private Sub txtPremiePersentasieHB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPremiePersentasieHB.Leave
        blnRequestPwd = True
        If Me.txtPremiePersentasieHB.Text = "" Or CDbl(Me.txtPremiePersentasieHB.Text) = 0 Then
            MsgBox("Premium rates for HB can not be 0%, it is changed to 100%.", MsgBoxStyle.Information)
            Me.txtPremiePersentasieHB.Text = CStr(100)
            Exit Sub
        End If
    End Sub
    Private Sub txtPremiePersentasieHE_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPremiePersentasieHE.TextChanged
        If Not blnLoading Then
            calcPremium()
            blnInformationChanged = True
        End If
    End Sub
    Private Sub txtPremiePersentasieHE_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPremiePersentasieHE.Enter
        If Area.Tak_Naam <> "Bloemfontein" Then
            If blnRequestPwd Then
                'Kobus 23/09/2013 verander van "Please choose the discount / loading stuff in the password fields."
                frmPassword.lblMessage.Text = "Authorise the item discount/loading."

                frmPassword.ShowDialog()
                Me.txtPremiePersentasieHE.Focus()
            End If
            If pwdEntered = "passmeby" Then
                Me.txtPremiePersentasieHE.SelectionStart = 0

                Me.txtPremiePersentasieHE.SelectionLength = Me.txtPremiePersentasieHE.MaxLength
                blnRequestPwd = False
            Else
                'Kobus 02/09/2014 voegby om verkeerde password te rëel
                If pwdEntered = "Cancelled" Then
                    Me.txtPremieVoorHE.Focus()
                    Exit Sub
                End If
                MsgBox("The password is not correct.", MsgBoxStyle.Information)
                Me.txtPremieVoorHE.Focus()
            End If
        End If
    End Sub
    Private Sub txtPremiePersentasieHE_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPremiePersentasieHE.Leave
        blnRequestPwd = True
        If Me.txtPremiePersentasieHE.Text = "" Or CDbl(Me.txtPremiePersentasieHE.Text) = 0 Then
            MsgBox("Premie percentage of HE can not be 0%, it is changed to 100%.", MsgBoxStyle.Information)
            Me.txtPremiePersentasieHE.Text = CStr(100)
            Exit Sub
        End If
    End Sub
    Private Sub txtPremieVoorHB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPremieVoorHB.KeyPress
        'Kobus 05/04/2013 do test on leave rather then KeyPress
        If (Char.IsLetter(e.KeyChar)) Then

            e.Handled = True
            MsgBox("Premium: Must be numeric", _
                   MsgBoxStyle.Information, "Verify")
            txtPremieVoorHB.Focus()
        Else
            'do nothing'do nothing
        End If
        calcPremium()
    End Sub
    Private Sub txtPremieVoorHB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPremieVoorHB.TextChanged

        blnInformationChanged = True
        calcPremium()
    End Sub
    Private Sub txtPremieVoorHB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPremieVoorHB.Enter
        Me.txtPremieVoorHB.SelectionStart = 0
        Me.txtPremieVoorHB.SelectionLength = Me.txtPremieVoorHB.MaxLength
        'Kobus 29/04/2014 comment in
        'Kobus 03/10/2013 comment out
        Me.txtPremieVoorHB.SelectAll()
    End Sub
    Private Sub txtPremieVoorHE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPremieVoorHE.KeyPress
        'If (Char.IsControl(e.KeyChar) = False) Then
        If (Char.IsLetter(e.KeyChar)) Then

            e.Handled = True
            MsgBox("Premium: Must be numeric", _
                   MsgBoxStyle.Information, "Verify")
            txtPremieVoorHE.Focus()
        Else
            'do nothing'do nothing
        End If
        'End If
        calcPremium()
    End Sub
    Private Sub txtPremieVoorHE_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPremieVoorHE.TextChanged
        blnInformationChanged = True
        calcPremium()
    End Sub
    Private Sub txtPremieVoorHE_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPremieVoorHE.Enter
        'Kobus 24/04/2013 change
        Me.txtPremieVoorHE.SelectionStart = 0
        Me.txtPremieVoorHE.SelectionLength = Me.txtPremieVoorHE.TextLength
        'Kobus 29/04/2014 comment in
        'Kobus 03/10/2013 comment out
        Me.txtPremieVoorHE.SelectAll()
    End Sub
    Private Sub WAARDE_HB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles WAARDE_HB.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar)) Then
                'do nothing
            Else
                e.Handled = True
                MsgBox("Value: Must be numeric", _
                       MsgBoxStyle.Information, "Verify")
                WAARDE_HB.Focus()
            End If
        End If
    End Sub
    Private Sub WAARDE_HB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WAARDE_HB.TextChanged
        blnInformationChanged = True
        calcTotValue()
    End Sub
    Private Sub WAARDE_HB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WAARDE_HB.Enter
        Me.WAARDE_HB.SelectionStart = 0
        Me.WAARDE_HB.SelectionLength = Len(Me.WAARDE_HB.Text)
        'Kobus 29/04/2014 comment in
        'Kobus 12/09/2013 voegby
        Me.WAARDE_HB.SelectAll() '6.53
    End Sub
    'Calculate the premium according to the % discount
    Public Sub calcPremium()

        Me.HE_Premie.Text = CStr(Format(Val(Me.txtPremieVoorHE.Text), "######0.00"))    'K 19/03/2013
        'Kobus 09/10/2013 verander van CStr(Format((Val(Me.txtPremieVoorHB.Text) * (Val(Me.txtPremiePersentasieHB.Text) / 100)), "######0.00"))
        Me.Premie_HB.Text = Format(System.Math.Round((Val(Me.txtPremieVoorHB.Text) * (Val(Me.txtPremiePersentasieHB.Text) / 100)), 2), "######0.00")
        Me.HE_Premie.Text = CStr(Format((((Val(Me.txtPremieVoorHE.Text)) + Val(Me.txtPremieEkstras.Text)) * (Val(Me.txtPremiePersentasieHE.Text) / 100)), "######0.00"))   'K
        If IsDBNull(Persoonl.eispers) Then
            Me.txtPremieNaKortingHB.Text = CStr(Format(Val(Me.Premie_HB.Text), "######0.00"))    'K
            Me.txtPremieNaKortingHE.Text = CStr(Format(Val(Me.HE_Premie.Text), "######0.00"))    'K
        Else
            Me.txtPremieNaKortingHB.Text = CStr(Format(Val(Me.Premie_HB.Text) * Val(Persoonl.eispers), "######0.00"))    'K
            Me.txtPremieNaKortingHE.Text = CStr(Format(Val(Me.HE_Premie.Text) * Val(Persoonl.eispers), "######0.00"))    'K
        End If
    End Sub
    Public Function pwdInputBox() As String
        pwdInputBox = InputBox("Only authorized users may select this option" & Chr(13) & "Please enter password", "Poldata Security")
    End Function
    'Calculate the grand total
    Public Sub calcGrandTotal()
        Me.txtGrootTotaal.Text = Format(Val(Me.HE_Premie.Text) + Val(Me.Premie_HB.Text), "######0.00")
    End Sub
    'Calculate the grand total after
    Public Sub calcGrandTotalAfter()
        Me.txtGrootTotaalNa.Text = Format(Val(Me.txtPremieNaKortingHB.Text) + Val(Me.txtPremieNaKortingHE.Text), "######0.00")
    End Sub
    'Set captions of the security checkboxes
    Public Sub setSecurityItemsCaption()
        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim param As New SqlParameter("@Type", SqlDbType.NVarChar)
            param.Value = "Eiendom"

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchSekuriteitbyType", param)

            'If reader.Read Then  'Kobus Visser 15/03/2013 change to Do While
            Do While reader.Read()
                chkSekuriteit(reader("bit")).CheckState = System.Windows.Forms.CheckState.Unchecked
                chkSekuriteit(reader("bit")).Text = reader("BeskrywingEngels")  'Kobus Visser 15/03/2013 change BeskrywingAfrikaans
                If reader("BeskrywingEngels") = "n/a" Then      'Kobus Visser 15/03/2013 change BeskrywingAfrikaans
                    chkSekuriteit(reader("bit")).Enabled = False
                End If
            Loop
            'rs.MoveNext()
            conn.Close()
        End Using

    End Sub
    'Calculate the bitwise number of the SECURITY options selected
    Public Function calcSecuritySelectedBitwise() As Integer
        Dim Temp As Integer

        calcSecuritySelectedBitwise = 0
        Temp = 0
        For Me.k = 0 To chkSekuriteit.UBound
            If chkSekuriteit(k).CheckState Then
                Temp = Temp + (2 ^ k) 'to calculate bitwise number 2 ^ position of bit
            End If
        Next

        calcSecuritySelectedBitwise = Temp
    End Function
    'Set SECURITY checkboxes according to bitwise number
    'Kobus Visser 15/03/2013 change from Public Function to Public Sub
    'Public Function setSecuritySelected(ByRef bitwise As Integer) As Object
    Public Sub setSecuritySelected(ByRef bitwise As Integer)
        If bitwise <> 0 Then
            For Me.k = 0 To chkSekuriteit.UBound
                If bitwise And (2 ^ k) Then
                    chkSekuriteit(k).CheckState = System.Windows.Forms.CheckState.Checked
                End If
            Next
        End If
    End Sub
    Private Sub toe_waarde_Change()
        blnInformationChanged = True
    End Sub
    Private Sub toe_premie_Change()
        blnInformationChanged = True
    End Sub
    Private Sub eem_waarde_Change()
        blnInformationChanged = True
    End Sub
    Private Sub eem_premie_Change()
        blnInformationChanged = True
    End Sub
    Private Sub txtBoukoste_Change()
        berekenHEWaarde()
    End Sub
    'Bereken HE waarde volgens boukoste en oppervlakte
    Public Sub berekenHEWaarde()
        If Me.txtOppvdummy.Text <> "" And IsNumeric(txtOppvdummy.Text) And Me.txtBoukoste.Text <> "" And IsNumeric(txtBoukoste.Text) Then
            'Kobus 31/05/2013 change CDbl(Me.txtBoukoste.Text), 2)
            Me.txtHEVoorgesteldeWaarde.Text = CStr(System.Math.Round(CDbl(Me.txtOppvdummy.Text) * FormatNumber(Me.txtBoukoste.Text), 0))
        Else
            'Kobus Visser 19/03/2013 change from "n.v.t"
            Me.txtHEVoorgesteldeWaarde.Text = "N/A"
        End If
    End Sub
    Private Sub _SSTab1_TabPage6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _SSTab1_TabPage6.Click

        'Kobus 28/10/2013 voegby if editing
        If blnediting Then
            GridGeisers.DataSource = FetchGeyserTypeWithGrid()
        Else
            If HE_WAARDE.Text <> 0 Then
                Me.btnVoegby.Enabled = True
            End If
        End If

    End Sub
    Private Sub _SSTab1_TabPage6_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _SSTab1_TabPage6.Enter
        'Kobus 28/10/2013 voegby
        If Val(HE_WAARDE.Text) <> 0 And pkHuis = 0 Then
            Me._SSTab1_TabPage6.Enabled = True
            Me.btnVoegby.Enabled = True
            Me.btnEdit.Enabled = True
            Me.btnVerwyder.Enabled = True
        Else
            If Val(HE_WAARDE.Text) = 0 Then
                Me._SSTab1_TabPage6.Enabled = False
                Me.btnVoegby.Enabled = False
                Me.btnEdit.Enabled = False
                Me.btnVerwyder.Enabled = False
            End If
        End If
        'Kobus 18/09/2013 voegby
        'If blnNoRepeat = False Then
        If pkHuis = 0 And blnRepeatGeyser = False Then
            validateForm()
            'End If
        End If
    End Sub
    Private Sub TotWaardeHE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TotWaardeHE.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub TotWaardeHB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TotWaardeHB.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub _chkSekuriteit_7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _chkSekuriteit_7.CheckedChanged
        _chkSekuriteit_7.Enabled = False
    End Sub
    Private Sub _chkSekuriteit_6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _chkSekuriteit_6.CheckedChanged
        _chkSekuriteit_6.Enabled = False
    End Sub
    Private Sub txtPremieVoorHB_Leave(sender As Object, e As System.EventArgs) Handles txtPremieVoorHB.Leave
        'Kobus 05/04/2013 change test to trigger on leave
        'Kobus 05/04/2013 change IsNumeric(Me.txtPremieVoorHB.Text.Trim)
        If IsNumeric(Me.txtPremieVoorHB.Text) = True Then
            'do nothing
        Else
            MsgBox("Premium: Must be numeric", _
                   MsgBoxStyle.Information, "Verify")
            txtPremieVoorHB.Focus()
        End If

        'Kobus 13/09/2013 voegby
        If Me.txtPremieVoorHB.Text = "" Then
            Me.txtPremieVoorHB.Text = "0.00"
        End If
        'Kobus Visser - 21/02/2013 - Add Format to keep last 0 ) in sents - don't think that this will make a difference due to other formats
        Me.txtPremieVoorHB.Text = Format(Val(Me.txtPremieVoorHB.Text), "######0.00")
        calcPremium()
    End Sub
    Private Sub toe_premie_Leave(sender As Object, e As System.EventArgs) Handles toe_premie.Leave
        'Kobus 29/04/2013 add
        If Me.toe_premie.Text = "" Then
            Me.toe_premie.Text = "0"
        ElseIf (Not (IsNumeric(toe_premie.Text))) Then
            Me.toe_premie.Text = "0"
            Me.SSTab1.SelectedIndex = 5
            'Me.toe_waarde.Enabled = True
            MsgBox("The accidental damage premium must be  a numeric value.", _
                   MsgBoxStyle.Information, "Verify")
            Me.SSTab1.SelectedIndex = 5
            Me.toe_premie.Focus()
            Exit Sub
        End If


    End Sub
    Private Sub toe_waarde_Leave(sender As Object, e As System.EventArgs) Handles toe_waarde.Leave
        'Kobus 29/04/2013 add
        If Me.toe_waarde.Text = "" Then
            Me.toe_waarde.Text = "0"
        End If
        If (Not (IsNumeric(toe_waarde.Text))) Then
            Me.SSTab1.SelectedIndex = 5
            Me.toe_waarde.Enabled = True
            MsgBox("The accidental damage value must be a numeric value without ditgits.", _
                   MsgBoxStyle.Information, "Verify")
            Me.SSTab1.SelectedIndex = 5
            Me.toe_waarde.Focus()
        End If
        Exit Sub
    End Sub
    Private Sub eem_waarde_Leave(sender As Object, e As System.EventArgs) Handles eem_waarde.Leave
        'Kobus 29/04/2013 add
        If Me.eem_waarde.Text = "" Then
            Me.eem_waarde.Text = "0"
        End If
        If (Not (IsNumeric(eem_waarde.Text))) Then
            Me.SSTab1.SelectedIndex = 5
            Me.eem_waarde.Enabled = True
            MsgBox("The accidental damage (EEM) value must be a numeric value without ditgits.", _
                   MsgBoxStyle.Information, "Verify")
            Me.SSTab1.SelectedIndex = 5
            Me.eem_waarde.Focus()
        End If
        Exit Sub
    End Sub
    Private Sub eem_premie_Leave(sender As Object, e As System.EventArgs) Handles eem_premie.Leave

        'Kobus 29/04/2013 add
        If Me.eem_premie.Text = "" Then
            Me.eem_premie.Text = "0"
        ElseIf (Not (IsNumeric(eem_premie.Text))) Then
            Me.eem_premie.Text = "0"
            Me.SSTab1.SelectedIndex = 5
            'Me.toe_waarde.Enabled = True
            MsgBox("The accidental damage (EEM) premium must be a numeric value.", _
                   MsgBoxStyle.Information, "Verify")
            Me.SSTab1.SelectedIndex = 5
            Me.eem_premie.Focus()
            Exit Sub
        End If

    End Sub
    Private Sub txtWaardeEkstras_TextChanged(sender As Object, e As System.EventArgs) Handles txtWaardeEkstras.TextChanged
        blnInformationChanged = True
    End Sub
    Private Sub Check1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Check1.CheckedChanged
        'Kobus 25/04/2013 add
        If intCurrentMainPtyStatus <> 1 Then
            blnInformationChanged = True
        Else
            blnInformationChanged = False
        End If
    End Sub
    Private Sub Check1_Click(sender As Object, e As System.EventArgs) Handles Check1.Click
        'Kobus 25/04/2013 add
        If Check1.CheckState = 1 Then
            FetchMainProperty()
        End If

    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Private Sub chkVerband_Click(sender As Object, e As System.EventArgs) Handles chkVerband.Click
        'Kobus 12/09/2013 voegby
        If Me.chkVerband.CheckState = CheckState.Unchecked Then
            Me.cmbHomeLoanOrg.Text = ""
            Me.cmbHomeLoanOrg.Enabled = False
        End If
    End Sub
    Private Sub txtPremieVoorHE_Leave(sender As Object, e As System.EventArgs) Handles txtPremieVoorHE.Leave
        If txtPremieVoorHE.Text = "0" Or txtPremieVoorHE.Text = "" Then
            txtPremieVoorHE.Text = "0.00"
        Else
            txtPremieVoorHE.Text = Format(Val(txtPremieVoorHE.Text), "########0.00")
        End If
    End Sub
    Private Sub WAARDE_HB_Leave(sender As Object, e As System.EventArgs) Handles WAARDE_HB.Leave
        'Kobus 13/08/2013 voegby
        If WAARDE_HB.Text = "" Then
            WAARDE_HB.Text = "0"
        End If
    End Sub
    Private Sub HE_WAARDE_Leave(sender As Object, e As System.EventArgs) Handles HE_WAARDE.Leave
        'Kobus 13/09/2013 voegby
        If HE_WAARDE.Text = "" Then
            HE_WAARDE.Text = "0"
        End If
        'Kobus 31/10/2013 voegby
        If txtPremieEkstras.Text = "" Then
            txtPremieEkstras.Text = 0
        End If
        'Kobus 24/10/2013 move to leave event
        'Kobus Visser - 21/02/2013 - Disable Geyser Tab (Add, Edit etc) when not Homeowner
        If Me.HE_WAARDE.Text = 0 And txtPremieEkstras.Text = 0 Then
            Me._SSTab1_TabPage6.Enabled = False
        Else
            Me._SSTab1_TabPage6.Enabled = True
        End If

        If Val(HE_WAARDE.Text) = 0 And dblHEWaarde <> 0 And Val(txtPremieEkstras.Text) <> 0 Then
            Me.HE_WAARDE.Text = dblHEWaarde
            Me._SSTab1_TabPage6.Enabled = True
            'Kobus 31/10/2013 verander van MsgBox("First remove geysers before removing Home Owner value!", 48, "Warning!")
            MsgBox("The geyser(s) must be removed before you can change Homeowner value to nil!", 48, "Warning!")
            Me.SSTab1.SelectedIndex = 6
            Me.btnVoegby.Enabled = True
            Me.btnVoegby.Focus()
            Exit Sub
        End If
        'Kobus 28/10/2013 voegby
        If Me.HE_WAARDE.Text <> 0 Then
            Me.btnVoegby.Enabled = True
            Me.btnEdit.Enabled = True
            Me.btnVerwyder.Enabled = True
        End If
        calcTotValue()
    End Sub
    Private Sub WAARDE_HB_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles WAARDE_HB.MouseClick
        'Kobus 29/04/2014 voegby
        Me.WAARDE_HB.SelectAll()
    End Sub
    Private Sub txtPremieVoorHE_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtPremieVoorHE.MouseClick
        'Kobus 29/04/2014 voegby
        Me.txtPremieVoorHE.SelectAll()
    End Sub
    Private Sub txtPremieVoorHB_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtPremieVoorHB.MouseClick
        'Kobus 29/04/2014 voeg by
        Me.txtPremieVoorHB.SelectAll()
    End Sub
    Private Sub HE_WAARDE_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles HE_WAARDE.MouseClick
        'Kobus 29/04/2014 voegby
        Me.HE_WAARDE.SelectAll()
    End Sub
    Public Sub GetPoskodeAdres(ByVal Poskode As String)
        'Kobus 08/05/2014 skep sub om dorp/stad te soek wanneer dit by ou rekords ontbreek
        Dim strDorp As String = ""
        Dim intI As Integer = 2

        Using conn As SqlConnection = SqlHelper.GetConnection

            Dim param() As SqlParameter = {New SqlParameter("@Poskode", SqlDbType.NVarChar)}

            param(0).Value = Poskode

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPoskodeAdresByKode", param)

            Do While reader.Read
                If reader("voorstad") = Me.DisplayVoorstad.Text Then
                    strDorp = reader("dorp")
                    Me.DisplayDorp.Text = (reader("Dorp"))
                    intI = 1
                    Exit Do
                Else
                    intI = 2
                    Me.DisplayDorp.Text = reader("dorp")
                End If
            Loop

            If intI > 2 Then
                MsgBox("The record cannot be found, please select a valid address.")
                Me.DisplayDorp.Text = strDorp
            End If
            conn.Close()
        End Using
    End Sub
End Class




















