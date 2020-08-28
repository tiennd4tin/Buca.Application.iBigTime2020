/***********************************************************************
 * <copyright file="ISUIncrementDecrementDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Wednesday, October 25, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.IncrementDecrement;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IncrementDecrement
{
    /// <summary>
    ///     ISUIncrementDecrementDao
    /// </summary>
    public interface ISUIncrementDecrementDao
    {
        /// <summary>
        ///     Gets the sUIncrementDecrement.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>SUIncrementDecrementEntity.</returns>
        SUIncrementDecrementEntity GetSUIncrementDecrement(string refId);

        /// <summary>
        ///     Gets the sUIncrementDecrement by refdate and reftype.
        /// </summary>
        /// <param name="sUIncrementDecrement">The ob sUIncrementDecrement entity.</param>
        /// <returns></returns>
        SUIncrementDecrementEntity GetSUIncrementDecrementByRefdateAndReftype(
            SUIncrementDecrementEntity sUIncrementDecrement);

        /// <summary>
        ///     Gets the sUIncrementDecrements by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List{SUIncrementDecrementEntity}.</returns>
        List<SUIncrementDecrementEntity> GetSUIncrementDecrementsByRefTypeId(int refTypeId);

        /// <summary>
        ///     Gets the sUIncrementDecrements by year of reference date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="yearOfRefDate">The year of reference date.</param>
        /// <returns></returns>
        List<SUIncrementDecrementEntity> GetSUIncrementDecrementsByYearOfRefDate(int refTypeId, short yearOfRefDate);

        /// <summary>
        ///     Gets the sUIncrementDecrements.
        /// </summary>
        /// <returns>List{SUIncrementDecrementEntity}.</returns>
        List<SUIncrementDecrementEntity> GetSUIncrementDecrements();

        /// <summary>
        ///     Inserts the sUIncrementDecrement.
        /// </summary>
        /// <param name="sUIncrementDecrement">The sUIncrementDecrement.</param>
        /// <returns>System.Int32.</returns>
        string InsertSUIncrementDecrement(SUIncrementDecrementEntity sUIncrementDecrement);

        /// <summary>
        ///     Updates the sUIncrementDecrement.
        /// </summary>
        /// <param name="sUIncrementDecrement">The sUIncrementDecrement.</param>
        /// <returns>System.String.</returns>
        string UpdateSUIncrementDecrement(SUIncrementDecrementEntity sUIncrementDecrement);

        /// <summary>
        ///     Deletes the sUIncrementDecrement.
        /// </summary>
        /// <param name="sUIncrementDecrement">The sUIncrementDecrement.</param>
        /// <returns>System.String.</returns>
        string DeleteSUIncrementDecrement(SUIncrementDecrementEntity sUIncrementDecrement);

        /// <summary>
        ///     Gets the SUIncrementDecrement by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        SUIncrementDecrementEntity GetSUIncrementDecrementByRefNo(string refNo);

        /// <summary>
        ///     Gets the SUIncrementDecrement by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        SUIncrementDecrementEntity GetSUIncrementDecrementByRefNo(string refNo, DateTime postedDate);
    }
}