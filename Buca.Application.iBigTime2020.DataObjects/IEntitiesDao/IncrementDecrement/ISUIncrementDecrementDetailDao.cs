/***********************************************************************
 * <copyright file="ISUIncrementDecrementDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Wednesday, October 25, 2017
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
    ///     ISUIncrementDecrementDetailDao
    /// </summary>
    public interface ISUIncrementDecrementDetailDao
    {
        /// <summary>
        ///     Gets the bADeposit details by bADeposit.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        List<SUIncrementDecrementDetailEntity> GetSUIncrementDecrementDetailsByRefId(string refId);

        /// <summary>
        ///     Inserts the bADeposit detail.
        /// </summary>
        /// <param name="sUIncrementDecrementDetail">The bADeposit detail.</param>
        /// <returns></returns>
        string InsertSUIncrementDecrementDetail(SUIncrementDecrementDetailEntity sUIncrementDecrementDetail);

        /// <summary>
        ///     Deletes the bADeposit detail by bADeposit identifier.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        string DeleteSUIncrementDecrementDetailByRefId(string refId);
    }
}