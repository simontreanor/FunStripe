namespace StripeRequest.Reporting

open FunStripe
open System.Text.Json.Serialization
open Stripe.Reporting
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
module ReportingReportRuns =

    type ListOptions =
        {
            /// Only return Report Runs that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    type ListOptions with
        static member New(?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    type Create'ParametersReportingCategory =
        | Advance
        | AdvanceFunding
        | AnticipationRepayment
        | Charge
        | ChargeFailure
        | ClimateOrderPurchase
        | ClimateOrderRefund
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
        | UnreconciledCustomerFunds

    type Create'ParametersTimezone =
        | [<JsonPropertyName("Africa/Abidjan")>] AfricaAbidjan
        | [<JsonPropertyName("Africa/Accra")>] AfricaAccra
        | [<JsonPropertyName("Africa/Addis_Ababa")>] AfricaAddisAbaba
        | [<JsonPropertyName("Africa/Algiers")>] AfricaAlgiers
        | [<JsonPropertyName("Africa/Asmara")>] AfricaAsmara
        | [<JsonPropertyName("Africa/Asmera")>] AfricaAsmera
        | [<JsonPropertyName("Africa/Bamako")>] AfricaBamako
        | [<JsonPropertyName("Africa/Bangui")>] AfricaBangui
        | [<JsonPropertyName("Africa/Banjul")>] AfricaBanjul
        | [<JsonPropertyName("Africa/Bissau")>] AfricaBissau
        | [<JsonPropertyName("Africa/Blantyre")>] AfricaBlantyre
        | [<JsonPropertyName("Africa/Brazzaville")>] AfricaBrazzaville
        | [<JsonPropertyName("Africa/Bujumbura")>] AfricaBujumbura
        | [<JsonPropertyName("Africa/Cairo")>] AfricaCairo
        | [<JsonPropertyName("Africa/Casablanca")>] AfricaCasablanca
        | [<JsonPropertyName("Africa/Ceuta")>] AfricaCeuta
        | [<JsonPropertyName("Africa/Conakry")>] AfricaConakry
        | [<JsonPropertyName("Africa/Dakar")>] AfricaDakar
        | [<JsonPropertyName("Africa/Dar_es_Salaam")>] AfricaDarEsSalaam
        | [<JsonPropertyName("Africa/Djibouti")>] AfricaDjibouti
        | [<JsonPropertyName("Africa/Douala")>] AfricaDouala
        | [<JsonPropertyName("Africa/El_Aaiun")>] AfricaElAaiun
        | [<JsonPropertyName("Africa/Freetown")>] AfricaFreetown
        | [<JsonPropertyName("Africa/Gaborone")>] AfricaGaborone
        | [<JsonPropertyName("Africa/Harare")>] AfricaHarare
        | [<JsonPropertyName("Africa/Johannesburg")>] AfricaJohannesburg
        | [<JsonPropertyName("Africa/Juba")>] AfricaJuba
        | [<JsonPropertyName("Africa/Kampala")>] AfricaKampala
        | [<JsonPropertyName("Africa/Khartoum")>] AfricaKhartoum
        | [<JsonPropertyName("Africa/Kigali")>] AfricaKigali
        | [<JsonPropertyName("Africa/Kinshasa")>] AfricaKinshasa
        | [<JsonPropertyName("Africa/Lagos")>] AfricaLagos
        | [<JsonPropertyName("Africa/Libreville")>] AfricaLibreville
        | [<JsonPropertyName("Africa/Lome")>] AfricaLome
        | [<JsonPropertyName("Africa/Luanda")>] AfricaLuanda
        | [<JsonPropertyName("Africa/Lubumbashi")>] AfricaLubumbashi
        | [<JsonPropertyName("Africa/Lusaka")>] AfricaLusaka
        | [<JsonPropertyName("Africa/Malabo")>] AfricaMalabo
        | [<JsonPropertyName("Africa/Maputo")>] AfricaMaputo
        | [<JsonPropertyName("Africa/Maseru")>] AfricaMaseru
        | [<JsonPropertyName("Africa/Mbabane")>] AfricaMbabane
        | [<JsonPropertyName("Africa/Mogadishu")>] AfricaMogadishu
        | [<JsonPropertyName("Africa/Monrovia")>] AfricaMonrovia
        | [<JsonPropertyName("Africa/Nairobi")>] AfricaNairobi
        | [<JsonPropertyName("Africa/Ndjamena")>] AfricaNdjamena
        | [<JsonPropertyName("Africa/Niamey")>] AfricaNiamey
        | [<JsonPropertyName("Africa/Nouakchott")>] AfricaNouakchott
        | [<JsonPropertyName("Africa/Ouagadougou")>] AfricaOuagadougou
        | [<JsonPropertyName("Africa/Porto-Novo")>] AfricaPortoNovo
        | [<JsonPropertyName("Africa/Sao_Tome")>] AfricaSaoTome
        | [<JsonPropertyName("Africa/Timbuktu")>] AfricaTimbuktu
        | [<JsonPropertyName("Africa/Tripoli")>] AfricaTripoli
        | [<JsonPropertyName("Africa/Tunis")>] AfricaTunis
        | [<JsonPropertyName("Africa/Windhoek")>] AfricaWindhoek
        | [<JsonPropertyName("America/Adak")>] AmericaAdak
        | [<JsonPropertyName("America/Anchorage")>] AmericaAnchorage
        | [<JsonPropertyName("America/Anguilla")>] AmericaAnguilla
        | [<JsonPropertyName("America/Antigua")>] AmericaAntigua
        | [<JsonPropertyName("America/Araguaina")>] AmericaAraguaina
        | [<JsonPropertyName("America/Argentina/Buenos_Aires")>] AmericaArgentinaBuenosAires
        | [<JsonPropertyName("America/Argentina/Catamarca")>] AmericaArgentinaCatamarca
        | [<JsonPropertyName("America/Argentina/ComodRivadavia")>] AmericaArgentinaComodRivadavia
        | [<JsonPropertyName("America/Argentina/Cordoba")>] AmericaArgentinaCordoba
        | [<JsonPropertyName("America/Argentina/Jujuy")>] AmericaArgentinaJujuy
        | [<JsonPropertyName("America/Argentina/La_Rioja")>] AmericaArgentinaLaRioja
        | [<JsonPropertyName("America/Argentina/Mendoza")>] AmericaArgentinaMendoza
        | [<JsonPropertyName("America/Argentina/Rio_Gallegos")>] AmericaArgentinaRioGallegos
        | [<JsonPropertyName("America/Argentina/Salta")>] AmericaArgentinaSalta
        | [<JsonPropertyName("America/Argentina/San_Juan")>] AmericaArgentinaSanJuan
        | [<JsonPropertyName("America/Argentina/San_Luis")>] AmericaArgentinaSanLuis
        | [<JsonPropertyName("America/Argentina/Tucuman")>] AmericaArgentinaTucuman
        | [<JsonPropertyName("America/Argentina/Ushuaia")>] AmericaArgentinaUshuaia
        | [<JsonPropertyName("America/Aruba")>] AmericaAruba
        | [<JsonPropertyName("America/Asuncion")>] AmericaAsuncion
        | [<JsonPropertyName("America/Atikokan")>] AmericaAtikokan
        | [<JsonPropertyName("America/Atka")>] AmericaAtka
        | [<JsonPropertyName("America/Bahia")>] AmericaBahia
        | [<JsonPropertyName("America/Bahia_Banderas")>] AmericaBahiaBanderas
        | [<JsonPropertyName("America/Barbados")>] AmericaBarbados
        | [<JsonPropertyName("America/Belem")>] AmericaBelem
        | [<JsonPropertyName("America/Belize")>] AmericaBelize
        | [<JsonPropertyName("America/Blanc-Sablon")>] AmericaBlancSablon
        | [<JsonPropertyName("America/Boa_Vista")>] AmericaBoaVista
        | [<JsonPropertyName("America/Bogota")>] AmericaBogota
        | [<JsonPropertyName("America/Boise")>] AmericaBoise
        | [<JsonPropertyName("America/Buenos_Aires")>] AmericaBuenosAires
        | [<JsonPropertyName("America/Cambridge_Bay")>] AmericaCambridgeBay
        | [<JsonPropertyName("America/Campo_Grande")>] AmericaCampoGrande
        | [<JsonPropertyName("America/Cancun")>] AmericaCancun
        | [<JsonPropertyName("America/Caracas")>] AmericaCaracas
        | [<JsonPropertyName("America/Catamarca")>] AmericaCatamarca
        | [<JsonPropertyName("America/Cayenne")>] AmericaCayenne
        | [<JsonPropertyName("America/Cayman")>] AmericaCayman
        | [<JsonPropertyName("America/Chicago")>] AmericaChicago
        | [<JsonPropertyName("America/Chihuahua")>] AmericaChihuahua
        | [<JsonPropertyName("America/Ciudad_Juarez")>] AmericaCiudadJuarez
        | [<JsonPropertyName("America/Coral_Harbour")>] AmericaCoralHarbour
        | [<JsonPropertyName("America/Cordoba")>] AmericaCordoba
        | [<JsonPropertyName("America/Costa_Rica")>] AmericaCostaRica
        | [<JsonPropertyName("America/Coyhaique")>] AmericaCoyhaique
        | [<JsonPropertyName("America/Creston")>] AmericaCreston
        | [<JsonPropertyName("America/Cuiaba")>] AmericaCuiaba
        | [<JsonPropertyName("America/Curacao")>] AmericaCuracao
        | [<JsonPropertyName("America/Danmarkshavn")>] AmericaDanmarkshavn
        | [<JsonPropertyName("America/Dawson")>] AmericaDawson
        | [<JsonPropertyName("America/Dawson_Creek")>] AmericaDawsonCreek
        | [<JsonPropertyName("America/Denver")>] AmericaDenver
        | [<JsonPropertyName("America/Detroit")>] AmericaDetroit
        | [<JsonPropertyName("America/Dominica")>] AmericaDominica
        | [<JsonPropertyName("America/Edmonton")>] AmericaEdmonton
        | [<JsonPropertyName("America/Eirunepe")>] AmericaEirunepe
        | [<JsonPropertyName("America/El_Salvador")>] AmericaElSalvador
        | [<JsonPropertyName("America/Ensenada")>] AmericaEnsenada
        | [<JsonPropertyName("America/Fort_Nelson")>] AmericaFortNelson
        | [<JsonPropertyName("America/Fort_Wayne")>] AmericaFortWayne
        | [<JsonPropertyName("America/Fortaleza")>] AmericaFortaleza
        | [<JsonPropertyName("America/Glace_Bay")>] AmericaGlaceBay
        | [<JsonPropertyName("America/Godthab")>] AmericaGodthab
        | [<JsonPropertyName("America/Goose_Bay")>] AmericaGooseBay
        | [<JsonPropertyName("America/Grand_Turk")>] AmericaGrandTurk
        | [<JsonPropertyName("America/Grenada")>] AmericaGrenada
        | [<JsonPropertyName("America/Guadeloupe")>] AmericaGuadeloupe
        | [<JsonPropertyName("America/Guatemala")>] AmericaGuatemala
        | [<JsonPropertyName("America/Guayaquil")>] AmericaGuayaquil
        | [<JsonPropertyName("America/Guyana")>] AmericaGuyana
        | [<JsonPropertyName("America/Halifax")>] AmericaHalifax
        | [<JsonPropertyName("America/Havana")>] AmericaHavana
        | [<JsonPropertyName("America/Hermosillo")>] AmericaHermosillo
        | [<JsonPropertyName("America/Indiana/Indianapolis")>] AmericaIndianaIndianapolis
        | [<JsonPropertyName("America/Indiana/Knox")>] AmericaIndianaKnox
        | [<JsonPropertyName("America/Indiana/Marengo")>] AmericaIndianaMarengo
        | [<JsonPropertyName("America/Indiana/Petersburg")>] AmericaIndianaPetersburg
        | [<JsonPropertyName("America/Indiana/Tell_City")>] AmericaIndianaTellCity
        | [<JsonPropertyName("America/Indiana/Vevay")>] AmericaIndianaVevay
        | [<JsonPropertyName("America/Indiana/Vincennes")>] AmericaIndianaVincennes
        | [<JsonPropertyName("America/Indiana/Winamac")>] AmericaIndianaWinamac
        | [<JsonPropertyName("America/Indianapolis")>] AmericaIndianapolis
        | [<JsonPropertyName("America/Inuvik")>] AmericaInuvik
        | [<JsonPropertyName("America/Iqaluit")>] AmericaIqaluit
        | [<JsonPropertyName("America/Jamaica")>] AmericaJamaica
        | [<JsonPropertyName("America/Jujuy")>] AmericaJujuy
        | [<JsonPropertyName("America/Juneau")>] AmericaJuneau
        | [<JsonPropertyName("America/Kentucky/Louisville")>] AmericaKentuckyLouisville
        | [<JsonPropertyName("America/Kentucky/Monticello")>] AmericaKentuckyMonticello
        | [<JsonPropertyName("America/Knox_IN")>] AmericaKnoxIN
        | [<JsonPropertyName("America/Kralendijk")>] AmericaKralendijk
        | [<JsonPropertyName("America/La_Paz")>] AmericaLaPaz
        | [<JsonPropertyName("America/Lima")>] AmericaLima
        | [<JsonPropertyName("America/Los_Angeles")>] AmericaLosAngeles
        | [<JsonPropertyName("America/Louisville")>] AmericaLouisville
        | [<JsonPropertyName("America/Lower_Princes")>] AmericaLowerPrinces
        | [<JsonPropertyName("America/Maceio")>] AmericaMaceio
        | [<JsonPropertyName("America/Managua")>] AmericaManagua
        | [<JsonPropertyName("America/Manaus")>] AmericaManaus
        | [<JsonPropertyName("America/Marigot")>] AmericaMarigot
        | [<JsonPropertyName("America/Martinique")>] AmericaMartinique
        | [<JsonPropertyName("America/Matamoros")>] AmericaMatamoros
        | [<JsonPropertyName("America/Mazatlan")>] AmericaMazatlan
        | [<JsonPropertyName("America/Mendoza")>] AmericaMendoza
        | [<JsonPropertyName("America/Menominee")>] AmericaMenominee
        | [<JsonPropertyName("America/Merida")>] AmericaMerida
        | [<JsonPropertyName("America/Metlakatla")>] AmericaMetlakatla
        | [<JsonPropertyName("America/Mexico_City")>] AmericaMexicoCity
        | [<JsonPropertyName("America/Miquelon")>] AmericaMiquelon
        | [<JsonPropertyName("America/Moncton")>] AmericaMoncton
        | [<JsonPropertyName("America/Monterrey")>] AmericaMonterrey
        | [<JsonPropertyName("America/Montevideo")>] AmericaMontevideo
        | [<JsonPropertyName("America/Montreal")>] AmericaMontreal
        | [<JsonPropertyName("America/Montserrat")>] AmericaMontserrat
        | [<JsonPropertyName("America/Nassau")>] AmericaNassau
        | [<JsonPropertyName("America/New_York")>] AmericaNewYork
        | [<JsonPropertyName("America/Nipigon")>] AmericaNipigon
        | [<JsonPropertyName("America/Nome")>] AmericaNome
        | [<JsonPropertyName("America/Noronha")>] AmericaNoronha
        | [<JsonPropertyName("America/North_Dakota/Beulah")>] AmericaNorthDakotaBeulah
        | [<JsonPropertyName("America/North_Dakota/Center")>] AmericaNorthDakotaCenter
        | [<JsonPropertyName("America/North_Dakota/New_Salem")>] AmericaNorthDakotaNewSalem
        | [<JsonPropertyName("America/Nuuk")>] AmericaNuuk
        | [<JsonPropertyName("America/Ojinaga")>] AmericaOjinaga
        | [<JsonPropertyName("America/Panama")>] AmericaPanama
        | [<JsonPropertyName("America/Pangnirtung")>] AmericaPangnirtung
        | [<JsonPropertyName("America/Paramaribo")>] AmericaParamaribo
        | [<JsonPropertyName("America/Phoenix")>] AmericaPhoenix
        | [<JsonPropertyName("America/Port-au-Prince")>] AmericaPortauPrince
        | [<JsonPropertyName("America/Port_of_Spain")>] AmericaPortOfSpain
        | [<JsonPropertyName("America/Porto_Acre")>] AmericaPortoAcre
        | [<JsonPropertyName("America/Porto_Velho")>] AmericaPortoVelho
        | [<JsonPropertyName("America/Puerto_Rico")>] AmericaPuertoRico
        | [<JsonPropertyName("America/Punta_Arenas")>] AmericaPuntaArenas
        | [<JsonPropertyName("America/Rainy_River")>] AmericaRainyRiver
        | [<JsonPropertyName("America/Rankin_Inlet")>] AmericaRankinInlet
        | [<JsonPropertyName("America/Recife")>] AmericaRecife
        | [<JsonPropertyName("America/Regina")>] AmericaRegina
        | [<JsonPropertyName("America/Resolute")>] AmericaResolute
        | [<JsonPropertyName("America/Rio_Branco")>] AmericaRioBranco
        | [<JsonPropertyName("America/Rosario")>] AmericaRosario
        | [<JsonPropertyName("America/Santa_Isabel")>] AmericaSantaIsabel
        | [<JsonPropertyName("America/Santarem")>] AmericaSantarem
        | [<JsonPropertyName("America/Santiago")>] AmericaSantiago
        | [<JsonPropertyName("America/Santo_Domingo")>] AmericaSantoDomingo
        | [<JsonPropertyName("America/Sao_Paulo")>] AmericaSaoPaulo
        | [<JsonPropertyName("America/Scoresbysund")>] AmericaScoresbysund
        | [<JsonPropertyName("America/Shiprock")>] AmericaShiprock
        | [<JsonPropertyName("America/Sitka")>] AmericaSitka
        | [<JsonPropertyName("America/St_Barthelemy")>] AmericaStBarthelemy
        | [<JsonPropertyName("America/St_Johns")>] AmericaStJohns
        | [<JsonPropertyName("America/St_Kitts")>] AmericaStKitts
        | [<JsonPropertyName("America/St_Lucia")>] AmericaStLucia
        | [<JsonPropertyName("America/St_Thomas")>] AmericaStThomas
        | [<JsonPropertyName("America/St_Vincent")>] AmericaStVincent
        | [<JsonPropertyName("America/Swift_Current")>] AmericaSwiftCurrent
        | [<JsonPropertyName("America/Tegucigalpa")>] AmericaTegucigalpa
        | [<JsonPropertyName("America/Thule")>] AmericaThule
        | [<JsonPropertyName("America/Thunder_Bay")>] AmericaThunderBay
        | [<JsonPropertyName("America/Tijuana")>] AmericaTijuana
        | [<JsonPropertyName("America/Toronto")>] AmericaToronto
        | [<JsonPropertyName("America/Tortola")>] AmericaTortola
        | [<JsonPropertyName("America/Vancouver")>] AmericaVancouver
        | [<JsonPropertyName("America/Virgin")>] AmericaVirgin
        | [<JsonPropertyName("America/Whitehorse")>] AmericaWhitehorse
        | [<JsonPropertyName("America/Winnipeg")>] AmericaWinnipeg
        | [<JsonPropertyName("America/Yakutat")>] AmericaYakutat
        | [<JsonPropertyName("America/Yellowknife")>] AmericaYellowknife
        | [<JsonPropertyName("Antarctica/Casey")>] AntarcticaCasey
        | [<JsonPropertyName("Antarctica/Davis")>] AntarcticaDavis
        | [<JsonPropertyName("Antarctica/DumontDUrville")>] AntarcticaDumontDUrville
        | [<JsonPropertyName("Antarctica/Macquarie")>] AntarcticaMacquarie
        | [<JsonPropertyName("Antarctica/Mawson")>] AntarcticaMawson
        | [<JsonPropertyName("Antarctica/McMurdo")>] AntarcticaMcMurdo
        | [<JsonPropertyName("Antarctica/Palmer")>] AntarcticaPalmer
        | [<JsonPropertyName("Antarctica/Rothera")>] AntarcticaRothera
        | [<JsonPropertyName("Antarctica/South_Pole")>] AntarcticaSouthPole
        | [<JsonPropertyName("Antarctica/Syowa")>] AntarcticaSyowa
        | [<JsonPropertyName("Antarctica/Troll")>] AntarcticaTroll
        | [<JsonPropertyName("Antarctica/Vostok")>] AntarcticaVostok
        | [<JsonPropertyName("Arctic/Longyearbyen")>] ArcticLongyearbyen
        | [<JsonPropertyName("Asia/Aden")>] AsiaAden
        | [<JsonPropertyName("Asia/Almaty")>] AsiaAlmaty
        | [<JsonPropertyName("Asia/Amman")>] AsiaAmman
        | [<JsonPropertyName("Asia/Anadyr")>] AsiaAnadyr
        | [<JsonPropertyName("Asia/Aqtau")>] AsiaAqtau
        | [<JsonPropertyName("Asia/Aqtobe")>] AsiaAqtobe
        | [<JsonPropertyName("Asia/Ashgabat")>] AsiaAshgabat
        | [<JsonPropertyName("Asia/Ashkhabad")>] AsiaAshkhabad
        | [<JsonPropertyName("Asia/Atyrau")>] AsiaAtyrau
        | [<JsonPropertyName("Asia/Baghdad")>] AsiaBaghdad
        | [<JsonPropertyName("Asia/Bahrain")>] AsiaBahrain
        | [<JsonPropertyName("Asia/Baku")>] AsiaBaku
        | [<JsonPropertyName("Asia/Bangkok")>] AsiaBangkok
        | [<JsonPropertyName("Asia/Barnaul")>] AsiaBarnaul
        | [<JsonPropertyName("Asia/Beirut")>] AsiaBeirut
        | [<JsonPropertyName("Asia/Bishkek")>] AsiaBishkek
        | [<JsonPropertyName("Asia/Brunei")>] AsiaBrunei
        | [<JsonPropertyName("Asia/Calcutta")>] AsiaCalcutta
        | [<JsonPropertyName("Asia/Chita")>] AsiaChita
        | [<JsonPropertyName("Asia/Choibalsan")>] AsiaChoibalsan
        | [<JsonPropertyName("Asia/Chongqing")>] AsiaChongqing
        | [<JsonPropertyName("Asia/Chungking")>] AsiaChungking
        | [<JsonPropertyName("Asia/Colombo")>] AsiaColombo
        | [<JsonPropertyName("Asia/Dacca")>] AsiaDacca
        | [<JsonPropertyName("Asia/Damascus")>] AsiaDamascus
        | [<JsonPropertyName("Asia/Dhaka")>] AsiaDhaka
        | [<JsonPropertyName("Asia/Dili")>] AsiaDili
        | [<JsonPropertyName("Asia/Dubai")>] AsiaDubai
        | [<JsonPropertyName("Asia/Dushanbe")>] AsiaDushanbe
        | [<JsonPropertyName("Asia/Famagusta")>] AsiaFamagusta
        | [<JsonPropertyName("Asia/Gaza")>] AsiaGaza
        | [<JsonPropertyName("Asia/Harbin")>] AsiaHarbin
        | [<JsonPropertyName("Asia/Hebron")>] AsiaHebron
        | [<JsonPropertyName("Asia/Ho_Chi_Minh")>] AsiaHoChiMinh
        | [<JsonPropertyName("Asia/Hong_Kong")>] AsiaHongKong
        | [<JsonPropertyName("Asia/Hovd")>] AsiaHovd
        | [<JsonPropertyName("Asia/Irkutsk")>] AsiaIrkutsk
        | [<JsonPropertyName("Asia/Istanbul")>] AsiaIstanbul
        | [<JsonPropertyName("Asia/Jakarta")>] AsiaJakarta
        | [<JsonPropertyName("Asia/Jayapura")>] AsiaJayapura
        | [<JsonPropertyName("Asia/Jerusalem")>] AsiaJerusalem
        | [<JsonPropertyName("Asia/Kabul")>] AsiaKabul
        | [<JsonPropertyName("Asia/Kamchatka")>] AsiaKamchatka
        | [<JsonPropertyName("Asia/Karachi")>] AsiaKarachi
        | [<JsonPropertyName("Asia/Kashgar")>] AsiaKashgar
        | [<JsonPropertyName("Asia/Kathmandu")>] AsiaKathmandu
        | [<JsonPropertyName("Asia/Katmandu")>] AsiaKatmandu
        | [<JsonPropertyName("Asia/Khandyga")>] AsiaKhandyga
        | [<JsonPropertyName("Asia/Kolkata")>] AsiaKolkata
        | [<JsonPropertyName("Asia/Krasnoyarsk")>] AsiaKrasnoyarsk
        | [<JsonPropertyName("Asia/Kuala_Lumpur")>] AsiaKualaLumpur
        | [<JsonPropertyName("Asia/Kuching")>] AsiaKuching
        | [<JsonPropertyName("Asia/Kuwait")>] AsiaKuwait
        | [<JsonPropertyName("Asia/Macao")>] AsiaMacao
        | [<JsonPropertyName("Asia/Macau")>] AsiaMacau
        | [<JsonPropertyName("Asia/Magadan")>] AsiaMagadan
        | [<JsonPropertyName("Asia/Makassar")>] AsiaMakassar
        | [<JsonPropertyName("Asia/Manila")>] AsiaManila
        | [<JsonPropertyName("Asia/Muscat")>] AsiaMuscat
        | [<JsonPropertyName("Asia/Nicosia")>] AsiaNicosia
        | [<JsonPropertyName("Asia/Novokuznetsk")>] AsiaNovokuznetsk
        | [<JsonPropertyName("Asia/Novosibirsk")>] AsiaNovosibirsk
        | [<JsonPropertyName("Asia/Omsk")>] AsiaOmsk
        | [<JsonPropertyName("Asia/Oral")>] AsiaOral
        | [<JsonPropertyName("Asia/Phnom_Penh")>] AsiaPhnomPenh
        | [<JsonPropertyName("Asia/Pontianak")>] AsiaPontianak
        | [<JsonPropertyName("Asia/Pyongyang")>] AsiaPyongyang
        | [<JsonPropertyName("Asia/Qatar")>] AsiaQatar
        | [<JsonPropertyName("Asia/Qostanay")>] AsiaQostanay
        | [<JsonPropertyName("Asia/Qyzylorda")>] AsiaQyzylorda
        | [<JsonPropertyName("Asia/Rangoon")>] AsiaRangoon
        | [<JsonPropertyName("Asia/Riyadh")>] AsiaRiyadh
        | [<JsonPropertyName("Asia/Saigon")>] AsiaSaigon
        | [<JsonPropertyName("Asia/Sakhalin")>] AsiaSakhalin
        | [<JsonPropertyName("Asia/Samarkand")>] AsiaSamarkand
        | [<JsonPropertyName("Asia/Seoul")>] AsiaSeoul
        | [<JsonPropertyName("Asia/Shanghai")>] AsiaShanghai
        | [<JsonPropertyName("Asia/Singapore")>] AsiaSingapore
        | [<JsonPropertyName("Asia/Srednekolymsk")>] AsiaSrednekolymsk
        | [<JsonPropertyName("Asia/Taipei")>] AsiaTaipei
        | [<JsonPropertyName("Asia/Tashkent")>] AsiaTashkent
        | [<JsonPropertyName("Asia/Tbilisi")>] AsiaTbilisi
        | [<JsonPropertyName("Asia/Tehran")>] AsiaTehran
        | [<JsonPropertyName("Asia/Tel_Aviv")>] AsiaTelAviv
        | [<JsonPropertyName("Asia/Thimbu")>] AsiaThimbu
        | [<JsonPropertyName("Asia/Thimphu")>] AsiaThimphu
        | [<JsonPropertyName("Asia/Tokyo")>] AsiaTokyo
        | [<JsonPropertyName("Asia/Tomsk")>] AsiaTomsk
        | [<JsonPropertyName("Asia/Ujung_Pandang")>] AsiaUjungPandang
        | [<JsonPropertyName("Asia/Ulaanbaatar")>] AsiaUlaanbaatar
        | [<JsonPropertyName("Asia/Ulan_Bator")>] AsiaUlanBator
        | [<JsonPropertyName("Asia/Urumqi")>] AsiaUrumqi
        | [<JsonPropertyName("Asia/Ust-Nera")>] AsiaUstNera
        | [<JsonPropertyName("Asia/Vientiane")>] AsiaVientiane
        | [<JsonPropertyName("Asia/Vladivostok")>] AsiaVladivostok
        | [<JsonPropertyName("Asia/Yakutsk")>] AsiaYakutsk
        | [<JsonPropertyName("Asia/Yangon")>] AsiaYangon
        | [<JsonPropertyName("Asia/Yekaterinburg")>] AsiaYekaterinburg
        | [<JsonPropertyName("Asia/Yerevan")>] AsiaYerevan
        | [<JsonPropertyName("Atlantic/Azores")>] AtlanticAzores
        | [<JsonPropertyName("Atlantic/Bermuda")>] AtlanticBermuda
        | [<JsonPropertyName("Atlantic/Canary")>] AtlanticCanary
        | [<JsonPropertyName("Atlantic/Cape_Verde")>] AtlanticCapeVerde
        | [<JsonPropertyName("Atlantic/Faeroe")>] AtlanticFaeroe
        | [<JsonPropertyName("Atlantic/Faroe")>] AtlanticFaroe
        | [<JsonPropertyName("Atlantic/Jan_Mayen")>] AtlanticJanMayen
        | [<JsonPropertyName("Atlantic/Madeira")>] AtlanticMadeira
        | [<JsonPropertyName("Atlantic/Reykjavik")>] AtlanticReykjavik
        | [<JsonPropertyName("Atlantic/South_Georgia")>] AtlanticSouthGeorgia
        | [<JsonPropertyName("Atlantic/St_Helena")>] AtlanticStHelena
        | [<JsonPropertyName("Atlantic/Stanley")>] AtlanticStanley
        | [<JsonPropertyName("Australia/ACT")>] AustraliaACT
        | [<JsonPropertyName("Australia/Adelaide")>] AustraliaAdelaide
        | [<JsonPropertyName("Australia/Brisbane")>] AustraliaBrisbane
        | [<JsonPropertyName("Australia/Broken_Hill")>] AustraliaBrokenHill
        | [<JsonPropertyName("Australia/Canberra")>] AustraliaCanberra
        | [<JsonPropertyName("Australia/Currie")>] AustraliaCurrie
        | [<JsonPropertyName("Australia/Darwin")>] AustraliaDarwin
        | [<JsonPropertyName("Australia/Eucla")>] AustraliaEucla
        | [<JsonPropertyName("Australia/Hobart")>] AustraliaHobart
        | [<JsonPropertyName("Australia/LHI")>] AustraliaLHI
        | [<JsonPropertyName("Australia/Lindeman")>] AustraliaLindeman
        | [<JsonPropertyName("Australia/Lord_Howe")>] AustraliaLordHowe
        | [<JsonPropertyName("Australia/Melbourne")>] AustraliaMelbourne
        | [<JsonPropertyName("Australia/NSW")>] AustraliaNSW
        | [<JsonPropertyName("Australia/North")>] AustraliaNorth
        | [<JsonPropertyName("Australia/Perth")>] AustraliaPerth
        | [<JsonPropertyName("Australia/Queensland")>] AustraliaQueensland
        | [<JsonPropertyName("Australia/South")>] AustraliaSouth
        | [<JsonPropertyName("Australia/Sydney")>] AustraliaSydney
        | [<JsonPropertyName("Australia/Tasmania")>] AustraliaTasmania
        | [<JsonPropertyName("Australia/Victoria")>] AustraliaVictoria
        | [<JsonPropertyName("Australia/West")>] AustraliaWest
        | [<JsonPropertyName("Australia/Yancowinna")>] AustraliaYancowinna
        | [<JsonPropertyName("Brazil/Acre")>] BrazilAcre
        | [<JsonPropertyName("Brazil/DeNoronha")>] BrazilDeNoronha
        | [<JsonPropertyName("Brazil/East")>] BrazilEast
        | [<JsonPropertyName("Brazil/West")>] BrazilWest
        | [<JsonPropertyName("CET")>] CET
        | [<JsonPropertyName("CST6CDT")>] CST6CDT
        | [<JsonPropertyName("Canada/Atlantic")>] CanadaAtlantic
        | [<JsonPropertyName("Canada/Central")>] CanadaCentral
        | [<JsonPropertyName("Canada/Eastern")>] CanadaEastern
        | [<JsonPropertyName("Canada/Mountain")>] CanadaMountain
        | [<JsonPropertyName("Canada/Newfoundland")>] CanadaNewfoundland
        | [<JsonPropertyName("Canada/Pacific")>] CanadaPacific
        | [<JsonPropertyName("Canada/Saskatchewan")>] CanadaSaskatchewan
        | [<JsonPropertyName("Canada/Yukon")>] CanadaYukon
        | [<JsonPropertyName("Chile/Continental")>] ChileContinental
        | [<JsonPropertyName("Chile/EasterIsland")>] ChileEasterIsland
        | [<JsonPropertyName("Cuba")>] Cuba
        | [<JsonPropertyName("EET")>] EET
        | [<JsonPropertyName("EST")>] EST
        | [<JsonPropertyName("EST5EDT")>] EST5EDT
        | [<JsonPropertyName("Egypt")>] Egypt
        | [<JsonPropertyName("Eire")>] Eire
        | [<JsonPropertyName("Etc/GMT")>] EtcGMT
        | [<JsonPropertyName("Etc/GMT+0")>] EtcGMTplus0
        | [<JsonPropertyName("Etc/GMT+1")>] EtcGMTplus1
        | [<JsonPropertyName("Etc/GMT+10")>] EtcGMTplus10
        | [<JsonPropertyName("Etc/GMT+11")>] EtcGMTplus11
        | [<JsonPropertyName("Etc/GMT+12")>] EtcGMTplus12
        | [<JsonPropertyName("Etc/GMT+2")>] EtcGMTplus2
        | [<JsonPropertyName("Etc/GMT+3")>] EtcGMTplus3
        | [<JsonPropertyName("Etc/GMT+4")>] EtcGMTplus4
        | [<JsonPropertyName("Etc/GMT+5")>] EtcGMTplus5
        | [<JsonPropertyName("Etc/GMT+6")>] EtcGMTplus6
        | [<JsonPropertyName("Etc/GMT+7")>] EtcGMTplus7
        | [<JsonPropertyName("Etc/GMT+8")>] EtcGMTplus8
        | [<JsonPropertyName("Etc/GMT+9")>] EtcGMTplus9
        | [<JsonPropertyName("Etc/GMT-0")>] EtcGMTminus0
        | [<JsonPropertyName("Etc/GMT-1")>] EtcGMTminus1
        | [<JsonPropertyName("Etc/GMT-10")>] EtcGMTminus10
        | [<JsonPropertyName("Etc/GMT-11")>] EtcGMTminus11
        | [<JsonPropertyName("Etc/GMT-12")>] EtcGMTminus12
        | [<JsonPropertyName("Etc/GMT-13")>] EtcGMTminus13
        | [<JsonPropertyName("Etc/GMT-14")>] EtcGMTminus14
        | [<JsonPropertyName("Etc/GMT-2")>] EtcGMTminus2
        | [<JsonPropertyName("Etc/GMT-3")>] EtcGMTminus3
        | [<JsonPropertyName("Etc/GMT-4")>] EtcGMTminus4
        | [<JsonPropertyName("Etc/GMT-5")>] EtcGMTminus5
        | [<JsonPropertyName("Etc/GMT-6")>] EtcGMTminus6
        | [<JsonPropertyName("Etc/GMT-7")>] EtcGMTminus7
        | [<JsonPropertyName("Etc/GMT-8")>] EtcGMTminus8
        | [<JsonPropertyName("Etc/GMT-9")>] EtcGMTminus9
        | [<JsonPropertyName("Etc/GMT0")>] EtcGMT0
        | [<JsonPropertyName("Etc/Greenwich")>] EtcGreenwich
        | [<JsonPropertyName("Etc/UCT")>] EtcUCT
        | [<JsonPropertyName("Etc/UTC")>] EtcUTC
        | [<JsonPropertyName("Etc/Universal")>] EtcUniversal
        | [<JsonPropertyName("Etc/Zulu")>] EtcZulu
        | [<JsonPropertyName("Europe/Amsterdam")>] EuropeAmsterdam
        | [<JsonPropertyName("Europe/Andorra")>] EuropeAndorra
        | [<JsonPropertyName("Europe/Astrakhan")>] EuropeAstrakhan
        | [<JsonPropertyName("Europe/Athens")>] EuropeAthens
        | [<JsonPropertyName("Europe/Belfast")>] EuropeBelfast
        | [<JsonPropertyName("Europe/Belgrade")>] EuropeBelgrade
        | [<JsonPropertyName("Europe/Berlin")>] EuropeBerlin
        | [<JsonPropertyName("Europe/Bratislava")>] EuropeBratislava
        | [<JsonPropertyName("Europe/Brussels")>] EuropeBrussels
        | [<JsonPropertyName("Europe/Bucharest")>] EuropeBucharest
        | [<JsonPropertyName("Europe/Budapest")>] EuropeBudapest
        | [<JsonPropertyName("Europe/Busingen")>] EuropeBusingen
        | [<JsonPropertyName("Europe/Chisinau")>] EuropeChisinau
        | [<JsonPropertyName("Europe/Copenhagen")>] EuropeCopenhagen
        | [<JsonPropertyName("Europe/Dublin")>] EuropeDublin
        | [<JsonPropertyName("Europe/Gibraltar")>] EuropeGibraltar
        | [<JsonPropertyName("Europe/Guernsey")>] EuropeGuernsey
        | [<JsonPropertyName("Europe/Helsinki")>] EuropeHelsinki
        | [<JsonPropertyName("Europe/Isle_of_Man")>] EuropeIsleOfMan
        | [<JsonPropertyName("Europe/Istanbul")>] EuropeIstanbul
        | [<JsonPropertyName("Europe/Jersey")>] EuropeJersey
        | [<JsonPropertyName("Europe/Kaliningrad")>] EuropeKaliningrad
        | [<JsonPropertyName("Europe/Kiev")>] EuropeKiev
        | [<JsonPropertyName("Europe/Kirov")>] EuropeKirov
        | [<JsonPropertyName("Europe/Kyiv")>] EuropeKyiv
        | [<JsonPropertyName("Europe/Lisbon")>] EuropeLisbon
        | [<JsonPropertyName("Europe/Ljubljana")>] EuropeLjubljana
        | [<JsonPropertyName("Europe/London")>] EuropeLondon
        | [<JsonPropertyName("Europe/Luxembourg")>] EuropeLuxembourg
        | [<JsonPropertyName("Europe/Madrid")>] EuropeMadrid
        | [<JsonPropertyName("Europe/Malta")>] EuropeMalta
        | [<JsonPropertyName("Europe/Mariehamn")>] EuropeMariehamn
        | [<JsonPropertyName("Europe/Minsk")>] EuropeMinsk
        | [<JsonPropertyName("Europe/Monaco")>] EuropeMonaco
        | [<JsonPropertyName("Europe/Moscow")>] EuropeMoscow
        | [<JsonPropertyName("Europe/Nicosia")>] EuropeNicosia
        | [<JsonPropertyName("Europe/Oslo")>] EuropeOslo
        | [<JsonPropertyName("Europe/Paris")>] EuropeParis
        | [<JsonPropertyName("Europe/Podgorica")>] EuropePodgorica
        | [<JsonPropertyName("Europe/Prague")>] EuropePrague
        | [<JsonPropertyName("Europe/Riga")>] EuropeRiga
        | [<JsonPropertyName("Europe/Rome")>] EuropeRome
        | [<JsonPropertyName("Europe/Samara")>] EuropeSamara
        | [<JsonPropertyName("Europe/San_Marino")>] EuropeSanMarino
        | [<JsonPropertyName("Europe/Sarajevo")>] EuropeSarajevo
        | [<JsonPropertyName("Europe/Saratov")>] EuropeSaratov
        | [<JsonPropertyName("Europe/Simferopol")>] EuropeSimferopol
        | [<JsonPropertyName("Europe/Skopje")>] EuropeSkopje
        | [<JsonPropertyName("Europe/Sofia")>] EuropeSofia
        | [<JsonPropertyName("Europe/Stockholm")>] EuropeStockholm
        | [<JsonPropertyName("Europe/Tallinn")>] EuropeTallinn
        | [<JsonPropertyName("Europe/Tirane")>] EuropeTirane
        | [<JsonPropertyName("Europe/Tiraspol")>] EuropeTiraspol
        | [<JsonPropertyName("Europe/Ulyanovsk")>] EuropeUlyanovsk
        | [<JsonPropertyName("Europe/Uzhgorod")>] EuropeUzhgorod
        | [<JsonPropertyName("Europe/Vaduz")>] EuropeVaduz
        | [<JsonPropertyName("Europe/Vatican")>] EuropeVatican
        | [<JsonPropertyName("Europe/Vienna")>] EuropeVienna
        | [<JsonPropertyName("Europe/Vilnius")>] EuropeVilnius
        | [<JsonPropertyName("Europe/Volgograd")>] EuropeVolgograd
        | [<JsonPropertyName("Europe/Warsaw")>] EuropeWarsaw
        | [<JsonPropertyName("Europe/Zagreb")>] EuropeZagreb
        | [<JsonPropertyName("Europe/Zaporozhye")>] EuropeZaporozhye
        | [<JsonPropertyName("Europe/Zurich")>] EuropeZurich
        | [<JsonPropertyName("Factory")>] Factory
        | [<JsonPropertyName("GB")>] GB
        | [<JsonPropertyName("GB-Eire")>] GBEire
        | [<JsonPropertyName("GMT")>] GMT
        | [<JsonPropertyName("GMT+0")>] GMTplus0
        | [<JsonPropertyName("GMT-0")>] GMTminus0
        | [<JsonPropertyName("GMT0")>] GMT0
        | [<JsonPropertyName("Greenwich")>] Greenwich
        | [<JsonPropertyName("HST")>] HST
        | [<JsonPropertyName("Hongkong")>] Hongkong
        | [<JsonPropertyName("Iceland")>] Iceland
        | [<JsonPropertyName("Indian/Antananarivo")>] IndianAntananarivo
        | [<JsonPropertyName("Indian/Chagos")>] IndianChagos
        | [<JsonPropertyName("Indian/Christmas")>] IndianChristmas
        | [<JsonPropertyName("Indian/Cocos")>] IndianCocos
        | [<JsonPropertyName("Indian/Comoro")>] IndianComoro
        | [<JsonPropertyName("Indian/Kerguelen")>] IndianKerguelen
        | [<JsonPropertyName("Indian/Mahe")>] IndianMahe
        | [<JsonPropertyName("Indian/Maldives")>] IndianMaldives
        | [<JsonPropertyName("Indian/Mauritius")>] IndianMauritius
        | [<JsonPropertyName("Indian/Mayotte")>] IndianMayotte
        | [<JsonPropertyName("Indian/Reunion")>] IndianReunion
        | [<JsonPropertyName("Iran")>] Iran
        | [<JsonPropertyName("Israel")>] Israel
        | [<JsonPropertyName("Jamaica")>] Jamaica
        | [<JsonPropertyName("Japan")>] Japan
        | [<JsonPropertyName("Kwajalein")>] Kwajalein
        | [<JsonPropertyName("Libya")>] Libya
        | [<JsonPropertyName("MET")>] MET
        | [<JsonPropertyName("MST")>] MST
        | [<JsonPropertyName("MST7MDT")>] MST7MDT
        | [<JsonPropertyName("Mexico/BajaNorte")>] MexicoBajaNorte
        | [<JsonPropertyName("Mexico/BajaSur")>] MexicoBajaSur
        | [<JsonPropertyName("Mexico/General")>] MexicoGeneral
        | [<JsonPropertyName("NZ")>] NZ
        | [<JsonPropertyName("NZ-CHAT")>] NZCHAT
        | [<JsonPropertyName("Navajo")>] Navajo
        | [<JsonPropertyName("PRC")>] PRC
        | [<JsonPropertyName("PST8PDT")>] PST8PDT
        | [<JsonPropertyName("Pacific/Apia")>] PacificApia
        | [<JsonPropertyName("Pacific/Auckland")>] PacificAuckland
        | [<JsonPropertyName("Pacific/Bougainville")>] PacificBougainville
        | [<JsonPropertyName("Pacific/Chatham")>] PacificChatham
        | [<JsonPropertyName("Pacific/Chuuk")>] PacificChuuk
        | [<JsonPropertyName("Pacific/Easter")>] PacificEaster
        | [<JsonPropertyName("Pacific/Efate")>] PacificEfate
        | [<JsonPropertyName("Pacific/Enderbury")>] PacificEnderbury
        | [<JsonPropertyName("Pacific/Fakaofo")>] PacificFakaofo
        | [<JsonPropertyName("Pacific/Fiji")>] PacificFiji
        | [<JsonPropertyName("Pacific/Funafuti")>] PacificFunafuti
        | [<JsonPropertyName("Pacific/Galapagos")>] PacificGalapagos
        | [<JsonPropertyName("Pacific/Gambier")>] PacificGambier
        | [<JsonPropertyName("Pacific/Guadalcanal")>] PacificGuadalcanal
        | [<JsonPropertyName("Pacific/Guam")>] PacificGuam
        | [<JsonPropertyName("Pacific/Honolulu")>] PacificHonolulu
        | [<JsonPropertyName("Pacific/Johnston")>] PacificJohnston
        | [<JsonPropertyName("Pacific/Kanton")>] PacificKanton
        | [<JsonPropertyName("Pacific/Kiritimati")>] PacificKiritimati
        | [<JsonPropertyName("Pacific/Kosrae")>] PacificKosrae
        | [<JsonPropertyName("Pacific/Kwajalein")>] PacificKwajalein
        | [<JsonPropertyName("Pacific/Majuro")>] PacificMajuro
        | [<JsonPropertyName("Pacific/Marquesas")>] PacificMarquesas
        | [<JsonPropertyName("Pacific/Midway")>] PacificMidway
        | [<JsonPropertyName("Pacific/Nauru")>] PacificNauru
        | [<JsonPropertyName("Pacific/Niue")>] PacificNiue
        | [<JsonPropertyName("Pacific/Norfolk")>] PacificNorfolk
        | [<JsonPropertyName("Pacific/Noumea")>] PacificNoumea
        | [<JsonPropertyName("Pacific/Pago_Pago")>] PacificPagoPago
        | [<JsonPropertyName("Pacific/Palau")>] PacificPalau
        | [<JsonPropertyName("Pacific/Pitcairn")>] PacificPitcairn
        | [<JsonPropertyName("Pacific/Pohnpei")>] PacificPohnpei
        | [<JsonPropertyName("Pacific/Ponape")>] PacificPonape
        | [<JsonPropertyName("Pacific/Port_Moresby")>] PacificPortMoresby
        | [<JsonPropertyName("Pacific/Rarotonga")>] PacificRarotonga
        | [<JsonPropertyName("Pacific/Saipan")>] PacificSaipan
        | [<JsonPropertyName("Pacific/Samoa")>] PacificSamoa
        | [<JsonPropertyName("Pacific/Tahiti")>] PacificTahiti
        | [<JsonPropertyName("Pacific/Tarawa")>] PacificTarawa
        | [<JsonPropertyName("Pacific/Tongatapu")>] PacificTongatapu
        | [<JsonPropertyName("Pacific/Truk")>] PacificTruk
        | [<JsonPropertyName("Pacific/Wake")>] PacificWake
        | [<JsonPropertyName("Pacific/Wallis")>] PacificWallis
        | [<JsonPropertyName("Pacific/Yap")>] PacificYap
        | [<JsonPropertyName("Poland")>] Poland
        | [<JsonPropertyName("Portugal")>] Portugal
        | [<JsonPropertyName("ROC")>] ROC
        | [<JsonPropertyName("ROK")>] ROK
        | [<JsonPropertyName("Singapore")>] Singapore
        | [<JsonPropertyName("Turkey")>] Turkey
        | [<JsonPropertyName("UCT")>] UCT
        | [<JsonPropertyName("US/Alaska")>] USAlaska
        | [<JsonPropertyName("US/Aleutian")>] USAleutian
        | [<JsonPropertyName("US/Arizona")>] USArizona
        | [<JsonPropertyName("US/Central")>] USCentral
        | [<JsonPropertyName("US/East-Indiana")>] USEastIndiana
        | [<JsonPropertyName("US/Eastern")>] USEastern
        | [<JsonPropertyName("US/Hawaii")>] USHawaii
        | [<JsonPropertyName("US/Indiana-Starke")>] USIndianaStarke
        | [<JsonPropertyName("US/Michigan")>] USMichigan
        | [<JsonPropertyName("US/Mountain")>] USMountain
        | [<JsonPropertyName("US/Pacific")>] USPacific
        | [<JsonPropertyName("US/Pacific-New")>] USPacificNew
        | [<JsonPropertyName("US/Samoa")>] USSamoa
        | [<JsonPropertyName("UTC")>] UTC
        | [<JsonPropertyName("Universal")>] Universal
        | [<JsonPropertyName("W-SU")>] WSU
        | [<JsonPropertyName("WET")>] WET
        | [<JsonPropertyName("Zulu")>] Zulu

    type Create'Parameters =
        {
            /// The set of report columns to include in the report output. If omitted, the Report Type is run with its default column set.
            [<Config.Form>]
            Columns: string list option
            /// Connected account ID to filter for in the report run.
            [<Config.Form>]
            ConnectedAccount: string option
            /// Currency of objects to be included in the report run.
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// Ending timestamp of data to be included in the report run (exclusive).
            [<Config.Form>]
            IntervalEnd: DateTime option
            /// Starting timestamp of data to be included in the report run.
            [<Config.Form>]
            IntervalStart: DateTime option
            /// Payout ID by which to filter the report run.
            [<Config.Form>]
            Payout: string option
            /// Category of balance transactions to be included in the report run.
            [<Config.Form>]
            ReportingCategory: Create'ParametersReportingCategory option
            /// Defaults to `Etc/UTC`. The output timezone for all timestamps in the report. A list of possible time zone values is maintained at the [IANA Time Zone Database](http://www.iana.org/time-zones). Has no effect on `interval_start` or `interval_end`.
            [<Config.Form>]
            Timezone: Create'ParametersTimezone option
        }

    type Create'Parameters with
        static member New(?columns: string list, ?connectedAccount: string, ?currency: IsoTypes.IsoCurrencyCode, ?intervalEnd: DateTime, ?intervalStart: DateTime, ?payout: string, ?reportingCategory: Create'ParametersReportingCategory, ?timezone: Create'ParametersTimezone) =
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

    type CreateOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Parameters specifying how the report should be run. Different Report Types have different required and optional parameters, listed in the [API Access to Reports](https://docs.stripe.com/reporting/statements/api) documentation.
            [<Config.Form>]
            Parameters: Create'Parameters option
            /// The ID of the [report type](https://docs.stripe.com/reporting/statements/api#report-types) to run, such as `"balance.summary.1"`.
            [<Config.Form>]
            ReportType: string
        }

    type CreateOptions with
        static member New(reportType: string, ?expand: string list, ?parameters: Create'Parameters) =
            {
                ReportType = reportType
                Expand = expand
                Parameters = parameters
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            ReportRun: string
        }

    type RetrieveOptions with
        static member New(reportRun: string, ?expand: string list) =
            {
                ReportRun = reportRun
                Expand = expand
            }

    ///<p>Returns a list of Report Runs, with the most recent appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/reporting/report_runs"
        |> RestApi.getAsync<StripeList<ReportingReportRun>> settings qs

    ///<p>Creates a new object and begin running the report. (Certain report types require a <a href="https://stripe.com/docs/keys#test-live-modes">live-mode API key</a>.)</p>
    let Create settings (options: CreateOptions) =
        $"/v1/reporting/report_runs"
        |> RestApi.postAsync<_, ReportingReportRun> settings (Map.empty) options

    ///<p>Retrieves the details of an existing Report Run.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/reporting/report_runs/{options.ReportRun}"
        |> RestApi.getAsync<ReportingReportRun> settings qs

module ReportingReportTypes =

    type ListOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    type ListOptions with
        static member New(?expand: string list) =
            {
                Expand = expand
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            ReportType: string
        }

    type RetrieveOptions with
        static member New(reportType: string, ?expand: string list) =
            {
                ReportType = reportType
                Expand = expand
            }

    ///<p>Returns a full list of Report Types.</p>
    let List settings (options: ListOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/reporting/report_types"
        |> RestApi.getAsync<StripeList<ReportingReportType>> settings qs

    ///<p>Retrieves the details of a Report Type. (Certain report types require a <a href="https://stripe.com/docs/keys#test-live-modes">live-mode API key</a>.)</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/reporting/report_types/{options.ReportType}"
        |> RestApi.getAsync<ReportingReportType> settings qs

