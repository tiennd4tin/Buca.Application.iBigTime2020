using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash
{
    public interface ICAPaymentDetailParallelDao
    {
        /// <summary>
        /// Deletes the ca payment detail parallel identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteCAPaymentDetailParallelId(string refId);

        /// <summary>
        /// Gets the ca payment detailby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.Collections.Generic.List&lt;Buca.Application.iBigTime2020.BusinessEntities.Business.Cash.CAPaymentDetailParallelEntity&gt;.</returns>
        List<CAPaymentDetailParallelEntity> GetCaPaymentDetailbyRefId(string refId);

        /// <summary>
        /// Inserts the ca payment detail parallel.
        /// </summary>
        /// <param name="caPaymentDetail">The ca payment detail.</param>
        /// <returns>System.String.</returns>
        string InsertCAPaymentDetailParallel(CAPaymentDetailParallelEntity caPaymentDetail);

        /// <summary>
        /// Updates the ca payment detail parallel.
        /// </summary>
        /// <param name="caPaymentDetail">The ca payment detail.</param>
        /// <returns>System.String.</returns>
        string UpdateCAPaymentDetailParallel(CAPaymentDetailParallelEntity caPaymentDetail);

    }

}