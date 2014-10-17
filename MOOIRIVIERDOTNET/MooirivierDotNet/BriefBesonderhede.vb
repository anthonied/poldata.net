Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports DAL
Imports System.IO
Imports System.Configuration
Imports Microsoft.Reporting.WinForms
Imports System.Net

Friend Class BriefBesonderhede
    Inherits BaseForm

    'Description : Print a letter containing all info on policy, holder can change info and return letter
    '            : All  outstanding info can be collected using this letter
    '            : A table (Reporting) contains all the fields, and questions to display in letter.
    'Dim dbPoldata As DAO.Database
    'Dim dbInsCell As DAO.Database
    ''UPGRADE_WARNING: Arrays in structure rsCellphone may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    'Dim rsCellphone As DAO.Recordset
    ''UPGRADE_WARNING: Arrays in structure rsPersoonl may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    'Dim rsPersoonl As DAO.Recordset
    ''UPGRADE_WARNING: Arrays in structure rsReportFields may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    'Dim rsReportFields As DAO.Recordset
    ''UPGRADE_WARNING: Arrays in structure rsProperty may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    'Dim rsProperty As DAO.Recordset
    ''UPGRADE_WARNING: Arrays in structure rsBranchInfo may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    'Dim rsBranchInfo As DAO.Recordset
    ''UPGRADE_WARNING: Arrays in structure rsVehicles may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    'Dim rsVehicles As DAO.Recordset
    ''UPGRADE_WARNING: Arrays in structure rs may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    'Dim rs As DAO.Recordset
    ''UPGRADE_WARNING: Arrays in structure rs2 may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    'Dim rs2 As DAO.Recordset
    'Dim xlapp As Microsoft.Office.Interop.Excel.Application
    'Dim xlbook As Microsoft.Office.Interop.Excel.Workbook
    'Dim xlsheet As Microsoft.Office.Interop.Excel.Worksheet
    'Dim xlRange As Microsoft.Office.Interop.Excel.Range
    Dim sSql As String
    Dim sStr As String
    Dim BranchInfoRetrieved As Boolean
    Dim rownumber As Short 'Current rownumber in letter
    Dim letterIntroAfr As String
    Dim letterSubjectAfr As String
    Dim letterIntro2Afr As String
    Dim letterIntroEng As String
    Dim letterSubjectEng As String
    Dim letterIntro2Eng As String
    Dim chrChecked As String 'Checked character to print on letter
    Dim chrUnChecked As String 'Unchecked character to print on letter
    Dim language As Byte 'The language of the current policy holder
    Dim letternumber As Short
    Dim blnUserControl As Boolean
    Dim tempFilename As String
    Dim fs As Object
    Dim formattingArray() As String
    Dim holderTitle As String
    Dim letterSubject As String
    Dim VersekeraarSql As String
    'Dim rsVersekeraar As DAO.Recordset
    Dim strAreaBranch As String
    Public result As Byte() = Nothing

    Private Sub btnHelp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnHelp.Click
        Dim message As Object
        message = "Information relating to printing customer details." & Chr(10) & Chr(10)
        message = message & Chr(149) & "  Hold 'Ctrl' from more than one area seemed to be chosen" & Chr(10)
        message = message & Chr(149) & "  For eg. all the surnames beginning with A press key 'A' and 'Az' in the from and to fields" & Chr(10)
        message = message & Chr(149) & " Letters to the 'default' printer printed" & Chr(10)
        message = message & Chr(149) & "  Die briewe word een vir een gedruk" & Chr(10)
        message = message & Chr(149) & "  It is better to smaller volumes at a time to print" & Chr(10)
        message = message & Chr(149) & "  The letters only had'Preview' when a letter is to express" & Chr(10)
        message = message & Chr(149) & "  A list of what letters will be printed, appears only when more than one" & Chr(10)
        MsgBox(message, MsgBoxStyle.Information)
    End Sub

    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
        'Dim i As Object
        'Dim attachList As Object
        'Dim rsMakelaarSql As Object
        'Dim rsAreaBrief As Object
        'Dim strEmailMessage As String

        'If rdHuidig.Checked Then

        '    BriefStatus.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        '    BriefStatus.DataGridView1.ReadOnly = True
        '    BriefStatus.DataGridView1.AutoGenerateColumns = False
        '    BriefStatus.DataGridView1.DataSource = CurrentPolicy()

        '    BriefBesonderhedeReportViewer2.ShowDialog()
        '    Exit Sub
        ' End If
        If rdHuidig.Checked Then
            BriefStatus.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            BriefStatus.DataGridView1.ReadOnly = True
            BriefStatus.DataGridView1.AutoGenerateColumns = False
            BriefStatus.DataGridView1.DataSource = CurrentPolicy()


            If rdEpos.Checked Then

                If emailEngine.signOn Then
                    emailEngine.txtTo.Text = Persoonl.EMAIL
                    emailEngine.ShowDialog()

                    'If cancel was clicked - abort process else continue
                    If Not emailEngine.returnValue Then
                        emailEngine.signOff()
                        emailEngine.Close()
                        Exit Sub
                    End If
                End If
                If rdDrukker.Checked Then
                    CreateReportFile()
                    gen_ArchiveDocument(result, Persoonl.POLISNO, 14, "", "", "", "")
                ElseIf rdEpos.Checked Then
                    CreateReportFile()
                    gen_ArchiveDocument(result, Persoonl.POLISNO, 14, emailEngine.txtSubject.Text, emailEngine.txtTo.Text, emailEngine.txtBody.Text, getAttachmentsForEmailEngine, tempFilename)
                    emailEngine.sendMail(emailEngine.txtTo.Text, emailEngine.txtSubject.Text, emailEngine.txtBody.Text, tempFilename)
                End If
                Exit Sub
            Else
                BriefBesonderhedeReportViewer2.ShowDialog()
                Exit Sub
            End If
        End If

        If Me.cmbVersekeraar.SelectedIndex = -1 And Me.rdSpesifieke.Checked = True Then
            MsgBox("An insurer must be selected if more than one schedule to print.", MsgBoxStyle.Information)
            Exit Sub
        End If

        BriefStatus.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        BriefStatus.DataGridView1.ReadOnly = True
        BriefStatus.DataGridView1.AutoGenerateColumns = False
        BriefStatus.DataGridView1.DataSource = ListBesonderhedeBriefPersoonlStatus()
        BriefStatus.txtFormToPopulate.Text = Me.Name
        If BriefStatus.DataGridView1.RowCount = 1 Then
            If rdEpos.Checked Then

                If emailEngine.signOn Then
                    emailEngine.txtTo.Text = Persoonl.EMAIL
                    emailEngine.ShowDialog()

                    'If cancel was clicked - abort process else continue
                    If Not emailEngine.returnValue Then
                        emailEngine.signOff()
                        emailEngine.Close()
                        Exit Sub
                    End If
                End If
                If rdDrukker.Checked Then
                    CreateReportFile()
                    gen_ArchiveDocument(result, Persoonl.POLISNO, 14, "", "", "", "")
                ElseIf rdEpos.Checked Then
                    CreateReportFile()
                    gen_ArchiveDocument(result, Persoonl.POLISNO, 14, emailEngine.txtSubject.Text, emailEngine.txtTo.Text, emailEngine.txtBody.Text, getAttachmentsForEmailEngine, tempFilename)
                    emailEngine.sendMail(emailEngine.txtTo.Text, emailEngine.txtSubject.Text, emailEngine.txtBody.Text, tempFilename)
                End If

            Else
                BriefBesonderhedeReportViewer2.Show()
            End If

        ElseIf BriefStatus.DataGridView1.RowCount < 1 Then
            MsgBox("No record match the criteria.")
            Exit Sub
        Else
            BriefStatus.ShowDialog()
        End If

        lblStatus.Text = "Search criteria by policies"

        Me.Refresh()


    End Sub
    Sub CreateReportFile()
        Dim detailStream As Stream
        detailStream = createDetailFile("/Mooirivier/BriefBesonderhede")
    End Sub
    Public Function createDetailFile(ByVal reportPath As String) As Stream
        Dim stream As MemoryStream = Nothing
        Dim rview = New ReportViewer
        Dim authCookie As Cookie
        Dim authority As String
        authCookie = Nothing
        authority = Nothing
        Try
            Try
                'MyReportViewer.ServerReport.ReportServerCredentials =  = New MyReportServerCredentials()
                rview.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)

            Catch ex As Exception
                MsgBox("The ReportServer is unavailable at this moment. Try again later.")
            End Try

            rview.ServerReport.ReportServerUrl = New Uri(ConfigurationManager.AppSettings("ReportPath"))

            'begin params specific
            Dim polisno As String
            If rdHuidig.Checked = True Then
                polisno = Persoonl.POLISNO
            ElseIf rdSpesifieke.Checked = True And BriefStatus.DataGridView1.RowCount = 1 Then
                polisno = BriefStatus.DataGridView1.Rows(0).Cells(0).Value
            Else
                rdSpesifieke.Checked = True
                polisno = BriefStatus.DataGridView1.SelectedRows(0).Cells(0).Value
            End If

            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", polisno), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Area_kode", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", Persoonl.TAAL), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("pkVoertuie", FetchVoertuie.pkVoertuie)}


            'end params specific

            rview.ServerReport.ReportPath = reportPath
            rview.ServerReport.SetParameters(params)

            Dim encoding As String = ""
            Dim mimeType As String = ""
            Dim warnings As Microsoft.Reporting.WinForms.Warning() = Nothing
            Dim streamIDs As String() = Nothing
            Dim extension As String = ""
            Dim format As String = "PDF" '//Desired format goes here (PDF, Excel, or Image)
            Dim deviceInfo As String = "<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>"

            result = rview.ServerReport.Render(format, deviceInfo, mimeType, encoding, extension, streamIDs, warnings)

            stream = New MemoryStream(result.Length)
            stream.Write(result, 0, result.Length)

            Return stream
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Function CurrentPolicy() As List(Of PersoonlCriteria)

        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Language", SqlDbType.Int), _
                                                New SqlParameter("@Polisno", SqlDbType.NVarChar)}

                params(0).Value = Persoonl.TAAL
                params(1).Value = Persoonl.POLISNO

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[ReportFetchCurrentPolicy]", params)

                Dim list As List(Of PersoonlCriteria) = New List(Of PersoonlCriteria)

                While reader.Read()
                    Dim item As PersoonlCriteria = New PersoonlCriteria()

                    If Not IsDBNull(reader("POLISNO")) Then
                        item.PolisNo = reader("POLISNO")
                    End If
                    If Not IsDBNull(reader("VERSEKERDE")) Then
                        item.Surname = reader("VERSEKERDE")
                    End If
                    If Not IsDBNull(reader("VOORL")) Then
                        item.voorl = reader("VOORL")

                    End If
                    If Not IsDBNull(reader("AREA_BESK")) Then
                        item.Area = reader("AREA_BESK")
                    End If
                    item.posbestemming = reader("POSBESTEMMING")

                    If Persoonl.TAAL = 0 Then 'Afr

                        If item.posbestemming = "0" Then 'Posadres
                            item.SavePosbesbesteming = "Posadres"
                        ElseIf item.posbestemming = "1" Then 'Risikoadres
                            item.SavePosbesbesteming = "Risiko-adres"
                        ElseIf item.posbestemming = "2" Then 'Universiteitsposbus
                            item.SavePosbesbesteming = "Universiteitsposbus"
                        ElseIf item.posbestemming = "3" Then 'E-pos
                            item.SavePosbesbesteming = "E-pos"
                        Else
                            item.SavePosbesbesteming = "Incorrect mailing destination"
                        End If

                    Else 'Eng
                        If item.posbestemming = "0" Then 'Postal address
                            item.SavePosbesbesteming = "Postal address"
                        ElseIf item.posbestemming = "1" Then 'Risk address
                            item.SavePosbesbesteming = "Risk address"
                        ElseIf item.posbestemming = "2" Then 'University mailbox
                            item.SavePosbesbesteming = "University mailbox"
                        ElseIf item.posbestemming = "3" Then 'Email
                            item.SavePosbesbesteming = "Email"
                        Else
                            item.SavePosbesbesteming = "Foutiewe posbestemming"
                        End If

                    End If
                    If Persoonl.TAAL = 0 Then
                        Select Case Persoonl.GEKANS
                            Case True
                                getStatus = "Gekansellee"
                                item.Status = getStatus
                            Case False
                                getStatus = "Aktief"
                                item.Status = getStatus
                            Case Else
                                getStatus = "Onbekend"
                                item.Status = getStatus
                        End Select
                    Else
                        Select Case Persoonl.GEKANS
                            Case True
                                getStatus = "Cancelled"
                                item.Status = getStatus
                            Case False
                                getStatus = "Active"
                                item.Status = getStatus
                            Case Else
                                getStatus = "Unknown"
                                item.Status = getStatus
                        End Select
                    End If
                    list.Add(item)

                End While

                Return list
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function

    Function ListBesonderhedeBriefPersoonlStatus() As List(Of PersoonlCriteria)
        Try
            ' Dim sqlSurname As String
            Dim strArea As String = ""


            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Language", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlStatus", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlArea", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlSurnameFrom", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlSurnameTo", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlVersekeraar", SqlDbType.NVarChar), _
                                                New SqlParameter("@Sqlposbestemming", SqlDbType.NVarChar)}

                If rdSpesifieke.Checked Then
                    Select Case cmbTaal.SelectedIndex
                        Case 0
                            params(0).Value = DBNull.Value
                        Case 1 'Afr
                            params(0).Value = CStr(0)
                        Case 2 'Eng
                            params(0).Value = 1
                    End Select
                Else
                    params(0).Value = DBNull.Value
                End If

                'Sql for status
                Select Case cmbStatus.SelectedIndex
                    Case 0
                        params(1).Value = DBNull.Value
                    Case 1
                        params(1).Value = "0"
                    Case 2
                        params(1).Value = "1"
                End Select

                If Gebruiker.titel = "Programmeerder" Then
                    If lstArea.SelectedIndex <> -1 And lstArea.SelectedIndex <> 0 Then
                        For i = 0 To lstArea.SelectedItems.Count - 1
                            strArea = strArea + "'" + lstArea.SelectedItems(i) + "',"
                        Next
                        strArea = Mid(strArea, 1, Len(strArea) - 1)
                        'Mid(params(2).Value, Len(params(2).Value) - 1)

                    End If
                Else
                    For i = 0 To lstArea.Items.Count - 1
                        If lstArea.GetSelected(i) Then
                            strArea = strArea + "'" + lstArea.SelectedItems(i) + "',"
                        End If
                    Next
                    strArea = Mid(strArea, 1, Len(strArea) - 1)
                    ' Mid(params(2).Value, Len(params(2).Value) - 1)
                End If
                If strArea = "" Then
                    params(2).Value = DBNull.Value
                Else
                    params(2).Value = strArea
                End If

                'Surname
                If Trim(txtVanaf.Text) <> "" Then
                    params(3).Value = Trim(txtVanaf.Text)
                Else
                    params(3).Value = ""
                End If

                If Trim(txtTot.Text) <> "" Then
                    params(4).Value = txtTot.Text + "zzzz"
                Else
                    params(4).Value = "zzzz"
                End If

                params(5).Value = cmbVersekeraar.SelectedItem
                'params(6).Value = Me.cmbPosbestemming.SelectedItem
                Select Case cmbPosbestemming.SelectedIndex
                    Case 0
                        params(6).Value = DBNull.Value
                    Case 1
                        params(6).Value = "0"
                    Case 2
                        params(6).Value = "1"
                    Case 3
                        params(6).Value = "2"
                    Case 4
                        params(6).Value = "3"
                End Select

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[ReportFetchPersoonlCriteria1]", params)

                Dim list As List(Of PersoonlCriteria) = New List(Of PersoonlCriteria)

                While reader.Read()
                    Dim item As PersoonlCriteria = New PersoonlCriteria()

                    If Not IsDBNull(reader("POLISNO")) Then
                        item.PolisNo = reader("POLISNO")
                    End If
                    If Not IsDBNull(reader("VERSEKERDE")) Then
                        item.Surname = reader("VERSEKERDE")
                    End If
                    If Not IsDBNull(reader("VOORL")) Then
                        item.voorl = reader("VOORL")

                    End If
                    If Not IsDBNull(reader("AREA_BESK")) Then
                        item.Area = reader("AREA_BESK")
                    End If
                    item.posbestemming = reader("POSBESTEMMING")

                    If Persoonl.TAAL = 0 Then 'Afr

                        If item.posbestemming = "0" Then 'Posadres
                            item.SavePosbesbesteming = "Posadres"
                        ElseIf item.posbestemming = "1" Then 'Risikoadres
                            item.SavePosbesbesteming = "Risiko-adres"
                        ElseIf item.posbestemming = "2" Then 'Universiteitsposbus
                            item.SavePosbesbesteming = "Universiteitsposbus"
                        ElseIf item.posbestemming = "3" Then 'E-pos
                            item.SavePosbesbesteming = "E-pos"
                        Else
                            item.SavePosbesbesteming = "Incorrect mailing destination"
                        End If

                    Else 'Eng
                        If item.posbestemming = "0" Then 'Postal address
                            item.SavePosbesbesteming = "Postal address"
                        ElseIf item.posbestemming = "1" Then 'Risk address
                            item.SavePosbesbesteming = "Risk address"
                        ElseIf item.posbestemming = "2" Then 'University mailbox
                            item.SavePosbesbesteming = "University mailbox"
                        ElseIf item.posbestemming = "3" Then 'Email
                            item.SavePosbesbesteming = "Email"
                        Else
                            item.SavePosbesbesteming = "Foutiewe posbestemming"
                        End If

                    End If
                    If Persoonl.TAAL = 0 Then
                        Select Case Persoonl.GEKANS
                            Case True
                                getStatus = "Gekansellee"
                                item.Status = getStatus
                            Case False
                                getStatus = "Aktief"
                                item.Status = getStatus
                            Case Else
                                getStatus = "Onbekend"
                                item.Status = getStatus
                        End Select
                    Else
                        Select Case Persoonl.GEKANS
                            Case True
                                getStatus = "Cancelled"
                                item.Status = getStatus
                            Case False
                                getStatus = "Active"
                                item.Status = getStatus
                            Case Else
                                getStatus = "Unknown"
                                item.Status = getStatus
                        End Select
                    End If
                    list.Add(item)

                End While

                Return list
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function

    'Setup the letter styles
    Public Sub setupLetter()

        'xlapp.DisplayAlerts = False

        'Set column widths
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().ColumnWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(1, 1).ColumnWidth = 3.5
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().ColumnWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(1, 2).ColumnWidth = 3.5
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().ColumnWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(1, 3).ColumnWidth = 3.5
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().ColumnWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(1, 12).ColumnWidth = 11.14

        'xlRange = xlsheet.Range("D1:K1")
        'xlRange.ColumnWidth = 8

        ' ! Override standard report style - set font to 8 !
        'xlRange = xlsheet.Range("A30:L1000")
        'xlRange.Font.Size = 8
        'xlRange.RowHeight = 15

        'Set the style of the letter introduction
        'xlRange = xlsheet.Range("A30:L30")
        'xlRange.Cells.Merge()
        'xlRange.RowHeight = 57
        'xlRange.VerticalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlTop
        'xlRange.WrapText = True

        'Set line
        'letterhead_setLine(xlsheet, "A4", "L4")

    End Sub
    'Display the list of info for personal info with current values and space to alter information
    Public Sub displayPersoonlInfo()

        'Set heading style
        'setSectionHeadingStyle()

        'Get fields to display in letter
        'rsReportFields = dbPoldata.OpenRecordset("SELECT * FROM reporting WHERE tableName = 'persoonl' AND language = " & language & " ORDER BY displayOrder")

        'Set heading
        'If rsPersoonl.Fields("taal").Value = 0 Then
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 1).value = "1. Persoonlike inligting"
        'Else
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ' xlsheet.Cells._Default(rownumber, 1).value = "1. Personal information"
        'End If

        'rownumber = rownumber + 1
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().RowHeight. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Rows._Default(rownumber).RowHeight = 10.25
        'rownumber = rownumber + 1

        'Do While Not rsReportFields.EOF
        'Select Case rsReportFields.Fields("fieldname").Value
        'Case "taal"
        ' If language = 0 Then
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ' xlsheet.Cells._Default(rownumber, 5).value = "Afrikaans"
        'Else
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 5).value = "English"
        ' End If
        ' Case "titelnum"
        'If language = 0 Then
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 5).value = rsPersoonl.Fields("afrikaanseTitel").Value
        'Else
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ' xlsheet.Cells._Default(rownumber, 5).value = rsPersoonl.Fields("engelseTitel").Value
        'End If
        'Case Else
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 5).value = "'" & rsPersoonl.Fields(rsReportFields.Fields("fieldname")).Value
        'End Select

        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 1).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 1).value = rsReportFields.Fields("display").Value
        'xlsheet.Range("E" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        'xlsheet.Range("E" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        'xlsheet.Range("H" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        'xlsheet.Range("H" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline

        'rownumber = rownumber + 1
        'rsReportFields.MoveNext()
        'Loop

        ' rownumber = rownumber + 1
    End Sub
    'Set the branch info on the letter at specific position and according to language preference
    Public Sub setBranchInfo(ByRef rownumber As Short, ByRef colNumber As Short)

        'Only retrieve the branch information when no information has been retrieved
        'If Not BranchInfoRetrieved Then
        '	rsBranchInfo = dbPoldata.OpenRecordset("SELECT * FROM area WHERE area_kode in " &  Gebruiker.BranchCodes & " ")
        '	BranchInfoRetrieved = True
        'End If

        'Set branch information according to policy holders' language preference
        'If Not (rsBranchInfo.EOF And rsBranchInfo.BOF) Then
        '	If language = 0 Then
        'Use company name and reg no - when empty use only branchname
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        'If Trim(rsBranchInfo.Fields("tak_bknaam").Value) = "" Or IsDBNull(rsBranchInfo.Fields("tak_bknaam").Value) Then
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, colNumber) = "Mooirivier Makelaars " & rsBranchInfo.Fields("tak_naam").Value
        'Else
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, colNumber) = rsBranchInfo.Fields("tak_bknaam").Value
        'End If

        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        'If Not (Trim(rsBranchInfo.Fields("tak_regno").Value) = "" Or IsDBNull(rsBranchInfo.Fields("tak_regno").Value)) Then
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 1, colNumber) = rsBranchInfo.Fields("tak_regno").Value
        'rownumber = rownumber + 1
        'End If

        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 1, colNumber) = rsBranchInfo.Fields("tak_straat").Value
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 2, colNumber) = rsBranchInfo.Fields("tak_voorstad").Value & " " & rsBranchInfo.Fields("tak_straat_poskode").Value

        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 4, colNumber) = "Posbus " & rsBranchInfo.Fields("tak_posbus").Value
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 5, colNumber) = rsBranchInfo.Fields("tak_dorp").Value
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 6, colNumber) = rsBranchInfo.Fields("tak_poskode").Value

        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 8, colNumber) = "Tel: " & rsBranchInfo.Fields("tak_tel").Value
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 9, colNumber) = "Faks: " & rsBranchInfo.Fields("tak_faks").Value
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 10, colNumber) = "E-pos: " & rsBranchInfo.Fields("tak_epos").Value

        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 12, colNumber) = "Kantoorure: " & rsBranchInfo.Fields("tak_dae1(a)").Value
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ' xlsheet.Cells._Default(rownumber + 13, colNumber) = rsBranchInfo.Fields("tak_dae2(a)").Value
        'Else
        'Use company name and reg no - when empty use only branchname
        ' 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        'if Trim(rsBranchInfo.Fields("tak_bknaam(e)").Value) = "" Or IsDBNull(rsBranchInfo.Fields("tak_bknaam(e)").Value) Then
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, colNumber) = "Mooirivier Brokers " & rsBranchInfo.Fields("tak_naam").Value
        '  Else
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, colNumber) = rsBranchInfo.Fields("tak_bknaam(e)").Value
        'End If

        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        'If Not (Trim(rsBranchInfo.Fields("tak_regno(e)").Value) = "" Or IsDBNull(rsBranchInfo.Fields("tak_regno(e)").Value)) Then
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 1, colNumber) = rsBranchInfo.Fields("tak_regno(e)").Value
        ' rownumber = rownumber + 1
        'End If

        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 1, colNumber) = rsBranchInfo.Fields("tak_straat(e)").Value
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 2, colNumber) = rsBranchInfo.Fields("tak_voorstad").Value & " " & rsBranchInfo.Fields("tak_straat_poskode").Value

        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ' xlsheet.Cells._Default(rownumber + 4, colNumber) = "PO Box " & rsBranchInfo.Fields("tak_posbus").Value
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 5, colNumber) = rsBranchInfo.Fields("tak_dorp").Value
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ' xlsheet.Cells._Default(rownumber + 6, colNumber) = rsBranchInfo.Fields("tak_poskode").Value

        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ' xlsheet.Cells._Default(rownumber + 8, colNumber) = "Tel: " & rsBranchInfo.Fields("tak_tel").Value
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 9, colNumber) = "Fax: " & rsBranchInfo.Fields("tak_faks").Value
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 10, colNumber) = "E-mail: " & rsBranchInfo.Fields("tak_epos").Value

        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 12, colNumber) = "Office hours: " & rsBranchInfo.Fields("tak_dae1(e)").Value
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 13, colNumber) = rsBranchInfo.Fields("tak_dae2(e)").Value
        '	End If 'language = 0
        'End If 'bof eof
    End Sub
    'Set the address information of the specific policy holder
    Public Sub setAddress(ByRef rownumber As Short, ByRef colNumber As Short)

        'If language = 0 Then
        'sStr = rsPersoonl.Fields("afrikaanseTitel").Value & " " & rsPersoonl.Fields("voorl").Value & " " & rsPersoonl.Fields("versekerde").Value
        'Else
        ' sStr = rsPersoonl.Fields("engelseTitel").Value & " " & rsPersoonl.Fields("voorl").Value & " " & rsPersoonl.Fields("versekerde").Value
        'End If

        'Only display address lines which contains information
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        ' If Trim(rsPersoonl.Fields("adres").Value) <> "" And Not IsDBNull(rsPersoonl.Fields("adres").Value) Then
        ' sStr = sStr & Chr(10) & rsPersoonl.Fields("adres").Value
        ' End If

        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        'If Trim(rsPersoonl.Fields("adres4").Value) <> "" And Not IsDBNull(rsPersoonl.Fields("adres4").Value) Then
        'sStr = sStr & Chr(10) & rsPersoonl.Fields("adres4").Value
        ' End If

        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        'If Trim(rsPersoonl.Fields("adres3").Value) <> "" And Not IsDBNull(rsPersoonl.Fields("adres3").Value) Then
        'sStr = sStr & Chr(10) & rsPersoonl.Fields("adres3").Value
        ' End If

        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        'If Trim(rsPersoonl.Fields("adres2").Value) <> "" And Not IsDBNull(rsPersoonl.Fields("adres2").Value) Then
        'sStr = sStr & Chr(10) & rsPersoonl.Fields("adres2").Value
        'End If

        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, colNumber) = sStr
    End Sub
    'Display all the properties with their info
    Public Sub displayPropertyInfo()
        'Dim countProperty As Object
        'Dim printDots As Object
        'Set heading style
        'setSectionHeadingStyle()

        'Get fields to display in letter
        'rsReportFields = dbPoldata.OpenRecordset("SELECT * FROM reporting WHERE tableName = 'huis' AND language = " & language & " ORDER BY displayOrder")

        'sSql = "SELECT huis.*, nameAfr, nameEng FROM huis "
        'sSql = sSql & " LEFT JOIN [HomeLoanOrg] ON [HomeLoanOrg].pkHomeLoanOrg = huis.fkHomeLoanOrg"
        'sSql = sSql & " WHERE polisno = '" & rsPersoonl.Fields("polisno").Value & "' AND cancelled = false"
        'rsProperty = dbPoldata.OpenRecordset(sSql)

        'If language = 0 Then
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 1).value = "3. Eiendomme"
        'Else
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 1).value = "3. Property"
        'End If

        ' rownumber = rownumber + 2
        'Do While Not rsProperty.EOF
        'Do While Not rsReportFields.EOF
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 1).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ' xlsheet.Cells._Default(rownumber, 1).value = rsReportFields.Fields("display").Value
        'UPGRADE_WARNING: Couldn't resolve default property of object printDots. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'printDots = True

        'Select Case LCase(rsReportFields.Fields("fieldname").Value)
        ''Case "adres_h1"
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 5).value = "'" & rsProperty.Fields(rsReportFields.Fields("fieldname")).Value
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ' xlsheet.Cells._Default(rownumber, 5).Font.Bold = True
        '   Case "tipe_dak"
        'listTipeDak(rsProperty.Fields("tipe_dak").Value)
        '  Case "struktuur"
        ' listStruktuur(rsProperty.Fields("struktuur").Value)
        'UPGRADE_WARNING: Couldn't resolve default property of object printDots. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'printDots = False
        '  Case "a_komm"
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '  xlsheet.Cells._Default(rownumber, 5).value = getAlarmComm(rsProperty.Fields("a_komm").Value & "")
        ' Case "a_goedgekeur"
        'listYesNo(rsProperty.Fields("a_goedgekeur").Value)
        'UPGRADE_WARNING: Couldn't resolve default property of object printDots. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'printDots = False
        ' Case "alarmreaksie"
        'listYesNo(rsProperty.Fields("alarmreaksie").Value & "")
        'UPGRADE_WARNING: Couldn't resolve default property of object printDots. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'printDots = False
        ' Case "sekuriteit"
        'listSekuriteit(rsProperty.Fields("sekuriteitBitValue").Value)
        'UPGRADE_WARNING: Couldn't resolve default property of object printDots. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ' printDots = False
        '  Case "mainproperty"
        ' listYesNo(rsProperty.Fields("mainproperty").Value & "")
        'UPGRADE_WARNING: Couldn't resolve default property of object printDots. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ' printDots = False
        'Case "fkpropertytype"
        'listPropertyType(CInt(rsProperty.Fields("fkPropertyType").Value & ""))
        'UPGRADE_WARNING: Couldn't resolve default property of object printDots. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'printDots = False
        ' Case "fkhomeloanorg"
        ' If language = 0 Then
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 5).value = rsProperty.Fields("nameAfr").Value
        'Else
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ' xlsheet.Cells._Default(rownumber, 5).value = rsProperty.Fields("nameEng").Value
        'End If
        ' Case "weerligbeskerming"
        'listYesNo(rsProperty.Fields("weerligbeskerming").Value)
        'UPGRADE_WARNING: Couldn't resolve default property of object printDots. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'printDots = False
        ' Case "grasdakaanhuis"
        'listYesNo(rsProperty.Fields("lapa").Value & "")
        'UPGRADE_WARNING: Couldn't resolve default property of object printDots. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ' printDots = False
        '  Case "grasdakgrootte"
        ' listGrasdakgrootte()
        'UPGRADE_WARNING: Couldn't resolve default property of object printDots. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'printDots = False
        ' Case "honde"
        ' listYesNo()
        'If language = 0 Then
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ' xlsheet.Cells._Default(rownumber, 7).value = "Beskryf:"
        ' Else
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 7).value = "Describe:"
        'End If
        'UPGRADE_WARNING: Couldn't resolve default property of object printDots. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'printDots = False
        '    Case Else
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 5).value = "'" & rsProperty.Fields(rsReportFields.Fields("fieldname")).Value
        'End Select

        'xlsheet.Range("E" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        'xlsheet.Range("E" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline

        'UPGRADE_WARNING: Couldn't resolve default property of object printDots. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If printDots Then
        '    xlsheet.Range("H" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '    xlsheet.Range("H" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        'End If

        'rownumber = rownumber + 1
        'rsReportFields.MoveNext()
        'Loop
        'UPGRADE_WARNING: Couldn't resolve default property of object countProperty. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'countProperty = countProperty + 1

        'displayHouseSpecifiedItems()

        'rsProperty.MoveNext()
        'rownumber = rownumber + 1
        'rsReportFields.MoveFirst()
        'Loop

        'rownumber = rownumber + 1
    End Sub

    'Get the type of alarm communication
    Public Function getAlarmComm(ByRef alarmCommindex As String) As String
        If language = 0 Then
            Select Case alarmCommindex
                Case "2"
                    getAlarmComm = "Radio"
                Case "3"
                    getAlarmComm = "Telefoon"
                Case Else
                    getAlarmComm = ""
            End Select
        Else
            Select Case alarmCommindex
                Case "2"
                    getAlarmComm = "Radio"
                Case "3"
                    getAlarmComm = "Telephone"
                Case Else
                    getAlarmComm = ""
            End Select
        End If
    End Function

    'Display all the vehicles with their info
    Public Sub displayVehicleInfo()
        'Dim k As Object
        'Dim printDots As Object
        ''Set heading style
        'setSectionHeadingStyle()

        'Get fields to display in letter
        'rsReportFields = dbPoldata.OpenRecordset("SELECT * FROM reporting WHERE tableName = 'voertuie' AND language = " & language & " ORDER BY displayOrder")

        ''Get all vehicles for policy (M&M and Diverse)
        'sSql = "SELECT voertuie.*, motors.maak, motors.besk FROM voertuie "
        'sSql = sSql & " LEFT JOIN motors ON voertuie.kode = motors.kode AND voertuie.eeu = motors.eeu AND voertuie.jaar = motors.jaar"
        'sSql = sSql & " WHERE not ander AND polisno = '" & rsPersoonl.Fields("polisno").Value & "' AND cancelled = false"
        'sSql = sSql & " UNION"
        'sSql = sSql & " SELECT voertuie.*, a_voertuig.maak, a_voertuig.besk FROM voertuie "
        'sSql = sSql & " LEFT JOIN a_voertuig ON voertuie.kode = a_voertuig.kode AND voertuie.eeu = a_voertuig.eeu AND voertuie.jaar = a_voertuig.jaar "
        'sSql = sSql & " WHERE ander AND polisno = '" & rsPersoonl.Fields("polisno").Value & "' AND cancelled = false"
        'rsVehicles = dbPoldata.OpenRecordset(sSql)

        'If language = 0 Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 1).value = "5. Voertuie"
        'Else
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 1).value = "5. Vehicles"
        'End If

        'rownumber = rownumber + 1
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().RowHeight. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Rows._Default(rownumber).RowHeight = 10.25
        'rownumber = rownumber + 1

        'Do While Not rsVehicles.EOF
        '	Do While Not rsReportFields.EOF
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 1).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 1).value = rsReportFields.Fields("display").Value
        '		'UPGRADE_WARNING: Couldn't resolve default property of object printDots. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		printDots = True

        '		Select Case rsReportFields.Fields("fieldname").Value
        '			Case "maak"
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '   xlsheet.Cells._Default(rownumber, 5).value = rsVehicles.Fields("maak").Value
        '   'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '   xlsheet.Cells._Default(rownumber, 5).Font.Bold = True
        'Case "besk"
        '   'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '   xlsheet.Cells._Default(rownumber, 5).value = rsVehicles.Fields("besk").Value
        '   'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '   xlsheet.Cells._Default(rownumber, 5).Font.Bold = True
        'Case "n_plaat"
        '   'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '   xlsheet.Cells._Default(rownumber, 5).value = rsVehicles.Fields("n_plaat").Value
        'Case "tipe"
        '   listVehicleTypes(rsVehicles.Fields("tipe").Value)
        '   'UPGRADE_WARNING: Couldn't resolve default property of object printDots. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '   printDots = False
        'Case "tipe_dek"
        '   listVehicleCover(rsVehicles.Fields("tipe_dek").Value)
        '   'UPGRADE_WARNING: Couldn't resolve default property of object printDots. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '   printDots = False
        'Case "gebruik"
        '   listVehicleUses(rsVehicles.Fields("gebruik").Value)
        '   'UPGRADE_WARNING: Couldn't resolve default property of object printDots. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '   printDots = False
        'Case "sekeruteit"
        '   listVehicleSecurity(rsVehicles.Fields("sekuriteitBitValue").Value)
        '   'UPGRADE_WARNING: Couldn't resolve default property of object printDots. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '   printDots = False
        'Case "motorplan"
        '   listYesNo(rsVehicles.Fields("motorplan").Value & "")
        '   'UPGRADE_WARNING: Couldn't resolve default property of object printDots. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '   printDots = False
        'Case "jaar"
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '   xlsheet.Cells._Default(rownumber, 5).value = "'" & rsVehicles.Fields("eeu").Value & rsVehicles.Fields("jaar").Value
        'Case "ingevoer"
        '   listYesNo(rsVehicles.Fields("ingevoer").Value)
        'Case "laeprofielbande"
        '   listYesNo(rsVehicles.Fields("laeprofielbande").Value & "")
        '   'UPGRADE_WARNING: Couldn't resolve default property of object printDots. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '   printDots = False
        'Case "motorhuis"
        '   listYesNo(rsVehicles.Fields("motorhuis").Value & "")
        '   'UPGRADE_WARNING: Couldn't resolve default property of object printDots. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '   printDots = False
        'Case "waardeTipe"
        '   'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '   xlsheet.Cells._Default(rownumber, 5).value = getWaardeTipe(rsVehicles.Fields("waardeTipe").Value & "")
        'Case "motorstatus"
        '   'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '   xlsheet.Cells._Default(rownumber, 5).value = gen_getVehicleStatus(language, rsVehicles.Fields("motorstatus").Value & "")
        'Case Else
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     xlsheet.Cells._Default(rownumber, 5).value = "'" & rsVehicles.Fields(rsReportFields.Fields("fieldname")).Value
        '	End Select

        '     xlsheet.Range("E" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '     xlsheet.Range("E" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline

        '     'UPGRADE_WARNING: Couldn't resolve default property of object printDots. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     If printDots Then
        '         xlsheet.Range("H" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '         xlsheet.Range("H" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '     End If

        '     rownumber = rownumber + 1
        '     rsReportFields.MoveNext()
        'Loop 

        'Display all factory fitted items
        'If language = 0 Then
        '    rs2 = dbPoldata.OpenRecordset("SELECT * FROM voertuieStandaard WHERE beskrywingAfrikaans <> 'n.v.t.' ORDER BY beskrywingAfrikaans")

        '    If Not (rs2.EOF And rs2.BOF) Then
        '        'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        k = 1
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber, 1).value = "Fabrieksgeïnstalleerde items"

        '        Do While Not rs2.EOF
        '            'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            If k = 5 Then 'Move to next line after 4 (5-1) entries
        '                rownumber = rownumber + 1
        '                'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                k = 1
        '            End If

        '            sSql = "SELECT * FROM voertuiefabrieks WHERE fkVoertuie = " & rsVehicles.Fields("pkVoertuie").Value & " AND fkVoertuieStandaard = " & rs2.Fields("pkVoertuieStandaard").Value
        '            rs = dbPoldata.OpenRecordset(sSql)

        'If (rs.EOF And rs.BOF) Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, k * 2 + 3).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, (k * 2) + 3).value = chrUnChecked & " " & rs2.Fields("beskrywingafrikaans").Value
        'Else
        '    'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, k * 2 + 3).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, (k * 2) + 3).value = chrChecked & " " & rs2.Fields("beskrywingafrikaans").Value
        'End If

        'xlsheet.Range("E" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        'xlsheet.Range("E" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        ''UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'k = k + 1
        'rs2.MoveNext()
        '        Loop
        '    End If
        'Else
        'rs2 = dbPoldata.OpenRecordset("SELECT * FROM voertuieStandaard WHERE beskrywingAfrikaans <> 'n.v.t.' ORDER BY beskrywingEngels")
        'If Not (rs2.EOF And rs2.BOF) Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    k = 1
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 1).value = "Factory fitted items"

        '    Do While Not rs2.EOF
        '        'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        If k = 5 Then 'Move to next line after 4 (5-1) entries
        '            rownumber = rownumber + 1
        '            'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            k = 1
        '        End If

        '        sSql = "SELECT * FROM voertuiefabrieks WHERE fkVoertuie = " & rsVehicles.Fields("pkVoertuie").Value & " AND fkVoertuieStandaard = " & rs2.Fields("pkVoertuieStandaard").Value
        '        rs = dbPoldata.OpenRecordset(sSql)

        '        If (rs.EOF And rs.BOF) Then
        '            'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, k * 2 + 3).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber, (k * 2) + 3).value = chrUnChecked & " " & rs2.Fields("beskrywingengels").Value
        '        Else
        ''UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, k * 2 + 3).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, (k * 2) + 3).value = chrChecked & " " & rs2.Fields("beskrywingengels").Value
        '        End If

        'xlsheet.Range("E" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        'xlsheet.Range("E" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        ''UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'k = k + 1
        'rs2.MoveNext()
        '    Loop
        'End If
        'End If
        'rownumber = rownumber + 1

        'displayVehicleSpecifiedItems()

        'rsVehicles.MoveNext()

        'rownumber = rownumber + 2

        'rsReportFields.MoveFirst()
        'rs2.MoveFirst()
        'Loop 

    End Sub
    'Display the list of cellphones
    Public Sub displayCellphoneInfo()
        'Dim i As Object
        'Dim k As Object
        'Dim numberOfRows As Byte

        ''Number of extra rows for cellphones
        'numberOfRows = 2

        'rsCellphone = dbInsCell.OpenRecordset("SELECT * FROM inscell_details WHERE status = 'A' AND polisno = '" & rsPersoonl.Fields("polisno").Value & "'")

        ''Set heading style
        'setSectionHeadingStyle()

        'If language = 0 Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 1).value = "2. Selfone (Selfone wat onder hierdie polis gedek moet word)"

        '	rownumber = rownumber + 1
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().RowHeight. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Rows._Default(rownumber).RowHeight = 10.25
        '	rownumber = rownumber + 1

        'Heading
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Cells._Default(rownumber, 1).value = "Maak"
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Cells._Default(rownumber, 4).value = "Model"
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Cells._Default(rownumber, 5).value = "Serienommer (IMEI)"
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Cells._Default(rownumber, 8).value = "Kontrakdatum"
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Cells._Default(rownumber, 10).value = "Waarde"
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Cells._Default(rownumber, 11).value = "Selfoonnommer"
        '      xlsheet.Range("A" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Rows._Default(rownumber).Font.Bold = True
        'Else
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Cells._Default(rownumber, 1).value = "2. Cellphones (Cellphones to be covered under this policy)"

        '      rownumber = rownumber + 1
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().RowHeight. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Rows._Default(rownumber).RowHeight = 10.25
        '      rownumber = rownumber + 1

        '      'Heading
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Cells._Default(rownumber, 1).value = "Make"
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Cells._Default(rownumber, 4).value = "Model"
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Cells._Default(rownumber, 5).value = "Serial number (IMEI)"
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Cells._Default(rownumber, 8).value = "Contract start date"
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Cells._Default(rownumber, 10).value = "Value"
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Cells._Default(rownumber, 11).value = "Cellphone number"
        '      xlsheet.Range("A" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Rows._Default(rownumber).Font.Bold = True
        'End If
        '      rownumber = rownumber + 1

        '      'Set the borders and lines for cellphone grid
        '      For k = 1 To numberOfRows
        '          xlsheet.Range("A" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '          xlsheet.Range("A" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '          xlsheet.Range("A" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '          xlsheet.Range("A" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '          xlsheet.Range("D" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '          xlsheet.Range("D" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '          xlsheet.Range("E" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '          xlsheet.Range("E" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '          xlsheet.Range("H" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '          xlsheet.Range("H" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '          xlsheet.Range("J" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '          xlsheet.Range("J" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '          xlsheet.Range("K" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '          xlsheet.Range("K" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '          rownumber = rownumber + 1
        '      Next

        '      'Populate with existing data
        '      'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      i = numberOfRows
        '      If Not (rsCellphone.EOF And rsCellphone.BOF) Then
        'Do While Not rsCellphone.EOF
        '    'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber - i, 1).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber - i, 1).value = rsCellphone.Fields("phone_make").Value
        '    'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber - i, 4).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber - i, 4).value = rsCellphone.Fields("phone_model").Value
        '    'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber - i, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber - i, 5).value = "'" & rsCellphone.Fields("sn_no").Value
        '    'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber - i, 8).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber - i, 8).value = "'" & rsCellphone.Fields("contract_date").Value
        '    'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber - i, 10).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber - i, 10).value = "'R" & rsCellphone.Fields("phone_price").Value
        '    'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber - i, 11).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber - i, 11).value = "'" & rsCellphone.Fields("sel_tel").Value
        '    rsCellphone.MoveNext()
        '    'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    i = i - 1
        'Loop
        'End If

        'rownumber = rownumber + 1
    End Sub
    'Display the items that were specified on a vehicle for cover
    Public Sub displayVehicleSpecifiedItems()
        ''UPGRADE_WARNING: Arrays in structure rsSpecified may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        'Dim rsSpecified As DAO.Recordset
        'Dim sqlField As String

        'sSql = "SELECT voertuieEkstras.*,beskrywingAfrikaans, beskrywingEngels"
        'sSql = sSql & " FROM voertuieEkstras LEFT JOIN VoertuieStandaard on VoertuieStandaard.pkVoertuieStandaard = voertuieEkstras.fkVoertuieEkstraTipe"
        'sSql = sSql & " WHERE deleted = 0 AND fkVoertuie = " & rsVehicles.Fields("pkVoertuie").Value
        'rsSpecified = dbPoldata.OpenRecordset(sSql)

        ''Specified additional items for cover
        'If language = 0 Then
        '	sqlField = "beskrywingAfrikaans"

        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 1).value = "Spesifiseer items vir dekking bv. allooiwiele"
        '	rownumber = rownumber + 1
        '	'Heading
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 1).value = "Tipe (bv. radio)"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 5).value = "Maak"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 6).value = "Model/beskrywing"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 9).value = "Serienommer"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 11).value = "Waarde"
        '	xlsheet.Range("A" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Rows._Default(rownumber).Font.Bold = True
        'Else
        '	sqlField = "beskrywingEngels"

        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 1).value = "Specify items for cover e.g. alloy rims"
        '	rownumber = rownumber + 1
        '	'Heading
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 1).value = "Type (ex. radio)"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 5).value = "Make"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 6).value = "Model/description"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 9).value = "Serial number"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 11).value = "Value"
        '	xlsheet.Range("A" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Rows._Default(rownumber).Font.Bold = True
        'End If

        'rownumber = rownumber + 1

        ''Populate with existing data
        'If Not (rsSpecified.EOF And rsSpecified.BOF) Then
        '	Do While Not rsSpecified.EOF
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 1).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 1).value = rsSpecified.Fields(sqlField).Value
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 5).value = rsSpecified.Fields("fabrikaat").Value & ""
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 6).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 6).value = rsSpecified.Fields("model").Value & ""
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 9).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 9).value = rsSpecified.Fields("serienommer").Value & ""
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 11).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 11).value = "'R " & rsSpecified.Fields("waarde").Value

        '		'Borders and lines
        '		xlsheet.Range("A" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '		xlsheet.Range("A" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '		xlsheet.Range("A" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '		xlsheet.Range("A" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '		xlsheet.Range("E" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '		xlsheet.Range("E" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '		xlsheet.Range("F" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '		xlsheet.Range("F" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '		xlsheet.Range("I" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '		xlsheet.Range("I" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '		xlsheet.Range("K" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '		xlsheet.Range("K" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline

        '		rownumber = rownumber + 1

        '		rsSpecified.MoveNext()
        '	Loop 
        'End If

        ''Add one extra line
        'xlsheet.Range("A" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        'xlsheet.Range("A" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        'xlsheet.Range("A" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        'xlsheet.Range("A" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        'xlsheet.Range("E" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        'xlsheet.Range("E" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        'xlsheet.Range("F" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        'xlsheet.Range("F" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        'xlsheet.Range("I" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        'xlsheet.Range("I" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        'xlsheet.Range("K" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        'xlsheet.Range("K" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline

        'rownumber = rownumber + 1
    End Sub

    'Display the items that were specified on a house for cover
    Public Sub displayHouseSpecifiedItems()
        'UPGRADE_WARNING: Arrays in structure rsSpecified may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        'Dim rsSpecified As DAO.Recordset
        'Dim sqlField As String

        'sSql = "SELECT Geysers.*, Afr, Eng"
        'sSql = sSql & " FROM Geysers LEFT JOIN Geysertipe on Geysertipe.pkGeysertipe = Geysers.fkGeysertipe"
        'sSql = sSql & " WHERE geysers.cancelled = 0 AND fkHuis = " & rsProperty.Fields("pkHuis").Value
        'rsSpecified = dbPoldata.OpenRecordset(sSql)

        ''Specified additional items for cover
        'If language = 0 Then
        '	sqlField = "Afr"

        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 1).value = "Geisers"
        '	rownumber = rownumber + 1
        '	'Heading
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 1).value = "Tipe (bv. Elektriese geiser)"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 5).value = "Maak"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 6).value = "Model/beskrywing"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 11).value = "Waarde"
        '	xlsheet.Range("A" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Rows._Default(rownumber).Font.Bold = True
        'Else
        '	sqlField = "Eng"

        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 1).value = "Geysers"
        '	rownumber = rownumber + 1
        '	'Heading
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 1).value = "Type (ex. Electrical geyser)"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 5).value = "Make"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 6).value = "Model/description"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 11).value = "Value"
        '	xlsheet.Range("A" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Rows._Default(rownumber).Font.Bold = True
        'End If

        'rownumber = rownumber + 1

        ''Populate with existing data
        'If Not (rsSpecified.EOF And rsSpecified.BOF) Then
        '	Do While Not rsSpecified.EOF
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 1).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 1).value = rsSpecified.Fields(sqlField).Value
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 5).value = rsSpecified.Fields("fabrikaat").Value & ""
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 6).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 6).value = rsSpecified.Fields("model").Value & ""
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 11).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 11).value = "'R " & rsSpecified.Fields("waarde").Value

        '		'Borders and lines
        '		xlsheet.Range("A" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '		xlsheet.Range("A" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '		xlsheet.Range("A" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '		xlsheet.Range("A" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '		xlsheet.Range("E" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '		xlsheet.Range("E" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '		xlsheet.Range("F" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '		xlsheet.Range("F" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '		xlsheet.Range("I" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '		xlsheet.Range("I" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '		xlsheet.Range("K" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '		xlsheet.Range("K" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline

        '		rownumber = rownumber + 1

        '		rsSpecified.MoveNext()
        '	Loop 
        'End If

        ''Add one extra line
        'xlsheet.Range("A" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        'xlsheet.Range("A" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        'xlsheet.Range("A" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        'xlsheet.Range("A" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        'xlsheet.Range("E" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        'xlsheet.Range("E" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        'xlsheet.Range("F" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        'xlsheet.Range("F" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        'xlsheet.Range("I" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        'xlsheet.Range("I" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        'xlsheet.Range("K" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        'xlsheet.Range("K" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline

        'rownumber = rownumber + 1
    End Sub
    Public Sub getLetterVariables()
        'rs = dbPoldata.OpenRecordset("SELECT * FROM reporting WHERE tablename = 'Letter'")
        'If Not (rs.EOF And rs.BOF) Then
        '	Do While Not rs.EOF
        '		Select Case rs.Fields("fieldname").Value
        '			Case "Introduction"
        '				If rs.Fields("language").Value = 0 Then
        '					letterIntroAfr = Replace(rs.Fields("Display").Value & "", "|", Chr(10))
        '				Else
        '					letterIntroEng = Replace(rs.Fields("Display").Value & "", "|", Chr(10))
        '				End If
        '			Case "Subject"
        '				If rs.Fields("language").Value = 0 Then
        '					letterSubjectAfr = rs.Fields("Display").Value & ""
        '				Else
        '					letterSubjectEng = rs.Fields("Display").Value & ""
        '				End If
        '		End Select
        '		rs.MoveNext()
        '	Loop 
        'Else
        '	letterIntroAfr = "ERROR - NO LETTER INTRODUCTION"
        '	letterSubjectAfr = "ERROR - NO LETTER SUBJECT"
        '	letterIntroEng = "ERROR - NO LETTER INTRODUCTION"
        '	letterSubjectEng = "ERROR - NO LETTER SUBJECT"
        'End If

        ''Get checked and unchecked characters from letter template
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'chrChecked = xlsheet.Cells._Default(2, "A").value
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'chrUnChecked = xlsheet.Cells._Default(3, "A").value
    End Sub
    Public Function getWaardeTipe(ByRef waardeTipeIndex As String) As String
        If language = 0 Then
            Select Case waardeTipeIndex
                Case "0"
                    getWaardeTipe = "Markwaarde"
                Case "1"
                    getWaardeTipe = "Verkoopwaarde"
                Case "2"
                    getWaardeTipe = "Ooreengekomewaarde"
                Case "3"
                    getWaardeTipe = "Persentasie van waarde"
                Case Else
                    getWaardeTipe = ""
            End Select
        Else
            Select Case waardeTipeIndex
                Case "0"
                    getWaardeTipe = "Market value"
                Case "1"
                    getWaardeTipe = "Resell value"
                Case "2"
                    getWaardeTipe = "Value agreed upon"
                Case "3"
                    getWaardeTipe = "Percentage of value"
                Case Else
                    getWaardeTipe = ""
            End Select
        End If
    End Function
    'Display the list of AR
    Public Sub displayARInfo()
        'Dim rsAr As Object
        'sSql = "SELECT dekking, serienommer, beskryf, beskrywing, selnommer, seldatumaangekoop, selkontrakmet, tipe2 FROM allerisk"
        'sSql = sSql & " WHERE polisno = '" & rsPersoonl.Fields("polisno").Value & "' AND cancelled = false"
        'rsAr = dbPoldata.OpenRecordset(sSql)

        ''Set heading style
        'setSectionHeadingStyle()

        'If language = 0 Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 1).value = "4. Alle risiko"

        '	rownumber = rownumber + 1
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().RowHeight. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Rows._Default(rownumber).RowHeight = 10.25
        '	rownumber = rownumber + 1

        '	'Heading
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 1).value = "Kategorie"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 5).value = "Beskrywing"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 10).value = "Serienommer"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 12).value = "Waarde"
        '	xlsheet.Range("A" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Rows._Default(rownumber).Font.Bold = True
        'Else
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 1).value = "4. All risks"

        '	rownumber = rownumber + 1
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().RowHeight. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Rows._Default(rownumber).RowHeight = 10.25
        '	rownumber = rownumber + 1

        '	'Heading
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 1).value = "Category"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 5).value = "Description"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 10).value = "Serial number"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 12).value = "Value"
        '	xlsheet.Range("A" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Rows().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Rows._Default(rownumber).Font.Bold = True
        'End If
        'rownumber = rownumber + 1

        'Populate grid with existing data
        'UPGRADE_WARNING: Couldn't resolve default property of object rsAr.BOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object rsAr.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If Not (rsAr.EOF And rsAr.BOF) Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object rsAr.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	Do While Not rsAr.EOF
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 1).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object rsAr(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 1).value = gen_getAllRiskTypeDesc(language, CShort(rsAr("tipe2")))
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object rsAr(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 5).value = rsAr("beskryf")
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 10).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object rsAr(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 10).value = "'" & rsAr("serienommer")
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 12).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object rsAr(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 12).value = "'R " & rsAr("dekking")

        '		'Borders and lines
        '		xlsheet.Range("A" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '		xlsheet.Range("A" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '		xlsheet.Range("A" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '		xlsheet.Range("A" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '		xlsheet.Range("E" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '		xlsheet.Range("E" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '		xlsheet.Range("J" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '		xlsheet.Range("J" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '		xlsheet.Range("L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '		xlsheet.Range("L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '		rownumber = rownumber + 1

        '		'UPGRADE_WARNING: Couldn't resolve default property of object rsAr.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		rsAr.MoveNext()
        '	Loop 
        'End If

        ''Borders and lines
        'xlsheet.Range("A" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        'xlsheet.Range("A" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        'xlsheet.Range("A" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        'xlsheet.Range("A" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        'xlsheet.Range("E" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        'xlsheet.Range("E" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        'xlsheet.Range("J" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        'xlsheet.Range("J" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        'xlsheet.Range("L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        'xlsheet.Range("L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline

        'rownumber = rownumber + 2
    End Sub
    'List possible roof types with current selected one
    Public Sub listTipeDak(ByRef tipeDak As String)
        'If language = 0 Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 5).value = chrUnChecked & " Teël staandak"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 7).value = chrUnChecked & " Sink staandak"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 9).value = chrUnChecked & " Sink platdak"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 11).value = chrUnChecked & " Asbes staandak"

        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 1, 5).value = chrUnChecked & " Asbes platdak"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 1, 7).value = chrUnChecked & " Gras staandak"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 1, 9).value = chrUnChecked & " Ander staandak"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 1, 11).value = chrUnChecked & " Ander platdak"
        'Else
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 5).value = chrUnChecked & " Pitched tiled "
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 7).value = chrUnChecked & " Pitched corrugated iron "
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 9).value = chrUnChecked & " Corrugated iron flat "
        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber, 11).value = chrUnChecked & " Pitch asbestos "

        '	'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	xlsheet.Cells._Default(rownumber + 1, 5).value = chrUnChecked & " Asbestos flat "
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Cells._Default(rownumber + 1, 7).value = chrUnChecked & " Pitched thatched "
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Cells._Default(rownumber + 1, 9).value = chrUnChecked & " Other pitched "
        '      'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      xlsheet.Cells._Default(rownumber + 1, 11).value = chrUnChecked & " Other flat "
        'End If

        '      'Check the currently selected item
        '      Select Case Val(tipeDak) - 1
        '          Case CDbl("0")
        '              'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '              'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '              xlsheet.Cells._Default(rownumber, 5).value = Replace(xlsheet.Cells._Default(rownumber, 5).value, chrUnChecked, chrChecked, 1, 1)
        '          Case CDbl("1")
        '              'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 7).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '              'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '              xlsheet.Cells._Default(rownumber, 7).value = Replace(xlsheet.Cells._Default(rownumber, 7).value, chrUnChecked, chrChecked, 1, 1)
        '          Case CDbl("2")
        '              'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 9).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '              'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '              xlsheet.Cells._Default(rownumber, 9).value = Replace(xlsheet.Cells._Default(rownumber, 9).value, chrUnChecked, chrChecked, 1, 1)
        '          Case CDbl("3")
        '              'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 11).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '              'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '              xlsheet.Cells._Default(rownumber, 11).value = Replace(xlsheet.Cells._Default(rownumber, 11).value, chrUnChecked, chrChecked, 1, 1)
        '          Case CDbl("4")
        '              'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 1, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '              'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '              xlsheet.Cells._Default(rownumber + 1, 5).value = Replace(xlsheet.Cells._Default(rownumber + 1, 5).value, chrUnChecked, chrChecked, 1, 1)
        '          Case CDbl("5")
        '              'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 1, 7).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '              'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '              xlsheet.Cells._Default(rownumber + 1, 7).value = Replace(xlsheet.Cells._Default(rownumber + 1, 7).value, chrUnChecked, chrChecked, 1, 1)
        '          Case CDbl("6")
        '              'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 1, 9).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '              'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '              xlsheet.Cells._Default(rownumber + 1, 9).value = Replace(xlsheet.Cells._Default(rownumber + 1, 9).value, chrUnChecked, chrChecked, 1, 1)
        '          Case CDbl("7")
        '              'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 1, 11).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '              'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '              xlsheet.Cells._Default(rownumber + 1, 11).value = Replace(xlsheet.Cells._Default(rownumber + 1, 11).value, chrUnChecked, chrChecked, 1, 1)
        '      End Select

        '      rownumber = rownumber + 1
    End Sub
    'List possible structure types
    'UPGRADE_NOTE: structure was upgraded to structure_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Public Sub listStruktuur(ByRef structure_Renamed As String)
        '	If language = 0 Then
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 5).value = chrUnChecked & " Standaard"
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 7).value = chrUnChecked & " Hout"
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 8).value = chrUnChecked & " Nie standaard"
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 10).value = chrUnChecked & " Strandhuis"
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 12).value = chrUnChecked & " Asbes"
        '	Else
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 5).value = chrUnChecked & " Standard"
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 7).value = chrUnChecked & " Wood"
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 8).value = chrUnChecked & " Not standard"
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 10).value = chrUnChecked & " Beach house"
        '		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		xlsheet.Cells._Default(rownumber, 12).value = chrUnChecked & " Abestos"
        '	End If

        '	'Check the currently selected item
        '	Select Case Val(structure_Renamed) - 1
        '		Case CDbl("0")
        '			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			xlsheet.Cells._Default(rownumber, 5).value = Replace(xlsheet.Cells._Default(rownumber, 5).value, chrUnChecked, chrChecked, 1, 1)
        '		Case CDbl("1")
        '			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 7).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			xlsheet.Cells._Default(rownumber, 7).value = Replace(xlsheet.Cells._Default(rownumber, 7).value, chrUnChecked, chrChecked, 1, 1)
        '		Case CDbl("2")
        '			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 8).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			xlsheet.Cells._Default(rownumber, 8).value = Replace(xlsheet.Cells._Default(rownumber, 8).value, chrUnChecked, chrChecked, 1, 1)
        '		Case CDbl("3")
        '			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 10).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			xlsheet.Cells._Default(rownumber, 10).value = Replace(xlsheet.Cells._Default(rownumber, 10).value, chrUnChecked, chrChecked, 1, 1)
        '		Case CDbl("4")
        '			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 12).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			xlsheet.Cells._Default(rownumber, 12).value = Replace(xlsheet.Cells._Default(rownumber, 12).value, chrUnChecked, chrChecked, 1, 1)
        '	End Select
    End Sub
    ''List possible security types
    Public Sub listSekuriteit(ByRef sekuriteitBitValue As Integer)
        '	Dim k As Object
        '	Dim fieldname As String

        '	If language = 0 Then
        '		fieldname = "beskrywingAfrikaans"
        '	Else
        '		fieldname = "beskrywingEngels"
        '	End If

        '	rs2 = dbPoldata.OpenRecordset("SELECT * FROM sekuriteit WHERE tipe = 'Eiendom' AND beskrywingAfrikaans <> 'n.v.t.'")
        '	'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	k = 1

        '	Do While Not rs2.EOF
        '		'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		If k = 5 Then 'Move to next line
        '			rownumber = rownumber + 1
        '			'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			k = 1
        '		End If

        '		If sekuriteitBitValue And rs2.Fields("bitvalue").Value Then
        '			'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, k * 2 + 3).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			xlsheet.Cells._Default(rownumber, (k * 2) + 3).value = chrChecked & " " & rs2.Fields(fieldname).Value
        '		Else
        '			'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, k * 2 + 3).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			xlsheet.Cells._Default(rownumber, (k * 2) + 3).value = chrUnChecked & " " & rs2.Fields(fieldname).Value
        '		End If
        '		xlsheet.Range("E" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        '		xlsheet.Range("E" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        '		'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		k = k + 1
        '		rs2.MoveNext()
        '	Loop 
    End Sub
    'List possible types of property
    Public Sub listPropertyType(ByRef fkPropertyType As Integer)
        'Dim k As Object
        'rs2 = dbPoldata.OpenRecordset("SELECT * FROM propertyType ORDER BY pkPropertyType")

        'If Not (rs2.EOF And rs2.BOF) Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    k = 1
        '    If language = 0 Then
        '        Do While Not rs2.EOF
        '            'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            If k = 4 Then 'Move to next line after 3 (4-1) entries
        '                rownumber = rownumber + 1
        '                'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                k = 1
        '            End If

        '            If fkPropertyType = rs2.Fields("pkPropertyType").Value Then
        '                'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, k * 3 + 2).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                xlsheet.Cells._Default(rownumber, (k * 3) + 2).value = chrChecked & " " & rs2.Fields("shortDescAfr").Value
        '            Else
        '                'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, k * 3 + 2).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                xlsheet.Cells._Default(rownumber, (k * 3) + 2).value = chrUnChecked & " " & rs2.Fields("shortDescAfr").Value
        '            End If
        '            'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            k = k + 1
        '            rs2.MoveNext()
        '        Loop
        '    Else
        '        Do While Not rs2.EOF
        '            'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            If k = 4 Then 'Move to next line after 3 (4-1) entries
        '                rownumber = rownumber + 1
        '                'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                k = 1
        '            End If

        '            If fkPropertyType = rs2.Fields("pkPropertyType").Value Then
        '                'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, k * 3 + 2).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                xlsheet.Cells._Default(rownumber, (k * 3) + 2).value = chrChecked & " " & rs2.Fields("shortDescEng").Value
        '            Else
        ''UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, k * 3 + 2).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, (k * 3) + 2).value = chrUnChecked & " " & rs2.Fields("shortDescEng").Value
        '            End If

        ''UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'k = k + 1
        'rs2.MoveNext()
        '        Loop
        '    End If
        'End If
    End Sub
    'List possible vehicle types
    Public Sub listVehicleTypes(ByRef Tipe As String)
        'If language = 0 Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 5).value = chrUnChecked & " Motor"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 7).value = chrUnChecked & " Bakkie"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 9).value = chrUnChecked & " Kombi"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 11).value = chrUnChecked & " Sleepwa"

        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 1, 5).value = chrUnChecked & " Woonwa"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 1, 7).value = chrUnChecked & " Motorfiets"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 1, 9).value = chrUnChecked & " Ander:"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 1, 11).value = chrUnChecked & " Motorboot"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 2, 5).value = chrUnChecked & " Vierwielmotorfiets"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 2, 7).value = chrUnChecked & " Gholf kar"
        'Else
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 5).value = chrUnChecked & " Motor"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 7).value = chrUnChecked & " Pick Up"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 9).value = chrUnChecked & " Microbus"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 11).value = chrUnChecked & " Trailer"

        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 1, 5).value = chrUnChecked & " Caravan"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 1, 7).value = chrUnChecked & " Motorcycle"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 1, 9).value = chrUnChecked & " Other:"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 1, 11).value = chrUnChecked & " Motorboat"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 2, 5).value = chrUnChecked & " Quadbike"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber + 2, 7).value = chrUnChecked & " Golf car"
        'End If

        ''Check the currently selected item
        'Select Case Val(Tipe) - 1
        '    Case CDbl("0")
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber, 5).value = Replace(xlsheet.Cells._Default(rownumber, 5).value, chrUnChecked, chrChecked, 1, 1)
        '    Case CDbl("1")
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 7).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber, 7).value = Replace(xlsheet.Cells._Default(rownumber, 7).value, chrUnChecked, chrChecked, 1, 1)
        '    Case CDbl("2")
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 9).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 9).value = Replace(xlsheet.Cells._Default(rownumber, 9).value, chrUnChecked, chrChecked, 1, 1)
        '    Case CDbl("3")
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 11).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 11).value = Replace(xlsheet.Cells._Default(rownumber, 11).value, chrUnChecked, chrChecked, 1, 1)
        '    Case CDbl("4")
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 1, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 1, 5).value = Replace(xlsheet.Cells._Default(rownumber + 1, 5).value, chrUnChecked, chrChecked, 1, 1)
        '    Case CDbl("5")
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 1, 7).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 1, 7).value = Replace(xlsheet.Cells._Default(rownumber + 1, 7).value, chrUnChecked, chrChecked, 1, 1)
        '    Case CDbl("6")
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 1, 9).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 1, 9).value = Replace(xlsheet.Cells._Default(rownumber + 1, 9).value, chrUnChecked, chrChecked, 1, 1)
        '    Case CDbl("7")
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 1, 11).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 1, 11).value = Replace(xlsheet.Cells._Default(rownumber + 1, 11).value, chrUnChecked, chrChecked, 1, 1)
        '    Case CDbl("8")
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 2, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 2, 5).value = Replace(xlsheet.Cells._Default(rownumber + 2, 5).value, chrUnChecked, chrChecked, 1, 1)
        '    Case CDbl("9")
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber + 2, 7).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber + 2, 7).value = Replace(xlsheet.Cells._Default(rownumber + 2, 7).value, chrUnChecked, chrChecked, 1, 1)
        'End Select

        'rownumber = rownumber + 2
    End Sub
    'List possible vehicle cover
    Public Sub listVehicleCover(ByRef tipe_dek As String)
        'If language = 0 Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 5).value = chrUnChecked & " Omvattend"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 7).value = chrUnChecked & " Balans, derde party, brand en diefstal"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 11).value = chrUnChecked & " Balans en derde party"
        'Else
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 5).value = chrUnChecked & " Comprehensive"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 7).value = chrUnChecked & " Balance, third party, fire and theft"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 11).value = chrUnChecked & " Balance and third party"
        'End If

        ''Check the currently selected item
        'Select Case Val(tipe_dek) - 1
        '    Case CDbl("0")
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber, 5).value = Replace(xlsheet.Cells._Default(rownumber, 5).value, chrUnChecked, chrChecked, 1, 1)
        '    Case CDbl("1")
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 7).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber, 7).value = Replace(xlsheet.Cells._Default(rownumber, 7).value, chrUnChecked, chrChecked, 1, 1)
        '    Case CDbl("2")
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 11).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 11).value = Replace(xlsheet.Cells._Default(rownumber, 11).value, chrUnChecked, chrChecked, 1, 1)
        'End Select
    End Sub
    'List possible vehicle uses
    Public Sub listVehicleUses(ByRef gebruik As String)
        'If language = 0 Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 5).value = chrUnChecked & " Privaat"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 7).value = chrUnChecked & " Professioneel"
        'Else
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 5).value = chrUnChecked & " Private"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 7).value = chrUnChecked & " Professional"
        'End If

        ''Check the currently selected item
        'Select Case Val(gebruik) - 1
        '    Case CDbl("0")
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 5).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        xlsheet.Cells._Default(rownumber, 5).value = Replace(xlsheet.Cells._Default(rownumber, 5).value, chrUnChecked, chrChecked, 1, 1)
        '    Case CDbl("1")
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 7).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 7).value = Replace(xlsheet.Cells._Default(rownumber, 7).value, chrUnChecked, chrChecked, 1, 1)
        '    Case CDbl("2")
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 9).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 9).value = Replace(xlsheet.Cells._Default(rownumber, 7).value, chrUnChecked, chrChecked, 1, 1)
        'End Select
    End Sub
    'List possible vehicle security
    Public Sub listVehicleSecurity(ByRef sekuriteitBitValue As String)
        'Dim k As Object
        'Dim rsSecurity As Object
        'Dim fieldname As String

        'If language = 0 Then
        '    fieldname = "beskrywingAfrikaans"
        'Else
        '    fieldname = "beskrywingEngels"
        'End If

        'rsSecurity = dbPoldata.OpenRecordset("SELECT * FROM sekuriteit WHERE tipe = 'Voertuig' AND beskrywingAfrikaans <> 'n.v.t.'")
        ''UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'k = 1

        ''UPGRADE_WARNING: Couldn't resolve default property of object rsSecurity.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Do While Not rsSecurity.EOF
        '    'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    If k = 5 Then 'Move to next line
        '        rownumber = rownumber + 1
        'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'k = 1
        '    End If

        'If sekuriteitBitValue And rsSecurity("bitvalue") Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, k * 2 + 3).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object rsSecurity(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, (k * 2) + 3).value = chrChecked & " " & rsSecurity(fieldname)
        'Else
        '    'UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, k * 2 + 3).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object rsSecurity(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, (k * 2) + 3).value = chrUnChecked & " " & rsSecurity(fieldname)
        'End If
        'xlsheet.Range("E" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous
        'xlsheet.Range("E" & rownumber, "L" & rownumber).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlHairline
        ''UPGRADE_WARNING: Couldn't resolve default property of object k. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'k = k + 1
        ''UPGRADE_WARNING: Couldn't resolve default property of object rsSecurity.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'rsSecurity.MoveNext()
        'Loop
    End Sub
    'Set the heading style at the current rownumber
    Public Sub setSectionHeadingStyle()
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 1).Font.Bold = True
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 1).Font.Size = 10
    End Sub
    Public Sub listGrasdakgrootte()
        'If language = 0 Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 5).value = "Huis:"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 8).value = "Lapa:"
        'Else
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 5).value = "House:"
        '    'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    xlsheet.Cells._Default(rownumber, 8).value = "Lapa:"
        'End If

        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 7).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 7).value = rsProperty.Fields("oppervlaktehuis").Value & " m" & Chr(178)
        ''UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(rownumber, 10).value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlsheet.Cells._Default(rownumber, 10).value = rsProperty.Fields("oppervlaktelapa").Value & " m" & Chr(178)
    End Sub
    'List yes/No as possible answers for questions
    Public Sub listYesNo(Optional ByRef yesno As String = "")
        'If language = 0 Then
        '    Select Case yesno
        '        Case "1", "J", "Y", "Ja", "Yes", "2"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber, 5).value = chrChecked & " Ja    " & chrUnChecked & " Nee"
        '        Case "0", "N", "N", "Nee", "No", "3"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber, 5).value = chrUnChecked & " Ja    " & chrChecked & " Nee"
        '        Case Else
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber, 5).value = chrUnChecked & " Ja    " & chrUnChecked & " Nee"
        '    End Select
        'Else
        '    Select Case yesno
        '        Case "1", "J", "Y", "Ja", "Yes", "2"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber, 5).value = chrChecked & " Yes    " & chrUnChecked & " No"
        '        Case "0", "N", "N", "Nee", "No", "3"
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber, 5).value = chrUnChecked & " Yes    " & chrChecked & " No"
        '        Case Else
        '            'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            xlsheet.Cells._Default(rownumber, 5).value = chrUnChecked & " Yes    " & chrUnChecked & " No"
        '    End Select
        'End If
    End Sub

    Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click

        ''UPGRADE_NOTE: Object xlapp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'xlapp = Nothing
        ''UPGRADE_NOTE: Object xlbook may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'xlbook = Nothing
        ''UPGRADE_NOTE: Object xlsheet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'xlsheet = Nothing
        'Me.Close()
    End Sub

    'Private Sub cmbVersekeraar_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbVersekeraar.Leave
    'Me.lstArea.Items.Clear()

    ''UPGRADE_WARNING: Couldn't resolve default property of object Gebtitel. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    'If Gebtitel = "Programmeerder" Then
    '    sSql = "SELECT area.*, versekeraar.* FROM area, versekeraar WHERE lewendig = 'J' AND naam = '" & Me.cmbVersekeraar.Text & "' and versekeraar.pkversekeraar = area.fkversekeraar ORDER BY area_kode"
    '    rs = dbPoldata.OpenRecordset(sSql)

    '    'Add 'alle' area item
    '    lstArea.Items.Add("Alle areas")
    'Else
    '    sSql = "SELECT area.*, versekeraar.* FROM area, versekeraar WHERE lewendig = 'J' AND area_kode in " &  Gebruiker.BranchCodes & " " & "AND naam = '" & Me.cmbVersekeraar.Text & "' and versekeraar.pkversekeraar = area.fkversekeraar ORDER BY area_kode"
    '    rs = dbPoldata.OpenRecordset(sSql)
    'End If

    'Do While Not rs.EOF
    '    lstArea.Items.Add(rs.Fields("area_besk").Value)
    ''The area code sometimes will be a 'A','B' or 'C' - So you cannot use itemdata (long)
    'rs.MoveNext()
    'Loop

    'End Sub

    Private Sub BriefBesonderhede_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Dim xlApplicationCreated As Object
        'dbPoldata = DAODBEngine_definst.OpenDatabase(pol_path & "\poldata5.mdb")
        'dbInsCell = DAODBEngine_definst.OpenDatabase(pol_path & "\inscell.mdb")
        'fs = CreateObject("Scripting.FileSystemObject")

        ''UPGRADE_WARNING: Couldn't resolve default property of object Gebtitel. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If Gebtitel = "Programmeerder" Then
        '    sSql = "SELECT * FROM area WHERE lewendig = 'J' ORDER BY area_kode"

        '    'Add 'alle' area item
        '    lstArea.Items.Add("Alle areas")
        'Else
        '    sSql = "SELECT * FROM area WHERE lewendig = 'J' AND area_kode in " &  Gebruiker.BranchCodes & " ORDER BY area_kode"
        'End If
        'rs = dbPoldata.OpenRecordset(sSql)

        'Do While Not rs.EOF
        '    lstArea.Items.Add(rs.Fields("area_besk").Value)
        '    rs.MoveNext()
        'Loop

        'Me.cmbStatus.SelectedIndex = 0
        'Me.cmbPosbestemming.SelectedIndex = 0
        'Me.cmbTaal.SelectedIndex = 0

        'VersekeraarSql = "SELECT * FROM versekeraar WHERE isnull(datecancelled) ORDER BY Naam"
        'rsVersekeraar = dbPoldata.OpenRecordset(VersekeraarSql)

        'Do While Not rsVersekeraar.EOF
        '    Me.cmbVersekeraar.Items.Add(rsVersekeraar.Fields("naam").Value)
        '    rsVersekeraar.MoveNext()
        'Loop
        'Me.cmbVersekeraar.SelectedIndex = -1

        ''UPGRADE_WARNING: Couldn't resolve default property of object xlApplicationCreated. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xlApplicationCreated = False

        ''Create the formatting array for printing purposes(also for the grid)
        'ReDim Preserve formattingArray(3, 5)
        'formattingArray(0, 0) = "polisno"
        'formattingArray(1, 0) = "Polisnommer"
        'formattingArray(2, 0) = "11"
        'formattingArray(0, 1) = "versekerde"
        'formattingArray(1, 1) = "Van"
        'formattingArray(2, 1) = "23"
        'formattingArray(0, 2) = "voorl"
        'formattingArray(1, 2) = "Voorletter"
        'formattingArray(2, 2) = "8"
        'formattingArray(0, 3) = "area_besk"
        'formattingArray(1, 3) = "Area"
        'formattingArray(2, 3) = "18"
        'formattingArray(0, 4) = "gekans"
        'formattingArray(1, 4) = "Status"
        'formattingArray(2, 4) = "12"
        'formattingArray(0, 5) = "posbestemming"
        'formattingArray(1, 5) = "Posbestemming"
        'formattingArray(2, 5) = "15"


        'populating areas from database to listbox
        PopulateArea()
        'populating insurer at a combobox
        PopulateVersekeraar()

        'You should not be able to print a schedule to a client after it has been cancelled(except if you specify criteria)
        If Persoonl.GEKANS Then
            Me.rdEpos.Enabled = False
            Me.rdDrukker.Checked = True
        End If
        Me.Text = My.Application.Info.Title & " - Letters - Customer details"
    End Sub
    Sub PopulateArea()
        '  lstArea.Items.Clear()

        If ListAreaDropdown.Count > 0 Then
            lstArea.DataSource = ListAreaDropdown()
        End If
    End Sub
    Sub PopulateVersekeraar()
        'cmbVersekeraar.Items.Clear()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVersekeraar")
                Dim list As List(Of String) = New List(Of String)

                While reader.Read()
                    Dim item As VersekeraarEntity = New VersekeraarEntity()

                    If reader("naam") IsNot DBNull.Value Then
                        item.Naam = reader("naam")
                    End If

                    list.Add(item.Naam)
                End While

                If list.Count > 0 Then
                    cmbVersekeraar.DataSource = list
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            End
        End Try
        cmbVersekeraar.SelectedIndex = -1

    End Sub

    'Andriette 14/08/2014 maak warnings reg
    ''Build the sql statement according to the criteria specified
    'Public Function BuildSQL(Optional ByRef specialList As String = "") As String
    '    'Dim i As Object
    '    'Dim sSql As String
    '    'Dim sqlArea As String
    '    'Dim sqlSurname As String
    '    'Dim sqlCurrentPolicy As String
    '    'Dim sqlLanguage As String
    '    'Dim sqlStatus As String
    '    'Dim sqlSpecialList As String
    '    'Dim sqlPosbestemming As String
    '    'Dim sqlVersekeraar As String
    '    ''UPGRADE_WARNING: Arrays in structure rsVersekeraar may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    '    'Dim rsVersekeraar As DAO.Recordset

    '    ''Build sql string according to criteria specified
    '    'If Me.rdSpesifieke.Checked Then
    '    '    'UPGRADE_WARNING: Couldn't resolve default property of object Gebtitel. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '    '    If Gebtitel = "Programmeerder" Then
    '    '        If lstArea.SelectedIndex <> -1 And lstArea.SelectedIndex <> 0 Then
    '    '            For i = 0 To lstArea.Items.Count - 1
    '    '                If lstArea.GetSelected(i) Then
    '    '                    sqlArea = sqlArea & "'" & VB6.GetItemString(lstArea, i) & "',"
    '    '                End If
    '    '            Next
    '    '            sqlArea = " AND area_besk in (" & VB.Left(sqlArea, Len(sqlArea) - 1) & ")"
    '    '        End If
    '    '    Else
    '    '        For i = 0 To lstArea.Items.Count - 1
    '    '            If lstArea.GetSelected(i) Then
    '    '                sqlArea = sqlArea & "'" & VB6.GetItemString(lstArea, i) & "',"
    '    '            End If
    '    '        Next
    '    '        sqlArea = " AND area_besk in (" & VB.Left(sqlArea, Len(sqlArea) - 1) & ")"
    '    '    End If

    '    '    'Surname
    '    '    If Me.txtVanaf.Text <> "" And Me.txtTot.Text <> "" Then
    '    '        sqlSurname = " AND (trim(versekerde) >= '" & Replace(Trim(Me.txtVanaf.Text), "'", "''") & "' AND trim(versekerde) <= '" & Replace(Trim(Me.txtTot.Text), "'", "''") & "zzzz')"
    '    '    End If
    '    'Else
    '    '    sqlArea = ""
    '    '    sqlSurname = ""
    '    'End If

    '    'If Me.rdHuidig.Checked Then
    '    '    sqlCurrentPolicy = " AND polisno = '" & Persoonl.Fields("polisno").Value & "'"
    '    'Else
    '    '    sqlCurrentPolicy = ""
    '    'End If

    '    ''Sql for language
    '    'If Me.rdSpesifieke.Checked Then
    '    '    Select Case Me.cmbTaal.SelectedIndex
    '    '        Case 0
    '    '            sqlLanguage = ""
    '    '        Case 1 'Afr
    '    '            sqlLanguage = " AND taal = '0'"
    '    '        Case 2 'Eng
    '    '            sqlLanguage = " AND taal = '1'"
    '    '    End Select
    '    'Else
    '    '    sqlLanguage = ""
    '    'End If

    '    ''Sql for status
    '    'Select Case Me.cmbStatus.SelectedIndex
    '    '    Case 0
    '    '        sqlStatus = ""
    '    '    Case 1
    '    '        sqlStatus = " AND not gekans"
    '    '    Case 2
    '    '        sqlStatus = " AND gekans"
    '    'End Select

    '    ''Sql for posbestemming
    '    'If Me.cmbPosbestemming.SelectedIndex <> 0 Then '0 - alle
    '    '    sqlPosbestemming = " AND posbestemming = '" & Me.cmbPosbestemming.SelectedIndex - 1 & "'"
    '    'End If

    '    ''Sql for versekeraar
    '    'If Me.cmbVersekeraar.SelectedIndex <> -1 Then
    '    '    sqlVersekeraar = "SELECT * FROM versekeraar WHERE naam = '" & Me.cmbVersekeraar.Text & "'"
    '    '    rsVersekeraar = dbPoldata.OpenRecordset(sqlVersekeraar)

    '    '    sqlVersekeraar = " AND fkversekeraar = " & rsVersekeraar.Fields("pkversekeraar").Value
    '    'End If

    '    ''Sql for the special items selected from the list to be printed
    '    'If specialList <> "" Then 'Items selected
    '    '    sqlSpecialList = " AND persoonl.polisno in (" & specialList & ")"
    '    'Else
    '    '    sqlSpecialList = ""
    '    'End If

    '    ''Build sql according to criteria specified
    '    'sSql = "SELECT persoonl.*, afrikaansetitel, engelsetitel,area_besk, area.fkversekeraar"
    '    'sSql = sSql & " FROM (persoonl LEFT JOIN titel On titel.titelindeks = persoonl.titelnum)"
    '    'sSql = sSql & " LEFT JOIN area ON area.area_kode = persoonl.area"
    '    'sSql = sSql & " WHERE 1=1 "
    '    'sSql = sSql & sqlStatus
    '    'sSql = sSql & sqlArea
    '    'sSql = sSql & sqlCurrentPolicy
    '    'sSql = sSql & sqlSurname
    '    'sSql = sSql & sqlLanguage
    '    'sSql = sSql & sqlPosbestemming
    '    'sSql = sSql & sqlSpecialList
    '    'sSql = sSql & sqlVersekeraar
    '    'sSql = sSql & " ORDER BY versekerde,voorl"

    '    'BuildSQL = sSql
    'End Function

    'UPGRADE_WARNING: Event rdHuidig.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub rdHuidig_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rdHuidig.CheckedChanged

        If eventSender.Checked Then
            If rdHuidig.Checked Then
                Me.lstArea.Enabled = False
                Me.txtVanaf.Enabled = False
                Me.txtTot.Enabled = False
                Me.lblTaal.Enabled = False
                Me.cmbTaal.Enabled = False

                Me.Label1.Enabled = False
                Me.Label2.Enabled = False
                Me.Label3.Enabled = False
                Me.Label5.Enabled = False
                Me.cmbStatus.Enabled = False
                Me.frmKriteria.Enabled = False
                Me.lblPosbestemming.Enabled = False
                Me.cmbPosbestemming.Enabled = False
                Me.cmbVersekeraar.Enabled = False
                Me.lblVersekeraar.Enabled = False
                Me.cmbVersekeraar.SelectedIndex = -1

                'You should not be able to print a schedule to a client after it has been cancelled(except if you specify criteria)

            End If
        End If
    End Sub

    'UPGRADE_WARNING: Event rdSpesifieke.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub rdSpesifieke_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rdSpesifieke.CheckedChanged

        If eventSender.Checked Then
            Dim i As Object
            If rdSpesifieke.Checked Then
                Me.lstArea.Enabled = True
                Me.txtVanaf.Enabled = True
                Me.txtTot.Enabled = True
                Me.lblTaal.Enabled = True
                Me.cmbTaal.Enabled = True

                Me.Label1.Enabled = True
                Me.Label2.Enabled = True
                Me.Label3.Enabled = True
                Me.Label5.Enabled = True
                Me.cmbStatus.Enabled = True
                Me.frmKriteria.Enabled = True

                'Clear selection
                For i = 0 To lstArea.Items.Count - 1
                    Me.lstArea.SetSelected(i, False)
                Next i

                Me.lstArea.SelectedIndex = 0
                Me.lstArea.SetSelected(0, True)
                Me.txtTot.Text = ""
                Me.txtVanaf.Text = ""
                Me.cmbStatus.SelectedIndex = 1
                Me.cmbTaal.SelectedIndex = 0
                Me.lblPosbestemming.Enabled = True
                Me.cmbPosbestemming.Enabled = True
                Me.cmbPosbestemming.SelectedIndex = 0
                Me.lblVersekeraar.Enabled = True
                Me.cmbVersekeraar.Enabled = True
                Me.cmbVersekeraar.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub cmbVersekeraar_leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbVersekeraar.Leave
        Me.lstArea.DataBindings.Clear()
        lstArea.DataSource = FetchAreaBeskr(Me.cmbVersekeraar.Text)

        '    Dim params() As SqlParameter = {New SqlParameter("@Area", SqlDbType.NVarChar), _
        '                                    New SqlParameter("@Versekeraar", SqlDbType.NVarChar)}

        '    If Gebruiker.titel = "Programmeerder" Then
        '        params(0).Value = ""
        '    Else
        '        params(0).Value = Gebruiker.BranchCodes
        '    End If

        '    params(1).Value = Me.cmbVersekeraar.Text

        '    Try
        '        Using conn As SqlConnection = SqlHelper.GetConnection

        '            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAreaFiltered", params)
        '            Dim list As List(Of String) = New List(Of String)

        '            While reader.Read()
        '                Dim item As AreaEntity = New AreaEntity()
        '                If list.Count = 0 Then
        '                    item.Area_Besk = "Alle areas"
        '                    list.Add(item.Area_Besk)
        '                End If

        '                If reader("Area_Besk") IsNot DBNull.Value Then
        '                    item.Area_Besk = reader("Area_Besk")
        '                End If

        '                If list.Count = 0 Then
        '                    item.Area_Besk = "Alle areas"
        '                End If
        '                list.Add(item.Area_Besk)
        '            End While

        '            lstArea.DataSource = list

        '        End Using
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical)
        '    End Try
    End Sub
End Class