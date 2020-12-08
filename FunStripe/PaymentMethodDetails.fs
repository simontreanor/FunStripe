namespace FunStripe

open FSharp.Json

module PaymentMethodDetails =

    type PaymentMethodDetail = {
        /// The type of transaction-specific details of the payment method used in the payment.
        /// An additional hash is included on <c>payment_method_details</c> with a name matching this value.
        /// It contains information specific to the payment method.
        Type: string

        AchCreditTransfer: AchCreditTransfer
        AchDebit: AchDebit
        Alipay: Alipay
        AuBecsDebit: AuBecsDebit
        BacsDebit: BacsDebit
        Bancontact: Bancontact
        Card: Cards.Card
        CardPresent: CardPresent
        Eps: Eps
        Fpx: Fpx
        Giropay: Giropay
        Ideal: Ideal
        InteracPresent: InteracPresent
        Klarna: Klarna
        Multibanco: Multibanco
        Oxxo: Oxxo
        P24: P24
        SepaDebit: SepaDebit
        StripeAccount: StripeAccount
        Wechat: Wechat
    }

    and Type =
        | AchCreditTransfer
        | AchDebit
        | AcssDebit
        | Alipay
        | AuBecsDebit
        | BacsDebit
        | Bancontact
        | Card
        | CardPresent
        | Eps
        | Fpx
        | Giropay
        | Ideal
        | InteracPresent
        | Klarna
        | Multibanco
        | Oxxo
        | P24
        | SepaDebit
        | StripeAccount
        | Wechat

    and AchCreditTransfer = {
        AccountNumber: string
        BankName: string
        RoutingNumber: string
        SwiftCode: string
    }

    and AchDebit = {
        AccountHolderType: string
        BankName: string
        Country: string
        Fingerprint: string
        [<JsonField("last4")>] Last4: string
        RoutingNumber: string
    }

    and Alipay = {
        Fingerprint: string
        TransactionId: string
    }

    and AuBecsDebit = {
        BsbNumber: string
        Fingerprint: string
        [<JsonField("last4")>] Last4: string
        Mandate: string
    }

    and BacsDebit = {
        Fingerprint: string
        Last4: string
        Mandate: string
        SortCode: string
    }

    and Bancontact = {
        BankCode: string
        BankName: string
        Bic: string
        GeneratedSepaDebit: string
        GeneratedSepaDebitMandate: string
        [<JsonField("iban_last4")>] IbanLast4: string
        PreferredLanguage: string
        VerifiedName: string
    }

    and CardPresent = {

    }

    and Eps = {
        VerifiedName: string
    }

    and Fpx = {
        Bank: FpxBank
    }

    and FpxBank =
        | AffinBank
        | AllianceBank
        | Ambank
        | BankIslam
        | BankMuamalat
        | BankRakyat
        | Bsn
        | Cimb
        | HongLeongBank
        | Hsbc
        | Kfh
        | Maybank2u
        | Ocbc
        | PublicBank
        | Rhb
        | StandardChartered
        | Uob
        | DeutscheBank
        | Maybank2e
        | PbEnterprise

    and Giropay = {

    }

    and Ideal = {

    }

    and InteracPresent = {

    }

    and Klarna = {

    }

    and Multibanco = {

    }

    and Oxxo = {

    }

    and P24 = {

    }

    and SepaDebit = {

    }

    and StripeAccount = {

    }

    and Wechat = {

    }
