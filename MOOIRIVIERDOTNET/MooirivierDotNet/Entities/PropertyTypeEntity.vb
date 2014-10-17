Imports System.ComponentModel
<Serializable()> _
Public Class PropertyTypeEntity

    Private m_pkPropertyType As Integer
    Private m_ShortDescAfr As String
    Private m_ShortDescEng As String
    Private m_Description As String
    Private m_Nomatch As Boolean
    <DataObjectField(False, False, False)> _
Public Property Nomatch() As Boolean
        Get
            Return m_Nomatch
        End Get
        Set(ByVal value As Boolean)
            m_Nomatch = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property pkPropertyType() As Integer
        Get
            Return m_pkPropertyType
        End Get
        Set(ByVal value As Integer)
            m_pkPropertyType = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property ShortDescAfr() As String
        Get
            Return m_ShortDescAfr
        End Get
        Set(ByVal value As String)
            m_ShortDescAfr = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property ShortDescEng() As String
        Get
            Return m_ShortDescEng
        End Get
        Set(ByVal value As String)
            m_ShortDescEng = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Description() As String
        Get
            Return m_Description
        End Get
        Set(ByVal value As String)
            m_Description = value
        End Set
    End Property
End Class
