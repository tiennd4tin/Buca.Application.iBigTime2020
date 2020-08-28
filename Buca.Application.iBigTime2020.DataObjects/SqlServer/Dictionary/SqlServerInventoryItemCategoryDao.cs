/***********************************************************************
 * <copyright file="SqlServerInventoryItemCategoryDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Wednesday, March 12, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
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
    /// Class SqlServerInventoryItemCategoryDao.
    /// </summary>
    public class SqlServerInventoryItemCategoryDao : IInventoryItemCategoryDao
    {
        /// <summary>
        /// Gets the inventory item categories.
        /// </summary>
        /// <returns>List&lt;InventoryItemCategoryEntity&gt;.</returns>
        public List<InventoryItemCategoryEntity> GetInventoryItemCategories()
        {
            const string sql = @"uspGet_All_InventoryItemCategory";
            return Db.ReadList(sql, true, Make);
        }

        /// <summary>
        /// Gets the inventory item categories by is tool.
        /// </summary>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        /// <returns>List&lt;InventoryItemCategoryEntity&gt;.</returns>
        public List<InventoryItemCategoryEntity> GetInventoryItemCategoriesByIsTool(bool isTool)
        {
            const string sql = @"uspGet_InventoryItemCategory_ByIsTool";
            object[] parms = { "@IsTool", isTool };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the inventory item categories by is tool.
        /// </summary>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;InventoryItemCategoryEntity&gt;.</returns>
        public List<InventoryItemCategoryEntity> GetInventoryItemCategoriesByIsTool(bool isTool, bool isActive)
        {
            const string sql = @"uspGet_InventoryItemCategory_ByIsToolAndIsActive";
            object[] parms = { "@IsTool", isTool, "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }
        public List<InventoryItemCategoryEntity> GetInventoryItemCategories( bool isActive)
        {
            const string sql = @"uspGet_InventoryItemCategory_IsActive";
            object[] parms = {  "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the inventory item categories by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;InventoryItemCategoryEntity&gt;.</returns>
        public List<InventoryItemCategoryEntity> GetInventoryItemCategoriesByIsActive(bool isActive)
        {
            const string sql = @"uspGet_InventoryItemCategory_ByIsActive";
            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the get inventory item category.
        /// </summary>
        /// <param name="inventoryItemCategoryId">The inventory item category identifier.</param>
        /// <returns>InventoryItemCategoryEntity.</returns>
        public InventoryItemCategoryEntity GetGetInventoryItemCategory(string inventoryItemCategoryId)
        {
            const string sql = @"uspGet_InventoryItemCategory_ByInventoryItemCategoryID";
            object[] parms = { "@InventoryItemCategoryID", inventoryItemCategoryId };
            return Db.Read(sql, true, Make, parms);
        }

        public string DeleteInventoryItemCategoryConvert( )
        {
            const string sql = @"usp_ConvertTool";
            object[] parms = {  };
            return Db.Delete(sql, true, parms);
        }

        public string InsertInventoryItemCategory(InventoryItemCategoryEntity inventoryItemCategory)
        {
            const string sql = @"uspInsert_InventoryItemCategory";
            return Db.Insert(sql, true, Take(inventoryItemCategory));
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, InventoryItemCategoryEntity> Make = reader =>
            new InventoryItemCategoryEntity
            {
                InventoryItemCategoryId = reader["InventoryItemCategoryID"].AsString(),
                InventoryItemCategoryCode = reader["InventoryItemCategoryCode"].AsString(),
                InventoryItemCategoryName = reader["InventoryItemCategoryName"].AsString(),
                ParentId = reader["ParentID"].AsString(),
                Grade = reader["Grade"].AsInt(),
                IsTool = reader["IsTool"].AsBool(),
                IsSystem = reader["IsSystem"].AsBool(),
                IsActive = reader["IsActive"].AsBool(),
                IsParent = reader["IsParent"].AsBool()
            };

        private object[] Take(InventoryItemCategoryEntity inventoryItemCategory)
        {
            return new object[]
            {
                "@InventoryItemCategoryID" , inventoryItemCategory.InventoryItemCategoryId,
                "@InventoryItemCategoryCode" , inventoryItemCategory.InventoryItemCategoryCode,
                "@InventoryItemCategoryName" , inventoryItemCategory.InventoryItemCategoryName,
                "@Grade" , inventoryItemCategory.Grade,
                "@ParentID" , inventoryItemCategory.ParentId,
                "@IsParent" , inventoryItemCategory.IsParent,
                "@IsSystem" , inventoryItemCategory.IsSystem,
                "@IsTool" , inventoryItemCategory.IsTool,
                "@IsActive" , inventoryItemCategory.IsActive
            };
        }
    }
}