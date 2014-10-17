Imports System.ComponentModel

<Serializable()> _
Public Class BetaalEntity
    Private m_polisno As String
    Private m_datum As DateTime
   
    <DataObjectField(False, False, False)> _
    Public Property POLISNO() As String
        Get
            Return m_polisno
        End Get
        Set(ByVal value As String)
            m_polisno = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
   Public Property Datum() As String
        Get
            Return m_datum
        End Get
        Set(ByVal value As String)
            m_datum = value
        End Set
    End Property
  
End Class
