using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.General;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.General
{
   public interface IGLVoucherListDao
    {
        GLVoucherListEntity GetGLVoucherListByRefId(string refId);
        GLPaymentListEntity GetGLPaymentListByRefId(string refId);
             
        GLVoucherListEntity GetGLVoucherListByRefNo(string refNo);

        GLVoucherListEntity GetGLVoucherListByRefNo(string refNo, DateTime postedDate);
        GLPaymentListEntity GetGLPaymentListByRefNo(string refNo, DateTime postedDate);

        List<GLVoucherListEntity> GetGLVoucherList();
        List<GLPaymentListEntity> GetGLPaymentList();
      
        List<GLVoucherListEntity> GetGLVouchersByRefTypeId(int refTypeId);
       
        string InsertGLVoucherList(GLVoucherListEntity glVoucherList);
        string InsertGLPaymentList(GLPaymentListEntity glPaymentList);
      
        string UpdateGLVoucherList(GLVoucherListEntity glVoucherList);
        string UpdateGLPaymentList(GLPaymentListEntity glPaymentList);
       
        string DeleteGLVoucherList(GLVoucherListEntity glVoucherList);
        string DeleteGLPaymentList(GLPaymentListEntity glPaymentList);

    }
}
