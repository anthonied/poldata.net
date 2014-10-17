﻿Imports System.ComponentModel

<Serializable()> _
Public Class ArgiefEntity
    Private m_Gebruiker As String
    Private m_Datum As Date
    'Kobus 16/07/2014 comment out
    'Private m_Kategorie As String
    Private m_Path As String
    Private m_epos_Onderwerp As String
    Private m_epos_Inhoud As String
    Private m_epos_Adres As String
    Private m_epos_Aanhangsels As String
    Private m_pkArgief As Integer
    Private m_Incoming As Boolean
    'Kobus 16/07/2014 voegby
    Private m_fkArchiveCategories As Integer

    <DataObjectField(False, False, False)> _
    Public Property pkArgief() As String
        Get
            Return m_pkArgief
        End Get
        Set(ByVal value As String)
            m_pkArgief = value
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
    Public Property Datum() As Date
        Get
            Return m_Datum
        End Get
        Set(ByVal value As Date)
            m_Datum = value
        End Set
    End Property
    'Kobus 16/07/2014 comment out
    '<DataObjectField(False, False, False)> _
    'Public Property Kategorie() As String
    '    Get
    '        Return m_Kategorie
    '    End Get
    '    Set(ByVal value As String)
    '        m_Kategorie = value
    '    End Set
    'End Property

    <DataObjectField(False, False, False)> _
    Public Property Path() As String
        Get
            Return m_Path
        End Get
        Set(ByVal value As String)
            m_Path = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property epos_Onderwerp() As String
        Get
            Return m_epos_Onderwerp
        End Get
        Set(ByVal value As String)
            m_epos_Onderwerp = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property epos_Inhoud() As String
        Get
            Return m_epos_Inhoud
        End Get
        Set(ByVal value As String)
            m_epos_Inhoud = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
        Public Property epos_Adres() As String
        Get
            Return m_epos_Adres
        End Get
        Set(ByVal value As String)
            m_epos_Adres = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
        Public Property epos_Aanhangsels() As String
        Get
            Return m_epos_Aanhangsels
        End Get
        Set(ByVal value As String)
            m_epos_Aanhangsels = value
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
    <DataObjectField(False, False, False)> _
    Public Property fkArchiveCategories() As Integer
        Get
            Return m_fkArchiveCategories
        End Get
        Set(ByVal value As Integer)
            m_fkArchiveCategories = value
        End Set
    End Property
End Class
