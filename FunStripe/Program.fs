open FunStripe
open FunStripe.AsyncResultCE
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
    let result =
        asyncResult {
            let! expected = getNewPaymentMethod()
            let! actual =
                let options =
                    // PaymentMethodsAttach'AttachOptions.New(
                    //     customer = testCustomer,
                    //     expand = [nameof(Customer)]
                    // )
                    PaymentMethodsAttach.AttachOptions.New(
                        customer = testCustomer,
                        paymentMethod = expected.Id
                    )
                PaymentMethodsAttach.Attach settings options
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
