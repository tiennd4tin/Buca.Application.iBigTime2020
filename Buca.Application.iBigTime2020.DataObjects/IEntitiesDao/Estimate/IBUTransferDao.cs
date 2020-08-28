/***********************************************************************
 * <copyright file="IBUTransferDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, December 13, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, December 13, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate
{
    /// <summary>
    /// Interface IBUTransferDao
    /// </summary>
    public interface IBUTransferDao
    {
        /// <summary>
        /// Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BUTransferEntity.</returns>
        BUTransferEntity GetBUTransferbyRefId(string refId);

        /// <summary>
        /// Gets the bu transfer by bu plan withdraw reference identifier.
        /// </summary>
        /// <param name="BUPlanWithdrawRefId">The bu plan withdraw reference identifier.</param>
        /// <returns></returns>
        BUTransferEntity GetBUTransferByBUPlanWithdrawRefId(string BUPlanWithdrawRefId);

        /// <summary>
        /// Gets the bu transferby reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>BUTransferEntity.</returns>
        BUTransferEntity GetBUTransferbyRefNo(string refNo);

        /// <summary>
        /// Gets the bu transferby reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <returns></returns>
        BUTransferEntity GetBUTransferbyRefNo(string refNo, DateTime postedDate);

        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <returns>List&lt;BUTransferEntity&gt;.</returns>
        List<BUTransferEntity> GetBUTransfer();

        /// <summary>
        /// Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;BUTransferEntity&gt;.</returns>
        List<BUTransferEntity> GetBUTransfersByRefTypeId(int refTypeId);

        /// <summary>
        /// Inserts the bu plan receipt.
        /// </summary>
        /// <param name="bUTransfer">The b u transfer.</param>
        /// <returns>System.String.</returns>
        string InsertBUTransfer(BUTransferEntity bUTransfer);

        /// <summary>
        /// Updates the bu plan receipt.
        /// </summary>
        /// <param name="bUTransfer">The b u transfer.</param>
        /// <returns>System.String.</returns>
        string UpdateBUTransfer(BUTransferEntity bUTransfer);
        
        /// <summary>
        /// Deletes the bu plan receipt.
        /// </summary>
        /// <param name="bUTransfer">The b u transfer.</param>
        /// <returns>System.String.</returns>
        string DeleteBUTransfer(BUTransferEntity bUTransfer);

        /// <summary>
        /// Deletes the bu transfer by bu plan withdraw reference identifier.
        /// </summary>
        /// <param name="buPlanWithdrawRefId">The bu plan withdraw reference identifier.</param>
        /// <returns></returns>
        string DeleteBUTransferByBUPlanWithdrawRefId(BUTransferEntity buPlanWithdrawRefId);
    }
}
