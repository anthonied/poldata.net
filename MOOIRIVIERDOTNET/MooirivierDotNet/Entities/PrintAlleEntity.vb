Imports System.ComponentModel

<Serializable()> _
Public Class PrintAlleEntity
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    Private m_DEKKING As Double
    Private m_PREMIE As Double
    Private m_POLISNO As String
    Private m_Afsluit_dat As String
    Private m_BESKRYF As String
    Private m_arnplaat As String
    Private m_bet_wyse As String
    Private m_tipe2 As Integer
    Private m_itemnr As String
    Private m_afsluitdatum As Date

    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    Public Property DEKKING() As Double
        Get
            Return m_DEKKING
        End Get
        Set(ByVal value As Double)
            m_DEKKING = value
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

    Public Property POLISNO() As String
        Get
            Return m_POLISNO
        End Get
        Set(ByVal value As String)
            m_POLISNO = value
        End Set
    End Property

    Public Property Afsluit_dat() As String
        Get
            Return m_Afsluit_dat
        End Get
        Set(ByVal value As String)
            m_Afsluit_dat = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property BESKRYF() As Integer
        Get
            Return m_BESKRYF
        End Get
        Set(ByVal value As Integer)
            m_BESKRYF = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property arnplaat() As String
        Get
            Return m_arnplaat
        End Get
        Set(ByVal value As String)
            m_arnplaat = value
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

    <DataObjectField(False, False, False)> _
Public Property tipe2() As Integer
        Get
            Return m_tipe2
        End Get
        Set(ByVal value As Integer)
            m_tipe2 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property itemnr() As String
        Get
            Return m_itemnr
        End Get
        Set(ByVal value As String)
            m_itemnr = value
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

End Class
