Imports System.ComponentModel
<Serializable()> _
Public Class EndmeestEntity
    Private m_Endosnaam As String
    Private m_Endosprint As String
    Private m_Endosdrukorals As String
    Private m_EndosAfrEng As String
    Private m_Endosidentifikasie As String
    Private m_Branchcode As String

    <DataObjectField(False, False, False)> _
    Public Property Endosnaam() As String
        Get
            Return m_Endosnaam
        End Get
        Set(ByVal value As String)
            m_Endosnaam = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Endosprint() As String
        Get
            Return m_Endosprint
        End Get
        Set(ByVal value As String)
            m_Endosprint = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Endosdrukorals() As String
        Get
            Return m_Endosdrukorals
        End Get
        Set(ByVal value As String)
            m_Endosdrukorals = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property EndosAfrEng() As String
        Get
            Return m_EndosAfrEng
        End Get
        Set(ByVal value As String)
            m_EndosAfrEng = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Endosidentifikasie() As String
        Get
            Return m_Endosidentifikasie
        End Get
        Set(ByVal value As String)
            m_Endosidentifikasie = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Branchcode() As String
        Get
            Return m_Branchcode
        End Get
        Set(ByVal value As String)
            m_Branchcode = value
        End Set
    End Property
End Class
