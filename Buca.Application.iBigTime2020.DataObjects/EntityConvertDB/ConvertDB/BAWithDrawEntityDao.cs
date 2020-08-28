using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class BAWithDrawEntityDao : IEntityBAWithDrawDao
    {
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        private readonly ConvertCashWithdrawType ConvertCash = new ConvertCashWithdrawType();
        private List<BankInfo> banks;
        public List<BAWithDrawEntity> GetBAWithDraws(string connectionString)
        {
            List<BAWithDrawEntity> buentity = new List<BAWithDrawEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var querry = context.BAWithDrawDetails.ToList();
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
                var detailfixedassets = context.BAWithDrawDetailFixedAssets.ToList();
                var detailparallels = context.BAWithDrawDetailParallels.ToList();
                var detailpurchases = context.BAWithDrawDetailPurchases.ToList();
                var detailtax = context.BAWithdrawDetailTaxes.ToList();
                var resultcontext = context.BAWithDraws.ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new BAWithDrawEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.CurrencyCode = result.CCY == null ? null : result.CCY.CurrencyID;
                    newresult.ExchangeRate = result.ExchangeRate ?? 0;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.InwardRefNo = result.InwardRefNo;
                    newresult.IncrementRefNo = result.IncrementRefNo;
                    newresult.BankId = result.BankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.BankAccount).BankInfoID.ToString();
                    newresult.BankName = result.BankName;
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.TotalAmountOC = result.TotalAmountOC;
                    newresult.TotalTaxAmount = result.TotalTaxAmount;
                    newresult.TotalFreightAmount = result.TotalFreightAmount;
                    newresult.TotalInwardAmount = result.TotalInwardAmount;
                    newresult.Reconciled = result.Reconciled;
                    newresult.Posted = result.Posted;
                    newresult.PostVersion = result.PostVersion;
                    newresult.EditVersion = result.EditVersion;
                    newresult.RefOrder = result.RefOrder;
                    newresult.RelationRefId = result.RelationRefID.ToString();
                    newresult.TotalPaymentAmount = result.TotalPaymentAmount;
                    newresult.BAWithDrawDetails = result.BAWithDrawDetails.Count <= 0 ? null : BAWithDrawDetails(result.BAWithDrawDetails.ToList(), result.RefID.ToString());
                    newresult.BAWithDrawDetailFixedAssets = result.BAWithDrawDetailFixedAssets.Count <= 0 ? null : BAWithDrawDetailFixedAssets(result.BAWithDrawDetailFixedAssets.ToList(), result.RefID.ToString());
                    newresult.BAWithDrawDetailParallels = result.BAWithDrawDetailParallels.Count <= 0 ? null : BAWithDrawDetailParallels(result.BAWithDrawDetailParallels.ToList(), result.RefID.ToString());
                    newresult.BAWithDrawDetailPurchases = result.BAWithDrawDetailPurchases.Count <= 0 ? null : BAWithDrawDetailPurchases(result.BAWithDrawDetailPurchases.ToList(), result.RefID.ToString());
                    newresult.BAWithdrawDetailTaxs = result.BAWithdrawDetailTaxes.Count <= 0 ? null : BAWithdrawDetailTaxs(result.BAWithdrawDetailTaxes.ToList(), result.RefID.ToString());
                    buentity.Add(newresult);
                }
            }
            return buentity;
        }

        public List<BAWithDrawDetailEntity> BAWithDrawDetails(List<BAWithDrawDetail> details, string refid)
        {
            List<BAWithDrawDetailEntity> lstDetailEntities = new List<BAWithDrawDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new BAWithDrawDetailEntity();
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
                newresult.FundId = result.FundID.ToString();
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.OrgRefNo = result.OrgRefNo;
                newresult.OrgRefDate = result.OrgRefDate;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.ProjectActivityEAId = result.Project2 == null ? null : result.Project2.ProjectID.ToString();
                newresult.BudgetExpenseId = result.ProjectExpense1 == null ? null : result.ProjectExpense1.ProjectExpenseID.ToString();
                //newresult.BankId = result.ban;
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<BAWithDrawDetailFixedAssetEntity> BAWithDrawDetailFixedAssets(List<BAWithDrawDetailFixedAsset> details, string refid)
        {
            List<BAWithDrawDetailFixedAssetEntity> lstDetailEntities = new List<BAWithDrawDetailFixedAssetEntity>();

            foreach (var result in details)
            {
                var newresult = new BAWithDrawDetailFixedAssetEntity();
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
                newresult.FundId = result.FundID.ToString();
                newresult.ProjectActivityId = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.InvoiceTypeCode = result.InvoiceTypeCode;
                newresult.OrgRefNo = result.OrgRefNo;
                newresult.OrgRefDate = result.OrgRefDate;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.BankId = result.BankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.BankAccount).BankInfoID.ToString();
                newresult.ProjectActivityEAId = result.Project2 == null ? null : result.Project2.ProjectID.ToString();
                //newresult.BudgetExpenseId = result.budgete;

                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<BAWithDrawDetailParallelEntity> BAWithDrawDetailParallels(List<BAWithDrawDetailParallel> details, string refid)
        {
            List<BAWithDrawDetailParallelEntity> lstDetailEntities = new List<BAWithDrawDetailParallelEntity>();

            foreach (var result in details)
            {
                var newresult = new BAWithDrawDetailParallelEntity();
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
                newresult.TaskId = result.Task == null ? null : result.Task.TaskID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.FundId = result.Fund == null ? null : result.Fund.FundID.ToString();
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
        public List<BAWithDrawDetailPurchaseEntity> BAWithDrawDetailPurchases(List<BAWithDrawDetailPurchase> details, string refid)
        {
            List<BAWithDrawDetailPurchaseEntity> lstDetailEntities = new List<BAWithDrawDetailPurchaseEntity>();

            foreach (var result in details)
            {
                var newresult = new BAWithDrawDetailPurchaseEntity();
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
                newresult.InvType = result.InvType;
                newresult.InvDate = result.InvDate;
                newresult.InvSeries = result.InvSeries;
                newresult.InvNo = result.InvNo;
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
                newresult.FundId = result.FundID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.ExpiryDate = result.ExpiryDate;
                newresult.LotNo = result.LotNo;
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.InvoiceTypeCode = result.InvoiceTypeCode;
                newresult.OrgRefNo = result.OrgRefNo;
                newresult.OrgRefDate = result.OrgRefDate;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.ProjectActivityEAId = result.Project2 == null ? null : result.Project2.ProjectID.ToString();
                //newresult.BudgetExpenseId = result.BudgetExpens;
                //newresult.BankID = result.bank;
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<BAWithdrawDetailTaxEntity> BAWithdrawDetailTaxs(List<BAWithdrawDetailTax> details, string refid)
        {
            List<BAWithdrawDetailTaxEntity> lstDetailEntities = new List<BAWithdrawDetailTaxEntity>();

            foreach (var result in details)
            {
                var newresult = new BAWithdrawDetailTaxEntity();
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
