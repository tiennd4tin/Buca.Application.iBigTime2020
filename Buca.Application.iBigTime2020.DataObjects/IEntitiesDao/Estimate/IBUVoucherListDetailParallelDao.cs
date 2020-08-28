/***********************************************************************
 * <copyright file="IBUVoucherListDetailParallelDao.cs" company="BUCA JSC">
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
    ///     IBUVoucherListDetailParallelDao
    /// </summary>
    public interface IBUVoucherListDetailParallelDao
    {
        /// <summary>
        ///     Deletes the ba with draw detail parallel identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteBUVoucherListDetailParallelById(string refId);

        /// <summary>
        ///     Gets the ba with draw detail parallelby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;BUVoucherListDetailParallelEntity&gt;.</returns>
        List<BUVoucherListDetailParallelEntity> GetBUVoucherListDetailParallelByRefId(string refId);

        /// <summary>
        ///     Inserts the ba with draw detail parallel.
        /// </summary>
        /// <param name="bUVoucherListDetailParallelEntity">The with draw detail.</param>
        /// <returns>System.String.</returns>
        string InsertBUVoucherListDetailParallel(BUVoucherListDetailParallelEntity bUVoucherListDetailParallelEntity);

        /// <summary>
        ///     Updates the ba with draw detail parallel.
        /// </summary>
        /// <param name="bUVoucherListDetailParallelEntity">The with draw detail.</param>
        /// <returns>System.String.</returns>
        string UpdateBUVoucherListDetailParallel(BUVoucherListDetailParallelEntity bUVoucherListDetailParallelEntity);
    }
}