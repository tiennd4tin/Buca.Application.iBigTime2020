using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit
{
    public interface IBABankTransferDetailParallelDao
    {
        /// <summary>
        /// Deletes the ba bank transfer detail parallel by identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteBABankTransferDetailParallelById(string refId);

        /// <summary>
        /// Gets the ba bank transfer detail parallel by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;BABankTransferDetailParallelEntity&gt;.</returns>
        List<BABankTransferDetailParallelEntity> GetBABankTransferDetailParallelByRefId(string refId);

        /// <summary>
        /// Inserts the ba bank transfer detail parallel.
        /// </summary>
        /// <param name="bankTransferDetail">The bank transfer detail.</param>
        /// <returns>System.String.</returns>
        string InsertBABankTransferDetailParallel(BABankTransferDetailParallelEntity bankTransferDetail);

        /// <summary>
        /// Updates the ba bank transfer detail parallel.
        /// </summary>
        /// <param name="bankTransferDetail">The bank transfer detail.</param>
        /// <returns>System.String.</returns>
        string UpdateBABankTransferDetailParallel(BABankTransferDetailParallelEntity bankTransferDetail);

    }

}