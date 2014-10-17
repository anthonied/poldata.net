Imports System.ComponentModel
<Serializable()> _
Public Class GeyserEntity
    Private m_GeyserTipe As String
    Private m_Fabrikaat As String
    Private m_Model As String
    Private m_Datum As Date
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    Private m_Waarde As Double
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    Private m_Premie As Double   'Kobus Visser 14/03/2013 change from Integer
    Private m_Liter As String
    Private m_DatumIn As Date
    Private m_DatumWysig As Date
    Private m_fkHuis As Integer
    Private m_Cancelled As Integer
    Private m_pkGeysers As Integer
  
    <DataObjectField(False, False, False)> _
   Public Property pkGeysers() As Integer
        Get
            Return m_pkGeysers
        End Get
        Set(ByVal value As Integer)
            m_pkGeysers = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property GeyserTipe() As String
        Get
            Return m_GeyserTipe
        End Get
        Set(ByVal value As String)
            m_GeyserTipe = value
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
    Public Property Datum() As DateTime
        Get
            Return m_Datum
        End Get
        Set(ByVal value As DateTime)
            m_Datum = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property Waarde() As Double
        Get
            Return m_Waarde
        End Get
        Set(ByVal value As Double)
            m_Waarde = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property Premie() As Double 'Kobus Visser 14/03/2013 change Integer
        Get
            Return m_Premie
        End Get
        Set(ByVal value As Double)
            m_Premie = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property Liter() As String
        Get
            Return m_Liter
        End Get
        Set(ByVal value As String)
            m_Liter = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property DatumIn() As DateTime
        Get
            Return m_DatumIn
        End Get
        Set(ByVal value As DateTime)
            m_DatumIn = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property DatumWysig() As DateTime
        Get
            Return m_DatumWysig
        End Get
        Set(ByVal value As DateTime)
            m_DatumWysig = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property fkHuis() As Integer
        Get
            Return m_fkHuis
        End Get
        Set(ByVal value As Integer)
            m_fkHuis = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Cancelled() As Integer
        Get
            Return m_Cancelled
        End Get
        Set(ByVal value As Integer)
            m_Cancelled = value
        End Set
    End Property
   
End Class
