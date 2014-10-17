Imports System.ComponentModel

<Serializable()> _
Public Class ReminderEntity

    Private m_pkReminder As Integer
    Private m_gebruiker As String
    Private m_datum As String
    Private m_boodskap As String
    Private m_onderwerp As String
    Private m_fkMemo As Integer

    <DataObjectField(False, False, False)> _
  Public Property pkReminder() As Integer
        Get
            Return m_pkReminder
        End Get
        Set(ByVal value As Integer)
            m_pkReminder = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property Gebruiker() As String
        Get
            Return m_gebruiker
        End Get
        Set(ByVal value As String)
            m_gebruiker = value
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
    <DataObjectField(False, False, False)> _
Public Property Boodskap() As String
        Get
            Return m_boodskap
        End Get
        Set(ByVal value As String)
            m_boodskap = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Onderwerp() As String
        Get
            Return m_onderwerp
        End Get
        Set(ByVal value As String)
            m_onderwerp = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property fkMemo() As Integer
        Get
            Return m_fkMemo
        End Get
        Set(ByVal value As Integer)
            m_fkMemo = value
        End Set
    End Property

End Class
