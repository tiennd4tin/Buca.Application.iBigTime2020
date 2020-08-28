
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash
{
  public interface ICAPaymentDetailTaxDao
  {

      List<CAPaymentDetailTaxEntity> GetCaPaymentDetailTaxByRefId(string refId);
      string InsertCAPaymentDetailTax(CAPaymentDetailTaxEntity paymentDetailTaxEntity);
        string UpdateCAPaymentDetailTax(CAPaymentDetailTaxEntity paymentDetailTaxEntity);
      string DeleteCAPaymentDetailTax(string refId);
  }
}
