Option Strict Off
Option Explicit On
Friend Class TV_Diens_Frm
	Inherits System.Windows.Forms.Form
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		
		Me.Hide()
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		Me.Hide()
	End Sub
	
	Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
		TV_Byvoeg.ShowDialog()
		Grid1.Focus()
		Grid1.col = 0
		Grid1.row = 1
		
	End Sub
	
	Private Sub command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles command4.Click
        'Dim tvtoebpremoud As Object
        'Dim besk2 As Object
		If Grid1.row + 1 = Grid1.Rows Then
            MsgBox("You must be one of the TVs to choose!", 48, "Error!")

			Exit Sub
		End If
		
        'TV_Diens.Index = "NOM_INDEX"
        'TV_Diens.Seek("=", TV_Kodes(Grid1.row))
        'If TV_Diens.NoMatch Then
        '	MsgBox("Die TV Diens databasis is foutief!", 16, "Kritiese fout!")
        '	End
        'End If
		
        'If MsgBox("Is u seker u wil die TV/Video/Hoëtrou/Toebehore uitvee? (" + TV_Diens.Fields("beskrywing").Value + ")", 17, "Boodskap...") = 1 Then

        'besk_tv = " " + TV_Diens.Fields("beskrywing").Value + " verwyder. "

        'UPGRADE_WARNING: Couldn't resolve default property of object besk2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'besk2 = TV_Diens.Fields("beskrywing").Value

        'Persoonl.Edit()

        'Bereken tv, video en toebehore premies
        'UPGRADE_WARNING: Couldn't resolve default property of object tvtoebpremoud. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'tvtoebpremoud = Val(Persoonl.Fields("TV_DIENS").Value)

        'Select Case TV_Diens.Fields("d_tipe").Value
        '	'TeleVisie", "Video.", "H.T.
        '	Case 1, 2, 3
        '		Persoonl.Fields("TV_DIENS").Value = Val(Persoonl.Fields("TV_DIENS").Value) - CDbl(VB6.Format(tv_koste))

        '		'Toebehore
        '	Case 4
        '		Persoonl.Fields("TV_DIENS").Value = Val(Persoonl.Fields("TV_DIENS").Value) - CDbl(VB6.Format(ntoebehore))
        'End Select

        ''Opdateer wysigingsgeskiedenis
        'If Persoonl.Fields("taal").Value = 0 Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object tvtoebpremoud. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	BESKRYWING = " (" & (VB6.Format(tvtoebpremoud)) & ") op (" + (besk2) + ")"
        'Else
        '	'UPGRADE_WARNING: Couldn't resolve default property of object tvtoebpremoud. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	BESKRYWING = " (" & (VB6.Format(tvtoebpremoud)) & ") on (" + (besk2) + ")"
        'End If
        'Doen_Wysig((29))
        'Persoonl.Update()

        'TV_Diens.Delete()

        'Form1.Label18.Text =Format(Val(Persoonl.Fields("TV_DIENS").Value), "######.00")

        'End If
        'TV_Diens.Index = "PN_INDEX"

        'UPGRADE_WARNING: Form event TV_Diens_Frm.Activated has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        TV_Diens_Frm_Activated(Me, New System.EventArgs())
	End Sub
	
	'UPGRADE_WARNING: Form event TV_Diens_Frm.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub TV_Diens_Frm_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        'Dim Temp1 As Object
		Dim lus As Object
		Dim Ctr As Object
		'UPGRADE_WARNING: Couldn't resolve default property of object Ctr. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Ctr = 0
        'TV_Diens.Seek("=", Form1.POLISNO)
		For lus = 1 To Grid1.Rows - 2
			Grid1.RemoveItem(1)
		Next 
		
        '		If Not (TV_Diens.NoMatch) Then
        '			While Not (TV_Diens.EOF)
        '				If TV_Diens.Fields("POLISNO").Value <> Form1.POLISNO.Text Then
        '					GoTo einde
        '				End If
        '				Select Case TV_Diens.Fields("D_TIPE").Value
        '					Case "1"
        '						'UPGRADE_WARNING: Couldn't resolve default property of object Temp1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '						Temp1 = "Televisie"
        '					Case "2"
        '						'UPGRADE_WARNING: Couldn't resolve default property of object Temp1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '						Temp1 = "Video Masjien"
        '					Case "3"
        '						'UPGRADE_WARNING: Couldn't resolve default property of object Temp1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '						Temp1 = "H.T."
        '					Case "4"
        '						'UPGRADE_WARNING: Couldn't resolve default property of object Temp1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '						Temp1 = "Toebehore"
        '				End Select
        '				'UPGRADE_WARNING: Couldn't resolve default property of object Temp1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '				Grid1.AddItem(TV_Diens.Fields("BESKRYWING").Value + Chr(9) + Temp1, Grid1.Rows - 1)
        '				'UPGRADE_WARNING: Couldn't resolve default property of object Ctr. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '				TV_Kodes(Ctr + 1) = TV_Diens.Fields("NOMMER").Value
        '				TV_Diens.MoveNext()
        '				'UPGRADE_WARNING: Couldn't resolve default property of object Ctr. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '				Ctr = Ctr + 1
        '			End While
        '		Else
        '			'UPGRADE_WARNING: Couldn't resolve default property of object Ctr. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			Ctr = 0
        '		End If
        'einde: 
        '		Grid1.Focus()
        '		Grid1.col = 0
        '		Grid1.row = 1

        '		doen_subtotaal()
		
	End Sub
	
	Private Sub TV_Diens_Frm_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Grid1.col = 0
		Grid1.row = 0
		Grid1.Text = "Fabrikaat:"
		Grid1.col = 1
		Grid1.set_ColWidth(0, 2200)
		Grid1.set_ColWidth(1, 1500)
		Grid1.Text = "Beskrywing:"
		
        'besk_tv = ""
		
	End Sub
End Class