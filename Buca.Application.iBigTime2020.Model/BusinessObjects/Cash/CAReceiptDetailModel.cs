﻿/***********************************************************************
 * <copyright file="CashDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using Buca.Application.iBigTime2020.Model.BusinessObjects.BaseModel;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Cash
{
    /// <summary>
    /// class CashDetailEntity
    /// </summary>
    public class CAReceiptDetailModel:BaseCheckErrorDetailByAccount
    {

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }
        public string RefDetailId { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string AutoBusinessId { get; set; }

        /// <summary>
        /// Gets or sets the reference detail identifier.
        /// </summary>
        /// <value>The reference detail identifier.</value>
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// 
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
        /// Gets or sets the amount oc.
        /// </summary>
        /// <value>The amount oc.</value>
        public decimal AmountOC { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the budget source identifier.
        /// </summary>
        /// <value>The budget source identifier.</value>
        public string BudgetSourceId { get; set; }
        public string CapitalPlanId { get; set; }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>The budget chapter code.</value>
        public string BudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets the budget sub kind item code.
        /// </summary>
        /// <value>The budget sub kind item code.</value>
        public string BudgetSubKindItemCode { get; set; }
        public string BudgetSubItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>The budget item code.</value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the fund structure identifier.
        /// </summary>
        /// <value>The fund structure identifier.</value>
        public string FundStructureId { get; set; }


        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>The project identifier.</value>
        public string ProjectId { get; set; }
        public string ContractId { get; set; }
        public string AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the cash withdraw type identifier.
        /// </summary>
        /// <value>The cash withdraw type identifier.</value>
        public int? CashWithdrawTypeId { get; set; }


        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>The bank identifier.</value>
        public string BankId { get; set; }
        
        /// <summary>
        /// Gets or sets the method distribute identifier.
        /// </summary>
        /// <value>The method distribute identifier.</value>
        /// <summary>
        /// Gets or sets the budget kind item code.
        /// </summary>
        /// <value>The budget kind item code.</value>
        public string BudgetKindItemCode { get; set; }


        /// <summary>
        /// Gets or sets the budget sub item code.
        /// </summary>
        /// <value>The budget sub item code.</value>

        public int? MethodDistributeId { get; set; }


        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>

        /// <summary>
        /// Gets or sets the activity identifier.
        /// </summary>
        /// <value>The activity identifier.</value>
        public string ActivityId { get; set; }


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
        /// Gets or sets the list item identifier.
        /// </summary>
        /// <value>The list item identifier.</value>
        public string ListItemId { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>The sort order.</value>
        public int? SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the budget detail item code.
        /// </summary>
        /// <value>The budget detail item code.</value>
        public string BudgetDetailItemCode { get; set; }

        /// <summary>
        /// Gets or sets the org reference no.
        /// </summary>
        /// <value>The org reference no.</value>
        public string OrgRefNo { get; set; }

        /// <summary>
        /// Gets or sets the org reference date.
        /// </summary>
        /// <value>The org reference date.</value>
        public DateTime? OrgRefDate { get; set; }


        /// <summary>
        /// Gets or sets the project activity ea identifier.
        /// </summary>
        /// <value>The project activity ea identifier.</value>
        public string ProjectActivityEAId { get; set; }

        /// <summary>
        /// Gets or sets the withdraw detail identifier.
        /// </summary>
        /// <value>The withdraw detail identifier.</value>
        public string WithdrawDetailId { get; set; }

        public string BudgetExpenseId { get; set; }

        public decimal TotalAmount { get { return AmountOC - Tax; } set { } }
        public decimal Tax { get; set; }
    }
}