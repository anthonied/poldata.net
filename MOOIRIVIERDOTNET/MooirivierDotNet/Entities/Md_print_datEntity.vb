Imports System.ComponentModel

<Serializable()> _
Public Class Md_print_datEntity
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    Private m_SUBTOTAAL As Double
    Private m_TV_DIENS As Double
    Private m_BEGRAFNIS As Double
    Private m_HuisBystandKomPers As String
    Private m_POLFOOI As Double
    Private m_SASPREM As Double
    Private m_Motorsekuriteitbitvaluememo As String
    Private m_PREMIE As Double
    Private m_BESK As String
    Private m_PakketItem1 As Decimal
    Private m_JAAR As String
    Private m_PakketItem2 As Decimal
    Private m_PakketItem3 As Decimal
    Private m_REG As String
    Private m_PakketItem4 As Decimal
    Private m_TIPE As String
    Private m_WAARDE As String
    Private m_MPREMIE As String
    Private m_VOERTUIE As Integer
    Private m_EISE As Integer
    Private m_POLISNO As String
    Private m_G_BONUS As String
    Private m_AREA As String
    Private m_BET_WYSE As String
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    Private m_PLIP As Double
    Private m_BESKERM As Double
    Private m_P_A_DAT2 As Date
    Private m_EEU As String
    Private m_pa_dat As String
    Private m_Afsluit_dat As Date
    Private m_careassist As Decimal
    Private m_eispers As String
    Private m_mmkode As String
    Private m_tipevoert As String
    Private m_bemarker As String
    Private m_adres3 As String
    Private m_motorsek As String
    Private m_afsluitdatum As Date
    Private m_gebruik As String

    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property SUBTOTAAL() As Double
        Get
            Return m_SUBTOTAAL
        End Get
        Set(ByVal value As Double)
            m_SUBTOTAAL = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property TV_DIENS() As Double
        Get
            Return m_TV_DIENS
        End Get
        Set(ByVal value As Double)
            m_TV_DIENS = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property BEGRAFNIS() As Double
        Get
            Return m_BEGRAFNIS
        End Get
        Set(ByVal value As Double)
            m_BEGRAFNIS = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property HuisBystandKomPers() As String
        Get
            Return m_HuisBystandKomPers
        End Get
        Set(ByVal value As String)
            m_HuisBystandKomPers = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property POLFOOI() As Double
        Get
            Return m_POLFOOI
        End Get
        Set(ByVal value As Double)
            m_POLFOOI = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property SASPREM() As Double
        Get
            Return m_SASPREM
        End Get
        Set(ByVal value As Double)
            m_SASPREM = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
        Public Property Motorsekuriteitbitvaluememo() As String
        Get
            Return m_Motorsekuriteitbitvaluememo
        End Get
        Set(ByVal value As String)
            m_Motorsekuriteitbitvaluememo = value
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
        Public Property BESK() As String
        Get
            Return m_BESK
        End Get
        Set(ByVal value As String)
            m_BESK = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
        Public Property PakketItem1() As Decimal
        Get
            Return m_PakketItem1
        End Get
        Set(ByVal value As Decimal)
            m_PakketItem1 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
        Public Property PakketItem2() As Decimal
        Get
            Return m_PakketItem2
        End Get
        Set(ByVal value As Decimal)
            m_PakketItem2 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
        Public Property PakketItem3() As Decimal
        Get
            Return m_PakketItem3
        End Get
        Set(ByVal value As Decimal)
            m_PakketItem3 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
        Public Property PakketItem4() As Decimal
        Get
            Return m_PakketItem4
        End Get
        Set(ByVal value As Decimal)
            m_PakketItem4 = value
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
        Public Property REG() As String
        Get
            Return m_REG
        End Get
        Set(ByVal value As String)
            m_REG = value
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
    <DataObjectField(False, False, False)> _
        Public Property WAARDE() As String
        Get
            Return m_WAARDE
        End Get
        Set(ByVal value As String)
            m_WAARDE = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
        Public Property VOERTUIE() As Integer
        Get
            Return m_VOERTUIE
        End Get
        Set(ByVal value As Integer)
            m_VOERTUIE = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
        Public Property MPREMIE() As String
        Get
            Return m_MPREMIE
        End Get
        Set(ByVal value As String)
            m_MPREMIE = value
        End Set
    End Property





    <DataObjectField(False, False, False)> _
            Public Property EISE() As Integer
        Get
            Return m_EISE
        End Get
        Set(ByVal value As Integer)
            m_EISE = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
            Public Property POLISNO() As String
        Get
            Return m_POLISNO
        End Get
        Set(ByVal value As String)
            m_POLISNO = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
            Public Property G_BONUS() As String
        Get
            Return m_G_BONUS
        End Get
        Set(ByVal value As String)
            m_G_BONUS = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
            Public Property BET_WYSE() As String
        Get
            Return m_BET_WYSE
        End Get
        Set(ByVal value As String)
            m_BET_WYSE = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property PLIP() As Double
        Get
            Return m_PLIP
        End Get
        Set(ByVal value As Double)
            m_PLIP = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property BESKERM() As Double
        Get
            Return m_BESKERM
        End Get
        Set(ByVal value As Double)
            m_BESKERM = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
            Public Property P_A_DAT2() As Date
        Get
            Return m_P_A_DAT2
        End Get
        Set(ByVal value As Date)
            m_P_A_DAT2 = value
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
            Public Property pa_dat() As String
        Get
            Return m_pa_dat
        End Get
        Set(ByVal value As String)
            m_pa_dat = value
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
            Public Property careassist() As Decimal
        Get
            Return m_careassist
        End Get
        Set(ByVal value As Decimal)
            m_careassist = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
            Public Property eispers() As String
        Get
            Return m_eispers
        End Get
        Set(ByVal value As String)
            m_eispers = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
            Public Property mmkode() As String
        Get
            Return m_mmkode
        End Get
        Set(ByVal value As String)
            m_mmkode = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
            Public Property tipevoert() As String
        Get
            Return m_tipevoert
        End Get
        Set(ByVal value As String)
            m_tipevoert = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
            Public Property bemarker() As String
        Get
            Return m_bemarker
        End Get
        Set(ByVal value As String)
            m_bemarker = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
            Public Property adres3() As String
        Get
            Return m_adres3
        End Get
        Set(ByVal value As String)
            m_adres3 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
            Public Property motorsek() As String
        Get
            Return m_motorsek
        End Get
        Set(ByVal value As String)
            m_motorsek = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
           Public Property afsluitdatum() As Date
        Get
            Return m_afsluitdatum
        End Get
        Set(ByVal value As Date)
            m_afsluitdatum = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
           Public Property gebruik() As String
        Get
            Return m_gebruik
        End Get
        Set(ByVal value As String)
            m_gebruik = value
        End Set
    End Property


End Class
