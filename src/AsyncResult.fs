namespace FunStripe

module AsyncResultCE =

    ///Defines an `AsyncResult` as a `Result` wrapped in an `Async`
    type AsyncResult<'ok,'error> = Async<Result<'ok,'error>>

    ///Builds the `AsyncResult` computation expression
    type AsyncResultBuilder() =

        member _.Bind(x: AsyncResult<'a, 'e>, f: 'a -> AsyncResult<'b, 'e>) : AsyncResult<'b, 'e> =
            async {
                let! xResult = x
                match xResult with
                | Ok x ->
                    return! f x
                | Error e ->
                    return (Error e)
            }

        member _.Return(x) : AsyncResult<_, _> =
            x
            |> Result.Ok
            |> async.Return

        member _.ReturnFrom(x: AsyncResult<_, _>) =
            x

        member _.ReturnFrom(x: Result<'a, 'e>) : AsyncResult<'a, 'e> =
            async.Return x

        member this.Zero() =
            this.Return ()

    ///Instantiates the `AsyncResult` computation expression
    let asyncResult = AsyncResultBuilder()

///Convenience functions for working with AsyncResult values
module AsyncResult =

    open AsyncResultCE

    ///Lift a plain value into AsyncResult
    let ofResult (r: Result<'a, 'e>) : AsyncResult<'a, 'e> =
        async.Return r

    ///Lift an Async computation into AsyncResult (the async cannot fail)
    let ofAsync (a: Async<'a>) : AsyncResult<'a, 'e> =
        async {
            let! v = a
            return Ok v
        }

    ///Transform the Ok value of an AsyncResult
    let map (f: 'a -> 'b) (x: AsyncResult<'a, 'e>) : AsyncResult<'b, 'e> =
        async {
            let! r = x
            return Result.map f r
        }

    ///Transform the Error value of an AsyncResult
    let mapError (f: 'e -> 'f) (x: AsyncResult<'a, 'e>) : AsyncResult<'a, 'f> =
        async {
            let! r = x
            return Result.mapError f r
        }
