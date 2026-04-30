namespace FunStripe.StripeRequest

open FunStripe
open System.Text.Json.Serialization
open FunStripe.StripeModel
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
module TreasuryCreditReversals =

    type ListOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>Returns objects associated with this FinancialAccount.</summary>
        [<Config.Query>]FinancialAccount: string
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>Only return CreditReversals for the ReceivedCredit ID.</summary>
        [<Config.Query>]ReceivedCredit: string option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Only return CreditReversals for a given status.</summary>
        [<Config.Query>]Status: string option
    }
    with
        static member New(financialAccount: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?receivedCredit: string, ?startingAfter: string, ?status: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                FinancialAccount = financialAccount
                Limit = limit
                ReceivedCredit = receivedCredit
                StartingAfter = startingAfter
                Status = status
            }

    ///<summary><p>Returns a list of CreditReversals.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("financial_account", options.FinancialAccount |> box); ("limit", options.Limit |> box); ("received_credit", options.ReceivedCredit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/treasury/credit_reversals"
        |> RestApi.getAsync<StripeList<TreasuryCreditReversal>> settings qs

    type CreateOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The ReceivedCredit to reverse.</summary>
        [<Config.Form>]ReceivedCredit: string
    }
    with
        static member New(receivedCredit: string, ?metadata: Map<string, string>, ?expand: string list) =
            {
                Expand = expand
                Metadata = metadata
                ReceivedCredit = receivedCredit
            }

    ///<summary><p>Reverses a ReceivedCredit and creates a CreditReversal object.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/treasury/credit_reversals"
        |> RestApi.postAsync<_, TreasuryCreditReversal> settings (Map.empty) options

    type RetrieveOptions = {
        [<Config.Path>]CreditReversal: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(creditReversal: string, ?expand: string list) =
            {
                CreditReversal = creditReversal
                Expand = expand
            }

    ///<summary><p>Retrieves the details of an existing CreditReversal by passing the unique CreditReversal ID from either the CreditReversal creation request or CreditReversal list</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/treasury/credit_reversals/{options.CreditReversal}"
        |> RestApi.getAsync<TreasuryCreditReversal> settings qs

module TreasuryDebitReversals =

    type ListOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>Returns objects associated with this FinancialAccount.</summary>
        [<Config.Query>]FinancialAccount: string
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>Only return DebitReversals for the ReceivedDebit ID.</summary>
        [<Config.Query>]ReceivedDebit: string option
        ///<summary>Only return DebitReversals for a given resolution.</summary>
        [<Config.Query>]Resolution: string option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Only return DebitReversals for a given status.</summary>
        [<Config.Query>]Status: string option
    }
    with
        static member New(financialAccount: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?receivedDebit: string, ?resolution: string, ?startingAfter: string, ?status: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                FinancialAccount = financialAccount
                Limit = limit
                ReceivedDebit = receivedDebit
                Resolution = resolution
                StartingAfter = startingAfter
                Status = status
            }

    ///<summary><p>Returns a list of DebitReversals.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("financial_account", options.FinancialAccount |> box); ("limit", options.Limit |> box); ("received_debit", options.ReceivedDebit |> box); ("resolution", options.Resolution |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/treasury/debit_reversals"
        |> RestApi.getAsync<StripeList<TreasuryDebitReversal>> settings qs

    type CreateOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The ReceivedDebit to reverse.</summary>
        [<Config.Form>]ReceivedDebit: string
    }
    with
        static member New(receivedDebit: string, ?metadata: Map<string, string>, ?expand: string list) =
            {
                Expand = expand
                Metadata = metadata
                ReceivedDebit = receivedDebit
            }

    ///<summary><p>Reverses a ReceivedDebit and creates a DebitReversal object.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/treasury/debit_reversals"
        |> RestApi.postAsync<_, TreasuryDebitReversal> settings (Map.empty) options

    type RetrieveOptions = {
        [<Config.Path>]DebitReversal: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(debitReversal: string, ?expand: string list) =
            {
                DebitReversal = debitReversal
                Expand = expand
            }

    ///<summary><p>Retrieves a DebitReversal object.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/treasury/debit_reversals/{options.DebitReversal}"
        |> RestApi.getAsync<TreasuryDebitReversal> settings qs

module TreasuryFinancialAccounts =

    type ListOptions = {
        ///<summary>Only return FinancialAccounts that were created during the given date interval.</summary>
        [<Config.Query>]Created: int option
        ///<summary>An object ID cursor for use in pagination.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit ranging from 1 to 100 (defaults to 10).</summary>
        [<Config.Query>]Limit: int option
        ///<summary>An object ID cursor for use in pagination.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Only return FinancialAccounts that have the given status: `open` or `closed`</summary>
        [<Config.Query>]Status: string option
    }
    with
        static member New(?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
            {
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Status = status
            }

    ///<summary><p>Returns a list of FinancialAccounts.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/treasury/financial_accounts"
        |> RestApi.getAsync<StripeList<TreasuryFinancialAccount>> settings qs

    type Create'FeaturesCardIssuing = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'FeaturesDepositInsurance = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'FeaturesFinancialAddressesAba = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'FeaturesFinancialAddresses = {
        ///<summary>Adds an ABA FinancialAddress to the FinancialAccount.</summary>
        [<Config.Form>]Aba: Create'FeaturesFinancialAddressesAba option
    }
    with
        static member New(?aba: Create'FeaturesFinancialAddressesAba) =
            {
                Aba = aba
            }

    type Create'FeaturesInboundTransfersAch = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'FeaturesInboundTransfers = {
        ///<summary>Enables ACH Debits via the InboundTransfers API.</summary>
        [<Config.Form>]Ach: Create'FeaturesInboundTransfersAch option
    }
    with
        static member New(?ach: Create'FeaturesInboundTransfersAch) =
            {
                Ach = ach
            }

    type Create'FeaturesIntraStripeFlows = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'FeaturesOutboundPaymentsAch = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'FeaturesOutboundPaymentsUsDomesticWire = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'FeaturesOutboundPayments = {
        ///<summary>Enables ACH transfers via the OutboundPayments API.</summary>
        [<Config.Form>]Ach: Create'FeaturesOutboundPaymentsAch option
        ///<summary>Enables US domestic wire transfers via the OutboundPayments API.</summary>
        [<Config.Form>]UsDomesticWire: Create'FeaturesOutboundPaymentsUsDomesticWire option
    }
    with
        static member New(?ach: Create'FeaturesOutboundPaymentsAch, ?usDomesticWire: Create'FeaturesOutboundPaymentsUsDomesticWire) =
            {
                Ach = ach
                UsDomesticWire = usDomesticWire
            }

    type Create'FeaturesOutboundTransfersAch = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'FeaturesOutboundTransfersUsDomesticWire = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'FeaturesOutboundTransfers = {
        ///<summary>Enables ACH transfers via the OutboundTransfers API.</summary>
        [<Config.Form>]Ach: Create'FeaturesOutboundTransfersAch option
        ///<summary>Enables US domestic wire transfers via the OutboundTransfers API.</summary>
        [<Config.Form>]UsDomesticWire: Create'FeaturesOutboundTransfersUsDomesticWire option
    }
    with
        static member New(?ach: Create'FeaturesOutboundTransfersAch, ?usDomesticWire: Create'FeaturesOutboundTransfersUsDomesticWire) =
            {
                Ach = ach
                UsDomesticWire = usDomesticWire
            }

    type Create'Features = {
        ///<summary>Encodes the FinancialAccount's ability to be used with the Issuing product, including attaching cards to and drawing funds from the FinancialAccount.</summary>
        [<Config.Form>]CardIssuing: Create'FeaturesCardIssuing option
        ///<summary>Represents whether this FinancialAccount is eligible for deposit insurance. Various factors determine the insurance amount.</summary>
        [<Config.Form>]DepositInsurance: Create'FeaturesDepositInsurance option
        ///<summary>Contains Features that add FinancialAddresses to the FinancialAccount.</summary>
        [<Config.Form>]FinancialAddresses: Create'FeaturesFinancialAddresses option
        ///<summary>Contains settings related to adding funds to a FinancialAccount from another Account with the same owner.</summary>
        [<Config.Form>]InboundTransfers: Create'FeaturesInboundTransfers option
        ///<summary>Represents the ability for the FinancialAccount to send money to, or receive money from other FinancialAccounts (for example, via OutboundPayment).</summary>
        [<Config.Form>]IntraStripeFlows: Create'FeaturesIntraStripeFlows option
        ///<summary>Includes Features related to initiating money movement out of the FinancialAccount to someone else's bucket of money.</summary>
        [<Config.Form>]OutboundPayments: Create'FeaturesOutboundPayments option
        ///<summary>Contains a Feature and settings related to moving money out of the FinancialAccount into another Account with the same owner.</summary>
        [<Config.Form>]OutboundTransfers: Create'FeaturesOutboundTransfers option
    }
    with
        static member New(?cardIssuing: Create'FeaturesCardIssuing, ?depositInsurance: Create'FeaturesDepositInsurance, ?financialAddresses: Create'FeaturesFinancialAddresses, ?inboundTransfers: Create'FeaturesInboundTransfers, ?intraStripeFlows: Create'FeaturesIntraStripeFlows, ?outboundPayments: Create'FeaturesOutboundPayments, ?outboundTransfers: Create'FeaturesOutboundTransfers) =
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

    type Create'PlatformRestrictions = {
        ///<summary>Restricts all inbound money movement.</summary>
        [<Config.Form>]InboundFlows: Create'PlatformRestrictionsInboundFlows option
        ///<summary>Restricts all outbound money movement.</summary>
        [<Config.Form>]OutboundFlows: Create'PlatformRestrictionsOutboundFlows option
    }
    with
        static member New(?inboundFlows: Create'PlatformRestrictionsInboundFlows, ?outboundFlows: Create'PlatformRestrictionsOutboundFlows) =
            {
                InboundFlows = inboundFlows
                OutboundFlows = outboundFlows
            }

    type CreateOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Encodes whether a FinancialAccount has access to a particular feature. Stripe or the platform can control features via the requested field.</summary>
        [<Config.Form>]Features: Create'Features option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The nickname for the FinancialAccount.</summary>
        [<Config.Form>]Nickname: Choice<string,string> option
        ///<summary>The set of functionalities that the platform can restrict on the FinancialAccount.</summary>
        [<Config.Form>]PlatformRestrictions: Create'PlatformRestrictions option
        ///<summary>The currencies the FinancialAccount can hold a balance in.</summary>
        [<Config.Form>]SupportedCurrencies: string list
    }
    with
        static member New(supportedCurrencies: string list, ?expand: string list, ?features: Create'Features, ?metadata: Map<string, string>, ?nickname: Choice<string,string>, ?platformRestrictions: Create'PlatformRestrictions) =
            {
                Expand = expand
                Features = features
                Metadata = metadata
                Nickname = nickname
                PlatformRestrictions = platformRestrictions
                SupportedCurrencies = supportedCurrencies
            }

    ///<summary><p>Creates a new FinancialAccount. Each connected account can have up to three FinancialAccounts by default.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/treasury/financial_accounts"
        |> RestApi.postAsync<_, TreasuryFinancialAccount> settings (Map.empty) options

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]FinancialAccount: string
    }
    with
        static member New(financialAccount: string, ?expand: string list) =
            {
                Expand = expand
                FinancialAccount = financialAccount
            }

    ///<summary><p>Retrieves the details of a FinancialAccount.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/treasury/financial_accounts/{options.FinancialAccount}"
        |> RestApi.getAsync<TreasuryFinancialAccount> settings qs

    type Update'FeaturesCardIssuing = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'FeaturesDepositInsurance = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'FeaturesFinancialAddressesAba = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'FeaturesFinancialAddresses = {
        ///<summary>Adds an ABA FinancialAddress to the FinancialAccount.</summary>
        [<Config.Form>]Aba: Update'FeaturesFinancialAddressesAba option
    }
    with
        static member New(?aba: Update'FeaturesFinancialAddressesAba) =
            {
                Aba = aba
            }

    type Update'FeaturesInboundTransfersAch = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'FeaturesInboundTransfers = {
        ///<summary>Enables ACH Debits via the InboundTransfers API.</summary>
        [<Config.Form>]Ach: Update'FeaturesInboundTransfersAch option
    }
    with
        static member New(?ach: Update'FeaturesInboundTransfersAch) =
            {
                Ach = ach
            }

    type Update'FeaturesIntraStripeFlows = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'FeaturesOutboundPaymentsAch = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'FeaturesOutboundPaymentsUsDomesticWire = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'FeaturesOutboundPayments = {
        ///<summary>Enables ACH transfers via the OutboundPayments API.</summary>
        [<Config.Form>]Ach: Update'FeaturesOutboundPaymentsAch option
        ///<summary>Enables US domestic wire transfers via the OutboundPayments API.</summary>
        [<Config.Form>]UsDomesticWire: Update'FeaturesOutboundPaymentsUsDomesticWire option
    }
    with
        static member New(?ach: Update'FeaturesOutboundPaymentsAch, ?usDomesticWire: Update'FeaturesOutboundPaymentsUsDomesticWire) =
            {
                Ach = ach
                UsDomesticWire = usDomesticWire
            }

    type Update'FeaturesOutboundTransfersAch = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'FeaturesOutboundTransfersUsDomesticWire = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'FeaturesOutboundTransfers = {
        ///<summary>Enables ACH transfers via the OutboundTransfers API.</summary>
        [<Config.Form>]Ach: Update'FeaturesOutboundTransfersAch option
        ///<summary>Enables US domestic wire transfers via the OutboundTransfers API.</summary>
        [<Config.Form>]UsDomesticWire: Update'FeaturesOutboundTransfersUsDomesticWire option
    }
    with
        static member New(?ach: Update'FeaturesOutboundTransfersAch, ?usDomesticWire: Update'FeaturesOutboundTransfersUsDomesticWire) =
            {
                Ach = ach
                UsDomesticWire = usDomesticWire
            }

    type Update'Features = {
        ///<summary>Encodes the FinancialAccount's ability to be used with the Issuing product, including attaching cards to and drawing funds from the FinancialAccount.</summary>
        [<Config.Form>]CardIssuing: Update'FeaturesCardIssuing option
        ///<summary>Represents whether this FinancialAccount is eligible for deposit insurance. Various factors determine the insurance amount.</summary>
        [<Config.Form>]DepositInsurance: Update'FeaturesDepositInsurance option
        ///<summary>Contains Features that add FinancialAddresses to the FinancialAccount.</summary>
        [<Config.Form>]FinancialAddresses: Update'FeaturesFinancialAddresses option
        ///<summary>Contains settings related to adding funds to a FinancialAccount from another Account with the same owner.</summary>
        [<Config.Form>]InboundTransfers: Update'FeaturesInboundTransfers option
        ///<summary>Represents the ability for the FinancialAccount to send money to, or receive money from other FinancialAccounts (for example, via OutboundPayment).</summary>
        [<Config.Form>]IntraStripeFlows: Update'FeaturesIntraStripeFlows option
        ///<summary>Includes Features related to initiating money movement out of the FinancialAccount to someone else's bucket of money.</summary>
        [<Config.Form>]OutboundPayments: Update'FeaturesOutboundPayments option
        ///<summary>Contains a Feature and settings related to moving money out of the FinancialAccount into another Account with the same owner.</summary>
        [<Config.Form>]OutboundTransfers: Update'FeaturesOutboundTransfers option
    }
    with
        static member New(?cardIssuing: Update'FeaturesCardIssuing, ?depositInsurance: Update'FeaturesDepositInsurance, ?financialAddresses: Update'FeaturesFinancialAddresses, ?inboundTransfers: Update'FeaturesInboundTransfers, ?intraStripeFlows: Update'FeaturesIntraStripeFlows, ?outboundPayments: Update'FeaturesOutboundPayments, ?outboundTransfers: Update'FeaturesOutboundTransfers) =
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

    type Update'ForwardingSettings = {
        ///<summary>The financial_account id</summary>
        [<Config.Form>]FinancialAccount: string option
        ///<summary>The payment_method or bank account id. This needs to be a verified bank account.</summary>
        [<Config.Form>]PaymentMethod: string option
        ///<summary>The type of the bank account provided. This can be either "financial_account" or "payment_method"</summary>
        [<Config.Form>]Type: Update'ForwardingSettingsType option
    }
    with
        static member New(?financialAccount: string, ?paymentMethod: string, ?type': Update'ForwardingSettingsType) =
            {
                FinancialAccount = financialAccount
                PaymentMethod = paymentMethod
                Type = type'
            }

    type Update'PlatformRestrictionsInboundFlows =
    | Restricted
    | Unrestricted

    type Update'PlatformRestrictionsOutboundFlows =
    | Restricted
    | Unrestricted

    type Update'PlatformRestrictions = {
        ///<summary>Restricts all inbound money movement.</summary>
        [<Config.Form>]InboundFlows: Update'PlatformRestrictionsInboundFlows option
        ///<summary>Restricts all outbound money movement.</summary>
        [<Config.Form>]OutboundFlows: Update'PlatformRestrictionsOutboundFlows option
    }
    with
        static member New(?inboundFlows: Update'PlatformRestrictionsInboundFlows, ?outboundFlows: Update'PlatformRestrictionsOutboundFlows) =
            {
                InboundFlows = inboundFlows
                OutboundFlows = outboundFlows
            }

    type UpdateOptions = {
        [<Config.Path>]FinancialAccount: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Encodes whether a FinancialAccount has access to a particular feature, with a status enum and associated `status_details`. Stripe or the platform may control features via the requested field.</summary>
        [<Config.Form>]Features: Update'Features option
        ///<summary>A different bank account where funds can be deposited/debited in order to get the closing FA's balance to $0</summary>
        [<Config.Form>]ForwardingSettings: Update'ForwardingSettings option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The nickname for the FinancialAccount.</summary>
        [<Config.Form>]Nickname: Choice<string,string> option
        ///<summary>The set of functionalities that the platform can restrict on the FinancialAccount.</summary>
        [<Config.Form>]PlatformRestrictions: Update'PlatformRestrictions option
    }
    with
        static member New(financialAccount: string, ?expand: string list, ?features: Update'Features, ?forwardingSettings: Update'ForwardingSettings, ?metadata: Map<string, string>, ?nickname: Choice<string,string>, ?platformRestrictions: Update'PlatformRestrictions) =
            {
                FinancialAccount = financialAccount
                Expand = expand
                Features = features
                ForwardingSettings = forwardingSettings
                Metadata = metadata
                Nickname = nickname
                PlatformRestrictions = platformRestrictions
            }

    ///<summary><p>Updates the details of a FinancialAccount.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/treasury/financial_accounts/{options.FinancialAccount}"
        |> RestApi.postAsync<_, TreasuryFinancialAccount> settings (Map.empty) options

module TreasuryFinancialAccountsClose =

    type Close'ForwardingSettingsType =
    | FinancialAccount
    | PaymentMethod

    type Close'ForwardingSettings = {
        ///<summary>The financial_account id</summary>
        [<Config.Form>]FinancialAccount: string option
        ///<summary>The payment_method or bank account id. This needs to be a verified bank account.</summary>
        [<Config.Form>]PaymentMethod: string option
        ///<summary>The type of the bank account provided. This can be either "financial_account" or "payment_method"</summary>
        [<Config.Form>]Type: Close'ForwardingSettingsType option
    }
    with
        static member New(?financialAccount: string, ?paymentMethod: string, ?type': Close'ForwardingSettingsType) =
            {
                FinancialAccount = financialAccount
                PaymentMethod = paymentMethod
                Type = type'
            }

    type CloseOptions = {
        [<Config.Path>]FinancialAccount: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>A different bank account where funds can be deposited/debited in order to get the closing FA's balance to $0</summary>
        [<Config.Form>]ForwardingSettings: Close'ForwardingSettings option
    }
    with
        static member New(financialAccount: string, ?expand: string list, ?forwardingSettings: Close'ForwardingSettings) =
            {
                FinancialAccount = financialAccount
                Expand = expand
                ForwardingSettings = forwardingSettings
            }

    ///<summary><p>Closes a FinancialAccount. A FinancialAccount can only be closed if it has a zero balance, has no pending InboundTransfers, and has canceled all attached Issuing cards.</p></summary>
    let Close settings (options: CloseOptions) =
        $"/v1/treasury/financial_accounts/{options.FinancialAccount}/close"
        |> RestApi.postAsync<_, TreasuryFinancialAccount> settings (Map.empty) options

module TreasuryFinancialAccountsFeatures =

    type RetrieveFeaturesOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]FinancialAccount: string
    }
    with
        static member New(financialAccount: string, ?expand: string list) =
            {
                Expand = expand
                FinancialAccount = financialAccount
            }

    ///<summary><p>Retrieves Features information associated with the FinancialAccount.</p></summary>
    let RetrieveFeatures settings (options: RetrieveFeaturesOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/treasury/financial_accounts/{options.FinancialAccount}/features"
        |> RestApi.getAsync<TreasuryFinancialAccountFeatures> settings qs

    type UpdateFeatures'CardIssuing = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type UpdateFeatures'DepositInsurance = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type UpdateFeatures'FinancialAddressesAba = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type UpdateFeatures'FinancialAddresses = {
        ///<summary>Adds an ABA FinancialAddress to the FinancialAccount.</summary>
        [<Config.Form>]Aba: UpdateFeatures'FinancialAddressesAba option
    }
    with
        static member New(?aba: UpdateFeatures'FinancialAddressesAba) =
            {
                Aba = aba
            }

    type UpdateFeatures'InboundTransfersAch = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type UpdateFeatures'InboundTransfers = {
        ///<summary>Enables ACH Debits via the InboundTransfers API.</summary>
        [<Config.Form>]Ach: UpdateFeatures'InboundTransfersAch option
    }
    with
        static member New(?ach: UpdateFeatures'InboundTransfersAch) =
            {
                Ach = ach
            }

    type UpdateFeatures'IntraStripeFlows = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type UpdateFeatures'OutboundPaymentsAch = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type UpdateFeatures'OutboundPaymentsUsDomesticWire = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type UpdateFeatures'OutboundPayments = {
        ///<summary>Enables ACH transfers via the OutboundPayments API.</summary>
        [<Config.Form>]Ach: UpdateFeatures'OutboundPaymentsAch option
        ///<summary>Enables US domestic wire transfers via the OutboundPayments API.</summary>
        [<Config.Form>]UsDomesticWire: UpdateFeatures'OutboundPaymentsUsDomesticWire option
    }
    with
        static member New(?ach: UpdateFeatures'OutboundPaymentsAch, ?usDomesticWire: UpdateFeatures'OutboundPaymentsUsDomesticWire) =
            {
                Ach = ach
                UsDomesticWire = usDomesticWire
            }

    type UpdateFeatures'OutboundTransfersAch = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type UpdateFeatures'OutboundTransfersUsDomesticWire = {
        ///<summary>Whether the FinancialAccount should have the Feature.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type UpdateFeatures'OutboundTransfers = {
        ///<summary>Enables ACH transfers via the OutboundTransfers API.</summary>
        [<Config.Form>]Ach: UpdateFeatures'OutboundTransfersAch option
        ///<summary>Enables US domestic wire transfers via the OutboundTransfers API.</summary>
        [<Config.Form>]UsDomesticWire: UpdateFeatures'OutboundTransfersUsDomesticWire option
    }
    with
        static member New(?ach: UpdateFeatures'OutboundTransfersAch, ?usDomesticWire: UpdateFeatures'OutboundTransfersUsDomesticWire) =
            {
                Ach = ach
                UsDomesticWire = usDomesticWire
            }

    type UpdateFeaturesOptions = {
        [<Config.Path>]FinancialAccount: string
        ///<summary>Encodes the FinancialAccount's ability to be used with the Issuing product, including attaching cards to and drawing funds from the FinancialAccount.</summary>
        [<Config.Form>]CardIssuing: UpdateFeatures'CardIssuing option
        ///<summary>Represents whether this FinancialAccount is eligible for deposit insurance. Various factors determine the insurance amount.</summary>
        [<Config.Form>]DepositInsurance: UpdateFeatures'DepositInsurance option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Contains Features that add FinancialAddresses to the FinancialAccount.</summary>
        [<Config.Form>]FinancialAddresses: UpdateFeatures'FinancialAddresses option
        ///<summary>Contains settings related to adding funds to a FinancialAccount from another Account with the same owner.</summary>
        [<Config.Form>]InboundTransfers: UpdateFeatures'InboundTransfers option
        ///<summary>Represents the ability for the FinancialAccount to send money to, or receive money from other FinancialAccounts (for example, via OutboundPayment).</summary>
        [<Config.Form>]IntraStripeFlows: UpdateFeatures'IntraStripeFlows option
        ///<summary>Includes Features related to initiating money movement out of the FinancialAccount to someone else's bucket of money.</summary>
        [<Config.Form>]OutboundPayments: UpdateFeatures'OutboundPayments option
        ///<summary>Contains a Feature and settings related to moving money out of the FinancialAccount into another Account with the same owner.</summary>
        [<Config.Form>]OutboundTransfers: UpdateFeatures'OutboundTransfers option
    }
    with
        static member New(financialAccount: string, ?cardIssuing: UpdateFeatures'CardIssuing, ?depositInsurance: UpdateFeatures'DepositInsurance, ?expand: string list, ?financialAddresses: UpdateFeatures'FinancialAddresses, ?inboundTransfers: UpdateFeatures'InboundTransfers, ?intraStripeFlows: UpdateFeatures'IntraStripeFlows, ?outboundPayments: UpdateFeatures'OutboundPayments, ?outboundTransfers: UpdateFeatures'OutboundTransfers) =
            {
                FinancialAccount = financialAccount
                CardIssuing = cardIssuing
                DepositInsurance = depositInsurance
                Expand = expand
                FinancialAddresses = financialAddresses
                InboundTransfers = inboundTransfers
                IntraStripeFlows = intraStripeFlows
                OutboundPayments = outboundPayments
                OutboundTransfers = outboundTransfers
            }

    ///<summary><p>Updates the Features associated with a FinancialAccount.</p></summary>
    let UpdateFeatures settings (options: UpdateFeaturesOptions) =
        $"/v1/treasury/financial_accounts/{options.FinancialAccount}/features"
        |> RestApi.postAsync<_, TreasuryFinancialAccountFeatures> settings (Map.empty) options

module TreasuryInboundTransfers =

    type ListOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>Returns objects associated with this FinancialAccount.</summary>
        [<Config.Query>]FinancialAccount: string
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Only return InboundTransfers that have the given status: `processing`, `succeeded`, `failed` or `canceled`.</summary>
        [<Config.Query>]Status: string option
    }
    with
        static member New(financialAccount: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                FinancialAccount = financialAccount
                Limit = limit
                StartingAfter = startingAfter
                Status = status
            }

    ///<summary><p>Returns a list of InboundTransfers sent from the specified FinancialAccount.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("financial_account", options.FinancialAccount |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/treasury/inbound_transfers"
        |> RestApi.getAsync<StripeList<TreasuryInboundTransfer>> settings qs

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
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The origin payment method to be debited for the InboundTransfer.</summary>
        [<Config.Form>]OriginPaymentMethod: string
        ///<summary>The complete description that appears on your customers' statements. Maximum 10 characters. Can only include -#.$&*, spaces, and alphanumeric characters.</summary>
        [<Config.Form>]StatementDescriptor: string option
    }
    with
        static member New(amount: int, currency: IsoTypes.IsoCurrencyCode, financialAccount: string, originPaymentMethod: string, ?description: string, ?expand: string list, ?metadata: Map<string, string>, ?statementDescriptor: string) =
            {
                Amount = amount
                Currency = currency
                Description = description
                Expand = expand
                FinancialAccount = financialAccount
                Metadata = metadata
                OriginPaymentMethod = originPaymentMethod
                StatementDescriptor = statementDescriptor
            }

    ///<summary><p>Creates an InboundTransfer.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/treasury/inbound_transfers"
        |> RestApi.postAsync<_, TreasuryInboundTransfer> settings (Map.empty) options

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Expand = expand
                Id = id
            }

    ///<summary><p>Retrieves the details of an existing InboundTransfer.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/treasury/inbound_transfers/{options.Id}"
        |> RestApi.getAsync<TreasuryInboundTransfer> settings qs

module TreasuryInboundTransfersCancel =

    type CancelOptions = {
        [<Config.Path>]InboundTransfer: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(inboundTransfer: string, ?expand: string list) =
            {
                InboundTransfer = inboundTransfer
                Expand = expand
            }

    ///<summary><p>Cancels an InboundTransfer.</p></summary>
    let Cancel settings (options: CancelOptions) =
        $"/v1/treasury/inbound_transfers/{options.InboundTransfer}/cancel"
        |> RestApi.postAsync<_, TreasuryInboundTransfer> settings (Map.empty) options

module TreasuryOutboundPayments =

    type ListOptions = {
        ///<summary>Only return OutboundPayments that were created during the given date interval.</summary>
        [<Config.Query>]Created: int option
        ///<summary>Only return OutboundPayments sent to this customer.</summary>
        [<Config.Query>]Customer: string option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>Returns objects associated with this FinancialAccount.</summary>
        [<Config.Query>]FinancialAccount: string
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Only return OutboundPayments that have the given status: `processing`, `failed`, `posted`, `returned`, or `canceled`.</summary>
        [<Config.Query>]Status: string option
    }
    with
        static member New(financialAccount: string, ?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
            {
                Created = created
                Customer = customer
                EndingBefore = endingBefore
                Expand = expand
                FinancialAccount = financialAccount
                Limit = limit
                StartingAfter = startingAfter
                Status = status
            }

    ///<summary><p>Returns a list of OutboundPayments sent from the specified FinancialAccount.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("financial_account", options.FinancialAccount |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/treasury/outbound_payments"
        |> RestApi.getAsync<StripeList<TreasuryOutboundPayment>> settings qs

    type Create'DestinationPaymentMethodDataBillingDetailsAddressBillingDetailsAddress = {
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

    type Create'DestinationPaymentMethodDataBillingDetails = {
        ///<summary>Billing address.</summary>
        [<Config.Form>]Address: Choice<Create'DestinationPaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string> option
        ///<summary>Email address.</summary>
        [<Config.Form>]Email: Choice<string,string> option
        ///<summary>Full name.</summary>
        [<Config.Form>]Name: Choice<string,string> option
        ///<summary>Billing phone number (including extension).</summary>
        [<Config.Form>]Phone: Choice<string,string> option
    }
    with
        static member New(?address: Choice<Create'DestinationPaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string>, ?email: Choice<string,string>, ?name: Choice<string,string>, ?phone: Choice<string,string>) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
            }

    type Create'DestinationPaymentMethodDataUsBankAccountAccountHolderType =
    | Company
    | Individual

    type Create'DestinationPaymentMethodDataUsBankAccountAccountType =
    | Checking
    | Savings

    type Create'DestinationPaymentMethodDataUsBankAccount = {
        ///<summary>Account holder type: individual or company.</summary>
        [<Config.Form>]AccountHolderType: Create'DestinationPaymentMethodDataUsBankAccountAccountHolderType option
        ///<summary>Account number of the bank account.</summary>
        [<Config.Form>]AccountNumber: string option
        ///<summary>Account type: checkings or savings. Defaults to checking if omitted.</summary>
        [<Config.Form>]AccountType: Create'DestinationPaymentMethodDataUsBankAccountAccountType option
        ///<summary>The ID of a Financial Connections Account to use as a payment method.</summary>
        [<Config.Form>]FinancialConnectionsAccount: string option
        ///<summary>Routing number of the bank account.</summary>
        [<Config.Form>]RoutingNumber: string option
    }
    with
        static member New(?accountHolderType: Create'DestinationPaymentMethodDataUsBankAccountAccountHolderType, ?accountNumber: string, ?accountType: Create'DestinationPaymentMethodDataUsBankAccountAccountType, ?financialConnectionsAccount: string, ?routingNumber: string) =
            {
                AccountHolderType = accountHolderType
                AccountNumber = accountNumber
                AccountType = accountType
                FinancialConnectionsAccount = financialConnectionsAccount
                RoutingNumber = routingNumber
            }

    type Create'DestinationPaymentMethodDataType =
    | FinancialAccount
    | UsBankAccount

    type Create'DestinationPaymentMethodData = {
        ///<summary>Billing information associated with the PaymentMethod that may be used or required by particular types of payment methods.</summary>
        [<Config.Form>]BillingDetails: Create'DestinationPaymentMethodDataBillingDetails option
        ///<summary>Required if type is set to `financial_account`. The FinancialAccount ID to send funds to.</summary>
        [<Config.Form>]FinancialAccount: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The type of the PaymentMethod. An additional hash is included on the PaymentMethod with a name matching this value. It contains additional information specific to the PaymentMethod type.</summary>
        [<Config.Form>]Type: Create'DestinationPaymentMethodDataType option
        ///<summary>Required hash if type is set to `us_bank_account`.</summary>
        [<Config.Form>]UsBankAccount: Create'DestinationPaymentMethodDataUsBankAccount option
    }
    with
        static member New(?billingDetails: Create'DestinationPaymentMethodDataBillingDetails, ?financialAccount: string, ?metadata: Map<string, string>, ?type': Create'DestinationPaymentMethodDataType, ?usBankAccount: Create'DestinationPaymentMethodDataUsBankAccount) =
            {
                BillingDetails = billingDetails
                FinancialAccount = financialAccount
                Metadata = metadata
                Type = type'
                UsBankAccount = usBankAccount
            }

    type Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptionsNetwork =
    | Ach
    | UsDomesticWire

    type Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptions = {
        ///<summary>Specifies the network rails to be used. If not set, will default to the PaymentMethod's preferred network. See the [docs](https://docs.stripe.com/treasury/money-movement/timelines) to learn more about money movement timelines for each network type.</summary>
        [<Config.Form>]Network: Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptionsNetwork option
    }
    with
        static member New(?network: Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptionsNetwork) =
            {
                Network = network
            }

    type Create'DestinationPaymentMethodOptions = {
        ///<summary>Optional fields for `us_bank_account`.</summary>
        [<Config.Form>]UsBankAccount: Choice<Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptions,string> option
    }
    with
        static member New(?usBankAccount: Choice<Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptions,string>) =
            {
                UsBankAccount = usBankAccount
            }

    type Create'EndUserDetails = {
        ///<summary>IP address of the user initiating the OutboundPayment. Must be supplied if `present` is set to `true`.</summary>
        [<Config.Form>]IpAddress: string option
        ///<summary>`True` if the OutboundPayment creation request is being made on behalf of an end user by a platform. Otherwise, `false`.</summary>
        [<Config.Form>]Present: bool option
    }
    with
        static member New(?ipAddress: string, ?present: bool) =
            {
                IpAddress = ipAddress
                Present = present
            }

    type CreateOptions = {
        ///<summary>Amount (in cents) to be transferred.</summary>
        [<Config.Form>]Amount: int
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode
        ///<summary>ID of the customer to whom the OutboundPayment is sent. Must match the Customer attached to the `destination_payment_method` passed in.</summary>
        [<Config.Form>]Customer: string option
        ///<summary>An arbitrary string attached to the object. Often useful for displaying to users.</summary>
        [<Config.Form>]Description: string option
        ///<summary>The PaymentMethod to use as the payment instrument for the OutboundPayment. Exclusive with `destination_payment_method_data`.</summary>
        [<Config.Form>]DestinationPaymentMethod: string option
        ///<summary>Hash used to generate the PaymentMethod to be used for this OutboundPayment. Exclusive with `destination_payment_method`.</summary>
        [<Config.Form>]DestinationPaymentMethodData: Create'DestinationPaymentMethodData option
        ///<summary>Payment method-specific configuration for this OutboundPayment.</summary>
        [<Config.Form>]DestinationPaymentMethodOptions: Create'DestinationPaymentMethodOptions option
        ///<summary>End user details.</summary>
        [<Config.Form>]EndUserDetails: Create'EndUserDetails option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The FinancialAccount to pull funds from.</summary>
        [<Config.Form>]FinancialAccount: string
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The description that appears on the receiving end for this OutboundPayment (for example, bank statement for external bank transfer). Maximum 10 characters for `ach` payments, 140 characters for `us_domestic_wire` payments, or 500 characters for `stripe` network transfers. Can only include -#.$&*, spaces, and alphanumeric characters. The default value is "payment".</summary>
        [<Config.Form>]StatementDescriptor: string option
    }
    with
        static member New(amount: int, currency: IsoTypes.IsoCurrencyCode, financialAccount: string, ?customer: string, ?description: string, ?destinationPaymentMethod: string, ?destinationPaymentMethodData: Create'DestinationPaymentMethodData, ?destinationPaymentMethodOptions: Create'DestinationPaymentMethodOptions, ?endUserDetails: Create'EndUserDetails, ?expand: string list, ?metadata: Map<string, string>, ?statementDescriptor: string) =
            {
                Amount = amount
                Currency = currency
                Customer = customer
                Description = description
                DestinationPaymentMethod = destinationPaymentMethod
                DestinationPaymentMethodData = destinationPaymentMethodData
                DestinationPaymentMethodOptions = destinationPaymentMethodOptions
                EndUserDetails = endUserDetails
                Expand = expand
                FinancialAccount = financialAccount
                Metadata = metadata
                StatementDescriptor = statementDescriptor
            }

    ///<summary><p>Creates an OutboundPayment.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/treasury/outbound_payments"
        |> RestApi.postAsync<_, TreasuryOutboundPayment> settings (Map.empty) options

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Expand = expand
                Id = id
            }

    ///<summary><p>Retrieves the details of an existing OutboundPayment by passing the unique OutboundPayment ID from either the OutboundPayment creation request or OutboundPayment list.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/treasury/outbound_payments/{options.Id}"
        |> RestApi.getAsync<TreasuryOutboundPayment> settings qs

