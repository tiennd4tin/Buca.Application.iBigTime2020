﻿/***********************************************************************
 * <copyright file="BUVoucherListDetailParallelModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUNGDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Tuesday, June 5, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate
{
    /// <summary>
    ///     BUVoucherListDetailParallelModel
    /// </summary>
    public class BUVoucherListDetailParallelModel
    {
        /// <summary>
        ///     Gets or sets the reference detail identifier.
        /// </summary>
        /// <value>
        ///     The reference detail identifier.
        /// </value>
        public string RefDetailId { get; set; }

        /// <summary>
        ///     Gets or sets the parent reference detail identifier.
        /// </summary>
        /// <value>
        ///     The parent reference detail identifier.
        /// </value>
        public string ParentRefDetailId { get; set; }

        /// <summary>
        ///     Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        ///     The reference identifier.
        /// </value>
        public string RefId { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the debit account.
        /// </summary>
        /// <value>
        ///     The debit account.
        /// </value>
        public string DebitAccount { get; set; }

        /// <summary>
        ///     Gets or sets the credit account.
        /// </summary>
        /// <value>
        ///     The credit account.
        /// </value>
        public string CreditAccount { get; set; }

        /// <summary>
        ///     Gets or sets the amount.
        /// </summary>
        /// <value>
        ///     The amount.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        ///     Gets or sets the amount oc.
        /// </summary>
        /// <value>
        ///     The amount oc.
        /// </value>
        public decimal AmountOC { get; set; }

        /// <summary>
        ///     Gets or sets the budget source identifier.
        /// </summary>
        /// <value>
        ///     The budget source identifier.
        /// </value>
        public string BudgetSourceId { get; set; }

        /// <summary>
        ///     Gets or sets the budget provide code.
        /// </summary>
        /// <value>
        ///     The budget provide code.
        /// </value>
        public string BudgetProvideCode { get; set; }

        /// <summary>
        ///     Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        ///     The budget chapter code.
        /// </value>
        public string BudgetChapterCode { get; set; }

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
        ///     Gets or sets the budget item code.
        /// </summary>
        /// <value>
        ///     The budget item code.
        /// </value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        ///     Gets or sets the budget sub item code.
        /// </summary>
        /// <value>
        ///     The budget sub item code.
        /// </value>
        public string BudgetSubItemCode { get; set; }

        /// <summary>
        ///     Gets or sets the budget detail item code.
        /// </summary>
        /// <value>
        ///     The budget detail item code.
        /// </value>
        public string BudgetDetailItemCode { get; set; }

        /// <summary>
        ///     Gets or sets the method distribute identifier.
        /// </summary>
        /// <value>
        ///     The method distribute identifier.
        /// </value>
        public int? MethodDistributeId { get; set; }

        /// <summary>
        ///     Gets or sets the cash withdraw type identifier.
        /// </summary>
        /// <value>
        ///     The cash withdraw type identifier.
        /// </value>
        public int? CashWithdrawTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>
        ///     The accounting object identifier.
        /// </value>
        public string AccountingObjectId { get; set; }

        /// <summary>
        ///     Gets or sets the activity identifier.
        /// </summary>
        /// <value>
        ///     The activity identifier.
        /// </value>
        public string ActivityId { get; set; }

        /// <summary>
        ///     Gets or sets the project identifier.
        /// </summary>
        /// <value>
        ///     The project identifier.
        /// </value>
        public string ProjectId { get; set; }

        /// <summary>
        ///     Gets or sets the list item identifier.
        /// </summary>
        /// <value>
        ///     The list item identifier.
        /// </value>
        public string ListItemId { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="BUVoucherListDetailParallelEntity" /> is approved.
        /// </summary>
        /// <value>
        ///     <c>true</c> if approved; otherwise, <c>false</c>.
        /// </value>
        public bool Approved { get; set; }

        /// <summary>
        ///     Gets or sets the sort order.
        /// </summary>
        /// <value>
        ///     The sort order.
        /// </value>
        public int? SortOrder { get; set; }

        /// <summary>
        ///     Gets or sets the org reference no.
        /// </summary>
        /// <value>
        ///     The org reference no.
        /// </value>
        public string OrgRefNo { get; set; }

        /// <summary>
        ///     Gets or sets the org reference date.
        /// </summary>
        /// <value>
        ///     The org reference date.
        /// </value>
        public DateTime? OrgRefDate { get; set; }

        /// <summary>
        ///     Gets or sets the fund structure identifier.
        /// </summary>
        /// <value>
        ///     The fund structure identifier.
        /// </value>
        public string FundStructureId { get; set; }

        /// <summary>
        ///     Gets or sets the bank account.
        /// </summary>
        /// <value>
        ///     The bank account.
        /// </value>
        public string BankAccount { get; set; }

        /// <summary>
        ///     Gets or sets the budget expense identifier.
        /// </summary>
        /// <value>
        ///     The budget expense identifier.
        /// </value>
        public string BudgetExpenseId { get; set; }
    }
}