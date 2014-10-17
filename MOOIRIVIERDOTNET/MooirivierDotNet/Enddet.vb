Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports DAL
Friend Class Enddet
    Inherits BaseForm
    Dim blnaddNew As Boolean
    Dim strendosdetmemovoor As String
    Private Sub Enddetcmd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Enddetcmd.Click

        Save(Status:="Wysiging", type:="Add/Update") 'add new fields to wysiging

        Me.enddetstatus.Text = "Endorsement detail record is changed"
        Me.enddetstatus.BackColor = System.Drawing.Color.Lime

    End Sub

    Private Sub Enddet_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.enddetstatus.Text = String.Empty
        Endmeest.endmststatus.Text = " "
        Me.enddetstatus.BackColor = System.Drawing.Color.Empty
        'Me.Enddetbew.Text = String.Empty
        Me.Close()
    End Sub

    Private Sub Verwenddet_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Verwenddet.Click
        '	Dim strSql As Object

        Save(Status:="Staking", type:="delete")

        Me.enddetstatus.Text = "Endorsement detail record is removed"
        Me.enddetstatus.BackColor = System.Drawing.Color.Lime

    End Sub
    Sub Save(ByVal type As String, ByVal Status As String)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Endosidentifikasie", SqlDbType.NVarChar), _
                                                New SqlParameter("@EndosdetMemoNew", SqlDbType.NVarChar), _
                                                New SqlParameter("@Datum", SqlDbType.NVarChar), _
                                                New SqlParameter("@Status1", SqlDbType.NVarChar), _
                                                New SqlParameter("@Type", SqlDbType.NVarChar), _
                                                New SqlParameter("@EndosdetMemoOld", SqlDbType.NVarChar), _
                                                New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@Branchcode", SqlDbType.NVarChar)}

                params(0).Value = Me.Endosdetid.Text
                If type = "delete" Then
                    params(1).Value = String.Empty
                Else
                    params(1).Value = Me.Enddetbew.Text
                End If
                params(2).Value = Now
                params(3).Value = Status
                params(4).Value = type
                params(5).Value = strendosdetmemovoor
                params(6).Value = "1111111111"
                params(7).Value = Endmeest.cmbAreaDescription.SelectedValue 'Me.txtTak.Text

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "endos5.UpdateWysigendos", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return

        End Try
    End Sub


    Private Sub Enddet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddingEndosDetail()
        strendosdetmemovoor = Enddetbew.Text
        enddetstatus.Text = String.Empty

        'Enddetbew.Text = String.Empty
        'Me.Enddetbew.Refresh()
    End Sub
 
    Private Sub Enddetbew_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Enddetbew.TextChanged
        Me.Enddetbew.Refresh()
    End Sub
    Sub AddingEndosDetail() 'As List(Of EndosDetailsEntity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim param() As SqlParameter = {New SqlParameter("@branchcode", SqlDbType.NVarChar), _
                                            New SqlParameter("@Endosidentifikasie", SqlDbType.NVarChar)}

                param(0).Value = Endmeest.cmbAreaDescription.SelectedValue
                param(1).Value = Endmeest.txtEndosidentifikasie.Text

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[endos5].[AddingEndosDetails]", param)

                Enddetbew.Text = ""
                While reader.Read()
                    Enddetbew.Text = reader("Endosdetmemo")
                End While
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return
        End Try

    End Sub
   
End Class