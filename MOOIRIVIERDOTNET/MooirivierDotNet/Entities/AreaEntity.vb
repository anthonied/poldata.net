Imports System.ComponentModel

<Serializable()> _
Public Class AreaEntity

    Private m_area_besk As String
    Private m_area_windskerm_bybet As Decimal
    Private m_mot_dek_bedrag As Decimal
    Private m_mot_dek_pers As Integer
    Private m_mot_dek_e_d As String
    Private m_mot_cov_e_d As String
    Private m_lewendig As String
    Private m_datumnielewendig As String
    Private m_tak_naam As String
    Private m_tak_dorp As String
    Private m_tak_poskode As String
    Private m_tak_straat As String
    Private m_tak_straat_poskode As String
    Private m_tak_tel As String
    Private m_tak_faks As String
    Private m_tak_modem As String
    Private m_tak_univ As String
    Private m_tak_unive As String
    Private m_tak_afkorting As String
    Private m_tak_epos As String
    Private m_tak_kontakpersoon As String
    Private m_motkommpers As Decimal
    Private m_hekommpers As Decimal
    Private m_hbkommpers As Decimal
    Private m_arkommpers As Decimal
    Private m_tak_bknaam As String
    Private m_tak_regno As String
    Private m_tak_bankbouv As String
    Private m_tak_takkode As String
    Private m_tak_rekeningnr As String
    Private m_tak_ongevalle As Decimal
    Private m_tak_bknaam_e As String
    Private m_tak_regno_e As String
    Private m_tak_dae1_a As String
    Private m_tak_dae1_e As String
    Private m_tak_dae2_a As String
    Private m_tak_dae2_e As String
    Private m_tak_ete_a As String
    Private m_tak_ete_e As String
    Private m_tak_voorstad As String
    Private m_tak_straat_e As String
    Private m_arposkodeongespes As String
    Private m_nedbankleerafkorting As String
    Private m_fsb_a As String
    Private m_fsb_e As String
    Private m_makelaarpolisno_a As String
    Private m_makelaarpolisno_e As String
    Private m_btwno As String
    Private m_boukoste As Decimal
    Private m_pakketitem1 As Decimal
    Private m_pakketitem2 As Decimal
    Private m_pakketitem3 As Decimal
    Private m_pakketitem4 As Decimal
    Private m_pakketitem1dekking As Decimal
    Private m_pakketitem2dekking As Decimal
    Private m_pakketitem3dekking As Decimal
    Private m_pakketitem4dekking As Decimal
    Private m_pakketitem1tel As String
    Private m_homeassistancedesc As String
    Private m_homeassistancetel As String
    Private m_fkversekeraar As Integer
    Private m_fkmakelaar As Integer
    Private m_autoassisttel As String
    Private m_fkvorigeversekeraar As Integer
    Private m_area_kode As String
    Private m_pkarea As Integer

    Private m_autoassist As String
    Private m_autoassisteng As String

    Private m_polisadministrasie As String
    Private m_tak_posbus As String
    Private m_tak_posbuseng As String
    Private m_polisadministrasieeng As String
    Private m_fkvorigemakelaar As Integer
    Private m_arongespesbedrag As String
    Private m_homeassistancedesceng As String
    Private m_showvehicleextrafields As Boolean
    Private m_displayfield As String
    Private m_NoMatch As Boolean
    <DataObjectField(False, False, False)> _
    Public Property fkmakelaar() As Integer
        Get
            Return m_fkmakelaar
        End Get
        Set(ByVal value As Integer)
            m_fkmakelaar = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property autoassist() As String
        Get
            Return m_autoassist
        End Get
        Set(ByVal value As String)
            m_autoassist = value
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
    Public Property Area_Besk() As String
        Get
            Return m_area_besk
        End Get
        Set(ByVal value As String)
            m_area_besk = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Area_Windskerm_Bybet() As Decimal
        Get
            Return m_area_windskerm_bybet
        End Get
        Set(ByVal value As Decimal)
            m_area_windskerm_bybet = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Mot_Dek_Bedrag() As Decimal
        Get
            Return m_mot_dek_bedrag
        End Get
        Set(ByVal value As Decimal)
            m_mot_dek_bedrag = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Mot_Dek_Pers() As Integer
        Get
            Return m_mot_dek_pers
        End Get
        Set(ByVal value As Integer)
            m_mot_dek_pers = value
        End Set
    End Property


    <DataObjectField(False, False, False)> _
    Public Property fkversekeraar() As Integer
        Get
            Return m_fkversekeraar
        End Get
        Set(ByVal value As Integer)
            m_fkversekeraar = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Mot_Dek_e_d() As String
        Get
            Return m_mot_dek_e_d
        End Get
        Set(ByVal value As String)
            m_mot_dek_e_d = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Mot_Cov_e_d() As String
        Get
            Return m_mot_cov_e_d
        End Get
        Set(ByVal value As String)
            m_mot_cov_e_d = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Lewendig() As String
        Get
            Return m_lewendig
        End Get
        Set(ByVal value As String)
            m_lewendig = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Datumnielewendig() As String
        Get
            Return m_datumnielewendig
        End Get
        Set(ByVal value As String)
            m_datumnielewendig = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Tak_Naam() As String
        Get
            Return m_tak_naam
        End Get
        Set(ByVal value As String)
            m_tak_naam = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Tak_Dorp() As String
        Get
            Return m_tak_dorp
        End Get
        Set(ByVal value As String)
            m_tak_dorp = value
        End Set
    End Property


    <DataObjectField(False, False, False)> _
    Public Property Tak_Poskode() As String
        Get
            Return m_tak_poskode
        End Get
        Set(ByVal value As String)
            m_tak_poskode = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Tak_straat() As String
        Get
            Return m_tak_straat
        End Get
        Set(ByVal value As String)
            m_tak_straat = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Tak_Straat_Poskode() As String
        Get
            Return m_tak_straat_poskode
        End Get
        Set(ByVal value As String)
            m_tak_straat_poskode = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Tak_tel() As String
        Get
            Return m_tak_tel
        End Get
        Set(ByVal value As String)
            m_tak_tel = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property DisplayField() As String
        Get
            Return m_displayfield
        End Get
        Set(ByVal value As String)
            m_displayfield = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property pkarea() As Integer
        Get
            Return m_pkarea
        End Get
        Set(ByVal value As Integer)
            m_pkarea = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property tak_afkorting() As String
        Get
            Return m_tak_afkorting
        End Get
        Set(ByVal value As String)
            m_tak_afkorting = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property tak_posbus() As String
        Get
            Return m_tak_posbus
        End Get
        Set(ByVal value As String)
            m_tak_posbus = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property tak_faks() As String
        Get
            Return m_tak_faks
        End Get
        Set(ByVal value As String)
            m_tak_faks = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property motkommpers() As String
        Get
            Return m_motkommpers
        End Get
        Set(ByVal value As String)
            m_motkommpers = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property hekommpers() As String
        Get
            Return m_hekommpers
        End Get
        Set(ByVal value As String)
            m_hekommpers = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property hbkommpers() As String
        Get
            Return m_hbkommpers
        End Get
        Set(ByVal value As String)
            m_hbkommpers = value
        End Set
    End Property


    <DataObjectField(False, False, False)> _
    Public Property arkommpers() As String
        Get
            Return m_arkommpers
        End Get
        Set(ByVal value As String)
            m_arkommpers = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property tak_epos() As String
        Get
            Return m_tak_epos
        End Get
        Set(ByVal value As String)
            m_tak_epos = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property tak_kontakpersoon() As String
        Get
            Return m_tak_kontakpersoon
        End Get
        Set(ByVal value As String)
            m_tak_kontakpersoon = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property tak_bknaam() As String
        Get
            Return m_tak_bknaam
        End Get
        Set(ByVal value As String)
            m_tak_bknaam = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property tak_regno() As String
        Get
            Return m_tak_regno
        End Get
        Set(ByVal value As String)
            m_tak_regno = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property tak_bknaame() As String
        Get
            Return m_tak_bknaam_e
        End Get
        Set(ByVal value As String)
            m_tak_bknaam_e = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property tak_regno_e() As String
        Get
            Return m_tak_regno_e
        End Get
        Set(ByVal value As String)
            m_tak_regno_e = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property tak_dae1_e() As String
        Get
            Return m_tak_dae1_e
        End Get
        Set(ByVal value As String)
            m_tak_dae1_e = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property tak_dae1_a() As String
        Get
            Return m_tak_dae1_a
        End Get
        Set(ByVal value As String)
            m_tak_dae1_a = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property tak_dae2_e() As String
        Get
            Return m_tak_dae2_e
        End Get
        Set(ByVal value As String)
            m_tak_dae2_e = value
        End Set
    End Property


    <DataObjectField(False, False, False)> _
    Public Property tak_dae2_a() As String
        Get
            Return m_tak_dae2_a
        End Get
        Set(ByVal value As String)
            m_tak_dae2_a = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property tak_ete_a() As String
        Get
            Return m_tak_ete_a
        End Get
        Set(ByVal value As String)
            m_tak_ete_a = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property tak_voorstad() As String
        Get
            Return m_tak_voorstad
        End Get
        Set(ByVal value As String)
            m_tak_voorstad = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property tak_ete_e() As String
        Get
            Return m_tak_ete_e
        End Get
        Set(ByVal value As String)
            m_tak_ete_e = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Tak_straat_e() As String
        Get
            Return m_tak_straat_e
        End Get
        Set(ByVal value As String)
            m_tak_straat_e = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property TAK_UNIV() As String
        Get
            Return m_tak_univ
        End Get
        Set(ByVal value As String)
            m_tak_univ = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property TAK_UNIVE() As String
        Get
            Return m_tak_unive
        End Get
        Set(ByVal value As String)
            m_tak_unive = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property pakketitem1() As String
        Get
            Return m_pakketitem1
        End Get
        Set(ByVal value As String)
            m_pakketitem1 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property pakketitem2() As String
        Get
            ' Andriette 30/05/2013 maak reg na 2 ipv 1
            Return m_pakketitem2
        End Get
        Set(ByVal value As String)
            ' Andriette 30/05/2013 maak reg na 2 ipv 1
            m_pakketitem2 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property homeassistancedesc() As String
        Get
            Return m_homeassistancedesc
        End Get
        Set(ByVal value As String)
            m_homeassistancedesc = value
        End Set
    End Property


    <DataObjectField(False, False, False)> _
    Public Property homeassistancetel() As String
        Get
            Return m_homeassistancetel
        End Get
        Set(ByVal value As String)
            m_homeassistancetel = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property pakketitem3() As String
        Get
            Return m_pakketitem3
        End Get
        Set(ByVal value As String)
            m_pakketitem3 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property pakketitem4() As String
        Get
            Return m_pakketitem4
        End Get
        Set(ByVal value As String)
            m_pakketitem4 = value
        End Set
    End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property


    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property


    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    '  Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property

    '<DataObjectField(False, False, False)> _
    'Public Property x() As String
    '    Get
    '        Return x
    '    End Get
    '    Set(ByVal value As String)
    '        x = value
    '    End Set
    'End Property
End Class
