/***********************************************************************
 * <copyright file="SqlServerSUIncrementDecrementDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Wednesday, October 25, 2017
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
    ///     SqlServerSUIncrementDecrementDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IncrementDecrement.ISUIncrementDecrementDao" />
    public class SqlServerSUIncrementDecrementDao : ISUIncrementDecrementDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, SUIncrementDecrementEntity> Make = reader =>
            new SUIncrementDecrementEntity
            {
                RefId = reader["RefID"].AsString(),
                RefType = reader["RefType"].AsInt(),
                RefDate = reader["RefDate"].AsDateTime(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                RefNo = reader["RefNo"].AsString(),
                ParalellRefNo = reader["ParalellRefNo"].AsString(),
                JournalMemo = reader["JournalMemo"].AsString(),
                TotalAmount = reader["TotalAmount"].AsDecimal(),
                EditVersion = reader["EditVersion"].AsIntForNull()
            };

        /// <summary>
        ///     Gets the sUIncrementDecrement.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     SUIncrementDecrementEntity.
        /// </returns>
        public SUIncrementDecrementEntity GetSUIncrementDecrement(string refId)
        {
            const string procedures = @"uspGet_SUIncrementDecrement_ByID";
            object[] parms = {"@RefID", refId};
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the sUIncrementDecrement by refdate and reftype.
        /// </summary>
        /// <param name="sUIncrementDecrement">The ob sUIncrementDecrement entity.</param>
        /// <returns></returns>
        public SUIncrementDecrementEntity GetSUIncrementDecrementByRefdateAndReftype(
            SUIncrementDecrementEntity sUIncrementDecrement)
        {
            const string procedures = @"uspGet_SUIncrementDecrement_ByRefdateAndReftype";
            object[] parms =
            {
                "@RefType", sUIncrementDecrement.RefType, "@RefDate", sUIncrementDecrement.RefDate, "@RefNo",
                sUIncrementDecrement.RefNo
            };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the sUIncrementDecrements by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        ///     List{SUIncrementDecrementEntity}.
        /// </returns>
        public List<SUIncrementDecrementEntity> GetSUIncrementDecrementsByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_SUIncrementDecrement_ByRefType";
            object[] parms = {"@RefType", refTypeId};
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the sUIncrementDecrements by year of reference date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="yearOfRefDate">The year of reference date.</param>
        /// <returns></returns>
        public List<SUIncrementDecrementEntity> GetSUIncrementDecrementsByYearOfRefDate(int refTypeId,
            short yearOfRefDate)
        {
            const string procedures = @"uspGet_SUIncrementDecrement_ByRefType_By_PostedYear";
            object[] parms = {"@PostedDate", yearOfRefDate, "@RefType", refTypeId};
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the sUIncrementDecrements.
        /// </summary>
        /// <returns>
        ///     List{SUIncrementDecrementEntity}.
        /// </returns>
        public List<SUIncrementDecrementEntity> GetSUIncrementDecrements()
        {
            const string procedures = @"uspGet_All_SUIncrementDecrement";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        ///     Inserts the sUIncrementDecrement.
        /// </summary>
        /// <param name="sUIncrementDecrement">The sUIncrementDecrement.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        public string InsertSUIncrementDecrement(SUIncrementDecrementEntity sUIncrementDecrement)
        {
            const string sql = @"uspInsert_SUIncrementDecrement";
            return Db.Insert(sql, true, Take(sUIncrementDecrement));
        }

        /// <summary>
        ///     Updates the sUIncrementDecrement.
        /// </summary>
        /// <param name="sUIncrementDecrement">The sUIncrementDecrement.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        public string UpdateSUIncrementDecrement(SUIncrementDecrementEntity sUIncrementDecrement)
        {
            const string sql = @"uspUpdate_SUIncrementDecrement";
            return Db.Update(sql, true, Take(sUIncrementDecrement));
        }

        /// <summary>
        ///     Deletes the sUIncrementDecrement.
        /// </summary>
        /// <param name="sUIncrementDecrement">The sUIncrementDecrement.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        public string DeleteSUIncrementDecrement(SUIncrementDecrementEntity sUIncrementDecrement)
        {
            const string sql = @"uspDelete_SUIncrementDecrement";

            object[] parms = {"@RefID", sUIncrementDecrement.RefId};
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        ///     Gets the SUIncrementDecrement by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        public SUIncrementDecrementEntity GetSUIncrementDecrementByRefNo(string refNo)
        {
            const string procedures = @"uspGet_SUIncrementDecrement_ByRefNo";
            object[] parms = {"@RefNo", refNo};
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the SUIncrementDecrement by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        public SUIncrementDecrementEntity GetSUIncrementDecrementByRefNo(string refNo, DateTime postedDate)
        {
            const string procedures = @"uspGet_SUIncrementDecrement_ByRefNoAndPostedDate";
            object[] parms = { "@RefNo", refNo, "@PostedDate", postedDate };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Takes the specified s u increment decrement entity.
        /// </summary>
        /// <param name="sUIncrementDecrementEntity">The s u increment decrement entity.</param>
        /// <returns></returns>
        private static object[] Take(SUIncrementDecrementEntity sUIncrementDecrementEntity)
        {
            return new object[]
            {
                "@RefID", sUIncrementDecrementEntity.RefId,
                "@RefType", sUIncrementDecrementEntity.RefType,
                "@RefDate", sUIncrementDecrementEntity.RefDate,
                "@PostedDate", sUIncrementDecrementEntity.PostedDate,
                "@RefNo", sUIncrementDecrementEntity.RefNo,
                "@ParalellRefNo", sUIncrementDecrementEntity.ParalellRefNo,
                "@JournalMemo", sUIncrementDecrementEntity.JournalMemo,
                "@TotalAmount", sUIncrementDecrementEntity.TotalAmount,
                "@EditVersion", sUIncrementDecrementEntity.EditVersion
            };
        }
    }
}