namespace Stripe.PaymentMethodConfiguration

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod

/// PaymentMethodConfigurations control which payment methods are displayed to your customers when you don't explicitly specify payment method types. You can have multiple configurations with different sets of payment methods for different scenarios.
/// There are two types of PaymentMethodConfigurations. Which is used depends on the [charge type](https://docs.stripe.com/connect/charges):
/// **Direct** configurations apply to payments created on your account, including Connect destination charges, Connect separate charges and transfers, and payments not involving Connect.
/// **Child** configurations apply to payments created on your connected accounts using direct charges, and charges with the on_behalf_of parameter.
/// Child configurations have a `parent` that sets default values and controls which settings connected accounts may override. You can specify a parent ID at payment time, and Stripe will automatically resolve the connected account’s associated child configuration. Parent configurations are [managed in the dashboard](https://dashboard.stripe.com/settings/payment_methods/connected_accounts) and are not available in this API.
/// Related guides:
/// - [Payment Method Configurations API](https://docs.stripe.com/connect/payment-method-configurations)
/// - [Multiple configurations on dynamic payment methods](https://docs.stripe.com/payments/multiple-payment-method-configs)
/// - [Multiple configurations for your Connect accounts](https://docs.stripe.com/connect/multiple-payment-method-configurations)
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
type PaymentMethodConfiguration =
    {
        AcssDebit: PaymentMethodConfigResourcePaymentMethodProperties option
        /// Whether the configuration can be used for new payments.
        Active: bool
        Affirm: PaymentMethodConfigResourcePaymentMethodProperties option
        AfterpayClearpay: PaymentMethodConfigResourcePaymentMethodProperties option
        Alipay: PaymentMethodConfigResourcePaymentMethodProperties option
        Alma: PaymentMethodConfigResourcePaymentMethodProperties option
        AmazonPay: PaymentMethodConfigResourcePaymentMethodProperties option
        ApplePay: PaymentMethodConfigResourcePaymentMethodProperties option
        /// For child configs, the Connect application associated with the configuration.
        Application: string option
        AuBecsDebit: PaymentMethodConfigResourcePaymentMethodProperties option
        BacsDebit: PaymentMethodConfigResourcePaymentMethodProperties option
        Bancontact: PaymentMethodConfigResourcePaymentMethodProperties option
        Billie: PaymentMethodConfigResourcePaymentMethodProperties option
        Blik: PaymentMethodConfigResourcePaymentMethodProperties option
        Boleto: PaymentMethodConfigResourcePaymentMethodProperties option
        Card: PaymentMethodConfigResourcePaymentMethodProperties option
        CartesBancaires: PaymentMethodConfigResourcePaymentMethodProperties option
        Cashapp: PaymentMethodConfigResourcePaymentMethodProperties option
        Crypto: PaymentMethodConfigResourcePaymentMethodProperties option
        CustomerBalance: PaymentMethodConfigResourcePaymentMethodProperties option
        Eps: PaymentMethodConfigResourcePaymentMethodProperties option
        Fpx: PaymentMethodConfigResourcePaymentMethodProperties option
        Giropay: PaymentMethodConfigResourcePaymentMethodProperties option
        GooglePay: PaymentMethodConfigResourcePaymentMethodProperties option
        Grabpay: PaymentMethodConfigResourcePaymentMethodProperties option
        /// Unique identifier for the object.
        Id: string
        Ideal: PaymentMethodConfigResourcePaymentMethodProperties option
        /// The default configuration is used whenever a payment method configuration is not specified.
        IsDefault: bool
        Jcb: PaymentMethodConfigResourcePaymentMethodProperties option
        KakaoPay: PaymentMethodConfigResourcePaymentMethodProperties option
        Klarna: PaymentMethodConfigResourcePaymentMethodProperties option
        Konbini: PaymentMethodConfigResourcePaymentMethodProperties option
        KrCard: PaymentMethodConfigResourcePaymentMethodProperties option
        Link: PaymentMethodConfigResourcePaymentMethodProperties option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        MbWay: PaymentMethodConfigResourcePaymentMethodProperties option
        Mobilepay: PaymentMethodConfigResourcePaymentMethodProperties option
        Multibanco: PaymentMethodConfigResourcePaymentMethodProperties option
        /// The configuration's name.
        Name: string
        NaverPay: PaymentMethodConfigResourcePaymentMethodProperties option
        NzBankAccount: PaymentMethodConfigResourcePaymentMethodProperties option
        Oxxo: PaymentMethodConfigResourcePaymentMethodProperties option
        [<JsonPropertyName("p24")>]
        P24: PaymentMethodConfigResourcePaymentMethodProperties option
        /// For child configs, the configuration's parent configuration.
        Parent: string option
        PayByBank: PaymentMethodConfigResourcePaymentMethodProperties option
        Payco: PaymentMethodConfigResourcePaymentMethodProperties option
        Paynow: PaymentMethodConfigResourcePaymentMethodProperties option
        Paypal: PaymentMethodConfigResourcePaymentMethodProperties option
        Payto: PaymentMethodConfigResourcePaymentMethodProperties option
        Pix: PaymentMethodConfigResourcePaymentMethodProperties option
        Promptpay: PaymentMethodConfigResourcePaymentMethodProperties option
        RevolutPay: PaymentMethodConfigResourcePaymentMethodProperties option
        SamsungPay: PaymentMethodConfigResourcePaymentMethodProperties option
        Satispay: PaymentMethodConfigResourcePaymentMethodProperties option
        SepaDebit: PaymentMethodConfigResourcePaymentMethodProperties option
        Sofort: PaymentMethodConfigResourcePaymentMethodProperties option
        Sunbit: PaymentMethodConfigResourcePaymentMethodProperties option
        Swish: PaymentMethodConfigResourcePaymentMethodProperties option
        Twint: PaymentMethodConfigResourcePaymentMethodProperties option
        Upi: PaymentMethodConfigResourcePaymentMethodProperties option
        UsBankAccount: PaymentMethodConfigResourcePaymentMethodProperties option
        WechatPay: PaymentMethodConfigResourcePaymentMethodProperties option
        Zip: PaymentMethodConfigResourcePaymentMethodProperties option
    }

