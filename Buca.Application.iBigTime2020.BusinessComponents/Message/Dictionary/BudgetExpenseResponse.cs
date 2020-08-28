
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary
{
    public class BudgetExpenseResponse : ResponseBase
    {
        public BudgetExpenseEntity BudgetExpenseEntity { get; set; }

        /// <summary>
        /// Gets or sets the account category identifier.
        /// </summary>
        /// <value>The account category identifier.</value>
        public string BudgetExpenseId { get; set; }
    }
}
