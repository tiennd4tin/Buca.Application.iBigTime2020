using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class CAReceiptEntityDao : IEntityCAReceiptDao
    {
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        private readonly ConvertCashWithdrawType ConvertCash = new ConvertCashWithdrawType();
        private List<BankInfo> banks;
        public List<CAReceiptEntity> GetCAReceipts(string connectionString)
        {
            List<CAReceiptEntity> buentity = new List<CAReceiptEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var querry = context.CAReceiptDetails.ToList();
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
                var resultcontext = context.CAReceipts.Where(x => x.RefType != 102).Where(x => x.RefType != 103).ToList();
                var fixedasset = context.FixedAssets.ToList();
                var inventoryitems = context.InventoryItems.ToList();
                var stocks = context.Stocks.ToList();
                var invoiceformnumber = context.InvoiceFormNumbers.ToList();
                //Detail
                var parallel = context.CAReceiptDetailParallels.ToList();
                var sales = context.CAReceiptDetailSales.ToList();
                var taxs = context.CAReceiptDetailTaxes.ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new CAReceiptEntity();
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
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.DocumentIncluded = result.DocumentIncluded;
                    newresult.InvType = result.InvType;
                    newresult.InvDateOrWithdrawRefDate = result.InvDateOrWithdrawRefDate;
                    newresult.InvSeries = result.InvSeries;
                    newresult.InvNoOrWithdrawRefNo = result.InvNoOrWithdrawRefNo;
                    newresult.BankId = result.BankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.BankAccount).BankInfoID.ToString();
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.TotalAmountOC = result.TotalAmountOC;
                    newresult.TotalTaxAmount = result.TotalTaxAmount;
                    newresult.TotalOutwardAmount = result.TotalOutwardAmount;
                    newresult.Posted = result.Posted;
                    newresult.RefOrder = result.RefOrder;
                    newresult.InvoiceForm = result.InvoiceForm;
                    newresult.InvoiceFormNumberId = result.InvoiceFormNumber == null ? null : result.InvoiceFormNumber.InvoiceFormNumberID.ToString();
                    newresult.InvSeriesPrefix = result.InvSeriesPrefix;
                    newresult.InvSeriesSuffix = result.InvSeriesSuffix;
                    newresult.PayForm = result.PayForm;
                    newresult.CompanyTaxcode = result.ComPanyTaxcode;
                    newresult.RelationRefId = result.RelationRefID.ToString();
                    newresult.BUCommitmentRequestId = result.BUCommitmentRequestID.ToString();
                    newresult.AccountingObjectContactName = result.AccountingObjectContactName;
                    newresult.ListNo = result.ListNo;
                    newresult.ListDate = result.ListDate;
                    newresult.IsAttachList = result.IsAttachList;
                    newresult.ListCommonNameInventory = result.ListCommonNameInventory;
                    newresult.TotalReceiptAmount = result.TotalReceiptAmount;
                    //newresult.WithdrawDate = result.WithdrawDate;
                    //newresult.WithdrawNo = result.WithdrawNo;
                    //newresult.CommitmentNo = result.CommitmentNo;
                    //newresult.BUPlanWithdrawRefId = result.BUPlanWithdrawRefID;

                    newresult.CAReceiptDetails = result.CAReceiptDetails.Count <= 0 ? null : CAReceiptDetails(result.CAReceiptDetails.ToList(), result.RefID.ToString());
                    newresult.CAReceiptDetailParallels = result.CAReceiptDetailParallels.Count <= 0 ? null : CAReceiptDetailParallels(result.CAReceiptDetailParallels.ToList(), result.RefID.ToString());
                    newresult.CAReceiptDetailTaxes = result.CAReceiptDetailTaxes.Count <= 0 ? null : CAReceiptDetailTaxes(result.CAReceiptDetailTaxes.ToList(), result.RefID.ToString());

                    buentity.Add(newresult);
                }
            }
            return buentity;
        }
        public List<CAReceiptDetailEntity> CAReceiptDetails(List<CAReceiptDetail> details, string refid)
        {
            List<CAReceiptDetailEntity> lstDetailEntities = new List<CAReceiptDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new CAReceiptDetailEntity();
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
                newresult.CashWithdrawTypeId = ConvertCash.ConvertCash(result.CashWithdrawTypeID);
                newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                newresult.ActivityId = result.Activity == null ? null : result.Activity.ActivityID.ToString();
                newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                newresult.ProjectActivityId = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
                newresult.ProjectExpenseId = result.ProjectExpense == null ? null : result.ProjectExpense.ProjectExpenseID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.OrgRefNo = result.OrgRefNo;
                newresult.OrgRefDate = result.OrgRefDate;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.BankId = result.BankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.BankAccount).BankInfoID.ToString();
                newresult.ProjectActivityEAId = result.Project2 == null ? null : result.Project2.ProjectID.ToString();
                newresult.WithdrawDetailId = result.WithdrawDetailID.ToString();
                newresult.BudgetExpenseId = result.BudgetExpenseID.ToString();
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<CAReceiptDetailParallelEntity> CAReceiptDetailParallels(List<CAReceiptDetailParallel> details, string refid)
        {
            List<CAReceiptDetailParallelEntity> lstDetailEntities = new List<CAReceiptDetailParallelEntity>();

            foreach (var result in details)
            {
                var newresult = new CAReceiptDetailParallelEntity();
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
                newresult.Approved = result.Approved ?? false;
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
        public List<CAReceiptDetailTaxEntity> CAReceiptDetailTaxes(List<CAReceiptDetailTax> details, string refid)
        {
            List<CAReceiptDetailTaxEntity> lstDetailEntities = new List<CAReceiptDetailTaxEntity>();

            foreach (var result in details)
            {
                var newresult = new CAReceiptDetailTaxEntity();
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
                newresult.SortOrder = result.SortOrder;
                newresult.InvoiceTypeCode = result.InvoiceTypeCode;
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
    }
}
