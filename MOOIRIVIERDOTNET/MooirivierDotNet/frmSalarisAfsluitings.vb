Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Data.SqlClient
Imports DAL

Friend Class frmSalarisAfsluitings
    Inherits BaseForm

    'Description  : PUK salaris afsluiting moet direkte metode gebruik word.
    Dim i As Integer
    Dim k As Integer
    Dim serverPath As String
    Dim docDir As String
    Dim Temp As String
    'Dim xlapp As Microsoft.Office.Interop.Excel.Application
    'Dim xlbook As Microsoft.Office.Interop.Excel.Workbook
    'Dim xlsheet As Microsoft.Office.Interop.Excel.Worksheet
    'Dim xlRange As Microsoft.Office.Interop.Excel.Range
    Dim sSql As String
    'UPGRADE_WARNING: Arrays in structure rs may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    'Dim rs As DAO.Recordset
    ''UPGRADE_WARNING: Arrays in structure rs2 may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    'Dim rs2 As DAO.Recordset
    'Dim dbPoldata As DAO.Database
    'Dim dbStats As DAO.Database
    Dim introw As Short
    Dim sRow As Short 'Summary row indicator
    Dim rowColor As Object
    Dim templatePath As String
    Dim GroupTotal(55) As Double
    Dim GrandTotal(55) As Double
    Dim GroupTotNa(55) As Double
    Dim sumNegPremium As Double
    Dim strEmailPath As String
    Dim strContactEmail As String
    Dim strSalaryPath As String
    Dim cnstFileName As String

    Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmSalarisAfsluitings_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Dim VersekeraarSql As String
         'Dim rsVersekeraar As DAO.Recordset

        'set the server path
        'serverPath = getAdminPath

        'Set database objects
        'dbPoldata = DAODBEngine_definst.OpenDatabase(pol_path & "\poldata5.mdb")
        'dbStats = DAODBEngine_definst.OpenDatabase(pol_path & "\stats5.mdb")

        PopulateArea() 'Combobox
        cmbSort.SelectedIndex = 0

    End Sub
    'Populate the combobox with all active areas
    Public Sub PopulateArea()

        cmbArea.DataSource = ListArea()
        cmbArea.DisplayMember = "DisplayField"
        Me.cmbArea.Enabled = True

        'Select first item by default
        Me.cmbArea.SelectedIndex = 0
    End Sub

    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
        'Dim attachList As Object
        Dim strPersoneelNommers As Object
        Dim strSql As Object
        'Dim SelectionFormula As Object
        Dim strNow As Object
       
        'toets of 'n opsie gekies is
        If Me.optFinaleLopie.Checked = False And Me.optToetslopie.Checked = False Then
            MsgBox("Final test run or run must be selected. Choose one.", MsgBoxStyle.Information)
            Exit Sub
        End If

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        strSalaryPath = "c:\PUK\"
        strNow = Format(Now, "ddmmyy")

        'toets lopie
          'Dim rsTak As DAO.Recordset
        If Me.optToetslopie.Checked = True Then
        Else

            UpdateGebrukerLopies()

            cnstFileName = strSalaryPath & strNow & "\"

            'Kyk eers of daar enige personeelnommers nog uitstaande is
            strSql = "SELECT * from ((Persoonl "
            strSql = strSql & "LEFT JOIN area on area.area_kode = Persoonl.area) "
            strSql = strSql & "LEFT JOIN versekeraar ON versekeraar.pkversekeraar = area.fkversekeraar) "
            strSql = strSql & "WHERE not Gekans "
            strSql = strSql & "AND Bet_wyse = '3' "
            strSql = strSql & "AND area.area_besk = '" & Me.cmbArea.Text & "' "
            'dit moet kyk na eerste betaaldatum
            strSql = strSql & "AND cdate(bet_dat) < DateAdd('m', 1, now) "
            strSql = strSql & "AND area.lewendig = 'J' "
            strSql = strSql & "AND (pers_nom = '' OR isnull(Pers_nom)) "
            'rs2 = pol.OpenRecordset(strSql)

            strPersoneelNommers = ""

            'If Not (rs2.BOF And rs2.EOF) Then
            '	Do While Not rs2.EOF
             '		strPersoneelNommers = strPersoneelNommers & rs2.Fields("polisno").Value & ", "
            '		rs2.MoveNext()
            '	Loop 
            MsgBox("There are numbers of missing personnel policy / ies: " & Chr(13) & strPersoneelNommers & Chr(13) & "Make first right to change or the first payment date to the next month.", MsgBoxStyle.Information)
            'TODO ____
            'System.Windows.Forms.Cursor.Current = vbNormal
            '_________
            '         Exit Sub
            'Else
            'Instantiate excel object, open report workbook.
            'xlapp = CreateObject("Excel.application")
            'xlbook = xlapp.Workbooks.Open(pol_path & "\Docs\Report.xls")
            'xlsheet = xlbook.Worksheets(1)

            'xlapp.DisplayAlerts = False

            'PUK maandelikse afsluiting
            'setupExcel()
            introw = 10

            createSalaryFile()

            'xlbook.SaveAs(cnstFileName)

            'xlbook.Close()
            'xlapp.Quit()

            'xlsheet = Nothing
            'xlbook = Nothing
            'xlapp = Nothing

            'Email file

            Try
                Using conn As SqlConnection = SqlHelper.GetConnection

                    Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "poldata5.FetchTak")

                    strContactEmail = "22150110@nwu.ac.za; juanita.vandenberg@nwu.ac.za"
                    'if email - get email detail
                    If emailEngine.signOn Then

                        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                        emailEngine.txtTo.Text = strContactEmail
                        Do While reader.Read
                            emailEngine.txtSubject.Text = "Mooirivier Makelaars(" & reader("tak_naam") & ") - Salaris Aftrekking leer"
                            emailEngine.txtBody.Text = "Attached is the end file for salary deductions from Mooi River Estate " & reader("tak_naam") & "."
                        Loop
                        emailEngine.ShowDialog()
                        'If cancel was clicked - abort process else continue
                        If Not emailEngine.returnValue Then
                            emailEngine.signOff()
                            emailEngine.Close()
                            Exit Sub
                        End If
                    Else
                        Exit Sub
                    End If
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            'Build list of attachmets
            For intI = 0 To emailEngine.lstAanhangsels.Items.Count - 1
                'attachList = attachList & VB6.GetItemString(emailEngine.lstAanhangsels, intI) & "; "
            Next

            'email file as attachment
            emailEngine.sendMail((emailEngine.txtTo).Text, (emailEngine.txtSubject).Text, (emailEngine.txtBody).Text, cnstFileName)

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            MsgBox("The PUK closure was completed." & Chr(13) & Chr(13) & "Die leer is '" & cnstFileName & "'", MsgBoxStyle.Information)

            'If the document was emailed - sign-off
            emailEngine.signOff()
            emailEngine.Close()
        End If
        'End If

    End Sub
    Public Sub createSalaryFile()
       
        Dim strSql As String
        
        'Dim rs2 As DAO.Recordset
        'Dim rs3 As DAO.Recordset

        strSql = "SELECT * from ((Persoonl "
        strSql = strSql & "LEFT JOIN area on area.area_kode = Persoonl.area) "
        strSql = strSql & "LEFT JOIN versekeraar ON versekeraar.pkversekeraar = area.fkversekeraar) "
        strSql = strSql & "WHERE not Gekans "
        strSql = strSql & "AND Bet_wyse = '3' "
        strSql = strSql & "AND area.area_besk = '" & Me.cmbArea.Text & "' "
        'dit moet kyk na eerste betaaldatum
        strSql = strSql & "AND cdate(bet_dat) < DateAdd('m', 1, now) "
        strSql = strSql & "AND area.lewendig = 'J' "
        If Me.cmbSort.Text = "Versekerde" Then
            strSql = strSql & "ORDER BY versekerde"
        Else
            strSql = strSql & "ORDER BY pers_nom"
        End If
        'rs2 = pol.OpenRecordset(strSql)

        Salary_SetApplicationParameters()
        strEmailPath = cnstFileName

        'Logo
        'rsMakelaarSql = dbPoldata.OpenRecordset("SELECT * FROM Makelaar where pkmakelaar = " & rs2.Fields("fkmakelaar").Value)
        'xlsheet.Shapes.AddPicture(getAdminPath & "Logo\" & rsMakelaarSql("Makelaar_logo"), True, True, xlsheet.Cells.Left, xlsheet.Cells.Top, 480, 70)

        'Do While Not rs2.BOF And Not rs2.EOF
        'strversekeraar = rs2.Fields("fkversekeraar").Value

        'SkryfExcel(rs2.Fields("Polisno").Value, rs2)

        'rs2.MoveNext()
        'Loop 

    End Sub

    Public Sub SkryfExcel(ByRef strPolisno As String) 'ByRef rs2 As DAO.Recordset)

        ''skryf rekord na puk leer
         'xlsheet.Cells._Default(introw, 1) = rs2.Fields("pers_nom").Value
        'xlsheet.Cells._Default(introw, 2) = rs2.Fields("versekerde").Value
         'xlsheet.Cells._Default(introw, 3) = rs2.Fields("voorl").Value

        'kry titel
        '  sSql = "SELECT * FROM titel WHERE titelindeks = " & rs2.Fields("titelnum").Value
        'rs = pol.OpenRecordset(sSql)

          'xlsheet.Cells._Default(introw, 4) = rs.Fields("afrikaansetitel").Value
        'xlsheet.Cells._Default(introw, 5) = rs2.Fields("id_nom").Value
        ' If IsDBNull(rs2.Fields("geb_dat").Value) Then
        'xlsheet.Cells._Default(introw, 6).value = ""
        '   Else
        ' xlsheet.Cells._Default(introw, 6).value = CDate(rs2.Fields("geb_dat").Value)
        '  End If
        'xlsheet.Cells._Default(introw, 7) =Format(rs2.Fields("premie2").Value, "000000.00")
       'xlsheet.Cells._Default(introw, 8) = rs2.Fields("polisno").Value

        'With xlsheet.Range("A" & introw, "I" & introw)
        '.Font.Size = 8
        'End With

        introw = introw + 1

        'End Sub

        'Public Sub setupExcel()
        'Dim xlRange As Microsoft.Office.Interop.Excel.Range

        'Set line
        'xlsheet.Range("A4", "I4").Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Word.XlBorderWeight.xlThin

        'Set headings
        'With xlsheet.Range("A6")
        '.Font.Bold = True
        '.Font.Size = 10
        '.Value = "Short term insurance - Tendered Collections for NWU"
        '.RowHeight = 12.75
        'End With

        'With xlsheet.Range("A7")
        '.Font.Size = 8
        '.value = "Month-end date: " &Format(Now, "dd/MM/yyyy")
        '.RowHeight = 11.25
        'End With

        'With xlsheet.Range("A9", "I9")
        '.Font.Bold = True
        '.Font.Size = 10
        '.BorderAround(Microsoft.Office.Interop.Word.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Word.XlBorderWeight.xlThin)
        'End With

        'xlsheet.Cells._Default(9, 1) = "Emp code"
        'xlsheet.Cells._Default(9, 2) = "Surname"
        'xlsheet.Cells._Default(9, 3) = "Initials"
        'xlsheet.Cells._Default(9, 4) = "Title"
        'xlsheet.Cells._Default(9, 5) = "ID"
        'xlsheet.Cells._Default(9, 6) = "DateOfBirth"
        'xlsheet.Cells._Default(9, 7) = "Amount"
        'xlsheet.Cells._Default(9, 8) = "Ref NR"

        'xlsheet.Cells._Default(9, 1).ColumnWidth = 9
        'xlsheet.Cells._Default(9, 2).ColumnWidth = 21
        'xlsheet.Cells._Default(9, 3).ColumnWidth = 6.14
        'xlsheet.Cells._Default(9, 4).ColumnWidth = 6
        'xlsheet.Cells._Default(9, 5).ColumnWidth = 13.43
        'xlsheet.Cells._Default(9, 6).ColumnWidth = 10.29
        'xlsheet.Cells._Default(9, 7).ColumnWidth = 7.29
        'xlsheet.Cells._Default(9, 8).ColumnWidth = 10.57
        'xlsheet.Cells._Default(9, 9).ColumnWidth = 2

        'Set date
        'With xlsheet.Cells._Default(5, 9)
        '.value = "'" &Format(Now, "dd/MM/yyyy")
        '.Font.Size = 8
        '.Font.Bold = True
        '.HorizontalAlignment = Microsoft.Office.Interop.Word.XlConstants.xlRight
        'End With

        'Footer
        'xlsheet.PageSetup.RightFooter = "&6Page &p of &n"
    End Sub

    Private Sub optFinaleLopie_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optFinaleLopie.CheckedChanged
        If eventSender.Checked Then
            Me.cmbArea.Enabled = True
            Me.cmbSort.Enabled = True
        End If
    End Sub

    Private Sub optToetslopie_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optToetslopie.CheckedChanged
        If eventSender.Checked Then
            Me.cmbArea.Enabled = False
            Me.cmbSort.Enabled = False
        End If
    End Sub

    Public Sub Salary_SetApplicationParameters()
        Dim strNow As String = ""

        'strNow =Format(Now, "ddmmyy")
        If Dir(strSalaryPath, FileAttribute.Directory) = "" Then
            MkDir(strSalaryPath)
        End If
        If Dir(strSalaryPath & strNow, FileAttribute.Directory) = "" Then
            MkDir(strSalaryPath & strNow)
        End If

        cnstFileName = strSalaryPath & strNow & "\NWU_Salary.xls"

    End Sub
    Public Sub UpdateGebrukerLopies()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@Gebruiker", SqlDbType.NVarChar), _
                                                New SqlParameter("@Datum", SqlDbType.DateTime), _
                                                New SqlParameter("@Beskrywing", SqlDbType.NVarChar)}




                params(0).Value = Gebruiker.Naam
                params(1).Value = Now
                params(2).Value = "Salary run - Final run " & Me.cmbArea.Text

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stats5.UpdateGebruikerLopies", params)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

    End Sub
          
End Class