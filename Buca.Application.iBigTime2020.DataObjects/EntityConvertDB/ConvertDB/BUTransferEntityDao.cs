using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class BUTransferEntityDao : IEntityBUTransferDao
    {
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        private readonly ConvertCashWithdrawType ConvertCash = new ConvertCashWithdrawType();
        private List<BankInfo> banks;
        public List<BUTransferEntity> GetBUTransfers(string connectionString)
        {
            List<BUTransferEntity> buentity = new List<BUTransferEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var querry = context.BUTransferDetails.ToList();
                var projects = context.Projects.ToList();
                var currencys = context.CCies.ToList();
                var budgetsource = context.BudgetSources.ToList();
                var listitems = context.ListItems.ToList();
                var funds = context.Funds.ToList();
                var fundstructures = context.FundStructures.ToList();
                var budgetproviders = context.BudgetProvidences.ToList();
                var accountingobject = context.AccountingObjects.ToList();
                var projectexpenses = context.ProjectExpenses.ToList();
                var activity = context.Activities.ToList();
                var tasks = context.Tasks.ToList();
                var topics = context.Topics.ToList();
                banks = context.BankInfoes.ToList();
                var department = context.Departments.ToList();
                var resultcontext = context.BUTransfers.ToList();
                var fixedasset = context.FixedAssets.ToList();
                var inventoryitems = context.InventoryItems.ToList();
                var stocks = context.Stocks.ToList();
                //Detail
                var parallel = context.BUTransferDetailParallels.ToList();
                var detailfixedassets = context.BUTransferDetailFixedAssets.ToList();
                var purchases = context.BUTransferDetailPurchases.ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new BUTransferEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.CurrencyCode = result.CCY == null ? null : result.CCY.CurrencyID;
                    newresult.ExchangeRate = result.ExchangeRate ?? 0;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.TargetProgramId = result.Project == null ? null : result.Project.ProjectID.ToString();
                    newresult.BankInfoId = result.BankInfo.BankInfoID.ToString();
                    newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                    newresult.AccountingObjectName = result.AccountingObjectName;
                    newresult.AccountingObjectAddress = result.AccountingObjectAddress;
                    newresult.AccountingObjectBankAccount = result.AccountingObjectBankAccount;
                    newresult.AccountingObjectBankName = result.AccountingObjectBankName;
                    newresult.DocumentIncluded = result.DocumentIncluded;
                    newresult.InwardStockRefNo = result.InwardStockRefNo;
                    newresult.WithdrawRefDate = result.WithdrawRefDate;
                    newresult.WithdrawRefNo = result.WithdrawRefNo;
                    newresult.IncrementRefNo = result.IncrementRefNo;
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.TotalAmountOC = result.TotalAmountOC;
                    newresult.TotalTaxAmount = result.TotalTaxAmount;
                    newresult.TotalFreightAmount = result.TotalFreightAmount;
                    newresult.TotalInwardAmount = result.TotalInwardAmount;
                    newresult.Posted = result.Posted;
                    newresult.PostVersion = result.PostVersion;
                    newresult.EditVersion = result.EditVersion;
                    newresult.RefOrder = result.RefOrder;
                    newresult.RelationRefId = result.RelationRefID.ToString();
                    newresult.BUCommitmentRequestId = result.BUCommitmentRequestID.ToString();
                    newresult.TotalFixedAssetAmount = result.TotalFixedAssetAmount;
                    //newresult.BUPlanWithdrawRefId = result.BUCommitmentRequestID;
                    //newresult.LinkRefNo = result.RefNo;
                    //newresult.gLVouchersRefId = result.v;
                    newresult.BUTransferDetails = result.BUTransferDetails.Count <= 0 ? null : BUTransferDetails(result.BUTransferDetails.ToList(), result.RefID.ToString());
                    newresult.BUTransferDetailParallels = result.BUTransferDetailParallels.Count <= 0 ? null : BUTransferDetailParallels(result.BUTransferDetailParallels.ToList(), result.RefID.ToString());
                    newresult.BUTransferDetailFixedAssets = result.BUTransferDetailFixedAssets.Count <= 0 ? null : BUTransferDetailFixedAssets(result.BUTransferDetailFixedAssets.ToList(), result.RefID.ToString());
                    newresult.BUTransferDetailPurchases = result.BUTransferDetailPurchases.Count <= 0 ? null : BUTransferDetailPurchases(result.BUTransferDetailPurchases.ToList(), result.RefID.ToString());
                    buentity.Add(newresult);
                }
            }
            return buentity;
        }
        public List<BUTransferDetailEntity> BUTransferDetails(List<BUTransferDetail> details, string refid)
        {
            List<BUTransferDetailEntity> lstDetailEntities = new List<BUTransferDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new BUTransferDetailEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.Description = result.Description;
                newresult.DebitAccount = result.DebitAccount;
                newresult.CreditAccount = result.CreditAccount;
                newresult.Amount = result.Amount;
                newresult.AmountOC = result.AmountOC;
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
                newresult.Approved = result.Approved;
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.FundId = result.Fund == null ? null : result.Fund.FundID.ToString();
                newresult.OrgRefNo = result.OrgRefNo;
                newresult.OrgRefDate = result.OrgRefDate;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.ProjectExpenseEAId = result.ProjectExpense1 == null ? null : result.ProjectExpense1.ProjectExpenseID.ToString();
                newresult.ProjectActivityEAId = result.Project2 == null ? null : result.Project2.ProjectID.ToString();
                newresult.WithdrawRefDetailId = result.WithdrawRefDetailID.ToString();
                newresult.BudgetProvideCode = result.BudgetProvidence == null ? null : result.BudgetProvidence.BudgetProvideCode;
                newresult.TopicId = result.Topic == null ? null : result.Topic.TopicID.ToString();
                //newresult.BudgetExpenseId = result.budget;
                //newresult.BankId = result.;
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<BUTransferDetailParallelEntity> BUTransferDetailParallels(List<BUTransferDetailParallel> details, string refid)
        {
            List<BUTransferDetailParallelEntity> lstDetailEntities = new List<BUTransferDetailParallelEntity>();

            foreach (var result in details)
            {
                var newresult = new BUTransferDetailParallelEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.ParentRefDetailId = result.ParentRefDetailID.ToString();
                newresult.RefId = refid;
                newresult.Description = result.Description;
                newresult.DebitAccount = result.DebitAccount;
                newresult.CreditAccount = result.CreditAccount;
                newresult.Amount = result.Amount;
                newresult.AmountOC = result.AmountOC;
                newresult.BudgetSourceId = result.BudgetSource == null ? null : result.BudgetSource.BudgetSourceID.ToString();
                newresult.BudgetChapterCode = result.BudgetChapterCode;
                newresult.BudgetKindItemCode = result.BudgetKindItemCode;
                newresult.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                newresult.BudgetItemCode = result.BudgetItemCode;
                newresult.BudgetSubItemCode = result.BudgetSubItemCode;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.MethodDistributeId = result.MethodDistributeID;
                newresult.CashWithdrawTypeId = ConvertCash.ConvertCash(result.CashWithdrawTypeID);
                newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                newresult.ActivityId = result.Activity == null ? null : result.Activity.ActivityID.ToString();
                newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                newresult.FundId = result.Fund == null ? null : result.Fund.FundID.ToString();
                newresult.TaskId = result.Task == null ? null : result.Task.TaskID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.SortOrder = result.SortOrder;
                newresult.OrgRefNo = result.OrgRefNo;
                newresult.OrgRefDate = result.OrgRefDate;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.BankId = result.BankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.BankAccount).BankInfoID.ToString();
                newresult.BudgetProvideCode = result.BudgetProvidence == null ? null : result.BudgetProvidence.BudgetProvideCode;
                newresult.TopicId = result.Topic == null ? null : result.Topic.TopicID.ToString();
                newresult.BudgetExpenseId = result.BudgetExpenseID.ToString();
                newresult.Approved = result.Approved;

                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<BUTransferDetailFixedAssetEntity> BUTransferDetailFixedAssets(List<BUTransferDetailFixedAsset> details, string refid)
        {
            List<BUTransferDetailFixedAssetEntity> lstDetailEntities = new List<BUTransferDetailFixedAssetEntity>();

            foreach (var result in details)
            {
                var newresult = new BUTransferDetailFixedAssetEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.FixedAssetId = result.FixedAsset == null ? null : result.FixedAsset.FixedAssetID.ToString();
                newresult.Description = result.Description;
                newresult.DepartmentId = result.Department == null ? null : result.Department.DepartmentID.ToString();
                newresult.DebitAccount = result.DebitAccount;
                newresult.CreditAccount = result.CreditAccount;
                newresult.Amount = result.Amount;
                newresult.TaxRate = Convert.ToInt32(result.TaxRate ?? 0);
                newresult.TaxAmount = result.TaxAmount;
                newresult.FreightAmount = result.FreightAmount;
                newresult.OrgPrice = result.OrgPrice;
                newresult.BudgetSourceId = result.BudgetSource == null ? null : result.BudgetSource.BudgetSourceID.ToString();
                newresult.BudgetChapterCode = result.BudgetChapterCode;
                newresult.BudgetKindItemCode = result.BudgetKindItemCode;
                newresult.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                newresult.BudgetItemCode = result.BudgetItemCode;
                newresult.BudgetSubItemCode = result.BudgetSubItemCode;
                newresult.MethodDistributeId = result.MethodDistributeID;
                newresult.CashWithdrawTypeId = ConvertCash.ConvertCash(result.CashWithdrawTypeID);
                newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                newresult.ActivityId = result.Activity == null ? null : result.Activity.ActivityID.ToString();
                newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                newresult.ProjectActivityId = result.ProjectActivityID.ToString();
                newresult.ProjectExpenseId = result.ProjectExpense == null ? null : result.ProjectExpense.ProjectExpenseID.ToString();
                newresult.TaskId = result.Task == null ? null : result.Task.TaskID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.Approved = result.Approved;
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.OrgRefNo = result.OrgRefNo;
                newresult.OrgRefDate = result.OrgRefDate;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.ProjectExpenseEAId = result.ProjectExpense1 == null ? null : result.ProjectExpense1.ProjectExpenseID.ToString();
                newresult.ProjectActivityEAId = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
                newresult.BudgetProvideCode = result.BudgetProvidence == null ? null : result.BudgetProvidence.BudgetProvideCode;
                newresult.TopicId = result.Topic == null ? null : result.Topic.TopicID.ToString();
                //newresult.CreatedDate = result.cre;
                //newresult.BudgetExpenseId = result.BudgetE;
                //newresult.BankId = result.BankID;

                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<BUTransferDetailPurchaseEntity> BUTransferDetailPurchases(List<BUTransferDetailPurchase> details, string refid)
        {
            List<BUTransferDetailPurchaseEntity> lstDetailEntities = new List<BUTransferDetailPurchaseEntity>();

            foreach (var result in details)
            {
                var newresult = new BUTransferDetailPurchaseEntity();

                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.InventoryItemId = result.InventoryItem == null ? null : result.InventoryItem.InventoryItemID.ToString();
                newresult.Description = result.Description;
                newresult.StockId = result.Stock == null ? null : result.Stock.StockID.ToString();
                newresult.DebitAccount = result.DebitAccount;
                newresult.CreditAccount = result.CreditAccount;
                newresult.Unit = result.Unit;
                newresult.Quantity = result.Quantity;
                newresult.QuantityConvert = result.QuantityConvert;
                newresult.UnitPrice = result.UnitPrice;
                newresult.UnitPriceConvert = result.UnitPriceConvert;
                newresult.Amount = result.Amount;
                newresult.TaxRate = Convert.ToInt32(result.TaxRate ?? 0);
                newresult.TaxAmount = result.TaxAmount;
                newresult.FreightAmount = result.FreightAmount;
                newresult.InwardAmount = result.InwardAmount;
                newresult.BudgetSourceId = result.BudgetSource == null ? null : result.BudgetSource.BudgetSourceID.ToString();
                newresult.BudgetChapterCode = result.BudgetChapterCode;
                newresult.BudgetKindItemCode = result.BudgetKindItemCode;
                newresult.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                newresult.BudgetItemCode = result.BudgetItemCode;
                newresult.BudgetSubItemCode = result.BudgetSubItemCode;
                newresult.MethodDistributeId = result.MethodDistributeID;
                newresult.CashWithdrawTypeId = ConvertCash.ConvertCash(result.CashWithdrawTypeID);
                newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                newresult.ActivityId = result.Activity == null ? null : result.Activity.ActivityID.ToString();
                newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                newresult.ProjectActivityId = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
                newresult.ProjectExpenseId = result.ProjectExpense == null ? null : result.ProjectExpense.ProjectExpenseID.ToString();
                newresult.TaskId = result.Task == null ? null : result.Task.TaskID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.ExpiryDate = result.ExpiryDate;
                newresult.LotNo = result.LotNo;
                newresult.Approved = result.Approved;
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.OrgRefNo = result.OrgRefNo;
                newresult.OrgRefDate = result.OrgRefDate;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.ProjectExpenseEAId = result.ProjectExpense1 == null ? null : result.ProjectExpense1.ProjectExpenseID.ToString();
                newresult.ProjectActivityEAId = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
                newresult.BudgetProvideCode = result.BudgetProvidence == null ? null : result.BudgetProvidence.BudgetProvideCode;
                newresult.TopicId = result.Topic == null ? null : result.Topic.TopicID.ToString();
                //newresult.CreateDate = result.CreateDate;
                //newresult.BudgetExpenseID = result.BudgetExpenseID;
                //newresult.BankID = result.BankID;

                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
    }
}
