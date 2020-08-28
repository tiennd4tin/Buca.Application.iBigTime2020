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

using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// Class SqlServerBudgetItemDao.
    /// </summary>
    public class SqlServerBudgetItemDao : IBudgetItemDao
    {
        /// <summary>
        /// Gets the Budget item.
        /// </summary>
        /// <param name="budgetItemId">The Budget item identifier.</param>
        /// <returns>BudgetItemEntity.</returns>
        public BudgetItemEntity GetBudgetItem(string budgetItemId)
        {
            const string sql = @"uspGet_BudgetItem_ByID";

            object[] parms = { "@BudgetItemID", budgetItemId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the Budget items.
        /// </summary>
        /// <returns>List{BudgetItemEntity}.</returns>
        public List<BudgetItemEntity> GetBudgetItems()
        {
            const string procedures = @"uspGet_All_BudgetItem";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the budget items by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<BudgetItemEntity> GetBudgetItemsByIsActive(bool isActive)
        {
            const string procedures = @"[dbo].[uspGet_BudgetItem_IsActive]";
            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the Budget items for combo tree.
        /// </summary>
        /// <param name="budgetItemId">The Budget item identifier.</param>
        /// <returns>List{BudgetItemEntity}.</returns>
        public List<BudgetItemEntity> GetBudgetItemsForComboTree(string budgetItemId)
        {
            const string sql = @"uspGet_BudgetItem_ForComboTree";

            object[] parms = { "@BudgetItemID", budgetItemId };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the Budget items by code.
        /// </summary>
        /// <returns>List{BudgetItemEntity}.</returns>
        public BudgetItemEntity GetBudgetItemsByCode(string budgetItemCode)
        {
            const string procedures = @"uspGet_BudgetItem_ByCode";
            object[] parms = { "@BudgetItemCode", budgetItemCode };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the Budget items active.
        /// </summary>
        /// <param name="isReceipt">if set to <c>true</c> [is receipt].</param>
        /// <returns>List{BudgetItemEntity}.</returns>
        public List<BudgetItemEntity> GetBudgetItemsByIsReceipt(bool isReceipt)
        {
            const string procedures = @"uspGet_BudgetItem_By_IsReceipt";
            object[] parms = { "@IsReceipt", isReceipt };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the budget items by capital allocate.
        /// </summary>
        /// <returns></returns>
        public List<BudgetItemEntity> GetBudgetItemsByCapitalAllocate()
        {
            const string procedures = @"uspGet_BudgetItemByCapitalAllocate";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the budget items by pay voucher.
        /// </summary>
        /// <returns></returns>
        public List<BudgetItemEntity> GetBudgetItemsByPayVoucher()
        {
            const string procedures = @"uspGet_BudgetItem_For_PayVoucher";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the budget items by is receipt for estimate.
        /// </summary>
        /// <param name="isReceipt">if set to <c>true</c> [is receipt].</param>
        /// <returns></returns>
        public List<BudgetItemEntity> GetBudgetItemsByIsReceiptForEstimate(bool isReceipt)
        {
            //const string procedures = @"uspGet_BudgetItem_By_IsReceipt_For_Estimate";
            const string procedures = @"uspGet_BudgetItem_For_ReceiptEstimate";
            object[] parms = { "@IsReceipt", isReceipt };
            return Db.ReadList(procedures, true, MakeForReceipt, parms);
        }

        /// <summary>
        /// Gets the budget item and sub items.
        /// </summary>
        /// <param name="budgetItemType">Type of the budget item.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<BudgetItemEntity> GetBudgetItemsByBudgetItemType(int budgetItemType, bool isActive)
        {
            const string procedures = @"uspGet_BudgetItem_ByType";
            object[] parms = { "@BudgetItemType", budgetItemType, "@IsActive", isActive };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the budget item and sub items.
        /// </summary>
        /// <param name="isBudgetItemType">Type of the is budget item.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<BudgetItemEntity> GetBudgetItemAndSubItems(int isBudgetItemType, bool isActive)
        {
            const string procedures = @"uspGet_BudgetItem_AndSubItem";
            object[] parms = { "@BudgetItemType", isBudgetItemType, "@IsActive", isActive };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the Budget item.
        /// </summary>
        /// <param name="budgetItem">The Budget item.</param>
        /// <returns>System.Int32.</returns>
        public string InsertBudgetItem(BudgetItemEntity budgetItem)
        {
            const string sql = "uspInsert_BudgetItem";
            return Db.Insert(sql, true, Take(budgetItem));
        }

        /// <summary>
        /// Updates the Budget item.
        /// </summary>
        /// <param name="budgetItem">The Budget item.</param>
        /// <returns>System.String.</returns>
        public string UpdateBudgetItem(BudgetItemEntity budgetItem)
        {
            const string sql = "uspUpdate_BudgetItem";
            return Db.Update(sql, true, Take(budgetItem));
        }

        /// <summary>
        /// Deletes the Budget item.
        /// </summary>
        /// <param name="budgetItem">The Budget item.</param>
        /// <returns>System.String.</returns>
        public string DeleteBudgetItem(BudgetItemEntity budgetItem)
        {
            const string sql = @"uspDelete_BudgetItem";

            object[] parms = { "@BudgetItemID", budgetItem.BudgetItemId };
            return Db.Delete(sql, true, parms);
        }

        public string DeleteBudgetItemConvert()
        {
            const string sql = @"usp_ConvertBudgetItem";

            object[] parms = {  };
            return Db.Delete(sql, true, parms);
        }
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>List{BudgetItemEntity}.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<BudgetItemEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the budget item by type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>List{BudgetItemEntity}.</returns>
        public List<BudgetItemEntity> GetBudgetItems(int type)
        {
            const string sql = @"uspGet_BudgetItem_ByType";
            object[] parms = { "@BudgetItemType", type };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BudgetItemEntity> Make = reader =>
            new BudgetItemEntity
            {
                BudgetItemId = reader["BudgetItemID"].AsString(),
                ParentId = reader["ParentID"].AsString(),
                BudgetItemType = reader["BudgetItemType"].AsInt(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetItemName = reader["BudgetItemName"].AsString(),
                BudgetGroupItemCode = reader["BudgetGroupItemCode"].AsString(),
                Grade = reader["Grade"].AsInt(),
                IsParent = reader["IsParent"].AsBool(),
                IsActive = reader["IsActive"].AsBool()
            };

        private static readonly Func<IDataReader, BudgetItemEntity> MakeForReceipt = reader =>
            new BudgetItemEntity
            {
                BudgetItemId = reader["BudgetItemID"].AsString(),
                ParentId = reader["ParentID"].AsString(),
                BudgetItemType = reader["BudgetItemType"].AsInt(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetItemName = reader["BudgetItemName"].AsString(),
                BudgetGroupItemCode = reader["BudgetGroupItemCode"].AsString(),
                Grade = reader["Grade"].AsInt(),
                IsParent = reader["IsParent"].AsBool(),
                IsActive = reader["IsActive"].AsBool()
            };

        /// <summary>
        /// Takes the specified Budget item.
        /// </summary>
        /// <param name="budgetItemEntity">The budget item entity.</param>
        /// <returns>
        /// System.Object[][].
        /// </returns>
        private object[] Take(BudgetItemEntity budgetItemEntity)
        {
            return new object[]
            {
                "@BudgetItemID",budgetItemEntity.BudgetItemId,
                "@ParentID",budgetItemEntity.ParentId,
                "@BudgetItemType",budgetItemEntity.BudgetItemType,
                "@BudgetItemCode",budgetItemEntity.BudgetItemCode,
                "@BudgetItemName",budgetItemEntity.BudgetItemName,
                "@BudgetGroupItemCode",budgetItemEntity.BudgetGroupItemCode,
                "@Grade",budgetItemEntity.Grade,
                "@IsParent",budgetItemEntity.IsParent,
                "@IsActive",budgetItemEntity.IsActive
            };
        }
    }
}
