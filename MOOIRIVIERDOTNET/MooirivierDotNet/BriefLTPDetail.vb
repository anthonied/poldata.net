Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class BriefLTPDetail
    Inherits BaseForm
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		
		txtPremie2.Text = CStr(Val(txtPremie2.Text))
        txtPremie2.Text = txtPremie2.Text
		
        'SkepLTPBrief()

        BriefLTPDetailReportViewer.Show()
		Me.Close()
		
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        'Dim xlsheet As Object
        'Dim xlbook As Object
        'Dim xlapp As Object
        'xlapp = Nothing
        'xlbook = Nothing
        'xlsheet = Nothing
		
		Me.Close()
		
	End Sub
	
	Private Sub BriefLTPDetail_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Andriette 18/11/2013 verander die velde se tipe van text na label
        '  txtPremie2.Text = CStr(CDbl(Form1.Premie2.Text) * Val(Form1.txtAantalMaande.Text))
        txtPremie2.Text = CStr(CDbl(Form1.Premie2.Text) * Val(Form1.lbltermynmaande.Text))
		'Set the default values for the datepicker
		Me.DTPicker1.MinDate = Now
		Me.DTPicker1.MaxDate = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 6, Now)
		Me.DTPicker1.CustomFormat = "01 MMMM yyyy"
		Me.DTPicker1.value = Now
        Me.Text = My.Application.Info.Title & " - Letters - Term Renewal Policy"
	End Sub
End Class