/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 27, 2017
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
    /// ISUTransferDetailDao
    /// </summary>
    public interface ISUTransferDetailDao
    {
        /// <summary>
        /// Gets the bADeposit details by bADeposit.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        List<SUTransferDetailEntity> GetSUTransferDetailsByRefId(string refId);

        /// <summary>
        /// Inserts the bADeposit detail.
        /// </summary>
        /// <param name="suTransferDetail">The su transfer detail.</param>
        /// <returns></returns>
        string InsertSUTransferDetail(SUTransferDetailEntity suTransferDetail);

        /// <summary>
        /// Deletes the bADeposit detail by bADeposit identifier.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        string DeleteSUTransferDetailByRefId(string refId);
    }
}
