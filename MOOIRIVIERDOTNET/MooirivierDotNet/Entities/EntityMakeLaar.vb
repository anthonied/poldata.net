
Imports System.ComponentModel
<Serializable()> _
Public Class EntityMakeLaar
    Private m_BeskrywingAfr As String
    Private m_BeskrywingEng As String
    Private m_DateCommenced As Date
    Private m_DateCancelled As Date
    Private m_pkMakelaar As Integer
    Private m_PreFix As String
    Private m_fkUMA As Integer
    Private m_Makelaar_afkorting As String
    Private m_Makelaar_Logo As String
    Private m_Makelaar_LogoLand As String
    Private m_Makelaar_groep As String
    Private m_Makelaar_groepEng As String
    'Linkie 11/07/2014
    Private m_NedbankleerAfkorting As String

    <DataObjectField(False, False, False)> _
    Public Property NedbankleerAfkorting() As String
        Get
            Return m_NedbankleerAfkorting
        End Get
        Set(ByVal value As String)
            m_NedbankleerAfkorting = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Makelaar_groep() As String
        Get
            Return m_Makelaar_groep
        End Get
        Set(ByVal value As String)
            m_Makelaar_groep = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Makelaar_groepEng() As String
        Get
            Return m_Makelaar_groepEng
        End Get
        Set(ByVal value As String)
            m_Makelaar_groepEng = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property BeskrywingAfr() As String
        Get
            Return m_BeskrywingAfr
        End Get
        Set(ByVal value As String)
            m_BeskrywingAfr = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property BeskrywingEng() As String
        Get
            Return m_BeskrywingEng
        End Get
        Set(ByVal value As String)
            m_BeskrywingEng = value
        End Set
    End Property



    <DataObjectField(False, False, False)> _
        Public Property DateCommenced() As Date
        Get
            Return m_DateCommenced
        End Get
        Set(ByVal value As Date)
            m_DateCommenced = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property DateCancelled() As Date
        Get
            Return m_DateCancelled
        End Get
        Set(ByVal value As Date)
            m_DateCancelled = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property pkMakelaar() As Integer
        Get
            Return m_pkMakelaar
        End Get
        Set(ByVal value As Integer)
            m_pkMakelaar = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property PreFix() As String
        Get
            Return m_PreFix
        End Get
        Set(ByVal value As String)
            m_PreFix = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
        Public Property fkUMA() As Integer
        Get
            Return m_fkUMA
        End Get
        Set(ByVal value As Integer)
            m_fkUMA = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Makelaar_afkorting() As String
        Get
            Return m_Makelaar_afkorting
        End Get
        Set(ByVal value As String)
            m_Makelaar_afkorting = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
        Public Property Makelaar_Logo() As String
        Get
            Return m_Makelaar_Logo
        End Get
        Set(ByVal value As String)
            m_Makelaar_Logo = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Makelaar_LogoLand() As String
        Get
            Return m_Makelaar_LogoLand
        End Get
        Set(ByVal value As String)
            m_Makelaar_LogoLand = value
        End Set
    End Property
End Class

