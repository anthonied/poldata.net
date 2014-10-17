Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Data.SqlClient
Imports DAL

Friend Class AddisionelePremieHerstel
    Inherits System.Windows.Forms.Form

    'Description  : Reset the additional premium to zero for specific section (General or Salary)

    Dim MaxDate As Object
    
    Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnRunReport_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnRunReport.Click

        If Not validated_Renamed() Then
            Exit Sub
        End If

        UpdateGebruikerLopies()


        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.lblStatus.Text = ""
        Me.lblStatus.Refresh()

        'Selected payment method
        If Me.rdAlgemeen.Checked Then
            resetGeneral()
        End If

        If Me.rdSalaris.Checked Then
            resetSalary()
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStatus.Text = ""
        Me.lblStatus.Refresh()
    End Sub
    Private Sub AddisionelePremieHerstel_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Set datepicker to today
        Me.DTPAfsluit.Value = Now
         Me.DTPAfsluit.Value = System.DBNull.Value

        Me.Text = My.Application.Info.Title & " - Multi Data - Restore additional premiums"

    End Sub
    Public Function validated_Renamed() As Boolean
        validated_Renamed = True

        If Me.rdSalaris.Checked Then
            If IsDBNull(Me.DTPAfsluit.Value) Then
                validated_Renamed = False
                MsgBox("The closing date must be entered to continue", MsgBoxStyle.Exclamation)
                Exit Function
            End If
        End If

        If Not (Me.rdAlgemeen).Checked And Not (Me.rdSalaris).Checked Then
            MsgBox("Please select one of the closing, or General Salary.", MsgBoxStyle.Exclamation)
            validated_Renamed = False
            Exit Function
        End If
    End Function
    Public Sub resetGeneral()

        Using conn As SqlConnection = SqlHelper.GetConnection

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchMaxAfsluit_date]")

            If MsgBox("Note: All reports and reconciliation forms must be completed by this time and balanced." & Chr(13) & Chr(13) & "Should the restore of additional premiums continue?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                While reader.Read()
                    MaxDate = reader("MaxDate")
                End While


                If MsgBox("The closing date according to the database is: " & MaxDate & Chr(13) & Chr(13) & " Is this correct?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then



                    Dim readers As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchPremie]")

                    While readers.Read()
                        UpdateAddisionelePremie()

                        If readers("totaal").value <> 0 Then
                            AddWysigDetails()
                        End If
                    End While

                    Persoonl.TAAL = 0

                    MsgBox("General additional premium adjustment was successful.", MsgBoxStyle.Information)
                Else
                    MsgBox("There was no additional premiums offered.", MsgBoxStyle.Information)
                End If
            End If

        End Using
    End Sub
    Public Sub resetSalary()

        If MsgBox("Note: All reports and reconciliation forms must be completed by this time and balanced." & Chr(13) & Chr(13) & "Should we continue with the recovery of additional premiums for the conclusion Salary?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Dim readers As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchPremieForSalary]")

            While readers.Read()
                UpdateAddisionelePremieSalary()

                If readers("totaal") <> 0 Then
                    AddWysigDetails()
                End If
            End While

            MsgBox("The additional premium salary adjustment was successful.", MsgBoxStyle.Information)
        Else
            MsgBox("There was no additional contributions offered.", MsgBoxStyle.Information)
        End If

    End Sub
    Sub UpdateGebruikerLopies()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Gebruiker", SqlDbType.NVarChar), _
                                                New SqlParameter("@Datum", SqlDbType.DateTime), _
                                                New SqlParameter("@Beskrywing", SqlDbType.NVarChar), _
                                                New SqlParameter("@AfsluitDatum", SqlDbType.DateTime)}


                params(0).Value = Gebruiker.Naam

                params(1).Value = Now()

                If Me.rdAlgemeen.Checked Then
                    params(2).Value = "Herstel addisionele premie"
                    params(3).Value = DBNull.Value
                ElseIf Me.rdSalaris.Checked Then
                    params(2).Value = "Herstel addisionele premie - Salaris"

                    params(3).Value = CDate(Me.DTPAfsluit._Value)
                End If


                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[stats5].[UpdateGebruikerLopies2]", params)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Sub GetMaxDate()
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchMaxAfsluit_date]")
                While reader.Read()
                    MaxDate = reader("MaxDate")
                End While

            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Sub UpdateAddisionelePremie()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@Afgesluit", SqlDbType.TinyInt), _
                                                New SqlParameter("@DatumAfgesluit", SqlDbType.NVarChar)}


                params(0).Value = Persoonl.POLISNO

                params(1).Value = 1
                params(2).Value = MaxDate



                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdateAddisionelePremie]", params)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Sub AddWysigDetails()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@KODE", SqlDbType.NVarChar), _
                                                New SqlParameter("@DATUM", SqlDbType.DateTime), _
                                                New SqlParameter("@VERSEKERDE", SqlDbType.NVarChar), _
                                                New SqlParameter("@VOORL", SqlDbType.NVarChar), _
                                                New SqlParameter("@gebruiker", SqlDbType.NVarChar), _
                                                New SqlParameter("@beskrywing", SqlDbType.NVarChar)}



                params(0).Value = Persoonl.POLISNO

                params(1).Value = 44
                params(2).Value = (DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, Now))
                params(3).Value = Persoonl.VERSEKERDE
                params(4).Value = Persoonl.VOORL
                params(5).Value = Gebruiker.Naam
                If Persoonl.TAAL = 0 Then
                    params(6).Value = "Herstel addisionele premie"
                Else
                    params(6).Value = "Reset additional premium"
                End If

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[InsertWysigDetails]", params)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Sub UpdateAddisionelePremieSalary()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@Afgesluit", SqlDbType.TinyInt), _
                                                New SqlParameter("@DatumAfgesluit", SqlDbType.NVarChar)}


                params(0).Value = Persoonl.POLISNO

                params(1).Value = 1
                params(2).Value = Me.DTPAfsluit._Value



                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdateAddisionelePremieForSalary]", params)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    
End Class