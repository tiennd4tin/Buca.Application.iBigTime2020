using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;

using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class BudgetKindItemEntityDao : IEntityBudgetKindItemDao
    {

        
       

        public List<BudgetKindItemEntity> GetBudgetKindItem(string connectionString)
        {
            List<BudgetKindItemEntity> listBudgetKindItem = new List<BudgetKindItemEntity>();
            using (var context = new MISAEntity(connectionString))
            {
               
                var lstBudgetKindItem = context.BudgetKindItems.ToList();

                foreach (var result in lstBudgetKindItem)
                {

                    var budgetKindItem = new BudgetKindItemEntity();

                    budgetKindItem.BudgetKindItemId = result.BudgetKinditemID.ToString();
                    budgetKindItem.ParentId = result.ParentID.ToString();
                    budgetKindItem.BudgetKindItemCode = result.BudgetKindItemCode;
                    budgetKindItem.BudgetKindItemName = result.BudgetKindItemName;
                    budgetKindItem.Grade = result.Grade;
                    budgetKindItem.IsParent = result.IsParent;
                   
                    budgetKindItem.IsActive = result.Active;

                    listBudgetKindItem.Add(budgetKindItem);
                    

                }

            }

            return listBudgetKindItem;
        }
    }
}
