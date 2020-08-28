/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    ///     SqlServerBudgetKindItemDao
    /// </summary>
    public class SqlServerBudgetKindItemDao : IBudgetKindItemDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, BudgetKindItemEntity> Make = reader =>
            new BudgetKindItemEntity
            {
                BudgetKindItemId = reader["BudgetKindItemID"].AsString(),
                ParentId = reader["ParentID"].AsString(),
                BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                BudgetKindItemName = reader["BudgetKindItemName"].AsString(),
                Grade = reader["Grade"].AsInt(),
                IsParent = reader["IsParent"].AsBool(),
                IsActive = reader["IsActive"].AsBool()
            };

        /// <summary>
        ///     The make include parent code
        /// </summary>
        private static readonly Func<IDataReader, BudgetKindItemEntity> MakeIncludeParentCode = reader =>
            new BudgetKindItemEntity
            {
                BudgetKindItemId = reader["BudgetKindItemID"].AsString(),
                ParentId = reader["BudgetKindItemParentCode"].AsString(),
                BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                BudgetKindItemName = reader["BudgetKindItemName"].AsString(),
                Grade = reader["Grade"].AsInt(),
                IsParent = reader["IsParent"].AsBool(),
                IsActive = reader["IsActive"].AsBool()
            };

        /// <summary>
        ///     Gets the Budget item.
        /// </summary>
        /// <param name="budgetKindItemId">The budget kind item identifier.</param>
        /// <returns></returns>
        public BudgetKindItemEntity GetBudgetKindItem(string budgetKindItemId)
        {
            const string sql = @"uspGet_BudgetKindItem_ByID";

            object[] parms = {"@BudgetKindItemID", budgetKindItemId};
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        ///     Gets the Budget items.
        /// </summary>
        /// <returns></returns>
        public List<BudgetKindItemEntity> GetBudgetKindItems()
        {
            const string procedures = @"uspGet_All_BudgetKindItem";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        ///     Gets the Budget items for combo tree.
        /// </summary>
        /// <param name="budgetKindItemId">The budget kind item identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<BudgetKindItemEntity> GetBudgetKindItemsForComboTree(string budgetKindItemId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the Budget items active.
        /// </summary>
        /// <returns></returns>
        public List<BudgetKindItemEntity> GetBudgetKindItemsActive()
        {
            const string procedures = @"uspGet_BudgetKindItem_ByActive";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        ///     Gets the Budget items active.
        /// </summary>
        /// <param name="isReceipt">if set to <c>true</c> [is receipt].</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<BudgetKindItemEntity> GetBudgetKindItemsByIsReceipt(bool isReceipt)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the budget items by capital allocate.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<BudgetKindItemEntity> GetBudgetKindItemsByCapitalAllocate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the budget items by pay voucher.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<BudgetKindItemEntity> GetBudgetKindItemsByPayVoucher()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the budget items by is receipt for estimate.
        /// </summary>
        /// <param name="isReceipt">if set to <c>true</c> [is receipt].</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<BudgetKindItemEntity> GetBudgetKindItemsByIsReceiptForEstimate(bool isReceipt)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the budget item and sub items.
        /// </summary>
        /// <param name="isBudgetKindItemType">Type of the is budget item.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<BudgetKindItemEntity> GetBudgetKindItemAndSubItems(int isBudgetKindItemType, bool isActive)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the Budget items by code.
        /// </summary>
        /// <param name="budgetKindItemCode">The budget kind item code.</param>
        /// <returns></returns>
        public BudgetKindItemEntity GetBudgetKindItemsByCode(string budgetKindItemCode)
        {
            const string procedures = @"uspGet_BudgetKindItem_ByCode";
            object[] parms = {"@BudgetKindItemCode", budgetKindItemCode};
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Inserts the Budget item.
        /// </summary>
        /// <param name="budgetKindItem">The budget kind item.</param>
        /// <returns></returns>
        public string InsertBudgetKindItem(BudgetKindItemEntity budgetKindItem)
        {
            const string sql = "uspInsert_BudgetKindItem";
            return Db.Insert(sql, true, Take(budgetKindItem));
        }

        /// <summary>
        ///     Updates the Budget item.
        /// </summary>
        /// <param name="budgetKindItem">The budget kind item.</param>
        /// <returns></returns>
        public string UpdateBudgetKindItem(BudgetKindItemEntity budgetKindItem)
        {
            const string sql = "uspUpdate_BudgetKindItem";
            return Db.Insert(sql, true, Take(budgetKindItem));
        }

        /// <summary>
        ///     Deletes the Budget item.
        /// </summary>
        /// <param name="budgetKindItem">The budget kind item.</param>
        /// <returns></returns>
        public string DeleteBudgetKindItem(BudgetKindItemEntity budgetKindItem)
        {
            const string sql = @"uspDelete_BudgetKindItem";

            object[] parms = {"@BudgetKindItemID", budgetKindItem.BudgetKindItemId};
            return Db.Delete(sql, true, parms);
        }

        public string DeleteBudgetKindItemConvert()
        {
            const string sql = @"usp_ConvertBudgetKindItem";

            object[] parms = { };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        ///     Gets the budget item by type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<BudgetKindItemEntity> GetBudgetKindItems(int type)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the budget kind items by code include parent code.
        /// </summary>
        /// <param name="budgetKindItemCode">The budget kind item code.</param>
        /// <returns></returns>
        public BudgetKindItemEntity GetBudgetKindItemsByCodeIncludeParentCode(string budgetKindItemCode)
        {
            const string procedures = @"uspGet_BudgetKindItem_ByCode";
            object[] parms = {"@BudgetKindItemCode", budgetKindItemCode};
            return Db.Read(procedures, true, MakeIncludeParentCode, parms);
        }

        /// <summary>
        ///     Takes the specified budget kind item entity.
        /// </summary>
        /// <param name="budgetKindItemEntity">The budget kind item entity.</param>
        /// <returns></returns>
        private static object[] Take(BudgetKindItemEntity budgetKindItemEntity)
        {
            return new object[]
            {
                "@BudgetKindItemID", budgetKindItemEntity.BudgetKindItemId,
                "@ParentID", budgetKindItemEntity.ParentId,
                "@BudgetKindItemCode", budgetKindItemEntity.BudgetKindItemCode,
                "@BudgetKindItemName", budgetKindItemEntity.BudgetKindItemName,
                "@Grade", budgetKindItemEntity.Grade,
                "@IsParent", budgetKindItemEntity.IsParent,
                "@IsActive", budgetKindItemEntity.IsActive
            };
        }
    }
}