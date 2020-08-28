/***********************************************************************
 * <copyright file="IBUVoucherListDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUNGDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, May 28, 2018
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
    ///     IBUVoucherListDetailDao
    /// </summary>
    public interface IBUVoucherListDetailDao
    {
        /// <summary>
        ///     Deletes the bu commitment request detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteBUVoucherListDetail(string refId);

        /// <summary>
        ///     Gets the bu commitment request detailby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;BUCommitmentRequestDetailEntity&gt;.</returns>
        List<BUVoucherListDetailEntity> GetBUVoucherListDetailbyRefId(string refId);

        /// <summary>
        ///     Inserts the bu plan receipt detail.
        /// </summary>
        /// <param name="bUTransferDetail">The b u transfer detail.</param>
        /// <returns>System.String.</returns>
        string InsertBUVoucherListDetail(BUVoucherListDetailEntity bUTransferDetail);

        /// <summary>
        /// Gets the original general ledger not in bu voucher list detail by cash withdraw no.
        /// </summary>
        /// <param name="sashWithdrawNo">The sash withdraw no.</param>
        /// <returns></returns>
        List<BUVoucherListDetailEntity> GetOriginalGeneralLedgerNotInBUVoucherListDetailByCashWithdrawNo(
            string cashWithdrawNo);
    }
}