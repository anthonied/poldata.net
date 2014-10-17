Imports System.ComponentModel
<Serializable()> _
Public Class EntityVoertuie
    Private m_maak As String
    Private m_besk As String
    Private m_ander As Integer
    Private m_plaat As String
    Private m_kode As String
    Private m_eeu As String
    Private m_jaar As String
    Private m_cancelled As Integer
    Private m_pkVoertuie As Integer
    Private m_gebruik As String
    Private m_tipe_dek As String
    Private m_NoMatch As Boolean
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    Private m_premie As Double
    Private m_tipe As String
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    Private m_premie_voor As Double 'Andriette 09/04/2013

    <DataObjectField(False, False, False)> _
   Public Property tipe() As String
        Get
            Return m_tipe
        End Get
        Set(ByVal value As String)
            m_tipe = value
        End Set
    End Property

    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property premie() As Double
        Get
            Return m_premie
        End Get
        Set(ByVal value As Double)
            m_premie = value
        End Set
    End Property
    
    <DataObjectField(False, False, False)> _
  Public Property pkVoertuie() As Integer
        Get
            Return m_pkVoertuie
        End Get
        Set(ByVal value As Integer)
            m_pkVoertuie = value
        End Set

    End Property
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
   Public Property kode() As String
        Get
            Return m_kode
        End Get
        Set(ByVal value As String)
            m_kode = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property eeu() As String
        Get
            Return m_eeu
        End Get
        Set(ByVal value As String)
            m_eeu = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property jaar() As String
        Get
            Return m_jaar
        End Get
        Set(ByVal value As String)
            m_jaar = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property cancelled() As Integer
        Get
            Return m_cancelled
        End Get
        Set(ByVal value As Integer)
            m_cancelled = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property ander() As Integer
        Get
            Return m_ander
        End Get
        Set(ByVal value As Integer)
            m_ander = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property besk() As String
        Get
            Return m_besk
        End Get
        Set(ByVal value As String)
            m_besk = value
        End Set
    End Property
    Public Property maak() As String
        Get
            Return m_maak
        End Get
        Set(ByVal value As String)
            m_maak = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property plaat() As String
        Get
            Return m_plaat
        End Get
        Set(ByVal value As String)
            m_plaat = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property gebruik() As String
        Get
            Return m_gebruik
        End Get
        Set(ByVal value As String)
            m_gebruik = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property tipe_dek() As String
        Get
            Return m_tipe_dek
        End Get
        Set(ByVal value As String)
            m_tipe_dek = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    'Andriette 09/04/2013
    <DataObjectField(False, False, False)> _
    Public Property premie_voor() As Double
        Get
            Return m_premie_voor
        End Get
        Set(ByVal value As Double)
            m_premie_voor = value
        End Set
    End Property
End Class
