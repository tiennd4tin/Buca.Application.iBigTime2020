/***********************************************************************
 * <copyright file="BUPlanWithdrawsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Thursday, November 2, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateThursday, November 2, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.View.Estimate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Presenter.Estimate
{
    /// <summary>
    /// Class BUPlanWithdrawsPresenter.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.Presenter.Presenter{Buca.Application.iBigTime2020.View.Estimate.IBUPlanWithdrawsView}" />
    public class BUPlanWithdrawsPresenter : Presenter<IBUPlanWithdrawsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CAReceiptsPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BUPlanWithdrawsPresenter(IBUPlanWithdrawsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.BUPlanWithdraws = Model.GetBUPlanWithdraws();
        }

        /// <summary>
        /// Displays the type of the by reference.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        public void DisplayByRefType(int refTypeId)
        {
            View.BUPlanWithdraws = Model.GetBUPlanWithdrawByRefTypeId(refTypeId);
        }
    }
}
