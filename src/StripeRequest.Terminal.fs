namespace FunStripe.StripeRequest

open FunStripe
open System.Text.Json.Serialization
open FunStripe.StripeModel
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
module TerminalConfigurations =

    type ListOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>if present, only return the account default or non-default configurations.</summary>
        [<Config.Query>]IsAccountDefault: bool option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?endingBefore: string, ?expand: string list, ?isAccountDefault: bool, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                IsAccountDefault = isAccountDefault
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<summary><p>Returns a list of <code>Configuration</code> objects.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("is_account_default", options.IsAccountDefault |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/terminal/configurations"
        |> RestApi.getAsync<StripeList<TerminalConfiguration>> settings qs

    type Create'BbposWisepad3 = {
        ///<summary>A File ID representing an image you want to display on the reader.</summary>
        [<Config.Form>]Splashscreen: Choice<string,string> option
    }
    with
        static member New(?splashscreen: Choice<string,string>) =
            {
                Splashscreen = splashscreen
            }

    type Create'BbposWiseposE = {
        ///<summary>A File ID representing an image to display on the reader</summary>
        [<Config.Form>]Splashscreen: Choice<string,string> option
    }
    with
        static member New(?splashscreen: Choice<string,string>) =
            {
                Splashscreen = splashscreen
            }

    type Create'CellularCellular = {
        ///<summary>Determines whether to allow the reader to connect to a cellular network. Defaults to false.</summary>
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Create'OfflineOffline = {
        ///<summary>Determines whether to allow transactions to be collected while reader is offline. Defaults to false.</summary>
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Create'RebootWindow = {
        ///<summary>Integer between 0 to 23 that represents the end hour of the reboot time window. The value must be different than the start_hour.</summary>
        [<Config.Form>]EndHour: int option
        ///<summary>Integer between 0 to 23 that represents the start hour of the reboot time window.</summary>
        [<Config.Form>]StartHour: int option
    }
    with
        static member New(?endHour: int, ?startHour: int) =
            {
                EndHour = endHour
                StartHour = startHour
            }

    type Create'StripeS700 = {
        ///<summary>A File ID representing an image you want to display on the reader.</summary>
        [<Config.Form>]Splashscreen: Choice<string,string> option
    }
    with
        static member New(?splashscreen: Choice<string,string>) =
            {
                Splashscreen = splashscreen
            }

    type Create'StripeS710 = {
        ///<summary>A File ID representing an image you want to display on the reader.</summary>
        [<Config.Form>]Splashscreen: Choice<string,string> option
    }
    with
        static member New(?splashscreen: Choice<string,string>) =
            {
                Splashscreen = splashscreen
            }

    type Create'TippingTippingAed = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingAud = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingCad = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingChf = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingCzk = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingDkk = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingEur = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingGbp = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingGip = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingHkd = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingHuf = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingJpy = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingMxn = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingMyr = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingNok = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingNzd = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingPln = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingRon = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingSek = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingSgd = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTippingUsd = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Create'TippingTipping = {
        ///<summary>Tipping configuration for AED</summary>
        [<Config.Form>]Aed: Create'TippingTippingAed option
        ///<summary>Tipping configuration for AUD</summary>
        [<Config.Form>]Aud: Create'TippingTippingAud option
        ///<summary>Tipping configuration for CAD</summary>
        [<Config.Form>]Cad: Create'TippingTippingCad option
        ///<summary>Tipping configuration for CHF</summary>
        [<Config.Form>]Chf: Create'TippingTippingChf option
        ///<summary>Tipping configuration for CZK</summary>
        [<Config.Form>]Czk: Create'TippingTippingCzk option
        ///<summary>Tipping configuration for DKK</summary>
        [<Config.Form>]Dkk: Create'TippingTippingDkk option
        ///<summary>Tipping configuration for EUR</summary>
        [<Config.Form>]Eur: Create'TippingTippingEur option
        ///<summary>Tipping configuration for GBP</summary>
        [<Config.Form>]Gbp: Create'TippingTippingGbp option
        ///<summary>Tipping configuration for GIP</summary>
        [<Config.Form>]Gip: Create'TippingTippingGip option
        ///<summary>Tipping configuration for HKD</summary>
        [<Config.Form>]Hkd: Create'TippingTippingHkd option
        ///<summary>Tipping configuration for HUF</summary>
        [<Config.Form>]Huf: Create'TippingTippingHuf option
        ///<summary>Tipping configuration for JPY</summary>
        [<Config.Form>]Jpy: Create'TippingTippingJpy option
        ///<summary>Tipping configuration for MXN</summary>
        [<Config.Form>]Mxn: Create'TippingTippingMxn option
        ///<summary>Tipping configuration for MYR</summary>
        [<Config.Form>]Myr: Create'TippingTippingMyr option
        ///<summary>Tipping configuration for NOK</summary>
        [<Config.Form>]Nok: Create'TippingTippingNok option
        ///<summary>Tipping configuration for NZD</summary>
        [<Config.Form>]Nzd: Create'TippingTippingNzd option
        ///<summary>Tipping configuration for PLN</summary>
        [<Config.Form>]Pln: Create'TippingTippingPln option
        ///<summary>Tipping configuration for RON</summary>
        [<Config.Form>]Ron: Create'TippingTippingRon option
        ///<summary>Tipping configuration for SEK</summary>
        [<Config.Form>]Sek: Create'TippingTippingSek option
        ///<summary>Tipping configuration for SGD</summary>
        [<Config.Form>]Sgd: Create'TippingTippingSgd option
        ///<summary>Tipping configuration for USD</summary>
        [<Config.Form>]Usd: Create'TippingTippingUsd option
    }
    with
        static member New(?aed: Create'TippingTippingAed, ?sek: Create'TippingTippingSek, ?ron: Create'TippingTippingRon, ?pln: Create'TippingTippingPln, ?nzd: Create'TippingTippingNzd, ?nok: Create'TippingTippingNok, ?myr: Create'TippingTippingMyr, ?mxn: Create'TippingTippingMxn, ?jpy: Create'TippingTippingJpy, ?sgd: Create'TippingTippingSgd, ?huf: Create'TippingTippingHuf, ?gip: Create'TippingTippingGip, ?gbp: Create'TippingTippingGbp, ?eur: Create'TippingTippingEur, ?dkk: Create'TippingTippingDkk, ?czk: Create'TippingTippingCzk, ?chf: Create'TippingTippingChf, ?cad: Create'TippingTippingCad, ?aud: Create'TippingTippingAud, ?hkd: Create'TippingTippingHkd, ?usd: Create'TippingTippingUsd) =
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

    type Create'VerifoneP400 = {
        ///<summary>A File ID representing an image you want to display on the reader.</summary>
        [<Config.Form>]Splashscreen: Choice<string,string> option
    }
    with
        static member New(?splashscreen: Choice<string,string>) =
            {
                Splashscreen = splashscreen
            }

    type Create'WifiWifiEnterpriseEapPeap = {
        ///<summary>A File ID representing a PEM file containing the server certificate</summary>
        [<Config.Form>]CaCertificateFile: string option
        ///<summary>Password for connecting to the WiFi network</summary>
        [<Config.Form>]Password: string option
        ///<summary>Name of the WiFi network</summary>
        [<Config.Form>]Ssid: string option
        ///<summary>Username for connecting to the WiFi network</summary>
        [<Config.Form>]Username: string option
    }
    with
        static member New(?caCertificateFile: string, ?password: string, ?ssid: string, ?username: string) =
            {
                CaCertificateFile = caCertificateFile
                Password = password
                Ssid = ssid
                Username = username
            }

    type Create'WifiWifiEnterpriseEapTls = {
        ///<summary>A File ID representing a PEM file containing the server certificate</summary>
        [<Config.Form>]CaCertificateFile: string option
        ///<summary>A File ID representing a PEM file containing the client certificate</summary>
        [<Config.Form>]ClientCertificateFile: string option
        ///<summary>A File ID representing a PEM file containing the client RSA private key</summary>
        [<Config.Form>]PrivateKeyFile: string option
        ///<summary>Password for the private key file</summary>
        [<Config.Form>]PrivateKeyFilePassword: string option
        ///<summary>Name of the WiFi network</summary>
        [<Config.Form>]Ssid: string option
    }
    with
        static member New(?caCertificateFile: string, ?clientCertificateFile: string, ?privateKeyFile: string, ?privateKeyFilePassword: string, ?ssid: string) =
            {
                CaCertificateFile = caCertificateFile
                ClientCertificateFile = clientCertificateFile
                PrivateKeyFile = privateKeyFile
                PrivateKeyFilePassword = privateKeyFilePassword
                Ssid = ssid
            }

    type Create'WifiWifiPersonalPsk = {
        ///<summary>Password for connecting to the WiFi network</summary>
        [<Config.Form>]Password: string option
        ///<summary>Name of the WiFi network</summary>
        [<Config.Form>]Ssid: string option
    }
    with
        static member New(?password: string, ?ssid: string) =
            {
                Password = password
                Ssid = ssid
            }

    type Create'WifiWifiType =
    | EnterpriseEapPeap
    | EnterpriseEapTls
    | PersonalPsk

    type Create'WifiWifi = {
        ///<summary>Credentials for a WPA-Enterprise WiFi network using the EAP-PEAP authentication method.</summary>
        [<Config.Form>]EnterpriseEapPeap: Create'WifiWifiEnterpriseEapPeap option
        ///<summary>Credentials for a WPA-Enterprise WiFi network using the EAP-TLS authentication method.</summary>
        [<Config.Form>]EnterpriseEapTls: Create'WifiWifiEnterpriseEapTls option
        ///<summary>Credentials for a WPA-Personal WiFi network.</summary>
        [<Config.Form>]PersonalPsk: Create'WifiWifiPersonalPsk option
        ///<summary>Security type of the WiFi network. Fill out the hash with the corresponding name to provide the set of credentials for this security type.</summary>
        [<Config.Form>]Type: Create'WifiWifiType option
    }
    with
        static member New(?enterpriseEapPeap: Create'WifiWifiEnterpriseEapPeap, ?enterpriseEapTls: Create'WifiWifiEnterpriseEapTls, ?personalPsk: Create'WifiWifiPersonalPsk, ?type': Create'WifiWifiType) =
            {
                EnterpriseEapPeap = enterpriseEapPeap
                EnterpriseEapTls = enterpriseEapTls
                PersonalPsk = personalPsk
                Type = type'
            }

    type CreateOptions = {
        ///<summary>An object containing device type specific settings for BBPOS WisePad 3 readers.</summary>
        [<Config.Form>]BbposWisepad3: Create'BbposWisepad3 option
        ///<summary>An object containing device type specific settings for BBPOS WisePOS E readers.</summary>
        [<Config.Form>]BbposWiseposE: Create'BbposWiseposE option
        ///<summary>Configuration for cellular connectivity.</summary>
        [<Config.Form>]Cellular: Choice<Create'CellularCellular,string> option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Name of the configuration</summary>
        [<Config.Form>]Name: string option
        ///<summary>Configurations for collecting transactions offline.</summary>
        [<Config.Form>]Offline: Choice<Create'OfflineOffline,string> option
        ///<summary>Reboot time settings for readers. that support customized reboot time configuration.</summary>
        [<Config.Form>]RebootWindow: Create'RebootWindow option
        ///<summary>An object containing device type specific settings for Stripe S700 readers.</summary>
        [<Config.Form>]StripeS700: Create'StripeS700 option
        ///<summary>An object containing device type specific settings for Stripe S710 readers.</summary>
        [<Config.Form>]StripeS710: Create'StripeS710 option
        ///<summary>Tipping configurations for readers that support on-reader tips.</summary>
        [<Config.Form>]Tipping: Choice<Create'TippingTipping,string> option
        ///<summary>An object containing device type specific settings for Verifone P400 readers.</summary>
        [<Config.Form>]VerifoneP400: Create'VerifoneP400 option
        ///<summary>Configurations for connecting to a WiFi network.</summary>
        [<Config.Form>]Wifi: Choice<Create'WifiWifi,string> option
    }
    with
        static member New(?bbposWisepad3: Create'BbposWisepad3, ?bbposWiseposE: Create'BbposWiseposE, ?cellular: Choice<Create'CellularCellular,string>, ?expand: string list, ?name: string, ?offline: Choice<Create'OfflineOffline,string>, ?rebootWindow: Create'RebootWindow, ?stripeS700: Create'StripeS700, ?stripeS710: Create'StripeS710, ?tipping: Choice<Create'TippingTipping,string>, ?verifoneP400: Create'VerifoneP400, ?wifi: Choice<Create'WifiWifi,string>) =
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

    ///<summary><p>Creates a new <code>Configuration</code> object.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/terminal/configurations"
        |> RestApi.postAsync<_, TerminalConfiguration> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Configuration: string
    }
    with
        static member New(configuration: string) =
            {
                Configuration = configuration
            }

    ///<summary><p>Deletes a <code>Configuration</code> object.</p></summary>
    let Delete settings (options: DeleteOptions) =
        $"/v1/terminal/configurations/{options.Configuration}"
        |> RestApi.deleteAsync<DeletedTerminalConfiguration> settings (Map.empty)

    type RetrieveOptions = {
        [<Config.Path>]Configuration: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(configuration: string, ?expand: string list) =
            {
                Configuration = configuration
                Expand = expand
            }

    ///<summary><p>Retrieves a <code>Configuration</code> object.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/terminal/configurations/{options.Configuration}"
        |> RestApi.getAsync<TerminalConfiguration> settings qs

    type Update'BbposWisepad3BbposWisePad3 = {
        ///<summary>A File ID representing an image you want to display on the reader.</summary>
        [<Config.Form>]Splashscreen: Choice<string,string> option
    }
    with
        static member New(?splashscreen: Choice<string,string>) =
            {
                Splashscreen = splashscreen
            }

    type Update'BbposWiseposEBbposWisePose = {
        ///<summary>A File ID representing an image to display on the reader</summary>
        [<Config.Form>]Splashscreen: Choice<string,string> option
    }
    with
        static member New(?splashscreen: Choice<string,string>) =
            {
                Splashscreen = splashscreen
            }

    type Update'CellularCellular = {
        ///<summary>Determines whether to allow the reader to connect to a cellular network. Defaults to false.</summary>
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Update'OfflineOffline = {
        ///<summary>Determines whether to allow transactions to be collected while reader is offline. Defaults to false.</summary>
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Update'RebootWindowRebootWindow = {
        ///<summary>Integer between 0 to 23 that represents the end hour of the reboot time window. The value must be different than the start_hour.</summary>
        [<Config.Form>]EndHour: int option
        ///<summary>Integer between 0 to 23 that represents the start hour of the reboot time window.</summary>
        [<Config.Form>]StartHour: int option
    }
    with
        static member New(?endHour: int, ?startHour: int) =
            {
                EndHour = endHour
                StartHour = startHour
            }

    type Update'StripeS700StripeS700 = {
        ///<summary>A File ID representing an image you want to display on the reader.</summary>
        [<Config.Form>]Splashscreen: Choice<string,string> option
    }
    with
        static member New(?splashscreen: Choice<string,string>) =
            {
                Splashscreen = splashscreen
            }

    type Update'StripeS710StripeS710 = {
        ///<summary>A File ID representing an image you want to display on the reader.</summary>
        [<Config.Form>]Splashscreen: Choice<string,string> option
    }
    with
        static member New(?splashscreen: Choice<string,string>) =
            {
                Splashscreen = splashscreen
            }

    type Update'TippingTippingAed = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingAud = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingCad = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingChf = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingCzk = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingDkk = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingEur = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingGbp = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingGip = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingHkd = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingHuf = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingJpy = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingMxn = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingMyr = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingNok = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingNzd = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingPln = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingRon = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingSek = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingSgd = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTippingUsd = {
        ///<summary>Fixed amounts displayed when collecting a tip</summary>
        [<Config.Form>]FixedAmounts: int list option
        ///<summary>Percentages displayed when collecting a tip</summary>
        [<Config.Form>]Percentages: int list option
        ///<summary>Below this amount, fixed amounts will be displayed; above it, percentages will be displayed</summary>
        [<Config.Form>]SmartTipThreshold: int option
    }
    with
        static member New(?fixedAmounts: int list, ?percentages: int list, ?smartTipThreshold: int) =
            {
                FixedAmounts = fixedAmounts
                Percentages = percentages
                SmartTipThreshold = smartTipThreshold
            }

    type Update'TippingTipping = {
        ///<summary>Tipping configuration for AED</summary>
        [<Config.Form>]Aed: Update'TippingTippingAed option
        ///<summary>Tipping configuration for AUD</summary>
        [<Config.Form>]Aud: Update'TippingTippingAud option
        ///<summary>Tipping configuration for CAD</summary>
        [<Config.Form>]Cad: Update'TippingTippingCad option
        ///<summary>Tipping configuration for CHF</summary>
        [<Config.Form>]Chf: Update'TippingTippingChf option
        ///<summary>Tipping configuration for CZK</summary>
        [<Config.Form>]Czk: Update'TippingTippingCzk option
        ///<summary>Tipping configuration for DKK</summary>
        [<Config.Form>]Dkk: Update'TippingTippingDkk option
        ///<summary>Tipping configuration for EUR</summary>
        [<Config.Form>]Eur: Update'TippingTippingEur option
        ///<summary>Tipping configuration for GBP</summary>
        [<Config.Form>]Gbp: Update'TippingTippingGbp option
        ///<summary>Tipping configuration for GIP</summary>
        [<Config.Form>]Gip: Update'TippingTippingGip option
        ///<summary>Tipping configuration for HKD</summary>
        [<Config.Form>]Hkd: Update'TippingTippingHkd option
        ///<summary>Tipping configuration for HUF</summary>
        [<Config.Form>]Huf: Update'TippingTippingHuf option
        ///<summary>Tipping configuration for JPY</summary>
        [<Config.Form>]Jpy: Update'TippingTippingJpy option
        ///<summary>Tipping configuration for MXN</summary>
        [<Config.Form>]Mxn: Update'TippingTippingMxn option
        ///<summary>Tipping configuration for MYR</summary>
        [<Config.Form>]Myr: Update'TippingTippingMyr option
        ///<summary>Tipping configuration for NOK</summary>
        [<Config.Form>]Nok: Update'TippingTippingNok option
        ///<summary>Tipping configuration for NZD</summary>
        [<Config.Form>]Nzd: Update'TippingTippingNzd option
        ///<summary>Tipping configuration for PLN</summary>
        [<Config.Form>]Pln: Update'TippingTippingPln option
        ///<summary>Tipping configuration for RON</summary>
        [<Config.Form>]Ron: Update'TippingTippingRon option
        ///<summary>Tipping configuration for SEK</summary>
        [<Config.Form>]Sek: Update'TippingTippingSek option
        ///<summary>Tipping configuration for SGD</summary>
        [<Config.Form>]Sgd: Update'TippingTippingSgd option
        ///<summary>Tipping configuration for USD</summary>
        [<Config.Form>]Usd: Update'TippingTippingUsd option
    }
    with
        static member New(?aed: Update'TippingTippingAed, ?sek: Update'TippingTippingSek, ?ron: Update'TippingTippingRon, ?pln: Update'TippingTippingPln, ?nzd: Update'TippingTippingNzd, ?nok: Update'TippingTippingNok, ?myr: Update'TippingTippingMyr, ?mxn: Update'TippingTippingMxn, ?jpy: Update'TippingTippingJpy, ?sgd: Update'TippingTippingSgd, ?huf: Update'TippingTippingHuf, ?gip: Update'TippingTippingGip, ?gbp: Update'TippingTippingGbp, ?eur: Update'TippingTippingEur, ?dkk: Update'TippingTippingDkk, ?czk: Update'TippingTippingCzk, ?chf: Update'TippingTippingChf, ?cad: Update'TippingTippingCad, ?aud: Update'TippingTippingAud, ?hkd: Update'TippingTippingHkd, ?usd: Update'TippingTippingUsd) =
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

    type Update'VerifoneP400VerifoneP400 = {
        ///<summary>A File ID representing an image you want to display on the reader.</summary>
        [<Config.Form>]Splashscreen: Choice<string,string> option
    }
    with
        static member New(?splashscreen: Choice<string,string>) =
            {
                Splashscreen = splashscreen
            }

    type Update'WifiWifiEnterpriseEapPeap = {
        ///<summary>A File ID representing a PEM file containing the server certificate</summary>
        [<Config.Form>]CaCertificateFile: string option
        ///<summary>Password for connecting to the WiFi network</summary>
        [<Config.Form>]Password: string option
        ///<summary>Name of the WiFi network</summary>
        [<Config.Form>]Ssid: string option
        ///<summary>Username for connecting to the WiFi network</summary>
        [<Config.Form>]Username: string option
    }
    with
        static member New(?caCertificateFile: string, ?password: string, ?ssid: string, ?username: string) =
            {
                CaCertificateFile = caCertificateFile
                Password = password
                Ssid = ssid
                Username = username
            }

    type Update'WifiWifiEnterpriseEapTls = {
        ///<summary>A File ID representing a PEM file containing the server certificate</summary>
        [<Config.Form>]CaCertificateFile: string option
        ///<summary>A File ID representing a PEM file containing the client certificate</summary>
        [<Config.Form>]ClientCertificateFile: string option
        ///<summary>A File ID representing a PEM file containing the client RSA private key</summary>
        [<Config.Form>]PrivateKeyFile: string option
        ///<summary>Password for the private key file</summary>
        [<Config.Form>]PrivateKeyFilePassword: string option
        ///<summary>Name of the WiFi network</summary>
        [<Config.Form>]Ssid: string option
    }
    with
        static member New(?caCertificateFile: string, ?clientCertificateFile: string, ?privateKeyFile: string, ?privateKeyFilePassword: string, ?ssid: string) =
            {
                CaCertificateFile = caCertificateFile
                ClientCertificateFile = clientCertificateFile
                PrivateKeyFile = privateKeyFile
                PrivateKeyFilePassword = privateKeyFilePassword
                Ssid = ssid
            }

    type Update'WifiWifiPersonalPsk = {
        ///<summary>Password for connecting to the WiFi network</summary>
        [<Config.Form>]Password: string option
        ///<summary>Name of the WiFi network</summary>
        [<Config.Form>]Ssid: string option
    }
    with
        static member New(?password: string, ?ssid: string) =
            {
                Password = password
                Ssid = ssid
            }

    type Update'WifiWifiType =
    | EnterpriseEapPeap
    | EnterpriseEapTls
    | PersonalPsk

    type Update'WifiWifi = {
        ///<summary>Credentials for a WPA-Enterprise WiFi network using the EAP-PEAP authentication method.</summary>
        [<Config.Form>]EnterpriseEapPeap: Update'WifiWifiEnterpriseEapPeap option
        ///<summary>Credentials for a WPA-Enterprise WiFi network using the EAP-TLS authentication method.</summary>
        [<Config.Form>]EnterpriseEapTls: Update'WifiWifiEnterpriseEapTls option
        ///<summary>Credentials for a WPA-Personal WiFi network.</summary>
        [<Config.Form>]PersonalPsk: Update'WifiWifiPersonalPsk option
        ///<summary>Security type of the WiFi network. Fill out the hash with the corresponding name to provide the set of credentials for this security type.</summary>
        [<Config.Form>]Type: Update'WifiWifiType option
    }
    with
        static member New(?enterpriseEapPeap: Update'WifiWifiEnterpriseEapPeap, ?enterpriseEapTls: Update'WifiWifiEnterpriseEapTls, ?personalPsk: Update'WifiWifiPersonalPsk, ?type': Update'WifiWifiType) =
            {
                EnterpriseEapPeap = enterpriseEapPeap
                EnterpriseEapTls = enterpriseEapTls
                PersonalPsk = personalPsk
                Type = type'
            }

    type UpdateOptions = {
        [<Config.Path>]Configuration: string
        ///<summary>An object containing device type specific settings for BBPOS WisePad 3 readers.</summary>
        [<Config.Form>]BbposWisepad3: Choice<Update'BbposWisepad3BbposWisePad3,string> option
        ///<summary>An object containing device type specific settings for BBPOS WisePOS E readers.</summary>
        [<Config.Form>]BbposWiseposE: Choice<Update'BbposWiseposEBbposWisePose,string> option
        ///<summary>Configuration for cellular connectivity.</summary>
        [<Config.Form>]Cellular: Choice<Update'CellularCellular,string> option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Name of the configuration</summary>
        [<Config.Form>]Name: string option
        ///<summary>Configurations for collecting transactions offline.</summary>
        [<Config.Form>]Offline: Choice<Update'OfflineOffline,string> option
        ///<summary>Reboot time settings for readers. that support customized reboot time configuration.</summary>
        [<Config.Form>]RebootWindow: Choice<Update'RebootWindowRebootWindow,string> option
        ///<summary>An object containing device type specific settings for Stripe S700 readers.</summary>
        [<Config.Form>]StripeS700: Choice<Update'StripeS700StripeS700,string> option
        ///<summary>An object containing device type specific settings for Stripe S710 readers.</summary>
        [<Config.Form>]StripeS710: Choice<Update'StripeS710StripeS710,string> option
        ///<summary>Tipping configurations for readers that support on-reader tips.</summary>
        [<Config.Form>]Tipping: Choice<Update'TippingTipping,string> option
        ///<summary>An object containing device type specific settings for Verifone P400 readers.</summary>
        [<Config.Form>]VerifoneP400: Choice<Update'VerifoneP400VerifoneP400,string> option
        ///<summary>Configurations for connecting to a WiFi network.</summary>
        [<Config.Form>]Wifi: Choice<Update'WifiWifi,string> option
    }
    with
        static member New(configuration: string, ?bbposWisepad3: Choice<Update'BbposWisepad3BbposWisePad3,string>, ?bbposWiseposE: Choice<Update'BbposWiseposEBbposWisePose,string>, ?cellular: Choice<Update'CellularCellular,string>, ?expand: string list, ?name: string, ?offline: Choice<Update'OfflineOffline,string>, ?rebootWindow: Choice<Update'RebootWindowRebootWindow,string>, ?stripeS700: Choice<Update'StripeS700StripeS700,string>, ?stripeS710: Choice<Update'StripeS710StripeS710,string>, ?tipping: Choice<Update'TippingTipping,string>, ?verifoneP400: Choice<Update'VerifoneP400VerifoneP400,string>, ?wifi: Choice<Update'WifiWifi,string>) =
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

    ///<summary><p>Updates a new <code>Configuration</code> object.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/terminal/configurations/{options.Configuration}"
        |> RestApi.postAsync<_, TerminalConfiguration> settings (Map.empty) options

module TerminalConnectionTokens =

    type CreateOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The id of the location that this connection token is scoped to. If specified the connection token will only be usable with readers assigned to that location, otherwise the connection token will be usable with all readers. Note that location scoping only applies to internet-connected readers. For more details, see [the docs on scoping connection tokens](https://docs.stripe.com/terminal/fleet/locations-and-zones?dashboard-or-api=api#connection-tokens).</summary>
        [<Config.Form>]Location: string option
    }
    with
        static member New(?expand: string list, ?location: string) =
            {
                Expand = expand
                Location = location
            }

    ///<summary><p>To connect to a reader the Stripe Terminal SDK needs to retrieve a short-lived connection token from Stripe, proxied through your server. On your backend, add an endpoint that creates and returns a connection token.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/terminal/connection_tokens"
        |> RestApi.postAsync<_, TerminalConnectionToken> settings (Map.empty) options

module TerminalLocations =

    type ListOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<summary><p>Returns a list of <code>Location</code> objects.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/terminal/locations"
        |> RestApi.getAsync<StripeList<TerminalLocation>> settings qs

    type Create'Address = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'AddressKana = {
        ///<summary>City or ward.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Block or building number.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Building details.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>Postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>Prefecture.</summary>
        [<Config.Form>]State: string option
        ///<summary>Town or cho-me.</summary>
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'AddressKanji = {
        ///<summary>City or ward.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Block or building number.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Building details.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>Postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>Prefecture.</summary>
        [<Config.Form>]State: string option
        ///<summary>Town or cho-me.</summary>
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type CreateOptions = {
        ///<summary>The full address of the location.</summary>
        [<Config.Form>]Address: Create'Address option
        ///<summary>The Kana variation of the full address of the location (Japan only).</summary>
        [<Config.Form>]AddressKana: Create'AddressKana option
        ///<summary>The Kanji variation of the full address of the location (Japan only).</summary>
        [<Config.Form>]AddressKanji: Create'AddressKanji option
        ///<summary>The ID of a configuration that will be used to customize all readers in this location.</summary>
        [<Config.Form>]ConfigurationOverrides: string option
        ///<summary>A name for the location. Maximum length is 1000 characters.</summary>
        [<Config.Form>]DisplayName: string option
        ///<summary>The Kana variation of the name for the location (Japan only). Maximum length is 1000 characters.</summary>
        [<Config.Form>]DisplayNameKana: string option
        ///<summary>The Kanji variation of the name for the location (Japan only). Maximum length is 1000 characters.</summary>
        [<Config.Form>]DisplayNameKanji: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The phone number for the location.</summary>
        [<Config.Form>]Phone: string option
    }
    with
        static member New(?address: Create'Address, ?addressKana: Create'AddressKana, ?addressKanji: Create'AddressKanji, ?configurationOverrides: string, ?displayName: string, ?displayNameKana: string, ?displayNameKanji: string, ?expand: string list, ?metadata: Map<string, string>, ?phone: string) =
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

    ///<summary><p>Creates a new <code>Location</code> object.
    ///For further details, including which address fields are required in each country, see the <a href="/docs/terminal/fleet/locations">Manage locations</a> guide.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/terminal/locations"
        |> RestApi.postAsync<_, TerminalLocation> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Location: string
    }
    with
        static member New(location: string) =
            {
                Location = location
            }

    ///<summary><p>Deletes a <code>Location</code> object.</p></summary>
    let Delete settings (options: DeleteOptions) =
        $"/v1/terminal/locations/{options.Location}"
        |> RestApi.deleteAsync<DeletedTerminalLocation> settings (Map.empty)

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Location: string
    }
    with
        static member New(location: string, ?expand: string list) =
            {
                Expand = expand
                Location = location
            }

    ///<summary><p>Retrieves a <code>Location</code> object.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/terminal/locations/{options.Location}"
        |> RestApi.getAsync<TerminalLocation> settings qs

    type Update'Address = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'AddressKana = {
        ///<summary>City or ward.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Block or building number.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Building details.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>Postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>Prefecture.</summary>
        [<Config.Form>]State: string option
        ///<summary>Town or cho-me.</summary>
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Update'AddressKanji = {
        ///<summary>City or ward.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Block or building number.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Building details.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>Postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>Prefecture.</summary>
        [<Config.Form>]State: string option
        ///<summary>Town or cho-me.</summary>
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type UpdateOptions = {
        [<Config.Path>]Location: string
        ///<summary>The full address of the location. You can't change the location's `country`. If you need to modify the `country` field, create a new `Location` object and re-register any existing readers to that location.</summary>
        [<Config.Form>]Address: Update'Address option
        ///<summary>The Kana variation of the full address of the location (Japan only).</summary>
        [<Config.Form>]AddressKana: Update'AddressKana option
        ///<summary>The Kanji variation of the full address of the location (Japan only).</summary>
        [<Config.Form>]AddressKanji: Update'AddressKanji option
        ///<summary>The ID of a configuration that will be used to customize all readers in this location.</summary>
        [<Config.Form>]ConfigurationOverrides: Choice<string,string> option
        ///<summary>A name for the location.</summary>
        [<Config.Form>]DisplayName: Choice<string,string> option
        ///<summary>The Kana variation of the name for the location (Japan only).</summary>
        [<Config.Form>]DisplayNameKana: Choice<string,string> option
        ///<summary>The Kanji variation of the name for the location (Japan only).</summary>
        [<Config.Form>]DisplayNameKanji: Choice<string,string> option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The phone number for the location.</summary>
        [<Config.Form>]Phone: Choice<string,string> option
    }
    with
        static member New(location: string, ?address: Update'Address, ?addressKana: Update'AddressKana, ?addressKanji: Update'AddressKanji, ?configurationOverrides: Choice<string,string>, ?displayName: Choice<string,string>, ?displayNameKana: Choice<string,string>, ?displayNameKanji: Choice<string,string>, ?expand: string list, ?metadata: Map<string, string>, ?phone: Choice<string,string>) =
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

    ///<summary><p>Updates a <code>Location</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/terminal/locations/{options.Location}"
        |> RestApi.postAsync<_, TerminalLocation> settings (Map.empty) options

module TerminalOnboardingLinks =

    type Create'LinkOptionsAppleTermsAndConditions = {
        ///<summary>Whether the link should also support users relinking their Apple account.</summary>
        [<Config.Form>]AllowRelinking: bool option
        ///<summary>The business name of the merchant accepting Apple's Terms and Conditions.</summary>
        [<Config.Form>]MerchantDisplayName: string option
    }
    with
        static member New(?allowRelinking: bool, ?merchantDisplayName: string) =
            {
                AllowRelinking = allowRelinking
                MerchantDisplayName = merchantDisplayName
            }

    type Create'LinkOptions = {
        ///<summary>The options associated with the Apple Terms and Conditions link type.</summary>
        [<Config.Form>]AppleTermsAndConditions: Create'LinkOptionsAppleTermsAndConditions option
    }
    with
        static member New(?appleTermsAndConditions: Create'LinkOptionsAppleTermsAndConditions) =
            {
                AppleTermsAndConditions = appleTermsAndConditions
            }

    type Create'LinkType =
    | AppleTermsAndConditions

    type CreateOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Specific fields needed to generate the desired link type.</summary>
        [<Config.Form>]LinkOptions: Create'LinkOptions
        ///<summary>The type of link being generated.</summary>
        [<Config.Form>]LinkType: Create'LinkType
        ///<summary>Stripe account ID to generate the link for.</summary>
        [<Config.Form>]OnBehalfOf: string option
    }
    with
        static member New(linkOptions: Create'LinkOptions, linkType: Create'LinkType, ?expand: string list, ?onBehalfOf: string) =
            {
                Expand = expand
                LinkOptions = linkOptions
                LinkType = linkType
                OnBehalfOf = onBehalfOf
            }

    ///<summary><p>Creates a new <code>OnboardingLink</code> object that contains a redirect_url used for onboarding onto Tap to Pay on iPhone.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/terminal/onboarding_links"
        |> RestApi.postAsync<_, TerminalOnboardingLink> settings (Map.empty) options

module TerminalReaders =

    type ListOptions = {
        ///<summary>Filters readers by device type</summary>
        [<Config.Query>]DeviceType: string option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A location ID to filter the response list to only readers at the specific location</summary>
        [<Config.Query>]Location: string option
        ///<summary>Filters readers by serial number</summary>
        [<Config.Query>]SerialNumber: string option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>A status filter to filter readers to only offline or online readers</summary>
        [<Config.Query>]Status: string option
    }
    with
        static member New(?deviceType: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?location: string, ?serialNumber: string, ?startingAfter: string, ?status: string) =
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

    ///<summary><p>Returns a list of <code>Reader</code> objects.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("device_type", options.DeviceType |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("location", options.Location |> box); ("serial_number", options.SerialNumber |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/terminal/readers"
        |> RestApi.getAsync<StripeList<TerminalReader>> settings qs

    type CreateOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Custom label given to the reader for easier identification. If no label is specified, the registration code will be used.</summary>
        [<Config.Form>]Label: string option
        ///<summary>The location to assign the reader to.</summary>
        [<Config.Form>]Location: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>A code generated by the reader used for registering to an account.</summary>
        [<Config.Form>]RegistrationCode: string
    }
    with
        static member New(registrationCode: string, ?expand: string list, ?label: string, ?location: string, ?metadata: Map<string, string>) =
            {
                Expand = expand
                Label = label
                Location = location
                Metadata = metadata
                RegistrationCode = registrationCode
            }

    ///<summary><p>Creates a new <code>Reader</code> object.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/terminal/readers"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Reader: string
    }
    with
        static member New(reader: string) =
            {
                Reader = reader
            }

    ///<summary><p>Deletes a <code>Reader</code> object.</p></summary>
    let Delete settings (options: DeleteOptions) =
        $"/v1/terminal/readers/{options.Reader}"
        |> RestApi.deleteAsync<DeletedTerminalReader> settings (Map.empty)

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Reader: string
    }
    with
        static member New(reader: string, ?expand: string list) =
            {
                Expand = expand
                Reader = reader
            }

    ///<summary><p>Retrieves a <code>Reader</code> object.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/terminal/readers/{options.Reader}"
        |> RestApi.getAsync<TerminalReader> settings qs

    type UpdateOptions = {
        [<Config.Path>]Reader: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The new label of the reader.</summary>
        [<Config.Form>]Label: Choice<string,string> option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(reader: string, ?expand: string list, ?label: Choice<string,string>, ?metadata: Map<string, string>) =
            {
                Reader = reader
                Expand = expand
                Label = label
                Metadata = metadata
            }

    ///<summary><p>Updates a <code>Reader</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/terminal/readers/{options.Reader}"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TerminalReadersCancelAction =

    type CancelActionOptions = {
        [<Config.Path>]Reader: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(reader: string, ?expand: string list) =
            {
                Reader = reader
                Expand = expand
            }

    ///<summary><p>Cancels the current reader action. See <a href="/docs/terminal/payments/collect-card-payment?terminal-sdk-platform=server-driven#programmatic-cancellation">Programmatic Cancellation</a> for more details.</p></summary>
    let CancelAction settings (options: CancelActionOptions) =
        $"/v1/terminal/readers/{options.Reader}/cancel_action"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TerminalReadersCollectInputs =

    type CollectInputs'InputsCustomText = {
        ///<summary>The description which will be displayed when collecting this input</summary>
        [<Config.Form>]Description: string option
        ///<summary>Custom text for the skip button. Maximum 14 characters.</summary>
        [<Config.Form>]SkipButton: string option
        ///<summary>Custom text for the submit button. Maximum 30 characters.</summary>
        [<Config.Form>]SubmitButton: string option
        ///<summary>The title which will be displayed when collecting this input</summary>
        [<Config.Form>]Title: string option
    }
    with
        static member New(?description: string, ?skipButton: string, ?submitButton: string, ?title: string) =
            {
                Description = description
                SkipButton = skipButton
                SubmitButton = submitButton
                Title = title
            }

    type CollectInputs'InputsSelectionChoicesStyle =
    | Primary
    | Secondary

    type CollectInputs'InputsSelectionChoices = {
        ///<summary>The unique identifier for this choice</summary>
        [<Config.Form>]Id: string option
        ///<summary>The style of the button which will be shown for this choice. Can be `primary` or `secondary`.</summary>
        [<Config.Form>]Style: CollectInputs'InputsSelectionChoicesStyle option
        ///<summary>The text which will be shown on the button for this choice</summary>
        [<Config.Form>]Text: string option
    }
    with
        static member New(?id: string, ?style: CollectInputs'InputsSelectionChoicesStyle, ?text: string) =
            {
                Id = id
                Style = style
                Text = text
            }

    type CollectInputs'InputsSelection = {
        ///<summary>List of choices for the `selection` input</summary>
        [<Config.Form>]Choices: CollectInputs'InputsSelectionChoices list option
    }
    with
        static member New(?choices: CollectInputs'InputsSelectionChoices list) =
            {
                Choices = choices
            }

    type CollectInputs'InputsTogglesDefaultValue =
    | Disabled
    | Enabled

    type CollectInputs'InputsToggles = {
        ///<summary>The default value of the toggle. Can be `enabled` or `disabled`.</summary>
        [<Config.Form>]DefaultValue: CollectInputs'InputsTogglesDefaultValue option
        ///<summary>The description which will be displayed for the toggle. Maximum 50 characters. At least one of title or description must be provided.</summary>
        [<Config.Form>]Description: string option
        ///<summary>The title which will be displayed for the toggle. Maximum 50 characters. At least one of title or description must be provided.</summary>
        [<Config.Form>]Title: string option
    }
    with
        static member New(?defaultValue: CollectInputs'InputsTogglesDefaultValue, ?description: string, ?title: string) =
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

    type CollectInputs'Inputs = {
        ///<summary>Customize the text which will be displayed while collecting this input</summary>
        [<Config.Form>]CustomText: CollectInputs'InputsCustomText option
        ///<summary>Indicate that this input is required, disabling the skip button</summary>
        [<Config.Form>]Required: bool option
        ///<summary>Options for the `selection` input</summary>
        [<Config.Form>]Selection: CollectInputs'InputsSelection option
        ///<summary>List of toggles to be displayed and customization for the toggles</summary>
        [<Config.Form>]Toggles: CollectInputs'InputsToggles list option
        ///<summary>The type of input to collect</summary>
        [<Config.Form>]Type: CollectInputs'InputsType option
    }
    with
        static member New(?customText: CollectInputs'InputsCustomText, ?required: bool, ?selection: CollectInputs'InputsSelection, ?toggles: CollectInputs'InputsToggles list, ?type': CollectInputs'InputsType) =
            {
                CustomText = customText
                Required = required
                Selection = selection
                Toggles = toggles
                Type = type'
            }

    type CollectInputsOptions = {
        [<Config.Path>]Reader: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>List of inputs to be collected from the customer using the Reader. Maximum 5 inputs.</summary>
        [<Config.Form>]Inputs: CollectInputs'Inputs list
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(reader: string, inputs: CollectInputs'Inputs list, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Reader = reader
                Expand = expand
                Inputs = inputs
                Metadata = metadata
            }

    ///<summary><p>Initiates an <a href="/docs/terminal/features/collect-inputs">input collection flow</a> on a Reader to display input forms and collect information from your customers.</p></summary>
    let CollectInputs settings (options: CollectInputsOptions) =
        $"/v1/terminal/readers/{options.Reader}/collect_inputs"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TerminalReadersCollectPaymentMethod =

    type CollectPaymentMethod'CollectConfigTipping = {
        ///<summary>Amount used to calculate tip suggestions on tipping selection screen for this transaction. Must be a positive integer in the smallest currency unit (e.g., 100 cents to represent $1.00 or 100 to represent ¥100, a zero-decimal currency).</summary>
        [<Config.Form>]AmountEligible: int option
    }
    with
        static member New(?amountEligible: int) =
            {
                AmountEligible = amountEligible
            }

    type CollectPaymentMethod'CollectConfigAllowRedisplay =
    | Always
    | Limited
    | Unspecified

    type CollectPaymentMethod'CollectConfig = {
        ///<summary>This field indicates whether this payment method can be shown again to its customer in a checkout flow. Stripe products such as Checkout and Elements use this field to determine whether a payment method can be shown as a saved payment method in a checkout flow.</summary>
        [<Config.Form>]AllowRedisplay: CollectPaymentMethod'CollectConfigAllowRedisplay option
        ///<summary>Enables cancel button on transaction screens.</summary>
        [<Config.Form>]EnableCustomerCancellation: bool option
        ///<summary>Override showing a tipping selection screen on this transaction.</summary>
        [<Config.Form>]SkipTipping: bool option
        ///<summary>Tipping configuration for this transaction.</summary>
        [<Config.Form>]Tipping: CollectPaymentMethod'CollectConfigTipping option
    }
    with
        static member New(?allowRedisplay: CollectPaymentMethod'CollectConfigAllowRedisplay, ?enableCustomerCancellation: bool, ?skipTipping: bool, ?tipping: CollectPaymentMethod'CollectConfigTipping) =
            {
                AllowRedisplay = allowRedisplay
                EnableCustomerCancellation = enableCustomerCancellation
                SkipTipping = skipTipping
                Tipping = tipping
            }

    type CollectPaymentMethodOptions = {
        [<Config.Path>]Reader: string
        ///<summary>Configuration overrides for this collection, such as tipping, surcharging, and customer cancellation settings.</summary>
        [<Config.Form>]CollectConfig: CollectPaymentMethod'CollectConfig option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The ID of the PaymentIntent to collect a payment method for.</summary>
        [<Config.Form>]PaymentIntent: string
    }
    with
        static member New(reader: string, paymentIntent: string, ?collectConfig: CollectPaymentMethod'CollectConfig, ?expand: string list) =
            {
                Reader = reader
                CollectConfig = collectConfig
                Expand = expand
                PaymentIntent = paymentIntent
            }

    ///<summary><p>Initiates a payment flow on a Reader and updates the PaymentIntent with card details before manual confirmation. See <a href="/docs/terminal/payments/collect-card-payment?terminal-sdk-platform=server-driven&process=inspect#collect-a-paymentmethod">Collecting a Payment method</a> for more details.</p></summary>
    let CollectPaymentMethod settings (options: CollectPaymentMethodOptions) =
        $"/v1/terminal/readers/{options.Reader}/collect_payment_method"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TerminalReadersConfirmPaymentIntent =

    type ConfirmPaymentIntent'ConfirmConfig = {
        ///<summary>The URL to redirect your customer back to after they authenticate or cancel their payment on the payment method's app or site. If you'd prefer to redirect to a mobile application, you can alternatively supply an application URI scheme.</summary>
        [<Config.Form>]ReturnUrl: string option
    }
    with
        static member New(?returnUrl: string) =
            {
                ReturnUrl = returnUrl
            }

    type ConfirmPaymentIntentOptions = {
        [<Config.Path>]Reader: string
        ///<summary>Configuration overrides for this confirmation, such as surcharge settings and return URL.</summary>
        [<Config.Form>]ConfirmConfig: ConfirmPaymentIntent'ConfirmConfig option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The ID of the PaymentIntent to confirm.</summary>
        [<Config.Form>]PaymentIntent: string
    }
    with
        static member New(reader: string, paymentIntent: string, ?confirmConfig: ConfirmPaymentIntent'ConfirmConfig, ?expand: string list) =
            {
                Reader = reader
                ConfirmConfig = confirmConfig
                Expand = expand
                PaymentIntent = paymentIntent
            }

    ///<summary><p>Finalizes a payment on a Reader. See <a href="/docs/terminal/payments/collect-card-payment?terminal-sdk-platform=server-driven&process=inspect#confirm-the-paymentintent">Confirming a Payment</a> for more details.</p></summary>
    let ConfirmPaymentIntent settings (options: ConfirmPaymentIntentOptions) =
        $"/v1/terminal/readers/{options.Reader}/confirm_payment_intent"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TerminalReadersProcessPaymentIntent =

    type ProcessPaymentIntent'ProcessConfigTipping = {
        ///<summary>Amount used to calculate tip suggestions on tipping selection screen for this transaction. Must be a positive integer in the smallest currency unit (e.g., 100 cents to represent $1.00 or 100 to represent ¥100, a zero-decimal currency).</summary>
        [<Config.Form>]AmountEligible: int option
    }
    with
        static member New(?amountEligible: int) =
            {
                AmountEligible = amountEligible
            }

    type ProcessPaymentIntent'ProcessConfigAllowRedisplay =
    | Always
    | Limited
    | Unspecified

    type ProcessPaymentIntent'ProcessConfig = {
        ///<summary>This field indicates whether this payment method can be shown again to its customer in a checkout flow. Stripe products such as Checkout and Elements use this field to determine whether a payment method can be shown as a saved payment method in a checkout flow.</summary>
        [<Config.Form>]AllowRedisplay: ProcessPaymentIntent'ProcessConfigAllowRedisplay option
        ///<summary>Enables cancel button on transaction screens.</summary>
        [<Config.Form>]EnableCustomerCancellation: bool option
        ///<summary>The URL to redirect your customer back to after they authenticate or cancel their payment on the payment method's app or site. If you'd prefer to redirect to a mobile application, you can alternatively supply an application URI scheme.</summary>
        [<Config.Form>]ReturnUrl: string option
        ///<summary>Override showing a tipping selection screen on this transaction.</summary>
        [<Config.Form>]SkipTipping: bool option
        ///<summary>Tipping configuration for this transaction.</summary>
        [<Config.Form>]Tipping: ProcessPaymentIntent'ProcessConfigTipping option
    }
    with
        static member New(?allowRedisplay: ProcessPaymentIntent'ProcessConfigAllowRedisplay, ?enableCustomerCancellation: bool, ?returnUrl: string, ?skipTipping: bool, ?tipping: ProcessPaymentIntent'ProcessConfigTipping) =
            {
                AllowRedisplay = allowRedisplay
                EnableCustomerCancellation = enableCustomerCancellation
                ReturnUrl = returnUrl
                SkipTipping = skipTipping
                Tipping = tipping
            }

    type ProcessPaymentIntentOptions = {
        [<Config.Path>]Reader: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The ID of the PaymentIntent to process on the reader.</summary>
        [<Config.Form>]PaymentIntent: string
        ///<summary>Configuration overrides for this transaction, such as tipping and customer cancellation settings.</summary>
        [<Config.Form>]ProcessConfig: ProcessPaymentIntent'ProcessConfig option
    }
    with
        static member New(reader: string, paymentIntent: string, ?expand: string list, ?processConfig: ProcessPaymentIntent'ProcessConfig) =
            {
                Reader = reader
                Expand = expand
                PaymentIntent = paymentIntent
                ProcessConfig = processConfig
            }

    ///<summary><p>Initiates a payment flow on a Reader. See <a href="/docs/terminal/payments/collect-card-payment?terminal-sdk-platform=server-driven&process=immediately#process-payment">process the payment</a> for more details.</p></summary>
    let ProcessPaymentIntent settings (options: ProcessPaymentIntentOptions) =
        $"/v1/terminal/readers/{options.Reader}/process_payment_intent"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TerminalReadersProcessSetupIntent =

    type ProcessSetupIntent'ProcessConfig = {
        ///<summary>Enables cancel button on transaction screens.</summary>
        [<Config.Form>]EnableCustomerCancellation: bool option
    }
    with
        static member New(?enableCustomerCancellation: bool) =
            {
                EnableCustomerCancellation = enableCustomerCancellation
            }

    type ProcessSetupIntent'AllowRedisplay =
    | Always
    | Limited
    | Unspecified

    type ProcessSetupIntentOptions = {
        [<Config.Path>]Reader: string
        ///<summary>This field indicates whether this payment method can be shown again to its customer in a checkout flow. Stripe products such as Checkout and Elements use this field to determine whether a payment method can be shown as a saved payment method in a checkout flow.</summary>
        [<Config.Form>]AllowRedisplay: ProcessSetupIntent'AllowRedisplay
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Configuration overrides for this setup, such as MOTO and customer cancellation settings.</summary>
        [<Config.Form>]ProcessConfig: ProcessSetupIntent'ProcessConfig option
        ///<summary>The ID of the SetupIntent to process on the reader.</summary>
        [<Config.Form>]SetupIntent: string
    }
    with
        static member New(reader: string, allowRedisplay: ProcessSetupIntent'AllowRedisplay, setupIntent: string, ?expand: string list, ?processConfig: ProcessSetupIntent'ProcessConfig) =
            {
                Reader = reader
                AllowRedisplay = allowRedisplay
                Expand = expand
                ProcessConfig = processConfig
                SetupIntent = setupIntent
            }

    ///<summary><p>Initiates a SetupIntent flow on a Reader. See <a href="/docs/terminal/features/saving-payment-details/save-directly">Save directly without charging</a> for more details.</p></summary>
    let ProcessSetupIntent settings (options: ProcessSetupIntentOptions) =
        $"/v1/terminal/readers/{options.Reader}/process_setup_intent"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TerminalReadersRefundPayment =

    type RefundPayment'RefundPaymentConfig = {
        ///<summary>Enables cancel button on transaction screens.</summary>
        [<Config.Form>]EnableCustomerCancellation: bool option
    }
    with
        static member New(?enableCustomerCancellation: bool) =
            {
                EnableCustomerCancellation = enableCustomerCancellation
            }

    type RefundPaymentOptions = {
        [<Config.Path>]Reader: string
        ///<summary>A positive integer in __cents__ representing how much of this charge to refund.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>ID of the Charge to refund.</summary>
        [<Config.Form>]Charge: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>ID of the PaymentIntent to refund.</summary>
        [<Config.Form>]PaymentIntent: string option
        ///<summary>Boolean indicating whether the application fee should be refunded when refunding this charge. If a full charge refund is given, the full application fee will be refunded. Otherwise, the application fee will be refunded in an amount proportional to the amount of the charge refunded. An application fee can be refunded only by the application that created the charge.</summary>
        [<Config.Form>]RefundApplicationFee: bool option
        ///<summary>Configuration overrides for this refund, such as customer cancellation settings.</summary>
        [<Config.Form>]RefundPaymentConfig: RefundPayment'RefundPaymentConfig option
        ///<summary>Boolean indicating whether the transfer should be reversed when refunding this charge. The transfer will be reversed proportionally to the amount being refunded (either the entire or partial amount). A transfer can be reversed only by the application that created the charge.</summary>
        [<Config.Form>]ReverseTransfer: bool option
    }
    with
        static member New(reader: string, ?amount: int, ?charge: string, ?expand: string list, ?metadata: Map<string, string>, ?paymentIntent: string, ?refundApplicationFee: bool, ?refundPaymentConfig: RefundPayment'RefundPaymentConfig, ?reverseTransfer: bool) =
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

    ///<summary><p>Initiates an in-person refund on a Reader. See <a href="/docs/terminal/payments/regional?integration-country=CA#refund-an-interac-payment">Refund an Interac Payment</a> for more details.</p></summary>
    let RefundPayment settings (options: RefundPaymentOptions) =
        $"/v1/terminal/readers/{options.Reader}/refund_payment"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TerminalReadersSetReaderDisplay =

    type SetReaderDisplay'CartLineItems = {
        ///<summary>The price of the item in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).</summary>
        [<Config.Form>]Amount: int option
        ///<summary>The description or name of the item.</summary>
        [<Config.Form>]Description: string option
        ///<summary>The quantity of the line item being purchased.</summary>
        [<Config.Form>]Quantity: int option
    }
    with
        static member New(?amount: int, ?description: string, ?quantity: int) =
            {
                Amount = amount
                Description = description
                Quantity = quantity
            }

    type SetReaderDisplay'Cart = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>Array of line items to display.</summary>
        [<Config.Form>]LineItems: SetReaderDisplay'CartLineItems list option
        ///<summary>The amount of tax in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).</summary>
        [<Config.Form>]Tax: int option
        ///<summary>Total balance of cart due in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).</summary>
        [<Config.Form>]Total: int option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?lineItems: SetReaderDisplay'CartLineItems list, ?tax: int, ?total: int) =
            {
                Currency = currency
                LineItems = lineItems
                Tax = tax
                Total = total
            }

    type SetReaderDisplay'Type =
    | Cart

    type SetReaderDisplayOptions = {
        [<Config.Path>]Reader: string
        ///<summary>Cart details to display on the reader screen, including line items, amounts, and currency.</summary>
        [<Config.Form>]Cart: SetReaderDisplay'Cart option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Type of information to display. Only `cart` is currently supported.</summary>
        [<Config.Form>]Type: SetReaderDisplay'Type
    }
    with
        static member New(reader: string, type': SetReaderDisplay'Type, ?cart: SetReaderDisplay'Cart, ?expand: string list) =
            {
                Reader = reader
                Cart = cart
                Expand = expand
                Type = type'
            }

    ///<summary><p>Sets the reader display to show <a href="/docs/terminal/features/display">cart details</a>.</p></summary>
    let SetReaderDisplay settings (options: SetReaderDisplayOptions) =
        $"/v1/terminal/readers/{options.Reader}/set_reader_display"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options
