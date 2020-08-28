using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetExpense
{
    public class BudgetExpensePresenter : Presenter<IBudgetExpenseView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetExpensePresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BudgetExpensePresenter(IBudgetExpenseView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified account category identifier.
        /// </summary>
        /// <param name="budgetExpenseId">The account category identifier.</param>
        public void Display(string budgetExpenseId)
        {
            if (budgetExpenseId == null)
            {
                View.BudgetExpenseId = null;
                return;
            }

            var budgetExpense = Model.GetBudgetExpense(budgetExpenseId);

            View.BudgetExpenseId = budgetExpense.BudgetExpenseId;
            View.BudgetExpenseName = budgetExpense.BudgetExpenseName;
            View.BudgetExpenseCode = budgetExpense.BudgetExpenseCode;
            View.IsSystem = budgetExpense.IsSystem;
            View.BudgetExpenseType = budgetExpense.BudgetExpenseType;
            View.IsActive = budgetExpense.IsActive;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public string Save()
        {
            var budgetExpense = new BudgetExpenseModel
            {
                BudgetExpenseId = View.BudgetExpenseId,
                BudgetExpenseName = View.BudgetExpenseName,
                BudgetExpenseCode = View.BudgetExpenseCode,
                BudgetExpenseType = View.BudgetExpenseType,
                IsSystem = View.IsSystem,
                IsActive = View.IsActive
            };

            if (View.BudgetExpenseId == null)
                return Model.AddBudgetExpense(budgetExpense);
            return Model.UpdateBudgetExpense(budgetExpense);
        }

        /// <summary>
        /// Deletes the specified account category identifier.
        /// </summary>
        /// <param name="budgetExpenseId">The account category identifier.</param>
        /// <returns>System.Int32.</returns>
        public string Delete(string budgetExpenseId)
        {
            return Model.DeleteBudgetExpense(budgetExpenseId);
        }
    }
}
