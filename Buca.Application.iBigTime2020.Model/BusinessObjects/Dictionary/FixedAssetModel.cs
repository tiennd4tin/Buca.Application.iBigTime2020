/***********************************************************************
 * <copyright file="FixedAssetModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Wednesday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;


namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// FixedAsset Model
    /// </summary>
    public class FixedAssetModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetModel"/> class.
        /// </summary>
        //public FixedAssetModel()
        //{
        //FixedAssetActivities = new List<FixedAssetActivityModel>();
        //}
        //public IList<FixedAssetCurrencyModel> FixedAssetCurrencies { get; set; }

        public string FixedAssetId { get; set; }

        public string FixedAssetCategoryId { get; set; }

        public string DepartmentId { get; set; }

        public string FixedAssetCode { get; set; }

        public string FixedAssetName { get; set; }

        public decimal Quantity { get; set; }

        public string Description { get; set; }

        public int ProductionYear { get; set; }

        public string MadeIn { get; set; }

        public string SerialNumber { get; set; }

        public string Accessories { get; set; }

        public string VendorId { get; set; }

        public string GuaranteeDuration { get; set; }

        public bool IsSecondHand { get; set; }

        public int LastState { get; set; }

        public DateTime DisposedDate { get; set; }

        public decimal DisposedAmount { get; set; }

        public string DisposedReason { get; set; }

        public DateTime PurchasedDate { get; set; }

        public DateTime UsedDate { get; set; }

        public DateTime DepreciationDate { get; set; }

        public DateTime IncrementDate { get; set; }

        public decimal OrgPrice { get; set; }

        public decimal DepreciationValueCaculated { get; set; }

        public decimal AccumDepreciationAmount { get; set; }

        public int LifeTime { get; set; }

        public decimal DepreciationRate { get; set; }

        public decimal PeriodDepreciationAmount { get; set; }

        public decimal RemainingAmount { get; set; }

        public int RemainingLifeTime { get; set; }

        public int EndYear { get; set; }

        public string OrgPriceAccount { get; set; }

        public string CapitalAccount { get; set; }

        public string RevenueAccount { get; set; }

        public string BudgetChapterCode { get; set; }

        public string BudgetKindItemCode { get; set; }

        public string BudgetSubKindItemCode { get; set; }

        public string BudgetItemCode { get; set; }

        public string BudgetSubItemCode { get; set; }

        public string CreditDepreciationAccount { get; set; }

        public string DebitDepreciationAccount { get; set; }

        public bool IsFixedAssetTransfer { get; set; }

        public decimal DepreciationTimeCaculated { get; set; }

        public string Unit { get; set; }

        public int Source { get; set; }

        public bool IsActive { get; set; }

        public decimal UsingRatio { get; set; }

        public DateTime DevaluationDate { get; set; }

        public int DevaluationPeriod { get; set; }

        public decimal DevaluationRate { get; set; }

        public decimal DevaluationLifeTime { get; set; }

        public string DevaluationCreditAccount { get; set; }

        public string DevaluationDebitAccount { get; set; }

        public decimal AccumDevaluationAmount { get; set; }

        public DateTime EndDevaluationDate { get; set; }

        public decimal PeriodDevaluationAmount { get; set; }

        public decimal DevaluationAmount { get; set; }
        public string FundStructureId { get; set; }

        //public decimal OrgPriceDebitAmount { get; set; }

        //public decimal OrgPriceCreditAmount { get; set; }

        //public decimal DepreciationDebitAmount { get; set; }

        //public decimal DepreciationCreditAmount { get; set; }

        //public decimal DevaluationDebitAmount { get; set; }

        //public decimal DevaluationCreditAmount { get; set; }

        //public IList<FixedAssetActivityModel> FixedAssetActivities { get; set; }

        public IList<FixedAssetDetailAccessoryModel> FixedAssetDetailAccessories { get; set; }

        public IList<FixedAssetVoucherAttachModel> FixedAssetVoucherAttachs { get; set; }
    }
}
