Imports System.ComponentModel

<Serializable()> _
Public Class Print2DatEntity

    Private m_Verwyskommissie As Decimal
    Private m_Premie2 As Decimal
    Private m_Polisno As String
    Private m_Afsluit_dat As String
    Private m_ongespesifiseerd As Decimal
    Private m_ongevalle As Decimal
    Private m_courtesyv As Decimal
    Private m_afsluitdatum As Date
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    Private m_alle_sub As Double
    Private m_huis_sub As Double
    Private m_motor_sub As Double
    Private m_id_nom As String
    Private m_bybet_k As String
    Private m_eispers As String
    Private m_Huispremie As String
    Private m_epc As Decimal
    Private m_inscell As Decimal
    Private m_AddisionelePremie As Decimal
    Private m_PersoonlAddisionelePremie As Decimal
    Private m_bet_wyse As String
    Private m_toe_waarde As Decimal
    Private m_toe_premie As Decimal
    Private m_eem_waarde As Decimal
    Private m_eem_premie As Decimal
    Private m_Nomatch As Boolean
    Private m_huisadres As String
    Private m_hehb As String


    <DataObjectField(False, False, False)> _
Public Property hehb() As String
        Get
            Return m_hehb
        End Get
        Set(ByVal value As String)
            m_hehb = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property huisadres() As String
        Get
            Return m_huisadres
        End Get
        Set(ByVal value As String)
            m_huisadres = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Huispremie() As String
        Get
            Return m_Huispremie
        End Get
        Set(ByVal value As String)
            m_Huispremie = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Nomatch() As Boolean
        Get
            Return m_Nomatch
        End Get
        Set(ByVal value As Boolean)
            m_Nomatch = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property toe_waarde() As Decimal
        Get
            Return m_toe_waarde
        End Get
        Set(ByVal value As Decimal)
            m_toe_waarde = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property toe_premie() As Decimal
        Get
            Return m_toe_premie
        End Get
        Set(ByVal value As Decimal)
            m_toe_premie = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property eem_waarde() As Decimal
        Get
            Return m_eem_waarde
        End Get
        Set(ByVal value As Decimal)
            m_eem_waarde = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property eem_premie() As Decimal
        Get
            Return m_eem_premie
        End Get
        Set(ByVal value As Decimal)
            m_eem_premie = value
        End Set
    End Property
        
    <DataObjectField(False, False, False)> _
Public Property Verwyskommissie() As Decimal
        Get
            Return m_Verwyskommissie
        End Get
        Set(ByVal value As Decimal)
            m_Verwyskommissie = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Premie2() As Decimal
        Get
            Return m_Premie2
        End Get
        Set(ByVal value As Decimal)
            m_Premie2 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Polisno() As String
        Get
            Return m_Polisno
        End Get
        Set(ByVal value As String)
            m_Polisno = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Afsluit_dat() As String
        Get
            Return m_Afsluit_dat
        End Get
        Set(ByVal value As String)
            m_Afsluit_dat = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property ongespesifiseerd() As Decimal
        Get
            Return m_ongespesifiseerd
        End Get
        Set(ByVal value As Decimal)
            m_ongespesifiseerd = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property ongevalle() As Decimal
        Get
            Return m_ongevalle
        End Get
        Set(ByVal value As Decimal)
            m_ongevalle = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property courtesyv() As Decimal
        Get
            Return m_courtesyv
        End Get
        Set(ByVal value As Decimal)
            m_courtesyv = value
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
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property alle_sub() As Double
        Get
            Return m_alle_sub
        End Get
        Set(ByVal value As Double)
            m_alle_sub = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property huis_sub() As Double
        Get
            Return m_huis_sub
        End Get
        Set(ByVal value As Double)
            m_huis_sub = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property motor_sub() As Double
        Get
            Return m_motor_sub
        End Get
        Set(ByVal value As Double)
            m_motor_sub = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property id_nom() As String
        Get
            Return m_id_nom
        End Get
        Set(ByVal value As String)
            m_id_nom = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property bybet_k() As String
        Get
            Return m_bybet_k
        End Get
        Set(ByVal value As String)
            m_bybet_k = value
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
Public Property epc() As Decimal
        Get
            Return m_epc
        End Get
        Set(ByVal value As Decimal)
            m_epc = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property inscell() As Decimal
        Get
            Return m_inscell
        End Get
        Set(ByVal value As Decimal)
            m_inscell = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property AddisionelePremie() As Decimal
        Get
            Return m_AddisionelePremie
        End Get
        Set(ByVal value As Decimal)
            m_AddisionelePremie = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property PersoonlAddisionelePremie() As Decimal
        Get
            Return m_PersoonlAddisionelePremie
        End Get
        Set(ByVal value As Decimal)
            m_PersoonlAddisionelePremie = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property bet_wyse() As String
        Get
            Return m_bet_wyse
        End Get
        Set(ByVal value As String)
            m_bet_wyse = value
        End Set
    End Property

End Class
