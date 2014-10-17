
Imports System.ComponentModel

<Serializable()> _
Public Class NedBegunstigdeHeaderEntity
    Private m_Begunstigde As String
    Private m_Aksiedatum As String
    Private m_Bedrag As Decimal
    Private m_Toetslopie As String
    Private m_Batchid As String
    Private m_Aksiedatum2 As Date
    Private m_Polisno As String

    <DataObjectField(False, False, False)> _
    Public Property Begunstigde() As String
        Get
            Return m_Begunstigde
        End Get
        Set(ByVal value As String)
            m_Begunstigde = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Aksiedatum() As String
        Get
            Return m_Aksiedatum
        End Get
        Set(ByVal value As String)
            m_Aksiedatum = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Bedrag() As Decimal
        Get
            Return m_Bedrag
        End Get
        Set(ByVal value As Decimal)
            m_Bedrag = String.Format("{0:N2}", value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Toetslopie() As String
        Get
            Return m_Toetslopie
        End Get
        Set(ByVal value As String)
            m_Toetslopie = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Batchid() As String
        Get
            Return m_Batchid
        End Get
        Set(ByVal value As String)
            m_Batchid = value
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
    Public Property Aksiedatum2() As Date
        Get
            Return m_Aksiedatum2
        End Get
        Set(ByVal value As Date)
            m_Aksiedatum2 = value
        End Set
    End Property

End Class
