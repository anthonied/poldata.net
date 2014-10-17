Option Strict Off
Option Explicit On

Imports System.Data.SqlClient
Imports DAL
Imports System.IO
Imports System.Diagnostics

Friend Class frmVoiceRecording
    Inherits System.Windows.Forms.Form
    'Public watchfolder As FileSystemWatcher
    Public pkArchiveVoice As Integer
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
    Dim blnclose As Boolean
    Dim dateCallDate As Date
    Dim strConactNumber As String
    Dim strCallerNumber As String
    Dim strComments As String
    Dim intIncoming As Integer
    Dim blnNonInsurance As Boolean = False

    Private Sub frmVoiceRecording_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form1.VoiceMonitor()
    End Sub

    Private Sub frmVoiceRecording_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        If Form1.blnStopWatch = True Then
            Close()
            Exit Sub
        End If
        Me.txtInsured.Enabled = True
        Me.txtInitials.Enabled = True
        Me.txtIDnumber.Enabled = True
        Me.txtPolisno.Enabled = True
        Me.btnSearchIDno.Enabled = True
        Me.btnSearchInsured.Enabled = True
        Me.btnSearchPolisno.Enabled = True
        optInsurance.Enabled = True
        optNonInsurance.Enabled = True
        Me.lblCallerNumber.Visible = True
        Me.txtCallerNumber.Visible = True
        ClearFields()
        If Form1.POLISNO.Text <> "" Then
            Me.txtInsured.Text = Form1.VERSEKERDE.Text
            Me.txtPolisno.Text = glbPolicyNumber
            Me.txtInitials.Text = Form1.VOORL.Text
            Me.txtIDnumber.Text = Form1.ID_NOM.Text
        End If
        If blnclose = True Then
            Me.Close()
            blnclose = False
            Exit Sub
        End If
        PopulateComboCategories()
        'createNewFileName()
        Me.Text = "      Voice Recording"
        blnclose = True
    End Sub
    Private Sub FillCategryDesc()

        'Using conn As SqlConnection = SqlHelper.GetConnection
        '    Dim params() As SqlParameter = {New SqlParameter("@pkArchiveCategories", SqlDbType.NVarChar)}

        '    params(0).Value = ArchiveVoice.intFkArchiveCategories

        '    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchArchiveCategoriesByPk", params)
        '    reader.Read()
        '    If Persoonl.TAAL = 0 Then
        '        txtCategoryDesc.Text = reader("DescriptionAfr")
        '    Else
        '        txtCategoryDesc.Text = reader("DescriptionEng")
        '    End If

        'End Using
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Form1.blnStopWatch = False
        If Trim(txtComments.Text) = "" Then
            MsgBox("A reason for cancellation is required.")
            Me.btnOk.Enabled = False
            Me.txtComments.Focus()
            Exit Sub
        End If
        If btnCancel.Text <> "Close" Then
            CancelCallInformation()
        End If
        Me.Close()
    End Sub
    Private Sub createNewFileName()
        '******************************************************************************
        '*Author       : Kobus
        '*Created      : 30/07/2014
        '*Purpose      : Control filename for Voice Archive table and directory
        '******************************************************************************
        If blnNonInsurance = False Then
            If txtFileName.Text = "" Then
                MsgBox("There is no file to proccess.")
                Exit Sub
            End If
            Dim strInsuredInitials As String

            If txtInsured.Text <> "" And txtPolisno.Text <> "" Then
                strFilename = Microsoft.VisualBasic.Right(txtFileName.Text, 22)
                strFileName2 = strFilename
                strFilename = txtFileName.Text
                File.Delete(strFilename)
                Dim myChar() As Char = {"G", "S", "M"}
                Dim strNew As String = strFileName2.TrimEnd(myChar)
                strServerPath = Form1.gen_getVoicePath
                strFilename = strServerPath & strNew & "txt"
                strFileName2 = strNew & "txt"
                Dim sw As StreamWriter = File.CreateText(strFilename)
                strInsuredInitials = Me.txtInsured.Text & " " & Me.txtInitials.Text
                sw.WriteLine("Insured: " & Me.txtInsured.Text)
                sw.WriteLine("Initials: " & Me.txtInitials.Text)
                sw.WriteLine("Policy No: " & Me.txtPolisno.Text)
                sw.WriteLine("IDNO: " & Me.txtIDnumber.Text)
                sw.WriteLine("Contact Number: " & Me.txtContactNumber.Text)
                sw.WriteLine("Caller Number: " & Me.txtCallerName.Text)
                sw.WriteLine("Comments: " & Me.txtComments.Text)
                sw.Flush()
                sw.Close()
                dateDocDate = Now()
                strServerPath = Form1.gen_getVoicePath 'The location on the server
                strDocDir = strServerPath & glbPolicyNumber
                strDocPath = txtPolisno.Text & "\" & Trim(cmbCategory.Text) & "_" & Format(dateDocDate, "ddMMyyyy_hhmmss") & "-" & strFileName2
                strReturnPath = strServerPath & strDocPath
                'End If
            End If
            If txtInsured.Text <> "" And txtPolisno.Text = "" Then
                strFilename = Microsoft.VisualBasic.Right(txtFileName.Text, 22)
                strFileName2 = strFilename
                strFilename = txtFileName.Text
                File.Delete(strFilename)
                Dim myChar() As Char = {"G", "S", "M"}
                Dim strNew As String = strFileName2.TrimEnd(myChar)
                strServerPath = Form1.gen_getVoicePath
                strFilename = strServerPath & strNew & "txt"
                strFileName2 = strNew & "txt"
                Dim sw As StreamWriter = File.CreateText(strFilename)
                strInsuredInitials = Me.txtInsured.Text & " " & Me.txtInitials.Text
                sw.WriteLine("Insured: " & Me.txtInsured.Text)
                sw.WriteLine("Initials: " & Me.txtInitials.Text)
                sw.WriteLine("Policy No: " & Me.txtPolisno.Text)
                sw.WriteLine("IDNO: " & Me.txtIDnumber.Text)
                sw.WriteLine("Contact Number: " & Me.txtContactNumber.Text)
                sw.WriteLine("Caller Number: " & Me.txtCallerName.Text)
                sw.WriteLine("Comments: " & Me.txtComments.Text)
                sw.Flush()
                sw.Close()
                dateDocDate = Now()
                strDocPath = "NotAllocated" & "\" & Trim(cmbCategory.Text) & "-" & strInsuredInitials & "Tel" & txtContactNumber.Text & "_" & Format(dateDocDate, "ddMMyyyy_hhmmss") & "-" & strFileName2
                strReturnPath = strServerPath & strDocPath
            End If
            If txtInsured.Text = "" And txtPolisno.Text = "" And txtComments.Text <> "" Then
                strFilename = Microsoft.VisualBasic.Right(txtFileName.Text, 22)
                strFileName2 = strFilename
                strFilename = txtFileName.Text
                File.Delete(strFilename)
                Dim myChar() As Char = {"G", "S", "M"}
                Dim strNew As String = strFileName2.TrimEnd(myChar)
                strServerPath = Form1.gen_getVoicePath
                strFilename = strServerPath & strNew & "txt"
                strFileName2 = strNew & "txt"
                Dim sw As StreamWriter = File.CreateText(strFilename)
                strInsuredInitials = Me.txtInsured.Text & " " & Me.txtInitials.Text
                sw.WriteLine("Insured: " & Me.txtInsured.Text)
                sw.WriteLine("Initials: " & Me.txtInitials.Text)
                sw.WriteLine("Policy No: " & Me.txtPolisno.Text)
                sw.WriteLine("IDNO: " & Me.txtIDnumber.Text)
                sw.WriteLine("Contact Number: " & Me.txtContactNumber.Text)
                sw.WriteLine("Caller Number: " & Me.txtCallerName.Text)
                sw.WriteLine("Comments: " & Me.txtComments.Text)
                sw.Flush()
                sw.Close()
                dateDocDate = Now()
                strServerPath = Form1.gen_getVoicePath 'The location on the server
                strDocDir = strServerPath & glbPolicyNumber
                strDocPath = "NotAllocated" & "\V - Recorded by: " & Gebruiker.Naam & "_" & Format(dateDocDate, "ddMMyyyy_hhmmss") & "-" & strFileName2
                strReturnPath = strServerPath & strDocPath
                'End If
            End If
            
        Else
            If txtInsured.Text = "" And txtPolisno.Text = "" And txtCallerName.Text <> "" Then
                strFilename = Microsoft.VisualBasic.Right(txtFileName.Text, 22)
                strFileName2 = strFilename
                strFilename = txtFileName.Text
                File.Delete(strFilename)
                Dim myChar() As Char = {"G", "S", "M"}
                Dim strNew As String = strFileName2.TrimEnd(myChar)
                strServerPath = Form1.gen_getVoicePath
                strFilename = strServerPath & strNew & "txt"
                strFileName2 = strNew & "txt"
                Dim sw As StreamWriter = File.CreateText(strFilename)
                'strInsuredInitials = Me.txtInsured.Text & " " & Me.txtInitials.Text
                sw.WriteLine("Insured: " & Me.txtInsured.Text)
                sw.WriteLine("Initials: " & Me.txtInitials.Text)
                sw.WriteLine("Policy No: " & Me.txtPolisno.Text)
                sw.WriteLine("IDNO: " & Me.txtIDnumber.Text)
                sw.WriteLine("Contact Number: " & Me.txtContactNumber.Text)
                sw.WriteLine("Caller Number: " & Me.txtCallerName.Text)
                sw.WriteLine("Comments: " & Me.txtComments.Text)
                sw.Flush()
                sw.Close()
                dateDocDate = Now()
                strDocPath = "NonInsured" & "\" & Trim(cmbCategory.Text) & "_" & txtCallerName.Text & "Tel" & txtContactNumber.Text & "_" & Format(dateDocDate, "ddMMyyyy_hhmmss") & "-" & strFileName2
                strReturnPath = strServerPath & strDocPath

            End If
        End If
        Try
            My.Computer.FileSystem.MoveFile(strFilename, strReturnPath,
        FileIO.UIOption.AllDialogs,
        FileIO.UICancelOption.ThrowException)
            txtFileName.Text = strReturnPath
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Sub
    Sub PopulateComboCategories()
        '******************************************************************************
        ' Author       : Kobus
        ' Created      : 31/07/2014
        ' Purpose      : Populate  Category combobox
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
    Private Sub ClearFields()
        Me.txtInsured.Text = ""
        Me.txtPolisno.Text = ""
        Me.txtInitials.Text = ""
        Me.txtIDnumber.Text = ""
    End Sub
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
                    'If reader("TEL_SEL") IsNot DBNull.Value Then
                    '    Me.txtInsured.Text = reader("TEL_SEL")
                    'End If
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
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

    Private Sub btnOk_Click(sender As Object, e As System.EventArgs) Handles btnOk.Click
        'If optInsurance.Checked = True And txtInsured.Text = "" Then
        '    MsgBox("Please select the Insured or policy number for this recording.")
        '    Exit Sub
        'End If
        If optInsurance.Checked = True And txtInsured.Text = "Surname" Then
            Me.txtInsured.Text = ""
            Me.txtPolisno.Text = ""
            Me.txtInitials.Text = ""
        End If
        If optNonInsurance.Checked = True And txtCallerName.Text = "" Then
            MsgBox("Please enter a Name for the caller.")
            Me.txtCallerName.Focus()
            Exit Sub
        End If
        If Trim(Me.txtComments.Text) = "" Then
            MsgBox("Reasons for not allocating the call, is required.")
            Me.txtComments.Focus()
            Exit Sub
        End If

        createNewFileName()
        If blnNonInsurance = False And txtPolisno.Text <> "" Then
            IncertVoiceArchive()
        End If
        optInsurance.Enabled = False
        optNonInsurance.Enabled = False
        txtFileName.Enabled = False
        btnOk.Enabled = False
        btnCancel.Text = "Close"
    End Sub
    Private Sub IncertVoiceArchive()

        '******************************************************************************
        '*Author       : Kobus
        '*Created      : 01/08/2014/2014
        '*Purpose      : update Archive Voice table
        '******************************************************************************

        dateCallDate = Now()
        strConactNumber = txtContactNumber.Text
        strCallerNumber = txtCallerNumber.Text
        strDocPath = txtFileName.Text
        strComments = txtComments.Text
        intIncoming = 1
        intFkArchiveCategories = 19
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

    Private Sub optNonInsurance_Click(sender As Object, e As System.EventArgs) Handles optNonInsurance.Click
        ClearFields()
        Me.txtInsured.Enabled = False
        Me.txtInitials.Enabled = False
        Me.txtIDnumber.Enabled = False
        Me.txtPolisno.Enabled = False
        Me.btnSearchIDno.Enabled = False
        Me.btnSearchInsured.Enabled = False
        Me.btnSearchPolisno.Enabled = False
        Me.lblCallerName.Visible = True
        Me.txtCallerName.Visible = True
        Me.lblCallerNumber.Visible = False
        Me.txtCallerNumber.Visible = False
        blnNonInsurance = True
    End Sub

    Private Sub optInsurance_Click(sender As Object, e As System.EventArgs) Handles optInsurance.Click
        Me.txtInsured.Enabled = True
        Me.txtInitials.Enabled = True
        Me.txtIDnumber.Enabled = True
        Me.txtPolisno.Enabled = True
        Me.btnSearchIDno.Enabled = True
        Me.btnSearchInsured.Enabled = True
        Me.btnSearchPolisno.Enabled = True
        Me.lblCallerNumber.Visible = True
        Me.txtCallerNumber.Visible = True
        Me.lblCallerName.Visible = False
        Me.txtCallerName.Visible = False
        blnNonInsurance = False
    End Sub
    Private Sub CancelCallInformation()
        'Kobus 06/08/2014 skep hierdie opsie om inligting te hanteer wanneer cancel gebruik word. 
        'Die oproepinligting word gestoor in die NonAllocated Directory
        If Trim(txtComments.Text) <> "" Then
            strFilename = Microsoft.VisualBasic.Right(txtFileName.Text, 22)
            strFileName2 = strFilename
            strFilename = txtFileName.Text
            File.Delete(strFilename)
            Dim myChar() As Char = {"G", "S", "M"}
            Dim strNew As String = strFileName2.TrimEnd(myChar)
            strServerPath = Form1.gen_getVoicePath
            strFilename = strServerPath & strNew & "txt"
            strFileName2 = strNew & "txt"
            Dim sw As StreamWriter = File.CreateText(strFilename)
            Dim strInsuredInitials As String
            If Me.txtInsured.Text = "Surname" Then
                strInsuredInitials = ""
            Else
                strInsuredInitials = txtInsured.Text & " " & txtInitials.Text
            End If

            sw.WriteLine("Insured: " & Me.txtInsured.Text)
            sw.WriteLine("Initials: " & Me.txtInitials.Text)
            sw.WriteLine("Policy No: " & Me.txtPolisno.Text)
            sw.WriteLine("IDNO: " & Me.txtIDnumber.Text)
            sw.WriteLine("Contact Number: " & Me.txtContactNumber.Text)
            sw.WriteLine("Caller Number: " & Me.txtCallerName.Text)
            sw.WriteLine("Comments: " & Me.txtComments.Text)
            sw.Flush()
            sw.Close()
            dateDocDate = Now()
            strDocPath = "NotAllocated" & "\" & "Cancelled by " & Gebruiker.Naam & Format(dateDocDate, "ddMMyyyy_hhmmss") & "-" & strFileName2
            strReturnPath = strServerPath & strDocPath
        End If
        Try
            My.Computer.FileSystem.MoveFile(strFilename, strReturnPath,
        FileIO.UIOption.AllDialogs,
        FileIO.UICancelOption.ThrowException)
            txtFileName.Text = strReturnPath
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class