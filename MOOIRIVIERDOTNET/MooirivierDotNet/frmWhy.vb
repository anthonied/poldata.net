Option Strict Off
Option Explicit On
Friend Class frmWhy
	Inherits System.Windows.Forms.Form
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		Me.Close()
	End Sub
	
	Private Sub frmWhy_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Me.Text = My.Application.Info.Title
	End Sub

    Private Sub lblTipText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTipText.Click

    End Sub
End Class