Imports System.ComponentModel

<Serializable()> _
Public Class VerwysdesEntity
    Private m_pkVerwysdes As Integer
    Private m_Verwysde As String
    Private m_Verwyser As String
    Private m_DatumBegin As Date
    Private m_DatumEindig As Date
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    Private m_Verwyskommissie As Double
    Private m_Status As String

    <DataObjectField(False, False, False)> _
    Public Property pkVerwysdes() As Integer
        Get
            Return m_pkVerwysdes
        End Get
        Set(ByVal value As Integer)
            m_pkVerwysdes = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Verwysde() As String
        Get
            Return m_Verwysde
        End Get
        Set(ByVal value As String)
            m_Verwysde = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property Verwyser() As String
        Get
            Return m_Verwyser
        End Get
        Set(ByVal value As String)
            m_Verwyser = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property DatumBegin() As Date
        Get
            Return m_DatumBegin
        End Get
        Set(ByVal value As Date)
            m_DatumBegin = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property DatumEindig() As Date
        Get
            Return m_DatumEindig
        End Get
        Set(ByVal value As Date)
            m_DatumEindig = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property Verwyskommissie() As Double
        Get
            Return m_Verwyskommissie
        End Get
        Set(ByVal value As Double)
            m_Verwyskommissie = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Status() As String
        Get
            Return m_Status
        End Get
        Set(ByVal value As String)
            m_Status = value
        End Set
    End Property
End Class


