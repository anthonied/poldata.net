Imports System.ComponentModel

<Serializable()> _
Public Class AftrekEntity
    Private m_polisno As String
    Private m_a_van As String
    Private m_a_vl As String
    Private m_tipe As String
    Private m_kode As String
    Private m_rek_no As String
    Private m_rek_no1 As String
    Private m_fk_bankcode As String
    Private m_credit_card_expiry_date As String
    Private m_credit_card_cvv_no As String
    Private m_nomatch As Boolean

    <DataObjectField(False, False, False)> _
  Public Property NoMatch() As Boolean
        Get
            Return m_nomatch
        End Get
        Set(ByVal value As Boolean)
            m_nomatch = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property POLISNO() As String
        Get
            Return m_polisno
        End Get
        Set(ByVal value As String)
            m_polisno = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property A_VAN() As String
        Get
            Return m_a_van
        End Get
        Set(ByVal value As String)
            m_a_van = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property A_VL() As String
        Get
            Return m_a_vl
        End Get
        Set(ByVal value As String)
            m_a_vl = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property A_TIPE() As String
        Get
            Return m_tipe
        End Get
        Set(ByVal value As String)
            m_tipe = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property A_KODE() As String
        Get
            Return m_kode
        End Get
        Set(ByVal value As String)
            m_kode = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property REK_NO() As String
        Get
            Return m_rek_no
        End Get
        Set(ByVal value As String)
            m_rek_no = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property REK_NO1() As String
        Get
            Return m_rek_no
        End Get
        Set(ByVal value As String)
            m_rek_no = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property FK_BANKCODE() As String
        Get
            Return m_fk_bankcode
        End Get
        Set(ByVal value As String)
            m_fk_bankcode = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property CREDIT_CARD_EXPIRY_DATE() As String
        Get
            Return m_credit_card_expiry_date
        End Get
        Set(ByVal value As String)
            m_credit_card_expiry_date = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property CREDIT_CARD_CVV_NO() As String
        Get
            Return m_credit_card_cvv_no
        End Get
        Set(ByVal value As String)
            m_credit_card_cvv_no = value
        End Set
    End Property

End Class
