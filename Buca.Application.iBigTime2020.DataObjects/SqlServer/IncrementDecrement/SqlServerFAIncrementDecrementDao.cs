/***********************************************************************
 * <copyright file="SqlServerFAIncrementDecrementDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.IncrementDecrement;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IncrementDecrement;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.IncrementDecrement
{
    /// <summary>
    ///     SqlServerFAIncrementDecrementDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IncrementDecrement.IFAIncrementDecrementDao" />
    public class SqlServerFAIncrementDecrementDao : IFAIncrementDecrementDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, FAIncrementDecrementEntity> Make = reader =>
            new FAIncrementDecrementEntity
            {
                RefId = reader["RefID"].AsString(),
                RefType = reader["RefType"].AsInt(),
                RefDate = reader["RefDate"].AsDateTime(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                RefNo = reader["RefNo"].AsString(),
                ParalellRefNo = reader["ParalellRefNo"].AsString(),
                JournalMemo = reader["JournalMemo"].AsString(),
                TotalAmount = reader["TotalAmount"].AsDecimal(),
                GeneratedRefId = reader["GeneratedRefID"].AsString()
            };

        /// <summary>
        ///     Gets the fAIncrementDecrement.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     FAIncrementDecrementEntity.
        /// </returns>
        public FAIncrementDecrementEntity GetFAIncrementDecrement(string refId)
        {
            const string procedures = @"uspGet_FAIncrementDecrement_ByID";
            object[] parms = { "@RefID", refId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the fAIncrementDecrement by refdate and reftype.
        /// </summary>
        /// <param name="fAIncrementDecrement">The ob fAIncrementDecrement entity.</param>
        /// <returns></returns>
        public FAIncrementDecrementEntity GetFAIncrementDecrementByRefdateAndReftype(
            FAIncrementDecrementEntity fAIncrementDecrement)
        {
            const string procedures = @"uspGet_FAIncrementDecrement_ByRefdateAndReftype";
            object[] parms =
            {
                "@RefType", fAIncrementDecrement.RefType, "@RefDate", fAIncrementDecrement.RefDate, "@RefNo",
                fAIncrementDecrement.RefNo
            };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the fAIncrementDecrements by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        ///     List{FAIncrementDecrementEntity}.
        /// </returns>
        public List<FAIncrementDecrementEntity> GetFAIncrementDecrementsByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_FAIncrementDecrement_ByRefType";
            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the fAIncrementDecrements.
        /// </summary>
        /// <returns>
        ///     List{FAIncrementDecrementEntity}.
        /// </returns>
        public List<FAIncrementDecrementEntity> GetFAIncrementDecrements()
        {
            const string procedures = @"uspGet_All_FAIncrementDecrement";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        ///     Inserts the fAIncrementDecrement.
        /// </summary>
        /// <param name="fAIncrementDecrement">The fAIncrementDecrement.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        public string InsertFAIncrementDecrement(FAIncrementDecrementEntity fAIncrementDecrement)
        {
            const string sql = @"uspInsert_FAIncrementDecrement";
            return Db.Insert(sql, true, Take(fAIncrementDecrement));
        }

        /// <summary>
        ///     Updates the fAIncrementDecrement.
        /// </summary>
        /// <param name="fAIncrementDecrement">The fAIncrementDecrement.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        public string UpdateFAIncrementDecrement(FAIncrementDecrementEntity fAIncrementDecrement)
        {
            const string sql = @"uspUpdate_FAIncrementDecrement";
            return Db.Update(sql, true, Take(fAIncrementDecrement));
        }

        /// <summary>
        ///     Deletes the fAIncrementDecrement.
        /// </summary>
        /// <param name="fAIncrementDecrement">The fAIncrementDecrement.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        public string DeleteFAIncrementDecrement(FAIncrementDecrementEntity fAIncrementDecrement)
        {
            const string sql = @"uspDelete_FAIncrementDecrement";

            object[] parms = { "@RefID", fAIncrementDecrement.RefId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        ///     Gets the FAIncrementDecrement by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        public FAIncrementDecrementEntity GetFAIncrementDecrementByRefNo(string refNo)
        {
            const string procedures = @"uspGet_FAIncrementDecrement_ByRefNo";
            object[] parms = { "@RefNo", refNo };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the FAIncrementDecrement by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        public FAIncrementDecrementEntity GetFAIncrementDecrementByRefNo(string refNo, DateTime posteDate)
        {
            const string procedures = @"uspGet_FAIncrementDecrement_ByRefNoAndPosteDate";
            object[] parms = { "@RefNo", refNo, "@PostedDate", posteDate };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Takes the specified s u increment decrement entity.
        /// </summary>
        /// <param name="fAIncrementDecrementEntity">The s u increment decrement entity.</param>
        /// <returns></returns>
        private static object[] Take(FAIncrementDecrementEntity fAIncrementDecrementEntity)
        {
            return new object[]
            {
                "@RefID", fAIncrementDecrementEntity.RefId,
                "@RefType", fAIncrementDecrementEntity.RefType,
                "@RefDate", fAIncrementDecrementEntity.RefDate,
                "@PostedDate", fAIncrementDecrementEntity.PostedDate,
                "@RefNo", fAIncrementDecrementEntity.RefNo,
                "@ParalellRefNo", fAIncrementDecrementEntity.ParalellRefNo,
                "@JournalMemo", fAIncrementDecrementEntity.JournalMemo,
                "@TotalAmount", fAIncrementDecrementEntity.TotalAmount,
                "@GeneratedRefID", fAIncrementDecrementEntity.GeneratedRefId
            };
        }
    }
}