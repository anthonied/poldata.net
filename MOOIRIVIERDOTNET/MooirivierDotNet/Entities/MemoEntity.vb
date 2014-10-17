Imports System.ComponentModel

<Serializable()> _
Public Class MemoEntity
    Private m_pkmemo As Integer
    Private m_polisno As String
    Private m_gebruiker As String
    Private m_datumtoegevoer As String
    Private m_kategorie As String
    Private m_beskrywing As String
    Private m_deleted As Integer
    Private m_datumverander As String
    Private m_DatumJaarEerste As String
    <DataObjectField(False, False, False)> _
    Public Property pkMemo() As Integer
        Get
            Return m_pkmemo
        End Get
        Set(ByVal value As Integer)
            m_pkmemo = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property POLISNO() As String
        Get
            Return m_polisno
        End Get
        Set(ByVal value As String)
            m_polisno = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property Gebruiker() As String
        Get
            Return m_gebruiker
        End Get
        Set(ByVal value As String)
            m_gebruiker = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property DatumToegevoer() As String
        Get
            Return m_datumtoegevoer
        End Get
        Set(ByVal value As String)
            m_datumtoegevoer = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Kategorie() As String
        Get
            Return m_kategorie
        End Get
        Set(ByVal value As String)
            m_kategorie = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property DatumVerander() As String
        Get
            Return m_datumverander
        End Get
        Set(ByVal value As String)
            m_datumverander = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Deleted() As Integer
        Get
            Return m_deleted
        End Get
        Set(ByVal value As Integer)
            m_deleted = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Beskrywing() As String
        Get
            Return m_beskrywing
        End Get
        Set(ByVal value As String)
            m_beskrywing = value
        End Set
    End Property
    ' Andriette 02/05/2013 voeg nog ;n veld by wat die datum me die jaar eerste gee vir sortering

    Public Property DatumJaarEerste() As String
        Get
            Return m_DatumJaarEerste

        End Get
        Set(ByVal value As String)
            m_DatumJaarEerste = value
        End Set
    End Property
End Class
