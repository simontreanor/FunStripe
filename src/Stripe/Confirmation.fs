namespace Stripe.Confirmation

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Address
open Stripe.Payment

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type ConfirmationTokenSetupFutureUsage =
    | OffSession
    | OnSession

/// This hash contains details about the online acceptance.
type ConfirmationTokensResourceMandateDataResourceCustomerAcceptanceResourceOnline =
    {
        /// The IP address from which the Mandate was accepted by the customer.
        IpAddress: string option
        /// The user agent of the browser from which the Mandate was accepted by the customer.
        UserAgent: string option
    }

module ConfirmationTokensResourceMandateDataResourceCustomerAcceptanceResourceOnline =
    let create
        (
            ipAddress: string option,
            userAgent: string option
        ) : ConfirmationTokensResourceMandateDataResourceCustomerAcceptanceResourceOnline
        =
        {
          IpAddress = ipAddress
          UserAgent = userAgent
        }

/// This hash contains details about the customer acceptance of the Mandate.
type ConfirmationTokensResourceMandateDataResourceCustomerAcceptance =
    {
        /// If this is a Mandate accepted online, this hash contains details about the online acceptance.
        Online: ConfirmationTokensResourceMandateDataResourceCustomerAcceptanceResourceOnline option
        /// The type of customer acceptance information included with the Mandate.
        Type: string
    }

module ConfirmationTokensResourceMandateDataResourceCustomerAcceptance =
    let create
        (
            online: ConfirmationTokensResourceMandateDataResourceCustomerAcceptanceResourceOnline option,
            ``type``: string
        ) : ConfirmationTokensResourceMandateDataResourceCustomerAcceptance
        =
        {
          Online = online
          Type = ``type``
        }

/// Data used for generating a Mandate.
type ConfirmationTokensResourceMandateData =
    { CustomerAcceptance: ConfirmationTokensResourceMandateDataResourceCustomerAcceptance }

module ConfirmationTokensResourceMandateData =
    let create
        (
            customerAcceptance: ConfirmationTokensResourceMandateDataResourceCustomerAcceptance
        ) : ConfirmationTokensResourceMandateData
        =
        {
          CustomerAcceptance = customerAcceptance
        }

/// Installment configuration for payments.
type ConfirmationTokensResourcePaymentMethodOptionsResourceCardResourceInstallment =
    { Plan: PaymentMethodDetailsCardInstallmentsPlan option }

module ConfirmationTokensResourcePaymentMethodOptionsResourceCardResourceInstallment =
    let create
        (
            plan: PaymentMethodDetailsCardInstallmentsPlan option
        ) : ConfirmationTokensResourcePaymentMethodOptionsResourceCardResourceInstallment
        =
        {
          Plan = plan
        }

/// This hash contains the card payment method options.
type ConfirmationTokensResourcePaymentMethodOptionsResourceCard =
    {
        /// The `cvc_update` Token collected from the Payment Element.
        CvcToken: string option
        Installments: ConfirmationTokensResourcePaymentMethodOptionsResourceCardResourceInstallment option
    }

module ConfirmationTokensResourcePaymentMethodOptionsResourceCard =
    let create
        (
            cvcToken: string option,
            installments: ConfirmationTokensResourcePaymentMethodOptionsResourceCardResourceInstallment option
        ) : ConfirmationTokensResourcePaymentMethodOptionsResourceCard
        =
        {
          CvcToken = cvcToken
          Installments = installments
        }

/// Payment-method-specific configuration
type ConfirmationTokensResourcePaymentMethodOptions =
    {
        /// This hash contains the card payment method options.
        Card: ConfirmationTokensResourcePaymentMethodOptionsResourceCard option
    }

module ConfirmationTokensResourcePaymentMethodOptions =
    let create
        (
            card: ConfirmationTokensResourcePaymentMethodOptionsResourceCard option
        ) : ConfirmationTokensResourcePaymentMethodOptions
        =
        {
          Card = card
        }

[<Struct>]
type ConfirmationTokensResourcePaymentMethodPreviewAllowRedisplay =
    | Always
    | Limited
    | Unspecified

type ConfirmationTokensResourcePaymentMethodPreviewCustomer'AnyOf =
    | String of string
    | Customer of Customer

