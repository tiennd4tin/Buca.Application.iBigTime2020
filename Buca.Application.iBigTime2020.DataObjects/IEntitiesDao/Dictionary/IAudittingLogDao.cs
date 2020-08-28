﻿/***********************************************************************
 * <copyright file="IAudittingLogDao.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;


namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// IAudittingLogDao
    /// </summary>
    public interface IAudittingLogDao
    {
        /// <summary>
        /// Gets the auditting logs.
        /// </summary>
        /// <returns></returns>
        List<AudittingLogEntity> GetAudittingLogs();

        /// <summary>
        /// Gets the auditting log.
        /// </summary>
        /// <param name="eventId">The event identifier.</param>
        /// <returns></returns>
        AudittingLogEntity GetAudittingLog_by_eventId(string eventId);

        /// <summary>
        /// Inserts the auditting log.
        /// </summary>
        /// <param name="audittingLog">The auditting log.</param>
        /// <returns></returns>
        string InsertAudittingLog(AudittingLogEntity audittingLog);

        /// <summary>
        /// Deletes the auditting log.
        /// </summary>
        /// <param name="audittingLog">The auditting log.</param>
        /// <returns></returns>
        string DeleteAudittingLog(AudittingLogEntity audittingLog);
    }
}
