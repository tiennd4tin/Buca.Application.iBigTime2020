using Buca.Application.iBigTime2020.BusinessEntities.Report.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report
{
    public interface IInventoryReportDao
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
        IList<S22HEntity> GetReportS22H(DateTime fromDate, DateTime toDate, string stockId, string inventoryItemIds,string accountNumber, int amountType, string currencyCode);
        #region sổ kho
        /// <summary>
        /// Gets the report S22 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="stockId">The stock identifier.</param>
        /// <param name="inventoryItemIds">The inventory item ids.</param>
        /// <returns>IList&lt;S22HEntity&gt;.</returns>
        IList<S21HEntity> GetReportS21H(DateTime fromDate, DateTime toDate, string stockId, string inventoryItemIds,bool IsDetailMonth);
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
        IList<InventoryBookEntity> GetInventoryBook(DateTime fromDate, DateTime toDate, string stockId, string inventoryItemIds);
        #endregion

        IList<S23HEntity> GetReportS23H(DateTime fromDate, DateTime toDate,string inventoryItemIds, string accountNumber);

        #region S26-H: Sổ theo dõi công cụ, dụng cụ tại nơi sử dụng
        /// <summary>
        /// Gets the report S26 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="inventoryCategoryId">The inventory category identifier.</param>
        /// <returns>IList&lt;S26HEntity&gt;.</returns>
        IList<S26HEntity> GetReportS26H(DateTime fromDate, DateTime toDate, string inventoryCategoryId, string inventoryItemIds, int amountType, string currencyCode);
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
        IList<MinutesInventoryToolEntity> GetMinutesInventoryTool(DateTime fromDate, DateTime toDate, string departmentId, bool minutesEuqalBook, string InventoryCategoryId, bool sumInventoryCategory);

        #endregion



    }
}
