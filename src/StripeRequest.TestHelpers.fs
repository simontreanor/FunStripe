namespace FunStripe.StripeRequest

open FunStripe
open FunStripe.Json
open FunStripe.StripeModel
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module TestHelpersCustomersFundCashBalance =

    type FundCashBalanceOptions = {
        [<Config.Path>]Customer: string
        ///Amount to be used for this test cash balance transaction. A positive integer representing how much to fund in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal) (e.g., 100 cents to fund $1.00 or 100 to fund ¥100, a zero-decimal currency).
        [<Config.Form>]Amount: int
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///A description of the test funding. This simulates free-text references supplied by customers when making bank transfers to their cash balance. You can use this to test how Stripe's [reconciliation algorithm](https://stripe.com/docs/payments/customer-balance/reconciliation) applies to different user inputs.
        [<Config.Form>]Reference: string option
    }
    with
        static member New(customer: string, amount: int, currency: string, ?expand: string list, ?reference: string) =
            {
                Customer = customer
                Amount = amount
                Currency = currency
                Expand = expand
                Reference = reference
            }

    ///<p>Create an incoming testmode bank transfer</p>
    let FundCashBalance settings (options: FundCashBalanceOptions) =
        $"/v1/test_helpers/customers/{options.Customer}/fund_cash_balance"
        |> RestApi.postAsync<_, CustomerCashBalanceTransaction> settings (Map.empty) options

