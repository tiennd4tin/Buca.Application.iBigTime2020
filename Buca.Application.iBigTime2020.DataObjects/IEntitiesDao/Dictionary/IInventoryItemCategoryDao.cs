/***********************************************************************
 * <copyright file="IStockDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Friday, March 14, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;


namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// Interface IInventoryItemDao
    /// </summary>
    public interface IInventoryItemCategoryDao
    {
        /// <summary>
        /// Gets the inventory item categories.
        /// </summary>
        /// <returns>List&lt;InventoryItemCategoryEntity&gt;.</returns>
        List<InventoryItemCategoryEntity> GetInventoryItemCategories();

        /// <summary>
        /// Gets the inventory item categories by is tool.
        /// </summary>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        /// <returns>List&lt;InventoryItemCategoryEntity&gt;.</returns>
        List<InventoryItemCategoryEntity> GetInventoryItemCategoriesByIsTool(bool isTool);

        /// <summary>
        /// Gets the inventory item categories by is tool.
        /// </summary>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;InventoryItemCategoryEntity&gt;.</returns>
        List<InventoryItemCategoryEntity> GetInventoryItemCategoriesByIsTool(bool isTool, bool isActive);
        List<InventoryItemCategoryEntity> GetInventoryItemCategories(bool isActive);

        /// <summary>
        /// Gets the inventory item categories by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;InventoryItemCategoryEntity&gt;.</returns>
        List<InventoryItemCategoryEntity> GetInventoryItemCategoriesByIsActive(bool isActive);

        /// <summary>
        /// Gets the get inventory item category.
        /// </summary>
        /// <param name="inventoryItemCategoryId">The inventory item category identifier.</param>
        /// <returns>InventoryItemCategoryEntity.</returns>
        InventoryItemCategoryEntity GetGetInventoryItemCategory(string inventoryItemCategoryId);

        string DeleteInventoryItemCategoryConvert();

        string InsertInventoryItemCategory(InventoryItemCategoryEntity inventoryItemCategory);
    }
}
