Module GlobalModule
    Public Persoonl As PERSOONLEntity 'Andriette regoor die hele stelsel uit Poldata1
    Public rsAddPremie As New AdditionalPremieEntity 'Andriette addisionelePremie
    Public rs1 As PERSOONLEntity ' Andriette baseform, frmkommissie
    Public Gebruiker As GebruikersEntity 'Andriette Addisionelepremie, Baseform, ens
    Public Area As AreaEntity = New AreaEntity
    Public rsAreaVerseke As New VersekeraarEntity
    Public Aftrek As AftrekEntity
    Public intMotorvenster As Decimal
    Public ssql As New Print2DatEntity
    Public entLangtermynpolis As LangtermynPolis
    Public voertuie As New VoertuieEntity
    Public rsPrint2 As New Print2DatEntity
    Public rsProperty As HuisEntity
    Public rs1PropertyForPrint As New Print2DatEntity
    Public glbPolicyNumber As String
    Public fetchHuisForGeyser As New HuisEntity
    Public FetchEndosidentifikasie As New Endos2001Entity
    Public rsVoertuie As New VoertuieEntity
    Public rsPrintVoertuie As New md_Print_Dat
    Public rsAreaBrief As New AreaEntity
    Public huis As HuisEntity
    Public rsMakelaarSql As New EntityMakeLaar
    Public rsArea As AreaByPersoonlEntity
    Public rsTak11 As TakEntity
    Public k_gegenereer As KontantGegenereerEntity
    Public e_kontant As EISE_KONTANT_Entity
    Public m_kontant As M_KontantEntity
    Public ktant As New List(Of KontantEntity)
    Public motor As New MontorEntity
    Public m_salarie As Maand_Puk_For_SalariesEntity
    Public m_elektronies As MaandElectronies
    Public listSekuriteit As List(Of SekuriteitEntity)
    Public rsreport As LangtermynPolis
    Public vt_balans As maand_vt_balansEntity
    Public PrimaryKeyVoertuie As VoertuieEntity
    Public vt_details As VTDetailsEntity
    Public m_salaris1 As List(Of Maand_SalariesEntity)
    Public m_salaris2 As List(Of Maand_SalariesEntity)
    Public m_salaris As List(Of Maand_SalariesEntity)
    Public m_salaris3 As Maand_Puk_For_SalariesEntity
    Public listVoertuig As List(Of ListVoertuieByPolisnoEntity)
    Public Bybetalings As BybetalingsEntity
    Public Constants As ConstantsEntity
    Public LongTermPolicy As LangtermynPolis
    Public rsHUis As HuisEntity
    Public huis_e As HuisEntity = New HuisEntity
    Public geyser As GeyserEntity = New GeyserEntity
    Public alle_risiko As New ALLERISKEntity
    Public Alle_tipe2 As Alle_Tipe2Entity = New Alle_Tipe2Entity
    Public voertuieEkstras As VoertuieEkstrasEnity = New VoertuieEkstrasEnity
    Public verwysdesAsluitings As VerwysdesAfsluitingsEntity = New VerwysdesAfsluitingsEntity
    Public entV_area As AreaEntity = New AreaEntity
    Public entV_versekeraar As VersekeraarEntity = New VersekeraarEntity

    Public pkHuis
    Public jaar_van_n
    Public jaar_tot_n
    Public maand_van_n
    Public maand_tot_n
    Public blnNieOpdateer As Boolean
    Public tv_koste As Single
    Public Password As String
    Public LTPJN
    Public getStatus As String
    Public Tak_afk As String
    Public sleutels As Object
    Public pkVoertuieEkstra As Integer
    Public huisvolgitem
    Public dblsubpremievoor As Double
    Public pol_path As String
    Public intGlbPreviousAreaCode As Integer
    Public blnediting As Boolean
    Public intPoldataGrid_Focus As Integer
    Public strreg_uc As String
    Public blnHuisvoegby As Boolean
    Public strKategorieVerander As String
    Public Ander_K As String
    Public dblglbPakketItem1Premie As Double
    Public dblglbPakketItem2Premie As Double
    Public arrglbUserBranchCodes(200)
    Public pkVoertuie As Integer
    Public pwdEntered As String
    Public pkGeysers As Long
    Public alleriskvolgitem
    Public polisfooi_ini As String
    Public strgewsert As String
    Public strBladsytwee As String
    Public strGewvirwie As String
    Public pkVerwysdes As Single
    Public strPolvankontant As String
    Public blnByvoeg As Boolean
    Public intRefreshpol As Integer
    Public blnDruk As Boolean
    Public dteTermdateStart As Date
    Public dteTermdateEnd As Date
    Public strTermMonthCount As String
    Public strTermStatus As String
    Public strTermDesc As String
    Public strTermStatusDesc As String
    Public strglbReportPath As String
    'Linkie 05/08/2013 - maak global
    Public glbVersekeraar As Integer
    Public intPKInsurer As Integer
    Public strInsured As String
    Public strDisFile As String
    Public glbMaxAfsluitDatMaand As Date
    Public strDescriptionVehicle As String
    Public dblAmountDueVerifyDek As Decimal
    Public dblAmountPaidVerifyDek As Decimal
    Public strUitgeloopJN As String
    Public strOor2MaandeUitgeloopJN As String
    Public dblTelOor2MaandeUitgeloopJN As Decimal
    Public dblTelUitgeloopJN As Decimal
    Public strVertoonEarnedJN As String
    Public blnIsBetaalJN As Boolean
    Public blnVertoonMsg As Boolean
    Public blnPolisInEersteMaand As Boolean
    Public blnInEeersteMaand As Boolean
    Public strVoertuieKode As String
    Public strVoertuieJaar As String
    Public strVoertuieMaak As String
    Public strVoertuieBesk As String
    Public strVoertuieTipe As String
    Public strVoertuieEeu As String
    Public strVoertuieCC As String
    Public strVoertuieCylinder As String
    Public strVoertuieBeginDatum As String
    Public strVoertuieEindDatum As String
    Public strVoertuieInruil As String
    Public strVoertuieKoop As String
    Public strVoertuieNuut As String
    Public arrUitgeloop(500), arrUitgeloopOor2Maande(500)
    Public strTak_afkorting As String
    Public strCLRSArea As String
    Public sngSalesPerson As Single
    Public dteMaxBetaalDateAllowed As Date
    Public bankName As String
    Public branchName As String
    Public branchCode As String
    Public accType As String
    Public bankSelected As String
    Public branchSelected As String
    Public brancCodeSelected As String
    Public glbEisno As String
    Public intpkIncome As Integer
    Public intpkPayments As Integer
    Public blnClaimPaymentBeneficiary As Boolean
    Public intpkJoernale As Integer
    Public intfkAssessor As Integer
    Public blnfkAssessor As Boolean
    Public strAssessorName As String
    Public blnAssessorClaim As Boolean
    Public intpkClassItem As Integer
    Public dblClassCover As Decimal
    Public strClassType As String
    Public strClaimItemDescription As String
    Public intfkMakelaar As Integer
    Public dteInsuredStartDate As Date
    Public strSekuritTitel As String ' andriette vir Linkie 
    Public strMsg2 As String
    Public strMsg As String
    Public intpkBegunstigde As Integer

    '  Public Ander_M As Integer
    ' Public Wysig As WysigEntity
    'Public Tak As TakEntity
    '  Public soekdatum As Object
    ' Public AddPremie As New AdditionalPremieEntity
    ' Public Versekeraar As VersekeraarEntity
    ' Public huisPremie As New HuisEntity
    'Andriette 22/01/2014 vervang die entity
    'Public voertuiePremie As New EntityVoertuie
    ' Public VoertuiePremie As New VoertuieEntity
    ' Public AllerisikoPremie As New ALLERISKEntity
    ' Public EndosDetailsEntity As EndosDetailsEntity
    ' Public rsPropertyType As New PropertyTypeEntity
    'Public md_print_dat As New md_Print_Dat
    ' Public Memolists As MemoEntity
    '  Public BankCodes As BankCodes
    'Public rsAr As ALLERISKEntity
    'Public pkVoertuie As New VoertuieEntity
    'Public rsmainProperty As HuisEntity
    ' Public rs2Property As New HuisEntity
    'Andriette 22/01/2014 vervang die entity
    'Public rsVoertuie As New EntityVoertuie
    'Public rsVoertuieForPrint2 As EntityVoertuie
    'Public rsVoertuieForPrint3 As New EntityVoertuie
    'Public rsVoertuieForPrint2 As New VoertuieEntity
    ' Public rsVoertuieForPrint3 As New VoertuieEntity
    'Public rs2 As InCellDetailsEntity
    ' Public PropertyType As PropertyTypeEntity = New PropertyTypeEntity
    ' Public rs As New VoertuieEntity
    ' Public FetchPersoonlForLoadMainform As PERSOONLEntity
    ' Public cell As Cellphone 'Andriette 07/08/2013 konsolideer 2 selfoon entities in een
    ' Public Kwitansie_nr As KwitansieEntity
    ' Public tak_hof As AreaEntity
    '  Public m_PukForSalaries As Maand_Puk_For_SalariesEntity
    '  Public m_GtbnForSalaries As Maand_gtbnForSalaries
    '  Public m_OuvsForSalaries As Maand_OuvsForSalaries
    ' Public motor_kwot As New MontorEntity
    ' Public arnp
    '  Public blnNp As Boolean
    ' Public blnAlleRisikoDekking As Boolean
    '   Public apremie 'andriette 13/08/2014 uitgehaal want dit word nerens gebruik nie
    '  Public m_debiet As MaandEntity
    ' Public listPersoonl As List(Of PERSOONLEntity)
    '  Public listArea As List(Of AreaEntity)
    '  Public listVersekeraar As List(Of VersekeraarEntity)
    ' Public listGebruiker As List(Of GebruikersEntity)
    ' Public glbUserBranchCodes As String
    '  Public Mdprint2dat As Print2DatEntity
    ' Public MDprintdat As md_Print_Dat
    'Public listHuis As List(Of HuisEntity)
    ' Public glbSkakelJKomTP As Boolean 'Are you busy converting a JK policy to a Term policy?
    '  Public listPoskode As List(Of PoskodeEntity)
    ' Public subpremie As Decimal
    '   Public f1subtotaal As Decimal
    ' Public f1eispers As Decimal
    ' Public txtStatusOld As String
    ' Public rs3 As VerwysdesEntity
    ' Public dteTermDateEnd As Date
    ' Public pkVoertuieEkstras As Long
    'Public EndmeestEntity As EndmeestEntity

    '  Public glbHomeAssistanceTel As String
    ' Public glbHomeAssistanceDesc As String
    'Linkie 31/07/2013 - sit global item in
    ' Public m_jaar
    'Public HB As Object
    ' Public Ry As Short
    ' Public HE As Object
    'Public Declare Function SetLocaleInfo Lib "kernel32" _
    ' Alias "SetLocaleInfoA" (ByVal Locale As Long, _
    ' ByVal LCType As Long, ByVal lpLCData As String) As Long

    ' Public Const LOCALE_SYSTEM_DEFAULT = 0
    ' Public Const LOCALE_SSHORTDATE = &H1F

    'Public nepc
    ' Public Selnommer As String
    ' Public intbetaaldatum As Integer
    '  Public cmbPropertyType
    ' Public cmbHomeLoanOrg
    ' Public dag
    ' Public dage
    ' Public canc As Integer
    ' Public sasria_ini As String ' kontant vorm
    ' Public h_sasria_ini As String ' kontant vorm
    '  Public verskil As Single
    ' Public Exe_path As String ' kontant vorm
    ' Public epospath As Object ' kontant vorm
    '  Public nmotorsasria 'kontant vorm
    'Public earlybird As Single
    'Public ntoebehore As Single
    'Public nkorting As Object
    'Public medies As MediesEntity = New MediesEntity
    'Public Eistipekode As Integer
    ' Public lngPkItem As Integer
    Public Enum enumCheckType
        PolicyCancelled = 0
        ItemRemoved = 1
    End Enum
    Public Enum enumItemType
        enum_Vehicle = 0
        enum_Property = 1
    End Enum
End Module
