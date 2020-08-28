using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;
using Buca.Application.iBigTime2020.BusinessEntities.Business.InwardOutward;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class INInwardOutwardEntityDao : IEntityINInwardOutwardDao
    {
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        private readonly ConvertCashWithdrawType ConvertCash = new ConvertCashWithdrawType();
        private List<BankInfo> banks;
        public List<INInwardOutwardEntity> GetINInwardOutwards(string connectionString)
        {
            List<INInwardOutwardEntity> buentity = new List<INInwardOutwardEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var querry = context.INInwardOutwardDetails.ToList();
                var querry2 = context.PUInvoiceDetails.ToList();
                var projects = context.Projects.ToList();
                //var currencys = context.CCies.ToList();
                var budgetsource = context.BudgetSources.ToList();
                //var listitems = context.ListItems.ToList();
                //var funds = context.Funds.ToList();
                var fundstructures = context.FundStructures.ToList();
                //var budgetproviders = context.BudgetProvidences.ToList();
                var accountingobject = context.AccountingObjects.ToList();
                var projectexpenses = context.ProjectExpenses.ToList();
                var activity = context.Activities.ToList();
                //var tasks = context.Tasks.ToList();
                var stocks = context.Stocks.ToList();
                ////var topics = context.Topics.ToList();
                //var fixedassets = context.FixedAssets.ToList();
                var departments = context.Departments.ToList();
                //var purchasepurposes = context.PurchasePurposes.ToList();
                var inventoryitems = context.InventoryItems.ToList();
                var suincrementdecrement = context.SUIncrementDecrements.ToList();
                banks = context.BankInfoes.ToList();
                var resultcontext = context.INInwardOutwards.ToList();
                //Get PuInvoice
                var resultcontext2 = context.PUInvoices.Where(x => x.RefType == 301).ToList();
                var resultcontext2Detail = context.PUInvoiceDetails.ToList();
                var resultcontext2Detailfixedassets = context.PUInvoiceDetailFixedAssets.ToList();
                //Get CAReceipts
                var resultcontext3 = context.CAReceipts.Where(x => x.RefType == 102).ToList();
                var resultcontext3sSales = context.CAReceiptDetailSales.ToList();
                //Get BADeposits
                var resultcontext4 = context.BADeposits.Where(x => x.RefType == 154).ToList();
                var resultcontext4sSales = context.BADepositDetailSales.ToList();
                //Get SAInvoices
                var resultcontext5 = context.SAInvoices.Where(x => x.RefType == 351).ToList();
                var resultcontext5Fixedasset = context.SAInvoiceDetails.ToList();
                //Get SAReturns
                var resultcontext6 = context.SAReturns.Where(x => x.RefType == 352).ToList();
                var resultcontext6Fixedasset = context.SAReturnDetails.ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new INInwardOutwardEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.TotalTaxAmount = result.TotalTaxAmount;
                    newresult.GeneratedRefId = result.SUIncrementDecrement == null ? null : result.SUIncrementDecrement.RefID.ToString();
                    newresult.RefOrder = result.RefOrder;
                    newresult.InwardOutwardDetails = result.INInwardOutwardDetails.Count <= 0 ? null : INInwardOutwardDetails(result.INInwardOutwardDetails.ToList(), result.RefID.ToString());
                    //newresult.DocumentInclued = result.Docume;
                    buentity.Add(newresult);
                }
                #region Lấy từ PuInvoice
                foreach (var result in resultcontext2)
                {
                    var newresult = new INInwardOutwardEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.TotalTaxAmount = result.TotalTaxAmount;
                    //newresult.GeneratedRefId = result.SUIncrementDecrement == null ? null : result.SUIncrementDecrement.RefID.ToString();
                    newresult.RefOrder = result.RefOrder;
                    newresult.InwardOutwardDetails = result.PUInvoiceDetails.Count <= 0 ? null : INInwardOutwardDetailsFromPUInvoiceDetails(result.PUInvoiceDetails.ToList(), result.RefID.ToString());
                    //newresult.DocumentInclued = result.Docume;
                    buentity.Add(newresult);
                }
                #endregion

                #region Lấy từ CAReceipts
                foreach (var result in resultcontext3)
                {
                    var newresult = new INInwardOutwardEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.TotalTaxAmount = result.TotalTaxAmount;
                    //newresult.GeneratedRefId = result.SUIncrementDecrement == null ? null : result.SUIncrementDecrement.RefID.ToString();
                    newresult.RefOrder = result.RefOrder;
                    newresult.InwardOutwardDetails = resultcontext3sSales.Count <= 0 ? null : INInwardOutwardDetailsFromCAReceipts(resultcontext3sSales.Where(x => x.RefID == result.RefID).ToList(), result.RefID.ToString());
                    // newresult.DocumentInclued = result.Docume;
                    buentity.Add(newresult);
                }
                #endregion

                #region Lấy từ BADeposit
                foreach (var result in resultcontext4)
                {
                    var newresult = new INInwardOutwardEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.TotalAmount = result.TotalAmountOC;
                    newresult.TotalTaxAmount = result.TotalTaxAmount;
                    //newresult.GeneratedRefId = result.SUIncrementDecrement == null ? null : result.SUIncrementDecrement.RefID.ToString();
                    newresult.RefOrder = result.RefOrder;
                    newresult.InwardOutwardDetails = result.BADepositDetailSales.Count <= 0 ? null : INInwardOutwardDetailsFromBADeposits(result.BADepositDetailSales.ToList(), result.RefID.ToString());
                    // newresult.DocumentInclued = result.Docume;
                    buentity.Add(newresult);
                }
                #endregion

                #region Lấy từ SAInvoices
                foreach (var result in resultcontext5)
                {
                    var newresult = new INInwardOutwardEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.TotalTaxAmount = result.TotalTaxAmount;
                    //newresult.GeneratedRefId = result.SUIncrementDecrement == null ? null : result.SUIncrementDecrement.RefID.ToString();
                    newresult.RefOrder = result.RefOrder;
                    newresult.InwardOutwardDetails = result.SAInvoiceDetails.Count <= 0 ? null : INInwardOutwardDetailsFromSAInvoices(result.SAInvoiceDetails.ToList(), result.RefID.ToString());
                    // newresult.DocumentInclued = result.Docume;
                    buentity.Add(newresult);
                }
                #endregion

                #region Lấy từ SAReturns
                foreach (var result in resultcontext6)
                {
                    var newresult = new INInwardOutwardEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.TotalTaxAmount = result.TotalTaxAmount;
                    //newresult.GeneratedRefId = result.SUIncrementDecrement == null ? null : result.SUIncrementDecrement.RefID.ToString();
                    newresult.RefOrder = result.RefOrder;
                    newresult.InwardOutwardDetails = result.SAReturnDetails.Count <= 0 ? null : INInwardOutwardDetailsFromSAReturns(result.SAReturnDetails.ToList(), result.RefID.ToString());
                    // newresult.DocumentInclued = result.Docume;
                    buentity.Add(newresult);
                }
                #endregion
            }
            return buentity.OrderBy(x => x.RefDate).ToList();
        }

        public List<INInwardOutwardDetailEntity> INInwardOutwardDetails(List<INInwardOutwardDetail> details, string refid)
        {
            List<INInwardOutwardDetailEntity> lstDetailEntities = new List<INInwardOutwardDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new INInwardOutwardDetailEntity();

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
                newresult.OutwardPurpose = result.OutwardPurpose;
                newresult.TaxRate = result.TaxRate;
                newresult.TaxAmount = result.TaxAmount;
                newresult.InwardAmount = result.InwardAmount;
                newresult.BudgetSourceId = result.BudgetSource == null ? null : result.BudgetSource.BudgetSourceID.ToString();
                newresult.BudgetChapterCode = result.BudgetChapterCode;
                newresult.BudgetKindItemCode = result.BudgetKindItemCode;
                newresult.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                newresult.BudgetItemCode = result.BudgetItemCode;
                newresult.BudgetSubItemCode = result.BudgetSubItemCode;
                newresult.MethodDistributeId = result.MethodDistributeID;
                newresult.CashWithDrawTypeId = ConvertCash.ConvertCash(result.CashWithDrawTypeID);
                newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                newresult.DepartmentId = result.Department == null ? null : result.Department.DepartmentID.ToString();
                newresult.ActivityId = result.Activity == null ? null : result.Activity.ActivityID.ToString();
                newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                newresult.ProjectActivityId = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.ConfrontingRefId = result.ConfrontingRefID.ToString();
                newresult.ConfrontingRefNo = result.ConfrontingRefNo;
                newresult.ExpiryDate = result.ExpiryDate;
                newresult.LotNo = result.LotNo;
                newresult.Approved = result.Approved;
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
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
        public List<INInwardOutwardDetailEntity> INInwardOutwardDetailsFromPUInvoiceDetails(List<PUInvoiceDetail> details, string refid)
        {
            List<INInwardOutwardDetailEntity> lstDetailEntities = new List<INInwardOutwardDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new INInwardOutwardDetailEntity();

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
                newresult.OutwardPurpose = 0;
                newresult.TaxRate = result.TaxRate;
                newresult.TaxAmount = result.TaxAmount;
                newresult.InwardAmount = result.InwardAmount;
                newresult.BudgetSourceId = result.BudgetSource == null ? null : result.BudgetSource.BudgetSourceID.ToString();
                newresult.BudgetChapterCode = result.BudgetChapterCode;
                newresult.BudgetKindItemCode = result.BudgetKindItemCode;
                newresult.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                newresult.BudgetItemCode = result.BudgetItemCode;
                newresult.BudgetSubItemCode = result.BudgetSubItemCode;
                newresult.MethodDistributeId = result.MethodDistributeID;
                newresult.CashWithDrawTypeId = ConvertCash.ConvertCash(result.CashWithDrawTypeID);
                newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                //newresult.DepartmentId = result.Department == null ? null : result.Department.DepartmentID.ToString();
                newresult.ActivityId = result.Activity == null ? null : result.Activity.ActivityID.ToString();
                newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                newresult.ProjectActivityId = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                //newresult.ConfrontingRefId = result.ConfrontingRefID.ToString();
                //newresult.ConfrontingRefNo = result.ConfrontingRefNo;
                newresult.ExpiryDate = result.ExpiryDate;
                newresult.LotNo = result.LotNo;
                newresult.Approved = result.Approved;
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.OrgRefNo = result.OrgRefNo;
                newresult.OrgRefDate = result.OrgRefDate;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                //newresult.BankId = result.BankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.BankAccount).BankInfoID.ToString();
                newresult.ProjectActivityEAId = result.Project2 == null ? null : result.Project2.ProjectID.ToString();
                //newresult.BudgetExpenseId = result.budgete;

                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<INInwardOutwardDetailEntity> INInwardOutwardDetailsFromCAReceipts(List<CAReceiptDetailSale> details, string refid)
        {
            List<INInwardOutwardDetailEntity> lstDetailEntities = new List<INInwardOutwardDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new INInwardOutwardDetailEntity();

                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.InventoryItemId = result.InventoryItemID.ToString();
                newresult.Description = result.Description;
                newresult.StockId = result.StockID.ToString();
                newresult.DebitAccount = result.DebitAccount;
                newresult.CreditAccount = result.CreditAccount;
                newresult.Unit = result.Unit;
                newresult.Quantity = result.Quantity;
                newresult.QuantityConvert = result.QuantityConvert;
                newresult.UnitPrice = result.UnitPrice;
                newresult.UnitPriceConvert = result.UnitPriceConvert;
                newresult.Amount = result.Amount;
                newresult.OutwardPurpose = 0;
                newresult.TaxRate = result.TaxRate;
                newresult.TaxAmount = result.TaxAmount;
                newresult.InwardAmount = result.OutwardAmount;
                newresult.BudgetSourceId = result.BudgetSourceID.ToString();
                newresult.BudgetChapterCode = result.BudgetChapterCode;
                newresult.BudgetKindItemCode = result.BudgetKindItemCode;
                newresult.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                newresult.BudgetItemCode = result.BudgetItemCode;
                newresult.BudgetSubItemCode = result.BudgetSubItemCode;
                newresult.MethodDistributeId = result.MethodDistributeID;
                newresult.CashWithDrawTypeId = ConvertCash.ConvertCash(result.CashWithdrawTypeID);
                newresult.AccountingObjectId = result.AccountingObjectID.ToString();
                //newresult.DepartmentId = result.Department == null ? null : result.Department.DepartmentID.ToString();
                newresult.ActivityId = result.ActivityID.ToString();
                newresult.ProjectId = result.ProjectID.ToString();
                newresult.ProjectActivityId = result.ProjectActivityID.ToString();
                newresult.ListItemId = result.ListItemID.ToString();
                newresult.ConfrontingRefId = result.ConfrontingRefID.ToString();
                newresult.ConfrontingRefNo = result.ConfrontingRefNo;
                newresult.ExpiryDate = result.ExpiryDate;
                newresult.LotNo = result.LotNo;
               // newresult.Approved = result.Approved;
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                //newresult.OrgRefNo = result.OrgRefNo;
                //newresult.OrgRefDate = result.OrgRefDate;
                newresult.FundStructureId = result.FundStructureID.ToString();
                //newresult.BankId = result.BankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.BankAccount).BankInfoID.ToString();
                newresult.ProjectActivityEAId = result.ProjectActivityEAID.ToString();
                //newresult.BudgetExpenseId = result.budgete;

                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<INInwardOutwardDetailEntity> INInwardOutwardDetailsFromBADeposits(List<BADepositDetailSale> details, string refid)
        {
            List<INInwardOutwardDetailEntity> lstDetailEntities = new List<INInwardOutwardDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new INInwardOutwardDetailEntity();

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
                newresult.OutwardPurpose = 0;
                newresult.TaxRate = result.TaxRate;
                newresult.TaxAmount = result.TaxAmount;
                newresult.InwardAmount = result.OutwardAmount;
                newresult.BudgetSourceId = result.BudgetSource == null ? null : result.BudgetSource.BudgetSourceID.ToString();
                newresult.BudgetChapterCode = result.BudgetChapterCode;
                newresult.BudgetKindItemCode = result.BudgetKindItemCode;
                newresult.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                newresult.BudgetItemCode = result.BudgetItemCode;
                newresult.BudgetSubItemCode = result.BudgetSubItemCode;
                newresult.MethodDistributeId = result.MethodDistributeID;
                newresult.CashWithDrawTypeId = ConvertCash.ConvertCash(result.CashWithdrawTypeID);
                newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                //newresult.DepartmentId = result.Department == null ? null : result.Department.DepartmentID.ToString();
                newresult.ActivityId = result.Activity == null ? null : result.Activity.ActivityID.ToString();
                newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                newresult.ProjectActivityId = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.ConfrontingRefId = result.ConfrontingRefID.ToString();
                newresult.ConfrontingRefNo = result.ConfrontingRefNo;
                newresult.ExpiryDate = result.ExpiryDate;
                newresult.LotNo = result.LotNo;
                //newresult.Approved = result.Approved;
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                //newresult.OrgRefNo = result.OrgRefNo;
                //newresult.OrgRefDate = result.OrgRefDate;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                //newresult.BankId = result.BankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.BankAccount).BankInfoID.ToString();
                newresult.ProjectActivityEAId = result.Project2 == null ? null : result.Project2.ProjectID.ToString();
                //newresult.BudgetExpenseId = result.budgete;

                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<INInwardOutwardDetailEntity> INInwardOutwardDetailsFromSAInvoices(List<SAInvoiceDetail> details, string refid)
        {
            List<INInwardOutwardDetailEntity> lstDetailEntities = new List<INInwardOutwardDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new INInwardOutwardDetailEntity();

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
                newresult.OutwardPurpose = 0;
                newresult.TaxRate = result.TaxRate;
                newresult.TaxAmount = result.TaxAmount;
                newresult.InwardAmount = result.OutwardAmount;
                newresult.BudgetSourceId = result.BudgetSource == null ? null : result.BudgetSource.BudgetSourceID.ToString();
                newresult.BudgetChapterCode = result.BudgetChapterCode;
                newresult.BudgetKindItemCode = result.BudgetKindItemCode;
                newresult.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                newresult.BudgetItemCode = result.BudgetItemCode;
                newresult.BudgetSubItemCode = result.BudgetSubItemCode;
                newresult.MethodDistributeId = result.MethodDistributeID;
                newresult.CashWithDrawTypeId = ConvertCash.ConvertCash(result.CashWithDrawTypeID);
                newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                //newresult.DepartmentId = result.Department == null ? null : result.Department.DepartmentID.ToString();
                newresult.ActivityId = result.Activity == null ? null : result.Activity.ActivityID.ToString();
                newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                newresult.ProjectActivityId = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.ConfrontingRefId = result.ConfrontingRefID.ToString();
                newresult.ConfrontingRefNo = result.ConfrontingRefNo;
                newresult.ExpiryDate = result.ExpiryDate;
                newresult.LotNo = result.LotNo;
                //newresult.Approved = result.Approved;
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                //newresult.OrgRefNo = result.OrgRefNo;
                //newresult.OrgRefDate = result.OrgRefDate;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                //newresult.BankId = result.BankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.BankAccount).BankInfoID.ToString();
                newresult.ProjectActivityEAId = result.Project2 == null ? null : result.Project2.ProjectID.ToString();
                //newresult.BudgetExpenseId = result.budgete;

                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<INInwardOutwardDetailEntity> INInwardOutwardDetailsFromSAReturns(List<SAReturnDetail> details, string refid)
        {
            List<INInwardOutwardDetailEntity> lstDetailEntities = new List<INInwardOutwardDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new INInwardOutwardDetailEntity();

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
                newresult.OutwardPurpose = 0;
                newresult.TaxRate = result.TaxRate;
                newresult.TaxAmount = result.TaxAmount;
                newresult.InwardAmount = result.InwardAmount;
                newresult.BudgetSourceId = result.BudgetSource == null ? null : result.BudgetSource.BudgetSourceID.ToString();
                newresult.BudgetChapterCode = result.BudgetChapterCode;
                newresult.BudgetKindItemCode = result.BudgetKindItemCode;
                newresult.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                newresult.BudgetItemCode = result.BudgetItemCode;
                newresult.BudgetSubItemCode = result.BudgetSubItemCode;
                newresult.MethodDistributeId = result.MethodDistributeID;
                newresult.CashWithDrawTypeId = ConvertCash.ConvertCash(result.CashWithDrawTypeID);
                newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                //newresult.DepartmentId = result.Department == null ? null : result.Department.DepartmentID.ToString();
                newresult.ActivityId = result.Activity == null ? null : result.Activity.ActivityID.ToString();
                newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                newresult.ProjectActivityId = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                //newresult.ConfrontingRefId = result.ConfrontingRefID.ToString();
                //newresult.ConfrontingRefNo = result.ConfrontingRefNo;
                newresult.ExpiryDate = result.ExpiryDate;
                newresult.LotNo = result.LotNo;
                //newresult.Approved = result.Approved;
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                //newresult.OrgRefNo = result.OrgRefNo;
                //newresult.OrgRefDate = result.OrgRefDate;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                //newresult.BankId = result.BankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.BankAccount).BankInfoID.ToString();
                newresult.ProjectActivityEAId = result.Project2 == null ? null : result.Project2.ProjectID.ToString();
                //newresult.BudgetExpenseId = result.budgete;

                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
    }
}
