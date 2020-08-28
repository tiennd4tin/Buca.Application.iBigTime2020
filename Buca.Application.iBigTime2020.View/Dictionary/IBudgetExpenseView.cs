/***********************************************************************
 * <copyright file="IBudgetExpenseView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    /// Interface IBudgetExpenseView
    /// </summary>
    public interface IBudgetExpenseView : IView
    {
        /// <summary>
        /// Gets or sets the budget expense identifier.
        /// </summary>
        /// <value>The budget expense identifier.</value>
        string BudgetExpenseId { get; set; }

        /// <summary>
        /// Gets or sets the budget expense code.
        /// </summary>
        /// <value>The budget expense code.</value>
        string BudgetExpenseCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget expense.
        /// </summary>
        /// <value>The name of the budget expense.</value>
        string BudgetExpenseName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BudgetExpenseEntity"/> is inactive.
        /// </summary>
        /// <value><c>true</c> if inactive; otherwise, <c>false</c>.</value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value><c>true</c> if this instance is system; otherwise, <c>false</c>.</value>
        bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets the type of the budget expense.
        /// </summary>
        /// <value>The type of the budget expense.</value>
        int BudgetExpenseType { get; set; }
    }
}
