
Imports System.ComponentModel
<Serializable()> _
Public Class VoertuieEkstrasEnity
    Private m_fkVoertuie As Integer
    Private m_pkVoertuieEkstras As Integer
    ' Kobus Visser 01/03/2013 change from Integer to String
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    'Linkie 05/07/2013 - verander na decimal
    Private m_Premie As Decimal
    Private m_Waarde As Decimal
    Private m_Beskrywing As String
    Private m_Fabrikaat As String
    Private m_Model As String
    Private m_SerieNommer As String
    Private m_Deleted As Integer
    Private m_DatumIn As String
    Private m_DatumWysig As String
    Private m_fkVoertuieEkstraTipe As Integer
    Private m_NoMatch As Boolean



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
    Public Property fkVoertuie() As Integer
        Get
            Return m_fkVoertuie
        End Get
        Set(ByVal value As Integer)
            m_fkVoertuie = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property fkVoertuieEkstraTipe() As Integer
        Get
            Return m_fkVoertuieEkstraTipe
        End Get
        Set(ByVal value As Integer)
            m_fkVoertuieEkstraTipe = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property pkVoertuieEkstras() As Integer
        Get
            Return m_pkVoertuieEkstras
        End Get
        Set(ByVal value As Integer)
            m_pkVoertuieEkstras = value
        End Set
    End Property
    ' Kobus Visser Change from Integer to Sring to show end 0 in cents
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    'Linkie 05/07/2013 - verander na decimal
    <DataObjectField(False, False, False)> _
    Public Property Premie() As Decimal
        Get
            Return m_Premie
        End Get
        Set(ByVal value As Decimal)
            'Linkie 05/07/2013 - sit formatting in
            m_Premie = String.Format("{0:N2}", value)
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Waarde() As Decimal
        Get
            Return m_Waarde
        End Get
        Set(ByVal value As Decimal)
            'Kobus 9/7/13 verander format
            m_Waarde = FormatNumber((value), 0)
        End Set
    End Property

    <DataObjectField(False, False, False)> _
 Public Property Beskrywing() As String
        Get
            Return m_Beskrywing
        End Get
        Set(ByVal value As String)
            m_Beskrywing = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
 Public Property DatumIn() As String
        Get
            Return m_DatumIn
        End Get
        Set(ByVal value As String)
            m_DatumIn = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property DatumWysig() As String
        Get
            Return m_DatumWysig
        End Get
        Set(ByVal value As String)
            m_DatumWysig = value
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
Public Property Model() As String
        Get
            Return m_Model
        End Get
        Set(ByVal value As String)
            m_Model = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property SerieNommer() As String
        Get
            Return m_SerieNommer
        End Get
        Set(ByVal value As String)
            m_SerieNommer = value
        End Set
    End Property


    <DataObjectField(False, False, False)> _
Public Property Deleted() As Integer
        Get
            Return m_Deleted
        End Get
        Set(ByVal value As Integer)
            m_Deleted = value
        End Set
    End Property

End Class
