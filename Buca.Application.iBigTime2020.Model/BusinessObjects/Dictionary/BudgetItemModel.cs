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

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// Class BudgetItemModel.
    /// </summary>
    public class BudgetItemModel
    {
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
