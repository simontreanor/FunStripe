#if INTERACTIVE
    #r "nuget: Microsoft.Extensions.Configuration";;
    #r "nuget: Microsoft.Extensions.Configuration.UserSecrets";;
#else
namespace FunStripe
#endif

open Microsoft.Extensions.Configuration
open Microsoft.Extensions.Configuration.UserSecrets
open System

module Config =

    //Parameter attributes for Stripe Requests
    type FormAttribute() = inherit Attribute()
    type PathAttribute() = inherit Attribute()
    type QueryAttribute() = inherit Attribute()

    /// Defines the base URL for the Stripe API
    let StripeBaseUrl = "https://api.stripe.com"

    /// Looks up the `UserSecrets` store on the developer's computer and retrieves the Stripe API
    /// test key (see README for link to documentation). To set the Stripe API key in `UserSecrets`
    /// on your development computer, switch to the tests directory and use cmd: ```dotnet user-secrets init```
    /// then command ```dotnet user-secrets set "StripeSK-Test" "sk_test_..."```. Also change the `userSecretsId`
    /// value in the code to match the generated user-secrets ID.
    let StripeTestApiKey =
        let config = ConfigurationBuilder().AddUserSecrets("170450ff-243d-4b38-9f56-c74254e1ca70").Build()
        config.["StripeSK-Test"] |> string

    // If you don't want to use `UserSecrets` comment out the above three lines and uncomment the two
    // lines below, and specify your Stripe API key manually:
    // /// Manually set the default Stripe API key instead of using `UserSecrets`
    // let StripeTestApiKey = "sk_test_..."
