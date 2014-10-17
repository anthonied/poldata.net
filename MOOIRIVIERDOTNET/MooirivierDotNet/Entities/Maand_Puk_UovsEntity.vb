Imports System.ComponentModel

<Serializable()> _
    Public Class Maand_Puk_UovsEntity

    Private m_polisno As String
    Private m_Vord_dat As Date
    Private m_Premie As Decimal
    Private m_Vord_premie As Decimal
    Private m_Jaar As Integer
    Private m_Maand As Integer
    Private m_Trans_dat As Date
    Private m_Afsluit_dat As Date
    Private m_Ingevorder As Decimal


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
    Public Property Vord_dat() As Date
        Get
            Return m_Vord_dat
        End Get
        Set(ByVal value As Date)
            m_Vord_dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Premie() As Decimal
        Get
            Return m_Premie
        End Get
        Set(ByVal value As Decimal)
            m_Premie = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property Vord_premie() As Decimal
        Get
            Return m_Vord_premie
        End Get
        Set(ByVal value As Decimal)
            m_Vord_premie = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Jaar() As Integer
        Get
            Return m_Jaar
        End Get
        Set(ByVal value As Integer)
            m_Jaar = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
  Public Property Maand() As Integer
        Get
            Return m_Maand
        End Get
        Set(ByVal value As Integer)
            m_Maand = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Trans_dat() As Date
        Get
            Return m_Trans_dat
        End Get
        Set(ByVal value As Date)
            m_Trans_dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Afsluit_dat() As Date
        Get
            Return m_Afsluit_dat
        End Get
        Set(ByVal value As Date)
            m_Afsluit_dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Ingevorder() As Decimal
        Get
            Return m_Ingevorder
        End Get
        Set(ByVal value As Decimal)
            m_Ingevorder = value
        End Set
    End Property

End Class


