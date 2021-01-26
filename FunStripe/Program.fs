// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open FunStripe
open FunStripe.AsyncResultCE
open FunStripe.StripeModel
open FunStripe.StripeRequest
open FunStripe.StripeService
open System

let testCustomer = "cus_HxEURwENT9MKb3"

let defaultCard =
    PaymentMethods'CreateCardCardDetailsParams.Create(
        cvc = "314",
        expMonth = 10,
        expYear = 2021,
        number = "4242424242424242"
    )

let settings = RestApi.StripeApiSettings.Create(apiKey = Config.StripeTestApiKey)

let getNewPaymentMethod () =
    asyncResult {
        let parameters = 
            PaymentMethods'CreateOptions.Create(
                card = Choice1Of2 defaultCard,
                ``type`` = PaymentMethods'CreateType.Card
            )
        return! PaymentMethods.Create settings parameters
    }

let test() =
    let result =
        asyncResult {
            let! expected = getNewPaymentMethod()
            let! actual =
                let parameters =
                    // PaymentMethodsAttach'AttachOptions.Create(
                    //     customer = testCustomer,
                    //     expand = [nameof(Customer)]
                    // )
                    PaymentMethodsAttach'AttachOptions.Create(
                        customer = testCustomer
                    )
                let queryParameters = PaymentMethodsAttach.AttachOptions.Create(paymentMethod = expected.Id)
                PaymentMethodsAttach.Attach settings parameters queryParameters
            return expected, actual
        }
        |> Async.RunSynchronously
    match result with
    | Ok (exp, act) ->
        (exp = act) |> string
    | Error e ->
        sprintf "%A" e

[<EntryPoint>]
let main argv =
    let result = test ()
    printfn "Test result: %s" (result)
    0
