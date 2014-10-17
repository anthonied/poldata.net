Imports System.ComponentModel

<Serializable()> _
Public Class TitleEntity
    Private m_id As Integer
    Private m_title As String
    <DataObjectField(False, False, False)> _
    Public Property ID() As String
        Get
            Return m_id
        End Get
        Set(ByVal value As String)
            m_id = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Title() As String
        Get
            Return m_title
        End Get
        Set(ByVal value As String)
            m_title = value
        End Set
    End Property
End Class
