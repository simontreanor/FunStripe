namespace FunStripe.StripeRequest

open FunStripe
open FunStripe.Json
open FunStripe.StripeModel
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module IssuingAuthorizations =

    type ListOptions = {
        ///<summary>Only return authorizations that belong to the given card.</summary>
        [<Config.Query>]Card: string option
        ///<summary>Only return authorizations that belong to the given cardholder.</summary>
        [<Config.Query>]Cardholder: string option
        ///<summary>Only return authorizations that were created during the given date interval.</summary>
        [<Config.Query>]Created: int option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Only return authorizations with the given status. One of `pending`, `closed`, or `reversed`.</summary>
        [<Config.Query>]Status: string option
    }
    with
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

    ///<summary><p>Returns a list of Issuing <code>Authorization</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("card", options.Card |> box); ("cardholder", options.Cardholder |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/issuing/authorizations"
        |> RestApi.getAsync<StripeList<IssuingAuthorization>> settings qs

    type RetrieveOptions = {
        [<Config.Path>]Authorization: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(authorization: string, ?expand: string list) =
            {
                Authorization = authorization
                Expand = expand
            }

    ///<summary><p>Retrieves an Issuing <code>Authorization</code> object.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/issuing/authorizations/{options.Authorization}"
        |> RestApi.getAsync<IssuingAuthorization> settings qs

    type UpdateOptions = {
        [<Config.Path>]Authorization: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(authorization: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Authorization = authorization
                Expand = expand
                Metadata = metadata
            }

    ///<summary><p>Updates the specified Issuing <code>Authorization</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/issuing/authorizations/{options.Authorization}"
        |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) options

module IssuingAuthorizationsApprove =

    type ApproveOptions = {
        [<Config.Path>]Authorization: string
        ///<summary>If the authorization's `pending_request.is_amount_controllable` property is `true`, you may provide this value to control how much to hold for the authorization. Must be positive (use [`decline`](https://docs.stripe.com/api/issuing/authorizations/decline) to decline an authorization request).</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(authorization: string, ?amount: int, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Authorization = authorization
                Amount = amount
                Expand = expand
                Metadata = metadata
            }

    ///<summary><p>[Deprecated] Approves a pending Issuing <code>Authorization</code> object. This request should be made within the timeout window of the <a href="/docs/issuing/controls/real-time-authorizations">real-time authorization</a> flow. 
    ///This method is deprecated. Instead, <a href="/docs/issuing/controls/real-time-authorizations#authorization-handling">respond directly to the webhook request to approve an authorization</a>.</p></summary>
    let Approve settings (options: ApproveOptions) =
        $"/v1/issuing/authorizations/{options.Authorization}/approve"
        |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) options

module IssuingAuthorizationsDecline =

    type DeclineOptions = {
        [<Config.Path>]Authorization: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(authorization: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Authorization = authorization
                Expand = expand
                Metadata = metadata
            }

    ///<summary><p>[Deprecated] Declines a pending Issuing <code>Authorization</code> object. This request should be made within the timeout window of the <a href="/docs/issuing/controls/real-time-authorizations">real time authorization</a> flow.
    ///This method is deprecated. Instead, <a href="/docs/issuing/controls/real-time-authorizations#authorization-handling">respond directly to the webhook request to decline an authorization</a>.</p></summary>
    let Decline settings (options: DeclineOptions) =
        $"/v1/issuing/authorizations/{options.Authorization}/decline"
        |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) options

