Option Strict Off
Option Explicit On
Friend Class W_Gesk
    Inherits BaseForm
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Me.Close()
	End Sub
    Private Sub W_Gesk_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim lstAmendments As List(Of WysigEntity)
        lstAmendments = ListWysig()

        If IsNothing(lstAmendments) Then
            MsgBox("There are no amendments for period as requested!")
            Me.Close()
            Exit Sub
        End If

        dgvAmendments.DataBindings.Clear()
        dgvAmendments.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAmendments.ReadOnly = True
        dgvAmendments.AutoGenerateColumns = False
        With Me.dgvAmendments.RowTemplate
            .Height = 18
            .MinimumHeight = 5
        End With

        dgvAmendments.DataSource = lstAmendments
    End Sub


    Private Sub dgvAmendments_DataBindingComplete(sender As Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvAmendments.DataBindingComplete
        Dim strDate As String

        For nInskrywing = 0 To dgvAmendments.RowCount - 1
            strDate = dgvAmendments.Rows(nInskrywing).Cells("DateTime").Value
            dgvAmendments.Rows(nInskrywing).Cells("Wysdatum").Value = String.Format(strDate, "{0:dd/mm/yyyy  HH:MM:SS}")
        Next
    End Sub
End Class
