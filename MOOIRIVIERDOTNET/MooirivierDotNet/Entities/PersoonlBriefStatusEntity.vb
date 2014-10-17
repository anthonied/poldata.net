Imports System.ComponentModel

<Serializable()> _
Public Class PersoonlBriefStatusEntity

    Private m_polisno As String
    Private m_versekerde As String
    Private m_voorl As String
    Private m_areaBesk As String
    Private m_Status As String
    Private m_posbesbesteming As String
    Private m_SavePosbesbesteming As String

    <DataObjectField(False, False, False)> _
   Public Property SavePosbesbesteming() As String
        Get
            Return m_SavePosbesbesteming
        End Get
        Set(ByVal value As String)
            m_SavePosbesbesteming = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Versekerde() As String
        Get
            Return m_versekerde
        End Get
        Set(ByVal value As String)
            m_versekerde = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property POLISNO() As String
        Get
            Return m_polisno
        End Get
        Set(ByVal value As String)
            m_polisno = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property Voorl() As String
        Get
            Return m_voorl
        End Get
        Set(ByVal value As String)
            m_voorl = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property AreaBesk() As String
        Get
            Return m_areaBesk
        End Get
        Set(ByVal value As String)
            m_areaBesk = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Status() As String
        Get
            Return m_Status
        End Get
        Set(ByVal value As String)
            m_Status = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Posbesbesteming() As String
        Get
            Return m_posbesbesteming
        End Get
        Set(ByVal value As String)
            m_posbesbesteming = value
        End Set
    End Property

End Class
