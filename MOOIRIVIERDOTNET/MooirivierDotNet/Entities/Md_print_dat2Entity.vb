Imports System.ComponentModel

<Serializable()> _
Public Class Md_print_dat2Entity

    Private m_eispers As Decimal
    Private m_Premie2 As Decimal
    Private m_courtesyv As Decimal
    Private m_epc As Decimal
    Private m_inscell As Decimal
  
    <DataObjectField(False, False, False)> _
    Public Property eispers() As Decimal
        Get
            Return m_eispers
        End Get
        Set(ByVal value As Decimal)
            m_eispers = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
   Public Property Premie2() As Decimal
        Get
            Return m_Premie2
        End Get
        Set(ByVal value As Decimal)
            m_Premie2 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
   Public Property courtesyv() As Decimal
        Get
            Return m_courtesyv
        End Get
        Set(ByVal value As Decimal)
            m_courtesyv = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property epc() As Decimal
        Get
            Return m_epc
        End Get
        Set(ByVal value As Decimal)
            m_epc = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property inscell() As Decimal
        Get
            Return m_inscell
        End Get
        Set(ByVal value As Decimal)
            m_inscell = value
        End Set
    End Property
End Class
