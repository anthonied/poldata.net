Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports DAL

Friend Class A_Risiko
    Inherits BaseForm

    Dim dblPremie As Double
    'Dim ardekking As Object
    Dim intDekking As Integer
    Dim pkAllerisk As Integer
    Dim blnDontClear As Boolean
    'Kobus 14/10/2013 voegby
    Dim blnInformationChanged As Boolean
    Dim blnCancel As Boolean
    Dim strSerienommer As String
    'Kobus 14/10/2013 voegby
    Dim blnFirst As Boolean
    'Kobus 21/10/2013 voegby
    Dim intCurrentIndex As Integer
    Dim bln2000plus As Boolean
    'Kobus 28/10/2013 voegby
    Dim blnValidateForm As Boolean
    'Kobus 30/10/2013 voegby
    Dim strEistipe As String
    Private Sub arnplaat_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles arnplaat.TextChanged
        If blnediting Then
            ' blnNp = 'Andriette 13/08/2014 word nerens gebruik nie 
        End If

    End Sub

    Private Sub arnplaat_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles arnplaat.KeyPress
        Dim KeyAscii As Integer = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case 34, 39
                ' Anything else is unacceptable, and should be ignored
                MsgBox("The characters '' and "" "" can not be used.", MsgBoxStyle.Information)
                KeyAscii = 0
            Case Else
                ' These are acceptable keystrokes
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub btnRedigeer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnRedigeer.Click, btnRedigeer.Click
        'Dim intPolisno As Integer
        Dim intRy As Integer
        'Kobus 14/10/2013 voegby
        blnCancel = False

        'Kobus 23/10/2013 comment out
        'Nuwe = False
        'Kobus 11/10/2013 verander van ardekking = alle_risiko.DEKKING
        intDekking = Format(Val(alle_risiko.DEKKING), "##########")
        dblPremie = Format(Val(alle_risiko.Premie), "########0.00")
        'intPolisno = glbPolicyNumber  'alle_risiko.POLISNO
        'Kobus 16/10/2013 comment out en voegby
        'alle_risiko = FetchAlleriskByPrimarykey() 
        If blnediting Then
            TestForChange()
            If blnInformationChanged = True Then
                ValidateForm()
                If blnValidateForm = False Then
                    Exit Sub
                End If

                'Kobus 21/05/04/2014 verander van alle_sub =  alle_sub - Val(alle_risiko.Premie)
                dblalle_sub = Form1.dblalle_sub
                dblalle_sub = dblalle_sub + Val(Me.Premie.Text)
                'Kobus 20/05/2014 comment out
                'doen_subtotaal()
                'Kobus 31/03/2014 voegby
                Form1.populate_dgvPoldata1AlleRisikoItems()
                LogAlterations()
                UpdateAllerisk()
                BFUpdateItemsSubTotals(glbPolicyNumber)
                HerBereken_Premie()
                Me.Close()
            Else
                blnDontClear = False
                Me.Close()
            End If
        Else
            dblalle_sub = dblalle_sub - Val(alle_risiko.Premie)
            dblalle_sub = dblalle_sub + Val(Me.Premie.Text)
            ValidateForm()
            LogAlterations()
            InsertIntoAllerisk()
            Me.Close()
        End If

        
        intRy = Form1.dgvPoldata1AlleRisikoItems.RowCount
        Form1.populate_dgvPoldata1AlleRisikoItems()

    End Sub
    Private Sub UpdateglobalAlleRisikoSub()
        'Kobus 26/03/2014 skep om die opdatering van inligting op Form1 te doen
        Dim paramM() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar)}
        paramM(0).Value = glbPolicyNumber

        Dim readerM As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchVoertuieForPremie", paramM)
        dblMotor_sub = 0
        Do While readerM.Read
            dblMotor_sub = dblMotor_sub + Val(readerM("Premie"))
        Loop
        Dim paramH() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar)}
        paramH(0).Value = glbPolicyNumber

        Dim readerH As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchHuisByPolisno", paramH)
        dblHuise_Sub = 0
        Do While readerH.Read
            dblHuise_Sub = dblHuise_Sub + Val(readerH("Premie_he")) + Val(readerH("Premie_hb")) + Val(readerH("toe_premie")) + Val(readerH("eem_premie"))
        Loop
        Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar)}
        param(0).Value = glbPolicyNumber

        Dim readers As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAlleriskByPolisno", param)
        dblalle_sub = 0
        Do While readers.Read
            dblalle_sub = dblalle_sub + readers("Premie")
        Loop
    End Sub


    Private Sub btnVoegby_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnVoegby.Click, btnVoegby.Click

        'Kobus 23/10/2013 voegby
        ValidateForm()
        If blnValidateForm = False Then
            Exit Sub
        End If
        If blnInformationChanged = True Then
            blnInformationChanged = False
            'Exit Sub
        End If
        'Kobus 21/05/04/2014 verander van alle_sub =  alle_sub - Val(alle_risiko.Premie)
        dblalle_sub = Form1.dblalle_sub
        dblalle_sub = dblalle_sub + Val(Me.Premie.Text)


        'Kobus 31/03/2014 comment out
        'doen_subtotaal()

        LogAlterations()
        InsertIntoAllerisk()
        'Kobus 31/03/2014 voegby
        BFUpdateItemsSubTotals(glbPolicyNumber)
        HerBereken_Premie()
        Form1.populate_dgvPoldata1AlleRisikoItems()
        Me.Close()
       
    End Sub

    Sub InsertIntoAllerisk()
        ''Kobus 17/10/2013 voegby
        'LogAlterations()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim param() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                               New SqlParameter("@beskryf", SqlDbType.NVarChar), _
                                               New SqlParameter("@DEKKING", SqlDbType.Money), _
                                               New SqlParameter("@PREMIE", SqlDbType.Money), _
                                               New SqlParameter("@arnplaat", SqlDbType.NVarChar), _
                                               New SqlParameter("@selkontrakmet", SqlDbType.NVarChar), _
                                               New SqlParameter("@itemnr", SqlDbType.SmallInt), _
                                               New SqlParameter("@selnommer", SqlDbType.NVarChar), _
                                               New SqlParameter("@seldatumaangekoop", SqlDbType.NVarChar), _
                                               New SqlParameter("@SERIENOMMER", SqlDbType.NVarChar), _
                                               New SqlParameter("@Tipe2", SqlDbType.SmallInt), _
                                               New SqlParameter("@Beskrywing", SqlDbType.NVarChar), _
                                               New SqlParameter("@pkAllerisk", SqlDbType.Int), _
                                               New SqlParameter("@Cancelled", SqlDbType.Bit)}
                'Andriette 15/08/2013 verander na die global polisnommer
                'param(0).Value = Form1.POLISNO.Text
                param(0).Value = glbPolicyNumber
                param(1).Value = Beskruiwing.Text
                'Kobus 10/10/2013 verander van Dekking.Text na 
                param(2).Value = CInt(Dekking.Text)
                param(3).Value = Premie.Text
                param(4).Value = arnplaat.Text
                param(5).Value = selkontrakmet.Text

                alleriskvolgitem = alleriskvolgitem + 1
                param(6).Value = alleriskvolgitem


                param(7).Value = Selnommer.Text
                param(8).Value = Seldatumaangekoop.Text
                'Kobus 16/10/2013 verander van VB.Left(Serienommer.Text, 40)
                param(9).Value = Serienommer.Text
                param(10).Value = Kode.SelectedValue
                'Kobus 30/10/2013 voegby
                If Persoonl.TAAL = 1 Then
                    FetchAll_Tipe2()
                    param(11).Value = strEistipe
                Else
                    param(11).Value = Trim(Kode.Text)
                End If
                param(12).Value = DBNull.Value
                param(13).Value = False

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.InsertIntoAllerisk", param)
                conn.Close()
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Sub UpdateAllerisk()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim param() As SqlParameter = {New SqlParameter("@pkAllerisk", SqlDbType.Int), _
                                               New SqlParameter("@beskryf", SqlDbType.NVarChar), _
                                               New SqlParameter("@DEKKING", SqlDbType.Money), _
                                               New SqlParameter("@PREMIE", SqlDbType.Money), _
                                               New SqlParameter("@arnplaat", SqlDbType.NVarChar), _
                                               New SqlParameter("@selkontrakmet", SqlDbType.NVarChar), _
                                               New SqlParameter("@selnommer", SqlDbType.NVarChar), _
                                               New SqlParameter("@seldatumaangekoop", SqlDbType.NVarChar), _
                                               New SqlParameter("@SERIENOMMER", SqlDbType.NVarChar), _
                                               New SqlParameter("@Tipe2", SqlDbType.NVarChar), _
                                               New SqlParameter("@Beskrywing", SqlDbType.NVarChar)}

                'Kobus 21/10/2013 verander van param(0).Value = Form1.Grid3.SelectedRows(0).Cells(0).Value NA
                param(0).Value = pkAllerisk
                param(1).Value = Beskruiwing.Text

                'If adek Then
                'Kobus 11/10/2013 verander van  param(2).Value = Dekking.Text na
                param(2).Value = Format(Val(Dekking.Text), "########")

                'Kobus 11/10/2013 verander van param(3).Value = Premie.Text
                param(3).Value = Format(Val(Premie.Text), "########0.00")
                param(4).Value = arnplaat.Text
                param(5).Value = selkontrakmet.Text
                param(6).Value = Selnommer.Text
                param(7).Value = Seldatumaangekoop.Text
                'Kobus 16/10/2013 verander van param(8).Value = Mid(Serienommer.Text, 40)
                param(8).Value = Serienommer.Text
                'Kobus 16/10/2013 verander van Alle_tipe2.Eistipekode na Kode.SelectedValue
                param(9).Value = Kode.SelectedValue

                If Kode.Text = "Selfone" Then
                    lblCellContract.Visible = True
                    lblCellNumber.Visible = True
                    lblDatePurchased.Visible = True
                    selkontrakmet.Visible = True
                    Selnommer.Visible = True
                    Seldatumaangekoop.Visible = True
                End If
                'Kobus 30/10/2013 voegby
                If Persoonl.TAAL = 1 Then
                    FetchAll_Tipe2()
                    param(10).Value = strEistipe
                Else
                    param(10).Value = Trim(Kode.Text)
                End If

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "poldata5.UpdateAlleriskDetails", param)

                'Linkie 03/07/2012 
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar)}
                params(0).Value = alle_risiko.POLISNO

                If params(0).Value = Nothing Then
                    Exit Sub
                Else
                    params(0).Value = alle_risiko.POLISNO
                End If
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAlleriskByPolisno", params)
                dblalle_sub = 0
                Do While reader.Read
                    dblalle_sub = dblalle_sub + reader("Premie")
                Loop
                conn.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub Beskruiwing_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Beskruiwing.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case 34, 39
                ' Anything else is unacceptable, and should be ignored
                MsgBox("The characters '' and "" "" can not be used.", MsgBoxStyle.Information)
                KeyAscii = 0
            Case Else
                ' These are acceptable keystrokes
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click

