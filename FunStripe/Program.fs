open FunStripe
open FunStripe.AsyncResultCE
open FunStripe.StripeError
open FunStripe.StripeModel
open FunStripe.StripeRequest
open System

let testCustomer = "cus_HxEURwENT9MKb3"

let defaultCard =
    PaymentMethods.Create'CardCardDetailsParams.New(
        cvc = "314",
        expMonth = 10,
        expYear = 2021,
        number = "4242424242424242"
    )

let settings = RestApi.StripeApiSettings.New(apiKey = Config.StripeTestApiKey)

let simpleError message =
    async { return Error { ErrorResponse.StripeError = ErrorObject.New(message = message) } }

let getNewPaymentMethod () =
    asyncResult {
        let options = 
            PaymentMethods.CreateOptions.New(
                card = Choice1Of2 defaultCard,
                type' = PaymentMethods.Create'Type.Card
            )
        return! PaymentMethods.Create settings options
    }

let test() =
    let (customerId, paymentMethodId) = ("cus_EoM0QeSF2VsaYl", "pm_1IG5N7GXSUku3vEhV7Zw2jaQ")
    let result =
        asyncResult {
            //Stripe docs recommend listing the customer's payment methods rather than using the paymentMethodId directly, but don't say why
            let! paymentMethods =
                PaymentMethods.ListOptions.New(
                    customer = customerId,
                    type' = "card"
                )
                |> PaymentMethods.List settings
            let paymentMethod =
                paymentMethods
                |> List.tryFind(fun pm -> pm.Id = paymentMethodId)
            match paymentMethod with
            | Some pm ->
                return!
                    PaymentIntents.CreateOptions.New (
                        amount = 12500,
                        confirm = true,
                        currency = "GBP",
                        customer = customerId,
                        offSession = Choice2Of2 PaymentIntents.Create'OffSession.Recurring,
                        paymentMethod = pm.Id,
                        setupFutureUsage = PaymentIntents.Create'SetupFutureUsage.OffSession
                    )
                    |> PaymentIntents.Create settings
            | None ->
                return! simpleError "No matching payment method found"
        }
        |> Async.RunSynchronously
    match result with
    | Ok pi ->
        sprintf "%A" pi
    | Error e ->
        sprintf "%A" e

[<EntryPoint>]
let main argv =
    let result = test ()
    printfn "Test result: %s" (result)
    0
