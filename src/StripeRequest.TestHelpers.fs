namespace FunStripe.StripeRequest

open FunStripe
open System.Text.Json.Serialization
open FunStripe.StripeModel
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
module TestHelpersConfirmationTokens =

    type Create'PaymentMethodDataAcssDebit = {
        ///<summary>Customer's bank account number.</summary>
        [<Config.Form>]AccountNumber: string option
        ///<summary>Institution number of the customer's bank.</summary>
        [<Config.Form>]InstitutionNumber: string option
        ///<summary>Transit number of the customer's bank.</summary>
        [<Config.Form>]TransitNumber: string option
    }
    with
        static member New(?accountNumber: string, ?institutionNumber: string, ?transitNumber: string) =
            {
                AccountNumber = accountNumber
                InstitutionNumber = institutionNumber
                TransitNumber = transitNumber
            }

    type Create'PaymentMethodDataAuBecsDebit = {
        ///<summary>The account number for the bank account.</summary>
        [<Config.Form>]AccountNumber: string option
        ///<summary>Bank-State-Branch number of the bank account.</summary>
        [<Config.Form>]BsbNumber: string option
    }
    with
        static member New(?accountNumber: string, ?bsbNumber: string) =
            {
                AccountNumber = accountNumber
                BsbNumber = bsbNumber
            }

    type Create'PaymentMethodDataBacsDebit = {
        ///<summary>Account number of the bank account that the funds will be debited from.</summary>
        [<Config.Form>]AccountNumber: string option
        ///<summary>Sort code of the bank account. (e.g., `10-20-30`)</summary>
        [<Config.Form>]SortCode: string option
    }
    with
        static member New(?accountNumber: string, ?sortCode: string) =
            {
                AccountNumber = accountNumber
                SortCode = sortCode
            }

    type Create'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'PaymentMethodDataBillingDetails = {
        ///<summary>Billing address.</summary>
        [<Config.Form>]Address: Choice<Create'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string> option
        ///<summary>Email address.</summary>
        [<Config.Form>]Email: Choice<string,string> option
        ///<summary>Full name.</summary>
        [<Config.Form>]Name: Choice<string,string> option
        ///<summary>Billing phone number (including extension).</summary>
        [<Config.Form>]Phone: Choice<string,string> option
        ///<summary>Taxpayer identification number. Used only for transactions between LATAM buyers and non-LATAM sellers.</summary>
        [<Config.Form>]TaxId: string option
    }
    with
        static member New(?address: Choice<Create'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string>, ?email: Choice<string,string>, ?name: Choice<string,string>, ?phone: Choice<string,string>, ?taxId: string) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
                TaxId = taxId
            }

    type Create'PaymentMethodDataBoleto = {
        ///<summary>The tax ID of the customer (CPF for individual consumers or CNPJ for businesses consumers)</summary>
        [<Config.Form>]TaxId: string option
    }
    with
        static member New(?taxId: string) =
            {
                TaxId = taxId
            }

    type Create'PaymentMethodDataEpsBank =
    | ArzteUndApothekerBank
    | AustrianAnadiBankAg
    | BankAustria
    | BankhausCarlSpangler
    | BankhausSchelhammerUndSchatteraAg
    | BawagPskAg
    | BksBankAg
    | BrullKallmusBankAg
    | BtvVierLanderBank
    | CapitalBankGraweGruppeAg
    | DeutscheBankAg
    | Dolomitenbank
    | EasybankAg
    | ErsteBankUndSparkassen
    | HypoAlpeadriabankInternationalAg
    | HypoBankBurgenlandAktiengesellschaft
    | HypoNoeLbFurNiederosterreichUWien
    | HypoOberosterreichSalzburgSteiermark
    | HypoTirolBankAg
    | HypoVorarlbergBankAg
    | MarchfelderBank
    | OberbankAg
    | RaiffeisenBankengruppeOsterreich
    | SchoellerbankAg
    | SpardaBankWien
    | VolksbankGruppe
    | VolkskreditbankAg
    | VrBankBraunau

    type Create'PaymentMethodDataEps = {
        ///<summary>The customer's bank.</summary>
        [<Config.Form>]Bank: Create'PaymentMethodDataEpsBank option
    }
    with
        static member New(?bank: Create'PaymentMethodDataEpsBank) =
            {
                Bank = bank
            }

    type Create'PaymentMethodDataFpxAccountHolderType =
    | Company
    | Individual

    type Create'PaymentMethodDataFpxBank =
    | AffinBank
    | Agrobank
    | AllianceBank
    | Ambank
    | BankIslam
    | BankMuamalat
    | BankOfChina
    | BankRakyat
    | Bsn
    | Cimb
    | DeutscheBank
    | HongLeongBank
    | Hsbc
    | Kfh
    | Maybank2e
    | Maybank2u
    | Ocbc
    | PbEnterprise
    | PublicBank
    | Rhb
    | StandardChartered
    | Uob

    type Create'PaymentMethodDataFpx = {
        ///<summary>Account holder type for FPX transaction</summary>
        [<Config.Form>]AccountHolderType: Create'PaymentMethodDataFpxAccountHolderType option
        ///<summary>The customer's bank.</summary>
        [<Config.Form>]Bank: Create'PaymentMethodDataFpxBank option
    }
    with
        static member New(?accountHolderType: Create'PaymentMethodDataFpxAccountHolderType, ?bank: Create'PaymentMethodDataFpxBank) =
            {
                AccountHolderType = accountHolderType
                Bank = bank
            }

    type Create'PaymentMethodDataIdealBank =
    | AbnAmro
    | Adyen
    | AsnBank
    | Bunq
    | Buut
    | Finom
    | Handelsbanken
    | Ing
    | Knab
    | Mollie
    | Moneyou
    | N26
    | Nn
    | Rabobank
    | Regiobank
    | Revolut
    | SnsBank
    | TriodosBank
    | VanLanschot
    | Yoursafe

    type Create'PaymentMethodDataIdeal = {
        ///<summary>The customer's bank. Only use this parameter for existing customers. Don't use it for new customers.</summary>
        [<Config.Form>]Bank: Create'PaymentMethodDataIdealBank option
    }
    with
        static member New(?bank: Create'PaymentMethodDataIdealBank) =
            {
                Bank = bank
            }

    type Create'PaymentMethodDataKlarnaDob = {
        ///<summary>The day of birth, between 1 and 31.</summary>
        [<Config.Form>]Day: int option
        ///<summary>The month of birth, between 1 and 12.</summary>
        [<Config.Form>]Month: int option
        ///<summary>The four-digit year of birth.</summary>
        [<Config.Form>]Year: int option
    }
    with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Create'PaymentMethodDataKlarna = {
        ///<summary>Customer's date of birth</summary>
        [<Config.Form>]Dob: Create'PaymentMethodDataKlarnaDob option
    }
    with
        static member New(?dob: Create'PaymentMethodDataKlarnaDob) =
            {
                Dob = dob
            }

    type Create'PaymentMethodDataNaverPayFunding =
    | Card
    | Points

    type Create'PaymentMethodDataNaverPay = {
        ///<summary>Whether to use Naver Pay points or a card to fund this transaction. If not provided, this defaults to `card`.</summary>
        [<Config.Form>]Funding: Create'PaymentMethodDataNaverPayFunding option
    }
    with
        static member New(?funding: Create'PaymentMethodDataNaverPayFunding) =
            {
                Funding = funding
            }

    type Create'PaymentMethodDataNzBankAccount = {
        ///<summary>The name on the bank account. Only required if the account holder name is different from the name of the authorized signatory collected in the PaymentMethod’s billing details.</summary>
        [<Config.Form>]AccountHolderName: string option
        ///<summary>The account number for the bank account.</summary>
        [<Config.Form>]AccountNumber: string option
        ///<summary>The numeric code for the bank account's bank.</summary>
        [<Config.Form>]BankCode: string option
        ///<summary>The numeric code for the bank account's bank branch.</summary>
        [<Config.Form>]BranchCode: string option
        [<Config.Form>]Reference: string option
        ///<summary>The suffix of the bank account number.</summary>
        [<Config.Form>]Suffix: string option
    }
    with
        static member New(?accountHolderName: string, ?accountNumber: string, ?bankCode: string, ?branchCode: string, ?reference: string, ?suffix: string) =
            {
                AccountHolderName = accountHolderName
                AccountNumber = accountNumber
                BankCode = bankCode
                BranchCode = branchCode
                Reference = reference
                Suffix = suffix
            }

    type Create'PaymentMethodDataP24Bank =
    | AliorBank
    | BankMillennium
    | BankNowyBfgSa
    | BankPekaoSa
    | BankiSpbdzielcze
    | Blik
    | BnpParibas
    | Boz
    | CitiHandlowy
    | CreditAgricole
    | Envelobank
    | EtransferPocztowy24
    | GetinBank
    | Ideabank
    | Ing
    | Inteligo
    | MbankMtransfer
    | NestPrzelew
    | NoblePay
    | PbacZIpko
    | PlusBank
    | SantanderPrzelew24
    | TmobileUsbugiBankowe
    | ToyotaBank
    | Velobank
    | VolkswagenBank

    type Create'PaymentMethodDataP24 = {
        ///<summary>The customer's bank.</summary>
        [<Config.Form>]Bank: Create'PaymentMethodDataP24Bank option
    }
    with
        static member New(?bank: Create'PaymentMethodDataP24Bank) =
            {
                Bank = bank
            }

    type Create'PaymentMethodDataPayto = {
        ///<summary>The account number for the bank account.</summary>
        [<Config.Form>]AccountNumber: string option
        ///<summary>Bank-State-Branch number of the bank account.</summary>
        [<Config.Form>]BsbNumber: string option
        ///<summary>The PayID alias for the bank account.</summary>
        [<Config.Form>]PayId: string option
    }
    with
        static member New(?accountNumber: string, ?bsbNumber: string, ?payId: string) =
            {
                AccountNumber = accountNumber
                BsbNumber = bsbNumber
                PayId = payId
            }

    type Create'PaymentMethodDataRadarOptions = {
        ///<summary>A [Radar Session](https://docs.stripe.com/radar/radar-session) is a snapshot of the browser metadata and device details that help Radar make more accurate predictions on your payments.</summary>
        [<Config.Form>]Session: string option
    }
    with
        static member New(?session: string) =
            {
                Session = session
            }

    type Create'PaymentMethodDataSepaDebit = {
        ///<summary>IBAN of the bank account.</summary>
        [<Config.Form>]Iban: string option
    }
    with
        static member New(?iban: string) =
            {
                Iban = iban
            }

    type Create'PaymentMethodDataSofortCountry =
    | [<JsonPropertyName("AT")>] AT
    | [<JsonPropertyName("BE")>] BE
    | [<JsonPropertyName("DE")>] DE
    | [<JsonPropertyName("ES")>] ES
    | [<JsonPropertyName("IT")>] IT
    | [<JsonPropertyName("NL")>] NL

    type Create'PaymentMethodDataSofort = {
        ///<summary>Two-letter ISO code representing the country the bank account is located in.</summary>
        [<Config.Form>]Country: Create'PaymentMethodDataSofortCountry option
    }
    with
        static member New(?country: Create'PaymentMethodDataSofortCountry) =
            {
                Country = country
            }

    type Create'PaymentMethodDataUpiMandateOptionsAmountType =
    | Fixed
    | Maximum

    type Create'PaymentMethodDataUpiMandateOptions = {
        ///<summary>Amount to be charged for future payments.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.</summary>
        [<Config.Form>]AmountType: Create'PaymentMethodDataUpiMandateOptionsAmountType option
        ///<summary>A description of the mandate or subscription that is meant to be displayed to the customer.</summary>
        [<Config.Form>]Description: string option
        ///<summary>End date of the mandate or subscription.</summary>
        [<Config.Form>]EndDate: DateTime option
    }
    with
        static member New(?amount: int, ?amountType: Create'PaymentMethodDataUpiMandateOptionsAmountType, ?description: string, ?endDate: DateTime) =
            {
                Amount = amount
                AmountType = amountType
                Description = description
                EndDate = endDate
            }

    type Create'PaymentMethodDataUpi = {
        ///<summary>Configuration options for setting up an eMandate</summary>
        [<Config.Form>]MandateOptions: Create'PaymentMethodDataUpiMandateOptions option
    }
    with
        static member New(?mandateOptions: Create'PaymentMethodDataUpiMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Create'PaymentMethodDataUsBankAccountAccountHolderType =
    | Company
    | Individual

    type Create'PaymentMethodDataUsBankAccountAccountType =
    | Checking
    | Savings

    type Create'PaymentMethodDataUsBankAccount = {
        ///<summary>Account holder type: individual or company.</summary>
        [<Config.Form>]AccountHolderType: Create'PaymentMethodDataUsBankAccountAccountHolderType option
        ///<summary>Account number of the bank account.</summary>
        [<Config.Form>]AccountNumber: string option
        ///<summary>Account type: checkings or savings. Defaults to checking if omitted.</summary>
        [<Config.Form>]AccountType: Create'PaymentMethodDataUsBankAccountAccountType option
        ///<summary>The ID of a Financial Connections Account to use as a payment method.</summary>
        [<Config.Form>]FinancialConnectionsAccount: string option
        ///<summary>Routing number of the bank account.</summary>
        [<Config.Form>]RoutingNumber: string option
    }
    with
        static member New(?accountHolderType: Create'PaymentMethodDataUsBankAccountAccountHolderType, ?accountNumber: string, ?accountType: Create'PaymentMethodDataUsBankAccountAccountType, ?financialConnectionsAccount: string, ?routingNumber: string) =
            {
                AccountHolderType = accountHolderType
                AccountNumber = accountNumber
                AccountType = accountType
                FinancialConnectionsAccount = financialConnectionsAccount
                RoutingNumber = routingNumber
            }

    type Create'PaymentMethodDataAllowRedisplay =
    | Always
    | Limited
    | Unspecified

    type Create'PaymentMethodDataType =
    | AcssDebit
    | Affirm
    | AfterpayClearpay
    | Alipay
    | Alma
    | AmazonPay
    | AuBecsDebit
    | BacsDebit
    | Bancontact
    | Billie
    | Blik
    | Boleto
    | Cashapp
    | Crypto
    | CustomerBalance
    | Eps
    | Fpx
    | Giropay
    | Grabpay
    | Ideal
    | KakaoPay
    | Klarna
    | Konbini
    | KrCard
    | Link
    | MbWay
    | Mobilepay
    | Multibanco
    | NaverPay
    | NzBankAccount
    | Oxxo
    | P24
    | PayByBank
    | Payco
    | Paynow
    | Paypal
    | Payto
    | Pix
    | Promptpay
    | RevolutPay
    | SamsungPay
    | Satispay
    | SepaDebit
    | Sofort
    | Sunbit
    | Swish
    | Twint
    | Upi
    | UsBankAccount
    | WechatPay
    | Zip

    type Create'PaymentMethodData = {
        ///<summary>If this is an `acss_debit` PaymentMethod, this hash contains details about the ACSS Debit payment method.</summary>
        [<Config.Form>]AcssDebit: Create'PaymentMethodDataAcssDebit option
        ///<summary>If this is an `affirm` PaymentMethod, this hash contains details about the Affirm payment method.</summary>
        [<Config.Form>]Affirm: string option
        ///<summary>If this is an `AfterpayClearpay` PaymentMethod, this hash contains details about the AfterpayClearpay payment method.</summary>
        [<Config.Form>]AfterpayClearpay: string option
        ///<summary>If this is an `Alipay` PaymentMethod, this hash contains details about the Alipay payment method.</summary>
        [<Config.Form>]Alipay: string option
        ///<summary>This field indicates whether this payment method can be shown again to its customer in a checkout flow. Stripe products such as Checkout and Elements use this field to determine whether a payment method can be shown as a saved payment method in a checkout flow. The field defaults to `unspecified`.</summary>
        [<Config.Form>]AllowRedisplay: Create'PaymentMethodDataAllowRedisplay option
        ///<summary>If this is a Alma PaymentMethod, this hash contains details about the Alma payment method.</summary>
        [<Config.Form>]Alma: string option
        ///<summary>If this is a AmazonPay PaymentMethod, this hash contains details about the AmazonPay payment method.</summary>
        [<Config.Form>]AmazonPay: string option
        ///<summary>If this is an `au_becs_debit` PaymentMethod, this hash contains details about the bank account.</summary>
        [<Config.Form>]AuBecsDebit: Create'PaymentMethodDataAuBecsDebit option
        ///<summary>If this is a `bacs_debit` PaymentMethod, this hash contains details about the Bacs Direct Debit bank account.</summary>
        [<Config.Form>]BacsDebit: Create'PaymentMethodDataBacsDebit option
        ///<summary>If this is a `bancontact` PaymentMethod, this hash contains details about the Bancontact payment method.</summary>
        [<Config.Form>]Bancontact: string option
        ///<summary>If this is a `billie` PaymentMethod, this hash contains details about the Billie payment method.</summary>
        [<Config.Form>]Billie: string option
        ///<summary>Billing information associated with the PaymentMethod that may be used or required by particular types of payment methods.</summary>
        [<Config.Form>]BillingDetails: Create'PaymentMethodDataBillingDetails option
        ///<summary>If this is a `blik` PaymentMethod, this hash contains details about the BLIK payment method.</summary>
        [<Config.Form>]Blik: string option
        ///<summary>If this is a `boleto` PaymentMethod, this hash contains details about the Boleto payment method.</summary>
        [<Config.Form>]Boleto: Create'PaymentMethodDataBoleto option
        ///<summary>If this is a `cashapp` PaymentMethod, this hash contains details about the Cash App Pay payment method.</summary>
        [<Config.Form>]Cashapp: string option
        ///<summary>If this is a Crypto PaymentMethod, this hash contains details about the Crypto payment method.</summary>
        [<Config.Form>]Crypto: string option
        ///<summary>If this is a `customer_balance` PaymentMethod, this hash contains details about the CustomerBalance payment method.</summary>
        [<Config.Form>]CustomerBalance: string option
        ///<summary>If this is an `eps` PaymentMethod, this hash contains details about the EPS payment method.</summary>
        [<Config.Form>]Eps: Create'PaymentMethodDataEps option
        ///<summary>If this is an `fpx` PaymentMethod, this hash contains details about the FPX payment method.</summary>
        [<Config.Form>]Fpx: Create'PaymentMethodDataFpx option
        ///<summary>If this is a `giropay` PaymentMethod, this hash contains details about the Giropay payment method.</summary>
        [<Config.Form>]Giropay: string option
        ///<summary>If this is a `grabpay` PaymentMethod, this hash contains details about the GrabPay payment method.</summary>
        [<Config.Form>]Grabpay: string option
        ///<summary>If this is an `ideal` PaymentMethod, this hash contains details about the iDEAL payment method.</summary>
        [<Config.Form>]Ideal: Create'PaymentMethodDataIdeal option
        ///<summary>If this is an `interac_present` PaymentMethod, this hash contains details about the Interac Present payment method.</summary>
        [<Config.Form>]InteracPresent: string option
        ///<summary>If this is a `kakao_pay` PaymentMethod, this hash contains details about the Kakao Pay payment method.</summary>
        [<Config.Form>]KakaoPay: string option
        ///<summary>If this is a `klarna` PaymentMethod, this hash contains details about the Klarna payment method.</summary>
        [<Config.Form>]Klarna: Create'PaymentMethodDataKlarna option
        ///<summary>If this is a `konbini` PaymentMethod, this hash contains details about the Konbini payment method.</summary>
        [<Config.Form>]Konbini: string option
        ///<summary>If this is a `kr_card` PaymentMethod, this hash contains details about the Korean Card payment method.</summary>
        [<Config.Form>]KrCard: string option
        ///<summary>If this is an `Link` PaymentMethod, this hash contains details about the Link payment method.</summary>
        [<Config.Form>]Link: string option
        ///<summary>If this is a MB WAY PaymentMethod, this hash contains details about the MB WAY payment method.</summary>
        [<Config.Form>]MbWay: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>If this is a `mobilepay` PaymentMethod, this hash contains details about the MobilePay payment method.</summary>
        [<Config.Form>]Mobilepay: string option
        ///<summary>If this is a `multibanco` PaymentMethod, this hash contains details about the Multibanco payment method.</summary>
        [<Config.Form>]Multibanco: string option
        ///<summary>If this is a `naver_pay` PaymentMethod, this hash contains details about the Naver Pay payment method.</summary>
        [<Config.Form>]NaverPay: Create'PaymentMethodDataNaverPay option
        ///<summary>If this is an nz_bank_account PaymentMethod, this hash contains details about the nz_bank_account payment method.</summary>
        [<Config.Form>]NzBankAccount: Create'PaymentMethodDataNzBankAccount option
        ///<summary>If this is an `oxxo` PaymentMethod, this hash contains details about the OXXO payment method.</summary>
        [<Config.Form>]Oxxo: string option
        ///<summary>If this is a `p24` PaymentMethod, this hash contains details about the P24 payment method.</summary>
        [<Config.Form>]P24: Create'PaymentMethodDataP24 option
        ///<summary>If this is a `pay_by_bank` PaymentMethod, this hash contains details about the PayByBank payment method.</summary>
        [<Config.Form>]PayByBank: string option
        ///<summary>If this is a `payco` PaymentMethod, this hash contains details about the PAYCO payment method.</summary>
        [<Config.Form>]Payco: string option
        ///<summary>If this is a `paynow` PaymentMethod, this hash contains details about the PayNow payment method.</summary>
        [<Config.Form>]Paynow: string option
        ///<summary>If this is a `paypal` PaymentMethod, this hash contains details about the PayPal payment method.</summary>
        [<Config.Form>]Paypal: string option
        ///<summary>If this is a `payto` PaymentMethod, this hash contains details about the PayTo payment method.</summary>
        [<Config.Form>]Payto: Create'PaymentMethodDataPayto option
        ///<summary>If this is a `pix` PaymentMethod, this hash contains details about the Pix payment method.</summary>
        [<Config.Form>]Pix: string option
        ///<summary>If this is a `promptpay` PaymentMethod, this hash contains details about the PromptPay payment method.</summary>
        [<Config.Form>]Promptpay: string option
        ///<summary>Options to configure Radar. See [Radar Session](https://docs.stripe.com/radar/radar-session) for more information.</summary>
        [<Config.Form>]RadarOptions: Create'PaymentMethodDataRadarOptions option
        ///<summary>If this is a `revolut_pay` PaymentMethod, this hash contains details about the Revolut Pay payment method.</summary>
        [<Config.Form>]RevolutPay: string option
        ///<summary>If this is a `samsung_pay` PaymentMethod, this hash contains details about the SamsungPay payment method.</summary>
        [<Config.Form>]SamsungPay: string option
        ///<summary>If this is a `satispay` PaymentMethod, this hash contains details about the Satispay payment method.</summary>
        [<Config.Form>]Satispay: string option
        ///<summary>If this is a `sepa_debit` PaymentMethod, this hash contains details about the SEPA debit bank account.</summary>
        [<Config.Form>]SepaDebit: Create'PaymentMethodDataSepaDebit option
        ///<summary>If this is a `sofort` PaymentMethod, this hash contains details about the SOFORT payment method.</summary>
        [<Config.Form>]Sofort: Create'PaymentMethodDataSofort option
        ///<summary>If this is a Sunbit PaymentMethod, this hash contains details about the Sunbit payment method.</summary>
        [<Config.Form>]Sunbit: string option
        ///<summary>If this is a `swish` PaymentMethod, this hash contains details about the Swish payment method.</summary>
        [<Config.Form>]Swish: string option
        ///<summary>If this is a TWINT PaymentMethod, this hash contains details about the TWINT payment method.</summary>
        [<Config.Form>]Twint: string option
        ///<summary>The type of the PaymentMethod. An additional hash is included on the PaymentMethod with a name matching this value. It contains additional information specific to the PaymentMethod type.</summary>
        [<Config.Form>]Type: Create'PaymentMethodDataType option
        ///<summary>If this is a `upi` PaymentMethod, this hash contains details about the UPI payment method.</summary>
        [<Config.Form>]Upi: Create'PaymentMethodDataUpi option
        ///<summary>If this is an `us_bank_account` PaymentMethod, this hash contains details about the US bank account payment method.</summary>
        [<Config.Form>]UsBankAccount: Create'PaymentMethodDataUsBankAccount option
        ///<summary>If this is an `wechat_pay` PaymentMethod, this hash contains details about the wechat_pay payment method.</summary>
        [<Config.Form>]WechatPay: string option
        ///<summary>If this is a `zip` PaymentMethod, this hash contains details about the Zip payment method.</summary>
        [<Config.Form>]Zip: string option
    }
    with
        static member New(?acssDebit: Create'PaymentMethodDataAcssDebit, ?mobilepay: string, ?multibanco: string, ?naverPay: Create'PaymentMethodDataNaverPay, ?nzBankAccount: Create'PaymentMethodDataNzBankAccount, ?oxxo: string, ?p24: Create'PaymentMethodDataP24, ?payByBank: string, ?payco: string, ?paynow: string, ?paypal: string, ?payto: Create'PaymentMethodDataPayto, ?pix: string, ?promptpay: string, ?radarOptions: Create'PaymentMethodDataRadarOptions, ?revolutPay: string, ?samsungPay: string, ?satispay: string, ?sepaDebit: Create'PaymentMethodDataSepaDebit, ?sofort: Create'PaymentMethodDataSofort, ?sunbit: string, ?swish: string, ?twint: string, ?type': Create'PaymentMethodDataType, ?upi: Create'PaymentMethodDataUpi, ?usBankAccount: Create'PaymentMethodDataUsBankAccount, ?metadata: Map<string, string>, ?wechatPay: string, ?mbWay: string, ?krCard: string, ?affirm: string, ?afterpayClearpay: string, ?alipay: string, ?allowRedisplay: Create'PaymentMethodDataAllowRedisplay, ?alma: string, ?amazonPay: string, ?auBecsDebit: Create'PaymentMethodDataAuBecsDebit, ?bacsDebit: Create'PaymentMethodDataBacsDebit, ?bancontact: string, ?billie: string, ?billingDetails: Create'PaymentMethodDataBillingDetails, ?blik: string, ?boleto: Create'PaymentMethodDataBoleto, ?cashapp: string, ?crypto: string, ?customerBalance: string, ?eps: Create'PaymentMethodDataEps, ?fpx: Create'PaymentMethodDataFpx, ?giropay: string, ?grabpay: string, ?ideal: Create'PaymentMethodDataIdeal, ?interacPresent: string, ?kakaoPay: string, ?klarna: Create'PaymentMethodDataKlarna, ?konbini: string, ?link: string, ?zip: string) =
            {
                AcssDebit = acssDebit
                Affirm = affirm
                AfterpayClearpay = afterpayClearpay
                Alipay = alipay
                AllowRedisplay = allowRedisplay
                Alma = alma
                AmazonPay = amazonPay
                AuBecsDebit = auBecsDebit
                BacsDebit = bacsDebit
                Bancontact = bancontact
                Billie = billie
                BillingDetails = billingDetails
                Blik = blik
                Boleto = boleto
                Cashapp = cashapp
                Crypto = crypto
                CustomerBalance = customerBalance
                Eps = eps
                Fpx = fpx
                Giropay = giropay
                Grabpay = grabpay
                Ideal = ideal
                InteracPresent = interacPresent
                KakaoPay = kakaoPay
                Klarna = klarna
                Konbini = konbini
                KrCard = krCard
                Link = link
                MbWay = mbWay
                Metadata = metadata
                Mobilepay = mobilepay
                Multibanco = multibanco
                NaverPay = naverPay
                NzBankAccount = nzBankAccount
                Oxxo = oxxo
                P24 = p24
                PayByBank = payByBank
                Payco = payco
                Paynow = paynow
                Paypal = paypal
                Payto = payto
                Pix = pix
                Promptpay = promptpay
                RadarOptions = radarOptions
                RevolutPay = revolutPay
                SamsungPay = samsungPay
                Satispay = satispay
                SepaDebit = sepaDebit
                Sofort = sofort
                Sunbit = sunbit
                Swish = swish
                Twint = twint
                Type = type'
                Upi = upi
                UsBankAccount = usBankAccount
                WechatPay = wechatPay
                Zip = zip
            }

    type Create'PaymentMethodOptionsCardInstallmentsPlanInterval =
    | Month

    type Create'PaymentMethodOptionsCardInstallmentsPlanType =
    | Bonus
    | FixedCount
    | Revolving

    type Create'PaymentMethodOptionsCardInstallmentsPlan = {
        ///<summary>For `fixed_count` installment plans, this is required. It represents the number of installment payments your customer will make to their credit card.</summary>
        [<Config.Form>]Count: int option
        ///<summary>For `fixed_count` installment plans, this is required. It represents the interval between installment payments your customer will make to their credit card.
        ///One of `month`.</summary>
        [<Config.Form>]Interval: Create'PaymentMethodOptionsCardInstallmentsPlanInterval option
        ///<summary>Type of installment plan, one of `fixed_count`, `bonus`, or `revolving`.</summary>
        [<Config.Form>]Type: Create'PaymentMethodOptionsCardInstallmentsPlanType option
    }
    with
        static member New(?count: int, ?interval: Create'PaymentMethodOptionsCardInstallmentsPlanInterval, ?type': Create'PaymentMethodOptionsCardInstallmentsPlanType) =
            {
                Count = count
                Interval = interval
                Type = type'
            }

    type Create'PaymentMethodOptionsCardInstallments = {
        ///<summary>The selected installment plan to use for this payment attempt.
        ///This parameter can only be provided during confirmation.</summary>
        [<Config.Form>]Plan: Create'PaymentMethodOptionsCardInstallmentsPlan option
    }
    with
        static member New(?plan: Create'PaymentMethodOptionsCardInstallmentsPlan) =
            {
                Plan = plan
            }

    type Create'PaymentMethodOptionsCard = {
        ///<summary>Installment configuration for payments confirmed using this ConfirmationToken.</summary>
        [<Config.Form>]Installments: Create'PaymentMethodOptionsCardInstallments option
    }
    with
        static member New(?installments: Create'PaymentMethodOptionsCardInstallments) =
            {
                Installments = installments
            }

    type Create'PaymentMethodOptions = {
        ///<summary>Configuration for any card payments confirmed using this ConfirmationToken.</summary>
        [<Config.Form>]Card: Create'PaymentMethodOptionsCard option
    }
    with
        static member New(?card: Create'PaymentMethodOptionsCard) =
            {
                Card = card
            }

    type Create'ShippingAddress = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'Shipping = {
        ///<summary>Shipping address</summary>
        [<Config.Form>]Address: Create'ShippingAddress option
        ///<summary>Recipient name.</summary>
        [<Config.Form>]Name: string option
        ///<summary>Recipient phone (including extension)</summary>
        [<Config.Form>]Phone: Choice<string,string> option
    }
    with
        static member New(?address: Create'ShippingAddress, ?name: string, ?phone: Choice<string,string>) =
            {
                Address = address
                Name = name
                Phone = phone
            }

    type Create'SetupFutureUsage =
    | OffSession
    | OnSession

    type CreateOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>ID of an existing PaymentMethod.</summary>
        [<Config.Form>]PaymentMethod: string option
        ///<summary>If provided, this hash will be used to create a PaymentMethod.</summary>
        [<Config.Form>]PaymentMethodData: Create'PaymentMethodData option
        ///<summary>Payment-method-specific configuration for this ConfirmationToken.</summary>
        [<Config.Form>]PaymentMethodOptions: Create'PaymentMethodOptions option
        ///<summary>Return URL used to confirm the Intent.</summary>
        [<Config.Form>]ReturnUrl: string option
        ///<summary>Indicates that you intend to make future payments with this ConfirmationToken's payment method.
        ///The presence of this property will [attach the payment method](https://docs.stripe.com/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete.</summary>
        [<Config.Form>]SetupFutureUsage: Create'SetupFutureUsage option
        ///<summary>Shipping information for this ConfirmationToken.</summary>
        [<Config.Form>]Shipping: Create'Shipping option
    }
    with
        static member New(?expand: string list, ?paymentMethod: string, ?paymentMethodData: Create'PaymentMethodData, ?paymentMethodOptions: Create'PaymentMethodOptions, ?returnUrl: string, ?setupFutureUsage: Create'SetupFutureUsage, ?shipping: Create'Shipping) =
            {
                Expand = expand
                PaymentMethod = paymentMethod
                PaymentMethodData = paymentMethodData
                PaymentMethodOptions = paymentMethodOptions
                ReturnUrl = returnUrl
                SetupFutureUsage = setupFutureUsage
                Shipping = shipping
            }

    ///<summary><p>Creates a test mode Confirmation Token server side for your integration tests.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/test_helpers/confirmation_tokens"
        |> RestApi.postAsync<_, ConfirmationToken> settings (Map.empty) options

module TestHelpersCustomersFundCashBalance =

    type FundCashBalanceOptions = {
        [<Config.Path>]Customer: string
        ///<summary>Amount to be used for this test cash balance transaction. A positive integer representing how much to fund in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal) (e.g., 100 cents to fund $1.00 or 100 to fund ¥100, a zero-decimal currency).</summary>
        [<Config.Form>]Amount: int
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>A description of the test funding. This simulates free-text references supplied by customers when making bank transfers to their cash balance. You can use this to test how Stripe's [reconciliation algorithm](https://docs.stripe.com/payments/customer-balance/reconciliation) applies to different user inputs.</summary>
        [<Config.Form>]Reference: string option
    }
    with
        static member New(customer: string, amount: int, currency: IsoTypes.IsoCurrencyCode, ?expand: string list, ?reference: string) =
            {
                Customer = customer
                Amount = amount
                Currency = currency
                Expand = expand
                Reference = reference
            }

    ///<summary><p>Create an incoming testmode bank transfer</p></summary>
    let FundCashBalance settings (options: FundCashBalanceOptions) =
        $"/v1/test_helpers/customers/{options.Customer}/fund_cash_balance"
        |> RestApi.postAsync<_, CustomerCashBalanceTransaction> settings (Map.empty) options

module TestHelpersIssuingAuthorizations =

    type Create'AmountDetails = {
        ///<summary>The ATM withdrawal fee.</summary>
        [<Config.Form>]AtmFee: int option
        ///<summary>The amount of cash requested by the cardholder.</summary>
        [<Config.Form>]CashbackAmount: int option
    }
    with
        static member New(?atmFee: int, ?cashbackAmount: int) =
            {
                AtmFee = atmFee
                CashbackAmount = cashbackAmount
            }

    type Create'FleetCardholderPromptData = {
        ///<summary>Driver ID.</summary>
        [<Config.Form>]DriverId: string option
        ///<summary>Odometer reading.</summary>
        [<Config.Form>]Odometer: int option
        ///<summary>An alphanumeric ID. This field is used when a vehicle ID, driver ID, or generic ID is entered by the cardholder, but the merchant or card network did not specify the prompt type.</summary>
        [<Config.Form>]UnspecifiedId: string option
        ///<summary>User ID.</summary>
        [<Config.Form>]UserId: string option
        ///<summary>Vehicle number.</summary>
        [<Config.Form>]VehicleNumber: string option
    }
    with
        static member New(?driverId: string, ?odometer: int, ?unspecifiedId: string, ?userId: string, ?vehicleNumber: string) =
            {
                DriverId = driverId
                Odometer = odometer
                UnspecifiedId = unspecifiedId
                UserId = userId
                VehicleNumber = vehicleNumber
            }

    type Create'FleetReportedBreakdownFuel = {
        ///<summary>Gross fuel amount that should equal Fuel Volume multipled by Fuel Unit Cost, inclusive of taxes.</summary>
        [<Config.Form>]GrossAmountDecimal: string option
    }
    with
        static member New(?grossAmountDecimal: string) =
            {
                GrossAmountDecimal = grossAmountDecimal
            }

    type Create'FleetReportedBreakdownNonFuel = {
        ///<summary>Gross non-fuel amount that should equal the sum of the line items, inclusive of taxes.</summary>
        [<Config.Form>]GrossAmountDecimal: string option
    }
    with
        static member New(?grossAmountDecimal: string) =
            {
                GrossAmountDecimal = grossAmountDecimal
            }

    type Create'FleetReportedBreakdownTax = {
        ///<summary>Amount of state or provincial Sales Tax included in the transaction amount. Null if not reported by merchant or not subject to tax.</summary>
        [<Config.Form>]LocalAmountDecimal: string option
        ///<summary>Amount of national Sales Tax or VAT included in the transaction amount. Null if not reported by merchant or not subject to tax.</summary>
        [<Config.Form>]NationalAmountDecimal: string option
    }
    with
        static member New(?localAmountDecimal: string, ?nationalAmountDecimal: string) =
            {
                LocalAmountDecimal = localAmountDecimal
                NationalAmountDecimal = nationalAmountDecimal
            }

    type Create'FleetReportedBreakdown = {
        ///<summary>Breakdown of fuel portion of the purchase.</summary>
        [<Config.Form>]Fuel: Create'FleetReportedBreakdownFuel option
        ///<summary>Breakdown of non-fuel portion of the purchase.</summary>
        [<Config.Form>]NonFuel: Create'FleetReportedBreakdownNonFuel option
        ///<summary>Information about tax included in this transaction.</summary>
        [<Config.Form>]Tax: Create'FleetReportedBreakdownTax option
    }
    with
        static member New(?fuel: Create'FleetReportedBreakdownFuel, ?nonFuel: Create'FleetReportedBreakdownNonFuel, ?tax: Create'FleetReportedBreakdownTax) =
            {
                Fuel = fuel
                NonFuel = nonFuel
                Tax = tax
            }

    type Create'FleetPurchaseType =
    | FuelAndNonFuelPurchase
    | FuelPurchase
    | NonFuelPurchase

    type Create'FleetServiceType =
    | FullService
    | NonFuelTransaction
    | SelfService

    type Create'Fleet = {
        ///<summary>Answers to prompts presented to the cardholder at the point of sale. Prompted fields vary depending on the configuration of your physical fleet cards. Typical points of sale support only numeric entry.</summary>
        [<Config.Form>]CardholderPromptData: Create'FleetCardholderPromptData option
        ///<summary>The type of purchase. One of `fuel_purchase`, `non_fuel_purchase`, or `fuel_and_non_fuel_purchase`.</summary>
        [<Config.Form>]PurchaseType: Create'FleetPurchaseType option
        ///<summary>More information about the total amount. This information is not guaranteed to be accurate as some merchants may provide unreliable data.</summary>
        [<Config.Form>]ReportedBreakdown: Create'FleetReportedBreakdown option
        ///<summary>The type of fuel service. One of `non_fuel_transaction`, `full_service`, or `self_service`.</summary>
        [<Config.Form>]ServiceType: Create'FleetServiceType option
    }
    with
        static member New(?cardholderPromptData: Create'FleetCardholderPromptData, ?purchaseType: Create'FleetPurchaseType, ?reportedBreakdown: Create'FleetReportedBreakdown, ?serviceType: Create'FleetServiceType) =
            {
                CardholderPromptData = cardholderPromptData
                PurchaseType = purchaseType
                ReportedBreakdown = reportedBreakdown
                ServiceType = serviceType
            }

    type Create'FuelType =
    | Diesel
    | Other
    | UnleadedPlus
    | UnleadedRegular
    | UnleadedSuper

    type Create'FuelUnit =
    | ChargingMinute
    | ImperialGallon
    | Kilogram
    | KilowattHour
    | Liter
    | Other
    | Pound
    | UsGallon

    type Create'Fuel = {
        ///<summary>[Conexxus Payment System Product Code](https://www.conexxus.org/conexxus-payment-system-product-codes) identifying the primary fuel product purchased.</summary>
        [<Config.Form>]IndustryProductCode: string option
        ///<summary>The quantity of `unit`s of fuel that was dispensed, represented as a decimal string with at most 12 decimal places.</summary>
        [<Config.Form>]QuantityDecimal: string option
        ///<summary>The type of fuel that was purchased. One of `diesel`, `unleaded_plus`, `unleaded_regular`, `unleaded_super`, or `other`.</summary>
        [<Config.Form>]Type: Create'FuelType option
        ///<summary>The units for `quantity_decimal`. One of `charging_minute`, `imperial_gallon`, `kilogram`, `kilowatt_hour`, `liter`, `pound`, `us_gallon`, or `other`.</summary>
        [<Config.Form>]Unit: Create'FuelUnit option
        ///<summary>The cost in cents per each unit of fuel, represented as a decimal string with at most 12 decimal places.</summary>
        [<Config.Form>]UnitCostDecimal: string option
    }
    with
        static member New(?industryProductCode: string, ?quantityDecimal: string, ?type': Create'FuelType, ?unit: Create'FuelUnit, ?unitCostDecimal: string) =
            {
                IndustryProductCode = industryProductCode
                QuantityDecimal = quantityDecimal
                Type = type'
                Unit = unit
                UnitCostDecimal = unitCostDecimal
            }

    type Create'MerchantDataCategory =
    | AcRefrigerationRepair
    | AccountingBookkeepingServices
    | AdvertisingServices
    | AgriculturalCooperative
    | AirlinesAirCarriers
    | AirportsFlyingFields
    | AmbulanceServices
    | AmusementParksCarnivals
    | AntiqueReproductions
    | AntiqueShops
    | Aquariums
    | ArchitecturalSurveyingServices
    | ArtDealersAndGalleries
    | ArtistsSupplyAndCraftShops
    | AutoAndHomeSupplyStores
    | AutoBodyRepairShops
    | AutoPaintShops
    | AutoServiceShops
    | AutomatedCashDisburse
    | AutomatedFuelDispensers
    | AutomobileAssociations
    | AutomotivePartsAndAccessoriesStores
    | AutomotiveTireStores
    | BailAndBondPayments
    | Bakeries
    | BandsOrchestras
    | BarberAndBeautyShops
    | BettingCasinoGambling
    | BicycleShops
    | BilliardPoolEstablishments
    | BoatDealers
    | BoatRentalsAndLeases
    | BookStores
    | BooksPeriodicalsAndNewspapers
    | BowlingAlleys
    | BusLines
    | BusinessSecretarialSchools
    | BuyingShoppingServices
    | CableSatelliteAndOtherPayTelevisionAndRadio
    | CameraAndPhotographicSupplyStores
    | CandyNutAndConfectioneryStores
    | CarAndTruckDealersNewUsed
    | CarAndTruckDealersUsedOnly
    | CarRentalAgencies
    | CarWashes
    | CarpentryServices
    | CarpetUpholsteryCleaning
    | Caterers
    | CharitableAndSocialServiceOrganizationsFundraising
    | ChemicalsAndAlliedProducts
    | ChildCareServices
    | ChildrensAndInfantsWearStores
    | ChiropodistsPodiatrists
    | Chiropractors
    | CigarStoresAndStands
    | CivicSocialFraternalAssociations
    | CleaningAndMaintenance
    | ClothingRental
    | CollegesUniversities
    | CommercialEquipment
    | CommercialFootwear
    | CommercialPhotographyArtAndGraphics
    | CommuterTransportAndFerries
    | ComputerNetworkServices
    | ComputerProgramming
    | ComputerRepair
    | ComputerSoftwareStores
    | ComputersPeripheralsAndSoftware
    | ConcreteWorkServices
    | ConstructionMaterials
    | ConsultingPublicRelations
    | CorrespondenceSchools
    | CosmeticStores
    | CounselingServices
    | CountryClubs
    | CourierServices
    | CourtCosts
    | CreditReportingAgencies
    | CruiseLines
    | DairyProductsStores
    | DanceHallStudiosSchools
    | DatingEscortServices
    | DentistsOrthodontists
    | DepartmentStores
    | DetectiveAgencies
    | DigitalGoodsApplications
    | DigitalGoodsGames
    | DigitalGoodsLargeVolume
    | DigitalGoodsMedia
    | DirectMarketingCatalogMerchant
    | DirectMarketingCombinationCatalogAndRetailMerchant
    | DirectMarketingInboundTelemarketing
    | DirectMarketingInsuranceServices
    | DirectMarketingOther
    | DirectMarketingOutboundTelemarketing
    | DirectMarketingSubscription
    | DirectMarketingTravel
    | DiscountStores
    | Doctors
    | DoorToDoorSales
    | DraperyWindowCoveringAndUpholsteryStores
    | DrinkingPlaces
    | DrugStoresAndPharmacies
    | DrugsDrugProprietariesAndDruggistSundries
    | DryCleaners
    | DurableGoods
    | DutyFreeStores
    | EatingPlacesRestaurants
    | EducationalServices
    | ElectricRazorStores
    | ElectricVehicleCharging
    | ElectricalPartsAndEquipment
    | ElectricalServices
    | ElectronicsRepairShops
    | ElectronicsStores
    | ElementarySecondarySchools
    | EmergencyServicesGcasVisaUseOnly
    | EmploymentTempAgencies
    | EquipmentRental
    | ExterminatingServices
    | FamilyClothingStores
    | FastFoodRestaurants
    | FinancialInstitutions
    | FinesGovernmentAdministrativeEntities
    | FireplaceFireplaceScreensAndAccessoriesStores
    | FloorCoveringStores
    | Florists
    | FloristsSuppliesNurseryStockAndFlowers
    | FreezerAndLockerMeatProvisioners
    | FuelDealersNonAutomotive
    | FuneralServicesCrematories
    | FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
    | FurnitureRepairRefinishing
    | FurriersAndFurShops
    | GeneralServices
    | GiftCardNoveltyAndSouvenirShops
    | GlassPaintAndWallpaperStores
    | GlasswareCrystalStores
    | GolfCoursesPublic
    | GovernmentLicensedHorseDogRacingUsRegionOnly
    | GovernmentLicensedOnlineCasionsOnlineGamblingUsRegionOnly
    | GovernmentOwnedLotteriesNonUsRegion
    | GovernmentOwnedLotteriesUsRegionOnly
    | GovernmentServices
    | GroceryStoresSupermarkets
    | HardwareEquipmentAndSupplies
    | HardwareStores
    | HealthAndBeautySpas
    | HearingAidsSalesAndSupplies
    | HeatingPlumbingAC
    | HobbyToyAndGameShops
    | HomeSupplyWarehouseStores
    | Hospitals
    | HotelsMotelsAndResorts
    | HouseholdApplianceStores
    | IndustrialSupplies
    | InformationRetrievalServices
    | InsuranceDefault
    | InsuranceUnderwritingPremiums
    | IntraCompanyPurchases
    | JewelryStoresWatchesClocksAndSilverwareStores
    | LandscapingServices
    | Laundries
    | LaundryCleaningServices
    | LegalServicesAttorneys
    | LuggageAndLeatherGoodsStores
    | LumberBuildingMaterialsStores
    | ManualCashDisburse
    | MarinasServiceAndSupplies
    | Marketplaces
    | MasonryStoneworkAndPlaster
    | MassageParlors
    | MedicalAndDentalLabs
    | MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
    | MedicalServices
    | MembershipOrganizations
    | MensAndBoysClothingAndAccessoriesStores
    | MensWomensClothingStores
    | MetalServiceCenters
    | MiscellaneousApparelAndAccessoryShops
    | MiscellaneousAutoDealers
    | MiscellaneousBusinessServices
    | MiscellaneousFoodStores
    | MiscellaneousGeneralMerchandise
    | MiscellaneousGeneralServices
    | MiscellaneousHomeFurnishingSpecialtyStores
    | MiscellaneousPublishingAndPrinting
    | MiscellaneousRecreationServices
    | MiscellaneousRepairShops
    | MiscellaneousSpecialtyRetail
    | MobileHomeDealers
    | MotionPictureTheaters
    | MotorFreightCarriersAndTrucking
    | MotorHomesDealers
    | MotorVehicleSuppliesAndNewParts
    | MotorcycleShopsAndDealers
    | MotorcycleShopsDealers
    | MusicStoresMusicalInstrumentsPianosAndSheetMusic
    | NewsDealersAndNewsstands
    | NonFiMoneyOrders
    | NonFiStoredValueCardPurchaseLoad
    | NondurableGoods
    | NurseriesLawnAndGardenSupplyStores
    | NursingPersonalCare
    | OfficeAndCommercialFurniture
    | OpticiansEyeglasses
    | OptometristsOphthalmologist
    | OrthopedicGoodsProstheticDevices
    | Osteopaths
    | PackageStoresBeerWineAndLiquor
    | PaintsVarnishesAndSupplies
    | ParkingLotsGarages
    | PassengerRailways
    | PawnShops
    | PetShopsPetFoodAndSupplies
    | PetroleumAndPetroleumProducts
    | PhotoDeveloping
    | PhotographicPhotocopyMicrofilmEquipmentAndSupplies
    | PhotographicStudios
    | PictureVideoProduction
    | PieceGoodsNotionsAndOtherDryGoods
    | PlumbingHeatingEquipmentAndSupplies
    | PoliticalOrganizations
    | PostalServicesGovernmentOnly
    | PreciousStonesAndMetalsWatchesAndJewelry
    | ProfessionalServices
    | PublicWarehousingAndStorage
    | QuickCopyReproAndBlueprint
    | Railroads
    | RealEstateAgentsAndManagersRentals
    | RecordStores
    | RecreationalVehicleRentals
    | ReligiousGoodsStores
    | ReligiousOrganizations
    | RoofingSidingSheetMetal
    | SecretarialSupportServices
    | SecurityBrokersDealers
    | ServiceStations
    | SewingNeedleworkFabricAndPieceGoodsStores
    | ShoeRepairHatCleaning
    | ShoeStores
    | SmallApplianceRepair
    | SnowmobileDealers
    | SpecialTradeServices
    | SpecialtyCleaning
    | SportingGoodsStores
    | SportingRecreationCamps
    | SportsAndRidingApparelStores
    | SportsClubsFields
    | StampAndCoinStores
    | StationaryOfficeSuppliesPrintingAndWritingPaper
    | StationeryStoresOfficeAndSchoolSupplyStores
    | SwimmingPoolsSales
    | TUiTravelGermany
    | TailorsAlterations
    | TaxPaymentsGovernmentAgencies
    | TaxPreparationServices
    | TaxicabsLimousines
    | TelecommunicationEquipmentAndTelephoneSales
    | TelecommunicationServices
    | TelegraphServices
    | TentAndAwningShops
    | TestingLaboratories
    | TheatricalTicketAgencies
    | Timeshares
    | TireRetreadingAndRepair
    | TollsBridgeFees
    | TouristAttractionsAndExhibits
    | TowingServices
    | TrailerParksCampgrounds
    | TransportationServices
    | TravelAgenciesTourOperators
    | TruckStopIteration
    | TruckUtilityTrailerRentals
    | TypesettingPlateMakingAndRelatedServices
    | TypewriterStores
    | USFederalGovernmentAgenciesOrDepartments
    | UniformsCommercialClothing
    | UsedMerchandiseAndSecondhandStores
    | Utilities
    | VarietyStores
    | VeterinaryServices
    | VideoAmusementGameSupplies
    | VideoGameArcades
    | VideoTapeRentalStores
    | VocationalTradeSchools
    | WatchJewelryRepair
    | WeldingRepair
    | WholesaleClubs
    | WigAndToupeeStores
    | WiresMoneyOrders
    | WomensAccessoryAndSpecialtyShops
    | WomensReadyToWearStores
    | WreckingAndSalvageYards

    type Create'MerchantData = {
        ///<summary>A categorization of the seller's type of business. See our [merchant categories guide](https://docs.stripe.com/issuing/merchant-categories) for a list of possible values.</summary>
        [<Config.Form>]Category: Create'MerchantDataCategory option
        ///<summary>City where the seller is located</summary>
        [<Config.Form>]City: string option
        ///<summary>Country where the seller is located</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Name of the seller</summary>
        [<Config.Form>]Name: string option
        ///<summary>Identifier assigned to the seller by the card network. Different card networks may assign different network_id fields to the same merchant.</summary>
        [<Config.Form>]NetworkId: string option
        ///<summary>Postal code where the seller is located</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State where the seller is located</summary>
        [<Config.Form>]State: string option
        ///<summary>An ID assigned by the seller to the location of the sale.</summary>
        [<Config.Form>]TerminalId: string option
        ///<summary>URL provided by the merchant on a 3DS request</summary>
        [<Config.Form>]Url: string option
    }
    with
        static member New(?category: Create'MerchantDataCategory, ?city: string, ?country: IsoTypes.IsoCountryCode, ?name: string, ?networkId: string, ?postalCode: string, ?state: string, ?terminalId: string, ?url: string) =
            {
                Category = category
                City = city
                Country = country
                Name = name
                NetworkId = networkId
                PostalCode = postalCode
                State = state
                TerminalId = terminalId
                Url = url
            }

    type Create'NetworkData = {
        ///<summary>Identifier assigned to the acquirer by the card network.</summary>
        [<Config.Form>]AcquiringInstitutionId: string option
    }
    with
        static member New(?acquiringInstitutionId: string) =
            {
                AcquiringInstitutionId = acquiringInstitutionId
            }

    type Create'RiskAssessmentCardTestingRiskLevel =
    | Elevated
    | Highest
    | Low
    | Normal
    | NotAssessed
    | Unknown

    type Create'RiskAssessmentCardTestingRisk = {
        ///<summary>The % of declines due to a card number not existing in the past hour, taking place at the same merchant. Higher rates correspond to a greater probability of card testing activity, meaning bad actors may be attempting different card number combinations to guess a correct one. Takes on values between 0 and 100.</summary>
        [<Config.Form>]InvalidAccountNumberDeclineRatePastHour: int option
        ///<summary>The % of declines due to incorrect verification data (like CVV or expiry) in the past hour, taking place at the same merchant. Higher rates correspond to a greater probability of bad actors attempting to utilize valid card credentials at merchants with verification requirements. Takes on values between 0 and 100.</summary>
        [<Config.Form>]InvalidCredentialsDeclineRatePastHour: int option
        ///<summary>The likelihood that this authorization is associated with card testing activity. This is assessed by evaluating decline activity over the last hour.</summary>
        [<Config.Form>]Level: Create'RiskAssessmentCardTestingRiskLevel option
    }
    with
        static member New(?invalidAccountNumberDeclineRatePastHour: int, ?invalidCredentialsDeclineRatePastHour: int, ?level: Create'RiskAssessmentCardTestingRiskLevel) =
            {
                InvalidAccountNumberDeclineRatePastHour = invalidAccountNumberDeclineRatePastHour
                InvalidCredentialsDeclineRatePastHour = invalidCredentialsDeclineRatePastHour
                Level = level
            }

    type Create'RiskAssessmentFraudRiskLevel =
    | Elevated
    | Highest
    | Low
    | Normal
    | NotAssessed
    | Unknown

    type Create'RiskAssessmentFraudRisk = {
        ///<summary>Stripe’s assessment of the likelihood of fraud on an authorization.</summary>
        [<Config.Form>]Level: Create'RiskAssessmentFraudRiskLevel option
        ///<summary>Stripe’s numerical model score assessing the likelihood of fraudulent activity. A higher score means a higher likelihood of fraudulent activity, and anything above 25 is considered high risk.</summary>
        [<Config.Form>]Score: decimal option
    }
    with
        static member New(?level: Create'RiskAssessmentFraudRiskLevel, ?score: decimal) =
            {
                Level = level
                Score = score
            }

    type Create'RiskAssessmentMerchantDisputeRiskLevel =
    | Elevated
    | Highest
    | Low
    | Normal
    | NotAssessed
    | Unknown

    type Create'RiskAssessmentMerchantDisputeRisk = {
        ///<summary>The dispute rate observed across all Stripe Issuing authorizations for this merchant. For example, a value of 50 means 50% of authorizations from this merchant on Stripe Issuing have resulted in a dispute. Higher values mean a higher likelihood the authorization is disputed. Takes on values between 0 and 100.</summary>
        [<Config.Form>]DisputeRate: int option
        ///<summary>The likelihood that authorizations from this merchant will result in a dispute based on their history on Stripe Issuing.</summary>
        [<Config.Form>]Level: Create'RiskAssessmentMerchantDisputeRiskLevel option
    }
    with
        static member New(?disputeRate: int, ?level: Create'RiskAssessmentMerchantDisputeRiskLevel) =
            {
                DisputeRate = disputeRate
                Level = level
            }

    type Create'RiskAssessment = {
        ///<summary>Stripe's assessment of this authorization's likelihood of being card testing activity.</summary>
        [<Config.Form>]CardTestingRisk: Create'RiskAssessmentCardTestingRisk option
        ///<summary>Stripe’s assessment of this authorization’s likelihood to be fraudulent.</summary>
        [<Config.Form>]FraudRisk: Create'RiskAssessmentFraudRisk option
        ///<summary>The dispute risk of the merchant (the seller on a purchase) on an authorization based on all Stripe Issuing activity.</summary>
        [<Config.Form>]MerchantDisputeRisk: Create'RiskAssessmentMerchantDisputeRisk option
    }
    with
        static member New(?cardTestingRisk: Create'RiskAssessmentCardTestingRisk, ?fraudRisk: Create'RiskAssessmentFraudRisk, ?merchantDisputeRisk: Create'RiskAssessmentMerchantDisputeRisk) =
            {
                CardTestingRisk = cardTestingRisk
                FraudRisk = fraudRisk
                MerchantDisputeRisk = merchantDisputeRisk
            }

    type Create'VerificationDataAuthenticationExemptionClaimedBy =
    | Acquirer
    | Issuer

    type Create'VerificationDataAuthenticationExemptionType =
    | LowValueTransaction
    | TransactionRiskAnalysis
    | Unknown

    type Create'VerificationDataAuthenticationExemption = {
        ///<summary>The entity that requested the exemption, either the acquiring merchant or the Issuing user.</summary>
        [<Config.Form>]ClaimedBy: Create'VerificationDataAuthenticationExemptionClaimedBy option
        ///<summary>The specific exemption claimed for this authorization.</summary>
        [<Config.Form>]Type: Create'VerificationDataAuthenticationExemptionType option
    }
    with
        static member New(?claimedBy: Create'VerificationDataAuthenticationExemptionClaimedBy, ?type': Create'VerificationDataAuthenticationExemptionType) =
            {
                ClaimedBy = claimedBy
                Type = type'
            }

    type Create'VerificationDataThreeDSecureResult =
    | AttemptAcknowledged
    | Authenticated
    | Failed
    | Required

    type Create'VerificationDataThreeDSecure = {
        ///<summary>The outcome of the 3D Secure authentication request.</summary>
        [<Config.Form>]Result: Create'VerificationDataThreeDSecureResult option
    }
    with
        static member New(?result: Create'VerificationDataThreeDSecureResult) =
            {
                Result = result
            }

    type Create'VerificationDataAddressLine1Check =
    | Match
    | Mismatch
    | NotProvided

    type Create'VerificationDataAddressPostalCodeCheck =
    | Match
    | Mismatch
    | NotProvided

    type Create'VerificationDataCvcCheck =
    | Match
    | Mismatch
    | NotProvided

    type Create'VerificationDataExpiryCheck =
    | Match
    | Mismatch
    | NotProvided

    type Create'VerificationData = {
        ///<summary>Whether the cardholder provided an address first line and if it matched the cardholder’s `billing.address.line1`.</summary>
        [<Config.Form>]AddressLine1Check: Create'VerificationDataAddressLine1Check option
        ///<summary>Whether the cardholder provided a postal code and if it matched the cardholder’s `billing.address.postal_code`.</summary>
        [<Config.Form>]AddressPostalCodeCheck: Create'VerificationDataAddressPostalCodeCheck option
        ///<summary>The exemption applied to this authorization.</summary>
        [<Config.Form>]AuthenticationExemption: Create'VerificationDataAuthenticationExemption option
        ///<summary>Whether the cardholder provided a CVC and if it matched Stripe’s record.</summary>
        [<Config.Form>]CvcCheck: Create'VerificationDataCvcCheck option
        ///<summary>Whether the cardholder provided an expiry date and if it matched Stripe’s record.</summary>
        [<Config.Form>]ExpiryCheck: Create'VerificationDataExpiryCheck option
        ///<summary>3D Secure details.</summary>
        [<Config.Form>]ThreeDSecure: Create'VerificationDataThreeDSecure option
    }
    with
        static member New(?addressLine1Check: Create'VerificationDataAddressLine1Check, ?addressPostalCodeCheck: Create'VerificationDataAddressPostalCodeCheck, ?authenticationExemption: Create'VerificationDataAuthenticationExemption, ?cvcCheck: Create'VerificationDataCvcCheck, ?expiryCheck: Create'VerificationDataExpiryCheck, ?threeDSecure: Create'VerificationDataThreeDSecure) =
            {
                AddressLine1Check = addressLine1Check
                AddressPostalCodeCheck = addressPostalCodeCheck
                AuthenticationExemption = authenticationExemption
                CvcCheck = cvcCheck
                ExpiryCheck = expiryCheck
                ThreeDSecure = threeDSecure
            }

    type Create'AuthorizationMethod =
    | Chip
    | Contactless
    | KeyedIn
    | Online
    | Swipe

    type Create'FraudDisputabilityLikelihood =
    | Neutral
    | Unknown
    | VeryLikely
    | VeryUnlikely

    type Create'Wallet =
    | ApplePay
    | GooglePay
    | SamsungPay

    type CreateOptions = {
        ///<summary>The total amount to attempt to authorize. This amount is in the provided currency, or defaults to the card's currency, and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Detailed breakdown of amount components. These amounts are denominated in `currency` and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).</summary>
        [<Config.Form>]AmountDetails: Create'AmountDetails option
        ///<summary>How the card details were provided. Defaults to online.</summary>
        [<Config.Form>]AuthorizationMethod: Create'AuthorizationMethod option
        ///<summary>Card associated with this authorization.</summary>
        [<Config.Form>]Card: string
        ///<summary>The currency of the authorization. If not provided, defaults to the currency of the card. Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Fleet-specific information for authorizations using Fleet cards.</summary>
        [<Config.Form>]Fleet: Create'Fleet option
        ///<summary>Probability that this transaction can be disputed in the event of fraud. Assessed by comparing the characteristics of the authorization to card network rules.</summary>
        [<Config.Form>]FraudDisputabilityLikelihood: Create'FraudDisputabilityLikelihood option
        ///<summary>Information about fuel that was purchased with this transaction.</summary>
        [<Config.Form>]Fuel: Create'Fuel option
        ///<summary>If set `true`, you may provide [amount](https://docs.stripe.com/api/issuing/authorizations/approve#approve_issuing_authorization-amount) to control how much to hold for the authorization.</summary>
        [<Config.Form>]IsAmountControllable: bool option
        ///<summary>The total amount to attempt to authorize. This amount is in the provided merchant currency, and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).</summary>
        [<Config.Form>]MerchantAmount: int option
        ///<summary>The currency of the authorization. If not provided, defaults to the currency of the card. Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]MerchantCurrency: IsoTypes.IsoCurrencyCode option
        ///<summary>Details about the seller (grocery store, e-commerce website, etc.) where the card authorization happened.</summary>
        [<Config.Form>]MerchantData: Create'MerchantData option
        ///<summary>Details about the authorization, such as identifiers, set by the card network.</summary>
        [<Config.Form>]NetworkData: Create'NetworkData option
        ///<summary>Stripe’s assessment of the fraud risk for this authorization.</summary>
        [<Config.Form>]RiskAssessment: Create'RiskAssessment option
        ///<summary>Verifications that Stripe performed on information that the cardholder provided to the merchant.</summary>
        [<Config.Form>]VerificationData: Create'VerificationData option
        ///<summary>The digital wallet used for this transaction. One of `apple_pay`, `google_pay`, or `samsung_pay`. Will populate as `null` when no digital wallet was utilized.</summary>
        [<Config.Form>]Wallet: Create'Wallet option
    }
    with
        static member New(card: string, ?amount: int, ?riskAssessment: Create'RiskAssessment, ?networkData: Create'NetworkData, ?merchantData: Create'MerchantData, ?merchantCurrency: IsoTypes.IsoCurrencyCode, ?merchantAmount: int, ?isAmountControllable: bool, ?fuel: Create'Fuel, ?fraudDisputabilityLikelihood: Create'FraudDisputabilityLikelihood, ?fleet: Create'Fleet, ?expand: string list, ?currency: IsoTypes.IsoCurrencyCode, ?authorizationMethod: Create'AuthorizationMethod, ?amountDetails: Create'AmountDetails, ?verificationData: Create'VerificationData, ?wallet: Create'Wallet) =
            {
                Amount = amount
                AmountDetails = amountDetails
                AuthorizationMethod = authorizationMethod
                Card = card
                Currency = currency
                Expand = expand
                Fleet = fleet
                FraudDisputabilityLikelihood = fraudDisputabilityLikelihood
                Fuel = fuel
                IsAmountControllable = isAmountControllable
                MerchantAmount = merchantAmount
                MerchantCurrency = merchantCurrency
                MerchantData = merchantData
                NetworkData = networkData
                RiskAssessment = riskAssessment
                VerificationData = verificationData
                Wallet = wallet
            }

    ///<summary><p>Create a test-mode authorization.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/test_helpers/issuing/authorizations"
        |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) options