module TreasuryOutboundPaymentsCancel =

    type CancelOptions = {
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

    ///<summary><p>Cancel an OutboundPayment.</p></summary>
    let Cancel settings (options: CancelOptions) =
        $"/v1/treasury/outbound_payments/{options.Id}/cancel"
        |> RestApi.postAsync<_, TreasuryOutboundPayment> settings (Map.empty) options

module TreasuryOutboundTransfers =

    type ListOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>Returns objects associated with this FinancialAccount.</summary>
        [<Config.Query>]FinancialAccount: string
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Only return OutboundTransfers that have the given status: `processing`, `canceled`, `failed`, `posted`, or `returned`.</summary>
        [<Config.Query>]Status: string option
    }
    with
        static member New(financialAccount: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                FinancialAccount = financialAccount
                Limit = limit
                StartingAfter = startingAfter
                Status = status
            }

    ///<summary><p>Returns a list of OutboundTransfers sent from the specified FinancialAccount.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("financial_account", options.FinancialAccount |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/treasury/outbound_transfers"
        |> RestApi.getAsync<StripeList<TreasuryOutboundTransfer>> settings qs

    type Create'DestinationPaymentMethodDataType =
    | FinancialAccount

    type Create'DestinationPaymentMethodData = {
        ///<summary>Required if type is set to `financial_account`. The FinancialAccount ID to send funds to.</summary>
        [<Config.Form>]FinancialAccount: string option
        ///<summary>The type of the destination.</summary>
        [<Config.Form>]Type: Create'DestinationPaymentMethodDataType option
    }
    with
        static member New(?financialAccount: string, ?type': Create'DestinationPaymentMethodDataType) =
            {
                FinancialAccount = financialAccount
                Type = type'
            }

    type Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptionsNetwork =
    | Ach
    | UsDomesticWire

    type Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptions = {
        ///<summary>Specifies the network rails to be used. If not set, will default to the PaymentMethod's preferred network. See the [docs](https://docs.stripe.com/treasury/money-movement/timelines) to learn more about money movement timelines for each network type.</summary>
        [<Config.Form>]Network: Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptionsNetwork option
    }
    with
        static member New(?network: Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptionsNetwork) =
            {
                Network = network
            }

    type Create'DestinationPaymentMethodOptions = {
        ///<summary>Optional fields for `us_bank_account`.</summary>
        [<Config.Form>]UsBankAccount: Choice<Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptions,string> option
    }
    with
        static member New(?usBankAccount: Choice<Create'DestinationPaymentMethodOptionsUsBankAccountPaymentMethodOptions,string>) =
            {
                UsBankAccount = usBankAccount
            }

    type CreateOptions = {
        ///<summary>Amount (in cents) to be transferred.</summary>
        [<Config.Form>]Amount: int
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode
        ///<summary>An arbitrary string attached to the object. Often useful for displaying to users.</summary>
        [<Config.Form>]Description: string option
        ///<summary>The PaymentMethod to use as the payment instrument for the OutboundTransfer.</summary>
        [<Config.Form>]DestinationPaymentMethod: string option
        ///<summary>Hash used to generate the PaymentMethod to be used for this OutboundTransfer. Exclusive with `destination_payment_method`.</summary>
        [<Config.Form>]DestinationPaymentMethodData: Create'DestinationPaymentMethodData option
        ///<summary>Hash describing payment method configuration details.</summary>
        [<Config.Form>]DestinationPaymentMethodOptions: Create'DestinationPaymentMethodOptions option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The FinancialAccount to pull funds from.</summary>
        [<Config.Form>]FinancialAccount: string
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Statement descriptor to be shown on the receiving end of an OutboundTransfer. Maximum 10 characters for `ach` transfers or 140 characters for `us_domestic_wire` transfers. The default value is "transfer". Can only include -#.$&*, spaces, and alphanumeric characters.</summary>
        [<Config.Form>]StatementDescriptor: string option
    }
    with
        static member New(amount: int, currency: IsoTypes.IsoCurrencyCode, financialAccount: string, ?description: string, ?destinationPaymentMethod: string, ?destinationPaymentMethodData: Create'DestinationPaymentMethodData, ?destinationPaymentMethodOptions: Create'DestinationPaymentMethodOptions, ?expand: string list, ?metadata: Map<string, string>, ?statementDescriptor: string) =
            {
                Amount = amount
                Currency = currency
                Description = description
                DestinationPaymentMethod = destinationPaymentMethod
                DestinationPaymentMethodData = destinationPaymentMethodData
                DestinationPaymentMethodOptions = destinationPaymentMethodOptions
                Expand = expand
                FinancialAccount = financialAccount
                Metadata = metadata
                StatementDescriptor = statementDescriptor
            }

    ///<summary><p>Creates an OutboundTransfer.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/treasury/outbound_transfers"
        |> RestApi.postAsync<_, TreasuryOutboundTransfer> settings (Map.empty) options

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]OutboundTransfer: string
    }
    with
        static member New(outboundTransfer: string, ?expand: string list) =
            {
                Expand = expand
                OutboundTransfer = outboundTransfer
            }

    ///<summary><p>Retrieves the details of an existing OutboundTransfer by passing the unique OutboundTransfer ID from either the OutboundTransfer creation request or OutboundTransfer list.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/treasury/outbound_transfers/{options.OutboundTransfer}"
        |> RestApi.getAsync<TreasuryOutboundTransfer> settings qs

