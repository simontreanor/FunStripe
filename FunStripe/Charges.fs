namespace FunStripe

open Common

module Charges =

    type Charge = {
        /// Unique identifier for the object.
        Id: string

        /// String representing the object's type. Objects of the same type share the same value.
        Object: string

        /// Amount intended to be collected by this payment. A positive integer representing how
        /// much to charge in the <a href="https://stripe.com/docs/currencies#zero-decimal">smallest
        /// currency unit</a> (e.g., 100 cents to charge $1.00 or 100 to charge ¥100, a zero-decimal
        /// currency). The minimum amount is $0.50 US or
        /// <a href="https://stripe.com/docs/currencies#minimum-and-maximum-charge-amounts">equivalent
        /// in charge currency</a>. The amount value supports up to eight digits (e.g., a value of
        /// 99999999 for a USD charge of $999,999.99).
        Amount: int

        /// Amount in %s captured (can be less than the amount attribute on the charge if a partial
        /// capture was made).
        AmountCaptured: int

        /// Amount in %s refunded (can be less than the amount attribute on the charge if a partial
        /// refund was issued).
        AmountRefunded: int

        /// The amount of the application fee (if any) requested for the charge. <a
        /// href="https://stripe.com/docs/connect/direct-charges#collecting-fees">See the Connect
        /// documentation</a> for details.
        ApplicationFeeAmount: int option

        /// Authorization code on the charge.
        AuthorizationCode: string

        ///Billing information associated with the payment method at the time of the transaction.
        BillingDetails: Common.BillingDetails

        /// The full statement descriptor that is passed to card networks, and that is displayed on
        /// your customers' credit card and bank statements. Allows you to see what the statement
        /// descriptor looks like after the static and dynamic portions are combined.
        CalculatedStatementDescriptor: string

        /// If the charge was created without capturing, this Boolean represents whether it is still
        /// uncaptured or has since been captured.
        Captured: bool

        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: System.DateTime

        /// Three-letter <a href="https://www.iso.org/iso-4217-currency-codes.html">ISO currency
        /// code</a>, in lowercase. Must be a <a href="https://stripe.com/docs/currencies">supported
        /// currency</a>.
        Currency: string

        /// An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string

        /// Whether the charge has been disputed.
        Disputed: bool

        /// Error code explaining reason for charge failure if available (see <a
        /// href="https://stripe.com/docs/api#errors">the errors section</a> for a list of codes).
        FailureCode: string

        /// Message to user further explaining reason for charge failure if available.
        FailureMessage: string

        /// Information on fraud assessments for the charge.
        FraudDetails: FraudDetails

        /// Has the value <c>true</c> if the object exists in live mode or the value <c>false</c> if
        /// the object exists in test mode.
        Livemode: bool

        /// Set of <a href="https://stripe.com/docs/api/metadata">key-value pairs</a> that you can
        /// attach to an object. This can be useful for storing additional information about the
        /// object in a structured format.
        Metadata: Map<string, string>

        /// Details about whether the payment was accepted, and why. See <a
        /// href="https://stripe.com/docs/declines">understanding declines</a> for details.
        Outcome: Outcome

        /// <c>true</c> if the charge succeeded, or was successfully authorized for later capture.
        Paid: bool

        /// ID of the payment method used in this charge.
        PaymentMethod: string

        /// Details about the payment method at the time of the transaction.
        PaymentMethodDetails: PaymentMethodDetails.PaymentMethodDetail

        /// This is the email address that the receipt for this charge was sent to.
        ReceiptEmail: string

        /// This is the transaction number that appears on email receipts sent for this charge. This
        /// attribute will be <c>null</c> until a receipt has been sent.
        ReceiptNumber: string

        /// This is the URL to view the receipt for this charge. The receipt is kept up-to-date to
        /// the latest state of the charge, including any refunds. If the charge is for an Invoice,
        /// the receipt will be stylized as an Invoice receipt.
        ReceiptUrl: string

        /// Whether the charge has been fully refunded. If the charge is only partially refunded,
        /// this attribute will still be false.
        Refunded: bool

        /// A list of refunds that have been applied to the charge.
        Refunds: RefundList

        /// Shipping information for the charge.
        Shipping: Shipping

        /// For card charges, use <c>statement_descriptor_suffix</c> instead. Otherwise, you can use
        /// this value as the complete description of a charge on your customers’ statements. Must
        /// contain at least one letter, maximum 22 characters.
        StatementDescriptor: string

        /// Provides information about the charge that customers see on their statements.
        /// Concatenated with the prefix (shortened descriptor) or statement descriptor that’s set
        /// on the account to form the complete statement descriptor. Maximum 22 characters for the
        /// concatenated descriptor.
        StatementDescriptorSuffix: string

        /// The status of the payment is either <c>succeeded</c>, <c>pending</c>, or <c>failed</c>.
        Status: string

        /// An optional dictionary including the account to automatically transfer to as part of a
        /// destination charge. <a href="https://stripe.com/docs/connect/destination-charges">See
        /// the Connect documentation</a> for details.
        TransferData: TransferData

        /// A string that identifies this transaction as part of a group. See the <a
        /// href="https://stripe.com/docs/connect/charges-transfers#transfer-options">Connect
        /// documentation</a> for details.
        TransferGroup: string
    }

    and FraudDetails = {
        /// Assessments from Stripe.
        StripeReport: StripeReport option
        /// Assessments reported by you.
        UserReport: UserReport option
    }

    and StripeReport =
        | Fraudulent

    and UserReport =
        | Fraudulent
        | Safe

    and Outcome = {
        /// The value <c>reversed_after_approval</c> indicates the payment was
        /// <a href="https://stripe.com/docs/declines#blocked-payments">blocked by Stripe</a> after
        /// bank authorization, and may temporarily appear as "pending" on a cardholder's statement.
        NetworkStatus: NetworkStatus

        /// An enumerated value providing a more detailed explanation of the outcome's <c>type</c>.
        /// See <a href="https://stripe.com/docs/declines">understanding declines</a> for more details.
        Reason: OutcomeReason

        /// Stripe Radar's evaluation of the riskiness of the payment. Possible values for evaluated
        /// payments are <c>normal</c>, <c>elevated</c>, <c>highest</c>. For non-card payments, and
        /// card-based payments predating the public assignment of risk levels, this field will have
        /// the value <c>not_assessed</c>. In the event of an error in the evaluation, this field
        /// will have the value <c>unknown</c>. This field is only available with Radar.
        RiskLevel: RiskLevel

        /// Stripe Radar's evaluation of the riskiness of the payment. Possible values for evaluated
        /// payments are between 0 and 100. For non-card payments, card-based payments predating the
        /// public assignment of risk scores, or in the event of an error during evaluation, this
        /// field will not be present. This field is only available with Radar for Fraud Teams.
        RiskScore: int option

        /// A human-readable description of the outcome type and reason, designed for you (the
        /// recipient of the payment), not your customer.
        SellerMessage: string

        /// See <a href="https://stripe.com/docs/declines">understanding declines</a> and
        /// <a href="https://stripe.com/docs/radar/reviews">Radar reviews</a> for details.
        Type: Type
    }

    and NetworkStatus =
        | ApprovedByNetwork
        | DeclinedByNetwork
        | NotSentToNetwork
        | ReversedAfterApproval

    and OutcomeReason =
        ///Charges placed in review by Radar's default review rule
        | ElevatedRiskLevel
        ///Charges blocked by Radar's default block rule
        | HighestRiskLevel
        ///Charges authorized, blocked, or placed in review by custom rules
        | Rule
    
    and RiskLevel =
        | Elevated
        | Highest
        | Normal
        | NotAssessed
        | Unknown

    and Type =
        | Authorized
        | Blocked
        | Invalid
        | IssuerDeclined
        | ManualReview

    and RefundList = {
        ///String representing the object’s type. Objects of the same type share the same value. Always has the value list.
        Object: string

        ///Details about each object.
        Data: Refund list

        ///True if this list has another page of items after this one that can be fetched.
        HasMore: bool

        ///The URL where this list can be accessed.
        Url: string
    }

    and Refund = {
        /// Unique identifier for the object.
        Id: string

        /// String representing the object's type. Objects of the same type share the same value.
        Object: string

        /// Amount, in pence.
        Amount: int

        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: System.DateTime

        /// Three-letter <a href="https://www.iso.org/iso-4217-currency-codes.html">ISO currency code</a>,
        /// in lowercase. Must be a <a href="https://stripe.com/docs/currencies">supported currency</a>.
        Currency: string

        /// An arbitrary string attached to the object. Often useful for displaying to users.
        /// (Available on non-card refunds only).
        Description: string option

        /// If the refund failed, the reason for refund failure if known.
        FailureReason: FailureReason

        /// Set of <a href="https://stripe.com/docs/api/metadata">key-value pairs</a> that you can
        /// attach to an object. This can be useful for storing additional information about the
        /// object in a structured format.
        Metadata: Map<string, string>

        /// Reason for the refund, either user-provided (<c>duplicate</c>, <c>fraudulent</c>, or
        /// <c>requested_by_customer</c>) or generated by Stripe internally (<c>expired_uncaptured_charge</c>).
        Reason: RefundReason

        /// This is the transaction number that appears on email receipts sent for this refund.
        ReceiptNumber: string

        /// Status of the refund. For credit card refunds, this can be <c>pending</c>,
        /// <c>succeeded</c>, or <c>failed</c>. For other types of refunds, it can be
        /// <c>pending</c>, <c>succeeded</c>, <c>failed</c>, or <c>canceled</c>. Refer to our <a
        /// href="https://stripe.com/docs/refunds#failed-refunds">refunds</a> documentation for more
        /// details.
        Status: RefundStatus
    }

    and FailureReason =
        | ExpiredOrCanceledCard
        | LostOrStolenCard
        | Unknown

    and RefundReason =
        | Duplicate
        | ExpiredUncapturedCharge
        | Fraudulent
        | RequestedByCustomer

    and RefundStatus =
        | Canceled
        | Pending
        | Succeeded
        | Failed

    and Shipping = {
        ///Shipping address.
        Address: Common.Address

        ///The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc.
        Carrier: string

        ///Recipient name.
        Name: string

        ///Recipient phone (including extension).
        Phone: string

        ///The tracking number for a physical product, obtained from the delivery service.
        /// If multiple tracking numbers were generated for this purchase, please separate them with commas.
        TrackingNumber: string
    }

    and TransferData = {
        Amount: int
        Destination: string
    }