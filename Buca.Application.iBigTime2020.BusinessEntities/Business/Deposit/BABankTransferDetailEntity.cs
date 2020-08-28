using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit
{
    public class BABankTransferDetailEntity : BusinessEntities
    {
        public string RefDetailId { get; set; }

        public string RefId { get; set; }

        public string Description { get; set; }

        public string DebitAccount { get; set; }

        public string CreditAccount { get; set; }

        public string FromBankId { get; set; }

        public string ToBankId { get; set; }

        public decimal Amount { get; set; }

        public string BudgetSourceId { get; set; }

        public string BudgetChapterCode { get; set; }

        public string BudgetKindItemCode { get; set; }

        public string BudgetSubKindItemCode { get; set; }

        public string BudgetItemCode { get; set; }

        public string BudgetSubItemCode { get; set; }

        public int? MethodDistributeId { get; set; }

        public int? CashWithDrawTypeId { get; set; }

        public string AccountingObjectId { get; set; }

        public string ActivityId { get; set; }

        public string ProjectId { get; set; }

        public string ProjectActivityId { get; set; }

        public string ListItemId { get; set; }

        public int? SortOrder { get; set; }

        public string BudgetDetailItemCode { get; set; }

        public decimal AmountOC { get; set; }

        public string FundStructureId { get; set; }

        public string ProjectActivityEAId { get; set; }

        public string BudgetExpenseId { get; set; }
    }
}
