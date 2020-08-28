/***********************************************************************
 * <copyright file="ibadepositdetailtaxdao.cs" company="BUCA JSC">
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
    ///     IBADepositDetailTaxDao
    /// </summary>
    public interface IBADepositDetailTaxDao
    {
        /// <summary>
        ///     Gets the bADeposit details by bADeposit.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        List<BADepositDetailTaxEntity> GetBADepositDetailTaxsByRefId(string refId);

        /// <summary>
        ///     Inserts the bADeposit detail.
        /// </summary>
        /// <param name="bADepositDetailTax">The bADeposit detail.</param>
        /// <returns></returns>
        string InsertBADepositDetailTax(BADepositDetailTaxEntity bADepositDetailTax);

        /// <summary>
        ///     Deletes the bADeposit detail by bADeposit identifier.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        string DeleteBADepositDetailTaxByRefId(string refId);
    }
}