namespace FunStripe

type AsyncResult<'ok,'error> = Async<Result<'ok,'error>>

[<AutoOpen>]
module AsyncResultCE =

    type AsyncResultBuilder() = 

        member __.Return(x) : AsyncResult<_,_> =
            x
            |> Result.Ok
            |> async.Return

        member __.Bind(x: AsyncResult<_, _>, f: 'a -> AsyncResult<'b,'c>) : AsyncResult<_,_> =
            async {
                let! xResult = x
                match xResult with
                | Ok x ->
                    return! f x
                | Error e ->
                    return (Error e)
            }

        member this.Zero() =
            this.Return ()

    let asyncResult = AsyncResultBuilder()
    