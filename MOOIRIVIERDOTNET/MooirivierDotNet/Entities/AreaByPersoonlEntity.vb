
Imports System.ComponentModel

<Serializable()> _
Public Class AreaByPersoonlEntity
    Private m_Area_besk As String
    Private m_Tak_afkorting As String
    Private m_Area_kode As String
    Private m_tak_naam As String
    Private m_LockEdits As Boolean
    <DataObjectField(False, False, False)> _
    Public Property tak_naam() As String
        Get
            Return m_tak_naam
        End Get
        Set(ByVal value As String)
            m_tak_naam = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property LockEdits() As Boolean
        Get
            Return m_LockEdits
        End Get
        Set(ByVal value As Boolean)
            m_LockEdits = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Tak_afkorting() As String
        Get
            Return m_Tak_afkorting
        End Get
        Set(ByVal value As String)
            m_Tak_afkorting = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Area_kode() As String
        Get
            Return m_Area_kode
        End Get
        Set(ByVal value As String)
            m_Area_kode = value
        End Set
    End Property
    

    <DataObjectField(False, False, False)> _
    Public Property Area_besk() As String
        Get
            Return m_Area_besk
        End Get
        Set(ByVal value As String)
            m_Area_besk = value
        End Set
    End Property
End Class


