/***********************************************************************
 * <copyright file="BUTransfersPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, December 13, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, December 13, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.View.Estimate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Presenter.Estimate
{
    /// <summary>
    /// Class BUTransfersPresenter.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.Presenter.Presenter{Buca.Application.iBigTime2020.View.Estimate.IBUTransfersView}" />
    public class BUTransfersPresenter : Presenter<IBUTransfersView>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="BUTransfersPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BUTransfersPresenter(IBUTransfersView view)
            : base(view)
        {
        }
        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.BUTransfers = Model.GetBUTransfer();
        }

        /// <summary>
        /// Displays the by reference identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        public void Display(int refTypeId)
        {
            View.BUTransfers = Model.GetBUTransfersByRefTypeId(refTypeId);
        }

        public void Display(List<RefTypeModel> listRefType)
        {
            var _bUTransfers = new List<BUTransferModel>();
            listRefType.ForEach(m => { _bUTransfers.AddRange(Model.GetBUTransfersByRefTypeId(m.RefTypeId)); });
            View.BUTransfers = _bUTransfers;
        }
    }
}
