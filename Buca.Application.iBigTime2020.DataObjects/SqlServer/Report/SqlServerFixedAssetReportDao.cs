/***********************************************************************
 * <copyright file="SqlServerFixedAssetReportDao.cs" company="BUCA JSC">
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
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Report
{
    /// <summary>
    /// SqlServerFixedAssetReportDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report.IFixedAssetReportDao" />
    public class SqlServerFixedAssetReportDao : IFixedAssetReportDao
    {
        /// <summary>
        /// Reports the inventory fixed assets.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="isPrintBookQuantity">if set to <c>true</c> [is print book quantity].</param>
        /// <returns></returns>
        public List<InventoryFixedAssetEntity> ReportInventoryFixedAssets(DateTime fromDate, DateTime toDate,
            bool isPrintBookQuantity)
        {
            const string sql = @"[dbo].[uspReport_InventoryFixedAsset]";
            object[] parms =
            {
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@IsPrintBookQuantity", isPrintBookQuantity
            };

            Func<IDataReader, InventoryFixedAssetEntity> makeInventoryFixedAsset = reader =>
                new InventoryFixedAssetEntity
                {
                    FixedAssetId = reader["FixedAssetID"].AsString(),
                    FixedAssetCode = reader["FixedAssetCode"].AsString(),
                    FixedAssetName = reader["FixedAssetName"].AsString(),
                    MadeIn = reader["MadeIn"].AsString(),
                    PostedDate = reader["PostedDate"].AsDateTime(),
                    SerialNumber = reader["SerialNumber"].AsString(),
                    UserDate = reader["UserDate"].AsInt(),
                    ToDate = reader["ToDate"].AsInt(),
                    FixedAssetCategoryId = reader["FixedAssetCategoryID"].AsString(),
                    FixedAssetCategoryCode = reader["FixedAssetCategoryCode"].AsString(),
                    FixedAssetCategoryName = reader["FixedAssetCategoryName"].AsString(),
                    DepartmentCode = reader["DepartmentCode"].AsString(),
                    DepartmentName = reader["DepartmentName"].AsString(),
                    BookQuantity = reader["BookQuantity"].AsInt(),
                    OrgPrice = reader["OrgPrice"].AsDecimal(),
                    DepreciationCreditAmount = reader["DepreciationCreditAmount"].AsDecimal(),
                    ReportItemIndex= reader["ReportItemIndex"].AsInt()

                };

            return Db.ReadList(sql, true, makeInventoryFixedAsset, parms);
        }

        /// <summary>
        /// Reports the fixed asset decrease list entities.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="decreaseReasonId">The decrease reason identifier.</param>
        /// <returns></returns>
        public List<FixedAssetDecreaseEntity> ReportFixedAssetDecreaseListEntities(DateTime fromDate, DateTime toDate,
            int decreaseReasonId)
        {
            const string sql = @"[dbo].[uspReport_GetFixedAssetDecreaseList]";
            object[] parms =
            {
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@DecreaseReasonID", decreaseReasonId
            };

            Func<IDataReader, FixedAssetDecreaseEntity> makeFixedAssetDecrease = reader => new FixedAssetDecreaseEntity
            {
                FixedAssetName = reader["FixedAssetName"].AsString(),
                FixedAssetCode = reader["FixedAssetCode"].AsString(),
                MadeIn = reader["MadeIn"].AsString(),
                OrgPrice = reader["OrgPrice"].AsDecimal(),
                SerialNumber = reader["SerialNumber"].AsString(),
                ProductionYear = reader["ProductionYear"].AsString().AsIntForNull(),
                Quantity = reader["Quantity"].AsInt(),
                RemainingAmount = reader["RemainingAmount"].AsDecimal(),
                RemainingRate = reader["RemainingRate"].AsDecimal(),
                Unit = reader["Unit"].AsString(),
                UsedDate = reader["UsedDate"].AsString().AsDateTimeForNull(),
                Volume = reader["Volume"].AsInt()
            };

            return Db.ReadList(sql, true, makeFixedAssetDecrease, parms);
        }

        public List<FixedAssetIncreaseDecreaseEntity> ReportFixedAssetIncreaseDecrease(DateTime fromDate, DateTime toDate)
        {
            const string sql = @"[dbo].[uspReport_GetFixedAssetIncreaseDecrease]";
            object[] parms =
            {
                "@FromDate", fromDate,
                "@ToDate", toDate
            };

            Func<IDataReader, FixedAssetIncreaseDecreaseEntity> makeFixedAssetIncreaseDecrease = reader => new FixedAssetIncreaseDecreaseEntity
            {
                DepartmentId = reader["DepartmentId"].AsString(),
                DepartmentName = reader["DepartmentName"].AsString(),
                FixedAssetName = reader["FixedAssetName"].AsString(),
                FixedAssetId = reader["FixedAssetId"].AsString(),
                OpenQty = reader["OpenQty"].AsDecimal(),
                OpenAmount = reader["OpenAmount"].AsDecimal(),
                InwardQty = reader["InwardQty"].AsDecimal(),
                InwardAmount = reader["InwardAmount"].AsDecimal(),
                OutwardQty = reader["OutwardQty"].AsDecimal(),
                OutwardAmount = reader["OutwardAmount"].AsDecimal(),
                FixedAssetCode = reader["FixedAssetCode"].AsString(),
                IsFixedAsset = reader["IsFixedAsset"].AsDecimal(),
            };

            return Db.ReadList(sql, true, makeFixedAssetIncreaseDecrease, parms);
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
            const string sql = @"[dbo].[uspReport_GetFixedAssetDepreciation]";
            object[] parms = {"@FromDate", fromDate, "@ToDate", toDate, "@IsDetailByFixedAsset", isDetailByFixedAsset };

            Func<IDataReader, FixedAssetC55HDEntity> MakeC55HD = reader => new FixedAssetC55HDEntity
            {
                FixedAssetCategoryId = reader["FixedAssetCategoryID"].AsString(),
                FixedAssetCategoryCode = reader["FixedAssetCategoryCode"].AsString(),
                FixedAssetCategoryName = reader["FixedAssetCategoryName"].AsString(),
                ParentId = reader["ParentID"].AsString(),
                Grade = reader["Grade"].AsInt(),
                OriginalPrice = reader["OriginalPrice"].AsDecimal(),
                DepreciationRate = reader["DepreciationRate"].AsDecimal(),
                DepreciationAmount = reader["DepreciationAmount"].AsDecimal(),
                IsFixedAsset = reader["IsFixedAsset"].AsBool(),
                IsParent = reader["IsParent"].AsBool(),
                IsDetailByFixedAsset = reader["IsDetailByFixedAsset"].AsBool()
            };
            return Db.ReadList(sql, true, MakeC55HD, parms);
        }

        /// <summary>
        /// Gets the report minutes get count fixed asset.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <param name="sumFixedAssetCategory">if set to <c>true</c> [sum fixed asset category].</param>
        /// <returns>
        /// List&lt;FixedAssetDecreaseEntity&gt;.
        /// </returns>
        public IList<MinutesGetCountFixedAssetEntity> GetReportMinutesGetCountFixedAsset(DateTime fromDate,
            DateTime toDate, string departmentId, string fixedAssetCategoryId, bool sumFixedAssetCategory)
        {
            const string sql = @"[dbo].[uspReport_MinutesGetCountFixedAsset]";
            object[] parms =
            {
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@pDepartmentID", departmentId,
                "@pFixedAssetCategory", fixedAssetCategoryId,
                "@pSumFixedAssetCategory", sumFixedAssetCategory
            };

            Func<IDataReader, MinutesGetCountFixedAssetEntity> makeMinutesGetCountFixedAssetEntity = reader =>
                new MinutesGetCountFixedAssetEntity
                {
                    FixedAssetId = reader["FixedAssetID"].AsString(),
                    FixedAssetName = reader["FixedAssetName"].AsString(),
                    FixedAssetCode = reader["FixedAssetCode"].AsString(),
                    SerialNumber = reader["SerialNumber"].AsString(),
                    UsedDate = reader["UsedDate"].AsInt(),
                    ToDate = reader["ToDate"].AsInt(),
                    SumFixedAssetCategory = reader["SumFixedAssetCategory"].AsBool(),
                    FixedAssetCategoryId = reader["FixedAssetCategoryId"].AsString(),
                    FixedAssetCategoryCode = reader["FixedAssetCategoryCode"].AsString(),
                    FixedAssetCategoryName = reader["FixedAssetCategoryName"].AsString(),
                    DepartmentCode = reader["DepartmentCode"].AsString(),
                    OrgPrice = reader["OrgPrice"].AsDecimal(),
                    DepreciationCreditAmount = reader["DepreciationCreditAmount"].AsDecimal(),
                    RemainingAmount = reader["RemainingAmount"].AsDecimal(),
                    MadeIn = reader["MadeIn"].AsString(),
                    DepartmentName = reader["DepartmentName"].AsString(),
                    BookQuantity = reader["BookQuantity"].AsDecimal()
                };

            return Db.ReadList(sql, true, makeMinutesGetCountFixedAssetEntity, parms);
        }

        public DataTable GetAttributionDepreciationFA(DateTime fromDate, DateTime toDate, string FixedAssetId, int IsPeriod, int IsType)
        {
            const string sql = @"uspCal_Attribution_DepreciationFA";
            object[] parms =
            {
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@FixedAssetID", FixedAssetId,
                "@IsPeriod",IsPeriod,
                "@IsType", IsType 
            };
            return Db.ReadDataTable(sql, true, parms);

        }
    }
}