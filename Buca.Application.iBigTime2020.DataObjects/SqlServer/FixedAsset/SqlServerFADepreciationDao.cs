/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.FixedAsset;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.FixedAsset;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.FixedAsset
{
    /// <summary>
    /// SqlServerFADepreciationDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.FixedAsset.IFADepreciationDao" />
    public class SqlServerFADepreciationDao : IFADepreciationDao
    {
        /// <summary>
        /// Gets the fa armortization.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public FADepreciationEntity GetFADepreciation(string refId)
        {
            const string procedures = @"uspGet_FADepreciation_ByRefID";

            object[] parms = { "@RefID", refId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the fa depreciation.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>
        /// FADepreciationEntity.
        /// </returns>
        public FADepreciationEntity GetFADepreciation(DateTime fromDate, DateTime toDate)
        {
            const string procedures = @"uspGet_FixedAssetDepreciation";

            object[] parms = { "@FromDate", fromDate, "@ToDate", toDate };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the fa depreciation.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <returns></returns>
        public FADepreciationEntity GetFADepreciation(string refNo, DateTime postedDate)
        {
            const string procedures = @"uspGet_FADepreciation_ByRefNoAndPostedDate";

            object[] parms = { "@RefNo", refNo, "@PostedDate", postedDate };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the fa armortizations by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public List<FADepreciationEntity> GetFADepreciationsByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_FADepreciation_ByRefType";

            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the fa depreciations by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="postedYear">The posted year.</param>
        /// <returns></returns>
        public List<FADepreciationEntity> GetFADepreciationsByRefTypeId(int refTypeId, int postedYear)
        {
            const string procedures = @"uspGet_FADepreciation_ByRefTypeAndPostedYear";

            object[] parms = { "@RefType", refTypeId, "@PostedYear", postedYear };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the type of the fa depreciations by reference type and period.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="periodType">Type of the period.</param>
        /// <returns></returns>
        public List<FADepreciationEntity> GetFADepreciationsByRefTypeAndPeriodType(int refTypeId, DateTime refDate, int periodType)
        {
            const string procedures = @"uspGet_FADepreciation_ByRefTypeAndPeriodType";

            object[] parms = { "@RefType", refTypeId, "@RefDate", refDate, "@PeriodType", periodType };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the type of the fa depreciations by reference type and period.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="periodType">Type of the period.</param>
        /// <returns></returns>
        public List<FADepreciationEntity> GetFADevaluationsByRefDateAndPeriodType(int refType, DateTime refDate, int periodType)
        {
            const string procedures = @"uspGet_FADeValuation_ByRefTypeAndPeriodType";

            object[] parms = { "@RefType", refType, "@RefDate", refDate, "@PeriodType", periodType };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the fa armortizations.
        /// </summary>
        /// <returns></returns>
        public List<FADepreciationEntity> GetFADepreciations()
        {
            const string procedures = @"uspGet_All_FADepreciation";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the fa armortizations by reference date.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        public List<FADepreciationEntity> GetFADepreciationsByRefDate(DateTime refDate)
        {
            const string procedures = @"uspGet_FADepreciation_ByRefDate";
            object[] parms = { "@RefDate", refDate };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the fa armortizations by reference date.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<FADepreciationEntity> GetFADepreciationsByRefDate(DateTime refDate, string currencyCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts the fa armortization.
        /// </summary>
        /// <param name="fAArmortization">The f a armortization.</param>
        /// <returns></returns>
        public string InsertFADepreciation(FADepreciationEntity fAArmortization)
        {
            const string sql = @"uspInsert_FADepreciation";
            return Db.Insert(sql, true, Take(fAArmortization));
        }

        /// <summary>
        /// Updates the fa armortization.
        /// </summary>
        /// <param name="fAArmortization">The f a armortization.</param>
        /// <returns></returns>
        public string UpdateFADepreciation(FADepreciationEntity fAArmortization)
        {
            const string sql = @"uspUpdate_FADepreciation";
            return Db.Insert(sql, true, Take(fAArmortization));
        }

        /// <summary>
        /// Deletes the fa armortization.
        /// </summary>
        /// <param name="fAArmortization">The f a armortization.</param>
        /// <returns></returns>
        public string DeleteFADepreciation(FADepreciationEntity fAArmortization)
        {
            const string sql = @"uspDelete_FADepreciation";

            object[] parms = { "@RefID", fAArmortization.RefId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, FADepreciationEntity> Make = reader =>
        new FADepreciationEntity
        {
            RefId = reader["RefID"].AsString(),
            RefType = reader["RefType"].AsInt(),
            RefDate = reader["RefDate"].AsDateTime(),
            PostedDate = reader["PostedDate"].AsDateTime(),
            RefNo = reader["RefNo"].AsString(),
            ParalellRefNo = reader["ParalellRefNo"].AsString(),
            JournalMemo = reader["JournalMemo"].AsString(),
            TotalAmount = reader["TotalAmount"].AsDecimal(),
            PeriodType = reader["PeriodType"].AsInt(),
            PeriodTypeName = reader["PeriodTypeName"].AsString()
        };

        /// <summary>
        /// Takes the specified f a depreciation entity.
        /// </summary>
        /// <param name="fADepreciationEntity">The f a depreciation entity.</param>
        /// <returns></returns>
        private object[] Take(FADepreciationEntity fADepreciationEntity)
        {
            return new object[]  
            {
                "@RefID",fADepreciationEntity.RefId,
		        "@RefType",fADepreciationEntity.RefType,
		        "@RefDate",fADepreciationEntity.RefDate,
		        "@PostedDate",fADepreciationEntity.PostedDate,
		        "@RefNo",fADepreciationEntity.RefNo,
		        "@ParalellRefNo",fADepreciationEntity.ParalellRefNo,
		        "@JournalMemo",fADepreciationEntity.JournalMemo,
		        "@TotalAmount",fADepreciationEntity.TotalAmount,
                "@PeriodType",fADepreciationEntity.PeriodType,
                "@PeriodTypeName",fADepreciationEntity.PeriodTypeName
            };
        }
    }
}
