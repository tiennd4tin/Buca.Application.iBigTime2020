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

using System.Collections.Generic;
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource
{
    /// <summary>
    /// Class BudgetSourcesPresenter.
    /// </summary>
    public class BudgetSourcesPresenter : Presenter<IBudgetSourcesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetSourcesPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BudgetSourcesPresenter(IBudgetSourcesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.BudgetSources = Model.GetBudgetSources();
        }

        /// <summary>
        /// Get List BudgetSources by Active
        /// </summary>
        /// <returns></returns>
        public IList<Model.BusinessObjects.Dictionary.BudgetSourceModel> GetBudgetSources()
        {
            return Model.GetBudgetSources();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.BudgetSources = Model.GetBudgetSourcesActive();
        }

        /// <summary>
        /// Displays the is parent.
        /// </summary>
        /// <param name="isParent">if set to <c>true</c> [is parent].</param>
        public void DisplayIsParent(bool isParent)
        {
            View.BudgetSources = Model.GetBudgetSourcesIsParent(isParent);
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void DisplayByFund()
        {
            View.BudgetSources = Model.GetBudgetSourcesByFund();
        }

        /// <summary>
        /// Displays for combo tree.
        /// </summary>
        /// <param name="budgetSourceId">The account identifier.</param>
        public void DisplayForComboTree(int budgetSourceId)
        {
            View.BudgetSources = Model.GetBudgetSourcesForComboTree(budgetSourceId);
        }

    }
}
