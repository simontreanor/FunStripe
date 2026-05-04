namespace Stripe.TaxId

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Tax

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
type DeletedTaxId =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

type DeletedTaxId with
    static member New(deleted: bool, id: string) =
        {
            Deleted = deleted
            Id = id
        }

module DeletedTaxId =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "tax_id"

type TaxIdType =
    | AdNrt
    | AeTrn
    | AlTin
    | AmTin
    | AoTin
    | ArCuit
    | AuAbn
    | AuArn
    | AwTin
    | AzTin
    | BaTin
    | BbTin
    | BdBin
    | BfIfu
    | BgUic
    | BhVat
    | BjIfu
    | BoTin
    | BrCnpj
    | BrCpf
    | BsTin
    | ByTin
    | CaBn
    | CaGstHst
    | CaPstBc
    | CaPstMb
    | CaPstSk
    | CaQst
    | CdNif
    | ChUid
    | ChVat
    | ClTin
    | CmNiu
    | CnTin
    | CoNit
    | CrTin
    | CvNif
    | DeStn
    | DoRcn
    | EcRuc
    | EgTin
    | EsCif
    | EtTin
    | EuOssVat
    | EuVat
    | FoVat
    | GbVat
    | GeVat
    | GiTin
    | GnNif
    | HkBr
    | HrOib
    | HuTin
    | IdNpwp
    | IlVat
    | InGst
    | IsVat
    | ItCf
    | JpCn
    | JpRn
    | JpTrn
    | KePin
    | KgTin
    | KhTin
    | KrBrn
    | KzBin
    | LaTin
    | LiUid
    | LiVat
    | LkVat
    | MaVat
    | MdVat
    | MePib
    | MkVat
    | MrNif
    | MxRfc
    | MyFrp
    | MyItn
    | MySst
    | NgTin
    | NoVat
    | NoVoec
    | NpPan
    | NzGst
    | OmVat
    | PeRuc
    | PhTin
    | PlNip
    | PyRuc
    | RoTin
    | RsPib
    | RuInn
    | RuKpp
    | SaVat
    | SgGst
    | SgUen
    | SiTin
    | SnNinea
    | SrFin
    | SvNit
    | ThVat
    | TjTin
    | TrTin
    | TwVat
    | TzVat
    | UaVat
    | UgTin
    | Unknown
    | UsEin
    | UyRuc
    | UzTin
    | UzVat
    | VeRif
    | VnTin
    | ZaVat
    | ZmTin
    | ZwTin

[<Struct>]
type TaxIdVerificationStatus =
    | Pending
    | Unavailable
    | Unverified
    | Verified

type TaxIdVerification =
    {
        /// Verification status, one of `pending`, `verified`, `unverified`, or `unavailable`.
        Status: TaxIdVerificationStatus
        /// Verified address.
        VerifiedAddress: string option
        /// Verified name.
        VerifiedName: string option
    }

type TaxIdVerification with
    static member New(status: TaxIdVerificationStatus, verifiedAddress: string option, verifiedName: string option) =
        {
            Status = status
            VerifiedAddress = verifiedAddress
            VerifiedName = verifiedName
        }

/// You can add one or multiple tax IDs to a [customer](https://docs.stripe.com/api/customers) or account.
/// Customer and account tax IDs get displayed on related invoices and credit notes.
/// Related guides: [Customer tax identification numbers](https://docs.stripe.com/billing/taxes/tax-ids), [Account tax IDs](https://docs.stripe.com/invoicing/connect#account-tax-ids)
type TaxId =
    {
        /// Two-letter ISO code representing the country of the tax ID.
        Country: IsoTypes.IsoCountryCode option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// ID of the customer.
        Customer: StripeId<Markers.Customer> option
        /// ID of the Account representing the customer.
        CustomerAccount: string option
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// The account or customer the tax ID belongs to.
        Owner: TaxIDsOwner option
        /// Type of the tax ID, one of `ad_nrt`, `ae_trn`, `al_tin`, `am_tin`, `ao_tin`, `ar_cuit`, `au_abn`, `au_arn`, `aw_tin`, `az_tin`, `ba_tin`, `bb_tin`, `bd_bin`, `bf_ifu`, `bg_uic`, `bh_vat`, `bj_ifu`, `bo_tin`, `br_cnpj`, `br_cpf`, `bs_tin`, `by_tin`, `ca_bn`, `ca_gst_hst`, `ca_pst_bc`, `ca_pst_mb`, `ca_pst_sk`, `ca_qst`, `cd_nif`, `ch_uid`, `ch_vat`, `cl_tin`, `cm_niu`, `cn_tin`, `co_nit`, `cr_tin`, `cv_nif`, `de_stn`, `do_rcn`, `ec_ruc`, `eg_tin`, `es_cif`, `et_tin`, `eu_oss_vat`, `eu_vat`, `fo_vat`, `gb_vat`, `ge_vat`, `gi_tin`, `gn_nif`, `hk_br`, `hr_oib`, `hu_tin`, `id_npwp`, `il_vat`, `in_gst`, `is_vat`, `it_cf`, `jp_cn`, `jp_rn`, `jp_trn`, `ke_pin`, `kg_tin`, `kh_tin`, `kr_brn`, `kz_bin`, `la_tin`, `li_uid`, `li_vat`, `lk_vat`, `ma_vat`, `md_vat`, `me_pib`, `mk_vat`, `mr_nif`, `mx_rfc`, `my_frp`, `my_itn`, `my_sst`, `ng_tin`, `no_vat`, `no_voec`, `np_pan`, `nz_gst`, `om_vat`, `pe_ruc`, `ph_tin`, `pl_nip`, `py_ruc`, `ro_tin`, `rs_pib`, `ru_inn`, `ru_kpp`, `sa_vat`, `sg_gst`, `sg_uen`, `si_tin`, `sn_ninea`, `sr_fin`, `sv_nit`, `th_vat`, `tj_tin`, `tr_tin`, `tw_vat`, `tz_vat`, `ua_vat`, `ug_tin`, `us_ein`, `uy_ruc`, `uz_tin`, `uz_vat`, `ve_rif`, `vn_tin`, `za_vat`, `zm_tin`, or `zw_tin`. Note that some legacy tax IDs have type `unknown`
        Type: TaxIdType
        /// Value of the tax ID.
        Value: string
        /// Tax ID verification information.
        Verification: TaxIdVerification option
    }

type TaxId with
    static member New(country: IsoTypes.IsoCountryCode option, created: DateTime, customer: StripeId<Markers.Customer> option, customerAccount: string option, id: string, livemode: bool, owner: TaxIDsOwner option, ``type``: TaxIdType, value: string, verification: TaxIdVerification option) =
        {
            Country = country
            Created = created
            Customer = customer
            CustomerAccount = customerAccount
            Id = id
            Livemode = livemode
            Owner = owner
            Type = ``type``
            Value = value
            Verification = verification
        }

module TaxId =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "tax_id"

