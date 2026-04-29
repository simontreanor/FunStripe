namespace FunStripe.StripeRequest

open FunStripe
open FunStripe.Json
open FunStripe.StripeModel
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module ReportingReportRuns =

    type ListOptions = {
        [<Config.Query>]Created: int option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of Report Runs, with the most recent appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/reporting/report_runs"
        |> RestApi.getAsync<ReportingReportRun list> settings qs

    type Create'ParametersReportingCategory =
    | Advance
    | AdvanceFunding
    | AnticipationRepayment
    | Charge
    | ChargeFailure
    | ConnectCollectionTransfer
    | ConnectReservedFunds
    | Contribution
    | Dispute
    | DisputeReversal
    | Fee
    | FinancingPaydown
    | FinancingPaydownReversal
    | FinancingPayout
    | FinancingPayoutReversal
    | IssuingAuthorizationHold
    | IssuingAuthorizationRelease
    | IssuingDispute
    | IssuingTransaction
    | NetworkCost
    | OtherAdjustment
    | PartialCaptureReversal
    | Payout
    | PayoutReversal
    | PlatformEarning
    | PlatformEarningRefund
    | Refund
    | RefundFailure
    | RiskReservedFunds
    | Tax
    | Topup
    | TopupReversal
    | Transfer
    | TransferReversal

    type Create'ParametersTimezone =
    | [<JsonUnionCase("Africa/Abidjan")>] AfricaAbidjan
    | [<JsonUnionCase("Africa/Accra")>] AfricaAccra
    | [<JsonUnionCase("Africa/Addis_Ababa")>] AfricaAddisAbaba
    | [<JsonUnionCase("Africa/Algiers")>] AfricaAlgiers
    | [<JsonUnionCase("Africa/Asmara")>] AfricaAsmara
    | [<JsonUnionCase("Africa/Asmera")>] AfricaAsmera
    | [<JsonUnionCase("Africa/Bamako")>] AfricaBamako
    | [<JsonUnionCase("Africa/Bangui")>] AfricaBangui
    | [<JsonUnionCase("Africa/Banjul")>] AfricaBanjul
    | [<JsonUnionCase("Africa/Bissau")>] AfricaBissau
    | [<JsonUnionCase("Africa/Blantyre")>] AfricaBlantyre
    | [<JsonUnionCase("Africa/Brazzaville")>] AfricaBrazzaville
    | [<JsonUnionCase("Africa/Bujumbura")>] AfricaBujumbura
    | [<JsonUnionCase("Africa/Cairo")>] AfricaCairo
    | [<JsonUnionCase("Africa/Casablanca")>] AfricaCasablanca
    | [<JsonUnionCase("Africa/Ceuta")>] AfricaCeuta
    | [<JsonUnionCase("Africa/Conakry")>] AfricaConakry
    | [<JsonUnionCase("Africa/Dakar")>] AfricaDakar
    | [<JsonUnionCase("Africa/Dar_es_Salaam")>] AfricaDarEsSalaam
    | [<JsonUnionCase("Africa/Djibouti")>] AfricaDjibouti
    | [<JsonUnionCase("Africa/Douala")>] AfricaDouala
    | [<JsonUnionCase("Africa/El_Aaiun")>] AfricaElAaiun
    | [<JsonUnionCase("Africa/Freetown")>] AfricaFreetown
    | [<JsonUnionCase("Africa/Gaborone")>] AfricaGaborone
    | [<JsonUnionCase("Africa/Harare")>] AfricaHarare
    | [<JsonUnionCase("Africa/Johannesburg")>] AfricaJohannesburg
    | [<JsonUnionCase("Africa/Juba")>] AfricaJuba
    | [<JsonUnionCase("Africa/Kampala")>] AfricaKampala
    | [<JsonUnionCase("Africa/Khartoum")>] AfricaKhartoum
    | [<JsonUnionCase("Africa/Kigali")>] AfricaKigali
    | [<JsonUnionCase("Africa/Kinshasa")>] AfricaKinshasa
    | [<JsonUnionCase("Africa/Lagos")>] AfricaLagos
    | [<JsonUnionCase("Africa/Libreville")>] AfricaLibreville
    | [<JsonUnionCase("Africa/Lome")>] AfricaLome
    | [<JsonUnionCase("Africa/Luanda")>] AfricaLuanda
    | [<JsonUnionCase("Africa/Lubumbashi")>] AfricaLubumbashi
    | [<JsonUnionCase("Africa/Lusaka")>] AfricaLusaka
    | [<JsonUnionCase("Africa/Malabo")>] AfricaMalabo
    | [<JsonUnionCase("Africa/Maputo")>] AfricaMaputo
    | [<JsonUnionCase("Africa/Maseru")>] AfricaMaseru
    | [<JsonUnionCase("Africa/Mbabane")>] AfricaMbabane
    | [<JsonUnionCase("Africa/Mogadishu")>] AfricaMogadishu
    | [<JsonUnionCase("Africa/Monrovia")>] AfricaMonrovia
    | [<JsonUnionCase("Africa/Nairobi")>] AfricaNairobi
    | [<JsonUnionCase("Africa/Ndjamena")>] AfricaNdjamena
    | [<JsonUnionCase("Africa/Niamey")>] AfricaNiamey
    | [<JsonUnionCase("Africa/Nouakchott")>] AfricaNouakchott
    | [<JsonUnionCase("Africa/Ouagadougou")>] AfricaOuagadougou
    | [<JsonUnionCase("Africa/Porto-Novo")>] AfricaPortoNovo
    | [<JsonUnionCase("Africa/Sao_Tome")>] AfricaSaoTome
    | [<JsonUnionCase("Africa/Timbuktu")>] AfricaTimbuktu
    | [<JsonUnionCase("Africa/Tripoli")>] AfricaTripoli
    | [<JsonUnionCase("Africa/Tunis")>] AfricaTunis
    | [<JsonUnionCase("Africa/Windhoek")>] AfricaWindhoek
    | [<JsonUnionCase("America/Adak")>] AmericaAdak
    | [<JsonUnionCase("America/Anchorage")>] AmericaAnchorage
    | [<JsonUnionCase("America/Anguilla")>] AmericaAnguilla
    | [<JsonUnionCase("America/Antigua")>] AmericaAntigua
    | [<JsonUnionCase("America/Araguaina")>] AmericaAraguaina
    | [<JsonUnionCase("America/Argentina/Buenos_Aires")>] AmericaArgentinaBuenosAires
    | [<JsonUnionCase("America/Argentina/Catamarca")>] AmericaArgentinaCatamarca
    | [<JsonUnionCase("America/Argentina/ComodRivadavia")>] AmericaArgentinaComodRivadavia
    | [<JsonUnionCase("America/Argentina/Cordoba")>] AmericaArgentinaCordoba
    | [<JsonUnionCase("America/Argentina/Jujuy")>] AmericaArgentinaJujuy
    | [<JsonUnionCase("America/Argentina/La_Rioja")>] AmericaArgentinaLaRioja
    | [<JsonUnionCase("America/Argentina/Mendoza")>] AmericaArgentinaMendoza
    | [<JsonUnionCase("America/Argentina/Rio_Gallegos")>] AmericaArgentinaRioGallegos
    | [<JsonUnionCase("America/Argentina/Salta")>] AmericaArgentinaSalta
    | [<JsonUnionCase("America/Argentina/San_Juan")>] AmericaArgentinaSanJuan
    | [<JsonUnionCase("America/Argentina/San_Luis")>] AmericaArgentinaSanLuis
    | [<JsonUnionCase("America/Argentina/Tucuman")>] AmericaArgentinaTucuman
    | [<JsonUnionCase("America/Argentina/Ushuaia")>] AmericaArgentinaUshuaia
    | [<JsonUnionCase("America/Aruba")>] AmericaAruba
    | [<JsonUnionCase("America/Asuncion")>] AmericaAsuncion
    | [<JsonUnionCase("America/Atikokan")>] AmericaAtikokan
    | [<JsonUnionCase("America/Atka")>] AmericaAtka
    | [<JsonUnionCase("America/Bahia")>] AmericaBahia
    | [<JsonUnionCase("America/Bahia_Banderas")>] AmericaBahiaBanderas
    | [<JsonUnionCase("America/Barbados")>] AmericaBarbados
    | [<JsonUnionCase("America/Belem")>] AmericaBelem
    | [<JsonUnionCase("America/Belize")>] AmericaBelize
    | [<JsonUnionCase("America/Blanc-Sablon")>] AmericaBlancSablon
    | [<JsonUnionCase("America/Boa_Vista")>] AmericaBoaVista
    | [<JsonUnionCase("America/Bogota")>] AmericaBogota
    | [<JsonUnionCase("America/Boise")>] AmericaBoise
    | [<JsonUnionCase("America/Buenos_Aires")>] AmericaBuenosAires
    | [<JsonUnionCase("America/Cambridge_Bay")>] AmericaCambridgeBay
    | [<JsonUnionCase("America/Campo_Grande")>] AmericaCampoGrande
    | [<JsonUnionCase("America/Cancun")>] AmericaCancun
    | [<JsonUnionCase("America/Caracas")>] AmericaCaracas
    | [<JsonUnionCase("America/Catamarca")>] AmericaCatamarca
    | [<JsonUnionCase("America/Cayenne")>] AmericaCayenne
    | [<JsonUnionCase("America/Cayman")>] AmericaCayman
    | [<JsonUnionCase("America/Chicago")>] AmericaChicago
    | [<JsonUnionCase("America/Chihuahua")>] AmericaChihuahua
    | [<JsonUnionCase("America/Ciudad_Juarez")>] AmericaCiudadJuarez
    | [<JsonUnionCase("America/Coral_Harbour")>] AmericaCoralHarbour
    | [<JsonUnionCase("America/Cordoba")>] AmericaCordoba
    | [<JsonUnionCase("America/Costa_Rica")>] AmericaCostaRica
    | [<JsonUnionCase("America/Creston")>] AmericaCreston
    | [<JsonUnionCase("America/Cuiaba")>] AmericaCuiaba
    | [<JsonUnionCase("America/Curacao")>] AmericaCuracao
    | [<JsonUnionCase("America/Danmarkshavn")>] AmericaDanmarkshavn
    | [<JsonUnionCase("America/Dawson")>] AmericaDawson
    | [<JsonUnionCase("America/Dawson_Creek")>] AmericaDawsonCreek
    | [<JsonUnionCase("America/Denver")>] AmericaDenver
    | [<JsonUnionCase("America/Detroit")>] AmericaDetroit
    | [<JsonUnionCase("America/Dominica")>] AmericaDominica
    | [<JsonUnionCase("America/Edmonton")>] AmericaEdmonton
    | [<JsonUnionCase("America/Eirunepe")>] AmericaEirunepe
    | [<JsonUnionCase("America/El_Salvador")>] AmericaElSalvador
    | [<JsonUnionCase("America/Ensenada")>] AmericaEnsenada
    | [<JsonUnionCase("America/Fort_Nelson")>] AmericaFortNelson
    | [<JsonUnionCase("America/Fort_Wayne")>] AmericaFortWayne
    | [<JsonUnionCase("America/Fortaleza")>] AmericaFortaleza
    | [<JsonUnionCase("America/Glace_Bay")>] AmericaGlaceBay
    | [<JsonUnionCase("America/Godthab")>] AmericaGodthab
    | [<JsonUnionCase("America/Goose_Bay")>] AmericaGooseBay
    | [<JsonUnionCase("America/Grand_Turk")>] AmericaGrandTurk
    | [<JsonUnionCase("America/Grenada")>] AmericaGrenada
    | [<JsonUnionCase("America/Guadeloupe")>] AmericaGuadeloupe
    | [<JsonUnionCase("America/Guatemala")>] AmericaGuatemala
    | [<JsonUnionCase("America/Guayaquil")>] AmericaGuayaquil
    | [<JsonUnionCase("America/Guyana")>] AmericaGuyana
    | [<JsonUnionCase("America/Halifax")>] AmericaHalifax
    | [<JsonUnionCase("America/Havana")>] AmericaHavana
    | [<JsonUnionCase("America/Hermosillo")>] AmericaHermosillo
    | [<JsonUnionCase("America/Indiana/Indianapolis")>] AmericaIndianaIndianapolis
    | [<JsonUnionCase("America/Indiana/Knox")>] AmericaIndianaKnox
    | [<JsonUnionCase("America/Indiana/Marengo")>] AmericaIndianaMarengo
    | [<JsonUnionCase("America/Indiana/Petersburg")>] AmericaIndianaPetersburg
    | [<JsonUnionCase("America/Indiana/Tell_City")>] AmericaIndianaTellCity
    | [<JsonUnionCase("America/Indiana/Vevay")>] AmericaIndianaVevay
    | [<JsonUnionCase("America/Indiana/Vincennes")>] AmericaIndianaVincennes
    | [<JsonUnionCase("America/Indiana/Winamac")>] AmericaIndianaWinamac
    | [<JsonUnionCase("America/Indianapolis")>] AmericaIndianapolis
    | [<JsonUnionCase("America/Inuvik")>] AmericaInuvik
    | [<JsonUnionCase("America/Iqaluit")>] AmericaIqaluit
    | [<JsonUnionCase("America/Jamaica")>] AmericaJamaica
    | [<JsonUnionCase("America/Jujuy")>] AmericaJujuy
    | [<JsonUnionCase("America/Juneau")>] AmericaJuneau
    | [<JsonUnionCase("America/Kentucky/Louisville")>] AmericaKentuckyLouisville
    | [<JsonUnionCase("America/Kentucky/Monticello")>] AmericaKentuckyMonticello
    | [<JsonUnionCase("America/Knox_IN")>] AmericaKnoxIN
    | [<JsonUnionCase("America/Kralendijk")>] AmericaKralendijk
    | [<JsonUnionCase("America/La_Paz")>] AmericaLaPaz
    | [<JsonUnionCase("America/Lima")>] AmericaLima
    | [<JsonUnionCase("America/Los_Angeles")>] AmericaLosAngeles
    | [<JsonUnionCase("America/Louisville")>] AmericaLouisville
    | [<JsonUnionCase("America/Lower_Princes")>] AmericaLowerPrinces
    | [<JsonUnionCase("America/Maceio")>] AmericaMaceio
    | [<JsonUnionCase("America/Managua")>] AmericaManagua
    | [<JsonUnionCase("America/Manaus")>] AmericaManaus
    | [<JsonUnionCase("America/Marigot")>] AmericaMarigot
    | [<JsonUnionCase("America/Martinique")>] AmericaMartinique
    | [<JsonUnionCase("America/Matamoros")>] AmericaMatamoros
    | [<JsonUnionCase("America/Mazatlan")>] AmericaMazatlan
    | [<JsonUnionCase("America/Mendoza")>] AmericaMendoza
    | [<JsonUnionCase("America/Menominee")>] AmericaMenominee
    | [<JsonUnionCase("America/Merida")>] AmericaMerida
    | [<JsonUnionCase("America/Metlakatla")>] AmericaMetlakatla
    | [<JsonUnionCase("America/Mexico_City")>] AmericaMexicoCity
    | [<JsonUnionCase("America/Miquelon")>] AmericaMiquelon
    | [<JsonUnionCase("America/Moncton")>] AmericaMoncton
    | [<JsonUnionCase("America/Monterrey")>] AmericaMonterrey
    | [<JsonUnionCase("America/Montevideo")>] AmericaMontevideo
    | [<JsonUnionCase("America/Montreal")>] AmericaMontreal
    | [<JsonUnionCase("America/Montserrat")>] AmericaMontserrat
    | [<JsonUnionCase("America/Nassau")>] AmericaNassau
    | [<JsonUnionCase("America/New_York")>] AmericaNewYork
    | [<JsonUnionCase("America/Nipigon")>] AmericaNipigon
    | [<JsonUnionCase("America/Nome")>] AmericaNome
    | [<JsonUnionCase("America/Noronha")>] AmericaNoronha
    | [<JsonUnionCase("America/North_Dakota/Beulah")>] AmericaNorthDakotaBeulah
    | [<JsonUnionCase("America/North_Dakota/Center")>] AmericaNorthDakotaCenter
    | [<JsonUnionCase("America/North_Dakota/New_Salem")>] AmericaNorthDakotaNewSalem
    | [<JsonUnionCase("America/Nuuk")>] AmericaNuuk
    | [<JsonUnionCase("America/Ojinaga")>] AmericaOjinaga
    | [<JsonUnionCase("America/Panama")>] AmericaPanama
    | [<JsonUnionCase("America/Pangnirtung")>] AmericaPangnirtung
    | [<JsonUnionCase("America/Paramaribo")>] AmericaParamaribo
    | [<JsonUnionCase("America/Phoenix")>] AmericaPhoenix
    | [<JsonUnionCase("America/Port-au-Prince")>] AmericaPortauPrince
    | [<JsonUnionCase("America/Port_of_Spain")>] AmericaPortOfSpain
    | [<JsonUnionCase("America/Porto_Acre")>] AmericaPortoAcre
    | [<JsonUnionCase("America/Porto_Velho")>] AmericaPortoVelho
    | [<JsonUnionCase("America/Puerto_Rico")>] AmericaPuertoRico
    | [<JsonUnionCase("America/Punta_Arenas")>] AmericaPuntaArenas
    | [<JsonUnionCase("America/Rainy_River")>] AmericaRainyRiver
    | [<JsonUnionCase("America/Rankin_Inlet")>] AmericaRankinInlet
    | [<JsonUnionCase("America/Recife")>] AmericaRecife
    | [<JsonUnionCase("America/Regina")>] AmericaRegina
    | [<JsonUnionCase("America/Resolute")>] AmericaResolute
    | [<JsonUnionCase("America/Rio_Branco")>] AmericaRioBranco
    | [<JsonUnionCase("America/Rosario")>] AmericaRosario
    | [<JsonUnionCase("America/Santa_Isabel")>] AmericaSantaIsabel
    | [<JsonUnionCase("America/Santarem")>] AmericaSantarem
    | [<JsonUnionCase("America/Santiago")>] AmericaSantiago
    | [<JsonUnionCase("America/Santo_Domingo")>] AmericaSantoDomingo
    | [<JsonUnionCase("America/Sao_Paulo")>] AmericaSaoPaulo
    | [<JsonUnionCase("America/Scoresbysund")>] AmericaScoresbysund
    | [<JsonUnionCase("America/Shiprock")>] AmericaShiprock
    | [<JsonUnionCase("America/Sitka")>] AmericaSitka
    | [<JsonUnionCase("America/St_Barthelemy")>] AmericaStBarthelemy
    | [<JsonUnionCase("America/St_Johns")>] AmericaStJohns
    | [<JsonUnionCase("America/St_Kitts")>] AmericaStKitts
    | [<JsonUnionCase("America/St_Lucia")>] AmericaStLucia
    | [<JsonUnionCase("America/St_Thomas")>] AmericaStThomas
    | [<JsonUnionCase("America/St_Vincent")>] AmericaStVincent
    | [<JsonUnionCase("America/Swift_Current")>] AmericaSwiftCurrent
    | [<JsonUnionCase("America/Tegucigalpa")>] AmericaTegucigalpa
    | [<JsonUnionCase("America/Thule")>] AmericaThule
    | [<JsonUnionCase("America/Thunder_Bay")>] AmericaThunderBay
    | [<JsonUnionCase("America/Tijuana")>] AmericaTijuana
    | [<JsonUnionCase("America/Toronto")>] AmericaToronto
    | [<JsonUnionCase("America/Tortola")>] AmericaTortola
    | [<JsonUnionCase("America/Vancouver")>] AmericaVancouver
    | [<JsonUnionCase("America/Virgin")>] AmericaVirgin
    | [<JsonUnionCase("America/Whitehorse")>] AmericaWhitehorse
    | [<JsonUnionCase("America/Winnipeg")>] AmericaWinnipeg
    | [<JsonUnionCase("America/Yakutat")>] AmericaYakutat
    | [<JsonUnionCase("America/Yellowknife")>] AmericaYellowknife
    | [<JsonUnionCase("Antarctica/Casey")>] AntarcticaCasey
    | [<JsonUnionCase("Antarctica/Davis")>] AntarcticaDavis
    | [<JsonUnionCase("Antarctica/DumontDUrville")>] AntarcticaDumontDUrville
    | [<JsonUnionCase("Antarctica/Macquarie")>] AntarcticaMacquarie
    | [<JsonUnionCase("Antarctica/Mawson")>] AntarcticaMawson
    | [<JsonUnionCase("Antarctica/McMurdo")>] AntarcticaMcMurdo
    | [<JsonUnionCase("Antarctica/Palmer")>] AntarcticaPalmer
    | [<JsonUnionCase("Antarctica/Rothera")>] AntarcticaRothera
    | [<JsonUnionCase("Antarctica/South_Pole")>] AntarcticaSouthPole
    | [<JsonUnionCase("Antarctica/Syowa")>] AntarcticaSyowa
    | [<JsonUnionCase("Antarctica/Troll")>] AntarcticaTroll
    | [<JsonUnionCase("Antarctica/Vostok")>] AntarcticaVostok
    | [<JsonUnionCase("Arctic/Longyearbyen")>] ArcticLongyearbyen
    | [<JsonUnionCase("Asia/Aden")>] AsiaAden
    | [<JsonUnionCase("Asia/Almaty")>] AsiaAlmaty
    | [<JsonUnionCase("Asia/Amman")>] AsiaAmman
    | [<JsonUnionCase("Asia/Anadyr")>] AsiaAnadyr
    | [<JsonUnionCase("Asia/Aqtau")>] AsiaAqtau
    | [<JsonUnionCase("Asia/Aqtobe")>] AsiaAqtobe
    | [<JsonUnionCase("Asia/Ashgabat")>] AsiaAshgabat
    | [<JsonUnionCase("Asia/Ashkhabad")>] AsiaAshkhabad
    | [<JsonUnionCase("Asia/Atyrau")>] AsiaAtyrau
    | [<JsonUnionCase("Asia/Baghdad")>] AsiaBaghdad
    | [<JsonUnionCase("Asia/Bahrain")>] AsiaBahrain
    | [<JsonUnionCase("Asia/Baku")>] AsiaBaku
    | [<JsonUnionCase("Asia/Bangkok")>] AsiaBangkok
    | [<JsonUnionCase("Asia/Barnaul")>] AsiaBarnaul
    | [<JsonUnionCase("Asia/Beirut")>] AsiaBeirut
    | [<JsonUnionCase("Asia/Bishkek")>] AsiaBishkek
    | [<JsonUnionCase("Asia/Brunei")>] AsiaBrunei
    | [<JsonUnionCase("Asia/Calcutta")>] AsiaCalcutta
    | [<JsonUnionCase("Asia/Chita")>] AsiaChita
    | [<JsonUnionCase("Asia/Choibalsan")>] AsiaChoibalsan
    | [<JsonUnionCase("Asia/Chongqing")>] AsiaChongqing
    | [<JsonUnionCase("Asia/Chungking")>] AsiaChungking
    | [<JsonUnionCase("Asia/Colombo")>] AsiaColombo
    | [<JsonUnionCase("Asia/Dacca")>] AsiaDacca
    | [<JsonUnionCase("Asia/Damascus")>] AsiaDamascus
    | [<JsonUnionCase("Asia/Dhaka")>] AsiaDhaka
    | [<JsonUnionCase("Asia/Dili")>] AsiaDili
    | [<JsonUnionCase("Asia/Dubai")>] AsiaDubai
    | [<JsonUnionCase("Asia/Dushanbe")>] AsiaDushanbe
    | [<JsonUnionCase("Asia/Famagusta")>] AsiaFamagusta
    | [<JsonUnionCase("Asia/Gaza")>] AsiaGaza
    | [<JsonUnionCase("Asia/Harbin")>] AsiaHarbin
    | [<JsonUnionCase("Asia/Hebron")>] AsiaHebron
    | [<JsonUnionCase("Asia/Ho_Chi_Minh")>] AsiaHoChiMinh
    | [<JsonUnionCase("Asia/Hong_Kong")>] AsiaHongKong
    | [<JsonUnionCase("Asia/Hovd")>] AsiaHovd
    | [<JsonUnionCase("Asia/Irkutsk")>] AsiaIrkutsk
    | [<JsonUnionCase("Asia/Istanbul")>] AsiaIstanbul
    | [<JsonUnionCase("Asia/Jakarta")>] AsiaJakarta
    | [<JsonUnionCase("Asia/Jayapura")>] AsiaJayapura
    | [<JsonUnionCase("Asia/Jerusalem")>] AsiaJerusalem
    | [<JsonUnionCase("Asia/Kabul")>] AsiaKabul
    | [<JsonUnionCase("Asia/Kamchatka")>] AsiaKamchatka
    | [<JsonUnionCase("Asia/Karachi")>] AsiaKarachi
    | [<JsonUnionCase("Asia/Kashgar")>] AsiaKashgar
    | [<JsonUnionCase("Asia/Kathmandu")>] AsiaKathmandu
    | [<JsonUnionCase("Asia/Katmandu")>] AsiaKatmandu
    | [<JsonUnionCase("Asia/Khandyga")>] AsiaKhandyga
    | [<JsonUnionCase("Asia/Kolkata")>] AsiaKolkata
    | [<JsonUnionCase("Asia/Krasnoyarsk")>] AsiaKrasnoyarsk
    | [<JsonUnionCase("Asia/Kuala_Lumpur")>] AsiaKualaLumpur
    | [<JsonUnionCase("Asia/Kuching")>] AsiaKuching
    | [<JsonUnionCase("Asia/Kuwait")>] AsiaKuwait
    | [<JsonUnionCase("Asia/Macao")>] AsiaMacao
    | [<JsonUnionCase("Asia/Macau")>] AsiaMacau
    | [<JsonUnionCase("Asia/Magadan")>] AsiaMagadan
    | [<JsonUnionCase("Asia/Makassar")>] AsiaMakassar
    | [<JsonUnionCase("Asia/Manila")>] AsiaManila
    | [<JsonUnionCase("Asia/Muscat")>] AsiaMuscat
    | [<JsonUnionCase("Asia/Nicosia")>] AsiaNicosia
    | [<JsonUnionCase("Asia/Novokuznetsk")>] AsiaNovokuznetsk
    | [<JsonUnionCase("Asia/Novosibirsk")>] AsiaNovosibirsk
    | [<JsonUnionCase("Asia/Omsk")>] AsiaOmsk
    | [<JsonUnionCase("Asia/Oral")>] AsiaOral
    | [<JsonUnionCase("Asia/Phnom_Penh")>] AsiaPhnomPenh
    | [<JsonUnionCase("Asia/Pontianak")>] AsiaPontianak
    | [<JsonUnionCase("Asia/Pyongyang")>] AsiaPyongyang
    | [<JsonUnionCase("Asia/Qatar")>] AsiaQatar
    | [<JsonUnionCase("Asia/Qostanay")>] AsiaQostanay
    | [<JsonUnionCase("Asia/Qyzylorda")>] AsiaQyzylorda
    | [<JsonUnionCase("Asia/Rangoon")>] AsiaRangoon
    | [<JsonUnionCase("Asia/Riyadh")>] AsiaRiyadh
    | [<JsonUnionCase("Asia/Saigon")>] AsiaSaigon
    | [<JsonUnionCase("Asia/Sakhalin")>] AsiaSakhalin
    | [<JsonUnionCase("Asia/Samarkand")>] AsiaSamarkand
    | [<JsonUnionCase("Asia/Seoul")>] AsiaSeoul
    | [<JsonUnionCase("Asia/Shanghai")>] AsiaShanghai
    | [<JsonUnionCase("Asia/Singapore")>] AsiaSingapore
    | [<JsonUnionCase("Asia/Srednekolymsk")>] AsiaSrednekolymsk
    | [<JsonUnionCase("Asia/Taipei")>] AsiaTaipei
    | [<JsonUnionCase("Asia/Tashkent")>] AsiaTashkent
    | [<JsonUnionCase("Asia/Tbilisi")>] AsiaTbilisi
    | [<JsonUnionCase("Asia/Tehran")>] AsiaTehran
    | [<JsonUnionCase("Asia/Tel_Aviv")>] AsiaTelAviv
    | [<JsonUnionCase("Asia/Thimbu")>] AsiaThimbu
    | [<JsonUnionCase("Asia/Thimphu")>] AsiaThimphu
    | [<JsonUnionCase("Asia/Tokyo")>] AsiaTokyo
    | [<JsonUnionCase("Asia/Tomsk")>] AsiaTomsk
    | [<JsonUnionCase("Asia/Ujung_Pandang")>] AsiaUjungPandang
    | [<JsonUnionCase("Asia/Ulaanbaatar")>] AsiaUlaanbaatar
    | [<JsonUnionCase("Asia/Ulan_Bator")>] AsiaUlanBator
    | [<JsonUnionCase("Asia/Urumqi")>] AsiaUrumqi
    | [<JsonUnionCase("Asia/Ust-Nera")>] AsiaUstNera
    | [<JsonUnionCase("Asia/Vientiane")>] AsiaVientiane
    | [<JsonUnionCase("Asia/Vladivostok")>] AsiaVladivostok
    | [<JsonUnionCase("Asia/Yakutsk")>] AsiaYakutsk
    | [<JsonUnionCase("Asia/Yangon")>] AsiaYangon
    | [<JsonUnionCase("Asia/Yekaterinburg")>] AsiaYekaterinburg
    | [<JsonUnionCase("Asia/Yerevan")>] AsiaYerevan
    | [<JsonUnionCase("Atlantic/Azores")>] AtlanticAzores
    | [<JsonUnionCase("Atlantic/Bermuda")>] AtlanticBermuda
    | [<JsonUnionCase("Atlantic/Canary")>] AtlanticCanary
    | [<JsonUnionCase("Atlantic/Cape_Verde")>] AtlanticCapeVerde
    | [<JsonUnionCase("Atlantic/Faeroe")>] AtlanticFaeroe
    | [<JsonUnionCase("Atlantic/Faroe")>] AtlanticFaroe
    | [<JsonUnionCase("Atlantic/Jan_Mayen")>] AtlanticJanMayen
    | [<JsonUnionCase("Atlantic/Madeira")>] AtlanticMadeira
    | [<JsonUnionCase("Atlantic/Reykjavik")>] AtlanticReykjavik
    | [<JsonUnionCase("Atlantic/South_Georgia")>] AtlanticSouthGeorgia
    | [<JsonUnionCase("Atlantic/St_Helena")>] AtlanticStHelena
    | [<JsonUnionCase("Atlantic/Stanley")>] AtlanticStanley
    | [<JsonUnionCase("Australia/ACT")>] AustraliaACT
    | [<JsonUnionCase("Australia/Adelaide")>] AustraliaAdelaide
    | [<JsonUnionCase("Australia/Brisbane")>] AustraliaBrisbane
    | [<JsonUnionCase("Australia/Broken_Hill")>] AustraliaBrokenHill
    | [<JsonUnionCase("Australia/Canberra")>] AustraliaCanberra
    | [<JsonUnionCase("Australia/Currie")>] AustraliaCurrie
    | [<JsonUnionCase("Australia/Darwin")>] AustraliaDarwin
    | [<JsonUnionCase("Australia/Eucla")>] AustraliaEucla
    | [<JsonUnionCase("Australia/Hobart")>] AustraliaHobart
    | [<JsonUnionCase("Australia/LHI")>] AustraliaLHI
    | [<JsonUnionCase("Australia/Lindeman")>] AustraliaLindeman
    | [<JsonUnionCase("Australia/Lord_Howe")>] AustraliaLordHowe
    | [<JsonUnionCase("Australia/Melbourne")>] AustraliaMelbourne
    | [<JsonUnionCase("Australia/NSW")>] AustraliaNSW
    | [<JsonUnionCase("Australia/North")>] AustraliaNorth
    | [<JsonUnionCase("Australia/Perth")>] AustraliaPerth
    | [<JsonUnionCase("Australia/Queensland")>] AustraliaQueensland
    | [<JsonUnionCase("Australia/South")>] AustraliaSouth
    | [<JsonUnionCase("Australia/Sydney")>] AustraliaSydney
    | [<JsonUnionCase("Australia/Tasmania")>] AustraliaTasmania
    | [<JsonUnionCase("Australia/Victoria")>] AustraliaVictoria
    | [<JsonUnionCase("Australia/West")>] AustraliaWest
    | [<JsonUnionCase("Australia/Yancowinna")>] AustraliaYancowinna
    | [<JsonUnionCase("Brazil/Acre")>] BrazilAcre
    | [<JsonUnionCase("Brazil/DeNoronha")>] BrazilDeNoronha
    | [<JsonUnionCase("Brazil/East")>] BrazilEast
    | [<JsonUnionCase("Brazil/West")>] BrazilWest
    | [<JsonUnionCase("CET")>] CET
    | [<JsonUnionCase("CST6CDT")>] CST6CDT
    | [<JsonUnionCase("Canada/Atlantic")>] CanadaAtlantic
    | [<JsonUnionCase("Canada/Central")>] CanadaCentral
    | [<JsonUnionCase("Canada/Eastern")>] CanadaEastern
    | [<JsonUnionCase("Canada/Mountain")>] CanadaMountain
    | [<JsonUnionCase("Canada/Newfoundland")>] CanadaNewfoundland
    | [<JsonUnionCase("Canada/Pacific")>] CanadaPacific
    | [<JsonUnionCase("Canada/Saskatchewan")>] CanadaSaskatchewan
    | [<JsonUnionCase("Canada/Yukon")>] CanadaYukon
    | [<JsonUnionCase("Chile/Continental")>] ChileContinental
    | [<JsonUnionCase("Chile/EasterIsland")>] ChileEasterIsland
    | [<JsonUnionCase("Cuba")>] Cuba
    | [<JsonUnionCase("EET")>] EET
    | [<JsonUnionCase("EST")>] EST
    | [<JsonUnionCase("EST5EDT")>] EST5EDT
    | [<JsonUnionCase("Egypt")>] Egypt
    | [<JsonUnionCase("Eire")>] Eire
    | [<JsonUnionCase("Etc/GMT")>] EtcGMT
    | [<JsonUnionCase("Etc/GMT+0")>] EtcGMTplus0
    | [<JsonUnionCase("Etc/GMT+1")>] EtcGMTplus1
    | [<JsonUnionCase("Etc/GMT+10")>] EtcGMTplus10
    | [<JsonUnionCase("Etc/GMT+11")>] EtcGMTplus11
    | [<JsonUnionCase("Etc/GMT+12")>] EtcGMTplus12
    | [<JsonUnionCase("Etc/GMT+2")>] EtcGMTplus2
    | [<JsonUnionCase("Etc/GMT+3")>] EtcGMTplus3
    | [<JsonUnionCase("Etc/GMT+4")>] EtcGMTplus4
    | [<JsonUnionCase("Etc/GMT+5")>] EtcGMTplus5
    | [<JsonUnionCase("Etc/GMT+6")>] EtcGMTplus6
    | [<JsonUnionCase("Etc/GMT+7")>] EtcGMTplus7
    | [<JsonUnionCase("Etc/GMT+8")>] EtcGMTplus8
    | [<JsonUnionCase("Etc/GMT+9")>] EtcGMTplus9
    | [<JsonUnionCase("Etc/GMT-0")>] EtcGMTminus0
    | [<JsonUnionCase("Etc/GMT-1")>] EtcGMTminus1
    | [<JsonUnionCase("Etc/GMT-10")>] EtcGMTminus10
    | [<JsonUnionCase("Etc/GMT-11")>] EtcGMTminus11
    | [<JsonUnionCase("Etc/GMT-12")>] EtcGMTminus12
    | [<JsonUnionCase("Etc/GMT-13")>] EtcGMTminus13
    | [<JsonUnionCase("Etc/GMT-14")>] EtcGMTminus14
    | [<JsonUnionCase("Etc/GMT-2")>] EtcGMTminus2
    | [<JsonUnionCase("Etc/GMT-3")>] EtcGMTminus3
    | [<JsonUnionCase("Etc/GMT-4")>] EtcGMTminus4
    | [<JsonUnionCase("Etc/GMT-5")>] EtcGMTminus5
    | [<JsonUnionCase("Etc/GMT-6")>] EtcGMTminus6
    | [<JsonUnionCase("Etc/GMT-7")>] EtcGMTminus7
    | [<JsonUnionCase("Etc/GMT-8")>] EtcGMTminus8
    | [<JsonUnionCase("Etc/GMT-9")>] EtcGMTminus9
    | [<JsonUnionCase("Etc/GMT0")>] EtcGMT0
    | [<JsonUnionCase("Etc/Greenwich")>] EtcGreenwich
    | [<JsonUnionCase("Etc/UCT")>] EtcUCT
    | [<JsonUnionCase("Etc/UTC")>] EtcUTC
    | [<JsonUnionCase("Etc/Universal")>] EtcUniversal
    | [<JsonUnionCase("Etc/Zulu")>] EtcZulu
    | [<JsonUnionCase("Europe/Amsterdam")>] EuropeAmsterdam
    | [<JsonUnionCase("Europe/Andorra")>] EuropeAndorra
    | [<JsonUnionCase("Europe/Astrakhan")>] EuropeAstrakhan
    | [<JsonUnionCase("Europe/Athens")>] EuropeAthens
    | [<JsonUnionCase("Europe/Belfast")>] EuropeBelfast
    | [<JsonUnionCase("Europe/Belgrade")>] EuropeBelgrade
    | [<JsonUnionCase("Europe/Berlin")>] EuropeBerlin
    | [<JsonUnionCase("Europe/Bratislava")>] EuropeBratislava
    | [<JsonUnionCase("Europe/Brussels")>] EuropeBrussels
    | [<JsonUnionCase("Europe/Bucharest")>] EuropeBucharest
    | [<JsonUnionCase("Europe/Budapest")>] EuropeBudapest
    | [<JsonUnionCase("Europe/Busingen")>] EuropeBusingen
    | [<JsonUnionCase("Europe/Chisinau")>] EuropeChisinau
    | [<JsonUnionCase("Europe/Copenhagen")>] EuropeCopenhagen
    | [<JsonUnionCase("Europe/Dublin")>] EuropeDublin
    | [<JsonUnionCase("Europe/Gibraltar")>] EuropeGibraltar
    | [<JsonUnionCase("Europe/Guernsey")>] EuropeGuernsey
    | [<JsonUnionCase("Europe/Helsinki")>] EuropeHelsinki
    | [<JsonUnionCase("Europe/Isle_of_Man")>] EuropeIsleOfMan
    | [<JsonUnionCase("Europe/Istanbul")>] EuropeIstanbul
    | [<JsonUnionCase("Europe/Jersey")>] EuropeJersey
    | [<JsonUnionCase("Europe/Kaliningrad")>] EuropeKaliningrad
    | [<JsonUnionCase("Europe/Kiev")>] EuropeKiev
    | [<JsonUnionCase("Europe/Kirov")>] EuropeKirov
    | [<JsonUnionCase("Europe/Kyiv")>] EuropeKyiv
    | [<JsonUnionCase("Europe/Lisbon")>] EuropeLisbon
    | [<JsonUnionCase("Europe/Ljubljana")>] EuropeLjubljana
    | [<JsonUnionCase("Europe/London")>] EuropeLondon
    | [<JsonUnionCase("Europe/Luxembourg")>] EuropeLuxembourg
    | [<JsonUnionCase("Europe/Madrid")>] EuropeMadrid
    | [<JsonUnionCase("Europe/Malta")>] EuropeMalta
    | [<JsonUnionCase("Europe/Mariehamn")>] EuropeMariehamn
    | [<JsonUnionCase("Europe/Minsk")>] EuropeMinsk
    | [<JsonUnionCase("Europe/Monaco")>] EuropeMonaco
    | [<JsonUnionCase("Europe/Moscow")>] EuropeMoscow
    | [<JsonUnionCase("Europe/Nicosia")>] EuropeNicosia
    | [<JsonUnionCase("Europe/Oslo")>] EuropeOslo
    | [<JsonUnionCase("Europe/Paris")>] EuropeParis
    | [<JsonUnionCase("Europe/Podgorica")>] EuropePodgorica
    | [<JsonUnionCase("Europe/Prague")>] EuropePrague
    | [<JsonUnionCase("Europe/Riga")>] EuropeRiga
    | [<JsonUnionCase("Europe/Rome")>] EuropeRome
    | [<JsonUnionCase("Europe/Samara")>] EuropeSamara
    | [<JsonUnionCase("Europe/San_Marino")>] EuropeSanMarino
    | [<JsonUnionCase("Europe/Sarajevo")>] EuropeSarajevo
    | [<JsonUnionCase("Europe/Saratov")>] EuropeSaratov
    | [<JsonUnionCase("Europe/Simferopol")>] EuropeSimferopol
    | [<JsonUnionCase("Europe/Skopje")>] EuropeSkopje
    | [<JsonUnionCase("Europe/Sofia")>] EuropeSofia
    | [<JsonUnionCase("Europe/Stockholm")>] EuropeStockholm
    | [<JsonUnionCase("Europe/Tallinn")>] EuropeTallinn
    | [<JsonUnionCase("Europe/Tirane")>] EuropeTirane
    | [<JsonUnionCase("Europe/Tiraspol")>] EuropeTiraspol
    | [<JsonUnionCase("Europe/Ulyanovsk")>] EuropeUlyanovsk
    | [<JsonUnionCase("Europe/Uzhgorod")>] EuropeUzhgorod
    | [<JsonUnionCase("Europe/Vaduz")>] EuropeVaduz
    | [<JsonUnionCase("Europe/Vatican")>] EuropeVatican
    | [<JsonUnionCase("Europe/Vienna")>] EuropeVienna
    | [<JsonUnionCase("Europe/Vilnius")>] EuropeVilnius
    | [<JsonUnionCase("Europe/Volgograd")>] EuropeVolgograd
    | [<JsonUnionCase("Europe/Warsaw")>] EuropeWarsaw
    | [<JsonUnionCase("Europe/Zagreb")>] EuropeZagreb
    | [<JsonUnionCase("Europe/Zaporozhye")>] EuropeZaporozhye
    | [<JsonUnionCase("Europe/Zurich")>] EuropeZurich
    | [<JsonUnionCase("Factory")>] Factory
    | [<JsonUnionCase("GB")>] GB
    | [<JsonUnionCase("GB-Eire")>] GBEire
    | [<JsonUnionCase("GMT")>] GMT
    | [<JsonUnionCase("GMT+0")>] GMTplus0
    | [<JsonUnionCase("GMT-0")>] GMTminus0
    | [<JsonUnionCase("GMT0")>] GMT0
    | [<JsonUnionCase("Greenwich")>] Greenwich
    | [<JsonUnionCase("HST")>] HST
    | [<JsonUnionCase("Hongkong")>] Hongkong
    | [<JsonUnionCase("Iceland")>] Iceland
    | [<JsonUnionCase("Indian/Antananarivo")>] IndianAntananarivo
    | [<JsonUnionCase("Indian/Chagos")>] IndianChagos
    | [<JsonUnionCase("Indian/Christmas")>] IndianChristmas
    | [<JsonUnionCase("Indian/Cocos")>] IndianCocos
    | [<JsonUnionCase("Indian/Comoro")>] IndianComoro
    | [<JsonUnionCase("Indian/Kerguelen")>] IndianKerguelen
    | [<JsonUnionCase("Indian/Mahe")>] IndianMahe
    | [<JsonUnionCase("Indian/Maldives")>] IndianMaldives
    | [<JsonUnionCase("Indian/Mauritius")>] IndianMauritius
    | [<JsonUnionCase("Indian/Mayotte")>] IndianMayotte
    | [<JsonUnionCase("Indian/Reunion")>] IndianReunion
    | [<JsonUnionCase("Iran")>] Iran
    | [<JsonUnionCase("Israel")>] Israel
    | [<JsonUnionCase("Jamaica")>] Jamaica
    | [<JsonUnionCase("Japan")>] Japan
    | [<JsonUnionCase("Kwajalein")>] Kwajalein
    | [<JsonUnionCase("Libya")>] Libya
    | [<JsonUnionCase("MET")>] MET
    | [<JsonUnionCase("MST")>] MST
    | [<JsonUnionCase("MST7MDT")>] MST7MDT
    | [<JsonUnionCase("Mexico/BajaNorte")>] MexicoBajaNorte
    | [<JsonUnionCase("Mexico/BajaSur")>] MexicoBajaSur
    | [<JsonUnionCase("Mexico/General")>] MexicoGeneral
    | [<JsonUnionCase("NZ")>] NZ
    | [<JsonUnionCase("NZ-CHAT")>] NZCHAT
    | [<JsonUnionCase("Navajo")>] Navajo
    | [<JsonUnionCase("PRC")>] PRC
    | [<JsonUnionCase("PST8PDT")>] PST8PDT
    | [<JsonUnionCase("Pacific/Apia")>] PacificApia
    | [<JsonUnionCase("Pacific/Auckland")>] PacificAuckland
    | [<JsonUnionCase("Pacific/Bougainville")>] PacificBougainville
    | [<JsonUnionCase("Pacific/Chatham")>] PacificChatham
    | [<JsonUnionCase("Pacific/Chuuk")>] PacificChuuk
    | [<JsonUnionCase("Pacific/Easter")>] PacificEaster
    | [<JsonUnionCase("Pacific/Efate")>] PacificEfate
    | [<JsonUnionCase("Pacific/Enderbury")>] PacificEnderbury
    | [<JsonUnionCase("Pacific/Fakaofo")>] PacificFakaofo
    | [<JsonUnionCase("Pacific/Fiji")>] PacificFiji
    | [<JsonUnionCase("Pacific/Funafuti")>] PacificFunafuti
    | [<JsonUnionCase("Pacific/Galapagos")>] PacificGalapagos
    | [<JsonUnionCase("Pacific/Gambier")>] PacificGambier
    | [<JsonUnionCase("Pacific/Guadalcanal")>] PacificGuadalcanal
    | [<JsonUnionCase("Pacific/Guam")>] PacificGuam
    | [<JsonUnionCase("Pacific/Honolulu")>] PacificHonolulu
    | [<JsonUnionCase("Pacific/Johnston")>] PacificJohnston
    | [<JsonUnionCase("Pacific/Kanton")>] PacificKanton
    | [<JsonUnionCase("Pacific/Kiritimati")>] PacificKiritimati
    | [<JsonUnionCase("Pacific/Kosrae")>] PacificKosrae
    | [<JsonUnionCase("Pacific/Kwajalein")>] PacificKwajalein
    | [<JsonUnionCase("Pacific/Majuro")>] PacificMajuro
    | [<JsonUnionCase("Pacific/Marquesas")>] PacificMarquesas
    | [<JsonUnionCase("Pacific/Midway")>] PacificMidway
    | [<JsonUnionCase("Pacific/Nauru")>] PacificNauru
    | [<JsonUnionCase("Pacific/Niue")>] PacificNiue
    | [<JsonUnionCase("Pacific/Norfolk")>] PacificNorfolk
    | [<JsonUnionCase("Pacific/Noumea")>] PacificNoumea
    | [<JsonUnionCase("Pacific/Pago_Pago")>] PacificPagoPago
    | [<JsonUnionCase("Pacific/Palau")>] PacificPalau
    | [<JsonUnionCase("Pacific/Pitcairn")>] PacificPitcairn
    | [<JsonUnionCase("Pacific/Pohnpei")>] PacificPohnpei
    | [<JsonUnionCase("Pacific/Ponape")>] PacificPonape
    | [<JsonUnionCase("Pacific/Port_Moresby")>] PacificPortMoresby
    | [<JsonUnionCase("Pacific/Rarotonga")>] PacificRarotonga
    | [<JsonUnionCase("Pacific/Saipan")>] PacificSaipan
    | [<JsonUnionCase("Pacific/Samoa")>] PacificSamoa
    | [<JsonUnionCase("Pacific/Tahiti")>] PacificTahiti
    | [<JsonUnionCase("Pacific/Tarawa")>] PacificTarawa
    | [<JsonUnionCase("Pacific/Tongatapu")>] PacificTongatapu
    | [<JsonUnionCase("Pacific/Truk")>] PacificTruk
    | [<JsonUnionCase("Pacific/Wake")>] PacificWake
    | [<JsonUnionCase("Pacific/Wallis")>] PacificWallis
    | [<JsonUnionCase("Pacific/Yap")>] PacificYap
    | [<JsonUnionCase("Poland")>] Poland
    | [<JsonUnionCase("Portugal")>] Portugal
    | [<JsonUnionCase("ROC")>] ROC
    | [<JsonUnionCase("ROK")>] ROK
    | [<JsonUnionCase("Singapore")>] Singapore
    | [<JsonUnionCase("Turkey")>] Turkey
    | [<JsonUnionCase("UCT")>] UCT
    | [<JsonUnionCase("US/Alaska")>] USAlaska
    | [<JsonUnionCase("US/Aleutian")>] USAleutian
    | [<JsonUnionCase("US/Arizona")>] USArizona
    | [<JsonUnionCase("US/Central")>] USCentral
    | [<JsonUnionCase("US/East-Indiana")>] USEastIndiana
    | [<JsonUnionCase("US/Eastern")>] USEastern
    | [<JsonUnionCase("US/Hawaii")>] USHawaii
    | [<JsonUnionCase("US/Indiana-Starke")>] USIndianaStarke
    | [<JsonUnionCase("US/Michigan")>] USMichigan
    | [<JsonUnionCase("US/Mountain")>] USMountain
    | [<JsonUnionCase("US/Pacific")>] USPacific
    | [<JsonUnionCase("US/Pacific-New")>] USPacificNew
    | [<JsonUnionCase("US/Samoa")>] USSamoa
    | [<JsonUnionCase("UTC")>] UTC
    | [<JsonUnionCase("Universal")>] Universal
    | [<JsonUnionCase("W-SU")>] WSU
    | [<JsonUnionCase("WET")>] WET
    | [<JsonUnionCase("Zulu")>] Zulu

    type Create'Parameters = {
        ///The set of report columns to include in the report output. If omitted, the Report Type is run with its default column set.
        [<Config.Form>]Columns: string list option
        ///Connected account ID to filter for in the report run.
        [<Config.Form>]ConnectedAccount: string option
        ///Currency of objects to be included in the report run.
        [<Config.Form>]Currency: string option
        ///Ending timestamp of data to be included in the report run (exclusive).
        [<Config.Form>]IntervalEnd: DateTime option
        ///Starting timestamp of data to be included in the report run.
        [<Config.Form>]IntervalStart: DateTime option
        ///Payout ID by which to filter the report run.
        [<Config.Form>]Payout: string option
        ///Category of balance transactions to be included in the report run.
        [<Config.Form>]ReportingCategory: Create'ParametersReportingCategory option
        ///Defaults to `Etc/UTC`. The output timezone for all timestamps in the report. A list of possible time zone values is maintained at the [IANA Time Zone Database](http://www.iana.org/time-zones). Has no effect on `interval_start` or `interval_end`.
        [<Config.Form>]Timezone: Create'ParametersTimezone option
    }
    with
        static member New(?columns: string list, ?connectedAccount: string, ?currency: string, ?intervalEnd: DateTime, ?intervalStart: DateTime, ?payout: string, ?reportingCategory: Create'ParametersReportingCategory, ?timezone: Create'ParametersTimezone) =
            {
                Columns = columns
                ConnectedAccount = connectedAccount
                Currency = currency
                IntervalEnd = intervalEnd
                IntervalStart = intervalStart
                Payout = payout
                ReportingCategory = reportingCategory
                Timezone = timezone
            }

    type CreateOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Parameters specifying how the report should be run. Different Report Types have different required and optional parameters, listed in the [API Access to Reports](https://stripe.com/docs/reporting/statements/api) documentation.
        [<Config.Form>]Parameters: Create'Parameters option
        ///The ID of the [report type](https://stripe.com/docs/reporting/statements/api#report-types) to run, such as `"balance.summary.1"`.
        [<Config.Form>]ReportType: string
    }
    with
        static member New(reportType: string, ?parameters: Create'Parameters, ?expand: string list) =
            {
                Expand = expand
                Parameters = parameters
                ReportType = reportType
            }

    ///<p>Creates a new object and begin running the report. (Certain report types require a <a href="https://stripe.com/docs/keys#test-live-modes">live-mode API key</a>.)</p>
    let Create settings (options: CreateOptions) =
        $"/v1/reporting/report_runs"
        |> RestApi.postAsync<_, ReportingReportRun> settings (Map.empty) options

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]ReportRun: string
    }
    with
        static member New(reportRun: string, ?expand: string list) =
            {
                Expand = expand
                ReportRun = reportRun
            }

    ///<p>Retrieves the details of an existing Report Run.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/reporting/report_runs/{options.ReportRun}"
        |> RestApi.getAsync<ReportingReportRun> settings qs

module ReportingReportTypes =

    type ListOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(?expand: string list) =
            {
                Expand = expand
            }

    ///<p>Returns a full list of Report Types.</p>
    let List settings (options: ListOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/reporting/report_types"
        |> RestApi.getAsync<ReportingReportType list> settings qs

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]ReportType: string
    }
    with
        static member New(reportType: string, ?expand: string list) =
            {
                Expand = expand
                ReportType = reportType
            }

    ///<p>Retrieves the details of a Report Type. (Certain report types require a <a href="https://stripe.com/docs/keys#test-live-modes">live-mode API key</a>.)</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/reporting/report_types/{options.ReportType}"
        |> RestApi.getAsync<ReportingReportType> settings qs
