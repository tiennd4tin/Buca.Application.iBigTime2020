using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash
{
    public interface ICAReceiptDetailParallelDao
    {
        /// <summary>
        /// Deletes the ca payment detail parallel identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteCAReceiptDetailParallelId(string refId);

        /// <summary>
        /// Gets the ca receipt detail parallelby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;CAReceiptDetailParallelEntity&gt;.</returns>
        List<CAReceiptDetailParallelEntity> GetCAReceiptDetailParallelbyRefId(string refId);

        /// <summary>
        /// Inserts the ca payment detail parallel.
        /// </summary>
        /// <param name="receiptDetail">The ca payment detail.</param>
        /// <returns>System.String.</returns>
        string InsertCAReceiptDetailParallel(CAReceiptDetailParallelEntity receiptDetail);

        /// <summary>
        /// Updates the ca payment detail parallel.
        /// </summary>
        /// <param name="receiptDetail">The ca payment detail.</param>
        /// <returns>System.String.</returns>
        string UpdateCAReceiptDetailParallel(CAReceiptDetailParallelEntity receiptDetail);

    }

}