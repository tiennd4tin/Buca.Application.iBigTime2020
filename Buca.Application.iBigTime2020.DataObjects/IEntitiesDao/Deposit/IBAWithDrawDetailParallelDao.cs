using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit
{
    public interface IBAWithDrawDetailParallelDao
    {
        /// <summary>
        /// Deletes the ba with draw detail parallel identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteBAWithDrawDetailParallelById(string refId);

        /// <summary>
        /// Gets the ba with draw detail parallelby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;BAWithDrawDetailParallelEntity&gt;.</returns>
        List<BAWithDrawDetailParallelEntity> GetBAWithDrawDetailParallelByRefId(string refId);

        /// <summary>
        /// Inserts the ba with draw detail parallel.
        /// </summary>
        /// <param name="withDrawDetail">The with draw detail.</param>
        /// <returns>System.String.</returns>
        string InsertBAWithDrawDetailParallel(BAWithDrawDetailParallelEntity withDrawDetail);

        /// <summary>
        /// Updates the ba with draw detail parallel.
        /// </summary>
        /// <param name="withDrawDetail">The with draw detail.</param>
        /// <returns>System.String.</returns>
        string UpdateBAWithDrawDetailParallel(BAWithDrawDetailParallelEntity withDrawDetail);

    }

}