Imports System.ComponentModel

<Serializable()> _
Public Class MaandElectronies

    Dim m_polisno As String
    Dim m_vord_dat As Date
    Dim m_premie As Decimal
    Dim m_vord_premie As Decimal
    Dim m_afsluit_dat As Date
    Dim m_jaar As Integer
    Dim m_maand As Integer
    Dim m_trans_dat As Date
    Dim m_betaalwyse As String
    Dim m_ingevorder As Decimal
    Dim m_me_trans_dat As Date
    Dim m_kwit_boek As String
    Dim m_Area As String
    Dim m_NoMatch As Boolean
    Dim m_Index As String

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
Public Property NoMatch() As Boolean
        Get
            Return m_NoMatch
        End Get
        Set(ByVal value As Boolean)
            m_NoMatch = value
        End Set
    End Property

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
Public Property me_trans_dat() As Date
        Get
            Return m_me_trans_dat
        End Get
        Set(ByVal value As Date)
            m_me_trans_dat = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property kwit_boek() As String
        Get
            Return m_kwit_boek
        End Get
        Set(ByVal value As String)
            m_kwit_boek = value
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
End Class
