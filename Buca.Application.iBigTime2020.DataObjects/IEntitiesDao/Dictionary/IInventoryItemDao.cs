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

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;


namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// Interface IInventoryItemDao
    /// </summary>
    public interface IInventoryItemDao
    {
        ///// <summary>
        ///// Lấy kho theo Id
        ///// </summary>
        ///// <param name="stockId">The stock identifier.</param>
        ///// <returns>InventoryItemEntity.</returns>
        //InventoryItemEntity GetInventoryItemsByStockId(string stockId);

        /// <summary>
        /// Gets the inventory items.
        /// </summary>
        /// <returns>List&lt;InventoryItemEntity&gt;.</returns>
        List<InventoryItemEntity> GetInventoryItems();

        /// <summary>
        /// Gets the inventory items by is tool.
        /// </summary>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        /// <returns>List&lt;InventoryItemEntity&gt;.</returns>
        List<InventoryItemEntity> GetInventoryItemsByIsTool(bool isTool);

        /// <summary>
        /// Gets the inventory items by is tool and is active.
        /// </summary>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<InventoryItemEntity> GetInventoryItemsByIsToolAndIsActive(bool isTool, bool isActive);
        List<InventoryItemEntity> GetInventoryItemsByIsStockAndIsActiveAndCategoryCode(bool isStock, bool isActive, string inventoryCategoryCode);

        /// <summary>
        /// Gets the inventory items by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;InventoryItemEntity&gt;.</returns>
        List<InventoryItemEntity> GetInventoryItemsByIsActive(bool isActive);

        /// <summary>
        /// Gets the inventory item.
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns>InventoryItemEntity.</returns>
        InventoryItemEntity GetInventoryItem(string inventoryItemId);

        /// <summary>
        /// Gets the inventory item by inventory item code.
        /// </summary>
        /// <param name="inventoryItemCode">The inventory item code.</param>
        /// <returns>InventoryItemEntity.</returns>
        InventoryItemEntity GetInventoryItemByInventoryItemCode(string inventoryItemCode);

        /// <summary>
        /// Gets the inventory item by inventory item code.
        /// </summary>
        /// <param name="inventoryItemCode">The inventory item code.</param>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        /// <returns>InventoryItemEntity.</returns>
        InventoryItemEntity GetInventoryItemByInventoryItemCode(string inventoryItemCode, bool isTool);

        /// <summary>
        /// Gets the inventory items by inventory category code.
        /// </summary>
        /// <param name="inventoryCategoryCode">The inventory category code.</param>
        /// <returns></returns>
        IList<InventoryItemEntity> GetInventoryItemsByInventoryCategoryCode(string inventoryCategoryCode);

        IList<InventoryItemdestinationEntity> GetInventoryItemsByInventoryItemdestinations(string inventoryItemId, DateTime RefDate, int RefOrder, int UnitPriceDecimalDigitNumber);
        ///// <summary>
        ///// Gets the inventory item list by stock.
        ///// by BangNC
        ///// </summary>
        ///// <param name="itemStock">The item stock.</param>
        ///// <param name="refId">The reference identifier.</param>
        ///// <param name="postDate">The post date.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <returns>List&lt;InventoryItemEntity&gt;.</returns>
        //List<InventoryItemEntity> GetInventoryItemsInStock(int itemStock, int refId, DateTime postDate, string currencyCode);

        ///// <summary>
        ///// Gets the inventory item list by stock.
        ///// by BangNC
        ///// </summary>
        ///// <param name="itemStock">The item stock.</param>
        ///// <returns>List&lt;InventoryItemEntity&gt;.</returns>
        //List<InventoryItemEntity> GetInventoryItemListByStock(int itemStock);

        /// <summary>
        /// Thêm dữ liệu vật tư theo đối tượng
        /// </summary>
        /// <param name="inventoryItemEntity">The inventory item entity.</param>
        /// <returns>System.Int32.</returns>
        string InsertInventoryItem(InventoryItemEntity inventoryItemEntity);

        /// <summary>
        /// Cập nhật vật tư dữ liệu theo đối tượng
        /// </summary>
        /// <param name="inventoryItemEntity">The inventory item entity.</param>
        /// <returns>System.String.</returns>
        string UpdateInventoryItem(InventoryItemEntity inventoryItemEntity);

        /// <summary>
        /// Xóa vật tư theo inventoryItemId
        /// </summary>
        /// <param name="inventoryItemEntity">The inventory item entity.</param>
        /// <returns>System.String.</returns>
        string DeleteInventoryItem(InventoryItemEntity inventoryItemEntity);

        string DeleteInventoryItemConvert( );

        ///// <summary>
        ///// Xóa vật tư theo mã
        ///// </summary>
        ///// <param name="inventoryItemCode">The inventory item code.</param>
        ///// <returns>System.String.</returns>
        //string DeleteInventoryItemByCode(string inventoryItemCode);

        ////GetInventoryItemByCode
        ///// <summary>
        ///// Lấy danh sách vật tư theo mã
        ///// </summary>
        ///// <param name="inventoryItemCode">The inventory item code.</param>
        ///// <returns>List&lt;InventoryItemEntity&gt;.</returns>
        //List<InventoryItemEntity> GetInventoryItemByCode(string inventoryItemCode);

        /// <summary>
        /// Tính số lượng tồn trong kho
        /// </summary>
        /// <returns></returns>
        InventoryItemEntity GetUnitsInStock(string inventoryItemId, string stockId,DateTime PostedDate);

        /// <summary>
        /// Tính số lượng tồn trong phòng ban
        /// </summary>
        /// <param name="inventoryItemId"></param>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        InventoryItemEntity GetUnitsInDepartment(string inventoryItemId, string departmentId);

        /// <summary>
        /// Calculates the outward price.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns>System.String.</returns>
        string CalculateOutwardPrice(DateTime fromDate, DateTime toDate, string inventoryItemId);
    }
}