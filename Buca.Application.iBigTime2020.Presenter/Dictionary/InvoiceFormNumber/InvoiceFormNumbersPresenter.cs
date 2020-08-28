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

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.InvoiceFormNumber
{
   public class InvoiceFormNumbersPresenter: Presenter<IInvoiceFormNumbersView>
    {
       /// <summary>
        /// Initializes a new instance of the <see cref="VoucherListPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
       public InvoiceFormNumbersPresenter(IInvoiceFormNumbersView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.InvoiceFormNumbers = Model.GetInvoiceFormNumbers();
        }

        /// <summary>
        /// Get list Account Category
        /// </summary>
        /// <returns>IList{Model.BusinessObjects.Dictionary.AccountCategoryModel}.</returns>
        public IList<InvoiceFormNumberModel> GetInvoiceFormNumbers()
        {
            return Model.GetInvoiceFormNumbers();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.InvoiceFormNumbers = Model.GetInvoiceFormNumbersByActive();
        }
    }
}
