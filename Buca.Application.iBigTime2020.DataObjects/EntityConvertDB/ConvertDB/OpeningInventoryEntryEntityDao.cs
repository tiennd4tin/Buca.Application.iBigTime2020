using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class OpeningInventoryEntryEntityDao : IEntityOpeningInventoryEntryDao
    {
        public List<OpeningInventoryEntryEntity> GetOpeningInventoryEntrys(string connectionString)
        {
            List<OpeningInventoryEntryEntity> buentity = new List<OpeningInventoryEntryEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                //var querry = context.OpeningInventoryEntryDetails.ToList();
                //var projects = context.Projects.ToList();
                //var currencys = context.CCies.ToList();
                var budgetsource = context.BudgetSources.ToList();
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
                //var department = context.Departments.ToList();
                var resultcontext = context.OpeningInventoryEntries.ToList();
                var fixedasset = context.FixedAssets.ToList();
                var inventoryitems = context.InventoryItems.ToList();
                //var stocks = context.Stocks.ToList();
                //var invoiceformnumber = context.InvoiceFormNumbers.ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new OpeningInventoryEntryEntity();

                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = result.RefType;
                    newresult.PostedDate = result.PostedDate;
                    newresult.CurrencyCode = result.CurrencyID;
                    newresult.ExchangeRate = result.ExchangeRate ?? 0;
                    newresult.AccountNumber = result.AccountNumber;
                    newresult.InventoryItemId = result.InventoryItem == null ? null : result.InventoryItem.InventoryItemID.ToString();
                    newresult.StockId = result.StockID.ToString();
                    newresult.BudgetSourceId = result.BudgetSource == null ? null : result.BudgetSource.BudgetSourceID.ToString();
                    newresult.BudgetChapterCode = result.BudgetChapterCode;
                   // newresult.BudgetKindItemCode = result;
                    //newresult.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                    //newresult.BudgetItemCode = result.BudgetItemCode;
                    //newresult.BudgetSubItemCode = result.BudgetSubItemCode;
                    newresult.Quantity = result.Quantity??0;
                    newresult.UnitPriceOC = result.UnitPrice ?? 0;
                    newresult.UnitPrice = result.UnitPrice??0;
                    newresult.AmountOC = result.Amount;
                    newresult.Amount = result.Amount;
                    newresult.ExpiryDate = result.ExpiryDate??DateTime.Now;
                    newresult.LotNo = result.LotNo;
                    newresult.PostVersion = result.PostVersion??0;
                    newresult.EditVersion = result.EditVersion??0;
                    newresult.SortOrder = result.SortOrder??0;
                    newresult.RefOrder = result.RefOrder??0;
                    //newresult.cre = result.CreateDate;
                    buentity.Add(newresult);
                }
            }
            return buentity;
        }
    }
}
