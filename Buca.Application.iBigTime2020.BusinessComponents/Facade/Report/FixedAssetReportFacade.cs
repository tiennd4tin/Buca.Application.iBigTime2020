/***********************************************************************
 * <copyright file="FixedAssetReportFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Friday, January 12, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * DateFriday, January 12, 2018Author SonTV  Description 
 * 
 * ************************************************************************/

using System;
using System.Data;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Report.FixedAsset;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Inventory;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Report
{
    /// <summary>
    ///     Class FixedAssetReportFacade.
    /// </summary>
    public class FixedAssetReportFacade
    {
        /// <summary>
        ///     The report list DAO
        /// </summary>
        private static readonly IReportListDao ReportListDao = DataAccess.DataAccess.ReportListDao;

        /// <summary>
        ///     The fixed asset report DAO
        /// </summary>
        private static readonly IFixedAssetReportDao FixedAssetReportDao = DataAccess.DataAccess.FixedAssetReportDao;

        /// <summary>
        ///     Gets the fixed asset S24 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="usePurpose">The use purpose.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <param name="fixedAssetCategoryGrade">The fixed asset category grade.</param>
        /// <param name="printByCondition">if set to <c>true</c> [print by condition].</param>
        /// <param name="printFixedAssetOpening">if set to <c>true</c> [print fixed asset opening].</param>
        /// <param name="printFixedAssetIncrementInYear">if set to <c>true</c> [print fixed asset increment in year].</param>
        /// <param name="printFixedAssetNotIncrement">if set to <c>true</c> [print fixed asset not increment].</param>
        /// <param name="listFixedAssetID">The list fixed asset identifier.</param>
        /// <returns>IList&lt;FixedAssetS24HEntity&gt;.</returns>
        public IList<FixedAssetS24HEntity> GetFixedAssetS24H(string fromDate, string toDate, int usePurpose,
            string departmentId, string fixedAssetCategoryId, int fixedAssetCategoryGrade, bool printByCondition,
            bool printFixedAssetOpening, bool printFixedAssetIncrementInYear, bool printFixedAssetNotIncrement,
            string listFixedAssetID, int amountType, string currencyCode)
        {
            return ReportListDao.GetFixedAssetS24H(fromDate, toDate, usePurpose, departmentId, fixedAssetCategoryId,
                fixedAssetCategoryGrade, printByCondition, printFixedAssetOpening, printFixedAssetIncrementInYear,
                printFixedAssetNotIncrement, listFixedAssetID, amountType, currencyCode);
        }

        public IList<S26HEntity> GetReportFixedAssetS26H(DateTime fromDate, DateTime toDate, string departmentId, string fixedAssetCategoryId,int amountType, string currencyCode)
        {
            return ReportListDao.GetReportFixedAssetS26H(fromDate, toDate, departmentId, fixedAssetCategoryId, amountType, currencyCode) ;
        }

        /// <summary>
        ///     Reports the inventory fixed asset entities.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="isPrintBookQuantity">if set to <c>true</c> [is print book quantity].</param>
        /// <returns></returns>
        public IList<InventoryFixedAssetEntity> ReportInventoryFixedAssetEntities(DateTime fromDate, DateTime toDate,
            bool isPrintBookQuantity)
        {
            return FixedAssetReportDao.ReportInventoryFixedAssets(fromDate, toDate, isPrintBookQuantity);
        }

        /// <summary>
        ///     Gets the report minutes get count fixed asset.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <param name="sumFixedAssetCategory">if set to <c>true</c> [sum fixed asset category].</param>
        /// <returns>IList&lt;InventoryFixedAssetEntity&gt;.</returns>
        public IList<MinutesGetCountFixedAssetEntity> GetReportMinutesGetCountFixedAsset(DateTime fromDate,
            DateTime toDate, string departmentId, string fixedAssetCategoryId, bool sumFixedAssetCategory)
        {
            return FixedAssetReportDao.GetReportMinutesGetCountFixedAsset(fromDate, toDate, departmentId,
                fixedAssetCategoryId, sumFixedAssetCategory);
        }

        /// <summary>
        ///     Reports the fixed asset decrease list entities.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="decreaseReasonId">The decrease reason identifier.</param>
        /// <returns></returns>
        public IList<FixedAssetDecreaseEntity> ReportFixedAssetDecreaseListEntities(DateTime fromDate, DateTime toDate,
            int decreaseReasonId)
        {
            return FixedAssetReportDao.ReportFixedAssetDecreaseListEntities(fromDate, toDate, decreaseReasonId);
        }


        public IList<FixedAssetIncreaseDecreaseEntity> ReportFixedAssetIncreaseDecrease(DateTime fromDate, DateTime toDate)
        {
            return FixedAssetReportDao.ReportFixedAssetIncreaseDecrease(fromDate, toDate);
        }

        /// <summary>
        /// Gets the C55 hd report.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="isDetailByFixedAsset">if set to <c>true</c> [is detail by fixed asset].</param>
        /// <returns></returns>
        public IList<FixedAssetC55HDEntity> GetC55HDReport(DateTime fromDate, DateTime toDate, bool isDetailByFixedAsset)
        {
            return FixedAssetReportDao.GetC55HDReport(fromDate, toDate, isDetailByFixedAsset);
        }

        public DataTable GetAttributionDepreciationFA(DateTime fromDate, DateTime toDate, string FixedAssetId,
            int IsPeriod, int IsType)
        {
            return FixedAssetReportDao.GetAttributionDepreciationFA(fromDate, toDate, FixedAssetId, IsPeriod, IsType);
        }
    }
}