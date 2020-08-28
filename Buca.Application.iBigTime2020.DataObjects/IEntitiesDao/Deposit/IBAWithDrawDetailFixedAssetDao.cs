/***********************************************************************
 * <copyright file="IBAWithDrawDetailFixedAssetDao.cs" company="BUCA JSC">
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
    ///     IBAWithDrawDetailFixedAssetFixedAssetDao
    /// </summary>
    public interface IBAWithDrawDetailFixedAssetDao
    {
        /// <summary>
        ///     Gets the bADeposit details by bADeposit.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        List<BAWithDrawDetailFixedAssetEntity> GetBAWithDrawDetailFixedAssetEntitysByRefId(string refId);

        /// <summary>
        ///     Inserts the bADeposit detail.
        /// </summary>
        /// <param name="bAWithDrawDetailFixedAssetEntity">The bADeposit detail.</param>
        /// <returns></returns>
        string InsertBAWithDrawDetailFixedAssetEntity(
            BAWithDrawDetailFixedAssetEntity bAWithDrawDetailFixedAssetEntity);

        /// <summary>
        ///     Deletes the bADeposit detail by bADeposit identifier.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        string DeleteBAWithDrawDetailFixedAssetEntityByRefId(string refId);
    }
}