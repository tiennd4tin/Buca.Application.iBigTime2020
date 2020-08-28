using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class InventoryItemEntityDao : IEntityInventoryItemDao
    {
       
       public  List<InventoryItemEntity> GetInventoryItem(string connectionString)
        {  
            List<InventoryItemEntity> listItems = new List<InventoryItemEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var accountingObject = context.AccountingObjects.ToList();
                var categories = context.InventoryItems.ToList();
                foreach (var result in categories)
                {
                    var inventory = new InventoryItemEntity();
                    inventory.InventoryItemId = result.InventoryItemID.ToString();
                    inventory.InventoryCategoryId = result.InventoryCategoryID.ToString();
                    inventory.InventoryItemCode = result.InventoryItemCode;
                    inventory.InventoryItemName = result.InventoryItemName;
                    inventory.Description = result.Description;
                    inventory.Unit = result.Unit;
                    inventory.ConvertUnit = result.ConvertUnit;
                    inventory.ConvertRate = result.ConvertRate;
                    inventory.UnitPrice = result.UnitPrice;
                    inventory.MadeIn = "";
                    inventory.SalePrice = result.SalePrice;
                    inventory.DefaultStockId = result.DefaultStockID.ToString();
                    inventory.DepartmentId = null;
                    inventory.InventoryAccount = result.InventoryAccount;
                    inventory.COGSAccount = result.COGSAccount;
                    inventory.SaleAccount = result.SaleAccount;
                    inventory.CostMethod = result.CostMethod;
                    inventory.AccountingObjectId = result.AccountingObject==null ? null: result.AccountingObject.AccountingObjectID.ToString();
                    inventory.TaxRate = result.TaxRate;
                    inventory.IsTool = result.IsTool;
                    inventory.IsService = result.IsService;
                    inventory.IsActive = result.Inactive ==true?false:true;
                    inventory.IsTaxable = false;
                    inventory.IsStock = true;

                    listItems.Add(inventory);

                }

               
            }

            return listItems;
        }

      
    }
}
