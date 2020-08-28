using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// Class BudgetExpense.
    /// </summary>
    public class BudgetExpenseModel
    {
        /// <summary>
        /// Gets or sets the budget expense identifier.
        /// </summary>
        /// <value>The budget expense identifier.</value>
        public string BudgetExpenseId { get; set; }

        /// <summary>
        /// Gets or sets the budget expense code.
        /// </summary>
        /// <value>The budget expense code.</value>
        public string BudgetExpenseCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget expense.
        /// </summary>
        /// <value>The name of the budget expense.</value>
        public string BudgetExpenseName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BudgetExpenseEntity"/> is inactive.
        /// </summary>
        /// <value><c>true</c> if inactive; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value><c>true</c> if this instance is system; otherwise, <c>false</c>.</value>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets the type of the budget expense.
        /// </summary>
        /// <value>The type of the budget expense.</value>
        public int BudgetExpenseType { get; set; }
    }
}
