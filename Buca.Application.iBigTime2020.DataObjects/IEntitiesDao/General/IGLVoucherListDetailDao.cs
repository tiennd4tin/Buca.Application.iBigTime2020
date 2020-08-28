using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.General;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.General
{
   public interface IGLVoucherListDetailDao
    {
     
        List<GLVoucherListDetailEntity> GetGLVoucherListDetailByRefId(string refId);
        List<GLPaymentListDetailEntity> GetGLPaymentListDetailByRefId(string refId);
        string InsertGLVoucherListDetail(GLVoucherListDetailEntity glVoucherListDetail);
        string InsertGLPaymentListDetail(GLPaymentListDetailEntity glPaymentListDetail);
        string DeleteGLVoucherListDetailByRefId(string refId);
        string DeleteGLPaymentListDetailByRefId(string refId);
    }
}
