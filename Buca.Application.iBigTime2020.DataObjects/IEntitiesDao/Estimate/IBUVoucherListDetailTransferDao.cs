/***********************************************************************
 * <copyright file="IBUVoucherListDetailTransferDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUNGDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, May 31, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate
{
    /// <summary>
    ///     IBUVoucherListDetailTransferDao
    /// </summary>
    public interface IBUVoucherListDetailTransferDao
    {
        /// <summary>
        ///     Deletes the ba with draw detail parallel identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        string DeleteBUVoucherListDetailTransferById(string refId);

        /// <summary>
        ///     Gets the ba with draw detail parallelby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     List&lt;BUVoucherListDetailTransferEntity&gt;.
        /// </returns>
        List<BUVoucherListDetailTransferEntity> GetBUVoucherListDetailTransferByRefId(string refId);

        /// <summary>
        ///     Inserts the ba with draw detail parallel.
        /// </summary>
        /// <param name="bUVoucherListDetailTransfer">The with draw detail.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        string InsertBUVoucherListDetailTransfer(BUVoucherListDetailTransferEntity bUVoucherListDetailTransfer);

        /// <summary>
        ///     Updates the ba with draw detail parallel.
        /// </summary>
        /// <param name="bUVoucherListDetailTransfer">The with draw detail.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        string UpdateBUVoucherListDetailTransfer(BUVoucherListDetailTransferEntity bUVoucherListDetailTransfer);
    }
}