using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure
{
    public class FundStructurePresenter : Presenter<IFundStructureView>
    {
        public FundStructurePresenter(IFundStructureView view)
            : base(view)
        {
        }

        public void Display(string fundStructureId)
        {
            if (fundStructureId == null) { View.FundStructureId = null; return; }

            var fundStructure = Model.GetFundStructure(fundStructureId);
            View.FundStructureId = fundStructure.FundStructureId;
            View.FundStructureCode = fundStructure.FundStructureCode;
            View.FundStructureName = fundStructure.FundStructureName;
            View.BUCACodeId = fundStructure.BUCACodeId;
            View.ParentId = fundStructure.ParentId;
            View.Grade = fundStructure.Grade;
            View.IsParent = fundStructure.IsParent;
            View.Inactive = fundStructure.Inactive;
            View.IsSystem = fundStructure.IsSystem;
            View.InvestmentPeriod = fundStructure.InvestmentPeriod; ;
            View.BudgetItemId = fundStructure.BudgetItemId;
            View.CashWithdrawTypeId = fundStructure.CashWithdrawTypeId;
            View.IsProjectExpense = fundStructure.IsProjectExpense;
            View.IsAllocateExpense = fundStructure.IsAllocateExpense;
            View.IsExpenseNoBuilding = fundStructure.IsExpenseNoBuilding;
        }

        public string Save()
        {
            var fundStructure = new FundStructureModel
            {
                FundStructureId = View.FundStructureId,
                FundStructureCode = View.FundStructureCode,
                FundStructureName = View.FundStructureName,
                BUCACodeId = View.BUCACodeId,
                ParentId = View.ParentId,
                Grade = View.Grade,
                IsParent = View.IsParent,
                Inactive = View.Inactive,
                IsSystem = View.IsSystem,
                InvestmentPeriod = View.InvestmentPeriod
                ,
                BudgetItemId = View.BudgetItemId
                ,
                CashWithdrawTypeId = 0
                ,
                IsProjectExpense = View.IsProjectExpense
                ,
                IsAllocateExpense = View.IsAllocateExpense
                ,
                IsExpenseNoBuilding = View.IsExpenseNoBuilding
            };

            return View.FundStructureId == null ? Model.AddFundStructure(fundStructure) : Model.UpdateFundStructure(fundStructure);
        }
        public string Delete(string fundStructureId)
        {
            return Model.DeleteFundStructure(fundStructureId);
        }
    }
}
