Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports DAL

Public Class frmClaimsCatastrophe
    Dim blnCatastropheValidation As Boolean
    Dim blnInfoChanges As Boolean = False
    Dim intRow As Integer = 0

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

    Private Sub frmClaimsCatastrophe_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FieldsEnabled(False)

        dgvCatastrophe.AutoGenerateColumns = False
        dgvCatastrophe.DataSource = Nothing
        dgvCatastrophe.Refresh()

        Me.dtpCatastropheDate.Value = Today

        populateComboboxes()

        populateGrid()

        Me.btnApply.Enabled = False
        Me.btnOK.Enabled = False

        blnInfoChanges = False

    End Sub

    Private Sub btnVoegby_Click(sender As System.Object, e As System.EventArgs) Handles btnVoegby.Click
        FieldsEnabled(True)
        Me.txtCatastropheName.Text = ""
        Me.txtCatastropheExcessAmount.Text = ""
        Me.dtpCatastropheDate.Value = Today
        Me.cmbCatastropheType.Text = ""
        Me.btnApply.Enabled = True
        Me.btnOK.Enabled = True

        'voorgestelde herversekeringsbedrag
        CheckExcessAmount()
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        FieldsEnabled(True)

        If intRow >= 0 Then
            Me.txtCatastropheName.Text = Me.dgvCatastrophe.Item(0, intRow).Value
            Me.txtCatastropheExcessAmount.Text = Me.dgvCatastrophe.Item(3, intRow).Value
            Me.dtpCatastropheDate.Value = Me.dgvCatastrophe.Item(2, intRow).Value
            Me.cmbCatastropheType.SelectedValue = Me.dgvCatastrophe.Item(4, intRow).Value
        End If

        Me.txtCatastropheName.Enabled = False
        Me.btnApply.Enabled = True
        Me.btnOK.Enabled = True

        blnInfoChanges = False
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click

        Me.btnOK.Enabled = False

        'validation
        CatastropheValidation()

        'save
        If blnCatastropheValidation = True Then
            SaveCatastropheDetails()

            Me.txtCatastropheName.Text = ""
            Me.txtCatastropheExcessAmount.Text = ""
            Me.dtpCatastropheDate.Value = Today
            Me.cmbCatastropheType.Text = ""

            Me.Close()
        End If

    End Sub
    Private Sub FieldsEnabled(ByVal blnEnabled As Boolean)
        Me.txtCatastropheName.Enabled = blnEnabled
        Me.txtCatastropheExcessAmount.Enabled = blnEnabled
        Me.dtpCatastropheDate.Enabled = blnEnabled
        Me.cmbCatastropheType.Enabled = blnEnabled
    End Sub
    Private Sub populateComboBoxes()
        'Type       
        cmbCatastropheType.DataSource = BaseForm.FillCombo("eisdat.FetchKatastrofeTipes", "pkKatastrofeTipes", "Beskrywing", "", "", "", "")
        cmbCatastropheType.DisplayMember = "ComboBoxName"
        cmbCatastropheType.ValueMember = "ComboBoxID"

        cmbCatastropheType.Text = ""

    End Sub

    Private Sub dgvCatastrophe_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCatastrophe.CellClick
        FieldsEnabled(False)

        intRow = e.RowIndex

        If intRow >= 0 Then
            Me.txtCatastropheName.Text = Me.dgvCatastrophe.Item(0, e.RowIndex).Value
            Me.txtCatastropheExcessAmount.Text = Me.dgvCatastrophe.Item(3, e.RowIndex).Value
            Me.dtpCatastropheDate.Value = Me.dgvCatastrophe.Item(2, e.RowIndex).Value
            Me.cmbCatastropheType.SelectedValue = Me.dgvCatastrophe.Item(4, e.RowIndex).Value
        End If
        Me.btnApply.Enabled = False
        Me.btnOK.Enabled = False

        blnInfoChanges = False
    End Sub

    Private Sub dgvCatastrophe_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCatastrophe.CellDoubleClick
        FieldsEnabled(True)
        intRow = e.RowIndex

        If intRow >= 0 Then
            Me.txtCatastropheName.Text = Me.dgvCatastrophe.Item(0, e.RowIndex).Value
            Me.txtCatastropheExcessAmount.Text = Me.dgvCatastrophe.Item(3, e.RowIndex).Value
            Me.dtpCatastropheDate.Value = Me.dgvCatastrophe.Item(2, e.RowIndex).Value
            Me.cmbCatastropheType.SelectedValue = Me.dgvCatastrophe.Item(4, e.RowIndex).Value
        End If

        Me.txtCatastropheName.Enabled = False
        Me.btnApply.Enabled = True
        Me.btnOK.Enabled = True

        blnInfoChanges = False
    End Sub

    Private Sub CatastropheValidation()
        blnCatastropheValidation = False

        'Name 
        If Me.txtCatastropheName.Text = "" Then
            MsgBox("A Name must be filled in.", vbInformation)
            blnCatastropheValidation = False
            Me.txtCatastropheName.Focus()
            Me.btnOK.Enabled = True
            Exit Sub
        End If

        'Type 
        If Me.cmbCatastropheType.Text = "" Then
            MsgBox("A Type must be chosen.", vbInformation)
            blnCatastropheValidation = False
            Me.cmbCatastropheType.Focus()
            Me.btnOK.Enabled = True
            Exit Sub
        End If

        'date 
        If Me.dtpCatastropheDate.Text = "" Then
            MsgBox("A date must be chosen.", vbInformation)
            blnCatastropheValidation = False
            Me.dtpCatastropheDate.Focus()
            Me.btnOK.Enabled = True
            Exit Sub
        End If

        'Bybetalingsbedrag 
        If Me.txtCatastropheExcessAmount.Text = "" Then
            MsgBox("The Excess Amount must be filled in.", vbInformation)
            blnCatastropheValidation = False
            Me.txtCatastropheExcessAmount.Focus()
            Me.btnOK.Enabled = True
            Exit Sub
        End If

        If (Not (IsNumeric(txtCatastropheExcessAmount.Text))) Then
            MsgBox("Excess Amount value must be numeric!")
            Me.txtCatastropheExcessAmount.Focus()
            Me.btnOK.Enabled = True
            Exit Sub
        End If

        blnCatastropheValidation = True
    End Sub
    Private Sub SaveCatastropheDetails()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Naam", SqlDbType.NVarChar), _
                                                New SqlParameter("@Datum", SqlDbType.DateTime), _
                                                New SqlParameter("@Bybetalingsbedrag", SqlDbType.Money), _
                                                New SqlParameter("@fkKatastrofeTipes", SqlDbType.Int)}


                params(0).Value = Me.txtCatastropheName.Text
                params(1).Value = Me.dtpCatastropheDate.Value
                params(2).Value = Me.txtCatastropheExcessAmount.Text
                params(3).Value = Me.cmbCatastropheType.SelectedValue
                
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "eisdat.UpdateKatastrofe", params)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub btnApply_Click(sender As System.Object, e As System.EventArgs) Handles btnApply.Click
        Me.btnOK.Enabled = False

        'validation
        CatastropheValidation()

        'save
        If blnCatastropheValidation = True Then
            SaveCatastropheDetails()

            populateGrid()

            FieldsEnabled(False)
            Me.txtCatastropheName.Text = ""
            Me.txtCatastropheExcessAmount.Text = ""
            Me.dtpCatastropheDate.Value = Today
            Me.cmbCatastropheType.Text = ""

            blnInfoChanges = False

            Me.btnApply.Enabled = False
            Me.btnOK.Enabled = False
        End If
    End Sub
    Private Sub populateGrid()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim readerCat As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchKatastrofe")
                Dim CatastropheList As List(Of CatastropheEntity) = New List(Of CatastropheEntity)

                Do While readerCat.Read
                    Dim item As CatastropheEntity = New CatastropheEntity()

                    If readerCat("Naam") IsNot DBNull.Value Then
                        item.Naam = readerCat("Naam")
                    Else
                        item.Naam = ""
                    End If
                    If readerCat("Bybetalingsbedrag") IsNot DBNull.Value Then
                        item.Bybetalingsbedrag = readerCat("Bybetalingsbedrag")
                    Else
                        item.Bybetalingsbedrag = 0
                    End If
                    If readerCat("datum") IsNot DBNull.Value Then
                        item.Datum = readerCat("datum")
                    Else
                        item.Datum = Nothing
                    End If
                    If readerCat("fkKatastrofeTipes") IsNot DBNull.Value Then
                        item.fkKatastrofeTipes = readerCat("fkKatastrofeTipes")
                    Else
                        item.fkKatastrofeTipes = 0
                    End If
                    If readerCat("Beskrywing") IsNot DBNull.Value Then
                        item.Beskrywing = readerCat("Beskrywing")
                    Else
                        item.Beskrywing = ""
                    End If

                    CatastropheList.Add(item)
                Loop

                dgvCatastrophe.DataSource = CatastropheList

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    readerCat.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub CheckExcessAmount()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@Datum", SqlDbType.Date)}

                param(0).Value = Me.dtpCatastropheDate.Value

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchHerversekering", param)

                If reader.Read Then
                    Me.txtCatastropheExcessAmount.Text = String.Format("{0:N2}", reader("herversekeringsbedrag"))
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub dtpCatastropheDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpCatastropheDate.ValueChanged
        CheckExcessAmount()
        blnInfoChanges = True
    End Sub

    Private Sub txtCatastropheName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCatastropheName.TextChanged
        blnInfoChanges = True
    End Sub

    Private Sub cmbCatastropheType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCatastropheType.SelectedIndexChanged
        blnInfoChanges = True
    End Sub

    Private Sub txtCatastropheExcessAmount_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCatastropheExcessAmount.TextChanged
        blnInfoChanges = True
    End Sub

   
    Private Sub dgvCatastrophe_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCatastrophe.CellContentClick

    End Sub
End Class