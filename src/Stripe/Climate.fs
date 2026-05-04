namespace Stripe.Climate

open System.Text.Json.Serialization
open FunStripe
open System

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
type ClimateOrderCancellationReason =
    | Expired
    | ProductUnavailable
    | Requested

[<Struct>]
type ClimateOrderStatus =
    | AwaitingFunds
    | Canceled
    | Confirmed
    | Delivered
    | Open

type ClimateRemovalsBeneficiary =
    {
        /// Publicly displayable name for the end beneficiary of carbon removal.
        PublicName: string
    }

type ClimateRemovalsBeneficiary with
    static member New(publicName: string) =
        {
            PublicName = publicName
        }

type ClimateRemovalsLocation =
    {
        /// The city where the supplier is located.
        City: string option
        /// Two-letter ISO code representing the country where the supplier is located.
        Country: IsoTypes.IsoCountryCode
        /// The geographic latitude where the supplier is located.
        Latitude: decimal option
        /// The geographic longitude where the supplier is located.
        Longitude: decimal option
        /// The state/county/province/region where the supplier is located.
        Region: string option
    }

type ClimateRemovalsLocation with
    static member New(city: string option, country: IsoTypes.IsoCountryCode, latitude: decimal option, longitude: decimal option, region: string option) =
        {
            City = city
            Country = country
            Latitude = latitude
            Longitude = longitude
            Region = region
        }

[<Struct>]
type ClimateSupplierRemovalPathway =
    | BiomassCarbonRemovalAndStorage
    | DirectAirCapture
    | EnhancedWeathering
    | MarineCarbonRemoval

/// A supplier of carbon removal.
type ClimateSupplier =
    {
        /// Unique identifier for the object.
        Id: string
        /// Link to a webpage to learn more about the supplier.
        InfoUrl: string
        /// Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        /// The locations in which this supplier operates.
        Locations: ClimateRemovalsLocation list
        /// Name of this carbon removal supplier.
        Name: string
        /// The scientific pathway used for carbon removal.
        RemovalPathway: ClimateSupplierRemovalPathway
    }

type ClimateSupplier with
    static member New(id: string, infoUrl: string, livemode: bool, locations: ClimateRemovalsLocation list, name: string, removalPathway: ClimateSupplierRemovalPathway) =
        {
            Id = id
            InfoUrl = infoUrl
            Livemode = livemode
            Locations = locations
            Name = name
            RemovalPathway = removalPathway
        }

module ClimateSupplier =
    ///String representing the object’s type. Objects of the same type share the same value.
    let object = "climate.supplier"

/// The delivery of a specified quantity of carbon for an order.
type ClimateRemovalsOrderDeliveries =
    {
        /// Time at which the delivery occurred. Measured in seconds since the Unix epoch.
        DeliveredAt: DateTime
        /// Specific location of this delivery.
        Location: ClimateRemovalsLocation option
        /// Quantity of carbon removal supplied by this delivery.
        MetricTons: string
        /// Once retired, a URL to the registry entry for the tons from this delivery.
        RegistryUrl: string option
        Supplier: ClimateSupplier
    }

type ClimateRemovalsOrderDeliveries with
    static member New(deliveredAt: DateTime, location: ClimateRemovalsLocation option, metricTons: string, registryUrl: string option, supplier: ClimateSupplier) =
        {
            DeliveredAt = deliveredAt
            Location = location
            MetricTons = metricTons
            RegistryUrl = registryUrl
            Supplier = supplier
        }

/// Orders represent your intent to purchase a particular Climate product. When you create an order, the
/// payment is deducted from your merchant balance.
type ClimateOrder =
    {
        /// Total amount of [Frontier](https://frontierclimate.com/)'s service fees in the currency's smallest unit.
        AmountFees: int
        /// Total amount of the carbon removal in the currency's smallest unit.
        AmountSubtotal: int
        /// Total amount of the order including fees in the currency's smallest unit.
        AmountTotal: int
        Beneficiary: ClimateRemovalsBeneficiary option
        /// Time at which the order was canceled. Measured in seconds since the Unix epoch.
        CanceledAt: DateTime option
        /// Reason for the cancellation of this order.
        CancellationReason: ClimateOrderCancellationReason option
        /// For delivered orders, a URL to a delivery certificate for the order.
        Certificate: string option
        /// Time at which the order was confirmed. Measured in seconds since the Unix epoch.
        ConfirmedAt: DateTime option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase, representing the currency for this order.
        Currency: IsoTypes.IsoCurrencyCode
        /// Time at which the order's expected_delivery_year was delayed. Measured in seconds since the Unix epoch.
        DelayedAt: DateTime option
        /// Time at which the order was delivered. Measured in seconds since the Unix epoch.
        DeliveredAt: DateTime option
        /// Details about the delivery of carbon removal for this order.
        DeliveryDetails: ClimateRemovalsOrderDeliveries list
        /// The year this order is expected to be delivered.
        ExpectedDeliveryYear: int
        /// Unique identifier for the object.
        Id: string
        /// Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// Quantity of carbon removal that is included in this order.
        MetricTons: string
        /// Unique ID for the Climate `Product` this order is purchasing.
        Product: StripeId<Markers.ClimateProduct>
        /// Time at which the order's product was substituted for a different product. Measured in seconds since the Unix epoch.
        ProductSubstitutedAt: DateTime option
        /// The current status of this order.
        Status: ClimateOrderStatus
    }

