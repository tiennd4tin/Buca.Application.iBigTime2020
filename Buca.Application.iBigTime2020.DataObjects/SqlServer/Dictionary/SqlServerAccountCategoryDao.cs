/***********************************************************************
 * <copyright file="SqlServerAccountCategoryDao.cs" company="BUCA JSC">
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

    /// <summary>
    /// Class SqlServerAccountCategoryDao.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary.IAccountCategoryDao" />
    public class SqlServerAccountCategoryDao : IAccountCategoryDao
    {
        #region IAccountCategoryDao Members

        /// <summary>
        /// Gets the account category.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        /// <returns>AccountCategoryEntity.</returns>
        public AccountCategoryEntity GetAccountCategory(string accountCategoryId)
        {

            const string sql = @"uspGet_AccountCategory_ByID";
            object[] parms = { "@AccountCategoryID", accountCategoryId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the account categorys.
        /// </summary>
        /// <returns>List{AccountCategoryEntity}.</returns>
        public List<AccountCategoryEntity> GetAccountCategories()
        {
            const string procedures = @"uspGet_All_AccountCategory";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the account categorys active.
        /// </summary>
        /// <returns>List{AccountCategoryEntity}.</returns>
        public List<AccountCategoryEntity> GetAccountCategoriesByIsActive(bool isActive)
        {

            const string procedures = @"uspGet_AccountCategory_ByActive";
            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the account category.
        /// </summary>
        /// <param name="accountCategory">The account category.</param>
        /// <returns>System.Int32.</returns>
        public string InsertAccountCategory(AccountCategoryEntity accountCategory)
        {

            const string sql = "uspInsert_AccountCategory";
            return Db.Insert(sql, true, Take(accountCategory));
        }

        /// <summary>
        /// Updates the account category.
        /// </summary>
        /// <param name="accountCategory">The account category.</param>
        /// <returns>System.String.</returns>
        public string UpdateAccountCategory(AccountCategoryEntity accountCategory)
        {

            const string sql = "uspUpdate_AccountCategory";
            return Db.Update(sql, true, Take(accountCategory));
        }

        /// <summary>
        /// Deletes the account category.
        /// </summary>
        /// <param name="accountCategory">The account category.</param>
        /// <returns>System.String.</returns>
        public string DeleteAccountCategory(AccountCategoryEntity accountCategory)
        {

            const string sql = @"uspDelete_AccountCategory";
            object[] parms = { "@AccountCategoryID", accountCategory.AccountCategoryId };
            return Db.Delete(sql, true, parms);
        }
        public string DeleteConvertAccountCategorry()
        {
            const string sql = @"usp_ConvertAccountCategory";
            object[] parms = {  };
            return Db.Delete(sql, true, parms);
        }

        #endregion

        /// <summary>
        /// Takes the specified account categories.
        /// </summary>
        /// <param name="accountCategories">The account categories.</param>
        /// <returns>System.Object[][].</returns>
        private object[] Take(AccountCategoryEntity accountCategories)
        {
            return new object[]
            {
                "@AccountCategoryId", accountCategories.AccountCategoryId,
                "@AccountCategoryName", accountCategories.AccountCategoryName,
                "@AccountCategoryKind", accountCategories.AccountCategoryKind,
                "@DetailByBudgetSource", accountCategories.DetailByBudgetSource,
                "@DetailByBudgetChapter", accountCategories.DetailByBudgetChapter,
                "@DetailByBudgetKindItem", accountCategories.DetailByBudgetKindItem,
                "@DetailByBudgetItem", accountCategories.DetailByBudgetItem ,
                "@DetailByBudgetSubItem", accountCategories.DetailByBudgetSubItem,
                "@DetailByMethodDistribute", accountCategories.DetailByMethodDistribute,
                "@DetailByAccountingObject", accountCategories.DetailByAccountingObject,
                "@DetailByActivity", accountCategories.DetailByActivity,
                "@DetailByProject", accountCategories.DetailByProject,
                "@DetailByTask", accountCategories.DetailByTask,
                "@DetailBySupply", accountCategories.DetailBySupply,
                "@DetailByInventoryItem", accountCategories.DetailByInventoryItem,
                "@DetailByFixedAsset", accountCategories.DetailByFixedAsset,
                "@DetailByBankAccount", accountCategories.DetailByBankAccount,
                "@DetailByFund", accountCategories.DetailByFund,
                "@IsActive", accountCategories.IsActive
            };
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, AccountCategoryEntity> Make = reader =>
            new AccountCategoryEntity
            {
                AccountCategoryId = reader["AccountCategoryID"].AsString(),
                AccountCategoryName = reader["AccountCategoryName"].AsString(),
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
                DetailByBankAccount = reader["DetailByBankAccount"].AsBool(),
                DetailByFund = reader["DetailByFund"].AsBool(),
                IsActive = reader["IsActive"].AsBool()
            };


    }
}
