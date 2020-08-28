/***********************************************************************
 * <copyright file="FrmXtraFixedAssetCategoryTreeDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: Wednesday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/


using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter
{
    /// <summary>
    /// Class BudgetChaptersPresenter.
    /// </summary>
    public class BudgetChaptersPresenter : Presenter<IBudgetChaptersView>
    {
        /// <summary>
        /// Initializes a new instance of the <see /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BudgetChaptersPresenter(IBudgetChaptersView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.BudgetChapters = Model.GetBudgetChapters();
        }

        /// <summary>
        /// Get List BudgetChapters by Active
        /// </summary>
        /// <returns></returns>
        public IList<BudgetChapterModel> GetBudgetChapters()
        {
            return Model.GetBudgetChapters();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public void DisplayByIsActive(bool isActive)
        {
            View.BudgetChapters = Model.GetBudgetChaptersByIsActive(isActive);
        }
    }
}
