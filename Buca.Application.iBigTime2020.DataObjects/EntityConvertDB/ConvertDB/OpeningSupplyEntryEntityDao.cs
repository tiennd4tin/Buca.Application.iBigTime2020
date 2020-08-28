using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class OpeningSupplyEntryEntityDao : IEntityOpeningSupplyEntryDao
    {
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        //private List<BankInfo> banks;
        public List<OpeningSupplyEntryEntity> GetOpeningSupplyEntrys(string connectionString)
        {
            List<OpeningSupplyEntryEntity> buentity = new List<OpeningSupplyEntryEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var inventoryitems = context.InventoryItems.ToList();
                //banks = context.BankInfoes.ToList();
                var resultcontext = context.OpeningSupplyEntries.ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new OpeningSupplyEntryEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.PostedDate = result.PostedDate;
                    newresult.CurrencyCode = result.CurrencyID;
                    newresult.ExchangeRate = result.ExchangeRate ?? 0;
                    newresult.AccountNumber = result.AccountNumber;
                    newresult.InventoryItemId = result.InventoryItem == null ? null : result.InventoryItem.InventoryItemID.ToString();
                    newresult.InventoryItemCode = result.InventoryItem == null ? null : result.InventoryItem.InventoryItemCode;
                    newresult.InventoryItemName = result.InventoryItem == null ? null : result.InventoryItem.InventoryItemName;
                    newresult.DepartmentId = result.DepartmentID.ToString();
                    newresult.BudgetChapterCode = result.BudgetChapterCode;
                    newresult.Quantity = result.Quantity??0;
                    newresult.UnitPriceOC = result.UnitPriceOC??0;
                    newresult.UnitPrice = result.UnitPrice ?? 0;
                    newresult.AmountOC = result.AmountOC ?? 0;
                    newresult.Amount = result.Amount ?? 0;
                    newresult.PostVersion = result.PostVersion ?? 0;
                    newresult.EditVersion = result.EditVersion ?? 0;
                    newresult.SortOrder = result.SortOrder ?? 0;
                    //newresult.OpeningAccountEntryDetail = result.CreateDate;

                    buentity.Add(newresult);
                }
            }
            return buentity;
        }
    }
}

