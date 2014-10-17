Option Strict Off
Option Explicit On
Friend Class PoskodesSoek
    Inherits BaseForm
    Public blnNoRepeat As Boolean
    Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        'Kobus 23/10/2013 voegby
        blnNoRepeat = False
        DetailGridView.DataSource = Nothing
        DetailGridView.Refresh()

        'Me.MSFlexGrid1.row = 0

        Me.txtPoskode.Text = ""
        Me.soekdorp.Text = ""
        Me.soekvoorstad.Text = ""
        'Kobus 09/10/2013 voeg by
        OpdateerKodes.Enabled = False
        Me.Close()
    End Sub
    'Button clear clicked - clear all text controls
    Private Sub btnClear_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClear.Click
        'Clear txtboxes and grid
        'Kobus 23/10/2013 voegby
        blnNoRepeat = False
        DetailGridView.DataSource = Nothing
        DetailGridView.Refresh()

        'Me.MSFlexGrid1.row = 0

        Me.txtPoskode.Text = ""
        Me.soekdorp.Text = ""
        Me.soekvoorstad.Text = ""

        Me.soekvoorstad.Focus()

        Me.OpdateerKodes.Enabled = False
    End Sub

    Private Sub cmbCodeType_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbCodeType.SelectedIndexChanged
        'Check from which form the search was lauched - display message accordingly
        If Me.cmbCodeType.SelectedIndex = 1 Then 'Box
            Select Case Trim(LCase(Me.txtFormToPopulate.Text))
                'KobusVisser 28/02/2013 changed elected to selected 
                Case "huis_ef"
                    If blnNoRepeat = True Then
                    Else
                        blnNoRepeat = True
                        MsgBox("Note: PO Box codes are not supposed to be selected as risk addresses.", MsgBoxStyle.Information)
                        'Kobus 23/10/2013 voegby
                        Me.cmbCodeType.SelectedIndex = 1
                        Me.cmbCodeType.Text = "PO Box"
                        Me.soekvoorstad.Focus()
                        Exit Sub
                    End If
                Case "voertuigdetail"
                    If blnNoRepeat = True Then
                    Else
                        blnNoRepeat = True
                        MsgBox("Note: PO Box codes are not supposed to be selected as overnight addresses.", MsgBoxStyle.Information)
                        'Kobus 23/10/2013 voegby
                        Me.cmbCodeType.SelectedIndex = 1
                        Me.cmbCodeType.Text = "PO Box"
                        Me.soekvoorstad.Focus()
                        Exit Sub
                    End If
            End Select
        End If
    End Sub

    Private Sub PoskodesSoek_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        Me.soekvoorstad.Text = ""
        Me.soekdorp.Text = ""
        Me.txtPoskode.Text = ""
        Me.cmbCodeType.SelectedIndex = 0
        Me.soekvoorstad.Focus()
    End Sub

    Private Sub PoskodesSoek_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Text = "      National Postal Codes"
        DetailGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DetailGridView.ReadOnly = True
        'Kobus 09/10/2013 voegby
        If DetailGridView.RowCount = 1 Then
            Me.OpdateerKodes.Enabled = False
        End If

    End Sub

    Private Sub MSFlexGrid1_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If Me.OpdateerKodes.Enabled Then
            OpdateerKodes_Click(OpdateerKodes, New System.EventArgs())
        End If
    End Sub

    Private Sub OpdateerKodes_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OpdateerKodes.Click
        'Kobus 23/10/2013 voegby
        blnNoRepeat = False
        If DetailGridView.SelectedCells(0).Value <> "" Then
            Select Case Trim(LCase(Me.txtFormToPopulate.Text))

                Case "huis_ef"
                    '    'Set variables according to selection
                    '    Me.MSFlexGrid1.col = 1
                    OpdateerKodes.Focus()
                    Huis_EF.DisplayVoorstad.Text = DetailGridView.SelectedCells(0).Value
                    '    Me.MSFlexGrid1.col = 2
                    Huis_EF.DisplayDorp.Text = DetailGridView.SelectedCells(1).Value
                    '    Me.MSFlexGrid1.col = 3
                    If cmbCodeType.SelectedItem = "Street" Then    'Kobus 05/03/2013 change Straat to Street
                        Huis_EF.poskode.Text = DetailGridView.SelectedCells(2).Value
                    Else
                        Huis_EF.poskode.Text = DetailGridView.SelectedCells(3).Value
                    End If
                    'Kobus 09/10/2013 voeg by
                    OpdateerKodes.Enabled = False
                    '    Huis_EF.Refresh()
                Case "voertuigdetail"

                    VoertuigDetail.txtVoorstad.Text = DetailGridView.SelectedCells.Item(0).Value

                    VoertuigDetail.txtStad.Text = DetailGridView.SelectedCells.Item(1).Value
                    ' Andriette maak spelfout reg
                    'If cmbCodeType.SelectedItem = "Steet" Then       'Kobus 05/03/2013 change Straat to Street
                    If cmbCodeType.SelectedItem = "Street" Then       'Kobus 05/03/2013 change Straat to Street
                        VoertuigDetail.txtPoskode.Text = DetailGridView.SelectedCells.Item(2).Value
                    Else
                        VoertuigDetail.txtPoskode.Text = DetailGridView.SelectedCells.Item(3).Value
                    End If
                    'Kobus 09/10/2013 voeg by
                    OpdateerKodes.Enabled = False
                Case "form1"
                    ' Andriette 06/03/2013 Herontwerp die skryf na die hoofskerm
                    ' voorstad
                    Form1.ADRES3.Text = DetailGridView.SelectedCells.Item(0).Value
                    Form1.ADRES3_Leave(Nothing, New System.EventArgs())
                    'Haal hierdie uit want dit word hanteer in adres 2
                    ' Dorp/Stad  
                    Form1.ADRES1.Text = DetailGridView.SelectedCells.Item(1).Value
                    'Form1.ADRES1_Leave(Nothing, New System.EventArgs())
                    'Poskode
                    If cmbCodeType.SelectedItem = "Street" Then
                        Form1.ADRES2.Text = DetailGridView.SelectedCells.Item(2).Value
                        Form1.ADRES2_Leave(Nothing, New System.EventArgs())
                    Else
                        Form1.ADRES2.Text = DetailGridView.SelectedCells.Item(3).Value
                        Form1.ADRES2_Leave(Nothing, New System.EventArgs())
                    End If


                    ' Andriette 06/05/2013 OU code

                    ''    Me.MSFlexGrid1.col = 1
                    '' Andriette 06/03/2013 verander die waardes
                    ''Form1.ADRES3.Text = DetailGridView.SelectedRows(0).Cells(0).Value
                    'Form1.ADRES3.Text = DetailGridView.SelectedCells.Item(0).Value
                    'Form1.ADRES3_Leave(Nothing, New System.EventArgs())
                    ''    Me.MSFlexGrid1.col = 2
                    '' Andriette 06/03/2013 verander die waardes
                    ''Form1.ADRES1.Text = DetailGridView.SelectedCells(1).Value
                    'Form1.ADRES1.Text = DetailGridView.SelectedCells.Item(1).Value
                    'Form1.ADRES1_Leave(Nothing, New System.EventArgs())
                    ''    Me.MSFlexGrid1.col = 3
                    '' Andriette 06/03/2013 verander die waardes
                    ''Form1.ADRES2.Text = DetailGridView.SelectedCells(2).Value
                    'Form1.ADRES2.Text = DetailGridView.SelectedCells.Item(2).Value
                    '' Form1.ADRES2.Text = DetailGridView.SelectedRows(0).Cells(3).Value
                    'Form1.ADRES2_Leave(Nothing, New System.EventArgs())
                    ''Fire change and lostfocus events to save data to database - use the existing functions
                    ''Form1.ADRES3_TextChanged(Nothing, New System.EventArgs())
                    ''Form1.ADRES3_Leave(Nothing, New System.EventArgs())
                    ''Form1.ADRES1_TextChanged(Nothing, New System.EventArgs())
                    ''Form1.ADRES1_Leave(Nothing, New System.EventArgs())
                    ''Form1.ADRES2_TextChanged(Nothing, New System.EventArgs())
                    ''Form1.ADRES2_Leave(Nothing, New System.EventArgs())
                Case "search"
                    Search.txtVoorstad.Text = DetailGridView.SelectedCells(0).Value
                    Search.txtStad.Text = DetailGridView.SelectedCells(1).Value
                    If cmbCodeType.SelectedItem = "Street" Then     'K Visser
                        Search.txtPoskode.Text = DetailGridView.SelectedCells(2).Value
                    Else
                        Search.txtPoskode.Text = DetailGridView.SelectedCells(3).Value
                    End If

                Case "BriefDubbelPremie"
                    BriefDubbelPremie.txtVoorstad.Text = DetailGridView.SelectedRows(0).Cells(0).Value
                    ' Andriette 06/03/2013 verander spelling na engels
                    'If cmbCodeType.SelectedItem = "Straat" Then
                    If cmbCodeType.SelectedItem = "Street" Then
                        BriefDubbelPremie.txtPoskode.Text = DetailGridView.SelectedRows(0).Cells(2).Value
                    Else
                        BriefDubbelPremie.txtPoskode.Text = DetailGridView.SelectedRows(0).Cells(3).Value
                    End If
                Case "briefbevestig"
                    BriefBevestig.txtVoorstad.Text = DetailGridView.SelectedCells(0).Value
                    ' Andriette 06/03/2013 verander spelling na engels
                    'If cmbCodeType.SelectedItem = "Straat" Then
                    If cmbCodeType.SelectedItem = "Street" Then
                        BriefBevestig.txtPoskode.Text = DetailGridView.SelectedCells(2).Value
                    Else
                        BriefBevestig.txtPoskode.Text = DetailGridView.SelectedCells(3).Value
                    End If
                Case "briefopskort"
                    BriefOpskort.txtVoorstad.Text = DetailGridView.SelectedCells(0).Value
                    ' Andriette 06/03/2013 verander spelling na engels
                    'If cmbCodeType.SelectedItem = "Straat" Then
                    If cmbCodeType.SelectedItem = "Street" Then
                        BriefOpskort.txtPoskode.Text = DetailGridView.SelectedCells(2).Value
                    Else
                        BriefOpskort.txtPoskode.Text = DetailGridView.SelectedCells(2).Value
                    End If
                    'Linkie 02/07/2014 - sit by sodat Eise dit ook kan gebruik
                Case "frmclaimslist"
                    frmClaimsList.txtSubburb.Text = DetailGridView.SelectedCells(0).Value
                    frmClaimsList.txtTown.Text = DetailGridView.SelectedCells(1).Value
                    If cmbCodeType.SelectedItem = "Street" Then
                        frmClaimsList.txtPostalCode.Text = DetailGridView.SelectedCells(2).Value
                    Else
                        frmClaimsList.txtPostalCode.Text = DetailGridView.SelectedCells(3).Value
                    End If
                    'Linkie 02/07/2014 - sit by sodat Eise dit ook kan gebruik
                Case "frmclaimsassessors"
                    frmClaimsAssessors.txtSubburb.Text = DetailGridView.SelectedCells(0).Value
                    frmClaimsAssessors.txtTown.Text = DetailGridView.SelectedCells(1).Value
                    If cmbCodeType.SelectedItem = "Street" Then
                        frmClaimsAssessors.txtPostalCode.Text = DetailGridView.SelectedCells(2).Value
                    Else
                        frmClaimsAssessors.txtPostalCode.Text = DetailGridView.SelectedCells(3).Value
                    End If
            End Select
            DetailGridView.DataSource = Nothing
            DetailGridView.DataBindings.Clear()
            DetailGridView.Refresh()
            Me.Close()
        Else
            MsgBox("A specific postcode must be selected to continue.", MsgBoxStyle.Exclamation)
        End If

    End Sub
    Private Sub soek_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles soek.Click
        'Replace code to only retrieve records from database that conforms to the search criteria specified
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        populateGrid()

        If DetailGridView.RowCount = 0 Then
            Me.OpdateerKodes.Enabled = False
        Else
            If Gebruiker.titel = "Besigtig" Then
                Me.OpdateerKodes.Enabled = False
            Else
                Me.OpdateerKodes.Enabled = True

            End If
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
        'Kobus 09/10/2013 voegby
        OpdateerKodes.Focus()
    End Sub

    Public Sub populateGrid()
        'Andriette 15/08/2014 gee die veranderlike ;n waarde om warnings weg te vat
        Dim type As String = ""

        DetailGridView.DataBindings.Clear()
        DetailGridView.AutoGenerateColumns = False
        ' Andriette 06/03/2013 verander die parameter wat na die Sp gaan
        If cmbCodeType.SelectedItem = "Street" Then
            type = "Straat"
        ElseIf cmbCodeType.SelectedItem = "PO Box" Then
            type = "PO Box"
        End If
        ' Andriette 06/03/2013 verander die parameters
        'DetailGridView.DataSource = listPoskode(cmbCodeType.SelectedItem, soekvoorstad.Text, soekdorp.Text, txtPoskode.Text)
        DetailGridView.DataSource = listPoskode(type, soekvoorstad.Text, soekdorp.Text, txtPoskode.Text)
        DetailGridView.Refresh()

        If cmbCodeType.SelectedItem = "Street" Then  'Kobus 05/03/2013 change Straat to Street
            DetailGridView.Columns(2).Visible = True
            DetailGridView.Columns(3).Visible = False
        Else
            DetailGridView.Columns(2).Visible = False
            DetailGridView.Columns(3).Visible = True
        End If
    End Sub


    'Private Sub DetailGridView_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DetailGridView.CellContentClick
    '    OpdateerKodes.PerformClick()
    'End Sub
End Class