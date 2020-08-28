using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.View.Estimate;

namespace Buca.Application.iBigTime2020.Presenter.Estimate
{
   public class BUPlanAdjustmentsPresenter:Presenter<IBUPlanAdjustmentsView>
    {
       public BUPlanAdjustmentsPresenter(IBUPlanAdjustmentsView view) : base(view)
       {
       }
        public void Display()
        {
            View.BUPlanAdjustment = Model.GetBuPlanAdjustment();
        }

       public void Display(string refID)
       {
           View.BUPlanAdjustment = Model.GetBUPlanAdjustmentVoucherbyRefId(refID);
       }

       public void DisplaybyrefType(string refTypeID)
       {
           View.BUPlanAdjustment = Model.GetBUPlanAdjustmentbyRefTypeId(refTypeID);
       }
    }
}
