Imports System.ComponentModel

<Serializable()> _
Public Class ListVoertuieByPolisnoEntity
    Private m_pkvoertuie As Integer
    Private m_ander As String
    Private m_Fabrikaat As String
    Private m_modelbeskrywing As String
    Private m_jaar As String
    Private m_registrasieno As String
    Private m_dekking As String
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    Private m_totalewaarde As Double
    Private m_totalepremie As Double
    Private m_sekuriteit As String
    Private M_KODE As String
    <DataObjectField(False, False, False)> _
Public Property KODE() As String
        Get
            Return M_KODE
        End Get
        Set(ByVal value As String)
            M_KODE = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
  Public Property pkVoertuie() As Integer
        Get
            Return m_pkvoertuie
        End Get
        Set(ByVal value As Integer)
            m_pkvoertuie = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Ander() As String
        Get
            Return m_ander
        End Get
        Set(ByVal value As String)
            m_ander = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Fabrikaat() As String
        Get
            Return m_Fabrikaat
        End Get
        Set(ByVal value As String)
            m_Fabrikaat = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Modelbeskrywing() As String
        Get
            Return m_modelbeskrywing
        End Get
        Set(ByVal value As String)
            m_modelbeskrywing = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Jaar() As String
        Get
            Return m_jaar
        End Get
        Set(ByVal value As String)
            m_jaar = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property RegistrasieNo() As String
        Get
            Return m_registrasieno
        End Get
        Set(ByVal value As String)
            m_registrasieno = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Dekking() As String
        Get
            Return m_dekking
        End Get
        Set(ByVal value As String)
            m_dekking = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property Totalewaarde() As Double
        Get
            Return m_totalewaarde
        End Get
        Set(ByVal value As Double)
            m_totalewaarde = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property Totalepremie() As Double
        Get
            Return m_totalepremie
        End Get
        Set(ByVal value As Double)
            m_totalepremie = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Sekuriteit() As String
        Get
            Return m_sekuriteit
        End Get
        Set(ByVal value As String)
            m_sekuriteit = value
        End Set
    End Property

End Class
