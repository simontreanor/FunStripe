namespace StripeRequest.Treasury

open FunStripe
open System.Text.Json.Serialization
open Stripe.Treasury
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
module TreasuryCreditReversals =

    type ListOptions =
        {
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// Returns objects associated with this FinancialAccount.
            [<Config.Query>]
            FinancialAccount: string
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// Only return CreditReversals for the ReceivedCredit ID.
            [<Config.Query>]
            ReceivedCredit: string option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return CreditReversals for a given status.
            [<Config.Query>]
            Status: string option
        }

    module ListOptions =
        let create
            (
                financialAccount: string
            ) : ListOptions
            =
            {
              FinancialAccount = financialAccount
              EndingBefore = None
              Expand = None
              Limit = None
              ReceivedCredit = None
              StartingAfter = None
              Status = None
            }

    type CreateOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The ReceivedCredit to reverse.
            [<Config.Form>]
            ReceivedCredit: string
        }

    module CreateOptions =
        let create
            (
                receivedCredit: string
            ) : CreateOptions
            =
            {
              ReceivedCredit = receivedCredit
              Expand = None
              Metadata = None
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            CreditReversal: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    module RetrieveOptions =
        let create
            (
                creditReversal: string
            ) : RetrieveOptions
            =
            {
              CreditReversal = creditReversal
              Expand = None
            }

    ///<p>Returns a list of CreditReversals.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("financial_account", options.FinancialAccount |> box); ("limit", options.Limit |> box); ("received_credit", options.ReceivedCredit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/treasury/credit_reversals"
        |> RestApi.getAsync<StripeList<TreasuryCreditReversal>> settings qs

    ///<p>Reverses a ReceivedCredit and creates a CreditReversal object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/treasury/credit_reversals"
        |> RestApi.postAsync<_, TreasuryCreditReversal> settings (Map.empty) options

    ///<p>Retrieves the details of an existing CreditReversal by passing the unique CreditReversal ID from either the CreditReversal creation request or CreditReversal list</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/treasury/credit_reversals/{options.CreditReversal}"
        |> RestApi.getAsync<TreasuryCreditReversal> settings qs

module TreasuryDebitReversals =

    type ListOptions =
        {
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// Returns objects associated with this FinancialAccount.
            [<Config.Query>]
            FinancialAccount: string
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// Only return DebitReversals for the ReceivedDebit ID.
            [<Config.Query>]
            ReceivedDebit: string option
            /// Only return DebitReversals for a given resolution.
            [<Config.Query>]
            Resolution: string option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return DebitReversals for a given status.
            [<Config.Query>]
            Status: string option
        }

    module ListOptions =
        let create
            (
                financialAccount: string
            ) : ListOptions
            =
            {
              FinancialAccount = financialAccount
              EndingBefore = None
              Expand = None
              Limit = None
              ReceivedDebit = None
              Resolution = None
              StartingAfter = None
              Status = None
            }

    type CreateOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The ReceivedDebit to reverse.
            [<Config.Form>]
            ReceivedDebit: string
        }

    module CreateOptions =
        let create
            (
                receivedDebit: string
            ) : CreateOptions
            =
            {
              ReceivedDebit = receivedDebit
              Expand = None
              Metadata = None
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            DebitReversal: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    module RetrieveOptions =
        let create
            (
                debitReversal: string
            ) : RetrieveOptions
            =
            {
              DebitReversal = debitReversal
              Expand = None
            }

    ///<p>Returns a list of DebitReversals.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("financial_account", options.FinancialAccount |> box); ("limit", options.Limit |> box); ("received_debit", options.ReceivedDebit |> box); ("resolution", options.Resolution |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/treasury/debit_reversals"
        |> RestApi.getAsync<StripeList<TreasuryDebitReversal>> settings qs

    ///<p>Reverses a ReceivedDebit and creates a DebitReversal object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/treasury/debit_reversals"
        |> RestApi.postAsync<_, TreasuryDebitReversal> settings (Map.empty) options

    ///<p>Retrieves a DebitReversal object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/treasury/debit_reversals/{options.DebitReversal}"
        |> RestApi.getAsync<TreasuryDebitReversal> settings qs

module TreasuryFinancialAccounts =

    type ListOptions =
        {
            /// Only return FinancialAccounts that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// An object ID cursor for use in pagination.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit ranging from 1 to 100 (defaults to 10).
            [<Config.Query>]
            Limit: int option
            /// An object ID cursor for use in pagination.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return FinancialAccounts that have the given status: `open` or `closed`
            [<Config.Query>]
            Status: string option
        }

    module ListOptions =
        let create
            (
                created: int option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option,
                status: string option
            ) : ListOptions
            =
            {
              Created = created
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
              Status = status
            }

    type Create'FeaturesCardIssuing =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'FeaturesCardIssuing =
        let create
            (
                requested: bool option
            ) : Create'FeaturesCardIssuing
            =
            {
              Requested = requested
            }

    type Create'FeaturesDepositInsurance =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'FeaturesDepositInsurance =
        let create
            (
                requested: bool option
            ) : Create'FeaturesDepositInsurance
            =
            {
              Requested = requested
            }

    type Create'FeaturesFinancialAddressesAba =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'FeaturesFinancialAddressesAba =
        let create
            (
                requested: bool option
            ) : Create'FeaturesFinancialAddressesAba
            =
            {
              Requested = requested
            }

    type Create'FeaturesFinancialAddresses =
        {
            /// Adds an ABA FinancialAddress to the FinancialAccount.
            [<Config.Form>]
            Aba: Create'FeaturesFinancialAddressesAba option
        }

    module Create'FeaturesFinancialAddresses =
        let create
            (
                aba: Create'FeaturesFinancialAddressesAba option
            ) : Create'FeaturesFinancialAddresses
            =
            {
              Aba = aba
            }

    type Create'FeaturesInboundTransfersAch =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'FeaturesInboundTransfersAch =
        let create
            (
                requested: bool option
            ) : Create'FeaturesInboundTransfersAch
            =
            {
              Requested = requested
            }

    type Create'FeaturesInboundTransfers =
        {
            /// Enables ACH Debits via the InboundTransfers API.
            [<Config.Form>]
            Ach: Create'FeaturesInboundTransfersAch option
        }

    module Create'FeaturesInboundTransfers =
        let create
            (
                ach: Create'FeaturesInboundTransfersAch option
            ) : Create'FeaturesInboundTransfers
            =
            {
              Ach = ach
            }

    type Create'FeaturesIntraStripeFlows =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'FeaturesIntraStripeFlows =
        let create
            (
                requested: bool option
            ) : Create'FeaturesIntraStripeFlows
            =
            {
              Requested = requested
            }

    type Create'FeaturesOutboundPaymentsAch =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'FeaturesOutboundPaymentsAch =
        let create
            (
                requested: bool option
            ) : Create'FeaturesOutboundPaymentsAch
            =
            {
              Requested = requested
            }

    type Create'FeaturesOutboundPaymentsUsDomesticWire =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'FeaturesOutboundPaymentsUsDomesticWire =
        let create
            (
                requested: bool option
            ) : Create'FeaturesOutboundPaymentsUsDomesticWire
            =
            {
              Requested = requested
            }

    type Create'FeaturesOutboundPayments =
        {
            /// Enables ACH transfers via the OutboundPayments API.
            [<Config.Form>]
            Ach: Create'FeaturesOutboundPaymentsAch option
            /// Enables US domestic wire transfers via the OutboundPayments API.
            [<Config.Form>]
            UsDomesticWire: Create'FeaturesOutboundPaymentsUsDomesticWire option
        }

    module Create'FeaturesOutboundPayments =
        let create
            (
                ach: Create'FeaturesOutboundPaymentsAch option,
                usDomesticWire: Create'FeaturesOutboundPaymentsUsDomesticWire option
            ) : Create'FeaturesOutboundPayments
            =
            {
              Ach = ach
              UsDomesticWire = usDomesticWire
            }

    type Create'FeaturesOutboundTransfersAch =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'FeaturesOutboundTransfersAch =
        let create
            (
                requested: bool option
            ) : Create'FeaturesOutboundTransfersAch
            =
            {
              Requested = requested
            }

    type Create'FeaturesOutboundTransfersUsDomesticWire =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'FeaturesOutboundTransfersUsDomesticWire =
        let create
            (
                requested: bool option
            ) : Create'FeaturesOutboundTransfersUsDomesticWire
            =
            {
              Requested = requested
            }

    type Create'FeaturesOutboundTransfers =
        {
            /// Enables ACH transfers via the OutboundTransfers API.
            [<Config.Form>]
            Ach: Create'FeaturesOutboundTransfersAch option
            /// Enables US domestic wire transfers via the OutboundTransfers API.
            [<Config.Form>]
            UsDomesticWire: Create'FeaturesOutboundTransfersUsDomesticWire option
        }

    module Create'FeaturesOutboundTransfers =
        let create
            (
                ach: Create'FeaturesOutboundTransfersAch option,
                usDomesticWire: Create'FeaturesOutboundTransfersUsDomesticWire option
            ) : Create'FeaturesOutboundTransfers
            =
            {
              Ach = ach
              UsDomesticWire = usDomesticWire
            }

    type Create'Features =
        {
            /// Encodes the FinancialAccount's ability to be used with the Issuing product, including attaching cards to and drawing funds from the FinancialAccount.
            [<Config.Form>]
            CardIssuing: Create'FeaturesCardIssuing option
            /// Represents whether this FinancialAccount is eligible for deposit insurance. Various factors determine the insurance amount.
            [<Config.Form>]
            DepositInsurance: Create'FeaturesDepositInsurance option
            /// Contains Features that add FinancialAddresses to the FinancialAccount.
            [<Config.Form>]
            FinancialAddresses: Create'FeaturesFinancialAddresses option
            /// Contains settings related to adding funds to a FinancialAccount from another Account with the same owner.
            [<Config.Form>]
            InboundTransfers: Create'FeaturesInboundTransfers option
            /// Represents the ability for the FinancialAccount to send money to, or receive money from other FinancialAccounts (for example, via OutboundPayment).
            [<Config.Form>]
            IntraStripeFlows: Create'FeaturesIntraStripeFlows option
            /// Includes Features related to initiating money movement out of the FinancialAccount to someone else's bucket of money.
            [<Config.Form>]
            OutboundPayments: Create'FeaturesOutboundPayments option
            /// Contains a Feature and settings related to moving money out of the FinancialAccount into another Account with the same owner.
            [<Config.Form>]
            OutboundTransfers: Create'FeaturesOutboundTransfers option
        }

    module Create'Features =
        let create
            (
                cardIssuing: Create'FeaturesCardIssuing option,
                depositInsurance: Create'FeaturesDepositInsurance option,
                financialAddresses: Create'FeaturesFinancialAddresses option,
                inboundTransfers: Create'FeaturesInboundTransfers option,
                intraStripeFlows: Create'FeaturesIntraStripeFlows option,
                outboundPayments: Create'FeaturesOutboundPayments option,
                outboundTransfers: Create'FeaturesOutboundTransfers option
            ) : Create'Features
            =
            {
              CardIssuing = cardIssuing
              DepositInsurance = depositInsurance
              FinancialAddresses = financialAddresses
              InboundTransfers = inboundTransfers
              IntraStripeFlows = intraStripeFlows
              OutboundPayments = outboundPayments
              OutboundTransfers = outboundTransfers
            }

    type Create'PlatformRestrictionsInboundFlows =
        | Restricted
        | Unrestricted

    type Create'PlatformRestrictionsOutboundFlows =
        | Restricted
        | Unrestricted

    type Create'PlatformRestrictions =
        {
            /// Restricts all inbound money movement.
            [<Config.Form>]
            InboundFlows: Create'PlatformRestrictionsInboundFlows option
            /// Restricts all outbound money movement.
            [<Config.Form>]
            OutboundFlows: Create'PlatformRestrictionsOutboundFlows option
        }

    module Create'PlatformRestrictions =
        let create
            (
                inboundFlows: Create'PlatformRestrictionsInboundFlows option,
                outboundFlows: Create'PlatformRestrictionsOutboundFlows option
            ) : Create'PlatformRestrictions
            =
            {
              InboundFlows = inboundFlows
              OutboundFlows = outboundFlows
            }

    type CreateOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Encodes whether a FinancialAccount has access to a particular feature. Stripe or the platform can control features via the requested field.
            [<Config.Form>]
            Features: Create'Features option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The nickname for the FinancialAccount.
            [<Config.Form>]
            Nickname: Choice<string,string> option
            /// The set of functionalities that the platform can restrict on the FinancialAccount.
            [<Config.Form>]
            PlatformRestrictions: Create'PlatformRestrictions option
            /// The currencies the FinancialAccount can hold a balance in.
            [<Config.Form>]
            SupportedCurrencies: string list
        }

    module CreateOptions =
        let create
            (
                supportedCurrencies: string list
            ) : CreateOptions
            =
            {
              SupportedCurrencies = supportedCurrencies
              Expand = None
              Features = None
              Metadata = None
              Nickname = None
              PlatformRestrictions = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            FinancialAccount: string
        }

    module RetrieveOptions =
        let create
            (
                financialAccount: string
            ) : RetrieveOptions
            =
            {
              FinancialAccount = financialAccount
              Expand = None
            }

    type Update'FeaturesCardIssuing =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'FeaturesCardIssuing =
        let create
            (
                requested: bool option
            ) : Update'FeaturesCardIssuing
            =
            {
              Requested = requested
            }

    type Update'FeaturesDepositInsurance =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'FeaturesDepositInsurance =
        let create
            (
                requested: bool option
            ) : Update'FeaturesDepositInsurance
            =
            {
              Requested = requested
            }

    type Update'FeaturesFinancialAddressesAba =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'FeaturesFinancialAddressesAba =
        let create
            (
                requested: bool option
            ) : Update'FeaturesFinancialAddressesAba
            =
            {
              Requested = requested
            }

    type Update'FeaturesFinancialAddresses =
        {
            /// Adds an ABA FinancialAddress to the FinancialAccount.
            [<Config.Form>]
            Aba: Update'FeaturesFinancialAddressesAba option
        }

    module Update'FeaturesFinancialAddresses =
        let create
            (
                aba: Update'FeaturesFinancialAddressesAba option
            ) : Update'FeaturesFinancialAddresses
            =
            {
              Aba = aba
            }

    type Update'FeaturesInboundTransfersAch =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'FeaturesInboundTransfersAch =
        let create
            (
                requested: bool option
            ) : Update'FeaturesInboundTransfersAch
            =
            {
              Requested = requested
            }

    type Update'FeaturesInboundTransfers =
        {
            /// Enables ACH Debits via the InboundTransfers API.
            [<Config.Form>]
            Ach: Update'FeaturesInboundTransfersAch option
        }

    module Update'FeaturesInboundTransfers =
        let create
            (
                ach: Update'FeaturesInboundTransfersAch option
            ) : Update'FeaturesInboundTransfers
            =
            {
              Ach = ach
            }

    type Update'FeaturesIntraStripeFlows =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'FeaturesIntraStripeFlows =
        let create
            (
                requested: bool option
            ) : Update'FeaturesIntraStripeFlows
            =
            {
              Requested = requested
            }

    type Update'FeaturesOutboundPaymentsAch =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'FeaturesOutboundPaymentsAch =
        let create
            (
                requested: bool option
            ) : Update'FeaturesOutboundPaymentsAch
            =
            {
              Requested = requested
            }

    type Update'FeaturesOutboundPaymentsUsDomesticWire =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'FeaturesOutboundPaymentsUsDomesticWire =
        let create
            (
                requested: bool option
            ) : Update'FeaturesOutboundPaymentsUsDomesticWire
            =
            {
              Requested = requested
            }

    type Update'FeaturesOutboundPayments =
        {
            /// Enables ACH transfers via the OutboundPayments API.
            [<Config.Form>]
            Ach: Update'FeaturesOutboundPaymentsAch option
            /// Enables US domestic wire transfers via the OutboundPayments API.
            [<Config.Form>]
            UsDomesticWire: Update'FeaturesOutboundPaymentsUsDomesticWire option
        }

    module Update'FeaturesOutboundPayments =
        let create
            (
                ach: Update'FeaturesOutboundPaymentsAch option,
                usDomesticWire: Update'FeaturesOutboundPaymentsUsDomesticWire option
            ) : Update'FeaturesOutboundPayments
            =
            {
              Ach = ach
              UsDomesticWire = usDomesticWire
            }

    type Update'FeaturesOutboundTransfersAch =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'FeaturesOutboundTransfersAch =
        let create
            (
                requested: bool option
            ) : Update'FeaturesOutboundTransfersAch
            =
            {
              Requested = requested
            }

    type Update'FeaturesOutboundTransfersUsDomesticWire =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'FeaturesOutboundTransfersUsDomesticWire =
        let create
            (
                requested: bool option
            ) : Update'FeaturesOutboundTransfersUsDomesticWire
            =
            {
              Requested = requested
            }

    type Update'FeaturesOutboundTransfers =
        {
            /// Enables ACH transfers via the OutboundTransfers API.
            [<Config.Form>]
            Ach: Update'FeaturesOutboundTransfersAch option
            /// Enables US domestic wire transfers via the OutboundTransfers API.
            [<Config.Form>]
            UsDomesticWire: Update'FeaturesOutboundTransfersUsDomesticWire option
        }

    module Update'FeaturesOutboundTransfers =
        let create
            (
                ach: Update'FeaturesOutboundTransfersAch option,
                usDomesticWire: Update'FeaturesOutboundTransfersUsDomesticWire option
            ) : Update'FeaturesOutboundTransfers
            =
            {
              Ach = ach
              UsDomesticWire = usDomesticWire
            }

    type Update'Features =
        {
            /// Encodes the FinancialAccount's ability to be used with the Issuing product, including attaching cards to and drawing funds from the FinancialAccount.
            [<Config.Form>]
            CardIssuing: Update'FeaturesCardIssuing option
            /// Represents whether this FinancialAccount is eligible for deposit insurance. Various factors determine the insurance amount.
            [<Config.Form>]
            DepositInsurance: Update'FeaturesDepositInsurance option
            /// Contains Features that add FinancialAddresses to the FinancialAccount.
            [<Config.Form>]
            FinancialAddresses: Update'FeaturesFinancialAddresses option
            /// Contains settings related to adding funds to a FinancialAccount from another Account with the same owner.
            [<Config.Form>]
            InboundTransfers: Update'FeaturesInboundTransfers option
            /// Represents the ability for the FinancialAccount to send money to, or receive money from other FinancialAccounts (for example, via OutboundPayment).
            [<Config.Form>]
            IntraStripeFlows: Update'FeaturesIntraStripeFlows option
            /// Includes Features related to initiating money movement out of the FinancialAccount to someone else's bucket of money.
            [<Config.Form>]
            OutboundPayments: Update'FeaturesOutboundPayments option
            /// Contains a Feature and settings related to moving money out of the FinancialAccount into another Account with the same owner.
            [<Config.Form>]
            OutboundTransfers: Update'FeaturesOutboundTransfers option
        }

    module Update'Features =
        let create
            (
                cardIssuing: Update'FeaturesCardIssuing option,
                depositInsurance: Update'FeaturesDepositInsurance option,
                financialAddresses: Update'FeaturesFinancialAddresses option,
                inboundTransfers: Update'FeaturesInboundTransfers option,
                intraStripeFlows: Update'FeaturesIntraStripeFlows option,
                outboundPayments: Update'FeaturesOutboundPayments option,
                outboundTransfers: Update'FeaturesOutboundTransfers option
            ) : Update'Features
            =
            {
              CardIssuing = cardIssuing
              DepositInsurance = depositInsurance
              FinancialAddresses = financialAddresses
              InboundTransfers = inboundTransfers
              IntraStripeFlows = intraStripeFlows
              OutboundPayments = outboundPayments
              OutboundTransfers = outboundTransfers
            }

    type Update'ForwardingSettingsType =
        | FinancialAccount
        | PaymentMethod

    type Update'ForwardingSettings =
        {
            /// The financial_account id
            [<Config.Form>]
            FinancialAccount: string option
            /// The payment_method or bank account id. This needs to be a verified bank account.
            [<Config.Form>]
            PaymentMethod: string option
            /// The type of the bank account provided. This can be either "financial_account" or "payment_method"
            [<Config.Form>]
            Type: Update'ForwardingSettingsType option
        }

    module Update'ForwardingSettings =
        let create
            (
                financialAccount: string option,
                paymentMethod: string option,
                ``type``: Update'ForwardingSettingsType option
            ) : Update'ForwardingSettings
            =
            {
              FinancialAccount = financialAccount
              PaymentMethod = paymentMethod
              Type = ``type``
            }

    type Update'PlatformRestrictionsInboundFlows =
        | Restricted
        | Unrestricted

    type Update'PlatformRestrictionsOutboundFlows =
        | Restricted
        | Unrestricted

    type Update'PlatformRestrictions =
        {
            /// Restricts all inbound money movement.
            [<Config.Form>]
            InboundFlows: Update'PlatformRestrictionsInboundFlows option
            /// Restricts all outbound money movement.
            [<Config.Form>]
            OutboundFlows: Update'PlatformRestrictionsOutboundFlows option
        }

    module Update'PlatformRestrictions =
        let create
            (
                inboundFlows: Update'PlatformRestrictionsInboundFlows option,
                outboundFlows: Update'PlatformRestrictionsOutboundFlows option
            ) : Update'PlatformRestrictions
            =
            {
              InboundFlows = inboundFlows
              OutboundFlows = outboundFlows
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            FinancialAccount: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Encodes whether a FinancialAccount has access to a particular feature, with a status enum and associated `status_details`. Stripe or the platform may control features via the requested field.
            [<Config.Form>]
            Features: Update'Features option
            /// A different bank account where funds can be deposited/debited in order to get the closing FA's balance to $0
            [<Config.Form>]
            ForwardingSettings: Update'ForwardingSettings option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The nickname for the FinancialAccount.
            [<Config.Form>]
            Nickname: Choice<string,string> option
            /// The set of functionalities that the platform can restrict on the FinancialAccount.
            [<Config.Form>]
            PlatformRestrictions: Update'PlatformRestrictions option
        }

    module UpdateOptions =
        let create
            (
                financialAccount: string
            ) : UpdateOptions
            =
            {
              FinancialAccount = financialAccount
              Expand = None
              Features = None
              ForwardingSettings = None
              Metadata = None
              Nickname = None
              PlatformRestrictions = None
            }

    ///<p>Returns a list of FinancialAccounts.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/treasury/financial_accounts"
        |> RestApi.getAsync<StripeList<TreasuryFinancialAccount>> settings qs

    ///<p>Creates a new FinancialAccount. Each connected account can have up to three FinancialAccounts by default.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/treasury/financial_accounts"
        |> RestApi.postAsync<_, TreasuryFinancialAccount> settings (Map.empty) options

    ///<p>Retrieves the details of a FinancialAccount.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/treasury/financial_accounts/{options.FinancialAccount}"
        |> RestApi.getAsync<TreasuryFinancialAccount> settings qs

    ///<p>Updates the details of a FinancialAccount.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/treasury/financial_accounts/{options.FinancialAccount}"
        |> RestApi.postAsync<_, TreasuryFinancialAccount> settings (Map.empty) options

