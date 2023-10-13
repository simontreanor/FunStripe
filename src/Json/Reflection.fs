namespace FunStripe.Json

module internal Reflection =
    open System
    open System.Reflection
    open System.Collections.Concurrent
    open Microsoft.FSharp.Reflection    

    let isOption' (t: Type): bool =
        t.IsGenericType && t.GetGenericTypeDefinition() = typedefof<option<_>>

    let getOptionType' (t: Type): Type =
        t.GetGenericArguments().[0]

    let isArray' (t: Type) =
        t.IsArray

    let isList' (t: Type) =
        t.IsGenericType && t.GetGenericTypeDefinition() = typedefof<List<_>>

    let getListType' (itemType: Type) =
        typedefof<List<_>>.MakeGenericType([| itemType |])

    let getListItemType' (t: Type) =
        t.GetGenericArguments().[0]

    let getListConstructor' (t: Type) =
        t.GetMethod ("Cons")

    let getListEmptyProperty' (t: Type) =
        t.GetProperty("Empty")

    let isMap' (t: Type) =
        t.IsGenericType && t.GetGenericTypeDefinition() = typedefof<Map<_,_>>

    let getMapKeyType' (t: Type) =
        t.GetGenericArguments().[0]

    let getMapValueType' (t: Type) =
        t.GetGenericArguments().[1]

    let getMapKvpTupleType' (t: Type) =
        t.GetGenericArguments() |> FSharpType.MakeTupleType

    let cacheResult (theFunction:'P -> 'R) =
        let theFunction = new Func<_, _>(theFunction)
        let cache = new ConcurrentDictionary<'P, 'R>()
        fun parameter -> cache.GetOrAdd(parameter, theFunction)

    let isRecord: Type -> bool = FSharpType.IsRecord |> cacheResult
    let getRecordFields: Type -> PropertyInfo [] = FSharpType.GetRecordFields |> cacheResult

    let isUnion: Type -> bool = FSharpType.IsUnion |> cacheResult
    let getUnionCases: Type -> UnionCaseInfo [] = FSharpType.GetUnionCases |> cacheResult

    let isTuple: Type -> bool = FSharpType.IsTuple |> cacheResult
    let getTupleElements: Type -> Type [] = FSharpType.GetTupleElements |> cacheResult

    let isOption: Type -> bool = isOption' |> cacheResult
    let getOptionType: Type -> Type = getOptionType' |> cacheResult

    let isArray: Type -> bool = isArray' |> cacheResult

    let isList: Type -> bool = isList' |> cacheResult
    let getListType: Type -> Type = getListType' |> cacheResult
    let getListItemType: Type -> Type = getListItemType' |> cacheResult
    let getListConstructor: Type -> MethodInfo = getListConstructor' |> cacheResult
    let getListEmptyProperty: Type -> PropertyInfo = getListEmptyProperty' |> cacheResult

    let isMap: Type -> bool = isMap' |> cacheResult
    let getMapKeyType: Type -> Type = getMapKeyType' |> cacheResult
    let getMapValueType: Type -> Type = getMapValueType' |> cacheResult
    let getMapKvpTupleType: Type -> Type = getMapKvpTupleType' |> cacheResult

    let unwrapOption (t: Type) (value: obj): obj option =
        let _, fields = FSharpValue.GetUnionFields(value, t)
        match fields.Length with
        | 1 -> Some fields.[0]
        | _ -> None

    let optionNone (t: Type): obj =
        let casesInfos = getUnionCases t
        FSharpValue.MakeUnion(casesInfos.[0], Array.empty)        

    let optionSome (t: Type) (value: obj): obj =
        let casesInfos = getUnionCases t
        FSharpValue.MakeUnion(casesInfos.[1], [| value |])

    let createList (itemType: Type) (items: obj list) =
        let listType = getListType itemType
        let theConstructor = getListConstructor listType
        let addItem item list = theConstructor.Invoke (null, [| item; list |])
        let theList = (getListEmptyProperty listType).GetValue(null)
        List.foldBack addItem items theList

    let KvpKey (value: obj): obj =
        let keyProperty = value.GetType().GetProperty("Key")
        keyProperty.GetValue(value, null)

    let KvpValue (value: obj): obj =
        let valueProperty = value.GetType().GetProperty("Value")
        valueProperty.GetValue(value, null)

    let CreateMap (mapType: Type) (items: (string*obj) list) =
        let theConstructor = mapType.GetConstructors().[0]
        let tupleType = getMapKvpTupleType mapType
        let listItems = items |> List.map (fun item -> FSharpValue.MakeTuple([|fst item; snd item|], tupleType))
        let theList = createList tupleType listItems
        theConstructor.Invoke([|theList|])
