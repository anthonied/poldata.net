Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports DAL
Friend Class Wysig2006
    Inherits BaseForm
	
    Private Sub wysig_2006_oud_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles wysig_2006_oud.Click
        Me.Close()
    End Sub

    Private Sub Wysig2006_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'List1.DisplayMember = "description"
        'List1.ValueMember = "description"
        'List1.DataSource = ListWysigtot2006()
        'If List1.Items.Count = 0 Then
        '    MsgBox("There are no amendments for period as requested!")
        '    Me.Close()
        '    Exit Sub
        'End If

        Dim lstAmendments As List(Of WysigEntity)
        lstAmendments = ListWysigtot2006()

        If IsNothing(lstAmendments) Then
            MsgBox("There are no amendments for period as requested!")
            Me.Close()
            Exit Sub
        End If

        dgvAmendments.DataBindings.Clear()
        dgvAmendments.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAmendments.ReadOnly = True
        dgvAmendments.AutoGenerateColumns = False
        With Me.dgvAmendments.RowTemplate
            .Height = 18
            .MinimumHeight = 5
        End With

        dgvAmendments.DataSource = lstAmendments

    End Sub
    ' Andriette 08/05/2013 verander die entity
    'Function ListWysigtot2006() As List(Of Wysig2006Entity)
    Function ListWysigtot2006() As List(Of WysigEntity)
        Dim strDatum As String
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                param.Value = Persoonl.POLISNO
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[Fetchwysigtot2006]", param)
                'Andriette 08/05/2013 verander die entity
                'Dim list As List(Of Wysig2006Entity) = New List(Of Wysig2006Entity)
                Dim list As List(Of WysigEntity) = New List(Of WysigEntity)
                While reader.Read()
                    'Dim item As Wysig2006Entity = New Wysig2006Entity()
                    Dim item As WysigEntity = New WysigEntity()
                    ' Andriette 08/05/2013 haal uit dien geen doel
                    'Dim description As Wysig2006Entity = New Wysig2006Entity
                    If reader("POLISNO") IsNot DBNull.Value Then
                        item.polisno = Trim(reader("POLISNO"))
                    Else
                        item.polisno = ""
                    End If
                    ' item.polisno = reader("polisno")
                    If reader("kode") IsNot DBNull.Value Then
                        item.kode = Trim(reader("kode"))
                    Else
                        item.kode = ""
                    End If
                    ' Andriette 05/06/2013 Verander die formaat van die datum om 24 uur horlosie te wys
                    If reader("datum") IsNot DBNull.Value Then
                        ' item.datum = Trim(reader("datum"))
                        item.datum = String.Format(reader("datum"), "{0:dd}/{0:mm}/{0:yyyy}  hh:mm:ss")
                    Else
                        item.datum = ""
                    End If

                    If reader("versekerde") IsNot DBNull.Value Then
                        item.versekerde = Trim(reader("versekerde"))
                    Else
                        item.versekerde = ""
                    End If

                    If reader("voorl") IsNot DBNull.Value Then
                        item.voorl = Trim(reader("voorl"))
                    Else
                        item.voorl = ""
                    End If

                    If reader("gebruiker") IsNot DBNull.Value Then
                        item.gebruiker = Trim(reader("gebruiker"))
                    Else
                        item.gebruiker = ""
                    End If

                    If reader("beskrywing") IsNot DBNull.Value Then
                        item.beskrywing = Trim(reader("beskrywing"))
                    Else
                        item.beskrywing = ""
                    End If

                    If reader("besk") IsNot DBNull.Value Then
                        If Persoonl.TAAL = 0 Then ' afrikaans
                            item.category = Trim(reader("besk"))
                        Else
                            If reader("beskEngels") IsNot DBNull.Value Then
                                item.category = Trim(reader("beskEngels"))
                            Else
                                item.category = ""
                            End If
                        End If
                        ' Andriette 08/05/2013 Haal die dubbelpunt uit
                        If item.category.Length > 0 Then

                            If item.category.Substring(Len(item.category) - 1, 1) = ":" Then
                                item.category = item.category.Substring(0, Len(item.category) - 1)
                            End If
                        Else

                        End If
                    Else
                        item.category = ""
                    End If


                    If item.datum.ToString <> "" Then

                        'strDatum = item.datum.ToString.Substring(0, 10)
                        strDatum = item.datum.ToString
                        ' strDatumdele = item.datum.ToString.Split("/")
                        ' Andriette 22/03/2013 Wys die volle datum met die tyd ingesluit
                        ' item.description = strDatumdele(2).Substring(0, 4) & "/" & strDatumdele(1) & "/" & strDatumdele(0) & "      "
                        item.description = strDatum


                        If item.category <> "" Then
                            item.description = item.description & " " & item.category

                            If item.beskrywing <> "" Then
                                item.description = item.description & " " & item.beskrywing
                            End If
                        Else
                            If item.beskrywing <> "" Then
                                item.description = item.description & " " & item.beskrywing
                            End If
                        End If


                    Else
                        If item.category <> "" Then
                            item.description = item.description & " " & item.category

                            If item.beskrywing <> "" Then
                                item.description = item.description & " " & item.beskrywing
                            End If
                        Else
                            If item.beskrywing <> "" Then
                                item.description = item.description & " " & item.beskrywing
                            End If
                        End If
                    End If

                    If Persoonl.TAAL = 0 Then
                        If item.gebruiker <> "" Then
                            item.description = item.description & " - Gebruiker: " & item.gebruiker
                        End If
                    Else
                        If item.gebruiker <> "" Then
                            item.description = item.description & " - User: " & item.gebruiker
                        End If
                    End If
                    'item.polisno = reader("polisno")
                    'item.kode = reader("kode")
                    'item.datum = reader("datum")
                    'item.versekerde = reader("versekerde")
                    'item.voorl = reader("voorl")
                    'item.gebruiker = reader("gebruiker")
                    'item.beskrywing = reader("beskrywing")
                    'If Persoonl.TAAL = 0 Then
                    '    item.description = CStr(reader("datum")) & " " & reader("beskrywing") & " ~ Gebruiker: " & reader("gebruiker")
                    'Else
                    '    item.description = CStr(reader("datum")) & " " & reader("beskrywing") & " ~ User: " & reader("gebruiker")
                    'End If
                    list.Add(item)
                End While
                Return list
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function


    Private Sub dgvAmendments_DataBindingComplete(sender As Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvAmendments.DataBindingComplete
        Dim strDate As String

        For intInskrywing = 0 To dgvAmendments.RowCount - 1
            strDate = dgvAmendments.Rows(intInskrywing).Cells("DateTime").Value
            dgvAmendments.Rows(intInskrywing).Cells("Wysdatum").Value = String.Format(strDate, "{0:dd/mm/yyyy  HH:MM:SS}")
        Next
    End Sub
End Class