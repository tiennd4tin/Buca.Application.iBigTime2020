/***********************************************************************
 * <copyright file="AccountBalanceEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 13 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;


namespace Buca.Application.iBigTime2020.BusinessEntities.Business
{
    /// <summary>
    /// AccountBalanceEntity
    /// </summary>
    public class AccountBalanceEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountBalanceEntity"/> class.
        /// </summary>
        public AccountBalanceEntity()
        {
            AddRule(new ValidateRequired("BalanceDate"));
            AddRule(new ValidateRequired("CurrencyCode"));
            AddRule(new ValidateRequired("AccountNumber"));
        }

        /// <summary>
        /// Gets or sets the account balance identifier.
        /// </summary>
        /// <value>
        /// The account balance identifier.
        /// </value>
        public string AccountBalanceId { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>
        /// The account number.
        /// </value>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>
        /// The currency identifier.
        /// </value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        /// The exchange rate.
        /// </value>
        public decimal? ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the balance date.
        /// </summary>
        /// <value>
        /// The balance date.
        /// </value>
        public DateTime BalanceDate { get; set; }

        /// <summary>
        /// Gets or sets the movement debit amount oc.
        /// </summary>
        /// <value>
        /// The movement debit amount oc.
        /// </value>
        public decimal MovementDebitAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the movement debit amount.
        /// </summary>
        /// <value>
        /// The movement debit amount.
        /// </value>
        public decimal MovementDebitAmount { get; set; }

        /// <summary>
        /// Gets or sets the movement credit amount oc.
        /// </summary>
        /// <value>
        /// The movement credit amount oc.
        /// </value>
        public decimal MovementCreditAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the movement credit amount.
        /// </summary>
        /// <value>
        /// The movement credit amount.
        /// </value>
        public decimal MovementCreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the budget source identifier.
        /// </summary>
        /// <value>
        /// The budget source identifier.
        /// </value>
        public string BudgetSourceId { get; set; }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        public string BudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets the budget kind item code.
        /// </summary>
        /// <value>
        /// The budget kind item code.
        /// </value>
        public string BudgetKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget sub kind item code.
        /// </summary>
        /// <value>
        /// The budget sub kind item code.
        /// </value>
        public string BudgetSubKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>
        /// The budget item code.
        /// </value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget sub item code.
        /// </summary>
        /// <value>
        /// The budget sub item code.
        /// </value>
        public string BudgetSubItemCode { get; set; }

        /// <summary>
        /// Gets or sets the method distribute identifier.
        /// </summary>
        /// <value>
        /// The method distribute identifier.
        /// </value>
        public int? MethodDistributeId { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>
        /// The accounting object identifier.
        /// </value>
        public string AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the activity identifier.
        /// </summary>
        /// <value>
        /// The activity identifier.
        /// </value>
        public string ActivityId { get; set; }

        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>
        /// The project identifier.
        /// </value>
        public string ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the project activity identifier.
        /// </summary>
        /// <value>
        /// The project activity identifier.
        /// </value>
        public string ProjectActivityId { get; set; }

        /// <summary>
        /// Gets or sets the project expense identifier.
        /// </summary>
        /// <value>
        /// The project expense identifier.
        /// </value>
        public string ProjectExpenseId { get; set; }

        /// <summary>
        /// Gets or sets the fund identifier.
        /// </summary>
        /// <value>
        /// The fund identifier.
        /// </value>
        public string FundId { get; set; }

        /// <summary>
        /// Gets or sets the task identifier.
        /// </summary>
        /// <value>
        /// The task identifier.
        /// </value>
        public string TaskId { get; set; }

        /// <summary>
        /// Gets or sets the budget detail item code.
        /// </summary>
        /// <value>
        /// The budget detail item code.
        /// </value>
        public string BudgetDetailItemCode { get; set; }

        /// <summary>
        /// Gets or sets the bank account.
        /// </summary>
        /// <value>
        /// The bank account.
        /// </value>
        public string BankAccount { get; set; }

        /// <summary>
        /// Gets or sets the fund structure identifier.
        /// </summary>
        /// <value>
        /// The fund structure identifier.
        /// </value>
        public string FundStructureId { get; set; }
    }
}
