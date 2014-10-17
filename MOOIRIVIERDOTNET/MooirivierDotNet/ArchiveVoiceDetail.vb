Option Strict Off
Option Explicit On

Imports System.Data.SqlClient
Imports DAL
Friend Class ArchiveVoiceDetail
	Inherits System.Windows.Forms.Form
    Public pkArchiveVoice As Integer
    Private Sub ArchiveVoiceDetail_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@pkArchiveVoice", SqlDbType.Int)
                param.Value = ArchiveVoice.dgvArchiveVoice.SelectedCells(6).Value
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchArchiveVoiceByPk", param)

                While reader.Read()
                    Dim item As ArchiveVoiceEntity = New ArchiveVoiceEntity()
                    Me.txtCallDate.Text = reader("CallDate")
                    Me.txtGebruiker.Text = reader("Gebruiker")
                    Me.txtContactNumber.Text = reader("ContactNumber")  'ArchiveVoice.dgvArchveVoice.SelectedCells(2).Value
                    Me.txtCallerNumber.Text = reader("CallerNumber")
                    Me.txtFileName.Text = reader("FileName")
                    Me.txtComments.Text = reader("Comments")

                End While
                conn.Close()
            End Using

        Catch ex As Exception
            MsgBox("There's error trying to connect to the database.", MsgBoxStyle.Exclamation)

        End Try
        FillCategryDesc()
        Me.Text = "      Voice Archive Detail"
    End Sub
    Private Sub FillCategryDesc()

        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim params() As SqlParameter = {New SqlParameter("@pkArchiveCategories", SqlDbType.NVarChar)}
                                           
            params(0).Value = ArchiveVoice.intFkArchiveCategories

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchArchiveCategoriesByPk", params)
            reader.Read()
            If Persoonl.TAAL = 0 Then
                txtCategoryDesc.Text = reader("DescriptionAfr")
            Else
                txtCategoryDesc.Text = reader("DescriptionEng")
            End If
            conn.Close()
        End Using
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class