module TreasuryOutboundTransfersCancel =

    type CancelOptions = {
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

    ///<summary><p>An OutboundTransfer can be canceled if the funds have not yet been paid out.</p></summary>
    let Cancel settings (options: CancelOptions) =
        $"/v1/treasury/outbound_transfers/{options.OutboundTransfer}/cancel"
        |> RestApi.postAsync<_, TreasuryOutboundTransfer> settings (Map.empty) options

module TreasuryReceivedCredits =

    type ListOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>The FinancialAccount that received the funds.</summary>
        [<Config.Query>]FinancialAccount: string
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>Only return ReceivedCredits described by the flow.</summary>
        [<Config.Query>]LinkedFlows: Map<string, string> option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Only return ReceivedCredits that have the given status: `succeeded` or `failed`.</summary>
        [<Config.Query>]Status: string option
    }
    with
        static member New(financialAccount: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?linkedFlows: Map<string, string>, ?startingAfter: string, ?status: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                FinancialAccount = financialAccount
                Limit = limit
                LinkedFlows = linkedFlows
                StartingAfter = startingAfter
                Status = status
            }

    ///<summary><p>Returns a list of ReceivedCredits.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("financial_account", options.FinancialAccount |> box); ("limit", options.Limit |> box); ("linked_flows", options.LinkedFlows |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/treasury/received_credits"
        |> RestApi.getAsync<StripeList<TreasuryReceivedCredit>> settings qs

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Expand = expand
                Id = id
            }

    ///<summary><p>Retrieves the details of an existing ReceivedCredit by passing the unique ReceivedCredit ID from the ReceivedCredit list.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/treasury/received_credits/{options.Id}"
        |> RestApi.getAsync<TreasuryReceivedCredit> settings qs

