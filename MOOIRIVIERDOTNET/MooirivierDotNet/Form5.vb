Imports DAL.DAL
Imports System.Data.SqlClient
Imports System
Imports System.IO

Public Class Form5
    'Private Sub Command1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command1.Click
    '    If chkDate.Checked = False Then
    '        MsgBox("It is essential that the correct date and time should be." & Chr(13) & "Please go to the 'checkbox' to 'click'.", MsgBoxStyle.Exclamation)
    '        Me.chkDate.Focus()
    '        Exit Sub
    '    End If
    '    If Len(Me.Gebnaam.Text) = 0 Then
    '        MsgBox("Please enter your username.", MsgBoxStyle.Exclamation)
    '        Me.Gebnaam.Focus()
    '        Exit Sub
    '    End If
    '    If Len(Me.Gebruikerkode.Text) = 0 Then
    '        MsgBox("Please enter your user code.", MsgBoxStyle.Exclamation)
    '        Me.Gebruikerkode.Focus()
    '        Exit Sub
    '    End If
    '    If Gebnaam.Text = String.Empty Or Gebruikerkode.Text = String.Empty Then
    '         Me.Gebnaam.Focus()
    '        Exit Sub
    '    Else
    '        Me.DialogResult = Windows.Forms.DialogResult.OK
    '        Me.Close()
    '    End If
    'End Sub
    'Private Sub Command2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command2.Click
    '    End
    'End Sub

    'Private Sub Form5_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
    '    If Me.DialogResult <> Windows.Forms.DialogResult.OK Then
    '        End
    '    End If
    'End Sub

    'Private Sub lblHoekom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblHoekom.Click
    '    frmWhy.Show()
    'End Sub

    Public Shared Form5Gebruiker As TextBox
    Public Shared Form5Password As TextBox
    Public Shared Form5Date As CheckBox
    Public Shared Form5OK As Boolean

    Private Sub lblHoekom_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lblHoekom.Click
        frmWhy.ShowDialog()
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click

        'Check if date and time was validated by the user
        If chkDate.Checked = False Then
            MsgBox("It is important that the correct date and time are entered." & Chr(13) & "Please click on the check.", MsgBoxStyle.Exclamation)
            Me.chkDate.Focus()
            Exit Sub
        End If
        If Len(Me.Gebnaam.Text) = 0 Then
            MsgBox("Please enter your username.", MsgBoxStyle.Exclamation)
            Me.Gebnaam.Focus()
            Exit Sub
        End If
        If Len(Me.Gebruikerkode.Text) = 0 Then
            MsgBox("Please enter your user code.", MsgBoxStyle.Exclamation)
            Me.Gebruikerkode.Focus()
            Exit Sub
        End If
        ShareObjectsForm5()
        If Gebnaam.Text = String.Empty Or Gebruikerkode.Text = String.Empty Then
            Me.Gebnaam.Focus()
            Exit Sub
        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
            ShareObjectsForm5()
            Me.Close()
        End If

        Me.Hide()

    End Sub
    Private Sub ShareObjectsForm5()
        
        Form5Gebruiker = Gebnaam
        Form5Password = Gebruikerkode
        form5Date = chkDate
        form5OK = Me.DialogResult
        
    End Sub
    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click

        'kanselleer die program
        End

    End Sub
    Private Sub Form5_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Gebnaam.Text = "" And Gebruikerkode.Text = "" Then
            End
        End If
    End Sub
    Private Sub Form5_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        sleutels = 0

        'Load version information into label
        Me.lblVersion.Text = "Version" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision

    End Sub
    Private Sub Gebruikerkode_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Gebruikerkode.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

        If eventArgs.KeyChar = Chr(13) Then
            Command1_Click(Command1, New System.EventArgs())
        End If

        sleutels = sleutels + 1

        If sleutels = 4 Then
            GoTo EventExitSub
            Me.Hide()
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub lblVersion_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lblVersion.Click
        MsgBox(Replace(My.Application.Info.Description, "|", Chr(13)), MsgBoxStyle.ApplicationModal, "Poldata - Version info")
    End Sub
    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Gebnaam.KeyPress, Gebruikerkode.KeyPress, chkDate.KeyPress
        If e.KeyChar = Chr(13) Then
            Command1_Click(Command1, New System.EventArgs())
        End If
    End Sub

    Shared Function form5Gebnaam() As String
        Throw New NotImplementedException
    End Function

    Shared Function form5Gebruikerkode() As String
        Throw New NotImplementedException
    End Function

End Class
