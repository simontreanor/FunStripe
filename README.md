# FunStripe

An F# 5.0 library to connect to the Stripe API, including code generators to update the model, requests and service.

## Installation

TBD

## Usage

Open the StripeModel, StripeRequest and StripeService modules.

Here's an example of how to create a new payment method:

```F#
let defaultCard =
    PostPaymentMethodsCardCardDetailsParams(
        cvc = "314",
        expMonth = 10,
        expYear = 2021,
        number = "4242424242424242"
    )

let createNewPaymentMethod () =
    let pms = PaymentMethodService(apiKey = Config.getStripeTestApiKey())
    asyncResult {
        let parameters = 
            PostPaymentMethodsParams(
                card = Choice1Of2 defaultCard,
                ``type`` = PostPaymentMethodsType.Card
            )
        return! pms.Create(parameters)
    }
```

The result value is an ```AsyncResult<PaymentMethod,ErrorResponse>```, giving you the requested object in case of success or a detailed error response if not.

The general format of API requests is ```<service instance>```.```<verb>```(```<body parameters>```,```<required inline parameters>```,```<optional inline parameters>```).

To instantiate the service instance you need to pass in your Stripe API key. To keep the keys out of source code, it is recommended to use [UserSecrets](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows) during development and web-server configuration settings in production.

## Code Generation

By cloning the source repository, as a developer you can use ```ModelBuilder.fs```, ```RequestBuilder.fs``` and ```ServiceBuilder.fs``` to generate the code in ```StripeModel.fs```, ```StripeRequest.fs``` and ```StripeService.fs``` respectively.

Using Visual Studio Code, you simply select all the text in each document and hit ```Alt + Enter``` to send the code to F# Interactive. This will overwrite the contents of the target modules.

The Stripe OpenAPI specification is stored locally as ```/res/spec3.sdk.json```. See the references below for the link to the latest online version.

By replacing the local copy with the latest one from online, you can regenerate the source code and build it to get the latest changes.

You could also customise how the source code is represented by editing the builder code files.

## References

[Stripe Documentation](https://stripe.com/docs)

[Developer Tools](https://stripe.com/docs/development)

[API Reference](https://stripe.com/docs/api)

[Official Stripe .NET Library](https://github.com/stripe/stripe-dotnet)

[Stripe OpenAPI Specification](https://raw.githubusercontent.com/stripe/openapi/master/openapi/spec3.sdk.json)

