Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmPassword
	Inherits System.Windows.Forms.Form
	
	Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
		'Set global variable
		pwdEntered = "Cancelled"
		Me.Close()
	End Sub
	
	Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
		'Set global variable
		pwdEntered = Me.txtPassword.Text
        Me.Close()
        'Kobus 06/05/2013 add
        Me.txtPassword.Text = ""
    End Sub

    Private Sub frmPassword_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        'Kobus 21/05/2014 voegby
        Me.txtPassword.Focus()
    End Sub
	
	Private Sub frmPassword_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Linkie 14/08/2014 - maak vorm standaard  Me.Text = My.Application.Info.Title & " - Sekuriteit"
        Me.Text = "Security"
        'Kobus 21/05/2014 voegby
        Me.txtPassword.Focus()
    End Sub

End Class