module TestHelpersIssuingAuthorizationsCapture =

    type Capture'PurchaseDetailsFleetCardholderPromptData = {
        ///<summary>Driver ID.</summary>
        [<Config.Form>]DriverId: string option
        ///<summary>Odometer reading.</summary>
        [<Config.Form>]Odometer: int option
        ///<summary>An alphanumeric ID. This field is used when a vehicle ID, driver ID, or generic ID is entered by the cardholder, but the merchant or card network did not specify the prompt type.</summary>
        [<Config.Form>]UnspecifiedId: string option
        ///<summary>User ID.</summary>
        [<Config.Form>]UserId: string option
        ///<summary>Vehicle number.</summary>
        [<Config.Form>]VehicleNumber: string option
    }
    with
        static member New(?driverId: string, ?odometer: int, ?unspecifiedId: string, ?userId: string, ?vehicleNumber: string) =
            {
                DriverId = driverId
                Odometer = odometer
                UnspecifiedId = unspecifiedId
                UserId = userId
                VehicleNumber = vehicleNumber
            }

    type Capture'PurchaseDetailsFleetReportedBreakdownFuel = {
        ///<summary>Gross fuel amount that should equal Fuel Volume multipled by Fuel Unit Cost, inclusive of taxes.</summary>
        [<Config.Form>]GrossAmountDecimal: string option
    }
    with
        static member New(?grossAmountDecimal: string) =
            {
                GrossAmountDecimal = grossAmountDecimal
            }

    type Capture'PurchaseDetailsFleetReportedBreakdownNonFuel = {
        ///<summary>Gross non-fuel amount that should equal the sum of the line items, inclusive of taxes.</summary>
        [<Config.Form>]GrossAmountDecimal: string option
    }
    with
        static member New(?grossAmountDecimal: string) =
            {
                GrossAmountDecimal = grossAmountDecimal
            }

    type Capture'PurchaseDetailsFleetReportedBreakdownTax = {
        ///<summary>Amount of state or provincial Sales Tax included in the transaction amount. Null if not reported by merchant or not subject to tax.</summary>
        [<Config.Form>]LocalAmountDecimal: string option
        ///<summary>Amount of national Sales Tax or VAT included in the transaction amount. Null if not reported by merchant or not subject to tax.</summary>
        [<Config.Form>]NationalAmountDecimal: string option
    }
    with
        static member New(?localAmountDecimal: string, ?nationalAmountDecimal: string) =
            {
                LocalAmountDecimal = localAmountDecimal
                NationalAmountDecimal = nationalAmountDecimal
            }

    type Capture'PurchaseDetailsFleetReportedBreakdown = {
        ///<summary>Breakdown of fuel portion of the purchase.</summary>
        [<Config.Form>]Fuel: Capture'PurchaseDetailsFleetReportedBreakdownFuel option
        ///<summary>Breakdown of non-fuel portion of the purchase.</summary>
        [<Config.Form>]NonFuel: Capture'PurchaseDetailsFleetReportedBreakdownNonFuel option
        ///<summary>Information about tax included in this transaction.</summary>
        [<Config.Form>]Tax: Capture'PurchaseDetailsFleetReportedBreakdownTax option
    }
    with
        static member New(?fuel: Capture'PurchaseDetailsFleetReportedBreakdownFuel, ?nonFuel: Capture'PurchaseDetailsFleetReportedBreakdownNonFuel, ?tax: Capture'PurchaseDetailsFleetReportedBreakdownTax) =
            {
                Fuel = fuel
                NonFuel = nonFuel
                Tax = tax
            }

    type Capture'PurchaseDetailsFleetPurchaseType =
    | FuelAndNonFuelPurchase
    | FuelPurchase
    | NonFuelPurchase

    type Capture'PurchaseDetailsFleetServiceType =
    | FullService
    | NonFuelTransaction
    | SelfService

    type Capture'PurchaseDetailsFleet = {
        ///<summary>Answers to prompts presented to the cardholder at the point of sale. Prompted fields vary depending on the configuration of your physical fleet cards. Typical points of sale support only numeric entry.</summary>
        [<Config.Form>]CardholderPromptData: Capture'PurchaseDetailsFleetCardholderPromptData option
        ///<summary>The type of purchase. One of `fuel_purchase`, `non_fuel_purchase`, or `fuel_and_non_fuel_purchase`.</summary>
        [<Config.Form>]PurchaseType: Capture'PurchaseDetailsFleetPurchaseType option
        ///<summary>More information about the total amount. This information is not guaranteed to be accurate as some merchants may provide unreliable data.</summary>
        [<Config.Form>]ReportedBreakdown: Capture'PurchaseDetailsFleetReportedBreakdown option
        ///<summary>The type of fuel service. One of `non_fuel_transaction`, `full_service`, or `self_service`.</summary>
        [<Config.Form>]ServiceType: Capture'PurchaseDetailsFleetServiceType option
    }
    with
        static member New(?cardholderPromptData: Capture'PurchaseDetailsFleetCardholderPromptData, ?purchaseType: Capture'PurchaseDetailsFleetPurchaseType, ?reportedBreakdown: Capture'PurchaseDetailsFleetReportedBreakdown, ?serviceType: Capture'PurchaseDetailsFleetServiceType) =
            {
                CardholderPromptData = cardholderPromptData
                PurchaseType = purchaseType
                ReportedBreakdown = reportedBreakdown
                ServiceType = serviceType
            }

    type Capture'PurchaseDetailsFlightSegments = {
        ///<summary>The three-letter IATA airport code of the flight's destination.</summary>
        [<Config.Form>]ArrivalAirportCode: string option
        ///<summary>The airline carrier code.</summary>
        [<Config.Form>]Carrier: string option
        ///<summary>The three-letter IATA airport code that the flight departed from.</summary>
        [<Config.Form>]DepartureAirportCode: string option
        ///<summary>The flight number.</summary>
        [<Config.Form>]FlightNumber: string option
        ///<summary>The flight's service class.</summary>
        [<Config.Form>]ServiceClass: string option
        ///<summary>Whether a stopover is allowed on this flight.</summary>
        [<Config.Form>]StopoverAllowed: bool option
    }
    with
        static member New(?arrivalAirportCode: string, ?carrier: string, ?departureAirportCode: string, ?flightNumber: string, ?serviceClass: string, ?stopoverAllowed: bool) =
            {
                ArrivalAirportCode = arrivalAirportCode
                Carrier = carrier
                DepartureAirportCode = departureAirportCode
                FlightNumber = flightNumber
                ServiceClass = serviceClass
                StopoverAllowed = stopoverAllowed
            }

    type Capture'PurchaseDetailsFlight = {
        ///<summary>The time that the flight departed.</summary>
        [<Config.Form>]DepartureAt: DateTime option
        ///<summary>The name of the passenger.</summary>
        [<Config.Form>]PassengerName: string option
        ///<summary>Whether the ticket is refundable.</summary>
        [<Config.Form>]Refundable: bool option
        ///<summary>The legs of the trip.</summary>
        [<Config.Form>]Segments: Capture'PurchaseDetailsFlightSegments list option
        ///<summary>The travel agency that issued the ticket.</summary>
        [<Config.Form>]TravelAgency: string option
    }
    with
        static member New(?departureAt: DateTime, ?passengerName: string, ?refundable: bool, ?segments: Capture'PurchaseDetailsFlightSegments list, ?travelAgency: string) =
            {
                DepartureAt = departureAt
                PassengerName = passengerName
                Refundable = refundable
                Segments = segments
                TravelAgency = travelAgency
            }

    type Capture'PurchaseDetailsFuelType =
    | Diesel
    | Other
    | UnleadedPlus
    | UnleadedRegular
    | UnleadedSuper

    type Capture'PurchaseDetailsFuelUnit =
    | ChargingMinute
    | ImperialGallon
    | Kilogram
    | KilowattHour
    | Liter
    | Other
    | Pound
    | UsGallon

    type Capture'PurchaseDetailsFuel = {
        ///<summary>[Conexxus Payment System Product Code](https://www.conexxus.org/conexxus-payment-system-product-codes) identifying the primary fuel product purchased.</summary>
        [<Config.Form>]IndustryProductCode: string option
        ///<summary>The quantity of `unit`s of fuel that was dispensed, represented as a decimal string with at most 12 decimal places.</summary>
        [<Config.Form>]QuantityDecimal: string option
        ///<summary>The type of fuel that was purchased. One of `diesel`, `unleaded_plus`, `unleaded_regular`, `unleaded_super`, or `other`.</summary>
        [<Config.Form>]Type: Capture'PurchaseDetailsFuelType option
        ///<summary>The units for `quantity_decimal`. One of `charging_minute`, `imperial_gallon`, `kilogram`, `kilowatt_hour`, `liter`, `pound`, `us_gallon`, or `other`.</summary>
        [<Config.Form>]Unit: Capture'PurchaseDetailsFuelUnit option
        ///<summary>The cost in cents per each unit of fuel, represented as a decimal string with at most 12 decimal places.</summary>
        [<Config.Form>]UnitCostDecimal: string option
    }
    with
        static member New(?industryProductCode: string, ?quantityDecimal: string, ?type': Capture'PurchaseDetailsFuelType, ?unit: Capture'PurchaseDetailsFuelUnit, ?unitCostDecimal: string) =
            {
                IndustryProductCode = industryProductCode
                QuantityDecimal = quantityDecimal
                Type = type'
                Unit = unit
                UnitCostDecimal = unitCostDecimal
            }

    type Capture'PurchaseDetailsLodging = {
        ///<summary>The time of checking into the lodging.</summary>
        [<Config.Form>]CheckInAt: DateTime option
        ///<summary>The number of nights stayed at the lodging.</summary>
        [<Config.Form>]Nights: int option
    }
    with
        static member New(?checkInAt: DateTime, ?nights: int) =
            {
                CheckInAt = checkInAt
                Nights = nights
            }

    type Capture'PurchaseDetailsReceipt = {
        [<Config.Form>]Description: string option
        [<Config.Form>]Quantity: string option
        [<Config.Form>]Total: int option
        [<Config.Form>]UnitCost: int option
    }
    with
        static member New(?description: string, ?quantity: string, ?total: int, ?unitCost: int) =
            {
                Description = description
                Quantity = quantity
                Total = total
                UnitCost = unitCost
            }

    type Capture'PurchaseDetails = {
        ///<summary>Fleet-specific information for transactions using Fleet cards.</summary>
        [<Config.Form>]Fleet: Capture'PurchaseDetailsFleet option
        ///<summary>Information about the flight that was purchased with this transaction.</summary>
        [<Config.Form>]Flight: Capture'PurchaseDetailsFlight option
        ///<summary>Information about fuel that was purchased with this transaction.</summary>
        [<Config.Form>]Fuel: Capture'PurchaseDetailsFuel option
        ///<summary>Information about lodging that was purchased with this transaction.</summary>
        [<Config.Form>]Lodging: Capture'PurchaseDetailsLodging option
        ///<summary>The line items in the purchase.</summary>
        [<Config.Form>]Receipt: Capture'PurchaseDetailsReceipt list option
        ///<summary>A merchant-specific order number.</summary>
        [<Config.Form>]Reference: string option
    }
    with
        static member New(?fleet: Capture'PurchaseDetailsFleet, ?flight: Capture'PurchaseDetailsFlight, ?fuel: Capture'PurchaseDetailsFuel, ?lodging: Capture'PurchaseDetailsLodging, ?receipt: Capture'PurchaseDetailsReceipt list, ?reference: string) =
            {
                Fleet = fleet
                Flight = flight
                Fuel = fuel
                Lodging = lodging
                Receipt = receipt
                Reference = reference
            }

    type CaptureOptions = {
        [<Config.Path>]Authorization: string
        ///<summary>The amount to capture from the authorization. If not provided, the full amount of the authorization will be captured. This amount is in the authorization currency and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).</summary>
        [<Config.Form>]CaptureAmount: int option
        ///<summary>Whether to close the authorization after capture. Defaults to true. Set to false to enable multi-capture flows.</summary>
        [<Config.Form>]CloseAuthorization: bool option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Additional purchase information that is optionally provided by the merchant.</summary>
        [<Config.Form>]PurchaseDetails: Capture'PurchaseDetails option
    }
    with
        static member New(authorization: string, ?captureAmount: int, ?closeAuthorization: bool, ?expand: string list, ?purchaseDetails: Capture'PurchaseDetails) =
            {
                Authorization = authorization
                CaptureAmount = captureAmount
                CloseAuthorization = closeAuthorization
                Expand = expand
                PurchaseDetails = purchaseDetails
            }

    ///<summary><p>Capture a test-mode authorization.</p></summary>
    let Capture settings (options: CaptureOptions) =
        $"/v1/test_helpers/issuing/authorizations/{options.Authorization}/capture"
        |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) options

module TestHelpersIssuingAuthorizationsExpire =

    type ExpireOptions = {
        [<Config.Path>]Authorization: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(authorization: string, ?expand: string list) =
            {
                Authorization = authorization
                Expand = expand
            }

    ///<summary><p>Expire a test-mode Authorization.</p></summary>
    let Expire settings (options: ExpireOptions) =
        $"/v1/test_helpers/issuing/authorizations/{options.Authorization}/expire"
        |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) options

module TestHelpersIssuingAuthorizationsFinalizeAmount =

    type FinalizeAmount'FleetCardholderPromptData = {
        ///<summary>Driver ID.</summary>
        [<Config.Form>]DriverId: string option
        ///<summary>Odometer reading.</summary>
        [<Config.Form>]Odometer: int option
        ///<summary>An alphanumeric ID. This field is used when a vehicle ID, driver ID, or generic ID is entered by the cardholder, but the merchant or card network did not specify the prompt type.</summary>
        [<Config.Form>]UnspecifiedId: string option
        ///<summary>User ID.</summary>
        [<Config.Form>]UserId: string option
        ///<summary>Vehicle number.</summary>
        [<Config.Form>]VehicleNumber: string option
    }
    with
        static member New(?driverId: string, ?odometer: int, ?unspecifiedId: string, ?userId: string, ?vehicleNumber: string) =
            {
                DriverId = driverId
                Odometer = odometer
                UnspecifiedId = unspecifiedId
                UserId = userId
                VehicleNumber = vehicleNumber
            }

    type FinalizeAmount'FleetReportedBreakdownFuel = {
        ///<summary>Gross fuel amount that should equal Fuel Volume multipled by Fuel Unit Cost, inclusive of taxes.</summary>
        [<Config.Form>]GrossAmountDecimal: string option
    }
    with
        static member New(?grossAmountDecimal: string) =
            {
                GrossAmountDecimal = grossAmountDecimal
            }

    type FinalizeAmount'FleetReportedBreakdownNonFuel = {
        ///<summary>Gross non-fuel amount that should equal the sum of the line items, inclusive of taxes.</summary>
        [<Config.Form>]GrossAmountDecimal: string option
    }
    with
        static member New(?grossAmountDecimal: string) =
            {
                GrossAmountDecimal = grossAmountDecimal
            }

    type FinalizeAmount'FleetReportedBreakdownTax = {
        ///<summary>Amount of state or provincial Sales Tax included in the transaction amount. Null if not reported by merchant or not subject to tax.</summary>
        [<Config.Form>]LocalAmountDecimal: string option
        ///<summary>Amount of national Sales Tax or VAT included in the transaction amount. Null if not reported by merchant or not subject to tax.</summary>
        [<Config.Form>]NationalAmountDecimal: string option
    }
    with
        static member New(?localAmountDecimal: string, ?nationalAmountDecimal: string) =
            {
                LocalAmountDecimal = localAmountDecimal
                NationalAmountDecimal = nationalAmountDecimal
            }

    type FinalizeAmount'FleetReportedBreakdown = {
        ///<summary>Breakdown of fuel portion of the purchase.</summary>
        [<Config.Form>]Fuel: FinalizeAmount'FleetReportedBreakdownFuel option
        ///<summary>Breakdown of non-fuel portion of the purchase.</summary>
        [<Config.Form>]NonFuel: FinalizeAmount'FleetReportedBreakdownNonFuel option
        ///<summary>Information about tax included in this transaction.</summary>
        [<Config.Form>]Tax: FinalizeAmount'FleetReportedBreakdownTax option
    }
    with
        static member New(?fuel: FinalizeAmount'FleetReportedBreakdownFuel, ?nonFuel: FinalizeAmount'FleetReportedBreakdownNonFuel, ?tax: FinalizeAmount'FleetReportedBreakdownTax) =
            {
                Fuel = fuel
                NonFuel = nonFuel
                Tax = tax
            }

    type FinalizeAmount'FleetPurchaseType =
    | FuelAndNonFuelPurchase
    | FuelPurchase
    | NonFuelPurchase

    type FinalizeAmount'FleetServiceType =
    | FullService
    | NonFuelTransaction
    | SelfService

    type FinalizeAmount'Fleet = {
        ///<summary>Answers to prompts presented to the cardholder at the point of sale. Prompted fields vary depending on the configuration of your physical fleet cards. Typical points of sale support only numeric entry.</summary>
        [<Config.Form>]CardholderPromptData: FinalizeAmount'FleetCardholderPromptData option
        ///<summary>The type of purchase. One of `fuel_purchase`, `non_fuel_purchase`, or `fuel_and_non_fuel_purchase`.</summary>
        [<Config.Form>]PurchaseType: FinalizeAmount'FleetPurchaseType option
        ///<summary>More information about the total amount. This information is not guaranteed to be accurate as some merchants may provide unreliable data.</summary>
        [<Config.Form>]ReportedBreakdown: FinalizeAmount'FleetReportedBreakdown option
        ///<summary>The type of fuel service. One of `non_fuel_transaction`, `full_service`, or `self_service`.</summary>
        [<Config.Form>]ServiceType: FinalizeAmount'FleetServiceType option
    }
    with
        static member New(?cardholderPromptData: FinalizeAmount'FleetCardholderPromptData, ?purchaseType: FinalizeAmount'FleetPurchaseType, ?reportedBreakdown: FinalizeAmount'FleetReportedBreakdown, ?serviceType: FinalizeAmount'FleetServiceType) =
            {
                CardholderPromptData = cardholderPromptData
                PurchaseType = purchaseType
                ReportedBreakdown = reportedBreakdown
                ServiceType = serviceType
            }

    type FinalizeAmount'FuelType =
    | Diesel
    | Other
    | UnleadedPlus
    | UnleadedRegular
    | UnleadedSuper

    type FinalizeAmount'FuelUnit =
    | ChargingMinute
    | ImperialGallon
    | Kilogram
    | KilowattHour
    | Liter
    | Other
    | Pound
    | UsGallon

    type FinalizeAmount'Fuel = {
        ///<summary>[Conexxus Payment System Product Code](https://www.conexxus.org/conexxus-payment-system-product-codes) identifying the primary fuel product purchased.</summary>
        [<Config.Form>]IndustryProductCode: string option
        ///<summary>The quantity of `unit`s of fuel that was dispensed, represented as a decimal string with at most 12 decimal places.</summary>
        [<Config.Form>]QuantityDecimal: string option
        ///<summary>The type of fuel that was purchased. One of `diesel`, `unleaded_plus`, `unleaded_regular`, `unleaded_super`, or `other`.</summary>
        [<Config.Form>]Type: FinalizeAmount'FuelType option
        ///<summary>The units for `quantity_decimal`. One of `charging_minute`, `imperial_gallon`, `kilogram`, `kilowatt_hour`, `liter`, `pound`, `us_gallon`, or `other`.</summary>
        [<Config.Form>]Unit: FinalizeAmount'FuelUnit option
        ///<summary>The cost in cents per each unit of fuel, represented as a decimal string with at most 12 decimal places.</summary>
        [<Config.Form>]UnitCostDecimal: string option
    }
    with
        static member New(?industryProductCode: string, ?quantityDecimal: string, ?type': FinalizeAmount'FuelType, ?unit: FinalizeAmount'FuelUnit, ?unitCostDecimal: string) =
            {
                IndustryProductCode = industryProductCode
                QuantityDecimal = quantityDecimal
                Type = type'
                Unit = unit
                UnitCostDecimal = unitCostDecimal
            }

    type FinalizeAmountOptions = {
        [<Config.Path>]Authorization: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The final authorization amount that will be captured by the merchant. This amount is in the authorization currency and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).</summary>
        [<Config.Form>]FinalAmount: int
        ///<summary>Fleet-specific information for authorizations using Fleet cards.</summary>
        [<Config.Form>]Fleet: FinalizeAmount'Fleet option
        ///<summary>Information about fuel that was purchased with this transaction.</summary>
        [<Config.Form>]Fuel: FinalizeAmount'Fuel option
    }
    with
        static member New(authorization: string, finalAmount: int, ?expand: string list, ?fleet: FinalizeAmount'Fleet, ?fuel: FinalizeAmount'Fuel) =
            {
                Authorization = authorization
                Expand = expand
                FinalAmount = finalAmount
                Fleet = fleet
                Fuel = fuel
            }

    ///<summary><p>Finalize the amount on an Authorization prior to capture, when the initial authorization was for an estimated amount.</p></summary>
    let FinalizeAmount settings (options: FinalizeAmountOptions) =
        $"/v1/test_helpers/issuing/authorizations/{options.Authorization}/finalize_amount"
        |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) options

