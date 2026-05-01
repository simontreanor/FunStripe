namespace StripeRequest.Issuing

open FunStripe
open System.Text.Json.Serialization
open Stripe.Issuing
open Stripe.IssuingCard
open Stripe.IssuingCardholder
open Stripe.IssuingPersonalizationDesign
open Stripe.IssuingToken
open Stripe.PaymentMethod
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module IssuingAuthorizations =

    type ListOptions =
        {
            /// Only return authorizations that belong to the given card.
            [<Config.Query>]
            Card: string option
            /// Only return authorizations that belong to the given cardholder.
            [<Config.Query>]
            Cardholder: string option
            /// Only return authorizations that were created during the given date interval.
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
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return authorizations with the given status. One of `pending`, `closed`, or `reversed`.
            [<Config.Query>]
            Status: string option
        }

    type ListOptions with
        static member New(?card: string, ?cardholder: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
            {
                Card = card
                Cardholder = cardholder
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Status = status
            }

    module ListOptions =
        let create
            (
                card: string option,
                cardholder: string option,
                created: int option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option,
                status: string option
            ) : ListOptions
            =
            {
              Card = card
              Cardholder = cardholder
              Created = created
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
              Status = status
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Authorization: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    type RetrieveOptions with
        static member New(authorization: string, ?expand: string list) =
            {
                Authorization = authorization
                Expand = expand
            }

    module RetrieveOptions =
        let create
            (
                authorization: string
            ) : RetrieveOptions
            =
            {
              Authorization = authorization
              Expand = None
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Authorization: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
        }

    type UpdateOptions with
        static member New(authorization: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Authorization = authorization
                Expand = expand
                Metadata = metadata
            }

    module UpdateOptions =
        let create
            (
                authorization: string
            ) : UpdateOptions
            =
            {
              Authorization = authorization
              Expand = None
              Metadata = None
            }

    ///<p>Returns a list of Issuing <code>Authorization</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("card", options.Card |> box); ("cardholder", options.Cardholder |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/issuing/authorizations"
        |> RestApi.getAsync<StripeList<IssuingAuthorization>> settings qs

    ///<p>Retrieves an Issuing <code>Authorization</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/issuing/authorizations/{options.Authorization}"
        |> RestApi.getAsync<IssuingAuthorization> settings qs

    ///<p>Updates the specified Issuing <code>Authorization</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/issuing/authorizations/{options.Authorization}"
        |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) options

module IssuingAuthorizationsApprove =

    type ApproveOptions =
        {
            [<Config.Path>]
            Authorization: string
            /// If the authorization's `pending_request.is_amount_controllable` property is `true`, you may provide this value to control how much to hold for the authorization. Must be positive (use [`decline`](https://docs.stripe.com/api/issuing/authorizations/decline) to decline an authorization request).
            [<Config.Form>]
            Amount: int option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
        }

    type ApproveOptions with
        static member New(authorization: string, ?amount: int, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Authorization = authorization
                Amount = amount
                Expand = expand
                Metadata = metadata
            }

    module ApproveOptions =
        let create
            (
                authorization: string
            ) : ApproveOptions
            =
            {
              Authorization = authorization
              Amount = None
              Expand = None
              Metadata = None
            }

    ///<p>[Deprecated] Approves a pending Issuing <code>Authorization</code> object. This request should be made within the timeout window of the <a href="/docs/issuing/controls/real-time-authorizations">real-time authorization</a> flow. 
    ///This method is deprecated. Instead, <a href="/docs/issuing/controls/real-time-authorizations#authorization-handling">respond directly to the webhook request to approve an authorization</a>.</p>
    let Approve settings (options: ApproveOptions) =
        $"/v1/issuing/authorizations/{options.Authorization}/approve"
        |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) options

module IssuingAuthorizationsDecline =

    type DeclineOptions =
        {
            [<Config.Path>]
            Authorization: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
        }

    type DeclineOptions with
        static member New(authorization: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Authorization = authorization
                Expand = expand
                Metadata = metadata
            }

    module DeclineOptions =
        let create
            (
                authorization: string
            ) : DeclineOptions
            =
            {
              Authorization = authorization
              Expand = None
              Metadata = None
            }

    ///<p>[Deprecated] Declines a pending Issuing <code>Authorization</code> object. This request should be made within the timeout window of the <a href="/docs/issuing/controls/real-time-authorizations">real time authorization</a> flow.
    ///This method is deprecated. Instead, <a href="/docs/issuing/controls/real-time-authorizations#authorization-handling">respond directly to the webhook request to decline an authorization</a>.</p>
    let Decline settings (options: DeclineOptions) =
        $"/v1/issuing/authorizations/{options.Authorization}/decline"
        |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) options

