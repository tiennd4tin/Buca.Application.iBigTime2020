/***********************************************************************
 * <copyright file="SqlServerAudittingLogDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 12 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;
using System.Data;


namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// Class SqlServerAudittingLogDao.
    /// </summary>
    public class SqlServerAudittingLogDao : IAudittingLogDao
    {
        /// <summary>
        /// Gets the auditting logs.
        /// </summary>
        /// <returns></returns>
        public List<AudittingLogEntity> GetAudittingLogs()
        {
            const string procedures = @"IuspGet_All_AudittingLog";
            return Db.ReadList(procedures, true, Make);
        }


        /// <summary>
        /// Gets the auditting log.
        /// </summary>
        /// <param name="eventId">The event identifier.</param>
        /// <returns></returns>
        public AudittingLogEntity GetAudittingLog_by_eventId(string eventId)
        {
            const string sql = @"uspGet_AudittingLog_ByID";

            object[] parms = { "@EventId", eventId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the auditting log.
        /// </summary>
        /// <param name="audittingLog">The auditting log.</param>
        /// <returns></returns>
        public string InsertAudittingLog(AudittingLogEntity audittingLog)
        {
            const string sql = @"Insert_AudittingLog";
            return Db.Insert(sql, true, Take(audittingLog));
        }

        /// <summary>
        /// Deletes the auditting log.
        /// </summary>
        /// <param name="audittingLog">The auditting log.</param>
        /// <returns></returns>
        public string DeleteAudittingLog(AudittingLogEntity audittingLog)
        {
            const string sql = @"uspDelete_AudittingLog";

            object[] parms = { "@EventID", audittingLog.EventId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, AudittingLogEntity> Make = reader =>
            new AudittingLogEntity
            {
                EventId = reader["EventId"].AsString(),
                LoginName = reader["LoginName"].AsString(),
                ComputerName = reader["ComputerName"].AsString(),
                Amount = reader["Amount"].AsDecimal(),
                Reference = reader["Reference"].AsString(),
                ComponentName = reader["ComponentName"].AsString(),
               
                EventAction = reader["EventAction"].AsInt(),
                EventTime = reader["EventTime"].AsDateTime(),
               
            };

 //       @EventID uniqueidentifier,
 //       @LoginName nvarchar(100), 		
	//	@ComputerName nvarchar(50), 		
	//	@FullName nvarchar(100), 		
	//	@EventTime datetime,
 //       @ComponentName nvarchar(100), 		
	//	@EventAction int, 		
	//	@Reference nvarchar(500), 		
	//	@Amount money
	//) 



        /// <summary>
        /// Takes the specified auditting log.
        /// </summary>
        /// <param name="audittingLog">The auditting log.</param>
        /// <returns></returns>
        private static object[] Take(AudittingLogEntity audittingLog)
        {
            return new object[]  
            {
                "@EventId", audittingLog.EventId,
                "@Amount", audittingLog.Amount,
                "@Reference", audittingLog.Reference,
                "@ComponentName", audittingLog.ComponentName,
                "@ComputerName", audittingLog.ComputerName,
                "@EventAction", audittingLog.EventAction,
                "@EventTime", audittingLog.EventTime,
                "@LoginName", audittingLog.LoginName

            };
        }
    }
}
