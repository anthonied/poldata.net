Imports System.ComponentModel
<Serializable()> _
    Public Class KontantRekonEntity

    Private m_area As String
    Private m_jaar As Integer
    Private m_maand As Integer
    Private m_mtprem As Decimal
    Private m_arprem As Decimal
    Private m_hbgewprem As Decimal
    Private m_hegewprem As Decimal
    Private m_hbgrasprem As Decimal
    Private m_hegrasprem As Decimal
    Private m_tselekprem As Decimal
    Private m_tsgewprem As Decimal
    Private m_wlprem As Decimal
    Private m_totprem As Decimal
    Private m_beskermingprem As Decimal
    Private m_sasriaprem As Decimal
    Private m_tvdiensprem As Decimal
    Private m_pfprem As Decimal
    Private m_begrafnisprem As Decimal
    Private m_plipprem As Decimal
    Private m_geleentheidsmotorprem As Decimal
    Private m_epcprem As Decimal
    Private m_caprem As Decimal
    Private m_selfoonprem As Decimal
    Private m_mediesprem As Decimal
    Private m_mtpers As Double
    Private m_arpers As Double
    Private m_hbgewpers As Double
    Private m_hegewpers As Double
    Private m_hbgraspers As Double
    Private m_hegraspers As Double
    Private m_tselekpers As Double
    Private m_tsgewpers As Double
    Private m_wlpers As Double
    Private m_premienakorting As Decimal
    Private m_Premievoorkorting As Decimal
    Private m_spesialekorting As Decimal
    Private m_addisionelepremie As Decimal
    Private m_motorsap As Decimal
    Private m_allerisikoap As Decimal
    Private m_hbap As Decimal
    Private m_heap As Decimal
    Private m_hbgrasap As Decimal
    Private m_hegrasap As Decimal
    Private m_toevaleemap As Decimal
    Private m_toevalbreekap As Decimal
    Private m_waterleweap As Decimal
    Private m_begrafnisap As Decimal
    Private m_sasriaap As Decimal
    Private m_polisfooiap As Decimal
    Private m_plipap As Decimal
    Private m_tvdiensap As Decimal
    Private m_beskermap As Decimal
    Private m_courtesyvap As Decimal
    Private m_epcap As Decimal
    Private m_careassistap As Decimal
    Private m_selfoonap As Decimal
    Private m_spesialekortingap As Decimal
    Private m_pakketitem1 As Decimal
    Private m_pakketitem2 As Decimal
    Private m_pakketitem3 As Decimal
    Private m_pakketitem4 As Decimal
    Private m_pakketitem1ap As Decimal
    Private m_pakketitem2ap As Decimal
    Private m_pakketitem3ap As Decimal
    Private m_pakketitem4ap As Decimal
    Private m_aantalpolisse As Integer
    Private m_aantalvoertuie As Integer
    Private m_aantalhomeassistance As Integer
    Private m_aantalpakketitem1 As Integer
    Private m_aantalar As Integer
    Private m_aantalhb As Integer
    Private m_aantalhe As Integer
    Private m_aantalhbgras As Integer
    Private m_aantalhegras As Integer
    Private m_aantaltselek As Integer
    Private m_aantalts As Integer
    Private m_aantalwl As Integer
    Private m_aantalsasria As Integer
    Private m_aantaltv As Integer
    Private m_aantalbegrafnis As Integer
    Private m_aantalplip As Integer
    Private m_aantalgeleentheidsmotor As Integer
    Private m_aantalcare As Integer
    Private m_aantalselfoon As Integer
    Private m_aantalpakketitem2 As Integer
    Private m_aantalpakketitem3 As Integer
    Private m_aantalpakketitem4 As Integer
    Private m_aantalvoertuiepol As Integer
    Private m_aantalarpol As Integer
    Private m_aantalhbpol As Integer
    Private m_aantalhepol As Integer
    Private m_aantalhbgraspol As Integer
    Private m_aantalhegraspol As Integer
    Private m_aantaltselekpol As Integer
    Private m_aantaltspol As Integer
    Private m_aantalwlpol As Integer

    <DataObjectField(False, False, False)> _
    Public Property AreaKR() As String
        Get
            Return m_area
        End Get
        Set(ByVal value As String)
            m_area = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property JaarKR() As Integer
        Get
            Return m_jaar
        End Get
        Set(ByVal value As Integer)
            m_jaar = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property MaandKR() As Integer
        Get
            Return m_maand
        End Get
        Set(ByVal value As Integer)
            m_maand = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Mtprem() As Decimal
        Get
            Return m_mtprem
        End Get
        Set(ByVal value As Decimal)
            m_mtprem = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Arprem() As Decimal
        Get
            Return m_arprem
        End Get
        Set(ByVal value As Decimal)
            m_arprem = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Hbgewprem() As Decimal
        Get
            Return m_hbgewprem
        End Get
        Set(ByVal value As Decimal)
            m_hbgewprem = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Hegewprem() As Decimal
        Get
            Return m_hegewprem
        End Get
        Set(ByVal value As Decimal)
            m_hegewprem = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Hbgrasprem() As Decimal
        Get
            Return m_hbgrasprem
        End Get
        Set(ByVal value As Decimal)
            m_hbgrasprem = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Hegrasprem() As Decimal
        Get
            Return m_hegrasprem
        End Get
        Set(ByVal value As Decimal)
            m_hegrasprem = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Tselekprem() As Decimal
        Get
            Return m_tselekprem
        End Get
        Set(ByVal value As Decimal)
            m_tselekprem = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Tsgewprem() As Decimal
        Get
            Return m_tsgewprem
        End Get
        Set(ByVal value As Decimal)
            m_tsgewprem = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Wlprem() As Decimal
        Get
            Return m_wlprem
        End Get
        Set(ByVal value As Decimal)
            m_wlprem = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Totprem() As Decimal
        Get
            Return m_totprem
        End Get
        Set(ByVal value As Decimal)
            m_totprem = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Beskermingprem() As Decimal
        Get
            Return m_beskermingprem
        End Get
        Set(ByVal value As Decimal)
            m_beskermingprem = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Sasriaprem() As Decimal
        Get
            Return m_sasriaprem
        End Get
        Set(ByVal value As Decimal)
            m_sasriaprem = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Tvdiensprem() As Decimal
        Get
            Return m_tvdiensprem
        End Get
        Set(ByVal value As Decimal)
            m_tvdiensprem = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Pfprem() As Decimal
        Get
            Return m_pfprem
        End Get
        Set(ByVal value As Decimal)
            m_pfprem = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Begrafnisprem() As Decimal
        Get
            Return m_begrafnisprem
        End Get
        Set(ByVal value As Decimal)
            m_begrafnisprem = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Plipprem() As Decimal
        Get
            Return m_plipprem
        End Get
        Set(ByVal value As Decimal)
            m_plipprem = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Geleentheidsmotorprem() As Decimal
        Get
            Return m_geleentheidsmotorprem
        End Get
        Set(ByVal value As Decimal)
            m_geleentheidsmotorprem = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Epcprem() As Decimal
        Get
            Return m_epcprem
        End Get
        Set(ByVal value As Decimal)
            m_epcprem = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Caprem() As Decimal
        Get
            Return m_caprem
        End Get
        Set(ByVal value As Decimal)
            m_caprem = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Selfoonprem() As Decimal
        Get
            Return m_selfoonprem
        End Get
        Set(ByVal value As Decimal)
            m_selfoonprem = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Mediesprem() As Decimal
        Get
            Return m_mediesprem
        End Get
        Set(ByVal value As Decimal)
            m_mediesprem = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Mtpers() As Double
        Get
            Return m_mtpers
        End Get
        Set(ByVal value As Double)
            m_mtpers = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Arpers() As Double
        Get
            Return m_arpers
        End Get
        Set(ByVal value As Double)
            m_arpers = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Hbgewpers() As Double
        Get
            Return m_hbgewpers
        End Get
        Set(ByVal value As Double)
            m_hbgewpers = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Hegewpers() As Double
        Get
            Return m_hegewpers
        End Get
        Set(ByVal value As Double)
            m_hegewpers = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Hbgraspers() As Double
        Get
            Return m_hbgraspers
        End Get
        Set(ByVal value As Double)
            m_hbgraspers = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Hegraspers() As Double
        Get
            Return m_hegraspers
        End Get
        Set(ByVal value As Double)
            m_hegraspers = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Tselekpers() As Double
        Get
            Return m_tselekpers
        End Get
        Set(ByVal value As Double)
            m_tselekpers = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Tsgewpers() As Double
        Get
            Return m_tsgewpers
        End Get
        Set(ByVal value As Double)
            m_tsgewpers = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Wlpers() As Double
        Get
            Return m_wlpers
        End Get
        Set(ByVal value As Double)
            m_wlpers = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Premienakorting() As Decimal
        Get
            Return m_premienakorting
        End Get
        Set(ByVal value As Decimal)
            m_premienakorting = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Premievoorkorting() As Decimal
        Get
            Return m_Premievoorkorting
        End Get
        Set(ByVal value As Decimal)
            m_Premievoorkorting = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Spesialekorting() As Decimal
        Get
            Return m_spesialekorting
        End Get
        Set(ByVal value As Decimal)
            m_spesialekorting = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Addisionelepremie() As Decimal
        Get
            Return m_addisionelepremie
        End Get
        Set(ByVal value As Decimal)
            m_addisionelepremie = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Motorsap() As Decimal
        Get
            Return m_motorsap
        End Get
        Set(ByVal value As Decimal)
            m_motorsap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Allerisikoap() As Decimal
        Get
            Return m_allerisikoap
        End Get
        Set(ByVal value As Decimal)
            m_allerisikoap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Hbap() As Decimal
        Get
            Return m_hbap
        End Get
        Set(ByVal value As Decimal)
            m_hbap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property HeAp() As Decimal
        Get
            Return m_heap
        End Get
        Set(ByVal value As Decimal)
            m_heap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Hbgrasap() As Decimal
        Get
            Return m_hbgrasap
        End Get
        Set(ByVal value As Decimal)
            m_hbgrasap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Hegrasap() As Decimal
        Get
            Return m_hegrasap
        End Get
        Set(ByVal value As Decimal)
            m_hegrasap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Toevaleemap() As Decimal
        Get
            Return m_toevaleemap
        End Get
        Set(ByVal value As Decimal)
            m_toevaleemap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Toevalbreekap() As Decimal
        Get
            Return m_toevalbreekap
        End Get
        Set(ByVal value As Decimal)
            m_toevalbreekap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Waterleweap() As Decimal
        Get
            Return m_waterleweap
        End Get
        Set(ByVal value As Decimal)
            m_waterleweap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Begrafnisap() As Decimal
        Get
            Return m_begrafnisap
        End Get
        Set(ByVal value As Decimal)
            m_begrafnisap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Sasriaap() As Decimal
        Get
            Return m_sasriaap
        End Get
        Set(ByVal value As Decimal)
            m_sasriaap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Polisfooiap() As Decimal
        Get
            Return m_polisfooiap
        End Get
        Set(ByVal value As Decimal)
            m_polisfooiap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Plipap() As Decimal
        Get
            Return m_plipap
        End Get
        Set(ByVal value As Decimal)
            m_plipap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Tvdiensap() As Decimal
        Get
            Return m_tvdiensap
        End Get
        Set(ByVal value As Decimal)
            m_tvdiensap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Beskermap() As Decimal
        Get
            Return m_beskermap
        End Get
        Set(ByVal value As Decimal)
            m_beskermap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Courtesyvap() As Decimal
        Get
            Return m_courtesyvap
        End Get
        Set(ByVal value As Decimal)
            m_courtesyvap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Epcap() As Decimal
        Get
            Return m_epcap
        End Get
        Set(ByVal value As Decimal)
            m_epcap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Careassistap() As Decimal
        Get
            Return m_careassistap
        End Get
        Set(ByVal value As Decimal)
            m_careassistap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Selfoonap() As Decimal
        Get
            Return m_selfoonap
        End Get
        Set(ByVal value As Decimal)
            m_selfoonap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Spesialekortingap() As Decimal
        Get
            Return m_spesialekortingap
        End Get
        Set(ByVal value As Decimal)
            m_spesialekortingap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Pakketitem1() As Decimal
        Get
            Return m_pakketitem1
        End Get
        Set(ByVal value As Decimal)
            m_pakketitem1 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Pakketitem2() As Decimal
        Get
            Return m_pakketitem2
        End Get
        Set(ByVal value As Decimal)
            m_pakketitem2 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Pakketitem3() As Decimal
        Get
            Return m_pakketitem3
        End Get
        Set(ByVal value As Decimal)
            m_pakketitem3 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Pakketitem4() As Decimal
        Get
            Return m_pakketitem4
        End Get
        Set(ByVal value As Decimal)
            m_pakketitem4 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Pakketitem1ap() As Decimal
        Get
            Return m_pakketitem1ap
        End Get
        Set(ByVal value As Decimal)
            m_pakketitem1ap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Pakketitem2ap() As Decimal
        Get
            Return m_pakketitem2ap
        End Get
        Set(ByVal value As Decimal)
            m_pakketitem2ap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Pakketitem3ap() As Decimal
        Get
            Return m_pakketitem3ap
        End Get
        Set(ByVal value As Decimal)
            m_pakketitem3ap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Pakketitem4ap() As Decimal
        Get
            Return m_pakketitem4ap
        End Get
        Set(ByVal value As Decimal)
            m_pakketitem4ap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalpolisse() As Integer
        Get
            Return m_aantalpolisse
        End Get
        Set(ByVal value As Integer)
            m_aantalpolisse = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalvoertuie() As Integer
        Get
            Return m_aantalvoertuie
        End Get
        Set(ByVal value As Integer)
            m_aantalvoertuie = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalhomeassistance() As Integer
        Get
            Return m_aantalhomeassistance
        End Get
        Set(ByVal value As Integer)
            m_aantalhomeassistance = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalpakketitem1() As Integer
        Get
            Return m_aantalpakketitem1
        End Get
        Set(ByVal value As Integer)
            m_aantalpakketitem1 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalar() As Integer
        Get
            Return m_aantalar
        End Get
        Set(ByVal value As Integer)
            m_aantalar = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalhb() As Integer
        Get
            Return m_aantalhb
        End Get
        Set(ByVal value As Integer)
            m_aantalhb = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalhe() As Integer
        Get
            Return m_aantalhe
        End Get
        Set(ByVal value As Integer)
            m_aantalhe = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalhbgras() As Integer
        Get
            Return m_aantalhbgras
        End Get
        Set(ByVal value As Integer)
            m_aantalhbgras = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalhegras() As Integer
        Get
            Return m_aantalhegras
        End Get
        Set(ByVal value As Integer)
            m_aantalhegras = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantaltselek() As Integer
        Get
            Return m_aantaltselek
        End Get
        Set(ByVal value As Integer)
            m_aantaltselek = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalts() As Integer
        Get
            Return m_aantalts
        End Get
        Set(ByVal value As Integer)
            m_aantalts = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalwl() As Integer
        Get
            Return m_aantalwl
        End Get
        Set(ByVal value As Integer)
            m_aantalwl = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalsasria() As Integer
        Get
            Return m_aantalsasria
        End Get
        Set(ByVal value As Integer)
            m_aantalsasria = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantaltv() As Integer
        Get
            Return m_aantaltv
        End Get
        Set(ByVal value As Integer)
            m_aantaltv = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalbegrafnis() As Integer
        Get
            Return m_aantalbegrafnis
        End Get
        Set(ByVal value As Integer)
            m_aantalbegrafnis = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalplip() As Integer
        Get
            Return m_aantalplip
        End Get
        Set(ByVal value As Integer)
            m_aantalplip = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalgeleentheidsmotor() As Integer
        Get
            Return m_aantalgeleentheidsmotor
        End Get
        Set(ByVal value As Integer)
            m_aantalgeleentheidsmotor = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalcare() As Integer
        Get
            Return m_aantalcare
        End Get
        Set(ByVal value As Integer)
            m_aantalcare = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalselfoon() As Integer
        Get
            Return m_aantalselfoon
        End Get
        Set(ByVal value As Integer)
            m_aantalselfoon = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalpakketitem2() As Integer
        Get
            Return m_aantalpakketitem2
        End Get
        Set(ByVal value As Integer)
            m_aantalpakketitem2 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalpakketitem3() As Integer
        Get
            Return m_aantalpakketitem3
        End Get
        Set(ByVal value As Integer)
            m_aantalpakketitem3 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalpakketitem4() As Integer
        Get
            Return m_aantalpakketitem4
        End Get
        Set(ByVal value As Integer)
            m_aantalpakketitem4 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalvoertuiepol() As Integer
        Get
            Return m_aantalvoertuiepol
        End Get
        Set(ByVal value As Integer)
            m_aantalvoertuiepol = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalarpol() As Integer
        Get
            Return m_aantalarpol
        End Get
        Set(ByVal value As Integer)
            m_aantalarpol = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalhbpol() As Integer
        Get
            Return m_aantalhbpol
        End Get
        Set(ByVal value As Integer)
            m_aantalhbpol = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalhepol() As Integer
        Get
            Return m_aantalhepol
        End Get
        Set(ByVal value As Integer)
            m_aantalhepol = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalhbgraspol() As Integer
        Get
            Return m_aantalhbgraspol
        End Get
        Set(ByVal value As Integer)
            m_aantalhbgraspol = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalhegraspol() As Integer
        Get
            Return m_aantalhegraspol
        End Get
        Set(ByVal value As Integer)
            m_aantalhegraspol = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantaltselekpol() As Integer
        Get
            Return m_aantaltselekpol
        End Get
        Set(ByVal value As Integer)
            m_aantaltselekpol = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantaltspol() As Integer
        Get
            Return m_aantaltspol
        End Get
        Set(ByVal value As Integer)
            m_aantaltspol = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aantalwlpol() As Integer
        Get
            Return m_aantalwlpol
        End Get
        Set(ByVal value As Integer)
            m_aantalwlpol = value
        End Set
    End Property
End Class
