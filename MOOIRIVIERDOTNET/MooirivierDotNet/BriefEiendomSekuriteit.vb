Imports Microsoft.VisualBasic.PowerPacks
Imports System.IO
Imports System.Net.Mail
Imports System.Configuration
Imports Microsoft.Reporting.WinForms
Imports System.Net
Imports System.Security.Principal

Friend Class BriefEiendomSekuriteit
    Inherits BaseForm
	'Description: Eiendom Sekuriteitsvereistes Brief - Standard and after a claim
	Dim sSql As String
    Dim introwNumber As Short
	'UPGRADE_WARNING: Arrays in structure rsInfo may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    'Dim rsInfo As DAO.Recordset
	Dim lnglanguage As Byte
	Dim strTitle As String
	'UPGRADE_WARNING: Arrays in structure rsProperty may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    'Dim rsProperty As DAO.Recordset
	Dim k As Short
	'UPGRADE_WARNING: Arrays in structure rsTipeSekuriteit may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    'Dim rsTipeSekuriteit As DAO.Recordset
	Dim lngBitwise As Byte
	Dim strMessageBody As String
	Dim strMessage As String
	Dim strAdres4 As String
	Dim strAdres3 As String
	Dim strAdres As String
	Dim strAdres2 As String
    Dim strAreaBranch As String
    Public result As Byte() = Nothing
    Public tempFilename As String

    Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
        'Check if an item was selected

        If Me.lstRisikoAdres.SelectedIndex = -1 Then
            MsgBox("A risk address must be chosen before the report can be populated.", MsgBoxStyle.Exclamation)

            Exit Sub
        End If

        'get the bitvalue and everything that were chosen
        For Me.k = 0 To Me.chkSekuriteit.UBound
            If chkSekuriteit(k).CheckState = 1 Then
                lngBitwise = lngBitwise + (2 ^ k)
            End If
        Next

        If lngBitwise <> 0 Then
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
            Else
                frmBriefEiendomSekuriteitReport.ShowDialog()
            End If
        Else
            MsgBox("You do not have a security type selected.", MsgBoxStyle.Information)

        End If


        If rdDrukker.Checked Then
            CreateReportFile()
            gen_ArchiveDocument(result, Persoonl.POLISNO, 14, "", "", "", "")
        ElseIf rdEpos.Checked Then
            CreateReportFile()
            gen_ArchiveDocument(result, Persoonl.POLISNO, 14, emailEngine.txtSubject.Text, emailEngine.txtTo.Text, emailEngine.txtBody.Text, getAttachmentsForEmailEngine, tempFilename)
            emailEngine.sendMail(emailEngine.txtTo.Text, emailEngine.txtSubject.Text, emailEngine.txtBody.Text, tempFilename)
        End If

       
    End Sub

    Private Sub BriefEiendomSekuriteit_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Andriette 16/08/2013 gebruik die global polisnommer
        'If Trim(Form1.POLISNO.Text) = "" Then
        If Trim(glbPolicyNumber) = "" Then
            MsgBox("First, select a policy for which the confirmation must be printed.", MsgBoxStyle.Exclamation)

            Me.Close()
        End If

        'Write Security Items Caption on the check boxes
        setSecurityItemsCaption()

        'Populate list with Risk address
        populateLstRisikoAdres()

        Me.Text = My.Application.Info.Title & " - Letter - Property Security Requirements"
    End Sub

    'Populate the list box with all the risk addresses of the policy
    Public Sub populateLstRisikoAdres()
        'Dim i As Integer

        Me.lstRisikoAdres.DataBindings.Clear()
        Me.lstRisikoAdres.DisplayMember = "EiendomDisplay"
        'Me.lstRisikoAdres.ValueMember = "SekuriteitBitValue"
        Me.lstRisikoAdres.ValueMember = "EiendomDisplay"
        Me.lstRisikoAdres.DataSource = ListHuis(Persoonl.POLISNO)
    End Sub

    'Set captions of the security checkboxes
    Public Sub setSecurityItemsCaption()
        listSekuriteit = FetchSekuriteitList("Eiendom")
        Dim i As Integer
        For i = 0 To listSekuriteit.Count - 1
            Select Case listSekuriteit(i).Bit
                Case 0
                    _chkSekuriteit_0.Text = listSekuriteit(i).BeskrywingEngels
                    If listSekuriteit(i).BeskrywingEngels = "n.v.t." Or listSekuriteit(i).Sekuriteit = 12 Or listSekuriteit(i).Sekuriteit = 13 Or listSekuriteit(i).Sekuriteit = 14 Then
                        _chkSekuriteit_0.Enabled = False
                    End If
                Case 1
                    _chkSekuriteit_1.Text = listSekuriteit(i).BeskrywingEngels
                    If listSekuriteit(i).BeskrywingEngels = "n.v.t." Or listSekuriteit(i).Sekuriteit = 12 Or listSekuriteit(i).Sekuriteit = 13 Or listSekuriteit(i).Sekuriteit = 14 Then
                        _chkSekuriteit_1.Enabled = False
                    End If
                Case 2
                    _chkSekuriteit_2.Text = listSekuriteit(i).BeskrywingEngels
                    If listSekuriteit(i).BeskrywingEngels = "n.v.t." Or listSekuriteit(i).Sekuriteit = 12 Or listSekuriteit(i).Sekuriteit = 13 Or listSekuriteit(i).Sekuriteit = 14 Then
                        _chkSekuriteit_2.Enabled = False
                    End If
                Case 3
                    _chkSekuriteit_3.Text = listSekuriteit(i).BeskrywingEngels
                    If listSekuriteit(i).BeskrywingEngels = "n.v.t." Or listSekuriteit(i).Sekuriteit = 12 Or listSekuriteit(i).Sekuriteit = 13 Or listSekuriteit(i).Sekuriteit = 14 Then
                        _chkSekuriteit_3.Enabled = False
                    End If
                Case 4
                    _chkSekuriteit_4.Text = listSekuriteit(i).BeskrywingEngels
                    If listSekuriteit(i).BeskrywingEngels = "n.v.t." Or listSekuriteit(i).Sekuriteit = 12 Or listSekuriteit(i).Sekuriteit = 13 Or listSekuriteit(i).Sekuriteit = 14 Then
                        _chkSekuriteit_4.Enabled = False
                    End If
                Case 5
                    _chkSekuriteit_5.Text = listSekuriteit(i).BeskrywingEngels
                    If listSekuriteit(i).BeskrywingEngels = "n/a" Or listSekuriteit(i).Sekuriteit = 12 Or listSekuriteit(i).Sekuriteit = 13 Or listSekuriteit(i).Sekuriteit = 14 Then
                        _chkSekuriteit_5.Enabled = False
                    End If
                Case 6
                    _chkSekuriteit_6.Text = listSekuriteit(i).BeskrywingEngels
                    If listSekuriteit(i).BeskrywingEngels = "n/a" Or listSekuriteit(i).Sekuriteit = 12 Or listSekuriteit(i).Sekuriteit = 13 Or listSekuriteit(i).Sekuriteit = 14 Then
                        _chkSekuriteit_6.Enabled = False
                    End If
                Case 7
                    _chkSekuriteit_7.Text = listSekuriteit(i).BeskrywingEngels
                    If listSekuriteit(i).BeskrywingEngels = "n/a" Or listSekuriteit(i).Sekuriteit = 12 Or listSekuriteit(i).Sekuriteit = 13 Or listSekuriteit(i).Sekuriteit = 14 Then
                        _chkSekuriteit_7.Enabled = False
                    End If
            End Select
        Next
    End Sub

    'Set SECURITY checkboxes according to lngBitwise number
    'ublic Function setSecuritySelected(ByRef lngBitwise As Integer) As Object
    '|Andriette 14/08/2014 maak ;n private sb 
    Private Sub setSecuritySelected(ByRef lngBitwise As Integer)
        If lngBitwise <> 0 Then
            For Me.k = 0 To Me.chkSekuriteit.UBound
                If lngBitwise And (2 ^ k) Then
                    Me.chkSekuriteit(k).Text = Me.chkSekuriteit(k).Text & " *"
                End If
            Next
        End If
    End Sub

    Private Sub lstRisikoAdres_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstRisikoAdres.SelectedIndexChanged
        Dim myHuisEntity As HuisEntity
        'clear the chkboxes of previous choices
        setSecurityItemsCaption()

        'mark chkboxes with current items on the risk address
        myHuisEntity = lstRisikoAdres.SelectedItem
        setSecuritySelected(myHuisEntity.SekuriteitBitValue)
    End Sub

    'Generate the letter
    Public Sub SekuriteitsvereisteBrief()
        lblStatus.Text = "Genereer Sekuriteitsvereistes brief"
        Me.Refresh()
    End Sub
    Sub CreateReportFile()
        Dim detailStream As Stream
        detailStream = createDetailFile("/Mooirivier/BriefEiendomSekuriteit")
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
            Dim strStandaard, Diefwering, Veiligheidshekke, Alarm, Kompleks, Dorp, Wagte As String


            If _chkSekuriteit_0.Checked Then
                Diefwering = "true"
            Else
                Diefwering = "false"
            End If

            If _chkSekuriteit_1.Checked Then
                Veiligheidshekke = "true"
            Else
                Veiligheidshekke = "false"
            End If

            If _chkSekuriteit_2.Checked Then
                Alarm = "true"
            Else
                Alarm = "false"
            End If

            If _chkSekuriteit_3.Checked Then
                Kompleks = "true"
            Else
                Kompleks = "false"
            End If

            If _chkSekuriteit_4.Checked Then
                Dorp = "true"
            Else
                Dorp = "false"
            End If

            If _chkSekuriteit_5.Checked Then
                Wagte = "true"
            Else
                Wagte = "false"
            End If

            If rdStandaard.Checked Then
                strStandaard = "Standaard"
            Else
                strStandaard = " "
            End If
            Dim myEntity As HuisEntity
            myEntity = lstRisikoAdres.SelectedItem


            If _chkSekuriteit_0.Checked Then
                Diefwering = "true"
            Else
                Diefwering = "false"
            End If

            If _chkSekuriteit_1.Checked Then
                Veiligheidshekke = "true"
            Else
                Veiligheidshekke = "false"
            End If

            If _chkSekuriteit_2.Checked Then
                Alarm = "true"
            Else
                Alarm = "false"
            End If

            If _chkSekuriteit_3.Checked Then
                Kompleks = "true"
            Else
                Kompleks = "false"
            End If

            If _chkSekuriteit_4.Checked Then
                Dorp = "true"
            Else
                Dorp = "false"
            End If

            If _chkSekuriteit_5.Checked Then
                Wagte = "true"
            Else
                Wagte = "false"
            End If

            If rdStandaard.Checked Then
                strStandaard = "Standaard"
            Else
                strStandaard = " "
            End If
            Dim myReportEntity As HuisEntity
            myReportEntity = lstRisikoAdres.SelectedItem


            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", Persoonl.POLISNO), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", Persoonl.TAAL), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("RisikoAdres", myReportEntity.EiendomDisplay), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("TipeBrief", strStandaard), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Diefwering", Diefwering), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Veiligheidshekke", Veiligheidshekke), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Alarm", Alarm), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Kompleks", Kompleks), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Dorp", Dorp), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Wagte", Wagte)}


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

    'Function SendMail(ByVal ToAddress As String, ByVal Body As String, ByVal Subject As String, ByVal myClient As SmtpClient, ByVal FromAddress As MailAddress, ByVal AttachmentFileStream As Stream)
    '    Dim MailMessage As New MailMessage()
    '    Dim myAttachment As Attachment

    '    Try
    '        AttachmentFileStream.Position = 0
    '        myAttachment = New Attachment(AttachmentFileStream, "1.zip")

    '        MailMessage.From = FromAddress
    '        MailMessage.Body = Body
    '        MailMessage.Subject = Subject
    '        MailMessage.Attachments.Add(myAttachment)

    '        MailMessage.To.Clear()

    '        MailMessage.To.Add(ToAddress)
    '        MailMessage.CC.Add(FromAddress)


    '        'send the mail now
    '        myClient.Send(MailMessage)

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return False
    '    End Try

    '    Return True
    'End Function
End Class