module TestHelpersIssuingAuthorizationsFraudChallengesRespond =

    type RespondOptions = {
        [<Config.Path>]Authorization: string
        ///<summary>Whether to simulate the user confirming that the transaction was legitimate (true) or telling Stripe that it was fraudulent (false).</summary>
        [<Config.Form>]Confirmed: bool
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(authorization: string, confirmed: bool, ?expand: string list) =
            {
                Authorization = authorization
                Confirmed = confirmed
                Expand = expand
            }

    ///<summary><p>Respond to a fraud challenge on a testmode Issuing authorization, simulating either a confirmation of fraud or a correction of legitimacy.</p></summary>
    let Respond settings (options: RespondOptions) =
        $"/v1/test_helpers/issuing/authorizations/{options.Authorization}/fraud_challenges/respond"
        |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) options

module TestHelpersIssuingAuthorizationsIncrement =

    type IncrementOptions = {
        [<Config.Path>]Authorization: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The amount to increment the authorization by. This amount is in the authorization currency and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).</summary>
        [<Config.Form>]IncrementAmount: int
        ///<summary>If set `true`, you may provide [amount](https://docs.stripe.com/api/issuing/authorizations/approve#approve_issuing_authorization-amount) to control how much to hold for the authorization.</summary>
        [<Config.Form>]IsAmountControllable: bool option
    }
    with
        static member New(authorization: string, incrementAmount: int, ?expand: string list, ?isAmountControllable: bool) =
            {
                Authorization = authorization
                Expand = expand
                IncrementAmount = incrementAmount
                IsAmountControllable = isAmountControllable
            }

    ///<summary><p>Increment a test-mode Authorization.</p></summary>
    let Increment settings (options: IncrementOptions) =
        $"/v1/test_helpers/issuing/authorizations/{options.Authorization}/increment"
        |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) options

