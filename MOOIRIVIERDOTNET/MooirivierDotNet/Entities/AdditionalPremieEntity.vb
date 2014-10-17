Imports System.ComponentModel
<Serializable()> _
Public Class AdditionalPremieEntity
    Private m_motors As Decimal
    Private m_Waterlewe As Decimal
    Private m_AlleRisiko As Decimal
    Private m_HB As Decimal
    Private m_HE As Decimal
    Private m_HBGras As Decimal
    Private m_HEGras As Decimal
    Private m_ToevalEEM As Decimal
    Private m_ToevalBreek As Decimal
    Private m_Beskerm As Decimal
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    Private m_Sasria As Double
    Private m_TVDiens As Decimal
    Private m_Polisfooi As Decimal
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    Private m_Begrafnis As Double
    Private m_Plip As Double
    Private m_CourtesyV As Decimal
    Private m_EPC As Decimal
    Private m_CareAssist As Decimal
    Private m_Selfoon As Decimal
    Private m_PakketItem1 As Decimal
    Private m_PakketItem2 As Decimal
    Private m_pkAddisionelePremie As Integer
    Private m_datAfgesluit As String
    Private m_afgesluit As Integer
    Private m_datToegevoer As String
    Private m_totaal As Decimal
    Private m_Nomatch As Boolean
    Private m_DisplayValue As String
    <DataObjectField(False, False, False)> _
  Public Property Nomatch() As Boolean
        Get
            Return m_Nomatch
        End Get
        Set(ByVal value As Boolean)
            m_Nomatch = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property totaal() As Decimal
        Get
            Return m_totaal
        End Get
        Set(ByVal value As Decimal)
            m_totaal = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property datAfgesluit() As String
        Get
            Return m_datAfgesluit
        End Get
        Set(ByVal value As String)
            m_datAfgesluit = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property afgesluit() As Integer
        Get
            Return m_afgesluit
        End Get
        Set(ByVal value As Integer)
            m_afgesluit = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property datToegevoer() As String
        Get
            Return m_datToegevoer
        End Get
        Set(ByVal value As String)
            m_datToegevoer = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property motors() As Decimal
        Get
            Return m_motors
        End Get
        Set(ByVal value As Decimal)
            m_motors = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property Waterlewe() As Decimal
        Get
            Return m_Waterlewe
        End Get
        Set(ByVal value As Decimal)
            m_Waterlewe = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property AlleRisiko() As Decimal
        Get
            Return m_AlleRisiko
        End Get
        Set(ByVal value As Decimal)
            m_AlleRisiko = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property HB() As Decimal
        Get
            Return m_HB
        End Get
        Set(ByVal value As Decimal)
            m_HB = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property HE() As Decimal
        Get
            Return m_HE
        End Get
        Set(ByVal value As Decimal)
            m_HE = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property HBGras() As Decimal
        Get
            Return m_HBGras
        End Get
        Set(ByVal value As Decimal)
            m_HBGras = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property HEGras() As Decimal
        Get
            Return m_HEGras
        End Get
        Set(ByVal value As Decimal)
            m_HEGras = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property ToevalEEM() As Decimal
        Get
            Return m_ToevalEEM
        End Get
        Set(ByVal value As Decimal)
            m_ToevalEEM = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property ToevalBreek() As Decimal
        Get
            Return m_ToevalBreek
        End Get
        Set(ByVal value As Decimal)
            m_ToevalBreek = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property Beskerm() As Decimal
        Get
            Return m_Beskerm
        End Get
        Set(ByVal value As Decimal)
            m_Beskerm = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property Sasria() As Double
        Get
            Return m_Sasria
        End Get
        Set(ByVal value As Double)
            m_Sasria = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property TVDiens() As Decimal
        Get
            Return m_TVDiens
        End Get
        Set(ByVal value As Decimal)
            m_TVDiens = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property Polisfooi() As Decimal
        Get
            Return m_Polisfooi
        End Get
        Set(ByVal value As Decimal)
            m_Polisfooi = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property Begrafnis() As Double
        Get
            Return m_Begrafnis
        End Get
        Set(ByVal value As Double)
            m_Begrafnis = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property Plip() As Double
        Get
            Return m_Plip
        End Get
        Set(ByVal value As Double)
            m_Plip = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property CourtesyV() As Decimal
        Get
            Return m_CourtesyV
        End Get
        Set(ByVal value As Decimal)
            m_CourtesyV = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property EPC() As Decimal
        Get
            Return m_EPC
        End Get
        Set(ByVal value As Decimal)
            m_EPC = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property CareAssist() As Decimal
        Get
            Return m_CareAssist
        End Get
        Set(ByVal value As Decimal)
            m_CareAssist = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property Selfoon() As Decimal
        Get
            Return m_Selfoon
        End Get
        Set(ByVal value As Decimal)
            m_Selfoon = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property PakketItem1() As Decimal
        Get
            Return m_PakketItem1
        End Get
        Set(ByVal value As Decimal)
            m_PakketItem1 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property PakketItem2() As Decimal
        Get
            Return m_PakketItem1
        End Get
        Set(ByVal value As Decimal)
            m_PakketItem1 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property pkAddisionelePremie() As Integer
        Get
            Return m_pkAddisionelePremie
        End Get
        Set(ByVal value As Integer)
            m_pkAddisionelePremie = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property DisplayValue() As String
        Get
            Return m_DisplayValue
        End Get
        Set(ByVal value As String)
            m_DisplayValue = value
        End Set
    End Property
End Class