edup:

    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        'Kobus 14/05/2014 voegby
        If Trim(Beskruiwing.Text) = "" Then
            blnCancel = True
            blnInformationChanged = False
            Me.Close()
            Exit Sub
        End If

        'Kobus 14/10/2013 comment alles uit en voegby
        blnCancel = True
        'Kobus 16/2013 voegby
        'intCurrentIndex = Me.Kode.SelectedIndex
        TestForChange()
        If blnInformationChanged = False Then
            Me.Close()
            Exit Sub
        Else
            Form1.populate_dgvPoldata1AlleRisikoItems()
        End If
        
        BFUpdateItemsSubTotals(glbPolicyNumber)
        HerBereken_Premie()
        'Kobus 26/03/2014 voegby en uncomment

    End Sub

    Private Sub Dekking_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Dekking.TextChanged
        'Kobus 25/10/2013 voegby
        If Me.Kode.SelectedValue = 299 Then
            bln2000plus = True
        End If
        If blnediting Then
            ' blnAlleRisikoDekking = True 'Andriette 13/08/2014 die word nerens meer getoets nie
            blnInformationChanged = True
            blnDontClear = True
        End If
    End Sub

    Private Sub Dekking_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Dekking.Leave
        If Dekking.Text = "" Then
            Me.Dekking.Text = "0"
            'Else
            '    If alle_risiko.DEKKING <> Me.Dekking.Text Then
            '        blnInformationChanged = True
            '    End If
        End If
        If (Not (IsNumeric(Dekking.Text))) Then
            MsgBox("All risk coverage value must be numeric!", 48, "Error!")
            Dekking.Focus()
            Exit Sub
        End If
        blnInformationChanged = True

    End Sub
    Private Sub A_Risiko_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        'Dim sSql As Object
        'Andriette 15/08/2013 verander die polisnommer na die global polisnommer
        '  Me.Text = My.Application.Info.Title & " - All risk information - " & Form1.TITEL.Text & " " & Form1.VOORL.Text & " " & Form1.VERSEKERDE.Text & " (" & Form1.POLISNO.Text & ")"
        'Kobus 11/10/2013 verander & " - All risk information - " &
        Me.Text = "        All risk detail - " & Form1.TITEL.Text & " " & Form1.VOORL.Text & " " & Form1.VERSEKERDE.Text & " (" & glbPolicyNumber & ")"
        'Alle_Activ()
        If Not blnediting And blnDontClear = True Then
            Kode.Enabled = True
            'If Me.Beskruiwing.Text = " " Then
            '    Me.Kode.SelectedIndex = -1
            'End If
            Exit Sub
        End If
        'Kobus 21/10/2013 voegby
        If Not blnediting Then
            Kode.Enabled = True
            If Me.Beskruiwing.Text = " " Then
                Me.Kode.SelectedIndex = -1
            End If
        End If

        If blnFirst = True Then
            Kode.Enabled = True
            Kode.Focus()
            Exit Sub
        End If
       
        'Kobus 11/10/2013 voetgby
        If Persoonl.GEKANS = True Then
            btnRedigeer.Enabled = False
        Else
            btnRedigeer.Enabled = True
        End If
        'Kode.Items.Clear()
