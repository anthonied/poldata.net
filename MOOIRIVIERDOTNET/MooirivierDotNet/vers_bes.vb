Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports DAL



Friend Class vers_bes
    Inherits BaseForm
    Public Suksesvol As Boolean = True


    Sub ApplyRecordset()

    End Sub
    Private Sub gdvNamesList_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

        'Kry volgende item nommer
        'Call kryitem()
        ''Kry polis nommer wat gebruiker geselekteer het
        'MSFlexGrid1.col = 2

        ''Kry rekord in persoonl
        'Persoonl.Index = "pn_index"
        'Persoonl.Seek("=", MSFlexGrid1.Text)

        'Me.Hide()
        MsgBox(dgvNamesList.SelectedRows.Count)

    End Sub

    'Sub PopulateGrid()
    ' andriette 2013/01/31 
    Function PopulateGrid() As Boolean
        Dim strgebruikkode As String = ""
        PopulateGrid = True
        'MSFlexGrid1.Refresh()
        Dim param() As SqlParameter = {New SqlParameter(PARM_VERSEKERDE, SqlDbType.NVarChar), _
                                        New SqlParameter("@area", SqlDbType.NVarChar), _
                                        New SqlParameter("@ID", SqlDbType.NVarChar)}
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection


                If Persoonl.VERSEKERDE Is Nothing Then
                    param(0).Value = ""
                Else
                    param(0).Value = Persoonl.VERSEKERDE

                End If

                'If Gebruiker.titel = "Programmeerder" Then
                '    param(1).Value = ""
                'Else
                strgebruikkode = Gebruiker.BranchCodes.left(Gebruiker.BranchCodes.Length - 1)
                strgebruikkode = strgebruikkode.right(strgebruikkode.Length - 1)
                param(1).Value = strgebruikkode
                '  End If

                param(2).Value = Form1.ID_NOM.Text
                ' Andriette 2013/01/30 roep in ander stored procedure sodat die area beskrywing op die vorm gewys kan word
                'Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlVERSEKERDE", param)
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonl", param)

                'Andriette
                ' toets vir rekords in die reader
                If Not reader.HasRows Then
                    MsgBox("No insured was found for this criteria")
                    PopulateGrid = False
                    Me.Suksesvol = False
                    Me.Hide()
                    Close()

                    Exit Function
                End If

                dgvNamesList.DataSource = Nothing

                Dim kieslist As List(Of PERSOONLEntity) = New List(Of PERSOONLEntity)

                While reader.Read()
                    Dim item As PERSOONLEntity = New PERSOONLEntity()
                    If reader("VERSEKERDE") IsNot DBNull.Value Then
                        item.VERSEKERDE = reader("VERSEKERDE")
                    End If
                    If reader("ADRES") IsNot DBNull.Value Then
                        item.ADRES = reader("ADRES")
                    End If
                    If reader("ADRES1") IsNot DBNull.Value Then
                        item.ADRES1 = reader("ADRES1")
                    End If
                    If reader("ADRES2") IsNot DBNull.Value Then
                        item.ADRES2 = reader("ADRES2")
                    End If

                    If reader("GEKANS") IsNot DBNull.Value Then
                        item.GEKANS = reader("GEKANS")
                        If reader("GEKANS") = True Then
                            item.Active_Icon = "O"
                        Else
                            item.Active_Icon = "P"
                        End If
                    End If
                    'Andriette 12/09/2013 voeg die ID weer by
                    If reader("ID_NOM") IsNot DBNull.Value Then
                        item.ID_NOM = reader("ID_NOM")
                    End If

                    If reader("POLISNO") IsNot DBNull.Value Then
                        item.POLISNO = reader("POLISNO")
                    End If

                    If reader("PREMIEKODE") IsNot DBNull.Value Then
                        item.PREMIEKODE = reader("PREMIEKODE")
                    End If

                    If reader("selfoon") IsNot DBNull.Value Then
                        item.selfoon = reader("selfoon")
                    End If

                    If reader("VOORL") IsNot DBNull.Value Then
                        item.VOORL = reader("VOORL")
                    End If

                    If reader("WERK_TEL2") IsNot DBNull.Value Then
                        item.WERK_TEL2 = reader("WERK_TEL2")
                    End If

                    ' Andriette 2013/01/30
                    ' Voeg die area_besk by
                    If reader("Area_besk") IsNot DBNull.Value Then
                        item.Area_Besk = reader("Area_besk")
                    End If

                    
                    kieslist.Add(item)
                End While

                If kieslist.Count > 0 Then

                    dgvNamesList.AutoGenerateColumns = False
                    dgvNamesList.DataSource = kieslist
                    ' Andriette 2013/01/30
                    ' sit regmerkies ev verkeerdmerkies in die active colom
                    ' maak die telefoon nr's : werk_tel, selfoon, huis_tel none as null maar ook none as 0
                    dgvNamesList.ReadOnly = False
                    Me.Suksesvol = True
                    dgvNamesList.Visible = True
                    dgvNamesList.Refresh()
                    kieslist = Nothing
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function


    Private Function PopulateFromRegno() As Boolean
        Dim blnResult As Boolean = True
        Dim strGebruikerKodes As String = ""

        PopulateFromRegno = True

        Dim param() As SqlParameter = {New SqlParameter("@n_plaat", SqlDbType.NVarChar), _
                                        New SqlParameter("@gebruiker", SqlDbType.NVarChar), _
                                        New SqlParameter("@branchcode", SqlDbType.NVarChar)}
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                param(0).Value = Form1.strRegistrationseek

                'If Gebruiker.titel = "Programmeerder" Then
                '    param(1).Value = "Programmeerder"
                'Else
                param(1).Value = Gebruiker.titel
                'End If
                strGebruikerKodes = Gebruiker.BranchCodes.left(Gebruiker.BranchCodes.Length - 1)
                strGebruikerKodes = strGebruikerKodes.right(strGebruikerKodes.Length - 1)
                param(2).Value = strGebruikerKodes

                ' Andriette 2013/01/30 roep in ander stored procedure sodat die area beskrywing op die vorm gewys kan word
                'Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlVERSEKERDE", param)
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertueibyNPlaat", param)

                'Andriette
                ' toets vir rekords in die reader
                If Not reader.HasRows Then
                    MsgBox("No insured was found for this criteria")
                    PopulateFromRegno = False
                    Me.Suksesvol = False
                    Me.Hide()
                    Close()
                    Exit Function
                End If

                dgvNamesList.DataSource = Nothing

                Dim entkieslist As List(Of PERSOONLEntity) = New List(Of PERSOONLEntity)

                While reader.Read()
                    Dim item As PERSOONLEntity = New PERSOONLEntity()
                    If reader("VERSEKERDE") IsNot DBNull.Value Then
                        item.VERSEKERDE = reader("VERSEKERDE")
                    End If
                    If reader("ADRES") IsNot DBNull.Value Then
                        item.ADRES = reader("ADRES")
                    End If
                    If reader("ADRES1") IsNot DBNull.Value Then
                        item.ADRES1 = reader("ADRES1")
                    End If
                    If reader("ADRES2") IsNot DBNull.Value Then
                        item.ADRES2 = reader("ADRES2")
                    End If

                    If reader("GEKANS") IsNot DBNull.Value Then
                        item.GEKANS = reader("GEKANS")
                        If reader("GEKANS") = True Then
                            item.Active_Icon = "O"
                        Else
                            item.Active_Icon = "P"
                        End If
                    End If
                    'Andriette 12/09/2013 voeg die ID weer by
                    If reader("ID_NOM") IsNot DBNull.Value Then
                        item.ID_NOM = reader("ID_NOM")
                    End If

                    If reader("POLISNO") IsNot DBNull.Value Then
                        item.POLISNO = reader("POLISNO")
                    End If

                    If reader("PREMIEKODE") IsNot DBNull.Value Then
                        item.PREMIEKODE = reader("PREMIEKODE")
                    End If

                    If reader("selfoon") IsNot DBNull.Value Then
                        item.selfoon = reader("selfoon")
                    End If

                    If reader("VOORL") IsNot DBNull.Value Then
                        item.VOORL = reader("VOORL")
                    End If

                    If reader("WERK_TEL2") IsNot DBNull.Value Then
                        item.WERK_TEL2 = reader("WERK_TEL2")
                    End If

                    If reader("Area_besk") IsNot DBNull.Value Then
                        item.Area_Besk = reader("Area_besk")
                    End If

                    If reader("Nommerplate") IsNot DBNull.Value Then
                        item.Nommerplate = reader("Nommerplate")
                    End If
                    entkieslist.Add(item)
                End While

                If entkieslist.Count > 0 Then

                    dgvNamesList.AutoGenerateColumns = False
                    dgvNamesList.DataSource = entkieslist
                End If

                Me.Suksesvol = True
                dgvNamesList.Visible = True
                dgvNamesList.Refresh()
                entkieslist = Nothing
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try

        Return blnResult

    End Function

    Private Sub gdvNamesList_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNamesList.CellClick
        Dim strpolicynumber As String = dgvNamesList.Item(2, e.RowIndex).Value
        'Andriette 07/10/2013 skuif die fokus na die eerste veld anders bly die heel regs
        'If Grid2.RowCount > 0 Then
        '    Grid2.FirstDisplayedScrollingColumnIndex = 0
        'End If
        Persoonl = FetchPersoonForVers_Bes(strpolicynumber)
        'Andriette 20/09/2013 verander na close
        'Me.Hide()
        If dgvNamesList.SelectedRows.Count < 1 Then
            Me.Suksesvol = False
            dgvNamesList.ClearSelection()
        End If
        'MSFlexGrid1.ClearSelection()
        Me.Close()
        'MSFlexGrid1.FirstDisplayedScrollingColumnIndex = 3
        'MSFlexGrid1.ClearSelection()
    End Sub

    Private Sub vers_bes_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        dgvNamesList.ClearSelection()
    End Sub

    ' Andriette 14/03/2013 As vorm toegemaak word 
    Private Sub vers_bes_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Andriette 20/09/2013 haal uit
        '   
        If dgvNamesList.SelectedRows.Count < 1 Then
            Me.Suksesvol = False
            Persoonl.POLISNO = Nothing
            dgvNamesList.ClearSelection()
        End If
        dgvNamesList.FirstDisplayedScrollingColumnIndex = 3
        dgvNamesList.ClearSelection()
        dgvNamesList.DataSource = Nothing

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
    End Sub

    Private Sub vers_bes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvNamesList.DataSource = Nothing
        dgvNamesList.Refresh()

        If Form1.strOpsoekKat = "Regno" Then
            PopulateFromRegno()
        Else
            PopulateGrid()
        End If
        'Andriette 20/09/2013 haal seleksie af

        ' Andriette 05/03/2013 Toets om te kyk of daar enige rekords gevind is
        If Me.Suksesvol = True Then

            ' Andriette 05/03/2013 As daar net 1 gevind is, vul sommer klaar die grid 
            If dgvNamesList.RowCount > 0 Then
                If dgvNamesList.Rows.Count = 1 And dgvNamesList.Item(2, 0).Value <> "" Then
                    'Andriette 01/08/2013 verander die global variable
                    Persoonl = FetchPersoonForVers_Bes(glbPolicyNumber)

                    Me.Suksesvol = True

                    Me.Suksesvol = True
                    Me.Hide()
                End If
            End If
        End If
        ' MsgBox("number of selected rows" + MSFlexGrid1.SelectedRows.Count.ToString)
        'Andriette 18/09/2013 stel die cursor
        dgvNamesList.ClearSelection()
        dgvNamesList.FirstDisplayedScrollingColumnIndex = 3
        dgvNamesList.CurrentCell = Nothing
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub


    Private Sub gdvNamesList_DataBindingComplete(sender As Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvNamesList.DataBindingComplete
        Dim strnplaat As String = ""
        For i = 0 To dgvNamesList.RowCount - 1

            If (dgvNamesList.Rows(i).Cells("huis_tel").Value = "Geen") Or (dgvNamesList.Rows(i).Cells("huis_tel").Value = "0") Then
                dgvNamesList.Rows(i).Cells("huis_tel").Value = ""

            End If
            If (dgvNamesList.Rows(i).Cells("werk_tel").Value = "Geen") Or (dgvNamesList.Rows(i).Cells("werk_tel").Value = "0") Then
                dgvNamesList.Rows(i).Cells("werk_tel").Value = ""

            End If
            If (dgvNamesList.Rows(i).Cells("selfoon").Value = "Geen") Or (dgvNamesList.Rows(i).Cells("selfoon").Value = "0") Then
                dgvNamesList.Rows(i).Cells("selfoon").Value = ""

            End If
            'Andriette 11/10/2013 verander die hele ry kleur ipv net die blokkie 
            If dgvNamesList.Rows(i).Cells("Gekans").Value = True Then

                dgvNamesList.Rows(i).Cells("ActiveIcon").Value = "O"
                dgvNamesList.Rows(i).Cells("ActiveIcon").Style.ForeColor = Color.Red
                '    MSFlexGrid1.Rows(i).DefaultCellStyle.BackColor = Color.BlanchedAlmond
            ElseIf dgvNamesList.Rows(i).Cells("Gekans").Value = False Then
                dgvNamesList.Rows(i).Cells("ActiveIcon").Value = "P"
                dgvNamesList.Rows(i).Cells("ActiveIcon").Style.ForeColor = Color.Green
                '  MSFlexGrid1.Rows(i).DefaultCellStyle.BackColor = Color.Azure
            End If

        Next (i)

        If Form1.strOpsoekKat = "Regno" Then
            dgvNamesList.Columns("Vehicles").Visible = True
        Else
            dgvNamesList.Columns("Vehicles").Visible = False
        End If
    End Sub


End Class