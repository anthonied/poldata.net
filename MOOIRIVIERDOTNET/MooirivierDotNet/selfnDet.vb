Option Strict Off
Option Explicit On

Imports System.Data.SqlClient
Imports DAL
Friend Class selfoonDetailFrm
    Inherits BaseForm
    'Andriette 01/08/2013 declare en vul die selfoon entity vir latere gebruik 

    Dim SelfoonDetail As New Selfoone
    'Description: Form containing textboxes with detail of cellphone Form working in conjunction with selfoonListFrm
    'On cancel - close form
	Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Sub Clear_Fields()
        Dim blnoldEnabled As Boolean
        cmbPhone_make.Text = ""
        txtPhone_model.Text = ""
        txtSN_no.Text = ""
        TextBox3.Text = ""
        dtpContractDate.Value = Now
        TextBox1.Text = ""
        TextBox2.Text = ""
        cmbStatus.Text = ""
        '     DateTimePicker1.Enabled = False
        '    txtCancel_Comment.Enabled = False
        'Andriette 14/08/2013 default die maak combo na -1
        cmbPhone_make.SelectedIndex = -1
        txtCancel_Comment.Text = ""
        blnoldEnabled = dtpCancellationDate.Enabled
        dtpCancellationDate.Enabled = True
        dtpCancellationDate.Text = CType("01/01/1900", Date)
        dtpCancellationDate.Enabled = blnoldEnabled
        cmbStatus.SelectedText = "Active"

    End Sub
    Public Sub refreshGrid()
        selfoonListFrm.dgvCellDetails.AutoGenerateColumns = False
        selfoonListFrm.dgvCellDetails.DataSource = ListCellphone()
    End Sub

    Private Sub btnHelp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnHelp.Click
        MsgBox("The serial number (IMEI) can be obtained by entering * # 06 # on the cellphone.", MsgBoxStyle.Information)
    End Sub

    Sub Save(ByVal type As String)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim params() As SqlParameter = {New SqlParameter("@pkInsCell", SqlDbType.Int), _
                                                New SqlParameter("@phone_make", SqlDbType.NVarChar), _
                                                New SqlParameter("@phone_model", SqlDbType.NVarChar), _
                                                New SqlParameter("@sn_no", SqlDbType.NVarChar), _
                                                New SqlParameter("@Sel_tel", SqlDbType.NVarChar), _
                                                New SqlParameter("@contract_date", SqlDbType.DateTime), _
                                                New SqlParameter("@phone_price", SqlDbType.Int), _
                                                New SqlParameter("@Premie", SqlDbType.Money), _
                                                New SqlParameter("@status", SqlDbType.NVarChar), _
                                                New SqlParameter("@cancel_date", SqlDbType.DateTime), _
                                                New SqlParameter("@cancel_comment", SqlDbType.NVarChar), _
                                                New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@taknaam", SqlDbType.NVarChar), _
                                                New SqlParameter("@Type", SqlDbType.NVarChar)}

                If selfoonListFrm.blnaddnew = True Then
                    params(0).Value = DBNull.Value
                Else
                    params(0).Value = CInt(selfoonListFrm.dgvCellDetails.SelectedCells.Item(0).Value)
                End If

                params(1).Value = cmbPhone_make.Text
                params(2).Value = txtPhone_model.Text
                params(3).Value = txtSN_no.Text
                params(4).Value = TextBox3.Text
                params(5).Value = Format(dtpContractDate.Value, "dd/MM/yyyy")
                params(6).Value = CInt(TextBox1.Text)
                params(7).Value = CDec(TextBox2.Text)
                'Andriette 23/08/2013 verander die status
                params(8).Value = cmbStatus.Text
                params(9).Value = Format(dtpCancellationDate.Value, "dd/MM/yyyy")
                params(10).Value = txtCancel_Comment.Text
                'Andriette 16/08/2013 gebruik global polisnommer
                'params(11).Value = Form1.POLISNO.Text
                params(11).Value = glbPolicyNumber
                If params(11).Value = Nothing Then
                    MsgBox("Please allocate a policy number for the insured", MsgBoxStyle.Information)
                    Exit Sub
                End If
                params(12).Value = Form1.Taknaam.Capture
                params(13).Value = type
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "insCELL.InsertCellphone", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Public Sub populateDDLMake()

        cmbPhone_make.ValueMember = "ComboBoxID"
        cmbPhone_make.DisplayMember = "ComboBoxName"
        cmbPhone_make.DataSource = FillCombo("insCELL.FetchInsCellMake", "pkInsCell_CellMake", "cellmake", "", "", "@Status", , "SqlDbType.NVarChar", "Active")
    End Sub
    'Ok button clicked - add\update record in database
    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
        Dim dblSelfoonpremie As Double
        If validateFields() Then
            Save("Add/Edit")
            dblSelfoonpremie = (cellphoneGetTotalPremium(glbPolicyNumber))
            Form1.btnSelfoonPremie.Text = FormatNumber(dblSelfoonpremie, 2)
            UpdatePersoonlPerField("selfoon", dblSelfoonpremie)
            enableDetail(False)
            'Andriette 14/03/2014 moenie wysiging skryf as die nog in byvoeg mode is nie
            If Not blnByvoeg Or blnPol_Byvoeg Then
                If selfoonListFrm.blnaddnew = True Then
                    logCellphoneAlteration("Addnew")
                Else
                    CheckChanges()
                End If
            End If
            'Andriette 01/08/2013 het die funksie na ;n private toe verander roep dus met formnaam
            selfoonListFrm.RefreshGrid()

            Me.Close()
        End If
    End Sub

    'Set values according to status selected
    'UPGRADE_WARNING: Event cmbStatus.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub cmbStatus_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbStatus.SelectedIndexChanged
        If selfoonListFrm.blnaddnew = False And Not blnLoading Then
            Select Case Me.cmbStatus.Text
                Case "Active"
                    Me.txtCancel_Comment.Text = ""
                    dtpCancellationDate.Value = "01/01/1900"
                    Me.txtCancel_Comment.Enabled = False
                    dtpCancellationDate.Enabled = False
                    Me.txtStatus.Text = "A"
                    enableDetail(True)
                Case "Cancelled"
                    enableDetail(False)
                    Me.txtStatus.Text = "C"
                    Me.txtCancel_Comment.Enabled = True
                    Me.txtCancel_date.Enabled = True
                    dtpCancellationDate.Value = Format(Now(), "dd/MM/yyyy")
                    dtpCancellationDate.Enabled = True

            End Select

            'If cmbStatus.Text <> SelfoonDetail.Status Then
            '    logCellphoneAlteration("Status")
            'End If
        End If
    End Sub

    'Onload - get data for selected selfoon
    Private Sub selfoonDetailFrm_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Andriette 23/08/2013 doen net die populate as 'n nuwe selfoon
        If selfoonListFrm.blnaddnew = True Then
            populateDDLMake()
        End If
        Clear_Fields()
        blnLoading = True
        'Andriette 01/08/2013 skep en populate die entity sodat daar vergelyk kan word om te sien of die logbare velde verander het
        'Populate controls with recordset data
        SelfoonDetail.Make = ""
        SelfoonDetail.Model = ""
        SelfoonDetail.Kontrak = ""
        SelfoonDetail.Nommer = ""
        SelfoonDetail.SerialNo = ""
        SelfoonDetail.Waarde = FormatNumber("0.00", 2)
        SelfoonDetail.Premie = FormatNumber("0.00", 2)
        SelfoonDetail.Status = ""
        SelfoonDetail.Kanselleer = ""
        SelfoonDetail.Rede = ""
        'Andriette 07/08/2013 Default na ongekies
        cmbStatus.SelectedIndex = -1
        If selfoonListFrm.blnaddnew = False Then
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim param As New SqlParameter("@pkInsCell", SqlDbType.Int)
                param.Value = CInt(selfoonListFrm.dgvCellDetails.SelectedCells.Item(0).Value)

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[insCELL].[InsCell_DetailsByPrimaryKey]", param)

                If reader.Read() Then
                    'Andriette 01/08/2013 vul die entity met die waardes om beginwaardes te kry

                    If Not IsDBNull(reader("Maak")) Then
                        SelfoonDetail.Make = reader("Maak")
                    Else
                        SelfoonDetail.Make = ""
                    End If
                    If Not IsDBNull(reader("Model")) Then
                        SelfoonDetail.Model = reader("Model")
                    Else
                        SelfoonDetail.Model = ""
                    End If
                    If Not IsDBNull(reader("SerieNo")) Then
                        SelfoonDetail.SerialNo = reader("SerieNo")
                    Else
                        SelfoonDetail.SerialNo = ""
                    End If
                    If Not IsDBNull(reader("Sel_tel")) Then
                        SelfoonDetail.Nommer = reader("Sel_tel")
                    Else
                        SelfoonDetail.Nommer = ""
                    End If
                    If Not IsDBNull(reader("Kotrak")) Then
                        SelfoonDetail.Kontrak = reader("Kotrak")
                    Else
                        SelfoonDetail.Kontrak = ""
                    End If
                    If Not IsDBNull(reader("Waarde")) Then
                        SelfoonDetail.Waarde = reader("Waarde")
                    Else
                        SelfoonDetail.Waarde = "0"
                    End If
                    'Andriette 01/08/2013 formatering regmaak
                    If Not IsDBNull(reader("Premie")) Then
                        SelfoonDetail.Premie = FormatNumber(reader("Premie"), 2)
                    Else
                        SelfoonDetail.Premie = "0.00"
                    End If
                    If Not IsDBNull(reader("status")) Then
                        SelfoonDetail.Status = reader("status")
                    Else
                        SelfoonDetail.Status = ""
                    End If
                    If Not IsDBNull(reader("Kanselleer")) Then
                        SelfoonDetail.Kanselleer = reader("Kanselleer")
                    Else
                        SelfoonDetail.Kanselleer = ""
                    End If
                    If Not IsDBNull(reader("Rede")) Then
                        SelfoonDetail.Rede = reader("Rede")
                    Else
                        SelfoonDetail.Rede = ""
                    End If
                    'Andriette 01/08/2013 Vul velde met waardes soos uit die entity
                    cmbPhone_make.Text = SelfoonDetail.Make
                    txtPhone_model.Text = SelfoonDetail.Model
                    txtSN_no.Text = SelfoonDetail.SerialNo
                    TextBox3.Text = SelfoonDetail.Nommer
                    dtpContractDate.Text = SelfoonDetail.Kontrak
                    TextBox1.Text = SelfoonDetail.Waarde
                    TextBox2.Text = SelfoonDetail.Premie
                    cmbStatus.Text = SelfoonDetail.Status
                    dtpCancellationDate.Text = SelfoonDetail.Kanselleer
                    txtCancel_Comment.Text = SelfoonDetail.Rede
                    ' cmbPhone_make.SelectedItem = SelfoonDetail.Make
                    'Andriette 21/08/2013 maak veld toe wat nie geedit moet word nie
                    'cmbPhone_make.Enabled = False
                    'txtPhone_model.Enabled = False
                    'txtSN_no.Enabled = False
                    'DateTimePicker1.Enabled = False
                    'TextBox3.Enabled = False
                    'TextBox1.Enabled = True
                    'TextBox2.Enabled = True
                    'enableDetail(False)
                    'TextBox1.Enabled = True
                    'TextBox2.Enabled = True
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

            Select Case cmbStatus.Text

                Case "A"
                    Me.cmbStatus.Text = "Active"
                    Me.txtCancel_Comment.Enabled = False
                    dtpCancellationDate.Text = CType("01/01/1900", Date)
                    dtpCancellationDate.Enabled = False
                    '     enableDetail(True)
                    'Andriette 01/08/2013 maak die vervaardiger onveranderbaar
                    cmbPhone_make.Enabled = False
                    enableDetail(False)
                    TextBox1.Enabled = True
                    TextBox2.Enabled = True
                    cmbStatus.Enabled = True
                Case "C"
                    Me.cmbStatus.Text = "Cancelled"
                    Me.txtCancel_Comment.Enabled = True
                    dtpCancellationDate.Enabled = True
                    enableDetail(False)
                    'Andriette 23/08/2013 disable die status as gekanseleer
                    cmbStatus.Enabled = False
                    txtCancel_Comment.Enabled = False
                    txtCancel_date.Enabled = False
                    dtpCancellationDate.Enabled = False
            End Select
            Me.Refresh()
        Else
            'Add new
            Me.txtStatus.Text = "A"
            Me.cmbStatus.Text = "Active"
            '   DateTimePicker2.Value = "01/01/1900"
            Me.txtCancel_Comment.Enabled = False
            dtpCancellationDate.Enabled = False
            enableDetail(True)
            'cmbStatus.SelectedIndex = -1
            'cmbStatus.SelectedValue = ""
            cmbStatus.SelectedIndex = 0

        End If

        'Populate the ddl phone_make with distinct phone_make values
        blnLoading = False
    End Sub

    'Log an alteration on a cellphone
    Public Sub logCellphoneAlteration(ByRef alt_type As String)
        'Log alterations on premium, status and when new cellphone was added
        '     Dim selfoondetail As New Cellphone
        Dim strStatusBeskrOUd As String = ""
        Dim strStatusBeskrNuut As String = ""
        Dim strOuStatus As String = ""
        Dim strNuweStatus As String = ""
        Select Case alt_type
            Case "Premium"
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig premie vanaf (" & CStr(selfoondetail.Premie) & ") na (" & (Me.TextBox2).Text & ") op selfoon: " & Me.cmbPhone_make.Text & " " & Me.txtPhone_model.Text & " " & Me.txtSN_no.Text
                Else
                    BESKRYWING = " change premium from (" & CStr(selfoondetail.Premie) & ") to (" & (Me.TextBox2).Text & ") on cellphone: " & Me.cmbPhone_make.Text & " " & Me.txtPhone_model.Text & " " & Me.txtSN_no.Text
                End If
                'Andriette verander die tipes veranderinge om inskrywings te reguleer
            Case "Activated"
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = "Aktiveer die selfoon: " & Me.cmbPhone_make.Text & " " & Me.txtPhone_model.Text & " " & Me.txtSN_no.Text & " - " & Me.txtCancel_Comment.Text
                Else
                    BESKRYWING = "Activate the cellphone: " & Me.cmbPhone_make.Text & " " & Me.txtPhone_model.Text & " " & Me.txtSN_no.Text & " - " & Me.txtCancel_Comment.Text
                End If
            Case "Cancelled"
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = "Kanselleer die selfoon: " & Me.cmbPhone_make.Text & " " & Me.txtPhone_model.Text & " " & Me.txtSN_no.Text & " - " & Me.txtCancel_Comment.Text
                Else
                    BESKRYWING = "Cancel the cellphone: " & Me.cmbPhone_make.Text & " " & Me.txtPhone_model.Text & " " & Me.txtSN_no.Text & " - " & Me.txtCancel_Comment.Text
                End If

                'Case "Status"
                '    strOuStatus = SelfoonDetail.Status
                '    strNuweStatus = txtStatus.Text
                '    If Persoonl.TAAL = 0 Then
                '        Select Case strNuweStatus
                '            Case "A"
                '                strStatusBeskrNuut = "Aktief"
                '            Case "C"
                '                strStatusBeskrNuut = "Gekanselleer"
                '        End Select
                '        Select Case strOuStatus
                '            Case "A"
                '                strStatusBeskrOUd = "Aktief"
                '            Case "C"
                '                strStatusBeskrOUd = "Gekanseleer"

                '        End Select
                '        BESKRYWING = " wysig status vanaf (" & strStatusBeskrOUd & ") na (" & strStatusBeskrNuut & ") op selfoon: " & Me.cmbPhone_make.Text & " " & Me.txtPhone_model.Text & " " & Me.txtSN_no.Text & " - " & Me.txtCancel_Comment.Text
                '    Else
                '        Select Case strNuweStatus
                '            Case "A"
                '                strStatusBeskrNuut = "Active"
                '            Case "C"
                '                strStatusBeskrNuut = "Cancelled"
                '        End Select

                '        Select Case strOuStatus
                '            Case "A"
                '                strStatusBeskrOUd = "Active"
                '            Case "C"
                '                strStatusBeskrOUd = "Cancelled"

                '        End Select
                '        BESKRYWING = " change status from (" & strStatusBeskrOUd & ") to (" & strStatusBeskrNuut & ") on cellphone: " & Me.cmbPhone_make.Text & " " & Me.txtPhone_model.Text & " " & Me.txtSN_no.Text & " - " & Me.txtCancel_Comment.Text
                '    End If
            Case "PhonePrice"
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig waarde vanaf (" & CStr(selfoondetail.Waarde) & ") na (" & (Me.TextBox1).Text & ") op selfoon: " & Me.cmbPhone_make.Text & " " & Me.txtPhone_model.Text & " " & Me.txtSN_no.Text
                Else
                    BESKRYWING = " change value from (" & CStr(selfoondetail.Waarde) & ") to (" & (Me.TextBox1).Text & ") on cellphone: " & Me.cmbPhone_make.Text & " " & Me.txtPhone_model.Text & " " & Me.txtSN_no.Text
                End If
            Case "Model"
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig model vanaf (" & CStr(selfoondetail.Model) & ") na (" & (Me.txtPhone_model).Text & ") op selfoon: " & Me.cmbPhone_make.Text & " " & Me.txtSN_no.Text
                Else
                    BESKRYWING = " change model from (" & CStr(selfoondetail.Model) & ") to (" & (Me.txtPhone_model).Text & ") on cellphone: " & Me.cmbPhone_make.Text & " " & Me.txtSN_no.Text
                End If
                'Andriette 02/08/2013 voeg die maak by
            Case "Make"
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig vervaardiger vanaf (" & CStr(SelfoonDetail.Make) & ") na (" & Me.cmbPhone_make.Text & ") op selfoon: " & Me.cmbPhone_make.Text & " " & Me.txtSN_no.Text
                Else
                    BESKRYWING = " change Manufacturer from (" & CStr(SelfoonDetail.Make) & ") to (" & Me.cmbPhone_make.Text & ") on cellphone: " & Me.cmbPhone_make.Text & " " & Me.txtSN_no.Text
                End If
            Case "Addnew"
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " voeg selfoon by: " & Me.cmbPhone_make.Text & " " & Me.txtPhone_model.Text & " " & Me.txtCellular_Number.Text & " " & Me.txtSN_no.Text
                Else
                    BESKRYWING = " add cellphone: " & Me.cmbPhone_make.Text & " " & Me.txtPhone_model.Text & " " & Me.txtCellular_Number.Text & " " & Me.txtSN_no.Text
                End If
            Case "SNNO"
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig IMEI no. vanaf (" & CStr(selfoondetail.SerialNo) & ") na (" & (Me.txtSN_no).Text & ") op selfoon: " & Me.cmbPhone_make.Text & " " & Me.txtSN_no.Text
                Else
                    BESKRYWING = " change IMEI nr from (" & CStr(selfoondetail.SerialNo) & ") to (" & (Me.txtSN_no).Text & ") on cellphone: " & Me.cmbPhone_make.Text & " " & Me.txtSN_no.Text
                End If
                'Andriette 02/08/2013 voeg velde by
            Case "KontrakDatum"
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig Kontrakdatum vanaf (" & CStr(SelfoonDetail.Kontrak) & ") na (" & dtpContractDate.Text & ") op selfoon: " & Me.cmbPhone_make.Text & " " & Me.txtSN_no.Text
                Else
                    BESKRYWING = " change Contract Date from (" & CStr(SelfoonDetail.Kontrak) & ") to (" & dtpContractDate.Text & ") on cellphone: " & Me.cmbPhone_make.Text & " " & Me.txtSN_no.Text
                End If
            Case "Nommer"
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig Selfoonnommer vanaf (" & CStr(SelfoonDetail.Nommer) & ") na (" & TextBox3.Text & ") op selfoon: " & Me.cmbPhone_make.Text & " " & Me.txtSN_no.Text
                Else
                    BESKRYWING = " change Cellphone number from (" & CStr(SelfoonDetail.Nommer) & ") to (" & TextBox3.Text & ") on cellphone: " & Me.cmbPhone_make.Text & " " & Me.txtSN_no.Text
                End If
            Case "KanseleerDatum"
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig Kansellasie datum vanaf (" & CStr(SelfoonDetail.Kanselleer) & ") na (" & dtpCancellationDate.Text & ") op selfoon: " & Me.cmbPhone_make.Text & " " & Me.txtSN_no.Text
                Else
                    BESKRYWING = " change Cancellation date from (" & CStr(SelfoonDetail.Kanselleer) & ") to (" & dtpCancellationDate.Text & ") on cellphone: " & Me.cmbPhone_make.Text & " " & Me.txtSN_no.Text
                End If
            Case "Rede"
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig Kansellasie rede vanaf (" & CStr(SelfoonDetail.Rede) & ") na (" & txtCancel_Comment.Text & ") op selfoon: " & Me.cmbPhone_make.Text & " " & Me.txtSN_no.Text
                Else
                    BESKRYWING = " change Cancellation reason from (" & CStr(SelfoonDetail.Rede) & ") to (" & txtCancel_Comment.Text & ") on cellphone: " & Me.cmbPhone_make.Text & " " & Me.txtSN_no.Text
                End If
        End Select
        UpdateWysig((122), BESKRYWING)
    End Sub

    'Check the fields for validity (mandatory fields etc.)
    Public Function validateFields() As Boolean
        Dim intYear As Integer

        'Check cellphone make
        If Me.cmbPhone_make.Text = "" Then
            MsgBox("Please enter mandatory fields.", MsgBoxStyle.Exclamation, "Poldata")
            validateFields = False
            Me.cmbPhone_make.Focus()
            Exit Function
        End If

        'Check cellphone model
        If Me.txtPhone_model.Text = "" Then
            MsgBox("Please complete the phone model.", MsgBoxStyle.Exclamation, "Poldata")
            validateFields = False
            Me.txtPhone_model.Focus()
            Exit Function
        End If

        'Check cellphone serial number
        If Me.txtSN_no.Text = "" Then
            MsgBox("Please enter the serial number (IMEI)." & Chr(13) & "This number can be obtained by entering *#06# on the cellphone.", MsgBoxStyle.Exclamation, "Poldata")
            validateFields = False
            Me.txtSN_no.Focus()
            Exit Function
        Else
            If Len(Me.txtSN_no.Text) < 15 Then
                MsgBox("The serial number (IMEI) should be 15 characters long.", MsgBoxStyle.Exclamation)
                validateFields = False
                Me.txtSN_no.Focus()
                Exit Function
            End If
        End If

        'Check cellphone contract date not to be empty
        'If Me.txtContract_date.Text = "__/__/____" Then
        '    MsgBox("Please complete the contract date.", MsgBoxStyle.Exclamation, "Poldata")
        '    validateFields = False
        '    Me.txtContract_date.Focus()
        '    Exit Function
        'End If

        'Check cellphone contract date to be valid date
        'If Not IsDate(Me.txtContract_date.Text) Then
        '    MsgBox("Please enter a correct contract date.", MsgBoxStyle.Exclamation, "Poldata")
        '    validateFields = False
        '    Me.txtContract_date.Focus()
        '    Exit Function
        'End If

        'Check cellphone price
        If IsNumeric(Me.TextBox2.Text) Then
            If Me.TextBox2.Text = "" Then
                MsgBox("Please fill in the value of the phone.", MsgBoxStyle.Exclamation, "Poldata")
                validateFields = False
                Me.TextBox2.Focus()
                Exit Function
            End If

            If Val(Me.TextBox2.Text) > 32000 Then
                MsgBox("The value of the phone can not exceed R32000.", MsgBoxStyle.Exclamation, "Poldata")
                validateFields = False
                Me.TextBox2.Focus()
                Exit Function
            End If
        Else
            MsgBox("The value must be numeric.", MsgBoxStyle.Exclamation, "Poldata")
        End If

        If IsNumeric(Me.TextBox3.Text) Then
            If Trim(Me.TextBox3.Text) = "" Then
                MsgBox("Please enter the phone number.", MsgBoxStyle.Exclamation, "Poldata")
                validateFields = False
                Me.TextBox3.Focus()
                Exit Function
            End If
            If Len(Trim(Me.TextBox3.Text)) <> 10 Then
                MsgBox("Please enter the complete phone number.", MsgBoxStyle.Exclamation, "Poldata")
                validateFields = False
                Me.TextBox3.Focus()
                Exit Function
            End If
        Else
            MsgBox("The phone number must be numeric.", MsgBoxStyle.Exclamation, "Poldata")
            validateFields = False
            Me.TextBox3.Focus()
            Exit Function
        End If

        'Check cellphone premium
        If IsNumeric(Me.TextBox1.Text) Then
            If Me.TextBox1.Text = "" Then
                MsgBox("Please enter the premium.", MsgBoxStyle.Exclamation, "Poldata")
                validateFields = False
                Me.TextBox1.Focus()
                Exit Function
            End If

        Else
            MsgBox("The premium must be numeric.", MsgBoxStyle.Exclamation, "Poldata")
        End If

        'When cellphone cancelled - check for reason of cancellation and date
        If Me.txtStatus.Text = "C" Then
            'If Me.txtCancel_date.Text = "__/__/____" Then
            '    MsgBox("Please complete the return date.", MsgBoxStyle.Exclamation, "Poldata")
            '    validateFields = False
            '    Me.txtCancel_date.Focus()
            '    Exit Function
            'End If

            'If Not IsDate(Me.txtCancel_date.Text) Then
            '    MsgBox("Please enter a correct return date.", MsgBoxStyle.Exclamation, "Poldata")
            '    validateFields = False
            '    Me.txtCancel_date.Focus()
            '    Exit Function
            'End If

            If Me.txtCancel_Comment.Text = "" Then
                MsgBox("Please provide a reason for cancellation.", MsgBoxStyle.Exclamation, "Poldata")
                Me.txtCancel_Comment.Focus()
                Exit Function
            End If
        End If

        ''Check for correct contract date
        'If Me.txtContract_date.Text <> "01/01/1900" Then
        '    intYear = Year(CDate(Me.txtContract_date.Text))
        '    If intYear < 1985 Or intYear > (Year(Now) + 1) Then

        '        MsgBox("Please ensure that the correct contract date is entered.", MsgBoxStyle.Exclamation, "Poldata")
        '        If Me.txtContract_date.Enabled = True Then
        '            Me.txtContract_date.Focus()
        '        End If
        '        validateFields = False
        '        Exit Function
        '    End If
        'End If

        'Check for correct cancellation date
        If Me.dtpCancellationDate.Value <> "01/01/1900" Then
            intYear = Year(CDate(Me.dtpCancellationDate.Value))
            If intYear < 1985 Or intYear > (Year(Now) + 1) Then
                MsgBox("Please ensure that the correct cancellation date is entered.", MsgBoxStyle.Exclamation, "Poldata")
                If Me.dtpCancellationDate.Enabled = True Then
                    Me.dtpCancellationDate.Focus()
                End If
                validateFields = False
                Exit Function
            End If
        End If

        'Field Check OK - return true
        validateFields = True
    End Function

    'Enable or disable cellphone detail fields according to argument set
    'UPGRADE_NOTE: enabled was upgraded to enabled_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Public Sub enableDetail(ByRef enabled_Renamed As Boolean)
        Me.cmbPhone_make.Enabled = enabled_Renamed
        Me.txtPhone_model.Enabled = enabled_Renamed
        Me.dtpContractDate.Enabled = enabled_Renamed
        Me.TextBox3.Enabled = enabled_Renamed
        Me.TextBox1.Enabled = enabled_Renamed
        Me.TextBox2.Enabled = enabled_Renamed
        Me.txtSN_no.Enabled = enabled_Renamed
        '     selfoonListFrm.btnEdit.Enabled = enabled_Renamed
        '    selfoonListFrm.btnKanselleer.Enabled = enabled_Renamed
    End Sub


    Private Sub CheckChanges()
        'Andriette 23/08/2013 toets teen dieselfde 
        If txtPhone_model.Text.ToUpper <> SelfoonDetail.Model.ToUpper Then
            logCellphoneAlteration("Model")
        End If
        If cmbPhone_make.Text.ToUpper <> SelfoonDetail.Make.ToUpper Then
            logCellphoneAlteration("Make")
        End If
        If txtSN_no.Text <> SelfoonDetail.SerialNo Then
            logCellphoneAlteration("SNNO")
        End If
        If TextBox2.Text <> SelfoonDetail.Premie Then
            logCellphoneAlteration("Premium")
        End If
        If TextBox1.Text <> SelfoonDetail.Waarde Then
            logCellphoneAlteration("PhonePrice")
        End If
        'Andriette 20/08/2013 as die status na gekanseleer verander het moenie die rede en datum appart inskryf nie
        If SelfoonDetail.Status = "A" And txtStatus.Text.Trim = "C" Then
            logCellphoneAlteration("Cancelled")
        Else
            If SelfoonDetail.Status = "C" And txtStatus.Text.Trim = "A" Then
                logCellphoneAlteration("Activated")
            End If
        End If
        If TextBox3.Text <> SelfoonDetail.Nommer Then
            logCellphoneAlteration("Nommer")
        End If
        If dtpContractDate.Text <> SelfoonDetail.Kontrak Then
            logCellphoneAlteration("KontrakDatum")
        End If
        If dtpCancellationDate.Text <> SelfoonDetail.Kanselleer And cmbStatus.Text.Substring(0, 1) = SelfoonDetail.Status Then
            logCellphoneAlteration("KanseleerDatum")
        End If
        If txtCancel_Comment.Text <> SelfoonDetail.Rede And cmbStatus.Text.Substring(0, 1) = SelfoonDetail.Status Then
            logCellphoneAlteration("Rede")
        End If
    End Sub

End Class