/// Form bodies stay on Stripe's host.
module FunStripe.RedirectTests

open System
open System.Net
open System.Net.Http
open System.Net.Sockets
open System.Text
open System.Threading.Tasks
open NUnit.Framework
open FunStripe

/// A local host that answers one request.
type private Host(answer: string) =
    let listener = new TcpListener(IPAddress.Loopback, 0)
    let mutable called = false
    do listener.Start()

    let served =
        task {
            try
                use! socket = listener.AcceptTcpClientAsync()
                called <- true
                use stream = socket.GetStream()
                let buffer = Array.zeroCreate 16384
                let! _ = stream.ReadAsync(buffer, 0, buffer.Length)
                let bytes = Encoding.ASCII.GetBytes answer
                do! stream.WriteAsync(bytes, 0, bytes.Length)
            with
            | :? SocketException
            | :? ObjectDisposedException -> ()
        }

    member _.Port = (listener.LocalEndpoint :?> IPEndPoint).Port
    member _.Called = called
    member _.Served: Task = served

    interface IDisposable with
        member _.Dispose() = listener.Stop()

let private okAnswer = "HTTP/1.1 200 OK\r\nContent-Length: 2\r\nConnection: close\r\n\r\n{}"

let private redirectTo (port: int) =
    $"HTTP/1.1 307 Moved\r\nLocation: http://127.0.0.1:{port}/stolen\r\nContent-Length: 0\r\nConnection: close\r\n\r\n"

let private settingsFor (port: int) =
    RestApi.StripeApiSettings.New(apiKey = "sk_test_x", baseUrl = $"http://127.0.0.1:{port}")

[<Test>]
let ``a redirected request is an error, and the other host is never called`` () : Task =
    task {
        use other = new Host(okAnswer)
        use first = new Host(redirectTo other.Port)
        let! result = RestApi.getAsync<obj> (settingsFor first.Port) Map.empty "/v1/customers" |> Async.StartAsTask
        do! first.Served
        match result with
        | Error e -> Assert.That(e.StripeError.Message.Value, Does.Contain "307")
        | Ok _ -> Assert.Fail "A redirect isn't a success"
        Assert.That(other.Called, Is.False)
    }
