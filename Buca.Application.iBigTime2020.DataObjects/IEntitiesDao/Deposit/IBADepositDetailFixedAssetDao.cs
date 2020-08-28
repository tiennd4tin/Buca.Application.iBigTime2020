/***********************************************************************
 * <copyright file="ibadepositdetailfixedassetdao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Wednesday, October 18, 2017
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
    ///     IBADepositDetailFixedAssetDao
    /// </summary>
    public interface IBADepositDetailFixedAssetDao
    {
        /// <summary>
        ///     Gets the bADeposit details by bADeposit.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        List<BADepositDetailFixedAssetEntity> GetBADepositDetailFixedAssetsByRefId(string refId);

        /// <summary>
        ///     Inserts the bADeposit detail.
        /// </summary>
        /// <param name="bADepositDetailFixedAsset">The bADeposit detail.</param>
        /// <returns></returns>
        string InsertBADepositDetailFixedAsset(BADepositDetailFixedAssetEntity bADepositDetailFixedAsset);

        /// <summary>
        ///     Deletes the bADeposit detail by bADeposit identifier.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        string DeleteBADepositDetailFixedAssetByRefId(string refId);
    }
}