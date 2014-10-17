Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Data.SqlClient
Imports DAL
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.Form
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Diagnostics

Friend Class Form1
    Inherits BaseForm

    ' Private Declare Function GetActiveWindow Lib "User" () As Short
    Dim blnchange As Boolean = False
    '  Dim go As Short
    Public blnKanselleerPolisFormCancelled As Boolean
    Const strHeader As String = "##DIS"
    Const strCompanyNumber As String = "127811"
    ' Const strTransactionCode As String = "400"
    '  Const strTypeofPayment As String = "21"
    '  Const strReference As String = ""
    Dim strDebitOrderOutputFileName As String
    Dim strCollectiondate As String
    Dim strMultidataPath As String
    Dim strDebitOrderDataPath As String
    Public intDelay As Integer
    Public intHuidigearea As Integer
    Public dblpolitiek As Double
    'Andriette skep ;n variable wat elektroniese pos aandui
    Public blnElectronicMail As Boolean = False
    'Linkie share al die controls
    Public Shared txtForm1Polisno As TextBox
    Public Shared txtForm1Versekerde As TextBox
    Public Shared txtForm1Voorl As TextBox
    Public Shared txtForm1ID_Nom As TextBox
    Public Shared txtForm1Dept As TextBox
    Public Shared txtForm1Beroep As TextBox
    Public Shared txtForm1BTWNo As TextBox
    Public Shared txtForm1Adres As TextBox
    Public Shared txtForm1Adres4 As TextBox
    Public Shared txtForm1Adres3 As TextBox
    Public Shared txtForm1Adres2 As TextBox
    Public Shared txtForm1NoemNaam As TextBox
    Public Shared txtForm1Huis_tel As TextBox
    Public Shared txtForm1Werk_tel As TextBox
    Public Shared txtForm1sel_tel As TextBox
    Public Shared txtForm1Fax As TextBox
    Public Shared txtForm1Email As TextBox
    'Andriette verander na 'n masked text box
    ' Public Shared form1PA_Dat As TextBox
    Public Shared txtForm1PA_Dat As MaskedTextBox
    Public Shared txtForm1Bet_dat As MaskedTextBox
    Public Shared txtForm1Gekans As TextBox
    Public Shared txtForm1Pos_vakkie As TextBox
    Public Shared txtForm1Pers_Nom As TextBox
    Public Shared txtForm1Besk_nr As TextBox
    ' Andriette 28/05/2013 verander die tipe van 'n label na 'n text box sodat dit verander kan word 10/04/2013
    Public Shared txtForm1LiabilityPrem As TextBox
    ' Andriette  29/05/2013 verander die tipe van 'n label na 'n text box sodat dit verander kan word10/04/2013
    Public Shared txtForm1CourtesyPrem As TextBox
    ' Andriette 29/05/2013 verander die tipe van 'n label na 'n text box sodat dit verander kan word 10/04/2013
    Public Shared txtForm1HomeAsst As TextBox
    ' Andriette 29/05/2013  verander die tipe van 'n label na 'n text box sodat dit verander kan word 10/04/2013
    Public Shared txtForm1RoadsidePrem As TextBox
    ' Andriette 10/04/2013  verander die tipe van 'n text box na 'n label sodat dit nie verander kan word nie 
    Public Shared lblForm1Pakket1Prem As Label
    Public Shared txtForm1Pakketitem2 As TextBox
    Public Shared cmbForm1Posbestemming As ComboBox
    Public Shared cmbForm1Area As ComboBox
    Public Shared cmbForm1Betaaldag As ComboBox
    Public Shared cmbForm1Bybet_k As ComboBox
    Public Shared cmbForm1Vanwie As ComboBox
    Public Shared cmbForm1Taal As ComboBox
    Public Shared cmbForm1Oudstudent As ComboBox
    'Public Shared form1AddSek As ComboBox
    Public Shared cmbForm1Plip2 As ComboBox
    Public Shared lblForm1Label36 As Label
    Public Shared lblForm1Label18 As Label
    Public Shared lblForm1Label35 As Label
    Public Shared lblForm1PolisPakketTotaal As Label
    Public Shared lblForm1SubtotaalNaKorting As Label
    ' Andriette 29/05/2013  verander die tipe van 'n label na 'n text box sodat dit verander kan word 
    ' Andriette 14/06/2013 verander die selfoon textbox na 'n button
    Public Shared btnForm1Selfoon As Button
    Public Shared lblForm1MaandeliksePremie As Label
    Public Shared lblForm1Label16 As Label
    Public Shared lblForm1Verwysingskommissie As Label
    Public Shared btnForm1AddisionelePremie As Button
    Public Shared lblForm1Premie2 As Label
    Public Shared lblForm1Label33 As Label
    Public Shared lblForm1Label23 As Label
    Public Shared cmbForm1Combo1 As ComboBox
    Public Shared lblForm1tydperk As Label
    Public Shared lblForm1status As Label
    Public Shared lblForm1Months As Label
    Public intBemarkerIndex As Integer
    Dim strAanvangGekanseleer As String
    Public Shared strOpsoekKat As String = ""
    Public Shared strRegistrationseek As String = ""
    'Andriette 03/10/2013 skep hierdie addisionele velde sodat die premie altyd reg bereken kan word
    Public Shared lblForm1HuisSubTotaal As Label
    Public Shared lblForm1MotorSubTotaal As Label
    Public Shared lblForm1AlleRisikoSubTotaal As Label
    Public blneditmode As Boolean = False
    'Andriette 17/02/2014 haal uit
    'Kobus 05/12/2013 voegby - nodig by delete van huise en voertuie
    '  Public blnVee_Uit As Boolean ' 
    Public blnExitWithError As Boolean = False
    Private dteAfsluitDatum As Date
    'Andriette 06/03/2014 
    Dim blnLoaded As Boolean = False
    Dim strPolVeldFokus As String = ""
    'Kobus 30/07/2014 voegby om Voice Monitor te doen
    'Public strInformation As System.IO.FileInfo
    Public strInformation As String
    Public strTeks As String
    Public watchfolder = New System.IO.FileSystemWatcher()
    Public blnStopWatch As Boolean
    '   Dim ListView1 As Array

    Private Sub Form1_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        '  MsgBox("Poldata1 activated")
        VoiceMonitor()
        If strPolVeldFokus <> Nothing Then
            If strPolVeldFokus <> "" Then
                Me.ActiveControl.Name = strPolVeldFokus
            End If
        End If

        If (blnLoading = False) And (blnClear_s = False) Then
            If Me.POLISNO.Text <> "" And strPolvankontant = "1" Then
                command8_Click(Command8, New System.EventArgs())
                strPolvankontant = "0"
            End If
        End If
    End Sub
    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        VoiceMonitor()
        dat_tyd_verifikasie()
        lblTime.Text = String.Format(Now, "dd/MM/yyyy HH:MM")
        blnLoading = True
        Dim tak_hoof As New AreaEntity
        If VerifyTheLogin() Then
            InitPol()
            Clear_Values()
            posbestemming.DataSource = ListPOSBESTEMMING(1)
            ShareObjectsForm1()
        Else
            Close()
            Exit Sub
        End If
        dgvPoldataVoertuie.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPoldata1Eiendomme.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPoldata1AlleRisikoItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        If Not blnLoading And Not IsNothing(Persoonl) Then
            If POLISNO.Text <> "" And Persoonl.POLISNO <> "" Then
                btnSelfoonPremie.Text = cellphoneGetTotalPremium(Persoonl.POLISNO)
            End If
        End If
        'Initialiseer datm van en tot op kontant ontvangstes
        jaar_tot_n = 0
        jaar_van_n = 0

        'Check for programmers and grant access
        If Gebruiker.titel = "Programmeerder" Then
            Me.mnuAdmin.Visible = True
            Me.mnuDetailSearch.Visible = True
            Me.mnuStelselFunksies.Visible = True
            Me.her_pol_premies.Visible = True
        ElseIf Gebruiker.titel = "Besigtig" Then
            Me.mnuAdmin.Visible = False
            Me.mnuDetailSearch.Visible = False
            Me.mnuStelselFunksies.Visible = False
            Me.her_pol_premies.Visible = False
        Else
            Me.mnuAdmin.Visible = False
            Me.mnuDetailSearch.Visible = True
            Me.mnuStelselFunksies.Visible = True

            Me.her_pol_premies.Visible = True
        End If

        If Gebruiker.titel <> "Programmeerder" Then
            AREA.Enabled = True
        End If

        Me.Timer1.Interval = 15000
        Me.Timer1.Enabled = True
        Me.lblTermynStatus.Text = ""

        Me.ADRES2.Text = Format(Me.ADRES2.Text, "0000")

        If tak_hoof.Tak_Naam = "Potchefstroom" Then
            Me.PERS_NOM.MaxLength = 8
        End If

        VERSEKERDE.Focus()

        blnLoading = False
        blnchange = False
    End Sub
    Private Sub ADRES_Enter(sender As Object, e As System.EventArgs) Handles ADRES.Enter
        If (blnByvoeg Or blnPol_Byvoeg) And ADRES.Text.ToUpper = "STREET ADDRESS" Then
            ADRES.Text = ""
        End If
    End Sub

    Public Sub ADRES_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ADRES.TextChanged
        If (blnLoading = False) And (blnClear_s = False) Then 'And Not (pol_byvoeg Or Byvoeg) Then
            blnchange = True
        End If
    End Sub
    Public Sub ADRES_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ADRES.Leave
        Dim strposadres As String = ""

        'Andriette 19/05/2014 gaan uit as cancel
        If BtnCancel.Focused Then
            Exit Sub
        End If
        'Andriette 24/02/2014 redesign

        If blnchange Then
            If ADRES.TextLength < 1 Then
                MsgBox("The Address field must be entered.", MsgBoxStyle.Critical)
                ADRES.Focus()
                Exit Sub
            End If
            If (blnByvoeg Or blnPol_Byvoeg) Then
                'Andriette toets om te kyk of dit gevul is, kan nie uitgaan as dit nie is nie

                If blnSavedNew Then

                    UpdatePersoonlPerField("ADRES", ADRES.Text.Trim)
                Else
                    'Andriette 07/04/2014 net as dit nognie reeds gesave is nie
                    ToetsNoodsaaklik()
                End If

            Else
                strposadres = Persoonl.ADRES
                If IsDBNull(strposadres) Then
                    strposadres = " "
                End If
                UpdatePersoonlPerField("ADRES", ADRES.Text.Trim)
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & (strposadres) & ") na (" & Trim(Me.ADRES.Text) & ")"
                Else
                    BESKRYWING = " change from (" & (strposadres) & ") to (" & Trim(Me.ADRES.Text) & ")"
                End If

                UpdateWysig(2, BESKRYWING)

            End If
            UpdateCLRSField("A", (Me.POLISNO).Text)
            blnchange = False
        End If
    End Sub

    Private Sub ADRES1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ADRES1.GotFocus
        MsgBox("Please make use of the Postalcode button", MsgBoxStyle.Exclamation)
        Me.btnPostalCodes.Focus()
    End Sub
    Public Sub ADRES1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ADRES1.TextChanged
        If (blnLoading = False) And (blnClear_s = False) Then
            blnchange = True
        End If
    End Sub
    'Andriette 20/05/2014 haal uit want dit word elders hanteer
    Public Sub ADRES1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ADRES1.Leave
        Dim strposadres1 As String
        If (Not (blnLoading)) And (Not (blnClear_s)) Then
            If Not IsNothing(Persoonl) And POLISNO.Text <> "" Then
                If blnchange And Not (blnPol_Byvoeg Or blnByvoeg) Then
                    strposadres1 = Persoonl.ADRES1
                    UpdatePersoonlPerField("ADRES1", ADRES1.Text.Trim)

                    If IsDBNull(strposadres1) Then
                        strposadres1 = " "
                    End If

                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = " wysig vanaf (" & (strposadres1) & ") na (" & Trim(Me.ADRES1.Text) & " Adres1 leave)"
                    Else
                        BESKRYWING = " change from (" & (strposadres1) & ") to (" & Trim(Me.ADRES1.Text) & " Adres1 leave)"
                    End If
                    UpdateWysig(2, BESKRYWING)
                    UpdateCLRSField("A", glbPolicyNumber)
                    blnchange = False
                    Exit Sub

                End If
            End If
        End If
    End Sub

    Private Sub ADRES2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ADRES2.Click
        If MsgBox("Please make use of the Postalcode button to fill the postalcode", MsgBoxStyle.Exclamation) = MsgBoxResult.Ok Then
            Me.btnPostalCodes.Focus()
            Exit Sub
        Else
            Me.btnPostalCodes.Focus()
            Exit Sub
        End If

    End Sub
    Public Sub ADRES2_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ADRES2.TextChanged
        'Andriette 30/10/2013 sluit nuwe polisse uit
        'Andriette moenie nuwe polisse uitsluit nie
        If (blnLoading = False) And (blnClear_s = False) Then 'And Not (pol_byvoeg Or Byvoeg) Then
            blnchange = True
        End If
    End Sub
   
    Public Sub ADRES2_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ADRES2.Leave
        Dim strposadres2 As String = ""
        Dim strPosadres1 As String = ""

        If blnchange Then
            strposadres2 = Persoonl.ADRES2
            strPosadres1 = Persoonl.ADRES1

            If IsDBNull(strposadres2) Then
                strposadres2 = " "
            End If

            If (blnPol_Byvoeg Or blnByvoeg) Then
                If blnSavedNew Then
                    UpdatePersoonlPerField("ADRES2", ADRES2.Text.Trim)
                    'Andriette verander die adres 1 - stad of dorp ook as die poskode verander
                    UpdatePersoonlPerField("Adres1", ADRES1.Text.Trim)
                Else
                    'Andriette 22/04/2014 toets vir noodsaaklik
                    ToetsNoodsaaklik()
                End If
            Else
                UpdatePersoonlPerField("ADRES2", ADRES2.Text.Trim)
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & (strposadres2) & ") na (" & Trim(Me.ADRES2.Text) & ")"
                Else
                    BESKRYWING = " change from (" & (strposadres2) & ") to (" & Trim(Me.ADRES2.Text) & ")"
                End If
                UpdateWysig(2, BESKRYWING)
                'Dorp of stad inligting
                UpdatePersoonlPerField("Adres1", ADRES1.Text.Trim)
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & (strPosadres1) & ") na (" & Trim(Me.ADRES1.Text) & ")"
                Else
                    BESKRYWING = " change from (" & (strPosadres1) & ") to (" & Trim(Me.ADRES1.Text) & ")"
                End If
                UpdateWysig(2, BESKRYWING)
            End If
            UpdateCLRSField("A", (Me.POLISNO).Text)
            blnchange = False
        End If

    End Sub

    Private Sub ADRES3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ADRES3.Click
    End Sub
    Private Sub ADRES3_Enter(sender As Object, e As System.EventArgs) Handles ADRES3.Enter
        If MsgBox("The suburb and postal code must be entered. Please use the postal code list to select it.", MsgBoxStyle.Exclamation) = MsgBoxResult.Ok Then
        End If
    End Sub

    Public Sub ADRES3_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ADRES3.TextChanged
        'Andriette 30/10/2013 sluit die nuwe polisse uit
        'Andriette 24/02/2014 sluit nuwe polisse nie uit nie
        If (blnLoading = False) And (blnClear_s = False) Then
            blnchange = True
        End If
    End Sub
    
    Public Sub ADRES3_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ADRES3.Leave
        Dim strPosAdres3 As String = ""

        If blnchange Then
            If (blnByvoeg Or blnPol_Byvoeg) Then
                If blnSavedNew Then
                    UpdatePersoonlPerField("ADRES3", ADRES3.Text.Trim)
                Else
                    'Andriette 07/04/2014 net as dit nognie gesave is nie
                    ToetsNoodsaaklik()
                End If

            Else
                strPosAdres3 = Persoonl.adres3
                UpdatePersoonlPerField("ADRES3", ADRES3.Text.Trim)

                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & (strPosAdres3) & ") na (" & Trim(Me.ADRES3.Text) & ")"
                Else
                    BESKRYWING = " change from (" & (strPosAdres3) & ") to (" & Trim(Me.ADRES3.Text) & ")"
                End If
                UpdateWysig(2, BESKRYWING)
            End If
            UpdateCLRSField("A", (Me.POLISNO).Text)
            blnchange = False
        End If

    End Sub

    Private Sub adres4_Enter(sender As Object, e As System.EventArgs) Handles adres4.Enter
        If blnPol_Byvoeg Or blnByvoeg And adres4.Text.ToUpper = "STREET ADDRESS" Then
            adres4.Text = ""
        End If
    End Sub
    Private Sub Adres4_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles adres4.TextChanged
        If (blnLoading = False) And (blnClear_s = False) Then 'And Not (pol_byvoeg Or Byvoeg) Then
            blnchange = True
        End If
    End Sub
    Private Sub adres4_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles adres4.Leave
        Dim strPosAdres As String = ""
        'Andriette 30/10/2013 sluit nuwe polisse uit
        If IsDBNull(strPosAdres) Then
            strPosAdres = " "
        End If
        If blnchange Then
            If (blnByvoeg Or blnPol_Byvoeg) Then
                If blnSavedNew Then
                    UpdatePersoonlPerField("ADRES4", adres4.Text & "")
                End If
            Else
                strPosAdres = Persoonl.Adres4
                UpdatePersoonlPerField("ADRES4", adres4.Text & "")

                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & (strPosAdres) & ") na (" & Trim(Me.adres4.Text) & ")"
                Else
                    BESKRYWING = " change from (" & (strPosAdres) & ") to (" & Trim(Me.adres4.Text) & ")"
                End If
                UpdateWysig(2, BESKRYWING)
            End If
            UpdateCLRSField("A", (Me.POLISNO).Text)
            blnchange = False
        End If
    End Sub
    'Andriette 28/02/2014 toets om te dien of die area geselekteer is op die nuwe polis
    Private Sub AREA_Leave(sender As Object, e As System.EventArgs) Handles AREA.Leave
        If blnByvoeg Or blnPol_Byvoeg Then
            If BtnCancel.Focused Then
                Exit Sub
            End If
            If AREA.SelectedItem Is Nothing Then
                MsgBox("The Area must be selected.", MsgBoxStyle.Critical)
                AREA.Focus()
                Exit Sub

            End If
        End If
    End Sub
    Private Sub area_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AREA.SelectedIndexChanged
        Dim dbltmpPremie As Double
        ' Dim persarea As Object
        '  Dim inti As Object
        Dim blnGaanNaBetWyse As Boolean = False

        ' Andriette 07/03/2013 Comment ongebruikte var's
        'Dim sSql As Object
        Dim item As New ComboBoxEntity
        If BtnCancel.Focused Then
            Exit Sub
        End If
        If Not (blnLoading) And (blnClear_s = False) Then
            item = Me.AREA.SelectedItem
            If (blnByvoeg Or blnPol_Byvoeg) Then

                If item.ComboBoxName.Trim = "Not Available" Then
                    MsgBox("This option may not be selected", MsgBoxStyle.Information)
                    blnClear_s = True
                    AREA.SelectedIndex = intHuidigearea
                    Exit Sub
                End If
            End If
            'Andriette 15/04/2014 moet die tak ook toets
            'If item.ComboBoxID = 2 Then
            '    PictureBox16.Visible = True
            'End If
        End If
        'Andriette 15/04/2014 
        'Andriette 26/03/2014 Toets vir PUKKIE en as PUKKE gekies het moet dit die personeel nommer verpligtend maak
        'Andriette 02/10/2013 toets vir die nuwe polis en stel die veranderlike wat kyk of al die noodsaaklike velde gevul is
        If (blnByvoeg Or blnPol_Byvoeg) And AREA.SelectedIndex > -1 And Not blnClear_s Then
            '    If Gebruiker.titel = "Programmeerder" Then
            ' UpdatePersoonlPerField("Area", item.ComboBoxID)
            'Andriette 07/04/2014 net as dit nognie gesave is nie
            If Not blnSavedNew Then
                ToetsNoodsaaklik()
            End If

            Persoonl.BET_WYSE = ""
            Persoonl.TAAL = 1
            item = AREA.SelectedItem
            Persoonl.Area = item.ComboBoxID
            Persoonl.GEKANS = False

            Bet_Wyse.ShowDialog()

            If blnPol_Byvoeg Or blnByvoeg Then
                btnPremieDetail.Enabled = False
            End If
            Select Case Persoonl.BET_WYSE
                Case 1
                    lbltipepolis.Text = "Monthly Cash"
                    lbltipepolis.Visible = True
                    grpTermynInligting.Visible = False
                Case 2
                    lbltipepolis.Text = "Annually Cash"
                    lbltipepolis.Visible = True
                    grpTermynInligting.Visible = False
                Case 3
                    lbltipepolis.Text = "Monthly Salary"
                    lbltipepolis.Visible = True
                    grpTermynInligting.Visible = False
                Case 4
                    lbltipepolis.Text = "Monthly Debit"
                    lbltipepolis.Visible = True
                    grpTermynInligting.Visible = False
                Case 5
                    lbltipepolis.Text = "Monthly Electronic"
                    lbltipepolis.Visible = True
                    grpTermynInligting.Visible = False
                Case 6
                    lbltipepolis.Text = "Term Policy"
                    grpTermynInligting.Visible = True
                    lbltermynperiode.Text = ""
                    lbltermynmaande.Text = ""
                    lblTermynStatus.Text = ""
                    lbltipepolis.Visible = False
                    grpTermynInligting.Text = "Term Policy"
                Case Else
            End Select
            'Andriette kry die laaste aflsuit datum volgens die betaalwyse
            If blnByvoeg Or blnPol_Byvoeg Then
                dteAfsluitDatum = pldKryAfsluitDatum(Persoonl.BET_WYSE)
                poldata1_DefaultFirstPaydate(dteAfsluitDatum, 1)
            End If

        End If

        If Not IsNothing(Persoonl) And POLISNO.Text <> "" Then

            Dim blnUserHasAccessToBranch As Boolean
            Dim intPreviousBetWyse As Integer
            Dim strPukDescription As String
            Dim strAreaHuidig As String
            Dim tak_hoof As AreaEntity
            Dim strRsSqlVersekeraar As String
            Dim intAreaIndeks As Integer
            item = Me.AREA.SelectedItem
            'Andriette 22/08/2013 voeg die entity by sodat daar getoets kan word op watter stelsel ingeteken is Area vs betaalwyse MM PUK
            Dim takdetail As New TakEntity
            'Andriette 22/08/2013 vul die entity uit die tabel uit
            takdetail = FetchTakForsalaries() 'Andriette 22/08/2013 dit lyk miskien snaaks maar daar is geen salaris parameters in die funksie nie
            intAreaIndeks = item.ComboBoxID
            tak_hoof = FetchAreaPerAreaKode(intAreaIndeks)

            strAreaHuidig = 0
            'Andriette 15/04/2014 
            If item.ComboBoxID = 2 Then
                PictureBox16.Visible = True
            End If
            If Not (blnLoading) And (blnClear_s = False) Then
                If Persoonl.Area = Nothing Then
                    Persoonl.Area = 0
                End If
                ' Andriette 06/05/2013 verander vir die nuwe comboboxes 
                If (Persoonl.Area <> intAreaIndeks) Or (IsDBNull(Persoonl.Area)) Then
                    strAreaHuidig = Persoonl.Area
                    strRsSqlVersekeraar = FetchVersekeraarSQL(AREA.SelectedValue)

                    If strRsSqlVersekeraar <> "" Then
                        If Persoonl.Area = Nothing Then
                            Persoonl.Area = "0"
                        End If
                        If Me.lblVersekeraar.Text = strRsSqlVersekeraar Or Persoonl.Area = "0" Then

                            'A user may only select those branches that he has access for
                            blnUserHasAccessToBranch = False
                            For intTeller = 1 To UBound(arrglbUserBranchCodes)
                                ' Andriette 06/05/2013 Verander die Comboboxes
                                'If (AREA.SelectedIndex + 1) = inti Then
                                If (intAreaIndeks) = intTeller Then
                                    blnUserHasAccessToBranch = True
                                    Exit For
                                End If
                            Next
                            If blnUserHasAccessToBranch = False Then
                                MsgBox("This area may not be selected because you do not have authorization.", MsgBoxStyle.Information)
                                'AREA.SelectedIndex = Val(Persoonl.Area) - 1
                                ' Andriette 06/05/2013 Stel terug na die vorige
                                Me.AREA.SelectedIndex = GetComboIndex(Persoonl.Area.Trim, Me.AREA.DataSource)
                                Exit Sub
                            End If

                            Me.Combo1.Enabled = True
                            Me.Check1.Enabled = True
                            Me.txtLiabilityPrem.Enabled = True
                            Me.Plip.Enabled = True
                            Me.plip2.Enabled = True
                            ' Andriette 28/05/2013 verander van ;n label na ;n textbox
                            Me.txtCourtesyPrem.Enabled = True
                            Me.txtRoadsidePrem.Enabled = True
                            Me.lblPakket1Prem.Enabled = True
                            Me.txtPakketitem2.Enabled = True
                            Me.txthomeAsstPrem.Enabled = True

                            Select Case tak_hoof.Tak_Naam
                                Case "Potchefstroom"
                                    Select Case AREA.SelectedIndex
                                        Case 4, 5, 6, 8
                                            MsgBox("The area is not available", 48, "Fout!")

                                            AREA.SelectedIndex = intHuidigearea
                                            AREA.Focus()
                                            Exit Sub
                                        Case Else
                                            GoTo edit_pers
                                    End Select

                                Case "Vaaldriehoek"
                                    Select Case AREA.SelectedIndex
                                        Case 0, 1, 2, 3, 4, 7, 8, 9, 10, 11, 12, 13, 14, 15
                                            MsgBox("Area is not available, area was returned to what it was ...", 48, "Fout!")


                                            AREA.SelectedIndex = intHuidigearea

                                            AREA.Focus()
                                            Exit Sub
                                        Case Else
                                            GoTo edit_pers
                                    End Select

                                    'nuwe area vir vanderbijlpark
                                Case "Riemland"
                                    Select Case AREA.SelectedIndex
                                        Case 8, 4
                                            MsgBox("Area is not available, area was returned to what it was ...", 48, "Fout!") 'El 13/6/2002
                                            AREA.SelectedIndex = intHuidigearea
                                            AREA.Focus()
                                            Exit Sub
                                        Case Else
                                            GoTo edit_pers
                                    End Select
                            End Select

edit_pers:

                            '     persarea = Persoonl.Area

                            'An area change to MM Puk must change the payment method to MS (3)
                            'Andriette 22/08/2013 Area vs Betaalwyse
                            'If tak_hoof.Tak_Naam = "Flagship" Then
                            If takdetail.TAKNAAM = "Flagship" Then
                                'Andriette maak die toets reg
                                'If Me.AREA.Items(Me.AREA.SelectedIndex) = getAreaCode("MM Puk") Then 'MM Puk
                                If Me.AREA.SelectedValue = getAreaCode("MM Puk") Then 'MM Puk
                                    'Set current betWyse for policy
                                    intPreviousBetWyse = Persoonl.BET_WYSE
                                    Persoonl.BET_WYSE = 3
                                    'Andriette 07/06/2013 verander die taal na engels
                                    'Me.txtTipePolis.Text = "Maandeliks salaris"
                                    Me.lbltipepolis.Text = "Monthly Salary"
                                    BetWyseAlteration(intPreviousBetWyse)
                                    'Andriette 22/08/2013 update dan die betaalwyse
                                    UpdatePersoonlPerField("Bet_Wyse", "3")
                                    'Andriette 29/08/2013 verander die boodskap 
                                    Dim strBoodskap As String = ""
                                    strBoodskap = "Since you changed the area to " & AREA.Text & ", the payment method was changed to Monthly Salary." & Chr(10)
                                    strBoodskap = strBoodskap & "Please complete a personnel number for this client."
                                    MsgBox(strBoodskap, MsgBoxStyle.Information)
                                    Me.PERS_NOM.Focus()
                                Else
                                    'An area code from MM Puk to another area must warn the user to change the payment method from 'Monthly salary'
                                    strPukDescription = "MM Puk"
                                    If intGlbPreviousAreaCode = getAreaCode(strPukDescription) Then
                                        '  MsgBox("Since this policy area has changed from " & strPukDescription & ",that only contain 'Monthly salary policies', the payment method should probably change.", MsgBoxStyle.Information)
                                        MsgBox("Since you have changed the area, please check the payment method", MsgBoxStyle.Information)
                                        Me.lbltipepolis.Text = ""
                                    End If

                                    'Andriette 05/09/2013 gaan na die betaalwyse skerm

                                    blnGaanNaBetWyse = True
                                End If
                            End If 'If tak_hoof = "Flagship" Then
                            'Andriette 27/08/2013 verander om nie die index nie maar die waarde te dra
                            'glbPreviousAreaCode = (Me.AREA.SelectedIndex)
                            intGlbPreviousAreaCode = AREA.SelectedValue
                            ' Andriette 06/05/2013 verander die Comboboxes na die nuwe entity kode
                            'Dim areaVar As Integer
                            'areaVar = Me.AREA.SelectedIndex + 1

                            UpdatePersoonlPerField("AREA", intAreaIndeks)

                            'UpdatePersoonlPerField("AREA", Me.AREA.SelectedIndex + 1)
                            If Persoonl.TAAL = Nothing Then
                                Persoonl.TAAL = "0"
                            End If
                            If Persoonl.TAAL = 0 Then
                                BESKRYWING = " wysig na (" & (AREA.Text) & ")"
                            Else
                                BESKRYWING = " change to (" & (AREA.Text) & ")"
                            End If

                            UpdateWysig(1, BESKRYWING)

                            Dim strRsVersekeraar As String
                            ' Andriette 06/05/2013 Verander aan die comboboxes na die nuwe entity kode

                            'rsVersekeraar = FetchVersekeraarSQL(areaVar)
                            strRsVersekeraar = FetchVersekeraarSQL(intAreaIndeks)

                            Me.lblVersekeraar.Text = strRsVersekeraar
                            ' Andriette 06/05/2013 Verander aan die Comboboxes na die nuwe entity kode
                            'getGlbPakketItems(areaVar)
                            getGlbPakketItems(intAreaIndeks)

                            intHuidigearea = Me.AREA.SelectedIndex
                            If strAreaHuidig = Nothing Then
                                strAreaHuidig = 0
                            End If
                            If strAreaHuidig <> "0" Then
                                UpdateEndos2001(strAreaHuidig, "Delete")
                            End If

                            UpdateEndos2001(AREA.SelectedIndex + 1, "Insert")

                            'vir alle areas behalwe G/Cus
                            If Persoonl.Area <> "E" Then
                                ' Andriette 14/06/2013 Hierdie funksie roep roep na die verkeerde tabel en veld
                                ' dit moet van die constants af kom
                                ' Haal die roep uit en gebruik die constants entity
                                ' FetchEPCValue()

                                ' Me.txthomeAsstPrem.Text = FormatNumber(nepc, 2)
                                'Me.EPC.Text = FormatNumber(Me.EPC.Text, 2)
                                Me.txthomeAsstPrem.Text = FormatNumber(Constants.EPC, 2)
                            Else
                                Me.txthomeAsstPrem.Text = "0.00"
                            End If

                            If (Persoonl.PakketItem1 <> 0) And Persoonl.Area = "E" Then
                                ' Andriette 09/04/2013 verander die formatering na ;n behoorlike funksieroep
                                'Me.txtPakketItem1.Text = Format(0, "#0.00") 
                                Me.lblPakket1Prem.Text = FormatNumber(0, 2)
                                dbltmpPremie = Persoonl.PakketItem1

                                UpdatePersoonlPerField("PakketItem1", CDbl(lblPakket1Prem.Text))

                                If Persoonl.TAAL = 0 Then
                                    BESKRYWING = "vanaf (" & FormatNumber(dbltmpPremie, 2) & ") na (" & (lblPakket1Prem).Text & ")"
                                Else
                                    BESKRYWING = "from (" & FormatNumber(dbltmpPremie, 2) & ") to (" & (lblPakket1Prem).Text & ")"
                                End If
                                UpdateWysig((189), BESKRYWING)
                                'Andriette 06/06/2014 
                                BFUpdateItemsSubTotals(glbPolicyNumber)
                                'Andriette 24/10/2013 alles geskuif na herbereken premie
                                'doen_subtotaal()

                                HerBereken_Premie()
                                If CDbl(strAreaHuidig) <> 0 Then
                                    ' Andriette 30/05/2013 Verander Domestic worker na Labour Insurance
                                    'MsgBox("Please note that this policy had Labour Insurance cover, and it was removed.", MsgBoxStyle.Exclamation)
                                    'Andriette 30/05/2013 verander die boodskap heeltemal
                                    MsgBox("Some of the extras specific to an area may be affected by the change. It may also affect the final premium", MsgBoxStyle.Exclamation)
                                End If
                            ElseIf Persoonl.PakketItem1 <> dblglbPakketItem1Premie Then
                                ' Andriette 09/04/2013 verander die formatering na 'n behoorlike funksieroep
                                'Me.txtPakketItem1.Text = Format(glbPakketItem1Premie, "#0.00") 
                                Me.lblPakket1Prem.Text = FormatNumber(dblglbPakketItem1Premie, 2)
                                dbltmpPremie = FormatNumber(Persoonl.PakketItem1, 2)

                                UpdatePersoonlPerField("PakketItem1", CDbl(lblPakket1Prem.Text))

                                If Persoonl.TAAL = 0 Then
                                    BESKRYWING = "vanaf (" & FormatNumber(dbltmpPremie, 2) & ") na (" & (lblPakket1Prem).Text & ")"
                                Else
                                    BESKRYWING = "from (" & FormatNumber(dbltmpPremie, 2) & ") to (" & (lblPakket1Prem).Text & ")"
                                End If
                                UpdateWysig(189, BESKRYWING)
                                'Andriette 06/06/2014 
                                BFUpdateItemsSubTotals(glbPolicyNumber)
                                'Andriette 24/10/2013 alles geskuif na herbereken premie
                                ' doen_subtotaal()
                                HerBereken_Premie()

                                If CDbl(strAreaHuidig) <> 0 Then
                                    ' Andriette 30/05/2013 verander die boodskap
                                    'MsgBox("The Domestic Worker cover can be affected by the change. It can also affect the final premium.", MsgBoxStyle.Exclamation)
                                    MsgBox("Some of the extras specific to an area may be affected by the change. It may also affect the final premium", MsgBoxStyle.Exclamation)
                                End If
                            End If

                            If (Persoonl.PakketItem2 <> 0) And Persoonl.Area = "E" Then
                                Me.txtPakketitem2.Text = Format(0, "#0.00")
                                dbltmpPremie = Persoonl.PakketItem2

                                UpdatePersoonlPerField("PakketItem2", CDbl(txtPakketitem2.Text))

                                If Persoonl.TAAL = 0 Then
                                    BESKRYWING = "vanaf (" & FormatNumber(dbltmpPremie, 2) & ") na (" & (txtPakketitem2).Text & ")"
                                Else
                                    BESKRYWING = "from (" & FormatNumber(dbltmpPremie, 2) & ") to (" & (txtPakketitem2).Text & ")"
                                End If
                                UpdateWysig((193), BESKRYWING)
                                'Andriette 06/06/2014 
                                BFUpdateItemsSubTotals(glbPolicyNumber)
                                'Andriette 24/10/2013 alles geskuif na herbereken premie
                                'doen_subtotaal()
                                HerBereken_Premie()

                                If CDbl(strAreaHuidig) <> 0 Then
                                    MsgBox("Please note that this policy Brokerage and had it removed.", MsgBoxStyle.Exclamation)
                                End If
                            ElseIf Persoonl.PakketItem2 <> dblglbPakketItem2Premie Then
                                Me.txtPakketitem2.Text = Format(dblglbPakketItem2Premie, "#0.00")
                                dbltmpPremie = Persoonl.PakketItem2
                                UpdatePersoonlPerField("PakketItem2", CDbl(txtPakketitem2.Text))
                                If Persoonl.TAAL = 0 Then
                                    BESKRYWING = "vanaf (" & FormatNumber(dbltmpPremie, 2) & ") na (" & (txtPakketitem2).Text & ")"
                                Else
                                    BESKRYWING = "from (" & FormatNumber(dbltmpPremie, 2) & ") to (" & (txtPakketitem2).Text & ")"
                                End If
                                UpdateWysig(193, BESKRYWING)
                                'Andriette 06/06/2014 
                                BFUpdateItemsSubTotals(glbPolicyNumber)
                                'Andriette 24/10/2013 alles geskuif na herbereken premie
                                'doen_subtotaal()
                                HerBereken_Premie()

                                If CDbl(strAreaHuidig) <> 0 Then
                                    MsgBox("The Broker Fee may be affected by the change. It can also affect the final premium.", MsgBoxStyle.Exclamation)
                                End If
                            End If
                        Else
                            MsgBox("You may not change insurer, only area.")
                            If UCase(tak_hoof.Lewendig) = "J" Then
                                If IsNumeric(Persoonl.Area) Then
                                    Me.AREA.SelectedIndex = Persoonl.Area - 1
                                End If
                            End If
                        End If 'lblversekeraar
                    End If 'versekeraar eof and bof
                End If
            End If
        End If

        If Not (blnByvoeg Or blnPol_Byvoeg) And item.ComboBoxID = "2" Then
            If Not blnLoading Then
                If PERS_NOM.TextLength = 0 Then
                    MsgBox("The Personnel number is required when MM Puk is selected as the area", MsgBoxStyle.Exclamation)
                    PERS_NOM.Focus()
                    Exit Sub
                End If

                If Len(PERS_NOM.Text) <> 8 Then
                    MsgBox("The staff number should be eight characters long.", MsgBoxStyle.Information)
                    Me.PERS_NOM.Focus()
                    Exit Sub
                End If

                If PERS_NOM.Text = "00000000" Then
                    PERS_NOM.Text = "        "
                End If
            End If
        End If

        If blnGaanNaBetWyse Then
            Bet_Wyse.ShowDialog()
        End If
    End Sub

    Function FetchVersekeraarSQL(ByVal strArea) As String
        Dim strReturnValue As String = ""

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@area_kode", SqlDbType.NVarChar)}

                params(0).Value = Gebruiker.Area_kode

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchVersekeraarAndArea]", params)
                Dim item As VersekeraarEntity = New VersekeraarEntity()

                If reader.Read() Then
                    If reader("naam") IsNot DBNull.Value Then
                        strReturnValue = reader("naam")
                    End If
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
            Return strReturnValue
        Catch ex As Exception
            MsgBox(ex.Message)
            Return ""
            Exit Function
        End Try
    End Function

    'Private Sub B_Voeg_By_Click()
    '    Add_Bemarker()
    'End Sub
    'Sub Add_Bemarker()

    'End Sub

    Private Function Bereken_Sasria_waardes_op_vorm() As Double
        Dim dblpolitiek As Double = 0
        Dim dblHuise As Double = 0
        Dim dblAlleRisiko As Double = 0
        Dim dblVoertuie As Double = 0
        'Huise 
        'Andriette 17/04/2014 net as gecheck
        If Check1.Checked Then


            For Each row As DataGridViewRow In dgvPoldata1Eiendomme.Rows
                'Andriette 02/09/2013 die waardes en nie die premies moet gebruik word
                If Not IsNothing(row.Cells(3).Value) And Not IsNothing(row.Cells(5).Value) Then
                    ' Andriette 2013-02-25 verander die grid offset terug na die norm
                    'politiek = politiek + (Double.Parse(row.Cells(4).Value) + Double.Parse(row.Cells(8).Value))
                    ' politiek = politiek + (Double.Parse(row.Cells(3).Value) + Double.Parse(row.Cells(5).Value))
                    dblHuise = dblHuise + Double.Parse(row.Cells(3).Value) + Double.Parse(row.Cells(5).Value)
                End If
            Next

            For Each row As DataGridViewRow In dgvPoldata1AlleRisikoItems.Rows
                ' Andriette 2013-02-25 verander die grid offset terug na die norm
                'If Not IsNothing(row.Cells(3).Value) Then
                '    politiek = politiek + Val(row.Cells(2).Value)
                'End If
                If Not IsNothing(row.Cells(4).Value) And row.Cells(4).Value <> 0 Then
                    ' politiek = politiek + Val(row.Cells(3).Value)
                    dblAlleRisiko = dblAlleRisiko + Val(row.Cells(3).Value)
                End If
            Next

            dblpolitiek = FormatNumber((dblAlleRisiko + dblHuise) * Val(Constants.Sasria_h), 2)

            If dblpolitiek > 0 And dblpolitiek < 3 Then
                dblpolitiek = 3
            End If
            'Andriette verander die formule
            'If Grid1.RowCount <> 2 Then
            '    politiek = politiek + (Constants.MotorSasria * (Grid1.RowCount))
            'Else
            '    If Grid1.Rows(0).Cells(1).Value <> "" Then
            '        politiek = politiek + Constants.MotorSasria
            '    End If
            'End If

            If dgvPoldataVoertuie.RowCount >= 1 Then
                dblpolitiek = dblpolitiek + (Constants.MotorSasria * (dgvPoldataVoertuie.RowCount))
            End If
        Else
            dblpolitiek = 0
        End If

        Return dblpolitiek
    End Function
    Private Sub BEROEP_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BEROEP.TextChanged
        'If BEROEP.Modified = True Then
        '    change = True
        'End If
        'Andriette 30/10/2013 sluit die nuwe polisse uit
        'Andriette 20/02/214 nie toets vir byvoeg nie
        If (blnLoading = False) And (blnClear_s = False) Then ' And Not (pol_byvoeg Or Byvoeg) Then
            blnchange = True
        End If

    End Sub
    Private Sub BEROEP_GotFocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BEROEP.GotFocus
        BEROEP.SelectionStart = 0
        BEROEP.SelectionLength = Len(BEROEP.Text)
    End Sub
    Private Sub BEROEP_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BEROEP.Leave
        Dim strwerk As String = ""

        'Andriette 20/02/2014 redesign
        If blnchange Then
            If (blnByvoeg Or blnPol_Byvoeg) Then
                If blnSavedNew Then
                    UpdatePersoonlPerField("BEROEP", BEROEP.Text)
                End If
            Else
                strwerk = Persoonl.BEROEP
                UpdatePersoonlPerField("BEROEP", BEROEP.Text)
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & (strwerk) & ") na  (" & (Me.BEROEP).Text & ")"
                Else
                    BESKRYWING = " change from (" & (strwerk) & ") to (" & (Me.BEROEP).Text & ")"
                End If
                UpdateWysig(84, BESKRYWING)
            End If
            blnchange = False
        End If

    End Sub
    Private Sub Besk_nr_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If (blnLoading = False) And (blnClear_s = False) Then
            blnchange = True
        End If
    End Sub
    Private Sub BET_DAT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BET_DAT.Leave
        Dim strBetaalDat As String

        'Aanvangsdatum moet ingevul wees
        If Len(BET_DAT.Text) = 0 Then
            MsgBox("A date is required", 48, "Invalid first payment date")
            Exit Sub
        End If
        'Aanvangsdatum moet n datum wees
        If Len(BET_DAT.Text) <> 0 Then
            If Not IsDate(BET_DAT.Text) Then
                MsgBox("A valid date is required.", 48, "Invalid first payment date")
                BET_DAT.Text = ""
                BET_DAT.Focus()
                Exit Sub
            End If
        End If

        'Andriette 30/10/2013 sluit nuwe polisse uit
        If blnchange And Not (blnPol_Byvoeg Or blnByvoeg) Then
            'P_A_DAT.Text = Format(P_A_DAT.Text, "dd/MM/yyyy")
            strBetaalDat = Format(Persoonl.bet_dat)
            UpdatePersoonlPerField("Bet_DAT", BET_DAT.Text)
            If Persoonl.TAAL = 0 Then
                BESKRYWING = " wysig vanaf (" & (strBetaalDat) & ") na (" & (Me.BET_DAT).Text & ")"
            Else
                BESKRYWING = " change from (" & (strBetaalDat) & ") to (" & (Me.BET_DAT).Text & ")"
            End If
            UpdateWysig(90, BESKRYWING)
            UpdateCLRSField("A", (Me.POLISNO).Text)
            blnchange = False
            Persoonl.bet_dat = BET_DAT.Text
        End If
        'Andriette 07/04/2014 net as dit nognie gesave is nie
        If (blnByvoeg Or blnPol_Byvoeg) And Not blnSavedNew Then
            ToetsNoodsaaklik()
        End If

    End Sub
    'Andriette 24/02/2014 sit by om te werk soos al die ander controls op die poldata1 skerm

    Private Sub Betaaldag_Leave(sender As Object, e As System.EventArgs) Handles Betaaldag.Leave
        Dim strAftrekdag As String = ""
        'Andriette 19/05/2014 gaan uit as cancel
        If BtnCancel.Focused Then
            Exit Sub
        End If

        If blnchange Then

            If (blnByvoeg Or blnPol_Byvoeg) Then
                If blnSavedNew Then
                    UpdatePersoonlPerField("betaaldatum", Betaaldag.SelectedIndex + 1)
                End If
            Else
                If Persoonl.betaaldatum = Nothing Then
                    Persoonl.betaaldatum = "1"
                End If
                strAftrekdag = Persoonl.betaaldatum
                strAftrekdag = Format(strAftrekdag, "00")
                'Andriette 24/04/2014

                If Persoonl.betaaldatum <> Betaaldag.SelectedIndex + 1 Then
                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = " wysig vanaf (" & Betaaldag.Items(Persoonl.betaaldatum - 1) & ") na (" & (Betaaldag.Text) & ")"

                    Else
                        BESKRYWING = " change from (" & Betaaldag.Items(Persoonl.betaaldatum - 1) & ") to (" & (Betaaldag.Text) & ")"
                    End If
                    UpdateWysig(119, BESKRYWING)
                    'Andriette 24/04/2014
                    UpdatePersoonlPerField("betaaldatum", Betaaldag.SelectedIndex + 1)
                End If
            End If
            UpdateCLRSField("A", (Me.POLISNO).Text)
            blnchange = False
        End If

    End Sub

    Private Sub Betaaldag_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Betaaldag.SelectedIndexChanged

        If Not (blnLoading) And Not (blnClear_s) Then
            blnchange = True
        End If
    End Sub

    Private Sub btnPostalCodes_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnPostalCodes.Click
        PoskodesSoek.txtFormToPopulate.Text = Me.Name
        PoskodesSoek.ShowDialog()
        If blnPol_Byvoeg Or blnByvoeg And adres4.Text.ToUpper = "STREET ADDRESS" Then
            adres4.Text = ""
        End If
    End Sub

    Private Sub btnPremieDetail_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnPremieDetail.Click
        'Andriette 18/09/2013 stel die cursor
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        PremieDetail.ShowDialog()
    End Sub

    Private Sub btnVerwyderdeItems_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnVerwyderdeItems.Click
        If intPoldataGrid_Focus = 0 Then
            MsgBox("Click on the vehicles, properties or risk list to display all deleted items .", MsgBoxStyle.Information)
        Else
            VerwyderdeItemLys.ShowDialog()
            'Andriette 06/06/2014 
            BFUpdateItemsSubTotals(glbPolicyNumber)
            HerBereken_Premie()
        End If
    End Sub

    Private Sub BYBET_K_Leave(sender As Object, e As System.EventArgs) Handles BYBET_K.Leave
        Dim strBybet As String = ""

        'Andriette 19/05/2014 gaan uit as cancel
        If BtnCancel.Focused Then
            Exit Sub
        End If

        If (blnByvoeg Or blnPol_Byvoeg) Then
            If BYBET_K.SelectedIndex = -1 Then
                MsgBox("The Excess is a required field", MsgBoxStyle.Exclamation)
                BYBET_K.Focus()
                Exit Sub
            End If
        End If

        If blnchange Then
            If blnByvoeg Or blnPol_Byvoeg Then
                If blnSavedNew Then
                    UpdatePersoonlPerField("BYBET_K", BYBET_K.SelectedIndex)
                Else
                    'Andriette 07/04/2014 net as dit nognie gesave is nie
                    ToetsNoodsaaklik()
                End If
            Else

                If Persoonl.BYBET_K <> BYBET_K.SelectedIndex Then
                    'Andriette 24/04/2014
                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = " wysig vanaf (" & BYBET_K.Items(Persoonl.BYBET_K) & ") na (" & (BYBET_K.Text) & ")"
                    Else
                        BESKRYWING = " change from (" & BYBET_K.Items(Persoonl.BYBET_K) & ") to (" & (BYBET_K.Text) & ")"
                    End If
                    UpdateWysig(3, BESKRYWING)
                    'Andriette 24/04/2014
                    UpdatePersoonlPerField("BYBET_K", BYBET_K.SelectedIndex)
                End If
            End If
            blnchange = False
        End If
    End Sub
    Private Sub BYBET_K_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BYBET_K.SelectedIndexChanged
        'Andriette 24/02/2014 redesign

        If Not blnLoading And Not blnClear_s Then
            blnchange = True
        End If
    End Sub

    'Andriette 12/08/2014 haal uit word nie meer gebruik nie
    '    Public Sub care_assist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles care_assist.Click
    '        Dim strCare_na As String
    '        Dim strCare_voor As Object
    '        Dim strBeskrywing As Object
    'lees_weer:

    '        If careassist.Text = "" Then
    '            strBeskrywing = InputBox("What is the Care Assist premium ?", "Mooirivier Noodhulp Diens ...", "0.00")
    '        Else
    '            strBeskrywing = InputBox("What is the Care Assist premium ?", "Mooirivier Noodhulp Diens ...", careassist.Text)
    '        End If

    '        'premie moet numeries wees
    '        If Len(strBeskrywing) > 0 Then
    '            If (Not (IsNumeric(strBeskrywing))) Then
    '                MsgBox("The Care Assist premium is not numerically")
    '                GoTo lees_weer
    '            End If
    '        End If
    '        If (strBeskrywing <> "") Or (strBeskrywing <> careassist.Text) Then
    '            careassist.Text = Format(strBeskrywing, "0.00")
    '        End If

    '        strCare_voor = Persoonl.careassist
    '        strCare_na = careassist.Text

    '        UpdatePersoonlPerField("careassist", careassist.Text)

    '        If Persoonl.TAAL = 0 Then
    '            BESKRYWING = " na " & careassist.Text
    '        Else
    '            BESKRYWING = " to " & careassist.Text
    '        End If
    '        UpdateWysig(95, BESKRYWING)
    '        'Andriette 06/06/2014 
    '        BFUpdateItemsSubTotals(glbPolicyNumber)
    '        'Andriette 24/10/2013 alles geskuif na herbereken premie
    '        'doen_subtotaal()
    '        HerBereken_Premie()
    '    End Sub

   
    Private Sub txtRoadsidePrem_GotFocus(sender As Object, e As System.EventArgs) Handles txtRoadsidePrem.GotFocus
        Me.txtRoadsidePrem.BackColor = System.Drawing.Color.White
    End Sub

    Private Sub txtRoadsidePrem_LostFocus(sender As Object, e As System.EventArgs) Handles txtRoadsidePrem.LostFocus
        Me.txtRoadsidePrem.BackColor = System.Drawing.Color.Silver
    End Sub
    'Andriette 21/02/2014 voeg by om te werk soos al die ander
    Private Sub txtRoadsidePrem_TextChanged(sender As Object, e As System.EventArgs) Handles txtRoadsidePrem.TextChanged
        If Not blnLoading And Not blnClear_s Then
            blnchange = True
        End If
    End Sub

    ' Andriette 12/06/2013 verander die change event na 'n leave event sodat die hele verandering geevalueer kan word
    Private Sub txtRoadsidePrem_Leave(sender As Object, e As System.EventArgs) Handles txtRoadsidePrem.Leave
        Dim strCare As String = ""

        If blnchange Then

            txtRoadsidePrem.Text = FormatNumber(Val(txtRoadsidePrem.Text), 2)
            If txtRoadsidePrem.Text.Trim = "" Then
                txtRoadsidePrem.Text = "0.00"
            End If

            If (blnByvoeg Or blnPol_Byvoeg) Then
                If blnSavedNew Then
                    UpdatePersoonlPerField("careassist", txtRoadsidePrem.Text)
                End If
            Else
                strCare = Persoonl.careassist
                UpdatePersoonlPerField("careassist", txtRoadsidePrem.Text)
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & strCare & ") na (" & (Me.txtRoadsidePrem).Text & ")"
                Else
                    BESKRYWING = " change from (" & strCare & ") to (" & (Me.txtRoadsidePrem).Text & ")"
                End If

                UpdateWysig(95, BESKRYWING)
            End If
            'Andriette 06/06/2014 
            BFUpdateItemsSubTotals(glbPolicyNumber)
            HerBereken_Premie()
            blnchange = False

            If Val(txtRoadsidePrem.Text) > 0 And dgvPoldataVoertuie.RowCount = 0 Then
                MsgBox("There is no vehicle insured on this policy.", MsgBoxStyle.Information)
            End If
        End If

        Me.txtRoadsidePrem.BackColor = System.Drawing.ColorTranslator.FromOle(&HC0C0C0)
    End Sub
   
    Private Sub Check1_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check1.CheckStateChanged
        Dim dblPolitiek As Double

        If (Not (blnLoading) And Not (blnClear_s)) Then
            If Not IsNothing(Persoonl) And POLISNO.Text <> "" Then
                If Check1.Checked Then
                    'Andriette 02/09/2013 verander die funksie
                    dblpolitiek = Bereken_Sasria_waardes_op_vorm()
                    'Andriette  02/09/2013 termynpolis is 6
                    'If Persoonl.BET_WYSE = "2" Then
                    If Persoonl.BET_WYSE = "6" Then
                        If MsgBox("Is the policy process to be converted to a term policy?", vbYesNo) = vbNo Then
                            '  glbSkakelJKomTP = False
                            dblpolitiek = dblpolitiek * 12
                        Else
                            '  glbSkakelJKomTP = True
                        End If
                    End If

                    UpdatePersoonlPerField("SASPREM", FormatNumber(Val(dblPolitiek), 2))

                    Label36.Text = FormatNumber(Val(dblPolitiek), 2)

                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = "(" & (Me.Label36.Text) & ")"
                    Else
                        BESKRYWING = "(" & (Me.Label36.Text) & ")"
                    End If
                    UpdateWysig(35, BESKRYWING)
                Else
                    UpdatePersoonlPerField("SASPREM", 0)
                    Persoonl.SASPREM = 0
                    Label36.Text = "0.00"
                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = "(" & (Persoonl.SASPREM) & ")"
                    Else
                        BESKRYWING = "(" & (Persoonl.SASPREM) & ")"
                    End If
                    UpdateWysig(36, BESKRYWING)
                End If
            End If
        End If
    End Sub

    Private Sub Combo1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Combo1.SelectedIndexChanged
        Dim dblOuPers As Double = 0
        Dim strLadingBeskrywing As String = ""
        'Andriette 19/05/2014 gaan uit as cancel
        If BtnCancel.Focused Then
            Exit Sub
        End If

        If blnByvoeg Or blnPol_Byvoeg Then
            If Combo1.SelectedIndex = -1 Then
                MsgBox("The Policy discout/Loading is a required field.", MsgBoxStyle.Exclamation)
                Combo1.Focus()
                Exit Sub
            End If
        End If

        If Not (blnClear_s) And Not (blnLoading) Then
            'change = True
            If blnByvoeg Or blnPol_Byvoeg Then
                If blnSavedNew Then
                    UpdatePersoonlPerField("EISBONUS", Me.Combo1.SelectedIndex)
                    UpdatePersoonlPerField("eispers", Val(Me.Combo1.Text))
                Else
                    'Andriette 07/04/2014 net as dit nognie gesave is nie
                    ToetsNoodsaaklik()
                End If

            Else
                If MsgBox("Is the load due to a claim?", 20, "Loading.......") = 6 Then

                    If Persoonl.TAAL = 0 Then
                        strLadingBeskrywing = "(Premie belading a.g.v. eis) "
                    Else
                        strLadingBeskrywing = "(Premium loading due to claim) "
                    End If
                End If
                dblOuPers = Persoonl.eispers
                dblOuPers = FormatNumber(dblOuPers, 2)

                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & dblOuPers & ") na (" & (Combo1.Text) & ") " & strLadingBeskrywing
                Else
                    BESKRYWING = " change from (" & dblOuPers & ") to (" & (Combo1.Text) & ") " & strLadingBeskrywing
                End If
                UpdateWysig(38, BESKRYWING)
                'Andriette 14/05/2014 skryf na die entity
                UpdatePersoonlPerField("EISBONUS", Me.Combo1.SelectedIndex)
                UpdatePersoonlPerField("eispers", Val(Me.Combo1.Text))
                Persoonl.eispers = Combo1.Text
            End If
            If Not (blnByvoeg Or blnPol_Byvoeg) And blnSavedNew Then
                'Andriette 06/06/2014 
                BFUpdateItemsSubTotals(glbPolicyNumber)
                HerBereken_Premie()
            End If

            blnchange = False
        End If
    End Sub
    Private Sub Combo2_Change()
        If (Not (blnClear_s)) And (Not (blnLoading)) Then
            If Not IsNothing(Persoonl) And POLISNO.Text <> "" Then
                UpdatePersoonlPerField("POSBESTEMMING", Format(posbestemming.SelectedIndex))
            End If
        End If
    End Sub

    Private Sub txtCourtesyPrem_Click(sender As Object, e As System.EventArgs) Handles txtCourtesyPrem.Click
        Me.txtCourtesyPrem.BackColor = System.Drawing.Color.White
    End Sub

    Public Sub datum_wysig_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles datum_wysig.Click
        frmLysDatumWysig.ShowDialog()
    End Sub


    Private Sub txthomeAsstPrem_GotFocus(sender As Object, e As System.EventArgs) Handles txthomeAsstPrem.GotFocus
        Me.txthomeAsstPrem.BackColor = System.Drawing.Color.White
    End Sub


    Public Sub m_verwysdes_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles m_verwysdes.Click
        If validateFields() Then
            VerwysdesListFrm.ShowDialog()
        End If
    End Sub

    Public Sub mnu_Unblok_eise_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnu_Unblok_eise.Click
        UpdatePersoonlPerField("Eisgeblok", "0")
        MsgBox("The block of claims is now closed for this policy ...")
        mnu_Unblok_eise.Enabled = False
        UpdateWysig(185, "")
    End Sub
    Public Sub mnu_verwys_verval_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnu_verwys_verval.Click
        frmVervaldeVerwysingskommissie.ShowDialog()
    End Sub
    Public Sub mnuBankUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuBankUpdate.Click
        frmBankupdate.ShowDialog()
    End Sub
    Public Sub mnuBriefDubbelPremie_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuBriefDubbelPremie.Click
        BriefDubbelPremie.ShowDialog()
    End Sub

    Public Sub mnuLTPbriewe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuLTPbriewe.Click
        BriefLTPDetail.ShowDialog()
    End Sub
    Public Sub mnuMotorwUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        menmfrm.ShowDialog()
    End Sub
    Public Sub mnuOpdatKrediet_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuOpdatKrediet.Click
        frmKredietkaartupdate.ShowDialog()
    End Sub
    Public Sub mnuOpskort_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuOpskort.Click
        Me.intDelay = 30000 'milliseconds
        BriefOpskort.ShowDialog()
    End Sub
    Public Sub mnuPostalcodesUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuPostalcodesUpdate.Click
        frmPostalcodesUpdate.ShowDialog()
    End Sub
    Public Sub mnuSalarisAfsluitings_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        frmSalarisAfsluitings.Show()
    End Sub
    Public Sub mnuSekuriteitsvereisteBrief_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSekuriteitsvereisteBrief.Click
        BriefEiendomSekuriteit.ShowDialog()
    End Sub
    Public Sub mnuStelPremieReg_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If POLISNO.Text = "" Then
            MsgBox("You should have a policy to choose!", 48, "Error!")
            Exit Sub
        End If
        UpdateWysig(49, "")
    End Sub

    Public Sub mnuVoerWeer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuVoerWeer.Click

        If POLISNO.Text = "" Then
            MsgBox("You should have a policy to choose!", 48, "Error!")
            Exit Sub
        End If

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Gebruiker", SqlDbType.NVarChar), _
                                                New SqlParameter("@Datum", SqlDbType.DateTime), _
                                                New SqlParameter("@Beskrywing", SqlDbType.NVarChar)}

                params(0).Value = Gebruiker.Naam
                params(1).Value = Now
                params(2).Value = "Herstel Polis - Net Maandeliks salaris"

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.UpdateGebruikerLopies", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        If Persoonl.TAAL = 0 Then
            BESKRYWING = " (Voer weer by afsluiting)"
        Else
            BESKRYWING = " (Submit to Multidata)"
        End If
        UpdateWysig(40, BESKRYWING)

    End Sub

    Private Function PersoonlPerVV(ByVal Versekerde As String, ByVal Voorl As String, ByVal Branch As String)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@Verserkerde", SqlDbType.NVarChar), _
                                               New SqlParameter("@Voorl", SqlDbType.NVarChar), _
                                               New SqlParameter("@BranchCodes", SqlDbType.NVarChar)}

                param(0).Value = Versekerde
                param(1).Value = Voorl
                param(2).Value = Branch

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchPersoonlByVV]", param)
                Persoonl = New PERSOONLEntity()

                If reader.Read() Then
                    If reader("ADRES") IsNot DBNull.Value Then
                        Persoonl.ADRES = reader("ADRES")
                    End If
                    If reader("ADRES1") IsNot DBNull.Value Then
                        Persoonl.ADRES1 = reader("ADRES1")
                    End If
                    If reader("ADRES2") IsNot DBNull.Value Then
                        Persoonl.ADRES2 = reader("ADRES2")
                    End If
                    If reader("adres3") IsNot DBNull.Value Then
                        Persoonl.adres3 = reader("adres3")
                    End If
                    If reader("Adres4") IsNot DBNull.Value Then
                        Persoonl.Adres4 = reader("Adres4")
                    End If
                    If reader("aftrekdat") IsNot DBNull.Value Then
                        Persoonl.aftrekdat = reader("aftrekdat")
                    End If
                    If reader("ALLE_SUB") IsNot DBNull.Value Then
                        Persoonl.ALLE_SUB = reader("ALLE_SUB")
                    End If
                    If reader("Area") IsNot DBNull.Value Then
                        Persoonl.Area = reader("Area")
                    End If
                    If reader("ASSESOR") IsNot DBNull.Value Then
                        Persoonl.ASSESOR = reader("ASSESOR")
                    End If
                    If reader("begraf_dek") IsNot DBNull.Value Then
                        Persoonl.begraf_dek = reader("begraf_dek")
                    End If
                    If reader("BEGRAFNIS") IsNot DBNull.Value Then
                        Persoonl.BEGRAFNIS = reader("BEGRAFNIS")
                    End If
                    If reader("BEROEP") IsNot DBNull.Value Then
                        Persoonl.BEROEP = reader("BEROEP")
                    End If
                    If reader("besk_nr") IsNot DBNull.Value Then
                        Persoonl.besk_nr = reader("besk_nr")
                    End If
                    If reader("BESKERM") IsNot DBNull.Value Then
                        Persoonl.BESKERM = reader("BESKERM")
                    End If
                    If reader("bet_dat") IsNot DBNull.Value Then
                        Persoonl.bet_dat = reader("bet_dat")
                    End If
                    If reader("BET_WYSE") IsNot DBNull.Value Then
                        Persoonl.BET_WYSE = reader("BET_WYSE")
                    End If
                    If reader("betaaldatum") IsNot DBNull.Value Then
                        Persoonl.betaaldatum = reader("betaaldatum")
                    End If
                    If reader("BTWNo") IsNot DBNull.Value Then
                        Persoonl.BTWNo = reader("BTWNo")
                    End If
                    If reader("BYBET_K") IsNot DBNull.Value Then
                        Persoonl.BYBET_K = reader("BYBET_K")
                    End If
                    If reader("bybmemo") IsNot DBNull.Value Then
                        Persoonl.bybmemo = reader("bybmemo")
                    End If
                    If reader("careassist") IsNot DBNull.Value Then
                        Persoonl.careassist = reader("careassist")
                    End If
                    If reader("CLRSTypeOfAmendment") IsNot DBNull.Value Then
                        Persoonl.CLRSTypeOfAmendment = reader("CLRSTypeOfAmendment")
                    End If
                    If reader("courtesyv") IsNot DBNull.Value Then
                        Persoonl.courtesyv = reader("courtesyv")
                    End If
                    If reader("DatumEffekGekans") IsNot DBNull.Value Then
                        Persoonl.DatumEffekGekans = reader("DatumEffekGekans")
                    End If
                    If reader("DatumGekanselleer") IsNot DBNull.Value Then
                        Persoonl.DatumGekanselleer = reader("DatumGekanselleer")
                    End If
                    If reader("DatumToegevoer") IsNot DBNull.Value Then
                        Persoonl.DatumToegevoer = reader("DatumToegevoer")
                    End If
                    If reader("DEPT") IsNot DBNull.Value Then
                        Persoonl.DEPT = reader("DEPT")
                    End If
                    If reader("EISBONUS") IsNot DBNull.Value Then
                        Persoonl.EISBONUS = reader("EISBONUS")
                    End If
                    If reader("Eisgeblok") IsNot DBNull.Value Then
                        Persoonl.Eisgeblok = reader("Eisgeblok")
                    End If
                    If reader("eispers") IsNot DBNull.Value Then
                        Persoonl.eispers = reader("eispers")
                        ' Andriette 30/04/2013 Vul met 0 as te kort
                        If Persoonl.eispers.Length = 1 Then ' volgetalle
                            Persoonl.eispers = Persoonl.eispers + ".00"
                        End If
                        If Persoonl.eispers.Length = 3 Then
                            Persoonl.eispers = Persoonl.eispers + "0"
                        End If
                    End If
                    If reader("elektroniesgestuur") IsNot DBNull.Value Then
                        Persoonl.elektroniesgestuur = reader("elektroniesgestuur")
                    End If
                    If reader("EMAIL") IsNot DBNull.Value Then
                        Persoonl.EMAIL = reader("EMAIL")
                    End If
                    If reader("epc") IsNot DBNull.Value Then
                        Persoonl.epc = reader("epc")
                    End If
                    If reader("FAX") IsNot DBNull.Value Then
                        Persoonl.FAX = reader("FAX")
                    End If
                    If reader("fkKansellasieRedes") IsNot DBNull.Value Then
                        Persoonl.fkKansellasieRedes = reader("fkKansellasieRedes")
                    End If
                    If reader("GEB_DAT") IsNot DBNull.Value Then
                        Persoonl.GEB_DAT = reader("GEB_DAT")
                    End If
                    If reader("GEKANS") IsNot DBNull.Value Then
                        Persoonl.GEKANS = reader("GEKANS")
                    End If
                    If reader("HUIS_SUB") IsNot DBNull.Value Then
                        Persoonl.HUIS_SUB = reader("HUIS_SUB")
                    End If
                    If reader("HUIS_TEL") IsNot DBNull.Value Then
                        Persoonl.HUIS_TEL = reader("HUIS_TEL")
                    End If
                    If reader("HUIS_TEL2") IsNot DBNull.Value Then
                        Persoonl.HUIS_TEL2 = Trim(reader("HUIS_TEL2"))
                    End If
                    If reader("ID_NOM") IsNot DBNull.Value Then
                        Persoonl.ID_NOM = reader("ID_NOM")
                    End If
                    If reader("INGEVORDER") IsNot DBNull.Value Then
                        Persoonl.INGEVORDER = reader("INGEVORDER")
                    End If
                    If reader("K_OPMERKING") IsNot DBNull.Value Then
                        Persoonl.K_OPMERKING = reader("K_OPMERKING")
                    End If
                    If reader("KLERK") IsNot DBNull.Value Then
                        Persoonl.KLERK = reader("KLERK")
                    End If
                    If reader("MAKELAAR") IsNot DBNull.Value Then
                        Persoonl.MAKELAAR = reader("MAKELAAR")
                    End If
                    If reader("MEDIES") IsNot DBNull.Value Then
                        Persoonl.MEDIES = reader("MEDIES")
                    End If
                    If reader("MOTOR_SUB") IsNot DBNull.Value Then
                        Persoonl.MOTOR_SUB = reader("MOTOR_SUB")
                    End If
                    If reader("noemnaam") IsNot DBNull.Value Then
                        Persoonl.noemnaam = reader("noemnaam")
                    End If
                    If reader("OPMERKING") IsNot DBNull.Value Then
                        Persoonl.OPMERKING = reader("OPMERKING")
                    End If
                    If reader("OUDSTUDENT") IsNot DBNull.Value Then
                        Persoonl.OUDSTUDENT = reader("OUDSTUDENT")
                    End If
                    If reader("P_A_DAT") IsNot DBNull.Value Then
                        Persoonl.P_A_DAT = reader("P_A_DAT")
                    End If
                    If reader("PakketItem1") IsNot DBNull.Value Then
                        Persoonl.PakketItem1 = reader("PakketItem1")
                    End If
                    If reader("PakketItem2") IsNot DBNull.Value Then
                        Persoonl.PakketItem2 = reader("PakketItem2")
                    End If
                    If reader("PakketItem3") IsNot DBNull.Value Then
                        Persoonl.PakketItem3 = reader("PakketItem3")
                    End If
                    If reader("PakketItem4") IsNot DBNull.Value Then
                        Persoonl.PakketItem4 = reader("PakketItem4")
                    End If
                    If reader("pers_nom") IsNot DBNull.Value Then
                        Persoonl.pers_nom = reader("pers_nom")
                    End If
                    If reader("PLIP") IsNot DBNull.Value Then
                        Persoonl.PLIP = reader("PLIP")
                    End If
                    If reader("PLIP1") IsNot DBNull.Value Then
                        Persoonl.PLIP1 = reader("PLIP1")
                    End If
                    If reader("POLFOOI") IsNot DBNull.Value Then
                        Persoonl.POLFOOI = reader("POLFOOI")
                    End If
                    If reader("POLISNO") IsNot DBNull.Value Then
                        Persoonl.POLISNO = reader("POLISNO")
                    End If
                    If reader("POS_VAKKIE") IsNot DBNull.Value Then
                        Persoonl.POS_VAKKIE = reader("POS_VAKKIE")
                    End If
                    If reader("POSBESTEMMING") IsNot DBNull.Value Then
                        Persoonl.POSBESTEMMING = reader("POSBESTEMMING")
                    End If
                    If reader("PREMIE") IsNot DBNull.Value Then
                        Persoonl.PREMIE = reader("PREMIE")
                    End If
                    If reader("premie2") IsNot DBNull.Value Then
                        Persoonl.premie2 = reader("premie2")
                    End If
                    If reader("PREMIEKODE") IsNot DBNull.Value Then
                        Persoonl.PREMIEKODE = reader("PREMIEKODE")
                    End If
                    If reader("SASPREM") IsNot DBNull.Value Then
                        Persoonl.SASPREM = reader("SASPREM")
                    End If
                    If reader("SEL_TEL") IsNot DBNull.Value Then
                        Persoonl.SEL_TEL = reader("SEL_TEL")
                    End If
                    If reader("selfoon") IsNot DBNull.Value Then
                        Persoonl.selfoon = reader("selfoon")
                    End If
                    If reader("STUDENTNO") IsNot DBNull.Value Then
                        Persoonl.STUDENTNO = reader("STUDENTNO")
                    End If
                    If reader("SUBTOTAAL") IsNot DBNull.Value Then
                        Persoonl.SUBTOTAAL = reader("SUBTOTAAL")
                    End If
                    If reader("TAAL") IsNot DBNull.Value Then
                        Persoonl.TAAL = reader("TAAL")
                    End If
                    If reader("TITEL") IsNot DBNull.Value Then
                        Persoonl.TITEL = reader("TITEL")
                    End If
                    If reader("titelnum") IsNot DBNull.Value Then
                        Persoonl.titelnum = reader("titelnum")
                    End If
                    If reader("TV_DIENS") IsNot DBNull.Value Then
                        Persoonl.TV_DIENS = reader("TV_DIENS")
                    End If
                    If reader("VANWIE") IsNot DBNull.Value Then
                        Persoonl.VANWIE = reader("VANWIE")
                        'Andriette 16/04/2013 Bemarker COMBOBOXES
                        intBemarkerIndex = reader("VANWIE")
                    End If
                    If reader("verwysdeur") IsNot DBNull.Value Then
                        Persoonl.verwysdeur = reader("verwysdeur")
                    End If
                    If reader("verwyskommissie") IsNot DBNull.Value Then
                        Persoonl.verwyskommissie = reader("verwyskommissie")
                    End If
                    If reader("VOORL") IsNot DBNull.Value Then
                        Persoonl.VOORL = reader("VOORL")
                    End If
                    If reader("WERK_G") IsNot DBNull.Value Then
                        Persoonl.WERK_G = reader("WERK_G")
                    End If
                    If reader("WERK_TEL") IsNot DBNull.Value Then
                        Persoonl.WERK_TEL = reader("WERK_TEL")
                    End If
                    If reader("WERK_TEL2") IsNot DBNull.Value Then
                        Persoonl.WERK_TEL2 = reader("WERK_TEL2")
                    End If
                    If reader("WN_POLIS") IsNot DBNull.Value Then
                        Persoonl.WN_POLIS = reader("WN_POLIS")
                    End If
                    If reader("VERSEKERDE") IsNot DBNull.Value Then
                        Persoonl.VERSEKERDE = reader("VERSEKERDE")
                    End If
                    Persoonl.NoMatch = False
                    BFUpdateItemsSubTotals(Persoonl.POLISNO)
                    Return True
                Else
                    Persoonl.NoMatch = True
                    Return False
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            End
        End Try
    End Function
    'Andriette 05/08/2013 verander na ;n funksie en return true as die versekerde gevind is andesins false
    '    Sub VV_Soek()
    Private Function VV_Soek()
        Dim blnVV_gevind As Boolean = False


        If Gebruiker.titel = "Programmeerder" Then
            If PersoonlPerVV(Me.VERSEKERDE.Text, Me.VOORL.Text, "") Then
                blnVV_gevind = True
            Else
                blnVV_gevind = False
            End If
        Else
            For intTeller = 1 To UBound(arrglbUserBranchCodes)
                PersoonlPerVV(Me.VERSEKERDE.Text, Me.VOORL.Text, arrglbUserBranchCodes(intTeller))
                If Not Persoonl.NoMatch Then
                    intTeller = UBound(arrglbUserBranchCodes)
                End If
            Next
        End If

        If Persoonl.GEKANS Then
            If Persoonl.fkKansellasieRedes = 24 Then
                MsgBox("The policy is cancelled due to the transition to Natsure as underwriter.", MsgBoxStyle.Exclamation, My.Application.Info.Title & " - Policy Cancelled")
            Else
                MsgBox("The policy is cancelled!", 64, "Information...")
            End If
        End If
        If Persoonl.GEKANS Then
            SetPoldata1FieldChangesAbility(False, "Cancelled")
        End If

        Return blnVV_gevind
    End Function

    Private Function PN_Soek() As Boolean
        Dim intGevind As Integer = -1
        Dim strSoekstring As String = ""
        'Andriette 13/03/2014 probeer iets anders   
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        glbPolicyNumber = POLISNO.Text
        Persoonl = FetchPersoonl()
        'Andriette 19/03/2014 As niks gekry nie nie moet boodskap vertoon
        If Persoonl Is Nothing Then
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Return False
            Exit Function
        Else
            If Persoonl.NoMatch Then
                If blnPol_Byvoeg = False Then
                    PN_Soek = False
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                    Exit Function
                End If
            End If
        End If

        If Not Persoonl.NoMatch Then
            strSoekstring = Chr(39) & Trim(Persoonl.Area) & Chr(39)
            intGevind = InStr(Gebruiker.BranchCodes, strSoekstring)
            If intGevind = 0 Then ' nie gevind
                PN_Soek = False
                Persoonl.NoMatch = True
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Function
            End If
        End If

        If Not (blnDruk) Then
            If Persoonl.GEKANS Then
                If Persoonl.fkKansellasieRedes = 24 Then
                    MsgBox("This policy was cancelled due to the change over to Natsure.", MsgBoxStyle.Exclamation, My.Application.Info.Title & " - Policy Cancelled")
                Else
                    MsgBox("The policy is cancelled!", 64, "Information...")
                End If
            End If
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        PN_Soek = True

    End Function

    Sub Bindposbestemming()
        posbestemming.Items.Clear()
        If Persoonl.TAAL = "0" Then
            posbestemming.Items.Add("Posadres")
            posbestemming.Items.Add("Risiko adres")
            posbestemming.Items.Add("Universiteitsposbus")
            posbestemming.Items.Add("Elektroniese pos")
        Else
            posbestemming.Items.Add("Postal address")
            posbestemming.Items.Add("Risk address")
            posbestemming.Items.Add("University Box")
            posbestemming.Items.Add("Email")
        End If
    End Sub

    Sub Populatefields()
        Dim intIndeksgevind As Integer
        Dim dblAddisionelePremie_Renamed As Double
        '     Dim dblValue1, dblValue2, dblValue3, dblValue4 As Double

        blneditmode = True
        blnClear_s = True
        blnLoading = True
        glbPolicyNumber = Persoonl.POLISNO
        TabDetail.SelectedIndex = 0
        btnPremieDetail.Enabled = True

        populate_dgvPoldataVoertuie()
        populate_dgvPoldata1Eiendomme()
        populate_dgvPoldata1AlleRisikoItems()

        dgvPoldataVoertuie.ClearSelection()
        dgvPoldata1Eiendomme.ClearSelection()
        dgvPoldata1AlleRisikoItems.ClearSelection()

        BindBYBET_K(Persoonl.TAAL)
        BindPayMonth(Persoonl.TAAL)
        If Persoonl.TAAL = 0 Then
            Taal.Items.Clear()
            Taal.Items.Add("Afrikaans")
            Taal.Items.Add("Engels")

            GEKANS.Items.Clear()
            GEKANS.Items.Add("Aktief")
            GEKANS.Items.Add("Gekanselleer")
            If Persoonl.GEKANS Then
                Me.GEKANS.Text = "Gekanselleer"
            Else
                Me.GEKANS.Text = "Aktief"
            End If
            Me.Taal.Text = "Afrikaans"
        Else
            Taal.Items.Clear()
            Taal.Items.Add("Afrikaans")
            Taal.Items.Add("English")
            GEKANS.Items.Clear()
            GEKANS.Items.Add("Active")
            GEKANS.Items.Add("Cancelled")
            If Persoonl.GEKANS Then
                Me.GEKANS.Text = "Cancelled"
            Else
                Me.GEKANS.Text = "Active"
            End If
            Me.Taal.Text = "English"
        End If
        Bindtitel(Persoonl.TAAL)
        Taal.SelectedIndex = Val(Persoonl.TAAL)
        posbestemming.DataSource = (ListPOSBESTEMMING(Persoonl.TAAL))
        If IsDBNull(Persoonl.TITEL) Then
            Me.TITEL.SelectedIndex = -1
        Else
            TITEL.SelectedIndex = GetComboIndex(Persoonl.titelnum, Me.TITEL.DataSource)
        End If
        Me.VANWIE.Enabled = False
        POLISNO.Text = Persoonl.POLISNO
        'Andriette 02/08/2013 

        VERSEKERDE.Text = Persoonl.VERSEKERDE
        'Andriette 24/04/2014 maak versekerde readonly tot gevclick word?
        VERSEKERDE.ReadOnly = True
        VOORL.Text = Persoonl.VOORL
        POLISNO.ReadOnly = True
        ID_NOM.Text = Persoonl.ID_NOM
        dept.Text = Persoonl.DEPT
        BEROEP.Text = Persoonl.BEROEP
        txtBTWno.Text = Persoonl.BTWNo
        'Andriette 21/05/2014 trek vanaf die tabel met die inisieering
        dblPTotaal = Val(Persoonl.PREMIE)
        If IsDBNull(Persoonl.BYBET_K) Or Persoonl.BYBET_K = "" Then
            Me.BYBET_K.SelectedIndex = -1
        Else
            Me.BYBET_K.SelectedIndex = Persoonl.BYBET_K
        End If
        Me.Taal.SelectedIndex = Val(Persoonl.TAAL)
        Me.Betaaldag.SelectedIndex = Persoonl.betaaldatum - 1
        Me.Oudstudentinstansie.Text = Persoonl.OUDSTUDENT & ""
        Me.studentno.Text = Persoonl.STUDENTNO & ""
        Me.dept.Text = Persoonl.DEPT
        Me.posbestemming.SelectedIndex = Val(Persoonl.POSBESTEMMING)
        If posbestemming.SelectedItem = "Elektroniese pos" Or posbestemming.SelectedItem = "Email" Then
            blnElectronicMail = True
        End If
        On Error Resume Next

        'Get the additional premiumamount
        dblAddisionelePremie_Renamed = getAdditionalPremium()
        If Persoonl.Area = "" Then
            Me.AREA.SelectedIndex = -1
        Else
            Me.AREA.SelectedIndex = GetComboIndex(Persoonl.Area.Trim, Me.AREA.DataSource)

            If Trim(Me.AREA.Text) = "" Then
                '   Me.AREA.SelectedIndex = -1
                Me.AREA.Text = "Not Available"
            End If
        End If

        If Me.AREA.Text = "Not Available" Then
            ' Andriette 26/04/2013 Skuif al die veld property veranderinge na die sub
            SetPoldata1FieldChangesAbility(False, "No Area")
            'Enable invoer velde
        Else
            If Persoonl.GEKANS = True Then
                SetPoldata1FieldChangesAbility(False, "Cancelled")
            ElseIf Persoonl.GEKANS = False Then
                SetPoldata1FieldChangesAbility(True, "Active")
            End If
        End If
        'Andriette 24/07/2013 verander die toets se boolean omdat geen veranderinge plaasvind anders stoor dit 0's
        blnchange = False
        Me.PERS_NOM.Text = Persoonl.pers_nom & ""
        Me.POS_VAKKIE.Text = Persoonl.POS_VAKKIE & ""
        Me.BEROEP.Text = Persoonl.BEROEP & ""
        Me.txtBTWno.Text = Persoonl.BTWNo & ""
        Me.dept.Text = Persoonl.DEPT & ""
        Me.ADRES.Text = Persoonl.ADRES & ""
        Me.ADRES1.Text = Persoonl.ADRES1 & ""
        Me.ADRES2.Text = Persoonl.ADRES2 & ""
        Me.ADRES3.Text = Persoonl.adres3 & ""
        Me.adres4.Text = Persoonl.Adres4 & ""
        Me.ID_NOM.Text = Persoonl.ID_NOM & ""
        Me.p_a_dat.Text = String.Format(Persoonl.P_A_DAT, "dd/MM/yyyy")
        'Andriette 23/04/2014 
        dtpInceptDt.Value = CType(Persoonl.P_A_DAT, Date)
        dtpInceptDt.MinDate = CType(Persoonl.P_A_DAT, Date).AddMonths(-1)
        dtpInceptDt.MaxDate = CType(Persoonl.P_A_DAT, Date).AddMonths(11)
        'dtpInceptionDate.Value = New DateTime(Persoonl.P_A_DAT)
        Me.BET_DAT.Text = String.Format(Persoonl.bet_dat, "yyyy/MM/dd")
        Me.BET_DAT.Visible = True
        Me.BET_DAT.Location = New Point(92, 46)
        txtBet_dat.Text = Persoonl.bet_dat '.ToString("dd/MM/yyyy")
        Label22.Text = "First Payment"
        Me.BET_DAT.Enabled = False
        Me.cmbPayMonthYear.Visible = False
        PictureBox8.Location = New Point(152, 53)
        PictureBox8.Visible = True
        M_Wysig.Enabled = True
        Me.WERK_TEL.Text = Persoonl.WERK_TEL2.Trim '& ""
        Me.HUIS_TEL.Text = Persoonl.HUIS_TEL2.Trim
        Me.sel_tel.Text = Persoonl.SEL_TEL.Trim ' & ""
        Me.FAX.Text = Persoonl.FAX.Trim ' & ""
        Me.EMAIL.Text = Persoonl.EMAIL & ""
        Me.txtRoadsidePrem.Text = FormatNumber(Persoonl.careassist, 2)
        Me.studentno.Text = Persoonl.STUDENTNO & ""
        Me.txtNoemnaam.Text = Persoonl.noemnaam & ""
        If IsDBNull(Persoonl.VANWIE) Then
            Me.VANWIE.SelectedIndex = -1
        Else
            Me.VANWIE.SelectedIndex = GetComboIndex(Persoonl.VANWIE.Trim, Me.VANWIE.DataSource)
        End If
        Me.Label35.Text = FormatNumber(Persoonl.BEGRAFNIS, 2)
        Me.Label18.Text = FormatNumber(Persoonl.TV_DIENS, 2)
        Me.txtLiabilityPrem.Text = FormatNumber(Persoonl.POLFOOI, 2)
        Me.Label33.Text = FormatNumber(Persoonl.SUBTOTAAL, 2)
        Me.Label23.Text = FormatNumber(Persoonl.PREMIE, 2)
        Me.lblMaandeliksePremie.Text = FormatNumber(Persoonl.PREMIE, 2)
        Me.Premie2.Text = FormatNumber(Persoonl.premie2, 2)
        Me.Verwysingskommissie.Text = FormatNumber(Persoonl.verwyskommissie, 2)
        Me.Verwysdeur.Text = Persoonl.verwysdeur & ""
        Me.btnAddisionelePremie.Text = FormatNumber(dblAddisionelePremie_Renamed, 2)
        Me.Label16.Text = FormatNumber(Persoonl.BESKERM, 2)
        Me.Plip.Text = FormatNumber(Persoonl.PLIP1, 2)
        Me.txtRoadsidePrem.Text = FormatNumber(Persoonl.careassist, 2)
        If Persoonl.eispers.Length = 1 Then
            Persoonl.eispers = Persoonl.eispers + ".00"
        End If
        If Persoonl.eispers.Length = 3 Then
            Persoonl.eispers = Persoonl.eispers + "0"
        End If
        Me.Combo1.Text = Persoonl.eispers
        If Val(Persoonl.SASPREM) <> 0 Then
            blnLoading = True
            Me.Check1.Enabled = True
            Me.Check1.CheckState = System.Windows.Forms.CheckState.Checked
            Me.Label36.Text = FormatNumber(Persoonl.SASPREM, 2)
        Else
            Me.Check1.Enabled = True
            Me.Label36.Text = FormatNumber(0, 2)
            Me.Check1.CheckState = CheckState.Unchecked

        End If
        ' Andriette 28/05/2013 verander na ;n text veld
        Me.txtCourtesyPrem.Text = FormatNumber(Val(Persoonl.courtesyv), 2)
        Me.plip2.Text = FormatNumber(Val(Persoonl.PLIP1), 2)
        Me.txthomeAsstPrem.Text = FormatNumber(Val(Persoonl.epc), 2)
        btnSelfoonPremie.Text = FormatNumber(Persoonl.selfoon, 2)
        Me.dgvPoldataVoertuie.Enabled = True
        Me.dgvPoldata1Eiendomme.Enabled = True
        Me.dgvPoldata1AlleRisikoItems.Enabled = True
        Me.M_Bet_Wyse.Enabled = True
        Me.M_Begraf.Enabled = True
        Me.M_TV_DIENS.Enabled = False
        Me.M_Wysig.Enabled = True
        Me.M_Bes.Enabled = True
        Me.AREA.Enabled = True
        Me.btnPremieDetail.Enabled = True
        Me.lblPolisPakketTotaal.Text = FormatNumber(gen_getPakketPremie(Persoonl.POLISNO, 1, Now, Now), 2)
        Me.lblPakket1Prem.Text = IIf(IsDBNull(Persoonl.PakketItem1), FormatNumber(0, 2), FormatNumber(Persoonl.PakketItem1, 2))
        Me.txtPakketitem2.Text = FormatNumber(IIf(IsDBNull(Persoonl.PakketItem2) Or Persoonl.PakketItem2 = 0, 0, Persoonl.PakketItem2), 2)
        poldata_DecodeBetaalwyse()
        Me.Timer1.Interval = 15000
        Me.Timer1.Enabled = True
        lblPakketItem1.Text = strglbPakketItem1BeskEng
        'dblValue1 = Me.btnSelfoonPremie.Text
        'dblValue2 = lblSubtotaalNaKorting.Text
        'dblValue3 = lblPolisPakketTotaal.Text
        intPoldataGrid_Focus = 0
        lblHuis_Sub.Text = Persoonl.HUIS_SUB
        lblMotor_Sub.Text = Persoonl.MOTOR_SUB
        lblAlle_Sub.Text = Persoonl.ALLE_SUB
        dblMotor_sub = Persoonl.MOTOR_SUB
        dblHuise_Sub = Persoonl.HUIS_SUB
        dblalle_sub = Persoonl.ALLE_SUB
        lblForm1HuisSubTotaal = lblHuis_Sub
        lblForm1AlleRisikoSubTotaal = lblAlle_Sub
        lblForm1MotorSubTotaal = lblHuis_Sub
        Poldata1_Stel_Items_Buttons(True)
        BFUpdateItemsSubTotals(glbPolicyNumber)
        blnLoading = False
        blnClear_s = False
        HerBereken_Premie()
        blnLoaded = True
        blnSavedNew = True
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Soekopsies()
        TabDetail.SelectedIndex = 0
        If POLISNO.Text <> "" Then
            If blnPol_Byvoeg = False Then
                If (Len(Me.POLISNO.Text) <> 10) Then
                    MsgBox("The policy number should be 10 long", 48, "Policy Number is Invalid!")
                    Me.POLISNO.Focus()
                    Exit Sub
                End If
                'soek polis nommer
                PN_Soek()
                If Persoonl.NoMatch Then
                    Clear_Values()
                    MsgBox("No insured was found for this criteria", 48, "")
                    Exit Sub
                End If

                Populatefields()
            End If

        ElseIf (VERSEKERDE.Text <> "") Or (VERSEKERDE.Text = "?") Then
            '	'As ? ingetik is, begin by die a's
            Persoonl = New PERSOONLEntity()
            If VERSEKERDE.Text = "?" Then
                Persoonl.VERSEKERDE = "a"
            Else
                Persoonl.VERSEKERDE = VERSEKERDE.Text
            End If

            If Gebruiker.titel = "Programmeerder" Then
                Persoonl.Index = "V_INDEX"
            Else
                Persoonl.Index = "av_index"
            End If

            strOpsoekKat = "Van"
            vers_bes.ShowDialog()
            If vers_bes.Suksesvol = False Then
                Clear_Values()
                Exit Sub
            End If
            If Persoonl.POLISNO IsNot Nothing Then
                Populatefields()
                If Persoonl.GEKANS Then
                    If Persoonl.fkKansellasieRedes = "24" Then
                        MsgBox("This policy is cancelled due to the transition to Natsure as underwriter.", MsgBoxStyle.Exclamation, My.Application.Info.Title & " - Policy cancellation")
                    Else
                        MsgBox("The policy is cancelled!", 64, "More ...")
                    End If
                    Me.GEKANS.Text = "Cancelled"
                End If

                If Not Persoonl.GEKANS Then
                    validataPostalAddress()
                End If
            End If
        ElseIf VERSEKERDE.Text <> "" And VOORL.Text <> "" Then
            If VV_Soek() Then
                Populatefields()
            End If
        ElseIf ID_NOM.Text <> "" Then
            '	'As ? ingetik is, begin by die a's
            Persoonl = New PERSOONLEntity()

            If Gebruiker.titel = "Programmeerder" Then
                Persoonl.Index = "V_INDEX"
            Else
                Persoonl.Index = "av_index"
            End If
            'Andriette 12/09/2013
            strOpsoekKat = "ID"
            vers_bes.ShowDialog()
            If vers_bes.Suksesvol = False Then
                Clear_Values()
                Exit Sub
            End If

            If Persoonl.POLISNO IsNot Nothing Then
                If Persoonl.GEKANS Then
                    If Persoonl.fkKansellasieRedes = "24" Then
                        MsgBox("This policy is cancelled due to the transition to Natsure as underwriter.", MsgBoxStyle.Exclamation, My.Application.Info.Title & " - Policy cancellation")
                        ' Andriette 13/06/2013 haal uit sodat die sub voltooi kan word
                        '   Exit Sub
                    Else
                        MsgBox("The policy is cancelled!", 64, "More ...")
                        ' Andriette 13/06/2013 haal uit sodat die sub voltooi kan word
                        ' Exit Sub
                    End If
                    Me.GEKANS.Text = "Cancelled"
                End If
                Populatefields()
                If Not Persoonl.GEKANS Then
                    validataPostalAddress()
                End If
            End If
        Else
            'Andriette 12/09/2013 voeg ID nommer by search opsie
            MsgBox("You need to enter a policy number, insured or ID number!", 48, "Error!")
            VERSEKERDE.Focus()
            Exit Sub
        End If

        ''Blok verwysdes as hierdie 'n Jaarliks kontant of Termynpolis is
        Me.m_verwysdes.Enabled = True
        'Andriette 02/09/2013 termynpolis is 6
        If Persoonl.BET_WYSE = "6" Then
            Me.m_verwysdes.Enabled = False
        End If

        If (VERSEKERDE.Text <> "" And VOORL.Text <> "" And POLISNO.Text <> "") Or (blnPol_Byvoeg = True) Then
            If Me.GEKANS.Text = "Cancelled" Then
                SetPoldata1MenuAbility(False)
            Else
                If Gebruiker.titel = "Besigtig" Then
                    SetPoldata1FieldChangesAbility(False, "Besigtig")
                    SetPoldata1MenuAbility(False)
                    SetPoldata1MenuAbility(True, "Besigtig")
                Else
                    SetPoldata1MenuAbility(True)
                End If ' If Gebtitel = "Besigtig" Then
            End If
        End If
        'andriette 17/10/2013 toets of die persoonl enigsins ingevul is
        If Persoonl Is Nothing Then
        Else
            If Not Persoonl.GEKANS = 1 Then
                'Kry volgende item nommer vir huise en alle risiko
                '  Call kryitem()

                intHuidigearea = Me.AREA.SelectedIndex

                'Is hierdie polis 'n langtermynpolis of 'n jaarliks kontant?
                'used on kontant will move code to kontant
                'FetchLangtermynPolis()

                'getLangtermynStatus()

                'If Persoonl.BET_WYSE = "6" Then
                '    enableCtrlsForLongtermPolicy(False)
                '    Me.mnuLTPbriewe.Enabled = True
                'Else
                '    enableCtrlsForLongtermPolicy(True)
                '    'Andriette 02/09/2013 termynpolisse is 6
                '    'If Persoonl.BET_WYSE = "2" Then
                '    If Persoonl.BET_WYSE = "6" Then
                '        Me.mnuLTPbriewe.Enabled = True
                '    Else
                '        Me.mnuLTPbriewe.Enabled = False
                '    End If
                'End If

                If Persoonl.Eisgeblok = 1 Then
                    mnu_Unblok_eise.Enabled = True
                Else
                    mnu_Unblok_eise.Enabled = False
                End If
                dblsubpremievoor = Persoonl.SUBTOTAAL * Persoonl.eispers
                If Me.AREA.SelectedIndex <> -1 Then 'Not for new policy
                    If Persoonl.Area Is Nothing Then
                    Else
                        'Andriette 27/08/2013 verander die area se index na die area se kode

                        'glbPreviousAreaCode = Me.AREA.SelectedIndex + 1
                        intGlbPreviousAreaCode = Persoonl.Area.Trim
                        Me.lblVersekeraar.Text = FetchVersekeraarForArea()
                    End If
                End If

                btnSelfoonPremie.Text = (cellphoneGetTotalPremium(Me.POLISNO.Text))
                Dim dblValue1, dblValue2, dblValue3 As Decimal

                dblValue1 = Me.btnSelfoonPremie.Text

                If Trim(Me.Label33.Text) <> "" Then
                    Dim dblsubtotaalnakorting As Double = 0
                    Me.lblSubtotaalNaKorting.Text = FormatNumber(Bereken_Subtotaal_na_korting, 2)
                End If
                Me.ToolTip1.SetToolTip(Me.lblSubtotaalNaKorting, "Subtotal before discount: R" & FormatNumber(Me.Label33.Text, 2))
                If lblSubtotaalNaKorting.Text = "" Then
                    lblSubtotaalNaKorting.Text = FormatNumber(0.0, 2) 'Andriette 17/07/2013 verander die formatting
                End If
                If lblPolisPakketTotaal.Text = "" Then
                    lblPolisPakketTotaal.Text = FormatNumber(0.0, 2) 'Andriette 17/07/2013 verander die formatting
                End If
                If Me.btnSelfoonPremie.Text = "" Then
                    Me.btnSelfoonPremie.Text = 0.0
                End If
                dblValue2 = CDec(lblSubtotaalNaKorting.Text)
                dblValue3 = lblPolisPakketTotaal.Text
                Me.btnSelfoonPremie.Text = FormatNumber(dblValue1, 2)
                lblMaandeliksePremie.Text = dblValue1 + dblValue2 + dblValue3
                lblMaandeliksePremie.Text = FormatNumber(lblMaandeliksePremie.Text, 2)
                M_druk.Enabled = True
                m_k_ontv.Enabled = True
            End If
        End If
    End Sub

    Public Sub command8_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command8.Click

        If blnPol_Byvoeg = True Then
            MsgBox("Adding a new policy, please use TAB or the MOUSE (not ENTER)", 48, "")
            Exit Sub
        End If
        TabDetail.SelectedIndex = 0
        If POLISNO.Text <> "" Then
            If blnPol_Byvoeg = False Then
                If (Len(Me.POLISNO.Text) <> 10) Then
                    MsgBox("The policy number should be 10 long", 48, "Policy Number is Invalid!")
                    Me.POLISNO.Focus()
                    Exit Sub
                End If
                'soek polis nommer
                PN_Soek()
                If Persoonl.NoMatch Then
                    MsgBox("No insured was found for this criteria", 48, "")
                    Exit Sub
                End If
                Populatefields()
            End If
        ElseIf (VERSEKERDE.Text <> "") Or (VERSEKERDE.Text = "?") Then
            '	'As ? ingetik is, begin by die a's
            Persoonl = New PERSOONLEntity()
            If VERSEKERDE.Text = "?" Then
                Persoonl.VERSEKERDE = "a"
            Else
                Persoonl.VERSEKERDE = VERSEKERDE.Text
            End If

            If Gebruiker.titel = "Programmeerder" Then
                Persoonl.Index = "V_INDEX"
            Else
                Persoonl.Index = "av_index"
            End If
            'Andriette 12/09/2013
            strOpsoekKat = "Van"
            vers_bes.ShowDialog()
            If vers_bes.Suksesvol = False Then
                Clear_Values()
                Exit Sub
            End If
            If Persoonl.POLISNO IsNot Nothing Then
                Populatefields()
                If Persoonl.GEKANS Then
                    If Persoonl.fkKansellasieRedes = "24" Then
                        MsgBox("This policy is cancelled due to the transition to Natsure as underwriter.", MsgBoxStyle.Exclamation, My.Application.Info.Title & " - Policy cancellation")
                        ' Andriette 13/06/2013 haal uit sodat die sub voltooi kan word
                        '   Exit Sub
                    Else
                        MsgBox("The policy is cancelled!", 64, "More ...")
                        ' Andriette 13/06/2013 haal uit sodat die sub voltooi kan word
                        ' Exit Sub
                    End If
                    Me.GEKANS.Text = "Cancelled"
                End If

                If Not Persoonl.GEKANS Then
                    validataPostalAddress()
                End If
            End If
        ElseIf VERSEKERDE.Text <> "" And VOORL.Text <> "" Then
            If VV_Soek() Then
                Populatefields()
            End If
        ElseIf ID_NOM.Text <> "" Then
            '	'As ? ingetik is, begin by die a's
            Persoonl = New PERSOONLEntity()

            If Gebruiker.titel = "Programmeerder" Then
                Persoonl.Index = "V_INDEX"
            Else
                Persoonl.Index = "av_index"
            End If
            'Andriette 12/09/2013
            strOpsoekKat = "ID"
            vers_bes.ShowDialog()
            If vers_bes.Suksesvol = False Then
                Clear_Values()
                Exit Sub
            End If

            If Persoonl.POLISNO IsNot Nothing Then
                'Andriette 01/11/2013 haal memo list huis
                Populatefields()
                If Persoonl.GEKANS Then
                    If Persoonl.fkKansellasieRedes = "24" Then
                        MsgBox("This policy is cancelled due to the transition to Natsure as underwriter.", MsgBoxStyle.Exclamation, My.Application.Info.Title & " - Policy cancellation")

                    Else
                        MsgBox("The policy is cancelled!", 64, "More ...")

                    End If
                    Me.GEKANS.Text = "Cancelled"
                End If

                If Not Persoonl.GEKANS Then
                    validataPostalAddress()
                End If
            End If
        Else
            'Andriette 12/09/2013 voeg ID nommer by search opsie
            MsgBox("You need to enter a policy number, insured or ID number!", 48, "Error!")
            VERSEKERDE.Focus()
            Exit Sub
        End If

        ''Blok verwysdes as hierdie 'n Jaarliks kontant of Termynpolis is
        Me.m_verwysdes.Enabled = True
        'Andriette 02/09/2013 termynpolis is 6
        If Persoonl.BET_WYSE = "6" Then
            Me.m_verwysdes.Enabled = False
        End If

        If (VERSEKERDE.Text <> "" And VOORL.Text <> "" And POLISNO.Text <> "") Or (blnPol_Byvoeg = True) Then

            If Me.GEKANS.Text = "Cancelled" Then
                SetPoldata1MenuAbility(False)
            Else
                If Gebruiker.titel = "Besigtig" Then
                    SetPoldata1FieldChangesAbility(False, "Besigtig")
                    SetPoldata1MenuAbility(False)
                    SetPoldata1MenuAbility(True, "Besigtig")
                Else
                    SetPoldata1MenuAbility(True)
                End If ' If Gebtitel = "Besigtig" Then
            End If
        End If
        'andriette 17/10/2013 toets of die persoonl enigsins ingevul is
        If Persoonl Is Nothing Then
        Else
            If Not Persoonl.GEKANS = 1 Then
                'Kry volgende item nommer vir huise en alle risiko
                ' Call kryitem()

                intHuidigearea = Me.AREA.SelectedIndex

                'Is hierdie polis 'n langtermynpolis of 'n jaarliks kontant?
                'used on kontant will move code to kontant
                FetchLangtermynPolis()
                getLangtermynStatus()
                If Persoonl.BET_WYSE = "6" Then
                    enableCtrlsForLongtermPolicy(False)
                    Me.mnuLTPbriewe.Enabled = True
                Else
                    enableCtrlsForLongtermPolicy(True)
                    If Persoonl.BET_WYSE = "6" Then
                        Me.mnuLTPbriewe.Enabled = True
                    Else
                        Me.mnuLTPbriewe.Enabled = False
                    End If
                End If

                If Persoonl.Eisgeblok = 1 Then
                    mnu_Unblok_eise.Enabled = True
                Else
                    mnu_Unblok_eise.Enabled = False
                End If

                dblsubpremievoor = Persoonl.SUBTOTAAL * Persoonl.eispers

                If Me.AREA.SelectedIndex <> -1 Then 'Not for new policy
                    If Persoonl.Area Is Nothing Then
                    Else
                        intGlbPreviousAreaCode = Persoonl.Area.Trim
                        Me.lblVersekeraar.Text = FetchVersekeraarForArea()
                    End If
                End If
                btnSelfoonPremie.Text = (cellphoneGetTotalPremium(Me.POLISNO.Text))
                Dim dblValue1, dblValue2, dblValue3 As Decimal

                dblValue1 = Me.btnSelfoonPremie.Text

                If Trim(Me.Label33.Text) <> "" Then

                    Dim dblsubtotaalnakorting As Double = 0
                    Me.lblSubtotaalNaKorting.Text = FormatNumber(Bereken_Subtotaal_na_korting, 2)

                End If
                Me.ToolTip1.SetToolTip(Me.lblSubtotaalNaKorting, "Subtotal before discount: R" & FormatNumber(Me.Label33.Text, 2))
                If lblSubtotaalNaKorting.Text = "" Then
                    lblSubtotaalNaKorting.Text = FormatNumber(0.0, 2) 'Andriette 17/07/2013 verander die formatting
                End If
                If lblPolisPakketTotaal.Text = "" Then
                    lblPolisPakketTotaal.Text = FormatNumber(0.0, 2) 'Andriette 17/07/2013 verander die formatting
                End If
                If Me.btnSelfoonPremie.Text = "" Then
                    Me.btnSelfoonPremie.Text = 0.0
                End If
                dblValue2 = CDec(lblSubtotaalNaKorting.Text)
                dblValue3 = lblPolisPakketTotaal.Text

                Me.btnSelfoonPremie.Text = FormatNumber(dblValue1, 2)
                lblMaandeliksePremie.Text = dblValue1 + dblValue2 + dblValue3
                lblMaandeliksePremie.Text = FormatNumber(lblMaandeliksePremie.Text, 2)
                M_druk.Enabled = True
                m_k_ontv.Enabled = True
            End If

        End If

    End Sub
    Private Sub dat_tyd_verifikasie()
        Dim strVandag2 As DateTime
        'kry vandag se datum en tyd

        strVandag2 = Now
        Form5.Label1.Text = Format(strVandag2, "dd/MM/yyyy  HH:mm")
        Form5.Text2.Text = Format(strVandag2, "dddd")
        Form5.ShowDialog()
    End Sub

    Private Sub txtCourtesyPrem_LostFocus(sender As Object, e As System.EventArgs) Handles txtCourtesyPrem.LostFocus
        Me.txtCourtesyPrem.BackColor = Color.Silver
    End Sub

    ' Andriette 29/05/2013 herskep die event omdat die veldnaam verander het
    ' Andriette 12/06/2013 verander na 'n leave event
    Private Sub txtCourtesyPrem_Leave(sender As Object, e As System.EventArgs) Handles txtCourtesyPrem.Leave
        Dim strCourtesy As String = ""

        If blnchange Then
            txtCourtesyPrem.Text = FormatNumber(Val(txtCourtesyPrem.Text), 2)
            If txtCourtesyPrem.Text.Trim = "" Then
                txtCourtesyPrem.Text = "0.00"
            End If

            If (blnPol_Byvoeg Or blnByvoeg) Then
                If blnSavedNew Then
                    UpdatePersoonlPerField("courtesyv", txtCourtesyPrem.Text)
                End If
            Else
                strCourtesy = Persoonl.courtesyv
                UpdatePersoonlPerField("courtesyv", txtCourtesyPrem.Text)
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & strCourtesy & ") na (" & (Me.txtCourtesyPrem).Text & ")"
                Else
                    BESKRYWING = " change from (" & strCourtesy & ") to (" & (Me.txtCourtesyPrem).Text & ")"
                End If
                UpdateWysig(75, BESKRYWING)

            End If
            'Andriette 06/06/2014 
            BFUpdateItemsSubTotals(glbPolicyNumber)
            HerBereken_Premie()
            blnchange = False

            If Val(txtCourtesyPrem.Text) > 0 And dgvPoldataVoertuie.RowCount = 0 Then
                MsgBox("There is no vehicle insured on this policy.", MsgBoxStyle.Information)
            End If

        End If
        Me.txtCourtesyPrem.BackColor = System.Drawing.ColorTranslator.FromOle(&HC0C0C0)
    End Sub

    Private Sub txtCourtesyPrem_TextChanged(sender As Object, e As System.EventArgs) Handles txtCourtesyPrem.TextChanged
        'Andriette 21/02/2014
        If Not blnLoading And Not blnClear_s Then
            blnchange = True
        End If
    End Sub

    Private Sub dept_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dept.TextChanged
        'Andriette 30/10/2013 sluit die nuwe polisse uit
        'Andriette 20/02/2014 nie toets vir byvoeg nie
        If (blnLoading = False) And (blnClear_s = False) Then
            blnchange = True
        End If
    End Sub

    Private Sub dept_GotFocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dept.GotFocus
        dept.SelectionStart = 0
        dept.SelectionLength = Len(dept.Text)
    End Sub

    Private Sub dept_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dept.Leave
        'Andriette 30/10/0213 sluit die nuwe polisse uit

        If blnchange Then
            dept.Text = UCase(dept.Text)
            If (blnPol_Byvoeg Or blnByvoeg) Then
                If blnSavedNew Then
                    UpdatePersoonlPerField("DEPT", Mid(dept.Text, 1, 20))
                End If
            Else
                dept.Text = UCase(dept.Text)
            End If
            blnchange = False
        End If

    End Sub

    Sub updateHuis()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim params() As SqlParameter = {New SqlParameter("@pkHuis", SqlDbType.Int), _
                                                 New SqlParameter("@PREMIE_HB", SqlDbType.Money), _
                                                New SqlParameter("@PREMIE_HE", SqlDbType.Money)}

                params(0).Value = pkHuis
                params(1).Value = Format("PREMIE_HB", "0.00")
                params(2).Value = Format("PREMIE_HE", "0.00")

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateHuisWithPremie", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Sub populateGridwithHuis()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@pkHuis", SqlDbType.Int)

                param.Value = pkHuis
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchHuisByPrimaryKey", param)

                If reader.Read() Then
                    If IsDBNull(reader("PREMIE_HE")) Or Not IsDBNull(reader("PREMIE_HE")) Then
                        updateHuis()
                    End If
                    If IsDBNull(reader("PREMIE_HB")) Or Not IsDBNull(reader("PREMIE_HB")) Then
                        updateHuis()
                    End If
                Else
                    MsgBox("This home is not found in the database: " & dgvPoldata1Eiendomme.Text)
                    Exit Sub
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Edit__Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Edit_.Click
        Dim dblpolitiek As Double

        If Not Me.validataPostalAddress Then
            Exit Sub
        End If

        blnediting = True
        blnHuisvoegby = False

        If blnNieOpdateer = 1 Then
            MsgBox("This policy's area is not available ... no updates that affect premium is allowed ..")
            Exit Sub
        End If

        Select Case intPoldataGrid_Focus
            'Redo vehicles
            Case 1
                'Vehicle selected for editing
                blnediting = True
                'Andriette 28/08/2013 toets om te kyk of daar enige voertuie is voor edit gedoen kan word
                'Andriette 05/09/2013 Kyk of daar enige selected rye is

                If dgvPoldataVoertuie.SelectedRows.Count > 0 Then

                    If Me.DataVoertuie.Text = "" Then
                        MsgBox("There are no vehicles to edit.", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If

                    'Set pk for vehicle
                    If CStr(Me.dgvPoldataVoertuie.SelectedCells.Item(0).Value) = "" Then
                        pkVoertuie = 0
                    Else

                        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                        pkVoertuie = CInt(Me.dgvPoldataVoertuie.SelectedCells.Item(0).Value)
                        VoertuigDetail.ShowDialog()
                    End If
                Else
                    MsgBox("You must select a vehicle to edit!", 48, "Error!")
                End If
            Case 2
                'huis edit
                strKategorieVerander = "huis"
                If dgvPoldata1Eiendomme.SelectedRows.Count = 0 Then
                    MsgBox("You must select a property to edit!", 48, "Error!")
                    Exit Sub
                End If
                pkHuis = CInt(Me.dgvPoldata1Eiendomme.SelectedCells.Item(13).Value)
                rsHUis = GetHuisByPrimaryKey(pkHuis)
                If (rsHUis Is Nothing) Then
                    MsgBox("There are no properties in the database", MsgBoxStyle.Information)
                    Exit Sub
                Else
                    If rsHUis.ADRES_H1 = "" Then
                        MsgBox("There are no properties in the database", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                End If
                Huis_EF.ShowDialog()

                Try
                    Using conn As SqlConnection = SqlHelper.GetConnection
                        Dim param As New SqlParameter("@pkHuis", SqlDbType.Int)
                        param.Value = CInt(Me.dgvPoldata1Eiendomme.SelectedCells.Item(13).Value)
                        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchHuisByPrimaryKey", param)
                        If Not reader.Read() Then
                            MsgBox("This property was not found in the database: " & dgvPoldata1Eiendomme.Text)
                            Exit Sub
                        End If
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                    End Using
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                blnediting = False
            Case 3
                strKategorieVerander = "alle risiko"
                If dgvPoldata1AlleRisikoItems.SelectedRows.Count = 0 Then
                    MsgBox("You must select an item to edit!", 48, "Error!")
                    Exit Sub
                End If
                A_Risiko.btnVoegby.Visible = False
                A_Risiko.btnRedigeer.Visible = True
                A_Risiko.ShowDialog()
                blnediting = False
        End Select
        'Andriette skuif die na hier uit die select uit want dit word in elke geval by elkeen laaste gedoen
        BFUpdateItemsSubTotals(glbPolicyNumber)
        HerBereken_Premie()
        If Check1.CheckState And Persoonl.GEKANS = False Then
            'Andriette 02/09/2013 verander die funksie
            dblpolitiek = Bereken_Sasria_waardes_op_vorm()
            If Persoonl.BET_WYSE = "6" Then
                dblpolitiek = dblpolitiek * 12
            End If
            UpdatePersoonlPerField("SASPREM", FormatNumber(dblpolitiek, 2))
            Label36.Text = FormatNumber(dblpolitiek, 2)
            UpdateSASPREM()
        Else 'Andriette 26/05/2014 maak die sasprem 0 as nie gecheck is nie
            Label36.Text = FormatNumber(0, 2)
            Persoonl.SASPREM = 0
        End If
    End Sub
    Private Sub EMAIL_GotFocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EMAIL.GotFocus
        EMAIL.SelectionStart = 0
        EMAIL.SelectionLength = Len(EMAIL.Text)
        'Andriette 30/10/2013 sluit nuwe polisse uit
        If EMAIL.Modified = True And Not (blnPol_Byvoeg Or blnByvoeg) Then
            blnchange = True
        End If
    End Sub
    Private Sub EMAIL_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EMAIL.Leave

        'Andriette 19/05/2014 gaan uit as cancel
        If BtnCancel.Focused Then
            Exit Sub
        End If

        If Not ToetsEpos(EMAIL.Text.Trim) Then
            'andriette 06/02/2014 brei die boodskap uit
            If blnElectronicMail = True And EMAIL.Text.Trim = "" Then
                MsgBox("The email address is required because you selected 'electronic mail' as the mail destination. It must include a @ symbol and a dot.", MsgBoxStyle.Critical)
                EMAIL.Focus()
                Exit Sub
            Else
                MsgBox("The Email address must include a @ symbol and a dot.", MsgBoxStyle.Exclamation)
                EMAIL.Focus()
                Exit Sub
            End If
        End If
        Dim strmail As String = ""
        'Andriette 29/01/2014 inisieer die variable

        If blnchange Then
            If (blnByvoeg Or blnPol_Byvoeg) Then 'And Not blnSavedNew Then
                If blnSavedNew Then
                    UpdatePersoonlPerField("EMAIL", EMAIL.Text)
                End If
            Else
                strmail = Persoonl.EMAIL
                UpdatePersoonlPerField("EMAIL", EMAIL.Text)
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & (strmail) & ") na (" & (Me.EMAIL).Text & ")"
                Else
                    BESKRYWING = " change from (" & (strmail) & ") to (" & (Me.EMAIL).Text & ")"
                End If
                UpdateWysig(80, BESKRYWING)
            End If

            UpdateCLRSField("A", (Me.POLISNO).Text)
            blnchange = False
        End If

        If blnPol_Byvoeg Or blnByvoeg Then
            TabDetail.SelectedTab = TabPolicyDetail
        End If

    End Sub

    Private Function ToetsEpos(strEpos) As Boolean
        Dim strPattern As String = "^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + _
                 "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,24}))$"
        Dim blnsukses As Boolean = True

        'Andriette 06/02/2014 toets ook al id die posbestemming nie e-pos nie maar die e-pos is ingevul

        If blnElectronicMail Or EMAIL.Text.Trim <> "" Then
            If Me.EMAIL.Text.Trim = "" Then
                Return False
            Else
                blnsukses = Regex.IsMatch(strEpos, strPattern)

                If Not blnsukses Then
                    EMAIL.Text = ""
                    EMAIL.Focus()
                End If
            End If
        End If
        Return blnsukses
    End Function

    Private Sub txthomeAsstPrem_LostFocus(sender As Object, e As System.EventArgs) Handles txthomeAsstPrem.LostFocus
        Me.txthomeAsstPrem.BackColor = Color.Silver
    End Sub

    'Andriette 12/06/2013 verander die text changed event na ;n leave event sodat die hele verandering geevalueer kan word
    Private Sub txthomeAsstPrem_Leave(sender As Object, e As System.EventArgs) Handles txthomeAsstPrem.Leave
        Dim strEpc As String = ""

        If blnchange Then
            txthomeAsstPrem.Text = FormatNumber(Val(txthomeAsstPrem.Text), 2)
            If txthomeAsstPrem.Text = " " Then
                txthomeAsstPrem.Text = "0.00"
            End If

            If (blnByvoeg Or blnPol_Byvoeg) Then
                If blnSavedNew Then
                    UpdatePersoonlPerField("epc", txthomeAsstPrem.Text)
                End If
            Else
                strEpc = Persoonl.epc
                UpdatePersoonlPerField("epc", txthomeAsstPrem.Text)
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & (strEpc) & ") na (" & FormatNumber((Me.txthomeAsstPrem).Text, 2) & ")"
                Else
                    BESKRYWING = " change from (" & (strEpc) & ") to (" & FormatNumber((Me.txthomeAsstPrem).Text, 2) & ")"
                End If
                UpdateWysig(118, BESKRYWING)
            End If

            blnchange = False
            'Andriette 06/06/2014 
            BFUpdateItemsSubTotals(glbPolicyNumber)
            HerBereken_Premie()
            If Val(txthomeAsstPrem.Text) > 0 Then
                If dgvPoldata1Eiendomme.RowCount = 0 Then
                    MsgBox("There is no property insured on this policy.", MsgBoxStyle.Information)
                End If
            End If
        End If

        Me.txthomeAsstPrem.BackColor = System.Drawing.ColorTranslator.FromOle(&HC0C0C0)
    End Sub
 
    Public Sub Exit_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Exit_Renamed.Click
        If POLISNO.TextLength > 0 Then
            Dim AreaItem As ComboBoxEntity = AREA.SelectedItem

            If blnElectronicMail = True And EMAIL.Text.Trim = "" Then
                MsgBox("The email address is required because you selected 'electronic mail' as the mail destination. It must include a @ symbol and a dot.", MsgBoxStyle.Critical)
                EMAIL.Focus()
                Exit Sub
            End If
            If AreaItem.ComboBoxID = 2 And PERS_NOM.TextLength = 0 Then
                MsgBox("The Personnel number is required if the area is MM PUK", MsgBoxStyle.Critical)
                PERS_NOM.Focus()
                Exit Sub
            End If
        End If

        End

    End Sub

    Private Sub FAX_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FAX.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar)) Then
                'Continue to process
            Else
                e.Handled = True
                MsgBox("Only numbers are allowed to enter in the text box and no spaces are allowed", MsgBoxStyle.Information, "Verify the fax number")
                FAX.Focus()
                Exit Sub
            End If
        End If
    End Sub
    Private Sub FAX_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FAX.TextChanged
        'Andriette 301/10/2013 sluit nuwe polisse uit
        'Andriette 21/02/2014 sluit nou die nuwe polisse in
        If (blnLoading = False) And (blnClear_s = False) Then 'And Not (pol_byvoeg Or Byvoeg) Then
            blnchange = True
        End If

    End Sub

    Private Sub FAX_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FAX.Leave
        Dim strFaks As String = ""
        'Andriette 30/10/2013 sluit nuwe polisse uit
        'Andriette 21/02/2014 redesign
        If blnchange Then
            If FAX.Text <> "" Then
                If Not IsNumeric(FAX.Text) Then
                    MsgBox("The fax number must be numeric", 48, "Fax number is invalid!")

                    FAX.Text = ""
                    FAX.Focus()
                    Exit Sub
                End If
            End If
            If (blnByvoeg Or blnPol_Byvoeg) Then
                If blnSavedNew Then

                    UpdatePersoonlPerField("FAX", FAX.Text)
                End If
            Else
                strFaks = Persoonl.FAX
                UpdatePersoonlPerField("FAX", FAX.Text)

                If IsDBNull(strFaks) Then
                    strFaks = ""
                End If

                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & (strFaks) & ") na (" & (Me.FAX).Text & ")"
                Else
                    BESKRYWING = " blnchange from (" & (strFaks) & ") to (" & (Me.FAX).Text & ")"
                End If
                UpdateWysig(81, BESKRYWING)

            End If
            blnchange = False
            UpdateCLRSField("A", (Me.POLISNO).Text)
        End If
    End Sub


    Private Sub ShareObjectsForm1()
        lblForm1Label23 = Label23
        cmbForm1Combo1 = Combo1
        txtForm1Polisno = POLISNO
        txtForm1Versekerde = VERSEKERDE
        txtForm1Voorl = VOORL
        txtForm1ID_Nom = ID_NOM
        txtForm1Dept = dept
        txtForm1Beroep = BEROEP
        txtForm1BTWNo = txtBTWno
        txtForm1Adres = ADRES
        txtForm1Adres4 = adres4
        txtForm1Adres3 = ADRES3
        txtForm1Adres2 = ADRES2
        txtForm1NoemNaam = txtNoemnaam
        txtForm1Huis_tel = HUIS_TEL
        txtForm1Werk_tel = WERK_TEL
        txtForm1sel_tel = sel_tel
        txtForm1Fax = FAX
        txtForm1Email = EMAIL
        txtForm1PA_Dat = p_a_dat
        txtForm1Bet_dat = BET_DAT
        txtForm1Gekans = Ougekans
        txtForm1Pos_vakkie = POS_VAKKIE
        txtForm1Pers_Nom = PERS_NOM
        txtForm1LiabilityPrem = txtLiabilityPrem
        txtForm1CourtesyPrem = txtCourtesyPrem
        txtForm1HomeAsst = txthomeAsstPrem
        txtForm1RoadsidePrem = txtRoadsidePrem
        txtForm1Pakketitem2 = txtPakketitem2
        lblForm1Pakket1Prem = lblPakket1Prem
        cmbForm1Posbestemming = posbestemming
        cmbForm1Area = AREA
        cmbForm1Betaaldag = Betaaldag
        cmbForm1Bybet_k = BYBET_K
        cmbForm1Vanwie = VANWIE
        cmbForm1Taal = Taal
        cmbForm1Oudstudent = Oudstudentinstansie
        cmbForm1Plip2 = plip2
        lblForm1Label36 = Label36
        lblForm1Label18 = Label18
        lblForm1Label35 = Label35
        lblForm1PolisPakketTotaal = lblPolisPakketTotaal
        lblForm1SubtotaalNaKorting = lblSubtotaalNaKorting
        btnForm1Selfoon = btnSelfoonPremie
        lblForm1MaandeliksePremie = lblMaandeliksePremie
        lblForm1Label16 = Label16
        lblForm1Verwysingskommissie = Verwysingskommissie
        btnForm1AddisionelePremie = btnAddisionelePremie
        lblForm1Premie2 = Premie2
        lblForm1Label33 = Label33
        lblForm1tydperk = lbltermynperiode
        lblForm1status = lblTermynStatus
        lblForm1Months = lbltermynmaande
        lblForm1HuisSubTotaal = lblHuis_Sub
        lblForm1MotorSubTotaal = lblMotor_Sub
        lblForm1AlleRisikoSubTotaal = lblAlle_Sub

    End Sub

    Private Sub Form1_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim strRekenaarid As string
        Dim tak_hoof As AreaEntity

        If blnExitWithError = False Then
            tak_hoof = FetchAreaPerAreaKode("('" + Persoonl.Area + "')")
            'aktiveer VDH databasis(vir Vaal rekenaar) of PCS databasis(vir Potchefstroom rekenaar)
            'tak_hoof.MoveFirst()
            If tak_hoof.Tak_Naam = "Potchefstroom" Or tak_hoof.Tak_Naam = "Vaaldriehoek" Then

                FileOpen(10, "c:\polis5\rekenaarid", OpenMode.Input)
                strRekenaarid = LineInput(10)

                strRekenaarid = Trim(strRekenaarid)
                FileClose(10)

                If UCase(strRekenaarid) = "POTCHEFSTROOM" Then

                    ' Kopieer pcs.ini na poldata.ini
                    FileOpen(15, "c:\windows\pcs.ini", OpenMode.Input)
                    FileOpen(16, "c:\windows\poldata.ini", OpenMode.Output)

                    FileClose(15, 16)

                    MsgBox("Potchefstroom's database is now loaded ... just wait a moment please")

                End If


                If UCase(strRekenaarid) = "VAALDRIEHOEK" Then

                    'Kopieer pcs.ini na poldata.ini
                    FileOpen(15, "c:\windows\vaal.ini", OpenMode.Input)
                    FileOpen(16, "c:\windows\poldata.ini", OpenMode.Output)

                    FileClose(15, 16)

                    'Maak seker dat die kopiering klaar is voordat aangegaan word met kode
                    MsgBox("Vaal Triangle's database is now loaded ... just wait a moment please")

                End If
            End If

            'Toets of eise al gesluit is
            On Error Resume Next
            AppActivate("Flagship Eise ©")
            If Err.Number <> 0 Then
                MsgBox("Please Stop only claim before the program poldata program stopped.....")
            End If
            Me.Close()

            A_Risiko = Nothing
            A_Risiko.Close()

            Bet_Wyse = Nothing
            Bet_Wyse.Close()

            byb = Nothing
            byb.Close()

            Enddet = Nothing
            Enddet.Close()

            Endmeest = Nothing
            Endmeest.Close()

            Form4 = Nothing
            Form4.Close()

            Form5 = Nothing
            Form5.Close()
            ' Andriette haal die kontant vorm heeltemal uit die projek
            '     Kontant = Nothing
            '    Kontant.Close()
        Else

        End If
    End Sub
    Private Sub ouGEKANS_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Ougekans.TextChanged
        If (blnLoading = False) And (blnClear_s = False) Then
            blnchange = True
        End If
    End Sub

    Private Sub ouGEKANS_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Ougekans.Leave
        Dim dblPolitiek As Double
        Dim dblTmpPremie As Double

        If blnchange Then 'change begin

            Ougekans.Text = UCase(Ougekans.Text)

            'Gekans moet ja of nee wees
            If Ougekans.Text <> "JA" And Ougekans.Text <> "NEE" Then
                MsgBox("'Geldige waardes vir 'Polis aktief' is JA of NEE.'", 48, "Ongeldige waarde!")
                Ougekans.Text = "JA"
                Ougekans.Focus()
                Exit Sub
            End If

            If Ougekans.Text = "NEE" Then
                If Not gen_WarningsOnCancelorRemove(Me.POLISNO.Text, enumCheckType.PolicyCancelled) Then
                    Ougekans.Text = "JA"
                    blnchange = False
                    Exit Sub
                End If

                KanselleerPolis.ShowDialog()
                'When the 'KanselleerPolis' form was cancelled, exit sub - no cancellation
                If blnKanselleerPolisFormCancelled Then
                    Exit Sub
                End If
            End If

            'Haal blok af as die polis geaktiveer word
            If Ougekans.Text = "JA" Then

                SetPoldata1FieldChangesAbility(True, "Active")
            End If

            'Sit die blok op as die polis gekans is
            If Ougekans.Text = "NEE" Then
                SetPoldata1FieldChangesAbility(False, "Cancelled")
                blnchange = False
            End If
            If Ougekans.Text <> "JA" Then
                Try
                    Using conn As SqlConnection = SqlHelper.GetConnection
                        Dim params() As SqlParameter = {New SqlParameter("@PolisNo", SqlDbType.NVarChar)}
                        params(0).Value = Persoonl.POLISNO
                        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchCancelHuisInfo]", params)
                        If reader.Read() Then
                            PtyCancl.ShowDialog()
                        End If
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                    End Using
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                    Exit Sub
                End Try
                UpdateCLRSField("C", (Me.POLISNO).Text)
            Else
                UpdatePersoonlPerField("GEKANS", False)
                UpdatePersoonlPerField("datumgekanselleer", "")
                UpdatePersoonlPerField("datumEffekGekans", "")
                UpdateWysig((40), "")

                getGlbPakketItems(Persoonl.Area)

                If (Persoonl.PakketItem1 <> dblglbPakketItem1Premie) And Persoonl.Area <> "E" Then
                    Me.lblPakket1Prem.Text = FormatNumber(dblglbPakketItem1Premie, 2)
                    dblTmpPremie = Persoonl.PakketItem1
                    UpdatePersoonlPerField("PakketItem1", FormatNumber(lblPakket1Prem.Text, 2))

                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = "vanaf (" & dblTmpPremie & ") na (" & FormatNumber(lblPakket1Prem.Text, 2) & ")"
                    Else
                        BESKRYWING = "from (" & dblTmpPremie & ") to (" & FormatNumber(lblPakket1Prem.Text, 2) & ")"
                    End If
                    UpdateWysig(189, BESKRYWING)
                    'Andriette 06/06/2014 
                    BFUpdateItemsSubTotals(glbPolicyNumber)
                    HerBereken_Premie()

                    MsgBox("Some of the extras specific to an area may be affected by the change. It may also affect the final premium", MsgBoxStyle.Exclamation)
                End If

                If (Persoonl.PakketItem2 <> dblglbPakketItem2Premie) And Persoonl.Area <> "E" Then
                    Me.txtPakketitem2.Text = FormatNumber(dblglbPakketItem2Premie, 2)
                    dblTmpPremie = Persoonl.PakketItem2
                    UpdatePersoonlPerField("PakketItem2", FormatNumber(txtPakketitem2.Text, 2))

                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = "vanaf (" & FormatNumber(dblTmpPremie, 2) & ") na (" & FormatNumber(txtPakketitem2.Text, 2) & ")"
                    Else
                        BESKRYWING = "from (" & FormatNumber(dblTmpPremie, 2) & ") to (" & FormatNumber(txtPakketitem2.Text, 2) & ")"
                    End If
                    UpdateWysig(193, BESKRYWING)
                    'Andriette 06/06/2014 
                    BFUpdateItemsSubTotals(glbPolicyNumber)
                    'Andriette 24/10/2013 alles geskuif na herbereken premie
                    'doen_subtotaal()
                    HerBereken_Premie()

                    MsgBox("Die Makelaarsfooi kan beinvloed word deur die verandering.  Dit kan ook die finale premie affekteer.", MsgBoxStyle.Exclamation)
                End If

                If Check1.CheckState Then
                    'Andriette 02/09/2013 verander die funksie
                    dblPolitiek = Bereken_Sasria_waardes_op_vorm()

                    If Persoonl.BET_WYSE = "6" Then
                        dblPolitiek = dblPolitiek * 12
                    End If
                    UpdatePersoonlPerField("SASPREM", FormatNumber(dblPolitiek, 2))
                    Label36.Text = FormatNumber(dblPolitiek, 2)
                End If
                'Andriette 06/06/2014 
                BFUpdateItemsSubTotals(glbPolicyNumber)
                HerBereken_Premie()

                UpdateCLRSField("A", (Me.POLISNO).Text)

            End If
            blnchange = False
        End If
    End Sub

    Private Sub Grid3_GotFocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dgvPoldata1AlleRisikoItems.GotFocus
        intPoldataGrid_Focus = 3
    End Sub

    'Andriette 05/05/2014 comment tydelik uit
    Public Sub her_pol_premies_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles her_pol_premies.Click
        Dim blnPrint_ As Boolean
        Dim intBlad As Integer
        Dim intCtr As Integer

        entV_area = New AreaEntity
        entV_area = FetchArea()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Gebruiker", SqlDbType.NVarChar), _
                                                New SqlParameter("@Datum", SqlDbType.DateTime), _
                                                New SqlParameter("@Beskrywing", SqlDbType.NVarChar)}

                params(0).Value = Gebruiker.Naam
                params(1).Value = Now
                params(2).Value = "Herbereken Premie"

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.UpdateGebruikerLopies", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        intRefreshpol = 1
        intCtr = 0

        blnDruk = True
        intBlad = 0

        Form4.Text1.Text = LTrim(Form4.Text1.Text)

        'verander na hoofletters
        Form4.Text2.Text = UCase(Form4.Text2.Text)
        Form4.Text4.Text = UCase(Form4.Text4.Text)
        Form4.Text1.Text = UCase(Form4.Text1.Text)
        Form4.Text3.Text = UCase(Form4.Text3.Text)

        'Area is nie gekry, ignoreer polis
        If entV_area.NoMatch Then
            blnPrint_ = False
        Else
            If UCase(entV_area.Lewendig) = "J" Then
                blnPrint_ = True
            Else
                blnPrint_ = False
            End If
        End If
printrec:
        If blnPrint_ Then
            If Not (Persoonl.GEKANS And (Not (IsDBNull(Persoonl.POLISNO)))) Then
                POLISNO.Text = Persoonl.POLISNO

                command8_Click(Command8, New System.EventArgs())


                intBlad = intBlad + 1
                intCtr = intCtr + 1
                'Besig.Label1.Text = "Besig om herberekenings van premie te doen..." & Format(Ctr)

                strgewsert = "0"
                strBladsytwee = "0"

                'Gewysigde sertifikate vlaggie inisialiseer
                strGewvirwie = " "


                If intBlad = 50 Then
                    intBlad = 0
                End If
xxx:
                'toets tot waar gedruk moet word
                If Not Persoonl.NoMatch Then
                    If Len(Form4.Text1.Text) <> 0 Then
                        If Persoonl.VERSEKERDE > Form4.Text2.Text Or Mid(Persoonl.VOORL, 5) > Form4.Text4.Text Then
                            GoTo xxxx
                        End If
                    End If
                End If
            End If
        End If

go_on:
        '		Persoonl.MoveNext()
        '		End While
xxxx:
        blnDruk = False
        intRefreshpol = 0
    End Sub

    Private Sub HUIS_TEL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles HUIS_TEL.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If Char.IsDigit(e.KeyChar) Then
                'do nothing
            Else
                e.Handled = True
                MsgBox("Only numbers are allowed in the text box and no space", MsgBoxStyle.Information, "Verify the Home numbers")
                HUIS_TEL.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub HUIS_TEL_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HUIS_TEL.TextChanged
        If (blnLoading = False) And (blnClear_s = False) Then 'And Not (pol_byvoeg Or Byvoeg) Then
            blnchange = True
        End If
    End Sub
    Private Sub HUIS_TEL_GotFocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HUIS_TEL.GotFocus

    End Sub
    Private Sub HUIS_TEL_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HUIS_TEL.Leave
        Dim strHuistel As String = ""
        'Andriette sluit nuwe polisse uit
        'Andriette 21/02/2014 redesign
        If blnchange Then
            If HUIS_TEL.Text <> "" Then
                If Not (IsNumeric(HUIS_TEL.Text)) Then
                    MsgBox("The telephone number must be numeric", 48, "Phone number is invalid!")
                    HUIS_TEL.Text = ""
                    HUIS_TEL.Focus()
                    Exit Sub
                End If
            End If
            If (blnByvoeg Or blnPol_Byvoeg) Then
                If blnSavedNew Then
                    UpdatePersoonlPerField("HUIS_TEL2", HUIS_TEL.Text)
                End If
            Else
                strHuistel = Persoonl.HUIS_TEL2
                UpdatePersoonlPerField("HUIS_TEL2", HUIS_TEL.Text)
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & (strHuistel) & ") na (" & (Me.HUIS_TEL).Text & ")"
                Else
                    BESKRYWING = " change from (" & (strHuistel) & ") to (" & (Me.HUIS_TEL).Text & ")"
                End If
                UpdateWysig(89, BESKRYWING)
            End If
            UpdateCLRSField("A", (Me.POLISNO).Text)
            blnchange = False
        End If

    End Sub
    'Andriette 12/09/2013 Sluit die ID-Nommer in by die soek kriteria
    Private Sub ID_NOM_Click(sender As Object, e As System.EventArgs) Handles ID_NOM.Click
        'Andriette 30/10/2013 sluit uit as byvoeg
        If BtnCancel.Focused Then
            BtnCancel.PerformClick()
            ID_NOM.Focus()
        End If

        If (blnByvoeg Or blnPol_Byvoeg) And Not blnSavedNew Then
            ToetsNoodsaaklik()
        End If
    End Sub

    Private Sub ID_NOM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ID_NOM.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If Char.IsDigit(e.KeyChar) Then
                'Continue with process
            Else
                e.Handled = True
                MsgBox("Only numbers and no spaces are allowed in the ID field", MsgBoxStyle.Information, "Verify the ID number")
                ID_NOM.Focus()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub ID_NOM_GotFocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ID_NOM.GotFocus
        ShareObjectsForm1()
    End Sub

    'Andriette 24/02/2014 voeg by om te werk soos al die ander
    Private Sub ID_NOM_TextChanged(sender As Object, e As System.EventArgs) Handles ID_NOM.TextChanged
        If Not blnLoading And Not blnClear_s And Not (blnByvoeg Or blnPol_Byvoeg) Then
            blnchange = True
        End If
    End Sub

    Private Sub ID_NOM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ID_NOM.Leave
        If BtnCancel.Focused Then
            Exit Sub
        End If

        'Andriette 24/02/0214 redesign
        If blnchange Then
            If ID_NOM.TextLength > 0 Then
                If Not blneditmode And Not (blnByvoeg Or blnPol_Byvoeg) Then
                    ' doen hierdie slegs as die search button of die enter key gedruk is
                    Soekopsies()
                    Exit Sub
                End If

                If ID_NOM.TextLength < 13 Then
                    MsgBox("The ID number should be 13 characters long", MsgBoxStyle.Critical)
                    ID_NOM.Focus()
                    Exit Sub
                End If
                If Not (IsNumeric(ID_NOM.Text)) Then
                    MsgBox("The identity number must be numeric", MsgBoxStyle.Critical)
                    ID_NOM.Text = ""
                    ID_NOM.Focus()
                    Exit Sub
                End If
                If blnPol_Byvoeg Or blnByvoeg Then
                    If ID_NOM.TextLength < 1 Then
                        MsgBox("The ID Number is required", MsgBoxStyle.Critical)
                        Me.ID_NOM.Focus()
                        Exit Sub
                    End If
                Else
                    Dim stridn As String = ""
                    stridn = Persoonl.ID_NOM
                    UpdatePersoonlPerField("ID_NOM", ID_NOM.Text)
                    If IsDBNull(stridn) Then
                        stridn = " "
                    End If
                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = " wysig vanaf (" & (stridn) & ") na (" & (Me.ID_NOM).Text & ")"
                    Else
                        BESKRYWING = " change from (" & (stridn) & ") to  (" & (Me.ID_NOM).Text & ")"
                    End If
                    UpdateWysig(87, BESKRYWING)
                    UpdateCLRSField("A", (Me.POLISNO).Text)
                    blnchange = False
                End If
            End If
        End If

        If blnByvoeg Or blnPol_Byvoeg Then

            If ID_NOM.TextLength < 1 Then
                MsgBox("The ID Number is required ", MsgBoxStyle.Critical)
                Me.ID_NOM.Focus()
                Exit Sub
            End If
            If ID_NOM.TextLength < 13 Then
                MsgBox("The ID number should be 13 characters long", MsgBoxStyle.Critical)
                ID_NOM.Focus()
                Exit Sub
            End If
            If Not (IsNumeric(ID_NOM.Text)) Then
                MsgBox("The identity number must be numeric", MsgBoxStyle.Critical)
                ID_NOM.Text = ""
                ID_NOM.Focus()
                Exit Sub
            End If
            'Andriette 07/04/2014 net as dit nognie gesave is nie
            If Not blnSavedNew Then
                ToetsNoodsaaklik()
            End If

        End If
    End Sub
    Private Sub Image1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Image1.Click
        MsgBox("The postal address consists of the following:" & Chr(13) & Chr(13) & "Address 1 (Street, Post Box or Flat/Townhouse Complex)" & Chr(13) & "Address 2 (Street address)" & Chr(13) & "Suburb (According to National Postalcodes)" & Chr(13) & "Postalcode (According to National Postalcodes)" & Chr(13) & Chr(13) & "Take note that the City/Town is not used by the Post Office", MsgBoxStyle.Information)
    End Sub
    Public Sub Jaar_1995_1999_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Jaar_1995_1999.Click
        wysoud.ShowDialog()
    End Sub

    Private Sub Label33_change()
        Dim dblsubtotaal As Double = 0

        If Trim(Me.Label33.Text) <> "" Then
            Me.lblSubtotaalNaKorting.Text = FormatNumber(Bereken_Subtotaal_na_korting, 2)
        End If
        Me.ToolTip1.SetToolTip(Me.lblSubtotaalNaKorting, "Subtotaal voor korting: R " & FormatNumber(Me.Label33.Text, 2))

    End Sub
    Private Sub Label36_change()
        If (Not (blnClear_s)) And (Not (blnLoading)) Then
            If Not IsNothing(Persoonl) And POLISNO.Text <> "" Then
                'Andriette 06/06/2014 
                BFUpdateItemsSubTotals(glbPolicyNumber)
                HerBereken_Premie()
            End If
        End If
    End Sub
    Private Sub Label5_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label5.Click
        POLISNO.Focus()
    End Sub

    Private Sub M_About_Click()
        About("Mooirivier Polis Databasis©", Me)
    End Sub
    Private Sub lblAddisionelePremie_Change()
        btnAddisionelePremie.Text = FormatNumber(Val(Me.btnAddisionelePremie.Text), 2)
    End Sub

    Private Sub btnAddisionelePremie_Click(sender As System.Object, e As System.EventArgs) Handles btnAddisionelePremie.Click
        AddisionelePremie.ShowDialog()
    End Sub

    Private Sub lblSelfoon_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        selfoonListFrm.ShowDialog()
    End Sub

    Public Sub M_Begraf_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles M_Begraf.Click
        Try
            Dim dblb_prem As Double
            Dim dblB_prem_p As Double
            Dim intB_dek As Integer
            Dim intB_dek_p As Integer

beg_weer1:
            intB_dek_p = Persoonl.begraf_dek
            intB_dek = InputBox("Please provide the funeral coverage", "Flagship", intB_dek_p)

            If Len(intB_dek) > 8 Then
                MsgBox("The funeral coverage is too long.", 48, "Flagship")
                intB_dek = ""
                intB_dek = InputBox("The funeral coverage may not be more than 8 numbers,please change it.", "Flagship", "0")

            End If
            If Len(intB_dek) > 0 Then
                If (Not (IsNumeric(intB_dek))) Then
                    MsgBox("The funeral coverage should be numeric", 48, "Error!")
                    GoTo beg_weer1
                End If
            Else
                If intB_dek = "" Then
                    MsgBox("You cancelled, program ends now.", MsgBoxStyle.Information, "Flagship")
                    Exit Sub
                End If
            End If

beg_weer2:
            dblB_prem_p = Persoonl.BEGRAFNIS
            dblb_prem = InputBox("Please provide the funeral premium", "Flagship", dblB_prem_p)
            If Len(dblb_prem) > 0 Then
                If (Not IsNumeric(dblb_prem)) Then
                    MsgBox("The funeral premium must be numeric.", 48, "Error!")
                    GoTo beg_weer2
                End If
            Else
                If dblb_prem = "" Then
                    MsgBox("You cancelled, program ends now.", MsgBoxStyle.Information, "Flagship")
                    Exit Sub
                End If
            End If

            'Linkie 03/07/2012
            If Format(intB_dek) <> Format(intB_dek_p) Or (Format(dblb_prem) <> Format(dblB_prem_p)) Then

                Using conn As SqlConnection = SqlHelper.GetConnection
                    'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                    Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                    New SqlParameter("@BEGRAFNIS", SqlDbType.Money), _
                                                    New SqlParameter("@begraf_dek", SqlDbType.Money)}
                    params(0).Value = Persoonl.POLISNO
                    params(1).Value = FormatNumber(dblb_prem, 2)
                    params(2).Value = FormatNumber(intB_dek, 0)
                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateFuneralDetails", params)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                End Using
            End If

            Me.Label35.Text = FormatNumber(dblb_prem, 2)

            If (Format(intB_dek) <> Format(intB_dek_p)) Or (Format(dblb_prem) <> Format(dblB_prem_p)) Then

                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig na (" & FormatNumber(Persoonl.BEGRAFNIS, 2) & ")"
                Else
                    BESKRYWING = " change to (" & FormatNumber(Persoonl.BEGRAFNIS, 2) & ")"
                End If
                UpdateWysig((27), BESKRYWING)
                'Andriette 06/06/2014 
                BFUpdateItemsSubTotals(glbPolicyNumber)
                HerBereken_Premie()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Public Sub M_Bet_Wyse_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles M_Bet_Wyse.Click
        Bet_Wyse.ShowDialog()
        'Andriette 23/01/2014 1.232
        ' As die betaalwyse verander het, moet die skerm ook opgedateer word
        poldata_DecodeBetaalwyse()
    End Sub
    Public Sub m_byb_menu_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles m_byb_menu.Click
        If Gebruiker.titel <> "Programmeerder" Then
            byb.Bybverander.Visible = False
        End If
        byb.Show()
    End Sub
    Public Sub M_daagliks_lys_2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles m_daagliks_lys_2.Click
        frmLysVanDaaglikseWysigings.ShowDialog()
    End Sub
    Public Sub m_endos_meester_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles m_endos_meester.Click
        If Gebruiker.titel <> "Programmeerder" Then
            Endmeest.btnEndmeestbyvoeg.Visible = False
            Endmeest.btnEndmeestverwcmd.Visible = False
            Endmeest.btnEnddetcmd.Visible = False
            Endmeest.Label1.Visible = False
            Endmeest.Label2.Visible = False
            Endmeest.Label3.Visible = False
            Endmeest.Label4.Visible = False
            Endmeest.txtEndosidentifikasie.Visible = False
            Endmeest.txtEndosnaam.Visible = False
            Endmeest.txtEndosafreng.Visible = False
            Endmeest.txtEndosDrukOrals.Visible = False
        End If
        Endmeest.Show()
    End Sub
    Public Sub m_k_ontv_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles m_k_ontv.Click
        'Andriette 14/10/2013 verander die cursor sodat die persoon kan sien die opsie is geclick
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        frmKontant.Show()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Public Sub M_Naam_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles M_Naam.Click
        Dim strTemp1 As String

        Try
            If VOORL.Text = "" Then
                MsgBox("You Must select a person ...", 48, " Error! ")
                Exit Sub
            End If

            strTemp1 = InputBox("Please type in the new Initials :", "Change Initials", VOORL.Text)
            If strTemp1 = "" Then
                Exit Sub
            End If
            'blok polisnommer op 5
            If Len(strTemp1) > 5 Then
                MsgBox("The initial is too long", 48, "Change Initials")
                strTemp1 = ""
                strTemp1 = InputBox("Initials may not be more than 5 characters,please change it.", "Change Initials", VOORL.Text)
            End If

            If Not Regex.Match(strTemp1, "^[a-z]*$", RegexOptions.IgnoreCase).Success Then

                MsgBox("Initials may only be aplphabetic text only")
                Exit Sub
            End If
            If Len(strTemp1) > 5 Then
                MsgBox("The initial is too long", 48, "Change Initials")
                Exit Sub
            End If

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@VOORL", SqlDbType.NVarChar)}

                params(0).Value = Persoonl.POLISNO
                params(1).Value = strTemp1
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateVoorl1", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

            If Persoonl.TAAL = 0 Then
                BESKRYWING = " wysig vanaf (" & (VOORL).Text & ") na (" + (strTemp1) + ")"
            Else
                BESKRYWING = " change from (" & (VOORL).Text & ") to (" + (strTemp1) + ")"
            End If

            UpdateWysig(51, BESKRYWING)
            UpdateCLRSField("A", (Me.POLISNO).Text)
            VOORL.Text = strTemp1

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

    End Sub
    Public Sub m_pol_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles m_pol.Click
        strgewsert = "0"
        strBladsytwee = "0"
        'Area, bybetalingswyse en eerste betaaldatum moet ingevul wees
        If Me.AREA.SelectedIndex = -1 Then
            MsgBox("Please supply the area...")
            Exit Sub
        End If

        If Me.BYBET_K.SelectedIndex = -1 Then
            MsgBox("Please supply the payment type ...")
            Exit Sub
        End If

        If Me.BET_DAT.Text = "" Then
            MsgBox("Please supply the first payment date ...")
            Exit Sub
        End If

        If Me.ADRES2.Text = "" Then
            MsgBox("Please supply a valid postal code ...")
            Exit Sub
        End If
        If Me.txtRoadsidePrem.Text = "" Then
            MsgBox("Care Assist value cannot be 0.00, please supply a value ...")
            Exit Sub
        End If
        'As posbestemming e-pos gemaak word, dan moet die polis n e-pos adres he
        If posbestemming.Text = "Elektroniese pos" Then
            'Het hierdie persoon n epos adres?
            If IsDBNull(Persoonl.EMAIL) Then
                MsgBox("Electronic mail is requested for this client. Please supply e-mail address for client " & Me.VOORL.Text & " " & Me.VERSEKERDE.Text & " " & Me.POLISNO.Text)
                Exit Sub
            End If
            If Len(Persoonl.EMAIL) = 0 Then
                MsgBox("Electronic mail is requested for this client. Please supply e-mail address for client " & Me.VOORL.Text & " " & Me.VERSEKERDE.Text & " " & Me.POLISNO.Text)
                Exit Sub
            End If
        End If

        'Gewysigde sertifikate vlaggie inisialiseer
        strGewvirwie = " "
    End Sub
    Public Sub M_REG_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles M_REG.Click
        'Andriette 07/10/2013 maak die velde skoon as op die registrasie nommer gesoek word
        Clear_Values()
        'Andriette 16/09/2013 verander na 'n public om te gebruik in vers_bes
        'Kobus 03/09/2014 voegby en verander Inputbox
        Dim strMessage, strTitle As String
        strMessage = "Registration number to be searched?"
        strTitle = "Vehicle - Search by registration"
        strRegistrationseek = InputBox(strMessage, strTitle)

        If Len(strRegistrationseek) > 10 Then
            MsgBox("Vehicle registration number must be less than 10 alphanumeric", MsgBoxStyle.Information)
            Exit Sub
        Else
            If strRegistrationseek = "" Then
                Exit Sub
            End If
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        strOpsoekKat = "Regno"
        vers_bes.ShowDialog()
        If vers_bes.Suksesvol = False Then
            Exit Sub
        End If
        If Persoonl.POLISNO IsNot Nothing Then
            Populatefields()
            If Persoonl.GEKANS Then
                If Persoonl.fkKansellasieRedes = "24" Then
                    MsgBox("This policy is cancelled due to the transition to Natsure as underwriter.", MsgBoxStyle.Exclamation, My.Application.Info.Title & " - Policy cancellation")
                Else
                    MsgBox("The policy is cancelled!", 64, "More ...")
                End If
                Me.GEKANS.Text = "Cancelled"
            End If

            If Not Persoonl.GEKANS Then
                validataPostalAddress()
            End If
        End If
    End Sub
    'Display form containing a list of cellphones that are insured with this policy
    Public Sub M_selfoon_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles M_selfoon.Click

        If POLISNO.Text = Nothing Then
            MsgBox("Please allocate the policy number of the insured", MsgBoxStyle.Information)
            Exit Sub
        End If
        selfoonListFrm.ShowDialog()

    End Sub
    'Public Sub M_TV_DIENS_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles M_TV_DIENS.Click
    '    TV_Diens_Frm.Show()

    '    ''Wys TV diens op poldata vorm
    '    Me.Label18.Text = FormatNumber(Val(Persoonl.TV_DIENS), 2)

    'End Sub
    Public Sub M_Van_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles M_Van.Click
        Dim strTemp1 As String

        If VERSEKERDE.Text = "" Then
            MsgBox("Do you select a person ...", 48, "Error!")
            Exit Sub
        End If

        strTemp1 = InputBox("Please type in the new surname", "Change surname", VERSEKERDE.Text)
        If strTemp1 = "" Then
            Exit Sub
        End If

        If Len(strTemp1) > 25 Then
            MsgBox("The surname is too long", 48, "Change surname")
            strTemp1 = ""
            strTemp1 = InputBox("Surname may not be more than 25 characters,please change it.", "Change surname", VERSEKERDE.Text)
        End If

        If Not Regex.Match(strTemp1, "^[' 'a-z]*$", RegexOptions.IgnoreCase).Success Then
            MsgBox("Surname may only be alphabetic text only")
            Exit Sub
        End If
        UpdatePersoonlPerField("VERSEKERDE", strTemp1)

        If Persoonl.TAAL = 0 Then
            BESKRYWING = " wysig vanaf (" & (VERSEKERDE).Text & ") na (" + (strTemp1) + ")"
        Else
            BESKRYWING = " change from (" & (VERSEKERDE).Text & ") to (" + (strTemp1) + ")"
        End If

        VERSEKERDE.Text = strTemp1
        UpdateWysig(50, BESKRYWING)
        MsgBox("Verify that debitorder holder's surname and initials at payment methods are correct", 64, "Message..")

        UpdateCLRSField("A", (Me.POLISNO).Text)
    End Sub

    Public Sub M_Ver_Drukker_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles M_Ver_Drukker.Click
        CommonDialog1Print.ShowDialog()
    End Sub
    Private Sub M_VERANDER_Click()
        Dim strTemp As String
beg:
        If POLISNO.Text = "" Then
            MsgBox("You should have a policy to choose!", 48, "Error!")
            Exit Sub
        End If

        strTemp = InputBox("Wat is die nuwe polisnommer:", "Verander Polisnommer...", Persoonl.POLISNO)
        If strTemp = "" Then
            Exit Sub
        End If

        If Len(strTemp) <> 10 Then
            MsgBox("The policy number entered incorrect ...", 48, "Error!")
            GoTo beg
        End If

        UpdatePersoonlPerField("POLISNO", strTemp)

        command8_Click(Command8, New System.EventArgs())
    End Sub

    Public Sub M_VERWYDER_NULL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles M_VERWYDER_NULL.Click
        MsgBox("The wrong people were erased ....", 64, "Message ...")
    End Sub

    'Private Sub M_werknemers_Click()
    '    Dim strTemp As Object
    '    If Label16.Text = "" Then
    '        strTemp = InputBox("What is the premium protection services", "Protection Services ...", " 45.00 ")
    '    Else
    '        strTemp = InputBox("Wat is die Beskermingsdienste premie:", "Beskermingsdienste...", FormatNumber(Label16.Text, 2))
    '    End If

    '    If (strTemp <> "") Or (strTemp <> Label16.Text) Then
    '        Label16.Text = FormatNumber(strTemp, 2)

    '        UpdatePersoonlPerField("WN_POLIS", Label16.Text)
    '        UpdateWysig(48, "")
    '        'Andriette 06/06/2014 
    '        BFUpdateItemsSubTotals(glbPolicyNumber)
    '        'Andriette 24/10/2013 alles geskuif na herbereken premie
    '        'doen_subtotaal()
    '        HerBereken_Premie()
    '    End If

    'End Sub
    Public Sub M_Wysig_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles M_Wysig.Click
        W_Gesk.ShowDialog()
    End Sub
    Private Sub MaskedEdit1_change()
        UpdatePersoonlPerField("ID_NOM", ID_NOM.Text)
    End Sub

    Public Sub mneBriefBesonderhede_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mneBriefBesonderhede.Click
        BriefBesonderhede.ShowDialog()
    End Sub
    Public Sub mnuAddisionelepremie_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuAddisionelepremie.Click
        AddisionelePremie.ShowDialog()
    End Sub
    Public Sub mnuBelasting_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuBelasting.Click
        BriefBelasting.ShowDialog()
    End Sub
    Public Sub mnuBriefBevestig_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuBriefBevestig.Click
        Me.intDelay = 30000 'milliseconds
        BriefBevestig.ShowDialog()
    End Sub
    Public Sub mnuDetailSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDetailSearch.Click
        Search.ShowDialog()
    End Sub
    Public Sub mnuDokArgief_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDokArgief.Click
        Argief.ShowDialog()
    End Sub
    Public Sub mnuKansellasieBrief_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuKansellasieBrief.Click
        BriefKansellasie.ShowDialog()
    End Sub
    Public Sub mnuKansellasieRedes_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuKansellasieRedes.Click
        AdminKansellasieRedes.ShowDialog()
    End Sub
    Public Sub mnuKontantAanmaning_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuKontantAanmaning.Click
        BriefKontant.ShowDialog()
    End Sub
    Public Sub mnuMeadMcGrouther_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuMeadMcGrouther.Click
        'Disable ok button - only for lookup
        If Gebruiker.MMLicence Then
            VoertuigSearch.btnOk.Enabled = False
            VoertuigSearch.ShowDialog()
        Else
            MsgBox("You don't have a license to access the Mead and McGrouther values.", MsgBoxStyle.Exclamation)
        End If

    End Sub
    Public Sub mnuOuMemo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuOuMemo.Click
        On Error Resume Next

        MemoFrm.Memo.Text = Persoonl.OPMERKING
        If Err.Number <> 0 Then
            MemoFrm.Memo.Text = ""
            Err.Clear()
        End If

        MemoFrm.ShowDialog()
    End Sub
    Public Sub mnuPolisskedule_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuPolisskedule.Click
        BriefSkedule.ShowDialog()
    End Sub
    Public Sub mnuReminders_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuReminders.Click
        ReminderPrint.ShowDialog()
    End Sub
    'Reset all the additional premiums to zero
    Public Sub mnuResetAddisionelePremies_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        AddisionelePremieHerstel.ShowDialog()
    End Sub
    Public Sub mnuVTBrief_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuVTBrief.Click
        BriefVT.ShowDialog()
    End Sub
    Private Sub Oudstudentinstansie_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Oudstudentinstansie.SelectedIndexChanged
        Dim strOudStudent As String = ""

        'Andriette 20/02/2014 redesign
        If Not (blnClear_s Or blnLoading) Then
            If (blnByvoeg Or blnPol_Byvoeg) Then
                If blnSavedNew Then
                    UpdatePersoonlPerField("Oudstudent", Oudstudentinstansie.Text)
                End If
            Else
                UpdatePersoonlPerField("Oudstudent", Oudstudentinstansie.Text)
                strOudStudent = Persoonl.OUDSTUDENT
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & (strOudStudent) & ") na (" & (Oudstudentinstansie.Text) & ")"
                Else
                    BESKRYWING = " change from (" & (strOudStudent) & ") to (" & (Oudstudentinstansie.Text) & ")"
                End If
                UpdateWysig(85, BESKRYWING)
            End If
            blnchange = False
        End If

    End Sub
    Private Sub Oudstudentinstansie_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Oudstudentinstansie.Leave
        If blnByvoeg Or blnPol_Byvoeg Then
            TabDetail.SelectedTab = tabcontactdetail
            posbestemming.Focus()
        End If
    End Sub
    Private Sub PCS_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        InitPol()
    End Sub
    Private Sub PERS_NOM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PERS_NOM.TextChanged
        'Andriette 30/10/2013 sluit nuwe polisse uit
        'andriette 20/02/214 nie toets vir bevoeg nie
        If (blnLoading = False) And (blnClear_s = False) Then 'And Not (pol_byvoeg Or Byvoeg) Then
            blnchange = True
        End If
    End Sub
    Private Sub PERS_NOM_GotFocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PERS_NOM.GotFocus
        PERS_NOM.SelectionStart = 0
        PERS_NOM.SelectionLength = 8
    End Sub
    Private Sub PERS_NOM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PERS_NOM.Leave
        Dim strPersNo As String = ""
        'Andriette 20/02/2014 redesign
        Dim item As New ComboBoxEntity
        item = AREA.SelectedItem

        'Andriette 19/05/2014 gaan uit as cancel
        If BtnCancel.Focused Then
            Exit Sub
        End If

        If blnchange Then
            If (blnByvoeg Or blnPol_Byvoeg) Then
                If blnSavedNew Then
                    UpdatePersoonlPerField("PERS_NOM", PERS_NOM.Text)
                End If
            Else
                strPersNo = Persoonl.pers_nom
                UpdatePersoonlPerField("PERS_NOM", PERS_NOM.Text)
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & (strPersNo) & ") na (" & (PERS_NOM).Text & ")"
                Else
                    BESKRYWING = " change from (" & (strPersNo) & ") to (" & (PERS_NOM).Text & ")"
                End If
                UpdateWysig(69, BESKRYWING)
            End If
            blnchange = False
        End If

        If item.ComboBoxID = 2 Then
            If PERS_NOM.TextLength = 0 Then
                MsgBox("The personnel number is required if the area is selectd as MM PUK", MsgBoxStyle.Exclamation)
                Me.PERS_NOM.Focus()
                Exit Sub
            End If
            If Len(PERS_NOM.Text) <> 8 Then
                MsgBox("The staff number should be eight characters long." & Chr(13) & "Please ensure that it is correct number.", MsgBoxStyle.Information)
                Me.PERS_NOM.Focus()
                Exit Sub
            End If

            If PERS_NOM.Text = "00000000" Then
                PERS_NOM.Text = "        "
            End If
        Else
            If Len(Trim(PERS_NOM.Text)) > 0 And Len(Trim(PERS_NOM.Text)) <> 7 Then
                PERS_NOM.Text = PERS_NOM.Text.PadLeft(7, "0")
            End If
        End If
    End Sub
    Private Sub Plip_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Plip.Leave
        If Not (blnLoading) Then

            Plip.Text = Format(Plip.Text, "####00.00")

            If Persoonl.PLIP1 <> Val(Plip.Text) Then
                Plip.Text = Format(Plip.Text, "####00.00")
                UpdatePersoonlPerField("PLIP1", Val(Plip.Text))
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig na (" & (plip2.Text) & ")"
                Else
                    BESKRYWING = " change to (" & (plip2.Text) & ")"
                End If
                UpdateWysig(53, BESKRYWING)
                'Andriette 06/06/2014 
                BFUpdateItemsSubTotals(glbPolicyNumber)
                HerBereken_Premie()
            End If
        End If
    End Sub

    Private Sub plip2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles plip2.SelectedIndexChanged
        If (blnLoading = False) And (blnClear_s = False) Then
            blnchange = True
        End If
    End Sub

    Private Sub plip2_GotFocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles plip2.GotFocus
        Me.plip2.BackColor = System.Drawing.Color.White
    End Sub
    Private Sub plip2_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles plip2.Leave
        Dim strOldPlip2 As String = ""
        'Andriette 21/02/214 redesign
        If blnchange Then

            If Not blnLoading Or blnClear_s Then
                If (blnByvoeg Or blnPol_Byvoeg) Then
                    If blnSavedNew Then
                        UpdatePersoonlPerField("plip1", FormatNumber(Val(plip2.Text), 2))
                    End If
                Else
                    UpdatePersoonlPerField("plip1", FormatNumber(Val(plip2.Text), 2))
                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = " wysig na (" & FormatNumber(plip2.Text, 2) & ")"
                    Else
                        BESKRYWING = " change to (" & FormatNumber(plip2.Text, 2) & ")"
                    End If
                    UpdateWysig(53, BESKRYWING)
                    'Andriette 06/06/2014 
                    BFUpdateItemsSubTotals(glbPolicyNumber)
                    HerBereken_Premie()
                End If
            End If
            blnchange = False
        End If
        Me.plip2.BackColor = System.Drawing.ColorTranslator.FromOle(&HC0C0C0)
    End Sub

    Private Sub POLISNO_Click(sender As Object, e As System.EventArgs) Handles POLISNO.Click
        If Not (blnByvoeg Or blnPol_Byvoeg) Then
            Clear_Values()
            POLISNO.Focus()
        Else
            If blnSavedNew And POLISNO.Text.Trim.Length > 0 Then
                Clear_Values()
                POLISNO.Focus()
                SetPoldata1FieldChangesAbility(True)
            End If
        End If
        TabDetail.SelectedTab = TabInligting
        POLISNO.Focus()
    End Sub

    Private Sub POLISNO_Enter(sender As Object, e As System.EventArgs) Handles POLISNO.Enter
        If Not (blnByvoeg Or blnPol_Byvoeg) Then
            If Control.ModifierKeys = Keys.Tab Then
                If Not (blnPol_Byvoeg Or blnByvoeg) Then
                    If VERSEKERDE.Text <> "" Or ID_NOM.Text <> "" Then
                        MsgBox("If you want to add a policy, please use the Add button", MsgBoxStyle.Information)
                    End If
                End If

            ElseIf Control.MouseButtons = Windows.Forms.MouseButtons.Left Then

            End If
        End If

    End Sub

    Private Sub POLISNO_TextChanged(sender As Object, e As System.EventArgs) Handles POLISNO.TextChanged
        If (blnLoading = False) And (blnClear_s = False) Then ' And Not (pol_byvoeg Or Byvoeg) Then
            blnchange = True
        End If
    End Sub
    Private Sub Polisno_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles POLISNO.Leave

        If BtnCancel.Focused Then
            Exit Sub
        End If

        If POLISNO.Text.Trim = "" And (blnByvoeg Or blnPol_Byvoeg) Then
            POLISNO.Focus()
            Exit Sub
        End If

        If Not blnchange Then
            Exit Sub
        End If

        glbPolicyNumber = POLISNO.Text

        If Me.POLISNO.Text <> "" Then
            If (Len(Me.POLISNO.Text) <> 10) Then
                MsgBox("The policy number should be 10 characters long", 48, "Policy number is invalid!")
                Me.POLISNO.Focus()
                'Andriette 27/05/2014
                blnchange = False
                Exit Sub
            End If
            'Andriette 31/10/2013 toets om te kyk of die polisnommer reeds bestaan

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar)}
                params(0).Value = POLISNO.Text
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlbyPolisno", params)
                If reader.Read Then
                    If reader("polisno") IsNot DBNull.Value Then

                        If (blnByvoeg Or blnPol_Byvoeg) Then
                            MsgBox("A policy with this number already exists. Please use a different policy number", MsgBoxStyle.Exclamation)
                            POLISNO.Clear()
                            POLISNO.Focus()
                            'Andriette 27/05/2014
                            blnchange = False
                            Exit Sub
                        Else
                            'Andriette 24/03/2014 vul met die polisdetail
                            Persoonl = FetchPersoonl()
                            Populatefields()
                            'Andriette 06/06/2014 
                            BFUpdateItemsSubTotals(glbPolicyNumber)
                            HerBereken_Premie()
                        End If
                    Else
                        If Not (blnByvoeg Or blnPol_Byvoeg) Then
                            If POLISNO.Text <> "" Then
                                MsgBox("This policy number does not exist. Please use the add button to add a new policy")
                                POLISNO.Clear()
                                POLISNO.Focus()
                                'Andriette 27/05/2014
                                blnchange = False
                                Exit Sub
                            End If

                        End If
                    End If

                Else
                    If Not (blnByvoeg Or blnPol_Byvoeg) Then
                        If POLISNO.Text <> "" Then
                            MsgBox("This policy number does not exist. Please use the add button to add a new policy")
                            POLISNO.Clear()
                            POLISNO.Focus()
                            'Andriette 27/05/2014
                            blnchange = False
                            Exit Sub
                        End If
                    End If

                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Else
            If (blnByvoeg Or blnPol_Byvoeg) And blnchange Then
                MsgBox("The Policy Number is required.", MsgBoxStyle.Critical)
                POLISNO.Focus()
                blnchange = False
                Exit Sub
            End If
        End If

        'Andriette 01/10/2013 toets om te kyk of adie ander noodsaaklike velde gevul is 
        If (blnPol_Byvoeg Or blnByvoeg) And POLISNO.TextLength = 10 Then
            'Andriette 07/04/2014 net as dit nognie gesave is nie
            If Not blnSavedNew Then
                ToetsNoodsaaklik()
            End If

            SetPoldata1FieldChangesAbility(True)
            AREA.Enabled = True
            VOORL.Enabled = True
            Me.TITEL.Focus()
        End If

        If POLISNO.TextLength = 10 Then
            glbPolicyNumber = POLISNO.Text
        End If

        'Andriette 27/05/2014
        blnchange = False

    End Sub

    Sub Clear_Values()
        Dim strVeldfocus As String = ""
        Try
            blnClear_s = True
            blnLoaded = False
            'Andriette 14/03/2014 stel die byvoeg eers false as die nuwe polis opgeroep word
            blnPol_Byvoeg = False
            blnByvoeg = False
            If Me.ActiveControl Is Nothing Then
            Else
                strVeldfocus = Me.ActiveControl.Name
            End If
            POLISNO.ReadOnly = False
            VERSEKERDE.ReadOnly = False
            'Andriette 23/01/2014 default na engels
            Taal.Items.Clear()
            Taal.Items.Add("Afrikaans")
            Taal.Items.Add("English")

            GEKANS.Items.Clear()
            GEKANS.Items.Add("Active")
            GEKANS.Items.Add("Cancelled")
            blneditmode = False
            Me.BYBET_K.SelectedIndex = -1
            Me.TITEL.SelectedIndex = -1
            If dgvPoldata1Eiendomme.RowCount > 0 Then
                dgvPoldata1Eiendomme.FirstDisplayedScrollingColumnIndex = 1
            End If
            If dgvPoldataVoertuie.RowCount > 0 Then
                dgvPoldataVoertuie.FirstDisplayedScrollingColumnIndex = 1
            End If
            SetPoldata1MenuAbility(False)
            Me.btnSelfoonPremie.Text = FormatNumber(0, 2)
            If Not (Me.VERSEKERDE.Text = "?") Then
                If (Me.VERSEKERDE.Text <> "") And (Me.VOORL.Text <> "") And (Me.POLISNO.Text <> "") Then
                    'area

                    If (Me.AREA.SelectedIndex = -1) And (Me.VERSEKERDE.Text <> "VERSEKERDE") And (Me.VERSEKERDE.Text <> "") And (Me.VOORL.Text <> "VOORL") And (Me.VOORL.Text <> "") Then

                        If Persoonl IsNot Nothing Then
                            If Persoonl.Area = "0" Then
                                If MsgBox("Please select an area for the insured", 48, "Error!") Then
                                    Me.AREA.Focus()
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            'subtotaal(label33) <> 0
            If (Len(Me.Label33.Text) <> 0) And (Me.Combo1.SelectedIndex = -1) Then
                If CDbl(Me.Label33.Text) <> 0 Then
                    MsgBox("Please select Policy Discout/Loading", 48, "Error!")
                    Me.Combo1.Focus()
                    Exit Sub
                End If
            End If

            If Len(Me.txtLiabilityPrem.Text) > 0 Then
                If (Not (IsNumeric(Me.txtLiabilityPrem.Text))) Then
                    MsgBox("The policy fee must be numerical!", 48, "Error!")
                    Me.txtLiabilityPrem.Focus()
                    Exit Sub
                End If
            End If

            If Val(Me.txthomeAsstPrem.Text) > 0 Then
                If (Not (IsNumeric(Me.txthomeAsstPrem.Text))) Then
                    MsgBox("The EPC must be numeric", 48, "Error!")
                    Me.txthomeAsstPrem.Focus()
                    Exit Sub
                End If
            End If
            Bindtitel(1)
            posbestemming.DataSource = ListPOSBESTEMMING(1)
            Me.VANWIE.SelectedIndex = -1
            Me.Betaaldag.Text = "01"
            Me.VERSEKERDE.Text = ""
            Me.VOORL.Text = ""
            Me.POLISNO.Text = ""
            Me.POS_VAKKIE.Text = ""
            Me.BEROEP.Text = ""
            Me.txtBTWno.Text = ""
            Me.dept.Text = ""
            Me.PERS_NOM.Text = ""
            Me.ADRES.Text = "Street address"
            Me.ADRES1.Text = "Town / City"
            Me.ADRES2.Text = "Code"
            Me.adres4.Text = ""
            Me.ID_NOM.Text = ""
            Me.p_a_dat.Text = ""
            Me.WERK_TEL.Text = ""
            Me.HUIS_TEL.Text = ""
            Me.sel_tel.Text = ""
            Me.FAX.Text = ""
            Me.EMAIL.Text = ""
            Me.Ougekans.Text = ""
            Me.GEKANS.Text = ""
            Me.AREA.SelectedIndex = -1
            Me.AREA.SelectedValue = ""

            Me.Plip.Text = ""
            Me.lblVersekeraar.Text = ""
            Me.Plip.Text = ""
            Me.plip2.Text = ""
            Me.BET_DAT.Text = ""
            'Andriette 03/02/2014 
            plip2.SelectedIndex = -1
            plip2.SelectedText = ""
            dtpInceptDt.MinDate = CDate("01/01/1753")
            dtpInceptDt.MaxDate = CDate("31/12/9998")
            PictureBox16.Visible = False
            Me.BET_DAT.Visible = False
            Me.BET_DAT.Location = New Point(110, 111)
            Label22.Text = "First Payment Month"
            Me.BET_DAT.Enabled = False
            Me.cmbPayMonthYear.Visible = True
            ' PictureBox8.Location = New Point(244, 53)

            ' Andriette 11/04/2013 Haal veld uit
            'Me.Besk_nr.Text = "" 
            Me.ADRES3.Text = "Suburb"
            Me.studentno.Text = ""
            Me.txtNoemnaam.Text = ""
            Me.picEmailVerplig.Visible = False
            Me.txtNoemnaam.SelectionStart = 0
            Me.txtNoemnaam.SelectionLength = Len(Me.txtNoemnaam.Text)
            ' Andriette 07/06/2013 As daar inligting in die huis grid is , maak seker die scroll is weer heel links voor jy die grid skoonmaak
            If dgvPoldata1Eiendomme.RowCount > 0 Then
                dgvPoldata1Eiendomme.CurrentCell = dgvPoldata1Eiendomme.Item(0, 0)
            End If
            dgvPoldataVoertuie.DataSource = Nothing
            dgvPoldataVoertuie.Refresh()
            dgvPoldata1Eiendomme.DataSource = Nothing
            dgvPoldata1Eiendomme.Refresh()
            dgvPoldata1AlleRisikoItems.DataSource = Nothing
            dgvPoldata1AlleRisikoItems.Refresh()

            SetPoldata1MenuAbility(False)
            M_Wysig.Enabled = False

            Me.BYBET_K.Text = ""
            Me.TITEL.Text = ""
            Me.VANWIE.Text = ""
            Me.Betaaldag.Text = ""
            Me.VANWIE.SelectedIndex = -1
            Me.GEKANS.SelectedIndex = -1
            Me.Betaaldag.SelectedIndex = -1
            strAanvangGekanseleer = ""
            Me.dgvPoldata1Eiendomme.Text = ""
            Me.dgvPoldata1AlleRisikoItems.Text = ""
            Me.txtLiabilityPrem.Text = ""
            Me.Label33.Text = ""
            Me.Label23.Text = ""

            Me.Verwysingskommissie.Text = " "
            Me.Premie2.Text = FormatNumber(0, 2)
            Me.Verwysdeur.Text = " "
            Me.btnAddisionelePremie.Text = "0.00"
            Me.Label35.Text = ""
            Me.Label36.Text = ""
            Me.Label18.Text = ""
            Me.Label16.Text = ""
            Me.Check1.CheckState = False
            Me.Taal.SelectedIndex = -1
            Me.Combo1.SelectedIndex = -1
            Me.posbestemming.SelectedIndex = -1
            Me.txtCourtesyPrem.Text = " "
            Me.txtRoadsidePrem.Text = FormatNumber(0, 2)
            Me.txthomeAsstPrem.Text = ""
            intMotorvenster = 15
            Me.Oudstudentinstansie.SelectedIndex = -1
            Me.lbltipepolis.Text = ""
            Me.lbltermynperiode.Text = ""
            Me.lbltermynmaande.Text = ""
            Me.lblPakket1Prem.Text = ""
            Me.txtPakketitem2.Text = ""
            Me.lblPolisPakketTotaal.Text = ""
            Me.lblSubtotaalNaKorting.Text = ""
            Me.lblMaandeliksePremie.Text = FormatNumber(0, 2)
            SetPoldata1FieldChangesAbility(False, "Besigtig")
            Persoonl = New PERSOONLEntity()
            ' POLISNO.Focus()
            blnClear_s = False
            grpTermynInligting.Visible = False
            lbltipepolis.Visible = True
            AREA.Enabled = False
            VOORL.Enabled = False
            If strVeldfocus <> "" Then
                Me.ActiveControl.Name = strVeldfocus
                Me.ActiveControl.Focus()
            Else
                VERSEKERDE.Focus()
            End If
            Me.BYBET_K.SelectedIndex = -1
            Me.TITEL.SelectedIndex = -1
            POLISNO.TabIndex = 12
            VERSEKERDE.TabIndex = 5
            btnPremieDetail.Enabled = False
            blnElectronicMail = False
            Poldata1_Stel_Items_Buttons(False)
            'Andriette 07/04/2014 sit die exit button in
            Exit_Renamed.Enabled = True
            BtnCancel.Enabled = True
            'Andriette 27/02/2014
            blnchange = False
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Sub UpdateAlleRisiko()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                New SqlParameter("@beskryf", SqlDbType.NVarChar), _
                                New SqlParameter("@DEKKING", SqlDbType.Money), _
                                New SqlParameter("@PREMIE", SqlDbType.Money), _
                                New SqlParameter("@arnplaat", SqlDbType.NVarChar), _
                                New SqlParameter("@selkontrakmet", SqlDbType.NVarChar), _
                                New SqlParameter("@seldatumaangekoop", SqlDbType.NVarChar), _
                                New SqlParameter("@selnommer", SqlDbType.NVarChar), _
                                New SqlParameter("@Tipe2", SqlDbType.SmallInt), _
                                New SqlParameter("@Beskrywing", SqlDbType.NVarChar), _
                                New SqlParameter("@SERIENOMMER", SqlDbType.NVarChar), _
                                New SqlParameter("@pkAllerisk", SqlDbType.Int), _
                                New SqlParameter("@itemnr", SqlDbType.SmallInt), _
                                New SqlParameter("@Cancelled", SqlDbType.Bit)}

                params(0).Value = Me.POLISNO.Text
                params(1).Value = "Ongespesifiseerd"
                params(2).Value = 2000
                params(3).Value = 0.0
                params(4).Value = ""
                params(5).Value = ""
                params(6).Value = ""
                params(7).Value = ""
                params(8).Value = "299"
                params(9).Value = "Alle risiko ongespesifiseerd"
                params(10).Value = ""
                params(11).Value = DBNull.Value
                params(12).Value = 1
                params(13).Value = 0
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.InsertIntoAlleRisk", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Private Sub POS_VAKKIE_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles POS_VAKKIE.TextChanged
        If (blnLoading = False) And (blnClear_s = False) Then
            blnchange = True
        End If
    End Sub
    Private Sub POS_VAKKIE_GotFocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles POS_VAKKIE.GotFocus
        POS_VAKKIE.SelectionStart = 0
        POS_VAKKIE.SelectionLength = Len(POS_VAKKIE.Text)
    End Sub
    Private Sub POS_VAKKIE_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles POS_VAKKIE.Leave
        Dim strPosvakkie As String = ""

        If blnchange Then
            If (blnByvoeg Or blnPol_Byvoeg) Then
                If blnSavedNew Then
                    UpdatePersoonlPerField("POS_VAKKIE", POS_VAKKIE.Text)
                End If
            Else
                strPosvakkie = Persoonl.POS_VAKKIE

                UpdatePersoonlPerField("POS_VAKKIE", POS_VAKKIE.Text)

                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & (strPosvakkie) & ") na (" & (Me.POS_VAKKIE).Text & ")"
                Else
                    BESKRYWING = " change from (" & (strPosvakkie) & ") to (" & (Me.POS_VAKKIE).Text & ")"
                End If

                UpdateWysig(92, BESKRYWING)
            End If
            blnchange = False
        End If

    End Sub

    Private Sub posbestemming_Leave(sender As Object, e As System.EventArgs) Handles posbestemming.Leave

        If BtnCancel.Focused Then
            Exit Sub
        End If
        If posbestemming.SelectedIndex = -1 Then
            MsgBox("Mail destination is required.", MsgBoxStyle.Exclamation)
            posbestemming.Focus()
        End If

    End Sub
    Private Sub posbestemming_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles posbestemming.SelectedIndexChanged

        If BtnCancel.Focused Then
            Exit Sub
        End If
        If (Not blnClear_s) And (Not blnLoading) Then
            blnchange = True
        Else
            Exit Sub
        End If

        If posbestemming.Text = "Email" Or posbestemming.Text = "Elektroniese pos" Then
            blnElectronicMail = True
            picEmailVerplig.Visible = True
            If (Not (blnClear_s)) And (Not (blnLoading)) Then
            Else
                Exit Sub
            End If
        Else
            blnElectronicMail = False
            picEmailVerplig.Visible = False

        End If

        If (blnPol_Byvoeg Or blnByvoeg) Then
            ToetsNoodsaaklik()
            If blnSavedNew Then
                Persoonl.POSBESTEMMING = Format(posbestemming.SelectedIndex)
                UpdatePersoonlPerField("POSBESTEMMING", Format(posbestemming.SelectedIndex))
            End If
        Else
            UpdatePersoonlPerField("POSBESTEMMING", Format(posbestemming.SelectedIndex))
            'Andriette 05/02/2014 doen hierdie nie as op load is nie
            If Persoonl.TAAL = 0 Then
                BESKRYWING = " wysig na (" & (posbestemming.Text) & ")"
            Else
                BESKRYWING = " changed to (" & (posbestemming.Text) & ")"
            End If
            UpdateWysig(117, BESKRYWING)
            UpdateCLRSField("A", (Me.POLISNO).Text)
            blnchange = False
        End If

        'As posbestemming risiko adres gemaak word, dan moet een van die risiko adresse gemerk wees vir posbestemming
        If posbestemming.Text = "Risk address" Then
            If huis_e.NoMatch = False Then
                MsgBox("You can not choose risk address as mail destination , because there are no properties.")
                posbestemming.Text = "Postal address"
                Exit Sub
            End If

        End If

    End Sub

    Private Sub sel_tel_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sel_tel.TextChanged
        If (blnLoading = False) And (blnClear_s = False) Then
            blnchange = True
        End If
    End Sub

    Private Sub sel_tel_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sel_tel.Leave
        Dim strSelnommer As String = ""
        If blnchange Then
            If sel_tel.Text <> "" Then
                If Not IsNumeric(sel_tel.Text) Then
                    MsgBox("The telephone number must be numeric", 48, "Phone number is invalid!")
                    sel_tel.Text = ""
                    sel_tel.Focus()
                    Exit Sub
                End If
            End If

            If (blnByvoeg Or blnPol_Byvoeg) Then
                If blnSavedNew Then
                    UpdatePersoonlPerField("SEL_TEL", sel_tel.Text)
                End If
            Else

                If IsDBNull(Persoonl.SEL_TEL) Then
                    strSelnommer = ""
                Else
                    strSelnommer = Persoonl.SEL_TEL
                End If

                UpdatePersoonlPerField("SEL_TEL", sel_tel.Text)

                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & (strSelnommer) & ") na (" & (Me.sel_tel).Text & ")"
                Else
                    BESKRYWING = " change from (" & (strSelnommer) & ") to (" & (Me.sel_tel).Text & ")"
                End If

                UpdateWysig(93, BESKRYWING)
                Persoonl.SEL_TEL = sel_tel.Text
            End If
            UpdateCLRSField("A", (Me.POLISNO).Text)
            blnchange = False
        End If

    End Sub
    Private Sub studentno_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles studentno.TextChanged
        If (blnLoading = False) And (blnClear_s = False) Then
            blnchange = True
        End If
    End Sub

    Private Sub studentno_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles studentno.Leave
        Dim strStudentNom As String = ""
        'Andriette 30/10/2013 sluit nuwe polisse uit
        'Andriette 20/02/2014 redesign

        If blnchange Then
            If (blnByvoeg Or blnPol_Byvoeg) Then
                If blnSavedNew Then
                    UpdatePersoonlPerField("studentno", studentno.Text)
                End If
            Else
                strStudentNom = Persoonl.STUDENTNO
                UpdatePersoonlPerField("studentno", studentno.Text)
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & (strStudentNom) & ") na (" & (Me.studentno).Text & ")"
                Else
                    BESKRYWING = " change from (" & (strStudentNom) & ") to (" & (Me.studentno).Text & ")"
                End If

                UpdateWysig(86, BESKRYWING)
            End If
            blnchange = False
        End If

        'Andriette 08/04/2014 voeg by om die volgende tab oop te maak
        If blnByvoeg Or blnPol_Byvoeg Then
            TabDetail.SelectedTab = tabcontactdetail
            posbestemming.Focus()
        End If
    End Sub

    Private Sub Taal_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Taal.SelectedIndexChanged
        'Andriette 19/05/2014 gaan uit as cancel
        If BtnCancel.Focused Then
            Exit Sub
        End If

        If Not (blnClear_s) And Not (blnLoading) Then
            If Taal.SelectedItem Is Nothing Then
                MsgBox("Please select a Language.", MsgBoxStyle.Critical)
                Taal.Focus()
                Exit Sub
            End If
            If (blnByvoeg Or blnPol_Byvoeg) Then

                If blnSavedNew Then
                    UpdatePersoonlPerField("TAAL", Format(Taal.SelectedIndex))
                Else
                    ToetsNoodsaaklik()
                End If
            Else
                UpdatePersoonlPerField("TAAL", Format(Taal.SelectedIndex))

            End If
            UpdateCLRSField("A", (Me.POLISNO).Text)
        End If

    End Sub

    ' Andriette 28/05/2013 Skuif na regte event net onder het geen handle nie
    Private Sub TxtliabilityPrem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Me.txtLiabilityPrem.BackColor = System.Drawing.Color.White
    End Sub
    ' Andriette 28/05/2013 regte event
    Private Sub txtLiabilityPrem_Click1(sender As Object, e As System.EventArgs) Handles txtLiabilityPrem.Click
        Me.txtLiabilityPrem.BackColor = System.Drawing.Color.White
    End Sub

    Private Sub txtLiabilityPrem_Leave(sender As Object, e As System.EventArgs) Handles txtLiabilityPrem.Leave
        Dim strPolisfooi As String = ""
        ' Andriette 28/05/2013 verander sodat dit nie trigger indien nie verander is met die hand nie
        'Andriette 12/06/2013 skuif eerder na die leave event
        'Andriette 21/02/2014 redesign
        If blnchange Then
            txtLiabilityPrem.Text = FormatNumber(Val(txtLiabilityPrem.Text), 2)
            If (blnPol_Byvoeg Or blnByvoeg) Then
                If blnSavedNew Then
                    UpdatePersoonlPerField("POLFOOI", Val(txtLiabilityPrem.Text))
                End If
            Else
                UpdatePersoonlPerField("POLFOOI", Val(txtLiabilityPrem.Text))
                strPolisfooi = Persoonl.POLFOOI

                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & (strPolisfooi) & ") na (" & FormatNumber(Me.txtLiabilityPrem.Text, 2) & ")"
                Else
                    BESKRYWING = " change from (" & (strPolisfooi) & ") to (" & FormatNumber(Me.txtLiabilityPrem.Text, 2) & ")"
                End If
                UpdateWysig(37, BESKRYWING)

            End If
            'Andriette 06/06/2014 
            BFUpdateItemsSubTotals(glbPolicyNumber)
            HerBereken_Premie()
            blnchange = False
        End If

    End Sub

    ' Andriette 28/05/2013 Regte event
    Private Sub txtLiabilityPrem_TextChanged(sender As Object, e As System.EventArgs) Handles txtLiabilityPrem.TextChanged
        If Not blnLoading And Not blnClear_s Then
            blnchange = True
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
        lblTime.Text = String.Format(Now, "dd/MM/yyyy HH:MM")
        'Check for any reminders
        gen_checkReminders()
    End Sub
    Public Sub gen_checkReminders()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@Datum", SqlDbType.DateTime), _
                                               New SqlParameter("@Gebruiker", SqlDbType.NVarChar)}

                param(0).Value = Now()
                param(1).Value = Gebruiker.Naam
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchGenReminders", param)
                While reader.Read()
                    ReminderPopup.intpkReminder = reader("pkReminder")
                    ReminderPopup.dteReminderdatum = reader("datum")
                    ReminderPopup.lblOnderwerp.Text = reader("onderwerp")
                    ReminderPopup.txtBoodskap.Text = reader("boodskap")
                    If IsDBNull(reader("fkMemo")) Then
                        ReminderPopup.intpkMemo = 0
                    Else
                        ReminderPopup.intpkMemo = reader("fkMemo")
                    End If
                    ' Andriette 15/04/2013 moenie die popup wys as dit reeds op die skerm vertoon nie, 
                    'voorkom multiple skerms wat opkom
                    If Not ReminderPopup.Visible Then
                        ReminderPopup.ShowDialog()
                    End If

                End While
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub TITEL_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TITEL.SelectedIndexChanged
        If TITEL.SelectedIndex = -1 Then
            Exit Sub
        End If
        If (blnLoading = False) And (blnClear_s = False) Then
            blnchange = True
        End If
    End Sub
    Private Sub TITEL_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TITEL.Leave
        If Not BtnCancel.Focused Then
            If blnchange Then
                Dim intTitelIndeks As Integer = -1
                Dim item As New ComboBoxEntity
                item = Me.TITEL.SelectedItem
                'andriette 28/02/2014 toets om te sien of dit ingevul is
                If item Is Nothing Then
                    MsgBox("The title must be entered. Please select the correct title.", MsgBoxStyle.Critical)
                    TITEL.Focus()
                    Exit Sub
                End If
                intTitelIndeks = item.ComboBoxID

                If (blnByvoeg Or blnPol_Byvoeg) Then
                    If blnSavedNew Then
                        UpdatePersoonlPerField("TITELNUM", Str(intTitelIndeks))
                    End If
                Else
                    UpdatePersoonlPerField("TITELNUM", Str(intTitelIndeks))
                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = " verander na (" & Trim(Me.TITEL.Text) & ")"
                    Else
                        BESKRYWING = " change to (" & Trim(Me.TITEL.Text) & ")"
                    End If

                    UpdateWysig(82, BESKRYWING)
                    UpdateCLRSField("A", (Me.POLISNO).Text)
                End If
                blnchange = False
                'Andriette 07/04/2014 net as dit nognie gesave is nie
                If Not blnSavedNew Then
                    ToetsNoodsaaklik()
                End If
            End If
        End If
    End Sub

    Private Sub txtBTWno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBTWno.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If Char.IsDigit(e.KeyChar) Then
                'continue
            Else
                e.Handled = True
                MsgBox("Only numbers allowed to be entered in the text box", MsgBoxStyle.Information, "Verify the VAT no")
                txtBTWno.Focus()
                Exit Sub
            End If
        End If
    End Sub
    Private Sub txtBTWno_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBTWno.TextChanged
        'Andriette 30/10/2013 sluit die nuwe polisse uit
        If (blnLoading = False) And (blnClear_s = False) Then 'And Not (pol_byvoeg Or Byvoeg) Then
            blnchange = True
        End If
    End Sub

    Private Sub txtBTWno_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBTWno.Leave
        Dim stroldBtw As String = ""
        'Andriette 20/02/2014 redesign

        If blnchange Then
            If (blnByvoeg Or blnPol_Byvoeg) Then
                If blnSavedNew Then
                    UpdatePersoonlPerField("btwno", Me.txtBTWno.Text)
                End If
            Else
                stroldBtw = Persoonl.BTWNo
                UpdatePersoonlPerField("btwno", Me.txtBTWno.Text)
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " vanaf (" & (stroldBtw) & ") na  (" & (Me.txtBTWno).Text & ")"
                Else
                    BESKRYWING = " from (" & (stroldBtw) & ") to (" & (Me.txtBTWno).Text & ")"
                End If
                UpdateWysig(183, BESKRYWING)
            End If
            blnchange = False
        End If
    End Sub
    Private Sub txtNoemnaam_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtNoemnaam.TextChanged
        'Andriette 30/10/2013 sluit die byvoeg uit
        If (blnLoading = False) And (blnClear_s = False) Then
            blnchange = True
        End If

    End Sub
    Private Sub txtNoemnaam_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtNoemnaam.Leave
        Dim strNaam As String = ""

        If blnchange Then
            If txtNoemnaam.Text.Trim <> strNaam Then
                If (blnByvoeg Or blnPol_Byvoeg) Then

                    If blnSavedNew Then
                        UpdatePersoonlPerField("noemnaam", txtNoemnaam.Text.Trim)
                    End If
                Else
                    strNaam = Persoonl.noemnaam
                    UpdatePersoonlPerField("noemnaam", txtNoemnaam.Text.Trim)
                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = " wysig vanaf (" & (strNaam) & ") na (" & (Me.txtNoemnaam).Text & ")"
                    Else
                        BESKRYWING = " change from (" & (strNaam) & ") to  (" & (Me.txtNoemnaam).Text & ")"
                    End If
                    UpdateWysig(120, BESKRYWING)
                End If

                UpdateCLRSField("A", (Me.POLISNO).Text)
                blnchange = False
            End If
        End If
    End Sub

    Private Sub txtPakketitem2_GotFocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPakketitem2.GotFocus
        Me.txtPakketitem2.BackColor = System.Drawing.Color.White
    End Sub
    Private Sub txtPakketitem2_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPakketitem2.Leave
        Dim tempPakketitem2 As String
        If Not (blnLoading) Then
            If Val(txtPakketitem2.Text) <> Persoonl.PakketItem2 Then
                If txtPakketitem2.Text = " " Then
                    txtPakketitem2.Text = CStr(0)
                End If
                tempPakketitem2 = FormatNumber(Persoonl.PakketItem2, 2)
                UpdatePersoonlPerField("Pakketitem2", Val(txtPakketitem2.Text))
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & (tempPakketitem2) & ") na (" & FormatNumber(Me.txtPakketitem2.Text, 2) & ")"
                Else
                    BESKRYWING = " change from (" & (tempPakketitem2) & ") to (" & FormatNumber(Me.txtPakketitem2.Text, 2) & ")"
                End If
                UpdateWysig(193, BESKRYWING)
                'Andriette 06/06/2014 
                BFUpdateItemsSubTotals(glbPolicyNumber)
                HerBereken_Premie()
            End If
        End If
        Me.txtPakketitem2.BackColor = System.Drawing.ColorTranslator.FromOle(&HC0C0C0)
    End Sub

    Private Sub VANWIE_Leave(sender As Object, e As System.EventArgs) Handles VANWIE.Leave

        'Andriette 19/05/2014 gaan uit as cancel
        If BtnCancel.Focused Then
            Exit Sub
        End If
        If blnPol_Byvoeg Or blnByvoeg Then
            If VANWIE.SelectedIndex = -1 Then
                MsgBox("The Marketer is a required field.", MsgBoxStyle.Exclamation)
                VANWIE.Focus()
                Exit Sub
            End If
        End If

        If blnchange Then
            If VANWIE.SelectedIndex <> -1 Then
                Dim intBemarkIndeks As Integer
                Dim item As New ComboBoxEntity
                '  Dim intcounter As Integer
                item = Me.VANWIE.SelectedItem
                intBemarkIndeks = item.ComboBoxID

                If blnByvoeg Or blnPol_Byvoeg Then
                    If blnSavedNew Then
                        UpdatePersoonlPerField("VANWIE", Trim(Str(intBemarkIndeks)))
                    Else
                        'Andriette 07/04/2014 net as dit nognie gesave is nie
                        ToetsNoodsaaklik()
                    End If
                Else
                    UpdatePersoonlPerField("VANWIE", Trim(Str(intBemarkIndeks)))
                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = " verander na (" & Trim(item.ComboBoxName) & ")"
                    Else
                        BESKRYWING = " change to (" & Trim(item.ComboBoxName) & ")"
                    End If
                    UpdateWysig(83, BESKRYWING)
                End If
            End If
            blnchange = False
        End If

    End Sub
    Private Sub VANWIE_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VANWIE.SelectedIndexChanged
        'andriette 24/02/2014 redesign
        If (blnLoading = False) And (blnClear_s = False) Then
            blnchange = True
        End If
    End Sub
    'Private Sub VDH_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    InitPol()
    'End Sub
    'Andriette 28/01/2014 voeg die tipe by dan hoef dit nie gesoek te word nie
    Sub InsertIntOverwyderdea_Voertuig(ByVal Kode As String, ByVal strTipe As String)
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@kode", SqlDbType.NVarChar), _
                                                New SqlParameter("@jaar", SqlDbType.NVarChar), _
                                                New SqlParameter("@maak", SqlDbType.NVarChar), _
                                                New SqlParameter("@besk", SqlDbType.NVarChar), _
                                                New SqlParameter("@tipe", SqlDbType.NVarChar), _
                                                New SqlParameter("@eeu", SqlDbType.NVarChar), _
                                                New SqlParameter("@verwyderdedatum", SqlDbType.Date)}

                params(0).Value = Kode
                params(1).Value = Trim(Me.dgvPoldataVoertuie.SelectedRows(0).Cells(3).Value).Substring(2, 2)
                params(2).Value = Trim(Me.dgvPoldataVoertuie.SelectedRows(0).Cells(1).Value)
                params(3).Value = Trim(Me.dgvPoldataVoertuie.SelectedRows(0).Cells(2).Value)
                params(4).Value = strTipe
                params(5).Value = Trim(Me.dgvPoldataVoertuie.SelectedRows(0).Cells(3).Value).Substring(0, 2)
                params(6).Value = Now()
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Poldata5.InsertIntoVerwyderdea_voertuig", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Public Sub DeleteFromA_Voertuig(ByVal Kode As String, ByVal strAksie As String)
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params() As SqlParameter = {New SqlParameter("@KODE", SqlDbType.NVarChar), _
                                                New SqlParameter("@verwyderdedatum", SqlDbType.DateTime), _
                                                New SqlParameter("@TransType", SqlDbType.NVarChar)}

                params(0).Value = Kode
                params(1).Value = Now()
                params(2).Value = strAksie

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.DeleteFromA_Voertuig", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Sub Updatevoertuie(ByVal pkVoertuig As String, ByVal blnStatus As Boolean)
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params() As SqlParameter = {New SqlParameter("@pkVoertuie", SqlDbType.Int), _
                                                 New SqlParameter("@Cancelled", SqlDbType.Bit), _
                                                New SqlParameter("@VerwyderdeDatum", SqlDbType.DateTime)}

                params(0).Value = pkVoertuig
                params(1).Value = blnStatus
                params(2).Value = Format(Now, "dd/MM/yyyy")

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.Updatevoertuie", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub
    Sub UpdateAllerisk()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params() As SqlParameter = {New SqlParameter("@pkAllerisk", SqlDbType.Int), _
                                                 New SqlParameter("@Cancelled", SqlDbType.Bit), _
                                                New SqlParameter("@VerwyderdeDatum", SqlDbType.DateTime)}

                params(0).Value = dgvPoldata1AlleRisikoItems.SelectedRows(0).Cells(0).Value
                params(1).Value = True
                params(2).Value = Format(Now, "dd/MM/yyyy")
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateAllerisk", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Vee_Uit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Vee_Uit.Click
        Dim strMessage As String

        If blnNieOpdateer = 1 Then
            MsgBox("This policy's location is not available ... not updating that influence premium is allowed ..")
            Exit Sub
        End If

        Select Case intPoldataGrid_Focus
            'Voertuig
            Case 1

                strKategorieVerander = "voertuig"
                'Kobus 05/12/2013 voegby
                If Me.dgvPoldataVoertuie.RowCount = 0 Or Me.dgvPoldataVoertuie.SelectedRows.Count <= 0 Then
                    Exit Sub
                End If
                voertuie = FetchVoertuie()
                If voertuie.NoMatch = False Then
                    If MsgBox("Are you sure you want to delete the vehicle with registration number:  " & voertuie.N_PLAAT, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                    strreg_uc = UCase(voertuie.N_PLAAT)
                    If InStr(strreg_uc, "ONB") > 0 Then
                        MsgBox("The car registration number is required for a motor to delete", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                    'Andriette 28/08/2013 verander die boodskap
                    If MsgBox("The vehicle radio must be removed in All Risk, where applicable." & Chr(13) & "Continue to delete the vehicle?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                    If voertuie.Huurkoop = True Then
                        If Not gen_WarningsOnCancelorRemove(Me.POLISNO.Text, enumCheckType.ItemRemoved, enumItemType.enum_Vehicle, voertuie.pkVoertuie) Then
                            Exit Sub
                        End If
                    End If
                    If voertuie.ANDER = True Then
                        DeleteFromA_Voertuig(voertuie.KODE, "Delete")
                    End If

                    'write alteration record
                    BESKRYWING = Trim(Me.dgvPoldataVoertuie.SelectedRows(0).Cells(2).Value)
                    BESKRYWING = BESKRYWING & " " & Trim(Me.dgvPoldataVoertuie.SelectedRows(0).Cells(3).Value) & " (" & voertuie.N_PLAAT & ")"
                    UpdateWysig(9, BESKRYWING)

                    'Mark select vehicle as deleted in die Voertuie Table
                    Updatevoertuie(dgvPoldataVoertuie.SelectedRows(0).Cells(0).Value, True)
                    'Andriette 06/06/2014 
                    BFUpdateItemsSubTotals(glbPolicyNumber)
                    HerBereken_Premie()

                    Me.populate_dgvPoldataVoertuie()
                    If dgvPoldataVoertuie.RowCount = 0 Then
                        MsgBox("Please remove the road assistance and Courtesy vehicle premiums there are no vehicles on the policy.", MsgBoxStyle.Exclamation)
                    End If

                End If
                If Check1.CheckState Then

                    'Andriette 02/09/2013 verander die funksie
                    dblpolitiek = Bereken_Sasria_waardes_op_vorm()
                    If Persoonl.BET_WYSE = "6" Then
                        dblpolitiek = dblpolitiek * 12
                    End If
                    UpdatePersoonlPerField("SASPREM", FormatNumber(dblpolitiek, 2))
                    Label36.Text = FormatNumber(dblpolitiek, 2)
                    UpdateSASPREM()

                End If
                intPoldataGrid_Focus = 0
                dgvPoldataVoertuie.ClearSelection()
            Case 2
                strKategorieVerander = "huis"
                If Me.dgvPoldata1Eiendomme.RowCount = 0 Or dgvPoldata1Eiendomme.SelectedRows.Count <= 0 Then
                    Exit Sub
                End If

                ' Andriette 30/04/2013 toets of daar 'n huis is voordat delete kan plaasvind
                If Trim(Me.dgvPoldata1Eiendomme.SelectedCells.Item(0).Value) = "0" Then 'And Trim(Me.Grid2.SelectedCells.Item(1).Value) = "" And Trim(Me.Grid2.SelectedCells.Item(2).Value) = "" Then
                    MsgBox("There are no properties to delete", MsgBoxStyle.Information)
                    Exit Sub
                End If
                ' Andriette 30/04/2013 verander die toets

                If dgvPoldata1Eiendomme.RowCount = dgvPoldata1Eiendomme.RowCount - 1 Then

                    MsgBox("You need to select a property to delete ", 48, " Error!")
                    Exit Sub
                End If

                If MsgBox("Are you sure you want to delete the property?", 17, "Message.") = 2 Then
                    Exit Sub
                End If

                pkHuis = CInt(Me.dgvPoldata1Eiendomme.SelectedCells.Item(13).Value)
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim param As New SqlParameter("@pkHuis", SqlDbType.Int)
                    param.Value = pkHuis

                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchHuisByPrimaryKey", param)

                    If gen_WarningsOnCancelorRemove(Me.POLISNO.Text, enumCheckType.ItemRemoved, enumItemType.enum_Property, pkHuis) Then
                        Exit Sub
                    End If

                    'Andriette verander die beskrywing soos per Kobus 04/10/2013
                    BESKRYWING = "(" & Me.dgvPoldata1Eiendomme.SelectedCells.Item(0).Value.ToString.Trim & ") "
                    If dgvPoldata1Eiendomme.SelectedCells.Item(4).Value <> 0 Then
                        If Persoonl.TAAL = 0 Then
                            BESKRYWING = BESKRYWING & "HE Prem: " & FormatCurrency(dgvPoldata1Eiendomme.SelectedCells.Item(4).Value, 2) & " Waarde "
                        Else
                            BESKRYWING = BESKRYWING & "HO Prem: " & FormatCurrency(dgvPoldata1Eiendomme.SelectedCells.Item(4).Value, 2) & " Value "
                        End If
                        BESKRYWING = BESKRYWING & FormatCurrency(dgvPoldata1Eiendomme.SelectedCells.Item(3).Value, 0)
                    End If

                    If dgvPoldata1Eiendomme.SelectedCells.Item(6).Value <> 0 Then
                        If Persoonl.TAAL = 0 Then
                            BESKRYWING = BESKRYWING & " HB Prem: " & FormatCurrency(dgvPoldata1Eiendomme.SelectedCells.Item(6).Value, 2) & " Waarde "
                        Else
                            BESKRYWING = BESKRYWING & " HH Prem: " & FormatCurrency(dgvPoldata1Eiendomme.SelectedCells.Item(6).Value, 2) & " Value "
                        End If
                        BESKRYWING = BESKRYWING & FormatCurrency(dgvPoldata1Eiendomme.SelectedCells.Item(5).Value, 0)
                    End If
                    If dgvPoldata1Eiendomme.SelectedCells.Item(9).Value <> 0 Then
                        If Persoonl.TAAL = 0 Then
                            BESKRYWING = BESKRYWING & " Acc Prem: " & FormatCurrency(dgvPoldata1Eiendomme.SelectedCells.Item(9).Value, 2) & " Waarde "
                        Else
                            BESKRYWING = BESKRYWING & " Ong Prem: " & FormatCurrency(dgvPoldata1Eiendomme.SelectedCells.Item(9).Value, 2) & " Value "
                        End If
                        BESKRYWING = BESKRYWING & FormatCurrency(dgvPoldata1Eiendomme.SelectedCells.Item(8).Value, 0)
                    End If
                    If dgvPoldata1Eiendomme.SelectedCells.Item(11).Value <> 0 Then
                        If Persoonl.TAAL = 0 Then
                            BESKRYWING = BESKRYWING & " EEM Prem: " & FormatCurrency(dgvPoldata1Eiendomme.SelectedCells.Item(11).Value, 2) & " Waarde "
                        Else
                            BESKRYWING = BESKRYWING & " EEM Prem: " & FormatCurrency(dgvPoldata1Eiendomme.SelectedCells.Item(11).Value, 2) & " Value "
                        End If
                        BESKRYWING = BESKRYWING & FormatCurrency(dgvPoldata1Eiendomme.SelectedCells.Item(10).Value, 0)
                    End If
                    UpdateWysig(17, BESKRYWING)

                    dblHuise_Sub = dblHuise_Sub - (Val(dgvPoldata1Eiendomme.SelectedCells.Item(4).Value) + Val(dgvPoldata1Eiendomme.SelectedCells.Item(6).Value) + Val(dgvPoldata1Eiendomme.SelectedCells.Item(9).Value) + Val(dgvPoldata1Eiendomme.SelectedCells.Item(11).Value))

                    strMessage = "Please note the following:" & Chr(13) & Chr(13)
                    strMessage = strMessage & Chr(149) & " Due to the fact that the property has been removed, make sure the overnight address of any vehicles is still correct."

                    MsgBox(strMessage, MsgBoxStyle.Information)

                    UpdateHuisWithPrimaryKey()
                    UpdateHuisWithPrimaryKey1()
                    populate_dgvPoldata1Eiendomme()
                    If dgvPoldata1Eiendomme.RowCount = 0 Then
                        MsgBox("Please remove the Home assistance premium there are no properties on the policy.", MsgBoxStyle.Exclamation)
                    End If
                    'Andriette 06/06/2014 
                    BFUpdateItemsSubTotals(glbPolicyNumber)
                    'Andriette 20/09/2013 skuif af na onder omdat die huis nognie verwyder is nie
                    HerBereken_Premie()
                    'Andriette 24/10/2013 alles geskuif na herbereken premie
                    'doen_subtotaal()
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                End Using
                If Check1.CheckState Then
                    '			
                    'Andriette 02/09/2013 verander die funksie
                    dblpolitiek = Bereken_Sasria_waardes_op_vorm()

                    If Persoonl.BET_WYSE = "6" Then
                        dblpolitiek = dblpolitiek * 12
                    End If

                    Persoonl.SASPREM = FormatNumber(dblpolitiek, 2)
                    'Persoonl.Update()
                    UpdatePersoonlPerField("SASPREM", FormatNumber(dblpolitiek, 2))

                    Label36.Text = FormatNumber(dblpolitiek, 2)
                    UpdateSASPREM()
                End If
                'Kobus 05/12/2013 comment out 
                dgvPoldata1Eiendomme.ClearSelection()
                intPoldataGrid_Focus = 0
            Case 3

                'Andriette 03/02/2014 toets vir leeg

                If dgvPoldata1AlleRisikoItems.RowCount = 0 Or dgvPoldata1AlleRisikoItems.SelectedRows.Count <= 0 Then
                    Exit Sub
                End If

                strKategorieVerander = "alle risiko"
                If MsgBox("Are you sure you want to delete the item?", 17, "Message.") = 2 Then
                    Exit Sub
                End If

                dblalle_sub = dblalle_sub - dgvPoldata1AlleRisikoItems.SelectedCells.Item(4).Value
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = "(" & dgvPoldata1AlleRisikoItems.SelectedCells.Item(1).Value.trim & ") premie (" & FormatNumber(dgvPoldata1AlleRisikoItems.SelectedCells.Item(4).Value, 2) & ") waarde (" + FormatNumber(dgvPoldata1AlleRisikoItems.SelectedCells.Item(3).Value, 0) + ")"
                Else
                    BESKRYWING = "(" & dgvPoldata1AlleRisikoItems.SelectedCells.Item(1).Value.trim & ") premium (" & FormatNumber(dgvPoldata1AlleRisikoItems.SelectedCells.Item(4).Value, 2) & ") value (" + FormatNumber(dgvPoldata1AlleRisikoItems.SelectedCells.Item(3).Value, 0) + ")"
                End If
                UpdateWysig(20, BESKRYWING)
                UpdateAllerisk()
                populate_dgvPoldata1AlleRisikoItems()
                dgvPoldata1AlleRisikoItems.Refresh()
                dgvPoldata1AlleRisikoItems.ClearSelection()
                'Andriette 06/06/2014 
                BFUpdateItemsSubTotals(glbPolicyNumber)
                HerBereken_Premie()

                If Check1.CheckState Then

                    'Andriette 02/09/2013 verander die funksie
                    dblpolitiek = Bereken_Sasria_waardes_op_vorm()
                    If Persoonl.BET_WYSE = "6" Then
                        dblpolitiek = dblpolitiek * 12
                    End If
                    Persoonl.SASPREM = FormatNumber(dblpolitiek, 2)
                    UpdatePersoonlPerField("SASPREM", FormatNumber(dblpolitiek, 2))
                    Label36.Text = FormatNumber(dblpolitiek, 2)
                    UpdateSASPREM()
                End If

                intPoldataGrid_Focus = 0
            Case Else
                MsgBox("No items selected", MsgBoxStyle.Exclamation)

        End Select
        btnVerwyderdeItems.Focus()
    End Sub
    Public Sub UpdateHuisWithPrimaryKey()
        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim params() As SqlParameter = {New SqlParameter("@pkHuis", SqlDbType.Int), _
                                            New SqlParameter("@DatumVerwyder", SqlDbType.DateTime)}
            params(0).Value = pkHuis
            params(1).Value = Now

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[UpdateHuiswithPrimaryKey]", params)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Using
    End Sub
    Private Sub Versekerde_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VERSEKERDE.Click

        If BtnCancel.Focused Then
            BtnCancel.PerformClick()
            VERSEKERDE.Focus()
        End If
        VERSEKERDE.ReadOnly = False

        'Andriette 25/03/2014 as jy click na die byvoeg moet dit ook skoonmaak
        If blnSavedNew Then
            Clear_Values()
            TabDetail.SelectedTab = TabInligting
            VERSEKERDE.Focus()
        Else
            If blnByvoeg Or blnPol_Byvoeg Then
                ToetsNoodsaaklik()
            End If
        End If
        VERSEKERDE.Focus()

    End Sub
    Private Sub VERSEKERDE_GotFocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VERSEKERDE.GotFocus
        ShareObjectsForm1()
    End Sub

    Private Sub VERSEKERDE_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VERSEKERDE.Leave
        VERSEKERDE.Text = UCase(VERSEKERDE.Text)
        'Andriette 01/10/2013 voeg 'n toets by dat hierdie veld op die byvoeg van polis gevul moet wees
        If Not BtnCancel.Focused Then
            If (Not blnLoading And (Not blnClear_s)) And (blnByvoeg Or blnPol_Byvoeg) Then
                If VERSEKERDE.Text.Length < 1 Then

                    MsgBox("The Insured Name must be entered.", 48, "It cannot be left empty when adding a policy")
                    Me.VERSEKERDE.Focus()
                    Exit Sub
                End If
            End If
            'Andriette 07/04/2014 net as dit nognie gesave is nie

            If (blnByvoeg Or blnPol_Byvoeg) And Not blnSavedNew Then
                ToetsNoodsaaklik()
            End If
        End If

    End Sub
    Sub UpdateSASPREM()
        Dim dblpolitiek As Double
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@SASPREM", SqlDbType.Money)}

                params(0).Value = Persoonl.POLISNO
                'Andriette 02/09/2013 verander die funksie
                dblpolitiek = Bereken_Sasria_waardes_op_vorm()
                If Persoonl.BET_WYSE = "6" Then
                    dblpolitiek = dblpolitiek * 12
                End If

                params(1).Value = FormatNumber(dblpolitiek, 2)

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateSASPREM", params)

                If Not (blnByvoeg Or blnPol_Byvoeg) Then
                    UpdatePersoonlPerField("SASPREM", dblpolitiek)
                End If

                Label36.Text = FormatNumber(dblpolitiek, 2)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Private Sub Voeg_By_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Voeg_By.Click

        If Not Me.validataPostalAddress Then
            Exit Sub
        End If
        blnHuisvoegby = True
        If blnNieOpdateer = 1 Then
            MsgBox("This policy's location is not available ... not updating that influence premium is allowed .. ")
            Exit Sub
        End If

        '   Ander_M = False

        Select Case intPoldataGrid_Focus
            Case 1
                strKategorieVerander = "voertuig"
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                'Set pk for vehicle
                blnediting = False
                If blnediting = False Then
                    pkVoertuie = 0
                    VoertuigDetail.ShowDialog()
                End If

            Case 2
                strKategorieVerander = "huis"

                'huis_e.Close()
                blnediting = False
                Huis_EF.ShowDialog()
            Case 3

                strKategorieVerander = "alle risiko"
                A_Risiko.Dekking.Text = ""
                A_Risiko.Premie.Text = ""
                blnediting = False
                A_Risiko.btnVoegby.Left = A_Risiko.btnRedigeer.Left
                A_Risiko.btnVoegby.Top = A_Risiko.btnRedigeer.Top
                A_Risiko.btnVoegby.Visible = True
                A_Risiko.btnRedigeer.Visible = False
                A_Risiko.ShowDialog()
        End Select

        BFUpdateItemsSubTotals(glbPolicyNumber)
        HerBereken_Premie()

        If Check1.CheckState Then
            UpdateSASPREM()
        Else
            Label36.Text = FormatNumber(0, 2)
            Persoonl.SASPREM = 0
        End If
    End Sub

    Private Sub VOORL_TextChanged(sender As Object, e As System.EventArgs) Handles VOORL.TextChanged
        If (blnLoading = False) And (blnClear_s = False) Then
            blnchange = True
        End If
    End Sub

    Private Sub Voorl_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VOORL.Leave
        'Andriette 27/05/2014
        VOORL.Text = VOORL.Text.ToUpper
        Me.VOORL.Text = Mid(VOORL.Text, 1, 5)
        If blnchange Then

            If (blnByvoeg Or blnPol_Byvoeg) Then
                If Len(VOORL.Text) < 1 Then
                    MsgBox("The Insured Initials should be entered", 48, "It cannot be left empty when adding a policy")
                    Me.VOORL.Focus()
                    Exit Sub
                End If
                If blnSavedNew Then

                    'Andriette 24/04/2014 geskiedenis
                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = " wysig vanaf (" & Persoonl.VOORL & ") na (" + Me.VOORL.Text.Trim.ToUpper + ")"
                    Else
                        BESKRYWING = " change from (" & Persoonl.VOORL & ") to (" + Me.VOORL.Text.Trim.ToUpper + ")"
                    End If

                    UpdateWysig(51, BESKRYWING)
                    UpdatePersoonlPerField("voorl", VOORL.Text.ToUpper)
                Else
                    'Andriette 07/04/2014 net as dit nognie gesave is nie
                    ToetsNoodsaaklik()
                End If

            Else
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & Persoonl.VOORL & ") na (" + Me.VOORL.Text.Trim.ToUpper + ")"
                Else
                    BESKRYWING = " change from (" & Persoonl.VOORL & ") to (" + Me.VOORL.Text.Trim.ToUpper + ")"
                End If

                UpdateWysig(51, BESKRYWING)
                UpdatePersoonlPerField("voorl", VOORL.Text.ToUpper)
            End If

            If Me.POLISNO.Text <> "" Then
                UpdateCLRSField("A", Me.POLISNO.Text)
            End If
            blnchange = False
        End If

    End Sub

    Private Sub WERK_TEL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles WERK_TEL.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If Char.IsDigit(e.KeyChar) Then
                'do nothing
            Else
                e.Handled = True
                MsgBox("Only numbers are allowed in the and no spaces", MsgBoxStyle.Information, "Verify work numbers")
                WERK_TEL.Focus()
                Exit Sub
            End If
        End If

    End Sub
    Private Sub WERK_TEL_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WERK_TEL.TextChanged

        'Andriette 30/10/2013 sluit nuwe polisse uit
        'Andriette 21/02/2014 moenie nuwe polisse uitsluit nie
        If (blnLoading = False) And (blnClear_s = False) Then ' And Not (pol_byvoeg Or Byvoeg) Then
            blnchange = True
        End If
    End Sub

    Private Sub WERK_TEL_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WERK_TEL.Leave
        Dim strWerktel As String = ""
        'Andriette 30/10/2013 sluit nuwe polisse uit
        'Andriette 21/02/2014 redesign

        If blnchange Then
            If WERK_TEL.Text <> "" Then
                If Not IsNumeric(WERK_TEL.Text) Then
                    MsgBox("The telephone number must be numeric", 48, "Phone number is invalid!")
                    WERK_TEL.Text = ""
                    WERK_TEL.Focus()
                    Exit Sub
                End If
            End If
            If (blnByvoeg Or blnPol_Byvoeg) Then
                If blnSavedNew Then
                    UpdatePersoonlPerField("WERK_TEL2", WERK_TEL.Text)
                End If
            Else
                strWerktel = Persoonl.WERK_TEL2
                UpdatePersoonlPerField("WERK_TEL2", WERK_TEL.Text)

                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & (strWerktel) & ") na (" & (Me.WERK_TEL).Text & ")"
                Else
                    BESKRYWING = " change from (" & (strWerktel) & ") to (" & (Me.WERK_TEL).Text & ")"
                End If
                UpdateWysig(88, BESKRYWING)
            End If
            blnchange = False
            UpdateCLRSField("A", (Me.POLISNO).Text)
        End If

    End Sub

    Public Sub populate_dgvPoldata1Eiendomme()
        dgvPoldata1Eiendomme.DataSource = Nothing
        ' Grid2.CurrentCell = Grid2.Item(0, 0)
        If Persoonl.POLISNO <> "" Then
            Try
                Dim list As List(Of HuisEntity) = New List(Of HuisEntity)
                ' Andriette 14/06/2013 maak seker die polisnommer is reg
                'list = ListHuis(POLISNO.Text)
                list = ListHuis(Persoonl.POLISNO)
                If list.Count > 0 Then
                    Dim columnHeaderStyle As New DataGridViewCellStyle
                    columnHeaderStyle.BackColor = Color.Aqua
                    columnHeaderStyle.Font = New Font("Microsoft Sans Serif", 7.5, FontStyle.Bold)
                    dgvPoldata1Eiendomme.ColumnHeadersDefaultCellStyle = columnHeaderStyle
                    dgvPoldata1Eiendomme.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7.5, FontStyle.Italic)
                    dgvPoldata1Eiendomme.ColumnHeadersHeight = 22
                    dgvPoldata1Eiendomme.RowTemplate.Height = 15

                    dgvPoldata1Eiendomme.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvPoldata1Eiendomme.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvPoldata1Eiendomme.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvPoldata1Eiendomme.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvPoldata1Eiendomme.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvPoldata1Eiendomme.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvPoldata1Eiendomme.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvPoldata1Eiendomme.Columns(11).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                    dgvPoldata1Eiendomme.AutoGenerateColumns = False
                    dgvPoldata1Eiendomme.DataSource = list
                    dgvPoldata1Eiendomme.Refresh()
                    dgvPoldata1Eiendomme.CurrentCell = dgvPoldata1Eiendomme.Item(0, 0)
                Else
                    'Andriette 17/02/2014 haal uit
                    ''Kobus 05/12/2013 voegby
                    'If blnVee_Uit = True Then
                    '    Grid2.DataSource = Nothing
                    '    Grid2.Refresh()
                    '    MsgBox("Please remove the Home assistance premium, because there are no properties left.", MsgBoxStyle.Exclamation)
                    '    blnVee_Uit = False
                    'End If
                    dgvPoldata1Eiendomme.DataSource = Nothing
                    dgvPoldata1Eiendomme.Refresh()
                End If
            Catch ex As Exception
                ' Andriette 2013-02-18 wys die regte boodskap
                'MsgBox("There's error trying to connect to the database.", MsgBoxStyle.Exclamation)
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)

            End Try

        End If
    End Sub
    Public Sub populate_dgvPoldata1AlleRisikoItems()
        ' Andriette 14/06/2013 maak seker die program gebruik die korrekte polisnommer
        'If polisno.text <> "" Then
        ' If Persoonl.POLISNO <> "" Then
        If glbPolicyNumber <> "" Then

            Try
                Dim list As List(Of ALLERISKEntity) = New List(Of ALLERISKEntity)
                list = ListALLERISKByPolisno(glbPolicyNumber)

                If list.Count > 0 Then
                    Dim columnHeaderStyle As New DataGridViewCellStyle
                    columnHeaderStyle.BackColor = Color.Aqua
                    columnHeaderStyle.Font = New Font("Microsoft Sans Serif", 7.5, FontStyle.Bold)
                    dgvPoldata1AlleRisikoItems.ColumnHeadersDefaultCellStyle = columnHeaderStyle
                    dgvPoldata1AlleRisikoItems.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7.5, FontStyle.Italic)
                    dgvPoldata1AlleRisikoItems.ColumnHeadersHeight = 22
                    dgvPoldata1AlleRisikoItems.RowTemplate.Height = 15

                    dgvPoldata1AlleRisikoItems.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvPoldata1AlleRisikoItems.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvPoldata1AlleRisikoItems.Columns(4).DefaultCellStyle.Format = "C"
                    dgvPoldata1AlleRisikoItems.AutoGenerateColumns = False
                    dgvPoldata1AlleRisikoItems.DataSource = list
                    dgvPoldata1AlleRisikoItems.Refresh()
                Else
                    dgvPoldata1AlleRisikoItems.DataSource = Nothing
                    dgvPoldataVoertuie.Refresh()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    'Description  : Procedure to populate the grid containing all vehicles for this policy.
    Public Sub populate_dgvPoldataVoertuie()

        If Persoonl.POLISNO <> "" Then

            listVoertuig = ListVoertuie(Persoonl.POLISNO)
            If Not IsNothing(listVoertuig) Then
                If listVoertuig.Count > 0 Then
                    Dim columnHeaderStyle As New DataGridViewCellStyle
                    columnHeaderStyle.BackColor = Color.Aqua
                    ' andriette maak die header bietjie kleiner
                    columnHeaderStyle.Font = New Font("Microsoft Sans Serif", 7.5, FontStyle.Bold)
                    dgvPoldataVoertuie.ColumnHeadersDefaultCellStyle = columnHeaderStyle
                    dgvPoldataVoertuie.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7.5, FontStyle.Italic)
                    dgvPoldataVoertuie.ColumnHeadersHeight = 22
                    dgvPoldataVoertuie.RowTemplate.Height = 15

                    dgvPoldataVoertuie.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvPoldataVoertuie.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvPoldataVoertuie.Columns(7).DefaultCellStyle.Format = "C"
                    dgvPoldataVoertuie.AutoGenerateColumns = False
                    dgvPoldataVoertuie.DataSource = listVoertuig

                    Dim SECURITY As String

                    For K As Integer = 0 To dgvPoldataVoertuie.RowCount - 1
                        SECURITY = gen_getVehicleSecurity(Persoonl.TAAL, dgvPoldataVoertuie.Rows(K).Cells(8).Value)
                        dgvPoldataVoertuie.Rows(K).Cells(8).Value = SECURITY
                    Next
                    For i As Integer = 0 To dgvPoldataVoertuie.RowCount - 1

                        If dgvPoldataVoertuie.Rows(i).Cells(5).Value = 1 Then
                            dgvPoldataVoertuie.Rows(i).Cells(5).Value = "Omv"
                        ElseIf dgvPoldataVoertuie.Rows(i).Cells(5).Value = 2 Then
                            dgvPoldataVoertuie.Rows(i).Cells(5).Value = "BD&D"
                        ElseIf dgvPoldataVoertuie.Rows(i).Cells(5).Value = 3 Then
                            dgvPoldataVoertuie.Rows(i).Cells(5).Value = "BD"
                        End If
                    Next
                Else
                    dgvPoldataVoertuie.DataSource = Nothing
                    dgvPoldataVoertuie.Refresh()
                End If
            End If
        End If
    End Sub
    'Check if postal address was completed with national postal codes
    Public Function validataPostalAddress() As Boolean
        If Me.ADRES3.Text = "Voorstad" Then
            validataPostalAddress = False
            MsgBox("Please use the Postalcode button to address the remedy", MsgBoxStyle.Exclamation)
            Me.btnPostalCodes.Focus()
            Exit Function
        End If
        If Me.ADRES1.Text = "Dorp / Stad" Then
            validataPostalAddress = False
            MsgBox("Please use the Postalcode button to address the remedy", MsgBoxStyle.Exclamation)
            Me.btnPostalCodes.Focus()
            Exit Function
        End If
        If Me.ADRES2.Text = "Kode" Then
            validataPostalAddress = False
            MsgBox("Please use the Postalcode button to address the remedy", MsgBoxStyle.Exclamation)
            Me.btnPostalCodes.Focus()
            Exit Function
        End If

        'Valid
        validataPostalAddress = True
    End Function
    'Get the status for the 'Termynpolis' and populate fields on form1 - only for viewing
    ' ** The logic used in this sub is similar to the logic used in BriefSkedule to determine status and premium
    ' ** Keep the working of both these procedures the same to ensure continuity
    Public Sub getLangtermynStatus()
        Me.lbltermynmaande.Text = ""
        Me.lbltermynperiode.Text = ""
        Me.lblTermynStatus.Text = ""
        'Get status and descriptions
        'Andriette 09/07/2014 verander die funksie om net die polisnommer te ontvang en dan die langtermynpolis se entity te populate
        'Andriette 11/09/2014 verander die parameter sodat dit vir nuwe termynpolisse ook kan werk
        'gen_getTermPolicyStatus(Persoonl.POLISNO)
        gen_getTermPolicyStatus(glbPolicyNumber)
        lbltermynperiode.Text = strTermDesc
        lblTermynStatus.Text = strTermStatusDesc
        lbltermynmaande.Text = FormatNumber(EntLangtermynpolis.Tydperk, 0)

    End Sub
    'Disable certain controls when this policy is a longtermpolicy
    Public Sub enableCtrlsForLongtermPolicy(ByRef enabled_Renamed As Boolean)
        ' Andriette 09/04/2013 verander na ;n btn
        Me.btnAddisionelePremie.Enabled = enabled_Renamed
        Me.mnuAddisionelepremie.Enabled = enabled_Renamed
        Me.Verwysdes.Enabled = enabled_Renamed
    End Sub
    'Hide, unhide term policy fields
    Public Sub termFieldsVisible(ByRef isVisible As Boolean)
        Me.lbltermynperiode.Visible = isVisible
        Me.Label74.Visible = isVisible
        Me.Label77.Visible = isVisible
        Me.lblTermynStatus.Visible = isVisible
        Me.Label75.Visible = isVisible
        Me.lbltermynmaande.Visible = isVisible

    End Sub
    Public Function validateFields() As Object
        validateFields = True

        'n JK of TP mag nie verwys nie
        'n Gekanselleerde mag ook nie verwys nie
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar)}
                params(0).Value = POLISNO.Text
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlByPolisno", params)
                Do While reader.Read
                    If reader("BET_WYSE") = "2" Or reader("BET_WYSE") = "6" Then
                        MsgBox("a term policy may not pay someone .", MsgBoxStyle.Exclamation, "Poldata")
                        validateFields = False
                        Exit Function
                    End If
                Loop
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function

    ''* Purpose:       To test premie2 adn return an error message if premie2 is less than zero or between 0 and 10
    ''* Inputs :       strPolisno
    ''* Outputs:       blnKleinerasNul, blnTussenNulenTien, strMsg, Premie
    'Public Sub form1_ToetsPremie(ByRef blnKleinerasnul As Boolean, ByRef blnTussenNulenTienRand As Boolean, ByRef strMsg As String, ByRef Premie As Double, ByRef strPolisno As String)

    '    blnKleinerasnul = False
    '    blnTussenNulenTienRand = False
    '    strMsg = ""

    '    If Premie < 0 Then
    '        strMsg = "Die premie is kleiner as R0 vir polis (" & strPolisno & "). Korrigeer asseblief en loop program weer. Program eindig"
    '        blnKleinerasnul = True
    '        Me.Cursor = System.Windows.Forms.Cursors.Default
    '    ElseIf Premie >= 0 And Premie < 10 Then
    '        strMsg = "Die premie is kleiner as R10 vir polis (" & strPolisno & "). Maak seker dat dit korrek is. Program gaan aan."
    '        blnTussenNulenTienRand = True
    '    End If
    'End Sub

    'Insert the alteration record for betwyse
    ' Andriette 07/03/2013 verander na 'n private sub daar is reeds so een in Baseform
    'Public Function BetWyseAlteration(ByRef btePreviousBetWyse As Byte) As Object
    Private Sub BetWyseAlteration(ByRef btePreviousBetWyse As Byte)
        'Was on monthly salary - insert alteration
        If btePreviousBetWyse = 3 Then
            UpdateWysig((65), "")
        End If
        'Was on monthly debit - insert alteration
        If btePreviousBetWyse = 4 Then
            UpdateWysig((43), "")
        End If

        Select Case Persoonl.BET_WYSE
            Case "1" 'Monthly cash
                UpdateWysig((22), "")
            Case "2" 'Annual cash
                UpdateWysig((23), "")
            Case "3" 'Monthly salary
                UpdateWysig((24), "")
            Case "4" 'Monthly debit
                UpdateWysig((25), "")
            Case "5" 'Monthly electronic
                UpdateWysig((177), "")
            Case "6" 'Term policy
                UpdateWysig((184), "")
        End Select
    End Sub

    Public Sub Wysig99Tot2006_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Wysig99Tot2006.Click
        Wysig2006.Show()
    End Sub
    Private Sub m_daagliks_lys_2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_daagliks_lys_2.Click
        frmLysVanDaaglikseWysigings.ShowDialog()
    End Sub
    Private Sub Grid2_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvPoldata1Eiendomme.CellFormatting
        If Persoonl IsNot Nothing Then
            'Andriette 13/08/2013 verander van sekuriteit na Sekuriteitsbit
            ' If Grid2.Columns(e.ColumnIndex).Name = "Sekuriteit" Then
            If dgvPoldata1Eiendomme.Columns(e.ColumnIndex).Name = "SekuriteitBitValue" Then
                If IsNumeric(e.Value) Then
                    e.Value = gen_getPropertySecurity(Persoonl.TAAL, CInt(e.Value))
                Else
                    If e.Value = "Geen" Or Trim(e.Value) = "" Then
                        If Persoonl.TAAL = 0 Then
                            e.Value = ""
                        Else
                            e.Value = ""
                        End If

                    End If
                End If

            End If
            If dgvPoldata1Eiendomme.Columns(e.ColumnIndex).Name = "TIPE_DAK" Then
                If Persoonl.TAAL = "0" Then
                    Select Case e.Value
                        Case "1"
                            e.Value = "Teël Staan"
                        Case "2"
                            e.Value = "Sink Staan"
                        Case "3"
                            e.Value = "Sink Plat"
                        Case "4"
                            e.Value = "Asbes Staan"
                        Case "5"
                            e.Value = "Asbes Plat"
                        Case "6"
                            e.Value = "Grasdak"
                        Case "7"
                            e.Value = "Ander Staan"
                        Case "8"
                            e.Value = "Ander Plat"
                    End Select
                Else
                    Select Case e.Value
                        Case "1"
                            e.Value = "Pitch Tiled"
                        Case "2"
                            e.Value = "Pitch Iron"
                        Case "3"
                            e.Value = "Flat Iron"
                        Case "4"
                            e.Value = "Pitch Asbestos"
                        Case "5"
                            e.Value = "Flat Asbestos"
                        Case "6"
                            e.Value = "Pitch Grass"
                        Case "7"
                            e.Value = "Other Pitched"
                        Case "8"
                            e.Value = "Other Flat"
                    End Select

                End If
            End If
            If dgvPoldata1Eiendomme.Columns(e.ColumnIndex).Name = "Struktuur" Then
                If Persoonl.TAAL = "0" Then
                    Select Case e.Value
                        Case "1"
                            e.Value = "Standard"
                        Case "2"
                            e.Value = "Wood"
                        Case "3"
                            e.Value = "Not stand"
                        Case "4"
                            e.Value = "Beach house"
                        Case "5"
                            e.Value = "Asbestos"
                    End Select
                Else
                    Select Case e.Value
                        Case "1"
                            e.Value = "Standard"
                        Case "2"
                            e.Value = "Wood"
                        Case "3"
                            e.Value = "Not stand"
                        Case "4"
                            e.Value = "Beach house"
                        Case "5"
                            e.Value = "Asbestos"
                    End Select
                End If
            End If
            If dgvPoldata1Eiendomme.Columns(e.ColumnIndex).Name = "PREMIE_HE" Then
                If e.Value = Nothing Then
                    e.Value = "0.00"
                End If
            End If
            If dgvPoldata1Eiendomme.Columns(e.ColumnIndex).Name = "PREMIE_HB" Then
                If e.Value = Nothing Then

                    e.Value = "0.00"
                End If

            End If
            If dgvPoldata1Eiendomme.Columns(e.ColumnIndex).Name = "toe_premie" Then
                If e.Value = Nothing Then
                    e.Value = "0.00"
                End If
            End If
            If dgvPoldata1Eiendomme.Columns(e.ColumnIndex).Name = "eem_premie" Then
                If e.Value = Nothing Then
                    e.Value = "0.00"
                End If
            End If

            If dgvPoldata1Eiendomme.Columns(e.ColumnIndex).Name = "toe_premie" Then
                If e.Value = Nothing Then
                    e.Value = "0.00"
                End If
            End If
            If dgvPoldata1Eiendomme.Columns(e.ColumnIndex).Name = "ADRES_H1" Then
                If e.Value = Nothing Then
                    e.Value = ""
                End If

            End If
            If dgvPoldata1Eiendomme.Columns(e.ColumnIndex).Name = "mainProperty" Then
                If e.Value = Nothing Then
                    e.Value = ""
                End If
            End If
        End If
        Dim columnHeaderStyle As New DataGridViewCellStyle
        columnHeaderStyle.BackColor = Color.Aqua
        columnHeaderStyle.Font = New Font("Microsoft Sans Serif", 6.5, FontStyle.Bold)
        dgvPoldata1Eiendomme.ColumnHeadersDefaultCellStyle = columnHeaderStyle
    End Sub


    Private Sub Grid1_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvPoldataVoertuie.CellFormatting
        If dgvPoldataVoertuie.Columns(e.ColumnIndex).Name = "Security" Then
            e.Value = gen_getVehicleSecurity(Persoonl.TAAL, CInt(e.Value))
        End If

        If dgvPoldataVoertuie.Columns(e.ColumnIndex).Name = "Cover" Then
            Select Case e.Value
                Case "1"
                    e.Value = "Omv"
                Case "2"
                    e.Value = "BDB"
                Case "3"
                    e.Value = "BD"
            End Select
        End If
    End Sub
    Public Sub GetDetailsByReg(ByVal regstration As String)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@n_plaat", SqlDbType.NVarChar), _
                                             New SqlParameter("@gebruiker", SqlDbType.NVarChar), _
                                             New SqlParameter("@branchCode", SqlDbType.NVarChar)}

                param(0).Value = regstration
                param(1).Value = Gebruiker.titel
                param(2).Value = Gebruiker.BranchCodes
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertueiByNplaat", param)

                If reader.Read Then
                    POLISNO.Text = reader("POLISNO")
                Else
                    If MsgBox("No vehicle registration'" & regstration & "' is found.", MsgBoxStyle.Information) = MsgBoxResult.Ok Then

                        Exit Sub
                    End If
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub mnuGenerieseBrief_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGenerieseBrief.Click
        BriefGeneries.ShowDialog()
    End Sub
    Private Sub Grid3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPoldata1AlleRisikoItems.CellContentClick
        dgvPoldata1AlleRisikoItems.ReadOnly = True
        'Andriette 08/08/2013 clear die selection van die ander grids
        dgvPoldataVoertuie.ClearSelection()
        dgvPoldata1Eiendomme.ClearSelection()
    End Sub
    Private Sub Grid2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPoldata1Eiendomme.CellContentClick
        dgvPoldata1Eiendomme.ReadOnly = True
        intPoldataGrid_Focus = 2
        'Andriette 08/08/2013 clear die selection van die ander grids
        dgvPoldataVoertuie.ClearSelection()
        dgvPoldata1AlleRisikoItems.ClearSelection()
    End Sub
    Private Sub Grid1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPoldataVoertuie.CellContentClick
        dgvPoldataVoertuie.ReadOnly = True
        'Andriette 08/08/2013 clear die selection van die ander grids
        dgvPoldata1Eiendomme.ClearSelection()
        dgvPoldata1AlleRisikoItems.ClearSelection()
    End Sub

    Private Sub Grid1_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPoldataVoertuie.RowEnter
        dgvPoldataVoertuie.ReadOnly = True
        'Andriette 08/08/2013 clear die selection van die ander grids
        dgvPoldata1Eiendomme.ClearSelection()
        dgvPoldata1AlleRisikoItems.ClearSelection()
    End Sub

    Private Sub Grid2_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPoldata1Eiendomme.RowEnter
        dgvPoldata1Eiendomme.ReadOnly = True
        'Andriette 07/06/2013 stel die pfokus waarde
        intPoldataGrid_Focus = 2
        'Andriette 08/08/2013 clear die selection van die ander grids
        dgvPoldataVoertuie.ClearSelection()
        dgvPoldata1AlleRisikoItems.ClearSelection()
    End Sub

    Private Sub Grid3_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPoldata1AlleRisikoItems.RowEnter
        dgvPoldata1AlleRisikoItems.ReadOnly = True
        'Andriette 08/08/2013 clear die selection van die ander grids
        dgvPoldataVoertuie.ClearSelection()
        dgvPoldata1Eiendomme.ClearSelection()
    End Sub


    Sub UpdateEndos2001(ByVal BranchCode As String, ByVal Type As String)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@BranchCode", SqlDbType.NVarChar), _
                                                New SqlParameter("@Type", SqlDbType.NVarChar)}

                params(0).Value = POLISNO.Text
                params(1).Value = BranchCode
                params(2).Value = Type

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdateEndos2001]", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub
    Function FetchAreaPerAreaKode(ByVal area As String) As AreaEntity
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@glbUserBranchCodes", SqlDbType.NVarChar)}
                params(0).Value = Gebruiker.BranchCodes
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchAreaPerAreaKode]", params)
                If reader.Read() Then
                    Dim item As AreaEntity = New AreaEntity()
                    ' Andriette 06/05/2013 toets of die veld null is voor die waarde oorgedra word na die entity
                    If reader("tak_naam") IsNot DBNull.Value Then
                        item.Tak_Naam = reader("tak_naam")
                    End If
                    If reader("Pakketitem1") IsNot DBNull.Value Then
                        ' Andriette 30/05/2013 verander om dit in die entity in te skryf en nie na die veld op die skerm nie
                        lblPakket1Prem.Text = FormatNumber(reader("Pakketitem1"), 2)
                        item.pakketitem1 = FormatNumber(reader("Pakketitem1"), 2)
                    End If
                    If reader("Pakketitem2") IsNot DBNull.Value Then
                        ' Andriette 30/05/2013 verander om dit in die entity in te skryf en nie na die veld op die skerm nie
                        txtPakketitem2.Text = FormatNumber(reader("Pakketitem2"), 2)
                        item.pakketitem2 = FormatNumber(reader("Pakketitem2"), 2)
                    End If

                    If reader("tak_dorp") IsNot DBNull.Value Then
                        item.Tak_Dorp = reader("tak_dorp")
                    End If

                    If reader("tak_poskode") IsNot DBNull.Value Then
                        item.Tak_Poskode = reader("tak_poskode")
                    End If

                    If reader("tak_tel") IsNot DBNull.Value Then
                        item.Tak_tel = reader("tak_tel")
                    End If

                    If reader("tak_straat") IsNot DBNull.Value Then
                        item.Tak_straat = reader("tak_straat")
                    End If
                    If reader("tak_straat_poskode") IsNot DBNull.Value Then
                        item.Tak_Straat_Poskode = reader("tak_straat_poskode")
                    End If
                    If reader("tak_posbus") IsNot DBNull.Value Then
                        item.tak_posbus = reader("tak_posbus")
                    End If
                    If reader("tak_faks") IsNot DBNull.Value Then
                        item.tak_faks = reader("tak_faks")
                    End If
                    If reader("motkommpers") IsNot DBNull.Value Then
                        item.motkommpers = reader("motkommpers")
                    End If
                    If reader("hekommpers") IsNot DBNull.Value Then
                        item.hekommpers = reader("hekommpers")
                    End If
                    If reader("hbkommpers") IsNot DBNull.Value Then
                        item.hbkommpers = reader("hbkommpers")
                    End If
                    If reader("arkommpers") IsNot DBNull.Value Then
                        item.arkommpers = reader("arkommpers")
                    End If
                    If reader("tak_epos") IsNot DBNull.Value Then
                        item.tak_epos = reader("tak_epos")
                    End If
                    If reader("tak_kontakpersoon") IsNot DBNull.Value Then
                        item.tak_kontakpersoon = reader("tak_kontakpersoon")
                    End If
                    If reader("tak_bknaam") IsNot DBNull.Value Then
                        item.tak_bknaam = reader("tak_bknaam")
                    End If
                    If reader("tak_regno") IsNot DBNull.Value Then
                        item.tak_regno = reader("tak_regno")
                    End If
                    If reader("tak_bknaam(e)") IsNot DBNull.Value Then
                        item.tak_bknaame = reader("tak_bknaam(e)")
                    End If
                    If reader("tak_regno(e)") IsNot DBNull.Value Then
                        item.tak_regno_e = reader("tak_regno(e)")
                    End If
                    If reader("tak_dae1(e)") IsNot DBNull.Value Then
                        item.tak_dae1_e = reader("tak_dae1(e)")
                    End If
                    If reader("tak_dae1(a)") IsNot DBNull.Value Then
                        item.tak_dae1_a = reader("tak_dae1(a)")
                    End If
                    If reader("tak_dae2(e)") IsNot DBNull.Value Then
                        item.tak_dae2_e = reader("tak_dae2(e)")
                    End If
                    If reader("tak_dae2(a)") IsNot DBNull.Value Then
                        item.tak_dae2_a = reader("tak_dae2(a)")
                    End If
                    If reader("tak_ete(a)") IsNot DBNull.Value Then
                        item.tak_ete_a = reader("tak_ete(a)")
                    End If
                    If reader("tak_voorstad") IsNot DBNull.Value Then
                        item.tak_voorstad = reader("tak_voorstad")
                    End If
                    If reader("tak_ete(e)") IsNot DBNull.Value Then
                        item.tak_ete_e = reader("tak_ete(e)")
                    End If
                    If reader("tak_straat(e)") IsNot DBNull.Value Then
                        item.Tak_straat_e = reader("tak_straat(e)")
                    End If
                    If reader("TAK_UNIV") IsNot DBNull.Value Then
                        item.TAK_UNIV = reader("TAK_UNIV")
                    End If
                    If reader("TAK_UNIVE") IsNot DBNull.Value Then
                        item.TAK_UNIVE = reader("TAK_UNIVE")
                    End If
                    If reader("Pakketitem3") IsNot DBNull.Value Then
                        item.pakketitem3 = FormatNumber(reader("Pakketitem3"), 2)
                    End If
                    If reader("Pakketitem3") IsNot DBNull.Value Then
                        item.pakketitem3 = FormatNumber(reader("Pakketitem3"), 2)
                    End If
                    Return item
                    Exit Function
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' Andriette 06/05/2013 Skuif die 2 lyne uit catch
        Return Nothing
    End Function

    'Author         : Andriette
    'Date           : 03/06/2013
    'Name           : FetchAreakodebyArea
    'Description    : gebruik die Sp wat net 1 area se detail terugbring volgens die area wat as parameter gepass word ipv 'n array

    Private Function FetchAreakodebyArea(ByVal Area As String)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Area_kode", SqlDbType.NVarChar)}
                params(0).Value = Area
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchAreakodebyArea]", params)
                If reader.Read() Then
                    Dim item As AreaEntity = New AreaEntity()
                    If reader("tak_naam") IsNot DBNull.Value Then
                        item.Tak_Naam = reader("tak_naam")
                    End If
                    If reader("Pakketitem1") IsNot DBNull.Value Then
                        ' Andriette 30/05/2013 verander om dit in die entity in te skryf en nie na die veld op die skerm nie
                        item.pakketitem1 = FormatNumber(reader("Pakketitem1"), 2)
                    End If
                    If reader("Pakketitem2") IsNot DBNull.Value Then
                        ' Andriette 30/05/2013 verander om dit in die entity in te skryf en nie na die veld op die skerm nie
                        item.pakketitem2 = FormatNumber(reader("Pakketitem2"), 2)
                    End If

                    If reader("tak_dorp") IsNot DBNull.Value Then
                        item.Tak_Dorp = reader("tak_dorp")
                    End If

                    If reader("tak_poskode") IsNot DBNull.Value Then
                        item.Tak_Poskode = reader("tak_poskode")
                    End If

                    If reader("tak_tel") IsNot DBNull.Value Then
                        item.Tak_tel = reader("tak_tel")
                    End If

                    If reader("tak_straat") IsNot DBNull.Value Then
                        item.Tak_straat = reader("tak_straat")
                    End If

                    If reader("tak_straat_poskode") IsNot DBNull.Value Then
                        item.Tak_Straat_Poskode = reader("tak_straat_poskode")
                    End If

                    If reader("tak_posbus") IsNot DBNull.Value Then
                        item.tak_posbus = reader("tak_posbus")
                    End If

                    If reader("tak_faks") IsNot DBNull.Value Then
                        item.tak_faks = reader("tak_faks")
                    End If

                    If reader("motkommpers") IsNot DBNull.Value Then
                        item.motkommpers = reader("motkommpers")
                    End If

                    If reader("hekommpers") IsNot DBNull.Value Then
                        item.hekommpers = reader("hekommpers")
                    End If

                    If reader("hbkommpers") IsNot DBNull.Value Then
                        item.hbkommpers = reader("hbkommpers")
                    End If

                    If reader("arkommpers") IsNot DBNull.Value Then
                        item.arkommpers = reader("arkommpers")
                    End If

                    If reader("tak_epos") IsNot DBNull.Value Then
                        item.tak_epos = reader("tak_epos")
                    End If

                    If reader("tak_kontakpersoon") IsNot DBNull.Value Then
                        item.tak_kontakpersoon = reader("tak_kontakpersoon")
                    End If

                    If reader("tak_bknaam") IsNot DBNull.Value Then
                        item.tak_bknaam = reader("tak_bknaam")
                    End If

                    If reader("tak_regno") IsNot DBNull.Value Then
                        item.tak_regno = reader("tak_regno")
                    End If

                    If reader("tak_bknaam(e)") IsNot DBNull.Value Then
                        item.tak_bknaame = reader("tak_bknaam(e)")
                    End If

                    If reader("tak_regno(e)") IsNot DBNull.Value Then
                        item.tak_regno_e = reader("tak_regno(e)")
                    End If

                    If reader("tak_dae1(e)") IsNot DBNull.Value Then
                        item.tak_dae1_e = reader("tak_dae1(e)")
                    End If

                    If reader("tak_dae1(a)") IsNot DBNull.Value Then
                        item.tak_dae1_a = reader("tak_dae1(a)")
                    End If

                    If reader("tak_dae2(e)") IsNot DBNull.Value Then
                        item.tak_dae2_e = reader("tak_dae2(e)")
                    End If

                    If reader("tak_dae2(a)") IsNot DBNull.Value Then
                        item.tak_dae2_a = reader("tak_dae2(a)")
                    End If

                    If reader("tak_ete(a)") IsNot DBNull.Value Then
                        item.tak_ete_a = reader("tak_ete(a)")
                    End If

                    If reader("tak_voorstad") IsNot DBNull.Value Then
                        item.tak_voorstad = reader("tak_voorstad")
                    End If

                    If reader("tak_ete(e)") IsNot DBNull.Value Then
                        item.tak_ete_e = reader("tak_ete(e)")
                    End If

                    If reader("tak_straat(e)") IsNot DBNull.Value Then
                        item.Tak_straat_e = reader("tak_straat(e)")
                    End If

                    If reader("TAK_UNIV") IsNot DBNull.Value Then
                        item.TAK_UNIV = reader("TAK_UNIV")
                    End If

                    If reader("TAK_UNIVE") IsNot DBNull.Value Then
                        item.TAK_UNIVE = reader("TAK_UNIVE")
                    End If

                    If reader("Pakketitem3") IsNot DBNull.Value Then
                        item.pakketitem3 = FormatNumber(reader("Pakketitem3"), 2)
                    End If

                    If reader("Pakketitem3") IsNot DBNull.Value Then
                        item.pakketitem3 = FormatNumber(reader("Pakketitem3"), 2)
                    End If

                    Return item
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Nothing
    End Function
    Public Sub FetchLangtermynPolis()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar)}
                'If Persoonl = Nothing Then

                'End If
                If Persoonl.POLISNO = Nothing Or Me.POLISNO.Text = "" Then
                    Exit Sub
                Else
                    params(0).Value = Me.POLISNO.Text Or params(0).Value = Persoonl.POLISNO
                End If

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[GetLangtermynpolisDate]", params)

                If reader.Read() Then
                    LTPJN = "J"
                Else
                    LTPJN = "N"
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Public Sub getGlbPakketItems(ByVal AREA)
        Dim item As AreaEntity
        'Andriette 03/06/2013 verander om van die ander stored procedure gebruik te maak 
        'item = FetchAreaPerAreaKode(AREA)
        item = FetchAreakodebyArea(AREA)
        lblPakket1Prem.Text = item.pakketitem1
        txtPakketitem2.Text = item.pakketitem2
        dblglbPakketItem1Premie = lblPakket1Prem.Text
        dblglbPakketItem2Premie = txtPakketitem2.Text
    End Sub

    Private Sub Grid1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPoldataVoertuie.GotFocus
        intPoldataGrid_Focus = 1
    End Sub

    Private Sub EMAIL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EMAIL.TextChanged
        'Andriette 30/10/2013 sluit nuwe polisse uit
        'Andriette 21/02/2014 sluit nuwe polisse in
        If EMAIL.Modified = True Then 'And Not (pol_byvoeg Or Byvoeg) Then
            blnchange = True
        End If
    End Sub

    Private Sub Grid1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvPoldataVoertuie.MouseDoubleClick
        Edit__Click(Edit_, New System.EventArgs())
    End Sub

    Private Sub Grid2_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvPoldata1Eiendomme.MouseDoubleClick
        Edit__Click(Edit_, New System.EventArgs())
    End Sub

    Private Sub Grid3_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvPoldata1AlleRisikoItems.MouseDoubleClick
        Edit__Click(Edit_, New System.EventArgs())
    End Sub

    Private Sub GEKANS_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GEKANS.SelectedIndexChanged

        If GEKANS.SelectedIndex = -1 Then
            strAanvangGekanseleer = ""
            Exit Sub
        End If

        If strAanvangGekanseleer = "" Then
            strAanvangGekanseleer = Me.GEKANS.Text
            Exit Sub
        Else
            If strAanvangGekanseleer <> Me.GEKANS.Text Then
                blnchange = True
                '      strAanvangGekanseleer = Me.GEKANS.Text ' Andriette 30/01/2014 moenie nou al stel nie
            End If
        End If

        'Andriette 30/01/2014 maak eers seker hierdie ingelogde persoon mag hierdie tak se goed verander
        Dim intPlekGevind As Integer
        Dim strsoekstring As String = Chr(39) & Trim(Persoonl.Area) & Chr(39)

        intPlekGevind = InStr(Gebruiker.BranchCodes, strsoekstring)
        If intPlekGevind <= 0 Then
            Exit Sub
        End If

        ' Andriette 14/05/2013 geskuif vanaf die veld leave event vir beter beheer
        Dim dblpolitiek As Double
        Dim dblTmpPremie As Double
        Dim strGekans As String

        If blnchange Then 'change begin
            strGekans = UCase(GEKANS.Text)

            'Andriette 29/01/2014 voeg die afrikaans by
            If strGekans <> "ACTIVE" And strGekans <> "CANCELLED" And strGekans <> "AKTIEF" And strGekans <> "GEKANSELLEER" Then
                MsgBox("'Valid values has to be added for the Policy Status field'", 48, "Invalid Values!")
                '  GEKANS.Text = "Cancelled"
                GEKANS.Focus()
                Exit Sub
            End If

            If strGekans = "CANCELLED" Or strGekans = "GEKANSELLEER" Then
                If gen_WarningsOnCancelorRemove(Me.POLISNO.Text, enumCheckType.PolicyCancelled) Then
                    ' Andriette 30/05/2013 verander sodat die kanseleer boodskappe nie opkom as jy No kies by warnings nie
                    'Andriette 29/01/2014 
                    KanselleerPolis.ShowDialog()

                    If blnKanselleerPolisFormCancelled Then
                        ' Andriette 10/06/2013 as die kansellasie van die polis gekanseleer is, moet die status
                        ' herstel word na wat dit was
                        If Persoonl.TAAL = 0 Then
                            strAanvangGekanseleer = "Aktief"
                            GEKANS.Text = "Gekanseleer"
                        Else
                            strAanvangGekanseleer = "Active"
                            GEKANS.Text = "Cancelled"
                        End If
                        blnchange = False
                        Exit Sub
                    End If
                    UpdateCLRSField("C", glbPolicyNumber)
                    ' PldRemove_Referrals_on_cancel(glbPolicyNumber)
                    poldata1_ManageReferralsOnPolicyCancelAndRestore(glbPolicyNumber, "Cancel")
                Else
                    GEKANS.SelectedIndex = 0
                    If Persoonl.TAAL = 0 Then
                        GEKANS.Text = "Aktief"
                    Else
                        GEKANS.Text = "Active"
                    End If
                    Exit Sub

                End If
                'Andriette 10/03/2014

            End If
            'Haal blok af as die polis geaktiveer word
            ' Andriette 30/01/2014 alles rondom die kansellasie word in die kanselleerpolis hanteer, hier hanteer
            ' ons slegs die heraktivering

            If strGekans = "ACTIVE" Or strGekans = "AKTIEF" Then
                ' Andriette 07/06/2013 verander die policy state
                UpdatePersoonlPerField("GEKANS", False)
                UpdatePersoonlPerField("datumgekanselleer", "")
                UpdatePersoonlPerField("datumEffekGekans", "")
                UpdateWysig((40), "")
                SetPoldata1FieldChangesAbility(True, "Active")
                ADRES2.Enabled = True
                '   UpdateCLRSField("A", (Me.POLISNO).Text)
                'Andriette 12/03/2014 roep die betaalwyse as die betaalwyse nie ooreenstem nie
                Dim takdetail As New TakEntity
                takdetail = FetchTakForsalaries()
                'Andriette 07/04/2014 sluit die maandelike kontant polisse in
                'If Persoonl.BET_WYSE = 2 Or (takdetail.TAKNAAM = "Flagship" And Persoonl.BET_WYSE = 3 And Persoonl.Area <> 2) Then
                If Persoonl.BET_WYSE = 2 Or Persoonl.BET_WYSE = 1 Or (takdetail.TAKNAAM = "Flagship" And Persoonl.BET_WYSE = 3 And Persoonl.Area <> 2) Then
                    MsgBox("The payment method is not valid anymore. Please select another payment method.", MsgBoxStyle.Exclamation)
                    Bet_Wyse.ShowDialog()
                    'Andriette 24/04/2014 
                    poldata_DecodeBetaalwyse()
                ElseIf Persoonl.BET_WYSE = 4 Then
                    'Andriette 19/05/2014 
                    MsgBox("Bank details for this policy already exists. Please verify if it is correct", MsgBoxStyle.Information)
                    Bet_Wyse.ShowDialog()
                ElseIf Persoonl.BET_WYSE = 6 Then 'Andriette 22/08/2014 vul die langtermynpolis se entity
                    gen_getTermPolicyStatus(glbPolicyNumber)

                End If
                ' PldReinstate_Referrals_on_restore(glbPolicyNumber)
                poldata1_ManageReferralsOnPolicyCancelAndRestore(glbPolicyNumber, "Restore")
                'Andriette 16/05/2014 1.366
                UpdateCLRSField("A", glbPolicyNumber)
            End If

            getGlbPakketItems(Persoonl.Area)

            If (Persoonl.PakketItem1 <> dblglbPakketItem1Premie) And Persoonl.Area <> "E" Then
                Me.lblPakket1Prem.Text = FormatNumber(dblglbPakketItem1Premie, 2)
                dblTmpPremie = FormatNumber(Persoonl.PakketItem1, 2)
                UpdatePersoonlPerField("PakketItem1", CDbl(lblPakket1Prem.Text))

                If Persoonl.TAAL = 0 Then
                    BESKRYWING = "vanaf (" & dblTmpPremie & ") na (" & FormatNumber(lblPakket1Prem.Text, 2) & ")"
                Else
                    BESKRYWING = "from (" & dblTmpPremie & ") to (" & FormatNumber(lblPakket1Prem.Text, 2) & ")"
                End If
                UpdateWysig(189, BESKRYWING)

                ' MsgBox("The Labour Insurance Coverage may be affected by the change. It can also affect the final premium", MsgBoxStyle.Exclamation)
                MsgBox("Some of the extras specific to an area may be affected by the change. It may also affect the final premium", MsgBoxStyle.Exclamation)
            End If

            If Check1.CheckState Then
                'Andriette 02/09/2013 verander die funksie
                dblpolitiek = Bereken_Sasria_waardes_op_vorm()
                'jaarliks kontant se sasria word met 12 vermenigvuldig
                'Andriette 02/09/2013 Termynpolisse is 6
                'If Persoonl.BET_WYSE = "2" Then
                If Persoonl.BET_WYSE = "6" Then
                    dblpolitiek = dblpolitiek * 12
                End If
                UpdatePersoonlPerField("SASPREM", FormatNumber(dblpolitiek, 2))
                Label36.Text = FormatNumber(dblpolitiek, 2)
            End If
            'Andriette 06/06/2014 
            BFUpdateItemsSubTotals(glbPolicyNumber)
            HerBereken_Premie()
            strAanvangGekanseleer = Me.GEKANS.Text
            'Andriette 24/10/2013 alles geskuif na herbereken premie
            'doen_subtotaal()
        End If
        blnchange = False
    End Sub

    Private Sub GEKANS_TextUpdate(sender As Object, e As System.EventArgs) Handles GEKANS.TextUpdate
        Dim dblPolitiek As Double
        Dim dbltmpPremie As Double
        Dim strGekans As String

        If blnchange Then 'change begin
            strGekans = UCase(GEKANS.Text)

            'If Ougekans.Text = "NEE" Then
            ' Andriette 07/06/2013 maak uppercase
            If strGekans = "CANCELLED" Then
                If Not gen_WarningsOnCancelorRemove(Me.POLISNO.Text, enumCheckType.PolicyCancelled) Then
                    'Ougekans.Text = "JA"
                    GEKANS.Text = "Cancelled"
                    blnchange = False
                    Exit Sub
                End If

                KanselleerPolis.ShowDialog()
                'When the 'KanselleerPolis' form was cancelled, exit sub - no cancellation
                If blnKanselleerPolisFormCancelled Then
                    Exit Sub
                End If
            End If

            'Haal blok af as die polis geaktiveer word
            ' If Ougekans.Text = "JA" Then
            If strGekans = "ACTIVE" Then
                ' Andriette 04/06/2013 vervang met meer generiese funksie
                ' Andriette 07/06/2013 verander die policy state
                SetPoldata1FieldChangesAbility(True, "Active")
                SetPoldata1MenuAbility(True)
            End If

            'Sit die blok op as die polis gekans is
            'If Ougekans.Text = "NEE" Then
            If strGekans = "CANCELLED" Then
                blnchange = False
                ' Andriette 26/04/2013 vervang die kode met 'n sub
                ' Andriette 04/06/2013 vervang met 'n generiese funksie
                'Blokveranderinge()
                ' Andriette 07/06/2013 verander die policy state
                SetPoldata1FieldChangesAbility(False, "Cancelled")
            End If
            ' Andriette 26/02/2013 verander gekanseleer om nie meer Ja of Nee te wees nie maar Active/Cancelled

            'If Ougekans.Text <> "JA" Then
            If strGekans <> "ACTIVE" Then
                Try
                    Using conn As SqlConnection = SqlHelper.GetConnection
                        Dim params() As SqlParameter = {New SqlParameter("@PolisNo", SqlDbType.NVarChar)}
                        params(0).Value = Persoonl.POLISNO
                        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchCancelHuisInfo]", params)
                        If reader.Read() Then
                            PtyCancl.ShowDialog()
                        End If
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                    End Using
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                    Exit Sub
                End Try

                UpdateCLRSField("C", (Me.POLISNO).Text)
            Else
                UpdatePersoonlPerField("GEKANS", False)
                UpdatePersoonlPerField("datumgekanselleer", "")
                UpdatePersoonlPerField("datumEffekGekans", "")
                UpdateWysig((40), "")

                getGlbPakketItems(Persoonl.Area)

                If (Persoonl.PakketItem1 <> dblglbPakketItem1Premie) And Persoonl.Area <> "E" Then
                    Me.lblPakket1Prem.Text = FormatNumber(dblglbPakketItem1Premie, 2)
                    dbltmpPremie = FormatNumber(Persoonl.PakketItem1, 2)
                    UpdatePersoonlPerField("PakketItem1", FormatNumber(lblPakket1Prem.Text, 2))

                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = "vanaf (" & dbltmpPremie & ") na (" & FormatNumber(lblPakket1Prem.Text, 2) & ")"
                    Else
                        BESKRYWING = "from (" & dbltmpPremie & ") to (" & FormatNumber(lblPakket1Prem.Text, 2) & ")"
                    End If
                    UpdateWysig(189, BESKRYWING)
                    'Andriette 06/06/2014 
                    BFUpdateItemsSubTotals(glbPolicyNumber)
                    'Andriette 24/10/2013 alles geskuif na herbereken premie
                    'doen_subtotaal()
                    HerBereken_Premie()
                    ' Andriette 30/05/2013 verander die boodskap
                    'MsgBox("The Domestic workers Coverage may be affected by the change. It can also affect the final premium", MsgBoxStyle.Exclamation)
                    MsgBox("Some of the extras specific to an area may be affected by the change. It may also affect the final premium", MsgBoxStyle.Exclamation)
                End If

                If (Persoonl.PakketItem2 <> dblglbPakketItem2Premie) And Persoonl.Area <> "E" Then
                    Me.txtPakketitem2.Text = FormatNumber(dblglbPakketItem2Premie, 2)
                    dbltmpPremie = FormatNumber(Persoonl.PakketItem2, 2)
                    UpdatePersoonlPerField("PakketItem2", FormatNumber(txtPakketitem2.Text, 2))

                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = "vanaf (" & dbltmpPremie & ") na (" & FormatNumber(txtPakketitem2.Text, 2) & ")"
                    Else
                        BESKRYWING = "from (" & dbltmpPremie & ") to (" & FormatNumber(txtPakketitem2.Text, 2) & ")"
                    End If
                    UpdateWysig(193, BESKRYWING)
                    'Andriette 06/06/2014 
                    BFUpdateItemsSubTotals(glbPolicyNumber)
                    'Andriette 24/10/2013 alles geskuif na herbereken premie
                    'doen_subtotaal()
                    HerBereken_Premie()
                    MsgBox("Die Makelaarsfooi kan beinvloed word deur die verandering.  Dit kan ook die finale premie affekteer.", MsgBoxStyle.Exclamation)
                End If

                If Check1.CheckState Then
                    'Andriette 02/09/2013 verander die funksie
                    dblPolitiek = Bereken_Sasria_waardes_op_vorm()
                    'jaarliks kontant se sasria word met 12 vermenigvuldig
                    'Andriette 02/09/2013 Termynpolisse is 6
                    'If Persoonl.BET_WYSE = "2" Then
                    If Persoonl.BET_WYSE = "6" Then
                        dblPolitiek = dblPolitiek * 12
                    End If
                    UpdatePersoonlPerField("SASPREM", FormatNumber(dblPolitiek, 2))
                    Label36.Text = FormatNumber(dblPolitiek, 2)
                End If
                'Andriette 06/06/2014 
                BFUpdateItemsSubTotals(glbPolicyNumber)
                HerBereken_Premie()
                'Andriette 24/10/2013 alles geskuif na herbereken premie
                'doen_subtotaal()

                UpdateCLRSField("A", (Me.POLISNO).Text)

            End If
            blnchange = False

        End If 'change einde
    End Sub
    ' Skuif die enables, disables, veld leeg maak eetc na funksie
    'Name           : Andriette
    'Date           : 26/04/2013
    'Name           : SetPoldata1FieldChangesAbility
    'Description    : Get a parameter as True or False and set the fields enable property to the received parameter,
    '                 Can also get a optional string field that will determine spesific field behaviors according to
    '                 Specific policy states ex View only, Cancelled Policies, Active Policies etc

    Private Sub SetPoldata1FieldChangesAbility(ByVal State As Boolean, Optional ByVal Policy_State As String = "")

        'For Each ctrl As Control In Me.Controls
        '    Try
        '        If TypeOf (ctrl) Is TextBox Then DirectCast(ctrl, TextBox).Clear()
        '        If TypeOf (ctrl) Is CheckBox Then DirectCast(ctrl, CheckBox).Checked = False
        '        If TypeOf (ctrl) Is ComboBox Then DirectCast(ctrl, ComboBox).SelectedIndex = -1
        '        If TypeOf (ctrl) Is Button Then DirectCast(ctrl, Button).Enabled = False
        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try
        'Next

        ' text bokse
        Me.ADRES.Enabled = State
        Me.ADRES1.Enabled = State
        Me.ADRES2.Enabled = State
        Me.ADRES3.Enabled = State
        Me.adres4.Enabled = State
        Me.BEROEP.Enabled = State
        Me.BET_DAT.Enabled = State
        Me.dept.Enabled = State
        Me.EMAIL.Enabled = State
        Me.FAX.Enabled = State
        Me.HUIS_TEL.Enabled = State
        'Andriette 11/09/2013 maak die id nommer oop vir search
        '   Me.ID_NOM.Enabled = State
        Me.Ougekans.Enabled = State
        Me.P_A_DAT.Enabled = State
        Me.PERS_NOM.Enabled = State
        Me.Plip.Enabled = State
        Me.POS_VAKKIE.Enabled = State
        Me.sel_tel.Enabled = State
        Me.studentno.Enabled = State
        ' Andriette 07/06/2013 voeg die velde by vir beheer
        Me.lbltermynmaande.Enabled = State
        Me.txtPkKansellasieRedes.Enabled = State
        Me.lblTipePolis.Enabled = State
        Me.lbltermynperiode.Enabled = State
        Me.txtBTWno.Enabled = State
        Me.txtNoemnaam.Enabled = State
        Me.txtPakketitem2.Enabled = State
        ' Andriette 14/06/2013 verander die selfoon textbox na 'n button
        'Me.btnSelfoonPrem.Enabled = State
        Me.btnSelfoonPremie.Enabled = State
        Me.WERK_TEL.Enabled = State

        ' comboboxes
        '  Me.AREA.Enabled = State
        Me.Betaaldag.Enabled = State
        Me.BYBET_K.Enabled = State
        Me.Combo1.Enabled = State
        Me.Oudstudentinstansie.Enabled = State
        Me.posbestemming.Enabled = State
        Me.plip2.Enabled = State
        Me.Taal.Enabled = State
        'Andriette 31/01/2014 haal die blok af en hou altyd oop
        '  Me.TITEL.Enabled = State
        Me.VANWIE.Enabled = State
        SetPoldata1MenuAbility(State)

        'Checkboxes
        Me.Check1.Enabled = State
        Me.Elektroniesgestuur.Enabled = State

        'Labels
        'Andriette 29/05/2013 verander na 'n text box
        Me.txtCourtesyPrem.Enabled = State
        Me.txthomeAsstPrem.Enabled = State
        Me.txtLiabilityPrem.Enabled = State
        Me.lblPakket1Prem.Enabled = State
        Me.txtRoadsidePrem.Enabled = State

        'Buttons
        Me.btnAddisionelePremie.Enabled = State
        If Not (blnByvoeg Or blnPol_Byvoeg) Then
            Me.btnPremieDetail.Enabled = True
        Else
            Me.btnPremieDetail.Enabled = False
        End If
        'Andriette 1.311 haal hier uit want dit word reeds op ander plekke gedoen
        ' Me.Edit_.Enabled = State
        ' Me.Vee_Uit.Enabled = State
        ' Me.Voeg_By.Enabled = State
        'Andriette 19/09/2013 maak altyd oop vir click, maar beperk binne vorm self
        '  Me.btnVerwyderdeItems.Enabled = True


        ' Andriette 07/06/2013 as die policy state Cancelled is doen die volgende
        Select Case Policy_State
            Case "Cancelled"
                ' Andriette 18/06/2013 verander soos die polis status
                Me.GEKANS.Enabled = True
            Case "No Area"
                Me.GEKANS.Enabled = False
            Case "Active"
                ' Andriette 18/06/2013 verander soos die polis status
                Me.GEKANS.Enabled = True
            Case "Clear Values"
                ' Andriette 18/06/2013 verander soos die polis status
                Me.GEKANS.Enabled = True
                ' Andriette 18/06/2013 voeg by
            Case Else
                Me.GEKANS.Enabled = State
        End Select
        Me.VOORL.Enabled = False
        Me.VOORL.ReadOnly = False

        ' Andriette 07/06/2013 Die volgende velde is altyd beskikbaar maak nie sake in watter status die polis is nie
        Me.VERSEKERDE.Enabled = True

        Me.POLISNO.Enabled = True
        'Andriette 19/03/2014 haal uit - dit word elders gedoen
        ' Me.Edit_.Enabled = True
        ' Andriette 04/06/2103 voeg die grids by
        Me.dgvPoldataVoertuie.Enabled = True
        Me.dgvPoldata1Eiendomme.Enabled = True
        Me.dgvPoldata1AlleRisikoItems.Enabled = True

    End Sub

    ' Andriette 04/06/2013 Verander na 'n meer generiese funksie
    '
    'Private Sub BlokMENU()
    'Name           : Andriette
    'Date           : 26/04/2013
    'Name           : SetPoldata1MenuAbility
    'Description    : Get a parameter as True or False and set the menu enable property to the received parameter,
    '                 Can also get a optional string field that will determine spesific menu behaviors according to
    '                 Module the Sub is called from ex Besigtig etc

    Private Sub SetPoldata1MenuAbility(ByVal State As Boolean, Optional ByVal Call_Module As String = "")
        ' Andriette 04/06/2013 hoof menu opsies wat enable/disable word volgend of ;n aktiewe polis op die skerm is of nie
        Me.M_druk.Enabled = State

        Me.mnuAdmin.Enabled = State
        Me.mnuEise.Enabled = State
        'Andriette 05/05/2014 haal menu opsies uit
        ' Me.M_Multi.Enabled = State
        Me.m_k_ontv.Enabled = State
        'Andriette 26/07/2013 voeg menu opsies by
        Me.care_assist.Enabled = State
        Me.M_Bes.Enabled = State
        Me.M_Naam.Enabled = State
        Me.M_Van.Enabled = State
        Me.m_endos_meester.Enabled = State
        Me.m_byb_menu.Enabled = State
        M_KAN_TV.Enabled = State

        ' Andriette 12/06/2013 skuif die selfoon menu opsien hierheen om te pas by die ander en maak dit die state en nie altyd disabled nie
        'Andriette 26/07/2013 verander na altyd oop
        Me.M_selfoon.Enabled = True

        ' Andriette 04/06/2013 sub menu opsies wat nooit enable word nie
        'Andriette 05/05/2014 haal menu opsies uit
        'Me.M_berei.Enabled = False
        Me.M_Begraf.Enabled = False
        Me.M_TV_DIENS.Enabled = False

        ' Andriette 04/06/2013 stel soos volg
        ' Menus wat altyd moet vertoon
        mnuVoertuie.Enabled = True
        mnuDetailSearch.Enabled = True
        mnuStelselFunksies.Enabled = True

        'Andriette 24/03/2014 jhaal uit dit word gestel saam met die items buttons
        '  Exit_Renamed.Enabled = True

        ' Andriette 18/06/2013 verander na ;n altyd sigbaar
        'Andriette 23/01/2014 verander na die parameter
        ' Me.M_Funk.Enabled = True
        Me.M_Funk.Enabled = State

        If Call_Module = "Besigtig" Then
            'Andriette 05/05/2014 haal menu opsies uit
            'Me.M_Multi.Enabled = False
            Me.m_k_ontv.Enabled = True
            Me.M_druk.Enabled = True
            'Uitdrukke
            Me.mnuVTBrief.Enabled = True
            Me.mnuLTPbriewe.Enabled = True
            Me.mnuKontantAanmaning.Enabled = True
            Me.mnuKansellasieBrief.Enabled = True
            Me.mnuBelasting.Enabled = True
            Me.mnuGenerieseBrief.Enabled = True
            Me.mnuOpskort.Enabled = True
            Me.mnuSekuriteitsvereisteBrief.Enabled = True
            Me.mnuBriefDubbelPremie.Enabled = True
            Me.mnu_Debietordervorms.Enabled = True
            Me.m_daagliks_lys_2.Enabled = False
            Me.mnu_verwys_verval.Enabled = True
            Me.mnuReminders.Enabled = True
            Me.datum_wysig.Enabled = False
            'Polisfunksies
            Me.M_Bet_Wyse.Enabled = True
            Me.M_Begraf.Enabled = False
            Me.M_TV_DIENS.Enabled = False
            Me.M_selfoon.Enabled = False
            Me.m_verwysdes.Enabled = True
            Me.mnuAddisionelepremie.Enabled = True
            Me.mnuDokArgief.Enabled = True
            Me.M_Naam.Enabled = False
            Me.M_Van.Enabled = False
            Me.m_endos_meester.Enabled = False
            Me.m_byb_menu.Enabled = False
        End If

    End Sub
    'Andriette 18/06/2013 verander die text/label field na 'n button wat na die selfoon skerm roep
    Private Sub btnSelfoonPremie_Click(sender As Object, e As System.EventArgs) Handles btnSelfoonPremie.Click

        If POLISNO.Text = Nothing Then
            MsgBox("Please allocate the policy number of the insured", MsgBoxStyle.Information)
            Exit Sub
        End If
        selfoonListFrm.ShowDialog()
    End Sub

    Private Sub txtSelfoonPrem_GotFocus(sender As Object, e As System.EventArgs) Handles btnSelfoonPremie.GotFocus
        ' Andriette 14/06/2013 verander die selfoon textbox na 'n button
        'Me.btnSelfoonPrem.BackColor = System.Drawing.Color.White
        Me.btnSelfoonPremie.BackColor = System.Drawing.Color.White
    End Sub

    Private Sub txtSelfoonPrem_LostFocus(sender As Object, e As System.EventArgs) Handles btnSelfoonPremie.LostFocus
        ' Andriette 14/06/2013 verander die selfoon textbox na 'n button
        'Me.btnSelfoonPrem.BackColor = Color.Silver
        Me.btnSelfoonPremie.BackColor = Color.Silver
    End Sub

    ' Andriette 13/06/2013 Skep 'n apparte function vir die verifikasie van die login
    ' Ruim die baie subs en so bietjie op
    Private Function VerifyTheLogin() As Boolean

        If Form5.Form5OK = True Then
            'Andriette 16/08/2013 haal die default uit en kodeer reg
            '  Dim username As String = "linkie" 'Form5.form5Gebnaam tydelike kode
            ' Dim password As String = "8225" 'Form5.form5Gebruikerkode tydelike kode
            Try
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim param As New SqlParameter(PARM_UserName, SqlDbType.NVarChar)
                    ' param.Value = username
                    param.Value = Form5.Gebnaam.Text
                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "sekurit.FetchGebruikers", param)
                    If reader.Read() Then
                        Gebruiker = New GebruikersEntity()
                        If reader("ApplicationPath") IsNot DBNull.Value Then
                            Gebruiker.ApplicationPath = reader("ApplicationPath")
                        Else
                            Gebruiker.ApplicationPath = ""
                        End If

                        If reader("Area_kode") IsNot DBNull.Value Then
                            Gebruiker.Area_kode = reader("Area_kode")
                        Else
                            Gebruiker.Area_kode = ""
                        End If

                        If reader("BranchCodes") IsNot DBNull.Value Then
                            Gebruiker.BranchCodes = reader("BranchCodes")
                        Else
                            Gebruiker.BranchCodes = ""
                        End If

                        If reader("Kode") IsNot DBNull.Value Then
                            Gebruiker.Kode = reader("Kode")
                        Else
                            Gebruiker.Kode = ""
                        End If

                        If reader("Naam") IsNot DBNull.Value Then
                            Gebruiker.Naam = reader("Naam")
                        Else
                            Gebruiker.Naam = ""
                        End If

                        If reader("Nedseedno") IsNot DBNull.Value Then
                            Gebruiker.Nedseedno = reader("Nedseedno")
                        Else
                            Gebruiker.Nedseedno = ""
                        End If

                        If reader("Policynumber") IsNot DBNull.Value Then
                            Gebruiker.Policynumber = reader("Policynumber")
                        Else
                            Gebruiker.Policynumber = ""
                        End If

                        If reader("titel") IsNot DBNull.Value Then
                            Gebruiker.titel = reader("titel")
                        Else
                            Gebruiker.titel = ""
                        End If

                        If reader("WindowsUsername") IsNot DBNull.Value Then
                            Gebruiker.WindowsUsername = reader("WindowsUsername")
                        Else
                            Gebruiker.WindowsUsername = ""
                        End If
                        If reader("MMLicense") IsNot DBNull.Value Then
                            Gebruiker.MMLicence = reader("MMLicense")
                        Else
                            Gebruiker.MMLicence = ""
                        End If

                        Dim i As Integer
                        Dim j As Integer

                        j = 0

                        For i = 3 To arrglbUserBranchCodes.Length Step 4
                            j = j + 1
                            If j < 10 Then
                                arrglbUserBranchCodes(j) = Mid(Gebruiker.BranchCodes, i, 1)
                            ElseIf j >= 10 And j < 100 Then
                                arrglbUserBranchCodes(j) = Mid(Gebruiker.BranchCodes, i, 2)
                                i = i + 1
                            ElseIf j >= 100 And j < 1000 Then
                                arrglbUserBranchCodes(j) = Mid(Gebruiker.BranchCodes, i, 3)
                                i = i + 2
                            ElseIf j >= 1000 And j < 10000 Then
                                arrglbUserBranchCodes(j) = Mid(Gebruiker.BranchCodes, i, 4)
                                i = i + 3
                            Else
                                arrglbUserBranchCodes(j) = Mid(Gebruiker.BranchCodes, i, 5)
                                i = i + 4
                            End If
                        Next
                        'Andriette 16/08/2013 verander die login sodat dit werk
                        'If Password.Substring(0, 1) = Gebruiker.Kode.Substring(0, 1) Then
                        '    If Password.Substring(1, 1) = Gebruiker.Kode.Substring(7, 1) Then
                        '        If Password.Substring(2, 1) = Gebruiker.Kode.Substring(8, 1) Then
                        '            If Password.Substring(3, 1) = Gebruiker.Kode.Substring(14, 1) Then
                        If Form5.Gebruikerkode.Text.Substring(0, 1) = Gebruiker.Kode.Substring(0, 1) Then
                            If Form5.Gebruikerkode.Text.Substring(1, 1) = Gebruiker.Kode.Substring(7, 1) Then
                                If Form5.Gebruikerkode.Text.Substring(2, 1) = Gebruiker.Kode.Substring(8, 1) Then
                                    If Form5.Gebruikerkode.Text.Substring(3, 1) = Gebruiker.Kode.Substring(14, 1) Then
                                        'Succesfull
                                        VerifyTheLogin = True
                                        Exit Function
                                    Else
                                        'Fail
                                        MsgBox("Your Usercode is not valid. Contact the IT department. Program ends.", MsgBoxStyle.Critical)
                                        VerifyTheLogin = False
                                        blnExitWithError = True
                                        Exit Function
                                        'End
                                    End If
                                Else
                                    MsgBox("Your Usercode is not valid. Contact the IT department. Program ends.", MsgBoxStyle.Critical)
                                    VerifyTheLogin = False
                                    blnExitWithError = True
                                    Exit Function
                                    'End
                                End If
                            Else
                                MsgBox("Your Usercode is not valid. Contact the IT department. Program ends.", MsgBoxStyle.Critical)
                                VerifyTheLogin = False
                                blnExitWithError = True
                                Exit Function
                                'End
                            End If
                        Else
                            MsgBox("Your Usercode is not valid. Contact the IT department. Program ends.", MsgBoxStyle.Critical)
                            VerifyTheLogin = False
                            blnExitWithError = True
                            Exit Function
                            ' End
                        End If
                    Else

                        MsgBox("Your Usercode is not in the security database. Contact the IT department. Program ends.", MsgBoxStyle.Critical)
                        ' Me.Close()
                        'End
                        VerifyTheLogin = False
                        blnExitWithError = True
                        Exit Function
                    End If
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                End Using

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                End
            End Try
        End If
    End Function


    'Linkie 30/06/2013 - stats menu items bysit
    Private Sub mnuRunsCommission_Click(sender As System.Object, e As System.EventArgs) Handles mnuRunsCommission.Click
        frmCommisionRun.Show()
    End Sub

    Private Sub mnuRunsCollections_Click(sender As System.Object, e As System.EventArgs) Handles mnuRunsCollections.Click
        frmCollections.Show()
    End Sub

    Private Sub mnuRunsFinalrun_Click(sender As System.Object, e As System.EventArgs) Handles mnuRunsFinalrun.Click
        frmFinalRun.Show()
    End Sub

    Private Sub mnuRunsDOUnpaidrun_Click(sender As System.Object, e As System.EventArgs) Handles mnuRunsDOUnpaidrun.Click
        frmDOUnpaidRun.Show()
    End Sub


    'Andriette 13/08/2013 stel die p_focus soos vir die ander 2 grids
    Private Sub Grid2_GotFocus1(sender As Object, e As System.EventArgs) Handles dgvPoldata1Eiendomme.GotFocus
        intPoldataGrid_Focus = 2
    End Sub
    Private Function Bereken_Subtotaal_na_korting()
        Dim intBedragNaKorting As Decimal = 0
        Dim intVoertuiePremies As Decimal = 0
        Dim intHuisPremies As Decimal = 0
        Dim intAlleRisikoPremies As Decimal = 0
        Dim intvoertuignaAfslag As Decimal = 0
        Dim intHuisNaAfslag As Decimal = 0
        Dim intAlleRisikoNaAfslag As Decimal = 0

        'Tel al die premies van die voertuie bymekaar
        For Each voertuigdetail As DataGridViewRow In dgvPoldataVoertuie.Rows
            If Not IsNothing(voertuigdetail.Cells(7).Value) Then
                intVoertuiePremies = intVoertuiePremies + Val(voertuigdetail.Cells(7).Value)
            End If
        Next

        'Tel 
        For Each Huisdetail As DataGridViewRow In dgvPoldata1Eiendomme.Rows
            If Not IsNothing(Huisdetail.Cells(4).Value) Then
                ' nHuisNaAfslag = FormatNumber(nHuisNaAfslag + (Val(Huisdetail.Cells(4).Value) * Combo1.Text), 2)
                intHuisPremies = intHuisPremies + (Val(Huisdetail.Cells(4).Value))
            End If
            If Not IsNothing(Huisdetail.Cells(6).Value) Then
                'nHuisNaAfslag = FormatNumber(nHuisNaAfslag + (Val(Huisdetail.Cells(6).Value) * Combo1.Text), 2)
                intHuisPremies = intHuisPremies + (Val(Huisdetail.Cells(6).Value))
            End If
            If Not IsNothing(Huisdetail.Cells(9).Value) Then
                'nHuisNaAfslag = FormatNumber(nHuisNaAfslag + (Val(Huisdetail.Cells(9).Value) * Combo1.Text), 2)
                intHuisPremies = intHuisPremies + (Val(Huisdetail.Cells(9).Value))
            End If
            If Not IsNothing(Huisdetail.Cells(11).Value) Then
                'nHuisNaAfslag = FormatNumber(nHuisNaAfslag + (Val(Huisdetail.Cells(11).Value) * Combo1.Text), 2)
                intHuisPremies = intHuisPremies + (Val(Huisdetail.Cells(11).Value))
            End If
        Next

        For Each AlleRisikoDetail As DataGridViewRow In dgvPoldata1AlleRisikoItems.Rows
            If Not IsNothing(AlleRisikoDetail.Cells(4).Value) Then
                intAlleRisikoPremies = intAlleRisikoPremies + Val(AlleRisikoDetail.Cells(4).Value)
            End If
        Next
        If Combo1.SelectedIndex = -1 Then
            Combo1.Text = 1.0
        End If
        intvoertuignaAfslag = FormatNumber(intVoertuiePremies * Combo1.Text, 2)
        '   nHuisNaAfslag = nHuisPremies * Combo1.Text
        intAlleRisikoNaAfslag = FormatNumber(intAlleRisikoPremies * Combo1.Text, 2)
        intHuisNaAfslag = FormatNumber(intHuisPremies * Combo1.Text, 2)
        intBedragNaKorting = intvoertuignaAfslag + intHuisNaAfslag + intAlleRisikoNaAfslag
        'Andriette 04/11/2013 Verander die formule na vergadering
        intBedragNaKorting = FormatNumber((intVoertuiePremies + intHuisPremies + intAlleRisikoPremies) * Combo1.Text, 2)

        Return intBedragNaKorting
    End Function

    'Andriette alles invoeg moet alleen geskied op die add button
    '30/10/2013
    Private Sub btnAddNew_Click(sender As System.Object, e As System.EventArgs) Handles btnAddNew.Click

        SetPoldata1FieldChangesAbility(True)

        If btnAddNew.Text = "Add" Then
            If Gebruiker.titel = "Besigtig" Then
                MsgBox("You do not have permission to add a policy", MsgBoxStyle.Information)
                blnPol_Byvoeg = False
                blnByvoeg = False
                SetPoldata1FieldChangesAbility(False)
                Exit Sub
            End If

            'TabInligting.Focus()
            TabDetail.SelectedTab = TabInligting
            '   ID_NOM.Focus()
            POLISNO.Focus()
            BtnCancel.Visible = True
            BtnCancel.Enabled = True
            blnSavedNew = False
            Clear_Values()
            blnPol_Byvoeg = True
            blnByvoeg = True
            MsgBox("Adding a new policy, please use TAB or the MOUSE (not ENTER)", 48, "")
            'btnAddNew.Size = New Size(125, 22)
            'BtnCancel.Location = New Point(128, 26)
            'btnAddNew.Text = "New Policy Incomplete"
            btnAddNew.Enabled = False

            '    Me.VERSEKERDE.TabIndex = 3
            '    Me.POLISNO.TabIndex = 0
            ' POLISNO.Focus()
            'Andriette 24/03/2014 stel saam met die items buttons
            'Exit_Renamed.Enabled = False
            GEKANS.Text = "Active"
            btnAddNew.Enabled = False
            btnVersekerdesoek.Enabled = False
            btnPolicySearch.Enabled = False
            btnIdSearch.Enabled = False
            p_a_dat.Text = Today()
            '  dtpInceptionDate.Value = Today()
            dtpInceptDt.MinDate = Now().AddMonths(-1)
            dtpInceptDt.MaxDate = Now().AddMonths(11)
            dtpInceptDt.Value = Now()
            Betaaldag.Text = "01"
            Persoonl = New PERSOONLEntity()
            btnPolicySearch.Enabled = False
            '   StelTabIndexes("Add")
            btnPremieDetail.Enabled = False
            adres4.Text = "Street Address"
            VOORL.Enabled = True
            VOORL.ReadOnly = False
            POLISNO.TabIndex = 5
            VERSEKERDE.TabIndex = 12
            Poldata1_Stel_Items_Buttons(False)
            'Andriette 17/04/2014 Tick op Sasria
            Check1.Checked = True
            POLISNO.Focus()
            blnchange = False
        End If
        M_Wysig.Enabled = False
    End Sub

    'Andriette 01/10/2013 Skryf 'n nuwe polis in die tabel Persoonl in

    Private Sub VoegPolisBy()
        Dim item As New ComboBoxEntity
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        polisfooi_ini = FormatNumber(Constants.Polisfooi, 2)
        'Andriette 11/11/2013 sit al die noodsaaklike velde bymekaar
        'Andriette 10/02/2014 skp die nuwe inskrywing
        UpdatePersoonlPerField("POLISNO", POLISNO.Text)
        'Update die persoonlike inligting

        item = TITEL.SelectedItem
        UpdatePersoonlPerField("Titelnum", item.ComboBoxID)
        'Andriette 27/05/2014 
        UpdatePersoonlPerField("voorl", Me.VOORL.Text.ToUpper)
        UpdatePersoonlPerField("VERSEKERDE", Me.VERSEKERDE.Text)
        UpdatePersoonlPerField("GEKANS", False)

        item = Me.AREA.SelectedItem
        UpdatePersoonlPerField("Area", item.ComboBoxID)
        getGlbPakketItems(item.ComboBoxID)
        UpdatePersoonlPerField("ID_Nom", Me.ID_NOM.Text)
        UpdatePersoonlPerField("TAAL", Me.Taal.SelectedIndex)
        UpdatePersoonlPerField("Adres", ADRES.Text)
        UpdatePersoonlPerField("Adres1", ADRES1.Text)
        UpdatePersoonlPerField("Adres3", ADRES3.Text)
        UpdatePersoonlPerField("Adres2", ADRES2.Text)
        UpdatePersoonlPerField("Adres4", adres4.Text)

        'Andriette 07/04/2014 verander na die ingeleesde datum en nie die datum nou nie
        'p_a_dat.Text = Format(Me.p_a_dat, "MM/dd/yyyy") 
        'Andriette 07/04/2014 verander die aanvangsdatum
        p_a_dat.Text = FormatDateTime(p_a_dat.Text, DateFormat.GeneralDate)
        Dim datum As Date
        ' datum = dtpInceptionDate.Value.Date
        datum = dtpInceptDt.Value.Date
        Dim intDay As Integer = datum.ToString.Substring(0, 2)
        Dim intMonth As Integer = datum.ToString.Substring(3, 2)
        Dim intyear As Integer = datum.ToString.Substring(6, 4)

        UpdatePersoonlPerField("P_A_DAT", intMonth.ToString.Trim.PadLeft(2, "0") & "/" & intDay.ToString.Trim.PadLeft(2, "0") & "/" & intyear.ToString.Trim)
        'UpdatePersoonlPerField("P_A_DAT", dtpInceptionDate.Value.Date)


        'Andriette 03/12/2013

        '    UpdatePersoonlPerField("bet_dat", BET_DAT.Text)
        ' Dim datum = New DateTime("30/11/2013")
        ' Dim KULTUUR As New Globalization.CultureInfo("en-ZA")

        UpdatePersoonlPerField("Bet_Dat", Me.BET_DAT.Text)
        UpdatePersoonlPerField("betaaldatum", Betaaldag.Text)
        UpdatePersoonlPerField("Bybet_K", BYBET_K.SelectedIndex)

        item = VANWIE.SelectedItem
        UpdatePersoonlPerField("Vanwie", item.ComboBoxID)
        'Opsionele velde

        UpdatePersoonlPerField("Noemnaam", Me.txtNoemnaam.Text)
        UpdatePersoonlPerField("Dept", Me.dept.Text)
        UpdatePersoonlPerField("Beroep", Me.BEROEP.Text)
        UpdatePersoonlPerField("BTWNo", Me.txtBTWno.Text)
        UpdatePersoonlPerField("Pers_Nom", Me.PERS_NOM.Text)
        UpdatePersoonlPerField("Studentno", Me.studentno.Text)
        If Me.Oudstudentinstansie.SelectedItem Is Nothing Then
            UpdatePersoonlPerField("Oudstudent", "")
        Else
            Dim oudstudentitem As New OUDSTUDENTEntity
            oudstudentitem = Me.Oudstudentinstansie.SelectedItem
            UpdatePersoonlPerField("Oudstudent", oudstudentitem.INSTANSIENAAM)
        End If
        UpdatePersoonlPerField("POSBESTEMMING", Format(posbestemming.SelectedIndex))

        UpdatePersoonlPerField("POS_VAKKIE", POS_VAKKIE.Text)
        UpdatePersoonlPerField("huis_tel2", HUIS_TEL.Text)
        UpdatePersoonlPerField("werk_tel2", WERK_TEL.Text)
        UpdatePersoonlPerField("sel_tel", sel_tel.Text)
        UpdatePersoonlPerField("fax", FAX.Text)
        UpdatePersoonlPerField("email", EMAIL.Text)
        UpdatePersoonlPerField("Bet_Wyse", Persoonl.BET_WYSE)
        UpdatePersoonlPerField("K_OPMERKING", "Geen \ None")
        UpdatePersoonlPerField("OPMERKING", "")
        UpdatePersoonlPerField("datumToegevoer", Format(Now, "yyyy/MM/dd"))

        'Andriette 10/02/2014 premie inligting

        UpdatePersoonlPerField("polfooi", polisfooi_ini)

        'UpdatePersoonlPerField("TV_DIENS", "0.00")
        'UpdatePersoonlPerField("MEDIES", "0.00")
        'UpdatePersoonlPerField("BEGRAFNIS", "0.00")
        UpdatePersoonlPerField("BEGRAF_DEK", "0.00")
        'UpdatePersoonlPerField("SASPREM", Val(Label36.Text))
        lblPakket1Prem.Text = FormatNumber(dblglbPakketItem1Premie, 2)
        '   Persoonl.PakketItem1 = glbPakketItem1Premie
        UpdatePersoonlPerField("PakketItem1", dblglbPakketItem1Premie)
        txtPakketitem2.Text = FormatNumber(0, 2)
        UpdatePersoonlPerField("PakketItem2", txtPakketitem2.Text)
        UpdatePersoonlPerField("PakketItem3", 0)
        UpdatePersoonlPerField("PakketItem4", 0)

        txtLiabilityPrem.Text = FormatNumber(polisfooi_ini, 2)
        UpdatePersoonlPerField("CLRSTypeOfAmendment", "N")

        UpdatePersoonlPerField("EISBONUS", Me.Combo1.SelectedIndex)
        UpdatePersoonlPerField("eispers", Val(Me.Combo1.Text))
        'Andriette 24/01/2014 Voeg die velde by 
        'Andriette 10/02/2014 velde word in herbereken premie hanteer
        'UpdatePersoonlPerField("courtesyv", Val(txtCourtesyPrem.Text))
        'UpdatePersoonlPerField("careassist", Val(txtRoadsidePrem.Text))
        'UpdatePersoonlPerField("epc", Val(txthomeAsstPrem.Text))
        ' UpdatePersoonlPerField("", Check1.CheckState)

        '  UpdatePersoonlPerField("SUBTOTAAL", 0)
        ' UpdatePersoonlPerField("PREMIE", 0)
        'UpdatePersoonlPerField("BESKERM", 0)
        UpdatePersoonlPerField("WN_POLIS", 0)
        UpdatePersoonlPerField("verwyskommissie", 0)
        'UpdatePersoonlPerField("premie2", 0)
        blnByvoeg = True

        '  Me.MEMO.Enabled = True
        Me.dgvPoldataVoertuie.Enabled = True
        Me.dgvPoldata1Eiendomme.Enabled = True
        Me.dgvPoldata1AlleRisikoItems.Enabled = True
        Me.M_Bet_Wyse.Enabled = True
        Me.M_Begraf.Enabled = True
        Me.M_TV_DIENS.Enabled = False
        Me.M_Bes.Enabled = True

        AREA.Enabled = True
        Ougekans.Text = "JA"
        '   GEKANS.Text = "Active"

        'Andriette 15/04/2013 roep die funksie om die formatering van 'n getal te doen

        UpdateAlleRisiko()
        populate_dgvPoldata1AlleRisikoItems()

        UpdateWysig(42, "")
        ' Byvoeg = False
        blnNuwe = True
        txtForm1Versekerde = Me.VERSEKERDE
        blnSavedNew = True
        'Andriette 06/06/2014 
        BFUpdateItemsSubTotals(glbPolicyNumber)
        'Andriette 10/02/2014 voeg by om die premies op te dateer en die tabel ook
        HerBereken_Premie() ' Dit hanteer die skryf op die tabel ook van premies
        'Andriette 08/04/2014 hierdie word reeds binne herbereken premie hanteer
        '  Persoonl = FetchPersoonl()
        M_Wysig.Enabled = True
        'Andriette 13/02/2014 haal eers die byvoeg af as jy ;n nuwe polis oopmaak, daar moet geen wysigings skryf terwyl die nuwe polis nog op die skerm is nie
        ' pol_byvoeg = False
        ' Byvoeg = False


        'UpdateCLRSField("N", POLISNO.Text)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '    frmBoodskap.Close()
    End Sub

    Private Function ToetsNoodsaaklik()
        'Andriette 06/02/2014 verander die werkswyse om sodra al die noodsaaklike velde met die byvoeg in gevul is, 
        ' die save automaties gebeur
        ' Die byvoeg wysiging moet skryf
        'die cancel button moet verdwyn
        ' die items se buttons moet enabled word
        Dim blnAlmalIngevul As Boolean = False
        Dim item As ComboBoxEntity = AREA.SelectedItem

        If Not blnSavedNew Then

            If Me.POLISNO.Text.Length > 0 And _
                   Me.VERSEKERDE.Text.Length > 0 And _
                   Me.VOORL.Text.Length > 0 And _
                   Me.ID_NOM.Text.Length > 0 And _
                   Me.AREA.SelectedIndex > -1 And _
                   Me.TITEL.Text <> "" And _
                   Me.ADRES.Text <> "" And _
                   Me.ADRES.Text.Trim.ToUpper <> "STREET ADDRESS" And _
                   Me.ADRES3.Text <> "" And _
                   Me.ADRES3.Text.Trim.ToUpper <> "SUBURB" And _
                   Me.ADRES2.Text <> "" And _
                   Me.ADRES2.Text.Trim.ToUpper <> "CODE" And _
                   Me.BET_DAT.Text <> "" And _
                   Me.BYBET_K.Text <> "" And _
                   Me.dtpInceptDt.Text <> "" And _
                   Me.VANWIE.Text <> "" And _
                   Me.Taal.SelectedIndex > -1 And _
                   Me.Combo1.SelectedIndex <> -1 And _
                   Me.posbestemming.SelectedIndex > -1 Then
                'Me.p_a_dat.Text <> "" And _
                If blnElectronicMail Then
                    If Me.EMAIL.TextLength > 0 Then
                        btnAddNew.Enabled = True
                        blnAlmalIngevul = True
                    Else
                        Return False
                        Exit Function
                    End If
                End If

                If item.ComboBoxID = 2 Then
                    'PUK Polisse moet ook die personeel nommer in he

                    If Len(PERS_NOM.Text) <> 8 Then
                        MsgBox("The staff number should be eight characters long.", MsgBoxStyle.Information)
                        Me.PERS_NOM.Focus()
                        Return False
                        Exit Function
                    End If

                    If PERS_NOM.Text = "00000000" Then
                        PERS_NOM.Text = "        "
                    End If

                    ' btnAddNew.Enabled = True
                    'blnAlmalIngevul = True
                End If

                btnAddNew.Enabled = True
                btnAddNew.Size = New Size(56, 22)
                BtnCancel.Location = New Point(58, 26)
                btnAddNew.Text = "Save"
                blnAlmalIngevul = True
            Else
                Return False
                Exit Function
            End If

        Else
            Return False
            Exit Function
        End If


        If blnAlmalIngevul Then

            '  BET_DAT.Text = cmbPayMonth.Text.PadLeft(2, "0") & "/" & "01" & "/" & cmbPayYear.Text
            '  BET_DAT.Text = (cmbPayMonthYear.SelectedIndex + 1).ToString.PadLeft(2, "0") + "/" + "01/" + cmbPayYear.Text
            Dim strPayyear As String = cmbPayMonthYear.SelectedItem.ToString.Substring(InStr(cmbPayMonthYear.SelectedItem.ToString, " "), 4).Trim
            Dim strPayMonth As String = cmbPayMonthYear.SelectedItem.ToString.Substring(0, InStr(cmbPayMonthYear.SelectedItem.ToString, " ")).Trim
            Select Case strPayMonth
                Case "Januarie", "January"
                    BET_DAT.Text = "01/01/" & strPayyear
                Case "Februarie", "February"
                    BET_DAT.Text = "02/01/" & strPayyear
                Case "Maart", "March"
                    BET_DAT.Text = "03/01/" & strPayyear
                Case "April"
                    BET_DAT.Text = "04/01/" & strPayyear
                Case "Mei", "May"
                    BET_DAT.Text = "05/01/" & strPayyear
                Case "Junie", "June"
                    BET_DAT.Text = "06/01/" & strPayyear
                Case "Julie", "July"
                    BET_DAT.Text = "07/01/" & strPayyear
                Case "Augustus", "August"
                    BET_DAT.Text = "08/01/" & strPayyear
                Case "September"
                    BET_DAT.Text = "09/01/" & strPayyear
                Case "Oktober", "October"
                    BET_DAT.Text = "10/01/" & strPayyear
                Case "November"
                    BET_DAT.Text = "11/01/" & strPayyear
                Case "Desember", "December"
                    BET_DAT.Text = "12/01/" & strPayyear
                Case Else
                    MsgBox("There was a problem with the selection of the first payment date", MsgBoxStyle.Critical)
                    Return False
                    Exit Function
            End Select

            VoegPolisBy()
            glbPolicyNumber = Me.POLISNO.Text
            btnAddNew.Text = "Add"

            BtnCancel.Visible = False
            BtnCancel.Enabled = False
            btnVersekerdesoek.Enabled = True
            btnPolicySearch.Enabled = True
            btnIdSearch.Enabled = True
            btnPolicySearch.Enabled = True
            ' StelTabIndexes("Soek/Edit")
            btnPremieDetail.Enabled = True
            btnAddNew.Size = New Size(56, 22)
            BtnCancel.Location = New Point(58, 26)
            ' BET_DAT.Text = "01/" + cmbPayMonth.Text.PadLeft(2, "0") + "/" + cmbPayYear.Text
            'Andriette 08/04/2014 dit word hanteer in die Voegpolisby funksie bietjie hoër op
            '  HerBereken_Premie()
            'Andr
            Poldata1_Stel_Items_Buttons(True)

        End If

        Return True

        '        Me.cmbPayMonth.SelectedText <> "" And _
        'Me.cmbPayYear.SelectedText <> "" And _
    End Function


    Private Sub OfficeMemoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OfficeMemoToolStripMenuItem.Click
        MemoList.ShowDialog()
    End Sub

    Private Sub ClientMemoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ClientMemoToolStripMenuItem.Click
        On Error Resume Next
        KMemoFrm.Memo.Text = Persoonl.K_OPMERKING
        If Err.Number <> 0 Then
            KMemoFrm.Memo.Text = ""
            Err.Clear()
        End If

        KMemoFrm.ShowDialog()
    End Sub

    Private Sub BtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancel.Click
        If MsgBox("Are you sure you want to cancel and loose all data?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            blnByvoeg = False
            blnPol_Byvoeg = False
            btnAddNew.Text = "Add"
            Exit_Renamed.Enabled = True

            If Not glbPolicyNumber Is Nothing Then
                DeleteOrphanRecords("Polisno", glbPolicyNumber, "poldata5.Aftrek")
            End If
            Clear_Values()
            BtnCancel.Visible = False
            BtnCancel.Enabled = False
            btnAddNew.Enabled = True
            btnVersekerdesoek.Enabled = True
            btnPolicySearch.Enabled = True
            btnIdSearch.Enabled = True
            'Andriette 06/02/2014 moet die betaalwyse inskrywing gaan delete

        End If

    End Sub

    Private Sub btnPolicySearch_Click(sender As System.Object, e As System.EventArgs) Handles btnPolicySearch.Click
        Soekopsies()
    End Sub

    Private Sub btnVersekerdesoek_Click(sender As System.Object, e As System.EventArgs) Handles btnVersekerdesoek.Click
        '  Command8.PerformClick()
        Soekopsies()
    End Sub

    Private Sub btnIdSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnIdSearch.Click
        ' Command8.PerformClick()
        Soekopsies()
    End Sub

    Private Sub Grid1_DataBindingComplete(sender As Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvPoldataVoertuie.DataBindingComplete
        Dim intTotaalPrem As Decimal = 0
        Dim inttotaalDek As Decimal = 0
        Dim voertuig As ListVoertuieByPolisnoEntity = New ListVoertuieByPolisnoEntity()
        For Each item In dgvPoldataVoertuie.DataSource
            voertuig = item
            intTotaalPrem = intTotaalPrem + voertuig.Totalepremie
            inttotaalDek = inttotaalDek + voertuig.Totalewaarde
        Next

        Me.dgvPoldataVoertuie.Columns(6).ToolTipText = FormatNumber(inttotaalDek, 2)
        Me.dgvPoldataVoertuie.Columns(7).ToolTipText = FormatNumber(intTotaalPrem, 2)

    End Sub

    Private Sub Grid2_DataBindingComplete(sender As Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvPoldata1Eiendomme.DataBindingComplete
        Dim intPremHH As Decimal = 0
        Dim intPremHE As Decimal = 0
        Dim intPremAcc As Decimal = 0
        Dim intPremEEM As Decimal = 0
        Dim intValueHH As Decimal = 0
        Dim intValueHE As Decimal = 0
        Dim intValueAcc As Decimal = 0
        Dim intValueEEm As Decimal = 0
        Dim intTotaalDek As Decimal = 0
        Dim huis As HuisEntity = New HuisEntity()

        For Each huis In dgvPoldata1Eiendomme.DataSource
            intPremHH = intPremHH + huis.PREMIE_HB
            intPremHE = intPremHE + huis.PREMIE_HE
            intPremAcc = intPremAcc + huis.TOE_PREMIE
            intPremEEM = intPremEEM + huis.EEM_PREMIE
            intValueHH = intValueHH + huis.WAARDE_HB
            intValueHE = intValueHE + huis.WAARDE_HE
            intValueAcc = intValueAcc + huis.TOE_WAARDE
            intValueEEm = intValueEEm + huis.EEM_WAARDE
        Next

        Me.dgvPoldata1Eiendomme.Columns(3).ToolTipText = FormatNumber(intValueHE, 2)
        Me.dgvPoldata1Eiendomme.Columns(4).ToolTipText = FormatNumber(intPremHE, 2)
        Me.dgvPoldata1Eiendomme.Columns(5).ToolTipText = FormatNumber(intValueHH, 2)
        Me.dgvPoldata1Eiendomme.Columns(6).ToolTipText = FormatNumber(intPremHH, 2)
        Me.dgvPoldata1Eiendomme.Columns(8).ToolTipText = FormatNumber(intValueAcc, 2)
        Me.dgvPoldata1Eiendomme.Columns(9).ToolTipText = FormatNumber(intPremAcc, 2)
        Me.dgvPoldata1Eiendomme.Columns(10).ToolTipText = FormatNumber(intValueEEm, 2)
        Me.dgvPoldata1Eiendomme.Columns(11).ToolTipText = FormatNumber(intPremEEM, 2)


    End Sub

    Private Sub Grid3_DataBindingComplete(sender As Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvPoldata1AlleRisikoItems.DataBindingComplete
        Dim intTotaalPrem As Decimal = 0
        Dim inttotaalDek As Decimal = 0
        Dim AlleRisk As ALLERISKEntity = New ALLERISKEntity()
        For Each AlleRisk In dgvPoldata1AlleRisikoItems.DataSource
            inttotaalDek = inttotaalDek + AlleRisk.Waarde
            intTotaalPrem = intTotaalPrem + AlleRisk.Premie
        Next
        Me.dgvPoldata1AlleRisikoItems.Columns(3).ToolTipText = FormatNumber(inttotaalDek, 2)
        Me.dgvPoldata1AlleRisikoItems.Columns(4).ToolTipText = FormatNumber(intTotaalPrem, 2)

    End Sub

    'Private Sub p_a_dat_TextChanged(sender As Object, e As System.EventArgs) Handles p_a_dat.TextChanged
    '    'Andriette 30/10/2013 sluit nuwe polisse uit
    '    'Andriette 24/02/2014 moenie nuwe polisse uitsluit nie
    '    If (blnLoading = False) And (blnClear_s = False) Then 'And Not (pol_byvoeg Or Byvoeg) Then
    '        blnchange = True
    '    End If

    'End Sub

    Private Sub p_a_dat_Leave(sender As Object, e As System.EventArgs) Handles p_a_dat.Leave
        Dim strAanvangsdat As String = ""

        If blnchange = True Then
            If Len(p_a_dat.Text) = 0 Then
                MsgBox("A date is required", 48, "Invalid start date")
                p_a_dat.Focus()
                Exit Sub
            End If

            If Len(p_a_dat.Text) <> 0 Then
                If Not IsDate(p_a_dat.Text) Then
                    MsgBox("A valid date is required.", 48, "Invalid start date")
                    p_a_dat.Focus()
                    Exit Sub
                End If
            End If
            'Andriette 08/04/2014 Die datum mag net 1 maand teruggaan
            Dim dtedatum_ingelees As Date = p_a_dat.Text
            Dim dteVroegste As Date = Today().AddMonths(-1)

            If dtedatum_ingelees < dteVroegste Then
                MsgBox("The Inception date may only be one month earlier than today", MsgBoxStyle.Exclamation)
                p_a_dat.Text = Today().AddMonths(-1).ToString("dd/MM/yyyy")
            End If

            If (blnByvoeg Or blnPol_Byvoeg) Then
                If blnSavedNew Then
                    UpdatePersoonlPerField("P_A_Dat", p_a_dat.Text)
                Else
                    'Andriette 07/04/2014 net as dit nognie gesave is nie
                    ToetsNoodsaaklik()
                End If
            Else
                strAanvangsdat = Persoonl.P_A_DAT
                UpdatePersoonlPerField("P_A_Dat", p_a_dat.Text)
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & (strAanvangsdat) & ") na (" & (Me.p_a_dat).Text & ")"
                Else
                    BESKRYWING = " change from (" & (strAanvangsdat) & ") to (" & (Me.p_a_dat).Text & ")"
                End If
                UpdateWysig(90, BESKRYWING)
            End If
            UpdateCLRSField("A", (Me.POLISNO).Text)
            blnchange = False
        End If
    End Sub

    Private Sub dtpInceptDt_Leave(sender As Object, e As System.EventArgs) Handles dtpInceptDt.Leave
        Dim strAanvangsdat As String = ""
        'Andriette 19/05/2014 gaan uit as cancel
        If BtnCancel.Focused Then
            Exit Sub
        End If

        If blnchange = True Then
            If Len(dtpInceptDt.Text) = 0 Then
                MsgBox("A date is required", 48, "Invalid inception date")
                dtpInceptDt.Focus()
                Exit Sub
            End If

            If dtpInceptDt.Text.Length > 0 Then
                If Not IsDate(dtpInceptDt.Text) Then
                    MsgBox("A valid date is required.", 48, "Invalid start date")
                    dtpInceptDt.Focus()
                    Exit Sub
                End If
            End If
            'Andriette 08/04/2014 Die datum mag net 1 maand teruggaan
            'Dim dtmdatum_ingelees As Date = dtpInceptDt.Text
            'Dim dtmVroegste As Date = Today().AddMonths(-1)

            'If dtmdatum_ingelees < dtmVroegste Then
            '    MsgBox("The Inception date may only be one month earlier than today", MsgBoxStyle.Exclamation)
            '    p_a_dat.Text = Today().AddMonths(-1).ToString("dd/MM/yyyy")
            'End If
            Dim dtedatum As Date
            dtedatum = dtpInceptDt.Value.Date
            Dim intDay As Integer = dtedatum.ToString.Substring(0, 2)
            Dim intMonth As Integer = dtedatum.ToString.Substring(3, 2)
            Dim intyear As Integer = dtedatum.ToString.Substring(6, 4)

            If (blnByvoeg Or blnPol_Byvoeg) Then
                If blnSavedNew Then
                    'UpdatePersoonlPerField("P_A_Dat", dtpInceptDt.Text)

                    UpdatePersoonlPerField("P_A_DAT", intMonth.ToString.Trim.PadLeft(2, "0") & "/" & intDay.ToString.Trim.PadLeft(2, "0") & "/" & intyear.ToString.Trim)
                Else
                    'Andriette 07/04/2014 net as dit nognie gesave is nie
                    ToetsNoodsaaklik()
                End If

            Else
                strAanvangsdat = Persoonl.P_A_DAT
                '  UpdatePersoonlPerField("P_A_Dat", dtpInceptDt.Text)
                UpdatePersoonlPerField("P_A_DAT", intMonth.ToString.Trim.PadLeft(2, "0") & "/" & intDay.ToString.Trim.PadLeft(2, "0") & "/" & intyear.ToString.Trim)
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & (strAanvangsdat) & ") na (" & dtpInceptDt.Text & ")"
                Else
                    BESKRYWING = " change from (" & (strAanvangsdat) & ") to (" & dtpInceptDt.Text & ")"
                End If
                UpdateWysig(90, BESKRYWING)
            End If
            UpdateCLRSField("A", (Me.POLISNO).Text)
            blnchange = False
        End If
    End Sub

    Private Sub dtpInceptDt_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpInceptDt.ValueChanged

        If (blnLoading = False) And (blnClear_s = False) Then
            blnchange = True
        End If
    End Sub

    Private Sub cmbPayMonthYear_Leave(sender As Object, e As System.EventArgs) Handles cmbPayMonthYear.Leave

        'Andriette 19/05/2014 gaan uit as cancel
        If BtnCancel.Focused Then
            Exit Sub
        End If

        If cmbPayMonthYear.SelectedIndex > -1 Then

            Dim strPayyear As String = cmbPayMonthYear.SelectedItem.ToString.Substring(InStr(cmbPayMonthYear.SelectedItem.ToString, " "), 4).Trim
            Dim strPayMonth As String = cmbPayMonthYear.SelectedItem.ToString.Substring(0, InStr(cmbPayMonthYear.SelectedItem.ToString, " ")).Trim
            Select Case strPayMonth
                Case "Januarie", "January"
                    BET_DAT.Text = "01/01/" & strPayyear
                Case "Februarie or February"
                    BET_DAT.Text = "02/01/" & strPayyear
                Case "Maart", "March"
                    BET_DAT.Text = "03/01/" & strPayyear
                Case "April"
                    BET_DAT.Text = "04/01/" & strPayyear
                Case "Mei", "May"
                    BET_DAT.Text = "05/01/" & strPayyear
                Case "Junie", "June"
                    BET_DAT.Text = "06/01/" & strPayyear
                Case "Julie", "July"
                    BET_DAT.Text = "07/01/" & strPayyear
                Case "Augustus", "August"
                    BET_DAT.Text = "08/01/" & strPayyear
                Case "September"
                    BET_DAT.Text = "09/01/" & strPayyear
                Case "Oktober", "October"
                    BET_DAT.Text = "10/01/" & strPayyear
                Case "November"
                    BET_DAT.Text = "11/01/" & strPayyear
                Case "Desember", "December"
                    BET_DAT.Text = "12/01/" & strPayyear
                Case Else
                    MsgBox("There was a problem with the selection of the first payment date" & strPayMonth, MsgBoxStyle.Critical)

                    Exit Sub
            End Select
        Else
            MsgBox("A payment date is required", MsgBoxStyle.Critical)
            cmbPayMonthYear.Focus()
        End If
    End Sub

    Private Sub cmbPayYear_Leave(sender As Object, e As System.EventArgs)
        If cmbPayMonthYear.SelectedItem <> "" Then
            ' If cmbPayMonth.Text < Now.Month Then
            If cmbPayMonthYear.SelectedIndex + 1 < dteAfsluitDatum.Month + 2 Then
                MsgBox("A month too early was be selected, please select an appropriate month. At least 2 months after the last run date.")
                cmbPayMonthYear.Text = Now.Month
                cmbPayMonthYear.Focus()
                Exit Sub
            End If
            'BET_DAT.Text = "01/" + cmbPayMonth.Text.PadLeft(2, "0") + "/" + cmbPayYear.Text
            '   BET_DAT.Text = (cmbPayMonthYear.SelectedIndex + 1).ToString.PadLeft(2, "0") + "/" + "01/" + cmbPayYear.Text
        End If
    End Sub


    'Andriette 20/09/2013
    'Stel die tab indexes op add sodat die gebruiker maklik van veld na veld kan spring en op die keyboard 'bly' vir intik
    'Indien nie add nie bly die versekerde tabindex 0
    Private Sub StelTabIndexes(state)
        POLISNO.TabIndex = 0
        TITEL.TabIndex = 1
        VOORL.TabIndex = 2
        VERSEKERDE.TabIndex = 3
        GEKANS.TabIndex = 4
        AREA.TabIndex = 5

        txtNoemnaam.TabIndex = 6
        ID_NOM.TabIndex = 7
        Taal.TabIndex = 8
        dept.TabIndex = 9
        BEROEP.TabIndex = 10
        txtBTWno.TabIndex = 11
        PERS_NOM.TabIndex = 12
        studentno.TabIndex = 13
        Oudstudentinstansie.TabIndex = 14

        posbestemming.TabIndex = 15
        ADRES.TabIndex = 16
        adres4.TabIndex = 17
        ADRES3.TabIndex = 18
        ADRES2.TabIndex = 19
        btnPostalCodes.TabIndex = 20
        POS_VAKKIE.TabIndex = 21
        HUIS_TEL.TabIndex = 22
        WERK_TEL.TabIndex = 23
        sel_tel.TabIndex = 24
        FAX.TabIndex = 24
        EMAIL.TabIndex = 26

        p_a_dat.TabIndex = 27
        BET_DAT.TabIndex = 28
        cmbPayMonthYear.TabIndex = 29
        Betaaldag.TabIndex = 31
        BYBET_K.TabIndex = 32
        VANWIE.TabIndex = 33
        lbltipepolis.TabIndex = 34
        lbltermynperiode.TabIndex = 35
        lbltermynmaande.TabIndex = 36
        Combo1.TabIndex = 37

    End Sub

    'Andriette 23/01/214 'n Funksie wat die betaalwyse en ander nodige inligting op die skerm vertoon

    Private Sub poldata_DecodeBetaalwyse()
        Select Case Trim(Persoonl.BET_WYSE)
            Case "1"
                Me.lbltipepolis.Text = "Monthly Cash"
                lbltipepolis.Visible = True
                Me.grpTermynInligting.Visible = False
            Case "2"
                Me.lbltipepolis.Text = "Annually Cash"
                lbltipepolis.Visible = True
                Me.grpTermynInligting.Visible = False
            Case "3"
                Me.lbltipepolis.Text = "Monthly Salary"
                lbltipepolis.Visible = True
                Me.grpTermynInligting.Visible = False
            Case "4"
                Me.lbltipepolis.Text = "Monthly Debit"
                lbltipepolis.Visible = True
                Me.grpTermynInligting.Visible = False
            Case "5"
                Me.lbltipepolis.Text = "Monthly Electronic"
                lbltipepolis.Visible = True
                Me.grpTermynInligting.Visible = False
            Case "6"
                Me.lbltipepolis.Text = "Term Policy"
                lbltipepolis.Visible = False
                Me.grpTermynInligting.Visible = True
                grpTermynInligting.Text = "Term Policy"
                'Andriette 09/07/2014 weet nie of hierdie ekstra roep werklik nodig is nie Dit populate 'n LTPJN variable 
                ' en dit lyk nie of iets verder daarmee gesoen word nie
                '  FetchLangtermynPolis() ' stel ;n global variable LTPJN ?
                getLangtermynStatus()
                'Andriette 09/07/2014 dit kan net 6 wees uit die case waarin dit nou is
                '    If Persoonl.BET_WYSE = "6" Then
                'Andriette 09/07/2014 dit maak nie sin om die controls vals te he nie
                'enableCtrlsForLongtermPolicy(False)
                enableCtrlsForLongtermPolicy(True)
                Me.mnuLTPbriewe.Enabled = True

                'Else
                'enableCtrlsForLongtermPolicy(True)
                ''Andriette 02/09/2013 termynpolisse is 6
                ''If Persoonl.BET_WYSE = "2" Then
                'If Persoonl.BET_WYSE = "6" Then
                '    Me.mnuLTPbriewe.Enabled = True
                'Else
                '    Me.mnuLTPbriewe.Enabled = False
                'End If
                'End If
            Case Else
                'Andriette 07/06/2013 verander die taal na engels
                'Me.txtTipePolis.Text = "Onbekend"
                Me.lbltipepolis.Text = "Unknown"
                Me.grpTermynInligting.Visible = False
        End Select
    End Sub

    Private Sub Poldata1_Stel_Items_Buttons(ByVal blnFunksioneel As Boolean)
        Voeg_By.Enabled = blnFunksioneel
        Edit_.Enabled = blnFunksioneel
        Vee_Uit.Enabled = blnFunksioneel
        btnVerwyderdeItems.Enabled = blnFunksioneel
        'Andriette 24/03/2014 
        Exit_Renamed.Enabled = blnFunksioneel
    End Sub

    ' Andriette 10/02/2014 Kry die laaste afsluit datum om die default nuwe betaaldatum te bereken
    Private Function pldKryAfsluitDatum(ByVal intTipePolis As Integer) As Date
        Dim dteLaasteAfsluit As Date = Now()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5d].[FetchAfsluitDatumLaaste]")
                If reader.Read Then
                    dteLaasteAfsluit = reader("Afsluit_dat")
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Return dteLaasteAfsluit
    End Function

    'Andriette 11/02/2014 Default die eerste betaaldatum

    Private Sub poldata1_DefaultFirstPaydate(ByVal dteAfsluitDatum As Date, ByVal intTaal As Integer)
        Dim intAfsluitMaand As Integer = dteAfsluitDatum.Month
        Dim intVandagMaand As Integer = Today.Month
        Dim strMaande(12, 2) As String
        Dim IntVandagJaar As Integer = Today.Year
        Dim intafsluitjaar As Integer = dteAfsluitDatum.Year
        Dim intbetaaljaar As Integer = dteAfsluitDatum.AddMonths(2).Year
        Dim intNoumaand As Integer = dteAfsluitDatum.AddMonths(2).Month
        Dim dteTeldatum As Date = dteAfsluitDatum.AddMonths(2)

        strMaande(0, 0) = "01"
        strMaande(0, 1) = "Januarie"
        strMaande(0, 2) = "January"
        strMaande(1, 0) = "02"
        strMaande(1, 1) = "Februarie"
        strMaande(1, 2) = "February"
        strMaande(2, 0) = "03"
        strMaande(2, 1) = "Maart"
        strMaande(2, 2) = "March"
        strMaande(3, 0) = "04"
        strMaande(3, 1) = "April"
        strMaande(3, 2) = "April"
        strMaande(4, 0) = "05"
        strMaande(4, 1) = "Mei"
        strMaande(4, 2) = "May"
        strMaande(5, 0) = "06"
        strMaande(5, 1) = "Junie"
        strMaande(5, 2) = "June"
        strMaande(6, 0) = "07"
        strMaande(6, 1) = "Julie"
        strMaande(6, 2) = "July"
        strMaande(7, 0) = "08"
        strMaande(7, 1) = "Augustus"
        strMaande(7, 2) = "August"
        strMaande(8, 0) = "09"
        strMaande(8, 1) = "September"
        strMaande(8, 2) = "September"
        strMaande(9, 0) = "10"
        strMaande(9, 1) = "Oktober"
        strMaande(9, 2) = "October"
        strMaande(10, 0) = "11"
        strMaande(10, 1) = "November"
        strMaande(10, 2) = "November"
        strMaande(11, 0) = "12"
        strMaande(11, 1) = "Desember"
        strMaande(11, 2) = "December"
        cmbPayMonthYear.Items.Clear()
        For intmaand = 1 To 12
            If intTaal = 0 Then ' Afrikaans
                cmbPayMonthYear.Items.Add(strMaande(dteTeldatum.Month - 1, 1) + " " + dteTeldatum.Year.ToString)

            ElseIf intTaal = 1 Then ' Engels
                cmbPayMonthYear.Items.Add(strMaande(dteTeldatum.Month - 1, 2) + " " + dteTeldatum.Year.ToString)
            End If

            dteTeldatum = dteTeldatum.AddMonths(1)
        Next
        cmbPayMonthYear.SelectedIndex = 0
    End Sub

    'Andriette 21/02/2014 voeg by om te werk soos al die ander
    Private Sub txthomeAsstPrem_TextChanged(sender As Object, e As System.EventArgs) Handles txthomeAsstPrem.TextChanged
        If Not blnLoading And Not blnClear_s Then
            blnchange = True
        End If
    End Sub

    'Andriette 10/03/2014 moenie kan verbygaan as die voorstad en poskode nie gekies is nie
    Private Sub btnPostalCodes_Leave(sender As Object, e As System.EventArgs) Handles btnPostalCodes.Leave
        If BtnCancel.Focused Then
            Exit Sub
        End If
        If ADRES3.Text.ToUpper = "SUBURB" Or ADRES3.Text.ToUpper = "CODE" Then
            MsgBox("The suburb and postal code must be entered. Please use the postal code list to select", MsgBoxStyle.Exclamation)
            btnPostalCodes.Focus()
        End If
    End Sub

    Private Sub EnterButton_Click(sender As System.Object, e As System.EventArgs) Handles EnterButton.Click
        'Andriette 19/03/2014 maak ;n ander enter button
        If blnPol_Byvoeg Or blnByvoeg Then
            MsgBox("Adding a new policy, please use TAB or the MOUSE (not ENTER)", 48, "")
            Exit Sub
        End If

        If blnLoaded Then
            MsgBox("When you view or amend a policy, please use the TAB key or the MOUSE (not ENTER)", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Soekopsies()
    End Sub

    Private Sub Form1_LostFocus(sender As Object, e As System.EventArgs) Handles Me.LostFocus
        'MsgBox("Poldata1 lostfocus")
        If Me.ActiveControl Is Nothing Then

        Else
            strPolVeldFokus = Me.ActiveControl.Name
        End If
    End Sub

    Private Sub poldata1_ManageReferralsOnPolicyCancelAndRestore(strPolicyNumber, strAction)
        Dim param1() As SqlParameter = {New SqlParameter("@PolicyNumber", SqlDbType.NChar), _
                                        New SqlParameter("@SearchOn", SqlDbType.NChar), _
                                        New SqlParameter("@SearchStatus", SqlDbType.NChar)}

        Dim param2() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NChar), _
                                New SqlParameter("@verwysdeur", SqlDbType.NChar)}
        ' Stel die status na "Cancelled"
        Dim param3() As SqlParameter = {New SqlParameter("@pkVerwysdes", SqlDbType.NChar), _
                                         New SqlParameter("@status", SqlDbType.NChar)}
        'Dim strverwysde As String = ""
        Dim strverwyser As String = ""
        Dim intPkVerwysdes As Integer = 0
        Dim strStatus As String = ""
        Dim strverwysde As String = ""
        Dim strTaal As String

        'Kry eers al die inskrywing op die verwysesdes tabel met die polisnommer
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                param1(0).Value = strPolicyNumber
                param1(1).Value = "Verwysde"
                If strAction = "Cancel" Then
                    param1(2).Value = "Active"
                ElseIf strAction = "Restore" Then
                    param1(2).Value = "Cancelled"
                End If

                Dim reader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchVerwysdesAndPersoonl]", param1)

                If reader.HasRows Then

                    Do While reader.Read()

                        If reader("verwyser") IsNot DBNull.Value Then
                            If reader("verwyser") <> "" Then
                                strverwyser = reader("verwyser")
                            Else
                                strverwyser = ""
                            End If
                        End If

                        If reader("pkVerwysdes") IsNot DBNull.Value Then
                            If reader("pkVerwysdes") <> 0 Then
                                intPkVerwysdes = reader("pkVerwysdes")
                            Else
                                intPkVerwysdes = ""
                            End If
                        End If

                        If reader("status") IsNot DBNull.Value Then
                            If reader("status") <> "" Then
                                strStatus = reader("status")
                            Else
                                strStatus = ""
                            End If
                        End If

                        strTaal = poldata1_FetchDetailOnPolicy("Taal", strverwyser)
                        param3(0).Value = intPkVerwysdes
                        If strAction = "Cancel" And strStatus = "Active" Then
                            param3(1).Value = "Cancelled"
                            'Andriette 23/05/2014
                            'Andriette 27/06/2014 
                            If strTaal = 0 Then
                                BESKRYWING = "Verwysde Polisnommer " & strPolicyNumber & " is gekanseleer"
                            ElseIf strTaal = 1 Then
                                BESKRYWING = "Referred Policy number " & strPolicyNumber & " is cancelled"
                            Else
                                BESKRYWING = ""
                            End If
                            UpdateWysig(143, BESKRYWING, strverwyser)

                            UpdatePersoonlPerField("Verwysdeur", "")
                            'Andriette 04/06/2014 haal uit want dit word in updatepersoonlperfield hanteer
                            'Persoonl.verwysdeur = "" 
                            Verwysdeur.Text = ""
                            'andriette 04/06/2014 haal uit want as dit op die huidige polis is word die updatepersoonlperfield gebruik
                            '  SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[Updateverwysdeurinpersoonl]", param2)
                            ' SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdateVerwysdesStatus]", param3)

                        ElseIf strAction = "Restore" And strStatus = "Cancelled" Then
                            'param2(0).Value = strverwyser
                            'param2(1).Value = ""


                            param3(1).Value = "Active"
                            'Andriette 23/05/2014
                            'Andriette 27/06/2014
                            '     If Persoonl.TAAL = 0 Then 'Afrikaans
                            If strTaal = 0 Then
                                BESKRYWING = "Verwysde Polisnommer " & strPolicyNumber & " is aktief"
                            ElseIf strTaal = 1 Then
                                BESKRYWING = "Referred Policy number " & strPolicyNumber & " is active"
                            Else
                                BESKRYWING = ""
                            End If
                            UpdateWysig(144, BESKRYWING, strverwyser)
                            'Andriette 04/06/2014 sit dit in want dit moet inkom
                            UpdatePersoonlPerField("Verwysdeur", strverwyser)
                            'Persoonl.verwysdeur = strverwyser
                            Verwysdeur.Text = strverwyser
                            'andriette 04/06/2014 haal uit want as dit op die huidige polis is word die updatepersoonlperfield gebruik
                            '  SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[Updateverwysdeurinpersoonl]", param2)
                            'SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdateVerwysdesStatus]", param3)
                        End If
                        SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdateVerwysdesStatus]", param3)
                        BESKRYWING = ""
                    Loop
                End If

                'Andriette doen as verwyser
                Dim param4() As SqlParameter = {New SqlParameter("@PolicyNumber", SqlDbType.NChar), _
                                                New SqlParameter("@SearchOn", SqlDbType.NChar), _
                                                New SqlParameter("@SearchStatus", SqlDbType.NChar)}

                param4(0).Value = strPolicyNumber
                param4(1).Value = "Verwyser"
                If strAction = "Cancel" Then
                    param4(2).Value = "Active"
                ElseIf strAction = "Restore" Then
                    param4(2).Value = "Cancelled"
                End If
                Dim reader1 = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchVerwysdesAndPersoonl]", param4)
                If reader1.HasRows Then
                    Do While reader1.Read()
                        If reader1("verwysde") IsNot DBNull.Value Then
                            If reader1("verwysde") <> "" Then
                                strverwysde = reader1("verwysde")
                            Else
                                strverwysde = ""
                            End If
                        End If

                        If reader1("pkVerwysdes") IsNot DBNull.Value Then
                            If reader1("pkVerwysdes") <> 0 Then
                                intPkVerwysdes = reader1("pkVerwysdes")
                            Else
                                intPkVerwysdes = ""
                            End If
                        End If

                        If reader1("status") IsNot DBNull.Value Then
                            If reader1("status") <> "" Then
                                strStatus = reader1("status")
                            Else
                                strStatus = ""
                            End If
                        End If

                        Dim param5() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NChar), _
                                                        New SqlParameter("@verwysdeur", SqlDbType.NChar)}
                        ' Stel die status na "Cancelled"
                        Dim param6() As SqlParameter = {New SqlParameter("@pkVerwysdes", SqlDbType.NChar), _
                                                         New SqlParameter("@status", SqlDbType.NChar)}
                        strTaal = poldata1_FetchDetailOnPolicy("Taal", strverwysde)
                        If strAction = "Cancel" And strStatus = "Active" Then
                            'Maak die veld in die persoonl tabel leeg
                            param5(0).Value = strverwysde
                            param5(1).Value = ""

                            param6(0).Value = intPkVerwysdes
                            param6(1).Value = "Cancelled"

                            If strTaal = 0 Then 'Afrikaans
                                BESKRYWING = "Verwyser Polis " & strPolicyNumber & " is gekanseleer"
                            ElseIf strTaal = 1 Then
                                BESKRYWING = "Referrer Policy " & strPolicyNumber & " is cancelled"
                            Else
                                BESKRYWING = ""
                            End If
                            UpdateWysig(143, BESKRYWING, strverwysde)

                        ElseIf strAction = "Restore" And strStatus = "Cancelled" Then
                            param5(0).Value = strverwysde
                            param5(1).Value = strPolicyNumber

                            param6(0).Value = intPkVerwysdes
                            param6(1).Value = "Active"

                            If strTaal = 0 Then 'Afrikaans
                                BESKRYWING = "Verwyser Polis " & strPolicyNumber & " is aktief"
                            ElseIf strTaal = 1 Then
                                BESKRYWING = "Referrer Policy " & strPolicyNumber & " is active"
                            Else
                                BESKRYWING = ""
                            End If
                            UpdateWysig(144, BESKRYWING, strverwysde)

                        End If
                        BESKRYWING = ""
                        SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[Updateverwysdeurinpersoonl]", param5)
                        SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdateVerwysdesStatus]", param6)
                    Loop
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    'Andriette 28/05/2014 voeg nuwe menu opsies by
    Private Sub mnuCellphoneUpdate_Click(sender As System.Object, e As System.EventArgs) Handles mnuCellphoneUpdate.Click
        frmCellphonesUpdate.Show()
    End Sub
    'Andriette 28/05/2014 nuwe menu opsies
    Private Sub mnuHomeLonesUpdate_Click(sender As System.Object, e As System.EventArgs) Handles mnuHomeLonesUpdate.Click
        frmHomeLoansUpdate.Show()

    End Sub
    'Andriette 05/06/2014 Nuwe menu opsies
    Private Sub mnuVehicleAccessUpdate_Click(sender As System.Object, e As System.EventArgs) Handles mnuVehicleAccessUpdate.Click
        frmVehicleAccessoriesUpdate.Show()
    End Sub

    Private Sub mnuHirePurchaseUpdate_Click(sender As System.Object, e As System.EventArgs) Handles mnuHirePurchaseUpdate.Click
        'Andriette 05/06/201 nuwe menu opsies
        frmHirePurchasesUpdate.Show()
    End Sub

    Private Sub mnuArchiveCategoriesUpdate_Click(sender As System.Object, e As System.EventArgs) Handles mnuArchiveCategoriesUpdate.Click
        frmArchiveCategoriesUpdate.Show()
    End Sub

    Private Sub mnuCommManagement_Click(sender As System.Object, e As System.EventArgs) Handles mnuCommManagement.Click
        frmCommunicationManagement.Show()
    End Sub


    Private Sub mnuVoiceArchive_Click(sender As System.Object, e As System.EventArgs) Handles mnuVoiceArchive.Click
        ArchiveVoice.ShowDialog()
    End Sub

    Private Sub mnuEise_Click(sender As System.Object, e As System.EventArgs) Handles mnuEise.Click
        frmClaimsList.ShowDialog()
    End Sub

    Private Sub mnuVoiceManagement_Click(sender As Object, e As System.EventArgs) Handles mnuVoiceManagement.Click
        frmVoice1Management.Show()
    End Sub
    Private Sub mnuVoiceRecording_Click(sender As Object, e As System.EventArgs) Handles mnuVoiceRecording.Click
        Dim strTempPath As String = ""
        Dim strFileToCopy As String
        Dim strFileName As String
        Dim strNewPath As String
        strTempPath = Directory.GetFiles(strTeks).OrderByDescending(Function(f) New FileInfo(f).LastWriteTime).First()
        strFileName = Microsoft.VisualBasic.Right(strTempPath, 22)
        strNewPath = "c:\polis5Voice\" & strFileName
        strFileToCopy = strTempPath
        If File.Exists(strNewPath) Then
            'skip file copy
        Else
            If strTempPath.Length > 0 Then
                My.Computer.FileSystem.CopyFile(strFileToCopy, strNewPath,
           FileIO.UIOption.AllDialogs,
               FileIO.UICancelOption.ThrowException)
            End If

        End If
        frmVoiceRecording.txtFileName.Text = strNewPath
        frmVoiceRecording.cmbCategory.Text = ""
        frmVoiceRecording.btnOk.Enabled = True
        frmVoiceRecording.btnCancel.Text = "Cancel"
        frmVoiceRecording.ShowDialog()
    End Sub
    Public Sub VoiceMonitor()
        '******************************************************************************
        ' Author       : Kobus
        ' Created      : 30/07/2014
        ' Purpose      : To invoke Voice Recording Form when dailing or receiving calls
        '******************************************************************************
        Dim watchfolder = New System.IO.FileSystemWatcher()
        blnStopWatch = False
        Try
            Using sr As New StreamReader("c:\polis5Admin\MyPath.txt")
                strTeks = sr.ReadToEnd()
            End Using
            'this is the path we want to monitor
            watchfolder.Path = strTeks
            'Add a list of Filters 
            watchfolder.NotifyFilter = IO.NotifyFilters.DirectoryName
            watchfolder.NotifyFilter = watchfolder.NotifyFilter Or _
                                       IO.NotifyFilters.FileName
            watchfolder.NotifyFilter = watchfolder.NotifyFilter Or _
                                       IO.NotifyFilters.Size

            ' add the handler to each event
            AddHandler watchfolder.Changed, AddressOf logchange
            watchfolder.EnableRaisingEvents = True

            '    Else
            '        MsgBox("File does not exist")
            '    End If
        Catch e As Exception
            MsgBox("The Amethyst file path is not available")
            Exit Sub
        End Try
    End Sub
    Private Sub logchange(sender As Object, e As FileSystemEventArgs)
        'Kobus 30/07/2014 skep om VoiceMonitor by te staan
        If blnStopWatch = True Then
            frmVoiceRecording.Close()
            blnStopWatch = True
            Exit Sub
        End If
        Try
            blnStopWatch = True
            'watchfolder.EnableRaisingEvents = False
            Dim strTempPath As String = ""
            Dim strFileToCopy As String
            Dim strFileName As String
            Dim strNewPath As String
            strTempPath = Directory.GetFiles(strTeks).OrderByDescending(Function(f) New FileInfo(f).LastWriteTime).First()
            strFileName = Microsoft.VisualBasic.Right(strTempPath, 22)
            Dim result As String
            If strFileName.Length > 4 Then
                result = strFileName.Substring(strFileName.Length - 4)
                If result <> ".GSM" Then
                    Exit Sub
                End If
            End If
            strNewPath = "c:\polis5Voice\" & strFileName
            If File.Exists(strNewPath) Then
                Exit Sub
            End If
            'strTempPath = Microsoft.VisualBasic.Right(strTempPath, 22)
            strInformation = strNewPath   'My.Computer.FileSystem.GetFileInfo(strTempPath)
            If e.ChangeType = IO.WatcherChangeTypes.Changed Then
                strFileToCopy = strTempPath
                'Dim files = Directory.GetFiles(strTempPath, "*.*")
                If strTempPath.Length > 0 Then
                    My.Computer.FileSystem.CopyFile(strFileToCopy, strNewPath,
               FileIO.UIOption.AllDialogs,
                   FileIO.UICancelOption.ThrowException)
                End If
                frmVoiceRecording.txtInsured.Focus()
                frmVoiceRecording.txtFileName.Text = strInformation
                frmVoiceRecording.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub


    Private Sub mnuMenMUpdate_Click(sender As Object, e As System.EventArgs) Handles mnuMenMUpdate.Click
        menmfrm1.Show()
    End Sub
End Class