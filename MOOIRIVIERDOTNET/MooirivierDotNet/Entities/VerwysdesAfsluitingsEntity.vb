Imports System.ComponentModel

<Serializable()> _
Public Class VerwysdesAfsluitingsEntity


    Private m_pkVerwysdesAfsluitings As Integer
    Private m_fkVerwysdes As Integer
    Private m_DatumAfgesluit As Date
    Private m_Kommissie As Decimal


    <DataObjectField(False, False, False)> _
  Public Property pkVerwysdesAfsluitings() As Integer
        Get
            Return m_pkVerwysdesAfsluitings
        End Get
        Set(ByVal value As Integer)
            m_pkVerwysdesAfsluitings = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property fkVerwysdes() As Integer
        Get
            Return m_fkVerwysdes
        End Get
        Set(ByVal value As Integer)
            m_fkVerwysdes = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property DatumAfgesluit() As Date
        Get
            Return m_DatumAfgesluit
        End Get
        Set(ByVal value As Date)
            m_DatumAfgesluit = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
Public Property Kommissie() As Decimal
        Get
            Return m_Kommissie
        End Get
        Set(ByVal value As Decimal)
            m_Kommissie = value
        End Set
    End Property

End Class
