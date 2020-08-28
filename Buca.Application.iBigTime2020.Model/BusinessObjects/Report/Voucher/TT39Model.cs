// ***********************************************************************
// Assembly         : Buca.Application.iBigTime2020.Model
// Author           : thangnd
// Created          : 11-08-2017
//
// Last Modified By : thangnd
// Last Modified On : 11-08-2017
// ***********************************************************************
// <copyright file="C31BBModel.cs" company="by adguard">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher
{
    /// <summary>
    /// Class C31BBModel.
    /// </summary>
    public class TT39Model
    {
        /// <summary>
        /// Gets or sets the org reference no.
        /// </summary>
        /// <value>
        /// The org reference no.
        /// </value>
        public string OrgRefNo { get; set; }

        /// <summary>
        /// Gets or sets the org reference date.
        /// </summary>
        /// <value>
        /// The org reference date.
        /// </value>
        public DateTime? OrgRefDate { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        public int RefType { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>The reference date.</value>
        public DateTime RefDate { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        public DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        public string RefNo { get; set; }

 
        /// <value>The address.</value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
        public string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the document included.
        /// </summary>
        /// <value>The document included.</value>
 

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>The total amount.</value>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

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
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>The total amount oc.</value>
        public decimal Amount { get; set; }

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
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>The sort order.</value>
        public int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the amount oc.
        /// </summary>
        /// <value>The amount oc.</value>
        public decimal AmountOC { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>The total amount.</value>
        public decimal TotalAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode { get; set; }
        public string ProjectCode { get; set; }

        /// <summary>
        /// Gets or sets the budget sub kind item code.
        /// </summary>
        /// <value>
        /// The budget sub kind item code.
        /// </value>
        public string BudgetSubKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets the sum amount.
        /// </summary>
        /// <value>The sum amount.</value>
        public string BudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the C41 bb detail models.
        /// </summary>
        /// <value>
        /// The C41 bb detail models.
        /// </value>
        /// 
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget sub item code.
        /// </summary>
        /// <value>The budget sub item code.</value>
        public string BudgetSubItemCode { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets the quota.
        /// </summary>
        /// <value>
        /// The quota.
        /// </value>
        public decimal Quota { get; set; }
        public decimal ActualUnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the cash with draw type identifier.
        /// </summary>
        /// <value>
        /// The cash with draw type identifier.
        /// </value>
        public int? CashWithDrawTypeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is real expend.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is real expend; otherwise, <c>false</c>.
        /// </value>
        public bool IsRealExpend { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is advance.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is advance; otherwise, <c>false</c>.
        /// </value>
        public bool IsAdvance { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is planned.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is planned; otherwise, <c>false</c>.
        /// </value>
        public bool IsPlanned { get; set; }


    }
}
