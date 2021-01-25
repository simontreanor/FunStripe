namespace FunStripe

open FunStripe.Json
open System

module StripeRequest =

    type ThreeDSecure'CreateOptions = {
        Amount: int
        Card: string option
        Currency: string
        Customer: string option
        Expand: string list option
        ReturnUrl: string
    }
    with
        static member Create(amount: int, currency: string, returnUrl: string, ?card: string, ?customer: string, ?expand: string list) =
            {
                Amount = amount
                Card = card
                Currency = currency
                Customer = customer
                Expand = expand
                ReturnUrl = returnUrl
            }

    type AccountLinks'CreateCollect =
        | CurrentlyDue
        | EventuallyDue

    type AccountLinks'CreateType =
        | AccountOnboarding
        | AccountUpdate
        | CustomAccountUpdate
        | CustomAccountVerification

    type AccountLinks'CreateOptions = {
        Account: string
        Collect: AccountLinks'CreateCollect option
        Expand: string list option
        RefreshUrl: string option
        ReturnUrl: string option
        Type: AccountLinks'CreateType
    }
    with
        static member Create(account: string, ``type``: AccountLinks'CreateType, ?collect: AccountLinks'CreateCollect, ?expand: string list, ?refreshUrl: string, ?returnUrl: string) =
            {
                Account = account
                Collect = collect
                Expand = expand
                RefreshUrl = refreshUrl
                ReturnUrl = returnUrl
                Type = ``type``
            }

    type Accounts'CreateBusinessProfileSupportAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Accounts'CreateBusinessProfile = {
        Mcc: string option
        Name: string option
        ProductDescription: string option
        SupportAddress: Accounts'CreateBusinessProfileSupportAddress option
        SupportEmail: string option
        SupportPhone: string option
        SupportUrl: string option
        Url: string option
    }
    with
        static member Create(?mcc: string, ?name: string, ?productDescription: string, ?supportAddress: Accounts'CreateBusinessProfileSupportAddress, ?supportEmail: string, ?supportPhone: string, ?supportUrl: string, ?url: string) =
            {
                Mcc = mcc
                Name = name
                ProductDescription = productDescription
                SupportAddress = supportAddress
                SupportEmail = supportEmail
                SupportPhone = supportPhone
                SupportUrl = supportUrl
                Url = url
            }

    type Accounts'CreateCapabilitiesAuBecsDebitPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'CreateCapabilitiesBacsDebitPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'CreateCapabilitiesBancontactPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'CreateCapabilitiesCardIssuing = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'CreateCapabilitiesCardPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'CreateCapabilitiesCartesBancairesPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'CreateCapabilitiesEpsPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'CreateCapabilitiesFpxPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'CreateCapabilitiesGiropayPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'CreateCapabilitiesGrabpayPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'CreateCapabilitiesIdealPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'CreateCapabilitiesJcbPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'CreateCapabilitiesLegacyPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'CreateCapabilitiesOxxoPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'CreateCapabilitiesP24Payments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'CreateCapabilitiesSepaDebitPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'CreateCapabilitiesSofortPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'CreateCapabilitiesTaxReportingUs1099K = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'CreateCapabilitiesTaxReportingUs1099Misc = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'CreateCapabilitiesTransfers = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'CreateCapabilities = {
        AuBecsDebitPayments: Accounts'CreateCapabilitiesAuBecsDebitPayments option
        BacsDebitPayments: Accounts'CreateCapabilitiesBacsDebitPayments option
        BancontactPayments: Accounts'CreateCapabilitiesBancontactPayments option
        CardIssuing: Accounts'CreateCapabilitiesCardIssuing option
        CardPayments: Accounts'CreateCapabilitiesCardPayments option
        CartesBancairesPayments: Accounts'CreateCapabilitiesCartesBancairesPayments option
        EpsPayments: Accounts'CreateCapabilitiesEpsPayments option
        FpxPayments: Accounts'CreateCapabilitiesFpxPayments option
        GiropayPayments: Accounts'CreateCapabilitiesGiropayPayments option
        GrabpayPayments: Accounts'CreateCapabilitiesGrabpayPayments option
        IdealPayments: Accounts'CreateCapabilitiesIdealPayments option
        JcbPayments: Accounts'CreateCapabilitiesJcbPayments option
        LegacyPayments: Accounts'CreateCapabilitiesLegacyPayments option
        OxxoPayments: Accounts'CreateCapabilitiesOxxoPayments option
        P24Payments: Accounts'CreateCapabilitiesP24Payments option
        SepaDebitPayments: Accounts'CreateCapabilitiesSepaDebitPayments option
        SofortPayments: Accounts'CreateCapabilitiesSofortPayments option
        TaxReportingUs1099K: Accounts'CreateCapabilitiesTaxReportingUs1099K option
        TaxReportingUs1099Misc: Accounts'CreateCapabilitiesTaxReportingUs1099Misc option
        Transfers: Accounts'CreateCapabilitiesTransfers option
    }
    with
        static member Create(?auBecsDebitPayments: Accounts'CreateCapabilitiesAuBecsDebitPayments, ?taxReportingUs1099K: Accounts'CreateCapabilitiesTaxReportingUs1099K, ?sofortPayments: Accounts'CreateCapabilitiesSofortPayments, ?sepaDebitPayments: Accounts'CreateCapabilitiesSepaDebitPayments, ?p24Payments: Accounts'CreateCapabilitiesP24Payments, ?oxxoPayments: Accounts'CreateCapabilitiesOxxoPayments, ?legacyPayments: Accounts'CreateCapabilitiesLegacyPayments, ?jcbPayments: Accounts'CreateCapabilitiesJcbPayments, ?idealPayments: Accounts'CreateCapabilitiesIdealPayments, ?grabpayPayments: Accounts'CreateCapabilitiesGrabpayPayments, ?giropayPayments: Accounts'CreateCapabilitiesGiropayPayments, ?fpxPayments: Accounts'CreateCapabilitiesFpxPayments, ?epsPayments: Accounts'CreateCapabilitiesEpsPayments, ?cartesBancairesPayments: Accounts'CreateCapabilitiesCartesBancairesPayments, ?cardPayments: Accounts'CreateCapabilitiesCardPayments, ?cardIssuing: Accounts'CreateCapabilitiesCardIssuing, ?bancontactPayments: Accounts'CreateCapabilitiesBancontactPayments, ?bacsDebitPayments: Accounts'CreateCapabilitiesBacsDebitPayments, ?taxReportingUs1099Misc: Accounts'CreateCapabilitiesTaxReportingUs1099Misc, ?transfers: Accounts'CreateCapabilitiesTransfers) =
            {
                AuBecsDebitPayments = auBecsDebitPayments
                BacsDebitPayments = bacsDebitPayments
                BancontactPayments = bancontactPayments
                CardIssuing = cardIssuing
                CardPayments = cardPayments
                CartesBancairesPayments = cartesBancairesPayments
                EpsPayments = epsPayments
                FpxPayments = fpxPayments
                GiropayPayments = giropayPayments
                GrabpayPayments = grabpayPayments
                IdealPayments = idealPayments
                JcbPayments = jcbPayments
                LegacyPayments = legacyPayments
                OxxoPayments = oxxoPayments
                P24Payments = p24Payments
                SepaDebitPayments = sepaDebitPayments
                SofortPayments = sofortPayments
                TaxReportingUs1099K = taxReportingUs1099K
                TaxReportingUs1099Misc = taxReportingUs1099Misc
                Transfers = transfers
            }

    type Accounts'CreateCompanyAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Accounts'CreateCompanyAddressKana = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
        Town: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Accounts'CreateCompanyAddressKanji = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
        Town: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Accounts'CreateCompanyVerificationDocument = {
        Back: string option
        Front: string option
    }
    with
        static member Create(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Accounts'CreateCompanyVerification = {
        Document: Accounts'CreateCompanyVerificationDocument option
    }
    with
        static member Create(?document: Accounts'CreateCompanyVerificationDocument) =
            {
                Document = document
            }

    type Accounts'CreateCompanyStructure =
        | GovernmentInstrumentality
        | GovernmentalUnit
        | IncorporatedNonProfit
        | LimitedLiabilityPartnership
        | MultiMemberLlc
        | PrivateCompany
        | PrivateCorporation
        | PrivatePartnership
        | PublicCompany
        | PublicCorporation
        | PublicPartnership
        | SoleProprietorship
        | TaxExemptGovernmentInstrumentality
        | UnincorporatedAssociation
        | UnincorporatedNonProfit

    type Accounts'CreateCompany = {
        Address: Accounts'CreateCompanyAddress option
        AddressKana: Accounts'CreateCompanyAddressKana option
        AddressKanji: Accounts'CreateCompanyAddressKanji option
        DirectorsProvided: bool option
        ExecutivesProvided: bool option
        Name: string option
        NameKana: string option
        NameKanji: string option
        OwnersProvided: bool option
        Phone: string option
        RegistrationNumber: string option
        Structure: Accounts'CreateCompanyStructure option
        TaxId: string option
        TaxIdRegistrar: string option
        VatId: string option
        Verification: Accounts'CreateCompanyVerification option
    }
    with
        static member Create(?address: Accounts'CreateCompanyAddress, ?addressKana: Accounts'CreateCompanyAddressKana, ?addressKanji: Accounts'CreateCompanyAddressKanji, ?directorsProvided: bool, ?executivesProvided: bool, ?name: string, ?nameKana: string, ?nameKanji: string, ?ownersProvided: bool, ?phone: string, ?registrationNumber: string, ?structure: Accounts'CreateCompanyStructure, ?taxId: string, ?taxIdRegistrar: string, ?vatId: string, ?verification: Accounts'CreateCompanyVerification) =
            {
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                DirectorsProvided = directorsProvided
                ExecutivesProvided = executivesProvided
                Name = name
                NameKana = nameKana
                NameKanji = nameKanji
                OwnersProvided = ownersProvided
                Phone = phone
                RegistrationNumber = registrationNumber
                Structure = structure
                TaxId = taxId
                TaxIdRegistrar = taxIdRegistrar
                VatId = vatId
                Verification = verification
            }

    type Accounts'CreateIndividualAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Accounts'CreateIndividualAddressKana = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
        Town: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Accounts'CreateIndividualAddressKanji = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
        Town: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Accounts'CreateIndividualDobDateOfBirthSpecs = {
        Day: int option
        Month: int option
        Year: int option
    }
    with
        static member Create(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Accounts'CreateIndividualVerificationAdditionalDocument = {
        Back: string option
        Front: string option
    }
    with
        static member Create(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Accounts'CreateIndividualVerificationDocument = {
        Back: string option
        Front: string option
    }
    with
        static member Create(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Accounts'CreateIndividualVerification = {
        AdditionalDocument: Accounts'CreateIndividualVerificationAdditionalDocument option
        Document: Accounts'CreateIndividualVerificationDocument option
    }
    with
        static member Create(?additionalDocument: Accounts'CreateIndividualVerificationAdditionalDocument, ?document: Accounts'CreateIndividualVerificationDocument) =
            {
                AdditionalDocument = additionalDocument
                Document = document
            }

    type Accounts'CreateIndividualPoliticalExposure =
        | Existing
        | None'

    type Accounts'CreateIndividual = {
        Address: Accounts'CreateIndividualAddress option
        AddressKana: Accounts'CreateIndividualAddressKana option
        AddressKanji: Accounts'CreateIndividualAddressKanji option
        Dob: Choice<Accounts'CreateIndividualDobDateOfBirthSpecs,string> option
        Email: string option
        FirstName: string option
        FirstNameKana: string option
        FirstNameKanji: string option
        Gender: string option
        IdNumber: string option
        LastName: string option
        LastNameKana: string option
        LastNameKanji: string option
        MaidenName: string option
        Metadata: Map<string, string> option
        Phone: string option
        PoliticalExposure: Accounts'CreateIndividualPoliticalExposure option
        SsnLast4: string option
        Verification: Accounts'CreateIndividualVerification option
    }
    with
        static member Create(?address: Accounts'CreateIndividualAddress, ?politicalExposure: Accounts'CreateIndividualPoliticalExposure, ?phone: string, ?metadata: Map<string, string>, ?maidenName: string, ?lastNameKanji: string, ?lastNameKana: string, ?lastName: string, ?ssnLast4: string, ?idNumber: string, ?firstNameKanji: string, ?firstNameKana: string, ?firstName: string, ?email: string, ?dob: Choice<Accounts'CreateIndividualDobDateOfBirthSpecs,string>, ?addressKanji: Accounts'CreateIndividualAddressKanji, ?addressKana: Accounts'CreateIndividualAddressKana, ?gender: string, ?verification: Accounts'CreateIndividualVerification) =
            {
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                Dob = dob
                Email = email
                FirstName = firstName
                FirstNameKana = firstNameKana
                FirstNameKanji = firstNameKanji
                Gender = gender
                IdNumber = idNumber
                LastName = lastName
                LastNameKana = lastNameKana
                LastNameKanji = lastNameKanji
                MaidenName = maidenName
                Metadata = metadata
                Phone = phone
                PoliticalExposure = politicalExposure
                SsnLast4 = ssnLast4
                Verification = verification
            }

    type Accounts'CreateSettingsBranding = {
        Icon: string option
        Logo: string option
        PrimaryColor: string option
        SecondaryColor: string option
    }
    with
        static member Create(?icon: string, ?logo: string, ?primaryColor: string, ?secondaryColor: string) =
            {
                Icon = icon
                Logo = logo
                PrimaryColor = primaryColor
                SecondaryColor = secondaryColor
            }

    type Accounts'CreateSettingsCardPaymentsDeclineOn = {
        AvsFailure: bool option
        CvcFailure: bool option
    }
    with
        static member Create(?avsFailure: bool, ?cvcFailure: bool) =
            {
                AvsFailure = avsFailure
                CvcFailure = cvcFailure
            }

    type Accounts'CreateSettingsCardPayments = {
        DeclineOn: Accounts'CreateSettingsCardPaymentsDeclineOn option
        StatementDescriptorPrefix: string option
    }
    with
        static member Create(?declineOn: Accounts'CreateSettingsCardPaymentsDeclineOn, ?statementDescriptorPrefix: string) =
            {
                DeclineOn = declineOn
                StatementDescriptorPrefix = statementDescriptorPrefix
            }

    type Accounts'CreateSettingsPayments = {
        StatementDescriptor: string option
        StatementDescriptorKana: string option
        StatementDescriptorKanji: string option
    }
    with
        static member Create(?statementDescriptor: string, ?statementDescriptorKana: string, ?statementDescriptorKanji: string) =
            {
                StatementDescriptor = statementDescriptor
                StatementDescriptorKana = statementDescriptorKana
                StatementDescriptorKanji = statementDescriptorKanji
            }

    type Accounts'CreateSettingsPayoutsScheduleDelayDays =
        | Minimum

    type Accounts'CreateSettingsPayoutsScheduleInterval =
        | Daily
        | Manual
        | Monthly
        | Weekly

    type Accounts'CreateSettingsPayoutsScheduleWeeklyAnchor =
        | Friday
        | Monday
        | Saturday
        | Sunday
        | Thursday
        | Tuesday
        | Wednesday

    type Accounts'CreateSettingsPayoutsSchedule = {
        DelayDays: Choice<Accounts'CreateSettingsPayoutsScheduleDelayDays,int> option
        Interval: Accounts'CreateSettingsPayoutsScheduleInterval option
        MonthlyAnchor: int option
        WeeklyAnchor: Accounts'CreateSettingsPayoutsScheduleWeeklyAnchor option
    }
    with
        static member Create(?delayDays: Choice<Accounts'CreateSettingsPayoutsScheduleDelayDays,int>, ?interval: Accounts'CreateSettingsPayoutsScheduleInterval, ?monthlyAnchor: int, ?weeklyAnchor: Accounts'CreateSettingsPayoutsScheduleWeeklyAnchor) =
            {
                DelayDays = delayDays
                Interval = interval
                MonthlyAnchor = monthlyAnchor
                WeeklyAnchor = weeklyAnchor
            }

    type Accounts'CreateSettingsPayouts = {
        DebitNegativeBalances: bool option
        Schedule: Accounts'CreateSettingsPayoutsSchedule option
        StatementDescriptor: string option
    }
    with
        static member Create(?debitNegativeBalances: bool, ?schedule: Accounts'CreateSettingsPayoutsSchedule, ?statementDescriptor: string) =
            {
                DebitNegativeBalances = debitNegativeBalances
                Schedule = schedule
                StatementDescriptor = statementDescriptor
            }

    type Accounts'CreateSettings = {
        Branding: Accounts'CreateSettingsBranding option
        CardPayments: Accounts'CreateSettingsCardPayments option
        Payments: Accounts'CreateSettingsPayments option
        Payouts: Accounts'CreateSettingsPayouts option
    }
    with
        static member Create(?branding: Accounts'CreateSettingsBranding, ?cardPayments: Accounts'CreateSettingsCardPayments, ?payments: Accounts'CreateSettingsPayments, ?payouts: Accounts'CreateSettingsPayouts) =
            {
                Branding = branding
                CardPayments = cardPayments
                Payments = payments
                Payouts = payouts
            }

    type Accounts'CreateTosAcceptance = {
        Date: DateTime option
        Ip: string option
        ServiceAgreement: string option
        UserAgent: string option
    }
    with
        static member Create(?date: DateTime, ?ip: string, ?serviceAgreement: string, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                ServiceAgreement = serviceAgreement
                UserAgent = userAgent
            }

    type Accounts'CreateBusinessType =
        | Company
        | GovernmentEntity
        | Individual
        | NonProfit

    type Accounts'CreateType =
        | Custom
        | Express
        | Standard

    type Accounts'CreateOptions = {
        AccountToken: string option
        BusinessProfile: Accounts'CreateBusinessProfile option
        BusinessType: Accounts'CreateBusinessType option
        Capabilities: Accounts'CreateCapabilities option
        Company: Accounts'CreateCompany option
        Country: string option
        DefaultCurrency: string option
        Email: string option
        Expand: string list option
        ExternalAccount: string option
        Individual: Accounts'CreateIndividual option
        Metadata: Map<string, string> option
        Settings: Accounts'CreateSettings option
        TosAcceptance: Accounts'CreateTosAcceptance option
        Type: Accounts'CreateType option
    }
    with
        static member Create(?accountToken: string, ?businessProfile: Accounts'CreateBusinessProfile, ?businessType: Accounts'CreateBusinessType, ?capabilities: Accounts'CreateCapabilities, ?company: Accounts'CreateCompany, ?country: string, ?defaultCurrency: string, ?email: string, ?expand: string list, ?externalAccount: string, ?individual: Accounts'CreateIndividual, ?metadata: Map<string, string>, ?settings: Accounts'CreateSettings, ?tosAcceptance: Accounts'CreateTosAcceptance, ?``type``: Accounts'CreateType) =
            {
                AccountToken = accountToken
                BusinessProfile = businessProfile
                BusinessType = businessType
                Capabilities = capabilities
                Company = company
                Country = country
                DefaultCurrency = defaultCurrency
                Email = email
                Expand = expand
                ExternalAccount = externalAccount
                Individual = individual
                Metadata = metadata
                Settings = settings
                TosAcceptance = tosAcceptance
                Type = ``type``
            }

    type Accounts'UpdateBusinessProfileSupportAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Accounts'UpdateBusinessProfile = {
        Mcc: string option
        Name: string option
        ProductDescription: string option
        SupportAddress: Accounts'UpdateBusinessProfileSupportAddress option
        SupportEmail: string option
        SupportPhone: string option
        SupportUrl: string option
        Url: string option
    }
    with
        static member Create(?mcc: string, ?name: string, ?productDescription: string, ?supportAddress: Accounts'UpdateBusinessProfileSupportAddress, ?supportEmail: string, ?supportPhone: string, ?supportUrl: string, ?url: string) =
            {
                Mcc = mcc
                Name = name
                ProductDescription = productDescription
                SupportAddress = supportAddress
                SupportEmail = supportEmail
                SupportPhone = supportPhone
                SupportUrl = supportUrl
                Url = url
            }

    type Accounts'UpdateCapabilitiesAuBecsDebitPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'UpdateCapabilitiesBacsDebitPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'UpdateCapabilitiesBancontactPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'UpdateCapabilitiesCardIssuing = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'UpdateCapabilitiesCardPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'UpdateCapabilitiesCartesBancairesPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'UpdateCapabilitiesEpsPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'UpdateCapabilitiesFpxPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'UpdateCapabilitiesGiropayPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'UpdateCapabilitiesGrabpayPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'UpdateCapabilitiesIdealPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'UpdateCapabilitiesJcbPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'UpdateCapabilitiesLegacyPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'UpdateCapabilitiesOxxoPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'UpdateCapabilitiesP24Payments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'UpdateCapabilitiesSepaDebitPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'UpdateCapabilitiesSofortPayments = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'UpdateCapabilitiesTaxReportingUs1099K = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'UpdateCapabilitiesTaxReportingUs1099Misc = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'UpdateCapabilitiesTransfers = {
        Requested: bool option
    }
    with
        static member Create(?requested: bool) =
            {
                Requested = requested
            }

    type Accounts'UpdateCapabilities = {
        AuBecsDebitPayments: Accounts'UpdateCapabilitiesAuBecsDebitPayments option
        BacsDebitPayments: Accounts'UpdateCapabilitiesBacsDebitPayments option
        BancontactPayments: Accounts'UpdateCapabilitiesBancontactPayments option
        CardIssuing: Accounts'UpdateCapabilitiesCardIssuing option
        CardPayments: Accounts'UpdateCapabilitiesCardPayments option
        CartesBancairesPayments: Accounts'UpdateCapabilitiesCartesBancairesPayments option
        EpsPayments: Accounts'UpdateCapabilitiesEpsPayments option
        FpxPayments: Accounts'UpdateCapabilitiesFpxPayments option
        GiropayPayments: Accounts'UpdateCapabilitiesGiropayPayments option
        GrabpayPayments: Accounts'UpdateCapabilitiesGrabpayPayments option
        IdealPayments: Accounts'UpdateCapabilitiesIdealPayments option
        JcbPayments: Accounts'UpdateCapabilitiesJcbPayments option
        LegacyPayments: Accounts'UpdateCapabilitiesLegacyPayments option
        OxxoPayments: Accounts'UpdateCapabilitiesOxxoPayments option
        P24Payments: Accounts'UpdateCapabilitiesP24Payments option
        SepaDebitPayments: Accounts'UpdateCapabilitiesSepaDebitPayments option
        SofortPayments: Accounts'UpdateCapabilitiesSofortPayments option
        TaxReportingUs1099K: Accounts'UpdateCapabilitiesTaxReportingUs1099K option
        TaxReportingUs1099Misc: Accounts'UpdateCapabilitiesTaxReportingUs1099Misc option
        Transfers: Accounts'UpdateCapabilitiesTransfers option
    }
    with
        static member Create(?auBecsDebitPayments: Accounts'UpdateCapabilitiesAuBecsDebitPayments, ?taxReportingUs1099K: Accounts'UpdateCapabilitiesTaxReportingUs1099K, ?sofortPayments: Accounts'UpdateCapabilitiesSofortPayments, ?sepaDebitPayments: Accounts'UpdateCapabilitiesSepaDebitPayments, ?p24Payments: Accounts'UpdateCapabilitiesP24Payments, ?oxxoPayments: Accounts'UpdateCapabilitiesOxxoPayments, ?legacyPayments: Accounts'UpdateCapabilitiesLegacyPayments, ?jcbPayments: Accounts'UpdateCapabilitiesJcbPayments, ?idealPayments: Accounts'UpdateCapabilitiesIdealPayments, ?grabpayPayments: Accounts'UpdateCapabilitiesGrabpayPayments, ?giropayPayments: Accounts'UpdateCapabilitiesGiropayPayments, ?fpxPayments: Accounts'UpdateCapabilitiesFpxPayments, ?epsPayments: Accounts'UpdateCapabilitiesEpsPayments, ?cartesBancairesPayments: Accounts'UpdateCapabilitiesCartesBancairesPayments, ?cardPayments: Accounts'UpdateCapabilitiesCardPayments, ?cardIssuing: Accounts'UpdateCapabilitiesCardIssuing, ?bancontactPayments: Accounts'UpdateCapabilitiesBancontactPayments, ?bacsDebitPayments: Accounts'UpdateCapabilitiesBacsDebitPayments, ?taxReportingUs1099Misc: Accounts'UpdateCapabilitiesTaxReportingUs1099Misc, ?transfers: Accounts'UpdateCapabilitiesTransfers) =
            {
                AuBecsDebitPayments = auBecsDebitPayments
                BacsDebitPayments = bacsDebitPayments
                BancontactPayments = bancontactPayments
                CardIssuing = cardIssuing
                CardPayments = cardPayments
                CartesBancairesPayments = cartesBancairesPayments
                EpsPayments = epsPayments
                FpxPayments = fpxPayments
                GiropayPayments = giropayPayments
                GrabpayPayments = grabpayPayments
                IdealPayments = idealPayments
                JcbPayments = jcbPayments
                LegacyPayments = legacyPayments
                OxxoPayments = oxxoPayments
                P24Payments = p24Payments
                SepaDebitPayments = sepaDebitPayments
                SofortPayments = sofortPayments
                TaxReportingUs1099K = taxReportingUs1099K
                TaxReportingUs1099Misc = taxReportingUs1099Misc
                Transfers = transfers
            }

    type Accounts'UpdateCompanyAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Accounts'UpdateCompanyAddressKana = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
        Town: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Accounts'UpdateCompanyAddressKanji = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
        Town: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Accounts'UpdateCompanyVerificationDocument = {
        Back: string option
        Front: string option
    }
    with
        static member Create(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Accounts'UpdateCompanyVerification = {
        Document: Accounts'UpdateCompanyVerificationDocument option
    }
    with
        static member Create(?document: Accounts'UpdateCompanyVerificationDocument) =
            {
                Document = document
            }

    type Accounts'UpdateCompanyStructure =
        | GovernmentInstrumentality
        | GovernmentalUnit
        | IncorporatedNonProfit
        | LimitedLiabilityPartnership
        | MultiMemberLlc
        | PrivateCompany
        | PrivateCorporation
        | PrivatePartnership
        | PublicCompany
        | PublicCorporation
        | PublicPartnership
        | SoleProprietorship
        | TaxExemptGovernmentInstrumentality
        | UnincorporatedAssociation
        | UnincorporatedNonProfit

    type Accounts'UpdateCompany = {
        Address: Accounts'UpdateCompanyAddress option
        AddressKana: Accounts'UpdateCompanyAddressKana option
        AddressKanji: Accounts'UpdateCompanyAddressKanji option
        DirectorsProvided: bool option
        ExecutivesProvided: bool option
        Name: string option
        NameKana: string option
        NameKanji: string option
        OwnersProvided: bool option
        Phone: string option
        RegistrationNumber: string option
        Structure: Accounts'UpdateCompanyStructure option
        TaxId: string option
        TaxIdRegistrar: string option
        VatId: string option
        Verification: Accounts'UpdateCompanyVerification option
    }
    with
        static member Create(?address: Accounts'UpdateCompanyAddress, ?addressKana: Accounts'UpdateCompanyAddressKana, ?addressKanji: Accounts'UpdateCompanyAddressKanji, ?directorsProvided: bool, ?executivesProvided: bool, ?name: string, ?nameKana: string, ?nameKanji: string, ?ownersProvided: bool, ?phone: string, ?registrationNumber: string, ?structure: Accounts'UpdateCompanyStructure, ?taxId: string, ?taxIdRegistrar: string, ?vatId: string, ?verification: Accounts'UpdateCompanyVerification) =
            {
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                DirectorsProvided = directorsProvided
                ExecutivesProvided = executivesProvided
                Name = name
                NameKana = nameKana
                NameKanji = nameKanji
                OwnersProvided = ownersProvided
                Phone = phone
                RegistrationNumber = registrationNumber
                Structure = structure
                TaxId = taxId
                TaxIdRegistrar = taxIdRegistrar
                VatId = vatId
                Verification = verification
            }

    type Accounts'UpdateIndividualAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Accounts'UpdateIndividualAddressKana = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
        Town: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Accounts'UpdateIndividualAddressKanji = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
        Town: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Accounts'UpdateIndividualDobDateOfBirthSpecs = {
        Day: int option
        Month: int option
        Year: int option
    }
    with
        static member Create(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Accounts'UpdateIndividualVerificationAdditionalDocument = {
        Back: string option
        Front: string option
    }
    with
        static member Create(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Accounts'UpdateIndividualVerificationDocument = {
        Back: string option
        Front: string option
    }
    with
        static member Create(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Accounts'UpdateIndividualVerification = {
        AdditionalDocument: Accounts'UpdateIndividualVerificationAdditionalDocument option
        Document: Accounts'UpdateIndividualVerificationDocument option
    }
    with
        static member Create(?additionalDocument: Accounts'UpdateIndividualVerificationAdditionalDocument, ?document: Accounts'UpdateIndividualVerificationDocument) =
            {
                AdditionalDocument = additionalDocument
                Document = document
            }

    type Accounts'UpdateIndividualPoliticalExposure =
        | Existing
        | None'

    type Accounts'UpdateIndividual = {
        Address: Accounts'UpdateIndividualAddress option
        AddressKana: Accounts'UpdateIndividualAddressKana option
        AddressKanji: Accounts'UpdateIndividualAddressKanji option
        Dob: Choice<Accounts'UpdateIndividualDobDateOfBirthSpecs,string> option
        Email: string option
        FirstName: string option
        FirstNameKana: string option
        FirstNameKanji: string option
        Gender: string option
        IdNumber: string option
        LastName: string option
        LastNameKana: string option
        LastNameKanji: string option
        MaidenName: string option
        Metadata: Map<string, string> option
        Phone: string option
        PoliticalExposure: Accounts'UpdateIndividualPoliticalExposure option
        SsnLast4: string option
        Verification: Accounts'UpdateIndividualVerification option
    }
    with
        static member Create(?address: Accounts'UpdateIndividualAddress, ?politicalExposure: Accounts'UpdateIndividualPoliticalExposure, ?phone: string, ?metadata: Map<string, string>, ?maidenName: string, ?lastNameKanji: string, ?lastNameKana: string, ?lastName: string, ?ssnLast4: string, ?idNumber: string, ?firstNameKanji: string, ?firstNameKana: string, ?firstName: string, ?email: string, ?dob: Choice<Accounts'UpdateIndividualDobDateOfBirthSpecs,string>, ?addressKanji: Accounts'UpdateIndividualAddressKanji, ?addressKana: Accounts'UpdateIndividualAddressKana, ?gender: string, ?verification: Accounts'UpdateIndividualVerification) =
            {
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                Dob = dob
                Email = email
                FirstName = firstName
                FirstNameKana = firstNameKana
                FirstNameKanji = firstNameKanji
                Gender = gender
                IdNumber = idNumber
                LastName = lastName
                LastNameKana = lastNameKana
                LastNameKanji = lastNameKanji
                MaidenName = maidenName
                Metadata = metadata
                Phone = phone
                PoliticalExposure = politicalExposure
                SsnLast4 = ssnLast4
                Verification = verification
            }

    type Accounts'UpdateSettingsBranding = {
        Icon: string option
        Logo: string option
        PrimaryColor: string option
        SecondaryColor: string option
    }
    with
        static member Create(?icon: string, ?logo: string, ?primaryColor: string, ?secondaryColor: string) =
            {
                Icon = icon
                Logo = logo
                PrimaryColor = primaryColor
                SecondaryColor = secondaryColor
            }

    type Accounts'UpdateSettingsCardPaymentsDeclineOn = {
        AvsFailure: bool option
        CvcFailure: bool option
    }
    with
        static member Create(?avsFailure: bool, ?cvcFailure: bool) =
            {
                AvsFailure = avsFailure
                CvcFailure = cvcFailure
            }

    type Accounts'UpdateSettingsCardPayments = {
        DeclineOn: Accounts'UpdateSettingsCardPaymentsDeclineOn option
        StatementDescriptorPrefix: string option
    }
    with
        static member Create(?declineOn: Accounts'UpdateSettingsCardPaymentsDeclineOn, ?statementDescriptorPrefix: string) =
            {
                DeclineOn = declineOn
                StatementDescriptorPrefix = statementDescriptorPrefix
            }

    type Accounts'UpdateSettingsPayments = {
        StatementDescriptor: string option
        StatementDescriptorKana: string option
        StatementDescriptorKanji: string option
    }
    with
        static member Create(?statementDescriptor: string, ?statementDescriptorKana: string, ?statementDescriptorKanji: string) =
            {
                StatementDescriptor = statementDescriptor
                StatementDescriptorKana = statementDescriptorKana
                StatementDescriptorKanji = statementDescriptorKanji
            }

    type Accounts'UpdateSettingsPayoutsScheduleDelayDays =
        | Minimum

    type Accounts'UpdateSettingsPayoutsScheduleInterval =
        | Daily
        | Manual
        | Monthly
        | Weekly

    type Accounts'UpdateSettingsPayoutsScheduleWeeklyAnchor =
        | Friday
        | Monday
        | Saturday
        | Sunday
        | Thursday
        | Tuesday
        | Wednesday

    type Accounts'UpdateSettingsPayoutsSchedule = {
        DelayDays: Choice<Accounts'UpdateSettingsPayoutsScheduleDelayDays,int> option
        Interval: Accounts'UpdateSettingsPayoutsScheduleInterval option
        MonthlyAnchor: int option
        WeeklyAnchor: Accounts'UpdateSettingsPayoutsScheduleWeeklyAnchor option
    }
    with
        static member Create(?delayDays: Choice<Accounts'UpdateSettingsPayoutsScheduleDelayDays,int>, ?interval: Accounts'UpdateSettingsPayoutsScheduleInterval, ?monthlyAnchor: int, ?weeklyAnchor: Accounts'UpdateSettingsPayoutsScheduleWeeklyAnchor) =
            {
                DelayDays = delayDays
                Interval = interval
                MonthlyAnchor = monthlyAnchor
                WeeklyAnchor = weeklyAnchor
            }

    type Accounts'UpdateSettingsPayouts = {
        DebitNegativeBalances: bool option
        Schedule: Accounts'UpdateSettingsPayoutsSchedule option
        StatementDescriptor: string option
    }
    with
        static member Create(?debitNegativeBalances: bool, ?schedule: Accounts'UpdateSettingsPayoutsSchedule, ?statementDescriptor: string) =
            {
                DebitNegativeBalances = debitNegativeBalances
                Schedule = schedule
                StatementDescriptor = statementDescriptor
            }

    type Accounts'UpdateSettings = {
        Branding: Accounts'UpdateSettingsBranding option
        CardPayments: Accounts'UpdateSettingsCardPayments option
        Payments: Accounts'UpdateSettingsPayments option
        Payouts: Accounts'UpdateSettingsPayouts option
    }
    with
        static member Create(?branding: Accounts'UpdateSettingsBranding, ?cardPayments: Accounts'UpdateSettingsCardPayments, ?payments: Accounts'UpdateSettingsPayments, ?payouts: Accounts'UpdateSettingsPayouts) =
            {
                Branding = branding
                CardPayments = cardPayments
                Payments = payments
                Payouts = payouts
            }

    type Accounts'UpdateTosAcceptance = {
        Date: DateTime option
        Ip: string option
        ServiceAgreement: string option
        UserAgent: string option
    }
    with
        static member Create(?date: DateTime, ?ip: string, ?serviceAgreement: string, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                ServiceAgreement = serviceAgreement
                UserAgent = userAgent
            }

    type Accounts'UpdateBusinessType =
        | Company
        | GovernmentEntity
        | Individual
        | NonProfit

    type Accounts'UpdateOptions = {
        AccountToken: string option
        BusinessProfile: Accounts'UpdateBusinessProfile option
        BusinessType: Accounts'UpdateBusinessType option
        Capabilities: Accounts'UpdateCapabilities option
        Company: Accounts'UpdateCompany option
        DefaultCurrency: string option
        Email: string option
        Expand: string list option
        ExternalAccount: string option
        Individual: Accounts'UpdateIndividual option
        Metadata: Map<string, string> option
        Settings: Accounts'UpdateSettings option
        TosAcceptance: Accounts'UpdateTosAcceptance option
    }
    with
        static member Create(?accountToken: string, ?businessProfile: Accounts'UpdateBusinessProfile, ?businessType: Accounts'UpdateBusinessType, ?capabilities: Accounts'UpdateCapabilities, ?company: Accounts'UpdateCompany, ?defaultCurrency: string, ?email: string, ?expand: string list, ?externalAccount: string, ?individual: Accounts'UpdateIndividual, ?metadata: Map<string, string>, ?settings: Accounts'UpdateSettings, ?tosAcceptance: Accounts'UpdateTosAcceptance) =
            {
                AccountToken = accountToken
                BusinessProfile = businessProfile
                BusinessType = businessType
                Capabilities = capabilities
                Company = company
                DefaultCurrency = defaultCurrency
                Email = email
                Expand = expand
                ExternalAccount = externalAccount
                Individual = individual
                Metadata = metadata
                Settings = settings
                TosAcceptance = tosAcceptance
            }

    type AccountsCapabilities'UpdateOptions = {
        Expand: string list option
        Requested: bool option
    }
    with
        static member Create(?expand: string list, ?requested: bool) =
            {
                Expand = expand
                Requested = requested
            }

    type AccountsExternalAccounts'CreateOptions = {
        DefaultForCurrency: bool option
        Expand: string list option
        ExternalAccount: string
        Metadata: Map<string, string> option
    }
    with
        static member Create(externalAccount: string, ?defaultForCurrency: bool, ?expand: string list, ?metadata: Map<string, string>) =
            {
                DefaultForCurrency = defaultForCurrency
                Expand = expand
                ExternalAccount = externalAccount
                Metadata = metadata
            }

    type AccountsExternalAccounts'UpdateAccountHolderType =
        | Company
        | Individual

    type AccountsExternalAccounts'UpdateOptions = {
        AccountHolderName: string option
        AccountHolderType: AccountsExternalAccounts'UpdateAccountHolderType option
        AddressCity: string option
        AddressCountry: string option
        AddressLine1: string option
        AddressLine2: string option
        AddressState: string option
        AddressZip: string option
        DefaultForCurrency: bool option
        ExpMonth: string option
        ExpYear: string option
        Expand: string list option
        Metadata: Map<string, string> option
        Name: string option
    }
    with
        static member Create(?accountHolderName: string, ?accountHolderType: AccountsExternalAccounts'UpdateAccountHolderType, ?addressCity: string, ?addressCountry: string, ?addressLine1: string, ?addressLine2: string, ?addressState: string, ?addressZip: string, ?defaultForCurrency: bool, ?expMonth: string, ?expYear: string, ?expand: string list, ?metadata: Map<string, string>, ?name: string) =
            {
                AccountHolderName = accountHolderName
                AccountHolderType = accountHolderType
                AddressCity = addressCity
                AddressCountry = addressCountry
                AddressLine1 = addressLine1
                AddressLine2 = addressLine2
                AddressState = addressState
                AddressZip = addressZip
                DefaultForCurrency = defaultForCurrency
                ExpMonth = expMonth
                ExpYear = expYear
                Expand = expand
                Metadata = metadata
                Name = name
            }

    type AccountsLoginLinks'CreateOptions = {
        Expand: string list option
        RedirectUrl: string option
    }
    with
        static member Create(?expand: string list, ?redirectUrl: string) =
            {
                Expand = expand
                RedirectUrl = redirectUrl
            }

    type AccountsPersons'CreateAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type AccountsPersons'CreateAddressKana = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
        Town: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type AccountsPersons'CreateAddressKanji = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
        Town: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type AccountsPersons'CreateDobDateOfBirthSpecs = {
        Day: int option
        Month: int option
        Year: int option
    }
    with
        static member Create(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type AccountsPersons'CreateRelationship = {
        Director: bool option
        Executive: bool option
        Owner: bool option
        PercentOwnership: Choice<decimal,string> option
        Representative: bool option
        Title: string option
    }
    with
        static member Create(?director: bool, ?executive: bool, ?owner: bool, ?percentOwnership: Choice<decimal,string>, ?representative: bool, ?title: string) =
            {
                Director = director
                Executive = executive
                Owner = owner
                PercentOwnership = percentOwnership
                Representative = representative
                Title = title
            }

    type AccountsPersons'CreateVerificationAdditionalDocument = {
        Back: string option
        Front: string option
    }
    with
        static member Create(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type AccountsPersons'CreateVerificationDocument = {
        Back: string option
        Front: string option
    }
    with
        static member Create(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type AccountsPersons'CreateVerification = {
        AdditionalDocument: AccountsPersons'CreateVerificationAdditionalDocument option
        Document: AccountsPersons'CreateVerificationDocument option
    }
    with
        static member Create(?additionalDocument: AccountsPersons'CreateVerificationAdditionalDocument, ?document: AccountsPersons'CreateVerificationDocument) =
            {
                AdditionalDocument = additionalDocument
                Document = document
            }

    type AccountsPersons'CreateOptions = {
        Address: AccountsPersons'CreateAddress option
        AddressKana: AccountsPersons'CreateAddressKana option
        AddressKanji: AccountsPersons'CreateAddressKanji option
        Dob: Choice<AccountsPersons'CreateDobDateOfBirthSpecs,string> option
        Email: string option
        Expand: string list option
        FirstName: string option
        FirstNameKana: string option
        FirstNameKanji: string option
        Gender: string option
        IdNumber: string option
        LastName: string option
        LastNameKana: string option
        LastNameKanji: string option
        MaidenName: string option
        Metadata: Map<string, string> option
        PersonToken: string option
        Phone: string option
        PoliticalExposure: string option
        Relationship: AccountsPersons'CreateRelationship option
        SsnLast4: string option
        Verification: AccountsPersons'CreateVerification option
    }
    with
        static member Create(?address: AccountsPersons'CreateAddress, ?relationship: AccountsPersons'CreateRelationship, ?politicalExposure: string, ?phone: string, ?personToken: string, ?metadata: Map<string, string>, ?maidenName: string, ?lastNameKanji: string, ?lastNameKana: string, ?lastName: string, ?idNumber: string, ?gender: string, ?firstNameKanji: string, ?firstNameKana: string, ?firstName: string, ?expand: string list, ?email: string, ?dob: Choice<AccountsPersons'CreateDobDateOfBirthSpecs,string>, ?addressKanji: AccountsPersons'CreateAddressKanji, ?addressKana: AccountsPersons'CreateAddressKana, ?ssnLast4: string, ?verification: AccountsPersons'CreateVerification) =
            {
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                Dob = dob
                Email = email
                Expand = expand
                FirstName = firstName
                FirstNameKana = firstNameKana
                FirstNameKanji = firstNameKanji
                Gender = gender
                IdNumber = idNumber
                LastName = lastName
                LastNameKana = lastNameKana
                LastNameKanji = lastNameKanji
                MaidenName = maidenName
                Metadata = metadata
                PersonToken = personToken
                Phone = phone
                PoliticalExposure = politicalExposure
                Relationship = relationship
                SsnLast4 = ssnLast4
                Verification = verification
            }

    type AccountsPersons'UpdateAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type AccountsPersons'UpdateAddressKana = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
        Town: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type AccountsPersons'UpdateAddressKanji = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
        Town: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type AccountsPersons'UpdateDobDateOfBirthSpecs = {
        Day: int option
        Month: int option
        Year: int option
    }
    with
        static member Create(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type AccountsPersons'UpdateRelationship = {
        Director: bool option
        Executive: bool option
        Owner: bool option
        PercentOwnership: Choice<decimal,string> option
        Representative: bool option
        Title: string option
    }
    with
        static member Create(?director: bool, ?executive: bool, ?owner: bool, ?percentOwnership: Choice<decimal,string>, ?representative: bool, ?title: string) =
            {
                Director = director
                Executive = executive
                Owner = owner
                PercentOwnership = percentOwnership
                Representative = representative
                Title = title
            }

    type AccountsPersons'UpdateVerificationAdditionalDocument = {
        Back: string option
        Front: string option
    }
    with
        static member Create(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type AccountsPersons'UpdateVerificationDocument = {
        Back: string option
        Front: string option
    }
    with
        static member Create(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type AccountsPersons'UpdateVerification = {
        AdditionalDocument: AccountsPersons'UpdateVerificationAdditionalDocument option
        Document: AccountsPersons'UpdateVerificationDocument option
    }
    with
        static member Create(?additionalDocument: AccountsPersons'UpdateVerificationAdditionalDocument, ?document: AccountsPersons'UpdateVerificationDocument) =
            {
                AdditionalDocument = additionalDocument
                Document = document
            }

    type AccountsPersons'UpdateOptions = {
        Address: AccountsPersons'UpdateAddress option
        AddressKana: AccountsPersons'UpdateAddressKana option
        AddressKanji: AccountsPersons'UpdateAddressKanji option
        Dob: Choice<AccountsPersons'UpdateDobDateOfBirthSpecs,string> option
        Email: string option
        Expand: string list option
        FirstName: string option
        FirstNameKana: string option
        FirstNameKanji: string option
        Gender: string option
        IdNumber: string option
        LastName: string option
        LastNameKana: string option
        LastNameKanji: string option
        MaidenName: string option
        Metadata: Map<string, string> option
        PersonToken: string option
        Phone: string option
        PoliticalExposure: string option
        Relationship: AccountsPersons'UpdateRelationship option
        SsnLast4: string option
        Verification: AccountsPersons'UpdateVerification option
    }
    with
        static member Create(?address: AccountsPersons'UpdateAddress, ?relationship: AccountsPersons'UpdateRelationship, ?politicalExposure: string, ?phone: string, ?personToken: string, ?metadata: Map<string, string>, ?maidenName: string, ?lastNameKanji: string, ?lastNameKana: string, ?lastName: string, ?idNumber: string, ?gender: string, ?firstNameKanji: string, ?firstNameKana: string, ?firstName: string, ?expand: string list, ?email: string, ?dob: Choice<AccountsPersons'UpdateDobDateOfBirthSpecs,string>, ?addressKanji: AccountsPersons'UpdateAddressKanji, ?addressKana: AccountsPersons'UpdateAddressKana, ?ssnLast4: string, ?verification: AccountsPersons'UpdateVerification) =
            {
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                Dob = dob
                Email = email
                Expand = expand
                FirstName = firstName
                FirstNameKana = firstNameKana
                FirstNameKanji = firstNameKanji
                Gender = gender
                IdNumber = idNumber
                LastName = lastName
                LastNameKana = lastNameKana
                LastNameKanji = lastNameKanji
                MaidenName = maidenName
                Metadata = metadata
                PersonToken = personToken
                Phone = phone
                PoliticalExposure = politicalExposure
                Relationship = relationship
                SsnLast4 = ssnLast4
                Verification = verification
            }

    type AccountsReject'RejectOptions = {
        Expand: string list option
        Reason: string
    }
    with
        static member Create(reason: string, ?expand: string list) =
            {
                Expand = expand
                Reason = reason
            }

    type ApplePayDomains'CreateOptions = {
        DomainName: string
        Expand: string list option
    }
    with
        static member Create(domainName: string, ?expand: string list) =
            {
                DomainName = domainName
                Expand = expand
            }

    type ApplicationFeesRefunds'UpdateOptions = {
        Expand: string list option
        Metadata: Map<string, string> option
    }
    with
        static member Create(?expand: string list, ?metadata: Map<string, string>) =
            {
                Expand = expand
                Metadata = metadata
            }

    type ApplicationFeesRefunds'CreateOptions = {
        Amount: int option
        Expand: string list option
        Metadata: Map<string, string> option
    }
    with
        static member Create(?amount: int, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Amount = amount
                Expand = expand
                Metadata = metadata
            }

    type BillingPortalSessions'CreateOptions = {
        Customer: string
        Expand: string list option
        ReturnUrl: string option
    }
    with
        static member Create(customer: string, ?expand: string list, ?returnUrl: string) =
            {
                Customer = customer
                Expand = expand
                ReturnUrl = returnUrl
            }

    type Charges'CreateDestination = {
        Account: string option
        Amount: int option
    }
    with
        static member Create(?account: string, ?amount: int) =
            {
                Account = account
                Amount = amount
            }

    type Charges'CreateShippingAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Charges'CreateShipping = {
        Address: Charges'CreateShippingAddress option
        Carrier: string option
        Name: string option
        Phone: string option
        TrackingNumber: string option
    }
    with
        static member Create(?address: Charges'CreateShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
            {
                Address = address
                Carrier = carrier
                Name = name
                Phone = phone
                TrackingNumber = trackingNumber
            }

    type Charges'CreateTransferData = {
        Amount: int option
        Destination: string option
    }
    with
        static member Create(?amount: int, ?destination: string) =
            {
                Amount = amount
                Destination = destination
            }

    type Charges'CreateOptions = {
        Amount: int option
        ApplicationFee: int option
        ApplicationFeeAmount: int option
        Capture: bool option
        Currency: string option
        Customer: string option
        Description: string option
        Destination: Charges'CreateDestination option
        Expand: string list option
        Metadata: Map<string, string> option
        OnBehalfOf: string option
        ReceiptEmail: string option
        Shipping: Charges'CreateShipping option
        Source: string option
        StatementDescriptor: string option
        StatementDescriptorSuffix: string option
        TransferData: Charges'CreateTransferData option
        TransferGroup: string option
    }
    with
        static member Create(?amount: int, ?statementDescriptorSuffix: string, ?statementDescriptor: string, ?source: string, ?shipping: Charges'CreateShipping, ?receiptEmail: string, ?onBehalfOf: string, ?metadata: Map<string, string>, ?expand: string list, ?destination: Charges'CreateDestination, ?description: string, ?customer: string, ?currency: string, ?capture: bool, ?applicationFeeAmount: int, ?applicationFee: int, ?transferData: Charges'CreateTransferData, ?transferGroup: string) =
            {
                Amount = amount
                ApplicationFee = applicationFee
                ApplicationFeeAmount = applicationFeeAmount
                Capture = capture
                Currency = currency
                Customer = customer
                Description = description
                Destination = destination
                Expand = expand
                Metadata = metadata
                OnBehalfOf = onBehalfOf
                ReceiptEmail = receiptEmail
                Shipping = shipping
                Source = source
                StatementDescriptor = statementDescriptor
                StatementDescriptorSuffix = statementDescriptorSuffix
                TransferData = transferData
                TransferGroup = transferGroup
            }

    type Charges'UpdateFraudDetailsUserReport =
        | Fraudulent
        | Safe

    type Charges'UpdateFraudDetails = {
        UserReport: Charges'UpdateFraudDetailsUserReport option
    }
    with
        static member Create(?userReport: Charges'UpdateFraudDetailsUserReport) =
            {
                UserReport = userReport
            }

    type Charges'UpdateShippingAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Charges'UpdateShipping = {
        Address: Charges'UpdateShippingAddress option
        Carrier: string option
        Name: string option
        Phone: string option
        TrackingNumber: string option
    }
    with
        static member Create(?address: Charges'UpdateShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
            {
                Address = address
                Carrier = carrier
                Name = name
                Phone = phone
                TrackingNumber = trackingNumber
            }

    type Charges'UpdateOptions = {
        Customer: string option
        Description: string option
        Expand: string list option
        FraudDetails: Charges'UpdateFraudDetails option
        Metadata: Map<string, string> option
        ReceiptEmail: string option
        Shipping: Charges'UpdateShipping option
        TransferGroup: string option
    }
    with
        static member Create(?customer: string, ?description: string, ?expand: string list, ?fraudDetails: Charges'UpdateFraudDetails, ?metadata: Map<string, string>, ?receiptEmail: string, ?shipping: Charges'UpdateShipping, ?transferGroup: string) =
            {
                Customer = customer
                Description = description
                Expand = expand
                FraudDetails = fraudDetails
                Metadata = metadata
                ReceiptEmail = receiptEmail
                Shipping = shipping
                TransferGroup = transferGroup
            }

    type ChargesCapture'CaptureTransferData = {
        Amount: int option
    }
    with
        static member Create(?amount: int) =
            {
                Amount = amount
            }

    type ChargesCapture'CaptureOptions = {
        Amount: int option
        ApplicationFee: int option
        ApplicationFeeAmount: int option
        Expand: string list option
        ReceiptEmail: string option
        StatementDescriptor: string option
        StatementDescriptorSuffix: string option
        TransferData: ChargesCapture'CaptureTransferData option
        TransferGroup: string option
    }
    with
        static member Create(?amount: int, ?applicationFee: int, ?applicationFeeAmount: int, ?expand: string list, ?receiptEmail: string, ?statementDescriptor: string, ?statementDescriptorSuffix: string, ?transferData: ChargesCapture'CaptureTransferData, ?transferGroup: string) =
            {
                Amount = amount
                ApplicationFee = applicationFee
                ApplicationFeeAmount = applicationFeeAmount
                Expand = expand
                ReceiptEmail = receiptEmail
                StatementDescriptor = statementDescriptor
                StatementDescriptorSuffix = statementDescriptorSuffix
                TransferData = transferData
                TransferGroup = transferGroup
            }

    type CheckoutSessions'CreateDiscounts = {
        Coupon: string option
        PromotionCode: string option
    }
    with
        static member Create(?coupon: string, ?promotionCode: string) =
            {
                Coupon = coupon
                PromotionCode = promotionCode
            }

    type CheckoutSessions'CreateLineItemsPriceDataProductData = {
        Description: string option
        Images: string list option
        Metadata: Map<string, string> option
        Name: string option
    }
    with
        static member Create(?description: string, ?images: string list, ?metadata: Map<string, string>, ?name: string) =
            {
                Description = description
                Images = images
                Metadata = metadata
                Name = name
            }

    type CheckoutSessions'CreateLineItemsPriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    type CheckoutSessions'CreateLineItemsPriceDataRecurring = {
        Interval: CheckoutSessions'CreateLineItemsPriceDataRecurringInterval option
        IntervalCount: int option
    }
    with
        static member Create(?interval: CheckoutSessions'CreateLineItemsPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type CheckoutSessions'CreateLineItemsPriceData = {
        Currency: string option
        Product: string option
        ProductData: CheckoutSessions'CreateLineItemsPriceDataProductData option
        Recurring: CheckoutSessions'CreateLineItemsPriceDataRecurring option
        UnitAmount: int option
        UnitAmountDecimal: string option
    }
    with
        static member Create(?currency: string, ?product: string, ?productData: CheckoutSessions'CreateLineItemsPriceDataProductData, ?recurring: CheckoutSessions'CreateLineItemsPriceDataRecurring, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                ProductData = productData
                Recurring = recurring
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type CheckoutSessions'CreateLineItems = {
        Amount: int option
        Currency: string option
        Description: string option
        Images: string list option
        Name: string option
        Price: string option
        PriceData: CheckoutSessions'CreateLineItemsPriceData option
        Quantity: int option
        TaxRates: string list option
    }
    with
        static member Create(?amount: int, ?currency: string, ?description: string, ?images: string list, ?name: string, ?price: string, ?priceData: CheckoutSessions'CreateLineItemsPriceData, ?quantity: int, ?taxRates: string list) =
            {
                Amount = amount
                Currency = currency
                Description = description
                Images = images
                Name = name
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type CheckoutSessions'CreatePaymentIntentDataShippingAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type CheckoutSessions'CreatePaymentIntentDataShipping = {
        Address: CheckoutSessions'CreatePaymentIntentDataShippingAddress option
        Carrier: string option
        Name: string option
        Phone: string option
        TrackingNumber: string option
    }
    with
        static member Create(?address: CheckoutSessions'CreatePaymentIntentDataShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
            {
                Address = address
                Carrier = carrier
                Name = name
                Phone = phone
                TrackingNumber = trackingNumber
            }

    type CheckoutSessions'CreatePaymentIntentDataTransferData = {
        Amount: int option
        Destination: string option
    }
    with
        static member Create(?amount: int, ?destination: string) =
            {
                Amount = amount
                Destination = destination
            }

    type CheckoutSessions'CreatePaymentIntentDataCaptureMethod =
        | Automatic
        | Manual

    type CheckoutSessions'CreatePaymentIntentDataSetupFutureUsage =
        | OffSession
        | OnSession

    type CheckoutSessions'CreatePaymentIntentData = {
        ApplicationFeeAmount: int option
        CaptureMethod: CheckoutSessions'CreatePaymentIntentDataCaptureMethod option
        Description: string option
        Metadata: Map<string, string> option
        OnBehalfOf: string option
        ReceiptEmail: string option
        SetupFutureUsage: CheckoutSessions'CreatePaymentIntentDataSetupFutureUsage option
        Shipping: CheckoutSessions'CreatePaymentIntentDataShipping option
        StatementDescriptor: string option
        StatementDescriptorSuffix: string option
        TransferData: CheckoutSessions'CreatePaymentIntentDataTransferData option
        TransferGroup: string option
    }
    with
        static member Create(?applicationFeeAmount: int, ?captureMethod: CheckoutSessions'CreatePaymentIntentDataCaptureMethod, ?description: string, ?metadata: Map<string, string>, ?onBehalfOf: string, ?receiptEmail: string, ?setupFutureUsage: CheckoutSessions'CreatePaymentIntentDataSetupFutureUsage, ?shipping: CheckoutSessions'CreatePaymentIntentDataShipping, ?statementDescriptor: string, ?statementDescriptorSuffix: string, ?transferData: CheckoutSessions'CreatePaymentIntentDataTransferData, ?transferGroup: string) =
            {
                ApplicationFeeAmount = applicationFeeAmount
                CaptureMethod = captureMethod
                Description = description
                Metadata = metadata
                OnBehalfOf = onBehalfOf
                ReceiptEmail = receiptEmail
                SetupFutureUsage = setupFutureUsage
                Shipping = shipping
                StatementDescriptor = statementDescriptor
                StatementDescriptorSuffix = statementDescriptorSuffix
                TransferData = transferData
                TransferGroup = transferGroup
            }

    type CheckoutSessions'CreatePaymentMethodTypes =
        | Alipay
        | BacsDebit
        | Bancontact
        | Card
        | Eps
        | Fpx
        | Giropay
        | Grabpay
        | Ideal
        | P24
        | SepaDebit
        | Sofort

    type CheckoutSessions'CreateSetupIntentData = {
        Description: string option
        Metadata: Map<string, string> option
        OnBehalfOf: string option
    }
    with
        static member Create(?description: string, ?metadata: Map<string, string>, ?onBehalfOf: string) =
            {
                Description = description
                Metadata = metadata
                OnBehalfOf = onBehalfOf
            }

    type CheckoutSessions'CreateShippingAddressCollectionAllowedCountries =
        | [<JsonUnionCase("AC")>] AC
        | [<JsonUnionCase("AD")>] AD
        | [<JsonUnionCase("AE")>] AE
        | [<JsonUnionCase("AF")>] AF
        | [<JsonUnionCase("AG")>] AG
        | [<JsonUnionCase("AI")>] AI
        | [<JsonUnionCase("AL")>] AL
        | [<JsonUnionCase("AM")>] AM
        | [<JsonUnionCase("AO")>] AO
        | [<JsonUnionCase("AQ")>] AQ
        | [<JsonUnionCase("AR")>] AR
        | [<JsonUnionCase("AT")>] AT
        | [<JsonUnionCase("AU")>] AU
        | [<JsonUnionCase("AW")>] AW
        | [<JsonUnionCase("AX")>] AX
        | [<JsonUnionCase("AZ")>] AZ
        | [<JsonUnionCase("BA")>] BA
        | [<JsonUnionCase("BB")>] BB
        | [<JsonUnionCase("BD")>] BD
        | [<JsonUnionCase("BE")>] BE
        | [<JsonUnionCase("BF")>] BF
        | [<JsonUnionCase("BG")>] BG
        | [<JsonUnionCase("BH")>] BH
        | [<JsonUnionCase("BI")>] BI
        | [<JsonUnionCase("BJ")>] BJ
        | [<JsonUnionCase("BL")>] BL
        | [<JsonUnionCase("BM")>] BM
        | [<JsonUnionCase("BN")>] BN
        | [<JsonUnionCase("BO")>] BO
        | [<JsonUnionCase("BQ")>] BQ
        | [<JsonUnionCase("BR")>] BR
        | [<JsonUnionCase("BS")>] BS
        | [<JsonUnionCase("BT")>] BT
        | [<JsonUnionCase("BV")>] BV
        | [<JsonUnionCase("BW")>] BW
        | [<JsonUnionCase("BY")>] BY
        | [<JsonUnionCase("BZ")>] BZ
        | [<JsonUnionCase("CA")>] CA
        | [<JsonUnionCase("CD")>] CD
        | [<JsonUnionCase("CF")>] CF
        | [<JsonUnionCase("CG")>] CG
        | [<JsonUnionCase("CH")>] CH
        | [<JsonUnionCase("CI")>] CI
        | [<JsonUnionCase("CK")>] CK
        | [<JsonUnionCase("CL")>] CL
        | [<JsonUnionCase("CM")>] CM
        | [<JsonUnionCase("CN")>] CN
        | [<JsonUnionCase("CO")>] CO
        | [<JsonUnionCase("CR")>] CR
        | [<JsonUnionCase("CV")>] CV
        | [<JsonUnionCase("CW")>] CW
        | [<JsonUnionCase("CY")>] CY
        | [<JsonUnionCase("CZ")>] CZ
        | [<JsonUnionCase("DE")>] DE
        | [<JsonUnionCase("DJ")>] DJ
        | [<JsonUnionCase("DK")>] DK
        | [<JsonUnionCase("DM")>] DM
        | [<JsonUnionCase("DO")>] DO
        | [<JsonUnionCase("DZ")>] DZ
        | [<JsonUnionCase("EC")>] EC
        | [<JsonUnionCase("EE")>] EE
        | [<JsonUnionCase("EG")>] EG
        | [<JsonUnionCase("EH")>] EH
        | [<JsonUnionCase("ER")>] ER
        | [<JsonUnionCase("ES")>] ES
        | [<JsonUnionCase("ET")>] ET
        | [<JsonUnionCase("FI")>] FI
        | [<JsonUnionCase("FJ")>] FJ
        | [<JsonUnionCase("FK")>] FK
        | [<JsonUnionCase("FO")>] FO
        | [<JsonUnionCase("FR")>] FR
        | [<JsonUnionCase("GA")>] GA
        | [<JsonUnionCase("GB")>] GB
        | [<JsonUnionCase("GD")>] GD
        | [<JsonUnionCase("GE")>] GE
        | [<JsonUnionCase("GF")>] GF
        | [<JsonUnionCase("GG")>] GG
        | [<JsonUnionCase("GH")>] GH
        | [<JsonUnionCase("GI")>] GI
        | [<JsonUnionCase("GL")>] GL
        | [<JsonUnionCase("GM")>] GM
        | [<JsonUnionCase("GN")>] GN
        | [<JsonUnionCase("GP")>] GP
        | [<JsonUnionCase("GQ")>] GQ
        | [<JsonUnionCase("GR")>] GR
        | [<JsonUnionCase("GS")>] GS
        | [<JsonUnionCase("GT")>] GT
        | [<JsonUnionCase("GU")>] GU
        | [<JsonUnionCase("GW")>] GW
        | [<JsonUnionCase("GY")>] GY
        | [<JsonUnionCase("HK")>] HK
        | [<JsonUnionCase("HN")>] HN
        | [<JsonUnionCase("HR")>] HR
        | [<JsonUnionCase("HT")>] HT
        | [<JsonUnionCase("HU")>] HU
        | [<JsonUnionCase("ID")>] ID
        | [<JsonUnionCase("IE")>] IE
        | [<JsonUnionCase("IL")>] IL
        | [<JsonUnionCase("IM")>] IM
        | [<JsonUnionCase("IN")>] IN
        | [<JsonUnionCase("IO")>] IO
        | [<JsonUnionCase("IQ")>] IQ
        | [<JsonUnionCase("IS")>] IS
        | [<JsonUnionCase("IT")>] IT
        | [<JsonUnionCase("JE")>] JE
        | [<JsonUnionCase("JM")>] JM
        | [<JsonUnionCase("JO")>] JO
        | [<JsonUnionCase("JP")>] JP
        | [<JsonUnionCase("KE")>] KE
        | [<JsonUnionCase("KG")>] KG
        | [<JsonUnionCase("KH")>] KH
        | [<JsonUnionCase("KI")>] KI
        | [<JsonUnionCase("KM")>] KM
        | [<JsonUnionCase("KN")>] KN
        | [<JsonUnionCase("KR")>] KR
        | [<JsonUnionCase("KW")>] KW
        | [<JsonUnionCase("KY")>] KY
        | [<JsonUnionCase("KZ")>] KZ
        | [<JsonUnionCase("LA")>] LA
        | [<JsonUnionCase("LB")>] LB
        | [<JsonUnionCase("LC")>] LC
        | [<JsonUnionCase("LI")>] LI
        | [<JsonUnionCase("LK")>] LK
        | [<JsonUnionCase("LR")>] LR
        | [<JsonUnionCase("LS")>] LS
        | [<JsonUnionCase("LT")>] LT
        | [<JsonUnionCase("LU")>] LU
        | [<JsonUnionCase("LV")>] LV
        | [<JsonUnionCase("LY")>] LY
        | [<JsonUnionCase("MA")>] MA
        | [<JsonUnionCase("MC")>] MC
        | [<JsonUnionCase("MD")>] MD
        | [<JsonUnionCase("ME")>] ME
        | [<JsonUnionCase("MF")>] MF
        | [<JsonUnionCase("MG")>] MG
        | [<JsonUnionCase("MK")>] MK
        | [<JsonUnionCase("ML")>] ML
        | [<JsonUnionCase("MM")>] MM
        | [<JsonUnionCase("MN")>] MN
        | [<JsonUnionCase("MO")>] MO
        | [<JsonUnionCase("MQ")>] MQ
        | [<JsonUnionCase("MR")>] MR
        | [<JsonUnionCase("MS")>] MS
        | [<JsonUnionCase("MT")>] MT
        | [<JsonUnionCase("MU")>] MU
        | [<JsonUnionCase("MV")>] MV
        | [<JsonUnionCase("MW")>] MW
        | [<JsonUnionCase("MX")>] MX
        | [<JsonUnionCase("MY")>] MY
        | [<JsonUnionCase("MZ")>] MZ
        | [<JsonUnionCase("NA")>] NA
        | [<JsonUnionCase("NC")>] NC
        | [<JsonUnionCase("NE")>] NE
        | [<JsonUnionCase("NG")>] NG
        | [<JsonUnionCase("NI")>] NI
        | [<JsonUnionCase("NL")>] NL
        | [<JsonUnionCase("NO")>] NO
        | [<JsonUnionCase("NP")>] NP
        | [<JsonUnionCase("NR")>] NR
        | [<JsonUnionCase("NU")>] NU
        | [<JsonUnionCase("NZ")>] NZ
        | [<JsonUnionCase("OM")>] OM
        | [<JsonUnionCase("PA")>] PA
        | [<JsonUnionCase("PE")>] PE
        | [<JsonUnionCase("PF")>] PF
        | [<JsonUnionCase("PG")>] PG
        | [<JsonUnionCase("PH")>] PH
        | [<JsonUnionCase("PK")>] PK
        | [<JsonUnionCase("PL")>] PL
        | [<JsonUnionCase("PM")>] PM
        | [<JsonUnionCase("PN")>] PN
        | [<JsonUnionCase("PR")>] PR
        | [<JsonUnionCase("PS")>] PS
        | [<JsonUnionCase("PT")>] PT
        | [<JsonUnionCase("PY")>] PY
        | [<JsonUnionCase("QA")>] QA
        | [<JsonUnionCase("RE")>] RE
        | [<JsonUnionCase("RO")>] RO
        | [<JsonUnionCase("RS")>] RS
        | [<JsonUnionCase("RU")>] RU
        | [<JsonUnionCase("RW")>] RW
        | [<JsonUnionCase("SA")>] SA
        | [<JsonUnionCase("SB")>] SB
        | [<JsonUnionCase("SC")>] SC
        | [<JsonUnionCase("SE")>] SE
        | [<JsonUnionCase("SG")>] SG
        | [<JsonUnionCase("SH")>] SH
        | [<JsonUnionCase("SI")>] SI
        | [<JsonUnionCase("SJ")>] SJ
        | [<JsonUnionCase("SK")>] SK
        | [<JsonUnionCase("SL")>] SL
        | [<JsonUnionCase("SM")>] SM
        | [<JsonUnionCase("SN")>] SN
        | [<JsonUnionCase("SO")>] SO
        | [<JsonUnionCase("SR")>] SR
        | [<JsonUnionCase("SS")>] SS
        | [<JsonUnionCase("ST")>] ST
        | [<JsonUnionCase("SV")>] SV
        | [<JsonUnionCase("SX")>] SX
        | [<JsonUnionCase("SZ")>] SZ
        | [<JsonUnionCase("TA")>] TA
        | [<JsonUnionCase("TC")>] TC
        | [<JsonUnionCase("TD")>] TD
        | [<JsonUnionCase("TF")>] TF
        | [<JsonUnionCase("TG")>] TG
        | [<JsonUnionCase("TH")>] TH
        | [<JsonUnionCase("TJ")>] TJ
        | [<JsonUnionCase("TK")>] TK
        | [<JsonUnionCase("TL")>] TL
        | [<JsonUnionCase("TM")>] TM
        | [<JsonUnionCase("TN")>] TN
        | [<JsonUnionCase("TO")>] TO
        | [<JsonUnionCase("TR")>] TR
        | [<JsonUnionCase("TT")>] TT
        | [<JsonUnionCase("TV")>] TV
        | [<JsonUnionCase("TW")>] TW
        | [<JsonUnionCase("TZ")>] TZ
        | [<JsonUnionCase("UA")>] UA
        | [<JsonUnionCase("UG")>] UG
        | [<JsonUnionCase("US")>] US
        | [<JsonUnionCase("UY")>] UY
        | [<JsonUnionCase("UZ")>] UZ
        | [<JsonUnionCase("VA")>] VA
        | [<JsonUnionCase("VC")>] VC
        | [<JsonUnionCase("VE")>] VE
        | [<JsonUnionCase("VG")>] VG
        | [<JsonUnionCase("VN")>] VN
        | [<JsonUnionCase("VU")>] VU
        | [<JsonUnionCase("WF")>] WF
        | [<JsonUnionCase("WS")>] WS
        | [<JsonUnionCase("XK")>] XK
        | [<JsonUnionCase("YE")>] YE
        | [<JsonUnionCase("YT")>] YT
        | [<JsonUnionCase("ZA")>] ZA
        | [<JsonUnionCase("ZM")>] ZM
        | [<JsonUnionCase("ZW")>] ZW
        | [<JsonUnionCase("ZZ")>] ZZ

    type CheckoutSessions'CreateShippingAddressCollection = {
        AllowedCountries: CheckoutSessions'CreateShippingAddressCollectionAllowedCountries list option
    }
    with
        static member Create(?allowedCountries: CheckoutSessions'CreateShippingAddressCollectionAllowedCountries list) =
            {
                AllowedCountries = allowedCountries
            }

    type CheckoutSessions'CreateSubscriptionDataItems = {
        Plan: string option
        Quantity: int option
        TaxRates: string list option
    }
    with
        static member Create(?plan: string, ?quantity: int, ?taxRates: string list) =
            {
                Plan = plan
                Quantity = quantity
                TaxRates = taxRates
            }

    type CheckoutSessions'CreateSubscriptionData = {
        ApplicationFeePercent: decimal option
        Coupon: string option
        DefaultTaxRates: string list option
        Items: CheckoutSessions'CreateSubscriptionDataItems list option
        Metadata: Map<string, string> option
        TrialEnd: DateTime option
        TrialFromPlan: bool option
        TrialPeriodDays: int option
    }
    with
        static member Create(?applicationFeePercent: decimal, ?coupon: string, ?defaultTaxRates: string list, ?items: CheckoutSessions'CreateSubscriptionDataItems list, ?metadata: Map<string, string>, ?trialEnd: DateTime, ?trialFromPlan: bool, ?trialPeriodDays: int) =
            {
                ApplicationFeePercent = applicationFeePercent
                Coupon = coupon
                DefaultTaxRates = defaultTaxRates
                Items = items
                Metadata = metadata
                TrialEnd = trialEnd
                TrialFromPlan = trialFromPlan
                TrialPeriodDays = trialPeriodDays
            }

    type CheckoutSessions'CreateBillingAddressCollection =
        | Auto
        | Required

    type CheckoutSessions'CreateLocale =
        | Auto
        | Bg
        | Cs
        | Da
        | De
        | El
        | En
        | [<JsonUnionCase("en-GB")>] EnGB
        | Es
        | [<JsonUnionCase("es-419")>] Es419
        | Et
        | Fi
        | Fr
        | [<JsonUnionCase("fr-CA")>] FrCA
        | Hu
        | Id
        | It
        | Ja
        | Lt
        | Lv
        | Ms
        | Mt
        | Nb
        | Nl
        | Pl
        | Pt
        | [<JsonUnionCase("pt-BR")>] PtBR
        | Ro
        | Ru
        | Sk
        | Sl
        | Sv
        | Tr
        | Zh
        | [<JsonUnionCase("zh-HK")>] ZhHK
        | [<JsonUnionCase("zh-TW")>] ZhTW

    type CheckoutSessions'CreateMode =
        | Payment
        | Setup
        | Subscription

    type CheckoutSessions'CreateSubmitType =
        | Auto
        | Book
        | Donate
        | Pay

    type CheckoutSessions'CreateOptions = {
        AllowPromotionCodes: bool option
        BillingAddressCollection: CheckoutSessions'CreateBillingAddressCollection option
        CancelUrl: string
        ClientReferenceId: string option
        Customer: string option
        CustomerEmail: string option
        Discounts: CheckoutSessions'CreateDiscounts list option
        Expand: string list option
        LineItems: CheckoutSessions'CreateLineItems list option
        Locale: CheckoutSessions'CreateLocale option
        Metadata: Map<string, string> option
        Mode: CheckoutSessions'CreateMode option
        PaymentIntentData: CheckoutSessions'CreatePaymentIntentData option
        PaymentMethodTypes: CheckoutSessions'CreatePaymentMethodTypes list
        SetupIntentData: CheckoutSessions'CreateSetupIntentData option
        ShippingAddressCollection: CheckoutSessions'CreateShippingAddressCollection option
        SubmitType: CheckoutSessions'CreateSubmitType option
        SubscriptionData: CheckoutSessions'CreateSubscriptionData option
        SuccessUrl: string
    }
    with
        static member Create(successUrl: string, cancelUrl: string, paymentMethodTypes: CheckoutSessions'CreatePaymentMethodTypes list, ?submitType: CheckoutSessions'CreateSubmitType, ?shippingAddressCollection: CheckoutSessions'CreateShippingAddressCollection, ?setupIntentData: CheckoutSessions'CreateSetupIntentData, ?paymentIntentData: CheckoutSessions'CreatePaymentIntentData, ?mode: CheckoutSessions'CreateMode, ?metadata: Map<string, string>, ?locale: CheckoutSessions'CreateLocale, ?lineItems: CheckoutSessions'CreateLineItems list, ?expand: string list, ?discounts: CheckoutSessions'CreateDiscounts list, ?customerEmail: string, ?customer: string, ?clientReferenceId: string, ?billingAddressCollection: CheckoutSessions'CreateBillingAddressCollection, ?subscriptionData: CheckoutSessions'CreateSubscriptionData, ?allowPromotionCodes: bool) =
            {
                AllowPromotionCodes = allowPromotionCodes
                BillingAddressCollection = billingAddressCollection
                CancelUrl = cancelUrl
                ClientReferenceId = clientReferenceId
                Customer = customer
                CustomerEmail = customerEmail
                Discounts = discounts
                Expand = expand
                LineItems = lineItems
                Locale = locale
                Metadata = metadata
                Mode = mode
                PaymentIntentData = paymentIntentData
                PaymentMethodTypes = paymentMethodTypes
                SetupIntentData = setupIntentData
                ShippingAddressCollection = shippingAddressCollection
                SubmitType = submitType
                SubscriptionData = subscriptionData
                SuccessUrl = successUrl
            }

    type Coupons'CreateAppliesTo = {
        Products: string list option
    }
    with
        static member Create(?products: string list) =
            {
                Products = products
            }

    type Coupons'CreateDuration =
        | Forever
        | Once
        | Repeating

    type Coupons'CreateOptions = {
        AmountOff: int option
        AppliesTo: Coupons'CreateAppliesTo option
        Currency: string option
        Duration: Coupons'CreateDuration
        DurationInMonths: int option
        Expand: string list option
        Id: string option
        MaxRedemptions: int option
        Metadata: Map<string, string> option
        Name: string option
        PercentOff: decimal option
        RedeemBy: DateTime option
    }
    with
        static member Create(duration: Coupons'CreateDuration, ?amountOff: int, ?appliesTo: Coupons'CreateAppliesTo, ?currency: string, ?durationInMonths: int, ?expand: string list, ?id: string, ?maxRedemptions: int, ?metadata: Map<string, string>, ?name: string, ?percentOff: decimal, ?redeemBy: DateTime) =
            {
                AmountOff = amountOff
                AppliesTo = appliesTo
                Currency = currency
                Duration = duration
                DurationInMonths = durationInMonths
                Expand = expand
                Id = id
                MaxRedemptions = maxRedemptions
                Metadata = metadata
                Name = name
                PercentOff = percentOff
                RedeemBy = redeemBy
            }

    type Coupons'UpdateOptions = {
        Expand: string list option
        Metadata: Map<string, string> option
        Name: string option
    }
    with
        static member Create(?expand: string list, ?metadata: Map<string, string>, ?name: string) =
            {
                Expand = expand
                Metadata = metadata
                Name = name
            }

    type CreditNotes'CreateLinesType =
        | CustomLineItem
        | InvoiceLineItem

    type CreditNotes'CreateLines = {
        Amount: int option
        Description: string option
        InvoiceLineItem: string option
        Quantity: int option
        TaxRates: Choice<string list,string> option
        Type: CreditNotes'CreateLinesType option
        UnitAmount: int option
        UnitAmountDecimal: string option
    }
    with
        static member Create(?amount: int, ?description: string, ?invoiceLineItem: string, ?quantity: int, ?taxRates: Choice<string list,string>, ?``type``: CreditNotes'CreateLinesType, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Amount = amount
                Description = description
                InvoiceLineItem = invoiceLineItem
                Quantity = quantity
                TaxRates = taxRates
                Type = ``type``
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type CreditNotes'CreateReason =
        | Duplicate
        | Fraudulent
        | OrderChange
        | ProductUnsatisfactory

    type CreditNotes'CreateOptions = {
        Amount: int option
        CreditAmount: int option
        Expand: string list option
        Invoice: string
        Lines: CreditNotes'CreateLines list option
        Memo: string option
        Metadata: Map<string, string> option
        OutOfBandAmount: int option
        Reason: CreditNotes'CreateReason option
        Refund: string option
        RefundAmount: int option
    }
    with
        static member Create(invoice: string, ?amount: int, ?creditAmount: int, ?expand: string list, ?lines: CreditNotes'CreateLines list, ?memo: string, ?metadata: Map<string, string>, ?outOfBandAmount: int, ?reason: CreditNotes'CreateReason, ?refund: string, ?refundAmount: int) =
            {
                Amount = amount
                CreditAmount = creditAmount
                Expand = expand
                Invoice = invoice
                Lines = lines
                Memo = memo
                Metadata = metadata
                OutOfBandAmount = outOfBandAmount
                Reason = reason
                Refund = refund
                RefundAmount = refundAmount
            }

    type CreditNotes'UpdateOptions = {
        Expand: string list option
        Memo: string option
        Metadata: Map<string, string> option
    }
    with
        static member Create(?expand: string list, ?memo: string, ?metadata: Map<string, string>) =
            {
                Expand = expand
                Memo = memo
                Metadata = metadata
            }

    type CreditNotesVoid'VoidCreditNoteOptions = {
        Expand: string list option
    }
    with
        static member Create(?expand: string list) =
            {
                Expand = expand
            }

    type Customers'CreateAddressAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Customers'CreateInvoiceSettingsCustomFields = {
        Name: string option
        Value: string option
    }
    with
        static member Create(?name: string, ?value: string) =
            {
                Name = name
                Value = value
            }

    type Customers'CreateInvoiceSettings = {
        CustomFields: Choice<Customers'CreateInvoiceSettingsCustomFields list,string> option
        DefaultPaymentMethod: string option
        Footer: string option
    }
    with
        static member Create(?customFields: Choice<Customers'CreateInvoiceSettingsCustomFields list,string>, ?defaultPaymentMethod: string, ?footer: string) =
            {
                CustomFields = customFields
                DefaultPaymentMethod = defaultPaymentMethod
                Footer = footer
            }

    type Customers'CreateShippingCustomerShippingAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Customers'CreateShippingCustomerShipping = {
        Address: Customers'CreateShippingCustomerShippingAddress option
        Name: string option
        Phone: string option
    }
    with
        static member Create(?address: Customers'CreateShippingCustomerShippingAddress, ?name: string, ?phone: string) =
            {
                Address = address
                Name = name
                Phone = phone
            }

    type Customers'CreateTaxIdDataType =
        | AeTrn
        | AuAbn
        | BrCnpj
        | BrCpf
        | CaBn
        | CaQst
        | ChVat
        | ClTin
        | EsCif
        | EuVat
        | HkBr
        | IdNpwp
        | InGst
        | JpCn
        | JpRn
        | KrBrn
        | LiUid
        | MxRfc
        | MyFrp
        | MyItn
        | MySst
        | NoVat
        | NzGst
        | RuInn
        | RuKpp
        | SaVat
        | SgGst
        | SgUen
        | ThVat
        | TwVat
        | UsEin
        | ZaVat

    type Customers'CreateTaxIdData = {
        Type: Customers'CreateTaxIdDataType option
        Value: string option
    }
    with
        static member Create(?``type``: Customers'CreateTaxIdDataType, ?value: string) =
            {
                Type = ``type``
                Value = value
            }

    type Customers'CreateTaxExempt =
        | Exempt
        | None'
        | Reverse

    type Customers'CreateOptions = {
        Address: Choice<Customers'CreateAddressAddress,string> option
        Balance: int option
        Coupon: string option
        Description: string option
        Email: string option
        Expand: string list option
        InvoicePrefix: string option
        InvoiceSettings: Customers'CreateInvoiceSettings option
        Metadata: Map<string, string> option
        Name: string option
        NextInvoiceSequence: int option
        PaymentMethod: string option
        Phone: string option
        PreferredLocales: string list option
        PromotionCode: string option
        Shipping: Choice<Customers'CreateShippingCustomerShipping,string> option
        Source: string option
        TaxExempt: Customers'CreateTaxExempt option
        TaxIdData: Customers'CreateTaxIdData list option
    }
    with
        static member Create(?address: Choice<Customers'CreateAddressAddress,string>, ?source: string, ?shipping: Choice<Customers'CreateShippingCustomerShipping,string>, ?promotionCode: string, ?preferredLocales: string list, ?phone: string, ?paymentMethod: string, ?nextInvoiceSequence: int, ?taxExempt: Customers'CreateTaxExempt, ?name: string, ?invoiceSettings: Customers'CreateInvoiceSettings, ?invoicePrefix: string, ?expand: string list, ?email: string, ?description: string, ?coupon: string, ?balance: int, ?metadata: Map<string, string>, ?taxIdData: Customers'CreateTaxIdData list) =
            {
                Address = address
                Balance = balance
                Coupon = coupon
                Description = description
                Email = email
                Expand = expand
                InvoicePrefix = invoicePrefix
                InvoiceSettings = invoiceSettings
                Metadata = metadata
                Name = name
                NextInvoiceSequence = nextInvoiceSequence
                PaymentMethod = paymentMethod
                Phone = phone
                PreferredLocales = preferredLocales
                PromotionCode = promotionCode
                Shipping = shipping
                Source = source
                TaxExempt = taxExempt
                TaxIdData = taxIdData
            }

    type Customers'UpdateAddressAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Customers'UpdateInvoiceSettingsCustomFields = {
        Name: string option
        Value: string option
    }
    with
        static member Create(?name: string, ?value: string) =
            {
                Name = name
                Value = value
            }

    type Customers'UpdateInvoiceSettings = {
        CustomFields: Choice<Customers'UpdateInvoiceSettingsCustomFields list,string> option
        DefaultPaymentMethod: string option
        Footer: string option
    }
    with
        static member Create(?customFields: Choice<Customers'UpdateInvoiceSettingsCustomFields list,string>, ?defaultPaymentMethod: string, ?footer: string) =
            {
                CustomFields = customFields
                DefaultPaymentMethod = defaultPaymentMethod
                Footer = footer
            }

    type Customers'UpdateShippingCustomerShippingAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Customers'UpdateShippingCustomerShipping = {
        Address: Customers'UpdateShippingCustomerShippingAddress option
        Name: string option
        Phone: string option
    }
    with
        static member Create(?address: Customers'UpdateShippingCustomerShippingAddress, ?name: string, ?phone: string) =
            {
                Address = address
                Name = name
                Phone = phone
            }

    type Customers'UpdateTrialEnd =
        | Now

    type Customers'UpdateTaxExempt =
        | Exempt
        | None'
        | Reverse

    type Customers'UpdateOptions = {
        Address: Choice<Customers'UpdateAddressAddress,string> option
        Balance: int option
        Coupon: string option
        DefaultSource: string option
        Description: string option
        Email: string option
        Expand: string list option
        InvoicePrefix: string option
        InvoiceSettings: Customers'UpdateInvoiceSettings option
        Metadata: Map<string, string> option
        Name: string option
        NextInvoiceSequence: int option
        Phone: string option
        PreferredLocales: string list option
        PromotionCode: string option
        Shipping: Choice<Customers'UpdateShippingCustomerShipping,string> option
        Source: string option
        TaxExempt: Customers'UpdateTaxExempt option
        TrialEnd: Choice<Customers'UpdateTrialEnd,DateTime> option
    }
    with
        static member Create(?address: Choice<Customers'UpdateAddressAddress,string>, ?source: string, ?shipping: Choice<Customers'UpdateShippingCustomerShipping,string>, ?promotionCode: string, ?preferredLocales: string list, ?phone: string, ?nextInvoiceSequence: int, ?name: string, ?taxExempt: Customers'UpdateTaxExempt, ?metadata: Map<string, string>, ?invoicePrefix: string, ?expand: string list, ?email: string, ?description: string, ?defaultSource: string, ?coupon: string, ?balance: int, ?invoiceSettings: Customers'UpdateInvoiceSettings, ?trialEnd: Choice<Customers'UpdateTrialEnd,DateTime>) =
            {
                Address = address
                Balance = balance
                Coupon = coupon
                DefaultSource = defaultSource
                Description = description
                Email = email
                Expand = expand
                InvoicePrefix = invoicePrefix
                InvoiceSettings = invoiceSettings
                Metadata = metadata
                Name = name
                NextInvoiceSequence = nextInvoiceSequence
                Phone = phone
                PreferredLocales = preferredLocales
                PromotionCode = promotionCode
                Shipping = shipping
                Source = source
                TaxExempt = taxExempt
                TrialEnd = trialEnd
            }

    type CustomersBalanceTransactions'CreateOptions = {
        Amount: int
        Currency: string
        Description: string option
        Expand: string list option
        Metadata: Map<string, string> option
    }
    with
        static member Create(amount: int, currency: string, ?description: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Amount = amount
                Currency = currency
                Description = description
                Expand = expand
                Metadata = metadata
            }

    type CustomersBalanceTransactions'UpdateOptions = {
        Description: string option
        Expand: string list option
        Metadata: Map<string, string> option
    }
    with
        static member Create(?description: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Description = description
                Expand = expand
                Metadata = metadata
            }

    type CustomersSources'CreateOptions = {
        Expand: string list option
        Metadata: Map<string, string> option
        Source: string
    }
    with
        static member Create(source: string, ?metadata: Map<string, string>, ?expand: string list) =
            {
                Expand = expand
                Metadata = metadata
                Source = source
            }

    type CustomersSources'DeleteOptions = {
        Expand: string list option
    }
    with
        static member Create(?expand: string list) =
            {
                Expand = expand
            }

    type CustomersSources'UpdateOwnerAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type CustomersSources'UpdateOwner = {
        Address: CustomersSources'UpdateOwnerAddress option
        Email: string option
        Name: string option
        Phone: string option
    }
    with
        static member Create(?address: CustomersSources'UpdateOwnerAddress, ?email: string, ?name: string, ?phone: string) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
            }

    type CustomersSources'UpdateAccountHolderType =
        | Company
        | Individual

    type CustomersSources'UpdateOptions = {
        AccountHolderName: string option
        AccountHolderType: CustomersSources'UpdateAccountHolderType option
        AddressCity: string option
        AddressCountry: string option
        AddressLine1: string option
        AddressLine2: string option
        AddressState: string option
        AddressZip: string option
        ExpMonth: string option
        ExpYear: string option
        Expand: string list option
        Metadata: Map<string, string> option
        Name: string option
        Owner: CustomersSources'UpdateOwner option
    }
    with
        static member Create(?accountHolderName: string, ?accountHolderType: CustomersSources'UpdateAccountHolderType, ?addressCity: string, ?addressCountry: string, ?addressLine1: string, ?addressLine2: string, ?addressState: string, ?addressZip: string, ?expMonth: string, ?expYear: string, ?expand: string list, ?metadata: Map<string, string>, ?name: string, ?owner: CustomersSources'UpdateOwner) =
            {
                AccountHolderName = accountHolderName
                AccountHolderType = accountHolderType
                AddressCity = addressCity
                AddressCountry = addressCountry
                AddressLine1 = addressLine1
                AddressLine2 = addressLine2
                AddressState = addressState
                AddressZip = addressZip
                ExpMonth = expMonth
                ExpYear = expYear
                Expand = expand
                Metadata = metadata
                Name = name
                Owner = owner
            }

    type CustomersSourcesVerify'VerifyOptions = {
        Amounts: int list option
        Expand: string list option
    }
    with
        static member Create(?amounts: int list, ?expand: string list) =
            {
                Amounts = amounts
                Expand = expand
            }

    type CustomersTaxIds'CreateType =
        | AeTrn
        | AuAbn
        | BrCnpj
        | BrCpf
        | CaBn
        | CaQst
        | ChVat
        | ClTin
        | EsCif
        | EuVat
        | HkBr
        | IdNpwp
        | InGst
        | JpCn
        | JpRn
        | KrBrn
        | LiUid
        | MxRfc
        | MyFrp
        | MyItn
        | MySst
        | NoVat
        | NzGst
        | RuInn
        | RuKpp
        | SaVat
        | SgGst
        | SgUen
        | ThVat
        | TwVat
        | UsEin
        | ZaVat

    type CustomersTaxIds'CreateOptions = {
        Expand: string list option
        Type: CustomersTaxIds'CreateType
        Value: string
    }
    with
        static member Create(``type``: CustomersTaxIds'CreateType, value: string, ?expand: string list) =
            {
                Expand = expand
                Type = ``type``
                Value = value
            }

    type Disputes'UpdateEvidence = {
        AccessActivityLog: string option
        BillingAddress: string option
        CancellationPolicy: string option
        CancellationPolicyDisclosure: string option
        CancellationRebuttal: string option
        CustomerCommunication: string option
        CustomerEmailAddress: string option
        CustomerName: string option
        CustomerPurchaseIp: string option
        CustomerSignature: string option
        DuplicateChargeDocumentation: string option
        DuplicateChargeExplanation: string option
        DuplicateChargeId: string option
        ProductDescription: string option
        Receipt: string option
        RefundPolicy: string option
        RefundPolicyDisclosure: string option
        RefundRefusalExplanation: string option
        ServiceDate: string option
        ServiceDocumentation: string option
        ShippingAddress: string option
        ShippingCarrier: string option
        ShippingDate: string option
        ShippingDocumentation: string option
        ShippingTrackingNumber: string option
        UncategorizedFile: string option
        UncategorizedText: string option
    }
    with
        static member Create(?accessActivityLog: string, ?shippingTrackingNumber: string, ?shippingDocumentation: string, ?shippingDate: string, ?shippingCarrier: string, ?shippingAddress: string, ?serviceDocumentation: string, ?serviceDate: string, ?refundRefusalExplanation: string, ?refundPolicyDisclosure: string, ?refundPolicy: string, ?receipt: string, ?uncategorizedFile: string, ?productDescription: string, ?duplicateChargeExplanation: string, ?duplicateChargeDocumentation: string, ?customerSignature: string, ?customerPurchaseIp: string, ?customerName: string, ?customerEmailAddress: string, ?customerCommunication: string, ?cancellationRebuttal: string, ?cancellationPolicyDisclosure: string, ?cancellationPolicy: string, ?billingAddress: string, ?duplicateChargeId: string, ?uncategorizedText: string) =
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

    type Disputes'UpdateOptions = {
        Evidence: Disputes'UpdateEvidence option
        Expand: string list option
        Metadata: Map<string, string> option
        Submit: bool option
    }
    with
        static member Create(?evidence: Disputes'UpdateEvidence, ?expand: string list, ?metadata: Map<string, string>, ?submit: bool) =
            {
                Evidence = evidence
                Expand = expand
                Metadata = metadata
                Submit = submit
            }

    type DisputesClose'CloseOptions = {
        Expand: string list option
    }
    with
        static member Create(?expand: string list) =
            {
                Expand = expand
            }

    type EphemeralKeys'CreateOptions = {
        Customer: string option
        Expand: string list option
        IssuingCard: string option
    }
    with
        static member Create(?customer: string, ?expand: string list, ?issuingCard: string) =
            {
                Customer = customer
                Expand = expand
                IssuingCard = issuingCard
            }

    type EphemeralKeys'DeleteOptions = {
        Expand: string list option
    }
    with
        static member Create(?expand: string list) =
            {
                Expand = expand
            }

    type FileLinks'CreateOptions = {
        Expand: string list option
        ExpiresAt: DateTime option
        File: string
        Metadata: Map<string, string> option
    }
    with
        static member Create(file: string, ?expand: string list, ?expiresAt: DateTime, ?metadata: Map<string, string>) =
            {
                Expand = expand
                ExpiresAt = expiresAt
                File = file
                Metadata = metadata
            }

    type FileLinks'UpdateExpiresAt =
        | Now

    type FileLinks'UpdateOptions = {
        Expand: string list option
        ExpiresAt: Choice<FileLinks'UpdateExpiresAt,DateTime,string> option
        Metadata: Map<string, string> option
    }
    with
        static member Create(?expand: string list, ?expiresAt: Choice<FileLinks'UpdateExpiresAt,DateTime,string>, ?metadata: Map<string, string>) =
            {
                Expand = expand
                ExpiresAt = expiresAt
                Metadata = metadata
            }

    type Files'CreateFileLinkData = {
        Create: bool option
        ExpiresAt: DateTime option
        Metadata: Map<string, string> option
    }
    with
        static member Create'(?create: bool, ?expiresAt: DateTime, ?metadata: Map<string, string>) =
            {
                Create = create
                ExpiresAt = expiresAt
                Metadata = metadata
            }

    type Files'CreatePurpose =
        | AdditionalVerification
        | BusinessIcon
        | BusinessLogo
        | CustomerSignature
        | DisputeEvidence
        | IdentityDocument
        | PciDocument
        | TaxDocumentUserUpload

    type Files'CreateOptions = {
        Expand: string list option
        File: string
        FileLinkData: Files'CreateFileLinkData option
        Purpose: Files'CreatePurpose
    }
    with
        static member Create(file: string, purpose: Files'CreatePurpose, ?expand: string list, ?fileLinkData: Files'CreateFileLinkData) =
            {
                Expand = expand
                File = file
                FileLinkData = fileLinkData
                Purpose = purpose
            }

    type Invoiceitems'CreateDiscounts = {
        Coupon: string option
        Discount: string option
    }
    with
        static member Create(?coupon: string, ?discount: string) =
            {
                Coupon = coupon
                Discount = discount
            }

    type Invoiceitems'CreatePeriod = {
        End: DateTime option
        Start: DateTime option
    }
    with
        static member Create(?``end``: DateTime, ?start: DateTime) =
            {
                End = ``end``
                Start = start
            }

    type Invoiceitems'CreatePriceData = {
        Currency: string option
        Product: string option
        UnitAmount: int option
        UnitAmountDecimal: string option
    }
    with
        static member Create(?currency: string, ?product: string, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Invoiceitems'CreateOptions = {
        Amount: int option
        Currency: string option
        Customer: string
        Description: string option
        Discountable: bool option
        Discounts: Choice<Invoiceitems'CreateDiscounts list,string> option
        Expand: string list option
        Invoice: string option
        Metadata: Map<string, string> option
        Period: Invoiceitems'CreatePeriod option
        Price: string option
        PriceData: Invoiceitems'CreatePriceData option
        Quantity: int option
        Subscription: string option
        TaxRates: string list option
        UnitAmount: int option
        UnitAmountDecimal: string option
    }
    with
        static member Create(customer: string, ?amount: int, ?taxRates: string list, ?subscription: string, ?quantity: int, ?priceData: Invoiceitems'CreatePriceData, ?price: string, ?period: Invoiceitems'CreatePeriod, ?metadata: Map<string, string>, ?invoice: string, ?expand: string list, ?discounts: Choice<Invoiceitems'CreateDiscounts list,string>, ?discountable: bool, ?description: string, ?currency: string, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Amount = amount
                Currency = currency
                Customer = customer
                Description = description
                Discountable = discountable
                Discounts = discounts
                Expand = expand
                Invoice = invoice
                Metadata = metadata
                Period = period
                Price = price
                PriceData = priceData
                Quantity = quantity
                Subscription = subscription
                TaxRates = taxRates
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Invoiceitems'UpdateDiscounts = {
        Coupon: string option
        Discount: string option
    }
    with
        static member Create(?coupon: string, ?discount: string) =
            {
                Coupon = coupon
                Discount = discount
            }

    type Invoiceitems'UpdatePeriod = {
        End: DateTime option
        Start: DateTime option
    }
    with
        static member Create(?``end``: DateTime, ?start: DateTime) =
            {
                End = ``end``
                Start = start
            }

    type Invoiceitems'UpdatePriceData = {
        Currency: string option
        Product: string option
        UnitAmount: int option
        UnitAmountDecimal: string option
    }
    with
        static member Create(?currency: string, ?product: string, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Invoiceitems'UpdateOptions = {
        Amount: int option
        Description: string option
        Discountable: bool option
        Discounts: Choice<Invoiceitems'UpdateDiscounts list,string> option
        Expand: string list option
        Metadata: Map<string, string> option
        Period: Invoiceitems'UpdatePeriod option
        Price: string option
        PriceData: Invoiceitems'UpdatePriceData option
        Quantity: int option
        TaxRates: Choice<string list,string> option
        UnitAmount: int option
        UnitAmountDecimal: string option
    }
    with
        static member Create(?amount: int, ?description: string, ?discountable: bool, ?discounts: Choice<Invoiceitems'UpdateDiscounts list,string>, ?expand: string list, ?metadata: Map<string, string>, ?period: Invoiceitems'UpdatePeriod, ?price: string, ?priceData: Invoiceitems'UpdatePriceData, ?quantity: int, ?taxRates: Choice<string list,string>, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Amount = amount
                Description = description
                Discountable = discountable
                Discounts = discounts
                Expand = expand
                Metadata = metadata
                Period = period
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Invoices'CreateCustomFields = {
        Name: string option
        Value: string option
    }
    with
        static member Create(?name: string, ?value: string) =
            {
                Name = name
                Value = value
            }

    type Invoices'CreateDiscounts = {
        Coupon: string option
        Discount: string option
    }
    with
        static member Create(?coupon: string, ?discount: string) =
            {
                Coupon = coupon
                Discount = discount
            }

    type Invoices'CreateTransferData = {
        Amount: int option
        Destination: string option
    }
    with
        static member Create(?amount: int, ?destination: string) =
            {
                Amount = amount
                Destination = destination
            }

    type Invoices'CreateCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    type Invoices'CreateOptions = {
        AccountTaxIds: Choice<string list,string> option
        ApplicationFeeAmount: int option
        AutoAdvance: bool option
        CollectionMethod: Invoices'CreateCollectionMethod option
        CustomFields: Choice<Invoices'CreateCustomFields list,string> option
        Customer: string
        DaysUntilDue: int option
        DefaultPaymentMethod: string option
        DefaultSource: string option
        DefaultTaxRates: string list option
        Description: string option
        Discounts: Choice<Invoices'CreateDiscounts list,string> option
        DueDate: DateTime option
        Expand: string list option
        Footer: string option
        Metadata: Map<string, string> option
        StatementDescriptor: string option
        Subscription: string option
        TransferData: Invoices'CreateTransferData option
    }
    with
        static member Create(customer: string, ?accountTaxIds: Choice<string list,string>, ?statementDescriptor: string, ?metadata: Map<string, string>, ?footer: string, ?expand: string list, ?dueDate: DateTime, ?discounts: Choice<Invoices'CreateDiscounts list,string>, ?description: string, ?defaultTaxRates: string list, ?defaultSource: string, ?defaultPaymentMethod: string, ?daysUntilDue: int, ?customFields: Choice<Invoices'CreateCustomFields list,string>, ?collectionMethod: Invoices'CreateCollectionMethod, ?autoAdvance: bool, ?applicationFeeAmount: int, ?subscription: string, ?transferData: Invoices'CreateTransferData) =
            {
                AccountTaxIds = accountTaxIds
                ApplicationFeeAmount = applicationFeeAmount
                AutoAdvance = autoAdvance
                CollectionMethod = collectionMethod
                CustomFields = customFields
                Customer = customer
                DaysUntilDue = daysUntilDue
                DefaultPaymentMethod = defaultPaymentMethod
                DefaultSource = defaultSource
                DefaultTaxRates = defaultTaxRates
                Description = description
                Discounts = discounts
                DueDate = dueDate
                Expand = expand
                Footer = footer
                Metadata = metadata
                StatementDescriptor = statementDescriptor
                Subscription = subscription
                TransferData = transferData
            }

    type Invoices'UpdateCustomFields = {
        Name: string option
        Value: string option
    }
    with
        static member Create(?name: string, ?value: string) =
            {
                Name = name
                Value = value
            }

    type Invoices'UpdateDiscounts = {
        Coupon: string option
        Discount: string option
    }
    with
        static member Create(?coupon: string, ?discount: string) =
            {
                Coupon = coupon
                Discount = discount
            }

    type Invoices'UpdateTransferDataTransferDataSpecs = {
        Amount: int option
        Destination: string option
    }
    with
        static member Create(?amount: int, ?destination: string) =
            {
                Amount = amount
                Destination = destination
            }

    type Invoices'UpdateCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    type Invoices'UpdateOptions = {
        AccountTaxIds: Choice<string list,string> option
        ApplicationFeeAmount: int option
        AutoAdvance: bool option
        CollectionMethod: Invoices'UpdateCollectionMethod option
        CustomFields: Choice<Invoices'UpdateCustomFields list,string> option
        DaysUntilDue: int option
        DefaultPaymentMethod: string option
        DefaultSource: string option
        DefaultTaxRates: Choice<string list,string> option
        Description: string option
        Discounts: Choice<Invoices'UpdateDiscounts list,string> option
        DueDate: DateTime option
        Expand: string list option
        Footer: string option
        Metadata: Map<string, string> option
        StatementDescriptor: string option
        TransferData: Choice<Invoices'UpdateTransferDataTransferDataSpecs,string> option
    }
    with
        static member Create(?accountTaxIds: Choice<string list,string>, ?metadata: Map<string, string>, ?footer: string, ?expand: string list, ?dueDate: DateTime, ?discounts: Choice<Invoices'UpdateDiscounts list,string>, ?description: string, ?statementDescriptor: string, ?defaultTaxRates: Choice<string list,string>, ?defaultPaymentMethod: string, ?daysUntilDue: int, ?customFields: Choice<Invoices'UpdateCustomFields list,string>, ?collectionMethod: Invoices'UpdateCollectionMethod, ?autoAdvance: bool, ?applicationFeeAmount: int, ?defaultSource: string, ?transferData: Choice<Invoices'UpdateTransferDataTransferDataSpecs,string>) =
            {
                AccountTaxIds = accountTaxIds
                ApplicationFeeAmount = applicationFeeAmount
                AutoAdvance = autoAdvance
                CollectionMethod = collectionMethod
                CustomFields = customFields
                DaysUntilDue = daysUntilDue
                DefaultPaymentMethod = defaultPaymentMethod
                DefaultSource = defaultSource
                DefaultTaxRates = defaultTaxRates
                Description = description
                Discounts = discounts
                DueDate = dueDate
                Expand = expand
                Footer = footer
                Metadata = metadata
                StatementDescriptor = statementDescriptor
                TransferData = transferData
            }

    type InvoicesFinalize'FinalizeInvoiceOptions = {
        AutoAdvance: bool option
        Expand: string list option
    }
    with
        static member Create(?autoAdvance: bool, ?expand: string list) =
            {
                AutoAdvance = autoAdvance
                Expand = expand
            }

    type InvoicesMarkUncollectible'MarkUncollectibleOptions = {
        Expand: string list option
    }
    with
        static member Create(?expand: string list) =
            {
                Expand = expand
            }

    type InvoicesPay'PayOptions = {
        Expand: string list option
        Forgive: bool option
        OffSession: bool option
        PaidOutOfBand: bool option
        PaymentMethod: string option
        Source: string option
    }
    with
        static member Create(?expand: string list, ?forgive: bool, ?offSession: bool, ?paidOutOfBand: bool, ?paymentMethod: string, ?source: string) =
            {
                Expand = expand
                Forgive = forgive
                OffSession = offSession
                PaidOutOfBand = paidOutOfBand
                PaymentMethod = paymentMethod
                Source = source
            }

    type InvoicesSend'SendInvoiceOptions = {
        Expand: string list option
    }
    with
        static member Create(?expand: string list) =
            {
                Expand = expand
            }

    type InvoicesVoid'VoidInvoiceOptions = {
        Expand: string list option
    }
    with
        static member Create(?expand: string list) =
            {
                Expand = expand
            }

    type IssuingAuthorizations'UpdateOptions = {
        Expand: string list option
        Metadata: Map<string, string> option
    }
    with
        static member Create(?expand: string list, ?metadata: Map<string, string>) =
            {
                Expand = expand
                Metadata = metadata
            }

    type IssuingAuthorizationsApprove'ApproveOptions = {
        Amount: int option
        Expand: string list option
        Metadata: Map<string, string> option
    }
    with
        static member Create(?amount: int, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Amount = amount
                Expand = expand
                Metadata = metadata
            }

    type IssuingAuthorizationsDecline'DeclineOptions = {
        Expand: string list option
        Metadata: Map<string, string> option
    }
    with
        static member Create(?expand: string list, ?metadata: Map<string, string>) =
            {
                Expand = expand
                Metadata = metadata
            }

    type IssuingCardholders'CreateBillingAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type IssuingCardholders'CreateBilling = {
        Address: IssuingCardholders'CreateBillingAddress option
    }
    with
        static member Create(?address: IssuingCardholders'CreateBillingAddress) =
            {
                Address = address
            }

    type IssuingCardholders'CreateCompany = {
        TaxId: string option
    }
    with
        static member Create(?taxId: string) =
            {
                TaxId = taxId
            }

    type IssuingCardholders'CreateIndividualDob = {
        Day: int option
        Month: int option
        Year: int option
    }
    with
        static member Create(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type IssuingCardholders'CreateIndividualVerificationDocument = {
        Back: string option
        Front: string option
    }
    with
        static member Create(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type IssuingCardholders'CreateIndividualVerification = {
        Document: IssuingCardholders'CreateIndividualVerificationDocument option
    }
    with
        static member Create(?document: IssuingCardholders'CreateIndividualVerificationDocument) =
            {
                Document = document
            }

    type IssuingCardholders'CreateIndividual = {
        Dob: IssuingCardholders'CreateIndividualDob option
        FirstName: string option
        LastName: string option
        Verification: IssuingCardholders'CreateIndividualVerification option
    }
    with
        static member Create(?dob: IssuingCardholders'CreateIndividualDob, ?firstName: string, ?lastName: string, ?verification: IssuingCardholders'CreateIndividualVerification) =
            {
                Dob = dob
                FirstName = firstName
                LastName = lastName
                Verification = verification
            }

    type IssuingCardholders'CreateSpendingControlsAllowedCategories =
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
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
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

    type IssuingCardholders'CreateSpendingControlsBlockedCategories =
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
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
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

    type IssuingCardholders'CreateSpendingControlsSpendingLimitsCategories =
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
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
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

    type IssuingCardholders'CreateSpendingControlsSpendingLimitsInterval =
        | AllTime
        | Daily
        | Monthly
        | PerAuthorization
        | Weekly
        | Yearly

    type IssuingCardholders'CreateSpendingControlsSpendingLimits = {
        Amount: int option
        Categories: IssuingCardholders'CreateSpendingControlsSpendingLimitsCategories list option
        Interval: IssuingCardholders'CreateSpendingControlsSpendingLimitsInterval option
    }
    with
        static member Create(?amount: int, ?categories: IssuingCardholders'CreateSpendingControlsSpendingLimitsCategories list, ?interval: IssuingCardholders'CreateSpendingControlsSpendingLimitsInterval) =
            {
                Amount = amount
                Categories = categories
                Interval = interval
            }

    type IssuingCardholders'CreateSpendingControls = {
        AllowedCategories: IssuingCardholders'CreateSpendingControlsAllowedCategories list option
        BlockedCategories: IssuingCardholders'CreateSpendingControlsBlockedCategories list option
        SpendingLimits: IssuingCardholders'CreateSpendingControlsSpendingLimits list option
        SpendingLimitsCurrency: string option
    }
    with
        static member Create(?allowedCategories: IssuingCardholders'CreateSpendingControlsAllowedCategories list, ?blockedCategories: IssuingCardholders'CreateSpendingControlsBlockedCategories list, ?spendingLimits: IssuingCardholders'CreateSpendingControlsSpendingLimits list, ?spendingLimitsCurrency: string) =
            {
                AllowedCategories = allowedCategories
                BlockedCategories = blockedCategories
                SpendingLimits = spendingLimits
                SpendingLimitsCurrency = spendingLimitsCurrency
            }

    type IssuingCardholders'CreateStatus =
        | Active
        | Inactive

    type IssuingCardholders'CreateType =
        | Company
        | Individual

    type IssuingCardholders'CreateOptions = {
        Billing: IssuingCardholders'CreateBilling
        Company: IssuingCardholders'CreateCompany option
        Email: string option
        Expand: string list option
        Individual: IssuingCardholders'CreateIndividual option
        Metadata: Map<string, string> option
        Name: string
        PhoneNumber: string option
        SpendingControls: IssuingCardholders'CreateSpendingControls option
        Status: IssuingCardholders'CreateStatus option
        Type: IssuingCardholders'CreateType
    }
    with
        static member Create(billing: IssuingCardholders'CreateBilling, name: string, ``type``: IssuingCardholders'CreateType, ?company: IssuingCardholders'CreateCompany, ?email: string, ?expand: string list, ?individual: IssuingCardholders'CreateIndividual, ?metadata: Map<string, string>, ?phoneNumber: string, ?spendingControls: IssuingCardholders'CreateSpendingControls, ?status: IssuingCardholders'CreateStatus) =
            {
                Billing = billing
                Company = company
                Email = email
                Expand = expand
                Individual = individual
                Metadata = metadata
                Name = name
                PhoneNumber = phoneNumber
                SpendingControls = spendingControls
                Status = status
                Type = ``type``
            }

    type IssuingCardholders'UpdateBillingAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type IssuingCardholders'UpdateBilling = {
        Address: IssuingCardholders'UpdateBillingAddress option
    }
    with
        static member Create(?address: IssuingCardholders'UpdateBillingAddress) =
            {
                Address = address
            }

    type IssuingCardholders'UpdateCompany = {
        TaxId: string option
    }
    with
        static member Create(?taxId: string) =
            {
                TaxId = taxId
            }

    type IssuingCardholders'UpdateIndividualDob = {
        Day: int option
        Month: int option
        Year: int option
    }
    with
        static member Create(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type IssuingCardholders'UpdateIndividualVerificationDocument = {
        Back: string option
        Front: string option
    }
    with
        static member Create(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type IssuingCardholders'UpdateIndividualVerification = {
        Document: IssuingCardholders'UpdateIndividualVerificationDocument option
    }
    with
        static member Create(?document: IssuingCardholders'UpdateIndividualVerificationDocument) =
            {
                Document = document
            }

    type IssuingCardholders'UpdateIndividual = {
        Dob: IssuingCardholders'UpdateIndividualDob option
        FirstName: string option
        LastName: string option
        Verification: IssuingCardholders'UpdateIndividualVerification option
    }
    with
        static member Create(?dob: IssuingCardholders'UpdateIndividualDob, ?firstName: string, ?lastName: string, ?verification: IssuingCardholders'UpdateIndividualVerification) =
            {
                Dob = dob
                FirstName = firstName
                LastName = lastName
                Verification = verification
            }

    type IssuingCardholders'UpdateSpendingControlsAllowedCategories =
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
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
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

    type IssuingCardholders'UpdateSpendingControlsBlockedCategories =
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
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
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

    type IssuingCardholders'UpdateSpendingControlsSpendingLimitsCategories =
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
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
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

    type IssuingCardholders'UpdateSpendingControlsSpendingLimitsInterval =
        | AllTime
        | Daily
        | Monthly
        | PerAuthorization
        | Weekly
        | Yearly

    type IssuingCardholders'UpdateSpendingControlsSpendingLimits = {
        Amount: int option
        Categories: IssuingCardholders'UpdateSpendingControlsSpendingLimitsCategories list option
        Interval: IssuingCardholders'UpdateSpendingControlsSpendingLimitsInterval option
    }
    with
        static member Create(?amount: int, ?categories: IssuingCardholders'UpdateSpendingControlsSpendingLimitsCategories list, ?interval: IssuingCardholders'UpdateSpendingControlsSpendingLimitsInterval) =
            {
                Amount = amount
                Categories = categories
                Interval = interval
            }

    type IssuingCardholders'UpdateSpendingControls = {
        AllowedCategories: IssuingCardholders'UpdateSpendingControlsAllowedCategories list option
        BlockedCategories: IssuingCardholders'UpdateSpendingControlsBlockedCategories list option
        SpendingLimits: IssuingCardholders'UpdateSpendingControlsSpendingLimits list option
        SpendingLimitsCurrency: string option
    }
    with
        static member Create(?allowedCategories: IssuingCardholders'UpdateSpendingControlsAllowedCategories list, ?blockedCategories: IssuingCardholders'UpdateSpendingControlsBlockedCategories list, ?spendingLimits: IssuingCardholders'UpdateSpendingControlsSpendingLimits list, ?spendingLimitsCurrency: string) =
            {
                AllowedCategories = allowedCategories
                BlockedCategories = blockedCategories
                SpendingLimits = spendingLimits
                SpendingLimitsCurrency = spendingLimitsCurrency
            }

    type IssuingCardholders'UpdateStatus =
        | Active
        | Inactive

    type IssuingCardholders'UpdateOptions = {
        Billing: IssuingCardholders'UpdateBilling option
        Company: IssuingCardholders'UpdateCompany option
        Email: string option
        Expand: string list option
        Individual: IssuingCardholders'UpdateIndividual option
        Metadata: Map<string, string> option
        PhoneNumber: string option
        SpendingControls: IssuingCardholders'UpdateSpendingControls option
        Status: IssuingCardholders'UpdateStatus option
    }
    with
        static member Create(?billing: IssuingCardholders'UpdateBilling, ?company: IssuingCardholders'UpdateCompany, ?email: string, ?expand: string list, ?individual: IssuingCardholders'UpdateIndividual, ?metadata: Map<string, string>, ?phoneNumber: string, ?spendingControls: IssuingCardholders'UpdateSpendingControls, ?status: IssuingCardholders'UpdateStatus) =
            {
                Billing = billing
                Company = company
                Email = email
                Expand = expand
                Individual = individual
                Metadata = metadata
                PhoneNumber = phoneNumber
                SpendingControls = spendingControls
                Status = status
            }

    type IssuingCards'CreateShippingAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type IssuingCards'CreateShippingService =
        | Express
        | Priority
        | Standard

    type IssuingCards'CreateShippingType =
        | Bulk
        | Individual

    type IssuingCards'CreateShipping = {
        Address: IssuingCards'CreateShippingAddress option
        Name: string option
        Service: IssuingCards'CreateShippingService option
        Type: IssuingCards'CreateShippingType option
    }
    with
        static member Create(?address: IssuingCards'CreateShippingAddress, ?name: string, ?service: IssuingCards'CreateShippingService, ?``type``: IssuingCards'CreateShippingType) =
            {
                Address = address
                Name = name
                Service = service
                Type = ``type``
            }

    type IssuingCards'CreateSpendingControlsAllowedCategories =
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
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
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

    type IssuingCards'CreateSpendingControlsBlockedCategories =
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
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
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

    type IssuingCards'CreateSpendingControlsSpendingLimitsCategories =
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
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
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

    type IssuingCards'CreateSpendingControlsSpendingLimitsInterval =
        | AllTime
        | Daily
        | Monthly
        | PerAuthorization
        | Weekly
        | Yearly

    type IssuingCards'CreateSpendingControlsSpendingLimits = {
        Amount: int option
        Categories: IssuingCards'CreateSpendingControlsSpendingLimitsCategories list option
        Interval: IssuingCards'CreateSpendingControlsSpendingLimitsInterval option
    }
    with
        static member Create(?amount: int, ?categories: IssuingCards'CreateSpendingControlsSpendingLimitsCategories list, ?interval: IssuingCards'CreateSpendingControlsSpendingLimitsInterval) =
            {
                Amount = amount
                Categories = categories
                Interval = interval
            }

    type IssuingCards'CreateSpendingControls = {
        AllowedCategories: IssuingCards'CreateSpendingControlsAllowedCategories list option
        BlockedCategories: IssuingCards'CreateSpendingControlsBlockedCategories list option
        SpendingLimits: IssuingCards'CreateSpendingControlsSpendingLimits list option
    }
    with
        static member Create(?allowedCategories: IssuingCards'CreateSpendingControlsAllowedCategories list, ?blockedCategories: IssuingCards'CreateSpendingControlsBlockedCategories list, ?spendingLimits: IssuingCards'CreateSpendingControlsSpendingLimits list) =
            {
                AllowedCategories = allowedCategories
                BlockedCategories = blockedCategories
                SpendingLimits = spendingLimits
            }

    type IssuingCards'CreateReplacementReason =
        | Damaged
        | Expired
        | Lost
        | Stolen

    type IssuingCards'CreateStatus =
        | Active
        | Inactive

    type IssuingCards'CreateType =
        | Physical
        | Virtual

    type IssuingCards'CreateOptions = {
        Cardholder: string option
        Currency: string
        Expand: string list option
        Metadata: Map<string, string> option
        ReplacementFor: string option
        ReplacementReason: IssuingCards'CreateReplacementReason option
        Shipping: IssuingCards'CreateShipping option
        SpendingControls: IssuingCards'CreateSpendingControls option
        Status: IssuingCards'CreateStatus option
        Type: IssuingCards'CreateType
    }
    with
        static member Create(currency: string, ``type``: IssuingCards'CreateType, ?cardholder: string, ?expand: string list, ?metadata: Map<string, string>, ?replacementFor: string, ?replacementReason: IssuingCards'CreateReplacementReason, ?shipping: IssuingCards'CreateShipping, ?spendingControls: IssuingCards'CreateSpendingControls, ?status: IssuingCards'CreateStatus) =
            {
                Cardholder = cardholder
                Currency = currency
                Expand = expand
                Metadata = metadata
                ReplacementFor = replacementFor
                ReplacementReason = replacementReason
                Shipping = shipping
                SpendingControls = spendingControls
                Status = status
                Type = ``type``
            }

    type IssuingCards'UpdateSpendingControlsAllowedCategories =
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
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
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

    type IssuingCards'UpdateSpendingControlsBlockedCategories =
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
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
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

    type IssuingCards'UpdateSpendingControlsSpendingLimitsCategories =
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
        | ElectricalPartsAndEquipment
        | ElectricalServices
        | ElectronicsRepairShops
        | ElectronicsStores
        | ElementarySecondarySchools
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

    type IssuingCards'UpdateSpendingControlsSpendingLimitsInterval =
        | AllTime
        | Daily
        | Monthly
        | PerAuthorization
        | Weekly
        | Yearly

    type IssuingCards'UpdateSpendingControlsSpendingLimits = {
        Amount: int option
        Categories: IssuingCards'UpdateSpendingControlsSpendingLimitsCategories list option
        Interval: IssuingCards'UpdateSpendingControlsSpendingLimitsInterval option
    }
    with
        static member Create(?amount: int, ?categories: IssuingCards'UpdateSpendingControlsSpendingLimitsCategories list, ?interval: IssuingCards'UpdateSpendingControlsSpendingLimitsInterval) =
            {
                Amount = amount
                Categories = categories
                Interval = interval
            }

    type IssuingCards'UpdateSpendingControls = {
        AllowedCategories: IssuingCards'UpdateSpendingControlsAllowedCategories list option
        BlockedCategories: IssuingCards'UpdateSpendingControlsBlockedCategories list option
        SpendingLimits: IssuingCards'UpdateSpendingControlsSpendingLimits list option
    }
    with
        static member Create(?allowedCategories: IssuingCards'UpdateSpendingControlsAllowedCategories list, ?blockedCategories: IssuingCards'UpdateSpendingControlsBlockedCategories list, ?spendingLimits: IssuingCards'UpdateSpendingControlsSpendingLimits list) =
            {
                AllowedCategories = allowedCategories
                BlockedCategories = blockedCategories
                SpendingLimits = spendingLimits
            }

    type IssuingCards'UpdateCancellationReason =
        | Lost
        | Stolen

    type IssuingCards'UpdateStatus =
        | Active
        | Canceled
        | Inactive

    type IssuingCards'UpdateOptions = {
        CancellationReason: IssuingCards'UpdateCancellationReason option
        Expand: string list option
        Metadata: Map<string, string> option
        SpendingControls: IssuingCards'UpdateSpendingControls option
        Status: IssuingCards'UpdateStatus option
    }
    with
        static member Create(?cancellationReason: IssuingCards'UpdateCancellationReason, ?expand: string list, ?metadata: Map<string, string>, ?spendingControls: IssuingCards'UpdateSpendingControls, ?status: IssuingCards'UpdateStatus) =
            {
                CancellationReason = cancellationReason
                Expand = expand
                Metadata = metadata
                SpendingControls = spendingControls
                Status = status
            }

    type IssuingDisputes'CreateEvidenceCanceledCanceledProductType =
        | Merchandise
        | Service

    type IssuingDisputes'CreateEvidenceCanceledCanceledReturnStatus =
        | MerchantRejected
        | Successful

    type IssuingDisputes'CreateEvidenceCanceledCanceled = {
        AdditionalDocumentation: Choice<string,string> option
        CanceledAt: Choice<DateTime,string> option
        CancellationPolicyProvided: Choice<bool,string> option
        CancellationReason: string option
        ExpectedAt: Choice<DateTime,string> option
        Explanation: string option
        ProductDescription: string option
        ProductType: IssuingDisputes'CreateEvidenceCanceledCanceledProductType option
        ReturnStatus: IssuingDisputes'CreateEvidenceCanceledCanceledReturnStatus option
        ReturnedAt: Choice<DateTime,string> option
    }
    with
        static member Create(?additionalDocumentation: Choice<string,string>, ?canceledAt: Choice<DateTime,string>, ?cancellationPolicyProvided: Choice<bool,string>, ?cancellationReason: string, ?expectedAt: Choice<DateTime,string>, ?explanation: string, ?productDescription: string, ?productType: IssuingDisputes'CreateEvidenceCanceledCanceledProductType, ?returnStatus: IssuingDisputes'CreateEvidenceCanceledCanceledReturnStatus, ?returnedAt: Choice<DateTime,string>) =
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

    type IssuingDisputes'CreateEvidenceDuplicateDuplicate = {
        AdditionalDocumentation: Choice<string,string> option
        CardStatement: Choice<string,string> option
        CashReceipt: Choice<string,string> option
        CheckImage: Choice<string,string> option
        Explanation: string option
        OriginalTransaction: string option
    }
    with
        static member Create(?additionalDocumentation: Choice<string,string>, ?cardStatement: Choice<string,string>, ?cashReceipt: Choice<string,string>, ?checkImage: Choice<string,string>, ?explanation: string, ?originalTransaction: string) =
            {
                AdditionalDocumentation = additionalDocumentation
                CardStatement = cardStatement
                CashReceipt = cashReceipt
                CheckImage = checkImage
                Explanation = explanation
                OriginalTransaction = originalTransaction
            }

    type IssuingDisputes'CreateEvidenceFraudulentFraudulent = {
        AdditionalDocumentation: Choice<string,string> option
        Explanation: string option
    }
    with
        static member Create(?additionalDocumentation: Choice<string,string>, ?explanation: string) =
            {
                AdditionalDocumentation = additionalDocumentation
                Explanation = explanation
            }

    type IssuingDisputes'CreateEvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus =
        | MerchantRejected
        | Successful

    type IssuingDisputes'CreateEvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed = {
        AdditionalDocumentation: Choice<string,string> option
        Explanation: string option
        ReceivedAt: Choice<DateTime,string> option
        ReturnDescription: string option
        ReturnStatus: IssuingDisputes'CreateEvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus option
        ReturnedAt: Choice<DateTime,string> option
    }
    with
        static member Create(?additionalDocumentation: Choice<string,string>, ?explanation: string, ?receivedAt: Choice<DateTime,string>, ?returnDescription: string, ?returnStatus: IssuingDisputes'CreateEvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus, ?returnedAt: Choice<DateTime,string>) =
            {
                AdditionalDocumentation = additionalDocumentation
                Explanation = explanation
                ReceivedAt = receivedAt
                ReturnDescription = returnDescription
                ReturnStatus = returnStatus
                ReturnedAt = returnedAt
            }

    type IssuingDisputes'CreateEvidenceNotReceivedNotReceivedProductType =
        | Merchandise
        | Service

    type IssuingDisputes'CreateEvidenceNotReceivedNotReceived = {
        AdditionalDocumentation: Choice<string,string> option
        ExpectedAt: Choice<DateTime,string> option
        Explanation: string option
        ProductDescription: string option
        ProductType: IssuingDisputes'CreateEvidenceNotReceivedNotReceivedProductType option
    }
    with
        static member Create(?additionalDocumentation: Choice<string,string>, ?expectedAt: Choice<DateTime,string>, ?explanation: string, ?productDescription: string, ?productType: IssuingDisputes'CreateEvidenceNotReceivedNotReceivedProductType) =
            {
                AdditionalDocumentation = additionalDocumentation
                ExpectedAt = expectedAt
                Explanation = explanation
                ProductDescription = productDescription
                ProductType = productType
            }

    type IssuingDisputes'CreateEvidenceOtherOtherProductType =
        | Merchandise
        | Service

    type IssuingDisputes'CreateEvidenceOtherOther = {
        AdditionalDocumentation: Choice<string,string> option
        Explanation: string option
        ProductDescription: string option
        ProductType: IssuingDisputes'CreateEvidenceOtherOtherProductType option
    }
    with
        static member Create(?additionalDocumentation: Choice<string,string>, ?explanation: string, ?productDescription: string, ?productType: IssuingDisputes'CreateEvidenceOtherOtherProductType) =
            {
                AdditionalDocumentation = additionalDocumentation
                Explanation = explanation
                ProductDescription = productDescription
                ProductType = productType
            }

    type IssuingDisputes'CreateEvidenceServiceNotAsDescribedServiceNotAsDescribed = {
        AdditionalDocumentation: Choice<string,string> option
        CanceledAt: Choice<DateTime,string> option
        CancellationReason: string option
        Explanation: string option
        ReceivedAt: Choice<DateTime,string> option
    }
    with
        static member Create(?additionalDocumentation: Choice<string,string>, ?canceledAt: Choice<DateTime,string>, ?cancellationReason: string, ?explanation: string, ?receivedAt: Choice<DateTime,string>) =
            {
                AdditionalDocumentation = additionalDocumentation
                CanceledAt = canceledAt
                CancellationReason = cancellationReason
                Explanation = explanation
                ReceivedAt = receivedAt
            }

    type IssuingDisputes'CreateEvidenceReason =
        | Canceled
        | Duplicate
        | Fraudulent
        | MerchandiseNotAsDescribed
        | NotReceived
        | Other
        | ServiceNotAsDescribed

    type IssuingDisputes'CreateEvidence = {
        Canceled: Choice<IssuingDisputes'CreateEvidenceCanceledCanceled,string> option
        Duplicate: Choice<IssuingDisputes'CreateEvidenceDuplicateDuplicate,string> option
        Fraudulent: Choice<IssuingDisputes'CreateEvidenceFraudulentFraudulent,string> option
        MerchandiseNotAsDescribed: Choice<IssuingDisputes'CreateEvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed,string> option
        NotReceived: Choice<IssuingDisputes'CreateEvidenceNotReceivedNotReceived,string> option
        Other: Choice<IssuingDisputes'CreateEvidenceOtherOther,string> option
        Reason: IssuingDisputes'CreateEvidenceReason option
        ServiceNotAsDescribed: Choice<IssuingDisputes'CreateEvidenceServiceNotAsDescribedServiceNotAsDescribed,string> option
    }
    with
        static member Create(?canceled: Choice<IssuingDisputes'CreateEvidenceCanceledCanceled,string>, ?duplicate: Choice<IssuingDisputes'CreateEvidenceDuplicateDuplicate,string>, ?fraudulent: Choice<IssuingDisputes'CreateEvidenceFraudulentFraudulent,string>, ?merchandiseNotAsDescribed: Choice<IssuingDisputes'CreateEvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed,string>, ?notReceived: Choice<IssuingDisputes'CreateEvidenceNotReceivedNotReceived,string>, ?other: Choice<IssuingDisputes'CreateEvidenceOtherOther,string>, ?reason: IssuingDisputes'CreateEvidenceReason, ?serviceNotAsDescribed: Choice<IssuingDisputes'CreateEvidenceServiceNotAsDescribedServiceNotAsDescribed,string>) =
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

    type IssuingDisputes'CreateOptions = {
        Evidence: IssuingDisputes'CreateEvidence option
        Expand: string list option
        Metadata: Map<string, string> option
        Transaction: string
    }
    with
        static member Create(transaction: string, ?evidence: IssuingDisputes'CreateEvidence, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Evidence = evidence
                Expand = expand
                Metadata = metadata
                Transaction = transaction
            }

    type IssuingDisputes'UpdateEvidenceCanceledCanceledProductType =
        | Merchandise
        | Service

    type IssuingDisputes'UpdateEvidenceCanceledCanceledReturnStatus =
        | MerchantRejected
        | Successful

    type IssuingDisputes'UpdateEvidenceCanceledCanceled = {
        AdditionalDocumentation: Choice<string,string> option
        CanceledAt: Choice<DateTime,string> option
        CancellationPolicyProvided: Choice<bool,string> option
        CancellationReason: string option
        ExpectedAt: Choice<DateTime,string> option
        Explanation: string option
        ProductDescription: string option
        ProductType: IssuingDisputes'UpdateEvidenceCanceledCanceledProductType option
        ReturnStatus: IssuingDisputes'UpdateEvidenceCanceledCanceledReturnStatus option
        ReturnedAt: Choice<DateTime,string> option
    }
    with
        static member Create(?additionalDocumentation: Choice<string,string>, ?canceledAt: Choice<DateTime,string>, ?cancellationPolicyProvided: Choice<bool,string>, ?cancellationReason: string, ?expectedAt: Choice<DateTime,string>, ?explanation: string, ?productDescription: string, ?productType: IssuingDisputes'UpdateEvidenceCanceledCanceledProductType, ?returnStatus: IssuingDisputes'UpdateEvidenceCanceledCanceledReturnStatus, ?returnedAt: Choice<DateTime,string>) =
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

    type IssuingDisputes'UpdateEvidenceDuplicateDuplicate = {
        AdditionalDocumentation: Choice<string,string> option
        CardStatement: Choice<string,string> option
        CashReceipt: Choice<string,string> option
        CheckImage: Choice<string,string> option
        Explanation: string option
        OriginalTransaction: string option
    }
    with
        static member Create(?additionalDocumentation: Choice<string,string>, ?cardStatement: Choice<string,string>, ?cashReceipt: Choice<string,string>, ?checkImage: Choice<string,string>, ?explanation: string, ?originalTransaction: string) =
            {
                AdditionalDocumentation = additionalDocumentation
                CardStatement = cardStatement
                CashReceipt = cashReceipt
                CheckImage = checkImage
                Explanation = explanation
                OriginalTransaction = originalTransaction
            }

    type IssuingDisputes'UpdateEvidenceFraudulentFraudulent = {
        AdditionalDocumentation: Choice<string,string> option
        Explanation: string option
    }
    with
        static member Create(?additionalDocumentation: Choice<string,string>, ?explanation: string) =
            {
                AdditionalDocumentation = additionalDocumentation
                Explanation = explanation
            }

    type IssuingDisputes'UpdateEvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus =
        | MerchantRejected
        | Successful

    type IssuingDisputes'UpdateEvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed = {
        AdditionalDocumentation: Choice<string,string> option
        Explanation: string option
        ReceivedAt: Choice<DateTime,string> option
        ReturnDescription: string option
        ReturnStatus: IssuingDisputes'UpdateEvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus option
        ReturnedAt: Choice<DateTime,string> option
    }
    with
        static member Create(?additionalDocumentation: Choice<string,string>, ?explanation: string, ?receivedAt: Choice<DateTime,string>, ?returnDescription: string, ?returnStatus: IssuingDisputes'UpdateEvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribedReturnStatus, ?returnedAt: Choice<DateTime,string>) =
            {
                AdditionalDocumentation = additionalDocumentation
                Explanation = explanation
                ReceivedAt = receivedAt
                ReturnDescription = returnDescription
                ReturnStatus = returnStatus
                ReturnedAt = returnedAt
            }

    type IssuingDisputes'UpdateEvidenceNotReceivedNotReceivedProductType =
        | Merchandise
        | Service

    type IssuingDisputes'UpdateEvidenceNotReceivedNotReceived = {
        AdditionalDocumentation: Choice<string,string> option
        ExpectedAt: Choice<DateTime,string> option
        Explanation: string option
        ProductDescription: string option
        ProductType: IssuingDisputes'UpdateEvidenceNotReceivedNotReceivedProductType option
    }
    with
        static member Create(?additionalDocumentation: Choice<string,string>, ?expectedAt: Choice<DateTime,string>, ?explanation: string, ?productDescription: string, ?productType: IssuingDisputes'UpdateEvidenceNotReceivedNotReceivedProductType) =
            {
                AdditionalDocumentation = additionalDocumentation
                ExpectedAt = expectedAt
                Explanation = explanation
                ProductDescription = productDescription
                ProductType = productType
            }

    type IssuingDisputes'UpdateEvidenceOtherOtherProductType =
        | Merchandise
        | Service

    type IssuingDisputes'UpdateEvidenceOtherOther = {
        AdditionalDocumentation: Choice<string,string> option
        Explanation: string option
        ProductDescription: string option
        ProductType: IssuingDisputes'UpdateEvidenceOtherOtherProductType option
    }
    with
        static member Create(?additionalDocumentation: Choice<string,string>, ?explanation: string, ?productDescription: string, ?productType: IssuingDisputes'UpdateEvidenceOtherOtherProductType) =
            {
                AdditionalDocumentation = additionalDocumentation
                Explanation = explanation
                ProductDescription = productDescription
                ProductType = productType
            }

    type IssuingDisputes'UpdateEvidenceServiceNotAsDescribedServiceNotAsDescribed = {
        AdditionalDocumentation: Choice<string,string> option
        CanceledAt: Choice<DateTime,string> option
        CancellationReason: string option
        Explanation: string option
        ReceivedAt: Choice<DateTime,string> option
    }
    with
        static member Create(?additionalDocumentation: Choice<string,string>, ?canceledAt: Choice<DateTime,string>, ?cancellationReason: string, ?explanation: string, ?receivedAt: Choice<DateTime,string>) =
            {
                AdditionalDocumentation = additionalDocumentation
                CanceledAt = canceledAt
                CancellationReason = cancellationReason
                Explanation = explanation
                ReceivedAt = receivedAt
            }

    type IssuingDisputes'UpdateEvidenceReason =
        | Canceled
        | Duplicate
        | Fraudulent
        | MerchandiseNotAsDescribed
        | NotReceived
        | Other
        | ServiceNotAsDescribed

    type IssuingDisputes'UpdateEvidence = {
        Canceled: Choice<IssuingDisputes'UpdateEvidenceCanceledCanceled,string> option
        Duplicate: Choice<IssuingDisputes'UpdateEvidenceDuplicateDuplicate,string> option
        Fraudulent: Choice<IssuingDisputes'UpdateEvidenceFraudulentFraudulent,string> option
        MerchandiseNotAsDescribed: Choice<IssuingDisputes'UpdateEvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed,string> option
        NotReceived: Choice<IssuingDisputes'UpdateEvidenceNotReceivedNotReceived,string> option
        Other: Choice<IssuingDisputes'UpdateEvidenceOtherOther,string> option
        Reason: IssuingDisputes'UpdateEvidenceReason option
        ServiceNotAsDescribed: Choice<IssuingDisputes'UpdateEvidenceServiceNotAsDescribedServiceNotAsDescribed,string> option
    }
    with
        static member Create(?canceled: Choice<IssuingDisputes'UpdateEvidenceCanceledCanceled,string>, ?duplicate: Choice<IssuingDisputes'UpdateEvidenceDuplicateDuplicate,string>, ?fraudulent: Choice<IssuingDisputes'UpdateEvidenceFraudulentFraudulent,string>, ?merchandiseNotAsDescribed: Choice<IssuingDisputes'UpdateEvidenceMerchandiseNotAsDescribedMerchandiseNotAsDescribed,string>, ?notReceived: Choice<IssuingDisputes'UpdateEvidenceNotReceivedNotReceived,string>, ?other: Choice<IssuingDisputes'UpdateEvidenceOtherOther,string>, ?reason: IssuingDisputes'UpdateEvidenceReason, ?serviceNotAsDescribed: Choice<IssuingDisputes'UpdateEvidenceServiceNotAsDescribedServiceNotAsDescribed,string>) =
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

    type IssuingDisputes'UpdateOptions = {
        Evidence: IssuingDisputes'UpdateEvidence option
        Expand: string list option
        Metadata: Map<string, string> option
    }
    with
        static member Create(?evidence: IssuingDisputes'UpdateEvidence, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Evidence = evidence
                Expand = expand
                Metadata = metadata
            }

    type IssuingDisputesSubmit'SubmitOptions = {
        Expand: string list option
        Metadata: Map<string, string> option
    }
    with
        static member Create(?expand: string list, ?metadata: Map<string, string>) =
            {
                Expand = expand
                Metadata = metadata
            }

    type IssuingTransactions'UpdateOptions = {
        Expand: string list option
        Metadata: Map<string, string> option
    }
    with
        static member Create(?expand: string list, ?metadata: Map<string, string>) =
            {
                Expand = expand
                Metadata = metadata
            }

    type Orders'CreateItemsType =
        | Discount
        | Shipping
        | Sku
        | Tax

    type Orders'CreateItems = {
        Amount: int option
        Currency: string option
        Description: string option
        Parent: string option
        Quantity: int option
        Type: Orders'CreateItemsType option
    }
    with
        static member Create(?amount: int, ?currency: string, ?description: string, ?parent: string, ?quantity: int, ?``type``: Orders'CreateItemsType) =
            {
                Amount = amount
                Currency = currency
                Description = description
                Parent = parent
                Quantity = quantity
                Type = ``type``
            }

    type Orders'CreateShippingAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Orders'CreateShipping = {
        Address: Orders'CreateShippingAddress option
        Name: string option
        Phone: string option
    }
    with
        static member Create(?address: Orders'CreateShippingAddress, ?name: string, ?phone: string) =
            {
                Address = address
                Name = name
                Phone = phone
            }

    type Orders'CreateOptions = {
        Coupon: string option
        Currency: string
        Customer: string option
        Email: string option
        Expand: string list option
        Items: Orders'CreateItems list option
        Metadata: Map<string, string> option
        Shipping: Orders'CreateShipping option
    }
    with
        static member Create(currency: string, ?coupon: string, ?customer: string, ?email: string, ?expand: string list, ?items: Orders'CreateItems list, ?metadata: Map<string, string>, ?shipping: Orders'CreateShipping) =
            {
                Coupon = coupon
                Currency = currency
                Customer = customer
                Email = email
                Expand = expand
                Items = items
                Metadata = metadata
                Shipping = shipping
            }

    type Orders'UpdateShipping = {
        Carrier: string option
        TrackingNumber: string option
    }
    with
        static member Create(?carrier: string, ?trackingNumber: string) =
            {
                Carrier = carrier
                TrackingNumber = trackingNumber
            }

    type Orders'UpdateStatus =
        | Canceled
        | Created
        | Fulfilled
        | Paid
        | Returned

    type Orders'UpdateOptions = {
        Coupon: string option
        Expand: string list option
        Metadata: Map<string, string> option
        SelectedShippingMethod: string option
        Shipping: Orders'UpdateShipping option
        Status: Orders'UpdateStatus option
    }
    with
        static member Create(?coupon: string, ?expand: string list, ?metadata: Map<string, string>, ?selectedShippingMethod: string, ?shipping: Orders'UpdateShipping, ?status: Orders'UpdateStatus) =
            {
                Coupon = coupon
                Expand = expand
                Metadata = metadata
                SelectedShippingMethod = selectedShippingMethod
                Shipping = shipping
                Status = status
            }

    type OrdersPay'PayOptions = {
        ApplicationFee: int option
        Customer: string option
        Email: string option
        Expand: string list option
        Metadata: Map<string, string> option
        Source: string option
    }
    with
        static member Create(?applicationFee: int, ?customer: string, ?email: string, ?expand: string list, ?metadata: Map<string, string>, ?source: string) =
            {
                ApplicationFee = applicationFee
                Customer = customer
                Email = email
                Expand = expand
                Metadata = metadata
                Source = source
            }

    type OrdersReturns'ReturnOrderItemsType =
        | Discount
        | Shipping
        | Sku
        | Tax

    type OrdersReturns'ReturnOrderItems = {
        Amount: int option
        Description: string option
        Parent: string option
        Quantity: int option
        Type: OrdersReturns'ReturnOrderItemsType option
    }
    with
        static member Create(?amount: int, ?description: string, ?parent: string, ?quantity: int, ?``type``: OrdersReturns'ReturnOrderItemsType) =
            {
                Amount = amount
                Description = description
                Parent = parent
                Quantity = quantity
                Type = ``type``
            }

    type OrdersReturns'ReturnOrderOptions = {
        Expand: string list option
        Items: Choice<OrdersReturns'ReturnOrderItems list,string> option
    }
    with
        static member Create(?expand: string list, ?items: Choice<OrdersReturns'ReturnOrderItems list,string>) =
            {
                Expand = expand
                Items = items
            }

    type PaymentIntents'CreateMandateDataCustomerAcceptanceOnline = {
        IpAddress: string option
        UserAgent: string option
    }
    with
        static member Create(?ipAddress: string, ?userAgent: string) =
            {
                IpAddress = ipAddress
                UserAgent = userAgent
            }

    type PaymentIntents'CreateMandateDataCustomerAcceptanceType =
        | Offline
        | Online

    type PaymentIntents'CreateMandateDataCustomerAcceptance = {
        AcceptedAt: DateTime option
        Offline: string option
        Online: PaymentIntents'CreateMandateDataCustomerAcceptanceOnline option
        Type: PaymentIntents'CreateMandateDataCustomerAcceptanceType option
    }
    with
        static member Create(?acceptedAt: DateTime, ?offline: string, ?online: PaymentIntents'CreateMandateDataCustomerAcceptanceOnline, ?``type``: PaymentIntents'CreateMandateDataCustomerAcceptanceType) =
            {
                AcceptedAt = acceptedAt
                Offline = offline
                Online = online
                Type = ``type``
            }

    type PaymentIntents'CreateMandateData = {
        CustomerAcceptance: PaymentIntents'CreateMandateDataCustomerAcceptance option
    }
    with
        static member Create(?customerAcceptance: PaymentIntents'CreateMandateDataCustomerAcceptance) =
            {
                CustomerAcceptance = customerAcceptance
            }

    type PaymentIntents'CreateOffSession =
        | OneOff
        | Recurring

    type PaymentIntents'CreatePaymentMethodDataAuBecsDebit = {
        AccountNumber: string option
        BsbNumber: string option
    }
    with
        static member Create(?accountNumber: string, ?bsbNumber: string) =
            {
                AccountNumber = accountNumber
                BsbNumber = bsbNumber
            }

    type PaymentIntents'CreatePaymentMethodDataBacsDebit = {
        AccountNumber: string option
        SortCode: string option
    }
    with
        static member Create(?accountNumber: string, ?sortCode: string) =
            {
                AccountNumber = accountNumber
                SortCode = sortCode
            }

    type PaymentIntents'CreatePaymentMethodDataBillingDetailsAddressBillingDetailsAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type PaymentIntents'CreatePaymentMethodDataBillingDetails = {
        Address: Choice<PaymentIntents'CreatePaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string> option
        Email: string option
        Name: string option
        Phone: string option
    }
    with
        static member Create(?address: Choice<PaymentIntents'CreatePaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string>, ?email: string, ?name: string, ?phone: string) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
            }

    type PaymentIntents'CreatePaymentMethodDataFpxAccountHolderType =
        | Company
        | Individual

    type PaymentIntents'CreatePaymentMethodDataFpxBank =
        | AffinBank
        | AllianceBank
        | Ambank
        | BankIslam
        | BankMuamalat
        | BankRakyat
        | Bsn
        | Cimb
        | DeutscheBank
        | HongLeongBank
        | Hsbc
        | Kfh
        | Maybank2e
        | Maybank2u
        | Ocbc
        | PbEnterprise
        | PublicBank
        | Rhb
        | StandardChartered
        | Uob

    type PaymentIntents'CreatePaymentMethodDataFpx = {
        AccountHolderType: PaymentIntents'CreatePaymentMethodDataFpxAccountHolderType option
        Bank: PaymentIntents'CreatePaymentMethodDataFpxBank option
    }
    with
        static member Create(?accountHolderType: PaymentIntents'CreatePaymentMethodDataFpxAccountHolderType, ?bank: PaymentIntents'CreatePaymentMethodDataFpxBank) =
            {
                AccountHolderType = accountHolderType
                Bank = bank
            }

    type PaymentIntents'CreatePaymentMethodDataIdealBank =
        | AbnAmro
        | AsnBank
        | Bunq
        | Handelsbanken
        | Ing
        | Knab
        | Moneyou
        | Rabobank
        | Regiobank
        | SnsBank
        | TriodosBank
        | VanLanschot

    type PaymentIntents'CreatePaymentMethodDataIdeal = {
        Bank: PaymentIntents'CreatePaymentMethodDataIdealBank option
    }
    with
        static member Create(?bank: PaymentIntents'CreatePaymentMethodDataIdealBank) =
            {
                Bank = bank
            }

    type PaymentIntents'CreatePaymentMethodDataP24Bank =
        | AliorBank
        | BankMillennium
        | BankNowyBfgSa
        | BankPekaoSa
        | BankiSpbdzielcze
        | Blik
        | BnpParibas
        | Boz
        | CitiHandlowy
        | CreditAgricole
        | Envelobank
        | EtransferPocztowy24
        | GetinBank
        | Ideabank
        | Ing
        | Inteligo
        | MbankMtransfer
        | NestPrzelew
        | NoblePay
        | PbacZIpko
        | PlusBank
        | SantanderPrzelew24
        | TmobileUsbugiBankowe
        | ToyotaBank
        | VolkswagenBank

    type PaymentIntents'CreatePaymentMethodDataP24 = {
        Bank: PaymentIntents'CreatePaymentMethodDataP24Bank option
    }
    with
        static member Create(?bank: PaymentIntents'CreatePaymentMethodDataP24Bank) =
            {
                Bank = bank
            }

    type PaymentIntents'CreatePaymentMethodDataSepaDebit = {
        Iban: string option
    }
    with
        static member Create(?iban: string) =
            {
                Iban = iban
            }

    type PaymentIntents'CreatePaymentMethodDataSofortCountry =
        | [<JsonUnionCase("AT")>] AT
        | [<JsonUnionCase("BE")>] BE
        | [<JsonUnionCase("DE")>] DE
        | [<JsonUnionCase("ES")>] ES
        | [<JsonUnionCase("IT")>] IT
        | [<JsonUnionCase("NL")>] NL

    type PaymentIntents'CreatePaymentMethodDataSofort = {
        Country: PaymentIntents'CreatePaymentMethodDataSofortCountry option
    }
    with
        static member Create(?country: PaymentIntents'CreatePaymentMethodDataSofortCountry) =
            {
                Country = country
            }

    type PaymentIntents'CreatePaymentMethodDataType =
        | Alipay
        | AuBecsDebit
        | BacsDebit
        | Bancontact
        | Eps
        | Fpx
        | Giropay
        | Grabpay
        | Ideal
        | Oxxo
        | P24
        | SepaDebit
        | Sofort

    type PaymentIntents'CreatePaymentMethodData = {
        Alipay: string option
        AuBecsDebit: PaymentIntents'CreatePaymentMethodDataAuBecsDebit option
        BacsDebit: PaymentIntents'CreatePaymentMethodDataBacsDebit option
        Bancontact: string option
        BillingDetails: PaymentIntents'CreatePaymentMethodDataBillingDetails option
        Eps: string option
        Fpx: PaymentIntents'CreatePaymentMethodDataFpx option
        Giropay: string option
        Grabpay: string option
        Ideal: PaymentIntents'CreatePaymentMethodDataIdeal option
        InteracPresent: string option
        Metadata: Map<string, string> option
        Oxxo: string option
        P24: PaymentIntents'CreatePaymentMethodDataP24 option
        SepaDebit: PaymentIntents'CreatePaymentMethodDataSepaDebit option
        Sofort: PaymentIntents'CreatePaymentMethodDataSofort option
        Type: PaymentIntents'CreatePaymentMethodDataType option
    }
    with
        static member Create(?alipay: string, ?sepaDebit: PaymentIntents'CreatePaymentMethodDataSepaDebit, ?p24: PaymentIntents'CreatePaymentMethodDataP24, ?oxxo: string, ?metadata: Map<string, string>, ?interacPresent: string, ?ideal: PaymentIntents'CreatePaymentMethodDataIdeal, ?sofort: PaymentIntents'CreatePaymentMethodDataSofort, ?grabpay: string, ?fpx: PaymentIntents'CreatePaymentMethodDataFpx, ?eps: string, ?billingDetails: PaymentIntents'CreatePaymentMethodDataBillingDetails, ?bancontact: string, ?bacsDebit: PaymentIntents'CreatePaymentMethodDataBacsDebit, ?auBecsDebit: PaymentIntents'CreatePaymentMethodDataAuBecsDebit, ?giropay: string, ?``type``: PaymentIntents'CreatePaymentMethodDataType) =
            {
                Alipay = alipay
                AuBecsDebit = auBecsDebit
                BacsDebit = bacsDebit
                Bancontact = bancontact
                BillingDetails = billingDetails
                Eps = eps
                Fpx = fpx
                Giropay = giropay
                Grabpay = grabpay
                Ideal = ideal
                InteracPresent = interacPresent
                Metadata = metadata
                Oxxo = oxxo
                P24 = p24
                SepaDebit = sepaDebit
                Sofort = sofort
                Type = ``type``
            }

    type PaymentIntents'CreatePaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage =
        | De
        | En
        | Fr
        | Nl

    type PaymentIntents'CreatePaymentMethodOptionsBancontactPaymentMethodOptions = {
        PreferredLanguage: PaymentIntents'CreatePaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage option
    }
    with
        static member Create(?preferredLanguage: PaymentIntents'CreatePaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage) =
            {
                PreferredLanguage = preferredLanguage
            }

    type PaymentIntents'CreatePaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval =
        | Month

    type PaymentIntents'CreatePaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType =
        | FixedCount

    type PaymentIntents'CreatePaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan = {
        Count: int option
        Interval: PaymentIntents'CreatePaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval option
        Type: PaymentIntents'CreatePaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType option
    }
    with
        static member Create(?count: int, ?interval: PaymentIntents'CreatePaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval, ?``type``: PaymentIntents'CreatePaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType) =
            {
                Count = count
                Interval = interval
                Type = ``type``
            }

    type PaymentIntents'CreatePaymentMethodOptionsCardPaymentIntentInstallments = {
        Enabled: bool option
        Plan: Choice<PaymentIntents'CreatePaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan,string> option
    }
    with
        static member Create(?enabled: bool, ?plan: Choice<PaymentIntents'CreatePaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan,string>) =
            {
                Enabled = enabled
                Plan = plan
            }

    type PaymentIntents'CreatePaymentMethodOptionsCardPaymentIntentNetwork =
        | Amex
        | CartesBancaires
        | Diners
        | Discover
        | Interac
        | Jcb
        | Mastercard
        | Unionpay
        | Unknown
        | Visa

    type PaymentIntents'CreatePaymentMethodOptionsCardPaymentIntentRequestThreeDSecure =
        | Any
        | Automatic

    type PaymentIntents'CreatePaymentMethodOptionsCardPaymentIntent = {
        CvcToken: string option
        Installments: PaymentIntents'CreatePaymentMethodOptionsCardPaymentIntentInstallments option
        Moto: bool option
        Network: PaymentIntents'CreatePaymentMethodOptionsCardPaymentIntentNetwork option
        RequestThreeDSecure: PaymentIntents'CreatePaymentMethodOptionsCardPaymentIntentRequestThreeDSecure option
    }
    with
        static member Create(?cvcToken: string, ?installments: PaymentIntents'CreatePaymentMethodOptionsCardPaymentIntentInstallments, ?moto: bool, ?network: PaymentIntents'CreatePaymentMethodOptionsCardPaymentIntentNetwork, ?requestThreeDSecure: PaymentIntents'CreatePaymentMethodOptionsCardPaymentIntentRequestThreeDSecure) =
            {
                CvcToken = cvcToken
                Installments = installments
                Moto = moto
                Network = network
                RequestThreeDSecure = requestThreeDSecure
            }

    type PaymentIntents'CreatePaymentMethodOptionsOxxoPaymentMethodOptions = {
        ExpiresAfterDays: int option
    }
    with
        static member Create(?expiresAfterDays: int) =
            {
                ExpiresAfterDays = expiresAfterDays
            }

    type PaymentIntents'CreatePaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions = {
        MandateOptions: string option
    }
    with
        static member Create(?mandateOptions: string) =
            {
                MandateOptions = mandateOptions
            }

    type PaymentIntents'CreatePaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage =
        | De
        | En
        | Es
        | Fr
        | It
        | Nl
        | Pl

    type PaymentIntents'CreatePaymentMethodOptionsSofortPaymentMethodOptions = {
        PreferredLanguage: PaymentIntents'CreatePaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage option
    }
    with
        static member Create(?preferredLanguage: PaymentIntents'CreatePaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage) =
            {
                PreferredLanguage = preferredLanguage
            }

    type PaymentIntents'CreatePaymentMethodOptions = {
        Alipay: Choice<string,string> option
        Bancontact: Choice<PaymentIntents'CreatePaymentMethodOptionsBancontactPaymentMethodOptions,string> option
        Card: Choice<PaymentIntents'CreatePaymentMethodOptionsCardPaymentIntent,string> option
        Oxxo: Choice<PaymentIntents'CreatePaymentMethodOptionsOxxoPaymentMethodOptions,string> option
        P24: Choice<string,string> option
        SepaDebit: Choice<PaymentIntents'CreatePaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions,string> option
        Sofort: Choice<PaymentIntents'CreatePaymentMethodOptionsSofortPaymentMethodOptions,string> option
    }
    with
        static member Create(?alipay: Choice<string,string>, ?bancontact: Choice<PaymentIntents'CreatePaymentMethodOptionsBancontactPaymentMethodOptions,string>, ?card: Choice<PaymentIntents'CreatePaymentMethodOptionsCardPaymentIntent,string>, ?oxxo: Choice<PaymentIntents'CreatePaymentMethodOptionsOxxoPaymentMethodOptions,string>, ?p24: Choice<string,string>, ?sepaDebit: Choice<PaymentIntents'CreatePaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions,string>, ?sofort: Choice<PaymentIntents'CreatePaymentMethodOptionsSofortPaymentMethodOptions,string>) =
            {
                Alipay = alipay
                Bancontact = bancontact
                Card = card
                Oxxo = oxxo
                P24 = p24
                SepaDebit = sepaDebit
                Sofort = sofort
            }

    type PaymentIntents'CreateShippingAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type PaymentIntents'CreateShipping = {
        Address: PaymentIntents'CreateShippingAddress option
        Carrier: string option
        Name: string option
        Phone: string option
        TrackingNumber: string option
    }
    with
        static member Create(?address: PaymentIntents'CreateShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
            {
                Address = address
                Carrier = carrier
                Name = name
                Phone = phone
                TrackingNumber = trackingNumber
            }

    type PaymentIntents'CreateTransferData = {
        Amount: int option
        Destination: string option
    }
    with
        static member Create(?amount: int, ?destination: string) =
            {
                Amount = amount
                Destination = destination
            }

    type PaymentIntents'CreateCaptureMethod =
        | Automatic
        | Manual

    type PaymentIntents'CreateConfirmationMethod =
        | Automatic
        | Manual

    type PaymentIntents'CreateSetupFutureUsage =
        | OffSession
        | OnSession

    type PaymentIntents'CreateOptions = {
        Amount: int
        ApplicationFeeAmount: int option
        CaptureMethod: PaymentIntents'CreateCaptureMethod option
        Confirm: bool option
        ConfirmationMethod: PaymentIntents'CreateConfirmationMethod option
        Currency: string
        Customer: string option
        Description: string option
        ErrorOnRequiresAction: bool option
        Expand: string list option
        Mandate: string option
        MandateData: PaymentIntents'CreateMandateData option
        Metadata: Map<string, string> option
        OffSession: Choice<bool,PaymentIntents'CreateOffSession> option
        OnBehalfOf: string option
        PaymentMethod: string option
        PaymentMethodData: PaymentIntents'CreatePaymentMethodData option
        PaymentMethodOptions: PaymentIntents'CreatePaymentMethodOptions option
        PaymentMethodTypes: string list option
        ReceiptEmail: string option
        ReturnUrl: string option
        SetupFutureUsage: PaymentIntents'CreateSetupFutureUsage option
        Shipping: PaymentIntents'CreateShipping option
        StatementDescriptor: string option
        StatementDescriptorSuffix: string option
        TransferData: PaymentIntents'CreateTransferData option
        TransferGroup: string option
        UseStripeSdk: bool option
    }
    with
        static member Create(amount: int, currency: string, ?transferData: PaymentIntents'CreateTransferData, ?statementDescriptorSuffix: string, ?statementDescriptor: string, ?shipping: PaymentIntents'CreateShipping, ?setupFutureUsage: PaymentIntents'CreateSetupFutureUsage, ?returnUrl: string, ?receiptEmail: string, ?paymentMethodTypes: string list, ?paymentMethodOptions: PaymentIntents'CreatePaymentMethodOptions, ?paymentMethodData: PaymentIntents'CreatePaymentMethodData, ?paymentMethod: string, ?onBehalfOf: string, ?offSession: Choice<bool,PaymentIntents'CreateOffSession>, ?metadata: Map<string, string>, ?mandateData: PaymentIntents'CreateMandateData, ?mandate: string, ?expand: string list, ?errorOnRequiresAction: bool, ?description: string, ?customer: string, ?confirmationMethod: PaymentIntents'CreateConfirmationMethod, ?confirm: bool, ?captureMethod: PaymentIntents'CreateCaptureMethod, ?applicationFeeAmount: int, ?transferGroup: string, ?useStripeSdk: bool) =
            {
                Amount = amount
                ApplicationFeeAmount = applicationFeeAmount
                CaptureMethod = captureMethod
                Confirm = confirm
                ConfirmationMethod = confirmationMethod
                Currency = currency
                Customer = customer
                Description = description
                ErrorOnRequiresAction = errorOnRequiresAction
                Expand = expand
                Mandate = mandate
                MandateData = mandateData
                Metadata = metadata
                OffSession = offSession
                OnBehalfOf = onBehalfOf
                PaymentMethod = paymentMethod
                PaymentMethodData = paymentMethodData
                PaymentMethodOptions = paymentMethodOptions
                PaymentMethodTypes = paymentMethodTypes
                ReceiptEmail = receiptEmail
                ReturnUrl = returnUrl
                SetupFutureUsage = setupFutureUsage
                Shipping = shipping
                StatementDescriptor = statementDescriptor
                StatementDescriptorSuffix = statementDescriptorSuffix
                TransferData = transferData
                TransferGroup = transferGroup
                UseStripeSdk = useStripeSdk
            }

    type PaymentIntents'UpdatePaymentMethodDataAuBecsDebit = {
        AccountNumber: string option
        BsbNumber: string option
    }
    with
        static member Create(?accountNumber: string, ?bsbNumber: string) =
            {
                AccountNumber = accountNumber
                BsbNumber = bsbNumber
            }

    type PaymentIntents'UpdatePaymentMethodDataBacsDebit = {
        AccountNumber: string option
        SortCode: string option
    }
    with
        static member Create(?accountNumber: string, ?sortCode: string) =
            {
                AccountNumber = accountNumber
                SortCode = sortCode
            }

    type PaymentIntents'UpdatePaymentMethodDataBillingDetailsAddressBillingDetailsAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type PaymentIntents'UpdatePaymentMethodDataBillingDetails = {
        Address: Choice<PaymentIntents'UpdatePaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string> option
        Email: string option
        Name: string option
        Phone: string option
    }
    with
        static member Create(?address: Choice<PaymentIntents'UpdatePaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string>, ?email: string, ?name: string, ?phone: string) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
            }

    type PaymentIntents'UpdatePaymentMethodDataFpxAccountHolderType =
        | Company
        | Individual

    type PaymentIntents'UpdatePaymentMethodDataFpxBank =
        | AffinBank
        | AllianceBank
        | Ambank
        | BankIslam
        | BankMuamalat
        | BankRakyat
        | Bsn
        | Cimb
        | DeutscheBank
        | HongLeongBank
        | Hsbc
        | Kfh
        | Maybank2e
        | Maybank2u
        | Ocbc
        | PbEnterprise
        | PublicBank
        | Rhb
        | StandardChartered
        | Uob

    type PaymentIntents'UpdatePaymentMethodDataFpx = {
        AccountHolderType: PaymentIntents'UpdatePaymentMethodDataFpxAccountHolderType option
        Bank: PaymentIntents'UpdatePaymentMethodDataFpxBank option
    }
    with
        static member Create(?accountHolderType: PaymentIntents'UpdatePaymentMethodDataFpxAccountHolderType, ?bank: PaymentIntents'UpdatePaymentMethodDataFpxBank) =
            {
                AccountHolderType = accountHolderType
                Bank = bank
            }

    type PaymentIntents'UpdatePaymentMethodDataIdealBank =
        | AbnAmro
        | AsnBank
        | Bunq
        | Handelsbanken
        | Ing
        | Knab
        | Moneyou
        | Rabobank
        | Regiobank
        | SnsBank
        | TriodosBank
        | VanLanschot

    type PaymentIntents'UpdatePaymentMethodDataIdeal = {
        Bank: PaymentIntents'UpdatePaymentMethodDataIdealBank option
    }
    with
        static member Create(?bank: PaymentIntents'UpdatePaymentMethodDataIdealBank) =
            {
                Bank = bank
            }

    type PaymentIntents'UpdatePaymentMethodDataP24Bank =
        | AliorBank
        | BankMillennium
        | BankNowyBfgSa
        | BankPekaoSa
        | BankiSpbdzielcze
        | Blik
        | BnpParibas
        | Boz
        | CitiHandlowy
        | CreditAgricole
        | Envelobank
        | EtransferPocztowy24
        | GetinBank
        | Ideabank
        | Ing
        | Inteligo
        | MbankMtransfer
        | NestPrzelew
        | NoblePay
        | PbacZIpko
        | PlusBank
        | SantanderPrzelew24
        | TmobileUsbugiBankowe
        | ToyotaBank
        | VolkswagenBank

    type PaymentIntents'UpdatePaymentMethodDataP24 = {
        Bank: PaymentIntents'UpdatePaymentMethodDataP24Bank option
    }
    with
        static member Create(?bank: PaymentIntents'UpdatePaymentMethodDataP24Bank) =
            {
                Bank = bank
            }

    type PaymentIntents'UpdatePaymentMethodDataSepaDebit = {
        Iban: string option
    }
    with
        static member Create(?iban: string) =
            {
                Iban = iban
            }

    type PaymentIntents'UpdatePaymentMethodDataSofortCountry =
        | [<JsonUnionCase("AT")>] AT
        | [<JsonUnionCase("BE")>] BE
        | [<JsonUnionCase("DE")>] DE
        | [<JsonUnionCase("ES")>] ES
        | [<JsonUnionCase("IT")>] IT
        | [<JsonUnionCase("NL")>] NL

    type PaymentIntents'UpdatePaymentMethodDataSofort = {
        Country: PaymentIntents'UpdatePaymentMethodDataSofortCountry option
    }
    with
        static member Create(?country: PaymentIntents'UpdatePaymentMethodDataSofortCountry) =
            {
                Country = country
            }

    type PaymentIntents'UpdatePaymentMethodDataType =
        | Alipay
        | AuBecsDebit
        | BacsDebit
        | Bancontact
        | Eps
        | Fpx
        | Giropay
        | Grabpay
        | Ideal
        | Oxxo
        | P24
        | SepaDebit
        | Sofort

    type PaymentIntents'UpdatePaymentMethodData = {
        Alipay: string option
        AuBecsDebit: PaymentIntents'UpdatePaymentMethodDataAuBecsDebit option
        BacsDebit: PaymentIntents'UpdatePaymentMethodDataBacsDebit option
        Bancontact: string option
        BillingDetails: PaymentIntents'UpdatePaymentMethodDataBillingDetails option
        Eps: string option
        Fpx: PaymentIntents'UpdatePaymentMethodDataFpx option
        Giropay: string option
        Grabpay: string option
        Ideal: PaymentIntents'UpdatePaymentMethodDataIdeal option
        InteracPresent: string option
        Metadata: Map<string, string> option
        Oxxo: string option
        P24: PaymentIntents'UpdatePaymentMethodDataP24 option
        SepaDebit: PaymentIntents'UpdatePaymentMethodDataSepaDebit option
        Sofort: PaymentIntents'UpdatePaymentMethodDataSofort option
        Type: PaymentIntents'UpdatePaymentMethodDataType option
    }
    with
        static member Create(?alipay: string, ?sepaDebit: PaymentIntents'UpdatePaymentMethodDataSepaDebit, ?p24: PaymentIntents'UpdatePaymentMethodDataP24, ?oxxo: string, ?metadata: Map<string, string>, ?interacPresent: string, ?ideal: PaymentIntents'UpdatePaymentMethodDataIdeal, ?sofort: PaymentIntents'UpdatePaymentMethodDataSofort, ?grabpay: string, ?fpx: PaymentIntents'UpdatePaymentMethodDataFpx, ?eps: string, ?billingDetails: PaymentIntents'UpdatePaymentMethodDataBillingDetails, ?bancontact: string, ?bacsDebit: PaymentIntents'UpdatePaymentMethodDataBacsDebit, ?auBecsDebit: PaymentIntents'UpdatePaymentMethodDataAuBecsDebit, ?giropay: string, ?``type``: PaymentIntents'UpdatePaymentMethodDataType) =
            {
                Alipay = alipay
                AuBecsDebit = auBecsDebit
                BacsDebit = bacsDebit
                Bancontact = bancontact
                BillingDetails = billingDetails
                Eps = eps
                Fpx = fpx
                Giropay = giropay
                Grabpay = grabpay
                Ideal = ideal
                InteracPresent = interacPresent
                Metadata = metadata
                Oxxo = oxxo
                P24 = p24
                SepaDebit = sepaDebit
                Sofort = sofort
                Type = ``type``
            }

    type PaymentIntents'UpdatePaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage =
        | De
        | En
        | Fr
        | Nl

    type PaymentIntents'UpdatePaymentMethodOptionsBancontactPaymentMethodOptions = {
        PreferredLanguage: PaymentIntents'UpdatePaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage option
    }
    with
        static member Create(?preferredLanguage: PaymentIntents'UpdatePaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage) =
            {
                PreferredLanguage = preferredLanguage
            }

    type PaymentIntents'UpdatePaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval =
        | Month

    type PaymentIntents'UpdatePaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType =
        | FixedCount

    type PaymentIntents'UpdatePaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan = {
        Count: int option
        Interval: PaymentIntents'UpdatePaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval option
        Type: PaymentIntents'UpdatePaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType option
    }
    with
        static member Create(?count: int, ?interval: PaymentIntents'UpdatePaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval, ?``type``: PaymentIntents'UpdatePaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType) =
            {
                Count = count
                Interval = interval
                Type = ``type``
            }

    type PaymentIntents'UpdatePaymentMethodOptionsCardPaymentIntentInstallments = {
        Enabled: bool option
        Plan: Choice<PaymentIntents'UpdatePaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan,string> option
    }
    with
        static member Create(?enabled: bool, ?plan: Choice<PaymentIntents'UpdatePaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan,string>) =
            {
                Enabled = enabled
                Plan = plan
            }

    type PaymentIntents'UpdatePaymentMethodOptionsCardPaymentIntentNetwork =
        | Amex
        | CartesBancaires
        | Diners
        | Discover
        | Interac
        | Jcb
        | Mastercard
        | Unionpay
        | Unknown
        | Visa

    type PaymentIntents'UpdatePaymentMethodOptionsCardPaymentIntentRequestThreeDSecure =
        | Any
        | Automatic

    type PaymentIntents'UpdatePaymentMethodOptionsCardPaymentIntent = {
        CvcToken: string option
        Installments: PaymentIntents'UpdatePaymentMethodOptionsCardPaymentIntentInstallments option
        Moto: bool option
        Network: PaymentIntents'UpdatePaymentMethodOptionsCardPaymentIntentNetwork option
        RequestThreeDSecure: PaymentIntents'UpdatePaymentMethodOptionsCardPaymentIntentRequestThreeDSecure option
    }
    with
        static member Create(?cvcToken: string, ?installments: PaymentIntents'UpdatePaymentMethodOptionsCardPaymentIntentInstallments, ?moto: bool, ?network: PaymentIntents'UpdatePaymentMethodOptionsCardPaymentIntentNetwork, ?requestThreeDSecure: PaymentIntents'UpdatePaymentMethodOptionsCardPaymentIntentRequestThreeDSecure) =
            {
                CvcToken = cvcToken
                Installments = installments
                Moto = moto
                Network = network
                RequestThreeDSecure = requestThreeDSecure
            }

    type PaymentIntents'UpdatePaymentMethodOptionsOxxoPaymentMethodOptions = {
        ExpiresAfterDays: int option
    }
    with
        static member Create(?expiresAfterDays: int) =
            {
                ExpiresAfterDays = expiresAfterDays
            }

    type PaymentIntents'UpdatePaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions = {
        MandateOptions: string option
    }
    with
        static member Create(?mandateOptions: string) =
            {
                MandateOptions = mandateOptions
            }

    type PaymentIntents'UpdatePaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage =
        | De
        | En
        | Es
        | Fr
        | It
        | Nl
        | Pl

    type PaymentIntents'UpdatePaymentMethodOptionsSofortPaymentMethodOptions = {
        PreferredLanguage: PaymentIntents'UpdatePaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage option
    }
    with
        static member Create(?preferredLanguage: PaymentIntents'UpdatePaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage) =
            {
                PreferredLanguage = preferredLanguage
            }

    type PaymentIntents'UpdatePaymentMethodOptions = {
        Alipay: Choice<string,string> option
        Bancontact: Choice<PaymentIntents'UpdatePaymentMethodOptionsBancontactPaymentMethodOptions,string> option
        Card: Choice<PaymentIntents'UpdatePaymentMethodOptionsCardPaymentIntent,string> option
        Oxxo: Choice<PaymentIntents'UpdatePaymentMethodOptionsOxxoPaymentMethodOptions,string> option
        P24: Choice<string,string> option
        SepaDebit: Choice<PaymentIntents'UpdatePaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions,string> option
        Sofort: Choice<PaymentIntents'UpdatePaymentMethodOptionsSofortPaymentMethodOptions,string> option
    }
    with
        static member Create(?alipay: Choice<string,string>, ?bancontact: Choice<PaymentIntents'UpdatePaymentMethodOptionsBancontactPaymentMethodOptions,string>, ?card: Choice<PaymentIntents'UpdatePaymentMethodOptionsCardPaymentIntent,string>, ?oxxo: Choice<PaymentIntents'UpdatePaymentMethodOptionsOxxoPaymentMethodOptions,string>, ?p24: Choice<string,string>, ?sepaDebit: Choice<PaymentIntents'UpdatePaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions,string>, ?sofort: Choice<PaymentIntents'UpdatePaymentMethodOptionsSofortPaymentMethodOptions,string>) =
            {
                Alipay = alipay
                Bancontact = bancontact
                Card = card
                Oxxo = oxxo
                P24 = p24
                SepaDebit = sepaDebit
                Sofort = sofort
            }

    type PaymentIntents'UpdateShippingShippingAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type PaymentIntents'UpdateShippingShipping = {
        Address: PaymentIntents'UpdateShippingShippingAddress option
        Carrier: string option
        Name: string option
        Phone: string option
        TrackingNumber: string option
    }
    with
        static member Create(?address: PaymentIntents'UpdateShippingShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
            {
                Address = address
                Carrier = carrier
                Name = name
                Phone = phone
                TrackingNumber = trackingNumber
            }

    type PaymentIntents'UpdateTransferData = {
        Amount: int option
    }
    with
        static member Create(?amount: int) =
            {
                Amount = amount
            }

    type PaymentIntents'UpdateSetupFutureUsage =
        | OffSession
        | OnSession

    type PaymentIntents'UpdateOptions = {
        Amount: int option
        ApplicationFeeAmount: Choice<int,string> option
        Currency: string option
        Customer: string option
        Description: string option
        Expand: string list option
        Metadata: Map<string, string> option
        PaymentMethod: string option
        PaymentMethodData: PaymentIntents'UpdatePaymentMethodData option
        PaymentMethodOptions: PaymentIntents'UpdatePaymentMethodOptions option
        PaymentMethodTypes: string list option
        ReceiptEmail: Choice<string,string> option
        SetupFutureUsage: PaymentIntents'UpdateSetupFutureUsage option
        Shipping: Choice<PaymentIntents'UpdateShippingShipping,string> option
        StatementDescriptor: string option
        StatementDescriptorSuffix: string option
        TransferData: PaymentIntents'UpdateTransferData option
        TransferGroup: string option
    }
    with
        static member Create(?amount: int, ?statementDescriptorSuffix: string, ?statementDescriptor: string, ?shipping: Choice<PaymentIntents'UpdateShippingShipping,string>, ?setupFutureUsage: PaymentIntents'UpdateSetupFutureUsage, ?receiptEmail: Choice<string,string>, ?paymentMethodTypes: string list, ?paymentMethodOptions: PaymentIntents'UpdatePaymentMethodOptions, ?paymentMethodData: PaymentIntents'UpdatePaymentMethodData, ?paymentMethod: string, ?metadata: Map<string, string>, ?expand: string list, ?description: string, ?customer: string, ?currency: string, ?applicationFeeAmount: Choice<int,string>, ?transferData: PaymentIntents'UpdateTransferData, ?transferGroup: string) =
            {
                Amount = amount
                ApplicationFeeAmount = applicationFeeAmount
                Currency = currency
                Customer = customer
                Description = description
                Expand = expand
                Metadata = metadata
                PaymentMethod = paymentMethod
                PaymentMethodData = paymentMethodData
                PaymentMethodOptions = paymentMethodOptions
                PaymentMethodTypes = paymentMethodTypes
                ReceiptEmail = receiptEmail
                SetupFutureUsage = setupFutureUsage
                Shipping = shipping
                StatementDescriptor = statementDescriptor
                StatementDescriptorSuffix = statementDescriptorSuffix
                TransferData = transferData
                TransferGroup = transferGroup
            }

    type PaymentIntentsCancel'CancelCancellationReason =
        | Abandoned
        | Duplicate
        | Fraudulent
        | RequestedByCustomer

    type PaymentIntentsCancel'CancelOptions = {
        CancellationReason: PaymentIntentsCancel'CancelCancellationReason option
        Expand: string list option
    }
    with
        static member Create(?cancellationReason: PaymentIntentsCancel'CancelCancellationReason, ?expand: string list) =
            {
                CancellationReason = cancellationReason
                Expand = expand
            }

    type PaymentIntentsCapture'CaptureTransferData = {
        Amount: int option
    }
    with
        static member Create(?amount: int) =
            {
                Amount = amount
            }

    type PaymentIntentsCapture'CaptureOptions = {
        AmountToCapture: int option
        ApplicationFeeAmount: int option
        Expand: string list option
        StatementDescriptor: string option
        StatementDescriptorSuffix: string option
        TransferData: PaymentIntentsCapture'CaptureTransferData option
    }
    with
        static member Create(?amountToCapture: int, ?applicationFeeAmount: int, ?expand: string list, ?statementDescriptor: string, ?statementDescriptorSuffix: string, ?transferData: PaymentIntentsCapture'CaptureTransferData) =
            {
                AmountToCapture = amountToCapture
                ApplicationFeeAmount = applicationFeeAmount
                Expand = expand
                StatementDescriptor = statementDescriptor
                StatementDescriptorSuffix = statementDescriptorSuffix
                TransferData = transferData
            }

    type PaymentIntentsConfirm'ConfirmMandateDataSecretKeyCustomerAcceptanceOnline = {
        IpAddress: string option
        UserAgent: string option
    }
    with
        static member Create(?ipAddress: string, ?userAgent: string) =
            {
                IpAddress = ipAddress
                UserAgent = userAgent
            }

    type PaymentIntentsConfirm'ConfirmMandateDataSecretKeyCustomerAcceptanceType =
        | Offline
        | Online

    type PaymentIntentsConfirm'ConfirmMandateDataSecretKeyCustomerAcceptance = {
        AcceptedAt: DateTime option
        Offline: string option
        Online: PaymentIntentsConfirm'ConfirmMandateDataSecretKeyCustomerAcceptanceOnline option
        Type: PaymentIntentsConfirm'ConfirmMandateDataSecretKeyCustomerAcceptanceType option
    }
    with
        static member Create(?acceptedAt: DateTime, ?offline: string, ?online: PaymentIntentsConfirm'ConfirmMandateDataSecretKeyCustomerAcceptanceOnline, ?``type``: PaymentIntentsConfirm'ConfirmMandateDataSecretKeyCustomerAcceptanceType) =
            {
                AcceptedAt = acceptedAt
                Offline = offline
                Online = online
                Type = ``type``
            }

    type PaymentIntentsConfirm'ConfirmMandateDataSecretKey = {
        CustomerAcceptance: PaymentIntentsConfirm'ConfirmMandateDataSecretKeyCustomerAcceptance option
    }
    with
        static member Create(?customerAcceptance: PaymentIntentsConfirm'ConfirmMandateDataSecretKeyCustomerAcceptance) =
            {
                CustomerAcceptance = customerAcceptance
            }

    type PaymentIntentsConfirm'ConfirmMandateDataClientKeyCustomerAcceptanceOnline = {
        IpAddress: string option
        UserAgent: string option
    }
    with
        static member Create(?ipAddress: string, ?userAgent: string) =
            {
                IpAddress = ipAddress
                UserAgent = userAgent
            }

    type PaymentIntentsConfirm'ConfirmMandateDataClientKeyCustomerAcceptanceType =
        | Online

    type PaymentIntentsConfirm'ConfirmMandateDataClientKeyCustomerAcceptance = {
        Online: PaymentIntentsConfirm'ConfirmMandateDataClientKeyCustomerAcceptanceOnline option
        Type: PaymentIntentsConfirm'ConfirmMandateDataClientKeyCustomerAcceptanceType option
    }
    with
        static member Create(?online: PaymentIntentsConfirm'ConfirmMandateDataClientKeyCustomerAcceptanceOnline, ?``type``: PaymentIntentsConfirm'ConfirmMandateDataClientKeyCustomerAcceptanceType) =
            {
                Online = online
                Type = ``type``
            }

    type PaymentIntentsConfirm'ConfirmMandateDataClientKey = {
        CustomerAcceptance: PaymentIntentsConfirm'ConfirmMandateDataClientKeyCustomerAcceptance option
    }
    with
        static member Create(?customerAcceptance: PaymentIntentsConfirm'ConfirmMandateDataClientKeyCustomerAcceptance) =
            {
                CustomerAcceptance = customerAcceptance
            }

    type PaymentIntentsConfirm'ConfirmOffSession =
        | OneOff
        | Recurring

    type PaymentIntentsConfirm'ConfirmPaymentMethodDataAuBecsDebit = {
        AccountNumber: string option
        BsbNumber: string option
    }
    with
        static member Create(?accountNumber: string, ?bsbNumber: string) =
            {
                AccountNumber = accountNumber
                BsbNumber = bsbNumber
            }

    type PaymentIntentsConfirm'ConfirmPaymentMethodDataBacsDebit = {
        AccountNumber: string option
        SortCode: string option
    }
    with
        static member Create(?accountNumber: string, ?sortCode: string) =
            {
                AccountNumber = accountNumber
                SortCode = sortCode
            }

    type PaymentIntentsConfirm'ConfirmPaymentMethodDataBillingDetailsAddressBillingDetailsAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type PaymentIntentsConfirm'ConfirmPaymentMethodDataBillingDetails = {
        Address: Choice<PaymentIntentsConfirm'ConfirmPaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string> option
        Email: string option
        Name: string option
        Phone: string option
    }
    with
        static member Create(?address: Choice<PaymentIntentsConfirm'ConfirmPaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string>, ?email: string, ?name: string, ?phone: string) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
            }

    type PaymentIntentsConfirm'ConfirmPaymentMethodDataFpxAccountHolderType =
        | Company
        | Individual

    type PaymentIntentsConfirm'ConfirmPaymentMethodDataFpxBank =
        | AffinBank
        | AllianceBank
        | Ambank
        | BankIslam
        | BankMuamalat
        | BankRakyat
        | Bsn
        | Cimb
        | DeutscheBank
        | HongLeongBank
        | Hsbc
        | Kfh
        | Maybank2e
        | Maybank2u
        | Ocbc
        | PbEnterprise
        | PublicBank
        | Rhb
        | StandardChartered
        | Uob

    type PaymentIntentsConfirm'ConfirmPaymentMethodDataFpx = {
        AccountHolderType: PaymentIntentsConfirm'ConfirmPaymentMethodDataFpxAccountHolderType option
        Bank: PaymentIntentsConfirm'ConfirmPaymentMethodDataFpxBank option
    }
    with
        static member Create(?accountHolderType: PaymentIntentsConfirm'ConfirmPaymentMethodDataFpxAccountHolderType, ?bank: PaymentIntentsConfirm'ConfirmPaymentMethodDataFpxBank) =
            {
                AccountHolderType = accountHolderType
                Bank = bank
            }

    type PaymentIntentsConfirm'ConfirmPaymentMethodDataIdealBank =
        | AbnAmro
        | AsnBank
        | Bunq
        | Handelsbanken
        | Ing
        | Knab
        | Moneyou
        | Rabobank
        | Regiobank
        | SnsBank
        | TriodosBank
        | VanLanschot

    type PaymentIntentsConfirm'ConfirmPaymentMethodDataIdeal = {
        Bank: PaymentIntentsConfirm'ConfirmPaymentMethodDataIdealBank option
    }
    with
        static member Create(?bank: PaymentIntentsConfirm'ConfirmPaymentMethodDataIdealBank) =
            {
                Bank = bank
            }

    type PaymentIntentsConfirm'ConfirmPaymentMethodDataP24Bank =
        | AliorBank
        | BankMillennium
        | BankNowyBfgSa
        | BankPekaoSa
        | BankiSpbdzielcze
        | Blik
        | BnpParibas
        | Boz
        | CitiHandlowy
        | CreditAgricole
        | Envelobank
        | EtransferPocztowy24
        | GetinBank
        | Ideabank
        | Ing
        | Inteligo
        | MbankMtransfer
        | NestPrzelew
        | NoblePay
        | PbacZIpko
        | PlusBank
        | SantanderPrzelew24
        | TmobileUsbugiBankowe
        | ToyotaBank
        | VolkswagenBank

    type PaymentIntentsConfirm'ConfirmPaymentMethodDataP24 = {
        Bank: PaymentIntentsConfirm'ConfirmPaymentMethodDataP24Bank option
    }
    with
        static member Create(?bank: PaymentIntentsConfirm'ConfirmPaymentMethodDataP24Bank) =
            {
                Bank = bank
            }

    type PaymentIntentsConfirm'ConfirmPaymentMethodDataSepaDebit = {
        Iban: string option
    }
    with
        static member Create(?iban: string) =
            {
                Iban = iban
            }

    type PaymentIntentsConfirm'ConfirmPaymentMethodDataSofortCountry =
        | [<JsonUnionCase("AT")>] AT
        | [<JsonUnionCase("BE")>] BE
        | [<JsonUnionCase("DE")>] DE
        | [<JsonUnionCase("ES")>] ES
        | [<JsonUnionCase("IT")>] IT
        | [<JsonUnionCase("NL")>] NL

    type PaymentIntentsConfirm'ConfirmPaymentMethodDataSofort = {
        Country: PaymentIntentsConfirm'ConfirmPaymentMethodDataSofortCountry option
    }
    with
        static member Create(?country: PaymentIntentsConfirm'ConfirmPaymentMethodDataSofortCountry) =
            {
                Country = country
            }

    type PaymentIntentsConfirm'ConfirmPaymentMethodDataType =
        | Alipay
        | AuBecsDebit
        | BacsDebit
        | Bancontact
        | Eps
        | Fpx
        | Giropay
        | Grabpay
        | Ideal
        | Oxxo
        | P24
        | SepaDebit
        | Sofort

    type PaymentIntentsConfirm'ConfirmPaymentMethodData = {
        Alipay: string option
        AuBecsDebit: PaymentIntentsConfirm'ConfirmPaymentMethodDataAuBecsDebit option
        BacsDebit: PaymentIntentsConfirm'ConfirmPaymentMethodDataBacsDebit option
        Bancontact: string option
        BillingDetails: PaymentIntentsConfirm'ConfirmPaymentMethodDataBillingDetails option
        Eps: string option
        Fpx: PaymentIntentsConfirm'ConfirmPaymentMethodDataFpx option
        Giropay: string option
        Grabpay: string option
        Ideal: PaymentIntentsConfirm'ConfirmPaymentMethodDataIdeal option
        InteracPresent: string option
        Metadata: Map<string, string> option
        Oxxo: string option
        P24: PaymentIntentsConfirm'ConfirmPaymentMethodDataP24 option
        SepaDebit: PaymentIntentsConfirm'ConfirmPaymentMethodDataSepaDebit option
        Sofort: PaymentIntentsConfirm'ConfirmPaymentMethodDataSofort option
        Type: PaymentIntentsConfirm'ConfirmPaymentMethodDataType option
    }
    with
        static member Create(?alipay: string, ?sepaDebit: PaymentIntentsConfirm'ConfirmPaymentMethodDataSepaDebit, ?p24: PaymentIntentsConfirm'ConfirmPaymentMethodDataP24, ?oxxo: string, ?metadata: Map<string, string>, ?interacPresent: string, ?ideal: PaymentIntentsConfirm'ConfirmPaymentMethodDataIdeal, ?sofort: PaymentIntentsConfirm'ConfirmPaymentMethodDataSofort, ?grabpay: string, ?fpx: PaymentIntentsConfirm'ConfirmPaymentMethodDataFpx, ?eps: string, ?billingDetails: PaymentIntentsConfirm'ConfirmPaymentMethodDataBillingDetails, ?bancontact: string, ?bacsDebit: PaymentIntentsConfirm'ConfirmPaymentMethodDataBacsDebit, ?auBecsDebit: PaymentIntentsConfirm'ConfirmPaymentMethodDataAuBecsDebit, ?giropay: string, ?``type``: PaymentIntentsConfirm'ConfirmPaymentMethodDataType) =
            {
                Alipay = alipay
                AuBecsDebit = auBecsDebit
                BacsDebit = bacsDebit
                Bancontact = bancontact
                BillingDetails = billingDetails
                Eps = eps
                Fpx = fpx
                Giropay = giropay
                Grabpay = grabpay
                Ideal = ideal
                InteracPresent = interacPresent
                Metadata = metadata
                Oxxo = oxxo
                P24 = p24
                SepaDebit = sepaDebit
                Sofort = sofort
                Type = ``type``
            }

    type PaymentIntentsConfirm'ConfirmPaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage =
        | De
        | En
        | Fr
        | Nl

    type PaymentIntentsConfirm'ConfirmPaymentMethodOptionsBancontactPaymentMethodOptions = {
        PreferredLanguage: PaymentIntentsConfirm'ConfirmPaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage option
    }
    with
        static member Create(?preferredLanguage: PaymentIntentsConfirm'ConfirmPaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage) =
            {
                PreferredLanguage = preferredLanguage
            }

    type PaymentIntentsConfirm'ConfirmPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval =
        | Month

    type PaymentIntentsConfirm'ConfirmPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType =
        | FixedCount

    type PaymentIntentsConfirm'ConfirmPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan = {
        Count: int option
        Interval: PaymentIntentsConfirm'ConfirmPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval option
        Type: PaymentIntentsConfirm'ConfirmPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType option
    }
    with
        static member Create(?count: int, ?interval: PaymentIntentsConfirm'ConfirmPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval, ?``type``: PaymentIntentsConfirm'ConfirmPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType) =
            {
                Count = count
                Interval = interval
                Type = ``type``
            }

    type PaymentIntentsConfirm'ConfirmPaymentMethodOptionsCardPaymentIntentInstallments = {
        Enabled: bool option
        Plan: Choice<PaymentIntentsConfirm'ConfirmPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan,string> option
    }
    with
        static member Create(?enabled: bool, ?plan: Choice<PaymentIntentsConfirm'ConfirmPaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan,string>) =
            {
                Enabled = enabled
                Plan = plan
            }

    type PaymentIntentsConfirm'ConfirmPaymentMethodOptionsCardPaymentIntentNetwork =
        | Amex
        | CartesBancaires
        | Diners
        | Discover
        | Interac
        | Jcb
        | Mastercard
        | Unionpay
        | Unknown
        | Visa

    type PaymentIntentsConfirm'ConfirmPaymentMethodOptionsCardPaymentIntentRequestThreeDSecure =
        | Any
        | Automatic

    type PaymentIntentsConfirm'ConfirmPaymentMethodOptionsCardPaymentIntent = {
        CvcToken: string option
        Installments: PaymentIntentsConfirm'ConfirmPaymentMethodOptionsCardPaymentIntentInstallments option
        Moto: bool option
        Network: PaymentIntentsConfirm'ConfirmPaymentMethodOptionsCardPaymentIntentNetwork option
        RequestThreeDSecure: PaymentIntentsConfirm'ConfirmPaymentMethodOptionsCardPaymentIntentRequestThreeDSecure option
    }
    with
        static member Create(?cvcToken: string, ?installments: PaymentIntentsConfirm'ConfirmPaymentMethodOptionsCardPaymentIntentInstallments, ?moto: bool, ?network: PaymentIntentsConfirm'ConfirmPaymentMethodOptionsCardPaymentIntentNetwork, ?requestThreeDSecure: PaymentIntentsConfirm'ConfirmPaymentMethodOptionsCardPaymentIntentRequestThreeDSecure) =
            {
                CvcToken = cvcToken
                Installments = installments
                Moto = moto
                Network = network
                RequestThreeDSecure = requestThreeDSecure
            }

    type PaymentIntentsConfirm'ConfirmPaymentMethodOptionsOxxoPaymentMethodOptions = {
        ExpiresAfterDays: int option
    }
    with
        static member Create(?expiresAfterDays: int) =
            {
                ExpiresAfterDays = expiresAfterDays
            }

    type PaymentIntentsConfirm'ConfirmPaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions = {
        MandateOptions: string option
    }
    with
        static member Create(?mandateOptions: string) =
            {
                MandateOptions = mandateOptions
            }

    type PaymentIntentsConfirm'ConfirmPaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage =
        | De
        | En
        | Es
        | Fr
        | It
        | Nl
        | Pl

    type PaymentIntentsConfirm'ConfirmPaymentMethodOptionsSofortPaymentMethodOptions = {
        PreferredLanguage: PaymentIntentsConfirm'ConfirmPaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage option
    }
    with
        static member Create(?preferredLanguage: PaymentIntentsConfirm'ConfirmPaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage) =
            {
                PreferredLanguage = preferredLanguage
            }

    type PaymentIntentsConfirm'ConfirmPaymentMethodOptions = {
        Alipay: Choice<string,string> option
        Bancontact: Choice<PaymentIntentsConfirm'ConfirmPaymentMethodOptionsBancontactPaymentMethodOptions,string> option
        Card: Choice<PaymentIntentsConfirm'ConfirmPaymentMethodOptionsCardPaymentIntent,string> option
        Oxxo: Choice<PaymentIntentsConfirm'ConfirmPaymentMethodOptionsOxxoPaymentMethodOptions,string> option
        P24: Choice<string,string> option
        SepaDebit: Choice<PaymentIntentsConfirm'ConfirmPaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions,string> option
        Sofort: Choice<PaymentIntentsConfirm'ConfirmPaymentMethodOptionsSofortPaymentMethodOptions,string> option
    }
    with
        static member Create(?alipay: Choice<string,string>, ?bancontact: Choice<PaymentIntentsConfirm'ConfirmPaymentMethodOptionsBancontactPaymentMethodOptions,string>, ?card: Choice<PaymentIntentsConfirm'ConfirmPaymentMethodOptionsCardPaymentIntent,string>, ?oxxo: Choice<PaymentIntentsConfirm'ConfirmPaymentMethodOptionsOxxoPaymentMethodOptions,string>, ?p24: Choice<string,string>, ?sepaDebit: Choice<PaymentIntentsConfirm'ConfirmPaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions,string>, ?sofort: Choice<PaymentIntentsConfirm'ConfirmPaymentMethodOptionsSofortPaymentMethodOptions,string>) =
            {
                Alipay = alipay
                Bancontact = bancontact
                Card = card
                Oxxo = oxxo
                P24 = p24
                SepaDebit = sepaDebit
                Sofort = sofort
            }

    type PaymentIntentsConfirm'ConfirmShippingShippingAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type PaymentIntentsConfirm'ConfirmShippingShipping = {
        Address: PaymentIntentsConfirm'ConfirmShippingShippingAddress option
        Carrier: string option
        Name: string option
        Phone: string option
        TrackingNumber: string option
    }
    with
        static member Create(?address: PaymentIntentsConfirm'ConfirmShippingShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
            {
                Address = address
                Carrier = carrier
                Name = name
                Phone = phone
                TrackingNumber = trackingNumber
            }

    type PaymentIntentsConfirm'ConfirmSetupFutureUsage =
        | OffSession
        | OnSession

    type PaymentIntentsConfirm'ConfirmOptions = {
        ErrorOnRequiresAction: bool option
        Expand: string list option
        Mandate: string option
        MandateData: Choice<PaymentIntentsConfirm'ConfirmMandateDataSecretKey,PaymentIntentsConfirm'ConfirmMandateDataClientKey> option
        OffSession: Choice<bool,PaymentIntentsConfirm'ConfirmOffSession> option
        PaymentMethod: string option
        PaymentMethodData: PaymentIntentsConfirm'ConfirmPaymentMethodData option
        PaymentMethodOptions: PaymentIntentsConfirm'ConfirmPaymentMethodOptions option
        ReceiptEmail: Choice<string,string> option
        ReturnUrl: string option
        SetupFutureUsage: PaymentIntentsConfirm'ConfirmSetupFutureUsage option
        Shipping: Choice<PaymentIntentsConfirm'ConfirmShippingShipping,string> option
        UseStripeSdk: bool option
    }
    with
        static member Create(?errorOnRequiresAction: bool, ?expand: string list, ?mandate: string, ?mandateData: Choice<PaymentIntentsConfirm'ConfirmMandateDataSecretKey,PaymentIntentsConfirm'ConfirmMandateDataClientKey>, ?offSession: Choice<bool,PaymentIntentsConfirm'ConfirmOffSession>, ?paymentMethod: string, ?paymentMethodData: PaymentIntentsConfirm'ConfirmPaymentMethodData, ?paymentMethodOptions: PaymentIntentsConfirm'ConfirmPaymentMethodOptions, ?receiptEmail: Choice<string,string>, ?returnUrl: string, ?setupFutureUsage: PaymentIntentsConfirm'ConfirmSetupFutureUsage, ?shipping: Choice<PaymentIntentsConfirm'ConfirmShippingShipping,string>, ?useStripeSdk: bool) =
            {
                ErrorOnRequiresAction = errorOnRequiresAction
                Expand = expand
                Mandate = mandate
                MandateData = mandateData
                OffSession = offSession
                PaymentMethod = paymentMethod
                PaymentMethodData = paymentMethodData
                PaymentMethodOptions = paymentMethodOptions
                ReceiptEmail = receiptEmail
                ReturnUrl = returnUrl
                SetupFutureUsage = setupFutureUsage
                Shipping = shipping
                UseStripeSdk = useStripeSdk
            }

    type PaymentMethods'CreateAuBecsDebit = {
        AccountNumber: string option
        BsbNumber: string option
    }
    with
        static member Create(?accountNumber: string, ?bsbNumber: string) =
            {
                AccountNumber = accountNumber
                BsbNumber = bsbNumber
            }

    type PaymentMethods'CreateBacsDebit = {
        AccountNumber: string option
        SortCode: string option
    }
    with
        static member Create(?accountNumber: string, ?sortCode: string) =
            {
                AccountNumber = accountNumber
                SortCode = sortCode
            }

    type PaymentMethods'CreateBillingDetailsAddressBillingDetailsAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type PaymentMethods'CreateBillingDetails = {
        Address: Choice<PaymentMethods'CreateBillingDetailsAddressBillingDetailsAddress,string> option
        Email: string option
        Name: string option
        Phone: string option
    }
    with
        static member Create(?address: Choice<PaymentMethods'CreateBillingDetailsAddressBillingDetailsAddress,string>, ?email: string, ?name: string, ?phone: string) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
            }

    type PaymentMethods'CreateCardCardDetailsParams = {
        Cvc: string option
        ExpMonth: int option
        ExpYear: int option
        Number: string option
    }
    with
        static member Create(?cvc: string, ?expMonth: int, ?expYear: int, ?number: string) =
            {
                Cvc = cvc
                ExpMonth = expMonth
                ExpYear = expYear
                Number = number
            }

    type PaymentMethods'CreateCardTokenParams = {
        Token: string option
    }
    with
        static member Create(?token: string) =
            {
                Token = token
            }

    type PaymentMethods'CreateFpxAccountHolderType =
        | Company
        | Individual

    type PaymentMethods'CreateFpxBank =
        | AffinBank
        | AllianceBank
        | Ambank
        | BankIslam
        | BankMuamalat
        | BankRakyat
        | Bsn
        | Cimb
        | DeutscheBank
        | HongLeongBank
        | Hsbc
        | Kfh
        | Maybank2e
        | Maybank2u
        | Ocbc
        | PbEnterprise
        | PublicBank
        | Rhb
        | StandardChartered
        | Uob

    type PaymentMethods'CreateFpx = {
        AccountHolderType: PaymentMethods'CreateFpxAccountHolderType option
        Bank: PaymentMethods'CreateFpxBank option
    }
    with
        static member Create(?accountHolderType: PaymentMethods'CreateFpxAccountHolderType, ?bank: PaymentMethods'CreateFpxBank) =
            {
                AccountHolderType = accountHolderType
                Bank = bank
            }

    type PaymentMethods'CreateIdealBank =
        | AbnAmro
        | AsnBank
        | Bunq
        | Handelsbanken
        | Ing
        | Knab
        | Moneyou
        | Rabobank
        | Regiobank
        | SnsBank
        | TriodosBank
        | VanLanschot

    type PaymentMethods'CreateIdeal = {
        Bank: PaymentMethods'CreateIdealBank option
    }
    with
        static member Create(?bank: PaymentMethods'CreateIdealBank) =
            {
                Bank = bank
            }

    type PaymentMethods'CreateP24Bank =
        | AliorBank
        | BankMillennium
        | BankNowyBfgSa
        | BankPekaoSa
        | BankiSpbdzielcze
        | Blik
        | BnpParibas
        | Boz
        | CitiHandlowy
        | CreditAgricole
        | Envelobank
        | EtransferPocztowy24
        | GetinBank
        | Ideabank
        | Ing
        | Inteligo
        | MbankMtransfer
        | NestPrzelew
        | NoblePay
        | PbacZIpko
        | PlusBank
        | SantanderPrzelew24
        | TmobileUsbugiBankowe
        | ToyotaBank
        | VolkswagenBank

    type PaymentMethods'CreateP24 = {
        Bank: PaymentMethods'CreateP24Bank option
    }
    with
        static member Create(?bank: PaymentMethods'CreateP24Bank) =
            {
                Bank = bank
            }

    type PaymentMethods'CreateSepaDebit = {
        Iban: string option
    }
    with
        static member Create(?iban: string) =
            {
                Iban = iban
            }

    type PaymentMethods'CreateSofortCountry =
        | [<JsonUnionCase("AT")>] AT
        | [<JsonUnionCase("BE")>] BE
        | [<JsonUnionCase("DE")>] DE
        | [<JsonUnionCase("ES")>] ES
        | [<JsonUnionCase("IT")>] IT
        | [<JsonUnionCase("NL")>] NL

    type PaymentMethods'CreateSofort = {
        Country: PaymentMethods'CreateSofortCountry option
    }
    with
        static member Create(?country: PaymentMethods'CreateSofortCountry) =
            {
                Country = country
            }

    type PaymentMethods'CreateType =
        | Alipay
        | AuBecsDebit
        | BacsDebit
        | Bancontact
        | Card
        | Eps
        | Fpx
        | Giropay
        | Grabpay
        | Ideal
        | Oxxo
        | P24
        | SepaDebit
        | Sofort

    type PaymentMethods'CreateOptions = {
        Alipay: string option
        AuBecsDebit: PaymentMethods'CreateAuBecsDebit option
        BacsDebit: PaymentMethods'CreateBacsDebit option
        Bancontact: string option
        BillingDetails: PaymentMethods'CreateBillingDetails option
        Card: Choice<PaymentMethods'CreateCardCardDetailsParams,PaymentMethods'CreateCardTokenParams> option
        Customer: string option
        Eps: string option
        Expand: string list option
        Fpx: PaymentMethods'CreateFpx option
        Giropay: string option
        Grabpay: string option
        Ideal: PaymentMethods'CreateIdeal option
        InteracPresent: string option
        Metadata: Map<string, string> option
        Oxxo: string option
        P24: PaymentMethods'CreateP24 option
        PaymentMethod: string option
        SepaDebit: PaymentMethods'CreateSepaDebit option
        Sofort: PaymentMethods'CreateSofort option
        Type: PaymentMethods'CreateType option
    }
    with
        static member Create(?alipay: string, ?sepaDebit: PaymentMethods'CreateSepaDebit, ?paymentMethod: string, ?p24: PaymentMethods'CreateP24, ?oxxo: string, ?metadata: Map<string, string>, ?interacPresent: string, ?ideal: PaymentMethods'CreateIdeal, ?grabpay: string, ?sofort: PaymentMethods'CreateSofort, ?giropay: string, ?expand: string list, ?eps: string, ?customer: string, ?card: Choice<PaymentMethods'CreateCardCardDetailsParams,PaymentMethods'CreateCardTokenParams>, ?billingDetails: PaymentMethods'CreateBillingDetails, ?bancontact: string, ?bacsDebit: PaymentMethods'CreateBacsDebit, ?auBecsDebit: PaymentMethods'CreateAuBecsDebit, ?fpx: PaymentMethods'CreateFpx, ?``type``: PaymentMethods'CreateType) =
            {
                Alipay = alipay
                AuBecsDebit = auBecsDebit
                BacsDebit = bacsDebit
                Bancontact = bancontact
                BillingDetails = billingDetails
                Card = card
                Customer = customer
                Eps = eps
                Expand = expand
                Fpx = fpx
                Giropay = giropay
                Grabpay = grabpay
                Ideal = ideal
                InteracPresent = interacPresent
                Metadata = metadata
                Oxxo = oxxo
                P24 = p24
                PaymentMethod = paymentMethod
                SepaDebit = sepaDebit
                Sofort = sofort
                Type = ``type``
            }

    type PaymentMethods'UpdateBillingDetailsAddressBillingDetailsAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type PaymentMethods'UpdateBillingDetails = {
        Address: Choice<PaymentMethods'UpdateBillingDetailsAddressBillingDetailsAddress,string> option
        Email: string option
        Name: string option
        Phone: string option
    }
    with
        static member Create(?address: Choice<PaymentMethods'UpdateBillingDetailsAddressBillingDetailsAddress,string>, ?email: string, ?name: string, ?phone: string) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
            }

    type PaymentMethods'UpdateCard = {
        ExpMonth: int option
        ExpYear: int option
    }
    with
        static member Create(?expMonth: int, ?expYear: int) =
            {
                ExpMonth = expMonth
                ExpYear = expYear
            }

    type PaymentMethods'UpdateOptions = {
        AuBecsDebit: string option
        BillingDetails: PaymentMethods'UpdateBillingDetails option
        Card: PaymentMethods'UpdateCard option
        Expand: string list option
        Metadata: Map<string, string> option
        SepaDebit: string option
    }
    with
        static member Create(?auBecsDebit: string, ?billingDetails: PaymentMethods'UpdateBillingDetails, ?card: PaymentMethods'UpdateCard, ?expand: string list, ?metadata: Map<string, string>, ?sepaDebit: string) =
            {
                AuBecsDebit = auBecsDebit
                BillingDetails = billingDetails
                Card = card
                Expand = expand
                Metadata = metadata
                SepaDebit = sepaDebit
            }

    type PaymentMethodsAttach'AttachOptions = {
        Customer: string
        Expand: string list option
    }
    with
        static member Create(customer: string, ?expand: string list) =
            {
                Customer = customer
                Expand = expand
            }

    type PaymentMethodsDetach'DetachOptions = {
        Expand: string list option
    }
    with
        static member Create(?expand: string list) =
            {
                Expand = expand
            }

    type Payouts'CreateMethod =
        | Instant
        | Standard

    type Payouts'CreateSourceType =
        | BankAccount
        | Card
        | Fpx

    type Payouts'CreateOptions = {
        Amount: int
        Currency: string
        Description: string option
        Destination: string option
        Expand: string list option
        Metadata: Map<string, string> option
        Method: Payouts'CreateMethod option
        SourceType: Payouts'CreateSourceType option
        StatementDescriptor: string option
    }
    with
        static member Create(amount: int, currency: string, ?description: string, ?destination: string, ?expand: string list, ?metadata: Map<string, string>, ?method: Payouts'CreateMethod, ?sourceType: Payouts'CreateSourceType, ?statementDescriptor: string) =
            {
                Amount = amount
                Currency = currency
                Description = description
                Destination = destination
                Expand = expand
                Metadata = metadata
                Method = method
                SourceType = sourceType
                StatementDescriptor = statementDescriptor
            }

    type Payouts'UpdateOptions = {
        Expand: string list option
        Metadata: Map<string, string> option
    }
    with
        static member Create(?expand: string list, ?metadata: Map<string, string>) =
            {
                Expand = expand
                Metadata = metadata
            }

    type PayoutsCancel'CancelOptions = {
        Expand: string list option
    }
    with
        static member Create(?expand: string list) =
            {
                Expand = expand
            }

    type PayoutsReverse'ReverseOptions = {
        Expand: string list option
        Metadata: Map<string, string> option
    }
    with
        static member Create(?expand: string list, ?metadata: Map<string, string>) =
            {
                Expand = expand
                Metadata = metadata
            }

    type Plans'CreateProductInlineProductParams = {
        Active: bool option
        Id: string option
        Metadata: Map<string, string> option
        Name: string option
        StatementDescriptor: string option
        UnitLabel: string option
    }
    with
        static member Create(?active: bool, ?id: string, ?metadata: Map<string, string>, ?name: string, ?statementDescriptor: string, ?unitLabel: string) =
            {
                Active = active
                Id = id
                Metadata = metadata
                Name = name
                StatementDescriptor = statementDescriptor
                UnitLabel = unitLabel
            }

    type Plans'CreateTiersUpTo =
        | Inf

    type Plans'CreateTiers = {
        FlatAmount: int option
        FlatAmountDecimal: string option
        UnitAmount: int option
        UnitAmountDecimal: string option
        UpTo: Choice<Plans'CreateTiersUpTo,int> option
    }
    with
        static member Create(?flatAmount: int, ?flatAmountDecimal: string, ?unitAmount: int, ?unitAmountDecimal: string, ?upTo: Choice<Plans'CreateTiersUpTo,int>) =
            {
                FlatAmount = flatAmount
                FlatAmountDecimal = flatAmountDecimal
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
                UpTo = upTo
            }

    type Plans'CreateTransformUsageRound =
        | Down
        | Up

    type Plans'CreateTransformUsage = {
        DivideBy: int option
        Round: Plans'CreateTransformUsageRound option
    }
    with
        static member Create(?divideBy: int, ?round: Plans'CreateTransformUsageRound) =
            {
                DivideBy = divideBy
                Round = round
            }

    type Plans'CreateAggregateUsage =
        | LastDuringPeriod
        | LastEver
        | Max
        | Sum

    type Plans'CreateBillingScheme =
        | PerUnit
        | Tiered

    type Plans'CreateInterval =
        | Day
        | Month
        | Week
        | Year

    type Plans'CreateTiersMode =
        | Graduated
        | Volume

    type Plans'CreateUsageType =
        | Licensed
        | Metered

    type Plans'CreateOptions = {
        Active: bool option
        AggregateUsage: Plans'CreateAggregateUsage option
        Amount: int option
        AmountDecimal: string option
        BillingScheme: Plans'CreateBillingScheme option
        Currency: string
        Expand: string list option
        Id: string option
        Interval: Plans'CreateInterval
        IntervalCount: int option
        Metadata: Map<string, string> option
        Nickname: string option
        Product: Choice<Plans'CreateProductInlineProductParams,string> option
        Tiers: Plans'CreateTiers list option
        TiersMode: Plans'CreateTiersMode option
        TransformUsage: Plans'CreateTransformUsage option
        TrialPeriodDays: int option
        UsageType: Plans'CreateUsageType option
    }
    with
        static member Create(interval: Plans'CreateInterval, currency: string, ?transformUsage: Plans'CreateTransformUsage, ?tiersMode: Plans'CreateTiersMode, ?tiers: Plans'CreateTiers list, ?product: Choice<Plans'CreateProductInlineProductParams,string>, ?nickname: string, ?metadata: Map<string, string>, ?intervalCount: int, ?active: bool, ?id: string, ?expand: string list, ?billingScheme: Plans'CreateBillingScheme, ?amountDecimal: string, ?amount: int, ?aggregateUsage: Plans'CreateAggregateUsage, ?trialPeriodDays: int, ?usageType: Plans'CreateUsageType) =
            {
                Active = active
                AggregateUsage = aggregateUsage
                Amount = amount
                AmountDecimal = amountDecimal
                BillingScheme = billingScheme
                Currency = currency
                Expand = expand
                Id = id
                Interval = interval
                IntervalCount = intervalCount
                Metadata = metadata
                Nickname = nickname
                Product = product
                Tiers = tiers
                TiersMode = tiersMode
                TransformUsage = transformUsage
                TrialPeriodDays = trialPeriodDays
                UsageType = usageType
            }

    type Plans'UpdateOptions = {
        Active: bool option
        Expand: string list option
        Metadata: Map<string, string> option
        Nickname: string option
        Product: string option
        TrialPeriodDays: int option
    }
    with
        static member Create(?active: bool, ?expand: string list, ?metadata: Map<string, string>, ?nickname: string, ?product: string, ?trialPeriodDays: int) =
            {
                Active = active
                Expand = expand
                Metadata = metadata
                Nickname = nickname
                Product = product
                TrialPeriodDays = trialPeriodDays
            }

    type Prices'CreateProductData = {
        Active: bool option
        Id: string option
        Metadata: Map<string, string> option
        Name: string option
        StatementDescriptor: string option
        UnitLabel: string option
    }
    with
        static member Create(?active: bool, ?id: string, ?metadata: Map<string, string>, ?name: string, ?statementDescriptor: string, ?unitLabel: string) =
            {
                Active = active
                Id = id
                Metadata = metadata
                Name = name
                StatementDescriptor = statementDescriptor
                UnitLabel = unitLabel
            }

    type Prices'CreateRecurringAggregateUsage =
        | LastDuringPeriod
        | LastEver
        | Max
        | Sum

    type Prices'CreateRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    type Prices'CreateRecurringUsageType =
        | Licensed
        | Metered

    type Prices'CreateRecurring = {
        AggregateUsage: Prices'CreateRecurringAggregateUsage option
        Interval: Prices'CreateRecurringInterval option
        IntervalCount: int option
        TrialPeriodDays: int option
        UsageType: Prices'CreateRecurringUsageType option
    }
    with
        static member Create(?aggregateUsage: Prices'CreateRecurringAggregateUsage, ?interval: Prices'CreateRecurringInterval, ?intervalCount: int, ?trialPeriodDays: int, ?usageType: Prices'CreateRecurringUsageType) =
            {
                AggregateUsage = aggregateUsage
                Interval = interval
                IntervalCount = intervalCount
                TrialPeriodDays = trialPeriodDays
                UsageType = usageType
            }

    type Prices'CreateTiersUpTo =
        | Inf

    type Prices'CreateTiers = {
        FlatAmount: int option
        FlatAmountDecimal: string option
        UnitAmount: int option
        UnitAmountDecimal: string option
        UpTo: Choice<Prices'CreateTiersUpTo,int> option
    }
    with
        static member Create(?flatAmount: int, ?flatAmountDecimal: string, ?unitAmount: int, ?unitAmountDecimal: string, ?upTo: Choice<Prices'CreateTiersUpTo,int>) =
            {
                FlatAmount = flatAmount
                FlatAmountDecimal = flatAmountDecimal
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
                UpTo = upTo
            }

    type Prices'CreateTransformQuantityRound =
        | Down
        | Up

    type Prices'CreateTransformQuantity = {
        DivideBy: int option
        Round: Prices'CreateTransformQuantityRound option
    }
    with
        static member Create(?divideBy: int, ?round: Prices'CreateTransformQuantityRound) =
            {
                DivideBy = divideBy
                Round = round
            }

    type Prices'CreateBillingScheme =
        | PerUnit
        | Tiered

    type Prices'CreateTiersMode =
        | Graduated
        | Volume

    type Prices'CreateOptions = {
        Active: bool option
        BillingScheme: Prices'CreateBillingScheme option
        Currency: string
        Expand: string list option
        LookupKey: string option
        Metadata: Map<string, string> option
        Nickname: string option
        Product: string option
        ProductData: Prices'CreateProductData option
        Recurring: Prices'CreateRecurring option
        Tiers: Prices'CreateTiers list option
        TiersMode: Prices'CreateTiersMode option
        TransferLookupKey: bool option
        TransformQuantity: Prices'CreateTransformQuantity option
        UnitAmount: int option
        UnitAmountDecimal: string option
    }
    with
        static member Create(currency: string, ?active: bool, ?billingScheme: Prices'CreateBillingScheme, ?expand: string list, ?lookupKey: string, ?metadata: Map<string, string>, ?nickname: string, ?product: string, ?productData: Prices'CreateProductData, ?recurring: Prices'CreateRecurring, ?tiers: Prices'CreateTiers list, ?tiersMode: Prices'CreateTiersMode, ?transferLookupKey: bool, ?transformQuantity: Prices'CreateTransformQuantity, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Active = active
                BillingScheme = billingScheme
                Currency = currency
                Expand = expand
                LookupKey = lookupKey
                Metadata = metadata
                Nickname = nickname
                Product = product
                ProductData = productData
                Recurring = recurring
                Tiers = tiers
                TiersMode = tiersMode
                TransferLookupKey = transferLookupKey
                TransformQuantity = transformQuantity
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Prices'UpdateRecurringUpdateRecurringParams = {
        TrialPeriodDays: int option
    }
    with
        static member Create(?trialPeriodDays: int) =
            {
                TrialPeriodDays = trialPeriodDays
            }

    type Prices'UpdateOptions = {
        Active: bool option
        Expand: string list option
        LookupKey: string option
        Metadata: Map<string, string> option
        Nickname: string option
        Recurring: Choice<Prices'UpdateRecurringUpdateRecurringParams,string> option
        TransferLookupKey: bool option
    }
    with
        static member Create(?active: bool, ?expand: string list, ?lookupKey: string, ?metadata: Map<string, string>, ?nickname: string, ?recurring: Choice<Prices'UpdateRecurringUpdateRecurringParams,string>, ?transferLookupKey: bool) =
            {
                Active = active
                Expand = expand
                LookupKey = lookupKey
                Metadata = metadata
                Nickname = nickname
                Recurring = recurring
                TransferLookupKey = transferLookupKey
            }

    type Products'CreatePackageDimensions = {
        Height: decimal option
        Length: decimal option
        Weight: decimal option
        Width: decimal option
    }
    with
        static member Create(?height: decimal, ?length: decimal, ?weight: decimal, ?width: decimal) =
            {
                Height = height
                Length = length
                Weight = weight
                Width = width
            }

    type Products'CreateType =
        | Good
        | Service

    type Products'CreateOptions = {
        Active: bool option
        Attributes: string list option
        Caption: string option
        DeactivateOn: string list option
        Description: string option
        Expand: string list option
        Id: string option
        Images: string list option
        Metadata: Map<string, string> option
        Name: string
        PackageDimensions: Products'CreatePackageDimensions option
        Shippable: bool option
        StatementDescriptor: string option
        Type: Products'CreateType option
        UnitLabel: string option
        Url: string option
    }
    with
        static member Create(name: string, ?active: bool, ?attributes: string list, ?caption: string, ?deactivateOn: string list, ?description: string, ?expand: string list, ?id: string, ?images: string list, ?metadata: Map<string, string>, ?packageDimensions: Products'CreatePackageDimensions, ?shippable: bool, ?statementDescriptor: string, ?``type``: Products'CreateType, ?unitLabel: string, ?url: string) =
            {
                Active = active
                Attributes = attributes
                Caption = caption
                DeactivateOn = deactivateOn
                Description = description
                Expand = expand
                Id = id
                Images = images
                Metadata = metadata
                Name = name
                PackageDimensions = packageDimensions
                Shippable = shippable
                StatementDescriptor = statementDescriptor
                Type = ``type``
                UnitLabel = unitLabel
                Url = url
            }

    type Products'UpdatePackageDimensionsPackageDimensionsSpecs = {
        Height: decimal option
        Length: decimal option
        Weight: decimal option
        Width: decimal option
    }
    with
        static member Create(?height: decimal, ?length: decimal, ?weight: decimal, ?width: decimal) =
            {
                Height = height
                Length = length
                Weight = weight
                Width = width
            }

    type Products'UpdateOptions = {
        Active: bool option
        Attributes: Choice<string list,string> option
        Caption: string option
        DeactivateOn: string list option
        Description: string option
        Expand: string list option
        Images: Choice<string list,string> option
        Metadata: Map<string, string> option
        Name: string option
        PackageDimensions: Choice<Products'UpdatePackageDimensionsPackageDimensionsSpecs,string> option
        Shippable: bool option
        StatementDescriptor: string option
        UnitLabel: string option
        Url: string option
    }
    with
        static member Create(?active: bool, ?attributes: Choice<string list,string>, ?caption: string, ?deactivateOn: string list, ?description: string, ?expand: string list, ?images: Choice<string list,string>, ?metadata: Map<string, string>, ?name: string, ?packageDimensions: Choice<Products'UpdatePackageDimensionsPackageDimensionsSpecs,string>, ?shippable: bool, ?statementDescriptor: string, ?unitLabel: string, ?url: string) =
            {
                Active = active
                Attributes = attributes
                Caption = caption
                DeactivateOn = deactivateOn
                Description = description
                Expand = expand
                Images = images
                Metadata = metadata
                Name = name
                PackageDimensions = packageDimensions
                Shippable = shippable
                StatementDescriptor = statementDescriptor
                UnitLabel = unitLabel
                Url = url
            }

    type PromotionCodes'CreateRestrictions = {
        FirstTimeTransaction: bool option
        MinimumAmount: int option
        MinimumAmountCurrency: string option
    }
    with
        static member Create(?firstTimeTransaction: bool, ?minimumAmount: int, ?minimumAmountCurrency: string) =
            {
                FirstTimeTransaction = firstTimeTransaction
                MinimumAmount = minimumAmount
                MinimumAmountCurrency = minimumAmountCurrency
            }

    type PromotionCodes'CreateOptions = {
        Active: bool option
        Code: string option
        Coupon: string
        Customer: string option
        Expand: string list option
        ExpiresAt: DateTime option
        MaxRedemptions: int option
        Metadata: Map<string, string> option
        Restrictions: PromotionCodes'CreateRestrictions option
    }
    with
        static member Create(coupon: string, ?active: bool, ?code: string, ?customer: string, ?expand: string list, ?expiresAt: DateTime, ?maxRedemptions: int, ?metadata: Map<string, string>, ?restrictions: PromotionCodes'CreateRestrictions) =
            {
                Active = active
                Code = code
                Coupon = coupon
                Customer = customer
                Expand = expand
                ExpiresAt = expiresAt
                MaxRedemptions = maxRedemptions
                Metadata = metadata
                Restrictions = restrictions
            }

    type PromotionCodes'UpdateOptions = {
        Active: bool option
        Expand: string list option
        Metadata: Map<string, string> option
    }
    with
        static member Create(?active: bool, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Active = active
                Expand = expand
                Metadata = metadata
            }

    type RadarValueListItems'CreateOptions = {
        Expand: string list option
        Value: string
        ValueList: string
    }
    with
        static member Create(value: string, valueList: string, ?expand: string list) =
            {
                Expand = expand
                Value = value
                ValueList = valueList
            }

    type RadarValueLists'CreateItemType =
        | CardBin
        | CardFingerprint
        | CaseSensitiveString
        | Country
        | Email
        | IpAddress
        | String

    type RadarValueLists'CreateOptions = {
        Alias: string
        Expand: string list option
        ItemType: RadarValueLists'CreateItemType option
        Metadata: Map<string, string> option
        Name: string
    }
    with
        static member Create(alias: string, name: string, ?expand: string list, ?itemType: RadarValueLists'CreateItemType, ?metadata: Map<string, string>) =
            {
                Alias = alias
                Expand = expand
                ItemType = itemType
                Metadata = metadata
                Name = name
            }

    type RadarValueLists'UpdateOptions = {
        Alias: string option
        Expand: string list option
        Metadata: Map<string, string> option
        Name: string option
    }
    with
        static member Create(?alias: string, ?expand: string list, ?metadata: Map<string, string>, ?name: string) =
            {
                Alias = alias
                Expand = expand
                Metadata = metadata
                Name = name
            }

    type Recipients'CreateOptions = {
        BankAccount: string option
        Card: string option
        Description: string option
        Email: string option
        Expand: string list option
        Metadata: Map<string, string> option
        Name: string
        TaxId: string option
        Type: string
    }
    with
        static member Create(name: string, ``type``: string, ?bankAccount: string, ?card: string, ?description: string, ?email: string, ?expand: string list, ?metadata: Map<string, string>, ?taxId: string) =
            {
                BankAccount = bankAccount
                Card = card
                Description = description
                Email = email
                Expand = expand
                Metadata = metadata
                Name = name
                TaxId = taxId
                Type = ``type``
            }

    type Recipients'UpdateOptions = {
        BankAccount: string option
        Card: string option
        DefaultCard: string option
        Description: string option
        Email: string option
        Expand: string list option
        Metadata: Map<string, string> option
        Name: string option
        TaxId: string option
    }
    with
        static member Create(?bankAccount: string, ?card: string, ?defaultCard: string, ?description: string, ?email: string, ?expand: string list, ?metadata: Map<string, string>, ?name: string, ?taxId: string) =
            {
                BankAccount = bankAccount
                Card = card
                DefaultCard = defaultCard
                Description = description
                Email = email
                Expand = expand
                Metadata = metadata
                Name = name
                TaxId = taxId
            }

    type Refunds'CreateReason =
        | Duplicate
        | Fraudulent
        | RequestedByCustomer

    type Refunds'CreateOptions = {
        Amount: int option
        Charge: string option
        Expand: string list option
        Metadata: Map<string, string> option
        PaymentIntent: string option
        Reason: Refunds'CreateReason option
        RefundApplicationFee: bool option
        ReverseTransfer: bool option
    }
    with
        static member Create(?amount: int, ?charge: string, ?expand: string list, ?metadata: Map<string, string>, ?paymentIntent: string, ?reason: Refunds'CreateReason, ?refundApplicationFee: bool, ?reverseTransfer: bool) =
            {
                Amount = amount
                Charge = charge
                Expand = expand
                Metadata = metadata
                PaymentIntent = paymentIntent
                Reason = reason
                RefundApplicationFee = refundApplicationFee
                ReverseTransfer = reverseTransfer
            }

    type Refunds'UpdateOptions = {
        Expand: string list option
        Metadata: Map<string, string> option
    }
    with
        static member Create(?expand: string list, ?metadata: Map<string, string>) =
            {
                Expand = expand
                Metadata = metadata
            }

    type ReportingReportRuns'CreateParametersReportingCategory =
        | Advance
        | AdvanceFunding
        | AnticipationRepayment
        | Charge
        | ChargeFailure
        | ConnectCollectionTransfer
        | ConnectReservedFunds
        | Contribution
        | Dispute
        | DisputeReversal
        | Fee
        | FinancingPaydown
        | FinancingPaydownReversal
        | FinancingPayout
        | FinancingPayoutReversal
        | IssuingAuthorizationHold
        | IssuingAuthorizationRelease
        | IssuingDispute
        | IssuingTransaction
        | NetworkCost
        | OtherAdjustment
        | PartialCaptureReversal
        | Payout
        | PayoutReversal
        | PlatformEarning
        | PlatformEarningRefund
        | Refund
        | RefundFailure
        | RiskReservedFunds
        | Tax
        | Topup
        | TopupReversal
        | Transfer
        | TransferReversal

    type ReportingReportRuns'CreateParametersTimezone =
        | [<JsonUnionCase("Africa/Abidjan")>] AfricaAbidjan
        | [<JsonUnionCase("Africa/Accra")>] AfricaAccra
        | [<JsonUnionCase("Africa/Addis_Ababa")>] AfricaAddisAbaba
        | [<JsonUnionCase("Africa/Algiers")>] AfricaAlgiers
        | [<JsonUnionCase("Africa/Asmara")>] AfricaAsmara
        | [<JsonUnionCase("Africa/Asmera")>] AfricaAsmera
        | [<JsonUnionCase("Africa/Bamako")>] AfricaBamako
        | [<JsonUnionCase("Africa/Bangui")>] AfricaBangui
        | [<JsonUnionCase("Africa/Banjul")>] AfricaBanjul
        | [<JsonUnionCase("Africa/Bissau")>] AfricaBissau
        | [<JsonUnionCase("Africa/Blantyre")>] AfricaBlantyre
        | [<JsonUnionCase("Africa/Brazzaville")>] AfricaBrazzaville
        | [<JsonUnionCase("Africa/Bujumbura")>] AfricaBujumbura
        | [<JsonUnionCase("Africa/Cairo")>] AfricaCairo
        | [<JsonUnionCase("Africa/Casablanca")>] AfricaCasablanca
        | [<JsonUnionCase("Africa/Ceuta")>] AfricaCeuta
        | [<JsonUnionCase("Africa/Conakry")>] AfricaConakry
        | [<JsonUnionCase("Africa/Dakar")>] AfricaDakar
        | [<JsonUnionCase("Africa/Dar_es_Salaam")>] AfricaDarEsSalaam
        | [<JsonUnionCase("Africa/Djibouti")>] AfricaDjibouti
        | [<JsonUnionCase("Africa/Douala")>] AfricaDouala
        | [<JsonUnionCase("Africa/El_Aaiun")>] AfricaElAaiun
        | [<JsonUnionCase("Africa/Freetown")>] AfricaFreetown
        | [<JsonUnionCase("Africa/Gaborone")>] AfricaGaborone
        | [<JsonUnionCase("Africa/Harare")>] AfricaHarare
        | [<JsonUnionCase("Africa/Johannesburg")>] AfricaJohannesburg
        | [<JsonUnionCase("Africa/Juba")>] AfricaJuba
        | [<JsonUnionCase("Africa/Kampala")>] AfricaKampala
        | [<JsonUnionCase("Africa/Khartoum")>] AfricaKhartoum
        | [<JsonUnionCase("Africa/Kigali")>] AfricaKigali
        | [<JsonUnionCase("Africa/Kinshasa")>] AfricaKinshasa
        | [<JsonUnionCase("Africa/Lagos")>] AfricaLagos
        | [<JsonUnionCase("Africa/Libreville")>] AfricaLibreville
        | [<JsonUnionCase("Africa/Lome")>] AfricaLome
        | [<JsonUnionCase("Africa/Luanda")>] AfricaLuanda
        | [<JsonUnionCase("Africa/Lubumbashi")>] AfricaLubumbashi
        | [<JsonUnionCase("Africa/Lusaka")>] AfricaLusaka
        | [<JsonUnionCase("Africa/Malabo")>] AfricaMalabo
        | [<JsonUnionCase("Africa/Maputo")>] AfricaMaputo
        | [<JsonUnionCase("Africa/Maseru")>] AfricaMaseru
        | [<JsonUnionCase("Africa/Mbabane")>] AfricaMbabane
        | [<JsonUnionCase("Africa/Mogadishu")>] AfricaMogadishu
        | [<JsonUnionCase("Africa/Monrovia")>] AfricaMonrovia
        | [<JsonUnionCase("Africa/Nairobi")>] AfricaNairobi
        | [<JsonUnionCase("Africa/Ndjamena")>] AfricaNdjamena
        | [<JsonUnionCase("Africa/Niamey")>] AfricaNiamey
        | [<JsonUnionCase("Africa/Nouakchott")>] AfricaNouakchott
        | [<JsonUnionCase("Africa/Ouagadougou")>] AfricaOuagadougou
        | [<JsonUnionCase("Africa/Porto-Novo")>] AfricaPortoNovo
        | [<JsonUnionCase("Africa/Sao_Tome")>] AfricaSaoTome
        | [<JsonUnionCase("Africa/Timbuktu")>] AfricaTimbuktu
        | [<JsonUnionCase("Africa/Tripoli")>] AfricaTripoli
        | [<JsonUnionCase("Africa/Tunis")>] AfricaTunis
        | [<JsonUnionCase("Africa/Windhoek")>] AfricaWindhoek
        | [<JsonUnionCase("America/Adak")>] AmericaAdak
        | [<JsonUnionCase("America/Anchorage")>] AmericaAnchorage
        | [<JsonUnionCase("America/Anguilla")>] AmericaAnguilla
        | [<JsonUnionCase("America/Antigua")>] AmericaAntigua
        | [<JsonUnionCase("America/Araguaina")>] AmericaAraguaina
        | [<JsonUnionCase("America/Argentina/Buenos_Aires")>] AmericaArgentinaBuenosAires
        | [<JsonUnionCase("America/Argentina/Catamarca")>] AmericaArgentinaCatamarca
        | [<JsonUnionCase("America/Argentina/ComodRivadavia")>] AmericaArgentinaComodRivadavia
        | [<JsonUnionCase("America/Argentina/Cordoba")>] AmericaArgentinaCordoba
        | [<JsonUnionCase("America/Argentina/Jujuy")>] AmericaArgentinaJujuy
        | [<JsonUnionCase("America/Argentina/La_Rioja")>] AmericaArgentinaLaRioja
        | [<JsonUnionCase("America/Argentina/Mendoza")>] AmericaArgentinaMendoza
        | [<JsonUnionCase("America/Argentina/Rio_Gallegos")>] AmericaArgentinaRioGallegos
        | [<JsonUnionCase("America/Argentina/Salta")>] AmericaArgentinaSalta
        | [<JsonUnionCase("America/Argentina/San_Juan")>] AmericaArgentinaSanJuan
        | [<JsonUnionCase("America/Argentina/San_Luis")>] AmericaArgentinaSanLuis
        | [<JsonUnionCase("America/Argentina/Tucuman")>] AmericaArgentinaTucuman
        | [<JsonUnionCase("America/Argentina/Ushuaia")>] AmericaArgentinaUshuaia
        | [<JsonUnionCase("America/Aruba")>] AmericaAruba
        | [<JsonUnionCase("America/Asuncion")>] AmericaAsuncion
        | [<JsonUnionCase("America/Atikokan")>] AmericaAtikokan
        | [<JsonUnionCase("America/Atka")>] AmericaAtka
        | [<JsonUnionCase("America/Bahia")>] AmericaBahia
        | [<JsonUnionCase("America/Bahia_Banderas")>] AmericaBahiaBanderas
        | [<JsonUnionCase("America/Barbados")>] AmericaBarbados
        | [<JsonUnionCase("America/Belem")>] AmericaBelem
        | [<JsonUnionCase("America/Belize")>] AmericaBelize
        | [<JsonUnionCase("America/Blanc-Sablon")>] AmericaBlancSablon
        | [<JsonUnionCase("America/Boa_Vista")>] AmericaBoaVista
        | [<JsonUnionCase("America/Bogota")>] AmericaBogota
        | [<JsonUnionCase("America/Boise")>] AmericaBoise
        | [<JsonUnionCase("America/Buenos_Aires")>] AmericaBuenosAires
        | [<JsonUnionCase("America/Cambridge_Bay")>] AmericaCambridgeBay
        | [<JsonUnionCase("America/Campo_Grande")>] AmericaCampoGrande
        | [<JsonUnionCase("America/Cancun")>] AmericaCancun
        | [<JsonUnionCase("America/Caracas")>] AmericaCaracas
        | [<JsonUnionCase("America/Catamarca")>] AmericaCatamarca
        | [<JsonUnionCase("America/Cayenne")>] AmericaCayenne
        | [<JsonUnionCase("America/Cayman")>] AmericaCayman
        | [<JsonUnionCase("America/Chicago")>] AmericaChicago
        | [<JsonUnionCase("America/Chihuahua")>] AmericaChihuahua
        | [<JsonUnionCase("America/Coral_Harbour")>] AmericaCoralHarbour
        | [<JsonUnionCase("America/Cordoba")>] AmericaCordoba
        | [<JsonUnionCase("America/Costa_Rica")>] AmericaCostaRica
        | [<JsonUnionCase("America/Creston")>] AmericaCreston
        | [<JsonUnionCase("America/Cuiaba")>] AmericaCuiaba
        | [<JsonUnionCase("America/Curacao")>] AmericaCuracao
        | [<JsonUnionCase("America/Danmarkshavn")>] AmericaDanmarkshavn
        | [<JsonUnionCase("America/Dawson")>] AmericaDawson
        | [<JsonUnionCase("America/Dawson_Creek")>] AmericaDawsonCreek
        | [<JsonUnionCase("America/Denver")>] AmericaDenver
        | [<JsonUnionCase("America/Detroit")>] AmericaDetroit
        | [<JsonUnionCase("America/Dominica")>] AmericaDominica
        | [<JsonUnionCase("America/Edmonton")>] AmericaEdmonton
        | [<JsonUnionCase("America/Eirunepe")>] AmericaEirunepe
        | [<JsonUnionCase("America/El_Salvador")>] AmericaElSalvador
        | [<JsonUnionCase("America/Ensenada")>] AmericaEnsenada
        | [<JsonUnionCase("America/Fort_Nelson")>] AmericaFortNelson
        | [<JsonUnionCase("America/Fort_Wayne")>] AmericaFortWayne
        | [<JsonUnionCase("America/Fortaleza")>] AmericaFortaleza
        | [<JsonUnionCase("America/Glace_Bay")>] AmericaGlaceBay
        | [<JsonUnionCase("America/Godthab")>] AmericaGodthab
        | [<JsonUnionCase("America/Goose_Bay")>] AmericaGooseBay
        | [<JsonUnionCase("America/Grand_Turk")>] AmericaGrandTurk
        | [<JsonUnionCase("America/Grenada")>] AmericaGrenada
        | [<JsonUnionCase("America/Guadeloupe")>] AmericaGuadeloupe
        | [<JsonUnionCase("America/Guatemala")>] AmericaGuatemala
        | [<JsonUnionCase("America/Guayaquil")>] AmericaGuayaquil
        | [<JsonUnionCase("America/Guyana")>] AmericaGuyana
        | [<JsonUnionCase("America/Halifax")>] AmericaHalifax
        | [<JsonUnionCase("America/Havana")>] AmericaHavana
        | [<JsonUnionCase("America/Hermosillo")>] AmericaHermosillo
        | [<JsonUnionCase("America/Indiana/Indianapolis")>] AmericaIndianaIndianapolis
        | [<JsonUnionCase("America/Indiana/Knox")>] AmericaIndianaKnox
        | [<JsonUnionCase("America/Indiana/Marengo")>] AmericaIndianaMarengo
        | [<JsonUnionCase("America/Indiana/Petersburg")>] AmericaIndianaPetersburg
        | [<JsonUnionCase("America/Indiana/Tell_City")>] AmericaIndianaTellCity
        | [<JsonUnionCase("America/Indiana/Vevay")>] AmericaIndianaVevay
        | [<JsonUnionCase("America/Indiana/Vincennes")>] AmericaIndianaVincennes
        | [<JsonUnionCase("America/Indiana/Winamac")>] AmericaIndianaWinamac
        | [<JsonUnionCase("America/Indianapolis")>] AmericaIndianapolis
        | [<JsonUnionCase("America/Inuvik")>] AmericaInuvik
        | [<JsonUnionCase("America/Iqaluit")>] AmericaIqaluit
        | [<JsonUnionCase("America/Jamaica")>] AmericaJamaica
        | [<JsonUnionCase("America/Jujuy")>] AmericaJujuy
        | [<JsonUnionCase("America/Juneau")>] AmericaJuneau
        | [<JsonUnionCase("America/Kentucky/Louisville")>] AmericaKentuckyLouisville
        | [<JsonUnionCase("America/Kentucky/Monticello")>] AmericaKentuckyMonticello
        | [<JsonUnionCase("America/Knox_IN")>] AmericaKnoxIN
        | [<JsonUnionCase("America/Kralendijk")>] AmericaKralendijk
        | [<JsonUnionCase("America/La_Paz")>] AmericaLaPaz
        | [<JsonUnionCase("America/Lima")>] AmericaLima
        | [<JsonUnionCase("America/Los_Angeles")>] AmericaLosAngeles
        | [<JsonUnionCase("America/Louisville")>] AmericaLouisville
        | [<JsonUnionCase("America/Lower_Princes")>] AmericaLowerPrinces
        | [<JsonUnionCase("America/Maceio")>] AmericaMaceio
        | [<JsonUnionCase("America/Managua")>] AmericaManagua
        | [<JsonUnionCase("America/Manaus")>] AmericaManaus
        | [<JsonUnionCase("America/Marigot")>] AmericaMarigot
        | [<JsonUnionCase("America/Martinique")>] AmericaMartinique
        | [<JsonUnionCase("America/Matamoros")>] AmericaMatamoros
        | [<JsonUnionCase("America/Mazatlan")>] AmericaMazatlan
        | [<JsonUnionCase("America/Mendoza")>] AmericaMendoza
        | [<JsonUnionCase("America/Menominee")>] AmericaMenominee
        | [<JsonUnionCase("America/Merida")>] AmericaMerida
        | [<JsonUnionCase("America/Metlakatla")>] AmericaMetlakatla
        | [<JsonUnionCase("America/Mexico_City")>] AmericaMexicoCity
        | [<JsonUnionCase("America/Miquelon")>] AmericaMiquelon
        | [<JsonUnionCase("America/Moncton")>] AmericaMoncton
        | [<JsonUnionCase("America/Monterrey")>] AmericaMonterrey
        | [<JsonUnionCase("America/Montevideo")>] AmericaMontevideo
        | [<JsonUnionCase("America/Montreal")>] AmericaMontreal
        | [<JsonUnionCase("America/Montserrat")>] AmericaMontserrat
        | [<JsonUnionCase("America/Nassau")>] AmericaNassau
        | [<JsonUnionCase("America/New_York")>] AmericaNewYork
        | [<JsonUnionCase("America/Nipigon")>] AmericaNipigon
        | [<JsonUnionCase("America/Nome")>] AmericaNome
        | [<JsonUnionCase("America/Noronha")>] AmericaNoronha
        | [<JsonUnionCase("America/North_Dakota/Beulah")>] AmericaNorthDakotaBeulah
        | [<JsonUnionCase("America/North_Dakota/Center")>] AmericaNorthDakotaCenter
        | [<JsonUnionCase("America/North_Dakota/New_Salem")>] AmericaNorthDakotaNewSalem
        | [<JsonUnionCase("America/Ojinaga")>] AmericaOjinaga
        | [<JsonUnionCase("America/Panama")>] AmericaPanama
        | [<JsonUnionCase("America/Pangnirtung")>] AmericaPangnirtung
        | [<JsonUnionCase("America/Paramaribo")>] AmericaParamaribo
        | [<JsonUnionCase("America/Phoenix")>] AmericaPhoenix
        | [<JsonUnionCase("America/Port-au-Prince")>] AmericaPortauPrince
        | [<JsonUnionCase("America/Port_of_Spain")>] AmericaPortOfSpain
        | [<JsonUnionCase("America/Porto_Acre")>] AmericaPortoAcre
        | [<JsonUnionCase("America/Porto_Velho")>] AmericaPortoVelho
        | [<JsonUnionCase("America/Puerto_Rico")>] AmericaPuertoRico
        | [<JsonUnionCase("America/Punta_Arenas")>] AmericaPuntaArenas
        | [<JsonUnionCase("America/Rainy_River")>] AmericaRainyRiver
        | [<JsonUnionCase("America/Rankin_Inlet")>] AmericaRankinInlet
        | [<JsonUnionCase("America/Recife")>] AmericaRecife
        | [<JsonUnionCase("America/Regina")>] AmericaRegina
        | [<JsonUnionCase("America/Resolute")>] AmericaResolute
        | [<JsonUnionCase("America/Rio_Branco")>] AmericaRioBranco
        | [<JsonUnionCase("America/Rosario")>] AmericaRosario
        | [<JsonUnionCase("America/Santa_Isabel")>] AmericaSantaIsabel
        | [<JsonUnionCase("America/Santarem")>] AmericaSantarem
        | [<JsonUnionCase("America/Santiago")>] AmericaSantiago
        | [<JsonUnionCase("America/Santo_Domingo")>] AmericaSantoDomingo
        | [<JsonUnionCase("America/Sao_Paulo")>] AmericaSaoPaulo
        | [<JsonUnionCase("America/Scoresbysund")>] AmericaScoresbysund
        | [<JsonUnionCase("America/Shiprock")>] AmericaShiprock
        | [<JsonUnionCase("America/Sitka")>] AmericaSitka
        | [<JsonUnionCase("America/St_Barthelemy")>] AmericaStBarthelemy
        | [<JsonUnionCase("America/St_Johns")>] AmericaStJohns
        | [<JsonUnionCase("America/St_Kitts")>] AmericaStKitts
        | [<JsonUnionCase("America/St_Lucia")>] AmericaStLucia
        | [<JsonUnionCase("America/St_Thomas")>] AmericaStThomas
        | [<JsonUnionCase("America/St_Vincent")>] AmericaStVincent
        | [<JsonUnionCase("America/Swift_Current")>] AmericaSwiftCurrent
        | [<JsonUnionCase("America/Tegucigalpa")>] AmericaTegucigalpa
        | [<JsonUnionCase("America/Thule")>] AmericaThule
        | [<JsonUnionCase("America/Thunder_Bay")>] AmericaThunderBay
        | [<JsonUnionCase("America/Tijuana")>] AmericaTijuana
        | [<JsonUnionCase("America/Toronto")>] AmericaToronto
        | [<JsonUnionCase("America/Tortola")>] AmericaTortola
        | [<JsonUnionCase("America/Vancouver")>] AmericaVancouver
        | [<JsonUnionCase("America/Virgin")>] AmericaVirgin
        | [<JsonUnionCase("America/Whitehorse")>] AmericaWhitehorse
        | [<JsonUnionCase("America/Winnipeg")>] AmericaWinnipeg
        | [<JsonUnionCase("America/Yakutat")>] AmericaYakutat
        | [<JsonUnionCase("America/Yellowknife")>] AmericaYellowknife
        | [<JsonUnionCase("Antarctica/Casey")>] AntarcticaCasey
        | [<JsonUnionCase("Antarctica/Davis")>] AntarcticaDavis
        | [<JsonUnionCase("Antarctica/DumontDUrville")>] AntarcticaDumontDUrville
        | [<JsonUnionCase("Antarctica/Macquarie")>] AntarcticaMacquarie
        | [<JsonUnionCase("Antarctica/Mawson")>] AntarcticaMawson
        | [<JsonUnionCase("Antarctica/McMurdo")>] AntarcticaMcMurdo
        | [<JsonUnionCase("Antarctica/Palmer")>] AntarcticaPalmer
        | [<JsonUnionCase("Antarctica/Rothera")>] AntarcticaRothera
        | [<JsonUnionCase("Antarctica/South_Pole")>] AntarcticaSouthPole
        | [<JsonUnionCase("Antarctica/Syowa")>] AntarcticaSyowa
        | [<JsonUnionCase("Antarctica/Troll")>] AntarcticaTroll
        | [<JsonUnionCase("Antarctica/Vostok")>] AntarcticaVostok
        | [<JsonUnionCase("Arctic/Longyearbyen")>] ArcticLongyearbyen
        | [<JsonUnionCase("Asia/Aden")>] AsiaAden
        | [<JsonUnionCase("Asia/Almaty")>] AsiaAlmaty
        | [<JsonUnionCase("Asia/Amman")>] AsiaAmman
        | [<JsonUnionCase("Asia/Anadyr")>] AsiaAnadyr
        | [<JsonUnionCase("Asia/Aqtau")>] AsiaAqtau
        | [<JsonUnionCase("Asia/Aqtobe")>] AsiaAqtobe
        | [<JsonUnionCase("Asia/Ashgabat")>] AsiaAshgabat
        | [<JsonUnionCase("Asia/Ashkhabad")>] AsiaAshkhabad
        | [<JsonUnionCase("Asia/Atyrau")>] AsiaAtyrau
        | [<JsonUnionCase("Asia/Baghdad")>] AsiaBaghdad
        | [<JsonUnionCase("Asia/Bahrain")>] AsiaBahrain
        | [<JsonUnionCase("Asia/Baku")>] AsiaBaku
        | [<JsonUnionCase("Asia/Bangkok")>] AsiaBangkok
        | [<JsonUnionCase("Asia/Barnaul")>] AsiaBarnaul
        | [<JsonUnionCase("Asia/Beirut")>] AsiaBeirut
        | [<JsonUnionCase("Asia/Bishkek")>] AsiaBishkek
        | [<JsonUnionCase("Asia/Brunei")>] AsiaBrunei
        | [<JsonUnionCase("Asia/Calcutta")>] AsiaCalcutta
        | [<JsonUnionCase("Asia/Chita")>] AsiaChita
        | [<JsonUnionCase("Asia/Choibalsan")>] AsiaChoibalsan
        | [<JsonUnionCase("Asia/Chongqing")>] AsiaChongqing
        | [<JsonUnionCase("Asia/Chungking")>] AsiaChungking
        | [<JsonUnionCase("Asia/Colombo")>] AsiaColombo
        | [<JsonUnionCase("Asia/Dacca")>] AsiaDacca
        | [<JsonUnionCase("Asia/Damascus")>] AsiaDamascus
        | [<JsonUnionCase("Asia/Dhaka")>] AsiaDhaka
        | [<JsonUnionCase("Asia/Dili")>] AsiaDili
        | [<JsonUnionCase("Asia/Dubai")>] AsiaDubai
        | [<JsonUnionCase("Asia/Dushanbe")>] AsiaDushanbe
        | [<JsonUnionCase("Asia/Famagusta")>] AsiaFamagusta
        | [<JsonUnionCase("Asia/Gaza")>] AsiaGaza
        | [<JsonUnionCase("Asia/Harbin")>] AsiaHarbin
        | [<JsonUnionCase("Asia/Hebron")>] AsiaHebron
        | [<JsonUnionCase("Asia/Ho_Chi_Minh")>] AsiaHoChiMinh
        | [<JsonUnionCase("Asia/Hong_Kong")>] AsiaHongKong
        | [<JsonUnionCase("Asia/Hovd")>] AsiaHovd
        | [<JsonUnionCase("Asia/Irkutsk")>] AsiaIrkutsk
        | [<JsonUnionCase("Asia/Istanbul")>] AsiaIstanbul
        | [<JsonUnionCase("Asia/Jakarta")>] AsiaJakarta
        | [<JsonUnionCase("Asia/Jayapura")>] AsiaJayapura
        | [<JsonUnionCase("Asia/Jerusalem")>] AsiaJerusalem
        | [<JsonUnionCase("Asia/Kabul")>] AsiaKabul
        | [<JsonUnionCase("Asia/Kamchatka")>] AsiaKamchatka
        | [<JsonUnionCase("Asia/Karachi")>] AsiaKarachi
        | [<JsonUnionCase("Asia/Kashgar")>] AsiaKashgar
        | [<JsonUnionCase("Asia/Kathmandu")>] AsiaKathmandu
        | [<JsonUnionCase("Asia/Katmandu")>] AsiaKatmandu
        | [<JsonUnionCase("Asia/Khandyga")>] AsiaKhandyga
        | [<JsonUnionCase("Asia/Kolkata")>] AsiaKolkata
        | [<JsonUnionCase("Asia/Krasnoyarsk")>] AsiaKrasnoyarsk
        | [<JsonUnionCase("Asia/Kuala_Lumpur")>] AsiaKualaLumpur
        | [<JsonUnionCase("Asia/Kuching")>] AsiaKuching
        | [<JsonUnionCase("Asia/Kuwait")>] AsiaKuwait
        | [<JsonUnionCase("Asia/Macao")>] AsiaMacao
        | [<JsonUnionCase("Asia/Macau")>] AsiaMacau
        | [<JsonUnionCase("Asia/Magadan")>] AsiaMagadan
        | [<JsonUnionCase("Asia/Makassar")>] AsiaMakassar
        | [<JsonUnionCase("Asia/Manila")>] AsiaManila
        | [<JsonUnionCase("Asia/Muscat")>] AsiaMuscat
        | [<JsonUnionCase("Asia/Nicosia")>] AsiaNicosia
        | [<JsonUnionCase("Asia/Novokuznetsk")>] AsiaNovokuznetsk
        | [<JsonUnionCase("Asia/Novosibirsk")>] AsiaNovosibirsk
        | [<JsonUnionCase("Asia/Omsk")>] AsiaOmsk
        | [<JsonUnionCase("Asia/Oral")>] AsiaOral
        | [<JsonUnionCase("Asia/Phnom_Penh")>] AsiaPhnomPenh
        | [<JsonUnionCase("Asia/Pontianak")>] AsiaPontianak
        | [<JsonUnionCase("Asia/Pyongyang")>] AsiaPyongyang
        | [<JsonUnionCase("Asia/Qatar")>] AsiaQatar
        | [<JsonUnionCase("Asia/Qostanay")>] AsiaQostanay
        | [<JsonUnionCase("Asia/Qyzylorda")>] AsiaQyzylorda
        | [<JsonUnionCase("Asia/Rangoon")>] AsiaRangoon
        | [<JsonUnionCase("Asia/Riyadh")>] AsiaRiyadh
        | [<JsonUnionCase("Asia/Saigon")>] AsiaSaigon
        | [<JsonUnionCase("Asia/Sakhalin")>] AsiaSakhalin
        | [<JsonUnionCase("Asia/Samarkand")>] AsiaSamarkand
        | [<JsonUnionCase("Asia/Seoul")>] AsiaSeoul
        | [<JsonUnionCase("Asia/Shanghai")>] AsiaShanghai
        | [<JsonUnionCase("Asia/Singapore")>] AsiaSingapore
        | [<JsonUnionCase("Asia/Srednekolymsk")>] AsiaSrednekolymsk
        | [<JsonUnionCase("Asia/Taipei")>] AsiaTaipei
        | [<JsonUnionCase("Asia/Tashkent")>] AsiaTashkent
        | [<JsonUnionCase("Asia/Tbilisi")>] AsiaTbilisi
        | [<JsonUnionCase("Asia/Tehran")>] AsiaTehran
        | [<JsonUnionCase("Asia/Tel_Aviv")>] AsiaTelAviv
        | [<JsonUnionCase("Asia/Thimbu")>] AsiaThimbu
        | [<JsonUnionCase("Asia/Thimphu")>] AsiaThimphu
        | [<JsonUnionCase("Asia/Tokyo")>] AsiaTokyo
        | [<JsonUnionCase("Asia/Tomsk")>] AsiaTomsk
        | [<JsonUnionCase("Asia/Ujung_Pandang")>] AsiaUjungPandang
        | [<JsonUnionCase("Asia/Ulaanbaatar")>] AsiaUlaanbaatar
        | [<JsonUnionCase("Asia/Ulan_Bator")>] AsiaUlanBator
        | [<JsonUnionCase("Asia/Urumqi")>] AsiaUrumqi
        | [<JsonUnionCase("Asia/Ust-Nera")>] AsiaUstNera
        | [<JsonUnionCase("Asia/Vientiane")>] AsiaVientiane
        | [<JsonUnionCase("Asia/Vladivostok")>] AsiaVladivostok
        | [<JsonUnionCase("Asia/Yakutsk")>] AsiaYakutsk
        | [<JsonUnionCase("Asia/Yangon")>] AsiaYangon
        | [<JsonUnionCase("Asia/Yekaterinburg")>] AsiaYekaterinburg
        | [<JsonUnionCase("Asia/Yerevan")>] AsiaYerevan
        | [<JsonUnionCase("Atlantic/Azores")>] AtlanticAzores
        | [<JsonUnionCase("Atlantic/Bermuda")>] AtlanticBermuda
        | [<JsonUnionCase("Atlantic/Canary")>] AtlanticCanary
        | [<JsonUnionCase("Atlantic/Cape_Verde")>] AtlanticCapeVerde
        | [<JsonUnionCase("Atlantic/Faeroe")>] AtlanticFaeroe
        | [<JsonUnionCase("Atlantic/Faroe")>] AtlanticFaroe
        | [<JsonUnionCase("Atlantic/Jan_Mayen")>] AtlanticJanMayen
        | [<JsonUnionCase("Atlantic/Madeira")>] AtlanticMadeira
        | [<JsonUnionCase("Atlantic/Reykjavik")>] AtlanticReykjavik
        | [<JsonUnionCase("Atlantic/South_Georgia")>] AtlanticSouthGeorgia
        | [<JsonUnionCase("Atlantic/St_Helena")>] AtlanticStHelena
        | [<JsonUnionCase("Atlantic/Stanley")>] AtlanticStanley
        | [<JsonUnionCase("Australia/ACT")>] AustraliaACT
        | [<JsonUnionCase("Australia/Adelaide")>] AustraliaAdelaide
        | [<JsonUnionCase("Australia/Brisbane")>] AustraliaBrisbane
        | [<JsonUnionCase("Australia/Broken_Hill")>] AustraliaBrokenHill
        | [<JsonUnionCase("Australia/Canberra")>] AustraliaCanberra
        | [<JsonUnionCase("Australia/Currie")>] AustraliaCurrie
        | [<JsonUnionCase("Australia/Darwin")>] AustraliaDarwin
        | [<JsonUnionCase("Australia/Eucla")>] AustraliaEucla
        | [<JsonUnionCase("Australia/Hobart")>] AustraliaHobart
        | [<JsonUnionCase("Australia/LHI")>] AustraliaLHI
        | [<JsonUnionCase("Australia/Lindeman")>] AustraliaLindeman
        | [<JsonUnionCase("Australia/Lord_Howe")>] AustraliaLordHowe
        | [<JsonUnionCase("Australia/Melbourne")>] AustraliaMelbourne
        | [<JsonUnionCase("Australia/NSW")>] AustraliaNSW
        | [<JsonUnionCase("Australia/North")>] AustraliaNorth
        | [<JsonUnionCase("Australia/Perth")>] AustraliaPerth
        | [<JsonUnionCase("Australia/Queensland")>] AustraliaQueensland
        | [<JsonUnionCase("Australia/South")>] AustraliaSouth
        | [<JsonUnionCase("Australia/Sydney")>] AustraliaSydney
        | [<JsonUnionCase("Australia/Tasmania")>] AustraliaTasmania
        | [<JsonUnionCase("Australia/Victoria")>] AustraliaVictoria
        | [<JsonUnionCase("Australia/West")>] AustraliaWest
        | [<JsonUnionCase("Australia/Yancowinna")>] AustraliaYancowinna
        | [<JsonUnionCase("Brazil/Acre")>] BrazilAcre
        | [<JsonUnionCase("Brazil/DeNoronha")>] BrazilDeNoronha
        | [<JsonUnionCase("Brazil/East")>] BrazilEast
        | [<JsonUnionCase("Brazil/West")>] BrazilWest
        | [<JsonUnionCase("CET")>] CET
        | [<JsonUnionCase("CST6CDT")>] CST6CDT
        | [<JsonUnionCase("Canada/Atlantic")>] CanadaAtlantic
        | [<JsonUnionCase("Canada/Central")>] CanadaCentral
        | [<JsonUnionCase("Canada/Eastern")>] CanadaEastern
        | [<JsonUnionCase("Canada/Mountain")>] CanadaMountain
        | [<JsonUnionCase("Canada/Newfoundland")>] CanadaNewfoundland
        | [<JsonUnionCase("Canada/Pacific")>] CanadaPacific
        | [<JsonUnionCase("Canada/Saskatchewan")>] CanadaSaskatchewan
        | [<JsonUnionCase("Canada/Yukon")>] CanadaYukon
        | [<JsonUnionCase("Chile/Continental")>] ChileContinental
        | [<JsonUnionCase("Chile/EasterIsland")>] ChileEasterIsland
        | [<JsonUnionCase("Cuba")>] Cuba
        | [<JsonUnionCase("EET")>] EET
        | [<JsonUnionCase("EST")>] EST
        | [<JsonUnionCase("EST5EDT")>] EST5EDT
        | [<JsonUnionCase("Egypt")>] Egypt
        | [<JsonUnionCase("Eire")>] Eire
        | [<JsonUnionCase("Etc/GMT")>] EtcGMT
        | [<JsonUnionCase("Etc/GMT+0")>] EtcGMTplus0
        | [<JsonUnionCase("Etc/GMT+1")>] EtcGMTplus1
        | [<JsonUnionCase("Etc/GMT+10")>] EtcGMTplus10
        | [<JsonUnionCase("Etc/GMT+11")>] EtcGMTplus11
        | [<JsonUnionCase("Etc/GMT+12")>] EtcGMTplus12
        | [<JsonUnionCase("Etc/GMT+2")>] EtcGMTplus2
        | [<JsonUnionCase("Etc/GMT+3")>] EtcGMTplus3
        | [<JsonUnionCase("Etc/GMT+4")>] EtcGMTplus4
        | [<JsonUnionCase("Etc/GMT+5")>] EtcGMTplus5
        | [<JsonUnionCase("Etc/GMT+6")>] EtcGMTplus6
        | [<JsonUnionCase("Etc/GMT+7")>] EtcGMTplus7
        | [<JsonUnionCase("Etc/GMT+8")>] EtcGMTplus8
        | [<JsonUnionCase("Etc/GMT+9")>] EtcGMTplus9
        | [<JsonUnionCase("Etc/GMT-0")>] EtcGMTminus0
        | [<JsonUnionCase("Etc/GMT-1")>] EtcGMTminus1
        | [<JsonUnionCase("Etc/GMT-10")>] EtcGMTminus10
        | [<JsonUnionCase("Etc/GMT-11")>] EtcGMTminus11
        | [<JsonUnionCase("Etc/GMT-12")>] EtcGMTminus12
        | [<JsonUnionCase("Etc/GMT-13")>] EtcGMTminus13
        | [<JsonUnionCase("Etc/GMT-14")>] EtcGMTminus14
        | [<JsonUnionCase("Etc/GMT-2")>] EtcGMTminus2
        | [<JsonUnionCase("Etc/GMT-3")>] EtcGMTminus3
        | [<JsonUnionCase("Etc/GMT-4")>] EtcGMTminus4
        | [<JsonUnionCase("Etc/GMT-5")>] EtcGMTminus5
        | [<JsonUnionCase("Etc/GMT-6")>] EtcGMTminus6
        | [<JsonUnionCase("Etc/GMT-7")>] EtcGMTminus7
        | [<JsonUnionCase("Etc/GMT-8")>] EtcGMTminus8
        | [<JsonUnionCase("Etc/GMT-9")>] EtcGMTminus9
        | [<JsonUnionCase("Etc/GMT0")>] EtcGMT0
        | [<JsonUnionCase("Etc/Greenwich")>] EtcGreenwich
        | [<JsonUnionCase("Etc/UCT")>] EtcUCT
        | [<JsonUnionCase("Etc/UTC")>] EtcUTC
        | [<JsonUnionCase("Etc/Universal")>] EtcUniversal
        | [<JsonUnionCase("Etc/Zulu")>] EtcZulu
        | [<JsonUnionCase("Europe/Amsterdam")>] EuropeAmsterdam
        | [<JsonUnionCase("Europe/Andorra")>] EuropeAndorra
        | [<JsonUnionCase("Europe/Astrakhan")>] EuropeAstrakhan
        | [<JsonUnionCase("Europe/Athens")>] EuropeAthens
        | [<JsonUnionCase("Europe/Belfast")>] EuropeBelfast
        | [<JsonUnionCase("Europe/Belgrade")>] EuropeBelgrade
        | [<JsonUnionCase("Europe/Berlin")>] EuropeBerlin
        | [<JsonUnionCase("Europe/Bratislava")>] EuropeBratislava
        | [<JsonUnionCase("Europe/Brussels")>] EuropeBrussels
        | [<JsonUnionCase("Europe/Bucharest")>] EuropeBucharest
        | [<JsonUnionCase("Europe/Budapest")>] EuropeBudapest
        | [<JsonUnionCase("Europe/Busingen")>] EuropeBusingen
        | [<JsonUnionCase("Europe/Chisinau")>] EuropeChisinau
        | [<JsonUnionCase("Europe/Copenhagen")>] EuropeCopenhagen
        | [<JsonUnionCase("Europe/Dublin")>] EuropeDublin
        | [<JsonUnionCase("Europe/Gibraltar")>] EuropeGibraltar
        | [<JsonUnionCase("Europe/Guernsey")>] EuropeGuernsey
        | [<JsonUnionCase("Europe/Helsinki")>] EuropeHelsinki
        | [<JsonUnionCase("Europe/Isle_of_Man")>] EuropeIsleOfMan
        | [<JsonUnionCase("Europe/Istanbul")>] EuropeIstanbul
        | [<JsonUnionCase("Europe/Jersey")>] EuropeJersey
        | [<JsonUnionCase("Europe/Kaliningrad")>] EuropeKaliningrad
        | [<JsonUnionCase("Europe/Kiev")>] EuropeKiev
        | [<JsonUnionCase("Europe/Kirov")>] EuropeKirov
        | [<JsonUnionCase("Europe/Lisbon")>] EuropeLisbon
        | [<JsonUnionCase("Europe/Ljubljana")>] EuropeLjubljana
        | [<JsonUnionCase("Europe/London")>] EuropeLondon
        | [<JsonUnionCase("Europe/Luxembourg")>] EuropeLuxembourg
        | [<JsonUnionCase("Europe/Madrid")>] EuropeMadrid
        | [<JsonUnionCase("Europe/Malta")>] EuropeMalta
        | [<JsonUnionCase("Europe/Mariehamn")>] EuropeMariehamn
        | [<JsonUnionCase("Europe/Minsk")>] EuropeMinsk
        | [<JsonUnionCase("Europe/Monaco")>] EuropeMonaco
        | [<JsonUnionCase("Europe/Moscow")>] EuropeMoscow
        | [<JsonUnionCase("Europe/Nicosia")>] EuropeNicosia
        | [<JsonUnionCase("Europe/Oslo")>] EuropeOslo
        | [<JsonUnionCase("Europe/Paris")>] EuropeParis
        | [<JsonUnionCase("Europe/Podgorica")>] EuropePodgorica
        | [<JsonUnionCase("Europe/Prague")>] EuropePrague
        | [<JsonUnionCase("Europe/Riga")>] EuropeRiga
        | [<JsonUnionCase("Europe/Rome")>] EuropeRome
        | [<JsonUnionCase("Europe/Samara")>] EuropeSamara
        | [<JsonUnionCase("Europe/San_Marino")>] EuropeSanMarino
        | [<JsonUnionCase("Europe/Sarajevo")>] EuropeSarajevo
        | [<JsonUnionCase("Europe/Saratov")>] EuropeSaratov
        | [<JsonUnionCase("Europe/Simferopol")>] EuropeSimferopol
        | [<JsonUnionCase("Europe/Skopje")>] EuropeSkopje
        | [<JsonUnionCase("Europe/Sofia")>] EuropeSofia
        | [<JsonUnionCase("Europe/Stockholm")>] EuropeStockholm
        | [<JsonUnionCase("Europe/Tallinn")>] EuropeTallinn
        | [<JsonUnionCase("Europe/Tirane")>] EuropeTirane
        | [<JsonUnionCase("Europe/Tiraspol")>] EuropeTiraspol
        | [<JsonUnionCase("Europe/Ulyanovsk")>] EuropeUlyanovsk
        | [<JsonUnionCase("Europe/Uzhgorod")>] EuropeUzhgorod
        | [<JsonUnionCase("Europe/Vaduz")>] EuropeVaduz
        | [<JsonUnionCase("Europe/Vatican")>] EuropeVatican
        | [<JsonUnionCase("Europe/Vienna")>] EuropeVienna
        | [<JsonUnionCase("Europe/Vilnius")>] EuropeVilnius
        | [<JsonUnionCase("Europe/Volgograd")>] EuropeVolgograd
        | [<JsonUnionCase("Europe/Warsaw")>] EuropeWarsaw
        | [<JsonUnionCase("Europe/Zagreb")>] EuropeZagreb
        | [<JsonUnionCase("Europe/Zaporozhye")>] EuropeZaporozhye
        | [<JsonUnionCase("Europe/Zurich")>] EuropeZurich
        | [<JsonUnionCase("Factory")>] Factory
        | [<JsonUnionCase("GB")>] GB
        | [<JsonUnionCase("GB-Eire")>] GBEire
        | [<JsonUnionCase("GMT")>] GMT
        | [<JsonUnionCase("GMT+0")>] GMTplus0
        | [<JsonUnionCase("GMT-0")>] GMTminus0
        | [<JsonUnionCase("GMT0")>] GMT0
        | [<JsonUnionCase("Greenwich")>] Greenwich
        | [<JsonUnionCase("HST")>] HST
        | [<JsonUnionCase("Hongkong")>] Hongkong
        | [<JsonUnionCase("Iceland")>] Iceland
        | [<JsonUnionCase("Indian/Antananarivo")>] IndianAntananarivo
        | [<JsonUnionCase("Indian/Chagos")>] IndianChagos
        | [<JsonUnionCase("Indian/Christmas")>] IndianChristmas
        | [<JsonUnionCase("Indian/Cocos")>] IndianCocos
        | [<JsonUnionCase("Indian/Comoro")>] IndianComoro
        | [<JsonUnionCase("Indian/Kerguelen")>] IndianKerguelen
        | [<JsonUnionCase("Indian/Mahe")>] IndianMahe
        | [<JsonUnionCase("Indian/Maldives")>] IndianMaldives
        | [<JsonUnionCase("Indian/Mauritius")>] IndianMauritius
        | [<JsonUnionCase("Indian/Mayotte")>] IndianMayotte
        | [<JsonUnionCase("Indian/Reunion")>] IndianReunion
        | [<JsonUnionCase("Iran")>] Iran
        | [<JsonUnionCase("Israel")>] Israel
        | [<JsonUnionCase("Jamaica")>] Jamaica
        | [<JsonUnionCase("Japan")>] Japan
        | [<JsonUnionCase("Kwajalein")>] Kwajalein
        | [<JsonUnionCase("Libya")>] Libya
        | [<JsonUnionCase("MET")>] MET
        | [<JsonUnionCase("MST")>] MST
        | [<JsonUnionCase("MST7MDT")>] MST7MDT
        | [<JsonUnionCase("Mexico/BajaNorte")>] MexicoBajaNorte
        | [<JsonUnionCase("Mexico/BajaSur")>] MexicoBajaSur
        | [<JsonUnionCase("Mexico/General")>] MexicoGeneral
        | [<JsonUnionCase("NZ")>] NZ
        | [<JsonUnionCase("NZ-CHAT")>] NZCHAT
        | [<JsonUnionCase("Navajo")>] Navajo
        | [<JsonUnionCase("PRC")>] PRC
        | [<JsonUnionCase("PST8PDT")>] PST8PDT
        | [<JsonUnionCase("Pacific/Apia")>] PacificApia
        | [<JsonUnionCase("Pacific/Auckland")>] PacificAuckland
        | [<JsonUnionCase("Pacific/Bougainville")>] PacificBougainville
        | [<JsonUnionCase("Pacific/Chatham")>] PacificChatham
        | [<JsonUnionCase("Pacific/Chuuk")>] PacificChuuk
        | [<JsonUnionCase("Pacific/Easter")>] PacificEaster
        | [<JsonUnionCase("Pacific/Efate")>] PacificEfate
        | [<JsonUnionCase("Pacific/Enderbury")>] PacificEnderbury
        | [<JsonUnionCase("Pacific/Fakaofo")>] PacificFakaofo
        | [<JsonUnionCase("Pacific/Fiji")>] PacificFiji
        | [<JsonUnionCase("Pacific/Funafuti")>] PacificFunafuti
        | [<JsonUnionCase("Pacific/Galapagos")>] PacificGalapagos
        | [<JsonUnionCase("Pacific/Gambier")>] PacificGambier
        | [<JsonUnionCase("Pacific/Guadalcanal")>] PacificGuadalcanal
        | [<JsonUnionCase("Pacific/Guam")>] PacificGuam
        | [<JsonUnionCase("Pacific/Honolulu")>] PacificHonolulu
        | [<JsonUnionCase("Pacific/Johnston")>] PacificJohnston
        | [<JsonUnionCase("Pacific/Kiritimati")>] PacificKiritimati
        | [<JsonUnionCase("Pacific/Kosrae")>] PacificKosrae
        | [<JsonUnionCase("Pacific/Kwajalein")>] PacificKwajalein
        | [<JsonUnionCase("Pacific/Majuro")>] PacificMajuro
        | [<JsonUnionCase("Pacific/Marquesas")>] PacificMarquesas
        | [<JsonUnionCase("Pacific/Midway")>] PacificMidway
        | [<JsonUnionCase("Pacific/Nauru")>] PacificNauru
        | [<JsonUnionCase("Pacific/Niue")>] PacificNiue
        | [<JsonUnionCase("Pacific/Norfolk")>] PacificNorfolk
        | [<JsonUnionCase("Pacific/Noumea")>] PacificNoumea
        | [<JsonUnionCase("Pacific/Pago_Pago")>] PacificPagoPago
        | [<JsonUnionCase("Pacific/Palau")>] PacificPalau
        | [<JsonUnionCase("Pacific/Pitcairn")>] PacificPitcairn
        | [<JsonUnionCase("Pacific/Pohnpei")>] PacificPohnpei
        | [<JsonUnionCase("Pacific/Ponape")>] PacificPonape
        | [<JsonUnionCase("Pacific/Port_Moresby")>] PacificPortMoresby
        | [<JsonUnionCase("Pacific/Rarotonga")>] PacificRarotonga
        | [<JsonUnionCase("Pacific/Saipan")>] PacificSaipan
        | [<JsonUnionCase("Pacific/Samoa")>] PacificSamoa
        | [<JsonUnionCase("Pacific/Tahiti")>] PacificTahiti
        | [<JsonUnionCase("Pacific/Tarawa")>] PacificTarawa
        | [<JsonUnionCase("Pacific/Tongatapu")>] PacificTongatapu
        | [<JsonUnionCase("Pacific/Truk")>] PacificTruk
        | [<JsonUnionCase("Pacific/Wake")>] PacificWake
        | [<JsonUnionCase("Pacific/Wallis")>] PacificWallis
        | [<JsonUnionCase("Pacific/Yap")>] PacificYap
        | [<JsonUnionCase("Poland")>] Poland
        | [<JsonUnionCase("Portugal")>] Portugal
        | [<JsonUnionCase("ROC")>] ROC
        | [<JsonUnionCase("ROK")>] ROK
        | [<JsonUnionCase("Singapore")>] Singapore
        | [<JsonUnionCase("Turkey")>] Turkey
        | [<JsonUnionCase("UCT")>] UCT
        | [<JsonUnionCase("US/Alaska")>] USAlaska
        | [<JsonUnionCase("US/Aleutian")>] USAleutian
        | [<JsonUnionCase("US/Arizona")>] USArizona
        | [<JsonUnionCase("US/Central")>] USCentral
        | [<JsonUnionCase("US/East-Indiana")>] USEastIndiana
        | [<JsonUnionCase("US/Eastern")>] USEastern
        | [<JsonUnionCase("US/Hawaii")>] USHawaii
        | [<JsonUnionCase("US/Indiana-Starke")>] USIndianaStarke
        | [<JsonUnionCase("US/Michigan")>] USMichigan
        | [<JsonUnionCase("US/Mountain")>] USMountain
        | [<JsonUnionCase("US/Pacific")>] USPacific
        | [<JsonUnionCase("US/Pacific-New")>] USPacificNew
        | [<JsonUnionCase("US/Samoa")>] USSamoa
        | [<JsonUnionCase("UTC")>] UTC
        | [<JsonUnionCase("Universal")>] Universal
        | [<JsonUnionCase("W-SU")>] WSU
        | [<JsonUnionCase("WET")>] WET
        | [<JsonUnionCase("Zulu")>] Zulu

    type ReportingReportRuns'CreateParameters = {
        Columns: string list option
        ConnectedAccount: string option
        Currency: string option
        IntervalEnd: DateTime option
        IntervalStart: DateTime option
        Payout: string option
        ReportingCategory: ReportingReportRuns'CreateParametersReportingCategory option
        Timezone: ReportingReportRuns'CreateParametersTimezone option
    }
    with
        static member Create(?columns: string list, ?connectedAccount: string, ?currency: string, ?intervalEnd: DateTime, ?intervalStart: DateTime, ?payout: string, ?reportingCategory: ReportingReportRuns'CreateParametersReportingCategory, ?timezone: ReportingReportRuns'CreateParametersTimezone) =
            {
                Columns = columns
                ConnectedAccount = connectedAccount
                Currency = currency
                IntervalEnd = intervalEnd
                IntervalStart = intervalStart
                Payout = payout
                ReportingCategory = reportingCategory
                Timezone = timezone
            }

    type ReportingReportRuns'CreateOptions = {
        Expand: string list option
        Parameters: ReportingReportRuns'CreateParameters option
        ReportType: string
    }
    with
        static member Create(reportType: string, ?parameters: ReportingReportRuns'CreateParameters, ?expand: string list) =
            {
                Expand = expand
                Parameters = parameters
                ReportType = reportType
            }

    type ReviewsApprove'ApproveOptions = {
        Expand: string list option
    }
    with
        static member Create(?expand: string list) =
            {
                Expand = expand
            }

    type SetupIntents'CreateMandateDataCustomerAcceptanceOnline = {
        IpAddress: string option
        UserAgent: string option
    }
    with
        static member Create(?ipAddress: string, ?userAgent: string) =
            {
                IpAddress = ipAddress
                UserAgent = userAgent
            }

    type SetupIntents'CreateMandateDataCustomerAcceptanceType =
        | Offline
        | Online

    type SetupIntents'CreateMandateDataCustomerAcceptance = {
        AcceptedAt: DateTime option
        Offline: string option
        Online: SetupIntents'CreateMandateDataCustomerAcceptanceOnline option
        Type: SetupIntents'CreateMandateDataCustomerAcceptanceType option
    }
    with
        static member Create(?acceptedAt: DateTime, ?offline: string, ?online: SetupIntents'CreateMandateDataCustomerAcceptanceOnline, ?``type``: SetupIntents'CreateMandateDataCustomerAcceptanceType) =
            {
                AcceptedAt = acceptedAt
                Offline = offline
                Online = online
                Type = ``type``
            }

    type SetupIntents'CreateMandateData = {
        CustomerAcceptance: SetupIntents'CreateMandateDataCustomerAcceptance option
    }
    with
        static member Create(?customerAcceptance: SetupIntents'CreateMandateDataCustomerAcceptance) =
            {
                CustomerAcceptance = customerAcceptance
            }

    type SetupIntents'CreatePaymentMethodOptionsCardRequestThreeDSecure =
        | Any
        | Automatic

    type SetupIntents'CreatePaymentMethodOptionsCard = {
        Moto: bool option
        RequestThreeDSecure: SetupIntents'CreatePaymentMethodOptionsCardRequestThreeDSecure option
    }
    with
        static member Create(?moto: bool, ?requestThreeDSecure: SetupIntents'CreatePaymentMethodOptionsCardRequestThreeDSecure) =
            {
                Moto = moto
                RequestThreeDSecure = requestThreeDSecure
            }

    type SetupIntents'CreatePaymentMethodOptionsSepaDebit = {
        MandateOptions: string option
    }
    with
        static member Create(?mandateOptions: string) =
            {
                MandateOptions = mandateOptions
            }

    type SetupIntents'CreatePaymentMethodOptions = {
        Card: SetupIntents'CreatePaymentMethodOptionsCard option
        SepaDebit: SetupIntents'CreatePaymentMethodOptionsSepaDebit option
    }
    with
        static member Create(?card: SetupIntents'CreatePaymentMethodOptionsCard, ?sepaDebit: SetupIntents'CreatePaymentMethodOptionsSepaDebit) =
            {
                Card = card
                SepaDebit = sepaDebit
            }

    type SetupIntents'CreateSingleUse = {
        Amount: int option
        Currency: string option
    }
    with
        static member Create(?amount: int, ?currency: string) =
            {
                Amount = amount
                Currency = currency
            }

    type SetupIntents'CreateUsage =
        | OffSession
        | OnSession

    type SetupIntents'CreateOptions = {
        Confirm: bool option
        Customer: string option
        Description: string option
        Expand: string list option
        MandateData: SetupIntents'CreateMandateData option
        Metadata: Map<string, string> option
        OnBehalfOf: string option
        PaymentMethod: string option
        PaymentMethodOptions: SetupIntents'CreatePaymentMethodOptions option
        PaymentMethodTypes: string list option
        ReturnUrl: string option
        SingleUse: SetupIntents'CreateSingleUse option
        Usage: SetupIntents'CreateUsage option
    }
    with
        static member Create(?confirm: bool, ?customer: string, ?description: string, ?expand: string list, ?mandateData: SetupIntents'CreateMandateData, ?metadata: Map<string, string>, ?onBehalfOf: string, ?paymentMethod: string, ?paymentMethodOptions: SetupIntents'CreatePaymentMethodOptions, ?paymentMethodTypes: string list, ?returnUrl: string, ?singleUse: SetupIntents'CreateSingleUse, ?usage: SetupIntents'CreateUsage) =
            {
                Confirm = confirm
                Customer = customer
                Description = description
                Expand = expand
                MandateData = mandateData
                Metadata = metadata
                OnBehalfOf = onBehalfOf
                PaymentMethod = paymentMethod
                PaymentMethodOptions = paymentMethodOptions
                PaymentMethodTypes = paymentMethodTypes
                ReturnUrl = returnUrl
                SingleUse = singleUse
                Usage = usage
            }

    type SetupIntents'UpdatePaymentMethodOptionsCardRequestThreeDSecure =
        | Any
        | Automatic

    type SetupIntents'UpdatePaymentMethodOptionsCard = {
        Moto: bool option
        RequestThreeDSecure: SetupIntents'UpdatePaymentMethodOptionsCardRequestThreeDSecure option
    }
    with
        static member Create(?moto: bool, ?requestThreeDSecure: SetupIntents'UpdatePaymentMethodOptionsCardRequestThreeDSecure) =
            {
                Moto = moto
                RequestThreeDSecure = requestThreeDSecure
            }

    type SetupIntents'UpdatePaymentMethodOptionsSepaDebit = {
        MandateOptions: string option
    }
    with
        static member Create(?mandateOptions: string) =
            {
                MandateOptions = mandateOptions
            }

    type SetupIntents'UpdatePaymentMethodOptions = {
        Card: SetupIntents'UpdatePaymentMethodOptionsCard option
        SepaDebit: SetupIntents'UpdatePaymentMethodOptionsSepaDebit option
    }
    with
        static member Create(?card: SetupIntents'UpdatePaymentMethodOptionsCard, ?sepaDebit: SetupIntents'UpdatePaymentMethodOptionsSepaDebit) =
            {
                Card = card
                SepaDebit = sepaDebit
            }

    type SetupIntents'UpdateOptions = {
        Customer: string option
        Description: string option
        Expand: string list option
        Metadata: Map<string, string> option
        PaymentMethod: string option
        PaymentMethodOptions: SetupIntents'UpdatePaymentMethodOptions option
        PaymentMethodTypes: string list option
    }
    with
        static member Create(?customer: string, ?description: string, ?expand: string list, ?metadata: Map<string, string>, ?paymentMethod: string, ?paymentMethodOptions: SetupIntents'UpdatePaymentMethodOptions, ?paymentMethodTypes: string list) =
            {
                Customer = customer
                Description = description
                Expand = expand
                Metadata = metadata
                PaymentMethod = paymentMethod
                PaymentMethodOptions = paymentMethodOptions
                PaymentMethodTypes = paymentMethodTypes
            }

    type SetupIntentsCancel'CancelCancellationReason =
        | Abandoned
        | Duplicate
        | RequestedByCustomer

    type SetupIntentsCancel'CancelOptions = {
        CancellationReason: SetupIntentsCancel'CancelCancellationReason option
        Expand: string list option
    }
    with
        static member Create(?cancellationReason: SetupIntentsCancel'CancelCancellationReason, ?expand: string list) =
            {
                CancellationReason = cancellationReason
                Expand = expand
            }

    type SetupIntentsConfirm'ConfirmMandateDataSecretKeyCustomerAcceptanceOnline = {
        IpAddress: string option
        UserAgent: string option
    }
    with
        static member Create(?ipAddress: string, ?userAgent: string) =
            {
                IpAddress = ipAddress
                UserAgent = userAgent
            }

    type SetupIntentsConfirm'ConfirmMandateDataSecretKeyCustomerAcceptanceType =
        | Offline
        | Online

    type SetupIntentsConfirm'ConfirmMandateDataSecretKeyCustomerAcceptance = {
        AcceptedAt: DateTime option
        Offline: string option
        Online: SetupIntentsConfirm'ConfirmMandateDataSecretKeyCustomerAcceptanceOnline option
        Type: SetupIntentsConfirm'ConfirmMandateDataSecretKeyCustomerAcceptanceType option
    }
    with
        static member Create(?acceptedAt: DateTime, ?offline: string, ?online: SetupIntentsConfirm'ConfirmMandateDataSecretKeyCustomerAcceptanceOnline, ?``type``: SetupIntentsConfirm'ConfirmMandateDataSecretKeyCustomerAcceptanceType) =
            {
                AcceptedAt = acceptedAt
                Offline = offline
                Online = online
                Type = ``type``
            }

    type SetupIntentsConfirm'ConfirmMandateDataSecretKey = {
        CustomerAcceptance: SetupIntentsConfirm'ConfirmMandateDataSecretKeyCustomerAcceptance option
    }
    with
        static member Create(?customerAcceptance: SetupIntentsConfirm'ConfirmMandateDataSecretKeyCustomerAcceptance) =
            {
                CustomerAcceptance = customerAcceptance
            }

    type SetupIntentsConfirm'ConfirmMandateDataClientKeyCustomerAcceptanceOnline = {
        IpAddress: string option
        UserAgent: string option
    }
    with
        static member Create(?ipAddress: string, ?userAgent: string) =
            {
                IpAddress = ipAddress
                UserAgent = userAgent
            }

    type SetupIntentsConfirm'ConfirmMandateDataClientKeyCustomerAcceptanceType =
        | Online

    type SetupIntentsConfirm'ConfirmMandateDataClientKeyCustomerAcceptance = {
        Online: SetupIntentsConfirm'ConfirmMandateDataClientKeyCustomerAcceptanceOnline option
        Type: SetupIntentsConfirm'ConfirmMandateDataClientKeyCustomerAcceptanceType option
    }
    with
        static member Create(?online: SetupIntentsConfirm'ConfirmMandateDataClientKeyCustomerAcceptanceOnline, ?``type``: SetupIntentsConfirm'ConfirmMandateDataClientKeyCustomerAcceptanceType) =
            {
                Online = online
                Type = ``type``
            }

    type SetupIntentsConfirm'ConfirmMandateDataClientKey = {
        CustomerAcceptance: SetupIntentsConfirm'ConfirmMandateDataClientKeyCustomerAcceptance option
    }
    with
        static member Create(?customerAcceptance: SetupIntentsConfirm'ConfirmMandateDataClientKeyCustomerAcceptance) =
            {
                CustomerAcceptance = customerAcceptance
            }

    type SetupIntentsConfirm'ConfirmPaymentMethodOptionsCardRequestThreeDSecure =
        | Any
        | Automatic

    type SetupIntentsConfirm'ConfirmPaymentMethodOptionsCard = {
        Moto: bool option
        RequestThreeDSecure: SetupIntentsConfirm'ConfirmPaymentMethodOptionsCardRequestThreeDSecure option
    }
    with
        static member Create(?moto: bool, ?requestThreeDSecure: SetupIntentsConfirm'ConfirmPaymentMethodOptionsCardRequestThreeDSecure) =
            {
                Moto = moto
                RequestThreeDSecure = requestThreeDSecure
            }

    type SetupIntentsConfirm'ConfirmPaymentMethodOptionsSepaDebit = {
        MandateOptions: string option
    }
    with
        static member Create(?mandateOptions: string) =
            {
                MandateOptions = mandateOptions
            }

    type SetupIntentsConfirm'ConfirmPaymentMethodOptions = {
        Card: SetupIntentsConfirm'ConfirmPaymentMethodOptionsCard option
        SepaDebit: SetupIntentsConfirm'ConfirmPaymentMethodOptionsSepaDebit option
    }
    with
        static member Create(?card: SetupIntentsConfirm'ConfirmPaymentMethodOptionsCard, ?sepaDebit: SetupIntentsConfirm'ConfirmPaymentMethodOptionsSepaDebit) =
            {
                Card = card
                SepaDebit = sepaDebit
            }

    type SetupIntentsConfirm'ConfirmOptions = {
        Expand: string list option
        MandateData: Choice<SetupIntentsConfirm'ConfirmMandateDataSecretKey,SetupIntentsConfirm'ConfirmMandateDataClientKey> option
        PaymentMethod: string option
        PaymentMethodOptions: SetupIntentsConfirm'ConfirmPaymentMethodOptions option
        ReturnUrl: string option
    }
    with
        static member Create(?expand: string list, ?mandateData: Choice<SetupIntentsConfirm'ConfirmMandateDataSecretKey,SetupIntentsConfirm'ConfirmMandateDataClientKey>, ?paymentMethod: string, ?paymentMethodOptions: SetupIntentsConfirm'ConfirmPaymentMethodOptions, ?returnUrl: string) =
            {
                Expand = expand
                MandateData = mandateData
                PaymentMethod = paymentMethod
                PaymentMethodOptions = paymentMethodOptions
                ReturnUrl = returnUrl
            }

    type Skus'CreateInventoryType =
        | Bucket
        | Finite
        | Infinite

    type Skus'CreateInventoryValue =
        | InStock
        | Limited
        | OutOfStock

    type Skus'CreateInventory = {
        Quantity: int option
        Type: Skus'CreateInventoryType option
        Value: Skus'CreateInventoryValue option
    }
    with
        static member Create(?quantity: int, ?``type``: Skus'CreateInventoryType, ?value: Skus'CreateInventoryValue) =
            {
                Quantity = quantity
                Type = ``type``
                Value = value
            }

    type Skus'CreatePackageDimensions = {
        Height: decimal option
        Length: decimal option
        Weight: decimal option
        Width: decimal option
    }
    with
        static member Create(?height: decimal, ?length: decimal, ?weight: decimal, ?width: decimal) =
            {
                Height = height
                Length = length
                Weight = weight
                Width = width
            }

    type Skus'CreateOptions = {
        Active: bool option
        Attributes: Map<string, string> option
        Currency: string
        Expand: string list option
        Id: string option
        Image: string option
        Inventory: Skus'CreateInventory
        Metadata: Map<string, string> option
        PackageDimensions: Skus'CreatePackageDimensions option
        Price: int
        Product: string
    }
    with
        static member Create(currency: string, inventory: Skus'CreateInventory, price: int, product: string, ?active: bool, ?attributes: Map<string, string>, ?expand: string list, ?id: string, ?image: string, ?metadata: Map<string, string>, ?packageDimensions: Skus'CreatePackageDimensions) =
            {
                Active = active
                Attributes = attributes
                Currency = currency
                Expand = expand
                Id = id
                Image = image
                Inventory = inventory
                Metadata = metadata
                PackageDimensions = packageDimensions
                Price = price
                Product = product
            }

    type Skus'UpdateInventoryType =
        | Bucket
        | Finite
        | Infinite

    type Skus'UpdateInventoryValue =
        | InStock
        | Limited
        | OutOfStock

    type Skus'UpdateInventory = {
        Quantity: int option
        Type: Skus'UpdateInventoryType option
        Value: Skus'UpdateInventoryValue option
    }
    with
        static member Create(?quantity: int, ?``type``: Skus'UpdateInventoryType, ?value: Skus'UpdateInventoryValue) =
            {
                Quantity = quantity
                Type = ``type``
                Value = value
            }

    type Skus'UpdatePackageDimensionsPackageDimensionsSpecs = {
        Height: decimal option
        Length: decimal option
        Weight: decimal option
        Width: decimal option
    }
    with
        static member Create(?height: decimal, ?length: decimal, ?weight: decimal, ?width: decimal) =
            {
                Height = height
                Length = length
                Weight = weight
                Width = width
            }

    type Skus'UpdateOptions = {
        Active: bool option
        Attributes: Map<string, string> option
        Currency: string option
        Expand: string list option
        Image: string option
        Inventory: Skus'UpdateInventory option
        Metadata: Map<string, string> option
        PackageDimensions: Choice<Skus'UpdatePackageDimensionsPackageDimensionsSpecs,string> option
        Price: int option
        Product: string option
    }
    with
        static member Create(?active: bool, ?attributes: Map<string, string>, ?currency: string, ?expand: string list, ?image: string, ?inventory: Skus'UpdateInventory, ?metadata: Map<string, string>, ?packageDimensions: Choice<Skus'UpdatePackageDimensionsPackageDimensionsSpecs,string>, ?price: int, ?product: string) =
            {
                Active = active
                Attributes = attributes
                Currency = currency
                Expand = expand
                Image = image
                Inventory = inventory
                Metadata = metadata
                PackageDimensions = packageDimensions
                Price = price
                Product = product
            }

    type Sources'CreateMandateAcceptanceOffline = {
        ContactEmail: string option
    }
    with
        static member Create(?contactEmail: string) =
            {
                ContactEmail = contactEmail
            }

    type Sources'CreateMandateAcceptanceOnline = {
        Date: DateTime option
        Ip: string option
        UserAgent: string option
    }
    with
        static member Create(?date: DateTime, ?ip: string, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Sources'CreateMandateAcceptanceStatus =
        | Accepted
        | Pending
        | Refused
        | Revoked

    type Sources'CreateMandateAcceptanceType =
        | Offline
        | Online

    type Sources'CreateMandateAcceptance = {
        Date: DateTime option
        Ip: string option
        Offline: Sources'CreateMandateAcceptanceOffline option
        Online: Sources'CreateMandateAcceptanceOnline option
        Status: Sources'CreateMandateAcceptanceStatus option
        Type: Sources'CreateMandateAcceptanceType option
        UserAgent: string option
    }
    with
        static member Create(?date: DateTime, ?ip: string, ?offline: Sources'CreateMandateAcceptanceOffline, ?online: Sources'CreateMandateAcceptanceOnline, ?status: Sources'CreateMandateAcceptanceStatus, ?``type``: Sources'CreateMandateAcceptanceType, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                Offline = offline
                Online = online
                Status = status
                Type = ``type``
                UserAgent = userAgent
            }

    type Sources'CreateMandateInterval =
        | OneTime
        | Scheduled
        | Variable

    type Sources'CreateMandateNotificationMethod =
        | DeprecatedNone'
        | Email
        | Manual
        | None'
        | StripeEmail

    type Sources'CreateMandate = {
        Acceptance: Sources'CreateMandateAcceptance option
        Amount: Choice<int,string> option
        Currency: string option
        Interval: Sources'CreateMandateInterval option
        NotificationMethod: Sources'CreateMandateNotificationMethod option
    }
    with
        static member Create(?acceptance: Sources'CreateMandateAcceptance, ?amount: Choice<int,string>, ?currency: string, ?interval: Sources'CreateMandateInterval, ?notificationMethod: Sources'CreateMandateNotificationMethod) =
            {
                Acceptance = acceptance
                Amount = amount
                Currency = currency
                Interval = interval
                NotificationMethod = notificationMethod
            }

    type Sources'CreateOwnerAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Sources'CreateOwner = {
        Address: Sources'CreateOwnerAddress option
        Email: string option
        Name: string option
        Phone: string option
    }
    with
        static member Create(?address: Sources'CreateOwnerAddress, ?email: string, ?name: string, ?phone: string) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
            }

    type Sources'CreateReceiverRefundAttributesMethod =
        | Email
        | Manual
        | None'

    type Sources'CreateReceiver = {
        RefundAttributesMethod: Sources'CreateReceiverRefundAttributesMethod option
    }
    with
        static member Create(?refundAttributesMethod: Sources'CreateReceiverRefundAttributesMethod) =
            {
                RefundAttributesMethod = refundAttributesMethod
            }

    type Sources'CreateRedirect = {
        ReturnUrl: string option
    }
    with
        static member Create(?returnUrl: string) =
            {
                ReturnUrl = returnUrl
            }

    type Sources'CreateSourceOrderItemsType =
        | Discount
        | Shipping
        | Sku
        | Tax

    type Sources'CreateSourceOrderItems = {
        Amount: int option
        Currency: string option
        Description: string option
        Parent: string option
        Quantity: int option
        Type: Sources'CreateSourceOrderItemsType option
    }
    with
        static member Create(?amount: int, ?currency: string, ?description: string, ?parent: string, ?quantity: int, ?``type``: Sources'CreateSourceOrderItemsType) =
            {
                Amount = amount
                Currency = currency
                Description = description
                Parent = parent
                Quantity = quantity
                Type = ``type``
            }

    type Sources'CreateSourceOrderShippingAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Sources'CreateSourceOrderShipping = {
        Address: Sources'CreateSourceOrderShippingAddress option
        Carrier: string option
        Name: string option
        Phone: string option
        TrackingNumber: string option
    }
    with
        static member Create(?address: Sources'CreateSourceOrderShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
            {
                Address = address
                Carrier = carrier
                Name = name
                Phone = phone
                TrackingNumber = trackingNumber
            }

    type Sources'CreateSourceOrder = {
        Items: Sources'CreateSourceOrderItems list option
        Shipping: Sources'CreateSourceOrderShipping option
    }
    with
        static member Create(?items: Sources'CreateSourceOrderItems list, ?shipping: Sources'CreateSourceOrderShipping) =
            {
                Items = items
                Shipping = shipping
            }

    type Sources'CreateFlow =
        | CodeVerification
        | None'
        | Receiver
        | Redirect

    type Sources'CreateUsage =
        | Reusable
        | SingleUse

    type Sources'CreateOptions = {
        Amount: int option
        Currency: string option
        Customer: string option
        Expand: string list option
        Flow: Sources'CreateFlow option
        Mandate: Sources'CreateMandate option
        Metadata: Map<string, string> option
        OriginalSource: string option
        Owner: Sources'CreateOwner option
        Receiver: Sources'CreateReceiver option
        Redirect: Sources'CreateRedirect option
        SourceOrder: Sources'CreateSourceOrder option
        StatementDescriptor: string option
        Token: string option
        Type: string option
        Usage: Sources'CreateUsage option
    }
    with
        static member Create(?amount: int, ?currency: string, ?customer: string, ?expand: string list, ?flow: Sources'CreateFlow, ?mandate: Sources'CreateMandate, ?metadata: Map<string, string>, ?originalSource: string, ?owner: Sources'CreateOwner, ?receiver: Sources'CreateReceiver, ?redirect: Sources'CreateRedirect, ?sourceOrder: Sources'CreateSourceOrder, ?statementDescriptor: string, ?token: string, ?``type``: string, ?usage: Sources'CreateUsage) =
            {
                Amount = amount
                Currency = currency
                Customer = customer
                Expand = expand
                Flow = flow
                Mandate = mandate
                Metadata = metadata
                OriginalSource = originalSource
                Owner = owner
                Receiver = receiver
                Redirect = redirect
                SourceOrder = sourceOrder
                StatementDescriptor = statementDescriptor
                Token = token
                Type = ``type``
                Usage = usage
            }

    type Sources'UpdateMandateAcceptanceOffline = {
        ContactEmail: string option
    }
    with
        static member Create(?contactEmail: string) =
            {
                ContactEmail = contactEmail
            }

    type Sources'UpdateMandateAcceptanceOnline = {
        Date: DateTime option
        Ip: string option
        UserAgent: string option
    }
    with
        static member Create(?date: DateTime, ?ip: string, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Sources'UpdateMandateAcceptanceStatus =
        | Accepted
        | Pending
        | Refused
        | Revoked

    type Sources'UpdateMandateAcceptanceType =
        | Offline
        | Online

    type Sources'UpdateMandateAcceptance = {
        Date: DateTime option
        Ip: string option
        Offline: Sources'UpdateMandateAcceptanceOffline option
        Online: Sources'UpdateMandateAcceptanceOnline option
        Status: Sources'UpdateMandateAcceptanceStatus option
        Type: Sources'UpdateMandateAcceptanceType option
        UserAgent: string option
    }
    with
        static member Create(?date: DateTime, ?ip: string, ?offline: Sources'UpdateMandateAcceptanceOffline, ?online: Sources'UpdateMandateAcceptanceOnline, ?status: Sources'UpdateMandateAcceptanceStatus, ?``type``: Sources'UpdateMandateAcceptanceType, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                Offline = offline
                Online = online
                Status = status
                Type = ``type``
                UserAgent = userAgent
            }

    type Sources'UpdateMandateInterval =
        | OneTime
        | Scheduled
        | Variable

    type Sources'UpdateMandateNotificationMethod =
        | DeprecatedNone'
        | Email
        | Manual
        | None'
        | StripeEmail

    type Sources'UpdateMandate = {
        Acceptance: Sources'UpdateMandateAcceptance option
        Amount: Choice<int,string> option
        Currency: string option
        Interval: Sources'UpdateMandateInterval option
        NotificationMethod: Sources'UpdateMandateNotificationMethod option
    }
    with
        static member Create(?acceptance: Sources'UpdateMandateAcceptance, ?amount: Choice<int,string>, ?currency: string, ?interval: Sources'UpdateMandateInterval, ?notificationMethod: Sources'UpdateMandateNotificationMethod) =
            {
                Acceptance = acceptance
                Amount = amount
                Currency = currency
                Interval = interval
                NotificationMethod = notificationMethod
            }

    type Sources'UpdateOwnerAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Sources'UpdateOwner = {
        Address: Sources'UpdateOwnerAddress option
        Email: string option
        Name: string option
        Phone: string option
    }
    with
        static member Create(?address: Sources'UpdateOwnerAddress, ?email: string, ?name: string, ?phone: string) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
            }

    type Sources'UpdateSourceOrderItemsType =
        | Discount
        | Shipping
        | Sku
        | Tax

    type Sources'UpdateSourceOrderItems = {
        Amount: int option
        Currency: string option
        Description: string option
        Parent: string option
        Quantity: int option
        Type: Sources'UpdateSourceOrderItemsType option
    }
    with
        static member Create(?amount: int, ?currency: string, ?description: string, ?parent: string, ?quantity: int, ?``type``: Sources'UpdateSourceOrderItemsType) =
            {
                Amount = amount
                Currency = currency
                Description = description
                Parent = parent
                Quantity = quantity
                Type = ``type``
            }

    type Sources'UpdateSourceOrderShippingAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Sources'UpdateSourceOrderShipping = {
        Address: Sources'UpdateSourceOrderShippingAddress option
        Carrier: string option
        Name: string option
        Phone: string option
        TrackingNumber: string option
    }
    with
        static member Create(?address: Sources'UpdateSourceOrderShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
            {
                Address = address
                Carrier = carrier
                Name = name
                Phone = phone
                TrackingNumber = trackingNumber
            }

    type Sources'UpdateSourceOrder = {
        Items: Sources'UpdateSourceOrderItems list option
        Shipping: Sources'UpdateSourceOrderShipping option
    }
    with
        static member Create(?items: Sources'UpdateSourceOrderItems list, ?shipping: Sources'UpdateSourceOrderShipping) =
            {
                Items = items
                Shipping = shipping
            }

    type Sources'UpdateOptions = {
        Amount: int option
        Expand: string list option
        Mandate: Sources'UpdateMandate option
        Metadata: Map<string, string> option
        Owner: Sources'UpdateOwner option
        SourceOrder: Sources'UpdateSourceOrder option
    }
    with
        static member Create(?amount: int, ?expand: string list, ?mandate: Sources'UpdateMandate, ?metadata: Map<string, string>, ?owner: Sources'UpdateOwner, ?sourceOrder: Sources'UpdateSourceOrder) =
            {
                Amount = amount
                Expand = expand
                Mandate = mandate
                Metadata = metadata
                Owner = owner
                SourceOrder = sourceOrder
            }

    type SourcesVerify'VerifyOptions = {
        Expand: string list option
        Values: string list
    }
    with
        static member Create(values: string list, ?expand: string list) =
            {
                Expand = expand
                Values = values
            }

    type SubscriptionItems'CreateBillingThresholdsItemBillingThresholds = {
        UsageGte: int option
    }
    with
        static member Create(?usageGte: int) =
            {
                UsageGte = usageGte
            }

    type SubscriptionItems'CreatePriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    type SubscriptionItems'CreatePriceDataRecurring = {
        Interval: SubscriptionItems'CreatePriceDataRecurringInterval option
        IntervalCount: int option
    }
    with
        static member Create(?interval: SubscriptionItems'CreatePriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type SubscriptionItems'CreatePriceData = {
        Currency: string option
        Product: string option
        Recurring: SubscriptionItems'CreatePriceDataRecurring option
        UnitAmount: int option
        UnitAmountDecimal: string option
    }
    with
        static member Create(?currency: string, ?product: string, ?recurring: SubscriptionItems'CreatePriceDataRecurring, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type SubscriptionItems'CreatePaymentBehavior =
        | AllowIncomplete
        | ErrorIfIncomplete
        | PendingIfIncomplete

    type SubscriptionItems'CreateProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | None'

    type SubscriptionItems'CreateOptions = {
        BillingThresholds: Choice<SubscriptionItems'CreateBillingThresholdsItemBillingThresholds,string> option
        Expand: string list option
        Metadata: Map<string, string> option
        PaymentBehavior: SubscriptionItems'CreatePaymentBehavior option
        Plan: string option
        Price: string option
        PriceData: SubscriptionItems'CreatePriceData option
        ProrationBehavior: SubscriptionItems'CreateProrationBehavior option
        ProrationDate: DateTime option
        Quantity: int option
        Subscription: string
        TaxRates: Choice<string list,string> option
    }
    with
        static member Create(subscription: string, ?billingThresholds: Choice<SubscriptionItems'CreateBillingThresholdsItemBillingThresholds,string>, ?expand: string list, ?metadata: Map<string, string>, ?paymentBehavior: SubscriptionItems'CreatePaymentBehavior, ?plan: string, ?price: string, ?priceData: SubscriptionItems'CreatePriceData, ?prorationBehavior: SubscriptionItems'CreateProrationBehavior, ?prorationDate: DateTime, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                BillingThresholds = billingThresholds
                Expand = expand
                Metadata = metadata
                PaymentBehavior = paymentBehavior
                Plan = plan
                Price = price
                PriceData = priceData
                ProrationBehavior = prorationBehavior
                ProrationDate = prorationDate
                Quantity = quantity
                Subscription = subscription
                TaxRates = taxRates
            }

    type SubscriptionItems'DeleteProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | None'

    type SubscriptionItems'DeleteOptions = {
        ClearUsage: bool option
        ProrationBehavior: SubscriptionItems'DeleteProrationBehavior option
        ProrationDate: DateTime option
    }
    with
        static member Create(?clearUsage: bool, ?prorationBehavior: SubscriptionItems'DeleteProrationBehavior, ?prorationDate: DateTime) =
            {
                ClearUsage = clearUsage
                ProrationBehavior = prorationBehavior
                ProrationDate = prorationDate
            }

    type SubscriptionItems'UpdateBillingThresholdsItemBillingThresholds = {
        UsageGte: int option
    }
    with
        static member Create(?usageGte: int) =
            {
                UsageGte = usageGte
            }

    type SubscriptionItems'UpdatePriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    type SubscriptionItems'UpdatePriceDataRecurring = {
        Interval: SubscriptionItems'UpdatePriceDataRecurringInterval option
        IntervalCount: int option
    }
    with
        static member Create(?interval: SubscriptionItems'UpdatePriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type SubscriptionItems'UpdatePriceData = {
        Currency: string option
        Product: string option
        Recurring: SubscriptionItems'UpdatePriceDataRecurring option
        UnitAmount: int option
        UnitAmountDecimal: string option
    }
    with
        static member Create(?currency: string, ?product: string, ?recurring: SubscriptionItems'UpdatePriceDataRecurring, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type SubscriptionItems'UpdatePaymentBehavior =
        | AllowIncomplete
        | ErrorIfIncomplete
        | PendingIfIncomplete

    type SubscriptionItems'UpdateProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | None'

    type SubscriptionItems'UpdateOptions = {
        BillingThresholds: Choice<SubscriptionItems'UpdateBillingThresholdsItemBillingThresholds,string> option
        Expand: string list option
        Metadata: Map<string, string> option
        OffSession: bool option
        PaymentBehavior: SubscriptionItems'UpdatePaymentBehavior option
        Plan: string option
        Price: string option
        PriceData: SubscriptionItems'UpdatePriceData option
        ProrationBehavior: SubscriptionItems'UpdateProrationBehavior option
        ProrationDate: DateTime option
        Quantity: int option
        TaxRates: Choice<string list,string> option
    }
    with
        static member Create(?billingThresholds: Choice<SubscriptionItems'UpdateBillingThresholdsItemBillingThresholds,string>, ?expand: string list, ?metadata: Map<string, string>, ?offSession: bool, ?paymentBehavior: SubscriptionItems'UpdatePaymentBehavior, ?plan: string, ?price: string, ?priceData: SubscriptionItems'UpdatePriceData, ?prorationBehavior: SubscriptionItems'UpdateProrationBehavior, ?prorationDate: DateTime, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                BillingThresholds = billingThresholds
                Expand = expand
                Metadata = metadata
                OffSession = offSession
                PaymentBehavior = paymentBehavior
                Plan = plan
                Price = price
                PriceData = priceData
                ProrationBehavior = prorationBehavior
                ProrationDate = prorationDate
                Quantity = quantity
                TaxRates = taxRates
            }

    type SubscriptionItemsUsageRecords'CreateAction =
        | Increment
        | Set

    type SubscriptionItemsUsageRecords'CreateOptions = {
        Action: SubscriptionItemsUsageRecords'CreateAction option
        Expand: string list option
        Quantity: int
        Timestamp: int
    }
    with
        static member Create(quantity: int, timestamp: int, ?action: SubscriptionItemsUsageRecords'CreateAction, ?expand: string list) =
            {
                Action = action
                Expand = expand
                Quantity = quantity
                Timestamp = timestamp
            }

    type SubscriptionSchedules'CreateDefaultSettingsBillingThresholdsBillingThresholds = {
        AmountGte: int option
        ResetBillingCycleAnchor: bool option
    }
    with
        static member Create(?amountGte: int, ?resetBillingCycleAnchor: bool) =
            {
                AmountGte = amountGte
                ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type SubscriptionSchedules'CreateDefaultSettingsInvoiceSettings = {
        DaysUntilDue: int option
    }
    with
        static member Create(?daysUntilDue: int) =
            {
                DaysUntilDue = daysUntilDue
            }

    type SubscriptionSchedules'CreateDefaultSettingsTransferDataTransferDataSpecs = {
        AmountPercent: decimal option
        Destination: string option
    }
    with
        static member Create(?amountPercent: decimal, ?destination: string) =
            {
                AmountPercent = amountPercent
                Destination = destination
            }

    type SubscriptionSchedules'CreateDefaultSettingsBillingCycleAnchor =
        | Automatic
        | PhaseStart

    type SubscriptionSchedules'CreateDefaultSettingsCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    type SubscriptionSchedules'CreateDefaultSettings = {
        BillingCycleAnchor: SubscriptionSchedules'CreateDefaultSettingsBillingCycleAnchor option
        BillingThresholds: Choice<SubscriptionSchedules'CreateDefaultSettingsBillingThresholdsBillingThresholds,string> option
        CollectionMethod: SubscriptionSchedules'CreateDefaultSettingsCollectionMethod option
        DefaultPaymentMethod: string option
        InvoiceSettings: SubscriptionSchedules'CreateDefaultSettingsInvoiceSettings option
        TransferData: Choice<SubscriptionSchedules'CreateDefaultSettingsTransferDataTransferDataSpecs,string> option
    }
    with
        static member Create(?billingCycleAnchor: SubscriptionSchedules'CreateDefaultSettingsBillingCycleAnchor, ?billingThresholds: Choice<SubscriptionSchedules'CreateDefaultSettingsBillingThresholdsBillingThresholds,string>, ?collectionMethod: SubscriptionSchedules'CreateDefaultSettingsCollectionMethod, ?defaultPaymentMethod: string, ?invoiceSettings: SubscriptionSchedules'CreateDefaultSettingsInvoiceSettings, ?transferData: Choice<SubscriptionSchedules'CreateDefaultSettingsTransferDataTransferDataSpecs,string>) =
            {
                BillingCycleAnchor = billingCycleAnchor
                BillingThresholds = billingThresholds
                CollectionMethod = collectionMethod
                DefaultPaymentMethod = defaultPaymentMethod
                InvoiceSettings = invoiceSettings
                TransferData = transferData
            }

    type SubscriptionSchedules'CreatePhasesAddInvoiceItemsPriceData = {
        Currency: string option
        Product: string option
        UnitAmount: int option
        UnitAmountDecimal: string option
    }
    with
        static member Create(?currency: string, ?product: string, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type SubscriptionSchedules'CreatePhasesAddInvoiceItems = {
        Price: string option
        PriceData: SubscriptionSchedules'CreatePhasesAddInvoiceItemsPriceData option
        Quantity: int option
        TaxRates: Choice<string list,string> option
    }
    with
        static member Create(?price: string, ?priceData: SubscriptionSchedules'CreatePhasesAddInvoiceItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type SubscriptionSchedules'CreatePhasesBillingThresholdsBillingThresholds = {
        AmountGte: int option
        ResetBillingCycleAnchor: bool option
    }
    with
        static member Create(?amountGte: int, ?resetBillingCycleAnchor: bool) =
            {
                AmountGte = amountGte
                ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type SubscriptionSchedules'CreatePhasesInvoiceSettings = {
        DaysUntilDue: int option
    }
    with
        static member Create(?daysUntilDue: int) =
            {
                DaysUntilDue = daysUntilDue
            }

    type SubscriptionSchedules'CreatePhasesItemsBillingThresholdsItemBillingThresholds = {
        UsageGte: int option
    }
    with
        static member Create(?usageGte: int) =
            {
                UsageGte = usageGte
            }

    type SubscriptionSchedules'CreatePhasesItemsPriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    type SubscriptionSchedules'CreatePhasesItemsPriceDataRecurring = {
        Interval: SubscriptionSchedules'CreatePhasesItemsPriceDataRecurringInterval option
        IntervalCount: int option
    }
    with
        static member Create(?interval: SubscriptionSchedules'CreatePhasesItemsPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type SubscriptionSchedules'CreatePhasesItemsPriceData = {
        Currency: string option
        Product: string option
        Recurring: SubscriptionSchedules'CreatePhasesItemsPriceDataRecurring option
        UnitAmount: int option
        UnitAmountDecimal: string option
    }
    with
        static member Create(?currency: string, ?product: string, ?recurring: SubscriptionSchedules'CreatePhasesItemsPriceDataRecurring, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type SubscriptionSchedules'CreatePhasesItems = {
        BillingThresholds: Choice<SubscriptionSchedules'CreatePhasesItemsBillingThresholdsItemBillingThresholds,string> option
        Plan: string option
        Price: string option
        PriceData: SubscriptionSchedules'CreatePhasesItemsPriceData option
        Quantity: int option
        TaxRates: Choice<string list,string> option
    }
    with
        static member Create(?billingThresholds: Choice<SubscriptionSchedules'CreatePhasesItemsBillingThresholdsItemBillingThresholds,string>, ?plan: string, ?price: string, ?priceData: SubscriptionSchedules'CreatePhasesItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                BillingThresholds = billingThresholds
                Plan = plan
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type SubscriptionSchedules'CreatePhasesTransferData = {
        AmountPercent: decimal option
        Destination: string option
    }
    with
        static member Create(?amountPercent: decimal, ?destination: string) =
            {
                AmountPercent = amountPercent
                Destination = destination
            }

    type SubscriptionSchedules'CreatePhasesBillingCycleAnchor =
        | Automatic
        | PhaseStart

    type SubscriptionSchedules'CreatePhasesCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    type SubscriptionSchedules'CreatePhasesProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | None'

    type SubscriptionSchedules'CreatePhases = {
        AddInvoiceItems: SubscriptionSchedules'CreatePhasesAddInvoiceItems list option
        ApplicationFeePercent: decimal option
        BillingCycleAnchor: SubscriptionSchedules'CreatePhasesBillingCycleAnchor option
        BillingThresholds: Choice<SubscriptionSchedules'CreatePhasesBillingThresholdsBillingThresholds,string> option
        CollectionMethod: SubscriptionSchedules'CreatePhasesCollectionMethod option
        Coupon: string option
        DefaultPaymentMethod: string option
        DefaultTaxRates: Choice<string list,string> option
        EndDate: DateTime option
        InvoiceSettings: SubscriptionSchedules'CreatePhasesInvoiceSettings option
        Items: SubscriptionSchedules'CreatePhasesItems list option
        Iterations: int option
        ProrationBehavior: SubscriptionSchedules'CreatePhasesProrationBehavior option
        TransferData: SubscriptionSchedules'CreatePhasesTransferData option
        Trial: bool option
        TrialEnd: DateTime option
    }
    with
        static member Create(?addInvoiceItems: SubscriptionSchedules'CreatePhasesAddInvoiceItems list, ?applicationFeePercent: decimal, ?billingCycleAnchor: SubscriptionSchedules'CreatePhasesBillingCycleAnchor, ?billingThresholds: Choice<SubscriptionSchedules'CreatePhasesBillingThresholdsBillingThresholds,string>, ?collectionMethod: SubscriptionSchedules'CreatePhasesCollectionMethod, ?coupon: string, ?defaultPaymentMethod: string, ?defaultTaxRates: Choice<string list,string>, ?endDate: DateTime, ?invoiceSettings: SubscriptionSchedules'CreatePhasesInvoiceSettings, ?items: SubscriptionSchedules'CreatePhasesItems list, ?iterations: int, ?prorationBehavior: SubscriptionSchedules'CreatePhasesProrationBehavior, ?transferData: SubscriptionSchedules'CreatePhasesTransferData, ?trial: bool, ?trialEnd: DateTime) =
            {
                AddInvoiceItems = addInvoiceItems
                ApplicationFeePercent = applicationFeePercent
                BillingCycleAnchor = billingCycleAnchor
                BillingThresholds = billingThresholds
                CollectionMethod = collectionMethod
                Coupon = coupon
                DefaultPaymentMethod = defaultPaymentMethod
                DefaultTaxRates = defaultTaxRates
                EndDate = endDate
                InvoiceSettings = invoiceSettings
                Items = items
                Iterations = iterations
                ProrationBehavior = prorationBehavior
                TransferData = transferData
                Trial = trial
                TrialEnd = trialEnd
            }

    type SubscriptionSchedules'CreateStartDate =
        | Now

    type SubscriptionSchedules'CreateEndBehavior =
        | Cancel
        | None'
        | Release
        | Renew

    type SubscriptionSchedules'CreateOptions = {
        Customer: string option
        DefaultSettings: SubscriptionSchedules'CreateDefaultSettings option
        EndBehavior: SubscriptionSchedules'CreateEndBehavior option
        Expand: string list option
        FromSubscription: string option
        Metadata: Map<string, string> option
        Phases: SubscriptionSchedules'CreatePhases list option
        StartDate: Choice<int,SubscriptionSchedules'CreateStartDate> option
    }
    with
        static member Create(?customer: string, ?defaultSettings: SubscriptionSchedules'CreateDefaultSettings, ?endBehavior: SubscriptionSchedules'CreateEndBehavior, ?expand: string list, ?fromSubscription: string, ?metadata: Map<string, string>, ?phases: SubscriptionSchedules'CreatePhases list, ?startDate: Choice<int,SubscriptionSchedules'CreateStartDate>) =
            {
                Customer = customer
                DefaultSettings = defaultSettings
                EndBehavior = endBehavior
                Expand = expand
                FromSubscription = fromSubscription
                Metadata = metadata
                Phases = phases
                StartDate = startDate
            }

    type SubscriptionSchedules'UpdateDefaultSettingsBillingThresholdsBillingThresholds = {
        AmountGte: int option
        ResetBillingCycleAnchor: bool option
    }
    with
        static member Create(?amountGte: int, ?resetBillingCycleAnchor: bool) =
            {
                AmountGte = amountGte
                ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type SubscriptionSchedules'UpdateDefaultSettingsInvoiceSettings = {
        DaysUntilDue: int option
    }
    with
        static member Create(?daysUntilDue: int) =
            {
                DaysUntilDue = daysUntilDue
            }

    type SubscriptionSchedules'UpdateDefaultSettingsTransferDataTransferDataSpecs = {
        AmountPercent: decimal option
        Destination: string option
    }
    with
        static member Create(?amountPercent: decimal, ?destination: string) =
            {
                AmountPercent = amountPercent
                Destination = destination
            }

    type SubscriptionSchedules'UpdateDefaultSettingsBillingCycleAnchor =
        | Automatic
        | PhaseStart

    type SubscriptionSchedules'UpdateDefaultSettingsCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    type SubscriptionSchedules'UpdateDefaultSettings = {
        BillingCycleAnchor: SubscriptionSchedules'UpdateDefaultSettingsBillingCycleAnchor option
        BillingThresholds: Choice<SubscriptionSchedules'UpdateDefaultSettingsBillingThresholdsBillingThresholds,string> option
        CollectionMethod: SubscriptionSchedules'UpdateDefaultSettingsCollectionMethod option
        DefaultPaymentMethod: string option
        InvoiceSettings: SubscriptionSchedules'UpdateDefaultSettingsInvoiceSettings option
        TransferData: Choice<SubscriptionSchedules'UpdateDefaultSettingsTransferDataTransferDataSpecs,string> option
    }
    with
        static member Create(?billingCycleAnchor: SubscriptionSchedules'UpdateDefaultSettingsBillingCycleAnchor, ?billingThresholds: Choice<SubscriptionSchedules'UpdateDefaultSettingsBillingThresholdsBillingThresholds,string>, ?collectionMethod: SubscriptionSchedules'UpdateDefaultSettingsCollectionMethod, ?defaultPaymentMethod: string, ?invoiceSettings: SubscriptionSchedules'UpdateDefaultSettingsInvoiceSettings, ?transferData: Choice<SubscriptionSchedules'UpdateDefaultSettingsTransferDataTransferDataSpecs,string>) =
            {
                BillingCycleAnchor = billingCycleAnchor
                BillingThresholds = billingThresholds
                CollectionMethod = collectionMethod
                DefaultPaymentMethod = defaultPaymentMethod
                InvoiceSettings = invoiceSettings
                TransferData = transferData
            }

    type SubscriptionSchedules'UpdatePhasesAddInvoiceItemsPriceData = {
        Currency: string option
        Product: string option
        UnitAmount: int option
        UnitAmountDecimal: string option
    }
    with
        static member Create(?currency: string, ?product: string, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type SubscriptionSchedules'UpdatePhasesAddInvoiceItems = {
        Price: string option
        PriceData: SubscriptionSchedules'UpdatePhasesAddInvoiceItemsPriceData option
        Quantity: int option
        TaxRates: Choice<string list,string> option
    }
    with
        static member Create(?price: string, ?priceData: SubscriptionSchedules'UpdatePhasesAddInvoiceItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type SubscriptionSchedules'UpdatePhasesBillingThresholdsBillingThresholds = {
        AmountGte: int option
        ResetBillingCycleAnchor: bool option
    }
    with
        static member Create(?amountGte: int, ?resetBillingCycleAnchor: bool) =
            {
                AmountGte = amountGte
                ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type SubscriptionSchedules'UpdatePhasesEndDate =
        | Now

    type SubscriptionSchedules'UpdatePhasesInvoiceSettings = {
        DaysUntilDue: int option
    }
    with
        static member Create(?daysUntilDue: int) =
            {
                DaysUntilDue = daysUntilDue
            }

    type SubscriptionSchedules'UpdatePhasesItemsBillingThresholdsItemBillingThresholds = {
        UsageGte: int option
    }
    with
        static member Create(?usageGte: int) =
            {
                UsageGte = usageGte
            }

    type SubscriptionSchedules'UpdatePhasesItemsPriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    type SubscriptionSchedules'UpdatePhasesItemsPriceDataRecurring = {
        Interval: SubscriptionSchedules'UpdatePhasesItemsPriceDataRecurringInterval option
        IntervalCount: int option
    }
    with
        static member Create(?interval: SubscriptionSchedules'UpdatePhasesItemsPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type SubscriptionSchedules'UpdatePhasesItemsPriceData = {
        Currency: string option
        Product: string option
        Recurring: SubscriptionSchedules'UpdatePhasesItemsPriceDataRecurring option
        UnitAmount: int option
        UnitAmountDecimal: string option
    }
    with
        static member Create(?currency: string, ?product: string, ?recurring: SubscriptionSchedules'UpdatePhasesItemsPriceDataRecurring, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type SubscriptionSchedules'UpdatePhasesItems = {
        BillingThresholds: Choice<SubscriptionSchedules'UpdatePhasesItemsBillingThresholdsItemBillingThresholds,string> option
        Plan: string option
        Price: string option
        PriceData: SubscriptionSchedules'UpdatePhasesItemsPriceData option
        Quantity: int option
        TaxRates: Choice<string list,string> option
    }
    with
        static member Create(?billingThresholds: Choice<SubscriptionSchedules'UpdatePhasesItemsBillingThresholdsItemBillingThresholds,string>, ?plan: string, ?price: string, ?priceData: SubscriptionSchedules'UpdatePhasesItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                BillingThresholds = billingThresholds
                Plan = plan
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type SubscriptionSchedules'UpdatePhasesStartDate =
        | Now

    type SubscriptionSchedules'UpdatePhasesTransferData = {
        AmountPercent: decimal option
        Destination: string option
    }
    with
        static member Create(?amountPercent: decimal, ?destination: string) =
            {
                AmountPercent = amountPercent
                Destination = destination
            }

    type SubscriptionSchedules'UpdatePhasesTrialEnd =
        | Now

    type SubscriptionSchedules'UpdatePhasesBillingCycleAnchor =
        | Automatic
        | PhaseStart

    type SubscriptionSchedules'UpdatePhasesCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    type SubscriptionSchedules'UpdatePhasesProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | None'

    type SubscriptionSchedules'UpdatePhases = {
        AddInvoiceItems: SubscriptionSchedules'UpdatePhasesAddInvoiceItems list option
        ApplicationFeePercent: decimal option
        BillingCycleAnchor: SubscriptionSchedules'UpdatePhasesBillingCycleAnchor option
        BillingThresholds: Choice<SubscriptionSchedules'UpdatePhasesBillingThresholdsBillingThresholds,string> option
        CollectionMethod: SubscriptionSchedules'UpdatePhasesCollectionMethod option
        Coupon: string option
        DefaultPaymentMethod: string option
        DefaultTaxRates: Choice<string list,string> option
        EndDate: Choice<int,SubscriptionSchedules'UpdatePhasesEndDate> option
        InvoiceSettings: SubscriptionSchedules'UpdatePhasesInvoiceSettings option
        Items: SubscriptionSchedules'UpdatePhasesItems list option
        Iterations: int option
        ProrationBehavior: SubscriptionSchedules'UpdatePhasesProrationBehavior option
        StartDate: Choice<int,SubscriptionSchedules'UpdatePhasesStartDate> option
        TransferData: SubscriptionSchedules'UpdatePhasesTransferData option
        Trial: bool option
        TrialEnd: Choice<int,SubscriptionSchedules'UpdatePhasesTrialEnd> option
    }
    with
        static member Create(?addInvoiceItems: SubscriptionSchedules'UpdatePhasesAddInvoiceItems list, ?transferData: SubscriptionSchedules'UpdatePhasesTransferData, ?startDate: Choice<int,SubscriptionSchedules'UpdatePhasesStartDate>, ?prorationBehavior: SubscriptionSchedules'UpdatePhasesProrationBehavior, ?iterations: int, ?items: SubscriptionSchedules'UpdatePhasesItems list, ?invoiceSettings: SubscriptionSchedules'UpdatePhasesInvoiceSettings, ?trial: bool, ?endDate: Choice<int,SubscriptionSchedules'UpdatePhasesEndDate>, ?defaultPaymentMethod: string, ?coupon: string, ?collectionMethod: SubscriptionSchedules'UpdatePhasesCollectionMethod, ?billingThresholds: Choice<SubscriptionSchedules'UpdatePhasesBillingThresholdsBillingThresholds,string>, ?billingCycleAnchor: SubscriptionSchedules'UpdatePhasesBillingCycleAnchor, ?applicationFeePercent: decimal, ?defaultTaxRates: Choice<string list,string>, ?trialEnd: Choice<int,SubscriptionSchedules'UpdatePhasesTrialEnd>) =
            {
                AddInvoiceItems = addInvoiceItems
                ApplicationFeePercent = applicationFeePercent
                BillingCycleAnchor = billingCycleAnchor
                BillingThresholds = billingThresholds
                CollectionMethod = collectionMethod
                Coupon = coupon
                DefaultPaymentMethod = defaultPaymentMethod
                DefaultTaxRates = defaultTaxRates
                EndDate = endDate
                InvoiceSettings = invoiceSettings
                Items = items
                Iterations = iterations
                ProrationBehavior = prorationBehavior
                StartDate = startDate
                TransferData = transferData
                Trial = trial
                TrialEnd = trialEnd
            }

    type SubscriptionSchedules'UpdateEndBehavior =
        | Cancel
        | None'
        | Release
        | Renew

    type SubscriptionSchedules'UpdateProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | None'

    type SubscriptionSchedules'UpdateOptions = {
        DefaultSettings: SubscriptionSchedules'UpdateDefaultSettings option
        EndBehavior: SubscriptionSchedules'UpdateEndBehavior option
        Expand: string list option
        Metadata: Map<string, string> option
        Phases: SubscriptionSchedules'UpdatePhases list option
        ProrationBehavior: SubscriptionSchedules'UpdateProrationBehavior option
    }
    with
        static member Create(?defaultSettings: SubscriptionSchedules'UpdateDefaultSettings, ?endBehavior: SubscriptionSchedules'UpdateEndBehavior, ?expand: string list, ?metadata: Map<string, string>, ?phases: SubscriptionSchedules'UpdatePhases list, ?prorationBehavior: SubscriptionSchedules'UpdateProrationBehavior) =
            {
                DefaultSettings = defaultSettings
                EndBehavior = endBehavior
                Expand = expand
                Metadata = metadata
                Phases = phases
                ProrationBehavior = prorationBehavior
            }

    type SubscriptionSchedulesCancel'CancelOptions = {
        Expand: string list option
        InvoiceNow: bool option
        Prorate: bool option
    }
    with
        static member Create(?expand: string list, ?invoiceNow: bool, ?prorate: bool) =
            {
                Expand = expand
                InvoiceNow = invoiceNow
                Prorate = prorate
            }

    type SubscriptionSchedulesRelease'ReleaseOptions = {
        Expand: string list option
        PreserveCancelDate: bool option
    }
    with
        static member Create(?expand: string list, ?preserveCancelDate: bool) =
            {
                Expand = expand
                PreserveCancelDate = preserveCancelDate
            }

    type Subscriptions'CreateAddInvoiceItemsPriceData = {
        Currency: string option
        Product: string option
        UnitAmount: int option
        UnitAmountDecimal: string option
    }
    with
        static member Create(?currency: string, ?product: string, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Subscriptions'CreateAddInvoiceItems = {
        Price: string option
        PriceData: Subscriptions'CreateAddInvoiceItemsPriceData option
        Quantity: int option
        TaxRates: Choice<string list,string> option
    }
    with
        static member Create(?price: string, ?priceData: Subscriptions'CreateAddInvoiceItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Subscriptions'CreateBillingThresholdsBillingThresholds = {
        AmountGte: int option
        ResetBillingCycleAnchor: bool option
    }
    with
        static member Create(?amountGte: int, ?resetBillingCycleAnchor: bool) =
            {
                AmountGte = amountGte
                ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type Subscriptions'CreateItemsBillingThresholdsItemBillingThresholds = {
        UsageGte: int option
    }
    with
        static member Create(?usageGte: int) =
            {
                UsageGte = usageGte
            }

    type Subscriptions'CreateItemsPriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    type Subscriptions'CreateItemsPriceDataRecurring = {
        Interval: Subscriptions'CreateItemsPriceDataRecurringInterval option
        IntervalCount: int option
    }
    with
        static member Create(?interval: Subscriptions'CreateItemsPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Subscriptions'CreateItemsPriceData = {
        Currency: string option
        Product: string option
        Recurring: Subscriptions'CreateItemsPriceDataRecurring option
        UnitAmount: int option
        UnitAmountDecimal: string option
    }
    with
        static member Create(?currency: string, ?product: string, ?recurring: Subscriptions'CreateItemsPriceDataRecurring, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Subscriptions'CreateItems = {
        BillingThresholds: Choice<Subscriptions'CreateItemsBillingThresholdsItemBillingThresholds,string> option
        Metadata: Map<string, string> option
        Plan: string option
        Price: string option
        PriceData: Subscriptions'CreateItemsPriceData option
        Quantity: int option
        TaxRates: Choice<string list,string> option
    }
    with
        static member Create(?billingThresholds: Choice<Subscriptions'CreateItemsBillingThresholdsItemBillingThresholds,string>, ?metadata: Map<string, string>, ?plan: string, ?price: string, ?priceData: Subscriptions'CreateItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                BillingThresholds = billingThresholds
                Metadata = metadata
                Plan = plan
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Subscriptions'CreatePendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval =
        | Day
        | Month
        | Week
        | Year

    type Subscriptions'CreatePendingInvoiceItemIntervalPendingInvoiceItemIntervalParams = {
        Interval: Subscriptions'CreatePendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval option
        IntervalCount: int option
    }
    with
        static member Create(?interval: Subscriptions'CreatePendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Subscriptions'CreateTransferData = {
        AmountPercent: decimal option
        Destination: string option
    }
    with
        static member Create(?amountPercent: decimal, ?destination: string) =
            {
                AmountPercent = amountPercent
                Destination = destination
            }

    type Subscriptions'CreateTrialEnd =
        | Now

    type Subscriptions'CreateCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    type Subscriptions'CreatePaymentBehavior =
        | AllowIncomplete
        | ErrorIfIncomplete
        | PendingIfIncomplete

    type Subscriptions'CreateProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | None'

    type Subscriptions'CreateOptions = {
        AddInvoiceItems: Subscriptions'CreateAddInvoiceItems list option
        ApplicationFeePercent: decimal option
        BackdateStartDate: DateTime option
        BillingCycleAnchor: DateTime option
        BillingThresholds: Choice<Subscriptions'CreateBillingThresholdsBillingThresholds,string> option
        CancelAt: DateTime option
        CancelAtPeriodEnd: bool option
        CollectionMethod: Subscriptions'CreateCollectionMethod option
        Coupon: string option
        Customer: string
        DaysUntilDue: int option
        DefaultPaymentMethod: string option
        DefaultSource: string option
        DefaultTaxRates: Choice<string list,string> option
        Expand: string list option
        Items: Subscriptions'CreateItems list option
        Metadata: Map<string, string> option
        OffSession: bool option
        PaymentBehavior: Subscriptions'CreatePaymentBehavior option
        PendingInvoiceItemInterval: Choice<Subscriptions'CreatePendingInvoiceItemIntervalPendingInvoiceItemIntervalParams,string> option
        PromotionCode: string option
        ProrationBehavior: Subscriptions'CreateProrationBehavior option
        TransferData: Subscriptions'CreateTransferData option
        TrialEnd: Choice<Subscriptions'CreateTrialEnd,DateTime> option
        TrialFromPlan: bool option
        TrialPeriodDays: int option
    }
    with
        static member Create(customer: string, ?addInvoiceItems: Subscriptions'CreateAddInvoiceItems list, ?trialEnd: Choice<Subscriptions'CreateTrialEnd,DateTime>, ?transferData: Subscriptions'CreateTransferData, ?prorationBehavior: Subscriptions'CreateProrationBehavior, ?promotionCode: string, ?pendingInvoiceItemInterval: Choice<Subscriptions'CreatePendingInvoiceItemIntervalPendingInvoiceItemIntervalParams,string>, ?paymentBehavior: Subscriptions'CreatePaymentBehavior, ?offSession: bool, ?metadata: Map<string, string>, ?items: Subscriptions'CreateItems list, ?expand: string list, ?defaultTaxRates: Choice<string list,string>, ?defaultSource: string, ?defaultPaymentMethod: string, ?daysUntilDue: int, ?coupon: string, ?collectionMethod: Subscriptions'CreateCollectionMethod, ?cancelAtPeriodEnd: bool, ?cancelAt: DateTime, ?billingThresholds: Choice<Subscriptions'CreateBillingThresholdsBillingThresholds,string>, ?billingCycleAnchor: DateTime, ?backdateStartDate: DateTime, ?applicationFeePercent: decimal, ?trialFromPlan: bool, ?trialPeriodDays: int) =
            {
                AddInvoiceItems = addInvoiceItems
                ApplicationFeePercent = applicationFeePercent
                BackdateStartDate = backdateStartDate
                BillingCycleAnchor = billingCycleAnchor
                BillingThresholds = billingThresholds
                CancelAt = cancelAt
                CancelAtPeriodEnd = cancelAtPeriodEnd
                CollectionMethod = collectionMethod
                Coupon = coupon
                Customer = customer
                DaysUntilDue = daysUntilDue
                DefaultPaymentMethod = defaultPaymentMethod
                DefaultSource = defaultSource
                DefaultTaxRates = defaultTaxRates
                Expand = expand
                Items = items
                Metadata = metadata
                OffSession = offSession
                PaymentBehavior = paymentBehavior
                PendingInvoiceItemInterval = pendingInvoiceItemInterval
                PromotionCode = promotionCode
                ProrationBehavior = prorationBehavior
                TransferData = transferData
                TrialEnd = trialEnd
                TrialFromPlan = trialFromPlan
                TrialPeriodDays = trialPeriodDays
            }

    type Subscriptions'CancelOptions = {
        Expand: string list option
        InvoiceNow: bool option
        Prorate: bool option
    }
    with
        static member Create(?expand: string list, ?invoiceNow: bool, ?prorate: bool) =
            {
                Expand = expand
                InvoiceNow = invoiceNow
                Prorate = prorate
            }

    type Subscriptions'UpdateAddInvoiceItemsPriceData = {
        Currency: string option
        Product: string option
        UnitAmount: int option
        UnitAmountDecimal: string option
    }
    with
        static member Create(?currency: string, ?product: string, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Subscriptions'UpdateAddInvoiceItems = {
        Price: string option
        PriceData: Subscriptions'UpdateAddInvoiceItemsPriceData option
        Quantity: int option
        TaxRates: Choice<string list,string> option
    }
    with
        static member Create(?price: string, ?priceData: Subscriptions'UpdateAddInvoiceItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Subscriptions'UpdateBillingThresholdsBillingThresholds = {
        AmountGte: int option
        ResetBillingCycleAnchor: bool option
    }
    with
        static member Create(?amountGte: int, ?resetBillingCycleAnchor: bool) =
            {
                AmountGte = amountGte
                ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type Subscriptions'UpdateItemsBillingThresholdsItemBillingThresholds = {
        UsageGte: int option
    }
    with
        static member Create(?usageGte: int) =
            {
                UsageGte = usageGte
            }

    type Subscriptions'UpdateItemsPriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    type Subscriptions'UpdateItemsPriceDataRecurring = {
        Interval: Subscriptions'UpdateItemsPriceDataRecurringInterval option
        IntervalCount: int option
    }
    with
        static member Create(?interval: Subscriptions'UpdateItemsPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Subscriptions'UpdateItemsPriceData = {
        Currency: string option
        Product: string option
        Recurring: Subscriptions'UpdateItemsPriceDataRecurring option
        UnitAmount: int option
        UnitAmountDecimal: string option
    }
    with
        static member Create(?currency: string, ?product: string, ?recurring: Subscriptions'UpdateItemsPriceDataRecurring, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Subscriptions'UpdateItems = {
        BillingThresholds: Choice<Subscriptions'UpdateItemsBillingThresholdsItemBillingThresholds,string> option
        ClearUsage: bool option
        Deleted: bool option
        Id: string option
        Metadata: Map<string, string> option
        Plan: string option
        Price: string option
        PriceData: Subscriptions'UpdateItemsPriceData option
        Quantity: int option
        TaxRates: Choice<string list,string> option
    }
    with
        static member Create(?billingThresholds: Choice<Subscriptions'UpdateItemsBillingThresholdsItemBillingThresholds,string>, ?clearUsage: bool, ?deleted: bool, ?id: string, ?metadata: Map<string, string>, ?plan: string, ?price: string, ?priceData: Subscriptions'UpdateItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                BillingThresholds = billingThresholds
                ClearUsage = clearUsage
                Deleted = deleted
                Id = id
                Metadata = metadata
                Plan = plan
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Subscriptions'UpdatePauseCollectionPauseCollectionBehavior =
        | KeepAsDraft
        | MarkUncollectible
        | Void

    type Subscriptions'UpdatePauseCollectionPauseCollection = {
        Behavior: Subscriptions'UpdatePauseCollectionPauseCollectionBehavior option
        ResumesAt: DateTime option
    }
    with
        static member Create(?behavior: Subscriptions'UpdatePauseCollectionPauseCollectionBehavior, ?resumesAt: DateTime) =
            {
                Behavior = behavior
                ResumesAt = resumesAt
            }

    type Subscriptions'UpdatePendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval =
        | Day
        | Month
        | Week
        | Year

    type Subscriptions'UpdatePendingInvoiceItemIntervalPendingInvoiceItemIntervalParams = {
        Interval: Subscriptions'UpdatePendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval option
        IntervalCount: int option
    }
    with
        static member Create(?interval: Subscriptions'UpdatePendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Subscriptions'UpdateTransferDataTransferDataSpecs = {
        AmountPercent: decimal option
        Destination: string option
    }
    with
        static member Create(?amountPercent: decimal, ?destination: string) =
            {
                AmountPercent = amountPercent
                Destination = destination
            }

    type Subscriptions'UpdateTrialEnd =
        | Now

    type Subscriptions'UpdateBillingCycleAnchor =
        | Now
        | Unchanged

    type Subscriptions'UpdateCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    type Subscriptions'UpdatePaymentBehavior =
        | AllowIncomplete
        | ErrorIfIncomplete
        | PendingIfIncomplete

    type Subscriptions'UpdateProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | None'

    type Subscriptions'UpdateOptions = {
        AddInvoiceItems: Subscriptions'UpdateAddInvoiceItems list option
        ApplicationFeePercent: decimal option
        BillingCycleAnchor: Subscriptions'UpdateBillingCycleAnchor option
        BillingThresholds: Choice<Subscriptions'UpdateBillingThresholdsBillingThresholds,string> option
        CancelAt: Choice<DateTime,string> option
        CancelAtPeriodEnd: bool option
        CollectionMethod: Subscriptions'UpdateCollectionMethod option
        Coupon: string option
        DaysUntilDue: int option
        DefaultPaymentMethod: string option
        DefaultSource: string option
        DefaultTaxRates: Choice<string list,string> option
        Expand: string list option
        Items: Subscriptions'UpdateItems list option
        Metadata: Map<string, string> option
        OffSession: bool option
        PauseCollection: Choice<Subscriptions'UpdatePauseCollectionPauseCollection,string> option
        PaymentBehavior: Subscriptions'UpdatePaymentBehavior option
        PendingInvoiceItemInterval: Choice<Subscriptions'UpdatePendingInvoiceItemIntervalPendingInvoiceItemIntervalParams,string> option
        PromotionCode: string option
        ProrationBehavior: Subscriptions'UpdateProrationBehavior option
        ProrationDate: DateTime option
        TransferData: Choice<Subscriptions'UpdateTransferDataTransferDataSpecs,string> option
        TrialEnd: Choice<Subscriptions'UpdateTrialEnd,DateTime> option
        TrialFromPlan: bool option
    }
    with
        static member Create(?addInvoiceItems: Subscriptions'UpdateAddInvoiceItems list, ?transferData: Choice<Subscriptions'UpdateTransferDataTransferDataSpecs,string>, ?prorationDate: DateTime, ?prorationBehavior: Subscriptions'UpdateProrationBehavior, ?promotionCode: string, ?pendingInvoiceItemInterval: Choice<Subscriptions'UpdatePendingInvoiceItemIntervalPendingInvoiceItemIntervalParams,string>, ?paymentBehavior: Subscriptions'UpdatePaymentBehavior, ?pauseCollection: Choice<Subscriptions'UpdatePauseCollectionPauseCollection,string>, ?offSession: bool, ?metadata: Map<string, string>, ?items: Subscriptions'UpdateItems list, ?trialEnd: Choice<Subscriptions'UpdateTrialEnd,DateTime>, ?expand: string list, ?defaultSource: string, ?defaultPaymentMethod: string, ?daysUntilDue: int, ?coupon: string, ?collectionMethod: Subscriptions'UpdateCollectionMethod, ?cancelAtPeriodEnd: bool, ?cancelAt: Choice<DateTime,string>, ?billingThresholds: Choice<Subscriptions'UpdateBillingThresholdsBillingThresholds,string>, ?billingCycleAnchor: Subscriptions'UpdateBillingCycleAnchor, ?applicationFeePercent: decimal, ?defaultTaxRates: Choice<string list,string>, ?trialFromPlan: bool) =
            {
                AddInvoiceItems = addInvoiceItems
                ApplicationFeePercent = applicationFeePercent
                BillingCycleAnchor = billingCycleAnchor
                BillingThresholds = billingThresholds
                CancelAt = cancelAt
                CancelAtPeriodEnd = cancelAtPeriodEnd
                CollectionMethod = collectionMethod
                Coupon = coupon
                DaysUntilDue = daysUntilDue
                DefaultPaymentMethod = defaultPaymentMethod
                DefaultSource = defaultSource
                DefaultTaxRates = defaultTaxRates
                Expand = expand
                Items = items
                Metadata = metadata
                OffSession = offSession
                PauseCollection = pauseCollection
                PaymentBehavior = paymentBehavior
                PendingInvoiceItemInterval = pendingInvoiceItemInterval
                PromotionCode = promotionCode
                ProrationBehavior = prorationBehavior
                ProrationDate = prorationDate
                TransferData = transferData
                TrialEnd = trialEnd
                TrialFromPlan = trialFromPlan
            }

    type TaxRates'CreateOptions = {
        Active: bool option
        Description: string option
        DisplayName: string
        Expand: string list option
        Inclusive: bool
        Jurisdiction: string option
        Metadata: Map<string, string> option
        Percentage: decimal
    }
    with
        static member Create(displayName: string, inclusive: bool, percentage: decimal, ?active: bool, ?description: string, ?expand: string list, ?jurisdiction: string, ?metadata: Map<string, string>) =
            {
                Active = active
                Description = description
                DisplayName = displayName
                Expand = expand
                Inclusive = inclusive
                Jurisdiction = jurisdiction
                Metadata = metadata
                Percentage = percentage
            }

    type TaxRates'UpdateOptions = {
        Active: bool option
        Description: string option
        DisplayName: string option
        Expand: string list option
        Jurisdiction: string option
        Metadata: Map<string, string> option
    }
    with
        static member Create(?active: bool, ?description: string, ?displayName: string, ?expand: string list, ?jurisdiction: string, ?metadata: Map<string, string>) =
            {
                Active = active
                Description = description
                DisplayName = displayName
                Expand = expand
                Jurisdiction = jurisdiction
                Metadata = metadata
            }

    type TerminalConnectionTokens'CreateOptions = {
        Expand: string list option
        Location: string option
    }
    with
        static member Create(?expand: string list, ?location: string) =
            {
                Expand = expand
                Location = location
            }

    type TerminalLocations'CreateAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type TerminalLocations'CreateOptions = {
        Address: TerminalLocations'CreateAddress
        DisplayName: string
        Expand: string list option
        Metadata: Map<string, string> option
    }
    with
        static member Create(address: TerminalLocations'CreateAddress, displayName: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Address = address
                DisplayName = displayName
                Expand = expand
                Metadata = metadata
            }

    type TerminalLocations'UpdateAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type TerminalLocations'UpdateOptions = {
        Address: TerminalLocations'UpdateAddress option
        DisplayName: string option
        Expand: string list option
        Metadata: Map<string, string> option
    }
    with
        static member Create(?address: TerminalLocations'UpdateAddress, ?displayName: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Address = address
                DisplayName = displayName
                Expand = expand
                Metadata = metadata
            }

    type TerminalReaders'CreateOptions = {
        Expand: string list option
        Label: string option
        Location: string option
        Metadata: Map<string, string> option
        RegistrationCode: string
    }
    with
        static member Create(registrationCode: string, ?expand: string list, ?label: string, ?location: string, ?metadata: Map<string, string>) =
            {
                Expand = expand
                Label = label
                Location = location
                Metadata = metadata
                RegistrationCode = registrationCode
            }

    type TerminalReaders'UpdateOptions = {
        Expand: string list option
        Label: string option
        Metadata: Map<string, string> option
    }
    with
        static member Create(?expand: string list, ?label: string, ?metadata: Map<string, string>) =
            {
                Expand = expand
                Label = label
                Metadata = metadata
            }

    type Tokens'CreateAccountCompanyAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Tokens'CreateAccountCompanyAddressKana = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
        Town: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Tokens'CreateAccountCompanyAddressKanji = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
        Town: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Tokens'CreateAccountCompanyVerificationDocument = {
        Back: string option
        Front: string option
    }
    with
        static member Create(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Tokens'CreateAccountCompanyVerification = {
        Document: Tokens'CreateAccountCompanyVerificationDocument option
    }
    with
        static member Create(?document: Tokens'CreateAccountCompanyVerificationDocument) =
            {
                Document = document
            }

    type Tokens'CreateAccountCompanyStructure =
        | GovernmentInstrumentality
        | GovernmentalUnit
        | IncorporatedNonProfit
        | LimitedLiabilityPartnership
        | MultiMemberLlc
        | PrivateCompany
        | PrivateCorporation
        | PrivatePartnership
        | PublicCompany
        | PublicCorporation
        | PublicPartnership
        | SoleProprietorship
        | TaxExemptGovernmentInstrumentality
        | UnincorporatedAssociation
        | UnincorporatedNonProfit

    type Tokens'CreateAccountCompany = {
        Address: Tokens'CreateAccountCompanyAddress option
        AddressKana: Tokens'CreateAccountCompanyAddressKana option
        AddressKanji: Tokens'CreateAccountCompanyAddressKanji option
        DirectorsProvided: bool option
        ExecutivesProvided: bool option
        Name: string option
        NameKana: string option
        NameKanji: string option
        OwnersProvided: bool option
        Phone: string option
        RegistrationNumber: string option
        Structure: Tokens'CreateAccountCompanyStructure option
        TaxId: string option
        TaxIdRegistrar: string option
        VatId: string option
        Verification: Tokens'CreateAccountCompanyVerification option
    }
    with
        static member Create(?address: Tokens'CreateAccountCompanyAddress, ?addressKana: Tokens'CreateAccountCompanyAddressKana, ?addressKanji: Tokens'CreateAccountCompanyAddressKanji, ?directorsProvided: bool, ?executivesProvided: bool, ?name: string, ?nameKana: string, ?nameKanji: string, ?ownersProvided: bool, ?phone: string, ?registrationNumber: string, ?structure: Tokens'CreateAccountCompanyStructure, ?taxId: string, ?taxIdRegistrar: string, ?vatId: string, ?verification: Tokens'CreateAccountCompanyVerification) =
            {
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                DirectorsProvided = directorsProvided
                ExecutivesProvided = executivesProvided
                Name = name
                NameKana = nameKana
                NameKanji = nameKanji
                OwnersProvided = ownersProvided
                Phone = phone
                RegistrationNumber = registrationNumber
                Structure = structure
                TaxId = taxId
                TaxIdRegistrar = taxIdRegistrar
                VatId = vatId
                Verification = verification
            }

    type Tokens'CreateAccountIndividualAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Tokens'CreateAccountIndividualAddressKana = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
        Town: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Tokens'CreateAccountIndividualAddressKanji = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
        Town: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Tokens'CreateAccountIndividualDobDateOfBirthSpecs = {
        Day: int option
        Month: int option
        Year: int option
    }
    with
        static member Create(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Tokens'CreateAccountIndividualVerificationAdditionalDocument = {
        Back: string option
        Front: string option
    }
    with
        static member Create(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Tokens'CreateAccountIndividualVerificationDocument = {
        Back: string option
        Front: string option
    }
    with
        static member Create(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Tokens'CreateAccountIndividualVerification = {
        AdditionalDocument: Tokens'CreateAccountIndividualVerificationAdditionalDocument option
        Document: Tokens'CreateAccountIndividualVerificationDocument option
    }
    with
        static member Create(?additionalDocument: Tokens'CreateAccountIndividualVerificationAdditionalDocument, ?document: Tokens'CreateAccountIndividualVerificationDocument) =
            {
                AdditionalDocument = additionalDocument
                Document = document
            }

    type Tokens'CreateAccountIndividualPoliticalExposure =
        | Existing
        | None'

    type Tokens'CreateAccountIndividual = {
        Address: Tokens'CreateAccountIndividualAddress option
        AddressKana: Tokens'CreateAccountIndividualAddressKana option
        AddressKanji: Tokens'CreateAccountIndividualAddressKanji option
        Dob: Choice<Tokens'CreateAccountIndividualDobDateOfBirthSpecs,string> option
        Email: string option
        FirstName: string option
        FirstNameKana: string option
        FirstNameKanji: string option
        Gender: string option
        IdNumber: string option
        LastName: string option
        LastNameKana: string option
        LastNameKanji: string option
        MaidenName: string option
        Metadata: Map<string, string> option
        Phone: string option
        PoliticalExposure: Tokens'CreateAccountIndividualPoliticalExposure option
        SsnLast4: string option
        Verification: Tokens'CreateAccountIndividualVerification option
    }
    with
        static member Create(?address: Tokens'CreateAccountIndividualAddress, ?politicalExposure: Tokens'CreateAccountIndividualPoliticalExposure, ?phone: string, ?metadata: Map<string, string>, ?maidenName: string, ?lastNameKanji: string, ?lastNameKana: string, ?lastName: string, ?ssnLast4: string, ?idNumber: string, ?firstNameKanji: string, ?firstNameKana: string, ?firstName: string, ?email: string, ?dob: Choice<Tokens'CreateAccountIndividualDobDateOfBirthSpecs,string>, ?addressKanji: Tokens'CreateAccountIndividualAddressKanji, ?addressKana: Tokens'CreateAccountIndividualAddressKana, ?gender: string, ?verification: Tokens'CreateAccountIndividualVerification) =
            {
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                Dob = dob
                Email = email
                FirstName = firstName
                FirstNameKana = firstNameKana
                FirstNameKanji = firstNameKanji
                Gender = gender
                IdNumber = idNumber
                LastName = lastName
                LastNameKana = lastNameKana
                LastNameKanji = lastNameKanji
                MaidenName = maidenName
                Metadata = metadata
                Phone = phone
                PoliticalExposure = politicalExposure
                SsnLast4 = ssnLast4
                Verification = verification
            }

    type Tokens'CreateAccountBusinessType =
        | Company
        | GovernmentEntity
        | Individual
        | NonProfit

    type Tokens'CreateAccount = {
        BusinessType: Tokens'CreateAccountBusinessType option
        Company: Tokens'CreateAccountCompany option
        Individual: Tokens'CreateAccountIndividual option
        TosShownAndAccepted: bool option
    }
    with
        static member Create(?businessType: Tokens'CreateAccountBusinessType, ?company: Tokens'CreateAccountCompany, ?individual: Tokens'CreateAccountIndividual, ?tosShownAndAccepted: bool) =
            {
                BusinessType = businessType
                Company = company
                Individual = individual
                TosShownAndAccepted = tosShownAndAccepted
            }

    type Tokens'CreateBankAccountAccountHolderType =
        | Company
        | Individual

    type Tokens'CreateBankAccount = {
        AccountHolderName: string option
        AccountHolderType: Tokens'CreateBankAccountAccountHolderType option
        AccountNumber: string option
        Country: string option
        Currency: string option
        RoutingNumber: string option
    }
    with
        static member Create(?accountHolderName: string, ?accountHolderType: Tokens'CreateBankAccountAccountHolderType, ?accountNumber: string, ?country: string, ?currency: string, ?routingNumber: string) =
            {
                AccountHolderName = accountHolderName
                AccountHolderType = accountHolderType
                AccountNumber = accountNumber
                Country = country
                Currency = currency
                RoutingNumber = routingNumber
            }

    type Tokens'CreateCardCreditCardSpecs = {
        AddressCity: string option
        AddressCountry: string option
        AddressLine1: string option
        AddressLine2: string option
        AddressState: string option
        AddressZip: string option
        Currency: string option
        Cvc: string option
        ExpMonth: string option
        ExpYear: string option
        Name: string option
        Number: string option
    }
    with
        static member Create(?addressCity: string, ?addressCountry: string, ?addressLine1: string, ?addressLine2: string, ?addressState: string, ?addressZip: string, ?currency: string, ?cvc: string, ?expMonth: string, ?expYear: string, ?name: string, ?number: string) =
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
                Number = number
            }

    type Tokens'CreateCvcUpdate = {
        Cvc: string option
    }
    with
        static member Create(?cvc: string) =
            {
                Cvc = cvc
            }

    type Tokens'CreatePersonAddress = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Tokens'CreatePersonAddressKana = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
        Town: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Tokens'CreatePersonAddressKanji = {
        City: string option
        Country: string option
        Line1: string option
        Line2: string option
        PostalCode: string option
        State: string option
        Town: string option
    }
    with
        static member Create(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Tokens'CreatePersonDobDateOfBirthSpecs = {
        Day: int option
        Month: int option
        Year: int option
    }
    with
        static member Create(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Tokens'CreatePersonRelationship = {
        Director: bool option
        Executive: bool option
        Owner: bool option
        PercentOwnership: Choice<decimal,string> option
        Representative: bool option
        Title: string option
    }
    with
        static member Create(?director: bool, ?executive: bool, ?owner: bool, ?percentOwnership: Choice<decimal,string>, ?representative: bool, ?title: string) =
            {
                Director = director
                Executive = executive
                Owner = owner
                PercentOwnership = percentOwnership
                Representative = representative
                Title = title
            }

    type Tokens'CreatePersonVerificationAdditionalDocument = {
        Back: string option
        Front: string option
    }
    with
        static member Create(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Tokens'CreatePersonVerificationDocument = {
        Back: string option
        Front: string option
    }
    with
        static member Create(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Tokens'CreatePersonVerification = {
        AdditionalDocument: Tokens'CreatePersonVerificationAdditionalDocument option
        Document: Tokens'CreatePersonVerificationDocument option
    }
    with
        static member Create(?additionalDocument: Tokens'CreatePersonVerificationAdditionalDocument, ?document: Tokens'CreatePersonVerificationDocument) =
            {
                AdditionalDocument = additionalDocument
                Document = document
            }

    type Tokens'CreatePerson = {
        Address: Tokens'CreatePersonAddress option
        AddressKana: Tokens'CreatePersonAddressKana option
        AddressKanji: Tokens'CreatePersonAddressKanji option
        Dob: Choice<Tokens'CreatePersonDobDateOfBirthSpecs,string> option
        Email: string option
        FirstName: string option
        FirstNameKana: string option
        FirstNameKanji: string option
        Gender: string option
        IdNumber: string option
        LastName: string option
        LastNameKana: string option
        LastNameKanji: string option
        MaidenName: string option
        Metadata: Map<string, string> option
        Phone: string option
        PoliticalExposure: string option
        Relationship: Tokens'CreatePersonRelationship option
        SsnLast4: string option
        Verification: Tokens'CreatePersonVerification option
    }
    with
        static member Create(?address: Tokens'CreatePersonAddress, ?relationship: Tokens'CreatePersonRelationship, ?politicalExposure: string, ?phone: string, ?metadata: Map<string, string>, ?maidenName: string, ?lastNameKanji: string, ?lastNameKana: string, ?lastName: string, ?idNumber: string, ?gender: string, ?firstNameKanji: string, ?firstNameKana: string, ?firstName: string, ?email: string, ?dob: Choice<Tokens'CreatePersonDobDateOfBirthSpecs,string>, ?addressKanji: Tokens'CreatePersonAddressKanji, ?addressKana: Tokens'CreatePersonAddressKana, ?ssnLast4: string, ?verification: Tokens'CreatePersonVerification) =
            {
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                Dob = dob
                Email = email
                FirstName = firstName
                FirstNameKana = firstNameKana
                FirstNameKanji = firstNameKanji
                Gender = gender
                IdNumber = idNumber
                LastName = lastName
                LastNameKana = lastNameKana
                LastNameKanji = lastNameKanji
                MaidenName = maidenName
                Metadata = metadata
                Phone = phone
                PoliticalExposure = politicalExposure
                Relationship = relationship
                SsnLast4 = ssnLast4
                Verification = verification
            }

    type Tokens'CreatePii = {
        IdNumber: string option
    }
    with
        static member Create(?idNumber: string) =
            {
                IdNumber = idNumber
            }

    type Tokens'CreateOptions = {
        Account: Tokens'CreateAccount option
        BankAccount: Tokens'CreateBankAccount option
        Card: Choice<Tokens'CreateCardCreditCardSpecs,string> option
        Customer: string option
        CvcUpdate: Tokens'CreateCvcUpdate option
        Expand: string list option
        Person: Tokens'CreatePerson option
        Pii: Tokens'CreatePii option
    }
    with
        static member Create(?account: Tokens'CreateAccount, ?bankAccount: Tokens'CreateBankAccount, ?card: Choice<Tokens'CreateCardCreditCardSpecs,string>, ?customer: string, ?cvcUpdate: Tokens'CreateCvcUpdate, ?expand: string list, ?person: Tokens'CreatePerson, ?pii: Tokens'CreatePii) =
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

    type Topups'CreateOptions = {
        Amount: int
        Currency: string
        Description: string option
        Expand: string list option
        Metadata: Map<string, string> option
        Source: string option
        StatementDescriptor: string option
        TransferGroup: string option
    }
    with
        static member Create(amount: int, currency: string, ?description: string, ?expand: string list, ?metadata: Map<string, string>, ?source: string, ?statementDescriptor: string, ?transferGroup: string) =
            {
                Amount = amount
                Currency = currency
                Description = description
                Expand = expand
                Metadata = metadata
                Source = source
                StatementDescriptor = statementDescriptor
                TransferGroup = transferGroup
            }

    type Topups'UpdateOptions = {
        Description: string option
        Expand: string list option
        Metadata: Map<string, string> option
    }
    with
        static member Create(?description: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Description = description
                Expand = expand
                Metadata = metadata
            }

    type TopupsCancel'CancelOptions = {
        Expand: string list option
    }
    with
        static member Create(?expand: string list) =
            {
                Expand = expand
            }

    type Transfers'CreateSourceType =
        | BankAccount
        | Card
        | Fpx

    type Transfers'CreateOptions = {
        Amount: int option
        Currency: string
        Description: string option
        Destination: string
        Expand: string list option
        Metadata: Map<string, string> option
        SourceTransaction: string option
        SourceType: Transfers'CreateSourceType option
        TransferGroup: string option
    }
    with
        static member Create(currency: string, destination: string, ?amount: int, ?description: string, ?expand: string list, ?metadata: Map<string, string>, ?sourceTransaction: string, ?sourceType: Transfers'CreateSourceType, ?transferGroup: string) =
            {
                Amount = amount
                Currency = currency
                Description = description
                Destination = destination
                Expand = expand
                Metadata = metadata
                SourceTransaction = sourceTransaction
                SourceType = sourceType
                TransferGroup = transferGroup
            }

    type TransfersReversals'CreateOptions = {
        Amount: int option
        Description: string option
        Expand: string list option
        Metadata: Map<string, string> option
        RefundApplicationFee: bool option
    }
    with
        static member Create(?amount: int, ?description: string, ?expand: string list, ?metadata: Map<string, string>, ?refundApplicationFee: bool) =
            {
                Amount = amount
                Description = description
                Expand = expand
                Metadata = metadata
                RefundApplicationFee = refundApplicationFee
            }

    type Transfers'UpdateOptions = {
        Description: string option
        Expand: string list option
        Metadata: Map<string, string> option
    }
    with
        static member Create(?description: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Description = description
                Expand = expand
                Metadata = metadata
            }

    type TransfersReversals'UpdateOptions = {
        Expand: string list option
        Metadata: Map<string, string> option
    }
    with
        static member Create(?expand: string list, ?metadata: Map<string, string>) =
            {
                Expand = expand
                Metadata = metadata
            }

    type WebhookEndpoints'CreateEnabledEvents =
        | Asterix
        | AccountApplicationAuthorized
        | AccountApplicationDeauthorized
        | AccountExternalAccountCreated
        | AccountExternalAccountDeleted
        | AccountExternalAccountUpdated
        | AccountUpdated
        | ApplicationFeeCreated
        | ApplicationFeeRefundUpdated
        | ApplicationFeeRefunded
        | BalanceAvailable
        | CapabilityUpdated
        | ChargeCaptured
        | ChargeDisputeClosed
        | ChargeDisputeCreated
        | ChargeDisputeFundsReinstated
        | ChargeDisputeFundsWithdrawn
        | ChargeDisputeUpdated
        | ChargeExpired
        | ChargeFailed
        | ChargePending
        | ChargeRefundUpdated
        | ChargeRefunded
        | ChargeSucceeded
        | ChargeUpdated
        | CheckoutSessionAsyncPaymentFailed
        | CheckoutSessionAsyncPaymentSucceeded
        | CheckoutSessionCompleted
        | CouponCreated
        | CouponDeleted
        | CouponUpdated
        | CreditNoteCreated
        | CreditNoteUpdated
        | CreditNoteVoided
        | CustomerCreated
        | CustomerDeleted
        | CustomerDiscountCreated
        | CustomerDiscountDeleted
        | CustomerDiscountUpdated
        | CustomerSourceCreated
        | CustomerSourceDeleted
        | CustomerSourceExpiring
        | CustomerSourceUpdated
        | CustomerSubscriptionCreated
        | CustomerSubscriptionDeleted
        | CustomerSubscriptionPendingUpdateApplied
        | CustomerSubscriptionPendingUpdateExpired
        | CustomerSubscriptionTrialWillEnd
        | CustomerSubscriptionUpdated
        | CustomerTaxIdCreated
        | CustomerTaxIdDeleted
        | CustomerTaxIdUpdated
        | CustomerUpdated
        | FileCreated
        | InvoiceCreated
        | InvoiceDeleted
        | InvoiceFinalizationFailed
        | InvoiceFinalized
        | InvoiceMarkedUncollectible
        | InvoicePaid
        | InvoicePaymentActionRequired
        | InvoicePaymentFailed
        | InvoicePaymentSucceeded
        | InvoiceSent
        | InvoiceUpcoming
        | InvoiceUpdated
        | InvoiceVoided
        | InvoiceitemCreated
        | InvoiceitemDeleted
        | InvoiceitemUpdated
        | IssuingAuthorizationCreated
        | IssuingAuthorizationRequest
        | IssuingAuthorizationUpdated
        | IssuingCardCreated
        | IssuingCardUpdated
        | IssuingCardholderCreated
        | IssuingCardholderUpdated
        | IssuingDisputeClosed
        | IssuingDisputeCreated
        | IssuingDisputeFundsReinstated
        | IssuingDisputeSubmitted
        | IssuingDisputeUpdated
        | IssuingTransactionCreated
        | IssuingTransactionUpdated
        | MandateUpdated
        | OrderCreated
        | OrderPaymentFailed
        | OrderPaymentSucceeded
        | OrderUpdated
        | OrderReturnCreated
        | PaymentIntentAmountCapturableUpdated
        | PaymentIntentCanceled
        | PaymentIntentCreated
        | PaymentIntentPaymentFailed
        | PaymentIntentProcessing
        | PaymentIntentRequiresAction
        | PaymentIntentSucceeded
        | PaymentMethodAttached
        | PaymentMethodAutomaticallyUpdated
        | PaymentMethodDetached
        | PaymentMethodUpdated
        | PayoutCanceled
        | PayoutCreated
        | PayoutFailed
        | PayoutPaid
        | PayoutUpdated
        | PersonCreated
        | PersonDeleted
        | PersonUpdated
        | PlanCreated
        | PlanDeleted
        | PlanUpdated
        | PriceCreated
        | PriceDeleted
        | PriceUpdated
        | ProductCreated
        | ProductDeleted
        | ProductUpdated
        | PromotionCodeCreated
        | PromotionCodeUpdated
        | RadarEarlyFraudWarningCreated
        | RadarEarlyFraudWarningUpdated
        | RecipientCreated
        | RecipientDeleted
        | RecipientUpdated
        | ReportingReportRunFailed
        | ReportingReportRunSucceeded
        | ReportingReportTypeUpdated
        | ReviewClosed
        | ReviewOpened
        | SetupIntentCanceled
        | SetupIntentCreated
        | SetupIntentRequiresAction
        | SetupIntentSetupFailed
        | SetupIntentSucceeded
        | SigmaScheduledQueryRunCreated
        | SkuCreated
        | SkuDeleted
        | SkuUpdated
        | SourceCanceled
        | SourceChargeable
        | SourceFailed
        | SourceMandateNotification
        | SourceRefundAttributesRequired
        | SourceTransactionCreated
        | SourceTransactionUpdated
        | SubscriptionScheduleAborted
        | SubscriptionScheduleCanceled
        | SubscriptionScheduleCompleted
        | SubscriptionScheduleCreated
        | SubscriptionScheduleExpiring
        | SubscriptionScheduleReleased
        | SubscriptionScheduleUpdated
        | TaxRateCreated
        | TaxRateUpdated
        | TopupCanceled
        | TopupCreated
        | TopupFailed
        | TopupReversed
        | TopupSucceeded
        | TransferCreated
        | TransferFailed
        | TransferPaid
        | TransferReversed
        | TransferUpdated

    type WebhookEndpoints'CreateApiVersion =
        | [<JsonUnionCase("2011-01-01")>] Numeric20110101
        | [<JsonUnionCase("2011-06-21")>] Numeric20110621
        | [<JsonUnionCase("2011-06-28")>] Numeric20110628
        | [<JsonUnionCase("2011-08-01")>] Numeric20110801
        | [<JsonUnionCase("2011-09-15")>] Numeric20110915
        | [<JsonUnionCase("2011-11-17")>] Numeric20111117
        | [<JsonUnionCase("2012-02-23")>] Numeric20120223
        | [<JsonUnionCase("2012-03-25")>] Numeric20120325
        | [<JsonUnionCase("2012-06-18")>] Numeric20120618
        | [<JsonUnionCase("2012-06-28")>] Numeric20120628
        | [<JsonUnionCase("2012-07-09")>] Numeric20120709
        | [<JsonUnionCase("2012-09-24")>] Numeric20120924
        | [<JsonUnionCase("2012-10-26")>] Numeric20121026
        | [<JsonUnionCase("2012-11-07")>] Numeric20121107
        | [<JsonUnionCase("2013-02-11")>] Numeric20130211
        | [<JsonUnionCase("2013-02-13")>] Numeric20130213
        | [<JsonUnionCase("2013-07-05")>] Numeric20130705
        | [<JsonUnionCase("2013-08-12")>] Numeric20130812
        | [<JsonUnionCase("2013-08-13")>] Numeric20130813
        | [<JsonUnionCase("2013-10-29")>] Numeric20131029
        | [<JsonUnionCase("2013-12-03")>] Numeric20131203
        | [<JsonUnionCase("2014-01-31")>] Numeric20140131
        | [<JsonUnionCase("2014-03-13")>] Numeric20140313
        | [<JsonUnionCase("2014-03-28")>] Numeric20140328
        | [<JsonUnionCase("2014-05-19")>] Numeric20140519
        | [<JsonUnionCase("2014-06-13")>] Numeric20140613
        | [<JsonUnionCase("2014-06-17")>] Numeric20140617
        | [<JsonUnionCase("2014-07-22")>] Numeric20140722
        | [<JsonUnionCase("2014-07-26")>] Numeric20140726
        | [<JsonUnionCase("2014-08-04")>] Numeric20140804
        | [<JsonUnionCase("2014-08-20")>] Numeric20140820
        | [<JsonUnionCase("2014-09-08")>] Numeric20140908
        | [<JsonUnionCase("2014-10-07")>] Numeric20141007
        | [<JsonUnionCase("2014-11-05")>] Numeric20141105
        | [<JsonUnionCase("2014-11-20")>] Numeric20141120
        | [<JsonUnionCase("2014-12-08")>] Numeric20141208
        | [<JsonUnionCase("2014-12-17")>] Numeric20141217
        | [<JsonUnionCase("2014-12-22")>] Numeric20141222
        | [<JsonUnionCase("2015-01-11")>] Numeric20150111
        | [<JsonUnionCase("2015-01-26")>] Numeric20150126
        | [<JsonUnionCase("2015-02-10")>] Numeric20150210
        | [<JsonUnionCase("2015-02-16")>] Numeric20150216
        | [<JsonUnionCase("2015-02-18")>] Numeric20150218
        | [<JsonUnionCase("2015-03-24")>] Numeric20150324
        | [<JsonUnionCase("2015-04-07")>] Numeric20150407
        | [<JsonUnionCase("2015-06-15")>] Numeric20150615
        | [<JsonUnionCase("2015-07-07")>] Numeric20150707
        | [<JsonUnionCase("2015-07-13")>] Numeric20150713
        | [<JsonUnionCase("2015-07-28")>] Numeric20150728
        | [<JsonUnionCase("2015-08-07")>] Numeric20150807
        | [<JsonUnionCase("2015-08-19")>] Numeric20150819
        | [<JsonUnionCase("2015-09-03")>] Numeric20150903
        | [<JsonUnionCase("2015-09-08")>] Numeric20150908
        | [<JsonUnionCase("2015-09-23")>] Numeric20150923
        | [<JsonUnionCase("2015-10-01")>] Numeric20151001
        | [<JsonUnionCase("2015-10-12")>] Numeric20151012
        | [<JsonUnionCase("2015-10-16")>] Numeric20151016
        | [<JsonUnionCase("2016-02-03")>] Numeric20160203
        | [<JsonUnionCase("2016-02-19")>] Numeric20160219
        | [<JsonUnionCase("2016-02-22")>] Numeric20160222
        | [<JsonUnionCase("2016-02-23")>] Numeric20160223
        | [<JsonUnionCase("2016-02-29")>] Numeric20160229
        | [<JsonUnionCase("2016-03-07")>] Numeric20160307
        | [<JsonUnionCase("2016-06-15")>] Numeric20160615
        | [<JsonUnionCase("2016-07-06")>] Numeric20160706
        | [<JsonUnionCase("2016-10-19")>] Numeric20161019
        | [<JsonUnionCase("2017-01-27")>] Numeric20170127
        | [<JsonUnionCase("2017-02-14")>] Numeric20170214
        | [<JsonUnionCase("2017-04-06")>] Numeric20170406
        | [<JsonUnionCase("2017-05-25")>] Numeric20170525
        | [<JsonUnionCase("2017-06-05")>] Numeric20170605
        | [<JsonUnionCase("2017-08-15")>] Numeric20170815
        | [<JsonUnionCase("2017-12-14")>] Numeric20171214
        | [<JsonUnionCase("2018-01-23")>] Numeric20180123
        | [<JsonUnionCase("2018-02-05")>] Numeric20180205
        | [<JsonUnionCase("2018-02-06")>] Numeric20180206
        | [<JsonUnionCase("2018-02-28")>] Numeric20180228
        | [<JsonUnionCase("2018-05-21")>] Numeric20180521
        | [<JsonUnionCase("2018-07-27")>] Numeric20180727
        | [<JsonUnionCase("2018-08-23")>] Numeric20180823
        | [<JsonUnionCase("2018-09-06")>] Numeric20180906
        | [<JsonUnionCase("2018-09-24")>] Numeric20180924
        | [<JsonUnionCase("2018-10-31")>] Numeric20181031
        | [<JsonUnionCase("2018-11-08")>] Numeric20181108
        | [<JsonUnionCase("2019-02-11")>] Numeric20190211
        | [<JsonUnionCase("2019-02-19")>] Numeric20190219
        | [<JsonUnionCase("2019-03-14")>] Numeric20190314
        | [<JsonUnionCase("2019-05-16")>] Numeric20190516
        | [<JsonUnionCase("2019-08-14")>] Numeric20190814
        | [<JsonUnionCase("2019-09-09")>] Numeric20190909
        | [<JsonUnionCase("2019-10-08")>] Numeric20191008
        | [<JsonUnionCase("2019-10-17")>] Numeric20191017
        | [<JsonUnionCase("2019-11-05")>] Numeric20191105
        | [<JsonUnionCase("2019-12-03")>] Numeric20191203
        | [<JsonUnionCase("2020-03-02")>] Numeric20200302
        | [<JsonUnionCase("2020-08-27")>] Numeric20200827

    type WebhookEndpoints'CreateOptions = {
        ApiVersion: WebhookEndpoints'CreateApiVersion option
        Connect: bool option
        Description: string option
        EnabledEvents: WebhookEndpoints'CreateEnabledEvents list
        Expand: string list option
        Metadata: Map<string, string> option
        Url: string
    }
    with
        static member Create(enabledEvents: WebhookEndpoints'CreateEnabledEvents list, url: string, ?apiVersion: WebhookEndpoints'CreateApiVersion, ?connect: bool, ?description: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                ApiVersion = apiVersion
                Connect = connect
                Description = description
                EnabledEvents = enabledEvents
                Expand = expand
                Metadata = metadata
                Url = url
            }

    type WebhookEndpoints'UpdateEnabledEvents =
        | Asterix
        | AccountApplicationAuthorized
        | AccountApplicationDeauthorized
        | AccountExternalAccountCreated
        | AccountExternalAccountDeleted
        | AccountExternalAccountUpdated
        | AccountUpdated
        | ApplicationFeeCreated
        | ApplicationFeeRefundUpdated
        | ApplicationFeeRefunded
        | BalanceAvailable
        | CapabilityUpdated
        | ChargeCaptured
        | ChargeDisputeClosed
        | ChargeDisputeCreated
        | ChargeDisputeFundsReinstated
        | ChargeDisputeFundsWithdrawn
        | ChargeDisputeUpdated
        | ChargeExpired
        | ChargeFailed
        | ChargePending
        | ChargeRefundUpdated
        | ChargeRefunded
        | ChargeSucceeded
        | ChargeUpdated
        | CheckoutSessionAsyncPaymentFailed
        | CheckoutSessionAsyncPaymentSucceeded
        | CheckoutSessionCompleted
        | CouponCreated
        | CouponDeleted
        | CouponUpdated
        | CreditNoteCreated
        | CreditNoteUpdated
        | CreditNoteVoided
        | CustomerCreated
        | CustomerDeleted
        | CustomerDiscountCreated
        | CustomerDiscountDeleted
        | CustomerDiscountUpdated
        | CustomerSourceCreated
        | CustomerSourceDeleted
        | CustomerSourceExpiring
        | CustomerSourceUpdated
        | CustomerSubscriptionCreated
        | CustomerSubscriptionDeleted
        | CustomerSubscriptionPendingUpdateApplied
        | CustomerSubscriptionPendingUpdateExpired
        | CustomerSubscriptionTrialWillEnd
        | CustomerSubscriptionUpdated
        | CustomerTaxIdCreated
        | CustomerTaxIdDeleted
        | CustomerTaxIdUpdated
        | CustomerUpdated
        | FileCreated
        | InvoiceCreated
        | InvoiceDeleted
        | InvoiceFinalizationFailed
        | InvoiceFinalized
        | InvoiceMarkedUncollectible
        | InvoicePaid
        | InvoicePaymentActionRequired
        | InvoicePaymentFailed
        | InvoicePaymentSucceeded
        | InvoiceSent
        | InvoiceUpcoming
        | InvoiceUpdated
        | InvoiceVoided
        | InvoiceitemCreated
        | InvoiceitemDeleted
        | InvoiceitemUpdated
        | IssuingAuthorizationCreated
        | IssuingAuthorizationRequest
        | IssuingAuthorizationUpdated
        | IssuingCardCreated
        | IssuingCardUpdated
        | IssuingCardholderCreated
        | IssuingCardholderUpdated
        | IssuingDisputeClosed
        | IssuingDisputeCreated
        | IssuingDisputeFundsReinstated
        | IssuingDisputeSubmitted
        | IssuingDisputeUpdated
        | IssuingTransactionCreated
        | IssuingTransactionUpdated
        | MandateUpdated
        | OrderCreated
        | OrderPaymentFailed
        | OrderPaymentSucceeded
        | OrderUpdated
        | OrderReturnCreated
        | PaymentIntentAmountCapturableUpdated
        | PaymentIntentCanceled
        | PaymentIntentCreated
        | PaymentIntentPaymentFailed
        | PaymentIntentProcessing
        | PaymentIntentRequiresAction
        | PaymentIntentSucceeded
        | PaymentMethodAttached
        | PaymentMethodAutomaticallyUpdated
        | PaymentMethodDetached
        | PaymentMethodUpdated
        | PayoutCanceled
        | PayoutCreated
        | PayoutFailed
        | PayoutPaid
        | PayoutUpdated
        | PersonCreated
        | PersonDeleted
        | PersonUpdated
        | PlanCreated
        | PlanDeleted
        | PlanUpdated
        | PriceCreated
        | PriceDeleted
        | PriceUpdated
        | ProductCreated
        | ProductDeleted
        | ProductUpdated
        | PromotionCodeCreated
        | PromotionCodeUpdated
        | RadarEarlyFraudWarningCreated
        | RadarEarlyFraudWarningUpdated
        | RecipientCreated
        | RecipientDeleted
        | RecipientUpdated
        | ReportingReportRunFailed
        | ReportingReportRunSucceeded
        | ReportingReportTypeUpdated
        | ReviewClosed
        | ReviewOpened
        | SetupIntentCanceled
        | SetupIntentCreated
        | SetupIntentRequiresAction
        | SetupIntentSetupFailed
        | SetupIntentSucceeded
        | SigmaScheduledQueryRunCreated
        | SkuCreated
        | SkuDeleted
        | SkuUpdated
        | SourceCanceled
        | SourceChargeable
        | SourceFailed
        | SourceMandateNotification
        | SourceRefundAttributesRequired
        | SourceTransactionCreated
        | SourceTransactionUpdated
        | SubscriptionScheduleAborted
        | SubscriptionScheduleCanceled
        | SubscriptionScheduleCompleted
        | SubscriptionScheduleCreated
        | SubscriptionScheduleExpiring
        | SubscriptionScheduleReleased
        | SubscriptionScheduleUpdated
        | TaxRateCreated
        | TaxRateUpdated
        | TopupCanceled
        | TopupCreated
        | TopupFailed
        | TopupReversed
        | TopupSucceeded
        | TransferCreated
        | TransferFailed
        | TransferPaid
        | TransferReversed
        | TransferUpdated

    type WebhookEndpoints'UpdateOptions = {
        Description: string option
        Disabled: bool option
        EnabledEvents: WebhookEndpoints'UpdateEnabledEvents list option
        Expand: string list option
        Metadata: Map<string, string> option
        Url: string option
    }
    with
        static member Create(?description: string, ?disabled: bool, ?enabledEvents: WebhookEndpoints'UpdateEnabledEvents list, ?expand: string list, ?metadata: Map<string, string>, ?url: string) =
            {
                Description = description
                Disabled = disabled
                EnabledEvents = enabledEvents
                Expand = expand
                Metadata = metadata
                Url = url
            }

