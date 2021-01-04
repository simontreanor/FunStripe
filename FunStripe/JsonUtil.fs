namespace FunStripe

open FSharp.Json
open Microsoft.FSharp.Reflection
open System
open System.Linq
open System.Reflection

module JsonUtil =
    
    ///JSON setting for snake-case formatting (Stripe uses snake-case, F# prefers pascal/camel case)
    let config = JsonConfig.create(allowUntyped = true, jsonFieldNaming = Json.snakeCase)

    ///Convert F# objects to JSON strings
    let serialise data =
        Json.serializeEx config data

    ///Convert JSON strings to F# objects
    let deserialise<'a> data =
        //printfn "%A" data //uncomment this to view the raw API response if tests fail
        let o = Json.deserializeEx<'a> config data
        //printfn "%A" o //uncomment this to view the parsed API response if tests fail
        o

    ///Get the name specified in the ```JsonUnionCase``` attribute (used to ensure correct naming of discriminated-union members where conventions are not followed)
    let getJsonUnionCaseName (value: obj) =
        let key = value |> string
        match value.GetType().UnderlyingSystemType.GetProperty(key) with
        | null ->
            config.jsonFieldNaming key
        | pi ->
            let name =
                pi.GetMethod.GetCustomAttributes(typeof<JsonUnionCase>, false).Cast<JsonUnionCase>()
                |> Seq.map(fun juc -> juc.Case)
                |> Seq.tryExactlyOne
            match name with
            | Some n -> n
            | None -> config.jsonFieldNaming key

    ///Get the name specified in the ```JsonField``` attribute (used to ensure correct naming of record/class members where conventions are not followed)
    let getJsonFieldName (value: obj) =
        let key = value |> string
        match value.GetType().UnderlyingSystemType.GetProperty(key) with
        | null ->
            config.jsonFieldNaming key
        | pi ->
            let name =
                pi.GetMethod.GetCustomAttributes(typeof<JsonField>, false).Cast<JsonField>()
                |> Seq.map(fun jf -> jf.Name)
                |> Seq.tryExactlyOne
            match name with
            | Some n -> n
            | None -> config.jsonFieldNaming key

    let getUnionCaseFromString<'a> (value: string) =
        typeof<'a>.UnderlyingSystemType.GetProperties()
        |> Array.map(fun pi ->
            pi.GetMethod.GetCustomAttributes(typeof<JsonField>, false).Cast<JsonField>()
            |> Seq.map(fun jf -> (pi.Name, jf.Name))
            |> Seq.tryExactlyOne
        )
        |> Array.choose id
        |> Array.tryFind(fun (_, jsonFieldName) -> jsonFieldName = value)
        |> Option.bind(fun (propertyName, _) ->
            match FSharpType.GetUnionCases typeof<'a> |> Array.filter (fun c -> c.Name = propertyName) with
            | [|c|] -> Some (FSharpValue.MakeUnion(c, [||]) :?> 'a)
            | _ -> None
        )
 
    ///Converts a string option to a strongly-typed union case, or a default strongly-typed value
    let optionToUnionCaseOr<'a> (defaultValue: 'a) (s: string option) =
        s |> Option.bind getUnionCaseFromString<'a> |> Option.defaultValue (defaultValue)

    ///Unwrap discriminated-union fields into the underlying object
    let unwrap (value: obj) =
        let _, fields = FSharpValue.GetUnionFields(value, value.GetType())
        fields.Cast<obj>()
        |> Seq.tryExactlyOne
        
    ///Wrap objects in discriminated-union fields
    let wrap<'a> (s: string) v =
        match FSharpType.GetUnionCases typeof<'a> |> Array.filter (fun uci -> uci.Name = s) with
        |[| uci |] -> Some(FSharpValue.MakeUnion(uci, [| v |]) :?> 'a)
        |_ -> None

    ///Get the types and underlying types of a discriminated union
    let getUnderlyingTypes<'a> () =
        typeof<'a>.GetMembers().Cast<MemberInfo>()
        |> Seq.filter(fun mi -> mi.MemberType = MemberTypes.NestedType)
        |> Seq.map(fun mi -> mi :?> Type)
        |> Seq.collect(fun t ->
            t.GetProperties()
            |> Seq.filter(fun pi -> pi.Name = "Item")
            |> Seq.map(fun pi -> (t, pi.PropertyType))
        )

    ///A non-generic variant of the `FSharp.Json.Json.deserialiseEx` function
    let jsonDeserializeEx (t: Type) (config: JsonConfig) (s: string) =
        let mi =
            Assembly.Load("FSharp.Json").GetTypes().Cast<Type>()
            |> Seq.find(fun t -> t.Name = "Json")
            |> (fun t -> t.GetMembers())
            |> Seq.find(fun mi -> mi.Name = "deserializeEx")
            |> (fun mi -> mi :?> MethodInfo)
        mi.MakeGenericMethod(t).Invoke(null, [| box config; box s |])

    ///Attribute for de-/serialising an `AnyOf` discriminated union
    type AnyOfTransform<'a>() =
        interface ITypeTransform with

            ///Specifies the target type, which is `obj` here to handle polymorphism
            member _.targetType () = (fun _ -> typeof<obj>) ()
        
            ///Serialise
            member this.toTargetType value = (unwrap >> Option.get >> box) value

            ///Deserialise
            member this.fromTargetType value =
                (
                    fun (o: obj) ->
                        getUnderlyingTypes<'a>()
                        |> Seq.pick(fun (t, ut) ->
                            (*  if the types match, wrap and return (note this function assumes all underlying types are different,
                                otherwise if there is more than one identical underlying type only the first is taken
                                (this is because there is no type info in the Stripe response for polymorphic fields)) *)
                            if o.GetType() = ut then
                                o
                                |> unbox
                                |> wrap<'a> (t.Name)
                            //FSharp.Json converts all numbers except floats to `decimal` internally, so we need to convert back
                            elif o.GetType() = typeof<decimal> && ut.FullName = "System.Int64" then
                                o
                                |> unbox
                                |> (fun (m: decimal) -> Convert.ToInt32 m)
                                |> wrap<'a> (t.Name)
                            else
                                try
                                    //FSharp.Json converts records wrapped in objects to `Map<string, string>`, but by round-tripping
                                    //the map through the serialiser as a typed object we get our strongly typed record back
                                    o
                                    |> Json.serializeEx config
                                    |> jsonDeserializeEx ut config
                                    |> unbox
                                    |> wrap<'a> (t.Name)
                                with
                                    //ignore non-matching types
                                    | ex ->
                                            None
                        )
                        |> box
                ) value
