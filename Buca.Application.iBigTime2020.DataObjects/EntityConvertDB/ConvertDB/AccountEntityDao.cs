using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class AccountEntityDao : IEntityAccountDao
    {

        public List<AccountEntity> GetAccounts(string connectionString)
        {
            List<AccountEntity> listAccount = new List<AccountEntity>();
            using (var context = new MISAEntity(connectionString))
            {

                var categories = context.Accounts.ToList();
                foreach (var result in categories)
                {
                    var account = new AccountEntity();
                    account.AccountId = result.AccountID.ToString();
                    account.AccountNumber = result.AccountNumber;
                    account.AccountCategoryId = result.AccountCategoryID;
                    account.ParentId = result.ParentID.ToString();
                    account.AccountName = result.AccountName;
                    account.AccountForeignName = null;
                    account.Description = result.Description;
                    account.AccountCategoryKind = result.AccountCategoryKind ?? 0;
                    account.DetailByBudgetSource = result.DetailByBudgetSource;
                    account.DetailByBudgetChapter = result.DetailByBudgetChapter;
                    account.DetailByBudgetKindItem = result.DetailByBudgetKindItem;
                    account.DetailByBudgetItem = result.DetailByBudgetItem;
                    account.DetailByBudgetSubItem = result.DetailByBudgetSubItem;
                    account.DetailByMethodDistribute = result.DetailByMethodDistribute;
                    account.DetailByAccountingObject = result.DetailByAccountingObject;
                    account.DetailByActivity = result.DetailByActivity;
                    account.DetailByProject = result.DetailByProject;
                    account.DetailByTask = result.DetailByTask;
                    account.DetailBySupply = result.DetailBySupply;
                    account.DetailByInventoryItem = result.DetailByInventoryItem;
                    account.DetailByFixedAsset = result.DetailByFixedAsset;
                    account.DetailByFund = result.DetailByFund;
                    account.DetailByBankAccount = result.DetailByBankAccount;
                    account.DetailByProjectActivity = result.DetailByProjectActivity;
                    account.DetailByInvestor = result.DetailByInvestor;
                    account.Grade = result.Grade;
                    account.IsParent = result.IsParent;
                    account.IsActive = result.Inactive == true ? false : true;
                    account.IsDisplayOnAccountBalanceSheet = true;
                    account.IsDisplayBalanceOnReport = true;
                    account.DetailByCurrency = true;
                    account.DetailByBudgetExpense = true;


                    listAccount.Add(account);

                }


            }

            return listAccount;
        }


    }
}
