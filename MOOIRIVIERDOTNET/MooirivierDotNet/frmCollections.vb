'********************************************************************
'Linkie 10/06/2013
'Form to handle the collections run that was on stats and multistats
'*******************************************************************
Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Data.SqlClient
Imports DAL
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration

Public Class frmCollections
    Dim blnCollectionsFix As Boolean
    Dim blnCollectionsValidated As Boolean
    Dim strFilename As String
    Dim strLine As String = ""
    Dim strPolisno As String
    Dim strDebitnr As String
    Dim strArea As String
    Dim strBetaalWyse As String
    Dim dblMaandPremie As Double
    Dim strTakhoof As String
    Dim intSalaryArea As Integer
    Dim dblCollectionsPremium As Double
    Dim strPersNom As String
    Dim strPersNomFile As String
    Dim strTak As String
    Dim clsRun As New clsRuns()
    Dim intpkMaand As Integer
    Dim strPolisnoChange As String
    Dim strPersnomChange As String

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        Dim strGebruikerlopie As String
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing
        Dim strPath As String = ""
        Dim entTakEntity As New TakEntity
        Dim strTak_afkorting As String = ""

        lblFixIncorrectData.Text = ""
        lblFixIncorrectData.Refresh()
        lblProcessing.Text = "Starting"
        lblProcessing.Refresh()

        CollectionsValidate()

        If blnCollectionsValidated = True Then
            Cursor.Current = Cursors.WaitCursor
            lblProcessing.Text = "Validated"
            lblProcessing.Refresh()

            Me.btnOk.Enabled = False
            Me.btnCancel.Enabled = False
            Me.cmdPath.Enabled = False

            lblProcessing.Text = "Database backup"
            lblProcessing.Refresh()

            If Me.optGeneral.Checked = True Then
                'backup database
                strPath = clsRun.gen_getServerPath & "MM Backup"
                If Dir(strPath, vbDirectory) = "" Then MkDir(strPath)

                entTakEntity = clsRun.GetTak
                strTak_afkorting = entTakEntity.Tak_afkorting

                strPath = strPath & "\" & strTak_afkorting & "_Collections.bak"
                If Gebruiker.titel = "Programmeerder" Then
                    If Me.chkDatabaseBackup.Checked = True Then
                        clsRun.BackupMooirivierDatabase(strPath)
                    End If
                Else
                    clsRun.BackupMooirivierDatabase(strPath)
                End If

                strGebruikerlopie = "Vorderingslopie - "
            Else
                'backup database
                strPath = clsRun.gen_getServerPath & "MM Backup"
                If Dir(strPath, vbDirectory) = "" Then MkDir(strPath)
                entTakEntity = clsRun.GetTak
                strTak_afkorting = entTakEntity.Tak_afkorting

                strPath = strPath & "\" & strTak_afkorting & "_Collections_Salary_" & Me.cmbArea.Text & ".bak"
                If Gebruiker.titel = "Programmeerder" Then
                    If Me.chkDatabaseBackup.Checked = True Then
                        clsRun.BackupMooirivierDatabase(strPath)
                    End If
                Else
                    clsRun.BackupMooirivierDatabase(strPath)
                End If

                strGebruikerlopie = "Vorderingslopie - Salaris - " & Me.cmbArea.Text & " - "
            End If

            clsRun.UpdateGebrukerLopiesRuns(strGebruikerlopie & cmbInsurer.Text, Me.dtpCollectionsDate.Text)

            glbVersekeraar = cmbInsurer.SelectedValue
            clsRun.GetInsurer()

            If Me.optGeneral.Checked = True Then
                If chkCollectionsRun.Checked = True Then
                    DeleteCollectionsData()
                    ReadCollectionsFileAndWriteData()
                End If

                If chkReportsSummary.Checked = True Then
                    'doen summary report
                    strglbReportPath = "/Mooirivier/ReportCollections"

                    frmReporting.Show()
                End If

                If chkReportsDetail.Checked = True Then
                    'doen detail report
                End If

                If chkReportsRecon.Checked = True Then
                    'doen recon report
                End If

                If chkReconReport103Report.Checked = True Then
                    'doen 103 verslag
                End If

                If chkReconReportPoliciesAdded.Checked = True Then
                    'doen polisse bygevoeg report
                End If

                If chkReconciliationForm.Checked = True Then
                    'vul rekon vorm in
                End If
            Else
                If chkCollectionsRun.Checked = True Then
                    If strTak = "Bloemfontein" Then
                        ReadExcelFileAndWriteDataBfn()
                    Else
                        ReadExcelFileAndWriteData()
                    End If
                End If

                If chkReportsSummary.Checked = True Then
                    'doen summary report

                End If

                If chkReportsDetail.Checked = True Then
                    'doen detail report
                End If

                If chkReportsRecon.Checked = True Then
                    'doen recon report
                End If

                If chkReconReport103Report.Checked = True Then
                    'doen 103 verslag
                End If

                If chkReconReportPoliciesAdded.Checked = True Then
                    'doen polisse bygevoeg report
                End If

                If chkReconciliationForm.Checked = True Then
                    'vul rekon vorm in
                End If

            End If
            Me.btnOk.Enabled = False
        End If

        Me.btnCancel.Enabled = True
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub frmCollections_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim strParamaterMaandBetaalwyse As String

        cmbInsurer.DataSource = BaseForm.FillCombo("poldata5.FetchVersekeraar", "pkVersekeraar", "Naam", "", "", "", "")
        cmbInsurer.DisplayMember = "ComboBoxName"
        cmbInsurer.ValueMember = "ComboBoxID"

        cmbInsurer.Text = ""

        cmbArea.DataSource = BaseForm.FillCombo("poldata5.ListActiveAreaOnly", "pkArea", "area_besk", "", "", "", "")
        cmbArea.DisplayMember = "ComboBoxName"
        cmbArea.ValueMember = "ComboBoxID"

        cmbArea.Text = ""

        'last  debietorder afsluitdatum
        strParamaterMaandBetaalwyse = "4"
        clsRun.MaxAfsluitDatMaand(strParamaterMaandBetaalwyse)
        Me.dtpCollectionsDate.Value = glbMaxAfsluitDatMaand

        'last msafsluitdatum
        strParamaterMaandBetaalwyse = "3"
        clsRun.MaxAfsluitDatMaand(strParamaterMaandBetaalwyse)
        Me.dtpSalaryCollectionDate.Value = glbMaxAfsluitDatMaand

        GetBranch()

        If Gebruiker.titel = "Programmeerder" Then
            Me.chkDatabaseBackup.Visible = True
            Me.Label15.Visible = True
        End If
    End Sub

    Private Sub CollectionsValidate()
        blnCollectionsValidated = False

        'Insurer must be chosen
        If Me.cmbInsurer.Text = "" Then
            MsgBox("A insurer must be chosen.", vbInformation)
            blnCollectionsValidated = False
            Me.cmbInsurer.Focus()
            Me.btnOk.Enabled = True
            Exit Sub
        End If

        'Date must be checked
        If Me.dtpCollectionsDate.Checked = False Then
            MsgBox("A date must be chosen.", vbInformation)
            blnCollectionsValidated = False
            Me.dtpCollectionsDate.Focus()
            Me.btnOk.Enabled = True
            Exit Sub
        End If

        'Path must be checked
        If Me.txtChooseCollectionsFilePath.Text = "" Then
            MsgBox("A path must be chosen.", vbInformation)
            blnCollectionsValidated = False
            Me.cmdPath.Focus()
            Me.btnOk.Enabled = True
            Exit Sub
        End If

        If Me.optSalary.Checked = True Then
            If Me.cmbArea.Text = "" Then
                MsgBox("An area must be chosen.", vbInformation)
                blnCollectionsValidated = False
                Me.cmbArea.Focus()
                Me.btnOk.Enabled = True
                Exit Sub
            End If
            If Me.dtpSalaryCollectionDate.Checked = False Then
                MsgBox("A Salary collections date must be chosen.", vbInformation)
                blnCollectionsValidated = False
                Me.dtpSalaryCollectionDate.Focus()
                Me.btnOk.Enabled = True
                Exit Sub
            End If
        End If
        blnCollectionsValidated = True
    End Sub

    Public Sub GetBranch()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchTak")

                If reader.Read Then
                    strTak = reader("Tak_naam")
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub cmdPath_Click(sender As System.Object, e As System.EventArgs) Handles cmdPath.Click

        If Me.cmbInsurer.Text <> "" Then
            glbVersekeraar = cmbInsurer.SelectedValue
            clsRun.GetInsurer()
        Else
            MsgBox("A insurer must first be chosen before you can select a file.", vbInformation)
            Me.cmbInsurer.Focus()
            Exit Sub
        End If

        If Me.optSalary.Checked = True Then
            If Me.cmbArea.Text <> "" Then
                intSalaryArea = cmbArea.SelectedValue
            Else
                MsgBox("An area must first be chosen before you can select a file.", vbInformation)
                Me.cmbArea.Focus()
                Exit Sub
            End If
        End If

        If Me.optGeneral.Checked = True Then
            ofdCollectionsFile.InitialDirectory = "C:\Polis5Admin\Collections\"
            ofdCollectionsFile.Title = "Open the .txt file of the specific month you are busy with"
            strDisFile = strDisFile & ".txt"
            ofdCollectionsFile.FileName = strDisFile
            ofdCollectionsFile.Filter = "Text file(*.txt)|*.txt"

            Dim intDidWork As Integer = ofdCollectionsFile.ShowDialog()

            If intDidWork <> DialogResult.Cancel Then
                strFilename = ofdCollectionsFile.FileName
                Me.txtChooseCollectionsFilePath.Text = ofdCollectionsFile.FileName
            End If

            If intDidWork <> DialogResult.Cancel And UCase(Microsoft.VisualBasic.Right(strFilename, 12)) <> UCase(strDisFile) Then
                MsgBox("The file chosen is not the one for this Insurer - please choose correct file.", vbInformation)
                strFilename = ""
                Me.txtChooseCollectionsFilePath.Text = ""
                Me.cmdPath.Focus()
                Exit Sub
            End If
        Else
            ofdCollectionsFile.InitialDirectory = "C:\Polis5Admin\Collections\"
            ofdCollectionsFile.Title = "Open the .xls file of the specific month you are busy with"
            If strTak = "Bloemfontein" Then
                ofdCollectionsFile.FileName = "UV"
            Else
                ofdCollectionsFile.FileName = "Puk"
            End If
            ofdCollectionsFile.Filter = "Excel file(*.xls)|*.xls"

            Dim intDidWork As Integer = ofdCollectionsFile.ShowDialog()

            If intDidWork <> DialogResult.Cancel Then
                strFilename = ofdCollectionsFile.FileName
                Me.txtChooseCollectionsFilePath.Text = ofdCollectionsFile.FileName
            End If

        End If
    End Sub
    Private Sub DeleteCollectionsData()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.DeleteCollectionsData")
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub ReadCollectionsFileAndWriteData()

        If System.IO.File.Exists(strFilename) = True Then
            Dim objReader As New System.IO.StreamReader(strFilename)

            Do While objReader.Peek() <> -1
                strLine = objReader.ReadLine() & vbNewLine

                'assign waardes uit text file
                strPolisno = Mid(strLine, 6, 10)
                strDebitnr = strLine.left(15)

                Try
                    Using conn As SqlConnection = SqlHelper.GetConnection
                        Dim param() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                               New SqlParameter("@pkVersekeraar", SqlDbType.Int)}

                        param(0).Value = strPolisno
                        param(1).Value = intPKInsurer
                        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlByVersekeraarAndPolisno", param)

                        If strPolisno = "1685000895" Or strPolisno = "7773016748" Or strPolisno = "7773006408" Or strPolisno = "1686000988" Or strPolisno = "7773041284" Then
                            strPolisno = strPolisno
                        End If

                        If reader.Read Then
                            strArea = reader("area")
                            strBetaalWyse = reader("bet_wyse")
                            Try
                                Using connect As SqlConnection = SqlHelper.GetConnection
                                    Dim params As New SqlParameter("@BranchVyf", SqlDbType.NVarChar)
                                    params.Value = Mid(strDebitnr, 7, 5)

                                    Dim readerTakpolisno As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchTakPolisno", params)

                                    If readerTakpolisno.Read Then
                                        'soek polisno + afsluitdatum in maand - as nie gekry, voeg dit by, dit beteken dat daar 'n polis deur multidata betaal is wat nie by Mooirivier is nie)
                                        strTakhoof = readerTakpolisno("tak_naam")

                                        Try
                                            Using conn2 As SqlConnection = SqlHelper.GetConnection
                                                Dim param2() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                                                New SqlParameter("@afsluitdat", SqlDbType.Date)}

                                                param2(0).Value = strPolisno
                                                param2(1).Value = Me.dtpCollectionsDate.Value

                                                Dim readerMaand As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaandPolisnoAfsluitdat]", param2)

                                                lblProcessing.Text = "Processing: " & strPolisno
                                                Me.lblProcessing.Refresh()

                                                If Not (readerMaand.Read) Then
                                                    'soek polisno + afsluitdatum in maand - as nie gekry, voeg dit by, dit beteken dat daar 'n polis deur multidata betaal is wat nie by Mooirivier is nie)
                                                    CreateMaandData()
                                                Else
                                                    dblMaandPremie = readerMaand("premie")
                                                    UpdateMaandData()
                                                End If
                                                'opdateer collections data
                                                CreateCollectionsData()
                                                If conn2.State = ConnectionState.Open Then
                                                    conn2.Close()
                                                    readerMaand.Close()
                                                End If
                                            End Using
                                        Catch ex As Exception
                                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                                        End Try
                                    End If
                                    If connect.State = ConnectionState.Open Then
                                        connect.Close()
                                        readerTakpolisno.Close()
                                    End If
                                End Using
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Critical)
                            End Try
                        End If
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                            reader.Close()
                        End If
                    End Using
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                Application.DoEvents()
            Loop

            objReader.Close()

            'Skryf die premie in maand(nie-multi) as 'n polisnommer in Maand voorkom, maar nie in tx leer nie - maand(match) = false
            'maw ons het 'n premie na multidata gestuur wat nie deur hulle betaal is nie.
            UpdateNonMatchedData()

            MsgBox("Finished with run", vbInformation)
            lblProcessing.Text = "Finished"
            Me.lblProcessing.Refresh()
        Else
            MsgBox("File does not exist.", vbInformation)
        End If
    End Sub
    Private Sub ReadExcelFileAndWriteData()
        Dim intRow As Integer
        Dim intEmpNoCol As Integer
        Dim intAmountCol As Integer
        Dim irow As Integer
        Dim icol As Integer
        Dim intRefNumber As Integer
        Dim intPukNAPolisno As Integer = 0

        If System.IO.File.Exists(strFilename) = True Then
            Dim xlApp As New Excel.Application
            Dim xlBook As Excel.Workbook
            Dim xlSheet As Excel.Worksheet

            xlBook = xlApp.Workbooks.Open(strFilename)
            xlSheet = xlBook.Worksheets(1)

            intAmountCol = 0
            intEmpNoCol = 0

            'kry die ry waar data moet begin lees word
            For irow = 1 To 20
                For icol = 1 To 20
                    If Trim(xlSheet.Cells(irow, icol).text) = "Emp Code" Then
                        intRow = irow + 1
                        intEmpNoCol = icol
                    End If
                    If Trim(xlSheet.Cells(irow, icol).text) = "Amount" Then
                        intAmountCol = icol
                    End If
                    If Trim(xlSheet.Cells(irow, icol).text) = "Reference Number" Then
                        intRefNumber = icol
                        'stop outer for loop
                        irow = 20
                    End If
                Next
            Next

            If intAmountCol = 0 Or intEmpNoCol = 0 Then
                MsgBox("The file chosen is not in the correct format. No information can be updated.  Please choose correct file.", vbInformation)
                Exit Sub
            End If

            Do While xlSheet.Cells(intRow, intEmpNoCol).text <> ""
                strPolisno = Trim(xlSheet.Cells(intRow, intRefNumber).text)
                dblCollectionsPremium = xlSheet.Cells(intRow, intAmountCol).text
                strPersNomFile = Trim(xlSheet.Cells(intRow, intEmpNoCol).text)

                Try
                    Using conn As SqlConnection = SqlHelper.GetConnection
                        Dim param() As SqlParameter = {New SqlParameter("@Persno", SqlDbType.NVarChar), _
                                               New SqlParameter("@pkVersekeraar", SqlDbType.Int)}

                        param(0).Value = strPersNomFile
                        param(1).Value = intPKInsurer
                        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlByVersekeraarAndPersno", param)

                        If strPolisno = "7776017756" Then
                            strPolisno = strPolisno
                        End If

                        If Len(strPolisno) < 10 Then
                            strPolisno = strPolisno & intPukNAPolisno
                            intPukNAPolisno += 1
                        End If

                        lblProcessing.Text = "Processing: " & strPolisno
                        Me.lblProcessing.Refresh()

                        If reader.Read Then
                            'polisno is nie verskaf nie, gaan soek in db of ons polisno kan kry.
                            If strPolisno = "" Or Len(strPolisno) < 10 Then
                                strPolisno = reader("polisno")
                            End If
                            strArea = reader("area")
                            strBetaalWyse = reader("bet_wyse")
                            strPersNom = reader("pers_nom")

                            Try
                                Using conn2 As SqlConnection = SqlHelper.GetConnection
                                    Dim param2() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                                    New SqlParameter("@afsluitdat", SqlDbType.Date)}

                                    param2(0).Value = strPolisno
                                    param2(1).Value = Me.dtpSalaryCollectionDate.Value

                                    Dim readerMaand As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaandPolisnoAfsluitdat]", param2)

                                    If Not (readerMaand.Read) Then
                                        'soek polisno + afsluitdatum in maand - as nie gekry, voeg dit by, dit beteken dat daar 'n polis deur multidata betaal is wat nie by Mooirivier is nie)
                                        CreateMaandData()
                                    Else
                                        dblMaandPremie = readerMaand("premie")
                                        strPersNom = reader("Pers_nom")
                                        UpdateMaandData()
                                    End If

                                    If conn2.State = ConnectionState.Open Then
                                        conn2.Close()
                                        readerMaand.Close()
                                    End If
                                End Using
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Critical)
                            End Try
                        Else
                            Try
                                Using connPolisno As SqlConnection = SqlHelper.GetConnection
                                    Dim paramPolisno() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                           New SqlParameter("@pkVersekeraar", SqlDbType.Int)}

                                    paramPolisno(0).Value = strPolisno
                                    paramPolisno(1).Value = intPKInsurer
                                    Dim readerPolisno As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlByVersekeraarAndPolisno", paramPolisno)

                                    If Len(strPolisno) < 10 Then
                                        strPolisno = strPolisno & intPukNAPolisno
                                        intPukNAPolisno += 1
                                    End If

                                    lblProcessing.Text = "Processing: " & strPolisno
                                    Me.lblProcessing.Refresh()

                                    If readerPolisno.Read Then
                                        'polisno is nie verskaf nie, gaan soek in db of ons polisno kan kry.
                                        If strPolisno = "" Or Len(strPolisno) < 10 Then
                                            strPolisno = readerPolisno("polisno")
                                        End If
                                        strArea = readerPolisno("area")
                                        strBetaalWyse = readerPolisno("bet_wyse")
                                        strPersNom = readerPolisno("pers_nom")

                                        Try
                                            Using conn2 As SqlConnection = SqlHelper.GetConnection
                                                Dim param2() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                                                New SqlParameter("@afsluitdat", SqlDbType.Date)}

                                                param2(0).Value = strPolisno
                                                param2(1).Value = Me.dtpSalaryCollectionDate.Value

                                                Dim readerMaand As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaandPolisnoAfsluitdat]", param2)

                                                If Not (readerMaand.Read) Then
                                                    'soek polisno + afsluitdatum in maand - as nie gekry, voeg dit by, dit beteken dat daar 'n polis deur multidata betaal is wat nie by Mooirivier is nie)
                                                    CreateMaandData()
                                                Else
                                                    dblMaandPremie = readerMaand("premie")
                                                    strPersNom = readerPolisno("Pers_nom")
                                                    UpdateMaandData()
                                                End If

                                                If conn2.State = ConnectionState.Open Then
                                                    conn2.Close()
                                                    readerMaand.Close()
                                                End If
                                            End Using
                                        Catch ex As Exception
                                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                                        End Try
                                    Else
                                        'indien dien personeelnr en polisno nie gekry word nie, skryf rekord in maand, waarmee hulle dan na die tyd moet match. (veranderde personeelnr)
                                        CreateMaandData()
                                    End If

                                    If connPolisno.State = ConnectionState.Open Then
                                        connPolisno.Close()
                                        readerPolisno.Close()
                                    End If
                                End Using
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Critical)
                            End Try
                        End If

                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                            reader.Close()
                        End If
                    End Using
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                Application.DoEvents()
                intRow = intRow + 1
            Loop

            'kry alle rekords wat polisno/persno moet reggemaak word
            getMissingRecords()

            If Me.grdInfoChange.Rows.Count > 0 Then
                MsgBox("Please fix the policy number or personnel number first. Click on the field and change it directly on the grid.", vbInformation)
                Me.btnCancel.Enabled = False
                blnCollectionsFix = False
                lblFixIncorrectData.Text = "Please fix the policy number or personnel number before you can complete the run."
                lblFixIncorrectData.Refresh()
            End If

            'Skryf die premie in maand(nie-multi) as 'n polisnommer in Maand voorkom, maar nie in tx leer nie - maand(match) = false
            'maw ons het 'n premie na multidata gestuur wat nie deur hulle betaal is nie.
            UpdateNonMatchedData()

            MsgBox("Finished with run", vbInformation)
            lblProcessing.Text = "Finished"
            Me.lblProcessing.Refresh()

            xlBook.Close()
            xlApp.Quit()
            xlSheet = Nothing
            xlBook = Nothing
            xlApp = Nothing
        Else
            MsgBox("File does not exist.", vbInformation)
        End If
    End Sub
    Private Sub CreateMaandData()
        Try
            Using conn3 As SqlConnection = SqlHelper.GetConnection

                Dim params3() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@PREMIE", SqlDbType.Money), _
                                                New SqlParameter("@VORD_PREMIE", SqlDbType.Money), _
                                                New SqlParameter("@AFSLUIT_DAT", SqlDbType.DateTime), _
                                                New SqlParameter("@Area", SqlDbType.NVarChar), _
                                                New SqlParameter("@JAAR", SqlDbType.SmallInt), _
                                                New SqlParameter("@MAAND", SqlDbType.SmallInt), _
                                                New SqlParameter("@TRANS_DAT", SqlDbType.DateTime), _
                                                New SqlParameter("@MS_TRANS_DAT", SqlDbType.DateTime), _
                                                New SqlParameter("@BETAALWYSE", SqlDbType.NVarChar), _
                                                New SqlParameter("@Kwit_boek", SqlDbType.NVarChar), _
                                                New SqlParameter("@Vord_DAT", SqlDbType.DateTime), _
                                                New SqlParameter("@Match", SqlDbType.Bit), _
                                                New SqlParameter("@Nie_Multi", SqlDbType.Money), _
                                                New SqlParameter("@Nie_MD", SqlDbType.Money), _
                                                New SqlParameter("@Oningewin", SqlDbType.Money), _
                                                New SqlParameter("@ingevorder", SqlDbType.Money), _
                                                New SqlParameter("@Pers_Nom", SqlDbType.NVarChar)}

                If Me.dtpSalaryCollectionDate.Enabled = False Then
                    params3(0).Value = strPolisno
                    params3(1).Value = Format(CDec(0), "#####.00")
                    params3(2).Value = Val(Mid(strLine, 49, 6) + "." + Mid(strLine, 56, 2))
                    params3(3).Value = Me.dtpCollectionsDate.Value
                    params3(4).Value = strArea
                    params3(5).Value = DateTime.Parse(Me.dtpCollectionsDate.Text).Year
                    params3(6).Value = DateTime.Parse(Me.dtpCollectionsDate.Text).Month
                    params3(7).Value = Now
                    params3(8).Value = DBNull.Value
                    params3(9).Value = strBetaalWyse
                    If strBetaalWyse = "3" Then
                        strBetaalWyse = strBetaalWyse
                    End If
                    params3(10).Value = ""
                    params3(11).Value = Mid(strLine, 108, 2) & "/" & Mid(106, 2) & "/" & Mid(strLine, 104, 2)
                    params3(12).Value = False
                    params3(13).Value = 0
                    params3(14).Value = Val(Mid(strLine, 49, 6) + "." + Mid(strLine, 56, 2))
                    params3(15).Value = 0
                    params3(16).Value = Val(Mid(strLine, 49, 6) + "." + Mid(strLine, 56, 2))
                    params3(17).Value = 0
                Else
                    params3(0).Value = strPolisno
                    params3(1).Value = Format(CDec(0), "#####.00")
                    params3(2).Value = dblCollectionsPremium
                    params3(3).Value = Me.dtpSalaryCollectionDate.Value
                    params3(4).Value = strArea
                    params3(5).Value = DateTime.Parse(Me.dtpCollectionsDate.Text).Year
                    params3(6).Value = DateTime.Parse(Me.dtpCollectionsDate.Text).Month
                    params3(7).Value = Now
                    params3(8).Value = Now
                    params3(9).Value = strBetaalWyse
                    params3(10).Value = ""
                    params3(11).Value = Me.dtpSalaryCollectionDate.Value
                    params3(12).Value = False
                    params3(13).Value = 0
                    params3(14).Value = dblCollectionsPremium
                    params3(15).Value = 0
                    params3(16).Value = dblCollectionsPremium
                    params3(17).Value = strPersNom
                End If

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.UpdateMaand", params3)
                If conn3.State = ConnectionState.Open Then
                    conn3.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub UpdateMaandData()
        Dim dblDifference As Double
        Try
            Using conn4 As SqlConnection = SqlHelper.GetConnection

                Dim params4() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@VORD_PREMIE", SqlDbType.Money), _
                                                New SqlParameter("@AFSLUIT_DAT", SqlDbType.DateTime), _
                                                New SqlParameter("@Area", SqlDbType.NVarChar), _
                                                New SqlParameter("@Vord_DAT", SqlDbType.DateTime), _
                                                New SqlParameter("@Match", SqlDbType.Bit), _
                                                New SqlParameter("@Oningewin", SqlDbType.Money), _
                                                New SqlParameter("@ingevorder", SqlDbType.Money)}
                If strPolisno = "1483001240" Or strPolisno = "7777000046" Then
                    strPolisno = strPolisno
                End If
                If Me.dtpSalaryCollectionDate.Enabled = False Then
                    'As gekry, bereken die verskil tussen maand(premie) en collections(premie)
                    If dblMaandPremie = Val(Mid(strLine, 49, 6) + "." + Mid(strLine, 56, 2)) Then
                        'As daar geen verskil is nie, word maand(match) = true
                        params4(5).Value = True
                        params4(6).Value = 0
                    Else
                        'As daar 'n verskil is, word maand(oningewin) = verskil
                        dblDifference = Format(Val(dblMaandPremie) - Val(Mid(strLine, 49, 6) + "." + Mid(strLine, 56, 2)), "####.00")
                        params4(5).Value = False
                        params4(6).Value = dblDifference
                    End If

                    params4(0).Value = strPolisno
                    params4(1).Value = Val(Mid(strLine, 49, 6) + "." + Mid(strLine, 56, 2))
                    params4(2).Value = Me.dtpCollectionsDate.Value
                    If strArea = "2" Then
                        strArea = strArea
                    End If
                    params4(3).Value = strArea
                    params4(4).Value = Mid(strLine, 108, 2) & "/" & Mid(strLine, 106, 2) & "/" & Mid(strLine, 104, 2)
                    params4(7).Value = Val(Mid(strLine, 49, 6) + "." + Mid(strLine, 56, 2))
                Else
                    'As gekry, bereken die verskil tussen maand(premie) en collections(premie)
                    If dblMaandPremie = dblCollectionsPremium Then
                        'As daar geen verskil is nie, word maand(match) = true
                        params4(5).Value = True
                        params4(6).Value = 0
                    Else
                        'As daar 'n verskil is, word maand(oningewin) = verskil
                        dblDifference = Format(Val(dblMaandPremie) - dblCollectionsPremium, "####.00")
                        params4(5).Value = False
                        params4(6).Value = dblDifference
                    End If

                    params4(0).Value = strPolisno
                    params4(1).Value = dblCollectionsPremium
                    params4(2).Value = Me.dtpSalaryCollectionDate.Value
                    params4(3).Value = strArea
                    params4(4).Value = Now
                    params4(7).Value = dblCollectionsPremium
                End If

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.UpdateMaand_Debiet", params4)
                If conn4.State = ConnectionState.Open Then
                    conn4.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub CreateCollectionsData()
        Try
            Using conn5 As SqlConnection = SqlHelper.GetConnection

                Dim params5() As SqlParameter = {New SqlParameter("@Debiet", SqlDbType.NVarChar), _
                                                New SqlParameter("@Bedrag", SqlDbType.Real), _
                                                New SqlParameter("@ITTot", SqlDbType.Real), _
                                                New SqlParameter("@HKTot", SqlDbType.Real), _
                                                New SqlParameter("@Bank2", SqlDbType.NVarChar), _
                                                New SqlParameter("@REKNr2", SqlDbType.NVarChar), _
                                                New SqlParameter("@T", SqlDbType.NVarChar), _
                                                New SqlParameter("@Naam", SqlDbType.NVarChar), _
                                                New SqlParameter("@Area", SqlDbType.NVarChar), _
                                                New SqlParameter("@Polis_no", SqlDbType.NVarChar), _
                                                New SqlParameter("@Area_kode", SqlDbType.NVarChar), _
                                                New SqlParameter("@Datum", SqlDbType.DateTime)}

                params5(0).Value = strDebitnr
                params5(1).Value = Val((Mid(strLine, 49, 6) + Mid(strLine, 56, 2)) / 100)
                params5(2).Value = Val(Mid(strLine, 60, 6) + Mid(strLine, 67, 2))
                params5(3).Value = Val(Mid(strLine, 71, 6) + Mid(strLine, 78, 2))
                params5(4).Value = Mid(strLine, 81, 6)
                params5(5).Value = Mid(strLine, 88, 13)
                params5(6).Value = Mid(strLine, 102, 1)
                params5(7).Value = Mid(strLine, 111, 30)
                params5(8).Value = strTakhoof
                params5(9).Value = "1" & strDebitnr.right(9)
                params5(10).Value = strArea
                params5(11).Value = Me.dtpCollectionsDate.Value

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.InsertCollectionsData", params5)
                If conn5.State = ConnectionState.Open Then
                    conn5.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Private Sub UpdateNonMatchedData()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Afsluit_dat", SqlDbType.DateTime), _
                                                New SqlParameter("@Betaalwyse", SqlDbType.NVarChar), _
                                                New SqlParameter("@area", SqlDbType.Int)}

                If Me.dtpSalaryCollectionDate.Enabled = False Then
                    params(0).Value = Me.dtpCollectionsDate.Value
                    params(1).Value = "4"
                    params(2).Value = DBNull.Value
                Else
                    params(0).Value = Me.dtpSalaryCollectionDate.Value
                    params(1).Value = "3"
                    params(2).Value = intSalaryArea
                End If

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.UpdateMaandNotMatched", params)

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    reader.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub getMissingRecords()
        grdInfoChange.AutoGenerateColumns = False
        grdInfoChange.DataSource = FetchMissingInfoForGrid()
        grdInfoChange.Refresh()

    End Sub
    Private Function FetchMissingInfoForGrid() As List(Of MaandEntity)
        Dim i As Integer = 0

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Afsluit_dat", SqlDbType.DateTime), _
                                                New SqlParameter("@Betaalwyse", SqlDbType.NVarChar), _
                                                New SqlParameter("@area", SqlDbType.Int)}

                If Me.dtpSalaryCollectionDate.Enabled = False Then
                    params(0).Value = Me.dtpCollectionsDate.Value
                    params(1).Value = "4"
                    params(2).Value = DBNull.Value
                Else
                    params(0).Value = Me.dtpSalaryCollectionDate.Value
                    params(1).Value = "3"
                    params(2).Value = intSalaryArea
                End If

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchMaandMissingRecords", params)

                Dim list As New List(Of MaandEntity)
                Do While reader.Read
                    Dim item As MaandEntity = New MaandEntity()

                    If reader("polisno") IsNot DBNull.Value Then
                        item.POLISNO = reader("polisno")
                    End If

                    If reader("Pers_Nom") IsNot DBNull.Value Then
                        item.Pers_Nom = reader("Pers_Nom")
                    End If
                    If reader("vord_premie") IsNot DBNull.Value Then
                        item.VORD_PREMIE = reader("vord_premie")
                    End If
                    If reader("pkMaand") IsNot DBNull.Value Then
                        item.pkMaand = reader("pkMaand")
                    End If

                    list.Add(item)
                    i = i + 1

                Loop

                Return list

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    reader.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function
    Private Sub optGeneral_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optGeneral.CheckedChanged
        Me.cmbArea.Enabled = False
        Me.Label30.Enabled = False
        Me.cmbArea.Text = ""
        Me.Label14.Enabled = False
        Me.dtpSalaryCollectionDate.Checked = False
        Me.dtpSalaryCollectionDate.Enabled = False
        Me.dtpCollectionsDate.Enabled = True
        Me.dtpCollectionsDate.Checked = True
    End Sub

    Private Sub optSalary_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optSalary.CheckedChanged
        Me.cmbArea.Enabled = True
        Me.Label30.Enabled = True
        Me.cmbArea.Text = ""
        Me.Label14.Enabled = True
        Me.dtpSalaryCollectionDate.Enabled = True
        Me.dtpSalaryCollectionDate.Checked = True
        Me.dtpCollectionsDate.Enabled = False
        Me.dtpCollectionsDate.Enabled = False
    End Sub
    Private Sub ReadExcelFileAndWriteDataBfn()
        Dim intRow As Integer

        If System.IO.File.Exists(strFilename) = True Then
            Dim xlApp As New Excel.Application
            Dim xlBook As Excel.Workbook
            Dim xlSheet As Excel.Worksheet

            xlBook = xlApp.Workbooks.Open(strFilename)
            xlSheet = xlBook.Worksheets(1)

            'kry die ry waar data moet begin lees word
            intRow = 5

            Do While Not xlSheet.Cells(intRow, "A").text = ""

                If Val(xlSheet.Cells(intRow, "A").text) = 0 Then
                    Exit Do
                End If

                dblCollectionsPremium = xlSheet.Cells(intRow, "C").text
                strPersNomFile = Trim(xlSheet.Cells(intRow, "A").text)
                'las nulle voor aan personeel nommer indien nodig
                strPersNomFile = strPersNomFile.PadLeft(7, "0")

                Try
                    Using conn As SqlConnection = SqlHelper.GetConnection
                        Dim param() As SqlParameter = {New SqlParameter("@Persno", SqlDbType.NVarChar), _
                                               New SqlParameter("@pkVersekeraar", SqlDbType.Int)}

                        param(0).Value = strPersNomFile
                        param(1).Value = intPKInsurer
                        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlByVersekeraarAndPersno", param)

                        If reader.Read Then
                            strPolisno = reader("polisno")
                            lblProcessing.Text = "Processing: " & strPolisno
                            Me.lblProcessing.Refresh()

                            strArea = reader("area")
                            strBetaalWyse = reader("bet_wyse")
                            strPersNom = reader("pers_nom")

                            Try
                                Using conn2 As SqlConnection = SqlHelper.GetConnection
                                    Dim param2() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                                    New SqlParameter("@afsluitdat", SqlDbType.Date)}

                                    param2(0).Value = strPolisno
                                    param2(1).Value = Me.dtpSalaryCollectionDate.Value

                                    Dim readerMaand As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[stats5].[FetchMaandPolisnoAfsluitdat]", param2)

                                    If Not (readerMaand.Read) Then
                                        'soek polisno + afsluitdatum in maand - as nie gekry, voeg dit by, dit beteken dat daar 'n polis deur multidata betaal is wat nie by Mooirivier is nie)
                                        CreateMaandData()
                                    Else
                                        dblMaandPremie = readerMaand("premie")
                                        strPersNom = reader("Pers_nom")
                                        UpdateMaandData()
                                    End If

                                    If conn2.State = ConnectionState.Open Then
                                        conn2.Close()
                                        readerMaand.Close()
                                    End If
                                End Using
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Critical)
                            End Try
                        End If

                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                            reader.Close()
                        End If
                    End Using
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                Application.DoEvents()
                intRow = intRow + 1
            Loop

            'Skryf die premie in maand(nie-multi) as 'n polisnommer in Maand voorkom, maar nie in tx leer nie - maand(match) = false
            'maw ons het 'n premie na multidata gestuur wat nie deur hulle betaal is nie.
            UpdateNonMatchedData()

            MsgBox("Finished with run", vbInformation)
            lblProcessing.Text = "Finished"
            Me.lblProcessing.Refresh()

            xlBook.Close()
            xlApp.Quit()
            xlSheet = Nothing
            xlBook = Nothing
            xlApp = Nothing
        Else
            MsgBox("File does not exist.", vbInformation)
        End If
    End Sub

    Private Sub grdInfoChange_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdInfoChange.CellClick
        intpkMaand = grdInfoChange.SelectedCells.Item(4).Value
    End Sub

    Private Sub UpdateMissingInfoForGrid()
        Dim i As Integer = 0

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@pkMaand", SqlDbType.Int), _
                                                New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@Pers_nom", SqlDbType.NVarChar)}

                params(0).Value = intpkMaand
                params(1).Value = strPolisnoChange
                params(2).Value = strPersnomChange

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.UpdateMaandPersnomChanged", params)

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    reader.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub grdInfoChange_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdInfoChange.CellEndEdit
        strPolisnoChange = grdInfoChange.SelectedCells.Item(0).Value
        strPersnomChange = grdInfoChange.SelectedCells.Item(1).Value
        'save polisno of persno        
        UpdateMissingInfoForGrid()

        'kry alle rekords wat polisno/persno moet reggemaak word
        getMissingRecords()

        If Me.grdInfoChange.Rows.Count = 0 Then
            blnCollectionsFix = True
        End If
        If blnCollectionsFix = True Then
            'Skryf die premie in maand(nie-multi) as 'n polisnommer in Maand voorkom, maar nie in tx leer nie - maand(match) = false
            'maw ons het 'n premie na multidata gestuur wat nie deur hulle betaal is nie.
            UpdateNonMatchedData()

            lblFixIncorrectData.Text = ""
            lblFixIncorrectData.Refresh()

            Me.btnCancel.Enabled = True

            MsgBox("Finished with run", vbInformation)
            lblProcessing.Text = "Finished"
            Me.lblProcessing.Refresh()
        End If

    End Sub

End Class
