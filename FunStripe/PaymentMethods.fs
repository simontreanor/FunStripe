namespace FunStripe

open Cards

module PaymentMethods =

    type PaymentMethod = {
        Id: string
        BillingDetails: Cards.BillingDetails
        Customer: string option
        Metadata: Map<string, string>
        Type: Type
        Card: Card option
        Object: string
        Created: int
        Livemode: bool
    }

    and Type =
        | Alipay
        | AuBecsDebit
        | BacsDebit
        | Bancontact
        | Card
        | Eps
        | Fpx
        | Giropay
        | Ideal
        | Oxxo
        | P24
        | SepaDebit
        | Sofort

    type CreateParams = {
        Type: Type
        BillingDetails: Cards.BillingDetails option
        Metadata: Map<string, string>option
        Card: CreateCard option
    }

    and CreateCard = {
        ExpMonth: int
        ExpYear: int
        Number: int64
        Cvc: int
    }

    type UpdateParams(``type``: Type, ?billingDetails: Cards.BillingDetails, ?metadata: Map<string, string>, ?card: UpdateCard) =
        member _.Type = ``type``
        member _.BillingDetails = billingDetails
        member _.Metadata = metadata
        member _.Card = card

    and UpdateCard = {
        ExpMonth: int
        ExpYear: int
    }

    type ListParams(customer: string, ``type``: Type, ?endingBefore: string, ?limit: int, ?startingAfter: string ) =
        member _.Customer = customer
        member _.Type = ``type``
        member _.EndingBefore = endingBefore 
        member _.Limit = limit
        member _.StartingAfter = startingAfter

    type PaymentMethodService() =
        member _.Endpoint = "/v1/payment_methods"
        member _.RestApiClient = RestApi.RestApiClient()

        member this.Get (id: string) =
            this.Endpoint + $@"/:{id}"
            |> this.RestApiClient.GetAsync<PaymentMethod>

        member this.Create (``params``: CreateParams) =
            this.Endpoint
            |> this.RestApiClient.PostAsync<_, PaymentMethod> ``params``

        member this.Update (id: string) (``params``: UpdateParams) =
            this.Endpoint + $@"/:{id}"
            |> this.RestApiClient.PostAsync<_, PaymentMethod> ``params``

        member this.List (``params``: ListParams) =
            this.Endpoint
            |> this.RestApiClient.GetWithAsync<_, PaymentMethod list> ``params``
