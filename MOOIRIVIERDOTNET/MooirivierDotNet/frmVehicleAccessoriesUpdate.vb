Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports DAL
Friend Class frmVehicleAccessoriesUpdate
    'Kobus 27/05/2014 create the Class to update Vehicle Accessories from a txt file
    Inherits System.Windows.Forms.Form

    'Dim appPath As String
    Dim intRow As Integer
    Dim strFilename As String
    Dim strVehicleAccesAfr As String
    Dim strVehicleAccesEng As String
    Dim bitVehicleAcces As SByte
    Dim intBitValue As Integer
    Dim bitVertoon As SByte
    Private Sub btnBrowse_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnBrowse.Click
        CommonDialog1Open.ShowDialog()
        If CommonDialog1Open.FileName <> "" Then
            Me.txtPath.Text = CommonDialog1Open.FileName
        End If
    End Sub
    'Cancel button onclick - close/unload form
    Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click

        If Me.txtPath.Text = "" Then
            CommonDialog1Open.ShowDialog()
            If CommonDialog1Open.FileName <> "" Then
                Me.txtPath.Text = CommonDialog1Open.FileName
                Dim strSearchWithinThis As String = Me.txtPath.Text
                Dim strSearchForThis As String = "Voertuie"
                Dim intFirstFind As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
                If intFirstFind = -1 Then
                    MsgBox("The wrong file is selected.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            Else
                MsgBox("Please select the Vehicle Accessories file.", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If
        If Me.txtPath.Text <> "" Then
            Dim strSearchWithinThis As String = Me.txtPath.Text
            Dim strSearchForThis As String = "Voertuie"
            Dim intFirstFind As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
            If intFirstFind = -1 Then
                MsgBox("The wrong file is selected.", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If
        strFilename = Me.txtPath.Text

        Me.Label1.Visible = True
        Me.Label1.Text = "Number of Vehicle Accessories updated:"
        Me.btnCancel.Enabled = False
        Me.btnOk.Enabled = False
        Me.btnBrowse.Enabled = False

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'Kobus 24/06/2014 comment out
        'Me.listStatus.Visible = True '
        'Me.listStatus.Items.Add(("Update the existing Vehicle accessories table."))
        'Me.Refresh()

        If updateVehichileAccessories() Then
            Me.listStatus.Visible = True
            Me.listStatus.Items.Add(("Vehicle Accessories Update completed."))
            Me.Refresh()
            Me.Cursor = System.Windows.Forms.Cursors.Default
            MsgBox("Vehicle Accessories Update completed.", MsgBoxStyle.Information)

            Me.btnCancel.Enabled = True
            Me.btnOk.Enabled = True
            Me.Label1.Text = "Number of Vehicle Accessories updated:"
            Me.btnCancel.Text = "Close"
            Me.btnOk.Enabled = False
            'Kobus 24/06/2014 comment out
            'Me.listStatus.Visible = False
            'Kobus 24/06/2014 comment out
            'Me.Label2.Text = "Update completed."
        Else
            MsgBox("Vehicle Accessories Update Failed.", MsgBoxStyle.Exclamation)
            Me.Label1.Visible = False
            'Kobus 24/06/2014 comment out
            'Me.Label2.Text = "Update the existing Vehicle accessories table."
            'Kobus 24/06/2014 verander van My.Application.Info.Title & " -  Database update (Vehicle accessories)"
            Me.Text = "       Vehicle Accessories Update"
            Me.btnBrowse.Enabled = True
            Me.txtPath.Text = ""
            'Kobus 24/06/2014 comment out
            'Me.listStatus.Items.Clear()
            Me.listStatus.Visible = True
            'Kobus 24/06/2014 comment out
            Me.listStatus.Visible = True '
            Me.listStatus.Items.Add(("Vehicle accessories Update Failed"))
            Me.Refresh()
            Me.lblProgress.Text = ""
            Me.btnCancel.Enabled = True
            Me.btnOk.Enabled = True
            Me.Label1.Text = ""
            Me.btnCancel.Text = "Cancel"
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If


    End Sub
    Private Function updateVehichileAccessories() As Boolean

        Try
            intRow = 0
            strVehicleAccesAfr = ""
            strVehicleAccesEng = ""
            bitVehicleAcces = 0
            intBitValue = 0
            bitVertoon = 0

            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader(strFilename)
            If System.IO.File.Exists(strFilename) = True Then
                Dim strReader As String
                strReader = fileReader.ReadLine()
                If Trim(strReader) = "" Then
                    MsgBox("The wrong file is selected.")
                    Return False
                    Exit Function
                End If

                Dim strSearchWithinThis As String = Trim(strReader)
                Dim strSearchForThis As String = "|"
                Dim intFirstFind As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
                If intFirstFind = -1 Then
                    MsgBox("The wrong file is selected.", MsgBoxStyle.Information)
                    Return False
                    Exit Function
                End If

                Do While Trim(strReader) <> ""
                    If intRow <> 0 Then
                        strReader = fileReader.ReadLine()
                    End If

                    If strReader = "" Then
                        Exit Do

                    Else

                        Dim myarray() As String = strReader.Split("|")
                        If Trim(myarray(0)) = "" Then
                            MsgBox("The wrong file is selected.", MsgBoxStyle.Information)
                            Return False
                            Exit Function
                        Else
                            strVehicleAccesAfr = Trim(myarray(0).Replace("""", " "))
                        End If

                        If Trim(myarray(1)) = "" Then
                            MsgBox("The wrong file is selected.", MsgBoxStyle.Information)
                            Return False
                            Exit Function
                        Else
                            strVehicleAccesEng = Trim(myarray(1).Replace("""", " "))
                        End If
                        If Trim(myarray(2)) <> "1" Then
                            myarray(2) = "0"
                        End If
                        If Trim(myarray(3)) <> "1" Then
                            myarray(3) = "0"
                        End If
                        If Trim(myarray(4)) <> "1" Then
                            myarray(4) = "0"
                        End If
                        bitVertoon = myarray(2)
                        bitVehicleAcces = myarray(3)
                        intBitValue = myarray(4)



                        Using conn As SqlConnection = SqlHelper.GetConnection
                            Dim param() As SqlParameter = {New SqlParameter("@Bit", SqlDbType.Bit), _
                                                           New SqlParameter("@BitValue", SqlDbType.Int), _
                                                           New SqlParameter("@BeskrywingAfrikaans", SqlDbType.NVarChar), _
                                                           New SqlParameter("@BeskrywingEngels", SqlDbType.NVarChar), _
                                                           New SqlParameter("@VertoonGespesifiseerd", SqlDbType.Bit)}
                            param(0).Value = bitVehicleAcces
                            param(1).Value = intBitValue
                            param(2).Value = strVehicleAccesAfr
                            param(3).Value = strVehicleAccesEng
                            param(4).Value = bitVertoon


                            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdatevehicleAccessoriesFromFile]", param)

                            If conn.State = ConnectionState.Open Then
                                conn.Close()
                            End If

                        End Using




                    End If

                    intRow = intRow + 1
                    lblProgress.Text = CStr(intRow)
                    lblProgress.Refresh()
                Loop

            Else
                MsgBox("File does not exist.", vbInformation)
                Return False
                Exit Function
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
            updateErrorList(True)
            Cursor = System.Windows.Forms.Cursors.Default
            Exit Function
        End Try

        Me.lblProgress.Text = CStr(intRow)
        Me.lblProgress.Refresh()


        Me.Label1.Text = "Number of Vehicle Accessories updated:"
        Me.lblProgress.Text = intRow
        Cursor = System.Windows.Forms.Cursors.Default
        Return True

    End Function
    'Update listbox with current error
    Public Function updateErrorList(ByRef resetError As Boolean) As Object
        If Err.Number <> 0 Then
            Me.listStatus.Items.Add("     !Attention: " & Err.Description)
            Me.Refresh()
            If resetError Then
                Err.Clear()
            End If
        End If
        Return False
    End Function
    Private Sub frmCellphonesUpdate_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Label1.Visible = False
        'Kobus 24/06/2014 comment out
        'Me.Label2.Text = "Update the Vehicle accessories table."
        'Kobus 24/06/2014 verander van My.Application.Info.Title & " -  Database update (Vehicle accessories information)"
        Me.Text = "      Vehicle Accessories Update"
        Me.btnBrowse.Enabled = True
        Me.txtPath.Text = ""
        Me.listStatus.Visible = True
        'Kobus 24/06/2014 voegby
        Me.listStatus.Visible = True '
        Me.listStatus.Items.Add(("Update the Vehicle Accessories table."))
        Me.Refresh()
        Me.lblProgress.Text = ""
        Me.btnCancel.Enabled = True
        Me.btnOk.Enabled = True
        Me.Label1.Text = ""
        Me.btnCancel.Text = "Cancel"

    End Sub
    Private Sub txtPath_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPath.TextChanged
        Me.btnCancel.Enabled = True
        Me.btnOk.Enabled = True
        Me.Label1.Text = ""
        Me.btnCancel.Text = "Cancel"

    End Sub

End Class
