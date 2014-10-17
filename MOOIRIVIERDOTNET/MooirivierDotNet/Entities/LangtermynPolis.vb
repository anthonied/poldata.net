Imports System.ComponentModel

<Serializable()> _
Public Class LangtermynPolis
    Private m_pkLangtermynPolis As Integer
    Private m_polisno As String
    Private m_datum_begin As Date
    Private m_datum_eindig As Date
    Private m_tydperk As Integer
    Private m_NoMatch As Boolean


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
Public Property pkLangtermynPolis() As Integer
        Get
            Return m_pkLangtermynPolis
        End Get
        Set(ByVal value As Integer)
            m_pkLangtermynPolis = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Polisno() As String
        Get
            Return m_polisno
        End Get
        Set(ByVal value As String)
            m_polisno = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property DatumBegin() As Date
        Get
            Return m_datum_begin
        End Get
        Set(ByVal value As Date)
            m_datum_begin = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property DatumEindig() As Date
        Get
            Return m_datum_eindig
        End Get
        Set(ByVal value As Date)
            m_datum_eindig = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property Tydperk() As Integer
        Get
            Return m_tydperk
        End Get
        Set(ByVal value As Integer)
            m_tydperk = value
        End Set
    End Property

End Class
