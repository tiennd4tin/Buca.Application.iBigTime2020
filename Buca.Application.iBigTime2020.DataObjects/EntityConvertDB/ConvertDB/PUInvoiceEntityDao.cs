using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.PUInvoice;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class PUInvoiceEntityDao: IEntityPUInvoiceDao
    {
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        private readonly ConvertCashWithdrawType ConvertCash = new ConvertCashWithdrawType();
        //private List<BankInfo> banks;
        public List<PUInvoiceEntity> GetPUInvoices(string connectionString)
        {
            List<PUInvoiceEntity> buentity = new List<PUInvoiceEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var querry = context.PUInvoiceDetails.ToList();
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
                //var stocks = context.Stocks.ToList();
                var topics = context.Topics.ToList();
                var fixedassets = context.FixedAssets.ToList();
                var departments = context.Departments.ToList();
                var purchasepurposes = context.PurchasePurposes.ToList();
                //var inventoryitems = context.InventoryItems.ToList();
                //banks = context.BankInfoes.ToList();
                var detailfixedassets = context.PUInvoiceDetailFixedAssets.ToList();
                var resultcontext = context.PUInvoices.Where(x => x.RefType != 301).ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new PUInvoiceEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.InwardRefNo = result.InwardRefNo;
                    newresult.IncrementRefNo = result.IncrementRefNo;
                    newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                    newresult.AccountingObjectName = result.AccountingObjectName;
                    newresult.AccountingObjectAddress = result.AccountingObjectAddress;
                    newresult.CompanyTaxCode = result.CompanyTaxCode;
                    newresult.AccountingObjectContactName = result.AccountingObjectContactName;
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.TotalTaxAmount = result.TotalTaxAmount;
                    newresult.TotalFreightAmount = result.TotalFreightAmount;
                    newresult.TotalInwardAmount = result.TotalInwardAmount;
                    newresult.Posted = result.Posted;
                    newresult.PostVersion = result.PostVersion??0;
                    newresult.EditVersion = result.EditVersion??0;
                    newresult.RefOrder = result.RefOrder??0;
                    newresult.TotalFixedAssetAmount = result.TotalFixedAssetAmount;
                    newresult.FARefOrder = result.FARefOrder;
                    //newresult.CurrencyCode = result.cuu;
                    //newresult.ExchangeRate = result.ex;
                    //newresult.TotalAmountOC = result.to;
                    newresult.PUInvoiceDetailFixedAssets = result.PUInvoiceDetailFixedAssets.Count <= 0 ? null : PUInvoiceDetailFixedAssets(result.PUInvoiceDetailFixedAssets.ToList(), result.RefID.ToString());
                    buentity.Add(newresult);
                }
            }
            return buentity;//Bỏ chứng từ hóa đơn mua hàng
        }
        public List<PUInvoiceDetailFixedAssetEntity> PUInvoiceDetailFixedAssets(List<PUInvoiceDetailFixedAsset> details, string refid)
        {
            List<PUInvoiceDetailFixedAssetEntity> lstDetailEntities = new List<PUInvoiceDetailFixedAssetEntity>();

            foreach (var result in details)
            {
                var newresult = new PUInvoiceDetailFixedAssetEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.FixedAssetId = result.FixedAsset == null ? null : result.FixedAsset.FixedAssetID.ToString();
                newresult.Description = result.Description;
                newresult.DepartmentId = result.Department == null ? null : result.Department.DepartmentID.ToString();
                newresult.DebitAccount = result.DebitAccount;
                newresult.CreditAccount = result.CreditAccount;
                newresult.Amount = result.Amount;
                newresult.TaxRate = result.TaxRate??0;
                newresult.TaxAmount = result.TaxAmount;
                newresult.TaxAccount = result.TaxAccount;
                newresult.InvDate = result.InvDate;
                newresult.InvSeries = result.InvSeries;
                newresult.InvNo = result.InvNo;
                newresult.InvType = result.InvType??0;
                newresult.InvoiceTypeCode = result.InvoiceTypeCode;
                newresult.PurchasePurposeId = result.PurchasePurpose == null ? null : result.PurchasePurpose.PurchasePurposeID.ToString();
                newresult.FreightAmount = result.FreightAmount;
                newresult.OrgPrice = result.OrgPrice;
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
                newresult.ProjectExpenseId = result.ProjectExpense==null?null:result.ProjectExpense.ProjectExpenseID.ToString();
                newresult.TaskId = result.Task == null ? null : result.Task.TaskID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.Approved = result.Approved;
                newresult.SortOrder = result.SortOrder??0;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.OrgRefNo = result.OrgRefNo;
                newresult.OrgRefDate = result.OrgRefDate;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.BankAccount = result.BankAccount;
                newresult.ProjectExpenseEAId = result.ProjectExpense1==null?null:result.ProjectExpense1.ProjectExpenseID.ToString();
                newresult.ProjectActivityEAId = result.Project2 == null ? null : result.Project2.ProjectID.ToString();
                newresult.BudgetProvIdeCode = result.BudgetProvidence == null ? null : result.BudgetProvidence.BudgetProvideCode;
                newresult.TopicId = result.Topic == null ? null : result.Topic.TopicID.ToString();
                //newresult.BudgetExpenseId = result.budgete;
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }

    }
}
