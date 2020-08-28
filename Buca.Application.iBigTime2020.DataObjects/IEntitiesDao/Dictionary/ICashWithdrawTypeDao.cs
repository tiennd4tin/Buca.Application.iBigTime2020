/***********************************************************************
 * <copyright file="ICashWithdrawTypeDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Friday, September 29, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    ///     ICashWithdrawTypeDao
    /// </summary>
    public interface ICashWithdrawTypeDao
    {
        /// <summary>
        ///     Gets the cashWithdrawType.
        /// </summary>
        /// <param name="cashWithdrawTypeId">The cashWithdrawType identifier.</param>
        /// <returns></returns>
        CashWithdrawTypeEntity GetCashWithdrawType(int cashWithdrawTypeId);

        /// <summary>
        ///     Gets the cashWithdrawTypes.
        /// </summary>
        /// <returns></returns>
        List<CashWithdrawTypeEntity> GetCashWithdrawTypes();
    }
}