2:

        If blnediting Then

            If blnDontClear = False Then
                blnFirst = False
                Using conn As SqlConnection = SqlHelper.GetConnection

                    Dim params As New SqlParameter("@pkAllerisk", SqlDbType.Int)

                    params.Value = Form1.dgvPoldata1AlleRisikoItems.SelectedRows(0).Cells(0).Value

                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAlleriskByPrimaryKey", params)

                    Do While reader.Read

                        Me.Beskruiwing.Text = reader("beskryf")
                        'Kobus 11/10/2013 verander van reader("DEKKING")
                        Me.Dekking.Text = Format(Val(reader("DEKKING")), "##########")
                        'Kobus 11/10/2013 verander van Me.Premie.Text = reader("PREMIE")
                        Me.Premie.Text = Format(Val(reader("PREMIE")), "########0.00")
                        Me.arnplaat.Text = reader("arnplaat")
                        Me.Serienommer.Text = reader("SERIENOMMER")
                        'Kobus 21/05/04/2014 verander van Me.Kode.Text = reader("BESKRYWING")
                        Me.Kode.Text = IIf(IsDBNull(reader("BESKRYWING")), " ", reader("BESKRYWING"))
                        Me.selkontrakmet.Text = IIf(IsDBNull(reader("selkontrakmet")), " ", reader("selkontrakmet"))
                        Me.Selnommer.Text = IIf(IsDBNull(reader("selnommer")), " ", reader("selnommer"))
                        'Kobus 16/10/2013 verander van Me.Seldatumaangekoop.Text = IIf(IsDBNull(reader("seldatumaangekoop")), " ", reader("selnommer"))
                        Me.Seldatumaangekoop.Text = IIf(IsDBNull(reader("seldatumaangekoop")), " ", reader("seldatumaangekoop"))
                    Loop
                    conn.Close()
                End Using

                'Kobus 21/10/2013 voegby
                If Me.Beskruiwing.Text = "Ongespesifiseerd" Then
                    Me.Kode.SelectedIndex = 28
                End If
            Else
                'Me.Kode.SelectedValue = intCurrentIndex
                Me.Beskruiwing.Focus()
                Exit Sub
            End If
            'Insert temp
            'Kobus 15/10/2013 voegby
            If blnFirst = False Then
                Alle_tipe2 = FetchAlle_Tipe2()
                Kode.Enabled = False
                Me.Kode.Text = alle_risiko.Beskrywing
            End If
            'Kobus 16/10/2013 voegby
            If Not Alle_tipe2.NoMatch Then
                Kode.Enabled = True
                Me.Kode.Text = alle_risiko.Beskrywing
                If Kode.SelectedValue = 250 Then
                    lblRegNumber.Visible = True
                    lblWhereApplicable.Visible = True
                    Me.arnplaat.Enabled = True
                End If
                If Alle_tipe2.cancelled = False Then
                    Me.Kode.Text = Alle_tipe2.Eistipe
                Else
                    blnFirst = True
                    'Kobus 16/10/2013 voegby
                    blnDontClear = True
                    Kode.Text = ""

                    'Kobus 15/10/2013 verander van 
                    'MsgBox("The All Risk type is no longer in use, a different type must be selected.", MsgBoxStyle.Information)
                    MsgBox("The All Risk type is not in use anymore, another type must be selected.", MsgBoxStyle.Information)
                    Kode.SelectedIndex = -1
                    'Kode.SelectedValue = 212
                    blnDontClear = True
                    Me.Kode.Enabled = True
                    blnInformationChanged = True
                    Me.Kode.Focus()
                    Exit Sub
                End If 'If rsAr("cancelled") = False Then
                Kode.Enabled = False
            Else
                MsgBox("This item type is not found in the database, please contact the IT department.", MsgBoxStyle.Information)
            End If 'If Not (rsAr.EOF) Then
        Else
            'Kobus 11/10/2013 voeg condisie - If blnDontClear = True Then - by
            'If blnDontClear = False Then
            blnDontClear = True
            'End If
            'clearNow()
        End If ' editing

        Me.Beskruiwing.Focus()
        'Kobus 11/10/2013 verander na
        If Gebruiker.titel = "Besigtig" Then
            Me.btnRedigeer.Enabled = False
            Me.btnVoegby.Enabled = False
        End If
    End Sub

    Private Sub A_Risiko_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Kobus 24/10/2013 voegby
        If blnValidateForm = False Then
            Exit Sub
        End If
        blnFirst = False
        blnDontClear = False
        Me.Close()
    End Sub

    Private Sub A_Risiko_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Kobus 16/10/2013 voegby

        'Kobus 14/10/2013 voegby
        If blnCancel = False Then
            'proceed
        Else

            If blnInformationChanged = False Then
                e.Cancel = False
                Exit Sub
            Else
                If MsgBox("Are you sure you want to cancel your changes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    e.Cancel = False
                    blnInformationChanged = False
                    'Kobus 29/10/2013 voegby
                    clearNow()
                Else
                    e.Cancel = True
                    blnDontClear = False
                    'intCurrentIndex = Me.Kode.SelectedIndex
                    'Exit Sub
                End If
            End If
        End If

    End Sub


    Private Sub A_Risiko_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        
        clearNow()
        Try

            'Kobus 11/10/2013 voeg kondisie by
            If blnediting Then
                Kode.Enabled = False
                blnInformationChanged = False
            End If

            'Kobus 11/10/2013 voetgby
            If Persoonl.GEKANS = True Then
                btnRedigeer.Enabled = False
            Else
                btnRedigeer.Enabled = True
            End If

            'Kobus 11/10/2013 verander If Gebtitel = "Besigtig" Then na 
            If Gebruiker.titel = "Besigtig" Then
                Me.btnRedigeer.Enabled = False
                Me.btnVoegby.Enabled = False
            End If

            Kode.DataSource = Nothing


            If Persoonl.TAAL = 0 Then
                'Kobus 21/10/2013 verander van
                'Andriette 22/10/12013
                '  populatecomboAllerisk("Eistipe")
                Kode.DataSource = FillCombo("poldata5.FetchAlle_tipe_PopulateCombo", "pk", "Descr", , , "@type", , SqlDbType.NVarChar, "Eistipe")
                '"@type", SqlDbType.NVarChar
            Else
                'Andriette 22/10/12013
                'populatecomboAllerisk("EistipeEngels")
                Kode.DataSource = FillCombo("poldata5.FetchAlle_tipe_PopulateCombo", "pk", "Descr", , , "@type", , SqlDbType.NVarChar, "EistipeEngels")
            End If
            Kode.ValueMember = "ComboBoxID"
            Kode.DisplayMember = "ComboBoxName"
            '    Kode.DataSource = FillCombo("poldata5.FetchAlle_tipe_PopulateCombo", "", "Eistipe", "", "")
            'Else

            '    Kode.DataSource = FillCombo("poldata5.FetchAlle_tipe_PopulateCombo", "0", "EistipeEngels", "", "")

            'End If
            'Kode.DisplayMember = "ComboBoxName"


            If blnediting Then
                Alle_tipe2 = FetchAlle_Tipe2()
                'Kobus test

                ' strEistipe = Alle_tipe2.Eistipe

                intCurrentIndex = Kode.SelectedValue
                'intCurrentIndex = Me.Kode.SelectedIndex

                Using conn As SqlConnection = SqlHelper.GetConnection

                    Dim params As New SqlParameter("@pkAllerisk", SqlDbType.Int)

                    params.Value = Form1.dgvPoldata1AlleRisikoItems.SelectedRows(0).Cells(0).Value

                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAlleriskByPrimaryKey", params)

                    If reader.Read Then
                        Me.Beskruiwing.Text = reader("beskryf")
                        'KOBUS 15/10/2013 VOEGBY
                        Me.Serienommer.Text = reader("SERIENOMMER")
                        strSerienommer = Me.Serienommer.Text
                        pkAllerisk = reader("pkAllerisk")
                        Dim intBeskryf As Integer = reader("tipe2")
                        Me.Kode.SelectedValue = intBeskryf
                        'Kobus 30/10/2013 verander van If reader("Beskrywing") <> "Selfone" Or reader("Beskrywing") <> "Mobile phones" Then
                        If reader("tipe2") = 265 Then
                            Me.selkontrakmet.Text = reader("selkontrakmet")
                            Me.Selnommer.Text = reader("Selnommer")
                            Me.Seldatumaangekoop.Text = reader("Seldatumaangekoop")
                        End If
                        If reader("tipe2") = 250 Then
                            Me.lblRegNumber.Enabled = True
                            Me.lblWhereApplicable.Enabled = True
                            Me.arnplaat.Enabled = True
                        Else
                            Me.lblRegNumber.Enabled = False
                            Me.lblWhereApplicable.Enabled = False
                            Me.arnplaat.Enabled = False
                        End If

                    Else
                        MsgBox("This item type is not found in the database, please contact the IT department.", MsgBoxStyle.Information)
                    End If
                    conn.Close()
                End Using
            Else
                clearNow()
                alle_risiko = New ALLERISKEntity
                alle_risiko = FetchAlleriskbyPolisNo()
            End If
            'Kobus 14/10/2013 voegby 
            blnInformationChanged = False
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Sub populatecomboAllerisk(ByVal type As String)
        Try

            Dim list As List(Of AlleriskDropdownEntity) = New List(Of AlleriskDropdownEntity)
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params As New SqlParameter("@type", SqlDbType.NVarChar)
                params.Value = type

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAlle_tipe_PopulateCombo", params)

                Do While reader.Read

                    Dim item As AlleriskDropdownEntity = New AlleriskDropdownEntity()

                    item.Descr = reader("Descr")
                    item.PK = reader("PK")
                    list.Add(item)
                Loop
                conn.Close()
            End Using

            Kode.ValueMember = "pk"
            Kode.DisplayMember = "Descr"
            Kode.DataSource = list

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub Kode_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Kode.SelectedIndexChanged

        'Vir 'n selfoon, vertoon  nog ekstra velde om in te vul
        'Kobus 21/10/2013 voegby
        Dim strFoon As String
        If Persoonl.TAAL = 0 Then
            strFoon = "Selfone"
        Else
            strFoon = "Mobile phones"
        End If
        If Kode.Text <> strFoon Then
            lblCellContract.Enabled = False
            lblCellNumber.Enabled = False
            lblDatePurchased.Enabled = False
            selkontrakmet.Enabled = False
            Selnommer.Enabled = False
            Seldatumaangekoop.Enabled = False
            lblDMY.Enabled = False
            Frame1.Enabled = False
            'Kobus 15/10/2013 voegby
            blnInformationChanged = True
            'blnFirst = False
        Else
            lblCellContract.Enabled = True
            lblCellNumber.Enabled = True
            lblDatePurchased.Enabled = True
            selkontrakmet.Enabled = True
            Selnommer.Enabled = True
            Seldatumaangekoop.Enabled = True
            lblDMY.Enabled = True
            Frame1.Enabled = True
            blnInformationChanged = True
        End If

        If Me.Kode.Text = "Motorradio's & klanktoerusting" Or Me.Kode.Text = "Car radio's & sound equipment" Then
            lblRegNumber.Enabled = True
            lblWhereApplicable.Enabled = True
            Me.arnplaat.Enabled = True
        Else
            lblRegNumber.Enabled = False
            lblWhereApplicable.Enabled = False
            Me.arnplaat.Enabled = False
        End If
    End Sub

    Private Sub Premie_Leave(sender As Object, e As System.EventArgs) Handles Premie.Leave
        'Kobus 28/10/2013 voegby
        If Me.Premie.Text = "" Then
            Me.Premie.Text = "0.00"
        End If

        If (Not (IsNumeric(Premie.Text))) Then
            MsgBox("All risk premium must be numeric!", 48, "Error!")
            Premie.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub Serienommer_Enter(sender As Object, e As System.EventArgs) Handles Serienommer.Enter
        If Not blnLoading Then
            strSerienommer = Serienommer.Text
        End If
    End Sub

    Private Sub Serienommer_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Serienommer.KeyPress

        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case 34, 39
                ' Anything else is unacceptable, and should be ignored
                MsgBox("The characters '' and "" "" can not be used.", MsgBoxStyle.Information)
                KeyAscii = 0
            Case Else
                ' These are acceptable keystrokes
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    'Kobus 16/2013 skep Sub
    Private Sub TestForChange()
        If pkAllerisk = 0 Then
        Else
            alle_risiko = FetchAllriskByPrimarykey()

            If alle_risiko.beskryf <> Beskruiwing.Text Then
                blnInformationChanged = True
            ElseIf Dekking.Text = "" Then
                Dekking.Text = 0
            ElseIf alle_risiko.DEKKING <> Dekking.Text Then
                blnInformationChanged = True
            ElseIf Premie.Text = "" Then
                Premie.Text = "0.00"
            ElseIf Me.Premie.Text = "0.00" And Me.Kode.SelectedValue <> "299" Then
                blnInformationChanged = True
            ElseIf alle_risiko.Premie <> Premie.Text Then
                blnInformationChanged = True
            ElseIf alle_risiko.arnplaat <> arnplaat.Text Then
                blnInformationChanged = True
                'Kobus 30/10/2013 wysig vam Beskrywing na tipe2 - moet tabel wysig maar nie geskiedenis
            ElseIf alle_risiko.Tipe2 <> Me.Kode.SelectedValue Then
                blnInformationChanged = True
            ElseIf alle_risiko.selkontrakmet <> selkontrakmet.Text Then
                blnInformationChanged = True
            ElseIf alle_risiko.selnommer <> Selnommer.Text Then
                blnInformationChanged = True
            ElseIf alle_risiko.seldatumaangekoop <> Seldatumaangekoop.Text Then
                blnInformationChanged = True
            ElseIf strSerienommer <> Serienommer.Text Then
                blnInformationChanged = True
            Else
                blnInformationChanged = False
            End If
        End If
    End Sub
    Private Sub LogAlterations()
        'Kobus 16/10/2013 skep sub
        'Kobus 28/03/2014 voegby
        If blnPol_Byvoeg Or blnByvoeg Then
        Else
            If Not blnediting Then
                If Persoonl.TAAL = 0 Then
                    BESKRYWING = " Besk as (" & Beskruiwing.Text & ") Premie (" & Format(Val(Premie.Text), "########0.00") & ") Waarde (" & Format(Val(Dekking.Text), "##########") & ") Tipe (" & Me.Kode.Text & ")"
                    UpdateWysig((21), BESKRYWING)
                Else
                    BESKRYWING = " Desc as (" & Beskruiwing.Text & ") Premium (" & Format(Val(Premie.Text), "########0.00") & ") Value (" & Format(Val(Dekking.Text), "##########") & ") type (" & Me.Kode.Text & ")"
                    UpdateWysig((21), BESKRYWING)
                End If
            Else

                'Beskruiwing
                'Kobus 17/10/2013 voegby
                'Kobus 28/03/2014 voegby And Not (pol_byvoeg Or Byvoeg)
                If Trim(alle_risiko.beskryf) <> Trim(Me.Beskruiwing.Text) And Not (blnPol_Byvoeg Or blnByvoeg) Then
                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = " wysig vanaf (" & alle_risiko.beskryf & ") na (" & Me.Beskruiwing.Text & ") Tipe (" & Me.Kode.Text & ")"
                    Else
                        BESKRYWING = " change from (" & alle_risiko.beskryf & ") to (" & Me.Beskruiwing.Text & ") Type (" & Me.Kode.Text & ")"
                    End If
                    UpdateWysig((201), BESKRYWING)
                End If

                'Motor Registrasienommer
                'Kobus 17/10/2013 voegby
                'Kobus 28/03/2014 voegby And Not (pol_byvoeg Or Byvoeg)
                If Trim(alle_risiko.arnplaat) <> Trim(Me.arnplaat.Text) And Not (blnPol_Byvoeg Or blnByvoeg) Then
                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = " wysig vanaf (" & alle_risiko.arnplaat & ") na (" & Me.arnplaat.Text & ") Tipe (" & Me.Beskruiwing.Text & ")"
                    Else
                        BESKRYWING = " change from (" & alle_risiko.arnplaat & ") to (" & Me.arnplaat.Text & ") Type (" & Me.Beskruiwing.Text & ")"
                    End If
                    UpdateWysig((202), BESKRYWING)
                End If
                'Kobus 18/11/2013 verander al die gevalle wat laaste inskrywing Tipe was, na 'Beskruiwing'
                'serienommer
                'Kobus 17/10/2013 voegby
                'Kobus 28/03/2014 voegby And Not (pol_byvoeg Or Byvoeg)
                If Trim(strSerienommer) <> Trim(Me.Serienommer.Text) And Not (blnPol_Byvoeg Or blnByvoeg) Then
                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = " wysig vanaf (" & strSerienommer & ") na (" & Me.Serienommer.Text & ") Tipe (" & Me.Beskruiwing.Text & ")"
                    Else
                        BESKRYWING = " change from (" & strSerienommer & ") to (" & Me.Serienommer.Text & ") Type (" & Me.Beskruiwing.Text & ")"
                    End If
                    UpdateWysig((203), BESKRYWING)
                End If

                'Waarde
                'Kobus 28/10/2013 voegby
                If Me.Dekking.Text = "" Then
                    Me.Dekking.Text = "0.00"
                End If
                'Kobus 17/10/2013 voegby
                'Kobus 28/03/2014 voegby And Not (pol_byvoeg Or Byvoeg)
                If Trim(alle_risiko.DEKKING) <> Trim(Me.Dekking.Text) And Not (blnPol_Byvoeg Or blnByvoeg) Then
                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = " wysig vanaf (" & Trim(alle_risiko.DEKKING) & ") na (" & Trim(Me.Dekking.Text) & ") Besk: (" & Me.Beskruiwing.Text & ")"
                    Else
                        BESKRYWING = " change from (" & Trim(alle_risiko.DEKKING) & ") to (" & Trim(Me.Dekking.Text) & ") Desc: (" & Me.Beskruiwing.Text & ")"
                    End If
                    UpdateWysig((18), BESKRYWING)
                End If

                'Premie
                'Kobus 28/10/2013 voegby
                If Me.Premie.Text = "" Then
                    Me.Premie.Text = "0.00"
                End If
                'Kobus 17/10/2013 voegby
                'Kobus 28/03/2014 voegby And Not (pol_byvoeg Or Byvoeg)
                If alle_risiko.Premie <> Me.Premie.Text And Not (blnPol_Byvoeg Or blnByvoeg) Then
                    'Kobus 21/10/2013 verander van BESKRYWING = " wysig vanaf (" & Trim(alle_risiko.Premie) & ") na (" & Trim(Me.Premie.Text) & ") op " & Me.Kode.Text
                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = " wysig vanaf (" & Format(Val(alle_risiko.Premie), "########0.00") & ") na (" & Format(Val(Me.Premie.Text), "########0.00") & ") Besk: (" & Me.Beskruiwing.Text & ")"
                    Else
                        BESKRYWING = " change from (" & Format(Val(alle_risiko.Premie), "########0.00") & ") to (" & Format(Val(Me.Premie.Text), "########0.00") & ") Desc: (" & Me.Beskruiwing.Text & ")"
                    End If
                    UpdateWysig((19), BESKRYWING)
                End If

                'Kobus 16/10/2013 skuif van Updateallerisk na nuwe sub LogAlterations
                'selkontrak
                'Kobus 28/03/2014 voegby And Not (pol_byvoeg Or Byvoeg)
                If alle_risiko.selkontrakmet <> selkontrakmet.Text And Not (blnPol_Byvoeg Or blnByvoeg) Then
                    If Persoonl.TAAL = 0 Then
                        'Kobus 16/10/2013 wysig vanaf BESKRYWING = " wysig vanaf (" + (alle_risiko.selkontrakmet) + ") na (" + (selkontrakmet).Text + ") "
                        BESKRYWING = " wysig vanaf (" & alle_risiko.selkontrakmet & ") na (" & Me.selkontrakmet.Text & ") Besk: (" & Me.Beskruiwing.Text & ")"
                    Else
                        'BESKRYWING = " change from (" + (alle_risiko.selkontrakmet) + ") to (" + (selkontrakmet).Text + ") "
                        BESKRYWING = " change from (" & alle_risiko.selkontrakmet & ") to (" & Me.selkontrakmet.Text & ") Desc: (" & Me.Beskruiwing.Text & ")"
                    End If
                    'Kobus 16/10/2013 comment out
                    'alle_risiko.selkontrakmet = Trim(selkontrakmet.Text)
                    UpdateWysig((130), BESKRYWING)
                End If

                'selnommer
                'Kobus 28/03/2014 voegby And Not (pol_byvoeg Or Byvoeg)
                If alle_risiko.selnommer <> Selnommer.Text And Not (blnPol_Byvoeg Or blnByvoeg) Then
                    If Persoonl.TAAL = 0 Then
                        'Kobus 16/10/2013 wysig vanaf BESKRYWING = " wysig vanaf (" + (alle_risiko.selnommer) + ") na (" + (Selnommer).Text + ")"
                        BESKRYWING = " wysig vanaf (" & alle_risiko.selnommer & ") na (" & Me.Selnommer.Text & ") Besk: (" & Me.Beskruiwing.Text & ")"
                    Else
                        'BESKRYWING = " change from (" + (alle_risiko.selnommer) + ") to (" + (Selnommer).Text + ")"
                        BESKRYWING = " change from (" & alle_risiko.selnommer & ") to (" & Me.Selnommer.Text & ") Desc: (" & Me.Beskruiwing.Text & ")"
                    End If
                    'Kobus 16/10/2013 comment out
                    'alle_risiko.selnommer = Trim(Selnommer.Text)
                    UpdateWysig((131), BESKRYWING)

                End If

                'seldatum
                'Kobus 28/03/2014 voegby And Not (pol_byvoeg Or Byvoeg)
                If alle_risiko.seldatumaangekoop <> Seldatumaangekoop.Text And Not (blnPol_Byvoeg Or blnByvoeg) Then
                    If Persoonl.TAAL = 0 Then
                        'Kobus 16/10/2013 wysig vanaf BESKRYWING = " wysig vanaf (" + (alle_risiko.seldatumaangekoop) + ") na (" + (Seldatumaangekoop).Text + ")"
                        BESKRYWING = " wysig vanaf (" & alle_risiko.seldatumaangekoop & ") na (" & Me.Seldatumaangekoop.Text & ") Besk: (" & Me.Beskruiwing.Text & ")"
                    Else
                        'BESKRYWING = " change from (" + (alle_risiko.seldatumaangekoop) + ") to (" + (Seldatumaangekoop).Text + ")"
                        BESKRYWING = " change from (" & alle_risiko.seldatumaangekoop & ") to (" & Me.Seldatumaangekoop.Text & ") Desc: (" & Me.Beskruiwing.Text & ")"
                    End If
                    'Kobus 16/10/2013 comment out
                    'alle_risiko.seldatumaangekoop = Trim(Seldatumaangekoop.Text)
                    UpdateWysig((132), BESKRYWING)
                End If
            End If
        End If
    End Sub
    Private Sub clearNow()
        'Kobus 18/10/2013 skep nuwe sub
        Me.Beskruiwing.Text = " "
        'Me.Kode.SelectedIndex = -1
        Me.Kode.Text = ""
        Me.Dekking.Text = "0"
        Me.Premie.Text = "0.00"
        Me.Kode.Enabled = True
        Me.Serienommer.Text = ""
        Me.selkontrakmet.Text = " "
        Me.Selnommer.Text = " "
        Me.Seldatumaangekoop.Text = " "
        Me.arnplaat.Text = ""
        'Kobus 18/10/2013 transfer up to (arnplaat.Enabled = True) from load event
        'Kobus 15/10/2013 voegby
        strSerienommer = ""
        'Kobus 16/10/2013 voegby
        Kode.Enabled = True
        'Kobus 17/10/2013 voegby
        blnCancel = False
        ''Kobus 18/102013 voegby
        'If Not editing Then
        '    blnDontClear = True
        'Else
        '    blnDontClear = False
        'End If
        lblRegNumber.Enabled = False
        lblWhereApplicable.Enabled = False
        Me.arnplaat.Enabled = False
        blnValidateForm = True
        blnDontClear = False
    End Sub
    Private Sub ValidateForm()
        'Kobus 18/10/2013 skep sub en skuif validation events soos op 18/10/2013 vanaf btn arredigeer na hierdie sub

        'Beskrywing
        If Beskruiwing.Text = " " Or Beskruiwing.Text = "" Then
            MsgBox("You must provide a description!", 48, "Error!")
            blnDontClear = True
            blnValidateForm = False
            blnInformationChanged = True
            Beskruiwing.Focus()
            Exit Sub
        End If

        'Dekking
        If Val(Dekking.Text) = 0 Then
            'Kobus 18/10/2013 verander boodskap van "You must have a value provided cover!"
            'Kobus 24/10/2013 verander boodskap van MsgBox("You must provide a cover value!", 48, "Error!") na
            MsgBox("Value must be numeric!", 48, "Error!")
            'Dekking.Text = Val(0)
            blnInformationChanged = True
            blnDontClear = True
            'Kobus 28/10/2013 voegby
            blnValidateForm = False
            blnInformationChanged = True
            Dekking.Focus()
            Exit Sub
        End If

        'Dekking by ongespesifiseerd
        'Kobus 28/10/2013 voegby
        If blnFirst = True Then
        Else
            If alle_risiko.DEKKING <> Val(Dekking.Text) And Me.Kode.SelectedValue = 299 And Val(Me.Premie.Text) = 0 Then
                MsgBox("The value has changed, make sure the premium is correct!", 48, "Error!")
                'Dekking.Text = Val(0)
                blnInformationChanged = True
                blnDontClear = True
                'Kobus 28/10/2013 voegby
                blnValidateForm = False
                blnInformationChanged = True
                blnFirst = True
                Dekking.Focus()
                Exit Sub
            End If
        End If

        'Beskruiwing dieselfde
        'Kobus 24/10/2013 voeg kondisie by
        If blnediting Then
        Else
            If alle_risiko.POLISNO = Persoonl.POLISNO Then
                If UCase(Trim(Beskruiwing.Text)) = UCase(Trim(alle_risiko.beskryf)) Then
                    MsgBox("There is already an all risk with such a description for this policy ...")
                    blnDontClear = True
                    'Kobus 28/10/2013 voegby
                    blnValidateForm = False
                    blnInformationChanged = True
                    Beskruiwing.Focus()
                    Exit Sub
                End If
            End If
        End If

        'Premie
        'Kobus 18/10/2013 en 23/10/2013 skep
        If Val(Premie.Text) = 0 And Kode.SelectedValue = 299 Then
            'Kobus 28/10/2013 comment out
            'MsgBox("The All risk premium amount is null!", 48, "Warning!")
        Else
            If Val(Premie.Text) = 0 And Kode.SelectedValue <> 299 Then
                MsgBox("All risk premium must be numeric!", 48, "Warning!")
                Premie.Text = "0.00"
                'Kobus 28/10/2013 voegby
                blnValidateForm = False
                blnInformationChanged = True
                Premie.Focus()
                Exit Sub
            End If
        End If
        'Kobus 15/10/2013 verander van If Kode.SelectedIndex = -1 Then
        If Kode.SelectedIndex = -1 Then
            'Kobus 18/10/2013 verander na (11.4)
            MsgBox("You must provide an All risk type.", 48, "Error!")
            'Kobus 28/10/2013 voegby
            blnValidateForm = False
            blnInformationChanged = True
            Kode.Focus()
            Exit Sub
        End If

        'Toets vir motorradio
        If Me.arnplaat.Text = "" And Kode.SelectedValue = 250 Then
            If (MsgBox("If the insured item is a car radio, the car registration number must also be completed.", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok) Then
                blnDontClear = True
                blnFirst = True
                Me.arnplaat.Enabled = True
                Me.lblWhereApplicable.Enabled = True
                Me.lblRegNumber.Enabled = True
                blnInformationChanged = True
                'Kobus 28/10/2013 voegby
                blnValidateForm = False
                Me.arnplaat.Focus()
                Exit Sub
            End If
        End If
        blnValidateForm = True
    End Sub

    'Kobus 29/10/2013 skep nuwe function verkry van Baseform
    Private Function FetchAllriskByPrimarykey() As ALLERISKEntity
        If IsNothing(Persoonl) Then
            Return Nothing
            Exit Function
        Else
            If Persoonl.POLISNO = "" Then
                Return Nothing
                Exit Function
            End If
        End If


        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim item As ALLERISKEntity = New ALLERISKEntity()
                Dim param As New SqlParameter("@pkAllerisk", SqlDbType.Int)

                param.Value = pkAllerisk

                If param.Value = Nothing Then
                    item.NoMatch = True
                    ' Andriette 07/03/2013 Maak warning reg
                    Return Nothing
                    Exit Function
                End If

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAlleriskByPrimaryKey", param)
                'Dim item As ALLERISKEntity = New ALLERISKEntity()

                If reader.Read() Then

                    If reader("POLISNO") IsNot DBNull.Value Then
                        item.POLISNO = reader("POLISNO")
                    End If
                    'If reader("afsluitdatum") IsNot DBNull.Value Then
                    '    item.afsluitdatum = reader("afsluitdatum")
                    'End If
                    If reader("arnplaat") IsNot DBNull.Value Then
                        item.arnplaat = reader("arnplaat")
                    End If
                    If reader("beskryf") IsNot DBNull.Value Then
                        item.beskryf = reader("beskryf")
                    End If
                    If reader("Beskrywing") IsNot DBNull.Value Then
                        item.Beskrywing = reader("Beskrywing")
                    End If
                    If reader("cancelled") IsNot DBNull.Value Then
                        item.cancelled = reader("cancelled")
                    End If
                    If reader("DEKKING") IsNot DBNull.Value Then
                        item.DEKKING = reader("DEKKING")
                    End If
                    If reader("itemnr") IsNot DBNull.Value Then
                        item.itemnr = reader("itemnr")
                    End If
                    If reader("Premie") IsNot DBNull.Value Then
                        item.Premie = reader("Premie")
                    End If
                    If reader("Tipe2") IsNot DBNull.Value Then
                        item.Tipe2 = reader("Tipe2")
                    End If
                    If reader("pkAllerisk") IsNot DBNull.Value Then
                        item.pkAllerisk = reader("pkAllerisk")
                    End If

                    If reader("selkontrakmet") IsNot DBNull.Value Then
                        item.selkontrakmet = reader("selkontrakmet")
                    End If
                    If reader("selnommer") IsNot DBNull.Value Then
                        item.selnommer = reader("selnommer")
                    End If
                    If reader("seldatumaangekoop") IsNot DBNull.Value Then
                        item.seldatumaangekoop = reader("seldatumaangekoop")
                    End If

                    item.NoMatch = False
                Else
                    item.NoMatch = True
                End If

                Return item
                conn.Close()
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function
    Private Sub FetchAll_Tipe2()
        'Kobus 30/10/2013 voegby - om beskrywing in AlleRisk in Afr te stoor in die Tabel waar kliënt Engels is

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@Eistipekode", SqlDbType.Int)
                param.Value = Me.Kode.SelectedValue

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAlle_tipe", param)
                If reader.Read() Then
                    strEistipe = Trim(reader("Eistipe"))
                End If
                conn.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    
End Class