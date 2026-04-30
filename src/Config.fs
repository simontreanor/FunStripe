namespace FunStripe

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
        /// The Stripe API date-version string (e.g. "2026-04-22.dahlia")
        member _.Version = version

    /// The Stripe API date-version that this build of FunStripe was generated from.
    /// When updating, also update the literal in AssemblyInfo.fs and <StripeApiVersion>
    /// in both .fsproj files so all three stay in sync.
    let DefaultStripeApiVersion = "2026-04-22.dahlia"

    /// Defines the base URL for the Stripe API
    let StripeBaseUrl = "https://api.stripe.com"

#if FABLE_COMPILER
    let StripeTestApiKey = ""
#else
    /// Reads the Stripe test API key from the STRIPE_TEST_API_KEY environment variable.
    /// Set this in your shell, a CI secret (e.g. GitHub Actions), or a local .env file.
    let StripeTestApiKey =
        Environment.GetEnvironmentVariable("STRIPE_TEST_API_KEY") |> Option.ofObj |> Option.defaultValue ""
#endif
