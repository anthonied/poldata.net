Option Strict Off
Option Explicit On

Imports Microsoft.VisualBasic.PowerPacks
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports DAL
Friend Class menmfrm
    Inherits BaseForm
    Dim numberRead As Integer
    Dim veld(200) As Object 'Aantal velde oorskry nie 200 nie
    'Kobus 04/03/2014 voegby
    Dim strFileName As String
    'Kobus 06/03/2014 voegby
    Dim blnDone As Boolean = False
	
	Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click
		Me.Close()
	End Sub
    Private Sub DeleteTemporaryTable()
        'Kobus 05/03/2014 toets of tydelike tabel bestaan indien wel - verwyder
        Try

            Using conn As SqlConnection = SqlHelper.GetConnection
                'Dim param() As SqlParameter = {New SqlParameter("@TableName", SqlDbType.NVarChar)}

                'param(0).Value = TableName

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[DeleteTemporyTable]")

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
	Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
        'Kobus 04/03/2014 voegby
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        If Me.txtLeernaam.Text <> "" Then
            Me.lblStatus.Text = ""
            'Kobus 04/03/2014 comment out
            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            'Kobus 04/03/2014 verander van If VB.Right(Me.txtLeernaam.Text, 3) = "xls" Then
            If VB.Right(Me.txtLeernaam.Text, 3) <> "DTA" Then
                'Kobus 04/03/2014 verander van MsgBox("There was an error with the file.", MsgBoxStyle.Information)
                MsgBox("Please select the correct file.", MsgBoxStyle.Information)
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Else
                'Kobus 04/03/2014 comment out
                'runUpdate()

            End If
        Else
            'Kobus 04/03/2014 voegby
            MsgBox("You must select the correct file.", MsgBoxStyle.Information)
            CommonDialog1Open.ShowDialog()
            If CommonDialog1Open.FileName <> "" Then
                Me.txtLeernaam.Text = CommonDialog1Open.FileName
                Me.lblStatus.Text = ""

                'Kobus 04/03/2014 verander van If VB.Right(Me.txtLeernaam.Text, 3) = "xls" Then
                If VB.Right(Me.txtLeernaam.Text, 3) <> "DTA" Then
                    'Kobus 04/03/2014 verander van MsgBox("There was an error with the file.", MsgBoxStyle.Information)
                    MsgBox("Please select the correct file.", MsgBoxStyle.Information)
                    'Kobus 04/03/2014 comment out'Kobus 04/03/2014 comment out
                    'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                    'Kobus 04/03/2014 voegby
                    Exit Sub
                Else
                    'Kobus 04/03/2014 comment out
                    'runUpdate()

                End If
            Else
                'Kobus 04/03/2014 verander van MsgBox("You must select the specific file.", MsgBoxStyle.Information)
                MsgBox("You must select the correct file.", MsgBoxStyle.Information)

                Me.btnSearch.Visible = True

                Exit Sub
            End If
        End If
        'Kobus 04/03/2014 voegby
        If MsgBox("Are you sure you want to update the Mead & McGrouther information?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.listStatus.Visible = True
            'Kobus 04/03/2014 voegby
            Me.listStatus.Items.Clear()
            'Kobus 20/4/2014 verander van "Updated table motor."
            Me.listStatus.Items.Add(("Update Mead & McGrouther table."))
            Me.Refresh()
            'Kobus 04/03/2014 voegby
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            strFileName = txtLeernaam.Text

            DeleteTemporaryTable()   '"poldata5.MeadMcGTemp4"
            UpdateMead_Mecgrouther()
        Else
            Exit Sub
        End If
        Me.listStatus.Visible = True
        'Kobus 17/4/2014 verander van Me.listStatus.Items.Add(("Updated Zip Code table."))
        Me.listStatus.Items.Add(("Update Mead and Mcgrouther table."))
        Me.Refresh()
        'updatePostalCodes()

        'Kobus 06/03/2014 verander van If UpdateMead_Mecgrouther() = True Then
        If blnDone = True Then
            Me.listStatus.Items.Add(("Update is completed."))

            Me.Refresh()

            Me.Cursor = System.Windows.Forms.Cursors.Default
            MsgBox("Update is completed.", MsgBoxStyle.Information)


            Me.btnOk.Enabled = False

            'Kobus 17/4/2014 verander van Me.Label1.Text = "Opdatering afgehandel."
            Me.Label1.Text = "Update is completed."
        Else
            Me.listStatus.Items.Add(("Update failed."))
            Me.btnClose.Enabled = True
            Me.Refresh()
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If

        Me.btnOk.Enabled = False
        'DeleteTemporaryTable()
    End Sub
	
	Private Sub btnSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSearch.Click
		Me.CommonDialog1Open.ShowDialog()
		Me.txtLeernaam.Text = Me.CommonDialog1Open.FileName
	End Sub
	
	Private Sub menmfrm_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		numberRead = 0
        Me.lblStatus.Text = "0"
        'Kobus 04/03/2014 voegby
        Me.listStatus.Visible = False
        txtLeernaam.Text = ""
        Me.btnSearch.Visible = True
        Me.btnOk.Enabled = True
        'Kobus 20/2/2014 verander van " - Databasis Opdatering - Mead & McGrouther"
        Me.Text = My.Application.Info.Title & " - Database update (Mead & McGrouther)"
	End Sub
    Private Function UpdateMead_Mecgrouther() As Boolean
        'Kobus 04/03/2014 voegby om nuwe kode op te stel vir hierdie opsie

        'Kobus 05/03/2014 skep 'n tydelike tabel 
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Dim connectionString As String = SqlHelper.DefaultConnectionString()
        Dim connB As New SqlClient.SqlConnection(connectionString)
        Dim cmdB As New SqlClient.SqlCommand
        Dim objReader As System.IO.StreamReader

                Try

            connB.Open()
            cmdB.CommandType = CommandType.Text
            cmdB.Connection = connB

                    'objReader = New System.IO.StreamReader("C:\Users\Kobus Visser\Documents\SQL Server Management Studio\CreateMedMcGTemp4.sql")
                    objReader = New System.IO.StreamReader("C:\MenMSkepTable.txt")
            cmdB.CommandText = objReader.ReadToEnd

            cmdB.ExecuteNonQuery()

                    objReader.Close()
            connB.Close()


                    'Kobus 05/03/2014 vul tydelike tabel met nuutste inligting 
            connB.Open()
            cmdB.CommandType = CommandType.Text
            cmdB.Connection = connB


                    objReader = New System.IO.StreamReader("C:\BulkInsert.txt")
            cmdB.CommandText = objReader.ReadToEnd

            cmdB.ExecuteNonQuery()

                    objReader.Close()
            connB.Close()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            blnDone = True

            'MsgBox("So far so good!!.", MsgBoxStyle.Information)

        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try

        Return True

        'Kobus 06/03/2014 - tydelik - HIER MOET INLIGTING WAT IN DIE TYDELIKE TABEL IS VERWERK WORD
        UpdateMOTORS()

    End Function
    Private Sub UpdateMOTORS()
        'Kobus 06/03/2014 - skep om data vanaf Tydelike Tabel oor te dra na poldata5.MOTORS
        'andriette 15/08/2014 haal al die ongebruikte veranderlikes uit om die warnings weg te vat
        '   Dim strJJ As String
        '   Dim strSoort As String
        ' Dim i As Integer
        '   Dim strBeginJaar As String
        ' Dim strEindJaar As String
        '  Dim strInRuilJaar As String
    End Sub
	Private Sub runUpdate()
		Dim jj As Object
		Dim soort As Object
		Dim i As Object
        Dim beginjaar As Object
		Dim begindatumjaar As Object
        Dim eindjaar As Object
		Dim einddatumjaar As Object
		Dim inruiljaar As Object
		Dim endveld As Object
		Dim tel As Object
		Dim beginveld As Object
		Dim menmin As Object
		Dim leernaam As Object
		Dim rekord As Object
		'Are you sure you want to run this upgrade ?
        'Dim pol As DAO.Database

        'Dim motor As DAO.Recordset
        'Kobus 20/4/2014 verander van "Are you sure you want to update the Engine Values ​​do?"
        If MsgBox("Are you sure you want to update the Mead & McGrouther information?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.listStatus.Visible = True

            'Kobus 20/4/2014 verander van "Updated table motor."
            Me.listStatus.Items.Add(("Update Mead & McGrouther table."))
            Me.Refresh()

            'Verklaar databasis en recordsets

            'Maak databasis en recordsets oop
            'pol = DAODBEngine_definst.OpenDatabase("c:\polis5\poldata5.mdb")
            'motor = pol.OpenRecordset("motor")

            On Error Resume Next

            'motor.Index = "mk_index" 'Kode + jaar

            'Maak uitvoer leer oop
            FileOpen(2, "c:\polis5\menm.txt", OpenMode.Output)
            PrintLine(2, "Meade en McGrouther opdaterings soos gedoen op " & Format(Now, "dd/mm/yyyy"))
            PrintLine(2, "Rekord, Soort, Kode, Jaar, Maak, Besk")
            PrintLine(2, TAB(10), "CC, Inruil, Koop, Nuut, Tipe, Cylinder,Eeu,Eindig datum")
            updateErrorList(True)

            'Lees Meade and McGrouther leer en opdateer na motor recordset in poldata5.mdb

            rekord = 1


            leernaam = Me.CommonDialog1Open.FileName

            FileOpen(1, leernaam, OpenMode.Input)
            updateErrorList(True)

            menmin = LineInput(1)

            While Not EOF(1)
                numberRead = numberRead + 1

                'Kry al 115 velde

                beginveld = 1

                tel = 1

                Do Until InStr(beginveld, menmin, ",") = 0
                    'Nie einde van rekord - kry volgende veld
                    endveld = InStr(beginveld, menmin, ",")

                    veld(tel) = Mid(menmin, beginveld, endveld - beginveld)

                    'Verwyder aanhalingstekens van maak  (veld 2)

                    If tel = 2 Then
                        veld(tel) = Mid(veld(tel), 2, Len(veld(tel)) - 2)
                        veld(tel) = Trim(veld(tel))
                    End If
                    updateErrorList(True)

                    tel = tel + 1
                    beginveld = endveld + 1
                Loop
                'Einde van rekord - kry laaste veld
                If InStr(beginveld, menmin, ",") = 0 Then
                    veld(tel) = Mid(menmin, beginveld, Len(menmin) - beginveld + 1)
                End If
                'Kies net Moors, bakkies en motorfietse
                If veld(67) = "A" Or veld(67) = "B" Or veld(67) = "C" Or veld(67) = "H" Or veld(67) = "M" Then
                    GoTo kiesmotor
                    updateErrorList(True)
                Else
                    GoTo volgmotor
                    updateErrorList(True)
                End If
kiesmotor:
                'Kobus 03/03/2014 comment out 
                'Inruil en koop waardes asook jaar en eeu
                'Daar is 15 inruil en 15 koop waardes
                'Waarde 15 is die huidige jaar en die res is 15 jaar terug
                'Is daar inruilwaardes wat verander?
                inruiljaar = Year(Now)
                'Bereken eindjaar waarde wat gebruik gaan word om nie verder te opdateer as 'n motor se eindjaar nie
                If veld(115) <> "       " Then
                    einddatumjaar = VB.Right(veld(115), 4)
                    einddatumjaar = Val(einddatumjaar)
                    eindjaar = Year(Now) - einddatumjaar
                    eindjaar = 40 - eindjaar
                End If
                'Bereken beginjaar waarde wat gebruik gaan word om nie voor 'n motor se beginjaar nie
                begindatumjaar = VB.Right(veld(10), 4)
                begindatumjaar = Val(begindatumjaar)
                beginjaar = Year(Now) - begindatumjaar
                beginjaar = 40 - beginjaar
                For i = 40 To 26 Step -1
                    'Opdateer een rekord van motor recordset
                    'motor.Seek("=", veld(1), VB.Right(inruiljaar, 2))
                    If (motor.NoMatch) Then
                        'Nuwe motor
                        soort = "New"

                        'motor.addNew()

                        updateErrorList(True)
                    Else
                        'Bestaande motor opdateer
                        soort = "Change"
                        'motor.Edit()
                        updateErrorList(True)
                    End If
                    motor.KODE = Mid(veld(1), 1, 8)

                    motor.Mark_R = Trim(veld(2))
                    If Len(veld(3)) > 30 Then
                        motor.besk = Mid(veld(3), 1, 30)
                    Else
                        ''
                        motor.besk = Trim(veld(3))
                    End If

                    motor.CC = Mid(Trim(veld(5)), 1, 4)
                    motor.Cyl = Mid(Trim(veld(4)), 1, 4)

                    'Tipe (1=motor, 2 = bakkies, 6 = motorfiets, 7 = ander
                    Select Case veld(67)
                        Case "A"
                            motor.TIPE = "1"
                        Case "B"
                            motor.TIPE = "2"
                        Case "C"
                            motor.TIPE = "6"
                        Case "H"
                            motor.TIPE = "2"
                        Case "M"
                            motor.TIPE = "2"
                        Case "T"
                            motor.TIPE = "7"
                        Case "U"
                            motor.TIPE = "7"
                        Case "Z"
                            motor.TIPE = "7"
                        Case Else
                            motor.TIPE = "7"
                    End Select

                    jj = Str(inruiljaar)
                    jj = Trim(jj)

                    motor.Jr = VB.Right(jj, 2)
                    motor.EEU = Mid(jj, 1, 2)
                    motor.Inruil_R = Trim(veld(i))
                    motor.Koop_R = Trim(veld(i + 15))
                    motor.Nuut_R = Trim(veld(i - 15))
                    If veld(115) <> "       " Then
                        motor.Einde = Mid(veld(115), 1, 10)
                    Else
                        motor.Einde = " "
                    End If


                    motor.Begin = veld(10)
                    '        'Skryf na uitvoer leer
                    PrintLine(2, rekord, TAB(7), soort, TAB(14), motor.KODE, TAB(23), motor.Jr, TAB(30), motor.Mark_R, TAB(50), motor.besk, TAB(73), motor.Begin)
                    PrintLine(2, TAB(10), motor.CC, TAB(20), motor.Inruil_R, TAB(30), motor.Koop_R, TAB(40), motor.Nuut_R, TAB(50), motor.TIPE, TAB(60), motor.Cyl, TAB(70), motor.EEU, TAB(73), motor.Einde)

                    'motor.Update()

                    updateErrorList(True)
volg_jaar:
                    inruiljaar = inruiljaar - 1
                Next

                Me.lblStatus.Text = CStr(numberRead)
                Me.lblStatus.Refresh()

                rekord = rekord + 1

volgmotor:
                menmin = LineInput(1)
            End While

            FileClose(1)
            FileClose(2)

            If Not (Dir("c:\polis5\kwot_new.mdb") = "") Then
                updateKwotasie()
                updateErrorList(True)
            End If
            PrintLine(2, "*** End of Report ****")
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Me.listStatus.Items.Add("update completed.")
            MsgBox("update completed.", MsgBoxStyle.Information)
            Me.btnOk.Enabled = False
            Me.btnSearch.Enabled = False

        End If
        FileClose(1)
        FileClose(2)
        updateErrorList(True)

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub updateKwotasie()
        'andriette 15/08/2014 haal al die ongebruikte veranderlikes uit om die warnings weg te vat
        ' Dim jj As Object
        '  Dim soort As Object
        Dim i As Object
        Dim beginjaar As Object
        Dim begindatumjaar As Object
        Dim eindjaar As Object
        Dim einddatumjaar As Object
        Dim inruiljaar As Object
        Dim endveld As Object
        Dim tel As Object
        Dim beginveld As Object
        Dim menmin As Object
        Dim leernaam As Object
        Dim rekord As Object
        'Dim pol_kwot As DAO.Database

        'Dim motor_kwot As DAO.Recordset

        'pol_kwot = DAODBEngine_definst.OpenDatabase("c:\polis5\kwot_new.mdb")
        'motor_kwot = pol_kwot.OpenRecordset("motor")

        'On Error Resume Next

        'motor_kwot.Index = "mk_index" 'Kode + jaar

        'Maak uitvoer leer oop
        FileOpen(2, "c:\polis5\menm.txt", OpenMode.Output)
        PrintLine(2, "Meade en McGrouther opdaterings soos gedoen op " & Format(Now, "dd/mm/yyyy"))
        PrintLine(2, "Rekord, Soort, Kode, Jaar, Maak, Besk")
        PrintLine(2, TAB(10), "CC, Inruil, Koop, Nuut, Tipe, Cylinder,Eeu,Eindig datum")
        updateErrorList(True)

        'Lees Meade and McGrouther leer en opdateer na motor recordset in poldata5.mdb

        rekord = 1
        leernaam = Me.CommonDialog1Open.FileName

        FileOpen(1, leernaam, OpenMode.Input)
        updateErrorList(True)

        menmin = LineInput(1)
        While Not EOF(1)
            numberRead = numberRead + 1

            'Kry al 115 velde
            beginveld = 1
            tel = 1

            Do Until InStr(beginveld, menmin, ",") = 0
                'Nie einde van rekord - kry volgende veld

                endveld = InStr(beginveld, menmin, ",")

                veld(tel) = Mid(menmin, beginveld, endveld - beginveld)

                'Verwyder aanhalingstekens van maak  (veld 2)

                If tel = 2 Then

                    veld(tel) = Mid(veld(tel), 2, Len(veld(tel)) - 2)

                    veld(tel) = Trim(veld(tel))
                End If

                updateErrorList(True)

                tel = tel + 1

                beginveld = endveld + 1
            Loop
            'Einde van rekord - kry laaste veld

            If InStr(beginveld, menmin, ",") = 0 Then

                veld(tel) = Mid(menmin, beginveld, Len(menmin) - beginveld + 1)
            End If
            'Kies net Moors, bakkies en motorfietse
            If veld(67) = "A" Or veld(67) = "B" Or veld(67) = "C" Or veld(67) = "H" Or veld(67) = "M" Then
                GoTo kiesmotor
                updateErrorList(True)
            Else
                GoTo volgmotor
                updateErrorList(True)
            End If
kiesmotor:

            'Inruil en koop waardes asook jaar en eeu
            'Daar is 15 inruil en 15 koop waardes
            'Waarde 15 is die huidige jaar en die res is 15 jaar terug

            'Is daar inruilwaardes wat verander?

            inruiljaar = Year(Now)

            'Bereken eindjaar waarde wat gebruik gaan word om nie verder te opdateer as 'n motor se eindjaar nie

            If veld(115) <> "       " Then

                einddatumjaar = VB.Right(veld(115), 4)
                einddatumjaar = Val(einddatumjaar)
                eindjaar = Year(Now) - einddatumjaar
                eindjaar = 40 - eindjaar
            End If

            'Bereken beginjaar waarde wat gebruik gaan word om nie voor 'n motor se beginjaar nie

            begindatumjaar = VB.Right(veld(10), 4)
            begindatumjaar = Val(begindatumjaar)
            beginjaar = Year(Now) - begindatumjaar
            beginjaar = 40 - beginjaar
            For i = 40 To 26 Step -1
                'Opdateer een rekord van motor recordset
                'motor_kwot.Seek("=", veld(1), VB.Right(inruiljaar, 2))
                'If (motor_kwot.NoMatch) Then
                '    'Nuwe motor
                '    soort = "New"
                '    'motor_kwot.addNew()
                '    updateErrorList(True)
                'Else
                '    'Bestaande motor opdateer

                '    soort = "Change"
                '    'motor_kwot.Edit()
                '    updateErrorList(True)
                'End If

                'motor_kwot.KODE = Mid(veld(1), 1, 8)

                'motor_kwot.Mark_R = Trim(veld(2))

                'If Len(veld(3)) > 30 Then

                '    motor_kwot.besk = Mid(veld(3), 1, 30)
                'Else

                '    motor_kwot.besk = Trim(veld(3))
                'End If
                'motor_kwot.CC = Mid(Trim(veld(5)), 1, 4)

                'motor_kwot.Cyl = Mid(Trim(veld(4)), 1, 4)

                ''Tipe (1=motor, 2 = bakkies, 6 = motorfiets, 7 = ander
                'Select Case veld(67)
                '    Case "A"
                '        motor_kwot.TIPE = "1"
                '    Case "B"
                '        motor_kwot.TIPE = "2"
                '    Case "C"
                '        motor_kwot.TIPE = "6"
                '    Case "H"
                '        motor_kwot.TIPE = "2"
                '    Case "M"
                '        motor_kwot.TIPE = "2"
                '    Case "T"
                '        motor_kwot.TIPE = "7"
                '    Case "U"
                '        motor_kwot.TIPE = "7"
                '    Case "Z"
                '        motor_kwot.TIPE = "7"
                '    Case Else
                '        motor_kwot.TIPE = "7"
                'End Select

                'jj = Str(inruiljaar)

                'jj = Trim(jj)

                'motor_kwot.Jr = VB.Right(jj, 2)
                'motor_kwot.EEU = Mid(jj, 1, 2)
                'motor_kwot.Inruil_R = Trim(veld(i))
                'motor_kwot.Koop_R = Trim(veld(i + 15))
                'motor_kwot.Nuut_R = Trim(veld(i - 15))
                'If veld(115) <> "       " Then

                '    motor_kwot.Einde = Mid(veld(115), 1, 10)
                'Else
                '    motor_kwot.Einde = " "
                'End If

                'motor_kwot.Begin = veld(10)

                ''Skryf na uitvoer leer
                'PrintLine(2, rekord, TAB(7), soort, TAB(14), motor_kwot.KODE, TAB(23), motor_kwot.Jr, TAB(30), motor_kwot.Mark_R, TAB(50), motor_kwot.besk, TAB(73), motor_kwot.Begin)
                'PrintLine(2, TAB(10), motor_kwot.CC, TAB(20), motor_kwot.Inruil_R, TAB(30), motor_kwot.Koop_R, TAB(40), motor_kwot.Nuut_R, TAB(50), motor_kwot.TIPE, TAB(60), motor_kwot.Cyl, TAB(70), motor_kwot.EEU, TAB(73), motor_kwot.Einde)

                'motor_kwot.Update()
                updateErrorList(True)
volg_jaar:

                inruiljaar = inruiljaar - 1
            Next

            Me.lblStatus.Text = CStr(numberRead)
            Me.lblStatus.Refresh()

            rekord = rekord + 1

volgmotor:

            menmin = LineInput(1)
        End While
        updateErrorList(True)

    End Sub
	
    'Update listbox with current error
    'andriette 15/08/2014 verander na ;n private sub uit om die warnings weg te vat
    'Public Function updateErrorList(ByRef resetError As Boolean) As Object
    Private Sub updateErrorList(ByRef resetError As Boolean)
        If Err.Number <> 0 Then
            Me.listStatus.Items.Add("     !Attention: " & Err.Description)
            If resetError Then
                Err.Clear()
            End If
        End If
    End Sub
End Class