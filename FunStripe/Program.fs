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

let settings = RestApi.StripeApiSettings.Create(apiKey = Config.getStripeTestApiKey())

let getNewPaymentMethod () =
    asyncResult {
        let parameters = 
            PostPaymentMethodsParams(
                card = Choice1Of2 defaultCard,
                ``type`` = PostPaymentMethodsType.Card
            )
        return! PaymentMethodsService.Create settings parameters
    }

let test() =
    let result =
        asyncResult {
            let! expected = getNewPaymentMethod()
            let! actual =
                let parameters =
                    // PostPaymentMethodsPaymentMethodAttachParams(
                    //     customer = testCustomer,
                    //     expand = [nameof(Customer)]
                    // )
                    PostPaymentMethodsPaymentMethodAttachParams(
                        customer = testCustomer
                    )
                let queryParameters = { PaymentMethodsAttachService.AttachQueryParams.PaymentMethod = expected.Id }
                PaymentMethodsAttachService.Attach settings parameters queryParameters
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
