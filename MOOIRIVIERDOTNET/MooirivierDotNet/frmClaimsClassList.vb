Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports DAL

Public Class frmClaimsClassList
    Dim clsRun As New clsRuns()
    Dim intRow As Integer = 0

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmClaimsClassList_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        populateGrid()
        dgvClassList.ClearSelection()
    End Sub
    Private Sub populateGrid()
        Dim intRow As Integer = 0
        dgvClassList.Rows.Clear()
        intRow = intRow + 1
        'Voertuie
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@polisno", SqlDbType.NVarChar)}
                params(0).Value = glbPolicyNumber

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuieForPremie", params)
                Do While reader.Read
                    clsRun.GetVehicleDescription(reader("ander"), reader("kode"), reader("eeu"), reader("jaar"))
                    dgvClassList.Rows.Insert(0, reader("pkVoertuie"), "Vehicle", strVoertuieMaak & " " & strVoertuieBesk, _
                                                       reader("n_plaat"), String.Format("{0:N2}", reader("waarde")), "Motor", intRow)
                    intRow = intRow + 1
                Loop

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    reader.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        'huise
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                    New SqlParameter("@Cancelled", SqlDbType.Int)}
                params(0).Value = glbPolicyNumber
                params(1).Value = False
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchHuisWithGrid", params)
                Do While reader.Read
                    If (reader("WAARDE_HE R") IsNot DBNull.Value And reader("WAARDE_HE R") <> 0) And (reader("WAARDE_HB R") IsNot DBNull.Value And reader("WAARDE_HB R") <> 0) Then
                        dgvClassList.Rows.Insert(0, reader("pkhuis"), "Homeowner", reader("adres"), "", String.Format("{0:N2}", reader("WAARDE_HE R")), "Huiseienaar", intRow)
                        intRow = intRow + 1
                        dgvClassList.Rows.Insert(0, reader("pkhuis"), "Household contents", reader("adres"), "", String.Format("{0:N2}", reader("WAARDE_HB R")), "Huisbewoner", intRow)
                        intRow = intRow + 1
                    ElseIf reader("WAARDE_HE R") IsNot DBNull.Value And reader("WAARDE_HE R") <> 0 Then
                        dgvClassList.Rows.Insert(0, reader("pkhuis"), "Homeowner", reader("adres"), "", String.Format("{0:N2}", reader("WAARDE_HE R")), "Huiseienaar", intRow)
                        intRow = intRow + 1
                    ElseIf reader("WAARDE_HB R") IsNot DBNull.Value And reader("WAARDE_HB R") <> 0 Then
                        dgvClassList.Rows.Insert(0, reader("pkhuis"), "Household contents", reader("adres"), "", String.Format("{0:N2}", reader("WAARDE_HB R")), "Huisbewoner", intRow)
                        intRow = intRow + 1
                    End If
                Loop

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    reader.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        'Alle risiko
        Dim strClassTypeAR As String = ""
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                    New SqlParameter("@Cancelled", SqlDbType.Int)}
                params(0).Value = glbPolicyNumber
                params(1).Value = False
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAlleriskWithGrid", params)
                Do While reader.Read
                    If reader("beskrywing") = "Alle risiko ongespesifiseerd" Then
                        strClassTypeAR = "Alle risiko ongespesifiseerd"
                    Else
                        strClassTypeAR = "Alle Risiko"
                    End If
                    dgvClassList.Rows.Insert(0, reader("pkAllerisk"), "All Risk", reader("beskryf"), reader("serienommer"), String.Format("{0:N2}", reader("dekking")), strClassTypeAR, intRow)
                    intRow = intRow + 1
                Loop

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    reader.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        'Persoonlike ongevalle
        dgvClassList.Rows.Insert(0, 0, "Personal accident", "Personal accident", "", String.Format("{0:N2}", 0), "Persoonlike ongevalle", intRow)
        intRow = intRow + 1

        'Persoonlike regsaanspreeklikheid
        dgvClassList.Rows.Insert(0, 0, "Personal liability", "Personal liability", "", String.Format("{0:N2}", 0), "Persoonlike ongevalle", intRow)
        intRow = intRow + 1

        'Waterlewe
        dgvClassList.Rows.Insert(0, 0, "Waterlife", "Waterlife", "", String.Format("{0:N2}", 0), "Waterlewe", intRow)
        intRow = intRow + 1

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@polisno", SqlDbType.NVarChar)}
                params(0).Value = glbPolicyNumber

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlByPolisno", params)
                If reader.Read Then
                    'Huis bystand
                    If reader("epc") IsNot DBNull.Value And reader("epc") > 0 Then
                        dgvClassList.Rows.Insert(0, 0, "Homeassist", "Homeassist", "", String.Format("{0:N2}", 0), "Huis bystand", intRow)
                        intRow = intRow + 1
                    End If

                    'Geleentheidsvoertuie
                    If reader("courtesyv") IsNot DBNull.Value And reader("courtesyv") > 0 Then
                        dgvClassList.Rows.Insert(0, 0, "Courtesy Vehicle", "Courtesy Vehicle", "", String.Format("{0:N2}", 0), "Geleentheidsvoertuig", intRow)
                        intRow = intRow + 1
                    End If
                End If

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    reader.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        'Selfone
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@polisno", SqlDbType.NVarChar)}
                params(0).Value = glbPolicyNumber

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "insCELL.FetchInsCellForDetails", params)
                Do While reader.Read
                    'Selfone
                    dgvClassList.Rows.Insert(0, reader("pkInscell"), "Cellphones", reader("phone_make") & " " & reader("phone_model"), reader("sel_tel"), String.Format("{0:N2}", reader("phone_price")), "Selfone", intRow)
                    intRow = intRow + 1
                Loop

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    reader.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try


    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If intRow <> 0 Then
            GetClassData()
            Me.Close()
        Else
            MsgBox("You must choose a class.", vbInformation)
        End If
    End Sub

    Private Sub dgvClassList_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClassList.CellClick
        introw = e.RowIndex
        GetClassData()
    End Sub

    Private Sub GetClassData()
        intpkClassItem = Me.dgvClassList.Item(0, intRow).Value
        dblClassCover = Me.dgvClassList.Item(4, intRow).Value
        strClassType = Me.dgvClassList.Item(1, intRow).Value
        strClaimItemDescription = Me.dgvClassList.Item(2, intRow).Value
        frmClaimsList.txtClaimDescription3.Text = strClaimItemDescription
        frmClaimsList.txtClaimDescription4.Text = Me.dgvClassList.Item(3, intRow).Value
        'default claim class na wat gekies was
        frmClaimsList.cmbClaimClassType.Text = Me.dgvClassList.Item(5, intRow).Value
        frmClaimsList.dtpClaimDate.Focus()
        Me.Close()
    End Sub

    Private Sub dgvClassList_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClassList.CellContentClick

    End Sub

    Private Sub dgvClassList_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClassList.CellDoubleClick
        intRow = e.RowIndex
        GetClassData()
        Me.Close()
    End Sub
End Class