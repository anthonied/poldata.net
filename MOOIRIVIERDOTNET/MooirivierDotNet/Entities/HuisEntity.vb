Imports System.ComponentModel

<Serializable()> _
Public Class HuisEntity

    Private m_POLISNO As String
    Private m_ADRES_H1 As String
    Private m_Adres4 As String
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    'Andriette 07/08/2013 verander die tipe na decimal van Double af
    Private m_WAARDE_HB As Decimal
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    'Andriette 07/08/2013 verander die tipe na decimal van Double af
    Private m_WAARDE_HE As Decimal
    Private m_voorstad As String
    Private m_SekuriteitBitValue As Integer
    Private m_EiendomDisplay As String
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    'Andriette 07/08/2013 verander die tipe na decimal van Double af
    Private m_premie_he As Decimal
    Private m_mainproperty As Integer
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    'Andriette 07/08/2013 verander die tipe na decimal van Double af
    Private m_toe_waarde As Decimal
    'Andriette 07/08/2013 verander die tipe na decimal van Double af
    Private m_toe_premie As Decimal
    'Andriette 07/08/2013 verander die tipe na decimal van Double af
    Private m_eem_waarde As Decimal
    'Andriette 07/08/2013 verander die tipe na decimal van Double af
    Private m_eem_premie As Decimal
    Private m_pkHuis As Integer
    Private m_tipe_dak As String
    Private m_struktuur As String
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    'Andriette 07/08/2013 verander die tipe na decimal van Double af
    Private m_premie_hb As Decimal
    Private m_sekuriteit As String
    Private m_NoMatch As Boolean
    Private m_Cancelled As Integer
    Private m_Verband As Integer
    Private m_bondNumber As String
    Private m_poskode As String
    Private m_dorp As String
    Private m_A_MONITOR As String
    Private m_A_MAAK As String
    Private m_AlarmReaksie As Integer
    Private m_WeerligBeskerming As Integer
    Private m_PremiePersentasieHB As Integer
    Private m_PremiePersentasieHE As Integer
    Private m_lapa As Integer
    Private m_OppervlakteLapa As Decimal
    Private m_OppervlakteHuis As Decimal
    Private m_ErfNommer As String
    Private m_fkHomeLoanOrg As Integer
    Private m_fkPropertyType As Integer
    Private m_pkPropertyType As Integer
    Private m_DatumVerwyder As Date
    Private m_POSHIERNATOE As Object
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    'Andriette 07/08/2013 verander die tipe na decimal van Double af
    Private m_WaardeEkstras As Decimal
    'Andriette 07/08/2013 verander die tipe na decimal van Double af
    Private m_premieEkstras As Decimal
    'Andriette 07/08/2013 verander die tipe na decimal van Double af
    Private m_PremieHE As Decimal
    Private m_A_KOMM As String
    Private m_A_GOEDGEKEUR As String
    'Kobus 01/10/2013 voegby
    Private m_WAARDEHE As Decimal

    '     ,[itemnr]
    '     ,[eem_waarde]
    '     ,[eem_premie]
    '     ,[sekuriteit]
    '     ,[hoofeiendom]
    '     , [WaardeHE]

    <DataObjectField(False, False, False)> _
    Public Property DatumVerwyder() As Date
        Get
            Return m_DatumVerwyder
        End Get
        Set(ByVal value As Date)
            m_DatumVerwyder = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property POSHIERNATOE() As Object
        Get
            Return m_POSHIERNATOE
        End Get
        Set(ByVal value As Object)
            m_POSHIERNATOE = value      ' Kobus Visser 19/03/2013 change to m_
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    'Andriette 07/08/2013 verander die tipe na decimal van Double af
    <DataObjectField(False, False, False)> _
    Public Property WaardeEkstras() As Decimal
        Get
            Return m_WaardeEkstras
        End Get
        Set(ByVal value As Decimal)
            m_WaardeEkstras = value     ' Kobus Visser 19/03/2013 change to m_
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    'Andriette 07/08/2013 verander die tipe na decimal van Double af
    <DataObjectField(False, False, False)> _
    Public Property premieEkstras() As Decimal
        Get
            Return m_premieEkstras
        End Get
        Set(ByVal value As Decimal)
            ' Kobus Visser 19/03/2013 change to m_ and format ' Andriette 08/08/2013
            m_premieEkstras = String.Format("{0:N2}", value)
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property PremieHE() As Decimal
        Get
            Return m_PremieHE
        End Get
        Set(ByVal value As Decimal)
            'Andriette 06/08/2013 verander die formatering
            ' m_PremieHE = value     ' Kobus Visser 19/03/2013 change to m_
            m_PremieHE = String.Format("{0:N2}", value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property A_KOMM() As String
        Get
            Return m_A_KOMM
        End Get
        Set(ByVal value As String)
            m_A_KOMM = value     ' Kobus Visser 19/03/2013 change to m_
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property A_GOEDGEKEUR() As String
        Get
            Return m_A_GOEDGEKEUR
        End Get
        Set(ByVal value As String)
            m_A_GOEDGEKEUR = value   ' Kobus Visser 19/03/2013 change to m_
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property A_MAAK() As String
        Get
            Return m_A_MAAK
        End Get
        Set(ByVal value As String)
            m_A_MAAK = value   ' Kobus Visser 19/03/2013 change to m_
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property ErfNommer() As String
        Get
            Return m_ErfNommer
        End Get
        Set(ByVal value As String)
            m_ErfNommer = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property A_MONITOR() As String
        Get
            Return m_A_MONITOR
        End Get
        Set(ByVal value As String)
            m_A_MONITOR = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property OppervlakteLapa() As Decimal
        Get
            Return m_OppervlakteLapa
        End Get
        Set(ByVal value As Decimal)
            m_OppervlakteLapa = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property OppervlakteHuis() As Decimal
        Get
            Return m_OppervlakteHuis
        End Get
        Set(ByVal value As Decimal)
            m_OppervlakteHuis = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property dorp() As String
        Get
            Return m_dorp
        End Get
        Set(ByVal value As String)
            m_dorp = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property poskode() As String
        Get
            Return m_poskode
        End Get
        Set(ByVal value As String)
            m_poskode = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property bondNumber() As String
        Get
            Return m_bondNumber
        End Get
        Set(ByVal value As String)
            m_bondNumber = value
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
Public Property NoMatch() As Boolean
        Get
            Return m_NoMatch
        End Get
        Set(ByVal value As Boolean)
            m_NoMatch = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property fkPropertyType() As Integer
        Get
            Return m_fkPropertyType
        End Get
        Set(ByVal value As Integer)
            m_fkPropertyType = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property pkPropertyType() As Integer
        Get
            Return m_pkPropertyType
        End Get
        Set(ByVal value As Integer)
            m_pkPropertyType = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property lapa() As Integer
        Get
            Return m_lapa
        End Get
        Set(ByVal value As Integer)
            m_lapa = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property fkHomeLoanOrg() As Integer
        Get
            Return m_fkHomeLoanOrg
        End Get
        Set(ByVal value As Integer)
            m_fkHomeLoanOrg = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property AlarmReaksie() As Integer
        Get
            Return m_AlarmReaksie
        End Get
        Set(ByVal value As Integer)
            m_AlarmReaksie = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property WeerligBeskerming() As Integer
        Get
            Return m_WeerligBeskerming
        End Get
        Set(ByVal value As Integer)
            m_WeerligBeskerming = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property PremiePersentasieHB() As Integer
        Get
            Return m_PremiePersentasieHB
        End Get
        Set(ByVal value As Integer)
            m_PremiePersentasieHB = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property PremiePersentasieHE() As Integer
        Get
            Return m_PremiePersentasieHE
        End Get
        Set(ByVal value As Integer)
            m_PremiePersentasieHE = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Verband() As Integer
        Get
            Return m_Verband
        End Get
        Set(ByVal value As Integer)
            m_Verband = value
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
    Public Property ADRES_H1() As String
        Get
            Return m_ADRES_H1
        End Get
        Set(ByVal value As String)
            m_ADRES_H1 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Adres4() As String
        Get
            Return m_Adres4
        End Get
        Set(ByVal value As String)
            m_Adres4 = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    'Andriette 07/08/2013 verander die tipe na decimal van Double af
    <DataObjectField(False, False, False)> _
    Public Property WAARDE_HB() As Decimal
        Get
            Return m_WAARDE_HB
        End Get
        Set(ByVal value As Decimal)
            m_WAARDE_HB = String.Format("{0:N0}", value)
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    'Andriette 07/08/2013 verander die tipe na decimal van Double af
    <DataObjectField(False, False, False)> _
    Public Property WAARDE_HE() As Decimal
        Get
            Return m_WAARDE_HE
        End Get
        Set(ByVal value As Decimal)
            m_WAARDE_HE = String.Format("{0:N0}", value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property voorstad() As String
        Get
            Return m_voorstad
        End Get
        Set(ByVal value As String)
            m_voorstad = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property SekuriteitBitValue() As Integer
        Get
            Return m_SekuriteitBitValue
        End Get
        Set(ByVal value As Integer)
            m_SekuriteitBitValue = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property EiendomDisplay() As String
        Get
            Return m_EiendomDisplay
        End Get
        Set(ByVal value As String)
            m_EiendomDisplay = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    'Andriette 07/08/2013 verander die tipe na decimal van Double af
    <DataObjectField(False, False, False)> _
    Public Property PREMIE_HE() As Decimal
        Get
            Return m_premie_he
        End Get
        Set(ByVal value As Decimal)
            'Andriette 06/08/2013 verander die formatering
            ' m_premie_he = value
            m_premie_he = String.Format("{0:N2}", value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property mainproperty() As Integer
        Get
            Return m_mainproperty
        End Get
        Set(ByVal value As Integer)
            m_mainproperty = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    'Andriette 07/08/2013 verander die tipe na decimal van Double af
    <DataObjectField(False, False, False)> _
    Public Property TOE_WAARDE() As Decimal
        Get
            Return m_toe_waarde
        End Get
        Set(ByVal value As Decimal)
            m_toe_waarde = String.Format("{0:N0}", value)
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    'Andriette 07/08/2013 verander die tipe na decimal van Double af
    <DataObjectField(False, False, False)> _
    Public Property TOE_PREMIE() As Decimal
        Get
            Return m_toe_premie
        End Get
        Set(ByVal value As Decimal)
            'Andriette 06/08/2013 verander die formatering
            '  m_toe_premie = value
            m_toe_premie = String.Format("{0:N2}", value)
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    'Andriette 07/08/2013 verander die tipe na decimal van Double af
    <DataObjectField(False, False, False)> _
    Public Property EEM_WAARDE() As Decimal
        Get
            Return m_eem_waarde
        End Get
        Set(ByVal value As Decimal)
            m_eem_waarde = String.Format("{0:N0}", value)
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    'Andriette 07/08/2013 verander die tipe na decimal van Double af
    <DataObjectField(False, False, False)> _
    Public Property EEM_PREMIE() As Decimal
        Get
            Return m_eem_premie
        End Get
        Set(ByVal value As Decimal)
            'Andriette 06/08/2013 verander die formatering
            '   m_eem_premie = value
            m_eem_premie = String.Format("{0:N2}", value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property pkHuis() As Integer
        Get
            Return m_pkHuis
        End Get
        Set(ByVal value As Integer)
            m_pkHuis = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property TIPE_DAK() As String
        Get
            Return m_tipe_dak
        End Get
        Set(ByVal value As String)
            m_tipe_dak = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property STRUKTUUR() As String
        Get
            Return m_struktuur
        End Get
        Set(ByVal value As String)
            m_struktuur = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    'Andriette 07/08/2013 verander die tipe na decimal van Double af
    <DataObjectField(False, False, False)> _
    Public Property PREMIE_HB() As Decimal
        Get
            Return m_premie_hb
        End Get
        Set(ByVal value As Decimal)
            'Andriette 06/08/2013 verander die formatering
            '   m_premie_hb = value
            m_premie_hb = String.Format("{0:N2}", value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property sekuriteit() As String
        Get
            Return m_sekuriteit
        End Get
        Set(ByVal value As String)
            m_sekuriteit = value
        End Set
    End Property
    'Kobus 01/10/2013 voegby
    <DataObjectField(False, False, False)> _
    Public Property WAARDEHE() As Decimal
        Get
            Return m_WAARDEHE
        End Get
        Set(ByVal value As Decimal)
            m_WAARDEHE = String.Format("{0:N0}", value)
        End Set
    End Property
End Class
