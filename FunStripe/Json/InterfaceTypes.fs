namespace FunStripe.Json

open System
open System.Text

/// Transformation between types
type ITypeTransform =
    /// Represents target type to transform to
    abstract member TargetType: unit -> Type
    /// Transform to target type
    abstract member ToTargetType: obj -> obj
    /// Transform from target type
    abstract member FromTargetType: obj -> obj

/// Controls Enum serialization
type EnumMode =
    /// Use default setting. Could be changed through [JsonConfig].
    | Default = 0
    /// Serialize Enum value as it's name
    | Name = 1
    /// Serialize Enum value as it's value
    | Value = 2

/// Attribute customizing serialization of members 
type JsonField (name: string) =
    inherit Attribute()
    /// Field name in JSON. Use null value to use record member name. Default value is null.
    member val public Name: string = name with get, set
    /// Controls weather member represents unmapped JSON. Default value is false.
    member val public AsJson: bool = false with get, set
    /// Tranform that should be applied to member. Default value is null.
    member val public Transform: Type = null with get, set
    /// Controls how Enum values should be represented. Default value is Name.
    member val public EnumValue: EnumMode = EnumMode.Default with get, set
    /// Sets default value for non option member. Default value is null.
    member val public DefaultValue: obj = null with get, set
    /// Controls default DateTime and DateTimeOffset formats. Default value is "yyyy-MM-ddTHH:mm:ss.fffffffK".
    member val public DateTimeFormat: string = "yyyy-MM-ddTHH:mm:ss.fffffffK" with get, set
    /// Creates default [JsonField] instance
    new () = JsonField(null)
with
    /// Default [JsonField].
    static member Default = JsonField()

/// Attribute customizing serialization of union cases
type JsonUnionCase (case: string) =
    inherit Attribute()
    /// Value that should be used for attributed union case. Default is null which means use F# case name.
    member val public Case: string = case with get, set
    /// Creates new [JsonUnionCase]
    new () = JsonUnionCase(null)
with
    /// Default [JsonUnion].
    static member Default = JsonUnionCase()

/// Represents one item in [JsonPath]
type JsonPathItem =
    /// Field in JSON object.
    | Field of string
    /// Item in JSON array.
    | ArrayItem of int

/// Represents path in JSON structure
type JsonPath = {
    /// Path represented as list of [JsonPathItem].
    Path: JsonPathItem list
}
with
    /// JSON root path.
    static member Root = { JsonPath.Path = [] }
    /// Creates new path from this by adding item to the end.
    member this.CreateNew (item: JsonPathItem) = { JsonPath.Path = this.Path @ [item] }
    /// Returns string representing JSON path.
    override this.ToString () =
        match this.Path.Length with
        | 0 -> ""
        | _ ->
            let value = StringBuilder()
            this.Path |> List.iteri (fun index location ->
                match location with
                | Field theProperty ->
                    if index <> 0 then value.Append "." |> ignore
                    value.Append theProperty |> ignore
                | ArrayItem item -> item |> sprintf "[%i]" |> value.Append |> ignore
            )
            value.ToString()

/// Fatal error during JSON serialization
type JsonSerializationError(message: string) =
    inherit Exception(message)

/// Fatal error during JSON deserialization
type JsonDeserializationError(path: JsonPath, message: string) =
    inherit Exception(message)
    /// JSON path pointing to the place in JSON where error happened.
    member e.Path = path

/// Modes of serialization of option None value
type SerializeNone =
    /// Serialize None value as null in JSON.
    | Null
    /// Omit members with None values in JSON.
    | Omit

/// Modes of deserialization of option types
type DeserializeOption =
    /// Allow members with None value to be omitted in JSON.
    | AllowOmit
    /// Require members with None value to have null value in JSON.
    | RequireNull

/// Represents field naming rule that is used during serialization from/to JSON.
type JsonFieldNaming = string -> string

/// Configuration for JSON serialization/deserialization
type JsonConfig = {
    /// Generates unformatted JSON if set to true. Default is false.
    Unformatted: bool
    /// Controls serialization of option None value. Default is SerializeNone.Null.
    SerializeNone: SerializeNone
    /// Controls deserialization of option types. Default is DeserializeOption.AllowOmit.
    DeserializeOption: DeserializeOption
    /// Sets JSON fields naming strategy. Default is `id` function.
    JsonFieldNaming: JsonFieldNaming
    /// Allows untyped data, like obj. Default is false.
    AllowUntyped: bool
    /// Controls serialization of enums. Default is EnumMode.Name
    EnumValue: EnumMode
}
with
    /// Creates customized [JsonConfig], each parameter corresponds to [JsonConfig] record member.
    static member Create (?unformatted, ?serializeNone, ?deserializeOption, ?jsonFieldNaming, ?allowUntyped, ?enumValue) =
        {
            JsonConfig.Unformatted = defaultArg unformatted false
            JsonConfig.SerializeNone = defaultArg serializeNone SerializeNone.Null
            JsonConfig.DeserializeOption = defaultArg deserializeOption DeserializeOption.AllowOmit
            JsonConfig.JsonFieldNaming = defaultArg jsonFieldNaming id
            JsonConfig.AllowUntyped = defaultArg allowUntyped false
            JsonConfig.EnumValue = defaultArg enumValue EnumMode.Name
        }
    /// Default [JsonConfig].
    static member Default = JsonConfig.Create()
    