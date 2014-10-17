Option Strict Off
Option Explicit On

Imports System.Data.SqlClient
Imports DAL


Friend Class frmLysVanDaaglikseWysigings
    Inherits BaseForm
	Dim blnUserControl As Boolean
    Public strArea As String = ""
	
    Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click

        'Dim i As Integer
        'strArea = ""
        'For i = 0 To lstArea.SelectedItems.Count - 1
        '    If strArea <> "" Then
        '        If lstArea.SelectedItems.Item(i) = "All areas" Then
        '            strArea = ""
        '            Exit For
        '        Else
        '            strArea = strArea & "," & lstArea.SelectedItems.Item(i)
        '        End If

        '    Else
        '        If lstArea.SelectedItems.Item(i) = "All areas" Then
        '            strArea = ""
        '            Exit For
        '        Else
        '            strArea = lstArea.SelectedItems.Item(i)
        '        End If
        '    End If
        'Next


       
        frmLysVanDaaglikseWysigingReportViewer.ShowDialog()
       
    End Sub

    Private Sub frmLysVanDaaglikseWysigings_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'lstArea.Items.Clear()

        If ListAreaDropdown.Count > 0 Then
            lstArea.DataSource = ListAreaDropdown()
        End If
    End Sub

    Public Function ValidateScreen() As Object
        Dim i As Object

        ValidateScreen = True
        If IsDBNull(Me.dtpDrukVir.Value) Then
            MsgBox("Please choose a data", MsgBoxStyle.Information)
            Me.dtpDrukVir.Focus()
            ValidateScreen = False
            Exit Function
        End If
        For i = 0 To lstArea.Items.Count - 1
            If lstArea.GetSelected(i) Then
                ValidateScreen = True
                Exit Function
            End If
        Next
        MsgBox("Choose one or more areas", MsgBoxStyle.Information)
        ValidateScreen = False
    End Function
End Class