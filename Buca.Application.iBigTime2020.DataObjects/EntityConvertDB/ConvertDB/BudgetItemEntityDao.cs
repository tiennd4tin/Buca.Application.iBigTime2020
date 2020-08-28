using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;

using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class BudgetItemEntityDao : IEntityBudgetItemDao
    {

        
       

        public List<BudgetItemEntity> GetBudgetItem(string connectionString)
        {
            List<BudgetItemEntity> listBudgetItem = new List<BudgetItemEntity>();
            using (var context = new MISAEntity(connectionString))
            {
               
                var lstBudgetItem = context.BudgetItems.ToList().OrderBy(x=>x.Grade);

                foreach (var result in lstBudgetItem)
                {

                    var budgetItem = new BudgetItemEntity();

                    budgetItem.BudgetItemId = result.BudgetItemID.ToString();
                    budgetItem.ParentId = result.ParentID.ToString();
                    budgetItem.BudgetItemType = result.BudgetItemType;
                    budgetItem.BudgetItemCode = result.BudgetItemCode;
                    budgetItem.BudgetItemName = result.BudgetItemName;
                    budgetItem.BudgetGroupItemCode = result.BudgetGroupItemCode;
                    budgetItem.Grade = result.Grade;
                    budgetItem.IsParent = result.IsParent;
                    budgetItem.IsActive = result.Inactive ==true ?false:true;

                    listBudgetItem.Add(budgetItem);
                    

                }

            }

            return listBudgetItem;
        }
    }
}
