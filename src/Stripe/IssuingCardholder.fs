namespace Stripe.IssuingCardholder

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.FundingInstructions

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type IssuingCardholderAddress = { Address: Address }

[<Struct>]
type IssuingCardholderAuthorizationControlsAllowedCardPresences =
    | NotPresent
    | Present

type IssuingCardholderAuthorizationControlsAllowedCategories =
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

[<Struct>]
type IssuingCardholderAuthorizationControlsBlockedCardPresences =
    | NotPresent
    | Present

type IssuingCardholderAuthorizationControlsBlockedCategories =
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

type IssuingCardholderSpendingLimitCategories =
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

type IssuingCardholderSpendingLimitInterval =
    | AllTime
    | Daily
    | Monthly
    | PerAuthorization
    | Weekly
    | Yearly

type IssuingCardholderSpendingLimit =
    {
        /// Maximum amount allowed to spend per interval. This amount is in the card's currency and in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).
        Amount: int
        /// Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) this limit applies to. Omitting this field will apply the limit to all categories.
        Categories: IssuingCardholderSpendingLimitCategories list option
        /// Interval (or event) to which the amount applies.
        Interval: IssuingCardholderSpendingLimitInterval
    }

type IssuingCardholderAuthorizationControls =
    {
        /// Array of card presence statuses from which authorizations will be allowed. Possible options are `present`, `not_present`. All other statuses will be blocked. Cannot be set with `blocked_card_presences`. Provide an empty value to unset this control.
        AllowedCardPresences: IssuingCardholderAuthorizationControlsAllowedCardPresences list option
        /// Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) of authorizations to allow. All other categories will be blocked. Cannot be set with `blocked_categories`.
        AllowedCategories: IssuingCardholderAuthorizationControlsAllowedCategories list option
        /// Array of strings containing representing countries from which authorizations will be allowed. Authorizations from merchants in all other countries will be declined. Country codes should be ISO 3166 alpha-2 country codes (e.g. `US`). Cannot be set with `blocked_merchant_countries`. Provide an empty value to unset this control.
        AllowedMerchantCountries: string list option
        /// Array of card presence statuses from which authorizations will be declined. Possible options are `present`, `not_present`. Cannot be set with `allowed_card_presences`. Provide an empty value to unset this control.
        BlockedCardPresences: IssuingCardholderAuthorizationControlsBlockedCardPresences list option
        /// Array of strings containing [categories](https://docs.stripe.com/api#issuing_authorization_object-merchant_data-category) of authorizations to decline. All other categories will be allowed. Cannot be set with `allowed_categories`.
        BlockedCategories: IssuingCardholderAuthorizationControlsBlockedCategories list option
        /// Array of strings containing representing countries from which authorizations will be declined. Country codes should be ISO 3166 alpha-2 country codes (e.g. `US`). Cannot be set with `allowed_merchant_countries`. Provide an empty value to unset this control.
        BlockedMerchantCountries: string list option
        /// Limit spending with amount-based rules that apply across this cardholder's cards.
        SpendingLimits: IssuingCardholderSpendingLimit list option
        /// Currency of the amounts within `spending_limits`.
        SpendingLimitsCurrency: IsoTypes.IsoCurrencyCode option
    }

type IssuingCardholderCompany =
    {
        /// Whether the company's business ID number was provided.
        TaxIdProvided: bool
    }

type IssuingCardholderUserTermsAcceptance =
    {
        /// The Unix timestamp marking when the cardholder accepted the Authorized User Terms.
        Date: DateTime option
        /// The IP address from which the cardholder accepted the Authorized User Terms.
        Ip: string option
        /// The user agent of the browser from which the cardholder accepted the Authorized User Terms.
        UserAgent: string option
    }

type IssuingCardholderCardIssuing =
    {
        /// Information about cardholder acceptance of Celtic [Authorized User Terms](https://stripe.com/docs/issuing/cards#accept-authorized-user-terms). Required for cards backed by a Celtic program.
        UserTermsAcceptance: IssuingCardholderUserTermsAcceptance option
    }

type IssuingCardholderIndividualDob =
    {
        /// The day of birth, between 1 and 31.
        Day: int option
        /// The month of birth, between 1 and 12.
        Month: int option
        /// The four-digit year of birth.
        Year: int option
    }

type IssuingCardholderIdDocument =
    {
        /// The back of a document returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`.
        Back: string option
        /// The front of a document returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`.
        Front: string option
    }

type IssuingCardholderVerification =
    {
        /// An identifying document, either a passport or local ID card.
        Document: IssuingCardholderIdDocument option
    }

