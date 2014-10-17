Imports System.ComponentModel

<Serializable()> _
Public Class VoertuieEntity
    Private m_pkVoertuie As Integer
    Private m_SekuriteitBitValue As String
    Private m_Maak As String
    Private m_JAAR As String
    Private m_N_PLAAT As String
    Private m_TIPE_DEK As String
    'Kobus 9/7/13 verander van String na Decimal
    Private m_WAARDE As Decimal
    'Kobus 9/7/13 verander van String na Decimal
    Private m_PREMIE As Decimal
    Private m_EEU As String
    Private m_KODE As String
    Private m_GEBRUIK As String
    Private m_TIPE As String
    Private m_CourtesyVehAmount As Decimal
    Private m_kleur As String
    'Kobus 03/09/2013 verander van Integer na boolean
    Private m_ANDER As Boolean
    Private m_huurinstansie As String
    Private m_PremiePersentasie As Integer
    Private m_kilometerlesing As Decimal
    Private m_onderstelnommer As String
    Private m_enjinnommer As String
    Private m_vssratingjn As String
    Private m_vssratingbesk As String
    Private m_Poskode As String
    Private m_NoMatch As Boolean
    Private m_Voorstad As String
    Private m_huurnommer As String
    Private m_area_kode As String
    Private m_WaardeEkstras As Object
    Private m_huurkoop As Integer

    'Kobus 11/11/2013 voegby vir logAlterations
    Private m_Adres As String
    'Andriette 22/01/2014 voeg die velde by
    Private m_motorstatus As String
    Private m_waardetipe As Integer
    Private m_adres2 As String
    Private m_areabeskrywing As String
    Private m_ingevoer As Integer
    Private m_laeprofielbande As Integer
    Private m_motorplan As Integer
    Private m_oornagbeskrywing As String
    Private m_kmperjaar As Integer
    Private m_genombestuurder1 As String
    Private m_genombestuurder2 As String
    Private m_genombestgebore1 As Integer
    Private m_genombestgebore2 As Integer
    Private m_gereeldebestuurder1 As String
    Private m_gereeldebestuurder2 As String
    Private m_gereeldebestuurder3 As String
    Private m_gereeldebestuurder4 As String
    Private m_gereeldebestgebore1 As Integer
    Private m_gereeldebestgebore2 As Integer
    Private m_gereeldebestgebore3 As Integer
    Private m_gereeldebestgebore4 As Integer
    Private m_kmlesingdatum As String
    Private m_motorplankm As Integer
    Private m_persentasiewaarde As Integer
    Private m_premievoertuig As Decimal
    Private m_premieekstras As Decimal
    Private m_waardevoertuig As Decimal
    'Andriette 22/01/2014 addisionele velde soos op tabel
    Private m_polisno As String
    Private m_sekeruteit As String
    Private m_kode1 As String
    Private m_modelnommer As String
    Private m_eienaar As String
    Private m_AreaFrekwensie As String
    Private m_Stad As String
    Private m_StandaardItems As Integer
    Private m_motorplanvervaldat As String
    Private m_PersentasieOp As String
    Private m_standaarditems2 As Integer
    Private m_verwyderdedatum As Date
    Private m_cancelled As Integer
    Private m_Motorhuis As Integer
    'Andriette 22/01/2014 Hierdie veld bestaan nie in die voertuie tabel nie 
    ' Ons voeg dit egter by omdat van die stored procedures die voertuie tabel join met die motors tabel en dan hierdie veld saam terugbring
    Private m_Besk As String

    <DataObjectField(False, False, False)> _
    Public Property WaardeEkstras() As Object
        Get
            Return m_WaardeEkstras
        End Get
        Set(ByVal value As Object)
            m_WaardeEkstras = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property pkVoertuie() As Integer
        Get
            Return m_pkVoertuie
        End Get
        Set(ByVal value As Integer)
            m_pkVoertuie = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property NoMatch() As Boolean
        Get
            Return m_NoMatch
        End Get
        Set(ByVal value As Boolean)
            m_NoMatch = value
        End Set
    End Property


    <DataObjectField(False, False, False)> _
    Public Property CourtesyVehAmount() As Decimal
        Get
            Return m_CourtesyVehAmount
        End Get
        Set(ByVal value As Decimal)
            m_CourtesyVehAmount = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property kilometerlesing() As Decimal
        Get
            Return m_kilometerlesing
        End Get
        Set(ByVal value As Decimal)
            m_kilometerlesing = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Huurkoop() As Integer
        Get
            Return m_huurkoop
        End Get
        Set(ByVal value As Integer)
            m_huurkoop = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property PremiePersentasie() As Integer
        Get
            Return m_PremiePersentasie
        End Get
        Set(ByVal value As Integer)
            m_PremiePersentasie = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Voorstad() As String
        Get
            Return m_Voorstad
        End Get
        Set(ByVal value As String)
            m_Voorstad = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property area_kode() As String
        Get
            Return m_area_kode
        End Get
        Set(ByVal value As String)
            m_area_kode = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property huurnommer() As String
        Get
            Return m_huurnommer
        End Get
        Set(ByVal value As String)
            'Kobus 24/04/2013 change 'huurnommer to m_huurnommer
            m_huurnommer = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Poskode() As String
        Get
            Return m_Poskode
        End Get
        Set(ByVal value As String)
            m_Poskode = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property vssratingjn() As String
        Get
            Return m_vssratingjn
        End Get
        Set(ByVal value As String)
            m_vssratingjn = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property vssratingbesk() As String
        Get
            Return m_vssratingbesk
        End Get
        Set(ByVal value As String)
            m_vssratingbesk = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property enjinnommer() As String
        Get
            Return m_enjinnommer
        End Get
        Set(ByVal value As String)
            m_enjinnommer = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property onderstelnommer() As String
        Get
            Return m_onderstelnommer
        End Get
        Set(ByVal value As String)
            m_onderstelnommer = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property huurinstansie() As String
        Get
            Return m_huurinstansie
        End Get
        Set(ByVal value As String)
            m_huurinstansie = value
        End Set
    End Property

    'Kobus 03/09/2013 verander van Integer na Boolean
    <DataObjectField(False, False, False)> _
    Public Property ANDER() As Boolean
        Get
            Return m_ANDER
        End Get
        Set(ByVal value As Boolean)
            m_ANDER = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property kleur() As String
        Get
            Return m_kleur
        End Get
        Set(ByVal value As String)
            m_kleur = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property SekuriteitBitValue() As String
        Get
            Return m_SekuriteitBitValue
        End Get
        Set(ByVal value As String)
            m_SekuriteitBitValue = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Maak() As String
        Get
            Return m_Maak
        End Get
        Set(ByVal value As String)
            m_Maak = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property JAAR() As String
        Get
            Return m_JAAR
        End Get
        Set(ByVal value As String)
            m_JAAR = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property N_PLAAT() As String
        Get
            Return m_N_PLAAT
        End Get
        Set(ByVal value As String)
            'Kobus 9/7/13 verander van m_SekuriteitBitValue = m_N_PLAAT - dit sal die regte waarde verseker
            m_N_PLAAT = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property TIPE_DEK() As String
        Get
            Return m_TIPE_DEK
        End Get
        Set(ByVal value As String)
            m_TIPE_DEK = value
        End Set
    End Property
    'Kobus 9/7/13 verander string na Decimal
    <DataObjectField(False, False, False)> _
    Public Property WAARDE() As Decimal
        Get
            Return m_WAARDE
        End Get
        Set(ByVal value As Decimal)
            m_WAARDE = FormatNumber((value), 0)
        End Set
    End Property

    'Kobus 9/7/13 verander van String na Decimal en format string
    <DataObjectField(False, False, False)> _
    Public Property PREMIE() As Decimal
        Get
            Return m_PREMIE
        End Get
        Set(ByVal value As Decimal)
            m_PREMIE = String.Format("{0:N2}", value)
        End Set
    End Property


    <DataObjectField(False, False, False)> _
    Public Property EEU() As String
        Get
            Return m_EEU
        End Get
        Set(ByVal value As String)
            m_EEU = value
        End Set
    End Property


    <DataObjectField(False, False, False)> _
    Public Property KODE() As String
        Get
            Return m_KODE
        End Get
        Set(ByVal value As String)
            m_KODE = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property GEBRUIK() As String
        Get
            Return m_GEBRUIK
        End Get
        Set(ByVal value As String)
            m_GEBRUIK = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property TIPE() As String
        Get
            Return m_TIPE
        End Get
        Set(ByVal value As String)
            m_TIPE = value
        End Set
    End Property
    'Kobus 11/11/2013 voegby vir logAlterations
    <DataObjectField(False, False, False)> _
