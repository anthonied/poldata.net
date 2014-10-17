Imports System.ComponentModel
<Serializable()> _
Public Class KontantEntity

    Private m_polisno As String
    Private m_vord_dat As Date
    Private m_premie As Decimal
    Private m_vord_premie As Decimal
    Private m_afsluit_dat As Date
    Private m_jaar As Integer
    Private m_maand As Integer
    Private m_trans_dat As Date
    Private m_betaalwyse As String
    Private m_kwitansie As String
    Private m_verw1 As String
    Private m_verw2 As String
    Private m_verw3 As String
    Private m_TJEKBESONDERHEDE As String
    Private m_verw4 As String
    Private m_verw5 As String
    Private m_vt_trans_dat As Date
    Private m_gekans As Integer
    Private m_kans_dat As Date
    Private m_vtkans_dat As Date
    Private m_mkkans_dat As Date
    Private m_jkkans_dat As Date
    Private m_eb_trans_dat As Date
    Private m_ms_trans_dat As Date
    Private m_ei_trans_dat As Date
    Private m_md_trans_dat As Date
    Private m_tipe As String
    Private m_kontant_tipe As String
    Private m_gg_trans_dat As Date
    Private m_Index As String
    Private m_nuwe_tjekno As String
    Private m_tjekno As String
    Private m_tjekno_uit As String
    Private m_tjekno_in As String
    Private m_EISNO As String
    Private m_TJEKDATUM As String
    Private m_kwit_boek As String
    Private m_Me_Trans_Dat As Date
    Private m_FkLangtermynpolis As Integer
    Private m_LTPtipe As String
    Private m_FKLangtermynpolis_Kontant As String
    Private m_VTDatumAangevra As Date
    Private m_area As String
    Private m_Nomatch As Boolean
    Private m_Ingevorder As Decimal
    Private m_mk_trans_dat As Date
    Private m_payment_beskrywing As String
    Private m_pk_waarde As String
    Private m_tabel As String
    Private m_jk_trans_dat As Date

    <DataObjectField(False, False, False)> _
    Public Property mk_trans_dat() As Date
        Get
            Return m_mk_trans_dat
        End Get
        Set(ByVal value As Date)
            m_mk_trans_dat = value
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
    Public Property polisno() As String
        Get
            Return m_polisno
        End Get
        Set(ByVal value As String)
            m_polisno = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property TJEKBESONDERHEDE() As String
        Get
            Return m_TJEKBESONDERHEDE
        End Get
        Set(ByVal value As String)
            m_TJEKBESONDERHEDE = value
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
    Public Property vt_trans_dat() As Date
        Get
            Return m_vt_trans_dat
        End Get
        Set(ByVal value As Date)
            m_vt_trans_dat = value
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
    Public Property kwitansie() As String
        Get
            Return m_kwitansie
        End Get
        Set(ByVal value As String)
            m_kwitansie = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property verw1() As String
        Get
            Return m_verw1
        End Get
        Set(ByVal value As String)
            m_verw1 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property verw2() As String
        Get
            Return m_verw2
        End Get
        Set(ByVal value As String)
            m_verw2 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property verw3() As String
        Get
            Return m_verw3
        End Get
        Set(ByVal value As String)
            m_verw3 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property verw4() As String
        Get
            Return m_verw4
        End Get
        Set(ByVal value As String)
            m_verw4 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property verw5() As String
        Get
            Return m_verw5
        End Get
        Set(ByVal value As String)
            m_verw5 = value
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
    Public Property vtkans_dat() As Date
        Get
            Return m_vtkans_dat
        End Get
        Set(ByVal value As Date)
            m_vtkans_dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property mkkans_dat() As Date
        Get
            Return m_mkkans_dat
        End Get
        Set(ByVal value As Date)
            m_mkkans_dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property jkkans_dat() As Date
        Get
            Return m_jkkans_dat
        End Get
        Set(ByVal value As Date)
            m_jkkans_dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property eb_trans_dat() As Date
        Get
            Return m_eb_trans_dat
        End Get
        Set(ByVal value As Date)
            m_eb_trans_dat = value
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
    Public Property ei_trans_dat() As Date
        Get
            Return m_ei_trans_dat
        End Get
        Set(ByVal value As Date)
            m_ei_trans_dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property md_trans_dat() As Date
        Get
            Return m_md_trans_dat
        End Get
        Set(ByVal value As Date)
            m_md_trans_dat = value
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
    Public Property kontant_tipe() As String
        Get
            Return m_kontant_tipe
        End Get
        Set(ByVal value As String)
            m_kontant_tipe = value
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
    Public Property nuwe_tjekno() As String
        Get
            Return m_nuwe_tjekno
        End Get
        Set(ByVal value As String)
            m_nuwe_tjekno = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property tjekno() As String
        Get
            Return m_tjekno
        End Get
        Set(ByVal value As String)
            m_tjekno = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
   Public Property tjekno_uit() As String
        Get
            Return m_tjekno_uit
        End Get
        Set(ByVal value As String)
            m_tjekno_uit = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property tjekno_in() As String
        Get
            Return m_tjekno_in
        End Get
        Set(ByVal value As String)
            m_tjekno_in = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
       Public Property EISNO() As String
        Get
            Return m_EISNO
        End Get
        Set(ByVal value As String)
            m_EISNO = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property TJEKDATUM() As String
        Get
            Return m_TJEKDATUM
        End Get
        Set(ByVal value As String)
            m_TJEKDATUM = value
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
    Public Property Me_Trans_Dat() As Date
        Get
            Return m_Me_Trans_Dat
        End Get
        Set(ByVal value As Date)
            m_Me_Trans_Dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property FkLangtermynpolis() As Integer
        Get
            Return m_FkLangtermynpolis
        End Get
        Set(ByVal value As Integer)
            m_FkLangtermynpolis = value
        End Set
    End Property

   
    <DataObjectField(False, False, False)> _
   Public Property LTPtipe() As String
        Get
            Return m_LTPtipe
        End Get
        Set(ByVal value As String)
            m_LTPtipe = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property FKLangtermynpolis_Kontant() As String
        Get
            Return m_FKLangtermynpolis_Kontant
        End Get
        Set(ByVal value As String)
            m_FKLangtermynpolis_Kontant = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
   Public Property VTDatumAangevra() As Date
        Get
            Return m_VTDatumAangevra
        End Get
        Set(ByVal value As Date)
            m_VTDatumAangevra = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property area() As String
        Get
            Return m_area
        End Get
        Set(ByVal value As String)
            m_area = value
        End Set
    End Property
    'Andriette 17/06/2014
    ' Wys die betaling beskrywin ipv net die 
    <DataObjectField(False, False, False)> _
    Public Property payment_beskrywing() As String
        Get
            Return m_payment_beskrywing
        End Get
        Set(ByVal value As String)
            m_payment_beskrywing = value
        End Set
    End Property

    'Andriette 02/07/2014 
    'voeg die pk waarde en die tabel naam by
    <DataObjectField(False, False, False)> _
    Public Property pk_waarde() As String
        Get
            Return m_pk_waarde
        End Get
        Set(ByVal value As String)
            m_pk_waarde = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property tabel() As String
        Get
            Return m_tabel
        End Get
        Set(ByVal value As String)
            m_tabel = value
        End Set
    End Property
    'Andriette 07/07/2014 
    <DataObjectField(False, False, False)> _
    Public Property jk_trans_dat As Date
        Get
            Return m_jk_trans_dat

        End Get
        Set(ByVal value As Date)
            m_jk_trans_dat = value
        End Set
    End Property
End Class
