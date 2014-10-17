Option Strict Off
Option Explicit On

Friend Class frmVervaldeVerwysingskommissie
    Inherits BaseForm
	Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
	
	Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
        frmVervaldeVerwysingskommissieReportViewer.ShowDialog()
    End Sub
	
    Private Sub dtpVervalDatumVanaf_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
       
    End Sub
	
	Private Sub frmVervaldeVerwysingskommissie_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim dteVolgendeMaand As Object
		Me.dtpVervalDatumVanaf.CustomFormat = "01 MMMM yyyy"
        dteVolgendeMaand = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, Now)
        Me.dtpVervalDatumVanaf.Value = CDate("01/" & CStr(Month(dteVolgendeMaand)) & "/" & CStr(Year(dteVolgendeMaand)))
		
        Me.dtpVervalDatumTot.Value = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, dtpVervalDatumVanaf.Value)
        Me.dtpVervalDatumTot.Value = DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, dtpVervalDatumTot.Value)
		
        Me.Text = My.Application.Info.Title & " - Reports - Referral commission that expired"
	End Sub

    Private Sub dtpVervalDatumVanaf_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpVervalDatumVanaf.ValueChanged
        Me.dtpVervalDatumVanaf.Value = CDate("01/" & CStr(Month(dtpVervalDatumVanaf.Value)) & "/" & CStr(Year(dtpVervalDatumVanaf.Value)))

        Me.dtpVervalDatumTot.Value = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, dtpVervalDatumVanaf.Value)
        Me.dtpVervalDatumTot.Value = DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, dtpVervalDatumTot.Value)
    End Sub

    Private Sub btnOK_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

    End Sub
End Class