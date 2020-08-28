/***********************************************************************
 * <copyright file="BUCommitmentRequestsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, December 6, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, December 6, 2017 Author SonTV  Description 
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
    /// Class BUCommitmentRequestsPresenter.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.Presenter.Presenter{Buca.Application.iBigTime2020.View.Estimate.IBUCommitmentRequestsView}" />
    public class BUCommitmentRequestsPresenter : Presenter<IBUCommitmentRequestsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BUCommitmentRequestsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BUCommitmentRequestsPresenter(IBUCommitmentRequestsView view)
            : base(view)
        {
        }
        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.BUCommitmentRequests = Model.GetBUCommitmentRequest();
        }

        /// <summary>
        /// Displays the type of the by reference.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void DisplayByRefId(string refId)
        {
            View.BUCommitmentRequests = Model.GetBUCommitmentRequest(refId);
        }

        /// <summary>
        /// Displays the by reference identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        public void Display(int refTypeId)
        {
            View.BUCommitmentRequests = Model.GetBUCommitmentRequestsByRefTypeId(refTypeId);
        }
    }
}
