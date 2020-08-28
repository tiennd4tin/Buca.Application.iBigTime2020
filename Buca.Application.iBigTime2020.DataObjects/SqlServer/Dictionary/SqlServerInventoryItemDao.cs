/***********************************************************************
 * <copyright file="SqlServerInventoryItemDao.cs" company="BUCA JSC">
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
    /// Class SqlServerInventoryItemDao.
    /// </summary>
    public class SqlServerInventoryItemDao : DaoBase, IInventoryItemDao
    {
        /// <summary>
        /// Gets the inventory items.
        /// </summary>
        /// <returns>List&lt;InventoryItemEntity&gt;.</returns>
        public List<InventoryItemEntity> GetInventoryItems()
        {
            const string sql = @"uspGet_All_InventoryItem";
            return Db.ReadList(sql, true, Make);
        }

        /// <summary>
        /// Gets the inventory items by is tool.
        /// </summary>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        /// <returns>List&lt;InventoryItemEntity&gt;.</returns>
        public List<InventoryItemEntity> GetInventoryItemsByIsTool(bool isTool)
        {
            const string sql = @"uspGet_InventoryItem_ByIsTool";
            object[] parms = { "@IsTool", isTool };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the inventory items by is tool and is active.
        /// </summary>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<InventoryItemEntity> GetInventoryItemsByIsToolAndIsActive(bool isTool, bool isActive)
        {
            const string sql = @"uspGet_InventoryItem_ByIsToolAndIsActive";
            object[] parms = { "@IsTool", isTool, "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }
        public List<InventoryItemEntity> GetInventoryItemsByIsStockAndIsActiveAndCategoryCode(bool isStock, bool isActive, string inventoryCategoryCode)
        {
            const string sql = @"uspGet_InventoryItem_ByIsToolAndIsActiveAndInventoryCategoryCode";
            object[] parms = { "@IsStock", isStock, "@IsActive", isActive, "@InventoryCategoryCode", inventoryCategoryCode };
            return Db.ReadList(sql, true, Make<InventoryItemEntity>, parms);
        }

        /// <summary>
        /// Gets the inventory items by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;InventoryItemEntity&gt;.</returns>
        public List<InventoryItemEntity> GetInventoryItemsByIsActive(bool isActive)
        {
            const string sql = @"uspGet_InventoryItem_ByIsActive";
            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the inventory item.
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns>InventoryItemEntity.</returns>
        public InventoryItemEntity GetInventoryItem(string inventoryItemId)
        {
            const string sql = @"uspGet_InventoryItem_ByInventoryItemID";
            object[] parms = { "@InventoryItemID", inventoryItemId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the inventory item by inventory item code.
        /// </summary>
        /// <param name="inventoryItemCode">The inventory item code.</param>
        /// <returns>InventoryItemEntity.</returns>
        public InventoryItemEntity GetInventoryItemByInventoryItemCode(string inventoryItemCode)
        {
            const string sql = @"uspGet_InventoryItem_ByInventoryItemCode";
            object[] parms = { "@InventoryItemCode", inventoryItemCode };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the inventory item by inventory item code.
        /// </summary>
        /// <param name="inventoryItemCode">The inventory item code.</param>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        /// <returns>InventoryItemEntity.</returns>
        public InventoryItemEntity GetInventoryItemByInventoryItemCode(string inventoryItemCode, bool isTool)
        {
            const string sql = @"uspGet_InventoryItem_ByInventoryItemCodeAndIsTool";
            object[] parms = { "@InventoryItemCode", inventoryItemCode, "@IsTool", isTool };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the inventory items by inventory category code.
        /// </summary>
        /// <param name="inventoryCategoryCode">The inventory category code.</param>
        /// <returns>IList&lt;InventoryItemEntity&gt;.</returns>
        public IList<InventoryItemEntity> GetInventoryItemsByInventoryCategoryCode(string inventoryCategoryCode)
        {
            const string sql = @"uspGet_InventoryItem_ByInventoryCategoryCode";
            object[] parms = { "@InventoryCategoryCode", inventoryCategoryCode };
            return Db.ReadList(sql, true, Make, parms);
        }

        public IList<InventoryItemdestinationEntity> GetInventoryItemsByInventoryItemdestinations(string inventoryItemId, DateTime RefDate, int RefOrder, int UnitPriceDecimalDigitNumber)
        {
            const string sql = @"Proc_GetVoucher_RealNameMethod";
            object[] parms = { "@InventoryItemID", inventoryItemId, "@RefDate", RefDate, @"RefOrder", RefOrder, @"UnitPriceDecimalDigitNumber", UnitPriceDecimalDigitNumber };
            return Db.ReadList(sql, true, Make_destination, parms);
        }
        ///// <summary>
        ///// Gets the inventory item list by stock.
        ///// BangNC
        ///// </summary>
        ///// <param name="itemStock">The item stock.</param>
        ///// <param name="refId">The reference identifier.</param>
        ///// <param name="postDate">The post date.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <returns>List&lt;InventoryItemEntity&gt;.</returns>
        //public List<InventoryItemEntity> GetInventoryItemListByStock(int itemStock, int refId, DateTime postDate, string currencyCode)
        //{
        //    const string sql = @"uspGet_All_InventoryItemByStockID";
        //    object[] parms = { "@StockID", itemStock, "@RefID", refId, "@PostDate", postDate, "@Currency" ,currencyCode };
        //    return Db.ReadList(sql, true, Make,parms);
        //}

        /// <summary>
        /// Inserts the inventory item.
        /// </summary>
        /// <param name="inventoryItem">The inventory item.</param>
        /// <returns>System.Int32.</returns>
        public string InsertInventoryItem(InventoryItemEntity inventoryItem)
        {
            const string sql = @"uspInsert_InventoryItem";
            return Db.Insert(sql, true, Take(inventoryItem));
        }

        /// <summary>
        /// Updates the inventory item.
        /// </summary>
        /// <param name="inventoryItem">The inventory item.</param>
        /// <returns>System.String.</returns>
        public string UpdateInventoryItem(InventoryItemEntity inventoryItem)
        {

            const string sql = @"uspUpdate_InventoryItem";
            return Db.Update(sql, true, Take(inventoryItem));

        }

        /// <summary>
        /// Xóa vật tư theo Id
        /// </summary>
        /// <param name="inventoryItem">The inventory item.</param>
        /// <returns>System.String.</returns>
        public string DeleteInventoryItem(InventoryItemEntity inventoryItem)
        {

            const string sql = @"uspDelete_InventoryItem";
            object[] parms = { "@inventoryItemID", inventoryItem.InventoryItemId };
            return Db.Delete(sql, true, parms);
        }

        public string DeleteInventoryItemConvert( )
        {

            const string sql = @"usp_ConvertInventoryItem";
            object[] parms = { };
            return Db.Delete(sql, true, parms);
        }

        ///// <summary>
        ///// Xóa vật tư theo mã
        ///// </summary>
        ///// <param name="inventoryItemCode">The inventory item code.</param>
        ///// <returns>System.String.</returns>
        //public string DeleteInventoryItemByCode(string inventoryItemCode)
        //{
        //    const string sql = @"uspDelete_Inventory";
        //    object[] parms = { "@inventoryItemCode", inventoryItemCode };
        //    return Db.Delete(sql, true, parms);
        //}

        ///// <summary>
        ///// Lấy danh sách Vật tư theo mã
        ///// </summary>
        ///// <param name="inventoryItemCode">The inventory item code.</param>
        ///// <returns>List&lt;InventoryItemEntity&gt;.</returns>
        //public List<InventoryItemEntity> GetInventoryItemByCode(string inventoryItemCode)
        //{
        //    object[] parms = { "@InventoryItemCode", inventoryItemCode };
        //    const string sql = @"uspGet_InventoryItem_ByInventoryCode";
        //    return Db.ReadList(sql, true, Make, parms);
        //}

        ///// <summary>
        ///// Gets the inventory item list by stock.
        ///// by BangNC
        ///// </summary>
        ///// <param name="itemStock">The item stock.</param>
        ///// <returns>List&lt;InventoryItemEntity&gt;.</returns>
        //public List<InventoryItemEntity> GetInventoryItemListByStock(int itemStock)
        //{
        //    const string sql = @"uspGet_InventoryItemByStockID";
        //    object[] parms = { "@StockID", itemStock };
        //    return Db.ReadList(sql, true, Make, parms);
        //}

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, InventoryItemEntity> Make = reader =>
            new InventoryItemEntity
            {
                InventoryItemId = reader["InventoryItemID"].AsString(),
                InventoryCategoryId = reader["InventoryCategoryID"].AsString(),
                InventoryItemCode = reader["InventoryItemCode"].AsString(),
                InventoryItemName = reader["InventoryItemName"].AsString(),
                Description = reader["Description"].AsString(),
                Unit = reader["Unit"].AsString(),
                ConvertUnit = reader["ConvertUnit"].AsString(),
                ConvertRate = reader["ConvertRate"].AsDecimal(),
                UnitPrice = reader["UnitPrice"].AsDecimal(),
                SalePrice = reader["SalePrice"].AsDecimal(),
                DefaultStockId = reader["DefaultStockID"].AsString(),
                DepartmentId = reader["DepartmentID"].AsString(),
                MadeIn = reader["MadeIn"].AsString(),
                InventoryAccount = reader["InventoryAccount"].AsString(),
                COGSAccount = reader["COGSAccount"].AsString(),
                SaleAccount = reader["SaleAccount"].AsString(),
                CostMethod = reader["CostMethod"].AsInt(),
                AccountingObjectId = reader["AccountingObjectID"].AsString(),
                TaxRate = reader["TaxRate"].AsDecimal(),
                IsTool = reader["IsTool"].AsBool(),
                IsService = reader["IsService"].AsBool(),
                IsActive = reader["IsActive"].AsBool(),
                IsTaxable = reader["IsTaxable"].AsBool(),
                IsStock = reader["IsStock"].AsBool()
            };


        private static readonly Func<IDataReader, InventoryItemdestinationEntity> Make_destination = reader =>
          new InventoryItemdestinationEntity
          {
              RefId = reader["RefID"].AsString(),
              RefDetailId = reader["RefDetailID"].AsString(),
              RefNo = reader["RefNo"].AsString(),
              RefDate = reader["RefDate"].AsDateTime(),
              StockId = reader["StockID"].AsString(),
              InventoryItemId = reader["InventoryItemID"].AsString(),
              StockCode = reader["StockCode"].AsString(),
              MainUnitPrice = reader["MainUnitPrice"].AsDecimal(),
              UnitPrice = reader["UnitPrice"].AsDecimal(),
              Quantity = reader["Quantity"].AsDecimal(),
              InwardAmount = reader["InwardAmount"].AsDecimal(),
              ExpiryDate = reader["ExpiryDate"].AsString(),
              LotNo = reader["LotNo"].AsString(),
              Unit = reader["Unit"].AsString()
          };

        ///// <summary>
        ///// The make
        ///// </summary>
        //private static readonly Func<IDataReader, InventoryItemEntity> MakeForListInventory = reader =>
        //    new InventoryItemEntity
        //    {
        //        InventoryItemId = reader["InventoryItemID"].AsId(),
        //        InventoryItemCode = reader["InventoryItemCode"].AsString(),
        //        InventoryItemName = reader["InventoryItemName"].AsString(),
        //        AccountCode = reader["AccountCode"].AsString(),
        //        Unit = reader["Unit"].AsString(),
        //        CurrencyCode = reader["CurrencyCode"].AsString(),
        //        CostMethod = reader["CostMethod"].AsInt(),
        //        IsActive = reader["IsActive"].AsBool(),
        //        StockId = reader["StockID"].AsInt(),
        //        StockCode = reader["StockCode"].AsString(),
        //        ExpenseAccountCode = reader["ExpenseAccountCode"].AsString(),
        //    };

        /// <summary>
        /// Takes the specified inventory item.
        /// </summary>
        /// <param name="inventoryItemEntity">The inventory item entity.</param>
        /// <returns>System.Object[][].</returns>
        private object[] Take(InventoryItemEntity inventoryItemEntity)
        {
            return new object[]
            {
                "@InventoryItemID",inventoryItemEntity.InventoryItemId,
                "@InventoryCategoryID",inventoryItemEntity.InventoryCategoryId,
                "@InventoryItemCode",inventoryItemEntity.InventoryItemCode,
                "@InventoryItemName",inventoryItemEntity.InventoryItemName,
                "@Description",inventoryItemEntity.Description,
                "@Unit",inventoryItemEntity.Unit,
                "@ConvertUnit",inventoryItemEntity.ConvertUnit,
                "@ConvertRate",inventoryItemEntity.ConvertRate,
                "@UnitPrice",inventoryItemEntity.UnitPrice,
                "@SalePrice",inventoryItemEntity.SalePrice,
                "@MadeIn", inventoryItemEntity.MadeIn,
                "@DefaultStockID",inventoryItemEntity.DefaultStockId,
                "@DepartmentID",inventoryItemEntity.DepartmentId,
                "@InventoryAccount",inventoryItemEntity.InventoryAccount,
                "@COGSAccount",inventoryItemEntity.COGSAccount,
                "@SaleAccount",inventoryItemEntity.SaleAccount,
                "@CostMethod",inventoryItemEntity.CostMethod,
                "@AccountingObjectID",inventoryItemEntity.AccountingObjectId,
                "@TaxRate",inventoryItemEntity.TaxRate,
                "@IsTool",inventoryItemEntity.IsTool,
                "@IsService",inventoryItemEntity.IsService,
                "@IsActive",inventoryItemEntity.IsActive,
                "@IsTaxable",inventoryItemEntity.IsTaxable,
                "@IsStock",inventoryItemEntity.IsStock,
            };
        }

        /// <summary>
        /// Takes the calcualte outward price.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns>System.Object[].</returns>
        private object[] TakeCalcualteOutwardPrice(DateTime fromDate, DateTime toDate, string inventoryItemId)
        {
            return new object[]
            {
                "@FromDate",fromDate,
                "@ToDate",toDate,
                "@InventoryItemID",inventoryItemId
            };
        }

        /// <summary>
        /// Tính số lượng tồn trong kho
        /// </summary>
        /// <returns></returns>
        public InventoryItemEntity GetUnitsInStock(string inventoryItemId, string stockId, DateTime ToDate)
        {
            const string sql = @"uspGet_UnitsInStock";
            object[] parms = { "@InventoryItemID", inventoryItemId, "@StockID", stockId,"@ToDate", ToDate };
            return Db.Read(sql, true, Make<InventoryItemEntity>, parms);
        }

        /// <summary>
        /// Tính số lượng tồn trong phòng ban
        /// </summary>
        /// <param name="inventoryItemId"></param>
        /// <param name="stockId"></param>
        /// <returns></returns>
        public InventoryItemEntity GetUnitsInDepartment(string inventoryItemId, string departmentId)
        {
            const string sql = @"uspGet_UnitsInDepartment";
            object[] parms = { "@InventoryItemID", inventoryItemId, "@DepartmentID", departmentId };
            return Db.Read(sql, true, Make<InventoryItemEntity>, parms);
        }

        /// <summary>
        /// Calculates the outward price.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns>System.String.</returns>
        public string CalculateOutwardPrice(DateTime fromDate, DateTime toDate, string inventoryItemId)
        {
            const string sql = @"uspCalculate_OutwardPrice_ByClosingAverage";
            return Db.Update(sql, true, TakeCalcualteOutwardPrice(fromDate, toDate, inventoryItemId));
        }
    }
}