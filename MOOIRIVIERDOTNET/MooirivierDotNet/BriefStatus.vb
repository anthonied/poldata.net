Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Data.SqlClient
Imports DAL

Friend Class BriefStatus
    Inherits BaseForm

    'Description  : Display a list of policies that will be printed/emailed Return values in public variables
    Public listToPrint As String
    Public returnValue As Boolean
    'Dim rsList As DAO.Recordset
    Dim arrFormatting() As String
    Dim strAreaBranch As String
    Public getPosbestemming As String
    Public getStatus As String
    Public briefLanguage As String
    Dim tempFilename As String




    Private Sub btnBack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnBack.Click
        Me.returnValue = False
        Me.listToPrint = ""
        Me.Hide()
    End Sub

    Private Sub btnDrukLys_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnDrukLys.Click
        'BriefSkedule.rdSpesifieke.Checked = True
        'BriefGeneries.rdSpesifieke.Checked = True
        'BriefBesonderhede.rdSpesifieke.Checked = True

        'Select Case txtFormToPopulate.Text

        '    Case "BriefBesonderhede"
        '        BriefBesonderhede.rdSpesifieke.Checked = True
        '        If BriefBesonderhede.rdSpesifieke.Checked Then
        '            Select Case BriefBesonderhede.cmbTaal.SelectedIndex
        '                Case 0
        '                    briefLanguage = 0
        '                Case 1 'Afr
        '                    briefLanguage = 0
        '                Case 2 'Eng
        '                    briefLanguage = 1
        '            End Select
        '        Else
        '            briefLanguage = ""
        '        End If

        '    Case "BriefGeneries"
        '        BriefGeneries.rdSpesifieke.Checked = True
        '        If BriefGeneries.rdSpesifieke.Checked Then
        '            Select Case BriefGeneries.cmbTaal.SelectedIndex
        '                Case 0
        '                    briefLanguage = 0
        '                Case 1 'Afr
        '                    briefLanguage = 0
        '                Case 2 'Eng
        '                    briefLanguage = 1
        '            End Select
        '        Else
        '            briefLanguage = ""
        '        End If

        '    Case "BriefSkedule"
        '        BriefSkedule.rdSpesifieke.Checked = True
        '        If BriefSkedule.rdSpesifieke.Checked Then
        '            Select Case BriefSkedule.cmbTaal.SelectedIndex
        '                Case 0
        '                    briefLanguage = 0
        '                Case 1 'Afr
        '                    briefLanguage = 0
        '                Case 2 'Eng
        '                    briefLanguage = 1
        '            End Select
        '        Else
        '            briefLanguage = ""
        '        End If

        'End Select

        BriefStatusReportViewer.ShowDialog()


        ' BriefBesonderhede1ReportViewer.ShowDialog()

        'Dim i As Object
        'Dim rptSubheading As String
        'Dim sAreas As String
        'Dim sTaal As String

        ''Get a list of all the areas selected
        'If BriefSkedule.lstArea.SelectedIndex <> -1 And BriefSkedule.lstArea.SelectedIndex <> 0 Then
        '    For i = 0 To BriefSkedule.lstArea.Items.Count - 1
        '        If BriefSkedule.lstArea.GetSelected(i) Then
        '            ' sAreas = sAreas & VB6.GetItemString(BriefSkedule.lstArea, i) & ","
        '        End If
        '    Next
        '    sAreas = VB.Left(sAreas, Len(sAreas) - 1) 'Remove last comma
        'Else
        '    sAreas = "Alle areas"
        'End If
        'rptSubheading = "(Area:" & sAreas & "; "

        ''Surnames
        'If Not (Trim(BriefSkedule.txtVanaf.Text) = "" And Trim(BriefSkedule.txtTot.Text) = "") Then
        '    rptSubheading = rptSubheading & "Vanne:" & BriefSkedule.txtVanaf.Text & " tot " & BriefSkedule.txtTot.Text & "; "
        'End If

        ''Taal
        'rptSubheading = rptSubheading & "Taal:" & BriefSkedule.cmbTaal.Text & "; "

        ''Status
        'rptSubheading = rptSubheading & "Status:" & BriefSkedule.cmbStatus.Text & "; "

        ''Posbestemming
        'rptSubheading = rptSubheading & "Posbestemming:" & BriefSkedule.cmbPosbestemming.Text & "; "

        ''Gewysig op
        'If Not IsDBNull(BriefSkedule.dtpGewysig._Value) Then
        '    rptSubheading = rptSubheading & "Gewysig op:" & BriefSkedule.dtpGewysig.Value & "; "
        'End If

        ''Gebruik
        'If BriefSkedule.rdKantoor.Checked Then
        '    rptSubheading = rptSubheading & "Druk vir: Kantoor; "
        'ElseIf BriefSkedule.rdKlient.Checked Then
        '    rptSubheading = rptSubheading & "Druk vir: Kliënt; "
        'End If

        ''Bestemming
        'If BriefSkedule.rdDrukker.Checked Then
        '    rptSubheading = rptSubheading & "Bestemming: Drukker)"
        'ElseIf BriefSkedule.rdEpos.Checked Then
        '    rptSubheading = rptSubheading & "Bestemming: E-pos)"
        'End If

        'letterhead_printRS("Polisse geselekteer om te druk", rptSubheading, rsList, arrFormatting)
    End Sub

    Private Sub btnHelp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnHelp.Click
        Dim message As Object
        message = "Information relating to the 'Policies for printing View'." & Chr(10) & Chr(10)
        message = message & Chr(149) & "  A specific group policies from this list can be selected for printing" & Chr(10)
        message = message & Chr(149) & "  Choose only one by saying 'click' or 'group by' Shift 'to keep" & Chr(10)
        message = message & Chr(149) & "  If no record (s) are selected, then everyone in the list printout" & Chr(10)
        MsgBox(message, MsgBoxStyle.Information)
    End Sub

    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click

        Select Case txtFormToPopulate.Text
            Case "BriefBesonderhede"
                If BriefBesonderhede.rdEpos.Checked Then

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
                    If BriefBesonderhede.rdDrukker.Checked Then
                        BriefBesonderhede.CreateReportFile()
                        gen_ArchiveDocument(BriefGeneries.result, Persoonl.POLISNO, 2, "", "", "", "")
                    ElseIf BriefBesonderhede.rdEpos.Checked Then
                        BriefBesonderhede.CreateReportFile()
                        gen_ArchiveDocument(BriefBesonderhede.result, Persoonl.POLISNO, 2, emailEngine.txtSubject.Text, emailEngine.txtTo.Text, emailEngine.txtBody.Text, getAttachmentsForEmailEngine, tempFilename)
                        emailEngine.sendMail(emailEngine.txtTo.Text, emailEngine.txtSubject.Text, emailEngine.txtBody.Text, tempFilename)
                    End If

                Else
                    BriefBesonderhedeReportViewer2.Show()
                End If

            Case "BriefGeneries"

                If BriefGeneries.rdEpos.Checked Then

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
                    If BriefGeneries.rdDrukker.Checked Then
                        BriefGeneries.CreateReportFile()
                        gen_ArchiveDocument(BriefGeneries.result, Persoonl.POLISNO, 4, "", "", "", "")
                    ElseIf BriefGeneries.rdEpos.Checked Then
                        BriefGeneries.CreateReportFile()
                        gen_ArchiveDocument(BriefGeneries.result, Persoonl.POLISNO, 4, emailEngine.txtSubject.Text, emailEngine.txtTo.Text, emailEngine.txtBody.Text, getAttachmentsForEmailEngine, tempFilename)
                        emailEngine.sendMail(emailEngine.txtTo.Text, emailEngine.txtSubject.Text, emailEngine.txtBody.Text, tempFilename)
                    End If

                Else
                    BriefGeneriesReportViewer.Show()
                End If

            Case "BriefSkedule"
                If BriefSkedule.rdEpos.Checked Then

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
                    If BriefSkedule.rdDrukker.Checked Then
                        BriefSkedule.CreateReportFile()
                        gen_ArchiveDocument(BriefGeneries.result, Persoonl.POLISNO, 7, "", "", "", "")
                    ElseIf BriefSkedule.rdEpos.Checked Then
                        BriefSkedule.CreateReportFile()
                        gen_ArchiveDocument(BriefSkedule.result, Persoonl.POLISNO, 7, emailEngine.txtSubject.Text, emailEngine.txtTo.Text, emailEngine.txtBody.Text, getAttachmentsForEmailEngine, tempFilename)
                        emailEngine.sendMail(emailEngine.txtTo.Text, emailEngine.txtSubject.Text, emailEngine.txtBody.Text, tempFilename)
                    End If

                Else
                    BriefSkeduleReportViewer.Show()
                End If

        End Select

        Me.Hide()
    End Sub

    'Public Sub populateList(ByRef rs As DAO.Recordset, ByRef formattingArray As Object)
    '    Dim k As Object
    '    Dim i As Short

    '    '    rsList = rs 'Global variable for form
    '    '    arrFormatting = formattingArray 'Global variable for form
    '        Set column and row numbers
    '    i = 0
    '    grid.Rows = rs.RecordCount + 1
    '    grid.Cols = UBound(formattingArray, 2) + 1

    '    '    Loop through recordset and array to populate data,headings and widths
    '    Do While Not rs.EOF
    '        For k = 0 To UBound(formattingArray, 2) 'Number of columns
    '            Select Case LCase(formattingArray(0, k))
    '                Case "posbestemming"
    '                    DataGridView1(i + 1, k, gen_getPosbestemmingDesc(0, Persoonl.POSBESTEMMING & "")) 'fieldname
    '                Case "gekans"
    '                    DataGridView1.set_TextMatrix(i + 1, k, gen_getStatus(0, rs.Fields("gekans").Value))
    '                Case Else
    '                    grid.set_TextMatrix(i + 1, k, rs.Fields(formattingArray(0, k)).Value & "") 'fieldname
    '            End Select
    '        Next
    '        i = i + 1
    '        '        rs.MoveNext()
    '    Loop

    'Set column widths and headings
    'For i = 0 To UBound(formattingArray, 2)
    '    'Set column heading
    '    'grid.set_TextMatrix(0, i, formattingArray(1, i))
    '    'set column widths
    '    'grid.set_ColWidth(i, formattingArray(2, i) * 100)

    '    'set style
    '    'grid.row = 0
    '    'grid.RowSel = 1
    '    'grid.col = i
    '    'grid.ColSel = i
    '    'grid.CellFontBold = True

    'Next

    '    Me.lblTotaal.Text = CStr(rs.RecordCount)

    ''grid.row = 0
    '    DataGridView1.RowCount = 0
    ''grid.col = 0
    '    DataGridView1.ColumnCount = 0

    'End Sub

    Private Sub BriefStatus_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'TODO ____
        'Data1.DatabaseName = pol_path & "/poldata5.mdb"
        '__________
        Dim rowCount As Integer
        '  Dim i As Integer

        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.ReadOnly = True
        DataGridView1.AutoGenerateColumns = False
        'DataGridView1.DataSource = BriefGeneries.ListGeneriesBriefPersoonlStatus()
        rowCount = DataGridView1.RowCount

        'If BriefGeneries.rdSpesifieke.Checked = True Then
        '    If rowCount > 1 Then
        '        DataGridView1.DataSource = BriefGeneries.ListGeneriesBriefPersoonlStatus()
        '    ElseIf rowCount < 1 Then
        '        MsgBox("There were no policies that meet the criteria", MsgBoxStyle.Information)
        '        Me.Close()
        '        Exit Sub
        '    Else

        '        BriefGeneriesReportViewer.Show()
        '        Me.Close()
        '    End If
        'ElseIf BriefBesonderhede.rdSpesifieke.Checked = True Then
        '    If rowCount > 1 Then
        '        DataGridView1.DataSource = BriefBesonderhede.ListBesonderhedeBriefPersoonlStatus()
        '    ElseIf rowCount < 1 Then
        '        MsgBox("There were no policies that meet the criteria", MsgBoxStyle.Information)
        '        Me.Close()
        '        Exit Sub
        '    Else

        '        BriefBesonderhede1ReportViewer.ShowDialog()
        '        Me.Close()
        '    End If
        'Else
        '    If rowCount > 1 Then
        '        DataGridView1.DataSource = BriefSkedule.BuildSql
        '    ElseIf rowCount < 1 Then
        '        MsgBox("There were no policies that meet the criteria", MsgBoxStyle.Information)
        '        Me.Close()
        '        Exit Sub
        '    Else

        '        BriefSkeduleReportViewer.ShowDialog()
        '        Me.Close()
        '    End If
        'End If
       
        Me.DataGridView1.BackgroundColor = System.Drawing.ColorTranslator.FromOle(RGB(178, 178, 178))

        Me.Text = My.Application.Info.Title & " - Letters - Policies for printing"
        'DataGridView1.AutoGenerateColumns = False
        'DataGridView1.DataSource = ListBriefPersoonlStatus()
        rowCount = DataGridView1.RowCount
        lblTotaal.Text = rowCount
        ' BriefSkedule.rdSpesifieke.Checked = False
        'BriefGeneries.rdSpesifieke.Checked = False
        'BriefBesonderhede.rdSpesifieke.Checked = False
    End Sub
    Function ListBriefPersoonlStatus() As List(Of PersoonlBriefStatusEntity)
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchBriefPersoonlStatus]")

                Dim list As List(Of PersoonlBriefStatusEntity) = New List(Of PersoonlBriefStatusEntity)
                While reader.Read()
                    Dim item As PersoonlBriefStatusEntity = New PersoonlBriefStatusEntity()

                    If Not IsDBNull(reader("POLISNO")) Then
                        item.POLISNO = reader("POLISNO")
                    End If
                    If Not IsDBNull(reader("VERSEKERDE")) Then
                        item.Versekerde = reader("VERSEKERDE")
                    End If
                    If Not IsDBNull(reader("VOORL")) Then
                        item.Voorl = reader("VOORL")

                    End If
                    If Not IsDBNull(reader("AREA_BESK")) Then
                        item.AreaBesk = reader("AREA_BESK")
                    End If
                    item.Posbesbesteming = reader("POSBESTEMMING")

                    If Persoonl.TAAL = 0 Then 'Afr

                        If item.Posbesbesteming = "0" Then 'Posadres
                            item.SavePosbesbesteming = "Posadres"
                        ElseIf item.Posbesbesteming = "1" Then 'Risikoadres
                            item.SavePosbesbesteming = "Risiko-adres"
                        ElseIf item.Posbesbesteming = "2" Then 'Universiteitsposbus
                            item.SavePosbesbesteming = "Universiteitsposbus"
                        ElseIf item.Posbesbesteming = "3" Then 'E-pos
                            item.SavePosbesbesteming = "E-pos"
                        Else
                            item.SavePosbesbesteming = "Incorrect mailing destination"
                        End If

                    Else 'Eng
                        If item.Posbesbesteming = "0" Then 'Postal address
                            item.SavePosbesbesteming = "Postal address"
                        ElseIf item.Posbesbesteming = "1" Then 'Risk address
                            item.SavePosbesbesteming = "Risk address"
                        ElseIf item.Posbesbesteming = "2" Then 'University mailbox
                            item.SavePosbesbesteming = "University mailbox"
                        ElseIf item.Posbesbesteming = "3" Then 'Email
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
   
    Public Sub populateGrid()
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.DataSource = BriefGeneries.ListGeneriesBriefPersoonlStatus()

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub
End Class