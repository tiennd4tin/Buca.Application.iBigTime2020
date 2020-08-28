/***********************************************************************
 * <copyright file="AutoBusinessParallelEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   thangnd
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 26 September 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// class AutoBusinessParallelEntity
    /// </summary>
    public class AutoBusinessParallelModel
    {
        /// <summary>
        /// Gets or sets the automatic business paralell identifier.
        /// </summary>
        /// <value>The automatic business paralell identifier.</value>
        public string AutoBusinessParallelId { get; set; }

        /// <summary>
        /// Gets or sets the automatic business code.
        /// </summary>
        /// <value>The automatic business code.</value>
        public string AutoBusinessCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the automatic business.
        /// </summary>
        /// <value>The name of the automatic business.</value>
        public string AutoBusinessName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the debit account.
        /// </summary>
        /// <value>The debit account.</value>
        public string DebitAccount { get; set; }

        /// <summary>
        /// Gets or sets the credit account.
        /// </summary>
        /// <value>The credit account.</value>
        public string CreditAccount { get; set; }

        /// <summary>
        /// Gets or sets the budget source identifier.
        /// </summary>
        /// <value>The budget source identifier.</value>
        public string BudgetSourceId { get; set; }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>The budget chapter code.</value>
        public string BudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets the budget kind item code.
        /// </summary>
        /// <value>The budget kind item code.</value>
        public string BudgetKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget sub kind item code.
        /// </summary>
        /// <value>The budget sub kind item code.</value>
        public string BudgetSubKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>The budget item code.</value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget sub item code.
        /// </summary>
        /// <value>The budget sub item code.</value>
        public string BudgetSubItemCode { get; set; }

        /// <summary>
        /// Gets or sets the method distribute identifier.
        /// </summary>
        /// <value>The method distribute identifier.</value>
        public int? MethodDistributeId { get; set; }

        /// <summary>
        /// Gets or sets the cash with draw type identifier.
        /// </summary>
        /// <value>The cash with draw type identifier.</value>
        public int? CashWithDrawTypeId { get; set; }

        /// <summary>
        /// Gets or sets the debit account parallel.
        /// </summary>
        /// <value>The debit account parallel.</value>
        public string DebitAccountParallel { get; set; }

        /// <summary>
        /// Gets or sets the credit account parallel.
        /// </summary>
        /// <value>The credit account parallel.</value>
        public string CreditAccountParallel { get; set; }

        /// <summary>
        /// Gets or sets the budget source identifier parallel.
        /// </summary>
        /// <value>The budget source identifier parallel.</value>
        public string BudgetSourceIdParallel { get; set; }

        /// <summary>
        /// Gets or sets the budget chapter code parallel.
        /// </summary>
        /// <value>The budget chapter code parallel.</value>
        public string BudgetChapterCodeParallel { get; set; }

        /// <summary>
        /// Gets or sets the budget kind item code parallel.
        /// </summary>
        /// <value>The budget kind item code parallel.</value>
        public string BudgetKindItemCodeParallel { get; set; }

        /// <summary>
        /// Gets or sets the budget sub kind item code parallel.
        /// </summary>
        /// <value>The budget sub kind item code parallel.</value>
        public string BudgetSubKindItemCodeParallel { get; set; }

        /// <summary>
        /// Gets or sets the budget item code parallel.
        /// </summary>
        /// <value>The budget item code parallel.</value>
        public string BudgetItemCodeParallel { get; set; }

        /// <summary>
        /// Gets or sets the budget sub item code parallel.
        /// </summary>
        /// <value>The budget sub item code parallel.</value>
        public string BudgetSubItemCodeParallel { get; set; }

        /// <summary>
        /// Gets or sets the method distribute identifier parallel.
        /// </summary>
        /// <value>The method distribute identifier parallel.</value>
        public int? MethodDistributeIdParallel { get; set; }

        /// <summary>
        /// Gets or sets the cash with draw type identifier parallel.
        /// </summary>
        /// <value>The cash with draw type identifier parallel.</value>
        public int? CashWithDrawTypeIdParallel { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>The sort order.</value>
        public int? SortOrder { get; set; }
    }
}
