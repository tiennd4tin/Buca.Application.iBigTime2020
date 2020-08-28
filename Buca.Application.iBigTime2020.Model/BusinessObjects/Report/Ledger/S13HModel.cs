/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: November 26, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    20/11/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using System;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Ledger
{
    /// <summary>
    /// S13HModel
    /// </summary>
   public class S13HModel
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public string RefId { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>
        /// The type of the reference.
        /// </value>
        public int RefType { get; set; }

        /// <summary>
        /// Gets or sets the reference type category.
        /// </summary>
        /// <value>
        /// The reference type category.
        /// </value>
        public int RefTypeCategory { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        public string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        public DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public DateTime RefDate { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>
        /// The journal memo.
        /// </value>
        public string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the v description.
        /// </summary>
        /// <value>
        /// The v description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>
        /// The account number.
        /// </value>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>
        /// The name of the account.
        /// </value>
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the corresponding account number.
        /// </summary>
        /// <value>
        /// The corresponding account number.
        /// </value>
        public string CorrespondingAccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the debit amount oc.
        /// </summary>
        /// <value>
        /// The debit amount oc.
        /// </value>
        public decimal DebitAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the debit amount.
        /// </summary>
        /// <value>
        /// The debit amount.
        /// </value>
        public decimal DebitAmount { get; set; }

        /// <summary>
        /// Gets or sets the credit amount oc.
        /// </summary>
        /// <value>
        /// The credit amount oc.
        /// </value>
        public decimal CreditAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the credit amount.
        /// </summary>
        /// <value>
        /// The credit amount.
        /// </value>
        public decimal CreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the closing debit amount oc.
        /// </summary>
        /// <value>
        /// The closing debit amount oc.
        /// </value>
        public decimal ClosingDebitAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the closing debit amount.
        /// </summary>
        /// <value>
        /// The closing debit amount.
        /// </value>
        public decimal ClosingDebitAmount { get; set; }

        /// <summary>
        /// Gets or sets the closing credit amount oc.
        /// </summary>
        /// <value>
        /// The closing credit amount oc.
        /// </value>
        public decimal ClosingCreditAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the closing credit amount.
        /// </summary>
        /// <value>
        /// The closing credit amount.
        /// </value>
        public decimal ClosingCreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the type of the order.
        /// </summary>
        /// <value>
        /// The type of the order.
        /// </value>
        public int OrderType { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public string SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>
        /// The currency identifier.
        /// </value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the currency.
        /// </summary>
        /// <value>
        /// The name of the currency.
        /// </value>
        public string CurrencyName { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        /// The exchange rate.
        /// </value>
        public decimal ExchangeRate { get; set; }
        public DateTime StartOfMonth { get; set; }
        public decimal Cot1 { get; set; }
        public decimal Cot2 { get; set; }
        public decimal Cot1OC { get; set; }
        public decimal Cot2OC { get; set; }
        public decimal Cot3 { get; set; }
        public decimal Cot3OC { get; set; }
        public string BankAccount { get; set; }
    }
}
