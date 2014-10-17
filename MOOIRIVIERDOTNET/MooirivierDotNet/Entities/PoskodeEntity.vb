Imports System.ComponentModel

<Serializable()> _
Public Class PoskodeEntity

    Private m_Dorp As String
    Private m_Voorstad As String
    Private m_Poskode As String
    Private m_Foutboodskap As String
    Private m_pcidnum As Integer
    Private m_crestazone As Integer
    Private m_PoskodePosbus As String


    <DataObjectField(False, False, False)> _
  Public Property Dorp() As String
        Get
            Return m_Dorp
        End Get
        Set(ByVal value As String)
            m_Dorp = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Voorstad() As String
        Get
            Return m_Voorstad
        End Get
        Set(ByVal value As String)
            m_Voorstad = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Poskode() As String
        Get
            Return m_Poskode
        End Get
        Set(ByVal value As String)
            m_Poskode = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Foutboodskap() As String
        Get
            Return m_Foutboodskap
        End Get
        Set(ByVal value As String)
            m_Foutboodskap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property pcidnum() As Integer
        Get
            Return m_pcidnum
        End Get
        Set(ByVal value As Integer)
            m_pcidnum = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property crestazone() As Integer
        Get
            Return m_crestazone
        End Get
        Set(ByVal value As Integer)
            m_crestazone = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property PoskodePosbus() As String
        Get
            Return m_PoskodePosbus
        End Get
        Set(ByVal value As String)
            m_PoskodePosbus = value
        End Set
    End Property

End Class
