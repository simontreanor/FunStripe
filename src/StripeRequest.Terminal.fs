namespace FunStripe.StripeRequest

open FunStripe
open FunStripe.Json
open FunStripe.StripeModel
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module TerminalConfigurations =

    type ListOptions = {
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///if present, only return the account default or non-default configurations.
        [<Config.Query>]IsAccountDefault: bool option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
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

    ///<p>Returns a list of <code>Configuration</code> objects.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("is_account_default", options.IsAccountDefault |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/terminal/configurations"
        |> RestApi.getAsync<TerminalConfiguration list> settings qs

    type Create'BbposWiseposE = {
        ///A File ID representing an image you would like displayed on the reader.
        [<Config.Form>]Splashscreen: Choice<string,string> option
    }
    with
        static member New(?splashscreen: Choice<string,string>) =
            {
                Splashscreen = splashscreen
            }

    type Create'TippingTippingAud = {
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Tipping configuration for AUD
        [<Config.Form>]Aud: Create'TippingTippingAud option
        ///Tipping configuration for CAD
        [<Config.Form>]Cad: Create'TippingTippingCad option
        ///Tipping configuration for CHF
        [<Config.Form>]Chf: Create'TippingTippingChf option
        ///Tipping configuration for CZK
        [<Config.Form>]Czk: Create'TippingTippingCzk option
        ///Tipping configuration for DKK
        [<Config.Form>]Dkk: Create'TippingTippingDkk option
        ///Tipping configuration for EUR
        [<Config.Form>]Eur: Create'TippingTippingEur option
        ///Tipping configuration for GBP
        [<Config.Form>]Gbp: Create'TippingTippingGbp option
        ///Tipping configuration for HKD
        [<Config.Form>]Hkd: Create'TippingTippingHkd option
        ///Tipping configuration for MYR
        [<Config.Form>]Myr: Create'TippingTippingMyr option
        ///Tipping configuration for NOK
        [<Config.Form>]Nok: Create'TippingTippingNok option
        ///Tipping configuration for NZD
        [<Config.Form>]Nzd: Create'TippingTippingNzd option
        ///Tipping configuration for SEK
        [<Config.Form>]Sek: Create'TippingTippingSek option
        ///Tipping configuration for SGD
        [<Config.Form>]Sgd: Create'TippingTippingSgd option
        ///Tipping configuration for USD
        [<Config.Form>]Usd: Create'TippingTippingUsd option
    }
    with
        static member New(?aud: Create'TippingTippingAud, ?cad: Create'TippingTippingCad, ?chf: Create'TippingTippingChf, ?czk: Create'TippingTippingCzk, ?dkk: Create'TippingTippingDkk, ?eur: Create'TippingTippingEur, ?gbp: Create'TippingTippingGbp, ?hkd: Create'TippingTippingHkd, ?myr: Create'TippingTippingMyr, ?nok: Create'TippingTippingNok, ?nzd: Create'TippingTippingNzd, ?sek: Create'TippingTippingSek, ?sgd: Create'TippingTippingSgd, ?usd: Create'TippingTippingUsd) =
            {
                Aud = aud
                Cad = cad
                Chf = chf
                Czk = czk
                Dkk = dkk
                Eur = eur
                Gbp = gbp
                Hkd = hkd
                Myr = myr
                Nok = nok
                Nzd = nzd
                Sek = sek
                Sgd = sgd
                Usd = usd
            }

    type Create'VerifoneP400 = {
        ///A File ID representing an image you would like displayed on the reader.
        [<Config.Form>]Splashscreen: Choice<string,string> option
    }
    with
        static member New(?splashscreen: Choice<string,string>) =
            {
                Splashscreen = splashscreen
            }

    type CreateOptions = {
        ///An object containing device type specific settings for BBPOS WisePOS E readers
        [<Config.Form>]BbposWiseposE: Create'BbposWiseposE option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Tipping configurations for readers supporting on-reader tips
        [<Config.Form>]Tipping: Choice<Create'TippingTipping,string> option
        ///An object containing device type specific settings for Verifone P400 readers
        [<Config.Form>]VerifoneP400: Create'VerifoneP400 option
    }
    with
        static member New(?bbposWiseposE: Create'BbposWiseposE, ?expand: string list, ?tipping: Choice<Create'TippingTipping,string>, ?verifoneP400: Create'VerifoneP400) =
            {
                BbposWiseposE = bbposWiseposE
                Expand = expand
                Tipping = tipping
                VerifoneP400 = verifoneP400
            }

    ///<p>Creates a new <code>Configuration</code> object.</p>
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

    ///<p>Deletes a <code>Configuration</code> object.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/terminal/configurations/{options.Configuration}"
        |> RestApi.deleteAsync<DeletedTerminalConfiguration> settings (Map.empty)

    type RetrieveOptions = {
        [<Config.Path>]Configuration: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(configuration: string, ?expand: string list) =
            {
                Configuration = configuration
                Expand = expand
            }

    ///<p>Retrieves a <code>Configuration</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/terminal/configurations/{options.Configuration}"
        |> RestApi.getAsync<TerminalConfiguration> settings qs

    type Update'BbposWiseposEBbposWisePose = {
        ///A File ID representing an image you would like displayed on the reader.
        [<Config.Form>]Splashscreen: Choice<string,string> option
    }
    with
        static member New(?splashscreen: Choice<string,string>) =
            {
                Splashscreen = splashscreen
            }

    type Update'TippingTippingAud = {
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Fixed amounts displayed when collecting a tip
        [<Config.Form>]FixedAmounts: int list option
        ///Percentages displayed when collecting a tip
        [<Config.Form>]Percentages: int list option
        ///Below this amount, fixed amounts will be displayed; above it, percentages will be displayed
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
        ///Tipping configuration for AUD
        [<Config.Form>]Aud: Update'TippingTippingAud option
        ///Tipping configuration for CAD
        [<Config.Form>]Cad: Update'TippingTippingCad option
        ///Tipping configuration for CHF
        [<Config.Form>]Chf: Update'TippingTippingChf option
        ///Tipping configuration for CZK
        [<Config.Form>]Czk: Update'TippingTippingCzk option
        ///Tipping configuration for DKK
        [<Config.Form>]Dkk: Update'TippingTippingDkk option
        ///Tipping configuration for EUR
        [<Config.Form>]Eur: Update'TippingTippingEur option
        ///Tipping configuration for GBP
        [<Config.Form>]Gbp: Update'TippingTippingGbp option
        ///Tipping configuration for HKD
        [<Config.Form>]Hkd: Update'TippingTippingHkd option
        ///Tipping configuration for MYR
        [<Config.Form>]Myr: Update'TippingTippingMyr option
        ///Tipping configuration for NOK
        [<Config.Form>]Nok: Update'TippingTippingNok option
        ///Tipping configuration for NZD
        [<Config.Form>]Nzd: Update'TippingTippingNzd option
        ///Tipping configuration for SEK
        [<Config.Form>]Sek: Update'TippingTippingSek option
        ///Tipping configuration for SGD
        [<Config.Form>]Sgd: Update'TippingTippingSgd option
        ///Tipping configuration for USD
        [<Config.Form>]Usd: Update'TippingTippingUsd option
    }
    with
        static member New(?aud: Update'TippingTippingAud, ?cad: Update'TippingTippingCad, ?chf: Update'TippingTippingChf, ?czk: Update'TippingTippingCzk, ?dkk: Update'TippingTippingDkk, ?eur: Update'TippingTippingEur, ?gbp: Update'TippingTippingGbp, ?hkd: Update'TippingTippingHkd, ?myr: Update'TippingTippingMyr, ?nok: Update'TippingTippingNok, ?nzd: Update'TippingTippingNzd, ?sek: Update'TippingTippingSek, ?sgd: Update'TippingTippingSgd, ?usd: Update'TippingTippingUsd) =
            {
                Aud = aud
                Cad = cad
                Chf = chf
                Czk = czk
                Dkk = dkk
                Eur = eur
                Gbp = gbp
                Hkd = hkd
                Myr = myr
                Nok = nok
                Nzd = nzd
                Sek = sek
                Sgd = sgd
                Usd = usd
            }

    type Update'VerifoneP400VerifoneP400 = {
        ///A File ID representing an image you would like displayed on the reader.
        [<Config.Form>]Splashscreen: Choice<string,string> option
    }
    with
        static member New(?splashscreen: Choice<string,string>) =
            {
                Splashscreen = splashscreen
            }

    type UpdateOptions = {
        [<Config.Path>]Configuration: string
        ///An object containing device type specific settings for BBPOS WisePOS E readers
        [<Config.Form>]BbposWiseposE: Choice<Update'BbposWiseposEBbposWisePose,string> option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Tipping configurations for readers supporting on-reader tips
        [<Config.Form>]Tipping: Choice<Update'TippingTipping,string> option
        ///An object containing device type specific settings for Verifone P400 readers
        [<Config.Form>]VerifoneP400: Choice<Update'VerifoneP400VerifoneP400,string> option
    }
    with
        static member New(configuration: string, ?bbposWiseposE: Choice<Update'BbposWiseposEBbposWisePose,string>, ?expand: string list, ?tipping: Choice<Update'TippingTipping,string>, ?verifoneP400: Choice<Update'VerifoneP400VerifoneP400,string>) =
            {
                Configuration = configuration
                BbposWiseposE = bbposWiseposE
                Expand = expand
                Tipping = tipping
                VerifoneP400 = verifoneP400
            }

    ///<p>Updates a new <code>Configuration</code> object.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/terminal/configurations/{options.Configuration}"
        |> RestApi.postAsync<_, TerminalConfiguration> settings (Map.empty) options

module TerminalConnectionTokens =

    type CreateOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The id of the location that this connection token is scoped to. If specified the connection token will only be usable with readers assigned to that location, otherwise the connection token will be usable with all readers. Note that location scoping only applies to internet-connected readers. For more details, see [the docs on scoping connection tokens](https://stripe.com/docs/terminal/fleet/locations#connection-tokens).
        [<Config.Form>]Location: string option
    }
    with
        static member New(?expand: string list, ?location: string) =
            {
                Expand = expand
                Location = location
            }

    ///<p>To connect to a reader the Stripe Terminal SDK needs to retrieve a short-lived connection token from Stripe, proxied through your server. On your backend, add an endpoint that creates and returns a connection token.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/terminal/connection_tokens"
        |> RestApi.postAsync<_, TerminalConnectionToken> settings (Map.empty) options

module TerminalLocations =

    type ListOptions = {
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
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

    ///<p>Returns a list of <code>Location</code> objects.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/terminal/locations"
        |> RestApi.getAsync<TerminalLocation list> settings qs

    type Create'Address = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type CreateOptions = {
        ///The full address of the location.
        [<Config.Form>]Address: Create'Address
        ///The ID of a configuration that will be used to customize all readers in this location.
        [<Config.Form>]ConfigurationOverrides: string option
        ///A name for the location.
        [<Config.Form>]DisplayName: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(address: Create'Address, displayName: string, ?configurationOverrides: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Address = address
                ConfigurationOverrides = configurationOverrides
                DisplayName = displayName
                Expand = expand
                Metadata = metadata
            }

    ///<p>Creates a new <code>Location</code> object.
    ///For further details, including which address fields are required in each country, see the <a href="/docs/terminal/fleet/locations">Manage locations</a> guide.</p>
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

    ///<p>Deletes a <code>Location</code> object.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/terminal/locations/{options.Location}"
        |> RestApi.deleteAsync<DeletedTerminalLocation> settings (Map.empty)

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Location: string
    }
    with
        static member New(location: string, ?expand: string list) =
            {
                Expand = expand
                Location = location
            }

    ///<p>Retrieves a <code>Location</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/terminal/locations/{options.Location}"
        |> RestApi.getAsync<TerminalLocation> settings qs

    type Update'Address = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type UpdateOptions = {
        [<Config.Path>]Location: string
        ///The full address of the location.
        [<Config.Form>]Address: Update'Address option
        ///The ID of a configuration that will be used to customize all readers in this location.
        [<Config.Form>]ConfigurationOverrides: Choice<string,string> option
        ///A name for the location.
        [<Config.Form>]DisplayName: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(location: string, ?address: Update'Address, ?configurationOverrides: Choice<string,string>, ?displayName: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Location = location
                Address = address
                ConfigurationOverrides = configurationOverrides
                DisplayName = displayName
                Expand = expand
                Metadata = metadata
            }

    ///<p>Updates a <code>Location</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/terminal/locations/{options.Location}"
        |> RestApi.postAsync<_, TerminalLocation> settings (Map.empty) options

module TerminalReaders =

    type ListOptions = {
        ///Filters readers by device type
        [<Config.Query>]DeviceType: string option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A location ID to filter the response list to only readers at the specific location
        [<Config.Query>]Location: string option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///A status filter to filter readers to only offline or online readers
        [<Config.Query>]Status: string option
    }
    with
        static member New(?deviceType: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?location: string, ?startingAfter: string, ?status: string) =
            {
                DeviceType = deviceType
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Location = location
                StartingAfter = startingAfter
                Status = status
            }

    ///<p>Returns a list of <code>Reader</code> objects.</p>
    let List settings (options: ListOptions) =
        let qs = [("device_type", options.DeviceType |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("location", options.Location |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/terminal/readers"
        |> RestApi.getAsync<TerminalReader list> settings qs

    type CreateOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Custom label given to the reader for easier identification. If no label is specified, the registration code will be used.
        [<Config.Form>]Label: string option
        ///The location to assign the reader to.
        [<Config.Form>]Location: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///A code generated by the reader used for registering to an account.
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

    ///<p>Creates a new <code>Reader</code> object.</p>
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

    ///<p>Deletes a <code>Reader</code> object.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/terminal/readers/{options.Reader}"
        |> RestApi.deleteAsync<DeletedTerminalReader> settings (Map.empty)

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Reader: string
    }
    with
        static member New(reader: string, ?expand: string list) =
            {
                Expand = expand
                Reader = reader
            }

    ///<p>Retrieves a <code>Reader</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/terminal/readers/{options.Reader}"
        |> RestApi.getAsync<TerminalReader> settings qs

    type UpdateOptions = {
        [<Config.Path>]Reader: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The new label of the reader.
        [<Config.Form>]Label: Choice<string,string> option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
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

    ///<p>Updates a <code>Reader</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/terminal/readers/{options.Reader}"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TerminalReadersCancelAction =

    type CancelActionOptions = {
        [<Config.Path>]Reader: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(reader: string, ?expand: string list) =
            {
                Reader = reader
                Expand = expand
            }

    ///<p>Cancels the current reader action.</p>
    let CancelAction settings (options: CancelActionOptions) =
        $"/v1/terminal/readers/{options.Reader}/cancel_action"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TerminalReadersProcessPaymentIntent =

    type ProcessPaymentIntent'ProcessConfigTipping = {
        ///Amount used to calculate tip suggestions on tipping selection screen for this transaction. Must be a positive integer in the smallest currency unit (e.g., 100 cents to represent $1.00 or 100 to represent ¥100, a zero-decimal currency).
        [<Config.Form>]AmountEligible: int option
    }
    with
        static member New(?amountEligible: int) =
            {
                AmountEligible = amountEligible
            }

    type ProcessPaymentIntent'ProcessConfig = {
        ///Override showing a tipping selection screen on this transaction.
        [<Config.Form>]SkipTipping: bool option
        ///Tipping configuration for this transaction.
        [<Config.Form>]Tipping: ProcessPaymentIntent'ProcessConfigTipping option
    }
    with
        static member New(?skipTipping: bool, ?tipping: ProcessPaymentIntent'ProcessConfigTipping) =
            {
                SkipTipping = skipTipping
                Tipping = tipping
            }

    type ProcessPaymentIntentOptions = {
        [<Config.Path>]Reader: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///PaymentIntent ID
        [<Config.Form>]PaymentIntent: string
        ///Configuration overrides
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

    ///<p>Initiates a payment flow on a Reader.</p>
    let ProcessPaymentIntent settings (options: ProcessPaymentIntentOptions) =
        $"/v1/terminal/readers/{options.Reader}/process_payment_intent"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TerminalReadersProcessSetupIntent =

    type ProcessSetupIntentOptions = {
        [<Config.Path>]Reader: string
        ///Customer Consent Collected
        [<Config.Form>]CustomerConsentCollected: bool
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Configuration overrides
        [<Config.Form>]ProcessConfig: string option
        ///SetupIntent ID
        [<Config.Form>]SetupIntent: string
    }
    with
        static member New(reader: string, customerConsentCollected: bool, setupIntent: string, ?expand: string list, ?processConfig: string) =
            {
                Reader = reader
                CustomerConsentCollected = customerConsentCollected
                Expand = expand
                ProcessConfig = processConfig
                SetupIntent = setupIntent
            }

    ///<p>Initiates a setup intent flow on a Reader.</p>
    let ProcessSetupIntent settings (options: ProcessSetupIntentOptions) =
        $"/v1/terminal/readers/{options.Reader}/process_setup_intent"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TerminalReadersRefundPayment =

    type RefundPaymentOptions = {
        [<Config.Path>]Reader: string
        ///A positive integer in __cents__ representing how much of this charge to refund.
        [<Config.Form>]Amount: int option
        ///ID of the Charge to refund.
        [<Config.Form>]Charge: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///ID of the PaymentIntent to refund.
        [<Config.Form>]PaymentIntent: string option
        ///Boolean indicating whether the application fee should be refunded when refunding this charge. If a full charge refund is given, the full application fee will be refunded. Otherwise, the application fee will be refunded in an amount proportional to the amount of the charge refunded. An application fee can be refunded only by the application that created the charge.
        [<Config.Form>]RefundApplicationFee: bool option
        ///Boolean indicating whether the transfer should be reversed when refunding this charge. The transfer will be reversed proportionally to the amount being refunded (either the entire or partial amount). A transfer can be reversed only by the application that created the charge.
        [<Config.Form>]ReverseTransfer: bool option
    }
    with
        static member New(reader: string, ?amount: int, ?charge: string, ?expand: string list, ?metadata: Map<string, string>, ?paymentIntent: string, ?refundApplicationFee: bool, ?reverseTransfer: bool) =
            {
                Reader = reader
                Amount = amount
                Charge = charge
                Expand = expand
                Metadata = metadata
                PaymentIntent = paymentIntent
                RefundApplicationFee = refundApplicationFee
                ReverseTransfer = reverseTransfer
            }

    ///<p>Initiates a refund on a Reader</p>
    let RefundPayment settings (options: RefundPaymentOptions) =
        $"/v1/terminal/readers/{options.Reader}/refund_payment"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options

module TerminalReadersSetReaderDisplay =

    type SetReaderDisplay'CartLineItems = {
        ///The price of the item in cents.
        [<Config.Form>]Amount: int option
        ///The description or name of the item.
        [<Config.Form>]Description: string option
        ///The quantity of the line item being purchased.
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
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///Array of line items that were purchased.
        [<Config.Form>]LineItems: SetReaderDisplay'CartLineItems list option
        ///The amount of tax in cents.
        [<Config.Form>]Tax: int option
        ///Total balance of cart due in cents.
        [<Config.Form>]Total: int option
    }
    with
        static member New(?currency: string, ?lineItems: SetReaderDisplay'CartLineItems list, ?tax: int, ?total: int) =
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
        ///Cart
        [<Config.Form>]Cart: SetReaderDisplay'Cart option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Type
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

    ///<p>Sets reader display to show cart details.</p>
    let SetReaderDisplay settings (options: SetReaderDisplayOptions) =
        $"/v1/terminal/readers/{options.Reader}/set_reader_display"
        |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) options
