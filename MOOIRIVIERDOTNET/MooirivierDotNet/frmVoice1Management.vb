Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports DAL
Imports System.IO

Friend Class frmVoice1Management
    'Kobus 22/07/2014 create the Class to Manage Voice files
    Inherits System.Windows.Forms.Form


    Dim appPath As String
    Dim intRow As Integer
    Dim strFilename As String
    Dim intBitValue As Integer
    Dim bitVertoon As SByte
    Dim dateDocDate As Date
    Dim strDocPath As String
    Dim strServerPath As String
    Dim strDocDir As String
    Dim strReturnPath As String
    Dim strresult As String
    Dim strFileName2 As String
    Dim intFkArchiveCategories As Integer
    Dim strFileDesc As String
    Dim dteCallDate As Date
    Dim strConactNumber As String
    Dim strCallerNumber As String
    Dim strComments As String
    Dim intIncoming As Integer
    Dim dateCallDate As Date

    Private Sub btnBrowse_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnBrowse.Click
        
        CommonDialog1Open.ShowDialog()
        Me.CommonDialog1Open.InitialDirectory = "C:\"
        If CommonDialog1Open.FileName <> "" Then
            Me.txtPath.Text = CommonDialog1Open.FileName
            Dim strSearchWithinThis As String = txtPath.Text
            strFilename = txtPath.Text
            Dim strSearchForThis As String
            strSearchForThis = ".txt"
            Dim intFirstFind As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
            If intFirstFind <> -1 Then
                Dim fileReader As System.IO.StreamReader
                fileReader = My.Computer.FileSystem.OpenTextFileReader(strFilename)
                If System.IO.File.Exists(strFilename) = True Then
                    Dim strReader As String
                    strReader = fileReader.ReadLine()
                    If Trim(strReader) = "" Then
                        MsgBox("The wrong file is selected.")
                        'Dim list As New List(Of String)
                        Exit Sub
                    End If
                    intRow = 0
                    If Trim(strReader) <> "" Then

                        Do While Trim(strReader) <> ""
                            Dim myarray() As String = strReader.Split(":")
                           
                            If myarray(0) = "Insured" Then
                                If myarray(1) = "" Then
                                    Me.txtInsured.Text = ""
                                Else
                                    Me.txtInsured.Text = Trim(myarray(1))
                                End If
                            End If
                            If myarray(0) = "Initials" Then
                                If myarray(1) = "" Then
                                    Me.txtInitials.Text = ""
                                Else
                                    Me.txtInitials.Text = Trim(myarray(1))
                                End If
                            End If
                            If myarray(0) = "Policy No" Then
                                If myarray(1) = "" Then
                                    myarray(1) = "0"
                                Else
                                    Me.txtPolisno.Text = Trim(myarray(1))
                                End If
                            End If
                            If myarray(0) = "IDNO" Then
                                If myarray(1) = "" Then
                                    Me.txtIDnumber.Text = ""
                                Else
                                    Me.txtIDnumber.Text = Trim(myarray(1))
                                End If
                            End If
                            If myarray(0) = "Contact Number" Then
                                If myarray(1) = "" Then
                                    Me.txtContactNumber.Text = ""
                                Else
                                    Me.txtContactNumber.Text = Trim(myarray(1))
                                End If
                            End If
                            If myarray(0) = "Caller Number" Then
                                If myarray(1) = "" Then
                                    Me.txtCallerNumber.Text = ""
                                Else
                                    Me.txtCallerNumber.Text = Trim(myarray(1))
                                End If
                            End If
                            If myarray(0) = "Comments" Then
                                If myarray(1) = "" Then
                                    Me.txtComments.Text = ""
                                Else
                                    Me.txtComments.Text = Trim(myarray(1))
                                End If

                            End If
                            strReader = fileReader.ReadLine()
                            intRow = intRow + 1
                            If strReader = "" Then
                                Exit Do
                            End If
                        Loop

                    End If
                End If
            End If
        End If

    End Sub

    'Cancel button onclick - close/unload form
    Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click

        If Me.txtPath.Text = "" Then
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

        If txtPolisno.Text <> "" Then
            IncertVoiceArchive()
        End If

        Me.btnCancel.Text = "Close"
        Me.btnOk.Enabled = False
        Me.btnBrowse.Enabled = False
        Me.Cursor = System.Windows.Forms.Cursors.Default


    End Sub
    Private Sub createNewFileName()
        '******************************************************************************
        '*Author       : Kobus
        '*Created      : 22/07/2014
        '*Purpose      : Control filename for ArchiveVoice table and directory
        '******************************************************************************
        dateDocDate = Now()
        strFilename = Microsoft.VisualBasic.Right(txtPath.Text, 22)
        strServerPath = Form1.gen_getVoicePath() 'The location on the server
        strDocDir = strServerPath & glbPolicyNumber 'The location on server with policy number
        'Path stored in db - no server path only subdirectory
        strDocPath = glbPolicyNumber & "\" & Trim(strFileDesc) & "_" & Format(dateDocDate, "ddMMyyyy_hhmmss") & strFilename
        strReturnPath = strServerPath & strDocPath
        'End If
        Try
            My.Computer.FileSystem.MoveFile(txtPath.Text, strReturnPath,
        FileIO.UIOption.AllDialogs,
        FileIO.UICancelOption.ThrowException)
            Me.txtFileName.Text = strReturnPath
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
        Me.Text = "      Voice Management for policy (" & Me.txtPolisno.Text & ")"
        Me.btnBrowse.Enabled = True
        Me.txtPath.Text = ""
        Me.btnCancel.Enabled = True
        Me.btnOk.Enabled = True
        Me.btnCancel.Text = "Cancel"
        PopulateComboCategories()

    End Sub

    Private Sub txtPath_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPath.TextChanged
        Me.btnCancel.Enabled = True
        Me.btnOk.Enabled = True
        'Me.Label1.Text = ""
        Me.btnCancel.Text = "Cancel"
        'strFilename = txtPath.Text
        'testFileType()
    End Sub

    Private Function listStatus() As Object
        Throw New NotImplementedException
    End Function
    Sub PopulateComboCategories()
        '******************************************************************************
        ' Author       : Kobus
        ' Created      : 22/07/2014
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

    End Sub
    'Private Function testFileType()
    '    '*****************************************************************************************
    '    ' Author       : Kobus
    '    ' Created      : 22/07/2014
    '    ' Purpose      : Test files to save only .msg files if type is Email and allow other files
    '    '*****************************************************************************************

    '    If strFilename = "" Then
    '        Return False
    '        Exit Function
    '    End If
    '    Dim strSearchWithinThis As String = txtPath.Text
    '    Dim strSearchForThis As String
    '    strSearchForThis = ".txt"
    '    Dim intFirstFind As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
    '    If intFirstFind <> -1 Then
    '        Dim strText As String = File.ReadAllText(strFilename)
    '        Dim index As Integer = strText.IndexOf("From:")
    '        If index >= 0 Then
    '            Me.btnOk.Enabled = False
    '            FileClose()
    '            Me.CommonDialog1Open.InitialDirectory = "C:\"
    '            Me.txtPath.Text = ""
    '            MsgBox("Email files must be saved as an Outlook msg file", MsgBoxStyle.Information)
    '            Return False
    '            Exit Function
    '        End If
    '    End If


    '    strSearchForThis = ".html"
    '    Dim intFirstFind1 As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
    '    If intFirstFind1 <> -1 Then
    '        Me.btnOk.Enabled = False
    '        Me.txtPath.Text = ""
    '        Me.CommonDialog1Open.InitialDirectory = "C:\"
    '        MsgBox("Email files must be saved as an Outlook msg file", MsgBoxStyle.Information)
    '        Return False
    '        Exit Function
    '    End If

    '    strSearchForThis = ".oft"
    '    Dim intFirstFind2 As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
    '    If intFirstFind2 <> -1 Then
    '        Me.btnOk.Enabled = False
    '        Me.txtPath.Text = ""
    '        Me.CommonDialog1Open.InitialDirectory = "C:\"
    '        MsgBox("Email files must be saved as an Outlook msg file", MsgBoxStyle.Information)
    '        Return False
    '        Exit Function
    '    End If


    '    strSearchForThis = ".mht"
    '    Dim intFirstFind3 As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
    '    If intFirstFind3 <> -1 Then
    '        Me.btnOk.Enabled = False
    '        Me.txtPath.Text = ""
    '        Me.CommonDialog1Open.InitialDirectory = "C:\"
    '        MsgBox("Email files must be saved as an Outlook msg file", MsgBoxStyle.Information)
    '        Return False
    '        Exit Function
    '    End If

    '    strSearchForThis = ".xml"
    '    Dim intFirstFind4 As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
    '    If intFirstFind4 <> -1 Then
    '        Me.btnOk.Enabled = False
    '        Me.txtPath.Text = ""
    '        Me.CommonDialog1Open.InitialDirectory = "C:\"
    '        MsgBox("Email files must be saved as an Outlook msg file", MsgBoxStyle.Information)
    '        Return False
    '        Exit Function
    '    End If

    '    strSearchForThis = ".thmx"
    '    Dim intFirstFind5 As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
    '    If intFirstFind5 <> -1 Then
    '        Me.btnOk.Enabled = False
    '        Me.txtPath.Text = ""
    '        Me.CommonDialog1Open.InitialDirectory = "C:\"
    '        MsgBox("Email files must be saved as an Outlook msg file", MsgBoxStyle.Information)
    '        Return False
    '        Exit Function
    '    End If
    '    strSearchForThis = "htm"
    '    Dim intFirstFind6 As Integer = strSearchWithinThis.IndexOf(strSearchForThis)
    '    If intFirstFind6 <> -1 Then
    '        Me.btnOk.Enabled = False
    '        Me.txtPath.Text = ""
    '        Me.CommonDialog1Open.InitialDirectory = "C:\"
    '        MsgBox("Email files must be saved as an Outlook msg file", MsgBoxStyle.Information)
    '        Return False
    '        Exit Function
    '    End If
    '    Return Nothing
    'End Function

    Private Sub cmbCategory_Leave(sender As Object, e As System.EventArgs) Handles cmbCategory.Leave
        '*******************************************************************************************
        ' Author       : Kobus
        ' Created      : 22/07/2014
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
    Private Sub SearchOptions()
        'Kobus 31/07/2014kep opsie om soekaksies te loots
        If Me.txtPolisno.Text <> "" Then

            If (Len(Me.txtPolisno.Text) <> 10) Then
                MsgBox("The policy number should be 10 long", 48, "Policy Number is Invalid!")
                Me.txtPolisno.Focus()
                Exit Sub
            End If
            'soek polis nommer
            PN_Search()
            If Persoonl.NoMatch Then
                ClearFields()
                MsgBox("No insured was found for this criteria", 48, "")

                Exit Sub
            End If
            FetchPersoonl()
        ElseIf (txtInsured.Text <> "") Or (txtInsured.Text = "?") Then
            '	'As ? ingetik is, begin by die a's
            Persoonl = New PERSOONLEntity()
            If txtInsured.Text = "?" Then
                Persoonl.VERSEKERDE = "a"
            Else
                Persoonl.VERSEKERDE = txtInsured.Text
            End If

            If Gebruiker.titel = "Programmeerder" Then
                Persoonl.Index = "V_INDEX"
            Else
                Persoonl.Index = "av_index"
            End If

            Form1.strOpsoekKat = "Van"
            vers_bes.ShowDialog()
            If vers_bes.Suksesvol = False Then
                ClearFields()
                Exit Sub
            Else
                Me.txtInsured.Text = Persoonl.VERSEKERDE
                Me.txtPolisno.Text = Persoonl.POLISNO
                Me.txtInitials.Text = Persoonl.VOORL
                Me.txtIDnumber.Text = Persoonl.ID_NOM
                Me.txtContactNumber.Text = Persoonl.SEL_TEL

            End If
        ElseIf (txtIDnumber.Text <> "") Or (txtIDnumber.Text = "?") Then
            '	'As ? ingetik is, begin by die a's
            Persoonl = New PERSOONLEntity()
            If txtIDnumber.Text = "?" Then
                Persoonl.ID_NOM = "a"
            Else
                Form1.ID_NOM.Text = txtIDnumber.Text
            End If

            If Gebruiker.titel = "Programmeerder" Then
                Persoonl.Index = "V_INDEX"
            Else
                Persoonl.Index = "av_index"
            End If

            Form1.strOpsoekKat = "ID"
            vers_bes.ShowDialog()
            If vers_bes.Suksesvol = False Then
                ClearFields()
                Exit Sub
            Else
                Me.txtInsured.Text = Persoonl.VERSEKERDE
                Me.txtPolisno.Text = Persoonl.POLISNO
                Me.txtInitials.Text = Persoonl.VOORL
                Me.txtIDnumber.Text = Persoonl.ID_NOM
                Me.txtContactNumber.Text = Persoonl.SEL_TEL
            End If
        End If
    End Sub
    Private Function PN_Search() As Boolean
        Dim gevind As Integer = -1
        Dim soekstring As String = ""
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        glbPolicyNumber = txtPolisno.Text
        FetchPersoonl()
        If Persoonl Is Nothing Then
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Return False
            Exit Function
        Else
            If Persoonl.NoMatch Then
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Function
            End If
        End If

        If Not Persoonl.NoMatch Then
            soekstring = Chr(39) & Trim(Persoonl.Area) & Chr(39)
            gevind = InStr(Gebruiker.BranchCodes, soekstring)
            If gevind = 0 Then ' nie gevind
                PN_Search = False
                Persoonl.NoMatch = True
                '  MsgBox("You are not authorised to open this policy. The policy does not fall in your authorised areas.", MsgBoxStyle.Critical)
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Function
            End If
        End If

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        PN_Search = True

    End Function
    Private Sub FetchPersoonl()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                               New SqlParameter("@VERSEKERDE", SqlDbType.NVarChar)}
                'Andriette 15/08/2013 Verander na die global polisnommer
                'params(0).Value = Form1.form1Polisno.Text
                params(0).Value = glbPolicyNumber
                If params(0).Value = Nothing Then
                    params(0).Value = ""
                    'Else
                    '    params(0).Value = Form1.form1Polisno.Text
                End If
                params(1).Value = ""

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlForFirstTime", params)

                If reader.Read() Then
                    If reader("Polisno") IsNot DBNull.Value Then
                        txtPolisno.Text = reader("Polisno")
                    End If
                    If reader("id_nom") IsNot DBNull.Value Then
                        Me.txtIDnumber.Text = reader("id_nom")
                    End If
                    If reader("VOORL") IsNot DBNull.Value Then
                        Me.txtInitials.Text = reader("VOORL")
                    End If
                    If reader("VERSEKERDE") IsNot DBNull.Value Then
                        Me.txtInsured.Text = reader("VERSEKERDE")
                    End If
                    If reader("SEL_TEL") IsNot DBNull.Value Then
                        Me.txtInsured.Text = reader("SEL_TEL")
                    End If
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Private Sub ClearFields()
        Me.txtInsured.Text = ""
        Me.txtPolisno.Text = ""
        Me.txtInitials.Text = ""
        Me.txtIDnumber.Text = ""
    End Sub
    Private Sub btnSearchPolisno_Click(sender As Object, e As System.EventArgs) Handles btnSearchPolisno.Click
        PN_Search()
    End Sub
    Private Sub btnSearchInsured_Click(sender As Object, e As System.EventArgs) Handles btnSearchInsured.Click
        SearchOptions()
    End Sub
    Private Sub txtInsured_Click(sender As Object, e As System.EventArgs) Handles txtInsured.Click
        Me.txtInsured.Text = ""
        Me.txtPolisno.Text = ""
        Me.txtIDnumber.Text = ""
        Me.txtInitials.Text = ""
    End Sub
    Private Sub btnSearchIDno_Click(sender As Object, e As System.EventArgs) Handles btnSearchIDno.Click
        SearchOptions()
    End Sub
    Private Sub txtIDnumber_Click(sender As Object, e As System.EventArgs) Handles txtIDnumber.Click
        Me.txtInsured.Text = ""
        Me.txtPolisno.Text = ""
        Me.txtIDnumber.Text = ""
        Me.txtInitials.Text = ""
    End Sub
    Private Sub IncertVoiceArchive()

        dateCallDate = Now()
        strConactNumber = txtContactNumber.Text
        strCallerNumber = txtCallerNumber.Text
        strDocPath = strFilename
        strComments = txtComments.Text
        If Me.cmbCategory.Text = "Voice In" Then
            intIncoming = 1
            intFkArchiveCategories = 19
        Else
            intIncoming = 0
            intFkArchiveCategories = 20
        End If
        glbPolicyNumber = txtPolisno.Text
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                     New SqlParameter("@CallDate", SqlDbType.DateTime), _
                                     New SqlParameter("@Gebruiker", SqlDbType.NVarChar), _
                                     New SqlParameter("@ContactNumber", SqlDbType.NVarChar), _
                                     New SqlParameter("@CallerNumber", SqlDbType.NVarChar), _
                                     New SqlParameter("@FileName", SqlDbType.NVarChar), _
                                     New SqlParameter("@Comments", SqlDbType.NVarChar), _
                                     New SqlParameter("@Incoming", SqlDbType.Bit), _
                                     New SqlParameter("@fkArchiveCategories", SqlDbType.Int)}

                params(0).Value = glbPolicyNumber
                params(1).Value = dateCallDate
                params(2).Value = Gebruiker.Naam
                params(3).Value = strConactNumber
                params(4).Value = strCallerNumber
                params(5).Value = strDocPath
                params(6).Value = strComments
                params(7).Value = intIncoming
                params(8).Value = intFkArchiveCategories

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.InsertArchiveVoice", params)

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
End Class
