Imports System.ComponentModel

<Serializable()> _
Public Class ClaimsEntity
    Private m_Polisno As String
    Private m_Eisno As String
    Private m_Eisgr As String
    Private m_Tipe As String
    Private m_Datum As Date
    Private m_Afdat As Date
    Private m_Aan_dat As Date
    Private m_Beskrywing As String
    Private m_Beskrywing2 As String
    Private m_Beskrywing3 As String
    Private m_Eis_sorteer As Boolean
    Private m_Herverseker As Decimal
    Private m_Hollard_Kat As Integer
    Private m_EisGrNum As Decimal
    Private m_Tipe2 As Integer
    Private m_Beskrywing4 As String
    Private m_Versekerde As String
    Private m_voorl As String
    Private m_fkClaimStatus As Integer
    Private m_afdat2 As String
    Private m_Bybetalingsbedrag As Decimal
    Private m_EisMemo As String
    Private m_ETBeskrywing As String
    Private m_ETBeskrywing2 As String
    Private m_Voorstad As String
    Private m_Dorp As String
    Private m_Poskode As String
    Private m_WeerligBeskermer As String
    Private m_EisBeskrywing As String
    Private m_MotorTeruggekry As String
    Private m_SkadeBedrag As Decimal
    Private m_Motorgebruik As String
    Private m_BestuurderIDNommer As String
    Private m_DwelmMisbruik As String
    Private m_KnockVirKnock As String
    Private m_Hondgebyt As String
    Private m_Aggressief As String
    Private m_WerfUitgaan As String
    Private m_WatHetGebeur As String
    Private m_Waargekry As String
    Private m_fkClaimSubstatus As Integer
    Private m_EisSubStatusKode As String
    Private m_ExGratia As String
    Private m_RegsSoortEis As String
    Private m_Hondgedrag As String
    Private m_ItemWaarde As Decimal
    Private m_Afgeskryf As String
    Private m_KatastrofeJN As String
    Private m_KatastrofeNaam As String
    Private m_KatastrofeDatum As Date
    Private m_KatastrofeBybetalingsBedrag As Decimal
    Private m_fkItem As Integer
    Private m_KatastrofeTipe As String
    Private m_fkVersekeraar As Integer
    Private m_fkUma As Integer
    Private m_fkMakelaar As Integer
    Private m_ClaimStatusAfr As String
    Private m_ClaimStatusEng As String
    Private m_ClaimSubStatusAfr As String
    Private m_ClaimSubStatusEng As String
    <DataObjectField(False, False, False)> _
    Public Property Polisno() As String
        Get
            Return m_Polisno
        End Get
        Set(ByVal value As String)
            m_Polisno = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Eisno() As String
        Get
            Return m_Eisno
        End Get
        Set(ByVal value As String)
            m_Eisno = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Eisgr() As String
        Get
            Return m_Eisgr
        End Get
        Set(ByVal value As String)
            m_Eisgr = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Tipe() As String
        Get
            Return m_Tipe
        End Get
        Set(ByVal value As String)
            m_Tipe = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Datum() As Date
        Get
            Return m_Datum
        End Get
        Set(ByVal value As Date)
            m_Datum = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Afdat() As Date
        Get
            Return m_Afdat
        End Get
        Set(ByVal value As Date)
            m_Afdat = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Aan_dat() As Date
        Get
            Return m_Aan_dat
        End Get
        Set(ByVal value As Date)
            m_Aan_dat = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Beskrywing() As String
        Get
            Return m_Beskrywing
        End Get
        Set(ByVal value As String)
            m_Beskrywing = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Beskrywing2() As String
        Get
            Return m_Beskrywing2
        End Get
        Set(ByVal value As String)
            m_Beskrywing2 = value
        End Set
    End Property


    <DataObjectField(False, False, False)> _
    Public Property Beskrywing3() As String
        Get
            Return m_Beskrywing3
        End Get
        Set(ByVal value As String)
            m_Beskrywing3 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Eis_sorteer() As Boolean
        Get
            Return m_Eis_sorteer
        End Get
        Set(ByVal value As Boolean)
            m_Eis_sorteer = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Herverseker() As Decimal
        Get
            Return m_Herverseker
        End Get
        Set(ByVal value As Decimal)
            m_Herverseker = String.Format("{0:N2}", value)
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Hollard_Kat() As Integer
        Get
            Return m_Hollard_Kat
        End Get
        Set(ByVal value As Integer)
            m_Hollard_Kat = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property EisGrNum() As Decimal
        Get
            Return m_EisGrNum
        End Get
        Set(ByVal value As Decimal)
            m_EisGrNum = String.Format("{0:N2}", value)
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Tipe2() As Integer
        Get
            Return m_Tipe2
        End Get
        Set(ByVal value As Integer)
            m_Tipe2 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Beskrywing4() As String
        Get
            Return m_Beskrywing4
        End Get
        Set(ByVal value As String)
            m_Beskrywing4 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Versekerde() As String
        Get
            Return m_Versekerde
        End Get
        Set(ByVal value As String)
            m_Versekerde = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property voorl() As String
        Get
            Return m_voorl
        End Get
        Set(ByVal value As String)
            m_voorl = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property fkClaimstatus() As Integer
        Get
            Return m_fkClaimStatus
        End Get
        Set(ByVal value As Integer)
            m_fkClaimStatus = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property afdat2() As String
        Get
            Return m_afdat2
        End Get
        Set(ByVal value As String)
            m_afdat2 = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Bybetalingsbedrag() As Decimal
        Get
            Return m_Bybetalingsbedrag
        End Get
        Set(ByVal value As Decimal)
            m_Bybetalingsbedrag = String.Format("{0:N2}", value)
        End Set
    End Property


    <DataObjectField(False, False, False)> _
    Public Property EisMemo() As String
        Get
            Return m_EisMemo
        End Get
        Set(ByVal value As String)
            m_EisMemo = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property ETBeskrywing() As String
        Get
            Return m_ETBeskrywing
        End Get
        Set(ByVal value As String)
            m_ETBeskrywing = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property ETBeskrywing2() As String
        Get
            Return m_ETBeskrywing2
        End Get
        Set(ByVal value As String)
            m_ETBeskrywing2 = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Voorstad() As String
        Get
            Return m_Voorstad
        End Get
        Set(ByVal value As String)
            m_Voorstad = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Dorp() As String
        Get
            Return m_Dorp
        End Get
        Set(ByVal value As String)
            m_Dorp = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Poskode() As String
        Get
            Return m_Poskode
        End Get
        Set(ByVal value As String)
            m_Poskode = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property WeerligBeskermer() As String
        Get
            Return m_WeerligBeskermer
        End Get
        Set(ByVal value As String)
            m_WeerligBeskermer = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property EisBeskrywing() As String
        Get
            Return m_EisBeskrywing
        End Get
        Set(ByVal value As String)
            m_EisBeskrywing = value
        End Set
    End Property


    <DataObjectField(False, False, False)> _
    Public Property MotorTeruggekry() As String
        Get
            Return m_MotorTeruggekry
        End Get
        Set(ByVal value As String)
            m_MotorTeruggekry = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property SkadeBedrag() As Decimal
        Get
            Return m_SkadeBedrag
        End Get
        Set(ByVal value As Decimal)
            m_SkadeBedrag = String.Format("{0:N2}", value)
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Motorgebruik() As String
        Get
            Return m_Motorgebruik
        End Get
        Set(ByVal value As String)
            m_Motorgebruik = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property BestuurderIDNommer() As String
        Get
            Return m_BestuurderIDNommer
        End Get
        Set(ByVal value As String)
            m_BestuurderIDNommer = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property DwelmMisbruik() As String
        Get
            Return m_DwelmMisbruik
        End Get
        Set(ByVal value As String)
            m_DwelmMisbruik = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property KnockVirKnock() As String
        Get
            Return m_KnockVirKnock
        End Get
        Set(ByVal value As String)
            m_KnockVirKnock = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Hondgebyt() As String
        Get
            Return m_Hondgebyt
        End Get
        Set(ByVal value As String)
            m_Hondgebyt = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property Aggressief() As String
        Get
            Return m_Aggressief
        End Get
        Set(ByVal value As String)
            m_Aggressief = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property WerfUitgaan() As String
        Get
            Return m_WerfUitgaan
        End Get
        Set(ByVal value As String)
            m_WerfUitgaan = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property WatHetGebeur() As String
        Get
            Return m_WatHetGebeur
        End Get
        Set(ByVal value As String)
            m_WatHetGebeur = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Waargekry() As String
        Get
            Return m_Waargekry
        End Get
        Set(ByVal value As String)
            m_Waargekry = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property fkClaimSubstatus() As Integer
        Get
            Return m_fkClaimSubstatus
        End Get
        Set(ByVal value As Integer)
            m_fkClaimSubstatus = value
        End Set
    End Property


    <DataObjectField(False, False, False)> _
    Public Property EisSubStatusKode() As String
        Get
            Return m_EisSubStatusKode
        End Get
        Set(ByVal value As String)
            m_EisSubStatusKode = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property ExGratia() As String
        Get
            Return m_ExGratia
        End Get
        Set(ByVal value As String)
            m_ExGratia = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property RegsSoortEis() As String
        Get
            Return m_RegsSoortEis
        End Get
        Set(ByVal value As String)
            m_RegsSoortEis = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Hondgedrag() As String
        Get
            Return m_Hondgedrag
        End Get
        Set(ByVal value As String)
            m_Hondgedrag = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property ItemWaarde() As Decimal
        Get
            Return m_ItemWaarde
        End Get
        Set(ByVal value As Decimal)
            m_ItemWaarde = String.Format("{0:N2}", value)
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property Afgeskryf() As String
        Get
            Return m_Afgeskryf
        End Get
        Set(ByVal value As String)
            m_Afgeskryf = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property KatastrofeJN() As String
        Get
            Return m_KatastrofeJN
        End Get
        Set(ByVal value As String)
            m_KatastrofeJN = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property KatastrofeNaam() As String
        Get
            Return m_KatastrofeNaam
        End Get
        Set(ByVal value As String)
            m_KatastrofeNaam = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property KatastrofeDatum() As Date
        Get
            Return m_KatastrofeDatum
        End Get
        Set(ByVal value As Date)
            m_KatastrofeDatum = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property KatastrofeBybetalingsBedrag() As Decimal
        Get
            Return m_KatastrofeBybetalingsBedrag
        End Get
        Set(ByVal value As Decimal)
            m_KatastrofeBybetalingsBedrag = String.Format("{0:N2}", value)
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property fkItem() As Integer
        Get
            Return m_fkItem
        End Get
        Set(ByVal value As Integer)
            m_fkItem = value
        End Set
    End Property


    <DataObjectField(False, False, False)> _
    Public Property KatastrofeTipe() As String
        Get
            Return m_KatastrofeTipe
        End Get
        Set(ByVal value As String)
            m_KatastrofeTipe = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property fkVersekeraar() As Integer
        Get
            Return m_fkVersekeraar
        End Get
        Set(ByVal value As Integer)
            m_fkVersekeraar = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property fkUma() As Integer
        Get
            Return m_fkUma
        End Get
        Set(ByVal value As Integer)
            m_fkUma = value
        End Set
    End Property

    <DataObjectField(False, False, False)> _
    Public Property fkMakelaar() As Integer
        Get
            Return m_fkMakelaar
        End Get
        Set(ByVal value As Integer)
            m_fkMakelaar = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property ClaimStatusAfr() As String
        Get
            Return m_ClaimStatusAfr
        End Get
        Set(ByVal value As String)
            m_ClaimStatusAfr = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property ClaimStatusEng() As String
        Get
            Return m_ClaimStatusEng
        End Get
        Set(ByVal value As String)
            m_ClaimStatusEng = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property ClaimSubStatusAfr() As String
        Get
            Return m_ClaimSubStatusAfr
        End Get
        Set(ByVal value As String)
            m_ClaimSubStatusAfr = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property ClaimSubStatusEng() As String
        Get
            Return m_ClaimSubStatusEng
        End Get
        Set(ByVal value As String)
            m_ClaimSubStatusEng = value
        End Set
    End Property
End Class