module TreasuryFinancialAccountsClose =

    type Close'ForwardingSettingsType =
        | FinancialAccount
        | PaymentMethod

    type Close'ForwardingSettings =
        {
            /// The financial_account id
            [<Config.Form>]
            FinancialAccount: string option
            /// The payment_method or bank account id. This needs to be a verified bank account.
            [<Config.Form>]
            PaymentMethod: string option
            /// The type of the bank account provided. This can be either "financial_account" or "payment_method"
            [<Config.Form>]
            Type: Close'ForwardingSettingsType option
        }

    module Close'ForwardingSettings =
        let create
            (
                financialAccount: string option,
                paymentMethod: string option,
                ``type``: Close'ForwardingSettingsType option
            ) : Close'ForwardingSettings
            =
            {
              FinancialAccount = financialAccount
              PaymentMethod = paymentMethod
              Type = ``type``
            }

    type CloseOptions =
        {
            [<Config.Path>]
            FinancialAccount: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A different bank account where funds can be deposited/debited in order to get the closing FA's balance to $0
            [<Config.Form>]
            ForwardingSettings: Close'ForwardingSettings option
        }

    module CloseOptions =
        let create
            (
                financialAccount: string
            ) : CloseOptions
            =
            {
              FinancialAccount = financialAccount
              Expand = None
              ForwardingSettings = None
            }

    ///<p>Closes a FinancialAccount. A FinancialAccount can only be closed if it has a zero balance, has no pending InboundTransfers, and has canceled all attached Issuing cards.</p>
    let Close settings (options: CloseOptions) =
        $"/v1/treasury/financial_accounts/{options.FinancialAccount}/close"
        |> RestApi.postAsync<_, TreasuryFinancialAccount> settings (Map.empty) options