module IssuingCardholders =

    type ListOptions = {
        ///<summary>Only return cardholders that were created during the given date interval.</summary>
        [<Config.Query>]Created: int option
        ///<summary>Only return cardholders that have the given email address.</summary>
        [<Config.Query>]Email: string option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>Only return cardholders that have the given phone number.</summary>
        [<Config.Query>]PhoneNumber: string option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Only return cardholders that have the given status. One of `active`, `inactive`, or `blocked`.</summary>
        [<Config.Query>]Status: string option
        ///<summary>Only return cardholders that have the given type. One of `individual` or `company`.</summary>
        [<Config.Query>]Type: string option
    }
    with
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

    ///<summary><p>Returns a list of Issuing <code>Cardholder</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("email", options.Email |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("phone_number", options.PhoneNumber |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("type", options.Type |> box)] |> Map.ofList
        $"/v1/issuing/cardholders"
        |> RestApi.getAsync<StripeList<IssuingCardholder>> settings qs

    type Create'BillingAddress = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'Billing = {
        ///<summary>The cardholder’s billing address.</summary>
        [<Config.Form>]Address: Create'BillingAddress option
    }
    with
        static member New(?address: Create'BillingAddress) =
            {
                Address = address
            }

    type Create'Company = {
        ///<summary>The entity's business ID number.</summary>
        [<Config.Form>]TaxId: string option
    }
    with
        static member New(?taxId: string) =
            {
                TaxId = taxId
            }

    type Create'IndividualCardIssuingUserTermsAcceptance = {
        ///<summary>The Unix timestamp marking when the cardholder accepted the Authorized User Terms.</summary>
        [<Config.Form>]Date: DateTime option
        ///<summary>The IP address from which the cardholder accepted the Authorized User Terms.</summary>
        [<Config.Form>]Ip: string option
        ///<summary>The user agent of the browser from which the cardholder accepted the Authorized User Terms.</summary>
        [<Config.Form>]UserAgent: Choice<string,string> option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?userAgent: Choice<string,string>) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Create'IndividualCardIssuing = {
        ///<summary>Information about cardholder acceptance of Celtic [Authorized User Terms](https://stripe.com/docs/issuing/cards#accept-authorized-user-terms). Required for cards backed by a Celtic program.</summary>
        [<Config.Form>]UserTermsAcceptance: Create'IndividualCardIssuingUserTermsAcceptance option
    }
    with
        static member New(?userTermsAcceptance: Create'IndividualCardIssuingUserTermsAcceptance) =
            {
                UserTermsAcceptance = userTermsAcceptance
            }

    type Create'IndividualDob = {
        ///<summary>The day of birth, between 1 and 31.</summary>
        [<Config.Form>]Day: int option
        ///<summary>The month of birth, between 1 and 12.</summary>
        [<Config.Form>]Month: int option
        ///<summary>The four-digit year of birth.</summary>
        [<Config.Form>]Year: int option
    }
    with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Create'IndividualVerificationDocument = {
        ///<summary>The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`.</summary>
        [<Config.Form>]Back: string option
        ///<summary>The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`.</summary>
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Create'IndividualVerification = {
        ///<summary>An identifying document, either a passport or local ID card.</summary>
        [<Config.Form>]Document: Create'IndividualVerificationDocument option
    }
    with
        static member New(?document: Create'IndividualVerificationDocument) =
            {
                Document = document
            }

    type Create'Individual = {
        ///<summary>Information related to the card_issuing program for this cardholder.</summary>
        [<Config.Form>]CardIssuing: Create'IndividualCardIssuing option
        ///<summary>The date of birth of this cardholder. Cardholders must be older than 13 years old.</summary>
        [<Config.Form>]Dob: Create'IndividualDob option
        ///<summary>The first name of this cardholder. Required before activating Cards. This field cannot contain any numbers, special characters (except periods, commas, hyphens, spaces and apostrophes) or non-latin letters.</summary>
        [<Config.Form>]FirstName: string option
        ///<summary>The last name of this cardholder. Required before activating Cards. This field cannot contain any numbers, special characters (except periods, commas, hyphens, spaces and apostrophes) or non-latin letters.</summary>
        [<Config.Form>]LastName: string option
        ///<summary>Government-issued ID document for this cardholder.</summary>
        [<Config.Form>]Verification: Create'IndividualVerification option
    }
    with
        static member New(?cardIssuing: Create'IndividualCardIssuing, ?dob: Create'IndividualDob, ?firstName: string, ?lastName: string, ?verification: Create'IndividualVerification) =
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

    type Create'SpendingControlsSpendingLimits = {
        ///<summary>Maximum amount allowed to spend per interval.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) this limit applies to. Omitting this field will apply the limit to all categories.</summary>
        [<Config.Form>]Categories: Create'SpendingControlsSpendingLimitsCategories list option
        ///<summary>Interval (or event) to which the amount applies.</summary>
        [<Config.Form>]Interval: Create'SpendingControlsSpendingLimitsInterval option
    }
    with
        static member New(?amount: int, ?categories: Create'SpendingControlsSpendingLimitsCategories list, ?interval: Create'SpendingControlsSpendingLimitsInterval) =
            {
                Amount = amount
                Categories = categories
                Interval = interval
            }

    type Create'SpendingControls = {
        ///<summary>Array of card presence statuses from which authorizations will be allowed. Possible options are `present`, `not_present`. All other statuses will be blocked. Cannot be set with `blocked_card_presences`. Provide an empty value to unset this control.</summary>
        [<Config.Form>]AllowedCardPresences: Create'SpendingControlsAllowedCardPresences list option
        ///<summary>Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) of authorizations to allow. All other categories will be blocked. Cannot be set with `blocked_categories`.</summary>
        [<Config.Form>]AllowedCategories: Create'SpendingControlsAllowedCategories list option
        ///<summary>Array of strings containing representing countries from which authorizations will be allowed. Authorizations from merchants in all other countries will be declined. Country codes should be ISO 3166 alpha-2 country codes (e.g. `US`). Cannot be set with `blocked_merchant_countries`. Provide an empty value to unset this control.</summary>
        [<Config.Form>]AllowedMerchantCountries: string list option
        ///<summary>Array of card presence statuses from which authorizations will be declined. Possible options are `present`, `not_present`. Cannot be set with `allowed_card_presences`. Provide an empty value to unset this control.</summary>
        [<Config.Form>]BlockedCardPresences: Create'SpendingControlsBlockedCardPresences list option
        ///<summary>Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) of authorizations to decline. All other categories will be allowed. Cannot be set with `allowed_categories`.</summary>
        [<Config.Form>]BlockedCategories: Create'SpendingControlsBlockedCategories list option
        ///<summary>Array of strings containing representing countries from which authorizations will be declined. Country codes should be ISO 3166 alpha-2 country codes (e.g. `US`). Cannot be set with `allowed_merchant_countries`. Provide an empty value to unset this control.</summary>
        [<Config.Form>]BlockedMerchantCountries: string list option
        ///<summary>Limit spending with amount-based rules that apply across this cardholder's cards.</summary>
        [<Config.Form>]SpendingLimits: Create'SpendingControlsSpendingLimits list option
        ///<summary>Currency of amounts within `spending_limits`. Defaults to your merchant country's currency.</summary>
        [<Config.Form>]SpendingLimitsCurrency: IsoTypes.IsoCurrencyCode option
    }
    with
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

    type Create'Status =
    | Active
    | Inactive

    type Create'Type =
    | Company
    | Individual

    type CreateOptions = {
        ///<summary>The cardholder's billing address.</summary>
        [<Config.Form>]Billing: Create'Billing
        ///<summary>Additional information about a `company` cardholder.</summary>
        [<Config.Form>]Company: Create'Company option
        ///<summary>The cardholder's email address.</summary>
        [<Config.Form>]Email: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Additional information about an `individual` cardholder.</summary>
        [<Config.Form>]Individual: Create'Individual option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The cardholder's name. This will be printed on cards issued to them. The maximum length of this field is 24 characters. This field cannot contain any special characters or numbers.</summary>
        [<Config.Form>]Name: string
        ///<summary>The cardholder's phone number. This will be transformed to [E.164](https://en.wikipedia.org/wiki/E.164) if it is not provided in that format already. This is required for all cardholders who will be creating EU cards. See the [3D Secure documentation](https://docs.stripe.com/issuing/3d-secure#when-is-3d-secure-applied) for more details.</summary>
        [<Config.Form>]PhoneNumber: string option
        ///<summary>The cardholder’s preferred locales (languages), ordered by preference. Locales can be `da`, `de`, `en`, `es`, `fr`, `it`, `pl`, or `sv`.
        /// This changes the language of the [3D Secure flow](https://docs.stripe.com/issuing/3d-secure) and one-time password messages sent to the cardholder.</summary>
        [<Config.Form>]PreferredLocales: Create'PreferredLocales list option
        ///<summary>Rules that control spending across this cardholder's cards. Refer to our [documentation](https://docs.stripe.com/issuing/controls/spending-controls) for more details.</summary>
        [<Config.Form>]SpendingControls: Create'SpendingControls option
        ///<summary>Specifies whether to permit authorizations on this cardholder's cards. Defaults to `active`.</summary>
        [<Config.Form>]Status: Create'Status option
        ///<summary>One of `individual` or `company`. See [Choose a cardholder type](https://docs.stripe.com/issuing/other/choose-cardholder) for more details.</summary>
        [<Config.Form>]Type: Create'Type option
    }
    with
        static member New(billing: Create'Billing, name: string, ?company: Create'Company, ?email: string, ?expand: string list, ?individual: Create'Individual, ?metadata: Map<string, string>, ?phoneNumber: string, ?preferredLocales: Create'PreferredLocales list, ?spendingControls: Create'SpendingControls, ?status: Create'Status, ?type': Create'Type) =
            {
                Billing = billing
                Company = company
                Email = email
                Expand = expand
                Individual = individual
                Metadata = metadata
                Name = name
                PhoneNumber = phoneNumber
                PreferredLocales = preferredLocales
                SpendingControls = spendingControls
                Status = status
                Type = type'
            }

    ///<summary><p>Creates a new Issuing <code>Cardholder</code> object that can be issued cards.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/issuing/cardholders"
        |> RestApi.postAsync<_, IssuingCardholder> settings (Map.empty) options

    type RetrieveOptions = {
        [<Config.Path>]Cardholder: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(cardholder: string, ?expand: string list) =
            {
                Cardholder = cardholder
                Expand = expand
            }

    ///<summary><p>Retrieves an Issuing <code>Cardholder</code> object.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/issuing/cardholders/{options.Cardholder}"
        |> RestApi.getAsync<IssuingCardholder> settings qs

    type Update'BillingAddress = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'Billing = {
        ///<summary>The cardholder’s billing address.</summary>
        [<Config.Form>]Address: Update'BillingAddress option
    }
    with
        static member New(?address: Update'BillingAddress) =
            {
                Address = address
            }

    type Update'Company = {
        ///<summary>The entity's business ID number.</summary>
        [<Config.Form>]TaxId: string option
    }
    with
        static member New(?taxId: string) =
            {
                TaxId = taxId
            }

    type Update'IndividualCardIssuingUserTermsAcceptance = {
        ///<summary>The Unix timestamp marking when the cardholder accepted the Authorized User Terms.</summary>
        [<Config.Form>]Date: DateTime option
        ///<summary>The IP address from which the cardholder accepted the Authorized User Terms.</summary>
        [<Config.Form>]Ip: string option
        ///<summary>The user agent of the browser from which the cardholder accepted the Authorized User Terms.</summary>
        [<Config.Form>]UserAgent: Choice<string,string> option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?userAgent: Choice<string,string>) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Update'IndividualCardIssuing = {
        ///<summary>Information about cardholder acceptance of Celtic [Authorized User Terms](https://stripe.com/docs/issuing/cards#accept-authorized-user-terms). Required for cards backed by a Celtic program.</summary>
        [<Config.Form>]UserTermsAcceptance: Update'IndividualCardIssuingUserTermsAcceptance option
    }
    with
        static member New(?userTermsAcceptance: Update'IndividualCardIssuingUserTermsAcceptance) =
            {
                UserTermsAcceptance = userTermsAcceptance
            }

    type Update'IndividualDob = {
        ///<summary>The day of birth, between 1 and 31.</summary>
        [<Config.Form>]Day: int option
        ///<summary>The month of birth, between 1 and 12.</summary>
        [<Config.Form>]Month: int option
        ///<summary>The four-digit year of birth.</summary>
        [<Config.Form>]Year: int option
    }
    with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Update'IndividualVerificationDocument = {
        ///<summary>The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`.</summary>
        [<Config.Form>]Back: string option
        ///<summary>The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`.</summary>
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Update'IndividualVerification = {
        ///<summary>An identifying document, either a passport or local ID card.</summary>
        [<Config.Form>]Document: Update'IndividualVerificationDocument option
    }
    with
        static member New(?document: Update'IndividualVerificationDocument) =
            {
                Document = document
            }

    type Update'Individual = {
        ///<summary>Information related to the card_issuing program for this cardholder.</summary>
        [<Config.Form>]CardIssuing: Update'IndividualCardIssuing option
        ///<summary>The date of birth of this cardholder. Cardholders must be older than 13 years old.</summary>
        [<Config.Form>]Dob: Update'IndividualDob option
        ///<summary>The first name of this cardholder. Required before activating Cards. This field cannot contain any numbers, special characters (except periods, commas, hyphens, spaces and apostrophes) or non-latin letters.</summary>
        [<Config.Form>]FirstName: string option
        ///<summary>The last name of this cardholder. Required before activating Cards. This field cannot contain any numbers, special characters (except periods, commas, hyphens, spaces and apostrophes) or non-latin letters.</summary>
        [<Config.Form>]LastName: string option
        ///<summary>Government-issued ID document for this cardholder.</summary>
        [<Config.Form>]Verification: Update'IndividualVerification option
    }
    with
        static member New(?cardIssuing: Update'IndividualCardIssuing, ?dob: Update'IndividualDob, ?firstName: string, ?lastName: string, ?verification: Update'IndividualVerification) =
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

    type Update'SpendingControlsSpendingLimits = {
        ///<summary>Maximum amount allowed to spend per interval.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) this limit applies to. Omitting this field will apply the limit to all categories.</summary>
        [<Config.Form>]Categories: Update'SpendingControlsSpendingLimitsCategories list option
        ///<summary>Interval (or event) to which the amount applies.</summary>
        [<Config.Form>]Interval: Update'SpendingControlsSpendingLimitsInterval option
    }
    with
        static member New(?amount: int, ?categories: Update'SpendingControlsSpendingLimitsCategories list, ?interval: Update'SpendingControlsSpendingLimitsInterval) =
            {
                Amount = amount
                Categories = categories
                Interval = interval
            }

    type Update'SpendingControls = {
        ///<summary>Array of card presence statuses from which authorizations will be allowed. Possible options are `present`, `not_present`. All other statuses will be blocked. Cannot be set with `blocked_card_presences`. Provide an empty value to unset this control.</summary>
        [<Config.Form>]AllowedCardPresences: Update'SpendingControlsAllowedCardPresences list option
        ///<summary>Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) of authorizations to allow. All other categories will be blocked. Cannot be set with `blocked_categories`.</summary>
        [<Config.Form>]AllowedCategories: Update'SpendingControlsAllowedCategories list option
        ///<summary>Array of strings containing representing countries from which authorizations will be allowed. Authorizations from merchants in all other countries will be declined. Country codes should be ISO 3166 alpha-2 country codes (e.g. `US`). Cannot be set with `blocked_merchant_countries`. Provide an empty value to unset this control.</summary>
        [<Config.Form>]AllowedMerchantCountries: string list option
        ///<summary>Array of card presence statuses from which authorizations will be declined. Possible options are `present`, `not_present`. Cannot be set with `allowed_card_presences`. Provide an empty value to unset this control.</summary>
        [<Config.Form>]BlockedCardPresences: Update'SpendingControlsBlockedCardPresences list option
        ///<summary>Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) of authorizations to decline. All other categories will be allowed. Cannot be set with `allowed_categories`.</summary>
        [<Config.Form>]BlockedCategories: Update'SpendingControlsBlockedCategories list option
        ///<summary>Array of strings containing representing countries from which authorizations will be declined. Country codes should be ISO 3166 alpha-2 country codes (e.g. `US`). Cannot be set with `allowed_merchant_countries`. Provide an empty value to unset this control.</summary>
        [<Config.Form>]BlockedMerchantCountries: string list option
        ///<summary>Limit spending with amount-based rules that apply across this cardholder's cards.</summary>
        [<Config.Form>]SpendingLimits: Update'SpendingControlsSpendingLimits list option
        ///<summary>Currency of amounts within `spending_limits`. Defaults to your merchant country's currency.</summary>
        [<Config.Form>]SpendingLimitsCurrency: IsoTypes.IsoCurrencyCode option
    }
    with
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

    type Update'Status =
    | Active
    | Inactive

    type UpdateOptions = {
        [<Config.Path>]Cardholder: string
        ///<summary>The cardholder's billing address.</summary>
        [<Config.Form>]Billing: Update'Billing option
        ///<summary>Additional information about a `company` cardholder.</summary>
        [<Config.Form>]Company: Update'Company option
        ///<summary>The cardholder's email address.</summary>
        [<Config.Form>]Email: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Additional information about an `individual` cardholder.</summary>
        [<Config.Form>]Individual: Update'Individual option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The cardholder's phone number. This is required for all cardholders who will be creating EU cards. See the [3D Secure documentation](https://docs.stripe.com/issuing/3d-secure) for more details.</summary>
        [<Config.Form>]PhoneNumber: string option
        ///<summary>The cardholder’s preferred locales (languages), ordered by preference. Locales can be `da`, `de`, `en`, `es`, `fr`, `it`, `pl`, or `sv`.
        /// This changes the language of the [3D Secure flow](https://docs.stripe.com/issuing/3d-secure) and one-time password messages sent to the cardholder.</summary>
        [<Config.Form>]PreferredLocales: Update'PreferredLocales list option
        ///<summary>Rules that control spending across this cardholder's cards. Refer to our [documentation](https://docs.stripe.com/issuing/controls/spending-controls) for more details.</summary>
        [<Config.Form>]SpendingControls: Update'SpendingControls option
        ///<summary>Specifies whether to permit authorizations on this cardholder's cards.</summary>
        [<Config.Form>]Status: Update'Status option
    }
    with
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

    ///<summary><p>Updates the specified Issuing <code>Cardholder</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/issuing/cardholders/{options.Cardholder}"
        |> RestApi.postAsync<_, IssuingCardholder> settings (Map.empty) options

module IssuingCards =

    type ListOptions = {
        ///<summary>Only return cards belonging to the Cardholder with the provided ID.</summary>
        [<Config.Query>]Cardholder: string option
        ///<summary>Only return cards that were issued during the given date interval.</summary>
        [<Config.Query>]Created: int option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Only return cards that have the given expiration month.</summary>
        [<Config.Query>]ExpMonth: int option
        ///<summary>Only return cards that have the given expiration year.</summary>
        [<Config.Query>]ExpYear: int option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>Only return cards that have the given last four digits.</summary>
        [<Config.Query>]Last4: string option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        [<Config.Query>]PersonalizationDesign: string option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Only return cards that have the given status. One of `active`, `inactive`, or `canceled`.</summary>
        [<Config.Query>]Status: string option
        ///<summary>Only return cards that have the given type. One of `virtual` or `physical`.</summary>
        [<Config.Query>]Type: string option
    }
    with
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

    ///<summary><p>Returns a list of Issuing <code>Card</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("cardholder", options.Cardholder |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("exp_month", options.ExpMonth |> box); ("exp_year", options.ExpYear |> box); ("expand", options.Expand |> box); ("last4", options.Last4 |> box); ("limit", options.Limit |> box); ("personalization_design", options.PersonalizationDesign |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("type", options.Type |> box)] |> Map.ofList
        $"/v1/issuing/cards"
        |> RestApi.getAsync<StripeList<IssuingCard>> settings qs

    type Create'LifecycleControlsCancelAfter = {
        ///<summary>The card is automatically cancelled when it makes this number of non-zero payment authorizations and transactions. The count includes penny authorizations, but doesn't include non-payment actions, such as authorization advice.</summary>
        [<Config.Form>]PaymentCount: int option
    }
    with
        static member New(?paymentCount: int) =
            {
                PaymentCount = paymentCount
            }

    type Create'LifecycleControls = {
        ///<summary>Cancels the card after the specified conditions are met.</summary>
        [<Config.Form>]CancelAfter: Create'LifecycleControlsCancelAfter option
    }
    with
        static member New(?cancelAfter: Create'LifecycleControlsCancelAfter) =
            {
                CancelAfter = cancelAfter
            }

    type Create'Pin = {
        ///<summary>The card's desired new PIN, encrypted under Stripe's public key.</summary>
        [<Config.Form>]EncryptedNumber: string option
    }
    with
        static member New(?encryptedNumber: string) =
            {
                EncryptedNumber = encryptedNumber
            }

    type Create'ShippingAddress = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
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

    type Create'ShippingAddressValidation = {
        ///<summary>The address validation capabilities to use.</summary>
        [<Config.Form>]Mode: Create'ShippingAddressValidationMode option
    }
    with
        static member New(?mode: Create'ShippingAddressValidationMode) =
            {
                Mode = mode
            }

    type Create'ShippingCustoms = {
        ///<summary>The Economic Operators Registration and Identification (EORI) number to use for Customs. Required for bulk shipments to Europe.</summary>
        [<Config.Form>]EoriNumber: string option
    }
    with
        static member New(?eoriNumber: string) =
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

    type Create'Shipping = {
        ///<summary>The address that the card is shipped to.</summary>
        [<Config.Form>]Address: Create'ShippingAddress option
        ///<summary>Address validation settings.</summary>
        [<Config.Form>]AddressValidation: Create'ShippingAddressValidation option
        ///<summary>Customs information for the shipment.</summary>
        [<Config.Form>]Customs: Create'ShippingCustoms option
        ///<summary>The name printed on the shipping label when shipping the card.</summary>
        [<Config.Form>]Name: string option
        ///<summary>Phone number of the recipient of the shipment.</summary>
        [<Config.Form>]PhoneNumber: string option
        ///<summary>Whether a signature is required for card delivery.</summary>
        [<Config.Form>]RequireSignature: bool option
        ///<summary>Shipment service.</summary>
        [<Config.Form>]Service: Create'ShippingService option
        ///<summary>Packaging options.</summary>
        [<Config.Form>]Type: Create'ShippingType option
    }
    with
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

    type Create'SpendingControlsSpendingLimits = {
        ///<summary>Maximum amount allowed to spend per interval.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) this limit applies to. Omitting this field will apply the limit to all categories.</summary>
        [<Config.Form>]Categories: Create'SpendingControlsSpendingLimitsCategories list option
        ///<summary>Interval (or event) to which the amount applies.</summary>
        [<Config.Form>]Interval: Create'SpendingControlsSpendingLimitsInterval option
    }
    with
        static member New(?amount: int, ?categories: Create'SpendingControlsSpendingLimitsCategories list, ?interval: Create'SpendingControlsSpendingLimitsInterval) =
            {
                Amount = amount
                Categories = categories
                Interval = interval
            }

    type Create'SpendingControls = {
        ///<summary>Array of card presence statuses from which authorizations will be allowed. Possible options are `present`, `not_present`. All other statuses will be blocked. Cannot be set with `blocked_card_presences`. Provide an empty value to unset this control.</summary>
        [<Config.Form>]AllowedCardPresences: Create'SpendingControlsAllowedCardPresences list option
        ///<summary>Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) of authorizations to allow. All other categories will be blocked. Cannot be set with `blocked_categories`.</summary>
        [<Config.Form>]AllowedCategories: Create'SpendingControlsAllowedCategories list option
        ///<summary>Array of strings containing representing countries from which authorizations will be allowed. Authorizations from merchants in all other countries will be declined. Country codes should be ISO 3166 alpha-2 country codes (e.g. `US`). Cannot be set with `blocked_merchant_countries`. Provide an empty value to unset this control.</summary>
        [<Config.Form>]AllowedMerchantCountries: string list option
        ///<summary>Array of card presence statuses from which authorizations will be declined. Possible options are `present`, `not_present`. Cannot be set with `allowed_card_presences`. Provide an empty value to unset this control.</summary>
        [<Config.Form>]BlockedCardPresences: Create'SpendingControlsBlockedCardPresences list option
        ///<summary>Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) of authorizations to decline. All other categories will be allowed. Cannot be set with `allowed_categories`.</summary>
        [<Config.Form>]BlockedCategories: Create'SpendingControlsBlockedCategories list option
        ///<summary>Array of strings containing representing countries from which authorizations will be declined. Country codes should be ISO 3166 alpha-2 country codes (e.g. `US`). Cannot be set with `allowed_merchant_countries`. Provide an empty value to unset this control.</summary>
        [<Config.Form>]BlockedMerchantCountries: string list option
        ///<summary>Limit spending with amount-based rules that apply across any cards this card replaced (i.e., its `replacement_for` card and _that_ card's `replacement_for` card, up the chain).</summary>
        [<Config.Form>]SpendingLimits: Create'SpendingControlsSpendingLimits list option
    }
    with
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

    type Create'ReplacementReason =
    | Damaged
    | Expired
    | Lost
    | Stolen

    type Create'Status =
    | Active
    | Inactive

    type Create'Type =
    | Physical
    | Virtual

    type CreateOptions = {
        ///<summary>The [Cardholder](https://docs.stripe.com/api#issuing_cardholder_object) object with which the card will be associated.</summary>
        [<Config.Form>]Cardholder: string option
        ///<summary>The currency for the card.</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode
        ///<summary>The desired expiration month (1-12) for this card if [specifying a custom expiration date](/issuing/cards/virtual/issue-cards?testing-method=with-code#exp-dates).</summary>
        [<Config.Form>]ExpMonth: int option
        ///<summary>The desired 4-digit expiration year for this card if [specifying a custom expiration date](/issuing/cards/virtual/issue-cards?testing-method=with-code#exp-dates).</summary>
        [<Config.Form>]ExpYear: int option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The new financial account ID the card will be associated with. This field allows a card to be reassigned to a different financial account.</summary>
        [<Config.Form>]FinancialAccount: string option
        ///<summary>Rules that control the lifecycle of this card, such as automatic cancellation. Refer to our [documentation](/issuing/controls/lifecycle-controls) for more details.</summary>
        [<Config.Form>]LifecycleControls: Create'LifecycleControls option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The personalization design object belonging to this card.</summary>
        [<Config.Form>]PersonalizationDesign: string option
        ///<summary>The desired PIN for this card.</summary>
        [<Config.Form>]Pin: Create'Pin option
        ///<summary>The card this is meant to be a replacement for (if any).</summary>
        [<Config.Form>]ReplacementFor: string option
        ///<summary>If `replacement_for` is specified, this should indicate why that card is being replaced.</summary>
        [<Config.Form>]ReplacementReason: Create'ReplacementReason option
        ///<summary>The second line to print on the card. Max length: 24 characters.</summary>
        [<Config.Form>]SecondLine: Choice<string,string> option
        ///<summary>The address where the card will be shipped.</summary>
        [<Config.Form>]Shipping: Create'Shipping option
        ///<summary>Rules that control spending for this card. Refer to our [documentation](https://docs.stripe.com/issuing/controls/spending-controls) for more details.</summary>
        [<Config.Form>]SpendingControls: Create'SpendingControls option
        ///<summary>Whether authorizations can be approved on this card. May be blocked from activating cards depending on past-due Cardholder requirements. Defaults to `inactive`.</summary>
        [<Config.Form>]Status: Create'Status option
        ///<summary>The type of card to issue. Possible values are `physical` or `virtual`.</summary>
        [<Config.Form>]Type: Create'Type
    }
    with
        static member New(type': Create'Type, currency: IsoTypes.IsoCurrencyCode, ?spendingControls: Create'SpendingControls, ?shipping: Create'Shipping, ?secondLine: Choice<string,string>, ?replacementReason: Create'ReplacementReason, ?replacementFor: string, ?pin: Create'Pin, ?personalizationDesign: string, ?metadata: Map<string, string>, ?lifecycleControls: Create'LifecycleControls, ?financialAccount: string, ?expand: string list, ?expYear: int, ?expMonth: int, ?status: Create'Status, ?cardholder: string) =
            {
                Cardholder = cardholder
                Currency = currency
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
                Type = type'
            }

    ///<summary><p>Creates an Issuing <code>Card</code> object.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/issuing/cards"
        |> RestApi.postAsync<_, IssuingCard> settings (Map.empty) options

    type RetrieveOptions = {
        [<Config.Path>]Card: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(card: string, ?expand: string list) =
            {
                Card = card
                Expand = expand
            }

    ///<summary><p>Retrieves an Issuing <code>Card</code> object.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/issuing/cards/{options.Card}"
        |> RestApi.getAsync<IssuingCard> settings qs

    type Update'Pin = {
        ///<summary>The card's desired new PIN, encrypted under Stripe's public key.</summary>
        [<Config.Form>]EncryptedNumber: string option
    }
    with
        static member New(?encryptedNumber: string) =
            {
                EncryptedNumber = encryptedNumber
            }

    type Update'ShippingAddress = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
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

    type Update'ShippingAddressValidation = {
        ///<summary>The address validation capabilities to use.</summary>
        [<Config.Form>]Mode: Update'ShippingAddressValidationMode option
    }
    with
        static member New(?mode: Update'ShippingAddressValidationMode) =
            {
                Mode = mode
            }

    type Update'ShippingCustoms = {
        ///<summary>The Economic Operators Registration and Identification (EORI) number to use for Customs. Required for bulk shipments to Europe.</summary>
        [<Config.Form>]EoriNumber: string option
    }
    with
        static member New(?eoriNumber: string) =
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

    type Update'Shipping = {
        ///<summary>The address that the card is shipped to.</summary>
        [<Config.Form>]Address: Update'ShippingAddress option
        ///<summary>Address validation settings.</summary>
        [<Config.Form>]AddressValidation: Update'ShippingAddressValidation option
        ///<summary>Customs information for the shipment.</summary>
        [<Config.Form>]Customs: Update'ShippingCustoms option
        ///<summary>The name printed on the shipping label when shipping the card.</summary>
        [<Config.Form>]Name: string option
        ///<summary>Phone number of the recipient of the shipment.</summary>
        [<Config.Form>]PhoneNumber: string option
        ///<summary>Whether a signature is required for card delivery.</summary>
        [<Config.Form>]RequireSignature: bool option
        ///<summary>Shipment service.</summary>
        [<Config.Form>]Service: Update'ShippingService option
        ///<summary>Packaging options.</summary>
        [<Config.Form>]Type: Update'ShippingType option
    }
    with
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

    type Update'SpendingControlsSpendingLimits = {
        ///<summary>Maximum amount allowed to spend per interval.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) this limit applies to. Omitting this field will apply the limit to all categories.</summary>
        [<Config.Form>]Categories: Update'SpendingControlsSpendingLimitsCategories list option
        ///<summary>Interval (or event) to which the amount applies.</summary>
        [<Config.Form>]Interval: Update'SpendingControlsSpendingLimitsInterval option
    }
    with
        static member New(?amount: int, ?categories: Update'SpendingControlsSpendingLimitsCategories list, ?interval: Update'SpendingControlsSpendingLimitsInterval) =
            {
                Amount = amount
                Categories = categories
                Interval = interval
            }

    type Update'SpendingControls = {
        ///<summary>Array of card presence statuses from which authorizations will be allowed. Possible options are `present`, `not_present`. All other statuses will be blocked. Cannot be set with `blocked_card_presences`. Provide an empty value to unset this control.</summary>
        [<Config.Form>]AllowedCardPresences: Update'SpendingControlsAllowedCardPresences list option
        ///<summary>Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) of authorizations to allow. All other categories will be blocked. Cannot be set with `blocked_categories`.</summary>
        [<Config.Form>]AllowedCategories: Update'SpendingControlsAllowedCategories list option
        ///<summary>Array of strings containing representing countries from which authorizations will be allowed. Authorizations from merchants in all other countries will be declined. Country codes should be ISO 3166 alpha-2 country codes (e.g. `US`). Cannot be set with `blocked_merchant_countries`. Provide an empty value to unset this control.</summary>
        [<Config.Form>]AllowedMerchantCountries: string list option
        ///<summary>Array of card presence statuses from which authorizations will be declined. Possible options are `present`, `not_present`. Cannot be set with `allowed_card_presences`. Provide an empty value to unset this control.</summary>
        [<Config.Form>]BlockedCardPresences: Update'SpendingControlsBlockedCardPresences list option
        ///<summary>Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) of authorizations to decline. All other categories will be allowed. Cannot be set with `allowed_categories`.</summary>
        [<Config.Form>]BlockedCategories: Update'SpendingControlsBlockedCategories list option
        ///<summary>Array of strings containing representing countries from which authorizations will be declined. Country codes should be ISO 3166 alpha-2 country codes (e.g. `US`). Cannot be set with `allowed_merchant_countries`. Provide an empty value to unset this control.</summary>
        [<Config.Form>]BlockedMerchantCountries: string list option
        ///<summary>Limit spending with amount-based rules that apply across any cards this card replaced (i.e., its `replacement_for` card and _that_ card's `replacement_for` card, up the chain).</summary>
        [<Config.Form>]SpendingLimits: Update'SpendingControlsSpendingLimits list option
    }
    with
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

    type Update'CancellationReason =
    | Lost
    | Stolen

    type Update'Status =
    | Active
    | Canceled
    | Inactive

    type UpdateOptions = {
        [<Config.Path>]Card: string
        ///<summary>Reason why the `status` of this card is `canceled`.</summary>
        [<Config.Form>]CancellationReason: Update'CancellationReason option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        [<Config.Form>]PersonalizationDesign: string option
        ///<summary>The desired new PIN for this card.</summary>
        [<Config.Form>]Pin: Update'Pin option
        ///<summary>Updated shipping information for the card.</summary>
        [<Config.Form>]Shipping: Update'Shipping option
        ///<summary>Rules that control spending for this card. Refer to our [documentation](https://docs.stripe.com/issuing/controls/spending-controls) for more details.</summary>
        [<Config.Form>]SpendingControls: Update'SpendingControls option
        ///<summary>Dictates whether authorizations can be approved on this card. May be blocked from activating cards depending on past-due Cardholder requirements. Defaults to `inactive`. If this card is being canceled because it was lost or stolen, this information should be provided as `cancellation_reason`.</summary>
        [<Config.Form>]Status: Update'Status option
    }
    with
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

    ///<summary><p>Updates the specified Issuing <code>Card</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/issuing/cards/{options.Card}"
        |> RestApi.postAsync<_, IssuingCard> settings (Map.empty) options

