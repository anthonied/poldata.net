Imports System.ComponentModel

<Serializable()> _
Public Class GebruikersEntity

    Private m_naam As String
    Private m_nedseedno As String
    Private m_kode As String
    Private m_titel As String
    Private m_branchcodes As String
    Private m_policynumber As String
    Private m_windowsusername As String
    Private m_applicationpath As String
    Private m_area_kode
    Private m_MMLicense As String


    <DataObjectField(False, False, False)> _
    Public Property Naam() As String
        Get
            Return m_naam
        End Get
        Set(ByVal value As String)
            m_naam = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Nedseedno() As String
        Get
            Return m_nedseedno
        End Get
        Set(ByVal value As String)
            m_nedseedno = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Kode() As String
        Get
            Return m_kode
        End Get
        Set(ByVal value As String)
            m_kode = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property titel() As String
        Get
            Return m_titel
        End Get
        Set(ByVal value As String)
            m_titel = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property BranchCodes() As String
        Get
            Return m_branchcodes
        End Get
        Set(ByVal value As String)
            m_branchcodes = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Policynumber() As String
        Get
            Return m_policynumber
        End Get
        Set(ByVal value As String)
            m_policynumber = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property WindowsUsername() As String
        Get
            Return m_windowsusername
        End Get
        Set(ByVal value As String)
            m_windowsusername = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property ApplicationPath() As String
        Get
            Return m_applicationpath
        End Get
        Set(ByVal value As String)
            m_applicationpath = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Area_kode() As String
        Get
            Return m_area_kode
        End Get
        Set(ByVal value As String)
            m_area_kode = value
        End Set
    End Property
    'Andriette 09/10/2013 
    <DataObjectField(False, False, False)> _
    Public Property MMLicence() As String
        Get
            Return m_MMLicense
        End Get
        Set(ByVal value As String)
            m_MMLicense = value
        End Set
    End Property
End Class
