/***********************************************************************
 * <copyright file="SqlServerBUVoucherListDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUNGDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, May 28, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Estimate
{
    /// <summary>
    ///     SqlServerBUVoucherListDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate.IBUVoucherListDao" />
    public class SqlServerBUVoucherListDao : IBUVoucherListDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, BUVoucherListEntity> Make = reader =>
            new BUVoucherListEntity
            {
                RefId = reader["RefID"].AsString(),
                RefType = reader["RefType"].AsInt(),
                RefDate = reader["RefDate"].AsDateTime(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                RefNo = reader["RefNo"].AsString(),
                ParalellRefNo = reader["ParalellRefNo"].AsString(),
                FromDate = reader["FromDate"].AsDateTime(),
                ToDate = reader["ToDate"].AsDateTime(),
                JournalMemo = reader["JournalMemo"].AsString(),
                Posted = reader["Posted"].AsBool(),
                TotalAmount = reader["TotalAmount"].AsDecimal(),
                PostVersion = reader["PostVersion"].AsString().AsIntForNull(),
                EditVersion = reader["EditVersion"].AsString().AsIntForNull(),
                TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                ExchangeRate = reader["ExchangeRate"].AsDecimal(),
            };

        /// <summary>
        ///     Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     BUVoucherListEntity.
        /// </returns>
        public BUVoucherListEntity GetBUVoucherListByRefId(string refId)
        {
            const string procedures = @"uspGet_BUVoucherList_ByRefId";
            object[] parms = {"@RefId", refId};
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the bu transferby reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>
        ///     BUVoucherListEntity.
        /// </returns>
        public BUVoucherListEntity GetBUVoucherListByRefNo(string refNo)
        {
            const string procedures = @"uspGet_BUVoucherList_ByRefNo";
            object[] parms = {"@RefNo", refNo};
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the bu voucher listby reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <returns></returns>
        public BUVoucherListEntity GetBUVoucherListByRefNo(string refNo, DateTime postedDate)
        {
            const string procedures = @"uspGet_BUVoucherList_ByRefNoAndPostedDate";
            object[] parms = {"@RefNo", refNo, "@PostedDate", postedDate};
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the bu plan receipt.
        /// </summary>
        /// <returns>
        ///     List&lt;BUVoucherListEntity&gt;.
        /// </returns>
        public List<BUVoucherListEntity> GetBUVoucherList()
        {
            const string procedures = @"uspGet_All_BUVoucherList";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        ///     Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        ///     List&lt;BUVoucherListEntity&gt;.
        /// </returns>
        public List<BUVoucherListEntity> GetBUVoucherListsByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_BUVoucherList_ByRefType";
            object[] parms = {"@RefType", refTypeId};
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Inserts the bu voucher list.
        /// </summary>
        /// <param name="bUVoucherListEntity">The bu voucher list entity.</param>
        /// <returns></returns>
        public string InsertBUVoucherList(BUVoucherListEntity bUVoucherListEntity)
        {
            const string procedures = @"uspInsert_BUVoucherList";
            return Db.Insert(procedures, true, Take(bUVoucherListEntity));
        }

        /// <summary>
        ///     Updates the bu plan receipt.
        /// </summary>
        /// <param name="bUVoucherListEntity">The b u transfer.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        public string UpdateBUVoucherList(BUVoucherListEntity bUVoucherListEntity)
        {
            const string procedures = @"uspUpdate_BUVoucherList";
            return Db.Update(procedures, true, Take(bUVoucherListEntity));
        }

        /// <summary>
        ///     Deletes the bu plan receipt.
        /// </summary>
        /// <param name="bUVoucherListEntity">The b u transfer.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        public string DeleteBUVoucherList(BUVoucherListEntity bUVoucherListEntity)
        {
            const string procedures = @"uspDelete_BUVoucherList";
            object[] parms = {"@RefId", bUVoucherListEntity.RefId};
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        ///     Takes the specified b u voucher list entity.
        /// </summary>
        /// <param name="bUVoucherListEntity">The b u voucher list entity.</param>
        /// <returns></returns>
        private static object[] Take(BUVoucherListEntity bUVoucherListEntity)
        {
            return new object[]
            {
                "@RefID", bUVoucherListEntity.RefId,
                "@RefType", bUVoucherListEntity.RefType,
                "@RefDate", bUVoucherListEntity.RefDate,
                "@PostedDate", bUVoucherListEntity.PostedDate,
                "@RefNo", bUVoucherListEntity.RefNo,
                "@ParalellRefNo", bUVoucherListEntity.ParalellRefNo,
                "@FromDate", bUVoucherListEntity.FromDate,
                "@ToDate", bUVoucherListEntity.ToDate,
                "@JournalMemo", bUVoucherListEntity.JournalMemo,
                "@Posted", bUVoucherListEntity.Posted,
                "@TotalAmount", bUVoucherListEntity.TotalAmount,
                "@PostVersion", bUVoucherListEntity.PostVersion,
                "@EditVersion", bUVoucherListEntity.EditVersion,
                "@CurrencyCode", bUVoucherListEntity.CurrencyCode,
                "@ExchangeRate", bUVoucherListEntity.ExchangeRate,
                "@TotalAmountOC",bUVoucherListEntity.TotalAmountOC
            };
        }
    }
}