module IssuingDisputes =

    type ListOptions = {
        ///<summary>Only return Issuing disputes that were created during the given date interval.</summary>
        [<Config.Query>]Created: int option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Select Issuing disputes with the given status.</summary>
        [<Config.Query>]Status: string option
        ///<summary>Select the Issuing dispute for the given transaction.</summary>
        [<Config.Query>]Transaction: string option
    }
    with
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

    ///<summary><p>Returns a list of Issuing <code>Dispute</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("transaction", options.Transaction |> box)] |> Map.ofList
        $"/v1/issuing/disputes"
        |> RestApi.getAsync<StripeList<IssuingDispute>> settings qs

    type Create'EvidenceCanceledCanceledProductType =
    | Merchandise
    | Service

    type Create'EvidenceCanceledCanceledReturnStatus =
    | MerchantRejected
    | Successful

    type Create'EvidenceCanceledCanceled = {
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.</summary>
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///<summary>Date when order was canceled.</summary>
        [<Config.Form>]CanceledAt: Choice<DateTime,string> option
        ///<summary>Whether the cardholder was provided with a cancellation policy.</summary>
        [<Config.Form>]CancellationPolicyProvided: Choice<bool,string> option
        ///<summary>Reason for canceling the order.</summary>
        [<Config.Form>]CancellationReason: Choice<string,string> option
        ///<summary>Date when the cardholder expected to receive the product.</summary>
        [<Config.Form>]ExpectedAt: Choice<DateTime,string> option
        ///<summary>Explanation of why the cardholder is disputing this transaction.</summary>
        [<Config.Form>]Explanation: Choice<string,string> option
        ///<summary>Description of the merchandise or service that was purchased.</summary>
        [<Config.Form>]ProductDescription: Choice<string,string> option
        ///<summary>Whether the product was a merchandise or service.</summary>
        [<Config.Form>]ProductType: Create'EvidenceCanceledCanceledProductType option
        ///<summary>Result of cardholder's attempt to return the product.</summary>
        [<Config.Form>]ReturnStatus: Create'EvidenceCanceledCanceledReturnStatus option
        ///<summary>Date when the product was returned or attempted to be returned.</summary>
        [<Config.Form>]ReturnedAt: Choice<DateTime,string> option
    }
    with
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

    type Create'EvidenceDuplicateDuplicate = {
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.</summary>
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Copy of the card statement showing that the product had already been paid for.</summary>
        [<Config.Form>]CardStatement: Choice<string,string> option
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Copy of the receipt showing that the product had been paid for in cash.</summary>
        [<Config.Form>]CashReceipt: Choice<string,string> option
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Image of the front and back of the check that was used to pay for the product.</summary>
        [<Config.Form>]CheckImage: Choice<string,string> option
        ///<summary>Explanation of why the cardholder is disputing this transaction.</summary>
        [<Config.Form>]Explanation: Choice<string,string> option
        ///<summary>Transaction (e.g., ipi_...) that the disputed transaction is a duplicate of. Of the two or more transactions that are copies of each other, this is original undisputed one.</summary>
        [<Config.Form>]OriginalTransaction: string option
    }
    with
        static member New(?additionalDocumentation: Choice<string,string>, ?cardStatement: Choice<string,string>, ?cashReceipt: Choice<string,string>, ?checkImage: Choice<string,string>, ?explanation: Choice<string,string>, ?originalTransaction: string) =
            {
                AdditionalDocumentation = additionalDocumentation
                CardStatement = cardStatement
                CashReceipt = cashReceipt
                CheckImage = checkImage
                Explanation = explanation
                OriginalTransaction = originalTransaction
            }

    type Create'EvidenceFraudulentFraudulent = {
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.</summary>
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///<summary>Explanation of why the cardholder is disputing this transaction.</summary>
        [<Config.Form>]Explanation: Choice<string,string> option
    }
    with
        static member New(?additionalDocumentation: Choice<string,string>, ?explanation: Choice<string,string>) =
            {
                AdditionalDocumentation = additionalDocumentation
                Explanation = explanation
            }

    type Create'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus =
    | MerchantRejected
    | Successful

    type Create'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed = {
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.</summary>
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///<summary>Explanation of why the cardholder is disputing this transaction.</summary>
        [<Config.Form>]Explanation: Choice<string,string> option
        ///<summary>Date when the product was received.</summary>
        [<Config.Form>]ReceivedAt: Choice<DateTime,string> option
        ///<summary>Description of the cardholder's attempt to return the product.</summary>
        [<Config.Form>]ReturnDescription: Choice<string,string> option
        ///<summary>Result of cardholder's attempt to return the product.</summary>
        [<Config.Form>]ReturnStatus: Create'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus option
        ///<summary>Date when the product was returned or attempted to be returned.</summary>
        [<Config.Form>]ReturnedAt: Choice<DateTime,string> option
    }
    with
        static member New(?additionalDocumentation: Choice<string,string>, ?explanation: Choice<string,string>, ?receivedAt: Choice<DateTime,string>, ?returnDescription: Choice<string,string>, ?returnStatus: Create'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus, ?returnedAt: Choice<DateTime,string>) =
            {
                AdditionalDocumentation = additionalDocumentation
                Explanation = explanation
                ReceivedAt = receivedAt
                ReturnDescription = returnDescription
                ReturnStatus = returnStatus
                ReturnedAt = returnedAt
            }

    type Create'EvidenceNoValidAuthorizationNoValidAuthorization = {
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.</summary>
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///<summary>Explanation of why the cardholder is disputing this transaction.</summary>
        [<Config.Form>]Explanation: Choice<string,string> option
    }
    with
        static member New(?additionalDocumentation: Choice<string,string>, ?explanation: Choice<string,string>) =
            {
                AdditionalDocumentation = additionalDocumentation
                Explanation = explanation
            }

    type Create'EvidenceNotReceivedNotReceivedProductType =
    | Merchandise
    | Service

    type Create'EvidenceNotReceivedNotReceived = {
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.</summary>
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///<summary>Date when the cardholder expected to receive the product.</summary>
        [<Config.Form>]ExpectedAt: Choice<DateTime,string> option
        ///<summary>Explanation of why the cardholder is disputing this transaction.</summary>
        [<Config.Form>]Explanation: Choice<string,string> option
        ///<summary>Description of the merchandise or service that was purchased.</summary>
        [<Config.Form>]ProductDescription: Choice<string,string> option
        ///<summary>Whether the product was a merchandise or service.</summary>
        [<Config.Form>]ProductType: Create'EvidenceNotReceivedNotReceivedProductType option
    }
    with
        static member New(?additionalDocumentation: Choice<string,string>, ?expectedAt: Choice<DateTime,string>, ?explanation: Choice<string,string>, ?productDescription: Choice<string,string>, ?productType: Create'EvidenceNotReceivedNotReceivedProductType) =
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

    type Create'EvidenceOtherOther = {
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.</summary>
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///<summary>Explanation of why the cardholder is disputing this transaction.</summary>
        [<Config.Form>]Explanation: Choice<string,string> option
        ///<summary>Description of the merchandise or service that was purchased.</summary>
        [<Config.Form>]ProductDescription: Choice<string,string> option
        ///<summary>Whether the product was a merchandise or service.</summary>
        [<Config.Form>]ProductType: Create'EvidenceOtherOtherProductType option
    }
    with
        static member New(?additionalDocumentation: Choice<string,string>, ?explanation: Choice<string,string>, ?productDescription: Choice<string,string>, ?productType: Create'EvidenceOtherOtherProductType) =
            {
                AdditionalDocumentation = additionalDocumentation
                Explanation = explanation
                ProductDescription = productDescription
                ProductType = productType
            }

    type Create'EvidenceServiceNotAsDescribedServiceNotAsDescribed = {
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.</summary>
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///<summary>Date when order was canceled.</summary>
        [<Config.Form>]CanceledAt: Choice<DateTime,string> option
        ///<summary>Reason for canceling the order.</summary>
        [<Config.Form>]CancellationReason: Choice<string,string> option
        ///<summary>Explanation of why the cardholder is disputing this transaction.</summary>
        [<Config.Form>]Explanation: Choice<string,string> option
        ///<summary>Date when the product was received.</summary>
        [<Config.Form>]ReceivedAt: Choice<DateTime,string> option
    }
    with
        static member New(?additionalDocumentation: Choice<string,string>, ?canceledAt: Choice<DateTime,string>, ?cancellationReason: Choice<string,string>, ?explanation: Choice<string,string>, ?receivedAt: Choice<DateTime,string>) =
            {
                AdditionalDocumentation = additionalDocumentation
                CanceledAt = canceledAt
                CancellationReason = cancellationReason
                Explanation = explanation
                ReceivedAt = receivedAt
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

    type Create'Evidence = {
        ///<summary>Evidence provided when `reason` is 'canceled'.</summary>
        [<Config.Form>]Canceled: Choice<Create'EvidenceCanceledCanceled,string> option
        ///<summary>Evidence provided when `reason` is 'duplicate'.</summary>
        [<Config.Form>]Duplicate: Choice<Create'EvidenceDuplicateDuplicate,string> option
        ///<summary>Evidence provided when `reason` is 'fraudulent'.</summary>
        [<Config.Form>]Fraudulent: Choice<Create'EvidenceFraudulentFraudulent,string> option
        ///<summary>Evidence provided when `reason` is 'merchandise_not_as_described'.</summary>
        [<Config.Form>]MerchandiseNotAsDescribed: Choice<Create'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed,string> option
        ///<summary>Evidence provided when `reason` is 'no_valid_authorization'.</summary>
        [<Config.Form>]NoValidAuthorization: Choice<Create'EvidenceNoValidAuthorizationNoValidAuthorization,string> option
        ///<summary>Evidence provided when `reason` is 'not_received'.</summary>
        [<Config.Form>]NotReceived: Choice<Create'EvidenceNotReceivedNotReceived,string> option
        ///<summary>Evidence provided when `reason` is 'other'.</summary>
        [<Config.Form>]Other: Choice<Create'EvidenceOtherOther,string> option
        ///<summary>The reason for filing the dispute. The evidence should be submitted in the field of the same name.</summary>
        [<Config.Form>]Reason: Create'EvidenceReason option
        ///<summary>Evidence provided when `reason` is 'service_not_as_described'.</summary>
        [<Config.Form>]ServiceNotAsDescribed: Choice<Create'EvidenceServiceNotAsDescribedServiceNotAsDescribed,string> option
    }
    with
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

    type Create'Treasury = {
        ///<summary>The ID of the ReceivedDebit to initiate an Issuings dispute for.</summary>
        [<Config.Form>]ReceivedDebit: string option
    }
    with
        static member New(?receivedDebit: string) =
            {
                ReceivedDebit = receivedDebit
            }

    type CreateOptions = {
        ///<summary>The dispute amount in the card's currency and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal). If not set, defaults to the full transaction amount.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Evidence provided for the dispute.</summary>
        [<Config.Form>]Evidence: Create'Evidence option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The ID of the issuing transaction to create a dispute for. For transaction on Treasury FinancialAccounts, use `treasury.received_debit`.</summary>
        [<Config.Form>]Transaction: string option
        ///<summary>Params for disputes related to Treasury FinancialAccounts</summary>
        [<Config.Form>]Treasury: Create'Treasury option
    }
    with
        static member New(?amount: int, ?evidence: Create'Evidence, ?expand: string list, ?metadata: Map<string, string>, ?transaction: string, ?treasury: Create'Treasury) =
            {
                Amount = amount
                Evidence = evidence
                Expand = expand
                Metadata = metadata
                Transaction = transaction
                Treasury = treasury
            }

    ///<summary><p>Creates an Issuing <code>Dispute</code> object. Individual pieces of evidence within the <code>evidence</code> object are optional at this point. Stripe only validates that required evidence is present during submission. Refer to <a href="/docs/issuing/purchases/disputes#dispute-reasons-and-evidence">Dispute reasons and evidence</a> for more details about evidence requirements.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/issuing/disputes"
        |> RestApi.postAsync<_, IssuingDispute> settings (Map.empty) options

    type RetrieveOptions = {
        [<Config.Path>]Dispute: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(dispute: string, ?expand: string list) =
            {
                Dispute = dispute
                Expand = expand
            }

    ///<summary><p>Retrieves an Issuing <code>Dispute</code> object.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/issuing/disputes/{options.Dispute}"
        |> RestApi.getAsync<IssuingDispute> settings qs

    type Update'EvidenceCanceledCanceledProductType =
    | Merchandise
    | Service

    type Update'EvidenceCanceledCanceledReturnStatus =
    | MerchantRejected
    | Successful

    type Update'EvidenceCanceledCanceled = {
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.</summary>
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///<summary>Date when order was canceled.</summary>
        [<Config.Form>]CanceledAt: Choice<DateTime,string> option
        ///<summary>Whether the cardholder was provided with a cancellation policy.</summary>
        [<Config.Form>]CancellationPolicyProvided: Choice<bool,string> option
        ///<summary>Reason for canceling the order.</summary>
        [<Config.Form>]CancellationReason: Choice<string,string> option
        ///<summary>Date when the cardholder expected to receive the product.</summary>
        [<Config.Form>]ExpectedAt: Choice<DateTime,string> option
        ///<summary>Explanation of why the cardholder is disputing this transaction.</summary>
        [<Config.Form>]Explanation: Choice<string,string> option
        ///<summary>Description of the merchandise or service that was purchased.</summary>
        [<Config.Form>]ProductDescription: Choice<string,string> option
        ///<summary>Whether the product was a merchandise or service.</summary>
        [<Config.Form>]ProductType: Update'EvidenceCanceledCanceledProductType option
        ///<summary>Result of cardholder's attempt to return the product.</summary>
        [<Config.Form>]ReturnStatus: Update'EvidenceCanceledCanceledReturnStatus option
        ///<summary>Date when the product was returned or attempted to be returned.</summary>
        [<Config.Form>]ReturnedAt: Choice<DateTime,string> option
    }
    with
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

    type Update'EvidenceDuplicateDuplicate = {
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.</summary>
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Copy of the card statement showing that the product had already been paid for.</summary>
        [<Config.Form>]CardStatement: Choice<string,string> option
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Copy of the receipt showing that the product had been paid for in cash.</summary>
        [<Config.Form>]CashReceipt: Choice<string,string> option
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Image of the front and back of the check that was used to pay for the product.</summary>
        [<Config.Form>]CheckImage: Choice<string,string> option
        ///<summary>Explanation of why the cardholder is disputing this transaction.</summary>
        [<Config.Form>]Explanation: Choice<string,string> option
        ///<summary>Transaction (e.g., ipi_...) that the disputed transaction is a duplicate of. Of the two or more transactions that are copies of each other, this is original undisputed one.</summary>
        [<Config.Form>]OriginalTransaction: string option
    }
    with
        static member New(?additionalDocumentation: Choice<string,string>, ?cardStatement: Choice<string,string>, ?cashReceipt: Choice<string,string>, ?checkImage: Choice<string,string>, ?explanation: Choice<string,string>, ?originalTransaction: string) =
            {
                AdditionalDocumentation = additionalDocumentation
                CardStatement = cardStatement
                CashReceipt = cashReceipt
                CheckImage = checkImage
                Explanation = explanation
                OriginalTransaction = originalTransaction
            }

    type Update'EvidenceFraudulentFraudulent = {
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.</summary>
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///<summary>Explanation of why the cardholder is disputing this transaction.</summary>
        [<Config.Form>]Explanation: Choice<string,string> option
    }
    with
        static member New(?additionalDocumentation: Choice<string,string>, ?explanation: Choice<string,string>) =
            {
                AdditionalDocumentation = additionalDocumentation
                Explanation = explanation
            }

    type Update'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus =
    | MerchantRejected
    | Successful

    type Update'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed = {
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.</summary>
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///<summary>Explanation of why the cardholder is disputing this transaction.</summary>
        [<Config.Form>]Explanation: Choice<string,string> option
        ///<summary>Date when the product was received.</summary>
        [<Config.Form>]ReceivedAt: Choice<DateTime,string> option
        ///<summary>Description of the cardholder's attempt to return the product.</summary>
        [<Config.Form>]ReturnDescription: Choice<string,string> option
        ///<summary>Result of cardholder's attempt to return the product.</summary>
        [<Config.Form>]ReturnStatus: Update'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus option
        ///<summary>Date when the product was returned or attempted to be returned.</summary>
        [<Config.Form>]ReturnedAt: Choice<DateTime,string> option
    }
    with
        static member New(?additionalDocumentation: Choice<string,string>, ?explanation: Choice<string,string>, ?receivedAt: Choice<DateTime,string>, ?returnDescription: Choice<string,string>, ?returnStatus: Update'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus, ?returnedAt: Choice<DateTime,string>) =
            {
                AdditionalDocumentation = additionalDocumentation
                Explanation = explanation
                ReceivedAt = receivedAt
                ReturnDescription = returnDescription
                ReturnStatus = returnStatus
                ReturnedAt = returnedAt
            }

    type Update'EvidenceNoValidAuthorizationNoValidAuthorization = {
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.</summary>
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///<summary>Explanation of why the cardholder is disputing this transaction.</summary>
        [<Config.Form>]Explanation: Choice<string,string> option
    }
    with
        static member New(?additionalDocumentation: Choice<string,string>, ?explanation: Choice<string,string>) =
            {
                AdditionalDocumentation = additionalDocumentation
                Explanation = explanation
            }

    type Update'EvidenceNotReceivedNotReceivedProductType =
    | Merchandise
    | Service

    type Update'EvidenceNotReceivedNotReceived = {
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.</summary>
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///<summary>Date when the cardholder expected to receive the product.</summary>
        [<Config.Form>]ExpectedAt: Choice<DateTime,string> option
        ///<summary>Explanation of why the cardholder is disputing this transaction.</summary>
        [<Config.Form>]Explanation: Choice<string,string> option
        ///<summary>Description of the merchandise or service that was purchased.</summary>
        [<Config.Form>]ProductDescription: Choice<string,string> option
        ///<summary>Whether the product was a merchandise or service.</summary>
        [<Config.Form>]ProductType: Update'EvidenceNotReceivedNotReceivedProductType option
    }
    with
        static member New(?additionalDocumentation: Choice<string,string>, ?expectedAt: Choice<DateTime,string>, ?explanation: Choice<string,string>, ?productDescription: Choice<string,string>, ?productType: Update'EvidenceNotReceivedNotReceivedProductType) =
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

    type Update'EvidenceOtherOther = {
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.</summary>
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///<summary>Explanation of why the cardholder is disputing this transaction.</summary>
        [<Config.Form>]Explanation: Choice<string,string> option
        ///<summary>Description of the merchandise or service that was purchased.</summary>
        [<Config.Form>]ProductDescription: Choice<string,string> option
        ///<summary>Whether the product was a merchandise or service.</summary>
        [<Config.Form>]ProductType: Update'EvidenceOtherOtherProductType option
    }
    with
        static member New(?additionalDocumentation: Choice<string,string>, ?explanation: Choice<string,string>, ?productDescription: Choice<string,string>, ?productType: Update'EvidenceOtherOtherProductType) =
            {
                AdditionalDocumentation = additionalDocumentation
                Explanation = explanation
                ProductDescription = productDescription
                ProductType = productType
            }

    type Update'EvidenceServiceNotAsDescribedServiceNotAsDescribed = {
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.</summary>
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///<summary>Date when order was canceled.</summary>
        [<Config.Form>]CanceledAt: Choice<DateTime,string> option
        ///<summary>Reason for canceling the order.</summary>
        [<Config.Form>]CancellationReason: Choice<string,string> option
        ///<summary>Explanation of why the cardholder is disputing this transaction.</summary>
        [<Config.Form>]Explanation: Choice<string,string> option
        ///<summary>Date when the product was received.</summary>
        [<Config.Form>]ReceivedAt: Choice<DateTime,string> option
    }
    with
        static member New(?additionalDocumentation: Choice<string,string>, ?canceledAt: Choice<DateTime,string>, ?cancellationReason: Choice<string,string>, ?explanation: Choice<string,string>, ?receivedAt: Choice<DateTime,string>) =
            {
                AdditionalDocumentation = additionalDocumentation
                CanceledAt = canceledAt
                CancellationReason = cancellationReason
                Explanation = explanation
                ReceivedAt = receivedAt
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

    type Update'Evidence = {
        ///<summary>Evidence provided when `reason` is 'canceled'.</summary>
        [<Config.Form>]Canceled: Choice<Update'EvidenceCanceledCanceled,string> option
        ///<summary>Evidence provided when `reason` is 'duplicate'.</summary>
        [<Config.Form>]Duplicate: Choice<Update'EvidenceDuplicateDuplicate,string> option
        ///<summary>Evidence provided when `reason` is 'fraudulent'.</summary>
        [<Config.Form>]Fraudulent: Choice<Update'EvidenceFraudulentFraudulent,string> option
        ///<summary>Evidence provided when `reason` is 'merchandise_not_as_described'.</summary>
        [<Config.Form>]MerchandiseNotAsDescribed: Choice<Update'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed,string> option
        ///<summary>Evidence provided when `reason` is 'no_valid_authorization'.</summary>
        [<Config.Form>]NoValidAuthorization: Choice<Update'EvidenceNoValidAuthorizationNoValidAuthorization,string> option
        ///<summary>Evidence provided when `reason` is 'not_received'.</summary>
        [<Config.Form>]NotReceived: Choice<Update'EvidenceNotReceivedNotReceived,string> option
        ///<summary>Evidence provided when `reason` is 'other'.</summary>
        [<Config.Form>]Other: Choice<Update'EvidenceOtherOther,string> option
        ///<summary>The reason for filing the dispute. The evidence should be submitted in the field of the same name.</summary>
        [<Config.Form>]Reason: Update'EvidenceReason option
        ///<summary>Evidence provided when `reason` is 'service_not_as_described'.</summary>
        [<Config.Form>]ServiceNotAsDescribed: Choice<Update'EvidenceServiceNotAsDescribedServiceNotAsDescribed,string> option
    }
    with
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

    type UpdateOptions = {
        [<Config.Path>]Dispute: string
        ///<summary>The dispute amount in the card's currency and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Evidence provided for the dispute.</summary>
        [<Config.Form>]Evidence: Update'Evidence option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(dispute: string, ?amount: int, ?evidence: Update'Evidence, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Dispute = dispute
                Amount = amount
                Evidence = evidence
                Expand = expand
                Metadata = metadata
            }

    ///<summary><p>Updates the specified Issuing <code>Dispute</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged. Properties on the <code>evidence</code> object can be unset by passing in an empty string.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/issuing/disputes/{options.Dispute}"
        |> RestApi.postAsync<_, IssuingDispute> settings (Map.empty) options

