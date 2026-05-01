namespace StripeRequest.Setup

open FunStripe
open System.Text.Json.Serialization
open Stripe.PaymentMethod
open Stripe.SetupAttempt
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
module SetupAttempts =

    type ListOptions =
        {
            /// A filter on the list, based on the object `created` field. The value
            /// can be a string with an integer Unix timestamp or a
            /// dictionary with a number of different query options.
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
            /// Only return SetupAttempts created by the SetupIntent specified by
            /// this ID.
            [<Config.Query>]
            SetupIntent: string
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    type ListOptions with
        static member New(setupIntent: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                SetupIntent = setupIntent
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of SetupAttempts that associate with a provided SetupIntent.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("setup_intent", options.SetupIntent |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/setup_attempts"
        |> RestApi.getAsync<StripeList<SetupAttempt>> settings qs

module SetupIntents =

    type ListOptions =
        {
            /// If present, the SetupIntent's payment method will be attached to the in-context Stripe Account.
            /// It can only be used for this Stripe Account’s own money movement flows like InboundTransfer and OutboundTransfers. It cannot be set to true when setting up a PaymentMethod for a Customer, and defaults to false when attaching a PaymentMethod to a Customer.
            [<Config.Query>]
            AttachToSelf: bool option
            /// A filter on the list, based on the object `created` field. The value can be a string with an integer Unix timestamp, or it can be a dictionary with a number of different query options.
            [<Config.Query>]
            Created: int option
            /// Only return SetupIntents for the customer specified by this customer ID.
            [<Config.Query>]
            Customer: string option
            /// Only return SetupIntents for the account specified by this customer ID.
            [<Config.Query>]
            CustomerAccount: string option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// Only return SetupIntents that associate with the specified payment method.
            [<Config.Query>]
            PaymentMethod: string option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    type ListOptions with
        static member New(?attachToSelf: bool, ?created: int, ?customer: string, ?customerAccount: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?paymentMethod: string, ?startingAfter: string) =
            {
                AttachToSelf = attachToSelf
                Created = created
                Customer = customer
                CustomerAccount = customerAccount
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                PaymentMethod = paymentMethod
                StartingAfter = startingAfter
            }

    type Create'AutomaticPaymentMethodsAllowRedirects =
        | Always
        | Never

    type Create'AutomaticPaymentMethods =
        {
            /// Controls whether this SetupIntent will accept redirect-based payment methods.
            /// Redirect-based payment methods may require your customer to be redirected to a payment method's app or site for authentication or additional steps. To [confirm](https://docs.stripe.com/api/setup_intents/confirm) this SetupIntent, you may be required to provide a `return_url` to redirect customers back to your site after they authenticate or complete the setup.
            [<Config.Form>]
            AllowRedirects: Create'AutomaticPaymentMethodsAllowRedirects option
            /// Whether this feature is enabled.
            [<Config.Form>]
            Enabled: bool option
        }

    type Create'AutomaticPaymentMethods with
        static member New(?allowRedirects: Create'AutomaticPaymentMethodsAllowRedirects, ?enabled: bool) =
            {
                AllowRedirects = allowRedirects
                Enabled = enabled
            }

    type Create'ExcludedPaymentMethodTypes =
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
        | Card
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

    type Create'FlowDirections =
        | Inbound
        | Outbound

    type Create'MandateDataSecretKeyCustomerAcceptanceOnline =
        {
            /// The IP address from which the Mandate was accepted by the customer.
            [<Config.Form>]
            IpAddress: string option
            /// The user agent of the browser from which the Mandate was accepted by the customer.
            [<Config.Form>]
            UserAgent: string option
        }

    type Create'MandateDataSecretKeyCustomerAcceptanceOnline with
        static member New(?ipAddress: string, ?userAgent: string) =
            {
                IpAddress = ipAddress
                UserAgent = userAgent
            }

    type Create'MandateDataSecretKeyCustomerAcceptanceType =
        | Offline
        | Online

    type Create'MandateDataSecretKeyCustomerAcceptance =
        {
            /// The time at which the customer accepted the Mandate.
            [<Config.Form>]
            AcceptedAt: DateTime option
            /// If this is a Mandate accepted offline, this hash contains details about the offline acceptance.
            [<Config.Form>]
            Offline: string option
            /// If this is a Mandate accepted online, this hash contains details about the online acceptance.
            [<Config.Form>]
            Online: Create'MandateDataSecretKeyCustomerAcceptanceOnline option
            /// The type of customer acceptance information included with the Mandate. One of `online` or `offline`.
            [<Config.Form>]
            Type: Create'MandateDataSecretKeyCustomerAcceptanceType option
        }

    type Create'MandateDataSecretKeyCustomerAcceptance with
        static member New(?acceptedAt: DateTime, ?offline: string, ?online: Create'MandateDataSecretKeyCustomerAcceptanceOnline, ?type': Create'MandateDataSecretKeyCustomerAcceptanceType) =
            {
                AcceptedAt = acceptedAt
                Offline = offline
                Online = online
                Type = type'
            }

    type Create'MandateDataSecretKey =
        {
            /// This hash contains details about the customer acceptance of the Mandate.
            [<Config.Form>]
            CustomerAcceptance: Create'MandateDataSecretKeyCustomerAcceptance option
        }

    type Create'MandateDataSecretKey with
        static member New(?customerAcceptance: Create'MandateDataSecretKeyCustomerAcceptance) =
            {
                CustomerAcceptance = customerAcceptance
            }

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

    type Create'PaymentMethodOptionsAcssDebitCurrency =
        | Cad
        | Usd

    type Create'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor =
        | Invoice
        | Subscription

    type Create'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule =
        | Combined
        | Interval
        | Sporadic

    type Create'PaymentMethodOptionsAcssDebitMandateOptionsTransactionType =
        | Business
        | Personal

    type Create'PaymentMethodOptionsAcssDebitMandateOptions =
        {
            /// A URL for custom mandate text to render during confirmation step.
            /// The URL will be rendered with additional GET parameters `payment_intent` and `payment_intent_client_secret` when confirming a Payment Intent,
            /// or `setup_intent` and `setup_intent_client_secret` when confirming a Setup Intent.
            [<Config.Form>]
            CustomMandateUrl: Choice<string,string> option
            /// List of Stripe products where this mandate can be selected automatically.
            [<Config.Form>]
            DefaultFor: Create'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor list option
            /// Description of the mandate interval. Only required if 'payment_schedule' parameter is 'interval' or 'combined'.
            [<Config.Form>]
            IntervalDescription: string option
            /// Payment schedule for the mandate.
            [<Config.Form>]
            PaymentSchedule: Create'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule option
            /// Transaction type of the mandate.
            [<Config.Form>]
            TransactionType: Create'PaymentMethodOptionsAcssDebitMandateOptionsTransactionType option
        }

    type Create'PaymentMethodOptionsAcssDebitMandateOptions with
        static member New(?customMandateUrl: Choice<string,string>, ?defaultFor: Create'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor list, ?intervalDescription: string, ?paymentSchedule: Create'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule, ?transactionType: Create'PaymentMethodOptionsAcssDebitMandateOptionsTransactionType) =
            {
                CustomMandateUrl = customMandateUrl
                DefaultFor = defaultFor
                IntervalDescription = intervalDescription
                PaymentSchedule = paymentSchedule
                TransactionType = transactionType
            }

    type Create'PaymentMethodOptionsAcssDebitVerificationMethod =
        | Automatic
        | Instant
        | Microdeposits

    type Create'PaymentMethodOptionsAcssDebit =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: Create'PaymentMethodOptionsAcssDebitCurrency option
            /// Additional fields for Mandate creation
            [<Config.Form>]
            MandateOptions: Create'PaymentMethodOptionsAcssDebitMandateOptions option
            /// Bank account verification method. The default value is `automatic`.
            [<Config.Form>]
            VerificationMethod: Create'PaymentMethodOptionsAcssDebitVerificationMethod option
        }

    type Create'PaymentMethodOptionsAcssDebit with
        static member New(?currency: Create'PaymentMethodOptionsAcssDebitCurrency, ?mandateOptions: Create'PaymentMethodOptionsAcssDebitMandateOptions, ?verificationMethod: Create'PaymentMethodOptionsAcssDebitVerificationMethod) =
            {
                Currency = currency
                MandateOptions = mandateOptions
                VerificationMethod = verificationMethod
            }

    type Create'PaymentMethodOptionsBacsDebitMandateOptions =
        {
            /// Prefix used to generate the Mandate reference. Must be at most 12 characters long. Must consist of only uppercase letters, numbers, spaces, or the following special characters: '/', '_', '-', '&', '.'. Cannot begin with 'DDIC' or 'STRIPE'.
            [<Config.Form>]
            ReferencePrefix: Choice<string,string> option
        }

    type Create'PaymentMethodOptionsBacsDebitMandateOptions with
        static member New(?referencePrefix: Choice<string,string>) =
            {
                ReferencePrefix = referencePrefix
            }

    type Create'PaymentMethodOptionsBacsDebit =
        {
            /// Additional fields for Mandate creation
            [<Config.Form>]
            MandateOptions: Create'PaymentMethodOptionsBacsDebitMandateOptions option
        }

    type Create'PaymentMethodOptionsBacsDebit with
        static member New(?mandateOptions: Create'PaymentMethodOptionsBacsDebitMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Create'PaymentMethodOptionsCardMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Create'PaymentMethodOptionsCardMandateOptionsInterval =
        | Day
        | Month
        | Sporadic
        | Week
        | Year

    type Create'PaymentMethodOptionsCardMandateOptionsSupportedTypes = | India

    type Create'PaymentMethodOptionsCardMandateOptions =
        {
            /// Amount to be charged for future payments, specified in the presentment currency.
            [<Config.Form>]
            Amount: int option
            /// One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
            [<Config.Form>]
            AmountType: Create'PaymentMethodOptionsCardMandateOptionsAmountType option
            /// Currency in which future payments will be charged. Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// A description of the mandate or subscription that is meant to be displayed to the customer.
            [<Config.Form>]
            Description: string option
            /// End date of the mandate or subscription. If not provided, the mandate will be active until canceled. If provided, end date should be after start date.
            [<Config.Form>]
            EndDate: DateTime option
            /// Specifies payment frequency. One of `day`, `week`, `month`, `year`, or `sporadic`.
            [<Config.Form>]
            Interval: Create'PaymentMethodOptionsCardMandateOptionsInterval option
            /// The number of intervals between payments. For example, `interval=month` and `interval_count=3` indicates one payment every three months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks). This parameter is optional when `interval=sporadic`.
            [<Config.Form>]
            IntervalCount: int option
            /// Unique identifier for the mandate or subscription.
            [<Config.Form>]
            Reference: string option
            /// Start date of the mandate or subscription. Start date should not be lesser than yesterday.
            [<Config.Form>]
            StartDate: DateTime option
            /// Specifies the type of mandates supported. Possible values are `india`.
            [<Config.Form>]
            SupportedTypes: Create'PaymentMethodOptionsCardMandateOptionsSupportedTypes list option
        }

    type Create'PaymentMethodOptionsCardMandateOptions with
        static member New(?amount: int, ?amountType: Create'PaymentMethodOptionsCardMandateOptionsAmountType, ?currency: IsoTypes.IsoCurrencyCode, ?description: string, ?endDate: DateTime, ?interval: Create'PaymentMethodOptionsCardMandateOptionsInterval, ?intervalCount: int, ?reference: string, ?startDate: DateTime, ?supportedTypes: Create'PaymentMethodOptionsCardMandateOptionsSupportedTypes list) =
            {
                Amount = amount
                AmountType = amountType
                Currency = currency
                Description = description
                EndDate = endDate
                Interval = interval
                IntervalCount = intervalCount
                Reference = reference
                StartDate = startDate
                SupportedTypes = supportedTypes
            }

    type Create'PaymentMethodOptionsCardNetwork =
        | Amex
        | CartesBancaires
        | Diners
        | Discover
        | EftposAu
        | Girocard
        | Interac
        | Jcb
        | Link
        | Mastercard
        | Unionpay
        | Unknown
        | Visa

    type Create'PaymentMethodOptionsCardRequestThreeDSecure =
        | Any
        | Automatic
        | Challenge

    type Create'PaymentMethodOptionsCardThreeDSecureAresTransStatus =
        | [<JsonPropertyName("A")>] A
        | [<JsonPropertyName("C")>] C
        | [<JsonPropertyName("I")>] I
        | [<JsonPropertyName("N")>] N
        | [<JsonPropertyName("R")>] R
        | [<JsonPropertyName("U")>] U
        | [<JsonPropertyName("Y")>] Y

    type Create'PaymentMethodOptionsCardThreeDSecureElectronicCommerceIndicator =
        | [<JsonPropertyName("01")>] Numeric01
        | [<JsonPropertyName("02")>] Numeric02
        | [<JsonPropertyName("05")>] Numeric05
        | [<JsonPropertyName("06")>] Numeric06
        | [<JsonPropertyName("07")>] Numeric07

    type Create'PaymentMethodOptionsCardThreeDSecureNetworkOptionsCartesBancairesCbAvalgo =
        | [<JsonPropertyName("0")>] Numeric0
        | [<JsonPropertyName("1")>] Numeric1
        | [<JsonPropertyName("2")>] Numeric2
        | [<JsonPropertyName("3")>] Numeric3
        | [<JsonPropertyName("4")>] Numeric4
        | [<JsonPropertyName("A")>] A

    type Create'PaymentMethodOptionsCardThreeDSecureNetworkOptionsCartesBancaires =
        {
            /// The cryptogram calculation algorithm used by the card Issuer's ACS
            /// to calculate the Authentication cryptogram. Also known as `cavvAlgorithm`.
            /// messageExtension: CB-AVALGO
            [<Config.Form>]
            CbAvalgo: Create'PaymentMethodOptionsCardThreeDSecureNetworkOptionsCartesBancairesCbAvalgo option
            /// The exemption indicator returned from Cartes Bancaires in the ARes.
            /// message extension: CB-EXEMPTION; string (4 characters)
            /// This is a 3 byte bitmap (low significant byte first and most significant
            /// bit first) that has been Base64 encoded
            [<Config.Form>]
            CbExemption: string option
            /// The risk score returned from Cartes Bancaires in the ARes.
            /// message extension: CB-SCORE; numeric value 0-99
            [<Config.Form>]
            CbScore: int option
        }

    type Create'PaymentMethodOptionsCardThreeDSecureNetworkOptionsCartesBancaires with
        static member New(?cbAvalgo: Create'PaymentMethodOptionsCardThreeDSecureNetworkOptionsCartesBancairesCbAvalgo, ?cbExemption: string, ?cbScore: int) =
            {
                CbAvalgo = cbAvalgo
                CbExemption = cbExemption
                CbScore = cbScore
            }

    type Create'PaymentMethodOptionsCardThreeDSecureNetworkOptions =
        {
            /// Cartes Bancaires-specific 3DS fields.
            [<Config.Form>]
            CartesBancaires: Create'PaymentMethodOptionsCardThreeDSecureNetworkOptionsCartesBancaires option
        }

    type Create'PaymentMethodOptionsCardThreeDSecureNetworkOptions with
        static member New(?cartesBancaires: Create'PaymentMethodOptionsCardThreeDSecureNetworkOptionsCartesBancaires) =
            {
                CartesBancaires = cartesBancaires
            }

    type Create'PaymentMethodOptionsCardThreeDSecureVersion =
        | [<JsonPropertyName("1.0.2")>] Numeric102
        | [<JsonPropertyName("2.1.0")>] Numeric210
        | [<JsonPropertyName("2.2.0")>] Numeric220
        | [<JsonPropertyName("2.3.0")>] Numeric230
        | [<JsonPropertyName("2.3.1")>] Numeric231

    type Create'PaymentMethodOptionsCardThreeDSecure =
        {
            /// The `transStatus` returned from the card Issuer’s ACS in the ARes.
            [<Config.Form>]
            AresTransStatus: Create'PaymentMethodOptionsCardThreeDSecureAresTransStatus option
            /// The cryptogram, also known as the "authentication value" (AAV, CAVV or
            /// AEVV). This value is 20 bytes, base64-encoded into a 28-character string.
            /// (Most 3D Secure providers will return the base64-encoded version, which
            /// is what you should specify here.)
            [<Config.Form>]
            Cryptogram: string option
            /// The Electronic Commerce Indicator (ECI) is returned by your 3D Secure
            /// provider and indicates what degree of authentication was performed.
            [<Config.Form>]
            ElectronicCommerceIndicator: Create'PaymentMethodOptionsCardThreeDSecureElectronicCommerceIndicator option
            /// Network specific 3DS fields. Network specific arguments require an
            /// explicit card brand choice. The parameter `payment_method_options.card.network``
            /// must be populated accordingly
            [<Config.Form>]
            NetworkOptions: Create'PaymentMethodOptionsCardThreeDSecureNetworkOptions option
            /// The challenge indicator (`threeDSRequestorChallengeInd`) which was requested in the
            /// AReq sent to the card Issuer's ACS. A string containing 2 digits from 01-99.
            [<Config.Form>]
            RequestorChallengeIndicator: string option
            /// For 3D Secure 1, the XID. For 3D Secure 2, the Directory Server
            /// Transaction ID (dsTransID).
            [<Config.Form>]
            TransactionId: string option
            /// The version of 3D Secure that was performed.
            [<Config.Form>]
            Version: Create'PaymentMethodOptionsCardThreeDSecureVersion option
        }

    type Create'PaymentMethodOptionsCardThreeDSecure with
        static member New(?aresTransStatus: Create'PaymentMethodOptionsCardThreeDSecureAresTransStatus, ?cryptogram: string, ?electronicCommerceIndicator: Create'PaymentMethodOptionsCardThreeDSecureElectronicCommerceIndicator, ?networkOptions: Create'PaymentMethodOptionsCardThreeDSecureNetworkOptions, ?requestorChallengeIndicator: string, ?transactionId: string, ?version: Create'PaymentMethodOptionsCardThreeDSecureVersion) =
            {
                AresTransStatus = aresTransStatus
                Cryptogram = cryptogram
                ElectronicCommerceIndicator = electronicCommerceIndicator
                NetworkOptions = networkOptions
                RequestorChallengeIndicator = requestorChallengeIndicator
                TransactionId = transactionId
                Version = version
            }

    type Create'PaymentMethodOptionsCard =
        {
            /// Configuration options for setting up an eMandate for cards issued in India.
            [<Config.Form>]
            MandateOptions: Create'PaymentMethodOptionsCardMandateOptions option
            /// When specified, this parameter signals that a card has been collected
            /// as MOTO (Mail Order Telephone Order) and thus out of scope for SCA. This
            /// parameter can only be provided during confirmation.
            [<Config.Form>]
            Moto: bool option
            /// Selected network to process this SetupIntent on. Depends on the available networks of the card attached to the SetupIntent. Can be only set confirm-time.
            [<Config.Form>]
            Network: Create'PaymentMethodOptionsCardNetwork option
            /// We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://docs.stripe.com/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. If not provided, this value defaults to `automatic`. Read our guide on [manually requesting 3D Secure](https://docs.stripe.com/payments/3d-secure/authentication-flow#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
            [<Config.Form>]
            RequestThreeDSecure: Create'PaymentMethodOptionsCardRequestThreeDSecure option
            /// If 3D Secure authentication was performed with a third-party provider,
            /// the authentication details to use for this setup.
            [<Config.Form>]
            ThreeDSecure: Create'PaymentMethodOptionsCardThreeDSecure option
        }

    type Create'PaymentMethodOptionsCard with
        static member New(?mandateOptions: Create'PaymentMethodOptionsCardMandateOptions, ?moto: bool, ?network: Create'PaymentMethodOptionsCardNetwork, ?requestThreeDSecure: Create'PaymentMethodOptionsCardRequestThreeDSecure, ?threeDSecure: Create'PaymentMethodOptionsCardThreeDSecure) =
            {
                MandateOptions = mandateOptions
                Moto = moto
                Network = network
                RequestThreeDSecure = requestThreeDSecure
                ThreeDSecure = threeDSecure
            }

    type Create'PaymentMethodOptionsKlarnaOnDemandPurchaseInterval =
        | Day
        | Month
        | Week
        | Year

    type Create'PaymentMethodOptionsKlarnaOnDemand =
        {
            /// Your average amount value. You can use a value across your customer base, or segment based on customer type, country, etc.
            [<Config.Form>]
            AverageAmount: int option
            /// The maximum value you may charge a customer per purchase. You can use a value across your customer base, or segment based on customer type, country, etc.
            [<Config.Form>]
            MaximumAmount: int option
            /// The lowest or minimum value you may charge a customer per purchase. You can use a value across your customer base, or segment based on customer type, country, etc.
            [<Config.Form>]
            MinimumAmount: int option
            /// Interval at which the customer is making purchases
            [<Config.Form>]
            PurchaseInterval: Create'PaymentMethodOptionsKlarnaOnDemandPurchaseInterval option
            /// The number of `purchase_interval` between charges
            [<Config.Form>]
            PurchaseIntervalCount: int option
        }

    type Create'PaymentMethodOptionsKlarnaOnDemand with
        static member New(?averageAmount: int, ?maximumAmount: int, ?minimumAmount: int, ?purchaseInterval: Create'PaymentMethodOptionsKlarnaOnDemandPurchaseInterval, ?purchaseIntervalCount: int) =
            {
                AverageAmount = averageAmount
                MaximumAmount = maximumAmount
                MinimumAmount = minimumAmount
                PurchaseInterval = purchaseInterval
                PurchaseIntervalCount = purchaseIntervalCount
            }

    type Create'PaymentMethodOptionsKlarnaPreferredLocale =
        | [<JsonPropertyName("cs-CZ")>] CsCZ
        | [<JsonPropertyName("da-DK")>] DaDK
        | [<JsonPropertyName("de-AT")>] DeAT
        | [<JsonPropertyName("de-CH")>] DeCH
        | [<JsonPropertyName("de-DE")>] DeDE
        | [<JsonPropertyName("el-GR")>] ElGR
        | [<JsonPropertyName("en-AT")>] EnAT
        | [<JsonPropertyName("en-AU")>] EnAU
        | [<JsonPropertyName("en-BE")>] EnBE
        | [<JsonPropertyName("en-CA")>] EnCA
        | [<JsonPropertyName("en-CH")>] EnCH
        | [<JsonPropertyName("en-CZ")>] EnCZ
        | [<JsonPropertyName("en-DE")>] EnDE
        | [<JsonPropertyName("en-DK")>] EnDK
        | [<JsonPropertyName("en-ES")>] EnES
        | [<JsonPropertyName("en-FI")>] EnFI
        | [<JsonPropertyName("en-FR")>] EnFR
        | [<JsonPropertyName("en-GB")>] EnGB
        | [<JsonPropertyName("en-GR")>] EnGR
        | [<JsonPropertyName("en-IE")>] EnIE
        | [<JsonPropertyName("en-IT")>] EnIT
        | [<JsonPropertyName("en-NL")>] EnNL
        | [<JsonPropertyName("en-NO")>] EnNO
        | [<JsonPropertyName("en-NZ")>] EnNZ
        | [<JsonPropertyName("en-PL")>] EnPL
        | [<JsonPropertyName("en-PT")>] EnPT
        | [<JsonPropertyName("en-RO")>] EnRO
        | [<JsonPropertyName("en-SE")>] EnSE
        | [<JsonPropertyName("en-US")>] EnUS
        | [<JsonPropertyName("es-ES")>] EsES
        | [<JsonPropertyName("es-US")>] EsUS
        | [<JsonPropertyName("fi-FI")>] FiFI
        | [<JsonPropertyName("fr-BE")>] FrBE
        | [<JsonPropertyName("fr-CA")>] FrCA
        | [<JsonPropertyName("fr-CH")>] FrCH
        | [<JsonPropertyName("fr-FR")>] FrFR
        | [<JsonPropertyName("it-CH")>] ItCH
        | [<JsonPropertyName("it-IT")>] ItIT
        | [<JsonPropertyName("nb-NO")>] NbNO
        | [<JsonPropertyName("nl-BE")>] NlBE
        | [<JsonPropertyName("nl-NL")>] NlNL
        | [<JsonPropertyName("pl-PL")>] PlPL
        | [<JsonPropertyName("pt-PT")>] PtPT
        | [<JsonPropertyName("ro-RO")>] RoRO
        | [<JsonPropertyName("sv-FI")>] SvFI
        | [<JsonPropertyName("sv-SE")>] SvSE

    type Create'PaymentMethodOptionsKlarnaSubscriptionsInterval =
        | Day
        | Month
        | Week
        | Year

    type Create'PaymentMethodOptionsKlarnaSubscriptionsNextBilling =
        {
            /// The amount of the next charge for the subscription.
            [<Config.Form>]
            Amount: int option
            /// The date of the next charge for the subscription in YYYY-MM-DD format.
            [<Config.Form>]
            Date: string option
        }

    type Create'PaymentMethodOptionsKlarnaSubscriptionsNextBilling with
        static member New(?amount: int, ?date: string) =
            {
                Amount = amount
                Date = date
            }

    type Create'PaymentMethodOptionsKlarnaSubscriptions =
        {
            /// Unit of time between subscription charges.
            [<Config.Form>]
            Interval: Create'PaymentMethodOptionsKlarnaSubscriptionsInterval option
            /// The number of intervals (specified in the `interval` attribute) between subscription charges. For example, `interval=month` and `interval_count=3` charges every 3 months.
            [<Config.Form>]
            IntervalCount: int option
            /// Name for subscription.
            [<Config.Form>]
            Name: string option
            /// Describes the upcoming charge for this subscription.
            [<Config.Form>]
            NextBilling: Create'PaymentMethodOptionsKlarnaSubscriptionsNextBilling option
            /// A non-customer-facing reference to correlate subscription charges in the Klarna app. Use a value that persists across subscription charges.
            [<Config.Form>]
            Reference: string option
        }

    type Create'PaymentMethodOptionsKlarnaSubscriptions with
        static member New(?interval: Create'PaymentMethodOptionsKlarnaSubscriptionsInterval, ?intervalCount: int, ?name: string, ?nextBilling: Create'PaymentMethodOptionsKlarnaSubscriptionsNextBilling, ?reference: string) =
            {
                Interval = interval
                IntervalCount = intervalCount
                Name = name
                NextBilling = nextBilling
                Reference = reference
            }

    type Create'PaymentMethodOptionsKlarna =
        {
            /// The currency of the SetupIntent. Three letter ISO currency code.
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// On-demand details if setting up a payment method for on-demand payments.
            [<Config.Form>]
            OnDemand: Create'PaymentMethodOptionsKlarnaOnDemand option
            /// Preferred language of the Klarna authorization page that the customer is redirected to
            [<Config.Form>]
            PreferredLocale: Create'PaymentMethodOptionsKlarnaPreferredLocale option
            /// Subscription details if setting up or charging a subscription
            [<Config.Form>]
            Subscriptions: Choice<Create'PaymentMethodOptionsKlarnaSubscriptions list,string> option
        }

    type Create'PaymentMethodOptionsKlarna with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?onDemand: Create'PaymentMethodOptionsKlarnaOnDemand, ?preferredLocale: Create'PaymentMethodOptionsKlarnaPreferredLocale, ?subscriptions: Choice<Create'PaymentMethodOptionsKlarnaSubscriptions list,string>) =
            {
                Currency = currency
                OnDemand = onDemand
                PreferredLocale = preferredLocale
                Subscriptions = subscriptions
            }

    type Create'PaymentMethodOptionsLink =
        {
            /// [Deprecated] This is a legacy parameter that no longer has any function.
            [<Config.Form>]
            PersistentToken: string option
        }

    type Create'PaymentMethodOptionsLink with
        static member New(?persistentToken: string) =
            {
                PersistentToken = persistentToken
            }

    type Create'PaymentMethodOptionsPaypal =
        {
            /// The PayPal Billing Agreement ID (BAID). This is an ID generated by PayPal which represents the mandate between the merchant and the customer.
            [<Config.Form>]
            BillingAgreementId: string option
        }

    type Create'PaymentMethodOptionsPaypal with
        static member New(?billingAgreementId: string) =
            {
                BillingAgreementId = billingAgreementId
            }

    type Create'PaymentMethodOptionsPaytoMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Create'PaymentMethodOptionsPaytoMandateOptionsPaymentSchedule =
        | Adhoc
        | Annual
        | Daily
        | Fortnightly
        | Monthly
        | Quarterly
        | SemiAnnual
        | Weekly

    type Create'PaymentMethodOptionsPaytoMandateOptionsPurpose =
        | DependantSupport
        | Government
        | Loan
        | Mortgage
        | Other
        | Pension
        | Personal
        | Retail
        | Salary
        | Tax
        | Utility

    type Create'PaymentMethodOptionsPaytoMandateOptions =
        {
            /// Amount that will be collected. It is required when `amount_type` is `fixed`.
            [<Config.Form>]
            Amount: Choice<int,string> option
            /// The type of amount that will be collected. The amount charged must be exact or up to the value of `amount` param for `fixed` or `maximum` type respectively. Defaults to `maximum`.
            [<Config.Form>]
            AmountType: Create'PaymentMethodOptionsPaytoMandateOptionsAmountType option
            /// Date, in YYYY-MM-DD format, after which payments will not be collected. Defaults to no end date.
            [<Config.Form>]
            EndDate: Choice<string,string> option
            /// The periodicity at which payments will be collected. Defaults to `adhoc`.
            [<Config.Form>]
            PaymentSchedule: Create'PaymentMethodOptionsPaytoMandateOptionsPaymentSchedule option
            /// The number of payments that will be made during a payment period. Defaults to 1 except for when `payment_schedule` is `adhoc`. In that case, it defaults to no limit.
            [<Config.Form>]
            PaymentsPerPeriod: Choice<int,string> option
            /// The purpose for which payments are made. Has a default value based on your merchant category code.
            [<Config.Form>]
            Purpose: Create'PaymentMethodOptionsPaytoMandateOptionsPurpose option
            /// Date, in YYYY-MM-DD format, from which payments will be collected. Defaults to confirmation time.
            [<Config.Form>]
            StartDate: Choice<string,string> option
        }

    type Create'PaymentMethodOptionsPaytoMandateOptions with
        static member New(?amount: Choice<int,string>, ?amountType: Create'PaymentMethodOptionsPaytoMandateOptionsAmountType, ?endDate: Choice<string,string>, ?paymentSchedule: Create'PaymentMethodOptionsPaytoMandateOptionsPaymentSchedule, ?paymentsPerPeriod: Choice<int,string>, ?purpose: Create'PaymentMethodOptionsPaytoMandateOptionsPurpose, ?startDate: Choice<string,string>) =
            {
                Amount = amount
                AmountType = amountType
                EndDate = endDate
                PaymentSchedule = paymentSchedule
                PaymentsPerPeriod = paymentsPerPeriod
                Purpose = purpose
                StartDate = startDate
            }

    type Create'PaymentMethodOptionsPayto =
        {
            /// Additional fields for Mandate creation.
            [<Config.Form>]
            MandateOptions: Create'PaymentMethodOptionsPaytoMandateOptions option
        }

    type Create'PaymentMethodOptionsPayto with
        static member New(?mandateOptions: Create'PaymentMethodOptionsPaytoMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Create'PaymentMethodOptionsPixMandateOptionsAmountIncludesIof =
        | Always
        | Never

    type Create'PaymentMethodOptionsPixMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Create'PaymentMethodOptionsPixMandateOptionsPaymentSchedule =
        | Halfyearly
        | Monthly
        | Quarterly
        | Weekly
        | Yearly

    type Create'PaymentMethodOptionsPixMandateOptions =
        {
            /// Amount to be charged for future payments. Required when `amount_type=fixed`. If not provided for `amount_type=maximum`, defaults to 40000.
            [<Config.Form>]
            Amount: int option
            /// Determines if the amount includes the IOF tax. Defaults to `never`.
            [<Config.Form>]
            AmountIncludesIof: Create'PaymentMethodOptionsPixMandateOptionsAmountIncludesIof option
            /// Type of amount. Defaults to `maximum`.
            [<Config.Form>]
            AmountType: Create'PaymentMethodOptionsPixMandateOptionsAmountType option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Only `brl` is supported currently.
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// Date when the mandate expires and no further payments will be charged, in `YYYY-MM-DD`. If not provided, the mandate will be active until canceled. If provided, end date should be after start date.
            [<Config.Form>]
            EndDate: string option
            /// Schedule at which the future payments will be charged. Defaults to `monthly`.
            [<Config.Form>]
            PaymentSchedule: Create'PaymentMethodOptionsPixMandateOptionsPaymentSchedule option
            /// Subscription name displayed to buyers in their bank app. Defaults to the displayable business name.
            [<Config.Form>]
            Reference: string option
            /// Start date of the mandate, in `YYYY-MM-DD`. Start date should be at least 3 days in the future. Defaults to 3 days after the current date.
            [<Config.Form>]
            StartDate: string option
        }

    type Create'PaymentMethodOptionsPixMandateOptions with
        static member New(?amount: int, ?amountIncludesIof: Create'PaymentMethodOptionsPixMandateOptionsAmountIncludesIof, ?amountType: Create'PaymentMethodOptionsPixMandateOptionsAmountType, ?currency: IsoTypes.IsoCurrencyCode, ?endDate: string, ?paymentSchedule: Create'PaymentMethodOptionsPixMandateOptionsPaymentSchedule, ?reference: string, ?startDate: string) =
            {
                Amount = amount
                AmountIncludesIof = amountIncludesIof
                AmountType = amountType
                Currency = currency
                EndDate = endDate
                PaymentSchedule = paymentSchedule
                Reference = reference
                StartDate = startDate
            }

    type Create'PaymentMethodOptionsPix =
        {
            /// Additional fields for mandate creation.
            [<Config.Form>]
            MandateOptions: Create'PaymentMethodOptionsPixMandateOptions option
        }

    type Create'PaymentMethodOptionsPix with
        static member New(?mandateOptions: Create'PaymentMethodOptionsPixMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Create'PaymentMethodOptionsSepaDebitMandateOptions =
        {
            /// Prefix used to generate the Mandate reference. Must be at most 12 characters long. Must consist of only uppercase letters, numbers, spaces, or the following special characters: '/', '_', '-', '&', '.'. Cannot begin with 'STRIPE'.
            [<Config.Form>]
            ReferencePrefix: Choice<string,string> option
        }

    type Create'PaymentMethodOptionsSepaDebitMandateOptions with
        static member New(?referencePrefix: Choice<string,string>) =
            {
                ReferencePrefix = referencePrefix
            }

    type Create'PaymentMethodOptionsSepaDebit =
        {
            /// Additional fields for Mandate creation
            [<Config.Form>]
            MandateOptions: Create'PaymentMethodOptionsSepaDebitMandateOptions option
        }

    type Create'PaymentMethodOptionsSepaDebit with
        static member New(?mandateOptions: Create'PaymentMethodOptionsSepaDebitMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Create'PaymentMethodOptionsUpiMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Create'PaymentMethodOptionsUpiMandateOptions =
        {
            /// Amount to be charged for future payments.
            [<Config.Form>]
            Amount: int option
            /// One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
            [<Config.Form>]
            AmountType: Create'PaymentMethodOptionsUpiMandateOptionsAmountType option
            /// A description of the mandate or subscription that is meant to be displayed to the customer.
            [<Config.Form>]
            Description: string option
            /// End date of the mandate or subscription.
            [<Config.Form>]
            EndDate: DateTime option
        }

    type Create'PaymentMethodOptionsUpiMandateOptions with
        static member New(?amount: int, ?amountType: Create'PaymentMethodOptionsUpiMandateOptionsAmountType, ?description: string, ?endDate: DateTime) =
            {
                Amount = amount
                AmountType = amountType
                Description = description
                EndDate = endDate
            }

    type Create'PaymentMethodOptionsUpiSetupFutureUsage =
        | [<JsonPropertyName("none")>] None'
        | OffSession
        | OnSession

    type Create'PaymentMethodOptionsUpi =
        {
            /// Configuration options for setting up an eMandate
            [<Config.Form>]
            MandateOptions: Create'PaymentMethodOptionsUpiMandateOptions option
            [<Config.Form>]
            SetupFutureUsage: Create'PaymentMethodOptionsUpiSetupFutureUsage option
        }

    type Create'PaymentMethodOptionsUpi with
        static member New(?mandateOptions: Create'PaymentMethodOptionsUpiMandateOptions, ?setupFutureUsage: Create'PaymentMethodOptionsUpiSetupFutureUsage) =
            {
                MandateOptions = mandateOptions
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsFiltersAccountSubcategories =
        | Checking
        | Savings

    type Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsFilters =
        {
            /// The account subcategories to use to filter for selectable accounts. Valid subcategories are `checking` and `savings`.
            [<Config.Form>]
            AccountSubcategories:
                Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsFiltersAccountSubcategories list option
        }

    type Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsFilters with
        static member New(?accountSubcategories: Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsFiltersAccountSubcategories list) =
            {
                AccountSubcategories = accountSubcategories
            }

    type Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions =
        | Balances
        | Ownership
        | PaymentMethod
        | Transactions

    type Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch =
        | Balances
        | Ownership
        | Transactions

    type Create'PaymentMethodOptionsUsBankAccountFinancialConnections =
        {
            /// Provide filters for the linked accounts that the customer can select for the payment method.
            [<Config.Form>]
            Filters: Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsFilters option
            /// The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.
            [<Config.Form>]
            Permissions: Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions list option
            /// List of data features that you would like to retrieve upon account creation.
            [<Config.Form>]
            Prefetch: Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch list option
            /// For webview integrations only. Upon completing OAuth login in the native browser, the user will be redirected to this URL to return to your app.
            [<Config.Form>]
            ReturnUrl: string option
        }

    type Create'PaymentMethodOptionsUsBankAccountFinancialConnections with
        static member New(?filters: Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsFilters, ?permissions: Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions list, ?prefetch: Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch list, ?returnUrl: string) =
            {
                Filters = filters
                Permissions = permissions
                Prefetch = prefetch
                ReturnUrl = returnUrl
            }

    type Create'PaymentMethodOptionsUsBankAccountMandateOptionsCollectionMethod = | Paper

    type Create'PaymentMethodOptionsUsBankAccountMandateOptions =
        {
            /// The method used to collect offline mandate customer acceptance.
            [<Config.Form>]
            CollectionMethod: Create'PaymentMethodOptionsUsBankAccountMandateOptionsCollectionMethod option
        }

    type Create'PaymentMethodOptionsUsBankAccountMandateOptions with
        static member New(?collectionMethod: Create'PaymentMethodOptionsUsBankAccountMandateOptionsCollectionMethod) =
            {
                CollectionMethod = collectionMethod
            }

    type Create'PaymentMethodOptionsUsBankAccountNetworksRequested =
        | Ach
        | UsDomesticWire

    type Create'PaymentMethodOptionsUsBankAccountNetworks =
        {
            /// Triggers validations to run across the selected networks
            [<Config.Form>]
            Requested: Create'PaymentMethodOptionsUsBankAccountNetworksRequested list option
        }

    type Create'PaymentMethodOptionsUsBankAccountNetworks with
        static member New(?requested: Create'PaymentMethodOptionsUsBankAccountNetworksRequested list) =
            {
                Requested = requested
            }

    type Create'PaymentMethodOptionsUsBankAccountVerificationMethod =
        | Automatic
        | Instant
        | Microdeposits

    type Create'PaymentMethodOptionsUsBankAccount =
        {
            /// Additional fields for Financial Connections Session creation
            [<Config.Form>]
            FinancialConnections: Create'PaymentMethodOptionsUsBankAccountFinancialConnections option
            /// Additional fields for Mandate creation
            [<Config.Form>]
            MandateOptions: Create'PaymentMethodOptionsUsBankAccountMandateOptions option
            /// Additional fields for network related functions
            [<Config.Form>]
            Networks: Create'PaymentMethodOptionsUsBankAccountNetworks option
            /// Bank account verification method. The default value is `automatic`.
            [<Config.Form>]
            VerificationMethod: Create'PaymentMethodOptionsUsBankAccountVerificationMethod option
        }

    type Create'PaymentMethodOptionsUsBankAccount with
        static member New(?financialConnections: Create'PaymentMethodOptionsUsBankAccountFinancialConnections, ?mandateOptions: Create'PaymentMethodOptionsUsBankAccountMandateOptions, ?networks: Create'PaymentMethodOptionsUsBankAccountNetworks, ?verificationMethod: Create'PaymentMethodOptionsUsBankAccountVerificationMethod) =
            {
                FinancialConnections = financialConnections
                MandateOptions = mandateOptions
                Networks = networks
                VerificationMethod = verificationMethod
            }

    type Create'PaymentMethodOptions =
        {
            /// If this is a `acss_debit` SetupIntent, this sub-hash contains details about the ACSS Debit payment method options.
            [<Config.Form>]
            AcssDebit: Create'PaymentMethodOptionsAcssDebit option
            /// If this is a `amazon_pay` SetupIntent, this sub-hash contains details about the AmazonPay payment method options.
            [<Config.Form>]
            AmazonPay: string option
            /// If this is a `bacs_debit` SetupIntent, this sub-hash contains details about the Bacs Debit payment method options.
            [<Config.Form>]
            BacsDebit: Create'PaymentMethodOptionsBacsDebit option
            /// Configuration for any card setup attempted on this SetupIntent.
            [<Config.Form>]
            Card: Create'PaymentMethodOptionsCard option
            /// If this is a `card_present` PaymentMethod, this sub-hash contains details about the card-present payment method options.
            [<Config.Form>]
            CardPresent: string option
            /// If this is a `klarna` PaymentMethod, this hash contains details about the Klarna payment method options.
            [<Config.Form>]
            Klarna: Create'PaymentMethodOptionsKlarna option
            /// If this is a `link` PaymentMethod, this sub-hash contains details about the Link payment method options.
            [<Config.Form>]
            Link: Create'PaymentMethodOptionsLink option
            /// If this is a `paypal` PaymentMethod, this sub-hash contains details about the PayPal payment method options.
            [<Config.Form>]
            Paypal: Create'PaymentMethodOptionsPaypal option
            /// If this is a `payto` SetupIntent, this sub-hash contains details about the PayTo payment method options.
            [<Config.Form>]
            Payto: Create'PaymentMethodOptionsPayto option
            /// If this is a `pix` SetupIntent, this sub-hash contains details about the Pix payment method options.
            [<Config.Form>]
            Pix: Create'PaymentMethodOptionsPix option
            /// If this is a `sepa_debit` SetupIntent, this sub-hash contains details about the SEPA Debit payment method options.
            [<Config.Form>]
            SepaDebit: Create'PaymentMethodOptionsSepaDebit option
            /// If this is a `upi` SetupIntent, this sub-hash contains details about the UPI payment method options.
            [<Config.Form>]
            Upi: Create'PaymentMethodOptionsUpi option
            /// If this is a `us_bank_account` SetupIntent, this sub-hash contains details about the US bank account payment method options.
            [<Config.Form>]
            UsBankAccount: Create'PaymentMethodOptionsUsBankAccount option
        }

    type Create'PaymentMethodOptions with
        static member New(?acssDebit: Create'PaymentMethodOptionsAcssDebit, ?amazonPay: string, ?bacsDebit: Create'PaymentMethodOptionsBacsDebit, ?card: Create'PaymentMethodOptionsCard, ?cardPresent: string, ?klarna: Create'PaymentMethodOptionsKlarna, ?link: Create'PaymentMethodOptionsLink, ?paypal: Create'PaymentMethodOptionsPaypal, ?payto: Create'PaymentMethodOptionsPayto, ?pix: Create'PaymentMethodOptionsPix, ?sepaDebit: Create'PaymentMethodOptionsSepaDebit, ?upi: Create'PaymentMethodOptionsUpi, ?usBankAccount: Create'PaymentMethodOptionsUsBankAccount) =
            {
                AcssDebit = acssDebit
                AmazonPay = amazonPay
                BacsDebit = bacsDebit
                Card = card
                CardPresent = cardPresent
                Klarna = klarna
                Link = link
                Paypal = paypal
                Payto = payto
                Pix = pix
                SepaDebit = sepaDebit
                Upi = upi
                UsBankAccount = usBankAccount
            }

    type Create'SingleUse =
        {
            /// Amount the customer is granting permission to collect later. A positive integer representing how much to charge in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal) (e.g., 100 cents to charge $1.00 or 100 to charge ¥100, a zero-decimal currency). The minimum amount is $0.50 US or [equivalent in charge currency](https://docs.stripe.com/currencies#minimum-and-maximum-charge-amounts). The amount value supports up to eight digits (e.g., a value of 99999999 for a USD charge of $999,999.99).
            [<Config.Form>]
            Amount: int option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
        }

    type Create'SingleUse with
        static member New(?amount: int, ?currency: IsoTypes.IsoCurrencyCode) =
            {
                Amount = amount
                Currency = currency
            }

    type Create'Usage =
        | OffSession
        | OnSession

    type CreateOptions =
        {
            /// If present, the SetupIntent's payment method will be attached to the in-context Stripe Account.
            /// It can only be used for this Stripe Account’s own money movement flows like InboundTransfer and OutboundTransfers. It cannot be set to true when setting up a PaymentMethod for a Customer, and defaults to false when attaching a PaymentMethod to a Customer.
            [<Config.Form>]
            AttachToSelf: bool option
            /// When you enable this parameter, this SetupIntent accepts payment methods that you enable in the Dashboard and that are compatible with its other parameters.
            [<Config.Form>]
            AutomaticPaymentMethods: Create'AutomaticPaymentMethods option
            /// Set to `true` to attempt to confirm this SetupIntent immediately. This parameter defaults to `false`. If a card is the attached payment method, you can provide a `return_url` in case further authentication is necessary.
            [<Config.Form>]
            Confirm: bool option
            /// ID of the ConfirmationToken used to confirm this SetupIntent.
            /// If the provided ConfirmationToken contains properties that are also being provided in this request, such as `payment_method`, then the values in this request will take precedence.
            [<Config.Form>]
            ConfirmationToken: string option
            /// ID of the Customer this SetupIntent belongs to, if one exists.
            /// If present, the SetupIntent's payment method will be attached to the Customer on successful setup. Payment methods attached to other Customers cannot be used with this SetupIntent.
            [<Config.Form>]
            Customer: string option
            /// ID of the Account this SetupIntent belongs to, if one exists.
            /// If present, the SetupIntent's payment method will be attached to the Account on successful setup. Payment methods attached to other Accounts cannot be used with this SetupIntent.
            [<Config.Form>]
            CustomerAccount: string option
            /// An arbitrary string attached to the object. Often useful for displaying to users.
            [<Config.Form>]
            Description: string option
            /// The list of payment method types to exclude from use with this SetupIntent.
            [<Config.Form>]
            ExcludedPaymentMethodTypes: Create'ExcludedPaymentMethodTypes list option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Indicates the directions of money movement for which this payment method is intended to be used.
            /// Include `inbound` if you intend to use the payment method as the origin to pull funds from. Include `outbound` if you intend to use the payment method as the destination to send funds to. You can include both if you intend to use the payment method for both purposes.
            [<Config.Form>]
            FlowDirections: Create'FlowDirections list option
            /// This hash contains details about the mandate to create. This parameter can only be used with [`confirm=true`](https://docs.stripe.com/api/setup_intents/create#create_setup_intent-confirm).
            [<Config.Form>]
            MandateData: Choice<Create'MandateDataSecretKey,string> option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The Stripe account ID created for this SetupIntent.
            [<Config.Form>]
            OnBehalfOf: string option
            /// ID of the payment method (a PaymentMethod, Card, or saved Source object) to attach to this SetupIntent.
            [<Config.Form>]
            PaymentMethod: string option
            /// The ID of the [payment method configuration](https://docs.stripe.com/api/payment_method_configurations) to use with this SetupIntent.
            [<Config.Form>]
            PaymentMethodConfiguration: string option
            /// When included, this hash creates a PaymentMethod that is set as the [`payment_method`](https://docs.stripe.com/api/setup_intents/object#setup_intent_object-payment_method)
            /// value in the SetupIntent.
            [<Config.Form>]
            PaymentMethodData: Create'PaymentMethodData option
            /// Payment method-specific configuration for this SetupIntent.
            [<Config.Form>]
            PaymentMethodOptions: Create'PaymentMethodOptions option
            /// The list of payment method types (for example, card) that this SetupIntent can use. If you don't provide this, Stripe will dynamically show relevant payment methods from your [payment method settings](https://dashboard.stripe.com/settings/payment_methods). A list of valid payment method types can be found [here](https://docs.stripe.com/api/payment_methods/object#payment_method_object-type).
            [<Config.Form>]
            PaymentMethodTypes: string list option
            /// The URL to redirect your customer back to after they authenticate or cancel their payment on the payment method's app or site. To redirect to a mobile application, you can alternatively supply an application URI scheme. This parameter can only be used with [`confirm=true`](https://docs.stripe.com/api/setup_intents/create#create_setup_intent-confirm).
            [<Config.Form>]
            ReturnUrl: string option
            /// If you populate this hash, this SetupIntent generates a `single_use` mandate after successful completion.
            /// Single-use mandates are only valid for the following payment methods: `acss_debit`, `alipay`, `au_becs_debit`, `bacs_debit`, `bancontact`, `boleto`, `ideal`, `link`, `sepa_debit`, and `us_bank_account`.
            [<Config.Form>]
            SingleUse: Create'SingleUse option
            /// Indicates how the payment method is intended to be used in the future. If not provided, this value defaults to `off_session`.
            [<Config.Form>]
            Usage: Create'Usage option
            /// Set to `true` when confirming server-side and using Stripe.js, iOS, or Android client-side SDKs to handle the next actions.
            [<Config.Form>]
            UseStripeSdk: bool option
        }

    type CreateOptions with
        static member New(?attachToSelf: bool, ?automaticPaymentMethods: Create'AutomaticPaymentMethods, ?confirm: bool, ?confirmationToken: string, ?customer: string, ?customerAccount: string, ?description: string, ?excludedPaymentMethodTypes: Create'ExcludedPaymentMethodTypes list, ?expand: string list, ?flowDirections: Create'FlowDirections list, ?mandateData: Choice<Create'MandateDataSecretKey,string>, ?metadata: Map<string, string>, ?onBehalfOf: string, ?paymentMethod: string, ?paymentMethodConfiguration: string, ?paymentMethodData: Create'PaymentMethodData, ?paymentMethodOptions: Create'PaymentMethodOptions, ?paymentMethodTypes: string list, ?returnUrl: string, ?singleUse: Create'SingleUse, ?usage: Create'Usage, ?useStripeSdk: bool) =
            {
                AttachToSelf = attachToSelf
                AutomaticPaymentMethods = automaticPaymentMethods
                Confirm = confirm
                ConfirmationToken = confirmationToken
                Customer = customer
                CustomerAccount = customerAccount
                Description = description
                ExcludedPaymentMethodTypes = excludedPaymentMethodTypes
                Expand = expand
                FlowDirections = flowDirections
                MandateData = mandateData
                Metadata = metadata
                OnBehalfOf = onBehalfOf
                PaymentMethod = paymentMethod
                PaymentMethodConfiguration = paymentMethodConfiguration
                PaymentMethodData = paymentMethodData
                PaymentMethodOptions = paymentMethodOptions
                PaymentMethodTypes = paymentMethodTypes
                ReturnUrl = returnUrl
                SingleUse = singleUse
                Usage = usage
                UseStripeSdk = useStripeSdk
            }

    type RetrieveOptions =
        {
            /// The client secret of the SetupIntent. We require this string if you use a publishable key to retrieve the SetupIntent.
            [<Config.Query>]
            ClientSecret: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Intent: string
        }

    type RetrieveOptions with
        static member New(intent: string, ?clientSecret: string, ?expand: string list) =
            {
                Intent = intent
                ClientSecret = clientSecret
                Expand = expand
            }

    type Update'ExcludedPaymentMethodTypes =
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
        | Card
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

    type Update'FlowDirections =
        | Inbound
        | Outbound

    type Update'PaymentMethodDataAcssDebit =
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

    type Update'PaymentMethodDataAcssDebit with
        static member New(?accountNumber: string, ?institutionNumber: string, ?transitNumber: string) =
            {
                AccountNumber = accountNumber
                InstitutionNumber = institutionNumber
                TransitNumber = transitNumber
            }

    type Update'PaymentMethodDataAllowRedisplay =
        | Always
        | Limited
        | Unspecified

    type Update'PaymentMethodDataAuBecsDebit =
        {
            /// The account number for the bank account.
            [<Config.Form>]
            AccountNumber: string option
            /// Bank-State-Branch number of the bank account.
            [<Config.Form>]
            BsbNumber: string option
        }

    type Update'PaymentMethodDataAuBecsDebit with
        static member New(?accountNumber: string, ?bsbNumber: string) =
            {
                AccountNumber = accountNumber
                BsbNumber = bsbNumber
            }

    type Update'PaymentMethodDataBacsDebit =
        {
            /// Account number of the bank account that the funds will be debited from.
            [<Config.Form>]
            AccountNumber: string option
            /// Sort code of the bank account. (e.g., `10-20-30`)
            [<Config.Form>]
            SortCode: string option
        }

    type Update'PaymentMethodDataBacsDebit with
        static member New(?accountNumber: string, ?sortCode: string) =
            {
                AccountNumber = accountNumber
                SortCode = sortCode
            }

    type Update'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress =
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

    type Update'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'PaymentMethodDataBillingDetails =
        {
            /// Billing address.
            [<Config.Form>]
            Address: Choice<Update'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string> option
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

    type Update'PaymentMethodDataBillingDetails with
        static member New(?address: Choice<Update'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string>, ?email: Choice<string,string>, ?name: Choice<string,string>, ?phone: Choice<string,string>, ?taxId: string) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
                TaxId = taxId
            }

    type Update'PaymentMethodDataBoleto =
        {
            /// The tax ID of the customer (CPF for individual consumers or CNPJ for businesses consumers)
            [<Config.Form>]
            TaxId: string option
        }

    type Update'PaymentMethodDataBoleto with
        static member New(?taxId: string) =
            {
                TaxId = taxId
            }

    type Update'PaymentMethodDataEpsBank =
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

    type Update'PaymentMethodDataEps =
        {
            /// The customer's bank.
            [<Config.Form>]
            Bank: Update'PaymentMethodDataEpsBank option
        }

    type Update'PaymentMethodDataEps with
        static member New(?bank: Update'PaymentMethodDataEpsBank) =
            {
                Bank = bank
            }

    type Update'PaymentMethodDataFpxAccountHolderType =
        | Company
        | Individual

    type Update'PaymentMethodDataFpxBank =
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

    type Update'PaymentMethodDataFpx =
        {
            /// Account holder type for FPX transaction
            [<Config.Form>]
            AccountHolderType: Update'PaymentMethodDataFpxAccountHolderType option
            /// The customer's bank.
            [<Config.Form>]
            Bank: Update'PaymentMethodDataFpxBank option
        }

    type Update'PaymentMethodDataFpx with
        static member New(?accountHolderType: Update'PaymentMethodDataFpxAccountHolderType, ?bank: Update'PaymentMethodDataFpxBank) =
            {
                AccountHolderType = accountHolderType
                Bank = bank
            }

    type Update'PaymentMethodDataIdealBank =
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

    type Update'PaymentMethodDataIdeal =
        {
            /// The customer's bank. Only use this parameter for existing customers. Don't use it for new customers.
            [<Config.Form>]
            Bank: Update'PaymentMethodDataIdealBank option
        }

    type Update'PaymentMethodDataIdeal with
        static member New(?bank: Update'PaymentMethodDataIdealBank) =
            {
                Bank = bank
            }

    type Update'PaymentMethodDataKlarnaDob =
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

    type Update'PaymentMethodDataKlarnaDob with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Update'PaymentMethodDataKlarna =
        {
            /// Customer's date of birth
            [<Config.Form>]
            Dob: Update'PaymentMethodDataKlarnaDob option
        }

    type Update'PaymentMethodDataKlarna with
        static member New(?dob: Update'PaymentMethodDataKlarnaDob) =
            {
                Dob = dob
            }

    type Update'PaymentMethodDataNaverPayFunding =
        | Card
        | Points

    type Update'PaymentMethodDataNaverPay =
        {
            /// Whether to use Naver Pay points or a card to fund this transaction. If not provided, this defaults to `card`.
            [<Config.Form>]
            Funding: Update'PaymentMethodDataNaverPayFunding option
        }

    type Update'PaymentMethodDataNaverPay with
        static member New(?funding: Update'PaymentMethodDataNaverPayFunding) =
            {
                Funding = funding
            }

    type Update'PaymentMethodDataNzBankAccount =
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

    type Update'PaymentMethodDataNzBankAccount with
        static member New(?accountHolderName: string, ?accountNumber: string, ?bankCode: string, ?branchCode: string, ?reference: string, ?suffix: string) =
            {
                AccountHolderName = accountHolderName
                AccountNumber = accountNumber
                BankCode = bankCode
                BranchCode = branchCode
                Reference = reference
                Suffix = suffix
            }

    type Update'PaymentMethodDataP24Bank =
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

    type Update'PaymentMethodDataP24 =
        {
            /// The customer's bank.
            [<Config.Form>]
            Bank: Update'PaymentMethodDataP24Bank option
        }

    type Update'PaymentMethodDataP24 with
        static member New(?bank: Update'PaymentMethodDataP24Bank) =
            {
                Bank = bank
            }

    type Update'PaymentMethodDataPayto =
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

    type Update'PaymentMethodDataPayto with
        static member New(?accountNumber: string, ?bsbNumber: string, ?payId: string) =
            {
                AccountNumber = accountNumber
                BsbNumber = bsbNumber
                PayId = payId
            }

    type Update'PaymentMethodDataRadarOptions =
        {
            /// A [Radar Session](https://docs.stripe.com/radar/radar-session) is a snapshot of the browser metadata and device details that help Radar make more accurate predictions on your payments.
            [<Config.Form>]
            Session: string option
        }

    type Update'PaymentMethodDataRadarOptions with
        static member New(?session: string) =
            {
                Session = session
            }

    type Update'PaymentMethodDataSepaDebit =
        {
            /// IBAN of the bank account.
            [<Config.Form>]
            Iban: string option
        }

    type Update'PaymentMethodDataSepaDebit with
        static member New(?iban: string) =
            {
                Iban = iban
            }

    type Update'PaymentMethodDataSofortCountry =
        | [<JsonPropertyName("AT")>] AT
        | [<JsonPropertyName("BE")>] BE
        | [<JsonPropertyName("DE")>] DE
        | [<JsonPropertyName("ES")>] ES
        | [<JsonPropertyName("IT")>] IT
        | [<JsonPropertyName("NL")>] NL

    type Update'PaymentMethodDataSofort =
        {
            /// Two-letter ISO code representing the country the bank account is located in.
            [<Config.Form>]
            Country: Update'PaymentMethodDataSofortCountry option
        }

    type Update'PaymentMethodDataSofort with
        static member New(?country: Update'PaymentMethodDataSofortCountry) =
            {
                Country = country
            }

    type Update'PaymentMethodDataType =
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

    type Update'PaymentMethodDataUpiMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Update'PaymentMethodDataUpiMandateOptions =
        {
            /// Amount to be charged for future payments.
            [<Config.Form>]
            Amount: int option
            /// One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
            [<Config.Form>]
            AmountType: Update'PaymentMethodDataUpiMandateOptionsAmountType option
            /// A description of the mandate or subscription that is meant to be displayed to the customer.
            [<Config.Form>]
            Description: string option
            /// End date of the mandate or subscription.
            [<Config.Form>]
            EndDate: DateTime option
        }

    type Update'PaymentMethodDataUpiMandateOptions with
        static member New(?amount: int, ?amountType: Update'PaymentMethodDataUpiMandateOptionsAmountType, ?description: string, ?endDate: DateTime) =
            {
                Amount = amount
                AmountType = amountType
                Description = description
                EndDate = endDate
            }

    type Update'PaymentMethodDataUpi =
        {
            /// Configuration options for setting up an eMandate
            [<Config.Form>]
            MandateOptions: Update'PaymentMethodDataUpiMandateOptions option
        }

    type Update'PaymentMethodDataUpi with
        static member New(?mandateOptions: Update'PaymentMethodDataUpiMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Update'PaymentMethodDataUsBankAccountAccountHolderType =
        | Company
        | Individual

    type Update'PaymentMethodDataUsBankAccountAccountType =
        | Checking
        | Savings

    type Update'PaymentMethodDataUsBankAccount =
        {
            /// Account holder type: individual or company.
            [<Config.Form>]
            AccountHolderType: Update'PaymentMethodDataUsBankAccountAccountHolderType option
            /// Account number of the bank account.
            [<Config.Form>]
            AccountNumber: string option
            /// Account type: checkings or savings. Defaults to checking if omitted.
            [<Config.Form>]
            AccountType: Update'PaymentMethodDataUsBankAccountAccountType option
            /// The ID of a Financial Connections Account to use as a payment method.
            [<Config.Form>]
            FinancialConnectionsAccount: string option
            /// Routing number of the bank account.
            [<Config.Form>]
            RoutingNumber: string option
        }

    type Update'PaymentMethodDataUsBankAccount with
        static member New(?accountHolderType: Update'PaymentMethodDataUsBankAccountAccountHolderType, ?accountNumber: string, ?accountType: Update'PaymentMethodDataUsBankAccountAccountType, ?financialConnectionsAccount: string, ?routingNumber: string) =
            {
                AccountHolderType = accountHolderType
                AccountNumber = accountNumber
                AccountType = accountType
                FinancialConnectionsAccount = financialConnectionsAccount
                RoutingNumber = routingNumber
            }

    type Update'PaymentMethodData =
        {
            /// If this is an `acss_debit` PaymentMethod, this hash contains details about the ACSS Debit payment method.
            [<Config.Form>]
            AcssDebit: Update'PaymentMethodDataAcssDebit option
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
            AllowRedisplay: Update'PaymentMethodDataAllowRedisplay option
            /// If this is a Alma PaymentMethod, this hash contains details about the Alma payment method.
            [<Config.Form>]
            Alma: string option
            /// If this is a AmazonPay PaymentMethod, this hash contains details about the AmazonPay payment method.
            [<Config.Form>]
            AmazonPay: string option
            /// If this is an `au_becs_debit` PaymentMethod, this hash contains details about the bank account.
            [<Config.Form>]
            AuBecsDebit: Update'PaymentMethodDataAuBecsDebit option
            /// If this is a `bacs_debit` PaymentMethod, this hash contains details about the Bacs Direct Debit bank account.
            [<Config.Form>]
            BacsDebit: Update'PaymentMethodDataBacsDebit option
            /// If this is a `bancontact` PaymentMethod, this hash contains details about the Bancontact payment method.
            [<Config.Form>]
            Bancontact: string option
            /// If this is a `billie` PaymentMethod, this hash contains details about the Billie payment method.
            [<Config.Form>]
            Billie: string option
            /// Billing information associated with the PaymentMethod that may be used or required by particular types of payment methods.
            [<Config.Form>]
            BillingDetails: Update'PaymentMethodDataBillingDetails option
            /// If this is a `blik` PaymentMethod, this hash contains details about the BLIK payment method.
            [<Config.Form>]
            Blik: string option
            /// If this is a `boleto` PaymentMethod, this hash contains details about the Boleto payment method.
            [<Config.Form>]
            Boleto: Update'PaymentMethodDataBoleto option
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
            Eps: Update'PaymentMethodDataEps option
            /// If this is an `fpx` PaymentMethod, this hash contains details about the FPX payment method.
            [<Config.Form>]
            Fpx: Update'PaymentMethodDataFpx option
            /// If this is a `giropay` PaymentMethod, this hash contains details about the Giropay payment method.
            [<Config.Form>]
            Giropay: string option
            /// If this is a `grabpay` PaymentMethod, this hash contains details about the GrabPay payment method.
            [<Config.Form>]
            Grabpay: string option
            /// If this is an `ideal` PaymentMethod, this hash contains details about the iDEAL payment method.
            [<Config.Form>]
            Ideal: Update'PaymentMethodDataIdeal option
            /// If this is an `interac_present` PaymentMethod, this hash contains details about the Interac Present payment method.
            [<Config.Form>]
            InteracPresent: string option
            /// If this is a `kakao_pay` PaymentMethod, this hash contains details about the Kakao Pay payment method.
            [<Config.Form>]
            KakaoPay: string option
            /// If this is a `klarna` PaymentMethod, this hash contains details about the Klarna payment method.
            [<Config.Form>]
            Klarna: Update'PaymentMethodDataKlarna option
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
            NaverPay: Update'PaymentMethodDataNaverPay option
            /// If this is an nz_bank_account PaymentMethod, this hash contains details about the nz_bank_account payment method.
            [<Config.Form>]
            NzBankAccount: Update'PaymentMethodDataNzBankAccount option
            /// If this is an `oxxo` PaymentMethod, this hash contains details about the OXXO payment method.
            [<Config.Form>]
            Oxxo: string option
            /// If this is a `p24` PaymentMethod, this hash contains details about the P24 payment method.
            [<Config.Form>]
            P24: Update'PaymentMethodDataP24 option
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
            Payto: Update'PaymentMethodDataPayto option
            /// If this is a `pix` PaymentMethod, this hash contains details about the Pix payment method.
            [<Config.Form>]
            Pix: string option
            /// If this is a `promptpay` PaymentMethod, this hash contains details about the PromptPay payment method.
            [<Config.Form>]
            Promptpay: string option
            /// Options to configure Radar. See [Radar Session](https://docs.stripe.com/radar/radar-session) for more information.
            [<Config.Form>]
            RadarOptions: Update'PaymentMethodDataRadarOptions option
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
            SepaDebit: Update'PaymentMethodDataSepaDebit option
            /// If this is a `sofort` PaymentMethod, this hash contains details about the SOFORT payment method.
            [<Config.Form>]
            Sofort: Update'PaymentMethodDataSofort option
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
            Type: Update'PaymentMethodDataType option
            /// If this is a `upi` PaymentMethod, this hash contains details about the UPI payment method.
            [<Config.Form>]
            Upi: Update'PaymentMethodDataUpi option
            /// If this is an `us_bank_account` PaymentMethod, this hash contains details about the US bank account payment method.
            [<Config.Form>]
            UsBankAccount: Update'PaymentMethodDataUsBankAccount option
            /// If this is an `wechat_pay` PaymentMethod, this hash contains details about the wechat_pay payment method.
            [<Config.Form>]
            WechatPay: string option
            /// If this is a `zip` PaymentMethod, this hash contains details about the Zip payment method.
            [<Config.Form>]
            Zip: string option
        }

    type Update'PaymentMethodData with
        static member New(?acssDebit: Update'PaymentMethodDataAcssDebit, ?affirm: string, ?afterpayClearpay: string, ?alipay: string, ?allowRedisplay: Update'PaymentMethodDataAllowRedisplay, ?alma: string, ?amazonPay: string, ?auBecsDebit: Update'PaymentMethodDataAuBecsDebit, ?bacsDebit: Update'PaymentMethodDataBacsDebit, ?bancontact: string, ?billie: string, ?billingDetails: Update'PaymentMethodDataBillingDetails, ?blik: string, ?boleto: Update'PaymentMethodDataBoleto, ?cashapp: string, ?crypto: string, ?customerBalance: string, ?eps: Update'PaymentMethodDataEps, ?fpx: Update'PaymentMethodDataFpx, ?giropay: string, ?grabpay: string, ?ideal: Update'PaymentMethodDataIdeal, ?interacPresent: string, ?kakaoPay: string, ?klarna: Update'PaymentMethodDataKlarna, ?konbini: string, ?krCard: string, ?link: string, ?mbWay: string, ?metadata: Map<string, string>, ?mobilepay: string, ?multibanco: string, ?naverPay: Update'PaymentMethodDataNaverPay, ?nzBankAccount: Update'PaymentMethodDataNzBankAccount, ?oxxo: string, ?p24: Update'PaymentMethodDataP24, ?payByBank: string, ?payco: string, ?paynow: string, ?paypal: string, ?payto: Update'PaymentMethodDataPayto, ?pix: string, ?promptpay: string, ?radarOptions: Update'PaymentMethodDataRadarOptions, ?revolutPay: string, ?samsungPay: string, ?satispay: string, ?sepaDebit: Update'PaymentMethodDataSepaDebit, ?sofort: Update'PaymentMethodDataSofort, ?sunbit: string, ?swish: string, ?twint: string, ?type': Update'PaymentMethodDataType, ?upi: Update'PaymentMethodDataUpi, ?usBankAccount: Update'PaymentMethodDataUsBankAccount, ?wechatPay: string, ?zip: string) =
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

    type Update'PaymentMethodOptionsAcssDebitCurrency =
        | Cad
        | Usd

    type Update'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor =
        | Invoice
        | Subscription

    type Update'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule =
        | Combined
        | Interval
        | Sporadic

    type Update'PaymentMethodOptionsAcssDebitMandateOptionsTransactionType =
        | Business
        | Personal

    type Update'PaymentMethodOptionsAcssDebitMandateOptions =
        {
            /// A URL for custom mandate text to render during confirmation step.
            /// The URL will be rendered with additional GET parameters `payment_intent` and `payment_intent_client_secret` when confirming a Payment Intent,
            /// or `setup_intent` and `setup_intent_client_secret` when confirming a Setup Intent.
            [<Config.Form>]
            CustomMandateUrl: Choice<string,string> option
            /// List of Stripe products where this mandate can be selected automatically.
            [<Config.Form>]
            DefaultFor: Update'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor list option
            /// Description of the mandate interval. Only required if 'payment_schedule' parameter is 'interval' or 'combined'.
            [<Config.Form>]
            IntervalDescription: string option
            /// Payment schedule for the mandate.
            [<Config.Form>]
            PaymentSchedule: Update'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule option
            /// Transaction type of the mandate.
            [<Config.Form>]
            TransactionType: Update'PaymentMethodOptionsAcssDebitMandateOptionsTransactionType option
        }

    type Update'PaymentMethodOptionsAcssDebitMandateOptions with
        static member New(?customMandateUrl: Choice<string,string>, ?defaultFor: Update'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor list, ?intervalDescription: string, ?paymentSchedule: Update'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule, ?transactionType: Update'PaymentMethodOptionsAcssDebitMandateOptionsTransactionType) =
            {
                CustomMandateUrl = customMandateUrl
                DefaultFor = defaultFor
                IntervalDescription = intervalDescription
                PaymentSchedule = paymentSchedule
                TransactionType = transactionType
            }

    type Update'PaymentMethodOptionsAcssDebitVerificationMethod =
        | Automatic
        | Instant
        | Microdeposits

    type Update'PaymentMethodOptionsAcssDebit =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: Update'PaymentMethodOptionsAcssDebitCurrency option
            /// Additional fields for Mandate creation
            [<Config.Form>]
            MandateOptions: Update'PaymentMethodOptionsAcssDebitMandateOptions option
            /// Bank account verification method. The default value is `automatic`.
            [<Config.Form>]
            VerificationMethod: Update'PaymentMethodOptionsAcssDebitVerificationMethod option
        }

    type Update'PaymentMethodOptionsAcssDebit with
        static member New(?currency: Update'PaymentMethodOptionsAcssDebitCurrency, ?mandateOptions: Update'PaymentMethodOptionsAcssDebitMandateOptions, ?verificationMethod: Update'PaymentMethodOptionsAcssDebitVerificationMethod) =
            {
                Currency = currency
                MandateOptions = mandateOptions
                VerificationMethod = verificationMethod
            }

    type Update'PaymentMethodOptionsBacsDebitMandateOptions =
        {
            /// Prefix used to generate the Mandate reference. Must be at most 12 characters long. Must consist of only uppercase letters, numbers, spaces, or the following special characters: '/', '_', '-', '&', '.'. Cannot begin with 'DDIC' or 'STRIPE'.
            [<Config.Form>]
            ReferencePrefix: Choice<string,string> option
        }

    type Update'PaymentMethodOptionsBacsDebitMandateOptions with
        static member New(?referencePrefix: Choice<string,string>) =
            {
                ReferencePrefix = referencePrefix
            }

    type Update'PaymentMethodOptionsBacsDebit =
        {
            /// Additional fields for Mandate creation
            [<Config.Form>]
            MandateOptions: Update'PaymentMethodOptionsBacsDebitMandateOptions option
        }

    type Update'PaymentMethodOptionsBacsDebit with
        static member New(?mandateOptions: Update'PaymentMethodOptionsBacsDebitMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Update'PaymentMethodOptionsCardMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Update'PaymentMethodOptionsCardMandateOptionsInterval =
        | Day
        | Month
        | Sporadic
        | Week
        | Year

    type Update'PaymentMethodOptionsCardMandateOptionsSupportedTypes = | India

    type Update'PaymentMethodOptionsCardMandateOptions =
        {
            /// Amount to be charged for future payments, specified in the presentment currency.
            [<Config.Form>]
            Amount: int option
            /// One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
            [<Config.Form>]
            AmountType: Update'PaymentMethodOptionsCardMandateOptionsAmountType option
            /// Currency in which future payments will be charged. Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// A description of the mandate or subscription that is meant to be displayed to the customer.
            [<Config.Form>]
            Description: string option
            /// End date of the mandate or subscription. If not provided, the mandate will be active until canceled. If provided, end date should be after start date.
            [<Config.Form>]
            EndDate: DateTime option
            /// Specifies payment frequency. One of `day`, `week`, `month`, `year`, or `sporadic`.
            [<Config.Form>]
            Interval: Update'PaymentMethodOptionsCardMandateOptionsInterval option
            /// The number of intervals between payments. For example, `interval=month` and `interval_count=3` indicates one payment every three months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks). This parameter is optional when `interval=sporadic`.
            [<Config.Form>]
            IntervalCount: int option
            /// Unique identifier for the mandate or subscription.
            [<Config.Form>]
            Reference: string option
            /// Start date of the mandate or subscription. Start date should not be lesser than yesterday.
            [<Config.Form>]
            StartDate: DateTime option
            /// Specifies the type of mandates supported. Possible values are `india`.
            [<Config.Form>]
            SupportedTypes: Update'PaymentMethodOptionsCardMandateOptionsSupportedTypes list option
        }

    type Update'PaymentMethodOptionsCardMandateOptions with
        static member New(?amount: int, ?amountType: Update'PaymentMethodOptionsCardMandateOptionsAmountType, ?currency: IsoTypes.IsoCurrencyCode, ?description: string, ?endDate: DateTime, ?interval: Update'PaymentMethodOptionsCardMandateOptionsInterval, ?intervalCount: int, ?reference: string, ?startDate: DateTime, ?supportedTypes: Update'PaymentMethodOptionsCardMandateOptionsSupportedTypes list) =
            {
                Amount = amount
                AmountType = amountType
                Currency = currency
                Description = description
                EndDate = endDate
                Interval = interval
                IntervalCount = intervalCount
                Reference = reference
                StartDate = startDate
                SupportedTypes = supportedTypes
            }

    type Update'PaymentMethodOptionsCardNetwork =
        | Amex
        | CartesBancaires
        | Diners
        | Discover
        | EftposAu
        | Girocard
        | Interac
        | Jcb
        | Link
        | Mastercard
        | Unionpay
        | Unknown
        | Visa

    type Update'PaymentMethodOptionsCardRequestThreeDSecure =
        | Any
        | Automatic
        | Challenge

    type Update'PaymentMethodOptionsCardThreeDSecureAresTransStatus =
        | [<JsonPropertyName("A")>] A
        | [<JsonPropertyName("C")>] C
        | [<JsonPropertyName("I")>] I
        | [<JsonPropertyName("N")>] N
        | [<JsonPropertyName("R")>] R
        | [<JsonPropertyName("U")>] U
        | [<JsonPropertyName("Y")>] Y

    type Update'PaymentMethodOptionsCardThreeDSecureElectronicCommerceIndicator =
        | [<JsonPropertyName("01")>] Numeric01
        | [<JsonPropertyName("02")>] Numeric02
        | [<JsonPropertyName("05")>] Numeric05
        | [<JsonPropertyName("06")>] Numeric06
        | [<JsonPropertyName("07")>] Numeric07

    type Update'PaymentMethodOptionsCardThreeDSecureNetworkOptionsCartesBancairesCbAvalgo =
        | [<JsonPropertyName("0")>] Numeric0
        | [<JsonPropertyName("1")>] Numeric1
        | [<JsonPropertyName("2")>] Numeric2
        | [<JsonPropertyName("3")>] Numeric3
        | [<JsonPropertyName("4")>] Numeric4
        | [<JsonPropertyName("A")>] A

    type Update'PaymentMethodOptionsCardThreeDSecureNetworkOptionsCartesBancaires =
        {
            /// The cryptogram calculation algorithm used by the card Issuer's ACS
            /// to calculate the Authentication cryptogram. Also known as `cavvAlgorithm`.
            /// messageExtension: CB-AVALGO
            [<Config.Form>]
            CbAvalgo: Update'PaymentMethodOptionsCardThreeDSecureNetworkOptionsCartesBancairesCbAvalgo option
            /// The exemption indicator returned from Cartes Bancaires in the ARes.
            /// message extension: CB-EXEMPTION; string (4 characters)
            /// This is a 3 byte bitmap (low significant byte first and most significant
            /// bit first) that has been Base64 encoded
            [<Config.Form>]
            CbExemption: string option
            /// The risk score returned from Cartes Bancaires in the ARes.
            /// message extension: CB-SCORE; numeric value 0-99
            [<Config.Form>]
            CbScore: int option
        }

    type Update'PaymentMethodOptionsCardThreeDSecureNetworkOptionsCartesBancaires with
        static member New(?cbAvalgo: Update'PaymentMethodOptionsCardThreeDSecureNetworkOptionsCartesBancairesCbAvalgo, ?cbExemption: string, ?cbScore: int) =
            {
                CbAvalgo = cbAvalgo
                CbExemption = cbExemption
                CbScore = cbScore
            }

    type Update'PaymentMethodOptionsCardThreeDSecureNetworkOptions =
        {
            /// Cartes Bancaires-specific 3DS fields.
            [<Config.Form>]
            CartesBancaires: Update'PaymentMethodOptionsCardThreeDSecureNetworkOptionsCartesBancaires option
        }

    type Update'PaymentMethodOptionsCardThreeDSecureNetworkOptions with
        static member New(?cartesBancaires: Update'PaymentMethodOptionsCardThreeDSecureNetworkOptionsCartesBancaires) =
            {
                CartesBancaires = cartesBancaires
            }

    type Update'PaymentMethodOptionsCardThreeDSecureVersion =
        | [<JsonPropertyName("1.0.2")>] Numeric102
        | [<JsonPropertyName("2.1.0")>] Numeric210
        | [<JsonPropertyName("2.2.0")>] Numeric220
        | [<JsonPropertyName("2.3.0")>] Numeric230
        | [<JsonPropertyName("2.3.1")>] Numeric231

    type Update'PaymentMethodOptionsCardThreeDSecure =
        {
            /// The `transStatus` returned from the card Issuer’s ACS in the ARes.
            [<Config.Form>]
            AresTransStatus: Update'PaymentMethodOptionsCardThreeDSecureAresTransStatus option
            /// The cryptogram, also known as the "authentication value" (AAV, CAVV or
            /// AEVV). This value is 20 bytes, base64-encoded into a 28-character string.
            /// (Most 3D Secure providers will return the base64-encoded version, which
            /// is what you should specify here.)
            [<Config.Form>]
            Cryptogram: string option
            /// The Electronic Commerce Indicator (ECI) is returned by your 3D Secure
            /// provider and indicates what degree of authentication was performed.
            [<Config.Form>]
            ElectronicCommerceIndicator: Update'PaymentMethodOptionsCardThreeDSecureElectronicCommerceIndicator option
            /// Network specific 3DS fields. Network specific arguments require an
            /// explicit card brand choice. The parameter `payment_method_options.card.network``
            /// must be populated accordingly
            [<Config.Form>]
            NetworkOptions: Update'PaymentMethodOptionsCardThreeDSecureNetworkOptions option
            /// The challenge indicator (`threeDSRequestorChallengeInd`) which was requested in the
            /// AReq sent to the card Issuer's ACS. A string containing 2 digits from 01-99.
            [<Config.Form>]
            RequestorChallengeIndicator: string option
            /// For 3D Secure 1, the XID. For 3D Secure 2, the Directory Server
            /// Transaction ID (dsTransID).
            [<Config.Form>]
            TransactionId: string option
            /// The version of 3D Secure that was performed.
            [<Config.Form>]
            Version: Update'PaymentMethodOptionsCardThreeDSecureVersion option
        }

    type Update'PaymentMethodOptionsCardThreeDSecure with
        static member New(?aresTransStatus: Update'PaymentMethodOptionsCardThreeDSecureAresTransStatus, ?cryptogram: string, ?electronicCommerceIndicator: Update'PaymentMethodOptionsCardThreeDSecureElectronicCommerceIndicator, ?networkOptions: Update'PaymentMethodOptionsCardThreeDSecureNetworkOptions, ?requestorChallengeIndicator: string, ?transactionId: string, ?version: Update'PaymentMethodOptionsCardThreeDSecureVersion) =
            {
                AresTransStatus = aresTransStatus
                Cryptogram = cryptogram
                ElectronicCommerceIndicator = electronicCommerceIndicator
                NetworkOptions = networkOptions
                RequestorChallengeIndicator = requestorChallengeIndicator
                TransactionId = transactionId
                Version = version
            }

    type Update'PaymentMethodOptionsCard =
        {
            /// Configuration options for setting up an eMandate for cards issued in India.
            [<Config.Form>]
            MandateOptions: Update'PaymentMethodOptionsCardMandateOptions option
            /// When specified, this parameter signals that a card has been collected
            /// as MOTO (Mail Order Telephone Order) and thus out of scope for SCA. This
            /// parameter can only be provided during confirmation.
            [<Config.Form>]
            Moto: bool option
            /// Selected network to process this SetupIntent on. Depends on the available networks of the card attached to the SetupIntent. Can be only set confirm-time.
            [<Config.Form>]
            Network: Update'PaymentMethodOptionsCardNetwork option
            /// We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://docs.stripe.com/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. If not provided, this value defaults to `automatic`. Read our guide on [manually requesting 3D Secure](https://docs.stripe.com/payments/3d-secure/authentication-flow#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
            [<Config.Form>]
            RequestThreeDSecure: Update'PaymentMethodOptionsCardRequestThreeDSecure option
            /// If 3D Secure authentication was performed with a third-party provider,
            /// the authentication details to use for this setup.
            [<Config.Form>]
            ThreeDSecure: Update'PaymentMethodOptionsCardThreeDSecure option
        }

    type Update'PaymentMethodOptionsCard with
        static member New(?mandateOptions: Update'PaymentMethodOptionsCardMandateOptions, ?moto: bool, ?network: Update'PaymentMethodOptionsCardNetwork, ?requestThreeDSecure: Update'PaymentMethodOptionsCardRequestThreeDSecure, ?threeDSecure: Update'PaymentMethodOptionsCardThreeDSecure) =
            {
                MandateOptions = mandateOptions
                Moto = moto
                Network = network
                RequestThreeDSecure = requestThreeDSecure
                ThreeDSecure = threeDSecure
            }

    type Update'PaymentMethodOptionsKlarnaOnDemandPurchaseInterval =
        | Day
        | Month
        | Week
        | Year

    type Update'PaymentMethodOptionsKlarnaOnDemand =
        {
            /// Your average amount value. You can use a value across your customer base, or segment based on customer type, country, etc.
            [<Config.Form>]
            AverageAmount: int option
            /// The maximum value you may charge a customer per purchase. You can use a value across your customer base, or segment based on customer type, country, etc.
            [<Config.Form>]
            MaximumAmount: int option
            /// The lowest or minimum value you may charge a customer per purchase. You can use a value across your customer base, or segment based on customer type, country, etc.
            [<Config.Form>]
            MinimumAmount: int option
            /// Interval at which the customer is making purchases
            [<Config.Form>]
            PurchaseInterval: Update'PaymentMethodOptionsKlarnaOnDemandPurchaseInterval option
            /// The number of `purchase_interval` between charges
            [<Config.Form>]
            PurchaseIntervalCount: int option
        }

    type Update'PaymentMethodOptionsKlarnaOnDemand with
        static member New(?averageAmount: int, ?maximumAmount: int, ?minimumAmount: int, ?purchaseInterval: Update'PaymentMethodOptionsKlarnaOnDemandPurchaseInterval, ?purchaseIntervalCount: int) =
            {
                AverageAmount = averageAmount
                MaximumAmount = maximumAmount
                MinimumAmount = minimumAmount
                PurchaseInterval = purchaseInterval
                PurchaseIntervalCount = purchaseIntervalCount
            }

    type Update'PaymentMethodOptionsKlarnaPreferredLocale =
        | [<JsonPropertyName("cs-CZ")>] CsCZ
        | [<JsonPropertyName("da-DK")>] DaDK
        | [<JsonPropertyName("de-AT")>] DeAT
        | [<JsonPropertyName("de-CH")>] DeCH
        | [<JsonPropertyName("de-DE")>] DeDE
        | [<JsonPropertyName("el-GR")>] ElGR
        | [<JsonPropertyName("en-AT")>] EnAT
        | [<JsonPropertyName("en-AU")>] EnAU
        | [<JsonPropertyName("en-BE")>] EnBE
        | [<JsonPropertyName("en-CA")>] EnCA
        | [<JsonPropertyName("en-CH")>] EnCH
        | [<JsonPropertyName("en-CZ")>] EnCZ
        | [<JsonPropertyName("en-DE")>] EnDE
        | [<JsonPropertyName("en-DK")>] EnDK
        | [<JsonPropertyName("en-ES")>] EnES
        | [<JsonPropertyName("en-FI")>] EnFI
        | [<JsonPropertyName("en-FR")>] EnFR
        | [<JsonPropertyName("en-GB")>] EnGB
        | [<JsonPropertyName("en-GR")>] EnGR
        | [<JsonPropertyName("en-IE")>] EnIE
        | [<JsonPropertyName("en-IT")>] EnIT
        | [<JsonPropertyName("en-NL")>] EnNL
        | [<JsonPropertyName("en-NO")>] EnNO
        | [<JsonPropertyName("en-NZ")>] EnNZ
        | [<JsonPropertyName("en-PL")>] EnPL
        | [<JsonPropertyName("en-PT")>] EnPT
        | [<JsonPropertyName("en-RO")>] EnRO
        | [<JsonPropertyName("en-SE")>] EnSE
        | [<JsonPropertyName("en-US")>] EnUS
        | [<JsonPropertyName("es-ES")>] EsES
        | [<JsonPropertyName("es-US")>] EsUS
        | [<JsonPropertyName("fi-FI")>] FiFI
        | [<JsonPropertyName("fr-BE")>] FrBE
        | [<JsonPropertyName("fr-CA")>] FrCA
        | [<JsonPropertyName("fr-CH")>] FrCH
        | [<JsonPropertyName("fr-FR")>] FrFR
        | [<JsonPropertyName("it-CH")>] ItCH
        | [<JsonPropertyName("it-IT")>] ItIT
        | [<JsonPropertyName("nb-NO")>] NbNO
        | [<JsonPropertyName("nl-BE")>] NlBE
        | [<JsonPropertyName("nl-NL")>] NlNL
        | [<JsonPropertyName("pl-PL")>] PlPL
        | [<JsonPropertyName("pt-PT")>] PtPT
        | [<JsonPropertyName("ro-RO")>] RoRO
        | [<JsonPropertyName("sv-FI")>] SvFI
        | [<JsonPropertyName("sv-SE")>] SvSE

    type Update'PaymentMethodOptionsKlarnaSubscriptionsInterval =
        | Day
        | Month
        | Week
        | Year

    type Update'PaymentMethodOptionsKlarnaSubscriptionsNextBilling =
        {
            /// The amount of the next charge for the subscription.
            [<Config.Form>]
            Amount: int option
            /// The date of the next charge for the subscription in YYYY-MM-DD format.
            [<Config.Form>]
            Date: string option
        }

    type Update'PaymentMethodOptionsKlarnaSubscriptionsNextBilling with
        static member New(?amount: int, ?date: string) =
            {
                Amount = amount
                Date = date
            }

    type Update'PaymentMethodOptionsKlarnaSubscriptions =
        {
            /// Unit of time between subscription charges.
            [<Config.Form>]
            Interval: Update'PaymentMethodOptionsKlarnaSubscriptionsInterval option
            /// The number of intervals (specified in the `interval` attribute) between subscription charges. For example, `interval=month` and `interval_count=3` charges every 3 months.
            [<Config.Form>]
            IntervalCount: int option
            /// Name for subscription.
            [<Config.Form>]
            Name: string option
            /// Describes the upcoming charge for this subscription.
            [<Config.Form>]
            NextBilling: Update'PaymentMethodOptionsKlarnaSubscriptionsNextBilling option
            /// A non-customer-facing reference to correlate subscription charges in the Klarna app. Use a value that persists across subscription charges.
            [<Config.Form>]
            Reference: string option
        }

    type Update'PaymentMethodOptionsKlarnaSubscriptions with
        static member New(?interval: Update'PaymentMethodOptionsKlarnaSubscriptionsInterval, ?intervalCount: int, ?name: string, ?nextBilling: Update'PaymentMethodOptionsKlarnaSubscriptionsNextBilling, ?reference: string) =
            {
                Interval = interval
                IntervalCount = intervalCount
                Name = name
                NextBilling = nextBilling
                Reference = reference
            }

    type Update'PaymentMethodOptionsKlarna =
        {
            /// The currency of the SetupIntent. Three letter ISO currency code.
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// On-demand details if setting up a payment method for on-demand payments.
            [<Config.Form>]
            OnDemand: Update'PaymentMethodOptionsKlarnaOnDemand option
            /// Preferred language of the Klarna authorization page that the customer is redirected to
            [<Config.Form>]
            PreferredLocale: Update'PaymentMethodOptionsKlarnaPreferredLocale option
            /// Subscription details if setting up or charging a subscription
            [<Config.Form>]
            Subscriptions: Choice<Update'PaymentMethodOptionsKlarnaSubscriptions list,string> option
        }

    type Update'PaymentMethodOptionsKlarna with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?onDemand: Update'PaymentMethodOptionsKlarnaOnDemand, ?preferredLocale: Update'PaymentMethodOptionsKlarnaPreferredLocale, ?subscriptions: Choice<Update'PaymentMethodOptionsKlarnaSubscriptions list,string>) =
            {
                Currency = currency
                OnDemand = onDemand
                PreferredLocale = preferredLocale
                Subscriptions = subscriptions
            }

    type Update'PaymentMethodOptionsLink =
        {
            /// [Deprecated] This is a legacy parameter that no longer has any function.
            [<Config.Form>]
            PersistentToken: string option
        }

    type Update'PaymentMethodOptionsLink with
        static member New(?persistentToken: string) =
            {
                PersistentToken = persistentToken
            }

    type Update'PaymentMethodOptionsPaypal =
        {
            /// The PayPal Billing Agreement ID (BAID). This is an ID generated by PayPal which represents the mandate between the merchant and the customer.
            [<Config.Form>]
            BillingAgreementId: string option
        }

    type Update'PaymentMethodOptionsPaypal with
        static member New(?billingAgreementId: string) =
            {
                BillingAgreementId = billingAgreementId
            }

    type Update'PaymentMethodOptionsPaytoMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Update'PaymentMethodOptionsPaytoMandateOptionsPaymentSchedule =
        | Adhoc
        | Annual
        | Daily
        | Fortnightly
        | Monthly
        | Quarterly
        | SemiAnnual
        | Weekly

    type Update'PaymentMethodOptionsPaytoMandateOptionsPurpose =
        | DependantSupport
        | Government
        | Loan
        | Mortgage
        | Other
        | Pension
        | Personal
        | Retail
        | Salary
        | Tax
        | Utility

    type Update'PaymentMethodOptionsPaytoMandateOptions =
        {
            /// Amount that will be collected. It is required when `amount_type` is `fixed`.
            [<Config.Form>]
            Amount: Choice<int,string> option
            /// The type of amount that will be collected. The amount charged must be exact or up to the value of `amount` param for `fixed` or `maximum` type respectively. Defaults to `maximum`.
            [<Config.Form>]
            AmountType: Update'PaymentMethodOptionsPaytoMandateOptionsAmountType option
            /// Date, in YYYY-MM-DD format, after which payments will not be collected. Defaults to no end date.
            [<Config.Form>]
            EndDate: Choice<string,string> option
            /// The periodicity at which payments will be collected. Defaults to `adhoc`.
            [<Config.Form>]
            PaymentSchedule: Update'PaymentMethodOptionsPaytoMandateOptionsPaymentSchedule option
            /// The number of payments that will be made during a payment period. Defaults to 1 except for when `payment_schedule` is `adhoc`. In that case, it defaults to no limit.
            [<Config.Form>]
            PaymentsPerPeriod: Choice<int,string> option
            /// The purpose for which payments are made. Has a default value based on your merchant category code.
            [<Config.Form>]
            Purpose: Update'PaymentMethodOptionsPaytoMandateOptionsPurpose option
            /// Date, in YYYY-MM-DD format, from which payments will be collected. Defaults to confirmation time.
            [<Config.Form>]
            StartDate: Choice<string,string> option
        }

    type Update'PaymentMethodOptionsPaytoMandateOptions with
        static member New(?amount: Choice<int,string>, ?amountType: Update'PaymentMethodOptionsPaytoMandateOptionsAmountType, ?endDate: Choice<string,string>, ?paymentSchedule: Update'PaymentMethodOptionsPaytoMandateOptionsPaymentSchedule, ?paymentsPerPeriod: Choice<int,string>, ?purpose: Update'PaymentMethodOptionsPaytoMandateOptionsPurpose, ?startDate: Choice<string,string>) =
            {
                Amount = amount
                AmountType = amountType
                EndDate = endDate
                PaymentSchedule = paymentSchedule
                PaymentsPerPeriod = paymentsPerPeriod
                Purpose = purpose
                StartDate = startDate
            }

    type Update'PaymentMethodOptionsPayto =
        {
            /// Additional fields for Mandate creation.
            [<Config.Form>]
            MandateOptions: Update'PaymentMethodOptionsPaytoMandateOptions option
        }

    type Update'PaymentMethodOptionsPayto with
        static member New(?mandateOptions: Update'PaymentMethodOptionsPaytoMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Update'PaymentMethodOptionsPixMandateOptionsAmountIncludesIof =
        | Always
        | Never

    type Update'PaymentMethodOptionsPixMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Update'PaymentMethodOptionsPixMandateOptionsPaymentSchedule =
        | Halfyearly
        | Monthly
        | Quarterly
        | Weekly
        | Yearly

    type Update'PaymentMethodOptionsPixMandateOptions =
        {
            /// Amount to be charged for future payments. Required when `amount_type=fixed`. If not provided for `amount_type=maximum`, defaults to 40000.
            [<Config.Form>]
            Amount: int option
            /// Determines if the amount includes the IOF tax. Defaults to `never`.
            [<Config.Form>]
            AmountIncludesIof: Update'PaymentMethodOptionsPixMandateOptionsAmountIncludesIof option
            /// Type of amount. Defaults to `maximum`.
            [<Config.Form>]
            AmountType: Update'PaymentMethodOptionsPixMandateOptionsAmountType option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Only `brl` is supported currently.
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// Date when the mandate expires and no further payments will be charged, in `YYYY-MM-DD`. If not provided, the mandate will be active until canceled. If provided, end date should be after start date.
            [<Config.Form>]
            EndDate: string option
            /// Schedule at which the future payments will be charged. Defaults to `monthly`.
            [<Config.Form>]
            PaymentSchedule: Update'PaymentMethodOptionsPixMandateOptionsPaymentSchedule option
            /// Subscription name displayed to buyers in their bank app. Defaults to the displayable business name.
            [<Config.Form>]
            Reference: string option
            /// Start date of the mandate, in `YYYY-MM-DD`. Start date should be at least 3 days in the future. Defaults to 3 days after the current date.
            [<Config.Form>]
            StartDate: string option
        }

    type Update'PaymentMethodOptionsPixMandateOptions with
        static member New(?amount: int, ?amountIncludesIof: Update'PaymentMethodOptionsPixMandateOptionsAmountIncludesIof, ?amountType: Update'PaymentMethodOptionsPixMandateOptionsAmountType, ?currency: IsoTypes.IsoCurrencyCode, ?endDate: string, ?paymentSchedule: Update'PaymentMethodOptionsPixMandateOptionsPaymentSchedule, ?reference: string, ?startDate: string) =
            {
                Amount = amount
                AmountIncludesIof = amountIncludesIof
                AmountType = amountType
                Currency = currency
                EndDate = endDate
                PaymentSchedule = paymentSchedule
                Reference = reference
                StartDate = startDate
            }

    type Update'PaymentMethodOptionsPix =
        {
            /// Additional fields for mandate creation.
            [<Config.Form>]
            MandateOptions: Update'PaymentMethodOptionsPixMandateOptions option
        }

    type Update'PaymentMethodOptionsPix with
        static member New(?mandateOptions: Update'PaymentMethodOptionsPixMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Update'PaymentMethodOptionsSepaDebitMandateOptions =
        {
            /// Prefix used to generate the Mandate reference. Must be at most 12 characters long. Must consist of only uppercase letters, numbers, spaces, or the following special characters: '/', '_', '-', '&', '.'. Cannot begin with 'STRIPE'.
            [<Config.Form>]
            ReferencePrefix: Choice<string,string> option
        }

    type Update'PaymentMethodOptionsSepaDebitMandateOptions with
        static member New(?referencePrefix: Choice<string,string>) =
            {
                ReferencePrefix = referencePrefix
            }

    type Update'PaymentMethodOptionsSepaDebit =
        {
            /// Additional fields for Mandate creation
            [<Config.Form>]
            MandateOptions: Update'PaymentMethodOptionsSepaDebitMandateOptions option
        }

    type Update'PaymentMethodOptionsSepaDebit with
        static member New(?mandateOptions: Update'PaymentMethodOptionsSepaDebitMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Update'PaymentMethodOptionsUpiMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Update'PaymentMethodOptionsUpiMandateOptions =
        {
            /// Amount to be charged for future payments.
            [<Config.Form>]
            Amount: int option
            /// One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
            [<Config.Form>]
            AmountType: Update'PaymentMethodOptionsUpiMandateOptionsAmountType option
            /// A description of the mandate or subscription that is meant to be displayed to the customer.
            [<Config.Form>]
            Description: string option
            /// End date of the mandate or subscription.
            [<Config.Form>]
            EndDate: DateTime option
        }

    type Update'PaymentMethodOptionsUpiMandateOptions with
        static member New(?amount: int, ?amountType: Update'PaymentMethodOptionsUpiMandateOptionsAmountType, ?description: string, ?endDate: DateTime) =
            {
                Amount = amount
                AmountType = amountType
                Description = description
                EndDate = endDate
            }

    type Update'PaymentMethodOptionsUpiSetupFutureUsage =
        | [<JsonPropertyName("none")>] None'
        | OffSession
        | OnSession

    type Update'PaymentMethodOptionsUpi =
        {
            /// Configuration options for setting up an eMandate
            [<Config.Form>]
            MandateOptions: Update'PaymentMethodOptionsUpiMandateOptions option
            [<Config.Form>]
            SetupFutureUsage: Update'PaymentMethodOptionsUpiSetupFutureUsage option
        }

    type Update'PaymentMethodOptionsUpi with
        static member New(?mandateOptions: Update'PaymentMethodOptionsUpiMandateOptions, ?setupFutureUsage: Update'PaymentMethodOptionsUpiSetupFutureUsage) =
            {
                MandateOptions = mandateOptions
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsUsBankAccountFinancialConnectionsFiltersAccountSubcategories =
        | Checking
        | Savings

    type Update'PaymentMethodOptionsUsBankAccountFinancialConnectionsFilters =
        {
            /// The account subcategories to use to filter for selectable accounts. Valid subcategories are `checking` and `savings`.
            [<Config.Form>]
            AccountSubcategories:
                Update'PaymentMethodOptionsUsBankAccountFinancialConnectionsFiltersAccountSubcategories list option
        }

    type Update'PaymentMethodOptionsUsBankAccountFinancialConnectionsFilters with
        static member New(?accountSubcategories: Update'PaymentMethodOptionsUsBankAccountFinancialConnectionsFiltersAccountSubcategories list) =
            {
                AccountSubcategories = accountSubcategories
            }

    type Update'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions =
        | Balances
        | Ownership
        | PaymentMethod
        | Transactions

    type Update'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch =
        | Balances
        | Ownership
        | Transactions

    type Update'PaymentMethodOptionsUsBankAccountFinancialConnections =
        {
            /// Provide filters for the linked accounts that the customer can select for the payment method.
            [<Config.Form>]
            Filters: Update'PaymentMethodOptionsUsBankAccountFinancialConnectionsFilters option
            /// The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.
            [<Config.Form>]
            Permissions: Update'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions list option
            /// List of data features that you would like to retrieve upon account creation.
            [<Config.Form>]
            Prefetch: Update'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch list option
            /// For webview integrations only. Upon completing OAuth login in the native browser, the user will be redirected to this URL to return to your app.
            [<Config.Form>]
            ReturnUrl: string option
        }

    type Update'PaymentMethodOptionsUsBankAccountFinancialConnections with
        static member New(?filters: Update'PaymentMethodOptionsUsBankAccountFinancialConnectionsFilters, ?permissions: Update'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions list, ?prefetch: Update'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch list, ?returnUrl: string) =
            {
                Filters = filters
                Permissions = permissions
                Prefetch = prefetch
                ReturnUrl = returnUrl
            }

    type Update'PaymentMethodOptionsUsBankAccountMandateOptionsCollectionMethod = | Paper

    type Update'PaymentMethodOptionsUsBankAccountMandateOptions =
        {
            /// The method used to collect offline mandate customer acceptance.
            [<Config.Form>]
            CollectionMethod: Update'PaymentMethodOptionsUsBankAccountMandateOptionsCollectionMethod option
        }

    type Update'PaymentMethodOptionsUsBankAccountMandateOptions with
        static member New(?collectionMethod: Update'PaymentMethodOptionsUsBankAccountMandateOptionsCollectionMethod) =
            {
                CollectionMethod = collectionMethod
            }

    type Update'PaymentMethodOptionsUsBankAccountNetworksRequested =
        | Ach
        | UsDomesticWire

    type Update'PaymentMethodOptionsUsBankAccountNetworks =
        {
            /// Triggers validations to run across the selected networks
            [<Config.Form>]
            Requested: Update'PaymentMethodOptionsUsBankAccountNetworksRequested list option
        }

    type Update'PaymentMethodOptionsUsBankAccountNetworks with
        static member New(?requested: Update'PaymentMethodOptionsUsBankAccountNetworksRequested list) =
            {
                Requested = requested
            }

    type Update'PaymentMethodOptionsUsBankAccountVerificationMethod =
        | Automatic
        | Instant
        | Microdeposits

    type Update'PaymentMethodOptionsUsBankAccount =
        {
            /// Additional fields for Financial Connections Session creation
            [<Config.Form>]
            FinancialConnections: Update'PaymentMethodOptionsUsBankAccountFinancialConnections option
            /// Additional fields for Mandate creation
            [<Config.Form>]
            MandateOptions: Update'PaymentMethodOptionsUsBankAccountMandateOptions option
            /// Additional fields for network related functions
            [<Config.Form>]
            Networks: Update'PaymentMethodOptionsUsBankAccountNetworks option
            /// Bank account verification method. The default value is `automatic`.
            [<Config.Form>]
            VerificationMethod: Update'PaymentMethodOptionsUsBankAccountVerificationMethod option
        }

    type Update'PaymentMethodOptionsUsBankAccount with
        static member New(?financialConnections: Update'PaymentMethodOptionsUsBankAccountFinancialConnections, ?mandateOptions: Update'PaymentMethodOptionsUsBankAccountMandateOptions, ?networks: Update'PaymentMethodOptionsUsBankAccountNetworks, ?verificationMethod: Update'PaymentMethodOptionsUsBankAccountVerificationMethod) =
            {
                FinancialConnections = financialConnections
                MandateOptions = mandateOptions
                Networks = networks
                VerificationMethod = verificationMethod
            }

    type Update'PaymentMethodOptions =
        {
            /// If this is a `acss_debit` SetupIntent, this sub-hash contains details about the ACSS Debit payment method options.
            [<Config.Form>]
            AcssDebit: Update'PaymentMethodOptionsAcssDebit option
            /// If this is a `amazon_pay` SetupIntent, this sub-hash contains details about the AmazonPay payment method options.
            [<Config.Form>]
            AmazonPay: string option
            /// If this is a `bacs_debit` SetupIntent, this sub-hash contains details about the Bacs Debit payment method options.
            [<Config.Form>]
            BacsDebit: Update'PaymentMethodOptionsBacsDebit option
            /// Configuration for any card setup attempted on this SetupIntent.
            [<Config.Form>]
            Card: Update'PaymentMethodOptionsCard option
            /// If this is a `card_present` PaymentMethod, this sub-hash contains details about the card-present payment method options.
            [<Config.Form>]
            CardPresent: string option
            /// If this is a `klarna` PaymentMethod, this hash contains details about the Klarna payment method options.
            [<Config.Form>]
            Klarna: Update'PaymentMethodOptionsKlarna option
            /// If this is a `link` PaymentMethod, this sub-hash contains details about the Link payment method options.
            [<Config.Form>]
            Link: Update'PaymentMethodOptionsLink option
            /// If this is a `paypal` PaymentMethod, this sub-hash contains details about the PayPal payment method options.
            [<Config.Form>]
            Paypal: Update'PaymentMethodOptionsPaypal option
            /// If this is a `payto` SetupIntent, this sub-hash contains details about the PayTo payment method options.
            [<Config.Form>]
            Payto: Update'PaymentMethodOptionsPayto option
            /// If this is a `pix` SetupIntent, this sub-hash contains details about the Pix payment method options.
            [<Config.Form>]
            Pix: Update'PaymentMethodOptionsPix option
            /// If this is a `sepa_debit` SetupIntent, this sub-hash contains details about the SEPA Debit payment method options.
            [<Config.Form>]
            SepaDebit: Update'PaymentMethodOptionsSepaDebit option
            /// If this is a `upi` SetupIntent, this sub-hash contains details about the UPI payment method options.
            [<Config.Form>]
            Upi: Update'PaymentMethodOptionsUpi option
            /// If this is a `us_bank_account` SetupIntent, this sub-hash contains details about the US bank account payment method options.
            [<Config.Form>]
            UsBankAccount: Update'PaymentMethodOptionsUsBankAccount option
        }

    type Update'PaymentMethodOptions with
        static member New(?acssDebit: Update'PaymentMethodOptionsAcssDebit, ?amazonPay: string, ?bacsDebit: Update'PaymentMethodOptionsBacsDebit, ?card: Update'PaymentMethodOptionsCard, ?cardPresent: string, ?klarna: Update'PaymentMethodOptionsKlarna, ?link: Update'PaymentMethodOptionsLink, ?paypal: Update'PaymentMethodOptionsPaypal, ?payto: Update'PaymentMethodOptionsPayto, ?pix: Update'PaymentMethodOptionsPix, ?sepaDebit: Update'PaymentMethodOptionsSepaDebit, ?upi: Update'PaymentMethodOptionsUpi, ?usBankAccount: Update'PaymentMethodOptionsUsBankAccount) =
            {
                AcssDebit = acssDebit
                AmazonPay = amazonPay
                BacsDebit = bacsDebit
                Card = card
                CardPresent = cardPresent
                Klarna = klarna
                Link = link
                Paypal = paypal
                Payto = payto
                Pix = pix
                SepaDebit = sepaDebit
                Upi = upi
                UsBankAccount = usBankAccount
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Intent: string
            /// If present, the SetupIntent's payment method will be attached to the in-context Stripe Account.
            /// It can only be used for this Stripe Account’s own money movement flows like InboundTransfer and OutboundTransfers. It cannot be set to true when setting up a PaymentMethod for a Customer, and defaults to false when attaching a PaymentMethod to a Customer.
            [<Config.Form>]
            AttachToSelf: bool option
            /// ID of the Customer this SetupIntent belongs to, if one exists.
            /// If present, the SetupIntent's payment method will be attached to the Customer on successful setup. Payment methods attached to other Customers cannot be used with this SetupIntent.
            [<Config.Form>]
            Customer: string option
            /// ID of the Account this SetupIntent belongs to, if one exists.
            /// If present, the SetupIntent's payment method will be attached to the Account on successful setup. Payment methods attached to other Accounts cannot be used with this SetupIntent.
            [<Config.Form>]
            CustomerAccount: string option
            /// An arbitrary string attached to the object. Often useful for displaying to users.
            [<Config.Form>]
            Description: string option
            /// The list of payment method types to exclude from use with this SetupIntent.
            [<Config.Form>]
            ExcludedPaymentMethodTypes: Choice<Update'ExcludedPaymentMethodTypes list,string> option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Indicates the directions of money movement for which this payment method is intended to be used.
            /// Include `inbound` if you intend to use the payment method as the origin to pull funds from. Include `outbound` if you intend to use the payment method as the destination to send funds to. You can include both if you intend to use the payment method for both purposes.
            [<Config.Form>]
            FlowDirections: Update'FlowDirections list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// ID of the payment method (a PaymentMethod, Card, or saved Source object) to attach to this SetupIntent. To unset this field to null, pass in an empty string.
            [<Config.Form>]
            PaymentMethod: string option
            /// The ID of the [payment method configuration](https://docs.stripe.com/api/payment_method_configurations) to use with this SetupIntent.
            [<Config.Form>]
            PaymentMethodConfiguration: string option
            /// When included, this hash creates a PaymentMethod that is set as the [`payment_method`](https://docs.stripe.com/api/setup_intents/object#setup_intent_object-payment_method)
            /// value in the SetupIntent.
            [<Config.Form>]
            PaymentMethodData: Update'PaymentMethodData option
            /// Payment method-specific configuration for this SetupIntent.
            [<Config.Form>]
            PaymentMethodOptions: Update'PaymentMethodOptions option
            /// The list of payment method types (for example, card) that this SetupIntent can set up. If you don't provide this, Stripe will dynamically show relevant payment methods from your [payment method settings](https://dashboard.stripe.com/settings/payment_methods). A list of valid payment method types can be found [here](https://docs.stripe.com/api/payment_methods/object#payment_method_object-type).
            [<Config.Form>]
            PaymentMethodTypes: string list option
        }

    type UpdateOptions with
        static member New(intent: string, ?attachToSelf: bool, ?customer: string, ?customerAccount: string, ?description: string, ?excludedPaymentMethodTypes: Choice<Update'ExcludedPaymentMethodTypes list,string>, ?expand: string list, ?flowDirections: Update'FlowDirections list, ?metadata: Map<string, string>, ?paymentMethod: string, ?paymentMethodConfiguration: string, ?paymentMethodData: Update'PaymentMethodData, ?paymentMethodOptions: Update'PaymentMethodOptions, ?paymentMethodTypes: string list) =
            {
                Intent = intent
                AttachToSelf = attachToSelf
                Customer = customer
                CustomerAccount = customerAccount
                Description = description
                ExcludedPaymentMethodTypes = excludedPaymentMethodTypes
                Expand = expand
                FlowDirections = flowDirections
                Metadata = metadata
                PaymentMethod = paymentMethod
                PaymentMethodConfiguration = paymentMethodConfiguration
                PaymentMethodData = paymentMethodData
                PaymentMethodOptions = paymentMethodOptions
                PaymentMethodTypes = paymentMethodTypes
            }

    ///<p>Returns a list of SetupIntents.</p>
    let List settings (options: ListOptions) =
        let qs = [("attach_to_self", options.AttachToSelf |> box); ("created", options.Created |> box); ("customer", options.Customer |> box); ("customer_account", options.CustomerAccount |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("payment_method", options.PaymentMethod |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/setup_intents"
        |> RestApi.getAsync<StripeList<SetupIntent>> settings qs

    ///<p>Creates a SetupIntent object.</p>
    ///<p>After you create the SetupIntent, attach a payment method and <a href="/docs/api/setup_intents/confirm">confirm</a>
    ///it to collect any required permissions to charge the payment method later.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/setup_intents"
        |> RestApi.postAsync<_, SetupIntent> settings (Map.empty) options

    ///<p>Retrieves the details of a SetupIntent that has previously been created. </p>
    ///<p>Client-side retrieval using a publishable key is allowed when the <code>client_secret</code> is provided in the query string. </p>
    ///<p>When retrieved with a publishable key, only a subset of properties will be returned. Please refer to the <a href="#setup_intent_object">SetupIntent</a> object reference for more details.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("client_secret", options.ClientSecret |> box); ("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/setup_intents/{options.Intent}"
        |> RestApi.getAsync<SetupIntent> settings qs

    ///<p>Updates a SetupIntent object.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/setup_intents/{options.Intent}"
        |> RestApi.postAsync<_, SetupIntent> settings (Map.empty) options

module SetupIntentsCancel =

    type Cancel'CancellationReason =
        | Abandoned
        | Duplicate
        | RequestedByCustomer

    type CancelOptions =
        {
            [<Config.Path>]
            Intent: string
            /// Reason for canceling this SetupIntent. Possible values are: `abandoned`, `requested_by_customer`, or `duplicate`
            [<Config.Form>]
            CancellationReason: Cancel'CancellationReason option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type CancelOptions with
        static member New(intent: string, ?cancellationReason: Cancel'CancellationReason, ?expand: string list) =
            {
                Intent = intent
                CancellationReason = cancellationReason
                Expand = expand
            }

    ///<p>You can cancel a SetupIntent object when it’s in one of these statuses: <code>requires_payment_method</code>, <code>requires_confirmation</code>, or <code>requires_action</code>. </p>
    ///<p>After you cancel it, setup is abandoned and any operations on the SetupIntent fail with an error. You can’t cancel the SetupIntent for a Checkout Session. <a href="/docs/api/checkout/sessions/expire">Expire the Checkout Session</a> instead.</p>
    let Cancel settings (options: CancelOptions) =
        $"/v1/setup_intents/{options.Intent}/cancel"
        |> RestApi.postAsync<_, SetupIntent> settings (Map.empty) options

module SetupIntentsConfirm =

    type Confirm'MandateDataSecretKeyCustomerAcceptanceOnline =
        {
            /// The IP address from which the Mandate was accepted by the customer.
            [<Config.Form>]
            IpAddress: string option
            /// The user agent of the browser from which the Mandate was accepted by the customer.
            [<Config.Form>]
            UserAgent: string option
        }

    type Confirm'MandateDataSecretKeyCustomerAcceptanceOnline with
        static member New(?ipAddress: string, ?userAgent: string) =
            {
                IpAddress = ipAddress
                UserAgent = userAgent
            }

    type Confirm'MandateDataSecretKeyCustomerAcceptanceType =
        | Offline
        | Online

    type Confirm'MandateDataSecretKeyCustomerAcceptance =
        {
            /// The time at which the customer accepted the Mandate.
            [<Config.Form>]
            AcceptedAt: DateTime option
            /// If this is a Mandate accepted offline, this hash contains details about the offline acceptance.
            [<Config.Form>]
            Offline: string option
            /// If this is a Mandate accepted online, this hash contains details about the online acceptance.
            [<Config.Form>]
            Online: Confirm'MandateDataSecretKeyCustomerAcceptanceOnline option
            /// The type of customer acceptance information included with the Mandate. One of `online` or `offline`.
            [<Config.Form>]
            Type: Confirm'MandateDataSecretKeyCustomerAcceptanceType option
        }

    type Confirm'MandateDataSecretKeyCustomerAcceptance with
        static member New(?acceptedAt: DateTime, ?offline: string, ?online: Confirm'MandateDataSecretKeyCustomerAcceptanceOnline, ?type': Confirm'MandateDataSecretKeyCustomerAcceptanceType) =
            {
                AcceptedAt = acceptedAt
                Offline = offline
                Online = online
                Type = type'
            }

    type Confirm'MandateDataSecretKey =
        {
            /// This hash contains details about the customer acceptance of the Mandate.
            [<Config.Form>]
            CustomerAcceptance: Confirm'MandateDataSecretKeyCustomerAcceptance option
        }

    type Confirm'MandateDataSecretKey with
        static member New(?customerAcceptance: Confirm'MandateDataSecretKeyCustomerAcceptance) =
            {
                CustomerAcceptance = customerAcceptance
            }

    type Confirm'MandateDataClientKeyCustomerAcceptanceOnline =
        {
            /// The IP address from which the Mandate was accepted by the customer.
            [<Config.Form>]
            IpAddress: string option
            /// The user agent of the browser from which the Mandate was accepted by the customer.
            [<Config.Form>]
            UserAgent: string option
        }

    type Confirm'MandateDataClientKeyCustomerAcceptanceOnline with
        static member New(?ipAddress: string, ?userAgent: string) =
            {
                IpAddress = ipAddress
                UserAgent = userAgent
            }

    type Confirm'MandateDataClientKeyCustomerAcceptanceType = | Online

    type Confirm'MandateDataClientKeyCustomerAcceptance =
        {
            /// If this is a Mandate accepted online, this hash contains details about the online acceptance.
            [<Config.Form>]
            Online: Confirm'MandateDataClientKeyCustomerAcceptanceOnline option
            /// The type of customer acceptance information included with the Mandate.
            [<Config.Form>]
            Type: Confirm'MandateDataClientKeyCustomerAcceptanceType option
        }

    type Confirm'MandateDataClientKeyCustomerAcceptance with
        static member New(?online: Confirm'MandateDataClientKeyCustomerAcceptanceOnline, ?type': Confirm'MandateDataClientKeyCustomerAcceptanceType) =
            {
                Online = online
                Type = type'
            }

    type Confirm'MandateDataClientKey =
        {
            /// This hash contains details about the customer acceptance of the Mandate.
            [<Config.Form>]
            CustomerAcceptance: Confirm'MandateDataClientKeyCustomerAcceptance option
        }

    type Confirm'MandateDataClientKey with
        static member New(?customerAcceptance: Confirm'MandateDataClientKeyCustomerAcceptance) =
            {
                CustomerAcceptance = customerAcceptance
            }

    type Confirm'PaymentMethodDataAcssDebit =
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

    type Confirm'PaymentMethodDataAcssDebit with
        static member New(?accountNumber: string, ?institutionNumber: string, ?transitNumber: string) =
            {
                AccountNumber = accountNumber
                InstitutionNumber = institutionNumber
                TransitNumber = transitNumber
            }

    type Confirm'PaymentMethodDataAllowRedisplay =
        | Always
        | Limited
        | Unspecified

    type Confirm'PaymentMethodDataAuBecsDebit =
        {
            /// The account number for the bank account.
            [<Config.Form>]
            AccountNumber: string option
            /// Bank-State-Branch number of the bank account.
            [<Config.Form>]
            BsbNumber: string option
        }

    type Confirm'PaymentMethodDataAuBecsDebit with
        static member New(?accountNumber: string, ?bsbNumber: string) =
            {
                AccountNumber = accountNumber
                BsbNumber = bsbNumber
            }

    type Confirm'PaymentMethodDataBacsDebit =
        {
            /// Account number of the bank account that the funds will be debited from.
            [<Config.Form>]
            AccountNumber: string option
            /// Sort code of the bank account. (e.g., `10-20-30`)
            [<Config.Form>]
            SortCode: string option
        }

    type Confirm'PaymentMethodDataBacsDebit with
        static member New(?accountNumber: string, ?sortCode: string) =
            {
                AccountNumber = accountNumber
                SortCode = sortCode
            }

    type Confirm'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress =
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

    type Confirm'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Confirm'PaymentMethodDataBillingDetails =
        {
            /// Billing address.
            [<Config.Form>]
            Address: Choice<Confirm'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string> option
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

    type Confirm'PaymentMethodDataBillingDetails with
        static member New(?address: Choice<Confirm'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string>, ?email: Choice<string,string>, ?name: Choice<string,string>, ?phone: Choice<string,string>, ?taxId: string) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
                TaxId = taxId
            }

    type Confirm'PaymentMethodDataBoleto =
        {
            /// The tax ID of the customer (CPF for individual consumers or CNPJ for businesses consumers)
            [<Config.Form>]
            TaxId: string option
        }

    type Confirm'PaymentMethodDataBoleto with
        static member New(?taxId: string) =
            {
                TaxId = taxId
            }

    type Confirm'PaymentMethodDataEpsBank =
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

    type Confirm'PaymentMethodDataEps =
        {
            /// The customer's bank.
            [<Config.Form>]
            Bank: Confirm'PaymentMethodDataEpsBank option
        }

    type Confirm'PaymentMethodDataEps with
        static member New(?bank: Confirm'PaymentMethodDataEpsBank) =
            {
                Bank = bank
            }

    type Confirm'PaymentMethodDataFpxAccountHolderType =
        | Company
        | Individual

    type Confirm'PaymentMethodDataFpxBank =
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

    type Confirm'PaymentMethodDataFpx =
        {
            /// Account holder type for FPX transaction
            [<Config.Form>]
            AccountHolderType: Confirm'PaymentMethodDataFpxAccountHolderType option
            /// The customer's bank.
            [<Config.Form>]
            Bank: Confirm'PaymentMethodDataFpxBank option
        }

    type Confirm'PaymentMethodDataFpx with
        static member New(?accountHolderType: Confirm'PaymentMethodDataFpxAccountHolderType, ?bank: Confirm'PaymentMethodDataFpxBank) =
            {
                AccountHolderType = accountHolderType
                Bank = bank
            }

    type Confirm'PaymentMethodDataIdealBank =
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

    type Confirm'PaymentMethodDataIdeal =
        {
            /// The customer's bank. Only use this parameter for existing customers. Don't use it for new customers.
            [<Config.Form>]
            Bank: Confirm'PaymentMethodDataIdealBank option
        }

    type Confirm'PaymentMethodDataIdeal with
        static member New(?bank: Confirm'PaymentMethodDataIdealBank) =
            {
                Bank = bank
            }

    type Confirm'PaymentMethodDataKlarnaDob =
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

    type Confirm'PaymentMethodDataKlarnaDob with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Confirm'PaymentMethodDataKlarna =
        {
            /// Customer's date of birth
            [<Config.Form>]
            Dob: Confirm'PaymentMethodDataKlarnaDob option
        }

    type Confirm'PaymentMethodDataKlarna with
        static member New(?dob: Confirm'PaymentMethodDataKlarnaDob) =
            {
                Dob = dob
            }

    type Confirm'PaymentMethodDataNaverPayFunding =
        | Card
        | Points

    type Confirm'PaymentMethodDataNaverPay =
        {
            /// Whether to use Naver Pay points or a card to fund this transaction. If not provided, this defaults to `card`.
            [<Config.Form>]
            Funding: Confirm'PaymentMethodDataNaverPayFunding option
        }

    type Confirm'PaymentMethodDataNaverPay with
        static member New(?funding: Confirm'PaymentMethodDataNaverPayFunding) =
            {
                Funding = funding
            }

    type Confirm'PaymentMethodDataNzBankAccount =
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

    type Confirm'PaymentMethodDataNzBankAccount with
        static member New(?accountHolderName: string, ?accountNumber: string, ?bankCode: string, ?branchCode: string, ?reference: string, ?suffix: string) =
            {
                AccountHolderName = accountHolderName
                AccountNumber = accountNumber
                BankCode = bankCode
                BranchCode = branchCode
                Reference = reference
                Suffix = suffix
            }

    type Confirm'PaymentMethodDataP24Bank =
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

    type Confirm'PaymentMethodDataP24 =
        {
            /// The customer's bank.
            [<Config.Form>]
            Bank: Confirm'PaymentMethodDataP24Bank option
        }

    type Confirm'PaymentMethodDataP24 with
        static member New(?bank: Confirm'PaymentMethodDataP24Bank) =
            {
                Bank = bank
            }

    type Confirm'PaymentMethodDataPayto =
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

    type Confirm'PaymentMethodDataPayto with
        static member New(?accountNumber: string, ?bsbNumber: string, ?payId: string) =
            {
                AccountNumber = accountNumber
                BsbNumber = bsbNumber
                PayId = payId
            }

    type Confirm'PaymentMethodDataRadarOptions =
        {
            /// A [Radar Session](https://docs.stripe.com/radar/radar-session) is a snapshot of the browser metadata and device details that help Radar make more accurate predictions on your payments.
            [<Config.Form>]
            Session: string option
        }

    type Confirm'PaymentMethodDataRadarOptions with
        static member New(?session: string) =
            {
                Session = session
            }

    type Confirm'PaymentMethodDataSepaDebit =
        {
            /// IBAN of the bank account.
            [<Config.Form>]
            Iban: string option
        }

    type Confirm'PaymentMethodDataSepaDebit with
        static member New(?iban: string) =
            {
                Iban = iban
            }

    type Confirm'PaymentMethodDataSofortCountry =
        | [<JsonPropertyName("AT")>] AT
        | [<JsonPropertyName("BE")>] BE
        | [<JsonPropertyName("DE")>] DE
        | [<JsonPropertyName("ES")>] ES
        | [<JsonPropertyName("IT")>] IT
        | [<JsonPropertyName("NL")>] NL

    type Confirm'PaymentMethodDataSofort =
        {
            /// Two-letter ISO code representing the country the bank account is located in.
            [<Config.Form>]
            Country: Confirm'PaymentMethodDataSofortCountry option
        }

    type Confirm'PaymentMethodDataSofort with
        static member New(?country: Confirm'PaymentMethodDataSofortCountry) =
            {
                Country = country
            }

    type Confirm'PaymentMethodDataType =
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

    type Confirm'PaymentMethodDataUpiMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Confirm'PaymentMethodDataUpiMandateOptions =
        {
            /// Amount to be charged for future payments.
            [<Config.Form>]
            Amount: int option
            /// One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
            [<Config.Form>]
            AmountType: Confirm'PaymentMethodDataUpiMandateOptionsAmountType option
            /// A description of the mandate or subscription that is meant to be displayed to the customer.
            [<Config.Form>]
            Description: string option
            /// End date of the mandate or subscription.
            [<Config.Form>]
            EndDate: DateTime option
        }

    type Confirm'PaymentMethodDataUpiMandateOptions with
        static member New(?amount: int, ?amountType: Confirm'PaymentMethodDataUpiMandateOptionsAmountType, ?description: string, ?endDate: DateTime) =
            {
                Amount = amount
                AmountType = amountType
                Description = description
                EndDate = endDate
            }

    type Confirm'PaymentMethodDataUpi =
        {
            /// Configuration options for setting up an eMandate
            [<Config.Form>]
            MandateOptions: Confirm'PaymentMethodDataUpiMandateOptions option
        }

    type Confirm'PaymentMethodDataUpi with
        static member New(?mandateOptions: Confirm'PaymentMethodDataUpiMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Confirm'PaymentMethodDataUsBankAccountAccountHolderType =
        | Company
        | Individual

    type Confirm'PaymentMethodDataUsBankAccountAccountType =
        | Checking
        | Savings

    type Confirm'PaymentMethodDataUsBankAccount =
        {
            /// Account holder type: individual or company.
            [<Config.Form>]
            AccountHolderType: Confirm'PaymentMethodDataUsBankAccountAccountHolderType option
            /// Account number of the bank account.
            [<Config.Form>]
            AccountNumber: string option
            /// Account type: checkings or savings. Defaults to checking if omitted.
            [<Config.Form>]
            AccountType: Confirm'PaymentMethodDataUsBankAccountAccountType option
            /// The ID of a Financial Connections Account to use as a payment method.
            [<Config.Form>]
            FinancialConnectionsAccount: string option
            /// Routing number of the bank account.
            [<Config.Form>]
            RoutingNumber: string option
        }

    type Confirm'PaymentMethodDataUsBankAccount with
        static member New(?accountHolderType: Confirm'PaymentMethodDataUsBankAccountAccountHolderType, ?accountNumber: string, ?accountType: Confirm'PaymentMethodDataUsBankAccountAccountType, ?financialConnectionsAccount: string, ?routingNumber: string) =
            {
                AccountHolderType = accountHolderType
                AccountNumber = accountNumber
                AccountType = accountType
                FinancialConnectionsAccount = financialConnectionsAccount
                RoutingNumber = routingNumber
            }

    type Confirm'PaymentMethodData =
        {
            /// If this is an `acss_debit` PaymentMethod, this hash contains details about the ACSS Debit payment method.
            [<Config.Form>]
            AcssDebit: Confirm'PaymentMethodDataAcssDebit option
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
            AllowRedisplay: Confirm'PaymentMethodDataAllowRedisplay option
            /// If this is a Alma PaymentMethod, this hash contains details about the Alma payment method.
            [<Config.Form>]
            Alma: string option
            /// If this is a AmazonPay PaymentMethod, this hash contains details about the AmazonPay payment method.
            [<Config.Form>]
            AmazonPay: string option
            /// If this is an `au_becs_debit` PaymentMethod, this hash contains details about the bank account.
            [<Config.Form>]
            AuBecsDebit: Confirm'PaymentMethodDataAuBecsDebit option
            /// If this is a `bacs_debit` PaymentMethod, this hash contains details about the Bacs Direct Debit bank account.
            [<Config.Form>]
            BacsDebit: Confirm'PaymentMethodDataBacsDebit option
            /// If this is a `bancontact` PaymentMethod, this hash contains details about the Bancontact payment method.
            [<Config.Form>]
            Bancontact: string option
            /// If this is a `billie` PaymentMethod, this hash contains details about the Billie payment method.
            [<Config.Form>]
            Billie: string option
            /// Billing information associated with the PaymentMethod that may be used or required by particular types of payment methods.
            [<Config.Form>]
            BillingDetails: Confirm'PaymentMethodDataBillingDetails option
            /// If this is a `blik` PaymentMethod, this hash contains details about the BLIK payment method.
            [<Config.Form>]
            Blik: string option
            /// If this is a `boleto` PaymentMethod, this hash contains details about the Boleto payment method.
            [<Config.Form>]
            Boleto: Confirm'PaymentMethodDataBoleto option
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
            Eps: Confirm'PaymentMethodDataEps option
            /// If this is an `fpx` PaymentMethod, this hash contains details about the FPX payment method.
            [<Config.Form>]
            Fpx: Confirm'PaymentMethodDataFpx option
            /// If this is a `giropay` PaymentMethod, this hash contains details about the Giropay payment method.
            [<Config.Form>]
            Giropay: string option
            /// If this is a `grabpay` PaymentMethod, this hash contains details about the GrabPay payment method.
            [<Config.Form>]
            Grabpay: string option
            /// If this is an `ideal` PaymentMethod, this hash contains details about the iDEAL payment method.
            [<Config.Form>]
            Ideal: Confirm'PaymentMethodDataIdeal option
            /// If this is an `interac_present` PaymentMethod, this hash contains details about the Interac Present payment method.
            [<Config.Form>]
            InteracPresent: string option
            /// If this is a `kakao_pay` PaymentMethod, this hash contains details about the Kakao Pay payment method.
            [<Config.Form>]
            KakaoPay: string option
            /// If this is a `klarna` PaymentMethod, this hash contains details about the Klarna payment method.
            [<Config.Form>]
            Klarna: Confirm'PaymentMethodDataKlarna option
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
            NaverPay: Confirm'PaymentMethodDataNaverPay option
            /// If this is an nz_bank_account PaymentMethod, this hash contains details about the nz_bank_account payment method.
            [<Config.Form>]
            NzBankAccount: Confirm'PaymentMethodDataNzBankAccount option
            /// If this is an `oxxo` PaymentMethod, this hash contains details about the OXXO payment method.
            [<Config.Form>]
            Oxxo: string option
            /// If this is a `p24` PaymentMethod, this hash contains details about the P24 payment method.
            [<Config.Form>]
            P24: Confirm'PaymentMethodDataP24 option
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
            Payto: Confirm'PaymentMethodDataPayto option
            /// If this is a `pix` PaymentMethod, this hash contains details about the Pix payment method.
            [<Config.Form>]
            Pix: string option
            /// If this is a `promptpay` PaymentMethod, this hash contains details about the PromptPay payment method.
            [<Config.Form>]
            Promptpay: string option
            /// Options to configure Radar. See [Radar Session](https://docs.stripe.com/radar/radar-session) for more information.
            [<Config.Form>]
            RadarOptions: Confirm'PaymentMethodDataRadarOptions option
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
            SepaDebit: Confirm'PaymentMethodDataSepaDebit option
            /// If this is a `sofort` PaymentMethod, this hash contains details about the SOFORT payment method.
            [<Config.Form>]
            Sofort: Confirm'PaymentMethodDataSofort option
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
            Type: Confirm'PaymentMethodDataType option
            /// If this is a `upi` PaymentMethod, this hash contains details about the UPI payment method.
            [<Config.Form>]
            Upi: Confirm'PaymentMethodDataUpi option
            /// If this is an `us_bank_account` PaymentMethod, this hash contains details about the US bank account payment method.
            [<Config.Form>]
            UsBankAccount: Confirm'PaymentMethodDataUsBankAccount option
            /// If this is an `wechat_pay` PaymentMethod, this hash contains details about the wechat_pay payment method.
            [<Config.Form>]
            WechatPay: string option
            /// If this is a `zip` PaymentMethod, this hash contains details about the Zip payment method.
            [<Config.Form>]
            Zip: string option
        }

    type Confirm'PaymentMethodData with
        static member New(?acssDebit: Confirm'PaymentMethodDataAcssDebit, ?affirm: string, ?afterpayClearpay: string, ?alipay: string, ?allowRedisplay: Confirm'PaymentMethodDataAllowRedisplay, ?alma: string, ?amazonPay: string, ?auBecsDebit: Confirm'PaymentMethodDataAuBecsDebit, ?bacsDebit: Confirm'PaymentMethodDataBacsDebit, ?bancontact: string, ?billie: string, ?billingDetails: Confirm'PaymentMethodDataBillingDetails, ?blik: string, ?boleto: Confirm'PaymentMethodDataBoleto, ?cashapp: string, ?crypto: string, ?customerBalance: string, ?eps: Confirm'PaymentMethodDataEps, ?fpx: Confirm'PaymentMethodDataFpx, ?giropay: string, ?grabpay: string, ?ideal: Confirm'PaymentMethodDataIdeal, ?interacPresent: string, ?kakaoPay: string, ?klarna: Confirm'PaymentMethodDataKlarna, ?konbini: string, ?krCard: string, ?link: string, ?mbWay: string, ?metadata: Map<string, string>, ?mobilepay: string, ?multibanco: string, ?naverPay: Confirm'PaymentMethodDataNaverPay, ?nzBankAccount: Confirm'PaymentMethodDataNzBankAccount, ?oxxo: string, ?p24: Confirm'PaymentMethodDataP24, ?payByBank: string, ?payco: string, ?paynow: string, ?paypal: string, ?payto: Confirm'PaymentMethodDataPayto, ?pix: string, ?promptpay: string, ?radarOptions: Confirm'PaymentMethodDataRadarOptions, ?revolutPay: string, ?samsungPay: string, ?satispay: string, ?sepaDebit: Confirm'PaymentMethodDataSepaDebit, ?sofort: Confirm'PaymentMethodDataSofort, ?sunbit: string, ?swish: string, ?twint: string, ?type': Confirm'PaymentMethodDataType, ?upi: Confirm'PaymentMethodDataUpi, ?usBankAccount: Confirm'PaymentMethodDataUsBankAccount, ?wechatPay: string, ?zip: string) =
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

    type Confirm'PaymentMethodOptionsAcssDebitCurrency =
        | Cad
        | Usd

    type Confirm'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor =
        | Invoice
        | Subscription

    type Confirm'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule =
        | Combined
        | Interval
        | Sporadic

    type Confirm'PaymentMethodOptionsAcssDebitMandateOptionsTransactionType =
        | Business
        | Personal

    type Confirm'PaymentMethodOptionsAcssDebitMandateOptions =
        {
            /// A URL for custom mandate text to render during confirmation step.
            /// The URL will be rendered with additional GET parameters `payment_intent` and `payment_intent_client_secret` when confirming a Payment Intent,
            /// or `setup_intent` and `setup_intent_client_secret` when confirming a Setup Intent.
            [<Config.Form>]
            CustomMandateUrl: Choice<string,string> option
            /// List of Stripe products where this mandate can be selected automatically.
            [<Config.Form>]
            DefaultFor: Confirm'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor list option
            /// Description of the mandate interval. Only required if 'payment_schedule' parameter is 'interval' or 'combined'.
            [<Config.Form>]
            IntervalDescription: string option
            /// Payment schedule for the mandate.
            [<Config.Form>]
            PaymentSchedule: Confirm'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule option
            /// Transaction type of the mandate.
            [<Config.Form>]
            TransactionType: Confirm'PaymentMethodOptionsAcssDebitMandateOptionsTransactionType option
        }

    type Confirm'PaymentMethodOptionsAcssDebitMandateOptions with
        static member New(?customMandateUrl: Choice<string,string>, ?defaultFor: Confirm'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor list, ?intervalDescription: string, ?paymentSchedule: Confirm'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule, ?transactionType: Confirm'PaymentMethodOptionsAcssDebitMandateOptionsTransactionType) =
            {
                CustomMandateUrl = customMandateUrl
                DefaultFor = defaultFor
                IntervalDescription = intervalDescription
                PaymentSchedule = paymentSchedule
                TransactionType = transactionType
            }

    type Confirm'PaymentMethodOptionsAcssDebitVerificationMethod =
        | Automatic
        | Instant
        | Microdeposits

    type Confirm'PaymentMethodOptionsAcssDebit =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: Confirm'PaymentMethodOptionsAcssDebitCurrency option
            /// Additional fields for Mandate creation
            [<Config.Form>]
            MandateOptions: Confirm'PaymentMethodOptionsAcssDebitMandateOptions option
            /// Bank account verification method. The default value is `automatic`.
            [<Config.Form>]
            VerificationMethod: Confirm'PaymentMethodOptionsAcssDebitVerificationMethod option
        }

    type Confirm'PaymentMethodOptionsAcssDebit with
        static member New(?currency: Confirm'PaymentMethodOptionsAcssDebitCurrency, ?mandateOptions: Confirm'PaymentMethodOptionsAcssDebitMandateOptions, ?verificationMethod: Confirm'PaymentMethodOptionsAcssDebitVerificationMethod) =
            {
                Currency = currency
                MandateOptions = mandateOptions
                VerificationMethod = verificationMethod
            }

    type Confirm'PaymentMethodOptionsBacsDebitMandateOptions =
        {
            /// Prefix used to generate the Mandate reference. Must be at most 12 characters long. Must consist of only uppercase letters, numbers, spaces, or the following special characters: '/', '_', '-', '&', '.'. Cannot begin with 'DDIC' or 'STRIPE'.
            [<Config.Form>]
            ReferencePrefix: Choice<string,string> option
        }

    type Confirm'PaymentMethodOptionsBacsDebitMandateOptions with
        static member New(?referencePrefix: Choice<string,string>) =
            {
                ReferencePrefix = referencePrefix
            }

    type Confirm'PaymentMethodOptionsBacsDebit =
        {
            /// Additional fields for Mandate creation
            [<Config.Form>]
            MandateOptions: Confirm'PaymentMethodOptionsBacsDebitMandateOptions option
        }

    type Confirm'PaymentMethodOptionsBacsDebit with
        static member New(?mandateOptions: Confirm'PaymentMethodOptionsBacsDebitMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Confirm'PaymentMethodOptionsCardMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Confirm'PaymentMethodOptionsCardMandateOptionsInterval =
        | Day
        | Month
        | Sporadic
        | Week
        | Year

    type Confirm'PaymentMethodOptionsCardMandateOptionsSupportedTypes = | India

    type Confirm'PaymentMethodOptionsCardMandateOptions =
        {
            /// Amount to be charged for future payments, specified in the presentment currency.
            [<Config.Form>]
            Amount: int option
            /// One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
            [<Config.Form>]
            AmountType: Confirm'PaymentMethodOptionsCardMandateOptionsAmountType option
            /// Currency in which future payments will be charged. Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// A description of the mandate or subscription that is meant to be displayed to the customer.
            [<Config.Form>]
            Description: string option
            /// End date of the mandate or subscription. If not provided, the mandate will be active until canceled. If provided, end date should be after start date.
            [<Config.Form>]
            EndDate: DateTime option
            /// Specifies payment frequency. One of `day`, `week`, `month`, `year`, or `sporadic`.
            [<Config.Form>]
            Interval: Confirm'PaymentMethodOptionsCardMandateOptionsInterval option
            /// The number of intervals between payments. For example, `interval=month` and `interval_count=3` indicates one payment every three months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks). This parameter is optional when `interval=sporadic`.
            [<Config.Form>]
            IntervalCount: int option
            /// Unique identifier for the mandate or subscription.
            [<Config.Form>]
            Reference: string option
            /// Start date of the mandate or subscription. Start date should not be lesser than yesterday.
            [<Config.Form>]
            StartDate: DateTime option
            /// Specifies the type of mandates supported. Possible values are `india`.
            [<Config.Form>]
            SupportedTypes: Confirm'PaymentMethodOptionsCardMandateOptionsSupportedTypes list option
        }

    type Confirm'PaymentMethodOptionsCardMandateOptions with
        static member New(?amount: int, ?amountType: Confirm'PaymentMethodOptionsCardMandateOptionsAmountType, ?currency: IsoTypes.IsoCurrencyCode, ?description: string, ?endDate: DateTime, ?interval: Confirm'PaymentMethodOptionsCardMandateOptionsInterval, ?intervalCount: int, ?reference: string, ?startDate: DateTime, ?supportedTypes: Confirm'PaymentMethodOptionsCardMandateOptionsSupportedTypes list) =
            {
                Amount = amount
                AmountType = amountType
                Currency = currency
                Description = description
                EndDate = endDate
                Interval = interval
                IntervalCount = intervalCount
                Reference = reference
                StartDate = startDate
                SupportedTypes = supportedTypes
            }

    type Confirm'PaymentMethodOptionsCardNetwork =
        | Amex
        | CartesBancaires
        | Diners
        | Discover
        | EftposAu
        | Girocard
        | Interac
        | Jcb
        | Link
        | Mastercard
        | Unionpay
        | Unknown
        | Visa

    type Confirm'PaymentMethodOptionsCardRequestThreeDSecure =
        | Any
        | Automatic
        | Challenge

    type Confirm'PaymentMethodOptionsCardThreeDSecureAresTransStatus =
        | [<JsonPropertyName("A")>] A
        | [<JsonPropertyName("C")>] C
        | [<JsonPropertyName("I")>] I
        | [<JsonPropertyName("N")>] N
        | [<JsonPropertyName("R")>] R
        | [<JsonPropertyName("U")>] U
        | [<JsonPropertyName("Y")>] Y

    type Confirm'PaymentMethodOptionsCardThreeDSecureElectronicCommerceIndicator =
        | [<JsonPropertyName("01")>] Numeric01
        | [<JsonPropertyName("02")>] Numeric02
        | [<JsonPropertyName("05")>] Numeric05
        | [<JsonPropertyName("06")>] Numeric06
        | [<JsonPropertyName("07")>] Numeric07

    type Confirm'PaymentMethodOptionsCardThreeDSecureNetworkOptionsCartesBancairesCbAvalgo =
        | [<JsonPropertyName("0")>] Numeric0
        | [<JsonPropertyName("1")>] Numeric1
        | [<JsonPropertyName("2")>] Numeric2
        | [<JsonPropertyName("3")>] Numeric3
        | [<JsonPropertyName("4")>] Numeric4
        | [<JsonPropertyName("A")>] A

    type Confirm'PaymentMethodOptionsCardThreeDSecureNetworkOptionsCartesBancaires =
        {
            /// The cryptogram calculation algorithm used by the card Issuer's ACS
            /// to calculate the Authentication cryptogram. Also known as `cavvAlgorithm`.
            /// messageExtension: CB-AVALGO
            [<Config.Form>]
            CbAvalgo: Confirm'PaymentMethodOptionsCardThreeDSecureNetworkOptionsCartesBancairesCbAvalgo option
            /// The exemption indicator returned from Cartes Bancaires in the ARes.
            /// message extension: CB-EXEMPTION; string (4 characters)
            /// This is a 3 byte bitmap (low significant byte first and most significant
            /// bit first) that has been Base64 encoded
            [<Config.Form>]
            CbExemption: string option
            /// The risk score returned from Cartes Bancaires in the ARes.
            /// message extension: CB-SCORE; numeric value 0-99
            [<Config.Form>]
            CbScore: int option
        }

    type Confirm'PaymentMethodOptionsCardThreeDSecureNetworkOptionsCartesBancaires with
        static member New(?cbAvalgo: Confirm'PaymentMethodOptionsCardThreeDSecureNetworkOptionsCartesBancairesCbAvalgo, ?cbExemption: string, ?cbScore: int) =
            {
                CbAvalgo = cbAvalgo
                CbExemption = cbExemption
                CbScore = cbScore
            }

    type Confirm'PaymentMethodOptionsCardThreeDSecureNetworkOptions =
        {
            /// Cartes Bancaires-specific 3DS fields.
            [<Config.Form>]
            CartesBancaires: Confirm'PaymentMethodOptionsCardThreeDSecureNetworkOptionsCartesBancaires option
        }

    type Confirm'PaymentMethodOptionsCardThreeDSecureNetworkOptions with
        static member New(?cartesBancaires: Confirm'PaymentMethodOptionsCardThreeDSecureNetworkOptionsCartesBancaires) =
            {
                CartesBancaires = cartesBancaires
            }

    type Confirm'PaymentMethodOptionsCardThreeDSecureVersion =
        | [<JsonPropertyName("1.0.2")>] Numeric102
        | [<JsonPropertyName("2.1.0")>] Numeric210
        | [<JsonPropertyName("2.2.0")>] Numeric220
        | [<JsonPropertyName("2.3.0")>] Numeric230
        | [<JsonPropertyName("2.3.1")>] Numeric231

    type Confirm'PaymentMethodOptionsCardThreeDSecure =
        {
            /// The `transStatus` returned from the card Issuer’s ACS in the ARes.
            [<Config.Form>]
            AresTransStatus: Confirm'PaymentMethodOptionsCardThreeDSecureAresTransStatus option
            /// The cryptogram, also known as the "authentication value" (AAV, CAVV or
            /// AEVV). This value is 20 bytes, base64-encoded into a 28-character string.
            /// (Most 3D Secure providers will return the base64-encoded version, which
            /// is what you should specify here.)
            [<Config.Form>]
            Cryptogram: string option
            /// The Electronic Commerce Indicator (ECI) is returned by your 3D Secure
            /// provider and indicates what degree of authentication was performed.
            [<Config.Form>]
            ElectronicCommerceIndicator: Confirm'PaymentMethodOptionsCardThreeDSecureElectronicCommerceIndicator option
            /// Network specific 3DS fields. Network specific arguments require an
            /// explicit card brand choice. The parameter `payment_method_options.card.network``
            /// must be populated accordingly
            [<Config.Form>]
            NetworkOptions: Confirm'PaymentMethodOptionsCardThreeDSecureNetworkOptions option
            /// The challenge indicator (`threeDSRequestorChallengeInd`) which was requested in the
            /// AReq sent to the card Issuer's ACS. A string containing 2 digits from 01-99.
            [<Config.Form>]
            RequestorChallengeIndicator: string option
            /// For 3D Secure 1, the XID. For 3D Secure 2, the Directory Server
            /// Transaction ID (dsTransID).
            [<Config.Form>]
            TransactionId: string option
            /// The version of 3D Secure that was performed.
            [<Config.Form>]
            Version: Confirm'PaymentMethodOptionsCardThreeDSecureVersion option
        }

    type Confirm'PaymentMethodOptionsCardThreeDSecure with
        static member New(?aresTransStatus: Confirm'PaymentMethodOptionsCardThreeDSecureAresTransStatus, ?cryptogram: string, ?electronicCommerceIndicator: Confirm'PaymentMethodOptionsCardThreeDSecureElectronicCommerceIndicator, ?networkOptions: Confirm'PaymentMethodOptionsCardThreeDSecureNetworkOptions, ?requestorChallengeIndicator: string, ?transactionId: string, ?version: Confirm'PaymentMethodOptionsCardThreeDSecureVersion) =
            {
                AresTransStatus = aresTransStatus
                Cryptogram = cryptogram
                ElectronicCommerceIndicator = electronicCommerceIndicator
                NetworkOptions = networkOptions
                RequestorChallengeIndicator = requestorChallengeIndicator
                TransactionId = transactionId
                Version = version
            }

    type Confirm'PaymentMethodOptionsCard =
        {
            /// Configuration options for setting up an eMandate for cards issued in India.
            [<Config.Form>]
            MandateOptions: Confirm'PaymentMethodOptionsCardMandateOptions option
            /// When specified, this parameter signals that a card has been collected
            /// as MOTO (Mail Order Telephone Order) and thus out of scope for SCA. This
            /// parameter can only be provided during confirmation.
            [<Config.Form>]
            Moto: bool option
            /// Selected network to process this SetupIntent on. Depends on the available networks of the card attached to the SetupIntent. Can be only set confirm-time.
            [<Config.Form>]
            Network: Confirm'PaymentMethodOptionsCardNetwork option
            /// We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://docs.stripe.com/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. If not provided, this value defaults to `automatic`. Read our guide on [manually requesting 3D Secure](https://docs.stripe.com/payments/3d-secure/authentication-flow#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
            [<Config.Form>]
            RequestThreeDSecure: Confirm'PaymentMethodOptionsCardRequestThreeDSecure option
            /// If 3D Secure authentication was performed with a third-party provider,
            /// the authentication details to use for this setup.
            [<Config.Form>]
            ThreeDSecure: Confirm'PaymentMethodOptionsCardThreeDSecure option
        }

    type Confirm'PaymentMethodOptionsCard with
        static member New(?mandateOptions: Confirm'PaymentMethodOptionsCardMandateOptions, ?moto: bool, ?network: Confirm'PaymentMethodOptionsCardNetwork, ?requestThreeDSecure: Confirm'PaymentMethodOptionsCardRequestThreeDSecure, ?threeDSecure: Confirm'PaymentMethodOptionsCardThreeDSecure) =
            {
                MandateOptions = mandateOptions
                Moto = moto
                Network = network
                RequestThreeDSecure = requestThreeDSecure
                ThreeDSecure = threeDSecure
            }

    type Confirm'PaymentMethodOptionsKlarnaOnDemandPurchaseInterval =
        | Day
        | Month
        | Week
        | Year

    type Confirm'PaymentMethodOptionsKlarnaOnDemand =
        {
            /// Your average amount value. You can use a value across your customer base, or segment based on customer type, country, etc.
            [<Config.Form>]
            AverageAmount: int option
            /// The maximum value you may charge a customer per purchase. You can use a value across your customer base, or segment based on customer type, country, etc.
            [<Config.Form>]
            MaximumAmount: int option
            /// The lowest or minimum value you may charge a customer per purchase. You can use a value across your customer base, or segment based on customer type, country, etc.
            [<Config.Form>]
            MinimumAmount: int option
            /// Interval at which the customer is making purchases
            [<Config.Form>]
            PurchaseInterval: Confirm'PaymentMethodOptionsKlarnaOnDemandPurchaseInterval option
            /// The number of `purchase_interval` between charges
            [<Config.Form>]
            PurchaseIntervalCount: int option
        }

    type Confirm'PaymentMethodOptionsKlarnaOnDemand with
        static member New(?averageAmount: int, ?maximumAmount: int, ?minimumAmount: int, ?purchaseInterval: Confirm'PaymentMethodOptionsKlarnaOnDemandPurchaseInterval, ?purchaseIntervalCount: int) =
            {
                AverageAmount = averageAmount
                MaximumAmount = maximumAmount
                MinimumAmount = minimumAmount
                PurchaseInterval = purchaseInterval
                PurchaseIntervalCount = purchaseIntervalCount
            }

    type Confirm'PaymentMethodOptionsKlarnaPreferredLocale =
        | [<JsonPropertyName("cs-CZ")>] CsCZ
        | [<JsonPropertyName("da-DK")>] DaDK
        | [<JsonPropertyName("de-AT")>] DeAT
        | [<JsonPropertyName("de-CH")>] DeCH
        | [<JsonPropertyName("de-DE")>] DeDE
        | [<JsonPropertyName("el-GR")>] ElGR
        | [<JsonPropertyName("en-AT")>] EnAT
        | [<JsonPropertyName("en-AU")>] EnAU
        | [<JsonPropertyName("en-BE")>] EnBE
        | [<JsonPropertyName("en-CA")>] EnCA
        | [<JsonPropertyName("en-CH")>] EnCH
        | [<JsonPropertyName("en-CZ")>] EnCZ
        | [<JsonPropertyName("en-DE")>] EnDE
        | [<JsonPropertyName("en-DK")>] EnDK
        | [<JsonPropertyName("en-ES")>] EnES
        | [<JsonPropertyName("en-FI")>] EnFI
        | [<JsonPropertyName("en-FR")>] EnFR
        | [<JsonPropertyName("en-GB")>] EnGB
        | [<JsonPropertyName("en-GR")>] EnGR
        | [<JsonPropertyName("en-IE")>] EnIE
        | [<JsonPropertyName("en-IT")>] EnIT
        | [<JsonPropertyName("en-NL")>] EnNL
        | [<JsonPropertyName("en-NO")>] EnNO
        | [<JsonPropertyName("en-NZ")>] EnNZ
        | [<JsonPropertyName("en-PL")>] EnPL
        | [<JsonPropertyName("en-PT")>] EnPT
        | [<JsonPropertyName("en-RO")>] EnRO
        | [<JsonPropertyName("en-SE")>] EnSE
        | [<JsonPropertyName("en-US")>] EnUS
        | [<JsonPropertyName("es-ES")>] EsES
        | [<JsonPropertyName("es-US")>] EsUS
        | [<JsonPropertyName("fi-FI")>] FiFI
        | [<JsonPropertyName("fr-BE")>] FrBE
        | [<JsonPropertyName("fr-CA")>] FrCA
        | [<JsonPropertyName("fr-CH")>] FrCH
        | [<JsonPropertyName("fr-FR")>] FrFR
        | [<JsonPropertyName("it-CH")>] ItCH
        | [<JsonPropertyName("it-IT")>] ItIT
        | [<JsonPropertyName("nb-NO")>] NbNO
        | [<JsonPropertyName("nl-BE")>] NlBE
        | [<JsonPropertyName("nl-NL")>] NlNL
        | [<JsonPropertyName("pl-PL")>] PlPL
        | [<JsonPropertyName("pt-PT")>] PtPT
        | [<JsonPropertyName("ro-RO")>] RoRO
        | [<JsonPropertyName("sv-FI")>] SvFI
        | [<JsonPropertyName("sv-SE")>] SvSE

    type Confirm'PaymentMethodOptionsKlarnaSubscriptionsInterval =
        | Day
        | Month
        | Week
        | Year

    type Confirm'PaymentMethodOptionsKlarnaSubscriptionsNextBilling =
        {
            /// The amount of the next charge for the subscription.
            [<Config.Form>]
            Amount: int option
            /// The date of the next charge for the subscription in YYYY-MM-DD format.
            [<Config.Form>]
            Date: string option
        }

    type Confirm'PaymentMethodOptionsKlarnaSubscriptionsNextBilling with
        static member New(?amount: int, ?date: string) =
            {
                Amount = amount
                Date = date
            }

    type Confirm'PaymentMethodOptionsKlarnaSubscriptions =
        {
            /// Unit of time between subscription charges.
            [<Config.Form>]
            Interval: Confirm'PaymentMethodOptionsKlarnaSubscriptionsInterval option
            /// The number of intervals (specified in the `interval` attribute) between subscription charges. For example, `interval=month` and `interval_count=3` charges every 3 months.
            [<Config.Form>]
            IntervalCount: int option
            /// Name for subscription.
            [<Config.Form>]
            Name: string option
            /// Describes the upcoming charge for this subscription.
            [<Config.Form>]
            NextBilling: Confirm'PaymentMethodOptionsKlarnaSubscriptionsNextBilling option
            /// A non-customer-facing reference to correlate subscription charges in the Klarna app. Use a value that persists across subscription charges.
            [<Config.Form>]
            Reference: string option
        }

    type Confirm'PaymentMethodOptionsKlarnaSubscriptions with
        static member New(?interval: Confirm'PaymentMethodOptionsKlarnaSubscriptionsInterval, ?intervalCount: int, ?name: string, ?nextBilling: Confirm'PaymentMethodOptionsKlarnaSubscriptionsNextBilling, ?reference: string) =
            {
                Interval = interval
                IntervalCount = intervalCount
                Name = name
                NextBilling = nextBilling
                Reference = reference
            }

    type Confirm'PaymentMethodOptionsKlarna =
        {
            /// The currency of the SetupIntent. Three letter ISO currency code.
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// On-demand details if setting up a payment method for on-demand payments.
            [<Config.Form>]
            OnDemand: Confirm'PaymentMethodOptionsKlarnaOnDemand option
            /// Preferred language of the Klarna authorization page that the customer is redirected to
            [<Config.Form>]
            PreferredLocale: Confirm'PaymentMethodOptionsKlarnaPreferredLocale option
            /// Subscription details if setting up or charging a subscription
            [<Config.Form>]
            Subscriptions: Choice<Confirm'PaymentMethodOptionsKlarnaSubscriptions list,string> option
        }

    type Confirm'PaymentMethodOptionsKlarna with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?onDemand: Confirm'PaymentMethodOptionsKlarnaOnDemand, ?preferredLocale: Confirm'PaymentMethodOptionsKlarnaPreferredLocale, ?subscriptions: Choice<Confirm'PaymentMethodOptionsKlarnaSubscriptions list,string>) =
            {
                Currency = currency
                OnDemand = onDemand
                PreferredLocale = preferredLocale
                Subscriptions = subscriptions
            }

    type Confirm'PaymentMethodOptionsLink =
        {
            /// [Deprecated] This is a legacy parameter that no longer has any function.
            [<Config.Form>]
            PersistentToken: string option
        }

    type Confirm'PaymentMethodOptionsLink with
        static member New(?persistentToken: string) =
            {
                PersistentToken = persistentToken
            }

    type Confirm'PaymentMethodOptionsPaypal =
        {
            /// The PayPal Billing Agreement ID (BAID). This is an ID generated by PayPal which represents the mandate between the merchant and the customer.
            [<Config.Form>]
            BillingAgreementId: string option
        }

    type Confirm'PaymentMethodOptionsPaypal with
        static member New(?billingAgreementId: string) =
            {
                BillingAgreementId = billingAgreementId
            }

    type Confirm'PaymentMethodOptionsPaytoMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Confirm'PaymentMethodOptionsPaytoMandateOptionsPaymentSchedule =
        | Adhoc
        | Annual
        | Daily
        | Fortnightly
        | Monthly
        | Quarterly
        | SemiAnnual
        | Weekly

    type Confirm'PaymentMethodOptionsPaytoMandateOptionsPurpose =
        | DependantSupport
        | Government
        | Loan
        | Mortgage
        | Other
        | Pension
        | Personal
        | Retail
        | Salary
        | Tax
        | Utility

    type Confirm'PaymentMethodOptionsPaytoMandateOptions =
        {
            /// Amount that will be collected. It is required when `amount_type` is `fixed`.
            [<Config.Form>]
            Amount: Choice<int,string> option
            /// The type of amount that will be collected. The amount charged must be exact or up to the value of `amount` param for `fixed` or `maximum` type respectively. Defaults to `maximum`.
            [<Config.Form>]
            AmountType: Confirm'PaymentMethodOptionsPaytoMandateOptionsAmountType option
            /// Date, in YYYY-MM-DD format, after which payments will not be collected. Defaults to no end date.
            [<Config.Form>]
            EndDate: Choice<string,string> option
            /// The periodicity at which payments will be collected. Defaults to `adhoc`.
            [<Config.Form>]
            PaymentSchedule: Confirm'PaymentMethodOptionsPaytoMandateOptionsPaymentSchedule option
            /// The number of payments that will be made during a payment period. Defaults to 1 except for when `payment_schedule` is `adhoc`. In that case, it defaults to no limit.
            [<Config.Form>]
            PaymentsPerPeriod: Choice<int,string> option
            /// The purpose for which payments are made. Has a default value based on your merchant category code.
            [<Config.Form>]
            Purpose: Confirm'PaymentMethodOptionsPaytoMandateOptionsPurpose option
            /// Date, in YYYY-MM-DD format, from which payments will be collected. Defaults to confirmation time.
            [<Config.Form>]
            StartDate: Choice<string,string> option
        }

    type Confirm'PaymentMethodOptionsPaytoMandateOptions with
        static member New(?amount: Choice<int,string>, ?amountType: Confirm'PaymentMethodOptionsPaytoMandateOptionsAmountType, ?endDate: Choice<string,string>, ?paymentSchedule: Confirm'PaymentMethodOptionsPaytoMandateOptionsPaymentSchedule, ?paymentsPerPeriod: Choice<int,string>, ?purpose: Confirm'PaymentMethodOptionsPaytoMandateOptionsPurpose, ?startDate: Choice<string,string>) =
            {
                Amount = amount
                AmountType = amountType
                EndDate = endDate
                PaymentSchedule = paymentSchedule
                PaymentsPerPeriod = paymentsPerPeriod
                Purpose = purpose
                StartDate = startDate
            }

    type Confirm'PaymentMethodOptionsPayto =
        {
            /// Additional fields for Mandate creation.
            [<Config.Form>]
            MandateOptions: Confirm'PaymentMethodOptionsPaytoMandateOptions option
        }

    type Confirm'PaymentMethodOptionsPayto with
        static member New(?mandateOptions: Confirm'PaymentMethodOptionsPaytoMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Confirm'PaymentMethodOptionsPixMandateOptionsAmountIncludesIof =
        | Always
        | Never

    type Confirm'PaymentMethodOptionsPixMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Confirm'PaymentMethodOptionsPixMandateOptionsPaymentSchedule =
        | Halfyearly
        | Monthly
        | Quarterly
        | Weekly
        | Yearly

    type Confirm'PaymentMethodOptionsPixMandateOptions =
        {
            /// Amount to be charged for future payments. Required when `amount_type=fixed`. If not provided for `amount_type=maximum`, defaults to 40000.
            [<Config.Form>]
            Amount: int option
            /// Determines if the amount includes the IOF tax. Defaults to `never`.
            [<Config.Form>]
            AmountIncludesIof: Confirm'PaymentMethodOptionsPixMandateOptionsAmountIncludesIof option
            /// Type of amount. Defaults to `maximum`.
            [<Config.Form>]
            AmountType: Confirm'PaymentMethodOptionsPixMandateOptionsAmountType option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Only `brl` is supported currently.
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// Date when the mandate expires and no further payments will be charged, in `YYYY-MM-DD`. If not provided, the mandate will be active until canceled. If provided, end date should be after start date.
            [<Config.Form>]
            EndDate: string option
            /// Schedule at which the future payments will be charged. Defaults to `monthly`.
            [<Config.Form>]
            PaymentSchedule: Confirm'PaymentMethodOptionsPixMandateOptionsPaymentSchedule option
            /// Subscription name displayed to buyers in their bank app. Defaults to the displayable business name.
            [<Config.Form>]
            Reference: string option
            /// Start date of the mandate, in `YYYY-MM-DD`. Start date should be at least 3 days in the future. Defaults to 3 days after the current date.
            [<Config.Form>]
            StartDate: string option
        }

    type Confirm'PaymentMethodOptionsPixMandateOptions with
        static member New(?amount: int, ?amountIncludesIof: Confirm'PaymentMethodOptionsPixMandateOptionsAmountIncludesIof, ?amountType: Confirm'PaymentMethodOptionsPixMandateOptionsAmountType, ?currency: IsoTypes.IsoCurrencyCode, ?endDate: string, ?paymentSchedule: Confirm'PaymentMethodOptionsPixMandateOptionsPaymentSchedule, ?reference: string, ?startDate: string) =
            {
                Amount = amount
                AmountIncludesIof = amountIncludesIof
                AmountType = amountType
                Currency = currency
                EndDate = endDate
                PaymentSchedule = paymentSchedule
                Reference = reference
                StartDate = startDate
            }

    type Confirm'PaymentMethodOptionsPix =
        {
            /// Additional fields for mandate creation.
            [<Config.Form>]
            MandateOptions: Confirm'PaymentMethodOptionsPixMandateOptions option
        }

    type Confirm'PaymentMethodOptionsPix with
        static member New(?mandateOptions: Confirm'PaymentMethodOptionsPixMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Confirm'PaymentMethodOptionsSepaDebitMandateOptions =
        {
            /// Prefix used to generate the Mandate reference. Must be at most 12 characters long. Must consist of only uppercase letters, numbers, spaces, or the following special characters: '/', '_', '-', '&', '.'. Cannot begin with 'STRIPE'.
            [<Config.Form>]
            ReferencePrefix: Choice<string,string> option
        }

    type Confirm'PaymentMethodOptionsSepaDebitMandateOptions with
        static member New(?referencePrefix: Choice<string,string>) =
            {
                ReferencePrefix = referencePrefix
            }

    type Confirm'PaymentMethodOptionsSepaDebit =
        {
            /// Additional fields for Mandate creation
            [<Config.Form>]
            MandateOptions: Confirm'PaymentMethodOptionsSepaDebitMandateOptions option
        }

    type Confirm'PaymentMethodOptionsSepaDebit with
        static member New(?mandateOptions: Confirm'PaymentMethodOptionsSepaDebitMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Confirm'PaymentMethodOptionsUpiMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Confirm'PaymentMethodOptionsUpiMandateOptions =
        {
            /// Amount to be charged for future payments.
            [<Config.Form>]
            Amount: int option
            /// One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
            [<Config.Form>]
            AmountType: Confirm'PaymentMethodOptionsUpiMandateOptionsAmountType option
            /// A description of the mandate or subscription that is meant to be displayed to the customer.
            [<Config.Form>]
            Description: string option
            /// End date of the mandate or subscription.
            [<Config.Form>]
            EndDate: DateTime option
        }

    type Confirm'PaymentMethodOptionsUpiMandateOptions with
        static member New(?amount: int, ?amountType: Confirm'PaymentMethodOptionsUpiMandateOptionsAmountType, ?description: string, ?endDate: DateTime) =
            {
                Amount = amount
                AmountType = amountType
                Description = description
                EndDate = endDate
            }

    type Confirm'PaymentMethodOptionsUpiSetupFutureUsage =
        | [<JsonPropertyName("none")>] None'
        | OffSession
        | OnSession

    type Confirm'PaymentMethodOptionsUpi =
        {
            /// Configuration options for setting up an eMandate
            [<Config.Form>]
            MandateOptions: Confirm'PaymentMethodOptionsUpiMandateOptions option
            [<Config.Form>]
            SetupFutureUsage: Confirm'PaymentMethodOptionsUpiSetupFutureUsage option
        }

    type Confirm'PaymentMethodOptionsUpi with
        static member New(?mandateOptions: Confirm'PaymentMethodOptionsUpiMandateOptions, ?setupFutureUsage: Confirm'PaymentMethodOptionsUpiSetupFutureUsage) =
            {
                MandateOptions = mandateOptions
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsUsBankAccountFinancialConnectionsFiltersAccountSubcategories =
        | Checking
        | Savings

    type Confirm'PaymentMethodOptionsUsBankAccountFinancialConnectionsFilters =
        {
            /// The account subcategories to use to filter for selectable accounts. Valid subcategories are `checking` and `savings`.
            [<Config.Form>]
            AccountSubcategories:
                Confirm'PaymentMethodOptionsUsBankAccountFinancialConnectionsFiltersAccountSubcategories list option
        }

    type Confirm'PaymentMethodOptionsUsBankAccountFinancialConnectionsFilters with
        static member New(?accountSubcategories: Confirm'PaymentMethodOptionsUsBankAccountFinancialConnectionsFiltersAccountSubcategories list) =
            {
                AccountSubcategories = accountSubcategories
            }

    type Confirm'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions =
        | Balances
        | Ownership
        | PaymentMethod
        | Transactions

    type Confirm'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch =
        | Balances
        | Ownership
        | Transactions

    type Confirm'PaymentMethodOptionsUsBankAccountFinancialConnections =
        {
            /// Provide filters for the linked accounts that the customer can select for the payment method.
            [<Config.Form>]
            Filters: Confirm'PaymentMethodOptionsUsBankAccountFinancialConnectionsFilters option
            /// The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.
            [<Config.Form>]
            Permissions: Confirm'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions list option
            /// List of data features that you would like to retrieve upon account creation.
            [<Config.Form>]
            Prefetch: Confirm'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch list option
            /// For webview integrations only. Upon completing OAuth login in the native browser, the user will be redirected to this URL to return to your app.
            [<Config.Form>]
            ReturnUrl: string option
        }

    type Confirm'PaymentMethodOptionsUsBankAccountFinancialConnections with
        static member New(?filters: Confirm'PaymentMethodOptionsUsBankAccountFinancialConnectionsFilters, ?permissions: Confirm'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions list, ?prefetch: Confirm'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch list, ?returnUrl: string) =
            {
                Filters = filters
                Permissions = permissions
                Prefetch = prefetch
                ReturnUrl = returnUrl
            }

    type Confirm'PaymentMethodOptionsUsBankAccountMandateOptionsCollectionMethod = | Paper

    type Confirm'PaymentMethodOptionsUsBankAccountMandateOptions =
        {
            /// The method used to collect offline mandate customer acceptance.
            [<Config.Form>]
            CollectionMethod: Confirm'PaymentMethodOptionsUsBankAccountMandateOptionsCollectionMethod option
        }

    type Confirm'PaymentMethodOptionsUsBankAccountMandateOptions with
        static member New(?collectionMethod: Confirm'PaymentMethodOptionsUsBankAccountMandateOptionsCollectionMethod) =
            {
                CollectionMethod = collectionMethod
            }

    type Confirm'PaymentMethodOptionsUsBankAccountNetworksRequested =
        | Ach
        | UsDomesticWire

    type Confirm'PaymentMethodOptionsUsBankAccountNetworks =
        {
            /// Triggers validations to run across the selected networks
            [<Config.Form>]
            Requested: Confirm'PaymentMethodOptionsUsBankAccountNetworksRequested list option
        }

    type Confirm'PaymentMethodOptionsUsBankAccountNetworks with
        static member New(?requested: Confirm'PaymentMethodOptionsUsBankAccountNetworksRequested list) =
            {
                Requested = requested
            }

    type Confirm'PaymentMethodOptionsUsBankAccountVerificationMethod =
        | Automatic
        | Instant
        | Microdeposits

    type Confirm'PaymentMethodOptionsUsBankAccount =
        {
            /// Additional fields for Financial Connections Session creation
            [<Config.Form>]
            FinancialConnections: Confirm'PaymentMethodOptionsUsBankAccountFinancialConnections option
            /// Additional fields for Mandate creation
            [<Config.Form>]
            MandateOptions: Confirm'PaymentMethodOptionsUsBankAccountMandateOptions option
            /// Additional fields for network related functions
            [<Config.Form>]
            Networks: Confirm'PaymentMethodOptionsUsBankAccountNetworks option
            /// Bank account verification method. The default value is `automatic`.
            [<Config.Form>]
            VerificationMethod: Confirm'PaymentMethodOptionsUsBankAccountVerificationMethod option
        }

    type Confirm'PaymentMethodOptionsUsBankAccount with
        static member New(?financialConnections: Confirm'PaymentMethodOptionsUsBankAccountFinancialConnections, ?mandateOptions: Confirm'PaymentMethodOptionsUsBankAccountMandateOptions, ?networks: Confirm'PaymentMethodOptionsUsBankAccountNetworks, ?verificationMethod: Confirm'PaymentMethodOptionsUsBankAccountVerificationMethod) =
            {
                FinancialConnections = financialConnections
                MandateOptions = mandateOptions
                Networks = networks
                VerificationMethod = verificationMethod
            }

    type Confirm'PaymentMethodOptions =
        {
            /// If this is a `acss_debit` SetupIntent, this sub-hash contains details about the ACSS Debit payment method options.
            [<Config.Form>]
            AcssDebit: Confirm'PaymentMethodOptionsAcssDebit option
            /// If this is a `amazon_pay` SetupIntent, this sub-hash contains details about the AmazonPay payment method options.
            [<Config.Form>]
            AmazonPay: string option
            /// If this is a `bacs_debit` SetupIntent, this sub-hash contains details about the Bacs Debit payment method options.
            [<Config.Form>]
            BacsDebit: Confirm'PaymentMethodOptionsBacsDebit option
            /// Configuration for any card setup attempted on this SetupIntent.
            [<Config.Form>]
            Card: Confirm'PaymentMethodOptionsCard option
            /// If this is a `card_present` PaymentMethod, this sub-hash contains details about the card-present payment method options.
            [<Config.Form>]
            CardPresent: string option
            /// If this is a `klarna` PaymentMethod, this hash contains details about the Klarna payment method options.
            [<Config.Form>]
            Klarna: Confirm'PaymentMethodOptionsKlarna option
            /// If this is a `link` PaymentMethod, this sub-hash contains details about the Link payment method options.
            [<Config.Form>]
            Link: Confirm'PaymentMethodOptionsLink option
            /// If this is a `paypal` PaymentMethod, this sub-hash contains details about the PayPal payment method options.
            [<Config.Form>]
            Paypal: Confirm'PaymentMethodOptionsPaypal option
            /// If this is a `payto` SetupIntent, this sub-hash contains details about the PayTo payment method options.
            [<Config.Form>]
            Payto: Confirm'PaymentMethodOptionsPayto option
            /// If this is a `pix` SetupIntent, this sub-hash contains details about the Pix payment method options.
            [<Config.Form>]
            Pix: Confirm'PaymentMethodOptionsPix option
            /// If this is a `sepa_debit` SetupIntent, this sub-hash contains details about the SEPA Debit payment method options.
            [<Config.Form>]
            SepaDebit: Confirm'PaymentMethodOptionsSepaDebit option
            /// If this is a `upi` SetupIntent, this sub-hash contains details about the UPI payment method options.
            [<Config.Form>]
            Upi: Confirm'PaymentMethodOptionsUpi option
            /// If this is a `us_bank_account` SetupIntent, this sub-hash contains details about the US bank account payment method options.
            [<Config.Form>]
            UsBankAccount: Confirm'PaymentMethodOptionsUsBankAccount option
        }

    type Confirm'PaymentMethodOptions with
        static member New(?acssDebit: Confirm'PaymentMethodOptionsAcssDebit, ?amazonPay: string, ?bacsDebit: Confirm'PaymentMethodOptionsBacsDebit, ?card: Confirm'PaymentMethodOptionsCard, ?cardPresent: string, ?klarna: Confirm'PaymentMethodOptionsKlarna, ?link: Confirm'PaymentMethodOptionsLink, ?paypal: Confirm'PaymentMethodOptionsPaypal, ?payto: Confirm'PaymentMethodOptionsPayto, ?pix: Confirm'PaymentMethodOptionsPix, ?sepaDebit: Confirm'PaymentMethodOptionsSepaDebit, ?upi: Confirm'PaymentMethodOptionsUpi, ?usBankAccount: Confirm'PaymentMethodOptionsUsBankAccount) =
            {
                AcssDebit = acssDebit
                AmazonPay = amazonPay
                BacsDebit = bacsDebit
                Card = card
                CardPresent = cardPresent
                Klarna = klarna
                Link = link
                Paypal = paypal
                Payto = payto
                Pix = pix
                SepaDebit = sepaDebit
                Upi = upi
                UsBankAccount = usBankAccount
            }

    type ConfirmOptions =
        {
            [<Config.Path>]
            Intent: string
            /// ID of the ConfirmationToken used to confirm this SetupIntent.
            /// If the provided ConfirmationToken contains properties that are also being provided in this request, such as `payment_method`, then the values in this request will take precedence.
            [<Config.Form>]
            ConfirmationToken: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            [<Config.Form>]
            MandateData: Choice<Confirm'MandateDataSecretKey,string,Confirm'MandateDataClientKey> option
            /// ID of the payment method (a PaymentMethod, Card, or saved Source object) to attach to this SetupIntent.
            [<Config.Form>]
            PaymentMethod: string option
            /// When included, this hash creates a PaymentMethod that is set as the [`payment_method`](https://docs.stripe.com/api/setup_intents/object#setup_intent_object-payment_method)
            /// value in the SetupIntent.
            [<Config.Form>]
            PaymentMethodData: Confirm'PaymentMethodData option
            /// Payment method-specific configuration for this SetupIntent.
            [<Config.Form>]
            PaymentMethodOptions: Confirm'PaymentMethodOptions option
            /// The URL to redirect your customer back to after they authenticate on the payment method's app or site.
            /// If you'd prefer to redirect to a mobile application, you can alternatively supply an application URI scheme.
            /// This parameter is only used for cards and other redirect-based payment methods.
            [<Config.Form>]
            ReturnUrl: string option
            /// Set to `true` when confirming server-side and using Stripe.js, iOS, or Android client-side SDKs to handle the next actions.
            [<Config.Form>]
            UseStripeSdk: bool option
        }

    type ConfirmOptions with
        static member New(intent: string, ?confirmationToken: string, ?expand: string list, ?mandateData: Choice<Confirm'MandateDataSecretKey,string,Confirm'MandateDataClientKey>, ?paymentMethod: string, ?paymentMethodData: Confirm'PaymentMethodData, ?paymentMethodOptions: Confirm'PaymentMethodOptions, ?returnUrl: string, ?useStripeSdk: bool) =
            {
                Intent = intent
                ConfirmationToken = confirmationToken
                Expand = expand
                MandateData = mandateData
                PaymentMethod = paymentMethod
                PaymentMethodData = paymentMethodData
                PaymentMethodOptions = paymentMethodOptions
                ReturnUrl = returnUrl
                UseStripeSdk = useStripeSdk
            }

    ///<p>Confirm that your customer intends to set up the current or
    ///provided payment method. For example, you would confirm a SetupIntent
    ///when a customer hits the “Save” button on a payment method management
    ///page on your website.</p>
    ///<p>If the selected payment method does not require any additional
    ///steps from the customer, the SetupIntent will transition to the
    ///<code>succeeded</code> status.</p>
    ///<p>Otherwise, it will transition to the <code>requires_action</code> status and
    ///suggest additional actions via <code>next_action</code>. If setup fails,
    ///the SetupIntent will transition to the
    ///<code>requires_payment_method</code> status or the <code>canceled</code> status if the
    ///confirmation limit is reached.</p>
    let Confirm settings (options: ConfirmOptions) =
        $"/v1/setup_intents/{options.Intent}/confirm"
        |> RestApi.postAsync<_, SetupIntent> settings (Map.empty) options

module SetupIntentsVerifyMicrodeposits =

    type VerifyMicrodepositsOptions =
        {
            [<Config.Path>]
            Intent: string
            /// Two positive integers, in *cents*, equal to the values of the microdeposits sent to the bank account.
            [<Config.Form>]
            Amounts: int list option
            /// A six-character code starting with SM present in the microdeposit sent to the bank account.
            [<Config.Form>]
            DescriptorCode: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type VerifyMicrodepositsOptions with
        static member New(intent: string, ?amounts: int list, ?descriptorCode: string, ?expand: string list) =
            {
                Intent = intent
                Amounts = amounts
                DescriptorCode = descriptorCode
                Expand = expand
            }

    ///<p>Verifies microdeposits on a SetupIntent object.</p>
    let VerifyMicrodeposits settings (options: VerifyMicrodepositsOptions) =
        $"/v1/setup_intents/{options.Intent}/verify_microdeposits"
        |> RestApi.postAsync<_, SetupIntent> settings (Map.empty) options

