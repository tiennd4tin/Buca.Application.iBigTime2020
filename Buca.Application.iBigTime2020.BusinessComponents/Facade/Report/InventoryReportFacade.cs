using Buca.Application.iBigTime2020.BusinessEntities.Report.Inventory;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Report
{
    public class InventoryReportFacade
    {
        /// <summary>
        /// The inventory report DAO
        /// </summary>
        private static readonly IInventoryReportDao InventoryReportDao = DataAccess.DataAccess.InventoryReportDao;

        /// <summary>
        /// Gets the report S22 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="stockId">The stock identifier.</param>
        /// <param name="inventoryItemIds">The inventory item ids.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <returns>IList&lt;S22HEntity&gt;.</returns>
        public IList<S22HEntity> GetReportS22H(DateTime fromDate, DateTime toDate, string stockId,
            string inventoryItemIds, string accountNumber, int amountType, string currencyCode)
        {
            return InventoryReportDao.GetReportS22H(fromDate, toDate, stockId, inventoryItemIds, accountNumber, amountType, currencyCode);
        }

        /// <summary>
        /// Gets the report S22 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="stockId">The stock identifier.</param>
        /// <param name="inventoryItemIds">The inventory item ids.</param>
        /// <returns>IList&lt;S22HEntity&gt;.</returns>
        public IList<S21HEntity> GetReportS21H(DateTime fromDate, DateTime toDate, string stockId,
            string inventoryItemIds,bool IsDetailMonth)
        {
            return InventoryReportDao.GetReportS21H(fromDate, toDate, stockId, inventoryItemIds, IsDetailMonth);
        }

        /// <summary>
        /// Gets the report S22 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="stockId">The stock identifier.</param>
        /// <param name="inventoryItemIds">The inventory item ids.</param>
        /// <returns>IList&lt;S22HEntity&gt;.</returns>
        public IList<InventoryBookEntity> GetInventoryBook(DateTime fromDate, DateTime toDate, string stockId,
            string inventoryItemIds)
        {
            return InventoryReportDao.GetInventoryBook(fromDate, toDate, stockId, inventoryItemIds);
        }
        public IList<S23HEntity> GetReportS23H(DateTime fromDate, DateTime toDate, string inventoryItemIds,
            string accountNumber)
        {
            return InventoryReportDao.GetReportS23H(fromDate, toDate, inventoryItemIds, accountNumber);
        }

        /// <summary>
        /// Gets the report S26 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="inventoryItemCategoryId">The inventory item category identifier.</param>
        /// <returns>IList&lt;S26HEntity&gt;.</returns>
        public IList<S26HEntity> GetReportS26H(DateTime fromDate, DateTime toDate,string inventoryItemCategoryId, string inventoryItemIds, int amountType, string currencyCode)
        {
            return InventoryReportDao.GetReportS26H(fromDate, toDate, inventoryItemCategoryId, inventoryItemIds, amountType,currencyCode);
        }

        #region Bảng kiểm kê công cụ dụng cụ

        /// <summary>
        /// Gets the minutes inventory tool.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="minutesEuqalBook">if set to <c>true</c> [minutes euqal book].</param>
        /// <param name="inventoryCategoryId">The inventory category identifier.</param>
        /// <param name="sumInventoryCategory">if set to <c>true</c> [sum inventory category].</param>
        /// <returns>IList&lt;MinutesInventoryToolEntity&gt;.</returns>
        public IList<MinutesInventoryToolEntity> GetMinutesInventoryTool(DateTime fromDate, DateTime toDate, string departmentId, bool minutesEuqalBook, string inventoryCategoryId, bool sumInventoryCategory)
        {
            return InventoryReportDao.GetMinutesInventoryTool(fromDate, toDate,departmentId, minutesEuqalBook, inventoryCategoryId, sumInventoryCategory);
        }

        #endregion

    }
}

