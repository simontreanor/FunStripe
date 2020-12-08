namespace FunStripe

[<AutoOpen>]
module ConstrainedTypes =
    open System

    type PositiveOrZeroInt = private PositiveOrZeroInt of int

    module PositiveOrZeroInt =

        let create i =
            match i with
            | i when i < 0 -> 0
            | i when i > 99999999 -> 99999999
            | _ -> i
        
        let value (PositiveOrZeroInt i) = i

