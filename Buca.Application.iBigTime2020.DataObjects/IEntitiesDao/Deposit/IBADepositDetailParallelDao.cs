using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit
{
    /// <summary>
    /// Interface IBADepositDetailParallelDao
    /// </summary>
    public interface IBADepositDetailParallelDao
    {
        /// <summary>
        /// Deletes the ba deposit detail parallel identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteBADepositDetailParallelById(string refId);

        /// <summary>
        /// Gets the ca payment detailby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;BADepositDetailParallelEntity&gt;.</returns>
        List<BADepositDetailParallelEntity> GetBADepositDetailParallelByRefId(string refId);

        /// <summary>
        /// Inserts the ba deposit detail parallel.
        /// </summary>
        /// <param name="depositDetail">The deposit detail.</param>
        /// <returns>System.String.</returns>
        string InsertBADepositDetailParallel(BADepositDetailParallelEntity depositDetail);

        /// <summary>
        /// Updates the ba deposit detail parallel.
        /// </summary>
        /// <param name="depositDetail">The deposit detail.</param>
        /// <returns>System.String.</returns>
        string UpdateBADepositDetailParallel(BADepositDetailParallelEntity depositDetail);
    }
}