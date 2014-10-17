Imports System.ComponentModel
<Serializable()> _
Public Class maand_vt_balansEntity
    Private m_polisno As String
    Private m_AFSLUIT_DAT As DateTime
    Private m_VT_AANT As Integer
    Private m_VERSEKERDE As String
    Private m_VOORL As String
    Private m_JAAR As Integer
    Private m_MAAND As Integer
    Private m_VT_BALANS As Double
    Private m_TRANS_DAT As DateTime
    Private m_Index As String
    Private m_Nomatch As Boolean

    <DataObjectField(False, False, False)> _
    Public Property Index() As String
        Get
            Return m_Index
        End Get
        Set(ByVal value As String)
            m_Index = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property VT_BALANS() As Double
        Get
            Return m_VT_BALANS
        End Get
        Set(ByVal value As Double)
            m_VT_BALANS = value
        End Set
    End Property
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
    Public Property polisno() As String
        Get
            Return m_polisno
        End Get
        Set(ByVal value As String)
            m_polisno = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property AFSLUIT_DAT() As DateTime
        Get
            Return m_AFSLUIT_DAT
        End Get
        Set(ByVal value As DateTime)
            m_AFSLUIT_DAT = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property VT_AANT() As Integer
        Get
            Return m_VT_AANT
        End Get
        Set(ByVal value As Integer)
            m_VT_AANT = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property VERSEKERDE() As String
        Get
            Return m_VERSEKERDE
        End Get
        Set(ByVal value As String)
            m_VERSEKERDE = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property VOORL() As String
        Get
            Return m_VOORL
        End Get
        Set(ByVal value As String)
            m_VOORL = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property JAAR() As Integer
        Get
            Return m_JAAR
        End Get
        Set(ByVal value As Integer)
            m_JAAR = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property MAAND() As Integer
        Get
            Return m_MAAND
        End Get
        Set(ByVal value As Integer)
            m_MAAND = value

        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property TRANS_DAT() As DateTime
        Get
            Return m_TRANS_DAT
        End Get
        Set(ByVal value As DateTime)
            m_TRANS_DAT = value

        End Set
    End Property
   
End Class


