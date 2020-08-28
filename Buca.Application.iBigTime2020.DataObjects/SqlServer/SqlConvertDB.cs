/***********************************************************************
 * <copyright file="SqlCommonDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Friday, May 30, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataHelpers;


namespace Buca.Application.iBigTime2020.DataAccess.SqlServer
{
    /// <summary>
    /// class SqlCommonDao
    /// </summary>
    public class SqlConvertDB : IConvertDB
    {
        public string ConvertDB(string source_ServerName, string source_Database, string destin_ServerName, string destin_DataBase, string storeProcedure)
        {
            const string sql = "usp_ConvertDB";
            object[] parms = 
              { "@source_ServerName", source_ServerName,
                "@source_Database", source_Database,
                "@destin_ServerName", destin_ServerName,
                "@destin_DataBase", destin_DataBase ,
                "@storeProcedure", storeProcedure ,

              };
            return Db.ConvertDB(sql, true, parms);
        }

       
    }
}
