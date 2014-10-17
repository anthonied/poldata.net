Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports DAL
Imports System.Text.RegularExpressions

Friend Class Bet_Wyse
    Inherits BaseForm
    ''Description  : Capture information on the payment method as well as the policy's banking details
    Dim strmsgBankClicked As String
    Dim strpreviousBetWyse As String ' Betwyse for policy prior to change
    Dim blnPkBnkCodesChanged As Boolean
    Dim blnSurnameChanged As Boolean
    Dim blnInitialsChanged As Boolean
    Dim blnAccNumberChanged As Boolean
    Dim blnAccTypeChanged As Boolean
    Dim strpreviousAccNumber As String
    Dim blnInformationChanged As Boolean 'Check if info on form changed

    Dim blnformloaded As Boolean
    Dim blnCVVNommerChanged As Boolean
    Dim blnKaartVervaldatumChanged As Boolean
    Dim strpreviousCCExpiryDate As String
    Dim strpreviousCVVNumber As String
    Dim blnbetWyseLoading As Boolean = False
    Dim takdetail As New TakEntity
    'Andriette 23/04/2014 
    Dim blnCancelClick As Boolean = False
    ' Dim formLoaded As String
    '  Dim bankName As String
    ' Dim branchName As String
    'Dim branchCode As String
    'Dim accType As String

    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click

        'Initialize
        blnPkBnkCodesChanged = False
        blnSurnameChanged = False
        blnAccNumberChanged = False
        blnAccTypeChanged = False
        blnInitialsChanged = False
        blnKaartVervaldatumChanged = False
        blnCVVNommerChanged = False
        Dim blnChanges As Boolean = False 'Andriette 16/08/2013 
        'Set current betWyse for policy
        strpreviousBetWyse = Persoonl.BET_WYSE
        '	'Validate form
        If validateForm() Then
            'Monthly cash
            If Me.rdMndKontant.Checked Then
                Persoonl.BET_WYSE = 1
            End If
            'Annual cash
            'If Me.rdJrKontant.Checked Then
            '    Persoonl.BET_WYSE = 2
            'End If
            'Monthly Salary
            ' Andriette 26/07/2013 verander die waardes om oreen te stem met Poldata1
            If Me.rdMndSalaris.Checked Then
                'Persoonl.BET_WYSE = 2
                Persoonl.BET_WYSE = 3
            End If
            'Montly debit
            If Me.rdMndDebiet.Checked Then
                'Persoonl.BET_WYSE = 3
                Persoonl.BET_WYSE = 4
            End If
            'Montly electronic
            If Me.rdMndElektronies.Checked Then
                'Persoonl.BET_WYSE = 4
                Persoonl.BET_WYSE = 5
            End If

            'Termynpolis
            If Me.rdTermynPolis.Checked Then
                'Persoonl.BET_WYSE = 5
                Persoonl.BET_WYSE = 6
            End If

            EditBetwyse("UpdateBewyse")

            'Check if betwyse value changed - insert alteration record
            'Andriette moenie wysiging skryf as dit 'n byvoeg is nie
            If Not (blnPol_Byvoeg Or blnByvoeg) Then
                If strpreviousBetWyse <> Persoonl.BET_WYSE Then
                    BetWyseAlteration()
                Else
                    'Andriette 16/08/2013 gebruik die global polisnommer
                    'UpdateCLRSField("A", (Form1.POLISNO).Text)
                    UpdateCLRSField("A", glbPolicyNumber)
                End If
            End If
            '* * * Update the bank details for policy * * *
            'check for changes
            If txtPkBnkCodes.Text = "" And txtPkBnkCodes.Text = "" Then
                '  Form1.getLangtermynStatus()
                Form1.btnPremieDetail.Enabled = True

                Me.Close()
            Else
                'Andriette 11/03/2014 as die tipe verander het moenie die bank besonderhede verandering log nie\
                ' If previousBetWyse = Persoonl.BET_WYSE and persoonl.bet_wyse   Then
                If Persoonl.BET_WYSE = 4 Then


                    ' If previousBetWyse = Persoonl.BET_WYSE And Aftrek.FK_BANKCODE <> CInt(Me.txtPkBnkCodes.Text) Or (IsDBNull(Aftrek.FK_BANKCODE) And CInt(Me.txtPkBnkCodes.Text) <> 0) Then
                    If Aftrek.FK_BANKCODE <> CInt(Me.txtPkBnkCodes.Text) Or (IsDBNull(Aftrek.FK_BANKCODE) And CInt(Me.txtPkBnkCodes.Text) <> 0) Then
                        blnPkBnkCodesChanged = True
                    End If

                    If Aftrek.A_VAN <> Me.txtSurname.Text Then
                        blnSurnameChanged = True
                        'Andriette 16/08/2013
                        blnChanges = True
                        '      UpdateCLRSField("A", (Form1.POLISNO).Text)
                    End If

                    If Aftrek.A_VL <> Me.txtInitials.Text Then
                        blnInitialsChanged = True
                        'Andriette 16/08/2013
                        blnChanges = True

                        '      UpdateCLRSField("A", (Form1.POLISNO).Text)
                    End If

                    If Aftrek.A_TIPE <> Me.cmbAccType.SelectedIndex + 1 Then
                        blnAccTypeChanged = True
                        'Andriette 16/08/2013
                        blnChanges = True
                        '    UpdateCLRSField("A", (Form1.POLISNO).Text)
                    End If

                    If Aftrek.REK_NO1 <> Me.txtAccNumber.Text Then
                        blnAccNumberChanged = True
                        'Andriette 16/08/2013
                        blnChanges = True
                        '   UpdateCLRSField("A", (Form1.POLISNO).Text)
                        strpreviousAccNumber = Aftrek.REK_NO1
                    End If

                    If cmbAccType.Text = "Krediet" Or cmbAccType.Text = "Credit" Then
                        If IsDBNull(Aftrek.CREDIT_CARD_CVV_NO) Or Aftrek.CREDIT_CARD_CVV_NO <> Me.txtCVVNommer.Text Then
                            blnCVVNommerChanged = True
                            'Andriette 16/08/2013
                            blnChanges = True
                            '  UpdateCLRSField("A", (Form1.POLISNO).Text)
                            If IsDBNull(Aftrek.CREDIT_CARD_CVV_NO) Then
                                strpreviousCVVNumber = ""
                            Else
                                strpreviousCVVNumber = Aftrek.CREDIT_CARD_CVV_NO
                            End If
                        End If
                        If IsDBNull(Aftrek.CREDIT_CARD_EXPIRY_DATE) Or Aftrek.CREDIT_CARD_EXPIRY_DATE <> Me.txtKaartVervaldatum.Text Then
                            blnKaartVervaldatumChanged = True
                            'Andriette 16/08/2013
                            blnChanges = True
                            '    UpdateCLRSField("A", (Form1.POLISNO).Text)
                            If IsDBNull(Aftrek.CREDIT_CARD_EXPIRY_DATE) Then
                                strpreviousCCExpiryDate = ""
                            Else
                                strpreviousCCExpiryDate = Aftrek.CREDIT_CARD_EXPIRY_DATE
                            End If
                        End If
                    End If
                    'End If
                    'If Persoonl.BET_WYSE = 4 Then


                    'Set new values for record
                    Aftrek.FK_BANKCODE = Me.txtPkBnkCodes.Text
                    Aftrek.A_VAN = Me.txtSurname.Text
                    Aftrek.A_VL = Me.txtInitials.Text
                    Aftrek.A_TIPE = Me.cmbAccType.SelectedIndex + 1
                    Aftrek.REK_NO1 = Me.txtAccNumber.Text
                    If cmbAccType.Text = "Krediet" Or cmbAccType.Text = "Credit" Then
                        Aftrek.CREDIT_CARD_CVV_NO = Me.txtCVVNommer.Text
                        Aftrek.CREDIT_CARD_EXPIRY_DATE = Me.txtKaartVervaldatum.Text
                    End If
                    'Andriette 10/04/2014 herorganiseer
                    ''Aftrek.Update

                    'Andriette 11/04/2014 moenie save as nie maandeliks debiet is nie
                    'If Aftrek.NoMatch Then 'no record for this policy -> add new
                    '    Save("Save/Edit")
                    '    'Andriette 16/08/2013 gebruik die global polisnommer
                    '    'Aftrek.POLISNO = Form1.POLISNO.Text
                    '    Aftrek.POLISNO = glbPolicyNumber
                    'Else 'update
                    '    Save("Save/Edit")
                    'End If

                    If rdMndDebiet.Checked Then
                        Save("Save/Edit") ' bankdetails op aftrek tabel
                        If Aftrek.NoMatch Then
                            Aftrek.POLISNO = glbPolicyNumber
                        End If
                    End If

                    'Insert alteration records for bankdetails
                    bankingAlteration()
                    If blnChanges Then
                        UpdateCLRSField("A", glbPolicyNumber)
                    End If
                End If
            End If
            'Update form1, policy type & status
            If Persoonl.BET_WYSE = 6 Then
                Form1.getLangtermynStatus()
            End If

            Form1.btnPremieDetail.Enabled = True

            Me.Close()
        End If
    End Sub
    Private Sub cmbAccType_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbAccType.SelectedIndexChanged
        'andriette 23/04/2014 
        If Not (blnLoading Or Not blnformloaded) Then
            blnInformationChanged = True
        End If

    End Sub

    Private Sub Bet_Wyse_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        'Set form title
        ' Andriette 05/03/2013 Verander die opskrif
        'Me.Text = My.Application.Info.Title & " - Payment Advice - " & Form1.TITEL.Text & " " & Form1.VOORL.Text & " " & Form1.VERSEKERDE.Text & " (" & Form1.POLISNO.Text & ")"
        'Andriette 16/08/2013 gebruik die global polisnommer
        'Me.Text = My.Application.Info.Title & " - Payment Method - " & Form1.TITEL.Text & " " & Form1.VOORL.Text & " " & Form1.VERSEKERDE.Text & " (" & Form1.POLISNO.Text & ")"
        Me.Text = My.Application.Info.Title & " - Payment Method - " & Form1.TITEL.Text & " " & Form1.VOORL.Text & " " & Form1.VERSEKERDE.Text & " (" & glbPolicyNumber & ")"
        If Gebruiker.titel = "Besigtig" Then
            Me.btnOk.Enabled = False
            Me.rdTermynPolis.Enabled = False
        End If
    End Sub

    Private Sub Bet_Wyse_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Andriette 22/08/2013 kry die takdetail vir verwerking 
        blnbetWyseLoading = True
        ClearBankDetails()
        InitBetWyse()

        blnformloaded = False
        blnCancelClick = False
        'Andriette 11/04/2014 verander die werking

        If Not (blnByvoeg Or blnPol_Byvoeg) Then
            'Andriette 19/02/2014 1.256 As dit nie Maandeliks debiet is nie moenie enige gestoorde bankdetail wys nie
            'Seek record in aftrek for this policy
            BWKryAftrekDetail()
            If Not Aftrek.NoMatch Then
                'Set account type value according to value in database
                If Aftrek.A_TIPE = "" Or IsDBNull(Aftrek.A_TIPE) Then
                    Me.cmbAccType.Text = ""
                Else
                    Me.cmbAccType.SelectedIndex = Val(Aftrek.A_TIPE) - 1
                End If

            End If

            'Get the bank details using pk
            'Andriette 14/05/2014
            bankName = ""
            branchName = ""
            branchCode = ""
            accType = ""
            If Aftrek.FK_BANKCODE <> "0" Then
                getBankDetails((Aftrek.FK_BANKCODE), bankName, branchName, branchCode, accType)
            End If


            'Andriette 10/03/2014  wys net vir maandelik elektronies
            'If Persoonl.BET_WYSE <> "4" Then
            If Persoonl.BET_WYSE = "4" Then
                Me.txtCVVNommer.Text = ""
                Me.txtKaartVervaldatum.Text = ""
                Me.txtAccNumber.Text = Aftrek.REK_NO1 & ""
                Me.txtBank.Text = bankName
                Me.txtBranch.Text = branchName
                Me.txtBranchCode.Text = branchCode
                Me.txtType.Text = accType
                Me.txtInitials.Text = Aftrek.A_VL & ""
                Me.txtPkBnkCodes.Text = Aftrek.FK_BANKCODE
                Me.txtSurname.Text = Aftrek.A_VAN & ""

                'If Me.txtType.Text = "Credit card" Then
                If Aftrek.A_TIPE = "4" Then
                    'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                    If Not IsDBNull(Aftrek.CREDIT_CARD_CVV_NO) Or Not IsDBNull(Aftrek.CREDIT_CARD_EXPIRY_DATE) Then
                        Me.txtCVVNommer.Text = Aftrek.CREDIT_CARD_CVV_NO
                        Me.txtKaartVervaldatum.Text = Aftrek.CREDIT_CARD_EXPIRY_DATE
                        If Persoonl.BET_WYSE = 4 Then
                            Me.lblCreditCardVervalDatum.Enabled = True
                            Me.lblCVVNumber.Enabled = True
                            Me.txtCVVNommer.Enabled = True
                            Me.txtKaartVervaldatum.Enabled = True
                        Else
                            Me.lblCreditCardVervalDatum.Enabled = False
                            Me.lblCVVNumber.Enabled = False
                            Me.txtCVVNommer.Enabled = False
                            Me.txtKaartVervaldatum.Enabled = False
                        End If
                    Else
                        Me.txtCVVNommer.Text = ""
                        Me.txtKaartVervaldatum.Text = ""
                        Me.lblCreditCardVervalDatum.Enabled = True
                        Me.lblCVVNumber.Enabled = True
                        Me.txtCVVNommer.Enabled = True
                        Me.txtKaartVervaldatum.Enabled = True
                    End If
                End If
            Else
                Me.lblCreditCardVervalDatum.Enabled = False
                Me.lblCVVNumber.Enabled = False
                Me.txtCVVNommer.Enabled = False
                Me.txtKaartVervaldatum.Enabled = False
            End If
            blnInformationChanged = False

            If Persoonl.GEKANS Then
                Me.btnOk.Enabled = False
                Me.btnBanke.Enabled = False
            Else
                Me.btnOk.Enabled = True
                Me.btnBanke.Enabled = True
            End If

            If strGebtitel = "Besigtig" Then
                Me.btnOk.Enabled = False
                Me.rdTermynPolis.Enabled = False
            End If
            'rdMndKontant.Checked = True
        End If
        blnformloaded = True
        blnbetWyseLoading = False
    End Sub

    'UPGRADE_WARNING: Event rdMndDebiet.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub rdMndDebiet_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rdMndDebiet.CheckedChanged
        '	If eventSender.Checked Then
        'andriette 23/04/2014 
        If Not (blnLoading Or Not blnformloaded) Then
            blnInformationChanged = True
        End If

        'Enable frames when monthly debit was chosen
        If Not blnbetWyseLoading And Not blnCancelClick Then

            If Me.rdMndDebiet.Checked Then
                enableFrame(True, Me.frameBank.Name)
                enableFrame(True, Me.frameRekening.Name)
                'Andriette 10/04/2014 as die maandelikdebiet gekies is
                ' toets om te kyk of daar 'n bankrekening gelaai is
                'Andriette 
                BWKryAftrekDetail()
                If Not Aftrek Is Nothing Then


                    If Not Aftrek.NoMatch And Aftrek.REK_NO <> "" Then
                        MsgBox("Bank details for this policy already exists. Please verify if it is correct", MsgBoxStyle.Information)
                        getBankDetails((Aftrek.FK_BANKCODE), bankName, branchName, branchCode, accType)
                        Me.txtBank.Text = bankName
                        Me.txtBranch.Text = branchName
                        Me.txtBranchCode.Text = branchCode
                        Me.txtType.Text = accType
                        Me.txtInitials.Text = Aftrek.A_VL & ""
                        Me.txtPkBnkCodes.Text = Aftrek.FK_BANKCODE
                        Me.txtSurname.Text = Aftrek.A_VAN & ""
                        Me.txtAccNumber.Text = Aftrek.REK_NO
                        Me.cmbAccType.SelectedIndex = Aftrek.A_TIPE - 1
                        If Not IsDBNull(Aftrek.CREDIT_CARD_CVV_NO) Or Not IsDBNull(Aftrek.CREDIT_CARD_EXPIRY_DATE) Then
                            Me.txtCVVNommer.Text = Aftrek.CREDIT_CARD_CVV_NO
                            Me.txtKaartVervaldatum.Text = Aftrek.CREDIT_CARD_EXPIRY_DATE
                            txtAccNumber.Focus()
                        End If

                    End If
                End If
                txtBank.Focus()
            Else
                'Andriette 19/02/2014 1.256 As die betaling tipe nie maandeliks debiet is nie vertoon nie die bank detail nie
                enableFrame(False, Me.frameBank.Name)
                enableFrame(False, Me.frameRekening.Name)
                txtAccNumber.Text = ""
                txtBank.Text = ""
                txtBranch.Text = ""
                txtBranchCode.Text = ""
                txtAccNumber.Text = ""
                txtInitials.Text = ""
                txtSurname.Text = ""
                txtCVVNommer.Text = ""
                txtKaartVervaldatum.Text = ""
                cmbAccType.Text = ""
                enableFrame(False, Me.frameBank.Name)
                enableFrame(False, Me.frameRekening.Name)
            End If
            Me.btnOk.Enabled = True
            'End If
        End If

    End Sub

    'UPGRADE_WARNING: Event rdMndElektronies.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub rdMndElektronies_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rdMndElektronies.CheckedChanged
        '	If eventSender.Checked Then
        'andriette 23/04/2014 
        If Not (blnLoading Or Not blnformloaded) Then
            blnInformationChanged = True
        End If
        'Disable frames
        If Me.rdMndElektronies.Checked Then
            enableFrame(False, Me.frameBank.Name)
            enableFrame(False, Me.frameRekening.Name)
        End If
        Me.btnOk.Enabled = True
        'End If
    End Sub

    'UPGRADE_WARNING: Event rdMndKontant.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub rdMndKontant_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rdMndKontant.CheckedChanged
        '	If eventSender.Checked Then
        'andriette 23/04/2014 
        If Not (blnLoading Or Not blnformloaded) Then
            blnInformationChanged = True
        End If
        'Disable frames
        If Me.rdMndKontant.Checked Then
            enableFrame(False, Me.frameBank.Name)
            enableFrame(False, Me.frameRekening.Name)
        End If
        Me.btnOk.Enabled = True
        'End If
    End Sub

    ''UPGRADE_WARNING: Event rdMndSalaris.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub rdMndSalaris_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rdMndSalaris.CheckedChanged
        '	If eventSender.Checked Then
        'andriette 23/04/2014 
        If Not (blnLoading Or Not blnformloaded) Then
            blnInformationChanged = True
        End If
        'Disable frames
        If Me.rdMndSalaris.Checked Then
            enableFrame(False, Me.frameBank.Name)
            enableFrame(False, Me.frameRekening.Name)
        End If
        Me.btnOk.Enabled = True
        'End If
    End Sub


    Private Sub txtAccNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccNumber.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar)) Then
                'do nothing
            Else
                e.Handled = True
                MsgBox("Account number: only numbers are allowed", _
                       MsgBoxStyle.Information, "Verify")
                txtAccNumber.Focus()
            End If
        End If

    End Sub

    Private Sub txtCVVNommer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCVVNommer.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar)) Then
                'do nothing
            Else
                e.Handled = True
                MsgBox("CCV number: only numbers are allowed", _
                       MsgBoxStyle.Information, "Verify")
                txtCVVNommer.Focus()
            End If
        End If

    End Sub

    Private Sub txtAccNumber_Leave(sender As Object, e As System.EventArgs) Handles txtAccNumber.Leave
        If blnInformationChanged Then
            If btnCancel.Focused Then
                If MsgBox("Are you sure you want to cancel your change(s)?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    BWRollbackScreen()

                    Me.Close()
                    Exit Sub                    'Else
                    '    If IsNumeric(txtAccNumber.Text) Then
                    '    Else
                    '        MsgBox("The Account number must be numbers only, Please enter correct Account number", MsgBoxStyle.Information)
                    '        txtAccNumber.Focus()
                    '    End If

                End If

            End If

            If IsNumeric(txtAccNumber.Text) Then
                'andriette 23/04/2014 
                'If Not (Loading Or Not formloaded) Then
                '    InformationChanged = True
                'End If
                ' InformationChanged = True
            Else
                MsgBox("The Account number must be numbers only, Please enter correct Account number", MsgBoxStyle.Information)
                txtAccNumber.Focus()

            End If
        End If

    End Sub

    Private Sub txtAccNumber_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtAccNumber.TextChanged
        'InformationChanged = True
        'andriette 23/04/2014 
        If Not (blnLoading Or Not blnformloaded) Then
            blnInformationChanged = True
        End If
    End Sub

    Private Sub txtBank_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBank.Click
        MsgBox(strmsgBankClicked, MsgBoxStyle.Information)
        btnBanke_Click(btnBanke, New System.EventArgs())
    End Sub

    Private Sub txtBranch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBranch.Click
        MsgBox(strmsgBankClicked, MsgBoxStyle.Information)
        btnBanke_Click(btnBanke, New System.EventArgs())
    End Sub

    Private Sub txtBranchCode_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBranchCode.TextChanged
        'If Not blnbetWyseLoading Then
        '    InformationChanged = True
        'End If
        'andriette 23/04/2014 
        If Not (blnLoading Or Not blnformloaded) Then
            blnInformationChanged = True
        End If
    End Sub

    Private Sub txtBranchCode_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBranchCode.Click
        MsgBox(strmsgBankClicked, MsgBoxStyle.Information)
        btnBanke_Click(btnBanke, New System.EventArgs())
    End Sub
    'Enable/disable selected frame and contents according to settings
    'Andriette 14/08/2014 maak ;n private Sub
    'Public Function enableFrame(ByRef enable As Boolean, ByRef theFrame As String) As Object
    Private Sub enableFrame(ByRef enable As Boolean, ByRef theFrame As String)
        Select Case theFrame
            Case "frameBank"
                Me.frameBank.Enabled = enable
                Me.btnBanke.Enabled = enable
                Me.txtBank.Enabled = enable
                Me.txtBranch.Enabled = enable
                Me.txtBranchCode.Enabled = enable
                Me.lblBank.Enabled = enable
                Me.lblBranch.Enabled = enable
                Me.lblBranchCode.Enabled = enable
            Case "frameRekening"
                Me.frameRekening.Enabled = enable
                Me.txtAccNumber.Enabled = enable
                Me.txtInitials.Enabled = enable
                Me.txtSurname.Enabled = enable
                Me.cmbAccType.Enabled = enable
                Me.lblAccNumber.Enabled = enable
                Me.lblAccType.Enabled = enable
                Me.lblInitials.Enabled = enable
                Me.lblSurname.Enabled = enable
                Me.lblCreditCardVervalDatum.Enabled = enable
                Me.txtKaartVervaldatum.Enabled = enable
                Me.lblCVVNumber.Enabled = enable
                Me.txtCVVNommer.Enabled = enable

                If Me.rdMndDebiet.Checked = True And enable = True Then
                    If Me.cmbAccType.SelectedIndex <> 3 Then
                        Me.lblCreditCardVervalDatum.Enabled = False
                        Me.txtKaartVervaldatum.Enabled = False
                        Me.lblCVVNumber.Enabled = False
                        Me.txtCVVNommer.Enabled = False
                    End If
                End If
        End Select
    End Sub
    'Validate the form for required fields
    Public Function validateForm() As Boolean

        Dim strVervalMaand As String

        'andriette toets om te sien of enige van die betaalwyses gekies is
        If Not rdMndSalaris.Checked And Not rdMndDebiet.Checked And Not rdMndElektronies.Checked And Not rdTermynPolis.Checked And Not rdMndKontant.Checked Then
            MsgBox("The Payment method is required.", MsgBoxStyle.Critical)
            validateForm = False
            Exit Function
        End If

        If Me.frameBank.Enabled Or Me.rdMndDebiet.Checked Then
            If Trim(Me.txtBank.Text) = "" Or Trim(Me.txtBranch.Text) = "" Or Trim(Me.txtBranchCode.Text) = "" Then
                MsgBox("Please complete the bank details.", MsgBoxStyle.Exclamation)
                Me.btnBanke.Focus()
                validateForm = False
                Exit Function
            End If
        End If

        If IsNumeric(Trim(txtInitials.Text)) Then
            MsgBox("The initials must only be letters.", MsgBoxStyle.Exclamation)
            Me.txtInitials.Focus()
            validateForm = False
            Exit Function
        End If
        If Me.frameRekening.Enabled Or Me.rdMndDebiet.Checked Then
            If CBool(Trim(CStr(Me.txtAccNumber.Text = ""))) Then
                MsgBox("Please enter the account number.", MsgBoxStyle.Exclamation)
                Me.txtAccNumber.Focus()
                validateForm = False
                Exit Function
            End If

            If CBool(Trim(CStr(Me.cmbAccType.Text = ""))) Then
                MsgBox("please enter the account type.", MsgBoxStyle.Exclamation)
                Me.cmbAccType.Focus()
                validateForm = False
                Exit Function
            End If

            'When credit account is selected, account type must be credit as well
            If Me.txtType.Text = "Credit card" And Me.cmbAccType.SelectedIndex <> 3 Then
                MsgBox("When a credit card is selected under bank records, the account type must always be Credit ", MsgBoxStyle.Exclamation)
                Me.cmbAccType.Focus()
                validateForm = False
                Exit Function
            End If

            If Me.txtType.Text = "Credit card" And Me.cmbAccType.SelectedIndex = 3 Then
                If Me.txtCVVNommer.Text = "" Then
                    MsgBox("Please enter the credit card cvv number.", MsgBoxStyle.Exclamation)
                    Me.txtCVVNommer.Focus()
                    validateForm = False
                    Exit Function
                End If
                If Not (IsNumeric(Me.txtCVVNommer.Text)) Then
                    MsgBox("Please enter numeric values.", MsgBoxStyle.Exclamation)
                    Me.txtCVVNommer.Focus()
                    validateForm = False
                    Exit Function
                End If
                If Me.txtKaartVervaldatum.Text = "" Then
                    MsgBox("The credit card expiry date is still outstanding, please enter correct date.", MsgBoxStyle.Exclamation)
                    Me.txtKaartVervaldatum.Focus()
                    validateForm = False
                    Exit Function
                End If
                If Not (IsNumeric(Me.txtKaartVervaldatum.Text)) Then
                    MsgBox("The credit card expiry date is invalid, please enter correct date", MsgBoxStyle.Exclamation)
                    Me.txtCVVNommer.Focus()
                    validateForm = False
                    Exit Function
                End If
                If Len(Me.txtCVVNommer.Text) < 3 Then
                    MsgBox("The credit card cvv number must be more than three(3) numbers.", MsgBoxStyle.Exclamation)
                    Me.txtCVVNommer.Focus()
                    validateForm = False
                    Exit Function
                End If
                If Len(Me.txtKaartVervaldatum.Text) < 4 Then
                    MsgBox("The credit card expiry date is not exhaustive.", MsgBoxStyle.Exclamation)
                    Me.txtKaartVervaldatum.Focus()
                    validateForm = False
                    Exit Function
                End If
                If CDbl(VB.Left(Me.txtKaartVervaldatum.Text, 2)) > 99 Then
                    MsgBox("Invalid expiry date.", MsgBoxStyle.Exclamation)
                    Me.txtKaartVervaldatum.Focus()
                    validateForm = False
                    Exit Function
                End If
                If CDbl(VB.Right(Me.txtKaartVervaldatum.Text, 2)) > 12 Then
                    MsgBox("Invalid expiry date.", MsgBoxStyle.Exclamation)
                    Me.txtKaartVervaldatum.Focus()
                    validateForm = False
                    Exit Function
                End If
                If VB.Left(Me.txtKaartVervaldatum.Text, 2) < VB.Right(CStr(Year(Now)), 2) Then
                    MsgBox("The credit card has expired.", MsgBoxStyle.Exclamation)
                    Me.txtKaartVervaldatum.Focus()
                    validateForm = False
                    Exit Function
                End If
                If VB.Left(Me.txtKaartVervaldatum.Text, 2) = VB.Right(CStr(Year(Now)), 2) Then
                    If Month(Now) < 10 Then
                        strVervalMaand = "0" & Month(Now)
                    Else
                        strVervalMaand = CStr(Month(Now))
                    End If
                    If VB.Right(Me.txtKaartVervaldatum.Text, 2) < strVervalMaand Then
                        MsgBox("The credit card expiry date has expired....", MsgBoxStyle.Exclamation)

                        Me.txtKaartVervaldatum.Focus()
                        validateForm = False
                        Exit Function
                    End If
                    If Me.txtType.Text <> "Credit card" And Me.cmbAccType.SelectedIndex = 3 Then
                        MsgBox("The bank records selected does not allow a credit card account, please select other account types", MsgBoxStyle.Exclamation)
                        Me.cmbAccType.Focus()
                        validateForm = False
                        Exit Function
                    End If
                End If
            End If
        End If

        'All is well and validated
        validateForm = True
    End Function
    'Insert the alteration record for betwyse
    'Andriette 14/08/2014 maak ;n sub want dit return niks
    ' Private Function BetWyseAlteration() As Object
    Private Sub BetWyseAlteration()
        'Was on monthly salary - insert alteration
        'If CDbl(previousBetWyse) = 3 Then
        '    UpdateWysig((65), "")
        'End If
        ''Was on monthly debit - insert alteration
        'If CDbl(previousBetWyse) = 4 Then
        '    UpdateWysig((43), "")
        'End If
        If strpreviousBetWyse = "3" Then
            UpdateWysig((65), "")
        End If
        'Was on monthly debit - insert alteration
        If strpreviousBetWyse = "4" Then
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
    'Insert the alteration records for the banking info according to changed items
    'Andriette 14/08/2014 maak ;n private sub want dit return nike
    'Public Function bankingAlteration() As Object
    Private Sub bankingAlteration()
        'Andriette 23/01/2014
        If Not (blnPol_Byvoeg Or blnByvoeg) Then

            'Bank
            If blnPkBnkCodesChanged Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig na (" & (Me.txtBank.Text & " - " & Me.txtBranch.Text) & ")"
                Else
                    BESKRYWING = " change to (" & (Me.txtBank.Text & " - " & Me.txtBranch.Text) & ")"
                End If
                UpdateWysig((26), BESKRYWING)
            End If

            'Surname
            If blnSurnameChanged Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig na (" & (Me.txtSurname).Text & ")"
                Else
                    BESKRYWING = " change to (" & (Me.txtSurname).Text & ")"
                End If
                UpdateWysig((45), BESKRYWING)
            End If

            'Initial
            If blnInitialsChanged Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig voorletters na (" & (Me.txtInitials).Text & ")"
                Else
                    BESKRYWING = " change initials to (" & (Me.txtInitials).Text & ")"
                End If
                UpdateWysig((45), BESKRYWING)
            End If

            'Account number
            If blnAccNumberChanged Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vanaf (" & (strpreviousAccNumber) & ") na (" & (Me.txtAccNumber).Text & ")"
                Else
                    BESKRYWING = " change from (" & (strpreviousAccNumber) & ") to (" & (Me.txtAccNumber).Text & ")"
                End If
                UpdateWysig((46), BESKRYWING)
            End If

            'Account type
            If blnAccTypeChanged Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig na (" & (Me.cmbAccType.Text) & ")"
                Else
                    BESKRYWING = " change to (" & (Me.cmbAccType.Text) & ")"
                End If
                UpdateWysig((47), BESKRYWING)
            End If

            'Credit Card CVV number
            If blnCVVNommerChanged Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " CVV nommer wysig vanaf (" & (strpreviousCVVNumber) & ") na (" & (Me.txtCVVNommer).Text & ")"
                Else
                    BESKRYWING = " CVV number change from (" & (strpreviousCVVNumber) & ") to (" & (Me.txtCVVNommer).Text & ")"
                End If
                UpdateWysig((46), BESKRYWING)
            End If
            'Credit Card CVV number
            If blnKaartVervaldatumChanged Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " Verval datum wysig vanaf (" & (strpreviousCCExpiryDate) & ") na (" & (Me.txtKaartVervaldatum).Text & ")"
                Else
                    BESKRYWING = " Expiry date change from (" & (strpreviousCCExpiryDate) & ") to (" & (Me.txtKaartVervaldatum).Text & ")"
                End If
                UpdateWysig((46), BESKRYWING)
            End If
        End If
    End Sub
    ''Get the bank details according to specified primary key
    Public Sub getBankDetails(ByRef pkBankCodes As String, ByRef bankName As String, ByRef branchName As String, ByRef branchCode As String, ByRef accType As String)

        If Trim(pkBankCodes) = "" Or IsDBNull(pkBankCodes) Then
            bankName = ""
            branchName = ""
            branchCode = ""
            accType = ""
        Else

            'Read data
            Try
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim param As SqlParameter = New SqlParameter("@pkBankCodes", SqlDbType.NVarChar)
                    param.Value = pkBankCodes

                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.BankCodesProc2", param)

                    Dim list As List(Of BankCodes) = New List(Of BankCodes)
                    While reader.Read()

                        If Not IsDBNull(reader("Bank")) Then
                            bankName = reader("Bank")
                        Else
                            bankName = ""
                        End If

                        If Not IsDBNull(reader("Tak")) Then
                            branchName = reader("Tak")
                        Else
                            branchName = ""
                        End If

                        If Not IsDBNull(reader("Takkode")) Then
                            branchCode = reader("Takkode")
                        Else
                            branchCode = ""
                        End If

                        If Not IsDBNull(reader("Type")) Then
                            accType = reader("Type")
                        Else
                            accType = ""
                        End If
                    End While
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)

            End Try
        End If
    End Sub



    Private Sub txtCVVNommer_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCVVNommer.TextChanged
        'If Not blnbetWyseLoading Then
        '    InformationChanged = True
        'End If
        'andriette 23/04/2014 
        If Not (blnLoading Or Not blnformloaded) Then
            blnInformationChanged = True
        End If
    End Sub



    Private Sub txtInitials_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInitials.Leave
        If Not Regex.Match(txtInitials.Text, "^[a-z]*$", RegexOptions.IgnoreCase).Success Then
            MsgBox("Please enter alphabetic text only and no spaces allowed!.", MsgBoxStyle.Information)
            txtInitials.Focus()
        End If

    End Sub

    Private Sub txtInitials_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtInitials.TextChanged
        'If Not blnbetWyseLoading Then
        '    InformationChanged = True
        'End If
        'andriette 23/04/2014 
        If Not (blnLoading Or Not blnformloaded) Then
            blnInformationChanged = True
        End If
    End Sub

    Private Sub txtKaartVervaldatum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtKaartVervaldatum.TextChanged
        'If Not blnbetWyseLoading Then
        '    InformationChanged = True
        'End If
        'andriette 23/04/2014 
        If Not (blnLoading Or Not blnformloaded) Then
            blnInformationChanged = True
        End If
    End Sub

    Private Sub txtSurname_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSurname.TextChanged
        'If Not blnbetWyseLoading Then
        '    InformationChanged = True
        'End If
        'andriette 23/04/2014 
        If Not (blnLoading Or Not blnformloaded) Then
            blnInformationChanged = True
        End If
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        blnCancelClick = True
        If blnInformationChanged Then


            If MsgBox("Are you sure you want to cancel your change(s)?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                BWRollbackScreen()

                Me.Close()
                Exit Sub
            End If
            blnCancelClick = False
        Else
            Me.Close()
        End If

    End Sub

    Private Sub btnBanke_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBanke.Click
        BnkCodes.ShowDialog()
    End Sub

    Private Sub cmbAccType_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAccType.Leave

        If cmbAccType.Text = "Krediet" Or cmbAccType.Text = "Credit" Then
            Me.lblCreditCardVervalDatum.Enabled = True
            Me.lblCVVNumber.Enabled = True
            Me.txtCVVNommer.Enabled = True
            Me.txtKaartVervaldatum.Enabled = True
        Else
            Me.lblCreditCardVervalDatum.Enabled = False
            Me.lblCVVNumber.Enabled = False
            Me.txtCVVNommer.Enabled = False
            Me.txtKaartVervaldatum.Enabled = False
        End If
    End Sub

    Private Sub rdTermynPolis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdTermynPolis.CheckedChanged

        Dim strMessage As String
        'andriette 23/04/2014 
        If Not (blnLoading Or Not blnformloaded) Then
            blnInformationChanged = True
        End If
        '  InformationChanged = True
        'Disable frames
        If Me.rdTermynPolis.Checked Then
            enableFrame(False, Me.frameBank.Name)
            enableFrame(False, Me.frameRekening.Name)

            'Check if the form is loaded AND that this policy wasn't a longterm anyway
            If blnformloaded And (Trim(Persoonl.BET_WYSE) <> "6") Then
                strMessage = " It is imperative that the following steps be taken! " & Chr(13) & Chr(13) & " Existing policies: " & Chr(13) & " 1. Remove any reference on this policy." & Chr(13) & " 2. Remove any additional premium on this policy." & Chr(13) & " 3. Then change the payment method for Term Policy and select the term." & Chr(13) & Chr(13) & " New policies: " & Chr(13) & " 1. Read all the details and components of the policy in full." & Chr(13) & " 2. Then select the payment method and term." & Chr(13) & Chr(13) & Chr(13) & "Is the policy ready to change to a term policy ?"

                If MsgBox(strMessage, MsgBoxStyle.YesNo, "Term Policy - Note") = MsgBoxResult.Yes Then
                    If rdTermynPolis.Checked And CDbl(Val(Form1.Verwysingskommissie.Text)) <> 0 Then
                        MsgBox("Term policies can not enjoy special discounts." & Chr(13) & "Policies with special discount can only be converted to term policies after reference canceled and the Commission came close to.", MsgBoxStyle.Exclamation)
                        Me.btnOk.Enabled = False
                    Else
                        LangtermynTydperk.ShowDialog()
                    End If
                Else
                    Me.btnOk.Enabled = False
                End If
                LangtermynTydperk.Close()
            End If
        End If


    End Sub

    Sub Save(ByVal type As String)

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim item As New BankCodes
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@A_VAN", SqlDbType.NVarChar), _
                                                New SqlParameter("@A_VL", SqlDbType.NVarChar), _
                                                New SqlParameter("@A_TIPE", SqlDbType.NVarChar), _
                                                New SqlParameter("@REK_NO1", SqlDbType.NVarChar), _
                                                New SqlParameter("@fkBankCodes", SqlDbType.Int), _
                                                New SqlParameter("@CreditCardCVVNumber", SqlDbType.NVarChar), _
                                                New SqlParameter("@CreditCardExpiryDate", SqlDbType.NVarChar), _
                                                New SqlParameter("@Type", SqlDbType.NVarChar)}
                'Andriette 16/08/2013 gebruik die global polisnommer
                'params(0).Value = Form1.POLISNO.Text
                params(0).Value = glbPolicyNumber
                params(1).Value = txtSurname.Text
                params(2).Value = txtInitials.Text
                params(3).Value = cmbAccType.SelectedIndex + 1
                params(4).Value = txtAccNumber.Text
                params(5).Value = Aftrek.FK_BANKCODE
                params(6).Value = txtCVVNommer.Text
                params(7).Value = txtKaartVervaldatum.Text
                params(8).Value = type

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateBankDetails", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Sub EditBetwyse(ByVal type As String)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@BET_WYSE", SqlDbType.NVarChar), _
                                                New SqlParameter("@Type", SqlDbType.NVarChar)}
                'Andriette 16/08/2013 gebruik die global polisnommer
                'params(0).Value = Form1.POLISNO.Text
                params(0).Value = glbPolicyNumber
                params(1).Value = Persoonl.BET_WYSE
                params(2).Value = type

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateBetWyse", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    'Private Sub txtAccNumber_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAccNumber.Validating
    '    If Not blnCancelClick Then
    '        If IsNumeric(txtAccNumber.Text) Then
    '            'andriette 23/04/2014 
    '            If Not (Loading Or Not formloaded) Then
    '                InformationChanged = True
    '            End If
    '            ' InformationChanged = True
    '        Else
    '            MsgBox("The Account number must be numbers only, Please enter correct Account number", MsgBoxStyle.Information)
    '            txtAccNumber.Focus()

    '        End If
    '    End If

    'End Sub

    Private Sub txtInitials_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtInitials.Validating
        'If IsNumeric(txtInitials.Text) And (txtInitials.Text.Trim) = " " Then
        '    InformationChanged = False
        '    MsgBox("The Initials must contain Alphabetic Character only without spaces in between", MsgBoxStyle.Information)
        '    txtInitials.Focus()
        'Else
        '    InformationChanged = True
        'End If
    End Sub

    Private Sub rdJrKontant_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.btnOk.Enabled = True
    End Sub
    Private Sub InitBetWyse()
        takdetail = FetchTakForsalaries()
        strmsgBankClicked = "Please use the pre-established list of banks."

        'Populate account type combo box
        cmbAccType.Items.Clear()
        If Persoonl.TAAL = 0 Then
            cmbAccType.Items.Add("Tjek")
            cmbAccType.Items.Add("Spaar")
            cmbAccType.Items.Add("Transmissie")
            cmbAccType.Items.Add("Krediet")
        Else
            cmbAccType.Items.Add("Cheque")
            cmbAccType.Items.Add("Savings")
            cmbAccType.Items.Add("Transmission")
            cmbAccType.Items.Add("Credit")
        End If

        'Andriette 22/04/2014 maak die velde skoon voor jy ingaan
        BWClear_AccountFields()
        BWClear_BankFields()
        'Laai die huidige betaalwyse detail

        blnformloaded = CStr(False)

        'Set message to display when clicked on banking details textboxes
        'Andriette 22/08/2013 disable die opsies wat nie pas by die area nie

        If takdetail.TAKNAAM = "Flagship" Then
            If Persoonl.Area = "2" Then 'PUK onder flagship
                If blnByvoeg Or blnPol_Byvoeg Then
                    rdMndSalaris.Checked = True
                    rdMndSalaris.Refresh()
                End If
                Me.rdMndKontant.Enabled = False
                Me.rdMndDebiet.Enabled = False
                Me.rdMndElektronies.Enabled = False
                Me.rdTermynPolis.Enabled = False
                Me.rdMndSalaris.Enabled = True
                Me.lblCreditCardVervalDatum.Enabled = False
                Me.lblCVVNumber.Enabled = False
                Me.txtCVVNommer.Enabled = False
                Me.txtKaartVervaldatum.Enabled = False
            Else
                If blnByvoeg Or blnPol_Byvoeg Then
                    rdMndElektronies.Checked = True
                    rdMndElektronies.Refresh()
                End If
                Me.rdMndKontant.Enabled = True
                Me.rdMndDebiet.Enabled = True
                Me.rdMndElektronies.Enabled = True
                Me.rdTermynPolis.Enabled = True
                Me.rdMndSalaris.Enabled = False
                Me.lblCreditCardVervalDatum.Enabled = True
                Me.lblCVVNumber.Enabled = True
                Me.txtCVVNommer.Enabled = True
                Me.txtKaartVervaldatum.Enabled = True
            End If
        Else
            Me.rdMndKontant.Enabled = True
            Me.rdMndDebiet.Enabled = True
            Me.rdMndElektronies.Enabled = True
            Me.rdTermynPolis.Enabled = True
            Me.rdMndSalaris.Enabled = True
        End If


        'Select payment advice according to db value set
        ' Andriette 18/06/2013 verander die verskillende radiobuttons om te korrespondeer met poldata1 skerm
        'Andriette 23/04/2014  Skuif na 'n sub vir hergebruik
        BWSetPaymentType()

        'If Persoonl.BET_WYSE <> "" Then
        '    Select Case Persoonl.BET_WYSE
        '        Case "1" 'Monthly cash
        '            Me.rdMndKontant.Checked = True
        '        Case "2"
        '            ' Doen niks want dit bestaan nie meer nie dit was jaarliks kontant
        '        Case "3" 'Monthly salary
        '            Me.rdMndSalaris.Checked = True
        '            If takdetail.TAKNAAM = "Flagship" And Persoonl.Area = "2" Then
        '                Me.rdMndKontant.Enabled = False
        '                Me.rdMndDebiet.Enabled = False
        '                Me.rdMndElektronies.Enabled = False
        '                Me.rdTermynPolis.Enabled = False
        '            End If
        '        Case "4" 'Monthly debit
        '            Me.rdMndDebiet.Checked = True
        '            enableFrame(True, Me.frameBank.Name)
        '            enableFrame(True, Me.frameRekening.Name)

        '        Case "5" 'Monthly electronic
        '            Me.rdMndElektronies.Checked = True
        '        Case "6" 'Term
        '            Me.rdTermynPolis.Checked = True
        '    End Select
        'End If

    End Sub

    Private Sub BWKryAftrekDetail()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                'Andriette 16/08/2013 gebruik die global polisnommer
                'param.Value = Form1.POLISNO.Text
                param.Value = glbPolicyNumber

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAftrek", param)
                Aftrek = New AftrekEntity()
                If reader.Read() Then

                    If reader("A_VAN") IsNot DBNull.Value Then
                        Aftrek.A_VAN = reader("A_VAN")
                    Else
                        Aftrek.A_VAN = ""
                    End If
                    If reader("A_VL") IsNot DBNull.Value Then
                        Aftrek.A_VL = reader("A_VL")
                    Else
                        Aftrek.A_VL = ""
                    End If
                    If reader("A_TIPE") IsNot DBNull.Value Then
                        Aftrek.A_TIPE = reader("A_TIPE")
                    Else
                        Aftrek.A_TIPE = ""
                    End If
                    If reader("A_KODE") IsNot DBNull.Value Then
                        Aftrek.A_KODE = reader("A_KODE")
                    Else
                        Aftrek.A_KODE = ""
                    End If
                    If reader("REK_NO1") IsNot DBNull.Value Then
                        Aftrek.REK_NO1 = reader("REK_NO1")
                    Else
                        Aftrek.REK_NO1 = ""
                    End If
                    If reader("fkBankCodes") IsNot DBNull.Value Then
                        Aftrek.FK_BANKCODE = reader("fkBankCodes")
                    Else
                        Aftrek.FK_BANKCODE = ""
                    End If
                    If reader("CreditCardCVVNumber") IsNot DBNull.Value Then
                        Aftrek.CREDIT_CARD_CVV_NO = reader("CreditCardCVVNumber")
                    Else
                        Aftrek.CREDIT_CARD_CVV_NO = ""
                    End If
                    If reader("CreditCardExpiryDate") IsNot DBNull.Value Then
                        Aftrek.CREDIT_CARD_EXPIRY_DATE = reader("CreditCardExpiryDate")
                    Else
                        Aftrek.CREDIT_CARD_EXPIRY_DATE = ""
                    End If
                    Aftrek.NoMatch = False

                Else
                    Aftrek.NoMatch = True
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try
    End Sub
    'Andriette 22/04/2014 as dit verander moet die rekening nommers ens skoonmaak
    Private Sub txtBank_TextChanged(sender As Object, e As System.EventArgs) Handles txtBank.TextChanged
        If blnformloaded Then
            BWClear_AccountFields()
        End If
    End Sub

    Private Sub BWClear_AccountFields()
        txtAccNumber.Text = ""
        cmbAccType.SelectedIndex = -1
        cmbAccType.Refresh()
        cmbAccType.SelectedText = ""
        txtInitials.Text = ""
        txtSurname.Text = ""
        txtCVVNommer.Text = ""
        txtKaartVervaldatum.Text = ""
    End Sub

    Private Sub BWClear_BankFields()
        txtBank.Text = ""
        txtBranch.Text = ""
        txtBranchCode.Text = ""
    End Sub

    Private Sub BWRollbackScreen()
        Me.txtAccNumber.Text = Aftrek.REK_NO1 & ""
        Me.txtBank.Text = bankName
        Me.txtBranch.Text = branchName
        Me.txtBranchCode.Text = branchCode
        Me.txtType.Text = accType
        Me.txtInitials.Text = Aftrek.A_VL & ""
        Me.txtPkBnkCodes.Text = Aftrek.FK_BANKCODE
        Me.txtSurname.Text = Aftrek.A_VAN & ""
        txtCVVNommer.Text = Aftrek.CREDIT_CARD_CVV_NO
        txtKaartVervaldatum.Text = Aftrek.CREDIT_CARD_EXPIRY_DATE
        cmbAccType.SelectedIndex = Val(Aftrek.A_TIPE) - 1
        BWSetPaymentType()
    End Sub

    Private Sub BWSetPaymentType()
        If Persoonl.BET_WYSE <> "" Then
            Select Case Persoonl.BET_WYSE
                Case "1" 'Monthly cash
                    Me.rdMndKontant.Checked = True
                Case "2"
                    ' Doen niks want dit bestaan nie meer nie dit was jaarliks kontant
                Case "3" 'Monthly salary
                    Me.rdMndSalaris.Checked = True
                    If takdetail.TAKNAAM = "Flagship" And Persoonl.Area = "2" Then
                        Me.rdMndKontant.Enabled = False
                        Me.rdMndDebiet.Enabled = False
                        Me.rdMndElektronies.Enabled = False
                        Me.rdTermynPolis.Enabled = False
                    End If
                Case "4" 'Monthly debit
                    Me.rdMndDebiet.Checked = True
                    enableFrame(True, Me.frameBank.Name)
                    enableFrame(True, Me.frameRekening.Name)

                Case "5" 'Monthly electronic
                    Me.rdMndElektronies.Checked = True
                Case "6" 'Term
                    Me.rdTermynPolis.Checked = True
            End Select
        End If
    End Sub
    'Andriette  16/05/2014 maak al die velde skoon as weer laai

    Private Sub ClearBankDetails()
        txtBank.Text = ""
        txtBranch.Text = ""
        txtBranchCode.Text = ""
        txtAccNumber.Text = ""
        txtInitials.Text = ""
        txtSurname.Text = ""
        txtCVVNommer.Text = ""
        txtKaartVervaldatum.Text = ""
        cmbAccType.SelectedIndex = -1
        cmbAccType.Text = ""



    End Sub
End Class