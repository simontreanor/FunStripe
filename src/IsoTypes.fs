namespace FunStripe

open System.Text.Json.Serialization

///ISO 3166-1 alpha-2 country codes and ISO 4217 currency codes for strongly-typed Stripe API requests and responses.
module IsoTypes =

    ///ISO 4217 three-letter currency codes. Names use uppercase ISO notation; JSON serializes to lowercase as expected by the Stripe API.
    type IsoCurrencyCode =
        | AED
        | AFN
        | ALL
        | AMD
        | ANG
        | AOA
        | ARS
        | AUD
        | AWG
        | AZN
        | BAM
        | BBD
        | BDT
        | BGN
        | BHD
        | BIF
        | BMD
        | BND
        | BOB
        | BRL
        | BSD
        | BTN
        | BWP
        | BYN
        | BZD
        | CAD
        | CDF
        | CHF
        | CLP
        | CNY
        | COP
        | CRC
        | CUP
        | CVE
        | CZK
        | DJF
        | DKK
        | DOP
        | DZD
        | EGP
        | ERN
        | ETB
        | EUR
        | FJD
        | FKP
        | GBP
        | GEL
        | GHS
        | GIP
        | GMD
        | GNF
        | GTQ
        | GYD
        | HKD
        | HNL
        | HRK
        | HTG
        | HUF
        | IDR
        | ILS
        | INR
        | IQD
        | IRR
        | ISK
        | JMD
        | JOD
        | JPY
        | KES
        | KGS
        | KHR
        | KMF
        | KPW
        | KRW
        | KWD
        | KYD
        | KZT
        | LAK
        | LBP
        | LKR
        | LRD
        | LSL
        | LYD
        | MAD
        | MDL
        | MGA
        | MKD
        | MMK
        | MNT
        | MOP
        | MRU
        | MUR
        | MVR
        | MWK
        | MXN
        | MYR
        | MZN
        | NAD
        | NGN
        | NIO
        | NOK
        | NPR
        | NZD
        | OMR
        | PAB
        | PEN
        | PGK
        | PHP
        | PKR
        | PLN
        | PYG
        | QAR
        | RON
        | RSD
        | RUB
        | RWF
        | SAR
        | SBD
        | SCR
        | SDG
        | SEK
        | SGD
        | SHP
        | SLE
        | SLL
        | SOS
        | SRD
        | STN
        | SVC
        | SYP
        | SZL
        | THB
        | TJS
        | TMT
        | TND
        | TOP
        | TRY
        | TTD
        | TWD
        | TZS
        | UAH
        | UGX
        | USD
        | UYU
        | UZS
        | VES
        | VND
        | VUV
        | WST
        | XAF
        | XCD
        | XOF
        | XPF
        | YER
        | ZAR
        | ZMW
        | ZWL

    ///ISO 3166-1 alpha-2 two-letter country codes. The JsonPropertyName attribute ensures correct uppercase serialization for the Stripe API.
    type IsoCountryCode =
        | [<JsonPropertyName("AC")>] AC
        | [<JsonPropertyName("AD")>] AD
        | [<JsonPropertyName("AE")>] AE
        | [<JsonPropertyName("AF")>] AF
        | [<JsonPropertyName("AG")>] AG
        | [<JsonPropertyName("AI")>] AI
        | [<JsonPropertyName("AL")>] AL
        | [<JsonPropertyName("AM")>] AM
        | [<JsonPropertyName("AO")>] AO
        | [<JsonPropertyName("AQ")>] AQ
        | [<JsonPropertyName("AR")>] AR
        | [<JsonPropertyName("AS")>] AS'
        | [<JsonPropertyName("AT")>] AT
        | [<JsonPropertyName("AU")>] AU
        | [<JsonPropertyName("AW")>] AW
        | [<JsonPropertyName("AX")>] AX
        | [<JsonPropertyName("AZ")>] AZ
        | [<JsonPropertyName("BA")>] BA
        | [<JsonPropertyName("BB")>] BB
        | [<JsonPropertyName("BD")>] BD
        | [<JsonPropertyName("BE")>] BE
        | [<JsonPropertyName("BF")>] BF
        | [<JsonPropertyName("BG")>] BG
        | [<JsonPropertyName("BH")>] BH
        | [<JsonPropertyName("BI")>] BI
        | [<JsonPropertyName("BJ")>] BJ
        | [<JsonPropertyName("BL")>] BL
        | [<JsonPropertyName("BM")>] BM
        | [<JsonPropertyName("BN")>] BN
        | [<JsonPropertyName("BO")>] BO
        | [<JsonPropertyName("BQ")>] BQ
        | [<JsonPropertyName("BR")>] BR
        | [<JsonPropertyName("BS")>] BS
        | [<JsonPropertyName("BT")>] BT
        | [<JsonPropertyName("BV")>] BV
        | [<JsonPropertyName("BW")>] BW
        | [<JsonPropertyName("BY")>] BY
        | [<JsonPropertyName("BZ")>] BZ
        | [<JsonPropertyName("CA")>] CA
        | [<JsonPropertyName("CC")>] CC
        | [<JsonPropertyName("CD")>] CD
        | [<JsonPropertyName("CF")>] CF
        | [<JsonPropertyName("CG")>] CG
        | [<JsonPropertyName("CH")>] CH
        | [<JsonPropertyName("CI")>] CI
        | [<JsonPropertyName("CK")>] CK
        | [<JsonPropertyName("CL")>] CL
        | [<JsonPropertyName("CM")>] CM
        | [<JsonPropertyName("CN")>] CN
        | [<JsonPropertyName("CO")>] CO
        | [<JsonPropertyName("CR")>] CR
        | [<JsonPropertyName("CU")>] CU
        | [<JsonPropertyName("CV")>] CV
        | [<JsonPropertyName("CW")>] CW
        | [<JsonPropertyName("CX")>] CX
        | [<JsonPropertyName("CY")>] CY
        | [<JsonPropertyName("CZ")>] CZ
        | [<JsonPropertyName("DE")>] DE
        | [<JsonPropertyName("DJ")>] DJ
        | [<JsonPropertyName("DK")>] DK
        | [<JsonPropertyName("DM")>] DM
        | [<JsonPropertyName("DO")>] DO'
        | [<JsonPropertyName("DZ")>] DZ
        | [<JsonPropertyName("EC")>] EC
        | [<JsonPropertyName("EE")>] EE
        | [<JsonPropertyName("EG")>] EG
        | [<JsonPropertyName("EH")>] EH
        | [<JsonPropertyName("ER")>] ER
        | [<JsonPropertyName("ES")>] ES
        | [<JsonPropertyName("ET")>] ET
        | [<JsonPropertyName("FI")>] FI
        | [<JsonPropertyName("FJ")>] FJ
        | [<JsonPropertyName("FK")>] FK
        | [<JsonPropertyName("FM")>] FM
        | [<JsonPropertyName("FO")>] FO
        | [<JsonPropertyName("FR")>] FR
        | [<JsonPropertyName("GA")>] GA
        | [<JsonPropertyName("GB")>] GB
        | [<JsonPropertyName("GD")>] GD
        | [<JsonPropertyName("GE")>] GE
        | [<JsonPropertyName("GF")>] GF
        | [<JsonPropertyName("GG")>] GG
        | [<JsonPropertyName("GH")>] GH
        | [<JsonPropertyName("GI")>] GI
        | [<JsonPropertyName("GL")>] GL
        | [<JsonPropertyName("GM")>] GM
        | [<JsonPropertyName("GN")>] GN
        | [<JsonPropertyName("GP")>] GP
        | [<JsonPropertyName("GQ")>] GQ
        | [<JsonPropertyName("GR")>] GR
        | [<JsonPropertyName("GS")>] GS
        | [<JsonPropertyName("GT")>] GT
        | [<JsonPropertyName("GU")>] GU
        | [<JsonPropertyName("GW")>] GW
        | [<JsonPropertyName("GY")>] GY
        | [<JsonPropertyName("HK")>] HK
        | [<JsonPropertyName("HM")>] HM
        | [<JsonPropertyName("HN")>] HN
        | [<JsonPropertyName("HR")>] HR
        | [<JsonPropertyName("HT")>] HT
        | [<JsonPropertyName("HU")>] HU
        | [<JsonPropertyName("ID")>] ID'
        | [<JsonPropertyName("IE")>] IE
        | [<JsonPropertyName("IL")>] IL
        | [<JsonPropertyName("IM")>] IM
        | [<JsonPropertyName("IN")>] IN'
        | [<JsonPropertyName("IO")>] IO
        | [<JsonPropertyName("IQ")>] IQ
        | [<JsonPropertyName("IR")>] IR
        | [<JsonPropertyName("IS")>] IS'
        | [<JsonPropertyName("IT")>] IT
        | [<JsonPropertyName("JE")>] JE
        | [<JsonPropertyName("JM")>] JM
        | [<JsonPropertyName("JO")>] JO
        | [<JsonPropertyName("JP")>] JP
        | [<JsonPropertyName("KE")>] KE
        | [<JsonPropertyName("KG")>] KG
        | [<JsonPropertyName("KH")>] KH
        | [<JsonPropertyName("KI")>] KI
        | [<JsonPropertyName("KM")>] KM
        | [<JsonPropertyName("KN")>] KN
        | [<JsonPropertyName("KP")>] KP
        | [<JsonPropertyName("KR")>] KR
        | [<JsonPropertyName("KW")>] KW
        | [<JsonPropertyName("KY")>] KY
        | [<JsonPropertyName("KZ")>] KZ
        | [<JsonPropertyName("LA")>] LA
        | [<JsonPropertyName("LB")>] LB
        | [<JsonPropertyName("LC")>] LC
        | [<JsonPropertyName("LI")>] LI
        | [<JsonPropertyName("LK")>] LK
        | [<JsonPropertyName("LR")>] LR
        | [<JsonPropertyName("LS")>] LS
        | [<JsonPropertyName("LT")>] LT'
        | [<JsonPropertyName("LU")>] LU
        | [<JsonPropertyName("LV")>] LV
        | [<JsonPropertyName("LY")>] LY
        | [<JsonPropertyName("MA")>] MA
        | [<JsonPropertyName("MC")>] MC
        | [<JsonPropertyName("MD")>] MD
        | [<JsonPropertyName("ME")>] ME
        | [<JsonPropertyName("MF")>] MF
        | [<JsonPropertyName("MG")>] MG
        | [<JsonPropertyName("MH")>] MH
        | [<JsonPropertyName("MK")>] MK
        | [<JsonPropertyName("ML")>] ML
        | [<JsonPropertyName("MM")>] MM
        | [<JsonPropertyName("MN")>] MN
        | [<JsonPropertyName("MO")>] MO
        | [<JsonPropertyName("MP")>] MP
        | [<JsonPropertyName("MQ")>] MQ
        | [<JsonPropertyName("MR")>] MR
        | [<JsonPropertyName("MS")>] MS
        | [<JsonPropertyName("MT")>] MT
        | [<JsonPropertyName("MU")>] MU
        | [<JsonPropertyName("MV")>] MV
        | [<JsonPropertyName("MW")>] MW
        | [<JsonPropertyName("MX")>] MX
        | [<JsonPropertyName("MY")>] MY
        | [<JsonPropertyName("MZ")>] MZ
        | [<JsonPropertyName("NA")>] NA
        | [<JsonPropertyName("NC")>] NC
        | [<JsonPropertyName("NE")>] NE
        | [<JsonPropertyName("NF")>] NF
        | [<JsonPropertyName("NG")>] NG
        | [<JsonPropertyName("NI")>] NI
        | [<JsonPropertyName("NL")>] NL
        | [<JsonPropertyName("NO")>] NO'
        | [<JsonPropertyName("NP")>] NP
        | [<JsonPropertyName("NR")>] NR
        | [<JsonPropertyName("NU")>] NU
        | [<JsonPropertyName("NZ")>] NZ
        | [<JsonPropertyName("OM")>] OM
        | [<JsonPropertyName("PA")>] PA
        | [<JsonPropertyName("PE")>] PE
        | [<JsonPropertyName("PF")>] PF
        | [<JsonPropertyName("PG")>] PG
        | [<JsonPropertyName("PH")>] PH
        | [<JsonPropertyName("PK")>] PK
        | [<JsonPropertyName("PL")>] PL
        | [<JsonPropertyName("PM")>] PM
        | [<JsonPropertyName("PN")>] PN
        | [<JsonPropertyName("PR")>] PR
        | [<JsonPropertyName("PS")>] PS
        | [<JsonPropertyName("PT")>] PT
        | [<JsonPropertyName("PW")>] PW
        | [<JsonPropertyName("PY")>] PY
        | [<JsonPropertyName("QA")>] QA
        | [<JsonPropertyName("RE")>] RE
        | [<JsonPropertyName("RO")>] RO
        | [<JsonPropertyName("RS")>] RS
        | [<JsonPropertyName("RU")>] RU
        | [<JsonPropertyName("RW")>] RW
        | [<JsonPropertyName("SA")>] SA
        | [<JsonPropertyName("SB")>] SB
        | [<JsonPropertyName("SC")>] SC
        | [<JsonPropertyName("SD")>] SD
        | [<JsonPropertyName("SE")>] SE
        | [<JsonPropertyName("SG")>] SG
        | [<JsonPropertyName("SH")>] SH
        | [<JsonPropertyName("SI")>] SI
        | [<JsonPropertyName("SJ")>] SJ
        | [<JsonPropertyName("SK")>] SK
        | [<JsonPropertyName("SL")>] SL
        | [<JsonPropertyName("SM")>] SM
        | [<JsonPropertyName("SN")>] SN
        | [<JsonPropertyName("SO")>] SO
        | [<JsonPropertyName("SR")>] SR
        | [<JsonPropertyName("SS")>] SS
        | [<JsonPropertyName("ST")>] ST
        | [<JsonPropertyName("SV")>] SV
        | [<JsonPropertyName("SX")>] SX
        | [<JsonPropertyName("SY")>] SY
        | [<JsonPropertyName("SZ")>] SZ
        | [<JsonPropertyName("TC")>] TC
        | [<JsonPropertyName("TD")>] TD
        | [<JsonPropertyName("TF")>] TF
        | [<JsonPropertyName("TG")>] TG
        | [<JsonPropertyName("TH")>] TH
        | [<JsonPropertyName("TJ")>] TJ
        | [<JsonPropertyName("TK")>] TK
        | [<JsonPropertyName("TL")>] TL
        | [<JsonPropertyName("TM")>] TM
        | [<JsonPropertyName("TN")>] TN
        | [<JsonPropertyName("TO")>] TO
        | [<JsonPropertyName("TR")>] TR
        | [<JsonPropertyName("TT")>] TT
        | [<JsonPropertyName("TV")>] TV
        | [<JsonPropertyName("TW")>] TW
        | [<JsonPropertyName("TZ")>] TZ
        | [<JsonPropertyName("UA")>] UA
        | [<JsonPropertyName("UG")>] UG
        | [<JsonPropertyName("UM")>] UM
        | [<JsonPropertyName("US")>] US
        | [<JsonPropertyName("UY")>] UY
        | [<JsonPropertyName("UZ")>] UZ
        | [<JsonPropertyName("VA")>] VA
        | [<JsonPropertyName("VC")>] VC
        | [<JsonPropertyName("VE")>] VE
        | [<JsonPropertyName("VG")>] VG
        | [<JsonPropertyName("VI")>] VI
        | [<JsonPropertyName("VN")>] VN
        | [<JsonPropertyName("VU")>] VU
        | [<JsonPropertyName("WF")>] WF
        | [<JsonPropertyName("WS")>] WS
        | [<JsonPropertyName("XK")>] XK
        | [<JsonPropertyName("YE")>] YE
        | [<JsonPropertyName("YT")>] YT
        | [<JsonPropertyName("ZA")>] ZA
        | [<JsonPropertyName("ZM")>] ZM
        | [<JsonPropertyName("ZW")>] ZW
