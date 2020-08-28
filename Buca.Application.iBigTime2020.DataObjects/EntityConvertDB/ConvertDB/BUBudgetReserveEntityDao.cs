using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class BUBudgetReserveEntityDao: IEntityBUBudgetReserveDao
    {
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        private readonly ConvertCashWithdrawType ConvertCash = new ConvertCashWithdrawType();
        private List<BankInfo> banks;
        public List<BUBudgetReserveEntity> GetBUBudgetReserves(string connectionString)
        {
            List<BUBudgetReserveEntity> buentity = new List<BUBudgetReserveEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var querry = context.BUBudgetReserveDetails.ToList();
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
                var resultcontext = context.BUBudgetReserves.ToList();
                var fixedasset = context.FixedAssets.ToList();
                var inventoryitems = context.InventoryItems.ToList();
                var stocks = context.Stocks.ToList();
                var invoiceformnumber = context.InvoiceFormNumbers.ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new BUBudgetReserveEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.BudgetChapterCode = result.BudgetChapterCode;
                    newresult.BudgetChapterName = result.BudgetChapterName;
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.CurrencyCode = result.CCY == null ? null : result.CCY.CurrencyID;
                    newresult.ExchangeRate = result.ExchangeRate;
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.TotalAmountOC = result.TotalAmountOC;
                    newresult.Posted = result.Posted;
                    newresult.EditVersion = result.EditVersion;
                    newresult.PostVersion = result.PostVersion;
                    newresult.BudgetReserveDetails = result.BUBudgetReserveDetails.Count <= 0 ? null : BUBudgetReserveDetails(result.BUBudgetReserveDetails.ToList(), result.RefID.ToString());
                    
                    buentity.Add(newresult);
                }
            }
            return buentity;
        }
        public List<BUBudgetReserveDetailEntity> BUBudgetReserveDetails(List<BUBudgetReserveDetail> details, string refid)
        {
            List<BUBudgetReserveDetailEntity> lstDetailEntities = new List<BUBudgetReserveDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new BUBudgetReserveDetailEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.Description = result.Description;
                newresult.Amount = result.Amount;
                newresult.AmountOC = result.AmountOC;
                newresult.BudgetSourceId = result.BudgetSource == null ? null : result.BudgetSource.BudgetSourceID.ToString();
                newresult.BudgetKindItemCode = result.BudgetKindItemCode;
                newresult.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                newresult.BudgetItemCode = result.BudgetItemCode;
                newresult.BudgetSubItemCode = result.BudgetSubItemCode;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.MethodDistributeId = result.MethodDistributeID;
                newresult.CashWithDrawTypeId = ConvertCash.ConvertCash(result.CashWithDrawTypeID);
                newresult.ActivityId = result.Activity == null ? null : result.Activity.ActivityID.ToString();
                newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                newresult.ProjectActivityId = result.ProjectActivityID.ToString();
                newresult.ProjectExpenseId = result.ProjectExpense == null ? null : result.ProjectExpense.ProjectExpenseID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.Approved = result.Approved;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetGroupItemCode = result.BudgetGroupItemCode;
                newresult.BankAccount = result.BankAccount;
                newresult.BudgetProvideCode = result.BudgetProvidence == null ? null : result.BudgetProvidence.BudgetProvideCode;
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
    }
}
