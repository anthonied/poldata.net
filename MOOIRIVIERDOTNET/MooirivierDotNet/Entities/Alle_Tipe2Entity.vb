Imports System.ComponentModel

<Serializable()> _
Public Class Alle_Tipe2Entity

    Private m_Afdeling As String
    Private m_Eistipekode As Integer
    Private m_Eistipe As String
    Private m_Hollardkat As Integer
    Private m_Hollardkatbesk As String
    Private m_EistipeEngels As String
    Private m_cancelled As Integer
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
Public Property Afdeling() As String
        Get
            Return m_Afdeling
        End Get
        Set(ByVal value As String)
            m_Afdeling = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Eistipekode() As Integer
        Get
            Return m_Eistipekode
        End Get
        Set(ByVal value As Integer)
            m_Eistipekode = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Eistipe() As String
        Get
            Return m_Eistipe
        End Get
        Set(ByVal value As String)
            m_Eistipe = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Hollardkat() As Integer
        Get
            Return m_Hollardkat
        End Get
        Set(ByVal value As Integer)
            m_Hollardkat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Hollardkatbesk() As String
        Get
            Return m_Hollardkatbesk
        End Get
        Set(ByVal value As String)
            m_Hollardkatbesk = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property EistipeEngels() As String
        Get
            Return m_EistipeEngels
        End Get
        Set(ByVal value As String)
            m_EistipeEngels = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property cancelled() As Integer
        Get
            Return m_cancelled
        End Get
        Set(ByVal value As Integer)
            m_cancelled = value
        End Set
    End Property
End Class
