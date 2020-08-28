using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class BUPlanAdjustmentEntityDao : IEntityBUPlanAdjustmentDao
    {
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        private readonly ConvertCashWithdrawType ConvertCash = new ConvertCashWithdrawType();
        private List<BankInfo> banks;
        public List<BUPlanAdjustmentEntity> GetBUPlanAdjustments(string connectionString)
        {
            List<BUPlanAdjustmentEntity> buplanadjustments = new List<BUPlanAdjustmentEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var querry = context.BUPlanAdjustmentDetails.ToList();
                var projects = context.Projects.ToList();
                var currencys = context.CCies.ToList();
                var budgetsource = context.BudgetSources.ToList();
                var listitems = context.ListItems.ToList();
                var fundstructures = context.FundStructures.ToList();
                var budgetproviders = context.BudgetProvidences.ToList();
                var accountingobject = context.AccountingObjects.ToList();
                var projectexpenses = context.ProjectExpenses.ToList();
                banks = context.BankInfoes.ToList();
                var resultcontext = context.BUPlanAdjustments.ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new BUPlanAdjustmentEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.DecisionDate = result.DecisionDate;
                    newresult.DecisionNo = result.DecisionNo;
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.Posted = result.Posted;
                    newresult.TotalPreAdjustmentAmount = result.TotalPreAdjustmentAmount;
                    newresult.TotalAdjustmentAmount = result.TotalAdjustmentAmount;
                    newresult.TotalPostAdjustmentAmount = result.TotalPostAdjustmentAmount;
                    newresult.PostVersion = result.PostVersion ?? 0;
                    newresult.EditVersion = result.EditVersion ?? 0;
                    //newresult.ExchangeRate = result.e;
                    //newresult.TotalAmount = result.TotalAmount;
                    //newresult.CurrencyCode = result.cc;
                    newresult.BUPlanAdjustmentDetails = BUPlanAdjustmentDetails(result.BUPlanAdjustmentDetails.ToList(), newresult.RefId);
                    buplanadjustments.Add(newresult);
                }
            }

            return buplanadjustments;
        }

        public List<BUPlanAdjustmentDetailEntity> BUPlanAdjustmentDetails(List<BUPlanAdjustmentDetail> details, string refid)
        {
            List<BUPlanAdjustmentDetailEntity> lstBuPlanReceiptDetailEntities = new List<BUPlanAdjustmentDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new BUPlanAdjustmentDetailEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.ItemName = result.ItemName;
                newresult.BudgetSourceId = result.BudgetSource == null ? null : result.BudgetSource.BudgetSourceID.ToString();
                newresult.BudgetChapterCode = result.BudgetChapterCode;
                newresult.BudgetKindItemCode = result.BudgetKindItemCode;
                newresult.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                newresult.BudgetGroupItemCode = result.BudgetGroupItemCode;
                newresult.BudgetItemCode = result.BudgetItemCode;
                newresult.BudgetSubItemCode = result.BudgetSubItemCode;
                newresult.DebitAccount = result.DebitAccount;
                newresult.AdjustmentAmount = result.AdjustmentAmount;
                newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                //newresult.ActivityId = result.Project == null ? null : result.Project.CDCActivityType.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.SortOrder = result.SortOrder ?? 0;
                newresult.TaskId = result.TaskID.ToString();
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.BankAccount = result.BankAccount;
                newresult.ProjectExpenseEAID = result.ProjectExpense == null ? null : result.ProjectExpense.ProjectExpenseID.ToString();
                newresult.ProjectActivityEAID = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
                newresult.BudgetProvideCode = result.BudgetProvidence == null ? null : result.BudgetProvidence.BudgetProvideCode;

                lstBuPlanReceiptDetailEntities.Add(newresult);
            }
            return lstBuPlanReceiptDetailEntities;
        }
    }
}
