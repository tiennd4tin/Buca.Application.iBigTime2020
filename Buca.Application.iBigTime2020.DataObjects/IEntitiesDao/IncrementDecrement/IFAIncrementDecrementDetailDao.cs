/***********************************************************************
 * <copyright file="IFAIncrementDecrementDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.IncrementDecrement;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IncrementDecrement
{
    /// <summary>
    ///     IFAIncrementDecrementDetailDao
    /// </summary>
    public interface IFAIncrementDecrementDetailDao
    {
        /// <summary>
        ///     Gets the bADeposit details by bADeposit.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        List<FAIncrementDecrementDetailEntity> GetFAIncrementDecrementDetailsByRefId(string refId);

        /// <summary>
        ///     Inserts the bADeposit detail.
        /// </summary>
        /// <param name="fAIncrementDecrementDetail">The bADeposit detail.</param>
        /// <returns></returns>
        string InsertFAIncrementDecrementDetail(FAIncrementDecrementDetailEntity fAIncrementDecrementDetail);

        /// <summary>
        ///     Deletes the bADeposit detail by bADeposit identifier.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        string DeleteFAIncrementDecrementDetailByRefId(string refId);
    }
}