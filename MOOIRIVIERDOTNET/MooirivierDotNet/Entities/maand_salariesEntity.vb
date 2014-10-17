
Imports System.ComponentModel

<Serializable()> _
Public Class Maand_SalariesEntity

    Private m_polisno As String
    Private m_VORD_DAT As String
    Private m_PREMIE As Date
    Private m_VORD_PREMIE As String
    Private m_AFSLUIT_DAT As String
    Private m_JAAR As String
    Private m_MAAND As String
    Private m_TRANS_DAT As String
    Private m_INGEVORDER As String
    Private m_NoMatch As Boolean
    <DataObjectField(False, False, False)> _
    Public Property NoMatch() As Boolean
        Get
            Return m_NoMatch
        End Get
        Set(ByVal value As Boolean)
            m_NoMatch = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property polisno() As String
        Get
            Return m_polisno
        End Get
        Set(ByVal value As String)
            m_polisno = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
   Public Property VORD_DAT() As String
        Get
            Return m_VORD_DAT
        End Get
        Set(ByVal value As String)
            m_VORD_DAT = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property VORD_PREMIE() As String
        Get
            Return m_VORD_PREMIE
        End Get
        Set(ByVal value As String)
            m_VORD_PREMIE = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property AFSLUIT_DAT() As String
        Get
            Return m_AFSLUIT_DAT
        End Get
        Set(ByVal value As String)
            m_AFSLUIT_DAT = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property PREMIE() As Date
        Get
            Return m_PREMIE
        End Get
        Set(ByVal value As Date)
            m_PREMIE = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property JAAR() As String
        Get
            Return m_JAAR
        End Get
        Set(ByVal value As String)
            m_JAAR = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property MAAND() As String
        Get
            Return m_MAAND
        End Get
        Set(ByVal value As String)
            m_MAAND = value

        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property TRANS_DAT() As String
        Get
            Return m_TRANS_DAT
        End Get
        Set(ByVal value As String)
            m_TRANS_DAT = value
        End Set
    End Property


    <DataObjectField(False, False, False)> _
       Public Property INGEVORDER() As String
        Get
            Return m_INGEVORDER
        End Get
        Set(ByVal value As String)
            m_INGEVORDER = value

        End Set
    End Property

End Class


