Imports System.ComponentModel

<Serializable()> _
Public Class Selfoone
    Private m_maak As String
    Private m_model As String
    Private m_serialNo As String
    Private m_nommer As String
    Private m_kotrak As String
    Private m_waarde As Decimal
    Private m_premie As Decimal
    Private m_status As String
    Private m_kanselleer As String
    Private m_rede As String 'Andriette 01/08/2013 verander die naam
    Private m_pkSelfoon As Integer

    <DataObjectField(False, False, False)> _
    Public Property Make() As String
        Get
            Return m_maak
        End Get
        Set(ByVal value As String)
            m_maak = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Model() As String
        Get
            Return m_model
        End Get
        Set(ByVal value As String)
            m_model = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property SerialNo() As String
        Get
            Return m_serialNo
        End Get
        Set(ByVal value As String)
            m_serialNo = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Nommer() As String
        Get
            Return m_nommer
        End Get
        Set(ByVal value As String)
            m_nommer = value
        End Set
    End Property

    'Andriette 01/08/2013 brei die entity uit om al die velde te bevat
    <DataObjectField(False, False, False)> _
    Public Property Kontrak() As String
        Get
            Return m_kotrak
        End Get
        Set(ByVal value As String)
            m_kotrak = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Waarde() As Decimal
        Get
            Return m_waarde
        End Get
        Set(ByVal value As Decimal)
            m_waarde = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Premie() As Decimal
        Get
            Return m_premie
        End Get
        Set(ByVal value As Decimal)
            m_premie = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Status() As String
        Get
            Return m_status
        End Get
        Set(ByVal value As String)
            m_status = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Kanselleer() As String
        Get
            Return m_kanselleer
        End Get
        Set(ByVal value As String)
            m_kanselleer = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Rede() As String
        Get
            Return m_rede
        End Get
        Set(ByVal value As String)
            m_rede = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property pkSelfoon() As String
        Get
            Return m_pkSelfoon
        End Get
        Set(ByVal value As String)
            m_pkSelfoon = value
        End Set
    End Property

End Class