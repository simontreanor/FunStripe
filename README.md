# FunStripe

An F# 5.0 library to connect to the Stripe API, including code generators to update the model and requests.

## Installation

Get the latest version from [Nuget](https://www.nuget.org/packages/FunStripe/)

## Usage

Open the StripeModel and StripeRequest modules.

Here's an example of how to create a new payment method:

```F#
let settings = RestApi.StripeApiSettings.New(apiKey = Config.StripeTestApiKey)

let defaultCard =
    PaymentMethods.CreateCardCardDetailsParams.New(
        cvc = "314",
        expMonth = 10,
        expYear = 2021,
        number = "4242424242424242"
    )

let getNewPaymentMethod () =
    asyncResult {
        return! 
            PaymentMethods.CreateOptions.New(
                card = Choice1Of2 defaultCard,
                type' = PaymentMethods.CreateType.Card
            )
            |> PaymentMethods.Create settings
    }
```

The result value is an `AsyncResult<PaymentMethod,ErrorResponse>`, giving you the requested object in case of success or a detailed error response if not.

The general format of API requests is `<module>`.`<method>` `settings` `options`.

To instantiate the `settings` you need to pass in your Stripe API key. Having local rather than global settings allows you to use different keys for different Stripe accounts if you need to.

If you don't specify the API key in the settings record, it will look for a default test API key to use, and to keep the keys out of source code, it uses [UserSecrets](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows). It is recommended to use user settings during development and web-server configuration settings in production, but if your source code will not be made public you can simply specify the API key as a string, at least for testing purposes. `Config.fs` contains some notes to help you.

The `options` can be provided using record notation or if there are many uninitialised properties you can use the static `New` method to instantiate the record more effiently.

## Code Generation

By cloning the source repository, as a developer you can use `ModelBuilder.fs` and `RequestBuilder.fs` to generate the code in `StripeModel.fs` and `StripeRequest.fs` respectively.

Using Visual Studio Code, you simply select all the text in each document and hit `Alt + Enter` to send the code to F# Interactive. This will overwrite the contents of the target modules.

The Stripe OpenAPI specification is stored locally as `/res/spec3.sdk.json`. See the references below for the link to the latest online version.

By replacing the local copy with the latest one from online, you can regenerate the source code and build it to get the latest changes.

You could also customise how the source code is represented by editing the builder code files.

## References

[Stripe Documentation](https://stripe.com/docs)

[Developer Tools](https://stripe.com/docs/development)

[API Reference](https://stripe.com/docs/api)

[Official Stripe .NET Library](https://github.com/stripe/stripe-dotnet)

[Stripe OpenAPI Specification](https://raw.githubusercontent.com/stripe/openapi/master/openapi/spec3.sdk.json)

