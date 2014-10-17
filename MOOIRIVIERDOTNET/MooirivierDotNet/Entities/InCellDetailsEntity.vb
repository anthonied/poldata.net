Imports System.ComponentModel
<Serializable()> _
Public Class InCellDetailsEntity
    Private m_phone_model As String
    Private m_phone_make As String
    Private m_premie As Decimal
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
Public Property phone_make() As String
        Get
            Return m_phone_make
        End Get
        Set(ByVal value As String)
            m_phone_make = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property phone_model() As String
        Get
            Return m_phone_model
        End Get
        Set(ByVal value As String)
            m_phone_model = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Premie() As Decimal
        Get
            Return m_premie
        End Get
        Set(ByVal value As Decimal)
            m_premie = value
        End Set
    End Property
End Class