module TreasuryFinancialAccountsFeatures =

    type RetrieveFeaturesOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            FinancialAccount: string
        }

    module RetrieveFeaturesOptions =
        let create
            (
                financialAccount: string
            ) : RetrieveFeaturesOptions
            =
            {
              FinancialAccount = financialAccount
              Expand = None
            }

    type UpdateFeatures'CardIssuing =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module UpdateFeatures'CardIssuing =
        let create
            (
                requested: bool option
            ) : UpdateFeatures'CardIssuing
            =
            {
              Requested = requested
            }

    type UpdateFeatures'DepositInsurance =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module UpdateFeatures'DepositInsurance =
        let create
            (
                requested: bool option
            ) : UpdateFeatures'DepositInsurance
            =
            {
              Requested = requested
            }

    type UpdateFeatures'FinancialAddressesAba =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module UpdateFeatures'FinancialAddressesAba =
        let create
            (
                requested: bool option
            ) : UpdateFeatures'FinancialAddressesAba
            =
            {
              Requested = requested
            }

    type UpdateFeatures'FinancialAddresses =
        {
            /// Adds an ABA FinancialAddress to the FinancialAccount.
            [<Config.Form>]
            Aba: UpdateFeatures'FinancialAddressesAba option
        }

    module UpdateFeatures'FinancialAddresses =
        let create
            (
                aba: UpdateFeatures'FinancialAddressesAba option
            ) : UpdateFeatures'FinancialAddresses
            =
            {
              Aba = aba
            }

    type UpdateFeatures'InboundTransfersAch =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module UpdateFeatures'InboundTransfersAch =
        let create
            (
                requested: bool option
            ) : UpdateFeatures'InboundTransfersAch
            =
            {
              Requested = requested
            }

    type UpdateFeatures'InboundTransfers =
        {
            /// Enables ACH Debits via the InboundTransfers API.
            [<Config.Form>]
            Ach: UpdateFeatures'InboundTransfersAch option
        }

    module UpdateFeatures'InboundTransfers =
        let create
            (
                ach: UpdateFeatures'InboundTransfersAch option
            ) : UpdateFeatures'InboundTransfers
            =
            {
              Ach = ach
            }

    type UpdateFeatures'IntraStripeFlows =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module UpdateFeatures'IntraStripeFlows =
        let create
            (
                requested: bool option
            ) : UpdateFeatures'IntraStripeFlows
            =
            {
              Requested = requested
            }

    type UpdateFeatures'OutboundPaymentsAch =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module UpdateFeatures'OutboundPaymentsAch =
        let create
            (
                requested: bool option
            ) : UpdateFeatures'OutboundPaymentsAch
            =
            {
              Requested = requested
            }

    type UpdateFeatures'OutboundPaymentsUsDomesticWire =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module UpdateFeatures'OutboundPaymentsUsDomesticWire =
        let create
            (
                requested: bool option
            ) : UpdateFeatures'OutboundPaymentsUsDomesticWire
            =
            {
              Requested = requested
            }

    type UpdateFeatures'OutboundPayments =
        {
            /// Enables ACH transfers via the OutboundPayments API.
            [<Config.Form>]
            Ach: UpdateFeatures'OutboundPaymentsAch option
            /// Enables US domestic wire transfers via the OutboundPayments API.
            [<Config.Form>]
            UsDomesticWire: UpdateFeatures'OutboundPaymentsUsDomesticWire option
        }

    module UpdateFeatures'OutboundPayments =
        let create
            (
                ach: UpdateFeatures'OutboundPaymentsAch option,
                usDomesticWire: UpdateFeatures'OutboundPaymentsUsDomesticWire option
            ) : UpdateFeatures'OutboundPayments
            =
            {
              Ach = ach
              UsDomesticWire = usDomesticWire
            }

    type UpdateFeatures'OutboundTransfersAch =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module UpdateFeatures'OutboundTransfersAch =
        let create
            (
                requested: bool option
            ) : UpdateFeatures'OutboundTransfersAch
            =
            {
              Requested = requested
            }

    type UpdateFeatures'OutboundTransfersUsDomesticWire =
        {
            /// Whether the FinancialAccount should have the Feature.
            [<Config.Form>]
            Requested: bool option
        }

    module UpdateFeatures'OutboundTransfersUsDomesticWire =
        let create
            (
                requested: bool option
            ) : UpdateFeatures'OutboundTransfersUsDomesticWire
            =
            {
              Requested = requested
            }

    type UpdateFeatures'OutboundTransfers =
        {
            /// Enables ACH transfers via the OutboundTransfers API.
            [<Config.Form>]
            Ach: UpdateFeatures'OutboundTransfersAch option
            /// Enables US domestic wire transfers via the OutboundTransfers API.
            [<Config.Form>]
            UsDomesticWire: UpdateFeatures'OutboundTransfersUsDomesticWire option
        }

    module UpdateFeatures'OutboundTransfers =
        let create
            (
                ach: UpdateFeatures'OutboundTransfersAch option,
                usDomesticWire: UpdateFeatures'OutboundTransfersUsDomesticWire option
            ) : UpdateFeatures'OutboundTransfers
            =
            {
              Ach = ach
              UsDomesticWire = usDomesticWire
            }

    type UpdateFeaturesOptions =
        {
            [<Config.Path>]
            FinancialAccount: string
            /// Encodes the FinancialAccount's ability to be used with the Issuing product, including attaching cards to and drawing funds from the FinancialAccount.
            [<Config.Form>]
            CardIssuing: UpdateFeatures'CardIssuing option
            /// Represents whether this FinancialAccount is eligible for deposit insurance. Various factors determine the insurance amount.
            [<Config.Form>]
            DepositInsurance: UpdateFeatures'DepositInsurance option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Contains Features that add FinancialAddresses to the FinancialAccount.
            [<Config.Form>]
            FinancialAddresses: UpdateFeatures'FinancialAddresses option
            /// Contains settings related to adding funds to a FinancialAccount from another Account with the same owner.
            [<Config.Form>]
            InboundTransfers: UpdateFeatures'InboundTransfers option
            /// Represents the ability for the FinancialAccount to send money to, or receive money from other FinancialAccounts (for example, via OutboundPayment).
            [<Config.Form>]
            IntraStripeFlows: UpdateFeatures'IntraStripeFlows option
            /// Includes Features related to initiating money movement out of the FinancialAccount to someone else's bucket of money.
            [<Config.Form>]
            OutboundPayments: UpdateFeatures'OutboundPayments option
            /// Contains a Feature and settings related to moving money out of the FinancialAccount into another Account with the same owner.
            [<Config.Form>]
            OutboundTransfers: UpdateFeatures'OutboundTransfers option
        }

    module UpdateFeaturesOptions =
        let create
            (
                financialAccount: string
            ) : UpdateFeaturesOptions
            =
            {
              FinancialAccount = financialAccount
              CardIssuing = None
              DepositInsurance = None
              Expand = None
              FinancialAddresses = None
              InboundTransfers = None
              IntraStripeFlows = None
              OutboundPayments = None
              OutboundTransfers = None
            }

    ///<p>Retrieves Features information associated with the FinancialAccount.</p>
    let RetrieveFeatures settings (options: RetrieveFeaturesOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/treasury/financial_accounts/{options.FinancialAccount}/features"
        |> RestApi.getAsync<TreasuryFinancialAccountFeatures> settings qs

    ///<p>Updates the Features associated with a FinancialAccount.</p>
    let UpdateFeatures settings (options: UpdateFeaturesOptions) =
        $"/v1/treasury/financial_accounts/{options.FinancialAccount}/features"
        |> RestApi.postAsync<_, TreasuryFinancialAccountFeatures> settings (Map.empty) options

module TreasuryInboundTransfers =

    type ListOptions =
        {
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// Returns objects associated with this FinancialAccount.
            [<Config.Query>]
            FinancialAccount: string
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return InboundTransfers that have the given status: `processing`, `succeeded`, `failed` or `canceled`.
            [<Config.Query>]
            Status: string option
        }

    module ListOptions =
        let create
            (
                financialAccount: string
            ) : ListOptions
            =
            {
              FinancialAccount = financialAccount
              EndingBefore = None
              Expand = None
              Limit = None
              StartingAfter = None
              Status = None
            }

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
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The origin payment method to be debited for the InboundTransfer.
            [<Config.Form>]
            OriginPaymentMethod: string
            /// The complete description that appears on your customers' statements. Maximum 10 characters. Can only include -#.$&*, spaces, and alphanumeric characters.
            [<Config.Form>]
            StatementDescriptor: string option
        }

    module CreateOptions =
        let create
            (
                amount: int,
                currency: IsoTypes.IsoCurrencyCode,
                financialAccount: string,
                originPaymentMethod: string
            ) : CreateOptions
            =
            {
              Amount = amount
              Currency = currency
              FinancialAccount = financialAccount
              OriginPaymentMethod = originPaymentMethod
              Description = None
              Expand = None
              Metadata = None
              StatementDescriptor = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Id: string
        }

    module RetrieveOptions =
        let create
            (
                id: string
            ) : RetrieveOptions
            =
            {
              Id = id
              Expand = None
            }

    ///<p>Returns a list of InboundTransfers sent from the specified FinancialAccount.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("financial_account", options.FinancialAccount |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/treasury/inbound_transfers"
        |> RestApi.getAsync<StripeList<TreasuryInboundTransfer>> settings qs

    ///<p>Creates an InboundTransfer.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/treasury/inbound_transfers"
        |> RestApi.postAsync<_, TreasuryInboundTransfer> settings (Map.empty) options

    ///<p>Retrieves the details of an existing InboundTransfer.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/treasury/inbound_transfers/{options.Id}"
        |> RestApi.getAsync<TreasuryInboundTransfer> settings qs

