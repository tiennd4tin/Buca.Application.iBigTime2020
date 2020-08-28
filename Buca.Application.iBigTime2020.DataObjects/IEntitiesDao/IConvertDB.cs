/***********************************************************************
 * <copyright file="CommonDao.cs" company="BUCA JSC">
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

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao
{
    public interface IConvertDB
    {
        
        
        string ConvertDB(string source_ServerName, string source_Database,string destin_ServerName,string destin_DataBase,string storeProcedure );

    }
}
