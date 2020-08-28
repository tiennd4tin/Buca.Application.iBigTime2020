using System;
using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;


namespace Buca.Application.iBigTime2020.BusinessEntities.Business.Cash
{
    public class CAPaymentDetailTaxEntity : BusinessEntities
    {
        public CAPaymentDetailTaxEntity()
        {
            AddRule(new ValidateRequired("RefDetailId"));
            AddRule(new ValidateRequired("RefId"));
        }
        public string RefDetailId { get; set; }

        public string RefId { get; set; }

        public string Description { get; set; }

        public decimal VATAmount { get; set; }

        public decimal? VATRate { get; set; }

        public decimal? TurnOver { get; set; }

        public int? InvType { get; set; }

        public DateTime? InvDate { get; set; }

        public string InvSeries { get; set; }

        public string InvNo { get; set; }

        public string PurchasePurposeId { get; set; }

        public string AccountingObjectId { get; set; }

        public string CompanyTaxCode { get; set; }

        public int SortOrder { get; set; }

        public string InvoiceTypeCode { get; set; }

    }
}
