namespace FunStripe.StripeRequest

open FunStripe
open FunStripe.Json
open FunStripe.StripeModel
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module AccountLinks =

    type Create'Collect =
    | CurrentlyDue
    | EventuallyDue

    type Create'Type =
    | AccountOnboarding
    | AccountUpdate

    type CreateOptions = {
        ///The identifier of the account to create an account link for.
        [<Config.Form>]Account: string
        ///Which information the platform needs to collect from the user. One of `currently_due` or `eventually_due`. Default is `currently_due`.
        [<Config.Form>]Collect: Create'Collect option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The URL the user will be redirected to if the account link is expired, has been previously-visited, or is otherwise invalid. The URL you specify should attempt to generate a new account link with the same parameters used to create the original account link, then redirect the user to the new account link's URL so they can continue with Connect Onboarding. If a new account link cannot be generated or the redirect fails you should display a useful error to the user.
        [<Config.Form>]RefreshUrl: string option
        ///The URL that the user will be redirected to upon leaving or completing the linked flow.
        [<Config.Form>]ReturnUrl: string option
        ///The type of account link the user is requesting. Possible values are `account_onboarding` or `account_update`.
        [<Config.Form>]Type: Create'Type
    }
    with
        static member New(account: string, type': Create'Type, ?collect: Create'Collect, ?expand: string list, ?refreshUrl: string, ?returnUrl: string) =
            {
                Account = account
                Collect = collect
                Expand = expand
                RefreshUrl = refreshUrl
                ReturnUrl = returnUrl
                Type = type'
            }

    ///<p>Creates an AccountLink object that includes a single-use Stripe URL that the platform can redirect their user to in order to take them through the Connect Onboarding flow.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/account_links"
        |> RestApi.postAsync<_, AccountLink> settings (Map.empty) options

module Accounts =

    type ListOptions = {
        [<Config.Query>]Created: int option
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
        static member New(?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of accounts connected to your platform via <a href="/docs/connect">Connect</a>. If you’re not a platform, the list is empty.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/accounts"
        |> RestApi.getAsync<Account list> settings qs

    type Create'BusinessProfileMonthlyEstimatedRevenue = {
        ///A non-negative integer representing how much to charge in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal).
        [<Config.Form>]Amount: int option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
    }
    with
        static member New(?amount: int, ?currency: string) =
            {
                Amount = amount
                Currency = currency
            }

    type Create'BusinessProfileSupportAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'BusinessProfile = {
        ///[The merchant category code for the account](https://stripe.com/docs/connect/setting-mcc). MCCs are used to classify businesses based on the goods or services they provide.
        [<Config.Form>]Mcc: string option
        ///An estimate of the monthly revenue of the business. Only accepted for accounts in Brazil and India.
        [<Config.Form>]MonthlyEstimatedRevenue: Create'BusinessProfileMonthlyEstimatedRevenue option
        ///The customer-facing business name.
        [<Config.Form>]Name: string option
        ///Internal-only description of the product sold by, or service provided by, the business. Used by Stripe for risk and underwriting purposes.
        [<Config.Form>]ProductDescription: string option
        ///A publicly available mailing address for sending support issues to.
        [<Config.Form>]SupportAddress: Create'BusinessProfileSupportAddress option
        ///A publicly available email address for sending support issues to.
        [<Config.Form>]SupportEmail: string option
        ///A publicly available phone number to call with support issues.
        [<Config.Form>]SupportPhone: string option
        ///A publicly available website for handling support issues.
        [<Config.Form>]SupportUrl: Choice<string,string> option
        ///The business's publicly available website.
        [<Config.Form>]Url: string option
    }
    with
        static member New(?mcc: string, ?monthlyEstimatedRevenue: Create'BusinessProfileMonthlyEstimatedRevenue, ?name: string, ?productDescription: string, ?supportAddress: Create'BusinessProfileSupportAddress, ?supportEmail: string, ?supportPhone: string, ?supportUrl: Choice<string,string>, ?url: string) =
            {
                Mcc = mcc
                MonthlyEstimatedRevenue = monthlyEstimatedRevenue
                Name = name
                ProductDescription = productDescription
                SupportAddress = supportAddress
                SupportEmail = supportEmail
                SupportPhone = supportPhone
                SupportUrl = supportUrl
                Url = url
            }

    type Create'CapabilitiesAcssDebitPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesAffirmPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesAfterpayClearpayPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesAuBecsDebitPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesBacsDebitPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesBancontactPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesBankTransferPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesBlikPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesBoletoPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesCardIssuing = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesCardPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesCartesBancairesPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesCashappPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesEpsPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesFpxPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesGiropayPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesGrabpayPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesIdealPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesIndiaInternationalPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesJcbPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesKlarnaPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesKonbiniPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesLegacyPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesLinkPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesOxxoPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesP24Payments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesPaynowPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesPromptpayPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesSepaDebitPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesSofortPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesTaxReportingUs1099K = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesTaxReportingUs1099Misc = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesTransfers = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesTreasury = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesUsBankAccountAchPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesZipPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'Capabilities = {
        ///The acss_debit_payments capability.
        [<Config.Form>]AcssDebitPayments: Create'CapabilitiesAcssDebitPayments option
        ///The affirm_payments capability.
        [<Config.Form>]AffirmPayments: Create'CapabilitiesAffirmPayments option
        ///The afterpay_clearpay_payments capability.
        [<Config.Form>]AfterpayClearpayPayments: Create'CapabilitiesAfterpayClearpayPayments option
        ///The au_becs_debit_payments capability.
        [<Config.Form>]AuBecsDebitPayments: Create'CapabilitiesAuBecsDebitPayments option
        ///The bacs_debit_payments capability.
        [<Config.Form>]BacsDebitPayments: Create'CapabilitiesBacsDebitPayments option
        ///The bancontact_payments capability.
        [<Config.Form>]BancontactPayments: Create'CapabilitiesBancontactPayments option
        ///The bank_transfer_payments capability.
        [<Config.Form>]BankTransferPayments: Create'CapabilitiesBankTransferPayments option
        ///The blik_payments capability.
        [<Config.Form>]BlikPayments: Create'CapabilitiesBlikPayments option
        ///The boleto_payments capability.
        [<Config.Form>]BoletoPayments: Create'CapabilitiesBoletoPayments option
        ///The card_issuing capability.
        [<Config.Form>]CardIssuing: Create'CapabilitiesCardIssuing option
        ///The card_payments capability.
        [<Config.Form>]CardPayments: Create'CapabilitiesCardPayments option
        ///The cartes_bancaires_payments capability.
        [<Config.Form>]CartesBancairesPayments: Create'CapabilitiesCartesBancairesPayments option
        ///The cashapp_payments capability.
        [<Config.Form>]CashappPayments: Create'CapabilitiesCashappPayments option
        ///The eps_payments capability.
        [<Config.Form>]EpsPayments: Create'CapabilitiesEpsPayments option
        ///The fpx_payments capability.
        [<Config.Form>]FpxPayments: Create'CapabilitiesFpxPayments option
        ///The giropay_payments capability.
        [<Config.Form>]GiropayPayments: Create'CapabilitiesGiropayPayments option
        ///The grabpay_payments capability.
        [<Config.Form>]GrabpayPayments: Create'CapabilitiesGrabpayPayments option
        ///The ideal_payments capability.
        [<Config.Form>]IdealPayments: Create'CapabilitiesIdealPayments option
        ///The india_international_payments capability.
        [<Config.Form>]IndiaInternationalPayments: Create'CapabilitiesIndiaInternationalPayments option
        ///The jcb_payments capability.
        [<Config.Form>]JcbPayments: Create'CapabilitiesJcbPayments option
        ///The klarna_payments capability.
        [<Config.Form>]KlarnaPayments: Create'CapabilitiesKlarnaPayments option
        ///The konbini_payments capability.
        [<Config.Form>]KonbiniPayments: Create'CapabilitiesKonbiniPayments option
        ///The legacy_payments capability.
        [<Config.Form>]LegacyPayments: Create'CapabilitiesLegacyPayments option
        ///The link_payments capability.
        [<Config.Form>]LinkPayments: Create'CapabilitiesLinkPayments option
        ///The oxxo_payments capability.
        [<Config.Form>]OxxoPayments: Create'CapabilitiesOxxoPayments option
        ///The p24_payments capability.
        [<Config.Form>]P24Payments: Create'CapabilitiesP24Payments option
        ///The paynow_payments capability.
        [<Config.Form>]PaynowPayments: Create'CapabilitiesPaynowPayments option
        ///The promptpay_payments capability.
        [<Config.Form>]PromptpayPayments: Create'CapabilitiesPromptpayPayments option
        ///The sepa_debit_payments capability.
        [<Config.Form>]SepaDebitPayments: Create'CapabilitiesSepaDebitPayments option
        ///The sofort_payments capability.
        [<Config.Form>]SofortPayments: Create'CapabilitiesSofortPayments option
        ///The tax_reporting_us_1099_k capability.
        [<Config.Form>]TaxReportingUs1099K: Create'CapabilitiesTaxReportingUs1099K option
        ///The tax_reporting_us_1099_misc capability.
        [<Config.Form>]TaxReportingUs1099Misc: Create'CapabilitiesTaxReportingUs1099Misc option
        ///The transfers capability.
        [<Config.Form>]Transfers: Create'CapabilitiesTransfers option
        ///The treasury capability.
        [<Config.Form>]Treasury: Create'CapabilitiesTreasury option
        ///The us_bank_account_ach_payments capability.
        [<Config.Form>]UsBankAccountAchPayments: Create'CapabilitiesUsBankAccountAchPayments option
        ///The zip_payments capability.
        [<Config.Form>]ZipPayments: Create'CapabilitiesZipPayments option
    }
    with
        static member New(?acssDebitPayments: Create'CapabilitiesAcssDebitPayments, ?klarnaPayments: Create'CapabilitiesKlarnaPayments, ?konbiniPayments: Create'CapabilitiesKonbiniPayments, ?legacyPayments: Create'CapabilitiesLegacyPayments, ?linkPayments: Create'CapabilitiesLinkPayments, ?oxxoPayments: Create'CapabilitiesOxxoPayments, ?p24Payments: Create'CapabilitiesP24Payments, ?jcbPayments: Create'CapabilitiesJcbPayments, ?paynowPayments: Create'CapabilitiesPaynowPayments, ?sepaDebitPayments: Create'CapabilitiesSepaDebitPayments, ?sofortPayments: Create'CapabilitiesSofortPayments, ?taxReportingUs1099K: Create'CapabilitiesTaxReportingUs1099K, ?taxReportingUs1099Misc: Create'CapabilitiesTaxReportingUs1099Misc, ?transfers: Create'CapabilitiesTransfers, ?treasury: Create'CapabilitiesTreasury, ?promptpayPayments: Create'CapabilitiesPromptpayPayments, ?indiaInternationalPayments: Create'CapabilitiesIndiaInternationalPayments, ?idealPayments: Create'CapabilitiesIdealPayments, ?grabpayPayments: Create'CapabilitiesGrabpayPayments, ?affirmPayments: Create'CapabilitiesAffirmPayments, ?afterpayClearpayPayments: Create'CapabilitiesAfterpayClearpayPayments, ?auBecsDebitPayments: Create'CapabilitiesAuBecsDebitPayments, ?bacsDebitPayments: Create'CapabilitiesBacsDebitPayments, ?bancontactPayments: Create'CapabilitiesBancontactPayments, ?bankTransferPayments: Create'CapabilitiesBankTransferPayments, ?blikPayments: Create'CapabilitiesBlikPayments, ?boletoPayments: Create'CapabilitiesBoletoPayments, ?cardIssuing: Create'CapabilitiesCardIssuing, ?cardPayments: Create'CapabilitiesCardPayments, ?cartesBancairesPayments: Create'CapabilitiesCartesBancairesPayments, ?cashappPayments: Create'CapabilitiesCashappPayments, ?epsPayments: Create'CapabilitiesEpsPayments, ?fpxPayments: Create'CapabilitiesFpxPayments, ?giropayPayments: Create'CapabilitiesGiropayPayments, ?usBankAccountAchPayments: Create'CapabilitiesUsBankAccountAchPayments, ?zipPayments: Create'CapabilitiesZipPayments) =
            {
                AcssDebitPayments = acssDebitPayments
                AffirmPayments = affirmPayments
                AfterpayClearpayPayments = afterpayClearpayPayments
                AuBecsDebitPayments = auBecsDebitPayments
                BacsDebitPayments = bacsDebitPayments
                BancontactPayments = bancontactPayments
                BankTransferPayments = bankTransferPayments
                BlikPayments = blikPayments
                BoletoPayments = boletoPayments
                CardIssuing = cardIssuing
                CardPayments = cardPayments
                CartesBancairesPayments = cartesBancairesPayments
                CashappPayments = cashappPayments
                EpsPayments = epsPayments
                FpxPayments = fpxPayments
                GiropayPayments = giropayPayments
                GrabpayPayments = grabpayPayments
                IdealPayments = idealPayments
                IndiaInternationalPayments = indiaInternationalPayments
                JcbPayments = jcbPayments
                KlarnaPayments = klarnaPayments
                KonbiniPayments = konbiniPayments
                LegacyPayments = legacyPayments
                LinkPayments = linkPayments
                OxxoPayments = oxxoPayments
                P24Payments = p24Payments
                PaynowPayments = paynowPayments
                PromptpayPayments = promptpayPayments
                SepaDebitPayments = sepaDebitPayments
                SofortPayments = sofortPayments
                TaxReportingUs1099K = taxReportingUs1099K
                TaxReportingUs1099Misc = taxReportingUs1099Misc
                Transfers = transfers
                Treasury = treasury
                UsBankAccountAchPayments = usBankAccountAchPayments
                ZipPayments = zipPayments
            }

    type Create'CompanyAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'CompanyAddressKana = {
        ///City or ward.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Block or building number.
        [<Config.Form>]Line1: string option
        ///Building details.
        [<Config.Form>]Line2: string option
        ///Postal code.
        [<Config.Form>]PostalCode: string option
        ///Prefecture.
        [<Config.Form>]State: string option
        ///Town or cho-me.
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'CompanyAddressKanji = {
        ///City or ward.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Block or building number.
        [<Config.Form>]Line1: string option
        ///Building details.
        [<Config.Form>]Line2: string option
        ///Postal code.
        [<Config.Form>]PostalCode: string option
        ///Prefecture.
        [<Config.Form>]State: string option
        ///Town or cho-me.
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'CompanyOwnershipDeclaration = {
        ///The Unix timestamp marking when the beneficial owner attestation was made.
        [<Config.Form>]Date: DateTime option
        ///The IP address from which the beneficial owner attestation was made.
        [<Config.Form>]Ip: string option
        ///The user agent of the browser from which the beneficial owner attestation was made.
        [<Config.Form>]UserAgent: string option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Create'CompanyVerificationDocument = {
        ///The back of a document returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `additional_verification`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Back: string option
        ///The front of a document returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `additional_verification`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Create'CompanyVerification = {
        ///A document verifying the business.
        [<Config.Form>]Document: Create'CompanyVerificationDocument option
    }
    with
        static member New(?document: Create'CompanyVerificationDocument) =
            {
                Document = document
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
    | SingleMemberLlc
    | SoleEstablishment
    | SoleProprietorship
    | TaxExemptGovernmentInstrumentality
    | UnincorporatedAssociation
    | UnincorporatedNonProfit
    | UnincorporatedPartnership

    type Create'Company = {
        ///The company's primary address.
        [<Config.Form>]Address: Create'CompanyAddress option
        ///The Kana variation of the company's primary address (Japan only).
        [<Config.Form>]AddressKana: Create'CompanyAddressKana option
        ///The Kanji variation of the company's primary address (Japan only).
        [<Config.Form>]AddressKanji: Create'CompanyAddressKanji option
        ///Whether the company's directors have been provided. Set this Boolean to `true` after creating all the company's directors with [the Persons API](https://stripe.com/docs/api/persons) for accounts with a `relationship.director` requirement. This value is not automatically set to `true` after creating directors, so it needs to be updated to indicate all directors have been provided.
        [<Config.Form>]DirectorsProvided: bool option
        ///Whether the company's executives have been provided. Set this Boolean to `true` after creating all the company's executives with [the Persons API](https://stripe.com/docs/api/persons) for accounts with a `relationship.executive` requirement.
        [<Config.Form>]ExecutivesProvided: bool option
        ///The export license ID number of the company, also referred as Import Export Code (India only).
        [<Config.Form>]ExportLicenseId: string option
        ///The purpose code to use for export transactions (India only).
        [<Config.Form>]ExportPurposeCode: string option
        ///The company's legal name.
        [<Config.Form>]Name: string option
        ///The Kana variation of the company's legal name (Japan only).
        [<Config.Form>]NameKana: string option
        ///The Kanji variation of the company's legal name (Japan only).
        [<Config.Form>]NameKanji: string option
        ///Whether the company's owners have been provided. Set this Boolean to `true` after creating all the company's owners with [the Persons API](https://stripe.com/docs/api/persons) for accounts with a `relationship.owner` requirement.
        [<Config.Form>]OwnersProvided: bool option
        ///This hash is used to attest that the beneficial owner information provided to Stripe is both current and correct.
        [<Config.Form>]OwnershipDeclaration: Create'CompanyOwnershipDeclaration option
        ///The company's phone number (used for verification).
        [<Config.Form>]Phone: string option
        ///The identification number given to a company when it is registered or incorporated, if distinct from the identification number used for filing taxes. (Examples are the CIN for companies and LLP IN for partnerships in India, and the Company Registration Number in Hong Kong).
        [<Config.Form>]RegistrationNumber: string option
        ///The category identifying the legal structure of the company or legal entity. See [Business structure](https://stripe.com/docs/connect/identity-verification#business-structure) for more details.
        [<Config.Form>]Structure: Create'CompanyStructure option
        ///The business ID number of the company, as appropriate for the company’s country. (Examples are an Employer ID Number in the U.S., a Business Number in Canada, or a Company Number in the UK.)
        [<Config.Form>]TaxId: string option
        ///The jurisdiction in which the `tax_id` is registered (Germany-based companies only).
        [<Config.Form>]TaxIdRegistrar: string option
        ///The VAT number of the company.
        [<Config.Form>]VatId: string option
        ///Information on the verification state of the company.
        [<Config.Form>]Verification: Create'CompanyVerification option
    }
    with
        static member New(?address: Create'CompanyAddress, ?taxIdRegistrar: string, ?taxId: string, ?structure: Create'CompanyStructure, ?registrationNumber: string, ?phone: string, ?ownershipDeclaration: Create'CompanyOwnershipDeclaration, ?ownersProvided: bool, ?vatId: string, ?nameKanji: string, ?name: string, ?exportPurposeCode: string, ?exportLicenseId: string, ?executivesProvided: bool, ?directorsProvided: bool, ?addressKanji: Create'CompanyAddressKanji, ?addressKana: Create'CompanyAddressKana, ?nameKana: string, ?verification: Create'CompanyVerification) =
            {
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                DirectorsProvided = directorsProvided
                ExecutivesProvided = executivesProvided
                ExportLicenseId = exportLicenseId
                ExportPurposeCode = exportPurposeCode
                Name = name
                NameKana = nameKana
                NameKanji = nameKanji
                OwnersProvided = ownersProvided
                OwnershipDeclaration = ownershipDeclaration
                Phone = phone
                RegistrationNumber = registrationNumber
                Structure = structure
                TaxId = taxId
                TaxIdRegistrar = taxIdRegistrar
                VatId = vatId
                Verification = verification
            }

    type Create'DocumentsBankAccountOwnershipVerification = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Create'DocumentsCompanyLicense = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Create'DocumentsCompanyMemorandumOfAssociation = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Create'DocumentsCompanyMinisterialDecree = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Create'DocumentsCompanyRegistrationVerification = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Create'DocumentsCompanyTaxIdVerification = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Create'DocumentsProofOfRegistration = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Create'Documents = {
        ///One or more documents that support the [Bank account ownership verification](https://support.stripe.com/questions/bank-account-ownership-verification) requirement. Must be a document associated with the account’s primary active bank account that displays the last 4 digits of the account number, either a statement or a voided check.
        [<Config.Form>]BankAccountOwnershipVerification: Create'DocumentsBankAccountOwnershipVerification option
        ///One or more documents that demonstrate proof of a company's license to operate.
        [<Config.Form>]CompanyLicense: Create'DocumentsCompanyLicense option
        ///One or more documents showing the company's Memorandum of Association.
        [<Config.Form>]CompanyMemorandumOfAssociation: Create'DocumentsCompanyMemorandumOfAssociation option
        ///(Certain countries only) One or more documents showing the ministerial decree legalizing the company's establishment.
        [<Config.Form>]CompanyMinisterialDecree: Create'DocumentsCompanyMinisterialDecree option
        ///One or more documents that demonstrate proof of a company's registration with the appropriate local authorities.
        [<Config.Form>]CompanyRegistrationVerification: Create'DocumentsCompanyRegistrationVerification option
        ///One or more documents that demonstrate proof of a company's tax ID.
        [<Config.Form>]CompanyTaxIdVerification: Create'DocumentsCompanyTaxIdVerification option
        ///One or more documents showing the company’s proof of registration with the national business registry.
        [<Config.Form>]ProofOfRegistration: Create'DocumentsProofOfRegistration option
    }
    with
        static member New(?bankAccountOwnershipVerification: Create'DocumentsBankAccountOwnershipVerification, ?companyLicense: Create'DocumentsCompanyLicense, ?companyMemorandumOfAssociation: Create'DocumentsCompanyMemorandumOfAssociation, ?companyMinisterialDecree: Create'DocumentsCompanyMinisterialDecree, ?companyRegistrationVerification: Create'DocumentsCompanyRegistrationVerification, ?companyTaxIdVerification: Create'DocumentsCompanyTaxIdVerification, ?proofOfRegistration: Create'DocumentsProofOfRegistration) =
            {
                BankAccountOwnershipVerification = bankAccountOwnershipVerification
                CompanyLicense = companyLicense
                CompanyMemorandumOfAssociation = companyMemorandumOfAssociation
                CompanyMinisterialDecree = companyMinisterialDecree
                CompanyRegistrationVerification = companyRegistrationVerification
                CompanyTaxIdVerification = companyTaxIdVerification
                ProofOfRegistration = proofOfRegistration
            }

    type Create'IndividualAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'IndividualAddressKana = {
        ///City or ward.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Block or building number.
        [<Config.Form>]Line1: string option
        ///Building details.
        [<Config.Form>]Line2: string option
        ///Postal code.
        [<Config.Form>]PostalCode: string option
        ///Prefecture.
        [<Config.Form>]State: string option
        ///Town or cho-me.
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'IndividualAddressKanji = {
        ///City or ward.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Block or building number.
        [<Config.Form>]Line1: string option
        ///Building details.
        [<Config.Form>]Line2: string option
        ///Postal code.
        [<Config.Form>]PostalCode: string option
        ///Prefecture.
        [<Config.Form>]State: string option
        ///Town or cho-me.
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'IndividualDobDateOfBirthSpecs = {
        ///The day of birth, between 1 and 31.
        [<Config.Form>]Day: int option
        ///The month of birth, between 1 and 12.
        [<Config.Form>]Month: int option
        ///The four-digit year of birth.
        [<Config.Form>]Year: int option
    }
    with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Create'IndividualRegisteredAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'IndividualVerificationAdditionalDocument = {
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Back: string option
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Create'IndividualVerificationDocument = {
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Back: string option
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Create'IndividualVerification = {
        ///A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.
        [<Config.Form>]AdditionalDocument: Create'IndividualVerificationAdditionalDocument option
        ///An identifying document, either a passport or local ID card.
        [<Config.Form>]Document: Create'IndividualVerificationDocument option
    }
    with
        static member New(?additionalDocument: Create'IndividualVerificationAdditionalDocument, ?document: Create'IndividualVerificationDocument) =
            {
                AdditionalDocument = additionalDocument
                Document = document
            }

    type Create'IndividualPoliticalExposure =
    | Existing
    | None'

    type Create'Individual = {
        ///The individual's primary address.
        [<Config.Form>]Address: Create'IndividualAddress option
        ///The Kana variation of the the individual's primary address (Japan only).
        [<Config.Form>]AddressKana: Create'IndividualAddressKana option
        ///The Kanji variation of the the individual's primary address (Japan only).
        [<Config.Form>]AddressKanji: Create'IndividualAddressKanji option
        ///The individual's date of birth.
        [<Config.Form>]Dob: Choice<Create'IndividualDobDateOfBirthSpecs,string> option
        ///The individual's email address.
        [<Config.Form>]Email: string option
        ///The individual's first name.
        [<Config.Form>]FirstName: string option
        ///The Kana variation of the the individual's first name (Japan only).
        [<Config.Form>]FirstNameKana: string option
        ///The Kanji variation of the individual's first name (Japan only).
        [<Config.Form>]FirstNameKanji: string option
        ///A list of alternate names or aliases that the individual is known by.
        [<Config.Form>]FullNameAliases: Choice<string list,string> option
        ///The individual's gender (International regulations require either "male" or "female").
        [<Config.Form>]Gender: string option
        ///The government-issued ID number of the individual, as appropriate for the representative's country. (Examples are a Social Security Number in the U.S., or a Social Insurance Number in Canada). Instead of the number itself, you can also provide a [PII token created with Stripe.js](https://stripe.com/docs/js/tokens_sources/create_token?type=pii).
        [<Config.Form>]IdNumber: string option
        ///The government-issued secondary ID number of the individual, as appropriate for the representative's country, will be used for enhanced verification checks. In Thailand, this would be the laser code found on the back of an ID card. Instead of the number itself, you can also provide a [PII token created with Stripe.js](https://stripe.com/docs/js/tokens_sources/create_token?type=pii).
        [<Config.Form>]IdNumberSecondary: string option
        ///The individual's last name.
        [<Config.Form>]LastName: string option
        ///The Kana variation of the individual's last name (Japan only).
        [<Config.Form>]LastNameKana: string option
        ///The Kanji variation of the individual's last name (Japan only).
        [<Config.Form>]LastNameKanji: string option
        ///The individual's maiden name.
        [<Config.Form>]MaidenName: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The individual's phone number.
        [<Config.Form>]Phone: string option
        ///Indicates if the person or any of their representatives, family members, or other closely related persons, declares that they hold or have held an important public job or function, in any jurisdiction.
        [<Config.Form>]PoliticalExposure: Create'IndividualPoliticalExposure option
        ///The individual's registered address.
        [<Config.Form>]RegisteredAddress: Create'IndividualRegisteredAddress option
        ///The last four digits of the individual's Social Security Number (U.S. only).
        [<Config.Form>]SsnLast4: string option
        ///The individual's verification document information.
        [<Config.Form>]Verification: Create'IndividualVerification option
    }
    with
        static member New(?address: Create'IndividualAddress, ?registeredAddress: Create'IndividualRegisteredAddress, ?politicalExposure: Create'IndividualPoliticalExposure, ?phone: string, ?metadata: Map<string, string>, ?maidenName: string, ?lastNameKanji: string, ?lastNameKana: string, ?lastName: string, ?idNumberSecondary: string, ?idNumber: string, ?gender: string, ?fullNameAliases: Choice<string list,string>, ?firstNameKanji: string, ?firstNameKana: string, ?firstName: string, ?email: string, ?dob: Choice<Create'IndividualDobDateOfBirthSpecs,string>, ?addressKanji: Create'IndividualAddressKanji, ?addressKana: Create'IndividualAddressKana, ?ssnLast4: string, ?verification: Create'IndividualVerification) =
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
                SsnLast4 = ssnLast4
                Verification = verification
            }

    type Create'SettingsBranding = {
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) An icon for the account. Must be square and at least 128px x 128px.
        [<Config.Form>]Icon: string option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) A logo for the account that will be used in Checkout instead of the icon and without the account's name next to it if provided. Must be at least 128px x 128px.
        [<Config.Form>]Logo: string option
        ///A CSS hex color value representing the primary branding color for this account.
        [<Config.Form>]PrimaryColor: string option
        ///A CSS hex color value representing the secondary branding color for this account.
        [<Config.Form>]SecondaryColor: string option
    }
    with
        static member New(?icon: string, ?logo: string, ?primaryColor: string, ?secondaryColor: string) =
            {
                Icon = icon
                Logo = logo
                PrimaryColor = primaryColor
                SecondaryColor = secondaryColor
            }

    type Create'SettingsCardIssuingTosAcceptance = {
        ///The Unix timestamp marking when the account representative accepted the service agreement.
        [<Config.Form>]Date: DateTime option
        ///The IP address from which the account representative accepted the service agreement.
        [<Config.Form>]Ip: string option
        ///The user agent of the browser from which the account representative accepted the service agreement.
        [<Config.Form>]UserAgent: Choice<string,string> option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?userAgent: Choice<string,string>) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Create'SettingsCardIssuing = {
        ///Details on the account's acceptance of the [Stripe Issuing Terms and Disclosures](https://stripe.com/docs/issuing/connect/tos_acceptance).
        [<Config.Form>]TosAcceptance: Create'SettingsCardIssuingTosAcceptance option
    }
    with
        static member New(?tosAcceptance: Create'SettingsCardIssuingTosAcceptance) =
            {
                TosAcceptance = tosAcceptance
            }

    type Create'SettingsCardPaymentsDeclineOn = {
        ///Whether Stripe automatically declines charges with an incorrect ZIP or postal code. This setting only applies when a ZIP or postal code is provided and they fail bank verification.
        [<Config.Form>]AvsFailure: bool option
        ///Whether Stripe automatically declines charges with an incorrect CVC. This setting only applies when a CVC is provided and it fails bank verification.
        [<Config.Form>]CvcFailure: bool option
    }
    with
        static member New(?avsFailure: bool, ?cvcFailure: bool) =
            {
                AvsFailure = avsFailure
                CvcFailure = cvcFailure
            }

    type Create'SettingsCardPayments = {
        ///Automatically declines certain charge types regardless of whether the card issuer accepted or declined the charge.
        [<Config.Form>]DeclineOn: Create'SettingsCardPaymentsDeclineOn option
        ///The default text that appears on credit card statements when a charge is made. This field prefixes any dynamic `statement_descriptor` specified on the charge. `statement_descriptor_prefix` is useful for maximizing descriptor space for the dynamic portion.
        [<Config.Form>]StatementDescriptorPrefix: string option
        ///The Kana variation of the default text that appears on credit card statements when a charge is made (Japan only). This field prefixes any dynamic `statement_descriptor_suffix_kana` specified on the charge. `statement_descriptor_prefix_kana` is useful for maximizing descriptor space for the dynamic portion.
        [<Config.Form>]StatementDescriptorPrefixKana: Choice<string,string> option
        ///The Kanji variation of the default text that appears on credit card statements when a charge is made (Japan only). This field prefixes any dynamic `statement_descriptor_suffix_kanji` specified on the charge. `statement_descriptor_prefix_kanji` is useful for maximizing descriptor space for the dynamic portion.
        [<Config.Form>]StatementDescriptorPrefixKanji: Choice<string,string> option
    }
    with
        static member New(?declineOn: Create'SettingsCardPaymentsDeclineOn, ?statementDescriptorPrefix: string, ?statementDescriptorPrefixKana: Choice<string,string>, ?statementDescriptorPrefixKanji: Choice<string,string>) =
            {
                DeclineOn = declineOn
                StatementDescriptorPrefix = statementDescriptorPrefix
                StatementDescriptorPrefixKana = statementDescriptorPrefixKana
                StatementDescriptorPrefixKanji = statementDescriptorPrefixKanji
            }

    type Create'SettingsPayments = {
        ///The default text that appears on credit card statements when a charge is made. This field prefixes any dynamic `statement_descriptor` specified on the charge.
        [<Config.Form>]StatementDescriptor: string option
        ///The Kana variation of the default text that appears on credit card statements when a charge is made (Japan only).
        [<Config.Form>]StatementDescriptorKana: string option
        ///The Kanji variation of the default text that appears on credit card statements when a charge is made (Japan only).
        [<Config.Form>]StatementDescriptorKanji: string option
    }
    with
        static member New(?statementDescriptor: string, ?statementDescriptorKana: string, ?statementDescriptorKanji: string) =
            {
                StatementDescriptor = statementDescriptor
                StatementDescriptorKana = statementDescriptorKana
                StatementDescriptorKanji = statementDescriptorKanji
            }

    type Create'SettingsPayoutsScheduleDelayDays =
    | Minimum

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

    type Create'SettingsPayoutsSchedule = {
        ///The number of days charge funds are held before being paid out. May also be set to `minimum`, representing the lowest available value for the account country. Default is `minimum`. The `delay_days` parameter remains at the last configured value if `interval` is `manual`. [Learn more about controlling payout delay days](https://stripe.com/docs/connect/manage-payout-schedule).
        [<Config.Form>]DelayDays: Choice<Create'SettingsPayoutsScheduleDelayDays,int> option
        ///How frequently available funds are paid out. One of: `daily`, `manual`, `weekly`, or `monthly`. Default is `daily`.
        [<Config.Form>]Interval: Create'SettingsPayoutsScheduleInterval option
        ///The day of the month when available funds are paid out, specified as a number between 1--31. Payouts nominally scheduled between the 29th and 31st of the month are instead sent on the last day of a shorter month. Required and applicable only if `interval` is `monthly`.
        [<Config.Form>]MonthlyAnchor: int option
        ///The day of the week when available funds are paid out, specified as `monday`, `tuesday`, etc. (required and applicable only if `interval` is `weekly`.)
        [<Config.Form>]WeeklyAnchor: Create'SettingsPayoutsScheduleWeeklyAnchor option
    }
    with
        static member New(?delayDays: Choice<Create'SettingsPayoutsScheduleDelayDays,int>, ?interval: Create'SettingsPayoutsScheduleInterval, ?monthlyAnchor: int, ?weeklyAnchor: Create'SettingsPayoutsScheduleWeeklyAnchor) =
            {
                DelayDays = delayDays
                Interval = interval
                MonthlyAnchor = monthlyAnchor
                WeeklyAnchor = weeklyAnchor
            }

    type Create'SettingsPayouts = {
        ///A Boolean indicating whether Stripe should try to reclaim negative balances from an attached bank account. For details, see [Understanding Connect Account Balances](https://stripe.com/docs/connect/account-balances).
        [<Config.Form>]DebitNegativeBalances: bool option
        ///Details on when funds from charges are available, and when they are paid out to an external account. For details, see our [Setting Bank and Debit Card Payouts](https://stripe.com/docs/connect/bank-transfers#payout-information) documentation.
        [<Config.Form>]Schedule: Create'SettingsPayoutsSchedule option
        ///The text that appears on the bank account statement for payouts. If not set, this defaults to the platform's bank descriptor as set in the Dashboard.
        [<Config.Form>]StatementDescriptor: string option
    }
    with
        static member New(?debitNegativeBalances: bool, ?schedule: Create'SettingsPayoutsSchedule, ?statementDescriptor: string) =
            {
                DebitNegativeBalances = debitNegativeBalances
                Schedule = schedule
                StatementDescriptor = statementDescriptor
            }

    type Create'SettingsTreasuryTosAcceptance = {
        ///The Unix timestamp marking when the account representative accepted the service agreement.
        [<Config.Form>]Date: DateTime option
        ///The IP address from which the account representative accepted the service agreement.
        [<Config.Form>]Ip: string option
        ///The user agent of the browser from which the account representative accepted the service agreement.
        [<Config.Form>]UserAgent: Choice<string,string> option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?userAgent: Choice<string,string>) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Create'SettingsTreasury = {
        ///Details on the account's acceptance of the Stripe Treasury Services Agreement.
        [<Config.Form>]TosAcceptance: Create'SettingsTreasuryTosAcceptance option
    }
    with
        static member New(?tosAcceptance: Create'SettingsTreasuryTosAcceptance) =
            {
                TosAcceptance = tosAcceptance
            }

    type Create'Settings = {
        ///Settings used to apply the account's branding to email receipts, invoices, Checkout, and other products.
        [<Config.Form>]Branding: Create'SettingsBranding option
        ///Settings specific to the account's use of the Card Issuing product.
        [<Config.Form>]CardIssuing: Create'SettingsCardIssuing option
        ///Settings specific to card charging on the account.
        [<Config.Form>]CardPayments: Create'SettingsCardPayments option
        ///Settings that apply across payment methods for charging on the account.
        [<Config.Form>]Payments: Create'SettingsPayments option
        ///Settings specific to the account's payouts.
        [<Config.Form>]Payouts: Create'SettingsPayouts option
        ///Settings specific to the account's Treasury FinancialAccounts.
        [<Config.Form>]Treasury: Create'SettingsTreasury option
    }
    with
        static member New(?branding: Create'SettingsBranding, ?cardIssuing: Create'SettingsCardIssuing, ?cardPayments: Create'SettingsCardPayments, ?payments: Create'SettingsPayments, ?payouts: Create'SettingsPayouts, ?treasury: Create'SettingsTreasury) =
            {
                Branding = branding
                CardIssuing = cardIssuing
                CardPayments = cardPayments
                Payments = payments
                Payouts = payouts
                Treasury = treasury
            }

    type Create'TosAcceptance = {
        ///The Unix timestamp marking when the account representative accepted their service agreement.
        [<Config.Form>]Date: DateTime option
        ///The IP address from which the account representative accepted their service agreement.
        [<Config.Form>]Ip: string option
        ///The user's service agreement type.
        [<Config.Form>]ServiceAgreement: string option
        ///The user agent of the browser from which the account representative accepted their service agreement.
        [<Config.Form>]UserAgent: string option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?serviceAgreement: string, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                ServiceAgreement = serviceAgreement
                UserAgent = userAgent
            }

    type Create'BusinessType =
    | Company
    | GovernmentEntity
    | Individual
    | NonProfit

    type Create'Type =
    | Custom
    | Express
    | Standard

    type CreateOptions = {
        ///An [account token](https://stripe.com/docs/api#create_account_token), used to securely provide details to the account.
        [<Config.Form>]AccountToken: string option
        ///Business information about the account.
        [<Config.Form>]BusinessProfile: Create'BusinessProfile option
        ///The business type.
        [<Config.Form>]BusinessType: Create'BusinessType option
        ///Each key of the dictionary represents a capability, and each capability maps to its settings (e.g. whether it has been requested or not). Each capability will be inactive until you have provided its specific requirements and Stripe has verified them. An account may have some of its requested capabilities be active and some be inactive.
        [<Config.Form>]Capabilities: Create'Capabilities option
        ///Information about the company or business. This field is available for any `business_type`.
        [<Config.Form>]Company: Create'Company option
        ///The country in which the account holder resides, or in which the business is legally established. This should be an ISO 3166-1 alpha-2 country code. For example, if you are in the United States and the business for which you're creating an account is legally represented in Canada, you would use `CA` as the country for the account being created. Available countries include [Stripe's global markets](https://stripe.com/global) as well as countries where [cross-border payouts](https://stripe.com/docs/connect/cross-border-payouts) are supported.
        [<Config.Form>]Country: string option
        ///Three-letter ISO currency code representing the default currency for the account. This must be a currency that [Stripe supports in the account's country](https://stripe.com/docs/payouts).
        [<Config.Form>]DefaultCurrency: string option
        ///Documents that may be submitted to satisfy various informational requests.
        [<Config.Form>]Documents: Create'Documents option
        ///The email address of the account holder. This is only to make the account easier to identify to you. Stripe only emails Custom accounts with your consent.
        [<Config.Form>]Email: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///A card or bank account to attach to the account for receiving [payouts](https://stripe.com/docs/connect/bank-debit-card-payouts) (you won’t be able to use it for top-ups). You can provide either a token, like the ones returned by [Stripe.js](https://stripe.com/docs/js), or a dictionary, as documented in the `external_account` parameter for [bank account](https://stripe.com/docs/api#account_create_bank_account) creation. <br><br>By default, providing an external account sets it as the new default external account for its currency, and deletes the old default if one exists. To add additional external accounts without replacing the existing default for the currency, use the [bank account](https://stripe.com/docs/api#account_create_bank_account) or [card creation](https://stripe.com/docs/api#account_create_card) APIs.
        [<Config.Form>]ExternalAccount: string option
        ///Information about the person represented by the account. This field is null unless `business_type` is set to `individual`.
        [<Config.Form>]Individual: Create'Individual option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Options for customizing how the account functions within Stripe.
        [<Config.Form>]Settings: Create'Settings option
        ///Details on the account's acceptance of the [Stripe Services Agreement](https://stripe.com/docs/connect/updating-accounts#tos-acceptance).
        [<Config.Form>]TosAcceptance: Create'TosAcceptance option
        ///The type of Stripe account to create. May be one of `custom`, `express` or `standard`.
        [<Config.Form>]Type: Create'Type option
    }
    with
        static member New(?accountToken: string, ?businessProfile: Create'BusinessProfile, ?businessType: Create'BusinessType, ?capabilities: Create'Capabilities, ?company: Create'Company, ?country: string, ?defaultCurrency: string, ?documents: Create'Documents, ?email: string, ?expand: string list, ?externalAccount: string, ?individual: Create'Individual, ?metadata: Map<string, string>, ?settings: Create'Settings, ?tosAcceptance: Create'TosAcceptance, ?type': Create'Type) =
            {
                AccountToken = accountToken
                BusinessProfile = businessProfile
                BusinessType = businessType
                Capabilities = capabilities
                Company = company
                Country = country
                DefaultCurrency = defaultCurrency
                Documents = documents
                Email = email
                Expand = expand
                ExternalAccount = externalAccount
                Individual = individual
                Metadata = metadata
                Settings = settings
                TosAcceptance = tosAcceptance
                Type = type'
            }

    ///<p>With <a href="/docs/connect">Connect</a>, you can create Stripe accounts for your users.
    ///To do this, you’ll first need to <a href="https://dashboard.stripe.com/account/applications/settings">register your platform</a>.
    ///If you’ve already collected information for your connected accounts, you <a href="/docs/connect/best-practices#onboarding">can prefill that information</a> when
    ///creating the account. Connect Onboarding won’t ask for the prefilled information during account onboarding.
    ///You can prefill any information on the account.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/accounts"
        |> RestApi.postAsync<_, Account> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Account: string
    }
    with
        static member New(account: string) =
            {
                Account = account
            }

    ///<p>With <a href="/docs/connect">Connect</a>, you can delete accounts you manage.
    ///Accounts created using test-mode keys can be deleted at any time. Standard accounts created using live-mode keys cannot be deleted. Custom or Express accounts created using live-mode keys can only be deleted once all balances are zero.
    ///If you want to delete your own account, use the <a href="https://dashboard.stripe.com/settings/account">account information tab in your account settings</a> instead.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/accounts/{options.Account}"
        |> RestApi.deleteAsync<DeletedAccount> settings (Map.empty)

    type RetrieveOptions = {
        [<Config.Path>]Account: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(account: string, ?expand: string list) =
            {
                Account = account
                Expand = expand
            }

    ///<p>Retrieves the details of an account.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/accounts/{options.Account}"
        |> RestApi.getAsync<Account> settings qs

    type Update'BusinessProfileMonthlyEstimatedRevenue = {
        ///A non-negative integer representing how much to charge in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal).
        [<Config.Form>]Amount: int option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
    }
    with
        static member New(?amount: int, ?currency: string) =
            {
                Amount = amount
                Currency = currency
            }

    type Update'BusinessProfileSupportAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'BusinessProfile = {
        ///[The merchant category code for the account](https://stripe.com/docs/connect/setting-mcc). MCCs are used to classify businesses based on the goods or services they provide.
        [<Config.Form>]Mcc: string option
        ///An estimate of the monthly revenue of the business. Only accepted for accounts in Brazil and India.
        [<Config.Form>]MonthlyEstimatedRevenue: Update'BusinessProfileMonthlyEstimatedRevenue option
        ///The customer-facing business name.
        [<Config.Form>]Name: string option
        ///Internal-only description of the product sold by, or service provided by, the business. Used by Stripe for risk and underwriting purposes.
        [<Config.Form>]ProductDescription: string option
        ///A publicly available mailing address for sending support issues to.
        [<Config.Form>]SupportAddress: Update'BusinessProfileSupportAddress option
        ///A publicly available email address for sending support issues to.
        [<Config.Form>]SupportEmail: string option
        ///A publicly available phone number to call with support issues.
        [<Config.Form>]SupportPhone: string option
        ///A publicly available website for handling support issues.
        [<Config.Form>]SupportUrl: Choice<string,string> option
        ///The business's publicly available website.
        [<Config.Form>]Url: string option
    }
    with
        static member New(?mcc: string, ?monthlyEstimatedRevenue: Update'BusinessProfileMonthlyEstimatedRevenue, ?name: string, ?productDescription: string, ?supportAddress: Update'BusinessProfileSupportAddress, ?supportEmail: string, ?supportPhone: string, ?supportUrl: Choice<string,string>, ?url: string) =
            {
                Mcc = mcc
                MonthlyEstimatedRevenue = monthlyEstimatedRevenue
                Name = name
                ProductDescription = productDescription
                SupportAddress = supportAddress
                SupportEmail = supportEmail
                SupportPhone = supportPhone
                SupportUrl = supportUrl
                Url = url
            }

    type Update'CapabilitiesAcssDebitPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesAffirmPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesAfterpayClearpayPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesAuBecsDebitPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesBacsDebitPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesBancontactPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesBankTransferPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesBlikPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesBoletoPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesCardIssuing = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesCardPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesCartesBancairesPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesCashappPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesEpsPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesFpxPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesGiropayPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesGrabpayPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesIdealPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesIndiaInternationalPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesJcbPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesKlarnaPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesKonbiniPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesLegacyPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesLinkPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesOxxoPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesP24Payments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesPaynowPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesPromptpayPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesSepaDebitPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesSofortPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesTaxReportingUs1099K = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesTaxReportingUs1099Misc = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesTransfers = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesTreasury = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesUsBankAccountAchPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesZipPayments = {
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'Capabilities = {
        ///The acss_debit_payments capability.
        [<Config.Form>]AcssDebitPayments: Update'CapabilitiesAcssDebitPayments option
        ///The affirm_payments capability.
        [<Config.Form>]AffirmPayments: Update'CapabilitiesAffirmPayments option
        ///The afterpay_clearpay_payments capability.
        [<Config.Form>]AfterpayClearpayPayments: Update'CapabilitiesAfterpayClearpayPayments option
        ///The au_becs_debit_payments capability.
        [<Config.Form>]AuBecsDebitPayments: Update'CapabilitiesAuBecsDebitPayments option
        ///The bacs_debit_payments capability.
        [<Config.Form>]BacsDebitPayments: Update'CapabilitiesBacsDebitPayments option
        ///The bancontact_payments capability.
        [<Config.Form>]BancontactPayments: Update'CapabilitiesBancontactPayments option
        ///The bank_transfer_payments capability.
        [<Config.Form>]BankTransferPayments: Update'CapabilitiesBankTransferPayments option
        ///The blik_payments capability.
        [<Config.Form>]BlikPayments: Update'CapabilitiesBlikPayments option
        ///The boleto_payments capability.
        [<Config.Form>]BoletoPayments: Update'CapabilitiesBoletoPayments option
        ///The card_issuing capability.
        [<Config.Form>]CardIssuing: Update'CapabilitiesCardIssuing option
        ///The card_payments capability.
        [<Config.Form>]CardPayments: Update'CapabilitiesCardPayments option
        ///The cartes_bancaires_payments capability.
        [<Config.Form>]CartesBancairesPayments: Update'CapabilitiesCartesBancairesPayments option
        ///The cashapp_payments capability.
        [<Config.Form>]CashappPayments: Update'CapabilitiesCashappPayments option
        ///The eps_payments capability.
        [<Config.Form>]EpsPayments: Update'CapabilitiesEpsPayments option
        ///The fpx_payments capability.
        [<Config.Form>]FpxPayments: Update'CapabilitiesFpxPayments option
        ///The giropay_payments capability.
        [<Config.Form>]GiropayPayments: Update'CapabilitiesGiropayPayments option
        ///The grabpay_payments capability.
        [<Config.Form>]GrabpayPayments: Update'CapabilitiesGrabpayPayments option
        ///The ideal_payments capability.
        [<Config.Form>]IdealPayments: Update'CapabilitiesIdealPayments option
        ///The india_international_payments capability.
        [<Config.Form>]IndiaInternationalPayments: Update'CapabilitiesIndiaInternationalPayments option
        ///The jcb_payments capability.
        [<Config.Form>]JcbPayments: Update'CapabilitiesJcbPayments option
        ///The klarna_payments capability.
        [<Config.Form>]KlarnaPayments: Update'CapabilitiesKlarnaPayments option
        ///The konbini_payments capability.
        [<Config.Form>]KonbiniPayments: Update'CapabilitiesKonbiniPayments option
        ///The legacy_payments capability.
        [<Config.Form>]LegacyPayments: Update'CapabilitiesLegacyPayments option
        ///The link_payments capability.
        [<Config.Form>]LinkPayments: Update'CapabilitiesLinkPayments option
        ///The oxxo_payments capability.
        [<Config.Form>]OxxoPayments: Update'CapabilitiesOxxoPayments option
        ///The p24_payments capability.
        [<Config.Form>]P24Payments: Update'CapabilitiesP24Payments option
        ///The paynow_payments capability.
        [<Config.Form>]PaynowPayments: Update'CapabilitiesPaynowPayments option
        ///The promptpay_payments capability.
        [<Config.Form>]PromptpayPayments: Update'CapabilitiesPromptpayPayments option
        ///The sepa_debit_payments capability.
        [<Config.Form>]SepaDebitPayments: Update'CapabilitiesSepaDebitPayments option
        ///The sofort_payments capability.
        [<Config.Form>]SofortPayments: Update'CapabilitiesSofortPayments option
        ///The tax_reporting_us_1099_k capability.
        [<Config.Form>]TaxReportingUs1099K: Update'CapabilitiesTaxReportingUs1099K option
        ///The tax_reporting_us_1099_misc capability.
        [<Config.Form>]TaxReportingUs1099Misc: Update'CapabilitiesTaxReportingUs1099Misc option
        ///The transfers capability.
        [<Config.Form>]Transfers: Update'CapabilitiesTransfers option
        ///The treasury capability.
        [<Config.Form>]Treasury: Update'CapabilitiesTreasury option
        ///The us_bank_account_ach_payments capability.
        [<Config.Form>]UsBankAccountAchPayments: Update'CapabilitiesUsBankAccountAchPayments option
        ///The zip_payments capability.
        [<Config.Form>]ZipPayments: Update'CapabilitiesZipPayments option
    }
    with
        static member New(?acssDebitPayments: Update'CapabilitiesAcssDebitPayments, ?klarnaPayments: Update'CapabilitiesKlarnaPayments, ?konbiniPayments: Update'CapabilitiesKonbiniPayments, ?legacyPayments: Update'CapabilitiesLegacyPayments, ?linkPayments: Update'CapabilitiesLinkPayments, ?oxxoPayments: Update'CapabilitiesOxxoPayments, ?p24Payments: Update'CapabilitiesP24Payments, ?jcbPayments: Update'CapabilitiesJcbPayments, ?paynowPayments: Update'CapabilitiesPaynowPayments, ?sepaDebitPayments: Update'CapabilitiesSepaDebitPayments, ?sofortPayments: Update'CapabilitiesSofortPayments, ?taxReportingUs1099K: Update'CapabilitiesTaxReportingUs1099K, ?taxReportingUs1099Misc: Update'CapabilitiesTaxReportingUs1099Misc, ?transfers: Update'CapabilitiesTransfers, ?treasury: Update'CapabilitiesTreasury, ?promptpayPayments: Update'CapabilitiesPromptpayPayments, ?indiaInternationalPayments: Update'CapabilitiesIndiaInternationalPayments, ?idealPayments: Update'CapabilitiesIdealPayments, ?grabpayPayments: Update'CapabilitiesGrabpayPayments, ?affirmPayments: Update'CapabilitiesAffirmPayments, ?afterpayClearpayPayments: Update'CapabilitiesAfterpayClearpayPayments, ?auBecsDebitPayments: Update'CapabilitiesAuBecsDebitPayments, ?bacsDebitPayments: Update'CapabilitiesBacsDebitPayments, ?bancontactPayments: Update'CapabilitiesBancontactPayments, ?bankTransferPayments: Update'CapabilitiesBankTransferPayments, ?blikPayments: Update'CapabilitiesBlikPayments, ?boletoPayments: Update'CapabilitiesBoletoPayments, ?cardIssuing: Update'CapabilitiesCardIssuing, ?cardPayments: Update'CapabilitiesCardPayments, ?cartesBancairesPayments: Update'CapabilitiesCartesBancairesPayments, ?cashappPayments: Update'CapabilitiesCashappPayments, ?epsPayments: Update'CapabilitiesEpsPayments, ?fpxPayments: Update'CapabilitiesFpxPayments, ?giropayPayments: Update'CapabilitiesGiropayPayments, ?usBankAccountAchPayments: Update'CapabilitiesUsBankAccountAchPayments, ?zipPayments: Update'CapabilitiesZipPayments) =
            {
                AcssDebitPayments = acssDebitPayments
                AffirmPayments = affirmPayments
                AfterpayClearpayPayments = afterpayClearpayPayments
                AuBecsDebitPayments = auBecsDebitPayments
                BacsDebitPayments = bacsDebitPayments
                BancontactPayments = bancontactPayments
                BankTransferPayments = bankTransferPayments
                BlikPayments = blikPayments
                BoletoPayments = boletoPayments
                CardIssuing = cardIssuing
                CardPayments = cardPayments
                CartesBancairesPayments = cartesBancairesPayments
                CashappPayments = cashappPayments
                EpsPayments = epsPayments
                FpxPayments = fpxPayments
                GiropayPayments = giropayPayments
                GrabpayPayments = grabpayPayments
                IdealPayments = idealPayments
                IndiaInternationalPayments = indiaInternationalPayments
                JcbPayments = jcbPayments
                KlarnaPayments = klarnaPayments
                KonbiniPayments = konbiniPayments
                LegacyPayments = legacyPayments
                LinkPayments = linkPayments
                OxxoPayments = oxxoPayments
                P24Payments = p24Payments
                PaynowPayments = paynowPayments
                PromptpayPayments = promptpayPayments
                SepaDebitPayments = sepaDebitPayments
                SofortPayments = sofortPayments
                TaxReportingUs1099K = taxReportingUs1099K
                TaxReportingUs1099Misc = taxReportingUs1099Misc
                Transfers = transfers
                Treasury = treasury
                UsBankAccountAchPayments = usBankAccountAchPayments
                ZipPayments = zipPayments
            }

    type Update'CompanyAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'CompanyAddressKana = {
        ///City or ward.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Block or building number.
        [<Config.Form>]Line1: string option
        ///Building details.
        [<Config.Form>]Line2: string option
        ///Postal code.
        [<Config.Form>]PostalCode: string option
        ///Prefecture.
        [<Config.Form>]State: string option
        ///Town or cho-me.
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Update'CompanyAddressKanji = {
        ///City or ward.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Block or building number.
        [<Config.Form>]Line1: string option
        ///Building details.
        [<Config.Form>]Line2: string option
        ///Postal code.
        [<Config.Form>]PostalCode: string option
        ///Prefecture.
        [<Config.Form>]State: string option
        ///Town or cho-me.
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Update'CompanyOwnershipDeclaration = {
        ///The Unix timestamp marking when the beneficial owner attestation was made.
        [<Config.Form>]Date: DateTime option
        ///The IP address from which the beneficial owner attestation was made.
        [<Config.Form>]Ip: string option
        ///The user agent of the browser from which the beneficial owner attestation was made.
        [<Config.Form>]UserAgent: string option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Update'CompanyVerificationDocument = {
        ///The back of a document returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `additional_verification`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Back: string option
        ///The front of a document returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `additional_verification`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Update'CompanyVerification = {
        ///A document verifying the business.
        [<Config.Form>]Document: Update'CompanyVerificationDocument option
    }
    with
        static member New(?document: Update'CompanyVerificationDocument) =
            {
                Document = document
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
    | SingleMemberLlc
    | SoleEstablishment
    | SoleProprietorship
    | TaxExemptGovernmentInstrumentality
    | UnincorporatedAssociation
    | UnincorporatedNonProfit
    | UnincorporatedPartnership

    type Update'Company = {
        ///The company's primary address.
        [<Config.Form>]Address: Update'CompanyAddress option
        ///The Kana variation of the company's primary address (Japan only).
        [<Config.Form>]AddressKana: Update'CompanyAddressKana option
        ///The Kanji variation of the company's primary address (Japan only).
        [<Config.Form>]AddressKanji: Update'CompanyAddressKanji option
        ///Whether the company's directors have been provided. Set this Boolean to `true` after creating all the company's directors with [the Persons API](https://stripe.com/docs/api/persons) for accounts with a `relationship.director` requirement. This value is not automatically set to `true` after creating directors, so it needs to be updated to indicate all directors have been provided.
        [<Config.Form>]DirectorsProvided: bool option
        ///Whether the company's executives have been provided. Set this Boolean to `true` after creating all the company's executives with [the Persons API](https://stripe.com/docs/api/persons) for accounts with a `relationship.executive` requirement.
        [<Config.Form>]ExecutivesProvided: bool option
        ///The export license ID number of the company, also referred as Import Export Code (India only).
        [<Config.Form>]ExportLicenseId: string option
        ///The purpose code to use for export transactions (India only).
        [<Config.Form>]ExportPurposeCode: string option
        ///The company's legal name.
        [<Config.Form>]Name: string option
        ///The Kana variation of the company's legal name (Japan only).
        [<Config.Form>]NameKana: string option
        ///The Kanji variation of the company's legal name (Japan only).
        [<Config.Form>]NameKanji: string option
        ///Whether the company's owners have been provided. Set this Boolean to `true` after creating all the company's owners with [the Persons API](https://stripe.com/docs/api/persons) for accounts with a `relationship.owner` requirement.
        [<Config.Form>]OwnersProvided: bool option
        ///This hash is used to attest that the beneficial owner information provided to Stripe is both current and correct.
        [<Config.Form>]OwnershipDeclaration: Update'CompanyOwnershipDeclaration option
        ///The company's phone number (used for verification).
        [<Config.Form>]Phone: string option
        ///The identification number given to a company when it is registered or incorporated, if distinct from the identification number used for filing taxes. (Examples are the CIN for companies and LLP IN for partnerships in India, and the Company Registration Number in Hong Kong).
        [<Config.Form>]RegistrationNumber: string option
        ///The category identifying the legal structure of the company or legal entity. See [Business structure](https://stripe.com/docs/connect/identity-verification#business-structure) for more details.
        [<Config.Form>]Structure: Update'CompanyStructure option
        ///The business ID number of the company, as appropriate for the company’s country. (Examples are an Employer ID Number in the U.S., a Business Number in Canada, or a Company Number in the UK.)
        [<Config.Form>]TaxId: string option
        ///The jurisdiction in which the `tax_id` is registered (Germany-based companies only).
        [<Config.Form>]TaxIdRegistrar: string option
        ///The VAT number of the company.
        [<Config.Form>]VatId: string option
        ///Information on the verification state of the company.
        [<Config.Form>]Verification: Update'CompanyVerification option
    }
    with
        static member New(?address: Update'CompanyAddress, ?taxIdRegistrar: string, ?taxId: string, ?structure: Update'CompanyStructure, ?registrationNumber: string, ?phone: string, ?ownershipDeclaration: Update'CompanyOwnershipDeclaration, ?ownersProvided: bool, ?vatId: string, ?nameKanji: string, ?name: string, ?exportPurposeCode: string, ?exportLicenseId: string, ?executivesProvided: bool, ?directorsProvided: bool, ?addressKanji: Update'CompanyAddressKanji, ?addressKana: Update'CompanyAddressKana, ?nameKana: string, ?verification: Update'CompanyVerification) =
            {
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                DirectorsProvided = directorsProvided
                ExecutivesProvided = executivesProvided
                ExportLicenseId = exportLicenseId
                ExportPurposeCode = exportPurposeCode
                Name = name
                NameKana = nameKana
                NameKanji = nameKanji
                OwnersProvided = ownersProvided
                OwnershipDeclaration = ownershipDeclaration
                Phone = phone
                RegistrationNumber = registrationNumber
                Structure = structure
                TaxId = taxId
                TaxIdRegistrar = taxIdRegistrar
                VatId = vatId
                Verification = verification
            }

    type Update'DocumentsBankAccountOwnershipVerification = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Update'DocumentsCompanyLicense = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Update'DocumentsCompanyMemorandumOfAssociation = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Update'DocumentsCompanyMinisterialDecree = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Update'DocumentsCompanyRegistrationVerification = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Update'DocumentsCompanyTaxIdVerification = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Update'DocumentsProofOfRegistration = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Update'Documents = {
        ///One or more documents that support the [Bank account ownership verification](https://support.stripe.com/questions/bank-account-ownership-verification) requirement. Must be a document associated with the account’s primary active bank account that displays the last 4 digits of the account number, either a statement or a voided check.
        [<Config.Form>]BankAccountOwnershipVerification: Update'DocumentsBankAccountOwnershipVerification option
        ///One or more documents that demonstrate proof of a company's license to operate.
        [<Config.Form>]CompanyLicense: Update'DocumentsCompanyLicense option
        ///One or more documents showing the company's Memorandum of Association.
        [<Config.Form>]CompanyMemorandumOfAssociation: Update'DocumentsCompanyMemorandumOfAssociation option
        ///(Certain countries only) One or more documents showing the ministerial decree legalizing the company's establishment.
        [<Config.Form>]CompanyMinisterialDecree: Update'DocumentsCompanyMinisterialDecree option
        ///One or more documents that demonstrate proof of a company's registration with the appropriate local authorities.
        [<Config.Form>]CompanyRegistrationVerification: Update'DocumentsCompanyRegistrationVerification option
        ///One or more documents that demonstrate proof of a company's tax ID.
        [<Config.Form>]CompanyTaxIdVerification: Update'DocumentsCompanyTaxIdVerification option
        ///One or more documents showing the company’s proof of registration with the national business registry.
        [<Config.Form>]ProofOfRegistration: Update'DocumentsProofOfRegistration option
    }
    with
        static member New(?bankAccountOwnershipVerification: Update'DocumentsBankAccountOwnershipVerification, ?companyLicense: Update'DocumentsCompanyLicense, ?companyMemorandumOfAssociation: Update'DocumentsCompanyMemorandumOfAssociation, ?companyMinisterialDecree: Update'DocumentsCompanyMinisterialDecree, ?companyRegistrationVerification: Update'DocumentsCompanyRegistrationVerification, ?companyTaxIdVerification: Update'DocumentsCompanyTaxIdVerification, ?proofOfRegistration: Update'DocumentsProofOfRegistration) =
            {
                BankAccountOwnershipVerification = bankAccountOwnershipVerification
                CompanyLicense = companyLicense
                CompanyMemorandumOfAssociation = companyMemorandumOfAssociation
                CompanyMinisterialDecree = companyMinisterialDecree
                CompanyRegistrationVerification = companyRegistrationVerification
                CompanyTaxIdVerification = companyTaxIdVerification
                ProofOfRegistration = proofOfRegistration
            }

    type Update'IndividualAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'IndividualAddressKana = {
        ///City or ward.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Block or building number.
        [<Config.Form>]Line1: string option
        ///Building details.
        [<Config.Form>]Line2: string option
        ///Postal code.
        [<Config.Form>]PostalCode: string option
        ///Prefecture.
        [<Config.Form>]State: string option
        ///Town or cho-me.
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Update'IndividualAddressKanji = {
        ///City or ward.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Block or building number.
        [<Config.Form>]Line1: string option
        ///Building details.
        [<Config.Form>]Line2: string option
        ///Postal code.
        [<Config.Form>]PostalCode: string option
        ///Prefecture.
        [<Config.Form>]State: string option
        ///Town or cho-me.
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Update'IndividualDobDateOfBirthSpecs = {
        ///The day of birth, between 1 and 31.
        [<Config.Form>]Day: int option
        ///The month of birth, between 1 and 12.
        [<Config.Form>]Month: int option
        ///The four-digit year of birth.
        [<Config.Form>]Year: int option
    }
    with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Update'IndividualRegisteredAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'IndividualVerificationAdditionalDocument = {
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Back: string option
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Update'IndividualVerificationDocument = {
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Back: string option
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Update'IndividualVerification = {
        ///A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.
        [<Config.Form>]AdditionalDocument: Update'IndividualVerificationAdditionalDocument option
        ///An identifying document, either a passport or local ID card.
        [<Config.Form>]Document: Update'IndividualVerificationDocument option
    }
    with
        static member New(?additionalDocument: Update'IndividualVerificationAdditionalDocument, ?document: Update'IndividualVerificationDocument) =
            {
                AdditionalDocument = additionalDocument
                Document = document
            }

    type Update'IndividualPoliticalExposure =
    | Existing
    | None'

    type Update'Individual = {
        ///The individual's primary address.
        [<Config.Form>]Address: Update'IndividualAddress option
        ///The Kana variation of the the individual's primary address (Japan only).
        [<Config.Form>]AddressKana: Update'IndividualAddressKana option
        ///The Kanji variation of the the individual's primary address (Japan only).
        [<Config.Form>]AddressKanji: Update'IndividualAddressKanji option
        ///The individual's date of birth.
        [<Config.Form>]Dob: Choice<Update'IndividualDobDateOfBirthSpecs,string> option
        ///The individual's email address.
        [<Config.Form>]Email: string option
        ///The individual's first name.
        [<Config.Form>]FirstName: string option
        ///The Kana variation of the the individual's first name (Japan only).
        [<Config.Form>]FirstNameKana: string option
        ///The Kanji variation of the individual's first name (Japan only).
        [<Config.Form>]FirstNameKanji: string option
        ///A list of alternate names or aliases that the individual is known by.
        [<Config.Form>]FullNameAliases: Choice<string list,string> option
        ///The individual's gender (International regulations require either "male" or "female").
        [<Config.Form>]Gender: string option
        ///The government-issued ID number of the individual, as appropriate for the representative's country. (Examples are a Social Security Number in the U.S., or a Social Insurance Number in Canada). Instead of the number itself, you can also provide a [PII token created with Stripe.js](https://stripe.com/docs/js/tokens_sources/create_token?type=pii).
        [<Config.Form>]IdNumber: string option
        ///The government-issued secondary ID number of the individual, as appropriate for the representative's country, will be used for enhanced verification checks. In Thailand, this would be the laser code found on the back of an ID card. Instead of the number itself, you can also provide a [PII token created with Stripe.js](https://stripe.com/docs/js/tokens_sources/create_token?type=pii).
        [<Config.Form>]IdNumberSecondary: string option
        ///The individual's last name.
        [<Config.Form>]LastName: string option
        ///The Kana variation of the individual's last name (Japan only).
        [<Config.Form>]LastNameKana: string option
        ///The Kanji variation of the individual's last name (Japan only).
        [<Config.Form>]LastNameKanji: string option
        ///The individual's maiden name.
        [<Config.Form>]MaidenName: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The individual's phone number.
        [<Config.Form>]Phone: string option
        ///Indicates if the person or any of their representatives, family members, or other closely related persons, declares that they hold or have held an important public job or function, in any jurisdiction.
        [<Config.Form>]PoliticalExposure: Update'IndividualPoliticalExposure option
        ///The individual's registered address.
        [<Config.Form>]RegisteredAddress: Update'IndividualRegisteredAddress option
        ///The last four digits of the individual's Social Security Number (U.S. only).
        [<Config.Form>]SsnLast4: string option
        ///The individual's verification document information.
        [<Config.Form>]Verification: Update'IndividualVerification option
    }
    with
        static member New(?address: Update'IndividualAddress, ?registeredAddress: Update'IndividualRegisteredAddress, ?politicalExposure: Update'IndividualPoliticalExposure, ?phone: string, ?metadata: Map<string, string>, ?maidenName: string, ?lastNameKanji: string, ?lastNameKana: string, ?lastName: string, ?idNumberSecondary: string, ?idNumber: string, ?gender: string, ?fullNameAliases: Choice<string list,string>, ?firstNameKanji: string, ?firstNameKana: string, ?firstName: string, ?email: string, ?dob: Choice<Update'IndividualDobDateOfBirthSpecs,string>, ?addressKanji: Update'IndividualAddressKanji, ?addressKana: Update'IndividualAddressKana, ?ssnLast4: string, ?verification: Update'IndividualVerification) =
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
                SsnLast4 = ssnLast4
                Verification = verification
            }

    type Update'SettingsBranding = {
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) An icon for the account. Must be square and at least 128px x 128px.
        [<Config.Form>]Icon: string option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) A logo for the account that will be used in Checkout instead of the icon and without the account's name next to it if provided. Must be at least 128px x 128px.
        [<Config.Form>]Logo: string option
        ///A CSS hex color value representing the primary branding color for this account.
        [<Config.Form>]PrimaryColor: string option
        ///A CSS hex color value representing the secondary branding color for this account.
        [<Config.Form>]SecondaryColor: string option
    }
    with
        static member New(?icon: string, ?logo: string, ?primaryColor: string, ?secondaryColor: string) =
            {
                Icon = icon
                Logo = logo
                PrimaryColor = primaryColor
                SecondaryColor = secondaryColor
            }

    type Update'SettingsCardIssuingTosAcceptance = {
        ///The Unix timestamp marking when the account representative accepted the service agreement.
        [<Config.Form>]Date: DateTime option
        ///The IP address from which the account representative accepted the service agreement.
        [<Config.Form>]Ip: string option
        ///The user agent of the browser from which the account representative accepted the service agreement.
        [<Config.Form>]UserAgent: Choice<string,string> option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?userAgent: Choice<string,string>) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Update'SettingsCardIssuing = {
        ///Details on the account's acceptance of the [Stripe Issuing Terms and Disclosures](https://stripe.com/docs/issuing/connect/tos_acceptance).
        [<Config.Form>]TosAcceptance: Update'SettingsCardIssuingTosAcceptance option
    }
    with
        static member New(?tosAcceptance: Update'SettingsCardIssuingTosAcceptance) =
            {
                TosAcceptance = tosAcceptance
            }

    type Update'SettingsCardPaymentsDeclineOn = {
        ///Whether Stripe automatically declines charges with an incorrect ZIP or postal code. This setting only applies when a ZIP or postal code is provided and they fail bank verification.
        [<Config.Form>]AvsFailure: bool option
        ///Whether Stripe automatically declines charges with an incorrect CVC. This setting only applies when a CVC is provided and it fails bank verification.
        [<Config.Form>]CvcFailure: bool option
    }
    with
        static member New(?avsFailure: bool, ?cvcFailure: bool) =
            {
                AvsFailure = avsFailure
                CvcFailure = cvcFailure
            }

    type Update'SettingsCardPayments = {
        ///Automatically declines certain charge types regardless of whether the card issuer accepted or declined the charge.
        [<Config.Form>]DeclineOn: Update'SettingsCardPaymentsDeclineOn option
        ///The default text that appears on credit card statements when a charge is made. This field prefixes any dynamic `statement_descriptor` specified on the charge. `statement_descriptor_prefix` is useful for maximizing descriptor space for the dynamic portion.
        [<Config.Form>]StatementDescriptorPrefix: string option
        ///The Kana variation of the default text that appears on credit card statements when a charge is made (Japan only). This field prefixes any dynamic `statement_descriptor_suffix_kana` specified on the charge. `statement_descriptor_prefix_kana` is useful for maximizing descriptor space for the dynamic portion.
        [<Config.Form>]StatementDescriptorPrefixKana: Choice<string,string> option
        ///The Kanji variation of the default text that appears on credit card statements when a charge is made (Japan only). This field prefixes any dynamic `statement_descriptor_suffix_kanji` specified on the charge. `statement_descriptor_prefix_kanji` is useful for maximizing descriptor space for the dynamic portion.
        [<Config.Form>]StatementDescriptorPrefixKanji: Choice<string,string> option
    }
    with
        static member New(?declineOn: Update'SettingsCardPaymentsDeclineOn, ?statementDescriptorPrefix: string, ?statementDescriptorPrefixKana: Choice<string,string>, ?statementDescriptorPrefixKanji: Choice<string,string>) =
            {
                DeclineOn = declineOn
                StatementDescriptorPrefix = statementDescriptorPrefix
                StatementDescriptorPrefixKana = statementDescriptorPrefixKana
                StatementDescriptorPrefixKanji = statementDescriptorPrefixKanji
            }

    type Update'SettingsPayments = {
        ///The default text that appears on credit card statements when a charge is made. This field prefixes any dynamic `statement_descriptor` specified on the charge.
        [<Config.Form>]StatementDescriptor: string option
        ///The Kana variation of the default text that appears on credit card statements when a charge is made (Japan only).
        [<Config.Form>]StatementDescriptorKana: string option
        ///The Kanji variation of the default text that appears on credit card statements when a charge is made (Japan only).
        [<Config.Form>]StatementDescriptorKanji: string option
    }
    with
        static member New(?statementDescriptor: string, ?statementDescriptorKana: string, ?statementDescriptorKanji: string) =
            {
                StatementDescriptor = statementDescriptor
                StatementDescriptorKana = statementDescriptorKana
                StatementDescriptorKanji = statementDescriptorKanji
            }

    type Update'SettingsPayoutsScheduleDelayDays =
    | Minimum

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

    type Update'SettingsPayoutsSchedule = {
        ///The number of days charge funds are held before being paid out. May also be set to `minimum`, representing the lowest available value for the account country. Default is `minimum`. The `delay_days` parameter remains at the last configured value if `interval` is `manual`. [Learn more about controlling payout delay days](https://stripe.com/docs/connect/manage-payout-schedule).
        [<Config.Form>]DelayDays: Choice<Update'SettingsPayoutsScheduleDelayDays,int> option
        ///How frequently available funds are paid out. One of: `daily`, `manual`, `weekly`, or `monthly`. Default is `daily`.
        [<Config.Form>]Interval: Update'SettingsPayoutsScheduleInterval option
        ///The day of the month when available funds are paid out, specified as a number between 1--31. Payouts nominally scheduled between the 29th and 31st of the month are instead sent on the last day of a shorter month. Required and applicable only if `interval` is `monthly`.
        [<Config.Form>]MonthlyAnchor: int option
        ///The day of the week when available funds are paid out, specified as `monday`, `tuesday`, etc. (required and applicable only if `interval` is `weekly`.)
        [<Config.Form>]WeeklyAnchor: Update'SettingsPayoutsScheduleWeeklyAnchor option
    }
    with
        static member New(?delayDays: Choice<Update'SettingsPayoutsScheduleDelayDays,int>, ?interval: Update'SettingsPayoutsScheduleInterval, ?monthlyAnchor: int, ?weeklyAnchor: Update'SettingsPayoutsScheduleWeeklyAnchor) =
            {
                DelayDays = delayDays
                Interval = interval
                MonthlyAnchor = monthlyAnchor
                WeeklyAnchor = weeklyAnchor
            }

    type Update'SettingsPayouts = {
        ///A Boolean indicating whether Stripe should try to reclaim negative balances from an attached bank account. For details, see [Understanding Connect Account Balances](https://stripe.com/docs/connect/account-balances).
        [<Config.Form>]DebitNegativeBalances: bool option
        ///Details on when funds from charges are available, and when they are paid out to an external account. For details, see our [Setting Bank and Debit Card Payouts](https://stripe.com/docs/connect/bank-transfers#payout-information) documentation.
        [<Config.Form>]Schedule: Update'SettingsPayoutsSchedule option
        ///The text that appears on the bank account statement for payouts. If not set, this defaults to the platform's bank descriptor as set in the Dashboard.
        [<Config.Form>]StatementDescriptor: string option
    }
    with
        static member New(?debitNegativeBalances: bool, ?schedule: Update'SettingsPayoutsSchedule, ?statementDescriptor: string) =
            {
                DebitNegativeBalances = debitNegativeBalances
                Schedule = schedule
                StatementDescriptor = statementDescriptor
            }

    type Update'SettingsTreasuryTosAcceptance = {
        ///The Unix timestamp marking when the account representative accepted the service agreement.
        [<Config.Form>]Date: DateTime option
        ///The IP address from which the account representative accepted the service agreement.
        [<Config.Form>]Ip: string option
        ///The user agent of the browser from which the account representative accepted the service agreement.
        [<Config.Form>]UserAgent: Choice<string,string> option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?userAgent: Choice<string,string>) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Update'SettingsTreasury = {
        ///Details on the account's acceptance of the Stripe Treasury Services Agreement.
        [<Config.Form>]TosAcceptance: Update'SettingsTreasuryTosAcceptance option
    }
    with
        static member New(?tosAcceptance: Update'SettingsTreasuryTosAcceptance) =
            {
                TosAcceptance = tosAcceptance
            }

    type Update'Settings = {
        ///Settings used to apply the account's branding to email receipts, invoices, Checkout, and other products.
        [<Config.Form>]Branding: Update'SettingsBranding option
        ///Settings specific to the account's use of the Card Issuing product.
        [<Config.Form>]CardIssuing: Update'SettingsCardIssuing option
        ///Settings specific to card charging on the account.
        [<Config.Form>]CardPayments: Update'SettingsCardPayments option
        ///Settings that apply across payment methods for charging on the account.
        [<Config.Form>]Payments: Update'SettingsPayments option
        ///Settings specific to the account's payouts.
        [<Config.Form>]Payouts: Update'SettingsPayouts option
        ///Settings specific to the account's Treasury FinancialAccounts.
        [<Config.Form>]Treasury: Update'SettingsTreasury option
    }
    with
        static member New(?branding: Update'SettingsBranding, ?cardIssuing: Update'SettingsCardIssuing, ?cardPayments: Update'SettingsCardPayments, ?payments: Update'SettingsPayments, ?payouts: Update'SettingsPayouts, ?treasury: Update'SettingsTreasury) =
            {
                Branding = branding
                CardIssuing = cardIssuing
                CardPayments = cardPayments
                Payments = payments
                Payouts = payouts
                Treasury = treasury
            }

    type Update'TosAcceptance = {
        ///The Unix timestamp marking when the account representative accepted their service agreement.
        [<Config.Form>]Date: DateTime option
        ///The IP address from which the account representative accepted their service agreement.
        [<Config.Form>]Ip: string option
        ///The user's service agreement type.
        [<Config.Form>]ServiceAgreement: string option
        ///The user agent of the browser from which the account representative accepted their service agreement.
        [<Config.Form>]UserAgent: string option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?serviceAgreement: string, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                ServiceAgreement = serviceAgreement
                UserAgent = userAgent
            }

    type Update'BusinessType =
    | Company
    | GovernmentEntity
    | Individual
    | NonProfit

    type UpdateOptions = {
        [<Config.Path>]Account: string
        ///An [account token](https://stripe.com/docs/api#create_account_token), used to securely provide details to the account.
        [<Config.Form>]AccountToken: string option
        ///Business information about the account.
        [<Config.Form>]BusinessProfile: Update'BusinessProfile option
        ///The business type.
        [<Config.Form>]BusinessType: Update'BusinessType option
        ///Each key of the dictionary represents a capability, and each capability maps to its settings (e.g. whether it has been requested or not). Each capability will be inactive until you have provided its specific requirements and Stripe has verified them. An account may have some of its requested capabilities be active and some be inactive.
        [<Config.Form>]Capabilities: Update'Capabilities option
        ///Information about the company or business. This field is available for any `business_type`.
        [<Config.Form>]Company: Update'Company option
        ///Three-letter ISO currency code representing the default currency for the account. This must be a currency that [Stripe supports in the account's country](https://stripe.com/docs/payouts).
        [<Config.Form>]DefaultCurrency: string option
        ///Documents that may be submitted to satisfy various informational requests.
        [<Config.Form>]Documents: Update'Documents option
        ///The email address of the account holder. This is only to make the account easier to identify to you. Stripe only emails Custom accounts with your consent.
        [<Config.Form>]Email: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///A card or bank account to attach to the account for receiving [payouts](https://stripe.com/docs/connect/bank-debit-card-payouts) (you won’t be able to use it for top-ups). You can provide either a token, like the ones returned by [Stripe.js](https://stripe.com/docs/js), or a dictionary, as documented in the `external_account` parameter for [bank account](https://stripe.com/docs/api#account_create_bank_account) creation. <br><br>By default, providing an external account sets it as the new default external account for its currency, and deletes the old default if one exists. To add additional external accounts without replacing the existing default for the currency, use the [bank account](https://stripe.com/docs/api#account_create_bank_account) or [card creation](https://stripe.com/docs/api#account_create_card) APIs.
        [<Config.Form>]ExternalAccount: string option
        ///Information about the person represented by the account. This field is null unless `business_type` is set to `individual`.
        [<Config.Form>]Individual: Update'Individual option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Options for customizing how the account functions within Stripe.
        [<Config.Form>]Settings: Update'Settings option
        ///Details on the account's acceptance of the [Stripe Services Agreement](https://stripe.com/docs/connect/updating-accounts#tos-acceptance).
        [<Config.Form>]TosAcceptance: Update'TosAcceptance option
    }
    with
        static member New(account: string, ?accountToken: string, ?businessProfile: Update'BusinessProfile, ?businessType: Update'BusinessType, ?capabilities: Update'Capabilities, ?company: Update'Company, ?defaultCurrency: string, ?documents: Update'Documents, ?email: string, ?expand: string list, ?externalAccount: string, ?individual: Update'Individual, ?metadata: Map<string, string>, ?settings: Update'Settings, ?tosAcceptance: Update'TosAcceptance) =
            {
                Account = account
                AccountToken = accountToken
                BusinessProfile = businessProfile
                BusinessType = businessType
                Capabilities = capabilities
                Company = company
                DefaultCurrency = defaultCurrency
                Documents = documents
                Email = email
                Expand = expand
                ExternalAccount = externalAccount
                Individual = individual
                Metadata = metadata
                Settings = settings
                TosAcceptance = tosAcceptance
            }

    ///<p>Updates a <a href="/docs/connect/accounts">connected account</a> by setting the values of the parameters passed. Any parameters not provided are
    ///left unchanged.
    ///For Custom accounts, you can update any information on the account. For other accounts, you can update all information until that
    ///account has started to go through Connect Onboarding. Once you create an <a href="/docs/api/account_links">Account Link</a>
    ///for a Standard or Express account, some parameters can no longer be changed. These are marked as <strong>Custom Only</strong> or <strong>Custom and Express</strong>
    ///below.
    ///To update your own account, use the <a href="https://dashboard.stripe.com/settings/account">Dashboard</a>. Refer to our
    ///<a href="/docs/connect/updating-accounts">Connect</a> documentation to learn more about updating accounts.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/accounts/{options.Account}"
        |> RestApi.postAsync<_, Account> settings (Map.empty) options

