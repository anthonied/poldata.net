

Imports System.ComponentModel

<Serializable()> _
Public Class MontorEntity
    Private m_TIPE As String
    Private m_Fabrikaat As String
    Private m_Model_beskrywing As String
    Private m_Jr As String
    Private m_Inruil_R As String
    Private m_Koop_R As String
    Private m_Nuut_R As String
    Private m_Mark_R As String
    Private m_KODE As String
    Private m_Cyl As String
    Private m_CC As String
    Private m_Begin As String
    Private m_Einde As String
    Private m_NoMatch As Boolean
    Private m_besk As String
    Private m_EEU As String
    <DataObjectField(False, False, False)> _
   Public Property EEU() As String
        Get
            Return m_EEU
        End Get
        Set(ByVal value As String)
            m_EEU = value
        End Set
    End Property
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
    Public Property besk() As String
        Get
            Return m_besk
        End Get
        Set(ByVal value As String)
            m_besk = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property TIPE() As String
        Get
            Return m_TIPE
        End Get
        Set(ByVal value As String)
            m_TIPE = value
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
    Public Property Model_beskrywing() As String
        Get
            Return m_Model_beskrywing
        End Get
        Set(ByVal value As String)
            m_Model_beskrywing = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Jr() As String
        Get
            Return m_Jr
        End Get
        Set(ByVal value As String)
            m_Jr = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Inruil_R() As String
        Get
            Return m_Inruil_R
        End Get
        Set(ByVal value As String)
            m_Inruil_R = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Koop_R() As String
        Get
            Return m_Koop_R
        End Get
        Set(ByVal value As String)
            m_Koop_R = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Nuut_R() As String
        Get
            Return m_Nuut_R
        End Get
        Set(ByVal value As String)
            m_Nuut_R = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Mark_R() As String
        Get
            Return m_Mark_R
        End Get
        Set(ByVal value As String)
            m_Mark_R = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property KODE() As String
        Get
            Return m_KODE
        End Get
        Set(ByVal value As String)
            m_KODE = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property Cyl() As String
        Get
            Return m_Cyl
        End Get
        Set(ByVal value As String)
            m_Cyl = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property CC() As String
        Get
            Return m_CC
        End Get
        Set(ByVal value As String)
            m_CC = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property Begin() As String
        Get
            Return m_Begin
        End Get
        Set(ByVal value As String)
            m_Begin = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property Einde() As String
        Get
            Return m_Einde
        End Get
        Set(ByVal value As String)
            m_Einde = value
        End Set
    End Property
End Class
