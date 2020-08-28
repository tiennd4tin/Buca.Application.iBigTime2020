using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.Model.BusinessObjects.BaseModel;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate
{
    public class BUPlanAdjustmentDetailModel :BaseCheckErrorDetailByAccount
    {
        public string RefDetailId { get; set; }

        public string RefId { get; set; }

        public string ItemName { get; set; }

        public string BudgetSourceId { get; set; }
        public string MethodDistributeId { get; set; }

        public string BudgetChapterCode { get; set; }

        public string BudgetKindItemCode { get; set; }

        public string BudgetSubKindItemCode { get; set; }

        public string BudgetGroupItemCode { get; set; }

        public string BudgetItemCode { get; set; }

        public string BudgetSubItemCode { get; set; }

        public string DebitAccount { get; set; }

        public decimal AdjustmentAmount { get; set; }
        public decimal Amount { get; set; }

        public string ProjectId { get; set; }

        public string ListItemId { get; set; }

        public int SortOrder { get; set; }

        public string TaskId { get; set; }

        public string BudgetDetailItemCode { get; set; }

        public string FundStructureId { get; set; }

        public string BankAccount { get; set; }

        public string ProjectExpenseEAID { get; set; }

        public string ProjectActivityEAID { get; set; }

        public string BudgetProvideCode { get; set; }
        public string ContractId { get; set; }
        public string CapitalPlanId { get; set; }

        public string ActivityId { get; set; }
    }
}
