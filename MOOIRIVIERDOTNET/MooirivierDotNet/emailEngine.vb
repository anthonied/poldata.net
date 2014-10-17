Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class emailEngine
    Inherits System.Windows.Forms.Form

    'Description  :Capture the subject ect. for an email, expose functions to signon, create and send mail, sign-off
    Public returnValue As Boolean 'Return values for form Ok - True, Cancel - False
    Dim strEmailApp As String
    'Create and send an email with parameters supplied attachments can be sent as an array
    Public Function sendMail(ByRef recipient As String, ByRef subject As String, ByRef body As String, ByRef attachment As String) As Boolean

        Dim i As Object
        Dim attachStartAt As Short
        Dim objOLApp As Microsoft.Office.Interop.Outlook.Application
        Dim NewEmail As Microsoft.Office.Interop.Outlook.MailItem
        Dim objAddSig As Microsoft.Office.Interop.Outlook.Inspector
        Dim strEmailSignature As String

        Try
            If strEmailApp = "OLE" Then
                attachStartAt = 0

                'Compose new email
                'Linkie 29/08/2014 Kommentaar Mapi uit - sodat vorm kan oopmaak, maar dat die kode nogsteeds daar is vir n voorbeeld
                'Linkie 29/08/2014 Vermoede dat Mapi in vb6 gebruik was, en nou word iets nuut gebruik in .net wat hy nie na kon convert nie, kry die "mapi" in .net

                'Linkie 29/08/2014 MAPIMessage1.Compose() 

                'Linkie 29/08/2014 MAPIMessage1.RecipDisplayName = LCase(recipient)
                'Linkie 29/08/2014 MAPIMessage1.RecipAddress = LCase(recipient)

                'Linkie 29/08/2014 MAPIMessage1.MsgSubject = subject
                'Linkie 29/08/2014 MAPIMessage1.MsgNoteText = " " & body

                'Add the attachment
                If attachment <> "" Then
                    'Linkie 29/08/2014 MAPIMessage1.AttachmentIndex = 0
                    'Linkie 29/08/2014 MAPIMessage1.AttachmentPathName = attachment
                    'Linkie 29/08/2014 MAPIMessage1.AttachmentPosition = 0
                    attachStartAt = 1
                End If

                If lstAanhangsels.Items.Count > 0 Then
                    'Use the attachments specified on emailengine form
                    For i = attachStartAt To lstAanhangsels.Items.Count
                        If lstAanhangsels.Items(i - attachStartAt) <> "" Then
                            'Linkie 29/08/2014 MAPIMessage1.AttachmentIndex = i
                            'Linkie 29/08/2014 MAPIMessage1.AttachmentPathName = lstAanhangsels.Items(i - attachStartAt)
                            'Linkie 29/08/2014 MAPIMessage1.AttachmentPosition = i
                        End If
                    Next
                End If
                'Send the composed message
                'Linkie 29/08/2014 MAPIMessage1.Send(False)
            Else
                'MS OUTLOOK
                'Set the Application object
                objOLApp = New Microsoft.Office.Interop.Outlook.Application
                NewEmail = objOLApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)
                objAddSig = NewEmail.GetInspector

                'UPGRADE_WARNING: Couldn't resolve default property of object objAddSig.CurrentItem.body. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                strEmailSignature = objAddSig.CurrentItem.body

                NewEmail.To = LCase(recipient)
                NewEmail.Subject = subject
                NewEmail.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatRichText
                NewEmail.Body = body & strEmailSignature
                NewEmail.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML

                'Add the attachment(s)
                If attachment <> "" Then
                    NewEmail.Attachments.Add(attachment)
                End If

                If lstAanhangsels.Items.Count > 0 Then
                    'Use the attachments specified on emailengine form
                    For i = 1 To lstAanhangsels.Items.Count
                        'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        If lstAanhangsels.Items(i - 1) <> "" Then
                            'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            NewEmail.Attachments.Add(lstAanhangsels.Items(i - 1))
                        End If
                    Next
                End If

                NewEmail.Send()

                'UPGRADE_NOTE: Object objOLApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                objOLApp = Nothing
                'UPGRADE_NOTE: Object NewEmail may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                NewEmail = Nothing
            End If
            Exit Function
        Catch ex As Exception
            MsgBox("The e-mail could not be sent.", MsgBoxStyle.Exclamation)
        End Try
    End Function
    'Sign-on to the default mail handler and set sessionID
    Public Function signOn() As Boolean
        Dim strMsg As String

        On Error GoTo errorhandler
        strMsg = "Are you using Microsoft Outlook as your default email application?"
        strMsg = strMsg & Chr(13) & Chr(13) & "  'Yes' - Use Microsoft Outlook"
        strMsg = strMsg & Chr(13) & "  'No' - Use Outlook Express"
        strMsg = strMsg & Chr(13) & Chr(13) & "Please note: The email won't be sent until the next time you Send/Receive."

        Select Case MsgBox(strMsg, MsgBoxStyle.YesNoCancel)
            Case MsgBoxResult.Yes
                strEmailApp = "MSOL"
                signOn = True
            Case MsgBoxResult.No
                strEmailApp = "OLE"

                'Sign-on to Outlook express (default mail handler)
                'Linkie 29/08/2014 MAPISession1.signOn()

                'Set session for messages
                'Linkie 29/08/2014 MAPIMessage1.SessionID = MAPISession1.SessionID
                signOn = True
            Case Else
                signOn = False
        End Select
        Exit Function
