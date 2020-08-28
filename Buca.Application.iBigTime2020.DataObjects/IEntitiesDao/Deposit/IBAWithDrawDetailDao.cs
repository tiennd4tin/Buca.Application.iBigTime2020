/***********************************************************************
 * <copyright file="IBAWithDrawDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 23, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit
{
    /// <summary>
    ///     IBAWithDrawDetailDao
    /// </summary>
    public interface IBAWithDrawDetailDao
    {
        /// <summary>
        ///     Gets the bADeposit details by bADeposit.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        List<BAWithDrawDetailEntity> GetBAWithDrawDetailEntitysByRefId(string refId);

        /// <summary>
        ///     Inserts the bADeposit detail.
        /// </summary>
        /// <param name="bAWithDrawDetailEntity">The bADeposit detail.</param>
        /// <returns></returns>
        string InsertBAWithDrawDetailEntity(BAWithDrawDetailEntity bAWithDrawDetailEntity);

        /// <summary>
        ///     Deletes the bADeposit detail by bADeposit identifier.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        string DeleteBAWithDrawDetailEntityByRefId(string refId);
    }
}