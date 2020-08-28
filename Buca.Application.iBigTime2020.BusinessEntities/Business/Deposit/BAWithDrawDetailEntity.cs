/***********************************************************************
 * <copyright file="BAWithDrawDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 23, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;

namespace Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit
{
    /// <summary>
    ///     BAWithDrawDetailEntity
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessEntities.BusinessEntities" />
    public class BAWithDrawDetailEntity : BusinessEntities
    {
        /// <summary>
        ///     Gets or sets the reference detail identifier.
        /// </summary>
        /// <value>
        ///     The reference detail identifier.
        /// </value>
        public string RefDetailId { get; set; }
        public string AutoBusinessId { get; set; }
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
        ///     Gets or sets the method distribute identifier.
        /// </summary>
        /// <value>
        ///     The method distribute identifier.
        /// </value>
        public int? MethodDistributeId { get; set; }

        /// <summary>
        ///     Gets or sets the cash with draw type identifier.
        /// </summary>
        /// <value>
        ///     The cash with draw type identifier.
        /// </value>
        public int? CashWithDrawTypeId { get; set; }

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
        ///     Gets or sets the project activity identifier.
        /// </summary>
        /// <value>
        ///     The project activity identifier.
        /// </value>
        public string ProjectActivityId { get; set; }

        /// <summary>
        ///     Gets or sets the fund identifier.
        /// </summary>
        /// <value>
        ///     The fund identifier.
        /// </value>
        public string FundId { get; set; }

        /// <summary>
        ///     Gets or sets the list item identifier.
        /// </summary>
        /// <value>
        ///     The list item identifier.
        /// </value>
        public string ListItemId { get; set; }

        /// <summary>
        ///     Gets or sets the sort order.
        /// </summary>
        /// <value>
        ///     The sort order.
        /// </value>
        public int? SortOrder { get; set; }

        /// <summary>
        ///     Gets or sets the budget detail item code.
        /// </summary>
        /// <value>
        ///     The budget detail item code.
        /// </value>
        public string BudgetDetailItemCode { get; set; }

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
        ///     Gets or sets the project activity ea identifier.
        /// </summary>
        /// <value>
        ///     The project activity ea identifier.
        /// </value>
        public string ProjectActivityEAId { get; set; }

        /// <summary>
        /// BudgetExpenseID
        /// </summary>
        public string BudgetExpenseId { get; set; }
        public string BankId { get; set; }
        public string ProjectCode { get; set; }
        public string ContractId { get; set; }
        public string CapitalPlanId { get; set; }
    }
}