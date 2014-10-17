Imports System.ComponentModel

<Serializable()> _
Public Class TakEntity

    Private m_taknaam As String
    Private m_tak_pobus As String
    Private m_tak_dorp As String
    Private m_tak_poskode As String
    Private m_tak_straat As String
    Private m_tak_tel As String
    Private m_tak_faks As String
    Private m_tak_moderm As String
    Private m_tak_univ As String
    Private m_tak_unive As String
    'Linkie 09/12/2013
    Private m_tak_afkorting As String


    <DataObjectField(False, False, False)> _
    Public Property TAKNAAM() As String
        Get
            Return m_taknaam
        End Get
        Set(ByVal value As String)
            m_taknaam = value
        End Set
    End Property

    'Linkie 09/12/2013
    <DataObjectField(False, False, False)> _
    Public Property Tak_afkorting() As String
        Get
            Return m_tak_afkorting
        End Get
        Set(ByVal value As String)
            m_tak_afkorting = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property TAK_POBUS() As String
        Get
            Return m_tak_pobus
        End Get
        Set(ByVal value As String)
            m_tak_pobus = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
 Public Property TAKDORP() As String
        Get
            Return m_tak_dorp
        End Get
        Set(ByVal value As String)
            m_tak_dorp = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
 Public Property TAK_POSKODE() As String
        Get
            Return m_tak_poskode
        End Get
        Set(ByVal value As String)
            m_tak_poskode = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
 Public Property TAK_STRAAT() As String
        Get
            Return m_tak_straat
        End Get
        Set(ByVal value As String)
            m_tak_straat = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property TAK_TEL() As String
        Get
            Return m_tak_tel
        End Get
        Set(ByVal value As String)
            m_tak_tel = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property TAK_FAKS() As String
        Get
            Return m_tak_faks
        End Get
        Set(ByVal value As String)
            m_tak_faks = value
        End Set
    End Property


    <DataObjectField(False, False, False)> _
Public Property TAK_MODERM() As String
        Get
            Return m_tak_moderm
        End Get
        Set(ByVal value As String)
            m_tak_moderm = value
        End Set
    End Property


    <DataObjectField(False, False, False)> _
Public Property TAK_UNIV() As String
        Get
            Return m_tak_univ
        End Get
        Set(ByVal value As String)
            m_tak_univ = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property TAK_UNIVE() As String
        Get
            Return m_tak_unive
        End Get
        Set(ByVal value As String)
            m_tak_unive = value
        End Set
    End Property
End Class