type ClimateOrder with
    static member New(amountFees: int, amountSubtotal: int, amountTotal: int, canceledAt: DateTime option, cancellationReason: ClimateOrderCancellationReason option, certificate: string option, confirmedAt: DateTime option, created: DateTime, currency: IsoTypes.IsoCurrencyCode, delayedAt: DateTime option, deliveredAt: DateTime option, deliveryDetails: ClimateRemovalsOrderDeliveries list, expectedDeliveryYear: int, id: string, livemode: bool, metadata: Map<string, string>, metricTons: string, product: StripeId<Markers.ClimateProduct>, productSubstitutedAt: DateTime option, status: ClimateOrderStatus, ?beneficiary: ClimateRemovalsBeneficiary) =
        {
            AmountFees = amountFees
            AmountSubtotal = amountSubtotal
            AmountTotal = amountTotal
            CanceledAt = canceledAt
            CancellationReason = cancellationReason
            Certificate = certificate
            ConfirmedAt = confirmedAt
            Created = created
            Currency = currency
            DelayedAt = delayedAt
            DeliveredAt = deliveredAt
            DeliveryDetails = deliveryDetails
            ExpectedDeliveryYear = expectedDeliveryYear
            Id = id
            Livemode = livemode
            Metadata = metadata
            MetricTons = metricTons
            Product = product
            ProductSubstitutedAt = productSubstitutedAt
            Status = status
            Beneficiary = beneficiary
        }

module ClimateOrder =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "climate.order"

/// Occurs when a Climate order is canceled.
type ClimateOrderCanceled = { Object: ClimateOrder }

type ClimateOrderCanceled with
    static member New(object: ClimateOrder) =
        {
            Object = object
        }

/// Occurs when a Climate order is created.
type ClimateOrderCreated = { Object: ClimateOrder }

type ClimateOrderCreated with
    static member New(object: ClimateOrder) =
        {
            Object = object
        }

/// Occurs when a Climate order is delayed.
type ClimateOrderDelayed = { Object: ClimateOrder }

type ClimateOrderDelayed with
    static member New(object: ClimateOrder) =
        {
            Object = object
        }

/// Occurs when a Climate order is delivered.
type ClimateOrderDelivered = { Object: ClimateOrder }

type ClimateOrderDelivered with
    static member New(object: ClimateOrder) =
        {
            Object = object
        }

/// Occurs when a Climate order's product is substituted for another.
type ClimateOrderProductSubstituted = { Object: ClimateOrder }

type ClimateOrderProductSubstituted with
    static member New(object: ClimateOrder) =
        {
            Object = object
        }

/// A Climate product represents a type of carbon removal unit available for reservation.
/// You can retrieve it to see the current price and availability.
type ClimateProduct =
    {
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Current prices for a metric ton of carbon removal in a currency's smallest unit.
        CurrentPricesPerMetricTon: Map<string, string list>
        /// The year in which the carbon removal is expected to be delivered.
        DeliveryYear: int option
        /// Unique identifier for the object. For convenience, Climate product IDs are human-readable strings
        /// that start with `climsku_`. See [carbon removal inventory](https://stripe.com/docs/climate/orders/carbon-removal-inventory)
        /// for a list of available carbon removal products.
        Id: string
        /// Has the value `true` if the object exists in live mode or the value `false` if the object exists in test mode.
        Livemode: bool
        /// The quantity of metric tons available for reservation.
        MetricTonsAvailable: string
        /// The Climate product's name.
        Name: string
        /// The carbon removal suppliers that fulfill orders for this Climate product.
        Suppliers: ClimateSupplier list
    }

type ClimateProduct with
    static member New(created: DateTime, currentPricesPerMetricTon: Map<string, string list>, deliveryYear: int option, id: string, livemode: bool, metricTonsAvailable: string, name: string, suppliers: ClimateSupplier list) =
        {
            Created = created
            CurrentPricesPerMetricTon = currentPricesPerMetricTon
            DeliveryYear = deliveryYear
            Id = id
            Livemode = livemode
            MetricTonsAvailable = metricTonsAvailable
            Name = name
            Suppliers = suppliers
        }

module ClimateProduct =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "climate.product"

/// Occurs when a Climate product is created.
type ClimateProductCreated = { Object: ClimateProduct }

type ClimateProductCreated with
    static member New(object: ClimateProduct) =
        {
            Object = object
        }

/// Occurs when a Climate product is updated.
type ClimateProductPricingUpdated = { Object: ClimateProduct }

type ClimateProductPricingUpdated with
    static member New(object: ClimateProduct) =
        {
            Object = object
        }

type ClimateRemovalsProductsPrice =
    {
        /// Fees for one metric ton of carbon removal in the currency's smallest unit.
        AmountFees: int
        /// Subtotal for one metric ton of carbon removal (excluding fees) in the currency's smallest unit.
        AmountSubtotal: int
        /// Total for one metric ton of carbon removal (including fees) in the currency's smallest unit.
        AmountTotal: int
    }

type ClimateRemovalsProductsPrice with
    static member New(amountFees: int, amountSubtotal: int, amountTotal: int) =
        {
            AmountFees = amountFees
            AmountSubtotal = amountSubtotal
            AmountTotal = amountTotal
        }

