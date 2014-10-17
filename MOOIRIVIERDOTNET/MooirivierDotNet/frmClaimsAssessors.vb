Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports DAL
Public Class frmClaimsAssessors
    Dim blnInfochanges As Boolean = False
    Dim blnAssessorValidation As Boolean
    Dim blnSoek As Boolean = False
    Dim intRow As Integer
    Dim intPKAssessor As Integer = 0
    Dim blnBeneficiary As Boolean = False

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        blnfkAssessor = False
        frmClaimsBeneficiary.txtSearchAssessor.Text = ""
        intfkAssessor = 0
        blnAssessorClaim = False

        If blnInfochanges = True Then
            If MsgBox("Are you sure you want to cancel and loose all your changes?", vbYesNo) = MsgBoxResult.Yes Then
                Me.Close()
            Else
                Exit Sub
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub dgvAssessors_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAssessors.CellClick
        FieldsEnabled(False)

        intRow = e.RowIndex

        intPKAssessor = Me.dgvAssessors.Item(0, intRow).Value
        intfkAssessor = intPKAssessor
        GetAssessorData()

        blnInfochanges = False
    End Sub

    Private Sub btnVoegby_Click(sender As System.Object, e As System.EventArgs) Handles btnVoegby.Click
        FieldsEnabled(True)
        Me.txtAddress1.Text = ""
        Me.txtEmail.Text = ""
        Me.txtAddress2.Text = ""
        Me.txtAssessor.Text = ""
        Me.txtCellnr.Text = ""
        Me.txtEmail.Text = ""
        Me.txtFaxnr.Text = ""
        Me.txtPostalCode.Text = ""
        Me.txtSubburb.Text = ""
        Me.txtTelnr.Text = ""
        Me.txtTown.Text = ""
        Me.chkBeneficiary.Checked = False
        intPKAssessor = 0
        intfkAssessor = intPKAssessor
    End Sub
    Private Sub FieldsEnabled(ByVal blnEnabled As Boolean)
        Me.txtAddress1.Enabled = blnEnabled
        Me.txtEmail.Enabled = blnEnabled
        Me.txtAddress2.Enabled = blnEnabled
        Me.txtAssessor.Enabled = blnEnabled
        Me.txtEmail.Enabled = blnEnabled
        Me.txtCellnr.Enabled = blnEnabled
        Me.txtFaxnr.Enabled = blnEnabled
        Me.txtTelnr.Enabled = blnEnabled
        Me.cmdPostalCodes.Enabled = blnEnabled
        Me.chkBeneficiary.Enabled = False
        Me.btnApply.Enabled = blnEnabled
        Me.btnOK.Enabled = blnEnabled
        If blnfkAssessor = True Then
            Me.btnOK.Enabled = True
        End If
        Me.Label13.Enabled = blnEnabled
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        FieldsEnabled(True)

        blnInfochanges = False
    End Sub

    Private Sub txtAssessor_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAssessor.TextChanged
        blnInfochanges = True
    End Sub

    Private Sub txtCellnr_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCellnr.TextChanged
        blnInfochanges = True
    End Sub

    Private Sub txtEmail_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtEmail.TextChanged
        blnInfochanges = True
    End Sub

    Private Sub txtTelnr_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTelnr.TextChanged
        blnInfochanges = True
    End Sub

    Private Sub txtFaxnr_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFaxnr.TextChanged
        blnInfochanges = True
    End Sub

    Private Sub chkBeneficiary_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkBeneficiary.CheckedChanged
        blnInfochanges = True
    End Sub

    Private Sub txtAddress1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAddress1.TextChanged
        blnInfochanges = True
    End Sub

    Private Sub txtAddress2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAddress2.TextChanged
        blnInfochanges = True
    End Sub

    Private Sub txtSubburb_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSubburb.TextChanged
        blnInfochanges = True
    End Sub

    Private Sub txtTown_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTown.TextChanged
        blnInfochanges = True
    End Sub

    Private Sub txtPostalCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPostalCode.TextChanged
        blnInfochanges = True
    End Sub

    Private Sub frmClaimsIncome_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FieldsEnabled(False)

        dgvAssessors.AutoGenerateColumns = False
        dgvAssessors.DataSource = Nothing
        dgvAssessors.Refresh()

        populateGrid()

        blnInfochanges = False
    End Sub
    Private Sub populateGrid()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params() As SqlParameter = {New SqlParameter("@AssessorName", SqlDbType.NVarChar)}
                If blnSoek = True Then
                    params(0).Value = Me.txtSearch.Text
                Else
                    params(0).Value = ""
                End If

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchAssessor", params)

                Dim AssessorList As List(Of ClaimsAssessorEntity) = New List(Of ClaimsAssessorEntity)

                Do While reader.Read
                    Dim item As ClaimsAssessorEntity = New ClaimsAssessorEntity()

                    If reader("AssessorName") IsNot DBNull.Value Then
                        item.AssessorName = reader("AssessorName")
                    Else
                        item.AssessorName = ""
                    End If
                    If reader("AssessorCell") IsNot DBNull.Value Then
                        item.AssessorCell = reader("AssessorCell")
                    Else
                        item.AssessorCell = ""
                    End If
                    If reader("AssessorEmail") IsNot DBNull.Value Then
                        item.AssessorEmail = reader("AssessorEmail")
                    Else
                        item.AssessorEmail = ""
                    End If
                    If reader("pkAssessor") IsNot DBNull.Value Then
                        item.pkAssessor = reader("pkAssessor")
                    Else
                        item.pkAssessor = 0
                    End If

                    AssessorList.Add(item)
                Loop

                dgvAssessors.DataSource = AssessorList

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    reader.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub btnApply_Click(sender As System.Object, e As System.EventArgs) Handles btnApply.Click
        Me.btnOK.Enabled = False

        'validation
        AssessorValidation()

        'save
        If blnAssessorValidation = True Then
            SaveAssessorDetails()

            populateGrid()

            FieldsEnabled(False)
            Me.txtAddress1.Text = ""
            Me.txtEmail.Text = ""
            Me.txtAddress2.Text = ""
            Me.txtAssessor.Text = ""
            Me.txtCellnr.Text = ""
            Me.txtEmail.Text = ""
            Me.txtFaxnr.Text = ""
            Me.txtPostalCode.Text = ""
            Me.txtSubburb.Text = ""
            Me.txtTelnr.Text = ""
            Me.txtTown.Text = ""
            Me.chkBeneficiary.Checked = False

            blnInfochanges = False
        End If
        If blnfkAssessor = True Then
            If blnAssessorClaim = True Then
                SaveAssessorClaim()
                frmClaimsList.populateAssessorsGrid()
            End If
            blnfkAssessor = False
            blnAssessorClaim = False
            Me.Close()
        End If
    End Sub
    Private Sub SaveAssessorDetails()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@pkAssessor", SqlDbType.Int), _
                                                New SqlParameter("@AssessorName", SqlDbType.NVarChar), _
                                                New SqlParameter("@AssessorEmail", SqlDbType.NVarChar), _
                                                New SqlParameter("@AssessorAddress1", SqlDbType.NVarChar), _
                                                New SqlParameter("@AssessorAddress2", SqlDbType.NVarChar), _
                                                New SqlParameter("@AssessorSubburb", SqlDbType.NVarChar), _
                                                New SqlParameter("@AssessorTown", SqlDbType.NVarChar), _
                                                New SqlParameter("@AssessorPCode", SqlDbType.NVarChar), _
                                                New SqlParameter("@AssessorFax", SqlDbType.NVarChar), _
                                                New SqlParameter("@AssessorTel", SqlDbType.NVarChar), _
                                                New SqlParameter("@AssessorCell", SqlDbType.NVarChar)}
               
                params(0).Value = intPKAssessor
                params(1).Value = Me.txtAssessor.Text
                params(2).Value = Me.txtEmail.Text
                params(3).Value = Me.txtAddress1.Text
                params(4).Value = Me.txtAddress2.Text
                params(5).Value = Me.txtSubburb.Text
                params(6).Value = Me.txtTown.Text
                params(7).Value = Me.txtPostalCode.Text
                params(8).Value = Me.txtFaxnr.Text
                params(9).Value = Me.txtTelnr.Text
                params(10).Value = Me.txtCellnr.Text

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "eisdat.UpdateAssessor", params)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Private Sub SaveAssessorClaim()
        Dim intPKAssessorsPerClaim As Integer = 0

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@pkAssessorsPerClaim", SqlDbType.Int), _
                                                New SqlParameter("@Eisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@fkAssessor", SqlDbType.NVarChar), _
                                                New SqlParameter("@Cancel", SqlDbType.Bit)}

                params(0).Value = intPKAssessorsperclaim
                params(1).Value = glbEisno
                params(2).Value = intfkAssessor
                params(3).Value = False

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "eisdat.UpdateAssessorsPerClaim", params)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        Me.btnOK.Enabled = False

        'validation
        AssessorValidation()

        'save
        If blnAssessorValidation = True Then
            SaveAssessorDetails()

            Me.txtAddress1.Text = ""
            Me.txtEmail.Text = ""
            Me.txtAddress2.Text = ""
            Me.txtAssessor.Text = ""
            Me.txtCellnr.Text = ""
            Me.txtEmail.Text = ""
            Me.txtFaxnr.Text = ""
            Me.txtPostalCode.Text = ""
            Me.txtSubburb.Text = ""
            Me.txtTelnr.Text = ""
            Me.txtTown.Text = ""
            Me.chkBeneficiary.Checked = False
            If blnfkAssessor = True Then
                If blnAssessorClaim = True Then
                    SaveAssessorClaim()
                    frmClaimsList.populateAssessorsGrid()
                End If
                blnfkAssessor = False
                blnAssessorClaim = False
                Me.Close()
            End If
            blnfkAssessor = False
            blnAssessorClaim = False
            Me.Close()
        End If
    End Sub
    Private Sub AssessorValidation()
        blnAssessorValidation = False

        'Name 
        If Me.txtAssessor.Text = "" Then
            MsgBox("A name must be filled in.", vbInformation)
            blnAssessorValidation = False
            Me.txtAssessor.Focus()
            Me.btnOK.Enabled = True
            Exit Sub
        End If

        blnAssessorValidation = True
    End Sub

    Private Sub dgvAssessors_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAssessors.CellDoubleClick
        FieldsEnabled(True)

        intRow = e.RowIndex
        intPKAssessor = Me.dgvAssessors.Item(0, intRow).Value
        intfkAssessor = intPKAssessor
        GetAssessorData()

    End Sub

    Private Sub btnSoek_Click(sender As System.Object, e As System.EventArgs) Handles btnSoek.Click
        FieldsEnabled(False)
        blnSoek = True

        populateGrid()
        blnSoek = False
    End Sub
    Private Sub GetAssessorData()
        If intRow >= 0 Then
            Me.chkBeneficiary.Checked = False
            blnBeneficiary = False
            Try
                Using conn As SqlConnection = SqlHelper.GetConnection

                    Dim params() As SqlParameter = {New SqlParameter("@pkAssessor", SqlDbType.Int)}

                    params(0).Value = Me.dgvAssessors.Item(0, intRow).Value

                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchAssessorpkAssessor", params)

                    Dim AssessorList As List(Of ClaimsAssessorEntity) = New List(Of ClaimsAssessorEntity)

                    If reader.Read Then
                        Dim item As ClaimsAssessorEntity = New ClaimsAssessorEntity()

                        If reader("AssessorName") IsNot DBNull.Value Then
                            item.AssessorName = reader("AssessorName")
                        Else
                            item.AssessorName = ""
                        End If
                        If reader("AssessorCell") IsNot DBNull.Value Then
                            item.AssessorCell = reader("AssessorCell")
                        Else
                            item.AssessorCell = ""
                        End If
                        If reader("AssessorEmail") IsNot DBNull.Value Then
                            item.AssessorEmail = reader("AssessorEmail")
                        Else
                            item.AssessorEmail = ""
                        End If
                        If reader("pkAssessor") IsNot DBNull.Value Then
                            item.pkAssessor = reader("pkAssessor")
                        Else
                            item.pkAssessor = 0
                        End If
                        If reader("AssessorAddress1") IsNot DBNull.Value Then
                            item.AssessorAddress1 = reader("AssessorAddress1")
                        Else
                            item.AssessorAddress1 = ""
                        End If
                        If reader("AssessorAddress2") IsNot DBNull.Value Then
                            item.AssessorAddress2 = reader("AssessorAddress2")
                        Else
                            item.AssessorAddress2 = ""
                        End If
                        If reader("AssessorFax") IsNot DBNull.Value Then
                            item.AssessorFax = reader("AssessorFax")
                        Else
                            item.AssessorFax = ""
                        End If
                        If reader("AssessorPCode") IsNot DBNull.Value Then
                            item.AssessorPCode = reader("AssessorPCode")
                        Else
                            item.AssessorPCode = ""
                        End If
                        If reader("AssessorSubburb") IsNot DBNull.Value Then
                            item.AssessorSubburb = reader("AssessorSubburb")
                        Else
                            item.AssessorSubburb = ""
                        End If
                        If reader("AssessorTel") IsNot DBNull.Value Then
                            item.AssessorTel = reader("AssessorTel")
                        Else
                            item.AssessorTel = ""
                        End If
                        If reader("AssessorTown") IsNot DBNull.Value Then
                            item.AssessorTown = reader("AssessorTown")
                        Else
                            item.AssessorTown = ""
                        End If

                        strAssessorName = item.AssessorName
                        If blnfkAssessor = True Then
                            frmClaimsBeneficiary.txtSearchAssessor.Text = strAssessorName
                        End If

                        intPKAssessor = item.pkAssessor
                        Me.txtAddress1.Text = item.AssessorAddress1
                        Me.txtEmail.Text = item.AssessorEmail
                        Me.txtAddress2.Text = item.AssessorAddress2
                        Me.txtAssessor.Text = item.AssessorName
                        Me.txtCellnr.Text = item.AssessorCell
                        Me.txtEmail.Text = item.AssessorEmail
                        Me.txtFaxnr.Text = item.AssessorFax
                        Me.txtPostalCode.Text = item.AssessorPCode
                        Me.txtSubburb.Text = item.AssessorSubburb
                        Me.txtTelnr.Text = item.AssessorTel
                        Me.txtTown.Text = item.AssessorTown
                        GetBeneficiary()
                        If blnBeneficiary = True Then
                            Me.chkBeneficiary.Checked = True
                        Else
                            Me.chkBeneficiary.Checked = False
                        End If

                    Else
                        MsgBox("The Assessor could not be found.", vbInformation)
                    End If
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                        reader.Close()
                    End If
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
        blnInfoChanges = False
    End Sub
    Private Sub GetBeneficiary()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params() As SqlParameter = {New SqlParameter("@fkAssessor", SqlDbType.NVarChar)}

                params(0).Value = intfkAssessor

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "eisdat.FetchBegunstigdefkAssessor", params)

                If reader.Read Then
                    blnBeneficiary = True
                End If

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    reader.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    
    Private Sub cmdPostalCodes_Click(sender As System.Object, e As System.EventArgs) Handles cmdPostalCodes.Click
        PoskodesSoek.txtFormToPopulate.Text = Me.Name
        PoskodesSoek.ShowDialog()
    End Sub
End Class