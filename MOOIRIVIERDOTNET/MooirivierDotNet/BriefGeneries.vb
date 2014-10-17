Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Data.SqlClient
Imports DAL
Imports System.IO
Imports Microsoft.Reporting.WinForms
Imports System.Net
Imports System.Configuration

Friend Class BriefGeneries
    Inherits BaseForm

    Dim BranchInfoRetrieved As Boolean

    Dim rownumber As Short 'Current rownumber in letter
    Dim language As Byte 'The language of the current policy holder
    Dim letternumber As Short
    Dim blnUserControl As Boolean
    Dim tempFilename As String
    Dim fs As Object
    Dim formattingArray() As String
    Dim holderTitle As String
    Dim letterSubject As String
    Dim VersekeraarSql As String
    Public getStatus As String
    Public result As Byte() = Nothing

    'Dim rsVersekeraar As DAO.Recordset
    Dim strAreaBranch As String

    Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
       
        If Not validateForm() Then
            Exit Sub
        End If

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
                    gen_ArchiveDocument(result, Persoonl.POLISNO, 4, "", "", "", "")
                ElseIf rdEpos.Checked Then
                    CreateReportFile()
                    gen_ArchiveDocument(result, Persoonl.POLISNO, 4, emailEngine.txtSubject.Text, emailEngine.txtTo.Text, emailEngine.txtBody.Text, getAttachmentsForEmailEngine, tempFilename)
                    emailEngine.sendMail(emailEngine.txtTo.Text, emailEngine.txtSubject.Text, emailEngine.txtBody.Text, tempFilename)
                End If
                Exit Sub
            Else
                BriefGeneriesReportViewer.Show()
                Exit Sub
            End If
        End If

        'If rdHuidig.Checked Then
        '    BriefStatus.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        '    BriefStatus.DataGridView1.ReadOnly = True
        '    BriefStatus.DataGridView1.AutoGenerateColumns = False
        '    BriefStatus.DataGridView1.DataSource = CurrentPolicy()

        '    BriefGeneriesReportViewer.Show()
        '    Exit Sub
        'End If

        If Me.cmbVersekeraar.SelectedIndex = -1 And Me.rdSpesifieke.Checked = True Then
            MsgBox("An insurer must be selected if more than one schedule to print.", MsgBoxStyle.Information)
            Exit Sub
        End If

        'Validate form
        If Not validateForm() Then
            Exit Sub
        End If


        BriefStatus.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        BriefStatus.DataGridView1.ReadOnly = True
        BriefStatus.DataGridView1.AutoGenerateColumns = False
        BriefStatus.DataGridView1.DataSource = ListGeneriesBriefPersoonlStatus()
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
                BriefGeneriesReportViewer.Show()
            End If

        ElseIf BriefStatus.DataGridView1.RowCount < 1 Then
            MsgBox("No record match the criteria.")
            Exit Sub
        Else
            BriefStatus.ShowDialog()
        End If

        lblStatus.Text = "Search criteria by policies"
        Me.Refresh()

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        lblStatus.Text = ""
        Me.Refresh()

       
    End Sub

    Function ListGeneriesBriefPersoonlStatus() As List(Of PersoonlCriteria)
        Try
            'Dim sqlSurname As String
            Dim strArea As String
            strArea = ""

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Language", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlStatus", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlArea", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlSurnameFrom", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlSurnameTo", SqlDbType.NVarChar), _
                                                New SqlParameter("@sqlVersekeraar", SqlDbType.NVarChar), _
                                                New SqlParameter("@Sqlposbestemming", SqlDbType.NVarChar), _
                                                New SqlParameter("@dtpAanvFrom", SqlDbType.VarChar), _
                                                New SqlParameter("@dtpAanvTo", SqlDbType.VarChar)}
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

                If params(5).Value = Nothing Then
                    params(5).Value = DBNull.Value
                Else
                    params(5).Value = cmbVersekeraar.SelectedItem
                End If

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

                If dtpAanvFrom.Checked Then

                    params(7).Value = Format(dtpAanvFrom.Value, "yyyy-MM-dd")
                Else
                    params(7).Value = DBNull.Value
                End If

                If dtpAanvTo.Checked Then
                    params(8).Value = Format(dtpAanvTo.Value, "yyyy-MM-dd")
                Else
                    params(8).Value = DBNull.Value
                End If

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[ReportFetchPersoonlCriteria]", params)

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

    Private Sub chkAttach_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkAttach.CheckStateChanged
        If chkAttach.CheckState = 1 Then
            enableBrief(True)
        Else
            enableBrief(False)
        End If
    End Sub

    Private Sub cmbVersekeraar_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbVersekeraar.Leave
        Me.lstArea.DataBindings.Clear()

        lstArea.DataSource = FetchAreaBeskr(Me.cmbVersekeraar.Text)
       
    End Sub

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

    Private Sub BriefGeneries_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        rdHuidig.Checked = True
        rdSpesifieke.Checked = False
    End Sub

    Private Sub BriefGeneries_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        
        PopulateArea()

        PopulateVersekeraar()

        Me.dtpAanvTo.Checked = False
        Me.dtpAanvFrom.Checked = False

        ' lstArea.Items.Add("Alle areas")

        Me.cmbStatus.SelectedIndex = 0
        Me.cmbPosbestemming.SelectedIndex = 0
        Me.cmbTaal.SelectedIndex = 0

        txtOnderwerp.Text = ""
        txtInhoud.Text = ""

        Me.Text = My.Application.Info.Title & " - Letters - Generic"
    End Sub
    Sub PopulateArea()
        ' lstArea.Items.Clear()

        If ListAreaDropdown.Count > 0 Then
            lstArea.DataSource = ListAreaDropdown()
        End If
    End Sub

    
    Private Sub rdDrukker_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rdDrukker.CheckedChanged
        If eventSender.Checked Then
            enableBrief(True)
            Me.chkAttach.Visible = False
        End If
    End Sub
    Private Sub rdEpos_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rdEpos.CheckedChanged
        If eventSender.Checked Then
            enableBrief(False)
            Me.chkAttach.Visible = True
            Me.chkAttach.CheckState = System.Windows.Forms.CheckState.Unchecked
        End If
    End Sub
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

                Me.Label4.Enabled = False 'aanvangsdatum
                Me.Label9.Enabled = False 'tot
                Me.dtpAanvFrom.Enabled = False
                Me.dtpAanvTo.Enabled = False

                Me.dtpAanvFrom.Value = Now

                Me.dtpAanvTo.Value = Now
                Me.cmbVersekeraar.Enabled = False
                Me.lblVersekeraar.Enabled = False
                Me.cmbVersekeraar.SelectedIndex = -1
            End If
        End If
    End Sub

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
                Me.Label4.Enabled = True 'aanvangsdatum
                Me.Label9.Enabled = True 'tot
                Me.dtpAanvFrom.Enabled = True
                Me.dtpAanvTo.Enabled = True
                Me.dtpAanvFrom.Value = Now
                Me.dtpAanvFrom.Checked = False
                Me.dtpAanvTo.Value = Now
                Me.dtpAanvTo.Checked = False
                'Clear selection
                For i = 0 To lstArea.Items.Count - 1
                    Me.lstArea.SetSelected(i, False)
                Next

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

    Public Sub enableBrief(ByRef enabled_Renamed As Boolean)
        Me.lblBriefBesonderhede.Enabled = enabled_Renamed
        Me.txtInhoud.Enabled = enabled_Renamed
        Me.txtOnderwerp.Enabled = enabled_Renamed
        Me.lblInhoud.Enabled = enabled_Renamed
        Me.lblOnderwerp.Enabled = enabled_Renamed
    End Sub

    Public Function validateForm() As Boolean

        validateForm = True

        If Me.rdDrukker.Checked Then
            If Trim(Me.txtInhoud.Text) = "" Or Trim(Me.txtOnderwerp.Text) = "" Then
                validateForm = False
                MsgBox("The topic and content must be completed to generate a letter.", MsgBoxStyle.Exclamation)
                Me.txtOnderwerp.Focus()
                Exit Function
            End If
        End If

        If Me.rdEpos.Checked Then
            If Me.chkAttach.CheckState = 1 And (Trim(Me.txtInhoud.Text) = "" Or Trim(Me.txtOnderwerp.Text) = "") Then
                validateForm = False
                MsgBox("The topic and content must be completed to generate a letter.", MsgBoxStyle.Exclamation)
                Me.txtOnderwerp.Focus()
                Exit Function
            End If
        End If

    End Function
    Private Function FilterArea(ByVal area As AreaEntity) As Boolean

        If area.Tak_Naam = "MM Jeffreysbaai" Then
            Return True
        Else
            Return False
        End If
    End Function
    Sub PopulateVersekeraar()
        ' cmbVersekeraar.Items.Clear()
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
    Sub CreateReportFile()
        Dim detailStream As Stream
        detailStream = createDetailFile("/Mooirivier/BriefGeneries")
    End Sub
    Public Function createDetailFile(ByVal reportPath As String) As Stream
        Dim stream As MemoryStream = Nothing
        Dim rview = New ReportViewer
        Dim authCookie As Cookie
        Dim authority As String
        Dim AreaBesk As String = ""
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


            'Assign Policy number
            If rdHuidig.Checked = True Then
                'Andriette 01/08/2013 verander die global variable

                glbPolicyNumber = Persoonl.POLISNO
                AreaBesk = BriefStatus.DataGridView1.Rows(0).Cells(3).Value
            ElseIf rdSpesifieke.Checked = True Then
                'Andriette 01/08/2013 verander die global variable
                glbPolicyNumber = BriefStatus.DataGridView1.Rows(0).Cells(0).Value
            Else
                rdSpesifieke.Checked = True
                'Andriette 01/08/2013 verander die global variable
                glbPolicyNumber = BriefStatus.DataGridView1.SelectedRows(0).Cells(0).Value
                AreaBesk = BriefStatus.DataGridView1.SelectedRows(0).Cells(3).Value
            End If
            'Andriette 01/08/2013 verander die global variable
            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", glbPolicyNumber), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", Persoonl.TAAL), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("AreaBesk", AreaBesk), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Onderwerp", txtOnderwerp.Text), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Inhond", txtInhoud.Text)}


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
End Class