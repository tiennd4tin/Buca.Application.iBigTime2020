/***********************************************************************
 * <copyright file="BudgetGroupItemModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Wednesday, October 10, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// BudgetGroupItemModel
    /// </summary>
    public class BudgetGroupItemModel
    {
        /// <summary>
        /// Gets or sets the budget group item identifier.
        /// </summary>
        /// <value>
        /// The budget group item identifier.
        /// </value>
        public string BudgetGroupItemId { get; set; }

        /// <summary>
        /// Gets or sets the budget group item code.
        /// </summary>
        /// <value>
        /// The budget group item code.
        /// </value>
        public string BudgetGroupItemCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget group item.
        /// </summary>
        /// <value>
        /// The name of the budget group item.
        /// </value>
        public string BudgetGroupItemName { get; set; }

        /// <summary>
        /// Gets or sets the rep budget item code.
        /// </summary>
        /// <value>
        /// The rep budget item code.
        /// </value>
        public string RepBudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
