/***********************************************************************
 * <copyright file="BUCommitmentAdjustmentsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Monday, December 11, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateMonday, December 11, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.View.Estimate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Presenter.Estimate
{
    /// <summary>
    /// Class BUCommitmentAdjustmentsPresenter.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.Presenter.Presenter{Buca.Application.iBigTime2020.View.Estimate.IBUCommitmentAdjustmentsView}" />
    public class BUCommitmentAdjustmentsPresenter : Presenter<IBUCommitmentAdjustmentsView>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="BUCommitmentAdjustmentsPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BUCommitmentAdjustmentsPresenter(IBUCommitmentAdjustmentsView view)
            : base(view)
        {
        }
        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.BUCommitmentAdjustments = Model.GetBUCommitmentAdjustment();
        }
        public IList<BUCommitmentAdjustmentModel> GetBUCommitmentRequest()
        {
            return Model.GetBUCommitmentAdjustment();
        }
        /// <summary>
        /// Displays the by reference identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        public void Display(int refTypeId)
        {
            View.BUCommitmentAdjustments = Model.GetBUCommitmentAdjustmentsByRefTypeId(refTypeId);
        }
    }
}
