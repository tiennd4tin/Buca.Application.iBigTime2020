/***********************************************************************
 * <copyright file="SqlServerDBOptionDao.cs" company="BUCA JSC">
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
    /// SqlServerDBOptionDao
    /// </summary>
    public class SqlServerDBOptionDao : IDBOptionDao
    {
        /// <summary>
        /// Gets the database option.
        /// </summary>
        /// <param name="dBOptionId">The d b option identifier.</param>
        /// <returns></returns>
        public DBOptionEntity GetDBOption(string dBOptionId)
        {
            const string sql = @"uspGet_DBOption_ByID";

            object[] parms = { "@OptionID", dBOptionId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the database options.
        /// </summary>
        /// <returns></returns>
        public List<DBOptionEntity> GetDBOptions()
        {
            const string procedures = @"uspGet_All_DBOption";
            return Db.ReadList(procedures, true, Make);
        }

        public List<DBOptionEntity> GetOptionsForDbInfo()
        {
            const string procedures = @"uspGet_All_DBOption_ForDbInfo";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the database options by system.
        /// </summary>
        /// <param name="isSystem">if set to <c>true</c> [is system].</param>
        /// <returns></returns>
        public List<DBOptionEntity> GetDBOptionsBySystem(bool isSystem)
        {
            const string procedures = @"uspGet_DBOption_IsSystem";

            object[] parms = { "@IsSystem", isSystem };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the type of the database options by value.
        /// </summary>
        /// <param name="valueType">Type of the value.</param>
        /// <returns></returns>
        public List<DBOptionEntity> GetDBOptionsByValueType(int valueType)
        {
            const string procedures = @"uspGet_DBOption_ByValueType";

            object[] parms = { "@ValueType", valueType };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Updates the database option.
        /// </summary>
        /// <param name="dBOption">The d b option.</param>
        /// <returns></returns>
        public string UpdateDBOption(DBOptionEntity dBOption)
        {
            const string sql = @"uspUpdate_DBOption";
            return Db.Update(sql, true, Take(dBOption));
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, DBOptionEntity> Make = reader =>
            new DBOptionEntity
            {
                OptionId = reader["OptionID"].AsString(),
                OptionValue = reader["OptionValue"].AsString(),
                ValueType = reader["ValueType"].AsInt(),
                Description = reader["Description"].AsString(),
                IsSystem = reader["IsSystem"].AsBool()
            };

        /// <summary>
        /// Takes the specified bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns></returns>
        private static object[] Take(DBOptionEntity bank)
        {
            return new object[]  
            {
                "@OptionID", bank.OptionId,
                "@OptionValue", bank.OptionValue,
                "@ValueType", bank.ValueType,
                "@Description", bank.Description,
                "@IsSystem", bank.IsSystem
            };
        }
    }
}