errorhandler:
        If Err.Number = 32003 Then
            MsgBox("The e-mail functionality can not be used." & Chr(13) & "Moontlike redes mag wees dat daar geen e-pos gelaai is nie of die e-pos applikasie kon nie gebruik word nie., vbExclamation")

            signOn = False
        Else
            On Error GoTo 0
            Err.Raise(Err.Number)
        End If
    End Function
    'Sign-off
    Public Sub signOff()
        If strEmailApp = "OLE" Then
            'Linkie 29/08/2014 MAPISession1.signOff()
        End If
    End Sub
    Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        Me.returnValue = False
        Me.Hide()
    End Sub

    Private Sub btnHelp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnHelp.Click
        Dim message As Object
        'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        message = "E-mail details."" & Chr(10) & Chr(10)"

        'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        message = message & Chr(149) & "To whom the mail is addressed is required" & Chr(10)

        'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        message = message & Chr(149) & "There can be more than an address entered by them with a semicolon (;) to separate." & Chr(10)

        'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        message = message & Chr(149) & "A subject for the e-mail is required" & Chr(10)

        'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        message = message & Chr(149) & "There may be more than one attachment selected by each 'Add' to 'click'" & Chr(10)

        'UPGRADE_WARNING: Couldn't resolve default property of object message. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        message = message & Chr(149) & "When a group e-mail, this is the information for each would be sent" & Chr(10)

        MsgBox(message, MsgBoxStyle.Information)
    End Sub

    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
        'Check if form is valid

        If Trim(Me.txtTo.Text) = "" Then
            MsgBox("To whom the e-mail must be sent is required.", MsgBoxStyle.Exclamation)

            Me.txtTo.Focus()
            Exit Sub
        End If

        If Trim(Me.txtSubject.Text) = "" Then
            MsgBox("A subject for the e-mail must be entered.", MsgBoxStyle.Exclamation)

            Me.txtSubject.Focus()
            Exit Sub
        End If

        Me.returnValue = True
        Me.Hide()

    End Sub

    Private Sub btnSoek_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSoek.Click
        On Error GoTo errorhandler

        Dim MyResult As System.Windows.Forms.DialogResult

        MyResult = CommonDialog1Open.ShowDialog()
        If MyResult = DialogResult.Cancel Then
            MsgBox("Error")
        End If


        If CommonDialog1Open.FileName <> "" Then
            Me.lstAanhangsels.Items.Add(CommonDialog1Open.FileName)
        End If
        Exit Sub
errorhandler:
        If Err.Number = 32755 Then 'Cancel selected - do nothing

        Else
            On Error GoTo 0 'reset error handling
            Err.Raise(Err.Number)
        End If
    End Sub
    'Verwyder spesifiek item vanaf lys
    Private Sub btnVerwyder_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnVerwyder.Click
        If lstAanhangsels.SelectedIndex <> -1 Then
            Me.lstAanhangsels.Items.RemoveAt(lstAanhangsels.SelectedIndex)
        Else
            MsgBox("There must be annexed be chosen to remove", MsgBoxStyle.Information)

        End If
    End Sub
    Private Sub emailEngine_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.txtBody.Text = ""
        Me.txtSubject.Text = ""
        Me.lstAanhangsels.Items.Clear()

        'set default location for Browse/Open file dialog
        Me.CommonDialog1Open.InitialDirectory = "c:\"

        Me.Text = My.Application.Info.Title & " - Epos besonderhede"
    End Sub
End Class