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
    /// BudgetSourcePropertyEntity
    /// </summary>
    public class BudgetSourcePropertyEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetSourcePropertyEntity"/> class.
        /// </summary>
        public BudgetSourcePropertyEntity()
        {
            AddRule(new ValidateRequired("BudgetSourcePropertyCode"));
            AddRule(new ValidateRequired("BudgetSourcePropertyName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetSourcePropertyEntity"/> class.
        /// </summary>
        /// <param name="budgetSourceCategoryId">The budget source category identifier.</param>
        /// <param name="budgetSourceCategoryCode">The budget source category code.</param>
        /// <param name="budgetSourceCategoryName">Name of the budget source category.</param>
        /// <param name="isSystem">if set to <c>true</c> [is system].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="parentId">The parent identifier.</param>
        public BudgetSourcePropertyEntity(string budgetSourceCategoryId, string budgetSourceCategoryCode, string budgetSourceCategoryName,
                                                    bool isSystem, bool isActive, string parentId)
            : this()
        {
            BudgetSourceCategoryId = budgetSourceCategoryId;
            BudgetSourceCategoryCode = budgetSourceCategoryCode;
            BudgetSourceCategoryName = budgetSourceCategoryName;
            IsActive = isActive;
            ParentId = parentId;
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
