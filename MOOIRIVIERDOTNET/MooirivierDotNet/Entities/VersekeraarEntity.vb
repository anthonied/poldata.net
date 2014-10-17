Imports System.ComponentModel

<Serializable()> _
Public Class VersekeraarEntity

    Private m_pkVersekeraar As Integer
    Private m_Naam As String
    Private m_Bedryfsnaam As String
    Private m_Telno As String
    Private m_Registrasienommer As String
    Private m_DateCancelled As Date
    Private m_Posadres As String
    Private m_FisieseAdres As String
    Private m_BTWNommer As String
    Private m_PosVoorstad As String
    Private m_PosDorp As String
    Private m_FisiesVoorstad As String
    Private m_FisiesDorp As String
    Private m_PosPoskode As String
    Private m_FisiesPoskode As String
    Private m_Postaladdress As String
    Private m_PhysicalAddress As String
    Private m_DisFile As String
    Private m_DateStarted As Date
    Private m_WaterleweKommpers As Decimal
    Private m_PadbystandKomPers As Object
    Private m_HuisBystandKomPers As Object


    <DataObjectField(False, False, False)> _
  Public Property pkVersekeraar() As Integer
        Get
            Return m_pkVersekeraar
        End Get
        Set(ByVal value As Integer)
            m_pkVersekeraar = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Naam() As String
        Get
            Return m_Naam
        End Get
        Set(ByVal value As String)
            m_Naam = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Bedryfsnaam() As String
        Get
            Return m_Bedryfsnaam
        End Get
        Set(ByVal value As String)
            m_Bedryfsnaam = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Telno() As String
        Get
            Return m_Telno
        End Get
        Set(ByVal value As String)
            m_Telno = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Registrasienommer() As String
        Get
            Return m_Registrasienommer
        End Get
        Set(ByVal value As String)
            m_Registrasienommer = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property DateCancelled() As Date
        Get
            Return m_DateCancelled
        End Get
        Set(ByVal value As Date)
            m_DateCancelled = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Posadres() As String
        Get
            Return m_Posadres
        End Get
        Set(ByVal value As String)
            m_Posadres = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property FisieseAdres() As String
        Get
            Return m_FisieseAdres
        End Get
        Set(ByVal value As String)
            m_FisieseAdres = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property BTWNommer() As String
        Get
            Return m_BTWNommer
        End Get
        Set(ByVal value As String)
            m_BTWNommer = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property PosVoorstad() As String
        Get
            Return m_PosVoorstad
        End Get
        Set(ByVal value As String)
            m_PosVoorstad = value
        End Set
    End Property


    <DataObjectField(False, False, False)> _
Public Property PosDorp() As String
        Get
            Return m_PosDorp
        End Get
        Set(ByVal value As String)
            m_PosDorp = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property DisFile() As String
        Get
            Return m_DisFile
        End Get
        Set(ByVal value As String)
            m_DisFile = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property PhysicalAddress() As String
        Get
            Return m_PhysicalAddress
        End Get
        Set(ByVal value As String)
            m_PhysicalAddress = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property FisiesPoskode() As String
        Get
            Return m_FisiesPoskode
        End Get
        Set(ByVal value As String)
            m_FisiesPoskode = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Postaladdress() As String
        Get
            Return m_Postaladdress
        End Get
        Set(ByVal value As String)
            m_Postaladdress = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property FisiesVoorstad() As String
        Get
            Return m_FisiesVoorstad
        End Get
        Set(ByVal value As String)
            m_FisiesVoorstad = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property FisiesDorp() As String
        Get
            Return m_FisiesDorp
        End Get
        Set(ByVal value As String)
            m_FisiesDorp = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property PosPoskode() As String
        Get
            Return m_PosPoskode
        End Get
        Set(ByVal value As String)
            m_PosPoskode = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property DateStarted() As Date
        Get
            Return m_DateStarted
        End Get
        Set(ByVal value As Date)
            m_DateStarted = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property WaterleweKommpers() As Decimal
        Get
            Return m_WaterleweKommpers
        End Get
        Set(ByVal value As Decimal)
            m_WaterleweKommpers = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property HuisBystandKomPers() As Object
        Get
            Return m_HuisBystandKomPers
        End Get
        Set(ByVal value As Object)
            m_HuisBystandKomPers = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property PadbystandKomPers() As Object
        Get
            Return m_PadbystandKomPers
        End Get
        Set(ByVal value As Object)
            m_PadbystandKomPers = value
        End Set
    End Property

End Class