module IssuingCardholders =

    type ListOptions =
        {
            /// Only return cardholders that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// Only return cardholders that have the given email address.
            [<Config.Query>]
            Email: string option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// Only return cardholders that have the given phone number.
            [<Config.Query>]
            PhoneNumber: string option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return cardholders that have the given status. One of `active`, `inactive`, or `blocked`.
            [<Config.Query>]
            Status: string option
            /// Only return cardholders that have the given type. One of `individual` or `company`.
            [<Config.Query>]
            Type: string option
        }

    type ListOptions with
        static member New(?created: int, ?email: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?phoneNumber: string, ?startingAfter: string, ?status: string, ?type': string) =
            {
                Created = created
                Email = email
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                PhoneNumber = phoneNumber
                StartingAfter = startingAfter
                Status = status
                Type = type'
            }

    module ListOptions =
        let create
            (
                created: int option,
                email: string option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                phoneNumber: string option,
                startingAfter: string option,
                status: string option,
                type': string option
            ) : ListOptions
            =
            {
              Created = created
              Email = email
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              PhoneNumber = phoneNumber
              StartingAfter = startingAfter
              Status = status
              Type = type'
            }

    type Create'BillingAddress =
        {
            /// City, district, suburb, town, or village.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Address line 1, such as the street, PO Box, or company name.
            [<Config.Form>]
            Line1: string option
            /// Address line 2, such as the apartment, suite, unit, or building.
            [<Config.Form>]
            Line2: string option
            /// ZIP or postal code.
            [<Config.Form>]
            PostalCode: string option
            /// State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
            [<Config.Form>]
            State: string option
        }

    type Create'BillingAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    module Create'BillingAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Create'BillingAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Create'Billing =
        {
            /// The cardholder’s billing address.
            [<Config.Form>]
            Address: Create'BillingAddress option
        }

    type Create'Billing with
        static member New(?address: Create'BillingAddress) =
            {
                Address = address
            }

    module Create'Billing =
        let create
            (
                address: Create'BillingAddress option
            ) : Create'Billing
            =
            {
              Address = address
            }

    type Create'Company =
        {
            /// The entity's business ID number.
            [<Config.Form>]
            TaxId: string option
        }

    type Create'Company with
        static member New(?taxId: string) =
            {
                TaxId = taxId
            }

    module Create'Company =
        let create
            (
                taxId: string option
            ) : Create'Company
            =
            {
              TaxId = taxId
            }

    type Create'IndividualCardIssuingUserTermsAcceptance =
        {
            /// The Unix timestamp marking when the cardholder accepted the Authorized User Terms.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the cardholder accepted the Authorized User Terms.
            [<Config.Form>]
            Ip: string option
            /// The user agent of the browser from which the cardholder accepted the Authorized User Terms.
            [<Config.Form>]
            UserAgent: Choice<string,string> option
        }

    type Create'IndividualCardIssuingUserTermsAcceptance with
        static member New(?date: DateTime, ?ip: string, ?userAgent: Choice<string,string>) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    module Create'IndividualCardIssuingUserTermsAcceptance =
        let create
            (
                date: DateTime option,
                ip: string option,
                userAgent: Choice<string,string> option
            ) : Create'IndividualCardIssuingUserTermsAcceptance
            =
            {
              Date = date
              Ip = ip
              UserAgent = userAgent
            }

    type Create'IndividualCardIssuing =
        {
            /// Information about cardholder acceptance of Celtic [Authorized User Terms](https://stripe.com/docs/issuing/cards#accept-authorized-user-terms). Required for cards backed by a Celtic program.
            [<Config.Form>]
            UserTermsAcceptance: Create'IndividualCardIssuingUserTermsAcceptance option
        }

    type Create'IndividualCardIssuing with
        static member New(?userTermsAcceptance: Create'IndividualCardIssuingUserTermsAcceptance) =
            {
                UserTermsAcceptance = userTermsAcceptance
            }

    module Create'IndividualCardIssuing =
        let create
            (
                userTermsAcceptance: Create'IndividualCardIssuingUserTermsAcceptance option
            ) : Create'IndividualCardIssuing
            =
            {
              UserTermsAcceptance = userTermsAcceptance
            }

    type Create'IndividualDob =
        {
            /// The day of birth, between 1 and 31.
            [<Config.Form>]
            Day: int option
            /// The month of birth, between 1 and 12.
            [<Config.Form>]
            Month: int option
            /// The four-digit year of birth.
            [<Config.Form>]
            Year: int option
        }

    type Create'IndividualDob with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    module Create'IndividualDob =
        let create
            (
                day: int option,
                month: int option,
                year: int option
            ) : Create'IndividualDob
            =
            {
              Day = day
              Month = month
              Year = year
            }

    type Create'IndividualVerificationDocument =
        {
            /// The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`.
            [<Config.Form>]
            Back: string option
            /// The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`.
            [<Config.Form>]
            Front: string option
        }

    type Create'IndividualVerificationDocument with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    module Create'IndividualVerificationDocument =
        let create
            (
                back: string option,
                front: string option
            ) : Create'IndividualVerificationDocument
            =
            {
              Back = back
              Front = front
            }

    type Create'IndividualVerification =
        {
            /// An identifying document, either a passport or local ID card.
            [<Config.Form>]
            Document: Create'IndividualVerificationDocument option
        }

    type Create'IndividualVerification with
        static member New(?document: Create'IndividualVerificationDocument) =
            {
                Document = document
            }

    module Create'IndividualVerification =
        let create
            (
                document: Create'IndividualVerificationDocument option
            ) : Create'IndividualVerification
            =
            {
              Document = document
            }

    type Create'Individual =
        {
            /// Information related to the card_issuing program for this cardholder.
            [<Config.Form>]
            CardIssuing: Create'IndividualCardIssuing option
            /// The date of birth of this cardholder. Cardholders must be older than 13 years old.
            [<Config.Form>]
            Dob: Create'IndividualDob option
            /// The first name of this cardholder. Required before activating Cards. This field cannot contain any numbers, special characters (except periods, commas, hyphens, spaces and apostrophes) or non-latin letters.
            [<Config.Form>]
            FirstName: string option
            /// The last name of this cardholder. Required before activating Cards. This field cannot contain any numbers, special characters (except periods, commas, hyphens, spaces and apostrophes) or non-latin letters.
            [<Config.Form>]
            LastName: string option
            /// Government-issued ID document for this cardholder.
            [<Config.Form>]
            Verification: Create'IndividualVerification option
        }

    type Create'Individual with
        static member New(?cardIssuing: Create'IndividualCardIssuing, ?dob: Create'IndividualDob, ?firstName: string, ?lastName: string, ?verification: Create'IndividualVerification) =
            {
                CardIssuing = cardIssuing
                Dob = dob
                FirstName = firstName
                LastName = lastName
                Verification = verification
            }

    module Create'Individual =
        let create
            (
                cardIssuing: Create'IndividualCardIssuing option,
                dob: Create'IndividualDob option,
                firstName: string option,
                lastName: string option,
                verification: Create'IndividualVerification option
            ) : Create'Individual
            =
            {
              CardIssuing = cardIssuing
              Dob = dob
              FirstName = firstName
              LastName = lastName
              Verification = verification
            }

    type Create'PreferredLocales =
        | De
        | En
        | Es
        | Fr
        | It

    type Create'SpendingControlsAllowedCardPresences =
        | NotPresent
        | Present

    type Create'SpendingControlsAllowedCategories =
        | AcRefrigerationRepair
        | AccountingBookkeepingServices
        | AdvertisingServices
        | AgriculturalCooperative
        | AirlinesAirCarriers
        | AirportsFlyingFields
        | AmbulanceServices
        | AmusementParksCarnivals
        | AntiqueReproductions
        | AntiqueShops
        | Aquariums
        | ArchitecturalSurveyingServices
        | ArtDealersAndGalleries
        | ArtistsSupplyAndCraftShops
        | AutoAndHomeSupplyStores
        | AutoBodyRepairShops
        | AutoPaintShops
        | AutoServiceShops
        | AutomatedCashDisburse
        | AutomatedFuelDispensers
        | AutomobileAssociations
        | AutomotivePartsAndAccessoriesStores
        | AutomotiveTireStores
        | BailAndBondPayments
        | Bakeries
        | BandsOrchestras
        | BarberAndBeautyShops
        | BettingCasinoGambling
        | BicycleShops
        | BilliardPoolEstablishments
        | BoatDealers
        | BoatRentalsAndLeases
        | BookStores
        | BooksPeriodicalsAndNewspapers
        | BowlingAlleys
        | BusLines
        | BusinessSecretarialSchools
        | BuyingShoppingServices
        | CableSatelliteAndOtherPayTelevisionAndRadio
        | CameraAndPhotographicSupplyStores
        | CandyNutAndConfectioneryStores
        | CarAndTruckDealersNewUsed
        | CarAndTruckDealersUsedOnly
        | CarRentalAgencies
        | CarWashes
        | CarpentryServices
        | CarpetUpholsteryCleaning
        | Caterers
        | CharitableAndSocialServiceOrganizationsFundraising
        | ChemicalsAndAlliedProducts
        | ChildCareServices
        | ChildrensAndInfantsWearStores
        | ChiropodistsPodiatrists
        | Chiropractors
        | CigarStoresAndStands
        | CivicSocialFraternalAssociations
        | CleaningAndMaintenance
        | ClothingRental
        | CollegesUniversities
        | CommercialEquipment
        | CommercialFootwear
        | CommercialPhotographyArtAndGraphics
        | CommuterTransportAndFerries
        | ComputerNetworkServices
        | ComputerProgramming
        | ComputerRepair
        | ComputerSoftwareStores
        | ComputersPeripheralsAndSoftware
        | ConcreteWorkServices
        | ConstructionMaterials
        | ConsultingPublicRelations
        | CorrespondenceSchools
        | CosmeticStores
        | CounselingServices
        | CountryClubs
        | CourierServices
        | CourtCosts
        | CreditReportingAgencies
        | CruiseLines
        | DairyProductsStores
        | DanceHallStudiosSchools
        | DatingEscortServices
        | DentistsOrthodontists
        | DepartmentStores
        | DetectiveAgencies
        | DigitalGoodsApplications
        | DigitalGoodsGames
        | DigitalGoodsLargeVolume
        | DigitalGoodsMedia
        | DirectMarketingCatalogMerchant
        | DirectMarketingCombinationCatalogAndRetailMerchant
        | DirectMarketingInboundTelemarketing
        | DirectMarketingInsuranceServices
        | DirectMarketingOther
        | DirectMarketingOutboundTelemarketing
        | DirectMarketingSubscription
        | DirectMarketingTravel
        | DiscountStores
        | Doctors
        | DoorToDoorSales
        | DraperyWindowCoveringAndUpholsteryStores
        | DrinkingPlaces
        | DrugStoresAndPharmacies
        | DrugsDrugProprietariesAndDruggistSundries
        | DryCleaners
        | DurableGoods
        | DutyFreeStores
        | EatingPlacesRestaurants
        | EducationalServices
        | ElectricRazorStores
        | ElectricVehicleCharging
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
        | EmergencyServicesGcasVisaUseOnly
        | EmploymentTempAgencies
        | EquipmentRental
        | ExterminatingServices
        | FamilyClothingStores
        | FastFoodRestaurants
        | FinancialInstitutions
        | FinesGovernmentAdministrativeEntities
        | FireplaceFireplaceScreensAndAccessoriesStores
        | FloorCoveringStores
        | Florists
        | FloristsSuppliesNurseryStockAndFlowers
        | FreezerAndLockerMeatProvisioners
        | FuelDealersNonAutomotive
        | FuneralServicesCrematories
        | FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | FurnitureRepairRefinishing
        | FurriersAndFurShops
        | GeneralServices
        | GiftCardNoveltyAndSouvenirShops
        | GlassPaintAndWallpaperStores
        | GlasswareCrystalStores
        | GolfCoursesPublic
        | GovernmentLicensedHorseDogRacingUsRegionOnly
        | GovernmentLicensedOnlineCasionsOnlineGamblingUsRegionOnly
        | GovernmentOwnedLotteriesNonUsRegion
        | GovernmentOwnedLotteriesUsRegionOnly
        | GovernmentServices
        | GroceryStoresSupermarkets
        | HardwareEquipmentAndSupplies
        | HardwareStores
        | HealthAndBeautySpas
        | HearingAidsSalesAndSupplies
        | HeatingPlumbingAC
        | HobbyToyAndGameShops
        | HomeSupplyWarehouseStores
        | Hospitals
        | HotelsMotelsAndResorts
        | HouseholdApplianceStores
        | IndustrialSupplies
        | InformationRetrievalServices
        | InsuranceDefault
        | InsuranceUnderwritingPremiums
        | IntraCompanyPurchases
        | JewelryStoresWatchesClocksAndSilverwareStores
        | LandscapingServices
        | Laundries
        | LaundryCleaningServices
        | LegalServicesAttorneys
        | LuggageAndLeatherGoodsStores
        | LumberBuildingMaterialsStores
        | ManualCashDisburse
        | MarinasServiceAndSupplies
        | Marketplaces
        | MasonryStoneworkAndPlaster
        | MassageParlors
        | MedicalAndDentalLabs
        | MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | MedicalServices
        | MembershipOrganizations
        | MensAndBoysClothingAndAccessoriesStores
        | MensWomensClothingStores
        | MetalServiceCenters
        | Miscellaneous
        | MiscellaneousApparelAndAccessoryShops
        | MiscellaneousAutoDealers
        | MiscellaneousBusinessServices
        | MiscellaneousFoodStores
        | MiscellaneousGeneralMerchandise
        | MiscellaneousGeneralServices
        | MiscellaneousHomeFurnishingSpecialtyStores
        | MiscellaneousPublishingAndPrinting
        | MiscellaneousRecreationServices
        | MiscellaneousRepairShops
        | MiscellaneousSpecialtyRetail
        | MobileHomeDealers
        | MotionPictureTheaters
        | MotorFreightCarriersAndTrucking
        | MotorHomesDealers
        | MotorVehicleSuppliesAndNewParts
        | MotorcycleShopsAndDealers
        | MotorcycleShopsDealers
        | MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | NewsDealersAndNewsstands
        | NonFiMoneyOrders
        | NonFiStoredValueCardPurchaseLoad
        | NondurableGoods
        | NurseriesLawnAndGardenSupplyStores
        | NursingPersonalCare
        | OfficeAndCommercialFurniture
        | OpticiansEyeglasses
        | OptometristsOphthalmologist
        | OrthopedicGoodsProstheticDevices
        | Osteopaths
        | PackageStoresBeerWineAndLiquor
        | PaintsVarnishesAndSupplies
        | ParkingLotsGarages
        | PassengerRailways
        | PawnShops
        | PetShopsPetFoodAndSupplies
        | PetroleumAndPetroleumProducts
        | PhotoDeveloping
        | PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | PhotographicStudios
        | PictureVideoProduction
        | PieceGoodsNotionsAndOtherDryGoods
        | PlumbingHeatingEquipmentAndSupplies
        | PoliticalOrganizations
        | PostalServicesGovernmentOnly
        | PreciousStonesAndMetalsWatchesAndJewelry
        | ProfessionalServices
        | PublicWarehousingAndStorage
        | QuickCopyReproAndBlueprint
        | Railroads
        | RealEstateAgentsAndManagersRentals
        | RecordStores
        | RecreationalVehicleRentals
        | ReligiousGoodsStores
        | ReligiousOrganizations
        | RoofingSidingSheetMetal
        | SecretarialSupportServices
        | SecurityBrokersDealers
        | ServiceStations
        | SewingNeedleworkFabricAndPieceGoodsStores
        | ShoeRepairHatCleaning
        | ShoeStores
        | SmallApplianceRepair
        | SnowmobileDealers
        | SpecialTradeServices
        | SpecialtyCleaning
        | SportingGoodsStores
        | SportingRecreationCamps
        | SportsAndRidingApparelStores
        | SportsClubsFields
        | StampAndCoinStores
        | StationaryOfficeSuppliesPrintingAndWritingPaper
        | StationeryStoresOfficeAndSchoolSupplyStores
        | SwimmingPoolsSales
        | TUiTravelGermany
        | TailorsAlterations
        | TaxPaymentsGovernmentAgencies
        | TaxPreparationServices
        | TaxicabsLimousines
        | TelecommunicationEquipmentAndTelephoneSales
        | TelecommunicationServices
        | TelegraphServices
        | TentAndAwningShops
        | TestingLaboratories
        | TheatricalTicketAgencies
        | Timeshares
        | TireRetreadingAndRepair
        | TollsBridgeFees
        | TouristAttractionsAndExhibits
        | TowingServices
        | TrailerParksCampgrounds
        | TransportationServices
        | TravelAgenciesTourOperators
        | TruckStopIteration
        | TruckUtilityTrailerRentals
        | TypesettingPlateMakingAndRelatedServices
        | TypewriterStores
        | USFederalGovernmentAgenciesOrDepartments
        | UniformsCommercialClothing
        | UsedMerchandiseAndSecondhandStores
        | Utilities
        | VarietyStores
        | VeterinaryServices
        | VideoAmusementGameSupplies
        | VideoGameArcades
        | VideoTapeRentalStores
        | VocationalTradeSchools
        | WatchJewelryRepair
        | WeldingRepair
        | WholesaleClubs
        | WigAndToupeeStores
        | WiresMoneyOrders
        | WomensAccessoryAndSpecialtyShops
        | WomensReadyToWearStores
        | WreckingAndSalvageYards

    type Create'SpendingControlsBlockedCardPresences =
        | NotPresent
        | Present

    type Create'SpendingControlsBlockedCategories =
        | AcRefrigerationRepair
        | AccountingBookkeepingServices
        | AdvertisingServices
        | AgriculturalCooperative
        | AirlinesAirCarriers
        | AirportsFlyingFields
        | AmbulanceServices
        | AmusementParksCarnivals
        | AntiqueReproductions
        | AntiqueShops
        | Aquariums
        | ArchitecturalSurveyingServices
        | ArtDealersAndGalleries
        | ArtistsSupplyAndCraftShops
        | AutoAndHomeSupplyStores
        | AutoBodyRepairShops
        | AutoPaintShops
        | AutoServiceShops
        | AutomatedCashDisburse
        | AutomatedFuelDispensers
        | AutomobileAssociations
        | AutomotivePartsAndAccessoriesStores
        | AutomotiveTireStores
        | BailAndBondPayments
        | Bakeries
        | BandsOrchestras
        | BarberAndBeautyShops
        | BettingCasinoGambling
        | BicycleShops
        | BilliardPoolEstablishments
        | BoatDealers
        | BoatRentalsAndLeases
        | BookStores
        | BooksPeriodicalsAndNewspapers
        | BowlingAlleys
        | BusLines
        | BusinessSecretarialSchools
        | BuyingShoppingServices
        | CableSatelliteAndOtherPayTelevisionAndRadio
        | CameraAndPhotographicSupplyStores
        | CandyNutAndConfectioneryStores
        | CarAndTruckDealersNewUsed
        | CarAndTruckDealersUsedOnly
        | CarRentalAgencies
        | CarWashes
        | CarpentryServices
        | CarpetUpholsteryCleaning
        | Caterers
        | CharitableAndSocialServiceOrganizationsFundraising
        | ChemicalsAndAlliedProducts
        | ChildCareServices
        | ChildrensAndInfantsWearStores
        | ChiropodistsPodiatrists
        | Chiropractors
        | CigarStoresAndStands
        | CivicSocialFraternalAssociations
        | CleaningAndMaintenance
        | ClothingRental
        | CollegesUniversities
        | CommercialEquipment
        | CommercialFootwear
        | CommercialPhotographyArtAndGraphics
        | CommuterTransportAndFerries
        | ComputerNetworkServices
        | ComputerProgramming
        | ComputerRepair
        | ComputerSoftwareStores
        | ComputersPeripheralsAndSoftware
        | ConcreteWorkServices
        | ConstructionMaterials
        | ConsultingPublicRelations
        | CorrespondenceSchools
        | CosmeticStores
        | CounselingServices
        | CountryClubs
        | CourierServices
        | CourtCosts
        | CreditReportingAgencies
        | CruiseLines
        | DairyProductsStores
        | DanceHallStudiosSchools
        | DatingEscortServices
        | DentistsOrthodontists
        | DepartmentStores
        | DetectiveAgencies
        | DigitalGoodsApplications
        | DigitalGoodsGames
        | DigitalGoodsLargeVolume
        | DigitalGoodsMedia
        | DirectMarketingCatalogMerchant
        | DirectMarketingCombinationCatalogAndRetailMerchant
        | DirectMarketingInboundTelemarketing
        | DirectMarketingInsuranceServices
        | DirectMarketingOther
        | DirectMarketingOutboundTelemarketing
        | DirectMarketingSubscription
        | DirectMarketingTravel
        | DiscountStores
        | Doctors
        | DoorToDoorSales
        | DraperyWindowCoveringAndUpholsteryStores
        | DrinkingPlaces
        | DrugStoresAndPharmacies
        | DrugsDrugProprietariesAndDruggistSundries
        | DryCleaners
        | DurableGoods
        | DutyFreeStores
        | EatingPlacesRestaurants
        | EducationalServices
        | ElectricRazorStores
        | ElectricVehicleCharging
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
        | EmergencyServicesGcasVisaUseOnly
        | EmploymentTempAgencies
        | EquipmentRental
        | ExterminatingServices
        | FamilyClothingStores
        | FastFoodRestaurants
        | FinancialInstitutions
        | FinesGovernmentAdministrativeEntities
        | FireplaceFireplaceScreensAndAccessoriesStores
        | FloorCoveringStores
        | Florists
        | FloristsSuppliesNurseryStockAndFlowers
        | FreezerAndLockerMeatProvisioners
        | FuelDealersNonAutomotive
        | FuneralServicesCrematories
        | FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | FurnitureRepairRefinishing
        | FurriersAndFurShops
        | GeneralServices
        | GiftCardNoveltyAndSouvenirShops
        | GlassPaintAndWallpaperStores
        | GlasswareCrystalStores
        | GolfCoursesPublic
        | GovernmentLicensedHorseDogRacingUsRegionOnly
        | GovernmentLicensedOnlineCasionsOnlineGamblingUsRegionOnly
        | GovernmentOwnedLotteriesNonUsRegion
        | GovernmentOwnedLotteriesUsRegionOnly
        | GovernmentServices
        | GroceryStoresSupermarkets
        | HardwareEquipmentAndSupplies
        | HardwareStores
        | HealthAndBeautySpas
        | HearingAidsSalesAndSupplies
        | HeatingPlumbingAC
        | HobbyToyAndGameShops
        | HomeSupplyWarehouseStores
        | Hospitals
        | HotelsMotelsAndResorts
        | HouseholdApplianceStores
        | IndustrialSupplies
        | InformationRetrievalServices
        | InsuranceDefault
        | InsuranceUnderwritingPremiums
        | IntraCompanyPurchases
        | JewelryStoresWatchesClocksAndSilverwareStores
        | LandscapingServices
        | Laundries
        | LaundryCleaningServices
        | LegalServicesAttorneys
        | LuggageAndLeatherGoodsStores
        | LumberBuildingMaterialsStores
        | ManualCashDisburse
        | MarinasServiceAndSupplies
        | Marketplaces
        | MasonryStoneworkAndPlaster
        | MassageParlors
        | MedicalAndDentalLabs
        | MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | MedicalServices
        | MembershipOrganizations
        | MensAndBoysClothingAndAccessoriesStores
        | MensWomensClothingStores
        | MetalServiceCenters
        | Miscellaneous
        | MiscellaneousApparelAndAccessoryShops
        | MiscellaneousAutoDealers
        | MiscellaneousBusinessServices
        | MiscellaneousFoodStores
        | MiscellaneousGeneralMerchandise
        | MiscellaneousGeneralServices
        | MiscellaneousHomeFurnishingSpecialtyStores
        | MiscellaneousPublishingAndPrinting
        | MiscellaneousRecreationServices
        | MiscellaneousRepairShops
        | MiscellaneousSpecialtyRetail
        | MobileHomeDealers
        | MotionPictureTheaters
        | MotorFreightCarriersAndTrucking
        | MotorHomesDealers
        | MotorVehicleSuppliesAndNewParts
        | MotorcycleShopsAndDealers
        | MotorcycleShopsDealers
        | MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | NewsDealersAndNewsstands
        | NonFiMoneyOrders
        | NonFiStoredValueCardPurchaseLoad
        | NondurableGoods
        | NurseriesLawnAndGardenSupplyStores
        | NursingPersonalCare
        | OfficeAndCommercialFurniture
        | OpticiansEyeglasses
        | OptometristsOphthalmologist
        | OrthopedicGoodsProstheticDevices
        | Osteopaths
        | PackageStoresBeerWineAndLiquor
        | PaintsVarnishesAndSupplies
        | ParkingLotsGarages
        | PassengerRailways
        | PawnShops
        | PetShopsPetFoodAndSupplies
        | PetroleumAndPetroleumProducts
        | PhotoDeveloping
        | PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | PhotographicStudios
        | PictureVideoProduction
        | PieceGoodsNotionsAndOtherDryGoods
        | PlumbingHeatingEquipmentAndSupplies
        | PoliticalOrganizations
        | PostalServicesGovernmentOnly
        | PreciousStonesAndMetalsWatchesAndJewelry
        | ProfessionalServices
        | PublicWarehousingAndStorage
        | QuickCopyReproAndBlueprint
        | Railroads
        | RealEstateAgentsAndManagersRentals
        | RecordStores
        | RecreationalVehicleRentals
        | ReligiousGoodsStores
        | ReligiousOrganizations
        | RoofingSidingSheetMetal
        | SecretarialSupportServices
        | SecurityBrokersDealers
        | ServiceStations
        | SewingNeedleworkFabricAndPieceGoodsStores
        | ShoeRepairHatCleaning
        | ShoeStores
        | SmallApplianceRepair
        | SnowmobileDealers
        | SpecialTradeServices
        | SpecialtyCleaning
        | SportingGoodsStores
        | SportingRecreationCamps
        | SportsAndRidingApparelStores
        | SportsClubsFields
        | StampAndCoinStores
        | StationaryOfficeSuppliesPrintingAndWritingPaper
        | StationeryStoresOfficeAndSchoolSupplyStores
        | SwimmingPoolsSales
        | TUiTravelGermany
        | TailorsAlterations
        | TaxPaymentsGovernmentAgencies
        | TaxPreparationServices
        | TaxicabsLimousines
        | TelecommunicationEquipmentAndTelephoneSales
        | TelecommunicationServices
        | TelegraphServices
        | TentAndAwningShops
        | TestingLaboratories
        | TheatricalTicketAgencies
        | Timeshares
        | TireRetreadingAndRepair
        | TollsBridgeFees
        | TouristAttractionsAndExhibits
        | TowingServices
        | TrailerParksCampgrounds
        | TransportationServices
        | TravelAgenciesTourOperators
        | TruckStopIteration
        | TruckUtilityTrailerRentals
        | TypesettingPlateMakingAndRelatedServices
        | TypewriterStores
        | USFederalGovernmentAgenciesOrDepartments
        | UniformsCommercialClothing
        | UsedMerchandiseAndSecondhandStores
        | Utilities
        | VarietyStores
        | VeterinaryServices
        | VideoAmusementGameSupplies
        | VideoGameArcades
        | VideoTapeRentalStores
        | VocationalTradeSchools
        | WatchJewelryRepair
        | WeldingRepair
        | WholesaleClubs
        | WigAndToupeeStores
        | WiresMoneyOrders
        | WomensAccessoryAndSpecialtyShops
        | WomensReadyToWearStores
        | WreckingAndSalvageYards

    type Create'SpendingControlsSpendingLimitsCategories =
        | AcRefrigerationRepair
        | AccountingBookkeepingServices
        | AdvertisingServices
        | AgriculturalCooperative
        | AirlinesAirCarriers
        | AirportsFlyingFields
        | AmbulanceServices
        | AmusementParksCarnivals
        | AntiqueReproductions
        | AntiqueShops
        | Aquariums
        | ArchitecturalSurveyingServices
        | ArtDealersAndGalleries
        | ArtistsSupplyAndCraftShops
        | AutoAndHomeSupplyStores
        | AutoBodyRepairShops
        | AutoPaintShops
        | AutoServiceShops
        | AutomatedCashDisburse
        | AutomatedFuelDispensers
        | AutomobileAssociations
        | AutomotivePartsAndAccessoriesStores
        | AutomotiveTireStores
        | BailAndBondPayments
        | Bakeries
        | BandsOrchestras
        | BarberAndBeautyShops
        | BettingCasinoGambling
        | BicycleShops
        | BilliardPoolEstablishments
        | BoatDealers
        | BoatRentalsAndLeases
        | BookStores
        | BooksPeriodicalsAndNewspapers
        | BowlingAlleys
        | BusLines
        | BusinessSecretarialSchools
        | BuyingShoppingServices
        | CableSatelliteAndOtherPayTelevisionAndRadio
        | CameraAndPhotographicSupplyStores
        | CandyNutAndConfectioneryStores
        | CarAndTruckDealersNewUsed
        | CarAndTruckDealersUsedOnly
        | CarRentalAgencies
        | CarWashes
        | CarpentryServices
        | CarpetUpholsteryCleaning
        | Caterers
        | CharitableAndSocialServiceOrganizationsFundraising
        | ChemicalsAndAlliedProducts
        | ChildCareServices
        | ChildrensAndInfantsWearStores
        | ChiropodistsPodiatrists
        | Chiropractors
        | CigarStoresAndStands
        | CivicSocialFraternalAssociations
        | CleaningAndMaintenance
        | ClothingRental
        | CollegesUniversities
        | CommercialEquipment
        | CommercialFootwear
        | CommercialPhotographyArtAndGraphics
        | CommuterTransportAndFerries
        | ComputerNetworkServices
        | ComputerProgramming
        | ComputerRepair
        | ComputerSoftwareStores
        | ComputersPeripheralsAndSoftware
        | ConcreteWorkServices
        | ConstructionMaterials
        | ConsultingPublicRelations
        | CorrespondenceSchools
        | CosmeticStores
        | CounselingServices
        | CountryClubs
        | CourierServices
        | CourtCosts
        | CreditReportingAgencies
        | CruiseLines
        | DairyProductsStores
        | DanceHallStudiosSchools
        | DatingEscortServices
        | DentistsOrthodontists
        | DepartmentStores
        | DetectiveAgencies
        | DigitalGoodsApplications
        | DigitalGoodsGames
        | DigitalGoodsLargeVolume
        | DigitalGoodsMedia
        | DirectMarketingCatalogMerchant
        | DirectMarketingCombinationCatalogAndRetailMerchant
        | DirectMarketingInboundTelemarketing
        | DirectMarketingInsuranceServices
        | DirectMarketingOther
        | DirectMarketingOutboundTelemarketing
        | DirectMarketingSubscription
        | DirectMarketingTravel
        | DiscountStores
        | Doctors
        | DoorToDoorSales
        | DraperyWindowCoveringAndUpholsteryStores
        | DrinkingPlaces
        | DrugStoresAndPharmacies
        | DrugsDrugProprietariesAndDruggistSundries
        | DryCleaners
        | DurableGoods
        | DutyFreeStores
        | EatingPlacesRestaurants
        | EducationalServices
        | ElectricRazorStores
        | ElectricVehicleCharging
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
        | EmergencyServicesGcasVisaUseOnly
        | EmploymentTempAgencies
        | EquipmentRental
        | ExterminatingServices
        | FamilyClothingStores
        | FastFoodRestaurants
        | FinancialInstitutions
        | FinesGovernmentAdministrativeEntities
        | FireplaceFireplaceScreensAndAccessoriesStores
        | FloorCoveringStores
        | Florists
        | FloristsSuppliesNurseryStockAndFlowers
        | FreezerAndLockerMeatProvisioners
        | FuelDealersNonAutomotive
        | FuneralServicesCrematories
        | FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | FurnitureRepairRefinishing
        | FurriersAndFurShops
        | GeneralServices
        | GiftCardNoveltyAndSouvenirShops
        | GlassPaintAndWallpaperStores
        | GlasswareCrystalStores
        | GolfCoursesPublic
        | GovernmentLicensedHorseDogRacingUsRegionOnly
        | GovernmentLicensedOnlineCasionsOnlineGamblingUsRegionOnly
        | GovernmentOwnedLotteriesNonUsRegion
        | GovernmentOwnedLotteriesUsRegionOnly
        | GovernmentServices
        | GroceryStoresSupermarkets
        | HardwareEquipmentAndSupplies
        | HardwareStores
        | HealthAndBeautySpas
        | HearingAidsSalesAndSupplies
        | HeatingPlumbingAC
        | HobbyToyAndGameShops
        | HomeSupplyWarehouseStores
        | Hospitals
        | HotelsMotelsAndResorts
        | HouseholdApplianceStores
        | IndustrialSupplies
        | InformationRetrievalServices
        | InsuranceDefault
        | InsuranceUnderwritingPremiums
        | IntraCompanyPurchases
        | JewelryStoresWatchesClocksAndSilverwareStores
        | LandscapingServices
        | Laundries
        | LaundryCleaningServices
        | LegalServicesAttorneys
        | LuggageAndLeatherGoodsStores
        | LumberBuildingMaterialsStores
        | ManualCashDisburse
        | MarinasServiceAndSupplies
        | Marketplaces
        | MasonryStoneworkAndPlaster
        | MassageParlors
        | MedicalAndDentalLabs
        | MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | MedicalServices
        | MembershipOrganizations
        | MensAndBoysClothingAndAccessoriesStores
        | MensWomensClothingStores
        | MetalServiceCenters
        | Miscellaneous
        | MiscellaneousApparelAndAccessoryShops
        | MiscellaneousAutoDealers
        | MiscellaneousBusinessServices
        | MiscellaneousFoodStores
        | MiscellaneousGeneralMerchandise
        | MiscellaneousGeneralServices
        | MiscellaneousHomeFurnishingSpecialtyStores
        | MiscellaneousPublishingAndPrinting
        | MiscellaneousRecreationServices
        | MiscellaneousRepairShops
        | MiscellaneousSpecialtyRetail
        | MobileHomeDealers
        | MotionPictureTheaters
        | MotorFreightCarriersAndTrucking
        | MotorHomesDealers
        | MotorVehicleSuppliesAndNewParts
        | MotorcycleShopsAndDealers
        | MotorcycleShopsDealers
        | MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | NewsDealersAndNewsstands
        | NonFiMoneyOrders
        | NonFiStoredValueCardPurchaseLoad
        | NondurableGoods
        | NurseriesLawnAndGardenSupplyStores
        | NursingPersonalCare
        | OfficeAndCommercialFurniture
        | OpticiansEyeglasses
        | OptometristsOphthalmologist
        | OrthopedicGoodsProstheticDevices
        | Osteopaths
        | PackageStoresBeerWineAndLiquor
        | PaintsVarnishesAndSupplies
        | ParkingLotsGarages
        | PassengerRailways
        | PawnShops
        | PetShopsPetFoodAndSupplies
        | PetroleumAndPetroleumProducts
        | PhotoDeveloping
        | PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | PhotographicStudios
        | PictureVideoProduction
        | PieceGoodsNotionsAndOtherDryGoods
        | PlumbingHeatingEquipmentAndSupplies
        | PoliticalOrganizations
        | PostalServicesGovernmentOnly
        | PreciousStonesAndMetalsWatchesAndJewelry
        | ProfessionalServices
        | PublicWarehousingAndStorage
        | QuickCopyReproAndBlueprint
        | Railroads
        | RealEstateAgentsAndManagersRentals
        | RecordStores
        | RecreationalVehicleRentals
        | ReligiousGoodsStores
        | ReligiousOrganizations
        | RoofingSidingSheetMetal
        | SecretarialSupportServices
        | SecurityBrokersDealers
        | ServiceStations
        | SewingNeedleworkFabricAndPieceGoodsStores
        | ShoeRepairHatCleaning
        | ShoeStores
        | SmallApplianceRepair
        | SnowmobileDealers
        | SpecialTradeServices
        | SpecialtyCleaning
        | SportingGoodsStores
        | SportingRecreationCamps
        | SportsAndRidingApparelStores
        | SportsClubsFields
        | StampAndCoinStores
        | StationaryOfficeSuppliesPrintingAndWritingPaper
        | StationeryStoresOfficeAndSchoolSupplyStores
        | SwimmingPoolsSales
        | TUiTravelGermany
        | TailorsAlterations
        | TaxPaymentsGovernmentAgencies
        | TaxPreparationServices
        | TaxicabsLimousines
        | TelecommunicationEquipmentAndTelephoneSales
        | TelecommunicationServices
        | TelegraphServices
        | TentAndAwningShops
        | TestingLaboratories
        | TheatricalTicketAgencies
        | Timeshares
        | TireRetreadingAndRepair
        | TollsBridgeFees
        | TouristAttractionsAndExhibits
        | TowingServices
        | TrailerParksCampgrounds
        | TransportationServices
        | TravelAgenciesTourOperators
        | TruckStopIteration
        | TruckUtilityTrailerRentals
        | TypesettingPlateMakingAndRelatedServices
        | TypewriterStores
        | USFederalGovernmentAgenciesOrDepartments
        | UniformsCommercialClothing
        | UsedMerchandiseAndSecondhandStores
        | Utilities
        | VarietyStores
        | VeterinaryServices
        | VideoAmusementGameSupplies
        | VideoGameArcades
        | VideoTapeRentalStores
        | VocationalTradeSchools
        | WatchJewelryRepair
        | WeldingRepair
        | WholesaleClubs
        | WigAndToupeeStores
        | WiresMoneyOrders
        | WomensAccessoryAndSpecialtyShops
        | WomensReadyToWearStores
        | WreckingAndSalvageYards

    type Create'SpendingControlsSpendingLimitsInterval =
        | AllTime
        | Daily
        | Monthly
        | PerAuthorization
        | Weekly
        | Yearly

    type Create'SpendingControlsSpendingLimits =
        {
            /// Maximum amount allowed to spend per interval.
            [<Config.Form>]
            Amount: int option
            /// Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) this limit applies to. Omitting this field will apply the limit to all categories.
            [<Config.Form>]
            Categories: Create'SpendingControlsSpendingLimitsCategories list option
            /// Interval (or event) to which the amount applies.
            [<Config.Form>]
            Interval: Create'SpendingControlsSpendingLimitsInterval option
        }

    type Create'SpendingControlsSpendingLimits with
        static member New(?amount: int, ?categories: Create'SpendingControlsSpendingLimitsCategories list, ?interval: Create'SpendingControlsSpendingLimitsInterval) =
            {
                Amount = amount
                Categories = categories
                Interval = interval
            }

    module Create'SpendingControlsSpendingLimits =
        let create
            (
                amount: int option,
                categories: Create'SpendingControlsSpendingLimitsCategories list option,
                interval: Create'SpendingControlsSpendingLimitsInterval option
            ) : Create'SpendingControlsSpendingLimits
            =
            {
              Amount = amount
              Categories = categories
              Interval = interval
            }

    type Create'SpendingControls =
        {
            /// Array of card presence statuses from which authorizations will be allowed. Possible options are `present`, `not_present`. All other statuses will be blocked. Cannot be set with `blocked_card_presences`. Provide an empty value to unset this control.
            [<Config.Form>]
            AllowedCardPresences: Create'SpendingControlsAllowedCardPresences list option
            /// Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) of authorizations to allow. All other categories will be blocked. Cannot be set with `blocked_categories`.
            [<Config.Form>]
            AllowedCategories: Create'SpendingControlsAllowedCategories list option
            /// Array of strings containing representing countries from which authorizations will be allowed. Authorizations from merchants in all other countries will be declined. Country codes should be ISO 3166 alpha-2 country codes (e.g. `US`). Cannot be set with `blocked_merchant_countries`. Provide an empty value to unset this control.
            [<Config.Form>]
            AllowedMerchantCountries: string list option
            /// Array of card presence statuses from which authorizations will be declined. Possible options are `present`, `not_present`. Cannot be set with `allowed_card_presences`. Provide an empty value to unset this control.
            [<Config.Form>]
            BlockedCardPresences: Create'SpendingControlsBlockedCardPresences list option
            /// Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) of authorizations to decline. All other categories will be allowed. Cannot be set with `allowed_categories`.
            [<Config.Form>]
            BlockedCategories: Create'SpendingControlsBlockedCategories list option
            /// Array of strings containing representing countries from which authorizations will be declined. Country codes should be ISO 3166 alpha-2 country codes (e.g. `US`). Cannot be set with `allowed_merchant_countries`. Provide an empty value to unset this control.
            [<Config.Form>]
            BlockedMerchantCountries: string list option
            /// Limit spending with amount-based rules that apply across this cardholder's cards.
            [<Config.Form>]
            SpendingLimits: Create'SpendingControlsSpendingLimits list option
            /// Currency of amounts within `spending_limits`. Defaults to your merchant country's currency.
            [<Config.Form>]
            SpendingLimitsCurrency: IsoTypes.IsoCurrencyCode option
        }

    type Create'SpendingControls with
        static member New(?allowedCardPresences: Create'SpendingControlsAllowedCardPresences list, ?allowedCategories: Create'SpendingControlsAllowedCategories list, ?allowedMerchantCountries: string list, ?blockedCardPresences: Create'SpendingControlsBlockedCardPresences list, ?blockedCategories: Create'SpendingControlsBlockedCategories list, ?blockedMerchantCountries: string list, ?spendingLimits: Create'SpendingControlsSpendingLimits list, ?spendingLimitsCurrency: IsoTypes.IsoCurrencyCode) =
            {
                AllowedCardPresences = allowedCardPresences
                AllowedCategories = allowedCategories
                AllowedMerchantCountries = allowedMerchantCountries
                BlockedCardPresences = blockedCardPresences
                BlockedCategories = blockedCategories
                BlockedMerchantCountries = blockedMerchantCountries
                SpendingLimits = spendingLimits
                SpendingLimitsCurrency = spendingLimitsCurrency
            }

    module Create'SpendingControls =
        let create
            (
                allowedCardPresences: Create'SpendingControlsAllowedCardPresences list option,
                allowedCategories: Create'SpendingControlsAllowedCategories list option,
                allowedMerchantCountries: string list option,
                blockedCardPresences: Create'SpendingControlsBlockedCardPresences list option,
                blockedCategories: Create'SpendingControlsBlockedCategories list option,
                blockedMerchantCountries: string list option,
                spendingLimits: Create'SpendingControlsSpendingLimits list option,
                spendingLimitsCurrency: IsoTypes.IsoCurrencyCode option
            ) : Create'SpendingControls
            =
            {
              AllowedCardPresences = allowedCardPresences
              AllowedCategories = allowedCategories
              AllowedMerchantCountries = allowedMerchantCountries
              BlockedCardPresences = blockedCardPresences
              BlockedCategories = blockedCategories
              BlockedMerchantCountries = blockedMerchantCountries
              SpendingLimits = spendingLimits
              SpendingLimitsCurrency = spendingLimitsCurrency
            }

    type Create'Status =
        | Active
        | Inactive

    type Create'Type =
        | Company
        | Individual

    type CreateOptions =
        {
            /// The cardholder's billing address.
            [<Config.Form>]
            Billing: Create'Billing
            /// Additional information about a `company` cardholder.
            [<Config.Form>]
            Company: Create'Company option
            /// The cardholder's email address.
            [<Config.Form>]
            Email: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Additional information about an `individual` cardholder.
            [<Config.Form>]
            Individual: Create'Individual option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The cardholder's name. This will be printed on cards issued to them. The maximum length of this field is 24 characters. This field cannot contain any special characters or numbers.
            [<Config.Form>]
            Name: string
            /// The cardholder's phone number. This will be transformed to [E.164](https://en.wikipedia.org/wiki/E.164) if it is not provided in that format already. This is required for all cardholders who will be creating EU cards. See the [3D Secure documentation](https://docs.stripe.com/issuing/3d-secure#when-is-3d-secure-applied) for more details.
            [<Config.Form>]
            PhoneNumber: string option
            /// The cardholder’s preferred locales (languages), ordered by preference. Locales can be `da`, `de`, `en`, `es`, `fr`, `it`, `pl`, or `sv`.
            /// This changes the language of the [3D Secure flow](https://docs.stripe.com/issuing/3d-secure) and one-time password messages sent to the cardholder.
            [<Config.Form>]
            PreferredLocales: Create'PreferredLocales list option
            /// Rules that control spending across this cardholder's cards. Refer to our [documentation](https://docs.stripe.com/issuing/controls/spending-controls) for more details.
            [<Config.Form>]
            SpendingControls: Create'SpendingControls option
            /// Specifies whether to permit authorizations on this cardholder's cards. Defaults to `active`.
            [<Config.Form>]
            Status: Create'Status option
            /// One of `individual` or `company`. See [Choose a cardholder type](https://docs.stripe.com/issuing/other/choose-cardholder) for more details.
            [<Config.Form>]
            Type: Create'Type option
        }

    type CreateOptions with
        static member New(billing: Create'Billing, name: string, ?company: Create'Company, ?email: string, ?expand: string list, ?individual: Create'Individual, ?metadata: Map<string, string>, ?phoneNumber: string, ?preferredLocales: Create'PreferredLocales list, ?spendingControls: Create'SpendingControls, ?status: Create'Status, ?type': Create'Type) =
            {
                Billing = billing
                Name = name
                Company = company
                Email = email
                Expand = expand
                Individual = individual
                Metadata = metadata
                PhoneNumber = phoneNumber
                PreferredLocales = preferredLocales
                SpendingControls = spendingControls
                Status = status
                Type = type'
            }

    module CreateOptions =
        let create
            (
                billing: Create'Billing,
                name: string
            ) : CreateOptions
            =
            {
              Billing = billing
              Name = name
              Company = None
              Email = None
              Expand = None
              Individual = None
              Metadata = None
              PhoneNumber = None
              PreferredLocales = None
              SpendingControls = None
              Status = None
              Type = None
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Cardholder: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    type RetrieveOptions with
        static member New(cardholder: string, ?expand: string list) =
            {
                Cardholder = cardholder
                Expand = expand
            }

    module RetrieveOptions =
        let create
            (
                cardholder: string
            ) : RetrieveOptions
            =
            {
              Cardholder = cardholder
              Expand = None
            }

    type Update'BillingAddress =
        {
            /// City, district, suburb, town, or village.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Address line 1, such as the street, PO Box, or company name.
            [<Config.Form>]
            Line1: string option
            /// Address line 2, such as the apartment, suite, unit, or building.
            [<Config.Form>]
            Line2: string option
            /// ZIP or postal code.
            [<Config.Form>]
            PostalCode: string option
            /// State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
            [<Config.Form>]
            State: string option
        }

    type Update'BillingAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    module Update'BillingAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Update'BillingAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Update'Billing =
        {
            /// The cardholder’s billing address.
            [<Config.Form>]
            Address: Update'BillingAddress option
        }

    type Update'Billing with
        static member New(?address: Update'BillingAddress) =
            {
                Address = address
            }

    module Update'Billing =
        let create
            (
                address: Update'BillingAddress option
            ) : Update'Billing
            =
            {
              Address = address
            }

    type Update'Company =
        {
            /// The entity's business ID number.
            [<Config.Form>]
            TaxId: string option
        }

    type Update'Company with
        static member New(?taxId: string) =
            {
                TaxId = taxId
            }

    module Update'Company =
        let create
            (
                taxId: string option
            ) : Update'Company
            =
            {
              TaxId = taxId
            }

    type Update'IndividualCardIssuingUserTermsAcceptance =
        {
            /// The Unix timestamp marking when the cardholder accepted the Authorized User Terms.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the cardholder accepted the Authorized User Terms.
            [<Config.Form>]
            Ip: string option
            /// The user agent of the browser from which the cardholder accepted the Authorized User Terms.
            [<Config.Form>]
            UserAgent: Choice<string,string> option
        }

    type Update'IndividualCardIssuingUserTermsAcceptance with
        static member New(?date: DateTime, ?ip: string, ?userAgent: Choice<string,string>) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    module Update'IndividualCardIssuingUserTermsAcceptance =
        let create
            (
                date: DateTime option,
                ip: string option,
                userAgent: Choice<string,string> option
            ) : Update'IndividualCardIssuingUserTermsAcceptance
            =
            {
              Date = date
              Ip = ip
              UserAgent = userAgent
            }

    type Update'IndividualCardIssuing =
        {
            /// Information about cardholder acceptance of Celtic [Authorized User Terms](https://stripe.com/docs/issuing/cards#accept-authorized-user-terms). Required for cards backed by a Celtic program.
            [<Config.Form>]
            UserTermsAcceptance: Update'IndividualCardIssuingUserTermsAcceptance option
        }

    type Update'IndividualCardIssuing with
        static member New(?userTermsAcceptance: Update'IndividualCardIssuingUserTermsAcceptance) =
            {
                UserTermsAcceptance = userTermsAcceptance
            }

    module Update'IndividualCardIssuing =
        let create
            (
                userTermsAcceptance: Update'IndividualCardIssuingUserTermsAcceptance option
            ) : Update'IndividualCardIssuing
            =
            {
              UserTermsAcceptance = userTermsAcceptance
            }

    type Update'IndividualDob =
        {
            /// The day of birth, between 1 and 31.
            [<Config.Form>]
            Day: int option
            /// The month of birth, between 1 and 12.
            [<Config.Form>]
            Month: int option
            /// The four-digit year of birth.
            [<Config.Form>]
            Year: int option
        }

    type Update'IndividualDob with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    module Update'IndividualDob =
        let create
            (
                day: int option,
                month: int option,
                year: int option
            ) : Update'IndividualDob
            =
            {
              Day = day
              Month = month
              Year = year
            }

    type Update'IndividualVerificationDocument =
        {
            /// The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`.
            [<Config.Form>]
            Back: string option
            /// The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`.
            [<Config.Form>]
            Front: string option
        }

    type Update'IndividualVerificationDocument with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    module Update'IndividualVerificationDocument =
        let create
            (
                back: string option,
                front: string option
            ) : Update'IndividualVerificationDocument
            =
            {
              Back = back
              Front = front
            }

    type Update'IndividualVerification =
        {
            /// An identifying document, either a passport or local ID card.
            [<Config.Form>]
            Document: Update'IndividualVerificationDocument option
        }

    type Update'IndividualVerification with
        static member New(?document: Update'IndividualVerificationDocument) =
            {
                Document = document
            }

    module Update'IndividualVerification =
        let create
            (
                document: Update'IndividualVerificationDocument option
            ) : Update'IndividualVerification
            =
            {
              Document = document
            }

    type Update'Individual =
        {
            /// Information related to the card_issuing program for this cardholder.
            [<Config.Form>]
            CardIssuing: Update'IndividualCardIssuing option
            /// The date of birth of this cardholder. Cardholders must be older than 13 years old.
            [<Config.Form>]
            Dob: Update'IndividualDob option
            /// The first name of this cardholder. Required before activating Cards. This field cannot contain any numbers, special characters (except periods, commas, hyphens, spaces and apostrophes) or non-latin letters.
            [<Config.Form>]
            FirstName: string option
            /// The last name of this cardholder. Required before activating Cards. This field cannot contain any numbers, special characters (except periods, commas, hyphens, spaces and apostrophes) or non-latin letters.
            [<Config.Form>]
            LastName: string option
            /// Government-issued ID document for this cardholder.
            [<Config.Form>]
            Verification: Update'IndividualVerification option
        }

    type Update'Individual with
        static member New(?cardIssuing: Update'IndividualCardIssuing, ?dob: Update'IndividualDob, ?firstName: string, ?lastName: string, ?verification: Update'IndividualVerification) =
            {
                CardIssuing = cardIssuing
                Dob = dob
                FirstName = firstName
                LastName = lastName
                Verification = verification
            }

    module Update'Individual =
        let create
            (
                cardIssuing: Update'IndividualCardIssuing option,
                dob: Update'IndividualDob option,
                firstName: string option,
                lastName: string option,
                verification: Update'IndividualVerification option
            ) : Update'Individual
            =
            {
              CardIssuing = cardIssuing
              Dob = dob
              FirstName = firstName
              LastName = lastName
              Verification = verification
            }

    type Update'PreferredLocales =
        | De
        | En
        | Es
        | Fr
        | It

    type Update'SpendingControlsAllowedCardPresences =
        | NotPresent
        | Present

    type Update'SpendingControlsAllowedCategories =
        | AcRefrigerationRepair
        | AccountingBookkeepingServices
        | AdvertisingServices
        | AgriculturalCooperative
        | AirlinesAirCarriers
        | AirportsFlyingFields
        | AmbulanceServices
        | AmusementParksCarnivals
        | AntiqueReproductions
        | AntiqueShops
        | Aquariums
        | ArchitecturalSurveyingServices
        | ArtDealersAndGalleries
        | ArtistsSupplyAndCraftShops
        | AutoAndHomeSupplyStores
        | AutoBodyRepairShops
        | AutoPaintShops
        | AutoServiceShops
        | AutomatedCashDisburse
        | AutomatedFuelDispensers
        | AutomobileAssociations
        | AutomotivePartsAndAccessoriesStores
        | AutomotiveTireStores
        | BailAndBondPayments
        | Bakeries
        | BandsOrchestras
        | BarberAndBeautyShops
        | BettingCasinoGambling
        | BicycleShops
        | BilliardPoolEstablishments
        | BoatDealers
        | BoatRentalsAndLeases
        | BookStores
        | BooksPeriodicalsAndNewspapers
        | BowlingAlleys
        | BusLines
        | BusinessSecretarialSchools
        | BuyingShoppingServices
        | CableSatelliteAndOtherPayTelevisionAndRadio
        | CameraAndPhotographicSupplyStores
        | CandyNutAndConfectioneryStores
        | CarAndTruckDealersNewUsed
        | CarAndTruckDealersUsedOnly
        | CarRentalAgencies
        | CarWashes
        | CarpentryServices
        | CarpetUpholsteryCleaning
        | Caterers
        | CharitableAndSocialServiceOrganizationsFundraising
        | ChemicalsAndAlliedProducts
        | ChildCareServices
        | ChildrensAndInfantsWearStores
        | ChiropodistsPodiatrists
        | Chiropractors
        | CigarStoresAndStands
        | CivicSocialFraternalAssociations
        | CleaningAndMaintenance
        | ClothingRental
        | CollegesUniversities
        | CommercialEquipment
        | CommercialFootwear
        | CommercialPhotographyArtAndGraphics
        | CommuterTransportAndFerries
        | ComputerNetworkServices
        | ComputerProgramming
        | ComputerRepair
        | ComputerSoftwareStores
        | ComputersPeripheralsAndSoftware
        | ConcreteWorkServices
        | ConstructionMaterials
        | ConsultingPublicRelations
        | CorrespondenceSchools
        | CosmeticStores
        | CounselingServices
        | CountryClubs
        | CourierServices
        | CourtCosts
        | CreditReportingAgencies
        | CruiseLines
        | DairyProductsStores
        | DanceHallStudiosSchools
        | DatingEscortServices
        | DentistsOrthodontists
        | DepartmentStores
        | DetectiveAgencies
        | DigitalGoodsApplications
        | DigitalGoodsGames
        | DigitalGoodsLargeVolume
        | DigitalGoodsMedia
        | DirectMarketingCatalogMerchant
        | DirectMarketingCombinationCatalogAndRetailMerchant
        | DirectMarketingInboundTelemarketing
        | DirectMarketingInsuranceServices
        | DirectMarketingOther
        | DirectMarketingOutboundTelemarketing
        | DirectMarketingSubscription
        | DirectMarketingTravel
        | DiscountStores
        | Doctors
        | DoorToDoorSales
        | DraperyWindowCoveringAndUpholsteryStores
        | DrinkingPlaces
        | DrugStoresAndPharmacies
        | DrugsDrugProprietariesAndDruggistSundries
        | DryCleaners
        | DurableGoods
        | DutyFreeStores
        | EatingPlacesRestaurants
        | EducationalServices
        | ElectricRazorStores
        | ElectricVehicleCharging
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
        | EmergencyServicesGcasVisaUseOnly
        | EmploymentTempAgencies
        | EquipmentRental
        | ExterminatingServices
        | FamilyClothingStores
        | FastFoodRestaurants
        | FinancialInstitutions
        | FinesGovernmentAdministrativeEntities
        | FireplaceFireplaceScreensAndAccessoriesStores
        | FloorCoveringStores
        | Florists
        | FloristsSuppliesNurseryStockAndFlowers
        | FreezerAndLockerMeatProvisioners
        | FuelDealersNonAutomotive
        | FuneralServicesCrematories
        | FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | FurnitureRepairRefinishing
        | FurriersAndFurShops
        | GeneralServices
        | GiftCardNoveltyAndSouvenirShops
        | GlassPaintAndWallpaperStores
        | GlasswareCrystalStores
        | GolfCoursesPublic
        | GovernmentLicensedHorseDogRacingUsRegionOnly
        | GovernmentLicensedOnlineCasionsOnlineGamblingUsRegionOnly
        | GovernmentOwnedLotteriesNonUsRegion
        | GovernmentOwnedLotteriesUsRegionOnly
        | GovernmentServices
        | GroceryStoresSupermarkets
        | HardwareEquipmentAndSupplies
        | HardwareStores
        | HealthAndBeautySpas
        | HearingAidsSalesAndSupplies
        | HeatingPlumbingAC
        | HobbyToyAndGameShops
        | HomeSupplyWarehouseStores
        | Hospitals
        | HotelsMotelsAndResorts
        | HouseholdApplianceStores
        | IndustrialSupplies
        | InformationRetrievalServices
        | InsuranceDefault
        | InsuranceUnderwritingPremiums
        | IntraCompanyPurchases
        | JewelryStoresWatchesClocksAndSilverwareStores
        | LandscapingServices
        | Laundries
        | LaundryCleaningServices
        | LegalServicesAttorneys
        | LuggageAndLeatherGoodsStores
        | LumberBuildingMaterialsStores
        | ManualCashDisburse
        | MarinasServiceAndSupplies
        | Marketplaces
        | MasonryStoneworkAndPlaster
        | MassageParlors
        | MedicalAndDentalLabs
        | MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | MedicalServices
        | MembershipOrganizations
        | MensAndBoysClothingAndAccessoriesStores
        | MensWomensClothingStores
        | MetalServiceCenters
        | Miscellaneous
        | MiscellaneousApparelAndAccessoryShops
        | MiscellaneousAutoDealers
        | MiscellaneousBusinessServices
        | MiscellaneousFoodStores
        | MiscellaneousGeneralMerchandise
        | MiscellaneousGeneralServices
        | MiscellaneousHomeFurnishingSpecialtyStores
        | MiscellaneousPublishingAndPrinting
        | MiscellaneousRecreationServices
        | MiscellaneousRepairShops
        | MiscellaneousSpecialtyRetail
        | MobileHomeDealers
        | MotionPictureTheaters
        | MotorFreightCarriersAndTrucking
        | MotorHomesDealers
        | MotorVehicleSuppliesAndNewParts
        | MotorcycleShopsAndDealers
        | MotorcycleShopsDealers
        | MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | NewsDealersAndNewsstands
        | NonFiMoneyOrders
        | NonFiStoredValueCardPurchaseLoad
        | NondurableGoods
        | NurseriesLawnAndGardenSupplyStores
        | NursingPersonalCare
        | OfficeAndCommercialFurniture
        | OpticiansEyeglasses
        | OptometristsOphthalmologist
        | OrthopedicGoodsProstheticDevices
        | Osteopaths
        | PackageStoresBeerWineAndLiquor
        | PaintsVarnishesAndSupplies
        | ParkingLotsGarages
        | PassengerRailways
        | PawnShops
        | PetShopsPetFoodAndSupplies
        | PetroleumAndPetroleumProducts
        | PhotoDeveloping
        | PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | PhotographicStudios
        | PictureVideoProduction
        | PieceGoodsNotionsAndOtherDryGoods
        | PlumbingHeatingEquipmentAndSupplies
        | PoliticalOrganizations
        | PostalServicesGovernmentOnly
        | PreciousStonesAndMetalsWatchesAndJewelry
        | ProfessionalServices
        | PublicWarehousingAndStorage
        | QuickCopyReproAndBlueprint
        | Railroads
        | RealEstateAgentsAndManagersRentals
        | RecordStores
        | RecreationalVehicleRentals
        | ReligiousGoodsStores
        | ReligiousOrganizations
        | RoofingSidingSheetMetal
        | SecretarialSupportServices
        | SecurityBrokersDealers
        | ServiceStations
        | SewingNeedleworkFabricAndPieceGoodsStores
        | ShoeRepairHatCleaning
        | ShoeStores
        | SmallApplianceRepair
        | SnowmobileDealers
        | SpecialTradeServices
        | SpecialtyCleaning
        | SportingGoodsStores
        | SportingRecreationCamps
        | SportsAndRidingApparelStores
        | SportsClubsFields
        | StampAndCoinStores
        | StationaryOfficeSuppliesPrintingAndWritingPaper
        | StationeryStoresOfficeAndSchoolSupplyStores
        | SwimmingPoolsSales
        | TUiTravelGermany
        | TailorsAlterations
        | TaxPaymentsGovernmentAgencies
        | TaxPreparationServices
        | TaxicabsLimousines
        | TelecommunicationEquipmentAndTelephoneSales
        | TelecommunicationServices
        | TelegraphServices
        | TentAndAwningShops
        | TestingLaboratories
        | TheatricalTicketAgencies
        | Timeshares
        | TireRetreadingAndRepair
        | TollsBridgeFees
        | TouristAttractionsAndExhibits
        | TowingServices
        | TrailerParksCampgrounds
        | TransportationServices
        | TravelAgenciesTourOperators
        | TruckStopIteration
        | TruckUtilityTrailerRentals
        | TypesettingPlateMakingAndRelatedServices
        | TypewriterStores
        | USFederalGovernmentAgenciesOrDepartments
        | UniformsCommercialClothing
        | UsedMerchandiseAndSecondhandStores
        | Utilities
        | VarietyStores
        | VeterinaryServices
        | VideoAmusementGameSupplies
        | VideoGameArcades
        | VideoTapeRentalStores
        | VocationalTradeSchools
        | WatchJewelryRepair
        | WeldingRepair
        | WholesaleClubs
        | WigAndToupeeStores
        | WiresMoneyOrders
        | WomensAccessoryAndSpecialtyShops
        | WomensReadyToWearStores
        | WreckingAndSalvageYards

    type Update'SpendingControlsBlockedCardPresences =
        | NotPresent
        | Present

    type Update'SpendingControlsBlockedCategories =
        | AcRefrigerationRepair
        | AccountingBookkeepingServices
        | AdvertisingServices
        | AgriculturalCooperative
        | AirlinesAirCarriers
        | AirportsFlyingFields
        | AmbulanceServices
        | AmusementParksCarnivals
        | AntiqueReproductions
        | AntiqueShops
        | Aquariums
        | ArchitecturalSurveyingServices
        | ArtDealersAndGalleries
        | ArtistsSupplyAndCraftShops
        | AutoAndHomeSupplyStores
        | AutoBodyRepairShops
        | AutoPaintShops
        | AutoServiceShops
        | AutomatedCashDisburse
        | AutomatedFuelDispensers
        | AutomobileAssociations
        | AutomotivePartsAndAccessoriesStores
        | AutomotiveTireStores
        | BailAndBondPayments
        | Bakeries
        | BandsOrchestras
        | BarberAndBeautyShops
        | BettingCasinoGambling
        | BicycleShops
        | BilliardPoolEstablishments
        | BoatDealers
        | BoatRentalsAndLeases
        | BookStores
        | BooksPeriodicalsAndNewspapers
        | BowlingAlleys
        | BusLines
        | BusinessSecretarialSchools
        | BuyingShoppingServices
        | CableSatelliteAndOtherPayTelevisionAndRadio
        | CameraAndPhotographicSupplyStores
        | CandyNutAndConfectioneryStores
        | CarAndTruckDealersNewUsed
        | CarAndTruckDealersUsedOnly
        | CarRentalAgencies
        | CarWashes
        | CarpentryServices
        | CarpetUpholsteryCleaning
        | Caterers
        | CharitableAndSocialServiceOrganizationsFundraising
        | ChemicalsAndAlliedProducts
        | ChildCareServices
        | ChildrensAndInfantsWearStores
        | ChiropodistsPodiatrists
        | Chiropractors
        | CigarStoresAndStands
        | CivicSocialFraternalAssociations
        | CleaningAndMaintenance
        | ClothingRental
        | CollegesUniversities
        | CommercialEquipment
        | CommercialFootwear
        | CommercialPhotographyArtAndGraphics
        | CommuterTransportAndFerries
        | ComputerNetworkServices
        | ComputerProgramming
        | ComputerRepair
        | ComputerSoftwareStores
        | ComputersPeripheralsAndSoftware
        | ConcreteWorkServices
        | ConstructionMaterials
        | ConsultingPublicRelations
        | CorrespondenceSchools
        | CosmeticStores
        | CounselingServices
        | CountryClubs
        | CourierServices
        | CourtCosts
        | CreditReportingAgencies
        | CruiseLines
        | DairyProductsStores
        | DanceHallStudiosSchools
        | DatingEscortServices
        | DentistsOrthodontists
        | DepartmentStores
        | DetectiveAgencies
        | DigitalGoodsApplications
        | DigitalGoodsGames
        | DigitalGoodsLargeVolume
        | DigitalGoodsMedia
        | DirectMarketingCatalogMerchant
        | DirectMarketingCombinationCatalogAndRetailMerchant
        | DirectMarketingInboundTelemarketing
        | DirectMarketingInsuranceServices
        | DirectMarketingOther
        | DirectMarketingOutboundTelemarketing
        | DirectMarketingSubscription
        | DirectMarketingTravel
        | DiscountStores
        | Doctors
        | DoorToDoorSales
        | DraperyWindowCoveringAndUpholsteryStores
        | DrinkingPlaces
        | DrugStoresAndPharmacies
        | DrugsDrugProprietariesAndDruggistSundries
        | DryCleaners
        | DurableGoods
        | DutyFreeStores
        | EatingPlacesRestaurants
        | EducationalServices
        | ElectricRazorStores
        | ElectricVehicleCharging
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
        | EmergencyServicesGcasVisaUseOnly
        | EmploymentTempAgencies
        | EquipmentRental
        | ExterminatingServices
        | FamilyClothingStores
        | FastFoodRestaurants
        | FinancialInstitutions
        | FinesGovernmentAdministrativeEntities
        | FireplaceFireplaceScreensAndAccessoriesStores
        | FloorCoveringStores
        | Florists
        | FloristsSuppliesNurseryStockAndFlowers
        | FreezerAndLockerMeatProvisioners
        | FuelDealersNonAutomotive
        | FuneralServicesCrematories
        | FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | FurnitureRepairRefinishing
        | FurriersAndFurShops
        | GeneralServices
        | GiftCardNoveltyAndSouvenirShops
        | GlassPaintAndWallpaperStores
        | GlasswareCrystalStores
        | GolfCoursesPublic
        | GovernmentLicensedHorseDogRacingUsRegionOnly
        | GovernmentLicensedOnlineCasionsOnlineGamblingUsRegionOnly
        | GovernmentOwnedLotteriesNonUsRegion
        | GovernmentOwnedLotteriesUsRegionOnly
        | GovernmentServices
        | GroceryStoresSupermarkets
        | HardwareEquipmentAndSupplies
        | HardwareStores
        | HealthAndBeautySpas
        | HearingAidsSalesAndSupplies
        | HeatingPlumbingAC
        | HobbyToyAndGameShops
        | HomeSupplyWarehouseStores
        | Hospitals
        | HotelsMotelsAndResorts
        | HouseholdApplianceStores
        | IndustrialSupplies
        | InformationRetrievalServices
        | InsuranceDefault
        | InsuranceUnderwritingPremiums
        | IntraCompanyPurchases
        | JewelryStoresWatchesClocksAndSilverwareStores
        | LandscapingServices
        | Laundries
        | LaundryCleaningServices
        | LegalServicesAttorneys
        | LuggageAndLeatherGoodsStores
        | LumberBuildingMaterialsStores
        | ManualCashDisburse
        | MarinasServiceAndSupplies
        | Marketplaces
        | MasonryStoneworkAndPlaster
        | MassageParlors
        | MedicalAndDentalLabs
        | MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | MedicalServices
        | MembershipOrganizations
        | MensAndBoysClothingAndAccessoriesStores
        | MensWomensClothingStores
        | MetalServiceCenters
        | Miscellaneous
        | MiscellaneousApparelAndAccessoryShops
        | MiscellaneousAutoDealers
        | MiscellaneousBusinessServices
        | MiscellaneousFoodStores
        | MiscellaneousGeneralMerchandise
        | MiscellaneousGeneralServices
        | MiscellaneousHomeFurnishingSpecialtyStores
        | MiscellaneousPublishingAndPrinting
        | MiscellaneousRecreationServices
        | MiscellaneousRepairShops
        | MiscellaneousSpecialtyRetail
        | MobileHomeDealers
        | MotionPictureTheaters
        | MotorFreightCarriersAndTrucking
        | MotorHomesDealers
        | MotorVehicleSuppliesAndNewParts
        | MotorcycleShopsAndDealers
        | MotorcycleShopsDealers
        | MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | NewsDealersAndNewsstands
        | NonFiMoneyOrders
        | NonFiStoredValueCardPurchaseLoad
        | NondurableGoods
        | NurseriesLawnAndGardenSupplyStores
        | NursingPersonalCare
        | OfficeAndCommercialFurniture
        | OpticiansEyeglasses
        | OptometristsOphthalmologist
        | OrthopedicGoodsProstheticDevices
        | Osteopaths
        | PackageStoresBeerWineAndLiquor
        | PaintsVarnishesAndSupplies
        | ParkingLotsGarages
        | PassengerRailways
        | PawnShops
        | PetShopsPetFoodAndSupplies
        | PetroleumAndPetroleumProducts
        | PhotoDeveloping
        | PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | PhotographicStudios
        | PictureVideoProduction
        | PieceGoodsNotionsAndOtherDryGoods
        | PlumbingHeatingEquipmentAndSupplies
        | PoliticalOrganizations
        | PostalServicesGovernmentOnly
        | PreciousStonesAndMetalsWatchesAndJewelry
        | ProfessionalServices
        | PublicWarehousingAndStorage
        | QuickCopyReproAndBlueprint
        | Railroads
        | RealEstateAgentsAndManagersRentals
        | RecordStores
        | RecreationalVehicleRentals
        | ReligiousGoodsStores
        | ReligiousOrganizations
        | RoofingSidingSheetMetal
        | SecretarialSupportServices
        | SecurityBrokersDealers
        | ServiceStations
        | SewingNeedleworkFabricAndPieceGoodsStores
        | ShoeRepairHatCleaning
        | ShoeStores
        | SmallApplianceRepair
        | SnowmobileDealers
        | SpecialTradeServices
        | SpecialtyCleaning
        | SportingGoodsStores
        | SportingRecreationCamps
        | SportsAndRidingApparelStores
        | SportsClubsFields
        | StampAndCoinStores
        | StationaryOfficeSuppliesPrintingAndWritingPaper
        | StationeryStoresOfficeAndSchoolSupplyStores
        | SwimmingPoolsSales
        | TUiTravelGermany
        | TailorsAlterations
        | TaxPaymentsGovernmentAgencies
        | TaxPreparationServices
        | TaxicabsLimousines
        | TelecommunicationEquipmentAndTelephoneSales
        | TelecommunicationServices
        | TelegraphServices
        | TentAndAwningShops
        | TestingLaboratories
        | TheatricalTicketAgencies
        | Timeshares
        | TireRetreadingAndRepair
        | TollsBridgeFees
        | TouristAttractionsAndExhibits
        | TowingServices
        | TrailerParksCampgrounds
        | TransportationServices
        | TravelAgenciesTourOperators
        | TruckStopIteration
        | TruckUtilityTrailerRentals
        | TypesettingPlateMakingAndRelatedServices
        | TypewriterStores
        | USFederalGovernmentAgenciesOrDepartments
        | UniformsCommercialClothing
        | UsedMerchandiseAndSecondhandStores
        | Utilities
        | VarietyStores
        | VeterinaryServices
        | VideoAmusementGameSupplies
        | VideoGameArcades
        | VideoTapeRentalStores
        | VocationalTradeSchools
        | WatchJewelryRepair
        | WeldingRepair
        | WholesaleClubs
        | WigAndToupeeStores
        | WiresMoneyOrders
        | WomensAccessoryAndSpecialtyShops
        | WomensReadyToWearStores
        | WreckingAndSalvageYards

    type Update'SpendingControlsSpendingLimitsCategories =
        | AcRefrigerationRepair
        | AccountingBookkeepingServices
        | AdvertisingServices
        | AgriculturalCooperative
        | AirlinesAirCarriers
        | AirportsFlyingFields
        | AmbulanceServices
        | AmusementParksCarnivals
        | AntiqueReproductions
        | AntiqueShops
        | Aquariums
        | ArchitecturalSurveyingServices
        | ArtDealersAndGalleries
        | ArtistsSupplyAndCraftShops
        | AutoAndHomeSupplyStores
        | AutoBodyRepairShops
        | AutoPaintShops
        | AutoServiceShops
        | AutomatedCashDisburse
        | AutomatedFuelDispensers
        | AutomobileAssociations
        | AutomotivePartsAndAccessoriesStores
        | AutomotiveTireStores
        | BailAndBondPayments
        | Bakeries
        | BandsOrchestras
        | BarberAndBeautyShops
        | BettingCasinoGambling
        | BicycleShops
        | BilliardPoolEstablishments
        | BoatDealers
        | BoatRentalsAndLeases
        | BookStores
        | BooksPeriodicalsAndNewspapers
        | BowlingAlleys
        | BusLines
        | BusinessSecretarialSchools
        | BuyingShoppingServices
        | CableSatelliteAndOtherPayTelevisionAndRadio
        | CameraAndPhotographicSupplyStores
        | CandyNutAndConfectioneryStores
        | CarAndTruckDealersNewUsed
        | CarAndTruckDealersUsedOnly
        | CarRentalAgencies
        | CarWashes
        | CarpentryServices
        | CarpetUpholsteryCleaning
        | Caterers
        | CharitableAndSocialServiceOrganizationsFundraising
        | ChemicalsAndAlliedProducts
        | ChildCareServices
        | ChildrensAndInfantsWearStores
        | ChiropodistsPodiatrists
        | Chiropractors
        | CigarStoresAndStands
        | CivicSocialFraternalAssociations
        | CleaningAndMaintenance
        | ClothingRental
        | CollegesUniversities
        | CommercialEquipment
        | CommercialFootwear
        | CommercialPhotographyArtAndGraphics
        | CommuterTransportAndFerries
        | ComputerNetworkServices
        | ComputerProgramming
        | ComputerRepair
        | ComputerSoftwareStores
        | ComputersPeripheralsAndSoftware
        | ConcreteWorkServices
        | ConstructionMaterials
        | ConsultingPublicRelations
        | CorrespondenceSchools
        | CosmeticStores
        | CounselingServices
        | CountryClubs
        | CourierServices
        | CourtCosts
        | CreditReportingAgencies
        | CruiseLines
        | DairyProductsStores
        | DanceHallStudiosSchools
        | DatingEscortServices
        | DentistsOrthodontists
        | DepartmentStores
        | DetectiveAgencies
        | DigitalGoodsApplications
        | DigitalGoodsGames
        | DigitalGoodsLargeVolume
        | DigitalGoodsMedia
        | DirectMarketingCatalogMerchant
        | DirectMarketingCombinationCatalogAndRetailMerchant
        | DirectMarketingInboundTelemarketing
        | DirectMarketingInsuranceServices
        | DirectMarketingOther
        | DirectMarketingOutboundTelemarketing
        | DirectMarketingSubscription
        | DirectMarketingTravel
        | DiscountStores
        | Doctors
        | DoorToDoorSales
        | DraperyWindowCoveringAndUpholsteryStores
        | DrinkingPlaces
        | DrugStoresAndPharmacies
        | DrugsDrugProprietariesAndDruggistSundries
        | DryCleaners
        | DurableGoods
        | DutyFreeStores
        | EatingPlacesRestaurants
        | EducationalServices
        | ElectricRazorStores
        | ElectricVehicleCharging
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
        | EmergencyServicesGcasVisaUseOnly
        | EmploymentTempAgencies
        | EquipmentRental
        | ExterminatingServices
        | FamilyClothingStores
        | FastFoodRestaurants
        | FinancialInstitutions
        | FinesGovernmentAdministrativeEntities
        | FireplaceFireplaceScreensAndAccessoriesStores
        | FloorCoveringStores
        | Florists
        | FloristsSuppliesNurseryStockAndFlowers
        | FreezerAndLockerMeatProvisioners
        | FuelDealersNonAutomotive
        | FuneralServicesCrematories
        | FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | FurnitureRepairRefinishing
        | FurriersAndFurShops
        | GeneralServices
        | GiftCardNoveltyAndSouvenirShops
        | GlassPaintAndWallpaperStores
        | GlasswareCrystalStores
        | GolfCoursesPublic
        | GovernmentLicensedHorseDogRacingUsRegionOnly
        | GovernmentLicensedOnlineCasionsOnlineGamblingUsRegionOnly
        | GovernmentOwnedLotteriesNonUsRegion
        | GovernmentOwnedLotteriesUsRegionOnly
        | GovernmentServices
        | GroceryStoresSupermarkets
        | HardwareEquipmentAndSupplies
        | HardwareStores
        | HealthAndBeautySpas
        | HearingAidsSalesAndSupplies
        | HeatingPlumbingAC
        | HobbyToyAndGameShops
        | HomeSupplyWarehouseStores
        | Hospitals
        | HotelsMotelsAndResorts
        | HouseholdApplianceStores
        | IndustrialSupplies
        | InformationRetrievalServices
        | InsuranceDefault
        | InsuranceUnderwritingPremiums
        | IntraCompanyPurchases
        | JewelryStoresWatchesClocksAndSilverwareStores
        | LandscapingServices
        | Laundries
        | LaundryCleaningServices
        | LegalServicesAttorneys
        | LuggageAndLeatherGoodsStores
        | LumberBuildingMaterialsStores
        | ManualCashDisburse
        | MarinasServiceAndSupplies
        | Marketplaces
        | MasonryStoneworkAndPlaster
        | MassageParlors
        | MedicalAndDentalLabs
        | MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | MedicalServices
        | MembershipOrganizations
        | MensAndBoysClothingAndAccessoriesStores
        | MensWomensClothingStores
        | MetalServiceCenters
        | Miscellaneous
        | MiscellaneousApparelAndAccessoryShops
        | MiscellaneousAutoDealers
        | MiscellaneousBusinessServices
        | MiscellaneousFoodStores
        | MiscellaneousGeneralMerchandise
        | MiscellaneousGeneralServices
        | MiscellaneousHomeFurnishingSpecialtyStores
        | MiscellaneousPublishingAndPrinting
        | MiscellaneousRecreationServices
        | MiscellaneousRepairShops
        | MiscellaneousSpecialtyRetail
        | MobileHomeDealers
        | MotionPictureTheaters
        | MotorFreightCarriersAndTrucking
        | MotorHomesDealers
        | MotorVehicleSuppliesAndNewParts
        | MotorcycleShopsAndDealers
        | MotorcycleShopsDealers
        | MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | NewsDealersAndNewsstands
        | NonFiMoneyOrders
        | NonFiStoredValueCardPurchaseLoad
        | NondurableGoods
        | NurseriesLawnAndGardenSupplyStores
        | NursingPersonalCare
        | OfficeAndCommercialFurniture
        | OpticiansEyeglasses
        | OptometristsOphthalmologist
        | OrthopedicGoodsProstheticDevices
        | Osteopaths
        | PackageStoresBeerWineAndLiquor
        | PaintsVarnishesAndSupplies
        | ParkingLotsGarages
        | PassengerRailways
        | PawnShops
        | PetShopsPetFoodAndSupplies
        | PetroleumAndPetroleumProducts
        | PhotoDeveloping
        | PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | PhotographicStudios
        | PictureVideoProduction
        | PieceGoodsNotionsAndOtherDryGoods
        | PlumbingHeatingEquipmentAndSupplies
        | PoliticalOrganizations
        | PostalServicesGovernmentOnly
        | PreciousStonesAndMetalsWatchesAndJewelry
        | ProfessionalServices
        | PublicWarehousingAndStorage
        | QuickCopyReproAndBlueprint
        | Railroads
        | RealEstateAgentsAndManagersRentals
        | RecordStores
        | RecreationalVehicleRentals
        | ReligiousGoodsStores
        | ReligiousOrganizations
        | RoofingSidingSheetMetal
        | SecretarialSupportServices
        | SecurityBrokersDealers
        | ServiceStations
        | SewingNeedleworkFabricAndPieceGoodsStores
        | ShoeRepairHatCleaning
        | ShoeStores
        | SmallApplianceRepair
        | SnowmobileDealers
        | SpecialTradeServices
        | SpecialtyCleaning
        | SportingGoodsStores
        | SportingRecreationCamps
        | SportsAndRidingApparelStores
        | SportsClubsFields
        | StampAndCoinStores
        | StationaryOfficeSuppliesPrintingAndWritingPaper
        | StationeryStoresOfficeAndSchoolSupplyStores
        | SwimmingPoolsSales
        | TUiTravelGermany
        | TailorsAlterations
        | TaxPaymentsGovernmentAgencies
        | TaxPreparationServices
        | TaxicabsLimousines
        | TelecommunicationEquipmentAndTelephoneSales
        | TelecommunicationServices
        | TelegraphServices
        | TentAndAwningShops
        | TestingLaboratories
        | TheatricalTicketAgencies
        | Timeshares
        | TireRetreadingAndRepair
        | TollsBridgeFees
        | TouristAttractionsAndExhibits
        | TowingServices
        | TrailerParksCampgrounds
        | TransportationServices
        | TravelAgenciesTourOperators
        | TruckStopIteration
        | TruckUtilityTrailerRentals
        | TypesettingPlateMakingAndRelatedServices
        | TypewriterStores
        | USFederalGovernmentAgenciesOrDepartments
        | UniformsCommercialClothing
        | UsedMerchandiseAndSecondhandStores
        | Utilities
        | VarietyStores
        | VeterinaryServices
        | VideoAmusementGameSupplies
        | VideoGameArcades
        | VideoTapeRentalStores
        | VocationalTradeSchools
        | WatchJewelryRepair
        | WeldingRepair
        | WholesaleClubs
        | WigAndToupeeStores
        | WiresMoneyOrders
        | WomensAccessoryAndSpecialtyShops
        | WomensReadyToWearStores
        | WreckingAndSalvageYards

    type Update'SpendingControlsSpendingLimitsInterval =
        | AllTime
        | Daily
        | Monthly
        | PerAuthorization
        | Weekly
        | Yearly

    type Update'SpendingControlsSpendingLimits =
        {
            /// Maximum amount allowed to spend per interval.
            [<Config.Form>]
            Amount: int option
            /// Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) this limit applies to. Omitting this field will apply the limit to all categories.
            [<Config.Form>]
            Categories: Update'SpendingControlsSpendingLimitsCategories list option
            /// Interval (or event) to which the amount applies.
            [<Config.Form>]
            Interval: Update'SpendingControlsSpendingLimitsInterval option
        }

    type Update'SpendingControlsSpendingLimits with
        static member New(?amount: int, ?categories: Update'SpendingControlsSpendingLimitsCategories list, ?interval: Update'SpendingControlsSpendingLimitsInterval) =
            {
                Amount = amount
                Categories = categories
                Interval = interval
            }

    module Update'SpendingControlsSpendingLimits =
        let create
            (
                amount: int option,
                categories: Update'SpendingControlsSpendingLimitsCategories list option,
                interval: Update'SpendingControlsSpendingLimitsInterval option
            ) : Update'SpendingControlsSpendingLimits
            =
            {
              Amount = amount
              Categories = categories
              Interval = interval
            }

    type Update'SpendingControls =
        {
            /// Array of card presence statuses from which authorizations will be allowed. Possible options are `present`, `not_present`. All other statuses will be blocked. Cannot be set with `blocked_card_presences`. Provide an empty value to unset this control.
            [<Config.Form>]
            AllowedCardPresences: Update'SpendingControlsAllowedCardPresences list option
            /// Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) of authorizations to allow. All other categories will be blocked. Cannot be set with `blocked_categories`.
            [<Config.Form>]
            AllowedCategories: Update'SpendingControlsAllowedCategories list option
            /// Array of strings containing representing countries from which authorizations will be allowed. Authorizations from merchants in all other countries will be declined. Country codes should be ISO 3166 alpha-2 country codes (e.g. `US`). Cannot be set with `blocked_merchant_countries`. Provide an empty value to unset this control.
            [<Config.Form>]
            AllowedMerchantCountries: string list option
            /// Array of card presence statuses from which authorizations will be declined. Possible options are `present`, `not_present`. Cannot be set with `allowed_card_presences`. Provide an empty value to unset this control.
            [<Config.Form>]
            BlockedCardPresences: Update'SpendingControlsBlockedCardPresences list option
            /// Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) of authorizations to decline. All other categories will be allowed. Cannot be set with `allowed_categories`.
            [<Config.Form>]
            BlockedCategories: Update'SpendingControlsBlockedCategories list option
            /// Array of strings containing representing countries from which authorizations will be declined. Country codes should be ISO 3166 alpha-2 country codes (e.g. `US`). Cannot be set with `allowed_merchant_countries`. Provide an empty value to unset this control.
            [<Config.Form>]
            BlockedMerchantCountries: string list option
            /// Limit spending with amount-based rules that apply across this cardholder's cards.
            [<Config.Form>]
            SpendingLimits: Update'SpendingControlsSpendingLimits list option
            /// Currency of amounts within `spending_limits`. Defaults to your merchant country's currency.
            [<Config.Form>]
            SpendingLimitsCurrency: IsoTypes.IsoCurrencyCode option
        }

    type Update'SpendingControls with
        static member New(?allowedCardPresences: Update'SpendingControlsAllowedCardPresences list, ?allowedCategories: Update'SpendingControlsAllowedCategories list, ?allowedMerchantCountries: string list, ?blockedCardPresences: Update'SpendingControlsBlockedCardPresences list, ?blockedCategories: Update'SpendingControlsBlockedCategories list, ?blockedMerchantCountries: string list, ?spendingLimits: Update'SpendingControlsSpendingLimits list, ?spendingLimitsCurrency: IsoTypes.IsoCurrencyCode) =
            {
                AllowedCardPresences = allowedCardPresences
                AllowedCategories = allowedCategories
                AllowedMerchantCountries = allowedMerchantCountries
                BlockedCardPresences = blockedCardPresences
                BlockedCategories = blockedCategories
                BlockedMerchantCountries = blockedMerchantCountries
                SpendingLimits = spendingLimits
                SpendingLimitsCurrency = spendingLimitsCurrency
            }

    module Update'SpendingControls =
        let create
            (
                allowedCardPresences: Update'SpendingControlsAllowedCardPresences list option,
                allowedCategories: Update'SpendingControlsAllowedCategories list option,
                allowedMerchantCountries: string list option,
                blockedCardPresences: Update'SpendingControlsBlockedCardPresences list option,
                blockedCategories: Update'SpendingControlsBlockedCategories list option,
                blockedMerchantCountries: string list option,
                spendingLimits: Update'SpendingControlsSpendingLimits list option,
                spendingLimitsCurrency: IsoTypes.IsoCurrencyCode option
            ) : Update'SpendingControls
            =
            {
              AllowedCardPresences = allowedCardPresences
              AllowedCategories = allowedCategories
              AllowedMerchantCountries = allowedMerchantCountries
              BlockedCardPresences = blockedCardPresences
              BlockedCategories = blockedCategories
              BlockedMerchantCountries = blockedMerchantCountries
              SpendingLimits = spendingLimits
              SpendingLimitsCurrency = spendingLimitsCurrency
            }

    type Update'Status =
        | Active
        | Inactive

    type UpdateOptions =
        {
            [<Config.Path>]
            Cardholder: string
            /// The cardholder's billing address.
            [<Config.Form>]
            Billing: Update'Billing option
            /// Additional information about a `company` cardholder.
            [<Config.Form>]
            Company: Update'Company option
            /// The cardholder's email address.
            [<Config.Form>]
            Email: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Additional information about an `individual` cardholder.
            [<Config.Form>]
            Individual: Update'Individual option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The cardholder's phone number. This is required for all cardholders who will be creating EU cards. See the [3D Secure documentation](https://docs.stripe.com/issuing/3d-secure) for more details.
            [<Config.Form>]
            PhoneNumber: string option
            /// The cardholder’s preferred locales (languages), ordered by preference. Locales can be `da`, `de`, `en`, `es`, `fr`, `it`, `pl`, or `sv`.
            /// This changes the language of the [3D Secure flow](https://docs.stripe.com/issuing/3d-secure) and one-time password messages sent to the cardholder.
            [<Config.Form>]
            PreferredLocales: Update'PreferredLocales list option
            /// Rules that control spending across this cardholder's cards. Refer to our [documentation](https://docs.stripe.com/issuing/controls/spending-controls) for more details.
            [<Config.Form>]
            SpendingControls: Update'SpendingControls option
            /// Specifies whether to permit authorizations on this cardholder's cards.
            [<Config.Form>]
            Status: Update'Status option
        }

    type UpdateOptions with
        static member New(cardholder: string, ?billing: Update'Billing, ?company: Update'Company, ?email: string, ?expand: string list, ?individual: Update'Individual, ?metadata: Map<string, string>, ?phoneNumber: string, ?preferredLocales: Update'PreferredLocales list, ?spendingControls: Update'SpendingControls, ?status: Update'Status) =
            {
                Cardholder = cardholder
                Billing = billing
                Company = company
                Email = email
                Expand = expand
                Individual = individual
                Metadata = metadata
                PhoneNumber = phoneNumber
                PreferredLocales = preferredLocales
                SpendingControls = spendingControls
                Status = status
            }

    module UpdateOptions =
        let create
            (
                cardholder: string
            ) : UpdateOptions
            =
            {
              Cardholder = cardholder
              Billing = None
              Company = None
              Email = None
              Expand = None
              Individual = None
              Metadata = None
              PhoneNumber = None
              PreferredLocales = None
              SpendingControls = None
              Status = None
            }

    ///<p>Returns a list of Issuing <code>Cardholder</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("email", options.Email |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("phone_number", options.PhoneNumber |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("type", options.Type |> box)] |> Map.ofList
        $"/v1/issuing/cardholders"
        |> RestApi.getAsync<StripeList<IssuingCardholder>> settings qs

    ///<p>Creates a new Issuing <code>Cardholder</code> object that can be issued cards.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/issuing/cardholders"
        |> RestApi.postAsync<_, IssuingCardholder> settings (Map.empty) options

    ///<p>Retrieves an Issuing <code>Cardholder</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/issuing/cardholders/{options.Cardholder}"
        |> RestApi.getAsync<IssuingCardholder> settings qs

    ///<p>Updates the specified Issuing <code>Cardholder</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/issuing/cardholders/{options.Cardholder}"
        |> RestApi.postAsync<_, IssuingCardholder> settings (Map.empty) options

module IssuingCards =

    type ListOptions =
        {
            /// Only return cards belonging to the Cardholder with the provided ID.
            [<Config.Query>]
            Cardholder: string option
            /// Only return cards that were issued during the given date interval.
            [<Config.Query>]
            Created: int option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Only return cards that have the given expiration month.
            [<Config.Query>]
            ExpMonth: int option
            /// Only return cards that have the given expiration year.
            [<Config.Query>]
            ExpYear: int option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// Only return cards that have the given last four digits.
            [<Config.Query>]
            Last4: string option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            [<Config.Query>]
            PersonalizationDesign: string option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return cards that have the given status. One of `active`, `inactive`, or `canceled`.
            [<Config.Query>]
            Status: string option
            /// Only return cards that have the given type. One of `virtual` or `physical`.
            [<Config.Query>]
            Type: string option
        }

    type ListOptions with
        static member New(?cardholder: string, ?created: int, ?endingBefore: string, ?expMonth: int, ?expYear: int, ?expand: string list, ?last4: string, ?limit: int, ?personalizationDesign: string, ?startingAfter: string, ?status: string, ?type': string) =
            {
                Cardholder = cardholder
                Created = created
                EndingBefore = endingBefore
                ExpMonth = expMonth
                ExpYear = expYear
                Expand = expand
                Last4 = last4
                Limit = limit
                PersonalizationDesign = personalizationDesign
                StartingAfter = startingAfter
                Status = status
                Type = type'
            }

    module ListOptions =
        let create
            (
                cardholder: string option,
                created: int option,
                endingBefore: string option,
                expMonth: int option,
                expYear: int option,
                expand: string list option,
                last4: string option,
                limit: int option,
                personalizationDesign: string option,
                startingAfter: string option,
                status: string option,
                type': string option
            ) : ListOptions
            =
            {
              Cardholder = cardholder
              Created = created
              EndingBefore = endingBefore
              ExpMonth = expMonth
              ExpYear = expYear
              Expand = expand
              Last4 = last4
              Limit = limit
              PersonalizationDesign = personalizationDesign
              StartingAfter = startingAfter
              Status = status
              Type = type'
            }

    type Create'LifecycleControlsCancelAfter =
        {
            /// The card is automatically cancelled when it makes this number of non-zero payment authorizations and transactions. The count includes penny authorizations, but doesn't include non-payment actions, such as authorization advice.
            [<Config.Form>]
            PaymentCount: int option
        }

    type Create'LifecycleControlsCancelAfter with
        static member New(?paymentCount: int) =
            {
                PaymentCount = paymentCount
            }

    module Create'LifecycleControlsCancelAfter =
        let create
            (
                paymentCount: int option
            ) : Create'LifecycleControlsCancelAfter
            =
            {
              PaymentCount = paymentCount
            }

    type Create'LifecycleControls =
        {
            /// Cancels the card after the specified conditions are met.
            [<Config.Form>]
            CancelAfter: Create'LifecycleControlsCancelAfter option
        }

    type Create'LifecycleControls with
        static member New(?cancelAfter: Create'LifecycleControlsCancelAfter) =
            {
                CancelAfter = cancelAfter
            }

    module Create'LifecycleControls =
        let create
            (
                cancelAfter: Create'LifecycleControlsCancelAfter option
            ) : Create'LifecycleControls
            =
            {
              CancelAfter = cancelAfter
            }

    type Create'Pin =
        {
            /// The card's desired new PIN, encrypted under Stripe's public key.
            [<Config.Form>]
            EncryptedNumber: string option
        }

    type Create'Pin with
        static member New(?encryptedNumber: string) =
            {
                EncryptedNumber = encryptedNumber
            }

    module Create'Pin =
        let create
            (
                encryptedNumber: string option
            ) : Create'Pin
            =
            {
              EncryptedNumber = encryptedNumber
            }

    type Create'ReplacementReason =
        | Damaged
        | Expired
        | Lost
        | Stolen

    type Create'ShippingAddress =
        {
            /// City, district, suburb, town, or village.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Address line 1, such as the street, PO Box, or company name.
            [<Config.Form>]
            Line1: string option
            /// Address line 2, such as the apartment, suite, unit, or building.
            [<Config.Form>]
            Line2: string option
            /// ZIP or postal code.
            [<Config.Form>]
            PostalCode: string option
            /// State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
            [<Config.Form>]
            State: string option
        }

    type Create'ShippingAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    module Create'ShippingAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Create'ShippingAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Create'ShippingAddressValidationMode =
        | Disabled
        | NormalizationOnly
        | ValidationAndNormalization

    type Create'ShippingAddressValidation =
        {
            /// The address validation capabilities to use.
            [<Config.Form>]
            Mode: Create'ShippingAddressValidationMode option
        }

    type Create'ShippingAddressValidation with
        static member New(?mode: Create'ShippingAddressValidationMode) =
            {
                Mode = mode
            }

    module Create'ShippingAddressValidation =
        let create
            (
                mode: Create'ShippingAddressValidationMode option
            ) : Create'ShippingAddressValidation
            =
            {
              Mode = mode
            }

    type Create'ShippingCustoms =
        {
            /// The Economic Operators Registration and Identification (EORI) number to use for Customs. Required for bulk shipments to Europe.
            [<Config.Form>]
            EoriNumber: string option
        }

    type Create'ShippingCustoms with
        static member New(?eoriNumber: string) =
            {
                EoriNumber = eoriNumber
            }

    module Create'ShippingCustoms =
        let create
            (
                eoriNumber: string option
            ) : Create'ShippingCustoms
            =
            {
              EoriNumber = eoriNumber
            }

    type Create'ShippingService =
        | Express
        | Priority
        | Standard

    type Create'ShippingType =
        | Bulk
        | Individual

    type Create'Shipping =
        {
            /// The address that the card is shipped to.
            [<Config.Form>]
            Address: Create'ShippingAddress option
            /// Address validation settings.
            [<Config.Form>]
            AddressValidation: Create'ShippingAddressValidation option
            /// Customs information for the shipment.
            [<Config.Form>]
            Customs: Create'ShippingCustoms option
            /// The name printed on the shipping label when shipping the card.
            [<Config.Form>]
            Name: string option
            /// Phone number of the recipient of the shipment.
            [<Config.Form>]
            PhoneNumber: string option
            /// Whether a signature is required for card delivery.
            [<Config.Form>]
            RequireSignature: bool option
            /// Shipment service.
            [<Config.Form>]
            Service: Create'ShippingService option
            /// Packaging options.
            [<Config.Form>]
            Type: Create'ShippingType option
        }

    type Create'Shipping with
        static member New(?address: Create'ShippingAddress, ?addressValidation: Create'ShippingAddressValidation, ?customs: Create'ShippingCustoms, ?name: string, ?phoneNumber: string, ?requireSignature: bool, ?service: Create'ShippingService, ?type': Create'ShippingType) =
            {
                Address = address
                AddressValidation = addressValidation
                Customs = customs
                Name = name
                PhoneNumber = phoneNumber
                RequireSignature = requireSignature
                Service = service
                Type = type'
            }

    module Create'Shipping =
        let create
            (
                address: Create'ShippingAddress option,
                addressValidation: Create'ShippingAddressValidation option,
                customs: Create'ShippingCustoms option,
                name: string option,
                phoneNumber: string option,
                requireSignature: bool option,
                service: Create'ShippingService option,
                type': Create'ShippingType option
            ) : Create'Shipping
            =
            {
              Address = address
              AddressValidation = addressValidation
              Customs = customs
              Name = name
              PhoneNumber = phoneNumber
              RequireSignature = requireSignature
              Service = service
              Type = type'
            }

    type Create'SpendingControlsAllowedCardPresences =
        | NotPresent
        | Present

    type Create'SpendingControlsAllowedCategories =
        | AcRefrigerationRepair
        | AccountingBookkeepingServices
        | AdvertisingServices
        | AgriculturalCooperative
        | AirlinesAirCarriers
        | AirportsFlyingFields
        | AmbulanceServices
        | AmusementParksCarnivals
        | AntiqueReproductions
        | AntiqueShops
        | Aquariums
        | ArchitecturalSurveyingServices
        | ArtDealersAndGalleries
        | ArtistsSupplyAndCraftShops
        | AutoAndHomeSupplyStores
        | AutoBodyRepairShops
        | AutoPaintShops
        | AutoServiceShops
        | AutomatedCashDisburse
        | AutomatedFuelDispensers
        | AutomobileAssociations
        | AutomotivePartsAndAccessoriesStores
        | AutomotiveTireStores
        | BailAndBondPayments
        | Bakeries
        | BandsOrchestras
        | BarberAndBeautyShops
        | BettingCasinoGambling
        | BicycleShops
        | BilliardPoolEstablishments
        | BoatDealers
        | BoatRentalsAndLeases
        | BookStores
        | BooksPeriodicalsAndNewspapers
        | BowlingAlleys
        | BusLines
        | BusinessSecretarialSchools
        | BuyingShoppingServices
        | CableSatelliteAndOtherPayTelevisionAndRadio
        | CameraAndPhotographicSupplyStores
        | CandyNutAndConfectioneryStores
        | CarAndTruckDealersNewUsed
        | CarAndTruckDealersUsedOnly
        | CarRentalAgencies
        | CarWashes
        | CarpentryServices
        | CarpetUpholsteryCleaning
        | Caterers
        | CharitableAndSocialServiceOrganizationsFundraising
        | ChemicalsAndAlliedProducts
        | ChildCareServices
        | ChildrensAndInfantsWearStores
        | ChiropodistsPodiatrists
        | Chiropractors
        | CigarStoresAndStands
        | CivicSocialFraternalAssociations
        | CleaningAndMaintenance
        | ClothingRental
        | CollegesUniversities
        | CommercialEquipment
        | CommercialFootwear
        | CommercialPhotographyArtAndGraphics
        | CommuterTransportAndFerries
        | ComputerNetworkServices
        | ComputerProgramming
        | ComputerRepair
        | ComputerSoftwareStores
        | ComputersPeripheralsAndSoftware
        | ConcreteWorkServices
        | ConstructionMaterials
        | ConsultingPublicRelations
        | CorrespondenceSchools
        | CosmeticStores
        | CounselingServices
        | CountryClubs
        | CourierServices
        | CourtCosts
        | CreditReportingAgencies
        | CruiseLines
        | DairyProductsStores
        | DanceHallStudiosSchools
        | DatingEscortServices
        | DentistsOrthodontists
        | DepartmentStores
        | DetectiveAgencies
        | DigitalGoodsApplications
        | DigitalGoodsGames
        | DigitalGoodsLargeVolume
        | DigitalGoodsMedia
        | DirectMarketingCatalogMerchant
        | DirectMarketingCombinationCatalogAndRetailMerchant
        | DirectMarketingInboundTelemarketing
        | DirectMarketingInsuranceServices
        | DirectMarketingOther
        | DirectMarketingOutboundTelemarketing
        | DirectMarketingSubscription
        | DirectMarketingTravel
        | DiscountStores
        | Doctors
        | DoorToDoorSales
        | DraperyWindowCoveringAndUpholsteryStores
        | DrinkingPlaces
        | DrugStoresAndPharmacies
        | DrugsDrugProprietariesAndDruggistSundries
        | DryCleaners
        | DurableGoods
        | DutyFreeStores
        | EatingPlacesRestaurants
        | EducationalServices
        | ElectricRazorStores
        | ElectricVehicleCharging
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
        | EmergencyServicesGcasVisaUseOnly
        | EmploymentTempAgencies
        | EquipmentRental
        | ExterminatingServices
        | FamilyClothingStores
        | FastFoodRestaurants
        | FinancialInstitutions
        | FinesGovernmentAdministrativeEntities
        | FireplaceFireplaceScreensAndAccessoriesStores
        | FloorCoveringStores
        | Florists
        | FloristsSuppliesNurseryStockAndFlowers
        | FreezerAndLockerMeatProvisioners
        | FuelDealersNonAutomotive
        | FuneralServicesCrematories
        | FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | FurnitureRepairRefinishing
        | FurriersAndFurShops
        | GeneralServices
        | GiftCardNoveltyAndSouvenirShops
        | GlassPaintAndWallpaperStores
        | GlasswareCrystalStores
        | GolfCoursesPublic
        | GovernmentLicensedHorseDogRacingUsRegionOnly
        | GovernmentLicensedOnlineCasionsOnlineGamblingUsRegionOnly
        | GovernmentOwnedLotteriesNonUsRegion
        | GovernmentOwnedLotteriesUsRegionOnly
        | GovernmentServices
        | GroceryStoresSupermarkets
        | HardwareEquipmentAndSupplies
        | HardwareStores
        | HealthAndBeautySpas
        | HearingAidsSalesAndSupplies
        | HeatingPlumbingAC
        | HobbyToyAndGameShops
        | HomeSupplyWarehouseStores
        | Hospitals
        | HotelsMotelsAndResorts
        | HouseholdApplianceStores
        | IndustrialSupplies
        | InformationRetrievalServices
        | InsuranceDefault
        | InsuranceUnderwritingPremiums
        | IntraCompanyPurchases
        | JewelryStoresWatchesClocksAndSilverwareStores
        | LandscapingServices
        | Laundries
        | LaundryCleaningServices
        | LegalServicesAttorneys
        | LuggageAndLeatherGoodsStores
        | LumberBuildingMaterialsStores
        | ManualCashDisburse
        | MarinasServiceAndSupplies
        | Marketplaces
        | MasonryStoneworkAndPlaster
        | MassageParlors
        | MedicalAndDentalLabs
        | MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | MedicalServices
        | MembershipOrganizations
        | MensAndBoysClothingAndAccessoriesStores
        | MensWomensClothingStores
        | MetalServiceCenters
        | Miscellaneous
        | MiscellaneousApparelAndAccessoryShops
        | MiscellaneousAutoDealers
        | MiscellaneousBusinessServices
        | MiscellaneousFoodStores
        | MiscellaneousGeneralMerchandise
        | MiscellaneousGeneralServices
        | MiscellaneousHomeFurnishingSpecialtyStores
        | MiscellaneousPublishingAndPrinting
        | MiscellaneousRecreationServices
        | MiscellaneousRepairShops
        | MiscellaneousSpecialtyRetail
        | MobileHomeDealers
        | MotionPictureTheaters
        | MotorFreightCarriersAndTrucking
        | MotorHomesDealers
        | MotorVehicleSuppliesAndNewParts
        | MotorcycleShopsAndDealers
        | MotorcycleShopsDealers
        | MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | NewsDealersAndNewsstands
        | NonFiMoneyOrders
        | NonFiStoredValueCardPurchaseLoad
        | NondurableGoods
        | NurseriesLawnAndGardenSupplyStores
        | NursingPersonalCare
        | OfficeAndCommercialFurniture
        | OpticiansEyeglasses
        | OptometristsOphthalmologist
        | OrthopedicGoodsProstheticDevices
        | Osteopaths
        | PackageStoresBeerWineAndLiquor
        | PaintsVarnishesAndSupplies
        | ParkingLotsGarages
        | PassengerRailways
        | PawnShops
        | PetShopsPetFoodAndSupplies
        | PetroleumAndPetroleumProducts
        | PhotoDeveloping
        | PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | PhotographicStudios
        | PictureVideoProduction
        | PieceGoodsNotionsAndOtherDryGoods
        | PlumbingHeatingEquipmentAndSupplies
        | PoliticalOrganizations
        | PostalServicesGovernmentOnly
        | PreciousStonesAndMetalsWatchesAndJewelry
        | ProfessionalServices
        | PublicWarehousingAndStorage
        | QuickCopyReproAndBlueprint
        | Railroads
        | RealEstateAgentsAndManagersRentals
        | RecordStores
        | RecreationalVehicleRentals
        | ReligiousGoodsStores
        | ReligiousOrganizations
        | RoofingSidingSheetMetal
        | SecretarialSupportServices
        | SecurityBrokersDealers
        | ServiceStations
        | SewingNeedleworkFabricAndPieceGoodsStores
        | ShoeRepairHatCleaning
        | ShoeStores
        | SmallApplianceRepair
        | SnowmobileDealers
        | SpecialTradeServices
        | SpecialtyCleaning
        | SportingGoodsStores
        | SportingRecreationCamps
        | SportsAndRidingApparelStores
        | SportsClubsFields
        | StampAndCoinStores
        | StationaryOfficeSuppliesPrintingAndWritingPaper
        | StationeryStoresOfficeAndSchoolSupplyStores
        | SwimmingPoolsSales
        | TUiTravelGermany
        | TailorsAlterations
        | TaxPaymentsGovernmentAgencies
        | TaxPreparationServices
        | TaxicabsLimousines
        | TelecommunicationEquipmentAndTelephoneSales
        | TelecommunicationServices
        | TelegraphServices
        | TentAndAwningShops
        | TestingLaboratories
        | TheatricalTicketAgencies
        | Timeshares
        | TireRetreadingAndRepair
        | TollsBridgeFees
        | TouristAttractionsAndExhibits
        | TowingServices
        | TrailerParksCampgrounds
        | TransportationServices
        | TravelAgenciesTourOperators
        | TruckStopIteration
        | TruckUtilityTrailerRentals
        | TypesettingPlateMakingAndRelatedServices
        | TypewriterStores
        | USFederalGovernmentAgenciesOrDepartments
        | UniformsCommercialClothing
        | UsedMerchandiseAndSecondhandStores
        | Utilities
        | VarietyStores
        | VeterinaryServices
        | VideoAmusementGameSupplies
        | VideoGameArcades
        | VideoTapeRentalStores
        | VocationalTradeSchools
        | WatchJewelryRepair
        | WeldingRepair
        | WholesaleClubs
        | WigAndToupeeStores
        | WiresMoneyOrders
        | WomensAccessoryAndSpecialtyShops
        | WomensReadyToWearStores
        | WreckingAndSalvageYards

    type Create'SpendingControlsBlockedCardPresences =
        | NotPresent
        | Present

    type Create'SpendingControlsBlockedCategories =
        | AcRefrigerationRepair
        | AccountingBookkeepingServices
        | AdvertisingServices
        | AgriculturalCooperative
        | AirlinesAirCarriers
        | AirportsFlyingFields
        | AmbulanceServices
        | AmusementParksCarnivals
        | AntiqueReproductions
        | AntiqueShops
        | Aquariums
        | ArchitecturalSurveyingServices
        | ArtDealersAndGalleries
        | ArtistsSupplyAndCraftShops
        | AutoAndHomeSupplyStores
        | AutoBodyRepairShops
        | AutoPaintShops
        | AutoServiceShops
        | AutomatedCashDisburse
        | AutomatedFuelDispensers
        | AutomobileAssociations
        | AutomotivePartsAndAccessoriesStores
        | AutomotiveTireStores
        | BailAndBondPayments
        | Bakeries
        | BandsOrchestras
        | BarberAndBeautyShops
        | BettingCasinoGambling
        | BicycleShops
        | BilliardPoolEstablishments
        | BoatDealers
        | BoatRentalsAndLeases
        | BookStores
        | BooksPeriodicalsAndNewspapers
        | BowlingAlleys
        | BusLines
        | BusinessSecretarialSchools
        | BuyingShoppingServices
        | CableSatelliteAndOtherPayTelevisionAndRadio
        | CameraAndPhotographicSupplyStores
        | CandyNutAndConfectioneryStores
        | CarAndTruckDealersNewUsed
        | CarAndTruckDealersUsedOnly
        | CarRentalAgencies
        | CarWashes
        | CarpentryServices
        | CarpetUpholsteryCleaning
        | Caterers
        | CharitableAndSocialServiceOrganizationsFundraising
        | ChemicalsAndAlliedProducts
        | ChildCareServices
        | ChildrensAndInfantsWearStores
        | ChiropodistsPodiatrists
        | Chiropractors
        | CigarStoresAndStands
        | CivicSocialFraternalAssociations
        | CleaningAndMaintenance
        | ClothingRental
        | CollegesUniversities
        | CommercialEquipment
        | CommercialFootwear
        | CommercialPhotographyArtAndGraphics
        | CommuterTransportAndFerries
        | ComputerNetworkServices
        | ComputerProgramming
        | ComputerRepair
        | ComputerSoftwareStores
        | ComputersPeripheralsAndSoftware
        | ConcreteWorkServices
        | ConstructionMaterials
        | ConsultingPublicRelations
        | CorrespondenceSchools
        | CosmeticStores
        | CounselingServices
        | CountryClubs
        | CourierServices
        | CourtCosts
        | CreditReportingAgencies
        | CruiseLines
        | DairyProductsStores
        | DanceHallStudiosSchools
        | DatingEscortServices
        | DentistsOrthodontists
        | DepartmentStores
        | DetectiveAgencies
        | DigitalGoodsApplications
        | DigitalGoodsGames
        | DigitalGoodsLargeVolume
        | DigitalGoodsMedia
        | DirectMarketingCatalogMerchant
        | DirectMarketingCombinationCatalogAndRetailMerchant
        | DirectMarketingInboundTelemarketing
        | DirectMarketingInsuranceServices
        | DirectMarketingOther
        | DirectMarketingOutboundTelemarketing
        | DirectMarketingSubscription
        | DirectMarketingTravel
        | DiscountStores
        | Doctors
        | DoorToDoorSales
        | DraperyWindowCoveringAndUpholsteryStores
        | DrinkingPlaces
        | DrugStoresAndPharmacies
        | DrugsDrugProprietariesAndDruggistSundries
        | DryCleaners
        | DurableGoods
        | DutyFreeStores
        | EatingPlacesRestaurants
        | EducationalServices
        | ElectricRazorStores
        | ElectricVehicleCharging
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
        | EmergencyServicesGcasVisaUseOnly
        | EmploymentTempAgencies
        | EquipmentRental
        | ExterminatingServices
        | FamilyClothingStores
        | FastFoodRestaurants
        | FinancialInstitutions
        | FinesGovernmentAdministrativeEntities
        | FireplaceFireplaceScreensAndAccessoriesStores
        | FloorCoveringStores
        | Florists
        | FloristsSuppliesNurseryStockAndFlowers
        | FreezerAndLockerMeatProvisioners
        | FuelDealersNonAutomotive
        | FuneralServicesCrematories
        | FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | FurnitureRepairRefinishing
        | FurriersAndFurShops
        | GeneralServices
        | GiftCardNoveltyAndSouvenirShops
        | GlassPaintAndWallpaperStores
        | GlasswareCrystalStores
        | GolfCoursesPublic
        | GovernmentLicensedHorseDogRacingUsRegionOnly
        | GovernmentLicensedOnlineCasionsOnlineGamblingUsRegionOnly
        | GovernmentOwnedLotteriesNonUsRegion
        | GovernmentOwnedLotteriesUsRegionOnly
        | GovernmentServices
        | GroceryStoresSupermarkets
        | HardwareEquipmentAndSupplies
        | HardwareStores
        | HealthAndBeautySpas
        | HearingAidsSalesAndSupplies
        | HeatingPlumbingAC
        | HobbyToyAndGameShops
        | HomeSupplyWarehouseStores
        | Hospitals
        | HotelsMotelsAndResorts
        | HouseholdApplianceStores
        | IndustrialSupplies
        | InformationRetrievalServices
        | InsuranceDefault
        | InsuranceUnderwritingPremiums
        | IntraCompanyPurchases
        | JewelryStoresWatchesClocksAndSilverwareStores
        | LandscapingServices
        | Laundries
        | LaundryCleaningServices
        | LegalServicesAttorneys
        | LuggageAndLeatherGoodsStores
        | LumberBuildingMaterialsStores
        | ManualCashDisburse
        | MarinasServiceAndSupplies
        | Marketplaces
        | MasonryStoneworkAndPlaster
        | MassageParlors
        | MedicalAndDentalLabs
        | MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | MedicalServices
        | MembershipOrganizations
        | MensAndBoysClothingAndAccessoriesStores
        | MensWomensClothingStores
        | MetalServiceCenters
        | Miscellaneous
        | MiscellaneousApparelAndAccessoryShops
        | MiscellaneousAutoDealers
        | MiscellaneousBusinessServices
        | MiscellaneousFoodStores
        | MiscellaneousGeneralMerchandise
        | MiscellaneousGeneralServices
        | MiscellaneousHomeFurnishingSpecialtyStores
        | MiscellaneousPublishingAndPrinting
        | MiscellaneousRecreationServices
        | MiscellaneousRepairShops
        | MiscellaneousSpecialtyRetail
        | MobileHomeDealers
        | MotionPictureTheaters
        | MotorFreightCarriersAndTrucking
        | MotorHomesDealers
        | MotorVehicleSuppliesAndNewParts
        | MotorcycleShopsAndDealers
        | MotorcycleShopsDealers
        | MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | NewsDealersAndNewsstands
        | NonFiMoneyOrders
        | NonFiStoredValueCardPurchaseLoad
        | NondurableGoods
        | NurseriesLawnAndGardenSupplyStores
        | NursingPersonalCare
        | OfficeAndCommercialFurniture
        | OpticiansEyeglasses
        | OptometristsOphthalmologist
        | OrthopedicGoodsProstheticDevices
        | Osteopaths
        | PackageStoresBeerWineAndLiquor
        | PaintsVarnishesAndSupplies
        | ParkingLotsGarages
        | PassengerRailways
        | PawnShops
        | PetShopsPetFoodAndSupplies
        | PetroleumAndPetroleumProducts
        | PhotoDeveloping
        | PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | PhotographicStudios
        | PictureVideoProduction
        | PieceGoodsNotionsAndOtherDryGoods
        | PlumbingHeatingEquipmentAndSupplies
        | PoliticalOrganizations
        | PostalServicesGovernmentOnly
        | PreciousStonesAndMetalsWatchesAndJewelry
        | ProfessionalServices
        | PublicWarehousingAndStorage
        | QuickCopyReproAndBlueprint
        | Railroads
        | RealEstateAgentsAndManagersRentals
        | RecordStores
        | RecreationalVehicleRentals
        | ReligiousGoodsStores
        | ReligiousOrganizations
        | RoofingSidingSheetMetal
        | SecretarialSupportServices
        | SecurityBrokersDealers
        | ServiceStations
        | SewingNeedleworkFabricAndPieceGoodsStores
        | ShoeRepairHatCleaning
        | ShoeStores
        | SmallApplianceRepair
        | SnowmobileDealers
        | SpecialTradeServices
        | SpecialtyCleaning
        | SportingGoodsStores
        | SportingRecreationCamps
        | SportsAndRidingApparelStores
        | SportsClubsFields
        | StampAndCoinStores
        | StationaryOfficeSuppliesPrintingAndWritingPaper
        | StationeryStoresOfficeAndSchoolSupplyStores
        | SwimmingPoolsSales
        | TUiTravelGermany
        | TailorsAlterations
        | TaxPaymentsGovernmentAgencies
        | TaxPreparationServices
        | TaxicabsLimousines
        | TelecommunicationEquipmentAndTelephoneSales
        | TelecommunicationServices
        | TelegraphServices
        | TentAndAwningShops
        | TestingLaboratories
        | TheatricalTicketAgencies
        | Timeshares
        | TireRetreadingAndRepair
        | TollsBridgeFees
        | TouristAttractionsAndExhibits
        | TowingServices
        | TrailerParksCampgrounds
        | TransportationServices
        | TravelAgenciesTourOperators
        | TruckStopIteration
        | TruckUtilityTrailerRentals
        | TypesettingPlateMakingAndRelatedServices
        | TypewriterStores
        | USFederalGovernmentAgenciesOrDepartments
        | UniformsCommercialClothing
        | UsedMerchandiseAndSecondhandStores
        | Utilities
        | VarietyStores
        | VeterinaryServices
        | VideoAmusementGameSupplies
        | VideoGameArcades
        | VideoTapeRentalStores
        | VocationalTradeSchools
        | WatchJewelryRepair
        | WeldingRepair
        | WholesaleClubs
        | WigAndToupeeStores
        | WiresMoneyOrders
        | WomensAccessoryAndSpecialtyShops
        | WomensReadyToWearStores
        | WreckingAndSalvageYards

    type Create'SpendingControlsSpendingLimitsCategories =
        | AcRefrigerationRepair
        | AccountingBookkeepingServices
        | AdvertisingServices
        | AgriculturalCooperative
        | AirlinesAirCarriers
        | AirportsFlyingFields
        | AmbulanceServices
        | AmusementParksCarnivals
        | AntiqueReproductions
        | AntiqueShops
        | Aquariums
        | ArchitecturalSurveyingServices
        | ArtDealersAndGalleries
        | ArtistsSupplyAndCraftShops
        | AutoAndHomeSupplyStores
        | AutoBodyRepairShops
        | AutoPaintShops
        | AutoServiceShops
        | AutomatedCashDisburse
        | AutomatedFuelDispensers
        | AutomobileAssociations
        | AutomotivePartsAndAccessoriesStores
        | AutomotiveTireStores
        | BailAndBondPayments
        | Bakeries
        | BandsOrchestras
        | BarberAndBeautyShops
        | BettingCasinoGambling
        | BicycleShops
        | BilliardPoolEstablishments
        | BoatDealers
        | BoatRentalsAndLeases
        | BookStores
        | BooksPeriodicalsAndNewspapers
        | BowlingAlleys
        | BusLines
        | BusinessSecretarialSchools
        | BuyingShoppingServices
        | CableSatelliteAndOtherPayTelevisionAndRadio
        | CameraAndPhotographicSupplyStores
        | CandyNutAndConfectioneryStores
        | CarAndTruckDealersNewUsed
        | CarAndTruckDealersUsedOnly
        | CarRentalAgencies
        | CarWashes
        | CarpentryServices
        | CarpetUpholsteryCleaning
        | Caterers
        | CharitableAndSocialServiceOrganizationsFundraising
        | ChemicalsAndAlliedProducts
        | ChildCareServices
        | ChildrensAndInfantsWearStores
        | ChiropodistsPodiatrists
        | Chiropractors
        | CigarStoresAndStands
        | CivicSocialFraternalAssociations
        | CleaningAndMaintenance
        | ClothingRental
        | CollegesUniversities
        | CommercialEquipment
        | CommercialFootwear
        | CommercialPhotographyArtAndGraphics
        | CommuterTransportAndFerries
        | ComputerNetworkServices
        | ComputerProgramming
        | ComputerRepair
        | ComputerSoftwareStores
        | ComputersPeripheralsAndSoftware
        | ConcreteWorkServices
        | ConstructionMaterials
        | ConsultingPublicRelations
        | CorrespondenceSchools
        | CosmeticStores
        | CounselingServices
        | CountryClubs
        | CourierServices
        | CourtCosts
        | CreditReportingAgencies
        | CruiseLines
        | DairyProductsStores
        | DanceHallStudiosSchools
        | DatingEscortServices
        | DentistsOrthodontists
        | DepartmentStores
        | DetectiveAgencies
        | DigitalGoodsApplications
        | DigitalGoodsGames
        | DigitalGoodsLargeVolume
        | DigitalGoodsMedia
        | DirectMarketingCatalogMerchant
        | DirectMarketingCombinationCatalogAndRetailMerchant
        | DirectMarketingInboundTelemarketing
        | DirectMarketingInsuranceServices
        | DirectMarketingOther
        | DirectMarketingOutboundTelemarketing
        | DirectMarketingSubscription
        | DirectMarketingTravel
        | DiscountStores
        | Doctors
        | DoorToDoorSales
        | DraperyWindowCoveringAndUpholsteryStores
        | DrinkingPlaces
        | DrugStoresAndPharmacies
        | DrugsDrugProprietariesAndDruggistSundries
        | DryCleaners
        | DurableGoods
        | DutyFreeStores
        | EatingPlacesRestaurants
        | EducationalServices
        | ElectricRazorStores
        | ElectricVehicleCharging
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
        | EmergencyServicesGcasVisaUseOnly
        | EmploymentTempAgencies
        | EquipmentRental
        | ExterminatingServices
        | FamilyClothingStores
        | FastFoodRestaurants
        | FinancialInstitutions
        | FinesGovernmentAdministrativeEntities
        | FireplaceFireplaceScreensAndAccessoriesStores
        | FloorCoveringStores
        | Florists
        | FloristsSuppliesNurseryStockAndFlowers
        | FreezerAndLockerMeatProvisioners
        | FuelDealersNonAutomotive
        | FuneralServicesCrematories
        | FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | FurnitureRepairRefinishing
        | FurriersAndFurShops
        | GeneralServices
        | GiftCardNoveltyAndSouvenirShops
        | GlassPaintAndWallpaperStores
        | GlasswareCrystalStores
        | GolfCoursesPublic
        | GovernmentLicensedHorseDogRacingUsRegionOnly
        | GovernmentLicensedOnlineCasionsOnlineGamblingUsRegionOnly
        | GovernmentOwnedLotteriesNonUsRegion
        | GovernmentOwnedLotteriesUsRegionOnly
        | GovernmentServices
        | GroceryStoresSupermarkets
        | HardwareEquipmentAndSupplies
        | HardwareStores
        | HealthAndBeautySpas
        | HearingAidsSalesAndSupplies
        | HeatingPlumbingAC
        | HobbyToyAndGameShops
        | HomeSupplyWarehouseStores
        | Hospitals
        | HotelsMotelsAndResorts
        | HouseholdApplianceStores
        | IndustrialSupplies
        | InformationRetrievalServices
        | InsuranceDefault
        | InsuranceUnderwritingPremiums
        | IntraCompanyPurchases
        | JewelryStoresWatchesClocksAndSilverwareStores
        | LandscapingServices
        | Laundries
        | LaundryCleaningServices
        | LegalServicesAttorneys
        | LuggageAndLeatherGoodsStores
        | LumberBuildingMaterialsStores
        | ManualCashDisburse
        | MarinasServiceAndSupplies
        | Marketplaces
        | MasonryStoneworkAndPlaster
        | MassageParlors
        | MedicalAndDentalLabs
        | MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | MedicalServices
        | MembershipOrganizations
        | MensAndBoysClothingAndAccessoriesStores
        | MensWomensClothingStores
        | MetalServiceCenters
        | Miscellaneous
        | MiscellaneousApparelAndAccessoryShops
        | MiscellaneousAutoDealers
        | MiscellaneousBusinessServices
        | MiscellaneousFoodStores
        | MiscellaneousGeneralMerchandise
        | MiscellaneousGeneralServices
        | MiscellaneousHomeFurnishingSpecialtyStores
        | MiscellaneousPublishingAndPrinting
        | MiscellaneousRecreationServices
        | MiscellaneousRepairShops
        | MiscellaneousSpecialtyRetail
        | MobileHomeDealers
        | MotionPictureTheaters
        | MotorFreightCarriersAndTrucking
        | MotorHomesDealers
        | MotorVehicleSuppliesAndNewParts
        | MotorcycleShopsAndDealers
        | MotorcycleShopsDealers
        | MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | NewsDealersAndNewsstands
        | NonFiMoneyOrders
        | NonFiStoredValueCardPurchaseLoad
        | NondurableGoods
        | NurseriesLawnAndGardenSupplyStores
        | NursingPersonalCare
        | OfficeAndCommercialFurniture
        | OpticiansEyeglasses
        | OptometristsOphthalmologist
        | OrthopedicGoodsProstheticDevices
        | Osteopaths
        | PackageStoresBeerWineAndLiquor
        | PaintsVarnishesAndSupplies
        | ParkingLotsGarages
        | PassengerRailways
        | PawnShops
        | PetShopsPetFoodAndSupplies
        | PetroleumAndPetroleumProducts
        | PhotoDeveloping
        | PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | PhotographicStudios
        | PictureVideoProduction
        | PieceGoodsNotionsAndOtherDryGoods
        | PlumbingHeatingEquipmentAndSupplies
        | PoliticalOrganizations
        | PostalServicesGovernmentOnly
        | PreciousStonesAndMetalsWatchesAndJewelry
        | ProfessionalServices
        | PublicWarehousingAndStorage
        | QuickCopyReproAndBlueprint
        | Railroads
        | RealEstateAgentsAndManagersRentals
        | RecordStores
        | RecreationalVehicleRentals
        | ReligiousGoodsStores
        | ReligiousOrganizations
        | RoofingSidingSheetMetal
        | SecretarialSupportServices
        | SecurityBrokersDealers
        | ServiceStations
        | SewingNeedleworkFabricAndPieceGoodsStores
        | ShoeRepairHatCleaning
        | ShoeStores
        | SmallApplianceRepair
        | SnowmobileDealers
        | SpecialTradeServices
        | SpecialtyCleaning
        | SportingGoodsStores
        | SportingRecreationCamps
        | SportsAndRidingApparelStores
        | SportsClubsFields
        | StampAndCoinStores
        | StationaryOfficeSuppliesPrintingAndWritingPaper
        | StationeryStoresOfficeAndSchoolSupplyStores
        | SwimmingPoolsSales
        | TUiTravelGermany
        | TailorsAlterations
        | TaxPaymentsGovernmentAgencies
        | TaxPreparationServices
        | TaxicabsLimousines
        | TelecommunicationEquipmentAndTelephoneSales
        | TelecommunicationServices
        | TelegraphServices
        | TentAndAwningShops
        | TestingLaboratories
        | TheatricalTicketAgencies
        | Timeshares
        | TireRetreadingAndRepair
        | TollsBridgeFees
        | TouristAttractionsAndExhibits
        | TowingServices
        | TrailerParksCampgrounds
        | TransportationServices
        | TravelAgenciesTourOperators
        | TruckStopIteration
        | TruckUtilityTrailerRentals
        | TypesettingPlateMakingAndRelatedServices
        | TypewriterStores
        | USFederalGovernmentAgenciesOrDepartments
        | UniformsCommercialClothing
        | UsedMerchandiseAndSecondhandStores
        | Utilities
        | VarietyStores
        | VeterinaryServices
        | VideoAmusementGameSupplies
        | VideoGameArcades
        | VideoTapeRentalStores
        | VocationalTradeSchools
        | WatchJewelryRepair
        | WeldingRepair
        | WholesaleClubs
        | WigAndToupeeStores
        | WiresMoneyOrders
        | WomensAccessoryAndSpecialtyShops
        | WomensReadyToWearStores
        | WreckingAndSalvageYards

    type Create'SpendingControlsSpendingLimitsInterval =
        | AllTime
        | Daily
        | Monthly
        | PerAuthorization
        | Weekly
        | Yearly

    type Create'SpendingControlsSpendingLimits =
        {
            /// Maximum amount allowed to spend per interval.
            [<Config.Form>]
            Amount: int option
            /// Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) this limit applies to. Omitting this field will apply the limit to all categories.
            [<Config.Form>]
            Categories: Create'SpendingControlsSpendingLimitsCategories list option
            /// Interval (or event) to which the amount applies.
            [<Config.Form>]
            Interval: Create'SpendingControlsSpendingLimitsInterval option
        }

    type Create'SpendingControlsSpendingLimits with
        static member New(?amount: int, ?categories: Create'SpendingControlsSpendingLimitsCategories list, ?interval: Create'SpendingControlsSpendingLimitsInterval) =
            {
                Amount = amount
                Categories = categories
                Interval = interval
            }

    module Create'SpendingControlsSpendingLimits =
        let create
            (
                amount: int option,
                categories: Create'SpendingControlsSpendingLimitsCategories list option,
                interval: Create'SpendingControlsSpendingLimitsInterval option
            ) : Create'SpendingControlsSpendingLimits
            =
            {
              Amount = amount
              Categories = categories
              Interval = interval
            }

    type Create'SpendingControls =
        {
            /// Array of card presence statuses from which authorizations will be allowed. Possible options are `present`, `not_present`. All other statuses will be blocked. Cannot be set with `blocked_card_presences`. Provide an empty value to unset this control.
            [<Config.Form>]
            AllowedCardPresences: Create'SpendingControlsAllowedCardPresences list option
            /// Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) of authorizations to allow. All other categories will be blocked. Cannot be set with `blocked_categories`.
            [<Config.Form>]
            AllowedCategories: Create'SpendingControlsAllowedCategories list option
            /// Array of strings containing representing countries from which authorizations will be allowed. Authorizations from merchants in all other countries will be declined. Country codes should be ISO 3166 alpha-2 country codes (e.g. `US`). Cannot be set with `blocked_merchant_countries`. Provide an empty value to unset this control.
            [<Config.Form>]
            AllowedMerchantCountries: string list option
            /// Array of card presence statuses from which authorizations will be declined. Possible options are `present`, `not_present`. Cannot be set with `allowed_card_presences`. Provide an empty value to unset this control.
            [<Config.Form>]
            BlockedCardPresences: Create'SpendingControlsBlockedCardPresences list option
            /// Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) of authorizations to decline. All other categories will be allowed. Cannot be set with `allowed_categories`.
            [<Config.Form>]
            BlockedCategories: Create'SpendingControlsBlockedCategories list option
            /// Array of strings containing representing countries from which authorizations will be declined. Country codes should be ISO 3166 alpha-2 country codes (e.g. `US`). Cannot be set with `allowed_merchant_countries`. Provide an empty value to unset this control.
            [<Config.Form>]
            BlockedMerchantCountries: string list option
            /// Limit spending with amount-based rules that apply across any cards this card replaced (i.e., its `replacement_for` card and _that_ card's `replacement_for` card, up the chain).
            [<Config.Form>]
            SpendingLimits: Create'SpendingControlsSpendingLimits list option
        }

    type Create'SpendingControls with
        static member New(?allowedCardPresences: Create'SpendingControlsAllowedCardPresences list, ?allowedCategories: Create'SpendingControlsAllowedCategories list, ?allowedMerchantCountries: string list, ?blockedCardPresences: Create'SpendingControlsBlockedCardPresences list, ?blockedCategories: Create'SpendingControlsBlockedCategories list, ?blockedMerchantCountries: string list, ?spendingLimits: Create'SpendingControlsSpendingLimits list) =
            {
                AllowedCardPresences = allowedCardPresences
                AllowedCategories = allowedCategories
                AllowedMerchantCountries = allowedMerchantCountries
                BlockedCardPresences = blockedCardPresences
                BlockedCategories = blockedCategories
                BlockedMerchantCountries = blockedMerchantCountries
                SpendingLimits = spendingLimits
            }

    module Create'SpendingControls =
        let create
            (
                allowedCardPresences: Create'SpendingControlsAllowedCardPresences list option,
                allowedCategories: Create'SpendingControlsAllowedCategories list option,
                allowedMerchantCountries: string list option,
                blockedCardPresences: Create'SpendingControlsBlockedCardPresences list option,
                blockedCategories: Create'SpendingControlsBlockedCategories list option,
                blockedMerchantCountries: string list option,
                spendingLimits: Create'SpendingControlsSpendingLimits list option
            ) : Create'SpendingControls
            =
            {
              AllowedCardPresences = allowedCardPresences
              AllowedCategories = allowedCategories
              AllowedMerchantCountries = allowedMerchantCountries
              BlockedCardPresences = blockedCardPresences
              BlockedCategories = blockedCategories
              BlockedMerchantCountries = blockedMerchantCountries
              SpendingLimits = spendingLimits
            }

    type Create'Status =
        | Active
        | Inactive

    type Create'Type =
        | Physical
        | Virtual

    type CreateOptions =
        {
            /// The [Cardholder](https://docs.stripe.com/api#issuing_cardholder_object) object with which the card will be associated.
            [<Config.Form>]
            Cardholder: string option
            /// The currency for the card.
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode
            /// The desired expiration month (1-12) for this card if [specifying a custom expiration date](/issuing/cards/virtual/issue-cards?testing-method=with-code#exp-dates).
            [<Config.Form>]
            ExpMonth: int option
            /// The desired 4-digit expiration year for this card if [specifying a custom expiration date](/issuing/cards/virtual/issue-cards?testing-method=with-code#exp-dates).
            [<Config.Form>]
            ExpYear: int option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The new financial account ID the card will be associated with. This field allows a card to be reassigned to a different financial account.
            [<Config.Form>]
            FinancialAccount: string option
            /// Rules that control the lifecycle of this card, such as automatic cancellation. Refer to our [documentation](/issuing/controls/lifecycle-controls) for more details.
            [<Config.Form>]
            LifecycleControls: Create'LifecycleControls option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The personalization design object belonging to this card.
            [<Config.Form>]
            PersonalizationDesign: string option
            /// The desired PIN for this card.
            [<Config.Form>]
            Pin: Create'Pin option
            /// The card this is meant to be a replacement for (if any).
            [<Config.Form>]
            ReplacementFor: string option
            /// If `replacement_for` is specified, this should indicate why that card is being replaced.
            [<Config.Form>]
            ReplacementReason: Create'ReplacementReason option
            /// The second line to print on the card. Max length: 24 characters.
            [<Config.Form>]
            SecondLine: Choice<string,string> option
            /// The address where the card will be shipped.
            [<Config.Form>]
            Shipping: Create'Shipping option
            /// Rules that control spending for this card. Refer to our [documentation](https://docs.stripe.com/issuing/controls/spending-controls) for more details.
            [<Config.Form>]
            SpendingControls: Create'SpendingControls option
            /// Whether authorizations can be approved on this card. May be blocked from activating cards depending on past-due Cardholder requirements. Defaults to `inactive`.
            [<Config.Form>]
            Status: Create'Status option
            /// The type of card to issue. Possible values are `physical` or `virtual`.
            [<Config.Form>]
            Type: Create'Type
        }

    type CreateOptions with
        static member New(currency: IsoTypes.IsoCurrencyCode, type': Create'Type, ?cardholder: string, ?expMonth: int, ?expYear: int, ?expand: string list, ?financialAccount: string, ?lifecycleControls: Create'LifecycleControls, ?metadata: Map<string, string>, ?personalizationDesign: string, ?pin: Create'Pin, ?replacementFor: string, ?replacementReason: Create'ReplacementReason, ?secondLine: Choice<string,string>, ?shipping: Create'Shipping, ?spendingControls: Create'SpendingControls, ?status: Create'Status) =
            {
                Currency = currency
                Type = type'
                Cardholder = cardholder
                ExpMonth = expMonth
                ExpYear = expYear
                Expand = expand
                FinancialAccount = financialAccount
                LifecycleControls = lifecycleControls
                Metadata = metadata
                PersonalizationDesign = personalizationDesign
                Pin = pin
                ReplacementFor = replacementFor
                ReplacementReason = replacementReason
                SecondLine = secondLine
                Shipping = shipping
                SpendingControls = spendingControls
                Status = status
            }

    module CreateOptions =
        let create
            (
                currency: IsoTypes.IsoCurrencyCode,
                type': Create'Type
            ) : CreateOptions
            =
            {
              Currency = currency
              Type = type'
              Cardholder = None
              ExpMonth = None
              ExpYear = None
              Expand = None
              FinancialAccount = None
              LifecycleControls = None
              Metadata = None
              PersonalizationDesign = None
              Pin = None
              ReplacementFor = None
              ReplacementReason = None
              SecondLine = None
              Shipping = None
              SpendingControls = None
              Status = None
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Card: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    type RetrieveOptions with
        static member New(card: string, ?expand: string list) =
            {
                Card = card
                Expand = expand
            }

    module RetrieveOptions =
        let create
            (
                card: string
            ) : RetrieveOptions
            =
            {
              Card = card
              Expand = None
            }

    type Update'CancellationReason =
        | Lost
        | Stolen

    type Update'Pin =
        {
            /// The card's desired new PIN, encrypted under Stripe's public key.
            [<Config.Form>]
            EncryptedNumber: string option
        }

    type Update'Pin with
        static member New(?encryptedNumber: string) =
            {
                EncryptedNumber = encryptedNumber
            }

    module Update'Pin =
        let create
            (
                encryptedNumber: string option
            ) : Update'Pin
            =
            {
              EncryptedNumber = encryptedNumber
            }

    type Update'ShippingAddress =
        {
            /// City, district, suburb, town, or village.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Address line 1, such as the street, PO Box, or company name.
            [<Config.Form>]
            Line1: string option
            /// Address line 2, such as the apartment, suite, unit, or building.
            [<Config.Form>]
            Line2: string option
            /// ZIP or postal code.
            [<Config.Form>]
            PostalCode: string option
            /// State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
            [<Config.Form>]
            State: string option
        }

    type Update'ShippingAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    module Update'ShippingAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Update'ShippingAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Update'ShippingAddressValidationMode =
        | Disabled
        | NormalizationOnly
        | ValidationAndNormalization

    type Update'ShippingAddressValidation =
        {
            /// The address validation capabilities to use.
            [<Config.Form>]
            Mode: Update'ShippingAddressValidationMode option
        }

    type Update'ShippingAddressValidation with
        static member New(?mode: Update'ShippingAddressValidationMode) =
            {
                Mode = mode
            }

    module Update'ShippingAddressValidation =
        let create
            (
                mode: Update'ShippingAddressValidationMode option
            ) : Update'ShippingAddressValidation
            =
            {
              Mode = mode
            }

    type Update'ShippingCustoms =
        {
            /// The Economic Operators Registration and Identification (EORI) number to use for Customs. Required for bulk shipments to Europe.
            [<Config.Form>]
            EoriNumber: string option
        }

    type Update'ShippingCustoms with
        static member New(?eoriNumber: string) =
            {
                EoriNumber = eoriNumber
            }

    module Update'ShippingCustoms =
        let create
            (
                eoriNumber: string option
            ) : Update'ShippingCustoms
            =
            {
              EoriNumber = eoriNumber
            }

    type Update'ShippingService =
        | Express
        | Priority
        | Standard

    type Update'ShippingType =
        | Bulk
        | Individual

    type Update'Shipping =
        {
            /// The address that the card is shipped to.
            [<Config.Form>]
            Address: Update'ShippingAddress option
            /// Address validation settings.
            [<Config.Form>]
            AddressValidation: Update'ShippingAddressValidation option
            /// Customs information for the shipment.
            [<Config.Form>]
            Customs: Update'ShippingCustoms option
            /// The name printed on the shipping label when shipping the card.
            [<Config.Form>]
            Name: string option
            /// Phone number of the recipient of the shipment.
            [<Config.Form>]
            PhoneNumber: string option
            /// Whether a signature is required for card delivery.
            [<Config.Form>]
            RequireSignature: bool option
            /// Shipment service.
            [<Config.Form>]
            Service: Update'ShippingService option
            /// Packaging options.
            [<Config.Form>]
            Type: Update'ShippingType option
        }

    type Update'Shipping with
        static member New(?address: Update'ShippingAddress, ?addressValidation: Update'ShippingAddressValidation, ?customs: Update'ShippingCustoms, ?name: string, ?phoneNumber: string, ?requireSignature: bool, ?service: Update'ShippingService, ?type': Update'ShippingType) =
            {
                Address = address
                AddressValidation = addressValidation
                Customs = customs
                Name = name
                PhoneNumber = phoneNumber
                RequireSignature = requireSignature
                Service = service
                Type = type'
            }

    module Update'Shipping =
        let create
            (
                address: Update'ShippingAddress option,
                addressValidation: Update'ShippingAddressValidation option,
                customs: Update'ShippingCustoms option,
                name: string option,
                phoneNumber: string option,
                requireSignature: bool option,
                service: Update'ShippingService option,
                type': Update'ShippingType option
            ) : Update'Shipping
            =
            {
              Address = address
              AddressValidation = addressValidation
              Customs = customs
              Name = name
              PhoneNumber = phoneNumber
              RequireSignature = requireSignature
              Service = service
              Type = type'
            }

    type Update'SpendingControlsAllowedCardPresences =
        | NotPresent
        | Present

    type Update'SpendingControlsAllowedCategories =
        | AcRefrigerationRepair
        | AccountingBookkeepingServices
        | AdvertisingServices
        | AgriculturalCooperative
        | AirlinesAirCarriers
        | AirportsFlyingFields
        | AmbulanceServices
        | AmusementParksCarnivals
        | AntiqueReproductions
        | AntiqueShops
        | Aquariums
        | ArchitecturalSurveyingServices
        | ArtDealersAndGalleries
        | ArtistsSupplyAndCraftShops
        | AutoAndHomeSupplyStores
        | AutoBodyRepairShops
        | AutoPaintShops
        | AutoServiceShops
        | AutomatedCashDisburse
        | AutomatedFuelDispensers
        | AutomobileAssociations
        | AutomotivePartsAndAccessoriesStores
        | AutomotiveTireStores
        | BailAndBondPayments
        | Bakeries
        | BandsOrchestras
        | BarberAndBeautyShops
        | BettingCasinoGambling
        | BicycleShops
        | BilliardPoolEstablishments
        | BoatDealers
        | BoatRentalsAndLeases
        | BookStores
        | BooksPeriodicalsAndNewspapers
        | BowlingAlleys
        | BusLines
        | BusinessSecretarialSchools
        | BuyingShoppingServices
        | CableSatelliteAndOtherPayTelevisionAndRadio
        | CameraAndPhotographicSupplyStores
        | CandyNutAndConfectioneryStores
        | CarAndTruckDealersNewUsed
        | CarAndTruckDealersUsedOnly
        | CarRentalAgencies
        | CarWashes
        | CarpentryServices
        | CarpetUpholsteryCleaning
        | Caterers
        | CharitableAndSocialServiceOrganizationsFundraising
        | ChemicalsAndAlliedProducts
        | ChildCareServices
        | ChildrensAndInfantsWearStores
        | ChiropodistsPodiatrists
        | Chiropractors
        | CigarStoresAndStands
        | CivicSocialFraternalAssociations
        | CleaningAndMaintenance
        | ClothingRental
        | CollegesUniversities
        | CommercialEquipment
        | CommercialFootwear
        | CommercialPhotographyArtAndGraphics
        | CommuterTransportAndFerries
        | ComputerNetworkServices
        | ComputerProgramming
        | ComputerRepair
        | ComputerSoftwareStores
        | ComputersPeripheralsAndSoftware
        | ConcreteWorkServices
        | ConstructionMaterials
        | ConsultingPublicRelations
        | CorrespondenceSchools
        | CosmeticStores
        | CounselingServices
        | CountryClubs
        | CourierServices
        | CourtCosts
        | CreditReportingAgencies
        | CruiseLines
        | DairyProductsStores
        | DanceHallStudiosSchools
        | DatingEscortServices
        | DentistsOrthodontists
        | DepartmentStores
        | DetectiveAgencies
        | DigitalGoodsApplications
        | DigitalGoodsGames
        | DigitalGoodsLargeVolume
        | DigitalGoodsMedia
        | DirectMarketingCatalogMerchant
        | DirectMarketingCombinationCatalogAndRetailMerchant
        | DirectMarketingInboundTelemarketing
        | DirectMarketingInsuranceServices
        | DirectMarketingOther
        | DirectMarketingOutboundTelemarketing
        | DirectMarketingSubscription
        | DirectMarketingTravel
        | DiscountStores
        | Doctors
        | DoorToDoorSales
        | DraperyWindowCoveringAndUpholsteryStores
        | DrinkingPlaces
        | DrugStoresAndPharmacies
        | DrugsDrugProprietariesAndDruggistSundries
        | DryCleaners
        | DurableGoods
        | DutyFreeStores
        | EatingPlacesRestaurants
        | EducationalServices
        | ElectricRazorStores
        | ElectricVehicleCharging
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
        | EmergencyServicesGcasVisaUseOnly
        | EmploymentTempAgencies
        | EquipmentRental
        | ExterminatingServices
        | FamilyClothingStores
        | FastFoodRestaurants
        | FinancialInstitutions
        | FinesGovernmentAdministrativeEntities
        | FireplaceFireplaceScreensAndAccessoriesStores
        | FloorCoveringStores
        | Florists
        | FloristsSuppliesNurseryStockAndFlowers
        | FreezerAndLockerMeatProvisioners
        | FuelDealersNonAutomotive
        | FuneralServicesCrematories
        | FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | FurnitureRepairRefinishing
        | FurriersAndFurShops
        | GeneralServices
        | GiftCardNoveltyAndSouvenirShops
        | GlassPaintAndWallpaperStores
        | GlasswareCrystalStores
        | GolfCoursesPublic
        | GovernmentLicensedHorseDogRacingUsRegionOnly
        | GovernmentLicensedOnlineCasionsOnlineGamblingUsRegionOnly
        | GovernmentOwnedLotteriesNonUsRegion
        | GovernmentOwnedLotteriesUsRegionOnly
        | GovernmentServices
        | GroceryStoresSupermarkets
        | HardwareEquipmentAndSupplies
        | HardwareStores
        | HealthAndBeautySpas
        | HearingAidsSalesAndSupplies
        | HeatingPlumbingAC
        | HobbyToyAndGameShops
        | HomeSupplyWarehouseStores
        | Hospitals
        | HotelsMotelsAndResorts
        | HouseholdApplianceStores
        | IndustrialSupplies
        | InformationRetrievalServices
        | InsuranceDefault
        | InsuranceUnderwritingPremiums
        | IntraCompanyPurchases
        | JewelryStoresWatchesClocksAndSilverwareStores
        | LandscapingServices
        | Laundries
        | LaundryCleaningServices
        | LegalServicesAttorneys
        | LuggageAndLeatherGoodsStores
        | LumberBuildingMaterialsStores
        | ManualCashDisburse
        | MarinasServiceAndSupplies
        | Marketplaces
        | MasonryStoneworkAndPlaster
        | MassageParlors
        | MedicalAndDentalLabs
        | MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | MedicalServices
        | MembershipOrganizations
        | MensAndBoysClothingAndAccessoriesStores
        | MensWomensClothingStores
        | MetalServiceCenters
        | Miscellaneous
        | MiscellaneousApparelAndAccessoryShops
        | MiscellaneousAutoDealers
        | MiscellaneousBusinessServices
        | MiscellaneousFoodStores
        | MiscellaneousGeneralMerchandise
        | MiscellaneousGeneralServices
        | MiscellaneousHomeFurnishingSpecialtyStores
        | MiscellaneousPublishingAndPrinting
        | MiscellaneousRecreationServices
        | MiscellaneousRepairShops
        | MiscellaneousSpecialtyRetail
        | MobileHomeDealers
        | MotionPictureTheaters
        | MotorFreightCarriersAndTrucking
        | MotorHomesDealers
        | MotorVehicleSuppliesAndNewParts
        | MotorcycleShopsAndDealers
        | MotorcycleShopsDealers
        | MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | NewsDealersAndNewsstands
        | NonFiMoneyOrders
        | NonFiStoredValueCardPurchaseLoad
        | NondurableGoods
        | NurseriesLawnAndGardenSupplyStores
        | NursingPersonalCare
        | OfficeAndCommercialFurniture
        | OpticiansEyeglasses
        | OptometristsOphthalmologist
        | OrthopedicGoodsProstheticDevices
        | Osteopaths
        | PackageStoresBeerWineAndLiquor
        | PaintsVarnishesAndSupplies
        | ParkingLotsGarages
        | PassengerRailways
        | PawnShops
        | PetShopsPetFoodAndSupplies
        | PetroleumAndPetroleumProducts
        | PhotoDeveloping
        | PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | PhotographicStudios
        | PictureVideoProduction
        | PieceGoodsNotionsAndOtherDryGoods
        | PlumbingHeatingEquipmentAndSupplies
        | PoliticalOrganizations
        | PostalServicesGovernmentOnly
        | PreciousStonesAndMetalsWatchesAndJewelry
        | ProfessionalServices
        | PublicWarehousingAndStorage
        | QuickCopyReproAndBlueprint
        | Railroads
        | RealEstateAgentsAndManagersRentals
        | RecordStores
        | RecreationalVehicleRentals
        | ReligiousGoodsStores
        | ReligiousOrganizations
        | RoofingSidingSheetMetal
        | SecretarialSupportServices
        | SecurityBrokersDealers
        | ServiceStations
        | SewingNeedleworkFabricAndPieceGoodsStores
        | ShoeRepairHatCleaning
        | ShoeStores
        | SmallApplianceRepair
        | SnowmobileDealers
        | SpecialTradeServices
        | SpecialtyCleaning
        | SportingGoodsStores
        | SportingRecreationCamps
        | SportsAndRidingApparelStores
        | SportsClubsFields
        | StampAndCoinStores
        | StationaryOfficeSuppliesPrintingAndWritingPaper
        | StationeryStoresOfficeAndSchoolSupplyStores
        | SwimmingPoolsSales
        | TUiTravelGermany
        | TailorsAlterations
        | TaxPaymentsGovernmentAgencies
        | TaxPreparationServices
        | TaxicabsLimousines
        | TelecommunicationEquipmentAndTelephoneSales
        | TelecommunicationServices
        | TelegraphServices
        | TentAndAwningShops
        | TestingLaboratories
        | TheatricalTicketAgencies
        | Timeshares
        | TireRetreadingAndRepair
        | TollsBridgeFees
        | TouristAttractionsAndExhibits
        | TowingServices
        | TrailerParksCampgrounds
        | TransportationServices
        | TravelAgenciesTourOperators
        | TruckStopIteration
        | TruckUtilityTrailerRentals
        | TypesettingPlateMakingAndRelatedServices
        | TypewriterStores
        | USFederalGovernmentAgenciesOrDepartments
        | UniformsCommercialClothing
        | UsedMerchandiseAndSecondhandStores
        | Utilities
        | VarietyStores
        | VeterinaryServices
        | VideoAmusementGameSupplies
        | VideoGameArcades
        | VideoTapeRentalStores
        | VocationalTradeSchools
        | WatchJewelryRepair
        | WeldingRepair
        | WholesaleClubs
        | WigAndToupeeStores
        | WiresMoneyOrders
        | WomensAccessoryAndSpecialtyShops
        | WomensReadyToWearStores
        | WreckingAndSalvageYards

    type Update'SpendingControlsBlockedCardPresences =
        | NotPresent
        | Present

    type Update'SpendingControlsBlockedCategories =
        | AcRefrigerationRepair
        | AccountingBookkeepingServices
        | AdvertisingServices
        | AgriculturalCooperative
        | AirlinesAirCarriers
        | AirportsFlyingFields
        | AmbulanceServices
        | AmusementParksCarnivals
        | AntiqueReproductions
        | AntiqueShops
        | Aquariums
        | ArchitecturalSurveyingServices
        | ArtDealersAndGalleries
        | ArtistsSupplyAndCraftShops
        | AutoAndHomeSupplyStores
        | AutoBodyRepairShops
        | AutoPaintShops
        | AutoServiceShops
        | AutomatedCashDisburse
        | AutomatedFuelDispensers
        | AutomobileAssociations
        | AutomotivePartsAndAccessoriesStores
        | AutomotiveTireStores
        | BailAndBondPayments
        | Bakeries
        | BandsOrchestras
        | BarberAndBeautyShops
        | BettingCasinoGambling
        | BicycleShops
        | BilliardPoolEstablishments
        | BoatDealers
        | BoatRentalsAndLeases
        | BookStores
        | BooksPeriodicalsAndNewspapers
        | BowlingAlleys
        | BusLines
        | BusinessSecretarialSchools
        | BuyingShoppingServices
        | CableSatelliteAndOtherPayTelevisionAndRadio
        | CameraAndPhotographicSupplyStores
        | CandyNutAndConfectioneryStores
        | CarAndTruckDealersNewUsed
        | CarAndTruckDealersUsedOnly
        | CarRentalAgencies
        | CarWashes
        | CarpentryServices
        | CarpetUpholsteryCleaning
        | Caterers
        | CharitableAndSocialServiceOrganizationsFundraising
        | ChemicalsAndAlliedProducts
        | ChildCareServices
        | ChildrensAndInfantsWearStores
        | ChiropodistsPodiatrists
        | Chiropractors
        | CigarStoresAndStands
        | CivicSocialFraternalAssociations
        | CleaningAndMaintenance
        | ClothingRental
        | CollegesUniversities
        | CommercialEquipment
        | CommercialFootwear
        | CommercialPhotographyArtAndGraphics
        | CommuterTransportAndFerries
        | ComputerNetworkServices
        | ComputerProgramming
        | ComputerRepair
        | ComputerSoftwareStores
        | ComputersPeripheralsAndSoftware
        | ConcreteWorkServices
        | ConstructionMaterials
        | ConsultingPublicRelations
        | CorrespondenceSchools
        | CosmeticStores
        | CounselingServices
        | CountryClubs
        | CourierServices
        | CourtCosts
        | CreditReportingAgencies
        | CruiseLines
        | DairyProductsStores
        | DanceHallStudiosSchools
        | DatingEscortServices
        | DentistsOrthodontists
        | DepartmentStores
        | DetectiveAgencies
        | DigitalGoodsApplications
        | DigitalGoodsGames
        | DigitalGoodsLargeVolume
        | DigitalGoodsMedia
        | DirectMarketingCatalogMerchant
        | DirectMarketingCombinationCatalogAndRetailMerchant
        | DirectMarketingInboundTelemarketing
        | DirectMarketingInsuranceServices
        | DirectMarketingOther
        | DirectMarketingOutboundTelemarketing
        | DirectMarketingSubscription
        | DirectMarketingTravel
        | DiscountStores
        | Doctors
        | DoorToDoorSales
        | DraperyWindowCoveringAndUpholsteryStores
        | DrinkingPlaces
        | DrugStoresAndPharmacies
        | DrugsDrugProprietariesAndDruggistSundries
        | DryCleaners
        | DurableGoods
        | DutyFreeStores
        | EatingPlacesRestaurants
        | EducationalServices
        | ElectricRazorStores
        | ElectricVehicleCharging
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
        | EmergencyServicesGcasVisaUseOnly
        | EmploymentTempAgencies
        | EquipmentRental
        | ExterminatingServices
        | FamilyClothingStores
        | FastFoodRestaurants
        | FinancialInstitutions
        | FinesGovernmentAdministrativeEntities
        | FireplaceFireplaceScreensAndAccessoriesStores
        | FloorCoveringStores
        | Florists
        | FloristsSuppliesNurseryStockAndFlowers
        | FreezerAndLockerMeatProvisioners
        | FuelDealersNonAutomotive
        | FuneralServicesCrematories
        | FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | FurnitureRepairRefinishing
        | FurriersAndFurShops
        | GeneralServices
        | GiftCardNoveltyAndSouvenirShops
        | GlassPaintAndWallpaperStores
        | GlasswareCrystalStores
        | GolfCoursesPublic
        | GovernmentLicensedHorseDogRacingUsRegionOnly
        | GovernmentLicensedOnlineCasionsOnlineGamblingUsRegionOnly
        | GovernmentOwnedLotteriesNonUsRegion
        | GovernmentOwnedLotteriesUsRegionOnly
        | GovernmentServices
        | GroceryStoresSupermarkets
        | HardwareEquipmentAndSupplies
        | HardwareStores
        | HealthAndBeautySpas
        | HearingAidsSalesAndSupplies
        | HeatingPlumbingAC
        | HobbyToyAndGameShops
        | HomeSupplyWarehouseStores
        | Hospitals
        | HotelsMotelsAndResorts
        | HouseholdApplianceStores
        | IndustrialSupplies
        | InformationRetrievalServices
        | InsuranceDefault
        | InsuranceUnderwritingPremiums
        | IntraCompanyPurchases
        | JewelryStoresWatchesClocksAndSilverwareStores
        | LandscapingServices
        | Laundries
        | LaundryCleaningServices
        | LegalServicesAttorneys
        | LuggageAndLeatherGoodsStores
        | LumberBuildingMaterialsStores
        | ManualCashDisburse
        | MarinasServiceAndSupplies
        | Marketplaces
        | MasonryStoneworkAndPlaster
        | MassageParlors
        | MedicalAndDentalLabs
        | MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | MedicalServices
        | MembershipOrganizations
        | MensAndBoysClothingAndAccessoriesStores
        | MensWomensClothingStores
        | MetalServiceCenters
        | Miscellaneous
        | MiscellaneousApparelAndAccessoryShops
        | MiscellaneousAutoDealers
        | MiscellaneousBusinessServices
        | MiscellaneousFoodStores
        | MiscellaneousGeneralMerchandise
        | MiscellaneousGeneralServices
        | MiscellaneousHomeFurnishingSpecialtyStores
        | MiscellaneousPublishingAndPrinting
        | MiscellaneousRecreationServices
        | MiscellaneousRepairShops
        | MiscellaneousSpecialtyRetail
        | MobileHomeDealers
        | MotionPictureTheaters
        | MotorFreightCarriersAndTrucking
        | MotorHomesDealers
        | MotorVehicleSuppliesAndNewParts
        | MotorcycleShopsAndDealers
        | MotorcycleShopsDealers
        | MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | NewsDealersAndNewsstands
        | NonFiMoneyOrders
        | NonFiStoredValueCardPurchaseLoad
        | NondurableGoods
        | NurseriesLawnAndGardenSupplyStores
        | NursingPersonalCare
        | OfficeAndCommercialFurniture
        | OpticiansEyeglasses
        | OptometristsOphthalmologist
        | OrthopedicGoodsProstheticDevices
        | Osteopaths
        | PackageStoresBeerWineAndLiquor
        | PaintsVarnishesAndSupplies
        | ParkingLotsGarages
        | PassengerRailways
        | PawnShops
        | PetShopsPetFoodAndSupplies
        | PetroleumAndPetroleumProducts
        | PhotoDeveloping
        | PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | PhotographicStudios
        | PictureVideoProduction
        | PieceGoodsNotionsAndOtherDryGoods
        | PlumbingHeatingEquipmentAndSupplies
        | PoliticalOrganizations
        | PostalServicesGovernmentOnly
        | PreciousStonesAndMetalsWatchesAndJewelry
        | ProfessionalServices
        | PublicWarehousingAndStorage
        | QuickCopyReproAndBlueprint
        | Railroads
        | RealEstateAgentsAndManagersRentals
        | RecordStores
        | RecreationalVehicleRentals
        | ReligiousGoodsStores
        | ReligiousOrganizations
        | RoofingSidingSheetMetal
        | SecretarialSupportServices
        | SecurityBrokersDealers
        | ServiceStations
        | SewingNeedleworkFabricAndPieceGoodsStores
        | ShoeRepairHatCleaning
        | ShoeStores
        | SmallApplianceRepair
        | SnowmobileDealers
        | SpecialTradeServices
        | SpecialtyCleaning
        | SportingGoodsStores
        | SportingRecreationCamps
        | SportsAndRidingApparelStores
        | SportsClubsFields
        | StampAndCoinStores
        | StationaryOfficeSuppliesPrintingAndWritingPaper
        | StationeryStoresOfficeAndSchoolSupplyStores
        | SwimmingPoolsSales
        | TUiTravelGermany
        | TailorsAlterations
        | TaxPaymentsGovernmentAgencies
        | TaxPreparationServices
        | TaxicabsLimousines
        | TelecommunicationEquipmentAndTelephoneSales
        | TelecommunicationServices
        | TelegraphServices
        | TentAndAwningShops
        | TestingLaboratories
        | TheatricalTicketAgencies
        | Timeshares
        | TireRetreadingAndRepair
        | TollsBridgeFees
        | TouristAttractionsAndExhibits
        | TowingServices
        | TrailerParksCampgrounds
        | TransportationServices
        | TravelAgenciesTourOperators
        | TruckStopIteration
        | TruckUtilityTrailerRentals
        | TypesettingPlateMakingAndRelatedServices
        | TypewriterStores
        | USFederalGovernmentAgenciesOrDepartments
        | UniformsCommercialClothing
        | UsedMerchandiseAndSecondhandStores
        | Utilities
        | VarietyStores
        | VeterinaryServices
        | VideoAmusementGameSupplies
        | VideoGameArcades
        | VideoTapeRentalStores
        | VocationalTradeSchools
        | WatchJewelryRepair
        | WeldingRepair
        | WholesaleClubs
        | WigAndToupeeStores
        | WiresMoneyOrders
        | WomensAccessoryAndSpecialtyShops
        | WomensReadyToWearStores
        | WreckingAndSalvageYards

    type Update'SpendingControlsSpendingLimitsCategories =
        | AcRefrigerationRepair
        | AccountingBookkeepingServices
        | AdvertisingServices
        | AgriculturalCooperative
        | AirlinesAirCarriers
        | AirportsFlyingFields
        | AmbulanceServices
        | AmusementParksCarnivals
        | AntiqueReproductions
        | AntiqueShops
        | Aquariums
        | ArchitecturalSurveyingServices
        | ArtDealersAndGalleries
        | ArtistsSupplyAndCraftShops
        | AutoAndHomeSupplyStores
        | AutoBodyRepairShops
        | AutoPaintShops
        | AutoServiceShops
        | AutomatedCashDisburse
        | AutomatedFuelDispensers
        | AutomobileAssociations
        | AutomotivePartsAndAccessoriesStores
        | AutomotiveTireStores
        | BailAndBondPayments
        | Bakeries
        | BandsOrchestras
        | BarberAndBeautyShops
        | BettingCasinoGambling
        | BicycleShops
        | BilliardPoolEstablishments
        | BoatDealers
        | BoatRentalsAndLeases
        | BookStores
        | BooksPeriodicalsAndNewspapers
        | BowlingAlleys
        | BusLines
        | BusinessSecretarialSchools
        | BuyingShoppingServices
        | CableSatelliteAndOtherPayTelevisionAndRadio
        | CameraAndPhotographicSupplyStores
        | CandyNutAndConfectioneryStores
        | CarAndTruckDealersNewUsed
        | CarAndTruckDealersUsedOnly
        | CarRentalAgencies
        | CarWashes
        | CarpentryServices
        | CarpetUpholsteryCleaning
        | Caterers
        | CharitableAndSocialServiceOrganizationsFundraising
        | ChemicalsAndAlliedProducts
        | ChildCareServices
        | ChildrensAndInfantsWearStores
        | ChiropodistsPodiatrists
        | Chiropractors
        | CigarStoresAndStands
        | CivicSocialFraternalAssociations
        | CleaningAndMaintenance
        | ClothingRental
        | CollegesUniversities
        | CommercialEquipment
        | CommercialFootwear
        | CommercialPhotographyArtAndGraphics
        | CommuterTransportAndFerries
        | ComputerNetworkServices
        | ComputerProgramming
        | ComputerRepair
        | ComputerSoftwareStores
        | ComputersPeripheralsAndSoftware
        | ConcreteWorkServices
        | ConstructionMaterials
        | ConsultingPublicRelations
        | CorrespondenceSchools
        | CosmeticStores
        | CounselingServices
        | CountryClubs
        | CourierServices
        | CourtCosts
        | CreditReportingAgencies
        | CruiseLines
        | DairyProductsStores
        | DanceHallStudiosSchools
        | DatingEscortServices
        | DentistsOrthodontists
        | DepartmentStores
        | DetectiveAgencies
        | DigitalGoodsApplications
        | DigitalGoodsGames
        | DigitalGoodsLargeVolume
        | DigitalGoodsMedia
        | DirectMarketingCatalogMerchant
        | DirectMarketingCombinationCatalogAndRetailMerchant
        | DirectMarketingInboundTelemarketing
        | DirectMarketingInsuranceServices
        | DirectMarketingOther
        | DirectMarketingOutboundTelemarketing
        | DirectMarketingSubscription
        | DirectMarketingTravel
        | DiscountStores
        | Doctors
        | DoorToDoorSales
        | DraperyWindowCoveringAndUpholsteryStores
        | DrinkingPlaces
        | DrugStoresAndPharmacies
        | DrugsDrugProprietariesAndDruggistSundries
        | DryCleaners
        | DurableGoods
        | DutyFreeStores
        | EatingPlacesRestaurants
        | EducationalServices
        | ElectricRazorStores
        | ElectricVehicleCharging
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
        | EmergencyServicesGcasVisaUseOnly
        | EmploymentTempAgencies
        | EquipmentRental
        | ExterminatingServices
        | FamilyClothingStores
        | FastFoodRestaurants
        | FinancialInstitutions
        | FinesGovernmentAdministrativeEntities
        | FireplaceFireplaceScreensAndAccessoriesStores
        | FloorCoveringStores
        | Florists
        | FloristsSuppliesNurseryStockAndFlowers
        | FreezerAndLockerMeatProvisioners
        | FuelDealersNonAutomotive
        | FuneralServicesCrematories
        | FurnitureHomeFurnishingsAndEquipmentStoresExceptAppliances
        | FurnitureRepairRefinishing
        | FurriersAndFurShops
        | GeneralServices
        | GiftCardNoveltyAndSouvenirShops
        | GlassPaintAndWallpaperStores
        | GlasswareCrystalStores
        | GolfCoursesPublic
        | GovernmentLicensedHorseDogRacingUsRegionOnly
        | GovernmentLicensedOnlineCasionsOnlineGamblingUsRegionOnly
        | GovernmentOwnedLotteriesNonUsRegion
        | GovernmentOwnedLotteriesUsRegionOnly
        | GovernmentServices
        | GroceryStoresSupermarkets
        | HardwareEquipmentAndSupplies
        | HardwareStores
        | HealthAndBeautySpas
        | HearingAidsSalesAndSupplies
        | HeatingPlumbingAC
        | HobbyToyAndGameShops
        | HomeSupplyWarehouseStores
        | Hospitals
        | HotelsMotelsAndResorts
        | HouseholdApplianceStores
        | IndustrialSupplies
        | InformationRetrievalServices
        | InsuranceDefault
        | InsuranceUnderwritingPremiums
        | IntraCompanyPurchases
        | JewelryStoresWatchesClocksAndSilverwareStores
        | LandscapingServices
        | Laundries
        | LaundryCleaningServices
        | LegalServicesAttorneys
        | LuggageAndLeatherGoodsStores
        | LumberBuildingMaterialsStores
        | ManualCashDisburse
        | MarinasServiceAndSupplies
        | Marketplaces
        | MasonryStoneworkAndPlaster
        | MassageParlors
        | MedicalAndDentalLabs
        | MedicalDentalOphthalmicAndHospitalEquipmentAndSupplies
        | MedicalServices
        | MembershipOrganizations
        | MensAndBoysClothingAndAccessoriesStores
        | MensWomensClothingStores
        | MetalServiceCenters
        | Miscellaneous
        | MiscellaneousApparelAndAccessoryShops
        | MiscellaneousAutoDealers
        | MiscellaneousBusinessServices
        | MiscellaneousFoodStores
        | MiscellaneousGeneralMerchandise
        | MiscellaneousGeneralServices
        | MiscellaneousHomeFurnishingSpecialtyStores
        | MiscellaneousPublishingAndPrinting
        | MiscellaneousRecreationServices
        | MiscellaneousRepairShops
        | MiscellaneousSpecialtyRetail
        | MobileHomeDealers
        | MotionPictureTheaters
        | MotorFreightCarriersAndTrucking
        | MotorHomesDealers
        | MotorVehicleSuppliesAndNewParts
        | MotorcycleShopsAndDealers
        | MotorcycleShopsDealers
        | MusicStoresMusicalInstrumentsPianosAndSheetMusic
        | NewsDealersAndNewsstands
        | NonFiMoneyOrders
        | NonFiStoredValueCardPurchaseLoad
        | NondurableGoods
        | NurseriesLawnAndGardenSupplyStores
        | NursingPersonalCare
        | OfficeAndCommercialFurniture
        | OpticiansEyeglasses
        | OptometristsOphthalmologist
        | OrthopedicGoodsProstheticDevices
        | Osteopaths
        | PackageStoresBeerWineAndLiquor
        | PaintsVarnishesAndSupplies
        | ParkingLotsGarages
        | PassengerRailways
        | PawnShops
        | PetShopsPetFoodAndSupplies
        | PetroleumAndPetroleumProducts
        | PhotoDeveloping
        | PhotographicPhotocopyMicrofilmEquipmentAndSupplies
        | PhotographicStudios
        | PictureVideoProduction
        | PieceGoodsNotionsAndOtherDryGoods
        | PlumbingHeatingEquipmentAndSupplies
        | PoliticalOrganizations
        | PostalServicesGovernmentOnly
        | PreciousStonesAndMetalsWatchesAndJewelry
        | ProfessionalServices
        | PublicWarehousingAndStorage
        | QuickCopyReproAndBlueprint
        | Railroads
        | RealEstateAgentsAndManagersRentals
        | RecordStores
        | RecreationalVehicleRentals
        | ReligiousGoodsStores
        | ReligiousOrganizations
        | RoofingSidingSheetMetal
        | SecretarialSupportServices
        | SecurityBrokersDealers
        | ServiceStations
        | SewingNeedleworkFabricAndPieceGoodsStores
        | ShoeRepairHatCleaning
        | ShoeStores
        | SmallApplianceRepair
        | SnowmobileDealers
        | SpecialTradeServices
        | SpecialtyCleaning
        | SportingGoodsStores
        | SportingRecreationCamps
        | SportsAndRidingApparelStores
        | SportsClubsFields
        | StampAndCoinStores
        | StationaryOfficeSuppliesPrintingAndWritingPaper
        | StationeryStoresOfficeAndSchoolSupplyStores
        | SwimmingPoolsSales
        | TUiTravelGermany
        | TailorsAlterations
        | TaxPaymentsGovernmentAgencies
        | TaxPreparationServices
        | TaxicabsLimousines
        | TelecommunicationEquipmentAndTelephoneSales
        | TelecommunicationServices
        | TelegraphServices
        | TentAndAwningShops
        | TestingLaboratories
        | TheatricalTicketAgencies
        | Timeshares
        | TireRetreadingAndRepair
        | TollsBridgeFees
        | TouristAttractionsAndExhibits
        | TowingServices
        | TrailerParksCampgrounds
        | TransportationServices
        | TravelAgenciesTourOperators
        | TruckStopIteration
        | TruckUtilityTrailerRentals
        | TypesettingPlateMakingAndRelatedServices
        | TypewriterStores
        | USFederalGovernmentAgenciesOrDepartments
        | UniformsCommercialClothing
        | UsedMerchandiseAndSecondhandStores
        | Utilities
        | VarietyStores
        | VeterinaryServices
        | VideoAmusementGameSupplies
        | VideoGameArcades
        | VideoTapeRentalStores
        | VocationalTradeSchools
        | WatchJewelryRepair
        | WeldingRepair
        | WholesaleClubs
        | WigAndToupeeStores
        | WiresMoneyOrders
        | WomensAccessoryAndSpecialtyShops
        | WomensReadyToWearStores
        | WreckingAndSalvageYards

    type Update'SpendingControlsSpendingLimitsInterval =
        | AllTime
        | Daily
        | Monthly
        | PerAuthorization
        | Weekly
        | Yearly

    type Update'SpendingControlsSpendingLimits =
        {
            /// Maximum amount allowed to spend per interval.
            [<Config.Form>]
            Amount: int option
            /// Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) this limit applies to. Omitting this field will apply the limit to all categories.
            [<Config.Form>]
            Categories: Update'SpendingControlsSpendingLimitsCategories list option
            /// Interval (or event) to which the amount applies.
            [<Config.Form>]
            Interval: Update'SpendingControlsSpendingLimitsInterval option
        }

    type Update'SpendingControlsSpendingLimits with
        static member New(?amount: int, ?categories: Update'SpendingControlsSpendingLimitsCategories list, ?interval: Update'SpendingControlsSpendingLimitsInterval) =
            {
                Amount = amount
                Categories = categories
                Interval = interval
            }

    module Update'SpendingControlsSpendingLimits =
        let create
            (
                amount: int option,
                categories: Update'SpendingControlsSpendingLimitsCategories list option,
                interval: Update'SpendingControlsSpendingLimitsInterval option
            ) : Update'SpendingControlsSpendingLimits
            =
            {
              Amount = amount
              Categories = categories
              Interval = interval
            }

    type Update'SpendingControls =
        {
            /// Array of card presence statuses from which authorizations will be allowed. Possible options are `present`, `not_present`. All other statuses will be blocked. Cannot be set with `blocked_card_presences`. Provide an empty value to unset this control.
            [<Config.Form>]
            AllowedCardPresences: Update'SpendingControlsAllowedCardPresences list option
            /// Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) of authorizations to allow. All other categories will be blocked. Cannot be set with `blocked_categories`.
            [<Config.Form>]
            AllowedCategories: Update'SpendingControlsAllowedCategories list option
            /// Array of strings containing representing countries from which authorizations will be allowed. Authorizations from merchants in all other countries will be declined. Country codes should be ISO 3166 alpha-2 country codes (e.g. `US`). Cannot be set with `blocked_merchant_countries`. Provide an empty value to unset this control.
            [<Config.Form>]
            AllowedMerchantCountries: string list option
            /// Array of card presence statuses from which authorizations will be declined. Possible options are `present`, `not_present`. Cannot be set with `allowed_card_presences`. Provide an empty value to unset this control.
            [<Config.Form>]
            BlockedCardPresences: Update'SpendingControlsBlockedCardPresences list option
            /// Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) of authorizations to decline. All other categories will be allowed. Cannot be set with `allowed_categories`.
            [<Config.Form>]
            BlockedCategories: Update'SpendingControlsBlockedCategories list option
            /// Array of strings containing representing countries from which authorizations will be declined. Country codes should be ISO 3166 alpha-2 country codes (e.g. `US`). Cannot be set with `allowed_merchant_countries`. Provide an empty value to unset this control.
            [<Config.Form>]
            BlockedMerchantCountries: string list option
            /// Limit spending with amount-based rules that apply across any cards this card replaced (i.e., its `replacement_for` card and _that_ card's `replacement_for` card, up the chain).
            [<Config.Form>]
            SpendingLimits: Update'SpendingControlsSpendingLimits list option
        }

    type Update'SpendingControls with
        static member New(?allowedCardPresences: Update'SpendingControlsAllowedCardPresences list, ?allowedCategories: Update'SpendingControlsAllowedCategories list, ?allowedMerchantCountries: string list, ?blockedCardPresences: Update'SpendingControlsBlockedCardPresences list, ?blockedCategories: Update'SpendingControlsBlockedCategories list, ?blockedMerchantCountries: string list, ?spendingLimits: Update'SpendingControlsSpendingLimits list) =
            {
                AllowedCardPresences = allowedCardPresences
                AllowedCategories = allowedCategories
                AllowedMerchantCountries = allowedMerchantCountries
                BlockedCardPresences = blockedCardPresences
                BlockedCategories = blockedCategories
                BlockedMerchantCountries = blockedMerchantCountries
                SpendingLimits = spendingLimits
            }

    module Update'SpendingControls =
        let create
            (
                allowedCardPresences: Update'SpendingControlsAllowedCardPresences list option,
                allowedCategories: Update'SpendingControlsAllowedCategories list option,
                allowedMerchantCountries: string list option,
                blockedCardPresences: Update'SpendingControlsBlockedCardPresences list option,
                blockedCategories: Update'SpendingControlsBlockedCategories list option,
                blockedMerchantCountries: string list option,
                spendingLimits: Update'SpendingControlsSpendingLimits list option
            ) : Update'SpendingControls
            =
            {
              AllowedCardPresences = allowedCardPresences
              AllowedCategories = allowedCategories
              AllowedMerchantCountries = allowedMerchantCountries
              BlockedCardPresences = blockedCardPresences
              BlockedCategories = blockedCategories
              BlockedMerchantCountries = blockedMerchantCountries
              SpendingLimits = spendingLimits
            }

    type Update'Status =
        | Active
        | Canceled
        | Inactive

    type UpdateOptions =
        {
            [<Config.Path>]
            Card: string
            /// Reason why the `status` of this card is `canceled`.
            [<Config.Form>]
            CancellationReason: Update'CancellationReason option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            [<Config.Form>]
            PersonalizationDesign: string option
            /// The desired new PIN for this card.
            [<Config.Form>]
            Pin: Update'Pin option
            /// Updated shipping information for the card.
            [<Config.Form>]
            Shipping: Update'Shipping option
            /// Rules that control spending for this card. Refer to our [documentation](https://docs.stripe.com/issuing/controls/spending-controls) for more details.
            [<Config.Form>]
            SpendingControls: Update'SpendingControls option
            /// Dictates whether authorizations can be approved on this card. May be blocked from activating cards depending on past-due Cardholder requirements. Defaults to `inactive`. If this card is being canceled because it was lost or stolen, this information should be provided as `cancellation_reason`.
            [<Config.Form>]
            Status: Update'Status option
        }

    type UpdateOptions with
        static member New(card: string, ?cancellationReason: Update'CancellationReason, ?expand: string list, ?metadata: Map<string, string>, ?personalizationDesign: string, ?pin: Update'Pin, ?shipping: Update'Shipping, ?spendingControls: Update'SpendingControls, ?status: Update'Status) =
            {
                Card = card
                CancellationReason = cancellationReason
                Expand = expand
                Metadata = metadata
                PersonalizationDesign = personalizationDesign
                Pin = pin
                Shipping = shipping
                SpendingControls = spendingControls
                Status = status
            }

    module UpdateOptions =
        let create
            (
                card: string
            ) : UpdateOptions
            =
            {
              Card = card
              CancellationReason = None
              Expand = None
              Metadata = None
              PersonalizationDesign = None
              Pin = None
              Shipping = None
              SpendingControls = None
              Status = None
            }

    ///<p>Returns a list of Issuing <code>Card</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("cardholder", options.Cardholder |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("exp_month", options.ExpMonth |> box); ("exp_year", options.ExpYear |> box); ("expand", options.Expand |> box); ("last4", options.Last4 |> box); ("limit", options.Limit |> box); ("personalization_design", options.PersonalizationDesign |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("type", options.Type |> box)] |> Map.ofList
        $"/v1/issuing/cards"
        |> RestApi.getAsync<StripeList<IssuingCard>> settings qs

    ///<p>Creates an Issuing <code>Card</code> object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/issuing/cards"
        |> RestApi.postAsync<_, IssuingCard> settings (Map.empty) options

    ///<p>Retrieves an Issuing <code>Card</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/issuing/cards/{options.Card}"
        |> RestApi.getAsync<IssuingCard> settings qs

    ///<p>Updates the specified Issuing <code>Card</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/issuing/cards/{options.Card}"
        |> RestApi.postAsync<_, IssuingCard> settings (Map.empty) options

module IssuingDisputes =

    type ListOptions =
        {
            /// Only return Issuing disputes that were created during the given date interval.
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
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Select Issuing disputes with the given status.
            [<Config.Query>]
            Status: string option
            /// Select the Issuing dispute for the given transaction.
            [<Config.Query>]
            Transaction: string option
        }

    type ListOptions with
        static member New(?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string, ?transaction: string) =
            {
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Status = status
                Transaction = transaction
            }

    module ListOptions =
        let create
            (
                created: int option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option,
                status: string option,
                transaction: string option
            ) : ListOptions
            =
            {
              Created = created
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
              Status = status
              Transaction = transaction
            }

    type Create'EvidenceCanceledCanceledProductType =
        | Merchandise
        | Service

    type Create'EvidenceCanceledCanceledReturnStatus =
        | MerchantRejected
        | Successful

    type Create'EvidenceCanceledCanceled =
        {
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
            [<Config.Form>]
            AdditionalDocumentation: Choice<string,string> option
            /// Date when order was canceled.
            [<Config.Form>]
            CanceledAt: Choice<DateTime,string> option
            /// Whether the cardholder was provided with a cancellation policy.
            [<Config.Form>]
            CancellationPolicyProvided: Choice<bool,string> option
            /// Reason for canceling the order.
            [<Config.Form>]
            CancellationReason: Choice<string,string> option
            /// Date when the cardholder expected to receive the product.
            [<Config.Form>]
            ExpectedAt: Choice<DateTime,string> option
            /// Explanation of why the cardholder is disputing this transaction.
            [<Config.Form>]
            Explanation: Choice<string,string> option
            /// Description of the merchandise or service that was purchased.
            [<Config.Form>]
            ProductDescription: Choice<string,string> option
            /// Whether the product was a merchandise or service.
            [<Config.Form>]
            ProductType: Create'EvidenceCanceledCanceledProductType option
            /// Result of cardholder's attempt to return the product.
            [<Config.Form>]
            ReturnStatus: Create'EvidenceCanceledCanceledReturnStatus option
            /// Date when the product was returned or attempted to be returned.
            [<Config.Form>]
            ReturnedAt: Choice<DateTime,string> option
        }

    type Create'EvidenceCanceledCanceled with
        static member New(?additionalDocumentation: Choice<string,string>, ?canceledAt: Choice<DateTime,string>, ?cancellationPolicyProvided: Choice<bool,string>, ?cancellationReason: Choice<string,string>, ?expectedAt: Choice<DateTime,string>, ?explanation: Choice<string,string>, ?productDescription: Choice<string,string>, ?productType: Create'EvidenceCanceledCanceledProductType, ?returnStatus: Create'EvidenceCanceledCanceledReturnStatus, ?returnedAt: Choice<DateTime,string>) =
            {
                AdditionalDocumentation = additionalDocumentation
                CanceledAt = canceledAt
                CancellationPolicyProvided = cancellationPolicyProvided
                CancellationReason = cancellationReason
                ExpectedAt = expectedAt
                Explanation = explanation
                ProductDescription = productDescription
                ProductType = productType
                ReturnStatus = returnStatus
                ReturnedAt = returnedAt
            }

    module Create'EvidenceCanceledCanceled =
        let create
            (
                additionalDocumentation: Choice<string,string> option,
                canceledAt: Choice<DateTime,string> option,
                cancellationPolicyProvided: Choice<bool,string> option,
                cancellationReason: Choice<string,string> option,
                expectedAt: Choice<DateTime,string> option,
                explanation: Choice<string,string> option,
                productDescription: Choice<string,string> option,
                productType: Create'EvidenceCanceledCanceledProductType option,
                returnStatus: Create'EvidenceCanceledCanceledReturnStatus option,
                returnedAt: Choice<DateTime,string> option
            ) : Create'EvidenceCanceledCanceled
            =
            {
              AdditionalDocumentation = additionalDocumentation
              CanceledAt = canceledAt
              CancellationPolicyProvided = cancellationPolicyProvided
              CancellationReason = cancellationReason
              ExpectedAt = expectedAt
              Explanation = explanation
              ProductDescription = productDescription
              ProductType = productType
              ReturnStatus = returnStatus
              ReturnedAt = returnedAt
            }

    type Create'EvidenceDuplicateDuplicate =
        {
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
            [<Config.Form>]
            AdditionalDocumentation: Choice<string,string> option
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Copy of the card statement showing that the product had already been paid for.
            [<Config.Form>]
            CardStatement: Choice<string,string> option
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Copy of the receipt showing that the product had been paid for in cash.
            [<Config.Form>]
            CashReceipt: Choice<string,string> option
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Image of the front and back of the check that was used to pay for the product.
            [<Config.Form>]
            CheckImage: Choice<string,string> option
            /// Explanation of why the cardholder is disputing this transaction.
            [<Config.Form>]
            Explanation: Choice<string,string> option
            /// Transaction (e.g., ipi_...) that the disputed transaction is a duplicate of. Of the two or more transactions that are copies of each other, this is original undisputed one.
            [<Config.Form>]
            OriginalTransaction: string option
        }

    type Create'EvidenceDuplicateDuplicate with
        static member New(?additionalDocumentation: Choice<string,string>, ?cardStatement: Choice<string,string>, ?cashReceipt: Choice<string,string>, ?checkImage: Choice<string,string>, ?explanation: Choice<string,string>, ?originalTransaction: string) =
            {
                AdditionalDocumentation = additionalDocumentation
                CardStatement = cardStatement
                CashReceipt = cashReceipt
                CheckImage = checkImage
                Explanation = explanation
                OriginalTransaction = originalTransaction
            }

    module Create'EvidenceDuplicateDuplicate =
        let create
            (
                additionalDocumentation: Choice<string,string> option,
                cardStatement: Choice<string,string> option,
                cashReceipt: Choice<string,string> option,
                checkImage: Choice<string,string> option,
                explanation: Choice<string,string> option,
                originalTransaction: string option
            ) : Create'EvidenceDuplicateDuplicate
            =
            {
              AdditionalDocumentation = additionalDocumentation
              CardStatement = cardStatement
              CashReceipt = cashReceipt
              CheckImage = checkImage
              Explanation = explanation
              OriginalTransaction = originalTransaction
            }

    type Create'EvidenceFraudulentFraudulent =
        {
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
            [<Config.Form>]
            AdditionalDocumentation: Choice<string,string> option
            /// Explanation of why the cardholder is disputing this transaction.
            [<Config.Form>]
            Explanation: Choice<string,string> option
        }

    type Create'EvidenceFraudulentFraudulent with
        static member New(?additionalDocumentation: Choice<string,string>, ?explanation: Choice<string,string>) =
            {
                AdditionalDocumentation = additionalDocumentation
                Explanation = explanation
            }

    module Create'EvidenceFraudulentFraudulent =
        let create
            (
                additionalDocumentation: Choice<string,string> option,
                explanation: Choice<string,string> option
            ) : Create'EvidenceFraudulentFraudulent
            =
            {
              AdditionalDocumentation = additionalDocumentation
              Explanation = explanation
            }

    type Create'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus =
        | MerchantRejected
        | Successful

    type Create'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed =
        {
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
            [<Config.Form>]
            AdditionalDocumentation: Choice<string,string> option
            /// Explanation of why the cardholder is disputing this transaction.
            [<Config.Form>]
            Explanation: Choice<string,string> option
            /// Date when the product was received.
            [<Config.Form>]
            ReceivedAt: Choice<DateTime,string> option
            /// Description of the cardholder's attempt to return the product.
            [<Config.Form>]
            ReturnDescription: Choice<string,string> option
            /// Result of cardholder's attempt to return the product.
            [<Config.Form>]
            ReturnStatus: Create'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus option
            /// Date when the product was returned or attempted to be returned.
            [<Config.Form>]
            ReturnedAt: Choice<DateTime,string> option
        }

    type Create'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed with
        static member New(?additionalDocumentation: Choice<string,string>, ?explanation: Choice<string,string>, ?receivedAt: Choice<DateTime,string>, ?returnDescription: Choice<string,string>, ?returnStatus: Create'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus, ?returnedAt: Choice<DateTime,string>) =
            {
                AdditionalDocumentation = additionalDocumentation
                Explanation = explanation
                ReceivedAt = receivedAt
                ReturnDescription = returnDescription
                ReturnStatus = returnStatus
                ReturnedAt = returnedAt
            }

    module Create'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed =
        let create
            (
                additionalDocumentation: Choice<string,string> option,
                explanation: Choice<string,string> option,
                receivedAt: Choice<DateTime,string> option,
                returnDescription: Choice<string,string> option,
                returnStatus: Create'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus option,
                returnedAt: Choice<DateTime,string> option
            ) : Create'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed
            =
            {
              AdditionalDocumentation = additionalDocumentation
              Explanation = explanation
              ReceivedAt = receivedAt
              ReturnDescription = returnDescription
              ReturnStatus = returnStatus
              ReturnedAt = returnedAt
            }

    type Create'EvidenceNoValidAuthorizationNoValidAuthorization =
        {
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
            [<Config.Form>]
            AdditionalDocumentation: Choice<string,string> option
            /// Explanation of why the cardholder is disputing this transaction.
            [<Config.Form>]
            Explanation: Choice<string,string> option
        }

    type Create'EvidenceNoValidAuthorizationNoValidAuthorization with
        static member New(?additionalDocumentation: Choice<string,string>, ?explanation: Choice<string,string>) =
            {
                AdditionalDocumentation = additionalDocumentation
                Explanation = explanation
            }

    module Create'EvidenceNoValidAuthorizationNoValidAuthorization =
        let create
            (
                additionalDocumentation: Choice<string,string> option,
                explanation: Choice<string,string> option
            ) : Create'EvidenceNoValidAuthorizationNoValidAuthorization
            =
            {
              AdditionalDocumentation = additionalDocumentation
              Explanation = explanation
            }

    type Create'EvidenceNotReceivedNotReceivedProductType =
        | Merchandise
        | Service

    type Create'EvidenceNotReceivedNotReceived =
        {
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
            [<Config.Form>]
            AdditionalDocumentation: Choice<string,string> option
            /// Date when the cardholder expected to receive the product.
            [<Config.Form>]
            ExpectedAt: Choice<DateTime,string> option
            /// Explanation of why the cardholder is disputing this transaction.
            [<Config.Form>]
            Explanation: Choice<string,string> option
            /// Description of the merchandise or service that was purchased.
            [<Config.Form>]
            ProductDescription: Choice<string,string> option
            /// Whether the product was a merchandise or service.
            [<Config.Form>]
            ProductType: Create'EvidenceNotReceivedNotReceivedProductType option
        }

    type Create'EvidenceNotReceivedNotReceived with
        static member New(?additionalDocumentation: Choice<string,string>, ?expectedAt: Choice<DateTime,string>, ?explanation: Choice<string,string>, ?productDescription: Choice<string,string>, ?productType: Create'EvidenceNotReceivedNotReceivedProductType) =
            {
                AdditionalDocumentation = additionalDocumentation
                ExpectedAt = expectedAt
                Explanation = explanation
                ProductDescription = productDescription
                ProductType = productType
            }

    module Create'EvidenceNotReceivedNotReceived =
        let create
            (
                additionalDocumentation: Choice<string,string> option,
                expectedAt: Choice<DateTime,string> option,
                explanation: Choice<string,string> option,
                productDescription: Choice<string,string> option,
                productType: Create'EvidenceNotReceivedNotReceivedProductType option
            ) : Create'EvidenceNotReceivedNotReceived
            =
            {
              AdditionalDocumentation = additionalDocumentation
              ExpectedAt = expectedAt
              Explanation = explanation
              ProductDescription = productDescription
              ProductType = productType
            }

    type Create'EvidenceOtherOtherProductType =
        | Merchandise
        | Service

    type Create'EvidenceOtherOther =
        {
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
            [<Config.Form>]
            AdditionalDocumentation: Choice<string,string> option
            /// Explanation of why the cardholder is disputing this transaction.
            [<Config.Form>]
            Explanation: Choice<string,string> option
            /// Description of the merchandise or service that was purchased.
            [<Config.Form>]
            ProductDescription: Choice<string,string> option
            /// Whether the product was a merchandise or service.
            [<Config.Form>]
            ProductType: Create'EvidenceOtherOtherProductType option
        }

    type Create'EvidenceOtherOther with
        static member New(?additionalDocumentation: Choice<string,string>, ?explanation: Choice<string,string>, ?productDescription: Choice<string,string>, ?productType: Create'EvidenceOtherOtherProductType) =
            {
                AdditionalDocumentation = additionalDocumentation
                Explanation = explanation
                ProductDescription = productDescription
                ProductType = productType
            }

    module Create'EvidenceOtherOther =
        let create
            (
                additionalDocumentation: Choice<string,string> option,
                explanation: Choice<string,string> option,
                productDescription: Choice<string,string> option,
                productType: Create'EvidenceOtherOtherProductType option
            ) : Create'EvidenceOtherOther
            =
            {
              AdditionalDocumentation = additionalDocumentation
              Explanation = explanation
              ProductDescription = productDescription
              ProductType = productType
            }

    type Create'EvidenceReason =
        | Canceled
        | Duplicate
        | Fraudulent
        | MerchandiseNotAsDescribed
        | NoValidAuthorization
        | NotReceived
        | Other
        | ServiceNotAsDescribed

    type Create'EvidenceServiceNotAsDescribedServiceNotAsDescribed =
        {
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
            [<Config.Form>]
            AdditionalDocumentation: Choice<string,string> option
            /// Date when order was canceled.
            [<Config.Form>]
            CanceledAt: Choice<DateTime,string> option
            /// Reason for canceling the order.
            [<Config.Form>]
            CancellationReason: Choice<string,string> option
            /// Explanation of why the cardholder is disputing this transaction.
            [<Config.Form>]
            Explanation: Choice<string,string> option
            /// Date when the product was received.
            [<Config.Form>]
            ReceivedAt: Choice<DateTime,string> option
        }

    type Create'EvidenceServiceNotAsDescribedServiceNotAsDescribed with
        static member New(?additionalDocumentation: Choice<string,string>, ?canceledAt: Choice<DateTime,string>, ?cancellationReason: Choice<string,string>, ?explanation: Choice<string,string>, ?receivedAt: Choice<DateTime,string>) =
            {
                AdditionalDocumentation = additionalDocumentation
                CanceledAt = canceledAt
                CancellationReason = cancellationReason
                Explanation = explanation
                ReceivedAt = receivedAt
            }

    module Create'EvidenceServiceNotAsDescribedServiceNotAsDescribed =
        let create
            (
                additionalDocumentation: Choice<string,string> option,
                canceledAt: Choice<DateTime,string> option,
                cancellationReason: Choice<string,string> option,
                explanation: Choice<string,string> option,
                receivedAt: Choice<DateTime,string> option
            ) : Create'EvidenceServiceNotAsDescribedServiceNotAsDescribed
            =
            {
              AdditionalDocumentation = additionalDocumentation
              CanceledAt = canceledAt
              CancellationReason = cancellationReason
              Explanation = explanation
              ReceivedAt = receivedAt
            }

    type Create'Evidence =
        {
            /// Evidence provided when `reason` is 'canceled'.
            [<Config.Form>]
            Canceled: Choice<Create'EvidenceCanceledCanceled,string> option
            /// Evidence provided when `reason` is 'duplicate'.
            [<Config.Form>]
            Duplicate: Choice<Create'EvidenceDuplicateDuplicate,string> option
            /// Evidence provided when `reason` is 'fraudulent'.
            [<Config.Form>]
            Fraudulent: Choice<Create'EvidenceFraudulentFraudulent,string> option
            /// Evidence provided when `reason` is 'merchandise_not_as_described'.
            [<Config.Form>]
            MerchandiseNotAsDescribed:
                Choice<Create'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed,string> option
            /// Evidence provided when `reason` is 'no_valid_authorization'.
            [<Config.Form>]
            NoValidAuthorization: Choice<Create'EvidenceNoValidAuthorizationNoValidAuthorization,string> option
            /// Evidence provided when `reason` is 'not_received'.
            [<Config.Form>]
            NotReceived: Choice<Create'EvidenceNotReceivedNotReceived,string> option
            /// Evidence provided when `reason` is 'other'.
            [<Config.Form>]
            Other: Choice<Create'EvidenceOtherOther,string> option
            /// The reason for filing the dispute. The evidence should be submitted in the field of the same name.
            [<Config.Form>]
            Reason: Create'EvidenceReason option
            /// Evidence provided when `reason` is 'service_not_as_described'.
            [<Config.Form>]
            ServiceNotAsDescribed: Choice<Create'EvidenceServiceNotAsDescribedServiceNotAsDescribed,string> option
        }

    type Create'Evidence with
        static member New(?canceled: Choice<Create'EvidenceCanceledCanceled,string>, ?duplicate: Choice<Create'EvidenceDuplicateDuplicate,string>, ?fraudulent: Choice<Create'EvidenceFraudulentFraudulent,string>, ?merchandiseNotAsDescribed: Choice<Create'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed,string>, ?noValidAuthorization: Choice<Create'EvidenceNoValidAuthorizationNoValidAuthorization,string>, ?notReceived: Choice<Create'EvidenceNotReceivedNotReceived,string>, ?other: Choice<Create'EvidenceOtherOther,string>, ?reason: Create'EvidenceReason, ?serviceNotAsDescribed: Choice<Create'EvidenceServiceNotAsDescribedServiceNotAsDescribed,string>) =
            {
                Canceled = canceled
                Duplicate = duplicate
                Fraudulent = fraudulent
                MerchandiseNotAsDescribed = merchandiseNotAsDescribed
                NoValidAuthorization = noValidAuthorization
                NotReceived = notReceived
                Other = other
                Reason = reason
                ServiceNotAsDescribed = serviceNotAsDescribed
            }

    module Create'Evidence =
        let create
            (
                canceled: Choice<Create'EvidenceCanceledCanceled,string> option,
                duplicate: Choice<Create'EvidenceDuplicateDuplicate,string> option,
                fraudulent: Choice<Create'EvidenceFraudulentFraudulent,string> option,
                merchandiseNotAsDescribed: Choice<Create'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed,string> option,
                noValidAuthorization: Choice<Create'EvidenceNoValidAuthorizationNoValidAuthorization,string> option,
                notReceived: Choice<Create'EvidenceNotReceivedNotReceived,string> option,
                other: Choice<Create'EvidenceOtherOther,string> option,
                reason: Create'EvidenceReason option,
                serviceNotAsDescribed: Choice<Create'EvidenceServiceNotAsDescribedServiceNotAsDescribed,string> option
            ) : Create'Evidence
            =
            {
              Canceled = canceled
              Duplicate = duplicate
              Fraudulent = fraudulent
              MerchandiseNotAsDescribed = merchandiseNotAsDescribed
              NoValidAuthorization = noValidAuthorization
              NotReceived = notReceived
              Other = other
              Reason = reason
              ServiceNotAsDescribed = serviceNotAsDescribed
            }

    type Create'Treasury =
        {
            /// The ID of the ReceivedDebit to initiate an Issuings dispute for.
            [<Config.Form>]
            ReceivedDebit: string option
        }

    type Create'Treasury with
        static member New(?receivedDebit: string) =
            {
                ReceivedDebit = receivedDebit
            }

    module Create'Treasury =
        let create
            (
                receivedDebit: string option
            ) : Create'Treasury
            =
            {
              ReceivedDebit = receivedDebit
            }

    type CreateOptions =
        {
            /// The dispute amount in the card's currency and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal). If not set, defaults to the full transaction amount.
            [<Config.Form>]
            Amount: int option
            /// Evidence provided for the dispute.
            [<Config.Form>]
            Evidence: Create'Evidence option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The ID of the issuing transaction to create a dispute for. For transaction on Treasury FinancialAccounts, use `treasury.received_debit`.
            [<Config.Form>]
            Transaction: string option
            /// Params for disputes related to Treasury FinancialAccounts
            [<Config.Form>]
            Treasury: Create'Treasury option
        }

    type CreateOptions with
        static member New(?amount: int, ?evidence: Create'Evidence, ?expand: string list, ?metadata: Map<string, string>, ?transaction: string, ?treasury: Create'Treasury) =
            {
                Amount = amount
                Evidence = evidence
                Expand = expand
                Metadata = metadata
                Transaction = transaction
                Treasury = treasury
            }

    module CreateOptions =
        let create
            (
                amount: int option,
                evidence: Create'Evidence option,
                expand: string list option,
                metadata: Map<string, string> option,
                transaction: string option,
                treasury: Create'Treasury option
            ) : CreateOptions
            =
            {
              Amount = amount
              Evidence = evidence
              Expand = expand
              Metadata = metadata
              Transaction = transaction
              Treasury = treasury
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Dispute: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    type RetrieveOptions with
        static member New(dispute: string, ?expand: string list) =
            {
                Dispute = dispute
                Expand = expand
            }

    module RetrieveOptions =
        let create
            (
                dispute: string
            ) : RetrieveOptions
            =
            {
              Dispute = dispute
              Expand = None
            }

    type Update'EvidenceCanceledCanceledProductType =
        | Merchandise
        | Service

    type Update'EvidenceCanceledCanceledReturnStatus =
        | MerchantRejected
        | Successful

    type Update'EvidenceCanceledCanceled =
        {
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
            [<Config.Form>]
            AdditionalDocumentation: Choice<string,string> option
            /// Date when order was canceled.
            [<Config.Form>]
            CanceledAt: Choice<DateTime,string> option
            /// Whether the cardholder was provided with a cancellation policy.
            [<Config.Form>]
            CancellationPolicyProvided: Choice<bool,string> option
            /// Reason for canceling the order.
            [<Config.Form>]
            CancellationReason: Choice<string,string> option
            /// Date when the cardholder expected to receive the product.
            [<Config.Form>]
            ExpectedAt: Choice<DateTime,string> option
            /// Explanation of why the cardholder is disputing this transaction.
            [<Config.Form>]
            Explanation: Choice<string,string> option
            /// Description of the merchandise or service that was purchased.
            [<Config.Form>]
            ProductDescription: Choice<string,string> option
            /// Whether the product was a merchandise or service.
            [<Config.Form>]
            ProductType: Update'EvidenceCanceledCanceledProductType option
            /// Result of cardholder's attempt to return the product.
            [<Config.Form>]
            ReturnStatus: Update'EvidenceCanceledCanceledReturnStatus option
            /// Date when the product was returned or attempted to be returned.
            [<Config.Form>]
            ReturnedAt: Choice<DateTime,string> option
        }

    type Update'EvidenceCanceledCanceled with
        static member New(?additionalDocumentation: Choice<string,string>, ?canceledAt: Choice<DateTime,string>, ?cancellationPolicyProvided: Choice<bool,string>, ?cancellationReason: Choice<string,string>, ?expectedAt: Choice<DateTime,string>, ?explanation: Choice<string,string>, ?productDescription: Choice<string,string>, ?productType: Update'EvidenceCanceledCanceledProductType, ?returnStatus: Update'EvidenceCanceledCanceledReturnStatus, ?returnedAt: Choice<DateTime,string>) =
            {
                AdditionalDocumentation = additionalDocumentation
                CanceledAt = canceledAt
                CancellationPolicyProvided = cancellationPolicyProvided
                CancellationReason = cancellationReason
                ExpectedAt = expectedAt
                Explanation = explanation
                ProductDescription = productDescription
                ProductType = productType
                ReturnStatus = returnStatus
                ReturnedAt = returnedAt
            }

    module Update'EvidenceCanceledCanceled =
        let create
            (
                additionalDocumentation: Choice<string,string> option,
                canceledAt: Choice<DateTime,string> option,
                cancellationPolicyProvided: Choice<bool,string> option,
                cancellationReason: Choice<string,string> option,
                expectedAt: Choice<DateTime,string> option,
                explanation: Choice<string,string> option,
                productDescription: Choice<string,string> option,
                productType: Update'EvidenceCanceledCanceledProductType option,
                returnStatus: Update'EvidenceCanceledCanceledReturnStatus option,
                returnedAt: Choice<DateTime,string> option
            ) : Update'EvidenceCanceledCanceled
            =
            {
              AdditionalDocumentation = additionalDocumentation
              CanceledAt = canceledAt
              CancellationPolicyProvided = cancellationPolicyProvided
              CancellationReason = cancellationReason
              ExpectedAt = expectedAt
              Explanation = explanation
              ProductDescription = productDescription
              ProductType = productType
              ReturnStatus = returnStatus
              ReturnedAt = returnedAt
            }

    type Update'EvidenceDuplicateDuplicate =
        {
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
            [<Config.Form>]
            AdditionalDocumentation: Choice<string,string> option
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Copy of the card statement showing that the product had already been paid for.
            [<Config.Form>]
            CardStatement: Choice<string,string> option
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Copy of the receipt showing that the product had been paid for in cash.
            [<Config.Form>]
            CashReceipt: Choice<string,string> option
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Image of the front and back of the check that was used to pay for the product.
            [<Config.Form>]
            CheckImage: Choice<string,string> option
            /// Explanation of why the cardholder is disputing this transaction.
            [<Config.Form>]
            Explanation: Choice<string,string> option
            /// Transaction (e.g., ipi_...) that the disputed transaction is a duplicate of. Of the two or more transactions that are copies of each other, this is original undisputed one.
            [<Config.Form>]
            OriginalTransaction: string option
        }

    type Update'EvidenceDuplicateDuplicate with
        static member New(?additionalDocumentation: Choice<string,string>, ?cardStatement: Choice<string,string>, ?cashReceipt: Choice<string,string>, ?checkImage: Choice<string,string>, ?explanation: Choice<string,string>, ?originalTransaction: string) =
            {
                AdditionalDocumentation = additionalDocumentation
                CardStatement = cardStatement
                CashReceipt = cashReceipt
                CheckImage = checkImage
                Explanation = explanation
                OriginalTransaction = originalTransaction
            }

    module Update'EvidenceDuplicateDuplicate =
        let create
            (
                additionalDocumentation: Choice<string,string> option,
                cardStatement: Choice<string,string> option,
                cashReceipt: Choice<string,string> option,
                checkImage: Choice<string,string> option,
                explanation: Choice<string,string> option,
                originalTransaction: string option
            ) : Update'EvidenceDuplicateDuplicate
            =
            {
              AdditionalDocumentation = additionalDocumentation
              CardStatement = cardStatement
              CashReceipt = cashReceipt
              CheckImage = checkImage
              Explanation = explanation
              OriginalTransaction = originalTransaction
            }

    type Update'EvidenceFraudulentFraudulent =
        {
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
            [<Config.Form>]
            AdditionalDocumentation: Choice<string,string> option
            /// Explanation of why the cardholder is disputing this transaction.
            [<Config.Form>]
            Explanation: Choice<string,string> option
        }

    type Update'EvidenceFraudulentFraudulent with
        static member New(?additionalDocumentation: Choice<string,string>, ?explanation: Choice<string,string>) =
            {
                AdditionalDocumentation = additionalDocumentation
                Explanation = explanation
            }

    module Update'EvidenceFraudulentFraudulent =
        let create
            (
                additionalDocumentation: Choice<string,string> option,
                explanation: Choice<string,string> option
            ) : Update'EvidenceFraudulentFraudulent
            =
            {
              AdditionalDocumentation = additionalDocumentation
              Explanation = explanation
            }

    type Update'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus =
        | MerchantRejected
        | Successful

    type Update'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed =
        {
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
            [<Config.Form>]
            AdditionalDocumentation: Choice<string,string> option
            /// Explanation of why the cardholder is disputing this transaction.
            [<Config.Form>]
            Explanation: Choice<string,string> option
            /// Date when the product was received.
            [<Config.Form>]
            ReceivedAt: Choice<DateTime,string> option
            /// Description of the cardholder's attempt to return the product.
            [<Config.Form>]
            ReturnDescription: Choice<string,string> option
            /// Result of cardholder's attempt to return the product.
            [<Config.Form>]
            ReturnStatus: Update'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus option
            /// Date when the product was returned or attempted to be returned.
            [<Config.Form>]
            ReturnedAt: Choice<DateTime,string> option
        }

    type Update'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed with
        static member New(?additionalDocumentation: Choice<string,string>, ?explanation: Choice<string,string>, ?receivedAt: Choice<DateTime,string>, ?returnDescription: Choice<string,string>, ?returnStatus: Update'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus, ?returnedAt: Choice<DateTime,string>) =
            {
                AdditionalDocumentation = additionalDocumentation
                Explanation = explanation
                ReceivedAt = receivedAt
                ReturnDescription = returnDescription
                ReturnStatus = returnStatus
                ReturnedAt = returnedAt
            }

    module Update'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed =
        let create
            (
                additionalDocumentation: Choice<string,string> option,
                explanation: Choice<string,string> option,
                receivedAt: Choice<DateTime,string> option,
                returnDescription: Choice<string,string> option,
                returnStatus: Update'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus option,
                returnedAt: Choice<DateTime,string> option
            ) : Update'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed
            =
            {
              AdditionalDocumentation = additionalDocumentation
              Explanation = explanation
              ReceivedAt = receivedAt
              ReturnDescription = returnDescription
              ReturnStatus = returnStatus
              ReturnedAt = returnedAt
            }

    type Update'EvidenceNoValidAuthorizationNoValidAuthorization =
        {
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
            [<Config.Form>]
            AdditionalDocumentation: Choice<string,string> option
            /// Explanation of why the cardholder is disputing this transaction.
            [<Config.Form>]
            Explanation: Choice<string,string> option
        }

    type Update'EvidenceNoValidAuthorizationNoValidAuthorization with
        static member New(?additionalDocumentation: Choice<string,string>, ?explanation: Choice<string,string>) =
            {
                AdditionalDocumentation = additionalDocumentation
                Explanation = explanation
            }

    module Update'EvidenceNoValidAuthorizationNoValidAuthorization =
        let create
            (
                additionalDocumentation: Choice<string,string> option,
                explanation: Choice<string,string> option
            ) : Update'EvidenceNoValidAuthorizationNoValidAuthorization
            =
            {
              AdditionalDocumentation = additionalDocumentation
              Explanation = explanation
            }

    type Update'EvidenceNotReceivedNotReceivedProductType =
        | Merchandise
        | Service

    type Update'EvidenceNotReceivedNotReceived =
        {
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
            [<Config.Form>]
            AdditionalDocumentation: Choice<string,string> option
            /// Date when the cardholder expected to receive the product.
            [<Config.Form>]
            ExpectedAt: Choice<DateTime,string> option
            /// Explanation of why the cardholder is disputing this transaction.
            [<Config.Form>]
            Explanation: Choice<string,string> option
            /// Description of the merchandise or service that was purchased.
            [<Config.Form>]
            ProductDescription: Choice<string,string> option
            /// Whether the product was a merchandise or service.
            [<Config.Form>]
            ProductType: Update'EvidenceNotReceivedNotReceivedProductType option
        }

    type Update'EvidenceNotReceivedNotReceived with
        static member New(?additionalDocumentation: Choice<string,string>, ?expectedAt: Choice<DateTime,string>, ?explanation: Choice<string,string>, ?productDescription: Choice<string,string>, ?productType: Update'EvidenceNotReceivedNotReceivedProductType) =
            {
                AdditionalDocumentation = additionalDocumentation
                ExpectedAt = expectedAt
                Explanation = explanation
                ProductDescription = productDescription
                ProductType = productType
            }

    module Update'EvidenceNotReceivedNotReceived =
        let create
            (
                additionalDocumentation: Choice<string,string> option,
                expectedAt: Choice<DateTime,string> option,
                explanation: Choice<string,string> option,
                productDescription: Choice<string,string> option,
                productType: Update'EvidenceNotReceivedNotReceivedProductType option
            ) : Update'EvidenceNotReceivedNotReceived
            =
            {
              AdditionalDocumentation = additionalDocumentation
              ExpectedAt = expectedAt
              Explanation = explanation
              ProductDescription = productDescription
              ProductType = productType
            }

    type Update'EvidenceOtherOtherProductType =
        | Merchandise
        | Service

    type Update'EvidenceOtherOther =
        {
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
            [<Config.Form>]
            AdditionalDocumentation: Choice<string,string> option
            /// Explanation of why the cardholder is disputing this transaction.
            [<Config.Form>]
            Explanation: Choice<string,string> option
            /// Description of the merchandise or service that was purchased.
            [<Config.Form>]
            ProductDescription: Choice<string,string> option
            /// Whether the product was a merchandise or service.
            [<Config.Form>]
            ProductType: Update'EvidenceOtherOtherProductType option
        }

    type Update'EvidenceOtherOther with
        static member New(?additionalDocumentation: Choice<string,string>, ?explanation: Choice<string,string>, ?productDescription: Choice<string,string>, ?productType: Update'EvidenceOtherOtherProductType) =
            {
                AdditionalDocumentation = additionalDocumentation
                Explanation = explanation
                ProductDescription = productDescription
                ProductType = productType
            }

    module Update'EvidenceOtherOther =
        let create
            (
                additionalDocumentation: Choice<string,string> option,
                explanation: Choice<string,string> option,
                productDescription: Choice<string,string> option,
                productType: Update'EvidenceOtherOtherProductType option
            ) : Update'EvidenceOtherOther
            =
            {
              AdditionalDocumentation = additionalDocumentation
              Explanation = explanation
              ProductDescription = productDescription
              ProductType = productType
            }

    type Update'EvidenceReason =
        | Canceled
        | Duplicate
        | Fraudulent
        | MerchandiseNotAsDescribed
        | NoValidAuthorization
        | NotReceived
        | Other
        | ServiceNotAsDescribed

    type Update'EvidenceServiceNotAsDescribedServiceNotAsDescribed =
        {
            /// (ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
            [<Config.Form>]
            AdditionalDocumentation: Choice<string,string> option
            /// Date when order was canceled.
            [<Config.Form>]
            CanceledAt: Choice<DateTime,string> option
            /// Reason for canceling the order.
            [<Config.Form>]
            CancellationReason: Choice<string,string> option
            /// Explanation of why the cardholder is disputing this transaction.
            [<Config.Form>]
            Explanation: Choice<string,string> option
            /// Date when the product was received.
            [<Config.Form>]
            ReceivedAt: Choice<DateTime,string> option
        }

    type Update'EvidenceServiceNotAsDescribedServiceNotAsDescribed with
        static member New(?additionalDocumentation: Choice<string,string>, ?canceledAt: Choice<DateTime,string>, ?cancellationReason: Choice<string,string>, ?explanation: Choice<string,string>, ?receivedAt: Choice<DateTime,string>) =
            {
                AdditionalDocumentation = additionalDocumentation
                CanceledAt = canceledAt
                CancellationReason = cancellationReason
                Explanation = explanation
                ReceivedAt = receivedAt
            }

    module Update'EvidenceServiceNotAsDescribedServiceNotAsDescribed =
        let create
            (
                additionalDocumentation: Choice<string,string> option,
                canceledAt: Choice<DateTime,string> option,
                cancellationReason: Choice<string,string> option,
                explanation: Choice<string,string> option,
                receivedAt: Choice<DateTime,string> option
            ) : Update'EvidenceServiceNotAsDescribedServiceNotAsDescribed
            =
            {
              AdditionalDocumentation = additionalDocumentation
              CanceledAt = canceledAt
              CancellationReason = cancellationReason
              Explanation = explanation
              ReceivedAt = receivedAt
            }

    type Update'Evidence =
        {
            /// Evidence provided when `reason` is 'canceled'.
            [<Config.Form>]
            Canceled: Choice<Update'EvidenceCanceledCanceled,string> option
            /// Evidence provided when `reason` is 'duplicate'.
            [<Config.Form>]
            Duplicate: Choice<Update'EvidenceDuplicateDuplicate,string> option
            /// Evidence provided when `reason` is 'fraudulent'.
            [<Config.Form>]
            Fraudulent: Choice<Update'EvidenceFraudulentFraudulent,string> option
            /// Evidence provided when `reason` is 'merchandise_not_as_described'.
            [<Config.Form>]
            MerchandiseNotAsDescribed:
                Choice<Update'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed,string> option
            /// Evidence provided when `reason` is 'no_valid_authorization'.
            [<Config.Form>]
            NoValidAuthorization: Choice<Update'EvidenceNoValidAuthorizationNoValidAuthorization,string> option
            /// Evidence provided when `reason` is 'not_received'.
            [<Config.Form>]
            NotReceived: Choice<Update'EvidenceNotReceivedNotReceived,string> option
            /// Evidence provided when `reason` is 'other'.
            [<Config.Form>]
            Other: Choice<Update'EvidenceOtherOther,string> option
            /// The reason for filing the dispute. The evidence should be submitted in the field of the same name.
            [<Config.Form>]
            Reason: Update'EvidenceReason option
            /// Evidence provided when `reason` is 'service_not_as_described'.
            [<Config.Form>]
            ServiceNotAsDescribed: Choice<Update'EvidenceServiceNotAsDescribedServiceNotAsDescribed,string> option
        }

    type Update'Evidence with
        static member New(?canceled: Choice<Update'EvidenceCanceledCanceled,string>, ?duplicate: Choice<Update'EvidenceDuplicateDuplicate,string>, ?fraudulent: Choice<Update'EvidenceFraudulentFraudulent,string>, ?merchandiseNotAsDescribed: Choice<Update'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed,string>, ?noValidAuthorization: Choice<Update'EvidenceNoValidAuthorizationNoValidAuthorization,string>, ?notReceived: Choice<Update'EvidenceNotReceivedNotReceived,string>, ?other: Choice<Update'EvidenceOtherOther,string>, ?reason: Update'EvidenceReason, ?serviceNotAsDescribed: Choice<Update'EvidenceServiceNotAsDescribedServiceNotAsDescribed,string>) =
            {
                Canceled = canceled
                Duplicate = duplicate
                Fraudulent = fraudulent
                MerchandiseNotAsDescribed = merchandiseNotAsDescribed
                NoValidAuthorization = noValidAuthorization
                NotReceived = notReceived
                Other = other
                Reason = reason
                ServiceNotAsDescribed = serviceNotAsDescribed
            }

    module Update'Evidence =
        let create
            (
                canceled: Choice<Update'EvidenceCanceledCanceled,string> option,
                duplicate: Choice<Update'EvidenceDuplicateDuplicate,string> option,
                fraudulent: Choice<Update'EvidenceFraudulentFraudulent,string> option,
                merchandiseNotAsDescribed: Choice<Update'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed,string> option,
                noValidAuthorization: Choice<Update'EvidenceNoValidAuthorizationNoValidAuthorization,string> option,
                notReceived: Choice<Update'EvidenceNotReceivedNotReceived,string> option,
                other: Choice<Update'EvidenceOtherOther,string> option,
                reason: Update'EvidenceReason option,
                serviceNotAsDescribed: Choice<Update'EvidenceServiceNotAsDescribedServiceNotAsDescribed,string> option
            ) : Update'Evidence
            =
            {
              Canceled = canceled
              Duplicate = duplicate
              Fraudulent = fraudulent
              MerchandiseNotAsDescribed = merchandiseNotAsDescribed
              NoValidAuthorization = noValidAuthorization
              NotReceived = notReceived
              Other = other
              Reason = reason
              ServiceNotAsDescribed = serviceNotAsDescribed
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Dispute: string
            /// The dispute amount in the card's currency and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).
            [<Config.Form>]
            Amount: int option
            /// Evidence provided for the dispute.
            [<Config.Form>]
            Evidence: Update'Evidence option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
        }

    type UpdateOptions with
        static member New(dispute: string, ?amount: int, ?evidence: Update'Evidence, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Dispute = dispute
                Amount = amount
                Evidence = evidence
                Expand = expand
                Metadata = metadata
            }

    module UpdateOptions =
        let create
            (
                dispute: string
            ) : UpdateOptions
            =
            {
              Dispute = dispute
              Amount = None
              Evidence = None
              Expand = None
              Metadata = None
            }

    ///<p>Returns a list of Issuing <code>Dispute</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("transaction", options.Transaction |> box)] |> Map.ofList
        $"/v1/issuing/disputes"
        |> RestApi.getAsync<StripeList<IssuingDispute>> settings qs

    ///<p>Creates an Issuing <code>Dispute</code> object. Individual pieces of evidence within the <code>evidence</code> object are optional at this point. Stripe only validates that required evidence is present during submission. Refer to <a href="/docs/issuing/purchases/disputes#dispute-reasons-and-evidence">Dispute reasons and evidence</a> for more details about evidence requirements.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/issuing/disputes"
        |> RestApi.postAsync<_, IssuingDispute> settings (Map.empty) options

    ///<p>Retrieves an Issuing <code>Dispute</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/issuing/disputes/{options.Dispute}"
        |> RestApi.getAsync<IssuingDispute> settings qs

    ///<p>Updates the specified Issuing <code>Dispute</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged. Properties on the <code>evidence</code> object can be unset by passing in an empty string.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/issuing/disputes/{options.Dispute}"
        |> RestApi.postAsync<_, IssuingDispute> settings (Map.empty) options

module IssuingDisputesSubmit =

    type SubmitOptions =
        {
            [<Config.Path>]
            Dispute: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
        }

    type SubmitOptions with
        static member New(dispute: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Dispute = dispute
                Expand = expand
                Metadata = metadata
            }

    module SubmitOptions =
        let create
            (
                dispute: string
            ) : SubmitOptions
            =
            {
              Dispute = dispute
              Expand = None
              Metadata = None
            }

    ///<p>Submits an Issuing <code>Dispute</code> to the card network. Stripe validates that all evidence fields required for the dispute’s reason are present. For more details, see <a href="/docs/issuing/purchases/disputes#dispute-reasons-and-evidence">Dispute reasons and evidence</a>.</p>
    let Submit settings (options: SubmitOptions) =
        $"/v1/issuing/disputes/{options.Dispute}/submit"
        |> RestApi.postAsync<_, IssuingDispute> settings (Map.empty) options

module IssuingPersonalizationDesigns =

    type ListOptions =
        {
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// Only return personalization designs with the given lookup keys.
            [<Config.Query>]
            LookupKeys: string list option
            /// Only return personalization designs with the given preferences.
            [<Config.Query>]
            Preferences: Map<string, string> option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return personalization designs with the given status.
            [<Config.Query>]
            Status: string option
        }

    type ListOptions with
        static member New(?endingBefore: string, ?expand: string list, ?limit: int, ?lookupKeys: string list, ?preferences: Map<string, string>, ?startingAfter: string, ?status: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                LookupKeys = lookupKeys
                Preferences = preferences
                StartingAfter = startingAfter
                Status = status
            }

    module ListOptions =
        let create
            (
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                lookupKeys: string list option,
                preferences: Map<string, string> option,
                startingAfter: string option,
                status: string option
            ) : ListOptions
            =
            {
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              LookupKeys = lookupKeys
              Preferences = preferences
              StartingAfter = startingAfter
              Status = status
            }

    type Create'CarrierText =
        {
            /// The footer body text of the carrier letter.
            [<Config.Form>]
            FooterBody: Choice<string,string> option
            /// The footer title text of the carrier letter.
            [<Config.Form>]
            FooterTitle: Choice<string,string> option
            /// The header body text of the carrier letter.
            [<Config.Form>]
            HeaderBody: Choice<string,string> option
            /// The header title text of the carrier letter.
            [<Config.Form>]
            HeaderTitle: Choice<string,string> option
        }

    type Create'CarrierText with
        static member New(?footerBody: Choice<string,string>, ?footerTitle: Choice<string,string>, ?headerBody: Choice<string,string>, ?headerTitle: Choice<string,string>) =
            {
                FooterBody = footerBody
                FooterTitle = footerTitle
                HeaderBody = headerBody
                HeaderTitle = headerTitle
            }

    module Create'CarrierText =
        let create
            (
                footerBody: Choice<string,string> option,
                footerTitle: Choice<string,string> option,
                headerBody: Choice<string,string> option,
                headerTitle: Choice<string,string> option
            ) : Create'CarrierText
            =
            {
              FooterBody = footerBody
              FooterTitle = footerTitle
              HeaderBody = headerBody
              HeaderTitle = headerTitle
            }

    type Create'Preferences =
        {
            /// Whether we use this personalization design to create cards when one isn't specified. A connected account uses the Connect platform's default design if no personalization design is set as the default design.
            [<Config.Form>]
            IsDefault: bool option
        }

    type Create'Preferences with
        static member New(?isDefault: bool) =
            {
                IsDefault = isDefault
            }

    module Create'Preferences =
        let create
            (
                isDefault: bool option
            ) : Create'Preferences
            =
            {
              IsDefault = isDefault
            }

    type CreateOptions =
        {
            /// The file for the card logo, for use with physical bundles that support card logos. Must have a `purpose` value of `issuing_logo`.
            [<Config.Form>]
            CardLogo: string option
            /// Hash containing carrier text, for use with physical bundles that support carrier text.
            [<Config.Form>]
            CarrierText: Create'CarrierText option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A lookup key used to retrieve personalization designs dynamically from a static string. This may be up to 200 characters.
            [<Config.Form>]
            LookupKey: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Friendly display name.
            [<Config.Form>]
            Name: string option
            /// The physical bundle object belonging to this personalization design.
            [<Config.Form>]
            PhysicalBundle: string
            /// Information on whether this personalization design is used to create cards when one is not specified.
            [<Config.Form>]
            Preferences: Create'Preferences option
            /// If set to true, will atomically remove the lookup key from the existing personalization design, and assign it to this personalization design.
            [<Config.Form>]
            TransferLookupKey: bool option
        }

    type CreateOptions with
        static member New(physicalBundle: string, ?cardLogo: string, ?carrierText: Create'CarrierText, ?expand: string list, ?lookupKey: string, ?metadata: Map<string, string>, ?name: string, ?preferences: Create'Preferences, ?transferLookupKey: bool) =
            {
                PhysicalBundle = physicalBundle
                CardLogo = cardLogo
                CarrierText = carrierText
                Expand = expand
                LookupKey = lookupKey
                Metadata = metadata
                Name = name
                Preferences = preferences
                TransferLookupKey = transferLookupKey
            }

    module CreateOptions =
        let create
            (
                physicalBundle: string
            ) : CreateOptions
            =
            {
              PhysicalBundle = physicalBundle
              CardLogo = None
              CarrierText = None
              Expand = None
              LookupKey = None
              Metadata = None
              Name = None
              Preferences = None
              TransferLookupKey = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            PersonalizationDesign: string
        }

    type RetrieveOptions with
        static member New(personalizationDesign: string, ?expand: string list) =
            {
                PersonalizationDesign = personalizationDesign
                Expand = expand
            }

    module RetrieveOptions =
        let create
            (
                personalizationDesign: string
            ) : RetrieveOptions
            =
            {
              PersonalizationDesign = personalizationDesign
              Expand = None
            }

    type Update'CarrierTextCarrierText =
        {
            /// The footer body text of the carrier letter.
            [<Config.Form>]
            FooterBody: Choice<string,string> option
            /// The footer title text of the carrier letter.
            [<Config.Form>]
            FooterTitle: Choice<string,string> option
            /// The header body text of the carrier letter.
            [<Config.Form>]
            HeaderBody: Choice<string,string> option
            /// The header title text of the carrier letter.
            [<Config.Form>]
            HeaderTitle: Choice<string,string> option
        }

    type Update'CarrierTextCarrierText with
        static member New(?footerBody: Choice<string,string>, ?footerTitle: Choice<string,string>, ?headerBody: Choice<string,string>, ?headerTitle: Choice<string,string>) =
            {
                FooterBody = footerBody
                FooterTitle = footerTitle
                HeaderBody = headerBody
                HeaderTitle = headerTitle
            }

    module Update'CarrierTextCarrierText =
        let create
            (
                footerBody: Choice<string,string> option,
                footerTitle: Choice<string,string> option,
                headerBody: Choice<string,string> option,
                headerTitle: Choice<string,string> option
            ) : Update'CarrierTextCarrierText
            =
            {
              FooterBody = footerBody
              FooterTitle = footerTitle
              HeaderBody = headerBody
              HeaderTitle = headerTitle
            }

    type Update'Preferences =
        {
            /// Whether we use this personalization design to create cards when one isn't specified. A connected account uses the Connect platform's default design if no personalization design is set as the default design.
            [<Config.Form>]
            IsDefault: bool option
        }

    type Update'Preferences with
        static member New(?isDefault: bool) =
            {
                IsDefault = isDefault
            }

    module Update'Preferences =
        let create
            (
                isDefault: bool option
            ) : Update'Preferences
            =
            {
              IsDefault = isDefault
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            PersonalizationDesign: string
            /// The file for the card logo, for use with physical bundles that support card logos. Must have a `purpose` value of `issuing_logo`.
            [<Config.Form>]
            CardLogo: Choice<string,string> option
            /// Hash containing carrier text, for use with physical bundles that support carrier text.
            [<Config.Form>]
            CarrierText: Choice<Update'CarrierTextCarrierText,string> option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A lookup key used to retrieve personalization designs dynamically from a static string. This may be up to 200 characters.
            [<Config.Form>]
            LookupKey: Choice<string,string> option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Friendly display name. Providing an empty string will set the field to null.
            [<Config.Form>]
            Name: Choice<string,string> option
            /// The physical bundle object belonging to this personalization design.
            [<Config.Form>]
            PhysicalBundle: string option
            /// Information on whether this personalization design is used to create cards when one is not specified.
            [<Config.Form>]
            Preferences: Update'Preferences option
            /// If set to true, will atomically remove the lookup key from the existing personalization design, and assign it to this personalization design.
            [<Config.Form>]
            TransferLookupKey: bool option
        }

    type UpdateOptions with
        static member New(personalizationDesign: string, ?cardLogo: Choice<string,string>, ?carrierText: Choice<Update'CarrierTextCarrierText,string>, ?expand: string list, ?lookupKey: Choice<string,string>, ?metadata: Map<string, string>, ?name: Choice<string,string>, ?physicalBundle: string, ?preferences: Update'Preferences, ?transferLookupKey: bool) =
            {
                PersonalizationDesign = personalizationDesign
                CardLogo = cardLogo
                CarrierText = carrierText
                Expand = expand
                LookupKey = lookupKey
                Metadata = metadata
                Name = name
                PhysicalBundle = physicalBundle
                Preferences = preferences
                TransferLookupKey = transferLookupKey
            }

    module UpdateOptions =
        let create
            (
                personalizationDesign: string
            ) : UpdateOptions
            =
            {
              PersonalizationDesign = personalizationDesign
              CardLogo = None
              CarrierText = None
              Expand = None
              LookupKey = None
              Metadata = None
              Name = None
              PhysicalBundle = None
              Preferences = None
              TransferLookupKey = None
            }

    ///<p>Returns a list of personalization design objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("lookup_keys", options.LookupKeys |> box); ("preferences", options.Preferences |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/issuing/personalization_designs"
        |> RestApi.getAsync<StripeList<IssuingPersonalizationDesign>> settings qs

    ///<p>Creates a personalization design object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/issuing/personalization_designs"
        |> RestApi.postAsync<_, IssuingPersonalizationDesign> settings (Map.empty) options

    ///<p>Retrieves a personalization design object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/issuing/personalization_designs/{options.PersonalizationDesign}"
        |> RestApi.getAsync<IssuingPersonalizationDesign> settings qs

    ///<p>Updates a card personalization object.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/issuing/personalization_designs/{options.PersonalizationDesign}"
        |> RestApi.postAsync<_, IssuingPersonalizationDesign> settings (Map.empty) options

module IssuingPhysicalBundles =

    type ListOptions =
        {
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return physical bundles with the given status.
            [<Config.Query>]
            Status: string option
            /// Only return physical bundles with the given type.
            [<Config.Query>]
            Type: string option
        }

    type ListOptions with
        static member New(?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string, ?type': string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Status = status
                Type = type'
            }

    module ListOptions =
        let create
            (
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option,
                status: string option,
                type': string option
            ) : ListOptions
            =
            {
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
              Status = status
              Type = type'
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            PhysicalBundle: string
        }

    type RetrieveOptions with
        static member New(physicalBundle: string, ?expand: string list) =
            {
                PhysicalBundle = physicalBundle
                Expand = expand
            }

    module RetrieveOptions =
        let create
            (
                physicalBundle: string
            ) : RetrieveOptions
            =
            {
              PhysicalBundle = physicalBundle
              Expand = None
            }

    ///<p>Returns a list of physical bundle objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("type", options.Type |> box)] |> Map.ofList
        $"/v1/issuing/physical_bundles"
        |> RestApi.getAsync<StripeList<IssuingPhysicalBundle>> settings qs

    ///<p>Retrieves a physical bundle object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/issuing/physical_bundles/{options.PhysicalBundle}"
        |> RestApi.getAsync<IssuingPhysicalBundle> settings qs

module IssuingTokens =

    type ListOptions =
        {
            /// The Issuing card identifier to list tokens for.
            [<Config.Query>]
            Card: string
            /// Only return Issuing tokens that were created during the given date interval.
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
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Select Issuing tokens with the given status.
            [<Config.Query>]
            Status: string option
        }

    type ListOptions with
        static member New(card: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
            {
                Card = card
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Status = status
            }

    module ListOptions =
        let create
            (
                card: string
            ) : ListOptions
            =
            {
              Card = card
              Created = None
              EndingBefore = None
              Expand = None
              Limit = None
              StartingAfter = None
              Status = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Token: string
        }

    type RetrieveOptions with
        static member New(token: string, ?expand: string list) =
            {
                Token = token
                Expand = expand
            }

    module RetrieveOptions =
        let create
            (
                token: string
            ) : RetrieveOptions
            =
            {
              Token = token
              Expand = None
            }

    type Update'Status =
        | Active
        | Deleted
        | Suspended

    type UpdateOptions =
        {
            [<Config.Path>]
            Token: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Specifies which status the token should be updated to.
            [<Config.Form>]
            Status: Update'Status
        }

    type UpdateOptions with
        static member New(status: Update'Status, token: string, ?expand: string list) =
            {
                Status = status
                Token = token
                Expand = expand
            }

    module UpdateOptions =
        let create
            (
                status: Update'Status,
                token: string
            ) : UpdateOptions
            =
            {
              Status = status
              Token = token
              Expand = None
            }

    ///<p>Lists all Issuing <code>Token</code> objects for a given card.</p>
    let List settings (options: ListOptions) =
        let qs = [("card", options.Card |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/issuing/tokens"
        |> RestApi.getAsync<StripeList<IssuingToken>> settings qs

    ///<p>Retrieves an Issuing <code>Token</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/issuing/tokens/{options.Token}"
        |> RestApi.getAsync<IssuingToken> settings qs

    ///<p>Attempts to update the specified Issuing <code>Token</code> object to the status specified.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/issuing/tokens/{options.Token}"
        |> RestApi.postAsync<_, IssuingToken> settings (Map.empty) options

module IssuingTransactions =

    type ListOptions =
        {
            /// Only return transactions that belong to the given card.
            [<Config.Query>]
            Card: string option
            /// Only return transactions that belong to the given cardholder.
            [<Config.Query>]
            Cardholder: string option
            /// Only return transactions that were created during the given date interval.
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
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return transactions that have the given type. One of `capture` or `refund`.
            [<Config.Query>]
            Type: string option
        }

    type ListOptions with
        static member New(?card: string, ?cardholder: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?type': string) =
            {
                Card = card
                Cardholder = cardholder
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Type = type'
            }

    module ListOptions =
        let create
            (
                card: string option,
                cardholder: string option,
                created: int option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option,
                type': string option
            ) : ListOptions
            =
            {
              Card = card
              Cardholder = cardholder
              Created = created
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
              Type = type'
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Transaction: string
        }

    type RetrieveOptions with
        static member New(transaction: string, ?expand: string list) =
            {
                Transaction = transaction
                Expand = expand
            }

    module RetrieveOptions =
        let create
            (
                transaction: string
            ) : RetrieveOptions
            =
            {
              Transaction = transaction
              Expand = None
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Transaction: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
        }

    type UpdateOptions with
        static member New(transaction: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Transaction = transaction
                Expand = expand
                Metadata = metadata
            }

    module UpdateOptions =
        let create
            (
                transaction: string
            ) : UpdateOptions
            =
            {
              Transaction = transaction
              Expand = None
              Metadata = None
            }

    ///<p>Returns a list of Issuing <code>Transaction</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("card", options.Card |> box); ("cardholder", options.Cardholder |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("type", options.Type |> box)] |> Map.ofList
        $"/v1/issuing/transactions"
        |> RestApi.getAsync<StripeList<IssuingTransaction>> settings qs

    ///<p>Retrieves an Issuing <code>Transaction</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/issuing/transactions/{options.Transaction}"
        |> RestApi.getAsync<IssuingTransaction> settings qs

    ///<p>Updates the specified Issuing <code>Transaction</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/issuing/transactions/{options.Transaction}"
        |> RestApi.postAsync<_, IssuingTransaction> settings (Map.empty) options

