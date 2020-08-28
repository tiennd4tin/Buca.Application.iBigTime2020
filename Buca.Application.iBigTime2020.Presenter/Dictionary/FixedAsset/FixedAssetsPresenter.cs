/***********************************************************************
 * <copyright file="FixedAssetsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Wednesday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Linq;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAsset
{
    /// <summary>
    /// FixedAssets Presenter
    /// </summary>
    public class FixedAssetsPresenter : Presenter<IFixedAssetsView>
    {
        private CompanyProfileModel _companyProfile;
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public FixedAssetsPresenter(IFixedAssetsView view)
            : base(view)
        {
        }

        public void Display()
        {
            View.FixedAssets = Model.GetFixedAssets();
        }

        /// <summary>
        /// Displays the by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public void DisplayByActive(bool isActive)
        {
            View.FixedAssets = Model.GetFixedAssetsActive(isActive);
        }
        public void DisplayByActiveDecre(bool isActive,string refId)
        {
            View.FixedAssets = Model.GetFixedAssetsActiveDecre(isActive, refId);
        }
        /// <summary>
        /// Displays for decrement.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="refDate">The reference date.</param>
        public void DisplayForDecrement(bool isActive, DateTime refDate)
        {
            View.FixedAssets = Model.GetFixedAssetsForDecrement(isActive, refDate);
        }

        /// <summary>
        /// Displays for adjustment.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="refDate">The reference date.</param>
        public void DisplayForAdjustment(bool isActive, DateTime refDate)
        {
            View.FixedAssets = Model.GetFixedAssetsForAdjustment(null, refDate,0, false);
        }
    }
}
