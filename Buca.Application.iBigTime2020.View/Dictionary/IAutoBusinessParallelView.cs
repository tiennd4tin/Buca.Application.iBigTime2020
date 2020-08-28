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

namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    ///     IAutoBusinessParallelView
    /// </summary>
    public interface IAutoBusinessParallelView : IView
    {
        /// <summary>
        /// Gets or sets the automatic business paralell identifier.
        /// </summary>
        /// <value>The automatic business paralell identifier.</value>
        string AutoBusinessParallelId { get; set; }

        /// <summary>
        /// Gets or sets the automatic business code.
        /// </summary>
        /// <value>The automatic business code.</value>
        string AutoBusinessCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the automatic business.
        /// </summary>
        /// <value>The name of the automatic business.</value>
        string AutoBusinessName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the debit account.
        /// </summary>
        /// <value>The debit account.</value>
        string DebitAccount { get; set; }

        /// <summary>
        /// Gets or sets the credit account.
        /// </summary>
        /// <value>The credit account.</value>
        string CreditAccount { get; set; }

        /// <summary>
        /// Gets or sets the budget source identifier.
        /// </summary>
        /// <value>The budget source identifier.</value>
        string BudgetSourceId { get; set; }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>The budget chapter code.</value>
        string BudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets the budget kind item code.
        /// </summary>
        /// <value>The budget kind item code.</value>
        string BudgetKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget sub kind item code.
        /// </summary>
        /// <value>The budget sub kind item code.</value>
        string BudgetSubKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>The budget item code.</value>
        string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget sub item code.
        /// </summary>
        /// <value>The budget sub item code.</value>
        string BudgetSubItemCode { get; set; }

        /// <summary>
        /// Gets or sets the method distribute identifier.
        /// </summary>
        /// <value>The method distribute identifier.</value>
        int? MethodDistributeId { get; set; }

        /// <summary>
        /// Gets or sets the cash with draw type identifier.
        /// </summary>
        /// <value>The cash with draw type identifier.</value>
        int? CashWithDrawTypeId { get; set; }

        /// <summary>
        /// Gets or sets the debit account parallel.
        /// </summary>
        /// <value>The debit account parallel.</value>
        string DebitAccountParallel { get; set; }

        /// <summary>
        /// Gets or sets the credit account parallel.
        /// </summary>
        /// <value>The credit account parallel.</value>
        string CreditAccountParallel { get; set; }

        /// <summary>
        /// Gets or sets the budget source identifier parallel.
        /// </summary>
        /// <value>The budget source identifier parallel.</value>
        string BudgetSourceIdParallel { get; set; }

        /// <summary>
        /// Gets or sets the budget chapter code parallel.
        /// </summary>
        /// <value>The budget chapter code parallel.</value>
        string BudgetChapterCodeParallel { get; set; }

        /// <summary>
        /// Gets or sets the budget kind item code parallel.
        /// </summary>
        /// <value>The budget kind item code parallel.</value>
        string BudgetKindItemCodeParallel { get; set; }

        /// <summary>
        /// Gets or sets the budget sub kind item code parallel.
        /// </summary>
        /// <value>The budget sub kind item code parallel.</value>
        string BudgetSubKindItemCodeParallel { get; set; }

        /// <summary>
        /// Gets or sets the budget item code parallel.
        /// </summary>
        /// <value>The budget item code parallel.</value>
        string BudgetItemCodeParallel { get; set; }

        /// <summary>
        /// Gets or sets the budget sub item code parallel.
        /// </summary>
        /// <value>The budget sub item code parallel.</value>
        string BudgetSubItemCodeParallel { get; set; }

        /// <summary>
        /// Gets or sets the method distribute identifier parallel.
        /// </summary>
        /// <value>The method distribute identifier parallel.</value>
        int? MethodDistributeIdParallel { get; set; }

        /// <summary>
        /// Gets or sets the cash with draw type identifier parallel.
        /// </summary>
        /// <value>The cash with draw type identifier parallel.</value>
        int? CashWithDrawTypeIdParallel { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>The sort order.</value>
        int? SortOrder { get; set; }
    }
}