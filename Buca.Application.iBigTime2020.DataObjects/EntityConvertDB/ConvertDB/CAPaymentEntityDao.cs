using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class CAPaymentEntityDao : IEntityCAPaymentDao
    {
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        private readonly ConvertCashWithdrawType ConvertCash = new ConvertCashWithdrawType();
        private List<BankInfo> banks;
        public List<CAPaymentEntity> GetCAPaymentLists(string connectionString)
        {
            List<CAPaymentEntity> buentity = new List<CAPaymentEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var querry = context.CAPaymentDetails.ToList();
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
                var stocks = context.Stocks.ToList();
                //var topics = context.Topics.ToList();
                var fixedassets = context.FixedAssets.ToList();
                var departments = context.Departments.ToList();
                var purchasepurposes = context.PurchasePurposes.ToList();
                var inventoryitems = context.InventoryItems.ToList();
                banks = context.BankInfoes.ToList();
                var detailfixedassets = context.CAPaymentDetailFixedAssets.ToList();
                var detailparallels = context.CAPaymentDetailParallels.ToList();
                var detailpurchases = context.CAPaymentDetailPurchases.ToList();
                var detailtax = context.CAPaymentDetailTaxes.ToList();
                var resultcontext = context.CAPayments.ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new CAPaymentEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.ExchangeRate = result.ExchangeRate ?? 0;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.IncrementRefNo = result.IncrementRefNo;
                    newresult.InwardRefNo = result.InwardRefNo;
                    newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.DocumentIncluded = result.DocumentIncluded;
                    newresult.BankId = result.BankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.BankAccount).BankInfoID.ToString();
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.TotalAmountOC = result.TotalAmountOC;
                    newresult.TotalTaxAmount = result.TotalTaxAmount;
                    newresult.TotalFreightAmount = result.TotalFreightAmount;
                    newresult.TotalInwardAmount = result.TotalInwardAmount;
                    newresult.Posted = result.Posted;
                    newresult.RefOrder = result.RefOrder ?? 0;
                    newresult.RelationRefId = result.RelationRefID.ToString();
                    newresult.TotalPaymentAmount = result.TotalPaymentAmount;
                    newresult.CurrencyCode = result.CCY == null ? null : result.CCY.CurrencyID;
                    newresult.CaPaymentDetails = CAPaymentDetails(result.CAPaymentDetails.ToList(), result.RefID.ToString());
                    newresult.CAPaymentDetailFixedAssets = result.CAPaymentDetailFixedAssets.Count <= 0 ? null : CAPaymentDetailFixedAssets(result.CAPaymentDetailFixedAssets.ToList(), result.RefID.ToString());
                    newresult.CAPaymentDetailParallels = result.CAPaymentDetailParallels.Count <= 0 ? null : CAPaymentDetailParallels(result.CAPaymentDetailParallels.ToList(), result.RefID.ToString());
                    newresult.CAPaymentDetailPurchases = result.CAPaymentDetailPurchases.Count <= 0 ? null : CAPaymentDetailPurchases(result.CAPaymentDetailPurchases.ToList(), result.RefID.ToString());
                    newresult.CaPaymentDetailTaxes = result.CAPaymentDetailTaxes.Count <= 0 ? null : CAPaymentDetailTaxes(result.CAPaymentDetailTaxes.ToList(), result.RefID.ToString());
                    buentity.Add(newresult);
                }
            }
            return buentity;
        }

        public List<CAPaymentDetailEntity> CAPaymentDetails(List<CAPaymentDetail> details, string refid)
        {
            List<CAPaymentDetailEntity> lstDetailEntities = new List<CAPaymentDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new CAPaymentDetailEntity();
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
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.Approved = result.Approved;
                newresult.SortOrder = result.SortOrder ?? 0;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.OrgRefNo = result.OrgRefNo;
                newresult.OrgRefDate = result.OrgRefDate;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.BankId = result.BankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.BankAccount).BankInfoID.ToString();
                newresult.ProjectExpenseEAId = result.ProjectExpense1 == null ? null : result.ProjectExpense1.ProjectExpenseID.ToString();
                newresult.ProjectActivityEAId = result.Project2 == null ? null : result.Project2.ProjectID.ToString();
                newresult.BudgetExpenseId = result.BudgetExpenseID.ToString();
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<CAPaymentDetailFixedAssetEntity> CAPaymentDetailFixedAssets(List<CAPaymentDetailFixedAsset> details, string refid)
        {
            List<CAPaymentDetailFixedAssetEntity> lstDetailEntities = new List<CAPaymentDetailFixedAssetEntity>();

            foreach (var result in details)
            {
                var newresult = new CAPaymentDetailFixedAssetEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.FixedAssetId = result.FixedAsset == null ? null : result.FixedAsset.FixedAssetID.ToString();
                newresult.Description = result.Description;
                newresult.DepartmentId = result.Department == null ? null : result.Department.DepartmentID.ToString();
                newresult.DebitAccount = result.DebitAccount;
                newresult.CreditAccount = result.CreditAccount;
                newresult.Amount = result.Amount;
                newresult.TaxRate = result.TaxRate;
                newresult.TaxAmount = result.TaxAmount;
                newresult.TaxAccount = result.TaxAccount;
                newresult.InvType = result.InvType;
                newresult.InvDate = result.InvDate;
                newresult.InvSeries = result.InvSeries;
                newresult.InvNo = result.InvNo;
                newresult.PurchasePurposeId = result.PurchasePurpose == null ? null : result.PurchasePurpose.PurchasePurposeID.ToString();
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
                newresult.FundId = result.Fund == null ? null : result.Fund.FundID.ToString();
                newresult.ProjectActivityId = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
                newresult.ProjectExpenseId = result.ProjectExpense == null ? null : result.ProjectExpense.ProjectExpenseID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.Approved = result.Approved;
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.InvoiceTypeCode = result.InvoiceTypeCode;
                newresult.OrgRefNo = result.OrgRefNo;
                newresult.OrgRefDate = result.OrgRefDate;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.BankId = result.BankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.BankAccount).BankInfoID.ToString();
                newresult.ProjectExpenseEAId = result.ProjectExpense1 == null ? null : result.ProjectExpense1.ProjectExpenseID.ToString();
                newresult.ProjectActivityEAId = result.Project2 == null ? null : result.Project2.ProjectID.ToString();
                //newresult.BudgetExpenseId = result.Budgete;

                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<CAPaymentDetailParallelEntity> CAPaymentDetailParallels(List<CAPaymentDetailParallel> details, string refid)
        {
            List<CAPaymentDetailParallelEntity> lstDetailEntities = new List<CAPaymentDetailParallelEntity>();

            foreach (var result in details)
            {
                var newresult = new CAPaymentDetailParallelEntity();
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
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.MethodDistributeId = result.MethodDistributeID;
                newresult.CashWithdrawTypeId = ConvertCash.ConvertCash(result.CashWithdrawTypeID);
                newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                newresult.ActivityId = result.Activity == null ? null : result.Activity.ActivityID.ToString();
                newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                newresult.TaskId = result.Task == null ? null : result.Task.TaskID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.Approved = result.Approved;
                newresult.SortOrder = result.SortOrder;
                newresult.OrgRefNo = result.OrgRefNo;
                newresult.OrgRefDate = result.OrgRefDate;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.BankId = result.BankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.BankAccount).BankInfoID.ToString();
                newresult.BudgetExpenseId = result.BudgetExpenseID.ToString();
                newresult.BudgetProvideCode = result.BudgetProvidence == null ? null : result.BudgetProvidence.BudgetProvideCode;

                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<CAPaymentDetailPurchaseEntity> CAPaymentDetailPurchases(List<CAPaymentDetailPurchase> details, string refid)
        {
            List<CAPaymentDetailPurchaseEntity> lstDetailEntities = new List<CAPaymentDetailPurchaseEntity>();

            foreach (var result in details)
            {
                var newresult = new CAPaymentDetailPurchaseEntity();

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
                newresult.InvType = result.InvType;
                newresult.InvDate = result.InvDate;
                newresult.InvSeries = result.InvSeries;
                newresult.InvNo = result.InvNo;
                newresult.TaxRate = result.TaxRate;
                newresult.TaxAmount = result.TaxAmount;
                newresult.TaxAccount = result.TaxAccount;
                newresult.PurchasePurposeId = result.PurchasePurpose == null ? null : result.PurchasePurpose.PurchasePurposeID.ToString();
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
                newresult.ProjectActivityId = result.Project == null ? null : result.Project.ProjectID.ToString();
                newresult.ProjectExpenseId = result.ProjectExpense == null ? null : result.ProjectExpense.ProjectExpenseID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.ExpiryDate = result.ExpiryDate;
                newresult.LotNo = result.LotNo;
                newresult.Approved = result.Approved;
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.InvoiceTypeCode = result.InvoiceTypeCode;
                newresult.OrgRefNo = result.OrgRefNo;
                newresult.OrgRefDate = result.OrgRefDate;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.ProjectExpenseEAId = result.ProjectExpense1 == null ? null : result.ProjectExpense1.ProjectExpenseID.ToString();
                newresult.ProjectActivityEAId = result.Project2 == null ? null : result.Project2.ProjectID.ToString();
                //newresult.BudgetExpenseId = result.BudgetExpense;

                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<CAPaymentDetailTaxEntity> CAPaymentDetailTaxes(List<CAPaymentDetailTax> details, string refid)
        {
            List<CAPaymentDetailTaxEntity> lstDetailEntities = new List<CAPaymentDetailTaxEntity>();

            foreach (var result in details)
            {
                var newresult = new CAPaymentDetailTaxEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.Description = result.Description;
                newresult.VATAmount = result.VATAmount;
                newresult.VATRate = result.VATRate;
                newresult.TurnOver = result.TurnOver;
                newresult.InvType = result.InvType;
                newresult.InvDate = result.InvDate;
                newresult.InvSeries = result.InvSeries;
                newresult.InvNo = result.InvNo;
                newresult.PurchasePurposeId = result.PurchasePurposeID.ToString();
                newresult.AccountingObjectId = result.AccountingObjectID.ToString();
                newresult.CompanyTaxCode = result.CompanyTaxCode;
                newresult.SortOrder = result.SortOrder ?? 0;
                newresult.InvoiceTypeCode = result.InvoiceTypeCode;
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
    }
}

