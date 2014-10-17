Option Strict Off
Option Explicit On

Imports System.Data.SqlClient
Imports DAL
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class MemoListDetail
    Inherits BaseForm
    Dim blnInformationChanged As Boolean
    Dim intPkReminder As Integer
    Dim dteremindDate As Date
    Const IntnrChrForAlteration As Integer = 30 'Number of characters used for alteration record

		Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        'MemoList.gridMemo.row = 0
        ' MemoList.populateGrid()

        Me.Close()
    End Sub
   
	Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
        'Dim rsRem As Object
        Dim dteremindDate As Date
        Dim strKategorie As String

        'Validate form before updating data
        If Not Validate_Renamed() Then
            Exit Sub
        End If

        'Try
        '    'Check if an item was selected (update <> addnew)

        '    Using conn As SqlConnection = SqlHelper.GetConnection
        '        Dim param As New SqlParameter("pkMemo", SqlDbType.Int)
        '        param.Value = MemoList.gridMemo.SelectedCells(0).Value
        '        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchMemo", param)
        '        reader.Read()

        If MemoList.blnaddNew = False Then 'Edit
            'Only update non NB items and when information changed
            strKategorie = MemoList.dgvMemo.SelectedCells(8).Value
            If strKategorie <> 1 And strKategorie <> 3 And blnInformationChanged Then
                SaveMemo()
                'Set alteration record description
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = "Verander aan Kantoor memo inskrywing (" & Mid(Me.txtBeskrywing.Text, 1, IntnrChrForAlteration) & "...)"
                Else
                    BESKRYWING = "Change Office memo entry (" & Mid(Me.txtBeskrywing.Text, 1, IntnrChrForAlteration) & "...)"
                End If
                'Log alteration
                UpdateWysig((39), BESKRYWING)
            End If
        Else
            SaveMemo()
            If Persoonl.TAAL = 0 Then
                BESKRYWING = "Voeg Kantoor memo inskrywing by (" & Mid(Me.txtBeskrywing.Text, 1, IntnrChrForAlteration) & "...)"
            Else
                BESKRYWING = "Add Office memo entry (" & Mid(Me.txtBeskrywing.Text, 1, IntnrChrForAlteration) & "...)"
            End If
            'Log alteration
            UpdateWysig((39), BESKRYWING)
        End If

        dteremindDate = Format(Me.DTPicker1.Value, "yyyy-mm-dd") & " " & Me.cmbTyd.Text
        If Me.chkRemindMe.CheckState = 1 Then
            UpdateInsertReminder()
        Else
            'Andriette 01/07/2014 delete reminder as daar vorige inskrywings was
            If MemoList.dgvMemo.RowCount > 0 Then
                DeleteReminder()
            End If
        End If
        'Clear controls
        Me.chkNB.Checked = False
        Me.chkRemindMe.Checked = False
        Me.txtBeskrywing.Text = ""
        Me.txtDatum.Text = ""
        Me.txtDatumVerander.Text = ""
        Me.txtGebruiker.Text = ""
        'Update form and close
        MemoList.populateGridDesc()
        Me.Close()
    End Sub
    Private Sub chkNB_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkNB.CheckStateChanged
        blnInformationChanged = True
    End Sub
    'UPGRADE_WARNING: Event chkRemindMe.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub chkRemindMe_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkRemindMe.CheckStateChanged
        If Me.chkRemindMe.CheckState = 1 Then
            Me.lblDatum.Enabled = True
            Me.lblTyd.Enabled = True
            Me.DTPicker1.Enabled = True
            Me.cmbTyd.Enabled = True

        Else
            Me.lblDatum.Enabled = False
            Me.lblTyd.Enabled = False
            Me.DTPicker1.Enabled = False
            Me.cmbTyd.Enabled = False

        End If
        blnInformationChanged = True
    End Sub

    Private Sub MemoListDetail_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim dtetheTime As DateTime
        Dim intPkMemo As Integer

        'Andriette 30/06/2014
        Me.Text = "Office Memo - Detail"

        'Populate time combo
        dtetheTime = CDate("08:00")
        For i = 0 To 18
            cmbTyd.Items.Add(Format(dtetheTime, "HH:mm"))
            dtetheTime = DateAdd(DateInterval.Minute, 30, dtetheTime)
        Next
        'Andriette 30/06/2014 skuif na die if statement
        ' pkMemo = MemoList.gridMemo.SelectedCells(1).Value

        'Setup datepicker
        Me.DTPicker1.CustomFormat = "dddd dd MMMM yyyy"

        If MemoList.blnaddNew Then
            'add
            Me.txtGebruiker.Text = Gebruiker.Naam
            Me.txtDatum.Text = Now
            Me.txtDatumVerander.Text = Now
            Me.DTPicker1.Value = Now
            Me.cmbTyd.SelectedIndex = 0
            Me.txtBeskrywing.Text = ""
            Me.chkRemindMe.Checked = False
            intPkReminder = 0
        Else
            'edit
            intPkMemo = MemoList.dgvMemo.SelectedCells(1).Value
            Try
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim params() As SqlParameter = {New SqlParameter("@fkMemo", SqlDbType.Int), _
                                                   New SqlParameter("@Gebruiker", SqlDbType.NVarChar)}

                    params(0).Value = intPkMemo
                    params(1).Value = Gebruiker.Naam

                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchReminder]", params)
                    While reader.Read()
                        Me.chkRemindMe.CheckState = System.Windows.Forms.CheckState.Checked
                        Me.DTPicker1.Value = Format(reader("datum"), "dd/MM/yyyy")
                        Me.cmbTyd.Text = Format(reader("datum"), "HH:MM")
                        intPkReminder = reader("pkReminder")

                    End While
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                End Using

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If

        chkRemindMe_CheckStateChanged(chkRemindMe, New System.EventArgs())
        blnInformationChanged = False
        If Gebruiker.titel = "Besigtig" Then
            'If pkMemo <> 0 Then 'Edit
            Me.btnOk.Enabled = False
            'End If
        End If
    End Sub

    Public Function Validate_Renamed() As Boolean
        Validate_Renamed = True

        'Check txtBeskrywing
        If Trim(Me.txtBeskrywing.Text) = "" Then
            MsgBox("A description for memo must entered.", MsgBoxStyle.Exclamation)
            Me.txtBeskrywing.Focus()
            Validate_Renamed = False
        End If
    End Function

    Private Sub txtBeskrywing_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBeskrywing.TextChanged
        blnInformationChanged = True
    End Sub
    Sub SaveMemo()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@pkMemo", SqlDbType.Int), _
                                                 New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                 New SqlParameter("@Gebruiker", SqlDbType.NVarChar), _
                                                 New SqlParameter("@DatumToegevoer", SqlDbType.DateTime), _
                                                 New SqlParameter("@Kategorie", SqlDbType.Int), _
                                                 New SqlParameter("@Beskrywing", SqlDbType.NVarChar), _
                                                 New SqlParameter("@Deleted", SqlDbType.Int), _
                                                 New SqlParameter("@DatumVerander", SqlDbType.DateTime)}

                If MemoList.blnaddNew Then
                    params(0).Value = DBNull.Value
                Else
                    params(0).Value = MemoList.dgvMemo.SelectedCells(1).Value
                End If

                params(1).Value = Persoonl.POLISNO
                params(2).Value = Gebruiker.Naam
                params(3).Value = Me.txtDatum.Text

                'Only change category to NB when necessary
                If MemoList.blnaddNew = False Then
                    If MemoList.dgvMemo.SelectedCells(8).Value <> 1 And MemoList.dgvMemo.SelectedCells(8).Value <> 3 Then
                        If Me.chkNB.Checked = True Then
                            params(4).Value = 1
                        Else
                            params(4).Value = 0
                        End If
                    End If
                Else
                    If Me.chkNB.Checked = True Then
                        params(4).Value = 1
                    Else
                        params(4).Value = 0
                    End If
                End If
                params(5).Value = Me.txtBeskrywing.Text
                params(6).Value = 0
                'params(7).Value = Me.txtDatumVerander.Text ' Andriette 11/04/2013
                params(7).Value = Now()
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.InsertMemo", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Sub UpdateInsertReminder()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@pkReminder", SqlDbType.Int), _
                                                 New SqlParameter("@Gebruiker", SqlDbType.NVarChar), _
                                                 New SqlParameter("@Datum", SqlDbType.DateTime), _
                                                 New SqlParameter("@Boodskap", SqlDbType.NVarChar), _
                                                 New SqlParameter("@Onderwerp", SqlDbType.NVarChar), _
                                                 New SqlParameter("@fkMemo", SqlDbType.Int), _
                                                 New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                 New SqlParameter("@DatumToegevoer", SqlDbType.DateTime)}

                If intPkReminder = 0 Then
                    params(0).Value = DBNull.Value
                Else
                    params(0).Value = intPkReminder
                End If
                params(1).Value = Gebruiker.Naam
                dteremindDate = Mid(Me.DTPicker1.Value, 1, 10) & " " & Me.cmbTyd.Text
                params(2).Value = dteremindDate
                params(3).Value = CStr(Me.txtBeskrywing.Text)
                Dim strTitelBesk As String
                Dim item As New ComboBoxEntity

                item = Form1.TITEL.SelectedItem
                strTitelBesk = item.ComboBoxName
                params(4).Value = strTitelBesk & " " & Persoonl.VOORL & " " & Persoonl.VERSEKERDE & " (" & Persoonl.POLISNO & ")"

                If MemoList.blnaddNew Then
                    params(5).Value = DBNull.Value
                Else
                    params(5).Value = MemoList.dgvMemo.SelectedCells(1).Value
                End If
                params(6).Value = Persoonl.POLISNO
                params(7).Value = Me.txtDatum.Text

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.InsertReminder", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Sub DeleteReminder()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params As New SqlParameter("@fkMemo", SqlDbType.Int)
                params.Value = CInt(MemoList.dgvMemo.SelectedCells(1).Value)
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[DeleteReminder]", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
End Class