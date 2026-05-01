namespace StripeRequest.Invoices

open FunStripe
open System.Text.Json.Serialization
open Stripe.PaymentMethod
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
module Invoices =

    type ListOptions =
        {
            /// The collection method of the invoice to retrieve. Either `charge_automatically` or `send_invoice`.
            [<Config.Query>]
            CollectionMethod: string option
            /// Only return invoices that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// Only return invoices for the customer specified by this customer ID.
            [<Config.Query>]
            Customer: string option
            /// Only return invoices for the account representing the customer specified by this account ID.
            [<Config.Query>]
            CustomerAccount: string option
            [<Config.Query>]
            DueDate: int option
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
            /// The status of the invoice, one of `draft`, `open`, `paid`, `uncollectible`, or `void`. [Learn more](https://docs.stripe.com/billing/invoices/workflow#workflow-overview)
            [<Config.Query>]
            Status: string option
            /// Only return invoices for the subscription specified by this subscription ID.
            [<Config.Query>]
            Subscription: string option
        }

    type ListOptions with
        static member New(?collectionMethod: string, ?created: int, ?customer: string, ?customerAccount: string, ?dueDate: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string, ?subscription: string) =
            {
                CollectionMethod = collectionMethod
                Created = created
                Customer = customer
                CustomerAccount = customerAccount
                DueDate = dueDate
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Status = status
                Subscription = subscription
            }

    type Create'AutomaticTaxLiabilityType =
        | Account
        | Self

    type Create'AutomaticTaxLiability =
        {
            /// The connected account being referenced when `type` is `account`.
            [<Config.Form>]
            Account: string option
            /// Type of the account referenced in the request.
            [<Config.Form>]
            Type: Create'AutomaticTaxLiabilityType option
        }

    type Create'AutomaticTaxLiability with
        static member New(?account: string, ?type': Create'AutomaticTaxLiabilityType) =
            {
                Account = account
                Type = type'
            }

    type Create'AutomaticTax =
        {
            /// Whether Stripe automatically computes tax on this invoice. Note that incompatible invoice items (invoice items with manually specified [tax rates](https://docs.stripe.com/api/tax_rates), negative amounts, or `tax_behavior=unspecified`) cannot be added to automatic tax invoices.
            [<Config.Form>]
            Enabled: bool option
            /// The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.
            [<Config.Form>]
            Liability: Create'AutomaticTaxLiability option
        }

    type Create'AutomaticTax with
        static member New(?enabled: bool, ?liability: Create'AutomaticTaxLiability) =
            {
                Enabled = enabled
                Liability = liability
            }

    type Create'CollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    type Create'CustomFields =
        {
            /// The name of the custom field. This may be up to 40 characters.
            [<Config.Form>]
            Name: string option
            /// The value of the custom field. This may be up to 140 characters.
            [<Config.Form>]
            Value: string option
        }

    type Create'CustomFields with
        static member New(?name: string, ?value: string) =
            {
                Name = name
                Value = value
            }

    type Create'Discounts =
        {
            /// ID of the coupon to create a new discount for.
            [<Config.Form>]
            Coupon: string option
            /// ID of an existing discount on the object (or one of its ancestors) to reuse.
            [<Config.Form>]
            Discount: string option
            /// ID of the promotion code to create a new discount for.
            [<Config.Form>]
            PromotionCode: string option
        }

    type Create'Discounts with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Create'FromInvoiceAction = | Revision

    type Create'FromInvoice =
        {
            /// The relation between the new invoice and the original invoice. Currently, only 'revision' is permitted
            [<Config.Form>]
            Action: Create'FromInvoiceAction option
            /// The `id` of the invoice that will be cloned.
            [<Config.Form>]
            Invoice: string option
        }

    type Create'FromInvoice with
        static member New(?action: Create'FromInvoiceAction, ?invoice: string) =
            {
                Action = action
                Invoice = invoice
            }

    type Create'IssuerType =
        | Account
        | Self

    type Create'Issuer =
        {
            /// The connected account being referenced when `type` is `account`.
            [<Config.Form>]
            Account: string option
            /// Type of the account referenced in the request.
            [<Config.Form>]
            Type: Create'IssuerType option
        }

    type Create'Issuer with
        static member New(?account: string, ?type': Create'IssuerType) =
            {
                Account = account
                Type = type'
            }

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType =
        | Business
        | Personal

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions =
        {
            /// Transaction type of the mandate.
            [<Config.Form>]
            TransactionType:
                Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType option
        }

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions with
        static member New(?transactionType: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType) =
            {
                TransactionType = transactionType
            }

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod =
        | Automatic
        | Instant
        | Microdeposits

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions =
        {
            /// Additional fields for Mandate creation
            [<Config.Form>]
            MandateOptions:
                Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions option
            /// Verification method for the intent
            [<Config.Form>]
            VerificationMethod:
                Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod option
        }

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions with
        static member New(?mandateOptions: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions, ?verificationMethod: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod) =
            {
                MandateOptions = mandateOptions
                VerificationMethod = verificationMethod
            }

    type Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage =
        | De
        | En
        | Fr
        | Nl

    type Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions =
        {
            /// Preferred language of the Bancontact authorization page that the customer is redirected to.
            [<Config.Form>]
            PreferredLanguage:
                Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage option
        }

    type Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions with
        static member New(?preferredLanguage: Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage) =
            {
                PreferredLanguage = preferredLanguage
            }

    type Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanInterval =
        | Month

    type Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanType =
        | Bonus
        | FixedCount
        | Revolving

    type Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlan =
        {
            /// For `fixed_count` installment plans, this is required. It represents the number of installment payments your customer will make to their credit card.
            [<Config.Form>]
            Count: int option
            /// For `fixed_count` installment plans, this is required. It represents the interval between installment payments your customer will make to their credit card.
            /// One of `month`.
            [<Config.Form>]
            Interval:
                Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanInterval option
            /// Type of installment plan, one of `fixed_count`, `bonus`, or `revolving`.
            [<Config.Form>]
            Type:
                Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanType option
        }

    type Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlan with
        static member New(?count: int, ?interval: Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanInterval, ?type': Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanType) =
            {
                Count = count
                Interval = interval
                Type = type'
            }

    type Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallments =
        {
            /// Setting to true enables installments for this invoice.
            /// Setting to false will prevent any selected plan from applying to a payment.
            [<Config.Form>]
            Enabled: bool option
            /// The selected installment plan to use for this invoice.
            [<Config.Form>]
            Plan:
                Choice<Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlan,string> option
        }

    type Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallments with
        static member New(?enabled: bool, ?plan: Choice<Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlan,string>) =
            {
                Enabled = enabled
                Plan = plan
            }

    type Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsRequestThreeDSecure =
        | Any
        | Automatic
        | Challenge

    type Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptions =
        {
            /// Installment configuration for payments attempted on this invoice.
            /// For more information, see the [installments integration guide](https://docs.stripe.com/payments/installments).
            [<Config.Form>]
            Installments: Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallments option
            /// We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://docs.stripe.com/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Read our guide on [manually requesting 3D Secure](https://docs.stripe.com/payments/3d-secure/authentication-flow#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
            [<Config.Form>]
            RequestThreeDSecure:
                Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsRequestThreeDSecure option
        }

    type Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptions with
        static member New(?installments: Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallments, ?requestThreeDSecure: Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsRequestThreeDSecure) =
            {
                Installments = installments
                RequestThreeDSecure = requestThreeDSecure
            }

    type Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer =
        {
            /// The desired country code of the bank account information. Permitted values include: `DE`, `FR`, `IE`, or `NL`.
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
        }

    type Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer with
        static member New(?country: IsoTypes.IsoCountryCode) =
            {
                Country = country
            }

    type Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer =
        {
            /// Configuration for eu_bank_transfer funding type.
            [<Config.Form>]
            EuBankTransfer:
                Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer option
            /// The bank transfer type that can be used for funding. Permitted values include: `eu_bank_transfer`, `gb_bank_transfer`, `jp_bank_transfer`, `mx_bank_transfer`, or `us_bank_transfer`.
            [<Config.Form>]
            Type: string option
        }

    type Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer with
        static member New(?euBankTransfer: Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer, ?type': string) =
            {
                EuBankTransfer = euBankTransfer
                Type = type'
            }

    type Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions =
        {
            /// Configuration for the bank transfer funding type, if the `funding_type` is set to `bank_transfer`.
            [<Config.Form>]
            BankTransfer:
                Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer option
            /// The funding method type to be used when there are not enough funds in the customer balance. Permitted values include: `bank_transfer`.
            [<Config.Form>]
            FundingType: string option
        }

    type Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions with
        static member New(?bankTransfer: Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer, ?fundingType: string) =
            {
                BankTransfer = bankTransfer
                FundingType = fundingType
            }

    type Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose =
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

    type Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions =
        {
            /// The maximum amount that can be collected in a single invoice. If you don't specify a maximum, then there is no limit.
            [<Config.Form>]
            Amount: int option
            /// The purpose for which payments are made. Has a default value based on your merchant category code.
            [<Config.Form>]
            Purpose: Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose option
        }

    type Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions with
        static member New(?amount: int, ?purpose: Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose) =
            {
                Amount = amount
                Purpose = purpose
            }

    type Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions =
        {
            /// Additional fields for Mandate creation.
            [<Config.Form>]
            MandateOptions: Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions option
        }

    type Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions with
        static member New(?mandateOptions: Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Create'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptionsAmountIncludesIof =
        | Always
        | Never

    type Create'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptions =
        {
            /// Determines if the amount includes the IOF tax. Defaults to `never`.
            [<Config.Form>]
            AmountIncludesIof:
                Create'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptionsAmountIncludesIof option
            /// The number of seconds (between 10 and 1209600) after which Pix payment will expire. Defaults to 86400 seconds.
            [<Config.Form>]
            ExpiresAfterSeconds: int option
        }

    type Create'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptions with
        static member New(?amountIncludesIof: Create'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptionsAmountIncludesIof, ?expiresAfterSeconds: int) =
            {
                AmountIncludesIof = amountIncludesIof
                ExpiresAfterSeconds = expiresAfterSeconds
            }

    type Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions =
        {
            /// Amount to be charged for future payments.
            [<Config.Form>]
            Amount: int option
            /// One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
            [<Config.Form>]
            AmountType:
                Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType option
            /// A description of the mandate or subscription that is meant to be displayed to the customer.
            [<Config.Form>]
            Description: string option
            /// End date of the mandate or subscription.
            [<Config.Form>]
            EndDate: DateTime option
        }

    type Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions with
        static member New(?amount: int, ?amountType: Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType, ?description: string, ?endDate: DateTime) =
            {
                Amount = amount
                AmountType = amountType
                Description = description
                EndDate = endDate
            }

    type Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions =
        {
            /// Configuration options for setting up an eMandate
            [<Config.Form>]
            MandateOptions: Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions option
        }

    type Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions with
        static member New(?mandateOptions: Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories
        =
        | Checking
        | Savings

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters =
        {
            /// The account subcategories to use to filter for selectable accounts. Valid subcategories are `checking` and `savings`.
            [<Config.Form>]
            AccountSubcategories:
                Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories list option
        }

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters with
        static member New(?accountSubcategories: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories list) =
            {
                AccountSubcategories = accountSubcategories
            }

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions =
        | Balances
        | Ownership
        | PaymentMethod
        | Transactions

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch =
        | Balances
        | Ownership
        | Transactions

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections =
        {
            /// Provide filters for the linked accounts that the customer can select for the payment method.
            [<Config.Form>]
            Filters:
                Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters option
            /// The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.
            [<Config.Form>]
            Permissions:
                Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list option
            /// List of data features that you would like to retrieve upon account creation.
            [<Config.Form>]
            Prefetch:
                Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list option
        }

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections with
        static member New(?filters: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters, ?permissions: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list, ?prefetch: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list) =
            {
                Filters = filters
                Permissions = permissions
                Prefetch = prefetch
            }

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod =
        | Automatic
        | Instant
        | Microdeposits

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions =
        {
            /// Additional fields for Financial Connections Session creation
            [<Config.Form>]
            FinancialConnections:
                Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections option
            /// Verification method for the intent
            [<Config.Form>]
            VerificationMethod:
                Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod option
        }

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions with
        static member New(?financialConnections: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections, ?verificationMethod: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod) =
            {
                FinancialConnections = financialConnections
                VerificationMethod = verificationMethod
            }

    type Create'PaymentSettingsPaymentMethodOptions =
        {
            /// If paying by `acss_debit`, this sub-hash contains details about the Canadian pre-authorized debit payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            AcssDebit: Choice<Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string> option
            /// If paying by `bancontact`, this sub-hash contains details about the Bancontact payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Bancontact:
                Choice<Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string> option
            /// If paying by `card`, this sub-hash contains details about the Card payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Card: Choice<Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptions,string> option
            /// If paying by `customer_balance`, this sub-hash contains details about the Bank transfer payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            CustomerBalance:
                Choice<Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string> option
            /// If paying by `konbini`, this sub-hash contains details about the Konbini payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Konbini: Choice<string,string> option
            /// If paying by `payto`, this sub-hash contains details about the PayTo payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Payto: Choice<Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions,string> option
            /// If paying by `pix`, this sub-hash contains details about the Pix payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Pix: Choice<Create'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptions,string> option
            /// If paying by `sepa_debit`, this sub-hash contains details about the SEPA Direct Debit payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            SepaDebit: Choice<string,string> option
            /// If paying by `upi`, this sub-hash contains details about the UPI payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Upi: Choice<Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions,string> option
            /// If paying by `us_bank_account`, this sub-hash contains details about the ACH direct debit payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            UsBankAccount:
                Choice<Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string> option
        }

    type Create'PaymentSettingsPaymentMethodOptions with
        static member New(?acssDebit: Choice<Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string>, ?bancontact: Choice<Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string>, ?card: Choice<Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptions,string>, ?customerBalance: Choice<Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string>, ?konbini: Choice<string,string>, ?payto: Choice<Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions,string>, ?pix: Choice<Create'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptions,string>, ?sepaDebit: Choice<string,string>, ?upi: Choice<Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions,string>, ?usBankAccount: Choice<Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string>) =
            {
                AcssDebit = acssDebit
                Bancontact = bancontact
                Card = card
                CustomerBalance = customerBalance
                Konbini = konbini
                Payto = payto
                Pix = pix
                SepaDebit = sepaDebit
                Upi = upi
                UsBankAccount = usBankAccount
            }

    type Create'PaymentSettingsPaymentMethodTypes =
        | AchCreditTransfer
        | AchDebit
        | AcssDebit
        | Affirm
        | AmazonPay
        | AuBecsDebit
        | BacsDebit
        | Bancontact
        | Boleto
        | Card
        | Cashapp
        | Crypto
        | Custom
        | CustomerBalance
        | Eps
        | Fpx
        | Giropay
        | Grabpay
        | Ideal
        | JpCreditTransfer
        | KakaoPay
        | Klarna
        | Konbini
        | KrCard
        | Link
        | Multibanco
        | NaverPay
        | NzBankAccount
        | P24
        | PayByBank
        | Payco
        | Paynow
        | Paypal
        | Payto
        | Pix
        | Promptpay
        | RevolutPay
        | SepaCreditTransfer
        | SepaDebit
        | Sofort
        | Swish
        | Upi
        | UsBankAccount
        | WechatPay

    type Create'PaymentSettings =
        {
            /// ID of the mandate to be used for this invoice. It must correspond to the payment method used to pay the invoice, including the invoice's default_payment_method or default_source, if set.
            [<Config.Form>]
            DefaultMandate: Choice<string,string> option
            /// Payment-method-specific configuration to provide to the invoice’s PaymentIntent.
            [<Config.Form>]
            PaymentMethodOptions: Create'PaymentSettingsPaymentMethodOptions option
            /// The list of payment method types (e.g. card) to provide to the invoice’s PaymentIntent. If not set, Stripe attempts to automatically determine the types to use by looking at the invoice’s default payment method, the subscription’s default payment method, the customer’s default payment method, and your [invoice template settings](https://dashboard.stripe.com/settings/billing/invoice).
            [<Config.Form>]
            PaymentMethodTypes: Choice<Create'PaymentSettingsPaymentMethodTypes list,string> option
        }

    type Create'PaymentSettings with
        static member New(?defaultMandate: Choice<string,string>, ?paymentMethodOptions: Create'PaymentSettingsPaymentMethodOptions, ?paymentMethodTypes: Choice<Create'PaymentSettingsPaymentMethodTypes list,string>) =
            {
                DefaultMandate = defaultMandate
                PaymentMethodOptions = paymentMethodOptions
                PaymentMethodTypes = paymentMethodTypes
            }

    type Create'PendingInvoiceItemsBehavior =
        | Exclude
        | Include

    type Create'RenderingAmountTaxDisplay =
        | ExcludeTax
        | IncludeInclusiveTax

    type Create'RenderingPdfPageSize =
        | A4
        | Auto
        | Letter

    type Create'RenderingPdf =
        {
            /// Page size for invoice PDF. Can be set to `a4`, `letter`, or `auto`.
            /// If set to `auto`, invoice PDF page size defaults to `a4` for customers with
            /// Japanese locale and `letter` for customers with other locales.
            [<Config.Form>]
            PageSize: Create'RenderingPdfPageSize option
        }

    type Create'RenderingPdf with
        static member New(?pageSize: Create'RenderingPdfPageSize) =
            {
                PageSize = pageSize
            }

    type Create'Rendering =
        {
            /// How line-item prices and amounts will be displayed with respect to tax on invoice PDFs. One of `exclude_tax` or `include_inclusive_tax`. `include_inclusive_tax` will include inclusive tax (and exclude exclusive tax) in invoice PDF amounts. `exclude_tax` will exclude all tax (inclusive and exclusive alike) from invoice PDF amounts.
            [<Config.Form>]
            AmountTaxDisplay: Create'RenderingAmountTaxDisplay option
            /// Invoice pdf rendering options
            [<Config.Form>]
            Pdf: Create'RenderingPdf option
            /// ID of the invoice rendering template to use for this invoice.
            [<Config.Form>]
            Template: string option
            /// The specific version of invoice rendering template to use for this invoice.
            [<Config.Form>]
            TemplateVersion: Choice<int,string> option
        }

    type Create'Rendering with
        static member New(?amountTaxDisplay: Create'RenderingAmountTaxDisplay, ?pdf: Create'RenderingPdf, ?template: string, ?templateVersion: Choice<int,string>) =
            {
                AmountTaxDisplay = amountTaxDisplay
                Pdf = pdf
                Template = template
                TemplateVersion = templateVersion
            }

    type Create'ShippingCostShippingRateDataDeliveryEstimateMaximumUnit =
        | BusinessDay
        | Day
        | Hour
        | Month
        | Week

    type Create'ShippingCostShippingRateDataDeliveryEstimateMaximum =
        {
            /// A unit of time.
            [<Config.Form>]
            Unit: Create'ShippingCostShippingRateDataDeliveryEstimateMaximumUnit option
            /// Must be greater than 0.
            [<Config.Form>]
            Value: int option
        }

    type Create'ShippingCostShippingRateDataDeliveryEstimateMaximum with
        static member New(?unit: Create'ShippingCostShippingRateDataDeliveryEstimateMaximumUnit, ?value: int) =
            {
                Unit = unit
                Value = value
            }

    type Create'ShippingCostShippingRateDataDeliveryEstimateMinimumUnit =
        | BusinessDay
        | Day
        | Hour
        | Month
        | Week

    type Create'ShippingCostShippingRateDataDeliveryEstimateMinimum =
        {
            /// A unit of time.
            [<Config.Form>]
            Unit: Create'ShippingCostShippingRateDataDeliveryEstimateMinimumUnit option
            /// Must be greater than 0.
            [<Config.Form>]
            Value: int option
        }

    type Create'ShippingCostShippingRateDataDeliveryEstimateMinimum with
        static member New(?unit: Create'ShippingCostShippingRateDataDeliveryEstimateMinimumUnit, ?value: int) =
            {
                Unit = unit
                Value = value
            }

    type Create'ShippingCostShippingRateDataDeliveryEstimate =
        {
            /// The upper bound of the estimated range. If empty, represents no upper bound i.e., infinite.
            [<Config.Form>]
            Maximum: Create'ShippingCostShippingRateDataDeliveryEstimateMaximum option
            /// The lower bound of the estimated range. If empty, represents no lower bound.
            [<Config.Form>]
            Minimum: Create'ShippingCostShippingRateDataDeliveryEstimateMinimum option
        }

    type Create'ShippingCostShippingRateDataDeliveryEstimate with
        static member New(?maximum: Create'ShippingCostShippingRateDataDeliveryEstimateMaximum, ?minimum: Create'ShippingCostShippingRateDataDeliveryEstimateMinimum) =
            {
                Maximum = maximum
                Minimum = minimum
            }

    type Create'ShippingCostShippingRateDataFixedAmount =
        {
            /// A non-negative integer in cents representing how much to charge.
            [<Config.Form>]
            Amount: int option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// Shipping rates defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            CurrencyOptions: Map<string, string> option
        }

    type Create'ShippingCostShippingRateDataFixedAmount with
        static member New(?amount: int, ?currency: IsoTypes.IsoCurrencyCode, ?currencyOptions: Map<string, string>) =
            {
                Amount = amount
                Currency = currency
                CurrencyOptions = currencyOptions
            }

    type Create'ShippingCostShippingRateDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type Create'ShippingCostShippingRateDataType = | FixedAmount

    type Create'ShippingCostShippingRateData =
        {
            /// The estimated range for how long shipping will take, meant to be displayable to the customer. This will appear on CheckoutSessions.
            [<Config.Form>]
            DeliveryEstimate: Create'ShippingCostShippingRateDataDeliveryEstimate option
            /// The name of the shipping rate, meant to be displayable to the customer. This will appear on CheckoutSessions.
            [<Config.Form>]
            DisplayName: string option
            /// Describes a fixed amount to charge for shipping. Must be present if type is `fixed_amount`.
            [<Config.Form>]
            FixedAmount: Create'ShippingCostShippingRateDataFixedAmount option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Specifies whether the rate is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`.
            [<Config.Form>]
            TaxBehavior: Create'ShippingCostShippingRateDataTaxBehavior option
            /// A [tax code](https://docs.stripe.com/tax/tax-categories) ID. The Shipping tax code is `txcd_92010001`.
            [<Config.Form>]
            TaxCode: string option
            /// The type of calculation to use on the shipping rate.
            [<Config.Form>]
            Type: Create'ShippingCostShippingRateDataType option
        }

    type Create'ShippingCostShippingRateData with
        static member New(?deliveryEstimate: Create'ShippingCostShippingRateDataDeliveryEstimate, ?displayName: string, ?fixedAmount: Create'ShippingCostShippingRateDataFixedAmount, ?metadata: Map<string, string>, ?taxBehavior: Create'ShippingCostShippingRateDataTaxBehavior, ?taxCode: string, ?type': Create'ShippingCostShippingRateDataType) =
            {
                DeliveryEstimate = deliveryEstimate
                DisplayName = displayName
                FixedAmount = fixedAmount
                Metadata = metadata
                TaxBehavior = taxBehavior
                TaxCode = taxCode
                Type = type'
            }

    type Create'ShippingCost =
        {
            /// The ID of the shipping rate to use for this order.
            [<Config.Form>]
            ShippingRate: string option
            /// Parameters to create a new ad-hoc shipping rate for this order.
            [<Config.Form>]
            ShippingRateData: Create'ShippingCostShippingRateData option
        }

    type Create'ShippingCost with
        static member New(?shippingRate: string, ?shippingRateData: Create'ShippingCostShippingRateData) =
            {
                ShippingRate = shippingRate
                ShippingRateData = shippingRateData
            }

    type Create'ShippingDetailsAddress =
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

    type Create'ShippingDetailsAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'ShippingDetails =
        {
            /// Shipping address
            [<Config.Form>]
            Address: Create'ShippingDetailsAddress option
            /// Recipient name.
            [<Config.Form>]
            Name: string option
            /// Recipient phone (including extension)
            [<Config.Form>]
            Phone: Choice<string,string> option
        }

    type Create'ShippingDetails with
        static member New(?address: Create'ShippingDetailsAddress, ?name: string, ?phone: Choice<string,string>) =
            {
                Address = address
                Name = name
                Phone = phone
            }

    type Create'TransferData =
        {
            /// The amount that will be transferred automatically when the invoice is paid. If no amount is set, the full amount is transferred.
            [<Config.Form>]
            Amount: int option
            /// ID of an existing, connected Stripe account.
            [<Config.Form>]
            Destination: string option
        }

    type Create'TransferData with
        static member New(?amount: int, ?destination: string) =
            {
                Amount = amount
                Destination = destination
            }

    type CreateOptions =
        {
            /// The account tax IDs associated with the invoice. Only editable when the invoice is a draft.
            [<Config.Form>]
            AccountTaxIds: Choice<string list,string> option
            /// A fee in cents (or local equivalent) that will be applied to the invoice and transferred to the application owner's Stripe account. The request must be made with an OAuth key or the Stripe-Account header in order to take an application fee. For more information, see the application fees [documentation](https://docs.stripe.com/billing/invoices/connect#collecting-fees).
            [<Config.Form>]
            ApplicationFeeAmount: int option
            /// Controls whether Stripe performs [automatic collection](https://docs.stripe.com/invoicing/integration/automatic-advancement-collection) of the invoice. If `false`, the invoice's state doesn't automatically advance without an explicit action. Defaults to false.
            [<Config.Form>]
            AutoAdvance: bool option
            /// Settings for automatic tax lookup for this invoice.
            [<Config.Form>]
            AutomaticTax: Create'AutomaticTax option
            /// The time when this invoice should be scheduled to finalize (up to 5 years in the future). The invoice is finalized at this time if it's still in draft state.
            [<Config.Form>]
            AutomaticallyFinalizesAt: DateTime option
            /// Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay this invoice using the default source attached to the customer. When sending an invoice, Stripe will email this invoice to the customer with payment instructions. Defaults to `charge_automatically`.
            [<Config.Form>]
            CollectionMethod: Create'CollectionMethod option
            /// The currency to create this invoice in. Defaults to that of `customer` if not specified.
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// A list of up to 4 custom fields to be displayed on the invoice.
            [<Config.Form>]
            CustomFields: Choice<Create'CustomFields list,string> option
            /// The ID of the customer to bill.
            [<Config.Form>]
            Customer: string option
            /// The ID of the account to bill.
            [<Config.Form>]
            CustomerAccount: string option
            /// The number of days from when the invoice is created until it is due. Valid only for invoices where `collection_method=send_invoice`.
            [<Config.Form>]
            DaysUntilDue: int option
            /// ID of the default payment method for the invoice. It must belong to the customer associated with the invoice. If not set, defaults to the subscription's default payment method, if any, or to the default payment method in the customer's invoice settings.
            [<Config.Form>]
            DefaultPaymentMethod: string option
            /// ID of the default payment source for the invoice. It must belong to the customer associated with the invoice and be in a chargeable state. If not set, defaults to the subscription's default source, if any, or to the customer's default source.
            [<Config.Form>]
            DefaultSource: string option
            /// The tax rates that will apply to any line item that does not have `tax_rates` set.
            [<Config.Form>]
            DefaultTaxRates: string list option
            /// An arbitrary string attached to the object. Often useful for displaying to users. Referenced as 'memo' in the Dashboard.
            [<Config.Form>]
            Description: string option
            /// The coupons and promotion codes to redeem into discounts for the invoice. If not specified, inherits the discount from the invoice's customer. Pass an empty string to avoid inheriting any discounts.
            [<Config.Form>]
            Discounts: Choice<Create'Discounts list,string> option
            /// The date on which payment for this invoice is due. Valid only for invoices where `collection_method=send_invoice`.
            [<Config.Form>]
            DueDate: DateTime option
            /// The date when this invoice is in effect. Same as `finalized_at` unless overwritten. When defined, this value replaces the system-generated 'Date of issue' printed on the invoice PDF and receipt.
            [<Config.Form>]
            EffectiveAt: DateTime option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Footer to be displayed on the invoice.
            [<Config.Form>]
            Footer: string option
            /// Revise an existing invoice. The new invoice will be created in `status=draft`. See the [revision documentation](https://docs.stripe.com/invoicing/invoice-revisions) for more details.
            [<Config.Form>]
            FromInvoice: Create'FromInvoice option
            /// The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.
            [<Config.Form>]
            Issuer: Create'Issuer option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Set the number for this invoice. If no number is present then a number will be assigned automatically when the invoice is finalized. In many markets, regulations require invoices to be unique, sequential and / or gapless. You are responsible for ensuring this is true across all your different invoicing systems in the event that you edit the invoice number using our API. If you use only Stripe for your invoices and do not change invoice numbers, Stripe handles this aspect of compliance for you automatically.
            [<Config.Form>]
            Number: string option
            /// The account (if any) for which the funds of the invoice payment are intended. If set, the invoice will be presented with the branding and support information of the specified account. See the [Invoices with Connect](https://docs.stripe.com/billing/invoices/connect) documentation for details.
            [<Config.Form>]
            OnBehalfOf: string option
            /// Configuration settings for the PaymentIntent that is generated when the invoice is finalized.
            [<Config.Form>]
            PaymentSettings: Create'PaymentSettings option
            /// How to handle pending invoice items on invoice creation. Defaults to `exclude` if the parameter is omitted.
            [<Config.Form>]
            PendingInvoiceItemsBehavior: Create'PendingInvoiceItemsBehavior option
            /// The rendering-related settings that control how the invoice is displayed on customer-facing surfaces such as PDF and Hosted Invoice Page.
            [<Config.Form>]
            Rendering: Create'Rendering option
            /// Settings for the cost of shipping for this invoice.
            [<Config.Form>]
            ShippingCost: Create'ShippingCost option
            /// Shipping details for the invoice. The Invoice PDF will use the `shipping_details` value if it is set, otherwise the PDF will render the shipping address from the customer.
            [<Config.Form>]
            ShippingDetails: Create'ShippingDetails option
            /// Extra information about a charge for the customer's credit card statement. It must contain at least one letter. If not specified and this invoice is part of a subscription, the default `statement_descriptor` will be set to the first subscription item's product's `statement_descriptor`.
            [<Config.Form>]
            StatementDescriptor: string option
            /// The ID of the subscription to invoice, if any. If set, the created invoice will only include pending invoice items for that subscription. The subscription's billing cycle and regular subscription events won't be affected.
            [<Config.Form>]
            Subscription: string option
            /// If specified, the funds from the invoice will be transferred to the destination and the ID of the resulting transfer will be found on the invoice's charge.
            [<Config.Form>]
            TransferData: Create'TransferData option
        }

    type CreateOptions with
        static member New(?accountTaxIds: Choice<string list,string>, ?applicationFeeAmount: int, ?autoAdvance: bool, ?automaticTax: Create'AutomaticTax, ?automaticallyFinalizesAt: DateTime, ?collectionMethod: Create'CollectionMethod, ?currency: IsoTypes.IsoCurrencyCode, ?customFields: Choice<Create'CustomFields list,string>, ?customer: string, ?customerAccount: string, ?daysUntilDue: int, ?defaultPaymentMethod: string, ?defaultSource: string, ?defaultTaxRates: string list, ?description: string, ?discounts: Choice<Create'Discounts list,string>, ?dueDate: DateTime, ?effectiveAt: DateTime, ?expand: string list, ?footer: string, ?fromInvoice: Create'FromInvoice, ?issuer: Create'Issuer, ?metadata: Map<string, string>, ?number: string, ?onBehalfOf: string, ?paymentSettings: Create'PaymentSettings, ?pendingInvoiceItemsBehavior: Create'PendingInvoiceItemsBehavior, ?rendering: Create'Rendering, ?shippingCost: Create'ShippingCost, ?shippingDetails: Create'ShippingDetails, ?statementDescriptor: string, ?subscription: string, ?transferData: Create'TransferData) =
            {
                AccountTaxIds = accountTaxIds
                ApplicationFeeAmount = applicationFeeAmount
                AutoAdvance = autoAdvance
                AutomaticTax = automaticTax
                AutomaticallyFinalizesAt = automaticallyFinalizesAt
                CollectionMethod = collectionMethod
                Currency = currency
                CustomFields = customFields
                Customer = customer
                CustomerAccount = customerAccount
                DaysUntilDue = daysUntilDue
                DefaultPaymentMethod = defaultPaymentMethod
                DefaultSource = defaultSource
                DefaultTaxRates = defaultTaxRates
                Description = description
                Discounts = discounts
                DueDate = dueDate
                EffectiveAt = effectiveAt
                Expand = expand
                Footer = footer
                FromInvoice = fromInvoice
                Issuer = issuer
                Metadata = metadata
                Number = number
                OnBehalfOf = onBehalfOf
                PaymentSettings = paymentSettings
                PendingInvoiceItemsBehavior = pendingInvoiceItemsBehavior
                Rendering = rendering
                ShippingCost = shippingCost
                ShippingDetails = shippingDetails
                StatementDescriptor = statementDescriptor
                Subscription = subscription
                TransferData = transferData
            }

    type DeleteOptions =
        { [<Config.Path>]
          Invoice: string }

    type DeleteOptions with
        static member New(invoice: string) =
            {
                Invoice = invoice
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Invoice: string
        }

    type RetrieveOptions with
        static member New(invoice: string, ?expand: string list) =
            {
                Invoice = invoice
                Expand = expand
            }

    type Update'AutomaticTaxLiabilityType =
        | Account
        | Self

    type Update'AutomaticTaxLiability =
        {
            /// The connected account being referenced when `type` is `account`.
            [<Config.Form>]
            Account: string option
            /// Type of the account referenced in the request.
            [<Config.Form>]
            Type: Update'AutomaticTaxLiabilityType option
        }

    type Update'AutomaticTaxLiability with
        static member New(?account: string, ?type': Update'AutomaticTaxLiabilityType) =
            {
                Account = account
                Type = type'
            }

    type Update'AutomaticTax =
        {
            /// Whether Stripe automatically computes tax on this invoice. Note that incompatible invoice items (invoice items with manually specified [tax rates](https://docs.stripe.com/api/tax_rates), negative amounts, or `tax_behavior=unspecified`) cannot be added to automatic tax invoices.
            [<Config.Form>]
            Enabled: bool option
            /// The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.
            [<Config.Form>]
            Liability: Update'AutomaticTaxLiability option
        }

    type Update'AutomaticTax with
        static member New(?enabled: bool, ?liability: Update'AutomaticTaxLiability) =
            {
                Enabled = enabled
                Liability = liability
            }

    type Update'CollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    type Update'CustomFields =
        {
            /// The name of the custom field. This may be up to 40 characters.
            [<Config.Form>]
            Name: string option
            /// The value of the custom field. This may be up to 140 characters.
            [<Config.Form>]
            Value: string option
        }

    type Update'CustomFields with
        static member New(?name: string, ?value: string) =
            {
                Name = name
                Value = value
            }

    type Update'Discounts =
        {
            /// ID of the coupon to create a new discount for.
            [<Config.Form>]
            Coupon: string option
            /// ID of an existing discount on the object (or one of its ancestors) to reuse.
            [<Config.Form>]
            Discount: string option
            /// ID of the promotion code to create a new discount for.
            [<Config.Form>]
            PromotionCode: string option
        }

    type Update'Discounts with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Update'IssuerType =
        | Account
        | Self

    type Update'Issuer =
        {
            /// The connected account being referenced when `type` is `account`.
            [<Config.Form>]
            Account: string option
            /// Type of the account referenced in the request.
            [<Config.Form>]
            Type: Update'IssuerType option
        }

    type Update'Issuer with
        static member New(?account: string, ?type': Update'IssuerType) =
            {
                Account = account
                Type = type'
            }

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType =
        | Business
        | Personal

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions =
        {
            /// Transaction type of the mandate.
            [<Config.Form>]
            TransactionType:
                Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType option
        }

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions with
        static member New(?transactionType: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType) =
            {
                TransactionType = transactionType
            }

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod =
        | Automatic
        | Instant
        | Microdeposits

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions =
        {
            /// Additional fields for Mandate creation
            [<Config.Form>]
            MandateOptions:
                Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions option
            /// Verification method for the intent
            [<Config.Form>]
            VerificationMethod:
                Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod option
        }

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions with
        static member New(?mandateOptions: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions, ?verificationMethod: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod) =
            {
                MandateOptions = mandateOptions
                VerificationMethod = verificationMethod
            }

    type Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage =
        | De
        | En
        | Fr
        | Nl

    type Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions =
        {
            /// Preferred language of the Bancontact authorization page that the customer is redirected to.
            [<Config.Form>]
            PreferredLanguage:
                Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage option
        }

    type Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions with
        static member New(?preferredLanguage: Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage) =
            {
                PreferredLanguage = preferredLanguage
            }

    type Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanInterval =
        | Month

    type Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanType =
        | Bonus
        | FixedCount
        | Revolving

    type Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlan =
        {
            /// For `fixed_count` installment plans, this is required. It represents the number of installment payments your customer will make to their credit card.
            [<Config.Form>]
            Count: int option
            /// For `fixed_count` installment plans, this is required. It represents the interval between installment payments your customer will make to their credit card.
            /// One of `month`.
            [<Config.Form>]
            Interval:
                Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanInterval option
            /// Type of installment plan, one of `fixed_count`, `bonus`, or `revolving`.
            [<Config.Form>]
            Type:
                Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanType option
        }

    type Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlan with
        static member New(?count: int, ?interval: Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanInterval, ?type': Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanType) =
            {
                Count = count
                Interval = interval
                Type = type'
            }

    type Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallments =
        {
            /// Setting to true enables installments for this invoice.
            /// Setting to false will prevent any selected plan from applying to a payment.
            [<Config.Form>]
            Enabled: bool option
            /// The selected installment plan to use for this invoice.
            [<Config.Form>]
            Plan:
                Choice<Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlan,string> option
        }

    type Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallments with
        static member New(?enabled: bool, ?plan: Choice<Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlan,string>) =
            {
                Enabled = enabled
                Plan = plan
            }

    type Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsRequestThreeDSecure =
        | Any
        | Automatic
        | Challenge

    type Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptions =
        {
            /// Installment configuration for payments attempted on this invoice.
            /// For more information, see the [installments integration guide](https://docs.stripe.com/payments/installments).
            [<Config.Form>]
            Installments: Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallments option
            /// We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://docs.stripe.com/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Read our guide on [manually requesting 3D Secure](https://docs.stripe.com/payments/3d-secure/authentication-flow#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
            [<Config.Form>]
            RequestThreeDSecure:
                Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsRequestThreeDSecure option
        }

    type Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptions with
        static member New(?installments: Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallments, ?requestThreeDSecure: Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsRequestThreeDSecure) =
            {
                Installments = installments
                RequestThreeDSecure = requestThreeDSecure
            }

    type Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer =
        {
            /// The desired country code of the bank account information. Permitted values include: `DE`, `FR`, `IE`, or `NL`.
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
        }

    type Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer with
        static member New(?country: IsoTypes.IsoCountryCode) =
            {
                Country = country
            }

    type Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer =
        {
            /// Configuration for eu_bank_transfer funding type.
            [<Config.Form>]
            EuBankTransfer:
                Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer option
            /// The bank transfer type that can be used for funding. Permitted values include: `eu_bank_transfer`, `gb_bank_transfer`, `jp_bank_transfer`, `mx_bank_transfer`, or `us_bank_transfer`.
            [<Config.Form>]
            Type: string option
        }

    type Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer with
        static member New(?euBankTransfer: Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer, ?type': string) =
            {
                EuBankTransfer = euBankTransfer
                Type = type'
            }

    type Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions =
        {
            /// Configuration for the bank transfer funding type, if the `funding_type` is set to `bank_transfer`.
            [<Config.Form>]
            BankTransfer:
                Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer option
            /// The funding method type to be used when there are not enough funds in the customer balance. Permitted values include: `bank_transfer`.
            [<Config.Form>]
            FundingType: string option
        }

    type Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions with
        static member New(?bankTransfer: Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer, ?fundingType: string) =
            {
                BankTransfer = bankTransfer
                FundingType = fundingType
            }

    type Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose =
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

    type Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions =
        {
            /// The maximum amount that can be collected in a single invoice. If you don't specify a maximum, then there is no limit.
            [<Config.Form>]
            Amount: int option
            /// The purpose for which payments are made. Has a default value based on your merchant category code.
            [<Config.Form>]
            Purpose: Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose option
        }

    type Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions with
        static member New(?amount: int, ?purpose: Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose) =
            {
                Amount = amount
                Purpose = purpose
            }

    type Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions =
        {
            /// Additional fields for Mandate creation.
            [<Config.Form>]
            MandateOptions: Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions option
        }

    type Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions with
        static member New(?mandateOptions: Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Update'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptionsAmountIncludesIof =
        | Always
        | Never

    type Update'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptions =
        {
            /// Determines if the amount includes the IOF tax. Defaults to `never`.
            [<Config.Form>]
            AmountIncludesIof:
                Update'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptionsAmountIncludesIof option
            /// The number of seconds (between 10 and 1209600) after which Pix payment will expire. Defaults to 86400 seconds.
            [<Config.Form>]
            ExpiresAfterSeconds: int option
        }

    type Update'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptions with
        static member New(?amountIncludesIof: Update'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptionsAmountIncludesIof, ?expiresAfterSeconds: int) =
            {
                AmountIncludesIof = amountIncludesIof
                ExpiresAfterSeconds = expiresAfterSeconds
            }

    type Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType =
        | Fixed
        | Maximum

    type Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions =
        {
            /// Amount to be charged for future payments.
            [<Config.Form>]
            Amount: int option
            /// One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
            [<Config.Form>]
            AmountType:
                Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType option
            /// A description of the mandate or subscription that is meant to be displayed to the customer.
            [<Config.Form>]
            Description: string option
            /// End date of the mandate or subscription.
            [<Config.Form>]
            EndDate: DateTime option
        }

    type Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions with
        static member New(?amount: int, ?amountType: Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType, ?description: string, ?endDate: DateTime) =
            {
                Amount = amount
                AmountType = amountType
                Description = description
                EndDate = endDate
            }

    type Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions =
        {
            /// Configuration options for setting up an eMandate
            [<Config.Form>]
            MandateOptions: Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions option
        }

    type Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions with
        static member New(?mandateOptions: Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories
        =
        | Checking
        | Savings

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters =
        {
            /// The account subcategories to use to filter for selectable accounts. Valid subcategories are `checking` and `savings`.
            [<Config.Form>]
            AccountSubcategories:
                Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories list option
        }

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters with
        static member New(?accountSubcategories: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories list) =
            {
                AccountSubcategories = accountSubcategories
            }

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions =
        | Balances
        | Ownership
        | PaymentMethod
        | Transactions

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch =
        | Balances
        | Ownership
        | Transactions

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections =
        {
            /// Provide filters for the linked accounts that the customer can select for the payment method.
            [<Config.Form>]
            Filters:
                Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters option
            /// The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.
            [<Config.Form>]
            Permissions:
                Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list option
            /// List of data features that you would like to retrieve upon account creation.
            [<Config.Form>]
            Prefetch:
                Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list option
        }

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections with
        static member New(?filters: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters, ?permissions: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list, ?prefetch: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list) =
            {
                Filters = filters
                Permissions = permissions
                Prefetch = prefetch
            }

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod =
        | Automatic
        | Instant
        | Microdeposits

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions =
        {
            /// Additional fields for Financial Connections Session creation
            [<Config.Form>]
            FinancialConnections:
                Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections option
            /// Verification method for the intent
            [<Config.Form>]
            VerificationMethod:
                Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod option
        }

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions with
        static member New(?financialConnections: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections, ?verificationMethod: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod) =
            {
                FinancialConnections = financialConnections
                VerificationMethod = verificationMethod
            }

    type Update'PaymentSettingsPaymentMethodOptions =
        {
            /// If paying by `acss_debit`, this sub-hash contains details about the Canadian pre-authorized debit payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            AcssDebit: Choice<Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string> option
            /// If paying by `bancontact`, this sub-hash contains details about the Bancontact payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Bancontact:
                Choice<Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string> option
            /// If paying by `card`, this sub-hash contains details about the Card payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Card: Choice<Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptions,string> option
            /// If paying by `customer_balance`, this sub-hash contains details about the Bank transfer payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            CustomerBalance:
                Choice<Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string> option
            /// If paying by `konbini`, this sub-hash contains details about the Konbini payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Konbini: Choice<string,string> option
            /// If paying by `payto`, this sub-hash contains details about the PayTo payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Payto: Choice<Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions,string> option
            /// If paying by `pix`, this sub-hash contains details about the Pix payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Pix: Choice<Update'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptions,string> option
            /// If paying by `sepa_debit`, this sub-hash contains details about the SEPA Direct Debit payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            SepaDebit: Choice<string,string> option
            /// If paying by `upi`, this sub-hash contains details about the UPI payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            Upi: Choice<Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions,string> option
            /// If paying by `us_bank_account`, this sub-hash contains details about the ACH direct debit payment method options to pass to the invoice’s PaymentIntent.
            [<Config.Form>]
            UsBankAccount:
                Choice<Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string> option
        }

    type Update'PaymentSettingsPaymentMethodOptions with
        static member New(?acssDebit: Choice<Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string>, ?bancontact: Choice<Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string>, ?card: Choice<Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptions,string>, ?customerBalance: Choice<Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string>, ?konbini: Choice<string,string>, ?payto: Choice<Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions,string>, ?pix: Choice<Update'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptions,string>, ?sepaDebit: Choice<string,string>, ?upi: Choice<Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions,string>, ?usBankAccount: Choice<Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string>) =
            {
                AcssDebit = acssDebit
                Bancontact = bancontact
                Card = card
                CustomerBalance = customerBalance
                Konbini = konbini
                Payto = payto
                Pix = pix
                SepaDebit = sepaDebit
                Upi = upi
                UsBankAccount = usBankAccount
            }

    type Update'PaymentSettingsPaymentMethodTypes =
        | AchCreditTransfer
        | AchDebit
        | AcssDebit
        | Affirm
        | AmazonPay
        | AuBecsDebit
        | BacsDebit
        | Bancontact
        | Boleto
        | Card
        | Cashapp
        | Crypto
        | Custom
        | CustomerBalance
        | Eps
        | Fpx
        | Giropay
        | Grabpay
        | Ideal
        | JpCreditTransfer
        | KakaoPay
        | Klarna
        | Konbini
        | KrCard
        | Link
        | Multibanco
        | NaverPay
        | NzBankAccount
        | P24
        | PayByBank
        | Payco
        | Paynow
        | Paypal
        | Payto
        | Pix
        | Promptpay
        | RevolutPay
        | SepaCreditTransfer
        | SepaDebit
        | Sofort
        | Swish
        | Upi
        | UsBankAccount
        | WechatPay

    type Update'PaymentSettings =
        {
            /// ID of the mandate to be used for this invoice. It must correspond to the payment method used to pay the invoice, including the invoice's default_payment_method or default_source, if set.
            [<Config.Form>]
            DefaultMandate: Choice<string,string> option
            /// Payment-method-specific configuration to provide to the invoice’s PaymentIntent.
            [<Config.Form>]
            PaymentMethodOptions: Update'PaymentSettingsPaymentMethodOptions option
            /// The list of payment method types (e.g. card) to provide to the invoice’s PaymentIntent. If not set, Stripe attempts to automatically determine the types to use by looking at the invoice’s default payment method, the subscription’s default payment method, the customer’s default payment method, and your [invoice template settings](https://dashboard.stripe.com/settings/billing/invoice).
            [<Config.Form>]
            PaymentMethodTypes: Choice<Update'PaymentSettingsPaymentMethodTypes list,string> option
        }

    type Update'PaymentSettings with
        static member New(?defaultMandate: Choice<string,string>, ?paymentMethodOptions: Update'PaymentSettingsPaymentMethodOptions, ?paymentMethodTypes: Choice<Update'PaymentSettingsPaymentMethodTypes list,string>) =
            {
                DefaultMandate = defaultMandate
                PaymentMethodOptions = paymentMethodOptions
                PaymentMethodTypes = paymentMethodTypes
            }

    type Update'RenderingAmountTaxDisplay =
        | ExcludeTax
        | IncludeInclusiveTax

    type Update'RenderingPdfPageSize =
        | A4
        | Auto
        | Letter

    type Update'RenderingPdf =
        {
            /// Page size for invoice PDF. Can be set to `a4`, `letter`, or `auto`.
            /// If set to `auto`, invoice PDF page size defaults to `a4` for customers with
            /// Japanese locale and `letter` for customers with other locales.
            [<Config.Form>]
            PageSize: Update'RenderingPdfPageSize option
        }

    type Update'RenderingPdf with
        static member New(?pageSize: Update'RenderingPdfPageSize) =
            {
                PageSize = pageSize
            }

    type Update'Rendering =
        {
            /// How line-item prices and amounts will be displayed with respect to tax on invoice PDFs. One of `exclude_tax` or `include_inclusive_tax`. `include_inclusive_tax` will include inclusive tax (and exclude exclusive tax) in invoice PDF amounts. `exclude_tax` will exclude all tax (inclusive and exclusive alike) from invoice PDF amounts.
            [<Config.Form>]
            AmountTaxDisplay: Update'RenderingAmountTaxDisplay option
            /// Invoice pdf rendering options
            [<Config.Form>]
            Pdf: Update'RenderingPdf option
            /// ID of the invoice rendering template to use for this invoice.
            [<Config.Form>]
            Template: string option
            /// The specific version of invoice rendering template to use for this invoice.
            [<Config.Form>]
            TemplateVersion: Choice<int,string> option
        }

    type Update'Rendering with
        static member New(?amountTaxDisplay: Update'RenderingAmountTaxDisplay, ?pdf: Update'RenderingPdf, ?template: string, ?templateVersion: Choice<int,string>) =
            {
                AmountTaxDisplay = amountTaxDisplay
                Pdf = pdf
                Template = template
                TemplateVersion = templateVersion
            }

    type Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMaximumUnit =
        | BusinessDay
        | Day
        | Hour
        | Month
        | Week

    type Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMaximum =
        {
            /// A unit of time.
            [<Config.Form>]
            Unit: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMaximumUnit option
            /// Must be greater than 0.
            [<Config.Form>]
            Value: int option
        }

    type Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMaximum with
        static member New(?unit: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMaximumUnit, ?value: int) =
            {
                Unit = unit
                Value = value
            }

    type Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMinimumUnit =
        | BusinessDay
        | Day
        | Hour
        | Month
        | Week

    type Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMinimum =
        {
            /// A unit of time.
            [<Config.Form>]
            Unit: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMinimumUnit option
            /// Must be greater than 0.
            [<Config.Form>]
            Value: int option
        }

    type Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMinimum with
        static member New(?unit: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMinimumUnit, ?value: int) =
            {
                Unit = unit
                Value = value
            }

    type Update'ShippingCostShippingCostShippingRateDataDeliveryEstimate =
        {
            /// The upper bound of the estimated range. If empty, represents no upper bound i.e., infinite.
            [<Config.Form>]
            Maximum: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMaximum option
            /// The lower bound of the estimated range. If empty, represents no lower bound.
            [<Config.Form>]
            Minimum: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMinimum option
        }

    type Update'ShippingCostShippingCostShippingRateDataDeliveryEstimate with
        static member New(?maximum: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMaximum, ?minimum: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMinimum) =
            {
                Maximum = maximum
                Minimum = minimum
            }

    type Update'ShippingCostShippingCostShippingRateDataFixedAmount =
        {
            /// A non-negative integer in cents representing how much to charge.
            [<Config.Form>]
            Amount: int option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// Shipping rates defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            CurrencyOptions: Map<string, string> option
        }

    type Update'ShippingCostShippingCostShippingRateDataFixedAmount with
        static member New(?amount: int, ?currency: IsoTypes.IsoCurrencyCode, ?currencyOptions: Map<string, string>) =
            {
                Amount = amount
                Currency = currency
                CurrencyOptions = currencyOptions
            }

    type Update'ShippingCostShippingCostShippingRateDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type Update'ShippingCostShippingCostShippingRateDataType = | FixedAmount

    type Update'ShippingCostShippingCostShippingRateData =
        {
            /// The estimated range for how long shipping will take, meant to be displayable to the customer. This will appear on CheckoutSessions.
            [<Config.Form>]
            DeliveryEstimate: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimate option
            /// The name of the shipping rate, meant to be displayable to the customer. This will appear on CheckoutSessions.
            [<Config.Form>]
            DisplayName: string option
            /// Describes a fixed amount to charge for shipping. Must be present if type is `fixed_amount`.
            [<Config.Form>]
            FixedAmount: Update'ShippingCostShippingCostShippingRateDataFixedAmount option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Specifies whether the rate is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`.
            [<Config.Form>]
            TaxBehavior: Update'ShippingCostShippingCostShippingRateDataTaxBehavior option
            /// A [tax code](https://docs.stripe.com/tax/tax-categories) ID. The Shipping tax code is `txcd_92010001`.
            [<Config.Form>]
            TaxCode: string option
            /// The type of calculation to use on the shipping rate.
            [<Config.Form>]
            Type: Update'ShippingCostShippingCostShippingRateDataType option
        }

    type Update'ShippingCostShippingCostShippingRateData with
        static member New(?deliveryEstimate: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimate, ?displayName: string, ?fixedAmount: Update'ShippingCostShippingCostShippingRateDataFixedAmount, ?metadata: Map<string, string>, ?taxBehavior: Update'ShippingCostShippingCostShippingRateDataTaxBehavior, ?taxCode: string, ?type': Update'ShippingCostShippingCostShippingRateDataType) =
            {
                DeliveryEstimate = deliveryEstimate
                DisplayName = displayName
                FixedAmount = fixedAmount
                Metadata = metadata
                TaxBehavior = taxBehavior
                TaxCode = taxCode
                Type = type'
            }

    type Update'ShippingCostShippingCost =
        {
            /// The ID of the shipping rate to use for this order.
            [<Config.Form>]
            ShippingRate: string option
            /// Parameters to create a new ad-hoc shipping rate for this order.
            [<Config.Form>]
            ShippingRateData: Update'ShippingCostShippingCostShippingRateData option
        }

    type Update'ShippingCostShippingCost with
        static member New(?shippingRate: string, ?shippingRateData: Update'ShippingCostShippingCostShippingRateData) =
            {
                ShippingRate = shippingRate
                ShippingRateData = shippingRateData
            }

    type Update'ShippingDetailsRecipientShippingWithOptionalFieldsAddressAddress =
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

    type Update'ShippingDetailsRecipientShippingWithOptionalFieldsAddressAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'ShippingDetailsRecipientShippingWithOptionalFieldsAddress =
        {
            /// Shipping address
            [<Config.Form>]
            Address: Update'ShippingDetailsRecipientShippingWithOptionalFieldsAddressAddress option
            /// Recipient name.
            [<Config.Form>]
            Name: string option
            /// Recipient phone (including extension)
            [<Config.Form>]
            Phone: Choice<string,string> option
        }

    type Update'ShippingDetailsRecipientShippingWithOptionalFieldsAddress with
        static member New(?address: Update'ShippingDetailsRecipientShippingWithOptionalFieldsAddressAddress, ?name: string, ?phone: Choice<string,string>) =
            {
                Address = address
                Name = name
                Phone = phone
            }

    type Update'TransferDataTransferDataSpecs =
        {
            /// The amount that will be transferred automatically when the invoice is paid. If no amount is set, the full amount is transferred.
            [<Config.Form>]
            Amount: int option
            /// ID of an existing, connected Stripe account.
            [<Config.Form>]
            Destination: string option
        }

    type Update'TransferDataTransferDataSpecs with
        static member New(?amount: int, ?destination: string) =
            {
                Amount = amount
                Destination = destination
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Invoice: string
            /// The account tax IDs associated with the invoice. Only editable when the invoice is a draft.
            [<Config.Form>]
            AccountTaxIds: Choice<string list,string> option
            /// A fee in cents (or local equivalent) that will be applied to the invoice and transferred to the application owner's Stripe account. The request must be made with an OAuth key or the Stripe-Account header in order to take an application fee. For more information, see the application fees [documentation](https://docs.stripe.com/billing/invoices/connect#collecting-fees).
            [<Config.Form>]
            ApplicationFeeAmount: int option
            /// Controls whether Stripe performs [automatic collection](https://docs.stripe.com/invoicing/integration/automatic-advancement-collection) of the invoice.
            [<Config.Form>]
            AutoAdvance: bool option
            /// Settings for automatic tax lookup for this invoice.
            [<Config.Form>]
            AutomaticTax: Update'AutomaticTax option
            /// The time when this invoice should be scheduled to finalize (up to 5 years in the future). The invoice is finalized at this time if it's still in draft state. To turn off automatic finalization, set `auto_advance` to false.
            [<Config.Form>]
            AutomaticallyFinalizesAt: DateTime option
            /// Either `charge_automatically` or `send_invoice`. This field can be updated only on `draft` invoices.
            [<Config.Form>]
            CollectionMethod: Update'CollectionMethod option
            /// A list of up to 4 custom fields to be displayed on the invoice. If a value for `custom_fields` is specified, the list specified will replace the existing custom field list on this invoice. Pass an empty string to remove previously-defined fields.
            [<Config.Form>]
            CustomFields: Choice<Update'CustomFields list,string> option
            /// The number of days from which the invoice is created until it is due. Only valid for invoices where `collection_method=send_invoice`. This field can only be updated on `draft` invoices.
            [<Config.Form>]
            DaysUntilDue: int option
            /// ID of the default payment method for the invoice. It must belong to the customer associated with the invoice. If not set, defaults to the subscription's default payment method, if any, or to the default payment method in the customer's invoice settings.
            [<Config.Form>]
            DefaultPaymentMethod: string option
            /// ID of the default payment source for the invoice. It must belong to the customer associated with the invoice and be in a chargeable state. If not set, defaults to the subscription's default source, if any, or to the customer's default source.
            [<Config.Form>]
            DefaultSource: Choice<string,string> option
            /// The tax rates that will apply to any line item that does not have `tax_rates` set. Pass an empty string to remove previously-defined tax rates.
            [<Config.Form>]
            DefaultTaxRates: Choice<string list,string> option
            /// An arbitrary string attached to the object. Often useful for displaying to users. Referenced as 'memo' in the Dashboard.
            [<Config.Form>]
            Description: string option
            /// The discounts that will apply to the invoice. Pass an empty string to remove previously-defined discounts.
            [<Config.Form>]
            Discounts: Choice<Update'Discounts list,string> option
            /// The date on which payment for this invoice is due. Only valid for invoices where `collection_method=send_invoice`. This field can only be updated on `draft` invoices.
            [<Config.Form>]
            DueDate: DateTime option
            /// The date when this invoice is in effect. Same as `finalized_at` unless overwritten. When defined, this value replaces the system-generated 'Date of issue' printed on the invoice PDF and receipt.
            [<Config.Form>]
            EffectiveAt: Choice<DateTime,string> option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Footer to be displayed on the invoice.
            [<Config.Form>]
            Footer: string option
            /// The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.
            [<Config.Form>]
            Issuer: Update'Issuer option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Set the number for this invoice. If no number is present then a number will be assigned automatically when the invoice is finalized. In many markets, regulations require invoices to be unique, sequential and / or gapless. You are responsible for ensuring this is true across all your different invoicing systems in the event that you edit the invoice number using our API. If you use only Stripe for your invoices and do not change invoice numbers, Stripe handles this aspect of compliance for you automatically.
            [<Config.Form>]
            Number: Choice<string,string> option
            /// The account (if any) for which the funds of the invoice payment are intended. If set, the invoice will be presented with the branding and support information of the specified account. See the [Invoices with Connect](https://docs.stripe.com/billing/invoices/connect) documentation for details.
            [<Config.Form>]
            OnBehalfOf: Choice<string,string> option
            /// Configuration settings for the PaymentIntent that is generated when the invoice is finalized.
            [<Config.Form>]
            PaymentSettings: Update'PaymentSettings option
            /// The rendering-related settings that control how the invoice is displayed on customer-facing surfaces such as PDF and Hosted Invoice Page.
            [<Config.Form>]
            Rendering: Update'Rendering option
            /// Settings for the cost of shipping for this invoice.
            [<Config.Form>]
            ShippingCost: Choice<Update'ShippingCostShippingCost,string> option
            /// Shipping details for the invoice. The Invoice PDF will use the `shipping_details` value if it is set, otherwise the PDF will render the shipping address from the customer.
            [<Config.Form>]
            ShippingDetails: Choice<Update'ShippingDetailsRecipientShippingWithOptionalFieldsAddress,string> option
            /// Extra information about a charge for the customer's credit card statement. It must contain at least one letter. If not specified and this invoice is part of a subscription, the default `statement_descriptor` will be set to the first subscription item's product's `statement_descriptor`.
            [<Config.Form>]
            StatementDescriptor: string option
            /// If specified, the funds from the invoice will be transferred to the destination and the ID of the resulting transfer will be found on the invoice's charge. This will be unset if you POST an empty value.
            [<Config.Form>]
            TransferData: Choice<Update'TransferDataTransferDataSpecs,string> option
        }

    type UpdateOptions with
        static member New(invoice: string, ?accountTaxIds: Choice<string list,string>, ?applicationFeeAmount: int, ?autoAdvance: bool, ?automaticTax: Update'AutomaticTax, ?automaticallyFinalizesAt: DateTime, ?collectionMethod: Update'CollectionMethod, ?customFields: Choice<Update'CustomFields list,string>, ?daysUntilDue: int, ?defaultPaymentMethod: string, ?defaultSource: Choice<string,string>, ?defaultTaxRates: Choice<string list,string>, ?description: string, ?discounts: Choice<Update'Discounts list,string>, ?dueDate: DateTime, ?effectiveAt: Choice<DateTime,string>, ?expand: string list, ?footer: string, ?issuer: Update'Issuer, ?metadata: Map<string, string>, ?number: Choice<string,string>, ?onBehalfOf: Choice<string,string>, ?paymentSettings: Update'PaymentSettings, ?rendering: Update'Rendering, ?shippingCost: Choice<Update'ShippingCostShippingCost,string>, ?shippingDetails: Choice<Update'ShippingDetailsRecipientShippingWithOptionalFieldsAddress,string>, ?statementDescriptor: string, ?transferData: Choice<Update'TransferDataTransferDataSpecs,string>) =
            {
                Invoice = invoice
                AccountTaxIds = accountTaxIds
                ApplicationFeeAmount = applicationFeeAmount
                AutoAdvance = autoAdvance
                AutomaticTax = automaticTax
                AutomaticallyFinalizesAt = automaticallyFinalizesAt
                CollectionMethod = collectionMethod
                CustomFields = customFields
                DaysUntilDue = daysUntilDue
                DefaultPaymentMethod = defaultPaymentMethod
                DefaultSource = defaultSource
                DefaultTaxRates = defaultTaxRates
                Description = description
                Discounts = discounts
                DueDate = dueDate
                EffectiveAt = effectiveAt
                Expand = expand
                Footer = footer
                Issuer = issuer
                Metadata = metadata
                Number = number
                OnBehalfOf = onBehalfOf
                PaymentSettings = paymentSettings
                Rendering = rendering
                ShippingCost = shippingCost
                ShippingDetails = shippingDetails
                StatementDescriptor = statementDescriptor
                TransferData = transferData
            }

    ///<p>You can list all invoices, or list the invoices for a specific customer. The invoices are returned sorted by creation date, with the most recently created invoices appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("collection_method", options.CollectionMethod |> box); ("created", options.Created |> box); ("customer", options.Customer |> box); ("customer_account", options.CustomerAccount |> box); ("due_date", options.DueDate |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("subscription", options.Subscription |> box)] |> Map.ofList
        $"/v1/invoices"
        |> RestApi.getAsync<StripeList<Invoice>> settings qs

    ///<p>This endpoint creates a draft invoice for a given customer. The invoice remains a draft until you <a href="/api/invoices/finalize">finalize</a> the invoice, which allows you to <a href="/api/invoices/pay">pay</a> or <a href="/api/invoices/send">send</a> the invoice to your customers.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/invoices"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

    ///<p>Permanently deletes a one-off invoice draft. This cannot be undone. Attempts to delete invoices that are no longer in a draft state will fail; once an invoice has been finalized or if an invoice is for a subscription, it must be <a href="/api/invoices/void">voided</a>.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/invoices/{options.Invoice}"
        |> RestApi.deleteAsync<DeletedInvoice> settings (Map.empty)

    ///<p>Retrieves the invoice with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/invoices/{options.Invoice}"
        |> RestApi.getAsync<Invoice> settings qs

    ///<p>Draft invoices are fully editable. Once an invoice is <a href="/docs/billing/invoices/workflow#finalized">finalized</a>,
    ///monetary values, as well as <code>collection_method</code>, become uneditable.</p>
    ///<p>If you would like to stop the Stripe Billing engine from automatically finalizing, reattempting payments on,
    ///sending reminders for, or <a href="/docs/billing/invoices/reconciliation">automatically reconciling</a> invoices, pass
    ///<code>auto_advance=false</code>.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/invoices/{options.Invoice}"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesCreatePreview =

    type CreatePreview'AutomaticTaxLiabilityType =
        | Account
        | Self

    type CreatePreview'AutomaticTaxLiability =
        {
            /// The connected account being referenced when `type` is `account`.
            [<Config.Form>]
            Account: string option
            /// Type of the account referenced in the request.
            [<Config.Form>]
            Type: CreatePreview'AutomaticTaxLiabilityType option
        }

    type CreatePreview'AutomaticTaxLiability with
        static member New(?account: string, ?type': CreatePreview'AutomaticTaxLiabilityType) =
            {
                Account = account
                Type = type'
            }

    type CreatePreview'AutomaticTax =
        {
            /// Whether Stripe automatically computes tax on this invoice. Note that incompatible invoice items (invoice items with manually specified [tax rates](https://docs.stripe.com/api/tax_rates), negative amounts, or `tax_behavior=unspecified`) cannot be added to automatic tax invoices.
            [<Config.Form>]
            Enabled: bool option
            /// The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.
            [<Config.Form>]
            Liability: CreatePreview'AutomaticTaxLiability option
        }

    type CreatePreview'AutomaticTax with
        static member New(?enabled: bool, ?liability: CreatePreview'AutomaticTaxLiability) =
            {
                Enabled = enabled
                Liability = liability
            }

    type CreatePreview'CustomerDetailsAddressOptionalFieldsAddress =
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

    type CreatePreview'CustomerDetailsAddressOptionalFieldsAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type CreatePreview'CustomerDetailsShippingCustomerShippingAddress =
        {
            /// City, district, suburb, town, or village.
            [<Config.Form>]
            City: string option
            /// A freeform text field for the country. However, in order to activate some tax features, the format should be a two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
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

    type CreatePreview'CustomerDetailsShippingCustomerShippingAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type CreatePreview'CustomerDetailsShippingCustomerShipping =
        {
            /// Customer shipping address.
            [<Config.Form>]
            Address: CreatePreview'CustomerDetailsShippingCustomerShippingAddress option
            /// Customer name.
            [<Config.Form>]
            Name: string option
            /// Customer phone (including extension).
            [<Config.Form>]
            Phone: string option
        }

    type CreatePreview'CustomerDetailsShippingCustomerShipping with
        static member New(?address: CreatePreview'CustomerDetailsShippingCustomerShippingAddress, ?name: string, ?phone: string) =
            {
                Address = address
                Name = name
                Phone = phone
            }

    type CreatePreview'CustomerDetailsTax =
        {
            /// A recent IP address of the customer used for tax reporting and tax location inference. Stripe recommends updating the IP address when a new PaymentMethod is attached or the address field on the customer is updated. We recommend against updating this field more frequently since it could result in unexpected tax location/reporting outcomes.
            [<Config.Form>]
            IpAddress: Choice<string,string> option
        }

    type CreatePreview'CustomerDetailsTax with
        static member New(?ipAddress: Choice<string,string>) =
            {
                IpAddress = ipAddress
            }

    type CreatePreview'CustomerDetailsTaxExempt =
        | Exempt
        | [<JsonPropertyName("none")>] None'
        | Reverse

    type CreatePreview'CustomerDetailsTaxIdsType =
        | AdNrt
        | AeTrn
        | AlTin
        | AmTin
        | AoTin
        | ArCuit
        | AuAbn
        | AuArn
        | AwTin
        | AzTin
        | BaTin
        | BbTin
        | BdBin
        | BfIfu
        | BgUic
        | BhVat
        | BjIfu
        | BoTin
        | BrCnpj
        | BrCpf
        | BsTin
        | ByTin
        | CaBn
        | CaGstHst
        | CaPstBc
        | CaPstMb
        | CaPstSk
        | CaQst
        | CdNif
        | ChUid
        | ChVat
        | ClTin
        | CmNiu
        | CnTin
        | CoNit
        | CrTin
        | CvNif
        | DeStn
        | DoRcn
        | EcRuc
        | EgTin
        | EsCif
        | EtTin
        | EuOssVat
        | EuVat
        | FoVat
        | GbVat
        | GeVat
        | GiTin
        | GnNif
        | HkBr
        | HrOib
        | HuTin
        | IdNpwp
        | IlVat
        | InGst
        | IsVat
        | ItCf
        | JpCn
        | JpRn
        | JpTrn
        | KePin
        | KgTin
        | KhTin
        | KrBrn
        | KzBin
        | LaTin
        | LiUid
        | LiVat
        | LkVat
        | MaVat
        | MdVat
        | MePib
        | MkVat
        | MrNif
        | MxRfc
        | MyFrp
        | MyItn
        | MySst
        | NgTin
        | NoVat
        | NoVoec
        | NpPan
        | NzGst
        | OmVat
        | PeRuc
        | PhTin
        | PlNip
        | PyRuc
        | RoTin
        | RsPib
        | RuInn
        | RuKpp
        | SaVat
        | SgGst
        | SgUen
        | SiTin
        | SnNinea
        | SrFin
        | SvNit
        | ThVat
        | TjTin
        | TrTin
        | TwVat
        | TzVat
        | UaVat
        | UgTin
        | UsEin
        | UyRuc
        | UzTin
        | UzVat
        | VeRif
        | VnTin
        | ZaVat
        | ZmTin
        | ZwTin

    type CreatePreview'CustomerDetailsTaxIds =
        {
            /// Type of the tax ID, one of `ad_nrt`, `ae_trn`, `al_tin`, `am_tin`, `ao_tin`, `ar_cuit`, `au_abn`, `au_arn`, `aw_tin`, `az_tin`, `ba_tin`, `bb_tin`, `bd_bin`, `bf_ifu`, `bg_uic`, `bh_vat`, `bj_ifu`, `bo_tin`, `br_cnpj`, `br_cpf`, `bs_tin`, `by_tin`, `ca_bn`, `ca_gst_hst`, `ca_pst_bc`, `ca_pst_mb`, `ca_pst_sk`, `ca_qst`, `cd_nif`, `ch_uid`, `ch_vat`, `cl_tin`, `cm_niu`, `cn_tin`, `co_nit`, `cr_tin`, `cv_nif`, `de_stn`, `do_rcn`, `ec_ruc`, `eg_tin`, `es_cif`, `et_tin`, `eu_oss_vat`, `eu_vat`, `fo_vat`, `gb_vat`, `ge_vat`, `gi_tin`, `gn_nif`, `hk_br`, `hr_oib`, `hu_tin`, `id_npwp`, `il_vat`, `in_gst`, `is_vat`, `it_cf`, `jp_cn`, `jp_rn`, `jp_trn`, `ke_pin`, `kg_tin`, `kh_tin`, `kr_brn`, `kz_bin`, `la_tin`, `li_uid`, `li_vat`, `lk_vat`, `ma_vat`, `md_vat`, `me_pib`, `mk_vat`, `mr_nif`, `mx_rfc`, `my_frp`, `my_itn`, `my_sst`, `ng_tin`, `no_vat`, `no_voec`, `np_pan`, `nz_gst`, `om_vat`, `pe_ruc`, `ph_tin`, `pl_nip`, `py_ruc`, `ro_tin`, `rs_pib`, `ru_inn`, `ru_kpp`, `sa_vat`, `sg_gst`, `sg_uen`, `si_tin`, `sn_ninea`, `sr_fin`, `sv_nit`, `th_vat`, `tj_tin`, `tr_tin`, `tw_vat`, `tz_vat`, `ua_vat`, `ug_tin`, `us_ein`, `uy_ruc`, `uz_tin`, `uz_vat`, `ve_rif`, `vn_tin`, `za_vat`, `zm_tin`, or `zw_tin`
            [<Config.Form>]
            Type: CreatePreview'CustomerDetailsTaxIdsType option
            /// Value of the tax ID.
            [<Config.Form>]
            Value: string option
        }

    type CreatePreview'CustomerDetailsTaxIds with
        static member New(?type': CreatePreview'CustomerDetailsTaxIdsType, ?value: string) =
            {
                Type = type'
                Value = value
            }

    type CreatePreview'CustomerDetails =
        {
            /// The customer's address. Learn about [country-specific requirements for calculating tax](/invoicing/taxes?dashboard-or-api=dashboard#set-up-customer).
            [<Config.Form>]
            Address: Choice<CreatePreview'CustomerDetailsAddressOptionalFieldsAddress,string> option
            /// The customer's shipping information. Appears on invoices emailed to this customer.
            [<Config.Form>]
            Shipping: Choice<CreatePreview'CustomerDetailsShippingCustomerShipping,string> option
            /// Tax details about the customer.
            [<Config.Form>]
            Tax: CreatePreview'CustomerDetailsTax option
            /// The customer's tax exemption. One of `none`, `exempt`, or `reverse`.
            [<Config.Form>]
            TaxExempt: CreatePreview'CustomerDetailsTaxExempt option
            /// The customer's tax IDs.
            [<Config.Form>]
            TaxIds: CreatePreview'CustomerDetailsTaxIds list option
        }

    type CreatePreview'CustomerDetails with
        static member New(?address: Choice<CreatePreview'CustomerDetailsAddressOptionalFieldsAddress,string>, ?shipping: Choice<CreatePreview'CustomerDetailsShippingCustomerShipping,string>, ?tax: CreatePreview'CustomerDetailsTax, ?taxExempt: CreatePreview'CustomerDetailsTaxExempt, ?taxIds: CreatePreview'CustomerDetailsTaxIds list) =
            {
                Address = address
                Shipping = shipping
                Tax = tax
                TaxExempt = taxExempt
                TaxIds = taxIds
            }

    type CreatePreview'Discounts =
        {
            /// ID of the coupon to create a new discount for.
            [<Config.Form>]
            Coupon: string option
            /// ID of an existing discount on the object (or one of its ancestors) to reuse.
            [<Config.Form>]
            Discount: string option
            /// ID of the promotion code to create a new discount for.
            [<Config.Form>]
            PromotionCode: string option
        }

    type CreatePreview'Discounts with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type CreatePreview'InvoiceItemsDiscounts =
        {
            /// ID of the coupon to create a new discount for.
            [<Config.Form>]
            Coupon: string option
            /// ID of an existing discount on the object (or one of its ancestors) to reuse.
            [<Config.Form>]
            Discount: string option
            /// ID of the promotion code to create a new discount for.
            [<Config.Form>]
            PromotionCode: string option
        }

    type CreatePreview'InvoiceItemsDiscounts with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type CreatePreview'InvoiceItemsPeriod =
        {
            /// The end of the period, which must be greater than or equal to the start. This value is inclusive.
            [<Config.Form>]
            End: DateTime option
            /// The start of the period. This value is inclusive.
            [<Config.Form>]
            Start: DateTime option
        }

    type CreatePreview'InvoiceItemsPeriod with
        static member New(?end': DateTime, ?start: DateTime) =
            {
                End = end'
                Start = start
            }

    type CreatePreview'InvoiceItemsPriceDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type CreatePreview'InvoiceItemsPriceData =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.
            [<Config.Form>]
            Product: string option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: CreatePreview'InvoiceItemsPriceDataTaxBehavior option
            /// A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    type CreatePreview'InvoiceItemsPriceData with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?taxBehavior: CreatePreview'InvoiceItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type CreatePreview'InvoiceItemsTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type CreatePreview'InvoiceItems =
        {
            /// The integer amount in cents (or local equivalent) of previewed invoice item.
            [<Config.Form>]
            Amount: int option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies). Only applicable to new invoice items.
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// An arbitrary string which you can attach to the invoice item. The description is displayed in the invoice for easy tracking.
            [<Config.Form>]
            Description: string option
            /// Explicitly controls whether discounts apply to this invoice item. Defaults to true, except for negative invoice items.
            [<Config.Form>]
            Discountable: bool option
            /// The coupons to redeem into discounts for the invoice item in the preview.
            [<Config.Form>]
            Discounts: Choice<CreatePreview'InvoiceItemsDiscounts list,string> option
            /// The ID of the invoice item to update in preview. If not specified, a new invoice item will be added to the preview of the upcoming invoice.
            [<Config.Form>]
            Invoiceitem: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The period associated with this invoice item. When set to different values, the period will be rendered on the invoice. If you have [Stripe Revenue Recognition](https://docs.stripe.com/revenue-recognition) enabled, the period will be used to recognize and defer revenue. See the [Revenue Recognition documentation](https://docs.stripe.com/revenue-recognition/methodology/subscriptions-and-invoicing) for details.
            [<Config.Form>]
            Period: CreatePreview'InvoiceItemsPeriod option
            /// The ID of the price object. One of `price` or `price_data` is required.
            [<Config.Form>]
            Price: string option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.
            [<Config.Form>]
            PriceData: CreatePreview'InvoiceItemsPriceData option
            /// Non-negative integer. The quantity of units for the invoice item. Use `quantity_decimal` instead to provide decimal precision. This field will be deprecated in favor of `quantity_decimal` in a future version.
            [<Config.Form>]
            Quantity: int option
            /// Non-negative decimal with at most 12 decimal places. The quantity of units for the invoice item.
            [<Config.Form>]
            QuantityDecimal: string option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: CreatePreview'InvoiceItemsTaxBehavior option
            /// A [tax code](https://docs.stripe.com/tax/tax-categories) ID.
            [<Config.Form>]
            TaxCode: Choice<string,string> option
            /// The tax rates that apply to the item. When set, any `default_tax_rates` do not apply to this item.
            [<Config.Form>]
            TaxRates: Choice<string list,string> option
            /// The integer unit amount in cents (or local equivalent) of the charge to be applied to the upcoming invoice. This unit_amount will be multiplied by the quantity to get the full amount. If you want to apply a credit to the customer's account, pass a negative unit_amount.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    type CreatePreview'InvoiceItems with
        static member New(?amount: int, ?currency: IsoTypes.IsoCurrencyCode, ?description: string, ?discountable: bool, ?discounts: Choice<CreatePreview'InvoiceItemsDiscounts list,string>, ?invoiceitem: string, ?metadata: Map<string, string>, ?period: CreatePreview'InvoiceItemsPeriod, ?price: string, ?priceData: CreatePreview'InvoiceItemsPriceData, ?quantity: int, ?quantityDecimal: string, ?taxBehavior: CreatePreview'InvoiceItemsTaxBehavior, ?taxCode: Choice<string,string>, ?taxRates: Choice<string list,string>, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Amount = amount
                Currency = currency
                Description = description
                Discountable = discountable
                Discounts = discounts
                Invoiceitem = invoiceitem
                Metadata = metadata
                Period = period
                Price = price
                PriceData = priceData
                Quantity = quantity
                QuantityDecimal = quantityDecimal
                TaxBehavior = taxBehavior
                TaxCode = taxCode
                TaxRates = taxRates
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type CreatePreview'IssuerType =
        | Account
        | Self

    type CreatePreview'Issuer =
        {
            /// The connected account being referenced when `type` is `account`.
            [<Config.Form>]
            Account: string option
            /// Type of the account referenced in the request.
            [<Config.Form>]
            Type: CreatePreview'IssuerType option
        }

    type CreatePreview'Issuer with
        static member New(?account: string, ?type': CreatePreview'IssuerType) =
            {
                Account = account
                Type = type'
            }

    type CreatePreview'PreviewMode =
        | Next
        | Recurring

    type CreatePreview'ScheduleDetailsBillingModeFlexibleProrationDiscounts =
        | Included
        | Itemized

    type CreatePreview'ScheduleDetailsBillingModeFlexible =
        {
            /// Controls how invoices and invoice items display proration amounts and discount amounts.
            [<Config.Form>]
            ProrationDiscounts: CreatePreview'ScheduleDetailsBillingModeFlexibleProrationDiscounts option
        }

    type CreatePreview'ScheduleDetailsBillingModeFlexible with
        static member New(?prorationDiscounts: CreatePreview'ScheduleDetailsBillingModeFlexibleProrationDiscounts) =
            {
                ProrationDiscounts = prorationDiscounts
            }

    type CreatePreview'ScheduleDetailsBillingModeType =
        | Classic
        | Flexible

    type CreatePreview'ScheduleDetailsBillingMode =
        {
            /// Configure behavior for flexible billing mode.
            [<Config.Form>]
            Flexible: CreatePreview'ScheduleDetailsBillingModeFlexible option
            /// Controls the calculation and orchestration of prorations and invoices for subscriptions. If no value is passed, the default is `flexible`.
            [<Config.Form>]
            Type: CreatePreview'ScheduleDetailsBillingModeType option
        }

    type CreatePreview'ScheduleDetailsBillingMode with
        static member New(?flexible: CreatePreview'ScheduleDetailsBillingModeFlexible, ?type': CreatePreview'ScheduleDetailsBillingModeType) =
            {
                Flexible = flexible
                Type = type'
            }

    type CreatePreview'ScheduleDetailsEndBehavior =
        | Cancel
        | Release

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsDiscounts =
        {
            /// ID of the coupon to create a new discount for.
            [<Config.Form>]
            Coupon: string option
            /// ID of an existing discount on the object (or one of its ancestors) to reuse.
            [<Config.Form>]
            Discount: string option
            /// ID of the promotion code to create a new discount for.
            [<Config.Form>]
            PromotionCode: string option
        }

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsDiscounts with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodEndType =
        | MinItemPeriodEnd
        | PhaseEnd
        | Timestamp

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodEnd =
        {
            /// A precise Unix timestamp for the end of the invoice item period. Must be greater than or equal to `period.start`.
            [<Config.Form>]
            Timestamp: DateTime option
            /// Select how to calculate the end of the invoice item period.
            [<Config.Form>]
            Type: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodEndType option
        }

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodEnd with
        static member New(?timestamp: DateTime, ?type': CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodEndType) =
            {
                Timestamp = timestamp
                Type = type'
            }

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodStartType =
        | MaxItemPeriodStart
        | PhaseStart
        | Timestamp

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodStart =
        {
            /// A precise Unix timestamp for the start of the invoice item period. Must be less than or equal to `period.end`.
            [<Config.Form>]
            Timestamp: DateTime option
            /// Select how to calculate the start of the invoice item period.
            [<Config.Form>]
            Type: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodStartType option
        }

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodStart with
        static member New(?timestamp: DateTime, ?type': CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodStartType) =
            {
                Timestamp = timestamp
                Type = type'
            }

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriod =
        {
            /// End of the invoice item period.
            [<Config.Form>]
            End: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodEnd option
            /// Start of the invoice item period.
            [<Config.Form>]
            Start: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodStart option
        }

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriod with
        static member New(?end': CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodEnd, ?start: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodStart) =
            {
                End = end'
                Start = start
            }

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPriceDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPriceData =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.
            [<Config.Form>]
            Product: string option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPriceDataTaxBehavior option
            /// A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge or a negative integer representing the amount to credit to the customer.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPriceData with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?taxBehavior: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItems =
        {
            /// The coupons to redeem into discounts for the item.
            [<Config.Form>]
            Discounts: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsDiscounts list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The period associated with this invoice item. If not set, `period.start.type` defaults to `max_item_period_start` and `period.end.type` defaults to `min_item_period_end`.
            [<Config.Form>]
            Period: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriod option
            /// The ID of the price object. One of `price` or `price_data` is required.
            [<Config.Form>]
            Price: string option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.
            [<Config.Form>]
            PriceData: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPriceData option
            /// Quantity for this item. Defaults to 1.
            [<Config.Form>]
            Quantity: int option
            /// The tax rates which apply to the item. When set, the `default_tax_rates` do not apply to this item.
            [<Config.Form>]
            TaxRates: Choice<string list,string> option
        }

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItems with
        static member New(?discounts: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsDiscounts list, ?metadata: Map<string, string>, ?period: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriod, ?price: string, ?priceData: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                Discounts = discounts
                Metadata = metadata
                Period = period
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type CreatePreview'ScheduleDetailsPhasesAutomaticTaxLiabilityType =
        | Account
        | Self

    type CreatePreview'ScheduleDetailsPhasesAutomaticTaxLiability =
        {
            /// The connected account being referenced when `type` is `account`.
            [<Config.Form>]
            Account: string option
            /// Type of the account referenced in the request.
            [<Config.Form>]
            Type: CreatePreview'ScheduleDetailsPhasesAutomaticTaxLiabilityType option
        }

    type CreatePreview'ScheduleDetailsPhasesAutomaticTaxLiability with
        static member New(?account: string, ?type': CreatePreview'ScheduleDetailsPhasesAutomaticTaxLiabilityType) =
            {
                Account = account
                Type = type'
            }

    type CreatePreview'ScheduleDetailsPhasesAutomaticTax =
        {
            /// Enabled automatic tax calculation which will automatically compute tax rates on all invoices generated by the subscription.
            [<Config.Form>]
            Enabled: bool option
            /// The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.
            [<Config.Form>]
            Liability: CreatePreview'ScheduleDetailsPhasesAutomaticTaxLiability option
        }

    type CreatePreview'ScheduleDetailsPhasesAutomaticTax with
        static member New(?enabled: bool, ?liability: CreatePreview'ScheduleDetailsPhasesAutomaticTaxLiability) =
            {
                Enabled = enabled
                Liability = liability
            }

    type CreatePreview'ScheduleDetailsPhasesBillingCycleAnchor =
        | Automatic
        | PhaseStart

    type CreatePreview'ScheduleDetailsPhasesBillingThresholdsBillingThresholds =
        {
            /// Monetary threshold that triggers the subscription to advance to a new billing period
            [<Config.Form>]
            AmountGte: int option
            /// Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.
            [<Config.Form>]
            ResetBillingCycleAnchor: bool option
        }

    type CreatePreview'ScheduleDetailsPhasesBillingThresholdsBillingThresholds with
        static member New(?amountGte: int, ?resetBillingCycleAnchor: bool) =
            {
                AmountGte = amountGte
                ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type CreatePreview'ScheduleDetailsPhasesCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    type CreatePreview'ScheduleDetailsPhasesDiscounts =
        {
            /// ID of the coupon to create a new discount for.
            [<Config.Form>]
            Coupon: string option
            /// ID of an existing discount on the object (or one of its ancestors) to reuse.
            [<Config.Form>]
            Discount: string option
            /// ID of the promotion code to create a new discount for.
            [<Config.Form>]
            PromotionCode: string option
        }

    type CreatePreview'ScheduleDetailsPhasesDiscounts with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type CreatePreview'ScheduleDetailsPhasesDurationInterval =
        | Day
        | Month
        | Week
        | Year

    type CreatePreview'ScheduleDetailsPhasesDuration =
        {
            /// Specifies phase duration. Either `day`, `week`, `month` or `year`.
            [<Config.Form>]
            Interval: CreatePreview'ScheduleDetailsPhasesDurationInterval option
            /// The multiplier applied to the interval.
            [<Config.Form>]
            IntervalCount: int option
        }

    type CreatePreview'ScheduleDetailsPhasesDuration with
        static member New(?interval: CreatePreview'ScheduleDetailsPhasesDurationInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type CreatePreview'ScheduleDetailsPhasesEndDate = | Now

    type CreatePreview'ScheduleDetailsPhasesInvoiceSettingsIssuerType =
        | Account
        | Self

    type CreatePreview'ScheduleDetailsPhasesInvoiceSettingsIssuer =
        {
            /// The connected account being referenced when `type` is `account`.
            [<Config.Form>]
            Account: string option
            /// Type of the account referenced in the request.
            [<Config.Form>]
            Type: CreatePreview'ScheduleDetailsPhasesInvoiceSettingsIssuerType option
        }

    type CreatePreview'ScheduleDetailsPhasesInvoiceSettingsIssuer with
        static member New(?account: string, ?type': CreatePreview'ScheduleDetailsPhasesInvoiceSettingsIssuerType) =
            {
                Account = account
                Type = type'
            }

    type CreatePreview'ScheduleDetailsPhasesInvoiceSettings =
        {
            /// The account tax IDs associated with this phase of the subscription schedule. Will be set on invoices generated by this phase of the subscription schedule.
            [<Config.Form>]
            AccountTaxIds: Choice<string list,string> option
            /// Number of days within which a customer must pay invoices generated by this subscription schedule. This value will be `null` for subscription schedules where `billing=charge_automatically`.
            [<Config.Form>]
            DaysUntilDue: int option
            /// The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.
            [<Config.Form>]
            Issuer: CreatePreview'ScheduleDetailsPhasesInvoiceSettingsIssuer option
        }

    type CreatePreview'ScheduleDetailsPhasesInvoiceSettings with
        static member New(?accountTaxIds: Choice<string list,string>, ?daysUntilDue: int, ?issuer: CreatePreview'ScheduleDetailsPhasesInvoiceSettingsIssuer) =
            {
                AccountTaxIds = accountTaxIds
                DaysUntilDue = daysUntilDue
                Issuer = issuer
            }

    type CreatePreview'ScheduleDetailsPhasesItemsBillingThresholdsItemBillingThresholds =
        {
            /// Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://docs.stripe.com/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))
            [<Config.Form>]
            UsageGte: int option
        }

    type CreatePreview'ScheduleDetailsPhasesItemsBillingThresholdsItemBillingThresholds with
        static member New(?usageGte: int) =
            {
                UsageGte = usageGte
            }

    type CreatePreview'ScheduleDetailsPhasesItemsDiscounts =
        {
            /// ID of the coupon to create a new discount for.
            [<Config.Form>]
            Coupon: string option
            /// ID of an existing discount on the object (or one of its ancestors) to reuse.
            [<Config.Form>]
            Discount: string option
            /// ID of the promotion code to create a new discount for.
            [<Config.Form>]
            PromotionCode: string option
        }

    type CreatePreview'ScheduleDetailsPhasesItemsDiscounts with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type CreatePreview'ScheduleDetailsPhasesItemsPriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    type CreatePreview'ScheduleDetailsPhasesItemsPriceDataRecurring =
        {
            /// Specifies billing frequency. Either `day`, `week`, `month` or `year`.
            [<Config.Form>]
            Interval: CreatePreview'ScheduleDetailsPhasesItemsPriceDataRecurringInterval option
            /// The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).
            [<Config.Form>]
            IntervalCount: int option
        }

    type CreatePreview'ScheduleDetailsPhasesItemsPriceDataRecurring with
        static member New(?interval: CreatePreview'ScheduleDetailsPhasesItemsPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type CreatePreview'ScheduleDetailsPhasesItemsPriceDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type CreatePreview'ScheduleDetailsPhasesItemsPriceData =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.
            [<Config.Form>]
            Product: string option
            /// The recurring components of a price such as `interval` and `interval_count`.
            [<Config.Form>]
            Recurring: CreatePreview'ScheduleDetailsPhasesItemsPriceDataRecurring option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: CreatePreview'ScheduleDetailsPhasesItemsPriceDataTaxBehavior option
            /// A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    type CreatePreview'ScheduleDetailsPhasesItemsPriceData with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?recurring: CreatePreview'ScheduleDetailsPhasesItemsPriceDataRecurring, ?taxBehavior: CreatePreview'ScheduleDetailsPhasesItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type CreatePreview'ScheduleDetailsPhasesItems =
        {
            /// Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
            [<Config.Form>]
            BillingThresholds:
                Choice<CreatePreview'ScheduleDetailsPhasesItemsBillingThresholdsItemBillingThresholds,string> option
            /// The coupons to redeem into discounts for the subscription item.
            [<Config.Form>]
            Discounts: Choice<CreatePreview'ScheduleDetailsPhasesItemsDiscounts list,string> option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to a configuration item. Metadata on a configuration item will update the underlying subscription item's `metadata` when the phase is entered, adding new keys and replacing existing keys. Individual keys in the subscription item's `metadata` can be unset by posting an empty value to them in the configuration item's `metadata`. To unset all keys in the subscription item's `metadata`, update the subscription item directly or unset every key individually from the configuration item's `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The plan ID to subscribe to. You may specify the same ID in `plan` and `price`.
            [<Config.Form>]
            Plan: string option
            /// The ID of the price object.
            [<Config.Form>]
            Price: string option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline.
            [<Config.Form>]
            PriceData: CreatePreview'ScheduleDetailsPhasesItemsPriceData option
            /// Quantity for the given price. Can be set only if the price's `usage_type` is `licensed` and not `metered`.
            [<Config.Form>]
            Quantity: int option
            /// A list of [Tax Rate](https://docs.stripe.com/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://docs.stripe.com/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.
            [<Config.Form>]
            TaxRates: Choice<string list,string> option
        }

    type CreatePreview'ScheduleDetailsPhasesItems with
        static member New(?billingThresholds: Choice<CreatePreview'ScheduleDetailsPhasesItemsBillingThresholdsItemBillingThresholds,string>, ?discounts: Choice<CreatePreview'ScheduleDetailsPhasesItemsDiscounts list,string>, ?metadata: Map<string, string>, ?plan: string, ?price: string, ?priceData: CreatePreview'ScheduleDetailsPhasesItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                BillingThresholds = billingThresholds
                Discounts = discounts
                Metadata = metadata
                Plan = plan
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type CreatePreview'ScheduleDetailsPhasesProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | [<JsonPropertyName("none")>] None'

    type CreatePreview'ScheduleDetailsPhasesStartDate = | Now

    type CreatePreview'ScheduleDetailsPhasesTransferData =
        {
            /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination.
            [<Config.Form>]
            AmountPercent: decimal option
            /// ID of an existing, connected Stripe account.
            [<Config.Form>]
            Destination: string option
        }

    type CreatePreview'ScheduleDetailsPhasesTransferData with
        static member New(?amountPercent: decimal, ?destination: string) =
            {
                AmountPercent = amountPercent
                Destination = destination
            }

    type CreatePreview'ScheduleDetailsPhasesTrialEnd = | Now

    type CreatePreview'ScheduleDetailsPhases =
        {
            /// A list of prices and quantities that will generate invoice items appended to the next invoice for this phase. You may pass up to 20 items.
            [<Config.Form>]
            AddInvoiceItems: CreatePreview'ScheduleDetailsPhasesAddInvoiceItems list option
            /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).
            [<Config.Form>]
            ApplicationFeePercent: decimal option
            /// Automatic tax settings for this phase.
            [<Config.Form>]
            AutomaticTax: CreatePreview'ScheduleDetailsPhasesAutomaticTax option
            /// Can be set to `phase_start` to set the anchor to the start of the phase or `automatic` to automatically change it if needed. Cannot be set to `phase_start` if this phase specifies a trial. For more information, see the billing cycle [documentation](https://docs.stripe.com/billing/subscriptions/billing-cycle).
            [<Config.Form>]
            BillingCycleAnchor: CreatePreview'ScheduleDetailsPhasesBillingCycleAnchor option
            /// Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
            [<Config.Form>]
            BillingThresholds: Choice<CreatePreview'ScheduleDetailsPhasesBillingThresholdsBillingThresholds,string> option
            /// Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay the underlying subscription at the end of each billing cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically` on creation.
            [<Config.Form>]
            CollectionMethod: CreatePreview'ScheduleDetailsPhasesCollectionMethod option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// ID of the default payment method for the subscription schedule. It must belong to the customer associated with the subscription schedule. If not set, invoices will use the default payment method in the customer's invoice settings.
            [<Config.Form>]
            DefaultPaymentMethod: string option
            /// A list of [Tax Rate](https://docs.stripe.com/api/tax_rates) ids. These Tax Rates will set the Subscription's [`default_tax_rates`](https://docs.stripe.com/api/subscriptions/create#create_subscription-default_tax_rates), which means they will be the Invoice's [`default_tax_rates`](https://docs.stripe.com/api/invoices/create#create_invoice-default_tax_rates) for any Invoices issued by the Subscription during this Phase.
            [<Config.Form>]
            DefaultTaxRates: Choice<string list,string> option
            /// Subscription description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription for rendering in Stripe surfaces and certain local payment methods UIs.
            [<Config.Form>]
            Description: Choice<string,string> option
            /// The coupons to redeem into discounts for the schedule phase. If not specified, inherits the discount from the subscription's customer. Pass an empty string to avoid inheriting any discounts.
            [<Config.Form>]
            Discounts: Choice<CreatePreview'ScheduleDetailsPhasesDiscounts list,string> option
            /// The number of intervals the phase should last. If set, `end_date` must not be set.
            [<Config.Form>]
            Duration: CreatePreview'ScheduleDetailsPhasesDuration option
            /// The date at which this phase of the subscription schedule ends. If set, `duration` must not be set.
            [<Config.Form>]
            EndDate: Choice<DateTime,CreatePreview'ScheduleDetailsPhasesEndDate> option
            /// All invoices will be billed using the specified settings.
            [<Config.Form>]
            InvoiceSettings: CreatePreview'ScheduleDetailsPhasesInvoiceSettings option
            /// List of configuration items, each with an attached price, to apply during this phase of the subscription schedule.
            [<Config.Form>]
            Items: CreatePreview'ScheduleDetailsPhasesItems list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to a phase. Metadata on a schedule's phase will update the underlying subscription's `metadata` when the phase is entered, adding new keys and replacing existing keys in the subscription's `metadata`. Individual keys in the subscription's `metadata` can be unset by posting an empty value to them in the phase's `metadata`. To unset all keys in the subscription's `metadata`, update the subscription directly or unset every key individually from the phase's `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The account on behalf of which to charge, for each of the associated subscription's invoices.
            [<Config.Form>]
            OnBehalfOf: string option
            /// Controls whether the subscription schedule should create [prorations](https://docs.stripe.com/billing/subscriptions/prorations) when transitioning to this phase if there is a difference in billing configuration. It's different from the request-level [proration_behavior](https://docs.stripe.com/api/subscription_schedules/update#update_subscription_schedule-proration_behavior) parameter which controls what happens if the update request affects the billing configuration (item price, quantity, etc.) of the current phase.
            [<Config.Form>]
            ProrationBehavior: CreatePreview'ScheduleDetailsPhasesProrationBehavior option
            /// The date at which this phase of the subscription schedule starts or `now`. Must be set on the first phase.
            [<Config.Form>]
            StartDate: Choice<DateTime,CreatePreview'ScheduleDetailsPhasesStartDate> option
            /// The data with which to automatically create a Transfer for each of the associated subscription's invoices.
            [<Config.Form>]
            TransferData: CreatePreview'ScheduleDetailsPhasesTransferData option
            /// If set to true the entire phase is counted as a trial and the customer will not be charged for any fees.
            [<Config.Form>]
            Trial: bool option
            /// Sets the phase to trialing from the start date to this date. Must be before the phase end date, can not be combined with `trial`
            [<Config.Form>]
            TrialEnd: Choice<DateTime,CreatePreview'ScheduleDetailsPhasesTrialEnd> option
        }

    type CreatePreview'ScheduleDetailsPhases with
        static member New(?addInvoiceItems: CreatePreview'ScheduleDetailsPhasesAddInvoiceItems list, ?applicationFeePercent: decimal, ?automaticTax: CreatePreview'ScheduleDetailsPhasesAutomaticTax, ?billingCycleAnchor: CreatePreview'ScheduleDetailsPhasesBillingCycleAnchor, ?billingThresholds: Choice<CreatePreview'ScheduleDetailsPhasesBillingThresholdsBillingThresholds,string>, ?collectionMethod: CreatePreview'ScheduleDetailsPhasesCollectionMethod, ?currency: IsoTypes.IsoCurrencyCode, ?defaultPaymentMethod: string, ?defaultTaxRates: Choice<string list,string>, ?description: Choice<string,string>, ?discounts: Choice<CreatePreview'ScheduleDetailsPhasesDiscounts list,string>, ?duration: CreatePreview'ScheduleDetailsPhasesDuration, ?endDate: Choice<DateTime,CreatePreview'ScheduleDetailsPhasesEndDate>, ?invoiceSettings: CreatePreview'ScheduleDetailsPhasesInvoiceSettings, ?items: CreatePreview'ScheduleDetailsPhasesItems list, ?metadata: Map<string, string>, ?onBehalfOf: string, ?prorationBehavior: CreatePreview'ScheduleDetailsPhasesProrationBehavior, ?startDate: Choice<DateTime,CreatePreview'ScheduleDetailsPhasesStartDate>, ?transferData: CreatePreview'ScheduleDetailsPhasesTransferData, ?trial: bool, ?trialEnd: Choice<DateTime,CreatePreview'ScheduleDetailsPhasesTrialEnd>) =
            {
                AddInvoiceItems = addInvoiceItems
                ApplicationFeePercent = applicationFeePercent
                AutomaticTax = automaticTax
                BillingCycleAnchor = billingCycleAnchor
                BillingThresholds = billingThresholds
                CollectionMethod = collectionMethod
                Currency = currency
                DefaultPaymentMethod = defaultPaymentMethod
                DefaultTaxRates = defaultTaxRates
                Description = description
                Discounts = discounts
                Duration = duration
                EndDate = endDate
                InvoiceSettings = invoiceSettings
                Items = items
                Metadata = metadata
                OnBehalfOf = onBehalfOf
                ProrationBehavior = prorationBehavior
                StartDate = startDate
                TransferData = transferData
                Trial = trial
                TrialEnd = trialEnd
            }

    type CreatePreview'ScheduleDetailsProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | [<JsonPropertyName("none")>] None'

    type CreatePreview'ScheduleDetails =
        {
            /// Controls how prorations and invoices for subscriptions are calculated and orchestrated.
            [<Config.Form>]
            BillingMode: CreatePreview'ScheduleDetailsBillingMode option
            /// Behavior of the subscription schedule and underlying subscription when it ends. Possible values are `release` or `cancel` with the default being `release`. `release` will end the subscription schedule and keep the underlying subscription running. `cancel` will end the subscription schedule and cancel the underlying subscription.
            [<Config.Form>]
            EndBehavior: CreatePreview'ScheduleDetailsEndBehavior option
            /// List representing phases of the subscription schedule. Each phase can be customized to have different durations, plans, and coupons. If there are multiple phases, the `end_date` of one phase will always equal the `start_date` of the next phase.
            [<Config.Form>]
            Phases: CreatePreview'ScheduleDetailsPhases list option
            /// In cases where the `schedule_details` params update the currently active phase, specifies if and how to prorate at the time of the request.
            [<Config.Form>]
            ProrationBehavior: CreatePreview'ScheduleDetailsProrationBehavior option
        }

    type CreatePreview'ScheduleDetails with
        static member New(?billingMode: CreatePreview'ScheduleDetailsBillingMode, ?endBehavior: CreatePreview'ScheduleDetailsEndBehavior, ?phases: CreatePreview'ScheduleDetailsPhases list, ?prorationBehavior: CreatePreview'ScheduleDetailsProrationBehavior) =
            {
                BillingMode = billingMode
                EndBehavior = endBehavior
                Phases = phases
                ProrationBehavior = prorationBehavior
            }

    type CreatePreview'SubscriptionDetailsBillingCycleAnchor =
        | Now
        | Unchanged

    type CreatePreview'SubscriptionDetailsBillingModeFlexibleProrationDiscounts =
        | Included
        | Itemized

    type CreatePreview'SubscriptionDetailsBillingModeFlexible =
        {
            /// Controls how invoices and invoice items display proration amounts and discount amounts.
            [<Config.Form>]
            ProrationDiscounts: CreatePreview'SubscriptionDetailsBillingModeFlexibleProrationDiscounts option
        }

    type CreatePreview'SubscriptionDetailsBillingModeFlexible with
        static member New(?prorationDiscounts: CreatePreview'SubscriptionDetailsBillingModeFlexibleProrationDiscounts) =
            {
                ProrationDiscounts = prorationDiscounts
            }

    type CreatePreview'SubscriptionDetailsBillingModeType =
        | Classic
        | Flexible

    type CreatePreview'SubscriptionDetailsBillingMode =
        {
            /// Configure behavior for flexible billing mode.
            [<Config.Form>]
            Flexible: CreatePreview'SubscriptionDetailsBillingModeFlexible option
            /// Controls the calculation and orchestration of prorations and invoices for subscriptions. If no value is passed, the default is `flexible`.
            [<Config.Form>]
            Type: CreatePreview'SubscriptionDetailsBillingModeType option
        }

    type CreatePreview'SubscriptionDetailsBillingMode with
        static member New(?flexible: CreatePreview'SubscriptionDetailsBillingModeFlexible, ?type': CreatePreview'SubscriptionDetailsBillingModeType) =
            {
                Flexible = flexible
                Type = type'
            }

    type CreatePreview'SubscriptionDetailsCancelAt =
        | MaxPeriodEnd
        | MinPeriodEnd

    type CreatePreview'SubscriptionDetailsItemsBillingThresholdsItemBillingThresholds =
        {
            /// Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://docs.stripe.com/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))
            [<Config.Form>]
            UsageGte: int option
        }

    type CreatePreview'SubscriptionDetailsItemsBillingThresholdsItemBillingThresholds with
        static member New(?usageGte: int) =
            {
                UsageGte = usageGte
            }

    type CreatePreview'SubscriptionDetailsItemsDiscounts =
        {
            /// ID of the coupon to create a new discount for.
            [<Config.Form>]
            Coupon: string option
            /// ID of an existing discount on the object (or one of its ancestors) to reuse.
            [<Config.Form>]
            Discount: string option
            /// ID of the promotion code to create a new discount for.
            [<Config.Form>]
            PromotionCode: string option
        }

    type CreatePreview'SubscriptionDetailsItemsDiscounts with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type CreatePreview'SubscriptionDetailsItemsPriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    type CreatePreview'SubscriptionDetailsItemsPriceDataRecurring =
        {
            /// Specifies billing frequency. Either `day`, `week`, `month` or `year`.
            [<Config.Form>]
            Interval: CreatePreview'SubscriptionDetailsItemsPriceDataRecurringInterval option
            /// The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).
            [<Config.Form>]
            IntervalCount: int option
        }

    type CreatePreview'SubscriptionDetailsItemsPriceDataRecurring with
        static member New(?interval: CreatePreview'SubscriptionDetailsItemsPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type CreatePreview'SubscriptionDetailsItemsPriceDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type CreatePreview'SubscriptionDetailsItemsPriceData =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.
            [<Config.Form>]
            Product: string option
            /// The recurring components of a price such as `interval` and `interval_count`.
            [<Config.Form>]
            Recurring: CreatePreview'SubscriptionDetailsItemsPriceDataRecurring option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: CreatePreview'SubscriptionDetailsItemsPriceDataTaxBehavior option
            /// A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    type CreatePreview'SubscriptionDetailsItemsPriceData with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?recurring: CreatePreview'SubscriptionDetailsItemsPriceDataRecurring, ?taxBehavior: CreatePreview'SubscriptionDetailsItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type CreatePreview'SubscriptionDetailsItems =
        {
            /// Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
            [<Config.Form>]
            BillingThresholds:
                Choice<CreatePreview'SubscriptionDetailsItemsBillingThresholdsItemBillingThresholds,string> option
            /// Delete all usage for a given subscription item. You must pass this when deleting a usage records subscription item. `clear_usage` has no effect if the plan has a billing meter attached.
            [<Config.Form>]
            ClearUsage: bool option
            /// A flag that, if set to `true`, will delete the specified item.
            [<Config.Form>]
            Deleted: bool option
            /// The coupons to redeem into discounts for the subscription item.
            [<Config.Form>]
            Discounts: Choice<CreatePreview'SubscriptionDetailsItemsDiscounts list,string> option
            /// Subscription item to update.
            [<Config.Form>]
            Id: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Plan ID for this item, as a string.
            [<Config.Form>]
            Plan: string option
            /// The ID of the price object. One of `price` or `price_data` is required. When changing a subscription item's price, `quantity` is set to 1 unless a `quantity` parameter is provided.
            [<Config.Form>]
            Price: string option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.
            [<Config.Form>]
            PriceData: CreatePreview'SubscriptionDetailsItemsPriceData option
            /// Quantity for this item.
            [<Config.Form>]
            Quantity: int option
            /// A list of [Tax Rate](https://docs.stripe.com/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://docs.stripe.com/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.
            [<Config.Form>]
            TaxRates: Choice<string list,string> option
        }

    type CreatePreview'SubscriptionDetailsItems with
        static member New(?billingThresholds: Choice<CreatePreview'SubscriptionDetailsItemsBillingThresholdsItemBillingThresholds,string>, ?clearUsage: bool, ?deleted: bool, ?discounts: Choice<CreatePreview'SubscriptionDetailsItemsDiscounts list,string>, ?id: string, ?metadata: Map<string, string>, ?plan: string, ?price: string, ?priceData: CreatePreview'SubscriptionDetailsItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                BillingThresholds = billingThresholds
                ClearUsage = clearUsage
                Deleted = deleted
                Discounts = discounts
                Id = id
                Metadata = metadata
                Plan = plan
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type CreatePreview'SubscriptionDetailsProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | [<JsonPropertyName("none")>] None'

    type CreatePreview'SubscriptionDetailsResumeAt = | Now

    type CreatePreview'SubscriptionDetailsTrialEnd = | Now

    type CreatePreview'SubscriptionDetails =
        {
            /// For new subscriptions, a future timestamp to anchor the subscription's [billing cycle](https://docs.stripe.com/subscriptions/billing-cycle). This is used to determine the date of the first full invoice, and, for plans with `month` or `year` intervals, the day of the month for subsequent invoices. For existing subscriptions, the value can only be set to `now` or `unchanged`.
            [<Config.Form>]
            BillingCycleAnchor: Choice<CreatePreview'SubscriptionDetailsBillingCycleAnchor,DateTime> option
            /// Controls how prorations and invoices for subscriptions are calculated and orchestrated.
            [<Config.Form>]
            BillingMode: CreatePreview'SubscriptionDetailsBillingMode option
            /// A timestamp at which the subscription should cancel. If set to a date before the current period ends, this will cause a proration if prorations have been enabled using `proration_behavior`. If set during a future period, this will always cause a proration for that period.
            [<Config.Form>]
            CancelAt: Choice<DateTime,string,CreatePreview'SubscriptionDetailsCancelAt> option
            /// Indicate whether this subscription should cancel at the end of the current period (`current_period_end`). Defaults to `false`.
            [<Config.Form>]
            CancelAtPeriodEnd: bool option
            /// This simulates the subscription being canceled or expired immediately.
            [<Config.Form>]
            CancelNow: bool option
            /// If provided, the invoice returned will preview updating or creating a subscription with these default tax rates. The default tax rates will apply to any line item that does not have `tax_rates` set.
            [<Config.Form>]
            DefaultTaxRates: Choice<string list,string> option
            /// A list of up to 20 subscription items, each with an attached price.
            [<Config.Form>]
            Items: CreatePreview'SubscriptionDetailsItems list option
            /// Determines how to handle [prorations](https://docs.stripe.com/billing/subscriptions/prorations) when the billing cycle changes (e.g., when switching plans, resetting `billing_cycle_anchor=now`, or starting a trial), or if an item's `quantity` changes. The default value is `create_prorations`.
            [<Config.Form>]
            ProrationBehavior: CreatePreview'SubscriptionDetailsProrationBehavior option
            /// If previewing an update to a subscription, and doing proration, `subscription_details.proration_date` forces the proration to be calculated as though the update was done at the specified time. The time given must be within the current subscription period and within the current phase of the schedule backing this subscription, if the schedule exists. If set, `subscription`, and one of `subscription_details.items`, or `subscription_details.trial_end` are required. Also, `subscription_details.proration_behavior` cannot be set to 'none'.
            [<Config.Form>]
            ProrationDate: DateTime option
            /// For paused subscriptions, setting `subscription_details.resume_at` to `now` will preview the invoice that will be generated if the subscription is resumed.
            [<Config.Form>]
            ResumeAt: CreatePreview'SubscriptionDetailsResumeAt option
            /// Date a subscription is intended to start (can be future or past).
            [<Config.Form>]
            StartDate: DateTime option
            /// If provided, the invoice returned will preview updating or creating a subscription with that trial end. If set, one of `subscription_details.items` or `subscription` is required.
            [<Config.Form>]
            TrialEnd: Choice<CreatePreview'SubscriptionDetailsTrialEnd,DateTime> option
        }

    type CreatePreview'SubscriptionDetails with
        static member New(?billingCycleAnchor: Choice<CreatePreview'SubscriptionDetailsBillingCycleAnchor,DateTime>, ?billingMode: CreatePreview'SubscriptionDetailsBillingMode, ?cancelAt: Choice<DateTime,string,CreatePreview'SubscriptionDetailsCancelAt>, ?cancelAtPeriodEnd: bool, ?cancelNow: bool, ?defaultTaxRates: Choice<string list,string>, ?items: CreatePreview'SubscriptionDetailsItems list, ?prorationBehavior: CreatePreview'SubscriptionDetailsProrationBehavior, ?prorationDate: DateTime, ?resumeAt: CreatePreview'SubscriptionDetailsResumeAt, ?startDate: DateTime, ?trialEnd: Choice<CreatePreview'SubscriptionDetailsTrialEnd,DateTime>) =
            {
                BillingCycleAnchor = billingCycleAnchor
                BillingMode = billingMode
                CancelAt = cancelAt
                CancelAtPeriodEnd = cancelAtPeriodEnd
                CancelNow = cancelNow
                DefaultTaxRates = defaultTaxRates
                Items = items
                ProrationBehavior = prorationBehavior
                ProrationDate = prorationDate
                ResumeAt = resumeAt
                StartDate = startDate
                TrialEnd = trialEnd
            }

    type CreatePreviewOptions =
        {
            /// Settings for automatic tax lookup for this invoice preview.
            [<Config.Form>]
            AutomaticTax: CreatePreview'AutomaticTax option
            /// The currency to preview this invoice in. Defaults to that of `customer` if not specified.
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The identifier of the customer whose upcoming invoice you're retrieving. If `automatic_tax` is enabled then one of `customer`, `customer_details`, `subscription`, or `schedule` must be set.
            [<Config.Form>]
            Customer: string option
            /// The identifier of the account representing the customer whose upcoming invoice you're retrieving. If `automatic_tax` is enabled then one of `customer`, `customer_account`, `customer_details`, `subscription`, or `schedule` must be set.
            [<Config.Form>]
            CustomerAccount: string option
            /// Details about the customer you want to invoice or overrides for an existing customer. If `automatic_tax` is enabled then one of `customer`, `customer_details`, `subscription`, or `schedule` must be set.
            [<Config.Form>]
            CustomerDetails: CreatePreview'CustomerDetails option
            /// The coupons to redeem into discounts for the invoice preview. If not specified, inherits the discount from the subscription or customer. This works for both coupons directly applied to an invoice and coupons applied to a subscription. Pass an empty string to avoid inheriting any discounts.
            [<Config.Form>]
            Discounts: Choice<CreatePreview'Discounts list,string> option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// List of invoice items to add or update in the upcoming invoice preview (up to 250).
            [<Config.Form>]
            InvoiceItems: CreatePreview'InvoiceItems list option
            /// The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.
            [<Config.Form>]
            Issuer: CreatePreview'Issuer option
            /// The account (if any) for which the funds of the invoice payment are intended. If set, the invoice will be presented with the branding and support information of the specified account. See the [Invoices with Connect](https://docs.stripe.com/billing/invoices/connect) documentation for details.
            [<Config.Form>]
            OnBehalfOf: Choice<string,string> option
            /// Customizes the types of values to include when calculating the invoice. Defaults to `next` if unspecified.
            [<Config.Form>]
            PreviewMode: CreatePreview'PreviewMode option
            /// The identifier of the schedule whose upcoming invoice you'd like to retrieve. Cannot be used with subscription or subscription fields.
            [<Config.Form>]
            Schedule: string option
            /// The schedule creation or modification params to apply as a preview. Cannot be used with `subscription` or `subscription_` prefixed fields.
            [<Config.Form>]
            ScheduleDetails: CreatePreview'ScheduleDetails option
            /// The identifier of the subscription for which you'd like to retrieve the upcoming invoice. If not provided, but a `subscription_details.items` is provided, you will preview creating a subscription with those items. If neither `subscription` nor `subscription_details.items` is provided, you will retrieve the next upcoming invoice from among the customer's subscriptions.
            [<Config.Form>]
            Subscription: string option
            /// The subscription creation or modification params to apply as a preview. Cannot be used with `schedule` or `schedule_details` fields.
            [<Config.Form>]
            SubscriptionDetails: CreatePreview'SubscriptionDetails option
        }

    type CreatePreviewOptions with
        static member New(?automaticTax: CreatePreview'AutomaticTax, ?currency: IsoTypes.IsoCurrencyCode, ?customer: string, ?customerAccount: string, ?customerDetails: CreatePreview'CustomerDetails, ?discounts: Choice<CreatePreview'Discounts list,string>, ?expand: string list, ?invoiceItems: CreatePreview'InvoiceItems list, ?issuer: CreatePreview'Issuer, ?onBehalfOf: Choice<string,string>, ?previewMode: CreatePreview'PreviewMode, ?schedule: string, ?scheduleDetails: CreatePreview'ScheduleDetails, ?subscription: string, ?subscriptionDetails: CreatePreview'SubscriptionDetails) =
            {
                AutomaticTax = automaticTax
                Currency = currency
                Customer = customer
                CustomerAccount = customerAccount
                CustomerDetails = customerDetails
                Discounts = discounts
                Expand = expand
                InvoiceItems = invoiceItems
                Issuer = issuer
                OnBehalfOf = onBehalfOf
                PreviewMode = previewMode
                Schedule = schedule
                ScheduleDetails = scheduleDetails
                Subscription = subscription
                SubscriptionDetails = subscriptionDetails
            }

    ///<p>At any time, you can preview the upcoming invoice for a subscription or subscription schedule. This will show you all the charges that are pending, including subscription renewal charges, invoice item charges, etc. It will also show you any discounts that are applicable to the invoice.</p>
    ///<p>You can also preview the effects of creating or updating a subscription or subscription schedule, including a preview of any prorations that will take place. To ensure that the actual proration is calculated exactly the same as the previewed proration, you should pass the <code>subscription_details.proration_date</code> parameter when doing the actual subscription update.</p>
    ///<p>The recommended way to get only the prorations being previewed on the invoice is to consider line items where <code>parent.subscription_item_details.proration</code> is <code>true</code>.</p>
    ///<p>Note that when you are viewing an upcoming invoice, you are simply viewing a preview – the invoice has not yet been created. As such, the upcoming invoice will not show up in invoice listing calls, and you cannot use the API to pay or edit the invoice. If you want to change the amount that your customer will be billed, you can add, remove, or update pending invoice items, or update the customer’s discount.</p>
    ///<p>Note: Currency conversion calculations use the latest exchange rates. Exchange rates may vary between the time of the preview and the time of the actual invoice creation. <a href="https://docs.stripe.com/currencies/conversions">Learn more</a></p>
    let CreatePreview settings (options: CreatePreviewOptions) =
        $"/v1/invoices/create_preview"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesSearch =

    type SearchOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for pagination across multiple pages of results. Don't include this parameter on the first call. Use the next_page value returned in a previous response to request subsequent results.
            [<Config.Query>]
            Page: string option
            /// The search query string. See [search query language](https://docs.stripe.com/search#search-query-language) and the list of supported [query fields for invoices](https://docs.stripe.com/search#query-fields-for-invoices).
            [<Config.Query>]
            Query: string
        }

    type SearchOptions with
        static member New(query: string, ?expand: string list, ?limit: int, ?page: string) =
            {
                Query = query
                Expand = expand
                Limit = limit
                Page = page
            }

    ///<p>Search for invoices you’ve previously created using Stripe’s <a href="/docs/search#search-query-language">Search Query Language</a>.
    ///Don’t use search in read-after-write flows where strict consistency is necessary. Under normal operating
    ///conditions, data is searchable in less than a minute. Occasionally, propagation of new or updated data can be up
    ///to an hour behind during outages. Search functionality is not available to merchants in India.</p>
    let Search settings (options: SearchOptions) =
        let qs = [("expand", options.Expand |> box); ("limit", options.Limit |> box); ("page", options.Page |> box); ("query", options.Query |> box)] |> Map.ofList
        $"/v1/invoices/search"
        |> RestApi.getAsync<StripeList<Invoice>> settings qs

module InvoicesAddLines =

    type AddLines'LinesDiscounts =
        {
            /// ID of the coupon to create a new discount for.
            [<Config.Form>]
            Coupon: string option
            /// ID of an existing discount on the object (or one of its ancestors) to reuse.
            [<Config.Form>]
            Discount: string option
            /// ID of the promotion code to create a new discount for.
            [<Config.Form>]
            PromotionCode: string option
        }

    type AddLines'LinesDiscounts with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type AddLines'LinesPeriod =
        {
            /// The end of the period, which must be greater than or equal to the start. This value is inclusive.
            [<Config.Form>]
            End: DateTime option
            /// The start of the period. This value is inclusive.
            [<Config.Form>]
            Start: DateTime option
        }

    type AddLines'LinesPeriod with
        static member New(?end': DateTime, ?start: DateTime) =
            {
                End = end'
                Start = start
            }

    type AddLines'LinesPriceDataProductData =
        {
            /// The product's description, meant to be displayable to the customer. Use this field to optionally store a long form explanation of the product being sold for your own rendering purposes.
            [<Config.Form>]
            Description: string option
            /// A list of up to 8 URLs of images for this product, meant to be displayable to the customer.
            [<Config.Form>]
            Images: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The product's name, meant to be displayable to the customer.
            [<Config.Form>]
            Name: string option
            /// A [tax code](https://docs.stripe.com/tax/tax-categories) ID.
            [<Config.Form>]
            TaxCode: string option
            /// A label that represents units of this product. When set, this will be included in customers' receipts, invoices, Checkout, and the customer portal.
            [<Config.Form>]
            UnitLabel: string option
        }

    type AddLines'LinesPriceDataProductData with
        static member New(?description: string, ?images: string list, ?metadata: Map<string, string>, ?name: string, ?taxCode: string, ?unitLabel: string) =
            {
                Description = description
                Images = images
                Metadata = metadata
                Name = name
                TaxCode = taxCode
                UnitLabel = unitLabel
            }

    type AddLines'LinesPriceDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type AddLines'LinesPriceData =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to. One of `product` or `product_data` is required.
            [<Config.Form>]
            Product: string option
            /// Data used to generate a new [Product](https://docs.stripe.com/api/products) object inline. One of `product` or `product_data` is required.
            [<Config.Form>]
            ProductData: AddLines'LinesPriceDataProductData option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: AddLines'LinesPriceDataTaxBehavior option
            /// A non-negative integer in cents (or local equivalent) representing how much to charge. One of `unit_amount` or `unit_amount_decimal` is required.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    type AddLines'LinesPriceData with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?productData: AddLines'LinesPriceDataProductData, ?taxBehavior: AddLines'LinesPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                ProductData = productData
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type AddLines'LinesPricing =
        {
            /// The ID of the price object.
            [<Config.Form>]
            Price: string option
        }

    type AddLines'LinesPricing with
        static member New(?price: string) =
            {
                Price = price
            }

    type AddLines'LinesTaxAmountsTaxRateDataJurisdictionLevel =
        | City
        | Country
        | County
        | District
        | Multiple
        | State

    type AddLines'LinesTaxAmountsTaxRateDataTaxType =
        | AmusementTax
        | CommunicationsTax
        | Gst
        | Hst
        | Igst
        | Jct
        | LeaseTax
        | Pst
        | Qst
        | RetailDeliveryFee
        | Rst
        | SalesTax
        | ServiceTax
        | Vat

    type AddLines'LinesTaxAmountsTaxRateData =
        {
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// An arbitrary string attached to the tax rate for your internal use only. It will not be visible to your customers.
            [<Config.Form>]
            Description: string option
            /// The display name of the tax rate, which will be shown to users.
            [<Config.Form>]
            DisplayName: string option
            /// This specifies if the tax rate is inclusive or exclusive.
            [<Config.Form>]
            Inclusive: bool option
            /// The jurisdiction for the tax rate. You can use this label field for tax reporting purposes. It also appears on your customer’s invoice.
            [<Config.Form>]
            Jurisdiction: string option
            /// The level of the jurisdiction that imposes this tax rate.
            [<Config.Form>]
            JurisdictionLevel: AddLines'LinesTaxAmountsTaxRateDataJurisdictionLevel option
            /// The statutory tax rate percent. This field accepts decimal values between 0 and 100 inclusive with at most 4 decimal places. To accommodate fixed-amount taxes, set the percentage to zero. Stripe will not display zero percentages on the invoice unless the `amount` of the tax is also zero.
            [<Config.Form>]
            Percentage: decimal option
            /// [ISO 3166-2 subdivision code](https://en.wikipedia.org/wiki/ISO_3166-2:US), without country prefix. For example, "NY" for New York, United States.
            [<Config.Form>]
            State: string option
            /// The high-level tax type, such as `vat` or `sales_tax`.
            [<Config.Form>]
            TaxType: AddLines'LinesTaxAmountsTaxRateDataTaxType option
        }

    type AddLines'LinesTaxAmountsTaxRateData with
        static member New(?country: IsoTypes.IsoCountryCode, ?description: string, ?displayName: string, ?inclusive: bool, ?jurisdiction: string, ?jurisdictionLevel: AddLines'LinesTaxAmountsTaxRateDataJurisdictionLevel, ?percentage: decimal, ?state: string, ?taxType: AddLines'LinesTaxAmountsTaxRateDataTaxType) =
            {
                Country = country
                Description = description
                DisplayName = displayName
                Inclusive = inclusive
                Jurisdiction = jurisdiction
                JurisdictionLevel = jurisdictionLevel
                Percentage = percentage
                State = state
                TaxType = taxType
            }

    type AddLines'LinesTaxAmountsTaxabilityReason =
        | CustomerExempt
        | NotCollecting
        | NotSubjectToTax
        | NotSupported
        | PortionProductExempt
        | PortionReducedRated
        | PortionStandardRated
        | ProductExempt
        | ProductExemptHoliday
        | ProportionallyRated
        | ReducedRated
        | ReverseCharge
        | StandardRated
        | TaxableBasisReduced
        | ZeroRated

    type AddLines'LinesTaxAmounts =
        {
            /// The amount, in cents (or local equivalent), of the tax.
            [<Config.Form>]
            Amount: int option
            /// Data to find or create a TaxRate object.
            /// Stripe automatically creates or reuses a TaxRate object for each tax amount. If the `tax_rate_data` exactly matches a previous value, Stripe will reuse the TaxRate object. TaxRate objects created automatically by Stripe are immediately archived, do not appear in the line item’s `tax_rates`, and cannot be directly added to invoices, payments, or line items.
            [<Config.Form>]
            TaxRateData: AddLines'LinesTaxAmountsTaxRateData option
            /// The reasoning behind this tax, for example, if the product is tax exempt.
            [<Config.Form>]
            TaxabilityReason: AddLines'LinesTaxAmountsTaxabilityReason option
            /// The amount on which tax is calculated, in cents (or local equivalent).
            [<Config.Form>]
            TaxableAmount: int option
        }

    type AddLines'LinesTaxAmounts with
        static member New(?amount: int, ?taxRateData: AddLines'LinesTaxAmountsTaxRateData, ?taxabilityReason: AddLines'LinesTaxAmountsTaxabilityReason, ?taxableAmount: int) =
            {
                Amount = amount
                TaxRateData = taxRateData
                TaxabilityReason = taxabilityReason
                TaxableAmount = taxableAmount
            }

    type AddLines'Lines =
        {
            /// The integer amount in cents (or local equivalent) of the charge to be applied to the upcoming invoice. If you want to apply a credit to the customer's account, pass a negative amount.
            [<Config.Form>]
            Amount: int option
            /// An arbitrary string which you can attach to the invoice item. The description is displayed in the invoice for easy tracking.
            [<Config.Form>]
            Description: string option
            /// Controls whether discounts apply to this line item. Defaults to false for prorations or negative line items, and true for all other line items. Cannot be set to true for prorations.
            [<Config.Form>]
            Discountable: bool option
            /// The coupons, promotion codes & existing discounts which apply to the line item. Item discounts are applied before invoice discounts. Pass an empty string to remove previously-defined discounts.
            [<Config.Form>]
            Discounts: Choice<AddLines'LinesDiscounts list,string> option
            /// ID of an unassigned invoice item to assign to this invoice. If not provided, a new item will be created.
            [<Config.Form>]
            InvoiceItem: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The period associated with this invoice item. When set to different values, the period will be rendered on the invoice. If you have [Stripe Revenue Recognition](https://docs.stripe.com/revenue-recognition) enabled, the period will be used to recognize and defer revenue. See the [Revenue Recognition documentation](https://docs.stripe.com/revenue-recognition/methodology/subscriptions-and-invoicing) for details.
            [<Config.Form>]
            Period: AddLines'LinesPeriod option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline.
            [<Config.Form>]
            PriceData: AddLines'LinesPriceData option
            /// The pricing information for the invoice item.
            [<Config.Form>]
            Pricing: AddLines'LinesPricing option
            /// Non-negative integer. The quantity of units for the line item. Use `quantity_decimal` instead to provide decimal precision. This field will be deprecated in favor of `quantity_decimal` in a future version.
            [<Config.Form>]
            Quantity: int option
            /// Non-negative decimal with at most 12 decimal places. The quantity of units for the line item.
            [<Config.Form>]
            QuantityDecimal: string option
            /// A list of up to 10 tax amounts for this line item. This can be useful if you calculate taxes on your own or use a third-party to calculate them. You cannot set tax amounts if any line item has [tax_rates](https://docs.stripe.com/api/invoices/line_item#invoice_line_item_object-tax_rates) or if the invoice has [default_tax_rates](https://docs.stripe.com/api/invoices/object#invoice_object-default_tax_rates) or uses [automatic tax](https://docs.stripe.com/tax/invoicing). Pass an empty string to remove previously defined tax amounts.
            [<Config.Form>]
            TaxAmounts: Choice<AddLines'LinesTaxAmounts list,string> option
            /// The tax rates which apply to the line item. When set, the `default_tax_rates` on the invoice do not apply to this line item. Pass an empty string to remove previously-defined tax rates.
            [<Config.Form>]
            TaxRates: Choice<string list,string> option
        }

    type AddLines'Lines with
        static member New(?amount: int, ?description: string, ?discountable: bool, ?discounts: Choice<AddLines'LinesDiscounts list,string>, ?invoiceItem: string, ?metadata: Map<string, string>, ?period: AddLines'LinesPeriod, ?priceData: AddLines'LinesPriceData, ?pricing: AddLines'LinesPricing, ?quantity: int, ?quantityDecimal: string, ?taxAmounts: Choice<AddLines'LinesTaxAmounts list,string>, ?taxRates: Choice<string list,string>) =
            {
                Amount = amount
                Description = description
                Discountable = discountable
                Discounts = discounts
                InvoiceItem = invoiceItem
                Metadata = metadata
                Period = period
                PriceData = priceData
                Pricing = pricing
                Quantity = quantity
                QuantityDecimal = quantityDecimal
                TaxAmounts = taxAmounts
                TaxRates = taxRates
            }

    type AddLinesOptions =
        {
            [<Config.Path>]
            Invoice: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            InvoiceMetadata: Choice<Map<string, string>,string> option
            /// The line items to add.
            [<Config.Form>]
            Lines: AddLines'Lines list
        }

    type AddLinesOptions with
        static member New(invoice: string, lines: AddLines'Lines list, ?expand: string list, ?invoiceMetadata: Choice<Map<string, string>,string>) =
            {
                Invoice = invoice
                Lines = lines
                Expand = expand
                InvoiceMetadata = invoiceMetadata
            }

    ///<p>Adds multiple line items to an invoice. This is only possible when an invoice is still a draft.</p>
    let AddLines settings (options: AddLinesOptions) =
        $"/v1/invoices/{options.Invoice}/add_lines"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesAttachPayment =

    type AttachPaymentOptions =
        {
            [<Config.Path>]
            Invoice: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The ID of the PaymentIntent to attach to the invoice.
            [<Config.Form>]
            PaymentIntent: string option
            /// The ID of the PaymentRecord to attach to the invoice.
            [<Config.Form>]
            PaymentRecord: string option
        }

    type AttachPaymentOptions with
        static member New(invoice: string, ?expand: string list, ?paymentIntent: string, ?paymentRecord: string) =
            {
                Invoice = invoice
                Expand = expand
                PaymentIntent = paymentIntent
                PaymentRecord = paymentRecord
            }

    ///<p>Attaches a PaymentIntent or an Out of Band Payment to the invoice, adding it to the list of <code>payments</code>.</p>
    ///<p>For the PaymentIntent, when the PaymentIntent’s status changes to <code>succeeded</code>, the payment is credited
    ///to the invoice, increasing its <code>amount_paid</code>. When the invoice is fully paid, the
    ///invoice’s status becomes <code>paid</code>.</p>
    ///<p>If the PaymentIntent’s status is already <code>succeeded</code> when it’s attached, it’s
    ///credited to the invoice immediately.</p>
    ///<p>See: <a href="/docs/invoicing/partial-payments">Partial payments</a> to learn more.</p>
    let AttachPayment settings (options: AttachPaymentOptions) =
        $"/v1/invoices/{options.Invoice}/attach_payment"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesFinalize =

    type FinalizeInvoiceOptions =
        {
            [<Config.Path>]
            Invoice: string
            /// Controls whether Stripe performs [automatic collection](https://docs.stripe.com/invoicing/integration/automatic-advancement-collection) of the invoice. If `false`, the invoice's state doesn't automatically advance without an explicit action.
            [<Config.Form>]
            AutoAdvance: bool option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type FinalizeInvoiceOptions with
        static member New(invoice: string, ?autoAdvance: bool, ?expand: string list) =
            {
                Invoice = invoice
                AutoAdvance = autoAdvance
                Expand = expand
            }

    ///<p>Stripe automatically finalizes drafts before sending and attempting payment on invoices. However, if you’d like to finalize a draft invoice manually, you can do so using this method.</p>
    let FinalizeInvoice settings (options: FinalizeInvoiceOptions) =
        $"/v1/invoices/{options.Invoice}/finalize"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesLines =

    type ListOptions =
        {
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Invoice: string
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    type ListOptions with
        static member New(invoice: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Invoice = invoice
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    type Update'Discounts =
        {
            /// ID of the coupon to create a new discount for.
            [<Config.Form>]
            Coupon: string option
            /// ID of an existing discount on the object (or one of its ancestors) to reuse.
            [<Config.Form>]
            Discount: string option
            /// ID of the promotion code to create a new discount for.
            [<Config.Form>]
            PromotionCode: string option
        }

    type Update'Discounts with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Update'Period =
        {
            /// The end of the period, which must be greater than or equal to the start. This value is inclusive.
            [<Config.Form>]
            End: DateTime option
            /// The start of the period. This value is inclusive.
            [<Config.Form>]
            Start: DateTime option
        }

    type Update'Period with
        static member New(?end': DateTime, ?start: DateTime) =
            {
                End = end'
                Start = start
            }

    type Update'PriceDataProductData =
        {
            /// The product's description, meant to be displayable to the customer. Use this field to optionally store a long form explanation of the product being sold for your own rendering purposes.
            [<Config.Form>]
            Description: string option
            /// A list of up to 8 URLs of images for this product, meant to be displayable to the customer.
            [<Config.Form>]
            Images: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The product's name, meant to be displayable to the customer.
            [<Config.Form>]
            Name: string option
            /// A [tax code](https://docs.stripe.com/tax/tax-categories) ID.
            [<Config.Form>]
            TaxCode: string option
            /// A label that represents units of this product. When set, this will be included in customers' receipts, invoices, Checkout, and the customer portal.
            [<Config.Form>]
            UnitLabel: string option
        }

    type Update'PriceDataProductData with
        static member New(?description: string, ?images: string list, ?metadata: Map<string, string>, ?name: string, ?taxCode: string, ?unitLabel: string) =
            {
                Description = description
                Images = images
                Metadata = metadata
                Name = name
                TaxCode = taxCode
                UnitLabel = unitLabel
            }

    type Update'PriceDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type Update'PriceData =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to. One of `product` or `product_data` is required.
            [<Config.Form>]
            Product: string option
            /// Data used to generate a new [Product](https://docs.stripe.com/api/products) object inline. One of `product` or `product_data` is required.
            [<Config.Form>]
            ProductData: Update'PriceDataProductData option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: Update'PriceDataTaxBehavior option
            /// A non-negative integer in cents (or local equivalent) representing how much to charge. One of `unit_amount` or `unit_amount_decimal` is required.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    type Update'PriceData with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?productData: Update'PriceDataProductData, ?taxBehavior: Update'PriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                ProductData = productData
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Update'Pricing =
        {
            /// The ID of the price object.
            [<Config.Form>]
            Price: string option
        }

    type Update'Pricing with
        static member New(?price: string) =
            {
                Price = price
            }

    type Update'TaxAmountsTaxRateDataJurisdictionLevel =
        | City
        | Country
        | County
        | District
        | Multiple
        | State

    type Update'TaxAmountsTaxRateDataTaxType =
        | AmusementTax
        | CommunicationsTax
        | Gst
        | Hst
        | Igst
        | Jct
        | LeaseTax
        | Pst
        | Qst
        | RetailDeliveryFee
        | Rst
        | SalesTax
        | ServiceTax
        | Vat

    type Update'TaxAmountsTaxRateData =
        {
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// An arbitrary string attached to the tax rate for your internal use only. It will not be visible to your customers.
            [<Config.Form>]
            Description: string option
            /// The display name of the tax rate, which will be shown to users.
            [<Config.Form>]
            DisplayName: string option
            /// This specifies if the tax rate is inclusive or exclusive.
            [<Config.Form>]
            Inclusive: bool option
            /// The jurisdiction for the tax rate. You can use this label field for tax reporting purposes. It also appears on your customer’s invoice.
            [<Config.Form>]
            Jurisdiction: string option
            /// The level of the jurisdiction that imposes this tax rate.
            [<Config.Form>]
            JurisdictionLevel: Update'TaxAmountsTaxRateDataJurisdictionLevel option
            /// The statutory tax rate percent. This field accepts decimal values between 0 and 100 inclusive with at most 4 decimal places. To accommodate fixed-amount taxes, set the percentage to zero. Stripe will not display zero percentages on the invoice unless the `amount` of the tax is also zero.
            [<Config.Form>]
            Percentage: decimal option
            /// [ISO 3166-2 subdivision code](https://en.wikipedia.org/wiki/ISO_3166-2:US), without country prefix. For example, "NY" for New York, United States.
            [<Config.Form>]
            State: string option
            /// The high-level tax type, such as `vat` or `sales_tax`.
            [<Config.Form>]
            TaxType: Update'TaxAmountsTaxRateDataTaxType option
        }

    type Update'TaxAmountsTaxRateData with
        static member New(?country: IsoTypes.IsoCountryCode, ?description: string, ?displayName: string, ?inclusive: bool, ?jurisdiction: string, ?jurisdictionLevel: Update'TaxAmountsTaxRateDataJurisdictionLevel, ?percentage: decimal, ?state: string, ?taxType: Update'TaxAmountsTaxRateDataTaxType) =
            {
                Country = country
                Description = description
                DisplayName = displayName
                Inclusive = inclusive
                Jurisdiction = jurisdiction
                JurisdictionLevel = jurisdictionLevel
                Percentage = percentage
                State = state
                TaxType = taxType
            }

    type Update'TaxAmountsTaxabilityReason =
        | CustomerExempt
        | NotCollecting
        | NotSubjectToTax
        | NotSupported
        | PortionProductExempt
        | PortionReducedRated
        | PortionStandardRated
        | ProductExempt
        | ProductExemptHoliday
        | ProportionallyRated
        | ReducedRated
        | ReverseCharge
        | StandardRated
        | TaxableBasisReduced
        | ZeroRated

    type Update'TaxAmounts =
        {
            /// The amount, in cents (or local equivalent), of the tax.
            [<Config.Form>]
            Amount: int option
            /// Data to find or create a TaxRate object.
            /// Stripe automatically creates or reuses a TaxRate object for each tax amount. If the `tax_rate_data` exactly matches a previous value, Stripe will reuse the TaxRate object. TaxRate objects created automatically by Stripe are immediately archived, do not appear in the line item’s `tax_rates`, and cannot be directly added to invoices, payments, or line items.
            [<Config.Form>]
            TaxRateData: Update'TaxAmountsTaxRateData option
            /// The reasoning behind this tax, for example, if the product is tax exempt.
            [<Config.Form>]
            TaxabilityReason: Update'TaxAmountsTaxabilityReason option
            /// The amount on which tax is calculated, in cents (or local equivalent).
            [<Config.Form>]
            TaxableAmount: int option
        }

    type Update'TaxAmounts with
        static member New(?amount: int, ?taxRateData: Update'TaxAmountsTaxRateData, ?taxabilityReason: Update'TaxAmountsTaxabilityReason, ?taxableAmount: int) =
            {
                Amount = amount
                TaxRateData = taxRateData
                TaxabilityReason = taxabilityReason
                TaxableAmount = taxableAmount
            }

    type UpdateOptions =
        {
            /// Invoice ID of line item
            [<Config.Path>]
            Invoice: string
            /// Invoice line item ID
            [<Config.Path>]
            LineItemId: string
            /// The integer amount in cents (or local equivalent) of the charge to be applied to the upcoming invoice. If you want to apply a credit to the customer's account, pass a negative amount.
            [<Config.Form>]
            Amount: int option
            /// An arbitrary string which you can attach to the invoice item. The description is displayed in the invoice for easy tracking.
            [<Config.Form>]
            Description: string option
            /// Controls whether discounts apply to this line item. Defaults to false for prorations or negative line items, and true for all other line items. Cannot be set to true for prorations.
            [<Config.Form>]
            Discountable: bool option
            /// The coupons, promotion codes & existing discounts which apply to the line item. Item discounts are applied before invoice discounts. Pass an empty string to remove previously-defined discounts.
            [<Config.Form>]
            Discounts: Choice<Update'Discounts list,string> option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`. For [type=subscription](/api/invoices/line_item) line items, the incoming metadata specified on the request is directly used to set this value, in contrast to [type=invoiceitem](/api/invoices/line_item) line items, where any existing metadata on the invoice line is merged with the incoming data.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The period associated with this invoice item. When set to different values, the period will be rendered on the invoice. If you have [Stripe Revenue Recognition](https://docs.stripe.com/revenue-recognition) enabled, the period will be used to recognize and defer revenue. See the [Revenue Recognition documentation](https://docs.stripe.com/revenue-recognition/methodology/subscriptions-and-invoicing) for details.
            [<Config.Form>]
            Period: Update'Period option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline.
            [<Config.Form>]
            PriceData: Update'PriceData option
            /// The pricing information for the invoice item.
            [<Config.Form>]
            Pricing: Update'Pricing option
            /// Non-negative integer. The quantity of units for the line item. Use `quantity_decimal` instead to provide decimal precision. This field will be deprecated in favor of `quantity_decimal` in a future version.
            [<Config.Form>]
            Quantity: int option
            /// Non-negative decimal with at most 12 decimal places. The quantity of units for the line item.
            [<Config.Form>]
            QuantityDecimal: string option
            /// A list of up to 10 tax amounts for this line item. This can be useful if you calculate taxes on your own or use a third-party to calculate them. You cannot set tax amounts if any line item has [tax_rates](https://docs.stripe.com/api/invoices/line_item#invoice_line_item_object-tax_rates) or if the invoice has [default_tax_rates](https://docs.stripe.com/api/invoices/object#invoice_object-default_tax_rates) or uses [automatic tax](https://docs.stripe.com/tax/invoicing). Pass an empty string to remove previously defined tax amounts.
            [<Config.Form>]
            TaxAmounts: Choice<Update'TaxAmounts list,string> option
            /// The tax rates which apply to the line item. When set, the `default_tax_rates` on the invoice do not apply to this line item. Pass an empty string to remove previously-defined tax rates.
            [<Config.Form>]
            TaxRates: Choice<string list,string> option
        }

    type UpdateOptions with
        static member New(invoice: string, lineItemId: string, ?amount: int, ?description: string, ?discountable: bool, ?discounts: Choice<Update'Discounts list,string>, ?expand: string list, ?metadata: Map<string, string>, ?period: Update'Period, ?priceData: Update'PriceData, ?pricing: Update'Pricing, ?quantity: int, ?quantityDecimal: string, ?taxAmounts: Choice<Update'TaxAmounts list,string>, ?taxRates: Choice<string list,string>) =
            {
                Invoice = invoice
                LineItemId = lineItemId
                Amount = amount
                Description = description
                Discountable = discountable
                Discounts = discounts
                Expand = expand
                Metadata = metadata
                Period = period
                PriceData = priceData
                Pricing = pricing
                Quantity = quantity
                QuantityDecimal = quantityDecimal
                TaxAmounts = taxAmounts
                TaxRates = taxRates
            }

    ///<p>When retrieving an invoice, you’ll get a <strong>lines</strong> property containing the total count of line items and the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/invoices/{options.Invoice}/lines"
        |> RestApi.getAsync<StripeList<LineItem>> settings qs

    ///<p>Updates an invoice’s line item. Some fields, such as <code>tax_amounts</code>, only live on the invoice line item,
    ///so they can only be updated through this endpoint. Other fields, such as <code>amount</code>, live on both the invoice
    ///item and the invoice line item, so updates on this endpoint will propagate to the invoice item as well.
    ///Updating an invoice’s line item is only possible before the invoice is finalized.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/invoices/{options.Invoice}/lines/{options.LineItemId}"
        |> RestApi.postAsync<_, LineItem> settings (Map.empty) options

module InvoicesMarkUncollectible =

    type MarkUncollectibleOptions =
        {
            [<Config.Path>]
            Invoice: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type MarkUncollectibleOptions with
        static member New(invoice: string, ?expand: string list) =
            {
                Invoice = invoice
                Expand = expand
            }

    ///<p>Marking an invoice as uncollectible is useful for keeping track of bad debts that can be written off for accounting purposes.</p>
    let MarkUncollectible settings (options: MarkUncollectibleOptions) =
        $"/v1/invoices/{options.Invoice}/mark_uncollectible"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesPay =

    type PayOptions =
        {
            [<Config.Path>]
            Invoice: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// In cases where the source used to pay the invoice has insufficient funds, passing `forgive=true` controls whether a charge should be attempted for the full amount available on the source, up to the amount to fully pay the invoice. This effectively forgives the difference between the amount available on the source and the amount due.
            /// Passing `forgive=false` will fail the charge if the source hasn't been pre-funded with the right amount. An example for this case is with ACH Credit Transfers and wires: if the amount wired is less than the amount due by a small amount, you might want to forgive the difference. Defaults to `false`.
            [<Config.Form>]
            Forgive: bool option
            /// ID of the mandate to be used for this invoice. It must correspond to the payment method used to pay the invoice, including the payment_method param or the invoice's default_payment_method or default_source, if set.
            [<Config.Form>]
            Mandate: Choice<string,string> option
            /// Indicates if a customer is on or off-session while an invoice payment is attempted. Defaults to `true` (off-session).
            [<Config.Form>]
            OffSession: bool option
            /// Boolean representing whether an invoice is paid outside of Stripe. This will result in no charge being made. Defaults to `false`.
            [<Config.Form>]
            PaidOutOfBand: bool option
            /// A PaymentMethod to be charged. The PaymentMethod must be the ID of a PaymentMethod belonging to the customer associated with the invoice being paid.
            [<Config.Form>]
            PaymentMethod: string option
            /// A payment source to be charged. The source must be the ID of a source belonging to the customer associated with the invoice being paid.
            [<Config.Form>]
            Source: string option
        }

    type PayOptions with
        static member New(invoice: string, ?expand: string list, ?forgive: bool, ?mandate: Choice<string,string>, ?offSession: bool, ?paidOutOfBand: bool, ?paymentMethod: string, ?source: string) =
            {
                Invoice = invoice
                Expand = expand
                Forgive = forgive
                Mandate = mandate
                OffSession = offSession
                PaidOutOfBand = paidOutOfBand
                PaymentMethod = paymentMethod
                Source = source
            }

    ///<p>Stripe automatically creates and then attempts to collect payment on invoices for customers on subscriptions according to your <a href="https://dashboard.stripe.com/account/billing/automatic">subscriptions settings</a>. However, if you’d like to attempt payment on an invoice out of the normal collection schedule or for some other reason, you can do so.</p>
    let Pay settings (options: PayOptions) =
        $"/v1/invoices/{options.Invoice}/pay"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesRemoveLines =

    type RemoveLines'LinesBehavior =
        | Delete
        | Unassign

    type RemoveLines'Lines =
        {
            /// Either `delete` or `unassign`. Deleted line items are permanently deleted. Unassigned line items can be reassigned to an invoice.
            [<Config.Form>]
            Behavior: RemoveLines'LinesBehavior option
            /// ID of an existing line item to remove from this invoice.
            [<Config.Form>]
            Id: string option
        }

    type RemoveLines'Lines with
        static member New(?behavior: RemoveLines'LinesBehavior, ?id: string) =
            {
                Behavior = behavior
                Id = id
            }

    type RemoveLinesOptions =
        {
            [<Config.Path>]
            Invoice: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            InvoiceMetadata: Choice<Map<string, string>,string> option
            /// The line items to remove.
            [<Config.Form>]
            Lines: RemoveLines'Lines list
        }

    type RemoveLinesOptions with
        static member New(invoice: string, lines: RemoveLines'Lines list, ?expand: string list, ?invoiceMetadata: Choice<Map<string, string>,string>) =
            {
                Invoice = invoice
                Lines = lines
                Expand = expand
                InvoiceMetadata = invoiceMetadata
            }

    ///<p>Removes multiple line items from an invoice. This is only possible when an invoice is still a draft.</p>
    let RemoveLines settings (options: RemoveLinesOptions) =
        $"/v1/invoices/{options.Invoice}/remove_lines"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesSend =

    type SendInvoiceOptions =
        {
            [<Config.Path>]
            Invoice: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type SendInvoiceOptions with
        static member New(invoice: string, ?expand: string list) =
            {
                Invoice = invoice
                Expand = expand
            }

    ///<p>Stripe will automatically send invoices to customers according to your <a href="https://dashboard.stripe.com/account/billing/automatic">subscriptions settings</a>. However, if you’d like to manually send an invoice to your customer out of the normal schedule, you can do so. When sending invoices that have already been paid, there will be no reference to the payment in the email.</p>
    ///<p>Requests made in test-mode result in no emails being sent, despite sending an <code>invoice.sent</code> event.</p>
    let SendInvoice settings (options: SendInvoiceOptions) =
        $"/v1/invoices/{options.Invoice}/send"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesUpdateLines =

    type UpdateLines'LinesDiscounts =
        {
            /// ID of the coupon to create a new discount for.
            [<Config.Form>]
            Coupon: string option
            /// ID of an existing discount on the object (or one of its ancestors) to reuse.
            [<Config.Form>]
            Discount: string option
            /// ID of the promotion code to create a new discount for.
            [<Config.Form>]
            PromotionCode: string option
        }

    type UpdateLines'LinesDiscounts with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type UpdateLines'LinesPeriod =
        {
            /// The end of the period, which must be greater than or equal to the start. This value is inclusive.
            [<Config.Form>]
            End: DateTime option
            /// The start of the period. This value is inclusive.
            [<Config.Form>]
            Start: DateTime option
        }

    type UpdateLines'LinesPeriod with
        static member New(?end': DateTime, ?start: DateTime) =
            {
                End = end'
                Start = start
            }

    type UpdateLines'LinesPriceDataProductData =
        {
            /// The product's description, meant to be displayable to the customer. Use this field to optionally store a long form explanation of the product being sold for your own rendering purposes.
            [<Config.Form>]
            Description: string option
            /// A list of up to 8 URLs of images for this product, meant to be displayable to the customer.
            [<Config.Form>]
            Images: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The product's name, meant to be displayable to the customer.
            [<Config.Form>]
            Name: string option
            /// A [tax code](https://docs.stripe.com/tax/tax-categories) ID.
            [<Config.Form>]
            TaxCode: string option
            /// A label that represents units of this product. When set, this will be included in customers' receipts, invoices, Checkout, and the customer portal.
            [<Config.Form>]
            UnitLabel: string option
        }

    type UpdateLines'LinesPriceDataProductData with
        static member New(?description: string, ?images: string list, ?metadata: Map<string, string>, ?name: string, ?taxCode: string, ?unitLabel: string) =
            {
                Description = description
                Images = images
                Metadata = metadata
                Name = name
                TaxCode = taxCode
                UnitLabel = unitLabel
            }

    type UpdateLines'LinesPriceDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type UpdateLines'LinesPriceData =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to. One of `product` or `product_data` is required.
            [<Config.Form>]
            Product: string option
            /// Data used to generate a new [Product](https://docs.stripe.com/api/products) object inline. One of `product` or `product_data` is required.
            [<Config.Form>]
            ProductData: UpdateLines'LinesPriceDataProductData option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: UpdateLines'LinesPriceDataTaxBehavior option
            /// A non-negative integer in cents (or local equivalent) representing how much to charge. One of `unit_amount` or `unit_amount_decimal` is required.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    type UpdateLines'LinesPriceData with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?productData: UpdateLines'LinesPriceDataProductData, ?taxBehavior: UpdateLines'LinesPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                ProductData = productData
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type UpdateLines'LinesPricing =
        {
            /// The ID of the price object.
            [<Config.Form>]
            Price: string option
        }

    type UpdateLines'LinesPricing with
        static member New(?price: string) =
            {
                Price = price
            }

    type UpdateLines'LinesTaxAmountsTaxRateDataJurisdictionLevel =
        | City
        | Country
        | County
        | District
        | Multiple
        | State

    type UpdateLines'LinesTaxAmountsTaxRateDataTaxType =
        | AmusementTax
        | CommunicationsTax
        | Gst
        | Hst
        | Igst
        | Jct
        | LeaseTax
        | Pst
        | Qst
        | RetailDeliveryFee
        | Rst
        | SalesTax
        | ServiceTax
        | Vat

    type UpdateLines'LinesTaxAmountsTaxRateData =
        {
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// An arbitrary string attached to the tax rate for your internal use only. It will not be visible to your customers.
            [<Config.Form>]
            Description: string option
            /// The display name of the tax rate, which will be shown to users.
            [<Config.Form>]
            DisplayName: string option
            /// This specifies if the tax rate is inclusive or exclusive.
            [<Config.Form>]
            Inclusive: bool option
            /// The jurisdiction for the tax rate. You can use this label field for tax reporting purposes. It also appears on your customer’s invoice.
            [<Config.Form>]
            Jurisdiction: string option
            /// The level of the jurisdiction that imposes this tax rate.
            [<Config.Form>]
            JurisdictionLevel: UpdateLines'LinesTaxAmountsTaxRateDataJurisdictionLevel option
            /// The statutory tax rate percent. This field accepts decimal values between 0 and 100 inclusive with at most 4 decimal places. To accommodate fixed-amount taxes, set the percentage to zero. Stripe will not display zero percentages on the invoice unless the `amount` of the tax is also zero.
            [<Config.Form>]
            Percentage: decimal option
            /// [ISO 3166-2 subdivision code](https://en.wikipedia.org/wiki/ISO_3166-2:US), without country prefix. For example, "NY" for New York, United States.
            [<Config.Form>]
            State: string option
            /// The high-level tax type, such as `vat` or `sales_tax`.
            [<Config.Form>]
            TaxType: UpdateLines'LinesTaxAmountsTaxRateDataTaxType option
        }

    type UpdateLines'LinesTaxAmountsTaxRateData with
        static member New(?country: IsoTypes.IsoCountryCode, ?description: string, ?displayName: string, ?inclusive: bool, ?jurisdiction: string, ?jurisdictionLevel: UpdateLines'LinesTaxAmountsTaxRateDataJurisdictionLevel, ?percentage: decimal, ?state: string, ?taxType: UpdateLines'LinesTaxAmountsTaxRateDataTaxType) =
            {
                Country = country
                Description = description
                DisplayName = displayName
                Inclusive = inclusive
                Jurisdiction = jurisdiction
                JurisdictionLevel = jurisdictionLevel
                Percentage = percentage
                State = state
                TaxType = taxType
            }

    type UpdateLines'LinesTaxAmountsTaxabilityReason =
        | CustomerExempt
        | NotCollecting
        | NotSubjectToTax
        | NotSupported
        | PortionProductExempt
        | PortionReducedRated
        | PortionStandardRated
        | ProductExempt
        | ProductExemptHoliday
        | ProportionallyRated
        | ReducedRated
        | ReverseCharge
        | StandardRated
        | TaxableBasisReduced
        | ZeroRated

    type UpdateLines'LinesTaxAmounts =
        {
            /// The amount, in cents (or local equivalent), of the tax.
            [<Config.Form>]
            Amount: int option
            /// Data to find or create a TaxRate object.
            /// Stripe automatically creates or reuses a TaxRate object for each tax amount. If the `tax_rate_data` exactly matches a previous value, Stripe will reuse the TaxRate object. TaxRate objects created automatically by Stripe are immediately archived, do not appear in the line item’s `tax_rates`, and cannot be directly added to invoices, payments, or line items.
            [<Config.Form>]
            TaxRateData: UpdateLines'LinesTaxAmountsTaxRateData option
            /// The reasoning behind this tax, for example, if the product is tax exempt.
            [<Config.Form>]
            TaxabilityReason: UpdateLines'LinesTaxAmountsTaxabilityReason option
            /// The amount on which tax is calculated, in cents (or local equivalent).
            [<Config.Form>]
            TaxableAmount: int option
        }

    type UpdateLines'LinesTaxAmounts with
        static member New(?amount: int, ?taxRateData: UpdateLines'LinesTaxAmountsTaxRateData, ?taxabilityReason: UpdateLines'LinesTaxAmountsTaxabilityReason, ?taxableAmount: int) =
            {
                Amount = amount
                TaxRateData = taxRateData
                TaxabilityReason = taxabilityReason
                TaxableAmount = taxableAmount
            }

    type UpdateLines'Lines =
        {
            /// The integer amount in cents (or local equivalent) of the charge to be applied to the upcoming invoice. If you want to apply a credit to the customer's account, pass a negative amount.
            [<Config.Form>]
            Amount: int option
            /// An arbitrary string which you can attach to the invoice item. The description is displayed in the invoice for easy tracking.
            [<Config.Form>]
            Description: string option
            /// Controls whether discounts apply to this line item. Defaults to false for prorations or negative line items, and true for all other line items. Cannot be set to true for prorations.
            [<Config.Form>]
            Discountable: bool option
            /// The coupons, promotion codes & existing discounts which apply to the line item. Item discounts are applied before invoice discounts. Pass an empty string to remove previously-defined discounts.
            [<Config.Form>]
            Discounts: Choice<UpdateLines'LinesDiscounts list,string> option
            /// ID of an existing line item on the invoice.
            [<Config.Form>]
            Id: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`. For [type=subscription](https://docs.stripe.com/api/invoices/line_item#invoice_line_item_object-type) line items, the incoming metadata specified on the request is directly used to set this value, in contrast to [type=invoiceitem](api/invoices/line_item#invoice_line_item_object-type) line items, where any existing metadata on the invoice line is merged with the incoming data.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The period associated with this invoice item. When set to different values, the period will be rendered on the invoice. If you have [Stripe Revenue Recognition](https://docs.stripe.com/revenue-recognition) enabled, the period will be used to recognize and defer revenue. See the [Revenue Recognition documentation](https://docs.stripe.com/revenue-recognition/methodology/subscriptions-and-invoicing) for details.
            [<Config.Form>]
            Period: UpdateLines'LinesPeriod option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline.
            [<Config.Form>]
            PriceData: UpdateLines'LinesPriceData option
            /// The pricing information for the invoice item.
            [<Config.Form>]
            Pricing: UpdateLines'LinesPricing option
            /// Non-negative integer. The quantity of units for the line item. Use `quantity_decimal` instead to provide decimal precision. This field will be deprecated in favor of `quantity_decimal` in a future version.
            [<Config.Form>]
            Quantity: int option
            /// Non-negative decimal with at most 12 decimal places. The quantity of units for the line item.
            [<Config.Form>]
            QuantityDecimal: string option
            /// A list of up to 10 tax amounts for this line item. This can be useful if you calculate taxes on your own or use a third-party to calculate them. You cannot set tax amounts if any line item has [tax_rates](https://docs.stripe.com/api/invoices/line_item#invoice_line_item_object-tax_rates) or if the invoice has [default_tax_rates](https://docs.stripe.com/api/invoices/object#invoice_object-default_tax_rates) or uses [automatic tax](https://docs.stripe.com/tax/invoicing). Pass an empty string to remove previously defined tax amounts.
            [<Config.Form>]
            TaxAmounts: Choice<UpdateLines'LinesTaxAmounts list,string> option
            /// The tax rates which apply to the line item. When set, the `default_tax_rates` on the invoice do not apply to this line item. Pass an empty string to remove previously-defined tax rates.
            [<Config.Form>]
            TaxRates: Choice<string list,string> option
        }

    type UpdateLines'Lines with
        static member New(?amount: int, ?description: string, ?discountable: bool, ?discounts: Choice<UpdateLines'LinesDiscounts list,string>, ?id: string, ?metadata: Map<string, string>, ?period: UpdateLines'LinesPeriod, ?priceData: UpdateLines'LinesPriceData, ?pricing: UpdateLines'LinesPricing, ?quantity: int, ?quantityDecimal: string, ?taxAmounts: Choice<UpdateLines'LinesTaxAmounts list,string>, ?taxRates: Choice<string list,string>) =
            {
                Amount = amount
                Description = description
                Discountable = discountable
                Discounts = discounts
                Id = id
                Metadata = metadata
                Period = period
                PriceData = priceData
                Pricing = pricing
                Quantity = quantity
                QuantityDecimal = quantityDecimal
                TaxAmounts = taxAmounts
                TaxRates = taxRates
            }

    type UpdateLinesOptions =
        {
            [<Config.Path>]
            Invoice: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`. For [type=subscription](https://docs.stripe.com/api/invoices/line_item#invoice_line_item_object-type) line items, the incoming metadata specified on the request is directly used to set this value, in contrast to [type=invoiceitem](api/invoices/line_item#invoice_line_item_object-type) line items, where any existing metadata on the invoice line is merged with the incoming data.
            [<Config.Form>]
            InvoiceMetadata: Choice<Map<string, string>,string> option
            /// The line items to update.
            [<Config.Form>]
            Lines: UpdateLines'Lines list
        }

    type UpdateLinesOptions with
        static member New(invoice: string, lines: UpdateLines'Lines list, ?expand: string list, ?invoiceMetadata: Choice<Map<string, string>,string>) =
            {
                Invoice = invoice
                Lines = lines
                Expand = expand
                InvoiceMetadata = invoiceMetadata
            }

    ///<p>Updates multiple line items on an invoice. This is only possible when an invoice is still a draft.</p>
    let UpdateLines settings (options: UpdateLinesOptions) =
        $"/v1/invoices/{options.Invoice}/update_lines"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesVoid =

    type VoidInvoiceOptions =
        {
            [<Config.Path>]
            Invoice: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type VoidInvoiceOptions with
        static member New(invoice: string, ?expand: string list) =
            {
                Invoice = invoice
                Expand = expand
            }

    ///<p>Mark a finalized invoice as void. This cannot be undone. Voiding an invoice is similar to <a href="/api/invoices/delete">deletion</a>, however it only applies to finalized invoices and maintains a papertrail where the invoice can still be found.</p>
    ///<p>Consult with local regulations to determine whether and how an invoice might be amended, canceled, or voided in the jurisdiction you’re doing business in. You might need to <a href="/api/invoices/create">issue another invoice</a> or <a href="/api/credit_notes/create">credit note</a> instead. Stripe recommends that you consult with your legal counsel for advice specific to your business.</p>
    let VoidInvoice settings (options: VoidInvoiceOptions) =
        $"/v1/invoices/{options.Invoice}/void"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

