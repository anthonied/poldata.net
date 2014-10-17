Option Strict Off
Option Explicit On

Imports System.Data.SqlClient
Imports System.IO
Imports DAL
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Net.Mail
Imports System.Configuration
Imports Microsoft.Reporting.WinForms
Imports System.Net
Imports System.Security.Principal
Friend Class Argief
    Inherits BaseForm
    'Description  : Archive of documents for current policy
    Dim strDocPath As String
    Dim strSortOrder As String
    Dim strSortOrderDesc As String
    Public list As List(Of ArgiefEntity)
    Dim blnReturnValue As Boolean 'Return values for form Ok - True, Cancel - False
    Dim strEmailApp As String
    Dim ASC As String
    Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click
        Me.Close()
        dgvArgief.DataSource = Nothing
    End Sub
    Private Sub btnHelp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnHelp.Click
        Dim strMessage As String
        strMessage = "Archive" & Chr(10) & Chr(10)
        strMessage = strMessage & Chr(149) & "Sort according to a column by clicking on the heading of the column." & Chr(10)
        strMessage = strMessage & Chr(149) & "To open a document, double-click on the item." & Chr(10)
        MsgBox(strMessage, MsgBoxStyle.Information)
    End Sub
    'Open the selected document
    'Add functionality to search for Archived documents not in server folder See previous versions for original code
    Private Sub btnOpen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOpen.Click
        openArchive()
    End Sub
    Sub openArchive()
        Dim strDocToOpen As String
        Dim strFilename As String
        Dim strFilenameWildcard As String
        Dim intStartFilename As Integer

        'On Error GoTo errorhandler
        Try
            strDocPath = dgvArgief.SelectedCells(6).Value
            ' docPath = ArgiefDataGridView.SelectedRows(0).Cells(5).Value
            strDocToOpen = gen_getArchivePath() & strDocPath

            If strDocPath <> "" Then
                'Check if this file exists in local archive folder

                If Dir(strDocToOpen, FileAttribute.Normal) = "" Then
                    If Not (File.Exists(strDocToOpen)) Then
                        'This file does not exist in local archive -> search
                        If MsgBox("This document does not exist in the local archive." & Chr(13) & "Want to search for?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                            'Set filename to search for
                            'Get the start position of the filename part
                            intStartFilename = InStr(1, strDocPath, "\")
                            'Get only the filename part
                            strFilename = Mid(strDocPath, intStartFilename + 1, Len(strDocPath) - intStartFilename)
                            strFilenameWildcard = Mid(strFilename, 1, Len(strFilename) - 3) & "*"

                            'Set commondialog properties
                            Me.CommonDialog1Open.Title = "search document: " & strDocPath
                            Me.CommonDialog1Open.FileName = strFilenameWildcard
                            Me.CommonDialog1Open.ShowDialog()

                            'Open the selected document from new location, if it is the correct document
                            If Me.CommonDialog1Open.FileName <> strFilename Then
                                MsgBox("The leather is chosen, do not match with the learning record.")
                            Else
                                'Kobus 19/06/2014 verander van openExcelDocument((Me.CommonDialog1Open.FileName))na
                                openAllTypeDocument((Me.CommonDialog1Open.FileName))
                            End If
                        End If
                    End If
                Else
                    'Open the file in the local archive
                    'Kobus 19/06/2014 verander van openExcelDocument(strDocToOpen) na
                    openAllTypeDocument(strDocToOpen)
                End If
            Else
                MsgBox("No document exists for this entry.", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Exit Sub

    End Sub
    Private Sub btnPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnPrint.Click
        ArgiefReportViewer.Show()
    End Sub
    Private Sub Argief_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Set form caption
        'Kobus 20/06/2014 haal die volgende uit - My.Application.Info.Title & 
        Me.Text = " Archive - " & Form1.TITEL.Text & " " & Persoonl.VOORL & " " & Persoonl.VERSEKERDE & " (" & Persoonl.POLISNO & ")"
        dgvArgief.DataSource = Nothing
        dgvArgief.BackgroundColor = System.Drawing.ColorTranslator.FromOle(RGB(178, 178, 178))
        PopulateGridDetails()
        ASC = "ASC"
        If dgvArgief.RowCount < 1 Then
            Me.btnPrint.Enabled = False
            Me.btnOpen.Enabled = False
            'Kobus 19/06/2014 voegby
            Me.btnBesonderhede.Enabled = False
            Me.btnEmail.Enabled = False
            'Kobus 19/06/2014 voegby
        Else
            If Not IsNothing(dgvArgief.SelectedCells(5).Value) Then
                Me.btnBesonderhede.Enabled = True
                Me.btnOpen.Enabled = True
                Me.btnPrint.Enabled = True
                Me.btnEmail.Enabled = False
            End If
        End If
    End Sub
    'Populate grid with records from database
    Private Function populateGrid() As List(Of ArgiefEntity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@polisno", SqlDbType.NVarChar)
                param.Value = Persoonl.POLISNO
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchArgiefByPolisno", param)
                Dim list As List(Of ArgiefEntity) = New List(Of ArgiefEntity)
                While reader.Read()
                    Dim item As ArgiefEntity = New ArgiefEntity()
                    item.Datum = reader("Datum")
                    'Dim dateD As String
                    'dateD = item.Datum.ToString
                    'dateD = String.Format(dateD, "{0:dd/mm/yyyy  HH:MM:SS}")
                    'item.Datum = CDate(dateD)
                    ''MsgBox("" & item.Datum, MsgBoxStyle.Exclamation)
                    item.Gebruiker = reader("Gebruiker")
                    'Kobus 16/07/2014 comment out
                    'item.Kategorie = reader("Kategorie")
                    item.epos_Adres = reader("epos_Adres")
                    item.pkArgief = reader("pkArgief")
                    item.Path = reader("Path")
                    If item.epos_Adres = "" Then
                        item.epos_Onderwerp = "Drukker"
                    Else
                        item.epos_Onderwerp = "E-pos"
                    End If
                    'Kobus 27/06/2014 voegby
                    If item.epos_Adres = "File" Then
                        item.epos_Onderwerp = ""
                    End If
                    item.Incoming = reader("Incoming")
                    'Kobus 16/07/2014 voegby
                    If IsDBNull(reader("fkArchiveCategories")) Then
                        item.fkArchiveCategories = 0
                    Else
                        item.fkArchiveCategories = reader("fkArchiveCategories")
                    End If

                    list.Add(item)

                End While
                Return list
                conn.Close()
            End Using

        Catch ex As Exception
            MsgBox("There's error trying to connect to the database.", MsgBoxStyle.Exclamation)
            Return Nothing
        End Try
    End Function
    'Populate grid
    Sub PopulateGridDetails()
        dgvArgief.BackgroundColor = System.Drawing.ColorTranslator.FromOle(RGB(178, 178, 178))
        dgvArgief.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvArgief.ReadOnly = True
        dgvArgief.AutoGenerateColumns = False
        list = populateGrid()
        If strSortOrder = "Date" Then
            list.Sort(AddressOf sortDatum)
            'Kobus 16/07/2014 comment out
            'ElseIf sortOrder = "Document" Then
            '    list.Sort(AddressOf sortKategorie)
        ElseIf strSortOrder = "Destination" Then
            list.Sort(AddressOf sortEpos_Onderwerp)
        ElseIf strSortOrder = "User" Then
            list.Sort(AddressOf sortGebruiker)
        ElseIf strSortOrder = "Email" Then
            list.Sort(AddressOf sortEpos_Adres)
        End If
        dgvArgief.DataSource = list
        ASC = "DESC"
    End Sub
    Sub PopulateGridDetailsDesc()
        dgvArgief.BackgroundColor = System.Drawing.ColorTranslator.FromOle(RGB(178, 178, 178))
        dgvArgief.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvArgief.ReadOnly = True
        dgvArgief.AutoGenerateColumns = False
        list = populateGrid()

        If strSortOrderDesc = "Date" Then
            list.Sort(AddressOf sortDatumDesc)
            'Kobus 16/07/2014 comment out
            'ElseIf sortOrderDesc = "Document" Then
            '    list.Sort(AddressOf sortdocumentDesc)
        ElseIf strSortOrderDesc = "Destination" Then
            list.Sort(AddressOf sortEpos_OnderwerpDesc)
        ElseIf strSortOrderDesc = "User" Then
            list.Sort(AddressOf sortGebruikerDesc)
        ElseIf strSortOrderDesc = "Email" Then
            list.Sort(AddressOf sortEpos_AdresDesc)
        End If

        dgvArgief.DataSource = list

        strDocPath = dgvArgief.SelectedCells(6).Value

        ASC = "ASC"
    End Sub

    Private Shared Function sortDatum(ByVal x As ArgiefEntity, ByVal y As ArgiefEntity) As Integer
        Return x.Datum.CompareTo(y.Datum)
    End Function
    Private Shared Function sortEpos_Onderwerp(ByVal x As ArgiefEntity, ByVal y As ArgiefEntity) As Integer
        Return x.epos_Onderwerp.CompareTo(y.epos_Onderwerp)
    End Function
    Private Shared Function sortGebruiker(ByVal x As ArgiefEntity, ByVal y As ArgiefEntity) As Integer
        Return x.Gebruiker.CompareTo(y.Gebruiker)
    End Function
    Private Shared Function sortEpos_Adres(ByVal x As ArgiefEntity, ByVal y As ArgiefEntity) As Integer
        Return x.epos_Adres.CompareTo(y.epos_Adres)
    End Function
    Private Shared Function sortpkArgief(ByVal x As ArgiefEntity, ByVal y As ArgiefEntity) As Integer
        Return x.pkArgief.CompareTo(y.pkArgief)
    End Function
    Private Shared Function sortDatumDesc(ByVal x As ArgiefEntity, ByVal y As ArgiefEntity) As Integer
        Return y.Datum.CompareTo(x.Datum)
    End Function
    'Kobus 16/07/2014 comment out
    'Private Shared Function sortKategorieDesc(ByVal x As ArgiefEntity, ByVal y As ArgiefEntity) As Integer
    '    Return y.Kategorie.CompareTo(x.Kategorie)
    'End Function
    Private Shared Function sortEpos_OnderwerpDesc(ByVal x As ArgiefEntity, ByVal y As ArgiefEntity) As Integer
        Return y.epos_Onderwerp.CompareTo(x.epos_Onderwerp)
    End Function
    Private Shared Function sortGebruikerDesc(ByVal x As ArgiefEntity, ByVal y As ArgiefEntity) As Integer
        Return y.Gebruiker.CompareTo(x.Gebruiker)
    End Function
    Private Shared Function sortEpos_AdresDesc(ByVal x As ArgiefEntity, ByVal y As ArgiefEntity) As Integer
        Return y.epos_Adres.CompareTo(x.epos_Adres)
    End Function
    Private Shared Function sortpkArgiefDesc(ByVal x As ArgiefEntity, ByVal y As ArgiefEntity) As Integer
        Return y.pkArgief.CompareTo(x.pkArgief)
    End Function
    '* Purpose  : Open the specified Excel document
    '* Inputs   : Document path
    Public Sub openExcelDocument(ByRef strDocPath As String)
        'Dim xlapp As New Microsoft.Office.Interop.Excel.Application
        'Dim xlbook As Microsoft.Office.Interop.Excel.Workbook

        'On Error GoTo errorhandler
        Try
            'Check if it is the correct file type
            'Dim blnUserControl As Boolean
            If Mid(strDocPath, Len(strDocPath) - 2, 3) = "xls" Then

            Else
                MsgBox("The file chosen is not in the correct format." & Chr(13) & "Only MS Excel files may be selected.", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Exit Sub
    End Sub

    Private Sub btnBesonderhede_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBesonderhede.Click
        ArgiefDetail.ShowDialog()
    End Sub

    Private Sub ArgiefDataGridView_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvArgief.CellContentDoubleClick
        openArchive()
    End Sub

    Private Sub ArgiefDataGridView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvArgief.Click
        Try
            If Not IsNothing(dgvArgief.SelectedCells(5).Value) Then
                Me.btnBesonderhede.Enabled = True
                Me.btnOpen.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ArgiefDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvArgief.CellContentClick
        dgvArgief.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub
    Private Sub ArgiefDataGridView_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvArgief.ColumnHeaderMouseClick

        If ASC = "ASC" Then
            strSortOrder = dgvArgief.Columns(e.ColumnIndex).HeaderText
            PopulateGridDetails()
        Else
            strSortOrderDesc = dgvArgief.Columns(e.ColumnIndex).HeaderText
            PopulateGridDetailsDesc()
        End If

    End Sub
    Public Sub openAllTypeDocument(ByRef strDocPath As String)
        '******************************************************************************
        ' Author       : Kobus
        ' Created      : 19/06/2014
        ' Purpose      : Open all types of files
        '******************************************************************************
        Dim psi As New ProcessStartInfo()
        With psi
            .FileName = strDocPath
            .UseShellExecute = True
        End With
        Process.Start(psi)
    End Sub
    Private Sub btnEmail_Click(sender As System.Object, e As System.EventArgs) Handles btnEmail.Click
        'Dim client As New emailEngine()
        emailEngine.signOn()
    End Sub
    Private Function signOn() As Boolean
        '    '******************************************************************************
        '    ' Author       : Kobus
        '    ' Created      : 19/06/2014
        '    ' Purpose      : Create an Outlook application.
        '    '******************************************************************************
        '        Dim strMsg As String

        '        On Error GoTo errorhandler
        '        strMsg = "Are you using Microsoft Outlook as your default email application?"
        '        strMsg = strMsg & Chr(13) & Chr(13) & "  'Yes' - Use Microsoft Outlook"
        '        strMsg = strMsg & Chr(13) & "  'No' - Use Outlook Express"
        '        strMsg = strMsg & Chr(13) & Chr(13) & "Please note: The email won't be sent until the next time you Send/Receive."

        '        Select Case MsgBox(strMsg, MsgBoxStyle.YesNoCancel)
        '            Case MsgBoxResult.Yes
        '                strEmailApp = "MSOL"
        '                signOn = True
        '            Case MsgBoxResult.No
        '                strEmailApp = "OLE"

        '                'Sign-on to Outlook express (default mail handler)
        '                MAPISession1.signOn()

        '                'Set session for messages
        '                MAPIMessage1.SessionID = MAPISession1.SessionID
        '                signOn = True
        '            Case Else
        '                signOn = False
        '        End Select
        '        Exit Function

        'errorhandler:
        '        If Err.Number = 32003 Then
        '            MsgBox("The e-mail functionality can not be used." & Chr(13) & "Moontlike redes mag wees dat daar geen e-pos gelaai is nie of die e-pos applikasie kon nie gebruik word nie., vbExclamation")

        '            signOn = False
        '        Else
        '            On Error GoTo 0
        '            Err.Raise(Err.Number)
        '        End If
    End Function
    Private Sub dgvArgief_DataBindingComplete(sender As Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvArgief.DataBindingComplete
        Dim strDate As String
        Dim blnInOut As Boolean
        'Kobus 16/07/2014 voegby
        Dim strDocument As String
        Dim intFkArchiveCategories As Integer

        For intInskrywing = 0 To dgvArgief.RowCount - 1

            blnInOut = dgvArgief.Rows(intInskrywing).Cells("Incoming").Value
            If blnInOut = True Then
                dgvArgief.Rows(intInskrywing).Cells("inOut").Value = "In"
            Else
                If Persoonl.TAAL = 0 Then
                    dgvArgief.Rows(intInskrywing).Cells("inOut").Value = "Uit"
                Else
                    dgvArgief.Rows(intInskrywing).Cells("inOut").Value = "Out"
                End If
            End If
            strDate = dgvArgief.Rows(intInskrywing).Cells("Datum").Value
            dgvArgief.Rows(intInskrywing).Cells("WysDatum").Value = String.Format(strDate, "{0:dd/mm/yyyy  HH:MM:SS}")

            'Kobus 16/07/2014 voegby

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@pkArchiveCategories", SqlDbType.NVarChar)}

                intFkArchiveCategories = dgvArgief.Rows(intInskrywing).Cells("fkArchiveCategories").Value
                params(0).Value = intFkArchiveCategories

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchArchiveCategoriesByPk", params)
                reader.Read()
                If Persoonl.TAAL = 0 Then
                    If intFkArchiveCategories <> 0 Then
                        strDocument = reader("DescriptionAfr")
                    Else
                        strDocument = "N/A"
                    End If
                Else
                    If intFkArchiveCategories <> 0 Then
                        strDocument = reader("DescriptionEng")
                    Else
                        strDocument = "N/A"
                    End If
                End If
                dgvArgief.Rows(intInskrywing).Cells("ShowCategorydesc").Value = strDocument
                conn.Close()
            End Using

        Next
    End Sub

End Class