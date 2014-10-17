
Imports System.ComponentModel

<Serializable()> _
Public Class ClaimsAssessorEntity
    Private m_AssessorName As String
    Private m_AssessorEmail As String
    Private m_AssessorAddress1 As String
    Private m_AssessorAddress2 As String
    Private m_AssessorSubburb As String
    Private m_AssessorTown As String
    Private m_AssessorPCode As String
    Private m_AssessorFax As String
    Private m_pkAssessor As Integer
    Private m_AssessorTel As String
    Private m_AssessorCell As String
    Private m_pkAssessorsPerClaim As Integer
    Private m_Eisno As String
    Private m_fkAssessor As Integer
    Private m_Cancel As Boolean

    <DataObjectField(False, False, False)> _
    Public Property AssessorName() As String
        Get
            Return m_AssessorName
        End Get
        Set(ByVal value As String)
            m_AssessorName = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property AssessorEmail() As String
        Get
            Return m_AssessorEmail
        End Get
        Set(ByVal value As String)
            m_AssessorEmail = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property AssessorAddress1() As String
        Get
            Return m_AssessorAddress1
        End Get
        Set(ByVal value As String)
            m_AssessorAddress1 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property AssessorAddress2() As String
        Get
            Return m_AssessorAddress2
        End Get
        Set(ByVal value As String)
            m_AssessorAddress2 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property AssessorSubburb() As String
        Get
            Return m_AssessorSubburb
        End Get
        Set(ByVal value As String)
            m_AssessorSubburb = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property AssessorTown() As String
        Get
            Return m_AssessorTown
        End Get
        Set(ByVal value As String)
            m_AssessorTown = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property AssessorPCode() As String
        Get
            Return m_AssessorPCode
        End Get
        Set(ByVal value As String)
            m_AssessorPCode = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property AssessorFax() As String
        Get
            Return m_AssessorFax
        End Get
        Set(ByVal value As String)
            m_AssessorFax = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property pkAssessor() As Integer
        Get
            Return m_pkAssessor
        End Get
        Set(ByVal value As Integer)
            m_pkAssessor = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property AssessorTel() As String
        Get
            Return m_AssessorTel
        End Get
        Set(ByVal value As String)
            m_AssessorTel = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property AssessorCell() As String
        Get
            Return m_AssessorCell
        End Get
        Set(ByVal value As String)
            m_AssessorCell = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property pkAssessorsPerClaim() As Integer
        Get
            Return m_pkAssessorsPerClaim
        End Get
        Set(ByVal value As Integer)
            m_pkAssessorsPerClaim = value
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
    <DataObjectField(False, False, False)> _
    Public Property Eisno() As String
        Get
            Return m_Eisno
        End Get
        Set(ByVal value As String)
            m_Eisno = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Cancel() As Boolean
        Get
            Return m_Cancel
        End Get
        Set(ByVal value As Boolean)
            m_Cancel = value
        End Set
    End Property
End Class
