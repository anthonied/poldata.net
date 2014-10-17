Imports System.ComponentModel

<Serializable()> _
Public Class OUDSTUDENTEntity
    Private m_instansienaam As String
    <DataObjectField(False, False, False)> _
    Public Property INSTANSIENAAM() As String
        Get
            Return m_instansienaam
        End Get
        Set(ByVal value As String)
            m_instansienaam = value
        End Set
    End Property

End Class
