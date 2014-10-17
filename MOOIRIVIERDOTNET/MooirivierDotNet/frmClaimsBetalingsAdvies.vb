Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports DAL
Public Class frmClaimsBetalingsAdvies
    Dim blnInfoChanges As Boolean = False
    Dim strSortorder As String = ""
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        If blnInfoChanges = True Then
            If MsgBox("Are you sure you want to cancel and loose all your changes?", vbYesNo) = MsgBoxResult.Yes Then
                Me.Close()
            Else
                Exit Sub
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub optBegunstigde_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optBegunstigde.CheckedChanged
        strSortorder = "Begunstigde"
        GetNedHeader()
    End Sub

    Private Sub frmClaimsBetalingsAdvies_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        strSortorder = "Begunstigde"

        GetNedHeader()
    End Sub

    Private Sub optDateTime_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optDateTime.CheckedChanged
        strSortorder = "Aksiedatum2"
        GetNedHeader()
    End Sub

    Private Sub GetNedHeader()
        dgvBetalingsAdvies.AutoGenerateColumns = False
        dgvBetalingsAdvies.DataSource = Nothing
        dgvBetalingsAdvies.Refresh()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim paramsClaims() As SqlParameter = {New SqlParameter("@Sort", SqlDbType.NVarChar)}
                paramsClaims(0).Value = strSortorder

                Dim readerClaims As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "ned.FetchBegunstigdeHeader", paramsClaims)

                Dim NedBegunstigdeHeaderList As List(Of NedBegunstigdeHeaderEntity) = New List(Of NedBegunstigdeHeaderEntity)

                Do While readerClaims.Read
                    Dim item As NedBegunstigdeHeaderEntity = New NedBegunstigdeHeaderEntity()

                    If readerClaims("Aksiedatum2") IsNot DBNull.Value Then
                        item.Aksiedatum2 = readerClaims("Aksiedatum2")
                    Else
                        item.Aksiedatum2 = Nothing
                    End If
                    If readerClaims("polisno") IsNot DBNull.Value Then
                        item.polisno = readerClaims("polisno")
                    Else
                        item.polisno = ""
                    End If
                    If readerClaims("Batchid") IsNot DBNull.Value Then
                        item.Batchid = readerClaims("Batchid")
                    Else
                        item.Batchid = ""
                    End If
                    If readerClaims("Bedrag") IsNot DBNull.Value Then
                        item.Bedrag = readerClaims("Bedrag")
                    Else
                        item.Bedrag = 0
                    End If
                    If readerClaims("Begunstigde") IsNot DBNull.Value Then
                        item.Begunstigde = readerClaims("Begunstigde")
                    Else
                        item.Begunstigde = ""
                    End If

                    If Area.Tak_Naam = "Flagship" Then
                        If item.Aksiedatum2 >= CDate("01/03/2009") Then
                            item.Bedrag = item.Bedrag
                        Else
                            item.Bedrag = item.Bedrag / 100
                        End If
                    Else
                        If item.Aksiedatum2 >= CDate("17/03/2009") Then
                            item.Bedrag = item.Bedrag
                        Else
                            item.Bedrag = item.Bedrag / 100
                        End If
                    End If

                    NedBegunstigdeHeaderList.Add(item)
                Loop

                dgvBetalingsAdvies.DataSource = NedBegunstigdeHeaderList

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    readerClaims.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub
End Class