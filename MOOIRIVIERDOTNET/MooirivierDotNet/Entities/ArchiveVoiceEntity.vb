Imports System.ComponentModel
'******************************************************************************
' Author       : Kobus
' Created      : 07/07/2014
' Purpose      : Use data from table Poldata5.ArchiveVoice
'******************************************************************************
<Serializable()> _
Public Class ArchiveVoiceEntity
    Private m_pkArchiveVoice As Integer
    Private m_CallDate As Date
    Private m_Gebruiker As String
    Private m_Polisno As String
    Private m_ContactNumber As String
    Private m_CallerNumber As String
    Private m_fkArchiveCategories As Integer
    Private m_Filename As String
    Private m_Comments As String
    Private m_Incoming As Boolean

    <DataObjectField(False, False, False)> _
    Public Property pkArchiveVoice As Integer
        Get
            Return m_pkArchiveVoice
        End Get
        Set(ByVal value As Integer)
            m_pkArchiveVoice = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Gebruiker() As String
        Get
            Return m_Gebruiker
        End Get
        Set(ByVal value As String)
            m_Gebruiker = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property CallDate As Date
        Get
            Return m_CallDate
        End Get
        Set(ByVal value As Date)
            m_CallDate = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property fkArchiveCategories() As Integer
        Get
            Return m_fkArchiveCategories
        End Get
        Set(ByVal value As Integer)
            m_fkArchiveCategories = value
        End Set
    End Property
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
        Public Property FileName() As String
        Get
            Return m_Filename
        End Get
        Set(ByVal value As String)
            m_Filename = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Comments() As String
        Get
            Return m_Comments
        End Get
        Set(ByVal value As String)
            m_Comments = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property ContactNumber() As String
        Get
            Return m_ContactNumber
        End Get
        Set(ByVal value As String)
            m_ContactNumber = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property CallerNumber() As String
        Get
            Return m_CallerNumber
        End Get
        Set(ByVal value As String)
            m_CallerNumber = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Incoming() As Boolean
        Get
            Return m_Incoming
        End Get
        Set(ByVal value As Boolean)
            m_Incoming = value
        End Set
    End Property
End Class
