Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports DAL
Imports Microsoft.VisualBasic.PowerPacks
Imports System.IO
Imports Microsoft.Reporting.WinForms
Imports System.Net
Imports System.Configuration

Friend Class BriefDubbelPremie
    Inherits BaseForm
    Dim sSql As String
    Dim rownumber As Short
    Dim language As Byte
    Dim strAreaBranch As String
    Public result As Byte() = Nothing
    Dim tempFilename As String
    Private Sub btnClear_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClear.Click
        Me.txtPoskode.Text = ""
        Me.txtVoorstad.Text = ""

    End Sub

    Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
        If rdAfrikaans.Checked Then
            language = 0

        ElseIf rdEngels.Checked Then
            language = 1
        End If

        'Validate
        If IsNumeric(Me.txtPremium.Text) Then
            If CDbl(Me.txtPremium.Text) <= 0 Then
                MsgBox("The premium can not be negative or zero.", MsgBoxStyle.Information)

                Me.txtPremium.Focus()
                Exit Sub
            Else
                Me.txtPremium.Text = Me.txtPremium.Text
            End If
        Else
            MsgBox("The premium must be a numeric integer.", MsgBoxStyle.Information)

            Me.txtPremium.Focus()
            Exit Sub
        End If

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
                gen_ArchiveDocument(result, Persoonl.POLISNO, 9, "", "", "", "")
            ElseIf rdEpos.Checked Then
                CreateReportFile()
                gen_ArchiveDocument(result, Persoonl.POLISNO, 9, emailEngine.txtSubject.Text, emailEngine.txtTo.Text, emailEngine.txtBody.Text, getAttachmentsForEmailEngine, tempFilename)
                emailEngine.sendMail(emailEngine.txtTo.Text, emailEngine.txtSubject.Text, emailEngine.txtBody.Text, tempFilename)
            End If
            Exit Sub
        Else
            BriefDubblePremieReport.Show()
            Exit Sub
        End If

    End Sub
    Sub CreateReportFile()
        Dim detailStream As Stream
        detailStream = createDetailFile("/Mooirivier/BriefDubblePrime")
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

                rview.ServerReport.ReportServerCredentials.SetFormsCredentials(authCookie, ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), authority)

            Catch ex As Exception
                MsgBox("The ReportServer is unavailable at this moment. Try again later.")
            End Try

            rview.ServerReport.ReportServerUrl = New Uri(ConfigurationManager.AppSettings("ReportPath"))

            'begin params specific
            Dim language As Integer

            If rdAfrikaans.Checked Then
                language = 0

            ElseIf rdEngels.Checked Then
                language = 1
            End If
            Dim myTitel As TitleEntity
            myTitel = cmbTitel.SelectedItem



            Dim params() As Microsoft.Reporting.WinForms.ReportParameter = {New Microsoft.Reporting.WinForms.ReportParameter("Area", Persoonl.Area), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("POLISNO", Persoonl.POLISNO), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Taal", language), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Adres1", txtAdres1.Text), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Adres2", txtAdres2.Text), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Van", txtVan.Text), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Voorstad", txtVoorstad.Text), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Poskode", txtPoskode.Text), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Premium", txtPremium.Text), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Voorl", txtVoorletter.Text), _
                                                                            New Microsoft.Reporting.WinForms.ReportParameter("Titel", myTitel.Title)}

            'end params specific

            rview.ServerReport.ReportPath = reportPath
            rview.ServerReport.SetParameters(params)

            Dim encoding As String = ""
            Dim mimeType As String = ""
            Dim warnings As Microsoft.Reporting.WinForms.Warning() = Nothing
            Dim streamIDs As String() = Nothing
            Dim extension As String = ""
            Dim formats As String = "PDF" '//Desired format goes here (PDF, Excel, or Image)
            Dim deviceInfo As String = "<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>"

            result = rview.ServerReport.Render(formats, deviceInfo, mimeType, encoding, extension, streamIDs, warnings)

            stream = New MemoryStream(result.Length)
            stream.Write(result, 0, result.Length)

            Return stream
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Sub Populatefields()

        cmbTitel.DataSource = ListTitle(Integer.Parse(Persoonl.TAAL))

        cmbTitel.DisplayMember = "Title"
        cmbTitel.SelectedItem = Persoonl.TITEL

        Me.cmbTitel.Enabled = True
    End Sub

    Private Sub btnPostalCodes_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnPostalCodes.Click
        PoskodesSoek.txtFormToPopulate.Text = Me.Name
        PoskodesSoek.ShowDialog()
    End Sub
    Private Sub BriefDubbelPremie_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Andriette 16/08/2013 gebruik die global polisnommer
        'f Trim(Form1.POLISNO.Text) = "" Then
        If Trim(glbPolicyNumber) = "" Then
            MsgBox("First, select a policy for which the confirmation must be printed.", MsgBoxStyle.Exclamation)

            Me.Close()
        End If
        Populatefields()
        'Populate the title combobox

        Me.cmbTitel.SelectedIndex = -1

        'Populate the address fields from form1
        If Form1.posbestemming.Text = "Universiteitsposbus" Then 'University
            Me.txtAdres1.Text = "Posvakkie " & Form1.POS_VAKKIE.Text & ""
            Me.txtAdres2.Text = ""
            Me.txtVoorstad.Text = ""
            Me.txtPoskode.Text = ""
        Else
            Me.txtAdres1.Text = Form1.ADRES.Text
            Me.txtAdres2.Text = Form1.adres4.Text
            Me.txtVoorstad.Text = Form1.ADRES3.Text
            Me.txtPoskode.Text = Form1.ADRES2.Text
        End If

        Me.cmbTitel.Text = Form1.TITEL.Text
        Me.txtVoorletter.Text = Form1.VOORL.Text
        Me.txtVan.Text = Form1.VERSEKERDE.Text


        txtPremium.Text = Format(GetMaximumPremium(), "0.00")

        Me.Text = My.Application.Info.Title & "Poldata -Letters - Opinion: Duplicate premium deduction"
    End Sub


End Class