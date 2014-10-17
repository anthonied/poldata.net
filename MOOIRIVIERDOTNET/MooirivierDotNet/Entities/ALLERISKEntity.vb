Imports System.ComponentModel

<Serializable()> _
Public Class ALLERISKEntity

    Private m_afsluitdatum As Date
    Private m_itemnr As Integer
    Private m_Tipe2 As Integer
    Private m_arnplaat As String
    Private m_POLISNO As String
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    Private m_DEKKING As Double
    Private m_beskrywing As String
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    Private m_waarde As Double
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    Private m_premie As Double
    Private m_beskryf As String
    Private m_cancelled As Integer
    Private m_pkAllerisk As Integer
    Private m_NoMatch As Boolean
    Private m_selkontrakmet As String
    Private m_selnommer As String
    Private m_seldatumaangekoop As String
    Private m_verwyderdedatum As Date

    <DataObjectField(False, False, False)> _
Public Property pkAllerisk() As Integer
        Get
            Return m_pkAllerisk
        End Get
        Set(ByVal value As Integer)
            m_pkAllerisk = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property verwyderdedatum() As Date
        Get
            Return m_verwyderdedatum
        End Get
        Set(ByVal value As Date)
            m_verwyderdedatum = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property selnommer() As String
        Get
            Return m_selnommer
        End Get
        Set(ByVal value As String)
            m_selnommer = value
        End Set
    End Property


    <DataObjectField(False, False, False)> _
Public Property seldatumaangekoop() As String
        Get
            Return m_seldatumaangekoop
        End Get
        Set(ByVal value As String)
            m_seldatumaangekoop = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property selkontrakmet() As String
        Get
            Return m_selkontrakmet
        End Get
        Set(ByVal value As String)
            m_selkontrakmet = value
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
Public Property cancelled() As Integer
        Get
            Return m_cancelled
        End Get
        Set(ByVal value As Integer)
            m_cancelled = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property afsluitdatum() As Date
        Get
            Return m_afsluitdatum
        End Get
        Set(ByVal value As Date)
            m_afsluitdatum = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property itemnr() As String
        Get
            Return m_itemnr
        End Get
        Set(ByVal value As String)
            m_itemnr = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Tipe2() As Integer
        Get
            Return m_Tipe2
        End Get
        Set(ByVal value As Integer)
            m_Tipe2 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property arnplaat() As String
        Get
            Return m_arnplaat
        End Get
        Set(ByVal value As String)
            m_arnplaat = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property POLISNO() As String
        Get
            Return m_polisno
        End Get
        Set(ByVal value As String)
            m_polisno = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property DEKKING() As Double
        Get
            Return m_DEKKING
        End Get
        Set(ByVal value As Double)
            m_DEKKING = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property Premie() As Double
        Get
            Return m_premie
        End Get
        Set(ByVal value As Double)
            m_premie = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property Waarde() As Double
        Get
            Return m_waarde
        End Get
        Set(ByVal value As Double)
            m_waarde = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Beskrywing() As String
        Get
            Return m_beskrywing
        End Get
        Set(ByVal value As String)
            m_beskrywing = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property beskryf() As String
        Get
            Return m_beskryf
        End Get
        Set(ByVal value As String)
            m_beskryf = value
        End Set
    End Property
End Class
