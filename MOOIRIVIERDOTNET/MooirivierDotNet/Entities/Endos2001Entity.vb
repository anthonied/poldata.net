Imports System.ComponentModel
<Serializable()> _
Public Class Endos2001Entity

    Private m_Polisno As String
    Private m_Endosidentifikasie As String
    Private m_Endos_druk_op_polis As String
    Private m_Branchcode As String

    <DataObjectField(False, False, False)> _
    Public Property Polisno() As String
        Get
            Return m_Polisno
        End Get
        Set(ByVal value As String)
            m_Polisno = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Endosidentifikasie() As String
        Get
            Return m_Endosidentifikasie
        End Get
        Set(ByVal value As String)
            m_Endosidentifikasie = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Endos_druk_op_polis() As String
        Get
            Return m_Endos_druk_op_polis
        End Get
        Set(ByVal value As String)
            m_Endos_druk_op_polis = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Branchcode() As String
        Get
            Return m_Branchcode
        End Get
        Set(ByVal value As String)
            m_Branchcode = value
        End Set
    End Property
End Class
