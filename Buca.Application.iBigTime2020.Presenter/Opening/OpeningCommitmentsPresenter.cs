/***********************************************************************
 * <copyright file="OpeningCommitmentsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Friday, December 8, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateFriday, December 8, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.View.OpeningCommitment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Presenter.Opening
{
    /// <summary>
    /// Class OpeningCommitmentsPresenter.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.Presenter.Presenter{Buca.Application.iBigTime2020.View.OpeningCommitment.IOpeningCommitmentsView}" />
    public class OpeningCommitmentsPresenter : Presenter<IOpeningCommitmentsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BUCommitmentRequestsPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public OpeningCommitmentsPresenter(IOpeningCommitmentsView view)
            : base(view)
        {
        }
        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.OpeningCommitments = Model.GetOpeningCommitment();
        }

        /// <summary>
        /// Displays the by reference identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        public void Display(int refTypeId)
        {
            View.OpeningCommitments = Model.GetOpeningCommitmentsByRefTypeId(refTypeId);
        }
    }
}
