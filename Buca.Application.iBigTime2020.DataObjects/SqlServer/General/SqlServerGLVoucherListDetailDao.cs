using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.General;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.General;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.General
{
    public class SqlServerGLVoucherListDetailDao : DaoBase, IGLVoucherListDetailDao
    {
        public string DeleteGLVoucherListDetailByRefId(string refId)
        {
            const string procedures = @"uspDelete_GLVoucherListDetail_ByRefID";

            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }
        public string DeleteGLPaymentListDetailByRefId(string refId)
        {
            const string procedures = @"uspDelete_GLPaymentListDetail_ByRefID";

            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        public List<GLVoucherListDetailEntity> GetGLVoucherListDetailByRefId(string refId)
        {
            const string procedures = @"uspGet_GLVoucherListDetail_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public List<GLPaymentListDetailEntity> GetGLPaymentListDetailByRefId(string refId)
        {
            const string procedures = @"uspGet_GLPaymentListDetail_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make<GLPaymentListDetailEntity>, parms);
        }

        public string InsertGLVoucherListDetail(GLVoucherListDetailEntity glVoucherListDetail)
        {
            const string sql = @"uspInsert_GLVoucherListDetail";
            return Db.Insert(sql, true, Take(glVoucherListDetail));
        }

        public string InsertGLPaymentListDetail(GLPaymentListDetailEntity glPaymentListDetail)
        {
            const string sql = @"uspInsert_GLPaymentListDetail";
            return Db.Insert(sql, true, Take(glPaymentListDetail));
        }

        private object[] Take(GLVoucherListDetailEntity gLVoucherListDetailEntity)
        {
            return new object[]
            {
                "@RefDetailID", gLVoucherListDetailEntity.RefDetailId,
                "@RefID", gLVoucherListDetailEntity.RefId,
                "@DetailRefType", gLVoucherListDetailEntity.DetailRefType,
                "@DetailID", gLVoucherListDetailEntity.DetailId,
                "@SortOrder", gLVoucherListDetailEntity.SortOrder,
                "@EntryType", gLVoucherListDetailEntity.EntryType,
                "@DetailRefID", gLVoucherListDetailEntity.DetailRefId,
            };
        }

        private object[] Take(GLPaymentListDetailEntity gLVoucherListDetailEntity)
        {
            return new object[]
            {
                "@RefDetailID", gLVoucherListDetailEntity.RefDetailId,
                "@RefID", gLVoucherListDetailEntity.RefId,
                "@DetailRefType", gLVoucherListDetailEntity.DetailRefType,
                "@DetailID", gLVoucherListDetailEntity.DetailId,
                "@SortOrder", gLVoucherListDetailEntity.SortOrder,
                "@EntryType", gLVoucherListDetailEntity.EntryType,
                "@DetailRefID", gLVoucherListDetailEntity.DetailRefId,
            };
        }

        private static readonly Func<IDataReader, GLVoucherListDetailEntity> Make = reader =>
    new GLVoucherListDetailEntity
    {
        RefDetailId = reader["RefDetailId"].AsString(),
        RefId = reader["RefId"].AsString(),
        DetailRefType = reader["DetailRefType"].AsInt(),
        DetailId = reader["DetailId"].AsString(),
        SortOrder = reader["SortOrder"].AsInt(),
        EntryType = reader["EntryType"].AsInt(),
        BudgetSourceId = reader["BudgetSourceId"].AsString(),
        RefDate = reader["RefDate"].AsDateTime(),
        PostedDate = reader["PostedDate"].AsDateTime(),
        RefNo = reader["RefNo"].AsString(),
        Description = reader["Description"].AsString(),
        DebitAccount = reader["DebitAccount"].AsString(),
        CreditAccount = reader["CreditAccount"].AsString(),
        Amount = reader["Amount"].AsDecimal(),
        AmountOC = reader["AmountOC"].AsDecimal(),
        DetailRefId = reader["DetailRefID"].AsString(),
        CurrencyCode = reader["CurrencyCode"].AsString(),
        ExchangeRate = reader["ExchangeRate"].AsDecimal(),
    };
    }
}