module TreasuryReceivedDebits =

    type ListOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>The FinancialAccount that funds were pulled from.</summary>
        [<Config.Query>]FinancialAccount: string
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Only return ReceivedDebits that have the given status: `succeeded` or `failed`.</summary>
        [<Config.Query>]Status: string option
    }
    with
        static member New(financialAccount: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                FinancialAccount = financialAccount
                Limit = limit
                StartingAfter = startingAfter
                Status = status
            }

    ///<summary><p>Returns a list of ReceivedDebits.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("financial_account", options.FinancialAccount |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/treasury/received_debits"
        |> RestApi.getAsync<StripeList<TreasuryReceivedDebit>> settings qs

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Expand = expand
                Id = id
            }

    ///<summary><p>Retrieves the details of an existing ReceivedDebit by passing the unique ReceivedDebit ID from the ReceivedDebit list</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/treasury/received_debits/{options.Id}"
        |> RestApi.getAsync<TreasuryReceivedDebit> settings qs

module TreasuryTransactionEntries =

    type ListOptions = {
        ///<summary>Only return TransactionEntries that were created during the given date interval.</summary>
        [<Config.Query>]Created: int option
        [<Config.Query>]EffectiveAt: int option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>Returns objects associated with this FinancialAccount.</summary>
        [<Config.Query>]FinancialAccount: string
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>The results are in reverse chronological order by `created` or `effective_at`. The default is `created`.</summary>
        [<Config.Query>]OrderBy: string option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Only return TransactionEntries associated with this Transaction.</summary>
        [<Config.Query>]Transaction: string option
    }
    with
        static member New(financialAccount: string, ?created: int, ?effectiveAt: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?orderBy: string, ?startingAfter: string, ?transaction: string) =
            {
                Created = created
                EffectiveAt = effectiveAt
                EndingBefore = endingBefore
                Expand = expand
                FinancialAccount = financialAccount
                Limit = limit
                OrderBy = orderBy
                StartingAfter = startingAfter
                Transaction = transaction
            }

    ///<summary><p>Retrieves a list of TransactionEntry objects.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("effective_at", options.EffectiveAt |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("financial_account", options.FinancialAccount |> box); ("limit", options.Limit |> box); ("order_by", options.OrderBy |> box); ("starting_after", options.StartingAfter |> box); ("transaction", options.Transaction |> box)] |> Map.ofList
        $"/v1/treasury/transaction_entries"
        |> RestApi.getAsync<StripeList<TreasuryTransactionEntry>> settings qs

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Expand = expand
                Id = id
            }

    ///<summary><p>Retrieves a TransactionEntry object.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/treasury/transaction_entries/{options.Id}"
        |> RestApi.getAsync<TreasuryTransactionEntry> settings qs

