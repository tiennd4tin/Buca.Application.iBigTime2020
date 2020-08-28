using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.IncrementDecrement;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class FAIncrementDecrementEntityDao: IEntityFAIncrementDecrementDao
    {
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        private readonly ConvertCashWithdrawType ConvertCash = new ConvertCashWithdrawType();
        private List<BankInfo> banks;
        public List<FAIncrementDecrementEntity> GetFAIncrementDecrements(string connectionString)
        {
            List<FAIncrementDecrementEntity> buentity = new List<FAIncrementDecrementEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var querry = context.FAIncrementDecrementDetails.ToList();
                var projects = context.Projects.ToList();
                //var currencys = context.CCies.ToList();
                var budgetsource = context.BudgetSources.ToList();
                var listitems = context.ListItems.ToList();
                //var funds = context.Funds.ToList();
                var fundstructures = context.FundStructures.ToList();
                //var budgetproviders = context.BudgetProvidences.ToList();
                var accountingobject = context.AccountingObjects.ToList();
                var projectexpenses = context.ProjectExpenses.ToList();
                var activity = context.Activities.ToList();
                //var tasks = context.Tasks.ToList();
                //var topics = context.Topics.ToList();
                //banks = context.BankInfoes.ToList();
                var department = context.Departments.ToList();
                var resultcontext = context.FAIncrementDecrements.ToList();
                var fixedasset = context.FixedAssets.ToList();
                //Get CAReceipts
                var resultcontext2 = context.CAReceipts.Where(x => x.RefType == 103).ToList();
                var resultcontext2Fixedasset = context.CAReceiptDetailFixedAssets.ToList();
                //Get BADeposits
                var resultcontext3 = context.BADeposits.Where(x => x.RefType == 155).ToList();
                var resultcontext3Fixedasset = context.BADepositDetailFixedAssets.ToList();
                //Get SAInvoices
                var resultcontext4 = context.SAInvoices.Where(x => x.RefType == 256).ToList();
                var resultcontext4Fixedasset = context.SAInvoiceDetailFixedAssets.ToList();
                //var inventoryitems = context.InventoryItems.ToList();
                //var stocks = context.Stocks.ToList();
                #region Detail
                foreach (var result in resultcontext)
                {
                    var newresult = new FAIncrementDecrementEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.GeneratedRefId = result.GeneratedRefID.ToString();
                    newresult.FAIncrementDecrementDetails = result.FAIncrementDecrementDetails.Count <= 0 ? null : FAIncrementDecrementDetails(result.FAIncrementDecrementDetails.ToList(), result.RefID.ToString());
                    buentity.Add(newresult);
                }
                #endregion

                #region CAReceipts
                foreach (var result in resultcontext2)
                {
                    var newresult = new FAIncrementDecrementEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.TotalAmount = result.TotalAmount;
                    //newresult.GeneratedRefId = result.GeneratedRefID.ToString();
                    newresult.FAIncrementDecrementDetails = resultcontext2Fixedasset.Count <= 0 ? null : FAIncrementDecrementDetailsFromCAReceipt(resultcontext2Fixedasset, result.RefID.ToString());
                    buentity.Add(newresult);
                }
                #endregion

                #region BADeposits
                foreach (var result in resultcontext3)
                {
                    var newresult = new FAIncrementDecrementEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.TotalAmount = result.TotalAmount;
                    //newresult.GeneratedRefId = result.GeneratedRefID.ToString();
                    newresult.FAIncrementDecrementDetails = resultcontext3Fixedasset.Count <= 0 ? null : FAIncrementDecrementDetailsFromBADeposits(resultcontext3Fixedasset, result.RefID.ToString());
                    buentity.Add(newresult);
                }
                #endregion

                #region SAInvoices
                foreach (var result in resultcontext4)
                {
                    var newresult = new FAIncrementDecrementEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.TotalAmount = result.TotalAmount;
                    //newresult.GeneratedRefId = result.GeneratedRefID.ToString();
                    newresult.FAIncrementDecrementDetails = resultcontext4Fixedasset.Count <= 0 ? null : FAIncrementDecrementDetailsFromSAInvoices(resultcontext4Fixedasset, result.RefID.ToString());
                    buentity.Add(newresult);
                }
                #endregion
            }
            return buentity;
        }

        public List<FAIncrementDecrementDetailEntity> FAIncrementDecrementDetails(List<FAIncrementDecrementDetail> details, string refid)
        {
            List<FAIncrementDecrementDetailEntity> lstDetailEntities = new List<FAIncrementDecrementDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new FAIncrementDecrementDetailEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.FixedAssetId = result.FixedAsset == null ? null : result.FixedAsset.FixedAssetID.ToString();
                newresult.Description = result.Description;
                newresult.DepartmentId = result.Department == null ? null : result.Department.DepartmentID.ToString();
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
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.Approved = result.Approved;
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.BankId = result.BankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.BankAccount).BankInfoID.ToString();
                newresult.ProjectExpenseEAId = result.ProjectExpense1 == null ? null : result.ProjectExpense1.ProjectExpenseID.ToString();
                newresult.ProjectActivityEAId = result.Project2 == null ? null : result.Project2.ProjectID.ToString();
                newresult.DecreaseReasonId= result.DecreaseReasonID;
                //newresult.BudgetExpenseId = result.BudgetExpense;
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<FAIncrementDecrementDetailEntity> FAIncrementDecrementDetailsFromCAReceipt(List<CAReceiptDetailFixedAsset> details, string refid)
        {
            List<FAIncrementDecrementDetailEntity> lstDetailEntities = new List<FAIncrementDecrementDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new FAIncrementDecrementDetailEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.FixedAssetId = result.FixedAsset == null ? null : result.FixedAsset.FixedAssetID.ToString();
                newresult.Description = result.Description;
                //newresult.DepartmentId = result.Department == null ? null : result.Department.DepartmentID.ToString();
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
                newresult.CashWithDrawTypeId = ConvertCash.ConvertCash(result.CashWithdrawTypeID);
                newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                newresult.ActivityId = result.Activity == null ? null : result.Activity.ActivityID.ToString();
                newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                newresult.ProjectActivityId = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                //newresult.Approved = result.Approved;
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                //newresult.BankId = result.BankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.BankAccount).BankInfoID.ToString();
                newresult.ProjectExpenseEAId = result.ProjectExpense1 == null ? null : result.ProjectExpense1.ProjectExpenseID.ToString();
                newresult.ProjectActivityEAId = result.Project2 == null ? null : result.Project2.ProjectID.ToString();
                //newresult.DecreaseReasonId = result.DecreaseReasonID;
                //newresult.BudgetExpenseId = result.BudgetExpense;
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<FAIncrementDecrementDetailEntity> FAIncrementDecrementDetailsFromBADeposits(List<BADepositDetailFixedAsset> details, string refid)
        {
            List<FAIncrementDecrementDetailEntity> lstDetailEntities = new List<FAIncrementDecrementDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new FAIncrementDecrementDetailEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.FixedAssetId = result.FixedAsset == null ? null : result.FixedAsset.FixedAssetID.ToString();
                newresult.Description = result.Description;
                //newresult.DepartmentId = result.Department == null ? null : result.Department.DepartmentID.ToString();
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
                newresult.CashWithDrawTypeId = ConvertCash.ConvertCash(result.CashWithdrawTypeID);
                newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                newresult.ActivityId = result.Activity == null ? null : result.Activity.ActivityID.ToString();
                newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                newresult.ProjectActivityId = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                //newresult.Approved = result.Approved;
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                //newresult.BankId = result.BankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.BankAccount).BankInfoID.ToString();
                newresult.ProjectExpenseEAId = result.ProjectExpense1 == null ? null : result.ProjectExpense1.ProjectExpenseID.ToString();
                newresult.ProjectActivityEAId = result.Project2 == null ? null : result.Project2.ProjectID.ToString();
                //newresult.DecreaseReasonId = result.DecreaseReasonID;
                //newresult.BudgetExpenseId = result.BudgetExpense;
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<FAIncrementDecrementDetailEntity> FAIncrementDecrementDetailsFromSAInvoices(List<SAInvoiceDetailFixedAsset> details, string refid)
        {
            List<FAIncrementDecrementDetailEntity> lstDetailEntities = new List<FAIncrementDecrementDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new FAIncrementDecrementDetailEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.FixedAssetId = result.FixedAsset == null ? null : result.FixedAsset.FixedAssetID.ToString();
                newresult.Description = result.Description;
                //newresult.DepartmentId = result.Department == null ? null : result.Department.DepartmentID.ToString();
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
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                //newresult.Approved = result.Approved;
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                //newresult.BankId = result.BankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.BankAccount).BankInfoID.ToString();
                newresult.ProjectExpenseEAId = result.ProjectExpense1 == null ? null : result.ProjectExpense1.ProjectExpenseID.ToString();
                newresult.ProjectActivityEAId = result.Project2 == null ? null : result.Project2.ProjectID.ToString();
                //newresult.DecreaseReasonId = result.DecreaseReasonID;
                //newresult.BudgetExpenseId = result.BudgetExpense;
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
    }
}
