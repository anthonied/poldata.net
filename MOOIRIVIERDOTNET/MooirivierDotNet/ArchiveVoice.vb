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

Friend Class ArchiveVoice
    Inherits BaseForm

    '************************************************************************************************
    ' Author       : Kobus
    ' Created      : 07/07/2014
    ' Purpose      : Keep record of voice recordings in connection with active policies
    '************************************************************************************************

    Dim docPath As String

    Dim sortOrder As String
    Dim sortOrderDesc As String
    Public list As List(Of ArchiveVoiceEntity)
    Public returnValue As Boolean 'Return values for form Ok - True, Cancel - False
    Dim strEmailApp As String
    Public intFkArchiveCategories As Integer

    Dim ASC As String


    Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click
        Me.Close()
        dgvArchiveVoice.DataSource = Nothing

    End Sub

    Private Sub btnHelp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnHelp.Click
        Dim message As Object
        message = "Archive - Phone Call Recordings " & Chr(10) & Chr(10)
        message = message & Chr(149) & " Sort according to a column by clicking on the the heading of the column." & Chr(10)
        message = message & Chr(149) & " To open a document, double-click on the item." & Chr(10)
        MsgBox(message, MsgBoxStyle.Information)
    End Sub
    'Open the selected document
    Private Sub btnOpen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOpen.Click
        openArchivevoice()
    End Sub

    Sub openArchivevoice()
        Dim strDocToOpen As String
        Dim strFilename As String
        Dim strFilenameWildcard As String
        Dim intStartFilename As Short

        Try
            docPath = dgvArchiveVoice.SelectedCells(6).Value
            ' docPath = ArgiefDataGridView.SelectedRows(0).Cells(5).Value
            'Kobus 11/07/2014 het hierdie funksie hier geskep - moet na BaseForm skuif
            strDocToOpen = gen_getVoicePath() & docPath

            If docPath <> "" Then
                'Check if this file exists in local archive folder

                If Dir(strDocToOpen, FileAttribute.Normal) = "" Then
                    If Not (File.Exists(strDocToOpen)) Then
                        'This file does not exist in local archive -> search
                        If MsgBox("This document does not exist in the local  voice archive." & Chr(13) & "Want to search for?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                            'Set filename to search for
                            'Get the start position of the filename part
                            intStartFilename = InStr(1, docPath, "\")
                            'Get only the filename part
                            strFilename = Mid(docPath, intStartFilename + 1, Len(docPath) - intStartFilename)
                            strFilenameWildcard = Mid(strFilename, 1, Len(strFilename) - 3) & "*"

                            'Set commondialog properties
                            Me.CommonDialog1Open.Title = "search document: " & docPath
                            Me.CommonDialog1Open.FileName = strFilenameWildcard
                            Me.CommonDialog1Open.ShowDialog()

                            'Open the selected document from new location, if it is the correct document
                            If Me.CommonDialog1Open.FileName <> strFilename Then
                                MsgBox("The leather is chosen, do not match with the learning record.")
                            Else
                                openAllTypeDocument((Me.CommonDialog1Open.FileName))
                            End If
                        End If
                    End If
                Else
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

    Private Sub ArchiveVoice_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Text = "     Voice Archive - " & Form1.TITEL.Text & " " & Persoonl.VOORL & " " & Persoonl.VERSEKERDE & " (" & Persoonl.POLISNO & ")"
        dgvArchiveVoice.DataSource = Nothing

        dgvArchiveVoice.BackgroundColor = System.Drawing.ColorTranslator.FromOle(RGB(178, 178, 178))
        PopulateGridDetails()
        ASC = "ASC"
        If dgvArchiveVoice.RowCount < 1 Then
            Me.btnPrint.Enabled = False
            Me.btnOpen.Enabled = False
            Me.btnBesonderhede.Enabled = False
        Else
            If Not IsNothing(dgvArchiveVoice.SelectedCells(6).Value) Then
                Me.btnBesonderhede.Enabled = True
                Me.btnOpen.Enabled = True
                Me.btnPrint.Enabled = True

            End If
        End If
    End Sub
    'Populate grid with records from database
    Private Function populateGrid() As List(Of ArchiveVoiceEntity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@polisno", SqlDbType.NVarChar)
                param.Value = glbPolicyNumber
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchArchiveVoiceByPolisno", param)

                Dim list As List(Of ArchiveVoiceEntity) = New List(Of ArchiveVoiceEntity)
                While reader.Read()
                    Dim item As ArchiveVoiceEntity = New ArchiveVoiceEntity()
                    item.pkArchiveVoice = reader("pkArchiveVoice")
                    item.CallDate = reader("CallDate")
                    item.Gebruiker = reader("Gebruiker")
                    item.Polisno = reader("Polisno")
                    item.ContactNumber = reader("ContactNumber")
                    item.CallerNumber = reader("CallerNumber")
                    item.fkArchiveCategories = reader("fkArchiveCategories")
                    item.FileName = reader("FileName")
                    item.Incoming = reader("Incoming")
                    list.Add(item)

                End While
                Return list
            End Using

        Catch ex As Exception
            MsgBox("There's error trying to connect to the database.", MsgBoxStyle.Exclamation)
            Return Nothing
        End Try
    End Function

    'Populate grid
    Sub PopulateGridDetails()
        dgvArchiveVoice.BackgroundColor = System.Drawing.ColorTranslator.FromOle(RGB(178, 178, 178))

        dgvArchiveVoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvArchiveVoice.ReadOnly = True
        dgvArchiveVoice.AutoGenerateColumns = False

        list = populateGrid()

        If sortOrder = "CallDate" Then
            list.Sort(AddressOf sortCallDateDesc)
        ElseIf sortOrder = "Polisno" Then
            list.Sort(AddressOf sortPolisnoDesc)
        ElseIf sortOrder = "ContactNumber" Then
            list.Sort(AddressOf sortContactNumberDesc)
        ElseIf sortOrder = "Gebruiker" Then
            list.Sort(AddressOf sortGebruikerDesc)
        ElseIf sortOrder = "CallerNumber" Then
            list.Sort(AddressOf sortCallerNumberDesc)
        ElseIf sortOrder = "fkArchiveCategories" Then
            list.Sort(AddressOf sortfkArchiveCategories)
        ElseIf sortOrder = "FileName" Then
            list.Sort(AddressOf sortFileNameDesc)
        ElseIf sortOrder = "pkArchiveVoice" Then
            list.Sort(AddressOf sortpkArchiveVoiceDesc)
        End If

        dgvArchiveVoice.DataSource = list

        ASC = "DESC"
    End Sub
    Sub PopulateGridDetailsDesc()
        dgvArchiveVoice.BackgroundColor = System.Drawing.ColorTranslator.FromOle(RGB(178, 178, 178))

        dgvArchiveVoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvArchiveVoice.ReadOnly = True
        dgvArchiveVoice.AutoGenerateColumns = False

        list = populateGrid()

        If sortOrderDesc = "CallDate" Then
            list.Sort(AddressOf sortCallDateDesc)
        ElseIf sortOrderDesc = "Polisno" Then
            list.Sort(AddressOf sortPolisnoDesc)
        ElseIf sortOrderDesc = "ContactNumber" Then
            list.Sort(AddressOf sortContactNumberDesc)
        ElseIf sortOrderDesc = "Gebruiker" Then
            list.Sort(AddressOf sortGebruikerDesc)
        ElseIf sortOrderDesc = "CallerNumber" Then
            list.Sort(AddressOf sortCallerNumberDesc)
        ElseIf sortOrderDesc = "fkArchiveVoiceCategories" Then
            list.Sort(AddressOf sortfkArchiveCategoriesDesc)
        ElseIf sortOrderDesc = "FileName" Then
            list.Sort(AddressOf sortFileNameDesc)
        ElseIf sortOrderDesc = "pkArchiveVoice" Then
            list.Sort(AddressOf sortpkArchiveVoiceDesc)
        End If

        dgvArchiveVoice.DataSource = list

        docPath = dgvArchiveVoice.SelectedCells(5).Value

        ASC = "ASC"
    End Sub

    Private Shared Function sortCallDate(ByVal x As ArchiveVoiceEntity, ByVal y As ArchiveVoiceEntity) As Integer
        Return x.CallDate.CompareTo(y.CallDate)
    End Function
    Private Shared Function sortfkArchiveCategories(ByVal x As ArchiveVoiceEntity, ByVal y As ArchiveVoiceEntity) As Integer
        Return x.fkArchiveCategories.CompareTo(y.fkArchiveCategories)
    End Function
    Private Shared Function sortPolisno(ByVal x As ArchiveVoiceEntity, ByVal y As ArchiveVoiceEntity) As Integer
        Return x.Polisno.CompareTo(y.Polisno)
    End Function
    Private Shared Function sortGebruiker(ByVal x As ArchiveVoiceEntity, ByVal y As ArchiveVoiceEntity) As Integer
        Return x.Gebruiker.CompareTo(y.Gebruiker)
    End Function
    Private Shared Function sortContactNumber(ByVal x As ArchiveVoiceEntity, ByVal y As ArchiveVoiceEntity) As Integer
        Return x.ContactNumber.CompareTo(y.ContactNumber)
    End Function
    Private Shared Function sortpkArchiveVoice(ByVal x As ArchiveVoiceEntity, ByVal y As ArchiveVoiceEntity) As Integer
        Return x.pkArchiveVoice.CompareTo(y.pkArchiveVoice)
    End Function
    Private Shared Function sortCallerNumber(ByVal x As ArchiveVoiceEntity, ByVal y As ArchiveVoiceEntity) As Integer
        Return y.CallerNumber.CompareTo(x.CallerNumber)
    End Function
    Private Shared Function sortFileName(ByVal x As ArchiveVoiceEntity, ByVal y As ArchiveVoiceEntity) As Integer
        Return y.FileName.CompareTo(x.FileName)
    End Function
    Private Shared Function sortCallDateDesc(ByVal x As ArchiveVoiceEntity, ByVal y As ArchiveVoiceEntity) As Integer
        Return y.CallDate.CompareTo(x.CallDate)
    End Function
    Private Shared Function sortfkArchiveCategoriesDesc(ByVal x As ArchiveVoiceEntity, ByVal y As ArchiveVoiceEntity) As Integer
        Return y.fkArchiveCategories.CompareTo(x.fkArchiveCategories)
    End Function
    Private Shared Function sortPolisnoDesc(ByVal x As ArchiveVoiceEntity, ByVal y As ArchiveVoiceEntity) As Integer
        Return y.Polisno.CompareTo(x.Polisno)
    End Function
    Private Shared Function sortGebruikerDesc(ByVal x As ArchiveVoiceEntity, ByVal y As ArchiveVoiceEntity) As Integer
        Return y.Gebruiker.CompareTo(x.Gebruiker)
    End Function
    Private Shared Function sortContactNumberDesc(ByVal x As ArchiveVoiceEntity, ByVal y As ArchiveVoiceEntity) As Integer
        Return y.ContactNumber.CompareTo(x.ContactNumber)
    End Function
    Private Shared Function sortCallerNumberDesc(ByVal x As ArchiveVoiceEntity, ByVal y As ArchiveVoiceEntity) As Integer
        Return y.CallerNumber.CompareTo(x.CallerNumber)
    End Function
    Private Shared Function sortFileNameDesc(ByVal x As ArchiveVoiceEntity, ByVal y As ArchiveVoiceEntity) As Integer
        Return y.FileName.CompareTo(x.FileName)
    End Function
    Private Shared Function sortpkArchiveVoiceDesc(ByVal x As ArchiveVoiceEntity, ByVal y As ArchiveVoiceEntity) As Integer
        Return y.pkArchiveVoice.CompareTo(x.pkArchiveVoice)
    End Function

    Private Sub btnBesonderhede_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBesonderhede.Click
        intFkArchiveCategories = dgvArchiveVoice.SelectedCells(8).Value
        ArchiveVoiceDetail.ShowDialog()
    End Sub

    Private Sub ArgiefDataGridView_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvArchiveVoice.CellContentDoubleClick
        openArchivevoice()
    End Sub

    Private Sub ArgiefDataGridView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvArchiveVoice.Click
        Try
            If Not IsNothing(dgvArchiveVoice.SelectedCells(6).Value) Then
                Me.btnBesonderhede.Enabled = True
                Me.btnOpen.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ArgiefDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvArchiveVoice.CellContentClick
        dgvArchiveVoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub VoiceDataGridView_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvArchiveVoice.ColumnHeaderMouseClick

        If ASC = "ASC" Then
            sortOrder = dgvArchiveVoice.Columns(e.ColumnIndex).HeaderText
            PopulateGridDetails()
        Else
            sortOrderDesc = dgvArchiveVoice.Columns(e.ColumnIndex).HeaderText
            PopulateGridDetailsDesc()
        End If

    End Sub

    Public Sub openAllTypeDocument(ByRef strDocPath As String)
        
        Dim psi As New ProcessStartInfo()
        With psi
            .FileName = strDocPath
            .UseShellExecute = True
        End With
        Process.Start(psi)
    End Sub

    Private Sub btnEmail_Click(sender As System.Object, e As System.EventArgs)
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
    Private Sub dgvArchiceVoice_DataBindingComplete(sender As Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvArchiveVoice.DataBindingComplete
        Dim dteCallDate As Date
        Dim blnIn_Out As Boolean

        For intInskrywing = 0 To dgvArchiveVoice.RowCount - 1

            blnIn_Out = dgvArchiveVoice.Rows(intInskrywing).Cells("Incoming").Value
            If blnIn_Out = True Then
                dgvArchiveVoice.Rows(intInskrywing).Cells("InOutWys").Value = "In"
            Else
                If Persoonl.TAAL = 0 Then
                    dgvArchiveVoice.Rows(intInskrywing).Cells("InOutWys").Value = "Uit"
                Else
                    dgvArchiveVoice.Rows(intInskrywing).Cells("InOutWys").Value = "Out"
                End If
            End If
            dteCallDate = dgvArchiveVoice.Rows(intInskrywing).Cells("CallDate").Value
            dgvArchiveVoice.Rows(intInskrywing).Cells("CallDateShow").Value = dteCallDate.ToString("dd/MM/yyyy HH:MM:ss")
        Next
    End Sub
End Class