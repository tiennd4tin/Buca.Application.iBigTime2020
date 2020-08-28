using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetExpense
{
    /// <summary>
    /// Class BudgetExpensesPresenter.
    /// </summary>
    public class BudgetExpensesPresenter : Presenter<IBudgetExpensesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetExpensesPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BudgetExpensesPresenter(IBudgetExpensesView view)
            : base(view)
        {
        }
        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.BudgetExpenses = Model.GetBudgetExpenses();
        }

        public void DisplayActive()
        {
            View.BudgetExpenses = Model.GetBudgetExpensesByIsActive(true);
        }
    }
}
