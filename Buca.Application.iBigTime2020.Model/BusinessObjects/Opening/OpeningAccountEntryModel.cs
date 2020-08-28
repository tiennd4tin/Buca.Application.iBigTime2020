/***********************************************************************
 * <copyright file="OpeningAccountEntryModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;


namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Opening
{
    /// <summary>
    /// OpeningAccountEntryModel
    /// </summary>
    public class OpeningAccountEntryModel
    {
        public string RefId { get; set; }

        public int RefType { get; set; }
        public string AccountingCateObjectCode { get; set; }
        public DateTime PostedDate { get; set; }
        public string AccountId { get; set; }
        public string ParentId { get; set; }

        public string CurrencyId { get; set; }

        public decimal ExchangeRate { get; set; }

        public string AccountNumber { get; set; }

        public string AccountName { get; set; }

        public decimal AccBeginningDebitAmountOC { get; set; }

        public decimal AccBeginningDebitAmount { get; set; }

        public decimal AccBeginningCreditAmountOC { get; set; }

        public decimal AccBeginningCreditAmount { get; set; }

        public decimal DebitAmountOC { get; set; }

        public decimal DebitAmount { get; set; }

        public decimal CreditAmountOC { get; set; }

        public decimal CreditAmount { get; set; }

        public string BudgetSourceId { get; set; }

        public string BudgetChapterCode { get; set; }

        public string BudgetKindItemCode { get; set; }

        public string BudgetSubKindItemCode { get; set; }

        public string BudgetItemCode { get; set; }

        public string BudgetSubItemCode { get; set; }

        public int MethodDistributeId { get; set; }

        public int CashWithdrawTypeId { get; set; }

        public string AccountingObjectId { get; set; }

        public string ActivityId { get; set; }

        public string ProjectId { get; set; }

        public string TaskId { get; set; }

        public string BankId { get; set; }

        public bool Approved { get; set; }

        public int SortOrder { get; set; }

        public string BudgetDetailItemCode { get; set; }

        public string ProjectActivityId { get; set; }

        public DateTime ApprovedDate { get; set; }

        public string FundStructureId { get; set; }

        public string ProjectActivityEAID { get; set; }

        public string BudgetProvideCode { get; set; }

        public string BudgetExpenseId { get; set; }

        public string CurrencyCode { get; set; }
        public string ContractId { get; set; }
        public string CapitalPlanId { get; set; }
    }
}