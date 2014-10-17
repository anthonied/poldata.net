
Imports System.ComponentModel

<Serializable()> _
Public Class KansellasieRedeEntity
    Private m_pkKansellasieRedes As Integer
    Private m_BeskrywingAfrikaans As String
    Private m_BeskrywingEngels As String
    Private m_Deleted As Integer


    <DataObjectField(False, False, False)> _
    Public Property pkKansellasieRedes() As Integer
        Get
            Return m_pkKansellasieRedes
        End Get
        Set(ByVal value As Integer)
            m_pkKansellasieRedes = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property BeskrywingAfrikaans() As String
        Get
            Return m_BeskrywingAfrikaans
        End Get
        Set(ByVal value As String)
            m_BeskrywingAfrikaans = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property BeskrywingEngels() As String
        Get
            Return m_BeskrywingEngels
        End Get
        Set(ByVal value As String)
            m_BeskrywingEngels = value
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
