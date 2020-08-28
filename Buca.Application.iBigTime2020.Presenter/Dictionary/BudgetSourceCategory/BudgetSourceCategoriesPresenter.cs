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

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSourceCategory
{
    /// <summary>
    /// class BudgetSourceCategoriesPresente
    /// </summary>
    public class BudgetSourceCategoriesPresenter : Presenter<IBudgetSourceCategoriesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetSourceCategoriesPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BudgetSourceCategoriesPresenter(IBudgetSourceCategoriesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displaies this instance.
        /// </summary>
        public void Display()
        {
            View.BudgetSourceCategories = Model.GetBudgetSourceCategories();
        }

        /// <summary>
        /// Displaies the active.
        /// </summary>
        public void DisplayActive()
        {
            View.BudgetSourceCategories = Model.GetBudgetSourceCategoriesActive();
        }
    }
}
