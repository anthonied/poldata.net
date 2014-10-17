Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports DAL
Imports System.IO

Friend Class frmCommunicationManagement
    'Kobus 12/06/2014 create the Class to Manage Communications
    Inherits System.Windows.Forms.Form


    Dim appPath As String
    Dim intRow As Integer
    Dim strFilename As String
    Dim strVehicleAccesAfr As String
    Dim strVehicleAccesEng As String
    Dim bitVehicleAcces As SByte
    Dim intBitValue As Integer
    Dim bitVertoon As SByte
    Dim dateDocDate As Date
    Dim strDocPath As String
    Dim strServerPath As String
    Dim strDocDir As String
    Dim strReturnPath As String
    Dim strEposOnderwerp As String
    Dim strEposadress As String
    Dim strEposInhoud As String
    Dim strEposAanhangsels As String
    Dim strresult As String
    Dim strFileName2 As String
    'Kobus 16/07/2014 voegby
    Dim intFkArchiveCategories As Integer
    Dim strFileDesc As String

    Private Sub btnBrowse_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnBrowse.Click
        
        CommonDialog1Open.ShowDialog()
        'Kobus 30/06/2014 voegby
        Me.CommonDialog1Open.InitialDirectory = "C:\"
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
            'Kobus 30/06/2014 voegby
            Me.CommonDialog1Open.InitialDirectory = "C:\"
            MsgBox("Please select a valid file to archive.", MsgBoxStyle.Information)
            btnBrowse.Enabled = True
            btnOk.Enabled = True
            Me.txtPath.Focus()
            Exit Sub
        End If

        If CommonDialog1Open.FileName <> "" Then
            Me.txtPath.Text = CommonDialog1Open.FileName

            strFilename = Me.txtPath.Text
            strFileName2 = strFilename.Substring((InStrRev(strFilename, ".") - 1), (Len(strFilename) - InStrRev(strFilename, ".") + 1))


            Me.btnOk.Enabled = True
            Me.btnBrowse.Enabled = False

            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If

        If cmbCategory.Text = "" And strFilename <> "" Then
            MsgBox("Please select an Archive category.", MsgBoxStyle.Information)
            cmbCategory.Focus()
            Exit Sub
        End If

        createNewFileName()

        UpdateArchive()

        Me.btnCancel.Text = "Close"
        Me.btnOk.Enabled = False
        Me.btnBrowse.Enabled = False
        Me.Cursor = System.Windows.Forms.Cursors.Default


    End Sub
    Private Sub createNewFileName()
        '******************************************************************************
        '*Author       : Kobus
        '*Created      : 17/06/2014
        '*Purpose      : Control filename for Archive table and directory
        '******************************************************************************
        dateDocDate = Now()

        strServerPath = Form1.gen_getArchivePath() 'The location on the server
        strDocDir = strServerPath & glbPolicyNumber 'The location on server with policy number
        'Path stored in db - no server path only subdirectory
        strDocPath = glbPolicyNumber & "\" & Trim(strFileDesc) & "_" & Format(dateDocDate, "ddMMyyyy_hhmmss") & strFileName2
        strReturnPath = strServerPath & strDocPath
        'End If
        Try
            My.Computer.FileSystem.MoveFile(strFilename, strReturnPath,
        FileIO.UIOption.AllDialogs,
        FileIO.UICancelOption.ThrowException)
            lblNewFileName.Text = "New File Name " & strReturnPath
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub UpdateArchive()

        '******************************************************************************
        '*Author       : Kobus
        '*Created      : 17/06/2014
        '*Purpose      : update Archive table
        '******************************************************************************
        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim params() As SqlParameter = {New SqlParameter("@Taal", SqlDbType.Int)}
            If Persoonl.TAAL = 0 Then
                params(0).Value = 0
            Else
                params(0).Value = 1
            End If

            'Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchArchiveCategories", params)

            'If reader.Read Then
            '    intFkArchiveCategories = reader("fkArchiveCategories")
            'End If
            
        End Using

        Try
            strEposOnderwerp = ""
            strEposInhoud = Trim(txtComments.Text)
            strEposOnderwerp = ""
            strEposadress = ""
            strEposAanhangsels = ""
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                     New SqlParameter("@path", SqlDbType.NVarChar), _
                                     New SqlParameter("@epos_onderwerp", SqlDbType.NVarChar), _
                                     New SqlParameter("@epos_adres", SqlDbType.NVarChar), _
                                     New SqlParameter("@epos_inhoud", SqlDbType.NVarChar), _
                                     New SqlParameter("@epos_aanhangsels", SqlDbType.NVarChar), _
                                     New SqlParameter("@gebruiker", SqlDbType.NVarChar), _
                                     New SqlParameter("@datum", SqlDbType.DateTime), _
                                     New SqlParameter("@Incoming", SqlDbType.Bit), _
                                     New SqlParameter("@fkArchiveCategories", SqlDbType.Int)}
                'New SqlParameter("@kategorie", SqlDbType.NVarChar), _

                params(0).Value = glbPolicyNumber
                'params(1).Value = Trim(Me.cmbCategory.Text)
                params(1).Value = strDocPath
                params(2).Value = strEposOnderwerp
                params(3).Value = strEposadress
                params(4).Value = strEposInhoud

                If strEposAanhangsels Is Nothing Then
                    params(5).Value = ""
                Else
                    params(5).Value = strEposAanhangsels
                End If

                params(6).Value = Gebruiker.Naam
                params(7).Value = dateDocDate
                'Kobus 01/07/2014 voegby om nuwe veld in tabel te vul
                params(8).Value = 1
                params(9).Value = intFkArchiveCategories


                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.InsertArchiveDocs", params)

            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try


        If Dir(strServerPath, vbDirectory) = "" Then
            MkDir(strServerPath)
        End If
        If Dir(strDocDir, vbDirectory) = "" Then
            MkDir(strDocDir)
        End If

    End Sub

    Private Sub frmCommunicationManagement_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        If Trim(glbPolicyNumber) = "" Then
            MsgBox("You must first select a policy.", MsgBoxStyle.Information)
            Me.Close()
            Exit Sub
        End If
        'Kobus 17/07/2014 voegby
        intFkArchiveCategories = 0
        strFileDesc = ""
        'Kobus 01/07/2014 voegby
        Me.CommonDialog1Open.InitialDirectory = "C:\"
        'Kobus 24/06/2014 verander van My.Application.Info.Title & " -  Communication Management for policy (" & glbPolicyNumber & ")"
        Me.Text = "      Communication Management for policy (" & glbPolicyNumber & ")"
        Me.btnBrowse.Enabled = True
        Me.txtPath.Text = ""
        Me.btnCancel.Enabled = True
        Me.btnOk.Enabled = True
        Me.btnCancel.Text = "Cancel"
        'Kobus 24/06/2014 comment out
        'Me.lblComments.Enabled = False
        'Me.txtComments.Enabled = False

        PopulateComboCategories()

    End Sub

    Private Sub txtPath_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPath.TextChanged
        Me.btnCancel.Enabled = True
        Me.btnOk.Enabled = True
        'Me.Label1.Text = ""
        Me.btnCancel.Text = "Cancel"
        strFilename = txtPath.Text
        testFileType()
    End Sub

    Private Function listStatus() As Object
        Throw New NotImplementedException
    End Function
    Sub PopulateComboCategories()
        '******************************************************************************
        ' Author       : Kobus
        ' Created      : 18/06/2014
        ' Purpose      : Populate combo box
        '******************************************************************************
        If Persoonl.TAAL = 0 Then
            cmbCategory.DataSource = BaseForm.FillCombo("poldata5.fetcharchivecategories", "pkArchiveCategories", "DescriptionAfr", "@Taal", SqlDbType.Int, 0)
        Else
            cmbCategory.DataSource = BaseForm.FillCombo("poldata5.fetcharchivecategories", "pkArchiveCategories", "DescriptionEng", "@Taal", SqlDbType.Int, 1)
        End If

        cmbCategory.DisplayMember = "ComboBoxName"
        cmbCategory.ValueMember = "ComboBoxID"

        cmbCategory.Text = ""


            'Using conn As SqlConnection = SqlHelper.GetConnection
            '    Dim params() As SqlParameter = {New SqlParameter("@Taal", SqlDbType.Int)}
            '    If Persoonl.TAAL = 0 Then
            '        params(0).Value = 0
            '    Else
            '        params(0).Value = 1
            '    End If

            '    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchArchiveCategories", params)
            '    cmbCategory.Items.Clear()
            '    If Persoonl.TAAL = 0 Then
            '        Do While reader.Read
            '            cmbCategory.Items.Add(reader("DescriptionAfr"))
            '            'As ek hierdie bysit wys die Pk ook in die dropbox, dit moenie gebeur nie
            '            cmbCategory.Items.Add(reader("pkArchiveCategories"))

            '        Loop
            '    Else
            '        Do While reader.Read
            '            cmbCategory.Items.Add(reader("DescriptionEng"))
            '        Loop
            '    End If
            'End Using
    End Sub
    Private Function testFileType()
        '*****************************************************************************************
        ' Author       : Kobus
        ' Created      : 20/06/2014
        ' Purpose      : Test files to save only .msg files if type is Email and allow other files
        '*****************************************************************************************

        'Kobnus 01/07/2014 voegby
        If strFilename = "" Then
            Return False
            Exit Function
        End If
        Dim strSearchWithinThis As String = txtPath.Text
        Dim strSearchForThis As String
        strSearchForThis = ".txt"
        Dim intFirstFind As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
        If intFirstFind <> -1 Then
            Dim strText As String = File.ReadAllText(strFilename)
            Dim index As Integer = strText.IndexOf("From:")
            If index >= 0 Then
                ' String is in file, starting at character "index"
                'Dim strSearchFor As String
                'Dim strLine As String
                'Dim objFSO As Object
                'Dim objTextFile As Object
                'strSearchFor = "From:"
                'objFSO = CreateObject("Scripting.FileSystemObject")
                'objTextFile = objFSO.OpenTextFile(txtPath.Text, 1)
                'Do Until objTextFile.AtEndOfStream
                '    strLine = objTextFile.ReadLine
                '    If InStr(1, strLine, strSearchFor, 1) > 0 Then
                '        'Me.txtPath.Text = ""
                Me.btnOk.Enabled = False
                FileClose()
                Me.CommonDialog1Open.InitialDirectory = "C:\"
                Me.txtPath.Text = ""
                MsgBox("Email files must be saved as an Outlook msg file", MsgBoxStyle.Information)
                Return False
                Exit Function
            End If
        End If


        strSearchForThis = ".html"
        Dim intFirstFind1 As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
        If intFirstFind1 <> -1 Then
            Me.btnOk.Enabled = False
            Me.txtPath.Text = ""
            Me.CommonDialog1Open.InitialDirectory = "C:\"
            MsgBox("Email files must be saved as an Outlook msg file", MsgBoxStyle.Information)
            Return False
            Exit Function
        End If

        strSearchForThis = ".oft"
        Dim intFirstFind2 As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
        If intFirstFind2 <> -1 Then
            Me.btnOk.Enabled = False
            Me.txtPath.Text = ""
            Me.CommonDialog1Open.InitialDirectory = "C:\"
            MsgBox("Email files must be saved as an Outlook msg file", MsgBoxStyle.Information)
            Return False
            Exit Function
        End If


        strSearchForThis = ".mht"
        Dim intFirstFind3 As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
        If intFirstFind3 <> -1 Then
            Me.btnOk.Enabled = False
            Me.txtPath.Text = ""
            Me.CommonDialog1Open.InitialDirectory = "C:\"
            MsgBox("Email files must be saved as an Outlook msg file", MsgBoxStyle.Information)
            Return False
            Exit Function
        End If

        strSearchForThis = ".xml"
        Dim intFirstFind4 As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
        If intFirstFind4 <> -1 Then
            Me.btnOk.Enabled = False
            Me.txtPath.Text = ""
            Me.CommonDialog1Open.InitialDirectory = "C:\"
            MsgBox("Email files must be saved as an Outlook msg file", MsgBoxStyle.Information)
            Return False
            Exit Function
        End If

        strSearchForThis = ".thmx"
        Dim intFirstFind5 As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
        If intFirstFind5 <> -1 Then
            Me.btnOk.Enabled = False
            Me.txtPath.Text = ""
            Me.CommonDialog1Open.InitialDirectory = "C:\"
            MsgBox("Email files must be saved as an Outlook msg file", MsgBoxStyle.Information)
            Return False
            Exit Function
        End If
        strSearchForThis = "htm"
        Dim intFirstFind6 As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
        If intFirstFind6 <> -1 Then
            Me.btnOk.Enabled = False
            Me.txtPath.Text = ""
            Me.CommonDialog1Open.InitialDirectory = "C:\"
            MsgBox("Email files must be saved as an Outlook msg file", MsgBoxStyle.Information)
            Return False
            Exit Function
        End If
        Return Nothing
    End Function

    Private Sub cmbCategory_Leave(sender As Object, e As System.EventArgs) Handles cmbCategory.Leave
        '*******************************************************************************************
        ' Author       : Kobus
        ' Created      : 18/07/2014
        ' Purpose      : To get values of pkArchiveCategories and CategoryFile for selected item
        '*******************************************************************************************

        Dim item As New ComboBoxEntity
        If cmbCategory.SelectedIndex <> -1 Then
            item = Me.cmbCategory.SelectedItem
            intFkArchiveCategories = item.ComboBoxID
        End If

        Using conn As SqlConnection = SqlHelper.GetConnection
            Dim params() As SqlParameter = {New SqlParameter("@pkArchiveCategories", SqlDbType.NVarChar)}

            params(0).Value = intFkArchiveCategories

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchArchiveCategoriesByPk", params)
            reader.Read()
            If Persoonl.TAAL = 0 Then
                strFileDesc = reader("CategoryFileAfr")
            Else
                strFileDesc = reader("CategoryFileEng")
            End If

        End Using

    End Sub
End Class
