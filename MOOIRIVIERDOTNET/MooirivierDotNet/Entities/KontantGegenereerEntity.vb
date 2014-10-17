Imports System.ComponentModel

<Serializable()> _
Public Class KontantGegenereerEntity

    Private m_polisno As String
    Private m_vord_dat As Date
    Private m_premie As Decimal
    Private m_vord_premie As Decimal
    Private m_afsluit_dat As Date
    Private m_jaar As Integer
    Private m_maand As Integer
    Private m_trans_dat As Date
    Private m_betaalwyse As String
    Private m_ingevorder As Decimal
    Private m_gg_trans_dat As Date
    Private m_tip_trans As String
    Private m_gekans As Integer
    Private m_kans_dat As Date
    Private m_eb_vb_tb As String
    Private m_tipe_trans As String
    Private m_Kwit_boek As String
    Private m_Area As String
    Private m_nomatch As Boolean

    <DataObjectField(False, False, False)> _
Public Property polisno() As String
        Get
            Return m_polisno
        End Get
        Set(ByVal value As String)
            m_polisno = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property vord_dat() As Date
        Get
            Return m_vord_dat
        End Get
        Set(ByVal value As Date)
            m_vord_dat = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property premie() As Decimal
        Get
            Return m_premie
        End Get
        Set(ByVal value As Decimal)
            m_premie = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property vord_premie() As Decimal
        Get
            Return m_vord_premie
        End Get
        Set(ByVal value As Decimal)
            m_vord_premie = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property afsluit_dat() As Date
        Get
            Return m_afsluit_dat
        End Get
        Set(ByVal value As Date)
            m_afsluit_dat = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property jaar() As Integer
        Get
            Return m_jaar
        End Get
        Set(ByVal value As Integer)
            m_jaar = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property maand() As Integer
        Get
            Return m_maand
        End Get
        Set(ByVal value As Integer)
            m_maand = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property trans_dat() As Date
        Get
            Return m_trans_dat
        End Get
        Set(ByVal value As Date)
            m_trans_dat = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property betaalwyse() As String
        Get
            Return m_betaalwyse
        End Get
        Set(ByVal value As String)
            m_betaalwyse = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property ingevorder() As Decimal
        Get
            Return m_ingevorder
        End Get
        Set(ByVal value As Decimal)
            m_ingevorder = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property gg_trans_dat() As Date
        Get
            Return m_gg_trans_dat
        End Get
        Set(ByVal value As Date)
            m_gg_trans_dat = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property tip_trans() As Date
        Get
            Return m_tip_trans
        End Get
        Set(ByVal value As Date)
            m_tip_trans = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property gekans() As Integer
        Get
            Return m_gekans
        End Get
        Set(ByVal value As Integer)
            m_gekans = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property kans_dat() As Date
        Get
            Return m_kans_dat
        End Get
        Set(ByVal value As Date)
            m_kans_dat = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property eb_vb_tb() As String
        Get
            Return m_eb_vb_tb
        End Get
        Set(ByVal value As String)
            m_eb_vb_tb = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property tipe_trans() As String
        Get
            Return m_tipe_trans
        End Get
        Set(ByVal value As String)
            m_tipe_trans = value
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
Public Property Area() As String
        Get
            Return m_Area
        End Get
        Set(ByVal value As String)
            m_Area = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property nomatch() As Boolean
        Get
            Return m_nomatch
        End Get
        Set(ByVal value As Boolean)
            m_nomatch = value
        End Set
    End Property
End Class
