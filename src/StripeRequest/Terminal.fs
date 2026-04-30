namespace StripeRequest.Terminal

open FunStripe
open System.Text.Json.Serialization
open Stripe.Deleted
open Stripe.Terminal
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
module TerminalConfigurations =

    type ListOptions =
        {
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// if present, only return the account default or non-default configurations.
            [<Config.Query>]
            IsAccountDefault: bool option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    module ListOptions =
        let create
            (
                endingBefore: string option,
                expand: string list option,
                isAccountDefault: bool option,
                limit: int option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              EndingBefore = endingBefore
              Expand = expand
              IsAccountDefault = isAccountDefault
              Limit = limit
              StartingAfter = startingAfter
            }

    type Create'BbposWisepad3 =
        {
            /// A File ID representing an image you want to display on the reader.
            [<Config.Form>]
            Splashscreen: Choice<string,string> option
        }

    module Create'BbposWisepad3 =
        let create
            (
                splashscreen: Choice<string,string> option
            ) : Create'BbposWisepad3
            =
            {
              Splashscreen = splashscreen
            }

    type Create'BbposWiseposE =
        {
            /// A File ID representing an image to display on the reader
            [<Config.Form>]
            Splashscreen: Choice<string,string> option
        }

    module Create'BbposWiseposE =
        let create
            (
                splashscreen: Choice<string,string> option
            ) : Create'BbposWiseposE
            =
            {
              Splashscreen = splashscreen
            }

    type Create'CellularCellular =
        {
            /// Determines whether to allow the reader to connect to a cellular network. Defaults to false.
            [<Config.Form>]
            Enabled: bool option
        }

    module Create'CellularCellular =
        let create
            (
                enabled: bool option
            ) : Create'CellularCellular
            =
            {
              Enabled = enabled
            }

    type Create'OfflineOffline =
        {
            /// Determines whether to allow transactions to be collected while reader is offline. Defaults to false.
            [<Config.Form>]
            Enabled: bool option
        }

    module Create'OfflineOffline =
        let create
            (
                enabled: bool option
            ) : Create'OfflineOffline
            =
            {
              Enabled = enabled
            }

    type Create'RebootWindow =
        {
            /// Integer between 0 to 23 that represents the end hour of the reboot time window. The value must be different than the start_hour.
            [<Config.Form>]
            EndHour: int option
            /// Integer between 0 to 23 that represents the start hour of the reboot time window.
            [<Config.Form>]
            StartHour: int option
        }

    module Create'RebootWindow =
        let create
            (
                endHour: int option,
                startHour: int option
            ) : Create'RebootWindow
            =
            {
              EndHour = endHour
              StartHour = startHour
            }

    type Create'StripeS700 =
        {
            /// A File ID representing an image you want to display on the reader.
            [<Config.Form>]
            Splashscreen: Choice<string,string> option
        }

    module Create'StripeS700 =
        let create
            (
                splashscreen: Choice<string,string> option
            ) : Create'StripeS700
            =
            {
              Splashscreen = splashscreen
            }

    type Create'StripeS710 =
        {
            /// A File ID representing an image you want to display on the reader.
            [<Config.Form>]
            Splashscreen: Choice<string,string> option
        }

    module Create'StripeS710 =
        let create
            (
                splashscreen: Choice<string,string> option
            ) : Create'StripeS710
            =
            {
              Splashscreen = splashscreen
            }

    type Create'TippingTippingAed =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Create'TippingTippingAed =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Create'TippingTippingAed
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingAud =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Create'TippingTippingAud =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Create'TippingTippingAud
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingCad =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Create'TippingTippingCad =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Create'TippingTippingCad
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingChf =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Create'TippingTippingChf =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Create'TippingTippingChf
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingCzk =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Create'TippingTippingCzk =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Create'TippingTippingCzk
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingDkk =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Create'TippingTippingDkk =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Create'TippingTippingDkk
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingEur =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Create'TippingTippingEur =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Create'TippingTippingEur
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingGbp =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Create'TippingTippingGbp =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Create'TippingTippingGbp
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingGip =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Create'TippingTippingGip =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Create'TippingTippingGip
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingHkd =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Create'TippingTippingHkd =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Create'TippingTippingHkd
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingHuf =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Create'TippingTippingHuf =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Create'TippingTippingHuf
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingJpy =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Create'TippingTippingJpy =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Create'TippingTippingJpy
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingMxn =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Create'TippingTippingMxn =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Create'TippingTippingMxn
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingMyr =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Create'TippingTippingMyr =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Create'TippingTippingMyr
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingNok =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Create'TippingTippingNok =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Create'TippingTippingNok
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingNzd =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Create'TippingTippingNzd =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Create'TippingTippingNzd
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingPln =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Create'TippingTippingPln =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Create'TippingTippingPln
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingRon =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Create'TippingTippingRon =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Create'TippingTippingRon
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingSek =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Create'TippingTippingSek =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Create'TippingTippingSek
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingSgd =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Create'TippingTippingSgd =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Create'TippingTippingSgd
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingUsd =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Create'TippingTippingUsd =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Create'TippingTippingUsd
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTipping =
        {
            /// Tipping configuration for AED
            [<Config.Form>]
            Aed: Create'TippingTippingAed option
            /// Tipping configuration for AUD
            [<Config.Form>]
            Aud: Create'TippingTippingAud option
            /// Tipping configuration for CAD
            [<Config.Form>]
            Cad: Create'TippingTippingCad option
            /// Tipping configuration for CHF
            [<Config.Form>]
            Chf: Create'TippingTippingChf option
            /// Tipping configuration for CZK
            [<Config.Form>]
            Czk: Create'TippingTippingCzk option
            /// Tipping configuration for DKK
            [<Config.Form>]
            Dkk: Create'TippingTippingDkk option
            /// Tipping configuration for EUR
            [<Config.Form>]
            Eur: Create'TippingTippingEur option
            /// Tipping configuration for GBP
            [<Config.Form>]
            Gbp: Create'TippingTippingGbp option
            /// Tipping configuration for GIP
            [<Config.Form>]
            Gip: Create'TippingTippingGip option
            /// Tipping configuration for HKD
            [<Config.Form>]
            Hkd: Create'TippingTippingHkd option
            /// Tipping configuration for HUF
            [<Config.Form>]
            Huf: Create'TippingTippingHuf option
            /// Tipping configuration for JPY
            [<Config.Form>]
            Jpy: Create'TippingTippingJpy option
            /// Tipping configuration for MXN
            [<Config.Form>]
            Mxn: Create'TippingTippingMxn option
            /// Tipping configuration for MYR
            [<Config.Form>]
            Myr: Create'TippingTippingMyr option
            /// Tipping configuration for NOK
            [<Config.Form>]
            Nok: Create'TippingTippingNok option
            /// Tipping configuration for NZD
            [<Config.Form>]
            Nzd: Create'TippingTippingNzd option
            /// Tipping configuration for PLN
            [<Config.Form>]
            Pln: Create'TippingTippingPln option
            /// Tipping configuration for RON
            [<Config.Form>]
            Ron: Create'TippingTippingRon option
            /// Tipping configuration for SEK
            [<Config.Form>]
            Sek: Create'TippingTippingSek option
            /// Tipping configuration for SGD
            [<Config.Form>]
            Sgd: Create'TippingTippingSgd option
            /// Tipping configuration for USD
            [<Config.Form>]
            Usd: Create'TippingTippingUsd option
        }

    module Create'TippingTipping =
        let create
            (
                aed: Create'TippingTippingAed option,
                aud: Create'TippingTippingAud option,
                cad: Create'TippingTippingCad option,
                chf: Create'TippingTippingChf option,
                czk: Create'TippingTippingCzk option,
                dkk: Create'TippingTippingDkk option,
                eur: Create'TippingTippingEur option,
                gbp: Create'TippingTippingGbp option,
                gip: Create'TippingTippingGip option,
                hkd: Create'TippingTippingHkd option,
                huf: Create'TippingTippingHuf option,
                jpy: Create'TippingTippingJpy option,
                mxn: Create'TippingTippingMxn option,
                myr: Create'TippingTippingMyr option,
                nok: Create'TippingTippingNok option,
                nzd: Create'TippingTippingNzd option,
                pln: Create'TippingTippingPln option,
                ron: Create'TippingTippingRon option,
                sek: Create'TippingTippingSek option,
                sgd: Create'TippingTippingSgd option,
                usd: Create'TippingTippingUsd option
            ) : Create'TippingTipping
            =
            {
              Aed = aed
              Aud = aud
              Cad = cad
              Chf = chf
              Czk = czk
              Dkk = dkk
              Eur = eur
              Gbp = gbp
              Gip = gip
              Hkd = hkd
              Huf = huf
              Jpy = jpy
              Mxn = mxn
              Myr = myr
              Nok = nok
              Nzd = nzd
              Pln = pln
              Ron = ron
              Sek = sek
              Sgd = sgd
              Usd = usd
            }

    type Create'VerifoneP400 =
        {
            /// A File ID representing an image you want to display on the reader.
            [<Config.Form>]
            Splashscreen: Choice<string,string> option
        }

    module Create'VerifoneP400 =
        let create
            (
                splashscreen: Choice<string,string> option
            ) : Create'VerifoneP400
            =
            {
              Splashscreen = splashscreen
            }

    type Create'WifiWifiEnterpriseEapPeap =
        {
            /// A File ID representing a PEM file containing the server certificate
            [<Config.Form>]
            CaCertificateFile: string option
            /// Password for connecting to the WiFi network
            [<Config.Form>]
            Password: string option
            /// Name of the WiFi network
            [<Config.Form>]
            Ssid: string option
            /// Username for connecting to the WiFi network
            [<Config.Form>]
            Username: string option
        }

    module Create'WifiWifiEnterpriseEapPeap =
        let create
            (
                caCertificateFile: string option,
                password: string option,
                ssid: string option,
                username: string option
            ) : Create'WifiWifiEnterpriseEapPeap
            =
            {
              CaCertificateFile = caCertificateFile
              Password = password
              Ssid = ssid
              Username = username
            }

    type Create'WifiWifiEnterpriseEapTls =
        {
            /// A File ID representing a PEM file containing the server certificate
            [<Config.Form>]
            CaCertificateFile: string option
            /// A File ID representing a PEM file containing the client certificate
            [<Config.Form>]
            ClientCertificateFile: string option
            /// A File ID representing a PEM file containing the client RSA private key
            [<Config.Form>]
            PrivateKeyFile: string option
            /// Password for the private key file
            [<Config.Form>]
            PrivateKeyFilePassword: string option
            /// Name of the WiFi network
            [<Config.Form>]
            Ssid: string option
        }

    module Create'WifiWifiEnterpriseEapTls =
        let create
            (
                caCertificateFile: string option,
                clientCertificateFile: string option,
                privateKeyFile: string option,
                privateKeyFilePassword: string option,
                ssid: string option
            ) : Create'WifiWifiEnterpriseEapTls
            =
            {
              CaCertificateFile = caCertificateFile
              ClientCertificateFile = clientCertificateFile
              PrivateKeyFile = privateKeyFile
              PrivateKeyFilePassword = privateKeyFilePassword
              Ssid = ssid
            }

    type Create'WifiWifiPersonalPsk =
        {
            /// Password for connecting to the WiFi network
            [<Config.Form>]
            Password: string option
            /// Name of the WiFi network
            [<Config.Form>]
            Ssid: string option
        }

    module Create'WifiWifiPersonalPsk =
        let create
            (
                password: string option,
                ssid: string option
            ) : Create'WifiWifiPersonalPsk
            =
            {
              Password = password
              Ssid = ssid
            }

    type Create'WifiWifiType =
        | EnterpriseEapPeap
        | EnterpriseEapTls
        | PersonalPsk

    type Create'WifiWifi =
        {
            /// Credentials for a WPA-Enterprise WiFi network using the EAP-PEAP authentication method.
            [<Config.Form>]
            EnterpriseEapPeap: Create'WifiWifiEnterpriseEapPeap option
            /// Credentials for a WPA-Enterprise WiFi network using the EAP-TLS authentication method.
            [<Config.Form>]
            EnterpriseEapTls: Create'WifiWifiEnterpriseEapTls option
            /// Credentials for a WPA-Personal WiFi network.
            [<Config.Form>]
            PersonalPsk: Create'WifiWifiPersonalPsk option
            /// Security type of the WiFi network. Fill out the hash with the corresponding name to provide the set of credentials for this security type.
            [<Config.Form>]
            Type: Create'WifiWifiType option
        }

    module Create'WifiWifi =
        let create
            (
                enterpriseEapPeap: Create'WifiWifiEnterpriseEapPeap option,
                enterpriseEapTls: Create'WifiWifiEnterpriseEapTls option,
                personalPsk: Create'WifiWifiPersonalPsk option,
                ``type``: Create'WifiWifiType option
            ) : Create'WifiWifi
            =
            {
              EnterpriseEapPeap = enterpriseEapPeap
              EnterpriseEapTls = enterpriseEapTls
              PersonalPsk = personalPsk
              Type = ``type``
            }

    type CreateOptions =
        {
            /// An object containing device type specific settings for BBPOS WisePad 3 readers.
            [<Config.Form>]
            BbposWisepad3: Create'BbposWisepad3 option
            /// An object containing device type specific settings for BBPOS WisePOS E readers.
            [<Config.Form>]
            BbposWiseposE: Create'BbposWiseposE option
            /// Configuration for cellular connectivity.
            [<Config.Form>]
            Cellular: Choice<Create'CellularCellular,string> option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Name of the configuration
            [<Config.Form>]
            Name: string option
            /// Configurations for collecting transactions offline.
            [<Config.Form>]
            Offline: Choice<Create'OfflineOffline,string> option
            /// Reboot time settings for readers. that support customized reboot time configuration.
            [<Config.Form>]
            RebootWindow: Create'RebootWindow option
            /// An object containing device type specific settings for Stripe S700 readers.
            [<Config.Form>]
            StripeS700: Create'StripeS700 option
            /// An object containing device type specific settings for Stripe S710 readers.
            [<Config.Form>]
            StripeS710: Create'StripeS710 option
            /// Tipping configurations for readers that support on-reader tips.
            [<Config.Form>]
            Tipping: Choice<Create'TippingTipping,string> option
            /// An object containing device type specific settings for Verifone P400 readers.
            [<Config.Form>]
            VerifoneP400: Create'VerifoneP400 option
            /// Configurations for connecting to a WiFi network.
            [<Config.Form>]
            Wifi: Choice<Create'WifiWifi,string> option
        }

    module CreateOptions =
        let create
            (
                bbposWisepad3: Create'BbposWisepad3 option,
                bbposWiseposE: Create'BbposWiseposE option,
                cellular: Choice<Create'CellularCellular,string> option,
                expand: string list option,
                name: string option,
                offline: Choice<Create'OfflineOffline,string> option,
                rebootWindow: Create'RebootWindow option,
                stripeS700: Create'StripeS700 option,
                stripeS710: Create'StripeS710 option,
                tipping: Choice<Create'TippingTipping,string> option,
                verifoneP400: Create'VerifoneP400 option,
                wifi: Choice<Create'WifiWifi,string> option
            ) : CreateOptions
            =
            {
              BbposWisepad3 = bbposWisepad3
              BbposWiseposE = bbposWiseposE
              Cellular = cellular
              Expand = expand
              Name = name
              Offline = offline
              RebootWindow = rebootWindow
              StripeS700 = stripeS700
              StripeS710 = stripeS710
              Tipping = tipping
              VerifoneP400 = verifoneP400
              Wifi = wifi
            }

    type DeleteOptions =
        { [<Config.Path>]
          Configuration: string }

    module DeleteOptions =
        let create
            (
                configuration: string
            ) : DeleteOptions
            =
            {
              Configuration = configuration
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Configuration: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    module RetrieveOptions =
        let create
            (
                configuration: string,
                expand: string list option
            ) : RetrieveOptions
            =
            {
              Configuration = configuration
              Expand = expand
            }

    type Update'BbposWisepad3BbposWisePad3 =
        {
            /// A File ID representing an image you want to display on the reader.
            [<Config.Form>]
            Splashscreen: Choice<string,string> option
        }

    module Update'BbposWisepad3BbposWisePad3 =
        let create
            (
                splashscreen: Choice<string,string> option
            ) : Update'BbposWisepad3BbposWisePad3
            =
            {
              Splashscreen = splashscreen
            }

    type Update'BbposWiseposEBbposWisePose =
        {
            /// A File ID representing an image to display on the reader
            [<Config.Form>]
            Splashscreen: Choice<string,string> option
        }

    module Update'BbposWiseposEBbposWisePose =
        let create
            (
                splashscreen: Choice<string,string> option
            ) : Update'BbposWiseposEBbposWisePose
            =
            {
              Splashscreen = splashscreen
            }

    type Update'CellularCellular =
        {
            /// Determines whether to allow the reader to connect to a cellular network. Defaults to false.
            [<Config.Form>]
            Enabled: bool option
        }

    module Update'CellularCellular =
        let create
            (
                enabled: bool option
            ) : Update'CellularCellular
            =
            {
              Enabled = enabled
            }

    type Update'OfflineOffline =
        {
            /// Determines whether to allow transactions to be collected while reader is offline. Defaults to false.
            [<Config.Form>]
            Enabled: bool option
        }

    module Update'OfflineOffline =
        let create
            (
                enabled: bool option
            ) : Update'OfflineOffline
            =
            {
              Enabled = enabled
            }

    type Update'RebootWindowRebootWindow =
        {
            /// Integer between 0 to 23 that represents the end hour of the reboot time window. The value must be different than the start_hour.
            [<Config.Form>]
            EndHour: int option
            /// Integer between 0 to 23 that represents the start hour of the reboot time window.
            [<Config.Form>]
            StartHour: int option
        }

    module Update'RebootWindowRebootWindow =
        let create
            (
                endHour: int option,
                startHour: int option
            ) : Update'RebootWindowRebootWindow
            =
            {
              EndHour = endHour
              StartHour = startHour
            }

    type Update'StripeS700StripeS700 =
        {
            /// A File ID representing an image you want to display on the reader.
            [<Config.Form>]
            Splashscreen: Choice<string,string> option
        }

    module Update'StripeS700StripeS700 =
        let create
            (
                splashscreen: Choice<string,string> option
            ) : Update'StripeS700StripeS700
            =
            {
              Splashscreen = splashscreen
            }

    type Update'StripeS710StripeS710 =
        {
            /// A File ID representing an image you want to display on the reader.
            [<Config.Form>]
            Splashscreen: Choice<string,string> option
        }

    module Update'StripeS710StripeS710 =
        let create
            (
                splashscreen: Choice<string,string> option
            ) : Update'StripeS710StripeS710
            =
            {
              Splashscreen = splashscreen
            }

    type Update'TippingTippingAed =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Update'TippingTippingAed =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Update'TippingTippingAed
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingAud =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Update'TippingTippingAud =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Update'TippingTippingAud
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingCad =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Update'TippingTippingCad =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Update'TippingTippingCad
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingChf =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Update'TippingTippingChf =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Update'TippingTippingChf
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingCzk =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Update'TippingTippingCzk =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Update'TippingTippingCzk
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingDkk =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Update'TippingTippingDkk =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Update'TippingTippingDkk
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingEur =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Update'TippingTippingEur =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Update'TippingTippingEur
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingGbp =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Update'TippingTippingGbp =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Update'TippingTippingGbp
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingGip =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Update'TippingTippingGip =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Update'TippingTippingGip
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingHkd =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Update'TippingTippingHkd =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Update'TippingTippingHkd
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingHuf =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Update'TippingTippingHuf =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Update'TippingTippingHuf
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingJpy =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Update'TippingTippingJpy =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Update'TippingTippingJpy
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingMxn =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Update'TippingTippingMxn =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Update'TippingTippingMxn
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingMyr =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Update'TippingTippingMyr =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Update'TippingTippingMyr
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingNok =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Update'TippingTippingNok =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Update'TippingTippingNok
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingNzd =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Update'TippingTippingNzd =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Update'TippingTippingNzd
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingPln =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Update'TippingTippingPln =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Update'TippingTippingPln
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingRon =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Update'TippingTippingRon =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Update'TippingTippingRon
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingSek =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Update'TippingTippingSek =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Update'TippingTippingSek
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingSgd =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Update'TippingTippingSgd =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Update'TippingTippingSgd
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingUsd =
        {
            /// Fixed amounts displayed when collecting a tip
            [<Config.Form>]
            FixedAmounts: int list option
            /// Percentages displayed when collecting a tip
            [<Config.Form>]
            Percentages: int list option
            /// Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
            [<Config.Form>]
            SmartTipThreshold: int option
        }

    module Update'TippingTippingUsd =
        let create
            (
                fixedAmounts: int list option,
                percentages: int list option,
                smartTipThreshold: int option
            ) : Update'TippingTippingUsd
            =
            {
              FixedAmounts = fixedAmounts
              Percentages = percentages
              SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTipping =
        {
            /// Tipping configuration for AED
            [<Config.Form>]
            Aed: Update'TippingTippingAed option
            /// Tipping configuration for AUD
            [<Config.Form>]
            Aud: Update'TippingTippingAud option
            /// Tipping configuration for CAD
            [<Config.Form>]
            Cad: Update'TippingTippingCad option
            /// Tipping configuration for CHF
            [<Config.Form>]
            Chf: Update'TippingTippingChf option
            /// Tipping configuration for CZK
            [<Config.Form>]
            Czk: Update'TippingTippingCzk option
            /// Tipping configuration for DKK
            [<Config.Form>]
            Dkk: Update'TippingTippingDkk option
            /// Tipping configuration for EUR
            [<Config.Form>]
            Eur: Update'TippingTippingEur option
            /// Tipping configuration for GBP
            [<Config.Form>]
            Gbp: Update'TippingTippingGbp option
            /// Tipping configuration for GIP
            [<Config.Form>]
            Gip: Update'TippingTippingGip option
            /// Tipping configuration for HKD
            [<Config.Form>]
            Hkd: Update'TippingTippingHkd option
            /// Tipping configuration for HUF
            [<Config.Form>]
            Huf: Update'TippingTippingHuf option
            /// Tipping configuration for JPY
            [<Config.Form>]
            Jpy: Update'TippingTippingJpy option
            /// Tipping configuration for MXN
            [<Config.Form>]
            Mxn: Update'TippingTippingMxn option
            /// Tipping configuration for MYR
            [<Config.Form>]
            Myr: Update'TippingTippingMyr option
            /// Tipping configuration for NOK
            [<Config.Form>]
            Nok: Update'TippingTippingNok option
            /// Tipping configuration for NZD
            [<Config.Form>]
            Nzd: Update'TippingTippingNzd option
            /// Tipping configuration for PLN
            [<Config.Form>]
            Pln: Update'TippingTippingPln option
            /// Tipping configuration for RON
            [<Config.Form>]
            Ron: Update'TippingTippingRon option
            /// Tipping configuration for SEK
            [<Config.Form>]
            Sek: Update'TippingTippingSek option
            /// Tipping configuration for SGD
            [<Config.Form>]
            Sgd: Update'TippingTippingSgd option
            /// Tipping configuration for USD
            [<Config.Form>]
            Usd: Update'TippingTippingUsd option
        }

    module Update'TippingTipping =
        let create
            (
                aed: Update'TippingTippingAed option,
                aud: Update'TippingTippingAud option,
                cad: Update'TippingTippingCad option,
                chf: Update'TippingTippingChf option,
                czk: Update'TippingTippingCzk option,
                dkk: Update'TippingTippingDkk option,
                eur: Update'TippingTippingEur option,
                gbp: Update'TippingTippingGbp option,
                gip: Update'TippingTippingGip option,
                hkd: Update'TippingTippingHkd option,
                huf: Update'TippingTippingHuf option,
                jpy: Update'TippingTippingJpy option,
                mxn: Update'TippingTippingMxn option,
                myr: Update'TippingTippingMyr option,
                nok: Update'TippingTippingNok option,
                nzd: Update'TippingTippingNzd option,
                pln: Update'TippingTippingPln option,
                ron: Update'TippingTippingRon option,
                sek: Update'TippingTippingSek option,
                sgd: Update'TippingTippingSgd option,
                usd: Update'TippingTippingUsd option
            ) : Update'TippingTipping
            =
            {
              Aed = aed
              Aud = aud
              Cad = cad
              Chf = chf
              Czk = czk
              Dkk = dkk
              Eur = eur
              Gbp = gbp
              Gip = gip
              Hkd = hkd
              Huf = huf
              Jpy = jpy
              Mxn = mxn
              Myr = myr
              Nok = nok
              Nzd = nzd
              Pln = pln
              Ron = ron
              Sek = sek
              Sgd = sgd
              Usd = usd
            }

    type Update'VerifoneP400VerifoneP400 =
        {
            /// A File ID representing an image you want to display on the reader.
            [<Config.Form>]
            Splashscreen: Choice<string,string> option
        }

    module Update'VerifoneP400VerifoneP400 =
        let create
            (
                splashscreen: Choice<string,string> option
            ) : Update'VerifoneP400VerifoneP400
            =
            {
              Splashscreen = splashscreen
            }

    type Update'WifiWifiEnterpriseEapPeap =
        {
            /// A File ID representing a PEM file containing the server certificate
            [<Config.Form>]
            CaCertificateFile: string option
            /// Password for connecting to the WiFi network
            [<Config.Form>]
            Password: string option
            /// Name of the WiFi network
            [<Config.Form>]
            Ssid: string option
            /// Username for connecting to the WiFi network
            [<Config.Form>]
            Username: string option
        }

    module Update'WifiWifiEnterpriseEapPeap =
        let create
            (
                caCertificateFile: string option,
                password: string option,
                ssid: string option,
                username: string option
            ) : Update'WifiWifiEnterpriseEapPeap
            =
            {
              CaCertificateFile = caCertificateFile
              Password = password
              Ssid = ssid
              Username = username
            }

    type Update'WifiWifiEnterpriseEapTls =
        {
            /// A File ID representing a PEM file containing the server certificate
            [<Config.Form>]
            CaCertificateFile: string option
            /// A File ID representing a PEM file containing the client certificate
            [<Config.Form>]
            ClientCertificateFile: string option
            /// A File ID representing a PEM file containing the client RSA private key
            [<Config.Form>]
            PrivateKeyFile: string option
            /// Password for the private key file
            [<Config.Form>]
            PrivateKeyFilePassword: string option
            /// Name of the WiFi network
            [<Config.Form>]
            Ssid: string option
        }

    module Update'WifiWifiEnterpriseEapTls =
        let create
            (
                caCertificateFile: string option,
                clientCertificateFile: string option,
                privateKeyFile: string option,
                privateKeyFilePassword: string option,
                ssid: string option
            ) : Update'WifiWifiEnterpriseEapTls
            =
            {
              CaCertificateFile = caCertificateFile
              ClientCertificateFile = clientCertificateFile
              PrivateKeyFile = privateKeyFile
              PrivateKeyFilePassword = privateKeyFilePassword
              Ssid = ssid
            }

    type Update'WifiWifiPersonalPsk =
        {
            /// Password for connecting to the WiFi network
            [<Config.Form>]
            Password: string option
            /// Name of the WiFi network
            [<Config.Form>]
            Ssid: string option
        }

    module Update'WifiWifiPersonalPsk =
        let create
            (
                password: string option,
                ssid: string option
            ) : Update'WifiWifiPersonalPsk
            =
            {
              Password = password
              Ssid = ssid
            }

    type Update'WifiWifiType =
        | EnterpriseEapPeap
        | EnterpriseEapTls
        | PersonalPsk

    type Update'WifiWifi =
        {
            /// Credentials for a WPA-Enterprise WiFi network using the EAP-PEAP authentication method.
            [<Config.Form>]
            EnterpriseEapPeap: Update'WifiWifiEnterpriseEapPeap option
            /// Credentials for a WPA-Enterprise WiFi network using the EAP-TLS authentication method.
            [<Config.Form>]
            EnterpriseEapTls: Update'WifiWifiEnterpriseEapTls option
            /// Credentials for a WPA-Personal WiFi network.
            [<Config.Form>]
            PersonalPsk: Update'WifiWifiPersonalPsk option
            /// Security type of the WiFi network. Fill out the hash with the corresponding name to provide the set of credentials for this security type.
            [<Config.Form>]
            Type: Update'WifiWifiType option
        }

    module Update'WifiWifi =
        let create
            (
                enterpriseEapPeap: Update'WifiWifiEnterpriseEapPeap option,
                enterpriseEapTls: Update'WifiWifiEnterpriseEapTls option,
                personalPsk: Update'WifiWifiPersonalPsk option,
                ``type``: Update'WifiWifiType option
            ) : Update'WifiWifi
            =
            {
              EnterpriseEapPeap = enterpriseEapPeap
              EnterpriseEapTls = enterpriseEapTls
              PersonalPsk = personalPsk
              Type = ``type``
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Configuration: string
            /// An object containing device type specific settings for BBPOS WisePad 3 readers.
            [<Config.Form>]
            BbposWisepad3: Choice<Update'BbposWisepad3BbposWisePad3,string> option
            /// An object containing device type specific settings for BBPOS WisePOS E readers.
            [<Config.Form>]
            BbposWiseposE: Choice<Update'BbposWiseposEBbposWisePose,string> option
            /// Configuration for cellular connectivity.
            [<Config.Form>]
            Cellular: Choice<Update'CellularCellular,string> option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Name of the configuration
            [<Config.Form>]
            Name: string option
            /// Configurations for collecting transactions offline.
            [<Config.Form>]
            Offline: Choice<Update'OfflineOffline,string> option
            /// Reboot time settings for readers. that support customized reboot time configuration.
            [<Config.Form>]
            RebootWindow: Choice<Update'RebootWindowRebootWindow,string> option
            /// An object containing device type specific settings for Stripe S700 readers.
            [<Config.Form>]
            StripeS700: Choice<Update'StripeS700StripeS700,string> option
            /// An object containing device type specific settings for Stripe S710 readers.
            [<Config.Form>]
            StripeS710: Choice<Update'StripeS710StripeS710,string> option
            /// Tipping configurations for readers that support on-reader tips.
            [<Config.Form>]
            Tipping: Choice<Update'TippingTipping,string> option
            /// An object containing device type specific settings for Verifone P400 readers.
            [<Config.Form>]
            VerifoneP400: Choice<Update'VerifoneP400VerifoneP400,string> option
            /// Configurations for connecting to a WiFi network.
            [<Config.Form>]
            Wifi: Choice<Update'WifiWifi,string> option
        }

    module UpdateOptions =
        let create
            (
                configuration: string,
                bbposWisepad3: Choice<Update'BbposWisepad3BbposWisePad3,string> option,
                bbposWiseposE: Choice<Update'BbposWiseposEBbposWisePose,string> option,
                cellular: Choice<Update'CellularCellular,string> option,
                expand: string list option,
                name: string option,
                offline: Choice<Update'OfflineOffline,string> option,
                rebootWindow: Choice<Update'RebootWindowRebootWindow,string> option,
                stripeS700: Choice<Update'StripeS700StripeS700,string> option,
                stripeS710: Choice<Update'StripeS710StripeS710,string> option,
                tipping: Choice<Update'TippingTipping,string> option,
                verifoneP400: Choice<Update'VerifoneP400VerifoneP400,string> option,
                wifi: Choice<Update'WifiWifi,string> option
            ) : UpdateOptions
            =
            {
              Configuration = configuration
              BbposWisepad3 = bbposWisepad3
              BbposWiseposE = bbposWiseposE
              Cellular = cellular
              Expand = expand
              Name = name
              Offline = offline
              RebootWindow = rebootWindow
              StripeS700 = stripeS700
              StripeS710 = stripeS710
              Tipping = tipping
              VerifoneP400 = verifoneP400
              Wifi = wifi
            }

    ///<p>Returns a list of <code>Configuration</code> objects.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("is_account_default", options.IsAccountDefault |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/terminal/configurations"
        |> RestApi.getAsync<StripeList<TerminalConfiguration>> settings qs

    ///<p>Creates a new <code>Configuration</code> object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/terminal/configurations"
        |> RestApi.postAsync<_, TerminalConfiguration> settings (Map.empty) options

    ///<p>Deletes a <code>Configuration</code> object.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/terminal/configurations/{options.Configuration}"
        |> RestApi.deleteAsync<DeletedTerminalConfiguration> settings (Map.empty)

    ///<p>Retrieves a <code>Configuration</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/terminal/configurations/{options.Configuration}"
        |> RestApi.getAsync<TerminalConfiguration> settings qs

    ///<p>Updates a new <code>Configuration</code> object.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/terminal/configurations/{options.Configuration}"
        |> RestApi.postAsync<_, TerminalConfiguration> settings (Map.empty) options

module TerminalConnectionTokens =

    type CreateOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The id of the location that this connection token is scoped to. If specified the connection token will only be usable with readers assigned to that location, otherwise the connection token will be usable with all readers. Note that location scoping only applies to internet-connected readers. For more details, see [the docs on scoping connection tokens](https://docs.stripe.com/terminal/fleet/locations-and-zones?dashboard-or-api=api#connection-tokens).
            [<Config.Form>]
            Location: string option
        }

    module CreateOptions =
        let create
            (
                expand: string list option,
                location: string option
            ) : CreateOptions
            =
            {
              Expand = expand
              Location = location
            }

    ///<p>To connect to a reader the Stripe Terminal SDK needs to retrieve a short-lived connection token from Stripe, proxied through your server. On your backend, add an endpoint that creates and returns a connection token.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/terminal/connection_tokens"
        |> RestApi.postAsync<_, TerminalConnectionToken> settings (Map.empty) options

module TerminalLocations =

    type ListOptions =
        {
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    module ListOptions =
        let create
            (
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
            }

    type Create'Address =
        {
            /// City, district, suburb, town, or village.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Address line 1, such as the street, PO Box, or company name.
            [<Config.Form>]
            Line1: string option
            /// Address line 2, such as the apartment, suite, unit, or building.
            [<Config.Form>]
            Line2: string option
            /// ZIP or postal code.
            [<Config.Form>]
            PostalCode: string option
            /// State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
            [<Config.Form>]
            State: string option
        }

    module Create'Address =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Create'Address
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Create'AddressKana =
        {
            /// City or ward.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Block or building number.
            [<Config.Form>]
            Line1: string option
            /// Building details.
            [<Config.Form>]
            Line2: string option
            /// Postal code.
            [<Config.Form>]
            PostalCode: string option
            /// Prefecture.
            [<Config.Form>]
            State: string option
            /// Town or cho-me.
            [<Config.Form>]
            Town: string option
        }

    module Create'AddressKana =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option,
                town: string option
            ) : Create'AddressKana
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
              Town = town
            }

    type Create'AddressKanji =
        {
            /// City or ward.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Block or building number.
            [<Config.Form>]
            Line1: string option
            /// Building details.
            [<Config.Form>]
            Line2: string option
            /// Postal code.
            [<Config.Form>]
            PostalCode: string option
            /// Prefecture.
            [<Config.Form>]
            State: string option
            /// Town or cho-me.
            [<Config.Form>]
            Town: string option
        }

    module Create'AddressKanji =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option,
                town: string option
            ) : Create'AddressKanji
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
              Town = town
            }

    type CreateOptions =
        {
            /// The full address of the location.
            [<Config.Form>]
            Address: Create'Address option
            /// The Kana variation of the full address of the location (Japan only).
            [<Config.Form>]
            AddressKana: Create'AddressKana option
            /// The Kanji variation of the full address of the location (Japan only).
            [<Config.Form>]
            AddressKanji: Create'AddressKanji option
            /// The ID of a configuration that will be used to customize all readers in this location.
            [<Config.Form>]
            ConfigurationOverrides: string option
            /// A name for the location. Maximum length is 1000 characters.
            [<Config.Form>]
            DisplayName: string option
            /// The Kana variation of the name for the location (Japan only). Maximum length is 1000 characters.
            [<Config.Form>]
            DisplayNameKana: string option
            /// The Kanji variation of the name for the location (Japan only). Maximum length is 1000 characters.
            [<Config.Form>]
            DisplayNameKanji: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The phone number for the location.
            [<Config.Form>]
            Phone: string option
        }

    module CreateOptions =
        let create
            (
                address: Create'Address option,
                addressKana: Create'AddressKana option,
                addressKanji: Create'AddressKanji option,
                configurationOverrides: string option,
                displayName: string option,
                displayNameKana: string option,
                displayNameKanji: string option,
                expand: string list option,
                metadata: Map<string, string> option,
                phone: string option
            ) : CreateOptions
            =
            {
              Address = address
              AddressKana = addressKana
              AddressKanji = addressKanji
              ConfigurationOverrides = configurationOverrides
              DisplayName = displayName
              DisplayNameKana = displayNameKana
              DisplayNameKanji = displayNameKanji
              Expand = expand
              Metadata = metadata
              Phone = phone
            }

    type DeleteOptions =
        { [<Config.Path>]
          Location: string }

    module DeleteOptions =
        let create
            (
                location: string
            ) : DeleteOptions
            =
            {
              Location = location
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Location: string
        }

    module RetrieveOptions =
        let create
            (
                location: string,
                expand: string list option
            ) : RetrieveOptions
            =
            {
              Location = location
              Expand = expand
            }

    type Update'Address =
        {
            /// City, district, suburb, town, or village.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Address line 1, such as the street, PO Box, or company name.
            [<Config.Form>]
            Line1: string option
            /// Address line 2, such as the apartment, suite, unit, or building.
            [<Config.Form>]
            Line2: string option
            /// ZIP or postal code.
            [<Config.Form>]
            PostalCode: string option
            /// State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
            [<Config.Form>]
            State: string option
        }

    module Update'Address =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Update'Address
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Update'AddressKana =
        {
            /// City or ward.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Block or building number.
            [<Config.Form>]
            Line1: string option
            /// Building details.
            [<Config.Form>]
            Line2: string option
            /// Postal code.
            [<Config.Form>]
            PostalCode: string option
            /// Prefecture.
            [<Config.Form>]
            State: string option
            /// Town or cho-me.
            [<Config.Form>]
            Town: string option
        }

    module Update'AddressKana =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option,
                town: string option
            ) : Update'AddressKana
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
              Town = town
            }

    type Update'AddressKanji =
        {
            /// City or ward.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Block or building number.
            [<Config.Form>]
            Line1: string option
            /// Building details.
            [<Config.Form>]
            Line2: string option
            /// Postal code.
            [<Config.Form>]
            PostalCode: string option
            /// Prefecture.
            [<Config.Form>]
            State: string option
            /// Town or cho-me.
            [<Config.Form>]
            Town: string option
        }

    module Update'AddressKanji =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option,
                town: string option
            ) : Update'AddressKanji
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
              Town = town
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Location: string
            /// The full address of the location. You can't change the location's `country`. If you need to modify the `country` field, create a new `Location` object and re-register any existing readers to that location.
            [<Config.Form>]
            Address: Update'Address option
            /// The Kana variation of the full address of the location (Japan only).
            [<Config.Form>]
            AddressKana: Update'AddressKana option
            /// The Kanji variation of the full address of the location (Japan only).
            [<Config.Form>]
            AddressKanji: Update'AddressKanji option
            /// The ID of a configuration that will be used to customize all readers in this location.
            [<Config.Form>]
            ConfigurationOverrides: Choice<string,string> option
            /// A name for the location.
            [<Config.Form>]
            DisplayName: Choice<string,string> option
            /// The Kana variation of the name for the location (Japan only).
            [<Config.Form>]
            DisplayNameKana: Choice<string,string> option
            /// The Kanji variation of the name for the location (Japan only).
            [<Config.Form>]
            DisplayNameKanji: Choice<string,string> option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The phone number for the location.
            [<Config.Form>]
            Phone: Choice<string,string> option
        }

    module UpdateOptions =
        let create
            (
                location: string,
                address: Update'Address option,
                addressKana: Update'AddressKana option,
                addressKanji: Update'AddressKanji option,
                configurationOverrides: Choice<string,string> option,
                displayName: Choice<string,string> option,
                displayNameKana: Choice<string,string> option,
                displayNameKanji: Choice<string,string> option,
                expand: string list option,
                metadata: Map<string, string> option,
                phone: Choice<string,string> option
            ) : UpdateOptions
            =
            {
              Location = location
              Address = address
              AddressKana = addressKana
              AddressKanji = addressKanji
              ConfigurationOverrides = configurationOverrides
              DisplayName = displayName
              DisplayNameKana = displayNameKana
              DisplayNameKanji = displayNameKanji
              Expand = expand
              Metadata = metadata
              Phone = phone
            }

    ///<p>Returns a list of <code>Location</code> objects.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/terminal/locations"
        |> RestApi.getAsync<StripeList<TerminalLocation>> settings qs

    ///<p>Creates a new <code>Location</code> object.
    ///For further details, including which address fields are required in each country, see the <a href="/docs/terminal/fleet/locations">Manage locations</a> guide.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/terminal/locations"
        |> RestApi.postAsync<_, TerminalLocation> settings (Map.empty) options

    ///<p>Deletes a <code>Location</code> object.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/terminal/locations/{options.Location}"
        |> RestApi.deleteAsync<DeletedTerminalLocation> settings (Map.empty)

    ///<p>Retrieves a <code>Location</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/terminal/locations/{options.Location}"
        |> RestApi.getAsync<TerminalLocation> settings qs

    ///<p>Updates a <code>Location</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/terminal/locations/{options.Location}"
        |> RestApi.postAsync<_, TerminalLocation> settings (Map.empty) options

