Imports System.ComponentModel
<Serializable()> _
Public Class WysigendosEntity

    Private m_Endosidentifikasie As String
    Private m_Endosdetmemo As String
    Private m_Datum As String
    Private m_Status As String
    Private m_Endosdetmemo2 As String
    Private m_Branchcode As String

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
    Public Property Endosdetmemo() As String
        Get
            Return m_Endosdetmemo
        End Get
        Set(ByVal value As String)
            m_Endosdetmemo = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Datum() As String
        Get
            Return m_Datum
        End Get
        Set(ByVal value As String)
            m_Datum = value
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
    Public Property Endosdetmemo2() As String
        Get
            Return m_Endosdetmemo2
        End Get
        Set(ByVal value As String)
            m_Endosdetmemo2 = value
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
