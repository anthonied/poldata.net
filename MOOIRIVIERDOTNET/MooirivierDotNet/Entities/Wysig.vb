﻿Imports System.ComponentModel
<Serializable()> _
Public Class Wysig

    Private m_polisno As Integer
    Private m_kode As Integer
    Private m_datum As Date
    Private m_versekerde As String
    Private m_voorl As String
    Private m_gebruiker As String
    Private m_beskywing As String

    <DataObjectField(False, False, False)> _
   Public Property polisno() As Integer
        Get
            Return m_polisno
        End Get
        Set(ByVal value As Integer)
            m_polisno = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property kode() As Integer
        Get
            Return m_kode
        End Get
        Set(ByVal value As Integer)
            m_kode = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property datum() As Date
        Get
            Return m_datum
        End Get
        Set(ByVal value As Date)
            m_datum = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property versekerde() As String
        Get
            Return m_versekerde
        End Get
        Set(ByVal value As String)
            m_versekerde = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property voorl() As String
        Get
            Return m_voorl
        End Get
        Set(ByVal value As String)
            m_voorl = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property gebruiker() As String
        Get
            Return m_gebruiker
        End Get
        Set(ByVal value As String)
            m_gebruiker = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property beskrywing() As String
        Get
            Return m_beskywing
        End Get
        Set(ByVal value As String)
            m_beskywing = value
        End Set
    End Property
End Class