module TestHelpersIssuingAuthorizationsReverse =

    type ReverseOptions = {
        [<Config.Path>]Authorization: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The amount to reverse from the authorization. If not provided, the full amount of the authorization will be reversed. This amount is in the authorization currency and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).</summary>
        [<Config.Form>]ReverseAmount: int option
    }
    with
        static member New(authorization: string, ?expand: string list, ?reverseAmount: int) =
            {
                Authorization = authorization
                Expand = expand
                ReverseAmount = reverseAmount
            }

    ///<summary><p>Reverse a test-mode Authorization.</p></summary>
    let Reverse settings (options: ReverseOptions) =
        $"/v1/test_helpers/issuing/authorizations/{options.Authorization}/reverse"
        |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) options

module TestHelpersIssuingCardsShippingDeliver =

    type DeliverCardOptions = {
        [<Config.Path>]Card: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(card: string, ?expand: string list) =
            {
                Card = card
                Expand = expand
            }

    ///<summary><p>Updates the shipping status of the specified Issuing <code>Card</code> object to <code>delivered</code>.</p></summary>
    let DeliverCard settings (options: DeliverCardOptions) =
        $"/v1/test_helpers/issuing/cards/{options.Card}/shipping/deliver"
        |> RestApi.postAsync<_, IssuingCard> settings (Map.empty) options

module TestHelpersIssuingCardsShippingFail =

    type FailCardOptions = {
        [<Config.Path>]Card: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(card: string, ?expand: string list) =
            {
                Card = card
                Expand = expand
            }

    ///<summary><p>Updates the shipping status of the specified Issuing <code>Card</code> object to <code>failure</code>.</p></summary>
    let FailCard settings (options: FailCardOptions) =
        $"/v1/test_helpers/issuing/cards/{options.Card}/shipping/fail"
        |> RestApi.postAsync<_, IssuingCard> settings (Map.empty) options

module TestHelpersIssuingCardsShippingReturn =

    type ReturnCardOptions = {
        [<Config.Path>]Card: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(card: string, ?expand: string list) =
            {
                Card = card
                Expand = expand
            }

    ///<summary><p>Updates the shipping status of the specified Issuing <code>Card</code> object to <code>returned</code>.</p></summary>
    let ReturnCard settings (options: ReturnCardOptions) =
        $"/v1/test_helpers/issuing/cards/{options.Card}/shipping/return"
        |> RestApi.postAsync<_, IssuingCard> settings (Map.empty) options

module TestHelpersIssuingCardsShippingShip =

    type ShipCardOptions = {
        [<Config.Path>]Card: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(card: string, ?expand: string list) =
            {
                Card = card
                Expand = expand
            }

    ///<summary><p>Updates the shipping status of the specified Issuing <code>Card</code> object to <code>shipped</code>.</p></summary>
    let ShipCard settings (options: ShipCardOptions) =
        $"/v1/test_helpers/issuing/cards/{options.Card}/shipping/ship"
        |> RestApi.postAsync<_, IssuingCard> settings (Map.empty) options

module TestHelpersIssuingCardsShippingSubmit =

    type SubmitCardOptions = {
        [<Config.Path>]Card: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(card: string, ?expand: string list) =
            {
                Card = card
                Expand = expand
            }

    ///<summary><p>Updates the shipping status of the specified Issuing <code>Card</code> object to <code>submitted</code>. This method requires Stripe Version ‘2024-09-30.acacia’ or later.</p></summary>
    let SubmitCard settings (options: SubmitCardOptions) =
        $"/v1/test_helpers/issuing/cards/{options.Card}/shipping/submit"
        |> RestApi.postAsync<_, IssuingCard> settings (Map.empty) options

module TestHelpersIssuingPersonalizationDesignsActivate =

    type ActivateOptions = {
        [<Config.Path>]PersonalizationDesign: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(personalizationDesign: string, ?expand: string list) =
            {
                PersonalizationDesign = personalizationDesign
                Expand = expand
            }

    ///<summary><p>Updates the <code>status</code> of the specified testmode personalization design object to <code>active</code>.</p></summary>
    let Activate settings (options: ActivateOptions) =
        $"/v1/test_helpers/issuing/personalization_designs/{options.PersonalizationDesign}/activate"
        |> RestApi.postAsync<_, IssuingPersonalizationDesign> settings (Map.empty) options

module TestHelpersIssuingPersonalizationDesignsDeactivate =

    type DeactivateOptions = {
        [<Config.Path>]PersonalizationDesign: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(personalizationDesign: string, ?expand: string list) =
            {
                PersonalizationDesign = personalizationDesign
                Expand = expand
            }

    ///<summary><p>Updates the <code>status</code> of the specified testmode personalization design object to <code>inactive</code>.</p></summary>
    let Deactivate settings (options: DeactivateOptions) =
        $"/v1/test_helpers/issuing/personalization_designs/{options.PersonalizationDesign}/deactivate"
        |> RestApi.postAsync<_, IssuingPersonalizationDesign> settings (Map.empty) options

module TestHelpersIssuingPersonalizationDesignsReject =

    type Reject'RejectionReasonsCardLogo =
    | GeographicLocation
    | Inappropriate
    | NetworkName
    | NonBinaryImage
    | NonFiatCurrency
    | Other
    | OtherEntity
    | PromotionalMaterial

    type Reject'RejectionReasonsCarrierText =
    | GeographicLocation
    | Inappropriate
    | NetworkName
    | NonFiatCurrency
    | Other
    | OtherEntity
    | PromotionalMaterial

    type Reject'RejectionReasons = {
        ///<summary>The reason(s) the card logo was rejected.</summary>
        [<Config.Form>]CardLogo: Reject'RejectionReasonsCardLogo list option
        ///<summary>The reason(s) the carrier text was rejected.</summary>
        [<Config.Form>]CarrierText: Reject'RejectionReasonsCarrierText list option
    }
    with
        static member New(?cardLogo: Reject'RejectionReasonsCardLogo list, ?carrierText: Reject'RejectionReasonsCarrierText list) =
            {
                CardLogo = cardLogo
                CarrierText = carrierText
            }

    type RejectOptions = {
        [<Config.Path>]PersonalizationDesign: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The reason(s) the personalization design was rejected.</summary>
        [<Config.Form>]RejectionReasons: Reject'RejectionReasons
    }
    with
        static member New(personalizationDesign: string, rejectionReasons: Reject'RejectionReasons, ?expand: string list) =
            {
                PersonalizationDesign = personalizationDesign
                Expand = expand
                RejectionReasons = rejectionReasons
            }

    ///<summary><p>Updates the <code>status</code> of the specified testmode personalization design object to <code>rejected</code>.</p></summary>
    let Reject settings (options: RejectOptions) =
        $"/v1/test_helpers/issuing/personalization_designs/{options.PersonalizationDesign}/reject"
        |> RestApi.postAsync<_, IssuingPersonalizationDesign> settings (Map.empty) options

module TestHelpersIssuingTransactionsCreateForceCapture =

    type CreateForceCapture'MerchantDataCategory =
    | AcRefrigerationRepair
    | AccountingBookkeepingServices
    | AdvertisingServices
    | AgriculturalCooperative
    | AirlinesAirCarriers
    | AirportsFlyingFields
    | AmbulanceServices
    | AmusementParksCarnivals
    | AntiqueReproductions
    | AntiqueShops
    | Aquariums
    | ArchitecturalSurveyingServices
    | ArtDealersAndGalleries
    | ArtistsSupplyAndCraftShops
    | AutoAndHomeSupplyStores
    | AutoBodyRepairShops
    | AutoPaintShops
    | AutoServiceShops
    | AutomatedCashDisburse
    | AutomatedFuelDispensers
    | AutomobileAssociations
    | AutomotivePartsAndAccessoriesStores
    | AutomotiveTireStores
    | BailAndBondPayments
    | Bakeries
    | BandsOrchestras
    | BarberAndBeautyShops
    | BettingCasinoGambling
    | BicycleShops
    | BilliardPoolEstablishments
    | BoatDealers
    | BoatRentalsAndLeases
    | BookStores
    | BooksPeriodicalsAndNewspapers
    | BowlingAlleys
    | BusLines
    | BusinessSecretarialSchools
    | BuyingShoppingServices
    | CableSatelliteAndOtherPayTelevisionAndRadio
    | CameraAndPhotographicSupplyStores
    | CandyNutAndConfectioneryStores
    | CarAndTruckDealersNewUsed
    | CarAndTruckDealersUsedOnly
    | CarRentalAgencies
    | CarWashes
    | CarpentryServices
    | CarpetUpholsteryCleaning
    | Caterers
    | CharitableAndSocialServiceOrganizationsFundraising
    | ChemicalsAndAlliedProducts
    | ChildCareServices
    | ChildrensAndInfantsWearStores
    | ChiropodistsPodiatrists
    | Chiropractors
    | CigarStoresAndStands
    | CivicSocialFraternalAssociations
    | CleaningAndMaintenance
    | ClothingRental
    | CollegesUniversities
    | CommercialEquipment
    | CommercialFootwear
    | CommercialPhotographyArtAndGraphics
    | CommuterTransportAndFerries
    | ComputerNetworkServices
    | ComputerProgramming
    | ComputerRepair
    | ComputerSoftwareStores
    | ComputersPeripheralsAndSoftware
    | ConcreteWorkServices
    | ConstructionMaterials
    | ConsultingPublicRelations
    | CorrespondenceSchools
    | CosmeticStores
    | CounselingServices
    | CountryClubs
    | CourierServices
    | CourtCosts
    | CreditReportingAgencies
    | CruiseLines
    | DairyProductsStores
    | DanceHallStudiosSchools
    | DatingEscortServices
    | DentistsOrthodontists
    | DepartmentStores
    | DetectiveAgencies
    | DigitalGoodsApplications
    | DigitalGoodsGames
    | DigitalGoodsLargeVolume
    | DigitalGoodsMedia
    | DirectMarketingCatalogMerchant
    | DirectMarketingCombinationCatalogAndRetailMerchant
    | DirectMarketingInboundTelemarketing
    | DirectMarketingInsuranceServices
    | DirectMarketingOther
    | DirectMarketingOutboundTelemarketing
    | DirectMarketingSubscription
    | DirectMarketingTravel
    | DiscountStores
    | Doctors
    | DoorToDoorSales
    | DraperyWindowCoveringAndUpholsteryStores
    | DrinkingPlaces
    | DrugStoresAndPharmacies
    | DrugsDrugProprietariesAndDruggistSundries
    | DryCleaners
    | DurableGoods
    | DutyFreeStores
    | EatingPlacesRestaurants
    | EducationalServices
    | ElectricRazorStores
    | ElectricVehicleCharging
    | ElectricalPartsAndEquipment
    | ElectricalServices
    | ElectronicsRepairShops
    | ElectronicsStores
    | ElementarySecondarySchools
    | EmergencyServicesGcasVisaUseOnly
    | EmploymentTempAgencies
    | EquipmentRental
    | ExterminatingServices
    | FamilyClothingStores
    | FastFoodRestaurants
    | FinancialInstitutions
    | FinesGovernmentAdministrativeEntities
    | FireplaceFireplaceScreensAndAccessoriesStores
    | FloorCoveringStores
    | Florists
    | FloristsSuppliesNurseryStockAndFlowers
    | FreezerAndLockerMeatProvisioners
    | FuelDealersNonAutomotive
    | FuneralServicesCrematories
    | FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
    | FurnitureRepairRefinishing
    | FurriersAndFurShops
    | GeneralServices
    | GiftCardNoveltyAndSouvenirShops
    | GlassPaintAndWallpaperStores
    | GlasswareCrystalStores
    | GolfCoursesPublic
    | GovernmentLicensedHorseDogRacingUsRegionOnly
    | GovernmentLicensedOnlineCasionsOnlineGamblingUsRegionOnly
    | GovernmentOwnedLotteriesNonUsRegion
    | GovernmentOwnedLotteriesUsRegionOnly
    | GovernmentServices
    | GroceryStoresSupermarkets
    | HardwareEquipmentAndSupplies
    | HardwareStores
    | HealthAndBeautySpas
    | HearingAidsSalesAndSupplies
    | HeatingPlumbingAC
    | HobbyToyAndGameShops
    | HomeSupplyWarehouseStores
    | Hospitals
    | HotelsMotelsAndResorts
    | HouseholdApplianceStores
    | IndustrialSupplies
    | InformationRetrievalServices
    | InsuranceDefault
    | InsuranceUnderwritingPremiums
    | IntraCompanyPurchases
    | JewelryStoresWatchesClocksAndSilverwareStores
    | LandscapingServices
    | Laundries
    | LaundryCleaningServices
    | LegalServicesAttorneys
    | LuggageAndLeatherGoodsStores
    | LumberBuildingMaterialsStores
    | ManualCashDisburse
    | MarinasServiceAndSupplies
    | Marketplaces
    | MasonryStoneworkAndPlaster
    | MassageParlors
    | MedicalAndDentalLabs
    | MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
    | MedicalServices
    | MembershipOrganizations
    | MensAndBoysClothingAndAccessoriesStores
    | MensWomensClothingStores
    | MetalServiceCenters
    | MiscellaneousApparelAndAccessoryShops
    | MiscellaneousAutoDealers
    | MiscellaneousBusinessServices
    | MiscellaneousFoodStores
    | MiscellaneousGeneralMerchandise
    | MiscellaneousGeneralServices
    | MiscellaneousHomeFurnishingSpecialtyStores
    | MiscellaneousPublishingAndPrinting
    | MiscellaneousRecreationServices
    | MiscellaneousRepairShops
    | MiscellaneousSpecialtyRetail
    | MobileHomeDealers
    | MotionPictureTheaters
    | MotorFreightCarriersAndTrucking
    | MotorHomesDealers
    | MotorVehicleSuppliesAndNewParts
    | MotorcycleShopsAndDealers
    | MotorcycleShopsDealers
    | MusicStoresMusicalInstrumentsPianosAndSheetMusic
    | NewsDealersAndNewsstands
    | NonFiMoneyOrders
    | NonFiStoredValueCardPurchaseLoad
    | NondurableGoods
    | NurseriesLawnAndGardenSupplyStores
    | NursingPersonalCare
    | OfficeAndCommercialFurniture
    | OpticiansEyeglasses
    | OptometristsOphthalmologist
    | OrthopedicGoodsProstheticDevices
    | Osteopaths
    | PackageStoresBeerWineAndLiquor
    | PaintsVarnishesAndSupplies
    | ParkingLotsGarages
    | PassengerRailways
    | PawnShops
    | PetShopsPetFoodAndSupplies
    | PetroleumAndPetroleumProducts
    | PhotoDeveloping
    | PhotographicPhotocopyMicrofilmEquipmentAndSupplies
    | PhotographicStudios
    | PictureVideoProduction
    | PieceGoodsNotionsAndOtherDryGoods
    | PlumbingHeatingEquipmentAndSupplies
    | PoliticalOrganizations
    | PostalServicesGovernmentOnly
    | PreciousStonesAndMetalsWatchesAndJewelry
    | ProfessionalServices
    | PublicWarehousingAndStorage
    | QuickCopyReproAndBlueprint
    | Railroads
    | RealEstateAgentsAndManagersRentals
    | RecordStores
    | RecreationalVehicleRentals
    | ReligiousGoodsStores
    | ReligiousOrganizations
    | RoofingSidingSheetMetal
    | SecretarialSupportServices
    | SecurityBrokersDealers
    | ServiceStations
    | SewingNeedleworkFabricAndPieceGoodsStores
    | ShoeRepairHatCleaning
    | ShoeStores
    | SmallApplianceRepair
    | SnowmobileDealers
    | SpecialTradeServices
    | SpecialtyCleaning
    | SportingGoodsStores
    | SportingRecreationCamps
    | SportsAndRidingApparelStores
    | SportsClubsFields
    | StampAndCoinStores
    | StationaryOfficeSuppliesPrintingAndWritingPaper
    | StationeryStoresOfficeAndSchoolSupplyStores
    | SwimmingPoolsSales
    | TUiTravelGermany
    | TailorsAlterations
    | TaxPaymentsGovernmentAgencies
    | TaxPreparationServices
    | TaxicabsLimousines
    | TelecommunicationEquipmentAndTelephoneSales
    | TelecommunicationServices
    | TelegraphServices
    | TentAndAwningShops
    | TestingLaboratories
    | TheatricalTicketAgencies
    | Timeshares
    | TireRetreadingAndRepair
    | TollsBridgeFees
    | TouristAttractionsAndExhibits
    | TowingServices
    | TrailerParksCampgrounds
    | TransportationServices
    | TravelAgenciesTourOperators
    | TruckStopIteration
    | TruckUtilityTrailerRentals
    | TypesettingPlateMakingAndRelatedServices
    | TypewriterStores
    | USFederalGovernmentAgenciesOrDepartments
    | UniformsCommercialClothing
    | UsedMerchandiseAndSecondhandStores
    | Utilities
    | VarietyStores
    | VeterinaryServices
    | VideoAmusementGameSupplies
    | VideoGameArcades
    | VideoTapeRentalStores
    | VocationalTradeSchools
    | WatchJewelryRepair
    | WeldingRepair
    | WholesaleClubs
    | WigAndToupeeStores
    | WiresMoneyOrders
    | WomensAccessoryAndSpecialtyShops
    | WomensReadyToWearStores
    | WreckingAndSalvageYards

    type CreateForceCapture'MerchantData = {
        ///<summary>A categorization of the seller's type of business. See our [merchant categories guide](https://docs.stripe.com/issuing/merchant-categories) for a list of possible values.</summary>
        [<Config.Form>]Category: CreateForceCapture'MerchantDataCategory option
        ///<summary>City where the seller is located</summary>
        [<Config.Form>]City: string option
        ///<summary>Country where the seller is located</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Name of the seller</summary>
        [<Config.Form>]Name: string option
        ///<summary>Identifier assigned to the seller by the card network. Different card networks may assign different network_id fields to the same merchant.</summary>
        [<Config.Form>]NetworkId: string option
        ///<summary>Postal code where the seller is located</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State where the seller is located</summary>
        [<Config.Form>]State: string option
        ///<summary>An ID assigned by the seller to the location of the sale.</summary>
        [<Config.Form>]TerminalId: string option
        ///<summary>URL provided by the merchant on a 3DS request</summary>
        [<Config.Form>]Url: string option
    }
    with
        static member New(?category: CreateForceCapture'MerchantDataCategory, ?city: string, ?country: IsoTypes.IsoCountryCode, ?name: string, ?networkId: string, ?postalCode: string, ?state: string, ?terminalId: string, ?url: string) =
            {
                Category = category
                City = city
                Country = country
                Name = name
                NetworkId = networkId
                PostalCode = postalCode
                State = state
                TerminalId = terminalId
                Url = url
            }

    type CreateForceCapture'PurchaseDetailsFleetCardholderPromptData = {
        ///<summary>Driver ID.</summary>
        [<Config.Form>]DriverId: string option
        ///<summary>Odometer reading.</summary>
        [<Config.Form>]Odometer: int option
        ///<summary>An alphanumeric ID. This field is used when a vehicle ID, driver ID, or generic ID is entered by the cardholder, but the merchant or card network did not specify the prompt type.</summary>
        [<Config.Form>]UnspecifiedId: string option
        ///<summary>User ID.</summary>
        [<Config.Form>]UserId: string option
        ///<summary>Vehicle number.</summary>
        [<Config.Form>]VehicleNumber: string option
    }
    with
        static member New(?driverId: string, ?odometer: int, ?unspecifiedId: string, ?userId: string, ?vehicleNumber: string) =
            {
                DriverId = driverId
                Odometer = odometer
                UnspecifiedId = unspecifiedId
                UserId = userId
                VehicleNumber = vehicleNumber
            }

    type CreateForceCapture'PurchaseDetailsFleetReportedBreakdownFuel = {
        ///<summary>Gross fuel amount that should equal Fuel Volume multipled by Fuel Unit Cost, inclusive of taxes.</summary>
        [<Config.Form>]GrossAmountDecimal: string option
    }
    with
        static member New(?grossAmountDecimal: string) =
            {
                GrossAmountDecimal = grossAmountDecimal
            }

    type CreateForceCapture'PurchaseDetailsFleetReportedBreakdownNonFuel = {
        ///<summary>Gross non-fuel amount that should equal the sum of the line items, inclusive of taxes.</summary>
        [<Config.Form>]GrossAmountDecimal: string option
    }
    with
        static member New(?grossAmountDecimal: string) =
            {
                GrossAmountDecimal = grossAmountDecimal
            }

    type CreateForceCapture'PurchaseDetailsFleetReportedBreakdownTax = {
        ///<summary>Amount of state or provincial Sales Tax included in the transaction amount. Null if not reported by merchant or not subject to tax.</summary>
        [<Config.Form>]LocalAmountDecimal: string option
        ///<summary>Amount of national Sales Tax or VAT included in the transaction amount. Null if not reported by merchant or not subject to tax.</summary>
        [<Config.Form>]NationalAmountDecimal: string option
    }
    with
        static member New(?localAmountDecimal: string, ?nationalAmountDecimal: string) =
            {
                LocalAmountDecimal = localAmountDecimal
                NationalAmountDecimal = nationalAmountDecimal
            }

    type CreateForceCapture'PurchaseDetailsFleetReportedBreakdown = {
        ///<summary>Breakdown of fuel portion of the purchase.</summary>
        [<Config.Form>]Fuel: CreateForceCapture'PurchaseDetailsFleetReportedBreakdownFuel option
        ///<summary>Breakdown of non-fuel portion of the purchase.</summary>
        [<Config.Form>]NonFuel: CreateForceCapture'PurchaseDetailsFleetReportedBreakdownNonFuel option
        ///<summary>Information about tax included in this transaction.</summary>
        [<Config.Form>]Tax: CreateForceCapture'PurchaseDetailsFleetReportedBreakdownTax option
    }
    with
        static member New(?fuel: CreateForceCapture'PurchaseDetailsFleetReportedBreakdownFuel, ?nonFuel: CreateForceCapture'PurchaseDetailsFleetReportedBreakdownNonFuel, ?tax: CreateForceCapture'PurchaseDetailsFleetReportedBreakdownTax) =
            {
                Fuel = fuel
                NonFuel = nonFuel
                Tax = tax
            }

    type CreateForceCapture'PurchaseDetailsFleetPurchaseType =
    | FuelAndNonFuelPurchase
    | FuelPurchase
    | NonFuelPurchase

    type CreateForceCapture'PurchaseDetailsFleetServiceType =
    | FullService
    | NonFuelTransaction
    | SelfService

    type CreateForceCapture'PurchaseDetailsFleet = {
        ///<summary>Answers to prompts presented to the cardholder at the point of sale. Prompted fields vary depending on the configuration of your physical fleet cards. Typical points of sale support only numeric entry.</summary>
        [<Config.Form>]CardholderPromptData: CreateForceCapture'PurchaseDetailsFleetCardholderPromptData option
        ///<summary>The type of purchase. One of `fuel_purchase`, `non_fuel_purchase`, or `fuel_and_non_fuel_purchase`.</summary>
        [<Config.Form>]PurchaseType: CreateForceCapture'PurchaseDetailsFleetPurchaseType option
        ///<summary>More information about the total amount. This information is not guaranteed to be accurate as some merchants may provide unreliable data.</summary>
        [<Config.Form>]ReportedBreakdown: CreateForceCapture'PurchaseDetailsFleetReportedBreakdown option
        ///<summary>The type of fuel service. One of `non_fuel_transaction`, `full_service`, or `self_service`.</summary>
        [<Config.Form>]ServiceType: CreateForceCapture'PurchaseDetailsFleetServiceType option
    }
    with
        static member New(?cardholderPromptData: CreateForceCapture'PurchaseDetailsFleetCardholderPromptData, ?purchaseType: CreateForceCapture'PurchaseDetailsFleetPurchaseType, ?reportedBreakdown: CreateForceCapture'PurchaseDetailsFleetReportedBreakdown, ?serviceType: CreateForceCapture'PurchaseDetailsFleetServiceType) =
            {
                CardholderPromptData = cardholderPromptData
                PurchaseType = purchaseType
                ReportedBreakdown = reportedBreakdown
                ServiceType = serviceType
            }

    type CreateForceCapture'PurchaseDetailsFlightSegments = {
        ///<summary>The three-letter IATA airport code of the flight's destination.</summary>
        [<Config.Form>]ArrivalAirportCode: string option
        ///<summary>The airline carrier code.</summary>
        [<Config.Form>]Carrier: string option
        ///<summary>The three-letter IATA airport code that the flight departed from.</summary>
        [<Config.Form>]DepartureAirportCode: string option
        ///<summary>The flight number.</summary>
        [<Config.Form>]FlightNumber: string option
        ///<summary>The flight's service class.</summary>
        [<Config.Form>]ServiceClass: string option
        ///<summary>Whether a stopover is allowed on this flight.</summary>
        [<Config.Form>]StopoverAllowed: bool option
    }
    with
        static member New(?arrivalAirportCode: string, ?carrier: string, ?departureAirportCode: string, ?flightNumber: string, ?serviceClass: string, ?stopoverAllowed: bool) =
            {
                ArrivalAirportCode = arrivalAirportCode
                Carrier = carrier
                DepartureAirportCode = departureAirportCode
                FlightNumber = flightNumber
                ServiceClass = serviceClass
                StopoverAllowed = stopoverAllowed
            }

    type CreateForceCapture'PurchaseDetailsFlight = {
        ///<summary>The time that the flight departed.</summary>
        [<Config.Form>]DepartureAt: DateTime option
        ///<summary>The name of the passenger.</summary>
        [<Config.Form>]PassengerName: string option
        ///<summary>Whether the ticket is refundable.</summary>
        [<Config.Form>]Refundable: bool option
        ///<summary>The legs of the trip.</summary>
        [<Config.Form>]Segments: CreateForceCapture'PurchaseDetailsFlightSegments list option
        ///<summary>The travel agency that issued the ticket.</summary>
        [<Config.Form>]TravelAgency: string option
    }
    with
        static member New(?departureAt: DateTime, ?passengerName: string, ?refundable: bool, ?segments: CreateForceCapture'PurchaseDetailsFlightSegments list, ?travelAgency: string) =
            {
                DepartureAt = departureAt
                PassengerName = passengerName
                Refundable = refundable
                Segments = segments
                TravelAgency = travelAgency
            }

    type CreateForceCapture'PurchaseDetailsFuelType =
    | Diesel
    | Other
    | UnleadedPlus
    | UnleadedRegular
    | UnleadedSuper

    type CreateForceCapture'PurchaseDetailsFuelUnit =
    | ChargingMinute
    | ImperialGallon
    | Kilogram
    | KilowattHour
    | Liter
    | Other
    | Pound
    | UsGallon

    type CreateForceCapture'PurchaseDetailsFuel = {
        ///<summary>[Conexxus Payment System Product Code](https://www.conexxus.org/conexxus-payment-system-product-codes) identifying the primary fuel product purchased.</summary>
        [<Config.Form>]IndustryProductCode: string option
        ///<summary>The quantity of `unit`s of fuel that was dispensed, represented as a decimal string with at most 12 decimal places.</summary>
        [<Config.Form>]QuantityDecimal: string option
        ///<summary>The type of fuel that was purchased. One of `diesel`, `unleaded_plus`, `unleaded_regular`, `unleaded_super`, or `other`.</summary>
        [<Config.Form>]Type: CreateForceCapture'PurchaseDetailsFuelType option
        ///<summary>The units for `quantity_decimal`. One of `charging_minute`, `imperial_gallon`, `kilogram`, `kilowatt_hour`, `liter`, `pound`, `us_gallon`, or `other`.</summary>
        [<Config.Form>]Unit: CreateForceCapture'PurchaseDetailsFuelUnit option
        ///<summary>The cost in cents per each unit of fuel, represented as a decimal string with at most 12 decimal places.</summary>
        [<Config.Form>]UnitCostDecimal: string option
    }
    with
        static member New(?industryProductCode: string, ?quantityDecimal: string, ?type': CreateForceCapture'PurchaseDetailsFuelType, ?unit: CreateForceCapture'PurchaseDetailsFuelUnit, ?unitCostDecimal: string) =
            {
                IndustryProductCode = industryProductCode
                QuantityDecimal = quantityDecimal
                Type = type'
                Unit = unit
                UnitCostDecimal = unitCostDecimal
            }

    type CreateForceCapture'PurchaseDetailsLodging = {
        ///<summary>The time of checking into the lodging.</summary>
        [<Config.Form>]CheckInAt: DateTime option
        ///<summary>The number of nights stayed at the lodging.</summary>
        [<Config.Form>]Nights: int option
    }
    with
        static member New(?checkInAt: DateTime, ?nights: int) =
            {
                CheckInAt = checkInAt
                Nights = nights
            }

    type CreateForceCapture'PurchaseDetailsReceipt = {
        [<Config.Form>]Description: string option
        [<Config.Form>]Quantity: string option
        [<Config.Form>]Total: int option
        [<Config.Form>]UnitCost: int option
    }
    with
        static member New(?description: string, ?quantity: string, ?total: int, ?unitCost: int) =
            {
                Description = description
                Quantity = quantity
                Total = total
                UnitCost = unitCost
            }

    type CreateForceCapture'PurchaseDetails = {
        ///<summary>Fleet-specific information for transactions using Fleet cards.</summary>
        [<Config.Form>]Fleet: CreateForceCapture'PurchaseDetailsFleet option
        ///<summary>Information about the flight that was purchased with this transaction.</summary>
        [<Config.Form>]Flight: CreateForceCapture'PurchaseDetailsFlight option
        ///<summary>Information about fuel that was purchased with this transaction.</summary>
        [<Config.Form>]Fuel: CreateForceCapture'PurchaseDetailsFuel option
        ///<summary>Information about lodging that was purchased with this transaction.</summary>
        [<Config.Form>]Lodging: CreateForceCapture'PurchaseDetailsLodging option
        ///<summary>The line items in the purchase.</summary>
        [<Config.Form>]Receipt: CreateForceCapture'PurchaseDetailsReceipt list option
        ///<summary>A merchant-specific order number.</summary>
        [<Config.Form>]Reference: string option
    }
    with
        static member New(?fleet: CreateForceCapture'PurchaseDetailsFleet, ?flight: CreateForceCapture'PurchaseDetailsFlight, ?fuel: CreateForceCapture'PurchaseDetailsFuel, ?lodging: CreateForceCapture'PurchaseDetailsLodging, ?receipt: CreateForceCapture'PurchaseDetailsReceipt list, ?reference: string) =
            {
                Fleet = fleet
                Flight = flight
                Fuel = fuel
                Lodging = lodging
                Receipt = receipt
                Reference = reference
            }

    type CreateForceCaptureOptions = {
        ///<summary>The total amount to attempt to capture. This amount is in the provided currency, or defaults to the cards currency, and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).</summary>
        [<Config.Form>]Amount: int
        ///<summary>Card associated with this transaction.</summary>
        [<Config.Form>]Card: string
        ///<summary>The currency of the capture. If not provided, defaults to the currency of the card. Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Details about the seller (grocery store, e-commerce website, etc.) where the card authorization happened.</summary>
        [<Config.Form>]MerchantData: CreateForceCapture'MerchantData option
        ///<summary>Additional purchase information that is optionally provided by the merchant.</summary>
        [<Config.Form>]PurchaseDetails: CreateForceCapture'PurchaseDetails option
    }
    with
        static member New(amount: int, card: string, ?currency: IsoTypes.IsoCurrencyCode, ?expand: string list, ?merchantData: CreateForceCapture'MerchantData, ?purchaseDetails: CreateForceCapture'PurchaseDetails) =
            {
                Amount = amount
                Card = card
                Currency = currency
                Expand = expand
                MerchantData = merchantData
                PurchaseDetails = purchaseDetails
            }

    ///<summary><p>Allows the user to capture an arbitrary amount, also known as a forced capture.</p></summary>
    let CreateForceCapture settings (options: CreateForceCaptureOptions) =
        $"/v1/test_helpers/issuing/transactions/create_force_capture"
        |> RestApi.postAsync<_, IssuingTransaction> settings (Map.empty) options

module TestHelpersIssuingTransactionsCreateUnlinkedRefund =

    type CreateUnlinkedRefund'MerchantDataCategory =
    | AcRefrigerationRepair
    | AccountingBookkeepingServices
    | AdvertisingServices
    | AgriculturalCooperative
    | AirlinesAirCarriers
    | AirportsFlyingFields
    | AmbulanceServices
    | AmusementParksCarnivals
    | AntiqueReproductions
    | AntiqueShops
    | Aquariums
    | ArchitecturalSurveyingServices
    | ArtDealersAndGalleries
    | ArtistsSupplyAndCraftShops
    | AutoAndHomeSupplyStores
    | AutoBodyRepairShops
    | AutoPaintShops
    | AutoServiceShops
    | AutomatedCashDisburse
    | AutomatedFuelDispensers
    | AutomobileAssociations
    | AutomotivePartsAndAccessoriesStores
    | AutomotiveTireStores
    | BailAndBondPayments
    | Bakeries
    | BandsOrchestras
    | BarberAndBeautyShops
    | BettingCasinoGambling
    | BicycleShops
    | BilliardPoolEstablishments
    | BoatDealers
    | BoatRentalsAndLeases
    | BookStores
    | BooksPeriodicalsAndNewspapers
    | BowlingAlleys
    | BusLines
    | BusinessSecretarialSchools
    | BuyingShoppingServices
    | CableSatelliteAndOtherPayTelevisionAndRadio
    | CameraAndPhotographicSupplyStores
    | CandyNutAndConfectioneryStores
    | CarAndTruckDealersNewUsed
    | CarAndTruckDealersUsedOnly
    | CarRentalAgencies
    | CarWashes
    | CarpentryServices
    | CarpetUpholsteryCleaning
    | Caterers
    | CharitableAndSocialServiceOrganizationsFundraising
    | ChemicalsAndAlliedProducts
    | ChildCareServices
    | ChildrensAndInfantsWearStores
    | ChiropodistsPodiatrists
    | Chiropractors
    | CigarStoresAndStands
    | CivicSocialFraternalAssociations
    | CleaningAndMaintenance
    | ClothingRental
    | CollegesUniversities
    | CommercialEquipment
    | CommercialFootwear
    | CommercialPhotographyArtAndGraphics
    | CommuterTransportAndFerries
    | ComputerNetworkServices
    | ComputerProgramming
    | ComputerRepair
    | ComputerSoftwareStores
    | ComputersPeripheralsAndSoftware
    | ConcreteWorkServices
    | ConstructionMaterials
    | ConsultingPublicRelations
    | CorrespondenceSchools
    | CosmeticStores
    | CounselingServices
    | CountryClubs
    | CourierServices
    | CourtCosts
    | CreditReportingAgencies
    | CruiseLines
    | DairyProductsStores
    | DanceHallStudiosSchools
    | DatingEscortServices
    | DentistsOrthodontists
    | DepartmentStores
    | DetectiveAgencies
    | DigitalGoodsApplications
    | DigitalGoodsGames
    | DigitalGoodsLargeVolume
    | DigitalGoodsMedia
    | DirectMarketingCatalogMerchant
    | DirectMarketingCombinationCatalogAndRetailMerchant
    | DirectMarketingInboundTelemarketing
    | DirectMarketingInsuranceServices
    | DirectMarketingOther
    | DirectMarketingOutboundTelemarketing
    | DirectMarketingSubscription
    | DirectMarketingTravel
    | DiscountStores
    | Doctors
    | DoorToDoorSales
    | DraperyWindowCoveringAndUpholsteryStores
    | DrinkingPlaces
    | DrugStoresAndPharmacies
    | DrugsDrugProprietariesAndDruggistSundries
    | DryCleaners
    | DurableGoods
    | DutyFreeStores
    | EatingPlacesRestaurants
    | EducationalServices
    | ElectricRazorStores
    | ElectricVehicleCharging
    | ElectricalPartsAndEquipment
    | ElectricalServices
    | ElectronicsRepairShops
    | ElectronicsStores
    | ElementarySecondarySchools
    | EmergencyServicesGcasVisaUseOnly
    | EmploymentTempAgencies
    | EquipmentRental
    | ExterminatingServices
    | FamilyClothingStores
    | FastFoodRestaurants
    | FinancialInstitutions
    | FinesGovernmentAdministrativeEntities
    | FireplaceFireplaceScreensAndAccessoriesStores
    | FloorCoveringStores
    | Florists
    | FloristsSuppliesNurseryStockAndFlowers
    | FreezerAndLockerMeatProvisioners
    | FuelDealersNonAutomotive
    | FuneralServicesCrematories
    | FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
    | FurnitureRepairRefinishing
    | FurriersAndFurShops
    | GeneralServices
    | GiftCardNoveltyAndSouvenirShops
    | GlassPaintAndWallpaperStores
    | GlasswareCrystalStores
    | GolfCoursesPublic
    | GovernmentLicensedHorseDogRacingUsRegionOnly
    | GovernmentLicensedOnlineCasionsOnlineGamblingUsRegionOnly
    | GovernmentOwnedLotteriesNonUsRegion
    | GovernmentOwnedLotteriesUsRegionOnly
    | GovernmentServices
    | GroceryStoresSupermarkets
    | HardwareEquipmentAndSupplies
    | HardwareStores
    | HealthAndBeautySpas
    | HearingAidsSalesAndSupplies
    | HeatingPlumbingAC
    | HobbyToyAndGameShops
    | HomeSupplyWarehouseStores
    | Hospitals
    | HotelsMotelsAndResorts
    | HouseholdApplianceStores
    | IndustrialSupplies
    | InformationRetrievalServices
    | InsuranceDefault
    | InsuranceUnderwritingPremiums
    | IntraCompanyPurchases
    | JewelryStoresWatchesClocksAndSilverwareStores
    | LandscapingServices
    | Laundries
    | LaundryCleaningServices
    | LegalServicesAttorneys
    | LuggageAndLeatherGoodsStores
    | LumberBuildingMaterialsStores
    | ManualCashDisburse
    | MarinasServiceAndSupplies
    | Marketplaces
    | MasonryStoneworkAndPlaster
    | MassageParlors
    | MedicalAndDentalLabs
    | MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
    | MedicalServices
    | MembershipOrganizations
    | MensAndBoysClothingAndAccessoriesStores
    | MensWomensClothingStores
    | MetalServiceCenters
    | MiscellaneousApparelAndAccessoryShops
    | MiscellaneousAutoDealers
    | MiscellaneousBusinessServices
    | MiscellaneousFoodStores
    | MiscellaneousGeneralMerchandise
    | MiscellaneousGeneralServices
    | MiscellaneousHomeFurnishingSpecialtyStores
    | MiscellaneousPublishingAndPrinting
    | MiscellaneousRecreationServices
    | MiscellaneousRepairShops
    | MiscellaneousSpecialtyRetail
    | MobileHomeDealers
    | MotionPictureTheaters
    | MotorFreightCarriersAndTrucking
    | MotorHomesDealers
    | MotorVehicleSuppliesAndNewParts
    | MotorcycleShopsAndDealers
    | MotorcycleShopsDealers
    | MusicStoresMusicalInstrumentsPianosAndSheetMusic
    | NewsDealersAndNewsstands
    | NonFiMoneyOrders
    | NonFiStoredValueCardPurchaseLoad
    | NondurableGoods
    | NurseriesLawnAndGardenSupplyStores
    | NursingPersonalCare
    | OfficeAndCommercialFurniture
    | OpticiansEyeglasses
    | OptometristsOphthalmologist
    | OrthopedicGoodsProstheticDevices
    | Osteopaths
    | PackageStoresBeerWineAndLiquor
    | PaintsVarnishesAndSupplies
    | ParkingLotsGarages
    | PassengerRailways
    | PawnShops
    | PetShopsPetFoodAndSupplies
    | PetroleumAndPetroleumProducts
    | PhotoDeveloping
    | PhotographicPhotocopyMicrofilmEquipmentAndSupplies
    | PhotographicStudios
    | PictureVideoProduction
    | PieceGoodsNotionsAndOtherDryGoods
    | PlumbingHeatingEquipmentAndSupplies
    | PoliticalOrganizations
    | PostalServicesGovernmentOnly
    | PreciousStonesAndMetalsWatchesAndJewelry
    | ProfessionalServices
    | PublicWarehousingAndStorage
    | QuickCopyReproAndBlueprint
    | Railroads
    | RealEstateAgentsAndManagersRentals
    | RecordStores
    | RecreationalVehicleRentals
    | ReligiousGoodsStores
    | ReligiousOrganizations
    | RoofingSidingSheetMetal
    | SecretarialSupportServices
    | SecurityBrokersDealers
    | ServiceStations
    | SewingNeedleworkFabricAndPieceGoodsStores
    | ShoeRepairHatCleaning
    | ShoeStores
    | SmallApplianceRepair
    | SnowmobileDealers
    | SpecialTradeServices
    | SpecialtyCleaning
    | SportingGoodsStores
    | SportingRecreationCamps
    | SportsAndRidingApparelStores
    | SportsClubsFields
    | StampAndCoinStores
    | StationaryOfficeSuppliesPrintingAndWritingPaper
    | StationeryStoresOfficeAndSchoolSupplyStores
    | SwimmingPoolsSales
    | TUiTravelGermany
    | TailorsAlterations
    | TaxPaymentsGovernmentAgencies
    | TaxPreparationServices
    | TaxicabsLimousines
    | TelecommunicationEquipmentAndTelephoneSales
    | TelecommunicationServices
    | TelegraphServices
    | TentAndAwningShops
    | TestingLaboratories
    | TheatricalTicketAgencies
    | Timeshares
    | TireRetreadingAndRepair
    | TollsBridgeFees
    | TouristAttractionsAndExhibits
    | TowingServices
    | TrailerParksCampgrounds
    | TransportationServices
    | TravelAgenciesTourOperators
    | TruckStopIteration
    | TruckUtilityTrailerRentals
    | TypesettingPlateMakingAndRelatedServices
    | TypewriterStores
    | USFederalGovernmentAgenciesOrDepartments
    | UniformsCommercialClothing
    | UsedMerchandiseAndSecondhandStores
    | Utilities
    | VarietyStores
    | VeterinaryServices
    | VideoAmusementGameSupplies
    | VideoGameArcades
    | VideoTapeRentalStores
    | VocationalTradeSchools
    | WatchJewelryRepair
    | WeldingRepair
    | WholesaleClubs
    | WigAndToupeeStores
    | WiresMoneyOrders
    | WomensAccessoryAndSpecialtyShops
    | WomensReadyToWearStores
    | WreckingAndSalvageYards

    type CreateUnlinkedRefund'MerchantData = {
        ///<summary>A categorization of the seller's type of business. See our [merchant categories guide](https://docs.stripe.com/issuing/merchant-categories) for a list of possible values.</summary>
        [<Config.Form>]Category: CreateUnlinkedRefund'MerchantDataCategory option
        ///<summary>City where the seller is located</summary>
        [<Config.Form>]City: string option
        ///<summary>Country where the seller is located</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Name of the seller</summary>
        [<Config.Form>]Name: string option
        ///<summary>Identifier assigned to the seller by the card network. Different card networks may assign different network_id fields to the same merchant.</summary>
        [<Config.Form>]NetworkId: string option
        ///<summary>Postal code where the seller is located</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State where the seller is located</summary>
        [<Config.Form>]State: string option
        ///<summary>An ID assigned by the seller to the location of the sale.</summary>
        [<Config.Form>]TerminalId: string option
        ///<summary>URL provided by the merchant on a 3DS request</summary>
        [<Config.Form>]Url: string option
    }
    with
        static member New(?category: CreateUnlinkedRefund'MerchantDataCategory, ?city: string, ?country: IsoTypes.IsoCountryCode, ?name: string, ?networkId: string, ?postalCode: string, ?state: string, ?terminalId: string, ?url: string) =
            {
                Category = category
                City = city
                Country = country
                Name = name
                NetworkId = networkId
                PostalCode = postalCode
                State = state
                TerminalId = terminalId
                Url = url
            }

    type CreateUnlinkedRefund'PurchaseDetailsFleetCardholderPromptData = {
        ///<summary>Driver ID.</summary>
        [<Config.Form>]DriverId: string option
        ///<summary>Odometer reading.</summary>
        [<Config.Form>]Odometer: int option
        ///<summary>An alphanumeric ID. This field is used when a vehicle ID, driver ID, or generic ID is entered by the cardholder, but the merchant or card network did not specify the prompt type.</summary>
        [<Config.Form>]UnspecifiedId: string option
        ///<summary>User ID.</summary>
        [<Config.Form>]UserId: string option
        ///<summary>Vehicle number.</summary>
        [<Config.Form>]VehicleNumber: string option
    }
    with
        static member New(?driverId: string, ?odometer: int, ?unspecifiedId: string, ?userId: string, ?vehicleNumber: string) =
            {
                DriverId = driverId
                Odometer = odometer
                UnspecifiedId = unspecifiedId
                UserId = userId
                VehicleNumber = vehicleNumber
            }

    type CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdownFuel = {
        ///<summary>Gross fuel amount that should equal Fuel Volume multipled by Fuel Unit Cost, inclusive of taxes.</summary>
        [<Config.Form>]GrossAmountDecimal: string option
    }
    with
        static member New(?grossAmountDecimal: string) =
            {
                GrossAmountDecimal = grossAmountDecimal
            }

    type CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdownNonFuel = {
        ///<summary>Gross non-fuel amount that should equal the sum of the line items, inclusive of taxes.</summary>
        [<Config.Form>]GrossAmountDecimal: string option
    }
    with
        static member New(?grossAmountDecimal: string) =
            {
                GrossAmountDecimal = grossAmountDecimal
            }

    type CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdownTax = {
        ///<summary>Amount of state or provincial Sales Tax included in the transaction amount. Null if not reported by merchant or not subject to tax.</summary>
        [<Config.Form>]LocalAmountDecimal: string option
        ///<summary>Amount of national Sales Tax or VAT included in the transaction amount. Null if not reported by merchant or not subject to tax.</summary>
        [<Config.Form>]NationalAmountDecimal: string option
    }
    with
        static member New(?localAmountDecimal: string, ?nationalAmountDecimal: string) =
            {
                LocalAmountDecimal = localAmountDecimal
                NationalAmountDecimal = nationalAmountDecimal
            }

    type CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdown = {
        ///<summary>Breakdown of fuel portion of the purchase.</summary>
        [<Config.Form>]Fuel: CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdownFuel option
        ///<summary>Breakdown of non-fuel portion of the purchase.</summary>
        [<Config.Form>]NonFuel: CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdownNonFuel option
        ///<summary>Information about tax included in this transaction.</summary>
        [<Config.Form>]Tax: CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdownTax option
    }
    with
        static member New(?fuel: CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdownFuel, ?nonFuel: CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdownNonFuel, ?tax: CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdownTax) =
            {
                Fuel = fuel
                NonFuel = nonFuel
                Tax = tax
            }

    type CreateUnlinkedRefund'PurchaseDetailsFleetPurchaseType =
    | FuelAndNonFuelPurchase
    | FuelPurchase
    | NonFuelPurchase

    type CreateUnlinkedRefund'PurchaseDetailsFleetServiceType =
    | FullService
    | NonFuelTransaction
    | SelfService

    type CreateUnlinkedRefund'PurchaseDetailsFleet = {
        ///<summary>Answers to prompts presented to the cardholder at the point of sale. Prompted fields vary depending on the configuration of your physical fleet cards. Typical points of sale support only numeric entry.</summary>
        [<Config.Form>]CardholderPromptData: CreateUnlinkedRefund'PurchaseDetailsFleetCardholderPromptData option
        ///<summary>The type of purchase. One of `fuel_purchase`, `non_fuel_purchase`, or `fuel_and_non_fuel_purchase`.</summary>
        [<Config.Form>]PurchaseType: CreateUnlinkedRefund'PurchaseDetailsFleetPurchaseType option
        ///<summary>More information about the total amount. This information is not guaranteed to be accurate as some merchants may provide unreliable data.</summary>
        [<Config.Form>]ReportedBreakdown: CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdown option
        ///<summary>The type of fuel service. One of `non_fuel_transaction`, `full_service`, or `self_service`.</summary>
        [<Config.Form>]ServiceType: CreateUnlinkedRefund'PurchaseDetailsFleetServiceType option
    }
    with
        static member New(?cardholderPromptData: CreateUnlinkedRefund'PurchaseDetailsFleetCardholderPromptData, ?purchaseType: CreateUnlinkedRefund'PurchaseDetailsFleetPurchaseType, ?reportedBreakdown: CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdown, ?serviceType: CreateUnlinkedRefund'PurchaseDetailsFleetServiceType) =
            {
                CardholderPromptData = cardholderPromptData
                PurchaseType = purchaseType
                ReportedBreakdown = reportedBreakdown
                ServiceType = serviceType
            }

    type CreateUnlinkedRefund'PurchaseDetailsFlightSegments = {
        ///<summary>The three-letter IATA airport code of the flight's destination.</summary>
        [<Config.Form>]ArrivalAirportCode: string option
        ///<summary>The airline carrier code.</summary>
        [<Config.Form>]Carrier: string option
        ///<summary>The three-letter IATA airport code that the flight departed from.</summary>
        [<Config.Form>]DepartureAirportCode: string option
        ///<summary>The flight number.</summary>
        [<Config.Form>]FlightNumber: string option
        ///<summary>The flight's service class.</summary>
        [<Config.Form>]ServiceClass: string option
        ///<summary>Whether a stopover is allowed on this flight.</summary>
        [<Config.Form>]StopoverAllowed: bool option
    }
    with
        static member New(?arrivalAirportCode: string, ?carrier: string, ?departureAirportCode: string, ?flightNumber: string, ?serviceClass: string, ?stopoverAllowed: bool) =
            {
                ArrivalAirportCode = arrivalAirportCode
                Carrier = carrier
                DepartureAirportCode = departureAirportCode
                FlightNumber = flightNumber
                ServiceClass = serviceClass
                StopoverAllowed = stopoverAllowed
            }

    type CreateUnlinkedRefund'PurchaseDetailsFlight = {
        ///<summary>The time that the flight departed.</summary>
        [<Config.Form>]DepartureAt: DateTime option
        ///<summary>The name of the passenger.</summary>
        [<Config.Form>]PassengerName: string option
        ///<summary>Whether the ticket is refundable.</summary>
        [<Config.Form>]Refundable: bool option
        ///<summary>The legs of the trip.</summary>
        [<Config.Form>]Segments: CreateUnlinkedRefund'PurchaseDetailsFlightSegments list option
        ///<summary>The travel agency that issued the ticket.</summary>
        [<Config.Form>]TravelAgency: string option
    }
    with
        static member New(?departureAt: DateTime, ?passengerName: string, ?refundable: bool, ?segments: CreateUnlinkedRefund'PurchaseDetailsFlightSegments list, ?travelAgency: string) =
            {
                DepartureAt = departureAt
                PassengerName = passengerName
                Refundable = refundable
                Segments = segments
                TravelAgency = travelAgency
            }

    type CreateUnlinkedRefund'PurchaseDetailsFuelType =
    | Diesel
    | Other
    | UnleadedPlus
    | UnleadedRegular
    | UnleadedSuper

    type CreateUnlinkedRefund'PurchaseDetailsFuelUnit =
    | ChargingMinute
    | ImperialGallon
    | Kilogram
    | KilowattHour
    | Liter
    | Other
    | Pound
    | UsGallon

    type CreateUnlinkedRefund'PurchaseDetailsFuel = {
        ///<summary>[Conexxus Payment System Product Code](https://www.conexxus.org/conexxus-payment-system-product-codes) identifying the primary fuel product purchased.</summary>
        [<Config.Form>]IndustryProductCode: string option
        ///<summary>The quantity of `unit`s of fuel that was dispensed, represented as a decimal string with at most 12 decimal places.</summary>
        [<Config.Form>]QuantityDecimal: string option
        ///<summary>The type of fuel that was purchased. One of `diesel`, `unleaded_plus`, `unleaded_regular`, `unleaded_super`, or `other`.</summary>
        [<Config.Form>]Type: CreateUnlinkedRefund'PurchaseDetailsFuelType option
        ///<summary>The units for `quantity_decimal`. One of `charging_minute`, `imperial_gallon`, `kilogram`, `kilowatt_hour`, `liter`, `pound`, `us_gallon`, or `other`.</summary>
        [<Config.Form>]Unit: CreateUnlinkedRefund'PurchaseDetailsFuelUnit option
        ///<summary>The cost in cents per each unit of fuel, represented as a decimal string with at most 12 decimal places.</summary>
        [<Config.Form>]UnitCostDecimal: string option
    }
    with
        static member New(?industryProductCode: string, ?quantityDecimal: string, ?type': CreateUnlinkedRefund'PurchaseDetailsFuelType, ?unit: CreateUnlinkedRefund'PurchaseDetailsFuelUnit, ?unitCostDecimal: string) =
            {
                IndustryProductCode = industryProductCode
                QuantityDecimal = quantityDecimal
                Type = type'
                Unit = unit
                UnitCostDecimal = unitCostDecimal
            }

    type CreateUnlinkedRefund'PurchaseDetailsLodging = {
        ///<summary>The time of checking into the lodging.</summary>
        [<Config.Form>]CheckInAt: DateTime option
        ///<summary>The number of nights stayed at the lodging.</summary>
        [<Config.Form>]Nights: int option
    }
    with
        static member New(?checkInAt: DateTime, ?nights: int) =
            {
                CheckInAt = checkInAt
                Nights = nights
            }

    type CreateUnlinkedRefund'PurchaseDetailsReceipt = {
        [<Config.Form>]Description: string option
        [<Config.Form>]Quantity: string option
        [<Config.Form>]Total: int option
        [<Config.Form>]UnitCost: int option
    }
    with
        static member New(?description: string, ?quantity: string, ?total: int, ?unitCost: int) =
            {
                Description = description
                Quantity = quantity
                Total = total
                UnitCost = unitCost
            }

    type CreateUnlinkedRefund'PurchaseDetails = {
        ///<summary>Fleet-specific information for transactions using Fleet cards.</summary>
        [<Config.Form>]Fleet: CreateUnlinkedRefund'PurchaseDetailsFleet option
        ///<summary>Information about the flight that was purchased with this transaction.</summary>
        [<Config.Form>]Flight: CreateUnlinkedRefund'PurchaseDetailsFlight option
        ///<summary>Information about fuel that was purchased with this transaction.</summary>
        [<Config.Form>]Fuel: CreateUnlinkedRefund'PurchaseDetailsFuel option
        ///<summary>Information about lodging that was purchased with this transaction.</summary>
        [<Config.Form>]Lodging: CreateUnlinkedRefund'PurchaseDetailsLodging option
        ///<summary>The line items in the purchase.</summary>
        [<Config.Form>]Receipt: CreateUnlinkedRefund'PurchaseDetailsReceipt list option
        ///<summary>A merchant-specific order number.</summary>
        [<Config.Form>]Reference: string option
    }
    with
        static member New(?fleet: CreateUnlinkedRefund'PurchaseDetailsFleet, ?flight: CreateUnlinkedRefund'PurchaseDetailsFlight, ?fuel: CreateUnlinkedRefund'PurchaseDetailsFuel, ?lodging: CreateUnlinkedRefund'PurchaseDetailsLodging, ?receipt: CreateUnlinkedRefund'PurchaseDetailsReceipt list, ?reference: string) =
            {
                Fleet = fleet
                Flight = flight
                Fuel = fuel
                Lodging = lodging
                Receipt = receipt
                Reference = reference
            }

    type CreateUnlinkedRefundOptions = {
        ///<summary>The total amount to attempt to refund. This amount is in the provided currency, or defaults to the cards currency, and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).</summary>
        [<Config.Form>]Amount: int
        ///<summary>Card associated with this unlinked refund transaction.</summary>
        [<Config.Form>]Card: string
        ///<summary>The currency of the unlinked refund. If not provided, defaults to the currency of the card. Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Details about the seller (grocery store, e-commerce website, etc.) where the card authorization happened.</summary>
        [<Config.Form>]MerchantData: CreateUnlinkedRefund'MerchantData option
        ///<summary>Additional purchase information that is optionally provided by the merchant.</summary>
        [<Config.Form>]PurchaseDetails: CreateUnlinkedRefund'PurchaseDetails option
    }
    with
        static member New(amount: int, card: string, ?currency: IsoTypes.IsoCurrencyCode, ?expand: string list, ?merchantData: CreateUnlinkedRefund'MerchantData, ?purchaseDetails: CreateUnlinkedRefund'PurchaseDetails) =
            {
                Amount = amount
                Card = card
                Currency = currency
                Expand = expand
                MerchantData = merchantData
                PurchaseDetails = purchaseDetails
            }

    ///<summary><p>Allows the user to refund an arbitrary amount, also known as a unlinked refund.</p></summary>
    let CreateUnlinkedRefund settings (options: CreateUnlinkedRefundOptions) =
        $"/v1/test_helpers/issuing/transactions/create_unlinked_refund"
        |> RestApi.postAsync<_, IssuingTransaction> settings (Map.empty) options

module TestHelpersIssuingTransactionsRefund =

    type RefundOptions = {
        [<Config.Path>]Transaction: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The total amount to attempt to refund. This amount is in the provided currency, or defaults to the cards currency, and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).</summary>
        [<Config.Form>]RefundAmount: int option
    }
    with
        static member New(transaction: string, ?expand: string list, ?refundAmount: int) =
            {
                Transaction = transaction
                Expand = expand
                RefundAmount = refundAmount
            }

    ///<summary><p>Refund a test-mode Transaction.</p></summary>
    let Refund settings (options: RefundOptions) =
        $"/v1/test_helpers/issuing/transactions/{options.Transaction}/refund"
        |> RestApi.postAsync<_, IssuingTransaction> settings (Map.empty) options