module IssuingDisputesSubmit =

    type SubmitOptions = {
        [<Config.Path>]Dispute: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(dispute: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Dispute = dispute
                Expand = expand
                Metadata = metadata
            }

    ///<summary><p>Submits an Issuing <code>Dispute</code> to the card network. Stripe validates that all evidence fields required for the dispute’s reason are present. For more details, see <a href="/docs/issuing/purchases/disputes#dispute-reasons-and-evidence">Dispute reasons and evidence</a>.</p></summary>
    let Submit settings (options: SubmitOptions) =
        $"/v1/issuing/disputes/{options.Dispute}/submit"
        |> RestApi.postAsync<_, IssuingDispute> settings (Map.empty) options

module IssuingPersonalizationDesigns =

    type ListOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>Only return personalization designs with the given lookup keys.</summary>
        [<Config.Query>]LookupKeys: string list option
        ///<summary>Only return personalization designs with the given preferences.</summary>
        [<Config.Query>]Preferences: Map<string, string> option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Only return personalization designs with the given status.</summary>
        [<Config.Query>]Status: string option
    }
    with
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

    ///<summary><p>Returns a list of personalization design objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("lookup_keys", options.LookupKeys |> box); ("preferences", options.Preferences |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/issuing/personalization_designs"
        |> RestApi.getAsync<StripeList<IssuingPersonalizationDesign>> settings qs

    type Create'CarrierText = {
        ///<summary>The footer body text of the carrier letter.</summary>
        [<Config.Form>]FooterBody: Choice<string,string> option
        ///<summary>The footer title text of the carrier letter.</summary>
        [<Config.Form>]FooterTitle: Choice<string,string> option
        ///<summary>The header body text of the carrier letter.</summary>
        [<Config.Form>]HeaderBody: Choice<string,string> option
        ///<summary>The header title text of the carrier letter.</summary>
        [<Config.Form>]HeaderTitle: Choice<string,string> option
    }
    with
        static member New(?footerBody: Choice<string,string>, ?footerTitle: Choice<string,string>, ?headerBody: Choice<string,string>, ?headerTitle: Choice<string,string>) =
            {
                FooterBody = footerBody
                FooterTitle = footerTitle
                HeaderBody = headerBody
                HeaderTitle = headerTitle
            }

    type Create'Preferences = {
        ///<summary>Whether we use this personalization design to create cards when one isn't specified. A connected account uses the Connect platform's default design if no personalization design is set as the default design.</summary>
        [<Config.Form>]IsDefault: bool option
    }
    with
        static member New(?isDefault: bool) =
            {
                IsDefault = isDefault
            }

    type CreateOptions = {
        ///<summary>The file for the card logo, for use with physical bundles that support card logos. Must have a `purpose` value of `issuing_logo`.</summary>
        [<Config.Form>]CardLogo: string option
        ///<summary>Hash containing carrier text, for use with physical bundles that support carrier text.</summary>
        [<Config.Form>]CarrierText: Create'CarrierText option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>A lookup key used to retrieve personalization designs dynamically from a static string. This may be up to 200 characters.</summary>
        [<Config.Form>]LookupKey: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Friendly display name.</summary>
        [<Config.Form>]Name: string option
        ///<summary>The physical bundle object belonging to this personalization design.</summary>
        [<Config.Form>]PhysicalBundle: string
        ///<summary>Information on whether this personalization design is used to create cards when one is not specified.</summary>
        [<Config.Form>]Preferences: Create'Preferences option
        ///<summary>If set to true, will atomically remove the lookup key from the existing personalization design, and assign it to this personalization design.</summary>
        [<Config.Form>]TransferLookupKey: bool option
    }
    with
        static member New(physicalBundle: string, ?cardLogo: string, ?carrierText: Create'CarrierText, ?expand: string list, ?lookupKey: string, ?metadata: Map<string, string>, ?name: string, ?preferences: Create'Preferences, ?transferLookupKey: bool) =
            {
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

    ///<summary><p>Creates a personalization design object.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/issuing/personalization_designs"
        |> RestApi.postAsync<_, IssuingPersonalizationDesign> settings (Map.empty) options

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]PersonalizationDesign: string
    }
    with
        static member New(personalizationDesign: string, ?expand: string list) =
            {
                Expand = expand
                PersonalizationDesign = personalizationDesign
            }

    ///<summary><p>Retrieves a personalization design object.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/issuing/personalization_designs/{options.PersonalizationDesign}"
        |> RestApi.getAsync<IssuingPersonalizationDesign> settings qs

    type Update'CarrierTextCarrierText = {
        ///<summary>The footer body text of the carrier letter.</summary>
        [<Config.Form>]FooterBody: Choice<string,string> option
        ///<summary>The footer title text of the carrier letter.</summary>
        [<Config.Form>]FooterTitle: Choice<string,string> option
        ///<summary>The header body text of the carrier letter.</summary>
        [<Config.Form>]HeaderBody: Choice<string,string> option
        ///<summary>The header title text of the carrier letter.</summary>
        [<Config.Form>]HeaderTitle: Choice<string,string> option
    }
    with
        static member New(?footerBody: Choice<string,string>, ?footerTitle: Choice<string,string>, ?headerBody: Choice<string,string>, ?headerTitle: Choice<string,string>) =
            {
                FooterBody = footerBody
                FooterTitle = footerTitle
                HeaderBody = headerBody
                HeaderTitle = headerTitle
            }

    type Update'Preferences = {
        ///<summary>Whether we use this personalization design to create cards when one isn't specified. A connected account uses the Connect platform's default design if no personalization design is set as the default design.</summary>
        [<Config.Form>]IsDefault: bool option
    }
    with
        static member New(?isDefault: bool) =
            {
                IsDefault = isDefault
            }

    type UpdateOptions = {
        [<Config.Path>]PersonalizationDesign: string
        ///<summary>The file for the card logo, for use with physical bundles that support card logos. Must have a `purpose` value of `issuing_logo`.</summary>
        [<Config.Form>]CardLogo: Choice<string,string> option
        ///<summary>Hash containing carrier text, for use with physical bundles that support carrier text.</summary>
        [<Config.Form>]CarrierText: Choice<Update'CarrierTextCarrierText,string> option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>A lookup key used to retrieve personalization designs dynamically from a static string. This may be up to 200 characters.</summary>
        [<Config.Form>]LookupKey: Choice<string,string> option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Friendly display name. Providing an empty string will set the field to null.</summary>
        [<Config.Form>]Name: Choice<string,string> option
        ///<summary>The physical bundle object belonging to this personalization design.</summary>
        [<Config.Form>]PhysicalBundle: string option
        ///<summary>Information on whether this personalization design is used to create cards when one is not specified.</summary>
        [<Config.Form>]Preferences: Update'Preferences option
        ///<summary>If set to true, will atomically remove the lookup key from the existing personalization design, and assign it to this personalization design.</summary>
        [<Config.Form>]TransferLookupKey: bool option
    }
    with
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

    ///<summary><p>Updates a card personalization object.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/issuing/personalization_designs/{options.PersonalizationDesign}"
        |> RestApi.postAsync<_, IssuingPersonalizationDesign> settings (Map.empty) options

