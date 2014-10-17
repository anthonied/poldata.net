Option Strict Off
Option Explicit On

Imports System.Data.SqlClient
Imports DAL
Friend Class ArgiefDetail
	Inherits System.Windows.Forms.Form
	
    ''Description  : Archive detail
    Dim pkArgief As Integer

    Private Sub ArgiefDetail_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@pkArgief", SqlDbType.Int)
                param.Value = Argief.dgvArgief.SelectedCells(5).Value
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchArgiefDetailBypkArgief", param)


                While reader.Read()
                    'Kobus 16/07/2014 verander entity
                    'Dim item As ArgiefDetailEntity = New ArgiefDetailEntity()
                    Dim item As ArgiefEntity = New ArgiefEntity()
                    Me.txtDatum.Text = Format(reader("Datum"), "dd/MM/yyyy HH:MM:ss")
                    Me.txtGebruiker.Text = reader("Gebruiker")
                    Me.txtBestemming.Text = Argief.dgvArgief.SelectedCells(2).Value
                    If Argief.dgvArgief.SelectedCells(4).Value = "" Then
                        'Andriette 01/08/2013 maak Engels
                        Me.txtEposAdres.Text = "N/A"
                    Else
                        Me.txtEposAdres.Text = reader("epos_Adres")
                    End If
                    'Kobus 16/07/2014 comment out
                    'If Argief.dgvArgief.SelectedCells(1).Value = "" Then
                    '    'Andriette 01/08/2013 maak Engels
                    '    Me.txtKategorie.Text = "N/A"
                    'Else
                    'Me.txtKategorie.Text = reader("Kategorie")
                    'End If
                    If reader("epos_Onderwerp") = "" Then
                        'Andriette 01/08/2013 maak engels
                        'Me.txtEposOnderwerp.Text = "n.v.t"
                        Me.txtEposOnderwerp.Text = "N/A"
                    Else
                        Me.txtEposOnderwerp.Text = reader("epos_Onderwerp")
                    End If
                    If reader("epos_Inhoud") = "" Then
                        'Andriette 01/08/2013 maak engels
                        'Me.txtEposInhoud.Text = "n.v.t"
                        Me.txtEposInhoud.Text = "N/A"
                    Else
                        Me.txtEposInhoud.Text = reader("epos_Inhoud")
                    End If
                    If reader("epos_Aanhangsels") = "" Then
                        'Andriette 01/08/2013 maak engels
                        Me.txtEposAanhangsels.Text = "N/A"
                    Else
                        Me.txtEposAanhangsels.Text = reader("epos_Aanhangsels")
                    End If

                    'If IsDBNull(reader("fkArchiveCategories")) Then
                    '    txtKategorie.Text = reader("fkArchiveCategories")
                    'End If
                    Me.txtFileName.Text = reader("Path")



                End While
            End Using

        Catch ex As Exception
            MsgBox("There's error trying to connect to the database.", MsgBoxStyle.Exclamation)

        End Try

        Me.Text = "     Archive - Detail"
        FillKategorieDesc()
    End Sub
    Private Sub FillKategorieDesc()

        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim params() As SqlParameter = {New SqlParameter("@pkArchiveCategories", SqlDbType.NVarChar)}

            params(0).Value = Argief.dgvArgief.SelectedCells(9).Value

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchArchiveCategoriesByPk", params)
            reader.Read()
            If Persoonl.TAAL = 0 Then
                If Argief.dgvArgief.SelectedCells(9).Value <> "0" Then
                    txtKategorie.Text = reader("DescriptionAfr")
                Else
                    txtKategorie.Text = "N/A"
                End If
            Else
                If Argief.dgvArgief.SelectedCells(9).Value <> "0" Then
                    txtKategorie.Text = reader("DescriptionEng")
                Else
                    txtKategorie.Text = "N/A"
                End If

            End If

        End Using
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class