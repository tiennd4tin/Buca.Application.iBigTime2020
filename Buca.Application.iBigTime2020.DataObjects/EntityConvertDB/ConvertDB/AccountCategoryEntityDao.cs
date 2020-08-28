using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class AccountCategoryEntityDao : IEntityAccountCategoryDao
    {
       
       public  List<AccountCategoryEntity> GetAccountsCategory(string connectionString)
        {  
            List<AccountCategoryEntity> listAccount = new List<AccountCategoryEntity>();
            using (var context = new MISAEntity(connectionString))
            {
               
                var categories = context.AccountCategories.ToList();
                foreach (var result in categories)
                {
                    var accountCategory = new AccountCategoryEntity();
                   
                    accountCategory.AccountCategoryId = result.AccountCategoryID;              
                    accountCategory.AccountCategoryKind = result.AccountCategoryKind ?? 0;
                    accountCategory.DetailByBudgetSource = result.DetailByBudgetSource;
                    accountCategory.DetailByBudgetChapter = result.DetailByBudgetChapter;
                    accountCategory.DetailByBudgetKindItem = result.DetailByBudgetKindItem;
                    accountCategory.DetailByBudgetItem = result.DetailByBudgetItem;
                    accountCategory.DetailByBudgetSubItem = result.DetailByBudgetSubItem;
                    accountCategory.DetailByMethodDistribute = result.DetailByMethodDistribute;
                    accountCategory.DetailByAccountingObject = result.DetailByAccountingObject;
                    accountCategory.DetailByActivity = result.DetailByActivity;
                    accountCategory.DetailByProject = result.DetailByProject;
                    accountCategory.DetailByTask = result.DetailByTask;
                    accountCategory.DetailBySupply = result.DetailBySupply;
                    accountCategory.DetailByInventoryItem = result.DetailByInventoryItem;
                    accountCategory.DetailByFixedAsset = result.DetailByFixedAsset;
                    accountCategory.DetailByFund = result.DetailByFund;
                    accountCategory.DetailByBankAccount = result.DetailByBankAccount;                   
                    accountCategory.IsActive = result.Inactive == true ? false:true;
                    accountCategory.AccountCategoryName = result.AccountCategoryName;
                   

                    listAccount.Add(accountCategory);

                }

               
            }

            return listAccount;
        }

      
    }
}
