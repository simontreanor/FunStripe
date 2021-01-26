#if INTERACTIVE
    #r "nuget: Microsoft.Extensions.Configuration";;
    #r "nuget: Microsoft.Extensions.Configuration.UserSecrets";;
#else
namespace FunStripe
#endif

open Microsoft.Extensions.Configuration
open Microsoft.Extensions.Configuration.UserSecrets

module Config =

    /// Defines the base URL for the Stripe API
    let StripeBaseUrl = "https://api.stripe.com"

    /// Looks up the `UserSecrets` store on the developer's computer and retrieves the Stripe API test key (see README for link to documentation)
    let StripeTestApiKey =
        let config = ConfigurationBuilder().AddUserSecrets("170450ff-243d-4b38-9f56-c74254e1ca70").Build()
        config.["StripeSK-Test"] |> string
