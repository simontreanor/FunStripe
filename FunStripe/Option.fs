namespace FunStripe

[<AutoOpen>]
module Option =

    type OptionBuilder() =
        member __.Bind(m, f) = Option.bind f m

        member this.Combine (a,b) = 
            match a,b with
            | Some a', Some b' ->
                printfn "combining %A and %A" a' b' 
                Some (a' + b')
            | Some a', None ->
                printfn "combining %A with None" a' 
                Some a'
            | None, Some b' ->
                printfn "combining None with %A" b' 
                Some b'
            | None, None ->
                printfn "combining None with None"
                None

        member __.Return(x) = Some x

        member this.Zero() =
            this.Return ()

    let option = OptionBuilder()
