using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.View.Dictionary
{
     public interface IFundStructureView : IView
    {
         string FundStructureId { get; set; }

         string FundStructureCode { get; set; }

         string FundStructureName { get; set; }

         string BUCACodeId { get; set; }

         string ParentId { get; set; }

         int Grade { get; set; }

         bool IsParent { get; set; }

         bool Inactive { get; set; }

         bool IsSystem { get; set; }

         int? InvestmentPeriod { get; set; }

       string BudgetItemId { get; set; }
       int CashWithdrawTypeId { get; set; }
       bool IsProjectExpense { get; set; }
       bool IsAllocateExpense { get; set; }
       bool IsExpenseNoBuilding { get; set; }
    }
}
