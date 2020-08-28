using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class OpeningAccountEntryEntityDao : IEntityOpeningAccountEntryDao
    {
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        private readonly ConvertCashWithdrawType ConvertCash = new ConvertCashWithdrawType();
        private List<BankInfo> banks;
        public IList<OpeningAccountEntryEntity> GetOpeningAccountEntrys(string connectionString, List<CurrencyEntity> currency)
        {
            List<OpeningAccountEntryEntity> buentity = new List<OpeningAccountEntryEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                //var querry = context.OpeningAccountEntries.ToList();
                var projects = context.Projects.ToList();
                //var currencys = context.CCies.ToList();
                var budgetsource = context.BudgetSources.ToList();
                //var listitems = context.ListItems.ToList();
                //var funds = context.Funds.ToList();
                var fundstructures = context.FundStructures.ToList();
                var budgetproviders = context.BudgetProvidences.ToList();
                var accountingobject = context.AccountingObjects.ToList();
                //var projectexpenses = context.ProjectExpenses.ToList();
                var activity = context.Activities.ToList();
                //var tasks = context.Tasks.ToList();
                //var topics = context.Topics.ToList();
                banks = context.BankInfoes.ToList();
                //var department = context.Departments.ToList();
                var resultcontext = context.OpeningAccountEntries.ToList();
                //var fixedasset = context.FixedAssets.ToList();
                //var inventoryitems = context.InventoryItems.ToList();
               // var stocks = context.Stocks.ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new OpeningAccountEntryEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.PostedDate = result.PostedDate ?? DateTime.Now;
                    newresult.CurrencyId = currency == null || string.IsNullOrEmpty(result.CurrencyID) ? null : currency.FirstOrDefault(c=>c.CurrencyCode == result.CurrencyID).CurrencyId;
                    newresult.ExchangeRate = result.ExchangeRate??0;
                    newresult.AccountNumber = result.AccountNumber;
                    newresult.AccBeginningDebitAmountOC = result.AccBeginningDebitAmountOC;
                    newresult.AccBeginningDebitAmount = result.AccBeginningDebitAmount;
                    newresult.AccBeginningCreditAmountOC = result.AccBeginningCreditAmountOC;
                    newresult.AccBeginningCreditAmount = result.AccBeginningCreditAmount;
                    newresult.DebitAmountOC = result.DebitAmountOC;
                    newresult.DebitAmount = result.DebitAmount;
                    newresult.CreditAmountOC = result.CreditAmountOC;
                    newresult.CreditAmount = result.CreditAmount;
                    newresult.BudgetSourceId = result.BudgetSource == null ? null : result.BudgetSource.BudgetSourceID.ToString();
                    newresult.BudgetChapterCode = result.BudgetChapterCode;
                    newresult.BudgetKindItemCode = result.BudgetKindItemCode;
                    newresult.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                    newresult.BudgetItemCode = result.BudgetItemCode;
                    newresult.BudgetSubItemCode = result.BudgetSubItemCode;
                    newresult.MethodDistributeId = result.MethodDistributeID??0;
                    newresult.CashWithdrawTypeId = ConvertCash.ConvertCash(result.CashWithdrawTypeID);
                    newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                    newresult.ActivityId = result.Activity == null ? null : result.Activity.ActivityID.ToString();
                    newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                    newresult.TaskId = result.TaskID.ToString();
                    //newresult.BankId = result.ba;
                    newresult.Approved = result.Approved??true;
                    newresult.SortOrder = result.SortOrder??0;
                    newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                    newresult.ProjectActivityId = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
                    newresult.ApprovedDate = result.ApprovedDate ?? DateTime.Now;
                    newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                    newresult.ProjectActivityEAID = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
                    newresult.BudgetProvideCode = result.BudgetProvidence == null ? null : result.BudgetProvidence.BudgetProvideCode;
                    //newresult.BudgetExpenseId = result.BudgetExpense;
                    buentity.Add(newresult);
                }
            }
            return buentity;
        }
    }
}
