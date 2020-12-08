namespace FunStripe

open FSharp.Json

module Cards =

    type Card = {
        Brand: Brand
        Checks: Checks
        Country: string
        ExpMonth: int
        ExpYear: int
        Fingerprint: string
        Funding: Funding
        GeneratedFrom: GeneratedFrom option
        [<JsonField("last4")>] Last4: string
        Networks: Networks
        ThreeDSecureUsage: ThreeDSecureUsage
        Wallet: Wallet option
    }

    and Checks = {
        AddressLine1Check: CheckResult option
        AddressPostalCodeCheck: CheckResult option
        CvcCheck: CheckResult option
    }

    and CheckResult =
        | Pass
        | Fail
        | Unavailable
        | Unchecked

    and Funding =
        | Credit
        | Debit
        | Prepaid
        | Unknown

    and GeneratedFrom = {
        Charge: string
        PaymentMethodDetails: PaymentMethodDetails
    }

    and PaymentMethodDetails = {
        CardPresent: Present
        Type: PaymentMethodType
    }

    and Present = {
        Brand: Brand
        CardholderName: string
        Country: string
        EmvAuthData: string
        ExpMonth: int
        ExpYear: int
        Fingerprint: string
        Funding: Funding
        GeneratedCard: string
        [<JsonField("last4")>] Last4: string
        Network: Network
        ReadMethod: ReadMethod
        Receipt: Receipt
        Type: string
    }

    and Brand =
        | Amex
        | Diners
        | Discover
        | Jcb
        | Mastercard
        | Unionpay
        | Visa
        | Unknown

    and Network =
        | Amex
        | CartesBancaires
        | Diners
        | Discover
        | Interac
        | Jcb
        | Mastercard
        | Unionpay
        | Visa
        | Unknown

    and ReadMethod =
        | ContactEmv
        | ContactlessEmv
        | MagneticStripeTrack2
        | MagneticStripeFallback
        | ContactlessMagstripeMode

    and Receipt= {
        AccountType: AccountType
        ApplicationCryptogram: string
        ApplicationPreferredName: string
        AuthorizationCode: string
        AuthorizationResponseCode: string
        CardholderVerificationMethod: string
        DedicatedFileName: string
        TerminalVerificationResults: string
        TransactionStatusInformation: string
    }

    and AccountType =
        | Credit
        | Checking
        | Prepaid
        | Unknown

    and PaymentMethodType =
        | CardPresent

    and Networks = {
        Available: Network list
        Preferred: Network option
    }

    and ThreeDSecureUsage = {
        Supported: bool
    }

    and Wallet = {
        AmexExpressCheckout: WalletInfo
        ApplePay: WalletInfo
        [<JsonField("dynamiclast4")>] DynamicLast4: string
        GooglePay: WalletInfo
        Masterpass: WalletInfo
        SamsungPay: WalletInfo
        Type: WalletType
        VisaCheckout: WalletInfo
    }

    and WalletType =
        | AmexExpressCheckout
        | ApplePay
        | GooglePay
        | Masterpass
        | SamsungPay
        | VisaCheckout

    and WalletInfo = {
        BillingAddress: Common.Address
        Email: string
        Name: string
        ShippingAddress: Common.Address
    }
