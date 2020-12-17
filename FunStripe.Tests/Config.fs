#if INTERACTIVE
    #r "nuget: Microsoft.Extensions.Configuration";;
    #r "nuget: Microsoft.Extensions.Configuration.UserSecrets";;
#else
namespace FunStripe
#endif

open Microsoft.Extensions.Configuration
open Microsoft.Extensions.Configuration.UserSecrets

module Config =

    let GetStripeTestApiKey =
        let config = ConfigurationBuilder().AddUserSecrets("170450ff-243d-4b38-9f56-c74254e1ca70").Build()
        config.["StripeSK-Test"] |> string
