'********************************************************************
'Linkie 10/06/2013
'Form to handle the Debit order unpaid run (VT) that was on stats and multistats
'*******************************************************************
Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Data.SqlClient
Imports DAL
Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Public Class frmDOUnpaidRun
    Dim strFilename As String
    Dim blnUnpaidRunValidated As Boolean
    Dim strLine As String
    Dim intMonth As Integer
    Dim intYear As Integer
    Dim strPolisno As String
    Dim strDebitnr As String
    Dim strVersekerde As String
    Dim strVoorl As String
    Dim strTakhoof As String
    Dim dteVorderdatum As Date
    Dim dblVTBedrag As Double
    Dim clsRun As New clsRuns()
    Dim strReason As String
    Dim strItem As String
    Dim dteDate As Date
    Dim dblPolicyAmountDue As Decimal
    Dim dblPolicyAmountPaid As Decimal
    Dim strActionTaken As String
    Dim dteDateOfAction As Date
    Dim strCancelled As String
    Dim dteMaandAfsluit As Date
    Dim dte2VTRunDate As Date
    Dim dteToday As Date = Today
    Dim dteBetaal As Date
    Dim strItemType As String
    Dim strLoanInst As String
    Dim strLoanAccnr As String


    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        Dim strPath As String = ""
        Dim entTakEntity As New TakEntity
        Dim strTak_afkorting As String = ""

        UnpaidRunValidated()

        If Me.opt1stUnpaidRun.Checked = False And Me.opt2ndUnpaidRun.Checked = False Then
            MsgBox("You have to choose one unpaid run.", vbInformation)
            Exit Sub
        End If

        If blnUnpaidRunValidated = True Then
            Cursor.Current = Cursors.WaitCursor
            lblProcessing.Text = "Validated"
            lblProcessing.Refresh()

            Me.btnOk.Enabled = False
            Me.btnCancel.Enabled = False
            Me.cmdPath.Enabled = False

            lblProcessing.Text = "Database backup"
            lblProcessing.Refresh()

            'backup database
            strPath = clsRun.gen_getServerPath & "MM Backup"
            If Dir(strPath, vbDirectory) = "" Then MkDir(strPath)
            entTakEntity = clsRun.GetTak
            strTak_afkorting = entTakEntity.Tak_afkorting

            If Me.opt1stUnpaidRun.Checked Then
                clsRun.UpdateGebrukerLopiesRuns("VT Lopie (1ste)- " & cmbInsurer.Text, Now)
                strPath = strPath & "\" & strTak_afkorting & "_VT1.bak"
            Else
                clsRun.UpdateGebrukerLopiesRuns("VT Lopie (2de)- " & cmbInsurer.Text, Now)
                strPath = strPath & "\" & strTak_afkorting & "_VT2.bak"
            End If

            If Gebruiker.titel = "Programmeerder" Then
                If Me.chkDatabaseBackup.Checked = True Then
                    clsRun.BackupMooirivierDatabase(strPath)
                End If
            Else
                clsRun.BackupMooirivierDatabase(strPath)
            End If

            ReadFile()

            If Me.chkReportsUnpaid.Checked = True Then
                'run verslag
            End If

            If Me.chkReconReport.Checked = True Then
                'run verslag
            End If

            If Me.chkReportsReconPerMarketer.Checked = True Then
                'run verslag
            End If

            If Me.chkReportsSuspensionOfCover.Checked = True Then
                'run verslag
                If Me.opt2ndUnpaidRun.Checked = True Then
                    Me.lblProcessing.Text = "Suspension of Cover report"
                    Me.lblProcessing.Refresh()
                    DeleteSuspensionOfCover()
                    SuspensionOfCover()
                End If
            End If

            If Me.opt2ndUnpaidRun.Checked = True Then
                Change2ndUnpaidRunDate()
            End If

            lblProcessing.Text = "Finished"
            lblProcessing.Refresh()
            Cursor.Current = Cursors.Default

            Me.btnCancel.Enabled = True
            MsgBox("Finished with run", vbInformation)
        End If

    End Sub

    Private Sub frmDOUnpaidRun_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim strParamaterMaandBetaalwyse As String

        cmbInsurer.DataSource = BaseForm.FillCombo("poldata5.FetchVersekeraar", "pkVersekeraar", "Naam", "", "", "", "")
        cmbInsurer.DisplayMember = "ComboBoxName"
        cmbInsurer.ValueMember = "ComboBoxID"

        cmbInsurer.Text = ""

        'last afsluitdatum
        strParamaterMaandBetaalwyse = "4"
        clsRun.MaxAfsluitDatMaand(strParamaterMaandBetaalwyse)
        Me.dtpUnpaidRunDate.Value = glbMaxAfsluitDatMaand

        If Gebruiker.titel = "Programmeerder" Then
            Me.chkDatabaseBackup.Visible = True
            Me.Label15.Visible = True
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


    Private Sub cmdPath_Click(sender As System.Object, e As System.EventArgs) Handles cmdPath.Click

        If Me.cmbInsurer.Text <> "" Then
            glbVersekeraar = cmbInsurer.SelectedValue
            clsRun.GetInsurer()
        Else
            MsgBox("A insurer must first be chosen before you can select a file.", vbInformation)
            Me.cmbInsurer.Focus()
            Exit Sub
        End If

        If Me.opt1stUnpaidRun.Checked = False And Me.opt2ndUnpaidRun.Checked = False Then
            MsgBox("You have to choose one unpaid to run.", vbInformation)
            Exit Sub
        End If

        ofdUnpaidRun.InitialDirectory = "C:\Polis5Admin\Collections\"
        ofdUnpaidRun.Title = "Open the .v* file of the specific month you are busy with"
        If Me.opt1stUnpaidRun.Checked Then
            ofdUnpaidRun.Filter = "Text file(*.vt)|*.vt"
            strDisFile = strDisFile & ".vt"
        Else
            ofdUnpaidRun.Filter = "Text file(*.v1)|*.v1"
            strDisFile = strDisFile & ".v1"
        End If
        ofdUnpaidRun.FileName = strDisFile

        Dim intDidWork As Integer = ofdUnpaidRun.ShowDialog()

        If intDidWork <> DialogResult.Cancel Then
            strFilename = ofdUnpaidRun.FileName
            Me.txtChooseUnpaidRunFilePath.Text = ofdUnpaidRun.FileName
        End If

        If intDidWork <> DialogResult.Cancel And UCase(Microsoft.VisualBasic.Right(strFilename, 11)) <> UCase(strDisFile) Then
            MsgBox("The file chosen is not the one for this Insurer - please choose correct file.", vbInformation)
            strFilename = ""
            Me.txtChooseUnpaidRunFilePath.Text = ""
            Me.cmdPath.Focus()
            Exit Sub
        End If

    End Sub
    Private Sub UnpaidRunValidated()
        blnUnpaidRunValidated = False

        'Insurer must be chosen
        If Me.cmbInsurer.Text = "" Then
            MsgBox("A insurer must be chosen.", vbInformation)
            blnUnpaidRunValidated = False
            Me.cmbInsurer.Focus()
            Me.btnOk.Enabled = True
            Exit Sub
        End If

        'Date must be checked
        If Me.dtpUnpaidRunDate.Checked = False Then
            MsgBox("A date must be chosen.", vbInformation)
            blnUnpaidRunValidated = False
            Me.dtpUnpaidRunDate.Focus()
            Me.btnOk.Enabled = True
            Exit Sub
        End If

        'Path must be checked
        If Me.txtChooseUnpaidRunFilePath.Text = "" Then
            MsgBox("A path must be chosen.", vbInformation)
            blnUnpaidRunValidated = False
            Me.cmdPath.Focus()
            Me.btnOk.Enabled = True
            Exit Sub
        End If
        blnUnpaidRunValidated = True
    End Sub
    Private Sub ReadFile()
        Dim dteRunDatePlusMonth As Date

        dteRunDatePlusMonth = Me.dtpUnpaidRunDate.Value.AddMonths(1)

        If System.IO.File.Exists(strFilename) = True Then
            Dim objReader As New System.IO.StreamReader(strFilename)

            Do While objReader.Peek() <> -1
                strLine = objReader.ReadLine() & vbNewLine

                intYear = Year(dteRunDatePlusMonth)
                intMonth = Month(dteRunDatePlusMonth)

                'assign waardes uit text file
                strPolisno = Mid(strLine, 6, 10)
                strDebitnr = Mid(strLine, 6, 10)
                dteVorderdatum = Mid(strLine, 73, 2) & "/" & Mid(strLine, 71, 2) & "/" & Mid(strLine, 69, 2)
                If strPolisno = "1685000080" Or strPolisno = "1183052434" Then
                    strPolisno = strPolisno
                End If
                Try
                    Using conn As SqlConnection = SqlHelper.GetConnection
                        Dim param() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                               New SqlParameter("@pkVersekeraar", SqlDbType.Int)}

                        param(0).Value = strPolisno
                        param(1).Value = intPKInsurer
                        Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchPersoonlByVersekeraarAndPolisno", param)

                        If strPolisno = "1685000080" Or strPolisno = "1183052434" Then
                            strPolisno = strPolisno
                        End If
                        If reader.Read Then
                            strVersekerde = reader("versekerde")
                            strVoorl = reader("voorl")
                            Try
                                Using connect As SqlConnection = SqlHelper.GetConnection
                                    Dim params As New SqlParameter("@BranchVyf", SqlDbType.NVarChar)
                                    params.Value = Mid(strDebitnr, 2, 5)

                                    Dim readerTakpolisno As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchTakPolisno", params)

                                    If readerTakpolisno.Read Then
                                        'soek polisno + afsluitdatum in maand - as nie gekry, voeg dit by, dit beteken dat daar 'n polis deur multidata betaal is wat nie by Mooirivier is nie)
                                        strTakhoof = readerTakpolisno("tak_naam")

                                        lblProcessing.Text = "Processing: " & strPolisno
                                        lblProcessing.Refresh()

                                        WriteDataDetails()
                                        WriteDataBalans()
                                        CorrectMaand()
                                    End If
                                    If connect.State = ConnectionState.Open Then
                                        connect.Close()
                                        readerTakpolisno.Close()
                                    End If
                                End Using
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Critical)
                            End Try
                        End If
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                            reader.Close()
                        End If
                    End Using
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                Application.DoEvents()
            Loop

            objReader.Close()

            Me.btnOk.Enabled = False
        Else
            MsgBox("File does not exist.", vbInformation)
        End If
    End Sub
    Private Sub Change2ndUnpaidRunDate()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@Tipe", SqlDbType.NVarChar)
                param.Value = "2de VT lopie"

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5d.UpdateUnpaidRunAfsluitdat", param)

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub WriteDataDetails()

        Try
            Using conn4 As SqlConnection = SqlHelper.GetConnection
                'andriette 19/08/2014 voeg 2 parameters by die SP - was benodig by die frmkontantdetail vorm
                ' om die byvoeg van die korrekte data by die inlees van betalings op VT
                'Andriette 27/08/2014 verander die sp - sit die pk waarde heel bo aan die lys
                'Dim params4() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                '                                New SqlParameter("@vt_bedrag", SqlDbType.Money), _
                '                                New SqlParameter("@vt_datum", SqlDbType.DateTime), _
                '                                New SqlParameter("@datumaangevra", SqlDbType.DateTime), _
                '                                New SqlParameter("@vt_takkode", SqlDbType.NVarChar), _
                '                                New SqlParameter("@vt_reknr", SqlDbType.NVarChar), _
                '                                New SqlParameter("@vt_rede", SqlDbType.NVarChar), _
                '                                New SqlParameter("@vt_kode", SqlDbType.Int), _
                '                                New SqlParameter("@x", SqlDbType.Bit), _
                '                                New SqlParameter("@vt_ingevorder", SqlDbType.Money), _
                '                                New SqlParameter("@vt_kwitansie", SqlDbType.NVarChar), _
                '                                New SqlParameter("@trans_dat", SqlDbType.DateTime), _
                '                                New SqlParameter("@jaar", SqlDbType.Int), _
                '                                New SqlParameter("@maand", SqlDbType.Int), _
                '                                New SqlParameter("@afsluit_dat", SqlDbType.DateTime), _
                '                                New SqlParameter("@vt_vord_Datum", SqlDbType.DateTime), _
                '                                New SqlParameter("@Kwit_Boek", SqlDbType.NVarChar)}
                Dim params4() As SqlParameter = {New SqlParameter("@pkMaand_Vt_Details", SqlDbType.NVarChar), _
                                                New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@vt_bedrag", SqlDbType.Money), _
                                                New SqlParameter("@vt_datum", SqlDbType.DateTime), _
                                                New SqlParameter("@datumaangevra", SqlDbType.DateTime), _
                                                New SqlParameter("@vt_takkode", SqlDbType.NVarChar), _
                                                New SqlParameter("@vt_reknr", SqlDbType.NVarChar), _
                                                New SqlParameter("@vt_rede", SqlDbType.NVarChar), _
                                                New SqlParameter("@vt_kode", SqlDbType.Int), _
                                                New SqlParameter("@x", SqlDbType.Bit), _
                                                New SqlParameter("@vt_ingevorder", SqlDbType.Money), _
                                                New SqlParameter("@vt_kwitansie", SqlDbType.NVarChar), _
                                                New SqlParameter("@trans_dat", SqlDbType.DateTime), _
                                                New SqlParameter("@jaar", SqlDbType.Int), _
                                                New SqlParameter("@maand", SqlDbType.Int), _
                                                New SqlParameter("@afsluit_dat", SqlDbType.DateTime), _
                                                New SqlParameter("@vt_vord_Datum", SqlDbType.DateTime), _
                                                New SqlParameter("@Kwit_Boek", SqlDbType.NVarChar)}
                'Andriette 19/08/2014 voeg die laaste 2 parameters by

                'params4(0).Value = strPolisno
                'params4(1).Value = Val(Mid(strLine, 84, 11) + "." + Mid(strLine, 96, 2))
                'params4(2).Value = Mid(strLine, 82, 2) & "/" & Mid(strLine, 80, 2) & "/" & Mid(strLine, 78, 2)
                'params4(3).Value = Mid(strLine, 73, 2) & "/" & Mid(strLine, 71, 2) & "/" & Mid(strLine, 69, 2)
                'params4(4).Value = Mid(strLine, 48, 6)
                'params4(5).Value = Mid(strLine, 55, 13)
                'params4(6).Value = Mid(strLine, 105, Len(strLine) + 1 - 105)
                'params4(7).Value = Mid(strLine, 102, 2)
                'params4(8).Value = IIf(Mid(strLine, 100, 1) = "X", True, False)
                'params4(9).Value = 0
                'params4(10).Value = ""
                'params4(11).Value = Now
                'params4(12).Value = intYear
                'params4(13).Value = intMonth
                'params4(14).Value = Me.dtpUnpaidRunDate.Value
                'params4(15).Value = System.DBNull.Value
                'params4(16).Value = System.DBNull.Value
                params4(0).Value = 0
                params4(1).Value = strPolisno
                params4(2).Value = Val(Mid(strLine, 84, 11) + "." + Mid(strLine, 96, 2))
                params4(3).Value = Mid(strLine, 82, 2) & "/" & Mid(strLine, 80, 2) & "/" & Mid(strLine, 78, 2)
                params4(4).Value = Mid(strLine, 73, 2) & "/" & Mid(strLine, 71, 2) & "/" & Mid(strLine, 69, 2)
                params4(5).Value = Mid(strLine, 48, 6)
                params4(6).Value = Mid(strLine, 55, 13)
                params4(7).Value = Mid(strLine, 105, Len(strLine) + 1 - 105)
                params4(8).Value = Mid(strLine, 102, 2)
                params4(9).Value = IIf(Mid(strLine, 100, 1) = "X", True, False)
                params4(10).Value = 0
                params4(11).Value = ""
                params4(12).Value = Now
                params4(13).Value = intYear
                params4(14).Value = intMonth
                params4(15).Value = Me.dtpUnpaidRunDate.Value
                params4(16).Value = System.DBNull.Value
                params4(17).Value = System.DBNull.Value

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.UpdateMaand_VT_Details", params4)
                If conn4.State = ConnectionState.Open Then
                    conn4.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Public Sub WriteDataBalans()

        dblVTBedrag = Val(Mid(strLine, 84, 11) & "." & Mid(strLine, 96, 2))

        Try
            Using conn4 As SqlConnection = SqlHelper.GetConnection

                Dim params4() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@versekerde", SqlDbType.NVarChar), _
                                                New SqlParameter("@voorl", SqlDbType.NVarChar), _
                                                New SqlParameter("@vt_aant", SqlDbType.Int), _
                                                New SqlParameter("@vt_balans", SqlDbType.Money), _
                                                New SqlParameter("@trans_dat", SqlDbType.DateTime), _
                                                New SqlParameter("@afsluit_dat", SqlDbType.DateTime), _
                                                New SqlParameter("@jaar", SqlDbType.Int), _
                                                New SqlParameter("@maand", SqlDbType.Int)}
                If strPolisno = "1183052434" Or strPolisno = "1685000080" Then
                    strPolisno = strPolisno
                End If
                params4(0).Value = strPolisno
                params4(1).Value = strVersekerde
                params4(2).Value = strVoorl
                params4(3).Value = 1
                params4(4).Value = dblVTBedrag
                params4(5).Value = Now
                params4(6).Value = Me.dtpUnpaidRunDate.Value
                params4(7).Value = intYear
                params4(8).Value = intMonth

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.UpdateMaand_VT_Balans", params4)
                If conn4.State = ConnectionState.Open Then
                    conn4.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Private Sub CorrectMaand()
        Dim dteAfsluitdat As Date

        dblVTBedrag = Val(Mid(strLine, 84, 11) & "." & Mid(strLine, 96, 2))

        'indien die vt vir die vorige maand is, moet dit die vorige maand se afsluitdatum kry
        If CInt(Mid(strLine, 71, 2)) <> intMonth Or CInt(("20" & Mid(strLine, 69, 2))) <> intYear Then
            Try
                Using connMaand As SqlConnection = SqlHelper.GetConnection
                    Dim paramMaand() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                   New SqlParameter("@Maand", SqlDbType.Int), _
                                                   New SqlParameter("@JAAR", SqlDbType.Int)}

                    paramMaand(0).Value = strPolisno
                    paramMaand(1).Value = CInt(Mid(strLine, 71, 2))
                    paramMaand(2).Value = CInt(("20" & Mid(strLine, 69, 2)))

                    Dim readerMaand As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchMaandDebities", paramMaand)

                    If readerMaand.Read Then
                        dteAfsluitdat = readerMaand("afsluit_dat")
                    End If
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try
        End If

        Try
            Using conn4 As SqlConnection = SqlHelper.GetConnection

                Dim params4() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                New SqlParameter("@afsluit_dat", SqlDbType.DateTime), _
                                                New SqlParameter("@vord_premie", SqlDbType.Money), _
                                                New SqlParameter("@match", SqlDbType.Bit), _
                                                New SqlParameter("@ingevorder", SqlDbType.Money), _
                                                New SqlParameter("@trans_dat", SqlDbType.DateTime), _
                                                New SqlParameter("@vord_dat", SqlDbType.DateTime), _
                                                New SqlParameter("@oningewin", SqlDbType.Money)}

                params4(0).Value = strPolisno
                If CInt(Mid(strLine, 71, 2)) <> intMonth Or CInt(("20" & Mid(strLine, 69, 2))) <> intYear Then
                    params4(1).Value = dteAfsluitdat
                Else
                    params4(1).Value = Me.dtpUnpaidRunDate.Value
                End If
                params4(2).Value = 0
                params4(3).Value = False
                params4(4).Value = 0
                params4(5).Value = Now
                params4(6).Value = DBNull.Value
                params4(7).Value = dblVTBedrag

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.UpdateMaandWithVT", params4)
                If conn4.State = ConnectionState.Open Then
                    conn4.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Private Sub SuspensionOfCover()

        blnVertoonMsg = False

        dteMaandAfsluit = glbMaxAfsluitDatMaand.AddMonths(1)

        dte2VTRunDate = clsRun.Get2ndVTRunDate()

        If IsDBNull(dte2VTRunDate) = True Then
            MsgBox("No rundate exists for 2nd VT run in stats5d.  Report ends.", vbInformation)
            Exit Sub
        End If

        dte2VTRunDate = dte2VTRunDate.AddDays(1)
        dteBetaal = dteMaandAfsluit.AddMonths(1)
        dteBetaal = dteBetaal.AddDays(-(dteBetaal.Day - 1))

        'kry Voertuie
        Try
            Using connect As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@ItemType", SqlDbType.NVarChar), _
                                               New SqlParameter("@Betaaldatum", SqlDbType.Date)}

                param(0).Value = "Vehicles"
                param(1).Value = dteBetaal     'System.String.Format(dteBetaal)

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchSuspensionofCover", param)

                Me.lblProcessing.Text = "Suspension of cover - Vehicles"
                Me.lblProcessing.Refresh()

                Do While reader.Read
                    strVersekerde = reader("versekerde")
                    strVoorl = reader("voorl")
                    strPolisno = reader("polisno")
                    strItemType = "Vehicles"
                    strLoanInst = reader("huurinstansie")
                    strLoanAccnr = reader("huurnommer")
                    Diagnostics.Debug.WriteLine("readervoertuie" & strPolisno)

                    If strPolisno = "1183052434" Or strPolisno = "1183052509" Or strPolisno = "1183052701" Or strPolisno = "1183052710" Or strPolisno = "1183052134" Then
                        strPolisno = strPolisno
                    End If

                    Application.DoEvents()

                    'was the policy for this vehicle cancelled in this period?
                    If reader("gekans") = True Then
                        strCancelled = clsRun.GetPolicyCancelled(strPolisno, dte2VTRunDate, dteToday, strCancelled)

                        If strCancelled = "Yes" Then
                            clsRun.GetVehicleDescription(reader("ander"), reader("kode"), reader("eeu"), reader("jaar"))
                            strItem = strDescriptionVehicle & "(" & reader("n_plaat") & ")"

                            clsRun.GetVerifieerDekking(strPolisno, Today, Month(dteMaandAfsluit))

                            strReason = "Policy Cancelled"
                            dteDate = reader("datumgekanselleer")
                            'skryf na tabel
                            dblPolicyAmountDue = dblAmountDueVerifyDek
                            dblPolicyAmountPaid = dblAmountPaidVerifyDek
                            strActionTaken = ""
                            dteDateOfAction = Today

                            CreateSuspensionOfCoverData()
                        End If
                    Else
                        clsRun.GetVerifieerDekking(strPolisno, Today, Month(dteMaandAfsluit))

                        If blnIsBetaalJN = False Then
                            'get description
                            clsRun.GetVehicleDescription(reader("ander"), reader("kode"), reader("eeu"), reader("jaar"))
                            strItem = strDescriptionVehicle & " (" & reader("n_plaat") & ")"

                            If blnInEeersteMaand = True Then
                                strReason = "New Policy"
                                dteDate = reader("P_a_dat")
                            Else
                                strReason = "No Cover"
                                dteDate = Today
                            End If
                            'skryf na tabel
                            dblPolicyAmountDue = dblAmountDueVerifyDek
                            dblPolicyAmountPaid = dblAmountPaidVerifyDek
                            strActionTaken = ""
                            dteDateOfAction = Today

                            CreateSuspensionOfCoverData()
                        End If
                    End If
                Loop
                If connect.State = ConnectionState.Open Then
                    connect.Close()
                    reader.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        'kry deleted voertuie
        Try
            Using connect As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@ItemType", SqlDbType.NVarChar), _
                                               New SqlParameter("@Verwyderdedatum", SqlDbType.DateTime)}

                param(0).Value = "Vehicles"
                param(1).Value = dte2VTRunDate

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchSuspensionofCoverDeletedItems", param)
                Me.lblProcessing.Text = "Suspension of cover - Deleted Vehicles"
                Me.lblProcessing.Refresh()

                Do While reader.Read
                    strVersekerde = reader("versekerde")
                    strVoorl = reader("voorl")
                    strPolisno = reader("polisno")
                    strItemType = "Vehicles"
                    strLoanInst = reader("huurinstansie")
                    strLoanAccnr = reader("huurnommer")

                    Diagnostics.Debug.WriteLine("reader deleted voertuie" & strPolisno)
                    clsRun.GetVehicleDescription(reader("ander"), reader("kode"), reader("eeu"), reader("jaar"))
                    If strPolisno = "1183052434" Or strPolisno = "1183052509" Or strPolisno = "1183052701" Or strPolisno = "1183052710" Or strPolisno = "1183052134" Then
                        strPolisno = strPolisno
                    End If
                    'skryf na tabel
                    strItem = strDescriptionVehicle & "(" & reader("n_plaat") & ")"
                    dblPolicyAmountDue = 0
                    dblPolicyAmountPaid = 0
                    strActionTaken = ""
                    dteDateOfAction = Today
                    strReason = "Vehicle Removed"
                    dteDate = reader("verwyderdedatum")

                    CreateSuspensionOfCoverData()
                Loop
                If connect.State = ConnectionState.Open Then
                    connect.Close()
                    reader.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        'kry huise
        Try
            Using connect As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@ItemType", SqlDbType.NVarChar), _
                                               New SqlParameter("@Betaaldatum", SqlDbType.Date)}

                param(0).Value = "Properties"
                param(1).Value = dteBetaal     'System.String.Format(dteBetaal)

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchSuspensionofCover", param)

                Me.lblProcessing.Text = "Suspension of cover - Properties"
                Me.lblProcessing.Refresh()

                Do While reader.Read
                    strVersekerde = reader("versekerde")
                    strVoorl = reader("voorl")
                    strItemType = "Properties"
                    strPolisno = reader("polisno")
                    If strPolisno = "1183052434" Or strPolisno = "1183052509" Or strPolisno = "1183052701" Or strPolisno = "1183052710" Or strPolisno = "1183052134" Then
                        strPolisno = strPolisno
                    End If
                    strLoanInst = IIf(IsDBNull(reader("huurinstansie")) = True, "Unknown", reader("huurinstansie"))
                    strLoanAccnr = reader("bondnumber")
                    Diagnostics.Debug.WriteLine("readerhuise" & strPolisno)
                    'was the policy for this vehicle cancelled in this period?
                    If reader("gekans") = True Then
                        strCancelled = clsRun.GetPolicyCancelled(strPolisno, dte2VTRunDate, dteToday, strCancelled)

                        If strCancelled = "Yes" Then
                            strItem = reader("adres_h1")

                            strReason = "Policy Cancelled"
                            dteDate = reader("datumgekanselleer")
                            dblPolicyAmountDue = dblAmountDueVerifyDek
                            dblPolicyAmountPaid = dblAmountPaidVerifyDek
                            strActionTaken = ""
                            dteDateOfAction = Today

                            CreateSuspensionOfCoverData()
                        End If
                    Else
                        clsRun.GetVerifieerDekking(strPolisno, Today, Month(dteMaandAfsluit))

                        If blnIsBetaalJN = False Then
                            'get description
                            strItem = reader("adres_h1")

                            If blnInEeersteMaand = True Then
                                strReason = "New Policy"
                                dteDate = reader("P_a_dat")
                            Else
                                strReason = "No Cover"
                                dteDate = Today
                            End If
                            dblPolicyAmountDue = dblAmountDueVerifyDek
                            dblPolicyAmountPaid = dblAmountPaidVerifyDek
                            strActionTaken = ""
                            dteDateOfAction = Today

                            CreateSuspensionOfCoverData()
                        End If
                    End If
                Loop
                If connect.State = ConnectionState.Open Then
                    connect.Close()
                    reader.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        'kry deleted huise
        Try
            Using connect As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@ItemType", SqlDbType.NVarChar), _
                                               New SqlParameter("@Verwyderdedatum", SqlDbType.DateTime)}

                param(0).Value = "Properties"
                param(1).Value = dte2VTRunDate

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchSuspensionofCoverDeletedItems", param)
                Me.lblProcessing.Text = "Suspension of cover - Deleted Properties"
                Me.lblProcessing.Refresh()

                Do While reader.Read
                    strVersekerde = reader("versekerde")
                    strVoorl = reader("voorl")
                    strPolisno = reader("polisno")
                    strItemType = "Properties"
                    strLoanInst = IIf(IsDBNull(reader("huurinstansie")) = True, "Unknown", reader("huurinstansie"))
                    strLoanAccnr = reader("bondnumber")

                    Diagnostics.Debug.WriteLine("readerdeletedhuise" & strPolisno)
                    If strPolisno = "1183052434" Or strPolisno = "1183052509" Or strPolisno = "1183052701" Or strPolisno = "1183052710" Or strPolisno = "1183052134" Then
                        strPolisno = strPolisno
                    End If
                    'skryf na tabel
                    strItem = reader("adres_h1")
                    dblPolicyAmountDue = 0
                    dblPolicyAmountPaid = 0
                    strActionTaken = ""
                    dteDateOfAction = Today
                    strReason = "House Removed"
                    dteDate = reader("DatumVerwyder")

                    CreateSuspensionOfCoverData()
                Loop
                If connect.State = ConnectionState.Open Then
                    connect.Close()
                    reader.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub DeleteSuspensionOfCover()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.DeleteSuspensionofCoverData")
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub CreateSuspensionOfCoverData()
        Try
            Using conn5 As SqlConnection = SqlHelper.GetConnection

                Dim params5() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@Versekerde", SqlDbType.NVarChar), _
                                                New SqlParameter("@Voorl", SqlDbType.NVarChar), _
                                                New SqlParameter("@Reason", SqlDbType.NVarChar), _
                                                New SqlParameter("@Itemtype", SqlDbType.NVarChar), _
                                                New SqlParameter("@Item", SqlDbType.NVarChar), _
                                                New SqlParameter("@Date", SqlDbType.Date), _
                                                New SqlParameter("@PolicyAmountDue", SqlDbType.Money), _
                                                New SqlParameter("@PolicyAmountPaid", SqlDbType.Money), _
                                                New SqlParameter("@ActionTaken", SqlDbType.NVarChar), _
                                                New SqlParameter("@DateOfAction", SqlDbType.DateTime), _
                                                New SqlParameter("@LoanInst", SqlDbType.NVarChar), _
                                                New SqlParameter("@LoanAccnr", SqlDbType.NVarChar)}

                params5(0).Value = strPolisno
                params5(1).Value = strVersekerde
                params5(2).Value = strVoorl
                params5(3).Value = strReason
                params5(4).Value = strItemType
                params5(5).Value = strItem
                params5(6).Value = dteDate
                params5(7).Value = dblPolicyAmountDue
                params5(8).Value = dblPolicyAmountPaid
                params5(9).Value = strActionTaken
                params5(10).Value = dteDateOfAction
                params5(11).Value = strLoanInst
                params5(12).Value = strLoanAccnr

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.InsertSuspensionofCoverData", params5)
                If conn5.State = ConnectionState.Open Then
                    conn5.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub opt1stUnpaidRun_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Me.txtChooseUnpaidRunFilePath.Text = ""
    End Sub

    Private Sub opt2ndUnpaidRun_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Me.txtChooseUnpaidRunFilePath.Text = ""
    End Sub

End Class