module TreasuryTransactions =

    type ListOptions = {
        ///<summary>Only return Transactions that were created during the given date interval.</summary>
        [<Config.Query>]Created: int option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>Returns objects associated with this FinancialAccount.</summary>
        [<Config.Query>]FinancialAccount: string
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>The results are in reverse chronological order by `created` or `posted_at`. The default is `created`.</summary>
        [<Config.Query>]OrderBy: string option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Only return Transactions that have the given status: `open`, `posted`, or `void`.</summary>
        [<Config.Query>]Status: string option
        ///<summary>A filter for the `status_transitions.posted_at` timestamp. When using this filter, `status=posted` and `order_by=posted_at` must also be specified.</summary>
        [<Config.Query>]StatusTransitions: Map<string, string> option
    }
    with
        static member New(financialAccount: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?orderBy: string, ?startingAfter: string, ?status: string, ?statusTransitions: Map<string, string>) =
            {
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                FinancialAccount = financialAccount
                Limit = limit
                OrderBy = orderBy
                StartingAfter = startingAfter
                Status = status
                StatusTransitions = statusTransitions
            }

    ///<summary><p>Retrieves a list of Transaction objects.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("financial_account", options.FinancialAccount |> box); ("limit", options.Limit |> box); ("order_by", options.OrderBy |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("status_transitions", options.StatusTransitions |> box)] |> Map.ofList
        $"/v1/treasury/transactions"
        |> RestApi.getAsync<StripeList<TreasuryTransaction>> settings qs

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Expand = expand
                Id = id
            }

    ///<summary><p>Retrieves the details of an existing Transaction.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/treasury/transactions/{options.Id}"
        |> RestApi.getAsync<TreasuryTransaction> settings qs
