using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.IncrementDecrement;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class FAAdjustmentEntityDao : IEntityFAAdjustmentDao
    {
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        private readonly ConvertCashWithdrawType ConvertCash = new ConvertCashWithdrawType();
        private List<BankInfo> banks;
        public List<FAAdjustmentEntity> GetFAAdjustments(string connectionString)
        {
            List<FAAdjustmentEntity> buentity = new List<FAAdjustmentEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var querry = context.FAAdjustmentDetails.ToList();
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
                //var tasks = context.Tasks.ToList();
                var topics = context.Topics.ToList();
                banks = context.BankInfoes.ToList();
                //var department = context.Departments.ToList();
                var fixedasset = context.FixedAssets.ToList();
                //var inventoryitems = context.InventoryItems.ToList();
                //var stocks = context.Stocks.ToList();
                var resultcontext = context.FAAdjustments.ToList();
                var detailfixedasset = context.FAAdjustmentDetailFAs.ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new FAAdjustmentEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.FixedAssetId = result.FixedAsset == null ? null : result.FixedAsset.FixedAssetID.ToString();
                    newresult.FixedAssetName = result.FixedAssetName;
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.Posted = result.Posted;
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.PostVersion = result.PostVersion ?? 0;
                    newresult.EditVersion = result.EditVersion;
                    newresult.AppliedYear = result.AppliedYear ?? 0;
                    newresult.EndYear = result.EndYear ?? 0;
                    newresult.FARefOrder = result.FARefOrder;
                    newresult.EndDevaluationDate = result.EndDevaluationDate ?? result.RefDate;
                    newresult.FAAdjustmentDetails = result.FAAdjustmentDetails.Count <= 0 ? null : FAAdjustmentDetails(result.FAAdjustmentDetails.ToList(), result.RefID.ToString());


                    newresult.OldOrgPrice = result.FAAdjustmentDetails.Count <= 0 ? 0 : result.FAAdjustmentDetailFAs.ToList()[0].OldOrgPrice;
                    newresult.OldDevaluationAmount = result.FAAdjustmentDetails.Count <= 0 ? 0 : result.FAAdjustmentDetailFAs.ToList()[0].OldDevaluationAmount;
                    newresult.OldAccumDevaluationAmount = result.FAAdjustmentDetails.Count <= 0 ? 0 : result.FAAdjustmentDetailFAs.ToList()[0].OldAccumDevaluationAmount;
                    newresult.OldAccumDepreciationAmount = result.FAAdjustmentDetails.Count <= 0 ? 0 : result.FAAdjustmentDetailFAs.ToList()[0].OldAccumDepreciationAmount;
                    newresult.OldRemainingAmount = result.FAAdjustmentDetails.Count <= 0 ? 0 : result.FAAdjustmentDetailFAs.ToList()[0].OldRemainingAmount;
                    //newresult.OldAnnualDepreciationRate = result.OldAnnualDepreciationRate;
                    newresult.OldAnnualDepreciationAmount = result.FAAdjustmentDetails.Count <= 0 ? 0 : result.FAAdjustmentDetailFAs.ToList()[0].OldAnnualDepreciationAmount;
                    //newresult.OldPeriodDevaluationAmount = result.OldPeriodDevaluationAmount;
                    newresult.OldQuantity = result.FAAdjustmentDetails.Count <= 0 ? 0 : result.FAAdjustmentDetailFAs.ToList()[0].OldQuantity;
                    //newresult.OldProductionRate = result.OldProductionRate;
                    //newresult.OldDevaluationRate = result.OldDevaluationRate;
                    //newresult.OldRemainingDevaluationLifeTime = result.OldRemainingDevaluationLifeTime;
                    newresult.NewOrgPrice = result.FAAdjustmentDetails.Count <= 0 ? 0 : result.FAAdjustmentDetailFAs.ToList()[0].NewOrgPrice;
                    newresult.NewDevaluationAmount = result.FAAdjustmentDetails.Count <= 0 ? 0 : result.FAAdjustmentDetailFAs.ToList()[0].NewDevaluationAmount;
                    newresult.NewAccumDevaluationAmount = result.FAAdjustmentDetails.Count <= 0 ? 0 : result.FAAdjustmentDetailFAs.ToList()[0].NewAccumDevaluationAmount;
                    newresult.NewAccumDepreciationAmount = result.FAAdjustmentDetails.Count <= 0 ? 0 : result.FAAdjustmentDetailFAs.ToList()[0].NewAccumDepreciationAmount;
                    newresult.NewRemainingAmount = result.FAAdjustmentDetails.Count <= 0 ? 0 : result.FAAdjustmentDetailFAs.ToList()[0].NewRemainingAmount;
                    //newresult.NewAnnualDepreciationRate = result.NewAnnualDepreciationRate;
                    newresult.NewAnnualDepreciationAmount = result.FAAdjustmentDetails.Count <= 0 ? 0 : result.FAAdjustmentDetailFAs.ToList()[0].NewAnnualDepreciationAmount;
                    //newresult.NewPeriodDevaluationAmount = result.NewPeriodDevaluationAmount;
                    newresult.NewQuantity = result.FAAdjustmentDetails.Count <= 0 ? 0 : result.FAAdjustmentDetailFAs.ToList()[0].NewQuantity;
                    //newresult.NewProductionRate = result.NewProductionRate;
                    //newresult.NewDevaluationRate = result.NewDevaluationRate;
                    //newresult.NewRemainingDevaluationLifeTime = result.NewRemainingDevaluationLifeTime;
                    //newresult.NewRemainingLifeTime = result.NewRemainingLifeTime;
                    newresult.DiffOrgPrice = result.FAAdjustmentDetails.Count <= 0 ? 0 : result.FAAdjustmentDetailFAs.ToList()[0].DiffOrgPrice;
                    newresult.DiffDevaluationAmount = result.FAAdjustmentDetails.Count <= 0 ? 0 : result.FAAdjustmentDetailFAs.ToList()[0].DiffDevaluationAmount;
                    newresult.DiffAccumDevaluationAmount = result.FAAdjustmentDetails.Count <= 0 ? 0 : result.FAAdjustmentDetailFAs.ToList()[0].DiffAccumDevaluationAmount;
                    newresult.DiffAccumDepreciationAmount = result.FAAdjustmentDetails.Count <= 0 ? 0 : result.FAAdjustmentDetailFAs.ToList()[0].DiffAccumDepreciationAmount;
                    newresult.DiffRemainingAmount = result.FAAdjustmentDetails.Count <= 0 ? 0 : result.FAAdjustmentDetailFAs.ToList()[0].DiffRemainingAmount;
                    //newresult.DiffAnnualDepreciationRate = result.DiffAnnualDepreciationRate;
                    newresult.DiffAnnualDepreciationAmount = result.FAAdjustmentDetails.Count <= 0 ? 0 : result.FAAdjustmentDetailFAs.ToList()[0].DiffAnnualDepreciationAmount;
                    //newresult.DiffPeriodDevaluationAmount = result.DiffPeriodDevaluationAmount;
                    newresult.DiffQuantity = result.FAAdjustmentDetails.Count <= 0 ? 0 : result.FAAdjustmentDetailFAs.ToList()[0].DiffQuantity;
                    //newresult.SortOrder = result.SortOrder;
                    //newresult.EndYear = result.EndYear;
                    //newresult.F = result.FAAdjustmentDetails.Count <= 0 ? null : FAAdjustmentDetails(result.FAAdjustmentDetails.ToList(), result.RefID.ToString());
                    buentity.Add(newresult);
                }
            }
            return buentity;
        }
        public List<FAAdjustmentDetailEntity> FAAdjustmentDetails(List<FAAdjustmentDetail> details, string refid)
        {
            List<FAAdjustmentDetailEntity> lstDetailEntities = new List<FAAdjustmentDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new FAAdjustmentDetailEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
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
                newresult.MethodDistributeId = result.MethodDistributeID??0;
                newresult.CashWithDrawTypeId = ConvertCash.ConvertCash(result.CashWithDrawTypeID);
                newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                newresult.ActivityId = result.Activity == null ? null : result.Activity.ActivityID.ToString();
                newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                newresult.ProjectActivityId = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
                newresult.ProjectExpenseId = result.ProjectExpense == null ? null : result.ProjectExpense.ProjectExpenseID.ToString();
                newresult.TaskId = result.Task == null ? null : result.Task.TaskID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.SortOrder = result.SortOrder??0;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.BankId = result.BankAccount;
                newresult.ProjectExpenseEAId = result.ProjectExpense1 == null ? null : result.ProjectExpense1.ProjectExpenseID.ToString();
                newresult.ProjectActivityEAId = result.Project2 == null ? null : result.Project2.ProjectID.ToString();
                newresult.BudgetProvideCode = result.BudgetProvidence == null ? null : result.BudgetProvidence.BudgetProvideCode;
                newresult.TopicId = result.Topic == null ? null : result.Topic.TopicID.ToString();
                //newresult.BudgetExpenseId = result.BudgetExpense;
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<FAAdjustmentDetailParallelEntity> FAAdjustmentDetailParallels(List<FAAdjustmentDetailParallel> details, string refid)
        {
            List<FAAdjustmentDetailParallelEntity> lstDetailEntities = new List<FAAdjustmentDetailParallelEntity>();

            foreach (var result in details)
            {
                var newresult = new FAAdjustmentDetailParallelEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
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
                newresult.MethodDistributeId = result.MethodDistributeID ?? 0;
                newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                newresult.ActivityId = result.Activity == null ? null : result.Activity.ActivityID.ToString();
                newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                newresult.TaskId = result.Task == null ? null : result.Task.TaskID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.SortOrder = result.SortOrder ?? 0;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.BankId = result.BankAccount;
                newresult.BudgetProvideCode = result.BudgetProvidence == null ? null : result.BudgetProvidence.BudgetProvideCode;
                newresult.TopicId = result.Topic == null ? null : result.Topic.TopicID.ToString();
                //newresult.BudgetExpenseId = result.BudgetExpense;
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }

        //public List<BAWithDrawDetailFixedAssetEntity> BAWithDrawDetailFixedAssets(List<BAWithDrawDetailFixedAsset> details, string refid)
        //{
        //    List<BAWithDrawDetailFixedAssetEntity> lstDetailEntities = new List<BAWithDrawDetailFixedAssetEntity>();

        //    foreach (var result in details)
        //    {
        //        var newresult = new BAWithDrawDetailFixedAssetEntity();
        //        newresult.RefDetailId = result.RefDetailID.ToString();
        //        newresult.RefId = refid;
        //        newresult.FixedAssetId = result.FixedAsset == null ? null : result.FixedAsset.FixedAssetID.ToString();
        //        newresult.Description = result.Description;
        //        newresult.DepartmentId = result.Department == null ? null : result.Department.DepartmentID.ToString();
        //        newresult.DebitAccount = result.DebitAccount;
        //        newresult.CreditAccount = result.CreditAccount;
        //        newresult.Amount = result.Amount;
        //        newresult.TaxRate = result.TaxRate;
        //        newresult.TaxAmount = result.TaxAmount;
        //        newresult.TaxAccount = result.TaxAccount;
        //        newresult.InvType = result.InvType;
        //        newresult.InvDate = result.InvDate;
        //        newresult.InvSeries = result.InvSeries;
        //        newresult.InvNo = result.InvNo;
        //        newresult.PurchasePurposeId = result.PurchasePurpose == null ? null : result.PurchasePurpose.PurchasePurposeID.ToString();
        //        newresult.FreightAmount = result.FreightAmount;
        //        newresult.OrgPrice = result.OrgPrice;
        //        newresult.BudgetSourceId = result.BudgetSource == null ? null : result.BudgetSource.BudgetSourceID.ToString();
        //        newresult.BudgetChapterCode = result.BudgetChapterCode;
        //        newresult.BudgetKindItemCode = result.BudgetKindItemCode;
        //        newresult.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
        //        newresult.BudgetItemCode = result.BudgetItemCode;
        //        newresult.BudgetSubItemCode = result.BudgetSubItemCode;
        //        newresult.MethodDistributeId = result.MethodDistributeID;
        //        newresult.CashWithdrawTypeId = ConvertCash.ConvertCash(result.CashWithdrawTypeID);
        //        newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
        //        newresult.ActivityId = result.Activity == null ? null : result.Activity.ActivityID.ToString();
        //        newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
        //        newresult.FundId = result.FundID.ToString();
        //        newresult.ProjectActivityId = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
        //        newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
        //        newresult.SortOrder = result.SortOrder;
        //        newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
        //        newresult.InvoiceTypeCode = result.InvoiceTypeCode;
        //        newresult.OrgRefNo = result.OrgRefNo;
        //        newresult.OrgRefDate = result.OrgRefDate;
        //        newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
        //        newresult.BankId = result.BankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.BankAccount).BankInfoID.ToString();
        //        newresult.ProjectActivityEAId = result.Project2 == null ? null : result.Project2.ProjectID.ToString();
        //        //newresult.BudgetExpenseId = result.budgete;

        //        lstDetailEntities.Add(newresult);
        //    }
        //    return lstDetailEntities;
        //}
    }
}
