using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Estimate
{
    /// <summary>
    /// SqlServerBUPlanReceiptDao
    /// </summary>
    public class SqlServerBUPlanReceiptDao : IBUPlanReceiptDao
    {
        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <returns></returns>
        public List<BUPlanReceiptEntity> GetBUPlanReceipt()
        {
            const string procedures = @"uspGet_All_BUPlanReceipt";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        public BUPlanReceiptEntity GetBUPlanReceipt(string refNo)
        {
            const string procedures = @"uspGet_BUPlanReceipt_ByRefNo";
            object[] parms = { "@RefNo", refNo };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        public BUPlanReceiptEntity GetBUPlanReceipt(string refNo, DateTime postedDate)
        {
            const string procedures = @"uspGet_BUPlanReceipt_ByRefNoAndPostedDate";
            object[] parms = { "@RefNo", refNo, "@PostedDate", postedDate };
            return Db.Read(procedures, true, Make, parms);
        }


        /// <summary>
        /// Gets the bu plan receipt entity.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public List<BUPlanReceiptEntity> GetBUPlanReceiptEntity(string refTypeId)
        {
            const string procedures = @"uspGet_BUPlanReceipt_ByRefType";
            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public List<BUPlanReceiptEntity> GetBUPlanReceiptsByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_BUPlanReceipt_ByRefType";
            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Deletes the bu plan receipt.
        /// </summary>
        /// <param name="buPlanReceipt">The bu plan receipt.</param>
        /// <returns></returns>
        public string DeleteBUPlanReceipt(BUPlanReceiptEntity buPlanReceipt)
        {
            const string procedures = @"uspDelete_BUPlanReceipt";
            object[] parms = { "@RefId", buPlanReceipt.RefId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public BUPlanReceiptEntity GetBUPlanReceiptEntitybyRefId(string refId)
        {
            const string procedures = @"uspGet_BUPlanReceipt_ByRefId";
            object[] parms = { "@RefId", refId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the bu plan receipt.
        /// </summary>
        /// <param name="buPlanReceipt">The bu plan receipt.</param>
        /// <returns></returns>
        public string InsertBUPlanReceipt(BUPlanReceiptEntity buPlanReceipt)
        {
            const string procedures = @"uspInsert_BUPlanReceipt";
            return Db.Insert(procedures, true, Take(buPlanReceipt));
        }

        /// <summary>
        /// Updates the bu plan receipt.
        /// </summary>
        /// <param name="buPlanReceipt">The bu plan receipt.</param>
        /// <returns></returns>
        public string UpdateBUPlanReceipt(BUPlanReceiptEntity buPlanReceipt)
        {
            const string procedures = @"uspUpdate_BUPlanReceipt";
            return Db.Update(procedures, true, Take(buPlanReceipt));
        }


        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BUPlanReceiptEntity> Make = reader =>
          new BUPlanReceiptEntity
          {
              RefId = reader["RefID"].AsString(),
              RefType = reader["RefType"].AsInt(),
              RefDate = reader["RefDate"].AsDateTime(),
              PostedDate = reader["PostedDate"].AsDateTime(),
              RefNo = reader["RefNo"].AsString(),
              CurrencyCode = reader["CurrencyCode"].AsString(),
              ExchangeRate = reader["ExchangeRate"].AsDecimal(),
              ParalellRefNo = reader["ParalellRefNo"].AsString(),
              DecisionDate = reader["DecisionDate"].AsDateTimeForNull(),
              DecisionNo = reader["DecisionNo"].AsString(),
              BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
              JournalMemo = reader["JournalMemo"].AsString(),
              Posted = reader["Posted"].AsBool(),
              TotalAmount = reader["TotalAmount"].AsDecimal(),
              TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
              AllocationConfig = reader["AllocationConfig"].AsInt(),

          };

        /// <summary>
        /// Takes the specified bu plan receipt entity.
        /// </summary>
        /// <param name="buPlanReceiptEntity">The bu plan receipt entity.</param>
        /// <returns></returns>
        private static object[] Take(BUPlanReceiptEntity buPlanReceiptEntity)
        {
            return new object[]
            {

               "@RefId",buPlanReceiptEntity.RefId,
               "@RefType",buPlanReceiptEntity.RefType,
               "@RefDate",buPlanReceiptEntity.RefDate,
               "@PostedDate",buPlanReceiptEntity.PostedDate,
               "@RefNo",buPlanReceiptEntity.RefNo,
               "@CurrencyCode",buPlanReceiptEntity.CurrencyCode,
               "@ExchangeRate",buPlanReceiptEntity.ExchangeRate,
               "@ParalellRefNo",buPlanReceiptEntity.ParalellRefNo,
               "@DecisionDate",buPlanReceiptEntity.DecisionDate,
               "@DecisionNo",buPlanReceiptEntity.DecisionNo,
               "@BudgetChapterCode",buPlanReceiptEntity.BudgetChapterCode,
               "@JournalMemo",buPlanReceiptEntity.JournalMemo,
               "@Posted",buPlanReceiptEntity.Posted,
               "@TotalAmount",buPlanReceiptEntity.TotalAmount,
               "@TotalAmountOC",buPlanReceiptEntity.TotalAmountOC,
               "@AllocationConfig",buPlanReceiptEntity.AllocationConfig,
               //"@RefTypeName",buPlanReceiptEntity.RefTypeName,
            };
        }


    }
}
