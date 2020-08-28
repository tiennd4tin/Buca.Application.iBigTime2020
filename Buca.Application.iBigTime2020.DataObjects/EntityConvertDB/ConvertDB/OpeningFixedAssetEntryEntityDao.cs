using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class OpeningFixedAssetEntryEntityDao : IEntityOpeningFixedAssetEntryDao
    {
        //private List<BankInfo> banks;
        public List<OpeningFixedAssetEntryEntity> GetOpeningFixedAssetEntrys(string connectionString)
        {
            List<OpeningFixedAssetEntryEntity> buentity = new List<OpeningFixedAssetEntryEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                //var querry = context.OpeningFixedAssetEntryDetails.ToList();
                //var projects = context.Projects.ToList();
                //var currencys = context.CCies.ToList();
                //var budgetsource = context.BudgetSources.ToList();
                //var listitems = context.ListItems.ToList();
                //var funds = context.Funds.ToList();
                //var fundstructures = context.FundStructures.ToList();
                //var budgetproviders = context.BudgetProvidences.ToList();
                //var accountingobject = context.AccountingObjects.ToList();
                //var projectexpenses = context.ProjectExpenses.ToList();
                //var activity = context.Activities.ToList();
                //var tasks = context.Tasks.ToList();
                //var topics = context.Topics.ToList();
                //banks = context.BankInfoes.ToList();
                var department = context.Departments.ToList();
                var resultcontext = context.OpeningFixedAssetEntries.ToList();
                var fixedasset = context.FixedAssets.ToList();
                //var inventoryitems = context.InventoryItems.ToList();
                //var stocks = context.Stocks.ToList();
                //var invoiceformnumber = context.InvoiceFormNumbers.ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new OpeningFixedAssetEntryEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = result.RefType;
                    newresult.PostedDate = result.PostedDate;
                    newresult.CurrencyCode = result.CurrencyID;
                    newresult.ExchangeRate = result.ExchangeRate??0;
                    newresult.FixedAssetId = result.FixedAsset == null ? null : result.FixedAsset.FixedAssetID.ToString();
                    newresult.DepartmentId = result.DepartmentID.ToString();
                    newresult.BudgetChapterCode = result.BudgetChapterCode;
                    newresult.OrgPriceAccount = result.OrgPriceAccount;
                    newresult.OrgPriceDebitAmountOC = result.OrgPriceDebitAmountOC??0;
                    newresult.OrgPriceDebitAmount = result.OrgPriceDebitAmount??0;
                    newresult.DepreciationAccount = result.DepreciationAccount;
                    newresult.DepreciationCreditAmountOC = result.DepreciationCreditAmountOC ?? 0;
                    newresult.DepreciationCreditAmount = result.DepreciationCreditAmount??0;
                    newresult.CapitalAccount = result.CapitalAccount;
                    newresult.CapitalCreditAmountOC = result.CapitalCreditAmountOC??0;
                    newresult.CapitalCreditAmount = result.CapitalCreditAmount??0;
                    //newresult.e = result.EditVersion;
                    //newresult.po = result.PostVersion;
                    newresult.SortOrder = result.SortOrder??0;
                    newresult.DevaluationCreditAmount = result.DevaluationCreditAmount??0;
                    buentity.Add(newresult);
                }
            }
            return buentity;
        }
    }
}
