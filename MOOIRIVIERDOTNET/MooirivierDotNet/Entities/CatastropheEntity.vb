Imports System.ComponentModel

<Serializable()> _
Public Class CatastropheEntity
    Private m_Naam As String
    Private m_Datum As Date
    Private m_Bybetalingsbedrag As Decimal
    Private m_fkKatastrofeTipes As Integer
    Private m_pkKatastrofeTipes As Integer
    Private m_Beskrywing As String

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
    Public Property Datum() As Date
        Get
            Return m_Datum
        End Get
        Set(ByVal value As Date)
            m_Datum = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property fkKatastrofeTipes() As Integer
        Get
            Return m_fkKatastrofeTipes
        End Get
        Set(ByVal value As Integer)
            m_fkKatastrofeTipes = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Bybetalingsbedrag() As Decimal
        Get
            Return m_Bybetalingsbedrag
        End Get
        Set(ByVal value As Decimal)
            m_Bybetalingsbedrag = String.Format("{0:N2}", value)
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property pkKatastrofeTipes() As Integer
        Get
            Return m_pkKatastrofeTipes
        End Get
        Set(ByVal value As Integer)
            m_pkKatastrofeTipes = value
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
End Class

