
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash
{
    public interface ICAPaymentDetailPurchaseDao
    {
        /// <summary>
        /// Gets the ca payment detail purchases by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.Collections.Generic.List&lt;Buca.Application.iBigTime2020.BusinessEntities.Business.Cash.CAPaymentDetailPurchaseEntity&gt;.</returns>
        List<CAPaymentDetailPurchaseEntity> GetCAPaymentDetailPurchasesByRefId(string refId);

        /// <summary>
        /// Inserts the ca payment detail purchase.
        /// </summary>
        /// <param name="paymentDetailPurchaseEntity">The payment detail purchase entity.</param>
        /// <returns>System.String.</returns>
        string InsertCAPaymentDetailPurchase(CAPaymentDetailPurchaseEntity paymentDetailPurchaseEntity);

        /// <summary>
        /// Deletes the ca payment detail purchase.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteCAPaymentDetailPurchase(string refId);
    }
}
