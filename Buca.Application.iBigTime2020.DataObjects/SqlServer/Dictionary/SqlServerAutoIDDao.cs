/***********************************************************************
 * <copyright file="SqlServerautoIDDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
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
    /// SqlServerautoIDDao
    /// </summary>
    public class SqlServerAutoIDDao : IAutoIDDao
    {
        /// <summary>
        /// Gets the automatic identifier by reference type category.
        /// </summary>
        /// <param name="refTypeCategoryId">The reference type category identifier.</param>
        /// <returns>AutoIDEntity.</returns>
        public AutoIDEntity GetAutoIDByRefTypeCategoryId(int refTypeCategoryId)
        {
            const string procedures = @"uspGet_AutoID_ByRefTypeCategory";
            object[] parms = { "@RefTypeCategoryID", refTypeCategoryId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the automatic numbers.
        /// </summary>
        /// <returns></returns>
        public List<AutoIDEntity> GetAutoIDs()
        {
            const string procedures = @"uspGet_All_AutoID";

            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Updates the automatic number.
        /// </summary>
        /// <param name="autoID">The automatic identifier.</param>
        /// <returns>System.String.</returns>
        public string UpdateAutoID(AutoIDEntity autoID)
        {
            const string sql = @"uspUpdate_AutoID";
            return Db.Update(sql, true, Take(autoID));
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, AutoIDEntity> Make = reader =>
            new AutoIDEntity
            {
                RefTypeCategoryId = reader["RefTypeCategoryID"].AsInt(),
                RefTypeCategoryName = reader["RefTypeCategoryName"].AsString(),
                Prefix = reader["Prefix"].AsString(),
                Value = reader["Value"].AsDecimal(),
                LengthOfValue = reader["LengthOfValue"].AsInt(),
                Suffix = reader["Suffix"].AsString(),
                IsSystem = reader["IsSystem"].AsBool()
            };

        /// <summary>
        /// Takes the specified automatic number.
        /// </summary>
        /// <param name="autoID">The automatic number.</param>
        /// <returns></returns>
        private static object[] Take(AutoIDEntity autoID)
        {
            return new object[]  
            {
                "@RefTypeCategoryID", autoID.RefTypeCategoryId,
                "@RefTypeCategoryName", autoID.RefTypeCategoryName,
                "@Prefix", autoID.Prefix,
                "@Value", autoID.Value,
                "@LengthOfValue", autoID.LengthOfValue,
                "@Suffix", autoID.Suffix,
                "@IsSystem", autoID.IsSystem
            };
        }
    }
}
