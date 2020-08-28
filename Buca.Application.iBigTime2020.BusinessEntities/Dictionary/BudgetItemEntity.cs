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
    /// Class BudgetItemEntity.
    /// </summary>
    public class BudgetItemEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetItemEntity"/> class.
        /// </summary>
        public BudgetItemEntity()
        {
            AddRule(new ValidateRequired("BudgetItemCode"));
            AddRule(new ValidateRequired("BudgetItemName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetItemEntity" /> class.
        /// </summary>
        /// <param name="budgetItemId">The budget item identifier.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <param name="budgetItemType">Type of the budget item.</param>
        /// <param name="budgetItemCode">The budget itemcode.</param>
        /// <param name="budgetItemName">The budget itemname.</param>
        /// <param name="budgetGroupItemCode">The budget group item code.</param>
        /// <param name="grade">The grade.</param>
        /// <param name="isParent">if set to <c>true</c> [is detail].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public BudgetItemEntity(string budgetItemId, string parentId, int budgetItemType,
            string budgetItemCode, string budgetItemName, string budgetGroupItemCode, int grade, bool isParent, bool isActive)
            : this()
        {
            BudgetItemId = budgetItemId;
            BudgetItemCode = budgetItemCode;
            BudgetItemName = budgetItemName;
            ParentId = parentId;
            Grade = grade;
            IsParent = isParent;
            IsActive = isActive;
            BudgetItemType = budgetItemType;
            BudgetGroupItemCode = budgetGroupItemCode;
        }

        /// <summary>
        /// Gets or sets the budget item identifier.
        /// </summary>
        /// <value>
        /// The budget item identifier.
        /// </value>
        public string BudgetItemId { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public string ParentId { get; set; }

        /// <summary>
        /// Gets or sets the type of the budget item.
        /// </summary>
        /// <value>
        /// The type of the budget item.
        /// </value>
        public int BudgetItemType { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>
        /// The budget item code.
        /// </value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget item.
        /// </summary>
        /// <value>
        /// The name of the budget item.
        /// </value>
        public string BudgetItemName { get; set; }

        /// <summary>
        /// Gets or sets the budget group item code.
        /// </summary>
        /// <value>
        /// The budget group item code.
        /// </value>
        public string BudgetGroupItemCode { get; set; }

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