type ConfirmationTokensResourcePaymentMethodPreviewType =
    | AcssDebit
    | Affirm
    | AfterpayClearpay
    | Alipay
    | Alma
    | AmazonPay
    | AuBecsDebit
    | BacsDebit
    | Bancontact
    | Billie
    | Blik
    | Boleto
    | Card
    | CardPresent
    | Cashapp
    | Crypto
    | Custom
    | CustomerBalance
    | Eps
    | Fpx
    | Giropay
    | Grabpay
    | Ideal
    | InteracPresent
    | KakaoPay
    | Klarna
    | Konbini
    | KrCard
    | Link
    | MbWay
    | Mobilepay
    | Multibanco
    | NaverPay
    | NzBankAccount
    | Oxxo
    | P24
    | PayByBank
    | Payco
    | Paynow
    | Paypal
    | Payto
    | Pix
    | Promptpay
    | RevolutPay
    | SamsungPay
    | Satispay
    | SepaDebit
    | Sofort
    | Sunbit
    | Swish
    | Twint
    | Upi
    | UsBankAccount
    | WechatPay
    | Zip

/// Details of the PaymentMethod collected by Payment Element
type ConfirmationTokensResourcePaymentMethodPreview =
    {
        AcssDebit: PaymentMethodAcssDebit option
        Affirm: PaymentMethodAffirm option
        AfterpayClearpay: PaymentMethodAfterpayClearpay option
        Alipay: PaymentFlowsPrivatePaymentMethodsAlipay option
        /// This field indicates whether this payment method can be shown again to its customer in a checkout flow. Stripe products such as Checkout and Elements use this field to determine whether a payment method can be shown as a saved payment method in a checkout flow. The field defaults to “unspecified”.
        AllowRedisplay: ConfirmationTokensResourcePaymentMethodPreviewAllowRedisplay option
        Alma: PaymentMethodAlma option
        AmazonPay: PaymentMethodAmazonPay option
        AuBecsDebit: PaymentMethodAuBecsDebit option
        BacsDebit: PaymentMethodBacsDebit option
        Bancontact: PaymentMethodBancontact option
        Billie: PaymentMethodBillie option
        BillingDetails: BillingDetails
        Blik: PaymentMethodBlik option
        Boleto: PaymentMethodBoleto option
        Card: PaymentMethodCard option
        CardPresent: PaymentMethodCardPresent option
        Cashapp: PaymentMethodCashapp option
        Crypto: PaymentMethodCrypto option
        /// The ID of the Customer to which this PaymentMethod is saved. This will not be set when the PaymentMethod has not been saved to a Customer.
        Customer: ConfirmationTokensResourcePaymentMethodPreviewCustomer'AnyOf option
        CustomerAccount: string option
        CustomerBalance: PaymentMethodCustomerBalance option
        Eps: PaymentMethodEps option
        Fpx: PaymentMethodFpx option
        Giropay: PaymentMethodGiropay option
        Grabpay: PaymentMethodGrabpay option
        Ideal: PaymentMethodIdeal option
        InteracPresent: PaymentMethodInteracPresent option
        KakaoPay: PaymentMethodKakaoPay option
        Klarna: PaymentMethodKlarna option
        Konbini: PaymentMethodKonbini option
        KrCard: PaymentMethodKrCard option
        Link: PaymentMethodLink option
        MbWay: PaymentMethodMbWay option
        Mobilepay: PaymentMethodMobilepay option
        Multibanco: PaymentMethodMultibanco option
        NaverPay: PaymentMethodNaverPay option
        NzBankAccount: PaymentMethodNzBankAccount option
        Oxxo: PaymentMethodOxxo option
        [<JsonPropertyName("p24")>]
        P24: PaymentMethodP24 option
        PayByBank: PaymentMethodPayByBank option
        Payco: PaymentMethodPayco option
        Paynow: PaymentMethodPaynow option
        Paypal: PaymentMethodPaypal option
        Payto: PaymentMethodPayto option
        Pix: PaymentMethodPix option
        Promptpay: PaymentMethodPromptpay option
        RevolutPay: PaymentMethodRevolutPay option
        SamsungPay: PaymentMethodSamsungPay option
        Satispay: PaymentMethodSatispay option
        SepaDebit: PaymentMethodSepaDebit option
        Sofort: PaymentMethodSofort option
        Sunbit: PaymentMethodSunbit option
        Swish: PaymentMethodSwish option
        Twint: PaymentMethodTwint option
        /// The type of the PaymentMethod. An additional hash is included on the PaymentMethod with a name matching this value. It contains additional information specific to the PaymentMethod type.
        Type: ConfirmationTokensResourcePaymentMethodPreviewType
        Upi: PaymentMethodUpi option
        UsBankAccount: PaymentMethodUsBankAccount option
        WechatPay: PaymentMethodWechatPay option
        Zip: PaymentMethodZip option
    }

