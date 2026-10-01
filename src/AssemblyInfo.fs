// Applies the assembly-level Stripe API version attribute.
// This file must be compiled AFTER Config.fs so the attribute type is in scope.
// The version comes from the generated SpecInfo.ApiVersion, so it tracks the spec.
module FunStripe.AssemblyInfo

[<assembly: FunStripe.Config.StripeApiVersionAttribute(FunStripe.SpecInfo.ApiVersion)>]
do ()
