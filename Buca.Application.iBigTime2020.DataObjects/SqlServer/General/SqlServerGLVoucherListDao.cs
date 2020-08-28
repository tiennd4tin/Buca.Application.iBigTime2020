using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.General;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.General;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.General
{
    public class SqlServerGLVoucherListDao : DaoBase, IGLVoucherListDao
    {
        public string DeleteGLVoucherList(GLVoucherListEntity glVoucherList)
        {
            const string sql = @"uspDelete_GlVoucherList";

            object[] parms = { "@RefID", glVoucherList.RefId };
            return Db.Delete(sql, true, parms);
        }
        public string DeleteGLPaymentList(GLPaymentListEntity glPaymentList)
        {
            const string sql = @"uspDelete_GlPaymentList";

            object[] parms = { "@RefID", glPaymentList.RefId };
            return Db.Delete(sql, true, parms);
        }

        public List<GLVoucherListEntity> GetGLVoucherList()
        {
            const string procedures = @"uspGet_All_GLVoucherList";
            return Db.ReadList(procedures, true, Make);
        }

        public List<GLPaymentListEntity> GetGLPaymentList()
        {
            const string procedures = @"uspGet_All_GLPaymentList";
            return Db.ReadList(procedures, true, Make<GLPaymentListEntity>);
        }

        public GLVoucherListEntity GetGLVoucherListByRefId(string refId)
        {
            const string procedures = @"uspGet_GLVoucherList_ByRefID";

            object[] parms = { "@RefID", refId };
            return Db.Read(procedures, true, Make, parms);
        }

        public GLPaymentListEntity GetGLPaymentListByRefId(string refId)
        {
            const string procedures = @"uspGet_GLPaymentList_ByRefID";

            object[] parms = { "@RefID", refId };
            return Db.Read(procedures, true, Make<GLPaymentListEntity>, parms);
        }

        public GLVoucherListEntity GetGLVoucherListByRefNo(string refNo)
        {
            const string procedures = @"uspGet_GLVoucherList_ByRefNo";

            object[] parms = { "@RefNo", refNo };
            return Db.Read(procedures, true, Make, parms);
        }

        public GLVoucherListEntity GetGLVoucherListByRefNo(string refNo, DateTime postedDate)
        {
            const string procedures = @"uspGet_GLVoucherList_ByRefNoAndPostedDate";

            object[] parms = { "@RefNo", refNo, "@PostedDate", postedDate };
            return Db.Read(procedures, true, Make, parms);
        }

        public GLPaymentListEntity GetGLPaymentListByRefNo(string refNo, DateTime postedDate)
        {
            const string procedures = @"uspGet_GLPaymentList_ByRefNoAndPostedDate";

            object[] parms = { "@RefNo", refNo, "@PostedDate", postedDate };
            return Db.Read(procedures, true, Make<GLPaymentListEntity>, parms);
        }

        public List<GLVoucherListEntity> GetGLVouchersByRefTypeId(int refTypeId)
        {
            throw new NotImplementedException();
        }

        public string InsertGLVoucherList(GLVoucherListEntity glVoucherList)
        {
            const string sql = @"uspInsert_GLVoucherList";
            return Db.Insert(sql, true, Take(glVoucherList));
        }

        public string InsertGLPaymentList(GLPaymentListEntity glPaymentList)
        {
            const string sql = @"uspInsert_GLPaymentList";
            return Db.Insert(sql, true, Take(glPaymentList));
        }

        public string UpdateGLVoucherList(GLVoucherListEntity glVoucherList)
        {
            const string sql = @"uspUpdate_GLVoucherList";
            return Db.Update(sql, true, Take(glVoucherList));
        }

        public string UpdateGLPaymentList(GLPaymentListEntity glPaymentList)
        {
            const string sql = @"uspUpdate_GLPaymentList";
            return Db.Update(sql, true, Take(glPaymentList));
        }

        private static readonly Func<IDataReader, GLVoucherListEntity> Make = reader =>
   new GLVoucherListEntity
   {
       RefId = reader["RefID"].AsString(),
       RefType = reader["RefType"].AsInt(),
       RefDate = reader["RefDate"].AsDateTime(),
       RefNo = reader["RefNo"].AsString(),
       VoucherTypeId = reader["VoucherTypeID"].AsString(),
       SetupType = reader["SetupType"].AsShort(),
       FromDate = reader["FromDate"].AsDateTime(),
       ToDate = reader["ToDate"].AsDateTime(),
       Description = reader["Description"].AsString(),
       TotalAmount = reader["TotalAmount"].AsDecimal(),
       EditVersion = reader["EditVersion"].AsInt(),

   };

        private static object[] Take(GLVoucherListEntity gLVoucherListEntity)
        {
            return new object[]
            {

                "@RefID", gLVoucherListEntity.RefId,
                "@RefType", gLVoucherListEntity.RefType,
                "@RefDate", gLVoucherListEntity.RefDate,
                "@RefNo", gLVoucherListEntity.RefNo,
                "@VoucherTypeID", gLVoucherListEntity.VoucherTypeId,
                "@SetupType", gLVoucherListEntity.SetupType,            
                "@Description", gLVoucherListEntity.Description,
                "@TotalAmount", gLVoucherListEntity.TotalAmount,
                "@EditVersion", gLVoucherListEntity.EditVersion,
            };
        }

        private static object[] Take(GLPaymentListEntity gLVoucherListEntity)
        {
            return new object[]
            {

                "@RefID", gLVoucherListEntity.RefId,
                "@RefType", gLVoucherListEntity.RefType,
                "@RefDate", gLVoucherListEntity.RefDate,
                "@PostedDate", gLVoucherListEntity.PostedDate,
                "@RefNo", gLVoucherListEntity.RefNo,
                "@VoucherTypeID", gLVoucherListEntity.VoucherTypeId,
                "@SetupType", gLVoucherListEntity.SetupType,            
                "@Description", gLVoucherListEntity.Description,
                "@TotalAmount", gLVoucherListEntity.TotalAmount,
                "@EditVersion", gLVoucherListEntity.EditVersion,
            };
        }

    }
}
