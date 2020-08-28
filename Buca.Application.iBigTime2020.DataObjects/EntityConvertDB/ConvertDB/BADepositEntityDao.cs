using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class BADepositEntityDao : IEntityBADepositDao
    {
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        private readonly ConvertCashWithdrawType ConvertCash = new ConvertCashWithdrawType();
        private List<BankInfo> banks;
        public List<BADepositEntity> GetBADeposits(string connectionString)
        {
            List<BADepositEntity> buentity = new List<BADepositEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var querry = context.BADepositDetails.ToList();
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
                var resultcontext = context.BADeposits.Where(x => x.RefType != 154).Where(x => x.RefType != 155).ToList();
                var fixedasset = context.FixedAssets.ToList();
                var inventoryitems = context.InventoryItems.ToList();
                var stocks = context.Stocks.ToList();
                var invoiceformnumber = context.InvoiceFormNumbers.ToList();
                //Detail
                var parallel = context.BADepositDetailParallels.ToList();
                var detailfixedassets = context.BADepositDetailFixedAssets.ToList();
                var sales = context.BADepositDetailSales.ToList();
                var taxs = context.BADepositDetailTaxes.ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new BADepositEntity();

                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.CurrencyCode = result.CCY == null ? null : result.CCY.CurrencyID;
                    newresult.ExchangeRate = result.ExchangeRate ?? 0;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.OutwardRefNo = result.OutwardRefNo;
                    newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                    newresult.BankId = result.BankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.BankAccount).BankInfoID.ToString();
                    newresult.InvType = result.InvType;
                    newresult.InvDate = result.InvDate;
                    newresult.InvSeries = result.InvSeries;
                    newresult.InvNo = result.InvNo;
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.TotalAmountOC = result.TotalAmountOC;
                    newresult.TotalTaxAmount = result.TotalTaxAmount;
                    newresult.TotalOutwardAmount = result.TotalOutwardAmount;
                    newresult.Reconciled = result.Reconciled;
                    newresult.Posted = result.Posted;
                    newresult.PostVersion = result.PostVersion;
                    newresult.EditVersion = result.EditVersion;
                    newresult.RefOrder = result.RefOrder;
                    newresult.InvoiceForm = result.InvoiceForm;
                    newresult.InvoiceFormNumberId = result.InvoiceFormNumber == null ? null : result.InvoiceFormNumber.InvoiceFormNumberID.ToString();
                    newresult.InvSeriesPrefix = result.InvSeriesPrefix;
                    newresult.InvSeriesSuffix = result.InvSeriesSuffix;
                    newresult.PayForm = result.PayForm;
                    newresult.ComPanyTaxcode = result.ComPanyTaxcode;
                    newresult.AccountingObjectContactName = result.AccountingObjectContactName;
                    newresult.ListNo = result.ListNo;
                    newresult.ListDate = result.ListDate;
                    newresult.IsAttachList = result.IsAttachList;
                    newresult.ListCommonNameInventory = result.ListCommonNameInventory;
                    newresult.BUCommitmentRequestId = result.BUCommitmentRequestID.ToString();
                    newresult.TotalReceiptAmount = result.TotalReceiptAmount;

                    newresult.BADepositDetails = result.BADepositDetails.Count <= 0 ? null : BADepositDetails(result.BADepositDetails.ToList(), result.RefID.ToString());
                    newresult.BADepositDetailParallels = result.BADepositDetailParallels.Count <= 0 ? null : BADepositDetailParallels(result.BADepositDetailParallels.ToList(), result.RefID.ToString());
                    newresult.BADepositDetailFixedAssetEntities = result.BADepositDetailFixedAssets.Count <= 0 ? null : BADepositDetailFixedAssets(result.BADepositDetailFixedAssets.ToList(), result.RefID.ToString());
                    newresult.BADepositDetailSaleEntities = result.BADepositDetailSales.Count <= 0 ? null : BADepositDetailSales(result.BADepositDetailSales.ToList(), result.RefID.ToString());
                    newresult.BADepositDetailTaxEntities = result.BADepositDetailTaxes.Count <= 0 ? null : BADepositDetailTaxes(result.BADepositDetailTaxes.ToList(), result.RefID.ToString());

                    buentity.Add(newresult);
                }
            }
            return buentity;
        }
        public List<BADepositDetailEntity> BADepositDetails(List<BADepositDetail> details, string refid)
        {
            List<BADepositDetailEntity> lstDetailEntities = new List<BADepositDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new BADepositDetailEntity();
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
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.BudgetExpenseId = result.BudgetExpenseID.ToString();
                //newresult.BankId = result.b;
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<BADepositDetailParallelEntity> BADepositDetailParallels(List<BADepositDetailParallel> details, string refid)
        {
            List<BADepositDetailParallelEntity> lstDetailEntities = new List<BADepositDetailParallelEntity>();

            foreach (var result in details)
            {
                var newresult = new BADepositDetailParallelEntity();
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
        public List<BADepositDetailFixedAssetEntity> BADepositDetailFixedAssets(List<BADepositDetailFixedAsset> details, string refid)
        {
            List<BADepositDetailFixedAssetEntity> lstDetailEntities = new List<BADepositDetailFixedAssetEntity>();

            foreach (var result in details)
            {
                var newresult = new BADepositDetailFixedAssetEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.FixedAssetId = result.FixedAsset == null ? null : result.FixedAsset.FixedAssetID.ToString();
                newresult.Description = result.Description;
                newresult.DebitAccount = result.DebitAccount;
                newresult.CreditAccount = result.CreditAccount;
                newresult.Amount = result.Amount;
                newresult.TaxRate = result.TaxRate??0;
                newresult.TaxAmount = result.TaxAmount;
                newresult.TaxAccount = result.TaxAccount;
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
                newresult.ProjectActivityId = result.Project1==null?null: result.Project1.ProjectID.ToString();
                newresult.ProjectExpenseId = result.ProjectExpense == null ? null : result.ProjectExpense.ProjectExpenseID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.ProjectExpenseEAId = result.ProjectExpense1 == null ? null : result.ProjectExpense1.ProjectExpenseID.ToString();
                newresult.ProjectActivityEAId = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<BADepositDetailSaleEntity> BADepositDetailSales(List<BADepositDetailSale> details, string refid)
        {
            List<BADepositDetailSaleEntity> lstDetailEntities = new List<BADepositDetailSaleEntity>();

            foreach (var result in details)
            {
                var newresult = new BADepositDetailSaleEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.InventoryItemId = result.InventoryItem == null ? null : result.InventoryItem.InventoryItemID.ToString();
                newresult.Description = result.Description;
                newresult.StockId = result.Stock == null ? null : result.Stock.StockID.ToString();
                newresult.DebitAccount = result.DebitAccount;
                newresult.CreditAccount = result.CreditAccount;
                newresult.Unit = result.Unit;
                newresult.Quantity = result.Quantity;
                newresult.UnitPrice = result.UnitPrice;
                newresult.QuantityConvert = result.QuantityConvert;
                newresult.UnitPriceConvert = result.UnitPriceConvert;
                newresult.Amount = result.Amount;
                newresult.TaxRate = result.TaxRate;
                newresult.TaxAmount = result.TaxAmount;
                newresult.TaxAccount = result.TaxAccount;
                newresult.OutwardPrice = result.OutwardPrice;
                newresult.OutwardAmount = result.OutwardAmount;
                newresult.InventoryAccount = result.InventoryAccount;
                newresult.COGSAccount = result.COGSAccount;
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
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.ConfrontingRefId = result.ConfrontingRefID.ToString();
                newresult.ConfrontingRefNo = result.ConfrontingRefNo;
                newresult.ExpiryDate = result.ExpiryDate;
                newresult.LotNo = result.LotNo;
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.ProjectExpenseEAId = result.ProjectExpense1 == null ? null : result.ProjectExpense1.ProjectExpenseID.ToString();
                newresult.ProjectActivityEAId = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
                newresult.DiscountRate = result.DiscountRate;
                newresult.DiscountAmount = result.DiscountAmount;
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<BADepositDetailTaxEntity> BADepositDetailTaxes(List<BADepositDetailTax> details, string refid)
        {
            List<BADepositDetailTaxEntity> lstDetailEntities = new List<BADepositDetailTaxEntity>();

            foreach (var result in details)
            {
                var newresult = new BADepositDetailTaxEntity();
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
                newresult.AccountingObjectName = result.AccountingObjectName;
                newresult.AccountingObjectAddress = result.AccountingObjectAddress;
                newresult.CompanyTaxCode = result.CompanyTaxCode;
                newresult.SortOrder = result.SortOrder;
                newresult.InvoiceTypeCode = result.InvoiceTypeCode;
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
    }
}