module TerminalOnboardingLinks =

    type Create'LinkOptionsAppleTermsAndConditions =
        {
            /// Whether the link should also support users relinking their Apple account.
            [<Config.Form>]
            AllowRelinking: bool option
            /// The business name of the merchant accepting Apple's Terms and Conditions.
            [<Config.Form>]
            MerchantDisplayName: string option
        }

    module Create'LinkOptionsAppleTermsAndConditions =
        let create
            (
                allowRelinking: bool option,
                merchantDisplayName: string option
            ) : Create'LinkOptionsAppleTermsAndConditions
            =
            {
              AllowRelinking = allowRelinking
              MerchantDisplayName = merchantDisplayName
            }

    type Create'LinkOptions =
        {
            /// The options associated with the Apple Terms and Conditions link type.
            [<Config.Form>]
            AppleTermsAndConditions: Create'LinkOptionsAppleTermsAndConditions option
        }

    module Create'LinkOptions =
        let create
            (
                appleTermsAndConditions: Create'LinkOptionsAppleTermsAndConditions option
            ) : Create'LinkOptions
            =
            {
              AppleTermsAndConditions = appleTermsAndConditions
            }

    type Create'LinkType = | AppleTermsAndConditions

    type CreateOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Specific fields needed to generate the desired link type.
            [<Config.Form>]
            LinkOptions: Create'LinkOptions
            /// The type of link being generated.
            [<Config.Form>]
            LinkType: Create'LinkType
            /// Stripe account ID to generate the link for.
            [<Config.Form>]
            OnBehalfOf: string option
        }

    module CreateOptions =
        let create
            (
                linkOptions: Create'LinkOptions,
                linkType: Create'LinkType,
                expand: string list option,
                onBehalfOf: string option
            ) : CreateOptions
            =
            {
              LinkOptions = linkOptions
              LinkType = linkType
              Expand = expand
              OnBehalfOf = onBehalfOf
            }

    ///<p>Creates a new <code>OnboardingLink</code> object that contains a redirect_url used for onboarding onto Tap to Pay on iPhone.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/terminal/onboarding_links"
        |> RestApi.postAsync<_, TerminalOnboardingLink> settings (Map.empty) options

