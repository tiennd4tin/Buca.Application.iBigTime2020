/***********************************************************************
 * <copyright file="CashWithdrawTypeFacade.cs" company="BUCA JSC">
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
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    ///     CashWithdrawTypeFacade
    /// </summary>
    public class CashWithdrawTypeFacade
    {
        /// <summary>
        ///     The cash withdraw type DAO
        /// </summary>
        private static readonly ICashWithdrawTypeDao CashWithdrawTypeDao = new SqlServerCashWithdrawTypeDao();

        /// <summary>
        ///     Gets the cash withdraw type entities.
        /// </summary>
        /// <returns></returns>
        public IList<CashWithdrawTypeEntity> GetCashWithdrawTypeEntities()
        {
            return CashWithdrawTypeDao.GetCashWithdrawTypes();
        }

        /// <summary>
        ///     Gets the cash withdraw type entity.
        /// </summary>
        /// <param name="cashWithdrawTypeId">The cash withdraw type identifier.</param>
        /// <returns></returns>
        public CashWithdrawTypeEntity GetCashWithdrawTypeEntity(int cashWithdrawTypeId)
        {
            return CashWithdrawTypeDao.GetCashWithdrawType(cashWithdrawTypeId);
        }
    }
}