type PaymentMethodConfiguration with
    static member New(active: bool, application: string option, id: string, isDefault: bool, livemode: bool, name: string, parent: string option, ?acssDebit: PaymentMethodConfigResourcePaymentMethodProperties, ?affirm: PaymentMethodConfigResourcePaymentMethodProperties, ?afterpayClearpay: PaymentMethodConfigResourcePaymentMethodProperties, ?alipay: PaymentMethodConfigResourcePaymentMethodProperties, ?alma: PaymentMethodConfigResourcePaymentMethodProperties, ?amazonPay: PaymentMethodConfigResourcePaymentMethodProperties, ?applePay: PaymentMethodConfigResourcePaymentMethodProperties, ?auBecsDebit: PaymentMethodConfigResourcePaymentMethodProperties, ?bacsDebit: PaymentMethodConfigResourcePaymentMethodProperties, ?bancontact: PaymentMethodConfigResourcePaymentMethodProperties, ?billie: PaymentMethodConfigResourcePaymentMethodProperties, ?blik: PaymentMethodConfigResourcePaymentMethodProperties, ?boleto: PaymentMethodConfigResourcePaymentMethodProperties, ?card: PaymentMethodConfigResourcePaymentMethodProperties, ?cartesBancaires: PaymentMethodConfigResourcePaymentMethodProperties, ?cashapp: PaymentMethodConfigResourcePaymentMethodProperties, ?crypto: PaymentMethodConfigResourcePaymentMethodProperties, ?customerBalance: PaymentMethodConfigResourcePaymentMethodProperties, ?eps: PaymentMethodConfigResourcePaymentMethodProperties, ?fpx: PaymentMethodConfigResourcePaymentMethodProperties, ?giropay: PaymentMethodConfigResourcePaymentMethodProperties, ?googlePay: PaymentMethodConfigResourcePaymentMethodProperties, ?grabpay: PaymentMethodConfigResourcePaymentMethodProperties, ?ideal: PaymentMethodConfigResourcePaymentMethodProperties, ?jcb: PaymentMethodConfigResourcePaymentMethodProperties, ?kakaoPay: PaymentMethodConfigResourcePaymentMethodProperties, ?klarna: PaymentMethodConfigResourcePaymentMethodProperties, ?konbini: PaymentMethodConfigResourcePaymentMethodProperties, ?krCard: PaymentMethodConfigResourcePaymentMethodProperties, ?link: PaymentMethodConfigResourcePaymentMethodProperties, ?mbWay: PaymentMethodConfigResourcePaymentMethodProperties, ?mobilepay: PaymentMethodConfigResourcePaymentMethodProperties, ?multibanco: PaymentMethodConfigResourcePaymentMethodProperties, ?naverPay: PaymentMethodConfigResourcePaymentMethodProperties, ?nzBankAccount: PaymentMethodConfigResourcePaymentMethodProperties, ?oxxo: PaymentMethodConfigResourcePaymentMethodProperties, ?p24: PaymentMethodConfigResourcePaymentMethodProperties, ?payByBank: PaymentMethodConfigResourcePaymentMethodProperties, ?payco: PaymentMethodConfigResourcePaymentMethodProperties, ?paynow: PaymentMethodConfigResourcePaymentMethodProperties, ?paypal: PaymentMethodConfigResourcePaymentMethodProperties, ?payto: PaymentMethodConfigResourcePaymentMethodProperties, ?pix: PaymentMethodConfigResourcePaymentMethodProperties, ?promptpay: PaymentMethodConfigResourcePaymentMethodProperties, ?revolutPay: PaymentMethodConfigResourcePaymentMethodProperties, ?samsungPay: PaymentMethodConfigResourcePaymentMethodProperties, ?satispay: PaymentMethodConfigResourcePaymentMethodProperties, ?sepaDebit: PaymentMethodConfigResourcePaymentMethodProperties, ?sofort: PaymentMethodConfigResourcePaymentMethodProperties, ?sunbit: PaymentMethodConfigResourcePaymentMethodProperties, ?swish: PaymentMethodConfigResourcePaymentMethodProperties, ?twint: PaymentMethodConfigResourcePaymentMethodProperties, ?upi: PaymentMethodConfigResourcePaymentMethodProperties, ?usBankAccount: PaymentMethodConfigResourcePaymentMethodProperties, ?wechatPay: PaymentMethodConfigResourcePaymentMethodProperties, ?zip: PaymentMethodConfigResourcePaymentMethodProperties) =
        {
            Active = active
            Application = application
            Id = id
            IsDefault = isDefault
            Livemode = livemode
            Name = name
            Parent = parent
            AcssDebit = acssDebit
            Affirm = affirm
            AfterpayClearpay = afterpayClearpay
            Alipay = alipay
            Alma = alma
            AmazonPay = amazonPay
            ApplePay = applePay
            AuBecsDebit = auBecsDebit
            BacsDebit = bacsDebit
            Bancontact = bancontact
            Billie = billie
            Blik = blik
            Boleto = boleto
            Card = card
            CartesBancaires = cartesBancaires
            Cashapp = cashapp
            Crypto = crypto
            CustomerBalance = customerBalance
            Eps = eps
            Fpx = fpx
            Giropay = giropay
            GooglePay = googlePay
            Grabpay = grabpay
            Ideal = ideal
            Jcb = jcb
            KakaoPay = kakaoPay
            Klarna = klarna
            Konbini = konbini
            KrCard = krCard
            Link = link
            MbWay = mbWay
            Mobilepay = mobilepay
            Multibanco = multibanco
            NaverPay = naverPay
            NzBankAccount = nzBankAccount
            Oxxo = oxxo
            P24 = p24
            PayByBank = payByBank
            Payco = payco
            Paynow = paynow
            Paypal = paypal
            Payto = payto
            Pix = pix
            Promptpay = promptpay
            RevolutPay = revolutPay
            SamsungPay = samsungPay
            Satispay = satispay
            SepaDebit = sepaDebit
            Sofort = sofort
            Sunbit = sunbit
            Swish = swish
            Twint = twint
            Upi = upi
            UsBankAccount = usBankAccount
            WechatPay = wechatPay
            Zip = zip
        }

module PaymentMethodConfiguration =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "payment_method_configuration"

