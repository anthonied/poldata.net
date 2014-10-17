Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Data.SqlClient
Imports DAL
Friend Class AddisionelePremie
    Inherits BaseForm

    ''Description: Form containing all the additional premium values for policy
    Dim IntTeller As Integer
    Dim dbltotaddprem As Double
    Dim pkAddisionelePremie As Integer
    Dim blnInformationChanged As Boolean
    Dim dbltotToevalBreek As Double
    Dim dbltotToevalEEM As Double
    Dim dbltotHB As Double
    Dim dbltotHE As Double
    Dim dbltotHBGras As Double
    Dim dbltotHEGras As Double
    Dim dbltotAlleRisiko As Double
    Dim dbltotWaterlewe As Double
    Dim dbltotMotors As Double
    Dim dbloldTotal As Decimal

    Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        If blnInformationChanged Then
            If MsgBox("Are you sure you want to cancel your changes and lost?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If

    End Sub

    Private Sub btnClear_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClear.Click
        If MsgBox("Are you sure you want to delete the additional premium detail?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            clear()

            dgvAddisionelePremie.AutoGenerateColumns = False
            calcTotals()
        End If
    End Sub

    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
        calcTotals()
        If validateForm() Then
            If pkAddisionelePremie = 0 Then
                'Insert
                InsertAdditionalPremie1()
                If Persoonl.TAAL = 0 Then
                    'Andriette 27/06/2013 doen die formatering
                    BESKRYWING = " bygevoeg: R " & FormatNumber(dgvAddisionelePremie.Rows(19).Cells(1).Value, 2)
                Else
                    BESKRYWING = " added: R " & FormatNumber(dgvAddisionelePremie.Rows(19).Cells(1).Value, 2)
                End If

                UpdateWysig(178, BESKRYWING)
                'Else
                '    UpdateAdditionalPremie()
                'End If
            Else
                If Val(dbloldTotal) <> Val(FormatNumber(dgvAddisionelePremie.Rows(19).Cells(1).Value)) Then
                    If Persoonl.TAAL = 0 Then
                        BESKRYWING = " wysig vanaf R " & FormatNumber(Val(dbloldTotal), 2) & " na R " & FormatNumber(FormatNumber(dgvAddisionelePremie.Rows(19).Cells(1).Value), 2)
                    Else
                        BESKRYWING = " change from R " & FormatNumber(Val(dbloldTotal), 2) & " na R " & FormatNumber(FormatNumber(dgvAddisionelePremie.Rows(19).Cells(1).Value), 2)
                    End If

                    UpdateWysig(178, BESKRYWING)

                End If

            End If
            UpdateAdditionalPremie()

            'Update the premium
            BFUpdateItemsSubTotals(glbPolicyNumber)
            HerBereken_Premie()
            'Andriette 24/10/2013 alles geskuif na herbereken premie
            'doen_subtotaal()

            Me.Close()
        End If
    End Sub
    Private Sub btnVulHuidigePremies_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnVulHuidigePremies.Click
        Dim lstHuisPremies As New List(Of Double)
        Dim dblMotorPremies As Double
        Dim dblAlleRisiko As Double
        Dim dblAfslagpers As Double
        Dim dblHuisPrems As Double
        Dim dblPremieEkstra As Double = 0
        ' Andriette 13/03/2013 skuif die funksies na eenhede wat dit beter sal hanteer
        'Populate grid with current premiums
        'FetchHuisForPremie()
        'FetchVoertuieForPremie()
        'FetchAllerisikoForPremie()
        'Andriette 28/08/2013 verander die werkwyse sodat elke een appart die afslag bereken en nie bymekaar
        'getel word nie sodat die sent verskil utigeskakel word
        dblAfslagpers = Val(Form1.Combo1.Text)
        lstHuisPremies = Huis_totale_premie(dblAfslagpers) 'Andriette  18/09/2013 voor afslag
        dblMotorPremies = Motors_totale_premie(dblAfslagpers) 'Andriette 18/09/2013 voor afslag
        dblAlleRisiko = AlleRisiko_totale_premie(dblAfslagpers) 'Andriette 18/09/2013 voor afslag

        dgvAddisionelePremie.Rows.Clear()

        dgvAddisionelePremie.ColumnCount = 4
        dgvAddisionelePremie.ColumnHeadersVisible = True
        dgvAddisionelePremie.AutoGenerateColumns = False
        'Andriette 16/10/2013 doen die afslag hier reeds
        VulGrid(Str(dblMotorPremies * dblAfslagpers),
       dbltotWaterlewe * dblAfslagpers,
       dblAlleRisiko.ToString * dblAfslagpers,
       lstHuisPremies(1) * dblAfslagpers,
       lstHuisPremies(0) * dblAfslagpers,
       dbltotHBGras * dblAfslagpers,
       dbltotHEGras * dblAfslagpers,
       lstHuisPremies(2) * dblAfslagpers,
       lstHuisPremies(3) * dblAfslagpers,
       Form1.Label36.Text,
       Form1.txtLiabilityPrem.Text,
       Form1.Label35.Text,
       Form1.plip2.Text,
       Form1.txtCourtesyPrem.Text,
       Form1.txthomeAsstPrem.Text,
       Form1.txtRoadsidePrem.Text,
       Form1.btnSelfoonPremie.Text,
       Form1.lblPakket1Prem.Text,
       Form1.Verwysingskommissie.Text,
       (dbltotaddprem),
       "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "")

        dblPremieEkstra = CDec(Form1.Label36.Text) + CDec(Form1.txtLiabilityPrem.Text) + CDec(Form1.Label35.Text) +
        CDec(Form1.plip2.Text) + CDec(Form1.txtCourtesyPrem.Text) + CDec(Form1.txthomeAsstPrem.Text) + CDec(Form1.txtRoadsidePrem.Text) +
        CDec(Form1.btnSelfoonPremie.Text) + CDec(Form1.lblPakket1Prem.Text)

        dblHuisPrems = lstHuisPremies(0) + lstHuisPremies(1) + lstHuisPremies(2) + lstHuisPremies(3)
        calcTotals(, dblHuisPrems + dblAlleRisiko + dblMotorPremies, dblPremieEkstra)

    End Sub

    Public Function FetchAllerisikoForPremie() As List(Of ALLERISKEntity)

        Dim list As List(Of ALLERISKEntity) = New List(Of ALLERISKEntity)

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                'Andriette 15/08/2013 verander na die global polisnommer
                'param.Value = Form1.form1Polisno.Text
                param.Value = glbPolicyNumber

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchAlleriskByPolisno", param)

                'If reader.Read() Then

                Do While reader.Read()
                    Dim item As ALLERISKEntity = New ALLERISKEntity()
                    If reader("POLISNO") IsNot DBNull.Value Then
                        item.POLISNO = reader("POLISNO")
                    End If
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

                    list.Add(item)
                Loop
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

            Return List
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function

    Private Sub cmbGeskiedenis_Click(sender As Object, e As System.EventArgs) Handles cmbGeskiedenis.Click
        'ChangeComboBox()
    End Sub


    Private Sub cmbGeskiedenis_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbGeskiedenis.SelectedIndexChanged
        ChangeComboBox()
    End Sub

    Public Sub ChangeComboBox()

        ' Andriette 07/06/2013 invoeg van ;n lee element en dan moet hy nie gekies kan word nie
        If Trim(cmbGeskiedenis.SelectedIndex) <> 0 Then
            Try
                dgvAddisionelePremie.AutoGenerateColumns = False
                dgvAddisionelePremie.Rows.Clear()
                Using conn As SqlConnection = SqlHelper.GetConnection
                    Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                                    New SqlParameter("@pkAddisionelePremie", SqlDbType.Int)}

                    params(0).Value = Persoonl.POLISNO
                    params(1).Value = cmbGeskiedenis.SelectedValue
                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchAddisionelePremie]", params)

                    While reader.Read()
                        If reader("pkAddisionelePremie") = 0 Then
                            dgvAddisionelePremie.Rows.Clear()

                            pkAddisionelePremie = 0
                        ElseIf reader("pkAddisionelePremie") IsNot DBNull.Value Then
                            pkAddisionelePremie = reader("pkAddisionelePremie")
                        End If

                        'Enable/Disable grid
                        If reader("afgesluit") = 1 Then
                            dgvAddisionelePremie.Enabled = False
                            btnOk.Enabled = False
                            Me.btnClear.Enabled = False
                            Me.btnVulHuidigePremies.Enabled = False
                        Else
                            dgvAddisionelePremie.Enabled = True
                            btnOk.Enabled = True
                            Me.btnClear.Enabled = True
                            Me.btnVulHuidigePremies.Enabled = True
                        End If

                        ' Andriette 2013-02-05
                        VulGrid(reader("motors"),
                                    reader("Waterlewe"),
                                    reader("AlleRisiko"),
                                    reader("HB"),
                                    reader("HE"),
                                    reader("HBGras"),
                                    reader("HEGras"),
                                    reader("ToevalEEM"),
                                    reader("ToevalBreek"),
                                    reader("Sasria"),
                                    reader("Polisfooi"),
                                    reader("Begrafnis"),
                                    reader("Plip"),
                                    reader("CourtesyV"),
                                    reader("EPC"),
                                    reader("CareAssist"),
                                    reader("Selfoon"),
                                    reader("PakketItem1"),
                                    reader("SpesialeKorting"),
                                    reader("Totaal"),
                                    reader("motorsBesk"),
                                    reader("WaterleweBesk"),
                                    reader("AllerisikoBesk"),
                                    reader("HBBesk"),
                                    reader("HEBesk"),
                                    reader("HBGrasBesk"),
                                    reader("HEGRasBesk"),
                                    reader("ToevalEEMBesk"),
                                    reader("ToevalBreekBesk"),
                                    reader("SasriaBesk"),
                                    reader("PolisfooiBesk"),
                                    reader("BegrafnisBesk"),
                                    reader("PlipBesk"),
                                    reader("CourtesyVBesk"),
                                    reader("EPCBesk"),
                                    reader("CareAssistBesk"),
                                    reader("SelfoonBesk"),
                                    reader("PakketItem1Besk"),
                                    reader("SpesialeKortingBesk"),
                                    "")

                    End While
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                End Using
                calcTotals()
                dgvAddisionelePremie.Rows(20).Cells(1).Value = "-----------"
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
    Private Sub AddisionelePremie_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        'Set form caption
        'Andriette 15/08/2013 verander die polisnommer na die global polisnommer
        'Me.Text = My.Application.Info.Title & " - Additional Premium - " & Form1.TITEL.Text & " " & Form1.VOORL.Text & " " & Form1.VERSEKERDE.Text & " (" & Form1.POLISNO.Text & ")"
        Me.Text = My.Application.Info.Title & " - Additional Premium - " & Form1.TITEL.Text & " " & Form1.VOORL.Text & " " & Form1.VERSEKERDE.Text & " (" & glbPolicyNumber & ")"
        If Gebruiker.titel = "Besigtig" Then
            Me.btnOk.Enabled = False
        End If
    End Sub

    Private Sub AddisionelePremie_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        ' Andriette 13/3/2013 skuif die datagri laer af
        dbltotaddprem = 0
        'Populate combobox with data
        cmbGeskiedenis.DisplayMember = "DisplayValue"
        cmbGeskiedenis.ValueMember = "pkAddisionelePremie"

        cmbGeskiedenis.DataSource = PopulateComboGeskiedenis()
        ' Andriette 08/04/2013  skuif die grid vul na hier
        SkepGrid()
        VulGrid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "")

        blnInformationChanged = False
        If cmbGeskiedenis.DataSource.count > 0 Then
            'Andriette 03/09/2013 split die funksie

            InitializeDataGridView()
        End If

        'Check if policy is cancelled
        If Persoonl.GEKANS = True Then
            Me.btnOk.Enabled = False
        Else
            Me.btnOk.Enabled = True
        End If

        If Gebruiker.titel = "Besigtig" Then
            Me.btnOk.Enabled = False
        End If

    End Sub

    Private Sub Image1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Image1.Click
        MsgBox("Use the arrows to move between the cells of the table.", MsgBoxStyle.Information)
    End Sub

    Private Sub Text1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text1.TextChanged
        blnInformationChanged = True
    End Sub


    Public Function PopulateComboGeskiedenis() As List(Of AdditionalPremieEntity)

        Dim lstEntAddPremie As List(Of AdditionalPremieEntity) = New List(Of AdditionalPremieEntity)
        Dim endAddPremie As AdditionalPremieEntity = New AdditionalPremieEntity()
        endAddPremie.pkAddisionelePremie = 99
        endAddPremie.DisplayValue = ""
        lstEntAddPremie.Add(endAddPremie)
        '  item1 = Nothing

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar)}

                params(0).Value = Persoonl.POLISNO

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchDateForAdditionalPremie]", params)
                If reader.HasRows Then
                    While reader.Read()
                        Dim endAddPremie2 As AdditionalPremieEntity = New AdditionalPremieEntity()

                        If reader("pkAddisionelePremie") IsNot DBNull.Value Then
                            endAddPremie2.pkAddisionelePremie = reader("pkAddisionelePremie")
                        End If
                        If reader("datAfgesluit") IsNot DBNull.Value Then
                            endAddPremie2.datAfgesluit = reader("datAfgesluit")
                        End If
                        If reader("datToegevoer") IsNot DBNull.Value Then
                            endAddPremie2.datToegevoer = reader("datToegevoer")
                        End If
                        If reader("afgesluit") IsNot DBNull.Value Then
                            endAddPremie2.afgesluit = reader("afgesluit")
                            If endAddPremie2.afgesluit = 0 Then
                                'Me.cmbGeskiedenis.Items.Add(item.datToegevoer & " - Aktief")
                                endAddPremie2.DisplayValue = endAddPremie2.datToegevoer & " - Aktief"

                            Else
                                'Me.cmbGeskiedenis.Items.Add(item.datAfgesluit & " - Afgesluit")
                                endAddPremie2.DisplayValue = endAddPremie2.datAfgesluit & " - Afgesluit"

                            End If
                        End If

                        lstEntAddPremie.Add(endAddPremie2)
                    End While
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox("There's error trying to connect to the database.", MsgBoxStyle.Exclamation)
        End Try
        Return lstEntAddPremie
    End Function
    Sub clear()
        'Andriette 03/09/2013 maak eers die grid skoon

        VulGrid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "")

    End Sub
    Private Sub InitializeDataGridView()
        Dim dblItemsTotal As Double = 0
        Dim dblEkstras As Double = 0
        Dim dbltotalna As Double = 0
        Dim dblpremieekstras As Double = 0
        dbltotToevalBreek = 0
        dbltotToevalEEM = 0
        dbltotHB = 0
        dbltotHE = 0
        dbltotHBGras = 0
        dbltotHEGras = 0
        dbltotAlleRisiko = 0
        dbltotWaterlewe = 0
        dbltotMotors = 0
        dbltotaddprem = Format(Val(CStr(dbltotaddprem)) + Val(Form1.lblMaandeliksePremie.Text) - Val(Form1.Verwysingskommissie.Text), "0.00")
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar)}

                ' params(0).Value = Persoonl.POLISNO
                params(0).Value = glbPolicyNumber

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchAddisionalPrieme]", params)
                If reader.HasRows Then

                    While reader.Read()

                        If reader("pkAddisionelePremie") Then
                            pkAddisionelePremie = (reader("pkAddisionelePremie"))
                        Else
                            pkAddisionelePremie = 0
                        End If

                        'Enable/Disable grid
                        If reader("afgesluit") = 1 Then
                            dgvAddisionelePremie.Enabled = False
                            btnOk.Enabled = False
                            Me.btnClear.Enabled = False
                            Me.btnVulHuidigePremies.Enabled = False
                        Else
                            dgvAddisionelePremie.Enabled = True
                            btnOk.Enabled = True
                            Me.btnClear.Enabled = True
                            Me.btnVulHuidigePremies.Enabled = True
                        End If
                        ' Populate the rows.
                        VulGrid(reader("motors"),
                                reader("Waterlewe"),
                                reader("AlleRisiko"),
                                reader("HB"),
                                reader("HE"),
                                reader("HBGras"),
                                reader("HEGras"),
                                reader("ToevalEEM"),
                                reader("ToevalBreek"),
                                reader("Sasria"),
                                reader("Polisfooi"),
                                reader("Begrafnis"),
                                reader("Plip"),
                                reader("CourtesyV"),
                                reader("EPC"),
                                reader("CareAssist"),
                                reader("Selfoon"),
                                reader("PakketItem1"),
                                reader("SpesialeKorting"),
                                reader("Totaal"),
                                reader("motorsBesk"),
                                reader("WaterleweBesk"),
                                reader("AllerisikoBesk"),
                                reader("HBBesk"),
                                reader("HEBesk"),
                                reader("HBGrasBesk"),
                                reader("HEGRasBesk"),
                                reader("ToevalEEMBesk"),
                                reader("ToevalBreekBesk"),
                                reader("SasriaBesk"),
                                reader("PolisfooiBesk"),
                                reader("BegrafnisBesk"),
                                reader("PlipBesk"),
                                reader("CourtesyVBesk"),
                                reader("EPCBesk"),
                                reader("CareAssistBesk"),
                                reader("SelfoonBesk"),
                                reader("PakketItem1Besk"),
                                reader("SpesialeKortingBesk"),
                                "")
                        dbltotalna = reader("motors") + reader("Waterlewe") + reader("AlleRisiko") + reader("HB") +
                                reader("HE") + reader("HBGras") + reader("HEGras") + reader("ToevalEEM") + reader("ToevalBreek")
                        dblEkstras = reader("Sasria") + reader("Polisfooi") + reader("Begrafnis") + reader("Plip") +
                                reader("CourtesyV") + reader("EPC") + reader("CareAssist") + reader("Selfoon") + reader("PakketItem1")
                        dbloldTotal = dbltotalna + dblEkstras
                    End While
                Else

                    dgvAddisionelePremie.Enabled = True
                    btnOk.Enabled = True
                    Me.btnClear.Enabled = True
                    Me.btnVulHuidigePremies.Enabled = True
                    pkAddisionelePremie = 0
                End If

                dgvAddisionelePremie.Rows(19).Cells(1).Value = FormatNumber(dbltotalna + dblEkstras, 2)
                dgvAddisionelePremie.Rows(20).Cells(1).Value = FormatNumber(dbltotalna + dblEkstras + Form1.lblMaandeliksePremie.Text - Form1.Verwysingskommissie.Text, 2)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Public Function insertAlterationRecord() As AdditionalPremieEntity
        'Dim list As List(Of Print2DatEntity) = New List(Of Print2DatEntity)
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param() As SqlParameter = {New SqlParameter("@Polisno", SqlDbType.NVarChar)}

                param(0).Value = Persoonl.POLISNO


                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchAddisionalPrieme]", param)
                Dim item As AdditionalPremieEntity = New AdditionalPremieEntity()
                If reader.Read Then

                    If reader("totaal") IsNot DBNull.Value Then
                        item.totaal = reader("totaal")
                    End If
                    ' Haal uit hier en skuif na regte plek
                    'If Persoonl.TAAL = 0 Then
                    '    'Andriette 27/06/2013 doen die formatering
                    '    BESKRYWING = " bygevoeg: R " & FormatNumber(reader("totaal"), 2)
                    'Else
                    '    BESKRYWING = " added: R " & FormatNumber(reader("totaal"), 2)
                    'End If

                    'UpdateWysig(178, BESKRYWING)

                    'Else
                    If Val(rsAddPremie.totaal) <> Val(dbloldTotal) Then
                        If Persoonl.TAAL = 0 Then
                            BESKRYWING = " wysig vanaf R " & FormatNumber(Val(dbloldTotal), 2) & " na R " & FormatNumber(reader("totaal"), 2)
                        Else
                            BESKRYWING = " change from R " & FormatNumber(Val(dbloldTotal), 2) & " na R " & FormatNumber(reader("totaal"), 2)
                        End If

                        UpdateWysig(178, BESKRYWING)

                    End If
                    item.Nomatch = False
                Else
                    item.Nomatch = True
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
            'Exit Function
        End Try
        Return Nothing
    End Function

    Sub UpdateAdditionalPremie()
        Dim strWaardesBeskrywings(24, 3) As String
        Dim intPkAddisionelePremie As Integer = 0
        Dim intwaarde As Integer = 3
        Dim strbedrag As String = ""
        Dim dblBedrag As Decimal = 0
        Dim strMessage As String = ""
        Dim strRye() As String = {"0", "1", "3", "4", "5", "6", "7", "8"}
        Dim intTelRye As Integer = 0

        Try
            ' kry eers die pk value
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar)}

                params(0).Value = Persoonl.POLISNO

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchAddisionalPrieme]", params)
                If reader.HasRows Then
                    While reader.Read()
                        intPkAddisionelePremie = (reader("pkAddisionelePremie"))
                    End While

                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

            ' calcTotals()
            If intPkAddisionelePremie = 0 Then
                MsgBox("Iets groot fout")
            End If
            Using conn As SqlConnection = SqlHelper.GetConnection
                '|Andriette prpbeer iets
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim param() As SqlParameter = {New SqlParameter("@pkAddisioneel", SqlDbType.Int), _
                                                New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                                New SqlParameter("@datumToegevoer", SqlDbType.NVarChar), _
                                                New SqlParameter("@Motors", SqlDbType.Money), _
                                                New SqlParameter("@MotorsBesk", SqlDbType.NVarChar), _
                                                New SqlParameter("@WaterLewe", SqlDbType.Money), _
                                                New SqlParameter("@WaterleweBesk", SqlDbType.NVarChar), _
                                                New SqlParameter("@AlleRisiko", SqlDbType.Money), _
                                                New SqlParameter("@AlleRisikoBesk", SqlDbType.NVarChar), _
                                                New SqlParameter("@HB", SqlDbType.Money), _
                                                New SqlParameter("@HBBesk", SqlDbType.NVarChar), _
                                                New SqlParameter("@HE", SqlDbType.Money), _
                                                New SqlParameter("@HEBesk", SqlDbType.NVarChar), _
                                                New SqlParameter("@HBGras", SqlDbType.Money), _
                                                New SqlParameter("@HBGrasbesk", SqlDbType.NVarChar), _
                                                New SqlParameter("@HEGras", SqlDbType.Money), _
                                                New SqlParameter("@HEGrasBesk", SqlDbType.NVarChar), _
                                                New SqlParameter("@ToevalEEM", SqlDbType.Money), _
                                                New SqlParameter("@ToevalEEMBesk", SqlDbType.NVarChar), _
                                                New SqlParameter("@ToevalBreek", SqlDbType.Money), _
                                                New SqlParameter("@ToevalBreekBesk", SqlDbType.NVarChar), _
                                                New SqlParameter("@Sasria", SqlDbType.Money), _
                                                New SqlParameter("@SasriaBesk", SqlDbType.NVarChar), _
                                                New SqlParameter("@Polisfooi", SqlDbType.Money), _
                                                New SqlParameter("@PolisfooiBesk", SqlDbType.NVarChar), _
                                                New SqlParameter("@Begrafnis", SqlDbType.Money), _
                                                New SqlParameter("@BegrafnisBesk", SqlDbType.NVarChar), _
                                                New SqlParameter("@Plip", SqlDbType.Money), _
                                                New SqlParameter("@PlipBesk", SqlDbType.NVarChar), _
                                                New SqlParameter("@CourtesyV", SqlDbType.Money), _
                                                New SqlParameter("@CourtesyVBesk", SqlDbType.NVarChar), _
                                                New SqlParameter("@EPC", SqlDbType.Money), _
                                                New SqlParameter("@EPCBesk", SqlDbType.NVarChar), _
                                                New SqlParameter("@CareAssist", SqlDbType.Money), _
                                                New SqlParameter("@CareAssistBesk", SqlDbType.NVarChar), _
                                                New SqlParameter("@Selfoon", SqlDbType.Money), _
                                                New SqlParameter("@SelfoonBesk", SqlDbType.NVarChar), _
                                                New SqlParameter("@PakketItem1", SqlDbType.Money), _
                                                New SqlParameter("@PakketItem1besk", SqlDbType.NVarChar), _
                                                New SqlParameter("@SpesialeKorting", SqlDbType.Money), _
                                                New SqlParameter("@SpesialeKortingBesk", SqlDbType.NVarChar), _
                                                New SqlParameter("@Totaal", SqlDbType.Money)}

                ' kry al die velde in die grid se waardes
                param(0).Value = intPkAddisionelePremie
                'Andriette 15/08/2013 v erander na die global polisnommer
                '  param(1).Value = Form1.POLISNO.Text
                param(1).Value = glbPolicyNumber
                ' Andriette die datum word verkeerd gestoor op die tabel
                param(2).Value = Now().ToString.Substring(0, 16)
                ' andriette 12/03/2013 na veranderinge
                For i = 3 To 39 Step 2
                    strbedrag = dgvAddisionelePremie.Rows(intTelRye).Cells(1).Value
                    If strbedrag <> "" Then
                        dblBedrag = CDec(strbedrag)
                    End If
                    param(i).Value = dblBedrag
                    param(i + 1).Value = dgvAddisionelePremie.Rows(intTelRye).Cells(2).Value
                    intwaarde += 1
                    intTelRye = intTelRye + 1
                Next
                strbedrag = dgvAddisionelePremie.Rows(19).Cells(1).Value
                dblBedrag = CDbl(strbedrag)
                ' Andriette 12/03/2013 verander die parameter count
                param(41).Value = dblBedrag
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdateAdditionalPremie]", param)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            'Return Nothing
        End Try

    End Sub


    Function InsertAdditionalPremie1()
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                'Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                'Linkie 02/07/2013 - verander net tipes sodat dit by db aanpas
                Dim param() As SqlParameter = {New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                        New SqlParameter("@datumToegevoer", SqlDbType.DateTime), _
                                         New SqlParameter("@afgesluit", SqlDbType.TinyInt), _
                                         New SqlParameter("@PakketItem2", SqlDbType.Money), _
                                        New SqlParameter("@PakketItem3", SqlDbType.Money), _
                                        New SqlParameter("@PakketItem4", SqlDbType.Money)}
                'Andriette 15/08/2013 verander na die global polisnommer
                '  param(0).Value = Form1.POLISNO.Text
                param(0).Value = glbPolicyNumber
                param(1).Value = (Now)
                param(2).Value = 0
                param(3).Value = 0
                param(4).Value = 0
                param(5).Value = 0

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[InsertIntoAdditionalPremie]", param)
                Return True
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function
    Public Function validateForm() As Boolean
        Dim strbedrag As String = 0
        Dim dblBedrag As Double
        Dim strMessage As String = ""

        'Run through the grid to check the values entered
        validateForm = True

        ' Andriette 13/03/2013 my kode vir validasie van die waardes
        For rowCount = 0 To 20
            strbedrag = dgvAddisionelePremie.Rows(rowCount).Cells(1).Value


            If strbedrag <> "" Then
                dblBedrag = CDec(strbedrag)
            End If

            ' strbedrag = strbedrag.Substring(1, Len(strbedrag) - 1)
            If Not IsNumeric(dblBedrag) Then
                strMessage = strMessage & " " & Trim(dgvAddisionelePremie.Rows(rowCount).Cells(0).Value) & ","
            End If
            ' Andriette 12/03/2013 verander om die sente ook te sien
            'dblbedrag = Val(strBedrag)
        Next

        If Len(strMessage) > 0 Then
            validateForm = False
            MsgBox("The following field(s) must have numeric values " & strMessage, MsgBoxStyle.Exclamation)
        End If

        'Final premium greater than zero
        ' Andriette 04/03/2013 Haal die waardes uit en herskik die indekse
        If Val(dgvAddisionelePremie.Rows(20).Cells(1).Value) < 0 Then
            validateForm = False
            MsgBox("The final premium must be greater than 0.", MsgBoxStyle.Exclamation)
        End If
    End Function

    Private Sub dgvAddisionelePremie_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAddisionelePremie.CellEndEdit

        If e.ColumnIndex = 1 Then
            calcTotals(e.RowIndex)
        End If

    End Sub

    Public Sub calcTotals(Optional intRow As Integer = -1, Optional dblTotalVoor As Double = 0, Optional dblPremieEkstras As Double = 0)
        Dim strBedrag As String
        Dim dblbedrag As Decimal
        Dim dbltotalna As Double = 0
        dbltotaddprem = 0

        Try
            For Me.IntTeller = 0 To 18

                strBedrag = dgvAddisionelePremie.Rows(IntTeller).Cells(1).Value
                If IsNumeric(strBedrag) Then
                    dblbedrag = CDec(strBedrag)
                    If IntTeller = 18 Then
                        ' If x = 20 Then
                        dbltotaddprem = dbltotaddprem - dblbedrag
                    Else
                        dbltotaddprem = dbltotaddprem + dblbedrag
                    End If

                    dgvAddisionelePremie.Rows(IntTeller).Cells(1).Value = FormatNumber(dgvAddisionelePremie.Rows(IntTeller).Cells(1).Value, 2)
                End If
            Next

            dgvAddisionelePremie.DefaultCellStyle.Format = "c"
            dgvAddisionelePremie.Refresh()
            dbltotalna = dbltotaddprem
            dgvAddisionelePremie.Rows(19).Cells(1).Value = FormatNumber(dbltotalna, 2)
            dgvAddisionelePremie.Rows(20).Cells(1).Value = FormatNumber(dbltotalna + Form1.lblMaandeliksePremie.Text - Form1.Verwysingskommissie.Text, 2)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub dgvAddisionelePremie_CellLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAddisionelePremie.CellLeave
        If e.ColumnIndex = 1 Then
            calcTotals(e.RowIndex)
        End If

    End Sub

    'Andriette 03/09/2013 Skep die grid net 1 maal
    Private Sub SkepGrid()
        dgvAddisionelePremie.AllowUserToAddRows = False
        dgvAddisionelePremie.AllowUserToDeleteRows = False
        'Andriette verander na 5 olomme
        'dgvAddisionelePremie.ColumnCount = 6
        dgvAddisionelePremie.ColumnCount = 5
        dgvAddisionelePremie.ColumnHeadersVisible = True

        ' Set the column header style.
        Dim columnHeaderStyle As New DataGridViewCellStyle()

        dgvAddisionelePremie.Columns(0).DefaultCellStyle.ForeColor = Color.Gray
        dgvAddisionelePremie.ColumnHeadersDefaultCellStyle = columnHeaderStyle
        columnHeaderStyle.BackColor = Color.DimGray
        columnHeaderStyle.Font = New Font("Verdana", 8, FontStyle.Bold)

        'First column background
        dgvAddisionelePremie.SelectionMode = DataGridViewSelectionMode.CellSelect
        dgvAddisionelePremie.AutoGenerateColumns = False
        dgvAddisionelePremie.Rows.Clear()

        ' Set the column header names.
        dgvAddisionelePremie.Columns(0).Width = 160
        dgvAddisionelePremie.Columns(0).Selected = False
        dgvAddisionelePremie.Columns(0).ReadOnly = True

        'dgvAddisionelePremie.Columns(1).Name = "Amount"
        'dgvAddisionelePremie.Columns(1).Width = 70
        'dgvAddisionelePremie.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ''dgvAddisionelePremie.Columns(1).DefaultCellStyle.Format = 

        dgvAddisionelePremie.Columns(1).Name = "Totals"
        dgvAddisionelePremie.Columns(1).Width = 70
        dgvAddisionelePremie.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgvAddisionelePremie.Columns(2).Name = "Description"
        dgvAddisionelePremie.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvAddisionelePremie.Columns(2).Visible = True

        dgvAddisionelePremie.Columns(3).Visible = False
        dgvAddisionelePremie.Columns(4).Visible = False

    End Sub


    Private Sub VulGrid(ByVal Voertuig As Double,
                        ByVal Water As Double,
                        ByVal AllRisk As Double,
                        ByVal HB As Double,
                        ByVal HE As Double,
                        ByVal HBGras As Double,
                        ByVal HEGras As Double,
                        ByVal ToevalEEm As Double,
                        ByVal ToevalBreek As Double,
                        ByVal Sasria As Double,
                        ByVal Polis As Double,
                        ByVal Begrafnis As Double,
                        ByVal Plip As Double,
                        ByVal Courtesy As Double,
                        ByVal inhoud As Double,
                        ByVal CareAssist As Double,
                        ByVal Cellphone As Double,
                        ByVal Operarum As Double,
                        ByVal Discount As Double,
                        ByVal TotalAdd As Double,
                        ByVal VoertuigBesk As String,
                        ByVal WaterBesk As String,
                        ByVal AllRiskBesk As String,
                        ByVal HBBesk As String,
                        ByVal HEBesk As String,
                        ByVal HBGrasBesk As String,
                        ByVal HEGrasBesk As String,
                        ByVal ToevalEEmBesk As String,
                        ByVal ToevalBreekBesk As String,
                        ByVal SasriaBesk As String,
                        ByVal PolisBesk As String,
                        ByVal BegrafnisBesk As String,
                        ByVal PlipBesk As String,
                        ByVal Courtesybesk As String,
                        ByVal inhoudBesk As String,
                        ByVal CareAssistBesk As String,
                        ByVal CellphoneBesk As String,
                        ByVal OperarumBesk As String,
                        ByVal DiscountBesk As String,
                        ByVal TotalAddBesk As String)



        'CStr(Format(Val(reader("PREMIE_HB")) * Val(Persoonl.eispers), "######0.00"))

        'Andriette 16/10/2013 haal die afslag uit moet reeds die afslag in berekening he
        'Dim row1() As String = {"+ Vehicles", FormatCurrency(Voertuig * Val(Form1.Combo1.Text), 2), "", VoertuigBesk, "Motors", "MotorsBesk"}
        '    Dim row1() As String = {"+ Vehicles", FormatCurrency(Voertuig, 2), "", VoertuigBesk, "Motors", "MotorsBesk"}
        Dim row1() As String = {"+ Vehicles", FormatNumber(Voertuig, 2), VoertuigBesk, "Motors", "MotorsBesk"}
        ' Andriette 14/03/2013 verander die beskrywing
        'Dim row2() As String = {"+ Aquatic", FormatCurrency(Water, 2), WaterBesk, "Waterlewe", "WaterleweBesk"}
        Dim row2() As String = {"+ Watercraft", FormatNumber(Water, 2), WaterBesk, "Waterlewe", "WaterleweBesk"}
        '  Dim row3() As String = {"", "", FormatNumber((Voertuig + Water), 2), "", ""}

        Dim row3() As String = {"+ Household Contents", FormatNumber(HB, 2), HBBesk, "HB", "HBBesk"}
        Dim row4() As String = {"+ Homeowners", FormatNumber(HE, 2), HEBesk, "HE", "HEBesk"}
        Dim row5() As String = {"+ Household Contents (Thatch)", FormatNumber(HBGras, 2), HBGrasBesk, "HBGras", "HBGrasBesk"}
        Dim row6() As String = {"+ Homeowners (Thatch)", FormatNumber(HEGras, 2), HEGrasBesk, "HEGras", "HEGradBesk"}
        Dim row7() As String = {"+ Accidental Damage(EEM)", FormatNumber(ToevalEEm, 2), ToevalEEmBesk, "ToevalEEM", "ToevalEEMBesk"}
        Dim row8() As String = {"+ Accidental Damage(Breakage)", FormatNumber(ToevalBreek, 2), ToevalBreekBesk, "ToevalBreek", "ToevalBreekBesk"}
        Dim totaal As Decimal = (HB + HE + HBGras + HEGras + ToevalEEm + ToevalBreek)
        ' Dim row10() As String = {"", "", FormatNumber(totaal, 2), "", ""}
        Dim row9() As String = {"+ All risk", FormatNumber(AllRisk, 2), AllRiskBesk, "AlleRisiko", "AlleRisikoBesk"}
        Dim row10() As String = {"+ Sasria", FormatNumber(Sasria, 2), SasriaBesk, "Sasria", "SasriaBesk"}
        Dim row11() As String = {"+ Liability", FormatNumber(Polis, 2), PolisBesk, "Polisfooi", "PolisfooiBesk"}
        Dim row12() As String = {"+ Funeral", FormatNumber(Begrafnis, 2), BegrafnisBesk, "Begrafnis", "BegrafnisBesk"}
        Dim row13() As String = {"+ Personal Liability", FormatNumber(Plip, 2), PlipBesk, "Plip", "PlipBesk"}
        Dim row14() As String = {"+ Courtesy Vehicle", FormatNumber(Courtesy, 2), Courtesybesk, "CourtesyV", "CourtesyVBesk"}
        Dim row15() As String = {"+ Home Assistance", FormatNumber(inhoud, 2), inhoudBesk, "EPC", "EPCBesk"}
        Dim row16() As String = {"+ Roadside Assistance", FormatNumber(CareAssist, 2), CareAssistBesk, "CareAssist", "CareAssistBesk"}
        Dim row17() As String = {"+ Cellphone", FormatNumber(Cellphone, 2), CellphoneBesk, "Selfoon", "SelfoonBesk"}
        Dim row18() As String = {"+ Labour Insurance", FormatNumber(Operarum, 2), OperarumBesk, "PakketItem1", "PakketItem1Besk"}
        totaal = (Sasria + Polis + Begrafnis + Plip + Courtesy + inhoud + CareAssist + Cellphone + Operarum)
        '   Dim row21() As String = {"", "", FormatCurrency(totaal, 2), "", ""}
        Dim row19() As String = {"- Special Discount", FormatNumber(Discount, 2), DiscountBesk, "SpesialeKorting", "SpesialeKortingBesk"}

        Dim row20() As String = {"Total Additional Premium", FormatNumber(TotalAdd, 2), TotalAddBesk, "Totaal", ""}
        Dim row21() As String = {"Total Final Premium", FormatNumber(0, 2)}

        Dim rows() As Object = {row1, row2, row3, row4, row5, row6, row7, row8, row9, row10, row11, row12, row13, row14, row15, _
                                row16, row17, row18, row19, row20, row21}
        dgvAddisionelePremie.AutoGenerateColumns = False
        Dim rowArray As String()

        For Each rowArray In rows
            dgvAddisionelePremie.Rows.Clear()
            dgvAddisionelePremie.AutoGenerateColumns = False
        Next rowArray

        For Each rowArray In rows
            dgvAddisionelePremie.Rows.Add(rowArray)
            dgvAddisionelePremie.AutoGenerateColumns = False
        Next rowArray

        dgvAddisionelePremie.Rows(19).DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold)
        dgvAddisionelePremie.Rows(20).DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold)
    End Sub

    Private Function Huis_totale_premie(dblAfslag As Double) As List(Of Double)
        Dim lstHuise As List(Of HuisEntity) = New List(Of HuisEntity)
        Dim dblPremieTotaal As Double = 0
        Dim dblHE As Double = 0
        Dim dblHB As Double = 0
        Dim dblHEGRas As Double = 0
        Dim dblHBGras As Double = 0
        Dim dblEEM As Double = 0
        Dim dblBreek As Double = 0
        Dim lstPremies As New List(Of Double)
        Dim dblpremie As Decimal = 0

        lstHuise = FetchHuisForPremie()

        For Elkehuis = 0 To lstHuise.Count - 1
            If lstHuise(Elkehuis).Cancelled = "0" Then
                'TotalPremie = CStr(Format(System.Math.Round(reader("premie") * Val(Persoonl.eispers), 2), "######0.00"))
                'dblpremie = CStr(Format(System.Math.Round(lstHuise(Elkehuis).PREMIE_HE * dblAfslag, 2), "######0.00"))
                'dblHE = dblHE + CStr(Format(System.Math.Round(lstHuise(Elkehuis).PREMIE_HE * dblAfslag, 2), "######0.00"))
                dblHE = dblHE + lstHuise(Elkehuis).PREMIE_HE

                ' dblpremie = CStr(Format(System.Math.Round(lstHuise(Elkehuis).PREMIE_HB * dblAfslag, 2), "######0.00"))
                'dblHB = dblHB + CStr(Format(System.Math.Round(lstHuise(Elkehuis).PREMIE_HB * dblAfslag, 2), "######0.00"))
                dblHB = dblHB + lstHuise(Elkehuis).PREMIE_HB

                ' dblpremie = CStr(Format(System.Math.Round(lstHuise(Elkehuis).EEM_PREMIE * dblAfslag, 2), "######0.00"))
                ' dblEEM = dblEEM + CStr(Format(System.Math.Round(lstHuise(Elkehuis).EEM_PREMIE * dblAfslag, 2), "######0.00"))
                dblEEM = dblEEM + lstHuise(Elkehuis).EEM_PREMIE

                'dblpremie = CStr(Format(System.Math.Round(lstHuise(Elkehuis).TOE_PREMIE * dblAfslag, 2), "######0.00"))
                'dblBreek = dblBreek + CStr(Format(System.Math.Round(lstHuise(Elkehuis).TOE_PREMIE * dblAfslag, 2), "######0.00"))
                dblBreek = dblBreek + lstHuise(Elkehuis).TOE_PREMIE

            End If
        Next

        '   dblPremieTotaal = FormatNumber(dblpremie * dblAfslag, 2)
        'lstPremies.Add(FormatNumber(dblHE * dblAfslag, 2))
        'lstPremies.Add(FormatNumber(dblHB * dblAfslag, 2))
        'lstPremies.Add(FormatNumber(dblEEM * dblAfslag, 2))
        'lstPremies.Add(FormatNumber(dblBreek * dblAfslag, 2))
        'Andriette 18/09/2013 laai in sonder die afslag
        lstPremies.Add(FormatNumber(dblHE, 2))
        lstPremies.Add(FormatNumber(dblHB, 2))
        lstPremies.Add(FormatNumber(dblEEM, 2))
        lstPremies.Add(FormatNumber(dblBreek, 2))
        Return lstPremies
    End Function

    Private Function Motors_totale_premie(dblAfslag As Double) As Double
        ' Dim lstVoertuie As List(Of EntityVoertuie) = New List(Of EntityVoertuie)
        Dim lstVoertuie As List(Of VoertuieEntity) = New List(Of VoertuieEntity)
        Dim dblTotaal As Decimal = 0
        Dim dblpremie As Decimal = 0

        lstVoertuie = FetchVoertuieForPremie()
        For ElkeVoertuig = 0 To lstVoertuie.Count - 1
            If lstVoertuie(ElkeVoertuig).cancelled = 0 Then
                'dblTotaal = dblTotaal + lstVoertuie(ElkeVoertuig).premie ' Andriette 09/04/2013
                'Andriette 28/08/2013 verander die manier hoe dit bereken word
                ' dblpremie = lstVoertuie(ElkeVoertuig).premie_voor * dblAfslag
                'dblpremie = FormatNumber(dblpremie, 2)
                ' dblpremie = CStr(Format(System.Math.Round(lstVoertuie(ElkeVoertuig).premie_voor * dblAfslag, 2), "######0.00"))
                'dblpremie = lstVoertuie(ElkeVoertuig).premie_voor
                dblpremie = lstVoertuie(ElkeVoertuig).PREMIE
                dblTotaal = dblTotaal + dblpremie
            End If
        Next
        'dblTotaal = FormatNumber(dblpremie * dblAfslag, 2)
        '  dblTotaal = FormatNumber(dblpremie, 2)
        'Andriette 18/09/2013 laai sonder die afslag
        Return dblTotaal
    End Function

    Private Function AlleRisiko_totale_premie(dblAfslag As Double) As Double
        Dim lstAlleRisiko As List(Of ALLERISKEntity) = New List(Of ALLERISKEntity)
        Dim dblTotaal As Double = 0
        Dim dblpremie As Decimal = 0
        lstAlleRisiko = FetchAllerisikoForPremie()
        For intHierdie = 0 To lstAlleRisiko.Count - 1
            If lstAlleRisiko(intHierdie).cancelled = 0 Then
                dblpremie = lstAlleRisiko(intHierdie).Premie
                dblTotaal = dblTotaal + dblpremie
            End If
        Next
        '    dblTotaal = FormatNumber(dblpremie * dblAfslag, 2)
        Return dblTotaal

    End Function

End Class