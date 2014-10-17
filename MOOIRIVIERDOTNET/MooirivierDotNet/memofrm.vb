Option Strict Off
Option Explicit On
Friend Class MemoFrm
    Inherits BaseForm
    'Dim Loading As Short
    Dim blnMem As Boolean
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		
        If blnMem Then
            UpdateWysig((39), "")
            'Update_Memo()
        End If
		Me.Hide()
		
	End Sub
	
	'UPGRADE_WARNING: Form event MemoFrm.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub MemoFrm_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        blnLoading = True
        blnMem = False
		MEMO.Top = 0
		MEMO.Left = 0
		MEMO.Width = Me.ClientRectangle.Width
        'MEMO.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.ClientRectangle.Height) - 1000)
        blnLoading = False
	End Sub
	
	Private Sub MemoFrm_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Centre_Form(Me)
	End Sub
	
	'UPGRADE_WARNING: Event Memo.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub Memo_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Memo.TextChanged
        blnMem = True
	End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class