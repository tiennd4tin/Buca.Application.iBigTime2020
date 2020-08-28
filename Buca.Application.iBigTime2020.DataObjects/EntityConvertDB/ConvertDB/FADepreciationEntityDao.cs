using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.FixedAsset;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class FADepreciationEntityDao: IEntityFADepreciationDao
    {
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        private readonly ConvertCashWithdrawType ConvertCash = new ConvertCashWithdrawType();
        public List<FADepreciationEntity> GetFADepreciations(string connectionString)
        {
            List<FADepreciationEntity> buentity = new List<FADepreciationEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var querry = context.FADepreciationDetails.ToList();
                var projects = context.Projects.ToList();
                //var currencys = context.CCies.ToList();
                var budgetsource = context.BudgetSources.ToList();
                var listitems = context.ListItems.ToList();
                //var funds = context.Funds.ToList();
                var fundstructures = context.FundStructures.ToList();
                var budgetproviders = context.BudgetProvidences.ToList();
                var accountingobject = context.AccountingObjects.ToList();
                var projectexpenses = context.ProjectExpenses.ToList();
                var activity = context.Activities.ToList();
                var tasks = context.Tasks.ToList();
                var topics = context.Topics.ToList();
                //banks = context.BankInfoes.ToList();
                //var department = context.Departments.ToList();
                //var fixedasset = context.FixedAssets.ToList();
                //var inventoryitems = context.InventoryItems.ToList();
                //var stocks = context.Stocks.ToList();
                var resultcontext = context.FADepreciations.ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new FADepreciationEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.PeriodType = result.PeriodType??0;
                    newresult.PeriodTypeName = result.PeriodTypeName;
                    newresult.FADepreciationDetails = result.FADepreciationDetails.Count <= 0 ? null : FADepreciationDetails(result.FADepreciationDetails.ToList(), result.RefID.ToString());
                    buentity.Add(newresult);
                }
            }
            return buentity;
        }

        public List<FADepreciationDetailEntity> FADepreciationDetails(List<FADepreciationDetail> details, string refid)
        {
            List<FADepreciationDetailEntity> lstDetailEntities = new List<FADepreciationDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new FADepreciationDetailEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.FixedAssetId = result.FixedAssetID.ToString();
                newresult.FixedAssetName = result.FixedAssetName;
                newresult.OrgPrice = result.OrgPrice;
                newresult.AnnualDepreciationRate = result.AnnualDepreciationRate??0;
                newresult.AnnualDepreciationAmount = result.AnnualDepreciationAmount??0;
                newresult.Description = result.Description;
                newresult.DebitAccount = result.DebitAccount;
                newresult.CreditAccount = result.CreditAccount;
                newresult.Amount = result.Amount;
                newresult.BudgetSourceId = result.BudgetSource == null ? null : result.BudgetSource.BudgetSourceID.ToString();
                newresult.BudgetChapterCode = result.BudgetChapterCode;
                newresult.BudgetKindItemCode = result.BudgetKindItemCode;
                newresult.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                newresult.BudgetItemCode = result.BudgetItemCode;
                newresult.BudgetSubItemCode = result.BudgetSubItemCode;
                newresult.MethodDistributeId = result.MethodDistributeID;
                newresult.CashWithDrawTypeId = ConvertCash.ConvertCash(result.CashWithDrawTypeID);
                newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                newresult.ActivityId = result.Activity == null ? null : result.Activity.ActivityID.ToString();
                newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                newresult.ProjectActivityId = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
                newresult.ProjectExpenseId = result.ProjectExpense == null ? null : result.ProjectExpense.ProjectExpenseID.ToString();
                newresult.TaskId = result.Task == null ? null : result.Task.TaskID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.ProjectExpenseEAId = result.ProjectExpense1 == null ? null : result.ProjectExpense1.ProjectExpenseID.ToString();
                newresult.ProjectActivityEAId = result.Project2 == null ? null : result.Project2.ProjectID.ToString();
                newresult.BudgetProvideCode = result.BudgetProvidence == null ? null : result.BudgetProvidence.BudgetProvideCode;
                newresult.TopicId = result.Topic == null ? null : result.Topic.TopicID.ToString();
                //newresult.BudgetExpenseId = result.BudgetExpense;
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
    }
}
