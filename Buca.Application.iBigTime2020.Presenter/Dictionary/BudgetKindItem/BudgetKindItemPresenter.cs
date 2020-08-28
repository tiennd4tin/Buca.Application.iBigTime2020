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

using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem
{
    public class BudgetKindItemPresenter: Presenter<IBudgetKindItemView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetKindItemPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BudgetKindItemPresenter(IBudgetKindItemView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified account category identifier.
        /// </summary>
        /// <param name="budgetKindItemId">The budget kind item identifier.</param>
        public void Display(string budgetKindItemId)
        {
            if (budgetKindItemId == null)
            {
                View.BudgetKindItemId = null;
                return;
            }

            var budgetKindItem = Model.GetBudgetKindItem(budgetKindItemId);

            View.BudgetKindItemId = budgetKindItem.BudgetKindItemId;
            View.ParentId = budgetKindItem.ParentId;
            View.BudgetKindItemCode = budgetKindItem.BudgetKindItemCode;
            View.BudgetKindItemName = budgetKindItem.BudgetKindItemName;
            View.Grade = budgetKindItem.Grade;
            View.IsParent = budgetKindItem.IsParent;
            View.IsActive = budgetKindItem.IsActive;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public string Save()
        {
            var budgetKindItem = new BudgetKindItemModel
            {
                BudgetKindItemId = View.BudgetKindItemId,
                ParentId = View.ParentId,
                BudgetKindItemCode = View.BudgetKindItemCode,
                BudgetKindItemName = View.BudgetKindItemName,
                Grade = View.Grade,
                IsParent = View.IsParent,
                IsActive = View.IsActive
            };

            if (View.BudgetKindItemId == null)
                return Model.AddBudgetKindItem(budgetKindItem);
            return Model.UpdateBudgetKindItem(budgetKindItem);
        }

        /// <summary>
        /// Deletes the specified account category identifier.
        /// </summary>
        /// <param name="budgetKindItemId">The budget kind item identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        public string Delete(string budgetKindItemId)
        {
            return Model.DeleteBudgetKindItem(budgetKindItemId);
        }
    }
}
