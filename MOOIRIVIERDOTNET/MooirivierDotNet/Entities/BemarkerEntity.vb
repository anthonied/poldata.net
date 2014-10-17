Imports System.ComponentModel

<Serializable()> _
Public Class BemarkerEntity
    Private m_naam As String
    Private m_kode_bem As String
    Private m_kode_bem_num As Integer
    Private m_description As String

    <DataObjectField(False, False, False)> _
    Public Property Naam() As String
        Get
            Return m_naam
        End Get
        Set(ByVal value As String)
            m_naam = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Kode_bem() As String
        Get
            Return m_kode_bem
        End Get
        Set(ByVal value As String)
            m_kode_bem = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Kode_bem_num() As Integer
        Get
            Return m_kode_bem_num
        End Get
        Set(ByVal value As Integer)
            m_kode_bem_num = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property description() As String
        Get
            Return m_description
        End Get
        Set(ByVal value As String)
            m_description = value
        End Set
    End Property

End Class
