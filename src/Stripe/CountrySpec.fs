namespace Stripe.CountrySpec

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type CountrySpecVerificationFieldDetails =
    {
        /// Additional fields which are only required for some users.
        Additional: string list
        /// Fields which every account must eventually provide.
        Minimum: string list
    }

type CountrySpecVerificationFields =
    { Company: CountrySpecVerificationFieldDetails
      Individual: CountrySpecVerificationFieldDetails }

/// Stripe needs to collect certain pieces of information about each account
/// created. These requirements can differ depending on the account's country. The
/// Country Specs API makes these rules available to your integration.
/// You can also view the information from this API call as [an online
/// guide](/docs/connect/required-verification-information).
type CountrySpec =
    {
        /// The default currency for this country. This applies to both payment methods and bank accounts.
        DefaultCurrency: IsoTypes.IsoCurrencyCode
        /// Unique identifier for the object. Represented as the ISO country code for this country.
        Id: string
        /// Currencies that can be accepted in the specific country (for transfers).
        SupportedBankAccountCurrencies: Map<string, string list>
        /// Currencies that can be accepted in the specified country (for payments).
        SupportedPaymentCurrencies: string list
        /// Payment methods available in the specified country. You may need to enable some payment methods (e.g., [ACH](https://stripe.com/docs/ach)) on your account before they appear in this list. The `stripe` payment method refers to [charging through your platform](https://stripe.com/docs/connect/destination-charges).
        SupportedPaymentMethods: string list
        /// Countries that can accept transfers from the specified country.
        SupportedTransferCountries: string list
        VerificationFields: CountrySpecVerificationFields
    }

module CountrySpec =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "country_spec"

