/***********************************************************************
 * <copyright file="ReceiptVouchersPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Wednesday, March 19, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using Buca.Application.iBigTime2020.View.Inventory;

namespace Buca.Application.iBigTime2020.Presenter.Inventory
{
    public class INInwardOutwardsPresenter : Presenter<IINInwardOutwardsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="INInwardOutwardsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public INInwardOutwardsPresenter(IINInwardOutwardsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.INInwardOutwards = Model.GetINInwardOutwards();
        }

        /// <summary>
        /// Displays the type of the by reference.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        public void DisplayByRefType(int refTypeId)
        {
            View.INInwardOutwards = Model.GetINInwardOutwardByRefTypeId(refTypeId);
        }

        public bool CheckExistVoucher(DateTime fromDate, DateTime toDate, string inventoryItem)
        {
            return Model.CheckExistVoucher(fromDate, toDate, inventoryItem);
        }
    }
}
