Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports DAL
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.Form
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Diagnostics

Friend Class Endmeest
    Inherits BaseForm

    Dim pkEndosidentifikasie As Integer
    Dim pkEndmeest As Integer
    Dim blnaddNew As Boolean
    Dim blnendosloading As Boolean = False

    Private Sub Endmeest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        blnendosloading = True
        PopulateCombobox()
        cmbAreaDescription.SelectedValue = CInt(Persoonl.Area)
        refreshGrid()
        btnEndmeestcmd.Enabled = False
        btnEndmeestverwcmd.Enabled = False
        btnEnddetcmd.Enabled = False
        Me.Text = My.Application.Info.Title & " - Endorsement Master"
        blnendosloading = False
    End Sub

    Private Sub Enddetcmd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnEnddetcmd.Click
        If Me.txtEndosidentifikasie.Text = "" Then
            MsgBox("You need to select an endorsement identification.", MsgBoxStyle.Information)
            Exit Sub
        Else
            Enddet.txtTak.Text = Me.cmbAreaDescription.Text
            Enddet.Endosdetid.Text = dgvEndorsments.SelectedCells.Item(2).Value
            Enddet.Endosdetnaam.Text = dgvEndorsments.SelectedCells.Item(3).Value
            'AddingEndosDetail()
            Enddet.ShowDialog()
        End If
        Enddet.txtTak.Text = Me.cmbAreaDescription.Text

    End Sub

    Private Sub Endmeestbyvoeg_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnEndmeestbyvoeg.Click

        If validation() = True Then
            blnaddNew = True

            If checkForIdentifikansie() = True And blnaddNew = True Then
                MessageBox.Show("Endorsement identification already exist", "Flagship")
                Me.endmststatus.Text = String.Empty

            Else
                Save("Add/Edit")
                Me.endmststatus.Text = "Endorsement master record has been added"
            End If
            'If Len(Me.Endosidentifikasie.Text) = 0 Then
            '    MsgBox("Vul asseblief die endossement meester besonderhede in, naamlik: Endossement meester identifikasie, naam, taal, en of die endossement moet druk op al die polisse...Druk dan die 'Voeg endossement by' knoppie.")
            '    Exit Sub
            'End If

        Else
            Me.endmststatus.Text = String.Empty

        End If

    End Sub

    Private Sub Endmeestcmd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnEndmeestcmd.Click
        If validation() = True Then
            blnaddNew = False

            Save("Add/Edit")
            Me.endmststatus.Text = "Endorsement master record is updated"
        End If

    End Sub

    Private Sub Endmeestverwcmd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnEndmeestverwcmd.Click
        Dim strantw As String

        strantw = InputBox("Do you really want to delete endorsement master (Y or N)?", , "N")
        If strantw.ToString.ToUpper = "Y" Then
            delete()
            MsgBox("The endorsement master has been removed...", MsgBoxStyle.Information)
        Else
            Exit Sub
        End If
        refreshGrid()

        Me.txtEndosafreng.Text = ""
        Me.txtEndosDrukOrals.Text = ""
        Me.txtEndosDrukPolis.Text = ""
        Me.txtEndosidentifikasie.Text = ""
        Me.txtEndosnaam.Text = ""

    End Sub

    Public Sub refreshGrid()
        dgvEndorsments.AutoGenerateColumns = False
        dgvEndorsments.DataSource = Nothing
        dgvEndorsments.Refresh()
        dgvEndorsments.DataSource = populateGrid()
        Me.txtEndosidentifikasie.Focus()
        Me.txtEndosafreng.Text = ""
        Me.txtEndosDrukOrals.Text = ""
        Me.txtEndosDrukPolis.Text = ""
        txtEndosdrukpolistOld.Text = ""
        Me.endmststatus.Text = String.Empty
    End Sub
    Function populateGrid() As List(Of EndmeestEntity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@branchcode", SqlDbType.NVarChar)
                'Andriette 01/08/2013 verander die parameter
                ' param.Value = cmbAreaDescription.SelectedValue

                '  param.Value = Persoonl.Area
                param.Value = cmbAreaDescription.SelectedValue

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "endos5.EndMeesterADDING", param)

                Dim list As List(Of EndmeestEntity) = New List(Of EndmeestEntity)
                While reader.Read()
                    Dim item As EndmeestEntity = New EndmeestEntity()
                    item.Endosidentifikasie = reader("Endosidentifikasie")
                    item.Endosnaam = reader("Endosnaam")
                    item.EndosAfrEng = reader("EndosAfrEng")
                    item.Endosdrukorals = reader("Endosdrukorals")

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

    Private Sub cmbAreaDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAreaDescription.SelectedIndexChanged
        If Not blnendosloading Then
            refreshGrid()
            Me.txtEndosidentifikasie.Text = ""
            Me.txtEndosnaam.Text = ""
            Me.txtEndosafreng.Text = ""
            Me.txtEndosDrukOrals.Text = ""
            Me.txtEndosDrukPolis.Text = ""
            txtEndosdrukpolistOld.Text = ""
        End If

    End Sub


    Public Sub enableDetail(ByRef enable As Boolean)
        Me.txtEndosidentifikasie.Text = ""
        Me.txtEndosnaam.Text = ""
        Me.txtEndosafreng.Text = ""
        Me.txtEndosDrukOrals.Text = ""
        Me.txtEndosDrukPolis.Text = ""
        txtEndosdrukpolistOld.Text = ""

        'Me.Endmeestbyvoeg.Enabled = enable
        Me.btnEndmeestcmd.Enabled = enable
        Me.btnEndmeestverwcmd.Enabled = enable
        Me.btnEnddetcmd.Enabled = enable

    End Sub

    Private Sub dgvEndossemente_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            blnaddNew = False
            enableDetail(True)
            'Andriette 20/08/2013 verander die taal en wys volledig
            'Andriette 26/08/2013 toets verbeter
            Me.txtEndosDrukOrals.Text = If(dgvEndorsments.SelectedCells.Item(5).Value = "J" Or dgvEndorsments.SelectedCells.Item(5).Value = "Yes", "Yes", "No")
            Me.txtEndosidentifikasie.Text = dgvEndorsments.SelectedCells.Item(2).Value
            Me.txtEndosnaam.Text = dgvEndorsments.SelectedCells.Item(3).Value
            Me.txtEndosafreng.Text = dgvEndorsments.SelectedCells.Item(4).Value

            GetENDOS2001()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Sub GetENDOS2001() 'As List(Of Endos2001Entity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                               New SqlParameter("@Endosidentifikasie", SqlDbType.NVarChar)}

                params(0).Value = Persoonl.POLISNO
                params(1).Value = dgvEndorsments.SelectedCells.Item(2).Value

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[getEndos2001]", params)

                '          Dim list As List(Of Endos2001Entity) = New List(Of Endos2001Entity)
                'Andriette 26/08/2013 daar behoort net 1 inskrywing te wees dus =verander die read
                'While reader.Read()
                If reader.Read() Then
                    '             Dim item As Endos2001Entity = New Endos2001Entity()
                    'item.Endosidentifikasie = reader("polisno")
                    'item.Endosidentifikasie = reader("Endosidentifikasie")
                    'Andriette 20/08/2013 verander na die regte Yes/No ipv J en N
                    Me.txtEndosDrukPolis.Text = If(reader("Endos_druk_op_polis") = "J", "Yes", "No")
                    Me.txtEndosdrukpolistOld.Text = reader("Endos_druk_op_polis")
                    'item.Branchcode = reader("Branchcode")
                    '            list.Add(item)

                    '         End While
                Else
                    Me.txtEndosDrukPolis.Text = "No"
                    Me.txtEndosdrukpolistOld.Text = "No"
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try

    End Sub
    Public Function checkForIdentifikansie() As Boolean
        Dim blnreturnvalue As Boolean
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@Endosidentifikasie", SqlDbType.NVarChar), _
                                                New SqlParameter("@branchcode", SqlDbType.NVarChar)}
                param(0).Value = txtEndosidentifikasie.Text '(DetailDataGridView.SelectedCells.Item(2).Value)
                param(1).Value = cmbAreaDescription.SelectedValue

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "endos5.CheckEndosidentifikansieExist ", param)

                While reader.Read()
                    If reader("countRedes") = 0 Then
                        blnreturnvalue = False
                    Else
                        blnreturnvalue = True
                    End If
                End While
                Return blnreturnvalue
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function
    Sub Save(ByVal type As String)

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@endosnaam", SqlDbType.NVarChar), _
                                                New SqlParameter("@endosprint", SqlDbType.NVarChar), _
                                                New SqlParameter("@endosdrukorals", SqlDbType.NVarChar), _
                                                New SqlParameter("@endosAfrEng", SqlDbType.NVarChar), _
                                                New SqlParameter("@Endosidentifikasie", SqlDbType.NVarChar), _
                                                New SqlParameter("@Branchcode", SqlDbType.NVarChar), _
                                                New SqlParameter("@Type", SqlDbType.NVarChar), _
                                                New SqlParameter("@Polisno", SqlDbType.NVarChar)}

                If checkForIdentifikansie() = True And blnaddNew = True Then
                    MessageBox.Show("Endorsement identification already exist", "Flagship")
                    Me.endmststatus.Text = String.Empty

                    Me.txtEndosDrukPolis.Text = ""
                    Me.txtEndosdrukpolistOld.Text = ""
                    Me.txtEndosidentifikasie.Text = ""
                    Me.txtEndosnaam.Text = ""
                    Me.txtEndosafreng.Text = ""
                    Me.txtEndosDrukOrals.Text = ""
                    Exit Sub
                Else
                    Me.endmststatus.Text = "Endorsement master record has been added successfully"
                    params(0).Value = Me.txtEndosnaam.Text
                    'Andriette 20/08/2013 verander om die engels in gedagte te hou
                    If Me.txtEndosDrukPolis.Text = "Yes" Then
                        params(1).Value = "J"
                    ElseIf Me.txtEndosDrukPolis.Text = "No" Then
                        params(1).Value = "N"
                    Else
                        params(1).Value = ""
                    End If

                    If Me.txtEndosDrukOrals.Text = "Yes" Then
                        params(2).Value = "J"
                    ElseIf Me.txtEndosDrukOrals.Text = "No" Then
                        params(2).Value = "N"
                    Else
                        params(2).Value = ""
                    End If

                    params(3).Value = Me.txtEndosafreng.Text
                    params(4).Value = Me.txtEndosidentifikasie.Text
                    params(5).Value = cmbAreaDescription.SelectedValue
                    params(6).Value = type
                    params(7).Value = Persoonl.POLISNO

                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[endos5].[UpdateOrAddEndmeest]", params)
                    Me.endmststatus.Text = "Endorsement master record has been added successfully"
                    If blnaddNew = True Then
                        If txtEndosDrukPolis.Text = "J" Then
                            BESKRYWING = txtEndosidentifikasie.Text + "-" + txtEndosnaam.Text
                            UpdateWysig(78, BESKRYWING)
                            Me.endmststatus.Text = "Endorsement master record has been added successfully"
                        End If
                    Else
                        Me.endmststatus.Text = "Endorsement master record has been altered successfully"
                        BESKRYWING = txtEndosidentifikasie.Text + "-" + txtEndosnaam.Text

                        If txtEndosDrukPolis.Text <> txtEndosdrukpolistOld.Text Then
                            If txtEndosDrukPolis.Text = "J" Or txtEndosDrukPolis.Text = "Yes" Then
                                UpdateWysig(78, BESKRYWING)
                            Else
                                If txtEndosDrukPolis.Text = "N" Or txtEndosDrukPolis.Text = "No" Then
                                    UpdateWysig(79, BESKRYWING)
                                End If
                            End If
                        End If
                    End If
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        refreshGrid()

        Me.txtEndosafreng.Text = ""
        Me.txtEndosDrukOrals.Text = ""
        Me.txtEndosDrukPolis.Text = ""
        txtEndosdrukpolistOld.Text = ""
        Me.txtEndosidentifikasie.Text = ""
        Me.txtEndosnaam.Text = ""
        Me.txtEndosidentifikasie.Focus()
        Me.endmststatus.Text = String.Empty
    End Sub
    Function validation() As Boolean
        If Len(txtEndosidentifikasie.Text) <> 3 Then
            MsgBox("The identification is incorrect. It should be 2 numeric and 1 alpha, eg. 01A for the first endorsement that will print first on the policy.")
            txtEndosidentifikasie.Focus()
            Return False
            Exit Function
        End If
        If Mid(txtEndosidentifikasie.Text, Len(txtEndosidentifikasie.Text)) <> "A" And Mid(txtEndosidentifikasie.Text, Len(txtEndosidentifikasie.Text)) <> "E" Then
            MsgBox("Endorsement language should either be entered as 'A' for Afrikaans or 'E' for English.")
            txtEndosidentifikasie.Focus()
            Return False
            Exit Function
        End If
        If txtEndosafreng.Text <> "Afrikaans" And txtEndosafreng.Text <> "English" Then
            MsgBox("Only Afrikaans or English may be entered ")
            Me.txtEndosafreng.Focus()
            Return False
            Exit Function
        End If
        'Andriette 20/08/2013 verander die skerm na Engels
        If txtEndosDrukOrals.Text <> "Yes" And txtEndosDrukOrals.Text <> "No" Then
            MsgBox("The endorsement printed on all policies should be 'Yes' or 'No' only.")
            txtEndosDrukOrals.Focus()
            Return False
            Exit Function
        End If

        If Len(txtEndosDrukPolis.Text) > 0 Then
            If txtEndosDrukPolis.Text <> "Yes" And txtEndosDrukPolis.Text <> "No" Then
                MsgBox("The endorsement printed on all policies should be 'Yes' or 'No' only.")
                txtEndosDrukPolis.Focus()
                Return False
                Exit Function
            End If
        End If
        Return True
    End Function
    Sub delete()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Branchcode", SqlDbType.NVarChar), _
                                                New SqlParameter("@Endosidentifikasie", SqlDbType.NVarChar)}
                params(0).Value = cmbAreaDescription.SelectedValue
                params(1).Value = Me.txtEndosidentifikasie.Text

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[endos5].[DeleteWysigendos]", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try

        Exit Sub
    End Sub
    Private Sub dgvEndossemente_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Me.endmststatus.Text = String.Empty
    End Sub



    Private Sub dgvEndossemente_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            blnaddNew = False
            enableDetail(True)
            'Andriette 20/08/2013 verander die taal en wys volledig
            'Andriette 26/08/2013 toets verbeter
            Me.txtEndosDrukOrals.Text = If(dgvEndorsments.SelectedCells.Item(5).Value = "J" Or dgvEndorsments.SelectedCells.Item(5).Value = "Yes", "Yes", "No")
            Me.txtEndosidentifikasie.Text = dgvEndorsments.SelectedCells.Item(2).Value
            Me.txtEndosnaam.Text = dgvEndorsments.SelectedCells.Item(3).Value
            Me.txtEndosafreng.Text = dgvEndorsments.SelectedCells.Item(4).Value

            GetENDOS2001()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub PopulateCombobox()
        'Andriette 01/08/2013 verander die combobox na die entity toe

        'Andriette 01/08/2013 verander na die gebruik van die combobox entity
        cmbAreaDescription.DataSource = BaseForm.FillCombo("poldata5.ListArea", "pkarea", "DisplayField", "", "")
        cmbAreaDescription.DisplayMember = "ComboBoxName"
        cmbAreaDescription.ValueMember = "ComboBoxID"
        cmbAreaDescription.SelectedIndex = -1 'GetComboIndex(Persoonl.Area, cmbAreaDescription.DataSource)

    End Sub

    Private Sub dgvEndorsments_DataBindingComplete(sender As Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvEndorsments.DataBindingComplete
        For intrekordtel = 0 To dgvEndorsments.RowCount - 1
            dgvEndorsments.Rows(intrekordtel).Cells("endosdrukorals").Value = If(dgvEndorsments.Rows(intrekordtel).Cells("endosdrukoralsdonotshow").Value.ToString.ToUpper = "J", "Everywhere", "Local")
        Next
    End Sub
End Class