/***********************************************************************
 * <copyright file="PurchasePurposePresenter.cs" company="BUCA JSC">
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

using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.PurchasePurpose
{
    /// <summary>
    ///     PurchasePurposePresenter
    /// </summary>
    /// <seealso
    ///     cref="Buca.Application.iBigTime2020.Presenter.Presenter{Buca.Application.iBigTime2020.View.Dictionary.IPurchasePurposeView}" />
    public class PurchasePurposePresenter : Presenter<IPurchasePurposeView>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PurchasePurposePresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public PurchasePurposePresenter(IPurchasePurposeView view) : base(view)
        {
        }

        /// <summary>
        ///     Displays the specified purchasePurpose identifier.
        /// </summary>
        /// <param name="purchasePurposeId">The purchasePurpose identifier.</param>
        public void Display(string purchasePurposeId)
        {
            if (purchasePurposeId == null)
            {
                View.PurchasePurposeId = null;
                return;
            }
            var purchasePurpose = Model.GetPurchasePurpose(purchasePurposeId);
            View.PurchasePurposeId = purchasePurpose.PurchasePurposeId;
            View.PurchasePurposeCode = purchasePurpose.PurchasePurposeCode;
            View.PurchasePurposeName = purchasePurpose.PurchasePurposeName;
            View.Description = purchasePurpose.Description;
            View.IsActive = purchasePurpose.IsActive;
        }

        /// <summary>
        ///     Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public string Save()
        {
            var purchasePurpose = new PurchasePurposeModel
            {
                PurchasePurposeId = View.PurchasePurposeId,
                PurchasePurposeCode = View.PurchasePurposeCode,
                PurchasePurposeName = View.PurchasePurposeName,
                Description = View.Description,
                IsActive = View.IsActive,
                IsSystem = false
            };
            return View.PurchasePurposeId == null
                ? Model.InsertPurchasePurpose(purchasePurpose)
                : Model.UpdatePurchasePurpose(purchasePurpose);
        }

        /// <summary>
        ///     Deletes the specified purchasePurpose identifier.
        /// </summary>
        /// <param name="purchasePurposeId">The purchasePurpose identifier.</param>
        /// <returns>System.Int32.</returns>
        public string Delete(string purchasePurposeId)
        {
            return Model.DeletePurchasePurpose(purchasePurposeId);
        }

        /// <summary>
        /// Gets the purchase purpose by code.
        /// </summary>
        /// <param name="purchasePurposeId">The purchase purpose identifier.</param>
        /// <param name="purchasePurposeCode">The purchase purpose code.</param>
        /// <returns></returns>
        public PurchasePurposeModel GetPurchasePurposeByCode(string purchasePurposeId, string purchasePurposeCode)
        {
            var purchasePurpose = Model.GetPurchasePurposeByCode(purchasePurposeCode);
            if (!string.IsNullOrEmpty(purchasePurposeId) && purchasePurposeId.Equals(purchasePurpose.PurchasePurposeId))
                return null;
            return Model.GetPurchasePurposeByCode(purchasePurposeCode);
        }
    }
}