/***********************************************************************
 * <copyright file="AutoBusinessEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: 27 September 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Linq;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.AutoBusiness
{
    public class AutoBusinessesPresenter : Presenter<IAutoBusinessesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoBusinessPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AutoBusinessesPresenter(IAutoBusinessesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.AutoBusinesses = Model.GetAutoBusinesses();
        }
        public void DisplayRef(int refType)
        {
            List<AutoBusinessModel> autoBusinesses = Model.GetAutoBusinesses().ToList();
            View.AutoBusinesses = autoBusinesses.Where(a => a.RefTypeId == refType).ToList();
        }
        /// <summary>
        /// Get list Account Category
        /// </summary>
        /// <returns>IList{Model.BusinessObjects.Dictionary.AccountCategoryModel}.</returns>
        public IList<AutoBusinessModel> GetAutoBusinesses()
        {
            return Model.GetAutoBusinesses();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.AutoBusinesses = Model.GetAutoBusinessesActive();
        }

        /// <summary>
        /// Displays the by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public void DisplayByRefTypeId(int refTypeId, bool isActive)
        {
            View.AutoBusinesses = Model.GetAutoBusinessByRefType(refTypeId, isActive);
        }
    }
}
