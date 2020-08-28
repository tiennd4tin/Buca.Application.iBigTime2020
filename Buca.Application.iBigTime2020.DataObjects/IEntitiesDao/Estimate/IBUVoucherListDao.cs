/***********************************************************************
 * <copyright file="IBUVoucherListDao.cs" company="BUCA JSC">
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

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate
{
    /// <summary>
    ///     IBUVoucherListDao
    /// </summary>
    public interface IBUVoucherListDao
    {
        /// <summary>
        ///     Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     BUVoucherListEntity.
        /// </returns>
        BUVoucherListEntity GetBUVoucherListByRefId(string refId);

        /// <summary>
        ///     Gets the bu transferby reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>
        ///     BUVoucherListEntity.
        /// </returns>
        BUVoucherListEntity GetBUVoucherListByRefNo(string refNo);

        /// <summary>
        ///     Gets the bu voucher listby reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <returns></returns>
        BUVoucherListEntity GetBUVoucherListByRefNo(string refNo, DateTime postedDate);

        /// <summary>
        ///     Gets the bu plan receipt.
        /// </summary>
        /// <returns>
        ///     List&lt;BUVoucherListEntity&gt;.
        /// </returns>
        List<BUVoucherListEntity> GetBUVoucherList();

        /// <summary>
        ///     Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        ///     List&lt;BUVoucherListEntity&gt;.
        /// </returns>
        List<BUVoucherListEntity> GetBUVoucherListsByRefTypeId(int refTypeId);

        /// <summary>
        ///     Inserts the bu plan receipt.
        /// </summary>
        /// <param name="bUVoucherListEntity">The b u transfer.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        string InsertBUVoucherList(BUVoucherListEntity bUVoucherListEntity );

        /// <summary>
        ///     Updates the bu plan receipt.
        /// </summary>
        /// <param name="bUVoucherListEntity">The b u transfer.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        string UpdateBUVoucherList(BUVoucherListEntity bUVoucherListEntity);

        /// <summary>
        ///     Deletes the bu plan receipt.
        /// </summary>
        /// <param name="bUVoucherListEntity">The b u transfer.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        string DeleteBUVoucherList(BUVoucherListEntity bUVoucherListEntity);
    }
}