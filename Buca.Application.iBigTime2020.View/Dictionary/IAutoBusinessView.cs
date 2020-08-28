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
    ///     IAutoBusinessView
    /// </summary>
    public interface IAutoBusinessView : IView
    {
        /// <summary>
        ///     Gets or sets the automatic business identifier.
        /// </summary>
        /// <value>
        ///     The automatic business identifier.
        /// </value>
        string AutoBusinessId { get; set; }

        /// <summary>
        ///     Gets or sets the automatic business code.
        /// </summary>
        /// <value>
        ///     The automatic business code.
        /// </value>
        string AutoBusinessCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the automatic business.
        /// </summary>
        /// <value>
        ///     The name of the automatic business.
        /// </value>
        string AutoBusinessName { get; set; }

        /// <summary>
        ///     Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        ///     The reference type identifier.
        /// </value>
        int RefTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the debit account.
        /// </summary>
        /// <value>
        ///     The debit account.
        /// </value>
        string DebitAccount { get; set; }

        /// <summary>
        ///     Gets or sets the credit account.
        /// </summary>
        /// <value>
        ///     The credit account.
        /// </value>
        string CreditAccount { get; set; }

        /// <summary>
        ///     Gets or sets the budget source identifier.
        /// </summary>
        /// <value>
        ///     The budget source identifier.
        /// </value>
        string BudgetSourceId { get; set; }

        /// <summary>
        ///     Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        ///     The budget chapter code.
        /// </value>
        string BudgetChapterCode { get; set; }

        /// <summary>
        ///     Gets or sets the budget kind item code.
        /// </summary>
        /// <value>
        ///     The budget kind item code.
        /// </value>
        string BudgetKindItemCode { get; set; }

        /// <summary>
        ///     Gets or sets the budget sub kind item code.
        /// </summary>
        /// <value>
        ///     The budget sub kind item code.
        /// </value>
        string BudgetSubKindItemCode { get; set; }

        /// <summary>
        ///     Gets or sets the budget item code.
        /// </summary>
        /// <value>
        ///     The budget item code.
        /// </value>
        string BudgetItemCode { get; set; }

        /// <summary>
        ///     Gets or sets the budget sub item code.
        /// </summary>
        /// <value>
        ///     The budget sub item code.
        /// </value>
        string BudgetSubItemCode { get; set; }

        /// <summary>
        ///     Gets or sets the method distribute identifier.
        /// </summary>
        /// <value>
        ///     The method distribute identifier.
        /// </value>
        int? MethodDistributeId { get; set; }

        /// <summary>
        ///     Gets or sets the cash with draw type identifier.
        /// </summary>
        /// <value>
        ///     The cash with draw type identifier.
        /// </value>
        int? CashWithDrawTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
    }
}