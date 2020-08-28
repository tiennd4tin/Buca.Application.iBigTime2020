using System;

namespace Buca.Application.iBigTime2020.BusinessEntities.Business.Opening
{
    /// <summary>
    /// Số dư đầu kì tài sản cố định
    /// </summary>
    public class OpeningFixedAssetEntryEntity : BusinessEntities
    {
        public string RefId { get; set; }

        public int RefType { get; set; }

        public DateTime PostedDate { get; set; }

        public string CurrencyCode { get; set; }

        public decimal ExchangeRate { get; set; }

        public string FixedAssetId { get; set; }
        public string FixedAssetCode { get; set; }

        public string DepartmentId { get; set; }

        public string BudgetChapterCode { get; set; }

        /// <summary>
        /// Tài khoản nguyên giá
        /// </summary>
        public string OrgPriceAccount { get; set; }

        /// <summary>
        /// Nguyên giá nguyên tệ
        /// </summary>
        public decimal OrgPriceDebitAmountOC { get; set; }

        /// <summary>
        /// Nguyên giá quy đổi
        /// </summary>
        public decimal OrgPriceDebitAmount { get; set; }

        /// <summary>
        /// Tài khoản có hạch toán hao mòn
        /// </summary>
        public string DepreciationAccount { get; set; }

        /// <summary>
        /// Hao mòn lũy kế nguyên tệ
        /// </summary>
        public decimal DepreciationCreditAmountOC { get; set; }

        /// <summary>
        /// Hao mòn lũy kế quy đổi
        /// </summary>
        public decimal DepreciationCreditAmount { get; set; }

        public string CapitalAccount { get; set; }

        /// <summary>
        /// Giá trị còn lại nguyên tệ
        /// </summary>
        public decimal CapitalCreditAmountOC { get; set; }

        /// <summary>
        /// Giá trị còn lại quy đổi
        /// </summary>
        public decimal CapitalCreditAmount { get; set; }

        public int SortOrder { get; set; }

        /// <summary>
        /// Khấu hao lũy kế
        /// </summary>
        public decimal DevaluationCreditAmount { get; set; }
    }
}
