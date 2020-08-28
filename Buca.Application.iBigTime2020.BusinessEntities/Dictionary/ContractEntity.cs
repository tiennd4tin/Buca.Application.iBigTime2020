using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;


namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    /// <summary>
    /// class AccountEntity
    /// </summary>
    public class ContractEntity
    {
        public string ContractId { get; set; }
        public string ContractNo { get; set; }
        public string ContractName { get; set; }
        public string ContractNameEnglish { get; set; }
        public DateTime SignDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal AmountOC { get; set; }
        public string ProjectId { get; set; }
        public string Description { get; set; }
        public string VendorId { get; set; }
        public string VendorBankAccountId { get; set; }
        public bool IsActive { get; set; }
        public List<ContractDetailEntity> ContractDetails { get; set; }
    }
}
