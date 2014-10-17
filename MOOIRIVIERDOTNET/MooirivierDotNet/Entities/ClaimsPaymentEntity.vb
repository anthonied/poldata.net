
Imports System.ComponentModel

<Serializable()> _
Public Class ClaimsPaymentEntity
    Private m_eisno As String
    Private m_polisno As String
    Private m_tjekbesonderhede As String
    Private m_premie As Decimal
    Private m_status As String
    Private m_kwitansie As String
    Private m_Btwuitbedrag As Decimal
    Private m_Btwbedrag As Decimal
    Private m_Btwjn As String
    Private m_Betaalwyse As String
    Private m_Tjekno As String
    Private m_Trans_dat As Date
    Private m_Tipe As String
    Private m_pkPayments As Integer
    Private m_Gekans As Integer
    Private m_GekansIcon As String
    Private m_Vord_dat As Date
    Private m_Afsluit_dat As Date
    Private m_kans_dat As Date
    Private m_vt_trans_dat As Date
    Private m_mk_Trans_dat As Date
    Private m_jk_Trans_dat As Date
    Private m_eb_Trans_dat As Date
    Private m_ms_Trans_dat As Date
    Private m_ei_Trans_dat As Date
    Private m_md_Trans_dat As Date
    Private m_gg_Trans_dat As Date
    Private m_Tjekdatum As Date
    Private m_StrTjekdatum As String
    Private m_Jaar As Integer
    Private m_Maand As Integer
    Private m_Bankindeks As Integer
    Private m_NedrekTipe As Integer
    Private m_Vord_premie As Decimal
    Private m_Nedlopie As Integer
    Private m_Verw1 As String
    Private m_Verw2 As String
    Private m_Verw3 As String
    Private m_Verw4 As String
    Private m_Verw5 As String
    Private m_Kontant_tipe As String
    Private m_Nuwe_Tjekno As String
    Private m_Tjekno_uit As String
    Private m_Tjekno_in As String
    Private m_Neddatum As String
    Private m_Nedbankkode As String
    Private m_Nedbankrek As String
    Private m_afdat2 As String
    Private m_Waarvoor As String
    Private m_Stuurdmv As String
    Private m_Faks As String
    Private m_Email As String
    Private m_Banknaam As String
    Private m_Taknaam As String
    Private m_Batchid As String
    Private m_BatchTyd As String
    Private m_VatNumber As String
    Private m_ServiceProviderName As String
    Private m_PayeeIdentification As String
    Private m_CategoryofService As String
    Private m_SubCategoryofService As String
    Private m_SpecialityofServiceProvider As String
    Private m_Area As String
    Private m_Faktuurnr As String
    Private m_TipePayment As String


    <DataObjectField(False, False, False)> _
    Public Property eisno() As String
        Get
            Return m_eisno
        End Get
        Set(ByVal value As String)
            m_eisno = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property polisno() As String
        Get
            Return m_polisno
        End Get
        Set(ByVal value As String)
            m_polisno = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Tjekbesonderhede() As String
        Get
            Return m_tjekbesonderhede
        End Get
        Set(ByVal value As String)
            m_tjekbesonderhede = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property premie() As Decimal
        Get
            Return m_premie
        End Get
        Set(ByVal value As Decimal)
            m_premie = String.Format("{0:N2}", value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property status() As String
        Get
            Return m_status
        End Get
        Set(ByVal value As String)
            m_status = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property kwitansie() As String
        Get
            Return m_kwitansie
        End Get
        Set(ByVal value As String)
            m_kwitansie = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Btwuitbedrag() As Decimal
        Get
            Return m_Btwuitbedrag
        End Get
        Set(ByVal value As Decimal)
            m_Btwuitbedrag = String.Format("{0:N2}", value)
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Btwbedrag() As Decimal
        Get
            Return m_Btwbedrag
        End Get
        Set(ByVal value As Decimal)
            m_Btwbedrag = String.Format("{0:N2}", value)
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Btwjn() As String
        Get
            Return m_Btwjn
        End Get
        Set(ByVal value As String)
            m_Btwjn = value
        End Set
    End Property


    <DataObjectField(False, False, False)> _
    Public Property Betaalwyse() As String
        Get
            Return m_Betaalwyse
        End Get
        Set(ByVal value As String)
            m_Betaalwyse = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Tjekno() As String
        Get
            Return m_Tjekno
        End Get
        Set(ByVal value As String)
            m_Tjekno = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Trans_dat() As Date
        Get
            Return m_Trans_dat
        End Get
        Set(ByVal value As Date)
            m_Trans_dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Tipe() As String
        Get
            Return m_Tipe
        End Get
        Set(ByVal value As String)
            m_Tipe = value
        End Set
    End Property
    
    <DataObjectField(False, False, False)> _
    Public Property pkPayments() As Integer
        Get
            Return m_pkPayments
        End Get
        Set(ByVal value As Integer)
            m_pkPayments = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Gekans() As Integer
        Get
            Return m_Gekans
        End Get
        Set(ByVal value As Integer)
            m_Gekans = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property GekansIcon() As String
        Get
            Return m_GekansIcon
        End Get
        Set(ByVal value As String)
            m_GekansIcon = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Vord_dat() As Date
        Get
            Return m_Vord_dat
        End Get
        Set(ByVal value As Date)
            m_Vord_dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Afsluit_dat() As Date
        Get
            Return m_Afsluit_dat
        End Get
        Set(ByVal value As Date)
            m_Afsluit_dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property kans_dat() As Date
        Get
            Return m_kans_dat
        End Get
        Set(ByVal value As Date)
            m_kans_dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property vt_trans_dat() As Date
        Get
            Return m_vt_trans_dat
        End Get
        Set(ByVal value As Date)
            m_vt_trans_dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property mk_Trans_dat() As Date
        Get
            Return m_mk_Trans_dat
        End Get
        Set(ByVal value As Date)
            m_mk_Trans_dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property jk_Trans_dat() As Date
        Get
            Return m_jk_Trans_dat
        End Get
        Set(ByVal value As Date)
            m_jk_Trans_dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property eb_Trans_dat() As Date
        Get
            Return m_eb_Trans_dat
        End Get
        Set(ByVal value As Date)
            m_eb_Trans_dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property ms_Trans_dat() As Date
        Get
            Return m_ms_Trans_dat
        End Get
        Set(ByVal value As Date)
            m_ms_Trans_dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property ei_Trans_dat() As Date
        Get
            Return m_ei_Trans_dat
        End Get
        Set(ByVal value As Date)
            m_ei_Trans_dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property md_Trans_dat() As Date
        Get
            Return m_md_Trans_dat
        End Get
        Set(ByVal value As Date)
            m_md_Trans_dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property gg_Trans_dat() As Date
        Get
            Return m_gg_Trans_dat
        End Get
        Set(ByVal value As Date)
            m_gg_Trans_dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Tjekdatum() As Date
        Get
            Return m_Tjekdatum
        End Get
        Set(ByVal value As Date)
            m_Tjekdatum = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property strTjekdatum() As String
        Get
            Return m_StrTjekdatum
        End Get
        Set(ByVal value As String)
            m_StrTjekdatum = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Jaar() As Integer
        Get
            Return m_Jaar
        End Get
        Set(ByVal value As Integer)
            m_Jaar = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Maand() As Integer
        Get
            Return m_Maand
        End Get
        Set(ByVal value As Integer)
            m_Maand = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Bankindeks() As Integer
        Get
            Return m_Bankindeks
        End Get
        Set(ByVal value As Integer)
            m_Bankindeks = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property NedrekTipe() As Integer
        Get
            Return m_NedrekTipe
        End Get
        Set(ByVal value As Integer)
            m_NedrekTipe = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Nedlopie() As Integer
        Get
            Return m_Nedlopie
        End Get
        Set(ByVal value As Integer)
            m_Nedlopie = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Vord_premie() As Decimal
        Get
            Return m_Vord_premie
        End Get
        Set(ByVal value As Decimal)
            m_Vord_premie = String.Format("{0:N2}", value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Verw1() As String
        Get
            Return m_Verw1
        End Get
        Set(ByVal value As String)
            m_Verw1 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Verw2() As String
        Get
            Return m_Verw2
        End Get
        Set(ByVal value As String)
            m_Verw2 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Verw3() As String
        Get
            Return m_Verw3
        End Get
        Set(ByVal value As String)
            m_Verw3 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Verw4() As String
        Get
            Return m_Verw4
        End Get
        Set(ByVal value As String)
            m_Verw4 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Verw5() As String
        Get
            Return m_Verw5
        End Get
        Set(ByVal value As String)
            m_Verw5 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Kontant_tipe() As String
        Get
            Return m_Kontant_tipe
        End Get
        Set(ByVal value As String)
            m_Kontant_tipe = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Nuwe_Tjekno() As String
        Get
            Return m_Nuwe_Tjekno
        End Get
        Set(ByVal value As String)
            m_Nuwe_Tjekno = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Tjekno_uit() As String
        Get
            Return m_Tjekno_uit
        End Get
        Set(ByVal value As String)
            m_Tjekno_uit = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Tjekno_in() As String
        Get
            Return m_Tjekno_in
        End Get
        Set(ByVal value As String)
            m_Tjekno_in = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Neddatum() As String
        Get
            Return m_Neddatum
        End Get
        Set(ByVal value As String)
            m_Neddatum = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Nedbankkode() As String
        Get
            Return m_Nedbankkode
        End Get
        Set(ByVal value As String)
            m_Nedbankkode = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Nedbankrek() As String
        Get
            Return m_Nedbankrek
        End Get
        Set(ByVal value As String)
            m_Nedbankrek = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property afdat2() As String
        Get
            Return m_afdat2
        End Get
        Set(ByVal value As String)
            m_afdat2 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Waarvoor() As String
        Get
            Return m_Waarvoor
        End Get
        Set(ByVal value As String)
            m_Waarvoor = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Stuurdmv() As String
        Get
            Return m_Stuurdmv
        End Get
        Set(ByVal value As String)
            m_Stuurdmv = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Faks() As String
        Get
            Return m_Faks
        End Get
        Set(ByVal value As String)
            m_Faks = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Email() As String
        Get
            Return m_Email
        End Get
        Set(ByVal value As String)
            m_Email = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Banknaam() As String
        Get
            Return m_Banknaam
        End Get
        Set(ByVal value As String)
            m_Banknaam = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Taknaam() As String
        Get
            Return m_Taknaam
        End Get
        Set(ByVal value As String)
            m_Taknaam = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Batchid() As String
        Get
            Return m_Batchid
        End Get
        Set(ByVal value As String)
            m_Batchid = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property BatchTyd() As String
        Get
            Return m_BatchTyd
        End Get
        Set(ByVal value As String)
            m_BatchTyd = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property VatNumber() As String
        Get
            Return m_VatNumber
        End Get
        Set(ByVal value As String)
            m_VatNumber = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property ServiceProviderName() As String
        Get
            Return m_ServiceProviderName
        End Get
        Set(ByVal value As String)
            m_ServiceProviderName = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property PayeeIdentification() As String
        Get
            Return m_PayeeIdentification
        End Get
        Set(ByVal value As String)
            m_PayeeIdentification = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property CategoryofService() As String
        Get
            Return m_CategoryofService
        End Get
        Set(ByVal value As String)
            m_CategoryofService = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property SubCategoryofService() As String
        Get
            Return m_SubCategoryofService
        End Get
        Set(ByVal value As String)
            m_SubCategoryofService = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property SpecialityofServiceProvider() As String
        Get
            Return m_SpecialityofServiceProvider
        End Get
        Set(ByVal value As String)
            m_SpecialityofServiceProvider = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Area() As String
        Get
            Return m_Area
        End Get
        Set(ByVal value As String)
            m_Area = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Faktuurnr() As String
        Get
            Return m_Faktuurnr
        End Get
        Set(ByVal value As String)
            m_Faktuurnr = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property TipePayment() As String
        Get
            Return m_TipePayment
        End Get
        Set(ByVal value As String)
            m_TipePayment = value
        End Set
    End Property
End Class
