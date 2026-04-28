#if INTERACTIVE
    #r "nuget: Microsoft.Extensions.Configuration";;
    #r "nuget: Microsoft.Extensions.Configuration.UserSecrets";;
#else
namespace FunStripe
#endif

#if !LITE
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.Configuration.UserSecrets
#endif
open System

module Config =

    //Parameter attributes for Stripe Requests
    type FormAttribute() = inherit Attribute()
    type PathAttribute() = inherit Attribute()
    type QueryAttribute() = inherit Attribute()

    /// Assembly-level attribute that records the Stripe API date-version the library was generated from
    [<AttributeUsage(AttributeTargets.Assembly)>]
    type StripeApiVersionAttribute(version: string) =
        inherit Attribute()
        /// The Stripe API date-version string (e.g. "2023-08-16")
        member _.Version = version

    /// The Stripe API date-version that this build of FunStripe was generated from.
    /// When updating, also update the literal in AssemblyInfo.fs and <StripeApiVersion>
    /// in both .fsproj files so all three stay in sync.
    let DefaultStripeApiVersion = "2023-08-16"

    /// Defines the base URL for the Stripe API
    let StripeBaseUrl = "https://api.stripe.com"

#if !LITE
    /// Looks up the `UserSecrets` store on the developer's computer and retrieves the Stripe API
    /// test key (see README for link to documentation). To set the Stripe API key in `UserSecrets`
    /// on your development computer, switch to the tests directory and use cmd: ```dotnet user-secrets init```
    /// then command ```dotnet user-secrets set "StripeSK-Test" "sk_test_..."```. Also change the `userSecretsId`
    /// value in the code to match the generated user-secrets ID.
    let StripeTestApiKey =
        let config = ConfigurationBuilder().AddUserSecrets("ee323121-66e7-40e6-acb1-d0914302cba3").Build()
        config.["StripeSK-Test"] |> string

    // If you don't want to use `UserSecrets` comment out the above three lines and uncomment the two
    // lines below, and specify your Stripe API key manually:
    // /// Manually set the default Stripe API key instead of using `UserSecrets`
    // let StripeTestApiKey = "sk_test_..."
#else
    let StripeTestApiKey = ""
#endif
