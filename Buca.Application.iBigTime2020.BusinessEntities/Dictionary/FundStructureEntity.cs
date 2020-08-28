using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    public class FundStructureEntity : BusinessEntities
    {
        public FundStructureEntity()
        {
            AddRule(new ValidateRequired("FundStructureCode"));
            AddRule(new ValidateRequired("FundStructureName"));
        }
        public string FundStructureId { get; set; }

        public string FundStructureCode { get; set; }

        public string FundStructureName { get; set; }

        public string BUCACodeId { get; set; }

        public string ParentId { get; set; }

        public int Grade { get; set; }

        public bool IsParent { get; set; }

        public bool Inactive { get; set; }

        public bool IsSystem { get; set; }

        public int? InvestmentPeriod { get; set; }
        public string BudgetItemId { get; set; }
        public int CashWithdrawTypeId { get; set; }
        public bool IsProjectExpense { get; set; }
        public bool IsAllocateExpense { get; set; }
        public bool IsExpenseNoBuilding { get; set; }
    }
}
