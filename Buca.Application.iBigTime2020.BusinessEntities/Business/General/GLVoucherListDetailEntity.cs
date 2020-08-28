using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;

namespace Buca.Application.iBigTime2020.BusinessEntities.Business.General
{
    public class GLVoucherListDetailEntity : BusinessEntities
    {
        public GLVoucherListDetailEntity()
        {
            AddRule(new ValidateId("RefDetailId"));
        }
        public string RefDetailId { get; set; }
        public string RefId { get; set; }
        public int DetailRefType { get; set; }
        public string DetailRefId { get; set; }
        public string DetailId { get; set; }
        public int SortOrder { get; set; }
        public int EntryType { get; set; }
        public string BudgetSourceId { get; set; }
        public DateTime? RefDate { get; set; }
        public DateTime PostedDate { get; set; }
        public string RefNo { get; set; }
        public string Description { get; set; }
        public string DebitAccount { get; set; }
        public string CreditAccount { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountOC { get; set; }
        public string RefNoTotal { get; set; }
        public DateTime RefDateTotal { get; set; }
        public string RefNoCount { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}
