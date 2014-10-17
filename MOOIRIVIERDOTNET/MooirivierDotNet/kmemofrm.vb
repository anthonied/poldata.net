Option Strict Off
Option Explicit On
Friend Class KMemoFrm
    Inherits BaseForm
    'Dim Loading As Short
    Dim blnMem As Boolean
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        If blnMem Then
            'Doen_Wysig((58))
            UpdateWysig(58, "")
            On Error Resume Next
            'Persoonl.Edit()
            Persoonl.K_OPMERKING = Me.Memo.Text


            If IsDBNull(Persoonl.K_OPMERKING) And IsNothing(Persoonl.K_OPMERKING) Then
                If Len(Persoonl.K_OPMERKING) > 0 Then
                    If Persoonl.TAAL = "0" Then
                        Persoonl.K_OPMERKING = "Geen"
                    Else
                        Persoonl.K_OPMERKING = "None"
                    End If
                End If
            End If
            'Persoonl.Update()

            On Error GoTo 0
        End If
        Me.Hide()

    End Sub
    Private Sub KMemoFrm_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        blnLoading = True
        blnMem = False
        Memo.Top = 0
        Memo.Left = 0
        Memo.Width = Me.ClientRectangle.Width

        'Memo.Height = TwipsToPixelsY(PixelsToTwipsY(Me.ClientRectangle.Height) - 1000)

        blnLoading = False

        If Gebruiker.titel = "Besigtig" Then
            Me.Command1.Enabled = False
        End If
    End Sub
	
	Private Sub KMemoFrm_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Centre_Form(Me)
	End Sub
	
    Private Sub Memo_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Memo.TextChanged
        blnMem = True
    End Sub
End Class