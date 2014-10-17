
Imports System.ComponentModel

<Serializable()> _
Public Class ClaimsBegunstigdeEntity
    Private m_Begunstigde As String
    Private m_Takkode As String
    Private m_Bank As String
    Private m_BankRekNo As String
    Private m_Rektipe As String
    Private m_stuurdmv As String
    Private m_Faks As String
    Private m_Email As String
    Private m_NedRekTipe As Integer
    Private m_BankIndeks As Integer
    Private m_fkBankCodes As Integer
    Private m_PayeeIdentification As String
    Private m_CategoryOfService As String
    Private m_SubCategoryOfService As String
    Private m_SpecialityOfServiceProvider As String
    Private m_fkAssessor As Integer
    Private m_pkBegunstigde As Integer
    <DataObjectField(False, False, False)> _
    Public Property pkBegunstigde() As Integer
        Get
            Return m_pkBegunstigde
        End Get
        Set(ByVal value As Integer)
            m_pkBegunstigde = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Begunstigde() As String
        Get
            Return m_Begunstigde
        End Get
        Set(ByVal value As String)
            m_Begunstigde = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Takkode() As String
        Get
            Return m_Takkode
        End Get
        Set(ByVal value As String)
            m_Takkode = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Bank() As String
        Get
            Return m_Bank
        End Get
        Set(ByVal value As String)
            m_Bank = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property BankRekNo() As String
        Get
            Return m_BankRekNo
        End Get
        Set(ByVal value As String)
            m_BankRekNo = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Rektipe() As String
        Get
            Return m_Rektipe
        End Get
        Set(ByVal value As String)
            m_Rektipe = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property stuurdmv() As String
        Get
            Return m_stuurdmv
        End Get
        Set(ByVal value As String)
            m_stuurdmv = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Faks() As String
        Get
            Return m_Faks
        End Get
        Set(ByVal value As String)
            m_Faks = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Email() As String
        Get
            Return m_Email
        End Get
        Set(ByVal value As String)
            m_Email = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property NedRekTipe() As Integer
        Get
            Return m_NedRekTipe
        End Get
        Set(ByVal value As Integer)
            m_NedRekTipe = value
        End Set
    End Property


    <DataObjectField(False, False, False)> _
    Public Property BankIndeks() As Integer
        Get
            Return m_BankIndeks
        End Get
        Set(ByVal value As Integer)
            m_BankIndeks = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property fkBankCodes() As Integer
        Get
            Return m_fkBankCodes
        End Get
        Set(ByVal value As Integer)
            m_fkBankCodes = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property PayeeIdentification() As String
        Get
            Return m_PayeeIdentification
        End Get
        Set(ByVal value As String)
            m_PayeeIdentification = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property CategoryOfService() As String
        Get
            Return m_CategoryOfService
        End Get
        Set(ByVal value As String)
            m_CategoryOfService = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property SubCategoryOfService() As String
        Get
            Return m_SubCategoryOfService
        End Get
        Set(ByVal value As String)
            m_SubCategoryOfService = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property SpecialityOfServiceProvider() As String
        Get
            Return m_SpecialityOfServiceProvider
        End Get
        Set(ByVal value As String)
            m_SpecialityOfServiceProvider = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property fkAssessor() As Integer
        Get
            Return m_fkAssessor
        End Get
        Set(ByVal value As Integer)
            m_fkAssessor = value
        End Set
    End Property

End Class