module TestHelpersRefundsExpire =

    type ExpireOptions = {
        [<Config.Path>]Refund: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(refund: string, ?expand: string list) =
            {
                Refund = refund
                Expand = expand
            }

    ///<summary><p>Expire a refund with a status of <code>requires_action</code>.</p></summary>
    let Expire settings (options: ExpireOptions) =
        $"/v1/test_helpers/refunds/{options.Refund}/expire"
        |> RestApi.postAsync<_, Refund> settings (Map.empty) options

module TestHelpersTerminalReadersPresentPaymentMethod =

    type PresentPaymentMethod'Card = {
        ///<summary>Card security code.</summary>
        [<Config.Form>]Cvc: string option
        ///<summary>Two-digit number representing the card's expiration month.</summary>
        [<Config.Form>]ExpMonth: int option
        ///<summary>Two- or four-digit number representing the card's expiration year.</summary>
        [<Config.Form>]ExpYear: int option
        ///<summary>The card number, as a string without any separators.</summary>
        [<Config.Form>]Number: string option
    }
    with
        static member New(?cvc: string, ?expMonth: int, ?expYear: int, ?number: string) =
            {
                Cvc = cvc
                ExpMonth = expMonth
                ExpYear = expYear
                Number = number
            }

    type PresentPaymentMethod'CardPresent = {
        ///<summary>The card number, as a string without any separators.</summary>
        [<Config.Form>]Number: string option
    }
    with
        static member New(?number: string) =
            {
                Number = number
            }

    type PresentPaymentMethod'InteracPresent = {
        ///<summary>The Interac card number.</summary>
        [<Config.Form>]Number: string option
    }
    with
        static member New(?number: string) =
            {
                Number = number
            }

    type PresentPaymentMethod'Type =
    | Card
    | CardPresent
    | InteracPresent

    type PresentPaymentMethodOptions = {
        [<Config.Path>]Reader: string
        ///<summary>Simulated on-reader tip amount.</summary>
        [<Config.Form>]AmountTip: int option
        ///<summary>Simulated data for the card payment method.</summary>
        [<Config.Form>]Card: PresentPaymentMethod'Card option
        ///<summary>Simulated data for the card_present payment method.</summary>
        [<Config.Form>]CardPresent: PresentPaymentMethod'CardPresent option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Simulated data for the interac_present payment method.</summary>
        [<Config.Form>]InteracPresent: PresentPaymentMethod'InteracPresent option
        ///<summary>Simulated payment type.</summary>
        [<Config.Form>]Type: PresentPaymentMethod'Type option
    }
    with
        static member New(reader: string, ?amountTip: int, ?card: PresentPaymentMethod'Card, ?cardPresent: PresentPaymentMethod'CardPresent, ?expand: string list, ?interacPresent: PresentPaymentMethod'InteracPresent, ?type': PresentPaymentMethod'Type) =
            {
                Reader = reader
                AmountTip = amountTip
                Card = card
                CardPresent = cardPresent
                Expand = expand
                InteracPresent = interacPresent
                Type = type'
            }

    ///<summary><p>Presents a payment method on a simulated reader. Can be used to simulate accepting a payment, saving a card or refunding a transaction.</p></summary>
    let PresentPaymentMethod settings (options: PresentPaymentMethodOptions) =
        $"/v1/test_helpers/terminal/readers/{options.Reader}/present_payment_method"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TestHelpersTerminalReadersSucceedInputCollection =

    type SucceedInputCollection'SkipNonRequiredInputs =
    | All
    | None'

    type SucceedInputCollectionOptions = {
        [<Config.Path>]Reader: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>This parameter defines the skip behavior for input collection.</summary>
        [<Config.Form>]SkipNonRequiredInputs: SucceedInputCollection'SkipNonRequiredInputs option
    }
    with
        static member New(reader: string, ?expand: string list, ?skipNonRequiredInputs: SucceedInputCollection'SkipNonRequiredInputs) =
            {
                Reader = reader
                Expand = expand
                SkipNonRequiredInputs = skipNonRequiredInputs
            }

    ///<summary><p>Use this endpoint to trigger a successful input collection on a simulated reader.</p></summary>
    let SucceedInputCollection settings (options: SucceedInputCollectionOptions) =
        $"/v1/test_helpers/terminal/readers/{options.Reader}/succeed_input_collection"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TestHelpersTerminalReadersTimeoutInputCollection =

    type TimeoutInputCollectionOptions = {
        [<Config.Path>]Reader: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(reader: string, ?expand: string list) =
            {
                Reader = reader
                Expand = expand
            }

    ///<summary><p>Use this endpoint to complete an input collection with a timeout error on a simulated reader.</p></summary>
    let TimeoutInputCollection settings (options: TimeoutInputCollectionOptions) =
        $"/v1/test_helpers/terminal/readers/{options.Reader}/timeout_input_collection"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TestHelpersTestClocks =

    type ListOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<summary><p>Returns a list of your test clocks.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/test_helpers/test_clocks"
        |> RestApi.getAsync<StripeList<TestHelpersTestClock>> settings qs

    type CreateOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The initial frozen time for this test clock.</summary>
        [<Config.Form>]FrozenTime: DateTime
        ///<summary>The name for this test clock.</summary>
        [<Config.Form>]Name: string option
    }
    with
        static member New(frozenTime: DateTime, ?expand: string list, ?name: string) =
            {
                Expand = expand
                FrozenTime = frozenTime
                Name = name
            }

    ///<summary><p>Creates a new test clock that can be attached to new customers and quotes.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/test_helpers/test_clocks"
        |> RestApi.postAsync<_, TestHelpersTestClock> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]TestClock: string
    }
    with
        static member New(testClock: string) =
            {
                TestClock = testClock
            }

    ///<summary><p>Deletes a test clock.</p></summary>
    let Delete settings (options: DeleteOptions) =
        $"/v1/test_helpers/test_clocks/{options.TestClock}"
        |> RestApi.deleteAsync<DeletedTestHelpersTestClock> settings (Map.empty)

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]TestClock: string
    }
    with
        static member New(testClock: string, ?expand: string list) =
            {
                Expand = expand
                TestClock = testClock
            }

    ///<summary><p>Retrieves a test clock.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/test_helpers/test_clocks/{options.TestClock}"
        |> RestApi.getAsync<TestHelpersTestClock> settings qs

