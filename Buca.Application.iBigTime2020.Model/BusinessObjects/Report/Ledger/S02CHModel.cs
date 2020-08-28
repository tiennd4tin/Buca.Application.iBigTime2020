/***********************************************************************
 * <copyright file="S02CHModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, August 02, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Ledger
{
    /// <summary>
    /// S02CHModel
    /// </summary>
    public class S02CHModel
    {
        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        public string BudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>
        /// The budget source code.
        /// </value>
        public string BudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget source.
        /// </summary>
        /// <value>
        /// The name of the budget source.
        /// </value>
        public string BudgetSourceName { get; set; }

        /// <summary>
        /// Gets or sets the budget sub kind item code.
        /// </summary>
        /// <value>
        /// The budget sub kind item code.
        /// </value>
        public string BudgetSubKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public string RefID { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>
        /// The type of the reference.
        /// </value>
        public int RefType { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        public string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public DateTime RefDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the corresponding account number.
        /// </summary>
        /// <value>
        /// The corresponding account number.
        /// </value>
        public string CorrespondingAccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the debit amount.
        /// </summary>
        /// <value>
        /// The debit amount.
        /// </value>
        public decimal DebitAmount { get; set; }

        /// <summary>
        /// Gets or sets the credit amount.
        /// </summary>
        /// <value>
        /// The credit amount.
        /// </value>
        public decimal CreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>
        /// The account number.
        /// </value>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the opening amount.
        /// </summary>
        /// <value>
        /// The opening amount.
        /// </value>
        public decimal OpeningAmount { get; set; }

        /// <summary>
        /// Gets or sets the accum debit amount quater.
        /// </summary>
        /// <value>
        /// The accum debit amount quater.
        /// </value>
        public decimal AccumDebitAmountQuater { get; set; }

        /// <summary>
        /// Gets or sets the accum credit amount quater.
        /// </summary>
        /// <value>
        /// The accum credit amount quater.
        /// </value>
        public decimal AccumCreditAmountQuater { get; set; }

        /// <summary>
        /// Gets or sets the accum debit amount year.
        /// </summary>
        /// <value>
        /// The accum debit amount year.
        /// </value>
        public decimal AccumDebitAmountYear { get; set; }

        /// <summary>
        /// Gets or sets the accum credit amount year.
        /// </summary>
        /// <value>
        /// The accum credit amount year.
        /// </value>
        public decimal AccumCreditAmountYear { get; set; }

        /// <summary>
        /// Gets or sets the month.
        /// </summary>
        /// <value>
        /// The month.
        /// </value>
        public int Month { get; set; }

        /// <summary>
        /// Gets or sets the begin month.
        /// </summary>
        /// <value>
        /// The begin month.
        /// </value>
        public DateTime BeginMonth { get; set; }

        /// <summary>
        /// Gets or sets the begin quarter.
        /// </summary>
        /// <value>
        /// The begin quarter.
        /// </value>
        public DateTime BeginQuarter { get; set; }

        /// <summary>
        /// Gets or sets the kind of the account category.
        /// </summary>
        /// <value>
        /// The kind of the account category.
        /// </value>
        public int AccountCategoryKind { get; set; }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>
        /// The grade.
        /// </value>
        public int Grade { get; set; }

        /// <summary>
        /// Gets or sets the acc level.
        /// </summary>
        /// <value>
        /// The acc level.
        /// </value>
        public string AccLevel { get; set; }
    }
}
