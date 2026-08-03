namespace FunStripe

///A raw JSON fragment preserved verbatim from the wire, used for fields whose schema is an
///untyped object (e.g. a webhook event's `data.object`, or `next_action.use_stripe_sdk`).
///Deserialise it into a concrete model with `Util.deserialiseRaw<'a>`.
type RawJson =
    | RawJson of string
    ///The raw JSON text of the fragment
    member this.Value = let (RawJson s) = this in s
