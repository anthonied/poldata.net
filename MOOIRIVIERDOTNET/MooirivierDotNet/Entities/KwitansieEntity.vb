
Imports System.ComponentModel
<Serializable()> _
Public Class KwitansieEntity
    Private m_volg_nr As String


    <DataObjectField(False, False, False)> _
Public Property volg_nr() As String
        Get
            Return m_volg_nr
        End Get
        Set(ByVal value As String)
            m_volg_nr = value
        End Set
    End Property
End Class
