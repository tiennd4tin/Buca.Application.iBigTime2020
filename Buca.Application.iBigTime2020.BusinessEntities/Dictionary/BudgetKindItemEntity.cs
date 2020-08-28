
using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;

namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    public class BudgetKindItemEntity : BusinessEntities
    {
       /// <summary>
        /// Initializes a new instance of the <see cref="BudgetItemEntity"/> class.
        /// </summary>
        public BudgetKindItemEntity()
        {
            AddRule(new ValidateRequired("BudgetKindItemCode"));
            AddRule(new ValidateRequired("BudgetKindItemName"));
        }

        /// <summary>
        /// Gets or sets the budget kind item identifier.
        /// </summary>
        /// <value>
        /// The budget kind item identifier.
        /// </value>
        public string BudgetKindItemId { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public string ParentId { get; set; }

        /// <summary>
        /// Gets or sets the budget kind item code.
        /// </summary>
        /// <value>
        /// The budget kind item code.
        /// </value>
        public string BudgetKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget kind item.
        /// </summary>
        /// <value>
        /// The name of the budget kind item.
        /// </value>
        public string BudgetKindItemName { get; set; }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>
        /// The grade.
        /// </value>
        public int Grade { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is parent].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is parent]; otherwise, <c>false</c>.
        /// </value>
        public bool IsParent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