Public Property Adres() As String
        Get
            Return m_Adres
        End Get
        Set(ByVal value As String)
            m_Adres = value
        End Set
    End Property



    <DataObjectField(False, False, False)> _
    Public Property motorstatus() As String
        Get
            Return m_motorstatus
        End Get
        Set(ByVal value As String)
            m_motorstatus = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property waardetipe() As Integer
        Get
            Return m_waardetipe
        End Get
        Set(ByVal value As Integer)
            m_waardetipe = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property adres2() As String
        Get
            Return m_adres2
        End Get
        Set(ByVal value As String)
            m_adres2 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property areabeskrywing() As String
        Get
            Return m_areabeskrywing
        End Get
        Set(ByVal value As String)
            m_areabeskrywing = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property ingevoer() As Integer
        Get
            Return m_ingevoer
        End Get
        Set(ByVal value As Integer)
            m_ingevoer = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property laeprofielbande() As Integer
        Get
            Return m_laeprofielbande
        End Get
        Set(ByVal value As Integer)
            m_laeprofielbande = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property motorplan() As Integer
        Get
            Return m_motorplan
        End Get
        Set(ByVal value As Integer)
            m_motorplan = value
        End Set
    End Property



    <DataObjectField(False, False, False)> _
    Public Property oornagbeskrywing() As String
        Get
            Return m_oornagbeskrywing
        End Get
        Set(ByVal value As String)
            m_oornagbeskrywing = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property kmperjaar() As String
        Get
            Return m_kmperjaar
        End Get
        Set(ByVal value As String)
            m_kmperjaar = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property genombestuurder1() As String
        Get
            Return m_genombestuurder1
        End Get
        Set(ByVal value As String)
            m_genombestuurder1 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property genombestuurder2() As String
        Get
            Return m_genombestuurder2
        End Get
        Set(ByVal value As String)
            m_genombestuurder2 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property genombestgebore1() As Integer
        Get
            Return m_genombestgebore1
        End Get
        Set(ByVal value As Integer)
            m_genombestgebore1 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property genombestgebore2() As Integer
        Get
            Return m_genombestgebore2
        End Get
        Set(ByVal value As Integer)
            m_genombestgebore2 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property gereeldebestuurder1() As String
        Get
            Return m_gereeldebestuurder1
        End Get
        Set(ByVal value As String)
            m_gereeldebestuurder1 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property gereeldebestuurder2() As String
        Get
            Return m_gereeldebestuurder2
        End Get
        Set(ByVal value As String)
            m_gereeldebestuurder2 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property gereeldebestuurder3() As String
        Get
            Return m_gereeldebestuurder3
        End Get
        Set(ByVal value As String)
            m_gereeldebestuurder3 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property gereeldebestuurder4() As String
        Get
            Return m_gereeldebestuurder4
        End Get
        Set(ByVal value As String)
            m_gereeldebestuurder4 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property gereeldebestgebore1() As Integer
        Get
            Return m_gereeldebestgebore1
        End Get
        Set(ByVal value As Integer)
            m_gereeldebestgebore1 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property gereeldebestgebore2() As Integer
        Get
            Return m_gereeldebestgebore2
        End Get
        Set(ByVal value As Integer)
            m_gereeldebestgebore2 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property gereeldebestgebore3() As Integer
        Get
            Return m_gereeldebestgebore3
        End Get
        Set(ByVal value As Integer)
            m_gereeldebestgebore3 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property gereeldebestgebore4() As Integer
        Get
            Return m_gereeldebestgebore4
        End Get
        Set(ByVal value As Integer)
            m_gereeldebestgebore4 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property kmlesingdatum() As String
        Get
            Return m_kmlesingdatum
        End Get
        Set(ByVal value As String)
            m_kmlesingdatum = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property motorplankm() As Integer
        Get
            Return m_motorplankm
        End Get
        Set(ByVal value As Integer)
            m_motorplankm = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property persentasiewaarde() As Integer
        Get
            Return m_persentasiewaarde
        End Get
        Set(ByVal value As Integer)
            m_persentasiewaarde = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property premievoertuig() As Decimal
        Get
            Return m_premievoertuig
        End Get
        Set(ByVal value As Decimal)
            m_premievoertuig = value
        End Set
    End Property
    'Private  As Decimal

    <DataObjectField(False, False, False)> _
    Public Property premieekstras() As Decimal
        Get
            Return m_premieekstras
        End Get
        Set(ByVal value As Decimal)
            m_premieekstras = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property waardevoertuig() As Decimal
        Get
            Return m_waardevoertuig
        End Get
        Set(ByVal value As Decimal)
            m_waardevoertuig = value
        End Set
    End Property



    <DataObjectField(False, False, False)> _
    Public Property Polisno() As String
        Get
            Return m_polisno
        End Get
        Set(ByVal value As String)
            m_polisno = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property sekeruteit() As String
        Get
            Return m_sekeruteit
        End Get
        Set(ByVal value As String)
            m_sekeruteit = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property kode1() As String
        Get
            Return m_kode1
        End Get
        Set(ByVal value As String)
            m_kode1 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property modelnommer() As String
        Get
            Return m_modelnommer
        End Get
        Set(ByVal value As String)
            m_modelnommer = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property eienaar() As String
        Get
            Return m_eienaar
        End Get
        Set(ByVal value As String)
            m_eienaar = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property AreaFrekwensie() As String
        Get
            Return m_AreaFrekwensie
        End Get
        Set(ByVal value As String)
            m_AreaFrekwensie = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property stad() As String
        Get
            Return m_Stad
        End Get
        Set(ByVal value As String)
            m_Stad = value
        End Set
    End Property


    <DataObjectField(False, False, False)> _
    Public Property StandaardItems() As Integer
        Get
            Return m_StandaardItems
        End Get
        Set(ByVal value As Integer)
            m_StandaardItems = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property motorplanvervaldat() As String
        Get
            Return m_motorplanvervaldat
        End Get
        Set(ByVal value As String)
            m_motorplanvervaldat = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property PersentasieOp() As String
        Get
            Return m_PersentasieOp
        End Get
        Set(ByVal value As String)
            m_PersentasieOp = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property StandaardItems2() As Integer
        Get
            Return m_standaarditems2
        End Get
        Set(ByVal value As Integer)
            m_standaarditems2 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property verwyderdedatum() As Date
        Get
            Return m_verwyderdedatum
        End Get
        Set(ByVal value As Date)
            m_verwyderdedatum = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Cancelled() As Integer
        Get
            Return m_cancelled
        End Get
        Set(ByVal value As Integer)
            m_cancelled = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property MotorHuis() As Integer
        Get
            Return m_Motorhuis
        End Get
        Set(ByVal value As Integer)
            m_Motorhuis = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Besk() As String
        Get
            Return m_Besk
        End Get
        Set(ByVal value As String)
            m_Besk = value
        End Set
    End Property
End Class
