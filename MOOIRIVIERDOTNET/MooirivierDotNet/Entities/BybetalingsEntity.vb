Imports System.ComponentModel
<Serializable()> _
Public Class BybetalingsEntity

    Private m_gewone As String
    Private m_bejaar As String
    Private m_duisend As String
    Private m_ander As String
    Private m_egewone As String
    Private m_ebejaarde As String
    Private m_enduisend As String
    Private m_eander As String
    Private m_alternatief As String
    Private m_ealternatief As String
    Private m_opsioneel As String
    Private m_eopsioneel As String
    Private m_BranchCode As Integer

    <DataObjectField(False, False, False)> _
   Public Property gewone() As String
        Get
            Return m_gewone
        End Get
        Set(ByVal value As String)
            m_gewone = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property bejaarde() As String
        Get
            Return m_bejaar
        End Get
        Set(ByVal value As String)
            m_bejaar = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property duisend() As String
        Get
            Return m_duisend
        End Get
        Set(ByVal value As String)
            m_duisend = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property ander() As String
        Get
            Return m_ander
        End Get
        Set(ByVal value As String)
            m_ander = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property egewone() As String
        Get
            Return m_egewone
        End Get
        Set(ByVal value As String)
            m_egewone = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property ebejaarde() As String
        Get
            Return m_ebejaarde
        End Get
        Set(ByVal value As String)
            m_ebejaarde = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property eduisend() As String
        Get
            Return m_enduisend
        End Get
        Set(ByVal value As String)
            m_enduisend = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
  Public Property eander() As String
        Get
            Return m_eander
        End Get
        Set(ByVal value As String)
            m_eander = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property alternatief() As String
        Get
            Return m_alternatief
        End Get
        Set(ByVal value As String)
            m_alternatief = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property ealternatief() As String
        Get
            Return m_ealternatief
        End Get
        Set(ByVal value As String)
            m_ealternatief = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property opsioneel() As String
        Get
            Return m_opsioneel
        End Get
        Set(ByVal value As String)
            m_opsioneel = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property eopsioneel() As String
        Get
            Return m_eopsioneel
        End Get
        Set(ByVal value As String)
            m_eopsioneel = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property BranchCode() As Integer
        Get
            Return m_BranchCode
        End Get
        Set(ByVal value As Integer)
            m_BranchCode = value
        End Set
    End Property

End Class
