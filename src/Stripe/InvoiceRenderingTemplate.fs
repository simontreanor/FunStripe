namespace Stripe.InvoiceRenderingTemplate

open System.Text.Json.Serialization
open FunStripe
open System

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type InvoiceRenderingTemplateStatus =
    | Active
    | Archived

/// Invoice Rendering Templates are used to configure how invoices are rendered on surfaces like the PDF. Invoice Rendering Templates
/// can be created from within the Dashboard, and they can be used over the API when creating invoices.
type InvoiceRenderingTemplate =
    {
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// A brief description of the template, hidden from customers
        Nickname: string option
        /// The status of the template, one of `active` or `archived`.
        Status: InvoiceRenderingTemplateStatus
        /// Version of this template; version increases by one when an update on the template changes any field that controls invoice rendering
        Version: int
    }

type InvoiceRenderingTemplate with
    static member New(created: DateTime, id: string, livemode: bool, metadata: Map<string, string> option, nickname: string option, status: InvoiceRenderingTemplateStatus, version: int) =
        {
            Created = created
            Id = id
            Livemode = livemode
            Metadata = metadata
            Nickname = nickname
            Status = status
            Version = version
        }

module InvoiceRenderingTemplate =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "invoice_rendering_template"

