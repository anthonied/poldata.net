Imports System.ComponentModel
<Serializable()> _
Public Class BevestigDescEntity
    Private m_bevestigDesc As String
    Private m_bevestigCode As Integer

    <DataObjectField(False, False, False)> _
 Public Property bevestigDesc() As String
        Get
            Return m_bevestigDesc
        End Get
        Set(ByVal value As String)
            m_bevestigDesc = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property bevestigCode() As Integer
        Get
            Return m_bevestigCode
        End Get
        Set(ByVal value As Integer)
            m_bevestigCode = value
        End Set
    End Property
End Class
