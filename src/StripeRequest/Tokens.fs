namespace StripeRequest.Tokens

open FunStripe
open System.Text.Json.Serialization
open Stripe.PaymentMethod
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
module Tokens =

    type Create'AccountBusinessType =
        | Company
        | GovernmentEntity
        | Individual
        | NonProfit

    type Create'AccountCompanyAddress =
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

    type Create'AccountCompanyAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'AccountCompanyAddressKana =
        {
            /// City or ward.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Block or building number.
            [<Config.Form>]
            Line1: string option
            /// Building details.
            [<Config.Form>]
            Line2: string option
            /// Postal code.
            [<Config.Form>]
            PostalCode: string option
            /// Prefecture.
            [<Config.Form>]
            State: string option
            /// Town or cho-me.
            [<Config.Form>]
            Town: string option
        }

    type Create'AccountCompanyAddressKana with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'AccountCompanyAddressKanji =
        {
            /// City or ward.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Block or building number.
            [<Config.Form>]
            Line1: string option
            /// Building details.
            [<Config.Form>]
            Line2: string option
            /// Postal code.
            [<Config.Form>]
            PostalCode: string option
            /// Prefecture.
            [<Config.Form>]
            State: string option
            /// Town or cho-me.
            [<Config.Form>]
            Town: string option
        }

    type Create'AccountCompanyAddressKanji with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'AccountCompanyDirectorshipDeclaration =
        {
            /// The Unix timestamp marking when the directorship declaration attestation was made.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the directorship declaration attestation was made.
            [<Config.Form>]
            Ip: string option
            /// The user agent of the browser from which the directorship declaration attestation was made.
            [<Config.Form>]
            UserAgent: string option
        }

    type Create'AccountCompanyDirectorshipDeclaration with
        static member New(?date: DateTime, ?ip: string, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Create'AccountCompanyOwnershipDeclaration =
        {
            /// The Unix timestamp marking when the beneficial owner attestation was made.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the beneficial owner attestation was made.
            [<Config.Form>]
            Ip: string option
            /// The user agent of the browser from which the beneficial owner attestation was made.
            [<Config.Form>]
            UserAgent: string option
        }

    type Create'AccountCompanyOwnershipDeclaration with
        static member New(?date: DateTime, ?ip: string, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Create'AccountCompanyOwnershipExemptionReason =
        | QualifiedEntityExceedsOwnershipThreshold
        | QualifiesAsFinancialInstitution

    type Create'AccountCompanyRegistrationDateRegistrationDateSpecs =
        {
            /// The day of registration, between 1 and 31.
            [<Config.Form>]
            Day: int option
            /// The month of registration, between 1 and 12.
            [<Config.Form>]
            Month: int option
            /// The four-digit year of registration.
            [<Config.Form>]
            Year: int option
        }

    type Create'AccountCompanyRegistrationDateRegistrationDateSpecs with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Create'AccountCompanyRepresentativeDeclaration =
        {
            /// The Unix timestamp marking when the representative declaration attestation was made.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the representative declaration attestation was made.
            [<Config.Form>]
            Ip: string option
            /// The user agent of the browser from which the representative declaration attestation was made.
            [<Config.Form>]
            UserAgent: string option
        }

    type Create'AccountCompanyRepresentativeDeclaration with
        static member New(?date: DateTime, ?ip: string, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Create'AccountCompanyStructure =
        | FreeZoneEstablishment
        | FreeZoneLlc
        | GovernmentInstrumentality
        | GovernmentalUnit
        | IncorporatedNonProfit
        | IncorporatedPartnership
        | LimitedLiabilityPartnership
        | Llc
        | MultiMemberLlc
        | PrivateCompany
        | PrivateCorporation
        | PrivatePartnership
        | PublicCompany
        | PublicCorporation
        | PublicPartnership
        | RegisteredCharity
        | SingleMemberLlc
        | SoleEstablishment
        | SoleProprietorship
        | TaxExemptGovernmentInstrumentality
        | UnincorporatedAssociation
        | UnincorporatedNonProfit
        | UnincorporatedPartnership

    type Create'AccountCompanyVerificationDocument =
        {
            /// The back of a document returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `additional_verification`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Back: string option
            /// The front of a document returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `additional_verification`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Front: string option
        }

    type Create'AccountCompanyVerificationDocument with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Create'AccountCompanyVerification =
        {
            /// A document verifying the business.
            [<Config.Form>]
            Document: Create'AccountCompanyVerificationDocument option
        }

    type Create'AccountCompanyVerification with
        static member New(?document: Create'AccountCompanyVerificationDocument) =
            {
                Document = document
            }

    type Create'AccountCompany =
        {
            /// The company's primary address.
            [<Config.Form>]
            Address: Create'AccountCompanyAddress option
            /// The Kana variation of the company's primary address (Japan only).
            [<Config.Form>]
            AddressKana: Create'AccountCompanyAddressKana option
            /// The Kanji variation of the company's primary address (Japan only).
            [<Config.Form>]
            AddressKanji: Create'AccountCompanyAddressKanji option
            /// Whether the company's directors have been provided. Set this Boolean to `true` after creating all the company's directors with [the Persons API](/api/persons) for accounts with a `relationship.director` requirement. This value is not automatically set to `true` after creating directors, so it needs to be updated to indicate all directors have been provided.
            [<Config.Form>]
            DirectorsProvided: bool option
            /// This hash is used to attest that the directors information provided to Stripe is both current and correct.
            [<Config.Form>]
            DirectorshipDeclaration: Create'AccountCompanyDirectorshipDeclaration option
            /// Whether the company's executives have been provided. Set this Boolean to `true` after creating all the company's executives with [the Persons API](/api/persons) for accounts with a `relationship.executive` requirement.
            [<Config.Form>]
            ExecutivesProvided: bool option
            /// The export license ID number of the company, also referred as Import Export Code (India only).
            [<Config.Form>]
            ExportLicenseId: string option
            /// The purpose code to use for export transactions (India only).
            [<Config.Form>]
            ExportPurposeCode: string option
            /// The company's legal name.
            [<Config.Form>]
            Name: string option
            /// The Kana variation of the company's legal name (Japan only).
            [<Config.Form>]
            NameKana: string option
            /// The Kanji variation of the company's legal name (Japan only).
            [<Config.Form>]
            NameKanji: string option
            /// Whether the company's owners have been provided. Set this Boolean to `true` after creating all the company's owners with [the Persons API](/api/persons) for accounts with a `relationship.owner` requirement.
            [<Config.Form>]
            OwnersProvided: bool option
            /// This hash is used to attest that the beneficial owner information provided to Stripe is both current and correct.
            [<Config.Form>]
            OwnershipDeclaration: Create'AccountCompanyOwnershipDeclaration option
            /// Whether the user described by the data in the token has been shown the Ownership Declaration and indicated that it is correct.
            [<Config.Form>]
            OwnershipDeclarationShownAndSigned: bool option
            /// This value is used to determine if a business is exempt from providing ultimate beneficial owners. See [this support article](https://support.stripe.com/questions/exemption-from-providing-ownership-details) and [changelog](https://docs.stripe.com/changelog/acacia/2025-01-27/ownership-exemption-reason-accounts-api) for more details.
            [<Config.Form>]
            OwnershipExemptionReason: Create'AccountCompanyOwnershipExemptionReason option
            /// The company's phone number (used for verification).
            [<Config.Form>]
            Phone: string option
            /// When the business was incorporated or registered.
            [<Config.Form>]
            RegistrationDate: Choice<Create'AccountCompanyRegistrationDateRegistrationDateSpecs,string> option
            /// The identification number given to a company when it is registered or incorporated, if distinct from the identification number used for filing taxes. (Examples are the CIN for companies and LLP IN for partnerships in India, and the Company Registration Number in Hong Kong).
            [<Config.Form>]
            RegistrationNumber: string option
            /// This hash is used to attest that the representative is authorized to act as the representative of their legal entity.
            [<Config.Form>]
            RepresentativeDeclaration: Create'AccountCompanyRepresentativeDeclaration option
            /// The category identifying the legal structure of the company or legal entity. See [Business structure](/connect/identity-verification#business-structure) for more details. Pass an empty string to unset this value.
            [<Config.Form>]
            Structure: Create'AccountCompanyStructure option
            /// The business ID number of the company, as appropriate for the company’s country. (Examples are an Employer ID Number in the U.S., a Business Number in Canada, or a Company Number in the UK.)
            [<Config.Form>]
            TaxId: string option
            /// The jurisdiction in which the `tax_id` is registered (Germany-based companies only).
            [<Config.Form>]
            TaxIdRegistrar: string option
            /// The VAT number of the company.
            [<Config.Form>]
            VatId: string option
            /// Information on the verification state of the company.
            [<Config.Form>]
            Verification: Create'AccountCompanyVerification option
        }

    type Create'AccountCompany with
        static member New(?address: Create'AccountCompanyAddress, ?addressKana: Create'AccountCompanyAddressKana, ?addressKanji: Create'AccountCompanyAddressKanji, ?directorsProvided: bool, ?directorshipDeclaration: Create'AccountCompanyDirectorshipDeclaration, ?executivesProvided: bool, ?exportLicenseId: string, ?exportPurposeCode: string, ?name: string, ?nameKana: string, ?nameKanji: string, ?ownersProvided: bool, ?ownershipDeclaration: Create'AccountCompanyOwnershipDeclaration, ?ownershipDeclarationShownAndSigned: bool, ?ownershipExemptionReason: Create'AccountCompanyOwnershipExemptionReason, ?phone: string, ?registrationDate: Choice<Create'AccountCompanyRegistrationDateRegistrationDateSpecs,string>, ?registrationNumber: string, ?representativeDeclaration: Create'AccountCompanyRepresentativeDeclaration, ?structure: Create'AccountCompanyStructure, ?taxId: string, ?taxIdRegistrar: string, ?vatId: string, ?verification: Create'AccountCompanyVerification) =
            {
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                DirectorsProvided = directorsProvided
                DirectorshipDeclaration = directorshipDeclaration
                ExecutivesProvided = executivesProvided
                ExportLicenseId = exportLicenseId
                ExportPurposeCode = exportPurposeCode
                Name = name
                NameKana = nameKana
                NameKanji = nameKanji
                OwnersProvided = ownersProvided
                OwnershipDeclaration = ownershipDeclaration
                OwnershipDeclarationShownAndSigned = ownershipDeclarationShownAndSigned
                OwnershipExemptionReason = ownershipExemptionReason
                Phone = phone
                RegistrationDate = registrationDate
                RegistrationNumber = registrationNumber
                RepresentativeDeclaration = representativeDeclaration
                Structure = structure
                TaxId = taxId
                TaxIdRegistrar = taxIdRegistrar
                VatId = vatId
                Verification = verification
            }

    type Create'AccountIndividualAddress =
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

    type Create'AccountIndividualAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'AccountIndividualAddressKana =
        {
            /// City or ward.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Block or building number.
            [<Config.Form>]
            Line1: string option
            /// Building details.
            [<Config.Form>]
            Line2: string option
            /// Postal code.
            [<Config.Form>]
            PostalCode: string option
            /// Prefecture.
            [<Config.Form>]
            State: string option
            /// Town or cho-me.
            [<Config.Form>]
            Town: string option
        }

    type Create'AccountIndividualAddressKana with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'AccountIndividualAddressKanji =
        {
            /// City or ward.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Block or building number.
            [<Config.Form>]
            Line1: string option
            /// Building details.
            [<Config.Form>]
            Line2: string option
            /// Postal code.
            [<Config.Form>]
            PostalCode: string option
            /// Prefecture.
            [<Config.Form>]
            State: string option
            /// Town or cho-me.
            [<Config.Form>]
            Town: string option
        }

    type Create'AccountIndividualAddressKanji with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'AccountIndividualDobDateOfBirthSpecs =
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

    type Create'AccountIndividualDobDateOfBirthSpecs with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Create'AccountIndividualPoliticalExposure =
        | Existing
        | [<JsonPropertyName("none")>] None'

    type Create'AccountIndividualRegisteredAddress =
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

    type Create'AccountIndividualRegisteredAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'AccountIndividualRelationship =
        {
            /// Whether the person is a director of the account's legal entity. Directors are typically members of the governing board of the company, or responsible for ensuring the company meets its regulatory obligations.
            [<Config.Form>]
            Director: bool option
            /// Whether the person has significant responsibility to control, manage, or direct the organization.
            [<Config.Form>]
            Executive: bool option
            /// Whether the person is an owner of the account’s legal entity.
            [<Config.Form>]
            Owner: bool option
            /// The percent owned by the person of the account's legal entity.
            [<Config.Form>]
            PercentOwnership: Choice<decimal,string> option
            /// The person's title (e.g., CEO, Support Engineer).
            [<Config.Form>]
            Title: string option
        }

    type Create'AccountIndividualRelationship with
        static member New(?director: bool, ?executive: bool, ?owner: bool, ?percentOwnership: Choice<decimal,string>, ?title: string) =
            {
                Director = director
                Executive = executive
                Owner = owner
                PercentOwnership = percentOwnership
                Title = title
            }

    type Create'AccountIndividualVerificationAdditionalDocument =
        {
            /// The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Back: string option
            /// The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Front: string option
        }

    type Create'AccountIndividualVerificationAdditionalDocument with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Create'AccountIndividualVerificationDocument =
        {
            /// The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Back: string option
            /// The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Front: string option
        }

    type Create'AccountIndividualVerificationDocument with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Create'AccountIndividualVerification =
        {
            /// A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.
            [<Config.Form>]
            AdditionalDocument: Create'AccountIndividualVerificationAdditionalDocument option
            /// An identifying document, either a passport or local ID card.
            [<Config.Form>]
            Document: Create'AccountIndividualVerificationDocument option
        }

    type Create'AccountIndividualVerification with
        static member New(?additionalDocument: Create'AccountIndividualVerificationAdditionalDocument, ?document: Create'AccountIndividualVerificationDocument) =
            {
                AdditionalDocument = additionalDocument
                Document = document
            }

    type Create'AccountIndividual =
        {
            /// The individual's primary address.
            [<Config.Form>]
            Address: Create'AccountIndividualAddress option
            /// The Kana variation of the individual's primary address (Japan only).
            [<Config.Form>]
            AddressKana: Create'AccountIndividualAddressKana option
            /// The Kanji variation of the individual's primary address (Japan only).
            [<Config.Form>]
            AddressKanji: Create'AccountIndividualAddressKanji option
            /// The individual's date of birth.
            [<Config.Form>]
            Dob: Choice<Create'AccountIndividualDobDateOfBirthSpecs,string> option
            /// The individual's email address.
            [<Config.Form>]
            Email: string option
            /// The individual's first name.
            [<Config.Form>]
            FirstName: string option
            /// The Kana variation of the individual's first name (Japan only).
            [<Config.Form>]
            FirstNameKana: string option
            /// The Kanji variation of the individual's first name (Japan only).
            [<Config.Form>]
            FirstNameKanji: string option
            /// A list of alternate names or aliases that the individual is known by.
            [<Config.Form>]
            FullNameAliases: Choice<string list,string> option
            /// The individual's gender
            [<Config.Form>]
            Gender: string option
            /// The government-issued ID number of the individual, as appropriate for the representative's country. (Examples are a Social Security Number in the U.S., or a Social Insurance Number in Canada). Instead of the number itself, you can also provide a [PII token created with Stripe.js](/js/tokens/create_token?type=pii).
            [<Config.Form>]
            IdNumber: string option
            /// The government-issued secondary ID number of the individual, as appropriate for the representative's country, will be used for enhanced verification checks. In Thailand, this would be the laser code found on the back of an ID card. Instead of the number itself, you can also provide a [PII token created with Stripe.js](/js/tokens/create_token?type=pii).
            [<Config.Form>]
            IdNumberSecondary: string option
            /// The individual's last name.
            [<Config.Form>]
            LastName: string option
            /// The Kana variation of the individual's last name (Japan only).
            [<Config.Form>]
            LastNameKana: string option
            /// The Kanji variation of the individual's last name (Japan only).
            [<Config.Form>]
            LastNameKanji: string option
            /// The individual's maiden name.
            [<Config.Form>]
            MaidenName: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The individual's phone number.
            [<Config.Form>]
            Phone: string option
            /// Indicates if the person or any of their representatives, family members, or other closely related persons, declares that they hold or have held an important public job or function, in any jurisdiction.
            [<Config.Form>]
            PoliticalExposure: Create'AccountIndividualPoliticalExposure option
            /// The individual's registered address.
            [<Config.Form>]
            RegisteredAddress: Create'AccountIndividualRegisteredAddress option
            /// Describes the person’s relationship to the account.
            [<Config.Form>]
            Relationship: Create'AccountIndividualRelationship option
            /// The last four digits of the individual's Social Security Number (U.S. only).
            [<Config.Form>]
            SsnLast4: string option
            /// The individual's verification document information.
            [<Config.Form>]
            Verification: Create'AccountIndividualVerification option
        }

    type Create'AccountIndividual with
        static member New(?address: Create'AccountIndividualAddress, ?addressKana: Create'AccountIndividualAddressKana, ?addressKanji: Create'AccountIndividualAddressKanji, ?dob: Choice<Create'AccountIndividualDobDateOfBirthSpecs,string>, ?email: string, ?firstName: string, ?firstNameKana: string, ?firstNameKanji: string, ?fullNameAliases: Choice<string list,string>, ?gender: string, ?idNumber: string, ?idNumberSecondary: string, ?lastName: string, ?lastNameKana: string, ?lastNameKanji: string, ?maidenName: string, ?metadata: Map<string, string>, ?phone: string, ?politicalExposure: Create'AccountIndividualPoliticalExposure, ?registeredAddress: Create'AccountIndividualRegisteredAddress, ?relationship: Create'AccountIndividualRelationship, ?ssnLast4: string, ?verification: Create'AccountIndividualVerification) =
            {
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                Dob = dob
                Email = email
                FirstName = firstName
                FirstNameKana = firstNameKana
                FirstNameKanji = firstNameKanji
                FullNameAliases = fullNameAliases
                Gender = gender
                IdNumber = idNumber
                IdNumberSecondary = idNumberSecondary
                LastName = lastName
                LastNameKana = lastNameKana
                LastNameKanji = lastNameKanji
                MaidenName = maidenName
                Metadata = metadata
                Phone = phone
                PoliticalExposure = politicalExposure
                RegisteredAddress = registeredAddress
                Relationship = relationship
                SsnLast4 = ssnLast4
                Verification = verification
            }

    type Create'Account =
        {
            /// The business type.
            [<Config.Form>]
            BusinessType: Create'AccountBusinessType option
            /// Information about the company or business.
            [<Config.Form>]
            Company: Create'AccountCompany option
            /// Information about the person represented by the account.
            [<Config.Form>]
            Individual: Create'AccountIndividual option
            /// Whether the user described by the data in the token has been shown [the Stripe Connected Account Agreement](/connect/account-tokens#stripe-connected-account-agreement). When creating an account token to create a new Connect account, this value must be `true`.
            [<Config.Form>]
            TosShownAndAccepted: bool option
        }

    type Create'Account with
        static member New(?businessType: Create'AccountBusinessType, ?company: Create'AccountCompany, ?individual: Create'AccountIndividual, ?tosShownAndAccepted: bool) =
            {
                BusinessType = businessType
                Company = company
                Individual = individual
                TosShownAndAccepted = tosShownAndAccepted
            }

    type Create'BankAccountAccountHolderType =
        | Company
        | Individual

    type Create'BankAccountAccountType =
        | Checking
        | Futsu
        | Savings
        | Toza

    type Create'BankAccount =
        {
            /// The name of the person or business that owns the bank account. This field is required when attaching the bank account to a `Customer` object.
            [<Config.Form>]
            AccountHolderName: string option
            /// The type of entity that holds the account. It can be `company` or `individual`. This field is required when attaching the bank account to a `Customer` object.
            [<Config.Form>]
            AccountHolderType: Create'BankAccountAccountHolderType option
            /// The account number for the bank account, in string form. Must be a checking account.
            [<Config.Form>]
            AccountNumber: string option
            /// The bank account type. This can only be `checking` or `savings` in most countries. In Japan, this can only be `futsu` or `toza`.
            [<Config.Form>]
            AccountType: Create'BankAccountAccountType option
            /// The country in which the bank account is located.
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// The currency the bank account is in. This must be a country/currency pairing that [Stripe supports.](https://docs.stripe.com/payouts)
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of a Payment Method with a `type` of `us_bank_account`. The Payment Method's bank account information will be copied and returned as a Bank Account Token. This parameter is exclusive with respect to all other parameters in the `bank_account` hash. You must include the top-level `customer` parameter if the Payment Method is attached to a `Customer` object. If the Payment Method is not attached to a `Customer` object, it will be consumed and cannot be used again. You may not use Payment Methods which were created by a Setup Intent with `attach_to_self=true`.
            [<Config.Form>]
            PaymentMethod: string option
            /// The routing number, sort code, or other country-appropriate institution number for the bank account. For US bank accounts, this is required and should be the ACH routing number, not the wire routing number. If you are providing an IBAN for `account_number`, this field is not required.
            [<Config.Form>]
            RoutingNumber: string option
        }

    type Create'BankAccount with
        static member New(?accountHolderName: string, ?accountHolderType: Create'BankAccountAccountHolderType, ?accountNumber: string, ?accountType: Create'BankAccountAccountType, ?country: IsoTypes.IsoCountryCode, ?currency: IsoTypes.IsoCurrencyCode, ?paymentMethod: string, ?routingNumber: string) =
            {
                AccountHolderName = accountHolderName
                AccountHolderType = accountHolderType
                AccountNumber = accountNumber
                AccountType = accountType
                Country = country
                Currency = currency
                PaymentMethod = paymentMethod
                RoutingNumber = routingNumber
            }

    type Create'CardCreditCardSpecsNetworksPreferred =
        | CartesBancaires
        | Mastercard
        | Visa

    type Create'CardCreditCardSpecsNetworks =
        {
            /// The customer's preferred card network for co-branded cards. Supports `cartes_bancaires`, `mastercard`, or `visa`. Selection of a network that does not apply to the card will be stored as `invalid_preference` on the card.
            [<Config.Form>]
            Preferred: Create'CardCreditCardSpecsNetworksPreferred option
        }

    type Create'CardCreditCardSpecsNetworks with
        static member New(?preferred: Create'CardCreditCardSpecsNetworksPreferred) =
            {
                Preferred = preferred
            }

    type Create'CardCreditCardSpecs =
        {
            /// City / District / Suburb / Town / Village.
            [<Config.Form>]
            AddressCity: string option
            /// Billing address country, if provided.
            [<Config.Form>]
            AddressCountry: IsoTypes.IsoCountryCode option
            /// Address line 1 (Street address / PO Box / Company name).
            [<Config.Form>]
            AddressLine1: string option
            /// Address line 2 (Apartment / Suite / Unit / Building).
            [<Config.Form>]
            AddressLine2: string option
            /// State / County / Province / Region.
            [<Config.Form>]
            AddressState: string option
            /// ZIP or postal code.
            [<Config.Form>]
            AddressZip: string option
            /// Required in order to add the card to an account; in all other cases, this parameter is not used. When added to an account, the card (which must be a debit card) can be used as a transfer destination for funds in this currency.
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// Card security code. Highly recommended to always include this value.
            [<Config.Form>]
            Cvc: string option
            /// Two-digit number representing the card's expiration month.
            [<Config.Form>]
            ExpMonth: string option
            /// Two- or four-digit number representing the card's expiration year.
            [<Config.Form>]
            ExpYear: string option
            /// Cardholder's full name.
            [<Config.Form>]
            Name: string option
            /// Contains information about card networks used to process the payment.
            [<Config.Form>]
            Networks: Create'CardCreditCardSpecsNetworks option
            /// The card number, as a string without any separators.
            [<Config.Form>]
            Number: string option
        }

    type Create'CardCreditCardSpecs with
        static member New(?addressCity: string, ?addressCountry: IsoTypes.IsoCountryCode, ?addressLine1: string, ?addressLine2: string, ?addressState: string, ?addressZip: string, ?currency: IsoTypes.IsoCurrencyCode, ?cvc: string, ?expMonth: string, ?expYear: string, ?name: string, ?networks: Create'CardCreditCardSpecsNetworks, ?number: string) =
            {
                AddressCity = addressCity
                AddressCountry = addressCountry
                AddressLine1 = addressLine1
                AddressLine2 = addressLine2
                AddressState = addressState
                AddressZip = addressZip
                Currency = currency
                Cvc = cvc
                ExpMonth = expMonth
                ExpYear = expYear
                Name = name
                Networks = networks
                Number = number
            }

    type Create'CvcUpdate =
        {
            /// The CVC value, in string form.
            [<Config.Form>]
            Cvc: string option
        }

    type Create'CvcUpdate with
        static member New(?cvc: string) =
            {
                Cvc = cvc
            }

    type Create'PersonAdditionalTosAcceptancesAccount =
        {
            /// The Unix timestamp marking when the account representative accepted the service agreement.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the account representative accepted the service agreement.
            [<Config.Form>]
            Ip: string option
            /// The user agent of the browser from which the account representative accepted the service agreement.
            [<Config.Form>]
            UserAgent: Choice<string,string> option
        }

    type Create'PersonAdditionalTosAcceptancesAccount with
        static member New(?date: DateTime, ?ip: string, ?userAgent: Choice<string,string>) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Create'PersonAdditionalTosAcceptances =
        {
            /// Details on the legal guardian's acceptance of the main Stripe service agreement.
            [<Config.Form>]
            Account: Create'PersonAdditionalTosAcceptancesAccount option
        }

    type Create'PersonAdditionalTosAcceptances with
        static member New(?account: Create'PersonAdditionalTosAcceptancesAccount) =
            {
                Account = account
            }

    type Create'PersonAddress =
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

    type Create'PersonAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'PersonAddressKana =
        {
            /// City or ward.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Block or building number.
            [<Config.Form>]
            Line1: string option
            /// Building details.
            [<Config.Form>]
            Line2: string option
            /// Postal code.
            [<Config.Form>]
            PostalCode: string option
            /// Prefecture.
            [<Config.Form>]
            State: string option
            /// Town or cho-me.
            [<Config.Form>]
            Town: string option
        }

    type Create'PersonAddressKana with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'PersonAddressKanji =
        {
            /// City or ward.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Block or building number.
            [<Config.Form>]
            Line1: string option
            /// Building details.
            [<Config.Form>]
            Line2: string option
            /// Postal code.
            [<Config.Form>]
            PostalCode: string option
            /// Prefecture.
            [<Config.Form>]
            State: string option
            /// Town or cho-me.
            [<Config.Form>]
            Town: string option
        }

    type Create'PersonAddressKanji with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'PersonDobDateOfBirthSpecs =
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

    type Create'PersonDobDateOfBirthSpecs with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Create'PersonDocumentsCompanyAuthorization =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: Choice<string,string> list option
        }

    type Create'PersonDocumentsCompanyAuthorization with
        static member New(?files: Choice<string,string> list) =
            {
                Files = files
            }

    type Create'PersonDocumentsPassport =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: Choice<string,string> list option
        }

    type Create'PersonDocumentsPassport with
        static member New(?files: Choice<string,string> list) =
            {
                Files = files
            }

    type Create'PersonDocumentsVisa =
        {
            /// One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.
            [<Config.Form>]
            Files: Choice<string,string> list option
        }

    type Create'PersonDocumentsVisa with
        static member New(?files: Choice<string,string> list) =
            {
                Files = files
            }

    type Create'PersonDocuments =
        {
            /// One or more documents that demonstrate proof that this person is authorized to represent the company.
            [<Config.Form>]
            CompanyAuthorization: Create'PersonDocumentsCompanyAuthorization option
            /// One or more documents showing the person's passport page with photo and personal data.
            [<Config.Form>]
            Passport: Create'PersonDocumentsPassport option
            /// One or more documents showing the person's visa required for living in the country where they are residing.
            [<Config.Form>]
            Visa: Create'PersonDocumentsVisa option
        }

    type Create'PersonDocuments with
        static member New(?companyAuthorization: Create'PersonDocumentsCompanyAuthorization, ?passport: Create'PersonDocumentsPassport, ?visa: Create'PersonDocumentsVisa) =
            {
                CompanyAuthorization = companyAuthorization
                Passport = passport
                Visa = visa
            }

    type Create'PersonPoliticalExposure =
        | Existing
        | [<JsonPropertyName("none")>] None'

    type Create'PersonRegisteredAddress =
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

    type Create'PersonRegisteredAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'PersonRelationship =
        {
            /// Whether the person is the authorizer of the account's representative.
            [<Config.Form>]
            Authorizer: bool option
            /// Whether the person is a director of the account's legal entity. Directors are typically members of the governing board of the company, or responsible for ensuring the company meets its regulatory obligations.
            [<Config.Form>]
            Director: bool option
            /// Whether the person has significant responsibility to control, manage, or direct the organization.
            [<Config.Form>]
            Executive: bool option
            /// Whether the person is the legal guardian of the account's representative.
            [<Config.Form>]
            LegalGuardian: bool option
            /// Whether the person is an owner of the account’s legal entity.
            [<Config.Form>]
            Owner: bool option
            /// The percent owned by the person of the account's legal entity.
            [<Config.Form>]
            PercentOwnership: Choice<decimal,string> option
            /// Whether the person is authorized as the primary representative of the account. This is the person nominated by the business to provide information about themselves, and general information about the account. There can only be one representative at any given time. At the time the account is created, this person should be set to the person responsible for opening the account.
            [<Config.Form>]
            Representative: bool option
            /// The person's title (e.g., CEO, Support Engineer).
            [<Config.Form>]
            Title: string option
        }

    type Create'PersonRelationship with
        static member New(?authorizer: bool, ?director: bool, ?executive: bool, ?legalGuardian: bool, ?owner: bool, ?percentOwnership: Choice<decimal,string>, ?representative: bool, ?title: string) =
            {
                Authorizer = authorizer
                Director = director
                Executive = executive
                LegalGuardian = legalGuardian
                Owner = owner
                PercentOwnership = percentOwnership
                Representative = representative
                Title = title
            }

    type Create'PersonUsCfpbDataEthnicityDetailsEthnicity =
        | Cuban
        | HispanicOrLatino
        | Mexican
        | NotHispanicOrLatino
        | OtherHispanicOrLatino
        | PreferNotToAnswer
        | PuertoRican

    type Create'PersonUsCfpbDataEthnicityDetails =
        {
            /// The persons ethnicity
            [<Config.Form>]
            Ethnicity: Create'PersonUsCfpbDataEthnicityDetailsEthnicity list option
            /// Please specify your origin, when other is selected.
            [<Config.Form>]
            EthnicityOther: string option
        }

    type Create'PersonUsCfpbDataEthnicityDetails with
        static member New(?ethnicity: Create'PersonUsCfpbDataEthnicityDetailsEthnicity list, ?ethnicityOther: string) =
            {
                Ethnicity = ethnicity
                EthnicityOther = ethnicityOther
            }

    type Create'PersonUsCfpbDataRaceDetailsRace =
        | AfricanAmerican
        | AmericanIndianOrAlaskaNative
        | Asian
        | AsianIndian
        | BlackOrAfricanAmerican
        | Chinese
        | Ethiopian
        | Filipino
        | GuamanianOrChamorro
        | Haitian
        | Jamaican
        | Japanese
        | Korean
        | NativeHawaiian
        | NativeHawaiianOrOtherPacificIslander
        | Nigerian
        | OtherAsian
        | OtherBlackOrAfricanAmerican
        | OtherPacificIslander
        | PreferNotToAnswer
        | Samoan
        | Somali
        | Vietnamese
        | White

    type Create'PersonUsCfpbDataRaceDetails =
        {
            /// The persons race.
            [<Config.Form>]
            Race: Create'PersonUsCfpbDataRaceDetailsRace list option
            /// Please specify your race, when other is selected.
            [<Config.Form>]
            RaceOther: string option
        }

    type Create'PersonUsCfpbDataRaceDetails with
        static member New(?race: Create'PersonUsCfpbDataRaceDetailsRace list, ?raceOther: string) =
            {
                Race = race
                RaceOther = raceOther
            }

    type Create'PersonUsCfpbData =
        {
            /// The persons ethnicity details
            [<Config.Form>]
            EthnicityDetails: Create'PersonUsCfpbDataEthnicityDetails option
            /// The persons race details
            [<Config.Form>]
            RaceDetails: Create'PersonUsCfpbDataRaceDetails option
            /// The persons self-identified gender
            [<Config.Form>]
            SelfIdentifiedGender: string option
        }

    type Create'PersonUsCfpbData with
        static member New(?ethnicityDetails: Create'PersonUsCfpbDataEthnicityDetails, ?raceDetails: Create'PersonUsCfpbDataRaceDetails, ?selfIdentifiedGender: string) =
            {
                EthnicityDetails = ethnicityDetails
                RaceDetails = raceDetails
                SelfIdentifiedGender = selfIdentifiedGender
            }

    type Create'PersonVerificationAdditionalDocument =
        {
            /// The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Back: string option
            /// The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Front: string option
        }

    type Create'PersonVerificationAdditionalDocument with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Create'PersonVerificationDocument =
        {
            /// The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Back: string option
            /// The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
            [<Config.Form>]
            Front: string option
        }

    type Create'PersonVerificationDocument with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Create'PersonVerification =
        {
            /// A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.
            [<Config.Form>]
            AdditionalDocument: Create'PersonVerificationAdditionalDocument option
            /// An identifying document, either a passport or local ID card.
            [<Config.Form>]
            Document: Create'PersonVerificationDocument option
        }

    type Create'PersonVerification with
        static member New(?additionalDocument: Create'PersonVerificationAdditionalDocument, ?document: Create'PersonVerificationDocument) =
            {
                AdditionalDocument = additionalDocument
                Document = document
            }

    type Create'Person =
        {
            /// Details on the legal guardian's or authorizer's acceptance of the required Stripe agreements.
            [<Config.Form>]
            AdditionalTosAcceptances: Create'PersonAdditionalTosAcceptances option
            /// The person's address.
            [<Config.Form>]
            Address: Create'PersonAddress option
            /// The Kana variation of the person's address (Japan only).
            [<Config.Form>]
            AddressKana: Create'PersonAddressKana option
            /// The Kanji variation of the person's address (Japan only).
            [<Config.Form>]
            AddressKanji: Create'PersonAddressKanji option
            /// The person's date of birth.
            [<Config.Form>]
            Dob: Choice<Create'PersonDobDateOfBirthSpecs,string> option
            /// Documents that may be submitted to satisfy various informational requests.
            [<Config.Form>]
            Documents: Create'PersonDocuments option
            /// The person's email address.
            [<Config.Form>]
            Email: string option
            /// The person's first name.
            [<Config.Form>]
            FirstName: string option
            /// The Kana variation of the person's first name (Japan only).
            [<Config.Form>]
            FirstNameKana: string option
            /// The Kanji variation of the person's first name (Japan only).
            [<Config.Form>]
            FirstNameKanji: string option
            /// A list of alternate names or aliases that the person is known by.
            [<Config.Form>]
            FullNameAliases: Choice<string list,string> option
            /// The person's gender (International regulations require either "male" or "female").
            [<Config.Form>]
            Gender: string option
            /// The person's ID number, as appropriate for their country. For example, a social security number in the U.S., social insurance number in Canada, etc. Instead of the number itself, you can also provide a [PII token provided by Stripe.js](https://docs.stripe.com/js/tokens/create_token?type=pii).
            [<Config.Form>]
            IdNumber: string option
            /// The person's secondary ID number, as appropriate for their country, will be used for enhanced verification checks. In Thailand, this would be the laser code found on the back of an ID card. Instead of the number itself, you can also provide a [PII token provided by Stripe.js](https://docs.stripe.com/js/tokens/create_token?type=pii).
            [<Config.Form>]
            IdNumberSecondary: string option
            /// The person's last name.
            [<Config.Form>]
            LastName: string option
            /// The Kana variation of the person's last name (Japan only).
            [<Config.Form>]
            LastNameKana: string option
            /// The Kanji variation of the person's last name (Japan only).
            [<Config.Form>]
            LastNameKanji: string option
            /// The person's maiden name.
            [<Config.Form>]
            MaidenName: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The country where the person is a national. Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)), or "XX" if unavailable.
            [<Config.Form>]
            Nationality: string option
            /// The person's phone number.
            [<Config.Form>]
            Phone: string option
            /// Indicates if the person or any of their representatives, family members, or other closely related persons, declares that they hold or have held an important public job or function, in any jurisdiction.
            [<Config.Form>]
            PoliticalExposure: Create'PersonPoliticalExposure option
            /// The person's registered address.
            [<Config.Form>]
            RegisteredAddress: Create'PersonRegisteredAddress option
            /// The relationship that this person has with the account's legal entity.
            [<Config.Form>]
            Relationship: Create'PersonRelationship option
            /// The last four digits of the person's Social Security number (U.S. only).
            [<Config.Form>]
            SsnLast4: string option
            /// Demographic data related to the person.
            [<Config.Form>]
            UsCfpbData: Create'PersonUsCfpbData option
            /// The person's verification status.
            [<Config.Form>]
            Verification: Create'PersonVerification option
        }

    type Create'Person with
        static member New(?additionalTosAcceptances: Create'PersonAdditionalTosAcceptances, ?address: Create'PersonAddress, ?addressKana: Create'PersonAddressKana, ?addressKanji: Create'PersonAddressKanji, ?dob: Choice<Create'PersonDobDateOfBirthSpecs,string>, ?documents: Create'PersonDocuments, ?email: string, ?firstName: string, ?firstNameKana: string, ?firstNameKanji: string, ?fullNameAliases: Choice<string list,string>, ?gender: string, ?idNumber: string, ?idNumberSecondary: string, ?lastName: string, ?lastNameKana: string, ?lastNameKanji: string, ?maidenName: string, ?metadata: Map<string, string>, ?nationality: string, ?phone: string, ?politicalExposure: Create'PersonPoliticalExposure, ?registeredAddress: Create'PersonRegisteredAddress, ?relationship: Create'PersonRelationship, ?ssnLast4: string, ?usCfpbData: Create'PersonUsCfpbData, ?verification: Create'PersonVerification) =
            {
                AdditionalTosAcceptances = additionalTosAcceptances
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                Dob = dob
                Documents = documents
                Email = email
                FirstName = firstName
                FirstNameKana = firstNameKana
                FirstNameKanji = firstNameKanji
                FullNameAliases = fullNameAliases
                Gender = gender
                IdNumber = idNumber
                IdNumberSecondary = idNumberSecondary
                LastName = lastName
                LastNameKana = lastNameKana
                LastNameKanji = lastNameKanji
                MaidenName = maidenName
                Metadata = metadata
                Nationality = nationality
                Phone = phone
                PoliticalExposure = politicalExposure
                RegisteredAddress = registeredAddress
                Relationship = relationship
                SsnLast4 = ssnLast4
                UsCfpbData = usCfpbData
                Verification = verification
            }

    type Create'Pii =
        {
            /// The `id_number` for the PII, in string form.
            [<Config.Form>]
            IdNumber: string option
        }

    type Create'Pii with
        static member New(?idNumber: string) =
            {
                IdNumber = idNumber
            }

    type CreateOptions =
        {
            /// Information for the account this token represents.
            [<Config.Form>]
            Account: Create'Account option
            /// The bank account this token will represent.
            [<Config.Form>]
            BankAccount: Create'BankAccount option
            /// The card this token will represent. If you also pass in a customer, the card must be the ID of a card belonging to the customer. Otherwise, if you do not pass in a customer, this is a dictionary containing a user's credit card details, with the options described below.
            [<Config.Form>]
            Card: Choice<Create'CardCreditCardSpecs,string> option
            /// Create a token for the customer, which is owned by the application's account. You can only use this with an [OAuth access token](https://docs.stripe.com/connect/standard-accounts) or [Stripe-Account header](https://docs.stripe.com/connect/authentication). Learn more about [cloning saved payment methods](https://docs.stripe.com/connect/cloning-saved-payment-methods).
            [<Config.Form>]
            Customer: string option
            /// The updated CVC value this token represents.
            [<Config.Form>]
            CvcUpdate: Create'CvcUpdate option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Information for the person this token represents.
            [<Config.Form>]
            Person: Create'Person option
            /// The PII this token represents.
            [<Config.Form>]
            Pii: Create'Pii option
        }

    type CreateOptions with
        static member New(?account: Create'Account, ?bankAccount: Create'BankAccount, ?card: Choice<Create'CardCreditCardSpecs,string>, ?customer: string, ?cvcUpdate: Create'CvcUpdate, ?expand: string list, ?person: Create'Person, ?pii: Create'Pii) =
            {
                Account = account
                BankAccount = bankAccount
                Card = card
                Customer = customer
                CvcUpdate = cvcUpdate
                Expand = expand
                Person = person
                Pii = pii
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

    ///<p>Creates a single-use token that represents a bank account’s details.
    ///You can use this token with any v1 API method in place of a bank account dictionary. You can only use this token once. To do so, attach it to a <a href="#accounts">connected account</a> where <a href="/api/accounts/object#account_object-controller-requirement_collection">controller.requirement_collection</a> is <code>application</code>, which includes Custom accounts.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/tokens"
        |> RestApi.postAsync<_, Token> settings (Map.empty) options

    ///<p>Retrieves the token with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/tokens/{options.Token}"
        |> RestApi.getAsync<Token> settings qs

