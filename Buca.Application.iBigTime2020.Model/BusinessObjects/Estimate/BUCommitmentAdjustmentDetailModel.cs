﻿/***********************************************************************
 * <copyright file="BUCommitmentAdjustmentDetailModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Monday, December 11, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateMonday, December 11, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate
{
    /// <summary>
    /// Class BUCommitmentAdjustmentDetailModel.
    /// </summary>
    public class BUCommitmentAdjustmentDetailModel
    {
        /// <summary>
        /// Gets or sets the reference detail identifier.
        /// </summary>
        /// <value>The reference detail identifier.</value>
        public string RefDetailId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>The currency identifier.</value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>The exchange rate.</value>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the amount oc.
        /// </summary>
        /// <value>The amount oc.</value>
        public decimal AmountOC { get; set; }

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
        /// Gets or sets the budget detail item code.
        /// </summary>
        /// <value>The budget detail item code.</value>
        public string BudgetDetailItemCode { get; set; }

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
        /// Gets or sets the activity identifier.
        /// </summary>
        /// <value>The activity identifier.</value>
        public string ActivityId { get; set; }

        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>The project identifier.</value>
        public string ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the project activity identifier.
        /// </summary>
        /// <value>The project activity identifier.</value>
        public string ProjectActivityId { get; set; }

        /// <summary>
        /// Gets or sets the project expense identifier.
        /// </summary>
        /// <value>The project expense identifier.</value>
        public string ProjectExpenseId { get; set; }

        /// <summary>
        /// Gets or sets the task identifier.
        /// </summary>
        /// <value>The task identifier.</value>
        public string TaskId { get; set; }

        /// <summary>
        /// Gets or sets the list item identifier.
        /// </summary>
        /// <value>The list item identifier.</value>
        public string ListItemId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BUCommitmentAdjustmentDetailModel"/> is approved.
        /// </summary>
        /// <value><c>true</c> if approved; otherwise, <c>false</c>.</value>
        public bool Approved { get; set; }

        /// <summary>
        /// Gets or sets the fund structure identifier.
        /// </summary>
        /// <value>The fund structure identifier.</value>
        public string FundStructureId { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>The sort order.</value>
        public int? SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the bank account.
        /// </summary>
        /// <value>The bank account.</value>
        public string BankAccount { get; set; }

        /// <summary>
        /// Gets or sets the budget provide code.
        /// </summary>
        /// <value>The budget provide code.</value>
        public string BudgetProvideCode { get; set; }

        /// <summary>
        /// Gets or sets to currency identifier.
        /// </summary>
        /// <value>To currency identifier.</value>
        public string ToCurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets to exchange rate.
        /// </summary>
        /// <value>To exchange rate.</value>
        public decimal ToExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets to amount oc.
        /// </summary>
        /// <value>To amount oc.</value>
        public decimal ToAmountOC { get; set; }

        /// <summary>
        /// Gets or sets to amount.
        /// </summary>
        /// <value>To amount.</value>
        public decimal ToAmount { get; set; }

        /// <summary>
        /// Gets or sets to budget source identifier.
        /// </summary>
        /// <value>To budget source identifier.</value>
        public string ToBudgetSourceId { get; set; }

        /// <summary>
        /// Gets or sets to budget provide code.
        /// </summary>
        /// <value>To budget provide code.</value>
        public string ToBudgetProvideCode { get; set; }

        /// <summary>
        /// Gets or sets to budget chapter code.
        /// </summary>
        /// <value>To budget chapter code.</value>
        public string ToBudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets to budget kind item code.
        /// </summary>
        /// <value>To budget kind item code.</value>
        public string ToBudgetKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets to budget sub kind item code.
        /// </summary>
        /// <value>To budget sub kind item code.</value>
        public string ToBudgetSubKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets to budget item code.
        /// </summary>
        /// <value>To budget item code.</value>
        public string ToBudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets to budget sub item code.
        /// </summary>
        /// <value>To budget sub item code.</value>
        public string ToBudgetSubItemCode { get; set; }

        /// <summary>
        /// Gets or sets to project identifier.
        /// </summary>
        /// <value>To project identifier.</value>
        public string ToProjectId { get; set; }

        /// <summary>
        /// Gets or sets the remain amount oc.
        /// </summary>
        /// <value>The remain amount oc.</value>
        public decimal RemainAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the remain amount.
        /// </summary>
        /// <value>The remain amount.</value>
        public decimal RemainAmount { get; set; }

        /// <summary>
        /// Gets or sets the remain exchange rate.
        /// </summary>
        /// <value>The remain exchange rate.</value>
        public decimal RemainExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the remain currency identifier.
        /// </summary>
        /// <value>The remain currency identifier.</value>
        public string RemainCurrencyCode { get; set; }

        public string BUCommitmentRequestDetailId { get; set; }

        public string ContractId { get; set; }
        public string CapitalPlanId { get; set; }
    }
}
