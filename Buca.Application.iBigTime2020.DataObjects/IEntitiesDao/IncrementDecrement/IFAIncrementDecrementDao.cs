/***********************************************************************
 * <copyright file="IFAIncrementDecrementDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 30, 2017
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
    ///     IFAIncrementDecrementDao
    /// </summary>
    public interface IFAIncrementDecrementDao
    {
        /// <summary>
        ///     Gets the fAIncrementDecrement.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     FAIncrementDecrementEntity.
        /// </returns>
        FAIncrementDecrementEntity GetFAIncrementDecrement(string refId);

        /// <summary>
        ///     Gets the fAIncrementDecrement by refdate and reftype.
        /// </summary>
        /// <param name="fAIncrementDecrement">The ob fAIncrementDecrement entity.</param>
        /// <returns></returns>
        FAIncrementDecrementEntity GetFAIncrementDecrementByRefdateAndReftype(
            FAIncrementDecrementEntity fAIncrementDecrement);

        /// <summary>
        ///     Gets the fAIncrementDecrements by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        ///     List{FAIncrementDecrementEntity}.
        /// </returns>
        List<FAIncrementDecrementEntity> GetFAIncrementDecrementsByRefTypeId(int refTypeId);

        /// <summary>
        ///     Gets the fAIncrementDecrements.
        /// </summary>
        /// <returns>
        ///     List{FAIncrementDecrementEntity}.
        /// </returns>
        List<FAIncrementDecrementEntity> GetFAIncrementDecrements();

        /// <summary>
        ///     Inserts the fAIncrementDecrement.
        /// </summary>
        /// <param name="fAIncrementDecrement">The fAIncrementDecrement.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        string InsertFAIncrementDecrement(FAIncrementDecrementEntity fAIncrementDecrement);

        /// <summary>
        ///     Updates the fAIncrementDecrement.
        /// </summary>
        /// <param name="fAIncrementDecrement">The fAIncrementDecrement.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        string UpdateFAIncrementDecrement(FAIncrementDecrementEntity fAIncrementDecrement);

        /// <summary>
        ///     Deletes the fAIncrementDecrement.
        /// </summary>
        /// <param name="fAIncrementDecrement">The fAIncrementDecrement.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        string DeleteFAIncrementDecrement(FAIncrementDecrementEntity fAIncrementDecrement);

        /// <summary>
        ///     Gets the FAIncrementDecrement by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        FAIncrementDecrementEntity GetFAIncrementDecrementByRefNo(string refNo);

        /// <summary>
        ///     Gets the FAIncrementDecrement by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        FAIncrementDecrementEntity GetFAIncrementDecrementByRefNo(string refNo, DateTime postedDate);
    }
}