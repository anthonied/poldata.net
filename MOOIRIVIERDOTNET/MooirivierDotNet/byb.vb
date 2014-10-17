Option Strict Off
Option Explicit On

Imports System.Data.SqlClient
Imports DAL
Friend Class byb

    Inherits BaseForm

    Private Sub Bejaarde_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Bejaarde.CheckedChanged
        Try
            If Me.Bejaarde.Checked Then
                Bybetalingsin.Text = Bybetalings.bejaarde
            End If
        Catch
            Bybetalingsin.Text = ""
        End Try
        Me.Bybstatus.Text = ""
    End Sub

    Private Sub Bybverander_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Bybverander.Click

        Save("Add/Edit")
        Bybetalings = FetchBybetaling()
        Me.Bybstatus.Text = "Excess record is changed"

    End Sub

    Private Sub cmbAreaDescription_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbAreaDescription.SelectedIndexChanged
        'Andriette 30/07/2013 toets eers om te sien of dit gestel is
        If cmbAreaDescription.SelectedIndex > 0 Then

            Bybetalings = FetchBybetaling()
            Me.Gewone.Checked = True
            Try
                If Me.Gewone.Checked Then
                    Bybetalingsin.Text = Bybetalings.gewone
                Else
                    Bybetalingsin.Text = String.Empty
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If

    End Sub

    Private Sub Duisend_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Duisend.CheckedChanged
        Try
            If Me.Duisend.Checked Then
                Bybetalingsin.Text = Bybetalings.duisend
            End If
        Catch
            Bybetalingsin.Text = ""
        End Try
        Me.Bybstatus.Text = ""
    End Sub

    Private Sub Eander_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Eander.CheckedChanged
        Try
            If Me.Eander.Checked Then
                Bybetalingsin.Text = Bybetalings.eander
            End If
        Catch
            Bybetalingsin.Text = ""
        End Try
    End Sub

    Private Sub Ebejaarde_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Ebejaarde.CheckedChanged
        Try
            If Me.Ebejaarde.Checked Then
                Bybetalingsin.Text = Bybetalings.ebejaarde
            End If
        Catch
            Bybetalingsin.Text = ""
        End Try
        Me.Bybstatus.Text = ""
    End Sub

    Private Sub Eduisend_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Eduisend.CheckedChanged
        Try
            If Me.Eduisend.Checked Then
                Bybetalingsin.Text = Bybetalings.eduisend
            End If
        Catch
            Bybetalingsin.Text = ""
        End Try
        Me.Bybstatus.Text = ""
    End Sub

    Private Sub Egewone_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Egewone.CheckedChanged
        Try
            If Me.Egewone.Checked Then
                Bybetalingsin.Text = Bybetalings.egewone
            End If
        Catch
            Bybetalingsin.Text = ""
        End Try
        Me.Bybstatus.Text = ""
    End Sub
    Private Sub byb_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim strArea As String
        cmbAreaDescription.SelectedIndex = -1
        'Andriette 30/07/2013 verander die Combo om in te pas by die Combo-entity
        'cmbAreaDescription.DisplayMember = "Area_Besk"
        'cmbAreaDescription.ValueMember = "pkarea"
        'cmbAreaDescription.DataSource = ListAreaDropdownByb()
        'Me.Bybstatus.Text = ""
        ' Andriette 31/07/2013 verander na selectedindex
        'strArea = Form1.AREA.SelectedValue
        strArea = Persoonl.Area
        cmbAreaDescription.ValueMember = "ComboBoxID"
        cmbAreaDescription.DisplayMember = "ComboBoxName"
        cmbAreaDescription.DataSource = FillCombo("poldata5.ListArea", "pkarea", "DisplayField", "", "")
        Me.Bybstatus.Text = ""
        cmbAreaDescription.SelectedIndex = GetComboIndex(strArea, cmbAreaDescription.DataSource)

        '  cmbAreaDescription.SelectedValue = strArea
    End Sub
    Private Sub Gewone_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Gewone.CheckedChanged
        Try
            If Me.Gewone.Checked Then
                Bybetalingsin.Text = Bybetalings.gewone

            End If
        Catch
            Bybetalingsin.Text = ""
        End Try
        Me.Bybstatus.Text = ""
    End Sub

    Private Sub rdAlternatief_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rdAlternatief.CheckedChanged
        Try
            If Me.rdAlternatief.Checked Then
                Bybetalingsin.Text = Bybetalings.alternatief
            End If
        Catch
            Bybetalingsin.Text = ""
        End Try
        Me.Bybstatus.Text = ""
    End Sub


    Private Sub rdAnder_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rdAnder.CheckedChanged
        Try
            If Me.rdAnder.Checked Then
                Bybetalingsin.Text = Bybetalings.ander
            End If
        Catch
            Bybetalingsin.Text = ""
        End Try
        Me.Bybstatus.Text = ""
    End Sub


    Private Sub rdEAlternatief_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rdEAlternatief.CheckedChanged
        Try
            If Me.rdEAlternatief.Checked Then
                Bybetalingsin.Text = Bybetalings.ealternatief
            End If
        Catch
            Bybetalingsin.Text = ""
        End Try
        Me.Bybstatus.Text = ""
    End Sub


    Private Sub rdEAnder_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rdEAnder.CheckedChanged
        Try
            If Me.rdEAnder.Checked Then
                Bybetalingsin.Text = Bybetalings.eander
            End If
        Catch
            Bybetalingsin.Text = ""
        End Try
        Me.Bybstatus.Text = ""
    End Sub


    Private Sub rdEOpsioneel_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rdEOpsioneel.CheckedChanged
        Try
            If Me.rdEOpsioneel.Checked Then
                Bybetalingsin.Text = Bybetalings.eopsioneel
            End If
        Catch
            Bybetalingsin.Text = ""
        End Try
        Me.Bybstatus.Text = ""
    End Sub


    Private Sub rdOpsioneel_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rdOpsioneel.CheckedChanged
        Try
            If Me.rdOpsioneel.Checked Then
                Bybetalingsin.Text = Bybetalings.opsioneel
            End If
        Catch
            Bybetalingsin.Text = ""
        End Try
        Me.Bybstatus.Text = ""
    End Sub
    Function FetchBybetaling() As BybetalingsEntity
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@BranchCode", SqlDbType.NVarChar)

                param.Value = Persoonl.Area
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[endos5].[FectchBybetalingByBranchCode]", param)

                Dim item As BybetalingsEntity = New BybetalingsEntity()
                If reader.Read() Then
                    If Not IsDBNull(reader("gewone")) Then
                        item.gewone = reader("gewone")
                    End If
                    If Not IsDBNull(reader("bejaarde")) Then
                        item.bejaarde = reader("bejaarde")
                    End If
                    If Not IsDBNull(reader("duisend")) Then
                        item.duisend = reader("duisend")
                    End If
                    If Not IsDBNull(reader("ander")) Then
                        item.ander = reader("ander")
                    End If
                    If Not IsDBNull(reader("egewone")) Then
                        item.egewone = reader("egewone")
                    End If
                    If Not IsDBNull(reader("ebejaarde")) Then
                        item.ebejaarde = reader("ebejaarde")
                    End If
                    If Not IsDBNull(reader("eduisend")) Then
                        item.eduisend = reader("eduisend")
                    End If
                    If Not IsDBNull(reader("eander")) Then
                        item.eander = reader("eander")
                    End If
                    If Not IsDBNull(reader("alternatief")) Then
                        item.alternatief = reader("alternatief")
                    End If
                    If Not IsDBNull(reader("ealternatief")) Then
                        item.ealternatief = reader("ealternatief")
                    End If

                    If Not IsDBNull(reader("opsioneel")) Then
                        item.opsioneel = reader("opsioneel")
                    End If

                    If Not IsDBNull(reader("eopsioneel")) Then
                        item.eopsioneel = reader("eopsioneel")
                    End If
                    item.BranchCode = reader("BranchCode")
                End If
                Return item
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
                Dim params() As SqlParameter = {New SqlParameter("@Field", SqlDbType.NVarChar), _
                                                New SqlParameter("@Description", SqlDbType.NVarChar), _
                                                New SqlParameter("@Branchcode", SqlDbType.NVarChar), _
                                                New SqlParameter("@Type", SqlDbType.NVarChar)}

                If Me.Gewone.Checked Then
                    params(0).Value = "gewone"
                End If

                If Me.Bejaarde.Checked Then
                    params(0).Value = "bejaarde"
                End If
                If Me.Duisend.Checked Then
                    params(0).Value = "duisend"
                End If
                If Me.Bejaarde.Checked Then
                    params(0).Value = "bejaarde"
                End If
                If Me.rdAnder.Checked Then
                    params(0).Value = "ander"
                End If
                If Me.Egewone.Checked Then
                    params(0).Value = "egewone"
                End If
                If Me.Ebejaarde.Checked Then
                    params(0).Value = "ebejaarde"
                End If
                If Me.Eduisend.Checked Then
                    params(0).Value = "enduisend"
                End If
                If Me.Bejaarde.Checked Then
                    params(0).Value = "bejaarde"
                End If
                If Me.rdEAnder.Checked Then
                    params(0).Value = "eander"
                End If
                If Me.rdAlternatief.Checked Then
                    params(0).Value = "alternatief"
                End If
                If Me.rdEAlternatief.Checked Then
                    params(0).Value = "ealternatief"
                End If
                If Me.rdOpsioneel.Checked Then
                    params(0).Value = "opsioneel"
                End If
                If Me.rdEOpsioneel.Checked Then
                    params(0).Value = "eopsioneel"
                End If

                params(1).Value = Bybetalingsin.Text
                'Andriette 31/07/2013 verander na selectedindex
                'params(2).Value = cmbAreaDescription.SelectedValue
                params(2).Value = cmbAreaDescription.SelectedIndex
                params(3).Value = "Add/Edit"

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "endos5.BybetalingsAddition", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class