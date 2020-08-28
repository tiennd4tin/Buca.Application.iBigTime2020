/***********************************************************************
 * <copyright file="FixedAssetPresenter.cs" company="BUCA JSC">
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
using Buca.Application.iBigTime2020.Model.BusinessObjects.FixedAsset;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Opening;
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAsset
{
    /// <summary>
    /// FixedAsset Presenter
    /// </summary>
    public class FixedAssetPresenter : Presenter<IFixedAssetView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public FixedAssetPresenter(IFixedAssetView view)
            : base(view)
        {
        }

        ///// <summary>
        ///// Displays the specified fixed asset identifier.
        ///// </summary>
        ///// <param name="fixedAssetId">The fixed asset identifier.</param>
        //public FixedAssetModel DisplayInFaIncreamnet(string fixedAssetId)
        //{

        //    var fixedAsset = Model.GetFixedAssetByFaIncrement(int.Parse(fixedAssetId));
        //    return fixedAsset;
        //}

        /// <summary>
        /// Displays the specified fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        public void Display(string fixedAssetId)

        {
            var fixedAsset = Model.GetFixedAssetById(fixedAssetId) ?? new FixedAssetModel { IsActive = true };

            View.FixedAssetId = fixedAsset.FixedAssetId;
            View.DepartmentId = fixedAsset.DepartmentId;
            View.FixedAssetCode = fixedAsset.FixedAssetCode;
            View.FixedAssetName = fixedAsset.FixedAssetName;
            View.Quantity = fixedAsset.Quantity;
            View.Description = fixedAsset.Description;
            View.ProductionYear = fixedAsset.ProductionYear;
            View.MadeIn = fixedAsset.MadeIn;
            View.SerialNumber = fixedAsset.SerialNumber;
            View.Accessories = fixedAsset.Accessories;
            View.VendorId = fixedAsset.VendorId;
            View.GuaranteeDuration = fixedAsset.GuaranteeDuration;
            View.IsSecondHand = fixedAsset.IsSecondHand;
            View.LastState = fixedAsset.LastState;
            View.DisposedDate = fixedAsset.DisposedDate;
            View.DisposedAmount = fixedAsset.DisposedAmount;
            View.DisposedReason = fixedAsset.DisposedReason;
            View.PurchasedDate = fixedAsset.PurchasedDate;
            View.UsedDate = fixedAsset.UsedDate;
            View.FixedAssetCategoryId = fixedAsset.FixedAssetCategoryId;

            View.LifeTime = fixedAsset.LifeTime;
            View.RemainingLifeTime = fixedAsset.RemainingLifeTime;
            View.DepreciationDate = fixedAsset.DepreciationDate;
            View.IncrementDate = fixedAsset.IncrementDate;
            View.OrgPrice = fixedAsset.OrgPrice;
            View.DepreciationValueCaculated = fixedAsset.DepreciationValueCaculated;
            View.AccumDepreciationAmount = fixedAsset.AccumDepreciationAmount;

            View.DepreciationRate = fixedAsset.DepreciationRate;
            View.PeriodDepreciationAmount = fixedAsset.PeriodDepreciationAmount;
            View.RemainingAmount = fixedAsset.RemainingAmount;
            View.EndYear = fixedAsset.EndYear;

            View.OrgPriceAccount = fixedAsset.OrgPriceAccount;
            View.CapitalAccount = fixedAsset.CapitalAccount;
            View.CreditDepreciationAccount = fixedAsset.CreditDepreciationAccount;
            View.DebitDepreciationAccount = fixedAsset.DebitDepreciationAccount;
            View.IsFixedAssetTransfer = fixedAsset.IsFixedAssetTransfer;
            View.DepreciationTimeCaculated = fixedAsset.DepreciationTimeCaculated;
            View.RevenueAccount = fixedAsset.RevenueAccount;
            View.Unit = fixedAsset.Unit;
            View.Source = fixedAsset.Source;
            View.IsActive = fixedAsset.IsActive;
            View.UsingRatio = fixedAsset.UsingRatio;
            View.DevaluationDate = fixedAsset.DevaluationDate;
            View.DevaluationLifeTime = fixedAsset.DevaluationLifeTime;
            View.DevaluationPeriod = fixedAsset.DevaluationPeriod;
            View.DevaluationRate = fixedAsset.DevaluationRate;

            View.BudgetKindItemCode = fixedAsset.BudgetKindItemCode;
            View.BudgetChapterCode = fixedAsset.BudgetChapterCode;
            View.BudgetItemCode = fixedAsset.BudgetItemCode;
            View.BudgetSubItemCode = fixedAsset.BudgetSubItemCode;
            View.BudgetSubKindItemCode = fixedAsset.BudgetSubKindItemCode;

            View.DevaluationCreditAccount = fixedAsset.DevaluationCreditAccount;
            View.DevaluationDebitAccount = fixedAsset.DevaluationDebitAccount;
            View.AccumDevaluationAmount = fixedAsset.AccumDevaluationAmount;
            View.EndDevaluationDate = fixedAsset.EndDevaluationDate;
            View.PeriodDevaluationAmount = fixedAsset.PeriodDevaluationAmount;
            View.DevaluationAmount = fixedAsset.DevaluationAmount;


            View.FixedAssetDetailAccessories = fixedAsset.FixedAssetDetailAccessories != null ? fixedAsset.FixedAssetDetailAccessories : new List<FixedAssetDetailAccessoryModel>();
            View.FixedAssetVoucherAttachs = fixedAsset.FixedAssetVoucherAttachs != null ? fixedAsset.FixedAssetVoucherAttachs : new List<FixedAssetVoucherAttachModel>();
        }




        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public string save(DateTime systemDate)
        {
            var fixedasset = new FixedAssetModel();
            fixedasset.FixedAssetId = View.FixedAssetId;
            fixedasset.FixedAssetCategoryId = View.FixedAssetCategoryId;
            fixedasset.DepartmentId = View.DepartmentId;
            fixedasset.FixedAssetCode = View.FixedAssetCode;
            fixedasset.FixedAssetName = View.FixedAssetName;
            fixedasset.Quantity = View.Quantity;
            fixedasset.Description = View.Description;
            fixedasset.ProductionYear = View.ProductionYear;
            fixedasset.MadeIn = View.MadeIn;
            fixedasset.SerialNumber = View.SerialNumber;
            fixedasset.Accessories = View.Accessories;
            fixedasset.VendorId = View.VendorId;
            fixedasset.GuaranteeDuration = View.GuaranteeDuration;
            fixedasset.IsSecondHand = View.IsSecondHand;
            fixedasset.LastState = View.LastState;
            fixedasset.DisposedDate = View.DisposedDate;
            fixedasset.DisposedAmount = View.DisposedAmount;
            fixedasset.DisposedReason = View.DisposedReason;
            fixedasset.PurchasedDate = View.PurchasedDate;
            fixedasset.UsedDate = View.UsedDate;
            fixedasset.DepreciationDate = View.DepreciationDate;
            fixedasset.IncrementDate = View.IncrementDate;
            fixedasset.OrgPrice = View.OrgPrice;
            fixedasset.DepreciationValueCaculated = View.DepreciationValueCaculated;
            fixedasset.AccumDepreciationAmount = View.AccumDepreciationAmount;
            fixedasset.LifeTime = View.LifeTime;
            fixedasset.DepreciationRate = View.DepreciationRate;
            fixedasset.PeriodDepreciationAmount = View.PeriodDepreciationAmount;
            fixedasset.RemainingAmount = View.RemainingAmount;
            fixedasset.RemainingLifeTime = View.RemainingLifeTime;
            fixedasset.EndYear = View.EndYear;
            fixedasset.OrgPriceAccount = View.OrgPriceAccount;
            fixedasset.CapitalAccount = View.CapitalAccount;
            fixedasset.CreditDepreciationAccount = View.CreditDepreciationAccount;
            fixedasset.DebitDepreciationAccount = View.DebitDepreciationAccount;
            fixedasset.IsFixedAssetTransfer = View.IsFixedAssetTransfer;
            fixedasset.DepreciationTimeCaculated = View.DepreciationTimeCaculated;
            fixedasset.Unit = View.Unit;
            fixedasset.Source = View.Source;
            fixedasset.RevenueAccount = View.RevenueAccount;
            fixedasset.IsActive = View.IsActive;
            fixedasset.UsingRatio = View.UsingRatio;
            fixedasset.DevaluationDate = View.DevaluationDate;
            fixedasset.DevaluationLifeTime = View.DevaluationLifeTime;
            fixedasset.DevaluationPeriod = View.DevaluationPeriod;
            fixedasset.DevaluationRate = View.DevaluationRate;
            fixedasset.BudgetChapterCode = View.BudgetChapterCode;
            fixedasset.BudgetSubKindItemCode = View.BudgetSubKindItemCode;
            fixedasset.BudgetKindItemCode = View.BudgetKindItemCode;
            fixedasset.BudgetSubItemCode = View.BudgetSubItemCode;
            fixedasset.BudgetItemCode = View.BudgetItemCode;
            fixedasset.DevaluationDebitAccount = View.DevaluationDebitAccount;
            fixedasset.DevaluationCreditAccount = View.DevaluationCreditAccount;
            fixedasset.AccumDevaluationAmount = View.AccumDevaluationAmount;
            fixedasset.FixedAssetDetailAccessories = View.FixedAssetDetailAccessories;
            fixedasset.FixedAssetVoucherAttachs = View.FixedAssetVoucherAttachs;
            fixedasset.EndDevaluationDate = View.EndDevaluationDate;
            fixedasset.PeriodDevaluationAmount = View.PeriodDevaluationAmount;
            fixedasset.DevaluationAmount = View.DevaluationAmount;
            fixedasset.FundStructureId = View.FundStructureId;

            if (View.FixedAssetId == null)
                return Model.AddFixedAsset(fixedasset);
            return Model.UpdateFixedAsset(fixedasset, systemDate);

        }

        public string Delete(string fixedAssetId, DateTime systemDate)
        {
            return Model.DeleteFixedAsset(fixedAssetId, systemDate);
        }
    }
}
