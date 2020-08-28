using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class InventoryCategoryEntityDao : IEntityInventoryCategoryDao
    { 

       public  List<InventoryItemCategoryEntity> GetInventoryItemsCategory(string connectionString)
        {  
            List<InventoryItemCategoryEntity> listInventoryCategory = new List<InventoryItemCategoryEntity>();
            using (var context = new MISAEntity(connectionString))
            {
               
                var categories = context.InventoryItemCategories.ToList().OrderBy(x=>x.Grade);
                foreach (var result in categories)
                {
                    var inventoryItemCategory = new InventoryItemCategoryEntity();

                    inventoryItemCategory.InventoryItemCategoryId = result.InventoryCategoryID.ToString();
                    inventoryItemCategory.InventoryItemCategoryCode = result.InventoryCategoryCode;
                    inventoryItemCategory.InventoryItemCategoryName = result.InventoryCategoryName;
                    inventoryItemCategory.ParentId = result.ParentID.ToString();
                    inventoryItemCategory.Grade = result.Grade;
                    inventoryItemCategory.IsParent = result.IsParent;
                    inventoryItemCategory.IsTool = result.IsTool;
                    inventoryItemCategory.IsSystem = result.IsSystem;
                    inventoryItemCategory.IsActive = result.Inactive ==true ?false:true;


                    listInventoryCategory.Add(inventoryItemCategory);

                }

               
            }

            return listInventoryCategory;
        }

      
    }
}
