// Applies the assembly-level Stripe API version attribute.
// This file must be compiled AFTER Config.fs so the attribute type is in scope.
//
// IMPORTANT: When the target Stripe API version changes, update the string literal
// below AND the `DefaultStripeApiVersion` constant in Config.fs AND the
// <StripeApiVersion> property in both .fsproj files.
module FunStripe.AssemblyInfo

[<assembly: FunStripe.Config.StripeApiVersionAttribute("2023-08-16")>]
do ()