module TerminalReaders =

    type ListOptions =
        {
            /// Filters readers by device type
            [<Config.Query>]
            DeviceType: string option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A location ID to filter the response list to only readers at the specific location
            [<Config.Query>]
            Location: string option
            /// Filters readers by serial number
            [<Config.Query>]
            SerialNumber: string option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// A status filter to filter readers to only offline or online readers
            [<Config.Query>]
            Status: string option
        }

    module ListOptions =
        let create
            (
                deviceType: string option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                location: string option,
                serialNumber: string option,
                startingAfter: string option,
                status: string option
            ) : ListOptions
            =
            {
              DeviceType = deviceType
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              Location = location
              SerialNumber = serialNumber
              StartingAfter = startingAfter
              Status = status
            }

    type CreateOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Custom label given to the reader for easier identification. If no label is specified, the registration code will be used.
            [<Config.Form>]
            Label: string option
            /// The location to assign the reader to.
            [<Config.Form>]
            Location: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// A code generated by the reader used for registering to an account.
            [<Config.Form>]
            RegistrationCode: string
        }

    module CreateOptions =
        let create
            (
                registrationCode: string,
                expand: string list option,
                label: string option,
                location: string option,
                metadata: Map<string, string> option
            ) : CreateOptions
            =
            {
              RegistrationCode = registrationCode
              Expand = expand
              Label = label
              Location = location
              Metadata = metadata
            }

    type DeleteOptions =
        { [<Config.Path>]
          Reader: string }

    module DeleteOptions =
        let create
            (
                reader: string
            ) : DeleteOptions
            =
            {
              Reader = reader
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Reader: string
        }

    module RetrieveOptions =
        let create
            (
                reader: string,
                expand: string list option
            ) : RetrieveOptions
            =
            {
              Reader = reader
              Expand = expand
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Reader: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The new label of the reader.
            [<Config.Form>]
            Label: Choice<string,string> option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
        }

    module UpdateOptions =
        let create
            (
                reader: string,
                expand: string list option,
                label: Choice<string,string> option,
                metadata: Map<string, string> option
            ) : UpdateOptions
            =
            {
              Reader = reader
              Expand = expand
              Label = label
              Metadata = metadata
            }

    ///<p>Returns a list of <code>Reader</code> objects.</p>
    let List settings (options: ListOptions) =
        let qs = [("device_type", options.DeviceType |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("location", options.Location |> box); ("serial_number", options.SerialNumber |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/terminal/readers"
        |> RestApi.getAsync<StripeList<TerminalReader>> settings qs

    ///<p>Creates a new <code>Reader</code> object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/terminal/readers"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

    ///<p>Deletes a <code>Reader</code> object.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/terminal/readers/{options.Reader}"
        |> RestApi.deleteAsync<DeletedTerminalReader> settings (Map.empty)

    ///<p>Retrieves a <code>Reader</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/terminal/readers/{options.Reader}"
        |> RestApi.getAsync<TerminalReader> settings qs

    ///<p>Updates a <code>Reader</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/terminal/readers/{options.Reader}"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TerminalReadersCancelAction =

    type CancelActionOptions =
        {
            [<Config.Path>]
            Reader: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module CancelActionOptions =
        let create
            (
                reader: string,
                expand: string list option
            ) : CancelActionOptions
            =
            {
              Reader = reader
              Expand = expand
            }

    ///<p>Cancels the current reader action. See <a href="/docs/terminal/payments/collect-card-payment?terminal-sdk-platform=server-driven#programmatic-cancellation">Programmatic Cancellation</a> for more details.</p>
    let CancelAction settings (options: CancelActionOptions) =
        $"/v1/terminal/readers/{options.Reader}/cancel_action"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TerminalReadersCollectInputs =

    type CollectInputs'InputsCustomText =
        {
            /// The description which will be displayed when collecting this input
            [<Config.Form>]
            Description: string option
            /// Custom text for the skip button. Maximum 14 characters.
            [<Config.Form>]
            SkipButton: string option
            /// Custom text for the submit button. Maximum 30 characters.
            [<Config.Form>]
            SubmitButton: string option
            /// The title which will be displayed when collecting this input
            [<Config.Form>]
            Title: string option
        }

    module CollectInputs'InputsCustomText =
        let create
            (
                description: string option,
                skipButton: string option,
                submitButton: string option,
                title: string option
            ) : CollectInputs'InputsCustomText
            =
            {
              Description = description
              SkipButton = skipButton
              SubmitButton = submitButton
              Title = title
            }

    type CollectInputs'InputsSelectionChoicesStyle =
        | Primary
        | Secondary

    type CollectInputs'InputsSelectionChoices =
        {
            /// The unique identifier for this choice
            [<Config.Form>]
            Id: string option
            /// The style of the button which will be shown for this choice. Can be `primary` or `secondary`.
            [<Config.Form>]
            Style: CollectInputs'InputsSelectionChoicesStyle option
            /// The text which will be shown on the button for this choice
            [<Config.Form>]
            Text: string option
        }

    module CollectInputs'InputsSelectionChoices =
        let create
            (
                id: string option,
                style: CollectInputs'InputsSelectionChoicesStyle option,
                text: string option
            ) : CollectInputs'InputsSelectionChoices
            =
            {
              Id = id
              Style = style
              Text = text
            }

    type CollectInputs'InputsSelection =
        {
            /// List of choices for the `selection` input
            [<Config.Form>]
            Choices: CollectInputs'InputsSelectionChoices list option
        }

    module CollectInputs'InputsSelection =
        let create
            (
                choices: CollectInputs'InputsSelectionChoices list option
            ) : CollectInputs'InputsSelection
            =
            {
              Choices = choices
            }

    type CollectInputs'InputsTogglesDefaultValue =
        | Disabled
        | Enabled

    type CollectInputs'InputsToggles =
        {
            /// The default value of the toggle. Can be `enabled` or `disabled`.
            [<Config.Form>]
            DefaultValue: CollectInputs'InputsTogglesDefaultValue option
            /// The description which will be displayed for the toggle. Maximum 50 characters. At least one of title or description must be provided.
            [<Config.Form>]
            Description: string option
            /// The title which will be displayed for the toggle. Maximum 50 characters. At least one of title or description must be provided.
            [<Config.Form>]
            Title: string option
        }

    module CollectInputs'InputsToggles =
        let create
            (
                defaultValue: CollectInputs'InputsTogglesDefaultValue option,
                description: string option,
                title: string option
            ) : CollectInputs'InputsToggles
            =
            {
              DefaultValue = defaultValue
              Description = description
              Title = title
            }

    type CollectInputs'InputsType =
        | Email
        | Numeric
        | Phone
        | Selection
        | Signature
        | Text

    type CollectInputs'Inputs =
        {
            /// Customize the text which will be displayed while collecting this input
            [<Config.Form>]
            CustomText: CollectInputs'InputsCustomText option
            /// Indicate that this input is required, disabling the skip button
            [<Config.Form>]
            Required: bool option
            /// Options for the `selection` input
            [<Config.Form>]
            Selection: CollectInputs'InputsSelection option
            /// List of toggles to be displayed and customization for the toggles
            [<Config.Form>]
            Toggles: CollectInputs'InputsToggles list option
            /// The type of input to collect
            [<Config.Form>]
            Type: CollectInputs'InputsType option
        }

    module CollectInputs'Inputs =
        let create
            (
                customText: CollectInputs'InputsCustomText option,
                required: bool option,
                selection: CollectInputs'InputsSelection option,
                toggles: CollectInputs'InputsToggles list option,
                ``type``: CollectInputs'InputsType option
            ) : CollectInputs'Inputs
            =
            {
              CustomText = customText
              Required = required
              Selection = selection
              Toggles = toggles
              Type = ``type``
            }

    type CollectInputsOptions =
        {
            [<Config.Path>]
            Reader: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// List of inputs to be collected from the customer using the Reader. Maximum 5 inputs.
            [<Config.Form>]
            Inputs: CollectInputs'Inputs list
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
        }

    module CollectInputsOptions =
        let create
            (
                inputs: CollectInputs'Inputs list,
                reader: string,
                expand: string list option,
                metadata: Map<string, string> option
            ) : CollectInputsOptions
            =
            {
              Inputs = inputs
              Reader = reader
              Expand = expand
              Metadata = metadata
            }

    ///<p>Initiates an <a href="/docs/terminal/features/collect-inputs">input collection flow</a> on a Reader to display input forms and collect information from your customers.</p>
    let CollectInputs settings (options: CollectInputsOptions) =
        $"/v1/terminal/readers/{options.Reader}/collect_inputs"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TerminalReadersCollectPaymentMethod =

    type CollectPaymentMethod'CollectConfigAllowRedisplay =
        | Always
        | Limited
        | Unspecified

    type CollectPaymentMethod'CollectConfigTipping =
        {
            /// Amount used to calculate tip suggestions on tipping selection screen for this transaction. Must be a positive integer in the smallest currency unit (e.g., 100 cents to represent $1.00 or 100 to represent ¥100, a zero-decimal currency).
            [<Config.Form>]
            AmountEligible: int option
        }

    module CollectPaymentMethod'CollectConfigTipping =
        let create
            (
                amountEligible: int option
            ) : CollectPaymentMethod'CollectConfigTipping
            =
            {
              AmountEligible = amountEligible
            }

    type CollectPaymentMethod'CollectConfig =
        {
            /// This field indicates whether this payment method can be shown again to its customer in a checkout flow. Stripe products such as Checkout and Elements use this field to determine whether a payment method can be shown as a saved payment method in a checkout flow.
            [<Config.Form>]
            AllowRedisplay: CollectPaymentMethod'CollectConfigAllowRedisplay option
            /// Enables cancel button on transaction screens.
            [<Config.Form>]
            EnableCustomerCancellation: bool option
            /// Override showing a tipping selection screen on this transaction.
            [<Config.Form>]
            SkipTipping: bool option
            /// Tipping configuration for this transaction.
            [<Config.Form>]
            Tipping: CollectPaymentMethod'CollectConfigTipping option
        }

    module CollectPaymentMethod'CollectConfig =
        let create
            (
                allowRedisplay: CollectPaymentMethod'CollectConfigAllowRedisplay option,
                enableCustomerCancellation: bool option,
                skipTipping: bool option,
                tipping: CollectPaymentMethod'CollectConfigTipping option
            ) : CollectPaymentMethod'CollectConfig
            =
            {
              AllowRedisplay = allowRedisplay
              EnableCustomerCancellation = enableCustomerCancellation
              SkipTipping = skipTipping
              Tipping = tipping
            }

    type CollectPaymentMethodOptions =
        {
            [<Config.Path>]
            Reader: string
            /// Configuration overrides for this collection, such as tipping, surcharging, and customer cancellation settings.
            [<Config.Form>]
            CollectConfig: CollectPaymentMethod'CollectConfig option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The ID of the PaymentIntent to collect a payment method for.
            [<Config.Form>]
            PaymentIntent: string
        }

    module CollectPaymentMethodOptions =
        let create
            (
                paymentIntent: string,
                reader: string,
                collectConfig: CollectPaymentMethod'CollectConfig option,
                expand: string list option
            ) : CollectPaymentMethodOptions
            =
            {
              PaymentIntent = paymentIntent
              Reader = reader
              CollectConfig = collectConfig
              Expand = expand
            }

    ///<p>Initiates a payment flow on a Reader and updates the PaymentIntent with card details before manual confirmation. See <a href="/docs/terminal/payments/collect-card-payment?terminal-sdk-platform=server-driven&process=inspect#collect-a-paymentmethod">Collecting a Payment method</a> for more details.</p>
    let CollectPaymentMethod settings (options: CollectPaymentMethodOptions) =
        $"/v1/terminal/readers/{options.Reader}/collect_payment_method"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TerminalReadersConfirmPaymentIntent =

    type ConfirmPaymentIntent'ConfirmConfig =
        {
            /// The URL to redirect your customer back to after they authenticate or cancel their payment on the payment method's app or site. If you'd prefer to redirect to a mobile application, you can alternatively supply an application URI scheme.
            [<Config.Form>]
            ReturnUrl: string option
        }

    module ConfirmPaymentIntent'ConfirmConfig =
        let create
            (
                returnUrl: string option
            ) : ConfirmPaymentIntent'ConfirmConfig
            =
            {
              ReturnUrl = returnUrl
            }

    type ConfirmPaymentIntentOptions =
        {
            [<Config.Path>]
            Reader: string
            /// Configuration overrides for this confirmation, such as surcharge settings and return URL.
            [<Config.Form>]
            ConfirmConfig: ConfirmPaymentIntent'ConfirmConfig option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The ID of the PaymentIntent to confirm.
            [<Config.Form>]
            PaymentIntent: string
        }

    module ConfirmPaymentIntentOptions =
        let create
            (
                paymentIntent: string,
                reader: string,
                confirmConfig: ConfirmPaymentIntent'ConfirmConfig option,
                expand: string list option
            ) : ConfirmPaymentIntentOptions
            =
            {
              PaymentIntent = paymentIntent
              Reader = reader
              ConfirmConfig = confirmConfig
              Expand = expand
            }

    ///<p>Finalizes a payment on a Reader. See <a href="/docs/terminal/payments/collect-card-payment?terminal-sdk-platform=server-driven&process=inspect#confirm-the-paymentintent">Confirming a Payment</a> for more details.</p>
    let ConfirmPaymentIntent settings (options: ConfirmPaymentIntentOptions) =
        $"/v1/terminal/readers/{options.Reader}/confirm_payment_intent"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TerminalReadersProcessPaymentIntent =

    type ProcessPaymentIntent'ProcessConfigAllowRedisplay =
        | Always
        | Limited
        | Unspecified

    type ProcessPaymentIntent'ProcessConfigTipping =
        {
            /// Amount used to calculate tip suggestions on tipping selection screen for this transaction. Must be a positive integer in the smallest currency unit (e.g., 100 cents to represent $1.00 or 100 to represent ¥100, a zero-decimal currency).
            [<Config.Form>]
            AmountEligible: int option
        }

    module ProcessPaymentIntent'ProcessConfigTipping =
        let create
            (
                amountEligible: int option
            ) : ProcessPaymentIntent'ProcessConfigTipping
            =
            {
              AmountEligible = amountEligible
            }

    type ProcessPaymentIntent'ProcessConfig =
        {
            /// This field indicates whether this payment method can be shown again to its customer in a checkout flow. Stripe products such as Checkout and Elements use this field to determine whether a payment method can be shown as a saved payment method in a checkout flow.
            [<Config.Form>]
            AllowRedisplay: ProcessPaymentIntent'ProcessConfigAllowRedisplay option
            /// Enables cancel button on transaction screens.
            [<Config.Form>]
            EnableCustomerCancellation: bool option
            /// The URL to redirect your customer back to after they authenticate or cancel their payment on the payment method's app or site. If you'd prefer to redirect to a mobile application, you can alternatively supply an application URI scheme.
            [<Config.Form>]
            ReturnUrl: string option
            /// Override showing a tipping selection screen on this transaction.
            [<Config.Form>]
            SkipTipping: bool option
            /// Tipping configuration for this transaction.
            [<Config.Form>]
            Tipping: ProcessPaymentIntent'ProcessConfigTipping option
        }

    module ProcessPaymentIntent'ProcessConfig =
        let create
            (
                allowRedisplay: ProcessPaymentIntent'ProcessConfigAllowRedisplay option,
                enableCustomerCancellation: bool option,
                returnUrl: string option,
                skipTipping: bool option,
                tipping: ProcessPaymentIntent'ProcessConfigTipping option
            ) : ProcessPaymentIntent'ProcessConfig
            =
            {
              AllowRedisplay = allowRedisplay
              EnableCustomerCancellation = enableCustomerCancellation
              ReturnUrl = returnUrl
              SkipTipping = skipTipping
              Tipping = tipping
            }

    type ProcessPaymentIntentOptions =
        {
            [<Config.Path>]
            Reader: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The ID of the PaymentIntent to process on the reader.
            [<Config.Form>]
            PaymentIntent: string
            /// Configuration overrides for this transaction, such as tipping and customer cancellation settings.
            [<Config.Form>]
            ProcessConfig: ProcessPaymentIntent'ProcessConfig option
        }

    module ProcessPaymentIntentOptions =
        let create
            (
                paymentIntent: string,
                reader: string,
                expand: string list option,
                processConfig: ProcessPaymentIntent'ProcessConfig option
            ) : ProcessPaymentIntentOptions
            =
            {
              PaymentIntent = paymentIntent
              Reader = reader
              Expand = expand
              ProcessConfig = processConfig
            }

    ///<p>Initiates a payment flow on a Reader. See <a href="/docs/terminal/payments/collect-card-payment?terminal-sdk-platform=server-driven&process=immediately#process-payment">process the payment</a> for more details.</p>
    let ProcessPaymentIntent settings (options: ProcessPaymentIntentOptions) =
        $"/v1/terminal/readers/{options.Reader}/process_payment_intent"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TerminalReadersProcessSetupIntent =

    type ProcessSetupIntent'AllowRedisplay =
        | Always
        | Limited
        | Unspecified

    type ProcessSetupIntent'ProcessConfig =
        {
            /// Enables cancel button on transaction screens.
            [<Config.Form>]
            EnableCustomerCancellation: bool option
        }

    module ProcessSetupIntent'ProcessConfig =
        let create
            (
                enableCustomerCancellation: bool option
            ) : ProcessSetupIntent'ProcessConfig
            =
            {
              EnableCustomerCancellation = enableCustomerCancellation
            }

    type ProcessSetupIntentOptions =
        {
            [<Config.Path>]
            Reader: string
            /// This field indicates whether this payment method can be shown again to its customer in a checkout flow. Stripe products such as Checkout and Elements use this field to determine whether a payment method can be shown as a saved payment method in a checkout flow.
            [<Config.Form>]
            AllowRedisplay: ProcessSetupIntent'AllowRedisplay
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Configuration overrides for this setup, such as MOTO and customer cancellation settings.
            [<Config.Form>]
            ProcessConfig: ProcessSetupIntent'ProcessConfig option
            /// The ID of the SetupIntent to process on the reader.
            [<Config.Form>]
            SetupIntent: string
        }

    module ProcessSetupIntentOptions =
        let create
            (
                allowRedisplay: ProcessSetupIntent'AllowRedisplay,
                reader: string,
                setupIntent: string,
                expand: string list option,
                processConfig: ProcessSetupIntent'ProcessConfig option
            ) : ProcessSetupIntentOptions
            =
            {
              AllowRedisplay = allowRedisplay
              Reader = reader
              SetupIntent = setupIntent
              Expand = expand
              ProcessConfig = processConfig
            }

    ///<p>Initiates a SetupIntent flow on a Reader. See <a href="/docs/terminal/features/saving-payment-details/save-directly">Save directly without charging</a> for more details.</p>
    let ProcessSetupIntent settings (options: ProcessSetupIntentOptions) =
        $"/v1/terminal/readers/{options.Reader}/process_setup_intent"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TerminalReadersRefundPayment =

    type RefundPayment'RefundPaymentConfig =
        {
            /// Enables cancel button on transaction screens.
            [<Config.Form>]
            EnableCustomerCancellation: bool option
        }

    module RefundPayment'RefundPaymentConfig =
        let create
            (
                enableCustomerCancellation: bool option
            ) : RefundPayment'RefundPaymentConfig
            =
            {
              EnableCustomerCancellation = enableCustomerCancellation
            }

    type RefundPaymentOptions =
        {
            [<Config.Path>]
            Reader: string
            /// A positive integer in __cents__ representing how much of this charge to refund.
            [<Config.Form>]
            Amount: int option
            /// ID of the Charge to refund.
            [<Config.Form>]
            Charge: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// ID of the PaymentIntent to refund.
            [<Config.Form>]
            PaymentIntent: string option
            /// Boolean indicating whether the application fee should be refunded when refunding this charge. If a full charge refund is given, the full application fee will be refunded. Otherwise, the application fee will be refunded in an amount proportional to the amount of the charge refunded. An application fee can be refunded only by the application that created the charge.
            [<Config.Form>]
            RefundApplicationFee: bool option
            /// Configuration overrides for this refund, such as customer cancellation settings.
            [<Config.Form>]
            RefundPaymentConfig: RefundPayment'RefundPaymentConfig option
            /// Boolean indicating whether the transfer should be reversed when refunding this charge. The transfer will be reversed proportionally to the amount being refunded (either the entire or partial amount). A transfer can be reversed only by the application that created the charge.
            [<Config.Form>]
            ReverseTransfer: bool option
        }

    module RefundPaymentOptions =
        let create
            (
                reader: string,
                amount: int option,
                charge: string option,
                expand: string list option,
                metadata: Map<string, string> option,
                paymentIntent: string option,
                refundApplicationFee: bool option,
                refundPaymentConfig: RefundPayment'RefundPaymentConfig option,
                reverseTransfer: bool option
            ) : RefundPaymentOptions
            =
            {
              Reader = reader
              Amount = amount
              Charge = charge
              Expand = expand
              Metadata = metadata
              PaymentIntent = paymentIntent
              RefundApplicationFee = refundApplicationFee
              RefundPaymentConfig = refundPaymentConfig
              ReverseTransfer = reverseTransfer
            }

    ///<p>Initiates an in-person refund on a Reader. See <a href="/docs/terminal/payments/regional?integration-country=CA#refund-an-interac-payment">Refund an Interac Payment</a> for more details.</p>
    let RefundPayment settings (options: RefundPaymentOptions) =
        $"/v1/terminal/readers/{options.Reader}/refund_payment"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TerminalReadersSetReaderDisplay =

    type SetReaderDisplay'CartLineItems =
        {
            /// The price of the item in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).
            [<Config.Form>]
            Amount: int option
            /// The description or name of the item.
            [<Config.Form>]
            Description: string option
            /// The quantity of the line item being purchased.
            [<Config.Form>]
            Quantity: int option
        }

    module SetReaderDisplay'CartLineItems =
        let create
            (
                amount: int option,
                description: string option,
                quantity: int option
            ) : SetReaderDisplay'CartLineItems
            =
            {
              Amount = amount
              Description = description
              Quantity = quantity
            }

    type SetReaderDisplay'Cart =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// Array of line items to display.
            [<Config.Form>]
            LineItems: SetReaderDisplay'CartLineItems list option
            /// The amount of tax in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).
            [<Config.Form>]
            Tax: int option
            /// Total balance of cart due in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).
            [<Config.Form>]
            Total: int option
        }

    module SetReaderDisplay'Cart =
        let create
            (
                currency: IsoTypes.IsoCurrencyCode option,
                lineItems: SetReaderDisplay'CartLineItems list option,
                tax: int option,
                total: int option
            ) : SetReaderDisplay'Cart
            =
            {
              Currency = currency
              LineItems = lineItems
              Tax = tax
              Total = total
            }

    type SetReaderDisplay'Type = | Cart

    type SetReaderDisplayOptions =
        {
            [<Config.Path>]
            Reader: string
            /// Cart details to display on the reader screen, including line items, amounts, and currency.
            [<Config.Form>]
            Cart: SetReaderDisplay'Cart option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Type of information to display. Only `cart` is currently supported.
            [<Config.Form>]
            Type: SetReaderDisplay'Type
        }

    module SetReaderDisplayOptions =
        let create
            (
                reader: string,
                ``type``: SetReaderDisplay'Type,
                cart: SetReaderDisplay'Cart option,
                expand: string list option
            ) : SetReaderDisplayOptions
            =
            {
              Reader = reader
              Type = ``type``
              Cart = cart
              Expand = expand
            }

    ///<p>Sets the reader display to show <a href="/docs/terminal/features/display">cart details</a>.</p>
    let SetReaderDisplay settings (options: SetReaderDisplayOptions) =
        $"/v1/terminal/readers/{options.Reader}/set_reader_display"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

