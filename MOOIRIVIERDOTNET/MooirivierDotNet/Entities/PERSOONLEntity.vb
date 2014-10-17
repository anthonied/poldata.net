Imports System.ComponentModel

<Serializable()> _
Public Class PERSOONLEntity
    Private m_titel As String
    Private m_versekerde As String
    Private m_voork As String
    Private m_gekans As Boolean
    Private m_polisno As String
    Private m_id_nom As String
    Private m_adres As String
    Private m_adres1 As String
    Private m_adres2 As String
    Private m_premiekode As String
    Private m_p_a_dat As String
    Private m_huis_tel As String
    Private m_werk_tel As String
    Private m_bybet_k As String
    Private m_eisbonus As String
    Private m_beroep As String
    Private m_werk_g As String
    Private m_vanwie As String
    Private m_opmerking As String
    Private m_geb_dat As String
    Private m_pos_vakkie As String
    Private m_taal As String
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    'Andriette 14/08/2013 - verander van double na decimal vir meer opsies

    Private m_polfooi As Decimal
    Private m_sasprem As Decimal
    Private m_tv_diens As Decimal
    Private m_medies As Decimal
    Private m_begrafnis As Decimal
    Private m_bet_wyse As String
    Private m_premie As Decimal
    Private m_subtotal As Decimal
    Private m_makelaar As String
    Private m_assesor As String
    Private m_klerk As String
    Private m_beskerm As Decimal
    Private m_motor_sub As Decimal
    Private m_huis_sub As Decimal
    Private m_alle_sub As Decimal
    Private m_plip As String
    Private m_plip1 As Decimal
    Private m_bet_dat As String
    Private m_begraf_dek As Decimal
    Private m_huis_tel2 As String
    Private m_werk_tel2 As String
    Private m_k_opmerking As String
    Private m_email As String
    Private m_fax As String
    Private m_sel_tel As String
    Private m_dept As String
    Private m_posbestemming As String
    Private m_btwno As String
    Private m_eisgeblok As Integer
    Private m_pakketitem1 As Decimal
    Private m_pakketitem2 As Decimal
    Private m_pakketitem3 As Decimal
    Private m_pakketitem4 As Decimal
    Private m_clrstypeofamendment As String
    Private m_area As String
    Private m_datumeffekgekans As String
    Private m_pers_nom As String
    Private m_eispers As String
    Private m_besk_nr As String
    Private m_careassist As Decimal
    Private m_adres3 As String
    Private m_elektroniesgestuur As Boolean
    Private m_epc As Decimal
    Private m_noemnaam As String
    Private m_aftrekdat As String
    Private m_selfoon As Decimal
    Private m_titelnum As Integer
    Private m_adres4 As String
    Private m_fkkansellasieredes As Integer
    Private m_datumgekanselleer As String
    Private m_datumtoegevoer As String
    Private m_wn_polis As Decimal
    Private n_ingevorder As Decimal
    Private m_oudstudent As String
    Private m_studentno As String
    Private m_premie2 As Decimal
    Private m_varwyskommissie As Decimal
    Private m_verwysdeur As String
    Private m_courtesyv As Decimal
    Private m_betaaldatum As String
    Private m_bybmemo As String
    Private m_nomatch As Boolean
    Private m_index As String
    Private m_area_besk As String
    Private m_Active_Icon As String
    Private m_Nommerplate As String

    Public Property Index() As String
        Get
            Return m_index
        End Get
        Set(ByVal value As String)
            m_index = value
        End Set
    End Property

    Public Property NoMatch() As Boolean
        Get
            Return m_nomatch
        End Get
        Set(ByVal value As Boolean)
            m_nomatch = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property TITEL() As String
        Get
            Return m_titel
        End Get
        Set(ByVal value As String)
            m_titel = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property VERSEKERDE() As String
        Get
            Return m_versekerde
        End Get
        Set(ByVal value As String)
            m_versekerde = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property VOORL() As String
        Get
            Return m_voork
        End Get
        Set(ByVal value As String)
            m_voork = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property GEKANS() As Boolean
        Get
            Return m_gekans
        End Get
        Set(ByVal value As Boolean)
            m_gekans = value
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
Public Property ID_NOM() As String
        Get
            Return m_id_nom
        End Get
        Set(ByVal value As String)
            m_id_nom = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property ADRES() As String
        Get
            Return m_adres
        End Get
        Set(ByVal value As String)
            m_adres = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property ADRES1() As String
        Get
            Return m_adres1
        End Get
        Set(ByVal value As String)
            m_adres1 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property ADRES2() As String
        Get
            Return m_adres2
        End Get
        Set(ByVal value As String)
            m_adres2 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property PREMIEKODE() As String
        Get
            Return m_premiekode
        End Get
        Set(ByVal value As String)
            m_premiekode = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property P_A_DAT() As String
        Get
            Return m_p_a_dat
        End Get
        Set(ByVal value As String)
            m_p_a_dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property HUIS_TEL() As String
        Get
            Return m_huis_tel
        End Get
        Set(ByVal value As String)
            m_huis_tel = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property WERK_TEL() As String
        Get
            Return m_werk_tel
        End Get
        Set(ByVal value As String)
            m_werk_tel = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property BYBET_K() As String
        Get
            Return m_bybet_k
        End Get
        Set(ByVal value As String)
            m_bybet_k = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property EISBONUS() As String
        Get
            Return m_eisbonus
        End Get
        Set(ByVal value As String)
            m_eisbonus = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property BEROEP() As String
        Get
            Return m_beroep
        End Get
        Set(ByVal value As String)
            m_beroep = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property WERK_G() As String
        Get
            Return m_werk_g
        End Get
        Set(ByVal value As String)
            m_werk_g = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property VANWIE() As String
        Get
            Return m_vanwie
        End Get
        Set(ByVal value As String)
            m_vanwie = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property OPMERKING() As String
        Get
            Return m_opmerking
        End Get
        Set(ByVal value As String)
            m_opmerking = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property GEB_DAT() As String
        Get
            Return m_geb_dat
        End Get
        Set(ByVal value As String)
            m_geb_dat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property POS_VAKKIE() As String
        Get
            Return m_pos_vakkie
        End Get
        Set(ByVal value As String)
            m_pos_vakkie = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property TAAL() As String
        Get
            Return m_taal
        End Get
        Set(ByVal value As String)
            m_taal = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property POLFOOI() As Decimal
        Get
            Return m_polfooi
        End Get
        Set(ByVal value As Decimal)
            m_polfooi = String.Format("{0:N2}", value)
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property SASPREM() As Decimal
        Get
            Return m_sasprem
        End Get
        Set(ByVal value As Decimal)
            m_sasprem = String.Format("{0:N2}", value)
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property TV_DIENS() As Decimal
        Get
            Return m_tv_diens
        End Get
        Set(ByVal value As Decimal)
            m_tv_diens = String.Format("{0:N2}", value)
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property MEDIES() As Decimal
        Get
            Return m_medies
        End Get
        Set(ByVal value As Decimal)
            m_medies = String.Format("{0:N2}", value)
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property BEGRAFNIS() As Decimal
        Get
            Return m_begrafnis
        End Get
        Set(ByVal value As Decimal)
            m_begrafnis = String.Format("{0:N2}", value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property BET_WYSE() As String
        Get
            Return m_bet_wyse
        End Get
        Set(ByVal value As String)
            m_bet_wyse = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property PREMIE() As Decimal
        Get
            Return m_premie
        End Get
        Set(ByVal value As Decimal)
            m_premie = String.Format("{0:N2}", value)
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property SUBTOTAAL() As Decimal
        Get
            Return m_subtotal
        End Get
        Set(ByVal value As Decimal)
            m_subtotal = String.Format("{0:N2}", value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property MAKELAAR() As String
        Get
            Return m_makelaar
        End Get
        Set(ByVal value As String)
            m_makelaar = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property ASSESOR() As String
        Get
            Return m_assesor
        End Get
        Set(ByVal value As String)
            m_assesor = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property KLERK() As String
        Get
            Return m_klerk
        End Get
        Set(ByVal value As String)
            m_klerk = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property BESKERM() As Decimal
        Get
            Return m_beskerm
        End Get
        Set(ByVal value As Decimal)
            m_beskerm = String.Format("{0:N2}", value)
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property MOTOR_SUB() As Decimal
        Get
            Return m_motor_sub
        End Get
        Set(ByVal value As Decimal)
            m_motor_sub = String.Format("{0:N2}", value)
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property HUIS_SUB() As Decimal
        Get
            Return m_huis_sub
        End Get
        Set(ByVal value As Decimal)
            m_huis_sub = String.Format("{0:N2}", value)
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property ALLE_SUB() As Decimal
        Get
            Return m_alle_sub
        End Get
        Set(ByVal value As Decimal)
            m_alle_sub = String.Format("{0:N2}", value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property PLIP() As String
        Get
            Return m_plip
        End Get
        Set(ByVal value As String)
            m_plip = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property PLIP1() As Decimal
        Get
            Return m_plip1
        End Get
        Set(ByVal value As Decimal)
            m_plip1 = String.Format("{0:N2}", value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property bet_dat() As String
        Get
            Return m_bet_dat
        End Get
        Set(ByVal value As String)
            m_bet_dat = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property begraf_dek() As Decimal
        Get
            Return m_begraf_dek
        End Get
        Set(ByVal value As Decimal)
            m_begraf_dek = String.Format("{0:N2}", value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property HUIS_TEL2() As String
        Get
            Return m_huis_tel2
        End Get
        Set(ByVal value As String)
            m_huis_tel2 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property WERK_TEL2() As String
        Get
            Return m_werk_tel2
        End Get
        Set(ByVal value As String)
            m_werk_tel2 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property K_OPMERKING() As String
        Get
            Return m_k_opmerking
        End Get
        Set(ByVal value As String)
            m_k_opmerking = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property EMAIL() As String
        Get
            Return m_email
        End Get
        Set(ByVal value As String)
            m_email = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property FAX() As String
        Get
            Return m_fax
        End Get
        Set(ByVal value As String)
            m_fax = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property SEL_TEL() As String
        Get
            Return m_sel_tel
        End Get
        Set(ByVal value As String)
            m_sel_tel = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property DEPT() As String
        Get
            Return m_dept
        End Get
        Set(ByVal value As String)
            m_dept = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property POSBESTEMMING() As String
        Get
            Return m_posbestemming
        End Get
        Set(ByVal value As String)
            m_posbestemming = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property WN_POLIS() As Decimal
        Get
            Return m_wn_polis
        End Get
        Set(ByVal value As Decimal)
            m_wn_polis = String.Format("{0:N2}", value)
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property INGEVORDER() As Decimal
        Get
            Return n_ingevorder
        End Get
        Set(ByVal value As Decimal)
            n_ingevorder = String.Format("{0:N2}", value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property OUDSTUDENT() As String
        Get
            Return m_oudstudent
        End Get
        Set(ByVal value As String)
            m_oudstudent = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property STUDENTNO() As String
        Get
            Return m_studentno
        End Get
        Set(ByVal value As String)
            m_studentno = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property premie2() As Decimal
        Get
            Return m_premie2
        End Get
        Set(ByVal value As Decimal)
            m_premie2 = String.Format("{0:N4}", value)
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property verwyskommissie() As Decimal
        Get
            Return m_varwyskommissie
        End Get
        Set(ByVal value As Decimal)
            m_varwyskommissie = String.Format("{0:N2}", value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property verwysdeur() As String
        Get
            Return m_verwysdeur
        End Get
        Set(ByVal value As String)
            m_verwysdeur = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property courtesyv() As Decimal
        Get
            Return m_courtesyv
        End Get
        Set(ByVal value As Decimal)
            m_courtesyv = String.Format("{0:N2}", value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property betaaldatum() As String
        Get
            Return m_betaaldatum
        End Get
        Set(ByVal value As String)
            m_betaaldatum = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property bybmemo() As String
        Get
            Return m_bybmemo
        End Get
        Set(ByVal value As String)
            m_bybmemo = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property eispers() As String
        Get
            Return m_eispers
        End Get
        Set(ByVal value As String)
            m_eispers = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property besk_nr() As String
        Get
            Return m_besk_nr
        End Get
        Set(ByVal value As String)
            m_besk_nr = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property careassist() As Decimal
        Get
            Return m_careassist
        End Get
        Set(ByVal value As Decimal)
            m_careassist = String.Format("{0:N2}", value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property adres3() As String
        Get
            Return m_adres3
        End Get
        Set(ByVal value As String)
            m_adres3 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property elektroniesgestuur() As String
        Get
            Return m_elektroniesgestuur
        End Get
        Set(ByVal value As String)
            m_elektroniesgestuur = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property epc() As Decimal
        Get
            Return m_epc
        End Get
        Set(ByVal value As Decimal)
            m_epc = String.Format("{0:N2}", value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property noemnaam() As String
        Get
            Return m_noemnaam
        End Get
        Set(ByVal value As String)
            m_noemnaam = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property aftrekdat() As String
        Get
            Return m_aftrekdat
        End Get
        Set(ByVal value As String)
            m_aftrekdat = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property selfoon() As String
        Get
            Return m_selfoon
        End Get
        Set(ByVal value As String)
            m_selfoon = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property titelnum() As String
        Get
            Return m_titel
        End Get
        Set(ByVal value As String)
            m_titel = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property Adres4() As String
        Get
            Return m_adres4
        End Get
        Set(ByVal value As String)
            m_adres4 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property fkKansellasieRedes() As String
        Get
            Return m_fkkansellasieredes
        End Get
        Set(ByVal value As String)
            m_fkkansellasieredes = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property DatumGekanselleer() As String
        Get
            Return m_datumgekanselleer
        End Get
        Set(ByVal value As String)
            m_datumgekanselleer = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property DatumToegevoer() As String
        Get
            Return m_datumtoegevoer
        End Get
        Set(ByVal value As String)
            m_datumtoegevoer = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property BTWNo() As String
        Get
            Return m_btwno
        End Get
        Set(ByVal value As String)
            m_btwno = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Eisgeblok() As String
        Get
            Return m_eisgeblok
        End Get
        Set(ByVal value As String)
            m_eisgeblok = value
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property PakketItem1() As Decimal
        Get
            Return m_pakketitem1
        End Get
        Set(ByVal value As Decimal)
            m_pakketitem1 = String.Format("{0:N2}", value)
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property PakketItem2() As Decimal
        Get
            Return m_pakketitem2
        End Get
        Set(ByVal value As Decimal)
            m_pakketitem2 = String.Format("{0:N2}", value)
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property PakketItem3() As Decimal
        Get
            Return m_pakketitem3
        End Get
        Set(ByVal value As Decimal)
            m_pakketitem3 = String.Format("{0:N2}", value)
        End Set
    End Property
    'Linkie 01/07/2013 - maak tipes reg volgens databasis
    <DataObjectField(False, False, False)> _
    Public Property PakketItem4() As Decimal
        Get
            Return m_pakketitem4
        End Get
        Set(ByVal value As Decimal)
            m_pakketitem4 = String.Format("{0:N2}", value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property CLRSTypeOfAmendment() As String
        Get
            Return m_clrstypeofamendment
        End Get
        Set(ByVal value As String)
            m_clrstypeofamendment = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
Public Property Area() As String
        Get
            Return m_area
        End Get
        Set(ByVal value As String)
            m_area = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
   Public Property DatumEffekGekans() As String
        Get
            Return m_datumeffekgekans
        End Get
        Set(ByVal value As String)
            m_datumeffekgekans = value
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
    Public Property Area_Besk() As String
        Get
            Return m_area_besk
        End Get
        Set(ByVal value As String)
            m_area_besk = value
        End Set
    End Property
    Public Property Active_Icon() As String
        Get
            Return m_Active_Icon
        End Get
        Set(ByVal value As String)
            m_Active_Icon = value
        End Set
    End Property
    'Andriette 17/09/2013 veog hierdie by om ook die nommerplate te kan wys wanneer so benodig
    <DataObjectField(False, False, False)> _
     Public Property Nommerplate() As String
        Get
            Return m_Nommerplate
        End Get
        Set(ByVal value As String)
            m_Nommerplate = value
        End Set
    End Property
End Class
