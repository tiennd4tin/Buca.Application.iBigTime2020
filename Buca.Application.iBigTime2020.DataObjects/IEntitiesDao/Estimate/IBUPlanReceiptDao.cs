using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate
{
    /// <summary>
    /// IBUPlanReceiptDao
    /// </summary>
    public interface IBUPlanReceiptDao
    {
        /// <summary>
        /// Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        BUPlanReceiptEntity GetBUPlanReceiptEntitybyRefId(string refId);

        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <returns></returns>
        List<BUPlanReceiptEntity> GetBUPlanReceipt();

        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        BUPlanReceiptEntity GetBUPlanReceipt(string refNo);

        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        BUPlanReceiptEntity GetBUPlanReceipt(string refNo, DateTime postedDate);

        /// <summary>
        /// Gets the bu plan receipt entity.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        List<BUPlanReceiptEntity> GetBUPlanReceiptEntity(string refTypeId);

        /// <summary>
        /// Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        List<BUPlanReceiptEntity> GetBUPlanReceiptsByRefTypeId(int refTypeId);

        /// <summary>
        /// Inserts the bu plan receipt.
        /// </summary>
        /// <param name="buPlanReceipt">The bu plan receipt.</param>
        /// <returns></returns>
        string InsertBUPlanReceipt(BUPlanReceiptEntity buPlanReceipt);

        /// <summary>
        /// Updates the bu plan receipt.
        /// </summary>
        /// <param name="buPlanReceipt">The bu plan receipt.</param>
        /// <returns></returns>
        string UpdateBUPlanReceipt(BUPlanReceiptEntity buPlanReceipt);


        /// <summary>
        /// Deletes the bu plan receipt.
        /// </summary>
        /// <param name="buPlanReceipt">The bu plan receipt.</param>
        /// <returns></returns>
        string DeleteBUPlanReceipt(BUPlanReceiptEntity buPlanReceipt);

    }
}
