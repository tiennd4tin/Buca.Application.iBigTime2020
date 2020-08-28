/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 12, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.InvoiceFormNumber
{
    public class InvoiceFormNumberPresenter : Presenter<IInvoiceFormNumberView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceFormNumberPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public InvoiceFormNumberPresenter(IInvoiceFormNumberView view)
            : base(view)
        {

        }

        /// <summary>
        /// Displays the specified inventory item identifier.
        /// </summary>
        /// <param name="invoiceFormNumberId">The invoice form number identifier.</param>
        public void Display(string invoiceFormNumberId)
        {
            if (invoiceFormNumberId == null)
            {
                View.InvoiceFormNumberId = null;
                return;
            }

            var invoiceFormNumber = Model.GetInvoiceFormNumber(invoiceFormNumberId);

            View.InvoiceFormNumberId = invoiceFormNumber.InvoiceFormNumberId;
            View.InvoiceFormNumberCode = invoiceFormNumber.InvoiceFormNumberCode;
            View.InvoiceFormNumberName = invoiceFormNumber.InvoiceFormNumberName;
            View.InvoiceType = invoiceFormNumber.InvoiceType;
            View.IsSystem = invoiceFormNumber.IsSystem;
            View.IsActive = invoiceFormNumber.IsActive;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public string Save()
        {
            var invoiceFormNumber = new InvoiceFormNumberModel
            {
                InvoiceFormNumberId = View.InvoiceFormNumberId,
                InvoiceFormNumberCode = View.InvoiceFormNumberCode,
                InvoiceFormNumberName = View.InvoiceFormNumberName,
                InvoiceType = View.InvoiceType,
                IsActive = View.IsActive,
                IsSystem = View.IsSystem
            };
            return View.InvoiceFormNumberId == null ? Model.InsertInvoiceFormNumber(invoiceFormNumber) : Model.UpdateInvoiceFormNumber(invoiceFormNumber);
        }

        /// <summary>
        /// Deletes the specified inventory item identifier.
        /// </summary>
        /// <param name="invoiceFormNumberId">The invoice form number identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        public string Delete(string invoiceFormNumberId)
        {
            return Model.DeleteInvoiceFormNumber(invoiceFormNumberId);
        }
    }
}
