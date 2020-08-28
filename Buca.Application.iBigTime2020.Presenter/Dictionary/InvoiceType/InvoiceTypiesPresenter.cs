/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.InvoiceType
{
    /// <summary>
    /// InvoiceFormNumberCategoriesPresenter
    /// </summary>
    public class InvoiceTypiesPresenter : Presenter<IInvoiceTypiesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceTypiesPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public InvoiceTypiesPresenter(IInvoiceTypiesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.InvoiceTypies = Model.GetInvoiceTypies();
        }
    }
}
