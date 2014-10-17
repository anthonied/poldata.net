Imports System.ComponentModel
<Serializable()> _
Public Class BankCodes
    Private m_pkBankCodes As String
    Private m_BranchCode As String
    Private m_Bankname As String
    Private m_BranchName As String
    Private m_Period As String
    Private m_Comment As String
    Private m_description As String
    Private m_type As String
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
    Public Property pkBankCodes() As String
        Get
            Return m_pkBankCodes
        End Get
        Set(ByVal value As String)
            m_pkBankCodes = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
 Public Property Comment() As String
        Get
            Return m_Comment
        End Get
        Set(ByVal value As String)
            m_Comment = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Period() As String
        Get
            Return m_Period
        End Get
        Set(ByVal value As String)
            m_Period = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property BranchCode() As String
        Get
            Return m_BranchCode
        End Get
        Set(ByVal value As String)
            m_BranchCode = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property BranchName() As String
        Get
            Return m_BranchName
        End Get
        Set(ByVal value As String)
            m_BranchName = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Bankname() As String
        Get
            Return m_Bankname
        End Get
        Set(ByVal value As String)
            m_Bankname = value
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
    <DataObjectField(False, False, False)> _
Public Property type() As String
        Get
            Return m_type
        End Get
        Set(ByVal value As String)
            m_type = value
        End Set
    End Property
End Class

