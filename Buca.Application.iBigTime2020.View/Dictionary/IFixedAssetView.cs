/***********************************************************************
 * <copyright file="IFixedAssetView.cs" company="BUCA JSC">
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
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;


namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    /// FixedAsset View Interface
    /// </summary>
    public interface IFixedAssetView : IView
    {
        string FixedAssetId { get; set; }

        string FixedAssetCategoryId { get; set; }

        string DepartmentId { get; set; }

        string FixedAssetCode { get; set; }

        string FixedAssetName { get; set; }

        decimal Quantity { get; set; }

        string Description { get; set; }

        int ProductionYear { get; set; }

        string MadeIn { get; set; }

        string SerialNumber { get; set; }

        string Accessories { get; set; }
        string FundStructureId { get; set; }
        string VendorId { get; set; }

        string GuaranteeDuration { get; set; }

        bool IsSecondHand { get; set; }

        int LastState { get; set; }

        DateTime DisposedDate { get; set; }

        decimal DisposedAmount { get; set; }

        string DisposedReason { get; set; }

        DateTime PurchasedDate { get; set; }

        DateTime UsedDate { get; set; }

        DateTime DepreciationDate { get; set; }

        DateTime IncrementDate { get; set; }

        decimal OrgPrice { get; set; }

        decimal DepreciationValueCaculated { get; set; }

        decimal AccumDepreciationAmount { get; set; }

        int LifeTime { get; set; }

        decimal DepreciationRate { get; set; }

        decimal PeriodDepreciationAmount { get; set; }

        decimal RemainingAmount { get; set; }

        int RemainingLifeTime { get; set; }

        int EndYear { get; set; }

        string OrgPriceAccount { get; set; }

        string CapitalAccount { get; set; }

        string RevenueAccount { get; set; }

        string CreditDepreciationAccount { get; set; }

        string DebitDepreciationAccount { get; set; }

        bool IsFixedAssetTransfer { get; set; }

        decimal DepreciationTimeCaculated { get; set; }

        string Unit { get; set; }

        int Source { get; set; }

        bool IsActive { get; set; }

        decimal UsingRatio { get; set; }

        DateTime DevaluationDate { get; set; }

        int DevaluationPeriod { get; set; }

        decimal DevaluationRate { get; set; }

        decimal DevaluationLifeTime { get; set; }

        string BudgetChapterCode { get; set; }

        string BudgetKindItemCode { get; set; }

        string BudgetSubKindItemCode { get; set; }

        string BudgetItemCode { get; set; }

        string BudgetSubItemCode { get; set; }

        string DevaluationCreditAccount { get; set; }

        string DevaluationDebitAccount { get; set; }

        decimal AccumDevaluationAmount { get; set; }

        DateTime EndDevaluationDate { get; set; }

        decimal PeriodDevaluationAmount { get; set; }

        decimal DevaluationAmount { get; set; }

        IList<FixedAssetDetailAccessoryModel> FixedAssetDetailAccessories { get; set; }

        IList<FixedAssetVoucherAttachModel> FixedAssetVoucherAttachs { get; set; }
    }
}
