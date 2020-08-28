/***********************************************************************
 * <copyright file="FAIncrementDecrementPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model.BusinessObjects.IncrementDecrement;
using Buca.Application.iBigTime2020.View.IncrementDecrement;
using System.Collections.Generic;
using System.Linq;

namespace Buca.Application.iBigTime2020.Presenter.IncrementDecrement
{
    /// <summary>
    ///     FAIncrementDecrementPresenter
    /// </summary>

    public class FAAdjustmentPresenter : Presenter<IFAAdjustmentView>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FAIncrementDecrementPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public FAAdjustmentPresenter(IFAAdjustmentView view) : base(view)
        {
        }

        public string Save(bool isAutoGenerateParallel)
        {
            var fAAdjustment = new FAAdjustmentModel
            {
                RefId = View.RefId,
                //  RefType = View.RefType,
                RefType = 254,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo,
                ParalellRefNo = View.ParalellRefNo,
                JournalMemo = View.JournalMemo,
                FixedAssetId = View.FixedAssetId,
                FixedAssetName = View.FixedAssetName,
                EndDevaluationDate = View.EndDevaluationDate,
                FARefOrder = 0,
                Posted = true,
                // TotalAmount = View.TotalAmount,
                NewOrgPrice = View.NewOrgPrice,
                OldOrgPrice = View.OldOrgPrice,
                DiffOrgPrice = View.DiffOrgPrice,
                NewDevaluationAmount = View.NewDevaluationAmount,
                OldDevaluationAmount = View.OldDevaluationAmount,
                DiffDevaluationAmount = View.DiffDevaluationAmount,
                NewAccumDepreciationAmount = View.NewAccumDepreciationAmount,
                OldAccumDepreciationAmount = View.OldAccumDepreciationAmount,
                DiffAccumDepreciationAmount = View.DiffAccumDepreciationAmount,
                NewAccumDevaluationAmount = View.NewAccumDevaluationAmount,
                OldAccumDevaluationAmount = View.OldAccumDevaluationAmount,
                DiffAccumDevaluationAmount = View.DiffAccumDevaluationAmount,
                OldAnnualDepreciationAmount = View.OldAnnualDepreciationAmount,
                DiffAnnualDepreciationAmount = View.DiffAnnualDepreciationAmount,
                NewAnnualDepreciationAmount = View.NewAnnualDepreciationAmount,
                NewRemainingAmount = View.NewRemainingAmount,
                OldRemainingAmount = View.OldRemainingAmount,
                DiffRemainingAmount = View.DiffRemainingAmount,
                NewQuantity = View.NewQuantity,
                OldQuantity = View.OldQuantity,
                DiffQuantity = View.DiffQuantity,
                FAAdjustmentDetails = View.FAAdjustmentDetails,
                FAAdjustmentDetailParallels = View.FAAdjustmentDetailParallels,
                TotalAmount = View.TotalAmount,
                // FAAdjustmentDetailFA = View.FAAdjustmentDetailFA
            };

            if (View.RefId == null)
            {
                    return Model.AddFAAdjustment(fAAdjustment, isAutoGenerateParallel);
            }    
                //return Model.AddFAAdjustment(fAAdjustment);
            return Model.UpdateFAAdjustment(fAAdjustment, isAutoGenerateParallel);
        }

        public string Delete(string refId)
        {
            return Model.DeleteFAAdjustment(refId);
        }

        public void Display(string refId, bool hasDetail, bool hasDetailParallel)
        {
            var fAAdjustment = Model.GetFAAdjustmentByRefId(refId, hasDetail, hasDetailParallel) ?? new FAAdjustmentModel();
            View.RefId = fAAdjustment.RefId;
            View.RefType = fAAdjustment.RefType;
            View.RefDate = fAAdjustment.RefDate;
            View.PostedDate = fAAdjustment.PostedDate;
            View.RefNo = fAAdjustment.RefNo;
            View.ParalellRefNo = fAAdjustment.ParalellRefNo;
            View.JournalMemo = fAAdjustment.JournalMemo;
            View.TotalAmount = fAAdjustment.TotalAmount;
            View.FixedAssetId = fAAdjustment.FixedAssetId;
            View.FixedAssetName = fAAdjustment.FixedAssetName;
            View.OldOrgPrice = fAAdjustment.OldOrgPrice;
            View.DiffOrgPrice = fAAdjustment.DiffOrgPrice;
            View.NewDevaluationAmount = fAAdjustment.NewDevaluationAmount;
            View.NewOrgPrice = fAAdjustment.NewOrgPrice;
            View.OldDevaluationAmount = fAAdjustment.OldDevaluationAmount;
            View.DiffDevaluationAmount = fAAdjustment.DiffDevaluationAmount;
            View.NewAccumDepreciationAmount = fAAdjustment.NewAccumDepreciationAmount;
            View.OldAccumDepreciationAmount = fAAdjustment.OldAccumDepreciationAmount;
            View.DiffAccumDepreciationAmount = fAAdjustment.DiffAccumDepreciationAmount;
            View.NewAccumDevaluationAmount = fAAdjustment.NewAccumDevaluationAmount;
            View.OldAccumDevaluationAmount = fAAdjustment.OldAccumDevaluationAmount;
            View.DiffAccumDevaluationAmount = fAAdjustment.DiffAccumDevaluationAmount;
            View.OldAnnualDepreciationAmount = fAAdjustment.OldOrgPrice - fAAdjustment.OldDevaluationAmount;
            View.NewRemainingAmount = fAAdjustment.NewRemainingAmount;
            View.OldRemainingAmount = fAAdjustment.OldRemainingAmount;
            View.DiffRemainingAmount = fAAdjustment.DiffRemainingAmount;
            View.NewQuantity = fAAdjustment.NewQuantity;
            View.OldQuantity = fAAdjustment.OldQuantity;
            View.DiffQuantity = fAAdjustment.DiffQuantity;
            View.FAAdjustmentDetails = fAAdjustment.FAAdjustmentDetails == null ? new List<FAAdjustmentDetailModel>() : fAAdjustment.FAAdjustmentDetails.ToList();
            View.FAAdjustmentDetailParallels = fAAdjustment.FAAdjustmentDetailParallels == null ? new List<FAAdjustmentDetailParallelModel>() : fAAdjustment.FAAdjustmentDetailParallels.ToList();
            //View.FAAdjustmentDetails = fAAdjustment.FAAdjustmentDetails;
            //View.FAAdjustmentDetailParallels = fAAdjustment.FAAdjustmentDetailParallels;
        }
        public void Display(string refId)
        {
            var fAAdjustment = Model.GetFAAdjustmentByRefId(refId) ?? new FAAdjustmentModel();
            View.RefId = fAAdjustment.RefId;
            View.RefType = fAAdjustment.RefType;
            View.RefDate = fAAdjustment.RefDate;
            View.PostedDate = fAAdjustment.PostedDate;
            View.RefNo = fAAdjustment.RefNo;
            View.ParalellRefNo = fAAdjustment.ParalellRefNo;
            View.JournalMemo = fAAdjustment.JournalMemo;
            View.TotalAmount = fAAdjustment.TotalAmount;
            View.FixedAssetId = fAAdjustment.FixedAssetId;
            View.FixedAssetName = fAAdjustment.FixedAssetName;
            View.OldOrgPrice = fAAdjustment.OldOrgPrice;
            View.DiffOrgPrice = fAAdjustment.DiffOrgPrice;
            View.NewDevaluationAmount = fAAdjustment.NewDevaluationAmount;
            View.NewOrgPrice = fAAdjustment.NewOrgPrice;
            View.OldDevaluationAmount = fAAdjustment.OldDevaluationAmount;
            View.DiffDevaluationAmount = fAAdjustment.DiffDevaluationAmount;
            View.NewAccumDepreciationAmount = fAAdjustment.NewAccumDepreciationAmount;
            View.OldAccumDepreciationAmount = fAAdjustment.OldAccumDepreciationAmount;
            View.DiffAccumDepreciationAmount = fAAdjustment.DiffAccumDepreciationAmount;
            View.NewAccumDevaluationAmount = fAAdjustment.NewAccumDevaluationAmount;
            View.OldAccumDevaluationAmount = fAAdjustment.OldAccumDevaluationAmount;
            View.DiffAccumDevaluationAmount = fAAdjustment.DiffAccumDevaluationAmount;
            View.OldAnnualDepreciationAmount = fAAdjustment.OldOrgPrice - fAAdjustment.OldDevaluationAmount;
            View.NewRemainingAmount = fAAdjustment.NewRemainingAmount;
            View.OldRemainingAmount = fAAdjustment.OldRemainingAmount;
            View.DiffRemainingAmount = fAAdjustment.DiffRemainingAmount;
            View.NewQuantity = fAAdjustment.NewQuantity;
            View.OldQuantity = fAAdjustment.OldQuantity;
            View.DiffQuantity = fAAdjustment.DiffQuantity;
            //View.FAAdjustmentDetails = fAAdjustment.FAAdjustmentDetails == null ? new List<FAAdjustmentDetailModel>() : fAAdjustment.FAAdjustmentDetails.ToList();
            //View.FAAdjustmentDetailParallels = fAAdjustment.FAAdjustmentDetailParallels == null ? new List<FAAdjustmentDetailParallelModel>() : fAAdjustment.FAAdjustmentDetailParallels.ToList();
            View.FAAdjustmentDetails = fAAdjustment.FAAdjustmentDetails;
            View.FAAdjustmentDetailParallels = fAAdjustment.FAAdjustmentDetailParallels;
        }
    }
}