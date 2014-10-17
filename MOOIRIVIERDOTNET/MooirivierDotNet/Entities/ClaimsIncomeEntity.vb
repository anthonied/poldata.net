
Imports System.ComponentModel

<Serializable()> _
Public Class ClaimsIncomeEntity
    Private m_eisno As String
    Private m_polisno As String
    Private m_besonderhede As String
    Private m_bedrag As Decimal
    Private m_status As String
    Private m_kwitansienr As String
    Private m_Btwuitbedrag As Decimal
    Private m_Btwbedrag As Decimal
    Private m_Btwjn As String
    Private m_Tjekofkontant As String
    Private m_Tjekno As String
    Private m_Trans_dat As Date
    Private m_VerhalingEisno As String
    Private m_Tipe As String
    Private m_DatumInkomste As Date
    Private m_pkIncome As Integer
    Private m_Cancel As Integer
    Private m_CancelIcon As String

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
    Public Property besonderhede() As String
        Get
            Return m_besonderhede
        End Get
        Set(ByVal value As String)
            m_besonderhede = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property bedrag() As Decimal
        Get
            Return m_bedrag
        End Get
        Set(ByVal value As Decimal)
            m_bedrag = String.Format("{0:N2}", value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property status() As String
        Get
            Return m_status
        End Get
        Set(ByVal value As String)
            m_status = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property kwitansienr() As String
        Get
            Return m_kwitansienr
        End Get
        Set(ByVal value As String)
            m_kwitansienr = value
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
    Public Property Tjekofkontant() As String
        Get
            Return m_Tjekofkontant
        End Get
        Set(ByVal value As String)
            m_Tjekofkontant = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Tjekno() As String
        Get
            Return m_Tjekno
        End Get
        Set(ByVal value As String)
            m_Tjekno = value
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
    Public Property VerhalingEisno() As String
        Get
            Return m_VerhalingEisno
        End Get
        Set(ByVal value As String)
            m_VerhalingEisno = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Tipe() As String
        Get
            Return m_Tipe
        End Get
        Set(ByVal value As String)
            m_Tipe = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property DatumInkomste() As Date
        Get
            Return m_DatumInkomste
        End Get
        Set(ByVal value As Date)
            m_DatumInkomste = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property pkIncome() As Integer
        Get
            Return m_pkIncome
        End Get
        Set(ByVal value As Integer)
            m_pkIncome = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Cancel() As Integer
        Get
            Return m_Cancel
        End Get
        Set(ByVal value As Integer)
            m_Cancel = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property CancelIcon() As String
        Get
            Return m_CancelIcon
        End Get
        Set(ByVal value As String)
            m_CancelIcon = value
        End Set
    End Property
End Class
