/***********************************************************************
 * <copyright file="b01hmodel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUNGDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, December 11, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Finacial
{
    /// <summary>
    ///     B01HModel
    /// </summary>
    public class B01HModel
    {
        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>
        /// The name of the account.
        /// </value>
        public string AccountName { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is print month13.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is print month13; otherwise, <c>false</c>.
        /// </value>
        public bool IsPrintMonth13 { get; set; }

        /// <summary>
        ///     Gets or sets the account number.
        /// </summary>
        /// <value>
        ///     The account number.
        /// </value>
        public string AccountNumber { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is parent.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is parent; otherwise, <c>false</c>.
        /// </value>
        public bool IsParent { get; set; }

        /// <summary>
        ///     Gets or sets the grade.
        /// </summary>
        /// <value>
        ///     The grade.
        /// </value>
        public int Grade { get; set; }

        /// <summary>
        ///     Gets or sets the opening debit.
        /// </summary>
        /// <value>
        ///     The opening debit.
        /// </value>
        public decimal OpeningDebit { get; set; }

        /// <summary>
        ///     Gets or sets the opening credit.
        /// </summary>
        /// <value>
        ///     The opening credit.
        /// </value>
        public decimal OpeningCredit { get; set; }

        /// <summary>
        ///     Gets or sets the movement debit.
        /// </summary>
        /// <value>
        ///     The movement debit.
        /// </value>
        public decimal MovementDebit { get; set; }

        /// <summary>
        ///     Gets or sets the movement credit.
        /// </summary>
        /// <value>
        ///     The movement credit.
        /// </value>
        public decimal MovementCredit { get; set; }

        /// <summary>
        ///     Gets or sets the movement accum debit.
        /// </summary>
        /// <value>
        ///     The movement accum debit.
        /// </value>
        public decimal MovementAccumDebit { get; set; }

        /// <summary>
        ///     Gets or sets the movement accum credit.
        /// </summary>
        /// <value>
        ///     The movement accum credit.
        /// </value>
        public decimal MovementAccumCredit { get; set; }

        /// <summary>
        ///     Gets or sets the closing debit.
        /// </summary>
        /// <value>
        ///     The closing debit.
        /// </value>
        public decimal ClosingDebit { get; set; }

        /// <summary>
        ///     Gets or sets the closing credit.
        /// </summary>
        /// <value>
        ///     The closing credit.
        /// </value>
        public decimal ClosingCredit { get; set; }

        /// <summary>
        ///     Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        ///     The budget chapter code.
        /// </value>
        public string BudgetChapterCode { get; set; }

        /// <summary>
        ///     Gets or sets the budget source identifier.
        /// </summary>
        /// <value>
        ///     The budget source identifier.
        /// </value>
        public string BudgetSourceId { get; set; }

        /// <summary>
        ///     Gets or sets the budget source code.
        /// </summary>
        /// <value>
        ///     The budget source code.
        /// </value>
        public string BudgetSourceCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the budget source.
        /// </summary>
        /// <value>
        ///     The name of the budget source.
        /// </value>
        public string BudgetSourceName { get; set; }

        /// <summary>
        ///     Gets or sets the budget kind item code.
        /// </summary>
        /// <value>
        ///     The budget kind item code.
        /// </value>
        public string BudgetKindItemCode { get; set; }

        /// <summary>
        ///     Gets or sets the budget sub kind item code.
        /// </summary>
        /// <value>
        ///     The budget sub kind item code.
        /// </value>
        public string BudgetSubKindItemCode { get; set; }

        /// <summary>
        ///     Gets or sets the account category.
        /// </summary>
        /// <value>
        ///     The account category.
        /// </value>
        public int? AccountCategory { get; set; }

        /// <summary>
        ///     Gets or sets the kind of the account category.
        /// </summary>
        /// <value>
        ///     The kind of the account category.
        /// </value>
        public int? AccountCategoryKind { get; set; }

        /// <summary>
        ///     Gets or sets the sort order.
        /// </summary>
        /// <value>
        ///     The sort order.
        /// </value>
        public int? SortOrder { get; set; }

        /// <summary>
        ///     Gets or sets the account grade.
        /// </summary>
        /// <value>
        ///     The account grade.
        /// </value>
        public int? AccountGrade { get; set; }
    }
}