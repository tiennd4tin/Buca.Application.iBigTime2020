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
    public class C41BBModel
    {
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

        /// <summary>
        /// Gets or sets the inward reference no.
        /// </summary>
        /// <value>The inward reference no.</value>
        public string InwardRefNo { get; set; }

        /// <summary>
        /// Gets or sets the name of the accounting object.
        /// </summary>
        /// <value>The name of the accounting object.</value>
        public string AccountingObjectName { get; set; }

        /// <summary>
        /// Gets or sets the name of the contact.
        /// </summary>
        /// <value>The name of the contact.</value>
        public string ContactName { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
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
        public string DocumentIncluded { get; set; }

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
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>The exchange rate.</value>
        public decimal ExchangeRate { get; set; }
        public string ExChangeRateFormat { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>The currency code.</value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the debit account all.
        /// </summary>
        /// <value>The debit account all.</value>
        public string DebitAccountAll { get; set; }

        /// <summary>
        /// Gets or sets the credit account all.
        /// </summary>
        /// <value>The credit account all.</value>
        public string CreditAccountAll { get; set; }

        /// <summary>
        /// Gets or sets the sum amount oc.
        /// </summary>
        /// <value>The sum amount oc.</value>
        public decimal SumAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the sum amount.
        /// </summary>
        /// <value>The sum amount.</value>
        public decimal SumAmount { get; set; }

        /// <summary>
        /// Gets or sets the C41 bb detail models.
        /// </summary>
        /// <value>
        /// The C41 bb detail models.
        /// </value>
        public List<C41BBDetailModel> C41BBDetails { get; set; }

        public string Receiver { get; set; }
        public string Payer { get; set; }
    }
}
