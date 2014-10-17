Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports DAL
Friend Class PremieDetail
    Inherits BaseForm

	'Description  : Display the detail of the premium - longterm policy included where applicable

    'Dim rsVoertuie As DAO.Recordset
    'Dim rsProperty As DAO.Recordset
    'Dim rsAr As DAO.Recordset
    'Dim rs As DAO.Recordset
    Dim glbHomeAssistanceDesc As String
    Dim intcounter As Integer
    Const intRows As Integer = 7 'Start grid with number of rows
    Const intCols As Integer = 4 'Number of columns for grid
    Dim introw As Integer = 0
    Dim strTotalvar3 As String
    Dim dblExtrasTermTotal As Double = 0
    Dim dblInsuredItemsTermTotal As Double = 0
    Dim dblPremium As Double = 0
    Dim dblTermcellPhone As Double = 0

    Public termPolicyPremiumDetail()

	Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click
		Me.Close()
	End Sub
	Private Sub PremieDetail_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
   
        'introw = 0
        'introw = introw + 1

        'Set caption
        'Andriette 16/08/2013 gebruik global polisnommer
        '  Me.Text = My.Application.Info.Title & " - Premium detail - " & Form1.TITEL.Text & " " & Form1.form1Voorl.Text & " " & Form1.form1Versekerde.Text & " (" & Form1.form1Polisno.Text & ")"

        Me.Text = My.Application.Info.Title & " - Premium detail - " & Form1.TITEL.Text & " " & Form1.txtForm1Voorl.Text & " " & Form1.txtForm1Versekerde.Text & " (" & glbPolicyNumber & ")"

        dgvPremieUiteensetting.ColumnCount = 3
        Dim columnHeaderStyle As New DataGridViewCellStyle()

        'gridPremie.Columns(0).DefaultCellStyle.ForeColor = Color.Gray

        'columnHeaderStyle.BackColor = Color.DimGray
        columnHeaderStyle.Font = New Font("Arial", 8, FontStyle.Bold)

        'gridPremie.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGreen

        dgvPremieUiteensetting.ColumnHeadersDefaultCellStyle = columnHeaderStyle

        dgvPremieUiteensetting.Columns(0).Width = 370
        dgvPremieUiteensetting.Columns(1).Width = 60
        dgvPremieUiteensetting.Columns(2).Width = 60
        dgvPremieUiteensetting.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPremieUiteensetting.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPremieUiteensetting.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        'DataGridView1.Columns(0).DefaultCellStyle.Font.Style = FontStyle.Bold
        dgvPremieUiteensetting.Columns(0).Selected = False
        'First column background
        dgvPremieUiteensetting.SelectionMode = DataGridViewSelectionMode.CellSelect
        dgvPremieUiteensetting.AutoGenerateColumns = False
        dgvPremieUiteensetting.ReadOnly = True

        introw = 0
        dgvPremieUiteensetting.AutoGenerateColumns = False
        dgvPremieUiteensetting.Refresh()
        dgvPremieUiteensetting.Rows.Clear()

        dgvPremieUiteensetting.Columns(0).Name = "Description"
        dgvPremieUiteensetting.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvPremieUiteensetting.Columns(1).Name = "Monthly"
        dgvPremieUiteensetting.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvPremieUiteensetting.Columns(2).Name = "Term"
        dgvPremieUiteensetting.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvPremieUiteensetting.Enabled = True
        dgvPremieUiteensetting.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dblTermcellPhone = 0
        'Populate grid
        dblInsuredItemsTermTotal = 0
        dblExtrasTermTotal = 0
        populateGrid()
        'Set status

        Me.lblTipePolis.Text = Form1.lbltipepolis.Text

        If Persoonl.BET_WYSE = "6" Then
            Me.lblTermynStatus.Visible = True
            Me.lblTydperk.Visible = True
            Me.Label3.Visible = True
            Me.Label4.Visible = True
            Me.lblTermynStatus.Text = strTermStatusDesc
            Me.lblTydperk.Text = strTermDesc
            dgvPremieUiteensetting.Columns(2).Visible = True
        Else
            Me.lblTermynStatus.Visible = False
            Me.lblTydperk.Visible = False
            Me.Label3.Visible = False
            Me.Label4.Visible = False
            'Andriette 06/08/2014 as dit nie termynpolis is nie verskuil die kolom vir termyn
            dgvPremieUiteensetting.Columns(2).Visible = False
        End If
        'Andriette 18/09/2013 stel die cursor
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    'Populate grid with records from database
    Public Sub populateGrid()
        'Clear grid
        Dim intTermynMaandeOor As Integer = 0
        Me.dgvPremieUiteensetting.Rows.Clear()
        dgvPremieUiteensetting.ColumnCount = 3
        'Andriette 10/07/2014 kry die detail vir 
        If Persoonl.BET_WYSE = "6" Then

            gen_getTermPolicyStatus(Persoonl.POLISNO) 'Vul die entity met die termynpolis data vir die polis
            'Andriette 09/07/2014 gebruik die waardes uit die entity
            '            termPolicyPremiumDetail = gen_getTermPolicyAmtEarned(Persoonl.POLISNO, entLangtermynpolis.DatumBegin, entLangtermynpolis.DatumEindig)
            'Andriette 06/08/2014 die werking het heeltemal verander kry nou net die oorblywende maande terug en bereken die oorblywende premie
            intTermynMaandeOor = baseform_GetTermPolicyMonthsLeft(Persoonl.POLISNO, entLangtermynpolis.DatumBegin, entLangtermynpolis.DatumEindig)
        End If
        If Persoonl.BET_WYSE = 6 Then
            Label6.Text = "Expected Premium breakdown after discount"
            Label2.Text = "Months left"
            lblMaande.Text = FormatNumber(intTermynMaandeOor, 0).ToString
        Else
            Label6.Text = "Premium breakdown after discount"
            Label2.Text = "Month"
            Me.lblMaande.Text = Form1.lbltermynmaande.Text
        End If

        insertProperty(intTermynMaandeOor)
        insertVehicles(intTermynMaandeOor)
        insertAllRisk(intTermynMaandeOor)

        insertCellphones(intTermynMaandeOor)
        insertOther(intTermynMaandeOor)
        If Persoonl.BET_WYSE = 6 Then
            insertFinal()
        End If


        'Set no row as selected (highlighted)
        'Me.gridPremie.row = 0
        'Me.gridPremie.col = 1
    End Sub
    'Insert vehicle detail into grid
    Public Sub insertVehicles(ByVal IntTermynMaandeOor)
        'Dim sSql As Object
        ''Get recordset for vehicles
        Dim strdesc As String
        Dim strTotalPremie As String
        Dim dbltotalTermPremie As Double
        introw = dgvPremieUiteensetting.Rows.Count - 1
        dgvPremieUiteensetting.Rows.Insert(introw, "", "", "")
        introw = introw + 1
        dgvPremieUiteensetting.Rows.Insert(introw, "Vehicles", "", "")
        dgvPremieUiteensetting.Rows(introw).DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold)
        introw = introw + 1
        strdesc = ""

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                param.Value = Persoonl.POLISNO
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchVoertuie_For_PremieDetails2]", param)
                While reader.Read
                    ' andriette 14/03/2013 toets vir die aktiewes wat nognie gekanseleer is nie

                    ' Andriette 28/02/2013 ' As die maak veld leeg is moenie die spasie vooraan sit nie
                    If Not IsDBNull(reader("maak")) Then
                        strdesc = Trim(reader("maak")) & " "
                        If Not IsDBNull(reader("besk")) Then
                            strdesc = strdesc & Trim(reader("besk")) & " "
                            If Not IsDBNull(reader("eeu")) Then
                                strdesc = strdesc & Trim(reader("eeu"))
                                If Not IsDBNull(reader("jaar")) Then
                                    strdesc = strdesc & Trim(reader("jaar")) & " "
                                    If Not IsDBNull(reader("n_plaat")) Then
                                        strdesc = strdesc & Trim(reader("n_plaat")) & " "
                                    End If
                                Else
                                    If Not IsDBNull(reader("n_plaat")) Then
                                        strdesc = strdesc & Trim(reader("n_plaat")) & " "
                                    End If
                                End If
                            Else
                                If Not IsDBNull(reader("jaar")) Then
                                    strdesc = strdesc & Trim(reader("jaar")) & " "
                                    If Not IsDBNull(reader("n_plaat")) Then
                                        strdesc = strdesc & Trim(reader("n_plaat")) & " "
                                    End If
                                Else
                                    If Not IsDBNull(reader("n_plaat")) Then
                                        strdesc = strdesc & Trim(reader("n_plaat")) & " "
                                    End If
                                End If
                            End If
                        Else
                            If Not IsDBNull(reader("eeu")) Then
                                strdesc = strdesc & Trim(reader("eeu"))
                                If Not IsDBNull(reader("jaar")) Then
                                    strdesc = strdesc & Trim(reader("jaar")) & " "
                                    If Not IsDBNull(reader("n_plaat")) Then
                                        strdesc = strdesc & Trim(reader("n_plaat")) & " "
                                    End If
                                Else
                                    If Not IsDBNull(reader("n_plaat")) Then
                                        strdesc = strdesc & Trim(reader("n_plaat")) & " "
                                    End If
                                End If
                            Else
                                If Not IsDBNull(reader("jaar")) Then
                                    strdesc = strdesc & Trim(reader("jaar")) & " "
                                    If Not IsDBNull(reader("n_plaat")) Then
                                        strdesc = strdesc & Trim(reader("n_plaat")) & " "
                                    End If
                                Else
                                    If Not IsDBNull(reader("n_plaat")) Then
                                        strdesc = strdesc & Trim(reader("n_plaat")) & " "
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If Not IsDBNull(reader("besk")) Then
                            strdesc = strdesc & Trim(reader("besk")) & " "
                            If Not IsDBNull(reader("eeu")) Then
                                strdesc = strdesc & Trim(reader("eeu"))
                                If Not IsDBNull(reader("jaar")) Then
                                    strdesc = strdesc & Trim(reader("jaar")) & " "
                                    If Not IsDBNull(reader("n_plaat")) Then
                                        strdesc = strdesc & Trim(reader("n_plaat")) & " "
                                    End If
                                Else
                                    If Not IsDBNull(reader("n_plaat")) Then
                                        strdesc = strdesc & Trim(reader("n_plaat")) & " "
                                    End If
                                End If
                            Else
                                If Not IsDBNull(reader("jaar")) Then
                                    strdesc = strdesc & Trim(reader("jaar")) & " "
                                    If Not IsDBNull(reader("n_plaat")) Then
                                        strdesc = strdesc & Trim(reader("n_plaat")) & " "
                                    End If
                                Else
                                    If Not IsDBNull(reader("n_plaat")) Then
                                        strdesc = strdesc & Trim(reader("n_plaat")) & " "
                                    End If

                                End If
                            End If
                        Else
                            If Not IsDBNull(reader("eeu")) Then
                                strdesc = strdesc & Trim(reader("eeu"))
                                If Not IsDBNull(reader("jaar")) Then
                                    strdesc = strdesc & Trim(reader("jaar")) & " "
                                    If Not IsDBNull(reader("n_plaat")) Then
                                        strdesc = strdesc & Trim(reader("n_plaat")) & " "
                                    End If
                                Else
                                    If Not IsDBNull(reader("n_plaat")) Then
                                        strdesc = strdesc & Trim(reader("n_plaat")) & " "
                                    End If
                                End If
                            Else
                                If Not IsDBNull(reader("jaar")) Then
                                    strdesc = strdesc & Trim(reader("jaar")) & " "
                                    If Not IsDBNull(reader("n_plaat")) Then
                                        strdesc = strdesc & Trim(reader("n_plaat")) & " "
                                    End If
                                Else
                                    If Not IsDBNull(reader("n_plaat")) Then
                                        strdesc = strdesc & Trim(reader("n_plaat")) & " "
                                    End If

                                End If
                            End If
                        End If
                    End If

                    strTotalPremie = CStr(Format(System.Math.Round(reader("premie") * Val(Persoonl.eispers), 2), "######0.00"))
                    'Andriette 06/08/2014 verander die termynpolis gedeelte van die premiedetail
                    If Persoonl.BET_WYSE = 6 Then
                        dbltotalTermPremie = strTotalPremie * IntTermynMaandeOor
                        dgvPremieUiteensetting.Rows.Insert(introw, strdesc, FormatNumber(strTotalPremie, 2), FormatNumber(dbltotalTermPremie, 2), introw)
                        dblInsuredItemsTermTotal = dblInsuredItemsTermTotal + dbltotalTermPremie
                    Else
                        dgvPremieUiteensetting.Rows.Insert(introw, strdesc, FormatNumber(strTotalPremie, 2), "N/A", introw)
                    End If
                    introw = introw + 1
                End While
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    'Insert property detail into grid
    Public Sub insertProperty(ByVal IntTermynMaandeOor)
        Dim strpropertyDesc As String
        'Andriette 28/08/2013 vir presiese berekening van die premies 
        Dim dblHEPrem As Decimal = 0
        Dim dblHOPrem As Decimal = 0
        Dim dblACCPrem As Decimal = 0
        Dim dblEEMPrem As Decimal = 0
        Dim dblHETermPrem As Decimal = 0
        Dim dblHOTermPrem As Decimal = 0
        Dim dblACCTermPrem As Decimal = 0
        Dim dblEEMTermPrem As Decimal = 0

        ' Dim desc As String
        ' introw = introw + 1

        introw = dgvPremieUiteensetting.Rows.Count - 1
        ''gridPremie.Rows.Insert(introw, "", "", "")
        'introw = introw + 1
        dgvPremieUiteensetting.Rows.Insert(introw, "Properties", "", "")
        dgvPremieUiteensetting.Rows(introw).DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold)
        introw = introw + 1

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)

                param.Value = Persoonl.POLISNO

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchHuisByPersoon_For_Premie]", param)

                While reader.Read()

                    ' Andriette 14/03/2013 Voeg 'n filter in vir onaktiewe huise
                    If reader("cancelled") IsNot DBNull.Value Then
                        If reader("Cancelled") = 0 Then
                            strpropertyDesc = StrConv(reader("ADRES_H1") & " " & reader("Adres4") & " " & reader("voorstad"), VbStrConv.ProperCase)

                            If reader("WAARDE_HE") > 0 Or reader("PREMIE_HE") > 0 Then
                                'i = i + 1
                                'introw = introw + 1
                                'Me.gridPremie.Rows.Add(+1) '= Me.gridPremie.Rows + 1
                                'Andriette 28/08/2013 herbereken die premie
                                'Me.txtPremieNaKortingHB.Text = CStr(Format(Val(Me.Premie_HB.Text) * Val(Persoonl.eispers), "######0.00"))    'K
                                'Me.txtPremieNaKortingHE.Text = CStr(Format(System.Math.Round(Val(Me.HE_Premie.Text) * Val(Persoonl.eispers), 2), "######0.00"))    'K
                                'Andriette 18/09/2013 verander die berekening om dieselfde te wees as op die huis vorm
                                dblHEPrem = CStr(Format(System.Math.Round(Val(reader("PREMIE_HE")) * Val(Persoonl.eispers), 2), "######0.00"))
                                'Andriette 06/08/2014 termynpolis
                                If Persoonl.BET_WYSE = 6 Then
                                    dblHETermPrem = dblHEPrem * IntTermynMaandeOor
                                    dgvPremieUiteensetting.Rows.Insert(introw, "Homeowner: " & strpropertyDesc, dblHEPrem, FormatNumber(dblHETermPrem, 2), introw)
                                    dblInsuredItemsTermTotal = dblInsuredItemsTermTotal + dblHETermPrem
                                Else
                                    dgvPremieUiteensetting.Rows.Insert(introw, "Homeowner: " & strpropertyDesc, dblHEPrem, "N/A", introw)
                                End If
                                '    dHEPrem = CStr(dHEPrem.ToString("######0.00"))

                                'gridPremie.Rows.Insert(introw, "Home Owner: " & propertyDesc, Format(CStr(reader("PREMIE_HE") * Persoonl.eispers)), "N/A", introw)
                                'insertDetailRow("Huiseienaars: " & propertyDesc, CStr(rsProperty.PREMIE_HE * Persoonl.eispers))
                            End If
                            'House contents
                            If reader("WAARDE_HB") > 0 Or reader("PREMIE_HB") > 0 Then
                                'Andriette 28/08/2013 herbereken die premie
                                'Andriette 18/09/2013 verander die berekening om dieselfde te wees as op die huis vorm
                                dblHOPrem = CStr(Format(Val(reader("PREMIE_HB")) * Val(Persoonl.eispers), "######0.00"))
                                If Persoonl.BET_WYSE = 6 Then
                                    dblHOTermPrem = dblHOPrem * IntTermynMaandeOor
                                    dblInsuredItemsTermTotal = dblInsuredItemsTermTotal + dblHOTermPrem
                                    dgvPremieUiteensetting.Rows.Insert(introw, "Household contents: " & strpropertyDesc, dblHOPrem, FormatNumber(dblHOTermPrem, 2), introw)
                                Else
                                    dgvPremieUiteensetting.Rows.Insert(introw, "Household contents: " & strpropertyDesc, dblHOPrem, "N/A", introw)
                                End If
                                ' insertDetailRow("Huishoudelike inhoud: " & propertyDesc, CStr(rsProperty.PREMIE_HB * Persoonl.eispers))
                            End If
                            'Accicdental loss(EEM)
                            If reader("eem_waarde") > 0 Or reader("eem_premie") > 0 Then
                                'i = i + 1
                                'introw = introw + 1
                                ' Me.gridPremie.Rows.Add(+1) ' = Me.gridPremie.Rows + 1
                                'Andriette 28/08/2013 herbereken die premie
                                dblEEMPrem = CStr(Format(System.Math.Round(reader("eem_premie") * Val(Persoonl.eispers), 2), "######0.00"))
                                If Persoonl.BET_WYSE = 6 Then
                                    dblEEMTermPrem = dblEEMPrem * IntTermynMaandeOor
                                    dgvPremieUiteensetting.Rows.Insert(introw, "Accidental Damage(EEM): " & strpropertyDesc, dblEEMPrem, FormatNumber(dblEEMTermPrem, 2), introw)
                                Else
                                    dgvPremieUiteensetting.Rows.Insert(introw, "Accidental Damage(EEM): " & strpropertyDesc, dblEEMPrem, "N/A", introw)
                                End If
                            End If
                            'Accidental loss(Breakage)
                            If reader("toe_waarde") > 0 Or reader("toe_premie") > 0 Then
                                'i = i + 1
                                'introw = introw + 1
                                ' Me.gridPremie.Rows.Add(+1) ' = Me.gridPremie.Rows + 1
                                'Andriette 28/08/2013 herbereken die premie
                                dblACCPrem = CStr(Format(System.Math.Round(reader("toe_premie") * Val(Persoonl.eispers), 2), "######0.00"))
                                If Persoonl.BET_WYSE = 6 Then
                                    dblACCTermPrem = dblACCPrem * IntTermynMaandeOor
                                    dgvPremieUiteensetting.Rows.Insert(introw, "Accidental Damage (Breakage): " & strpropertyDesc, dblACCPrem, FormatNumber(dblACCTermPrem, 2), introw)
                                Else
                                    dgvPremieUiteensetting.Rows.Insert(introw, "Accidental Damage (Breakage): " & strpropertyDesc, dblACCPrem, "N/A", introw)
                                End If
                            End If
                            introw = introw + 1
                        End If
                    End If
                End While
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    'Insert the detail for the current row
    Public Sub insertDetailRow(ByRef description As String, ByRef premium As String, Optional ByRef termPremium As Double = 0, Optional ByRef heading As Boolean = False)
        'Me.gridPremie.Rows = Me.gridPremie.Rows + 1
        'Me.gridPremie.Columns(0).Name = ("")
        'Me.gridPremie.Columns(1).Name = (description)
        If premium <> "" Then
            If Trim(premium) = "" Then
                premium = "0"
            End If

            Me.dgvPremieUiteensetting.Columns(2).Name = (Format(Val(premium), "0.00"))

            'Check for longterm policies
            If Trim(Persoonl.BET_WYSE) = "6" Then
                If termPremium <> 0 Then
                    Me.dgvPremieUiteensetting.Columns(3).Name = (Format(termPremium, "0.00"))
                Else
                    If IsNumeric(Form1.lbltermynmaande.Text) Then
                        Me.dgvPremieUiteensetting.Columns(3).Name = (Format(Val(CStr(CDbl(premium) * CDbl(Form1.lbltermynmaande.Text))), "0.00"))
                    End If
                End If
            Else
                Me.dgvPremieUiteensetting.Columns(3).Name = "N/A"
            End If
        End If
    End Sub
    'Insert ar detail into grid
    Public Sub insertAllRisk(ByVal IntTermynMaandeOor)
        Dim dblprem As Decimal
        Dim dblTermPrem As Double

        introw = dgvPremieUiteensetting.Rows.Count - 1
        dgvPremieUiteensetting.Rows.Insert(introw, "", "", "")
        introw = introw + 1
        dgvPremieUiteensetting.Rows.Insert(introw, "All Risk", "", "")
        dgvPremieUiteensetting.Rows(introw).DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold)
        introw = introw + 1
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                param.Value = Persoonl.POLISNO

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchAlleriskByPolisno]", param)

                While reader.Read()
                    'Andriette 24/07/2013 verander die toets
                    ' If reader("Premie") = "" then
                    'Andriette 13/08/2013 maak die toets reg
                    ' If Not IsDBNull(reader("Premie")) OrElse reader("Premie") = 0 Then
                    If IsDBNull(reader("Premie")) OrElse reader("Premie") = 0 Then
                        dblprem = 0
                    Else
                        dblprem = reader("Premie")
                    End If
                    dblprem = dblprem * Persoonl.eispers

                    If Persoonl.BET_WYSE = 6 Then
                        dblTermPrem = dblprem * IntTermynMaandeOor
                        dgvPremieUiteensetting.Rows.Insert(introw, reader("beskryf"), FormatNumber(dblprem, 2), FormatNumber(dblTermPrem, 2))
                        dblInsuredItemsTermTotal = dblInsuredItemsTermTotal + dblTermPrem
                    Else
                        dgvPremieUiteensetting.Rows.Insert(introw, reader("beskryf"), FormatNumber(dblprem, 2), "N/A")
                    End If
                    'gridPremie.Rows.Insert(introw, reader("beskryf"), FormatNumber((dblprem * Persoonl.eispers), 2), "N/A")
                    introw = introw + 1
                End While
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub insertLiability()
        Dim termPremDetail(17) As Double
        ' Dim dateStart As Date
        ' Dim dateEnd As Date
        '  Dim Months As Byte
        Dim TermDesc As String = ""
        Dim StatusDesc As String = ""
        '  Dim TermStatus As Byte

        'Andriette 09/07/2014 verander die funksie om net 1 parameter te gebruik en dan die entity te vul met die data
        ' gen_getTermPolicyStatus(Persoonl.BET_WYSE, Persoonl.POLISNO, dateStart, dateEnd, Months, TermDesc, StatusDesc, TermStatus)
        'Andriette 10/07/2014 skuif na 
        'gen_getTermPolicyStatus(Persoonl.POLISNO)
        ''  gen_getTermPolicyAmtEarned(Persoonl.POLISNO, dateStart, dateEnd, termPremDetail)
        ''Andriette 09/07/2014 gebruik die waardes uit die entity
        '' gen_getTermPolicyAmtEarned(Persoonl.POLISNO, dateStart, dateEnd, termPremDetail)
        'termPremDetail = gen_getTermPolicyAmtEarned(Persoonl.POLISNO, EntLangtermynpolis.DatumBegin, EntLangtermynpolis.DatumEindig)
        'gridPremie.Rows.Insert(introw, "Personal Liability", (Form1.form1Plip2.Text), IIf(Trim(Persoonl.BET_WYSE = "6"), termPremDetail(6), "N/A"), introw)

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim param As New SqlParameter("@area_kode", SqlDbType.NVarChar)
                param.Value = Persoonl.Area
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchAreakodeByArea]", param)
                If reader.Read Then
                    'If reader("Autoassist") = "Padbystand" Then
                    '    gridPremie.Rows.Add("Home Assistance", FormatNumber(Form1.form1Careass.Text, 2), IIf(Trim(Persoonl.BET_WYSE) = "6", FormatNumber(termPremDetail(7), 2), "N/A"), introw)
                    'Else
                    '    gridPremie.Rows.Add(reader("AutoassistENG"), FormatNumber(Form1.form1Careass.Text, 2), IIf(Trim(Persoonl.BET_WYSE) = "6", FormatNumber(termPremDetail(7), 2), "N/A"), introw)
                    'End If
                    ''gridPremie.Rows.Add(reader("Autoassist"), FormatNumber(Form1.form1Careass.Text, 2), IIf(Trim(Persoonl.BET_WYSE) = "6", FormatNumber(termPremDetail(7), 2), "N/A"), introw)
                    dgvPremieUiteensetting.Rows.Add(strglbPakketItem1BeskEng, FormatNumber(Form1.lblForm1Pakket1Prem.Text, 2), IIf(Trim(Persoonl.BET_WYSE = "6"), FormatNumber(termPremDetail(14), 2), "N/A"), introw)
                    intcounter = intcounter + 1
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        dgvPremieUiteensetting.Refresh()

    End Sub
    Public Sub insertOther(ByVal IntTermynMaandeOor)
        Dim dblTermPremie As Double = 0
        Dim strTermvalue As String = "N/A"
        Dim dblPremiewaarde As Double = 0

        introw = dgvPremieUiteensetting.Rows.Count - 1
        dgvPremieUiteensetting.Rows.Insert(introw, "", "", "")
        introw = introw + 1
        ' Andriette 15/03/2013 verander die bewoording
        'gridPremie.Rows.Insert(introw, "Policy Package", "", "")
        dgvPremieUiteensetting.Rows.Insert(introw, "Extras", "", "")
        dgvPremieUiteensetting.Rows(introw).DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold)
        introw = introw + 1
        If Persoonl.BET_WYSE = 6 Then
            dblTermPremie = Form1.lblForm1Label36.Text * IntTermynMaandeOor
            dblExtrasTermTotal = dblExtrasTermTotal + dblTermPremie
            strTermvalue = FormatNumber(dblTermPremie, 2).ToString
        End If
        dgvPremieUiteensetting.Rows.Insert(introw, "Sasria ", FormatNumber(Form1.lblForm1Label36.Text, 2), strTermvalue, introw)

        intcounter = intcounter + 1
        introw = introw + 1

        ' Andriette 15/03/2013 skuif na hier
        'gridPremie.Rows.Insert(introw, "Liability", FormatNumber((Form1.form1LiabilityPrem.Text), 2), IIf(Trim(Persoonl.BET_WYSE = "6"), FormatNumber(termPolicyPremiumDetail(4), 2), "N/A"), introw)
        If Persoonl.BET_WYSE = 6 Then
            dblTermPremie = Form1.txtForm1LiabilityPrem.Text * IntTermynMaandeOor
            strTermvalue = FormatNumber(dblTermPremie, 2).ToString
            dblExtrasTermTotal = dblExtrasTermTotal + dblTermPremie
        End If
        dgvPremieUiteensetting.Rows.Insert(introw, "Liability", FormatNumber((Form1.txtForm1LiabilityPrem.Text), 2), strTermvalue, introw)
        intcounter = intcounter + 1
        introw = introw + 1
        'gridPremie.Rows.Insert(introw, "Personal Liability", (Form1.form1Plip2.Text), IIf(Trim(Persoonl.BET_WYSE = "6"), termPolicyPremiumDetail(6), "N/A"), introw)
        If Persoonl.BET_WYSE = 6 Then
            'andriette 15/08/2014 maak eroor reg
            Dim strWaarde As String = Form1.cmbForm1Plip2.Text
            Dim dblWaarde As Double = 0
            If strWaarde <> "" Then
                dblWaarde = Val(strWaarde)
                dblTermPremie = dblWaarde * IntTermynMaandeOor
            Else
                dblTermPremie = 0
            End If
        Else
            dblTermPremie = 0
        End If
        strTermvalue = FormatNumber(dblTermPremie, 2).ToString
        dblExtrasTermTotal = dblExtrasTermTotal + dblTermPremie

        If Form1.cmbForm1Plip2.Text = "" Then
            dgvPremieUiteensetting.Rows.Insert(introw, "Personal Liability", FormatNumber(0, 2), strTermvalue, introw)
        Else
            dgvPremieUiteensetting.Rows.Insert(introw, "Personal Liability", FormatNumber(Form1.cmbForm1Plip2.Text, 2), strTermvalue, introw)
        End If

        'dgvPremieUiteensetting.Rows.Insert(introw, "Personal Liability", (Form1.cmbForm1Plip2.Text), strTermvalue, introw)
        intcounter = intcounter + 1
        introw = introw + 1
        'gridPremie.Rows.Add(glbPakketItem1BeskEng, FormatNumber(Form1.form1Pakket1Prem.Text, 2), IIf(Trim(Persoonl.BET_WYSE = "6"), FormatNumber(termPolicyPremiumDetail(14), 2), "N/A"), introw)
        If Persoonl.BET_WYSE = 6 Then
            dblTermPremie = Form1.lblForm1Pakket1Prem.Text * IntTermynMaandeOor
            strTermvalue = FormatNumber(dblTermPremie, 2).ToString
            dblExtrasTermTotal = dblExtrasTermTotal + dblTermPremie
        End If
        dgvPremieUiteensetting.Rows.Add(strglbPakketItem1BeskEng, FormatNumber(Form1.lblForm1Pakket1Prem.Text, 2), strTermvalue, introw)
        intcounter = intcounter + 1
        introw = introw + 1
        'gridPremie.Rows.Insert(introw, "TV Service Contract", (Form1.form1Label18.Text), IIf(Trim(Persoonl.BET_WYSE = "6"), termPremDetail(3), "N/A"), introw)
        'i = i + 1

        If Form1.txtForm1CourtesyPrem.Text.Trim <> "" Then
            If Persoonl.BET_WYSE = 6 Then
                dblTermPremie = (Form1.txtForm1CourtesyPrem).Text * IntTermynMaandeOor
                strTermvalue = FormatNumber(dblTermPremie, 2).ToString
                dblExtrasTermTotal = dblExtrasTermTotal + dblTermPremie
            End If
            dgvPremieUiteensetting.Rows.Insert(introw, "Courtesy Vehicle", FormatNumber((Form1.txtForm1CourtesyPrem).Text, 2), strTermvalue, introw)
        Else
            If Persoonl.BET_WYSE = 6 Then
                strTermvalue = FormatNumber(0, 2).ToString
            End If
            dgvPremieUiteensetting.Rows.Insert(introw, "Courtesy Vehicle", FormatNumber(0, 2), strTermvalue, introw)
        End If

        intcounter = intcounter + 1
        introw = introw + 1
        If Form1.txtForm1HomeAsst.Text.Trim <> "" Then
            If Persoonl.BET_WYSE = 6 Then
                dblTermPremie = Form1.txtForm1HomeAsst.Text * IntTermynMaandeOor
                strTermvalue = FormatNumber(dblTermPremie, 2).ToString
                dblExtrasTermTotal = dblExtrasTermTotal + dblTermPremie
            End If
            dgvPremieUiteensetting.Rows.Insert(introw, "Home Assistance", FormatNumber((Form1.txtForm1HomeAsst.Text), 2), strTermvalue, "N/A", introw)
        Else
            If Persoonl.BET_WYSE = 6 Then
                dblTermPremie = 0
                strTermvalue = FormatNumber(dblTermPremie, 2).ToString
            End If
            dgvPremieUiteensetting.Rows.Insert(introw, "Home Assistance", FormatNumber(0, 2), strTermvalue, introw)
        End If

        intcounter = intcounter + 1
        introw = introw + 1
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@area_kode", SqlDbType.NVarChar)
                param.Value = Persoonl.Area
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchAreakodeByArea]", param)
                If reader.Read Then
                    'gridPremie.Rows.Add(reader("AutoassistEng"), FormatNumber(Form1.form1RoadsidePrem.Text, 2), IIf(Trim(Persoonl.BET_WYSE = "6"), FormatNumber(termPolicyPremiumDetail(7), 2), "N/A"), introw)
                    If Persoonl.BET_WYSE = 6 Then
                        dblTermPremie = Form1.txtForm1RoadsidePrem.Text * IntTermynMaandeOor
                        strTermvalue = FormatNumber(dblTermPremie, 2).ToString
                        dblExtrasTermTotal = dblExtrasTermTotal + dblTermPremie
                    End If
                    dgvPremieUiteensetting.Rows.Add(reader("AutoassistEng"), FormatNumber(Form1.txtForm1RoadsidePrem.Text, 2), strTermvalue, introw)

                    intcounter = intcounter + 1
                    introw = introw + 1
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception

        End Try
        If Form1.lblForm1Label35.Text.Trim <> "" Then
            If Persoonl.BET_WYSE = 6 Then
                dblTermPremie = Form1.lblForm1Label35.Text * IntTermynMaandeOor
                strTermvalue = FormatNumber(dblTermPremie, 2).ToString
                dblExtrasTermTotal = dblExtrasTermTotal + dblTermPremie
            End If
            'gridPremie.Rows.Insert(introw, "Funeral Policy", FormatNumber((Form1.form1Label35.Text), 2), IIf(Trim(Persoonl.BET_WYSE = "6"), FormatNumber(termPolicyPremiumDetail(5), 2), "N/A"), introw)
            dgvPremieUiteensetting.Rows.Insert(introw, "Funeral Policy", FormatNumber((Form1.lblForm1Label35.Text), 2), strTermvalue, introw)
        Else
            If Persoonl.BET_WYSE = 6 Then
                strTermvalue = FormatNumber(0, 2).ToString
            End If
            'gridPremie.Rows.Insert(introw, "Funeral Policy", FormatNumber(0, 2), IIf(Trim(Persoonl.BET_WYSE = "6"), FormatNumber(termPolicyPremiumDetail(5), 2), "N/A"), introw)
            dgvPremieUiteensetting.Rows.Insert(introw, "Funeral Policy", FormatNumber(0, 2), strTermvalue, introw)
        End If

        intcounter = intcounter + 1
        introw = introw + 1
        introw = dgvPremieUiteensetting.Rows.Count - 1
        'gridPremie.Rows.Insert(introw, "", "", "")
        'introw = introw + 1
        dgvPremieUiteensetting.Rows.Add("Total Extras ", FormatNumber(Form1.lblForm1PolisPakketTotaal.Text, 2), IIf(Trim(Persoonl.BET_WYSE = "6"), FormatNumber(dblExtrasTermTotal, 2), "N/A"), True)
        dgvPremieUiteensetting.Rows(introw).DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold)
        introw = introw + 1

        dgvPremieUiteensetting.Rows.Add("Subtotal Insured Items", FormatNumber(Form1.lblForm1SubtotaalNaKorting.Text, 2), IIf(Trim(Persoonl.BET_WYSE = "6"), FormatNumber(dblInsuredItemsTermTotal, 2), "N/A"))
        intcounter = intcounter + 1
        ' Andriette 15/03/2013 haal hier uit
        'gridPremie.Rows.Add("Cellphone insurance", FormatNumber(Form1.form1Selfoon.Text, 2), IIf(Trim(Persoonl.BET_WYSE = "6"), FormatNumber(termPremDetail(11), 2), "N/A"), introw)
        'i = i + 1

        introw = dgvPremieUiteensetting.Rows.Count - 1
        dgvPremieUiteensetting.Rows.Insert(introw, "", "", "")
        introw = introw + 1
        dblTermPremie = Val(Form1.lblForm1MaandeliksePremie.Text) * IntTermynMaandeOor
        dgvPremieUiteensetting.Rows.Add("Monthly Premium", FormatNumber(Form1.lblForm1MaandeliksePremie.Text, 2), IIf(Trim(Persoonl.BET_WYSE = "6"), FormatNumber(dblTermPremie, 2), "N/A"), True)
        dgvPremieUiteensetting.Rows(introw).DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold)
        introw = introw + 1

        'gridPremie.Rows.Add("Protection Service", (Form1.form1Label16.Text), IIf(Trim(Persoonl.BET_WYSE = "6"), termPremDetail(1), "n.v.t"), introw)
        'i = i + 1

        dgvPremieUiteensetting.Rows.Add("Special discount", FormatNumber(Form1.lblForm1Verwysingskommissie.Text, 2), IIf(Trim(Persoonl.BET_WYSE = "6"), FormatNumber(0, 2), "N/A"))
        intcounter = intcounter + 1
        dgvPremieUiteensetting.Rows.Add("Additional premium", FormatNumber(Form1.btnForm1AddisionelePremie.Text, 2), IIf(Trim(Persoonl.BET_WYSE = "6"), FormatNumber(0, 2), "N/A"))
        intcounter = intcounter + 1
        introw = dgvPremieUiteensetting.Rows.Count - 1
        dgvPremieUiteensetting.Rows.Insert(introw, "", "", "")
        introw = introw + 1
        dblPremium = dblExtrasTermTotal + dblTermcellPhone + dblInsuredItemsTermTotal
        dgvPremieUiteensetting.Rows.Add("Premium Payable (including VAT at 14%)", FormatNumber(Form1.lblForm1Premie2.Text, 2), IIf(Trim(Persoonl.BET_WYSE = "6"), FormatNumber(dblExtrasTermTotal + dblInsuredItemsTermTotal + dblTermcellPhone, 2), "N/A"), True)
        dgvPremieUiteensetting.Rows(introw).DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold)
        introw = introw + 1
        dgvPremieUiteensetting.Refresh()

    End Sub



        '* Purpose  : insert the details of all cellphones
        '* Outputs  : Insert records in grid
    Public Sub insertCellphones(ByVal IntTermynMaandeOor)
        'Dim sSql As Object
        Dim strBeskrywing As String = ""
        Dim dblCellPremie As Double = 0
        Dim dblCellTermPremie As Double = 0

        Try
            introw = dgvPremieUiteensetting.Rows.Count - 1
            dgvPremieUiteensetting.Rows.Insert(introw, "", "", "")
            introw = introw + 1
            ' Andriette 27/02/2013 maak woord reg
            dgvPremieUiteensetting.Rows.Insert(introw, "Cellphone insurance", "", "")
            dgvPremieUiteensetting.Rows(introw).DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold)
            introw = introw + 1

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@POLISNO", SqlDbType.NVarChar)
                param.Value = glbPolicyNumber

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[insCELL].[FetchInsCellForDetails]", param)

                While reader.Read()
                    strBeskrywing = reader("phone_make") & " " & reader("phone_model")
                    dblCellPremie = reader("Premie")
                    If Persoonl.BET_WYSE = 6 Then
                        dblCellTermPremie = dblCellPremie * IntTermynMaandeOor
                        dgvPremieUiteensetting.Rows.Insert(introw, strBeskrywing, FormatNumber(dblCellPremie, 2), IIf(Trim(Persoonl.BET_WYSE = "6"), FormatNumber(dblCellTermPremie, 2), "N/A"))
                        dblTermcellPhone = dblTermcellPhone + dblCellTermPremie
                        'Else
                        '    dgvPremieUiteensetting.Rows.Insert(introw, strBeskrywing, FormatNumber(dblCellPremie, 2), IIf(Trim(Persoonl.BET_WYSE = "6"), FormatNumber(dblCellTermPremie, 2), "N/A"))
                    End If

                    introw = introw + 1
                End While
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub InsertFinal()
        Dim dblTotalPaid As Double = 0
        Dim dblBalance As Double = 0
        Dim dblraised As Double = 0
        introw = dgvPremieUiteensetting.Rows.Count - 1
        Try
            Using conn As SqlConnection = SqlHelper.GetConnection

                Dim params() As SqlParameter = {New SqlParameter("@vanaf", SqlDbType.DateTime), _
                                                New SqlParameter("@tot", SqlDbType.DateTime), _
                                                New SqlParameter("@polisno", SqlDbType.NVarChar)}

                params(0).Value = entLangtermynpolis.DatumBegin
                params(1).Value = entLangtermynpolis.DatumEindig
                params(2).Value = glbPolicyNumber
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchKontantByTrans_Dat", params)
                If reader.HasRows Then
                    Do While reader.Read
                        If reader("vord_premie") IsNot DBNull.Value Then
                            dblTotalPaid = dblTotalPaid + reader("vord_premie")
                        End If
                    Loop
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using

            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params2() As SqlParameter = {New SqlParameter("@polisno", SqlDbType.NVarChar), _
                                                 New SqlParameter("@category", SqlDbType.NVarChar), _
                                                 New SqlParameter("@StartDate", SqlDbType.DateTime), _
                                                 New SqlParameter("@end_date", SqlDbType.DateTime)}

                params2(0).Value = glbPolicyNumber
                params2(1).Value = "LT"
                params2(2).Value = entLangtermynpolis.DatumBegin
                params2(3).Value = entLangtermynpolis.DatumEindig
                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "stats5.FetchAlletipesTransaksiesByPolisnoStatus", params2)
                If reader.HasRows Then
                    Do While reader.Read
                        If reader("Tabel") IsNot DBNull.Value Then
                            If reader("Tabel") = "maand" Then
                                If reader("premie") IsNot DBNull.Value Then
                                    dblraised = dblraised + reader("premie")
                                End If
                            End If
                        End If
                    Loop
                End If
            End Using

            dgvPremieUiteensetting.Rows.Add("Paid in this period", "", FormatNumber(dblTotalPaid, 2), introw)
            introw = introw + 1
            dgvPremieUiteensetting.Rows.Add("Raised and Potential for this period", "", FormatNumber(dblPremium + dblraised, 2), introw)
            introw = introw + 1
            dblBalance = dblTotalPaid - dblPremium - dblraised
            dgvPremieUiteensetting.Rows.Add("Balance", "", FormatNumber(dblBalance, 2), introw)
            dgvPremieUiteensetting.Rows(introw).DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold)
            '  introw = introw + 1

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try


    End Sub

End Class