module AccountsCapabilities =

    type CapabilitiesOptions = {
        [<Config.Path>]Account: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(account: string, ?expand: string list) =
            {
                Account = account
                Expand = expand
            }

    ///<p>Returns a list of capabilities associated with the account. The capabilities are returned sorted by creation date, with the most recent capability appearing first.</p>
    let Capabilities settings (options: CapabilitiesOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/accounts/{options.Account}/capabilities"
        |> RestApi.getAsync<Capability list> settings qs

    type RetrieveOptions = {
        [<Config.Path>]Account: string
        [<Config.Path>]Capability: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(account: string, capability: string, ?expand: string list) =
            {
                Account = account
                Capability = capability
                Expand = expand
            }

    ///<p>Retrieves information about the specified Account Capability.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/accounts/{options.Account}/capabilities/{options.Capability}"
        |> RestApi.getAsync<Capability> settings qs

    type UpdateOptions = {
        [<Config.Path>]Account: string
        [<Config.Path>]Capability: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(account: string, capability: string, ?expand: string list, ?requested: bool) =
            {
                Account = account
                Capability = capability
                Expand = expand
                Requested = requested
            }

    ///<p>Updates an existing Account Capability.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/accounts/{options.Account}/capabilities/{options.Capability}"
        |> RestApi.postAsync<_, Capability> settings (Map.empty) options

module AccountsExternalAccounts =

    type ListOptions = {
        [<Config.Path>]Account: string
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
        static member New(account: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Account = account
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>List external accounts for an account.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/accounts/{options.Account}/external_accounts"
        |> RestApi.getAsync<ExternalAccount list> settings qs

    type CreateOptions = {
        [<Config.Path>]Account: string
        ///When set to true, or if this is the first external account added in this currency, this account becomes the default external account for its currency.
        [<Config.Form>]DefaultForCurrency: bool option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Please refer to full [documentation](https://stripe.com/docs/api) instead.
        [<Config.Form>]ExternalAccount: string
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(account: string, externalAccount: string, ?defaultForCurrency: bool, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Account = account
                DefaultForCurrency = defaultForCurrency
                Expand = expand
                ExternalAccount = externalAccount
                Metadata = metadata
            }

    ///<p>Create an external account for a given account.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/accounts/{options.Account}/external_accounts"
        |> RestApi.postAsync<_, ExternalAccount> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Account: string
        [<Config.Path>]Id: string
    }
    with
        static member New(account: string, id: string) =
            {
                Account = account
                Id = id
            }

    ///<p>Delete a specified external account for a given account.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/accounts/{options.Account}/external_accounts/{options.Id}"
        |> RestApi.deleteAsync<DeletedExternalAccount> settings (Map.empty)

    type RetrieveOptions = {
        [<Config.Path>]Account: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
    }
    with
        static member New(account: string, id: string, ?expand: string list) =
            {
                Account = account
                Expand = expand
                Id = id
            }

    ///<p>Retrieve a specified external account for a given account.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/accounts/{options.Account}/external_accounts/{options.Id}"
        |> RestApi.getAsync<ExternalAccount> settings qs

    type Update'DocumentsBankAccountOwnershipVerification = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Update'Documents = {
        ///One or more documents that support the [Bank account ownership verification](https://support.stripe.com/questions/bank-account-ownership-verification) requirement. Must be a document associated with the bank account that displays the last 4 digits of the account number, either a statement or a voided check.
        [<Config.Form>]BankAccountOwnershipVerification: Update'DocumentsBankAccountOwnershipVerification option
    }
    with
        static member New(?bankAccountOwnershipVerification: Update'DocumentsBankAccountOwnershipVerification) =
            {
                BankAccountOwnershipVerification = bankAccountOwnershipVerification
            }

    type Update'AccountHolderType =
    | Company
    | Individual

    type Update'AccountType =
    | Checking
    | Futsu
    | Savings
    | Toza

    type UpdateOptions = {
        [<Config.Path>]Account: string
        [<Config.Path>]Id: string
        ///The name of the person or business that owns the bank account.
        [<Config.Form>]AccountHolderName: string option
        ///The type of entity that holds the account. This can be either `individual` or `company`.
        [<Config.Form>]AccountHolderType: Update'AccountHolderType option
        ///The bank account type. This can only be `checking` or `savings` in most countries. In Japan, this can only be `futsu` or `toza`.
        [<Config.Form>]AccountType: Update'AccountType option
        ///City/District/Suburb/Town/Village.
        [<Config.Form>]AddressCity: string option
        ///Billing address country, if provided when creating card.
        [<Config.Form>]AddressCountry: string option
        ///Address line 1 (Street address/PO Box/Company name).
        [<Config.Form>]AddressLine1: string option
        ///Address line 2 (Apartment/Suite/Unit/Building).
        [<Config.Form>]AddressLine2: string option
        ///State/County/Province/Region.
        [<Config.Form>]AddressState: string option
        ///ZIP or postal code.
        [<Config.Form>]AddressZip: string option
        ///When set to true, this becomes the default external account for its currency.
        [<Config.Form>]DefaultForCurrency: bool option
        ///Documents that may be submitted to satisfy various informational requests.
        [<Config.Form>]Documents: Update'Documents option
        ///Two digit number representing the card’s expiration month.
        [<Config.Form>]ExpMonth: string option
        ///Four digit number representing the card’s expiration year.
        [<Config.Form>]ExpYear: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Cardholder name.
        [<Config.Form>]Name: string option
    }
    with
        static member New(account: string, id: string, ?expand: string list, ?expYear: string, ?expMonth: string, ?documents: Update'Documents, ?defaultForCurrency: bool, ?addressZip: string, ?addressState: string, ?addressLine2: string, ?addressLine1: string, ?addressCountry: string, ?addressCity: string, ?accountType: Update'AccountType, ?accountHolderType: Update'AccountHolderType, ?accountHolderName: string, ?metadata: Map<string, string>, ?name: string) =
            {
                Account = account
                Id = id
                AccountHolderName = accountHolderName
                AccountHolderType = accountHolderType
                AccountType = accountType
                AddressCity = addressCity
                AddressCountry = addressCountry
                AddressLine1 = addressLine1
                AddressLine2 = addressLine2
                AddressState = addressState
                AddressZip = addressZip
                DefaultForCurrency = defaultForCurrency
                Documents = documents
                ExpMonth = expMonth
                ExpYear = expYear
                Expand = expand
                Metadata = metadata
                Name = name
            }

    ///<p>Updates the metadata, account holder name, account holder type of a bank account belonging to a <a href="/docs/connect/custom-accounts">Custom account</a>, and optionally sets it as the default for its currency. Other bank account details are not editable by design.
    ///You can re-enable a disabled bank account by performing an update call without providing any arguments or changes.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/accounts/{options.Account}/external_accounts/{options.Id}"
        |> RestApi.postAsync<_, ExternalAccount> settings (Map.empty) options

module AccountsLoginLinks =

    type CreateOptions = {
        [<Config.Path>]Account: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(account: string, ?expand: string list) =
            {
                Account = account
                Expand = expand
            }

    ///<p>Creates a single-use login link for an Express account to access their Stripe dashboard.
    ///<strong>You may only create login links for <a href="/docs/connect/express-accounts">Express accounts</a> connected to your platform</strong>.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/accounts/{options.Account}/login_links"
        |> RestApi.postAsync<_, LoginLink> settings (Map.empty) options

module AccountsPersons =

    type PersonsOptions = {
        [<Config.Path>]Account: string
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///Filters on the list of people returned based on the person's relationship to the account's company.
        [<Config.Query>]Relationship: Map<string, string> option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(account: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?relationship: Map<string, string>, ?startingAfter: string) =
            {
                Account = account
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Relationship = relationship
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of people associated with the account’s legal entity. The people are returned sorted by creation date, with the most recent people appearing first.</p>
    let Persons settings (options: PersonsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("relationship", options.Relationship |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/accounts/{options.Account}/persons"
        |> RestApi.getAsync<Person list> settings qs

    type Create'Address = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'AddressKana = {
        ///City or ward.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Block or building number.
        [<Config.Form>]Line1: string option
        ///Building details.
        [<Config.Form>]Line2: string option
        ///Postal code.
        [<Config.Form>]PostalCode: string option
        ///Prefecture.
        [<Config.Form>]State: string option
        ///Town or cho-me.
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'AddressKanji = {
        ///City or ward.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Block or building number.
        [<Config.Form>]Line1: string option
        ///Building details.
        [<Config.Form>]Line2: string option
        ///Postal code.
        [<Config.Form>]PostalCode: string option
        ///Prefecture.
        [<Config.Form>]State: string option
        ///Town or cho-me.
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'DobDateOfBirthSpecs = {
        ///The day of birth, between 1 and 31.
        [<Config.Form>]Day: int option
        ///The month of birth, between 1 and 12.
        [<Config.Form>]Month: int option
        ///The four-digit year of birth.
        [<Config.Form>]Year: int option
    }
    with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Create'DocumentsCompanyAuthorization = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: Choice<string,string> list option
    }
    with
        static member New(?files: Choice<string,string> list) =
            {
                Files = files
            }

    type Create'DocumentsPassport = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: Choice<string,string> list option
    }
    with
        static member New(?files: Choice<string,string> list) =
            {
                Files = files
            }

    type Create'DocumentsVisa = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: Choice<string,string> list option
    }
    with
        static member New(?files: Choice<string,string> list) =
            {
                Files = files
            }

    type Create'Documents = {
        ///One or more documents that demonstrate proof that this person is authorized to represent the company.
        [<Config.Form>]CompanyAuthorization: Create'DocumentsCompanyAuthorization option
        ///One or more documents showing the person's passport page with photo and personal data.
        [<Config.Form>]Passport: Create'DocumentsPassport option
        ///One or more documents showing the person's visa required for living in the country where they are residing.
        [<Config.Form>]Visa: Create'DocumentsVisa option
    }
    with
        static member New(?companyAuthorization: Create'DocumentsCompanyAuthorization, ?passport: Create'DocumentsPassport, ?visa: Create'DocumentsVisa) =
            {
                CompanyAuthorization = companyAuthorization
                Passport = passport
                Visa = visa
            }

    type Create'RegisteredAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'Relationship = {
        ///Whether the person is a director of the account's legal entity. Directors are typically members of the governing board of the company, or responsible for ensuring the company meets its regulatory obligations.
        [<Config.Form>]Director: bool option
        ///Whether the person has significant responsibility to control, manage, or direct the organization.
        [<Config.Form>]Executive: bool option
        ///Whether the person is an owner of the account’s legal entity.
        [<Config.Form>]Owner: bool option
        ///The percent owned by the person of the account's legal entity.
        [<Config.Form>]PercentOwnership: Choice<decimal,string> option
        ///Whether the person is authorized as the primary representative of the account. This is the person nominated by the business to provide information about themselves, and general information about the account. There can only be one representative at any given time. At the time the account is created, this person should be set to the person responsible for opening the account.
        [<Config.Form>]Representative: bool option
        ///The person's title (e.g., CEO, Support Engineer).
        [<Config.Form>]Title: string option
    }
    with
        static member New(?director: bool, ?executive: bool, ?owner: bool, ?percentOwnership: Choice<decimal,string>, ?representative: bool, ?title: string) =
            {
                Director = director
                Executive = executive
                Owner = owner
                PercentOwnership = percentOwnership
                Representative = representative
                Title = title
            }

    type Create'VerificationAdditionalDocument = {
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Back: string option
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Create'VerificationDocument = {
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Back: string option
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Create'Verification = {
        ///A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.
        [<Config.Form>]AdditionalDocument: Create'VerificationAdditionalDocument option
        ///An identifying document, either a passport or local ID card.
        [<Config.Form>]Document: Create'VerificationDocument option
    }
    with
        static member New(?additionalDocument: Create'VerificationAdditionalDocument, ?document: Create'VerificationDocument) =
            {
                AdditionalDocument = additionalDocument
                Document = document
            }

    type CreateOptions = {
        [<Config.Path>]Account: string
        ///The person's address.
        [<Config.Form>]Address: Create'Address option
        ///The Kana variation of the person's address (Japan only).
        [<Config.Form>]AddressKana: Create'AddressKana option
        ///The Kanji variation of the person's address (Japan only).
        [<Config.Form>]AddressKanji: Create'AddressKanji option
        ///The person's date of birth.
        [<Config.Form>]Dob: Choice<Create'DobDateOfBirthSpecs,string> option
        ///Documents that may be submitted to satisfy various informational requests.
        [<Config.Form>]Documents: Create'Documents option
        ///The person's email address.
        [<Config.Form>]Email: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The person's first name.
        [<Config.Form>]FirstName: string option
        ///The Kana variation of the person's first name (Japan only).
        [<Config.Form>]FirstNameKana: string option
        ///The Kanji variation of the person's first name (Japan only).
        [<Config.Form>]FirstNameKanji: string option
        ///A list of alternate names or aliases that the person is known by.
        [<Config.Form>]FullNameAliases: Choice<string list,string> option
        ///The person's gender (International regulations require either "male" or "female").
        [<Config.Form>]Gender: string option
        ///The person's ID number, as appropriate for their country. For example, a social security number in the U.S., social insurance number in Canada, etc. Instead of the number itself, you can also provide a [PII token provided by Stripe.js](https://stripe.com/docs/js/tokens_sources/create_token?type=pii).
        [<Config.Form>]IdNumber: string option
        ///The person's secondary ID number, as appropriate for their country, will be used for enhanced verification checks. In Thailand, this would be the laser code found on the back of an ID card. Instead of the number itself, you can also provide a [PII token provided by Stripe.js](https://stripe.com/docs/js/tokens_sources/create_token?type=pii).
        [<Config.Form>]IdNumberSecondary: string option
        ///The person's last name.
        [<Config.Form>]LastName: string option
        ///The Kana variation of the person's last name (Japan only).
        [<Config.Form>]LastNameKana: string option
        ///The Kanji variation of the person's last name (Japan only).
        [<Config.Form>]LastNameKanji: string option
        ///The person's maiden name.
        [<Config.Form>]MaidenName: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The country where the person is a national. Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)), or "XX" if unavailable.
        [<Config.Form>]Nationality: string option
        ///A [person token](https://stripe.com/docs/connect/account-tokens), used to securely provide details to the person.
        [<Config.Form>]PersonToken: string option
        ///The person's phone number.
        [<Config.Form>]Phone: string option
        ///Indicates if the person or any of their representatives, family members, or other closely related persons, declares that they hold or have held an important public job or function, in any jurisdiction.
        [<Config.Form>]PoliticalExposure: string option
        ///The person's registered address.
        [<Config.Form>]RegisteredAddress: Create'RegisteredAddress option
        ///The relationship that this person has with the account's legal entity.
        [<Config.Form>]Relationship: Create'Relationship option
        ///The last four digits of the person's Social Security number (U.S. only).
        [<Config.Form>]SsnLast4: string option
        ///The person's verification status.
        [<Config.Form>]Verification: Create'Verification option
    }
    with
        static member New(account: string, ?relationship: Create'Relationship, ?registeredAddress: Create'RegisteredAddress, ?politicalExposure: string, ?phone: string, ?personToken: string, ?nationality: string, ?metadata: Map<string, string>, ?maidenName: string, ?lastNameKanji: string, ?lastNameKana: string, ?lastName: string, ?idNumberSecondary: string, ?idNumber: string, ?gender: string, ?fullNameAliases: Choice<string list,string>, ?firstNameKanji: string, ?firstNameKana: string, ?firstName: string, ?expand: string list, ?email: string, ?documents: Create'Documents, ?dob: Choice<Create'DobDateOfBirthSpecs,string>, ?addressKanji: Create'AddressKanji, ?addressKana: Create'AddressKana, ?address: Create'Address, ?ssnLast4: string, ?verification: Create'Verification) =
            {
                Account = account
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                Dob = dob
                Documents = documents
                Email = email
                Expand = expand
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
                Nationality = nationality
                PersonToken = personToken
                Phone = phone
                PoliticalExposure = politicalExposure
                RegisteredAddress = registeredAddress
                Relationship = relationship
                SsnLast4 = ssnLast4
                Verification = verification
            }

    ///<p>Creates a new person.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/accounts/{options.Account}/persons"
        |> RestApi.postAsync<_, Person> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Account: string
        [<Config.Path>]Person: string
    }
    with
        static member New(account: string, person: string) =
            {
                Account = account
                Person = person
            }

    ///<p>Deletes an existing person’s relationship to the account’s legal entity. Any person with a relationship for an account can be deleted through the API, except if the person is the <code>account_opener</code>. If your integration is using the <code>executive</code> parameter, you cannot delete the only verified <code>executive</code> on file.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/accounts/{options.Account}/persons/{options.Person}"
        |> RestApi.deleteAsync<DeletedPerson> settings (Map.empty)

    type RetrieveOptions = {
        [<Config.Path>]Account: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Person: string
    }
    with
        static member New(account: string, person: string, ?expand: string list) =
            {
                Account = account
                Expand = expand
                Person = person
            }

    ///<p>Retrieves an existing person.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/accounts/{options.Account}/persons/{options.Person}"
        |> RestApi.getAsync<Person> settings qs

    type Update'Address = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'AddressKana = {
        ///City or ward.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Block or building number.
        [<Config.Form>]Line1: string option
        ///Building details.
        [<Config.Form>]Line2: string option
        ///Postal code.
        [<Config.Form>]PostalCode: string option
        ///Prefecture.
        [<Config.Form>]State: string option
        ///Town or cho-me.
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Update'AddressKanji = {
        ///City or ward.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Block or building number.
        [<Config.Form>]Line1: string option
        ///Building details.
        [<Config.Form>]Line2: string option
        ///Postal code.
        [<Config.Form>]PostalCode: string option
        ///Prefecture.
        [<Config.Form>]State: string option
        ///Town or cho-me.
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Update'DobDateOfBirthSpecs = {
        ///The day of birth, between 1 and 31.
        [<Config.Form>]Day: int option
        ///The month of birth, between 1 and 12.
        [<Config.Form>]Month: int option
        ///The four-digit year of birth.
        [<Config.Form>]Year: int option
    }
    with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Update'DocumentsCompanyAuthorization = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: Choice<string,string> list option
    }
    with
        static member New(?files: Choice<string,string> list) =
            {
                Files = files
            }

    type Update'DocumentsPassport = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: Choice<string,string> list option
    }
    with
        static member New(?files: Choice<string,string> list) =
            {
                Files = files
            }

    type Update'DocumentsVisa = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: Choice<string,string> list option
    }
    with
        static member New(?files: Choice<string,string> list) =
            {
                Files = files
            }

    type Update'Documents = {
        ///One or more documents that demonstrate proof that this person is authorized to represent the company.
        [<Config.Form>]CompanyAuthorization: Update'DocumentsCompanyAuthorization option
        ///One or more documents showing the person's passport page with photo and personal data.
        [<Config.Form>]Passport: Update'DocumentsPassport option
        ///One or more documents showing the person's visa required for living in the country where they are residing.
        [<Config.Form>]Visa: Update'DocumentsVisa option
    }
    with
        static member New(?companyAuthorization: Update'DocumentsCompanyAuthorization, ?passport: Update'DocumentsPassport, ?visa: Update'DocumentsVisa) =
            {
                CompanyAuthorization = companyAuthorization
                Passport = passport
                Visa = visa
            }

    type Update'RegisteredAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'Relationship = {
        ///Whether the person is a director of the account's legal entity. Directors are typically members of the governing board of the company, or responsible for ensuring the company meets its regulatory obligations.
        [<Config.Form>]Director: bool option
        ///Whether the person has significant responsibility to control, manage, or direct the organization.
        [<Config.Form>]Executive: bool option
        ///Whether the person is an owner of the account’s legal entity.
        [<Config.Form>]Owner: bool option
        ///The percent owned by the person of the account's legal entity.
        [<Config.Form>]PercentOwnership: Choice<decimal,string> option
        ///Whether the person is authorized as the primary representative of the account. This is the person nominated by the business to provide information about themselves, and general information about the account. There can only be one representative at any given time. At the time the account is created, this person should be set to the person responsible for opening the account.
        [<Config.Form>]Representative: bool option
        ///The person's title (e.g., CEO, Support Engineer).
        [<Config.Form>]Title: string option
    }
    with
        static member New(?director: bool, ?executive: bool, ?owner: bool, ?percentOwnership: Choice<decimal,string>, ?representative: bool, ?title: string) =
            {
                Director = director
                Executive = executive
                Owner = owner
                PercentOwnership = percentOwnership
                Representative = representative
                Title = title
            }

    type Update'VerificationAdditionalDocument = {
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Back: string option
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Update'VerificationDocument = {
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Back: string option
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Update'Verification = {
        ///A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.
        [<Config.Form>]AdditionalDocument: Update'VerificationAdditionalDocument option
        ///An identifying document, either a passport or local ID card.
        [<Config.Form>]Document: Update'VerificationDocument option
    }
    with
        static member New(?additionalDocument: Update'VerificationAdditionalDocument, ?document: Update'VerificationDocument) =
            {
                AdditionalDocument = additionalDocument
                Document = document
            }

    type UpdateOptions = {
        [<Config.Path>]Account: string
        [<Config.Path>]Person: string
        ///The person's address.
        [<Config.Form>]Address: Update'Address option
        ///The Kana variation of the person's address (Japan only).
        [<Config.Form>]AddressKana: Update'AddressKana option
        ///The Kanji variation of the person's address (Japan only).
        [<Config.Form>]AddressKanji: Update'AddressKanji option
        ///The person's date of birth.
        [<Config.Form>]Dob: Choice<Update'DobDateOfBirthSpecs,string> option
        ///Documents that may be submitted to satisfy various informational requests.
        [<Config.Form>]Documents: Update'Documents option
        ///The person's email address.
        [<Config.Form>]Email: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The person's first name.
        [<Config.Form>]FirstName: string option
        ///The Kana variation of the person's first name (Japan only).
        [<Config.Form>]FirstNameKana: string option
        ///The Kanji variation of the person's first name (Japan only).
        [<Config.Form>]FirstNameKanji: string option
        ///A list of alternate names or aliases that the person is known by.
        [<Config.Form>]FullNameAliases: Choice<string list,string> option
        ///The person's gender (International regulations require either "male" or "female").
        [<Config.Form>]Gender: string option
        ///The person's ID number, as appropriate for their country. For example, a social security number in the U.S., social insurance number in Canada, etc. Instead of the number itself, you can also provide a [PII token provided by Stripe.js](https://stripe.com/docs/js/tokens_sources/create_token?type=pii).
        [<Config.Form>]IdNumber: string option
        ///The person's secondary ID number, as appropriate for their country, will be used for enhanced verification checks. In Thailand, this would be the laser code found on the back of an ID card. Instead of the number itself, you can also provide a [PII token provided by Stripe.js](https://stripe.com/docs/js/tokens_sources/create_token?type=pii).
        [<Config.Form>]IdNumberSecondary: string option
        ///The person's last name.
        [<Config.Form>]LastName: string option
        ///The Kana variation of the person's last name (Japan only).
        [<Config.Form>]LastNameKana: string option
        ///The Kanji variation of the person's last name (Japan only).
        [<Config.Form>]LastNameKanji: string option
        ///The person's maiden name.
        [<Config.Form>]MaidenName: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The country where the person is a national. Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)), or "XX" if unavailable.
        [<Config.Form>]Nationality: string option
        ///A [person token](https://stripe.com/docs/connect/account-tokens), used to securely provide details to the person.
        [<Config.Form>]PersonToken: string option
        ///The person's phone number.
        [<Config.Form>]Phone: string option
        ///Indicates if the person or any of their representatives, family members, or other closely related persons, declares that they hold or have held an important public job or function, in any jurisdiction.
        [<Config.Form>]PoliticalExposure: string option
        ///The person's registered address.
        [<Config.Form>]RegisteredAddress: Update'RegisteredAddress option
        ///The relationship that this person has with the account's legal entity.
        [<Config.Form>]Relationship: Update'Relationship option
        ///The last four digits of the person's Social Security number (U.S. only).
        [<Config.Form>]SsnLast4: string option
        ///The person's verification status.
        [<Config.Form>]Verification: Update'Verification option
    }
    with
        static member New(account: string, person: string, ?relationship: Update'Relationship, ?registeredAddress: Update'RegisteredAddress, ?politicalExposure: string, ?phone: string, ?personToken: string, ?nationality: string, ?metadata: Map<string, string>, ?maidenName: string, ?lastNameKanji: string, ?lastNameKana: string, ?lastName: string, ?idNumberSecondary: string, ?idNumber: string, ?gender: string, ?fullNameAliases: Choice<string list,string>, ?firstNameKanji: string, ?firstNameKana: string, ?firstName: string, ?expand: string list, ?email: string, ?documents: Update'Documents, ?dob: Choice<Update'DobDateOfBirthSpecs,string>, ?addressKanji: Update'AddressKanji, ?addressKana: Update'AddressKana, ?address: Update'Address, ?ssnLast4: string, ?verification: Update'Verification) =
            {
                Account = account
                Person = person
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                Dob = dob
                Documents = documents
                Email = email
                Expand = expand
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
                Nationality = nationality
                PersonToken = personToken
                Phone = phone
                PoliticalExposure = politicalExposure
                RegisteredAddress = registeredAddress
                Relationship = relationship
                SsnLast4 = ssnLast4
                Verification = verification
            }

    ///<p>Updates an existing person.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/accounts/{options.Account}/persons/{options.Person}"
        |> RestApi.postAsync<_, Person> settings (Map.empty) options

module AccountsReject =

    type RejectOptions = {
        [<Config.Path>]Account: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The reason for rejecting the account. Can be `fraud`, `terms_of_service`, or `other`.
        [<Config.Form>]Reason: string
    }
    with
        static member New(account: string, reason: string, ?expand: string list) =
            {
                Account = account
                Expand = expand
                Reason = reason
            }

    ///<p>With <a href="/docs/connect">Connect</a>, you may flag accounts as suspicious.
    ///Test-mode Custom and Express accounts can be rejected at any time. Accounts created using live-mode keys may only be rejected once all balances are zero.</p>
    let Reject settings (options: RejectOptions) =
        $"/v1/accounts/{options.Account}/reject"
        |> RestApi.postAsync<_, Account> settings (Map.empty) options

module ApplePayDomains =

    type ListOptions = {
        [<Config.Query>]DomainName: string option
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
        static member New(?domainName: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                DomainName = domainName
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>List apple pay domains.</p>
    let List settings (options: ListOptions) =
        let qs = [("domain_name", options.DomainName |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/apple_pay/domains"
        |> RestApi.getAsync<ApplePayDomain list> settings qs

    type CreateOptions = {
        [<Config.Form>]DomainName: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(domainName: string, ?expand: string list) =
            {
                DomainName = domainName
                Expand = expand
            }

    ///<p>Create an apple pay domain.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/apple_pay/domains"
        |> RestApi.postAsync<_, ApplePayDomain> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Domain: string
    }
    with
        static member New(domain: string) =
            {
                Domain = domain
            }

    ///<p>Delete an apple pay domain.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/apple_pay/domains/{options.Domain}"
        |> RestApi.deleteAsync<DeletedApplePayDomain> settings (Map.empty)

    type RetrieveOptions = {
        [<Config.Path>]Domain: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(domain: string, ?expand: string list) =
            {
                Domain = domain
                Expand = expand
            }

    ///<p>Retrieve an apple pay domain.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/apple_pay/domains/{options.Domain}"
        |> RestApi.getAsync<ApplePayDomain> settings qs

module ApplicationFees =

    type ListOptions = {
        ///Only return application fees for the charge specified by this charge ID.
        [<Config.Query>]Charge: string option
        [<Config.Query>]Created: int option
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
        static member New(?charge: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Charge = charge
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of application fees you’ve previously collected. The application fees are returned in sorted order, with the most recent fees appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("charge", options.Charge |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/application_fees"
        |> RestApi.getAsync<ApplicationFee list> settings qs

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Expand = expand
                Id = id
            }

    ///<p>Retrieves the details of an application fee that your account has collected. The same information is returned when refunding the application fee.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/application_fees/{options.Id}"
        |> RestApi.getAsync<ApplicationFee> settings qs

module ApplicationFeesRefunds =

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Fee: string
        [<Config.Path>]Id: string
    }
    with
        static member New(fee: string, id: string, ?expand: string list) =
            {
                Expand = expand
                Fee = fee
                Id = id
            }

    ///<p>By default, you can see the 10 most recent refunds stored directly on the application fee object, but you can also retrieve details about a specific refund stored on the application fee.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/application_fees/{options.Fee}/refunds/{options.Id}"
        |> RestApi.getAsync<FeeRefund> settings qs

    type UpdateOptions = {
        [<Config.Path>]Fee: string
        [<Config.Path>]Id: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(fee: string, id: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Fee = fee
                Id = id
                Expand = expand
                Metadata = metadata
            }

    ///<p>Updates the specified application fee refund by setting the values of the parameters passed. Any parameters not provided will be left unchanged.
    ///This request only accepts metadata as an argument.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/application_fees/{options.Fee}/refunds/{options.Id}"
        |> RestApi.postAsync<_, FeeRefund> settings (Map.empty) options

    type ListOptions = {
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(id: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Id = id
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>You can see a list of the refunds belonging to a specific application fee. Note that the 10 most recent refunds are always available by default on the application fee object. If you need more than those 10, you can use this API method and the <code>limit</code> and <code>starting_after</code> parameters to page through additional refunds.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/application_fees/{options.Id}/refunds"
        |> RestApi.getAsync<FeeRefund list> settings qs

    type CreateOptions = {
        [<Config.Path>]Id: string
        ///A positive integer, in _cents (or local equivalent)_, representing how much of this fee to refund. Can refund only up to the remaining unrefunded amount of the fee.
        [<Config.Form>]Amount: int option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(id: string, ?amount: int, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Id = id
                Amount = amount
                Expand = expand
                Metadata = metadata
            }

    ///<p>Refunds an application fee that has previously been collected but not yet refunded.
    ///Funds will be refunded to the Stripe account from which the fee was originally collected.
    ///You can optionally refund only part of an application fee.
    ///You can do so multiple times, until the entire fee has been refunded.
    ///Once entirely refunded, an application fee can’t be refunded again.
    ///This method will raise an error when called on an already-refunded application fee,
    ///or when trying to refund more money than is left on an application fee.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/application_fees/{options.Id}/refunds"
        |> RestApi.postAsync<_, FeeRefund> settings (Map.empty) options

module AppsSecrets =

    type ListOptions = {
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///Specifies the scoping of the secret. Requests originating from UI extensions can only access account-scoped secrets or secrets scoped to their own user.
        [<Config.Query>]Scope: Map<string, string>
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(scope: Map<string, string>, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Scope = scope
                StartingAfter = startingAfter
            }

    ///<p>List all secrets stored on the given scope.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("scope", options.Scope |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/apps/secrets"
        |> RestApi.getAsync<AppsSecret list> settings qs

    type Create'ScopeType =
    | Account
    | User

    type Create'Scope = {
        ///The secret scope type.
        [<Config.Form>]Type: Create'ScopeType option
        ///The user ID. This field is required if `type` is set to `user`, and should not be provided if `type` is set to `account`.
        [<Config.Form>]User: string option
    }
    with
        static member New(?type': Create'ScopeType, ?user: string) =
            {
                Type = type'
                User = user
            }

    type CreateOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The Unix timestamp for the expiry time of the secret, after which the secret deletes.
        [<Config.Form>]ExpiresAt: DateTime option
        ///A name for the secret that's unique within the scope.
        [<Config.Form>]Name: string
        ///The plaintext secret value to be stored.
        [<Config.Form>]Payload: string
        ///Specifies the scoping of the secret. Requests originating from UI extensions can only access account-scoped secrets or secrets scoped to their own user.
        [<Config.Form>]Scope: Create'Scope
    }
    with
        static member New(name: string, payload: string, scope: Create'Scope, ?expand: string list, ?expiresAt: DateTime) =
            {
                Expand = expand
                ExpiresAt = expiresAt
                Name = name
                Payload = payload
                Scope = scope
            }

    ///<p>Create or replace a secret in the secret store.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/apps/secrets"
        |> RestApi.postAsync<_, AppsSecret> settings (Map.empty) options

module AppsSecretsDelete =

    type DeleteWhere'ScopeType =
    | Account
    | User

    type DeleteWhere'Scope = {
        ///The secret scope type.
        [<Config.Form>]Type: DeleteWhere'ScopeType option
        ///The user ID. This field is required if `type` is set to `user`, and should not be provided if `type` is set to `account`.
        [<Config.Form>]User: string option
    }
    with
        static member New(?type': DeleteWhere'ScopeType, ?user: string) =
            {
                Type = type'
                User = user
            }

    type DeleteWhereOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///A name for the secret that's unique within the scope.
        [<Config.Form>]Name: string
        ///Specifies the scoping of the secret. Requests originating from UI extensions can only access account-scoped secrets or secrets scoped to their own user.
        [<Config.Form>]Scope: DeleteWhere'Scope
    }
    with
        static member New(name: string, scope: DeleteWhere'Scope, ?expand: string list) =
            {
                Expand = expand
                Name = name
                Scope = scope
            }

    ///<p>Deletes a secret from the secret store by name and scope.</p>
    let DeleteWhere settings (options: DeleteWhereOptions) =
        $"/v1/apps/secrets/delete"
        |> RestApi.postAsync<_, AppsSecret> settings (Map.empty) options

module AppsSecretsFind =

    type FindOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A name for the secret that's unique within the scope.
        [<Config.Query>]Name: string
        ///Specifies the scoping of the secret. Requests originating from UI extensions can only access account-scoped secrets or secrets scoped to their own user.
        [<Config.Query>]Scope: Map<string, string>
    }
    with
        static member New(name: string, scope: Map<string, string>, ?expand: string list) =
            {
                Expand = expand
                Name = name
                Scope = scope
            }

    ///<p>Finds a secret in the secret store by name and scope.</p>
    let Find settings (options: FindOptions) =
        let qs = [("expand", options.Expand |> box); ("name", options.Name |> box); ("scope", options.Scope |> box)] |> Map.ofList
        $"/v1/apps/secrets/find"
        |> RestApi.getAsync<AppsSecret> settings qs
