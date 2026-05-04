namespace StripeRequest.TestHelpers

open FunStripe
open System.Text.Json.Serialization
open Stripe.ConfirmationToken
open Stripe.IssuingCard
open Stripe.IssuingPersonalizationDesign
open Stripe.PaymentMethod
open Stripe.Terminal
open Stripe.TestHelpers
open Stripe.Treasury
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
module TestHelpersConfirmationTokens =

    type Create'PaymentMethodDataAcssDebit =
        {
            /// Customer's bank account number.
            [<Config.Form>]
            AccountNumber: string option
            /// Institution number of the customer's bank.
            [<Config.Form>]
            InstitutionNumber: string option
            /// Transit number of the customer's bank.
            [<Config.Form>]
            TransitNumber: string option
        }

    type Create'PaymentMethodDataAcssDebit with
        static member New(?accountNumber: string, ?institutionNumber: string, ?transitNumber: string) =
            {
                AccountNumber = accountNumber
                InstitutionNumber = institutionNumber
                TransitNumber = transitNumber
            }

    type Create'PaymentMethodDataAllowRedisplay =
        | Always
        | Limited
        | Unspecified

    type Create'PaymentMethodDataAuBecsDebit =
        {
            /// The account number for the bank account.
            [<Config.Form>]
            AccountNumber: string option
            /// Bank-State-Branch number of the bank account.
            [<Config.Form>]
            BsbNumber: string option
        }

    type Create'PaymentMethodDataAuBecsDebit with
        static member New(?accountNumber: string, ?bsbNumber: string) =
            {
                AccountNumber = accountNumber
                BsbNumber = bsbNumber
            }

    type Create'PaymentMethodDataBacsDebit =
        {
            /// Account number of the bank account that the funds will be debited from.
            [<Config.Form>]
            AccountNumber: string option
            /// Sort code of the bank account. (e.g., `10-20-30`)
            [<Config.Form>]
            SortCode: string option
        }

    type Create'PaymentMethodDataBacsDebit with
        static member New(?accountNumber: string, ?sortCode: string) =
            {
                AccountNumber = accountNumber
                SortCode = sortCode
            }

    type Create'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress =
        {
            /// City, district, suburb, town, or village.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Address line 1, such as the street, PO Box, or company name.
            [<Config.Form>]
            Line1: string option
            /// Address line 2, such as the apartment, suite, unit, or building.
            [<Config.Form>]
            Line2: string option
            /// ZIP or postal code.
            [<Config.Form>]
            PostalCode: string option
            /// State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
            [<Config.Form>]
            State: string option
        }

    type Create'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'PaymentMethodDataBillingDetails =
        {
            /// Billing address.
            [<Config.Form>]
            Address: Choice<Create'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string> option
            /// Email address.
            [<Config.Form>]
            Email: Choice<string,string> option
            /// Full name.
            [<Config.Form>]
            Name: Choice<string,string> option
            /// Billing phone number (including extension).
            [<Config.Form>]
            Phone: Choice<string,string> option
            /// Taxpayer identification number. Used only for transactions between LATAM buyers and non-LATAM sellers.
            [<Config.Form>]
            TaxId: string option
        }

    type Create'PaymentMethodDataBillingDetails with
        static member New(?address: Choice<Create'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string>, ?email: Choice<string,string>, ?name: Choice<string,string>, ?phone: Choice<string,string>, ?taxId: string) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
                TaxId = taxId
            }

    type Create'PaymentMethodDataBoleto =
        {
            /// The tax ID of the customer (CPF for individual consumers or CNPJ for businesses consumers)
            [<Config.Form>]
            TaxId: string option
        }

    type Create'PaymentMethodDataBoleto with
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

    type Create'PaymentMethodDataEps =
        {
            /// The customer's bank.
            [<Config.Form>]
            Bank: Create'PaymentMethodDataEpsBank option
        }

    type Create'PaymentMethodDataEps with
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

    type Create'PaymentMethodDataFpx =
        {
            /// Account holder type for FPX transaction
            [<Config.Form>]
            AccountHolderType: Create'PaymentMethodDataFpxAccountHolderType option
            /// The customer's bank.
            [<Config.Form>]
            Bank: Create'PaymentMethodDataFpxBank option
        }

    type Create'PaymentMethodDataFpx with
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

    type Create'PaymentMethodDataIdeal =
        {
            /// The customer's bank. Only use this parameter for existing customers. Don't use it for new customers.
            [<Config.Form>]
            Bank: Create'PaymentMethodDataIdealBank option
        }

    type Create'PaymentMethodDataIdeal with
        static member New(?bank: Create'PaymentMethodDataIdealBank) =
            {
                Bank = bank
            }

    type Create'PaymentMethodDataKlarnaDob =
        {
            /// The day of birth, between 1 and 31.
            [<Config.Form>]
            Day: int option
            /// The month of birth, between 1 and 12.
            [<Config.Form>]
            Month: int option
            /// The four-digit year of birth.
            [<Config.Form>]
            Year: int option
        }

    type Create'PaymentMethodDataKlarnaDob with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Create'PaymentMethodDataKlarna =
        {
            /// Customer's date of birth
            [<Config.Form>]
            Dob: Create'PaymentMethodDataKlarnaDob option
        }

    type Create'PaymentMethodDataKlarna with
        static member New(?dob: Create'PaymentMethodDataKlarnaDob) =
            {
                Dob = dob
            }

    type Create'PaymentMethodDataNaverPayFunding =
        | Card
        | Points

    type Create'PaymentMethodDataNaverPay =
        {
            /// Whether to use Naver Pay points or a card to fund this transaction. If not provided, this defaults to `card`.
            [<Config.Form>]
            Funding: Create'PaymentMethodDataNaverPayFunding option
        }

    type Create'PaymentMethodDataNaverPay with
        static member New(?funding: Create'PaymentMethodDataNaverPayFunding) =
            {
                Funding = funding
            }

    type Create'PaymentMethodDataNzBankAccount =
        {
            /// The name on the bank account. Only required if the account holder name is different from the name of the authorized signatory collected in the PaymentMethod’s billing details.
            [<Config.Form>]
            AccountHolderName: string option
            /// The account number for the bank account.
            [<Config.Form>]
            AccountNumber: string option
            /// The numeric code for the bank account's bank.
            [<Config.Form>]
            BankCode: string option
            /// The numeric code for the bank account's bank branch.
            [<Config.Form>]
            BranchCode: string option
            [<Config.Form>]
            Reference: string option
            /// The suffix of the bank account number.
            [<Config.Form>]
            Suffix: string option
        }

    type Create'PaymentMethodDataNzBankAccount with
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

    type Create'PaymentMethodDataP24 =
        {
            /// The customer's bank.
            [<Config.Form>]
            Bank: Create'PaymentMethodDataP24Bank option
        }

    type Create'PaymentMethodDataP24 with
        static member New(?bank: Create'PaymentMethodDataP24Bank) =
            {
                Bank = bank
            }

    type Create'PaymentMethodDataPayto =
        {
            /// The account number for the bank account.
            [<Config.Form>]
            AccountNumber: string option
            /// Bank-State-Branch number of the bank account.
            [<Config.Form>]
            BsbNumber: string option
            /// The PayID alias for the bank account.
            [<Config.Form>]
            PayId: string option
        }

    type Create'PaymentMethodDataPayto with
        static member New(?accountNumber: string, ?bsbNumber: string, ?payId: string) =
            {
                AccountNumber = accountNumber
                BsbNumber = bsbNumber
                PayId = payId
            }

    type Create'PaymentMethodDataRadarOptions =
        {
            /// A [Radar Session](https://docs.stripe.com/radar/radar-session) is a snapshot of the browser metadata and device details that help Radar make more accurate predictions on your payments.
            [<Config.Form>]
            Session: string option
        }

    type Create'PaymentMethodDataRadarOptions with
        static member New(?session: string) =
            {
                Session = session
            }

    type Create'PaymentMethodDataSepaDebit =
        {
            /// IBAN of the bank account.
            [<Config.Form>]
            Iban: string option
        }

    type Create'PaymentMethodDataSepaDebit with
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

    type Create'PaymentMethodDataSofort =
        {
            /// Two-letter ISO code representing the country the bank account is located in.
            [<Config.Form>]
            Country: Create'PaymentMethodDataSofortCountry option
        }

    type Create'PaymentMethodDataSofort with
        static member New(?country: Create'PaymentMethodDataSofortCountry) =
            {
                Country = country
            }

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

    type Create'PaymentMethodDataUpiMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Create'PaymentMethodDataUpiMandateOptions =
        {
            /// Amount to be charged for future payments.
            [<Config.Form>]
            Amount: int option
            /// One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
            [<Config.Form>]
            AmountType: Create'PaymentMethodDataUpiMandateOptionsAmountType option
            /// A description of the mandate or subscription that is meant to be displayed to the customer.
            [<Config.Form>]
            Description: string option
            /// End date of the mandate or subscription.
            [<Config.Form>]
            EndDate: DateTime option
        }

    type Create'PaymentMethodDataUpiMandateOptions with
        static member New(?amount: int, ?amountType: Create'PaymentMethodDataUpiMandateOptionsAmountType, ?description: string, ?endDate: DateTime) =
            {
                Amount = amount
                AmountType = amountType
                Description = description
                EndDate = endDate
            }

    type Create'PaymentMethodDataUpi =
        {
            /// Configuration options for setting up an eMandate
            [<Config.Form>]
            MandateOptions: Create'PaymentMethodDataUpiMandateOptions option
        }

    type Create'PaymentMethodDataUpi with
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

    type Create'PaymentMethodDataUsBankAccount =
        {
            /// Account holder type: individual or company.
            [<Config.Form>]
            AccountHolderType: Create'PaymentMethodDataUsBankAccountAccountHolderType option
            /// Account number of the bank account.
            [<Config.Form>]
            AccountNumber: string option
            /// Account type: checkings or savings. Defaults to checking if omitted.
            [<Config.Form>]
            AccountType: Create'PaymentMethodDataUsBankAccountAccountType option
            /// The ID of a Financial Connections Account to use as a payment method.
            [<Config.Form>]
            FinancialConnectionsAccount: string option
            /// Routing number of the bank account.
            [<Config.Form>]
            RoutingNumber: string option
        }

    type Create'PaymentMethodDataUsBankAccount with
        static member New(?accountHolderType: Create'PaymentMethodDataUsBankAccountAccountHolderType, ?accountNumber: string, ?accountType: Create'PaymentMethodDataUsBankAccountAccountType, ?financialConnectionsAccount: string, ?routingNumber: string) =
            {
                AccountHolderType = accountHolderType
                AccountNumber = accountNumber
                AccountType = accountType
                FinancialConnectionsAccount = financialConnectionsAccount
                RoutingNumber = routingNumber
            }

    type Create'PaymentMethodData =
        {
            /// If this is an `acss_debit` PaymentMethod, this hash contains details about the ACSS Debit payment method.
            [<Config.Form>]
            AcssDebit: Create'PaymentMethodDataAcssDebit option
            /// If this is an `affirm` PaymentMethod, this hash contains details about the Affirm payment method.
            [<Config.Form>]
            Affirm: string option
            /// If this is an `AfterpayClearpay` PaymentMethod, this hash contains details about the AfterpayClearpay payment method.
            [<Config.Form>]
            AfterpayClearpay: string option
            /// If this is an `Alipay` PaymentMethod, this hash contains details about the Alipay payment method.
            [<Config.Form>]
            Alipay: string option
            /// This field indicates whether this payment method can be shown again to its customer in a checkout flow. Stripe products such as Checkout and Elements use this field to determine whether a payment method can be shown as a saved payment method in a checkout flow. The field defaults to `unspecified`.
            [<Config.Form>]
            AllowRedisplay: Create'PaymentMethodDataAllowRedisplay option
            /// If this is a Alma PaymentMethod, this hash contains details about the Alma payment method.
            [<Config.Form>]
            Alma: string option
            /// If this is a AmazonPay PaymentMethod, this hash contains details about the AmazonPay payment method.
            [<Config.Form>]
            AmazonPay: string option
            /// If this is an `au_becs_debit` PaymentMethod, this hash contains details about the bank account.
            [<Config.Form>]
            AuBecsDebit: Create'PaymentMethodDataAuBecsDebit option
            /// If this is a `bacs_debit` PaymentMethod, this hash contains details about the Bacs Direct Debit bank account.
            [<Config.Form>]
            BacsDebit: Create'PaymentMethodDataBacsDebit option
            /// If this is a `bancontact` PaymentMethod, this hash contains details about the Bancontact payment method.
            [<Config.Form>]
            Bancontact: string option
            /// If this is a `billie` PaymentMethod, this hash contains details about the Billie payment method.
            [<Config.Form>]
            Billie: string option
            /// Billing information associated with the PaymentMethod that may be used or required by particular types of payment methods.
            [<Config.Form>]
            BillingDetails: Create'PaymentMethodDataBillingDetails option
            /// If this is a `blik` PaymentMethod, this hash contains details about the BLIK payment method.
            [<Config.Form>]
            Blik: string option
            /// If this is a `boleto` PaymentMethod, this hash contains details about the Boleto payment method.
            [<Config.Form>]
            Boleto: Create'PaymentMethodDataBoleto option
            /// If this is a `cashapp` PaymentMethod, this hash contains details about the Cash App Pay payment method.
            [<Config.Form>]
            Cashapp: string option
            /// If this is a Crypto PaymentMethod, this hash contains details about the Crypto payment method.
            [<Config.Form>]
            Crypto: string option
            /// If this is a `customer_balance` PaymentMethod, this hash contains details about the CustomerBalance payment method.
            [<Config.Form>]
            CustomerBalance: string option
            /// If this is an `eps` PaymentMethod, this hash contains details about the EPS payment method.
            [<Config.Form>]
            Eps: Create'PaymentMethodDataEps option
            /// If this is an `fpx` PaymentMethod, this hash contains details about the FPX payment method.
            [<Config.Form>]
            Fpx: Create'PaymentMethodDataFpx option
            /// If this is a `giropay` PaymentMethod, this hash contains details about the Giropay payment method.
            [<Config.Form>]
            Giropay: string option
            /// If this is a `grabpay` PaymentMethod, this hash contains details about the GrabPay payment method.
            [<Config.Form>]
            Grabpay: string option
            /// If this is an `ideal` PaymentMethod, this hash contains details about the iDEAL payment method.
            [<Config.Form>]
            Ideal: Create'PaymentMethodDataIdeal option
            /// If this is an `interac_present` PaymentMethod, this hash contains details about the Interac Present payment method.
            [<Config.Form>]
            InteracPresent: string option
            /// If this is a `kakao_pay` PaymentMethod, this hash contains details about the Kakao Pay payment method.
            [<Config.Form>]
            KakaoPay: string option
            /// If this is a `klarna` PaymentMethod, this hash contains details about the Klarna payment method.
            [<Config.Form>]
            Klarna: Create'PaymentMethodDataKlarna option
            /// If this is a `konbini` PaymentMethod, this hash contains details about the Konbini payment method.
            [<Config.Form>]
            Konbini: string option
            /// If this is a `kr_card` PaymentMethod, this hash contains details about the Korean Card payment method.
            [<Config.Form>]
            KrCard: string option
            /// If this is an `Link` PaymentMethod, this hash contains details about the Link payment method.
            [<Config.Form>]
            Link: string option
            /// If this is a MB WAY PaymentMethod, this hash contains details about the MB WAY payment method.
            [<Config.Form>]
            MbWay: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// If this is a `mobilepay` PaymentMethod, this hash contains details about the MobilePay payment method.
            [<Config.Form>]
            Mobilepay: string option
            /// If this is a `multibanco` PaymentMethod, this hash contains details about the Multibanco payment method.
            [<Config.Form>]
            Multibanco: string option
            /// If this is a `naver_pay` PaymentMethod, this hash contains details about the Naver Pay payment method.
            [<Config.Form>]
            NaverPay: Create'PaymentMethodDataNaverPay option
            /// If this is an nz_bank_account PaymentMethod, this hash contains details about the nz_bank_account payment method.
            [<Config.Form>]
            NzBankAccount: Create'PaymentMethodDataNzBankAccount option
            /// If this is an `oxxo` PaymentMethod, this hash contains details about the OXXO payment method.
            [<Config.Form>]
            Oxxo: string option
            /// If this is a `p24` PaymentMethod, this hash contains details about the P24 payment method.
            [<Config.Form>]
            P24: Create'PaymentMethodDataP24 option
            /// If this is a `pay_by_bank` PaymentMethod, this hash contains details about the PayByBank payment method.
            [<Config.Form>]
            PayByBank: string option
            /// If this is a `payco` PaymentMethod, this hash contains details about the PAYCO payment method.
            [<Config.Form>]
            Payco: string option
            /// If this is a `paynow` PaymentMethod, this hash contains details about the PayNow payment method.
            [<Config.Form>]
            Paynow: string option
            /// If this is a `paypal` PaymentMethod, this hash contains details about the PayPal payment method.
            [<Config.Form>]
            Paypal: string option
            /// If this is a `payto` PaymentMethod, this hash contains details about the PayTo payment method.
            [<Config.Form>]
            Payto: Create'PaymentMethodDataPayto option
            /// If this is a `pix` PaymentMethod, this hash contains details about the Pix payment method.
            [<Config.Form>]
            Pix: string option
            /// If this is a `promptpay` PaymentMethod, this hash contains details about the PromptPay payment method.
            [<Config.Form>]
            Promptpay: string option
            /// Options to configure Radar. See [Radar Session](https://docs.stripe.com/radar/radar-session) for more information.
            [<Config.Form>]
            RadarOptions: Create'PaymentMethodDataRadarOptions option
            /// If this is a `revolut_pay` PaymentMethod, this hash contains details about the Revolut Pay payment method.
            [<Config.Form>]
            RevolutPay: string option
            /// If this is a `samsung_pay` PaymentMethod, this hash contains details about the SamsungPay payment method.
            [<Config.Form>]
            SamsungPay: string option
            /// If this is a `satispay` PaymentMethod, this hash contains details about the Satispay payment method.
            [<Config.Form>]
            Satispay: string option
            /// If this is a `sepa_debit` PaymentMethod, this hash contains details about the SEPA debit bank account.
            [<Config.Form>]
            SepaDebit: Create'PaymentMethodDataSepaDebit option
            /// If this is a `sofort` PaymentMethod, this hash contains details about the SOFORT payment method.
            [<Config.Form>]
            Sofort: Create'PaymentMethodDataSofort option
            /// If this is a Sunbit PaymentMethod, this hash contains details about the Sunbit payment method.
            [<Config.Form>]
            Sunbit: string option
            /// If this is a `swish` PaymentMethod, this hash contains details about the Swish payment method.
            [<Config.Form>]
            Swish: string option
            /// If this is a TWINT PaymentMethod, this hash contains details about the TWINT payment method.
            [<Config.Form>]
            Twint: string option
            /// The type of the PaymentMethod. An additional hash is included on the PaymentMethod with a name matching this value. It contains additional information specific to the PaymentMethod type.
            [<Config.Form>]
            Type: Create'PaymentMethodDataType option
            /// If this is a `upi` PaymentMethod, this hash contains details about the UPI payment method.
            [<Config.Form>]
            Upi: Create'PaymentMethodDataUpi option
            /// If this is an `us_bank_account` PaymentMethod, this hash contains details about the US bank account payment method.
            [<Config.Form>]
            UsBankAccount: Create'PaymentMethodDataUsBankAccount option
            /// If this is an `wechat_pay` PaymentMethod, this hash contains details about the wechat_pay payment method.
            [<Config.Form>]
            WechatPay: string option
            /// If this is a `zip` PaymentMethod, this hash contains details about the Zip payment method.
            [<Config.Form>]
            Zip: string option
        }

    type Create'PaymentMethodData with
        static member New(?acssDebit: Create'PaymentMethodDataAcssDebit, ?affirm: string, ?afterpayClearpay: string, ?alipay: string, ?allowRedisplay: Create'PaymentMethodDataAllowRedisplay, ?alma: string, ?amazonPay: string, ?auBecsDebit: Create'PaymentMethodDataAuBecsDebit, ?bacsDebit: Create'PaymentMethodDataBacsDebit, ?bancontact: string, ?billie: string, ?billingDetails: Create'PaymentMethodDataBillingDetails, ?blik: string, ?boleto: Create'PaymentMethodDataBoleto, ?cashapp: string, ?crypto: string, ?customerBalance: string, ?eps: Create'PaymentMethodDataEps, ?fpx: Create'PaymentMethodDataFpx, ?giropay: string, ?grabpay: string, ?ideal: Create'PaymentMethodDataIdeal, ?interacPresent: string, ?kakaoPay: string, ?klarna: Create'PaymentMethodDataKlarna, ?konbini: string, ?krCard: string, ?link: string, ?mbWay: string, ?metadata: Map<string, string>, ?mobilepay: string, ?multibanco: string, ?naverPay: Create'PaymentMethodDataNaverPay, ?nzBankAccount: Create'PaymentMethodDataNzBankAccount, ?oxxo: string, ?p24: Create'PaymentMethodDataP24, ?payByBank: string, ?payco: string, ?paynow: string, ?paypal: string, ?payto: Create'PaymentMethodDataPayto, ?pix: string, ?promptpay: string, ?radarOptions: Create'PaymentMethodDataRadarOptions, ?revolutPay: string, ?samsungPay: string, ?satispay: string, ?sepaDebit: Create'PaymentMethodDataSepaDebit, ?sofort: Create'PaymentMethodDataSofort, ?sunbit: string, ?swish: string, ?twint: string, ?type': Create'PaymentMethodDataType, ?upi: Create'PaymentMethodDataUpi, ?usBankAccount: Create'PaymentMethodDataUsBankAccount, ?wechatPay: string, ?zip: string) =
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

    type Create'PaymentMethodOptionsCardInstallmentsPlanInterval = | Month

    type Create'PaymentMethodOptionsCardInstallmentsPlanType =
        | Bonus
        | FixedCount
        | Revolving

    type Create'PaymentMethodOptionsCardInstallmentsPlan =
        {
            /// For `fixed_count` installment plans, this is required. It represents the number of installment payments your customer will make to their credit card.
            [<Config.Form>]
            Count: int option
            /// For `fixed_count` installment plans, this is required. It represents the interval between installment payments your customer will make to their credit card.
            /// One of `month`.
            [<Config.Form>]
            Interval: Create'PaymentMethodOptionsCardInstallmentsPlanInterval option
            /// Type of installment plan, one of `fixed_count`, `bonus`, or `revolving`.
            [<Config.Form>]
            Type: Create'PaymentMethodOptionsCardInstallmentsPlanType option
        }

    type Create'PaymentMethodOptionsCardInstallmentsPlan with
        static member New(?count: int, ?interval: Create'PaymentMethodOptionsCardInstallmentsPlanInterval, ?type': Create'PaymentMethodOptionsCardInstallmentsPlanType) =
            {
                Count = count
                Interval = interval
                Type = type'
            }

    type Create'PaymentMethodOptionsCardInstallments =
        {
            /// The selected installment plan to use for this payment attempt.
            /// This parameter can only be provided during confirmation.
            [<Config.Form>]
            Plan: Create'PaymentMethodOptionsCardInstallmentsPlan option
        }

    type Create'PaymentMethodOptionsCardInstallments with
        static member New(?plan: Create'PaymentMethodOptionsCardInstallmentsPlan) =
            {
                Plan = plan
            }

    type Create'PaymentMethodOptionsCard =
        {
            /// Installment configuration for payments confirmed using this ConfirmationToken.
            [<Config.Form>]
            Installments: Create'PaymentMethodOptionsCardInstallments option
        }

    type Create'PaymentMethodOptionsCard with
        static member New(?installments: Create'PaymentMethodOptionsCardInstallments) =
            {
                Installments = installments
            }

    type Create'PaymentMethodOptions =
        {
            /// Configuration for any card payments confirmed using this ConfirmationToken.
            [<Config.Form>]
            Card: Create'PaymentMethodOptionsCard option
        }

    type Create'PaymentMethodOptions with
        static member New(?card: Create'PaymentMethodOptionsCard) =
            {
                Card = card
            }

    type Create'SetupFutureUsage =
        | OffSession
        | OnSession

    type Create'ShippingAddress =
        {
            /// City, district, suburb, town, or village.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Address line 1, such as the street, PO Box, or company name.
            [<Config.Form>]
            Line1: string option
            /// Address line 2, such as the apartment, suite, unit, or building.
            [<Config.Form>]
            Line2: string option
            /// ZIP or postal code.
            [<Config.Form>]
            PostalCode: string option
            /// State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
            [<Config.Form>]
            State: string option
        }

    type Create'ShippingAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'Shipping =
        {
            /// Shipping address
            [<Config.Form>]
            Address: Create'ShippingAddress option
            /// Recipient name.
            [<Config.Form>]
            Name: string option
            /// Recipient phone (including extension)
            [<Config.Form>]
            Phone: Choice<string,string> option
        }

    type Create'Shipping with
        static member New(?address: Create'ShippingAddress, ?name: string, ?phone: Choice<string,string>) =
            {
                Address = address
                Name = name
                Phone = phone
            }

    type CreateOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// ID of an existing PaymentMethod.
            [<Config.Form>]
            PaymentMethod: string option
            /// If provided, this hash will be used to create a PaymentMethod.
            [<Config.Form>]
            PaymentMethodData: Create'PaymentMethodData option
            /// Payment-method-specific configuration for this ConfirmationToken.
            [<Config.Form>]
            PaymentMethodOptions: Create'PaymentMethodOptions option
            /// Return URL used to confirm the Intent.
            [<Config.Form>]
            ReturnUrl: string option
            /// Indicates that you intend to make future payments with this ConfirmationToken's payment method.
            /// The presence of this property will [attach the payment method](https://docs.stripe.com/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete.
            [<Config.Form>]
            SetupFutureUsage: Create'SetupFutureUsage option
            /// Shipping information for this ConfirmationToken.
            [<Config.Form>]
            Shipping: Create'Shipping option
        }

    type CreateOptions with
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

    ///<p>Creates a test mode Confirmation Token server side for your integration tests.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/test_helpers/confirmation_tokens"
        |> RestApi.postAsync<_, ConfirmationToken> settings (Map.empty) options

module TestHelpersCustomersFundCashBalance =

    type FundCashBalanceOptions =
        {
            [<Config.Path>]
            Customer: string
            /// Amount to be used for this test cash balance transaction. A positive integer representing how much to fund in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal) (e.g., 100 cents to fund $1.00 or 100 to fund ¥100, a zero-decimal currency).
            [<Config.Form>]
            Amount: int
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A description of the test funding. This simulates free-text references supplied by customers when making bank transfers to their cash balance. You can use this to test how Stripe's [reconciliation algorithm](https://docs.stripe.com/payments/customer-balance/reconciliation) applies to different user inputs.
            [<Config.Form>]
            Reference: string option
        }

    type FundCashBalanceOptions with
        static member New(amount: int, currency: IsoTypes.IsoCurrencyCode, customer: string, ?expand: string list, ?reference: string) =
            {
                Amount = amount
                Currency = currency
                Customer = customer
                Expand = expand
                Reference = reference
            }

    ///<p>Create an incoming testmode bank transfer</p>
    let FundCashBalance settings (options: FundCashBalanceOptions) =
        $"/v1/test_helpers/customers/{options.Customer}/fund_cash_balance"
        |> RestApi.postAsync<_, CustomerCashBalanceTransaction> settings (Map.empty) options

module TestHelpersIssuingAuthorizations =

    type Create'AmountDetails =
        {
            /// The ATM withdrawal fee.
            [<Config.Form>]
            AtmFee: int option
            /// The amount of cash requested by the cardholder.
            [<Config.Form>]
            CashbackAmount: int option
        }

    type Create'AmountDetails with
        static member New(?atmFee: int, ?cashbackAmount: int) =
            {
                AtmFee = atmFee
                CashbackAmount = cashbackAmount
            }

    type Create'AuthorizationMethod =
        | Chip
        | Contactless
        | KeyedIn
        | Online
        | Swipe

    type Create'FleetCardholderPromptData =
        {
            /// Driver ID.
            [<Config.Form>]
            DriverId: string option
            /// Odometer reading.
            [<Config.Form>]
            Odometer: int option
            /// An alphanumeric ID. This field is used when a vehicle ID, driver ID, or generic ID is entered by the cardholder, but the merchant or card network did not specify the prompt type.
            [<Config.Form>]
            UnspecifiedId: string option
            /// User ID.
            [<Config.Form>]
            UserId: string option
            /// Vehicle number.
            [<Config.Form>]
            VehicleNumber: string option
        }

    type Create'FleetCardholderPromptData with
        static member New(?driverId: string, ?odometer: int, ?unspecifiedId: string, ?userId: string, ?vehicleNumber: string) =
            {
                DriverId = driverId
                Odometer = odometer
                UnspecifiedId = unspecifiedId
                UserId = userId
                VehicleNumber = vehicleNumber
            }

    type Create'FleetPurchaseType =
        | FuelAndNonFuelPurchase
        | FuelPurchase
        | NonFuelPurchase

    type Create'FleetReportedBreakdownFuel =
        {
            /// Gross fuel amount that should equal Fuel Volume multipled by Fuel Unit Cost, inclusive of taxes.
            [<Config.Form>]
            GrossAmountDecimal: string option
        }

    type Create'FleetReportedBreakdownFuel with
        static member New(?grossAmountDecimal: string) =
            {
                GrossAmountDecimal = grossAmountDecimal
            }

    type Create'FleetReportedBreakdownNonFuel =
        {
            /// Gross non-fuel amount that should equal the sum of the line items, inclusive of taxes.
            [<Config.Form>]
            GrossAmountDecimal: string option
        }

    type Create'FleetReportedBreakdownNonFuel with
        static member New(?grossAmountDecimal: string) =
            {
                GrossAmountDecimal = grossAmountDecimal
            }

    type Create'FleetReportedBreakdownTax =
        {
            /// Amount of state or provincial Sales Tax included in the transaction amount. Null if not reported by merchant or not subject to tax.
            [<Config.Form>]
            LocalAmountDecimal: string option
            /// Amount of national Sales Tax or VAT included in the transaction amount. Null if not reported by merchant or not subject to tax.
            [<Config.Form>]
            NationalAmountDecimal: string option
        }

    type Create'FleetReportedBreakdownTax with
        static member New(?localAmountDecimal: string, ?nationalAmountDecimal: string) =
            {
                LocalAmountDecimal = localAmountDecimal
                NationalAmountDecimal = nationalAmountDecimal
            }

    type Create'FleetReportedBreakdown =
        {
            /// Breakdown of fuel portion of the purchase.
            [<Config.Form>]
            Fuel: Create'FleetReportedBreakdownFuel option
            /// Breakdown of non-fuel portion of the purchase.
            [<Config.Form>]
            NonFuel: Create'FleetReportedBreakdownNonFuel option
            /// Information about tax included in this transaction.
            [<Config.Form>]
            Tax: Create'FleetReportedBreakdownTax option
        }

    type Create'FleetReportedBreakdown with
        static member New(?fuel: Create'FleetReportedBreakdownFuel, ?nonFuel: Create'FleetReportedBreakdownNonFuel, ?tax: Create'FleetReportedBreakdownTax) =
            {
                Fuel = fuel
                NonFuel = nonFuel
                Tax = tax
            }

    type Create'FleetServiceType =
        | FullService
        | NonFuelTransaction
        | SelfService

    type Create'Fleet =
        {
            /// Answers to prompts presented to the cardholder at the point of sale. Prompted fields vary depending on the configuration of your physical fleet cards. Typical points of sale support only numeric entry.
            [<Config.Form>]
            CardholderPromptData: Create'FleetCardholderPromptData option
            /// The type of purchase. One of `fuel_purchase`, `non_fuel_purchase`, or `fuel_and_non_fuel_purchase`.
            [<Config.Form>]
            PurchaseType: Create'FleetPurchaseType option
            /// More information about the total amount. This information is not guaranteed to be accurate as some merchants may provide unreliable data.
            [<Config.Form>]
            ReportedBreakdown: Create'FleetReportedBreakdown option
            /// The type of fuel service. One of `non_fuel_transaction`, `full_service`, or `self_service`.
            [<Config.Form>]
            ServiceType: Create'FleetServiceType option
        }

    type Create'Fleet with
        static member New(?cardholderPromptData: Create'FleetCardholderPromptData, ?purchaseType: Create'FleetPurchaseType, ?reportedBreakdown: Create'FleetReportedBreakdown, ?serviceType: Create'FleetServiceType) =
            {
                CardholderPromptData = cardholderPromptData
                PurchaseType = purchaseType
                ReportedBreakdown = reportedBreakdown
                ServiceType = serviceType
            }

    type Create'FraudDisputabilityLikelihood =
        | Neutral
        | Unknown
        | VeryLikely
        | VeryUnlikely

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

    type Create'Fuel =
        {
            /// [Conexxus Payment System Product Code](https://www.conexxus.org/conexxus-payment-system-product-codes) identifying the primary fuel product purchased.
            [<Config.Form>]
            IndustryProductCode: string option
            /// The quantity of `unit`s of fuel that was dispensed, represented as a decimal string with at most 12 decimal places.
            [<Config.Form>]
            QuantityDecimal: string option
            /// The type of fuel that was purchased. One of `diesel`, `unleaded_plus`, `unleaded_regular`, `unleaded_super`, or `other`.
            [<Config.Form>]
            Type: Create'FuelType option
            /// The units for `quantity_decimal`. One of `charging_minute`, `imperial_gallon`, `kilogram`, `kilowatt_hour`, `liter`, `pound`, `us_gallon`, or `other`.
            [<Config.Form>]
            Unit: Create'FuelUnit option
            /// The cost in cents per each unit of fuel, represented as a decimal string with at most 12 decimal places.
            [<Config.Form>]
            UnitCostDecimal: string option
        }

    type Create'Fuel with
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

    type Create'MerchantData =
        {
            /// A categorization of the seller's type of business. See our [merchant categories guide](https://docs.stripe.com/issuing/merchant-categories) for a list of possible values.
            [<Config.Form>]
            Category: Create'MerchantDataCategory option
            /// City where the seller is located
            [<Config.Form>]
            City: string option
            /// Country where the seller is located
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Name of the seller
            [<Config.Form>]
            Name: string option
            /// Identifier assigned to the seller by the card network. Different card networks may assign different network_id fields to the same merchant.
            [<Config.Form>]
            NetworkId: string option
            /// Postal code where the seller is located
            [<Config.Form>]
            PostalCode: string option
            /// State where the seller is located
            [<Config.Form>]
            State: string option
            /// An ID assigned by the seller to the location of the sale.
            [<Config.Form>]
            TerminalId: string option
            /// URL provided by the merchant on a 3DS request
            [<Config.Form>]
            Url: string option
        }

    type Create'MerchantData with
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

    type Create'NetworkData =
        {
            /// Identifier assigned to the acquirer by the card network.
            [<Config.Form>]
            AcquiringInstitutionId: string option
        }

    type Create'NetworkData with
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

    type Create'RiskAssessmentCardTestingRisk =
        {
            /// The % of declines due to a card number not existing in the past hour, taking place at the same merchant. Higher rates correspond to a greater probability of card testing activity, meaning bad actors may be attempting different card number combinations to guess a correct one. Takes on values between 0 and 100.
            [<Config.Form>]
            InvalidAccountNumberDeclineRatePastHour: int option
            /// The % of declines due to incorrect verification data (like CVV or expiry) in the past hour, taking place at the same merchant. Higher rates correspond to a greater probability of bad actors attempting to utilize valid card credentials at merchants with verification requirements. Takes on values between 0 and 100.
            [<Config.Form>]
            InvalidCredentialsDeclineRatePastHour: int option
            /// The likelihood that this authorization is associated with card testing activity. This is assessed by evaluating decline activity over the last hour.
            [<Config.Form>]
            Level: Create'RiskAssessmentCardTestingRiskLevel option
        }

    type Create'RiskAssessmentCardTestingRisk with
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

    type Create'RiskAssessmentFraudRisk =
        {
            /// Stripe’s assessment of the likelihood of fraud on an authorization.
            [<Config.Form>]
            Level: Create'RiskAssessmentFraudRiskLevel option
            /// Stripe’s numerical model score assessing the likelihood of fraudulent activity. A higher score means a higher likelihood of fraudulent activity, and anything above 25 is considered high risk.
            [<Config.Form>]
            Score: decimal option
        }

    type Create'RiskAssessmentFraudRisk with
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

    type Create'RiskAssessmentMerchantDisputeRisk =
        {
            /// The dispute rate observed across all Stripe Issuing authorizations for this merchant. For example, a value of 50 means 50% of authorizations from this merchant on Stripe Issuing have resulted in a dispute. Higher values mean a higher likelihood the authorization is disputed. Takes on values between 0 and 100.
            [<Config.Form>]
            DisputeRate: int option
            /// The likelihood that authorizations from this merchant will result in a dispute based on their history on Stripe Issuing.
            [<Config.Form>]
            Level: Create'RiskAssessmentMerchantDisputeRiskLevel option
        }

    type Create'RiskAssessmentMerchantDisputeRisk with
        static member New(?disputeRate: int, ?level: Create'RiskAssessmentMerchantDisputeRiskLevel) =
            {
                DisputeRate = disputeRate
                Level = level
            }

    type Create'RiskAssessment =
        {
            /// Stripe's assessment of this authorization's likelihood of being card testing activity.
            [<Config.Form>]
            CardTestingRisk: Create'RiskAssessmentCardTestingRisk option
            /// Stripe’s assessment of this authorization’s likelihood to be fraudulent.
            [<Config.Form>]
            FraudRisk: Create'RiskAssessmentFraudRisk option
            /// The dispute risk of the merchant (the seller on a purchase) on an authorization based on all Stripe Issuing activity.
            [<Config.Form>]
            MerchantDisputeRisk: Create'RiskAssessmentMerchantDisputeRisk option
        }

    type Create'RiskAssessment with
        static member New(?cardTestingRisk: Create'RiskAssessmentCardTestingRisk, ?fraudRisk: Create'RiskAssessmentFraudRisk, ?merchantDisputeRisk: Create'RiskAssessmentMerchantDisputeRisk) =
            {
                CardTestingRisk = cardTestingRisk
                FraudRisk = fraudRisk
                MerchantDisputeRisk = merchantDisputeRisk
            }

    type Create'VerificationDataAddressLine1Check =
        | Match
        | Mismatch
        | NotProvided

    type Create'VerificationDataAddressPostalCodeCheck =
        | Match
        | Mismatch
        | NotProvided

    type Create'VerificationDataAuthenticationExemptionClaimedBy =
        | Acquirer
        | Issuer

    type Create'VerificationDataAuthenticationExemptionType =
        | LowValueTransaction
        | TransactionRiskAnalysis
        | Unknown

    type Create'VerificationDataAuthenticationExemption =
        {
            /// The entity that requested the exemption, either the acquiring merchant or the Issuing user.
            [<Config.Form>]
            ClaimedBy: Create'VerificationDataAuthenticationExemptionClaimedBy option
            /// The specific exemption claimed for this authorization.
            [<Config.Form>]
            Type: Create'VerificationDataAuthenticationExemptionType option
        }

    type Create'VerificationDataAuthenticationExemption with
        static member New(?claimedBy: Create'VerificationDataAuthenticationExemptionClaimedBy, ?type': Create'VerificationDataAuthenticationExemptionType) =
            {
                ClaimedBy = claimedBy
                Type = type'
            }

    type Create'VerificationDataCvcCheck =
        | Match
        | Mismatch
        | NotProvided

    type Create'VerificationDataExpiryCheck =
        | Match
        | Mismatch
        | NotProvided

    type Create'VerificationDataThreeDSecureResult =
        | AttemptAcknowledged
        | Authenticated
        | Failed
        | Required

    type Create'VerificationDataThreeDSecure =
        {
            /// The outcome of the 3D Secure authentication request.
            [<Config.Form>]
            Result: Create'VerificationDataThreeDSecureResult option
        }

    type Create'VerificationDataThreeDSecure with
        static member New(?result: Create'VerificationDataThreeDSecureResult) =
            {
                Result = result
            }

    type Create'VerificationData =
        {
            /// Whether the cardholder provided an address first line and if it matched the cardholder’s `billing.address.line1`.
            [<Config.Form>]
            AddressLine1Check: Create'VerificationDataAddressLine1Check option
            /// Whether the cardholder provided a postal code and if it matched the cardholder’s `billing.address.postal_code`.
            [<Config.Form>]
            AddressPostalCodeCheck: Create'VerificationDataAddressPostalCodeCheck option
            /// The exemption applied to this authorization.
            [<Config.Form>]
            AuthenticationExemption: Create'VerificationDataAuthenticationExemption option
            /// Whether the cardholder provided a CVC and if it matched Stripe’s record.
            [<Config.Form>]
            CvcCheck: Create'VerificationDataCvcCheck option
            /// Whether the cardholder provided an expiry date and if it matched Stripe’s record.
            [<Config.Form>]
            ExpiryCheck: Create'VerificationDataExpiryCheck option
            /// 3D Secure details.
            [<Config.Form>]
            ThreeDSecure: Create'VerificationDataThreeDSecure option
        }

    type Create'VerificationData with
        static member New(?addressLine1Check: Create'VerificationDataAddressLine1Check, ?addressPostalCodeCheck: Create'VerificationDataAddressPostalCodeCheck, ?authenticationExemption: Create'VerificationDataAuthenticationExemption, ?cvcCheck: Create'VerificationDataCvcCheck, ?expiryCheck: Create'VerificationDataExpiryCheck, ?threeDSecure: Create'VerificationDataThreeDSecure) =
            {
                AddressLine1Check = addressLine1Check
                AddressPostalCodeCheck = addressPostalCodeCheck
                AuthenticationExemption = authenticationExemption
                CvcCheck = cvcCheck
                ExpiryCheck = expiryCheck
                ThreeDSecure = threeDSecure
            }

    type Create'Wallet =
        | ApplePay
        | GooglePay
        | SamsungPay

    type CreateOptions =
        {
            /// The total amount to attempt to authorize. This amount is in the provided currency, or defaults to the card's currency, and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).
            [<Config.Form>]
            Amount: int option
            /// Detailed breakdown of amount components. These amounts are denominated in `currency` and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).
            [<Config.Form>]
            AmountDetails: Create'AmountDetails option
            /// How the card details were provided. Defaults to online.
            [<Config.Form>]
            AuthorizationMethod: Create'AuthorizationMethod option
            /// Card associated with this authorization.
            [<Config.Form>]
            Card: string
            /// The currency of the authorization. If not provided, defaults to the currency of the card. Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Fleet-specific information for authorizations using Fleet cards.
            [<Config.Form>]
            Fleet: Create'Fleet option
            /// Probability that this transaction can be disputed in the event of fraud. Assessed by comparing the characteristics of the authorization to card network rules.
            [<Config.Form>]
            FraudDisputabilityLikelihood: Create'FraudDisputabilityLikelihood option
            /// Information about fuel that was purchased with this transaction.
            [<Config.Form>]
            Fuel: Create'Fuel option
            /// If set `true`, you may provide [amount](https://docs.stripe.com/api/issuing/authorizations/approve#approve_issuing_authorization-amount) to control how much to hold for the authorization.
            [<Config.Form>]
            IsAmountControllable: bool option
            /// The total amount to attempt to authorize. This amount is in the provided merchant currency, and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).
            [<Config.Form>]
            MerchantAmount: int option
            /// The currency of the authorization. If not provided, defaults to the currency of the card. Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            MerchantCurrency: IsoTypes.IsoCurrencyCode option
            /// Details about the seller (grocery store, e-commerce website, etc.) where the card authorization happened.
            [<Config.Form>]
            MerchantData: Create'MerchantData option
            /// Details about the authorization, such as identifiers, set by the card network.
            [<Config.Form>]
            NetworkData: Create'NetworkData option
            /// Stripe’s assessment of the fraud risk for this authorization.
            [<Config.Form>]
            RiskAssessment: Create'RiskAssessment option
            /// Verifications that Stripe performed on information that the cardholder provided to the merchant.
            [<Config.Form>]
            VerificationData: Create'VerificationData option
            /// The digital wallet used for this transaction. One of `apple_pay`, `google_pay`, or `samsung_pay`. Will populate as `null` when no digital wallet was utilized.
            [<Config.Form>]
            Wallet: Create'Wallet option
        }

    type CreateOptions with
        static member New(card: string, ?amount: int, ?amountDetails: Create'AmountDetails, ?authorizationMethod: Create'AuthorizationMethod, ?currency: IsoTypes.IsoCurrencyCode, ?expand: string list, ?fleet: Create'Fleet, ?fraudDisputabilityLikelihood: Create'FraudDisputabilityLikelihood, ?fuel: Create'Fuel, ?isAmountControllable: bool, ?merchantAmount: int, ?merchantCurrency: IsoTypes.IsoCurrencyCode, ?merchantData: Create'MerchantData, ?networkData: Create'NetworkData, ?riskAssessment: Create'RiskAssessment, ?verificationData: Create'VerificationData, ?wallet: Create'Wallet) =
            {
                Card = card
                Amount = amount
                AmountDetails = amountDetails
                AuthorizationMethod = authorizationMethod
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

    ///<p>Create a test-mode authorization.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/test_helpers/issuing/authorizations"
        |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) options

module TestHelpersIssuingAuthorizationsCapture =

    type Capture'PurchaseDetailsFleetCardholderPromptData =
        {
            /// Driver ID.
            [<Config.Form>]
            DriverId: string option
            /// Odometer reading.
            [<Config.Form>]
            Odometer: int option
            /// An alphanumeric ID. This field is used when a vehicle ID, driver ID, or generic ID is entered by the cardholder, but the merchant or card network did not specify the prompt type.
            [<Config.Form>]
            UnspecifiedId: string option
            /// User ID.
            [<Config.Form>]
            UserId: string option
            /// Vehicle number.
            [<Config.Form>]
            VehicleNumber: string option
        }

    type Capture'PurchaseDetailsFleetCardholderPromptData with
        static member New(?driverId: string, ?odometer: int, ?unspecifiedId: string, ?userId: string, ?vehicleNumber: string) =
            {
                DriverId = driverId
                Odometer = odometer
                UnspecifiedId = unspecifiedId
                UserId = userId
                VehicleNumber = vehicleNumber
            }

    type Capture'PurchaseDetailsFleetPurchaseType =
        | FuelAndNonFuelPurchase
        | FuelPurchase
        | NonFuelPurchase

    type Capture'PurchaseDetailsFleetReportedBreakdownFuel =
        {
            /// Gross fuel amount that should equal Fuel Volume multipled by Fuel Unit Cost, inclusive of taxes.
            [<Config.Form>]
            GrossAmountDecimal: string option
        }

    type Capture'PurchaseDetailsFleetReportedBreakdownFuel with
        static member New(?grossAmountDecimal: string) =
            {
                GrossAmountDecimal = grossAmountDecimal
            }

    type Capture'PurchaseDetailsFleetReportedBreakdownNonFuel =
        {
            /// Gross non-fuel amount that should equal the sum of the line items, inclusive of taxes.
            [<Config.Form>]
            GrossAmountDecimal: string option
        }

    type Capture'PurchaseDetailsFleetReportedBreakdownNonFuel with
        static member New(?grossAmountDecimal: string) =
            {
                GrossAmountDecimal = grossAmountDecimal
            }

    type Capture'PurchaseDetailsFleetReportedBreakdownTax =
        {
            /// Amount of state or provincial Sales Tax included in the transaction amount. Null if not reported by merchant or not subject to tax.
            [<Config.Form>]
            LocalAmountDecimal: string option
            /// Amount of national Sales Tax or VAT included in the transaction amount. Null if not reported by merchant or not subject to tax.
            [<Config.Form>]
            NationalAmountDecimal: string option
        }

    type Capture'PurchaseDetailsFleetReportedBreakdownTax with
        static member New(?localAmountDecimal: string, ?nationalAmountDecimal: string) =
            {
                LocalAmountDecimal = localAmountDecimal
                NationalAmountDecimal = nationalAmountDecimal
            }

    type Capture'PurchaseDetailsFleetReportedBreakdown =
        {
            /// Breakdown of fuel portion of the purchase.
            [<Config.Form>]
            Fuel: Capture'PurchaseDetailsFleetReportedBreakdownFuel option
            /// Breakdown of non-fuel portion of the purchase.
            [<Config.Form>]
            NonFuel: Capture'PurchaseDetailsFleetReportedBreakdownNonFuel option
            /// Information about tax included in this transaction.
            [<Config.Form>]
            Tax: Capture'PurchaseDetailsFleetReportedBreakdownTax option
        }

    type Capture'PurchaseDetailsFleetReportedBreakdown with
        static member New(?fuel: Capture'PurchaseDetailsFleetReportedBreakdownFuel, ?nonFuel: Capture'PurchaseDetailsFleetReportedBreakdownNonFuel, ?tax: Capture'PurchaseDetailsFleetReportedBreakdownTax) =
            {
                Fuel = fuel
                NonFuel = nonFuel
                Tax = tax
            }

    type Capture'PurchaseDetailsFleetServiceType =
        | FullService
        | NonFuelTransaction
        | SelfService

    type Capture'PurchaseDetailsFleet =
        {
            /// Answers to prompts presented to the cardholder at the point of sale. Prompted fields vary depending on the configuration of your physical fleet cards. Typical points of sale support only numeric entry.
            [<Config.Form>]
            CardholderPromptData: Capture'PurchaseDetailsFleetCardholderPromptData option
            /// The type of purchase. One of `fuel_purchase`, `non_fuel_purchase`, or `fuel_and_non_fuel_purchase`.
            [<Config.Form>]
            PurchaseType: Capture'PurchaseDetailsFleetPurchaseType option
            /// More information about the total amount. This information is not guaranteed to be accurate as some merchants may provide unreliable data.
            [<Config.Form>]
            ReportedBreakdown: Capture'PurchaseDetailsFleetReportedBreakdown option
            /// The type of fuel service. One of `non_fuel_transaction`, `full_service`, or `self_service`.
            [<Config.Form>]
            ServiceType: Capture'PurchaseDetailsFleetServiceType option
        }

    type Capture'PurchaseDetailsFleet with
        static member New(?cardholderPromptData: Capture'PurchaseDetailsFleetCardholderPromptData, ?purchaseType: Capture'PurchaseDetailsFleetPurchaseType, ?reportedBreakdown: Capture'PurchaseDetailsFleetReportedBreakdown, ?serviceType: Capture'PurchaseDetailsFleetServiceType) =
            {
                CardholderPromptData = cardholderPromptData
                PurchaseType = purchaseType
                ReportedBreakdown = reportedBreakdown
                ServiceType = serviceType
            }

    type Capture'PurchaseDetailsFlightSegments =
        {
            /// The three-letter IATA airport code of the flight's destination.
            [<Config.Form>]
            ArrivalAirportCode: string option
            /// The airline carrier code.
            [<Config.Form>]
            Carrier: string option
            /// The three-letter IATA airport code that the flight departed from.
            [<Config.Form>]
            DepartureAirportCode: string option
            /// The flight number.
            [<Config.Form>]
            FlightNumber: string option
            /// The flight's service class.
            [<Config.Form>]
            ServiceClass: string option
            /// Whether a stopover is allowed on this flight.
            [<Config.Form>]
            StopoverAllowed: bool option
        }

    type Capture'PurchaseDetailsFlightSegments with
        static member New(?arrivalAirportCode: string, ?carrier: string, ?departureAirportCode: string, ?flightNumber: string, ?serviceClass: string, ?stopoverAllowed: bool) =
            {
                ArrivalAirportCode = arrivalAirportCode
                Carrier = carrier
                DepartureAirportCode = departureAirportCode
                FlightNumber = flightNumber
                ServiceClass = serviceClass
                StopoverAllowed = stopoverAllowed
            }

    type Capture'PurchaseDetailsFlight =
        {
            /// The time that the flight departed.
            [<Config.Form>]
            DepartureAt: DateTime option
            /// The name of the passenger.
            [<Config.Form>]
            PassengerName: string option
            /// Whether the ticket is refundable.
            [<Config.Form>]
            Refundable: bool option
            /// The legs of the trip.
            [<Config.Form>]
            Segments: Capture'PurchaseDetailsFlightSegments list option
            /// The travel agency that issued the ticket.
            [<Config.Form>]
            TravelAgency: string option
        }

    type Capture'PurchaseDetailsFlight with
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

    type Capture'PurchaseDetailsFuel =
        {
            /// [Conexxus Payment System Product Code](https://www.conexxus.org/conexxus-payment-system-product-codes) identifying the primary fuel product purchased.
            [<Config.Form>]
            IndustryProductCode: string option
            /// The quantity of `unit`s of fuel that was dispensed, represented as a decimal string with at most 12 decimal places.
            [<Config.Form>]
            QuantityDecimal: string option
            /// The type of fuel that was purchased. One of `diesel`, `unleaded_plus`, `unleaded_regular`, `unleaded_super`, or `other`.
            [<Config.Form>]
            Type: Capture'PurchaseDetailsFuelType option
            /// The units for `quantity_decimal`. One of `charging_minute`, `imperial_gallon`, `kilogram`, `kilowatt_hour`, `liter`, `pound`, `us_gallon`, or `other`.
            [<Config.Form>]
            Unit: Capture'PurchaseDetailsFuelUnit option
            /// The cost in cents per each unit of fuel, represented as a decimal string with at most 12 decimal places.
            [<Config.Form>]
            UnitCostDecimal: string option
        }

    type Capture'PurchaseDetailsFuel with
        static member New(?industryProductCode: string, ?quantityDecimal: string, ?type': Capture'PurchaseDetailsFuelType, ?unit: Capture'PurchaseDetailsFuelUnit, ?unitCostDecimal: string) =
            {
                IndustryProductCode = industryProductCode
                QuantityDecimal = quantityDecimal
                Type = type'
                Unit = unit
                UnitCostDecimal = unitCostDecimal
            }

    type Capture'PurchaseDetailsLodging =
        {
            /// The time of checking into the lodging.
            [<Config.Form>]
            CheckInAt: DateTime option
            /// The number of nights stayed at the lodging.
            [<Config.Form>]
            Nights: int option
        }

    type Capture'PurchaseDetailsLodging with
        static member New(?checkInAt: DateTime, ?nights: int) =
            {
                CheckInAt = checkInAt
                Nights = nights
            }

    type Capture'PurchaseDetailsReceipt =
        { [<Config.Form>]
          Description: string option
          [<Config.Form>]
          Quantity: string option
          [<Config.Form>]
          Total: int option
          [<Config.Form>]
          UnitCost: int option }

    type Capture'PurchaseDetailsReceipt with
        static member New(?description: string, ?quantity: string, ?total: int, ?unitCost: int) =
            {
                Description = description
                Quantity = quantity
                Total = total
                UnitCost = unitCost
            }

    type Capture'PurchaseDetails =
        {
            /// Fleet-specific information for transactions using Fleet cards.
            [<Config.Form>]
            Fleet: Capture'PurchaseDetailsFleet option
            /// Information about the flight that was purchased with this transaction.
            [<Config.Form>]
            Flight: Capture'PurchaseDetailsFlight option
            /// Information about fuel that was purchased with this transaction.
            [<Config.Form>]
            Fuel: Capture'PurchaseDetailsFuel option
            /// Information about lodging that was purchased with this transaction.
            [<Config.Form>]
            Lodging: Capture'PurchaseDetailsLodging option
            /// The line items in the purchase.
            [<Config.Form>]
            Receipt: Capture'PurchaseDetailsReceipt list option
            /// A merchant-specific order number.
            [<Config.Form>]
            Reference: string option
        }

    type Capture'PurchaseDetails with
        static member New(?fleet: Capture'PurchaseDetailsFleet, ?flight: Capture'PurchaseDetailsFlight, ?fuel: Capture'PurchaseDetailsFuel, ?lodging: Capture'PurchaseDetailsLodging, ?receipt: Capture'PurchaseDetailsReceipt list, ?reference: string) =
            {
                Fleet = fleet
                Flight = flight
                Fuel = fuel
                Lodging = lodging
                Receipt = receipt
                Reference = reference
            }

    type CaptureOptions =
        {
            [<Config.Path>]
            Authorization: string
            /// The amount to capture from the authorization. If not provided, the full amount of the authorization will be captured. This amount is in the authorization currency and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).
            [<Config.Form>]
            CaptureAmount: int option
            /// Whether to close the authorization after capture. Defaults to true. Set to false to enable multi-capture flows.
            [<Config.Form>]
            CloseAuthorization: bool option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Additional purchase information that is optionally provided by the merchant.
            [<Config.Form>]
            PurchaseDetails: Capture'PurchaseDetails option
        }

    type CaptureOptions with
        static member New(authorization: string, ?captureAmount: int, ?closeAuthorization: bool, ?expand: string list, ?purchaseDetails: Capture'PurchaseDetails) =
            {
                Authorization = authorization
                CaptureAmount = captureAmount
                CloseAuthorization = closeAuthorization
                Expand = expand
                PurchaseDetails = purchaseDetails
            }

    ///<p>Capture a test-mode authorization.</p>
    let Capture settings (options: CaptureOptions) =
        $"/v1/test_helpers/issuing/authorizations/{options.Authorization}/capture"
        |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) options

module TestHelpersIssuingAuthorizationsExpire =

    type ExpireOptions =
        {
            [<Config.Path>]
            Authorization: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type ExpireOptions with
        static member New(authorization: string, ?expand: string list) =
            {
                Authorization = authorization
                Expand = expand
            }

    ///<p>Expire a test-mode Authorization.</p>
    let Expire settings (options: ExpireOptions) =
        $"/v1/test_helpers/issuing/authorizations/{options.Authorization}/expire"
        |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) options

module TestHelpersIssuingAuthorizationsFinalizeAmount =

    type FinalizeAmount'FleetCardholderPromptData =
        {
            /// Driver ID.
            [<Config.Form>]
            DriverId: string option
            /// Odometer reading.
            [<Config.Form>]
            Odometer: int option
            /// An alphanumeric ID. This field is used when a vehicle ID, driver ID, or generic ID is entered by the cardholder, but the merchant or card network did not specify the prompt type.
            [<Config.Form>]
            UnspecifiedId: string option
            /// User ID.
            [<Config.Form>]
            UserId: string option
            /// Vehicle number.
            [<Config.Form>]
            VehicleNumber: string option
        }

    type FinalizeAmount'FleetCardholderPromptData with
        static member New(?driverId: string, ?odometer: int, ?unspecifiedId: string, ?userId: string, ?vehicleNumber: string) =
            {
                DriverId = driverId
                Odometer = odometer
                UnspecifiedId = unspecifiedId
                UserId = userId
                VehicleNumber = vehicleNumber
            }

    type FinalizeAmount'FleetPurchaseType =
        | FuelAndNonFuelPurchase
        | FuelPurchase
        | NonFuelPurchase

    type FinalizeAmount'FleetReportedBreakdownFuel =
        {
            /// Gross fuel amount that should equal Fuel Volume multipled by Fuel Unit Cost, inclusive of taxes.
            [<Config.Form>]
            GrossAmountDecimal: string option
        }

    type FinalizeAmount'FleetReportedBreakdownFuel with
        static member New(?grossAmountDecimal: string) =
            {
                GrossAmountDecimal = grossAmountDecimal
            }

    type FinalizeAmount'FleetReportedBreakdownNonFuel =
        {
            /// Gross non-fuel amount that should equal the sum of the line items, inclusive of taxes.
            [<Config.Form>]
            GrossAmountDecimal: string option
        }

    type FinalizeAmount'FleetReportedBreakdownNonFuel with
        static member New(?grossAmountDecimal: string) =
            {
                GrossAmountDecimal = grossAmountDecimal
            }

    type FinalizeAmount'FleetReportedBreakdownTax =
        {
            /// Amount of state or provincial Sales Tax included in the transaction amount. Null if not reported by merchant or not subject to tax.
            [<Config.Form>]
            LocalAmountDecimal: string option
            /// Amount of national Sales Tax or VAT included in the transaction amount. Null if not reported by merchant or not subject to tax.
            [<Config.Form>]
            NationalAmountDecimal: string option
        }

    type FinalizeAmount'FleetReportedBreakdownTax with
        static member New(?localAmountDecimal: string, ?nationalAmountDecimal: string) =
            {
                LocalAmountDecimal = localAmountDecimal
                NationalAmountDecimal = nationalAmountDecimal
            }

    type FinalizeAmount'FleetReportedBreakdown =
        {
            /// Breakdown of fuel portion of the purchase.
            [<Config.Form>]
            Fuel: FinalizeAmount'FleetReportedBreakdownFuel option
            /// Breakdown of non-fuel portion of the purchase.
            [<Config.Form>]
            NonFuel: FinalizeAmount'FleetReportedBreakdownNonFuel option
            /// Information about tax included in this transaction.
            [<Config.Form>]
            Tax: FinalizeAmount'FleetReportedBreakdownTax option
        }

    type FinalizeAmount'FleetReportedBreakdown with
        static member New(?fuel: FinalizeAmount'FleetReportedBreakdownFuel, ?nonFuel: FinalizeAmount'FleetReportedBreakdownNonFuel, ?tax: FinalizeAmount'FleetReportedBreakdownTax) =
            {
                Fuel = fuel
                NonFuel = nonFuel
                Tax = tax
            }

    type FinalizeAmount'FleetServiceType =
        | FullService
        | NonFuelTransaction
        | SelfService

    type FinalizeAmount'Fleet =
        {
            /// Answers to prompts presented to the cardholder at the point of sale. Prompted fields vary depending on the configuration of your physical fleet cards. Typical points of sale support only numeric entry.
            [<Config.Form>]
            CardholderPromptData: FinalizeAmount'FleetCardholderPromptData option
            /// The type of purchase. One of `fuel_purchase`, `non_fuel_purchase`, or `fuel_and_non_fuel_purchase`.
            [<Config.Form>]
            PurchaseType: FinalizeAmount'FleetPurchaseType option
            /// More information about the total amount. This information is not guaranteed to be accurate as some merchants may provide unreliable data.
            [<Config.Form>]
            ReportedBreakdown: FinalizeAmount'FleetReportedBreakdown option
            /// The type of fuel service. One of `non_fuel_transaction`, `full_service`, or `self_service`.
            [<Config.Form>]
            ServiceType: FinalizeAmount'FleetServiceType option
        }

    type FinalizeAmount'Fleet with
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

    type FinalizeAmount'Fuel =
        {
            /// [Conexxus Payment System Product Code](https://www.conexxus.org/conexxus-payment-system-product-codes) identifying the primary fuel product purchased.
            [<Config.Form>]
            IndustryProductCode: string option
            /// The quantity of `unit`s of fuel that was dispensed, represented as a decimal string with at most 12 decimal places.
            [<Config.Form>]
            QuantityDecimal: string option
            /// The type of fuel that was purchased. One of `diesel`, `unleaded_plus`, `unleaded_regular`, `unleaded_super`, or `other`.
            [<Config.Form>]
            Type: FinalizeAmount'FuelType option
            /// The units for `quantity_decimal`. One of `charging_minute`, `imperial_gallon`, `kilogram`, `kilowatt_hour`, `liter`, `pound`, `us_gallon`, or `other`.
            [<Config.Form>]
            Unit: FinalizeAmount'FuelUnit option
            /// The cost in cents per each unit of fuel, represented as a decimal string with at most 12 decimal places.
            [<Config.Form>]
            UnitCostDecimal: string option
        }

    type FinalizeAmount'Fuel with
        static member New(?industryProductCode: string, ?quantityDecimal: string, ?type': FinalizeAmount'FuelType, ?unit: FinalizeAmount'FuelUnit, ?unitCostDecimal: string) =
            {
                IndustryProductCode = industryProductCode
                QuantityDecimal = quantityDecimal
                Type = type'
                Unit = unit
                UnitCostDecimal = unitCostDecimal
            }

    type FinalizeAmountOptions =
        {
            [<Config.Path>]
            Authorization: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The final authorization amount that will be captured by the merchant. This amount is in the authorization currency and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).
            [<Config.Form>]
            FinalAmount: int
            /// Fleet-specific information for authorizations using Fleet cards.
            [<Config.Form>]
            Fleet: FinalizeAmount'Fleet option
            /// Information about fuel that was purchased with this transaction.
            [<Config.Form>]
            Fuel: FinalizeAmount'Fuel option
        }

    type FinalizeAmountOptions with
        static member New(authorization: string, finalAmount: int, ?expand: string list, ?fleet: FinalizeAmount'Fleet, ?fuel: FinalizeAmount'Fuel) =
            {
                Authorization = authorization
                FinalAmount = finalAmount
                Expand = expand
                Fleet = fleet
                Fuel = fuel
            }

    ///<p>Finalize the amount on an Authorization prior to capture, when the initial authorization was for an estimated amount.</p>
    let FinalizeAmount settings (options: FinalizeAmountOptions) =
        $"/v1/test_helpers/issuing/authorizations/{options.Authorization}/finalize_amount"
        |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) options

module TestHelpersIssuingAuthorizationsFraudChallengesRespond =

    type RespondOptions =
        {
            [<Config.Path>]
            Authorization: string
            /// Whether to simulate the user confirming that the transaction was legitimate (true) or telling Stripe that it was fraudulent (false).
            [<Config.Form>]
            Confirmed: bool
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type RespondOptions with
        static member New(authorization: string, confirmed: bool, ?expand: string list) =
            {
                Authorization = authorization
                Confirmed = confirmed
                Expand = expand
            }

    ///<p>Respond to a fraud challenge on a testmode Issuing authorization, simulating either a confirmation of fraud or a correction of legitimacy.</p>
    let Respond settings (options: RespondOptions) =
        $"/v1/test_helpers/issuing/authorizations/{options.Authorization}/fraud_challenges/respond"
        |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) options

module TestHelpersIssuingAuthorizationsIncrement =

    type IncrementOptions =
        {
            [<Config.Path>]
            Authorization: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The amount to increment the authorization by. This amount is in the authorization currency and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).
            [<Config.Form>]
            IncrementAmount: int
            /// If set `true`, you may provide [amount](https://docs.stripe.com/api/issuing/authorizations/approve#approve_issuing_authorization-amount) to control how much to hold for the authorization.
            [<Config.Form>]
            IsAmountControllable: bool option
        }

    type IncrementOptions with
        static member New(authorization: string, incrementAmount: int, ?expand: string list, ?isAmountControllable: bool) =
            {
                Authorization = authorization
                IncrementAmount = incrementAmount
                Expand = expand
                IsAmountControllable = isAmountControllable
            }

    ///<p>Increment a test-mode Authorization.</p>
    let Increment settings (options: IncrementOptions) =
        $"/v1/test_helpers/issuing/authorizations/{options.Authorization}/increment"
        |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) options

module TestHelpersIssuingAuthorizationsReverse =

    type ReverseOptions =
        {
            [<Config.Path>]
            Authorization: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The amount to reverse from the authorization. If not provided, the full amount of the authorization will be reversed. This amount is in the authorization currency and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).
            [<Config.Form>]
            ReverseAmount: int option
        }

    type ReverseOptions with
        static member New(authorization: string, ?expand: string list, ?reverseAmount: int) =
            {
                Authorization = authorization
                Expand = expand
                ReverseAmount = reverseAmount
            }

    ///<p>Reverse a test-mode Authorization.</p>
    let Reverse settings (options: ReverseOptions) =
        $"/v1/test_helpers/issuing/authorizations/{options.Authorization}/reverse"
        |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) options

module TestHelpersIssuingCardsShippingDeliver =

    type DeliverCardOptions =
        {
            [<Config.Path>]
            Card: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type DeliverCardOptions with
        static member New(card: string, ?expand: string list) =
            {
                Card = card
                Expand = expand
            }

    ///<p>Updates the shipping status of the specified Issuing <code>Card</code> object to <code>delivered</code>.</p>
    let DeliverCard settings (options: DeliverCardOptions) =
        $"/v1/test_helpers/issuing/cards/{options.Card}/shipping/deliver"
        |> RestApi.postAsync<_, IssuingCard> settings (Map.empty) options

module TestHelpersIssuingCardsShippingFail =

    type FailCardOptions =
        {
            [<Config.Path>]
            Card: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type FailCardOptions with
        static member New(card: string, ?expand: string list) =
            {
                Card = card
                Expand = expand
            }

    ///<p>Updates the shipping status of the specified Issuing <code>Card</code> object to <code>failure</code>.</p>
    let FailCard settings (options: FailCardOptions) =
        $"/v1/test_helpers/issuing/cards/{options.Card}/shipping/fail"
        |> RestApi.postAsync<_, IssuingCard> settings (Map.empty) options

module TestHelpersIssuingCardsShippingReturn =

    type ReturnCardOptions =
        {
            [<Config.Path>]
            Card: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type ReturnCardOptions with
        static member New(card: string, ?expand: string list) =
            {
                Card = card
                Expand = expand
            }

    ///<p>Updates the shipping status of the specified Issuing <code>Card</code> object to <code>returned</code>.</p>
    let ReturnCard settings (options: ReturnCardOptions) =
        $"/v1/test_helpers/issuing/cards/{options.Card}/shipping/return"
        |> RestApi.postAsync<_, IssuingCard> settings (Map.empty) options

module TestHelpersIssuingCardsShippingShip =

    type ShipCardOptions =
        {
            [<Config.Path>]
            Card: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type ShipCardOptions with
        static member New(card: string, ?expand: string list) =
            {
                Card = card
                Expand = expand
            }

    ///<p>Updates the shipping status of the specified Issuing <code>Card</code> object to <code>shipped</code>.</p>
    let ShipCard settings (options: ShipCardOptions) =
        $"/v1/test_helpers/issuing/cards/{options.Card}/shipping/ship"
        |> RestApi.postAsync<_, IssuingCard> settings (Map.empty) options

module TestHelpersIssuingCardsShippingSubmit =

    type SubmitCardOptions =
        {
            [<Config.Path>]
            Card: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type SubmitCardOptions with
        static member New(card: string, ?expand: string list) =
            {
                Card = card
                Expand = expand
            }

    ///<p>Updates the shipping status of the specified Issuing <code>Card</code> object to <code>submitted</code>. This method requires Stripe Version ‘2024-09-30.acacia’ or later.</p>
    let SubmitCard settings (options: SubmitCardOptions) =
        $"/v1/test_helpers/issuing/cards/{options.Card}/shipping/submit"
        |> RestApi.postAsync<_, IssuingCard> settings (Map.empty) options

module TestHelpersIssuingPersonalizationDesignsActivate =

    type ActivateOptions =
        {
            [<Config.Path>]
            PersonalizationDesign: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type ActivateOptions with
        static member New(personalizationDesign: string, ?expand: string list) =
            {
                PersonalizationDesign = personalizationDesign
                Expand = expand
            }

    ///<p>Updates the <code>status</code> of the specified testmode personalization design object to <code>active</code>.</p>
    let Activate settings (options: ActivateOptions) =
        $"/v1/test_helpers/issuing/personalization_designs/{options.PersonalizationDesign}/activate"
        |> RestApi.postAsync<_, IssuingPersonalizationDesign> settings (Map.empty) options

module TestHelpersIssuingPersonalizationDesignsDeactivate =

    type DeactivateOptions =
        {
            [<Config.Path>]
            PersonalizationDesign: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type DeactivateOptions with
        static member New(personalizationDesign: string, ?expand: string list) =
            {
                PersonalizationDesign = personalizationDesign
                Expand = expand
            }

    ///<p>Updates the <code>status</code> of the specified testmode personalization design object to <code>inactive</code>.</p>
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

    type Reject'RejectionReasons =
        {
            /// The reason(s) the card logo was rejected.
            [<Config.Form>]
            CardLogo: Reject'RejectionReasonsCardLogo list option
            /// The reason(s) the carrier text was rejected.
            [<Config.Form>]
            CarrierText: Reject'RejectionReasonsCarrierText list option
        }

    type Reject'RejectionReasons with
        static member New(?cardLogo: Reject'RejectionReasonsCardLogo list, ?carrierText: Reject'RejectionReasonsCarrierText list) =
            {
                CardLogo = cardLogo
                CarrierText = carrierText
            }

    type RejectOptions =
        {
            [<Config.Path>]
            PersonalizationDesign: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The reason(s) the personalization design was rejected.
            [<Config.Form>]
            RejectionReasons: Reject'RejectionReasons
        }

    type RejectOptions with
        static member New(personalizationDesign: string, rejectionReasons: Reject'RejectionReasons, ?expand: string list) =
            {
                PersonalizationDesign = personalizationDesign
                RejectionReasons = rejectionReasons
                Expand = expand
            }

    ///<p>Updates the <code>status</code> of the specified testmode personalization design object to <code>rejected</code>.</p>
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

    type CreateForceCapture'MerchantData =
        {
            /// A categorization of the seller's type of business. See our [merchant categories guide](https://docs.stripe.com/issuing/merchant-categories) for a list of possible values.
            [<Config.Form>]
            Category: CreateForceCapture'MerchantDataCategory option
            /// City where the seller is located
            [<Config.Form>]
            City: string option
            /// Country where the seller is located
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Name of the seller
            [<Config.Form>]
            Name: string option
            /// Identifier assigned to the seller by the card network. Different card networks may assign different network_id fields to the same merchant.
            [<Config.Form>]
            NetworkId: string option
            /// Postal code where the seller is located
            [<Config.Form>]
            PostalCode: string option
            /// State where the seller is located
            [<Config.Form>]
            State: string option
            /// An ID assigned by the seller to the location of the sale.
            [<Config.Form>]
            TerminalId: string option
            /// URL provided by the merchant on a 3DS request
            [<Config.Form>]
            Url: string option
        }

    type CreateForceCapture'MerchantData with
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

    type CreateForceCapture'PurchaseDetailsFleetCardholderPromptData =
        {
            /// Driver ID.
            [<Config.Form>]
            DriverId: string option
            /// Odometer reading.
            [<Config.Form>]
            Odometer: int option
            /// An alphanumeric ID. This field is used when a vehicle ID, driver ID, or generic ID is entered by the cardholder, but the merchant or card network did not specify the prompt type.
            [<Config.Form>]
            UnspecifiedId: string option
            /// User ID.
            [<Config.Form>]
            UserId: string option
            /// Vehicle number.
            [<Config.Form>]
            VehicleNumber: string option
        }

    type CreateForceCapture'PurchaseDetailsFleetCardholderPromptData with
        static member New(?driverId: string, ?odometer: int, ?unspecifiedId: string, ?userId: string, ?vehicleNumber: string) =
            {
                DriverId = driverId
                Odometer = odometer
                UnspecifiedId = unspecifiedId
                UserId = userId
                VehicleNumber = vehicleNumber
            }

    type CreateForceCapture'PurchaseDetailsFleetPurchaseType =
        | FuelAndNonFuelPurchase
        | FuelPurchase
        | NonFuelPurchase

    type CreateForceCapture'PurchaseDetailsFleetReportedBreakdownFuel =
        {
            /// Gross fuel amount that should equal Fuel Volume multipled by Fuel Unit Cost, inclusive of taxes.
            [<Config.Form>]
            GrossAmountDecimal: string option
        }

    type CreateForceCapture'PurchaseDetailsFleetReportedBreakdownFuel with
        static member New(?grossAmountDecimal: string) =
            {
                GrossAmountDecimal = grossAmountDecimal
            }

    type CreateForceCapture'PurchaseDetailsFleetReportedBreakdownNonFuel =
        {
            /// Gross non-fuel amount that should equal the sum of the line items, inclusive of taxes.
            [<Config.Form>]
            GrossAmountDecimal: string option
        }

    type CreateForceCapture'PurchaseDetailsFleetReportedBreakdownNonFuel with
        static member New(?grossAmountDecimal: string) =
            {
                GrossAmountDecimal = grossAmountDecimal
            }

    type CreateForceCapture'PurchaseDetailsFleetReportedBreakdownTax =
        {
            /// Amount of state or provincial Sales Tax included in the transaction amount. Null if not reported by merchant or not subject to tax.
            [<Config.Form>]
            LocalAmountDecimal: string option
            /// Amount of national Sales Tax or VAT included in the transaction amount. Null if not reported by merchant or not subject to tax.
            [<Config.Form>]
            NationalAmountDecimal: string option
        }

    type CreateForceCapture'PurchaseDetailsFleetReportedBreakdownTax with
        static member New(?localAmountDecimal: string, ?nationalAmountDecimal: string) =
            {
                LocalAmountDecimal = localAmountDecimal
                NationalAmountDecimal = nationalAmountDecimal
            }

    type CreateForceCapture'PurchaseDetailsFleetReportedBreakdown =
        {
            /// Breakdown of fuel portion of the purchase.
            [<Config.Form>]
            Fuel: CreateForceCapture'PurchaseDetailsFleetReportedBreakdownFuel option
            /// Breakdown of non-fuel portion of the purchase.
            [<Config.Form>]
            NonFuel: CreateForceCapture'PurchaseDetailsFleetReportedBreakdownNonFuel option
            /// Information about tax included in this transaction.
            [<Config.Form>]
            Tax: CreateForceCapture'PurchaseDetailsFleetReportedBreakdownTax option
        }

    type CreateForceCapture'PurchaseDetailsFleetReportedBreakdown with
        static member New(?fuel: CreateForceCapture'PurchaseDetailsFleetReportedBreakdownFuel, ?nonFuel: CreateForceCapture'PurchaseDetailsFleetReportedBreakdownNonFuel, ?tax: CreateForceCapture'PurchaseDetailsFleetReportedBreakdownTax) =
            {
                Fuel = fuel
                NonFuel = nonFuel
                Tax = tax
            }

    type CreateForceCapture'PurchaseDetailsFleetServiceType =
        | FullService
        | NonFuelTransaction
        | SelfService

    type CreateForceCapture'PurchaseDetailsFleet =
        {
            /// Answers to prompts presented to the cardholder at the point of sale. Prompted fields vary depending on the configuration of your physical fleet cards. Typical points of sale support only numeric entry.
            [<Config.Form>]
            CardholderPromptData: CreateForceCapture'PurchaseDetailsFleetCardholderPromptData option
            /// The type of purchase. One of `fuel_purchase`, `non_fuel_purchase`, or `fuel_and_non_fuel_purchase`.
            [<Config.Form>]
            PurchaseType: CreateForceCapture'PurchaseDetailsFleetPurchaseType option
            /// More information about the total amount. This information is not guaranteed to be accurate as some merchants may provide unreliable data.
            [<Config.Form>]
            ReportedBreakdown: CreateForceCapture'PurchaseDetailsFleetReportedBreakdown option
            /// The type of fuel service. One of `non_fuel_transaction`, `full_service`, or `self_service`.
            [<Config.Form>]
            ServiceType: CreateForceCapture'PurchaseDetailsFleetServiceType option
        }

    type CreateForceCapture'PurchaseDetailsFleet with
        static member New(?cardholderPromptData: CreateForceCapture'PurchaseDetailsFleetCardholderPromptData, ?purchaseType: CreateForceCapture'PurchaseDetailsFleetPurchaseType, ?reportedBreakdown: CreateForceCapture'PurchaseDetailsFleetReportedBreakdown, ?serviceType: CreateForceCapture'PurchaseDetailsFleetServiceType) =
            {
                CardholderPromptData = cardholderPromptData
                PurchaseType = purchaseType
                ReportedBreakdown = reportedBreakdown
                ServiceType = serviceType
            }

    type CreateForceCapture'PurchaseDetailsFlightSegments =
        {
            /// The three-letter IATA airport code of the flight's destination.
            [<Config.Form>]
            ArrivalAirportCode: string option
            /// The airline carrier code.
            [<Config.Form>]
            Carrier: string option
            /// The three-letter IATA airport code that the flight departed from.
            [<Config.Form>]
            DepartureAirportCode: string option
            /// The flight number.
            [<Config.Form>]
            FlightNumber: string option
            /// The flight's service class.
            [<Config.Form>]
            ServiceClass: string option
            /// Whether a stopover is allowed on this flight.
            [<Config.Form>]
            StopoverAllowed: bool option
        }

    type CreateForceCapture'PurchaseDetailsFlightSegments with
        static member New(?arrivalAirportCode: string, ?carrier: string, ?departureAirportCode: string, ?flightNumber: string, ?serviceClass: string, ?stopoverAllowed: bool) =
            {
                ArrivalAirportCode = arrivalAirportCode
                Carrier = carrier
                DepartureAirportCode = departureAirportCode
                FlightNumber = flightNumber
                ServiceClass = serviceClass
                StopoverAllowed = stopoverAllowed
            }

    type CreateForceCapture'PurchaseDetailsFlight =
        {
            /// The time that the flight departed.
            [<Config.Form>]
            DepartureAt: DateTime option
            /// The name of the passenger.
            [<Config.Form>]
            PassengerName: string option
            /// Whether the ticket is refundable.
            [<Config.Form>]
            Refundable: bool option
            /// The legs of the trip.
            [<Config.Form>]
            Segments: CreateForceCapture'PurchaseDetailsFlightSegments list option
            /// The travel agency that issued the ticket.
            [<Config.Form>]
            TravelAgency: string option
        }

    type CreateForceCapture'PurchaseDetailsFlight with
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

    type CreateForceCapture'PurchaseDetailsFuel =
        {
            /// [Conexxus Payment System Product Code](https://www.conexxus.org/conexxus-payment-system-product-codes) identifying the primary fuel product purchased.
            [<Config.Form>]
            IndustryProductCode: string option
            /// The quantity of `unit`s of fuel that was dispensed, represented as a decimal string with at most 12 decimal places.
            [<Config.Form>]
            QuantityDecimal: string option
            /// The type of fuel that was purchased. One of `diesel`, `unleaded_plus`, `unleaded_regular`, `unleaded_super`, or `other`.
            [<Config.Form>]
            Type: CreateForceCapture'PurchaseDetailsFuelType option
            /// The units for `quantity_decimal`. One of `charging_minute`, `imperial_gallon`, `kilogram`, `kilowatt_hour`, `liter`, `pound`, `us_gallon`, or `other`.
            [<Config.Form>]
            Unit: CreateForceCapture'PurchaseDetailsFuelUnit option
            /// The cost in cents per each unit of fuel, represented as a decimal string with at most 12 decimal places.
            [<Config.Form>]
            UnitCostDecimal: string option
        }

    type CreateForceCapture'PurchaseDetailsFuel with
        static member New(?industryProductCode: string, ?quantityDecimal: string, ?type': CreateForceCapture'PurchaseDetailsFuelType, ?unit: CreateForceCapture'PurchaseDetailsFuelUnit, ?unitCostDecimal: string) =
            {
                IndustryProductCode = industryProductCode
                QuantityDecimal = quantityDecimal
                Type = type'
                Unit = unit
                UnitCostDecimal = unitCostDecimal
            }

    type CreateForceCapture'PurchaseDetailsLodging =
        {
            /// The time of checking into the lodging.
            [<Config.Form>]
            CheckInAt: DateTime option
            /// The number of nights stayed at the lodging.
            [<Config.Form>]
            Nights: int option
        }

    type CreateForceCapture'PurchaseDetailsLodging with
        static member New(?checkInAt: DateTime, ?nights: int) =
            {
                CheckInAt = checkInAt
                Nights = nights
            }

    type CreateForceCapture'PurchaseDetailsReceipt =
        { [<Config.Form>]
          Description: string option
          [<Config.Form>]
          Quantity: string option
          [<Config.Form>]
          Total: int option
          [<Config.Form>]
          UnitCost: int option }

    type CreateForceCapture'PurchaseDetailsReceipt with
        static member New(?description: string, ?quantity: string, ?total: int, ?unitCost: int) =
            {
                Description = description
                Quantity = quantity
                Total = total
                UnitCost = unitCost
            }

    type CreateForceCapture'PurchaseDetails =
        {
            /// Fleet-specific information for transactions using Fleet cards.
            [<Config.Form>]
            Fleet: CreateForceCapture'PurchaseDetailsFleet option
            /// Information about the flight that was purchased with this transaction.
            [<Config.Form>]
            Flight: CreateForceCapture'PurchaseDetailsFlight option
            /// Information about fuel that was purchased with this transaction.
            [<Config.Form>]
            Fuel: CreateForceCapture'PurchaseDetailsFuel option
            /// Information about lodging that was purchased with this transaction.
            [<Config.Form>]
            Lodging: CreateForceCapture'PurchaseDetailsLodging option
            /// The line items in the purchase.
            [<Config.Form>]
            Receipt: CreateForceCapture'PurchaseDetailsReceipt list option
            /// A merchant-specific order number.
            [<Config.Form>]
            Reference: string option
        }

    type CreateForceCapture'PurchaseDetails with
        static member New(?fleet: CreateForceCapture'PurchaseDetailsFleet, ?flight: CreateForceCapture'PurchaseDetailsFlight, ?fuel: CreateForceCapture'PurchaseDetailsFuel, ?lodging: CreateForceCapture'PurchaseDetailsLodging, ?receipt: CreateForceCapture'PurchaseDetailsReceipt list, ?reference: string) =
            {
                Fleet = fleet
                Flight = flight
                Fuel = fuel
                Lodging = lodging
                Receipt = receipt
                Reference = reference
            }

    type CreateForceCaptureOptions =
        {
            /// The total amount to attempt to capture. This amount is in the provided currency, or defaults to the cards currency, and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).
            [<Config.Form>]
            Amount: int
            /// Card associated with this transaction.
            [<Config.Form>]
            Card: string
            /// The currency of the capture. If not provided, defaults to the currency of the card. Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Details about the seller (grocery store, e-commerce website, etc.) where the card authorization happened.
            [<Config.Form>]
            MerchantData: CreateForceCapture'MerchantData option
            /// Additional purchase information that is optionally provided by the merchant.
            [<Config.Form>]
            PurchaseDetails: CreateForceCapture'PurchaseDetails option
        }

    type CreateForceCaptureOptions with
        static member New(amount: int, card: string, ?currency: IsoTypes.IsoCurrencyCode, ?expand: string list, ?merchantData: CreateForceCapture'MerchantData, ?purchaseDetails: CreateForceCapture'PurchaseDetails) =
            {
                Amount = amount
                Card = card
                Currency = currency
                Expand = expand
                MerchantData = merchantData
                PurchaseDetails = purchaseDetails
            }

    ///<p>Allows the user to capture an arbitrary amount, also known as a forced capture.</p>
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

    type CreateUnlinkedRefund'MerchantData =
        {
            /// A categorization of the seller's type of business. See our [merchant categories guide](https://docs.stripe.com/issuing/merchant-categories) for a list of possible values.
            [<Config.Form>]
            Category: CreateUnlinkedRefund'MerchantDataCategory option
            /// City where the seller is located
            [<Config.Form>]
            City: string option
            /// Country where the seller is located
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Name of the seller
            [<Config.Form>]
            Name: string option
            /// Identifier assigned to the seller by the card network. Different card networks may assign different network_id fields to the same merchant.
            [<Config.Form>]
            NetworkId: string option
            /// Postal code where the seller is located
            [<Config.Form>]
            PostalCode: string option
            /// State where the seller is located
            [<Config.Form>]
            State: string option
            /// An ID assigned by the seller to the location of the sale.
            [<Config.Form>]
            TerminalId: string option
            /// URL provided by the merchant on a 3DS request
            [<Config.Form>]
            Url: string option
        }

    type CreateUnlinkedRefund'MerchantData with
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

    type CreateUnlinkedRefund'PurchaseDetailsFleetCardholderPromptData =
        {
            /// Driver ID.
            [<Config.Form>]
            DriverId: string option
            /// Odometer reading.
            [<Config.Form>]
            Odometer: int option
            /// An alphanumeric ID. This field is used when a vehicle ID, driver ID, or generic ID is entered by the cardholder, but the merchant or card network did not specify the prompt type.
            [<Config.Form>]
            UnspecifiedId: string option
            /// User ID.
            [<Config.Form>]
            UserId: string option
            /// Vehicle number.
            [<Config.Form>]
            VehicleNumber: string option
        }

    type CreateUnlinkedRefund'PurchaseDetailsFleetCardholderPromptData with
        static member New(?driverId: string, ?odometer: int, ?unspecifiedId: string, ?userId: string, ?vehicleNumber: string) =
            {
                DriverId = driverId
                Odometer = odometer
                UnspecifiedId = unspecifiedId
                UserId = userId
                VehicleNumber = vehicleNumber
            }

    type CreateUnlinkedRefund'PurchaseDetailsFleetPurchaseType =
        | FuelAndNonFuelPurchase
        | FuelPurchase
        | NonFuelPurchase

    type CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdownFuel =
        {
            /// Gross fuel amount that should equal Fuel Volume multipled by Fuel Unit Cost, inclusive of taxes.
            [<Config.Form>]
            GrossAmountDecimal: string option
        }

    type CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdownFuel with
        static member New(?grossAmountDecimal: string) =
            {
                GrossAmountDecimal = grossAmountDecimal
            }

    type CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdownNonFuel =
        {
            /// Gross non-fuel amount that should equal the sum of the line items, inclusive of taxes.
            [<Config.Form>]
            GrossAmountDecimal: string option
        }

    type CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdownNonFuel with
        static member New(?grossAmountDecimal: string) =
            {
                GrossAmountDecimal = grossAmountDecimal
            }

    type CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdownTax =
        {
            /// Amount of state or provincial Sales Tax included in the transaction amount. Null if not reported by merchant or not subject to tax.
            [<Config.Form>]
            LocalAmountDecimal: string option
            /// Amount of national Sales Tax or VAT included in the transaction amount. Null if not reported by merchant or not subject to tax.
            [<Config.Form>]
            NationalAmountDecimal: string option
        }

    type CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdownTax with
        static member New(?localAmountDecimal: string, ?nationalAmountDecimal: string) =
            {
                LocalAmountDecimal = localAmountDecimal
                NationalAmountDecimal = nationalAmountDecimal
            }

    type CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdown =
        {
            /// Breakdown of fuel portion of the purchase.
            [<Config.Form>]
            Fuel: CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdownFuel option
            /// Breakdown of non-fuel portion of the purchase.
            [<Config.Form>]
            NonFuel: CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdownNonFuel option
            /// Information about tax included in this transaction.
            [<Config.Form>]
            Tax: CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdownTax option
        }

    type CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdown with
        static member New(?fuel: CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdownFuel, ?nonFuel: CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdownNonFuel, ?tax: CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdownTax) =
            {
                Fuel = fuel
                NonFuel = nonFuel
                Tax = tax
            }

    type CreateUnlinkedRefund'PurchaseDetailsFleetServiceType =
        | FullService
        | NonFuelTransaction
        | SelfService

    type CreateUnlinkedRefund'PurchaseDetailsFleet =
        {
            /// Answers to prompts presented to the cardholder at the point of sale. Prompted fields vary depending on the configuration of your physical fleet cards. Typical points of sale support only numeric entry.
            [<Config.Form>]
            CardholderPromptData: CreateUnlinkedRefund'PurchaseDetailsFleetCardholderPromptData option
            /// The type of purchase. One of `fuel_purchase`, `non_fuel_purchase`, or `fuel_and_non_fuel_purchase`.
            [<Config.Form>]
            PurchaseType: CreateUnlinkedRefund'PurchaseDetailsFleetPurchaseType option
            /// More information about the total amount. This information is not guaranteed to be accurate as some merchants may provide unreliable data.
            [<Config.Form>]
            ReportedBreakdown: CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdown option
            /// The type of fuel service. One of `non_fuel_transaction`, `full_service`, or `self_service`.
            [<Config.Form>]
            ServiceType: CreateUnlinkedRefund'PurchaseDetailsFleetServiceType option
        }

    type CreateUnlinkedRefund'PurchaseDetailsFleet with
        static member New(?cardholderPromptData: CreateUnlinkedRefund'PurchaseDetailsFleetCardholderPromptData, ?purchaseType: CreateUnlinkedRefund'PurchaseDetailsFleetPurchaseType, ?reportedBreakdown: CreateUnlinkedRefund'PurchaseDetailsFleetReportedBreakdown, ?serviceType: CreateUnlinkedRefund'PurchaseDetailsFleetServiceType) =
            {
                CardholderPromptData = cardholderPromptData
                PurchaseType = purchaseType
                ReportedBreakdown = reportedBreakdown
                ServiceType = serviceType
            }

    type CreateUnlinkedRefund'PurchaseDetailsFlightSegments =
        {
            /// The three-letter IATA airport code of the flight's destination.
            [<Config.Form>]
            ArrivalAirportCode: string option
            /// The airline carrier code.
            [<Config.Form>]
            Carrier: string option
            /// The three-letter IATA airport code that the flight departed from.
            [<Config.Form>]
            DepartureAirportCode: string option
            /// The flight number.
            [<Config.Form>]
            FlightNumber: string option
            /// The flight's service class.
            [<Config.Form>]
            ServiceClass: string option
            /// Whether a stopover is allowed on this flight.
            [<Config.Form>]
            StopoverAllowed: bool option
        }

    type CreateUnlinkedRefund'PurchaseDetailsFlightSegments with
        static member New(?arrivalAirportCode: string, ?carrier: string, ?departureAirportCode: string, ?flightNumber: string, ?serviceClass: string, ?stopoverAllowed: bool) =
            {
                ArrivalAirportCode = arrivalAirportCode
                Carrier = carrier
                DepartureAirportCode = departureAirportCode
                FlightNumber = flightNumber
                ServiceClass = serviceClass
                StopoverAllowed = stopoverAllowed
            }

    type CreateUnlinkedRefund'PurchaseDetailsFlight =
        {
            /// The time that the flight departed.
            [<Config.Form>]
            DepartureAt: DateTime option
            /// The name of the passenger.
            [<Config.Form>]
            PassengerName: string option
            /// Whether the ticket is refundable.
            [<Config.Form>]
            Refundable: bool option
            /// The legs of the trip.
            [<Config.Form>]
            Segments: CreateUnlinkedRefund'PurchaseDetailsFlightSegments list option
            /// The travel agency that issued the ticket.
            [<Config.Form>]
            TravelAgency: string option
        }

    type CreateUnlinkedRefund'PurchaseDetailsFlight with
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

    type CreateUnlinkedRefund'PurchaseDetailsFuel =
        {
            /// [Conexxus Payment System Product Code](https://www.conexxus.org/conexxus-payment-system-product-codes) identifying the primary fuel product purchased.
            [<Config.Form>]
            IndustryProductCode: string option
            /// The quantity of `unit`s of fuel that was dispensed, represented as a decimal string with at most 12 decimal places.
            [<Config.Form>]
            QuantityDecimal: string option
            /// The type of fuel that was purchased. One of `diesel`, `unleaded_plus`, `unleaded_regular`, `unleaded_super`, or `other`.
            [<Config.Form>]
            Type: CreateUnlinkedRefund'PurchaseDetailsFuelType option
            /// The units for `quantity_decimal`. One of `charging_minute`, `imperial_gallon`, `kilogram`, `kilowatt_hour`, `liter`, `pound`, `us_gallon`, or `other`.
            [<Config.Form>]
            Unit: CreateUnlinkedRefund'PurchaseDetailsFuelUnit option
            /// The cost in cents per each unit of fuel, represented as a decimal string with at most 12 decimal places.
            [<Config.Form>]
            UnitCostDecimal: string option
        }

    type CreateUnlinkedRefund'PurchaseDetailsFuel with
        static member New(?industryProductCode: string, ?quantityDecimal: string, ?type': CreateUnlinkedRefund'PurchaseDetailsFuelType, ?unit: CreateUnlinkedRefund'PurchaseDetailsFuelUnit, ?unitCostDecimal: string) =
            {
                IndustryProductCode = industryProductCode
                QuantityDecimal = quantityDecimal
                Type = type'
                Unit = unit
                UnitCostDecimal = unitCostDecimal
            }

    type CreateUnlinkedRefund'PurchaseDetailsLodging =
        {
            /// The time of checking into the lodging.
            [<Config.Form>]
            CheckInAt: DateTime option
            /// The number of nights stayed at the lodging.
            [<Config.Form>]
            Nights: int option
        }

    type CreateUnlinkedRefund'PurchaseDetailsLodging with
        static member New(?checkInAt: DateTime, ?nights: int) =
            {
                CheckInAt = checkInAt
                Nights = nights
            }

    type CreateUnlinkedRefund'PurchaseDetailsReceipt =
        { [<Config.Form>]
          Description: string option
          [<Config.Form>]
          Quantity: string option
          [<Config.Form>]
          Total: int option
          [<Config.Form>]
          UnitCost: int option }

    type CreateUnlinkedRefund'PurchaseDetailsReceipt with
        static member New(?description: string, ?quantity: string, ?total: int, ?unitCost: int) =
            {
                Description = description
                Quantity = quantity
                Total = total
                UnitCost = unitCost
            }

    type CreateUnlinkedRefund'PurchaseDetails =
        {
            /// Fleet-specific information for transactions using Fleet cards.
            [<Config.Form>]
            Fleet: CreateUnlinkedRefund'PurchaseDetailsFleet option
            /// Information about the flight that was purchased with this transaction.
            [<Config.Form>]
            Flight: CreateUnlinkedRefund'PurchaseDetailsFlight option
            /// Information about fuel that was purchased with this transaction.
            [<Config.Form>]
            Fuel: CreateUnlinkedRefund'PurchaseDetailsFuel option
            /// Information about lodging that was purchased with this transaction.
            [<Config.Form>]
            Lodging: CreateUnlinkedRefund'PurchaseDetailsLodging option
            /// The line items in the purchase.
            [<Config.Form>]
            Receipt: CreateUnlinkedRefund'PurchaseDetailsReceipt list option
            /// A merchant-specific order number.
            [<Config.Form>]
            Reference: string option
        }

    type CreateUnlinkedRefund'PurchaseDetails with
        static member New(?fleet: CreateUnlinkedRefund'PurchaseDetailsFleet, ?flight: CreateUnlinkedRefund'PurchaseDetailsFlight, ?fuel: CreateUnlinkedRefund'PurchaseDetailsFuel, ?lodging: CreateUnlinkedRefund'PurchaseDetailsLodging, ?receipt: CreateUnlinkedRefund'PurchaseDetailsReceipt list, ?reference: string) =
            {
                Fleet = fleet
                Flight = flight
                Fuel = fuel
                Lodging = lodging
                Receipt = receipt
                Reference = reference
            }

    type CreateUnlinkedRefundOptions =
        {
            /// The total amount to attempt to refund. This amount is in the provided currency, or defaults to the cards currency, and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).
            [<Config.Form>]
            Amount: int
            /// Card associated with this unlinked refund transaction.
            [<Config.Form>]
            Card: string
            /// The currency of the unlinked refund. If not provided, defaults to the currency of the card. Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Details about the seller (grocery store, e-commerce website, etc.) where the card authorization happened.
            [<Config.Form>]
            MerchantData: CreateUnlinkedRefund'MerchantData option
            /// Additional purchase information that is optionally provided by the merchant.
            [<Config.Form>]
            PurchaseDetails: CreateUnlinkedRefund'PurchaseDetails option
        }

    type CreateUnlinkedRefundOptions with
        static member New(amount: int, card: string, ?currency: IsoTypes.IsoCurrencyCode, ?expand: string list, ?merchantData: CreateUnlinkedRefund'MerchantData, ?purchaseDetails: CreateUnlinkedRefund'PurchaseDetails) =
            {
                Amount = amount
                Card = card
                Currency = currency
                Expand = expand
                MerchantData = merchantData
                PurchaseDetails = purchaseDetails
            }

    ///<p>Allows the user to refund an arbitrary amount, also known as a unlinked refund.</p>
    let CreateUnlinkedRefund settings (options: CreateUnlinkedRefundOptions) =
        $"/v1/test_helpers/issuing/transactions/create_unlinked_refund"
        |> RestApi.postAsync<_, IssuingTransaction> settings (Map.empty) options

module TestHelpersIssuingTransactionsRefund =

    type RefundOptions =
        {
            [<Config.Path>]
            Transaction: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The total amount to attempt to refund. This amount is in the provided currency, or defaults to the cards currency, and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).
            [<Config.Form>]
            RefundAmount: int option
        }

    type RefundOptions with
        static member New(transaction: string, ?expand: string list, ?refundAmount: int) =
            {
                Transaction = transaction
                Expand = expand
                RefundAmount = refundAmount
            }

    ///<p>Refund a test-mode Transaction.</p>
    let Refund settings (options: RefundOptions) =
        $"/v1/test_helpers/issuing/transactions/{options.Transaction}/refund"
        |> RestApi.postAsync<_, IssuingTransaction> settings (Map.empty) options

module TestHelpersRefundsExpire =

    type ExpireOptions =
        {
            [<Config.Path>]
            Refund: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type ExpireOptions with
        static member New(refund: string, ?expand: string list) =
            {
                Refund = refund
                Expand = expand
            }

    ///<p>Expire a refund with a status of <code>requires_action</code>.</p>
    let Expire settings (options: ExpireOptions) =
        $"/v1/test_helpers/refunds/{options.Refund}/expire"
        |> RestApi.postAsync<_, Refund> settings (Map.empty) options

module TestHelpersTerminalReadersPresentPaymentMethod =

    type PresentPaymentMethod'Card =
        {
            /// Card security code.
            [<Config.Form>]
            Cvc: string option
            /// Two-digit number representing the card's expiration month.
            [<Config.Form>]
            ExpMonth: int option
            /// Two- or four-digit number representing the card's expiration year.
            [<Config.Form>]
            ExpYear: int option
            /// The card number, as a string without any separators.
            [<Config.Form>]
            Number: string option
        }

    type PresentPaymentMethod'Card with
        static member New(?cvc: string, ?expMonth: int, ?expYear: int, ?number: string) =
            {
                Cvc = cvc
                ExpMonth = expMonth
                ExpYear = expYear
                Number = number
            }

    type PresentPaymentMethod'CardPresent =
        {
            /// The card number, as a string without any separators.
            [<Config.Form>]
            Number: string option
        }

    type PresentPaymentMethod'CardPresent with
        static member New(?number: string) =
            {
                Number = number
            }

    type PresentPaymentMethod'InteracPresent =
        {
            /// The Interac card number.
            [<Config.Form>]
            Number: string option
        }

    type PresentPaymentMethod'InteracPresent with
        static member New(?number: string) =
            {
                Number = number
            }

    type PresentPaymentMethod'Type =
        | Card
        | CardPresent
        | InteracPresent

    type PresentPaymentMethodOptions =
        {
            [<Config.Path>]
            Reader: string
            /// Simulated on-reader tip amount.
            [<Config.Form>]
            AmountTip: int option
            /// Simulated data for the card payment method.
            [<Config.Form>]
            Card: PresentPaymentMethod'Card option
            /// Simulated data for the card_present payment method.
            [<Config.Form>]
            CardPresent: PresentPaymentMethod'CardPresent option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Simulated data for the interac_present payment method.
            [<Config.Form>]
            InteracPresent: PresentPaymentMethod'InteracPresent option
            /// Simulated payment type.
            [<Config.Form>]
            Type: PresentPaymentMethod'Type option
        }

    type PresentPaymentMethodOptions with
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

    ///<p>Presents a payment method on a simulated reader. Can be used to simulate accepting a payment, saving a card or refunding a transaction.</p>
    let PresentPaymentMethod settings (options: PresentPaymentMethodOptions) =
        $"/v1/test_helpers/terminal/readers/{options.Reader}/present_payment_method"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TestHelpersTerminalReadersSucceedInputCollection =

    type SucceedInputCollection'SkipNonRequiredInputs =
        | All
        | [<JsonPropertyName("none")>] None'

    type SucceedInputCollectionOptions =
        {
            [<Config.Path>]
            Reader: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// This parameter defines the skip behavior for input collection.
            [<Config.Form>]
            SkipNonRequiredInputs: SucceedInputCollection'SkipNonRequiredInputs option
        }

    type SucceedInputCollectionOptions with
        static member New(reader: string, ?expand: string list, ?skipNonRequiredInputs: SucceedInputCollection'SkipNonRequiredInputs) =
            {
                Reader = reader
                Expand = expand
                SkipNonRequiredInputs = skipNonRequiredInputs
            }

    ///<p>Use this endpoint to trigger a successful input collection on a simulated reader.</p>
    let SucceedInputCollection settings (options: SucceedInputCollectionOptions) =
        $"/v1/test_helpers/terminal/readers/{options.Reader}/succeed_input_collection"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TestHelpersTerminalReadersTimeoutInputCollection =

    type TimeoutInputCollectionOptions =
        {
            [<Config.Path>]
            Reader: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type TimeoutInputCollectionOptions with
        static member New(reader: string, ?expand: string list) =
            {
                Reader = reader
                Expand = expand
            }

    ///<p>Use this endpoint to complete an input collection with a timeout error on a simulated reader.</p>
    let TimeoutInputCollection settings (options: TimeoutInputCollectionOptions) =
        $"/v1/test_helpers/terminal/readers/{options.Reader}/timeout_input_collection"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TestHelpersTestClocks =

    type ListOptions =
        {
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
        static member New(?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    type CreateOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The initial frozen time for this test clock.
            [<Config.Form>]
            FrozenTime: DateTime
            /// The name for this test clock.
            [<Config.Form>]
            Name: string option
        }

    type CreateOptions with
        static member New(frozenTime: DateTime, ?expand: string list, ?name: string) =
            {
                FrozenTime = frozenTime
                Expand = expand
                Name = name
            }

    type DeleteOptions =
        { [<Config.Path>]
          TestClock: string }

    type DeleteOptions with
        static member New(testClock: string) =
            {
                TestClock = testClock
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            TestClock: string
        }

    type RetrieveOptions with
        static member New(testClock: string, ?expand: string list) =
            {
                TestClock = testClock
                Expand = expand
            }

    ///<p>Returns a list of your test clocks.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/test_helpers/test_clocks"
        |> RestApi.getAsync<StripeList<TestHelpersTestClock>> settings qs

    ///<p>Creates a new test clock that can be attached to new customers and quotes.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/test_helpers/test_clocks"
        |> RestApi.postAsync<_, TestHelpersTestClock> settings (Map.empty) options

    ///<p>Deletes a test clock.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/test_helpers/test_clocks/{options.TestClock}"
        |> RestApi.deleteAsync<DeletedTestHelpersTestClock> settings (Map.empty)

    ///<p>Retrieves a test clock.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/test_helpers/test_clocks/{options.TestClock}"
        |> RestApi.getAsync<TestHelpersTestClock> settings qs

module TestHelpersTestClocksAdvance =

    type AdvanceOptions =
        {
            [<Config.Path>]
            TestClock: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The time to advance the test clock. Must be after the test clock's current frozen time. Cannot be more than two intervals in the future from the shortest subscription in this test clock. If there are no subscriptions in this test clock, it cannot be more than two years in the future.
            [<Config.Form>]
            FrozenTime: DateTime
        }

    type AdvanceOptions with
        static member New(frozenTime: DateTime, testClock: string, ?expand: string list) =
            {
                FrozenTime = frozenTime
                TestClock = testClock
                Expand = expand
            }

    ///<p>Starts advancing a test clock to a specified time in the future. Advancement is done when status changes to <code>Ready</code>.</p>
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

    type Fail'FailureDetails =
        {
            /// Reason for the failure.
            [<Config.Form>]
            Code: Fail'FailureDetailsCode option
        }

    type Fail'FailureDetails with
        static member New(?code: Fail'FailureDetailsCode) =
            {
                Code = code
            }

    type FailOptions =
        {
            [<Config.Path>]
            Id: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Details about a failed InboundTransfer.
            [<Config.Form>]
            FailureDetails: Fail'FailureDetails option
        }

    type FailOptions with
        static member New(id: string, ?expand: string list, ?failureDetails: Fail'FailureDetails) =
            {
                Id = id
                Expand = expand
                FailureDetails = failureDetails
            }

    ///<p>Transitions a test mode created InboundTransfer to the <code>failed</code> status. The InboundTransfer must already be in the <code>processing</code> state.</p>
    let Fail settings (options: FailOptions) =
        $"/v1/test_helpers/treasury/inbound_transfers/{options.Id}/fail"
        |> RestApi.postAsync<_, TreasuryInboundTransfer> settings (Map.empty) options

module TestHelpersTreasuryInboundTransfersReturn =

    type ReturnInboundTransferOptions =
        {
            [<Config.Path>]
            Id: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type ReturnInboundTransferOptions with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    ///<p>Marks the test mode InboundTransfer object as returned and links the InboundTransfer to a ReceivedDebit. The InboundTransfer must already be in the <code>succeeded</code> state.</p>
    let ReturnInboundTransfer settings (options: ReturnInboundTransferOptions) =
        $"/v1/test_helpers/treasury/inbound_transfers/{options.Id}/return"
        |> RestApi.postAsync<_, TreasuryInboundTransfer> settings (Map.empty) options

module TestHelpersTreasuryInboundTransfersSucceed =

    type SucceedOptions =
        {
            [<Config.Path>]
            Id: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type SucceedOptions with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    ///<p>Transitions a test mode created InboundTransfer to the <code>succeeded</code> status. The InboundTransfer must already be in the <code>processing</code> state.</p>
    let Succeed settings (options: SucceedOptions) =
        $"/v1/test_helpers/treasury/inbound_transfers/{options.Id}/succeed"
        |> RestApi.postAsync<_, TreasuryInboundTransfer> settings (Map.empty) options

module TestHelpersTreasuryOutboundPayments =

    type Update'TrackingDetailsAch =
        {
            /// ACH trace ID for funds sent over the `ach` network.
            [<Config.Form>]
            TraceId: string option
        }

    type Update'TrackingDetailsAch with
        static member New(?traceId: string) =
            {
                TraceId = traceId
            }

    type Update'TrackingDetailsType =
        | Ach
        | UsDomesticWire

    type Update'TrackingDetailsUsDomesticWire =
        {
            /// CHIPS System Sequence Number (SSN) for funds sent over the `us_domestic_wire` network.
            [<Config.Form>]
            Chips: string option
            /// IMAD for funds sent over the `us_domestic_wire` network.
            [<Config.Form>]
            Imad: string option
            /// OMAD for funds sent over the `us_domestic_wire` network.
            [<Config.Form>]
            Omad: string option
        }

    type Update'TrackingDetailsUsDomesticWire with
        static member New(?chips: string, ?imad: string, ?omad: string) =
            {
                Chips = chips
                Imad = imad
                Omad = omad
            }

    type Update'TrackingDetails =
        {
            /// ACH network tracking details.
            [<Config.Form>]
            Ach: Update'TrackingDetailsAch option
            /// The US bank account network used to send funds.
            [<Config.Form>]
            Type: Update'TrackingDetailsType option
            /// US domestic wire network tracking details.
            [<Config.Form>]
            UsDomesticWire: Update'TrackingDetailsUsDomesticWire option
        }

    type Update'TrackingDetails with
        static member New(?ach: Update'TrackingDetailsAch, ?type': Update'TrackingDetailsType, ?usDomesticWire: Update'TrackingDetailsUsDomesticWire) =
            {
                Ach = ach
                Type = type'
                UsDomesticWire = usDomesticWire
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Id: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Details about network-specific tracking information.
            [<Config.Form>]
            TrackingDetails: Update'TrackingDetails
        }

    type UpdateOptions with
        static member New(id: string, trackingDetails: Update'TrackingDetails, ?expand: string list) =
            {
                Id = id
                TrackingDetails = trackingDetails
                Expand = expand
            }

    ///<p>Updates a test mode created OutboundPayment with tracking details. The OutboundPayment must not be cancelable, and cannot be in the <code>canceled</code> or <code>failed</code> states.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/test_helpers/treasury/outbound_payments/{options.Id}"
        |> RestApi.postAsync<_, TreasuryOutboundPayment> settings (Map.empty) options

module TestHelpersTreasuryOutboundPaymentsFail =

    type FailOptions =
        {
            [<Config.Path>]
            Id: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type FailOptions with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    ///<p>Transitions a test mode created OutboundPayment to the <code>failed</code> status. The OutboundPayment must already be in the <code>processing</code> state.</p>
    let Fail settings (options: FailOptions) =
        $"/v1/test_helpers/treasury/outbound_payments/{options.Id}/fail"
        |> RestApi.postAsync<_, TreasuryOutboundPayment> settings (Map.empty) options

module TestHelpersTreasuryOutboundPaymentsPost =

    type PostOptions =
        {
            [<Config.Path>]
            Id: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type PostOptions with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    ///<p>Transitions a test mode created OutboundPayment to the <code>posted</code> status. The OutboundPayment must already be in the <code>processing</code> state.</p>
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

    type ReturnOutboundPayment'ReturnedDetails =
        {
            /// The return code to be set on the OutboundPayment object.
            [<Config.Form>]
            Code: ReturnOutboundPayment'ReturnedDetailsCode option
        }

    type ReturnOutboundPayment'ReturnedDetails with
        static member New(?code: ReturnOutboundPayment'ReturnedDetailsCode) =
            {
                Code = code
            }

    type ReturnOutboundPaymentOptions =
        {
            [<Config.Path>]
            Id: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Optional hash to set the return code.
            [<Config.Form>]
            ReturnedDetails: ReturnOutboundPayment'ReturnedDetails option
        }

    type ReturnOutboundPaymentOptions with
        static member New(id: string, ?expand: string list, ?returnedDetails: ReturnOutboundPayment'ReturnedDetails) =
            {
                Id = id
                Expand = expand
                ReturnedDetails = returnedDetails
            }

    ///<p>Transitions a test mode created OutboundPayment to the <code>returned</code> status. The OutboundPayment must already be in the <code>processing</code> state.</p>
    let ReturnOutboundPayment settings (options: ReturnOutboundPaymentOptions) =
        $"/v1/test_helpers/treasury/outbound_payments/{options.Id}/return"
        |> RestApi.postAsync<_, TreasuryOutboundPayment> settings (Map.empty) options

module TestHelpersTreasuryOutboundTransfers =

    type Update'TrackingDetailsAch =
        {
            /// ACH trace ID for funds sent over the `ach` network.
            [<Config.Form>]
            TraceId: string option
        }

    type Update'TrackingDetailsAch with
        static member New(?traceId: string) =
            {
                TraceId = traceId
            }

    type Update'TrackingDetailsType =
        | Ach
        | UsDomesticWire

    type Update'TrackingDetailsUsDomesticWire =
        {
            /// CHIPS System Sequence Number (SSN) for funds sent over the `us_domestic_wire` network.
            [<Config.Form>]
            Chips: string option
            /// IMAD for funds sent over the `us_domestic_wire` network.
            [<Config.Form>]
            Imad: string option
            /// OMAD for funds sent over the `us_domestic_wire` network.
            [<Config.Form>]
            Omad: string option
        }

    type Update'TrackingDetailsUsDomesticWire with
        static member New(?chips: string, ?imad: string, ?omad: string) =
            {
                Chips = chips
                Imad = imad
                Omad = omad
            }

    type Update'TrackingDetails =
        {
            /// ACH network tracking details.
            [<Config.Form>]
            Ach: Update'TrackingDetailsAch option
            /// The US bank account network used to send funds.
            [<Config.Form>]
            Type: Update'TrackingDetailsType option
            /// US domestic wire network tracking details.
            [<Config.Form>]
            UsDomesticWire: Update'TrackingDetailsUsDomesticWire option
        }

    type Update'TrackingDetails with
        static member New(?ach: Update'TrackingDetailsAch, ?type': Update'TrackingDetailsType, ?usDomesticWire: Update'TrackingDetailsUsDomesticWire) =
            {
                Ach = ach
                Type = type'
                UsDomesticWire = usDomesticWire
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            OutboundTransfer: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Details about network-specific tracking information.
            [<Config.Form>]
            TrackingDetails: Update'TrackingDetails
        }

    type UpdateOptions with
        static member New(outboundTransfer: string, trackingDetails: Update'TrackingDetails, ?expand: string list) =
            {
                OutboundTransfer = outboundTransfer
                TrackingDetails = trackingDetails
                Expand = expand
            }

    ///<p>Updates a test mode created OutboundTransfer with tracking details. The OutboundTransfer must not be cancelable, and cannot be in the <code>canceled</code> or <code>failed</code> states.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/test_helpers/treasury/outbound_transfers/{options.OutboundTransfer}"
        |> RestApi.postAsync<_, TreasuryOutboundTransfer> settings (Map.empty) options

module TestHelpersTreasuryOutboundTransfersFail =

    type FailOptions =
        {
            [<Config.Path>]
            OutboundTransfer: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type FailOptions with
        static member New(outboundTransfer: string, ?expand: string list) =
            {
                OutboundTransfer = outboundTransfer
                Expand = expand
            }

    ///<p>Transitions a test mode created OutboundTransfer to the <code>failed</code> status. The OutboundTransfer must already be in the <code>processing</code> state.</p>
    let Fail settings (options: FailOptions) =
        $"/v1/test_helpers/treasury/outbound_transfers/{options.OutboundTransfer}/fail"
        |> RestApi.postAsync<_, TreasuryOutboundTransfer> settings (Map.empty) options

module TestHelpersTreasuryOutboundTransfersPost =

    type PostOptions =
        {
            [<Config.Path>]
            OutboundTransfer: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type PostOptions with
        static member New(outboundTransfer: string, ?expand: string list) =
            {
                OutboundTransfer = outboundTransfer
                Expand = expand
            }

    ///<p>Transitions a test mode created OutboundTransfer to the <code>posted</code> status. The OutboundTransfer must already be in the <code>processing</code> state.</p>
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

    type ReturnOutboundTransfer'ReturnedDetails =
        {
            /// Reason for the return.
            [<Config.Form>]
            Code: ReturnOutboundTransfer'ReturnedDetailsCode option
        }

    type ReturnOutboundTransfer'ReturnedDetails with
        static member New(?code: ReturnOutboundTransfer'ReturnedDetailsCode) =
            {
                Code = code
            }

    type ReturnOutboundTransferOptions =
        {
            [<Config.Path>]
            OutboundTransfer: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Details about a returned OutboundTransfer.
            [<Config.Form>]
            ReturnedDetails: ReturnOutboundTransfer'ReturnedDetails option
        }

    type ReturnOutboundTransferOptions with
        static member New(outboundTransfer: string, ?expand: string list, ?returnedDetails: ReturnOutboundTransfer'ReturnedDetails) =
            {
                OutboundTransfer = outboundTransfer
                Expand = expand
                ReturnedDetails = returnedDetails
            }

    ///<p>Transitions a test mode created OutboundTransfer to the <code>returned</code> status. The OutboundTransfer must already be in the <code>processing</code> state.</p>
    let ReturnOutboundTransfer settings (options: ReturnOutboundTransferOptions) =
        $"/v1/test_helpers/treasury/outbound_transfers/{options.OutboundTransfer}/return"
        |> RestApi.postAsync<_, TreasuryOutboundTransfer> settings (Map.empty) options

module TestHelpersTreasuryReceivedCredits =

    type Create'InitiatingPaymentMethodDetailsType = | UsBankAccount

    type Create'InitiatingPaymentMethodDetailsUsBankAccount =
        {
            /// The bank account holder's name.
            [<Config.Form>]
            AccountHolderName: string option
            /// The bank account number.
            [<Config.Form>]
            AccountNumber: string option
            /// The bank account's routing number.
            [<Config.Form>]
            RoutingNumber: string option
        }

    type Create'InitiatingPaymentMethodDetailsUsBankAccount with
        static member New(?accountHolderName: string, ?accountNumber: string, ?routingNumber: string) =
            {
                AccountHolderName = accountHolderName
                AccountNumber = accountNumber
                RoutingNumber = routingNumber
            }

    type Create'InitiatingPaymentMethodDetails =
        {
            /// The source type.
            [<Config.Form>]
            Type: Create'InitiatingPaymentMethodDetailsType option
            /// Optional fields for `us_bank_account`.
            [<Config.Form>]
            UsBankAccount: Create'InitiatingPaymentMethodDetailsUsBankAccount option
        }

    type Create'InitiatingPaymentMethodDetails with
        static member New(?type': Create'InitiatingPaymentMethodDetailsType, ?usBankAccount: Create'InitiatingPaymentMethodDetailsUsBankAccount) =
            {
                Type = type'
                UsBankAccount = usBankAccount
            }

    type Create'Network =
        | Ach
        | UsDomesticWire

    type CreateOptions =
        {
            /// Amount (in cents) to be transferred.
            [<Config.Form>]
            Amount: int
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode
            /// An arbitrary string attached to the object. Often useful for displaying to users.
            [<Config.Form>]
            Description: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The FinancialAccount to send funds to.
            [<Config.Form>]
            FinancialAccount: string
            /// Initiating payment method details for the object.
            [<Config.Form>]
            InitiatingPaymentMethodDetails: Create'InitiatingPaymentMethodDetails option
            /// Specifies the network rails to be used. If not set, will default to the PaymentMethod's preferred network. See the [docs](https://docs.stripe.com/treasury/money-movement/timelines) to learn more about money movement timelines for each network type.
            [<Config.Form>]
            Network: Create'Network
        }

    type CreateOptions with
        static member New(amount: int, currency: IsoTypes.IsoCurrencyCode, financialAccount: string, network: Create'Network, ?description: string, ?expand: string list, ?initiatingPaymentMethodDetails: Create'InitiatingPaymentMethodDetails) =
            {
                Amount = amount
                Currency = currency
                FinancialAccount = financialAccount
                Network = network
                Description = description
                Expand = expand
                InitiatingPaymentMethodDetails = initiatingPaymentMethodDetails
            }

    ///<p>Use this endpoint to simulate a test mode ReceivedCredit initiated by a third party. In live mode, you can’t directly create ReceivedCredits initiated by third parties.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/test_helpers/treasury/received_credits"
        |> RestApi.postAsync<_, TreasuryReceivedCredit> settings (Map.empty) options

module TestHelpersTreasuryReceivedDebits =

    type Create'InitiatingPaymentMethodDetailsType = | UsBankAccount

    type Create'InitiatingPaymentMethodDetailsUsBankAccount =
        {
            /// The bank account holder's name.
            [<Config.Form>]
            AccountHolderName: string option
            /// The bank account number.
            [<Config.Form>]
            AccountNumber: string option
            /// The bank account's routing number.
            [<Config.Form>]
            RoutingNumber: string option
        }

    type Create'InitiatingPaymentMethodDetailsUsBankAccount with
        static member New(?accountHolderName: string, ?accountNumber: string, ?routingNumber: string) =
            {
                AccountHolderName = accountHolderName
                AccountNumber = accountNumber
                RoutingNumber = routingNumber
            }

    type Create'InitiatingPaymentMethodDetails =
        {
            /// The source type.
            [<Config.Form>]
            Type: Create'InitiatingPaymentMethodDetailsType option
            /// Optional fields for `us_bank_account`.
            [<Config.Form>]
            UsBankAccount: Create'InitiatingPaymentMethodDetailsUsBankAccount option
        }

    type Create'InitiatingPaymentMethodDetails with
        static member New(?type': Create'InitiatingPaymentMethodDetailsType, ?usBankAccount: Create'InitiatingPaymentMethodDetailsUsBankAccount) =
            {
                Type = type'
                UsBankAccount = usBankAccount
            }

    type Create'Network = | Ach

    type CreateOptions =
        {
            /// Amount (in cents) to be transferred.
            [<Config.Form>]
            Amount: int
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode
            /// An arbitrary string attached to the object. Often useful for displaying to users.
            [<Config.Form>]
            Description: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The FinancialAccount to pull funds from.
            [<Config.Form>]
            FinancialAccount: string
            /// Initiating payment method details for the object.
            [<Config.Form>]
            InitiatingPaymentMethodDetails: Create'InitiatingPaymentMethodDetails option
            /// Specifies the network rails to be used. If not set, will default to the PaymentMethod's preferred network. See the [docs](https://docs.stripe.com/treasury/money-movement/timelines) to learn more about money movement timelines for each network type.
            [<Config.Form>]
            Network: Create'Network
        }

    type CreateOptions with
        static member New(amount: int, currency: IsoTypes.IsoCurrencyCode, financialAccount: string, network: Create'Network, ?description: string, ?expand: string list, ?initiatingPaymentMethodDetails: Create'InitiatingPaymentMethodDetails) =
            {
                Amount = amount
                Currency = currency
                FinancialAccount = financialAccount
                Network = network
                Description = description
                Expand = expand
                InitiatingPaymentMethodDetails = initiatingPaymentMethodDetails
            }

    ///<p>Use this endpoint to simulate a test mode ReceivedDebit initiated by a third party. In live mode, you can’t directly create ReceivedDebits initiated by third parties.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/test_helpers/treasury/received_debits"
        |> RestApi.postAsync<_, TreasuryReceivedDebit> settings (Map.empty) options

