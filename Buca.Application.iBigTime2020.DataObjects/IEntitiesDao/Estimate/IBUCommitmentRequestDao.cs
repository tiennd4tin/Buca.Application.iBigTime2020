using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate
{
    public interface IBUCommitmentRequestDao
    {
        /// <summary>
        /// Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        BUCommitmentRequestEntity GetBUCommitmentRequestbyRefId(string refId);

        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <returns></returns>
        List<BUCommitmentRequestEntity> GetBUCommitmentRequest();

        /// <summary>
        /// Gets the bu plan receipt entity.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        List<BUCommitmentRequestEntity> GetBUCommitmentRequest(string refTypeId);


        /// <summary>
        /// Gets the bu commitment request by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>BUCommitmentRequestEntity.</returns>
        BUCommitmentRequestEntity GetBUCommitmentRequestByRefNo(string refNo);

        /// <summary>
        /// Gets the bu commitment request by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>BUCommitmentRequestEntity.</returns>
        BUCommitmentRequestEntity GetBUCommitmentRequestByRefNo(string refNo, DateTime postedDate);

        /// <summary>
        /// Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        List<BUCommitmentRequestEntity> GetBUCommitmentRequestsByRefTypeId(int refTypeId);

        /// <summary>
        /// Inserts the bu plan receipt.
        /// </summary>
        /// <param name="buPlanReceipt">The bu plan receipt.</param>
        /// <returns></returns>
        string InsertBUCommitmentRequest (BUCommitmentRequestEntity bUCommitmentRequest);

        /// <summary>
        /// Updates the bu plan receipt.
        /// </summary>
        /// <param name="buPlanReceipt">The bu plan receipt.</param>
        /// <returns></returns>
        string UpdateBUCommitmentRequest (BUCommitmentRequestEntity bUCommitmentRequest);


        /// <summary>
        /// Deletes the bu plan receipt.
        /// </summary>
        /// <param name="buPlanReceipt">The bu plan receipt.</param>
        /// <returns></returns>
        string DeleteBUCommitmentRequest (BUCommitmentRequestEntity bUCommitmentRequest);
    }
}
