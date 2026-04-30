namespace StripeRequest.Accounts

open FunStripe
open System.Text.Json.Serialization
open Stripe.Capability
open Stripe.LoginLink
open Stripe.PaymentMethod
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module Accounts =

    type ListOptions =
        {
            /// Only return connected accounts that were created during the given date interval.
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

    module ListOptions =
        let create
            (
                created: int option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              Created = created
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
            }

    type Create'BusinessProfileAnnualRevenue =
        {
            /// A non-negative integer representing the amount in the [smallest currency unit](/currencies#zero-decimal).
            [<Config.Form>]
            Amount: int option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The close-out date of the preceding fiscal year in ISO 8601 format. E.g. 2023-12-31 for the 31st of December, 2023.
            [<Config.Form>]
            FiscalYearEnd: string option
        }

    module Create'BusinessProfileAnnualRevenue =
        let create
            (
                amount: int option,
                currency: IsoTypes.IsoCurrencyCode option,
                fiscalYearEnd: string option
            ) : Create'BusinessProfileAnnualRevenue
            =
            {
              Amount = amount
              Currency = currency
              FiscalYearEnd = fiscalYearEnd
            }

    type Create'BusinessProfileMinorityOwnedBusinessDesignation =
        | LgbtqiOwnedBusiness
        | MinorityOwnedBusiness
        | None'OfTheseApply
        | PreferNotToAnswer
        | WomenOwnedBusiness

    type Create'BusinessProfileMonthlyEstimatedRevenue =
        {
            /// A non-negative integer representing how much to charge in the [smallest currency unit](/currencies#zero-decimal).
            [<Config.Form>]
            Amount: int option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
        }

    module Create'BusinessProfileMonthlyEstimatedRevenue =
        let create
            (
                amount: int option,
                currency: IsoTypes.IsoCurrencyCode option
            ) : Create'BusinessProfileMonthlyEstimatedRevenue
            =
            {
              Amount = amount
              Currency = currency
            }

    type Create'BusinessProfileSupportAddress =
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

    module Create'BusinessProfileSupportAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Create'BusinessProfileSupportAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Create'BusinessProfile =
        {
            /// The applicant's gross annual revenue for its preceding fiscal year.
            [<Config.Form>]
            AnnualRevenue: Create'BusinessProfileAnnualRevenue option
            /// An estimated upper bound of employees, contractors, vendors, etc. currently working for the business.
            [<Config.Form>]
            EstimatedWorkerCount: int option
            /// [The merchant category code for the account](/connect/setting-mcc). MCCs are used to classify businesses based on the goods or services they provide.
            [<Config.Form>]
            Mcc: string option
            /// Whether the business is a minority-owned, women-owned, and/or LGBTQI+ -owned business.
            [<Config.Form>]
            MinorityOwnedBusinessDesignation: Create'BusinessProfileMinorityOwnedBusinessDesignation list option
            /// An estimate of the monthly revenue of the business. Only accepted for accounts in Brazil and India.
            [<Config.Form>]
            MonthlyEstimatedRevenue: Create'BusinessProfileMonthlyEstimatedRevenue option
            /// The customer-facing business name.
            [<Config.Form>]
            Name: string option
            /// Internal-only description of the product sold by, or service provided by, the business. Used by Stripe for risk and underwriting purposes.
            [<Config.Form>]
            ProductDescription: string option
            /// A publicly available mailing address for sending support issues to.
            [<Config.Form>]
            SupportAddress: Create'BusinessProfileSupportAddress option
            /// A publicly available email address for sending support issues to.
            [<Config.Form>]
            SupportEmail: string option
            /// A publicly available phone number to call with support issues.
            [<Config.Form>]
            SupportPhone: string option
            /// A publicly available website for handling support issues.
            [<Config.Form>]
            SupportUrl: Choice<string,string> option
            /// The business's publicly available website.
            [<Config.Form>]
            Url: string option
        }

    module Create'BusinessProfile =
        let create
            (
                annualRevenue: Create'BusinessProfileAnnualRevenue option,
                estimatedWorkerCount: int option,
                mcc: string option,
                minorityOwnedBusinessDesignation: Create'BusinessProfileMinorityOwnedBusinessDesignation list option,
                monthlyEstimatedRevenue: Create'BusinessProfileMonthlyEstimatedRevenue option,
                name: string option,
                productDescription: string option,
                supportAddress: Create'BusinessProfileSupportAddress option,
                supportEmail: string option,
                supportPhone: string option,
                supportUrl: Choice<string,string> option,
                url: string option
            ) : Create'BusinessProfile
            =
            {
              AnnualRevenue = annualRevenue
              EstimatedWorkerCount = estimatedWorkerCount
              Mcc = mcc
              MinorityOwnedBusinessDesignation = minorityOwnedBusinessDesignation
              MonthlyEstimatedRevenue = monthlyEstimatedRevenue
              Name = name
              ProductDescription = productDescription
              SupportAddress = supportAddress
              SupportEmail = supportEmail
              SupportPhone = supportPhone
              SupportUrl = supportUrl
              Url = url
            }

    type Create'BusinessType =
        | Company
        | GovernmentEntity
        | Individual
        | NonProfit

    type Create'CapabilitiesAcssDebitPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesAcssDebitPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesAcssDebitPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesAffirmPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesAffirmPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesAffirmPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesAfterpayClearpayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesAfterpayClearpayPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesAfterpayClearpayPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesAlmaPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesAlmaPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesAlmaPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesAmazonPayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesAmazonPayPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesAmazonPayPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesAppDistribution =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesAppDistribution =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesAppDistribution
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesAuBecsDebitPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesAuBecsDebitPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesAuBecsDebitPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesBacsDebitPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesBacsDebitPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesBacsDebitPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesBancontactPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesBancontactPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesBancontactPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesBankTransferPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesBankTransferPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesBankTransferPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesBilliePayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesBilliePayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesBilliePayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesBlikPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesBlikPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesBlikPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesBoletoPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesBoletoPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesBoletoPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesCardIssuing =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesCardIssuing =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesCardIssuing
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesCardPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesCardPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesCardPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesCartesBancairesPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesCartesBancairesPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesCartesBancairesPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesCashappPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesCashappPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesCashappPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesCryptoPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesCryptoPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesCryptoPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesEpsPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesEpsPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesEpsPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesFpxPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesFpxPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesFpxPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesGbBankTransferPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesGbBankTransferPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesGbBankTransferPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesGiropayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesGiropayPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesGiropayPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesGrabpayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesGrabpayPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesGrabpayPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesIdealPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesIdealPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesIdealPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesIndiaInternationalPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesIndiaInternationalPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesIndiaInternationalPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesJcbPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesJcbPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesJcbPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesJpBankTransferPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesJpBankTransferPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesJpBankTransferPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesKakaoPayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesKakaoPayPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesKakaoPayPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesKlarnaPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesKlarnaPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesKlarnaPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesKonbiniPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesKonbiniPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesKonbiniPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesKrCardPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesKrCardPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesKrCardPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesLegacyPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesLegacyPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesLegacyPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesLinkPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesLinkPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesLinkPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesMbWayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesMbWayPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesMbWayPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesMobilepayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesMobilepayPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesMobilepayPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesMultibancoPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesMultibancoPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesMultibancoPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesMxBankTransferPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesMxBankTransferPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesMxBankTransferPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesNaverPayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesNaverPayPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesNaverPayPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesNzBankAccountBecsDebitPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesNzBankAccountBecsDebitPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesNzBankAccountBecsDebitPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesOxxoPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesOxxoPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesOxxoPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesP24Payments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesP24Payments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesP24Payments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesPayByBankPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesPayByBankPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesPayByBankPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesPaycoPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesPaycoPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesPaycoPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesPaynowPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesPaynowPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesPaynowPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesPaytoPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesPaytoPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesPaytoPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesPixPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesPixPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesPixPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesPromptpayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesPromptpayPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesPromptpayPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesRevolutPayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesRevolutPayPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesRevolutPayPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesSamsungPayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesSamsungPayPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesSamsungPayPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesSatispayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesSatispayPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesSatispayPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesSepaBankTransferPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesSepaBankTransferPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesSepaBankTransferPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesSepaDebitPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesSepaDebitPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesSepaDebitPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesSofortPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesSofortPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesSofortPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesSunbitPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesSunbitPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesSunbitPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesSwishPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesSwishPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesSwishPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesTaxReportingUs1099K =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesTaxReportingUs1099K =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesTaxReportingUs1099K
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesTaxReportingUs1099Misc =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesTaxReportingUs1099Misc =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesTaxReportingUs1099Misc
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesTransfers =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesTransfers =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesTransfers
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesTreasury =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesTreasury =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesTreasury
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesTwintPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesTwintPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesTwintPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesUpiPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesUpiPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesUpiPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesUsBankAccountAchPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesUsBankAccountAchPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesUsBankAccountAchPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesUsBankTransferPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesUsBankTransferPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesUsBankTransferPayments
            =
            {
              Requested = requested
            }

    type Create'CapabilitiesZipPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Create'CapabilitiesZipPayments =
        let create
            (
                requested: bool option
            ) : Create'CapabilitiesZipPayments
            =
            {
              Requested = requested
            }

    type Create'Capabilities =
        {
            /// The acss_debit_payments capability.
            [<Config.Form>]
            AcssDebitPayments: Create'CapabilitiesAcssDebitPayments option
            /// The affirm_payments capability.
            [<Config.Form>]
            AffirmPayments: Create'CapabilitiesAffirmPayments option
            /// The afterpay_clearpay_payments capability.
            [<Config.Form>]
            AfterpayClearpayPayments: Create'CapabilitiesAfterpayClearpayPayments option
            /// The alma_payments capability.
            [<Config.Form>]
            AlmaPayments: Create'CapabilitiesAlmaPayments option
            /// The amazon_pay_payments capability.
            [<Config.Form>]
            AmazonPayPayments: Create'CapabilitiesAmazonPayPayments option
            /// The app_distribution capability.
            [<Config.Form>]
            AppDistribution: Create'CapabilitiesAppDistribution option
            /// The au_becs_debit_payments capability.
            [<Config.Form>]
            AuBecsDebitPayments: Create'CapabilitiesAuBecsDebitPayments option
            /// The bacs_debit_payments capability.
            [<Config.Form>]
            BacsDebitPayments: Create'CapabilitiesBacsDebitPayments option
            /// The bancontact_payments capability.
            [<Config.Form>]
            BancontactPayments: Create'CapabilitiesBancontactPayments option
            /// The bank_transfer_payments capability.
            [<Config.Form>]
            BankTransferPayments: Create'CapabilitiesBankTransferPayments option
            /// The billie_payments capability.
            [<Config.Form>]
            BilliePayments: Create'CapabilitiesBilliePayments option
            /// The blik_payments capability.
            [<Config.Form>]
            BlikPayments: Create'CapabilitiesBlikPayments option
            /// The boleto_payments capability.
            [<Config.Form>]
            BoletoPayments: Create'CapabilitiesBoletoPayments option
            /// The card_issuing capability.
            [<Config.Form>]
            CardIssuing: Create'CapabilitiesCardIssuing option
            /// The card_payments capability.
            [<Config.Form>]
            CardPayments: Create'CapabilitiesCardPayments option
            /// The cartes_bancaires_payments capability.
            [<Config.Form>]
            CartesBancairesPayments: Create'CapabilitiesCartesBancairesPayments option
            /// The cashapp_payments capability.
            [<Config.Form>]
            CashappPayments: Create'CapabilitiesCashappPayments option
            /// The crypto_payments capability.
            [<Config.Form>]
            CryptoPayments: Create'CapabilitiesCryptoPayments option
            /// The eps_payments capability.
            [<Config.Form>]
            EpsPayments: Create'CapabilitiesEpsPayments option
            /// The fpx_payments capability.
            [<Config.Form>]
            FpxPayments: Create'CapabilitiesFpxPayments option
            /// The gb_bank_transfer_payments capability.
            [<Config.Form>]
            GbBankTransferPayments: Create'CapabilitiesGbBankTransferPayments option
            /// The giropay_payments capability.
            [<Config.Form>]
            GiropayPayments: Create'CapabilitiesGiropayPayments option
            /// The grabpay_payments capability.
            [<Config.Form>]
            GrabpayPayments: Create'CapabilitiesGrabpayPayments option
            /// The ideal_payments capability.
            [<Config.Form>]
            IdealPayments: Create'CapabilitiesIdealPayments option
            /// The india_international_payments capability.
            [<Config.Form>]
            IndiaInternationalPayments: Create'CapabilitiesIndiaInternationalPayments option
            /// The jcb_payments capability.
            [<Config.Form>]
            JcbPayments: Create'CapabilitiesJcbPayments option
            /// The jp_bank_transfer_payments capability.
            [<Config.Form>]
            JpBankTransferPayments: Create'CapabilitiesJpBankTransferPayments option
            /// The kakao_pay_payments capability.
            [<Config.Form>]
            KakaoPayPayments: Create'CapabilitiesKakaoPayPayments option
            /// The klarna_payments capability.
            [<Config.Form>]
            KlarnaPayments: Create'CapabilitiesKlarnaPayments option
            /// The konbini_payments capability.
            [<Config.Form>]
            KonbiniPayments: Create'CapabilitiesKonbiniPayments option
            /// The kr_card_payments capability.
            [<Config.Form>]
            KrCardPayments: Create'CapabilitiesKrCardPayments option
            /// The legacy_payments capability.
            [<Config.Form>]
            LegacyPayments: Create'CapabilitiesLegacyPayments option
            /// The link_payments capability.
            [<Config.Form>]
            LinkPayments: Create'CapabilitiesLinkPayments option
            /// The mb_way_payments capability.
            [<Config.Form>]
            MbWayPayments: Create'CapabilitiesMbWayPayments option
            /// The mobilepay_payments capability.
            [<Config.Form>]
            MobilepayPayments: Create'CapabilitiesMobilepayPayments option
            /// The multibanco_payments capability.
            [<Config.Form>]
            MultibancoPayments: Create'CapabilitiesMultibancoPayments option
            /// The mx_bank_transfer_payments capability.
            [<Config.Form>]
            MxBankTransferPayments: Create'CapabilitiesMxBankTransferPayments option
            /// The naver_pay_payments capability.
            [<Config.Form>]
            NaverPayPayments: Create'CapabilitiesNaverPayPayments option
            /// The nz_bank_account_becs_debit_payments capability.
            [<Config.Form>]
            NzBankAccountBecsDebitPayments: Create'CapabilitiesNzBankAccountBecsDebitPayments option
            /// The oxxo_payments capability.
            [<Config.Form>]
            OxxoPayments: Create'CapabilitiesOxxoPayments option
            /// The p24_payments capability.
            [<Config.Form>]
            P24Payments: Create'CapabilitiesP24Payments option
            /// The pay_by_bank_payments capability.
            [<Config.Form>]
            PayByBankPayments: Create'CapabilitiesPayByBankPayments option
            /// The payco_payments capability.
            [<Config.Form>]
            PaycoPayments: Create'CapabilitiesPaycoPayments option
            /// The paynow_payments capability.
            [<Config.Form>]
            PaynowPayments: Create'CapabilitiesPaynowPayments option
            /// The payto_payments capability.
            [<Config.Form>]
            PaytoPayments: Create'CapabilitiesPaytoPayments option
            /// The pix_payments capability.
            [<Config.Form>]
            PixPayments: Create'CapabilitiesPixPayments option
            /// The promptpay_payments capability.
            [<Config.Form>]
            PromptpayPayments: Create'CapabilitiesPromptpayPayments option
            /// The revolut_pay_payments capability.
            [<Config.Form>]
            RevolutPayPayments: Create'CapabilitiesRevolutPayPayments option
            /// The samsung_pay_payments capability.
            [<Config.Form>]
            SamsungPayPayments: Create'CapabilitiesSamsungPayPayments option
            /// The satispay_payments capability.
            [<Config.Form>]
            SatispayPayments: Create'CapabilitiesSatispayPayments option
            /// The sepa_bank_transfer_payments capability.
            [<Config.Form>]
            SepaBankTransferPayments: Create'CapabilitiesSepaBankTransferPayments option
            /// The sepa_debit_payments capability.
            [<Config.Form>]
            SepaDebitPayments: Create'CapabilitiesSepaDebitPayments option
            /// The sofort_payments capability.
            [<Config.Form>]
            SofortPayments: Create'CapabilitiesSofortPayments option
            /// The sunbit_payments capability.
            [<Config.Form>]
            SunbitPayments: Create'CapabilitiesSunbitPayments option
            /// The swish_payments capability.
            [<Config.Form>]
            SwishPayments: Create'CapabilitiesSwishPayments option
            /// The tax_reporting_us_1099_k capability.
            [<Config.Form>]
            TaxReportingUs1099K: Create'CapabilitiesTaxReportingUs1099K option
            /// The tax_reporting_us_1099_misc capability.
            [<Config.Form>]
            TaxReportingUs1099Misc: Create'CapabilitiesTaxReportingUs1099Misc option
            /// The transfers capability.
            [<Config.Form>]
            Transfers: Create'CapabilitiesTransfers option
            /// The treasury capability.
            [<Config.Form>]
            Treasury: Create'CapabilitiesTreasury option
            /// The twint_payments capability.
            [<Config.Form>]
            TwintPayments: Create'CapabilitiesTwintPayments option
            /// The upi_payments capability.
            [<Config.Form>]
            UpiPayments: Create'CapabilitiesUpiPayments option
            /// The us_bank_account_ach_payments capability.
            [<Config.Form>]
            UsBankAccountAchPayments: Create'CapabilitiesUsBankAccountAchPayments option
            /// The us_bank_transfer_payments capability.
            [<Config.Form>]
            UsBankTransferPayments: Create'CapabilitiesUsBankTransferPayments option
            /// The zip_payments capability.
            [<Config.Form>]
            ZipPayments: Create'CapabilitiesZipPayments option
        }

    module Create'Capabilities =
        let create
            (
                acssDebitPayments: Create'CapabilitiesAcssDebitPayments option,
                affirmPayments: Create'CapabilitiesAffirmPayments option,
                afterpayClearpayPayments: Create'CapabilitiesAfterpayClearpayPayments option,
                almaPayments: Create'CapabilitiesAlmaPayments option,
                amazonPayPayments: Create'CapabilitiesAmazonPayPayments option,
                appDistribution: Create'CapabilitiesAppDistribution option,
                auBecsDebitPayments: Create'CapabilitiesAuBecsDebitPayments option,
                bacsDebitPayments: Create'CapabilitiesBacsDebitPayments option,
                bancontactPayments: Create'CapabilitiesBancontactPayments option,
                bankTransferPayments: Create'CapabilitiesBankTransferPayments option,
                billiePayments: Create'CapabilitiesBilliePayments option,
                blikPayments: Create'CapabilitiesBlikPayments option,
                boletoPayments: Create'CapabilitiesBoletoPayments option,
                cardIssuing: Create'CapabilitiesCardIssuing option,
                cardPayments: Create'CapabilitiesCardPayments option,
                cartesBancairesPayments: Create'CapabilitiesCartesBancairesPayments option,
                cashappPayments: Create'CapabilitiesCashappPayments option,
                cryptoPayments: Create'CapabilitiesCryptoPayments option,
                epsPayments: Create'CapabilitiesEpsPayments option,
                fpxPayments: Create'CapabilitiesFpxPayments option,
                gbBankTransferPayments: Create'CapabilitiesGbBankTransferPayments option,
                giropayPayments: Create'CapabilitiesGiropayPayments option,
                grabpayPayments: Create'CapabilitiesGrabpayPayments option,
                idealPayments: Create'CapabilitiesIdealPayments option,
                indiaInternationalPayments: Create'CapabilitiesIndiaInternationalPayments option,
                jcbPayments: Create'CapabilitiesJcbPayments option,
                jpBankTransferPayments: Create'CapabilitiesJpBankTransferPayments option,
                kakaoPayPayments: Create'CapabilitiesKakaoPayPayments option,
                klarnaPayments: Create'CapabilitiesKlarnaPayments option,
                konbiniPayments: Create'CapabilitiesKonbiniPayments option,
                krCardPayments: Create'CapabilitiesKrCardPayments option,
                legacyPayments: Create'CapabilitiesLegacyPayments option,
                linkPayments: Create'CapabilitiesLinkPayments option,
                mbWayPayments: Create'CapabilitiesMbWayPayments option,
                mobilepayPayments: Create'CapabilitiesMobilepayPayments option,
                multibancoPayments: Create'CapabilitiesMultibancoPayments option,
                mxBankTransferPayments: Create'CapabilitiesMxBankTransferPayments option,
                naverPayPayments: Create'CapabilitiesNaverPayPayments option,
                nzBankAccountBecsDebitPayments: Create'CapabilitiesNzBankAccountBecsDebitPayments option,
                oxxoPayments: Create'CapabilitiesOxxoPayments option,
                p24Payments: Create'CapabilitiesP24Payments option,
                payByBankPayments: Create'CapabilitiesPayByBankPayments option,
                paycoPayments: Create'CapabilitiesPaycoPayments option,
                paynowPayments: Create'CapabilitiesPaynowPayments option,
                paytoPayments: Create'CapabilitiesPaytoPayments option,
                pixPayments: Create'CapabilitiesPixPayments option,
                promptpayPayments: Create'CapabilitiesPromptpayPayments option,
                revolutPayPayments: Create'CapabilitiesRevolutPayPayments option,
                samsungPayPayments: Create'CapabilitiesSamsungPayPayments option,
                satispayPayments: Create'CapabilitiesSatispayPayments option,
                sepaBankTransferPayments: Create'CapabilitiesSepaBankTransferPayments option,
                sepaDebitPayments: Create'CapabilitiesSepaDebitPayments option,
                sofortPayments: Create'CapabilitiesSofortPayments option,
                sunbitPayments: Create'CapabilitiesSunbitPayments option,
                swishPayments: Create'CapabilitiesSwishPayments option,
                taxReportingUs1099K: Create'CapabilitiesTaxReportingUs1099K option,
                taxReportingUs1099Misc: Create'CapabilitiesTaxReportingUs1099Misc option,
                transfers: Create'CapabilitiesTransfers option,
                treasury: Create'CapabilitiesTreasury option,
                twintPayments: Create'CapabilitiesTwintPayments option,
                upiPayments: Create'CapabilitiesUpiPayments option,
                usBankAccountAchPayments: Create'CapabilitiesUsBankAccountAchPayments option,
                usBankTransferPayments: Create'CapabilitiesUsBankTransferPayments option,
                zipPayments: Create'CapabilitiesZipPayments option
            ) : Create'Capabilities
            =
            {
              AcssDebitPayments = acssDebitPayments
              AffirmPayments = affirmPayments
              AfterpayClearpayPayments = afterpayClearpayPayments
              AlmaPayments = almaPayments
              AmazonPayPayments = amazonPayPayments
              AppDistribution = appDistribution
              AuBecsDebitPayments = auBecsDebitPayments
              BacsDebitPayments = bacsDebitPayments
              BancontactPayments = bancontactPayments
              BankTransferPayments = bankTransferPayments
              BilliePayments = billiePayments
              BlikPayments = blikPayments
              BoletoPayments = boletoPayments
              CardIssuing = cardIssuing
              CardPayments = cardPayments
              CartesBancairesPayments = cartesBancairesPayments
              CashappPayments = cashappPayments
              CryptoPayments = cryptoPayments
              EpsPayments = epsPayments
              FpxPayments = fpxPayments
              GbBankTransferPayments = gbBankTransferPayments
              GiropayPayments = giropayPayments
              GrabpayPayments = grabpayPayments
              IdealPayments = idealPayments
              IndiaInternationalPayments = indiaInternationalPayments
              JcbPayments = jcbPayments
              JpBankTransferPayments = jpBankTransferPayments
              KakaoPayPayments = kakaoPayPayments
              KlarnaPayments = klarnaPayments
              KonbiniPayments = konbiniPayments
              KrCardPayments = krCardPayments
              LegacyPayments = legacyPayments
              LinkPayments = linkPayments
              MbWayPayments = mbWayPayments
              MobilepayPayments = mobilepayPayments
              MultibancoPayments = multibancoPayments
              MxBankTransferPayments = mxBankTransferPayments
              NaverPayPayments = naverPayPayments
              NzBankAccountBecsDebitPayments = nzBankAccountBecsDebitPayments
              OxxoPayments = oxxoPayments
              P24Payments = p24Payments
              PayByBankPayments = payByBankPayments
              PaycoPayments = paycoPayments
              PaynowPayments = paynowPayments
              PaytoPayments = paytoPayments
              PixPayments = pixPayments
              PromptpayPayments = promptpayPayments
              RevolutPayPayments = revolutPayPayments
              SamsungPayPayments = samsungPayPayments
              SatispayPayments = satispayPayments
              SepaBankTransferPayments = sepaBankTransferPayments
              SepaDebitPayments = sepaDebitPayments
              SofortPayments = sofortPayments
              SunbitPayments = sunbitPayments
              SwishPayments = swishPayments
              TaxReportingUs1099K = taxReportingUs1099K
              TaxReportingUs1099Misc = taxReportingUs1099Misc
              Transfers = transfers
              Treasury = treasury
              TwintPayments = twintPayments
              UpiPayments = upiPayments
              UsBankAccountAchPayments = usBankAccountAchPayments
              UsBankTransferPayments = usBankTransferPayments
              ZipPayments = zipPayments
            }

    type Create'CompanyAddress =
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

    module Create'CompanyAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Create'CompanyAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Create'CompanyAddressKana =
        {
            /// City or ward.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Block or building number.
            [<Config.Form>]
            Line1: string option
            /// Building details.
            [<Config.Form>]
            Line2: string option
            /// Postal code.
            [<Config.Form>]
            PostalCode: string option
            /// Prefecture.
            [<Config.Form>]
            State: string option
            /// Town or cho-me.
            [<Config.Form>]
            Town: string option
        }

    module Create'CompanyAddressKana =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option,
                town: string option
            ) : Create'CompanyAddressKana
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
              Town = town
            }

    type Create'CompanyAddressKanji =
        {
            /// City or ward.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Block or building number.
            [<Config.Form>]
            Line1: string option
            /// Building details.
            [<Config.Form>]
            Line2: string option
            /// Postal code.
            [<Config.Form>]
            PostalCode: string option
            /// Prefecture.
            [<Config.Form>]
            State: string option
            /// Town or cho-me.
            [<Config.Form>]
            Town: string option
        }

    module Create'CompanyAddressKanji =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option,
                town: string option
            ) : Create'CompanyAddressKanji
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
              Town = town
            }

    type Create'CompanyDirectorshipDeclaration =
        {
            /// The Unix timestamp marking when the directorship declaration attestation was made.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the directorship declaration attestation was made.
            [<Config.Form>]
            Ip: string option
            /// The user agent of the browser from which the directorship declaration attestation was made.
            [<Config.Form>]
            UserAgent: string option
        }

    module Create'CompanyDirectorshipDeclaration =
        let create
            (
                date: DateTime option,
                ip: string option,
                userAgent: string option
            ) : Create'CompanyDirectorshipDeclaration
            =
            {
              Date = date
              Ip = ip
              UserAgent = userAgent
            }

    type Create'CompanyOwnershipDeclaration =
        {
            /// The Unix timestamp marking when the beneficial owner attestation was made.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the beneficial owner attestation was made.
            [<Config.Form>]
            Ip: string option
            /// The user agent of the browser from which the beneficial owner attestation was made.
            [<Config.Form>]
            UserAgent: string option
        }

    module Create'CompanyOwnershipDeclaration =
        let create
            (
                date: DateTime option,
                ip: string option,
                userAgent: string option
            ) : Create'CompanyOwnershipDeclaration
            =
            {
              Date = date
              Ip = ip
              UserAgent = userAgent
            }

    type Create'CompanyOwnershipExemptionReason =
        | QualifiedEntityExceedsOwnershipThreshold
        | QualifiesAsFinancialInstitution

    type Create'CompanyRegistrationDateRegistrationDateSpecs =
        {
            /// The day of registration, between 1 and 31.
            [<Config.Form>]
            Day: int option
            /// The month of registration, between 1 and 12.
            [<Config.Form>]
            Month: int option
            /// The four-digit year of registration.
            [<Config.Form>]
            Year: int option
        }

    module Create'CompanyRegistrationDateRegistrationDateSpecs =
        let create
            (
                day: int option,
                month: int option,
                year: int option
            ) : Create'CompanyRegistrationDateRegistrationDateSpecs
            =
            {
              Day = day
              Month = month
              Year = year
            }

    type Create'CompanyRepresentativeDeclaration =
        {
            /// The Unix timestamp marking when the representative declaration attestation was made.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the representative declaration attestation was made.
            [<Config.Form>]
            Ip: string option
            /// The user agent of the browser from which the representative declaration attestation was made.
            [<Config.Form>]
            UserAgent: string option
        }

    module Create'CompanyRepresentativeDeclaration =
        let create
            (
                date: DateTime option,
                ip: string option,
                userAgent: string option
            ) : Create'CompanyRepresentativeDeclaration
            =
            {
              Date = date
              Ip = ip
              UserAgent = userAgent
            }

    type Create'CompanyStructure =
        | FreeZoneEstablishment
        | FreeZoneLlc
        | GovernmentInstrumentality
        | GovernmentalUnit
        | IncorporatedNonProfit
        | IncorporatedPartnership
        | LimitedLiabilityPartnership
        | Llc
        | MultiMemberLlc
        | PrivateCompany
        | PrivateCorporation
        | PrivatePartnership
        | PublicCompany
        | PublicCorporation
        | PublicPartnership
        | RegisteredCharity
        | SingleMemberLlc
        | SoleEstablishment
        | SoleProprietorship
        | TaxExemptGovernmentInstrumentality
        | UnincorporatedAssociation
        | UnincorporatedNonProfit
        | UnincorporatedPartnership

    type Create'CompanyVerificationDocument =
        {
            /// The back of a document returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `additional_verification`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Back: string option
            /// The front of a document returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `additional_verification`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Front: string option
        }

    module Create'CompanyVerificationDocument =
        let create
            (
                back: string option,
                front: string option
            ) : Create'CompanyVerificationDocument
            =
            {
              Back = back
              Front = front
            }

    type Create'CompanyVerification =
        {
            /// A document verifying the business.
            [<Config.Form>]
            Document: Create'CompanyVerificationDocument option
        }

    module Create'CompanyVerification =
        let create
            (
                document: Create'CompanyVerificationDocument option
            ) : Create'CompanyVerification
            =
            {
              Document = document
            }

    type Create'Company =
        {
            /// The company's primary address.
            [<Config.Form>]
            Address: Create'CompanyAddress option
            /// The Kana variation of the company's primary address (Japan only).
            [<Config.Form>]
            AddressKana: Create'CompanyAddressKana option
            /// The Kanji variation of the company's primary address (Japan only).
            [<Config.Form>]
            AddressKanji: Create'CompanyAddressKanji option
            /// Whether the company's directors have been provided. Set this Boolean to `true` after creating all the company's directors with [the Persons API](/api/persons) for accounts with a `relationship.director` requirement. This value is not automatically set to `true` after creating directors, so it needs to be updated to indicate all directors have been provided.
            [<Config.Form>]
            DirectorsProvided: bool option
            /// This hash is used to attest that the directors information provided to Stripe is both current and correct.
            [<Config.Form>]
            DirectorshipDeclaration: Create'CompanyDirectorshipDeclaration option
            /// Whether the company's executives have been provided. Set this Boolean to `true` after creating all the company's executives with [the Persons API](/api/persons) for accounts with a `relationship.executive` requirement.
            [<Config.Form>]
            ExecutivesProvided: bool option
            /// The export license ID number of the company, also referred as Import Export Code (India only).
            [<Config.Form>]
            ExportLicenseId: string option
            /// The purpose code to use for export transactions (India only).
            [<Config.Form>]
            ExportPurposeCode: string option
            /// The company's legal name.
            [<Config.Form>]
            Name: string option
            /// The Kana variation of the company's legal name (Japan only).
            [<Config.Form>]
            NameKana: string option
            /// The Kanji variation of the company's legal name (Japan only).
            [<Config.Form>]
            NameKanji: string option
            /// Whether the company's owners have been provided. Set this Boolean to `true` after creating all the company's owners with [the Persons API](/api/persons) for accounts with a `relationship.owner` requirement.
            [<Config.Form>]
            OwnersProvided: bool option
            /// This hash is used to attest that the beneficial owner information provided to Stripe is both current and correct.
            [<Config.Form>]
            OwnershipDeclaration: Create'CompanyOwnershipDeclaration option
            /// This value is used to determine if a business is exempt from providing ultimate beneficial owners. See [this support article](https://support.stripe.com/questions/exemption-from-providing-ownership-details) and [changelog](https://docs.stripe.com/changelog/acacia/2025-01-27/ownership-exemption-reason-accounts-api) for more details.
            [<Config.Form>]
            OwnershipExemptionReason: Create'CompanyOwnershipExemptionReason option
            /// The company's phone number (used for verification).
            [<Config.Form>]
            Phone: string option
            /// When the business was incorporated or registered.
            [<Config.Form>]
            RegistrationDate: Choice<Create'CompanyRegistrationDateRegistrationDateSpecs,string> option
            /// The identification number given to a company when it is registered or incorporated, if distinct from the identification number used for filing taxes. (Examples are the CIN for companies and LLP IN for partnerships in India, and the Company Registration Number in Hong Kong).
            [<Config.Form>]
            RegistrationNumber: string option
            /// This hash is used to attest that the representative is authorized to act as the representative of their legal entity.
            [<Config.Form>]
            RepresentativeDeclaration: Create'CompanyRepresentativeDeclaration option
            /// The category identifying the legal structure of the company or legal entity. See [Business structure](/connect/identity-verification#business-structure) for more details. Pass an empty string to unset this value.
            [<Config.Form>]
            Structure: Create'CompanyStructure option
            /// The business ID number of the company, as appropriate for the company’s country. (Examples are an Employer ID Number in the U.S., a Business Number in Canada, or a Company Number in the UK.)
            [<Config.Form>]
            TaxId: string option
            /// The jurisdiction in which the `tax_id` is registered (Germany-based companies only).
            [<Config.Form>]
            TaxIdRegistrar: string option
            /// The VAT number of the company.
            [<Config.Form>]
            VatId: string option
            /// Information on the verification state of the company.
            [<Config.Form>]
            Verification: Create'CompanyVerification option
        }

    module Create'Company =
        let create
            (
                address: Create'CompanyAddress option,
                addressKana: Create'CompanyAddressKana option,
                addressKanji: Create'CompanyAddressKanji option,
                directorsProvided: bool option,
                directorshipDeclaration: Create'CompanyDirectorshipDeclaration option,
                executivesProvided: bool option,
                exportLicenseId: string option,
                exportPurposeCode: string option,
                name: string option,
                nameKana: string option,
                nameKanji: string option,
                ownersProvided: bool option,
                ownershipDeclaration: Create'CompanyOwnershipDeclaration option,
                ownershipExemptionReason: Create'CompanyOwnershipExemptionReason option,
                phone: string option,
                registrationDate: Choice<Create'CompanyRegistrationDateRegistrationDateSpecs,string> option,
                registrationNumber: string option,
                representativeDeclaration: Create'CompanyRepresentativeDeclaration option,
                structure: Create'CompanyStructure option,
                taxId: string option,
                taxIdRegistrar: string option,
                vatId: string option,
                verification: Create'CompanyVerification option
            ) : Create'Company
            =
            {
              Address = address
              AddressKana = addressKana
              AddressKanji = addressKanji
              DirectorsProvided = directorsProvided
              DirectorshipDeclaration = directorshipDeclaration
              ExecutivesProvided = executivesProvided
              ExportLicenseId = exportLicenseId
              ExportPurposeCode = exportPurposeCode
              Name = name
              NameKana = nameKana
              NameKanji = nameKanji
              OwnersProvided = ownersProvided
              OwnershipDeclaration = ownershipDeclaration
              OwnershipExemptionReason = ownershipExemptionReason
              Phone = phone
              RegistrationDate = registrationDate
              RegistrationNumber = registrationNumber
              RepresentativeDeclaration = representativeDeclaration
              Structure = structure
              TaxId = taxId
              TaxIdRegistrar = taxIdRegistrar
              VatId = vatId
              Verification = verification
            }

    type Create'ControllerFeesPayer =
        | Account
        | Application

    type Create'ControllerFees =
        {
            /// A value indicating the responsible payer of Stripe fees on this account. Defaults to `account`. Learn more about [fee behavior on connected accounts](https://docs.stripe.com/connect/direct-charges-fee-payer-behavior).
            [<Config.Form>]
            Payer: Create'ControllerFeesPayer option
        }

    module Create'ControllerFees =
        let create
            (
                payer: Create'ControllerFeesPayer option
            ) : Create'ControllerFees
            =
            {
              Payer = payer
            }

    type Create'ControllerLossesPayments =
        | Application
        | Stripe

    type Create'ControllerLosses =
        {
            /// A value indicating who is liable when this account can't pay back negative balances resulting from payments. Defaults to `stripe`.
            [<Config.Form>]
            Payments: Create'ControllerLossesPayments option
        }

    module Create'ControllerLosses =
        let create
            (
                payments: Create'ControllerLossesPayments option
            ) : Create'ControllerLosses
            =
            {
              Payments = payments
            }

    type Create'ControllerRequirementCollection =
        | Application
        | Stripe

    type Create'ControllerStripeDashboardType =
        | Express
        | Full
        | [<JsonPropertyName("none")>] None'

    type Create'ControllerStripeDashboard =
        {
            /// Whether this account should have access to the full Stripe Dashboard (`full`), to the Express Dashboard (`express`), or to no Stripe-hosted dashboard (`none`). Defaults to `full`.
            [<Config.Form>]
            Type: Create'ControllerStripeDashboardType option
        }

    module Create'ControllerStripeDashboard =
        let create
            (
                ``type``: Create'ControllerStripeDashboardType option
            ) : Create'ControllerStripeDashboard
            =
            {
              Type = ``type``
            }

    type Create'Controller =
        {
            /// A hash of configuration for who pays Stripe fees for product usage on this account.
            [<Config.Form>]
            Fees: Create'ControllerFees option
            /// A hash of configuration for products that have negative balance liability, and whether Stripe or a Connect application is responsible for them.
            [<Config.Form>]
            Losses: Create'ControllerLosses option
            /// A value indicating responsibility for collecting updated information when requirements on the account are due or change. Defaults to `stripe`.
            [<Config.Form>]
            RequirementCollection: Create'ControllerRequirementCollection option
            /// A hash of configuration for Stripe-hosted dashboards.
            [<Config.Form>]
            StripeDashboard: Create'ControllerStripeDashboard option
        }

    module Create'Controller =
        let create
            (
                fees: Create'ControllerFees option,
                losses: Create'ControllerLosses option,
                requirementCollection: Create'ControllerRequirementCollection option,
                stripeDashboard: Create'ControllerStripeDashboard option
            ) : Create'Controller
            =
            {
              Fees = fees
              Losses = losses
              RequirementCollection = requirementCollection
              StripeDashboard = stripeDashboard
            }

    type Create'DocumentsBankAccountOwnershipVerification =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: string list option
        }

    module Create'DocumentsBankAccountOwnershipVerification =
        let create
            (
                files: string list option
            ) : Create'DocumentsBankAccountOwnershipVerification
            =
            {
              Files = files
            }

    type Create'DocumentsCompanyLicense =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: string list option
        }

    module Create'DocumentsCompanyLicense =
        let create
            (
                files: string list option
            ) : Create'DocumentsCompanyLicense
            =
            {
              Files = files
            }

    type Create'DocumentsCompanyMemorandumOfAssociation =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: string list option
        }

    module Create'DocumentsCompanyMemorandumOfAssociation =
        let create
            (
                files: string list option
            ) : Create'DocumentsCompanyMemorandumOfAssociation
            =
            {
              Files = files
            }

    type Create'DocumentsCompanyMinisterialDecree =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: string list option
        }

    module Create'DocumentsCompanyMinisterialDecree =
        let create
            (
                files: string list option
            ) : Create'DocumentsCompanyMinisterialDecree
            =
            {
              Files = files
            }

    type Create'DocumentsCompanyRegistrationVerification =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: string list option
        }

    module Create'DocumentsCompanyRegistrationVerification =
        let create
            (
                files: string list option
            ) : Create'DocumentsCompanyRegistrationVerification
            =
            {
              Files = files
            }

    type Create'DocumentsCompanyTaxIdVerification =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: string list option
        }

    module Create'DocumentsCompanyTaxIdVerification =
        let create
            (
                files: string list option
            ) : Create'DocumentsCompanyTaxIdVerification
            =
            {
              Files = files
            }

    type Create'DocumentsProofOfAddress =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: string list option
        }

    module Create'DocumentsProofOfAddress =
        let create
            (
                files: string list option
            ) : Create'DocumentsProofOfAddress
            =
            {
              Files = files
            }

    type Create'DocumentsProofOfRegistrationSigner =
        {
            /// The token of the person signing the document, if applicable.
            [<Config.Form>]
            Person: string option
        }

    module Create'DocumentsProofOfRegistrationSigner =
        let create
            (
                person: string option
            ) : Create'DocumentsProofOfRegistrationSigner
            =
            {
              Person = person
            }

    type Create'DocumentsProofOfRegistration =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: string list option
            /// Information regarding the person signing the document if applicable.
            [<Config.Form>]
            Signer: Create'DocumentsProofOfRegistrationSigner option
        }

    module Create'DocumentsProofOfRegistration =
        let create
            (
                files: string list option,
                signer: Create'DocumentsProofOfRegistrationSigner option
            ) : Create'DocumentsProofOfRegistration
            =
            {
              Files = files
              Signer = signer
            }

    type Create'DocumentsProofOfUltimateBeneficialOwnershipSigner =
        {
            /// The token of the person signing the document, if applicable.
            [<Config.Form>]
            Person: string option
        }

    module Create'DocumentsProofOfUltimateBeneficialOwnershipSigner =
        let create
            (
                person: string option
            ) : Create'DocumentsProofOfUltimateBeneficialOwnershipSigner
            =
            {
              Person = person
            }

    type Create'DocumentsProofOfUltimateBeneficialOwnership =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: string list option
            /// Information regarding the person signing the document if applicable.
            [<Config.Form>]
            Signer: Create'DocumentsProofOfUltimateBeneficialOwnershipSigner option
        }

    module Create'DocumentsProofOfUltimateBeneficialOwnership =
        let create
            (
                files: string list option,
                signer: Create'DocumentsProofOfUltimateBeneficialOwnershipSigner option
            ) : Create'DocumentsProofOfUltimateBeneficialOwnership
            =
            {
              Files = files
              Signer = signer
            }

    type Create'Documents =
        {
            /// One or more documents that support the [Bank account ownership verification](https://support.stripe.com/questions/bank-account-ownership-verification) requirement. Must be a document associated with the account’s primary active bank account that displays the last 4 digits of the account number, either a statement or a check.
            [<Config.Form>]
            BankAccountOwnershipVerification: Create'DocumentsBankAccountOwnershipVerification option
            /// One or more documents that demonstrate proof of a company's license to operate.
            [<Config.Form>]
            CompanyLicense: Create'DocumentsCompanyLicense option
            /// One or more documents showing the company's Memorandum of Association.
            [<Config.Form>]
            CompanyMemorandumOfAssociation: Create'DocumentsCompanyMemorandumOfAssociation option
            /// (Certain countries only) One or more documents showing the ministerial decree legalizing the company's establishment.
            [<Config.Form>]
            CompanyMinisterialDecree: Create'DocumentsCompanyMinisterialDecree option
            /// One or more documents that demonstrate proof of a company's registration with the appropriate local authorities.
            [<Config.Form>]
            CompanyRegistrationVerification: Create'DocumentsCompanyRegistrationVerification option
            /// One or more documents that demonstrate proof of a company's tax ID.
            [<Config.Form>]
            CompanyTaxIdVerification: Create'DocumentsCompanyTaxIdVerification option
            /// One or more documents that demonstrate proof of address.
            [<Config.Form>]
            ProofOfAddress: Create'DocumentsProofOfAddress option
            /// One or more documents showing the company’s proof of registration with the national business registry.
            [<Config.Form>]
            ProofOfRegistration: Create'DocumentsProofOfRegistration option
            /// One or more documents that demonstrate proof of ultimate beneficial ownership.
            [<Config.Form>]
            ProofOfUltimateBeneficialOwnership: Create'DocumentsProofOfUltimateBeneficialOwnership option
        }

    module Create'Documents =
        let create
            (
                bankAccountOwnershipVerification: Create'DocumentsBankAccountOwnershipVerification option,
                companyLicense: Create'DocumentsCompanyLicense option,
                companyMemorandumOfAssociation: Create'DocumentsCompanyMemorandumOfAssociation option,
                companyMinisterialDecree: Create'DocumentsCompanyMinisterialDecree option,
                companyRegistrationVerification: Create'DocumentsCompanyRegistrationVerification option,
                companyTaxIdVerification: Create'DocumentsCompanyTaxIdVerification option,
                proofOfAddress: Create'DocumentsProofOfAddress option,
                proofOfRegistration: Create'DocumentsProofOfRegistration option,
                proofOfUltimateBeneficialOwnership: Create'DocumentsProofOfUltimateBeneficialOwnership option
            ) : Create'Documents
            =
            {
              BankAccountOwnershipVerification = bankAccountOwnershipVerification
              CompanyLicense = companyLicense
              CompanyMemorandumOfAssociation = companyMemorandumOfAssociation
              CompanyMinisterialDecree = companyMinisterialDecree
              CompanyRegistrationVerification = companyRegistrationVerification
              CompanyTaxIdVerification = companyTaxIdVerification
              ProofOfAddress = proofOfAddress
              ProofOfRegistration = proofOfRegistration
              ProofOfUltimateBeneficialOwnership = proofOfUltimateBeneficialOwnership
            }

    type Create'Groups =
        {
            /// The group the account is in to determine their payments pricing, and null if the account is on customized pricing. [See the Platform pricing tool documentation](https://docs.stripe.com/connect/platform-pricing-tools) for details.
            [<Config.Form>]
            PaymentsPricing: Choice<string,string> option
        }

    module Create'Groups =
        let create
            (
                paymentsPricing: Choice<string,string> option
            ) : Create'Groups
            =
            {
              PaymentsPricing = paymentsPricing
            }

    type Create'IndividualAddress =
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

    module Create'IndividualAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Create'IndividualAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Create'IndividualAddressKana =
        {
            /// City or ward.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Block or building number.
            [<Config.Form>]
            Line1: string option
            /// Building details.
            [<Config.Form>]
            Line2: string option
            /// Postal code.
            [<Config.Form>]
            PostalCode: string option
            /// Prefecture.
            [<Config.Form>]
            State: string option
            /// Town or cho-me.
            [<Config.Form>]
            Town: string option
        }

    module Create'IndividualAddressKana =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option,
                town: string option
            ) : Create'IndividualAddressKana
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
              Town = town
            }

    type Create'IndividualAddressKanji =
        {
            /// City or ward.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Block or building number.
            [<Config.Form>]
            Line1: string option
            /// Building details.
            [<Config.Form>]
            Line2: string option
            /// Postal code.
            [<Config.Form>]
            PostalCode: string option
            /// Prefecture.
            [<Config.Form>]
            State: string option
            /// Town or cho-me.
            [<Config.Form>]
            Town: string option
        }

    module Create'IndividualAddressKanji =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option,
                town: string option
            ) : Create'IndividualAddressKanji
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
              Town = town
            }

    type Create'IndividualDobDateOfBirthSpecs =
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

    module Create'IndividualDobDateOfBirthSpecs =
        let create
            (
                day: int option,
                month: int option,
                year: int option
            ) : Create'IndividualDobDateOfBirthSpecs
            =
            {
              Day = day
              Month = month
              Year = year
            }

    type Create'IndividualPoliticalExposure =
        | Existing
        | [<JsonPropertyName("none")>] None'

    type Create'IndividualRegisteredAddress =
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

    module Create'IndividualRegisteredAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Create'IndividualRegisteredAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Create'IndividualRelationship =
        {
            /// Whether the person is a director of the account's legal entity. Directors are typically members of the governing board of the company, or responsible for ensuring the company meets its regulatory obligations.
            [<Config.Form>]
            Director: bool option
            /// Whether the person has significant responsibility to control, manage, or direct the organization.
            [<Config.Form>]
            Executive: bool option
            /// Whether the person is an owner of the account’s legal entity.
            [<Config.Form>]
            Owner: bool option
            /// The percent owned by the person of the account's legal entity.
            [<Config.Form>]
            PercentOwnership: Choice<decimal,string> option
            /// The person's title (e.g., CEO, Support Engineer).
            [<Config.Form>]
            Title: string option
        }

    module Create'IndividualRelationship =
        let create
            (
                director: bool option,
                executive: bool option,
                owner: bool option,
                percentOwnership: Choice<decimal,string> option,
                title: string option
            ) : Create'IndividualRelationship
            =
            {
              Director = director
              Executive = executive
              Owner = owner
              PercentOwnership = percentOwnership
              Title = title
            }

    type Create'IndividualVerificationAdditionalDocument =
        {
            /// The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Back: string option
            /// The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Front: string option
        }

    module Create'IndividualVerificationAdditionalDocument =
        let create
            (
                back: string option,
                front: string option
            ) : Create'IndividualVerificationAdditionalDocument
            =
            {
              Back = back
              Front = front
            }

    type Create'IndividualVerificationDocument =
        {
            /// The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Back: string option
            /// The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Front: string option
        }

    module Create'IndividualVerificationDocument =
        let create
            (
                back: string option,
                front: string option
            ) : Create'IndividualVerificationDocument
            =
            {
              Back = back
              Front = front
            }

    type Create'IndividualVerification =
        {
            /// A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.
            [<Config.Form>]
            AdditionalDocument: Create'IndividualVerificationAdditionalDocument option
            /// An identifying document, either a passport or local ID card.
            [<Config.Form>]
            Document: Create'IndividualVerificationDocument option
        }

    module Create'IndividualVerification =
        let create
            (
                additionalDocument: Create'IndividualVerificationAdditionalDocument option,
                document: Create'IndividualVerificationDocument option
            ) : Create'IndividualVerification
            =
            {
              AdditionalDocument = additionalDocument
              Document = document
            }

    type Create'Individual =
        {
            /// The individual's primary address.
            [<Config.Form>]
            Address: Create'IndividualAddress option
            /// The Kana variation of the individual's primary address (Japan only).
            [<Config.Form>]
            AddressKana: Create'IndividualAddressKana option
            /// The Kanji variation of the individual's primary address (Japan only).
            [<Config.Form>]
            AddressKanji: Create'IndividualAddressKanji option
            /// The individual's date of birth.
            [<Config.Form>]
            Dob: Choice<Create'IndividualDobDateOfBirthSpecs,string> option
            /// The individual's email address.
            [<Config.Form>]
            Email: string option
            /// The individual's first name.
            [<Config.Form>]
            FirstName: string option
            /// The Kana variation of the individual's first name (Japan only).
            [<Config.Form>]
            FirstNameKana: string option
            /// The Kanji variation of the individual's first name (Japan only).
            [<Config.Form>]
            FirstNameKanji: string option
            /// A list of alternate names or aliases that the individual is known by.
            [<Config.Form>]
            FullNameAliases: Choice<string list,string> option
            /// The individual's gender
            [<Config.Form>]
            Gender: string option
            /// The government-issued ID number of the individual, as appropriate for the representative's country. (Examples are a Social Security Number in the U.S., or a Social Insurance Number in Canada). Instead of the number itself, you can also provide a [PII token created with Stripe.js](/js/tokens/create_token?type=pii).
            [<Config.Form>]
            IdNumber: string option
            /// The government-issued secondary ID number of the individual, as appropriate for the representative's country, will be used for enhanced verification checks. In Thailand, this would be the laser code found on the back of an ID card. Instead of the number itself, you can also provide a [PII token created with Stripe.js](/js/tokens/create_token?type=pii).
            [<Config.Form>]
            IdNumberSecondary: string option
            /// The individual's last name.
            [<Config.Form>]
            LastName: string option
            /// The Kana variation of the individual's last name (Japan only).
            [<Config.Form>]
            LastNameKana: string option
            /// The Kanji variation of the individual's last name (Japan only).
            [<Config.Form>]
            LastNameKanji: string option
            /// The individual's maiden name.
            [<Config.Form>]
            MaidenName: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The individual's phone number.
            [<Config.Form>]
            Phone: string option
            /// Indicates if the person or any of their representatives, family members, or other closely related persons, declares that they hold or have held an important public job or function, in any jurisdiction.
            [<Config.Form>]
            PoliticalExposure: Create'IndividualPoliticalExposure option
            /// The individual's registered address.
            [<Config.Form>]
            RegisteredAddress: Create'IndividualRegisteredAddress option
            /// Describes the person’s relationship to the account.
            [<Config.Form>]
            Relationship: Create'IndividualRelationship option
            /// The last four digits of the individual's Social Security Number (U.S. only).
            [<Config.Form>]
            SsnLast4: string option
            /// The individual's verification document information.
            [<Config.Form>]
            Verification: Create'IndividualVerification option
        }

    module Create'Individual =
        let create
            (
                address: Create'IndividualAddress option,
                addressKana: Create'IndividualAddressKana option,
                addressKanji: Create'IndividualAddressKanji option,
                dob: Choice<Create'IndividualDobDateOfBirthSpecs,string> option,
                email: string option,
                firstName: string option,
                firstNameKana: string option,
                firstNameKanji: string option,
                fullNameAliases: Choice<string list,string> option,
                gender: string option,
                idNumber: string option,
                idNumberSecondary: string option,
                lastName: string option,
                lastNameKana: string option,
                lastNameKanji: string option,
                maidenName: string option,
                metadata: Map<string, string> option,
                phone: string option,
                politicalExposure: Create'IndividualPoliticalExposure option,
                registeredAddress: Create'IndividualRegisteredAddress option,
                relationship: Create'IndividualRelationship option,
                ssnLast4: string option,
                verification: Create'IndividualVerification option
            ) : Create'Individual
            =
            {
              Address = address
              AddressKana = addressKana
              AddressKanji = addressKanji
              Dob = dob
              Email = email
              FirstName = firstName
              FirstNameKana = firstNameKana
              FirstNameKanji = firstNameKanji
              FullNameAliases = fullNameAliases
              Gender = gender
              IdNumber = idNumber
              IdNumberSecondary = idNumberSecondary
              LastName = lastName
              LastNameKana = lastNameKana
              LastNameKanji = lastNameKanji
              MaidenName = maidenName
              Metadata = metadata
              Phone = phone
              PoliticalExposure = politicalExposure
              RegisteredAddress = registeredAddress
              Relationship = relationship
              SsnLast4 = ssnLast4
              Verification = verification
            }

    type Create'SettingsBacsDebitPayments =
        {
            /// The Bacs Direct Debit Display Name for this account. For payments made with Bacs Direct Debit, this name appears on the mandate as the statement descriptor. Mobile banking apps display it as the name of the business. To use custom branding, set the Bacs Direct Debit Display Name during or right after creation. Custom branding incurs an additional monthly fee for the platform. If you don't set the display name before requesting Bacs capability, it's automatically set as "Stripe" and the account is onboarded to Stripe branding, which is free.
            [<Config.Form>]
            DisplayName: string option
        }

    module Create'SettingsBacsDebitPayments =
        let create
            (
                displayName: string option
            ) : Create'SettingsBacsDebitPayments
            =
            {
              DisplayName = displayName
            }

    type Create'SettingsBranding =
        {
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) An icon for the account. Must be square and at least 128px x 128px.
            [<Config.Form>]
            Icon: string option
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) A logo for the account that will be used in Checkout instead of the icon and without the account's name next to it if provided. Must be at least 128px x 128px.
            [<Config.Form>]
            Logo: string option
            /// A CSS hex color value representing the primary branding color for this account.
            [<Config.Form>]
            PrimaryColor: string option
            /// A CSS hex color value representing the secondary branding color for this account.
            [<Config.Form>]
            SecondaryColor: string option
        }

    module Create'SettingsBranding =
        let create
            (
                icon: string option,
                logo: string option,
                primaryColor: string option,
                secondaryColor: string option
            ) : Create'SettingsBranding
            =
            {
              Icon = icon
              Logo = logo
              PrimaryColor = primaryColor
              SecondaryColor = secondaryColor
            }

    type Create'SettingsCardIssuingTosAcceptance =
        {
            /// The Unix timestamp marking when the account representative accepted the service agreement.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the account representative accepted the service agreement.
            [<Config.Form>]
            Ip: string option
            /// The user agent of the browser from which the account representative accepted the service agreement.
            [<Config.Form>]
            UserAgent: Choice<string,string> option
        }

    module Create'SettingsCardIssuingTosAcceptance =
        let create
            (
                date: DateTime option,
                ip: string option,
                userAgent: Choice<string,string> option
            ) : Create'SettingsCardIssuingTosAcceptance
            =
            {
              Date = date
              Ip = ip
              UserAgent = userAgent
            }

    type Create'SettingsCardIssuing =
        {
            /// Details on the account's acceptance of the [Stripe Issuing Terms and Disclosures](/issuing/connect/tos_acceptance).
            [<Config.Form>]
            TosAcceptance: Create'SettingsCardIssuingTosAcceptance option
        }

    module Create'SettingsCardIssuing =
        let create
            (
                tosAcceptance: Create'SettingsCardIssuingTosAcceptance option
            ) : Create'SettingsCardIssuing
            =
            {
              TosAcceptance = tosAcceptance
            }

    type Create'SettingsCardPaymentsDeclineOn =
        {
            /// Whether Stripe automatically declines charges with an incorrect ZIP or postal code. This setting only applies when a ZIP or postal code is provided and they fail bank verification.
            [<Config.Form>]
            AvsFailure: bool option
            /// Whether Stripe automatically declines charges with an incorrect CVC. This setting only applies when a CVC is provided and it fails bank verification.
            [<Config.Form>]
            CvcFailure: bool option
        }

    module Create'SettingsCardPaymentsDeclineOn =
        let create
            (
                avsFailure: bool option,
                cvcFailure: bool option
            ) : Create'SettingsCardPaymentsDeclineOn
            =
            {
              AvsFailure = avsFailure
              CvcFailure = cvcFailure
            }

    type Create'SettingsCardPayments =
        {
            /// Automatically declines certain charge types regardless of whether the card issuer accepted or declined the charge.
            [<Config.Form>]
            DeclineOn: Create'SettingsCardPaymentsDeclineOn option
            /// The default text that appears on credit card statements when a charge is made. This field prefixes any dynamic `statement_descriptor` specified on the charge. `statement_descriptor_prefix` is useful for maximizing descriptor space for the dynamic portion.
            [<Config.Form>]
            StatementDescriptorPrefix: string option
            /// The Kana variation of the default text that appears on credit card statements when a charge is made (Japan only). This field prefixes any dynamic `statement_descriptor_suffix_kana` specified on the charge. `statement_descriptor_prefix_kana` is useful for maximizing descriptor space for the dynamic portion.
            [<Config.Form>]
            StatementDescriptorPrefixKana: Choice<string,string> option
            /// The Kanji variation of the default text that appears on credit card statements when a charge is made (Japan only). This field prefixes any dynamic `statement_descriptor_suffix_kanji` specified on the charge. `statement_descriptor_prefix_kanji` is useful for maximizing descriptor space for the dynamic portion.
            [<Config.Form>]
            StatementDescriptorPrefixKanji: Choice<string,string> option
        }

    module Create'SettingsCardPayments =
        let create
            (
                declineOn: Create'SettingsCardPaymentsDeclineOn option,
                statementDescriptorPrefix: string option,
                statementDescriptorPrefixKana: Choice<string,string> option,
                statementDescriptorPrefixKanji: Choice<string,string> option
            ) : Create'SettingsCardPayments
            =
            {
              DeclineOn = declineOn
              StatementDescriptorPrefix = statementDescriptorPrefix
              StatementDescriptorPrefixKana = statementDescriptorPrefixKana
              StatementDescriptorPrefixKanji = statementDescriptorPrefixKanji
            }

    type Create'SettingsInvoicesHostedPaymentMethodSave =
        | Always
        | Never
        | Offer

    type Create'SettingsInvoices =
        {
            /// Whether to save the payment method after a payment is completed for a one-time invoice or a subscription invoice when the customer already has a default payment method on the hosted invoice page.
            [<Config.Form>]
            HostedPaymentMethodSave: Create'SettingsInvoicesHostedPaymentMethodSave option
        }

    module Create'SettingsInvoices =
        let create
            (
                hostedPaymentMethodSave: Create'SettingsInvoicesHostedPaymentMethodSave option
            ) : Create'SettingsInvoices
            =
            {
              HostedPaymentMethodSave = hostedPaymentMethodSave
            }

    type Create'SettingsPayments =
        {
            /// The default text that appears on statements for non-card charges outside of Japan. For card charges, if you don't set a `statement_descriptor_prefix`, this text is also used as the statement descriptor prefix. In that case, if concatenating the statement descriptor suffix causes the combined statement descriptor to exceed 22 characters, we truncate the `statement_descriptor` text to limit the full descriptor to 22 characters. For more information about statement descriptors and their requirements, see the [account settings documentation](https://docs.stripe.com/get-started/account/statement-descriptors).
            [<Config.Form>]
            StatementDescriptor: string option
            /// The Kana variation of `statement_descriptor` used for charges in Japan. Japanese statement descriptors have [special requirements](https://docs.stripe.com/get-started/account/statement-descriptors#set-japanese-statement-descriptors).
            [<Config.Form>]
            StatementDescriptorKana: string option
            /// The Kanji variation of `statement_descriptor` used for charges in Japan. Japanese statement descriptors have [special requirements](https://docs.stripe.com/get-started/account/statement-descriptors#set-japanese-statement-descriptors).
            [<Config.Form>]
            StatementDescriptorKanji: string option
        }

    module Create'SettingsPayments =
        let create
            (
                statementDescriptor: string option,
                statementDescriptorKana: string option,
                statementDescriptorKanji: string option
            ) : Create'SettingsPayments
            =
            {
              StatementDescriptor = statementDescriptor
              StatementDescriptorKana = statementDescriptorKana
              StatementDescriptorKanji = statementDescriptorKanji
            }

    type Create'SettingsPayoutsScheduleDelayDays = | Minimum

    type Create'SettingsPayoutsScheduleInterval =
        | Daily
        | Manual
        | Monthly
        | Weekly

    type Create'SettingsPayoutsScheduleWeeklyAnchor =
        | Friday
        | Monday
        | Saturday
        | Sunday
        | Thursday
        | Tuesday
        | Wednesday

    type Create'SettingsPayoutsScheduleWeeklyPayoutDays =
        | Friday
        | Monday
        | Thursday
        | Tuesday
        | Wednesday

    type Create'SettingsPayoutsSchedule =
        {
            /// The number of days charge funds are held before being paid out. May also be set to `minimum`, representing the lowest available value for the account country. Default is `minimum`. The `delay_days` parameter remains at the last configured value if `interval` is `manual`. [Learn more about controlling payout delay days](/connect/manage-payout-schedule).
            [<Config.Form>]
            DelayDays: Choice<Create'SettingsPayoutsScheduleDelayDays,int> option
            /// How frequently available funds are paid out. One of: `daily`, `manual`, `weekly`, or `monthly`. Default is `daily`.
            [<Config.Form>]
            Interval: Create'SettingsPayoutsScheduleInterval option
            /// The day of the month when available funds are paid out, specified as a number between 1--31. Payouts nominally scheduled between the 29th and 31st of the month are instead sent on the last day of a shorter month. Required and applicable only if `interval` is `monthly`.
            [<Config.Form>]
            MonthlyAnchor: int option
            /// The days of the month when available funds are paid out, specified as an array of numbers between 1--31. Payouts nominally scheduled between the 29th and 31st of the month are instead sent on the last day of a shorter month. Required and applicable only if `interval` is `monthly` and `monthly_anchor` is not set.
            [<Config.Form>]
            MonthlyPayoutDays: int list option
            /// The day of the week when available funds are paid out, specified as `monday`, `tuesday`, etc. Required and applicable only if `interval` is `weekly`.
            [<Config.Form>]
            WeeklyAnchor: Create'SettingsPayoutsScheduleWeeklyAnchor option
            /// The days of the week when available funds are paid out, specified as an array, e.g., [`monday`, `tuesday`]. Required and applicable only if `interval` is `weekly`.
            [<Config.Form>]
            WeeklyPayoutDays: Create'SettingsPayoutsScheduleWeeklyPayoutDays list option
        }

    module Create'SettingsPayoutsSchedule =
        let create
            (
                delayDays: Choice<Create'SettingsPayoutsScheduleDelayDays,int> option,
                interval: Create'SettingsPayoutsScheduleInterval option,
                monthlyAnchor: int option,
                monthlyPayoutDays: int list option,
                weeklyAnchor: Create'SettingsPayoutsScheduleWeeklyAnchor option,
                weeklyPayoutDays: Create'SettingsPayoutsScheduleWeeklyPayoutDays list option
            ) : Create'SettingsPayoutsSchedule
            =
            {
              DelayDays = delayDays
              Interval = interval
              MonthlyAnchor = monthlyAnchor
              MonthlyPayoutDays = monthlyPayoutDays
              WeeklyAnchor = weeklyAnchor
              WeeklyPayoutDays = weeklyPayoutDays
            }

    type Create'SettingsPayouts =
        {
            /// A Boolean indicating whether Stripe should try to reclaim negative balances from an attached bank account. For details, see [Understanding Connect Account Balances](/connect/account-balances).
            [<Config.Form>]
            DebitNegativeBalances: bool option
            /// Details on when funds from charges are available, and when they are paid out to an external account. For details, see our [Setting Bank and Debit Card Payouts](/connect/bank-transfers#payout-information) documentation.
            [<Config.Form>]
            Schedule: Create'SettingsPayoutsSchedule option
            /// The text that appears on the bank account statement for payouts. If not set, this defaults to the platform's bank descriptor as set in the Dashboard.
            [<Config.Form>]
            StatementDescriptor: string option
        }

    module Create'SettingsPayouts =
        let create
            (
                debitNegativeBalances: bool option,
                schedule: Create'SettingsPayoutsSchedule option,
                statementDescriptor: string option
            ) : Create'SettingsPayouts
            =
            {
              DebitNegativeBalances = debitNegativeBalances
              Schedule = schedule
              StatementDescriptor = statementDescriptor
            }

    type Create'SettingsTreasuryTosAcceptance =
        {
            /// The Unix timestamp marking when the account representative accepted the service agreement.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the account representative accepted the service agreement.
            [<Config.Form>]
            Ip: string option
            /// The user agent of the browser from which the account representative accepted the service agreement.
            [<Config.Form>]
            UserAgent: Choice<string,string> option
        }

    module Create'SettingsTreasuryTosAcceptance =
        let create
            (
                date: DateTime option,
                ip: string option,
                userAgent: Choice<string,string> option
            ) : Create'SettingsTreasuryTosAcceptance
            =
            {
              Date = date
              Ip = ip
              UserAgent = userAgent
            }

    type Create'SettingsTreasury =
        {
            /// Details on the account's acceptance of the Stripe Treasury Services Agreement.
            [<Config.Form>]
            TosAcceptance: Create'SettingsTreasuryTosAcceptance option
        }

    module Create'SettingsTreasury =
        let create
            (
                tosAcceptance: Create'SettingsTreasuryTosAcceptance option
            ) : Create'SettingsTreasury
            =
            {
              TosAcceptance = tosAcceptance
            }

    type Create'Settings =
        {
            /// Settings specific to Bacs Direct Debit.
            [<Config.Form>]
            BacsDebitPayments: Create'SettingsBacsDebitPayments option
            /// Settings used to apply the account's branding to email receipts, invoices, Checkout, and other products.
            [<Config.Form>]
            Branding: Create'SettingsBranding option
            /// Settings specific to the account's use of the Card Issuing product.
            [<Config.Form>]
            CardIssuing: Create'SettingsCardIssuing option
            /// Settings specific to card charging on the account.
            [<Config.Form>]
            CardPayments: Create'SettingsCardPayments option
            /// Settings specific to the account’s use of Invoices.
            [<Config.Form>]
            Invoices: Create'SettingsInvoices option
            /// Settings that apply across payment methods for charging on the account.
            [<Config.Form>]
            Payments: Create'SettingsPayments option
            /// Settings specific to the account's payouts.
            [<Config.Form>]
            Payouts: Create'SettingsPayouts option
            /// Settings specific to the account's Treasury FinancialAccounts.
            [<Config.Form>]
            Treasury: Create'SettingsTreasury option
        }

    module Create'Settings =
        let create
            (
                bacsDebitPayments: Create'SettingsBacsDebitPayments option,
                branding: Create'SettingsBranding option,
                cardIssuing: Create'SettingsCardIssuing option,
                cardPayments: Create'SettingsCardPayments option,
                invoices: Create'SettingsInvoices option,
                payments: Create'SettingsPayments option,
                payouts: Create'SettingsPayouts option,
                treasury: Create'SettingsTreasury option
            ) : Create'Settings
            =
            {
              BacsDebitPayments = bacsDebitPayments
              Branding = branding
              CardIssuing = cardIssuing
              CardPayments = cardPayments
              Invoices = invoices
              Payments = payments
              Payouts = payouts
              Treasury = treasury
            }

    type Create'TosAcceptance =
        {
            /// The Unix timestamp marking when the account representative accepted their service agreement.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the account representative accepted their service agreement.
            [<Config.Form>]
            Ip: string option
            /// The user's service agreement type.
            [<Config.Form>]
            ServiceAgreement: string option
            /// The user agent of the browser from which the account representative accepted their service agreement.
            [<Config.Form>]
            UserAgent: string option
        }

    module Create'TosAcceptance =
        let create
            (
                date: DateTime option,
                ip: string option,
                serviceAgreement: string option,
                userAgent: string option
            ) : Create'TosAcceptance
            =
            {
              Date = date
              Ip = ip
              ServiceAgreement = serviceAgreement
              UserAgent = userAgent
            }

    type Create'Type =
        | Custom
        | Express
        | Standard

    type CreateOptions =
        {
            /// An [account token](https://api.stripe.com#create_account_token), used to securely provide details to the account.
            [<Config.Form>]
            AccountToken: string option
            /// Business information about the account.
            [<Config.Form>]
            BusinessProfile: Create'BusinessProfile option
            /// The business type. Once you create an [Account Link](/api/account_links) or [Account Session](/api/account_sessions), this property can only be updated for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts.
            [<Config.Form>]
            BusinessType: Create'BusinessType option
            /// Each key of the dictionary represents a capability, and each capability
            /// maps to its settings (for example, whether it has been requested or not). Each
            /// capability is inactive until you have provided its specific
            /// requirements and Stripe has verified them. An account might have some
            /// of its requested capabilities be active and some be inactive.
            /// Required when [account.controller.stripe_dashboard.type](/api/accounts/create#create_account-controller-dashboard-type)
            /// is `none`, which includes Custom accounts.
            [<Config.Form>]
            Capabilities: Create'Capabilities option
            /// Information about the company or business. This field is available for any `business_type`. Once you create an [Account Link](/api/account_links) or [Account Session](/api/account_sessions), this property can only be updated for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts.
            [<Config.Form>]
            Company: Create'Company option
            /// A hash of configuration describing the account controller's attributes.
            [<Config.Form>]
            Controller: Create'Controller option
            /// The country in which the account holder resides, or in which the business is legally established. This should be an ISO 3166-1 alpha-2 country code. For example, if you are in the United States and the business for which you're creating an account is legally represented in Canada, you would use `CA` as the country for the account being created. Available countries include [Stripe's global markets](https://stripe.com/global) as well as countries where [cross-border payouts](https://stripe.com/docs/connect/cross-border-payouts) are supported.
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Three-letter ISO currency code representing the default currency for the account. This must be a currency that [Stripe supports in the account's country](https://docs.stripe.com/payouts).
            [<Config.Form>]
            DefaultCurrency: IsoTypes.IsoCurrencyCode option
            /// Documents that may be submitted to satisfy various informational requests.
            [<Config.Form>]
            Documents: Create'Documents option
            /// The email address of the account holder. This is only to make the account easier to identify to you. If [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts, Stripe doesn't email the account without your consent.
            [<Config.Form>]
            Email: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A card or bank account to attach to the account for receiving [payouts](/connect/bank-debit-card-payouts) (you won’t be able to use it for top-ups). You can provide either a token, like the ones returned by [Stripe.js](/js), or a dictionary, as documented in the `external_account` parameter for [bank account](/api#account_create_bank_account) creation. <br><br>By default, providing an external account sets it as the new default external account for its currency, and deletes the old default if one exists. To add additional external accounts without replacing the existing default for the currency, use the [bank account](/api#account_create_bank_account) or [card creation](/api#account_create_card) APIs. After you create an [Account Link](/api/account_links) or [Account Session](/api/account_sessions), this property can only be updated for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts.
            [<Config.Form>]
            ExternalAccount: string option
            /// A hash of account group type to tokens. These are account groups this account should be added to.
            [<Config.Form>]
            Groups: Create'Groups option
            /// Information about the person represented by the account. This field is null unless `business_type` is set to `individual`. Once you create an [Account Link](/api/account_links) or [Account Session](/api/account_sessions), this property can only be updated for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts.
            [<Config.Form>]
            Individual: Create'Individual option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Options for customizing how the account functions within Stripe.
            [<Config.Form>]
            Settings: Create'Settings option
            /// Details on the account's acceptance of the [Stripe Services Agreement](/connect/updating-accounts#tos-acceptance). This property can only be updated for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts. This property defaults to a `full` service agreement when empty.
            [<Config.Form>]
            TosAcceptance: Create'TosAcceptance option
            /// The `type` parameter is deprecated. Use [`controller`](/api/accounts/create#create_account-controller) instead to configure dashboard access, fee payer, loss liability, and requirement collection.
            [<Config.Form>]
            Type: Create'Type option
        }

    module CreateOptions =
        let create
            (
                accountToken: string option,
                businessProfile: Create'BusinessProfile option,
                businessType: Create'BusinessType option,
                capabilities: Create'Capabilities option,
                company: Create'Company option,
                controller: Create'Controller option,
                country: IsoTypes.IsoCountryCode option,
                defaultCurrency: IsoTypes.IsoCurrencyCode option,
                documents: Create'Documents option,
                email: string option,
                expand: string list option,
                externalAccount: string option,
                groups: Create'Groups option,
                individual: Create'Individual option,
                metadata: Map<string, string> option,
                settings: Create'Settings option,
                tosAcceptance: Create'TosAcceptance option,
                ``type``: Create'Type option
            ) : CreateOptions
            =
            {
              AccountToken = accountToken
              BusinessProfile = businessProfile
              BusinessType = businessType
              Capabilities = capabilities
              Company = company
              Controller = controller
              Country = country
              DefaultCurrency = defaultCurrency
              Documents = documents
              Email = email
              Expand = expand
              ExternalAccount = externalAccount
              Groups = groups
              Individual = individual
              Metadata = metadata
              Settings = settings
              TosAcceptance = tosAcceptance
              Type = ``type``
            }

    type DeleteOptions =
        { [<Config.Path>]
          Account: string }

    module DeleteOptions =
        let create
            (
                account: string
            ) : DeleteOptions
            =
            {
              Account = account
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Account: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    module RetrieveOptions =
        let create
            (
                account: string
            ) : RetrieveOptions
            =
            {
              Account = account
              Expand = None
            }

    type Update'BusinessProfileAnnualRevenue =
        {
            /// A non-negative integer representing the amount in the [smallest currency unit](/currencies#zero-decimal).
            [<Config.Form>]
            Amount: int option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The close-out date of the preceding fiscal year in ISO 8601 format. E.g. 2023-12-31 for the 31st of December, 2023.
            [<Config.Form>]
            FiscalYearEnd: string option
        }

    module Update'BusinessProfileAnnualRevenue =
        let create
            (
                amount: int option,
                currency: IsoTypes.IsoCurrencyCode option,
                fiscalYearEnd: string option
            ) : Update'BusinessProfileAnnualRevenue
            =
            {
              Amount = amount
              Currency = currency
              FiscalYearEnd = fiscalYearEnd
            }

    type Update'BusinessProfileMinorityOwnedBusinessDesignation =
        | LgbtqiOwnedBusiness
        | MinorityOwnedBusiness
        | None'OfTheseApply
        | PreferNotToAnswer
        | WomenOwnedBusiness

    type Update'BusinessProfileMonthlyEstimatedRevenue =
        {
            /// A non-negative integer representing how much to charge in the [smallest currency unit](/currencies#zero-decimal).
            [<Config.Form>]
            Amount: int option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
        }

    module Update'BusinessProfileMonthlyEstimatedRevenue =
        let create
            (
                amount: int option,
                currency: IsoTypes.IsoCurrencyCode option
            ) : Update'BusinessProfileMonthlyEstimatedRevenue
            =
            {
              Amount = amount
              Currency = currency
            }

    type Update'BusinessProfileSupportAddress =
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

    module Update'BusinessProfileSupportAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Update'BusinessProfileSupportAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Update'BusinessProfile =
        {
            /// The applicant's gross annual revenue for its preceding fiscal year.
            [<Config.Form>]
            AnnualRevenue: Update'BusinessProfileAnnualRevenue option
            /// An estimated upper bound of employees, contractors, vendors, etc. currently working for the business.
            [<Config.Form>]
            EstimatedWorkerCount: int option
            /// [The merchant category code for the account](/connect/setting-mcc). MCCs are used to classify businesses based on the goods or services they provide.
            [<Config.Form>]
            Mcc: string option
            /// Whether the business is a minority-owned, women-owned, and/or LGBTQI+ -owned business.
            [<Config.Form>]
            MinorityOwnedBusinessDesignation: Update'BusinessProfileMinorityOwnedBusinessDesignation list option
            /// An estimate of the monthly revenue of the business. Only accepted for accounts in Brazil and India.
            [<Config.Form>]
            MonthlyEstimatedRevenue: Update'BusinessProfileMonthlyEstimatedRevenue option
            /// The customer-facing business name.
            [<Config.Form>]
            Name: string option
            /// Internal-only description of the product sold by, or service provided by, the business. Used by Stripe for risk and underwriting purposes.
            [<Config.Form>]
            ProductDescription: string option
            /// A publicly available mailing address for sending support issues to.
            [<Config.Form>]
            SupportAddress: Update'BusinessProfileSupportAddress option
            /// A publicly available email address for sending support issues to.
            [<Config.Form>]
            SupportEmail: string option
            /// A publicly available phone number to call with support issues.
            [<Config.Form>]
            SupportPhone: string option
            /// A publicly available website for handling support issues.
            [<Config.Form>]
            SupportUrl: Choice<string,string> option
            /// The business's publicly available website.
            [<Config.Form>]
            Url: string option
        }

    module Update'BusinessProfile =
        let create
            (
                annualRevenue: Update'BusinessProfileAnnualRevenue option,
                estimatedWorkerCount: int option,
                mcc: string option,
                minorityOwnedBusinessDesignation: Update'BusinessProfileMinorityOwnedBusinessDesignation list option,
                monthlyEstimatedRevenue: Update'BusinessProfileMonthlyEstimatedRevenue option,
                name: string option,
                productDescription: string option,
                supportAddress: Update'BusinessProfileSupportAddress option,
                supportEmail: string option,
                supportPhone: string option,
                supportUrl: Choice<string,string> option,
                url: string option
            ) : Update'BusinessProfile
            =
            {
              AnnualRevenue = annualRevenue
              EstimatedWorkerCount = estimatedWorkerCount
              Mcc = mcc
              MinorityOwnedBusinessDesignation = minorityOwnedBusinessDesignation
              MonthlyEstimatedRevenue = monthlyEstimatedRevenue
              Name = name
              ProductDescription = productDescription
              SupportAddress = supportAddress
              SupportEmail = supportEmail
              SupportPhone = supportPhone
              SupportUrl = supportUrl
              Url = url
            }

    type Update'BusinessType =
        | Company
        | GovernmentEntity
        | Individual
        | NonProfit

    type Update'CapabilitiesAcssDebitPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesAcssDebitPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesAcssDebitPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesAffirmPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesAffirmPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesAffirmPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesAfterpayClearpayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesAfterpayClearpayPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesAfterpayClearpayPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesAlmaPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesAlmaPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesAlmaPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesAmazonPayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesAmazonPayPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesAmazonPayPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesAppDistribution =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesAppDistribution =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesAppDistribution
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesAuBecsDebitPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesAuBecsDebitPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesAuBecsDebitPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesBacsDebitPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesBacsDebitPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesBacsDebitPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesBancontactPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesBancontactPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesBancontactPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesBankTransferPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesBankTransferPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesBankTransferPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesBilliePayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesBilliePayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesBilliePayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesBlikPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesBlikPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesBlikPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesBoletoPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesBoletoPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesBoletoPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesCardIssuing =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesCardIssuing =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesCardIssuing
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesCardPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesCardPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesCardPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesCartesBancairesPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesCartesBancairesPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesCartesBancairesPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesCashappPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesCashappPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesCashappPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesCryptoPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesCryptoPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesCryptoPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesEpsPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesEpsPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesEpsPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesFpxPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesFpxPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesFpxPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesGbBankTransferPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesGbBankTransferPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesGbBankTransferPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesGiropayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesGiropayPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesGiropayPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesGrabpayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesGrabpayPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesGrabpayPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesIdealPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesIdealPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesIdealPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesIndiaInternationalPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesIndiaInternationalPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesIndiaInternationalPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesJcbPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesJcbPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesJcbPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesJpBankTransferPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesJpBankTransferPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesJpBankTransferPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesKakaoPayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesKakaoPayPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesKakaoPayPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesKlarnaPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesKlarnaPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesKlarnaPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesKonbiniPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesKonbiniPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesKonbiniPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesKrCardPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesKrCardPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesKrCardPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesLegacyPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesLegacyPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesLegacyPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesLinkPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesLinkPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesLinkPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesMbWayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesMbWayPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesMbWayPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesMobilepayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesMobilepayPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesMobilepayPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesMultibancoPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesMultibancoPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesMultibancoPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesMxBankTransferPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesMxBankTransferPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesMxBankTransferPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesNaverPayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesNaverPayPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesNaverPayPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesNzBankAccountBecsDebitPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesNzBankAccountBecsDebitPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesNzBankAccountBecsDebitPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesOxxoPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesOxxoPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesOxxoPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesP24Payments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesP24Payments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesP24Payments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesPayByBankPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesPayByBankPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesPayByBankPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesPaycoPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesPaycoPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesPaycoPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesPaynowPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesPaynowPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesPaynowPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesPaytoPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesPaytoPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesPaytoPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesPixPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesPixPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesPixPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesPromptpayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesPromptpayPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesPromptpayPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesRevolutPayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesRevolutPayPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesRevolutPayPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesSamsungPayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesSamsungPayPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesSamsungPayPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesSatispayPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesSatispayPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesSatispayPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesSepaBankTransferPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesSepaBankTransferPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesSepaBankTransferPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesSepaDebitPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesSepaDebitPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesSepaDebitPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesSofortPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesSofortPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesSofortPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesSunbitPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesSunbitPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesSunbitPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesSwishPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesSwishPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesSwishPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesTaxReportingUs1099K =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesTaxReportingUs1099K =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesTaxReportingUs1099K
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesTaxReportingUs1099Misc =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesTaxReportingUs1099Misc =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesTaxReportingUs1099Misc
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesTransfers =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesTransfers =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesTransfers
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesTreasury =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesTreasury =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesTreasury
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesTwintPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesTwintPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesTwintPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesUpiPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesUpiPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesUpiPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesUsBankAccountAchPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesUsBankAccountAchPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesUsBankAccountAchPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesUsBankTransferPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesUsBankTransferPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesUsBankTransferPayments
            =
            {
              Requested = requested
            }

    type Update'CapabilitiesZipPayments =
        {
            /// Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
            [<Config.Form>]
            Requested: bool option
        }

    module Update'CapabilitiesZipPayments =
        let create
            (
                requested: bool option
            ) : Update'CapabilitiesZipPayments
            =
            {
              Requested = requested
            }

    type Update'Capabilities =
        {
            /// The acss_debit_payments capability.
            [<Config.Form>]
            AcssDebitPayments: Update'CapabilitiesAcssDebitPayments option
            /// The affirm_payments capability.
            [<Config.Form>]
            AffirmPayments: Update'CapabilitiesAffirmPayments option
            /// The afterpay_clearpay_payments capability.
            [<Config.Form>]
            AfterpayClearpayPayments: Update'CapabilitiesAfterpayClearpayPayments option
            /// The alma_payments capability.
            [<Config.Form>]
            AlmaPayments: Update'CapabilitiesAlmaPayments option
            /// The amazon_pay_payments capability.
            [<Config.Form>]
            AmazonPayPayments: Update'CapabilitiesAmazonPayPayments option
            /// The app_distribution capability.
            [<Config.Form>]
            AppDistribution: Update'CapabilitiesAppDistribution option
            /// The au_becs_debit_payments capability.
            [<Config.Form>]
            AuBecsDebitPayments: Update'CapabilitiesAuBecsDebitPayments option
            /// The bacs_debit_payments capability.
            [<Config.Form>]
            BacsDebitPayments: Update'CapabilitiesBacsDebitPayments option
            /// The bancontact_payments capability.
            [<Config.Form>]
            BancontactPayments: Update'CapabilitiesBancontactPayments option
            /// The bank_transfer_payments capability.
            [<Config.Form>]
            BankTransferPayments: Update'CapabilitiesBankTransferPayments option
            /// The billie_payments capability.
            [<Config.Form>]
            BilliePayments: Update'CapabilitiesBilliePayments option
            /// The blik_payments capability.
            [<Config.Form>]
            BlikPayments: Update'CapabilitiesBlikPayments option
            /// The boleto_payments capability.
            [<Config.Form>]
            BoletoPayments: Update'CapabilitiesBoletoPayments option
            /// The card_issuing capability.
            [<Config.Form>]
            CardIssuing: Update'CapabilitiesCardIssuing option
            /// The card_payments capability.
            [<Config.Form>]
            CardPayments: Update'CapabilitiesCardPayments option
            /// The cartes_bancaires_payments capability.
            [<Config.Form>]
            CartesBancairesPayments: Update'CapabilitiesCartesBancairesPayments option
            /// The cashapp_payments capability.
            [<Config.Form>]
            CashappPayments: Update'CapabilitiesCashappPayments option
            /// The crypto_payments capability.
            [<Config.Form>]
            CryptoPayments: Update'CapabilitiesCryptoPayments option
            /// The eps_payments capability.
            [<Config.Form>]
            EpsPayments: Update'CapabilitiesEpsPayments option
            /// The fpx_payments capability.
            [<Config.Form>]
            FpxPayments: Update'CapabilitiesFpxPayments option
            /// The gb_bank_transfer_payments capability.
            [<Config.Form>]
            GbBankTransferPayments: Update'CapabilitiesGbBankTransferPayments option
            /// The giropay_payments capability.
            [<Config.Form>]
            GiropayPayments: Update'CapabilitiesGiropayPayments option
            /// The grabpay_payments capability.
            [<Config.Form>]
            GrabpayPayments: Update'CapabilitiesGrabpayPayments option
            /// The ideal_payments capability.
            [<Config.Form>]
            IdealPayments: Update'CapabilitiesIdealPayments option
            /// The india_international_payments capability.
            [<Config.Form>]
            IndiaInternationalPayments: Update'CapabilitiesIndiaInternationalPayments option
            /// The jcb_payments capability.
            [<Config.Form>]
            JcbPayments: Update'CapabilitiesJcbPayments option
            /// The jp_bank_transfer_payments capability.
            [<Config.Form>]
            JpBankTransferPayments: Update'CapabilitiesJpBankTransferPayments option
            /// The kakao_pay_payments capability.
            [<Config.Form>]
            KakaoPayPayments: Update'CapabilitiesKakaoPayPayments option
            /// The klarna_payments capability.
            [<Config.Form>]
            KlarnaPayments: Update'CapabilitiesKlarnaPayments option
            /// The konbini_payments capability.
            [<Config.Form>]
            KonbiniPayments: Update'CapabilitiesKonbiniPayments option
            /// The kr_card_payments capability.
            [<Config.Form>]
            KrCardPayments: Update'CapabilitiesKrCardPayments option
            /// The legacy_payments capability.
            [<Config.Form>]
            LegacyPayments: Update'CapabilitiesLegacyPayments option
            /// The link_payments capability.
            [<Config.Form>]
            LinkPayments: Update'CapabilitiesLinkPayments option
            /// The mb_way_payments capability.
            [<Config.Form>]
            MbWayPayments: Update'CapabilitiesMbWayPayments option
            /// The mobilepay_payments capability.
            [<Config.Form>]
            MobilepayPayments: Update'CapabilitiesMobilepayPayments option
            /// The multibanco_payments capability.
            [<Config.Form>]
            MultibancoPayments: Update'CapabilitiesMultibancoPayments option
            /// The mx_bank_transfer_payments capability.
            [<Config.Form>]
            MxBankTransferPayments: Update'CapabilitiesMxBankTransferPayments option
            /// The naver_pay_payments capability.
            [<Config.Form>]
            NaverPayPayments: Update'CapabilitiesNaverPayPayments option
            /// The nz_bank_account_becs_debit_payments capability.
            [<Config.Form>]
            NzBankAccountBecsDebitPayments: Update'CapabilitiesNzBankAccountBecsDebitPayments option
            /// The oxxo_payments capability.
            [<Config.Form>]
            OxxoPayments: Update'CapabilitiesOxxoPayments option
            /// The p24_payments capability.
            [<Config.Form>]
            P24Payments: Update'CapabilitiesP24Payments option
            /// The pay_by_bank_payments capability.
            [<Config.Form>]
            PayByBankPayments: Update'CapabilitiesPayByBankPayments option
            /// The payco_payments capability.
            [<Config.Form>]
            PaycoPayments: Update'CapabilitiesPaycoPayments option
            /// The paynow_payments capability.
            [<Config.Form>]
            PaynowPayments: Update'CapabilitiesPaynowPayments option
            /// The payto_payments capability.
            [<Config.Form>]
            PaytoPayments: Update'CapabilitiesPaytoPayments option
            /// The pix_payments capability.
            [<Config.Form>]
            PixPayments: Update'CapabilitiesPixPayments option
            /// The promptpay_payments capability.
            [<Config.Form>]
            PromptpayPayments: Update'CapabilitiesPromptpayPayments option
            /// The revolut_pay_payments capability.
            [<Config.Form>]
            RevolutPayPayments: Update'CapabilitiesRevolutPayPayments option
            /// The samsung_pay_payments capability.
            [<Config.Form>]
            SamsungPayPayments: Update'CapabilitiesSamsungPayPayments option
            /// The satispay_payments capability.
            [<Config.Form>]
            SatispayPayments: Update'CapabilitiesSatispayPayments option
            /// The sepa_bank_transfer_payments capability.
            [<Config.Form>]
            SepaBankTransferPayments: Update'CapabilitiesSepaBankTransferPayments option
            /// The sepa_debit_payments capability.
            [<Config.Form>]
            SepaDebitPayments: Update'CapabilitiesSepaDebitPayments option
            /// The sofort_payments capability.
            [<Config.Form>]
            SofortPayments: Update'CapabilitiesSofortPayments option
            /// The sunbit_payments capability.
            [<Config.Form>]
            SunbitPayments: Update'CapabilitiesSunbitPayments option
            /// The swish_payments capability.
            [<Config.Form>]
            SwishPayments: Update'CapabilitiesSwishPayments option
            /// The tax_reporting_us_1099_k capability.
            [<Config.Form>]
            TaxReportingUs1099K: Update'CapabilitiesTaxReportingUs1099K option
            /// The tax_reporting_us_1099_misc capability.
            [<Config.Form>]
            TaxReportingUs1099Misc: Update'CapabilitiesTaxReportingUs1099Misc option
            /// The transfers capability.
            [<Config.Form>]
            Transfers: Update'CapabilitiesTransfers option
            /// The treasury capability.
            [<Config.Form>]
            Treasury: Update'CapabilitiesTreasury option
            /// The twint_payments capability.
            [<Config.Form>]
            TwintPayments: Update'CapabilitiesTwintPayments option
            /// The upi_payments capability.
            [<Config.Form>]
            UpiPayments: Update'CapabilitiesUpiPayments option
            /// The us_bank_account_ach_payments capability.
            [<Config.Form>]
            UsBankAccountAchPayments: Update'CapabilitiesUsBankAccountAchPayments option
            /// The us_bank_transfer_payments capability.
            [<Config.Form>]
            UsBankTransferPayments: Update'CapabilitiesUsBankTransferPayments option
            /// The zip_payments capability.
            [<Config.Form>]
            ZipPayments: Update'CapabilitiesZipPayments option
        }

    module Update'Capabilities =
        let create
            (
                acssDebitPayments: Update'CapabilitiesAcssDebitPayments option,
                affirmPayments: Update'CapabilitiesAffirmPayments option,
                afterpayClearpayPayments: Update'CapabilitiesAfterpayClearpayPayments option,
                almaPayments: Update'CapabilitiesAlmaPayments option,
                amazonPayPayments: Update'CapabilitiesAmazonPayPayments option,
                appDistribution: Update'CapabilitiesAppDistribution option,
                auBecsDebitPayments: Update'CapabilitiesAuBecsDebitPayments option,
                bacsDebitPayments: Update'CapabilitiesBacsDebitPayments option,
                bancontactPayments: Update'CapabilitiesBancontactPayments option,
                bankTransferPayments: Update'CapabilitiesBankTransferPayments option,
                billiePayments: Update'CapabilitiesBilliePayments option,
                blikPayments: Update'CapabilitiesBlikPayments option,
                boletoPayments: Update'CapabilitiesBoletoPayments option,
                cardIssuing: Update'CapabilitiesCardIssuing option,
                cardPayments: Update'CapabilitiesCardPayments option,
                cartesBancairesPayments: Update'CapabilitiesCartesBancairesPayments option,
                cashappPayments: Update'CapabilitiesCashappPayments option,
                cryptoPayments: Update'CapabilitiesCryptoPayments option,
                epsPayments: Update'CapabilitiesEpsPayments option,
                fpxPayments: Update'CapabilitiesFpxPayments option,
                gbBankTransferPayments: Update'CapabilitiesGbBankTransferPayments option,
                giropayPayments: Update'CapabilitiesGiropayPayments option,
                grabpayPayments: Update'CapabilitiesGrabpayPayments option,
                idealPayments: Update'CapabilitiesIdealPayments option,
                indiaInternationalPayments: Update'CapabilitiesIndiaInternationalPayments option,
                jcbPayments: Update'CapabilitiesJcbPayments option,
                jpBankTransferPayments: Update'CapabilitiesJpBankTransferPayments option,
                kakaoPayPayments: Update'CapabilitiesKakaoPayPayments option,
                klarnaPayments: Update'CapabilitiesKlarnaPayments option,
                konbiniPayments: Update'CapabilitiesKonbiniPayments option,
                krCardPayments: Update'CapabilitiesKrCardPayments option,
                legacyPayments: Update'CapabilitiesLegacyPayments option,
                linkPayments: Update'CapabilitiesLinkPayments option,
                mbWayPayments: Update'CapabilitiesMbWayPayments option,
                mobilepayPayments: Update'CapabilitiesMobilepayPayments option,
                multibancoPayments: Update'CapabilitiesMultibancoPayments option,
                mxBankTransferPayments: Update'CapabilitiesMxBankTransferPayments option,
                naverPayPayments: Update'CapabilitiesNaverPayPayments option,
                nzBankAccountBecsDebitPayments: Update'CapabilitiesNzBankAccountBecsDebitPayments option,
                oxxoPayments: Update'CapabilitiesOxxoPayments option,
                p24Payments: Update'CapabilitiesP24Payments option,
                payByBankPayments: Update'CapabilitiesPayByBankPayments option,
                paycoPayments: Update'CapabilitiesPaycoPayments option,
                paynowPayments: Update'CapabilitiesPaynowPayments option,
                paytoPayments: Update'CapabilitiesPaytoPayments option,
                pixPayments: Update'CapabilitiesPixPayments option,
                promptpayPayments: Update'CapabilitiesPromptpayPayments option,
                revolutPayPayments: Update'CapabilitiesRevolutPayPayments option,
                samsungPayPayments: Update'CapabilitiesSamsungPayPayments option,
                satispayPayments: Update'CapabilitiesSatispayPayments option,
                sepaBankTransferPayments: Update'CapabilitiesSepaBankTransferPayments option,
                sepaDebitPayments: Update'CapabilitiesSepaDebitPayments option,
                sofortPayments: Update'CapabilitiesSofortPayments option,
                sunbitPayments: Update'CapabilitiesSunbitPayments option,
                swishPayments: Update'CapabilitiesSwishPayments option,
                taxReportingUs1099K: Update'CapabilitiesTaxReportingUs1099K option,
                taxReportingUs1099Misc: Update'CapabilitiesTaxReportingUs1099Misc option,
                transfers: Update'CapabilitiesTransfers option,
                treasury: Update'CapabilitiesTreasury option,
                twintPayments: Update'CapabilitiesTwintPayments option,
                upiPayments: Update'CapabilitiesUpiPayments option,
                usBankAccountAchPayments: Update'CapabilitiesUsBankAccountAchPayments option,
                usBankTransferPayments: Update'CapabilitiesUsBankTransferPayments option,
                zipPayments: Update'CapabilitiesZipPayments option
            ) : Update'Capabilities
            =
            {
              AcssDebitPayments = acssDebitPayments
              AffirmPayments = affirmPayments
              AfterpayClearpayPayments = afterpayClearpayPayments
              AlmaPayments = almaPayments
              AmazonPayPayments = amazonPayPayments
              AppDistribution = appDistribution
              AuBecsDebitPayments = auBecsDebitPayments
              BacsDebitPayments = bacsDebitPayments
              BancontactPayments = bancontactPayments
              BankTransferPayments = bankTransferPayments
              BilliePayments = billiePayments
              BlikPayments = blikPayments
              BoletoPayments = boletoPayments
              CardIssuing = cardIssuing
              CardPayments = cardPayments
              CartesBancairesPayments = cartesBancairesPayments
              CashappPayments = cashappPayments
              CryptoPayments = cryptoPayments
              EpsPayments = epsPayments
              FpxPayments = fpxPayments
              GbBankTransferPayments = gbBankTransferPayments
              GiropayPayments = giropayPayments
              GrabpayPayments = grabpayPayments
              IdealPayments = idealPayments
              IndiaInternationalPayments = indiaInternationalPayments
              JcbPayments = jcbPayments
              JpBankTransferPayments = jpBankTransferPayments
              KakaoPayPayments = kakaoPayPayments
              KlarnaPayments = klarnaPayments
              KonbiniPayments = konbiniPayments
              KrCardPayments = krCardPayments
              LegacyPayments = legacyPayments
              LinkPayments = linkPayments
              MbWayPayments = mbWayPayments
              MobilepayPayments = mobilepayPayments
              MultibancoPayments = multibancoPayments
              MxBankTransferPayments = mxBankTransferPayments
              NaverPayPayments = naverPayPayments
              NzBankAccountBecsDebitPayments = nzBankAccountBecsDebitPayments
              OxxoPayments = oxxoPayments
              P24Payments = p24Payments
              PayByBankPayments = payByBankPayments
              PaycoPayments = paycoPayments
              PaynowPayments = paynowPayments
              PaytoPayments = paytoPayments
              PixPayments = pixPayments
              PromptpayPayments = promptpayPayments
              RevolutPayPayments = revolutPayPayments
              SamsungPayPayments = samsungPayPayments
              SatispayPayments = satispayPayments
              SepaBankTransferPayments = sepaBankTransferPayments
              SepaDebitPayments = sepaDebitPayments
              SofortPayments = sofortPayments
              SunbitPayments = sunbitPayments
              SwishPayments = swishPayments
              TaxReportingUs1099K = taxReportingUs1099K
              TaxReportingUs1099Misc = taxReportingUs1099Misc
              Transfers = transfers
              Treasury = treasury
              TwintPayments = twintPayments
              UpiPayments = upiPayments
              UsBankAccountAchPayments = usBankAccountAchPayments
              UsBankTransferPayments = usBankTransferPayments
              ZipPayments = zipPayments
            }

    type Update'CompanyAddress =
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

    module Update'CompanyAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Update'CompanyAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Update'CompanyAddressKana =
        {
            /// City or ward.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Block or building number.
            [<Config.Form>]
            Line1: string option
            /// Building details.
            [<Config.Form>]
            Line2: string option
            /// Postal code.
            [<Config.Form>]
            PostalCode: string option
            /// Prefecture.
            [<Config.Form>]
            State: string option
            /// Town or cho-me.
            [<Config.Form>]
            Town: string option
        }

    module Update'CompanyAddressKana =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option,
                town: string option
            ) : Update'CompanyAddressKana
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
              Town = town
            }

    type Update'CompanyAddressKanji =
        {
            /// City or ward.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Block or building number.
            [<Config.Form>]
            Line1: string option
            /// Building details.
            [<Config.Form>]
            Line2: string option
            /// Postal code.
            [<Config.Form>]
            PostalCode: string option
            /// Prefecture.
            [<Config.Form>]
            State: string option
            /// Town or cho-me.
            [<Config.Form>]
            Town: string option
        }

    module Update'CompanyAddressKanji =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option,
                town: string option
            ) : Update'CompanyAddressKanji
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
              Town = town
            }

    type Update'CompanyDirectorshipDeclaration =
        {
            /// The Unix timestamp marking when the directorship declaration attestation was made.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the directorship declaration attestation was made.
            [<Config.Form>]
            Ip: string option
            /// The user agent of the browser from which the directorship declaration attestation was made.
            [<Config.Form>]
            UserAgent: string option
        }

    module Update'CompanyDirectorshipDeclaration =
        let create
            (
                date: DateTime option,
                ip: string option,
                userAgent: string option
            ) : Update'CompanyDirectorshipDeclaration
            =
            {
              Date = date
              Ip = ip
              UserAgent = userAgent
            }

    type Update'CompanyOwnershipDeclaration =
        {
            /// The Unix timestamp marking when the beneficial owner attestation was made.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the beneficial owner attestation was made.
            [<Config.Form>]
            Ip: string option
            /// The user agent of the browser from which the beneficial owner attestation was made.
            [<Config.Form>]
            UserAgent: string option
        }

    module Update'CompanyOwnershipDeclaration =
        let create
            (
                date: DateTime option,
                ip: string option,
                userAgent: string option
            ) : Update'CompanyOwnershipDeclaration
            =
            {
              Date = date
              Ip = ip
              UserAgent = userAgent
            }

    type Update'CompanyOwnershipExemptionReason =
        | QualifiedEntityExceedsOwnershipThreshold
        | QualifiesAsFinancialInstitution

    type Update'CompanyRegistrationDateRegistrationDateSpecs =
        {
            /// The day of registration, between 1 and 31.
            [<Config.Form>]
            Day: int option
            /// The month of registration, between 1 and 12.
            [<Config.Form>]
            Month: int option
            /// The four-digit year of registration.
            [<Config.Form>]
            Year: int option
        }

    module Update'CompanyRegistrationDateRegistrationDateSpecs =
        let create
            (
                day: int option,
                month: int option,
                year: int option
            ) : Update'CompanyRegistrationDateRegistrationDateSpecs
            =
            {
              Day = day
              Month = month
              Year = year
            }

    type Update'CompanyRepresentativeDeclaration =
        {
            /// The Unix timestamp marking when the representative declaration attestation was made.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the representative declaration attestation was made.
            [<Config.Form>]
            Ip: string option
            /// The user agent of the browser from which the representative declaration attestation was made.
            [<Config.Form>]
            UserAgent: string option
        }

    module Update'CompanyRepresentativeDeclaration =
        let create
            (
                date: DateTime option,
                ip: string option,
                userAgent: string option
            ) : Update'CompanyRepresentativeDeclaration
            =
            {
              Date = date
              Ip = ip
              UserAgent = userAgent
            }

    type Update'CompanyStructure =
        | FreeZoneEstablishment
        | FreeZoneLlc
        | GovernmentInstrumentality
        | GovernmentalUnit
        | IncorporatedNonProfit
        | IncorporatedPartnership
        | LimitedLiabilityPartnership
        | Llc
        | MultiMemberLlc
        | PrivateCompany
        | PrivateCorporation
        | PrivatePartnership
        | PublicCompany
        | PublicCorporation
        | PublicPartnership
        | RegisteredCharity
        | SingleMemberLlc
        | SoleEstablishment
        | SoleProprietorship
        | TaxExemptGovernmentInstrumentality
        | UnincorporatedAssociation
        | UnincorporatedNonProfit
        | UnincorporatedPartnership

    type Update'CompanyVerificationDocument =
        {
            /// The back of a document returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `additional_verification`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Back: string option
            /// The front of a document returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `additional_verification`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Front: string option
        }

    module Update'CompanyVerificationDocument =
        let create
            (
                back: string option,
                front: string option
            ) : Update'CompanyVerificationDocument
            =
            {
              Back = back
              Front = front
            }

    type Update'CompanyVerification =
        {
            /// A document verifying the business.
            [<Config.Form>]
            Document: Update'CompanyVerificationDocument option
        }

    module Update'CompanyVerification =
        let create
            (
                document: Update'CompanyVerificationDocument option
            ) : Update'CompanyVerification
            =
            {
              Document = document
            }

    type Update'Company =
        {
            /// The company's primary address.
            [<Config.Form>]
            Address: Update'CompanyAddress option
            /// The Kana variation of the company's primary address (Japan only).
            [<Config.Form>]
            AddressKana: Update'CompanyAddressKana option
            /// The Kanji variation of the company's primary address (Japan only).
            [<Config.Form>]
            AddressKanji: Update'CompanyAddressKanji option
            /// Whether the company's directors have been provided. Set this Boolean to `true` after creating all the company's directors with [the Persons API](/api/persons) for accounts with a `relationship.director` requirement. This value is not automatically set to `true` after creating directors, so it needs to be updated to indicate all directors have been provided.
            [<Config.Form>]
            DirectorsProvided: bool option
            /// This hash is used to attest that the directors information provided to Stripe is both current and correct.
            [<Config.Form>]
            DirectorshipDeclaration: Update'CompanyDirectorshipDeclaration option
            /// Whether the company's executives have been provided. Set this Boolean to `true` after creating all the company's executives with [the Persons API](/api/persons) for accounts with a `relationship.executive` requirement.
            [<Config.Form>]
            ExecutivesProvided: bool option
            /// The export license ID number of the company, also referred as Import Export Code (India only).
            [<Config.Form>]
            ExportLicenseId: string option
            /// The purpose code to use for export transactions (India only).
            [<Config.Form>]
            ExportPurposeCode: string option
            /// The company's legal name.
            [<Config.Form>]
            Name: string option
            /// The Kana variation of the company's legal name (Japan only).
            [<Config.Form>]
            NameKana: string option
            /// The Kanji variation of the company's legal name (Japan only).
            [<Config.Form>]
            NameKanji: string option
            /// Whether the company's owners have been provided. Set this Boolean to `true` after creating all the company's owners with [the Persons API](/api/persons) for accounts with a `relationship.owner` requirement.
            [<Config.Form>]
            OwnersProvided: bool option
            /// This hash is used to attest that the beneficial owner information provided to Stripe is both current and correct.
            [<Config.Form>]
            OwnershipDeclaration: Update'CompanyOwnershipDeclaration option
            /// This value is used to determine if a business is exempt from providing ultimate beneficial owners. See [this support article](https://support.stripe.com/questions/exemption-from-providing-ownership-details) and [changelog](https://docs.stripe.com/changelog/acacia/2025-01-27/ownership-exemption-reason-accounts-api) for more details.
            [<Config.Form>]
            OwnershipExemptionReason: Update'CompanyOwnershipExemptionReason option
            /// The company's phone number (used for verification).
            [<Config.Form>]
            Phone: string option
            [<Config.Form>]
            RegistrationDate: Choice<Update'CompanyRegistrationDateRegistrationDateSpecs,string> option
            /// The identification number given to a company when it is registered or incorporated, if distinct from the identification number used for filing taxes. (Examples are the CIN for companies and LLP IN for partnerships in India, and the Company Registration Number in Hong Kong).
            [<Config.Form>]
            RegistrationNumber: string option
            /// This hash is used to attest that the representative is authorized to act as the representative of their legal entity.
            [<Config.Form>]
            RepresentativeDeclaration: Update'CompanyRepresentativeDeclaration option
            /// The category identifying the legal structure of the company or legal entity. See [Business structure](/connect/identity-verification#business-structure) for more details. Pass an empty string to unset this value.
            [<Config.Form>]
            Structure: Update'CompanyStructure option
            /// The business ID number of the company, as appropriate for the company’s country. (Examples are an Employer ID Number in the U.S., a Business Number in Canada, or a Company Number in the UK.)
            [<Config.Form>]
            TaxId: string option
            /// The jurisdiction in which the `tax_id` is registered (Germany-based companies only).
            [<Config.Form>]
            TaxIdRegistrar: string option
            /// The VAT number of the company.
            [<Config.Form>]
            VatId: string option
            /// Information on the verification state of the company.
            [<Config.Form>]
            Verification: Update'CompanyVerification option
        }

    module Update'Company =
        let create
            (
                address: Update'CompanyAddress option,
                addressKana: Update'CompanyAddressKana option,
                addressKanji: Update'CompanyAddressKanji option,
                directorsProvided: bool option,
                directorshipDeclaration: Update'CompanyDirectorshipDeclaration option,
                executivesProvided: bool option,
                exportLicenseId: string option,
                exportPurposeCode: string option,
                name: string option,
                nameKana: string option,
                nameKanji: string option,
                ownersProvided: bool option,
                ownershipDeclaration: Update'CompanyOwnershipDeclaration option,
                ownershipExemptionReason: Update'CompanyOwnershipExemptionReason option,
                phone: string option,
                registrationDate: Choice<Update'CompanyRegistrationDateRegistrationDateSpecs,string> option,
                registrationNumber: string option,
                representativeDeclaration: Update'CompanyRepresentativeDeclaration option,
                structure: Update'CompanyStructure option,
                taxId: string option,
                taxIdRegistrar: string option,
                vatId: string option,
                verification: Update'CompanyVerification option
            ) : Update'Company
            =
            {
              Address = address
              AddressKana = addressKana
              AddressKanji = addressKanji
              DirectorsProvided = directorsProvided
              DirectorshipDeclaration = directorshipDeclaration
              ExecutivesProvided = executivesProvided
              ExportLicenseId = exportLicenseId
              ExportPurposeCode = exportPurposeCode
              Name = name
              NameKana = nameKana
              NameKanji = nameKanji
              OwnersProvided = ownersProvided
              OwnershipDeclaration = ownershipDeclaration
              OwnershipExemptionReason = ownershipExemptionReason
              Phone = phone
              RegistrationDate = registrationDate
              RegistrationNumber = registrationNumber
              RepresentativeDeclaration = representativeDeclaration
              Structure = structure
              TaxId = taxId
              TaxIdRegistrar = taxIdRegistrar
              VatId = vatId
              Verification = verification
            }

    type Update'DocumentsBankAccountOwnershipVerification =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: string list option
        }

    module Update'DocumentsBankAccountOwnershipVerification =
        let create
            (
                files: string list option
            ) : Update'DocumentsBankAccountOwnershipVerification
            =
            {
              Files = files
            }

    type Update'DocumentsCompanyLicense =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: string list option
        }

    module Update'DocumentsCompanyLicense =
        let create
            (
                files: string list option
            ) : Update'DocumentsCompanyLicense
            =
            {
              Files = files
            }

    type Update'DocumentsCompanyMemorandumOfAssociation =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: string list option
        }

    module Update'DocumentsCompanyMemorandumOfAssociation =
        let create
            (
                files: string list option
            ) : Update'DocumentsCompanyMemorandumOfAssociation
            =
            {
              Files = files
            }

    type Update'DocumentsCompanyMinisterialDecree =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: string list option
        }

    module Update'DocumentsCompanyMinisterialDecree =
        let create
            (
                files: string list option
            ) : Update'DocumentsCompanyMinisterialDecree
            =
            {
              Files = files
            }

    type Update'DocumentsCompanyRegistrationVerification =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: string list option
        }

    module Update'DocumentsCompanyRegistrationVerification =
        let create
            (
                files: string list option
            ) : Update'DocumentsCompanyRegistrationVerification
            =
            {
              Files = files
            }

    type Update'DocumentsCompanyTaxIdVerification =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: string list option
        }

    module Update'DocumentsCompanyTaxIdVerification =
        let create
            (
                files: string list option
            ) : Update'DocumentsCompanyTaxIdVerification
            =
            {
              Files = files
            }

    type Update'DocumentsProofOfAddress =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: string list option
        }

    module Update'DocumentsProofOfAddress =
        let create
            (
                files: string list option
            ) : Update'DocumentsProofOfAddress
            =
            {
              Files = files
            }

    type Update'DocumentsProofOfRegistrationSigner =
        {
            /// The token of the person signing the document, if applicable.
            [<Config.Form>]
            Person: string option
        }

    module Update'DocumentsProofOfRegistrationSigner =
        let create
            (
                person: string option
            ) : Update'DocumentsProofOfRegistrationSigner
            =
            {
              Person = person
            }

    type Update'DocumentsProofOfRegistration =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: string list option
            /// Information regarding the person signing the document if applicable.
            [<Config.Form>]
            Signer: Update'DocumentsProofOfRegistrationSigner option
        }

    module Update'DocumentsProofOfRegistration =
        let create
            (
                files: string list option,
                signer: Update'DocumentsProofOfRegistrationSigner option
            ) : Update'DocumentsProofOfRegistration
            =
            {
              Files = files
              Signer = signer
            }

    type Update'DocumentsProofOfUltimateBeneficialOwnershipSigner =
        {
            /// The token of the person signing the document, if applicable.
            [<Config.Form>]
            Person: string option
        }

    module Update'DocumentsProofOfUltimateBeneficialOwnershipSigner =
        let create
            (
                person: string option
            ) : Update'DocumentsProofOfUltimateBeneficialOwnershipSigner
            =
            {
              Person = person
            }

    type Update'DocumentsProofOfUltimateBeneficialOwnership =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: string list option
            /// Information regarding the person signing the document if applicable.
            [<Config.Form>]
            Signer: Update'DocumentsProofOfUltimateBeneficialOwnershipSigner option
        }

    module Update'DocumentsProofOfUltimateBeneficialOwnership =
        let create
            (
                files: string list option,
                signer: Update'DocumentsProofOfUltimateBeneficialOwnershipSigner option
            ) : Update'DocumentsProofOfUltimateBeneficialOwnership
            =
            {
              Files = files
              Signer = signer
            }

    type Update'Documents =
        {
            /// One or more documents that support the [Bank account ownership verification](https://support.stripe.com/questions/bank-account-ownership-verification) requirement. Must be a document associated with the account’s primary active bank account that displays the last 4 digits of the account number, either a statement or a check.
            [<Config.Form>]
            BankAccountOwnershipVerification: Update'DocumentsBankAccountOwnershipVerification option
            /// One or more documents that demonstrate proof of a company's license to operate.
            [<Config.Form>]
            CompanyLicense: Update'DocumentsCompanyLicense option
            /// One or more documents showing the company's Memorandum of Association.
            [<Config.Form>]
            CompanyMemorandumOfAssociation: Update'DocumentsCompanyMemorandumOfAssociation option
            /// (Certain countries only) One or more documents showing the ministerial decree legalizing the company's establishment.
            [<Config.Form>]
            CompanyMinisterialDecree: Update'DocumentsCompanyMinisterialDecree option
            /// One or more documents that demonstrate proof of a company's registration with the appropriate local authorities.
            [<Config.Form>]
            CompanyRegistrationVerification: Update'DocumentsCompanyRegistrationVerification option
            /// One or more documents that demonstrate proof of a company's tax ID.
            [<Config.Form>]
            CompanyTaxIdVerification: Update'DocumentsCompanyTaxIdVerification option
            /// One or more documents that demonstrate proof of address.
            [<Config.Form>]
            ProofOfAddress: Update'DocumentsProofOfAddress option
            /// One or more documents showing the company’s proof of registration with the national business registry.
            [<Config.Form>]
            ProofOfRegistration: Update'DocumentsProofOfRegistration option
            /// One or more documents that demonstrate proof of ultimate beneficial ownership.
            [<Config.Form>]
            ProofOfUltimateBeneficialOwnership: Update'DocumentsProofOfUltimateBeneficialOwnership option
        }

    module Update'Documents =
        let create
            (
                bankAccountOwnershipVerification: Update'DocumentsBankAccountOwnershipVerification option,
                companyLicense: Update'DocumentsCompanyLicense option,
                companyMemorandumOfAssociation: Update'DocumentsCompanyMemorandumOfAssociation option,
                companyMinisterialDecree: Update'DocumentsCompanyMinisterialDecree option,
                companyRegistrationVerification: Update'DocumentsCompanyRegistrationVerification option,
                companyTaxIdVerification: Update'DocumentsCompanyTaxIdVerification option,
                proofOfAddress: Update'DocumentsProofOfAddress option,
                proofOfRegistration: Update'DocumentsProofOfRegistration option,
                proofOfUltimateBeneficialOwnership: Update'DocumentsProofOfUltimateBeneficialOwnership option
            ) : Update'Documents
            =
            {
              BankAccountOwnershipVerification = bankAccountOwnershipVerification
              CompanyLicense = companyLicense
              CompanyMemorandumOfAssociation = companyMemorandumOfAssociation
              CompanyMinisterialDecree = companyMinisterialDecree
              CompanyRegistrationVerification = companyRegistrationVerification
              CompanyTaxIdVerification = companyTaxIdVerification
              ProofOfAddress = proofOfAddress
              ProofOfRegistration = proofOfRegistration
              ProofOfUltimateBeneficialOwnership = proofOfUltimateBeneficialOwnership
            }

    type Update'Groups =
        {
            /// The group the account is in to determine their payments pricing, and null if the account is on customized pricing. [See the Platform pricing tool documentation](https://docs.stripe.com/connect/platform-pricing-tools) for details.
            [<Config.Form>]
            PaymentsPricing: Choice<string,string> option
        }

    module Update'Groups =
        let create
            (
                paymentsPricing: Choice<string,string> option
            ) : Update'Groups
            =
            {
              PaymentsPricing = paymentsPricing
            }

    type Update'IndividualAddress =
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

    module Update'IndividualAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Update'IndividualAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Update'IndividualAddressKana =
        {
            /// City or ward.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Block or building number.
            [<Config.Form>]
            Line1: string option
            /// Building details.
            [<Config.Form>]
            Line2: string option
            /// Postal code.
            [<Config.Form>]
            PostalCode: string option
            /// Prefecture.
            [<Config.Form>]
            State: string option
            /// Town or cho-me.
            [<Config.Form>]
            Town: string option
        }

    module Update'IndividualAddressKana =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option,
                town: string option
            ) : Update'IndividualAddressKana
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
              Town = town
            }

    type Update'IndividualAddressKanji =
        {
            /// City or ward.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Block or building number.
            [<Config.Form>]
            Line1: string option
            /// Building details.
            [<Config.Form>]
            Line2: string option
            /// Postal code.
            [<Config.Form>]
            PostalCode: string option
            /// Prefecture.
            [<Config.Form>]
            State: string option
            /// Town or cho-me.
            [<Config.Form>]
            Town: string option
        }

    module Update'IndividualAddressKanji =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option,
                town: string option
            ) : Update'IndividualAddressKanji
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
              Town = town
            }

    type Update'IndividualDobDateOfBirthSpecs =
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

    module Update'IndividualDobDateOfBirthSpecs =
        let create
            (
                day: int option,
                month: int option,
                year: int option
            ) : Update'IndividualDobDateOfBirthSpecs
            =
            {
              Day = day
              Month = month
              Year = year
            }

    type Update'IndividualPoliticalExposure =
        | Existing
        | [<JsonPropertyName("none")>] None'

    type Update'IndividualRegisteredAddress =
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

    module Update'IndividualRegisteredAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Update'IndividualRegisteredAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Update'IndividualRelationship =
        {
            /// Whether the person is a director of the account's legal entity. Directors are typically members of the governing board of the company, or responsible for ensuring the company meets its regulatory obligations.
            [<Config.Form>]
            Director: bool option
            /// Whether the person has significant responsibility to control, manage, or direct the organization.
            [<Config.Form>]
            Executive: bool option
            /// Whether the person is an owner of the account’s legal entity.
            [<Config.Form>]
            Owner: bool option
            /// The percent owned by the person of the account's legal entity.
            [<Config.Form>]
            PercentOwnership: Choice<decimal,string> option
            /// The person's title (e.g., CEO, Support Engineer).
            [<Config.Form>]
            Title: string option
        }

    module Update'IndividualRelationship =
        let create
            (
                director: bool option,
                executive: bool option,
                owner: bool option,
                percentOwnership: Choice<decimal,string> option,
                title: string option
            ) : Update'IndividualRelationship
            =
            {
              Director = director
              Executive = executive
              Owner = owner
              PercentOwnership = percentOwnership
              Title = title
            }

    type Update'IndividualVerificationAdditionalDocument =
        {
            /// The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Back: string option
            /// The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Front: string option
        }

    module Update'IndividualVerificationAdditionalDocument =
        let create
            (
                back: string option,
                front: string option
            ) : Update'IndividualVerificationAdditionalDocument
            =
            {
              Back = back
              Front = front
            }

    type Update'IndividualVerificationDocument =
        {
            /// The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Back: string option
            /// The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Front: string option
        }

    module Update'IndividualVerificationDocument =
        let create
            (
                back: string option,
                front: string option
            ) : Update'IndividualVerificationDocument
            =
            {
              Back = back
              Front = front
            }

    type Update'IndividualVerification =
        {
            /// A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.
            [<Config.Form>]
            AdditionalDocument: Update'IndividualVerificationAdditionalDocument option
            /// An identifying document, either a passport or local ID card.
            [<Config.Form>]
            Document: Update'IndividualVerificationDocument option
        }

    module Update'IndividualVerification =
        let create
            (
                additionalDocument: Update'IndividualVerificationAdditionalDocument option,
                document: Update'IndividualVerificationDocument option
            ) : Update'IndividualVerification
            =
            {
              AdditionalDocument = additionalDocument
              Document = document
            }

    type Update'Individual =
        {
            /// The individual's primary address.
            [<Config.Form>]
            Address: Update'IndividualAddress option
            /// The Kana variation of the individual's primary address (Japan only).
            [<Config.Form>]
            AddressKana: Update'IndividualAddressKana option
            /// The Kanji variation of the individual's primary address (Japan only).
            [<Config.Form>]
            AddressKanji: Update'IndividualAddressKanji option
            /// The individual's date of birth.
            [<Config.Form>]
            Dob: Choice<Update'IndividualDobDateOfBirthSpecs,string> option
            /// The individual's email address.
            [<Config.Form>]
            Email: string option
            /// The individual's first name.
            [<Config.Form>]
            FirstName: string option
            /// The Kana variation of the individual's first name (Japan only).
            [<Config.Form>]
            FirstNameKana: string option
            /// The Kanji variation of the individual's first name (Japan only).
            [<Config.Form>]
            FirstNameKanji: string option
            /// A list of alternate names or aliases that the individual is known by.
            [<Config.Form>]
            FullNameAliases: Choice<string list,string> option
            /// The individual's gender
            [<Config.Form>]
            Gender: string option
            /// The government-issued ID number of the individual, as appropriate for the representative's country. (Examples are a Social Security Number in the U.S., or a Social Insurance Number in Canada). Instead of the number itself, you can also provide a [PII token created with Stripe.js](/js/tokens/create_token?type=pii).
            [<Config.Form>]
            IdNumber: string option
            /// The government-issued secondary ID number of the individual, as appropriate for the representative's country, will be used for enhanced verification checks. In Thailand, this would be the laser code found on the back of an ID card. Instead of the number itself, you can also provide a [PII token created with Stripe.js](/js/tokens/create_token?type=pii).
            [<Config.Form>]
            IdNumberSecondary: string option
            /// The individual's last name.
            [<Config.Form>]
            LastName: string option
            /// The Kana variation of the individual's last name (Japan only).
            [<Config.Form>]
            LastNameKana: string option
            /// The Kanji variation of the individual's last name (Japan only).
            [<Config.Form>]
            LastNameKanji: string option
            /// The individual's maiden name.
            [<Config.Form>]
            MaidenName: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The individual's phone number.
            [<Config.Form>]
            Phone: string option
            /// Indicates if the person or any of their representatives, family members, or other closely related persons, declares that they hold or have held an important public job or function, in any jurisdiction.
            [<Config.Form>]
            PoliticalExposure: Update'IndividualPoliticalExposure option
            /// The individual's registered address.
            [<Config.Form>]
            RegisteredAddress: Update'IndividualRegisteredAddress option
            /// Describes the person’s relationship to the account.
            [<Config.Form>]
            Relationship: Update'IndividualRelationship option
            /// The last four digits of the individual's Social Security Number (U.S. only).
            [<Config.Form>]
            SsnLast4: string option
            /// The individual's verification document information.
            [<Config.Form>]
            Verification: Update'IndividualVerification option
        }

    module Update'Individual =
        let create
            (
                address: Update'IndividualAddress option,
                addressKana: Update'IndividualAddressKana option,
                addressKanji: Update'IndividualAddressKanji option,
                dob: Choice<Update'IndividualDobDateOfBirthSpecs,string> option,
                email: string option,
                firstName: string option,
                firstNameKana: string option,
                firstNameKanji: string option,
                fullNameAliases: Choice<string list,string> option,
                gender: string option,
                idNumber: string option,
                idNumberSecondary: string option,
                lastName: string option,
                lastNameKana: string option,
                lastNameKanji: string option,
                maidenName: string option,
                metadata: Map<string, string> option,
                phone: string option,
                politicalExposure: Update'IndividualPoliticalExposure option,
                registeredAddress: Update'IndividualRegisteredAddress option,
                relationship: Update'IndividualRelationship option,
                ssnLast4: string option,
                verification: Update'IndividualVerification option
            ) : Update'Individual
            =
            {
              Address = address
              AddressKana = addressKana
              AddressKanji = addressKanji
              Dob = dob
              Email = email
              FirstName = firstName
              FirstNameKana = firstNameKana
              FirstNameKanji = firstNameKanji
              FullNameAliases = fullNameAliases
              Gender = gender
              IdNumber = idNumber
              IdNumberSecondary = idNumberSecondary
              LastName = lastName
              LastNameKana = lastNameKana
              LastNameKanji = lastNameKanji
              MaidenName = maidenName
              Metadata = metadata
              Phone = phone
              PoliticalExposure = politicalExposure
              RegisteredAddress = registeredAddress
              Relationship = relationship
              SsnLast4 = ssnLast4
              Verification = verification
            }

    type Update'SettingsBacsDebitPayments =
        {
            /// The Bacs Direct Debit Display Name for this account. For payments made with Bacs Direct Debit, this name appears on the mandate as the statement descriptor. Mobile banking apps display it as the name of the business. To use custom branding, set the Bacs Direct Debit Display Name during or right after creation. Custom branding incurs an additional monthly fee for the platform. If you don't set the display name before requesting Bacs capability, it's automatically set as "Stripe" and the account is onboarded to Stripe branding, which is free.
            [<Config.Form>]
            DisplayName: string option
        }

    module Update'SettingsBacsDebitPayments =
        let create
            (
                displayName: string option
            ) : Update'SettingsBacsDebitPayments
            =
            {
              DisplayName = displayName
            }

    type Update'SettingsBranding =
        {
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) An icon for the account. Must be square and at least 128px x 128px.
            [<Config.Form>]
            Icon: string option
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) A logo for the account that will be used in Checkout instead of the icon and without the account's name next to it if provided. Must be at least 128px x 128px.
            [<Config.Form>]
            Logo: string option
            /// A CSS hex color value representing the primary branding color for this account.
            [<Config.Form>]
            PrimaryColor: string option
            /// A CSS hex color value representing the secondary branding color for this account.
            [<Config.Form>]
            SecondaryColor: string option
        }

    module Update'SettingsBranding =
        let create
            (
                icon: string option,
                logo: string option,
                primaryColor: string option,
                secondaryColor: string option
            ) : Update'SettingsBranding
            =
            {
              Icon = icon
              Logo = logo
              PrimaryColor = primaryColor
              SecondaryColor = secondaryColor
            }

    type Update'SettingsCardIssuingTosAcceptance =
        {
            /// The Unix timestamp marking when the account representative accepted the service agreement.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the account representative accepted the service agreement.
            [<Config.Form>]
            Ip: string option
            /// The user agent of the browser from which the account representative accepted the service agreement.
            [<Config.Form>]
            UserAgent: Choice<string,string> option
        }

    module Update'SettingsCardIssuingTosAcceptance =
        let create
            (
                date: DateTime option,
                ip: string option,
                userAgent: Choice<string,string> option
            ) : Update'SettingsCardIssuingTosAcceptance
            =
            {
              Date = date
              Ip = ip
              UserAgent = userAgent
            }

    type Update'SettingsCardIssuing =
        {
            /// Details on the account's acceptance of the [Stripe Issuing Terms and Disclosures](/issuing/connect/tos_acceptance).
            [<Config.Form>]
            TosAcceptance: Update'SettingsCardIssuingTosAcceptance option
        }

    module Update'SettingsCardIssuing =
        let create
            (
                tosAcceptance: Update'SettingsCardIssuingTosAcceptance option
            ) : Update'SettingsCardIssuing
            =
            {
              TosAcceptance = tosAcceptance
            }

    type Update'SettingsCardPaymentsDeclineOn =
        {
            /// Whether Stripe automatically declines charges with an incorrect ZIP or postal code. This setting only applies when a ZIP or postal code is provided and they fail bank verification.
            [<Config.Form>]
            AvsFailure: bool option
            /// Whether Stripe automatically declines charges with an incorrect CVC. This setting only applies when a CVC is provided and it fails bank verification.
            [<Config.Form>]
            CvcFailure: bool option
        }

    module Update'SettingsCardPaymentsDeclineOn =
        let create
            (
                avsFailure: bool option,
                cvcFailure: bool option
            ) : Update'SettingsCardPaymentsDeclineOn
            =
            {
              AvsFailure = avsFailure
              CvcFailure = cvcFailure
            }

    type Update'SettingsCardPayments =
        {
            /// Automatically declines certain charge types regardless of whether the card issuer accepted or declined the charge.
            [<Config.Form>]
            DeclineOn: Update'SettingsCardPaymentsDeclineOn option
            /// The default text that appears on credit card statements when a charge is made. This field prefixes any dynamic `statement_descriptor` specified on the charge. `statement_descriptor_prefix` is useful for maximizing descriptor space for the dynamic portion.
            [<Config.Form>]
            StatementDescriptorPrefix: string option
            /// The Kana variation of the default text that appears on credit card statements when a charge is made (Japan only). This field prefixes any dynamic `statement_descriptor_suffix_kana` specified on the charge. `statement_descriptor_prefix_kana` is useful for maximizing descriptor space for the dynamic portion.
            [<Config.Form>]
            StatementDescriptorPrefixKana: Choice<string,string> option
            /// The Kanji variation of the default text that appears on credit card statements when a charge is made (Japan only). This field prefixes any dynamic `statement_descriptor_suffix_kanji` specified on the charge. `statement_descriptor_prefix_kanji` is useful for maximizing descriptor space for the dynamic portion.
            [<Config.Form>]
            StatementDescriptorPrefixKanji: Choice<string,string> option
        }

    module Update'SettingsCardPayments =
        let create
            (
                declineOn: Update'SettingsCardPaymentsDeclineOn option,
                statementDescriptorPrefix: string option,
                statementDescriptorPrefixKana: Choice<string,string> option,
                statementDescriptorPrefixKanji: Choice<string,string> option
            ) : Update'SettingsCardPayments
            =
            {
              DeclineOn = declineOn
              StatementDescriptorPrefix = statementDescriptorPrefix
              StatementDescriptorPrefixKana = statementDescriptorPrefixKana
              StatementDescriptorPrefixKanji = statementDescriptorPrefixKanji
            }

    type Update'SettingsInvoicesHostedPaymentMethodSave =
        | Always
        | Never
        | Offer

    type Update'SettingsInvoices =
        {
            /// The list of default Account Tax IDs to automatically include on invoices. Account Tax IDs get added when an invoice is finalized.
            [<Config.Form>]
            DefaultAccountTaxIds: Choice<string list,string> option
            /// Whether to save the payment method after a payment is completed for a one-time invoice or a subscription invoice when the customer already has a default payment method on the hosted invoice page.
            [<Config.Form>]
            HostedPaymentMethodSave: Update'SettingsInvoicesHostedPaymentMethodSave option
        }

    module Update'SettingsInvoices =
        let create
            (
                defaultAccountTaxIds: Choice<string list,string> option,
                hostedPaymentMethodSave: Update'SettingsInvoicesHostedPaymentMethodSave option
            ) : Update'SettingsInvoices
            =
            {
              DefaultAccountTaxIds = defaultAccountTaxIds
              HostedPaymentMethodSave = hostedPaymentMethodSave
            }

    type Update'SettingsPayments =
        {
            /// The default text that appears on statements for non-card charges outside of Japan. For card charges, if you don't set a `statement_descriptor_prefix`, this text is also used as the statement descriptor prefix. In that case, if concatenating the statement descriptor suffix causes the combined statement descriptor to exceed 22 characters, we truncate the `statement_descriptor` text to limit the full descriptor to 22 characters. For more information about statement descriptors and their requirements, see the [account settings documentation](https://docs.stripe.com/get-started/account/statement-descriptors).
            [<Config.Form>]
            StatementDescriptor: string option
            /// The Kana variation of `statement_descriptor` used for charges in Japan. Japanese statement descriptors have [special requirements](https://docs.stripe.com/get-started/account/statement-descriptors#set-japanese-statement-descriptors).
            [<Config.Form>]
            StatementDescriptorKana: string option
            /// The Kanji variation of `statement_descriptor` used for charges in Japan. Japanese statement descriptors have [special requirements](https://docs.stripe.com/get-started/account/statement-descriptors#set-japanese-statement-descriptors).
            [<Config.Form>]
            StatementDescriptorKanji: string option
        }

    module Update'SettingsPayments =
        let create
            (
                statementDescriptor: string option,
                statementDescriptorKana: string option,
                statementDescriptorKanji: string option
            ) : Update'SettingsPayments
            =
            {
              StatementDescriptor = statementDescriptor
              StatementDescriptorKana = statementDescriptorKana
              StatementDescriptorKanji = statementDescriptorKanji
            }

    type Update'SettingsPayoutsScheduleDelayDays = | Minimum

    type Update'SettingsPayoutsScheduleInterval =
        | Daily
        | Manual
        | Monthly
        | Weekly

    type Update'SettingsPayoutsScheduleWeeklyAnchor =
        | Friday
        | Monday
        | Saturday
        | Sunday
        | Thursday
        | Tuesday
        | Wednesday

    type Update'SettingsPayoutsScheduleWeeklyPayoutDays =
        | Friday
        | Monday
        | Thursday
        | Tuesday
        | Wednesday

    type Update'SettingsPayoutsSchedule =
        {
            /// The number of days charge funds are held before being paid out. May also be set to `minimum`, representing the lowest available value for the account country. Default is `minimum`. The `delay_days` parameter remains at the last configured value if `interval` is `manual`. [Learn more about controlling payout delay days](/connect/manage-payout-schedule).
            [<Config.Form>]
            DelayDays: Choice<Update'SettingsPayoutsScheduleDelayDays,int> option
            /// How frequently available funds are paid out. One of: `daily`, `manual`, `weekly`, or `monthly`. Default is `daily`.
            [<Config.Form>]
            Interval: Update'SettingsPayoutsScheduleInterval option
            /// The day of the month when available funds are paid out, specified as a number between 1--31. Payouts nominally scheduled between the 29th and 31st of the month are instead sent on the last day of a shorter month. Required and applicable only if `interval` is `monthly`.
            [<Config.Form>]
            MonthlyAnchor: int option
            /// The days of the month when available funds are paid out, specified as an array of numbers between 1--31. Payouts nominally scheduled between the 29th and 31st of the month are instead sent on the last day of a shorter month. Required and applicable only if `interval` is `monthly` and `monthly_anchor` is not set.
            [<Config.Form>]
            MonthlyPayoutDays: int list option
            /// The day of the week when available funds are paid out, specified as `monday`, `tuesday`, etc. Required and applicable only if `interval` is `weekly`.
            [<Config.Form>]
            WeeklyAnchor: Update'SettingsPayoutsScheduleWeeklyAnchor option
            /// The days of the week when available funds are paid out, specified as an array, e.g., [`monday`, `tuesday`]. Required and applicable only if `interval` is `weekly`.
            [<Config.Form>]
            WeeklyPayoutDays: Update'SettingsPayoutsScheduleWeeklyPayoutDays list option
        }

    module Update'SettingsPayoutsSchedule =
        let create
            (
                delayDays: Choice<Update'SettingsPayoutsScheduleDelayDays,int> option,
                interval: Update'SettingsPayoutsScheduleInterval option,
                monthlyAnchor: int option,
                monthlyPayoutDays: int list option,
                weeklyAnchor: Update'SettingsPayoutsScheduleWeeklyAnchor option,
                weeklyPayoutDays: Update'SettingsPayoutsScheduleWeeklyPayoutDays list option
            ) : Update'SettingsPayoutsSchedule
            =
            {
              DelayDays = delayDays
              Interval = interval
              MonthlyAnchor = monthlyAnchor
              MonthlyPayoutDays = monthlyPayoutDays
              WeeklyAnchor = weeklyAnchor
              WeeklyPayoutDays = weeklyPayoutDays
            }

    type Update'SettingsPayouts =
        {
            /// A Boolean indicating whether Stripe should try to reclaim negative balances from an attached bank account. For details, see [Understanding Connect Account Balances](/connect/account-balances).
            [<Config.Form>]
            DebitNegativeBalances: bool option
            /// Details on when funds from charges are available, and when they are paid out to an external account. For details, see our [Setting Bank and Debit Card Payouts](/connect/bank-transfers#payout-information) documentation.
            [<Config.Form>]
            Schedule: Update'SettingsPayoutsSchedule option
            /// The text that appears on the bank account statement for payouts. If not set, this defaults to the platform's bank descriptor as set in the Dashboard.
            [<Config.Form>]
            StatementDescriptor: string option
        }

    module Update'SettingsPayouts =
        let create
            (
                debitNegativeBalances: bool option,
                schedule: Update'SettingsPayoutsSchedule option,
                statementDescriptor: string option
            ) : Update'SettingsPayouts
            =
            {
              DebitNegativeBalances = debitNegativeBalances
              Schedule = schedule
              StatementDescriptor = statementDescriptor
            }

    type Update'SettingsTreasuryTosAcceptance =
        {
            /// The Unix timestamp marking when the account representative accepted the service agreement.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the account representative accepted the service agreement.
            [<Config.Form>]
            Ip: string option
            /// The user agent of the browser from which the account representative accepted the service agreement.
            [<Config.Form>]
            UserAgent: Choice<string,string> option
        }

    module Update'SettingsTreasuryTosAcceptance =
        let create
            (
                date: DateTime option,
                ip: string option,
                userAgent: Choice<string,string> option
            ) : Update'SettingsTreasuryTosAcceptance
            =
            {
              Date = date
              Ip = ip
              UserAgent = userAgent
            }

    type Update'SettingsTreasury =
        {
            /// Details on the account's acceptance of the Stripe Treasury Services Agreement.
            [<Config.Form>]
            TosAcceptance: Update'SettingsTreasuryTosAcceptance option
        }

    module Update'SettingsTreasury =
        let create
            (
                tosAcceptance: Update'SettingsTreasuryTosAcceptance option
            ) : Update'SettingsTreasury
            =
            {
              TosAcceptance = tosAcceptance
            }

    type Update'Settings =
        {
            /// Settings specific to Bacs Direct Debit payments.
            [<Config.Form>]
            BacsDebitPayments: Update'SettingsBacsDebitPayments option
            /// Settings used to apply the account's branding to email receipts, invoices, Checkout, and other products.
            [<Config.Form>]
            Branding: Update'SettingsBranding option
            /// Settings specific to the account's use of the Card Issuing product.
            [<Config.Form>]
            CardIssuing: Update'SettingsCardIssuing option
            /// Settings specific to card charging on the account.
            [<Config.Form>]
            CardPayments: Update'SettingsCardPayments option
            /// Settings specific to the account's use of Invoices.
            [<Config.Form>]
            Invoices: Update'SettingsInvoices option
            /// Settings that apply across payment methods for charging on the account.
            [<Config.Form>]
            Payments: Update'SettingsPayments option
            /// Settings specific to the account's payouts.
            [<Config.Form>]
            Payouts: Update'SettingsPayouts option
            /// Settings specific to the account's Treasury FinancialAccounts.
            [<Config.Form>]
            Treasury: Update'SettingsTreasury option
        }

    module Update'Settings =
        let create
            (
                bacsDebitPayments: Update'SettingsBacsDebitPayments option,
                branding: Update'SettingsBranding option,
                cardIssuing: Update'SettingsCardIssuing option,
                cardPayments: Update'SettingsCardPayments option,
                invoices: Update'SettingsInvoices option,
                payments: Update'SettingsPayments option,
                payouts: Update'SettingsPayouts option,
                treasury: Update'SettingsTreasury option
            ) : Update'Settings
            =
            {
              BacsDebitPayments = bacsDebitPayments
              Branding = branding
              CardIssuing = cardIssuing
              CardPayments = cardPayments
              Invoices = invoices
              Payments = payments
              Payouts = payouts
              Treasury = treasury
            }

    type Update'TosAcceptance =
        {
            /// The Unix timestamp marking when the account representative accepted their service agreement.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the account representative accepted their service agreement.
            [<Config.Form>]
            Ip: string option
            /// The user's service agreement type.
            [<Config.Form>]
            ServiceAgreement: string option
            /// The user agent of the browser from which the account representative accepted their service agreement.
            [<Config.Form>]
            UserAgent: string option
        }

    module Update'TosAcceptance =
        let create
            (
                date: DateTime option,
                ip: string option,
                serviceAgreement: string option,
                userAgent: string option
            ) : Update'TosAcceptance
            =
            {
              Date = date
              Ip = ip
              ServiceAgreement = serviceAgreement
              UserAgent = userAgent
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Account: string
            /// An [account token](https://api.stripe.com#create_account_token), used to securely provide details to the account.
            [<Config.Form>]
            AccountToken: string option
            /// Business information about the account.
            [<Config.Form>]
            BusinessProfile: Update'BusinessProfile option
            /// The business type. Once you create an [Account Link](/api/account_links) or [Account Session](/api/account_sessions), this property can only be updated for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts.
            [<Config.Form>]
            BusinessType: Update'BusinessType option
            /// Each key of the dictionary represents a capability, and each capability
            /// maps to its settings (for example, whether it has been requested or not). Each
            /// capability is inactive until you have provided its specific
            /// requirements and Stripe has verified them. An account might have some
            /// of its requested capabilities be active and some be inactive.
            /// Required when [account.controller.stripe_dashboard.type](/api/accounts/create#create_account-controller-dashboard-type)
            /// is `none`, which includes Custom accounts.
            [<Config.Form>]
            Capabilities: Update'Capabilities option
            /// Information about the company or business. This field is available for any `business_type`. Once you create an [Account Link](/api/account_links) or [Account Session](/api/account_sessions), this property can only be updated for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts.
            [<Config.Form>]
            Company: Update'Company option
            /// Three-letter ISO currency code representing the default currency for the account. This must be a currency that [Stripe supports in the account's country](https://docs.stripe.com/payouts).
            [<Config.Form>]
            DefaultCurrency: IsoTypes.IsoCurrencyCode option
            /// Documents that may be submitted to satisfy various informational requests.
            [<Config.Form>]
            Documents: Update'Documents option
            /// The email address of the account holder. This is only to make the account easier to identify to you. If [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts, Stripe doesn't email the account without your consent.
            [<Config.Form>]
            Email: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A card or bank account to attach to the account for receiving [payouts](/connect/bank-debit-card-payouts) (you won’t be able to use it for top-ups). You can provide either a token, like the ones returned by [Stripe.js](/js), or a dictionary, as documented in the `external_account` parameter for [bank account](/api#account_create_bank_account) creation. <br><br>By default, providing an external account sets it as the new default external account for its currency, and deletes the old default if one exists. To add additional external accounts without replacing the existing default for the currency, use the [bank account](/api#account_create_bank_account) or [card creation](/api#account_create_card) APIs. After you create an [Account Link](/api/account_links) or [Account Session](/api/account_sessions), this property can only be updated for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts.
            [<Config.Form>]
            ExternalAccount: string option
            /// A hash of account group type to tokens. These are account groups this account should be added to.
            [<Config.Form>]
            Groups: Update'Groups option
            /// Information about the person represented by the account. This field is null unless `business_type` is set to `individual`. Once you create an [Account Link](/api/account_links) or [Account Session](/api/account_sessions), this property can only be updated for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts.
            [<Config.Form>]
            Individual: Update'Individual option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Options for customizing how the account functions within Stripe.
            [<Config.Form>]
            Settings: Update'Settings option
            /// Details on the account's acceptance of the [Stripe Services Agreement](/connect/updating-accounts#tos-acceptance). This property can only be updated for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts. This property defaults to a `full` service agreement when empty.
            [<Config.Form>]
            TosAcceptance: Update'TosAcceptance option
        }

    module UpdateOptions =
        let create
            (
                account: string
            ) : UpdateOptions
            =
            {
              Account = account
              AccountToken = None
              BusinessProfile = None
              BusinessType = None
              Capabilities = None
              Company = None
              DefaultCurrency = None
              Documents = None
              Email = None
              Expand = None
              ExternalAccount = None
              Groups = None
              Individual = None
              Metadata = None
              Settings = None
              TosAcceptance = None
            }

    ///<p>Returns a list of accounts connected to your platform via <a href="/docs/connect">Connect</a>. If you’re not a platform, the list is empty.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/accounts"
        |> RestApi.getAsync<StripeList<Account>> settings qs

    ///<p>With <a href="/docs/connect">Connect</a>, you can create Stripe accounts for your users.
    ///To do this, you’ll first need to <a href="https://dashboard.stripe.com/account/applications/settings">register your platform</a>.</p>
    ///<p>If you’ve already collected information for your connected accounts, you <a href="/docs/connect/best-practices#onboarding">can prefill that information</a> when
    ///creating the account. Connect Onboarding won’t ask for the prefilled information during account onboarding.
    ///You can prefill any information on the account.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/accounts"
        |> RestApi.postAsync<_, Account> settings (Map.empty) options

    ///<p>With <a href="/connect">Connect</a>, you can delete accounts you manage.</p>
    ///<p>Test-mode accounts can be deleted at any time.</p>
    ///<p>Live-mode accounts that have access to the standard dashboard and Stripe is responsible for negative account balances cannot be deleted, which includes Standard accounts. All other Live-mode accounts, can be deleted when all <a href="/api/balance/balance_object">balances</a> are zero.</p>
    ///<p>If you want to delete your own account, use the <a href="https://dashboard.stripe.com/settings/account">account information tab in your account settings</a> instead.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/accounts/{options.Account}"
        |> RestApi.deleteAsync<DeletedAccount> settings (Map.empty)

    ///<p>Retrieves the details of an account.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/accounts/{options.Account}"
        |> RestApi.getAsync<Account> settings qs

    ///<p>Updates a <a href="/connect/accounts">connected account</a> by setting the values of the parameters passed. Any parameters not provided are
    ///left unchanged.</p>
    ///<p>For accounts where <a href="/api/accounts/object#account_object-controller-requirement_collection">controller.requirement_collection</a>
    ///is <code>application</code>, which includes Custom accounts, you can update any information on the account.</p>
    ///<p>For accounts where <a href="/api/accounts/object#account_object-controller-requirement_collection">controller.requirement_collection</a>
    ///is <code>stripe</code>, which includes Standard and Express accounts, you can update all information until you create
    ///an <a href="/api/account_links">Account Link</a> or <a href="/api/account_sessions">Account Session</a> to start Connect onboarding,
    ///after which some properties can no longer be updated.</p>
    ///<p>To update your own account, use the <a href="https://dashboard.stripe.com/settings/account">Dashboard</a>. Refer to our
    ///<a href="/docs/connect/updating-accounts">Connect</a> documentation to learn more about updating accounts.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/accounts/{options.Account}"
        |> RestApi.postAsync<_, Account> settings (Map.empty) options

module AccountsCapabilities =

    type CapabilitiesOptions =
        {
            [<Config.Path>]
            Account: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    module CapabilitiesOptions =
        let create
            (
                account: string
            ) : CapabilitiesOptions
            =
            {
              Account = account
              Expand = None
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Account: string
            [<Config.Path>]
            Capability: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    module RetrieveOptions =
        let create
            (
                account: string,
                capability: string
            ) : RetrieveOptions
            =
            {
              Account = account
              Capability = capability
              Expand = None
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Account: string
            [<Config.Path>]
            Capability: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// To request a new capability for an account, pass true. There can be a delay before the requested capability becomes active. If the capability has any activation requirements, the response includes them in the `requirements` arrays.
            /// If a capability isn't permanent, you can remove it from the account by passing false. Some capabilities are permanent after they've been requested. Attempting to remove a permanent capability returns an error.
            [<Config.Form>]
            Requested: bool option
        }

    module UpdateOptions =
        let create
            (
                account: string,
                capability: string
            ) : UpdateOptions
            =
            {
              Account = account
              Capability = capability
              Expand = None
              Requested = None
            }

    ///<p>Returns a list of capabilities associated with the account. The capabilities are returned sorted by creation date, with the most recent capability appearing first.</p>
    let Capabilities settings (options: CapabilitiesOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/accounts/{options.Account}/capabilities"
        |> RestApi.getAsync<StripeList<Capability>> settings qs

    ///<p>Retrieves information about the specified Account Capability.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/accounts/{options.Account}/capabilities/{options.Capability}"
        |> RestApi.getAsync<Capability> settings qs

    ///<p>Updates an existing Account Capability. Request or remove a capability by updating its <code>requested</code> parameter.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/accounts/{options.Account}/capabilities/{options.Capability}"
        |> RestApi.postAsync<_, Capability> settings (Map.empty) options

module AccountsExternalAccounts =

    type ListOptions =
        {
            [<Config.Path>]
            Account: string
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// Filter external accounts according to a particular object type.
            [<Config.Query>]
            Object: string option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    module ListOptions =
        let create
            (
                account: string
            ) : ListOptions
            =
            {
              Account = account
              EndingBefore = None
              Expand = None
              Limit = None
              Object = None
              StartingAfter = None
            }

    type CreateOptions =
        {
            [<Config.Path>]
            Account: string
            /// When set to true, or if this is the first external account added in this currency, this account becomes the default external account for its currency.
            [<Config.Form>]
            DefaultForCurrency: bool option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A token, like the ones returned by [Stripe.js](https://docs.stripe.com/js) or a dictionary containing a user's external account details (with the options shown below). Please refer to full [documentation](https://stripe.com/docs/api/external_accounts) instead.
            [<Config.Form>]
            ExternalAccount: string
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
        }

    module CreateOptions =
        let create
            (
                account: string,
                externalAccount: string
            ) : CreateOptions
            =
            {
              Account = account
              ExternalAccount = externalAccount
              DefaultForCurrency = None
              Expand = None
              Metadata = None
            }

    type DeleteOptions =
        {
            [<Config.Path>]
            Account: string
            /// Unique identifier for the external account to be deleted.
            [<Config.Path>]
            Id: string
        }

    module DeleteOptions =
        let create
            (
                account: string,
                id: string
            ) : DeleteOptions
            =
            {
              Account = account
              Id = id
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Account: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// Unique identifier for the external account to be retrieved.
            [<Config.Path>]
            Id: string
        }

    module RetrieveOptions =
        let create
            (
                account: string,
                id: string
            ) : RetrieveOptions
            =
            {
              Account = account
              Id = id
              Expand = None
            }

    type Update'AccountHolderType =
        | Company
        | Individual

    type Update'AccountType =
        | Checking
        | Futsu
        | Savings
        | Toza

    type Update'DocumentsBankAccountOwnershipVerification =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: string list option
        }

    module Update'DocumentsBankAccountOwnershipVerification =
        let create
            (
                files: string list option
            ) : Update'DocumentsBankAccountOwnershipVerification
            =
            {
              Files = files
            }

    type Update'Documents =
        {
            /// One or more documents that support the [Bank account ownership verification](https://support.stripe.com/questions/bank-account-ownership-verification) requirement. Must be a document associated with the bank account that displays the last 4 digits of the account number, either a statement or a check.
            [<Config.Form>]
            BankAccountOwnershipVerification: Update'DocumentsBankAccountOwnershipVerification option
        }

    module Update'Documents =
        let create
            (
                bankAccountOwnershipVerification: Update'DocumentsBankAccountOwnershipVerification option
            ) : Update'Documents
            =
            {
              BankAccountOwnershipVerification = bankAccountOwnershipVerification
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Account: string
            [<Config.Path>]
            Id: string
            /// The name of the person or business that owns the bank account.
            [<Config.Form>]
            AccountHolderName: string option
            /// The type of entity that holds the account. This can be either `individual` or `company`.
            [<Config.Form>]
            AccountHolderType: Update'AccountHolderType option
            /// The bank account type. This can only be `checking` or `savings` in most countries. In Japan, this can only be `futsu` or `toza`.
            [<Config.Form>]
            AccountType: Update'AccountType option
            /// City/District/Suburb/Town/Village.
            [<Config.Form>]
            AddressCity: string option
            /// Billing address country, if provided when creating card.
            [<Config.Form>]
            AddressCountry: IsoTypes.IsoCountryCode option
            /// Address line 1 (Street address/PO Box/Company name).
            [<Config.Form>]
            AddressLine1: string option
            /// Address line 2 (Apartment/Suite/Unit/Building).
            [<Config.Form>]
            AddressLine2: string option
            /// State/County/Province/Region.
            [<Config.Form>]
            AddressState: string option
            /// ZIP or postal code.
            [<Config.Form>]
            AddressZip: string option
            /// When set to true, this becomes the default external account for its currency.
            [<Config.Form>]
            DefaultForCurrency: bool option
            /// Documents that may be submitted to satisfy various informational requests.
            [<Config.Form>]
            Documents: Update'Documents option
            /// Two digit number representing the card’s expiration month.
            [<Config.Form>]
            ExpMonth: string option
            /// Four digit number representing the card’s expiration year.
            [<Config.Form>]
            ExpYear: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Cardholder name.
            [<Config.Form>]
            Name: string option
        }

    module UpdateOptions =
        let create
            (
                account: string,
                id: string
            ) : UpdateOptions
            =
            {
              Account = account
              Id = id
              AccountHolderName = None
              AccountHolderType = None
              AccountType = None
              AddressCity = None
              AddressCountry = None
              AddressLine1 = None
              AddressLine2 = None
              AddressState = None
              AddressZip = None
              DefaultForCurrency = None
              Documents = None
              ExpMonth = None
              ExpYear = None
              Expand = None
              Metadata = None
              Name = None
            }

    ///<p>List external accounts for an account.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("object", options.Object |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/accounts/{options.Account}/external_accounts"
        |> RestApi.getAsync<StripeList<ExternalAccount>> settings qs

    ///<p>Create an external account for a given account.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/accounts/{options.Account}/external_accounts"
        |> RestApi.postAsync<_, ExternalAccount> settings (Map.empty) options

    ///<p>Delete a specified external account for a given account.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/accounts/{options.Account}/external_accounts/{options.Id}"
        |> RestApi.deleteAsync<DeletedExternalAccount> settings (Map.empty)

    ///<p>Retrieve a specified external account for a given account.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/accounts/{options.Account}/external_accounts/{options.Id}"
        |> RestApi.getAsync<ExternalAccount> settings qs

    ///<p>Updates the metadata, account holder name, account holder type of a bank account belonging to
    ///a connected account and optionally sets it as the default for its currency. Other bank account
    ///details are not editable by design.</p>
    ///<p>You can only update bank accounts when <a href="/api/accounts/object#account_object-controller-requirement_collection">account.controller.requirement_collection</a> is <code>application</code>, which includes <a href="/connect/custom-accounts">Custom accounts</a>.</p>
    ///<p>You can re-enable a disabled bank account by performing an update call without providing any
    ///arguments or changes.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/accounts/{options.Account}/external_accounts/{options.Id}"
        |> RestApi.postAsync<_, ExternalAccount> settings (Map.empty) options

module AccountsLoginLinks =

    type CreateOptions =
        {
            [<Config.Path>]
            Account: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module CreateOptions =
        let create
            (
                account: string
            ) : CreateOptions
            =
            {
              Account = account
              Expand = None
            }

    ///<p>Creates a login link for a connected account to access the Express Dashboard.</p>
    ///<p><strong>You can only create login links for accounts that use the <a href="/connect/express-dashboard">Express Dashboard</a> and are connected to your platform</strong>.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/accounts/{options.Account}/login_links"
        |> RestApi.postAsync<_, LoginLink> settings (Map.empty) options

module AccountsPersons =

    type PersonsOptions =
        {
            [<Config.Path>]
            Account: string
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// Filters on the list of people returned based on the person's relationship to the account's company.
            [<Config.Query>]
            Relationship: Map<string, string> option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    module PersonsOptions =
        let create
            (
                account: string
            ) : PersonsOptions
            =
            {
              Account = account
              EndingBefore = None
              Expand = None
              Limit = None
              Relationship = None
              StartingAfter = None
            }

    type Create'AdditionalTosAcceptancesAccount =
        {
            /// The Unix timestamp marking when the account representative accepted the service agreement.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the account representative accepted the service agreement.
            [<Config.Form>]
            Ip: string option
            /// The user agent of the browser from which the account representative accepted the service agreement.
            [<Config.Form>]
            UserAgent: Choice<string,string> option
        }

    module Create'AdditionalTosAcceptancesAccount =
        let create
            (
                date: DateTime option,
                ip: string option,
                userAgent: Choice<string,string> option
            ) : Create'AdditionalTosAcceptancesAccount
            =
            {
              Date = date
              Ip = ip
              UserAgent = userAgent
            }

    type Create'AdditionalTosAcceptances =
        {
            /// Details on the legal guardian's acceptance of the main Stripe service agreement.
            [<Config.Form>]
            Account: Create'AdditionalTosAcceptancesAccount option
        }

    module Create'AdditionalTosAcceptances =
        let create
            (
                account: Create'AdditionalTosAcceptancesAccount option
            ) : Create'AdditionalTosAcceptances
            =
            {
              Account = account
            }

    type Create'Address =
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

    module Create'Address =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Create'Address
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Create'AddressKana =
        {
            /// City or ward.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Block or building number.
            [<Config.Form>]
            Line1: string option
            /// Building details.
            [<Config.Form>]
            Line2: string option
            /// Postal code.
            [<Config.Form>]
            PostalCode: string option
            /// Prefecture.
            [<Config.Form>]
            State: string option
            /// Town or cho-me.
            [<Config.Form>]
            Town: string option
        }

    module Create'AddressKana =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option,
                town: string option
            ) : Create'AddressKana
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
              Town = town
            }

    type Create'AddressKanji =
        {
            /// City or ward.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Block or building number.
            [<Config.Form>]
            Line1: string option
            /// Building details.
            [<Config.Form>]
            Line2: string option
            /// Postal code.
            [<Config.Form>]
            PostalCode: string option
            /// Prefecture.
            [<Config.Form>]
            State: string option
            /// Town or cho-me.
            [<Config.Form>]
            Town: string option
        }

    module Create'AddressKanji =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option,
                town: string option
            ) : Create'AddressKanji
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
              Town = town
            }

    type Create'DobDateOfBirthSpecs =
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

    module Create'DobDateOfBirthSpecs =
        let create
            (
                day: int option,
                month: int option,
                year: int option
            ) : Create'DobDateOfBirthSpecs
            =
            {
              Day = day
              Month = month
              Year = year
            }

    type Create'DocumentsCompanyAuthorization =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: Choice<string,string> list option
        }

    module Create'DocumentsCompanyAuthorization =
        let create
            (
                files: Choice<string,string> list option
            ) : Create'DocumentsCompanyAuthorization
            =
            {
              Files = files
            }

    type Create'DocumentsPassport =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: Choice<string,string> list option
        }

    module Create'DocumentsPassport =
        let create
            (
                files: Choice<string,string> list option
            ) : Create'DocumentsPassport
            =
            {
              Files = files
            }

    type Create'DocumentsVisa =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: Choice<string,string> list option
        }

    module Create'DocumentsVisa =
        let create
            (
                files: Choice<string,string> list option
            ) : Create'DocumentsVisa
            =
            {
              Files = files
            }

    type Create'Documents =
        {
            /// One or more documents that demonstrate proof that this person is authorized to represent the company.
            [<Config.Form>]
            CompanyAuthorization: Create'DocumentsCompanyAuthorization option
            /// One or more documents showing the person's passport page with photo and personal data.
            [<Config.Form>]
            Passport: Create'DocumentsPassport option
            /// One or more documents showing the person's visa required for living in the country where they are residing.
            [<Config.Form>]
            Visa: Create'DocumentsVisa option
        }

    module Create'Documents =
        let create
            (
                companyAuthorization: Create'DocumentsCompanyAuthorization option,
                passport: Create'DocumentsPassport option,
                visa: Create'DocumentsVisa option
            ) : Create'Documents
            =
            {
              CompanyAuthorization = companyAuthorization
              Passport = passport
              Visa = visa
            }

    type Create'PoliticalExposure =
        | Existing
        | [<JsonPropertyName("none")>] None'

    type Create'RegisteredAddress =
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

    module Create'RegisteredAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Create'RegisteredAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Create'Relationship =
        {
            /// Whether the person is the authorizer of the account's representative.
            [<Config.Form>]
            Authorizer: bool option
            /// Whether the person is a director of the account's legal entity. Directors are typically members of the governing board of the company, or responsible for ensuring the company meets its regulatory obligations.
            [<Config.Form>]
            Director: bool option
            /// Whether the person has significant responsibility to control, manage, or direct the organization.
            [<Config.Form>]
            Executive: bool option
            /// Whether the person is the legal guardian of the account's representative.
            [<Config.Form>]
            LegalGuardian: bool option
            /// Whether the person is an owner of the account’s legal entity.
            [<Config.Form>]
            Owner: bool option
            /// The percent owned by the person of the account's legal entity.
            [<Config.Form>]
            PercentOwnership: Choice<decimal,string> option
            /// Whether the person is authorized as the primary representative of the account. This is the person nominated by the business to provide information about themselves, and general information about the account. There can only be one representative at any given time. At the time the account is created, this person should be set to the person responsible for opening the account.
            [<Config.Form>]
            Representative: bool option
            /// The person's title (e.g., CEO, Support Engineer).
            [<Config.Form>]
            Title: string option
        }

    module Create'Relationship =
        let create
            (
                authorizer: bool option,
                director: bool option,
                executive: bool option,
                legalGuardian: bool option,
                owner: bool option,
                percentOwnership: Choice<decimal,string> option,
                representative: bool option,
                title: string option
            ) : Create'Relationship
            =
            {
              Authorizer = authorizer
              Director = director
              Executive = executive
              LegalGuardian = legalGuardian
              Owner = owner
              PercentOwnership = percentOwnership
              Representative = representative
              Title = title
            }

    type Create'UsCfpbDataEthnicityDetailsEthnicity =
        | Cuban
        | HispanicOrLatino
        | Mexican
        | NotHispanicOrLatino
        | OtherHispanicOrLatino
        | PreferNotToAnswer
        | PuertoRican

    type Create'UsCfpbDataEthnicityDetails =
        {
            /// The persons ethnicity
            [<Config.Form>]
            Ethnicity: Create'UsCfpbDataEthnicityDetailsEthnicity list option
            /// Please specify your origin, when other is selected.
            [<Config.Form>]
            EthnicityOther: string option
        }

    module Create'UsCfpbDataEthnicityDetails =
        let create
            (
                ethnicity: Create'UsCfpbDataEthnicityDetailsEthnicity list option,
                ethnicityOther: string option
            ) : Create'UsCfpbDataEthnicityDetails
            =
            {
              Ethnicity = ethnicity
              EthnicityOther = ethnicityOther
            }

    type Create'UsCfpbDataRaceDetailsRace =
        | AfricanAmerican
        | AmericanIndianOrAlaskaNative
        | Asian
        | AsianIndian
        | BlackOrAfricanAmerican
        | Chinese
        | Ethiopian
        | Filipino
        | GuamanianOrChamorro
        | Haitian
        | Jamaican
        | Japanese
        | Korean
        | NativeHawaiian
        | NativeHawaiianOrOtherPacificIslander
        | Nigerian
        | OtherAsian
        | OtherBlackOrAfricanAmerican
        | OtherPacificIslander
        | PreferNotToAnswer
        | Samoan
        | Somali
        | Vietnamese
        | White

    type Create'UsCfpbDataRaceDetails =
        {
            /// The persons race.
            [<Config.Form>]
            Race: Create'UsCfpbDataRaceDetailsRace list option
            /// Please specify your race, when other is selected.
            [<Config.Form>]
            RaceOther: string option
        }

    module Create'UsCfpbDataRaceDetails =
        let create
            (
                race: Create'UsCfpbDataRaceDetailsRace list option,
                raceOther: string option
            ) : Create'UsCfpbDataRaceDetails
            =
            {
              Race = race
              RaceOther = raceOther
            }

    type Create'UsCfpbData =
        {
            /// The persons ethnicity details
            [<Config.Form>]
            EthnicityDetails: Create'UsCfpbDataEthnicityDetails option
            /// The persons race details
            [<Config.Form>]
            RaceDetails: Create'UsCfpbDataRaceDetails option
            /// The persons self-identified gender
            [<Config.Form>]
            SelfIdentifiedGender: string option
        }

    module Create'UsCfpbData =
        let create
            (
                ethnicityDetails: Create'UsCfpbDataEthnicityDetails option,
                raceDetails: Create'UsCfpbDataRaceDetails option,
                selfIdentifiedGender: string option
            ) : Create'UsCfpbData
            =
            {
              EthnicityDetails = ethnicityDetails
              RaceDetails = raceDetails
              SelfIdentifiedGender = selfIdentifiedGender
            }

    type Create'VerificationAdditionalDocument =
        {
            /// The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Back: string option
            /// The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Front: string option
        }

    module Create'VerificationAdditionalDocument =
        let create
            (
                back: string option,
                front: string option
            ) : Create'VerificationAdditionalDocument
            =
            {
              Back = back
              Front = front
            }

    type Create'VerificationDocument =
        {
            /// The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Back: string option
            /// The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Front: string option
        }

    module Create'VerificationDocument =
        let create
            (
                back: string option,
                front: string option
            ) : Create'VerificationDocument
            =
            {
              Back = back
              Front = front
            }

    type Create'Verification =
        {
            /// A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.
            [<Config.Form>]
            AdditionalDocument: Create'VerificationAdditionalDocument option
            /// An identifying document, either a passport or local ID card.
            [<Config.Form>]
            Document: Create'VerificationDocument option
        }

    module Create'Verification =
        let create
            (
                additionalDocument: Create'VerificationAdditionalDocument option,
                document: Create'VerificationDocument option
            ) : Create'Verification
            =
            {
              AdditionalDocument = additionalDocument
              Document = document
            }

    type CreateOptions =
        {
            [<Config.Path>]
            Account: string
            /// Details on the legal guardian's or authorizer's acceptance of the required Stripe agreements.
            [<Config.Form>]
            AdditionalTosAcceptances: Create'AdditionalTosAcceptances option
            /// The person's address.
            [<Config.Form>]
            Address: Create'Address option
            /// The Kana variation of the person's address (Japan only).
            [<Config.Form>]
            AddressKana: Create'AddressKana option
            /// The Kanji variation of the person's address (Japan only).
            [<Config.Form>]
            AddressKanji: Create'AddressKanji option
            /// The person's date of birth.
            [<Config.Form>]
            Dob: Choice<Create'DobDateOfBirthSpecs,string> option
            /// Documents that may be submitted to satisfy various informational requests.
            [<Config.Form>]
            Documents: Create'Documents option
            /// The person's email address.
            [<Config.Form>]
            Email: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The person's first name.
            [<Config.Form>]
            FirstName: string option
            /// The Kana variation of the person's first name (Japan only).
            [<Config.Form>]
            FirstNameKana: string option
            /// The Kanji variation of the person's first name (Japan only).
            [<Config.Form>]
            FirstNameKanji: string option
            /// A list of alternate names or aliases that the person is known by.
            [<Config.Form>]
            FullNameAliases: Choice<string list,string> option
            /// The person's gender (International regulations require either "male" or "female").
            [<Config.Form>]
            Gender: string option
            /// The person's ID number, as appropriate for their country. For example, a social security number in the U.S., social insurance number in Canada, etc. Instead of the number itself, you can also provide a [PII token provided by Stripe.js](https://docs.stripe.com/js/tokens/create_token?type=pii).
            [<Config.Form>]
            IdNumber: string option
            /// The person's secondary ID number, as appropriate for their country, will be used for enhanced verification checks. In Thailand, this would be the laser code found on the back of an ID card. Instead of the number itself, you can also provide a [PII token provided by Stripe.js](https://docs.stripe.com/js/tokens/create_token?type=pii).
            [<Config.Form>]
            IdNumberSecondary: string option
            /// The person's last name.
            [<Config.Form>]
            LastName: string option
            /// The Kana variation of the person's last name (Japan only).
            [<Config.Form>]
            LastNameKana: string option
            /// The Kanji variation of the person's last name (Japan only).
            [<Config.Form>]
            LastNameKanji: string option
            /// The person's maiden name.
            [<Config.Form>]
            MaidenName: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The country where the person is a national. Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)), or "XX" if unavailable.
            [<Config.Form>]
            Nationality: string option
            /// A [person token](https://docs.stripe.com/connect/account-tokens), used to securely provide details to the person.
            [<Config.Form>]
            PersonToken: string option
            /// The person's phone number.
            [<Config.Form>]
            Phone: string option
            /// Indicates if the person or any of their representatives, family members, or other closely related persons, declares that they hold or have held an important public job or function, in any jurisdiction.
            [<Config.Form>]
            PoliticalExposure: Create'PoliticalExposure option
            /// The person's registered address.
            [<Config.Form>]
            RegisteredAddress: Create'RegisteredAddress option
            /// The relationship that this person has with the account's legal entity.
            [<Config.Form>]
            Relationship: Create'Relationship option
            /// The last four digits of the person's Social Security number (U.S. only).
            [<Config.Form>]
            SsnLast4: string option
            /// Demographic data related to the person.
            [<Config.Form>]
            UsCfpbData: Create'UsCfpbData option
            /// The person's verification status.
            [<Config.Form>]
            Verification: Create'Verification option
        }

    module CreateOptions =
        let create
            (
                account: string
            ) : CreateOptions
            =
            {
              Account = account
              AdditionalTosAcceptances = None
              Address = None
              AddressKana = None
              AddressKanji = None
              Dob = None
              Documents = None
              Email = None
              Expand = None
              FirstName = None
              FirstNameKana = None
              FirstNameKanji = None
              FullNameAliases = None
              Gender = None
              IdNumber = None
              IdNumberSecondary = None
              LastName = None
              LastNameKana = None
              LastNameKanji = None
              MaidenName = None
              Metadata = None
              Nationality = None
              PersonToken = None
              Phone = None
              PoliticalExposure = None
              RegisteredAddress = None
              Relationship = None
              SsnLast4 = None
              UsCfpbData = None
              Verification = None
            }

    type DeleteOptions =
        { [<Config.Path>]
          Account: string
          [<Config.Path>]
          Person: string }

    module DeleteOptions =
        let create
            (
                account: string,
                person: string
            ) : DeleteOptions
            =
            {
              Account = account
              Person = person
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Account: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Person: string
        }

    module RetrieveOptions =
        let create
            (
                account: string,
                person: string
            ) : RetrieveOptions
            =
            {
              Account = account
              Person = person
              Expand = None
            }

    type Update'AdditionalTosAcceptancesAccount =
        {
            /// The Unix timestamp marking when the account representative accepted the service agreement.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the account representative accepted the service agreement.
            [<Config.Form>]
            Ip: string option
            /// The user agent of the browser from which the account representative accepted the service agreement.
            [<Config.Form>]
            UserAgent: Choice<string,string> option
        }

    module Update'AdditionalTosAcceptancesAccount =
        let create
            (
                date: DateTime option,
                ip: string option,
                userAgent: Choice<string,string> option
            ) : Update'AdditionalTosAcceptancesAccount
            =
            {
              Date = date
              Ip = ip
              UserAgent = userAgent
            }

    type Update'AdditionalTosAcceptances =
        {
            /// Details on the legal guardian's acceptance of the main Stripe service agreement.
            [<Config.Form>]
            Account: Update'AdditionalTosAcceptancesAccount option
        }

    module Update'AdditionalTosAcceptances =
        let create
            (
                account: Update'AdditionalTosAcceptancesAccount option
            ) : Update'AdditionalTosAcceptances
            =
            {
              Account = account
            }

    type Update'Address =
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

    module Update'Address =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Update'Address
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Update'AddressKana =
        {
            /// City or ward.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Block or building number.
            [<Config.Form>]
            Line1: string option
            /// Building details.
            [<Config.Form>]
            Line2: string option
            /// Postal code.
            [<Config.Form>]
            PostalCode: string option
            /// Prefecture.
            [<Config.Form>]
            State: string option
            /// Town or cho-me.
            [<Config.Form>]
            Town: string option
        }

    module Update'AddressKana =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option,
                town: string option
            ) : Update'AddressKana
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
              Town = town
            }

    type Update'AddressKanji =
        {
            /// City or ward.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Block or building number.
            [<Config.Form>]
            Line1: string option
            /// Building details.
            [<Config.Form>]
            Line2: string option
            /// Postal code.
            [<Config.Form>]
            PostalCode: string option
            /// Prefecture.
            [<Config.Form>]
            State: string option
            /// Town or cho-me.
            [<Config.Form>]
            Town: string option
        }

    module Update'AddressKanji =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option,
                town: string option
            ) : Update'AddressKanji
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
              Town = town
            }

    type Update'DobDateOfBirthSpecs =
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

    module Update'DobDateOfBirthSpecs =
        let create
            (
                day: int option,
                month: int option,
                year: int option
            ) : Update'DobDateOfBirthSpecs
            =
            {
              Day = day
              Month = month
              Year = year
            }

    type Update'DocumentsCompanyAuthorization =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: Choice<string,string> list option
        }

    module Update'DocumentsCompanyAuthorization =
        let create
            (
                files: Choice<string,string> list option
            ) : Update'DocumentsCompanyAuthorization
            =
            {
              Files = files
            }

    type Update'DocumentsPassport =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: Choice<string,string> list option
        }

    module Update'DocumentsPassport =
        let create
            (
                files: Choice<string,string> list option
            ) : Update'DocumentsPassport
            =
            {
              Files = files
            }

    type Update'DocumentsVisa =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: Choice<string,string> list option
        }

    module Update'DocumentsVisa =
        let create
            (
                files: Choice<string,string> list option
            ) : Update'DocumentsVisa
            =
            {
              Files = files
            }

    type Update'Documents =
        {
            /// One or more documents that demonstrate proof that this person is authorized to represent the company.
            [<Config.Form>]
            CompanyAuthorization: Update'DocumentsCompanyAuthorization option
            /// One or more documents showing the person's passport page with photo and personal data.
            [<Config.Form>]
            Passport: Update'DocumentsPassport option
            /// One or more documents showing the person's visa required for living in the country where they are residing.
            [<Config.Form>]
            Visa: Update'DocumentsVisa option
        }

    module Update'Documents =
        let create
            (
                companyAuthorization: Update'DocumentsCompanyAuthorization option,
                passport: Update'DocumentsPassport option,
                visa: Update'DocumentsVisa option
            ) : Update'Documents
            =
            {
              CompanyAuthorization = companyAuthorization
              Passport = passport
              Visa = visa
            }

    type Update'PoliticalExposure =
        | Existing
        | [<JsonPropertyName("none")>] None'

    type Update'RegisteredAddress =
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

    module Update'RegisteredAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Update'RegisteredAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Update'Relationship =
        {
            /// Whether the person is the authorizer of the account's representative.
            [<Config.Form>]
            Authorizer: bool option
            /// Whether the person is a director of the account's legal entity. Directors are typically members of the governing board of the company, or responsible for ensuring the company meets its regulatory obligations.
            [<Config.Form>]
            Director: bool option
            /// Whether the person has significant responsibility to control, manage, or direct the organization.
            [<Config.Form>]
            Executive: bool option
            /// Whether the person is the legal guardian of the account's representative.
            [<Config.Form>]
            LegalGuardian: bool option
            /// Whether the person is an owner of the account’s legal entity.
            [<Config.Form>]
            Owner: bool option
            /// The percent owned by the person of the account's legal entity.
            [<Config.Form>]
            PercentOwnership: Choice<decimal,string> option
            /// Whether the person is authorized as the primary representative of the account. This is the person nominated by the business to provide information about themselves, and general information about the account. There can only be one representative at any given time. At the time the account is created, this person should be set to the person responsible for opening the account.
            [<Config.Form>]
            Representative: bool option
            /// The person's title (e.g., CEO, Support Engineer).
            [<Config.Form>]
            Title: string option
        }

    module Update'Relationship =
        let create
            (
                authorizer: bool option,
                director: bool option,
                executive: bool option,
                legalGuardian: bool option,
                owner: bool option,
                percentOwnership: Choice<decimal,string> option,
                representative: bool option,
                title: string option
            ) : Update'Relationship
            =
            {
              Authorizer = authorizer
              Director = director
              Executive = executive
              LegalGuardian = legalGuardian
              Owner = owner
              PercentOwnership = percentOwnership
              Representative = representative
              Title = title
            }

    type Update'UsCfpbDataEthnicityDetailsEthnicity =
        | Cuban
        | HispanicOrLatino
        | Mexican
        | NotHispanicOrLatino
        | OtherHispanicOrLatino
        | PreferNotToAnswer
        | PuertoRican

    type Update'UsCfpbDataEthnicityDetails =
        {
            /// The persons ethnicity
            [<Config.Form>]
            Ethnicity: Update'UsCfpbDataEthnicityDetailsEthnicity list option
            /// Please specify your origin, when other is selected.
            [<Config.Form>]
            EthnicityOther: string option
        }

    module Update'UsCfpbDataEthnicityDetails =
        let create
            (
                ethnicity: Update'UsCfpbDataEthnicityDetailsEthnicity list option,
                ethnicityOther: string option
            ) : Update'UsCfpbDataEthnicityDetails
            =
            {
              Ethnicity = ethnicity
              EthnicityOther = ethnicityOther
            }

    type Update'UsCfpbDataRaceDetailsRace =
        | AfricanAmerican
        | AmericanIndianOrAlaskaNative
        | Asian
        | AsianIndian
        | BlackOrAfricanAmerican
        | Chinese
        | Ethiopian
        | Filipino
        | GuamanianOrChamorro
        | Haitian
        | Jamaican
        | Japanese
        | Korean
        | NativeHawaiian
        | NativeHawaiianOrOtherPacificIslander
        | Nigerian
        | OtherAsian
        | OtherBlackOrAfricanAmerican
        | OtherPacificIslander
        | PreferNotToAnswer
        | Samoan
        | Somali
        | Vietnamese
        | White

    type Update'UsCfpbDataRaceDetails =
        {
            /// The persons race.
            [<Config.Form>]
            Race: Update'UsCfpbDataRaceDetailsRace list option
            /// Please specify your race, when other is selected.
            [<Config.Form>]
            RaceOther: string option
        }

    module Update'UsCfpbDataRaceDetails =
        let create
            (
                race: Update'UsCfpbDataRaceDetailsRace list option,
                raceOther: string option
            ) : Update'UsCfpbDataRaceDetails
            =
            {
              Race = race
              RaceOther = raceOther
            }

    type Update'UsCfpbData =
        {
            /// The persons ethnicity details
            [<Config.Form>]
            EthnicityDetails: Update'UsCfpbDataEthnicityDetails option
            /// The persons race details
            [<Config.Form>]
            RaceDetails: Update'UsCfpbDataRaceDetails option
            /// The persons self-identified gender
            [<Config.Form>]
            SelfIdentifiedGender: string option
        }

    module Update'UsCfpbData =
        let create
            (
                ethnicityDetails: Update'UsCfpbDataEthnicityDetails option,
                raceDetails: Update'UsCfpbDataRaceDetails option,
                selfIdentifiedGender: string option
            ) : Update'UsCfpbData
            =
            {
              EthnicityDetails = ethnicityDetails
              RaceDetails = raceDetails
              SelfIdentifiedGender = selfIdentifiedGender
            }

    type Update'VerificationAdditionalDocument =
        {
            /// The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Back: string option
            /// The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Front: string option
        }

    module Update'VerificationAdditionalDocument =
        let create
            (
                back: string option,
                front: string option
            ) : Update'VerificationAdditionalDocument
            =
            {
              Back = back
              Front = front
            }

    type Update'VerificationDocument =
        {
            /// The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Back: string option
            /// The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Front: string option
        }

    module Update'VerificationDocument =
        let create
            (
                back: string option,
                front: string option
            ) : Update'VerificationDocument
            =
            {
              Back = back
              Front = front
            }

    type Update'Verification =
        {
            /// A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.
            [<Config.Form>]
            AdditionalDocument: Update'VerificationAdditionalDocument option
            /// An identifying document, either a passport or local ID card.
            [<Config.Form>]
            Document: Update'VerificationDocument option
        }

    module Update'Verification =
        let create
            (
                additionalDocument: Update'VerificationAdditionalDocument option,
                document: Update'VerificationDocument option
            ) : Update'Verification
            =
            {
              AdditionalDocument = additionalDocument
              Document = document
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Account: string
            [<Config.Path>]
            Person: string
            /// Details on the legal guardian's or authorizer's acceptance of the required Stripe agreements.
            [<Config.Form>]
            AdditionalTosAcceptances: Update'AdditionalTosAcceptances option
            /// The person's address.
            [<Config.Form>]
            Address: Update'Address option
            /// The Kana variation of the person's address (Japan only).
            [<Config.Form>]
            AddressKana: Update'AddressKana option
            /// The Kanji variation of the person's address (Japan only).
            [<Config.Form>]
            AddressKanji: Update'AddressKanji option
            /// The person's date of birth.
            [<Config.Form>]
            Dob: Choice<Update'DobDateOfBirthSpecs,string> option
            /// Documents that may be submitted to satisfy various informational requests.
            [<Config.Form>]
            Documents: Update'Documents option
            /// The person's email address.
            [<Config.Form>]
            Email: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The person's first name.
            [<Config.Form>]
            FirstName: string option
            /// The Kana variation of the person's first name (Japan only).
            [<Config.Form>]
            FirstNameKana: string option
            /// The Kanji variation of the person's first name (Japan only).
            [<Config.Form>]
            FirstNameKanji: string option
            /// A list of alternate names or aliases that the person is known by.
            [<Config.Form>]
            FullNameAliases: Choice<string list,string> option
            /// The person's gender (International regulations require either "male" or "female").
            [<Config.Form>]
            Gender: string option
            /// The person's ID number, as appropriate for their country. For example, a social security number in the U.S., social insurance number in Canada, etc. Instead of the number itself, you can also provide a [PII token provided by Stripe.js](https://docs.stripe.com/js/tokens/create_token?type=pii).
            [<Config.Form>]
            IdNumber: string option
            /// The person's secondary ID number, as appropriate for their country, will be used for enhanced verification checks. In Thailand, this would be the laser code found on the back of an ID card. Instead of the number itself, you can also provide a [PII token provided by Stripe.js](https://docs.stripe.com/js/tokens/create_token?type=pii).
            [<Config.Form>]
            IdNumberSecondary: string option
            /// The person's last name.
            [<Config.Form>]
            LastName: string option
            /// The Kana variation of the person's last name (Japan only).
            [<Config.Form>]
            LastNameKana: string option
            /// The Kanji variation of the person's last name (Japan only).
            [<Config.Form>]
            LastNameKanji: string option
            /// The person's maiden name.
            [<Config.Form>]
            MaidenName: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The country where the person is a national. Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)), or "XX" if unavailable.
            [<Config.Form>]
            Nationality: string option
            /// A [person token](https://docs.stripe.com/connect/account-tokens), used to securely provide details to the person.
            [<Config.Form>]
            PersonToken: string option
            /// The person's phone number.
            [<Config.Form>]
            Phone: string option
            /// Indicates if the person or any of their representatives, family members, or other closely related persons, declares that they hold or have held an important public job or function, in any jurisdiction.
            [<Config.Form>]
            PoliticalExposure: Update'PoliticalExposure option
            /// The person's registered address.
            [<Config.Form>]
            RegisteredAddress: Update'RegisteredAddress option
            /// The relationship that this person has with the account's legal entity.
            [<Config.Form>]
            Relationship: Update'Relationship option
            /// The last four digits of the person's Social Security number (U.S. only).
            [<Config.Form>]
            SsnLast4: string option
            /// Demographic data related to the person.
            [<Config.Form>]
            UsCfpbData: Update'UsCfpbData option
            /// The person's verification status.
            [<Config.Form>]
            Verification: Update'Verification option
        }

    module UpdateOptions =
        let create
            (
                account: string,
                person: string
            ) : UpdateOptions
            =
            {
              Account = account
              Person = person
              AdditionalTosAcceptances = None
              Address = None
              AddressKana = None
              AddressKanji = None
              Dob = None
              Documents = None
              Email = None
              Expand = None
              FirstName = None
              FirstNameKana = None
              FirstNameKanji = None
              FullNameAliases = None
              Gender = None
              IdNumber = None
              IdNumberSecondary = None
              LastName = None
              LastNameKana = None
              LastNameKanji = None
              MaidenName = None
              Metadata = None
              Nationality = None
              PersonToken = None
              Phone = None
              PoliticalExposure = None
              RegisteredAddress = None
              Relationship = None
              SsnLast4 = None
              UsCfpbData = None
              Verification = None
            }

    ///<p>Returns a list of people associated with the account’s legal entity. The people are returned sorted by creation date, with the most recent people appearing first.</p>
    let Persons settings (options: PersonsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("relationship", options.Relationship |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/accounts/{options.Account}/persons"
        |> RestApi.getAsync<StripeList<Person>> settings qs

    ///<p>Creates a new person.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/accounts/{options.Account}/persons"
        |> RestApi.postAsync<_, Person> settings (Map.empty) options

    ///<p>Deletes an existing person’s relationship to the account’s legal entity. Any person with a relationship for an account can be deleted through the API, except if the person is the <code>account_opener</code>. If your integration is using the <code>executive</code> parameter, you cannot delete the only verified <code>executive</code> on file.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/accounts/{options.Account}/persons/{options.Person}"
        |> RestApi.deleteAsync<DeletedPerson> settings (Map.empty)

    ///<p>Retrieves an existing person.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/accounts/{options.Account}/persons/{options.Person}"
        |> RestApi.getAsync<Person> settings qs

    ///<p>Updates an existing person.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/accounts/{options.Account}/persons/{options.Person}"
        |> RestApi.postAsync<_, Person> settings (Map.empty) options

module AccountsReject =

    type RejectOptions =
        {
            [<Config.Path>]
            Account: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The reason for rejecting the account. Can be `fraud`, `terms_of_service`, or `other`.
            [<Config.Form>]
            Reason: string
        }

    module RejectOptions =
        let create
            (
                account: string,
                reason: string
            ) : RejectOptions
            =
            {
              Account = account
              Reason = reason
              Expand = None
            }

    ///<p>With <a href="/connect">Connect</a>, you can reject accounts that you have flagged as suspicious.</p>
    ///<p>Only accounts where your platform is liable for negative account balances, which includes Custom and Express accounts, can be rejected. Test-mode accounts can be rejected at any time. Live-mode accounts can only be rejected after all balances are zero.</p>
    let Reject settings (options: RejectOptions) =
        $"/v1/accounts/{options.Account}/reject"
        |> RestApi.postAsync<_, Account> settings (Map.empty) options

