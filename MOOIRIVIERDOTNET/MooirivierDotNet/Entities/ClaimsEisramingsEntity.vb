
Imports System.ComponentModel

<Serializable()> _
Public Class ClaimsEisramingsEntity
    Private m_Polisno As String
    Private m_Eisno As String
    Private m_Eisramingsbedrag As Decimal
    Private m_Eisramingsdatum As String

    <DataObjectField(False, False, False)> _
    Public Property Polisno() As String
        Get
            Return m_Polisno
        End Get
        Set(ByVal value As String)
            m_Polisno = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Eisno() As String
        Get
            Return m_Eisno
        End Get
        Set(ByVal value As String)
            m_Eisno = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Eisramingsbedrag() As Decimal
        Get
            Return m_Eisramingsbedrag
        End Get
        Set(ByVal value As Decimal)
            m_Eisramingsbedrag = String.Format("{0:N2}", value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Eisramingsdatum() As String
        Get
            Return m_Eisramingsdatum
        End Get
        Set(ByVal value As String)
            m_Eisramingsdatum = value
        End Set
    End Property
End Class
