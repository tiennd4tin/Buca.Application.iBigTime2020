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

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// SqlServerInvoiceFormNumberCategoryDao
    /// </summary>
    public class SqlServerInvoiceTypeDao : IInvoiceTypeDao
    {
        /// <summary>
        /// Gets the invoice form number categories.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<InvoiceTypeEntity> GetInvoiceTypies()
        {
            const string sql = @"uspGet_All_InvoiceType";
            return Db.ReadList(sql, true, Make);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, InvoiceTypeEntity> Make = reader =>
            new InvoiceTypeEntity
            {
                InvoiceTypeId = reader["InvoiceTypeID"].AsInt(),
                InvoiceTypeCode = reader["InvoiceTypeCode"].AsString(),
                InvoiceTypeName = reader["InvoiceTypeName"].AsString(),
                Description = reader["Description"].AsString(),
                IsActive = reader["IsActive"].AsBool()
            };
    }
}