module IssuingPhysicalBundles =

    type ListOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Only return physical bundles with the given status.</summary>
        [<Config.Query>]Status: string option
        ///<summary>Only return physical bundles with the given type.</summary>
        [<Config.Query>]Type: string option
    }
    with
        static member New(?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string, ?type': string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Status = status
                Type = type'
            }

    ///<summary><p>Returns a list of physical bundle objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("type", options.Type |> box)] |> Map.ofList
        $"/v1/issuing/physical_bundles"
        |> RestApi.getAsync<StripeList<IssuingPhysicalBundle>> settings qs

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]PhysicalBundle: string
    }
    with
        static member New(physicalBundle: string, ?expand: string list) =
            {
                Expand = expand
                PhysicalBundle = physicalBundle
            }

    ///<summary><p>Retrieves a physical bundle object.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/issuing/physical_bundles/{options.PhysicalBundle}"
        |> RestApi.getAsync<IssuingPhysicalBundle> settings qs

module IssuingTokens =

    type ListOptions = {
        ///<summary>The Issuing card identifier to list tokens for.</summary>
        [<Config.Query>]Card: string
        ///<summary>Only return Issuing tokens that were created during the given date interval.</summary>
        [<Config.Query>]Created: int option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Select Issuing tokens with the given status.</summary>
        [<Config.Query>]Status: string option
    }
    with
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

    ///<summary><p>Lists all Issuing <code>Token</code> objects for a given card.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("card", options.Card |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/issuing/tokens"
        |> RestApi.getAsync<StripeList<IssuingToken>> settings qs

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Token: string
    }
    with
        static member New(token: string, ?expand: string list) =
            {
                Expand = expand
                Token = token
            }

    ///<summary><p>Retrieves an Issuing <code>Token</code> object.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/issuing/tokens/{options.Token}"
        |> RestApi.getAsync<IssuingToken> settings qs

    type Update'Status =
    | Active
    | Deleted
    | Suspended

    type UpdateOptions = {
        [<Config.Path>]Token: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Specifies which status the token should be updated to.</summary>
        [<Config.Form>]Status: Update'Status
    }
    with
        static member New(token: string, status: Update'Status, ?expand: string list) =
            {
                Token = token
                Expand = expand
                Status = status
            }

    ///<summary><p>Attempts to update the specified Issuing <code>Token</code> object to the status specified.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/issuing/tokens/{options.Token}"
        |> RestApi.postAsync<_, IssuingToken> settings (Map.empty) options

module IssuingTransactions =

    type ListOptions = {
        ///<summary>Only return transactions that belong to the given card.</summary>
        [<Config.Query>]Card: string option
        ///<summary>Only return transactions that belong to the given cardholder.</summary>
        [<Config.Query>]Cardholder: string option
        ///<summary>Only return transactions that were created during the given date interval.</summary>
        [<Config.Query>]Created: int option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Only return transactions that have the given type. One of `capture` or `refund`.</summary>
        [<Config.Query>]Type: string option
    }
    with
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

    ///<summary><p>Returns a list of Issuing <code>Transaction</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("card", options.Card |> box); ("cardholder", options.Cardholder |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("type", options.Type |> box)] |> Map.ofList
        $"/v1/issuing/transactions"
        |> RestApi.getAsync<StripeList<IssuingTransaction>> settings qs

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Transaction: string
    }
    with
        static member New(transaction: string, ?expand: string list) =
            {
                Expand = expand
                Transaction = transaction
            }

    ///<summary><p>Retrieves an Issuing <code>Transaction</code> object.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/issuing/transactions/{options.Transaction}"
        |> RestApi.getAsync<IssuingTransaction> settings qs

    type UpdateOptions = {
        [<Config.Path>]Transaction: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(transaction: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Transaction = transaction
                Expand = expand
                Metadata = metadata
            }

    ///<summary><p>Updates the specified Issuing <code>Transaction</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/issuing/transactions/{options.Transaction}"
        |> RestApi.postAsync<_, IssuingTransaction> settings (Map.empty) options
