
Imports System.ComponentModel

<Serializable()> _
Public Class Tak_NaamEntity
    Private m_tak_naam As String


    <DataObjectField(False, False, False)> _
    Public Property tak_naam() As String
        Get
            Return m_tak_naam
        End Get
        Set(ByVal value As String)
            m_tak_naam = value
        End Set
    End Property


End Class
