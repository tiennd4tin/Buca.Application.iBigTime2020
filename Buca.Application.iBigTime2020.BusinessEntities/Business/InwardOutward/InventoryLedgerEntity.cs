using System;

namespace Buca.Application.iBigTime2020.BusinessEntities.Business.InwardOutward
{
    public class InventoryLedgerEntity : BusinessEntities
    {
        public string InventoryLedgerId { get; set; }

        public string RefId { get; set; }

        public int RefType { get; set; }

        public string RefNo { get; set; }

        public DateTime RefDate { get; set; }

        public DateTime PostedDate { get; set; }

        public string AccountNumber { get; set; }
        public string CorrespondingAccountNumber { get; set; }

        public string BudgetSourceId { get; set; }

        public string StockId { get; set; }

        public string InventoryItemId { get; set; }

        public string Unit { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal InwardQuantity { get; set; }

        public decimal OutwardQuantity { get; set; }

        public decimal InwardAmount { get; set; }
        public decimal InwardAmountOC { get; set; }
        public decimal OutwardAmount { get; set; }
        public decimal OutwardAmountOC { get; set; }

        public decimal InwardQuantityBalance { get; set; }

        public decimal InwardAmountBalance { get; set; }

        public string JournalMemo { get; set; }

        public string Description { get; set; }

        public int? OutwardPurpose { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public string LotNo { get; set; }

        public int? RefOrder { get; set; }

        public string RefDetailId { get; set; }

        public int? SortOrder { get; set; }

        public string ConfrontingRefId { get; set; }

        public string InwardRefDetailId { get; set; }

        public decimal? UnitPriceBalance { get; set; }

        public decimal? InwardAmountBalanceAfter { get; set; }

        public string BudgetProvideCode { get; set; }
        public string CurrencyCode { get; set; }
    }
}
