Imports System.ComponentModel

<Serializable()> _
Public Class SekuriteitEntity

    Private m_Sekuriteit As Integer
    Private m_Tipe As String
    Private m_Bit As Integer
    Private m_Bitvalue As Integer
    Private m_BeskrywingAfrikaans As String
    Private m_BeskrywingEngels As String
   

    <DataObjectField(False, False, False)> _
    Public Property Sekuriteit() As Integer
        Get
            Return m_Sekuriteit
        End Get
        Set(ByVal value As Integer)
            m_Sekuriteit = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Tipe() As String
        Get
            Return m_Tipe
        End Get
        Set(ByVal value As String)
            m_Tipe = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Bit() As Integer
        Get
            Return m_Bit
        End Get
        Set(ByVal value As Integer)
            m_Bit = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Bitvalue() As Integer
        Get
            Return m_Bitvalue
        End Get
        Set(ByVal value As Integer)
            m_Bitvalue = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property BeskrywingAfrikaans() As String
        Get
            Return m_BeskrywingAfrikaans
        End Get
        Set(ByVal value As String)
            m_BeskrywingAfrikaans = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property BeskrywingEngels() As String
        Get
            Return m_BeskrywingEngels
        End Get
        Set(ByVal value As String)
            m_BeskrywingEngels = value
        End Set
    End Property

   
End Class