module TreasuryInboundTransfersCancel =

    type CancelOptions =
        {
            [<Config.Path>]
            InboundTransfer: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module CancelOptions =
        let create
            (
                inboundTransfer: string
            ) : CancelOptions
            =
            {
              InboundTransfer = inboundTransfer
              Expand = None
            }

    ///<p>Cancels an InboundTransfer.</p>
    let Cancel settings (options: CancelOptions) =
        $"/v1/treasury/inbound_transfers/{options.InboundTransfer}/cancel"
        |> RestApi.postAsync<_, TreasuryInboundTransfer> settings (Map.empty) options

module TreasuryOutboundPayments =

    type ListOptions =
        {
            /// Only return OutboundPayments that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// Only return OutboundPayments sent to this customer.
            [<Config.Query>]
            Customer: string option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// Returns objects associated with this FinancialAccount.
            [<Config.Query>]
            FinancialAccount: string
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return OutboundPayments that have the given status: `processing`, `failed`, `posted`, `returned`, or `canceled`.
            [<Config.Query>]
            Status: string option
        }

    module ListOptions =
        let create
            (
                financialAccount: string
            ) : ListOptions
            =
            {
              FinancialAccount = financialAccount
              Created = None
              Customer = None
              EndingBefore = None
              Expand = None
              Limit = None
              StartingAfter = None
              Status = None
            }

    type Create'DestinationPaymentMethodDataBillingDetailsAddressBillingDetailsAddress =
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

    module Create'DestinationPaymentMethodDataBillingDetailsAddressBillingDetailsAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Create'DestinationPaymentMethodDataBillingDetailsAddressBillingDetailsAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Create'DestinationPaymentMethodDataBillingDetails =
        {
            /// Billing address.
            [<Config.Form>]
            Address: Choice<Create'DestinationPaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string> option
            /// Email address.
            [<Config.Form>]
            Email: Choice<string,string> option
            /// Full name.
            [<Config.Form>]
            Name: Choice<string,string> option
            /// Billing phone number (including extension).
            [<Config.Form>]
            Phone: Choice<string,string> option
        }

    module Create'DestinationPaymentMethodDataBillingDetails =
        let create
            (
                address: Choice<Create'DestinationPaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string> option,
                email: Choice<string,string> option,
                name: Choice<string,string> option,
                phone: Choice<string,string> option
            ) : Create'DestinationPaymentMethodDataBillingDetails
            =
            {
              Address = address
              Email = email
              Name = name
              Phone = phone
            }

    type Create'DestinationPaymentMethodDataType =
        | FinancialAccount
        | UsBankAccount

    type Create'DestinationPaymentMethodDataUsBankAccountAccountHolderType =
        | Company
        | Individual

    type Create'DestinationPaymentMethodDataUsBankAccountAccountType =
        | Checking
        | Savings

    type Create'DestinationPaymentMethodDataUsBankAccount =
        {
            /// Account holder type: individual or company.
            [<Config.Form>]
            AccountHolderType: Create'DestinationPaymentMethodDataUsBankAccountAccountHolderType option
            /// Account number of the bank account.
            [<Config.Form>]
            AccountNumber: string option
            /// Account type: checkings or savings. Defaults to checking if omitted.
            [<Config.Form>]
            AccountType: Create'DestinationPaymentMethodDataUsBankAccountAccountType option
            /// The ID of a Financial Connections Account to use as a payment method.
            [<Config.Form>]
            FinancialConnectionsAccount: string option
            /// Routing number of the bank account.
            [<Config.Form>]
            RoutingNumber: string option
        }

    module Create'DestinationPaymentMethodDataUsBankAccount =
        let create
            (
                accountHolderType: Create'DestinationPaymentMethodDataUsBankAccountAccountHolderType option,
                accountNumber: string option,
                accountType: Create'DestinationPaymentMethodDataUsBankAccountAccountType option,
                financialConnectionsAccount: string option,
                routingNumber: string option
            ) : Create'DestinationPaymentMethodDataUsBankAccount
            =
            {
              AccountHolderType = accountHolderType
              AccountNumber = accountNumber
              AccountType = accountType
              FinancialConnectionsAccount = financialConnectionsAccount
              RoutingNumber = routingNumber
            }

    type Create'DestinationPaymentMethodData =
        {
            /// Billing information associated with the PaymentMethod that may be used or required by particular types of payment methods.
            [<Config.Form>]
            BillingDetails: Create'DestinationPaymentMethodDataBillingDetails option
            /// Required if type is set to `financial_account`. The FinancialAccount ID to send funds to.
            [<Config.Form>]
            FinancialAccount: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The type of the PaymentMethod. An additional hash is included on the PaymentMethod with a name matching this value. It contains additional information specific to the PaymentMethod type.
            [<Config.Form>]
            Type: Create'DestinationPaymentMethodDataType option
            /// Required hash if type is set to `us_bank_account`.
            [<Config.Form>]
            UsBankAccount: Create'DestinationPaymentMethodDataUsBankAccount option
        }

    module Create'DestinationPaymentMethodData =
        let create
            (
                billingDetails: Create'DestinationPaymentMethodDataBillingDetails option,
                financialAccount: string option,
                metadata: Map<string, string> option,
                ``type``: Create'DestinationPaymentMethodDataType option,
                usBankAccount: Create'DestinationPaymentMethodDataUsBankAccount option
            ) : Create'DestinationPaymentMethodData
            =
            {
              BillingDetails = billingDetails
              FinancialAccount = financialAccount
              Metadata = metadata
              Type = ``type``
              UsBankAccount = usBankAccount
            }

    type Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptionsNetwork =
        | Ach
        | UsDomesticWire

    type Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptions =
        {
            /// Specifies the network rails to be used. If not set, will default to the PaymentMethod's preferred network. See the [docs](https://docs.stripe.com/treasury/money-movement/timelines) to learn more about money movement timelines for each network type.
            [<Config.Form>]
            Network: Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptionsNetwork option
        }

    module Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptions =
        let create
            (
                network: Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptionsNetwork option
            ) : Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptions
            =
            {
              Network = network
            }

    type Create'DestinationPaymentMethodOptions =
        {
            /// Optional fields for `us_bank_account`.
            [<Config.Form>]
            UsBankAccount: Choice<Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptions,string> option
        }

    module Create'DestinationPaymentMethodOptions =
        let create
            (
                usBankAccount: Choice<Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptions,string> option
            ) : Create'DestinationPaymentMethodOptions
            =
            {
              UsBankAccount = usBankAccount
            }

    type Create'EndUserDetails =
        {
            /// IP address of the user initiating the OutboundPayment. Must be supplied if `present` is set to `true`.
            [<Config.Form>]
            IpAddress: string option
            /// `True` if the OutboundPayment creation request is being made on behalf of an end user by a platform. Otherwise, `false`.
            [<Config.Form>]
            Present: bool option
        }

    module Create'EndUserDetails =
        let create
            (
                ipAddress: string option,
                present: bool option
            ) : Create'EndUserDetails
            =
            {
              IpAddress = ipAddress
              Present = present
            }

    type CreateOptions =
        {
            /// Amount (in cents) to be transferred.
            [<Config.Form>]
            Amount: int
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode
            /// ID of the customer to whom the OutboundPayment is sent. Must match the Customer attached to the `destination_payment_method` passed in.
            [<Config.Form>]
            Customer: string option
            /// An arbitrary string attached to the object. Often useful for displaying to users.
            [<Config.Form>]
            Description: string option
            /// The PaymentMethod to use as the payment instrument for the OutboundPayment. Exclusive with `destination_payment_method_data`.
            [<Config.Form>]
            DestinationPaymentMethod: string option
            /// Hash used to generate the PaymentMethod to be used for this OutboundPayment. Exclusive with `destination_payment_method`.
            [<Config.Form>]
            DestinationPaymentMethodData: Create'DestinationPaymentMethodData option
            /// Payment method-specific configuration for this OutboundPayment.
            [<Config.Form>]
            DestinationPaymentMethodOptions: Create'DestinationPaymentMethodOptions option
            /// End user details.
            [<Config.Form>]
            EndUserDetails: Create'EndUserDetails option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The FinancialAccount to pull funds from.
            [<Config.Form>]
            FinancialAccount: string
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The description that appears on the receiving end for this OutboundPayment (for example, bank statement for external bank transfer). Maximum 10 characters for `ach` payments, 140 characters for `us_domestic_wire` payments, or 500 characters for `stripe` network transfers. Can only include -#.$&*, spaces, and alphanumeric characters. The default value is "payment".
            [<Config.Form>]
            StatementDescriptor: string option
        }

    module CreateOptions =
        let create
            (
                amount: int,
                currency: IsoTypes.IsoCurrencyCode,
                financialAccount: string
            ) : CreateOptions
            =
            {
              Amount = amount
              Currency = currency
              FinancialAccount = financialAccount
              Customer = None
              Description = None
              DestinationPaymentMethod = None
              DestinationPaymentMethodData = None
              DestinationPaymentMethodOptions = None
              EndUserDetails = None
              Expand = None
              Metadata = None
              StatementDescriptor = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Id: string
        }

    module RetrieveOptions =
        let create
            (
                id: string
            ) : RetrieveOptions
            =
            {
              Id = id
              Expand = None
            }

    ///<p>Returns a list of OutboundPayments sent from the specified FinancialAccount.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("financial_account", options.FinancialAccount |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/treasury/outbound_payments"
        |> RestApi.getAsync<StripeList<TreasuryOutboundPayment>> settings qs

    ///<p>Creates an OutboundPayment.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/treasury/outbound_payments"
        |> RestApi.postAsync<_, TreasuryOutboundPayment> settings (Map.empty) options

    ///<p>Retrieves the details of an existing OutboundPayment by passing the unique OutboundPayment ID from either the OutboundPayment creation request or OutboundPayment list.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/treasury/outbound_payments/{options.Id}"
        |> RestApi.getAsync<TreasuryOutboundPayment> settings qs

module TreasuryOutboundPaymentsCancel =

    type CancelOptions =
        {
            [<Config.Path>]
            Id: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module CancelOptions =
        let create
            (
                id: string
            ) : CancelOptions
            =
            {
              Id = id
              Expand = None
            }

    ///<p>Cancel an OutboundPayment.</p>
    let Cancel settings (options: CancelOptions) =
        $"/v1/treasury/outbound_payments/{options.Id}/cancel"
        |> RestApi.postAsync<_, TreasuryOutboundPayment> settings (Map.empty) options

module TreasuryOutboundTransfers =

    type ListOptions =
        {
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// Returns objects associated with this FinancialAccount.
            [<Config.Query>]
            FinancialAccount: string
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return OutboundTransfers that have the given status: `processing`, `canceled`, `failed`, `posted`, or `returned`.
            [<Config.Query>]
            Status: string option
        }

    module ListOptions =
        let create
            (
                financialAccount: string
            ) : ListOptions
            =
            {
              FinancialAccount = financialAccount
              EndingBefore = None
              Expand = None
              Limit = None
              StartingAfter = None
              Status = None
            }

    type Create'DestinationPaymentMethodDataType = | FinancialAccount

    type Create'DestinationPaymentMethodData =
        {
            /// Required if type is set to `financial_account`. The FinancialAccount ID to send funds to.
            [<Config.Form>]
            FinancialAccount: string option
            /// The type of the destination.
            [<Config.Form>]
            Type: Create'DestinationPaymentMethodDataType option
        }

    module Create'DestinationPaymentMethodData =
        let create
            (
                financialAccount: string option,
                ``type``: Create'DestinationPaymentMethodDataType option
            ) : Create'DestinationPaymentMethodData
            =
            {
              FinancialAccount = financialAccount
              Type = ``type``
            }

    type Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptionsNetwork =
        | Ach
        | UsDomesticWire

    type Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptions =
        {
            /// Specifies the network rails to be used. If not set, will default to the PaymentMethod's preferred network. See the [docs](https://docs.stripe.com/treasury/money-movement/timelines) to learn more about money movement timelines for each network type.
            [<Config.Form>]
            Network: Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptionsNetwork option
        }

    module Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptions =
        let create
            (
                network: Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptionsNetwork option
            ) : Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptions
            =
            {
              Network = network
            }

    type Create'DestinationPaymentMethodOptions =
        {
            /// Optional fields for `us_bank_account`.
            [<Config.Form>]
            UsBankAccount: Choice<Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptions,string> option
        }

    module Create'DestinationPaymentMethodOptions =
        let create
            (
                usBankAccount: Choice<Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptions,string> option
            ) : Create'DestinationPaymentMethodOptions
            =
            {
              UsBankAccount = usBankAccount
            }

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
            /// The PaymentMethod to use as the payment instrument for the OutboundTransfer.
            [<Config.Form>]
            DestinationPaymentMethod: string option
            /// Hash used to generate the PaymentMethod to be used for this OutboundTransfer. Exclusive with `destination_payment_method`.
            [<Config.Form>]
            DestinationPaymentMethodData: Create'DestinationPaymentMethodData option
            /// Hash describing payment method configuration details.
            [<Config.Form>]
            DestinationPaymentMethodOptions: Create'DestinationPaymentMethodOptions option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The FinancialAccount to pull funds from.
            [<Config.Form>]
            FinancialAccount: string
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Statement descriptor to be shown on the receiving end of an OutboundTransfer. Maximum 10 characters for `ach` transfers or 140 characters for `us_domestic_wire` transfers. The default value is "transfer". Can only include -#.$&*, spaces, and alphanumeric characters.
            [<Config.Form>]
            StatementDescriptor: string option
        }

    module CreateOptions =
        let create
            (
                amount: int,
                currency: IsoTypes.IsoCurrencyCode,
                financialAccount: string
            ) : CreateOptions
            =
            {
              Amount = amount
              Currency = currency
              FinancialAccount = financialAccount
              Description = None
              DestinationPaymentMethod = None
              DestinationPaymentMethodData = None
              DestinationPaymentMethodOptions = None
              Expand = None
              Metadata = None
              StatementDescriptor = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            OutboundTransfer: string
        }

    module RetrieveOptions =
        let create
            (
                outboundTransfer: string
            ) : RetrieveOptions
            =
            {
              OutboundTransfer = outboundTransfer
              Expand = None
            }

    ///<p>Returns a list of OutboundTransfers sent from the specified FinancialAccount.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("financial_account", options.FinancialAccount |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/treasury/outbound_transfers"
        |> RestApi.getAsync<StripeList<TreasuryOutboundTransfer>> settings qs

    ///<p>Creates an OutboundTransfer.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/treasury/outbound_transfers"
        |> RestApi.postAsync<_, TreasuryOutboundTransfer> settings (Map.empty) options

    ///<p>Retrieves the details of an existing OutboundTransfer by passing the unique OutboundTransfer ID from either the OutboundTransfer creation request or OutboundTransfer list.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/treasury/outbound_transfers/{options.OutboundTransfer}"
        |> RestApi.getAsync<TreasuryOutboundTransfer> settings qs

module TreasuryOutboundTransfersCancel =

    type CancelOptions =
        {
            [<Config.Path>]
            OutboundTransfer: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module CancelOptions =
        let create
            (
                outboundTransfer: string
            ) : CancelOptions
            =
            {
              OutboundTransfer = outboundTransfer
              Expand = None
            }

    ///<p>An OutboundTransfer can be canceled if the funds have not yet been paid out.</p>
    let Cancel settings (options: CancelOptions) =
        $"/v1/treasury/outbound_transfers/{options.OutboundTransfer}/cancel"
        |> RestApi.postAsync<_, TreasuryOutboundTransfer> settings (Map.empty) options

module TreasuryReceivedCredits =

    type ListOptions =
        {
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// The FinancialAccount that received the funds.
            [<Config.Query>]
            FinancialAccount: string
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// Only return ReceivedCredits described by the flow.
            [<Config.Query>]
            LinkedFlows: Map<string, string> option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return ReceivedCredits that have the given status: `succeeded` or `failed`.
            [<Config.Query>]
            Status: string option
        }

    module ListOptions =
        let create
            (
                financialAccount: string
            ) : ListOptions
            =
            {
              FinancialAccount = financialAccount
              EndingBefore = None
              Expand = None
              Limit = None
              LinkedFlows = None
              StartingAfter = None
              Status = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Id: string
        }

    module RetrieveOptions =
        let create
            (
                id: string
            ) : RetrieveOptions
            =
            {
              Id = id
              Expand = None
            }

    ///<p>Returns a list of ReceivedCredits.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("financial_account", options.FinancialAccount |> box); ("limit", options.Limit |> box); ("linked_flows", options.LinkedFlows |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/treasury/received_credits"
        |> RestApi.getAsync<StripeList<TreasuryReceivedCredit>> settings qs

    ///<p>Retrieves the details of an existing ReceivedCredit by passing the unique ReceivedCredit ID from the ReceivedCredit list.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/treasury/received_credits/{options.Id}"
        |> RestApi.getAsync<TreasuryReceivedCredit> settings qs

module TreasuryReceivedDebits =

    type ListOptions =
        {
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// The FinancialAccount that funds were pulled from.
            [<Config.Query>]
            FinancialAccount: string
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return ReceivedDebits that have the given status: `succeeded` or `failed`.
            [<Config.Query>]
            Status: string option
        }

    module ListOptions =
        let create
            (
                financialAccount: string
            ) : ListOptions
            =
            {
              FinancialAccount = financialAccount
              EndingBefore = None
              Expand = None
              Limit = None
              StartingAfter = None
              Status = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Id: string
        }

    module RetrieveOptions =
        let create
            (
                id: string
            ) : RetrieveOptions
            =
            {
              Id = id
              Expand = None
            }

    ///<p>Returns a list of ReceivedDebits.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("financial_account", options.FinancialAccount |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/treasury/received_debits"
        |> RestApi.getAsync<StripeList<TreasuryReceivedDebit>> settings qs

    ///<p>Retrieves the details of an existing ReceivedDebit by passing the unique ReceivedDebit ID from the ReceivedDebit list</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/treasury/received_debits/{options.Id}"
        |> RestApi.getAsync<TreasuryReceivedDebit> settings qs

module TreasuryTransactionEntries =

    type ListOptions =
        {
            /// Only return TransactionEntries that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            [<Config.Query>]
            EffectiveAt: int option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// Returns objects associated with this FinancialAccount.
            [<Config.Query>]
            FinancialAccount: string
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// The results are in reverse chronological order by `created` or `effective_at`. The default is `created`.
            [<Config.Query>]
            OrderBy: string option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return TransactionEntries associated with this Transaction.
            [<Config.Query>]
            Transaction: string option
        }

    module ListOptions =
        let create
            (
                financialAccount: string
            ) : ListOptions
            =
            {
              FinancialAccount = financialAccount
              Created = None
              EffectiveAt = None
              EndingBefore = None
              Expand = None
              Limit = None
              OrderBy = None
              StartingAfter = None
              Transaction = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Id: string
        }

    module RetrieveOptions =
        let create
            (
                id: string
            ) : RetrieveOptions
            =
            {
              Id = id
              Expand = None
            }

    ///<p>Retrieves a list of TransactionEntry objects.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("effective_at", options.EffectiveAt |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("financial_account", options.FinancialAccount |> box); ("limit", options.Limit |> box); ("order_by", options.OrderBy |> box); ("starting_after", options.StartingAfter |> box); ("transaction", options.Transaction |> box)] |> Map.ofList
        $"/v1/treasury/transaction_entries"
        |> RestApi.getAsync<StripeList<TreasuryTransactionEntry>> settings qs

    ///<p>Retrieves a TransactionEntry object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/treasury/transaction_entries/{options.Id}"
        |> RestApi.getAsync<TreasuryTransactionEntry> settings qs

module TreasuryTransactions =

    type ListOptions =
        {
            /// Only return Transactions that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// Returns objects associated with this FinancialAccount.
            [<Config.Query>]
            FinancialAccount: string
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// The results are in reverse chronological order by `created` or `posted_at`. The default is `created`.
            [<Config.Query>]
            OrderBy: string option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return Transactions that have the given status: `open`, `posted`, or `void`.
            [<Config.Query>]
            Status: string option
            /// A filter for the `status_transitions.posted_at` timestamp. When using this filter, `status=posted` and `order_by=posted_at` must also be specified.
            [<Config.Query>]
            StatusTransitions: Map<string, string> option
        }

    module ListOptions =
        let create
            (
                financialAccount: string
            ) : ListOptions
            =
            {
              FinancialAccount = financialAccount
              Created = None
              EndingBefore = None
              Expand = None
              Limit = None
              OrderBy = None
              StartingAfter = None
              Status = None
              StatusTransitions = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Id: string
        }

    module RetrieveOptions =
        let create
            (
                id: string
            ) : RetrieveOptions
            =
            {
              Id = id
              Expand = None
            }

    ///<p>Retrieves a list of Transaction objects.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("financial_account", options.FinancialAccount |> box); ("limit", options.Limit |> box); ("order_by", options.OrderBy |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("status_transitions", options.StatusTransitions |> box)] |> Map.ofList
        $"/v1/treasury/transactions"
        |> RestApi.getAsync<StripeList<TreasuryTransaction>> settings qs

    ///<p>Retrieves the details of an existing Transaction.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/treasury/transactions/{options.Id}"
        |> RestApi.getAsync<TreasuryTransaction> settings qs

