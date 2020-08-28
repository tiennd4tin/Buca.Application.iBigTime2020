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
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// SqlServerRefTypeDao
    /// </summary>
    public class SqlServerRefTypeCategoryDao : IRefTypeCategoryDao
    {
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, RefTypeCategoryEntity> Make = reader =>
           new RefTypeCategoryEntity
           {
               RefTypeCategoryId = reader["RefTypeCategoryId"].AsInt(),
               RefTypeCategoryName = reader["RefTypeCategoryName"].AsString(),
               DefaultDebitAccountId = reader["DefaultDebitAccountId"].AsString(),
               DefaultCreditAccountId = reader["DefaultCreditAccountId"].AsString()
           };

        /// <summary>
        /// Gets the reference type category by reference type category identifier.
        /// </summary>
        /// <param name="reftypeCategoryId">The reftype category identifier.</param>
        /// <returns>RefTypeCategoryEntity.</returns>
        public RefTypeCategoryEntity GetRefTypeCategoryByRefTypeCategoryId(int reftypeCategoryId)
        {
            const string sql = @"uspGet_RefTypeCategory_ByRefTypeCategoryID";
            object[] parms = { "@RefTypeCategoryID", reftypeCategoryId };
            return Db.Read(sql, true, Make, parms);
        }
    }
}
