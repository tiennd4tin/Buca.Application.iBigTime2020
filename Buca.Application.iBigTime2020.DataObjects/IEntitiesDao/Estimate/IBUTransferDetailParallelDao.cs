using System.Collections.Generic;   
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate
{
    public interface IBUTransferDetailParallelDao
    {
        /// <summary>
        /// Deletes the ba with draw detail parallel identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteBUTransferDetailParallelById(string refId);

        /// <summary>
        /// Gets the ba with draw detail parallelby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;BUTransferDetailParallelEntity&gt;.</returns>
        List<BUTransferDetailParallelEntity> GetBUTransferDetailParallelByRefId(string refId);

        /// <summary>
        /// Inserts the ba with draw detail parallel.
        /// </summary>
        /// <param name="withDrawDetail">The with draw detail.</param>
        /// <returns>System.String.</returns>
        string InsertBUTransferDetailParallel(BUTransferDetailParallelEntity withDrawDetail);

        /// <summary>
        /// Updates the ba with draw detail parallel.
        /// </summary>
        /// <param name="withDrawDetail">The with draw detail.</param>
        /// <returns>System.String.</returns>
        string UpdateBUTransferDetailParallel(BUTransferDetailParallelEntity withDrawDetail);

    }

}