module TestHelpersIssuingCardsShippingDeliver =

    type DeliverCardOptions = {
        [<Config.Path>]Card: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
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

    type FailCardOptions = {
        [<Config.Path>]Card: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
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

    type ReturnCardOptions = {
        [<Config.Path>]Card: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
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

    type ShipCardOptions = {
        [<Config.Path>]Card: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(card: string, ?expand: string list) =
            {
                Card = card
                Expand = expand
            }

    ///<p>Updates the shipping status of the specified Issuing <code>Card</code> object to <code>shipped</code>.</p>
    let ShipCard settings (options: ShipCardOptions) =
        $"/v1/test_helpers/issuing/cards/{options.Card}/shipping/ship"
        |> RestApi.postAsync<_, IssuingCard> settings (Map.empty) options

module TestHelpersRefundsExpire =

    type ExpireOptions = {
        [<Config.Path>]Refund: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
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

    type PresentPaymentMethod'CardPresent = {
        ///The card number, as a string without any separators.
        [<Config.Form>]Number: string option
    }
    with
        static member New(?number: string) =
            {
                Number = number
            }

    type PresentPaymentMethod'InteracPresent = {
        ///Card Number
        [<Config.Form>]Number: string option
    }
    with
        static member New(?number: string) =
            {
                Number = number
            }

    type PresentPaymentMethod'Type =
    | CardPresent
    | InteracPresent

    type PresentPaymentMethodOptions = {
        [<Config.Path>]Reader: string
        ///Simulated on-reader tip amount.
        [<Config.Form>]AmountTip: int option
        ///Simulated data for the card_present payment method.
        [<Config.Form>]CardPresent: PresentPaymentMethod'CardPresent option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Simulated data for the interac_present payment method.
        [<Config.Form>]InteracPresent: PresentPaymentMethod'InteracPresent option
        ///Simulated payment type.
        [<Config.Form>]Type: PresentPaymentMethod'Type option
    }
    with
        static member New(reader: string, ?amountTip: int, ?cardPresent: PresentPaymentMethod'CardPresent, ?expand: string list, ?interacPresent: PresentPaymentMethod'InteracPresent, ?type': PresentPaymentMethod'Type) =
            {
                Reader = reader
                AmountTip = amountTip
                CardPresent = cardPresent
                Expand = expand
                InteracPresent = interacPresent
                Type = type'
            }

    ///<p>Presents a payment method on a simulated reader. Can be used to simulate accepting a payment, saving a card or refunding a transaction.</p>
    let PresentPaymentMethod settings (options: PresentPaymentMethodOptions) =
        $"/v1/test_helpers/terminal/readers/{options.Reader}/present_payment_method"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TestHelpersTestClocks =

    type ListOptions = {
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
        static member New(?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of your test clocks.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/test_helpers/test_clocks"
        |> RestApi.getAsync<TestHelpersTestClock list> settings qs

    type CreateOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The initial frozen time for this test clock.
        [<Config.Form>]FrozenTime: DateTime
        ///The name for this test clock.
        [<Config.Form>]Name: string option
    }
    with
        static member New(frozenTime: DateTime, ?expand: string list, ?name: string) =
            {
                Expand = expand
                FrozenTime = frozenTime
                Name = name
            }

    ///<p>Creates a new test clock that can be attached to new customers and quotes.</p>
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

    ///<p>Deletes a test clock.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/test_helpers/test_clocks/{options.TestClock}"
        |> RestApi.deleteAsync<DeletedTestHelpersTestClock> settings (Map.empty)

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]TestClock: string
    }
    with
        static member New(testClock: string, ?expand: string list) =
            {
                Expand = expand
                TestClock = testClock
            }

    ///<p>Retrieves a test clock.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/test_helpers/test_clocks/{options.TestClock}"
        |> RestApi.getAsync<TestHelpersTestClock> settings qs

module TestHelpersTestClocksAdvance =

    type AdvanceOptions = {
        [<Config.Path>]TestClock: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The time to advance the test clock. Must be after the test clock's current frozen time. Cannot be more than two intervals in the future from the shortest subscription in this test clock. If there are no subscriptions in this test clock, it cannot be more than two years in the future.
        [<Config.Form>]FrozenTime: DateTime
    }
    with
        static member New(testClock: string, frozenTime: DateTime, ?expand: string list) =
            {
                TestClock = testClock
                Expand = expand
                FrozenTime = frozenTime
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

    type Fail'FailureDetails = {
        ///Reason for the failure.
        [<Config.Form>]Code: Fail'FailureDetailsCode option
    }
    with
        static member New(?code: Fail'FailureDetailsCode) =
            {
                Code = code
            }

    type FailOptions = {
        [<Config.Path>]Id: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Details about a failed InboundTransfer.
        [<Config.Form>]FailureDetails: Fail'FailureDetails option
    }
    with
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

    type ReturnInboundTransferOptions = {
        [<Config.Path>]Id: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
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

    type SucceedOptions = {
        [<Config.Path>]Id: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    ///<p>Transitions a test mode created InboundTransfer to the <code>succeeded</code> status. The InboundTransfer must already be in the <code>processing</code> state.</p>
    let Succeed settings (options: SucceedOptions) =
        $"/v1/test_helpers/treasury/inbound_transfers/{options.Id}/succeed"
        |> RestApi.postAsync<_, TreasuryInboundTransfer> settings (Map.empty) options

module TestHelpersTreasuryOutboundPaymentsFail =

    type FailOptions = {
        [<Config.Path>]Id: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
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

    type PostOptions = {
        [<Config.Path>]Id: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
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

    type ReturnOutboundPayment'ReturnedDetails = {
        ///The return code to be set on the OutboundPayment object.
        [<Config.Form>]Code: ReturnOutboundPayment'ReturnedDetailsCode option
    }
    with
        static member New(?code: ReturnOutboundPayment'ReturnedDetailsCode) =
            {
                Code = code
            }

    type ReturnOutboundPaymentOptions = {
        [<Config.Path>]Id: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Optional hash to set the the return code.
        [<Config.Form>]ReturnedDetails: ReturnOutboundPayment'ReturnedDetails option
    }
    with
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

module TestHelpersTreasuryOutboundTransfersFail =

    type FailOptions = {
        [<Config.Path>]OutboundTransfer: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
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

    type PostOptions = {
        [<Config.Path>]OutboundTransfer: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
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

    type ReturnOutboundTransfer'ReturnedDetails = {
        ///Reason for the return.
        [<Config.Form>]Code: ReturnOutboundTransfer'ReturnedDetailsCode option
    }
    with
        static member New(?code: ReturnOutboundTransfer'ReturnedDetailsCode) =
            {
                Code = code
            }

    type ReturnOutboundTransferOptions = {
        [<Config.Path>]OutboundTransfer: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Details about a returned OutboundTransfer.
        [<Config.Form>]ReturnedDetails: ReturnOutboundTransfer'ReturnedDetails option
    }
    with
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

    type Create'InitiatingPaymentMethodDetailsUsBankAccount = {
        ///The bank account holder's name.
        [<Config.Form>]AccountHolderName: string option
        ///The bank account number.
        [<Config.Form>]AccountNumber: string option
        ///The bank account's routing number.
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
        ///The source type.
        [<Config.Form>]Type: Create'InitiatingPaymentMethodDetailsType option
        ///Optional fields for `us_bank_account`.
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
        ///Amount (in cents) to be transferred.
        [<Config.Form>]Amount: int
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        [<Config.Form>]Description: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The FinancialAccount to send funds to.
        [<Config.Form>]FinancialAccount: string
        ///Initiating payment method details for the object.
        [<Config.Form>]InitiatingPaymentMethodDetails: Create'InitiatingPaymentMethodDetails option
        ///The rails used for the object.
        [<Config.Form>]Network: Create'Network
    }
    with
        static member New(amount: int, currency: string, financialAccount: string, network: Create'Network, ?description: string, ?expand: string list, ?initiatingPaymentMethodDetails: Create'InitiatingPaymentMethodDetails) =
            {
                Amount = amount
                Currency = currency
                Description = description
                Expand = expand
                FinancialAccount = financialAccount
                InitiatingPaymentMethodDetails = initiatingPaymentMethodDetails
                Network = network
            }

    ///<p>Use this endpoint to simulate a test mode ReceivedCredit initiated by a third party. In live mode, you can’t directly create ReceivedCredits initiated by third parties.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/test_helpers/treasury/received_credits"
        |> RestApi.postAsync<_, TreasuryReceivedCredit> settings (Map.empty) options

module TestHelpersTreasuryReceivedDebits =

    type Create'InitiatingPaymentMethodDetailsUsBankAccount = {
        ///The bank account holder's name.
        [<Config.Form>]AccountHolderName: string option
        ///The bank account number.
        [<Config.Form>]AccountNumber: string option
        ///The bank account's routing number.
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
        ///The source type.
        [<Config.Form>]Type: Create'InitiatingPaymentMethodDetailsType option
        ///Optional fields for `us_bank_account`.
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
        ///Amount (in cents) to be transferred.
        [<Config.Form>]Amount: int
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        [<Config.Form>]Description: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The FinancialAccount to pull funds from.
        [<Config.Form>]FinancialAccount: string
        ///Initiating payment method details for the object.
        [<Config.Form>]InitiatingPaymentMethodDetails: Create'InitiatingPaymentMethodDetails option
        ///The rails used for the object.
        [<Config.Form>]Network: Create'Network
    }
    with
        static member New(amount: int, currency: string, financialAccount: string, network: Create'Network, ?description: string, ?expand: string list, ?initiatingPaymentMethodDetails: Create'InitiatingPaymentMethodDetails) =
            {
                Amount = amount
                Currency = currency
                Description = description
                Expand = expand
                FinancialAccount = financialAccount
                InitiatingPaymentMethodDetails = initiatingPaymentMethodDetails
                Network = network
            }

    ///<p>Use this endpoint to simulate a test mode ReceivedDebit initiated by a third party. In live mode, you can’t directly create ReceivedDebits initiated by third parties.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/test_helpers/treasury/received_debits"
        |> RestApi.postAsync<_, TreasuryReceivedDebit> settings (Map.empty) options
