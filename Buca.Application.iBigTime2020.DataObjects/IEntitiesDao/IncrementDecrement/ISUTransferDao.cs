/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 27, 2017
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
    /// ISUTransferDao
    /// </summary>
    public interface ISUTransferDao
    {
        /// <summary>
        /// Gets the sUIncrementDecrement.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        /// SUTransferEntity.
        /// </returns>
        SUTransferEntity GetSUTransfer(string refId);

        /// <summary>
        /// Gets the su transfer.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <returns></returns>
        SUTransferEntity GetSUTransfer(string refNo, DateTime postedDate);

        /// <summary>
        /// Gets the sUIncrementDecrement by refdate and reftype.
        /// </summary>
        /// <param name="sUIncrementDecrement">The ob sUIncrementDecrement entity.</param>
        /// <returns></returns>
        SUTransferEntity GetSUTransferByRefdateAndReftype(SUTransferEntity sUIncrementDecrement);

        /// <summary>
        /// Gets the sUIncrementDecrements by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        /// List{SUTransferEntity}.
        /// </returns>
        List<SUTransferEntity> GetSUTransfersByRefTypeId(int refTypeId);

        /// <summary>
        /// Gets the sUIncrementDecrements by year of reference date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="yearOfRefDate">The year of reference date.</param>
        /// <returns></returns>
        List<SUTransferEntity> GetSUTransfersByYearOfRefDate(int refTypeId, short yearOfRefDate);

        /// <summary>
        /// Gets the sUIncrementDecrements.
        /// </summary>
        /// <returns>
        /// List{SUTransferEntity}.
        /// </returns>
        List<SUTransferEntity> GetSUTransfers();

        /// <summary>
        /// Inserts the sUIncrementDecrement.
        /// </summary>
        /// <param name="sUIncrementDecrement">The sUIncrementDecrement.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string InsertSUTransfer(SUTransferEntity sUIncrementDecrement);

        /// <summary>
        /// Updates the sUIncrementDecrement.
        /// </summary>
        /// <param name="sUIncrementDecrement">The sUIncrementDecrement.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        string UpdateSUTransfer(SUTransferEntity sUIncrementDecrement);

        /// <summary>
        /// Deletes the sUIncrementDecrement.
        /// </summary>
        /// <param name="sUIncrementDecrement">The sUIncrementDecrement.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        string DeleteSUTransfer(SUTransferEntity sUIncrementDecrement);

        /// <summary>
        /// Gets the SUTransfer by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        SUTransferEntity GetSUTransferByRefNo(string refNo);
    }
}
