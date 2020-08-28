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
using System.Collections;
using System.Collections.Generic;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem
{
    /// <summary>
    /// Class BudgetItemsPresenter.
    /// </summary>
    public class BudgetItemsPresenter : Presenter<IBudgetItemsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetItemsPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BudgetItemsPresenter(IBudgetItemsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.BudgetItems = Model.GetBudgetItems();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public void DisplayActive(bool isActive)
        {
            View.BudgetItems = Model.GetBudgetItemsByIsActive(isActive);
        }

        /// <summary>
        /// Displays the specified budget item type.
        /// </summary>
        /// <param name="budgetItemType">Type of the budget item.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public void Display(int budgetItemType, bool isActive)
        {
            View.BudgetItems = Model.GetBudgetItemAndSubItem(budgetItemType, isActive);
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayIsReceipt()
        {
            View.BudgetItems = Model.GetBudgetItemsByReceipt();
        }

        /// <summary>
        /// Displays the is capital allocate.
        /// </summary>
        public void DisplayIsCapitalAllocate()
        {
            View.BudgetItems = Model.GetBudgetItemsCapitalAllocate();
        }

        /// <summary>
        /// Displays the is receipt for estimate.
        /// </summary>
        public void DisplayIsReceiptForEstimate()
        {
            View.BudgetItems = Model.GetBudgetItemsByReceiptForEstimate();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayIsPayment()
        {
            View.BudgetItems = Model.GetBudgetItemsByPayment();
        }

        /// <summary>
        /// Displays the payment voucher.
        /// </summary>
        public void DisplayPaymentVoucher()
        {
            View.BudgetItems = Model.GetBudgetItemsPayVoucher();
        }

        /// <summary>
        /// Displays the is payment for estimate.
        /// </summary>
        public void DisplayIsPaymentForEstimate()
        {
            View.BudgetItems = Model.GetBudgetItemsByPaymentForEstimate();
        }

        /// <summary>
        /// Gets the budget item.
        /// </summary>
        /// <param name="budgetItemId">The budget item identifier.</param>
        /// <returns></returns>
        public BudgetItemModel GetBudgetItem(string budgetItemId)
        {
            return Model.GetBudgetItem(budgetItemId);
        }

        /// <summary>
        /// Gets the budget items.
        /// </summary>
        /// <returns>IList&lt;BudgetItemModel&gt;.</returns>
        public IList<BudgetItemModel> GetBudgetItems()
        {
            return Model.GetBudgetItems();
        }
    }
}