type IssuingCardholderIndividual =
    {
        /// Information related to the card_issuing program for this cardholder.
        CardIssuing: IssuingCardholderCardIssuing option
        /// The date of birth of this cardholder.
        Dob: IssuingCardholderIndividualDob option
        /// The first name of this cardholder. Required before activating Cards. This field cannot contain any numbers, special characters (except periods, commas, hyphens, spaces and apostrophes) or non-latin letters.
        FirstName: string option
        /// The last name of this cardholder. Required before activating Cards. This field cannot contain any numbers, special characters (except periods, commas, hyphens, spaces and apostrophes) or non-latin letters.
        LastName: string option
        /// Government-issued ID document for this cardholder.
        Verification: IssuingCardholderVerification option
    }

[<Struct>]
type IssuingCardholderPreferredLocales =
    | De
    | En
    | Es
    | Fr
    | It

[<Struct>]
type IssuingCardholderRequirementsDisabledReason =
    | Listed
    | [<JsonPropertyName("rejected.listed")>] RejectedListed
    | [<JsonPropertyName("requirements.past_due")>] RequirementsPastDue
    | UnderReview

type IssuingCardholderRequirementsPastDue =
    | [<JsonPropertyName("company.tax_id")>] CompanyTaxId
    | [<JsonPropertyName("individual.card_issuing.user_terms_acceptance.date")>] IndividualCardIssuingUserTermsAcceptanceDate
    | [<JsonPropertyName("individual.card_issuing.user_terms_acceptance.ip")>] IndividualCardIssuingUserTermsAcceptanceIp
    | [<JsonPropertyName("individual.dob.day")>] IndividualDobDay
    | [<JsonPropertyName("individual.dob.month")>] IndividualDobMonth
    | [<JsonPropertyName("individual.dob.year")>] IndividualDobYear
    | [<JsonPropertyName("individual.first_name")>] IndividualFirstName
    | [<JsonPropertyName("individual.last_name")>] IndividualLastName
    | [<JsonPropertyName("individual.verification.document")>] IndividualVerificationDocument

type IssuingCardholderRequirements =
    {
        /// If `disabled_reason` is present, all cards will decline authorizations with `cardholder_verification_required` reason.
        DisabledReason: IssuingCardholderRequirementsDisabledReason option
        /// Array of fields that need to be collected in order to verify and re-enable the cardholder.
        PastDue: IssuingCardholderRequirementsPastDue list option
    }

[<Struct>]
type IssuingCardholderStatus =
    | Active
    | Blocked
    | Inactive

[<Struct>]
type IssuingCardholderType =
    | Company
    | Individual

/// An Issuing `Cardholder` object represents an individual or business entity who is [issued](https://docs.stripe.com/issuing) cards.
/// Related guide: [How to create a cardholder](https://docs.stripe.com/issuing/cards/virtual/issue-cards#create-cardholder)
type IssuingCardholder =
    {
        Billing: IssuingCardholderAddress
        /// Additional information about a `company` cardholder.
        Company: IssuingCardholderCompany option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// The cardholder's email address.
        Email: string option
        /// Unique identifier for the object.
        Id: string
        /// Additional information about an `individual` cardholder.
        Individual: IssuingCardholderIndividual option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// The cardholder's name. This will be printed on cards issued to them.
        Name: string
        /// The cardholder's phone number. This is required for all cardholders who will be creating EU cards. See the [3D Secure documentation](https://docs.stripe.com/issuing/3d-secure#when-is-3d-secure-applied) for more details.
        PhoneNumber: string option
        /// The cardholder’s preferred locales (languages), ordered by preference. Locales can be `da`, `de`, `en`, `es`, `fr`, `it`, `pl`, or `sv`.
        ///  This changes the language of the [3D Secure flow](https://docs.stripe.com/issuing/3d-secure) and one-time password messages sent to the cardholder.
        PreferredLocales: IssuingCardholderPreferredLocales list option
        Requirements: IssuingCardholderRequirements
        /// Rules that control spending across this cardholder's cards. Refer to our [documentation](https://docs.stripe.com/issuing/controls/spending-controls) for more details.
        SpendingControls: IssuingCardholderAuthorizationControls option
        /// Specifies whether to permit authorizations on this cardholder's cards.
        Status: IssuingCardholderStatus
        /// One of `individual` or `company`. See [Choose a cardholder type](https://docs.stripe.com/issuing/other/choose-cardholder) for more details.
        Type: IssuingCardholderType
    }

module IssuingCardholder =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "issuing.cardholder"

/// Occurs whenever a cardholder is updated.
type IssuingCardholderUpdated = { Object: IssuingCardholder }

/// Occurs whenever a cardholder is created.
type IssuingCardholderCreated = { Object: IssuingCardholder }

