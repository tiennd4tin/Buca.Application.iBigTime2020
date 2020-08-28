/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 27, 2017
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
    /// SqlServerSUTransferDao
    /// </summary>
    public class SqlServerSUTransferDao : ISUTransferDao
    {
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, SUTransferEntity> Make = reader =>
            new SUTransferEntity
            {
                RefId = reader["RefID"].AsGuid().AsString(),
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
        /// Gets the sUIncrementDecrement.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        /// SUTransferEntity.
        /// </returns>
        public SUTransferEntity GetSUTransfer(string refId)
        {
            const string procedures = @"uspGet_SUTransfer_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the su transfer.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <returns></returns>
        public SUTransferEntity GetSUTransfer(string refNo, DateTime postedDate)
        {
            const string procedures = @"uspGet_SUTransfer_ByRefNoAndPostedDate";

            object[] parms = { "@RefNo", refNo, "@PostedDate", postedDate };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the sUIncrementDecrement by refdate and reftype.
        /// </summary>
        /// <param name="suTransfer">The su transfer.</param>
        /// <returns></returns>
        public SUTransferEntity GetSUTransferByRefdateAndReftype(SUTransferEntity suTransfer)
        {
            const string procedures = @"uspGet_SUTransfer_ByRefdateAndReftype";
            object[] parms =
            {
                "@RefType", suTransfer.RefType, "@RefDate", suTransfer.RefDate, "@RefNo",suTransfer.RefNo
            };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the sUIncrementDecrements by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        /// List{SUTransferEntity}.
        /// </returns>
        public List<SUTransferEntity> GetSUTransfersByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_SUTransfer_ByRefType";
            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the sUIncrementDecrements by year of reference date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="yearOfRefDate">The year of reference date.</param>
        /// <returns></returns>
        public List<SUTransferEntity> GetSUTransfersByYearOfRefDate(int refTypeId,
            short yearOfRefDate)
        {
            const string procedures = @"uspGet_SUTransfer_ByRefType_By_PostedYear";
            object[] parms = { "@PostedDate", yearOfRefDate, "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the sUIncrementDecrements.
        /// </summary>
        /// <returns>
        /// List{SUTransferEntity}.
        /// </returns>
        public List<SUTransferEntity> GetSUTransfers()
        {
            const string procedures = @"uspGet_All_SUTransfer";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Inserts the sUIncrementDecrement.
        /// </summary>
        /// <param name="suTransfer">The su transfer.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        public string InsertSUTransfer(SUTransferEntity suTransfer)
        {
            const string sql = @"uspInsert_SUTransfer";
            return Db.Insert(sql, true, Take(suTransfer));
        }

        /// <summary>
        /// Updates the sUIncrementDecrement.
        /// </summary>
        /// <param name="suTransfer">The su transfer.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        public string UpdateSUTransfer(SUTransferEntity suTransfer)
        {
            const string sql = @"uspUpdate_SUTransfer";
            return Db.Update(sql, true, Take(suTransfer));
        }

        /// <summary>
        /// Deletes the sUIncrementDecrement.
        /// </summary>
        /// <param name="suTransfer">The su transfer.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        public string DeleteSUTransfer(SUTransferEntity suTransfer)
        {
            const string sql = @"uspDelete_SUTransfer";

            object[] parms = { "@RefID", suTransfer.RefId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// Gets the SUTransfer by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        public SUTransferEntity GetSUTransferByRefNo(string refNo)
        {
            const string procedures = @"uspGet_SUTransfer_ByRefNo";
            object[] parms = { "@RefNo", refNo };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Takes the specified s u increment decrement entity.
        /// </summary>
        /// <param name="suTransferEntity">The su transfer entity.</param>
        /// <returns></returns>
        private static object[] Take(SUTransferEntity suTransferEntity)
        {
            return new object[]
            {
                "@RefID", suTransferEntity.RefId,
                "@RefType", suTransferEntity.RefType,
                "@RefDate", suTransferEntity.RefDate,
                "@PostedDate", suTransferEntity.PostedDate,
                "@RefNo", suTransferEntity.RefNo,
                "@ParalellRefNo", suTransferEntity.ParalellRefNo,
                "@JournalMemo", suTransferEntity.JournalMemo,
                "@TotalAmount", suTransferEntity.TotalAmount,
                "@EditVersion", suTransferEntity.EditVersion
            };
        }
    }
}
