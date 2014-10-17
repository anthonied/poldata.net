
Imports System.ComponentModel
<Serializable()> _
Public Class BriefVT_Entity
    Private m_Datumaangebied As String
    Private m_VTDatum As Date
    Private m_Beskrywing As String
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    Private m_Bedrag As Double
    Private m_Krities As String
    <DataObjectField(False, False, False)> _
 Public Property Datumaangebied() As String
        Get
            Return m_Datumaangebied
        End Get
        Set(ByVal value As String)
            m_Datumaangebied = (value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property VTDatum() As Date
        Get
            Return m_VTDatum
        End Get
        Set(ByVal value As Date)
            m_VTDatum = (value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Beskrywing() As String
        Get
            Return m_Beskrywing
        End Get
        Set(ByVal value As String)
            m_Beskrywing = (value)
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property Bedrag() As Double
        Get
            Return m_Bedrag
        End Get
        Set(ByVal value As Double)
            m_Bedrag = (value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
 Public Property Krities() As String
        Get
            Return m_Krities
        End Get
        Set(ByVal value As String)
            m_Krities = (value)
        End Set
    End Property

  



   

 


    
End Class
