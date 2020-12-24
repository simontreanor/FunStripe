namespace FunStripe

module Util =

    ///Pipe a sequence of results
    let (>=>) =
        fun result next -> result |> Result.bind (fun _ -> next)

    ///Map an array of results to a result of arrays
    let mapResults results =
        let oo = results |> Array.choose(function | Ok o -> Some o | _ -> None) 
        let ee = results |> Array.choose(function | Error o -> Some o | _ -> None)
        if ee |> Array.isEmpty then Ok oo else Error ee
