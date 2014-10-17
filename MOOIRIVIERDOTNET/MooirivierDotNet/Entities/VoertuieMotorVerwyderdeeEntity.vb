Imports System.ComponentModel
<Serializable()> _
Public Class VoertuieMotorVerwyderdeeEntity

    '  ,[KODE1]
    '  ,[motorstatus]
    '  ,[modelnommer]

    '  ,[waardeTipe]
    '  ,[Eienaar]
    '  ,[AreaBeskrywing]
    '  ,[AreaFrekwensie]
    '  ,[Motorhuis]
    '  ,[Adres]
    '  ,[Stad]
    '  ,[OornagBeskrywing]
    '  ,[StandaardItems]
    '  ,[ingevoer]
    '  ,[KmPerJaar]
    '  ,[KmLesingDatum]
    '  ,[GereeldeBestuurder1]
    '  ,[GereeldeBestuurder2]
    '  ,[GereeldeBestuurder3]
    '  ,[GereeldeBestuurder4]
    '  ,[GereeldeBestGebore1]
    '  ,[GereeldeBestGebore2]
    '  ,[GereeldeBestGebore3]
    '  ,[GereeldeBestGebore4]
    '  ,[GenomBestuurder1]
    '  ,[GenomBestuurder2]
    '  ,[GenomBestGebore1]
    '  ,[GenomBestGebore2]
    '  ,[PremieEkstras]

    '  ,[Motorplan]
    '  ,[MotorplanVervalDat]
    '  ,[MotorplanKm]
    '  ,[LaeProfielbande]
    '  ,[PersentasieWaarde]
    '  ,[PersentasieOp]
    '  ,[PremieVoertuig]
    '  ,[WaardeVoertuig]
    '  ,[Adres2]
    '  ,[SekuriteitBitValue]
    '  ,[StandaardItems2]
    '  ,[Huurkoop]
    '  ,[VerwyderdeDatum]
    '  ,[]
    Private m_pkVoertuie As Integer
    Private m_SekuriteitBitValue As String
    Private m_Maak As String
    Private m_JAAR As String
    Private m_N_PLAAT As String
    Private m_TIPE_DEK As String
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    Private m_WAARDE As Double
    Private m_PREMIE As Double
    Private m_EEU As String
    Private m_KODE As String
    Private m_GEBRUIK As String
    Private m_TIPE As String
    Private m_CourtesyVehAmount As Decimal
    Private m_kleur As String
    Private m_ANDER As Integer
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
    Private m_WaardeEkstras As Object
    Private m_huurkoop As Integer
    Private m_besk As String
    Private m_verwyderdedatum As String
    Private m_motorstatus As String
    Private m_polisno As String
    Private m_Cancelled As Integer
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property WaardeEkstras() As Double
        Get
            Return m_WaardeEkstras
        End Get
        Set(ByVal value As Double)
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
Public Property Cancelled() As Integer
        Get
            Return m_Cancelled
        End Get
        Set(ByVal value As Integer)
            m_Cancelled = value
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
Public Property motorstatus() As String
        Get
            Return m_motorstatus
        End Get
        Set(ByVal value As String)
            m_motorstatus = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property huurnommer() As String
        Get
            Return m_huurnommer
        End Get
        Set(ByVal value As String)
            m_huurnommer = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property verwyderdedatum() As String
        Get
            Return m_verwyderdedatum
        End Get
        Set(ByVal value As String)
            m_verwyderdedatum = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property besk() As String
        Get
            Return m_besk
        End Get
        Set(ByVal value As String)
            m_besk = value
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

    <DataObjectField(False, False, False)> _
Public Property ANDER() As Integer
        Get
            Return m_ANDER
        End Get
        Set(ByVal value As Integer)
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
            m_SekuriteitBitValue = m_N_PLAAT
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
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property WAARDE() As Double
        Get
            Return m_WAARDE
        End Get
        Set(ByVal value As Double)
            m_WAARDE = value
        End Set
    End Property

    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property PREMIE() As Double
        Get
            Return m_PREMIE
        End Get
        Set(ByVal value As Double)
            m_PREMIE = value
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
End Class


