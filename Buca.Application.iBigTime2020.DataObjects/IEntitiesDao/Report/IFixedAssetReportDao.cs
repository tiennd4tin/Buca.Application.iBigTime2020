/***********************************************************************
 * <copyright file="IFixedAssetReportDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUNGDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, April 26, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Report.FixedAsset;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report
{
    /// <summary>
    ///     IFixedAssetReportDao
    /// </summary>
    public interface IFixedAssetReportDao
    {
        /// <summary>
        ///     Reports the inventory fixed assets.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="isPrintBookQuantity">if set to <c>true</c> [is print book quantity].</param>
        /// <returns></returns>
        List<InventoryFixedAssetEntity> ReportInventoryFixedAssets(DateTime fromDate, DateTime toDate,
            bool isPrintBookQuantity);

        /// <summary>
        ///     Gets the report minutes get count fixed asset.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <param name="sumFixedAssetCategory">if set to <c>true</c> [sum fixed asset category].</param>
        /// <returns>IList&lt;MinutesGetCountFixedAssetEntity&gt;.</returns>
        IList<MinutesGetCountFixedAssetEntity> GetReportMinutesGetCountFixedAsset(DateTime fromDate, DateTime toDate,
            string departmentId, string fixedAssetCategoryId, bool sumFixedAssetCategory);

        /// <summary>
        ///     Reports the fixed asset decrease list entities.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="decreaseReasonId">The decrease reason identifier.</param>
        /// <returns></returns>
        List<FixedAssetDecreaseEntity> ReportFixedAssetDecreaseListEntities(DateTime fromDate, DateTime toDate,
            int decreaseReasonId);

        /// <summary>
        /// Tang giam tscd
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="decreaseReasonId"></param>
        /// <returns></returns>
        List<FixedAssetIncreaseDecreaseEntity> ReportFixedAssetIncreaseDecrease(DateTime fromDate, DateTime toDate);

        /// <summary>
        /// Gets the C55 hd report.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="isDetailByFixedAsset">if set to <c>true</c> [is detail by fixed asset].</param>
        /// <returns></returns>
        IList<FixedAssetC55HDEntity> GetC55HDReport(DateTime fromDate, DateTime toDate, bool isDetailByFixedAsset);

        DataTable GetAttributionDepreciationFA(DateTime fromDate, DateTime toDate, string FixedAssetId, int IsPeriod, int IsType);
    }
}