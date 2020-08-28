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

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource
{
    /// <summary>
    /// Class BudgetSourcePresenter.
    /// </summary>
    public class BudgetSourcePresenter : Presenter<IBudgetSourceView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetSourcePresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BudgetSourcePresenter(IBudgetSourceView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified budgetSource identifier.
        /// </summary>
        /// <param name="budgetSourceId">The budgetSource identifier.</param>
        public void Display(string budgetSourceId)
        {
            if (budgetSourceId == null)
            {
                View.BudgetSourceId = null;
                return;
            }

            var budgetSource = Model.GetBudgetSource(budgetSourceId);

            View.BudgetSourceId = budgetSource.BudgetSourceId;
            View.BudgetSourceCode = budgetSource.BudgetSourceCode;
            View.BudgetSourceName = budgetSource.BudgetSourceName;
            View.ParentId = budgetSource.ParentId;
            View.IsParent = budgetSource.IsParent;
            View.IsSavingExpenses = budgetSource.IsSavingExpenses;
            View.BudgetSourceCategoryId = budgetSource.BudgetSourceCategoryId;
            View.BudgetSourceProperty = budgetSource.BudgetSourceProperty;
            View.BankAccountId = budgetSource.BankAccountId;
            View.PayableBankAccountId = budgetSource.PayableBankAccountId;
            View.ProjectId = budgetSource.ProjectId;
            View.IsSelfControl = budgetSource.IsSelfControl;
            View.IsActive = budgetSource.IsActive;
            View.BudgetCode = budgetSource.BudgetCode;
            View.BudgetSourceType = budgetSource.BudgetSourceType;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public string Save()
        {
            var budgetSource = new BudgetSourceModel
            {
                BudgetSourceId = View.BudgetSourceId,
                BudgetSourceCode = View.BudgetSourceCode,
                BudgetSourceName = View.BudgetSourceName,
                ParentId = View.ParentId,
                IsParent = View.IsParent,
                IsSavingExpenses = View.IsSavingExpenses,
                BudgetSourceCategoryId = View.BudgetSourceCategoryId,
                BudgetSourceProperty = View.BudgetSourceProperty,
                BankAccountId = View.BankAccountId,
                PayableBankAccountId = View.PayableBankAccountId,
                ProjectId = View.ProjectId,
                IsSelfControl = View.IsSelfControl,
                IsActive = View.IsActive,
                BudgetCode = View.BudgetCode,
                BudgetSourceType = View.BudgetSourceType
            };

            if (View.BudgetSourceId == null)
                return Model.AddBudgetSource(budgetSource);
            return Model.UpdateBudgetSource(budgetSource);
        }

        /// <summary>
        /// Deletes the specified budget source identifier.
        /// </summary>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <returns>System.Int32.</returns>
        public string Delete(string budgetSourceId)
        {
            return Model.DeleteBudgetSource(budgetSourceId);
        }
    }
}