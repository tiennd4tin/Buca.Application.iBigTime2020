using System;
using System.Collections.Generic;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher
{
    public class C301NSEntity : BusinessEntities
    {
        public bool IsPayOrAdvance { get; set; }
        public bool IsTranOrCash { get; set; }
        public string RefID { get; set; }
        public string RefNo { get; set; }
        public string ProjectName { get; set; }
        public string ProjectCode { get; set; }
        public string IDQHNS { get; set; }
        public string InvestmentName { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string FundingCode { get; set; }
        public string NameCTMT { get; set; }
        public string IDCTMT { get; set; }
        public int FiveYear { get; set; }
        public string ExpendContract { get; set; }
        public string FrameContract { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime RefDate { get; set; }
        public decimal SumAmount { get; set; }
        public string TaxName { get; set; }
        public string TaxIDVAT { get; set; }
        public string TaxIDNKT { get; set; }
        public string TaxChapter { get; set; }
        public string TaxCompanyGet { get; set; }
        public string TaxKBNN { get; set; }
        public decimal TaxAmount { get; set; }
        public string ObName { get; set; }
        public string ObIDQHNS { get; set; }
        public string ObAddress { get; set; }
        public string ObBankCode { get; set; }
        public string ObBankName { get; set; }
        public string ObIDCTMTAndDA { get; set; }
        public string ObPersonNameCash { get; set; }
        public string ObIDCard { get; set; }
        public DateTime ObDateCard { get; set; }
        public string ObAddressCard { get; set; }
        public decimal ObAmount { get; set; }
        public string ContractCode { get; set; }
        public DateTime ContractDate { get; set; }
        public decimal LKTTN { get; set; }
        public decimal LKT { get; set; }
        public decimal LKTNN { get; set; }
        public decimal SDTUTN { get; set; }
        public decimal SDTUNN { get; set; }
        public decimal SDTU { get; set; }
        public string CapitalSource { get; set; }
        public string PlanYear { get; set; }
        public decimal THTUTN { get; set; }
        public decimal THTUNN { get; set; }
        public decimal TTNVTN { get; set; }
        public decimal TTNVNN { get; set; }
        public string SubContractName { get; set; }
        public DateTime SubContractDate { get; set; }
        public IList<C301NSDetailEntity> Details { get; set; }
        public IList<C301NSDetail2Entity> Details2 { get; set; }
    }
}
