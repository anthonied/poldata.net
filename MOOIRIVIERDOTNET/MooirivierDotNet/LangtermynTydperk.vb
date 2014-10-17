Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Data.SqlClient
Imports DAL

Friend Class LangtermynTydperk
    Inherits BaseForm

    'Description  : Capture the timeframe for the longterm policy Return newly added pk in public variable - caller must unload form
    Public IntPkLangtermynPolis As Integer

     Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
        Dim dteLatestMonthEnd As Date
        Dim dteExistingMonthEnd As Date

        'Validate term
        Try
            If validated_Renamed() Then

                Using conn As SqlConnection = SqlHelper.GetConnection

                    Dim params() As SqlParameter = {New SqlParameter("@pkLangtermynPolis", SqlDbType.Int), _
                                                    New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                    New SqlParameter("@DatumBegin", SqlDbType.DateTime), _
                                                    New SqlParameter("@Tydperk", SqlDbType.TinyInt), _
                                                    New SqlParameter("@DatumEindig", SqlDbType.DateTime)}

                    params(0).Value = IntPkLangtermynPolis
                    'Andriette 16/08/2013 gebruik die global polisnommer
                    'params(1).Value = CStr(Form1.POLISNO.Text)
                    params(1).Value = glbPolicyNumber
                    params(2).Value = CDate(Me.dtpBegin.Value)
                    params(3).Value = cmbTydperk.SelectedItem
                    params(4).Value = CDate(Me.dtpEindig.Value)


                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.UpdateLangtermynPolis", params)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                End Using
                'Andriette 16/08/2013 gebruik die global polisnommer
                '  UpdateCLRSField("A", (Form1.POLISNO).Text)
                UpdateCLRSField("A", glbPolicyNumber)
                'Get the latest month-end date
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim param As New SqlParameter("@afsluitdatum", SqlDbType.DateTime)
                    param.Value = CDate(DateAdd(Microsoft.VisualBasic.DateInterval.Month, -13, Now))

                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.Fetch_md_PRINT_DAT_LatestMonth", param)

                    While reader.Read()
                        If reader("afsluitdatum") IsNot DBNull.Value Then
                            If reader("afsluitdatum") > param.Value Then
                                dteLatestMonthEnd = reader("afsluitdatum")
                            End If
                        End If
                    End While
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                End Using


                'Check if the month-end was already done for the start of this term
                If (dteLatestMonthEnd) = (DateAdd(Microsoft.VisualBasic.DateInterval.Month, -1, Me.dtpBegin.Value)) Then

                    'Get the month-end record for the term period
                    Using conn As SqlConnection = SqlHelper.GetConnection
                        Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                        param.Value = Persoonl.POLISNO

                        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.Fetch_md_PRINT_DAT", param)

                        Do While reader.Read
                            If reader.Read Then
                                'Create month-end record
                                gen_insertMonthEndRecord(Persoonl.POLISNO, dteLatestMonthEnd, "LT")
                            Else
                                'Delete existing month-end records
                                dteExistingMonthEnd = reader("afsluitdatum")
                                'Create new month-end record for Term policy
                                gen_insertMonthEndRecord(Persoonl.POLISNO, dteLatestMonthEnd, "LT")
                            End If
                        Loop
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                    End Using
                End If 'Format(datLatestMonthEnd, "mm/yyyy")....
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        'Hide form, caller must unload form
        Me.Hide()

    End Sub
   Private Sub cmbTydperk_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbTydperk.SelectedIndexChanged
        updateEndDate()
    End Sub

    Private Sub dtpBegin_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateEndDate()
    End Sub

    Private Sub LangtermynTydperk_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Set the custom format for the datepickers
        Me.dtpBegin.CustomFormat = "01/MM/yyyy"

        'Set default dates and max date for start
        If VB.Day(Now) <= 15 Then
            Me.dtpBegin.Value = DateSerial(Year(Now), Month(Now), 1)
            Me.dtpBegin.MinDate = DateSerial(Year(Now), Month(Now), 1) 'First day of next month
        Else
            Me.dtpBegin.Value = DateSerial(Year(Now), Month(Now) + 1, 1)
            Me.dtpBegin.MinDate = DateSerial(Year(Now), Month(Now) + 1, 1) 'First day of next month
        End If

        Me.dtpBegin.MaxDate = DateSerial(Year(dtpBegin.MinDate), Month(dtpBegin.MinDate) + 13, 1) 'One year later

        Me.cmbTydperk.SelectedIndex = 10

        Me.Text = My.Application.Info.Title & " - Term policy - Period"

        If Gebruiker.titel = "Besigtig" Then
            Me.btnOk.Enabled = False
        End If
    End Sub

    'Validate term etc.
    Public Function validated_Renamed() As Boolean
        Try
            validated_Renamed = False
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@DatumBegin", SqlDbType.DateTime), _
                                                New SqlParameter("@DatumEindig", SqlDbType.DateTime)}
                'Andriette Gebruik die global polisnommer

                'params(0).Value = CStr(Form1.POLISNO.Text)
                params(0).Value = glbPolicyNumber
                params(1).Value = CDate(Me.dtpBegin.Value)
                params(2).Value = CDate(Me.dtpEindig.Value)

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchLangtermynPolis", params)
                If Not reader.HasRows() Then
                    ' If reader.Read Then
                    validated_Renamed = True
                Else
                    MsgBox("The period overlaps with an existing period (" & entLangtermynpolis.DatumBegin & " - " & entLangtermynpolis.DatumEindig & ")", MsgBoxStyle.Exclamation)
                    Exit Function
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function
    Public Sub updateEndDate()
        dtpEindig.Value = CStr(DateSerial(Year(Me.dtpBegin.Value), Month(Me.dtpBegin.Value) + CDbl(Me.cmbTydperk.Text), 0)) 'Last day of month
        dtpEindig.Enabled = False
    End Sub
End Class