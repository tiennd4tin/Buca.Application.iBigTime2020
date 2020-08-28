/***********************************************************************
 * <copyright file="SqlServerAccountDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Friday, March 14, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;


namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{
    public class SqlServerAccountDao : DaoBase, IAccountDao
    {
        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>AccountEntity.</returns>
        public AccountEntity GetAccount(string accountId)
        {
            const string sql = @"uspGet_Account_ByID";

            object[] parms = { "@AccountID", accountId };
            return Db.Read(sql, true, Make, parms);
        }


        /// <summary>
        /// Gets the account by account code.
        /// </summary>
        /// <param name="accountnumber">The account code.</param>
        /// <returns></returns>
        public AccountEntity GetAccountByAccountNumber(string accountnumber)
        {
            const string sql = @"[uspGet_Account_ByAccountNumber]";

            object[] parms = { "@AccountNumber", accountnumber };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the accounts for combo tree.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>List{AccountEntity}.</returns>
        public List<AccountEntity> GetAccountsForComboTree(string accountId)
        {
            const string sql = @"uspGet_Account_ForComboTreee";

            object[] parms = { "@AccountID", accountId };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the accounts.
        /// </summary>
        /// <returns></returns>
        public List<AccountEntity> GetAccounts()
        {
            const string procedures = @"uspGet_All_Account";
            return Db.ReadList(procedures, true, Make);          
        }

        /// <summary>
        /// Gets the accounts active.
        /// </summary>
        /// <returns></returns>
        public List<AccountEntity> GetAccountsActive(bool isActive)
        {
            const string procedures = @"uspGet_Account_ByActive";
            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the accounts is detail.
        /// </summary>
        /// <param name="isDetail">if set to <c>true</c> [is detail].</param>
        /// <returns></returns>
        public List<AccountEntity> GetAccountsIsDetail(bool isDetail)
        {
            const string procedures = @"uspGet_Account_ByIsParent";
            object[] parms = { "@IsParent", isDetail };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns></returns>
        public string InsertAccount(AccountEntity account)
        {
            const string sql = "uspInsert_Account";
            return Db.Insert(sql, true, Take(account));
        }

        /// <summary>
        /// Updates the account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns></returns>
        public string UpdateAccount(AccountEntity account)
        {
            const string sql = "uspUpdate_Account";
            return Db.Update(sql, true, Take(account));
        }

        /// <summary>
        /// Deletes the account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns></returns>
        public string DeleteAccount(AccountEntity account)
        {
            const string sql = @"uspDelete_Account";

            object[] parms = { "@AccountID", account.AccountId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, AccountEntity> Make = reader => new AccountEntity
        {
            AccountId = reader["AccountID"].AsString(),
            AccountNumber = reader["AccountNumber"].AsString(),
            AccountCategoryId = reader["AccountCategoryID"].AsString(),
            ParentId = reader["ParentID"].AsString(),
            AccountName = reader["AccountName"].AsString(),
            AccountForeignName = reader["AccountForeignName"].AsString(),
            Description = reader["Description"].AsString(),
            AccountCategoryKind = reader["AccountCategoryKind"].AsInt(),
            DetailByBudgetSource = reader["DetailByBudgetSource"].AsBool(),
            DetailByBudgetChapter = reader["DetailByBudgetChapter"].AsBool(),
            DetailByBudgetKindItem = reader["DetailByBudgetKindItem"].AsBool(),
            DetailByBudgetItem = reader["DetailByBudgetItem"].AsBool(),
            DetailByBudgetSubItem = reader["DetailByBudgetSubItem"].AsBool(),
            DetailByMethodDistribute = reader["DetailByMethodDistribute"].AsBool(),
            DetailByAccountingObject = reader["DetailByAccountingObject"].AsBool(),
            DetailByActivity = reader["DetailByActivity"].AsBool(),
            DetailByProject = reader["DetailByProject"].AsBool(),
            DetailByTask = reader["DetailByTask"].AsBool(),
            DetailBySupply = reader["DetailBySupply"].AsBool(),
            DetailByInventoryItem = reader["DetailByInventoryItem"].AsBool(),
            DetailByFixedAsset = reader["DetailByFixedAsset"].AsBool(),
            DetailByFund = reader["DetailByFund"].AsBool(),
            DetailByBankAccount = reader["DetailByBankAccount"].AsBool(),
            DetailByProjectActivity = reader["DetailByProjectActivity"].AsBool(),
            DetailByInvestor = reader["DetailByInvestor"].AsBool(),
            Grade = reader["Grade"].AsInt(),
            IsParent = reader["IsParent"].AsBool(),
            IsActive = reader["IsActive"].AsBool(),
            IsDisplayOnAccountBalanceSheet = reader["IsDisplayOnAccountBalanceSheet"].AsBool(),
            IsDisplayBalanceOnReport = reader["IsDisplayBalanceOnReport"].AsBool(),
            DetailByCurrency = reader["DetailByCurrency"].AsBool(),
            DetailByBudgetExpense = reader["DetailByBudgetExpense"].AsBool(),
            DetailByExpense = reader["DetailByExpense"].AsBool(),
            DetailByContract = reader["DetailByContract"].AsBool(),
            DetailByCapitalPlan = reader["DetailByCapitalPlan"].AsBool(),
        };


        /// <summary>
        /// Takes the specified account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns></returns>
        private static object[] Take(AccountEntity accountEntity)
        {
            return new object[]
            {

                "@AccountID", accountEntity.AccountId,
                "@AccountNumber", accountEntity.AccountNumber,
                "@AccountCategoryID", accountEntity.AccountCategoryId,
                "@ParentID", accountEntity.ParentId,
                "@AccountName", accountEntity.AccountName,
                "@AccountForeignName", accountEntity.AccountForeignName,
                "@Description", accountEntity.Description,
                "@AccountCategoryKind", accountEntity.AccountCategoryKind,
                "@DetailByBudgetSource", accountEntity.DetailByBudgetSource,
                "@DetailByBudgetChapter", accountEntity.DetailByBudgetChapter,
                "@DetailByBudgetKindItem", accountEntity.DetailByBudgetKindItem,
                "@DetailByBudgetItem", accountEntity.DetailByBudgetItem,
                "@DetailByBudgetSubItem", accountEntity.DetailByBudgetSubItem,
                "@DetailByMethodDistribute", accountEntity.DetailByMethodDistribute,
                "@DetailByAccountingObject", accountEntity.DetailByAccountingObject,
                "@DetailByActivity", accountEntity.DetailByActivity,
                "@DetailByProject", accountEntity.DetailByProject,
                "@DetailByTask", accountEntity.DetailByTask,
                "@DetailBySupply", accountEntity.DetailBySupply,
                "@DetailByInventoryItem", accountEntity.DetailByInventoryItem,
                "@DetailByFixedAsset", accountEntity.DetailByFixedAsset,
                "@DetailByFund", accountEntity.DetailByFund,
                "@DetailByBankAccount", accountEntity.DetailByBankAccount,
                "@DetailByProjectActivity", accountEntity.DetailByProjectActivity,
                "@DetailByInvestor", accountEntity.DetailByInvestor,
                "@Grade", accountEntity.Grade,
                "@IsParent", accountEntity.IsParent,
                "@IsActive", accountEntity.IsActive,
                "@IsDisplayOnAccountBalanceSheet", accountEntity.IsDisplayOnAccountBalanceSheet,
                "@IsDisplayBalanceOnReport", accountEntity.IsDisplayBalanceOnReport,
                "@DetailByCurrency", accountEntity.DetailByCurrency,
                "@DetailByBudgetExpense", accountEntity.DetailByBudgetExpense,
                "@DetailByExpense", accountEntity.DetailByExpense,
                "@DetailByContract", accountEntity.DetailByContract,
                "@DetailByCapitalPlan", accountEntity.DetailByCapitalPlan,
            };
        }

        /// <summary>
        /// Gets the accounts for is inventory item.
        /// </summary>
        /// <returns>List{AccountEntity}.</returns>
        public List<AccountEntity> GetAccountsForIsInventoryItem()
        {
            const string procedures = @"uspGet_Account_ByInventoryItem";
            return Db.ReadList(procedures, true, Make);

        }

        public string DeleteConvertAccount()
        {
            const string sql = @"usp_ConvertAccount";

            object[] parms = { };
            return Db.Delete(sql, true, parms);
        }

        public string CheckExistAccountNumber(string AccountId,string AccountNumber)
        {
            const string sql = @"uspCheckExist_AccountNumber";

            object[] parms = { "@AccountID", AccountId, "@AccountNumber",AccountNumber };
            return Db.Delete(sql, true, parms);
        }
    }
}
