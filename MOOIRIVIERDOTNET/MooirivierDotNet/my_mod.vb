Option Strict Off
Option Explicit On
Module MY_MOD
	'Function declaration for Set_Topmost
	Declare Function SetWindowPos Lib "User" (ByVal hWnd As Short, ByVal hWndInsertAfter As Short, ByVal x As Short, ByVal y As Short, ByVal cx As Short, ByVal cy As Short, ByVal wFlags As Short) As Short
	
	Public prev_tag As Short
	Public area_b(100) As Object
	
	Sub About(ByRef heading As String, ByRef aFrm As System.Windows.Forms.Form)
		
	End Sub
	
	Sub Centre_Ctrl(ByRef aCtrl As System.Windows.Forms.Control, ByRef aForm As System.Windows.Forms.Form)
		
        '	aCtrl.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(aForm.Width) - VB6.PixelsToTwipsX(aCtrl.Width)) / 2)
	End Sub
	
	Sub Centre_Form(ByRef aForm As System.Windows.Forms.Form)
		
        'If aForm.WindowState = 0 Then
        '    aForm.SetBounds(VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / 2) - (VB6.PixelsToTwipsX(aForm.Width) / 2)), VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / 2) - (VB6.PixelsToTwipsY(aForm.Height) / 2)), 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
        'End If

	End Sub
	
	Sub set_topmost(ByRef aFrm As System.Windows.Forms.Form)
		
    End Sub

    'Linkie 13/06/2013
    <System.Runtime.CompilerServices.Extension()> _
    Public Function left(ByVal str As String, ByVal length As Integer) As String
        Return str.Substring(0, Math.Min(str.Length, length))
    End Function
    'Linkie 13/06/2013
    <System.Runtime.CompilerServices.Extension()> _
    Public Function right(ByVal str As String, ByVal length As Integer) As String
        Return str.Substring(Math.Max(0, str.Length - length))
    End Function
End Module