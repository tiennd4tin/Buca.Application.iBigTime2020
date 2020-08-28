/***********************************************************************
 * <copyright file="PurchasePurposesPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, October 12, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Windows.Forms;
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.PurchasePurpose
{
    /// <summary>
    /// PurchasePurposesPresenter
    /// </summary>
    /// <seealso cref="Application.iBigTime2020.View.Dictionary.IPurchasePurposesView}" />
    public class PurchasePurposesPresenter : Presenter<IPurchasePurposesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchasePurposesPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public PurchasePurposesPresenter(IPurchasePurposesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.PurchasePurposes = Model.GetPurchasePurposes();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public void DisplayByIsActive(bool isActive)
        {
            View.PurchasePurposes = Model.GetPurchasePurposesByIsActive(isActive);
        }
    }
}