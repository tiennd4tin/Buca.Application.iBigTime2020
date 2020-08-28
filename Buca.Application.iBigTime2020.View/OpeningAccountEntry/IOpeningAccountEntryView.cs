/***********************************************************************
 * <copyright file="IOpeningAccountEntryView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 28 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Opening;


namespace Buca.Application.iBigTime2020.View.OpeningAccountEntry
{
    /// <summary>
    /// interface IOpeningAccountEntryView
    /// </summary>
    public interface IOpeningAccountEntryView : IView
    {
         string RefID { get; set; }

         int RefType { get; set; }

         DateTime PostedDate { get; set; }

         string CurrencyId { get; set; }

         decimal ExchangeRate { get; set; }

         string AccountNumber { get; set; }

         string AccountName { get; set; }

         decimal AccBeginningDebitAmountOC { get; set; }

         decimal AccBeginningDebitAmount { get; set; }

         decimal AccBeginningCreditAmountOC { get; set; }

         decimal AccBeginningCreditAmount { get; set; }

         decimal DebitAmountOC { get; set; }

         decimal DebitAmount { get; set; }

         decimal CreditAmountOC { get; set; }

         decimal CreditAmount { get; set; }

         string BudgetSourceId { get; set; }

         string BudgetChapterCode { get; set; }

         string BudgetKindItemCode { get; set; }

         string BudgetSubKindItemCode { get; set; }

         string BudgetItemCode { get; set; }

         string BudgetSubItemCode { get; set; }

         int MethodDistributeId { get; set; }

         int CashWithdrawTypeId { get; set; }

         string AccountingObjectId { get; set; }

         string ActivityId { get; set; }

         string ProjectId { get; set; }

         string TaskId { get; set; }

         string BankId { get; set; }

         bool Approved { get; set; }

         int SortOrder { get; set; }

         string BudgetDetailItemCode { get; set; }

         string ProjectActivityId { get; set; }

         DateTime ApprovedDate { get; set; }

         string FundStructureId { get; set; }

         string ProjectActivityEAID { get; set; }

         string BudgetProvideCode { get; set; }
    }
}
