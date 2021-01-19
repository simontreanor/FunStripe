// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open FunStripe
open FunStripe.AsyncResultCE
open FunStripe.StripeModel
open FunStripe.StripeRequest
open FunStripe.StripeService
open System

let testCustomer = "cus_HxEURwENT9MKb3"

let defaultCard =
    PostPaymentMethodsCardCardDetailsParams(
        cvc = "314",
        expMonth = 10,
        expYear = 2021,
        number = "4242424242424242"
    )

let getNewPaymentMethod () =
    let pms = PaymentMethodService(apiKey = Config.getStripeTestApiKey())
    asyncResult {
        let parameters = 
            PostPaymentMethodsParams(
                card = Choice1Of2 defaultCard,
                ``type`` = PostPaymentMethodsType.Card
            )
        return! pms.Create(parameters)
    }

let test() =
    let result =
        asyncResult {
            let! expected = getNewPaymentMethod()
            let! actual =
                let pms = PaymentMethodService(apiKey = Config.getStripeTestApiKey())
                let parameters =
                    // PostPaymentMethodsPaymentMethodAttachParams(
                    //     customer = testCustomer,
                    //     expand = [nameof(Customer)]
                    // )
                    PostPaymentMethodsPaymentMethodAttachParams(
                        customer = testCustomer
                    )
                pms.Attach(parameters, expected.Id)
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
