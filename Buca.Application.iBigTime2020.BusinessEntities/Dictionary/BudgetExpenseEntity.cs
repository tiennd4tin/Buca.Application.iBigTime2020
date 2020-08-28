using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;

namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    /// <summary>
    /// Class BudgetExpense.
    /// </summary>
    public class BudgetExpenseEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetExpenseEntity"/> class.
        /// </summary>
        public BudgetExpenseEntity()
        {
            AddRule(new ValidateRequired("BudgetExpenseCode"));
            AddRule(new ValidateRequired("BudgetExpenseName"));
        }

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
