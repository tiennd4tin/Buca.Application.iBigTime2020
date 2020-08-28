using Buca.Application.iBigTime2020.BusinessEntities.Report.Inventory;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Report
{
    /// <summary>
    /// Class SqlServerInventoryReportDao.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report.IInventoryReportDao" />
    public class SqlServerInventoryReportDao : IInventoryReportDao
    {
        /// <summary>
        /// Gets the report S22 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="stockId">The stock identifier.</param>
        /// <param name="inventoryItemIds">The inventory item ids.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <returns>IList&lt;S22HEntity&gt;.</returns>
        public IList<S22HEntity> GetReportS22H(DateTime fromDate, DateTime toDate, string stockId, string inventoryItemIds, string accountNumber, int amountType, string currencyCode)
        {
            const string sql = @"uspReport_S22H";
            object[] parms =
            {
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@AccountNumber", accountNumber,
                "@StockID", stockId,
                "@InventoryItemIDs", inventoryItemIds,
                "@AmountType", amountType,
                "@CurrencyCode", currencyCode,
            };


            Func<IDataReader, S22HEntity> makeS22H = reader =>
              new S22HEntity
              {
                  OrderType = reader["OrderType"].AsInt(),
                  RefType = reader["RefType"].AsInt(),
                  RefId = reader["RefId"].AsString(),
                  RefNo = reader["RefNo"].AsString(),
                  PostedDate = reader["PostedDate"].AsDateTime(),
                  JournalMemo = reader["JournalMemo"].AsString(),
                  RefDate = reader["RefDate"].AsDateTime(),
                  AccountNumber = reader["AccountNumber"].AsString(),
                  ClosingAmount = reader["ClosingAmount"].AsDecimal(),
                  ClosingQuantity = reader["ClosingQuantity"].AsDecimal(),
                  InventoryItemCode = reader["InventoryItemCode"].AsString(),
                  InventoryItemId = reader["InventoryItemID"].AsString(),
                  InventoryItemName = reader["InventoryItemName"].AsString(),
                  InwardAmount = reader["InwardAmount"].AsDecimal(),
                  InwardQuantity = reader["InwardQuantity"].AsDecimal(),
                  OutwardAmount = reader["OutwardAmount"].AsDecimal(),
                  OutwardQuantity = reader["OutwardQuantity"].AsDecimal(),
                  RefOrder = reader["RefOrder"].AsInt(),
                  StockCode = reader["StockCode"].AsString(),
                  StockId = reader["StockID"].AsString(),
                  StockName = reader["StockName"].AsString(),
                  Unit = reader["Unit"].AsString(),
                  UnitPrice = reader["UnitPrice"].AsDecimal(),
              };

            return Db.ReadList(sql, true, makeS22H, parms);

        }
        #region Sổ kho S21-H
        /// <summary>
        /// Gets the report S22 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="stockId">The stock identifier.</param>
        /// <param name="inventoryItemIds">The inventory item ids.</param>
        /// <returns>IList&lt;S22HEntity&gt;.</returns>
        public IList<S21HEntity> GetReportS21H(DateTime fromDate, DateTime toDate, string stockId, string inventoryItemIds,bool IsDetailMonth)
        {
            const string sql = @"uspReport_S21H";
            object[] parms =
            {
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pStockID", stockId,
                "@InventoryIDs", inventoryItemIds,
                "@IsDetailMonth",IsDetailMonth
            };


            Func<IDataReader, S21HEntity> makeS21H = reader =>
              new S21HEntity
              {
                  OrderType = reader["OrderType"].AsInt(),
                  RefType = reader["RefType"].AsInt(),
                  RefId = reader["RefID"].AsString(),
                  RefNo = reader["RefNo"].AsString(),
                  PostedDate = reader["PostedDate"].AsDateTime(),
                  JournalMemo = reader["JournalMemo"].AsString(),
                  RefDate = reader["RefDate"].AsDateTime(),
                  ClosingQuantity = reader["ClosingQuantity"].AsDecimal(),
                  InventoryItemCode = reader["InventoryItemCode"].AsString(),
                  InventoryItemId = reader["InventoryItemID"].AsString(),
                  InventoryItemName = reader["InventoryItemName"].AsString(),
                  InwardQuantity = reader["InwardQuantity"].AsDecimal(),
                  OutwardQuantity = reader["OutwardQuantity"].AsDecimal(),
                  RefOrder = reader["RefOrder"].AsInt(),
                  StockCode = reader["StockCode"].AsString(),
                  StockId = reader["StockID"].AsString(),
                  StockName = reader["StockName"].AsString(),
                  Unit = reader["Unit"].AsString(),
                  UnitPrice = reader["UnitPrice"].AsDecimal(),
                  Month = reader["Month"].AsInt(),
                  FromDateInCurrentMonth = reader["FromDateInCurrentMonth"].AsDateTime(),
                  ToDateInCurrentMonth = reader["ToDateInCurrentMonth"].AsDateTime(),
                  RefTypeOrder = reader["RefTypeOrder"].AsInt(),
                  InventoryItemDescription = reader["InventoryItemDescription"].AsString(),
                  AccumulatedIn = reader["AccumulatedIn"].AsInt(),
                  AccumulatedOut = reader["AccumulatedOut"].AsInt()

              };
            return Db.ReadList(sql, true, makeS21H, parms);

        }


        #endregion

        #region Báo cáo tồn kho
        /// <summary>
        /// Gets the report S22 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="stockId">The stock identifier.</param>
        /// <param name="inventoryItemIds">The inventory item ids.</param>
        /// <returns>IList&lt;S22HEntity&gt;.</returns>
        public IList<InventoryBookEntity> GetInventoryBook(DateTime fromDate, DateTime toDate, string stockId, string inventoryItemIds)
        {
            const string sql = @"uspReport_InventoryBook";
            object[] parms =
            {
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@StockID", stockId,
                "@ListInventoryItemID", inventoryItemIds
            };

            
            Func<IDataReader, InventoryBookEntity> makeInventoryBook = reader =>
              new InventoryBookEntity
              {
                    StockId = reader["StockID"].AsString(),
                    InventoryItemId = reader["InventoryItemID"].AsString(),
                    OpeningQuantity = reader["OpeningQuantity"].AsDecimal(),
                    OpeningAmount = reader["OpeningAmount"].AsDecimal(),
                    InwardQuantity = reader["InwardQuantity"].AsDecimal(),
                    InwardAmount = reader["InwardAmount"].AsDecimal(),
                    OutwardQuantity = reader["OutwardQuantity"].AsDecimal(),
                    OutwardAmount = reader["OutwardAmount"].AsDecimal(),
                    ClosingQuantity = reader["ClosingQuantity"].AsDecimal(),
                    ClosingAmount = reader["ClosingAmount"].AsDecimal(),
                    StockCode = reader["StockCode"].AsString(),
                    StockName = reader["StockName"].AsString(),
                    InventoryCategoryId = reader["InventoryItemCategoryID"].AsString(),
                    InventoryCategoryCode = reader["InventoryItemCategoryCode"].AsString(),
                    InventoryCategoryName = reader["InventoryItemCategoryName"].AsString(),
                    InventoryItemCode = reader["InventoryItemCode"].AsString(),
                    InventoryItemName = reader["InventoryItemName"].AsString(),
                  //  Unit = reader["Unit"].AsString()
              };

            return Db.ReadList(sql, true, makeInventoryBook, parms);

        }

        #endregion

        #region Sổ kho S23-H
        public IList<S23HEntity> GetReportS23H(DateTime fromDate, DateTime toDate, string inventoryItemIds, string accountNumber)
        {
            const string sql = @"uspReport_S23H";
            object[] parms =
            {
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pAccountNumber", accountNumber,
                "@pInventoryItemIDs", inventoryItemIds
            };


            Func<IDataReader, S23HEntity> makeS23H = reader =>
              new S23HEntity
              {
                  AccountNumber = reader["AccountNumber"].AsString(),
                  InventoryCategoryId = reader["InventoryCategoryID"].AsString(),
                  InventoryCategoryCode = reader["InventoryCategoryCode"].AsString(),
                  InventoryCategoryName = reader["InventoryCategoryName"].AsString(),
                  InventoryItemId = reader["InventoryItemID"].AsString(),
                  InventoryItemCode = reader["InventoryItemCode"].AsString(),
                  InventoryItemName = reader["InventoryItemName"].AsString(),
                  OpeningAmount = reader["OpeningAmount"].AsDecimal(),
                  InwardAmount = reader["InwardAmount"].AsDecimal(),
                  OutwardAmount = reader["OutwardAmount"].AsDecimal(),
                  ClosingAmount = reader["ClosingAmount"].AsDecimal(),
              };

            return Db.ReadList(sql, true, makeS23H, parms);
        }
        #endregion

        #region S26-H: Sổ theo dõi công cụ, dụng cụ tại nơi sử dụng

        /// <summary>
        /// Gets the report S26 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="inventoryCategoryId">The inventory category identifier.</param>
        /// <returns>IList&lt;S26HEntity&gt;.</returns>
        public IList<S26HEntity> GetReportS26H(DateTime fromDate, DateTime toDate, string inventoryCategoryId, string inventoryItemIds, int amountType, string currencyCode)
        {
            const string sql = @"uspReport_S26H";
            object[] parms =
            {
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@InventoryIDs", inventoryItemIds,
                "@InventoryCategoryID", inventoryCategoryId,
                "@AmountType", amountType,
                "@CurrencyCode", currencyCode,
            };
            Func<IDataReader, S26HEntity> makeS26H = reader =>
              new S26HEntity
              {
                  RefType = reader["RefType"].AsInt(),
                  RefId = reader["RefId"].AsString(),
                  RefNo = reader["RefNo"].AsString(),
                  PostedDate = reader["PostedDate"].AsDateTime(),
                  RefDate = reader["RefDate"].AsDateTime(),                  
                  InventoryItemCode = reader["InventoryItemCode"].AsString(),
                  InventoryItemName = reader["InventoryItemName"].AsString(),
                  RefOrder = reader["RefOrder"].AsInt(),
                  Unit = reader["Unit"].AsString(),
                  UnitPrice = reader["UnitPrice"].AsDecimal(),
                  Amount = reader["Amount"].AsDecimal(),
                  DecrementAmount = reader["DecrementAmount"].AsDecimal(),
                  DecrementDescription = reader["DecrementDescription"].AsString(),
                  DecrementQuantity = reader["DecrementQuantity"].AsDecimal(),
                  DecrementUnitPrice = reader["DecrementUnitPrice"].AsDecimal(),
                  //DepartmentCode = reader["DepartmentCode"].AsString(),
                  //DepartmentName = reader["DepartmentName"].AsString(),
                  InventoryCategoryCode = reader["InventoryCategoryCode"].AsString(),
                  InventoryCategoryName = reader["InventoryCategoryName"].AsString(),
                  Quantity = reader["Quantity"].AsDecimal(),
              };

            return Db.ReadList(sql, true, makeS26H, parms);
        }

        #endregion

        #region Biên bản kiểm kê CCDC

        /// <summary>
        /// Gets the minutes inventory tool.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="minutesEuqalBook">if set to <c>true</c> [minutes euqal book].</param>
        /// <param name="InventoryCategoryId">The inventory category identifier.</param>
        /// <param name="sumInventoryCategory">if set to <c>true</c> [sum inventory category].</param>
        /// <returns>IList&lt;MinutesInventoryToolEntity&gt;.</returns>
        public IList<MinutesInventoryToolEntity> GetMinutesInventoryTool(DateTime fromDate, DateTime toDate, string departmentId, bool minutesEuqalBook, string InventoryCategoryId, bool sumInventoryCategory)
        {
            const string sql = @"uspReport_MinutesInventoryTool";
            object[] parms =
            {
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@DepartmentID", departmentId,
                "@MinutesEuqalBook", minutesEuqalBook,
                "@InventoryCategory",InventoryCategoryId,
                "@SumInventoryCategory",sumInventoryCategory
            };
            Func<IDataReader, MinutesInventoryToolEntity> makeMinutesInventoryTool = reader =>
             new MinutesInventoryToolEntity
             {
                
                 InventoryItemCode = reader["InventoryItemCode"].AsString(),
                 InventoryItemName = reader["InventoryItemName"].AsString(),             
                 DepartmentName = reader["DepartmentName"].AsString(),
                 InventoryCategoryName = reader["InventoryCategoryName"].AsString(),
                 AmountBook = reader["AmountBook"].AsDecimal(),
                 AmountMinutes = reader["AmountMinutes"].AsDecimal(),
                 DepartmentId = reader["DepartmentID"].AsString(),
                 InventoryCategoryId = reader["InventoryCategoryID"].AsString(),
                 InventoryItemId = reader["InventoryItemID"].AsString(),
                 QuantityBook = reader["QuantityBook"].AsDecimal(),
                 QuantityMinutes = reader["QuantityMinutes"].AsDecimal(),
                 SumInventoryCategory = reader["SumInventoryCategory"].AsString()
             };
            return Db.ReadList(sql, true, makeMinutesInventoryTool, parms);
        }

        #endregion
    }
}
