using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash
{
    /// <summary>
    /// ICAPaymentDao
    /// </summary>
    public interface ICAPaymentDao
    {
        /// <summary>
        /// Gets the ca payment entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        CAPaymentEntity GetCaPaymentEntitybyRefId(string refId);

        /// <summary>
        /// Gets the ca payment entityby reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refType">Type of the reference.</param>
        /// <returns>CAPaymentEntity.</returns>
        CAPaymentEntity GetCaPaymentEntitybyRefNo(string refNo, int refType);

        /// <summary>
        /// Gets the ca payment.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <returns></returns>
        CAPaymentEntity GetCaPayment(string refNo, DateTime postedDate);

        /// <summary>
        /// Gets the ca payment.
        /// </summary>
        /// <returns></returns>
        List<CAPaymentEntity> GetCaPayment();

        /// <summary>
        /// Gets the ca payments by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        List<CAPaymentEntity> GetCaPaymentsByRefTypeId(int refTypeId);

        /// <summary>
        /// Inserts the ca payment.
        /// </summary>
        /// <param name="caPayment">The ca payment.</param>
        /// <returns></returns>
        string InsertCAPayment(CAPaymentEntity caPayment);

        /// <summary>
        /// Updates the ca payment.
        /// </summary>
        /// <param name="caPayment">The ca payment.</param>
        /// <returns></returns>
        string UpdateCAPayment(CAPaymentEntity caPayment);

        /// <summary>
        /// Deletes the ca payment.
        /// </summary>
        /// <param name="caPayment">The ca payment.</param>
        /// <returns></returns>
        string DeleteCAPayment(CAPaymentEntity caPayment);

        /// <summary>
        /// Deletes the ca payment by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        string DeleteCAPaymentByRefId(string refId);

    }

}