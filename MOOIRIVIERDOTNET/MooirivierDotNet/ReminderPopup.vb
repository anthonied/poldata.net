Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Data.SqlClient
Imports DAL

Friend Class ReminderPopup
    Inherits System.Windows.Forms.Form

    'Description  : The reminder popup
    Dim dteremindDate As Date
    Public intpkReminder As Integer
    Public intpkMemo As Integer
    Public dteReminderdatum As Date
    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
        DeleteReminder()
        SelectMemo()
        Me.Close()
    End Sub
    Sub SelectMemo()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection


                'Search policy
                If Me.chkSoekPolis.CheckState = 1 Then
                    'Get memo detail
                    Dim param As New SqlParameter("@pkMemo", SqlDbType.Int)
                    param.Value = intpkMemo
                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchMemoForReminder", param)

                    If reader.Read() Then
                        Form1.POLISNO.Text = reader("polisno")
                        glbPolicyNumber = reader("Polisno")
                        Me.Close()
                        Form1.command8_Click(Nothing, New System.EventArgs())
                    Else
                        MsgBox("The policy could not be found.", MsgBoxStyle.Exclamation)
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

    'Delete reminder
    Sub DeleteReminder()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params As New SqlParameter("@pkReminder", SqlDbType.Int)
                params.Value = intpkReminder
                If intpkReminder <> 0 Then

                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[DeleteExistingReminder]", params)

                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

    End Sub

    'Snooze reminder
    Private Sub btnSnooze_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSnooze.Click
        Try
            dteremindDate = getNewDate()
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Datum", SqlDbType.DateTime), _
                                                New SqlParameter("@pkReminder", SqlDbType.Int)}
                params(0).Value = dteremindDate
                params(1).Value = intpkReminder
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateSnooze", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        Me.Close()
    End Sub

    Private Sub chkSoekPolis_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkSoekPolis.CheckStateChanged
        checkbtnOkEnable()
    End Sub

    Private Sub chkStaak_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkStaak.CheckStateChanged
        checkbtnOkEnable()
    End Sub

    Private Sub ReminderPopup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.cmbSnooze.SelectedIndex = 0
        Me.lblDue.Text = String.Format(dteReminderdatum, "dddd dd mmmm yyyy HH:MM")
        Beep()

        Me.Text = My.Application.Info.Title & " - Reminder"
    End Sub
    'Get the new date from the snooze time
    Public Function getNewDate() As Object
        Dim dtecurrentDate As Date
        Select Case Me.cmbSnooze.SelectedIndex
            Case 0
                getNewDate = DateAdd(Microsoft.VisualBasic.DateInterval.Minute, 5, Now)
            Case 1
                getNewDate = DateAdd(Microsoft.VisualBasic.DateInterval.Minute, 10, Now)
            Case 2
                getNewDate = DateAdd(Microsoft.VisualBasic.DateInterval.Minute, 15, Now)
            Case 3
                getNewDate = DateAdd(Microsoft.VisualBasic.DateInterval.Minute, 30, Now)
            Case 4
                getNewDate = DateAdd(Microsoft.VisualBasic.DateInterval.Hour, 1, Now)
            Case 5
                getNewDate = DateAdd(Microsoft.VisualBasic.DateInterval.Hour, 2, Now)
            Case 6
                getNewDate = DateAdd(Microsoft.VisualBasic.DateInterval.Hour, 4, Now)
            Case 7
                getNewDate = DateAdd(Microsoft.VisualBasic.DateInterval.Hour, 8, Now)
            Case 8
                getNewDate = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, Now)
            Case 9
                getNewDate = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 2, Now)
            Case 10
                getNewDate = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 3, Now)
            Case 11
                getNewDate = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 4, Now)
            Case 12
                getNewDate = DateAdd(Microsoft.VisualBasic.DateInterval.WeekOfYear, 1, Now)
            Case 13
                getNewDate = DateAdd(Microsoft.VisualBasic.DateInterval.WeekOfYear, 2, Now)
            Case 14
                getNewDate = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, Now)
            Case Else
                getNewDate = dtecurrentDate
        End Select
    End Function
    'Check to see if the ok button should be enabled or not
    Public Sub checkbtnOkEnable()
        If Me.chkSoekPolis.CheckState = 1 Or Me.chkStaak.CheckState = 1 Then
            Me.btnOk.Enabled = True
        Else
            Me.btnOk.Enabled = False
        End If
    End Sub
End Class