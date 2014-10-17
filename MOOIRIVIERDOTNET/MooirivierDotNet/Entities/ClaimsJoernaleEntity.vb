
Imports System.ComponentModel

<Serializable()> _
Public Class ClaimsJoernaleEntity
    Private m_pkJoernale As Integer
    Private m_polisno As String
    Private m_eisno As String
    Private m_JoernaleVord_dat As Date
    Private m_JoernaleVord_Premie As Decimal
    Private m_Jaar As Integer
    Private m_Maand As Integer
    Private m_Trans_dat As Date
    Private m_Gekans As Integer
    Private m_CancelledIcon As String
    Private m_JoernaleTipe As String
    Private m_Kontant_Tipe As String
    Private m_JoernaleTjekdatum As Date
    Private m_JoernaleTjekbesonderhede As String
    Private m_Btwuitbedrag As Decimal
    Private m_Btwbedrag As Decimal
    Private m_Btwjn As String
    Private m_JoernaleFaktuurnr As String
    Private m_Waarvoor As String
    Private m_KruisVerwysing As String
    Private m_TjekofElektronies As String
    Private m_VATNumber As String
    Private m_ServiceProviderName As String
    Private m_PayeeIdentification As String
    Private m_CategoryofService As String
    Private m_SubCategoryofService As String
    Private m_SpecialityofServiceProvider As String

    <DataObjectField(False, False, False)> _
    Public Property eisno() As String
        Get
            Return m_eisno
        End Get
        Set(ByVal value As String)
            m_eisno = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property polisno() As String
        Get
            Return m_polisno
        End Get
        Set(ByVal value As String)
            m_polisno = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property JTjekbesonderhede() As String
        Get
            Return m_JoernaleTjekbesonderhede
        End Get
        Set(ByVal value As String)
            m_JoernaleTjekbesonderhede = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property JVord_Premie() As Decimal
        Get
            Return m_JoernaleVord_Premie
        End Get
        Set(ByVal value As Decimal)
            m_JoernaleVord_Premie = String.Format("{0:N2}", value)
        End Set
    End Property
    

    <DataObjectField(False, False, False)> _
    Public Property JFaktuurnr() As String
        Get
            Return m_JoernaleFaktuurnr
        End Get
        Set(ByVal value As String)
            m_JoernaleFaktuurnr = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Btwuitbedrag() As Decimal
        Get
            Return m_Btwuitbedrag
        End Get
        Set(ByVal value As Decimal)
            m_Btwuitbedrag = String.Format("{0:N2}", value)
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Btwbedrag() As Decimal
        Get
            Return m_Btwbedrag
        End Get
        Set(ByVal value As Decimal)
            m_Btwbedrag = String.Format("{0:N2}", value)
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Btwjn() As String
        Get
            Return m_Btwjn
        End Get
        Set(ByVal value As String)
            m_Btwjn = value
        End Set
    End Property


    <DataObjectField(False, False, False)> _
    Public Property TjekofElektronies() As String
        Get
            Return m_TjekofElektronies
        End Get
        Set(ByVal value As String)
            m_TjekofElektronies = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Waarvoor() As String
        Get
            Return m_Waarvoor
        End Get
        Set(ByVal value As String)
            m_Waarvoor = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Trans_dat() As Date
        Get
            Return m_Trans_dat
        End Get
        Set(ByVal value As Date)
            m_Trans_dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property KruisVerwysing() As String
        Get
            Return m_KruisVerwysing
        End Get
        Set(ByVal value As String)
            m_KruisVerwysing = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property JTipe() As String
        Get
            Return m_JoernaleTipe
        End Get
        Set(ByVal value As String)
            m_JoernaleTipe = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Kontant_Tipe() As String
        Get
            Return m_Kontant_Tipe
        End Get
        Set(ByVal value As String)
            m_Kontant_Tipe = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property JVord_dat() As Date
        Get
            Return m_JoernaleVord_dat
        End Get
        Set(ByVal value As Date)
            m_JoernaleVord_dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property JTjekdatum() As Date
        Get
            Return m_JoernaleTjekdatum
        End Get
        Set(ByVal value As Date)
            m_JoernaleTjekdatum = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property pkJoernale() As Integer
        Get
            Return m_pkJoernale
        End Get
        Set(ByVal value As Integer)
            m_pkJoernale = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Gekans() As Integer
        Get
            Return m_Gekans
        End Get
        Set(ByVal value As Integer)
            m_Gekans = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Maand() As Integer
        Get
            Return m_Maand
        End Get
        Set(ByVal value As Integer)
            m_Maand = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Jaar() As Integer
        Get
            Return m_Jaar
        End Get
        Set(ByVal value As Integer)
            m_Jaar = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property CancelledIcon() As String
        Get
            Return m_CancelledIcon
        End Get
        Set(ByVal value As String)
            m_CancelledIcon = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property VatNumber() As String
        Get
            Return m_VatNumber
        End Get
        Set(ByVal value As String)
            m_VatNumber = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property ServiceProviderName() As String
        Get
            Return m_ServiceProviderName
        End Get
        Set(ByVal value As String)
            m_ServiceProviderName = value
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
    Public Property CategoryofService() As String
        Get
            Return m_CategoryofService
        End Get
        Set(ByVal value As String)
            m_CategoryofService = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property SubCategoryofService() As String
        Get
            Return m_SubCategoryofService
        End Get
        Set(ByVal value As String)
            m_SubCategoryofService = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property SpecialityofServiceProvider() As String
        Get
            Return m_SpecialityofServiceProvider
        End Get
        Set(ByVal value As String)
            m_SpecialityofServiceProvider = value
        End Set
    End Property
End Class
