using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.General;
namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.General
{
    public interface  IGLVoucherListParamaterDao
    {
        List<GLVoucherListParamaterEntity> GetGlVoucherListParamater(int type);

        List<GLVoucherListDetailEntity> GetGlVoucherListDetailParamaterFilter(string refTypeId, DateTime fromDate,
            DateTime toDate);

    }
}
