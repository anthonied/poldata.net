Imports System.ComponentModel
<Serializable()> _
Public Class ConstantsEntity
    Private m_ReportserverURL As String
    Private m_Sasria_h As Decimal
    Private m_TV_Premie As Decimal
    Private m_Polisfooi As Decimal
    Private m_Earlybird As Decimal
    Private m_Toebehore As Decimal
    Private m_Korting As Decimal
    Private m_MotorSasria As Decimal
    Private m_EPC As Decimal
    Private m_Path As String
    Private m_DebitOrderPerc As Decimal
    'Linkie 11/07/2014 - vat byvoeg
    Private m_VAT As Decimal
    'Andriette 14/08/2014 PlipCoverValue byvoeg
    Private m_PlipCoverValue As Double

    <DataObjectField(False, False, False)> _
    Public Property VAT() As Decimal
        Get
            Return m_VAT
        End Get
        Set(ByVal value As Decimal)
            m_VAT = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property ReportserverURL() As String
        Get
            Return m_ReportserverURL
        End Get
        Set(ByVal value As String)
            m_ReportserverURL = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Path() As String
        Get
            Return m_Path
        End Get
        Set(ByVal value As String)
            m_Path = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property TV_Premie() As Decimal
        Get
            Return m_TV_Premie
        End Get
        Set(ByVal value As Decimal)
            m_TV_Premie = value
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

    <DataObjectField(False, False, False)> _
Public Property Earlybird() As Decimal
        Get
            Return m_Earlybird
        End Get
        Set(ByVal value As Decimal)
            m_Earlybird = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Toebehore() As Decimal
        Get
            Return m_Toebehore
        End Get
        Set(ByVal value As Decimal)
            m_Toebehore = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Korting() As Decimal
        Get
            Return m_Korting
        End Get
        Set(ByVal value As Decimal)
            m_Korting = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property MotorSasria() As Decimal
        Get
            Return m_MotorSasria
        End Get
        Set(ByVal value As Decimal)
            m_MotorSasria = value
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
Public Property Sasria_h() As Decimal
        Get
            Return m_Sasria_h
        End Get
        Set(ByVal value As Decimal)
            m_Sasria_h = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property DebitOrderPerc() As Decimal
        Get
            Return m_DebitOrderPerc
        End Get
        Set(ByVal value As Decimal)
            m_DebitOrderPerc = value
        End Set
    End Property

    'Andriette 14/08/2014
    <DataObjectField(False, False, False)> _
    Public Property PlipCoverValue() As Decimal
        Get
            Return m_PlipCoverValue
        End Get
        Set(ByVal value As Decimal)
            m_PlipCoverValue = value
        End Set
    End Property
End Class

