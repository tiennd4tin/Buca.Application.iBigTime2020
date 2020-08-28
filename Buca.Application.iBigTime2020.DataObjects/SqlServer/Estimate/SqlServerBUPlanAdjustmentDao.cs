using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Estimate
{
    public class SqlServerBUPlanAdjustmentDao : DaoBase, IBUPlanAdjustmentDao
    {


        public List<BUPlanAdjustmentEntity> GetBuPlanAdjustment()
        {
            const string procedures = @"uspGet_All_BUPlanAdjustment";
            return Db.ReadList(procedures, true, Make);
        }

        public BUPlanAdjustmentEntity GetBuPlanAdjustmentEntitybyRefId(string refId)
        {
            const string procedures = @"uspGet_BUPlanAdjustment_ByRefId";
            object[] parms = { "@RefID", refId };
            return Db.Read(procedures, true, Make<BUPlanAdjustmentEntity>, parms);
        }

        public BUPlanAdjustmentEntity GetBuPlanAdjustmentEntitybyRefNo(string refNo)
        {
            const string procedures = @"uspGet_BUPlanAdjustment_ByRefNo";
            object[] parms = { "@RefNo", refNo };
            return Db.Read(procedures, true, Make, parms);
        }
        public BUPlanAdjustmentEntity GetBuPlanAdjustmentEntitybyRefNo(string refNo, DateTime postedDate)
        {
            const string procedures = @"uspGet_BUPlanAdjustment_ByRefNoAndPostedDate";
            object[] parms = { "@RefNo", refNo, "@PostedDate", postedDate };
            return Db.Read(procedures, true, Make, parms);
        }

        public List<BUPlanAdjustmentEntity> GetBuPlanAdjustmentEntitybyReftypeId(string refTypeId)
        {
            const string procedures = @"uspGet_BUPlanAdjustment_ByRefType";
            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public string InsertBUPlanAdjustment(BUPlanAdjustmentEntity buPlanAdjustment)
        {
            const string procedures = @"uspInsert_BUPlanAdjustment";
            return Db.Insert(procedures, true, Take(buPlanAdjustment));
        }

        public string UpdateBUPlanAdjustment(BUPlanAdjustmentEntity buPlanAdjustment)
        {
            const string procedures = @"uspUpdate_BUPlanAdjustment";
            return Db.Update(procedures, true, Take(buPlanAdjustment));
        }
        public string DeleteBUPlanAdjustment(BUPlanAdjustmentEntity buPlanAdjustment)
        {
            const string procedures = @"uspDelete_BUPlanAdjustment";
            object[] parms = { "@RefID", buPlanAdjustment.RefId };
            return Db.Delete(procedures, true, parms);
        }
        private static readonly Func<IDataReader, BUPlanAdjustmentEntity> Make = reader =>
   new BUPlanAdjustmentEntity
   {
       RefId = reader["RefID"].AsString(),
       RefType = reader["RefType"].AsInt(),
       RefDate = reader["RefDate"].AsDateTime(),
       PostedDate = reader["PostedDate"].AsDateTime(),
       RefNo = reader["RefNo"].AsString(),
       ParalellRefNo = reader["ParalellRefNo"].AsString(),
       DecisionDate = reader["DecisionDate"].AsDateTime(),
       DecisionNo = reader["DecisionNo"].AsString(),
       JournalMemo = reader["JournalMemo"].AsString(),
       Posted = reader["Posted"].AsBool(),
       TotalPreAdjustmentAmount = reader["TotalPreAdjustmentAmount"].AsDecimal(),
       TotalAdjustmentAmount = reader["TotalAdjustmentAmount"].AsDecimal(),
       TotalPostAdjustmentAmount = reader["TotalPostAdjustmentAmount"].AsDecimal(),
       PostVersion = reader["PostVersion"].AsInt(),
       EditVersion = reader["EditVersion"].AsInt(),
       ExchangeRate = reader["ExchangeRate"].AsDecimal(),
       CurrencyCode = reader["CurrencyCode"].AsString()
   };
        private static object[] Take(BUPlanAdjustmentEntity bUPlanAdjustmentEntity)
        {
            return new object[]
            {

                "@RefID", bUPlanAdjustmentEntity.RefId,
                "@RefType", bUPlanAdjustmentEntity.RefType,
                "@RefDate", bUPlanAdjustmentEntity.RefDate,
                "@PostedDate", bUPlanAdjustmentEntity.PostedDate,
                "@RefNo", bUPlanAdjustmentEntity.RefNo,
                "@ParalellRefNo", bUPlanAdjustmentEntity.ParalellRefNo,
                "@DecisionDate", bUPlanAdjustmentEntity.DecisionDate,
                "@DecisionNo", bUPlanAdjustmentEntity.DecisionNo,
                "@JournalMemo", bUPlanAdjustmentEntity.JournalMemo,
                "@Posted", bUPlanAdjustmentEntity.Posted,
                "@TotalPreAdjustmentAmount", bUPlanAdjustmentEntity.TotalPreAdjustmentAmount,
                "@TotalAdjustmentAmount", bUPlanAdjustmentEntity.TotalAdjustmentAmount,
                "@TotalPostAdjustmentAmount", bUPlanAdjustmentEntity.TotalPostAdjustmentAmount,
                "@PostVersion", bUPlanAdjustmentEntity.PostVersion,
                "@EditVersion", bUPlanAdjustmentEntity.EditVersion,
                "@ExchangeRate", bUPlanAdjustmentEntity.ExchangeRate,
                "@CurrencyCode", bUPlanAdjustmentEntity.CurrencyCode,
                "@TotalAmount", bUPlanAdjustmentEntity.TotalAmount
            };
        }

        public List<BUPlanAdjustmentEntity> GetBuPlanAdjustmentVoucherbyRefId(string refId)
        {
            throw new NotImplementedException();
        }
    }
}
