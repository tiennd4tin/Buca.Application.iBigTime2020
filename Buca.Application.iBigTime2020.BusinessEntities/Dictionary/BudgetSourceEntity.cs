/***********************************************************************
 * <copyright file="BudgetSourceEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: 27 September 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Business.General;
using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;

namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    /// <summary>
    /// Class BudgetSourceEntity.
    /// </summary>
    public class BudgetSourceEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetSourceEntity"/> class.
        /// </summary>
        public BudgetSourceEntity()
        {
            AddRule(new ValidateRequired("BudgetSourceCode"));
            AddRule(new ValidateRequired("BudgetSourceName"));
        }

        /// <summary>
        /// Gets or sets the budget source identifier.
        /// </summary>
        /// <value>
        /// The budget source identifier.
        /// </value>
        public string BudgetSourceId { get; set; }

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>
        /// The budget source code.
        /// </value>
        public string BudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget source.
        /// </summary>
        /// <value>
        /// The name of the budget source.
        /// </value>
        public string BudgetSourceName { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public string ParentId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is parent].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is parent]; otherwise, <c>false</c>.
        /// </value>
        public bool IsParent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is saving expenses].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is saving expenses]; otherwise, <c>false</c>.
        /// </value>
        public bool IsSavingExpenses { get; set; }

        /// <summary>
        /// Gets or sets the budget source category identifier.
        /// </summary>
        /// <value>
        /// The budget source category identifier.
        /// </value>
        public string BudgetSourceCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the budget source property.
        /// </summary>
        /// <value>
        /// The budget source property.
        /// </value>
        public int BudgetSourceProperty { get; set; }

        /// <summary>
        /// Gets or sets the bank account.
        /// </summary>
        /// <value>
        /// The bank account.
        /// </value>
        public string BankAccountId { get; set; }

        /// <summary>
        /// Gets or sets the payable bank account.
        /// </summary>
        /// <value>
        /// The payable bank account.
        /// </value>
        public string PayableBankAccountId { get; set; }

        /// <summary>
        /// Gets or sets the target code.
        /// </summary>
        /// <value>
        /// The target code.
        /// </value>
        public string ProjectId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is self control].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is self control]; otherwise, <c>false</c>.
        /// </value>
        public bool IsSelfControl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Get or set BudgetCode
        /// </summary>
        public string BudgetCode { get; set; }

        /// <summary>
        /// Gets or sets the type of the budget source.
        /// </summary>
        /// <value>
        /// The type of the budget source.
        /// </value>
        public short BudgetSourceType { get; set; }

        public int Grade { get; set; }
    }
}
