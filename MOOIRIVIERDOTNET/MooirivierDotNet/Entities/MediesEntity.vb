Imports System.ComponentModel

<Serializable()> _
Public Class MediesEntity
    Private m_POLISNO As String
    Private m_ME_UNIVE_P As String
    Private m_ME_GROOT_P As String
    Private m_ME_SIEKT_P As String
    Private m_ME_HOSPI_P As String
    Private m_ME_UNIVE_D As String
    Private m_ME_GROOT_D As String
    Private m_ME_SIEKT_D As String
    Private m_ME_HOSPI_D As String
    Private m_MEDIESE_V As String
    Private m_ME_UNIV_K As String
    Private m_ME_GROOT_K As String
    Private m_ME_SIEKT_K As String
    Private m_ME_HOSPI_K As String
    Private m_EGGENOTE As String
    Private m_EGGENOTE_G As Date
    Private m_NoMatch As Boolean

    <DataObjectField(False, False, False)> _
Public Property POLISNO() As String
        Get
            Return m_POLISNO
        End Get
        Set(ByVal value As String)
            m_POLISNO = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property ME_UNIVE_P() As String
        Get
            Return m_ME_UNIVE_P
        End Get
        Set(ByVal value As String)
            m_ME_UNIVE_P = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property ME_GROOT_P() As String
        Get
            Return m_ME_GROOT_P
        End Get
        Set(ByVal value As String)
            m_ME_GROOT_P = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property ME_SIEKT_P() As String
        Get
            Return m_ME_SIEKT_P
        End Get
        Set(ByVal value As String)
            m_ME_SIEKT_P = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property ME_HOSPI_P() As String
        Get
            Return m_ME_HOSPI_P
        End Get
        Set(ByVal value As String)
            m_ME_HOSPI_P = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property ME_UNIVE_D() As String
        Get
            Return m_ME_UNIVE_D
        End Get
        Set(ByVal value As String)
            m_ME_UNIVE_D = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property ME_GROOT_D() As String
        Get
            Return m_ME_GROOT_D
        End Get
        Set(ByVal value As String)
            m_ME_GROOT_D = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property ME_SIEKT_D() As String
        Get
            Return m_ME_SIEKT_D
        End Get
        Set(ByVal value As String)
            m_ME_SIEKT_D = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property ME_HOSPI_D() As String
        Get
            Return m_ME_HOSPI_D
        End Get
        Set(ByVal value As String)
            m_ME_HOSPI_D = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property MEDIESE_V() As String
        Get
            Return m_MEDIESE_V
        End Get
        Set(ByVal value As String)
            m_MEDIESE_V = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property ME_UNIV_K() As String
        Get
            Return m_ME_UNIV_K
        End Get
        Set(ByVal value As String)
            m_ME_UNIV_K = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property ME_GROOT_K() As String
        Get
            Return m_ME_GROOT_K
        End Get
        Set(ByVal value As String)
            m_ME_GROOT_K = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property ME_SIEKT_K() As String
        Get
            Return m_ME_SIEKT_K
        End Get
        Set(ByVal value As String)
            m_ME_SIEKT_K = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property ME_HOSPI_K() As String
        Get
            Return m_ME_HOSPI_K
        End Get
        Set(ByVal value As String)
            m_ME_HOSPI_K = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property EGGENOTE() As String
        Get
            Return m_EGGENOTE
        End Get
        Set(ByVal value As String)
            m_EGGENOTE = value
        End Set
    End Property


    <DataObjectField(False, False, False)> _
Public Property EGGENOTE_G() As Date
        Get
            Return m_EGGENOTE_G
        End Get
        Set(ByVal value As Date)
            m_EGGENOTE_G = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property NoMatch() As Boolean
        Get
            Return m_NoMatch
        End Get
        Set(ByVal value As Boolean)
            m_NoMatch = value
        End Set
    End Property
End Class
