/***********************************************************************
 * <copyright file="AutoBusinessParallelEntity.cs" company="BUCA JSC">
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
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.AutoBusinessParallel
{
    /// <summary>
    /// Class AutoBusinessParallelsPresenter.
    /// </summary>
    public class AutoBusinessParallelsPresenter : Presenter<IAutoBusinessParallelsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoBusinessParallelsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AutoBusinessParallelsPresenter(IAutoBusinessParallelsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.AutoBusinessParallels = Model.GetAutoBusinessParallels();
        }

        /// <summary>
        /// Get list Account Category
        /// </summary>
        /// <returns>IList{Model.BusinessObjects.Dictionary.AccountCategoryModel}.</returns>
        public IList<AutoBusinessParallelModel> GetAutoBusinessParallels()
        {
            return Model.GetAutoBusinessParallels();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.AutoBusinessParallels = Model.GetAutoBusinessParallelsActive();
        }
    }
}
