using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash
{

    public interface ICAPaymentDetailDao
    {
        string DeleteCAPaymentDetailId(string refId);
        List<CAPaymentDetailEntity> GetCaPaymentDetailbyRefId(string refId);
   

        string InsertCAPaymentDetail(CAPaymentDetailEntity caPaymentDetail);

        string UpdateCAPaymentDetail(CAPaymentDetailEntity caPaymentDetail);

    }

}