Imports System.ComponentModel

<Serializable()> _
Public Class InsertMemoEntiy
    Private m_pkMemo As Integer
    Private m_Polisno As String
    Private m_Gebruiker As String
    Private m_DatumToegevoer As Date
    Private m_Kategorie As Integer
    Private m_Beskrywing As String
    Private m_Deleted As Integer
    Private m_DatumVerander As Date

    <DataObjectField(False, False, False)> _
    Public Property pkMemo() As Integer
        Get
            Return m_pkMemo
        End Get
        Set(ByVal value As Integer)
            m_pkMemo = value
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
    Public Property Gebruiker() As String
        Get
            Return m_Gebruiker
        End Get
        Set(ByVal value As String)
            m_Gebruiker = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property DatumToegevoer() As Date
        Get
            Return m_DatumToegevoer
        End Get
        Set(ByVal value As Date)
            m_DatumToegevoer = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Kategorie() As Integer
        Get
            Return m_Kategorie
        End Get
        Set(ByVal value As Integer)
            m_Kategorie = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Beskrywing() As String
        Get
            Return m_Beskrywing
        End Get
        Set(ByVal value As String)
            m_Beskrywing = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property DatumVerander() As Date
        Get
            Return m_DatumVerander
        End Get
        Set(ByVal value As Date)
            m_DatumVerander = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Deleted() As Integer
        Get
            Return m_Deleted
        End Get
        Set(ByVal value As Integer)
            m_Deleted = value
        End Set
    End Property
End Class
