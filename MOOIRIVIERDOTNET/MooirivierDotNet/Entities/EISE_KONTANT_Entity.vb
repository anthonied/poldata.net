
Imports System.ComponentModel
<Serializable()> _
Public Class EISE_KONTANT_Entity

    Dim m_POLISNO As String
    Dim m_VORD_DAT As Date
    Dim m_PREMIE As Decimal
    Dim m_VORD_PREMIE As Decimal
    Dim m_AFSLUIT_DAT As Date
    Dim m_JAAR As Integer
    Dim m_MAAND As Integer
    Dim m_TRANS_DAT As Date
    Dim m_BETAALWYSE As String
    Dim m_ingevorder As Decimal
    Dim m_ei_trans_dat As Date
    Dim m_eisno As String
    Dim m_tipe As String
    Dim m_betaal As String
    Dim m_Area As String
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
Public Property tipe() As String
        Get
            Return m_tipe
        End Get
        Set(ByVal value As String)
            m_tipe = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property eisno() As String
        Get
            Return m_eisno
        End Get
        Set(ByVal value As String)
            m_eisno = value
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
Public Property betaal() As String
        Get
            Return m_betaal
        End Get
        Set(ByVal value As String)
            m_betaal = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property ei_trans_dat() As Date
        Get
            Return m_ei_trans_dat
        End Get
        Set(ByVal value As Date)
            m_ei_trans_dat = value
        End Set
    End Property

    
End Class