module TestHelpersTestClocksAdvance =

    type AdvanceOptions = {
        [<Config.Path>]TestClock: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The time to advance the test clock. Must be after the test clock's current frozen time. Cannot be more than two intervals in the future from the shortest subscription in this test clock. If there are no subscriptions in this test clock, it cannot be more than two years in the future.</summary>
        [<Config.Form>]FrozenTime: DateTime
    }
    with
        static member New(testClock: string, frozenTime: DateTime, ?expand: string list) =
            {
                TestClock = testClock
                Expand = expand
                FrozenTime = frozenTime
            }

    ///<summary><p>Starts advancing a test clock to a specified time in the future. Advancement is done when status changes to <code>Ready</code>.</p></summary>
    let Advance settings (options: AdvanceOptions) =
        $"/v1/test_helpers/test_clocks/{options.TestClock}/advance"
        |> RestApi.postAsync<_, TestHelpersTestClock> settings (Map.empty) options

module TestHelpersTreasuryInboundTransfersFail =

    type Fail'FailureDetailsCode =
    | AccountClosed
    | AccountFrozen
    | BankAccountRestricted
    | BankOwnershipChanged
    | DebitNotAuthorized
    | IncorrectAccountHolderAddress
    | IncorrectAccountHolderName
    | IncorrectAccountHolderTaxId
    | InsufficientFunds
    | InvalidAccountNumber
    | InvalidCurrency
    | NoAccount
    | Other

    type Fail'FailureDetails = {
        ///<summary>Reason for the failure.</summary>
        [<Config.Form>]Code: Fail'FailureDetailsCode option
    }
    with
        static member New(?code: Fail'FailureDetailsCode) =
            {
                Code = code
            }

    type FailOptions = {
        [<Config.Path>]Id: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Details about a failed InboundTransfer.</summary>
        [<Config.Form>]FailureDetails: Fail'FailureDetails option
    }
    with
        static member New(id: string, ?expand: string list, ?failureDetails: Fail'FailureDetails) =
            {
                Id = id
                Expand = expand
                FailureDetails = failureDetails
            }

    ///<summary><p>Transitions a test mode created InboundTransfer to the <code>failed</code> status. The InboundTransfer must already be in the <code>processing</code> state.</p></summary>
    let Fail settings (options: FailOptions) =
        $"/v1/test_helpers/treasury/inbound_transfers/{options.Id}/fail"
        |> RestApi.postAsync<_, TreasuryInboundTransfer> settings (Map.empty) options

module TestHelpersTreasuryInboundTransfersReturn =

    type ReturnInboundTransferOptions = {
        [<Config.Path>]Id: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    ///<summary><p>Marks the test mode InboundTransfer object as returned and links the InboundTransfer to a ReceivedDebit. The InboundTransfer must already be in the <code>succeeded</code> state.</p></summary>
    let ReturnInboundTransfer settings (options: ReturnInboundTransferOptions) =
        $"/v1/test_helpers/treasury/inbound_transfers/{options.Id}/return"
        |> RestApi.postAsync<_, TreasuryInboundTransfer> settings (Map.empty) options

module TestHelpersTreasuryInboundTransfersSucceed =

    type SucceedOptions = {
        [<Config.Path>]Id: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    ///<summary><p>Transitions a test mode created InboundTransfer to the <code>succeeded</code> status. The InboundTransfer must already be in the <code>processing</code> state.</p></summary>
    let Succeed settings (options: SucceedOptions) =
        $"/v1/test_helpers/treasury/inbound_transfers/{options.Id}/succeed"
        |> RestApi.postAsync<_, TreasuryInboundTransfer> settings (Map.empty) options

module TestHelpersTreasuryOutboundPayments =

    type Update'TrackingDetailsAch = {
        ///<summary>ACH trace ID for funds sent over the `ach` network.</summary>
        [<Config.Form>]TraceId: string option
    }
    with
        static member New(?traceId: string) =
            {
                TraceId = traceId
            }

    type Update'TrackingDetailsUsDomesticWire = {
        ///<summary>CHIPS System Sequence Number (SSN) for funds sent over the `us_domestic_wire` network.</summary>
        [<Config.Form>]Chips: string option
        ///<summary>IMAD for funds sent over the `us_domestic_wire` network.</summary>
        [<Config.Form>]Imad: string option
        ///<summary>OMAD for funds sent over the `us_domestic_wire` network.</summary>
        [<Config.Form>]Omad: string option
    }
    with
        static member New(?chips: string, ?imad: string, ?omad: string) =
            {
                Chips = chips
                Imad = imad
                Omad = omad
            }

    type Update'TrackingDetailsType =
    | Ach
    | UsDomesticWire

    type Update'TrackingDetails = {
        ///<summary>ACH network tracking details.</summary>
        [<Config.Form>]Ach: Update'TrackingDetailsAch option
        ///<summary>The US bank account network used to send funds.</summary>
        [<Config.Form>]Type: Update'TrackingDetailsType option
        ///<summary>US domestic wire network tracking details.</summary>
        [<Config.Form>]UsDomesticWire: Update'TrackingDetailsUsDomesticWire option
    }
    with
        static member New(?ach: Update'TrackingDetailsAch, ?type': Update'TrackingDetailsType, ?usDomesticWire: Update'TrackingDetailsUsDomesticWire) =
            {
                Ach = ach
                Type = type'
                UsDomesticWire = usDomesticWire
            }

    type UpdateOptions = {
        [<Config.Path>]Id: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Details about network-specific tracking information.</summary>
        [<Config.Form>]TrackingDetails: Update'TrackingDetails
    }
    with
        static member New(id: string, trackingDetails: Update'TrackingDetails, ?expand: string list) =
            {
                Id = id
                Expand = expand
                TrackingDetails = trackingDetails
            }

    ///<summary><p>Updates a test mode created OutboundPayment with tracking details. The OutboundPayment must not be cancelable, and cannot be in the <code>canceled</code> or <code>failed</code> states.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/test_helpers/treasury/outbound_payments/{options.Id}"
        |> RestApi.postAsync<_, TreasuryOutboundPayment> settings (Map.empty) options

module TestHelpersTreasuryOutboundPaymentsFail =

    type FailOptions = {
        [<Config.Path>]Id: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    ///<summary><p>Transitions a test mode created OutboundPayment to the <code>failed</code> status. The OutboundPayment must already be in the <code>processing</code> state.</p></summary>
    let Fail settings (options: FailOptions) =
        $"/v1/test_helpers/treasury/outbound_payments/{options.Id}/fail"
        |> RestApi.postAsync<_, TreasuryOutboundPayment> settings (Map.empty) options

module TestHelpersTreasuryOutboundPaymentsPost =

    type PostOptions = {
        [<Config.Path>]Id: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    ///<summary><p>Transitions a test mode created OutboundPayment to the <code>posted</code> status. The OutboundPayment must already be in the <code>processing</code> state.</p></summary>
    let Post settings (options: PostOptions) =
        $"/v1/test_helpers/treasury/outbound_payments/{options.Id}/post"
        |> RestApi.postAsync<_, TreasuryOutboundPayment> settings (Map.empty) options

module TestHelpersTreasuryOutboundPaymentsReturn =

    type ReturnOutboundPayment'ReturnedDetailsCode =
    | AccountClosed
    | AccountFrozen
    | BankAccountRestricted
    | BankOwnershipChanged
    | Declined
    | IncorrectAccountHolderName
    | InvalidAccountNumber
    | InvalidCurrency
    | NoAccount
    | Other

    type ReturnOutboundPayment'ReturnedDetails = {
        ///<summary>The return code to be set on the OutboundPayment object.</summary>
        [<Config.Form>]Code: ReturnOutboundPayment'ReturnedDetailsCode option
    }
    with
        static member New(?code: ReturnOutboundPayment'ReturnedDetailsCode) =
            {
                Code = code
            }

    type ReturnOutboundPaymentOptions = {
        [<Config.Path>]Id: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Optional hash to set the return code.</summary>
        [<Config.Form>]ReturnedDetails: ReturnOutboundPayment'ReturnedDetails option
    }
    with
        static member New(id: string, ?expand: string list, ?returnedDetails: ReturnOutboundPayment'ReturnedDetails) =
            {
                Id = id
                Expand = expand
                ReturnedDetails = returnedDetails
            }

    ///<summary><p>Transitions a test mode created OutboundPayment to the <code>returned</code> status. The OutboundPayment must already be in the <code>processing</code> state.</p></summary>
    let ReturnOutboundPayment settings (options: ReturnOutboundPaymentOptions) =
        $"/v1/test_helpers/treasury/outbound_payments/{options.Id}/return"
        |> RestApi.postAsync<_, TreasuryOutboundPayment> settings (Map.empty) options

module TestHelpersTreasuryOutboundTransfers =

    type Update'TrackingDetailsAch = {
        ///<summary>ACH trace ID for funds sent over the `ach` network.</summary>
        [<Config.Form>]TraceId: string option
    }
    with
        static member New(?traceId: string) =
            {
                TraceId = traceId
            }

    type Update'TrackingDetailsUsDomesticWire = {
        ///<summary>CHIPS System Sequence Number (SSN) for funds sent over the `us_domestic_wire` network.</summary>
        [<Config.Form>]Chips: string option
        ///<summary>IMAD for funds sent over the `us_domestic_wire` network.</summary>
        [<Config.Form>]Imad: string option
        ///<summary>OMAD for funds sent over the `us_domestic_wire` network.</summary>
        [<Config.Form>]Omad: string option
    }
    with
        static member New(?chips: string, ?imad: string, ?omad: string) =
            {
                Chips = chips
                Imad = imad
                Omad = omad
            }

    type Update'TrackingDetailsType =
    | Ach
    | UsDomesticWire

    type Update'TrackingDetails = {
        ///<summary>ACH network tracking details.</summary>
        [<Config.Form>]Ach: Update'TrackingDetailsAch option
        ///<summary>The US bank account network used to send funds.</summary>
        [<Config.Form>]Type: Update'TrackingDetailsType option
        ///<summary>US domestic wire network tracking details.</summary>
        [<Config.Form>]UsDomesticWire: Update'TrackingDetailsUsDomesticWire option
    }
    with
        static member New(?ach: Update'TrackingDetailsAch, ?type': Update'TrackingDetailsType, ?usDomesticWire: Update'TrackingDetailsUsDomesticWire) =
            {
                Ach = ach
                Type = type'
                UsDomesticWire = usDomesticWire
            }

    type UpdateOptions = {
        [<Config.Path>]OutboundTransfer: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Details about network-specific tracking information.</summary>
        [<Config.Form>]TrackingDetails: Update'TrackingDetails
    }
    with
        static member New(outboundTransfer: string, trackingDetails: Update'TrackingDetails, ?expand: string list) =
            {
                OutboundTransfer = outboundTransfer
                Expand = expand
                TrackingDetails = trackingDetails
            }

    ///<summary><p>Updates a test mode created OutboundTransfer with tracking details. The OutboundTransfer must not be cancelable, and cannot be in the <code>canceled</code> or <code>failed</code> states.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/test_helpers/treasury/outbound_transfers/{options.OutboundTransfer}"
        |> RestApi.postAsync<_, TreasuryOutboundTransfer> settings (Map.empty) options

module TestHelpersTreasuryOutboundTransfersFail =

    type FailOptions = {
        [<Config.Path>]OutboundTransfer: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(outboundTransfer: string, ?expand: string list) =
            {
                OutboundTransfer = outboundTransfer
                Expand = expand
            }

    ///<summary><p>Transitions a test mode created OutboundTransfer to the <code>failed</code> status. The OutboundTransfer must already be in the <code>processing</code> state.</p></summary>
    let Fail settings (options: FailOptions) =
        $"/v1/test_helpers/treasury/outbound_transfers/{options.OutboundTransfer}/fail"
        |> RestApi.postAsync<_, TreasuryOutboundTransfer> settings (Map.empty) options

module TestHelpersTreasuryOutboundTransfersPost =

    type PostOptions = {
        [<Config.Path>]OutboundTransfer: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(outboundTransfer: string, ?expand: string list) =
            {
                OutboundTransfer = outboundTransfer
                Expand = expand
            }

    ///<summary><p>Transitions a test mode created OutboundTransfer to the <code>posted</code> status. The OutboundTransfer must already be in the <code>processing</code> state.</p></summary>
    let Post settings (options: PostOptions) =
        $"/v1/test_helpers/treasury/outbound_transfers/{options.OutboundTransfer}/post"
        |> RestApi.postAsync<_, TreasuryOutboundTransfer> settings (Map.empty) options

module TestHelpersTreasuryOutboundTransfersReturn =

    type ReturnOutboundTransfer'ReturnedDetailsCode =
    | AccountClosed
    | AccountFrozen
    | BankAccountRestricted
    | BankOwnershipChanged
    | Declined
    | IncorrectAccountHolderName
    | InvalidAccountNumber
    | InvalidCurrency
    | NoAccount
    | Other

    type ReturnOutboundTransfer'ReturnedDetails = {
        ///<summary>Reason for the return.</summary>
        [<Config.Form>]Code: ReturnOutboundTransfer'ReturnedDetailsCode option
    }
    with
        static member New(?code: ReturnOutboundTransfer'ReturnedDetailsCode) =
            {
                Code = code
            }

    type ReturnOutboundTransferOptions = {
        [<Config.Path>]OutboundTransfer: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Details about a returned OutboundTransfer.</summary>
        [<Config.Form>]ReturnedDetails: ReturnOutboundTransfer'ReturnedDetails option
    }
    with
        static member New(outboundTransfer: string, ?expand: string list, ?returnedDetails: ReturnOutboundTransfer'ReturnedDetails) =
            {
                OutboundTransfer = outboundTransfer
                Expand = expand
                ReturnedDetails = returnedDetails
            }

    ///<summary><p>Transitions a test mode created OutboundTransfer to the <code>returned</code> status. The OutboundTransfer must already be in the <code>processing</code> state.</p></summary>
    let ReturnOutboundTransfer settings (options: ReturnOutboundTransferOptions) =
        $"/v1/test_helpers/treasury/outbound_transfers/{options.OutboundTransfer}/return"
        |> RestApi.postAsync<_, TreasuryOutboundTransfer> settings (Map.empty) options

module TestHelpersTreasuryReceivedCredits =

    type Create'InitiatingPaymentMethodDetailsUsBankAccount = {
        ///<summary>The bank account holder's name.</summary>
        [<Config.Form>]AccountHolderName: string option
        ///<summary>The bank account number.</summary>
        [<Config.Form>]AccountNumber: string option
        ///<summary>The bank account's routing number.</summary>
        [<Config.Form>]RoutingNumber: string option
    }
    with
        static member New(?accountHolderName: string, ?accountNumber: string, ?routingNumber: string) =
            {
                AccountHolderName = accountHolderName
                AccountNumber = accountNumber
                RoutingNumber = routingNumber
            }

    type Create'InitiatingPaymentMethodDetailsType =
    | UsBankAccount

    type Create'InitiatingPaymentMethodDetails = {
        ///<summary>The source type.</summary>
        [<Config.Form>]Type: Create'InitiatingPaymentMethodDetailsType option
        ///<summary>Optional fields for `us_bank_account`.</summary>
        [<Config.Form>]UsBankAccount: Create'InitiatingPaymentMethodDetailsUsBankAccount option
    }
    with
        static member New(?type': Create'InitiatingPaymentMethodDetailsType, ?usBankAccount: Create'InitiatingPaymentMethodDetailsUsBankAccount) =
            {
                Type = type'
                UsBankAccount = usBankAccount
            }

    type Create'Network =
    | Ach
    | UsDomesticWire

    type CreateOptions = {
        ///<summary>Amount (in cents) to be transferred.</summary>
        [<Config.Form>]Amount: int
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode
        ///<summary>An arbitrary string attached to the object. Often useful for displaying to users.</summary>
        [<Config.Form>]Description: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The FinancialAccount to send funds to.</summary>
        [<Config.Form>]FinancialAccount: string
        ///<summary>Initiating payment method details for the object.</summary>
        [<Config.Form>]InitiatingPaymentMethodDetails: Create'InitiatingPaymentMethodDetails option
        ///<summary>Specifies the network rails to be used. If not set, will default to the PaymentMethod's preferred network. See the [docs](https://docs.stripe.com/treasury/money-movement/timelines) to learn more about money movement timelines for each network type.</summary>
        [<Config.Form>]Network: Create'Network
    }
    with
        static member New(amount: int, currency: IsoTypes.IsoCurrencyCode, financialAccount: string, network: Create'Network, ?description: string, ?expand: string list, ?initiatingPaymentMethodDetails: Create'InitiatingPaymentMethodDetails) =
            {
                Amount = amount
                Currency = currency
                Description = description
                Expand = expand
                FinancialAccount = financialAccount
                InitiatingPaymentMethodDetails = initiatingPaymentMethodDetails
                Network = network
            }

    ///<summary><p>Use this endpoint to simulate a test mode ReceivedCredit initiated by a third party. In live mode, you can’t directly create ReceivedCredits initiated by third parties.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/test_helpers/treasury/received_credits"
        |> RestApi.postAsync<_, TreasuryReceivedCredit> settings (Map.empty) options

module TestHelpersTreasuryReceivedDebits =

    type Create'InitiatingPaymentMethodDetailsUsBankAccount = {
        ///<summary>The bank account holder's name.</summary>
        [<Config.Form>]AccountHolderName: string option
        ///<summary>The bank account number.</summary>
        [<Config.Form>]AccountNumber: string option
        ///<summary>The bank account's routing number.</summary>
        [<Config.Form>]RoutingNumber: string option
    }
    with
        static member New(?accountHolderName: string, ?accountNumber: string, ?routingNumber: string) =
            {
                AccountHolderName = accountHolderName
                AccountNumber = accountNumber
                RoutingNumber = routingNumber
            }

    type Create'InitiatingPaymentMethodDetailsType =
    | UsBankAccount

    type Create'InitiatingPaymentMethodDetails = {
        ///<summary>The source type.</summary>
        [<Config.Form>]Type: Create'InitiatingPaymentMethodDetailsType option
        ///<summary>Optional fields for `us_bank_account`.</summary>
        [<Config.Form>]UsBankAccount: Create'InitiatingPaymentMethodDetailsUsBankAccount option
    }
    with
        static member New(?type': Create'InitiatingPaymentMethodDetailsType, ?usBankAccount: Create'InitiatingPaymentMethodDetailsUsBankAccount) =
            {
                Type = type'
                UsBankAccount = usBankAccount
            }

    type Create'Network =
    | Ach

    type CreateOptions = {
        ///<summary>Amount (in cents) to be transferred.</summary>
        [<Config.Form>]Amount: int
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode
        ///<summary>An arbitrary string attached to the object. Often useful for displaying to users.</summary>
        [<Config.Form>]Description: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The FinancialAccount to pull funds from.</summary>
        [<Config.Form>]FinancialAccount: string
        ///<summary>Initiating payment method details for the object.</summary>
        [<Config.Form>]InitiatingPaymentMethodDetails: Create'InitiatingPaymentMethodDetails option
        ///<summary>Specifies the network rails to be used. If not set, will default to the PaymentMethod's preferred network. See the [docs](https://docs.stripe.com/treasury/money-movement/timelines) to learn more about money movement timelines for each network type.</summary>
        [<Config.Form>]Network: Create'Network
    }
    with
        static member New(amount: int, currency: IsoTypes.IsoCurrencyCode, financialAccount: string, network: Create'Network, ?description: string, ?expand: string list, ?initiatingPaymentMethodDetails: Create'InitiatingPaymentMethodDetails) =
            {
                Amount = amount
                Currency = currency
                Description = description
                Expand = expand
                FinancialAccount = financialAccount
                InitiatingPaymentMethodDetails = initiatingPaymentMethodDetails
                Network = network
            }

    ///<summary><p>Use this endpoint to simulate a test mode ReceivedDebit initiated by a third party. In live mode, you can’t directly create ReceivedDebits initiated by third parties.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/test_helpers/treasury/received_debits"
        |> RestApi.postAsync<_, TreasuryReceivedDebit> settings (Map.empty) options
