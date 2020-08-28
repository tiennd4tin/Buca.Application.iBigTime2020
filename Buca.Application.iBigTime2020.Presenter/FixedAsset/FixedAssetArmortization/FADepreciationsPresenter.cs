/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.FixedAsset;
using Buca.Application.iBigTime2020.View.FixedAsset;

namespace Buca.Application.iBigTime2020.Presenter.FixedAsset.FixedAssetArmortization
{
    /// <summary>
    /// FADepreciationsPresenter
    /// </summary>
    public class FADepreciationsPresenter : Presenter<IFADepreciationsView>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FADepreciationsPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public FADepreciationsPresenter(IFADepreciationsView view)
            : base(view)
        {
        }

        /// <summary>
        ///     Displays this instance.
        /// </summary>
        public void Display()
        {
            View.FADepreciations = Model.GetFADepreciations();
        }

        /// <summary>
        /// Displays the specified reference type.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        public void Display(int refType)
        {
            View.FADepreciations = Model.GetFADepreciationsByRefTypeId(refType);
        }

        /// <summary>
        /// Displays the specified reference type.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// /// <param name="refDate">Type of the reference.</param>
        public IList<FADepreciationModel> GetFADepreciationsInYear(int refType, DateTime refDate)
        {
             return Model.GetFADepreciationsByYearOfPostDate(refType, refDate);
        }

        /// <summary>
        /// Gets the fa depreciations in year.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="periodType">Type of the period.</param>
        /// <returns></returns>
        public IList<FADepreciationModel> GetFADepreciationsInYear(int refType, DateTime refDate, int periodType)
        {
            return Model.GetFADepreciationsByRefDateAndPeriodType(refType, refDate, periodType);
        }

        /// <summary>
        /// Gets the fa devaluation.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="periodType">Type of the period.</param>
        /// <returns></returns>
        public IList<FADepreciationModel> GetFADevaluations(int refType, DateTime refDate, int periodType)
        {
            return Model.GetFADevaluations(refType, refDate, periodType);
        }
    }
}
