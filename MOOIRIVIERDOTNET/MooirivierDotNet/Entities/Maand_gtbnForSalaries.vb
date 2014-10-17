Imports System.ComponentModel

<Serializable()> _
    Public Class Maand_gtbnForSalaries


    Dim m_POLISNO As String
    Dim m_VORD_DAT As Date
    Dim m_PREMIE As Decimal
    Dim m_VORD_PREMIE As Decimal
    Dim m_MATCH As Integer
    Dim m_NIE_MULTI As Decimal
    Dim m_NIE_MD As Decimal
    Dim m_ONINGEWIN As Decimal
    Dim m_AFSLUIT_DAT As Date
    Dim m_JAAR As Integer
    Dim m_MAAND As Integer
    Dim m_TRANS_DAT As Date
    Dim m_BETAALWYSE As String
    Dim m_ingevorder As Decimal
    Dim m_ms_trans_dat As Date
    Dim m_Kwit_boek As String
    Dim m_Area As String
    Dim m_pers_nom As String
    Dim m_NoMatch As Boolean

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
Public Property Kwit_boek() As String
        Get
            Return m_Kwit_boek
        End Get
        Set(ByVal value As String)
            m_Kwit_boek = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property VORD_DAT() As Date
        Get
            Return m_VORD_DAT
        End Get
        Set(ByVal value As Date)
            m_VORD_DAT = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property PREMIE() As Decimal
        Get
            Return m_PREMIE
        End Get
        Set(ByVal value As Decimal)
            m_PREMIE = value
        End Set
    End Property


    <DataObjectField(False, False, False)> _
Public Property VORD_PREMIE() As Decimal
        Get
            Return m_VORD_PREMIE
        End Get
        Set(ByVal value As Decimal)
            m_VORD_PREMIE = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property MATCH() As Integer
        Get
            Return m_MATCH
        End Get
        Set(ByVal value As Integer)
            m_MATCH = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property NIE_MULTI() As Decimal
        Get
            Return m_NIE_MULTI
        End Get
        Set(ByVal value As Decimal)
            m_NIE_MULTI = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property NIE_MD() As Decimal
        Get
            Return m_NIE_MD
        End Get
        Set(ByVal value As Decimal)
            m_NIE_MD = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property ONINGEWIN() As Decimal
        Get
            Return m_ONINGEWIN
        End Get
        Set(ByVal value As Decimal)
            m_ONINGEWIN = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property AFSLUIT_DAT() As Date
        Get
            Return m_AFSLUIT_DAT
        End Get
        Set(ByVal value As Date)
            m_AFSLUIT_DAT = value
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
Public Property BETAALWYSE() As String
        Get
            Return m_BETAALWYSE
        End Get
        Set(ByVal value As String)
            m_BETAALWYSE = value
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
Public Property ms_trans_dat() As Date
        Get
            Return m_ms_trans_dat
        End Get
        Set(ByVal value As Date)
            m_ms_trans_dat = value
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
Public Property pers_nom() As String
        Get
            Return m_pers_nom
        End Get
        Set(ByVal value As String)
            m_pers_nom = value
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

End Class
