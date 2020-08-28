/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 27, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.BaseModel;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.IncrementDecrement
{
    /// <summary>
    /// SUTransferModel
    /// </summary>
    public class FAAdjustmentDetailModel:BaseCheckErrorDetailByAccount
    {
        public string RefDetailId { get; set; }

        public string RefId { get; set; }

        public string Description { get; set; }

        public string DebitAccount { get; set; }

        public string CreditAccount { get; set; }

        public decimal Amount { get; set; }

        public string BudgetSourceId { get; set; }

        public string BudgetChapterCode { get; set; }

        public string BudgetKindItemCode { get; set; }

        public string BudgetSubKindItemCode { get; set; }

        public string BudgetItemCode { get; set; }

        public string BudgetSubItemCode { get; set; }

        public int MethodDistributeId { get; set; }

        public int CashWithDrawTypeId { get; set; }

        public string AccountingObjectId { get; set; }        

        public string ProjectId { get; set; }

        public string ProjectActivityId { get; set; }

        public string ProjectExpenseId { get; set; }

        public string TaskId { get; set; }

        public string ListItemId { get; set; }

        public int SortOrder { get; set; }

        public string BudgetDetailItemCode { get; set; }

        public string FundStructureId { get; set; }

        public string BankId { get; set; }

        public string ProjectExpenseEAId { get; set; }

        public string ProjectActivityEAId { get; set; }

        public string BudgetProvideCode { get; set; }

        public string TopicId { get; set; }

        public string BudgetExpenseId { get; set; }
        public string ContractId { get; set; }
        public string CapitalPlanId { get; set; }

        public string ActivityId { get; set; }

    }
}
