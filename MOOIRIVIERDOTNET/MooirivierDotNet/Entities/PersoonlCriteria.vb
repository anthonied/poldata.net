
Imports System.ComponentModel
<Serializable()> _
Public Class PersoonlCriteria
    Private m_Language As String
    Private m_Status As String
    Private m_Area As String
    Private m_Surname As String
    Private m_gekans As String
    Private m_Versekeraar As String
    Private m_posbestemming As String
    Private m_AanvFrom As String
    Private m_AanvTo As String
    Private m_voorl As String
    Private m_PolisNo As String
    Private m_SavePosbesbesteming As String
    Private m_getStatus As String

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
  Public Property getStatus() As String
        Get
            Return m_getStatus
        End Get
        Set(ByVal value As String)
            m_getStatus = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property voorl() As String
        Get
            Return m_voorl
        End Get
        Set(ByVal value As String)
            m_voorl = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property PolisNo() As String
        Get
            Return m_PolisNo
        End Get
        Set(ByVal value As String)
            m_PolisNo = value
        End Set
    End Property
    

    <DataObjectField(False, False, False)> _
   Public Property Language() As String
        Get
            Return m_Language
        End Get
        Set(ByVal value As String)
            m_Language = value
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
    Public Property Area() As String
        Get
            Return m_Area
        End Get
        Set(ByVal value As String)
            m_Area = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Surname() As String
        Get
            Return m_Surname
        End Get
        Set(ByVal value As String)
            m_Surname = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
 Public Property gekans() As String
        Get
            Return m_gekans
        End Get
        Set(ByVal value As String)
            m_gekans = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Versekeraar() As String
        Get
            Return m_Versekeraar
        End Get
        Set(ByVal value As String)
            m_Versekeraar = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property posbestemming() As String
        Get
            Return m_posbestemming
        End Get
        Set(ByVal value As String)
            m_posbestemming = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property AanvFrom() As String
        Get
            Return m_AanvFrom
        End Get
        Set(ByVal value As String)
            m_AanvFrom = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property AanvTo() As String
        Get
            Return m_AanvTo
        End Get
        Set(ByVal value As String)
            m_AanvTo = value
        End Set
    End Property
End Class

