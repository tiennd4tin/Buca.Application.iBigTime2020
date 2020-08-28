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

using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;

namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    /// <summary>
    /// BudgetSourceCategoryEntity
    /// </summary>
    public class BudgetSourceCategoryEntity : BusinessEntities
    {
        public BudgetSourceCategoryEntity()
        {
            AddRule(new ValidateRequired("BudgetSourceCategoryCode"));
            AddRule(new ValidateRequired("BudgetSourceCategoryName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetSourceCategoryEntity" /> class.
        /// </summary>
        /// <param name="budgetSourceCategoryId">The budget source category identifier.</param>
        /// <param name="budgetSourceCategoryCode">The budget source category code.</param>
        /// <param name="budgetSourceCategoryName">Name of the budget source category.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <param name="isParent">if set to <c>true</c> [is parent].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public BudgetSourceCategoryEntity(string budgetSourceCategoryId, string budgetSourceCategoryCode, string budgetSourceCategoryName,
            string parentId, bool isParent, bool isActive)
            : this()
        {
            BudgetSourceCategoryId = budgetSourceCategoryId;
            BudgetSourceCategoryCode = budgetSourceCategoryCode;
            BudgetSourceCategoryName = budgetSourceCategoryName;
            IsActive = isActive;
            ParentId = parentId;
            IsParent = isParent;
        }

        /// <summary>
        /// Gets or sets the budget source category identifier.
        /// </summary>
        /// <value>
        /// The budget source category identifier.
        /// </value>
        public string BudgetSourceCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the budget source category code.
        /// </summary>
        /// <value>
        /// The budget source category code.
        /// </value>
        public string BudgetSourceCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget source category.
        /// </summary>
        /// <value>
        /// The name of the budget source category.
        /// </value>
        public string BudgetSourceCategoryName { get; set; }

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
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
