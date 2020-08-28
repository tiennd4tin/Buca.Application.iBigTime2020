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

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem
{
    /// <summary>
    /// Class BudgetItemPresenter.
    /// </summary>
    public class BudgetItemPresenter : Presenter<IBudgetItemView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetItemPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BudgetItemPresenter(IBudgetItemView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified budget item identifier.
        /// </summary>
        /// <param name="budgetItemId">The budget item identifier.</param>
        public void Display(string budgetItemId)
        {
            if (budgetItemId == null)
            {
                View.BudgetItemId = null;
                return;
            }

            var budgetItem = Model.GetBudgetItem(budgetItemId);

            View.BudgetItemId = budgetItem.BudgetItemId;
            View.ParentId = budgetItem.ParentId;
            View.BudgetItemType = budgetItem.BudgetItemType;
            View.BudgetItemCode = budgetItem.BudgetItemCode;
            View.BudgetItemName = budgetItem.BudgetItemName;
            View.BudgetGroupItemCode = budgetItem.BudgetGroupItemCode;
            View.Grade = budgetItem.Grade;
            View.IsParent = budgetItem.IsParent;
            View.IsActive = budgetItem.IsActive;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public string Save()
        {
            var budgetItem = new BudgetItemModel
            {
                BudgetItemId = View.BudgetItemId,
                ParentId = View.ParentId,
                BudgetItemType = View.BudgetItemType,
                BudgetItemCode = View.BudgetItemCode,
                BudgetItemName = View.BudgetItemName,
                BudgetGroupItemCode = View.BudgetGroupItemCode,
                Grade = View.Grade,
                IsParent = View.IsParent,
                IsActive = View.IsActive
            };

            if (View.BudgetItemId == null)
                return Model.AddBudgetItem(budgetItem);
            return Model.UpdateBudgetItem(budgetItem);
        }

        /// <summary>
        /// Deletes the specified budget item identifier.
        /// </summary>
        /// <param name="budgetItemId">The budget item identifier.</param>
        /// <returns>System.Int32.</returns>
        public string Delete(string budgetItemId)
        {
            return Model.DeleteBudgetItem(budgetItemId);
        }
    }
}
