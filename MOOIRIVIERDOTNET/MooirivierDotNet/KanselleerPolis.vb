Option Strict Off
Option Explicit On

Imports System.Data.SqlClient
Imports DAL

Friend Class KanselleerPolis
    Inherits BaseForm

    'Description: Form containing dropdown for reason of cancellation
    '  Dim strSqlInfor As String

    Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
        'Reset gekans

        Form1.Ougekans.Text = "JA"
        Form1.blnKanselleerPolisFormCancelled = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click

        If cmbKansellasieRede.SelectedIndex = -1 Then
            MsgBox("'A Reason for cancel must be given.", MsgBoxStyle.Exclamation)
        Else
            'Set pk and date
            'Persoonl.Edit()
            'Persoonl.Fields("GEKANS").Value = True
            'Persoonl.Fields("fkKansellasieRedes").Value = VB6.GetItemData(Me.cmbKansellasieRede, cmbKansellasieRede.SelectedIndex)
            'Persoonl.Fields("datumGekanselleer").Value = VB6.Format(Now, "dd/mm/yyyy")
            'Persoonl.Fields("datumEffekGekans").Value = VB6.Format(Me.dtpEffekDatum.value, "dd/mm/yyyy")
            'Persoonl.Update()
            ' Andriette 14/05/2013 haal alles uit en gebruik 1 SP
            'updatePersoonl()
            '' Andriette 10/05/2013 doen die kansellasie
            'UpdatePersoonlPerField("gekans", True)
            '' Andriette 14/05/2013 verander om 'n string deur te stuur nie 'n datum nie
            ''Andriette 14/05/2013 haal tydelik uit tot oplossing vir die update van datums gevind word
            ''    UpdatePersoonlPerField("datumgekanselleer", Now())
            ''    UpdatePersoonlPerField("datumEffekGekans", Me.dtpEffekDatum.Value)
            UpdatePersoonlKansellasie()

            'Set description for alteration record
            BESKRYWING = Me.cmbKansellasieRede.Text
            If Persoonl.TAAL = 0 Then 'Afr
                BESKRYWING = BESKRYWING & ". Effektief: " & Me.dtpEffekDatum.Value
            Else
                BESKRYWING = BESKRYWING & ". Effective: " & Me.dtpEffekDatum.Value
            End If

            UpdateWysig((41), BESKRYWING)

            Form1.blnKanselleerPolisFormCancelled = False
            Me.Close()
        End If
    End Sub

    Private Sub KanselleerPolis_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Me.Text = My.Application.Info.Title & " - Cancel policy"
        populateCmbTitel()

        'Set the default values for the datepicker
        
        Me.dtpEffekDatum.Value = Now()
        Me.dtpEffekDatum.Format = DateTimePickerFormat.Custom
        Me.dtpEffekDatum.CustomFormat = "dd/MM/yyyy"

        'Me.dtpEffekDatum.MinDate = DateAdd(Microsoft.VisualBasic.DateInterval.Month, -6, Now)
        'Me.dtpEffekDatum.MaxDate = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 6, Now)
        'Me.dtpEffekDatum.Value = Format(Now, "dd/MM/yyyy")
        'Me.dtpEffekDatum.Value = DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, DateAdd(Microsoft.VisualBasic.DateInterval.Day, 0 - (dtpEffekDatum.Value - 1), dtpEffekDatum.Value)))

    End Sub
    Public Sub populateCmbTitel()
        cmbKansellasieRede.ValueMember = "pkKansellasieRedes"
        ' Andriette 14/05/2013 verander na dis combobox
        'cmbKansellasieRede.DataSource = ListKansellasRedes()
        If Persoonl.TAAL = 0 Then
            cmbKansellasieRede.DataSource = FillCombo("[poldata5].[FetchKansellasiepolicy]", "pkKansellasieRedes", "BeskrywingAfrikaans", "", "", "", "BeskrywingAfrikaans")
        Else
            cmbKansellasieRede.DataSource = FillCombo("[poldata5].[FetchKansellasiepolicy]", "pkKansellasieRedes", "BeskrywingEngels", "", "", , "BeskrywingEngels")
        End If
        cmbKansellasieRede.DisplayMember = "comboboxname"
    End Sub
    Public Function ListKansellasRedes() As List(Of KansellasieRedesEntity)
        Dim list As List(Of KansellasieRedesEntity) = New List(Of KansellasieRedesEntity)

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim param As New SqlParameter("@sqlSortField", SqlDbType.NVarChar)
                ' Andriette 23/05/2013 haal uit die afrikaans en wys net Engels
                'If Persoonl.TAAL = 0 Then
                '    param.Value = "BeskrywingAfrikaans"
                'Else
                param.Value = "BeskrywingEngels"
                'End If

                Dim reader As SqlDataReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[poldata5].[FetchKansellasiepolicy]", param)

                While reader.Read()
                    Dim item As KansellasieRedesEntity = New KansellasieRedesEntity()

                    item.pkKansellasieRedes = reader("pkKansellasieRedes")
                    'If Persoonl.TAAL = 0 Then
                    '    item.BeskrywingAfrikaans = reader("BeskrywingAfrikaans")
                    'Else
                    item.BeskrywingEngels = reader("BeskrywingEngels")
                    '
                    list.Add(item)
                End While
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox("There's error trying to connect to the database.", MsgBoxStyle.Exclamation)
        End Try
        Return list
    End Function
    ' Andriette 14/05/2013 vir die update van die kansellasie detail
    Private Sub UpdatePersoonlKansellasie()

        Try
            Using conn As SqlConnection = SqlHelper.GetConnection
                Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                                     New SqlParameter("@Gekans", SqlDbType.Bit), _
                                     New SqlParameter("@fkKansellasieRedes", SqlDbType.Int), _
                                     New SqlParameter("@DatumGekanselleer", SqlDbType.DateTime), _
                                     New SqlParameter("@DatumEffekGekans ", SqlDbType.DateTime)}
                'Andriette 16/08/2013 global polisnommer
                'params(0).Value = Form1.form1Polisno.Text
                params(0).Value = glbPolicyNumber
                params(1).Value = Form1.GEKANS.SelectedIndex
                Dim item As New ComboBoxEntity
                '  Dim intcounter As Integer
                item = Me.cmbKansellasieRede.SelectedItem
                params(2).Value = item.ComboBoxID
                params(3).Value = Now()
                params(4).Value = Me.dtpEffekDatum.Value

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdatePersoonlForKansellasieRedes]", params)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Using
            'Linkie 03/07/2012

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
        'FetchPersoonl())

    End Sub


End Class