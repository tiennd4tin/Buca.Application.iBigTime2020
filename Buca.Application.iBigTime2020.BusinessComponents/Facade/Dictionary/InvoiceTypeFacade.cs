/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// InvoiceTypeFacade
    /// </summary>
    public class InvoiceTypeFacade
    {
        /// <summary>
        /// The invoice form number category DAO
        /// </summary>
        private static readonly IInvoiceTypeDao InvoiceTypeDao = DataAccess.DataAccess.InvoiceTypeDao;

        /// <summary>
        /// Gets the invoice form number categories.
        /// </summary>
        /// <returns></returns>
        public List<InvoiceTypeEntity> GetInvoiceTypies()
        {
            return InvoiceTypeDao.GetInvoiceTypies();
        }
    }
}
