Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Data.SqlClient
Imports DAL

Friend Class VerwysdesDetailFrm
    Inherits BaseForm
    Dim strEndofThisMonth As String
    Dim strStartofThisMonth As String
    Dim blnInformationChanged As Boolean
    Dim strtype As String
    'Andriette 18/06/2014 oorbodig haal uit
    ' Dim PolisnoFetch As Boolean
    Dim Verwysdes As New VerwysdesEntity
    Dim dteDatumbegin As Date
    Dim dteDatumeindig As Date


    Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        If blnInformationChanged Then
            If MsgBox("Are you sure you want to lose your change(s)?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If

    End Sub


    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOK.Click
        'Dim rs2 As DAO.Recordset
        '   Dim dteOuDatumBegin As Date
        '    Dim dteOuDatumEindig As Date
        Dim dteOuStatus As Object
        '    Dim dteNuweDatumbegin As Date
        '    Dim dteNuweDatumeindig As Date
        dteOuStatus = 0
        'Validate fields
        SkakelDatumOm()
        If validateFields() Then

            If Me.ChkForAdd.Checked = True Then

                ' InsertVerwysdes()
                Me.Close()
            Else
                'Andriette 27/05/2014 gebruik uit die entity uit
                'Using conn As SqlConnection = SqlHelper.GetConnection

                '    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchVerwysdesByOne_One]")
                '    While reader.Read

                '        dteOuDatumBegin = CDate(reader("DatumBegin"))
                '        dteOuDatumEindig = CDate(reader("DatumEindig"))
                '        dteOuStatus = reader("Status")

                '    End While
                'End Using

                ''Insert alteration log if verwysde was added
                If VerwysdesListFrm.dgvVerwysdes.Text = "pkVerwysdes" Then
                    logVerwysdesAlteration("Addnew", " ", "")
                Else
                    If Verwysdes.DatumBegin <> dteDatumbegin Then
                        logVerwysdesAlteration("DatumBegin", Verwysdes.DatumBegin, dteDatumbegin)
                    End If

                    'Insert alteration log if Datum eindig has changed
                    If Verwysdes.DatumEindig <> dteDatumeindig Then
                        logVerwysdesAlteration("DatumEindig", Verwysdes.DatumEindig, dteDatumeindig)
                    End If

                    'Insert alteration log if status has changed
                    'If Verwysdes.Status <> Me.txtStatus.Text Then
                    '    logVerwysdesAlteration("Status", Verwysdes.Status, txtStatus.Text)
                    'End If
                    Verwysdes.DatumBegin = dteDatumbegin
                    Verwysdes.DatumEindig = dteDatumeindig
                    UpdateVerwysdes(dteDatumbegin, dteDatumeindig, "Active")
                    '   Verwysdes.Status = txtStatus.Text
                End If

                'Update verwysde with verwysdeur
                '      UpdateVerwysdes(dteDatumbegin, dteDatumeindig, txtStatus.Text)
                UpdateVerwysdeWithVerwysdeur((Me.lblVerwysde.Text))

                VerwysdesListFrm.PopulateGridVerwysdes()

                Me.Close()
            End If
            Me.ChkForAdd.Checked = False
            VerwysdesListFrm.dgvVerwysdes.ReadOnly = True
            VerwysdesListFrm.PopulateGridVerwysdes()

        End If 'validateFields
    End Sub

    Private Sub btnSoekVersekerde_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        VersekerdeSoek.ShowDialog()
    End Sub

    Private Sub dtpDatumToegevoer_CallbackKeyDown(ByVal KeyCode As Short, ByVal Shift As Short, ByVal CallbackField As String, ByRef CallbackDate As Date)

    End Sub

    Private Sub dtpDatumBegin_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        blnInformationChanged = True

        ''Ensure start of the month day is presented on datepicker
        'strStartofThisMonth = "01" & "/" & Mid(Me.dtpDatumBegin.Value, 4, 7)
        'Me.dtpDatumEindig.CustomFormat = VB.Day(CDate(strStartofThisMonth)) & "/MM/yyyy"

    End Sub

    Private Sub dtpDatumEindig_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        blnInformationChanged = True

        'Ensure end of the month day is presented on datepicker
        'strEndofThisMonth = "01" & "/" & Mid(Me.dtpDatumEindig.Value, 4, 7)
        'strEndofThisMonth = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, CDate(strEndofThisMonth)))
        'strEndofThisMonth = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, CDate(strEndofThisMonth)))
        'Me.dtpDatumEindig.CustomFormat = VB.Day(CDate(strEndofThisMonth)) & "/MM/yyyy"

    End Sub

    Private Sub VerwysdesDetailFrm_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim strMaande(12, 2) As String
        Dim intEindmaand As Integer
        Dim intEindJaar As Integer
        Dim intjaartel As Integer = 0
        Dim intmaandtel As Integer = 1
        Dim dteTelDatum As Date

        Verwysdes.DatumBegin = VerwysdesListFrm.dgvVerwysdes.SelectedRows(0).Cells(4).Value
        Verwysdes.DatumEindig = VerwysdesListFrm.dgvVerwysdes.SelectedRows(0).Cells(5).Value
        intEindJaar = Verwysdes.DatumEindig.Year
        intEindmaand = Verwysdes.DatumEindig.Month

        intmaandtel = Verwysdes.DatumBegin.Month
        intjaartel = Verwysdes.DatumBegin.Year
        ' Andriette 12/06/2013 verander die bewoording
        Me.Text = My.Application.Info.Title & " - Referral detail"

        blnInformationChanged = False
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
        'andriette 24/06/2013 default na gelang van die button gebruik
        cmbDatumBegin.Items.Clear()
        cmbDatumEindig.Items.Clear()
        dteTelDatum = Verwysdes.DatumBegin
        intmaandtel = Verwysdes.DatumBegin.Month
        intjaartel = Verwysdes.DatumBegin.Year

        Do Until intmaandtel = intEindmaand And intjaartel = intEindJaar
            If Persoonl.TAAL = 0 Then ' Afrikaans
                cmbDatumBegin.Items.Add(strMaande(dteTelDatum.Month - 1, 1) + " " + dteTelDatum.Year.ToString)
                cmbDatumEindig.Items.Add(strMaande(dteTelDatum.Month - 1, 1) + " " + dteTelDatum.Year.ToString)
            ElseIf Persoonl.TAAL = 1 Then ' Engels
                cmbDatumBegin.Items.Add(strMaande(dteTelDatum.Month - 1, 2) + " " + dteTelDatum.Year.ToString)
                cmbDatumEindig.Items.Add(strMaande(dteTelDatum.Month - 1, 2) + " " + dteTelDatum.Year.ToString)
            End If
            dteTelDatum = dteTelDatum.AddMonths(1)

            intmaandtel = dteTelDatum.Month
            intjaartel = dteTelDatum.Year
        Loop
        'laaste een ook bysit
        If Persoonl.TAAL = 0 Then ' Afrikaans
            cmbDatumBegin.Items.Add(strMaande(dteTelDatum.Month - 1, 1) + " " + dteTelDatum.Year.ToString)
            cmbDatumEindig.Items.Add(strMaande(dteTelDatum.Month - 1, 1) + " " + dteTelDatum.Year.ToString)
        ElseIf Persoonl.TAAL = 1 Then ' Engels
            cmbDatumBegin.Items.Add(strMaande(dteTelDatum.Month - 1, 2) + " " + dteTelDatum.Year.ToString)
            cmbDatumEindig.Items.Add(strMaande(dteTelDatum.Month - 1, 2) + " " + dteTelDatum.Year.ToString)
        End If
        cmbDatumBegin.SelectedIndex = 0
        cmbDatumEindig.SelectedIndex = cmbDatumEindig.Items.Count - 1

        'Col 0 contains primary key value
        'VerwysdesListFrm.GridVerwysdes.ColumnCount = 0
        'If Not IsNothing(VerwysdesListFrm.GridVerwysdes.SelectedRows(0).Cells(0).Value) Then
        '    'Check if 'Voegby' was clicked or edit
        '    'Onclick 'Voegby' set grid to row 0 and col 0
        '    'If pkVerwysdes <> 0 Then
        '    'Edit
        '    Using conn As SqlConnection = SqlHelper.GetConnection

        '        Dim params() As SqlParameter = {New SqlParameter("@pkVerwysdes", SqlDbType.Int)}

        '        params(0).Value = VerwysdesListFrm.GridVerwysdes.SelectedRows(0).Cells(0).Value

        '        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVerwysdesAndPersoonl", params)
        '        Do While reader.Read
        '            'Populate controls with recordset data
        '            Me.txtVerwysde.Text = reader("verwysde")
        '            Me.lblVan.Text = reader("Versekerde")
        '            Me.lblVoorletter.Text = reader("Voorl")
        '            Me.dtpDatumBegin.Value = CDate(reader("DatumBegin"))
        '            Me.dtpDatumEindig.Value = CDate(reader("DatumEindig"))
        '            txtStatusOld = reader("Status")
        '            Me.txtStatus.Text = reader("Status")
        '        Loop
        '    End Using

        '    Me.btnSoekVersekerde.Enabled = False
        'Else

        '    'Add new
        '    Me.dtpDatumBegin.Value = "01" & Mid(Format(Now, "dd/mm/yyyy hh:mm:ss"), 17)

        '    Me.dtpDatumEindig.Value = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 12, Me.dtpDatumBegin.Value)
        '    Me.dtpDatumEindig.Value = DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, Me.dtpDatumEindig.Value)

        '    txtStatusOld = ""
        '    Me.txtVerwysde.Text = ""
        '    Me.txtStatus.Text = "Aktief"
        '    Me.txtStatus.Enabled = False
        '    Me.btnSoekVersekerde.Enabled = True

        'End If
        'Andriette 27/05/2014
        Verwysdes.Status = VerwysdesListFrm.dgvVerwysdes.SelectedRows(0).Cells(6).Value
        Verwysdes.DatumBegin = VerwysdesListFrm.dgvVerwysdes.SelectedRows(0).Cells(4).Value
        Verwysdes.DatumEindig = VerwysdesListFrm.dgvVerwysdes.SelectedRows(0).Cells(5).Value
        Verwysdes.Verwysde = VerwysdesListFrm.dgvVerwysdes.SelectedRows(0).Cells(1).Value

        'Populate status
        ' Andriette 17/15/2013 verander na Engels
        '    txtStatus.Items.Clear()
        'Me.txtStatus.Items.Add("Aktief")
        'Me.txtStatus.Items.Add("Gekanselleer")
        '    Me.txtStatus.Items.Add("Active")
        '    Me.txtStatus.Items.Add("Cancelled")
        ' Andriette 12/06/2013 Voeg die Expired opsie by
        '   Me.txtStatus.Items.Add("Expired")


        'Me.dtpDatumBegin.CustomFormat = "01/MM/yyyy"
        ''Me.dtpDatumEindig.CustomFormat = VB.Day(Me.dtpDatumEindig.Value) & "/MM/yyyy"
        'Me.txtStatus.Text = VerwysdesListFrm.GridVerwysdes.SelectedRows(0).Cells(6).Value
        'Me.dtpDatumBegin.Text = VerwysdesListFrm.GridVerwysdes.SelectedRows(0).Cells(4).Value
        'Me.dtpDatumEindig.Text = VerwysdesListFrm.GridVerwysdes.SelectedRows(0).Cells(5).Value
        'Me.lblVerwysde.Text = VerwysdesListFrm.GridVerwysdes.SelectedRows(0).Cells(1).Value
        'Me.lblVan.Text = VerwysdesListFrm.GridVerwysdes.SelectedRows(0).Cells(2).Value
        'Me.lblVoorletter.Text = VerwysdesListFrm.GridVerwysdes.SelectedRows(0).Cells(3).Value

        'Me.dtpDatumBegin.CustomFormat = "01/MM/yyyy"
        'Me.dtpDatumEindig.CustomFormat = VB.Day(Me.dtpDatumEindig.Value) & "/MM/yyyy"
        ' Me.txtStatus.Text = Verwysdes.Status
        'Me.dtpDatumBegin.Text = Verwysdes.DatumBegin
        'Me.dtpDatumEindig.Text = Verwysdes.DatumEindig
        Me.lblVerwysde.Text = Verwysdes.Verwysde
        Me.lblVan.Text = VerwysdesListFrm.dgvVerwysdes.SelectedRows(0).Cells(2).Value
        Me.lblVoorletter.Text = VerwysdesListFrm.dgvVerwysdes.SelectedRows(0).Cells(3).Value

    End Sub

    Public Function validateFields() As Boolean
        Dim strGekans As String
        'Dim sSql As String

        'Die verwyser mag nie homself verwys nie
        'Andriette 16/08/2013 gebruik die global polisnommer
        'If Me.lblVerwysde.Text = Form1.POLISNO.Text Then
        If Me.lblVerwysde.Text = glbPolicyNumber Then
            MsgBox("Referral may not be to himself.", MsgBoxStyle.Exclamation, "Poldata")
            validateFields = False
            Me.lblVerwysde.Focus()
            Exit Function
        End If

        'Verwysde moet 'n polisnommer in hê. Dit moet bestaan op persoonl en nie gekanselleerd wees.
        If (Me.lblVerwysde.Text = "") Or Not IsNumeric(Me.lblVerwysde.Text) Then
            MsgBox("The referral must have a valid policy number.", MsgBoxStyle.Exclamation, "Poldata")
            validateFields = False
            Me.lblVerwysde.Focus()
            Exit Function
        End If

        If dteDatumbegin > dteDatumeindig Then
            MsgBox("The start date must be before the end date")
            Exit Function
        End If
        'If VerwysdesListFrm.GridVerwysdes.SelectedRows(0).Cells(0).Value = pkVerwysdes Then 'Vir byvoeg
        ' PolisnoFetch = FetchPersoonlPolisno()
        'Andriette 18/06/2014
        strGekans = poldata1_FetchDetailOnPolicy("gekans", lblVerwysde.Text)

        ' If PolisnoFetch = False Then
        If strGekans Then
            MsgBox("The referral must have a valid policy number and it may not be cancelled. ", MsgBoxStyle.Exclamation, "Poldata")
            validateFields = False
            Exit Function
        Else
            validateFields = True
        End If

        'Die verwysde mag nie 'n JK of TP wees nie 
        If Persoonl.BET_WYSE = "2" Or Persoonl.BET_WYSE = "6" Then
            MsgBox("'Yearly cash or a term policy may not be a referral.", MsgBoxStyle.Exclamation, "Poldata")
            validateFields = False
            Exit Function
        End If
        If ChkForAdd.Checked = True Then
            For i = 0 To VerwysdesListFrm.dgvVerwysdes.Rows.Count - 1

                If lblVerwysde.Text = VerwysdesListFrm.dgvVerwysdes.Rows(i).Cells(1).Value Then
                    MsgBox("This is already a referral link.", MsgBoxStyle.Exclamation, "Poldata")
                    validateFields = False
                    Exit Function
                End If

            Next
        Else
            validateFields = True
        End If

        'As vandag na die 15de is, dan moet die begin datum in die toekoms lê
        'If CDbl(Mid(CStr(Now), 2)) > 15 Then
        '    If DateDiff(Microsoft.VisualBasic.DateInterval.Day, Now, Me.dtpDatumBegin.Value) <= 0 Then
        '        MsgBox("Since today is the 15th of the month, the date in the following month / s is")
        '        Me.dtpDatumBegin.Focus()
        '        Exit Function
        '    End If
        'End If

        'Field Check OK - return true
        validateFields = True

    End Function

    Public Sub logVerwysdesAlteration(ByRef strAltType As Object, ByRef StrOldValue As Object, ByRef StrNewValue As Object)

        'Log alterations on when new Verwysde was added and Datum verval was changed
        Select Case strAltType
            Case "Addnew"
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = "voeg verwysde by: " & Me.lblVan.Text & " " & Me.lblVoorletter.Text & "(" & Me.lblVerwysde.Text & ")"
                Else
                    BESKRYWING = "add Referral: " & Me.lblVan.Text & " " & Me.lblVoorletter.Text & "(" & Me.lblVerwysde.Text & ")"
                End If

            Case "DatumBegin"
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = "wysig begin datum vanaf (" & StrOldValue & ") na (" & StrNewValue & ") op verwysde: " & Me.lblVan.Text & " " & Me.lblVoorletter.Text & "(" & Me.lblVerwysde.Text & ")"
                Else
                    BESKRYWING = "change start date from (" & StrOldValue & ") to (" & StrNewValue & ") on referral: " & Me.lblVan.Text & " " & Me.lblVoorletter.Text & "(" & Me.lblVerwysde.Text & ")"
                End If

            Case "DatumEindig"
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = "wysig end datum vanaf (" & StrOldValue & ") na (" & StrNewValue & ") op verwysde: " & Me.lblVan.Text & " " & Me.lblVoorletter.Text & "(" & Me.lblVerwysde.Text & ")"
                Else
                    BESKRYWING = "change end date from (" & StrOldValue & ") to (" & StrNewValue & ") on referral: " & Me.lblVan.Text & " " & Me.lblVoorletter.Text & "(" & Me.lblVerwysde.Text & ")"
                End If

            Case "Status"
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " wysig status vanaf (" & StrOldValue & ") na (" & StrNewValue & ") op verwysde: " & Me.lblVan.Text & " " & Me.lblVoorletter.Text & "(" & Me.lblVerwysde.Text & ")"
                Else
                    BESKRYWING = " change status from (" & StrOldValue & ") to (" & StrNewValue & ") on referral: " & Me.lblVan.Text & " " & Me.lblVoorletter.Text & "(" & Me.lblVerwysde.Text & ")"
                End If

        End Select

        UpdateWysig((142), BESKRYWING)

    End Sub

    '* Purpose      : Update verwysde se veld 'Verwysdeur' op persoonl
    '* Input        : strVerwysde
    Private Function UpdateVerwysdeWithVerwysdeur(ByRef strVerwysde As Object) As Object
        Try


            Dim params() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@verwysdeur", SqlDbType.NVarChar)}
            params(0).Value = strVerwysde
            'Andriette 16/08/2013 gebruik die global polisnommer
            'params(1).Value = Form1.POLISNO.Text
            params(1).Value = glbPolicyNumber
            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.UpdateVerwysdeurInPersoonl", params)
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function

    'Private Sub txtStatus_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    If txtStatus.Text <> txtStatusOld Then
    '        InformationChanged = True
    '    End If

    'End Sub

    'Private Sub txtStatus_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    If txtStatus.Text <> txtStatusOld Then
    '        InformationChanged = True
    '    End If

    'End Sub

    'Sub InsertVerwysdes()
    '    Try
    '        Using conn As SqlConnection = SqlHelper.GetConnection

    '            Dim param() As SqlParameter = {New SqlParameter("@Verwysde ", SqlDbType.NVarChar), _
    '                                            New SqlParameter("@Verwyser", SqlDbType.NVarChar), _
    '                                            New SqlParameter("@DatumBegin", SqlDbType.DateTime), _
    '                                            New SqlParameter("@DatumEinding", SqlDbType.DateTime), _
    '                                            New SqlParameter("@Status", SqlDbType.NVarChar)}


    '            param(0).Value = Me.lblVerwysde.Text
    '            param(1).Value = Persoonl.POLISNO
    '            param(2).Value = Me.dteDatumbegin
    '            param(3).Value = Me.dteDatumeindig
    '            param(4).Value = Me.txtStatus.Text

    '            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[InsertVerwysdes]", param)
    '        End Using
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)

    '    End Try
    'End Sub

    Sub UpdateVerwysdes(dteBeginDatum As Date, dteEndDatum As Date, status As String)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim param() As SqlParameter = {New SqlParameter("@Verwysde ", SqlDbType.Int), _
                                               New SqlParameter("@DatumBegin", SqlDbType.DateTime), _
                                               New SqlParameter("@DatumEinding", SqlDbType.DateTime), _
                                               New SqlParameter("@Status", SqlDbType.NVarChar)}

                param(0).Value = VerwysdesListFrm.dgvVerwysdes.SelectedRows(0).Cells(0).Value


                'If strStartofThisMonth = "" Then
                '    param(1).Value = Me.dtpDatumBegin.Value
                'Else
                '    param(1).Value = strStartofThisMonth
                'End If
                'If strEndofThisMonth = "" Then
                '    param(2).Value = Me.dtpDatumEindig.Value
                'Else
                '    param(2).Value = strEndofThisMonth
                'End If
                param(1).Value = dteBeginDatum
                param(2).Value = dteEndDatum

                param(3).Value = "Active" 'Andriette 12/06/2014 kan net in Active verwysings ingaan


                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdateVerwysdesData]", param)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try
    End Sub
    Function FetchPersoonlPolisno() As Boolean
        Dim blnreturnValue As Boolean = False
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchPersoonlPolisno]")
                While reader.Read()
                    If reader("POLISNO") = lblVerwysde.Text Then
                        blnreturnValue = True
                    End If
                End While
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            blnreturnValue = False
        End Try
        Return blnreturnValue
    End Function

    'Get the first day of the month
    Private Function FirstDayOfMonth(ByVal sourceDate As DateTime) As DateTime
        Return New DateTime(sourceDate.Year, sourceDate.Month, 1)
    End Function

    'Get the last day of the month
    Private Function LastDayOfMonth(ByVal sourceDate As DateTime) As DateTime
        Dim lastDay As DateTime = New DateTime(sourceDate.Year, sourceDate.Month, 1)
        Return lastDay.AddMonths(1).AddDays(-1)
    End Function


    Private Sub SkakelDatumOm()
        Dim strBeginmonth As String = cmbDatumBegin.SelectedItem.ToString.Substring(0, InStr(cmbDatumBegin.SelectedItem.ToString, " ")).Trim
        Dim strBeginYear As String = cmbDatumBegin.SelectedItem.ToString.Substring(InStr(cmbDatumBegin.SelectedItem.ToString, " "), 4).Trim
        Dim strEndMonth As String = cmbDatumEindig.SelectedItem.ToString.Substring(0, InStr(cmbDatumEindig.SelectedItem.ToString, " ")).Trim
        Dim strEndYear As String = cmbDatumEindig.SelectedItem.ToString.Substring(InStr(cmbDatumEindig.SelectedItem.ToString, " "), 4).Trim

        Select Case strBeginmonth
            Case "Januarie", "January"
                dteDatumbegin = "01/01/" & strBeginYear
            Case "Februarie", "February"
                dteDatumbegin = "01/02/" & strBeginYear
            Case "Maart", "March"
                dteDatumbegin = "01/03/" & strBeginYear
            Case "April"
                dteDatumbegin = "01/04/" & strBeginYear
            Case "Mei", "May"
                dteDatumbegin = "01/05/" & strBeginYear
            Case "Junie", "June"
                dteDatumbegin = "01/06/" & strBeginYear
            Case "Julie", "July"
                dteDatumbegin = "01/07/" & strBeginYear
            Case "Augustus", "August"
                dteDatumbegin = "01/08/" & strBeginYear
            Case "September"
                dteDatumbegin = "01/09/" & strBeginYear
            Case "Oktober", "October"
                dteDatumbegin = "01/10/" & strBeginYear
            Case "November"
                dteDatumbegin = "01/11/" & strBeginYear
            Case "Desember", "December"
                dteDatumbegin = "01/12/" & strBeginYear
            Case Else
                MsgBox("There was a problem with the selection of the start date", MsgBoxStyle.Critical)
                Exit Sub
        End Select

        Select Case strEndMonth
            Case "Januarie", "January"
                dteDatumeindig = DateTime.Parse("01/01/" & strEndYear)
            Case "Februarie", "February"
                dteDatumeindig = DateTime.Parse("01/02/" & strEndYear)
            Case "Maart", "March"
                dteDatumeindig = DateTime.Parse("01/03/" & strEndYear)
            Case "April"
                dteDatumeindig = DateTime.Parse("01/04/" & strEndYear)
            Case "Mei", "May"
                dteDatumeindig = DateTime.Parse("01/05/" & strEndYear)
            Case "Junie", "June"
                dteDatumeindig = DateTime.Parse("01/06/" & strEndYear)
            Case "Julie", "July"
                dteDatumeindig = DateTime.Parse("01/07/" & strEndYear)
            Case "Augustus", "August"
                dteDatumeindig = DateTime.Parse("01/08/" & strEndYear)
            Case "September"
                dteDatumeindig = DateTime.Parse("01/09/" & strEndYear)
            Case "Oktober", "October"
                dteDatumeindig = DateTime.Parse("01/10/" & strEndYear)
            Case "November"
                dteDatumeindig = DateTime.Parse("01/11/" & strEndYear)
            Case "Desember", "December"
                dteDatumeindig = DateTime.Parse("01/12/" & strEndYear)
            Case Else
                MsgBox("There was a problem with the selection of the first payment date", MsgBoxStyle.Critical)
                Exit Sub
        End Select

        dteDatumeindig = dteDatumeindig.AddMonths(1)
        dteDatumeindig = dteDatumeindig.AddDays(-1)

    End Sub


End Class