Imports System.ComponentModel

<Serializable()> _
Public Class AlleriskDropdownEntity

    Private m_Descr As String
    Private m_PK As Integer

    <DataObjectField(False, False, False)> _
    Public Property Descr() As String
        Get
            Return m_Descr
        End Get
        Set(ByVal value As String)
            m_Descr = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property PK() As Integer
        Get
            Return m_PK
        End Get
        Set(ByVal value As Integer)
            m_PK = value
        End Set
    End Property


End Class
