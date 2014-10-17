Imports System.ComponentModel
<Serializable()> _
Public Class GeyserTipeEntity
    Private m_pkGeyserTipe As Integer
    Private m_Afr As String
    Private m_Eng As String
    Private m_Cancelled As Integer
    <DataObjectField(False, False, False)> _
 Public Property pkGeyserTipe() As Integer
        Get
            Return m_pkGeyserTipe
        End Get
        Set(ByVal value As Integer)
            m_pkGeyserTipe = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property Afr() As String
        Get
            Return m_Afr
        End Get
        Set(ByVal value As String)
            m_Afr = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Eng() As String
        Get
            Return m_Eng
        End Get
        Set(ByVal value As String)
            m_Eng = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Cancelled() As Integer
        Get
            Return m_Cancelled
        End Get
        Set(ByVal value As Integer)
            m_Cancelled = value
        End Set
    End Property

End Class
