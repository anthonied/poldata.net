Imports System.ComponentModel

<Serializable()> _
Public Class VTDetailsEntity

    Private m_POLISNO As String
    Private m_VT_BEDRAG As Decimal
    Private m_VT_INGEVORDER As Decimal
    Private m_VT_KWITANSIE As String
    Private m_VT_TAKKODE As String
    Private m_VT_REKNR As String
    Private m_VT_REDE As String
    Private m_VT_TIPE_REK As Integer
    Private m_VT_VORD_DATUM As Date
    Private m_VT_KODE As Integer
    Private m_X As Integer
    Private m_VT_DATUM As Date
    Private m_JAAR As Integer
    Private m_MAAND As Integer
    Private m_TRANS_DAT As Date
    Private m_Kwit_boek As String
    Private m_DatumAangevra As Date
    Private m_Index As String
    Private m_Nomatch As Boolean

    <DataObjectField(False, False, False)> _
Public Property Index() As String
        Get
            Return m_Index
        End Get
        Set(ByVal value As String)
            m_Index = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Nomatch() As Boolean
        Get
            Return m_Nomatch
        End Get
        Set(ByVal value As Boolean)
            m_Nomatch = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property POLISNO() As String
        Get
            Return m_POLISNO
        End Get
        Set(ByVal value As String)
            m_POLISNO = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property VT_BEDRAG() As Decimal
        Get
            Return m_VT_BEDRAG
        End Get
        Set(ByVal value As Decimal)
            m_VT_BEDRAG = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property VT_INGEVORDER() As Decimal
        Get
            Return m_VT_INGEVORDER
        End Get
        Set(ByVal value As Decimal)
            m_VT_INGEVORDER = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property VT_KWITANSIE() As String
        Get
            Return m_VT_KWITANSIE
        End Get
        Set(ByVal value As String)
            m_VT_KWITANSIE = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property VT_TAKKODE() As String
        Get
            Return m_VT_TAKKODE
        End Get
        Set(ByVal value As String)
            m_VT_TAKKODE = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property VT_REKNR() As String
        Get
            Return m_VT_REKNR
        End Get
        Set(ByVal value As String)
            m_VT_REKNR = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property VT_REDE() As String
        Get
            Return m_VT_REDE
        End Get
        Set(ByVal value As String)
            m_VT_REDE = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property VT_TIPE_REK() As Integer
        Get
            Return m_VT_TIPE_REK
        End Get
        Set(ByVal value As Integer)
            m_VT_TIPE_REK = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property VT_VORD_DATUM() As Date
        Get
            Return m_VT_VORD_DATUM
        End Get
        Set(ByVal value As Date)
            m_VT_VORD_DATUM = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property VT_KODE() As Integer
        Get
            Return m_VT_KODE
        End Get
        Set(ByVal value As Integer)
            m_VT_KODE = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property X() As Integer
        Get
            Return m_X
        End Get
        Set(ByVal value As Integer)
            m_X = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property VT_DATUM() As Date
        Get
            Return m_VT_DATUM
        End Get
        Set(ByVal value As Date)
            m_VT_DATUM = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property JAAR() As Integer
        Get
            Return m_JAAR
        End Get
        Set(ByVal value As Integer)
            m_JAAR = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property MAAND() As Integer
        Get
            Return m_MAAND
        End Get
        Set(ByVal value As Integer)
            m_MAAND = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property TRANS_DAT() As Date
        Get
            Return m_TRANS_DAT
        End Get
        Set(ByVal value As Date)
            m_TRANS_DAT = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Kwit_boek() As String
        Get
            Return m_Kwit_boek
        End Get
        Set(ByVal value As String)
            m_Kwit_boek = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property DatumAangevra() As Date
        Get
            Return m_DatumAangevra
        End Get
        Set(ByVal value As Date)
            m_DatumAangevra = value
        End Set
    End Property
End Class
