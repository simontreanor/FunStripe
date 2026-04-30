namespace StripeRequest.Disputes

open FunStripe
open System.Text.Json.Serialization
open Stripe.Payment
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
module Disputes =

    type ListOptions =
        {
            /// Only return disputes associated to the charge specified by this charge ID.
            [<Config.Query>]
            Charge: string option
            /// Only return disputes that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// Only return disputes associated to the PaymentIntent specified by this PaymentIntent ID.
            [<Config.Query>]
            PaymentIntent: string option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    module ListOptions =
        let create
            (
                charge: string option,
                created: int option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                paymentIntent: string option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              Charge = charge
              Created = created
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              PaymentIntent = paymentIntent
              StartingAfter = startingAfter
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Dispute: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    module RetrieveOptions =
        let create
            (
                dispute: string,
                expand: string list option
            ) : RetrieveOptions
            =
            {
              Dispute = dispute
              Expand = expand
            }

    type Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3DisputedTransactionMerchandiseOrServices =
        | Merchandise
        | Services

    type Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3DisputedTransactionShippingAddress =
        {
            /// City, district, suburb, town, or village.
            [<Config.Form>]
            City: Choice<string,string> option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: Choice<IsoTypes.IsoCountryCode,string> option
            /// Address line 1, such as the street, PO Box, or company name.
            [<Config.Form>]
            Line1: Choice<string,string> option
            /// Address line 2, such as the apartment, suite, unit, or building.
            [<Config.Form>]
            Line2: Choice<string,string> option
            /// ZIP or postal code.
            [<Config.Form>]
            PostalCode: Choice<string,string> option
            /// State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
            [<Config.Form>]
            State: Choice<string,string> option
        }

    module Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3DisputedTransactionShippingAddress =
        let create
            (
                city: Choice<string,string> option,
                country: Choice<IsoTypes.IsoCountryCode,string> option,
                line1: Choice<string,string> option,
                line2: Choice<string,string> option,
                postalCode: Choice<string,string> option,
                state: Choice<string,string> option
            ) : Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3DisputedTransactionShippingAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3DisputedTransaction =
        {
            /// User Account ID used to log into business platform. Must be recognizable by the user.
            [<Config.Form>]
            CustomerAccountId: Choice<string,string> option
            /// Unique identifier of the cardholder’s device derived from a combination of at least two hardware and software attributes. Must be at least 20 characters.
            [<Config.Form>]
            CustomerDeviceFingerprint: Choice<string,string> option
            /// Unique identifier of the cardholder’s device such as a device serial number (e.g., International Mobile Equipment Identity [IMEI]). Must be at least 15 characters.
            [<Config.Form>]
            CustomerDeviceId: Choice<string,string> option
            /// The email address of the customer.
            [<Config.Form>]
            CustomerEmailAddress: Choice<string,string> option
            /// The IP address that the customer used when making the purchase.
            [<Config.Form>]
            CustomerPurchaseIp: Choice<string,string> option
            /// Categorization of disputed payment.
            [<Config.Form>]
            MerchandiseOrServices:
                Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3DisputedTransactionMerchandiseOrServices option
            /// A description of the product or service that was sold.
            [<Config.Form>]
            ProductDescription: Choice<string,string> option
            /// The address to which a physical product was shipped. All fields are required for Visa Compelling Evidence 3.0 evidence submission.
            [<Config.Form>]
            ShippingAddress:
                Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3DisputedTransactionShippingAddress option
        }

    module Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3DisputedTransaction =
        let create
            (
                customerAccountId: Choice<string,string> option,
                customerDeviceFingerprint: Choice<string,string> option,
                customerDeviceId: Choice<string,string> option,
                customerEmailAddress: Choice<string,string> option,
                customerPurchaseIp: Choice<string,string> option,
                merchandiseOrServices: Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3DisputedTransactionMerchandiseOrServices option,
                productDescription: Choice<string,string> option,
                shippingAddress: Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3DisputedTransactionShippingAddress option
            ) : Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3DisputedTransaction
            =
            {
              CustomerAccountId = customerAccountId
              CustomerDeviceFingerprint = customerDeviceFingerprint
              CustomerDeviceId = customerDeviceId
              CustomerEmailAddress = customerEmailAddress
              CustomerPurchaseIp = customerPurchaseIp
              MerchandiseOrServices = merchandiseOrServices
              ProductDescription = productDescription
              ShippingAddress = shippingAddress
            }

    type Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3PriorUndisputedTransactionsShippingAddress =
        {
            /// City, district, suburb, town, or village.
            [<Config.Form>]
            City: Choice<string,string> option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: Choice<IsoTypes.IsoCountryCode,string> option
            /// Address line 1, such as the street, PO Box, or company name.
            [<Config.Form>]
            Line1: Choice<string,string> option
            /// Address line 2, such as the apartment, suite, unit, or building.
            [<Config.Form>]
            Line2: Choice<string,string> option
            /// ZIP or postal code.
            [<Config.Form>]
            PostalCode: Choice<string,string> option
            /// State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
            [<Config.Form>]
            State: Choice<string,string> option
        }

    module Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3PriorUndisputedTransactionsShippingAddress =
        let create
            (
                city: Choice<string,string> option,
                country: Choice<IsoTypes.IsoCountryCode,string> option,
                line1: Choice<string,string> option,
                line2: Choice<string,string> option,
                postalCode: Choice<string,string> option,
                state: Choice<string,string> option
            ) : Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3PriorUndisputedTransactionsShippingAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3PriorUndisputedTransactions =
        {
            /// Stripe charge ID for the Visa Compelling Evidence 3.0 eligible prior charge.
            [<Config.Form>]
            Charge: string option
            /// User Account ID used to log into business platform. Must be recognizable by the user.
            [<Config.Form>]
            CustomerAccountId: Choice<string,string> option
            /// Unique identifier of the cardholder’s device derived from a combination of at least two hardware and software attributes. Must be at least 20 characters.
            [<Config.Form>]
            CustomerDeviceFingerprint: Choice<string,string> option
            /// Unique identifier of the cardholder’s device such as a device serial number (e.g., International Mobile Equipment Identity [IMEI]). Must be at least 15 characters.
            [<Config.Form>]
            CustomerDeviceId: Choice<string,string> option
            /// The email address of the customer.
            [<Config.Form>]
            CustomerEmailAddress: Choice<string,string> option
            /// The IP address that the customer used when making the purchase.
            [<Config.Form>]
            CustomerPurchaseIp: Choice<string,string> option
            /// A description of the product or service that was sold.
            [<Config.Form>]
            ProductDescription: Choice<string,string> option
            /// The address to which a physical product was shipped. All fields are required for Visa Compelling Evidence 3.0 evidence submission.
            [<Config.Form>]
            ShippingAddress:
                Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3PriorUndisputedTransactionsShippingAddress option
        }

    module Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3PriorUndisputedTransactions =
        let create
            (
                charge: string option,
                customerAccountId: Choice<string,string> option,
                customerDeviceFingerprint: Choice<string,string> option,
                customerDeviceId: Choice<string,string> option,
                customerEmailAddress: Choice<string,string> option,
                customerPurchaseIp: Choice<string,string> option,
                productDescription: Choice<string,string> option,
                shippingAddress: Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3PriorUndisputedTransactionsShippingAddress option
            ) : Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3PriorUndisputedTransactions
            =
            {
              Charge = charge
              CustomerAccountId = customerAccountId
              CustomerDeviceFingerprint = customerDeviceFingerprint
              CustomerDeviceId = customerDeviceId
              CustomerEmailAddress = customerEmailAddress
              CustomerPurchaseIp = customerPurchaseIp
              ProductDescription = productDescription
              ShippingAddress = shippingAddress
            }

    type Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3 =
        {
            /// Disputed transaction details for Visa Compelling Evidence 3.0 evidence submission.
            [<Config.Form>]
            DisputedTransaction:
                Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3DisputedTransaction option
            /// List of exactly two prior undisputed transaction objects for Visa Compelling Evidence 3.0 evidence submission.
            [<Config.Form>]
            PriorUndisputedTransactions:
                Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3PriorUndisputedTransactions list option
        }

    module Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3 =
        let create
            (
                disputedTransaction: Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3DisputedTransaction option,
                priorUndisputedTransactions: Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3PriorUndisputedTransactions list option
            ) : Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3
            =
            {
              DisputedTransaction = disputedTransaction
              PriorUndisputedTransactions = priorUndisputedTransactions
            }

    type Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompliance =
        {
            /// A field acknowledging the fee incurred when countering a Visa compliance dispute. If this field is set to true, evidence can be submitted for the compliance dispute. Stripe collects a 500 USD (or local equivalent) amount to cover the network costs associated with resolving compliance disputes. Stripe refunds the 500 USD network fee if you win the dispute.
            [<Config.Form>]
            FeeAcknowledged: bool option
        }

    module Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompliance =
        let create
            (
                feeAcknowledged: bool option
            ) : Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompliance
            =
            {
              FeeAcknowledged = feeAcknowledged
            }

    type Update'EvidenceEnhancedEvidenceEnhancedEvidence =
        {
            /// Evidence provided for Visa Compelling Evidence 3.0 evidence submission.
            [<Config.Form>]
            VisaCompellingEvidence3: Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3 option
            /// Evidence provided for Visa compliance evidence submission.
            [<Config.Form>]
            VisaCompliance: Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompliance option
        }

    module Update'EvidenceEnhancedEvidenceEnhancedEvidence =
        let create
            (
                visaCompellingEvidence3: Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompellingEvidence3 option,
                visaCompliance: Update'EvidenceEnhancedEvidenceEnhancedEvidenceVisaCompliance option
            ) : Update'EvidenceEnhancedEvidenceEnhancedEvidence
            =
            {
              VisaCompellingEvidence3 = visaCompellingEvidence3
              VisaCompliance = visaCompliance
            }

    type Update'Evidence =
        {
            /// Any server or activity logs showing proof that the customer accessed or downloaded the purchased digital product. This information should include IP addresses, corresponding timestamps, and any detailed recorded activity. Has a maximum character count of 20,000.
            [<Config.Form>]
            AccessActivityLog: string option
            /// The billing address provided by the customer.
            [<Config.Form>]
            BillingAddress: string option
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Your subscription cancellation policy, as shown to the customer.
            [<Config.Form>]
            CancellationPolicy: string option
            /// An explanation of how and when the customer was shown your refund policy prior to purchase. Has a maximum character count of 20,000.
            [<Config.Form>]
            CancellationPolicyDisclosure: string option
            /// A justification for why the customer's subscription was not canceled. Has a maximum character count of 20,000.
            [<Config.Form>]
            CancellationRebuttal: string option
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Any communication with the customer that you feel is relevant to your case. Examples include emails proving that the customer received the product or service, or demonstrating their use of or satisfaction with the product or service.
            [<Config.Form>]
            CustomerCommunication: string option
            /// The email address of the customer.
            [<Config.Form>]
            CustomerEmailAddress: string option
            /// The name of the customer.
            [<Config.Form>]
            CustomerName: string option
            /// The IP address that the customer used when making the purchase.
            [<Config.Form>]
            CustomerPurchaseIp: string option
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) A relevant document or contract showing the customer's signature.
            [<Config.Form>]
            CustomerSignature: string option
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Documentation for the prior charge that can uniquely identify the charge, such as a receipt, shipping label, work order, etc. This document should be paired with a similar document from the disputed payment that proves the two payments are separate.
            [<Config.Form>]
            DuplicateChargeDocumentation: string option
            /// An explanation of the difference between the disputed charge versus the prior charge that appears to be a duplicate. Has a maximum character count of 20,000.
            [<Config.Form>]
            DuplicateChargeExplanation: string option
            /// The Stripe ID for the prior charge which appears to be a duplicate of the disputed charge.
            [<Config.Form>]
            DuplicateChargeId: string option
            /// Additional evidence for qualifying evidence programs.
            [<Config.Form>]
            EnhancedEvidence: Choice<Update'EvidenceEnhancedEvidenceEnhancedEvidence,string> option
            /// A description of the product or service that was sold. Has a maximum character count of 20,000.
            [<Config.Form>]
            ProductDescription: string option
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Any receipt or message sent to the customer notifying them of the charge.
            [<Config.Form>]
            Receipt: string option
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Your refund policy, as shown to the customer.
            [<Config.Form>]
            RefundPolicy: string option
            /// Documentation demonstrating that the customer was shown your refund policy prior to purchase. Has a maximum character count of 20,000.
            [<Config.Form>]
            RefundPolicyDisclosure: string option
            /// A justification for why the customer is not entitled to a refund. Has a maximum character count of 20,000.
            [<Config.Form>]
            RefundRefusalExplanation: string option
            /// The date on which the customer received or began receiving the purchased service, in a clear human-readable format.
            [<Config.Form>]
            ServiceDate: string option
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Documentation showing proof that a service was provided to the customer. This could include a copy of a signed contract, work order, or other form of written agreement.
            [<Config.Form>]
            ServiceDocumentation: string option
            /// The address to which a physical product was shipped. You should try to include as complete address information as possible.
            [<Config.Form>]
            ShippingAddress: string option
            /// The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc. If multiple carriers were used for this purchase, please separate them with commas.
            [<Config.Form>]
            ShippingCarrier: string option
            /// The date on which a physical product began its route to the shipping address, in a clear human-readable format.
            [<Config.Form>]
            ShippingDate: string option
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Documentation showing proof that a product was shipped to the customer at the same address the customer provided to you. This could include a copy of the shipment receipt, shipping label, etc. It should show the customer's full shipping address, if possible.
            [<Config.Form>]
            ShippingDocumentation: string option
            /// The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
            [<Config.Form>]
            ShippingTrackingNumber: string option
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Any additional evidence or statements.
            [<Config.Form>]
            UncategorizedFile: string option
            /// Any additional evidence or statements. Has a maximum character count of 20,000.
            [<Config.Form>]
            UncategorizedText: string option
        }

    module Update'Evidence =
        let create
            (
                accessActivityLog: string option,
                billingAddress: string option,
                cancellationPolicy: string option,
                cancellationPolicyDisclosure: string option,
                cancellationRebuttal: string option,
                customerCommunication: string option,
                customerEmailAddress: string option,
                customerName: string option,
                customerPurchaseIp: string option,
                customerSignature: string option,
                duplicateChargeDocumentation: string option,
                duplicateChargeExplanation: string option,
                duplicateChargeId: string option,
                enhancedEvidence: Choice<Update'EvidenceEnhancedEvidenceEnhancedEvidence,string> option,
                productDescription: string option,
                receipt: string option,
                refundPolicy: string option,
                refundPolicyDisclosure: string option,
                refundRefusalExplanation: string option,
                serviceDate: string option,
                serviceDocumentation: string option,
                shippingAddress: string option,
                shippingCarrier: string option,
                shippingDate: string option,
                shippingDocumentation: string option,
                shippingTrackingNumber: string option,
                uncategorizedFile: string option,
                uncategorizedText: string option
            ) : Update'Evidence
            =
            {
              AccessActivityLog = accessActivityLog
              BillingAddress = billingAddress
              CancellationPolicy = cancellationPolicy
              CancellationPolicyDisclosure = cancellationPolicyDisclosure
              CancellationRebuttal = cancellationRebuttal
              CustomerCommunication = customerCommunication
              CustomerEmailAddress = customerEmailAddress
              CustomerName = customerName
              CustomerPurchaseIp = customerPurchaseIp
              CustomerSignature = customerSignature
              DuplicateChargeDocumentation = duplicateChargeDocumentation
              DuplicateChargeExplanation = duplicateChargeExplanation
              DuplicateChargeId = duplicateChargeId
              EnhancedEvidence = enhancedEvidence
              ProductDescription = productDescription
              Receipt = receipt
              RefundPolicy = refundPolicy
              RefundPolicyDisclosure = refundPolicyDisclosure
              RefundRefusalExplanation = refundRefusalExplanation
              ServiceDate = serviceDate
              ServiceDocumentation = serviceDocumentation
              ShippingAddress = shippingAddress
              ShippingCarrier = shippingCarrier
              ShippingDate = shippingDate
              ShippingDocumentation = shippingDocumentation
              ShippingTrackingNumber = shippingTrackingNumber
              UncategorizedFile = uncategorizedFile
              UncategorizedText = uncategorizedText
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Dispute: string
            /// Evidence to upload, to respond to a dispute. Updating any field in the hash will submit all fields in the hash for review. The combined character count of all fields is limited to 150,000.
            [<Config.Form>]
            Evidence: Update'Evidence option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Whether to immediately submit evidence to the bank. If `false`, evidence is staged on the dispute. Staged evidence is visible in the API and Dashboard, and can be submitted to the bank by making another request with this attribute set to `true` (the default).
            [<Config.Form>]
            Submit: bool option
        }

    module UpdateOptions =
        let create
            (
                dispute: string,
                evidence: Update'Evidence option,
                expand: string list option,
                metadata: Map<string, string> option,
                submit: bool option
            ) : UpdateOptions
            =
            {
              Dispute = dispute
              Evidence = evidence
              Expand = expand
              Metadata = metadata
              Submit = submit
            }

    ///<p>Returns a list of your disputes.</p>
    let List settings (options: ListOptions) =
        let qs = [("charge", options.Charge |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("payment_intent", options.PaymentIntent |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/disputes"
        |> RestApi.getAsync<StripeList<Dispute>> settings qs

    ///<p>Retrieves the dispute with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/disputes/{options.Dispute}"
        |> RestApi.getAsync<Dispute> settings qs

    ///<p>When you get a dispute, contacting your customer is always the best first step. If that doesn’t work, you can submit evidence to help us resolve the dispute in your favor. You can do this in your <a href="https://dashboard.stripe.com/disputes">dashboard</a>, but if you prefer, you can use the API to submit evidence programmatically.</p>
    ///<p>Depending on your dispute type, different evidence fields will give you a better chance of winning your dispute. To figure out which evidence fields to provide, see our <a href="/docs/disputes/categories">guide to dispute types</a>.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/disputes/{options.Dispute}"
        |> RestApi.postAsync<_, Dispute> settings (Map.empty) options

module DisputesClose =

    type CloseOptions =
        {
            [<Config.Path>]
            Dispute: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module CloseOptions =
        let create
            (
                dispute: string,
                expand: string list option
            ) : CloseOptions
            =
            {
              Dispute = dispute
              Expand = expand
            }

    ///<p>Closing the dispute for a charge indicates that you do not have any evidence to submit and are essentially dismissing the dispute, acknowledging it as lost.</p>
    ///<p>The status of the dispute will change from <code>needs_response</code> to <code>lost</code>. <em>Closing a dispute is irreversible</em>.</p>
    let Close settings (options: CloseOptions) =
        $"/v1/disputes/{options.Dispute}/close"
        |> RestApi.postAsync<_, Dispute> settings (Map.empty) options

