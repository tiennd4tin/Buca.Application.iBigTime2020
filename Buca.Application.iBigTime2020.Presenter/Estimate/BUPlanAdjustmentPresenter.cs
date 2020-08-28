using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.View.Estimate;

namespace Buca.Application.iBigTime2020.Presenter.Estimate
{
    public class BUPlanAdjustmentPresenter : Presenter<IBUPlanAdjustmentView>
    {
        public BUPlanAdjustmentPresenter(IBUPlanAdjustmentView view) : base(view)
        {
        }
        public void Display(string refId)
        {
            var bUPlanAdjustment = Model.GetBuPlanAdjustmentbyRefId(refId) ?? new BUPlanAdjustmentModel();
            View.RefId = bUPlanAdjustment.RefId;
            View.RefType = bUPlanAdjustment.RefType;
            View.RefDate = bUPlanAdjustment.RefDate;
            View.PostedDate = bUPlanAdjustment.PostedDate;
            View.RefNo = bUPlanAdjustment.RefNo;
            View.ExchangeRate = bUPlanAdjustment.ExchangeRate;
            View.ParalellRefNo = bUPlanAdjustment.ParalellRefNo;
            View.DecisionDate = bUPlanAdjustment.DecisionDate;
            View.DecisionNo = bUPlanAdjustment.DecisionNo;
            View.JournalMemo = bUPlanAdjustment.JournalMemo;
            View.Posted = bUPlanAdjustment.Posted;
            View.TotalPreAdjustmentAmount = bUPlanAdjustment.TotalPreAdjustmentAmount;
            View.TotalAdjustmentAmount = bUPlanAdjustment.TotalAdjustmentAmount;
            View.TotalPostAdjustmentAmount = bUPlanAdjustment.TotalPostAdjustmentAmount;
            View.PostVersion = bUPlanAdjustment.PostVersion;
            View.EditVersion = bUPlanAdjustment.EditVersion;
            View.BUPlanAdjustmentDetails = bUPlanAdjustment.BuPlanAdjustmentDetailModels == null ? new List<BUPlanAdjustmentDetailModel>() : bUPlanAdjustment.BuPlanAdjustmentDetailModels;
            View.TotalAmount = bUPlanAdjustment.TotalAmount;
            View.CurrencyCode = bUPlanAdjustment.CurrencyCode;

        }

        public string Save()
        {
            var bUPlanAdjustment = new BUPlanAdjustmentModel()
            {

                RefId = View.RefId,
                RefType = View.RefType,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo,
                ParalellRefNo = View.ParalellRefNo,
                DecisionDate = View.DecisionDate,
                DecisionNo = View.DecisionNo,
                JournalMemo = View.JournalMemo,
                Posted = View.Posted,
                TotalPreAdjustmentAmount = View.TotalPreAdjustmentAmount,
                TotalAdjustmentAmount = View.TotalAdjustmentAmount,
                TotalPostAdjustmentAmount = View.TotalPostAdjustmentAmount,
                PostVersion = View.PostVersion,
                EditVersion = View.EditVersion,
                BuPlanAdjustmentDetailModels = View.BUPlanAdjustmentDetails,
                ExchangeRate = View.ExchangeRate,
                CurrencyCode = View.CurrencyCode,
                TotalAmount = View.TotalAmount,
                
            };
            if (View.RefId == null)
                return Model.InsertBUPlanAdjustment(bUPlanAdjustment);
            return Model.UpdateBUPlanAdjustment(bUPlanAdjustment);
        }
        public string Delete(string refId)
        {
            return Model.DeleteBUPlanAdjustment(refId);
        }
    }
}
