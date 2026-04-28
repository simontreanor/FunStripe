namespace FunStripe.StripeRequest

open FunStripe
open FunStripe.Json
open FunStripe.StripeModel
open System

module IssuingAuthorizations =

    type ListOptions = {
        ///Only return authorizations that belong to the given card.
        [<Config.Query>]Card: string option
        ///Only return authorizations that belong to the given cardholder.
        [<Config.Query>]Cardholder: string option
        ///Only return authorizations that were created during the given date interval.
        [<Config.Query>]Created: int option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///Only return authorizations with the given status. One of `pending`, `closed`, or `reversed`.
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

    ///<p>Returns a list of Issuing <code>Authorization</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("card", options.Card |> box); ("cardholder", options.Cardholder |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/issuing/authorizations"
        |> RestApi.getAsync<IssuingAuthorization list> settings qs

    type RetrieveOptions = {
        [<Config.Path>]Authorization: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(authorization: string, ?expand: string list) =
            {
                Authorization = authorization
                Expand = expand
            }

    ///<p>Retrieves an Issuing <code>Authorization</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/issuing/authorizations/{options.Authorization}"
        |> RestApi.getAsync<IssuingAuthorization> settings qs

    type UpdateOptions = {
        [<Config.Path>]Authorization: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(authorization: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Authorization = authorization
                Expand = expand
                Metadata = metadata
            }

    ///<p>Updates the specified Issuing <code>Authorization</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/issuing/authorizations/{options.Authorization}"
        |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) options

module IssuingAuthorizationsApprove =

    type ApproveOptions = {
        [<Config.Path>]Authorization: string
        ///If the authorization's `pending_request.is_amount_controllable` property is `true`, you may provide this value to control how much to hold for the authorization. Must be positive (use [`decline`](https://stripe.com/docs/api/issuing/authorizations/decline) to decline an authorization request).
        [<Config.Form>]Amount: int option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
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

    ///<p>Approves a pending Issuing <code>Authorization</code> object. This request should be made within the timeout window of the <a href="/docs/issuing/controls/real-time-authorizations">real-time authorization</a> flow. 
    ///You can also respond directly to the webhook request to approve an authorization (preferred). More details can be found <a href="/docs/issuing/controls/real-time-authorizations#authorization-handling">here</a>.</p>
    let Approve settings (options: ApproveOptions) =
        $"/v1/issuing/authorizations/{options.Authorization}/approve"
        |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) options

module IssuingAuthorizationsDecline =

    type DeclineOptions = {
        [<Config.Path>]Authorization: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(authorization: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Authorization = authorization
                Expand = expand
                Metadata = metadata
            }

    ///<p>Declines a pending Issuing <code>Authorization</code> object. This request should be made within the timeout window of the <a href="/docs/issuing/controls/real-time-authorizations">real time authorization</a> flow.
    ///You can also respond directly to the webhook request to decline an authorization (preferred). More details can be found <a href="/docs/issuing/controls/real-time-authorizations#authorization-handling">here</a>.</p>
    let Decline settings (options: DeclineOptions) =
        $"/v1/issuing/authorizations/{options.Authorization}/decline"
        |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) options

module IssuingCardholders =

    type ListOptions = {
        ///Only return cardholders that were created during the given date interval.
        [<Config.Query>]Created: int option
        ///Only return cardholders that have the given email address.
        [<Config.Query>]Email: string option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///Only return cardholders that have the given phone number.
        [<Config.Query>]PhoneNumber: string option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///Only return cardholders that have the given status. One of `active`, `inactive`, or `blocked`.
        [<Config.Query>]Status: string option
        ///Only return cardholders that have the given type. One of `individual` or `company`.
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

    ///<p>Returns a list of Issuing <code>Cardholder</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("email", options.Email |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("phone_number", options.PhoneNumber |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("type", options.Type |> box)] |> Map.ofList
        $"/v1/issuing/cardholders"
        |> RestApi.getAsync<IssuingCardholder list> settings qs

    type Create'BillingAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'Billing = {
        ///The cardholder’s billing address.
        [<Config.Form>]Address: Create'BillingAddress option
    }
    with
        static member New(?address: Create'BillingAddress) =
            {
                Address = address
            }

    type Create'Company = {
        ///The entity's business ID number.
        [<Config.Form>]TaxId: string option
    }
    with
        static member New(?taxId: string) =
            {
                TaxId = taxId
            }

    type Create'IndividualCardIssuingUserTermsAcceptance = {
        ///The Unix timestamp marking when the cardholder accepted the Authorized User Terms. Required for Celtic Spend Card users.
        [<Config.Form>]Date: DateTime option
        ///The IP address from which the cardholder accepted the Authorized User Terms. Required for Celtic Spend Card users.
        [<Config.Form>]Ip: string option
        ///The user agent of the browser from which the cardholder accepted the Authorized User Terms.
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
        ///Information about cardholder acceptance of [Authorized User Terms](https://stripe.com/docs/issuing/cards).
        [<Config.Form>]UserTermsAcceptance: Create'IndividualCardIssuingUserTermsAcceptance option
    }
    with
        static member New(?userTermsAcceptance: Create'IndividualCardIssuingUserTermsAcceptance) =
            {
                UserTermsAcceptance = userTermsAcceptance
            }

    type Create'IndividualDob = {
        ///The day of birth, between 1 and 31.
        [<Config.Form>]Day: int option
        ///The month of birth, between 1 and 12.
        [<Config.Form>]Month: int option
        ///The four-digit year of birth.
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
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`.
        [<Config.Form>]Back: string option
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`.
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Create'IndividualVerification = {
        ///An identifying document, either a passport or local ID card.
        [<Config.Form>]Document: Create'IndividualVerificationDocument option
    }
    with
        static member New(?document: Create'IndividualVerificationDocument) =
            {
                Document = document
            }

    type Create'Individual = {
        ///Information related to the card_issuing program for this cardholder.
        [<Config.Form>]CardIssuing: Create'IndividualCardIssuing option
        ///The date of birth of this cardholder. Cardholders must be older than 13 years old.
        [<Config.Form>]Dob: Create'IndividualDob option
        ///The first name of this cardholder. Required before activating Cards. This field cannot contain any numbers, special characters (except periods, commas, hyphens, spaces and apostrophes) or non-latin letters.
        [<Config.Form>]FirstName: string option
        ///The last name of this cardholder. Required before activating Cards. This field cannot contain any numbers, special characters (except periods, commas, hyphens, spaces and apostrophes) or non-latin letters.
        [<Config.Form>]LastName: string option
        ///Government-issued ID document for this cardholder.
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
        ///Maximum amount allowed to spend per interval.
        [<Config.Form>]Amount: int option
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) this limit applies to. Omitting this field will apply the limit to all categories.
        [<Config.Form>]Categories: Create'SpendingControlsSpendingLimitsCategories list option
        ///Interval (or event) to which the amount applies.
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
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) of authorizations to allow. All other categories will be blocked. Cannot be set with `blocked_categories`.
        [<Config.Form>]AllowedCategories: Create'SpendingControlsAllowedCategories list option
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) of authorizations to decline. All other categories will be allowed. Cannot be set with `allowed_categories`.
        [<Config.Form>]BlockedCategories: Create'SpendingControlsBlockedCategories list option
        ///Limit spending with amount-based rules that apply across this cardholder's cards.
        [<Config.Form>]SpendingLimits: Create'SpendingControlsSpendingLimits list option
        ///Currency of amounts within `spending_limits`. Defaults to your merchant country's currency.
        [<Config.Form>]SpendingLimitsCurrency: string option
    }
    with
        static member New(?allowedCategories: Create'SpendingControlsAllowedCategories list, ?blockedCategories: Create'SpendingControlsBlockedCategories list, ?spendingLimits: Create'SpendingControlsSpendingLimits list, ?spendingLimitsCurrency: string) =
            {
                AllowedCategories = allowedCategories
                BlockedCategories = blockedCategories
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
        ///The cardholder's billing address.
        [<Config.Form>]Billing: Create'Billing
        ///Additional information about a `company` cardholder.
        [<Config.Form>]Company: Create'Company option
        ///The cardholder's email address.
        [<Config.Form>]Email: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Additional information about an `individual` cardholder.
        [<Config.Form>]Individual: Create'Individual option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The cardholder's name. This will be printed on cards issued to them. The maximum length of this field is 24 characters. This field cannot contain any special characters or numbers.
        [<Config.Form>]Name: string
        ///The cardholder's phone number. This will be transformed to [E.164](https://en.wikipedia.org/wiki/E.164) if it is not provided in that format already. This is required for all cardholders who will be creating EU cards. See the [3D Secure documentation](https://stripe.com/docs/issuing/3d-secure#when-is-3d-secure-applied) for more details.
        [<Config.Form>]PhoneNumber: string option
        ///The cardholder’s preferred locales (languages), ordered by preference. Locales can be `de`, `en`, `es`, `fr`, or `it`.
        /// This changes the language of the [3D Secure flow](https://stripe.com/docs/issuing/3d-secure) and one-time password messages sent to the cardholder.
        [<Config.Form>]PreferredLocales: Create'PreferredLocales list option
        ///Rules that control spending across this cardholder's cards. Refer to our [documentation](https://stripe.com/docs/issuing/controls/spending-controls) for more details.
        [<Config.Form>]SpendingControls: Create'SpendingControls option
        ///Specifies whether to permit authorizations on this cardholder's cards. Defaults to `active`.
        [<Config.Form>]Status: Create'Status option
        ///One of `individual` or `company`. See [Choose a cardholder type](https://stripe.com/docs/issuing/other/choose-cardholder) for more details.
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

    ///<p>Creates a new Issuing <code>Cardholder</code> object that can be issued cards.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/issuing/cardholders"
        |> RestApi.postAsync<_, IssuingCardholder> settings (Map.empty) options

    type RetrieveOptions = {
        [<Config.Path>]Cardholder: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(cardholder: string, ?expand: string list) =
            {
                Cardholder = cardholder
                Expand = expand
            }

    ///<p>Retrieves an Issuing <code>Cardholder</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/issuing/cardholders/{options.Cardholder}"
        |> RestApi.getAsync<IssuingCardholder> settings qs

    type Update'BillingAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'Billing = {
        ///The cardholder’s billing address.
        [<Config.Form>]Address: Update'BillingAddress option
    }
    with
        static member New(?address: Update'BillingAddress) =
            {
                Address = address
            }

    type Update'Company = {
        ///The entity's business ID number.
        [<Config.Form>]TaxId: string option
    }
    with
        static member New(?taxId: string) =
            {
                TaxId = taxId
            }

    type Update'IndividualCardIssuingUserTermsAcceptance = {
        ///The Unix timestamp marking when the cardholder accepted the Authorized User Terms. Required for Celtic Spend Card users.
        [<Config.Form>]Date: DateTime option
        ///The IP address from which the cardholder accepted the Authorized User Terms. Required for Celtic Spend Card users.
        [<Config.Form>]Ip: string option
        ///The user agent of the browser from which the cardholder accepted the Authorized User Terms.
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
        ///Information about cardholder acceptance of [Authorized User Terms](https://stripe.com/docs/issuing/cards).
        [<Config.Form>]UserTermsAcceptance: Update'IndividualCardIssuingUserTermsAcceptance option
    }
    with
        static member New(?userTermsAcceptance: Update'IndividualCardIssuingUserTermsAcceptance) =
            {
                UserTermsAcceptance = userTermsAcceptance
            }

    type Update'IndividualDob = {
        ///The day of birth, between 1 and 31.
        [<Config.Form>]Day: int option
        ///The month of birth, between 1 and 12.
        [<Config.Form>]Month: int option
        ///The four-digit year of birth.
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
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`.
        [<Config.Form>]Back: string option
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`.
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Update'IndividualVerification = {
        ///An identifying document, either a passport or local ID card.
        [<Config.Form>]Document: Update'IndividualVerificationDocument option
    }
    with
        static member New(?document: Update'IndividualVerificationDocument) =
            {
                Document = document
            }

    type Update'Individual = {
        ///Information related to the card_issuing program for this cardholder.
        [<Config.Form>]CardIssuing: Update'IndividualCardIssuing option
        ///The date of birth of this cardholder. Cardholders must be older than 13 years old.
        [<Config.Form>]Dob: Update'IndividualDob option
        ///The first name of this cardholder. Required before activating Cards. This field cannot contain any numbers, special characters (except periods, commas, hyphens, spaces and apostrophes) or non-latin letters.
        [<Config.Form>]FirstName: string option
        ///The last name of this cardholder. Required before activating Cards. This field cannot contain any numbers, special characters (except periods, commas, hyphens, spaces and apostrophes) or non-latin letters.
        [<Config.Form>]LastName: string option
        ///Government-issued ID document for this cardholder.
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
        ///Maximum amount allowed to spend per interval.
        [<Config.Form>]Amount: int option
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) this limit applies to. Omitting this field will apply the limit to all categories.
        [<Config.Form>]Categories: Update'SpendingControlsSpendingLimitsCategories list option
        ///Interval (or event) to which the amount applies.
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
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) of authorizations to allow. All other categories will be blocked. Cannot be set with `blocked_categories`.
        [<Config.Form>]AllowedCategories: Update'SpendingControlsAllowedCategories list option
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) of authorizations to decline. All other categories will be allowed. Cannot be set with `allowed_categories`.
        [<Config.Form>]BlockedCategories: Update'SpendingControlsBlockedCategories list option
        ///Limit spending with amount-based rules that apply across this cardholder's cards.
        [<Config.Form>]SpendingLimits: Update'SpendingControlsSpendingLimits list option
        ///Currency of amounts within `spending_limits`. Defaults to your merchant country's currency.
        [<Config.Form>]SpendingLimitsCurrency: string option
    }
    with
        static member New(?allowedCategories: Update'SpendingControlsAllowedCategories list, ?blockedCategories: Update'SpendingControlsBlockedCategories list, ?spendingLimits: Update'SpendingControlsSpendingLimits list, ?spendingLimitsCurrency: string) =
            {
                AllowedCategories = allowedCategories
                BlockedCategories = blockedCategories
                SpendingLimits = spendingLimits
                SpendingLimitsCurrency = spendingLimitsCurrency
            }

    type Update'Status =
    | Active
    | Inactive

    type UpdateOptions = {
        [<Config.Path>]Cardholder: string
        ///The cardholder's billing address.
        [<Config.Form>]Billing: Update'Billing option
        ///Additional information about a `company` cardholder.
        [<Config.Form>]Company: Update'Company option
        ///The cardholder's email address.
        [<Config.Form>]Email: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Additional information about an `individual` cardholder.
        [<Config.Form>]Individual: Update'Individual option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The cardholder's phone number. This is required for all cardholders who will be creating EU cards. See the [3D Secure documentation](https://stripe.com/docs/issuing/3d-secure) for more details.
        [<Config.Form>]PhoneNumber: string option
        ///The cardholder’s preferred locales (languages), ordered by preference. Locales can be `de`, `en`, `es`, `fr`, or `it`.
        /// This changes the language of the [3D Secure flow](https://stripe.com/docs/issuing/3d-secure) and one-time password messages sent to the cardholder.
        [<Config.Form>]PreferredLocales: Update'PreferredLocales list option
        ///Rules that control spending across this cardholder's cards. Refer to our [documentation](https://stripe.com/docs/issuing/controls/spending-controls) for more details.
        [<Config.Form>]SpendingControls: Update'SpendingControls option
        ///Specifies whether to permit authorizations on this cardholder's cards.
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

    ///<p>Updates the specified Issuing <code>Cardholder</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/issuing/cardholders/{options.Cardholder}"
        |> RestApi.postAsync<_, IssuingCardholder> settings (Map.empty) options

module IssuingCards =

    type ListOptions = {
        ///Only return cards belonging to the Cardholder with the provided ID.
        [<Config.Query>]Cardholder: string option
        ///Only return cards that were issued during the given date interval.
        [<Config.Query>]Created: int option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Only return cards that have the given expiration month.
        [<Config.Query>]ExpMonth: int option
        ///Only return cards that have the given expiration year.
        [<Config.Query>]ExpYear: int option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///Only return cards that have the given last four digits.
        [<Config.Query>]Last4: string option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///Only return cards that have the given status. One of `active`, `inactive`, or `canceled`.
        [<Config.Query>]Status: string option
        ///Only return cards that have the given type. One of `virtual` or `physical`.
        [<Config.Query>]Type: string option
    }
    with
        static member New(?cardholder: string, ?created: int, ?endingBefore: string, ?expMonth: int, ?expYear: int, ?expand: string list, ?last4: string, ?limit: int, ?startingAfter: string, ?status: string, ?type': string) =
            {
                Cardholder = cardholder
                Created = created
                EndingBefore = endingBefore
                ExpMonth = expMonth
                ExpYear = expYear
                Expand = expand
                Last4 = last4
                Limit = limit
                StartingAfter = startingAfter
                Status = status
                Type = type'
            }

    ///<p>Returns a list of Issuing <code>Card</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("cardholder", options.Cardholder |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("exp_month", options.ExpMonth |> box); ("exp_year", options.ExpYear |> box); ("expand", options.Expand |> box); ("last4", options.Last4 |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("type", options.Type |> box)] |> Map.ofList
        $"/v1/issuing/cards"
        |> RestApi.getAsync<IssuingCard list> settings qs

    type Create'ShippingAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'ShippingCustoms = {
        ///The Economic Operators Registration and Identification (EORI) number to use for Customs. Required for bulk shipments to Europe.
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
        ///The address that the card is shipped to.
        [<Config.Form>]Address: Create'ShippingAddress option
        ///Customs information for the shipment.
        [<Config.Form>]Customs: Create'ShippingCustoms option
        ///The name printed on the shipping label when shipping the card.
        [<Config.Form>]Name: string option
        ///Phone number of the recipient of the shipment.
        [<Config.Form>]PhoneNumber: string option
        ///Whether a signature is required for card delivery.
        [<Config.Form>]RequireSignature: bool option
        ///Shipment service.
        [<Config.Form>]Service: Create'ShippingService option
        ///Packaging options.
        [<Config.Form>]Type: Create'ShippingType option
    }
    with
        static member New(?address: Create'ShippingAddress, ?customs: Create'ShippingCustoms, ?name: string, ?phoneNumber: string, ?requireSignature: bool, ?service: Create'ShippingService, ?type': Create'ShippingType) =
            {
                Address = address
                Customs = customs
                Name = name
                PhoneNumber = phoneNumber
                RequireSignature = requireSignature
                Service = service
                Type = type'
            }

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
        ///Maximum amount allowed to spend per interval.
        [<Config.Form>]Amount: int option
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) this limit applies to. Omitting this field will apply the limit to all categories.
        [<Config.Form>]Categories: Create'SpendingControlsSpendingLimitsCategories list option
        ///Interval (or event) to which the amount applies.
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
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) of authorizations to allow. All other categories will be blocked. Cannot be set with `blocked_categories`.
        [<Config.Form>]AllowedCategories: Create'SpendingControlsAllowedCategories list option
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) of authorizations to decline. All other categories will be allowed. Cannot be set with `allowed_categories`.
        [<Config.Form>]BlockedCategories: Create'SpendingControlsBlockedCategories list option
        ///Limit spending with amount-based rules that apply across any cards this card replaced (i.e., its `replacement_for` card and _that_ card's `replacement_for` card, up the chain).
        [<Config.Form>]SpendingLimits: Create'SpendingControlsSpendingLimits list option
    }
    with
        static member New(?allowedCategories: Create'SpendingControlsAllowedCategories list, ?blockedCategories: Create'SpendingControlsBlockedCategories list, ?spendingLimits: Create'SpendingControlsSpendingLimits list) =
            {
                AllowedCategories = allowedCategories
                BlockedCategories = blockedCategories
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
        ///The [Cardholder](https://stripe.com/docs/api#issuing_cardholder_object) object with which the card will be associated.
        [<Config.Form>]Cardholder: string option
        ///The currency for the card.
        [<Config.Form>]Currency: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        [<Config.Form>]FinancialAccount: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The card this is meant to be a replacement for (if any).
        [<Config.Form>]ReplacementFor: string option
        ///If `replacement_for` is specified, this should indicate why that card is being replaced.
        [<Config.Form>]ReplacementReason: Create'ReplacementReason option
        ///The address where the card will be shipped.
        [<Config.Form>]Shipping: Create'Shipping option
        ///Rules that control spending for this card. Refer to our [documentation](https://stripe.com/docs/issuing/controls/spending-controls) for more details.
        [<Config.Form>]SpendingControls: Create'SpendingControls option
        ///Whether authorizations can be approved on this card. May be blocked from activating cards depending on past-due Cardholder requirements. Defaults to `inactive`.
        [<Config.Form>]Status: Create'Status option
        ///The type of card to issue. Possible values are `physical` or `virtual`.
        [<Config.Form>]Type: Create'Type
    }
    with
        static member New(currency: string, type': Create'Type, ?cardholder: string, ?expand: string list, ?financialAccount: string, ?metadata: Map<string, string>, ?replacementFor: string, ?replacementReason: Create'ReplacementReason, ?shipping: Create'Shipping, ?spendingControls: Create'SpendingControls, ?status: Create'Status) =
            {
                Cardholder = cardholder
                Currency = currency
                Expand = expand
                FinancialAccount = financialAccount
                Metadata = metadata
                ReplacementFor = replacementFor
                ReplacementReason = replacementReason
                Shipping = shipping
                SpendingControls = spendingControls
                Status = status
                Type = type'
            }

    ///<p>Creates an Issuing <code>Card</code> object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/issuing/cards"
        |> RestApi.postAsync<_, IssuingCard> settings (Map.empty) options

    type RetrieveOptions = {
        [<Config.Path>]Card: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(card: string, ?expand: string list) =
            {
                Card = card
                Expand = expand
            }

    ///<p>Retrieves an Issuing <code>Card</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/issuing/cards/{options.Card}"
        |> RestApi.getAsync<IssuingCard> settings qs

    type Update'Pin = {
        ///The card's desired new PIN, encrypted under Stripe's public key.
        [<Config.Form>]EncryptedNumber: string option
    }
    with
        static member New(?encryptedNumber: string) =
            {
                EncryptedNumber = encryptedNumber
            }

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
        ///Maximum amount allowed to spend per interval.
        [<Config.Form>]Amount: int option
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) this limit applies to. Omitting this field will apply the limit to all categories.
        [<Config.Form>]Categories: Update'SpendingControlsSpendingLimitsCategories list option
        ///Interval (or event) to which the amount applies.
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
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) of authorizations to allow. All other categories will be blocked. Cannot be set with `blocked_categories`.
        [<Config.Form>]AllowedCategories: Update'SpendingControlsAllowedCategories list option
        ///Array of strings containing [categories](https://stripe.com/docs/api#issuing_authorization_object-merchant_data-category) of authorizations to decline. All other categories will be allowed. Cannot be set with `allowed_categories`.
        [<Config.Form>]BlockedCategories: Update'SpendingControlsBlockedCategories list option
        ///Limit spending with amount-based rules that apply across any cards this card replaced (i.e., its `replacement_for` card and _that_ card's `replacement_for` card, up the chain).
        [<Config.Form>]SpendingLimits: Update'SpendingControlsSpendingLimits list option
    }
    with
        static member New(?allowedCategories: Update'SpendingControlsAllowedCategories list, ?blockedCategories: Update'SpendingControlsBlockedCategories list, ?spendingLimits: Update'SpendingControlsSpendingLimits list) =
            {
                AllowedCategories = allowedCategories
                BlockedCategories = blockedCategories
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
        ///Reason why the `status` of this card is `canceled`.
        [<Config.Form>]CancellationReason: Update'CancellationReason option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The desired new PIN for this card.
        [<Config.Form>]Pin: Update'Pin option
        ///Rules that control spending for this card. Refer to our [documentation](https://stripe.com/docs/issuing/controls/spending-controls) for more details.
        [<Config.Form>]SpendingControls: Update'SpendingControls option
        ///Dictates whether authorizations can be approved on this card. May be blocked from activating cards depending on past-due Cardholder requirements. Defaults to `inactive`. If this card is being canceled because it was lost or stolen, this information should be provided as `cancellation_reason`.
        [<Config.Form>]Status: Update'Status option
    }
    with
        static member New(card: string, ?cancellationReason: Update'CancellationReason, ?expand: string list, ?metadata: Map<string, string>, ?pin: Update'Pin, ?spendingControls: Update'SpendingControls, ?status: Update'Status) =
            {
                Card = card
                CancellationReason = cancellationReason
                Expand = expand
                Metadata = metadata
                Pin = pin
                SpendingControls = spendingControls
                Status = status
            }

    ///<p>Updates the specified Issuing <code>Card</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/issuing/cards/{options.Card}"
        |> RestApi.postAsync<_, IssuingCard> settings (Map.empty) options

module IssuingDisputes =

    type ListOptions = {
        ///Select Issuing disputes that were created during the given date interval.
        [<Config.Query>]Created: int option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///Select Issuing disputes with the given status.
        [<Config.Query>]Status: string option
        ///Select the Issuing dispute for the given transaction.
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

    ///<p>Returns a list of Issuing <code>Dispute</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("transaction", options.Transaction |> box)] |> Map.ofList
        $"/v1/issuing/disputes"
        |> RestApi.getAsync<IssuingDispute list> settings qs

    type Create'EvidenceCanceledCanceledProductType =
    | Merchandise
    | Service

    type Create'EvidenceCanceledCanceledReturnStatus =
    | MerchantRejected
    | Successful

    type Create'EvidenceCanceledCanceled = {
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///Date when order was canceled.
        [<Config.Form>]CanceledAt: Choice<DateTime,string> option
        ///Whether the cardholder was provided with a cancellation policy.
        [<Config.Form>]CancellationPolicyProvided: Choice<bool,string> option
        ///Reason for canceling the order.
        [<Config.Form>]CancellationReason: Choice<string,string> option
        ///Date when the cardholder expected to receive the product.
        [<Config.Form>]ExpectedAt: Choice<DateTime,string> option
        ///Explanation of why the cardholder is disputing this transaction.
        [<Config.Form>]Explanation: Choice<string,string> option
        ///Description of the merchandise or service that was purchased.
        [<Config.Form>]ProductDescription: Choice<string,string> option
        ///Whether the product was a merchandise or service.
        [<Config.Form>]ProductType: Create'EvidenceCanceledCanceledProductType option
        ///Result of cardholder's attempt to return the product.
        [<Config.Form>]ReturnStatus: Create'EvidenceCanceledCanceledReturnStatus option
        ///Date when the product was returned or attempted to be returned.
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
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Copy of the card statement showing that the product had already been paid for.
        [<Config.Form>]CardStatement: Choice<string,string> option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Copy of the receipt showing that the product had been paid for in cash.
        [<Config.Form>]CashReceipt: Choice<string,string> option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Image of the front and back of the check that was used to pay for the product.
        [<Config.Form>]CheckImage: Choice<string,string> option
        ///Explanation of why the cardholder is disputing this transaction.
        [<Config.Form>]Explanation: Choice<string,string> option
        ///Transaction (e.g., ipi_...) that the disputed transaction is a duplicate of. Of the two or more transactions that are copies of each other, this is original undisputed one.
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
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///Explanation of why the cardholder is disputing this transaction.
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
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///Explanation of why the cardholder is disputing this transaction.
        [<Config.Form>]Explanation: Choice<string,string> option
        ///Date when the product was received.
        [<Config.Form>]ReceivedAt: Choice<DateTime,string> option
        ///Description of the cardholder's attempt to return the product.
        [<Config.Form>]ReturnDescription: Choice<string,string> option
        ///Result of cardholder's attempt to return the product.
        [<Config.Form>]ReturnStatus: Create'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus option
        ///Date when the product was returned or attempted to be returned.
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

    type Create'EvidenceNotReceivedNotReceivedProductType =
    | Merchandise
    | Service

    type Create'EvidenceNotReceivedNotReceived = {
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///Date when the cardholder expected to receive the product.
        [<Config.Form>]ExpectedAt: Choice<DateTime,string> option
        ///Explanation of why the cardholder is disputing this transaction.
        [<Config.Form>]Explanation: Choice<string,string> option
        ///Description of the merchandise or service that was purchased.
        [<Config.Form>]ProductDescription: Choice<string,string> option
        ///Whether the product was a merchandise or service.
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
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///Explanation of why the cardholder is disputing this transaction.
        [<Config.Form>]Explanation: Choice<string,string> option
        ///Description of the merchandise or service that was purchased.
        [<Config.Form>]ProductDescription: Choice<string,string> option
        ///Whether the product was a merchandise or service.
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
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///Date when order was canceled.
        [<Config.Form>]CanceledAt: Choice<DateTime,string> option
        ///Reason for canceling the order.
        [<Config.Form>]CancellationReason: Choice<string,string> option
        ///Explanation of why the cardholder is disputing this transaction.
        [<Config.Form>]Explanation: Choice<string,string> option
        ///Date when the product was received.
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
    | NotReceived
    | Other
    | ServiceNotAsDescribed

    type Create'Evidence = {
        ///Evidence provided when `reason` is 'canceled'.
        [<Config.Form>]Canceled: Choice<Create'EvidenceCanceledCanceled,string> option
        ///Evidence provided when `reason` is 'duplicate'.
        [<Config.Form>]Duplicate: Choice<Create'EvidenceDuplicateDuplicate,string> option
        ///Evidence provided when `reason` is 'fraudulent'.
        [<Config.Form>]Fraudulent: Choice<Create'EvidenceFraudulentFraudulent,string> option
        ///Evidence provided when `reason` is 'merchandise_not_as_described'.
        [<Config.Form>]MerchandiseNotAsDescribed: Choice<Create'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed,string> option
        ///Evidence provided when `reason` is 'not_received'.
        [<Config.Form>]NotReceived: Choice<Create'EvidenceNotReceivedNotReceived,string> option
        ///Evidence provided when `reason` is 'other'.
        [<Config.Form>]Other: Choice<Create'EvidenceOtherOther,string> option
        ///The reason for filing the dispute. The evidence should be submitted in the field of the same name.
        [<Config.Form>]Reason: Create'EvidenceReason option
        ///Evidence provided when `reason` is 'service_not_as_described'.
        [<Config.Form>]ServiceNotAsDescribed: Choice<Create'EvidenceServiceNotAsDescribedServiceNotAsDescribed,string> option
    }
    with
        static member New(?canceled: Choice<Create'EvidenceCanceledCanceled,string>, ?duplicate: Choice<Create'EvidenceDuplicateDuplicate,string>, ?fraudulent: Choice<Create'EvidenceFraudulentFraudulent,string>, ?merchandiseNotAsDescribed: Choice<Create'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed,string>, ?notReceived: Choice<Create'EvidenceNotReceivedNotReceived,string>, ?other: Choice<Create'EvidenceOtherOther,string>, ?reason: Create'EvidenceReason, ?serviceNotAsDescribed: Choice<Create'EvidenceServiceNotAsDescribedServiceNotAsDescribed,string>) =
            {
                Canceled = canceled
                Duplicate = duplicate
                Fraudulent = fraudulent
                MerchandiseNotAsDescribed = merchandiseNotAsDescribed
                NotReceived = notReceived
                Other = other
                Reason = reason
                ServiceNotAsDescribed = serviceNotAsDescribed
            }

    type Create'Treasury = {
        ///The ID of the ReceivedDebit to initiate an Issuings dispute for.
        [<Config.Form>]ReceivedDebit: string option
    }
    with
        static member New(?receivedDebit: string) =
            {
                ReceivedDebit = receivedDebit
            }

    type CreateOptions = {
        ///The dispute amount in the card's currency and in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal). If not set, defaults to the full transaction amount.
        [<Config.Form>]Amount: int option
        ///Evidence provided for the dispute.
        [<Config.Form>]Evidence: Create'Evidence option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The ID of the issuing transaction to create a dispute for. For transaction on Treasury FinancialAccounts, use `treasury.received_debit`.
        [<Config.Form>]Transaction: string option
        ///Params for disputes related to Treasury FinancialAccounts
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

    ///<p>Creates an Issuing <code>Dispute</code> object. Individual pieces of evidence within the <code>evidence</code> object are optional at this point. Stripe only validates that required evidence is present during submission. Refer to <a href="/docs/issuing/purchases/disputes#dispute-reasons-and-evidence">Dispute reasons and evidence</a> for more details about evidence requirements.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/issuing/disputes"
        |> RestApi.postAsync<_, IssuingDispute> settings (Map.empty) options

    type RetrieveOptions = {
        [<Config.Path>]Dispute: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(dispute: string, ?expand: string list) =
            {
                Dispute = dispute
                Expand = expand
            }

    ///<p>Retrieves an Issuing <code>Dispute</code> object.</p>
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
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///Date when order was canceled.
        [<Config.Form>]CanceledAt: Choice<DateTime,string> option
        ///Whether the cardholder was provided with a cancellation policy.
        [<Config.Form>]CancellationPolicyProvided: Choice<bool,string> option
        ///Reason for canceling the order.
        [<Config.Form>]CancellationReason: Choice<string,string> option
        ///Date when the cardholder expected to receive the product.
        [<Config.Form>]ExpectedAt: Choice<DateTime,string> option
        ///Explanation of why the cardholder is disputing this transaction.
        [<Config.Form>]Explanation: Choice<string,string> option
        ///Description of the merchandise or service that was purchased.
        [<Config.Form>]ProductDescription: Choice<string,string> option
        ///Whether the product was a merchandise or service.
        [<Config.Form>]ProductType: Update'EvidenceCanceledCanceledProductType option
        ///Result of cardholder's attempt to return the product.
        [<Config.Form>]ReturnStatus: Update'EvidenceCanceledCanceledReturnStatus option
        ///Date when the product was returned or attempted to be returned.
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
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Copy of the card statement showing that the product had already been paid for.
        [<Config.Form>]CardStatement: Choice<string,string> option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Copy of the receipt showing that the product had been paid for in cash.
        [<Config.Form>]CashReceipt: Choice<string,string> option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Image of the front and back of the check that was used to pay for the product.
        [<Config.Form>]CheckImage: Choice<string,string> option
        ///Explanation of why the cardholder is disputing this transaction.
        [<Config.Form>]Explanation: Choice<string,string> option
        ///Transaction (e.g., ipi_...) that the disputed transaction is a duplicate of. Of the two or more transactions that are copies of each other, this is original undisputed one.
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
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///Explanation of why the cardholder is disputing this transaction.
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
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///Explanation of why the cardholder is disputing this transaction.
        [<Config.Form>]Explanation: Choice<string,string> option
        ///Date when the product was received.
        [<Config.Form>]ReceivedAt: Choice<DateTime,string> option
        ///Description of the cardholder's attempt to return the product.
        [<Config.Form>]ReturnDescription: Choice<string,string> option
        ///Result of cardholder's attempt to return the product.
        [<Config.Form>]ReturnStatus: Update'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus option
        ///Date when the product was returned or attempted to be returned.
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

    type Update'EvidenceNotReceivedNotReceivedProductType =
    | Merchandise
    | Service

    type Update'EvidenceNotReceivedNotReceived = {
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///Date when the cardholder expected to receive the product.
        [<Config.Form>]ExpectedAt: Choice<DateTime,string> option
        ///Explanation of why the cardholder is disputing this transaction.
        [<Config.Form>]Explanation: Choice<string,string> option
        ///Description of the merchandise or service that was purchased.
        [<Config.Form>]ProductDescription: Choice<string,string> option
        ///Whether the product was a merchandise or service.
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
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///Explanation of why the cardholder is disputing this transaction.
        [<Config.Form>]Explanation: Choice<string,string> option
        ///Description of the merchandise or service that was purchased.
        [<Config.Form>]ProductDescription: Choice<string,string> option
        ///Whether the product was a merchandise or service.
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
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Additional documentation supporting the dispute.
        [<Config.Form>]AdditionalDocumentation: Choice<string,string> option
        ///Date when order was canceled.
        [<Config.Form>]CanceledAt: Choice<DateTime,string> option
        ///Reason for canceling the order.
        [<Config.Form>]CancellationReason: Choice<string,string> option
        ///Explanation of why the cardholder is disputing this transaction.
        [<Config.Form>]Explanation: Choice<string,string> option
        ///Date when the product was received.
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
    | NotReceived
    | Other
    | ServiceNotAsDescribed

    type Update'Evidence = {
        ///Evidence provided when `reason` is 'canceled'.
        [<Config.Form>]Canceled: Choice<Update'EvidenceCanceledCanceled,string> option
        ///Evidence provided when `reason` is 'duplicate'.
        [<Config.Form>]Duplicate: Choice<Update'EvidenceDuplicateDuplicate,string> option
        ///Evidence provided when `reason` is 'fraudulent'.
        [<Config.Form>]Fraudulent: Choice<Update'EvidenceFraudulentFraudulent,string> option
        ///Evidence provided when `reason` is 'merchandise_not_as_described'.
        [<Config.Form>]MerchandiseNotAsDescribed: Choice<Update'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed,string> option
        ///Evidence provided when `reason` is 'not_received'.
        [<Config.Form>]NotReceived: Choice<Update'EvidenceNotReceivedNotReceived,string> option
        ///Evidence provided when `reason` is 'other'.
        [<Config.Form>]Other: Choice<Update'EvidenceOtherOther,string> option
        ///The reason for filing the dispute. The evidence should be submitted in the field of the same name.
        [<Config.Form>]Reason: Update'EvidenceReason option
        ///Evidence provided when `reason` is 'service_not_as_described'.
        [<Config.Form>]ServiceNotAsDescribed: Choice<Update'EvidenceServiceNotAsDescribedServiceNotAsDescribed,string> option
    }
    with
        static member New(?canceled: Choice<Update'EvidenceCanceledCanceled,string>, ?duplicate: Choice<Update'EvidenceDuplicateDuplicate,string>, ?fraudulent: Choice<Update'EvidenceFraudulentFraudulent,string>, ?merchandiseNotAsDescribed: Choice<Update'EvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed,string>, ?notReceived: Choice<Update'EvidenceNotReceivedNotReceived,string>, ?other: Choice<Update'EvidenceOtherOther,string>, ?reason: Update'EvidenceReason, ?serviceNotAsDescribed: Choice<Update'EvidenceServiceNotAsDescribedServiceNotAsDescribed,string>) =
            {
                Canceled = canceled
                Duplicate = duplicate
                Fraudulent = fraudulent
                MerchandiseNotAsDescribed = merchandiseNotAsDescribed
                NotReceived = notReceived
                Other = other
                Reason = reason
                ServiceNotAsDescribed = serviceNotAsDescribed
            }

    type UpdateOptions = {
        [<Config.Path>]Dispute: string
        ///The dispute amount in the card's currency and in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal).
        [<Config.Form>]Amount: int option
        ///Evidence provided for the dispute.
        [<Config.Form>]Evidence: Update'Evidence option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
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

    ///<p>Updates the specified Issuing <code>Dispute</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged. Properties on the <code>evidence</code> object can be unset by passing in an empty string.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/issuing/disputes/{options.Dispute}"
        |> RestApi.postAsync<_, IssuingDispute> settings (Map.empty) options

module IssuingDisputesSubmit =

    type SubmitOptions = {
        [<Config.Path>]Dispute: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(dispute: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Dispute = dispute
                Expand = expand
                Metadata = metadata
            }

    ///<p>Submits an Issuing <code>Dispute</code> to the card network. Stripe validates that all evidence fields required for the dispute’s reason are present. For more details, see <a href="/docs/issuing/purchases/disputes#dispute-reasons-and-evidence">Dispute reasons and evidence</a>.</p>
    let Submit settings (options: SubmitOptions) =
        $"/v1/issuing/disputes/{options.Dispute}/submit"
        |> RestApi.postAsync<_, IssuingDispute> settings (Map.empty) options

module IssuingTransactions =

    type ListOptions = {
        ///Only return transactions that belong to the given card.
        [<Config.Query>]Card: string option
        ///Only return transactions that belong to the given cardholder.
        [<Config.Query>]Cardholder: string option
        ///Only return transactions that were created during the given date interval.
        [<Config.Query>]Created: int option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///Only return transactions that have the given type. One of `capture` or `refund`.
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

    ///<p>Returns a list of Issuing <code>Transaction</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("card", options.Card |> box); ("cardholder", options.Cardholder |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("type", options.Type |> box)] |> Map.ofList
        $"/v1/issuing/transactions"
        |> RestApi.getAsync<IssuingTransaction list> settings qs

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Transaction: string
    }
    with
        static member New(transaction: string, ?expand: string list) =
            {
                Expand = expand
                Transaction = transaction
            }

    ///<p>Retrieves an Issuing <code>Transaction</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/issuing/transactions/{options.Transaction}"
        |> RestApi.getAsync<IssuingTransaction> settings qs

    type UpdateOptions = {
        [<Config.Path>]Transaction: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(transaction: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Transaction = transaction
                Expand = expand
                Metadata = metadata
            }

    ///<p>Updates the specified Issuing <code>Transaction</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/issuing/transactions/{options.Transaction}"
        |> RestApi.postAsync<_, IssuingTransaction> settings (Map.empty) options
