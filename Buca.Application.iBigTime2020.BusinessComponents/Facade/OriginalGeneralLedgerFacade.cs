/***********************************************************************
 * <copyright file="OriginalGeneralLedgerFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Wednesday, October 10, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade
{
    /// <summary>
    /// 
    /// </summary>
    public class OriginalGeneralLedgerFacade
    {
        /// <summary>
        /// The original general ledger DAO
        /// </summary>
        private static readonly IOriginalGeneralLedgerDao OriginalGeneralLedgerDao = DataAccess.DataAccess.OriginalGeneralLedgerDao;

        /// <summary>
        /// Gets the search voucher.
        /// </summary>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        public List<OriginalGeneralLedgerEntity> GetSearchVoucher(string whereClause)
        {
            return OriginalGeneralLedgerDao.GetSearchVoucher(whereClause);
        }
    }
}
