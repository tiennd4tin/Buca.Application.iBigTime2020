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
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem
{
    public class BudgetKindItemsPresenter : Presenter<IBudgetKindItemsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetKindItemsPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BudgetKindItemsPresenter(IBudgetKindItemsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.BudgetKindItems = Model.GetBudgetKindItems();
        }

        /// <summary>
        /// Get list Account Category
        /// </summary>
        /// <returns>IList{Model.BusinessObjects.Dictionary.AccountCategoryModel}.</returns>
        public IList<BudgetKindItemModel> GetBudgetKindItems()
        {
            return Model.GetBudgetKindItems();
        }

        /// <summary>
        /// Gets the budget kind item.
        /// </summary>
        /// <param name="budgetKindItemId">The budget kind item identifier.</param>
        /// <returns></returns>
        public BudgetKindItemModel GetBudgetKindItem(string budgetKindItemId)
        {
            return Model.GetBudgetKindItem(budgetKindItemId);
        }

        public BudgetKindItemModel GetBudgetKindItemByCode(string budgetKindItemCode)
        {
            return Model.GetBudgetKindItemsByCode(budgetKindItemCode);
        }
        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.BudgetKindItems = Model.GetBudgetKindItemsByActive();
        }
    }
}
