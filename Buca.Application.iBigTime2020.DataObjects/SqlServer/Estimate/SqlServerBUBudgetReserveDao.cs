/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: December 11, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    11/12/2017     Author       tudt        Description 
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
    /// SqlServerBUBudgetReserveDao
    /// </summary>
    public class SqlServerBUBudgetReserveDao : IBUBudgetReserveDao
    {
        /// <summary>
        /// Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public BUBudgetReserveEntity GetBUBudgetReserveByRefId(string refId)
        {
            const string procedures = @"uspGet_BUBudgetReserve_ByRefID";
            object[] parms = {"@RefId", refId};
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <returns></returns>
        public List<BUBudgetReserveEntity> GetBUBudgetReserves()
        {
            const string procedures = @"uspGet_All_BUBudgetReserve";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the bu budget reserves by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public List<BUBudgetReserveEntity> GetBUBudgetReservesByRefId(string refId)
        {
            const string procedures = @"uspGet_BUBudgetReserve_ByRefID";
            object[] parms = { "@RefId", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        public BUBudgetReserveEntity GetBUBudgetReserve(string refNo)
        {
            const string procedures = @"uspGet_BUBudgetReserve_ByRefNo";
            object[] parms = { "@RefNo", refNo };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        public BUBudgetReserveEntity GetBUBudgetReserve(string refNo, DateTime postedDate)
        {
            const string procedures = @"uspGet_BUBudgetReserve_ByRefNoAndPostedDate";
            object[] parms = { "@RefNo", refNo, "@PostedDate", postedDate };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the bu plan receipt entity.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public List<BUBudgetReserveEntity> GetBUBudgetReserves(string refTypeId)
        {
            const string procedures = @"uspGet_BUBudgetReserve_ByRefType";
            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public List<BUBudgetReserveEntity> GetBUBudgetReservesByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_BUBudgetReserve_ByRefType";
            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the bu plan receipt.
        /// </summary>
        /// <param name="buBudgetReserve">The bu budget reserve.</param>
        /// <returns></returns>
        public string InsertBUBudgetReserve(BUBudgetReserveEntity buBudgetReserve)
        {
            const string procedures = @"uspInsert_BUBudgetReserve";
            return Db.Insert(procedures, true, Take(buBudgetReserve));
        }

        /// <summary>
        /// Updates the bu plan receipt.
        /// </summary>
        /// <param name="buBudgetReserve">The bu budget reserve.</param>
        /// <returns></returns>
        public string UpdateBUBudgetReserve(BUBudgetReserveEntity buBudgetReserve)
        {
            const string procedures = @"uspUpdate_BUBudgetReserve";
            return Db.Update(procedures, true, Take(buBudgetReserve));
        }

        /// <summary>
        /// Deletes the bu plan receipt.
        /// </summary>
        /// <param name="buBudgetReserve">The bu budget reserve.</param>
        /// <returns></returns>
        public string DeleteBUBudgetReserve(BUBudgetReserveEntity buBudgetReserve)
        {
            const string procedures = @"uspDelete_BUBudgetReserve";
            object[] parms = { "@RefId", buBudgetReserve.RefId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BUBudgetReserveEntity> Make = reader =>
          new BUBudgetReserveEntity
          {
              RefId = reader["RefID"].AsGuid().AsString(),
              RefDate = reader["RefDate"].AsDateTime(),
              PostedDate = reader["PostedDate"].AsDateTime(),
              RefNo = reader["RefNo"].AsString(),
              RefType = reader["RefType"].AsInt(),
              BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
              BudgetChapterName = reader["BudgetChapterName"].AsString(),
              JournalMemo = reader["JournalMemo"].AsString(),
              CurrencyCode = reader["CurrencyCode"].AsString(),
              ExchangeRate = reader["ExchangeRate"].AsDecimal(),
              TotalAmount = reader["TotalAmount"].AsDecimal(),
              TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
              Posted = reader["Posted"].AsBool(),
              EditVersion = reader["EditVersion"].AsInt(),
              PostVersion = reader["PostVersion"].AsInt()
          };

        /// <summary>
        /// Takes the specified b u budget reserve entity.
        /// </summary>
        /// <param name="bUBudgetReserveEntity">The b u budget reserve entity.</param>
        /// <returns></returns>
        private object[] Take(BUBudgetReserveEntity bUBudgetReserveEntity)
        {
            return new object[]
            {
                "@RefID",bUBudgetReserveEntity.RefId,
                "@RefDate",bUBudgetReserveEntity.RefDate,
                "@PostedDate",bUBudgetReserveEntity.PostedDate,
                "@RefNo",bUBudgetReserveEntity.RefNo,
                "@RefType",bUBudgetReserveEntity.RefType,
                "@BudgetChapterCode",bUBudgetReserveEntity.BudgetChapterCode,
                "@BudgetChapterName",bUBudgetReserveEntity.BudgetChapterName,
                "@JournalMemo",bUBudgetReserveEntity.JournalMemo,
                "@CurrencyCode",bUBudgetReserveEntity.CurrencyCode,
                "@ExchangeRate",bUBudgetReserveEntity.ExchangeRate,
                "@TotalAmount",bUBudgetReserveEntity.TotalAmount,
                "@TotalAmountOC",bUBudgetReserveEntity.TotalAmountOC,
                "@Posted",bUBudgetReserveEntity.Posted,
                "@EditVersion",bUBudgetReserveEntity.EditVersion,
                "@PostVersion",bUBudgetReserveEntity.PostVersion
            };
        }
    }
}
