using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.View.Estimate;

namespace Buca.Application.iBigTime2020.Presenter.Estimate
{
    public class BUPlanReceiptsPresenter : Presenter<IBUPlanReceiptsView>
    {
        public BUPlanReceiptsPresenter(IBUPlanReceiptsView view) : base(view)
        {
        }

        public void Display()
        {
            View.BUPlanReceipts = Model.GetBUPlanReceipt();
        }

        /// <summary>
        /// Displays the type of the by reference.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        public void DisplayByRefId(string refId)
        {
            View.BUPlanReceipts = Model.GetBUPlanReceiptbyRefId(refId);
        }

        /// <summary>
        /// Displays the by reference identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        public void Display(int refTypeId)
        {
            View.BUPlanReceipts = Model.GetBUPlanReceiptbyRefType(refTypeId);
        }
    }
}