module ConfirmationTokensResourcePaymentMethodPreview =
    let create
        (
            billingDetails: BillingDetails,
            customer: ConfirmationTokensResourcePaymentMethodPreviewCustomer'AnyOf option,
            customerAccount: string option,
            ``type``: ConfirmationTokensResourcePaymentMethodPreviewType,
            acssDebit: PaymentMethodAcssDebit option,
            affirm: PaymentMethodAffirm option,
            afterpayClearpay: PaymentMethodAfterpayClearpay option,
            alipay: PaymentFlowsPrivatePaymentMethodsAlipay option,
            allowRedisplay: ConfirmationTokensResourcePaymentMethodPreviewAllowRedisplay option,
            alma: PaymentMethodAlma option,
            amazonPay: PaymentMethodAmazonPay option,
            auBecsDebit: PaymentMethodAuBecsDebit option,
            bacsDebit: PaymentMethodBacsDebit option,
            bancontact: PaymentMethodBancontact option,
            billie: PaymentMethodBillie option,
            blik: PaymentMethodBlik option,
            boleto: PaymentMethodBoleto option,
            card: PaymentMethodCard option,
            cardPresent: PaymentMethodCardPresent option,
            cashapp: PaymentMethodCashapp option,
            crypto: PaymentMethodCrypto option,
            customerBalance: PaymentMethodCustomerBalance option,
            eps: PaymentMethodEps option,
            fpx: PaymentMethodFpx option,
            giropay: PaymentMethodGiropay option,
            grabpay: PaymentMethodGrabpay option,
            ideal: PaymentMethodIdeal option,
            interacPresent: PaymentMethodInteracPresent option,
            kakaoPay: PaymentMethodKakaoPay option,
            klarna: PaymentMethodKlarna option,
            konbini: PaymentMethodKonbini option,
            krCard: PaymentMethodKrCard option,
            link: PaymentMethodLink option,
            mbWay: PaymentMethodMbWay option,
            mobilepay: PaymentMethodMobilepay option,
            multibanco: PaymentMethodMultibanco option,
            naverPay: PaymentMethodNaverPay option,
            nzBankAccount: PaymentMethodNzBankAccount option,
            oxxo: PaymentMethodOxxo option,
            p24: PaymentMethodP24 option,
            payByBank: PaymentMethodPayByBank option,
            payco: PaymentMethodPayco option,
            paynow: PaymentMethodPaynow option,
            paypal: PaymentMethodPaypal option,
            payto: PaymentMethodPayto option,
            pix: PaymentMethodPix option,
            promptpay: PaymentMethodPromptpay option,
            revolutPay: PaymentMethodRevolutPay option,
            samsungPay: PaymentMethodSamsungPay option,
            satispay: PaymentMethodSatispay option,
            sepaDebit: PaymentMethodSepaDebit option,
            sofort: PaymentMethodSofort option,
            sunbit: PaymentMethodSunbit option,
            swish: PaymentMethodSwish option,
            twint: PaymentMethodTwint option,
            upi: PaymentMethodUpi option,
            usBankAccount: PaymentMethodUsBankAccount option,
            wechatPay: PaymentMethodWechatPay option,
            zip: PaymentMethodZip option
        ) : ConfirmationTokensResourcePaymentMethodPreview
        =
        {
          BillingDetails = billingDetails
          Customer = customer
          CustomerAccount = customerAccount
          Type = ``type``
          AcssDebit = acssDebit
          Affirm = affirm
          AfterpayClearpay = afterpayClearpay
          Alipay = alipay
          AllowRedisplay = allowRedisplay
          Alma = alma
          AmazonPay = amazonPay
          AuBecsDebit = auBecsDebit
          BacsDebit = bacsDebit
          Bancontact = bancontact
          Billie = billie
          Blik = blik
          Boleto = boleto
          Card = card
          CardPresent = cardPresent
          Cashapp = cashapp
          Crypto = crypto
          CustomerBalance = customerBalance
          Eps = eps
          Fpx = fpx
          Giropay = giropay
          Grabpay = grabpay
          Ideal = ideal
          InteracPresent = interacPresent
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

type ConfirmationTokensResourceShipping =
    {
        Address: Address
        /// Recipient name.
        Name: string
        /// Recipient phone (including extension).
        Phone: string option
    }

module ConfirmationTokensResourceShipping =
    let create
        (
            address: Address,
            name: string,
            phone: string option
        ) : ConfirmationTokensResourceShipping
        =
        {
          Address = address
          Name = name
          Phone = phone
        }

/// ConfirmationTokens help transport client side data collected by Stripe JS over
/// to your server for confirming a PaymentIntent or SetupIntent. If the confirmation
/// is successful, values present on the ConfirmationToken are written onto the Intent.
/// To learn more about how to use ConfirmationToken, visit the related guides:
/// - [Finalize payments on the server](https://docs.stripe.com/payments/finalize-payments-on-the-server)
/// - [Build two-step confirmation](https://docs.stripe.com/payments/build-a-two-step-confirmation).
type ConfirmationToken =
    {
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Time at which this ConfirmationToken expires and can no longer be used to confirm a PaymentIntent or SetupIntent.
        ExpiresAt: DateTime option
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Data used for generating a Mandate.
        MandateData: ConfirmationTokensResourceMandateData option
        /// ID of the PaymentIntent that this ConfirmationToken was used to confirm, or null if this ConfirmationToken has not yet been used.
        PaymentIntent: string option
        /// Payment-method-specific configuration for this ConfirmationToken.
        PaymentMethodOptions: ConfirmationTokensResourcePaymentMethodOptions option
        /// Payment details collected by the Payment Element, used to create a PaymentMethod when a PaymentIntent or SetupIntent is confirmed with this ConfirmationToken.
        PaymentMethodPreview: ConfirmationTokensResourcePaymentMethodPreview option
        /// Return URL used to confirm the Intent.
        ReturnUrl: string option
        /// Indicates that you intend to make future payments with this ConfirmationToken's payment method.
        /// The presence of this property will [attach the payment method](https://docs.stripe.com/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete.
        SetupFutureUsage: ConfirmationTokenSetupFutureUsage option
        /// ID of the SetupIntent that this ConfirmationToken was used to confirm, or null if this ConfirmationToken has not yet been used.
        SetupIntent: string option
        /// Shipping information collected on this ConfirmationToken.
        Shipping: ConfirmationTokensResourceShipping option
        /// Indicates whether the Stripe SDK is used to handle confirmation flow. Defaults to `true` on ConfirmationToken.
        UseStripeSdk: bool
    }

module ConfirmationToken =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "confirmation_token"

    let create
        (
            created: DateTime,
            expiresAt: DateTime option,
            id: string,
            livemode: bool,
            paymentIntent: string option,
            paymentMethodOptions: ConfirmationTokensResourcePaymentMethodOptions option,
            paymentMethodPreview: ConfirmationTokensResourcePaymentMethodPreview option,
            returnUrl: string option,
            setupFutureUsage: ConfirmationTokenSetupFutureUsage option,
            setupIntent: string option,
            shipping: ConfirmationTokensResourceShipping option,
            useStripeSdk: bool,
            mandateData: ConfirmationTokensResourceMandateData option option
        ) : ConfirmationToken
        =
        {
          Created = created
          ExpiresAt = expiresAt
          Id = id
          Livemode = livemode
          PaymentIntent = paymentIntent
          PaymentMethodOptions = paymentMethodOptions
          PaymentMethodPreview = paymentMethodPreview
          ReturnUrl = returnUrl
          SetupFutureUsage = setupFutureUsage
          SetupIntent = setupIntent
          Shipping = shipping
          UseStripeSdk = useStripeSdk
          MandateData = mandateData |> Option.flatten
        }

