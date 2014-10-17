Option Strict Off
Option Explicit On
Friend Class TV_Byvoeg
	Inherits System.Windows.Forms.Form

	Private Sub Beskryw_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Beskryw.SelectedIndexChanged
		If Beskryw.SelectedIndex = Beskryw.Items.Count - 1 Then
        End If
    End Sub
	
	Private Sub Beskrywing_Click()
        Dim strAntwoord As String
		If Beskryw.SelectedIndex = Beskryw.Items.Count - 1 Then
            strAntwoord = InputBox("Wat is die nuwe TV. beskrywing?", "Voeg beskrywing by.")
            Beskryw.Items.RemoveAt(Beskryw.Items.Count - 1)
            Beskryw.Items.Add(strAntwoord)
			Beskryw.Items.Add("Voeg by.")
		End If
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        'Dim tvtoebpremoud As Object
		If Beskryw.SelectedIndex = -1 Then
            MsgBox("You must select the description!", 48, "Error!")

			Beskryw.Focus()
			Exit Sub
		End If
		If Tipe.SelectedIndex = -1 Then
            MsgBox("You must select a type of", 48, "Error!")

			Tipe.Focus()
			Exit Sub
		End If
		
        'TV_Diens.addNew()
        'TV_Diens.Fields("POLISNO").Value = Form1.POLISNO.Text
        'TV_Diens.Fields("D_TIPE").Value = Tipe.SelectedIndex + 1
        'TV_Diens.Fields("BESKRYWING").Value = VB6.GetItemString(Beskryw, Beskryw.SelectedIndex)
        'Tel_TV_Kode_By()
        'TV_Diens.Update()

        'Persoonl.Edit()
		
		'Bereken tv, video en toebehore premies
		'UPGRADE_WARNING: Couldn't resolve default property of object tvtoebpremoud. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'tvtoebpremoud = Persoonl.Fields("tv_diens").Value
		
		Select Case Tipe.SelectedIndex
			'TeleVisie", "Video.", "H.T.
			Case 0, 1, 2
				'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                'If IsDbNull(Persoonl.Fields("tv_diens").Value) Then
                '	Persoonl.Fields("TV_DIENS").Value =Format(tv_koste)
                'Else
                '	Persoonl.Fields("TV_DIENS").Value = Val(Persoonl.Fields("TV_DIENS").Value) + CDbl(VB6.Format(tv_koste))
                'End If
                'Toebehore
            Case 3
                'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                'If IsDbNull(Persoonl.Fields("tv_diens").Value) Then
                '	Persoonl.Fields("TV_DIENS").Value =Format(ntoebehore)
                'Else
                '	Persoonl.Fields("TV_DIENS").Value = Val(Persoonl.Fields("TV_DIENS").Value) + CDbl(VB6.Format(ntoebehore))
                'End If
        End Select

        'Opdateer wysigingsgeskiedenis
        'If Persoonl.Fields("taal").Value = 0 Then
        '	BESKRYWING = " wysig vanaf (" + ((tvtoebpremoud)) + ") na (" + (Persoonl.Fields("TV_DIENS")).Value + ") op (" + (VB6.GetItemString(Beskryw, Beskryw.SelectedIndex)) + ")"
        'Else
        '	BESKRYWING = " change from (" + ((tvtoebpremoud)) + ") to (" + (Persoonl.Fields("TV_DIENS")).Value + ") on (" + (VB6.GetItemString(Beskryw, Beskryw.SelectedIndex)) + ")"
        'End If
        'Doen_Wysig((28))

        'Persoonl.Update()

        'Form1.Label18.Text =Format(Val(Persoonl.Fields("TV_DIENS").Value), "######.00")

        'besk_tv = " " & VB6.GetItemString(Beskryw, Beskryw.SelectedIndex) & " bygevoeg. "
		
		Me.Hide()
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		Me.Hide()
	End Sub
	
	'UPGRADE_WARNING: Form event TV_Byvoeg.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub TV_Byvoeg_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		Beskryw.Focus()
		
	End Sub
	
	Private Sub TV_Byvoeg_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
        'TV_Maak.MoveFirst()
        'While Not (TV_Maak.EOF)
        '	Beskryw.Items.Add(TV_Maak.Fields("BESKRYWING").Value)
        '	TV_Maak.MoveNext()
        'End While
		Beskryw.Items.Add("Voeg By.")
		
		Tipe.Items.Add("TeleVisie")
		Tipe.Items.Add("Video.")
		Tipe.Items.Add("H.T.")
		
		Tipe.Items.Add("Toebehore")
		
	End Sub
End Class